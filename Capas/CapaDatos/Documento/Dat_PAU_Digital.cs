using CapaEntidad.DOC;
using CapaEntidad.ViewModel;
using GeneralSQL;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.DOC
{
    public class Dat_PAU_Digital
    {
        private DBOracle dBOracle;

        public Dat_PAU_Digital()
        {
            dBOracle = new DBOracle();
        }

        public string RegRSDGrabar(Ent_ResSubDirTabInforme informeDigital, VM_RSD_DIGITAL otros)
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

        public VM_RSD_DIGITAL ObtenerRSD(string COD_RESOLUCION)
        {
            VM_RSD_DIGITAL vm = null;
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
                                vm = new VM_RSD_DIGITAL();
                                vm.RECURSOS = new List<VM_RSD_DIGITAL_RECURSO>();
                                vm.FIRMAS = new List<VM_RSD_DIGITAL_FIRMA>();

                                while (dr.Read())
                                {
                                    vm.COD_INFORME_DIGITAL = dr["VCodInformeDigital"].ToString();
                                    vm.COD_RES_SUB = dr["VCodResSub"].ToString();
                                    vm.NUM_INFORME_SITD = dr["VNumInformeSITD"].ToString();
                                    if (dr["NTramiteID"] != DBNull.Value) vm.TRAMITE_ID = int.Parse(dr["NTramiteID"].ToString());
                                    vm.COD_PROCEDENCIA = dr["VCodProcedencia"].ToString();
                                    vm.COD_MATERIA = dr["VCodMateria"].ToString();
                                    vm.NRO_REFERENCIA = dr["VNroReferencia"].ToString();
                                    vm.COD_TITULAR = dr["VCodTitular"].ToString();
                                    vm.TITULAR_ESTADO_RUC = dr["VRucTitularEstado"].ToString();
                                    vm.TITULAR_CONDICION_RUC = dr["VRucTitularCondicion"].ToString();
                                    if (dr["NAnioResolucion"] != DBNull.Value) vm.RES_DIRECTORAL_ANIO = Convert.ToInt32(dr["NAnioResolucion"]);
                                    vm.RES_DIRECTORAL_UND_ORGANICA = dr["VCodUndOrganica"].ToString();
                                    if (dr["DFechaResolucion"] != DBNull.Value) vm.RES_DIRECTORAL_FECHA = DateTime.Parse(dr["DFechaResolucion"].ToString());
                                    vm.VISTOS = dr["VVistos"].ToString();
                                    vm.ANTECEDENTES = dr["VAntecedentes"].ToString();
                                    vm.COMPETENCIA = dr["VCompetencia"].ToString();
                                    vm.ANALISIS = dr["VAnalisis"].ToString();
                                    vm.IMPUTACION = dr["VImputacion"].ToString();
                                    vm.COMUNICACION_EXTERNA = dr["VComunicacionExterna"].ToString();
                                    vm.PARRAFOS_CLICHE = dr["VParrafosCliche"].ToString();
                                    vm.PIE_PAGINA = dr["VPiePagina"].ToString();
                                    vm.RESOLUCION = dr["VResolucion"].ToString();
                                    if (dr["VRutaArchivoRevision"] != DBNull.Value) vm.RUTA_ARCHIVO_REVISION = dr["VRutaArchivoRevision"].ToString();
                                    //vm.COD_USUARIO_OPERACION = dr["VCodUsuarioCreacion"].ToString();
                                    if (dr["DFechaCreacion"] != DBNull.Value) vm.FECHA_REGISTRO = DateTime.Parse(dr["DFechaCreacion"].ToString());
                                    vm.ESTADO = dr["NEstado"] == DBNull.Value ? 0 : Convert.ToInt32(dr["NEstado"]);
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

        public string NotificarRSD(RSD_Notificacion notificacion)
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
                    using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.SPFISCALIZACION_RSDTABINFORMEDIGITAL_ENVIARALERTA", notificacion))
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

        /*public VM_RSD_CABECERA ObtenerRSDCabecera(string COD_RESOLUCION)
        {
            VM_RSD_CABECERA vm = null;

            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, "DOC_OSINFOR_ERP_MIGRACION.SPFISCALIZACION_RSDTABINFORMEDIGITAL_CABECERA", COD_RESOLUCION))
                    {
                        if (dr != null)
                        {

                            if (dr.HasRows)
                            {
                                vm = new VM_RSD_CABECERA();

                                while (dr.Read())
                                {
                                    vm.COD_INFORME = dr["COD_INFORME"].ToString();
                                    vm.TITULAR_SUPERVISADO = dr["TITULAR_SUPERVISADO"].ToString();
                                    vm.DOCUMENTO_TITULAR = dr["DOCUMENTO_TITULAR"].ToString();
                                    vm.REPRESENTANTE_LEGAL = dr["REPRESENTANTE_LEGAL"].ToString();
                                    vm.RUC_TITULAR = dr["RUC_TITULAR"].ToString();
                                    //vm.NUM_INFORME = dr["NUM_INFORME"].ToString();
                                    //if(dr["INF_FECHA"] != null) vm.INF_FECHA = DateTime.Parse(dr["INF_FECHA"].ToString());
                                    //vm.INF_ANTECEDENTES = dr["INF_ANTECEDENTES"].ToString();
                                    vm.ASUNTO = dr["ASUNTO"].ToString();
                                    vm.COD_THABILITANTE = dr["COD_THABILITANTE"].ToString();
                                    vm.NUM_THABILITANTE = dr["NUM_THABILITANTE"].ToString();
                                    vm.THABILITANTE_SECTOR = dr["THABILITANTE_SECTOR"].ToString();
                                    vm.UBIGEO_THABILITANTE = dr["UBIGEO_THABILITANTE"].ToString();
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
        }*/

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
                                    objEN.INF_ANTECEDENTES = dr["INF_ANTECEDENTES"].ToString();
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
