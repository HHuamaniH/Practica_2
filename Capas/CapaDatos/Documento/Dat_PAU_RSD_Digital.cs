using CapaEntidad.DOC;
using CapaEntidad.ViewModel;
using GeneralSQL;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CapaDatos.DOC
{
    public class Dat_PAU_RSD_Digital
    {
        private DBOracle dBOracle;

        public Dat_PAU_RSD_Digital()
        {
            dBOracle = new DBOracle();
        }

        public string RegRSDGrabar(Ent_ResSubDirTabInforme informeDigital, VM_PAU_RSD_DIGITAL otros)
        {
            String OUTPUTPARAM01 = "", codInformeDigital = informeDigital.pVCodInformeDigital;

            OracleTransaction tr = null;
            using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
            {
                cn.Open();
                tr = cn.BeginTransaction();
                try
                {
                    using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.SPFISCALIZACION_RSDTABINFORMEDIGITAL_GRABAR", informeDigital))
                    {
                        cmd.ExecuteNonQuery();
                        OUTPUTPARAM01 = (String)cmd.Parameters["pVOUTPUTPARAM01"].Value;
                        codInformeDigital = OUTPUTPARAM01;


                        if (otros.RECURSOS != null)
                        {
                            foreach (var item in otros.RECURSOS)
                            {
                                object[] param = { codInformeDigital, item.item, item.tipo, item.url, item.nombre, item.estado, item.accion };
                                dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.SPFISCALIZACION_RSDTABINFORMEDIGITAL_RECURSO_GRABAR", param);
                            }
                        }
                        if (otros.FIRMAS != null)
                        {
                            foreach (var item in otros.FIRMAS)
                            {
                                object[] param = { codInformeDigital, item.item, item.codPersona, item.funcion, item.estado, item.accion };
                                dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.SPFISCALIZACION_RSDTABINFORMEDIGITAL_FIRMA_GRABAR", param);
                            }
                        }

                        dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.SPFISCALIZACION_RSDTABINFORMEDIGITAL_ELIMINAR_ITEMS", new object[] { codInformeDigital });

                        if (otros.INFRACCIONES != null)
                        {
                            foreach (var item in otros.INFRACCIONES)
                            {
                                object[] param = { codInformeDigital, item.codInfraccion, item.accion };
                                dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.SPFISCALIZACION_RSDTABINFORMEDIGITAL_INFRACCION_GRABAR", param);
                            }
                        }
                        if (otros.CAUSALES_CADUCIDAD != null)
                        {
                            foreach (var item in otros.CAUSALES_CADUCIDAD)
                            {
                                object[] param = { codInformeDigital, item.codCausalCaducidad, item.accion };
                                dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.SPFISCALIZACION_RSDTABINFORMEDIGITAL_CAUSAL_CADUCIDAD_GRABAR", param);
                            }
                        }

                        if (otros.ELIMINAR != null)
                        {
                            foreach (var item in otros.ELIMINAR)
                            {
                                object[] param = { item.codInformeDigital, item.item, item.origen };
                                dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.SPFISCALIZACION_RSDTABINFORMEDIGITAL_DET_ELIMINAR", param);
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

        public bool RSDFirmaActualizar(VM_RSD_DIGITAL_FIRMA item)
        {
            bool txSuccess = false;
            OracleTransaction tr = null;
            using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
            {
                cn.Open();
                tr = cn.BeginTransaction();

                try
                {
                    object[] param = { item.codInformeDigital, item.item, item.estado };
                    int rows = dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.SPFISCALIZACION_RSDTABINFORMEDIGITAL_FIRMA_ACTUALIZAR", param);

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

        public VM_PAU_RSD_DIGITAL ObtenerRSD(string COD_RESOLUCION)
        {
            VM_PAU_RSD_DIGITAL vm = null;
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, "DOC_OSINFOR_ERP_MIGRACION.SPFISCALIZACION_RSDTABINFORMEDIGITAL_OBTENER", COD_RESOLUCION))
                    {
                        if (dr != null)
                        {
                            //INFORME                   
                            if (dr.HasRows)
                            {
                                vm = new VM_PAU_RSD_DIGITAL();
                                vm.RECURSOS = new List<VM_RSD_DIGITAL_RECURSO>();
                                vm.FIRMAS = new List<VM_RSD_DIGITAL_FIRMA>();
                                vm.INFRACCIONES = new List<VM_RSD_DIGITAL_INFRACCIONES_INFORME>();
                                vm.CAUSALES_CADUCIDAD = new List<VM_RSD_DIGITAL_CAUSALES_CADUCIDAD_INFORME>();

                                while (dr.Read())
                                {
                                    vm.COD_INFORME_DIGITAL = dr["VCodInformeDigital"].ToString();
                                    vm.COD_RES_SUB = dr["VCodResSub"].ToString();
                                    vm.NUM_INFORME_SITD = dr["VNumInformeSITD"].ToString();
                                    if (dr["NTramiteID"] != DBNull.Value) vm.TRAMITE_ID = int.Parse(dr["NTramiteID"].ToString());
                                    vm.COD_PROCEDENCIA = dr["VCodProcedencia"].ToString();
                                    vm.COD_MATERIA = dr["VCodMateria"].ToString();
                                    vm.COD_MODALIDAD = dr["VCodModalidad"].ToString();
                                    vm.NRO_REFERENCIA = dr["VNroReferencia"].ToString();
                                    vm.NUM_POA = dr["NNumPOA"] != DBNull.Value ? Convert.ToInt32(dr["NNumPOA"]) : default(int?);
                                    vm.NOMBRE_POA = dr["nombre_poa"] != DBNull.Value ? dr["nombre_poa"].ToString() : null;
                                    vm.COD_THABILITANTE = dr["VCodTHabilitante"] != DBNull.Value ? dr["VCodTHabilitante"].ToString() : null;
                                    vm.TITULAR_ESTADO_RUC = dr["VRucTitularEstado"] != DBNull.Value ? dr["VRucTitularEstado"].ToString(): null;
                                    vm.TITULAR_CONDICION_RUC = dr["VRucTitularCondicion"] != DBNull.Value ? dr["VRucTitularCondicion"].ToString() : null;
                                    if (dr["NAnioResolucion"] != DBNull.Value) vm.RES_DIRECTORAL_ANIO = Convert.ToInt32(dr["NAnioResolucion"]);
                                    vm.RES_DIRECTORAL_UND_ORGANICA = dr["VCodUndOrganica"] != DBNull.Value ? dr["VCodUndOrganica"].ToString() : null;
                                    if (dr["DFechaResolucion"] != DBNull.Value) vm.RES_DIRECTORAL_FECHA = DateTime.Parse(dr["DFechaResolucion"].ToString());
                                    vm.FLG_CADUCIDAD_EXTRACCION = Convert.ToBoolean(dr["NFlagCaducidadExtraccion"]);
                                    vm.FLG_COMUNICACION = Convert.ToBoolean(dr["NFlagComunicacion"]);
                                    vm.FLG_HERRAMIENTAS_SUBSANAR = Convert.ToBoolean(dr["NFlagHerramientasSubsanar"]);
                                    vm.FLG_IMPUTACION_CARGOS = Convert.ToBoolean(dr["NFlagImputacionCargos"]);
                                    vm.FLG_MEDIDAS_CAUTELARES = Convert.ToBoolean(dr["NFlagMedidasCautelares"]);

                                    if (dr["VRutaArchivoRevision"] != DBNull.Value) vm.RUTA_ARCHIVO_REVISION = dr["VRutaArchivoRevision"].ToString();
                                    //vm.COD_USUARIO_OPERACION = dr["VCodUsuarioCreacion"].ToString();
                                    if (dr["DFechaCreacion"] != DBNull.Value) vm.FECHA_REGISTRO = DateTime.Parse(dr["DFechaCreacion"].ToString());
                                    vm.ESTADO = (dr["NEstado"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["NEstado"]);
                                }
                            }

                            //FIRMAS
                            dr.NextResult();
                            if (dr.HasRows)
                            {
                                VM_RSD_DIGITAL_FIRMA objEN = null;
                                while (dr.Read())
                                {
                                    objEN = new VM_RSD_DIGITAL_FIRMA();
                                    objEN.codInformeDigital = dr["VCodInformeDigital"].ToString();
                                    objEN.item = Convert.ToInt32(dr["NItem"]);
                                    objEN.codPersona = dr["VCodPersona"].ToString();
                                    objEN.apellidosNombres = dr["VApellidosNombres"].ToString();
                                    objEN.numeroDocumento = dr["VNDocumento"].ToString();
                                    objEN.funcion = dr["VFuncion"].ToString();
                                    if (dr["NEstado"] != DBNull.Value) objEN.estado = Convert.ToInt32(dr["NEstado"]);
                                    objEN.accion = 1;
                                    vm.FIRMAS.Add(objEN);
                                }
                            }

                            //RECURSOS
                            dr.NextResult();
                            if (dr.HasRows)
                            {
                                VM_RSD_DIGITAL_RECURSO objEN = null;
                                while (dr.Read())
                                {
                                    objEN = new VM_RSD_DIGITAL_RECURSO();
                                    objEN.codInformeDigital = dr["VCodInformeDigital"].ToString();
                                    objEN.item = Convert.ToInt32(dr["NItem"]);
                                    objEN.tipo = dr["VTipo"].ToString();
                                    objEN.url = dr["VUrl"].ToString();
                                    objEN.nombre = dr["VNombre"].ToString();
                                    objEN.estado = Convert.ToInt32(dr["NEstado"]);
                                    objEN.accion = 1;
                                    vm.RECURSOS.Add(objEN);
                                }
                            }

                            //INFRACCIONES
                            dr.NextResult();
                            if (dr.HasRows)
                            {
                                VM_RSD_DIGITAL_INFRACCIONES_INFORME objEN = null;
                                while (dr.Read())
                                {
                                    objEN = new VM_RSD_DIGITAL_INFRACCIONES_INFORME();
                                    objEN.codInformeDigital = dr["VCodInformeDigital"].ToString();
                                    objEN.codInfraccion = Convert.ToInt32(dr["NCodInfraccion"]);
                                    vm.INFRACCIONES.Add(objEN);
                                }
                            }

                            //CAUSALES DE CADUCIDAD
                            dr.NextResult();
                            if (dr.HasRows)
                            {
                                VM_RSD_DIGITAL_CAUSALES_CADUCIDAD_INFORME objEN = null;
                                while (dr.Read())
                                {
                                    objEN = new VM_RSD_DIGITAL_CAUSALES_CADUCIDAD_INFORME();
                                    objEN.codInformeDigital = dr["VCodInformeDigital"].ToString();
                                    objEN.codCausalCaducidad = Convert.ToInt32(dr["NCodCausalCaducidad"]);
                                    vm.CAUSALES_CADUCIDAD.Add(objEN);
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

        public List<VM_RSD_DIGITAL_INFRACCIONES> ListarInfracciones()
        {
            try
            {
                List<VM_RSD_DIGITAL_INFRACCIONES> result = new List<VM_RSD_DIGITAL_INFRACCIONES>();

                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();

                    using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, "DOC_OSINFOR_ERP_MIGRACION.SPFISCALIZACION_RSDTABINFORMEDIGITAL_INFRACCIONES_OBTENER"))
                    {
                        if (dr != null)
                        {
                            //INFORME
                            if (dr.HasRows)
                            {
                                VM_RSD_DIGITAL_INFRACCIONES objEN = null;
                                while (dr.Read())
                                {
                                    objEN = new VM_RSD_DIGITAL_INFRACCIONES();
                                    objEN.codInfraccion = Convert.ToInt32(dr["NCodInfraccion"]);
                                    objEN.codModalidad = dr["VCodModalidad"].ToString();
                                    objEN.titulo = dr["VTitulo"].ToString();
                                    objEN.conducta = dr["VConducta"].ToString();
                                    objEN.tipoInfractor = dr["VTipoInfractor"].ToString();
                                    objEN.numeral = dr["VNumeral"].ToString();
                                    objEN.sancion = dr["VSancion"].ToString();
                                    objEN.subsanar = dr["VSubsanar"].ToString();
                                    objEN.codPlantilla = dr["VCodPlantilla"].ToString();

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

        public List<VM_RSD_DIGITAL_CAUSALES_CADUCIDAD> ListarCausalesCaducidad()
        {
            try
            {
                List<VM_RSD_DIGITAL_CAUSALES_CADUCIDAD> result = new List<VM_RSD_DIGITAL_CAUSALES_CADUCIDAD>();

                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();

                    using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, "DOC_OSINFOR_ERP_MIGRACION.SPFISCALIZACION_RSDTABINFORMEDIGITAL_CAUSALES_CADUCIDAD_OBTENER"))
                    {
                        if (dr != null)
                        {
                            //INFORME
                            if (dr.HasRows)
                            {
                                VM_RSD_DIGITAL_CAUSALES_CADUCIDAD objEN = null;
                                while (dr.Read())
                                {
                                    objEN = new VM_RSD_DIGITAL_CAUSALES_CADUCIDAD();
                                    objEN.codCausalCaducidad = Convert.ToInt32(dr["NCODCAUSALCADUCIDAD"]);
                                    objEN.titulo = dr["VTITULO"].ToString();

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

        public List<VM_RSD_PLAN_MANEJO> ListarPlanesManejo(string COD_INFORME, string COD_THABILITANTE, int? NUM_POA, string V_OPCION)
        {
            try
            {
                List<VM_RSD_PLAN_MANEJO> result = new List<VM_RSD_PLAN_MANEJO>();

                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();

                    using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, "DOC_OSINFOR_ERP_MIGRACION.SPFISCALIZACION_RSDTABINFORMEDIGITAL_PLANES_MANEJO", COD_INFORME, COD_THABILITANTE, NUM_POA, V_OPCION))
                    {
                        if (dr != null)
                        {
                            //INFORME
                            if (dr.HasRows)
                            {
                                VM_RSD_PLAN_MANEJO objEN = null;
                                while (dr.Read())
                                {
                                    objEN = new VM_RSD_PLAN_MANEJO();
                                    objEN.COD_INFORME = dr["COD_INFORME"].ToString();
                                    objEN.INICIO_SUPERVISION = dr["INICIO_SUPERVISION"] != DBNull.Value ? DateTime.Parse(dr["INICIO_SUPERVISION"].ToString()).ToShortDateString() : null;
                                    objEN.NUM_POA = dr["NUM_POA"].ToString();
                                    objEN.NOMBRE_POA = dr["NOMBRE_POA"].ToString();
                                    objEN.ARESOLUCION_NUM = dr["ARESOLUCION_NUM"] != DBNull.Value ? dr["ARESOLUCION_NUM"].ToString() : null;
                                    objEN.ARESOLUCION_FECHA = dr["ARESOLUCION_FECHA"] != DBNull.Value ? DateTime.Parse(dr["ARESOLUCION_FECHA"].ToString()).ToShortDateString() : null;
                                    objEN.INICIO_VIGENCIA = dr["INICIO_VIGENCIA"] != DBNull.Value ? DateTime.Parse(dr["INICIO_VIGENCIA"].ToString()).ToShortDateString() : null;
                                    objEN.FIN_VIGENCIA = dr["FIN_VIGENCIA"] != DBNull.Value ? DateTime.Parse(dr["FIN_VIGENCIA"].ToString()).ToShortDateString() : null;

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
                    dBOracle.ManExecute(cn, null, "DOC_OSINFOR_ERP_MIGRACION.SPFISCALIZACION_RSDTABINFORMEDIGITAL_INFORME_NUMERO_GUARDAR", param);

                }
                catch (Exception ex)
                {

                    throw ex;
                }

            }
        }

        public List<VM_Informe_Supervision> ObtenerRSDCabeceraByReferencia(string NUM_REFERENCIA, int TIPO = 1)
        {
            List<VM_Informe_Supervision> vm = null;

            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, "DOC_OSINFOR_ERP_MIGRACION.SPFISCALIZACION_RSDTABINFORMEDIGITAL_INFORME_SUPERVISION", NUM_REFERENCIA, TIPO))
                    {
                        if (dr != null)
                        {
                            if (dr.HasRows)
                            {
                                vm = new List<VM_Informe_Supervision>();
                                VM_Informe_Supervision objEN;

                                while (dr.Read())
                                {
                                    objEN = new VM_Informe_Supervision();
                                    objEN.COD_INFORME = dr["COD_INFORME"].ToString();
                                    objEN.TITULAR_SUPERVISADO = dr["TITULAR_SUPERVISADO"].ToString();
                                    objEN.TIPO_INFORME = dr["TIPO_INFORME"].ToString();
                                    objEN.COD_MTIPO = dr["COD_MTIPO"].ToString();
                                    objEN.MODALIDAD_TIPO = dr["MODALIDAD_TIPO"].ToString();
                                    objEN.DOCUMENTO_TITULAR = dr["DOCUMENTO_TITULAR"].ToString();
                                    objEN.REPRESENTANTE_LEGAL = dr["REPRESENTANTE_LEGAL"].ToString();
                                    objEN.RUC_TITULAR = dr["RUC_TITULAR"].ToString();
                                    objEN.NUM_INFORME = dr["NUM_INFORME"].ToString();
                                    if (dr["INF_FECHA"] != null) objEN.INF_FECHA = DateTime.Parse(dr["INF_FECHA"].ToString());                                  
                                    objEN.ASUNTO = dr["ASUNTO"].ToString();
                                    objEN.COD_THABILITANTE = dr["COD_THABILITANTE"].ToString();
                                    objEN.NUM_THABILITANTE = dr["NUM_THABILITANTE"].ToString();
                                    objEN.THABILITANTE_SECTOR = dr["THABILITANTE_SECTOR"].ToString();
                                    objEN.UBIGEO_THABILITANTE = dr["UBIGEO_THABILITANTE"].ToString();
                                    vm.Add(objEN);
                                }

                                //DOCUMENTOS
                                dr.NextResult();

                                if (dr.HasRows)
                                {
                                    var documentos = new List<VM_Informe_Supervision_Documentos>();
                                    VM_Informe_Supervision_Documentos oCamposDet;

                                    while (dr.Read())
                                    {
                                        oCamposDet = new VM_Informe_Supervision_Documentos();
                                        oCamposDet.COD_INFORME = dr["COD_INFORME"].ToString();
                                        oCamposDet.DETINV_CODDOC = dr["DETINV_CODDOC"].ToString();
                                        oCamposDet.DETINV_DESCRIPCION = dr["DETINV_DESCRIPCION"].ToString();
                                        oCamposDet.ORIGEN = dr["ORIGEN"].ToString();
                                        documentos.Add(oCamposDet);
                                    }

                                    //Asignamos a cada informe
                                    if (documentos.Count > 0)
                                    {
                                        foreach (var item in vm)
                                        {
                                            item.DOCUMENTOS.AddRange(documentos.Where(x => x.COD_INFORME == item.COD_INFORME).ToList());
                                        }
                                    }

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

        public bool CambiarEstado(string codInformeDigital, DateTime fechaOperacion, int estado, string codUsuarioOperacion)
        {

            bool success = false;
            using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
            {
                cn.Open();

                try
                {
                    object[] param = { codInformeDigital, fechaOperacion, estado, codUsuarioOperacion };
                    dBOracle.ManExecute(cn, null, "DOC_OSINFOR_ERP_MIGRACION.SPFISCALIZACION_RSDTABINFORMEDIGITAL_ESTADO_ACTUALIZAR", param);
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
                    object[] param = { codInforme, "ANULAR_FIRMA_POR_INFORME", "" }; //SPFISCALIZACION_RSDTABINFORMEDIGITAL
                    dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.SPFISCALIZACION_RSDTABINFORMEDIGITAL_OPERACION", param);
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
    }
}
