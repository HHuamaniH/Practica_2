using CapaEntidad.DOC;
using GeneralSQL;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using CEntidad = CapaEntidad.DOC.Ent_InfQuinquenal;
using SQL = GeneralSQL.Data.SQL;

namespace CapaDatos.DOC
{
    public class Dat_InformeQuinquenal
    {
        private SQL oGDataSQL = new SQL();
        private DBOracle dBOracle = new DBOracle();
        public List<Dictionary<string, string>> GetAll(string criterio, string valorBusqueda, int currentPage, int pageSize, string sort, ref int rowCount)
        {
            List<Dictionary<string, string>> lstResult = new List<Dictionary<string, string>>();
            rowCount = 0;

            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, "DOC_OSINFOR_ERP_MIGRACION.USP_INFORME_QUINQUENAL_LISTAR", criterio, valorBusqueda, currentPage, pageSize, sort))
                    {
                        if (dr != null)
                        {
                            if (dr.HasRows)
                            {
                                Dictionary<string, string> sFila;
                                string sColumn = "";

                                while (dr.Read())
                                {
                                    sFila = new Dictionary<string, string>();
                                    for (int i = 0; i < dr.FieldCount; i++)
                                    {
                                        sColumn = dr.GetName(i);
                                        sFila.Add(sColumn, dr[sColumn].ToString().Trim());
                                    }
                                    lstResult.Add(sFila);
                                }

                                dr.NextResult();
                                if (dr.HasRows)
                                {
                                    if (dr.Read())
                                    {
                                        rowCount = Convert.ToInt32(dr["rowcount"].ToString());
                                    }
                                }
                            }
                        }
                    }
                }
                return lstResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /*
        public List<Ent_BUSQUEDA> GetAll(string criterio, string valorBusqueda, int currentPage, int pageSize, string sort, ref int rowCount)
        {
            List<Ent_BUSQUEDA> result = new List<Ent_BUSQUEDA>();
            Ent_BUSQUEDA vm;
            rowCount = 0;
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, "DOC_OSINFOR_ERP_MIGRACION.USP_INFORME_QUINQUENAL_LISTAR", criterio, valorBusqueda, currentPage, pageSize, sort))
                    {
                        if (dr != null)
                        {

                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    vm = new Ent_BUSQUEDA();
                                    vm.CODIGO = dr["COD_INFORME"].ToString();
                                    vm.NUMERO = dr["NUM_INFORME"].ToString();
                                    vm.PARAMETRO01 = dr["FECHA_CREACION"].ToString();
                                    vm.PARAMETRO02 = dr["TIPO"].ToString();
                                    vm.PARAMETRO03 = dr["RD_QUINQUENAL"].ToString();
                                    vm.PARAMETRO04 = dr["NUM_THABILITANTE"].ToString();
                                    vm.PARAMETRO05 = dr["TITULAR"].ToString();
                                    result.Add(vm);
                                }
                                dr.NextResult();
                                if (dr.HasRows)
                                {
                                    if (dr.Read())
                                    {
                                        rowCount = Convert.ToInt32(dr["rowcount"].ToString());
                                    }
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
        }*/
        public String RegGrabarQuinquenio(OracleConnection cn, CEntidad oCEntidad)
        {
            OracleTransaction tr = null;
            String OUTPUTPARAM01 = "";
            CEntidad oCamposDet;

            try
            {
                tr = cn.BeginTransaction(); 
     
                
                if (oCEntidad.ListVerificadores != null)
                {
                    foreach (var loDatos in oCEntidad.ListVerificadores)
                    {
                        oCamposDet = new CEntidad();
                        oCamposDet.COD_INFORME = oCEntidad.COD_INFORME;
                        oCamposDet.CODIGO = loDatos.CODIGO;
                        oCamposDet.VERIFICADOR = loDatos.VERIFICADOR;
                        oCamposDet.OBSERVACION = loDatos.OBSERVACION;
                        oCamposDet.QUINQUENIO = loDatos.QUINQUENIO;
                        oCamposDet.VALUE_VERIFICADOR = loDatos.VALUE_VERIFICADOR;
                        dBOracle.ManExecute(cn, tr, "doc_osinfor_erp_migracion.spINFORME_QUINQUENAL_VERIFICADOR_GRABAR", oCamposDet);
                    }
                }
                if (oCEntidad.ListConclusiones != null)
                {
                    Ent_IQUINQUENAL_DET_CONCLUSION entConclusion;

                    foreach (var item in oCEntidad.ListConclusiones)
                    {
                        entConclusion = new Ent_IQUINQUENAL_DET_CONCLUSION();
                        entConclusion.COD_INFORME = oCEntidad.COD_INFORME;
                        entConclusion.QUINQUENIO = item.QUINQUENIO;
                        entConclusion.CRITERIO_EVALUACION = item.CRITERIO_EVALUACION;
                        entConclusion.ACLARACION_TITULAR = item.ACLARACION_TITULAR;
                        entConclusion.IMPL_PMANEJO = item.IMPL_PMANEJO;
                        entConclusion.CUMPL_OBLIGACION = item.CUMPL_OBLIGACION;
                        entConclusion.CALIDAD_IMPL = item.CALIDAD_IMPL;
                        entConclusion.OPINION_FAVORABLE = item.OPINION_FAVORABLE;
                        entConclusion.DEMORA_NEGLIGENCIA = item.DEMORA_NEGLIGENCIA;
                        entConclusion.ADVERTENCIA_CAUSAL = item.ADVERTENCIA_CAUSAL;
                        entConclusion.AUDITORIA_OK = item.AUDITORIA_OK;
                        entConclusion.AMPLIAR_CONTRATO = item.AMPLIAR_CONTRATO;
                        entConclusion.COD_UCUENTA = oCEntidad.COD_UCUENTA;
                        dBOracle.ManExecute(cn, tr, "doc_osinfor_erp_migracion.spIQUINQUENAL_DET_CONCLUSION_Grabar", entConclusion);
                    }
                }
                tr.Commit();
                return OUTPUTPARAM01;
            }
            catch (Exception ex)
            {
                if (tr != null)
                {
                    tr.Rollback();
                }
                throw ex;
            }

        }
        public String RegGrabarInfQuinv1(OracleConnection cn, CEntidad oCEntidad)
        {
            OracleTransaction tr = null;
            String OUTPUTPARAM01 = "";
            CEntidad oCamposDet;

            try
            {
                tr = cn.BeginTransaction();
                //Grabando Cabecera
                using (OracleCommand cmd =dBOracle.ManExecuteOutput(cn, tr, "doc_osinfor_erp_migracion.spInformeQuinquenalGrabar", oCEntidad))
                {
                    cmd.ExecuteNonQuery();
                    OUTPUTPARAM01 = (String)cmd.Parameters["OUTPUTPARAM01"].Value;
                    if (OUTPUTPARAM01 == "100")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("El registro se encuentra con Control de Calidad Conforme, No se puede modificar el registro");
                    }
                    else if (OUTPUTPARAM01 == "99")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("Ud. no tiene permiso para realizar esta acción");
                    }
                    if (OUTPUTPARAM01 == "0")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("El Número del Informe ya existe");
                    }
                    else if (OUTPUTPARAM01 == "1")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("El Número de Informe Existe en otro Registro");
                    }
                    else if (OUTPUTPARAM01 == "2")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("No Tiene Permisos para Modificar este Informe");
                    }
                }

                if (oCEntidad.RegEstado == 1) //Nuevo
                {
                    oCEntidad.COD_RESODIREC = OUTPUTPARAM01;
                }
                
                //Eliminando Detalle
                if (oCEntidad.ListEliTABLA != null)
                {
                    foreach (var loDatos in oCEntidad.ListEliTABLA)
                    {
                        oCamposDet = new CEntidad();
                        oCamposDet.EliTABLA = loDatos.EliTABLA;
                        oCamposDet.CODIGO = OUTPUTPARAM01;
                        oCamposDet.EliVALOR01 = loDatos.EliVALOR01;
                        oCamposDet.EliVALOR02 = loDatos.EliVALOR02;
                        oCamposDet.NUM_POA = loDatos.NUM_POA;
                        dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spINFQuinquenalEliminarDetalle", oCamposDet);
                    }
                }
                if (oCEntidad.ListProfesionales != null)
                {
                    foreach (var loDatos in oCEntidad.ListProfesionales)
                    {
                        oCamposDet = new CEntidad();
                        oCamposDet.COD_INFORME = OUTPUTPARAM01;
                        oCamposDet.COD_PROFESIONAL = loDatos.COD_PERSONA;
                        oCamposDet.BusFormulario = "PROFESIONAL";
                        if (loDatos.RegEstado == 1)
                        {
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spInformeQuinquenal_General", oCamposDet);
                        }
                    }
                }
                if (oCEntidad.ListRDQuinquenal != null)
                {
                    foreach (var loDatos in oCEntidad.ListRDQuinquenal)
                    {
                        oCamposDet = new CEntidad();
                        oCamposDet.COD_INFORME = OUTPUTPARAM01;
                        oCamposDet.COD_RESODIREC = loDatos.COD_RESODIREC;
                        oCamposDet.BusFormulario = loDatos.COD_FCTIPO == "0000100" ? "RDQuinquenal" : "CNQuinquenal";
                        if (loDatos.RegEstado == 1)
                        {
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spInformeQuinquenal_General", oCamposDet);
                        }
                    }
                }
                if (oCEntidad.ListHallazgos != null)
                {
                    foreach (var loDatos in oCEntidad.ListHallazgos)
                    {
                        oCamposDet = new CEntidad();
                        oCamposDet.COD_INFORME = OUTPUTPARAM01;
                        oCamposDet.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                        oCamposDet.HALLAZGO = loDatos.HALLAZGO;
                        oCamposDet.COD_UCUENTA = oCEntidad.COD_UCUENTA;
                        if (loDatos.RegEstado == 1)
                        {
                            dBOracle.ManExecute(cn, tr, "doc_osinfor_erp_migracion.spIQUINQUENAL_DET_HALLAZGO_Grabar", oCamposDet);
                        }
                    }
                }
                /*
                if (oCEntidad.ListVerificadores != null)
                {
                    foreach (var loDatos in oCEntidad.ListVerificadores)
                    {
                        oCamposDet = new CEntidad();
                        oCamposDet.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                        oCamposDet.CODIGO = loDatos.CODIGO;
                        oCamposDet.VERIFICADOR = loDatos.VERIFICADOR;
                        oCamposDet.OBSERVACION = loDatos.OBSERVACION;
                        oCamposDet.QUINQUENIO = loDatos.QUINQUENIO;
                        oCamposDet.VALUE_VERIFICADOR = loDatos.VALUE_VERIFICADOR;
                        oGDataSQL.ManExecute(cn, tr, "DOC.spINFORME_QUINQUENAL_VERIFICADOR_GRABAR", oCamposDet);
                    }
                }
                if (oCEntidad.ListConclusiones != null)
                {
                    Ent_IQUINQUENAL_DET_CONCLUSION entConclusion;

                    foreach (var item in oCEntidad.ListConclusiones)
                    {
                        entConclusion = new Ent_IQUINQUENAL_DET_CONCLUSION();
                        entConclusion.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                        entConclusion.QUINQUENIO = item.QUINQUENIO;
                        entConclusion.CRITERIO_EVALUACION = item.CRITERIO_EVALUACION;
                        entConclusion.ACLARACION_TITULAR = item.ACLARACION_TITULAR;
                        entConclusion.IMPL_PMANEJO = item.IMPL_PMANEJO;
                        entConclusion.CUMPL_OBLIGACION = item.CUMPL_OBLIGACION;
                        entConclusion.CALIDAD_IMPL = item.CALIDAD_IMPL;
                        entConclusion.OPINION_FAVORABLE = item.OPINION_FAVORABLE;
                        entConclusion.DEMORA_NEGLIGENCIA = item.DEMORA_NEGLIGENCIA;
                        entConclusion.ADVERTENCIA_CAUSAL = item.ADVERTENCIA_CAUSAL;
                        entConclusion.AUDITORIA_OK = item.AUDITORIA_OK;
                        entConclusion.AMPLIAR_CONTRATO = item.AMPLIAR_CONTRATO;
                        entConclusion.COD_UCUENTA = oCEntidad.COD_UCUENTA;
                        oGDataSQL.ManExecute(cn, tr, "DOC.spIQUINQUENAL_DET_CONCLUSION_Grabar", entConclusion);
                    }
                }*/
                tr.Commit();
                return OUTPUTPARAM01;
            }
            catch (Exception ex)
            {
                if (tr != null)
                {
                    tr.Rollback();
                }
                throw ex;
            }

        }
        /// <summary>
        /// metodo para guardar informe quinquenal
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public String RegGrabarInfQuin(OracleConnection cn, CEntidad oCEntidad)
        {
            OracleTransaction tr = null;
            String OUTPUTPARAM01 = "";
            CEntidad oCamposDet;

            try
            {
                tr = cn.BeginTransaction();
                //Grabando Cabecera
                using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spInformeQuinquenalGrabar", oCEntidad))
                {
                    cmd.ExecuteNonQuery();
                    OUTPUTPARAM01 = (String)cmd.Parameters["@OUTPUTPARAM01"].Value;
                    if (OUTPUTPARAM01 == "100")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("El registro se encuentra con Control de Calidad Conforme, No se puede modificar el registro");
                    }
                    else if (OUTPUTPARAM01 == "99")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("Ud. no tiene permiso para realizar esta acción");
                    }
                    if (OUTPUTPARAM01 == "0")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("El Número del Informe ya existe");
                    }
                    else if (OUTPUTPARAM01 == "1")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("El Número de Informe Existe en otro Registro");
                    }
                    else if (OUTPUTPARAM01 == "2")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("No Tiene Permisos para Modificar este Informe");
                    }
                }
                //Reemplazando El Nuevo Codigo Creado
                //String[] cadena = OUTPUTPARAM02.Split('|');
                if (oCEntidad.RegEstado == 1) //Nuevo
                {
                    oCEntidad.COD_RESODIREC = OUTPUTPARAM01;
                }
                //
                //Eliminando Detalle
                if (oCEntidad.ListEliTABLA != null)
                {
                    foreach (var loDatos in oCEntidad.ListEliTABLA)
                    {
                        oCamposDet = new CEntidad();
                        oCamposDet.EliTABLA = loDatos.EliTABLA;
                        oCamposDet.CODIGO = OUTPUTPARAM01;
                        oCamposDet.EliVALOR01 = loDatos.EliVALOR01;
                        oCamposDet.EliVALOR02 = loDatos.EliVALOR02;
                        oCamposDet.NUM_POA = loDatos.NUM_POA;
                        dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spINFQuinquenalEliminarDetalle", oCamposDet);
                    }
                }
                if (oCEntidad.ListProfesionales != null)
                {
                    foreach (var loDatos in oCEntidad.ListProfesionales)
                    {
                        oCamposDet = new CEntidad();
                        oCamposDet.COD_INFORME = OUTPUTPARAM01;
                        oCamposDet.COD_PROFESIONAL = loDatos.COD_PERSONA;
                        oCamposDet.BusFormulario = "PROFESIONAL";
                        if (loDatos.RegEstado == 1)
                        {
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spInformeQuinquenal_General", oCamposDet);
                        }
                    }
                }
                if (oCEntidad.ListRDQuinquenal != null)
                {
                    foreach (var loDatos in oCEntidad.ListRDQuinquenal)
                    {
                        oCamposDet = new CEntidad();
                        oCamposDet.COD_INFORME = OUTPUTPARAM01;
                        oCamposDet.COD_RESODIREC = loDatos.COD_RESODIREC;
                        oCamposDet.BusFormulario = loDatos.COD_FCTIPO == "0000100" ? "RDQuinquenal" : "CNQuinquenal";
                        if (loDatos.RegEstado == 1)
                        {
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spInformeQuinquenal_General", oCamposDet);
                        }
                    }
                }
                if (oCEntidad.ListParticipantes != null)
                {
                    foreach (var loDatos in oCEntidad.ListParticipantes)
                    {
                        oCamposDet = new CEntidad();
                        oCamposDet.COD_INFORME = OUTPUTPARAM01;
                        oCamposDet.COD_PERSONA = loDatos.COD_PERSONA;
                        oCamposDet.APELLIDOS_NOMBRE = loDatos.APELLIDOS_NOMBRE;
                        oCamposDet.CARGO = loDatos.CARGO;
                        oCamposDet.DNI = loDatos.DNI;
                        oCamposDet.ENTIDAD = loDatos.ENTIDAD;
                        oCamposDet.RegEstado = loDatos.RegEstado;
                        oCamposDet.BusFormulario = "PARTICIPANTES";
                        dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spInformeQuinquenal_General", oCamposDet);

                    }
                }
                if (oCEntidad.ListInfraestructura != null)
                {
                    foreach (var loDatos in oCEntidad.ListInfraestructura)
                    {
                        oCamposDet = new CEntidad();
                        oCamposDet.COD_INFORME = OUTPUTPARAM01;
                        oCamposDet.COD_INFRAESTRUCTURA = loDatos.COD_INFRAESTRUCTURA;
                        oCamposDet.Este = loDatos.Este;
                        oCamposDet.Norte = loDatos.Norte;
                        oCamposDet.PCA = loDatos.PCA;
                        oCamposDet.Infraestructura = loDatos.Infraestructura;
                        oCamposDet.POAPendiente = loDatos.POAPendiente;
                        oCamposDet.CampoPendiente = loDatos.CampoPendiente;
                        oCamposDet.ObservacionPendiente = loDatos.ObservacionPendiente;
                        oCamposDet.POACalzada = loDatos.POACalzada;
                        oCamposDet.CampoCalzada = loDatos.CampoCalzada;
                        oCamposDet.Observacioncalzada = loDatos.Observacioncalzada;
                        oCamposDet.RegEstado = loDatos.RegEstado;
                        oCamposDet.BusFormulario = "INFRAESTRUCTURA";
                        dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spInformeQuinquenal_General", oCamposDet);
                    }
                }
                if (oCEntidad.ListISupervInfoDocument != null)
                {
                    foreach (var loDatos in oCEntidad.ListISupervInfoDocument)
                    {
                        oCamposDet = new CEntidad();
                        oCamposDet.COD_INFORME = OUTPUTPARAM01;
                        oCamposDet.COD_INFO_DOCUMENTARIO = loDatos.COD_INFO_DOCUMENTARIO;
                        oCamposDet.NUM_POA = loDatos.NUM_POA;
                        oCamposDet.LINDERAMIENTO_AREA = loDatos.LINDERAMIENTO_AREA;
                        oCamposDet.AREA_DEMARCACION = loDatos.AREA_DEMARCACION;
                        oCamposDet.AREA_LINDERAMIENTO = loDatos.AREA_LINDERAMIENTO;
                        oCamposDet.INEX_AGUAJAL = loDatos.INEX_AGUAJAL;
                        oCamposDet.INEX_AGUAJAL_PORC = loDatos.INEX_AGUAJAL_PORC;
                        oCamposDet.INEX_AGUAJAL_NOUB = loDatos.INEX_AGUAJAL_NOUB;
                        oCamposDet.INEX_AGUAJAL_OBS = loDatos.INEX_AGUAJAL_OBS;
                        oCamposDet.INEX_PASTIZAL = loDatos.INEX_PASTIZAL;
                        oCamposDet.INEX_PASTIZAL_PORC = loDatos.INEX_PASTIZAL_PORC;
                        oCamposDet.INEX_PASTIZAL_NOUB = loDatos.INEX_PASTIZAL_NOUB;
                        oCamposDet.INEX_PASTIZAL_OBS = loDatos.INEX_PASTIZAL_OBS;
                        oCamposDet.INEX_INACCESIBLE = loDatos.INEX_INACCESIBLE;
                        oCamposDet.INEX_INACCESIBLE_PORC = loDatos.INEX_INACCESIBLE_PORC;
                        oCamposDet.INEX_INACCESIBLE_NOUB = loDatos.INEX_INACCESIBLE_NOUB;
                        oCamposDet.INEX_INACCESIBLE_OBS = loDatos.INEX_INACCESIBLE_OBS;
                        oCamposDet.INEX_OTROS = loDatos.INEX_OTROS;
                        oCamposDet.INEX_OTROS_PORC = loDatos.INEX_OTROS_PORC;
                        oCamposDet.INEX_OTROS_NOUB = loDatos.INEX_OTROS_NOUB;
                        oCamposDet.INEX_OTROS_OBS = loDatos.INEX_OTROS_OBS;
                        oCamposDet.INDICIO_APROV = loDatos.INDICIO_APROV;
                        oCamposDet.OBSERV_APROV = loDatos.OBSERV_APROV;
                        oCamposDet.TIPO_SAPROVECHAMIENTO = loDatos.TIPO_SAPROVECHAMIENTO;
                        oCamposDet.CUMPLE_VIAL_PLANMAN = loDatos.CUMPLE_VIAL_PLANMAN;
                        oCamposDet.CUENTA_AREPOSICION = loDatos.CUENTA_AREPOSICION;
                        oCamposDet.FEC_PRESENT_PM = loDatos.FEC_PRESENT_PM;
                        oCamposDet.FEC_APROB_PM = loDatos.FEC_APROB_PM;
                        oCamposDet.CUMPLE_PM_PGMF = loDatos.CUMPLE_PM_PGMF;
                        oCamposDet.OBSERV_PM_PGMF = loDatos.OBSERV_PM_PGMF;
                        oCamposDet.APROB_NORMAVIGENTE_PM = loDatos.APROB_NORMAVIGENTE_PM;
                        oCamposDet.OBSERV_NORMAVIGENTE_PM = loDatos.OBSERV_NORMAVIGENTE_PM;
                        oCamposDet.CUENTA_INFOEJECPO = loDatos.CUENTA_INFOEJECPO;
                        oCamposDet.FEC_PRESENT_INFOEJECPO = loDatos.FEC_PRESENT_INFOEJECPO;
                        oCamposDet.FEC_COMUNIC_INFOEJECPO = loDatos.FEC_COMUNIC_INFOEJECPO;
                        oCamposDet.CUMPLE_LINEA_INFOEJECPO = loDatos.CUMPLE_LINEA_INFOEJECPO;
                        oCamposDet.OBSERV_LINEA_INFOEJECPO = loDatos.OBSERV_LINEA_INFOEJECPO;
                        oCamposDet.CUMPLE_PAGO_APROV = loDatos.CUMPLE_PAGO_APROV;
                        oCamposDet.OBSERV_PAGO_APROV = loDatos.OBSERV_PAGO_APROV;
                        oCamposDet.COD_RESODIREC_GRAVEDAD = loDatos.COD_RESODIREC_GRAVEDAD;
                        oCamposDet.RegEstado = loDatos.RegEstado;
                        oCamposDet.OUTPUTPARAM01 = "";
                        if (oCamposDet.RegEstado == -1)
                        {
                            oCamposDet.RegEstado = 1;
                        }
                        dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spINFORME_QUINQUENAL_INFO_DOCUMENTGrabar", oCamposDet);
                    }
                }
                if (oCEntidad.ListISupervLindAreaVertice != null)
                {
                    foreach (var loDatos in oCEntidad.ListISupervLindAreaVertice)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            oCamposDet = new CEntidad();
                            oCamposDet.COD_INFORME = OUTPUTPARAM01;//.Split('|')[0];
                            oCamposDet.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            oCamposDet.VERTICE = loDatos.VERTICE;
                            oCamposDet.ZONA = loDatos.ZONA;
                            oCamposDet.COORDENADA_ESTE = loDatos.COORDENADA_ESTE;
                            oCamposDet.COORDENADA_NORTE = loDatos.COORDENADA_NORTE;
                            oCamposDet.OBSERVACION = loDatos.OBSERVACION;
                            oCamposDet.COD_UCUENTA = oCEntidad.COD_UCUENTA;
                            oCamposDet.RegEstado = loDatos.RegEstado;
                            oCamposDet.NUM_POA = loDatos.NUM_POA;

                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.ISUPERVISION_LINDAREA_VERTICE_Grabar", oCamposDet);
                        }
                    }
                }
                if (oCEntidad.ListISupervMaderableAdicional != null)
                {
                    foreach (var loDatos in oCEntidad.ListISupervMaderableAdicional)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            //oCamposMad = new CEntSDetMarable();
                            oCamposDet = new CEntidad();
                            oCamposDet.COD_INFORME = OUTPUTPARAM01;
                            oCamposDet.COD_ESPECIES = loDatos.COD_ESPECIES;
                            oCamposDet.DESC_ESPECIES = loDatos.DESC_ESPECIES;
                            oCamposDet.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            oCamposDet.BLOQUE = loDatos.BLOQUE;
                            oCamposDet.FAJA = loDatos.FAJA;
                            oCamposDet.CODIGO = loDatos.CODIGO;
                            oCamposDet.DAP = loDatos.DAP;
                            oCamposDet.AC = loDatos.AC;
                            oCamposDet.COORDENADA_ESTE = loDatos.COORDENADA_ESTE;
                            oCamposDet.COORDENADA_NORTE = loDatos.COORDENADA_NORTE;
                            // oCamposDet.COD_ECONDICION = loDatos.COD_ECONDICION;
                            oCamposDet.COD_EESTADO = loDatos.COD_EESTADO;
                            oCamposDet.DESC_EESTADO = loDatos.DESC_EESTADO;
                            oCamposDet.COD_ACATEGORIA = loDatos.COD_ACATEGORIA;
                            oCamposDet.DESC_ACATEGORIA = loDatos.DESC_ACATEGORIA;
                            oCamposDet.OBSERVACION = loDatos.OBSERVACION;
                            oCamposDet.RegEstado = loDatos.RegEstado;
                            oCamposDet.MAE_TIP_MADERABLE = loDatos.MAE_TIP_MADERABLE;
                            oCamposDet.NUM_POA = loDatos.NUM_POA;

                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.ISUPERVISION_DET_EMADERABLE_ADICIONAL_Grabar", oCamposDet);
                        }
                    }
                }
                if (oCEntidad.ListISupervMaderableNoAutorizado != null)
                {

                    foreach (var loDatos in oCEntidad.ListISupervMaderableNoAutorizado)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            //oCamposMad = new CEntSDetMarable();
                            oCamposDet = new CEntidad();
                            oCamposDet.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            oCamposDet.COD_ESPECIES = loDatos.COD_ESPECIES;
                            oCamposDet.DESC_ESPECIES = loDatos.DESC_ESPECIES;
                            oCamposDet.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            oCamposDet.BLOQUE = loDatos.BLOQUE;
                            oCamposDet.FAJA = loDatos.FAJA;
                            oCamposDet.CODIGO = loDatos.CODIGO;
                            oCamposDet.DAP = loDatos.DAP;
                            oCamposDet.AC = loDatos.AC;
                            oCamposDet.COORDENADA_ESTE = loDatos.COORDENADA_ESTE;
                            oCamposDet.COORDENADA_NORTE = loDatos.COORDENADA_NORTE;
                            //oCamposDet.COD_ECONDICION = loDatos.COD_ECONDICION;
                            oCamposDet.COD_EESTADO = loDatos.COD_EESTADO;
                            oCamposDet.DESC_EESTADO = loDatos.DESC_EESTADO;
                            oCamposDet.COD_ACATEGORIA = loDatos.COD_ACATEGORIA;
                            oCamposDet.DESC_ACATEGORIA = loDatos.DESC_ACATEGORIA;
                            oCamposDet.OBSERVACION = loDatos.OBSERVACION;
                            oCamposDet.RegEstado = loDatos.RegEstado;
                            oCamposDet.MAE_TIP_MADERABLE = loDatos.MAE_TIP_MADERABLE;
                            oCamposDet.NUM_POA = loDatos.NUM_POA;

                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.ISUPERVISION_DET_EMADERABLE_ADICIONAL_Grabar", oCamposDet);
                        }
                    }
                }
                if (oCEntidad.ListISDSilvicultutal != null)
                {

                    foreach (var loDatos in oCEntidad.ListISDSilvicultutal)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            //oCampoSilv = new CEntISDSilvicultural();
                            oCamposDet = new CEntidad();
                            oCamposDet.COD_INFORME = OUTPUTPARAM01;
                            oCamposDet.COD_ASILVICULTURALES = loDatos.COD_ASILVICULTURALES;
                            oCamposDet.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            oCamposDet.COD_ESPECIES = loDatos.COD_ESPECIES;
                            oCamposDet.FAJA = loDatos.FAJA;
                            oCamposDet.NUM_PLANTULAS = loDatos.NUM_PLANTULAS;
                            oCamposDet.UBICACION = loDatos.UBICACION;
                            oCamposDet.TIEMPO = loDatos.TIEMPO;
                            oCamposDet.CUMPLIMIENTO_ACTIVIDADES = loDatos.CUMPLIMIENTO_ACTIVIDADES;
                            oCamposDet.OBSERVACION = loDatos.OBSERVACION;
                            oCamposDet.NUM_POA = loDatos.NUM_POA;
                            oCamposDet.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.ISUPERVISION_DET_ASILVICULTURALES_Grabar", oCamposDet);
                        }
                    }
                }
                // CAMBIO DE USO
                if (oCEntidad.ListISupervCambioUso != null)
                {
                    foreach (var loDatos in oCEntidad.ListISupervCambioUso)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            CEntidad ocampo = new CEntidad();
                            ocampo.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            ocampo.MAE_TIP_CAMBIOUSO = loDatos.MAE_TIP_CAMBIOUSO;
                            ocampo.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            ocampo.AREA = loDatos.AREA;
                            ocampo.OBSERVACION = loDatos.OBSERVACION;
                            ocampo.NUM_POA = loDatos.NUM_POA;
                            ocampo.COD_UCUENTA = oCEntidad.COD_UCUENTA;
                            ocampo.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.ISUPERVISION_CAMBIO_USO_Grabar", ocampo);
                        }
                    }
                }
                //VOLUMEN INJUSTIFICADO
                if (oCEntidad.ListVolInjustificado != null)
                {

                    foreach (var loDatos in oCEntidad.ListVolInjustificado)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            //oCamposMad = new CEntSDetMarable();
                            oCamposDet = new CEntidad();
                            oCamposDet.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            oCamposDet.COD_ENCIENTIFICO = loDatos.COD_ENCIENTIFICO;
                            oCamposDet.NOMBRE_CIENTIFICO = loDatos.NOMBRE_CIENTIFICO;
                            oCamposDet.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            oCamposDet.NOMBRE_COMUN = loDatos.NOMBRE_COMUN;
                            oCamposDet.VOLUMEN = loDatos.VOLUMEN;
                            oCamposDet.NUM_POA = loDatos.NUM_POA;
                            //oCamposDet.TIPOMADERABLE = loDatos.TIPOMADERABLE;
                            oCamposDet.OBSERVACION = loDatos.OBSERVACION;
                            oCamposDet.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.ISUPERVISION_MADE_NOMADE_DET_VOL_INJUSTIFICADO_Grabar", oCamposDet);
                        }
                    }
                }

                /*
                                ocampoEnt.COD_INFORME = dr["COD_INFORME"].ToString();
                                ocampoEnt.COD_VERIFICADOR = dr["COD_VERIFICADOR"].ToString();
                                ocampoEnt.VERIFICADOR = dr["VERIFICADOR"].ToString();
                                ocampoEnt.OBSERVACION = dr["OBSERVACIONES"].ToString();
                                ocampoEnt.QUINQUENIO = Int32.Parse(dr["QUINQUENION"].ToString());
                                ocampoEnt.VALUE_VERIFICADOR = dr["VALUE_VERIFICADOR"].ToString();
                                ocampoEnt.CODIGO = dr["COD_VERICADOR_INT"].ToString();
                 */
                if (oCEntidad.listVerificadores1 != null)
                {
                    if (oCEntidad.listVerificadores1.Count > 0)
                    {
                        foreach (var loDatos in oCEntidad.listVerificadores1)
                        {
                            oCamposDet = new CEntidad();
                            oCamposDet.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            oCamposDet.CODIGO = loDatos.CODIGO;
                            oCamposDet.VERIFICADOR = loDatos.VERIFICADOR;
                            oCamposDet.OBSERVACION = loDatos.OBSERVACION;
                            oCamposDet.QUINQUENIO = loDatos.QUINQUENIO;
                            oCamposDet.VALUE_VERIFICADOR = loDatos.VALUE_VERIFICADOR;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spINFORME_QUINQUENAL_VERIFICADOR_GRABAR", oCamposDet);
                        }
                    }
                }
                if (oCEntidad.listVerificadores2 != null)
                {
                    if (oCEntidad.listVerificadores2.Count > 0)
                    {
                        foreach (var loDatos in oCEntidad.listVerificadores2)
                        {
                            oCamposDet = new CEntidad();
                            oCamposDet.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            oCamposDet.CODIGO = loDatos.CODIGO;
                            oCamposDet.VERIFICADOR = loDatos.VERIFICADOR;
                            oCamposDet.OBSERVACION = loDatos.OBSERVACION;
                            oCamposDet.QUINQUENIO = loDatos.QUINQUENIO;
                            oCamposDet.VALUE_VERIFICADOR = loDatos.VALUE_VERIFICADOR;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spINFORME_QUINQUENAL_VERIFICADOR_GRABAR", oCamposDet);
                        }
                    }
                }
                if (oCEntidad.listVerificadores3 != null)
                {
                    if (oCEntidad.listVerificadores3.Count > 0)
                    {
                        foreach (var loDatos in oCEntidad.listVerificadores3)
                        {
                            oCamposDet = new CEntidad();
                            oCamposDet.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            oCamposDet.CODIGO = loDatos.CODIGO;
                            oCamposDet.VERIFICADOR = loDatos.VERIFICADOR;
                            oCamposDet.OBSERVACION = loDatos.OBSERVACION;
                            oCamposDet.QUINQUENIO = loDatos.QUINQUENIO;
                            oCamposDet.VALUE_VERIFICADOR = loDatos.VALUE_VERIFICADOR;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spINFORME_QUINQUENAL_VERIFICADOR_GRABAR", oCamposDet);
                        }
                    }
                }
                if (oCEntidad.listVerificadores4 != null)
                {
                    if (oCEntidad.listVerificadores4.Count > 0)
                    {
                        foreach (var loDatos in oCEntidad.listVerificadores4)
                        {
                            oCamposDet = new CEntidad();
                            oCamposDet.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            oCamposDet.CODIGO = loDatos.CODIGO;
                            oCamposDet.VERIFICADOR = loDatos.VERIFICADOR;
                            oCamposDet.OBSERVACION = loDatos.OBSERVACION;
                            oCamposDet.QUINQUENIO = loDatos.QUINQUENIO;
                            oCamposDet.VALUE_VERIFICADOR = loDatos.VALUE_VERIFICADOR;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spINFORME_QUINQUENAL_VERIFICADOR_GRABAR", oCamposDet);
                        }
                    }
                }
                tr.Commit();
                return OUTPUTPARAM01;
            }
            catch (Exception ex)
            {
                if (tr != null)
                {
                    tr.Rollback();
                }
                throw ex;
            }

        }
        public Ent_InfQuinquenal_QUINQUENIO RegMostrarItemsQuinquenio(OracleConnection cn, string asCodInforme, int QUINQUENIO)
        {
            try
            {
                Ent_InfQuinquenal_QUINQUENIO result = new Ent_InfQuinquenal_QUINQUENIO();

                result.verificadores = new List<CEntidad>();
                result.entConclusion = new Ent_IQUINQUENAL_DET_CONCLUSION();
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, "DOC_OSINFOR_ERP_MIGRACION.USPINFORMEQUINQUENALMOSTRARITEMSQUINQUENIO", asCodInforme, QUINQUENIO))
                {
                    if (dr != null)
                    {
                        //CEntidad ocampoEnt; 
                        //Verificadores
                     
                        if (dr.HasRows)
                        {
                            CEntidad verificador;
                            while (dr.Read())
                            {
                                verificador = new CEntidad();
                                verificador.COD_INFORME = dr["COD_INFORME"].ToString();
                                verificador.COD_VERIFICADOR = dr["COD_VERIFICADOR"].ToString();
                                verificador.VERIFICADOR = dr["VERIFICADOR"].ToString();
                                verificador.OBSERVACION = dr["OBSERVACIONES"].ToString();
                                verificador.QUINQUENIO = dr["QUINQUENION"] == DBNull.Value ? 0 : Convert.ToInt32(dr["QUINQUENION"]);
                                verificador.VALUE_VERIFICADOR = dr["VALUE_VERIFICADOR"].ToString();
                                verificador.CODIGO = dr["COD_VERICADOR_INT"].ToString();
                                result.verificadores.Add(verificador);
                            }



                        }
                        //Conclusiones
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            // Ent_IQUINQUENAL_DET_CONCLUSION entConclusion;

                            dr.Read();
                            
                                // entConclusion = new Ent_IQUINQUENAL_DET_CONCLUSION();
                                result.entConclusion.COD_INFORME = dr["COD_INFORME"].ToString();
                                result.entConclusion.QUINQUENIO = Int32.Parse(dr["QUINQUENIO"].ToString());
                                result.entConclusion.CRITERIO_EVALUACION = dr["CRITERIO_EVALUACION"].ToString();
                                result.entConclusion.ACLARACION_TITULAR = dr["ACLARACION_TITULAR"].ToString();
                                result.entConclusion.IMPL_PMANEJO = dr["IMPL_PMANEJO"].ToString();
                                result.entConclusion.CUMPL_OBLIGACION = dr["CUMPL_OBLIGACION"].ToString();
                                result.entConclusion.CALIDAD_IMPL = dr["CALIDAD_IMPL"].ToString();
                                result.entConclusion.OPINION_FAVORABLE = dr["OPINION_FAVORABLE"].ToString();
                                result.entConclusion.DEMORA_NEGLIGENCIA = dr["DEMORA_NEGLIGENCIA"].ToString();
                                result.entConclusion.ADVERTENCIA_CAUSAL = dr["ADVERTENCIA_CAUSAL"].ToString();
                                result.entConclusion.AUDITORIA_OK =dr["AUDITORIA_OK"]==DBNull.Value?0:Convert.ToInt32(dr["AUDITORIA_OK"]);
                                result.entConclusion.AMPLIAR_CONTRATO = dr["AMPLIAR_CONTRATO"] == DBNull.Value ? 0 : Convert.ToInt32(dr["AMPLIAR_CONTRATO"]); ;
                                //lsCEntidad.ListConclusiones.Add(entConclusion);
                             
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
        public CEntidad RegMostrarItems(OracleConnection cn, CEntidad oCEntidad)
        {
            try
            {
                CEntidad lsCEntidad = new CEntidad();
                lsCEntidad.ListEliTABLA = new List<CEntidad>();
                lsCEntidad.ListProfesionales = new List<CEntidad>();
                lsCEntidad.ListRDQuinquenal = new List<CEntidad>();
                lsCEntidad.ListParticipantes = new List<CEntidad>();
                lsCEntidad.ListInfraestructura = new List<CEntidad>();
                lsCEntidad.ListISupervInfoDocument = new List<CEntidad>();
                lsCEntidad.ListISupervLindAreaVertice = new List<CEntidad>();
                lsCEntidad.ListISupervMaderableAdicional = new List<CEntidad>();
                lsCEntidad.ListISupervMaderableNoAutorizado = new List<CEntidad>();
                lsCEntidad.ListISDSilvicultutal = new List<CEntidad>();
                lsCEntidad.ListISupervCambioUso = new List<CEntidad>();
                lsCEntidad.ListVolInjustificado = new List<CEntidad>();

                lsCEntidad.listVerificadores1 = new List<CEntidad>();
                lsCEntidad.listVerificadores2 = new List<CEntidad>();
                lsCEntidad.listVerificadores3 = new List<CEntidad>();
                lsCEntidad.listVerificadores4 = new List<CEntidad>();
                lsCEntidad.ListHallazgos = new List<CEntidad>();
                lsCEntidad.ListVerificadores = new List<CEntidad>();
                lsCEntidad.ListConclusiones = new List<Ent_IQUINQUENAL_DET_CONCLUSION>();

                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spINFORMEQUINQUENALMostrarItems", oCEntidad))
                {
                    if (dr != null)
                    {
                        CEntidad ocampoEnt;
                        if (dr.HasRows)
                        {
                            dr.Read();
                            lsCEntidad.COD_INFORME = dr["COD_INFORME"].ToString();
                            lsCEntidad.NUM_INFORME = dr["NUMERO"].ToString();
                            lsCEntidad.FECHA_EMISION = dr["FECHA_EMISION"].ToString();
                            lsCEntidad.COD_DIRECTOR = dr["COD_DIRECTOR"].ToString().Trim();
                            lsCEntidad.APELLIDOS_NOMBRE = dr["DIRECTOR"].ToString().Trim();
                            lsCEntidad.OBSERVACION = dr["OBSERVACION"].ToString().Trim();
                            lsCEntidad.USUARIO_REGISTRO = dr["USUARIO_REGISTRO"].ToString();
                            lsCEntidad.COD_ITIPO = dr["COD_ITIPO"].ToString();
                            lsCEntidad.DOCUMENTACION = dr["DOCUMENTACION"].ToString().Trim();
                            lsCEntidad.ASUNTO = dr["ASUNTO"].ToString().Trim();
                            lsCEntidad.FECHA_INICIO_AUDITORIA = dr["FECHA_INICIO_AUDITORIA"].ToString();
                            lsCEntidad.FECHA_FIN_AUDITORIA = dr["FECHA_FIN_AUDITORIA"].ToString();
                        }
                        //Estado (Calidad)
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            dr.Read();
                            lsCEntidad.COD_ESTADO_DOC = dr["COD_ESTADO_DOC"].ToString();
                            lsCEntidad.OBSERVACIONES_CONTROL = dr["OBSERVACIONES_CONTROL"].ToString();
                            lsCEntidad.OBSERV_SUBSANAR = Convert.ToBoolean(dr["OBSERV_SUBSANAR"]);
                            lsCEntidad.USUARIO_CONTROL = dr["USUARIO_CONTROL"].ToString();
                        }
                        else
                        {
                            lsCEntidad.COD_ESTADO_DOC = "0000000";
                            lsCEntidad.OBSERVACIONES_CONTROL = "";
                            lsCEntidad.OBSERV_SUBSANAR = false;
                            lsCEntidad.USUARIO_CONTROL = "";
                        }
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidad();
                                ocampoEnt.COD_PERSONA = dr["COD_PROFESIONAL"].ToString();
                                ocampoEnt.APELLIDOS_NOMBRE = dr["PROFESIONAL"].ToString();
                                ocampoEnt.RegEstado = 0;
                                lsCEntidad.ListProfesionales.Add(ocampoEnt);
                            }
                        }
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidad();
                                ocampoEnt.COD_RESODIREC = dr["COD_RESODIREC"].ToString();
                                ocampoEnt.NUMERO_RESOLUCION = dr["NUMERO_RESOLUCION"].ToString();
                                ocampoEnt.TIPO_FISCALIZA = dr["TIPO_FISCALIZA"].ToString();
                                ocampoEnt.TITULO_TH = dr["NUM_THABILITANTE"].ToString();
                                ocampoEnt.COD_FCTIPO = dr["COD_FCTIPO"].ToString();
                                /*ocampoEnt.PRIM_QUIN = Boolean.Parse(dr["PRIM_QUINQUENIO"].ToString());
                                ocampoEnt.SEC_QUIN = Boolean.Parse(dr["SEG_QUINQUENIO"].ToString());
                                ocampoEnt.TER_QUIN = Boolean.Parse(dr["TERC_QUINQUENIO"].ToString());
                                ocampoEnt.CUART_QUIN = Boolean.Parse(dr["CUART_QUINQUENIO"].ToString());*/

                                ocampoEnt.RegEstado = 0;
                                lsCEntidad.ListRDQuinquenal.Add(ocampoEnt);
                            }
                        }
                        //Listado de hallazgos (resultados)
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidad();
                                ocampoEnt.COD_SECUENCIAL = Convert.ToInt32(dr["COD_SECUENCIAL"].ToString());
                                ocampoEnt.HALLAZGO = dr["HALLAZGO"].ToString();
                                ocampoEnt.RegEstado = 0;
                                lsCEntidad.ListHallazgos.Add(ocampoEnt);
                            }
                        }
                        /*
                        //Verificadores
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidad();
                                ocampoEnt.COD_INFORME = dr["COD_INFORME"].ToString();
                                ocampoEnt.COD_VERIFICADOR = dr["COD_VERIFICADOR"].ToString();
                                ocampoEnt.VERIFICADOR = dr["VERIFICADOR"].ToString();
                                ocampoEnt.OBSERVACION = dr["OBSERVACIONES"].ToString();
                                ocampoEnt.QUINQUENIO = Int32.Parse(dr["QUINQUENION"].ToString());
                                ocampoEnt.VALUE_VERIFICADOR = dr["VALUE_VERIFICADOR"].ToString();
                                ocampoEnt.CODIGO = dr["COD_VERICADOR_INT"].ToString();
                                lsCEntidad.ListVerificadores.Add(ocampoEnt);
                            }
                        }
                        //Conclusiones
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            Ent_IQUINQUENAL_DET_CONCLUSION entConclusion;

                            while (dr.Read())
                            {
                                entConclusion = new Ent_IQUINQUENAL_DET_CONCLUSION();
                                entConclusion.COD_INFORME = dr["COD_INFORME"].ToString();
                                entConclusion.QUINQUENIO = Int32.Parse(dr["QUINQUENIO"].ToString());
                                entConclusion.CRITERIO_EVALUACION = dr["CRITERIO_EVALUACION"].ToString();
                                entConclusion.ACLARACION_TITULAR = dr["ACLARACION_TITULAR"].ToString();
                                entConclusion.IMPL_PMANEJO = dr["IMPL_PMANEJO"].ToString();
                                entConclusion.CUMPL_OBLIGACION = dr["CUMPL_OBLIGACION"].ToString();
                                entConclusion.CALIDAD_IMPL = dr["CALIDAD_IMPL"].ToString();
                                entConclusion.OPINION_FAVORABLE = dr["OPINION_FAVORABLE"].ToString();
                                entConclusion.DEMORA_NEGLIGENCIA = dr["DEMORA_NEGLIGENCIA"].ToString();
                                entConclusion.ADVERTENCIA_CAUSAL = dr["ADVERTENCIA_CAUSAL"].ToString();
                                entConclusion.AUDITORIA_OK = Int32.Parse(dr["AUDITORIA_OK"].ToString());
                                entConclusion.AMPLIAR_CONTRATO = Int32.Parse(dr["AMPLIAR_CONTRATO"].ToString());
                                lsCEntidad.ListConclusiones.Add(entConclusion);
                            }
                        }*/
                    }
                }
                return lsCEntidad;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<CEntidad> GetAllCartaNotificacion(string BusFormulario, string BusCriterio, string BusValor, string BusCriterio1 = "")
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            CEntidad oCampos;
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    object[] param = { BusFormulario, BusCriterio, BusValor, "", 1, 20 };
                    using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, "DOC_OSINFOR_ERP_MIGRACION.spGeneral_Listar", param))
                    {
                        if (dr != null)
                        {

                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    oCampos = new CEntidad();
                                    oCampos.COD_RESODIREC = dr["COD_CNOTIFICACION"].ToString();
                                    oCampos.NUMERO_RESOLUCION = dr["NUM_CNOTIFICACION"].ToString();
                                    oCampos.MODALIDAD = dr["MODALIDAD"].ToString();
                                    oCampos.TIPO_FISCALIZA = "Carta de Notificación de Auditoría Quinquenal";
                                    oCampos.COD_THABILITANTE = dr["COD_THABILITANTE"].ToString();
                                    oCampos.TITULO_TH = dr["NUM_THABILITANTE"].ToString();
                                    oCampos.RegEstado = 1;
                                    oCampos.COD_FCTIPO = "0000005"; //Carta de Notificación de Auditoría Quinquenal
                                    //oCampos.TITULAR = dr["TITULAR"].ToString();
                                    //oCampos.POA = dr["POA"].ToString();
                                    lsCEntidad.Add(oCampos);
                                }
                            }
                        }
                    }
                }
                return lsCEntidad;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //public List<CEntidad> dat_ListRDQuinquenal(SqlConnection cn, CEntidad oCEntidad)
        //{
        //    List<CEntidad> lsCEntidad = new List<CEntidad>();
        //    CEntidad oCampos = new CEntidad();
        //    try
        //    {
        //        using (SqlDataReader dr = oGDataSQL.SelDrdResult(cn, null, "DOC.spGeneral_Listar", oCEntidad))
        //        {
        //            if (dr != null)
        //            {
        //                if (dr.HasRows)
        //                {
        //                    while (dr.Read())
        //                    {
        //                        oCampos = new CEntidad();
        //                        oCampos.COD_RESODIREC = dr["COD_RESODIREC"].ToString();
        //                        oCampos.NUMERO_RESOLUCION = dr["NUMERO_RESOLUCION"].ToString();
        //                        oCampos.TIPO_FISCALIZA = dr["TIPO_FISCALIZA"].ToString();
        //                        oCampos.FECHA_EMISION = dr["FECHA"].ToString();
        //                        oCampos.TITULO_TH = dr["NUM_THABILITANTE"].ToString();
        //                        oCampos.COD_THABILITANTE = dr["COD_THABILITANTE"].ToString();
        //                        oCampos.COD_FCTIPO = dr["COD_FCTIPO"].ToString();

        //                        oCampos.PRIM_QUIN = Boolean.Parse(dr["PRIM_QUINQUENIO"].ToString());
        //                        oCampos.SEC_QUIN = Boolean.Parse(dr["SEG_QUINQUENIO"].ToString());
        //                        oCampos.TER_QUIN = Boolean.Parse(dr["TERC_QUINQUENIO"].ToString());
        //                        oCampos.CUART_QUIN = Boolean.Parse(dr["CUART_QUINQUENIO"].ToString());

        //                        lsCEntidad.Add(oCampos);
        //                    }
        //                }
        //            }
        //        }
        //        return lsCEntidad;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public List<CEntidad> dat_LogComboListar(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            CEntidad oCampos = new CEntidad();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spGeneral_Combo_Listar", oCEntidad))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                oCampos.CODIGO = dr["CODIGO"].ToString();
                                oCampos.DESCRIPCION = dr["DESCRIPCION"].ToString();
                                lsCEntidad.Add(oCampos);
                            }
                        }
                    }
                }
                return lsCEntidad;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<int> ObtenerQuinquenios(OracleConnection cn, CEntidad oCEntidad)
        {
            List<int> quinquenios = new List<int>();

            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spInformeQuinquenal_General", oCEntidad))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                quinquenios.Add(dr.GetInt32(dr.GetOrdinal("QUIENQUENIO")));
                            }
                        }
                    }
                }
                return quinquenios;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // listado de POA
        //public CEntidad RegMostListPOAs(SqlConnection cn, CEntidad oCEntidad)
        //{
        //    CEntidad oCampos = null;
        //    try
        //    {
        //        using (SqlDataReader dr = oGDataSQL.SelDrdDefault(cn, null, "DOC.spInformeQuinquenal_General", oCEntidad))
        //        {
        //            if (dr != null)
        //            {
        //                oCampos = new CEntidad();
        //                List<CEntidad> lsDetDetalle;
        //                CEntidad oCamposDet;
        //                //
        //                //Lista de POAS
        //                lsDetDetalle = new List<CEntidad>();
        //                if (dr.HasRows)
        //                {
        //                    int pt1 = dr.GetOrdinal("NUM_POA");
        //                    int pt2 = dr.GetOrdinal("POA");
        //                    while (dr.Read())
        //                    {
        //                        oCamposDet = new CEntidad();
        //                        oCamposDet.NUM_POA = dr.GetInt32(pt1);
        //                        oCamposDet.POA = dr.GetString(pt2);
        //                        oCamposDet.RegEstado = 0;
        //                        lsDetDetalle.Add(oCamposDet);
        //                    }
        //                }
        //                oCampos.ListPOAs = lsDetDetalle;
        //            }
        //        }
        //        return oCampos;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
    }
}
