using CapaEntidad.DOC;
using GeneralSQL;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using CEntidad = CapaEntidad.DOC.Ent_IMEDIDA;

namespace CapaDatos.DOC
{
    public class Dat_IMEDIDA
    {
        private DBOracle dBOracle = new DBOracle();

        public CEntidad RegMostrarListaItems(OracleConnection cn, CEntidad oCEntidad)
        {
            CEntidad oCampos = new CEntidad();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spIMEDIDAMostrarItem", oCEntidad))
                {
                    if (dr != null)
                    {
                        oCampos.ListEliTABLA = new List<Ent_IMEDIDA_EliTABLA>();
                        oCampos.ListProfResponsable = new List<Ent_IMEDIDA_RESPONSABLE>();
                        oCampos.ListEspecieReforestada = new List<Ent_IMEDIDA_ESPECIE>();
                        oCampos.ListVerticeReforestada = new List<Ent_IMEDIDA_VERTICE>();
                        oCampos.ListExpediente = new List<Ent_IMEDIDA_EXPEDIENTE>();

                        if (dr.HasRows)
                        {
                            dr.Read();
                            oCampos.COD_INFORME = dr.GetString(dr.GetOrdinal("COD_INFORME"));
                            oCampos.COD_ITIPO = dr.GetString(dr.GetOrdinal("COD_ITIPO"));
                            oCampos.ITIPO = dr.GetString(dr.GetOrdinal("ITIPO"));
                            oCampos.NUMERO = dr.GetString(dr.GetOrdinal("NUMERO"));
                            oCampos.IMOTIVO = dr.GetString(dr.GetOrdinal("IMOTIVO"));
                            oCampos.COD_DIRECTOR = dr.GetString(dr.GetOrdinal("COD_DIRECTOR"));
                            oCampos.DIRECTOR = dr.GetString(dr.GetOrdinal("DIRECTOR"));
                            oCampos.CUMPLE_PLAZO = dr.GetBoolean(dr.GetOrdinal("CUMPLE_PLAZO"));
                            oCampos.FECHA_RECEPCION = dr.GetString(dr.GetOrdinal("FECHA_RECEPCION"));
                            oCampos.INFORME_COMPLETO = dr.GetBoolean(dr.GetOrdinal("INFORME_COMPLETO"));
                            oCampos.FIRMA_REGENTE = dr.GetBoolean(dr.GetOrdinal("FIRMA_REGENTE"));
                            oCampos.CONCLUSION = dr.GetString(dr.GetOrdinal("CONCLUSION"));
                            oCampos.REMITIR_DFFFS = dr.GetBoolean(dr.GetOrdinal("REMITIR_DFFFS"));
                            oCampos.RECOMENDACION = dr.GetString(dr.GetOrdinal("RECOMENDACION"));
                            oCampos.FECHA_VERIFICA_INICIO = dr.GetString(dr.GetOrdinal("FECHA_VERIFICA_INICIO"));
                            oCampos.FECHA_VERIFICA_FIN = dr.GetString(dr.GetOrdinal("FECHA_VERIFICA_FIN"));
                            oCampos.FECHA_IMPLEMENTACION = dr.GetString(dr.GetOrdinal("FECHA_IMPLEMENTACION"));
                            oCampos.REPOSICION_DENTRO = dr.GetBoolean(dr.GetOrdinal("REPOSICION_DENTRO"));
                            oCampos.REPOSICION_FUERA = dr.GetBoolean(dr.GetOrdinal("REPOSICION_FUERA"));
                            oCampos.CUMPLE_CANTIDAD = dr.GetBoolean(dr.GetOrdinal("CUMPLE_CANTIDAD"));
                            oCampos.CUMPLE_MEDIDA = dr.GetBoolean(dr.GetOrdinal("CUMPLE_MEDIDA"));
                            oCampos.USUARIO_REGISTRO = dr.GetString(dr.GetOrdinal("USUARIO_REGISTRO"));
                        }
                        //Estado (Calidad)
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            dr.Read();
                            oCampos.COD_ESTADO_DOC = dr.GetString(dr.GetOrdinal("COD_ESTADO_DOC"));
                            oCampos.OBSERVACIONES_CONTROL = dr.GetString(dr.GetOrdinal("OBSERVACIONES_CONTROL"));
                            oCampos.OBSERV_SUBSANAR = dr.GetBoolean(dr.GetOrdinal("OBSERV_SUBSANAR"));
                            oCampos.USUARIO_CONTROL = dr.GetString(dr.GetOrdinal("USUARIO_CONTROL"));

                        }
                        //Listado Profesional Responsable
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            Ent_IMEDIDA_RESPONSABLE oCamposRes;

                            while (dr.Read())
                            {
                                oCamposRes = new Ent_IMEDIDA_RESPONSABLE();
                                oCamposRes.COD_RESPONSABLE = dr.GetString(dr.GetOrdinal("COD_RESPONSABLE"));
                                oCamposRes.RESPONSABLE = dr.GetString(dr.GetOrdinal("RESPONSABLE"));
                                oCamposRes.RegEstado = 0;
                                oCampos.ListProfResponsable.Add(oCamposRes);
                            }
                        }
                        //Listado de plantas reforestadas y/o reemplazadas
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            Ent_IMEDIDA_ESPECIE oCamposEsp;

                            while (dr.Read())
                            {
                                oCamposEsp = new Ent_IMEDIDA_ESPECIE();
                                oCamposEsp.COD_SECUENCIAL = dr.GetInt32(dr.GetOrdinal("COD_SECUENCIAL"));
                                oCamposEsp.COD_ESPECIES = dr.GetString(dr.GetOrdinal("COD_ESPECIES"));
                                oCamposEsp.DESCRIPCION_ESPECIE = dr.GetString(dr.GetOrdinal("DESCRIPCION_ESPECIE"));
                                oCamposEsp.DIAMETRO = dr.GetDecimal(dr.GetOrdinal("DIAMETRO"));
                                oCamposEsp.ALTURA = dr.GetDecimal(dr.GetOrdinal("ALTURA"));
                                oCamposEsp.ZONA = dr.GetString(dr.GetOrdinal("ZONA"));
                                oCamposEsp.COORDENADA_ESTE = dr.GetInt32(dr.GetOrdinal("COORDENADA_ESTE"));
                                oCamposEsp.COORDENADA_NORTE = dr.GetInt32(dr.GetOrdinal("COORDENADA_NORTE"));
                                oCamposEsp.ESTADO_ESPECIE = dr.GetString(dr.GetOrdinal("ESTADO_ESPECIE"));
                                oCamposEsp.OBSERVACION = dr.GetString(dr.GetOrdinal("OBSERVACION")).Replace("\n", "<br/>");
                                oCamposEsp.RegEstado = 0;
                                oCampos.ListEspecieReforestada.Add(oCamposEsp);
                            }
                        }
                        //Listado de vértices del área de manejo de regeneración natural y/o reforestada
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            Ent_IMEDIDA_VERTICE oCamposVer;

                            while (dr.Read())
                            {
                                oCamposVer = new Ent_IMEDIDA_VERTICE();
                                oCamposVer.COD_SECUENCIAL = dr.GetInt32(dr.GetOrdinal("COD_SECUENCIAL"));
                                oCamposVer.VERTICE = dr.GetString(dr.GetOrdinal("VERTICE"));
                                oCamposVer.ZONA = dr.GetString(dr.GetOrdinal("ZONA"));
                                oCamposVer.COORDENADA_ESTE = dr.GetInt32(dr.GetOrdinal("COORDENADA_ESTE"));
                                oCamposVer.COORDENADA_NORTE = dr.GetInt32(dr.GetOrdinal("COORDENADA_NORTE"));
                                oCamposVer.OBSERVACION = dr.GetString(dr.GetOrdinal("OBSERVACION")).Replace("\n", "<br/>");
                                oCamposVer.RegEstado = 0;
                                oCampos.ListVerticeReforestada.Add(oCamposVer);
                            }
                        }
                        //Listado de expedientes administrativos
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            Ent_IMEDIDA_EXPEDIENTE oCampoExp;

                            while (dr.Read())
                            {
                                oCampoExp = new Ent_IMEDIDA_EXPEDIENTE();
                                oCampoExp.COD_RESODIREC = dr.GetString(dr.GetOrdinal("COD_RESODIREC"));
                                oCampoExp.NUM_EXPEDIENTE = dr.GetString(dr.GetOrdinal("NUM_EXPEDIENTE"));
                                oCampoExp.NUM_THABILITANTE = dr.GetString(dr.GetOrdinal("NUM_THABILITANTE"));
                                oCampoExp.TITULAR = dr.GetString(dr.GetOrdinal("TITULAR"));
                                oCampoExp.MODALIDAD = dr.GetString(dr.GetOrdinal("MODALIDAD"));
                                //oCampoExp.NUM_RESOLUCION = dr.GetString(dr.GetOrdinal("NUM_RESOLUCION"));
                                oCampoExp.RegEstado = 0;
                                oCampos.ListExpediente.Add(oCampoExp);
                            }
                        }
                    }
                }
                return oCampos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public String RegGrabar(OracleConnection cn, CEntidad oCEntidad)
        {
            OracleTransaction tr = null;
            String OUTPUTPARAM01 = "";
            //CEntidad oCamposDet;
            try
            {
                tr = cn.BeginTransaction();
                //Grabando Cabecera
                using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spIMEDIDA_Grabar", oCEntidad))
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
                    if (OUTPUTPARAM01 == "0" || OUTPUTPARAM01 == "1")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("El número de informe ya existe");
                    }
                    else if (OUTPUTPARAM01 == "3")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("Este control de calidad no puede modificarse");
                    }
                    else if (OUTPUTPARAM01 == "2")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("No tiene permisos para modificar este registro");
                    }
                }
                //Reemplazando El Nuevo Codigo Creado
                if (oCEntidad.RegEstado == 1) //Nuevo
                {
                    oCEntidad.COD_INFORME = OUTPUTPARAM01;
                }
                //Eliminando Detalle
                if (oCEntidad.ListEliTABLA != null)
                {
                    Ent_IMEDIDA_EliTABLA oCamposEli;

                    foreach (var loDatos in oCEntidad.ListEliTABLA)
                    {
                        oCamposEli = new Ent_IMEDIDA_EliTABLA();
                        oCamposEli.COD_INFORME = oCEntidad.COD_INFORME;
                        oCamposEli.EliTABLA = loDatos.EliTABLA;
                        oCamposEli.COD_PERSONA = loDatos.COD_PERSONA;
                        oCamposEli.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                        oCamposEli.COD_RESODIREC = loDatos.COD_RESODIREC;
                        dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spIMEDIDA_Eliminar", oCamposEli);
                    }
                }
                //Registrar profesional responsable
                if (oCEntidad.ListProfResponsable != null)
                {
                    Ent_IMEDIDA_RESPONSABLE oCamposRes;

                    foreach (var loDatos in oCEntidad.ListProfResponsable)
                    {
                        if (loDatos.RegEstado != 0)
                        {
                            oCamposRes = new Ent_IMEDIDA_RESPONSABLE();
                            oCamposRes.COD_INFORME = oCEntidad.COD_INFORME;
                            oCamposRes.COD_RESPONSABLE = loDatos.COD_RESPONSABLE;
                            oCamposRes.COD_UCUENTA = oCEntidad.COD_UCUENTA;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.INFORME_DET_SUPERVISOR_Asignar", oCamposRes);
                        }
                    }
                }
                //Registrar las plantas reforestadas y/o reemplazadas
                if (oCEntidad.ListEspecieReforestada != null)
                {
                    Ent_IMEDIDA_ESPECIE oCamposEsp;

                    foreach (var loDatos in oCEntidad.ListEspecieReforestada)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2)
                        {
                            oCamposEsp = new Ent_IMEDIDA_ESPECIE();
                            oCamposEsp.COD_INFORME = oCEntidad.COD_INFORME;
                            oCamposEsp.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            oCamposEsp.COD_ESPECIES = loDatos.COD_ESPECIES;
                            oCamposEsp.DESCRIPCION_ESPECIE = loDatos.DESCRIPCION_ESPECIE;
                            oCamposEsp.DIAMETRO = loDatos.DIAMETRO;
                            oCamposEsp.ALTURA = loDatos.ALTURA;
                            oCamposEsp.ZONA = loDatos.ZONA;
                            oCamposEsp.COORDENADA_ESTE = loDatos.COORDENADA_ESTE;
                            oCamposEsp.COORDENADA_NORTE = loDatos.COORDENADA_NORTE;
                            oCamposEsp.ESTADO_ESPECIE = loDatos.ESTADO_ESPECIE;
                            oCamposEsp.OBSERVACION = loDatos.OBSERVACION;
                            oCamposEsp.COD_UCUENTA = oCEntidad.COD_UCUENTA;
                            oCamposEsp.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spIMEDIDA_DET_ESPECIES_Grabar", oCamposEsp);
                        }
                    }
                }
                //Registrar los vértices de área manejo de regeneración natural y/o reforestadas
                if (oCEntidad.ListVerticeReforestada != null)
                {
                    Ent_IMEDIDA_VERTICE oCamposVer;

                    foreach (var loDatos in oCEntidad.ListVerticeReforestada)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2)
                        {
                            oCamposVer = new Ent_IMEDIDA_VERTICE();
                            oCamposVer.COD_INFORME = oCEntidad.COD_INFORME;
                            oCamposVer.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            oCamposVer.VERTICE = loDatos.VERTICE;
                            oCamposVer.ZONA = loDatos.ZONA;
                            oCamposVer.COORDENADA_ESTE = loDatos.COORDENADA_ESTE;
                            oCamposVer.COORDENADA_NORTE = loDatos.COORDENADA_NORTE;
                            oCamposVer.OBSERVACION = loDatos.OBSERVACION;
                            oCamposVer.COD_UCUENTA = oCEntidad.COD_UCUENTA;
                            oCamposVer.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spIMEDIDA_DET_VERTICES_Grabar", oCamposVer);
                        }
                    }
                }
                //Registrar los expedientes administrativos
                if (oCEntidad.ListExpediente != null)
                {
                    Ent_IMEDIDA_EXPEDIENTE oCompoExp;

                    foreach (var loDatos in oCEntidad.ListExpediente)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2)
                        {
                            oCompoExp = new Ent_IMEDIDA_EXPEDIENTE();
                            oCompoExp.COD_INFORME = oCEntidad.COD_INFORME;
                            oCompoExp.COD_RESODIREC = loDatos.COD_RESODIREC;
                            oCompoExp.COD_UCUENTA = oCEntidad.COD_UCUENTA;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spIMEDIDA_VS_EXP_Grabar", oCompoExp);
                        }
                    }
                }
                //Registrar las medidas asociadas al informe
                if (oCEntidad.ListMedidaAsociada != null)
                {
                    Ent_IMEDIDA_EXP_MEDIDA oCompoMed;

                    foreach (var loDatos in oCEntidad.ListMedidaAsociada)
                    {
                        oCompoMed = new Ent_IMEDIDA_EXP_MEDIDA();
                        oCompoMed.COD_INFORME = oCEntidad.COD_INFORME;
                        oCompoMed.COD_RESODIREC = loDatos.COD_RESODIREC;
                        oCompoMed.COD_RESODIREC_MEDIDA = loDatos.COD_RESODIREC_MEDIDA;
                        oCompoMed.COD_MEDIDA = loDatos.COD_MEDIDA;
                        oCompoMed.COD_UCUENTA = oCEntidad.COD_UCUENTA;
                        dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spIMEDIDA_EXP_MEDIDA_Grabar", oCompoMed);
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

        public CEntidad RegMostCombo(OracleConnection cn, CEntidad oCEntidad)
        {
            CEntidad oCampos = null;
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spGeneral_Combo_Listar", oCEntidad))
                {
                    if (dr != null)
                    {
                        oCampos = new CEntidad();
                        oCampos.ListMComboEspecies = new List<CEntidad>();
                        oCampos.ListMComboTInforme = new List<CEntidad>();
                        oCampos.ListIndicador = new List<CEntidad>();
                        CEntidad oCamposDet;

                        //Tipo Informe
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.CODIGO = dr.GetString(dr.GetOrdinal("CODIGO"));
                                oCamposDet.DESCRIPCION = dr.GetString(dr.GetOrdinal("DESCRIPCION"));
                                oCampos.ListMComboTInforme.Add(oCamposDet);
                            }
                        }
                        //Estado Documento
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.CODIGO = dr.GetString(dr.GetOrdinal("CODIGO"));
                                oCamposDet.DESCRIPCION = dr.GetString(dr.GetOrdinal("DESCRIPCION"));
                                oCampos.ListIndicador.Add(oCamposDet);
                            }
                        }
                        //Listado de especies
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.CODIGO = dr.GetString(dr.GetOrdinal("CODIGO"));
                                oCamposDet.DESCRIPCION = dr.GetString(dr.GetOrdinal("DESCRIPCION"));
                                oCampos.ListMComboEspecies.Add(oCamposDet);
                            }
                        }
                    }
                }
                return oCampos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Ent_IMEDIDA_EXPEDIENTE> RegListExpediente(OracleConnection cn, CEntidad oCEntidad)
        {
            List<Ent_IMEDIDA_EXPEDIENTE> olExpediente = new List<Ent_IMEDIDA_EXPEDIENTE>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spGeneral_Listar", oCEntidad))
                {
                    if (dr != null)
                    {
                        Ent_IMEDIDA_EXPEDIENTE oCamposDet;

                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCamposDet = new Ent_IMEDIDA_EXPEDIENTE();
                                oCamposDet.COD_RESODIREC = dr.GetString(dr.GetOrdinal("COD_RESODIREC"));
                                oCamposDet.NUM_RESOLUCION = dr.GetString(dr.GetOrdinal("NUM_RESOLUCION"));
                                oCamposDet.TIPO_RESOLUCION = dr.GetString(dr.GetOrdinal("TIPO_RESOLUCION"));
                                oCamposDet.NUM_EXPEDIENTE = dr.GetString(dr.GetOrdinal("NUM_EXPEDIENTE"));
                                oCamposDet.NUM_THABILITANTE = dr.GetString(dr.GetOrdinal("NUM_THABILITANTE"));
                                oCamposDet.TITULAR = dr.GetString(dr.GetOrdinal("TITULAR"));
                                oCamposDet.MODALIDAD = dr.GetString(dr.GetOrdinal("MODALIDAD"));

                                olExpediente.Add(oCamposDet);
                            }
                        }
                    }
                }
                return olExpediente;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Ent_IMEDIDA_EXP_MEDIDA> RegListMedida(OracleConnection cn, Ent_IMEDIDA_EXP_MEDIDA oCEntidad)
        {
            List<Ent_IMEDIDA_EXP_MEDIDA> olMedida = new List<Ent_IMEDIDA_EXP_MEDIDA>();

            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spIMEDIDA_EXP_MEDIDA_Listar", oCEntidad))
                {
                    if (dr != null)
                    {
                        Ent_IMEDIDA_EXP_MEDIDA oCamposDet;

                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCamposDet = new Ent_IMEDIDA_EXP_MEDIDA();
                                oCamposDet.COD_INFORME = dr.GetString(dr.GetOrdinal("COD_INFORME"));
                                oCamposDet.COD_RESODIREC = dr.GetString(dr.GetOrdinal("COD_RESODIREC"));
                                oCamposDet.COD_RESODIREC_MEDIDA = dr.GetString(dr.GetOrdinal("COD_RESODIREC_MEDIDA"));
                                oCamposDet.NUM_RESOLUCION_MEDIDA = dr.GetString(dr.GetOrdinal("NUM_RESOLUCION_MEDIDA"));
                                oCamposDet.COD_MEDIDA = dr.GetInt32(dr.GetOrdinal("COD_MEDIDA"));
                                oCamposDet.MEDIDA = dr.GetString(dr.GetOrdinal("MEDIDA"));
                                oCamposDet.ASOCIADO = dr.GetBoolean(dr.GetOrdinal("ASOCIADO"));
                                oCamposDet.TXT_ASOCIADO = (dr.GetBoolean(dr.GetOrdinal("ASOCIADO"))==true)?"SI":"NO";
                                oCamposDet.PLAZO_POST_MES = dr.GetInt32(dr.GetOrdinal("PLAZO_POST_MES"));
                                oCamposDet.PLAZO_POST_DIA = dr.GetInt32(dr.GetOrdinal("PLAZO_POST_DIA"));
                                oCamposDet.PLAZO_POST_ANIO = dr.GetInt32(dr.GetOrdinal("PLAZO_POST_ANIO"));
                                oCamposDet.PLAZO_INF_MES = dr.GetInt32(dr.GetOrdinal("PLAZO_INF_MES"));
                                oCamposDet.PLAZO_INF_DIA = dr.GetInt32(dr.GetOrdinal("PLAZO_INF_DIA"));
                                oCamposDet.PLAZO_INF_ANIO = dr.GetInt32(dr.GetOrdinal("PLAZO_INF_ANIO"));
                                oCamposDet.PLAZO_IMPL_MES = dr.GetInt32(dr.GetOrdinal("PLAZO_IMPL_MES"));
                                oCamposDet.PLAZO_IMPL_DIA = dr.GetInt32(dr.GetOrdinal("PLAZO_IMPL_DIA"));
                                oCamposDet.PLAZO_IMPL_ANIO = dr.GetInt32(dr.GetOrdinal("PLAZO_IMPL_ANIO"));

                                olMedida.Add(oCamposDet);
                            }
                        }
                    }
                }
                return olMedida;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public List<Dictionary<string, string>> ReporteInformeMedidaCorrectiva(OracleConnection cn, CEntidad oCEntidad)
        {
            List<Dictionary<string, string>> lstResult = new List<Dictionary<string, string>>();

            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spReporteInformeMedidaCorrectiva", oCEntidad))
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
                                    sFila.Add(sColumn, dr[sColumn].ToString());
                                }
                                lstResult.Add(sFila);
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public CEntidad RegMostrarExpediente_BuscarDatos(OracleConnection cn, CEntidad oCEntidad)
        {
            CEntidad busqueda = new CEntidad();
            busqueda.ListBusqueda = new List<Ent_IMEDIDA_EXPEDIENTE>();

            List<Ent_IMEDIDA_EXPEDIENTE> lsCEntidad = new List<Ent_IMEDIDA_EXPEDIENTE>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spGeneral_Listar_Paging", oCEntidad))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            Ent_IMEDIDA_EXPEDIENTE oCampos;
                            while (dr.Read())
                            {
                                oCampos = new Ent_IMEDIDA_EXPEDIENTE();
                                oCampos.COD_RESODIREC = dr["COD_RESODIREC"].ToString();
                                oCampos.NUM_RESOLUCION = dr["NUM_RESOLUCION"].ToString();
                                oCampos.TIPO_RESOLUCION = dr["TIPO_RESOLUCION"].ToString();
                                oCampos.NUM_EXPEDIENTE = dr["NUM_EXPEDIENTE"].ToString();
                                oCampos.NUM_THABILITANTE = dr["NUM_THABILITANTE"].ToString();
                                oCampos.TITULAR = dr["TITULAR"].ToString();
                                oCampos.MODALIDAD = dr["MODALIDAD"].ToString();
                                lsCEntidad.Add(oCampos);
                            }
                        }

                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                busqueda.v_row_index = Int32.Parse(dr["ROWCOUNT"].ToString());
                            }
                        }
                    }
                }
                busqueda.ListBusqueda = lsCEntidad;
                return busqueda;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public List<CEntidad> ReporteSeguimientoMCorrectiva(OracleConnection cn, CEntidad oCEntidad)
        //{
        //    List<CEntidad> olRegistros = new List<CEntidad>();

        //    try
        //    {
        //        using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spReporteSeguimientoMedidasCorrectivas", oCEntidad))
        //        {
        //            if (dr != null)
        //            {
        //                CEntidad oCamposDet;

        //                if (dr.HasRows)
        //                {
        //                    while (dr.Read())
        //                    {
        //                        oCamposDet = new CEntidad();
        //                        oCamposDet.OD = dr.GetString(dr.GetOrdinal("OD_AMBITO"));
        //                        oCamposDet.MODALIDAD = dr.GetString(dr.GetOrdinal("MODALIDAD"));
        //                        oCamposDet.DEPARTAMENTO = dr.GetString(dr.GetOrdinal("DEPARTAMENTO"));
        //                        oCamposDet.PROVINCIA = dr.GetString(dr.GetOrdinal("PROVINCIA"));
        //                        oCamposDet.DISTRITO = dr.GetString(dr.GetOrdinal("DISTRITO"));

        //                        oCamposDet.TITULAR = dr.GetString(dr.GetOrdinal("TITULAR"));
        //                        oCamposDet.NUM_THABILITANTE = dr.GetString(dr.GetOrdinal("NUM_THABILITANTE"));
        //                        oCamposDet.NUM_DOCUMENTO = dr.GetString(dr.GetOrdinal("NUM_DOCUMENTO"));
        //                        oCamposDet.MCORRECTIVA = dr.GetString(dr.GetOrdinal("MCORRECTIVA"));
        //                        oCamposDet.MCORRECTIVA_RDREC = dr.GetString(dr.GetOrdinal("MCORRECTIVA_RDREC"));
        //                        oCamposDet.MCORRECTIVA_RTFFS = dr.GetString(dr.GetOrdinal("MCORRECTIVA_RTFFS"));
        //                        oCamposDet.FECHA_NOTIFICACION = dr.GetString(dr.GetOrdinal("FECHA_NOTIFICACION"));
        //                        oCamposDet.PLAZO_IMPLEMENTACION = dr.GetString(dr.GetOrdinal("PLAZO_IMPLEMENTACION"));
        //                        oCamposDet.PLAZO_INFORME = dr.GetString(dr.GetOrdinal("PLAZO_INFORME"));
        //                        oCamposDet.ESTADO_PAU = dr.GetString(dr.GetOrdinal("ESTADO_PAU"));
        //                        oCamposDet.CUENTA_INFORME = dr.GetString(dr.GetOrdinal("CUENTA_INFORME"));
        //                        oCamposDet.FECHA_INFORME = dr.GetString(dr.GetOrdinal("FECHA_INFORME"));
        //                        oCamposDet.NUMERO = dr.GetString(dr.GetOrdinal("INFORME_VERIFICACION"));
        //                        oCamposDet.VARIA_MCORRECTIVA = dr.GetString(dr.GetOrdinal("VARIA_MCORRECTIVA"));
        //                        oCamposDet.NUM_RDREC = dr.GetString(dr.GetOrdinal("NUM_RDREC"));
        //                        oCamposDet.NUM_RTFFS = dr.GetString(dr.GetOrdinal("NUM_RTFFS"));
        //                        olRegistros.Add(oCamposDet);
        //                    }
        //                }
        //            }
        //        }
        //        return olRegistros;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
    }
}