using CapaEntidad.DOC;
using CapaEntidad.Documento;
using CapaEntidad.ViewModel;
using GeneralSQL;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using SQL = GeneralSQL.Data.SQL;

namespace CapaDatos.Documento
{
    public class Dat_Informe_Legal_Digital
    {
        private DBOracle dBOracle;
        private SQL oGDataSQL;

        public Dat_Informe_Legal_Digital()
        {
            dBOracle = new DBOracle();
            oGDataSQL = new SQL();
        }

        public string RegInformeGrabar(Ent_InformeLegalPAUDigital informeDigital, VM_INFORME_LEGAL_DIGITAL oILegal)
        {
            string OUTPUTPARAM01 = "", codInformeDigital = informeDigital.pVCodInformeDigital;

            OracleTransaction tr = null;
            using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
            {
                cn.Open();
                tr = cn.BeginTransaction();
                try
                {
                    using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.SPFISCALIZACION_INFORME_LEGAL_DIGITAL_GRABAR", informeDigital))
                    {
                        cmd.ExecuteNonQuery();
                        OUTPUTPARAM01 = (String)cmd.Parameters["pVOUTPUTPARAM01"].Value;
                        codInformeDigital = OUTPUTPARAM01;

                        if (oILegal.RSD != null)
                        {
                            foreach (var item in oILegal.RSD)
                            {
                                object[] param = { codInformeDigital, item.item, item.codResolucion, item.estado, item.accion };
                                dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.SPFISCALIZACION_INFORME_LEGAL_DIGITAL_RSD_GRABAR", param);
                            }
                        }
                        if (oILegal.REFERENCIAS != null)
                        {
                            foreach (var item in oILegal.REFERENCIAS)
                            {
                                if (item.RegEstado == 1) //Nuevo o modificado
                                {
                                    object[] param = { item.COD_ILEGAL, item.CODIGO, item.NUMERO, item.PDF_DOCUMENTO, item.TIPO_DOCUMENTO, item.SUBTIPO, 1 };
                                    dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spILEGAL_DET_ACCIONGrabar", param);
                                }
                            }
                        }
                        if (oILegal.DOCUMENTOS != null)
                        {
                            foreach (var item in oILegal.DOCUMENTOS)
                            {
                                object[] param = { codInformeDigital, item.item, item.codResolucion, item.tipo, item.url, item.nombre, item.estado, item.accion };
                                dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.SPFISCALIZACION_INFORME_LEGAL_DIGITAL_DOCUMENTO_GRABAR", param);
                            }
                        }
                        if (oILegal.PARTICIPANTES != null)
                        {
                            foreach (var item in oILegal.PARTICIPANTES)
                            {
                                object[] param = { codInformeDigital, item.item, item.codPersona, item.funcion, item.observacion, item.estado, item.accion };
                                dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.SPFISCALIZACION_INFORME_LEGAL_DIGITAL_PARTICIPANTE_GRABAR", param);
                            }
                        }
                        if (oILegal.INFRACCIONES != null)
                        {
                            foreach (var item in oILegal.INFRACCIONES)
                            {
                                object[] param = { codInformeDigital, item.item, item.codResolucion, item.codInciso, item.titulo, Convert.ToInt16(item.flgDesvirtua), Convert.ToInt16(item.flgSubsana), item.parrafos, item.estado, item.accion };
                                dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.SPFISCALIZACION_INFORME_LEGAL_DIGITAL_INFRACCION_GRABAR", param);
                            }
                        }
                        if (oILegal.ANTECEDENTES != null)
                        {
                            foreach (var item in oILegal.ANTECEDENTES)
                            {
                                object[] param = {
                                    codInformeDigital,
                                    item.item, item.codResolucion,
                                    item.tipoDocumento, item.numero,
                                    string.IsNullOrEmpty(item.fechaEmision) ? default(DateTime?) : Convert.ToDateTime(item.fechaEmision),
                                    string.IsNullOrEmpty(item.fechaNotificacion) ? default(DateTime?) : Convert.ToDateTime(item.fechaNotificacion),
                                    item.estado,
                                    item.accion
                                };

                                dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.SPFISCALIZACION_INFORME_LEGAL_DIGITAL_ANTECEDENTES_GRABAR", param);
                            }
                        }

                        if (oILegal.ELIMINAR != null)
                        {
                            foreach (var item in oILegal.ELIMINAR)
                            {
                                object[] param = { item.codInforme, item.item, item.origen };
                                dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.SPFISCALIZACION_INFORME_LEGAL_DIGITAL_DET_ELIMINAR", param);
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

        public VM_INFORME_LEGAL_DIGITAL ObtenerInforme(string COD_RESOLUCION)
        {
            VM_INFORME_LEGAL_DIGITAL vm = null;
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, "DOC_OSINFOR_ERP_MIGRACION.SPFISCALIZACION_INFORME_LEGAL_DIGITAL_OBTENER", COD_RESOLUCION))
                    {
                        if (dr != null)
                        {
                            if (dr.HasRows)
                            {
                                vm = new VM_INFORME_LEGAL_DIGITAL();

                                while (dr.Read())
                                {
                                    vm.COD_INFORME_DIGITAL = dr["VCODINFORMEDIGITAL"].ToString();
                                    vm.COD_INFORME = dr["VCODINFORME"].ToString();
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
                                    vm.FLG_CUESTION_PREVIA = Convert.ToBoolean(dr["NFLAGCUESTIONPREVIA"]);
                                    vm.FLG_REC_RESPONSABILIDAD = Convert.ToBoolean(dr["NFLAGRECRESPONSABILIDAD"]);
                                    vm.FLG_GRAVEDAD_RIESGO = Convert.ToBoolean(dr["NFLAGGRAVEDADRIESGO"]);
                                    vm.FLG_SANCION = Convert.ToInt16(dr["NFLAGSANCION"]);
                                    vm.SANCION_UIT = Convert.ToDecimal(dr["NSANCIONUIT"]);
                                    vm.SANCION_COD_CALCULO = dr["VSANCIONCODCALCULO"].ToString();
                                    vm.FLG_MEDIDA_CORRECTIVA = Convert.ToBoolean(dr["NFLAGMEDIDACORRECTIVA"]);
                                    vm.FLG_MEDIDA_COMPLEMENTARIA = Convert.ToBoolean(dr["NFLAGMEDIDACOMPLEMENTARIA"]);
                                    vm.FLG_RESPONSABLE_SOLIDARIO = Convert.ToBoolean(dr["NFLAGRESPONSABLESOLIDARIO"]);
                                    vm.FLG_COMUNICACION_GORE = Convert.ToBoolean(dr["NFLAGCOMUNICACIONGORE"]);
                                    vm.RUTA_ARCHIVO_REVISION = dr["VRUTAARCHIVOREVISION"].ToString();
                                    vm.COD_USUARIO_OPERACION = dr["VCODUSUARIOCREACION"].ToString();
                                    //vm.COD_USUARIO_MODIFICACION = dr["VCODUSUARIOMODIFICACION"].ToString();
                                    vm.ESTADO = Convert.ToInt16(dr["NESTADO"]);
                                }
                            }

                            //RSD ASOCIADAS
                            dr.NextResult();
                            if (dr.HasRows)
                            {
                                VM_INFORME_LEGAL_DIGITAL_VS_RSD objEN = null;
                                while (dr.Read())
                                {
                                    objEN = new VM_INFORME_LEGAL_DIGITAL_VS_RSD();
                                    objEN.codInformeDigital = dr["VCODINFORMEDIGITAL"].ToString();
                                    objEN.item = Convert.ToInt32(dr["NITEM"]);
                                    objEN.codResolucion = dr["VCODRESOLUCION"].ToString();
                                    objEN.numInforme = dr["NUMERO_RESOLUCION"].ToString();
                                    objEN.estado = Convert.ToInt32(dr["NESTADO"]);
                                    objEN.accion = 1;
                                    vm.RSD.Add(objEN);
                                }
                            }

                            //PARTICIPANTE
                            dr.NextResult();
                            if (dr.HasRows)
                            {
                                VM_INFORME_LEGAL_DIGITAL_PARTICIPANTE objEN = null;
                                while (dr.Read())
                                {
                                    objEN = new VM_INFORME_LEGAL_DIGITAL_PARTICIPANTE();
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
                                VM_INFORME_LEGAL_DIGITAL_DOCUMENTO objEN = null;
                                while (dr.Read())
                                {
                                    objEN = new VM_INFORME_LEGAL_DIGITAL_DOCUMENTO();
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
                                VM_INFORME_LEGAL_DIGITAL_INFRACCION objEN = null;
                                while (dr.Read())
                                {
                                    objEN = new VM_INFORME_LEGAL_DIGITAL_INFRACCION();
                                    objEN.codInformeDigital = dr["VCODINFORMEDIGITAL"].ToString();
                                    objEN.item = Convert.ToInt32(dr["NITEM"]);
                                    objEN.codResolucion = dr["VCODRESOLUCION"].ToString();
                                    objEN.codInciso = dr["VCODINCISO"].ToString();
                                    objEN.inciso = dr["VINCISO"].ToString();
                                    objEN.titulo = dr["VTITULO"].ToString();
                                    objEN.detalle = dr["DESCRIPCION_INFRACCIONES"].ToString();
                                    objEN.gravedad = dr["GRAVEDAD"]?.ToString();
                                    objEN.tipoInfraccion = dr["TIPO_INFRACCION"] != DBNull.Value ? Convert.ToInt32(dr["TIPO_INFRACCION"].ToString()) : default(int?);
                                    objEN.rangoSancion = dr["RANGO_SANCION"]?.ToString();
                                    objEN.flgDesvirtua = Convert.ToBoolean(dr["NFLAGDESVIRTUA"]);
                                    objEN.flgSubsana = Convert.ToBoolean(dr["NFLAGSUBSANA"]);
                                    objEN.parrafos = dr["VPARRAFOS"] != DBNull.Value ? dr["VPARRAFOS"].ToString() : null;
                                    objEN.estado = Convert.ToInt32(dr["NESTADO"]);
                                    objEN.accion = 1;

                                    vm.INFRACCIONES.Add(objEN);
                                }
                            }

                            //ANTECEDENTES
                            dr.NextResult();
                            if (dr.HasRows)
                            {
                                VM_INFORME_LEGAL_DIGITAL_ANTECEDENTE objEN = null;
                                while (dr.Read())
                                {
                                    objEN = new VM_INFORME_LEGAL_DIGITAL_ANTECEDENTE();
                                    objEN.codInformeDigital = dr["VCODINFORMEDIGITAL"].ToString();
                                    objEN.item = Convert.ToInt32(dr["NITEM"]);
                                    objEN.codResolucion = dr["VCODRESOLUCION"].ToString();
                                    objEN.tipoDocumento = dr["VTIPODOCUMENTO"].ToString();
                                    objEN.numero = dr["VNUMERO"].ToString();
                                    objEN.fechaEmision = dr["DFECHAEMISION"] != DBNull.Value ? Convert.ToDateTime(dr["DFECHAEMISION"]).ToShortDateString() : null;
                                    objEN.fechaNotificacion = dr["DFECHANOTIFICACION"] != DBNull.Value ? Convert.ToDateTime(dr["DFECHANOTIFICACION"]).ToShortDateString() : null;
                                    objEN.estado = Convert.ToInt32(dr["NESTADO"]);
                                    objEN.accion = 1;

                                    vm.ANTECEDENTES.Add(objEN);
                                }
                            }
                        }
                    }

                    return vm;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<VM_INFORME_LEGAL_DIGITAL_ANTECEDENTE> ObtenerAntecedentesRSD(string COD_RESOLUCION, string COD_THABILITANTE)
        {
            List<VM_INFORME_LEGAL_DIGITAL_ANTECEDENTE> vm = null;

            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, "DOC_OSINFOR_ERP_MIGRACION.SPFISCALIZACION_INFORME_LEGAL_DIGITAL_ANTECEDENTES", COD_RESOLUCION, COD_THABILITANTE))
                    {
                        if (dr != null)
                        {
                            if (dr.HasRows)
                            {
                                vm = new List<VM_INFORME_LEGAL_DIGITAL_ANTECEDENTE>();

                                VM_INFORME_LEGAL_DIGITAL_ANTECEDENTE objEN = null;

                                while (dr.Read())
                                {
                                    objEN = new VM_INFORME_LEGAL_DIGITAL_ANTECEDENTE();
                                    objEN.tipoDocumento = dr["TIPO_DOCUMENTO"].ToString();
                                    objEN.numero = dr["NUMERO"].ToString();
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

        public VM_TRA_M_TRAMITE_SITD ObtenerExpedienteSITD(string NRO_DOCUMENTO)
        {
            VM_TRA_M_TRAMITE_SITD vm = null;
            try
            {
                //using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena_SITD()))
                {
                    cn.Open();
                    //using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, "DOC_OSINFOR_ERP_MIGRACION.TRA_M_TRAMITE_OBTENER_EXPEDIENTE", NRO_DOCUMENTO))
                    using (SqlDataReader dr = oGDataSQL.SelDrdDefault(cn, "usp_Consultar_Documentos_SITD_Expediente", NRO_DOCUMENTO))
                    {
                        if (dr != null)
                        {
                            if (dr.HasRows)
                            {
                                vm = new VM_TRA_M_TRAMITE_SITD();

                                while (dr.Read())
                                {
                                    vm.iCodTramite = Convert.ToInt32(dr["iCodTramite"].ToString());
                                    vm.cCodificacion = dr["cCodificacion"]?.ToString();
                                    vm.cNroDocumento = dr["cNroDocumento"]?.ToString();
                                    vm.fFecDocumento = dr["fFecDocumento"] != DBNull.Value ? Convert.ToDateTime(dr["fFecDocumento"].ToString()) : default(DateTime?);
                                    vm.cDescTipoDoc = dr["cDescTipoDoc"]?.ToString();
                                    vm.PDF_TRAMITE_SITD = dr["PDF_TRAMITE_SITD"]?.ToString();
                                }
                            }
                        }
                    }
                }

                return vm;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }       

        public void ModificarNumeroInforme(string codInforme, string numeroInforme, DateTime fechaOperacion)
        {
            using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
            {
                cn.Open();
                try
                {
                    object[] param = { codInforme, numeroInforme, fechaOperacion };
                    dBOracle.ManExecute(cn, null, "DOC_OSINFOR_ERP_MIGRACION.SPFISCALIZACION_INFORME_LEGAL_DIGITAL_NUMERO_GUARDAR", param);

                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
        }

        public string Notificar(Informe_Notificacion notificacion)
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
                    using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.SPFISCALIZACION_INFORME_LEGAL_DIGITAL_ENVIARALERTA", notificacion))
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

        public bool ParticipanteActualizar(VM_INFORME_LEGAL_DIGITAL_PARTICIPANTE item)
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
                    int rows = dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.SPFISCALIZACION_INFORME_LEGAL_DIGITAL_PARTICIPANTE_GRABAR", param);
                    //object[] param = { item.codInformeDigital, item.item, item.estado };
                    //int rows = dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.SPFISCALIZACION_INFORME_LEGAL_DIGITAL_PARTICIPANTE_ACTUALIZAR", param);

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

        public bool CambiarEstado(string codInformeDigital, DateTime fechaOperacion, int estado, string codUsuarioOperacion)
        {

            bool success = false;
            using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
            {
                cn.Open();

                try
                {
                    object[] param = { codInformeDigital, fechaOperacion, estado, codUsuarioOperacion };
                    dBOracle.ManExecute(cn, null, "DOC_OSINFOR_ERP_MIGRACION.SPFISCALIZACION_INFORME_LEGAL_DIGITAL_ESTADO_ACTUALIZAR", param);
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
                    dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.SPFISCALIZACION_INFORME_LEGAL_DIGITAL_OPERACION", param);
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

        public List<Ent_INFORME_VOL_ANALIZADO> RegMostrarInfoDocumentResumenSupervisado(string COD_RESOLUCION)
        {
            var result = new List<Ent_INFORME_VOL_ANALIZADO>();
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, "DOC_OSINFOR_ERP_MIGRACION.SPFISCALIZACION_INFORME_LEGAL_DIGITAL_ISUPERVISION_RESUMEN", COD_RESOLUCION))
                    {
                        if (dr != null)
                        {
                            //dr.NextResult();
                            if (dr.HasRows)
                            {
                                Ent_INFORME_VOL_ANALIZADO ovolumen;
                                while (dr.Read())
                                {
                                    ovolumen = new Ent_INFORME_VOL_ANALIZADO();
                                    ovolumen.COD_SECUENCIAL = Int32.Parse(dr["COD_SECUENCIAL"].ToString());
                                    ovolumen.COD_ESPECIES = dr["COD_ESPECIES"].ToString();
                                    ovolumen.ESPECIES = dr["ESPECIES"].ToString();
                                    ovolumen.NUM_ARBOLES = Decimal.Parse(dr["NUM_ARBOLES"].ToString());
                                    ovolumen.BALANCE_EXTRACCION = Decimal.Parse(dr["BALANCE_EXTRACCION"].ToString());
                                    ovolumen.ESTADO_CAMPO = dr["ESTADO_CAMPO"].ToString();
                                    ovolumen.VOLUMEN_APROBADO = Decimal.Parse(dr["VOLUMEN_APROBADO"].ToString());
                                    ovolumen.VOLUMEN_MOVILIZADO = Decimal.Parse(dr["VOLUMEN_MOVILIZADO"].ToString());
                                    ovolumen.VOLUMEN_INJUSTIFICADO = Decimal.Parse(dr["VOLUMEN_INJUSTIFICADO"].ToString());
                                    ovolumen.VOLUMEN_JUSTIFICADO = Decimal.Parse(dr["VOLUMEN_JUSTIFICADO"].ToString());
                                    ovolumen.OBSERVACION = dr["OBSERVACION"].ToString();
                                    ovolumen.RegEstado = 0;
                                    result.Add(ovolumen);
                                }
                            }

                        }
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
