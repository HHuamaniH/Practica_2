using CapaEntidad.DOC;
using CapaEntidad.ViewModel;
using GeneralSQL;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CapaDatos.DOC
{
    public class Dat_PAU_RD_Digital
    {
        private DBOracle dBOracle;

        public Dat_PAU_RD_Digital()
        {
            dBOracle = new DBOracle();
        }

        public string RegRDGrabar(Ent_ResDirTabInforme informeDigital, VM_PAU_RD_DIGITAL otros)
        {
            String OUTPUTPARAM01 = "", codInformeDigital = informeDigital.pVCodInformeDigital;

            OracleTransaction tr = null;
            using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
            {
                cn.Open();
                tr = cn.BeginTransaction();
                try
                {
                    using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.SPFISCALIZACION_RESDIR_DIGITAL_GRABAR", informeDigital))
                    {
                        cmd.ExecuteNonQuery();
                        OUTPUTPARAM01 = (String)cmd.Parameters["pVOUTPUTPARAM01"].Value;
                        codInformeDigital = OUTPUTPARAM01;

                        if (otros.ILEGAL != null)
                        {
                            foreach (var item in otros.ILEGAL)
                            {
                                object[] param = { codInformeDigital, item.item, item.codILegal, item.estado, item.accion };
                                dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.SPFISCALIZACION_RESDIR_DIGITAL_ILEGAL_GRABAR", param);
                            }
                        }
                        if (otros.REFERENCIAS != null)
                        {
                            foreach (var item in otros.REFERENCIAS)
                            {
                                if (item.RegEstado == 1) //Nuevo o modificado
                                {
                                    object[] param = { item.COD_RESODIREC, item.CODIGO, item.NUMERO, item.PDF_DOCUMENTO, item.TIPO_DOCUMENTO, item.SUBTIPO, 1 };
                                    dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.RESODIREC_DET_ACCIONGrabar", param);
                                }
                            }
                        }
                        if (otros.DOCUMENTOS != null)
                        {
                            foreach (var item in otros.DOCUMENTOS)
                            {
                                object[] param = { codInformeDigital, item.item, item.codResolucion, item.tipo, item.url, item.nombre, item.estado, item.accion };
                                dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.SPFISCALIZACION_RESDIR_DIGITAL_DOCUMENTO_GRABAR", param);
                            }
                        }
                        if (otros.PARTICIPANTES != null)
                        {
                            foreach (var item in otros.PARTICIPANTES)
                            {
                                object[] param = { codInformeDigital, item.item, item.codPersona, item.funcion, item.observacion, item.estado, item.accion };
                                dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.SPFISCALIZACION_RESDIR_DIGITAL_PARTICIPANTE_GRABAR", param);
                            }
                        }
                        if (otros.INFRACCIONES != null)
                        {
                            foreach (var item in otros.INFRACCIONES)
                            {
                                object[] param = { codInformeDigital, item.item, item.codILegal, item.codResolucion, item.codInciso, item.titulo, item.parrafos, item.estado, item.flgSeleccionado, item.accion };
                                dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.SPFISCALIZACION_RESDIR_DIGITAL_INFRACCION_GRABAR", param);
                            }
                        }
                        if (otros.ANTECEDENTES != null)
                        {
                            foreach (var item in otros.ANTECEDENTES)
                            {
                                object[] param = {
                                    codInformeDigital,
                                    item.item, item.codILegal,
                                    item.tipoDocumento, item.numero,
                                    item.codDocumento,
                                    string.IsNullOrEmpty(item.fechaEmision) ? default(DateTime?) : Convert.ToDateTime(item.fechaEmision),
                                    string.IsNullOrEmpty(item.fechaNotificacion) ? default(DateTime?) : Convert.ToDateTime(item.fechaNotificacion),
                                    item.estado,
                                    item.accion
                                };

                                dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.SPFISCALIZACION_RESDIR_DIGITAL_ANTECEDENTES_GRABAR", param);
                            }
                        }

                        if (otros.ELIMINAR != null)
                        {
                            foreach (var item in otros.ELIMINAR)
                            {
                                object[] param = { item.codInforme, item.item, item.origen };
                                dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.SPFISCALIZACION_RESDIR_DIGITAL_DET_ELIMINAR", param);
                            }
                        }
                    }
                    tr.Commit();
                }
                catch (Exception ex)
                {
                    if (tr != null)
                    {
                        tr.Rollback();
                        tr.Dispose();
                        tr = null;
                    }
                    throw ex;
                }

            }
            return codInformeDigital;
        }

        public bool ParticipanteActualizar(VM_PAU_RD_DIGITAL_PARTICIPANTE item)
        {
            bool txSuccess = false;
            OracleTransaction tr = null;
            using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
            {
                cn.Open();
                tr = cn.BeginTransaction();

                try
                {
                    object[] param = { item.codInformeDigital, item.item, item.codPersona, item.funcion, item.observacion, item.estado, 1 };
                    int rows = dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.SPFISCALIZACION_RESDIR_DIGITAL_PARTICIPANTE_GRABAR", param);

                    tr.Commit();

                    txSuccess = rows != 0;
                }
                catch (Exception ex)
                {
                    if (tr != null)
                    {
                        tr.Rollback();
                        tr.Dispose();
                        tr = null;
                    }
                    throw ex;
                }
            }

            return txSuccess;
        }

        public VM_PAU_RD_DIGITAL ObtenerRD(string COD_RESOLUCION)
        {
            VM_PAU_RD_DIGITAL vm = null;
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, "DOC_OSINFOR_ERP_MIGRACION.SPFISCALIZACION_RESDIR_DIGITAL_OBTENER", COD_RESOLUCION))
                    {
                        if (dr != null)
                        {
                            if (dr.HasRows)
                            {
                                vm = new VM_PAU_RD_DIGITAL();

                                while (dr.Read())
                                {
                                    vm.COD_INFORME_DIGITAL = dr["VCODINFORMEDIGITAL"].ToString();
                                    vm.COD_RESOLUCION = dr["VCODRESOLUCION"].ToString();
                                    vm.TRAMITE_ID = dr["NTRAMITEID"] != DBNull.Value ? Convert.ToInt32(dr["NTRAMITEID"]) : default(int?);
                                    vm.NUM_INFORME_SITD = dr["VNUMINFORMESITD"].ToString();
                                    vm.COD_PROCEDENCIA = dr["VCODPROCEDENCIA"].ToString();
                                    vm.COD_TIPO_INFORME = dr["VCODTIPOINFORME"].ToString();
                                    vm.COD_MATERIA = dr["VCODMATERIA"].ToString();
                                    vm.COD_MODALIDAD = dr["VCODMODALIDAD"].ToString();
                                    vm.COD_THABILITANTE = dr["COD_THABILITANTE"].ToString();
                                    vm.COD_TITULAR = dr["COD_TITULAR"].ToString();
                                    vm.TITULAR = dr["TITULAR"].ToString();
                                    vm.NUM_CONTRATO = dr["NUM_CONTRATO"].ToString();
                                    vm.TITULAR_DOCUMENTO = dr["TITULAR_DOCUMENTO"].ToString();
                                    vm.TITULAR_RUC = dr["TITULAR_RUC"].ToString();
                                    vm.TITULAR_ESTADO_RUC = dr["TITULAR_ESTADO_RUC"].ToString();
                                    vm.TITULAR_CONDICION_RUC = dr["TITULAR_CONDICION_RUC"].ToString();
                                    vm.R_LEGAL = dr["R_LEGAL"].ToString();
                                    vm.R_LEGAL_DOCUMENTO = dr["R_LEGAL_DOCUMENTO"].ToString();
                                    vm.R_LEGAL_RUC = dr["R_LEGAL_RUC"].ToString();
                                    vm.UBIGEO_COD_DPTO = dr["UBIGEO_COD_DPTO"].ToString();
                                    vm.UBIGEO_DEPARTAMENTO = dr["UBIGEO_DEPARTAMENTO"].ToString();
                                    vm.UBIGEO_COD_PROV = dr["UBIGEO_COD_PROV"].ToString();
                                    vm.UBIGEO_PROVINCIA = dr["UBIGEO_PROVINCIA"].ToString();
                                    vm.UBIGEO_COD_DIST = dr["UBIGEO_COD_DIST"].ToString();
                                    vm.UBIGEO_DISTRITO = dr["UBIGEO_DISTRITO"].ToString();
                                    vm.UBIGEO_SECTOR = dr["UBIGEO_SECTOR"].ToString();
                                    vm.FLG_RESPONSABLE_SOLIDARIO = Convert.ToBoolean(dr["NFLAGRESPONSABLESOLIDARIO"]);
                                    vm.FLG_GRAVEDAD_OCASIONADA = Convert.ToBoolean(dr["NFLAGGRAVEDADOCASIONADA"]);
                                    vm.FLG_ACREDITACION_IMPUTACIONES = Convert.ToBoolean(dr["NFLAGACREDITACIONIMPUTACIONES"]);
                                    vm.FLG_SANCION = Convert.ToInt16(dr["NFLAGSANCION"]);
                                    vm.SANCION_UIT = Convert.ToDecimal(dr["NSANCIONUIT"]);
                                    vm.SANCION_COD_CALCULO = dr["VSANCIONCODCALCULO"].ToString();
                                    vm.FLG_MEDIDAS_COMPLEMENTARIAS = Convert.ToBoolean(dr["NFLAGMEDIDASCOMPLEMENTARIAS"]);
                                    vm.FLG_MEDIDAS_CORRECTIVAS = Convert.ToBoolean(dr["NFLAGMEDIDASCORRECTIVAS"]);
                                    vm.FLG_COMUNICACION_ENTIDADES = Convert.ToBoolean(dr["NFLAGCOMUNICACIONENTIDADES"]);
                                    vm.RUTA_ARCHIVO_REVISION = dr["VRUTAARCHIVOREVISION"].ToString();
                                    vm.COD_USUARIO_OPERACION = dr["VCODUSUARIOCREACION"].ToString();
                                    //vm.COD_USUARIO_MODIFICACION = dr["VCODUSUARIOMODIFICACION"].ToString();
                                    vm.ESTADO = Convert.ToInt16(dr["NESTADO"]);
                                }
                            }

                            //INFORMES LEGALES ASOCIADOS
                            dr.NextResult();
                            if (dr.HasRows)
                            {
                                VM_PAU_RD_DIGITAL_VS_ILEGAL objEN = null;
                                while (dr.Read())
                                {
                                    objEN = new VM_PAU_RD_DIGITAL_VS_ILEGAL();
                                    objEN.codInformeDigital = dr["VCODINFORMEDIGITAL"].ToString();
                                    objEN.item = Convert.ToInt32(dr["NITEM"]);
                                    objEN.codILegal = dr["VCODRESOLUCION"].ToString();
                                    objEN.nroILegal = dr["NUMERO_RESOLUCION"].ToString();
                                    //objEN.codInformeSupervision = dr["COD_ISUPERVISION"].ToString();
                                    //objEN.numInformeSupervision = dr["NUMERO_ISUPERVISION"].ToString();
                                    //POA
                                    //objEN.numAResolucion = dr["ARESOLUCION_NUM"].ToString();
                                    //objEN.numPOA = dr["NUM_POA"].ToString();
                                    //objEN.nombrePOA = dr["NOMBRE_POA"].ToString();

                                    objEN.estado = Convert.ToInt32(dr["NESTADO"]);
                                    objEN.accion = 1;
                                    vm.ILEGAL.Add(objEN);
                                }
                            }

                            //PARTICIPANTE
                            dr.NextResult();
                            if (dr.HasRows)
                            {
                                VM_PAU_RD_DIGITAL_PARTICIPANTE objEN = null;
                                while (dr.Read())
                                {
                                    objEN = new VM_PAU_RD_DIGITAL_PARTICIPANTE();
                                    objEN.codInformeDigital = dr["VCODINFORMEDIGITAL"].ToString();
                                    objEN.item = Convert.ToInt32(dr["NITEM"]);
                                    objEN.codPersona = dr["VCODPARTICIPANTE"].ToString();
                                    objEN.apellidosNombres = dr["APELLIDOS_NOMBRES"].ToString();
                                    objEN.numeroDocumento = dr["N_DOCUMENTO"].ToString();
                                    objEN.funcion = dr["VFUNCION"] != DBNull.Value ? dr["VFUNCION"].ToString() : null;
                                    objEN.observacion = dr["VOBSERVACION"] != DBNull.Value ? dr["VOBSERVACION"].ToString() : null;
                                    if (dr["NESTADO"] != DBNull.Value) objEN.estado = Convert.ToInt32(dr["NESTADO"]);
                                    objEN.accion = 1;
                                    vm.PARTICIPANTES.Add(objEN);
                                }
                            }

                            //DOCUMENTOS
                            dr.NextResult();
                            if (dr.HasRows)
                            {
                                VM_PAU_RD_DIGITAL_DOCUMENTO objEN = null;
                                while (dr.Read())
                                {
                                    objEN = new VM_PAU_RD_DIGITAL_DOCUMENTO();
                                    objEN.codInformeDigital = dr["VCODINFORMEDIGITAL"].ToString();
                                    objEN.item = Convert.ToInt32(dr["NITEM"]);
                                    objEN.codResolucion = dr["VCODRESOLUCION"].ToString();
                                    objEN.tipo = dr["VTIPO"].ToString();
                                    objEN.nombre = dr["VNOMBRE"].ToString();
                                    objEN.url = dr["VURL"] != DBNull.Value ? dr["VURL"].ToString() : null;
                                    objEN.estado = Convert.ToInt32(dr["NESTADO"]);
                                    objEN.accion = 1;
                                    vm.DOCUMENTOS.Add(objEN);
                                }
                            }

                            //INFRACCIONES
                            dr.NextResult();
                            if (dr.HasRows)
                            {
                                VM_PAU_RD_DIGITAL_INFRACCION objEN = null;
                                while (dr.Read())
                                {
                                    objEN = new VM_PAU_RD_DIGITAL_INFRACCION();
                                    objEN.codInformeDigital = dr["VCODINFORMEDIGITAL"].ToString();
                                    objEN.item = Convert.ToInt32(dr["NITEM"]);
                                    objEN.codILegal = dr["VCODILEGAL"].ToString();
                                    objEN.codResolucion = dr["VCODRESOLUCION"].ToString();
                                    objEN.codInciso = dr["VCODINCISO"].ToString();
                                    objEN.inciso = dr["VINCISO"].ToString();
                                    objEN.titulo = dr["VTITULO"].ToString();
                                    objEN.detalle = dr["DESCRIPCION_INFRACCIONES"].ToString();
                                    objEN.gravedad = dr["GRAVEDAD"] != DBNull.Value ? dr["GRAVEDAD"].ToString() : null;
                                    objEN.rangoSancion = dr["RANGO_SANCION"] != DBNull.Value ? dr["RANGO_SANCION"].ToString() : null;
                                    objEN.tipoInfraccion = dr["TIPO_INFRACCION"] != DBNull.Value ? Convert.ToInt32(dr["TIPO_INFRACCION"].ToString()) : default(int?);

                                    objEN.codEspecie = dr["COD_ESPECIES"] != DBNull.Value ? dr["COD_ESPECIES"].ToString() : null;
                                    objEN.especie = dr["DESCRIPCION_ESPECIE"] != DBNull.Value ? dr["DESCRIPCION_ESPECIE"].ToString() : null;
                                    objEN.volumen = dr["VOLUMEN"] != DBNull.Value ? Convert.ToDouble(dr["VOLUMEN"]) : 0;
                                    objEN.area = dr["AREA"] != DBNull.Value ? Convert.ToDouble(dr["AREA"]) : 0;
                                    objEN.nroIndividuos = dr["NUMERO_INDIVIDUOS"] != DBNull.Value ? Convert.ToDouble(dr["NUMERO_INDIVIDUOS"]) : 0;
                                    objEN.numPOA = dr["NUM_POA"] != DBNull.Value ? dr["NUM_POA"].ToString() : null;
                                    //objEN.numAResolucion = dr["ARESOLUCION_NUM"] != DBNull.Value ? dr["ARESOLUCION_NUM"].ToString() : null;
                                    objEN.tipoMaderable = dr["TIPOMADERABLE"].ToString();

                                    //objEN.flgDesvirtua = Convert.ToBoolean(dr["NFLAGDESVIRTUA"]);
                                    //objEN.flgSubsana = Convert.ToBoolean(dr["NFLAGSUBSANA"]);
                                    objEN.parrafos = dr["VPARRAFOS"] != DBNull.Value ? dr["VPARRAFOS"].ToString() : null;
                                    objEN.estado = Convert.ToInt32(dr["NESTADO"]);
                                    objEN.flgSeleccionado = dr["NFLAGSELECCIONADO"] != DBNull.Value ? Convert.ToInt16(dr["NFLAGSELECCIONADO"]) == 1 : false;
                                    objEN.accion = 1;

                                    vm.INFRACCIONES.Add(objEN);
                                }
                            }

                            //ANTECEDENTES
                            dr.NextResult();
                            if (dr.HasRows)
                            {
                                VM_PAU_RD_DIGITAL_ANTECEDENTE objEN = null;
                                while (dr.Read())
                                {
                                    objEN = new VM_PAU_RD_DIGITAL_ANTECEDENTE();
                                    objEN.codInformeDigital = dr["VCODINFORMEDIGITAL"].ToString();
                                    objEN.item = Convert.ToInt32(dr["NITEM"]);
                                    objEN.codILegal = dr["VCODILEGAL"].ToString();
                                    objEN.tipoDocumento = dr["VTIPODOCUMENTO"].ToString();
                                    objEN.numero = dr["VNUMERO"].ToString();
                                    objEN.codDocumento = dr["VCODDOCUMENTO"].ToString();
                                    objEN.fechaEmision = dr["DFECHAEMISION"] != DBNull.Value ? Convert.ToDateTime(dr["DFECHAEMISION"]).ToShortDateString() : null;
                                    objEN.fechaNotificacion = dr["DFECHANOTIFICACION"] != DBNull.Value ? Convert.ToDateTime(dr["DFECHANOTIFICACION"]).ToShortDateString() : null;
                                    objEN.estado = Convert.ToInt32(dr["NESTADO"]);
                                    objEN.accion = 1;

                                    vm.ANTECEDENTES.Add(objEN);
                                }
                            }
                        }
                    }
                }

                return vm;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<VM_PAU_RD_DIGITAL_ANTECEDENTE> ObtenerAntecedentes(string COD_RESOLUCION)
        {
            List<VM_PAU_RD_DIGITAL_ANTECEDENTE> vm = null;

            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();

                    using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, "DOC_OSINFOR_ERP_MIGRACION.SPFISCALIZACION_RESDIR_DIGITAL_ANTECEDENTES", COD_RESOLUCION))
                    {
                        if (dr != null)
                        {
                            if (dr.HasRows)
                            {
                                vm = new List<VM_PAU_RD_DIGITAL_ANTECEDENTE>();

                                VM_PAU_RD_DIGITAL_ANTECEDENTE objEN = null;

                                while (dr.Read())
                                {
                                    objEN = new VM_PAU_RD_DIGITAL_ANTECEDENTE();
                                    objEN.tipoDocumento = dr["TIPO_DOCUMENTO"].ToString();
                                    objEN.numero = dr["NUMERO"].ToString();
                                    objEN.codDocumento = dr["COD_DOCUMENTO"].ToString();
                                    objEN.fechaEmision = (dr["FECHA_EMISION"] != DBNull.Value) ? dr["FECHA_EMISION"].ToString().Trim() : null;
                                    objEN.fechaNotificacion = (dr["FECHA_NOTIFICACION"] != DBNull.Value) ? dr["FECHA_NOTIFICACION"].ToString().Trim() : null;
                                    vm.Add(objEN);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return vm;
        }

        public List<VM_PAU_RD_DIGITAL_INFRACCION> ListarInfracciones()
        {
            try
            {
                List<VM_PAU_RD_DIGITAL_INFRACCION> result = new List<VM_PAU_RD_DIGITAL_INFRACCION>();

                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();

                    using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, "DOC_OSINFOR_ERP_MIGRACION.SPFISCALIZACION_RESDIR_DIGITAL_INFRACCIONES_OBTENER"))
                    {
                        if (dr != null)
                        {
                            //INFORME
                            if (dr.HasRows)
                            {
                                VM_PAU_RD_DIGITAL_INFRACCION objEN = null;
                                while (dr.Read())
                                {
                                    objEN = new VM_PAU_RD_DIGITAL_INFRACCION();
                                    //objEN.codInfraccion = Convert.ToInt32(dr["NCodInfraccion"]);
                                    //objEN.codModalidad = dr["VCodModalidad"].ToString();
                                    //objEN.titulo = dr["VTitulo"].ToString();
                                    //objEN.conducta = dr["VConducta"].ToString();
                                    //objEN.tipoInfractor = dr["VTipoInfractor"].ToString();
                                    //objEN.numeral = dr["VNumeral"].ToString();
                                    //objEN.sancion = dr["VSancion"].ToString();
                                    //objEN.subsanar = dr["VSubsanar"].ToString();
                                    //objEN.codPlantilla = dr["VCodPlantilla"].ToString();

                                    result.Add(objEN);
                                }
                            }
                        }
                    }
                }

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string Notificar(VM_PAU_DIGITAL_ALERTA notificacion)
        {
            string OUTPUTPARAM01 = "";

            OracleTransaction tr = null;
            using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
            {
                cn.Open();
                tr = cn.BeginTransaction();
                try
                {
                    //object[] param = { notificacion.COD_PERSONA, notificacion.COD_INFORME, notificacion.MENSAJE_ENVIO_ALERTA };
                    using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.SPFISCALIZACION_PAU_DIGITAL_ENVIARALERTA", notificacion))
                    {
                        cmd.ExecuteNonQuery();
                        OUTPUTPARAM01 = cmd.Parameters["OUTPUTPARAM01"].Value?.ToString() ?? "";
                    }
                    tr.Commit();
                }
                catch (Exception ex)
                {
                    if (tr != null)
                    {
                        tr.Rollback();
                        tr.Dispose();
                        tr = null;
                    }
                    throw ex;
                }

            }
            return OUTPUTPARAM01;
        }

        public void ModificarNumeroInforme(string codInforme, string numeroInforme, DateTime fechaOperacion)
        {
            using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
            {
                cn.Open();
                try
                {
                    object[] param = { codInforme, numeroInforme, fechaOperacion };
                    dBOracle.ManExecute(cn, null, "DOC_OSINFOR_ERP_MIGRACION.SPFISCALIZACION_RESDIR_DIGITAL_NUMERO_GUARDAR", param);

                }
                catch (Exception ex)
                {

                    throw ex;
                }

            }
        }

        public bool CambiarEstado(string codInformeDigital, DateTime fechaOperacion, int estado, string codUsuarioOperacion)
        {

            bool success = false;
            using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
            {
                cn.Open();

                try
                {
                    object[] param = { codInformeDigital, fechaOperacion, estado, codUsuarioOperacion };
                    dBOracle.ManExecute(cn, null, "DOC_OSINFOR_ERP_MIGRACION.SPFISCALIZACION_RESDIR_DIGITAL_ESTADO_ACTUALIZAR", param);
                    success = true;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return success;
        }

        public bool AnularFirmaPorInforme(string codInforme)
        {
            bool success = false;
            OracleTransaction tr = null;

            using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
            {
                cn.Open();
                tr = cn.BeginTransaction();
                try
                {
                    object[] param = { codInforme, "ANULAR_FIRMA_POR_INFORME", "" };
                    dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.SPFISCALIZACION_RESDIR_DIGITAL_OPERACION", param);
                    tr.Commit();
                    success = true;
                }
                catch (Exception ex)
                {
                    if (tr != null)
                    {
                        tr.Rollback();
                        tr.Dispose();
                        tr = null;
                    }
                    throw ex;
                }
            }
            return success;
        }

        public VM_PAU_RD_INFORME_LEGAL_RESUMEN ObtenerResumenInformeLegal(string COD_ILEGAL)
        {
            VM_PAU_RD_INFORME_LEGAL_RESUMEN objEN = null;

            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();

                    using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, "DOC_OSINFOR_ERP_MIGRACION.SPFISCALIZACION_INFORME_LEGAL_RESUMEN", COD_ILEGAL))
                    {
                        if (dr != null)
                        {
                            if (dr.HasRows)
                            {
                                objEN = new VM_PAU_RD_INFORME_LEGAL_RESUMEN();
                                var columns = Enumerable.Range(0, dr.FieldCount).Select(dr.GetName).ToList();

                                while (dr.Read())
                                {
                                    objEN.COD_THABILITANTE = dr["COD_THABILITANTE"] as string;
                                    objEN.COD_TITULAR = dr["COD_TITULAR"] as string;
                                    objEN.NUM_THABILITANTE = dr["NUM_THABILITANTE"] as string;
                                    objEN.TITULAR = dr["TITULAR"] as string;
                                    objEN.TITULAR_DOCUMENTO = dr["TITULAR_DOCUMENTO"] as string;
                                    objEN.TITULAR_RUC = dr["TITULAR_RUC"] as string;
                                    objEN.R_LEGAL = dr["R_LEGAL"] as string;
                                    objEN.R_LEGAL_DOCUMENTO = dr["R_LEGAL_DOCUMENTO"] as string;
                                    objEN.R_LEGAL_RUC = dr["R_LEGAL_RUC"] as string;
                                    objEN.UBIGEO_DEPARTAMENTO = dr["UBIGEO_DEPARTAMENTO"] as string;
                                    objEN.UBIGEO_PROVINCIA = dr["UBIGEO_PROVINCIA"] as string;
                                    objEN.UBIGEO_DISTRITO = dr["UBIGEO_DISTRITO"] as string;
                                    objEN.COD_ISUPERVISION = dr["COD_ISUPERVISION"] as string;
                                    objEN.NUMERO_ISUPERVISION = dr["NUMERO_ISUPERVISION"] as string;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return objEN;
        }
    }
}
