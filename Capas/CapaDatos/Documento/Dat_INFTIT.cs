using GeneralSQL;//using SQL = GeneralSQL.Data.SQL;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;//using System.Data.SqlClient;
using CEntidadC = CapaEntidad.DOC.Ent_INFTIT;

namespace CapaDatos.DOC
{
    /// <summary>
    /// 
    /// </summary>
    public class Dat_INFTIT
    {
        private DBOracle dBOracle = new DBOracle(); //private SQL dBOracle = new SQL();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public List<CEntidadC> RegMostrarINFTIT_Buscar(OracleConnection cn, CEntidadC oCEntidad)
        {
            List<CEntidadC> lsCEntidad = new List<CEntidadC>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spGeneral_Listar", oCEntidad))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            CEntidadC oCampos;
                            while (dr.Read())
                            {
                                oCampos = new CEntidadC();
                                oCampos.COD_INFORME = dr["COD_INFORME"].ToString();
                                oCampos.COD_RESODIREC = dr["COD_RESODIREC"].ToString();
                                oCampos.COD_RESODIREC_INI_PAU = dr["COD_RESODIREC_INI_PAU"].ToString();
                                oCampos.NUMERO = dr["NUMERO"].ToString();
                                oCampos.D_LINEA = dr["D_LINEA"].ToString();
                                oCampos.NUM_THABILITANTE = dr["NUM_THABILITANTE"].ToString();
                                oCampos.TITULAR = dr["TITULAR"].ToString();
                                oCampos.COD_PMANEJO = dr["COD_PMANEJO"].ToString();
                                oCampos.NUM_POA = dr.GetInt32(dr.GetOrdinal("NUM_POA"));
                                oCampos.COD_THABILITANTE = dr["COD_THABILITANTE"].ToString();
                                oCampos.MEDIDAS_CAUTELARES = dr["MEDIDAS_CAUTELARES"].ToString();
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public String RegGrabaInfTitular(OracleConnection cn, CEntidadC oCEntidad)
        {
            OracleTransaction tr = null;
            String OUTPUTPARAM01 = "";
            //String OUTPUTPARAM02 = "";
            CEntidadC oCamposDet;

            try
            {
                tr = cn.BeginTransaction();
                //Grabando Cabecera
                using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spINFTIT_Grabar", oCEntidad))
                {
                    cmd.ExecuteNonQuery();
                    OUTPUTPARAM01 = (String)cmd.Parameters["OUTPUTPARAM01"].Value;
                    //OUTPUTPARAM02 = (String)cmd.Parameters["@OUTPUTPARAM02"].Value;
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
                        throw new Exception("El Número Información del Titular del descargo ya existe");
                    }
                    else if (OUTPUTPARAM01 == "1")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("El Número de Información del Titular del descargo existe en otro Registro");
                    }
                    else if (OUTPUTPARAM01 == "2")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("No Tiene Permisos para Modificar este documento presentado por el titular");
                    }
                    else if (OUTPUTPARAM01 == "3")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("Está con Control de Calidad, no puede modificar");
                    }
                }
                //Reemplazando El Nuevo Codigo Creado

                if (oCEntidad.RegEstado == 1) //Nuevo
                {
                    oCEntidad.COD_INFTIT = OUTPUTPARAM01;
                    //oCEntidad.COD_INFTIT_DESCARGOS = OUTPUTPARAM02;
                }
                if (oCEntidad.ListEliTABLA != null)
                {
                    foreach (var loDatos in oCEntidad.ListEliTABLA)
                    {
                        oCamposDet = new CEntidadC();
                        oCamposDet.COD_INFTIT = OUTPUTPARAM01;
                        oCamposDet.EliTABLA = loDatos.EliTABLA;
                        oCamposDet.EliVALOR01 = loDatos.EliVALOR01;
                        oCamposDet.EliVALOR02 = loDatos.EliVALOR02;
                        oCamposDet.COD_INFORME = loDatos.COD_INFORME;
                        oCamposDet.COD_ILEGAL = loDatos.COD_ILEGAL;
                        oCamposDet.COD_RESODIREC = loDatos.COD_RESODIREC;
                        oCamposDet.COD_RESODIREC_INI_PAU = loDatos.COD_RESODIREC_INI_PAU;
                        dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spINFTITEliminarDetalle", oCamposDet);
                    }
                }
                if (oCEntidad.ListInformes != null)
                {
                    foreach (var loDatos in oCEntidad.ListInformes)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            oCamposDet = new CEntidadC();
                            oCamposDet.COD_INFTIT = OUTPUTPARAM01;
                            oCamposDet.RegEstado = 1;

                            loDatos.COD_RESODIREC = (loDatos.COD_RESODIREC == null) ? "" : loDatos.COD_RESODIREC;
                            loDatos.COD_RESODIREC_INI_PAU = (loDatos.COD_RESODIREC_INI_PAU == null) ? "" : loDatos.COD_RESODIREC_INI_PAU;
                            loDatos.COD_THABILITANTE = (loDatos.COD_THABILITANTE == null) ? "" : loDatos.COD_THABILITANTE;
                            loDatos.COD_PMANEJO = (loDatos.COD_PMANEJO == null) ? "" : loDatos.COD_PMANEJO;
                            loDatos.COD_INFORME = (loDatos.COD_INFORME == null) ? "" : loDatos.COD_INFORME;
                            loDatos.COD_ILEGAL = (loDatos.COD_ILEGAL == null) ? "" : loDatos.COD_ILEGAL;

                            if (loDatos.COD_RESODIREC != "" && loDatos.COD_RESODIREC_INI_PAU != "")
                            {
                                oCamposDet.COD_RESODIREC_INI_PAU = loDatos.COD_RESODIREC_INI_PAU;
                                oCamposDet.COD_RESODIREC = loDatos.COD_RESODIREC;
                                dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spINFTIT_DET_EXP_Grabar", oCamposDet);
                            }
                            else if (loDatos.COD_RESODIREC != "")
                            {
                                oCamposDet.COD_RESODIREC = loDatos.COD_RESODIREC;
                                dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spINFTIT_VS_RD_Grabar", oCamposDet);
                            }
                            else if (loDatos.NUM_POA != 0 && loDatos.NUM_POA != -1 && loDatos.COD_THABILITANTE != "")
                            {
                                oCamposDet.COD_UCUENTA = oCEntidad.COD_UCUENTA;
                                oCamposDet.COD_THABILITANTE = loDatos.COD_THABILITANTE;
                                oCamposDet.NUM_POA = loDatos.NUM_POA;
                                dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spINFTIT_POA_Grabar", oCamposDet);
                            }
                            else if (loDatos.COD_THABILITANTE != "")
                            {
                                oCamposDet.COD_UCUENTA = oCEntidad.COD_UCUENTA;
                                oCamposDet.COD_THABILITANTE = loDatos.COD_THABILITANTE;
                                dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spINFTIT_VS_TH_Grabar", oCamposDet);
                            }
                            else if (loDatos.COD_PMANEJO != "")
                            {
                                oCamposDet.COD_UCUENTA = oCEntidad.COD_UCUENTA;
                                oCamposDet.COD_PMANEJO = loDatos.COD_PMANEJO;
                                dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spINFTIT_PLAN_MANEJO_Grabar", oCamposDet);
                            }
                            else if (loDatos.COD_INFORME != "")
                            {
                                oCamposDet.COD_INFORME = loDatos.COD_INFORME;
                                dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spINFTIT__DET_INFORME_Grabar", oCamposDet);
                            }
                            else if (loDatos.COD_ILEGAL != "")
                            {
                                oCamposDet.COD_INFORME = loDatos.COD_ILEGAL;
                                dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spINFTIT__DET_ILEGAL_Grabar", oCamposDet);
                            }
                        }
                    }
                }
                if (oCEntidad.ListProfesionalFirma != null)
                {
                    foreach (var loDatos in oCEntidad.ListProfesionalFirma)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            oCamposDet = new CEntidadC();
                            //    oCamposDet.COD_SECUENCIAL = 0;
                            oCamposDet.COD_PERSONA = loDatos.COD_PERSONA;
                            oCamposDet.COD_PTIPO = loDatos.COD_PTIPO;
                            oCamposDet.COD_INFTIT = OUTPUTPARAM01;
                            oCamposDet.RegEstado = 1;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spINFTIT_DET_PERSONAFIRMAGrabar", oCamposDet);
                        }
                    }
                }
                tr.Commit();
                //return OUTPUTPARAM01 + '|' + OUTPUTPARAM02;
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
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public CEntidadC RegMostrarListaInfTitItem(OracleConnection cn, CEntidadC oCEntidad)
        {
            CEntidadC lsCEntidad = new CEntidadC();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spINFTITMostrarItems", oCEntidad))
                {
                    if (dr != null)
                    {
                        lsCEntidad.ListProfesionalFirma = new List<CEntidadC>();
                        lsCEntidad.ListInformes = new List<CEntidadC>();
                        lsCEntidad.ListEliTABLA = new List<CEntidadC>();
                        //CEntPresupSuper ocampodet;
                        CEntidadC ocampoEnt;

                        if (dr.HasRows)
                        {
                            dr.Read();
                            lsCEntidad.COD_FCTIPO = dr.GetString(dr.GetOrdinal("COD_FCTIPO"));
                            lsCEntidad.TIPO_FISCALIZA = dr.GetString(dr.GetOrdinal("TIPO_FISCALIZA"));
                            lsCEntidad.COD_UBIGEO = dr.GetString(dr.GetOrdinal("COD_UBIGEO"));
                            lsCEntidad.UBIGEO = dr.GetString(dr.GetOrdinal("UBIGEO"));
                            lsCEntidad.COD_PERSONA = dr.GetString(dr.GetOrdinal("COD_PERSONA"));
                            lsCEntidad.APELLIDOS_NOMBRES = dr.GetString(dr.GetOrdinal("APELLIDOS_NOMBRES"));
                            lsCEntidad.NUMERO_INFTIT = dr.GetString(dr.GetOrdinal("NUMERO_INFTIT"));
                            lsCEntidad.FECHA_PRESENTACION = dr.GetString(dr.GetOrdinal("FECHA_PRESENTACION"));
                            lsCEntidad.FECHA_EMISION = dr.GetString(dr.GetOrdinal("FECHA_EMISION"));
                            lsCEntidad.DESCRIPCION = dr.GetString(dr.GetOrdinal("DESCRIPCION"));

                            lsCEntidad.TELEFONO = dr.GetString(dr.GetOrdinal("TELEFONO"));
                            lsCEntidad.COD_UBIGEO_DESCARGO = dr.GetString(dr.GetOrdinal("COD_UBIGEO_DESCARGO"));
                            lsCEntidad.UBIGEO_DESCARGO = dr.GetString(dr.GetOrdinal("UBIGEO_DESCARGO"));
                            lsCEntidad.DIRECCION = dr.GetString(dr.GetOrdinal("DIRECCION"));
                            lsCEntidad.CORREO_ELECTRONICO = dr.GetString(dr.GetOrdinal("CORREO_ELECTRONICO"));
                            lsCEntidad.COD_INFTIT_DESCARGO_TIPO = dr.GetString(dr.GetOrdinal("COD_INFTIT_DESCARGO_TIPO"));
                            lsCEntidad.FUNDAMENTOS_PRESENTADOS = dr.GetString(dr.GetOrdinal("FUNDAMENTOS_PRESENTADOS"));
                            lsCEntidad.NULIDAD = dr.GetBoolean(dr.GetOrdinal("NULIDAD"));
                            lsCEntidad.OBSERV_NULIDAD = dr.GetString(dr.GetOrdinal("OBSERV_NULIDAD"));

                            lsCEntidad.NUMERO_CUOTAS = dr.GetInt32(dr.GetOrdinal("NUMERO_CUOTAS"));
                            lsCEntidad.MONTO_CUOTA = dr.GetDecimal(dr.GetOrdinal("MONTO_CUOTA"));
                            lsCEntidad.FECHA_INICIO = dr.GetString(dr.GetOrdinal("FECHA_INICIO"));
                            lsCEntidad.FECHA_FIN = dr.GetString(dr.GetOrdinal("FECHA_FIN"));

                            lsCEntidad.COD_OD_REGISTRO = dr.GetString(dr.GetOrdinal("COD_OD_REGISTRO"));
                            lsCEntidad.DOMICILIO_PROCESAL = dr.GetString(dr.GetOrdinal("DOMICILIO_PROCESAL"));
                            lsCEntidad.AUDIENCIA_ORAL = dr.GetBoolean(dr.GetOrdinal("AUDIENCIA_ORAL"));
                            lsCEntidad.COD_PARENTESCO = dr.GetString(dr.GetOrdinal("COD_PARENTESCO"));
                            lsCEntidad.FIRMA_LEGALIZADA = dr.GetBoolean(dr.GetOrdinal("FIRMA_LEGALIZADA"));
                            lsCEntidad.APELAR_MEDCAUT = dr.GetBoolean(dr.GetOrdinal("APELAR_MEDCAUT"));

                            lsCEntidad.IMPROCEDENCIA = dr.GetBoolean(dr.GetOrdinal("IMPROCEDENCIA"));
                            lsCEntidad.DOCUMENTO_IMPROCEDENCIA = dr.GetString(dr.GetOrdinal("DOCUMENTO_IMPROCEDENCIA"));
                            lsCEntidad.FECHA_IMPROCEDENCIA = dr.GetString(dr.GetOrdinal("FECHA_IMPROCEDENCIA"));
                            lsCEntidad.USUARIO_REGISTRO = dr.GetString(dr.GetOrdinal("USUARIO_REGISTRO"));

                        }
                        //Estado (Calidad)
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            dr.Read();
                            lsCEntidad.COD_ESTADO_DOC = dr.GetString(dr.GetOrdinal("COD_ESTADO_DOC"));
                            lsCEntidad.OBSERVACIONES_CONTROL = dr.GetString(dr.GetOrdinal("OBSERVACIONES_CONTROL"));
                            lsCEntidad.OBSERV_SUBSANAR = dr.GetBoolean(dr.GetOrdinal("OBSERV_SUBSANAR"));
                            lsCEntidad.USUARIO_CONTROL = dr.GetString(dr.GetOrdinal("USUARIO_CONTROL"));
                        }
                        else
                        {
                            lsCEntidad.COD_ESTADO_DOC = "";
                            lsCEntidad.OBSERVACIONES_CONTROL = "";
                            lsCEntidad.OBSERV_SUBSANAR = false;
                            lsCEntidad.USUARIO_CONTROL = "";
                        }

                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidadC();
                                ocampoEnt.COD_INFORME = dr["COD_INFORME"].ToString();
                                ocampoEnt.NUMERO = dr["NUMERO"].ToString();
                                ocampoEnt.D_LINEA = dr["D_LINEA"].ToString();
                                ocampoEnt.NUM_THABILITANTE = dr["NUM_THABILITANTE"].ToString();
                                ocampoEnt.TITULAR = dr["TITULAR"].ToString().Replace("\"", "'");
                                ocampoEnt.COD_RESODIREC = dr["COD_RESODIREC"].ToString();
                                ocampoEnt.COD_RESODIREC_INI_PAU = dr["COD_RESODIREC_INI_PAU"].ToString();
                                ocampoEnt.COD_PMANEJO = dr["COD_PMANEJO"].ToString();
                                ocampoEnt.NUM_POA = dr.GetInt32(dr.GetOrdinal("NUM_POA"));
                                ocampoEnt.COD_THABILITANTE = dr["COD_THABILITANTE"].ToString();
                                ocampoEnt.RegEstado = 0;
                                lsCEntidad.ListInformes.Add(ocampoEnt);
                            }
                        }
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidadC();
                                ocampoEnt.COD_PERSONA = dr["COD_PERSONA"].ToString();
                                ocampoEnt.PERSONAFIRMA = dr["PERSONAFIRMA"].ToString();
                                ocampoEnt.COD_PTIPO = dr["COD_PTIPO"].ToString();
                                ocampoEnt.PERSONATIPO = dr["PERSONATIPO"].ToString();
                                ocampoEnt.COD_SECUENCIAL = Int32.Parse(dr["COD_SECUENCIAL"].ToString());
                                ocampoEnt.RegEstado = 0;
                                lsCEntidad.ListProfesionalFirma.Add(ocampoEnt);
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public List<Dictionary<string, string>> ReporteInformeTitular(OracleConnection cn, CEntidadC oCEntidad)
        {
            List<Dictionary<string, string>> lstResult = new List<Dictionary<string, string>>();

            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spReporteFiscalizacionInformacion_titular", oCEntidad))
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
        public CEntidadC RegMostCombo(OracleConnection cn, CEntidadC oCEntidad)
        {
            CEntidadC oCampos = null;
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spGeneral_Combo_Listar", oCEntidad))
                {
                    if (dr != null)
                    {
                        oCampos = new CEntidadC();
                        List<CEntidadC> lsDetDetalle;
                        CEntidadC oCamposDet;
                        //
                        //01 Modalidad
                        lsDetDetalle = new List<CEntidadC>();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                //
                                oCamposDet = new CEntidadC();
                                oCamposDet.CODIGO = dr["CODIGO"].ToString();
                                oCamposDet.DESCRIPCION = dr["DESCRIPCION"].ToString();
                                lsDetDetalle.Add(oCamposDet);
                            }
                        }
                        oCampos.ListMComboCategoria = lsDetDetalle;
                        //02 Documento Identidad
                        dr.NextResult();
                        lsDetDetalle = new List<CEntidadC>();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidadC();
                                oCamposDet.CODIGO = dr["CODIGO"].ToString();
                                oCamposDet.DESCRIPCION = dr["DESCRIPCION"].ToString();
                                lsDetDetalle.Add(oCamposDet);
                            }
                        }
                        oCampos.ListMComboDIdentidad = lsDetDetalle;
                        //03 Estado Documento
                        dr.NextResult();
                        lsDetDetalle = new List<CEntidadC>();
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("CODIGO");
                            int pt2 = dr.GetOrdinal("DESCRIPCION");
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidadC();
                                oCamposDet.CODIGO = dr.GetString(pt1);
                                oCamposDet.DESCRIPCION = dr.GetString(pt2);
                                lsDetDetalle.Add(oCamposDet);
                            }
                        }
                        oCampos.ListIndicador = lsDetDetalle;
                        //04 Oficina Desconcentrada
                        dr.NextResult();
                        lsDetDetalle = new List<CEntidadC>();
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("CODIGO");
                            int pt2 = dr.GetOrdinal("DESCRIPCION");
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidadC();
                                oCamposDet.CODIGO = dr.GetString(pt1);
                                oCamposDet.DESCRIPCION = dr.GetString(pt2);
                                lsDetDetalle.Add(oCamposDet);
                            }
                        }
                        oCampos.ListMComboOD = lsDetDetalle;
                        //05 Tipo de Carta de Notificación
                        dr.NextResult();
                        lsDetDetalle = new List<CEntidadC>();
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("CODIGO");
                            int pt2 = dr.GetOrdinal("DESCRIPCION");
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidadC();
                                oCamposDet.CODIGO = dr.GetString(pt1);
                                oCamposDet.DESCRIPCION = dr.GetString(pt2);
                                lsDetDetalle.Add(oCamposDet);
                            }
                        }
                        oCampos.ListTipoCNotificacion = lsDetDetalle;
                    }
                }
                return oCampos;
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
        public CEntidadC RegMostrarListaTipoProfesional(OracleConnection cn, CEntidadC oCEntidad)
        {
            CEntidadC oCampos = null;
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spTipoPersonaProfesional", oCEntidad))
                {
                    if (dr != null)
                    {
                        oCampos = new CEntidadC();
                        List<CEntidadC> lsDetDetalle;
                        CEntidadC oCamposDet;

                        lsDetDetalle = new List<CEntidadC>();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                //PARTE_DIARIO_DETALLE
                                oCamposDet = new CEntidadC();
                                oCamposDet.COD_PTIPO = dr["COD_PTIPO"].ToString();
                                oCamposDet.PERSONATIPO = dr["DESCRIPCION"].ToString();
                                lsDetDetalle.Add(oCamposDet);
                            }
                        }
                        oCampos.ListTipoProfesional = lsDetDetalle;
                    }
                }
                return oCampos;
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
        public CEntidadC RegMostrarINFTIT_BuscarDatos(OracleConnection cn, CEntidadC oCEntidad)
        {
            CEntidadC busqueda = new CEntidadC();
            busqueda.ListBusqueda = new List<CEntidadC>();

            List<CEntidadC> lsCEntidad = new List<CEntidadC>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spGeneral_Listar", oCEntidad))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            CEntidadC oCampos;
                            while (dr.Read())
                            {
                                oCampos = new CEntidadC();
                                oCampos.COD_INFORME = dr["COD_INFORME"].ToString();
                                oCampos.COD_RESODIREC = dr["COD_RESODIREC"].ToString();
                                oCampos.COD_RESODIREC_INI_PAU = dr["COD_RESODIREC_INI_PAU"].ToString();
                                oCampos.NUMERO = dr["NUMERO"].ToString();
                                oCampos.D_LINEA = dr["D_LINEA"].ToString();
                                oCampos.NUM_THABILITANTE = dr["NUM_THABILITANTE"].ToString();
                                oCampos.TITULAR = dr["TITULAR"].ToString();
                                oCampos.COD_PMANEJO = dr["COD_PMANEJO"].ToString();
                                oCampos.NUM_POA = dr.GetInt32(dr.GetOrdinal("NUM_POA"));
                                oCampos.COD_THABILITANTE = dr["COD_THABILITANTE"].ToString();
                                oCampos.MEDIDAS_CAUTELARES = dr["MEDIDAS_CAUTELARES"].ToString();
                                lsCEntidad.Add(oCampos);
                            }
                        }
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                busqueda.v_row_index = Int32.Parse(dr["TOTALROW"].ToString());
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public CEntidadC RegMostrarListaTipoDescargo(OracleConnection cn, CEntidadC oCEntidad)
        {
            CEntidadC oCampos = null;
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spINFTITTipoDescargoListar", oCEntidad))
                {
                    if (dr != null)
                    {
                        oCampos = new CEntidadC();
                        List<CEntidadC> lsDetDetalle;
                        CEntidadC oCamposDet;

                        lsDetDetalle = new List<CEntidadC>();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                //PARTE_DIARIO_DETALLE
                                oCamposDet = new CEntidadC();
                                oCamposDet.COD_INFTIT_DESCARGO_TIPO = dr["COD_INFTIT_DESCARGO_TIPO"].ToString();
                                oCamposDet.DESCRIPCION = dr["DESCRIPCION"].ToString();
                                lsDetDetalle.Add(oCamposDet);
                            }
                        }
                        oCampos.ListTipoDescargo = lsDetDetalle;
                    }
                }
                return oCampos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
