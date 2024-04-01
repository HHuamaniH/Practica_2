using System;
using System.Collections.Generic;
using Oracle.ManagedDataAccess.Client;//using System.Data.SqlClient;
using CEntidadC = CapaEntidad.DOC.Ent_INFFUN;
using GeneralSQL;//using SQL = GeneralSQL.Data.SQL;
using CapaEntidad.Documento;
using GeneralSQL.Data;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos.DOC
{
    /// <summary>
    /// 
    /// </summary>
    public class Dat_INFFUN
    {
        private DBOracle dBOracle = new DBOracle();//private SQL dBOracle = new SQL();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public List<CEntidadC> RegMostrarINFFUN_Buscar(OracleConnection cn, CEntidadC oCEntidad)
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
        public String RegGrabaInfFundamentado(OracleConnection cn, CEntidadC oCEntidad)
        {
            OracleTransaction tr = null;
            String OUTPUTPARAM01 = "";
            String OUTPUTPARAM02 = "";
            CEntidadC oCamposDet;

            try
            {
                tr = cn.BeginTransaction();
                //Grabando Cabecera
                using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.SPINFFUNGRABAR_V2", oCEntidad))
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
                        throw new Exception("El Número del Informe Fundamentado  ya existe");
                    }
                    else if (OUTPUTPARAM01 == "1")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("El Número de Informe Fundamentado existe en otro Registro");
                    }
                    else if (OUTPUTPARAM01 == "2")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("No Tiene Permisos para Modificar este informe fundamentado");
                    }
                    else if (OUTPUTPARAM01 == "3")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("Está con Control de Calidad, no puede modificar");
                    }
                    else if (OUTPUTPARAM01 == "4")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("El Número de Registro del SITD ya existe");
                    }
                    else if (OUTPUTPARAM01 == "5")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("El Número de Registro del SITD existe en otro Registro");
                    }
                }
                //Reemplazando El Nuevo Codigo Creado

                if (oCEntidad.RegEstado == 1) //Nuevo
                {
                    oCEntidad.COD_INFFUN = OUTPUTPARAM01;
                }
                if (oCEntidad.ListEliTABLA != null)
                {
                    foreach (var loDatos in oCEntidad.ListEliTABLA)
                    {
                        oCamposDet = new CEntidadC();
                        oCamposDet.COD_INFFUN = OUTPUTPARAM01;
                        oCamposDet.EliTABLA = loDatos.EliTABLA;
                        oCamposDet.EliVALOR01 = loDatos.EliVALOR01;
                        oCamposDet.COD_INFORME = (loDatos.COD_INFORME==null) ? " " : loDatos.COD_INFORME;
                        oCamposDet.COD_RESODIREC = (loDatos.COD_RESODIREC == null) ? " " : loDatos.COD_RESODIREC; 
                        oCamposDet.COD_RESODIREC_INI_PAU = (loDatos.COD_RESODIREC_INI_PAU == null) ? " " : loDatos.COD_RESODIREC_INI_PAU;  
                        dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spINFFUNEliminarDetalle", oCamposDet);
                    }
                }
                if (oCEntidad.ListInformes != null)
                {
                    foreach (var loDatos in oCEntidad.ListInformes)
                    {
                        if (loDatos.RegEstado == 1) //Nuevo
                        {
                            oCamposDet = new CEntidadC();
                            if (loDatos.COD_RESODIREC != null && loDatos.COD_RESODIREC != "" && loDatos.COD_RESODIREC_INI_PAU != null && loDatos.COD_RESODIREC_INI_PAU != "")
                            {
                                oCamposDet.COD_RESODIREC_INI_PAU = loDatos.COD_RESODIREC_INI_PAU;
                                oCamposDet.COD_RESODIREC = loDatos.COD_RESODIREC;
                                oCamposDet.COD_INFFUN = OUTPUTPARAM01;
                                oCamposDet.RegEstado = 1;
                                dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spINFFUN_VS_INI_PAU_Grabar", oCamposDet);
                            }
                            else if (loDatos.COD_INFORME != "")
                            {
                                oCamposDet.COD_INFORME = loDatos.COD_INFORME;
                                oCamposDet.COD_INFFUN = OUTPUTPARAM01;
                                oCamposDet.RegEstado = 1;
                                dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spINFFUN_INFORME_Grabar", oCamposDet);
                            }
                        }
                    }
                }
                if (oCEntidad.ListarEntidades != null)
                {
                    foreach (var loDatos in oCEntidad.ListarEntidades)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            oCamposDet = new CEntidadC();
                            //  oCamposDet.COD_SECUENCIAL = 0;
                            oCamposDet.COD_SENTIDAD = loDatos.COD_SENTIDAD;
                            oCamposDet.COD_INFFUN = OUTPUTPARAM01;
                            oCamposDet.RegEstado = 1;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spINFFUN_DETALLE_Grabar", oCamposDet);
                        }
                    }
                }
                if (oCEntidad.ListProfesionales != null)
                {
                    foreach (var loDatos in oCEntidad.ListProfesionales)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2)
                        {
                            oCamposDet = new CEntidadC();
                            oCamposDet.COD_PERSONA = loDatos.COD_PERSONA;
                            oCamposDet.COD_INFFUN = OUTPUTPARAM01;
                            oCamposDet.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spINFFUN_PROFESIONAL_Grabar", oCamposDet);
                        }
                    }
                }
                tr.Commit();



                return OUTPUTPARAM01 + '|' + OUTPUTPARAM02;
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
        /// 

        public String RegActualizaInfFundamentado(OracleConnection cn, string codigo)
        {
            OracleTransaction tr = null;
            CEntidadC oCamposDet;

            try
            {
                tr = cn.BeginTransaction();

                oCamposDet = new CEntidadC();
                oCamposDet.COD_INFFUN = codigo;
                oCamposDet.RegEstado = 1;
                dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spINFFUN_INFORME_ACTUALIZA", oCamposDet);

                tr.Commit();

                return codigo;
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
        public CEntidadC RegMostrarListaInfFunItem(OracleConnection cn, CEntidadC oCEntidad)
        {
            CEntidadC lsCEntidad = new CEntidadC();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spINFFUNMostrarItems", oCEntidad))
                {
                    if (dr != null)
                    {
                        lsCEntidad.ListInformes = new List<CEntidadC>();
                        lsCEntidad.ListarEntidades = new List<CEntidadC>();
                        lsCEntidad.ListProfesionales = new List<CEntidadC>();

                        //CEntPresupSuper ocampodet;
                        CEntidadC ocampoEnt;

                        if (dr.HasRows)
                        {
                            dr.Read();
                            lsCEntidad.COD_FCTIPO = dr.GetString(dr.GetOrdinal("COD_FCTIPO"));
                            lsCEntidad.NUMERO_INFORME = dr.GetString(dr.GetOrdinal("NUMERO_INFORME"));
                            lsCEntidad.COD_PERSONA = dr.GetString(dr.GetOrdinal("COD_PERSONA"));
                            lsCEntidad.APELLIDOS_NOMBRES = dr.GetString(dr.GetOrdinal("APELLIDOS_NOMBRES"));
                            //lsCEntidad.TIPO = dr.GetString(dr.GetOrdinal("TIPO"));
                            lsCEntidad.TIPO_FISCALIZA = dr.GetString(dr.GetOrdinal("TIPO_FISCALIZA"));
                            lsCEntidad.FECHA_EMISION = dr.GetString(dr.GetOrdinal("FECHA_EMISION"));
                            //lsCEntidad.FECHA_DERIVACION = dr.GetString(dr.GetOrdinal("FECHA_DERIVACION"));
                            lsCEntidad.CONCLUSIONES = dr.GetString(dr.GetOrdinal("CONCLUSIONES"));
                            lsCEntidad.DESCRIPCION = dr.GetString(dr.GetOrdinal("DESCRIPCION"));
                            lsCEntidad.COD_OD_REGISTRO = dr.GetString(dr.GetOrdinal("COD_OD_REGISTRO"));
                            lsCEntidad.USUARIO_REGISTRO = dr.GetString(dr.GetOrdinal("USUARIO_REGISTRO"));
                            // NUEVOS CAMPOS //
                            lsCEntidad.NUMERO_TRAMITE = dr.GetString(dr.GetOrdinal("NUMERO_REGISTRO"));
                            lsCEntidad.FECHA_TRAMITE = dr.GetString(dr.GetOrdinal("FECHA_SOLICITUD"));
                            lsCEntidad.NUMERO_SOLICITUD = dr.GetString(dr.GetOrdinal("NUMERO_SOLICITUD"));
                            lsCEntidad.COD_TIPO_SOLICITUD = dr.GetString(dr.GetOrdinal("COD_TIPO_SOLICITUD"));
                            lsCEntidad.COD_VEN_LEGAL = dr.GetString(dr.GetOrdinal("COD_VENC_LEGAL"));
                            lsCEntidad.GLOSA = dr.GetString(dr.GetOrdinal("DETALLE"));
                            lsCEntidad.COD_UBIGEO = dr.GetString(dr.GetOrdinal("COD_UBIGEO"));
                            lsCEntidad.ESTAB_UBIGEO = dr.GetString(dr.GetOrdinal("ESTAB_UBIGEO"));
                            lsCEntidad.COD_PERSONA_ASIGNADO = dr.GetString(dr.GetOrdinal("COD_PERSONA_ASIGNADO"));
                            lsCEntidad.PERSONA_TITULAR = dr.GetString(dr.GetOrdinal("PERSONA_TITULAR"));

                            lsCEntidad.FLAG_INFFUN_EMITIDO = dr.GetInt32(dr.GetOrdinal("FLAG_INFFUN_EMITIDO"));
                            lsCEntidad.FECHA_FIRMEZA = dr.GetString(dr.GetOrdinal("FECHA_FIRMEZA"));
                            lsCEntidad.NUMERO_OFICIO1 = dr.GetString(dr.GetOrdinal("NUMERO_OFICIO1"));
                            lsCEntidad.FECHA_OFICIO1 = dr.GetString(dr.GetOrdinal("FECHA_OFICIO1"));

                            lsCEntidad.FLAG_NO_INFUN_EMITIDO = dr.GetInt32(dr.GetOrdinal("FLAG_NO_INFUN_EMITIDO"));
                            lsCEntidad.NUMERO_OFICIO2 = dr.GetString(dr.GetOrdinal("NUMERO_OFICIO2"));
                            lsCEntidad.FECHA_OFICIO2 = dr.GetString(dr.GetOrdinal("FECHA_OFICIO2"));
                            lsCEntidad.NOTA_NO_INFFUN = dr.GetString(dr.GetOrdinal("NOTA_NO_INFFUN"));

                            lsCEntidad.FLAG_COPIA_PAU_EMITIDO = dr.GetInt32(dr.GetOrdinal("FLAG_COPIA_PAU_EMITIDO"));
                            lsCEntidad.NOTA_COPIA_PAU = dr.GetString(dr.GetOrdinal("NOTA_COPIA_PAU"));

                            lsCEntidad.FLAG_NOTIFICACION = dr.GetInt32(dr.GetOrdinal("FLAG_NOTIFICACION"));
                            lsCEntidad.FECHA_NOTIFICACION = dr.GetString(dr.GetOrdinal("FECHA_NOTIFICACION"));
                            lsCEntidad.NOTA_NOTIFICACION = dr.GetString(dr.GetOrdinal("NOTA_NOTIFICACION"));
                            lsCEntidad.CARPETA_FISCAL = dr.GetString(dr.GetOrdinal("CARPETA_FISCAL"));
                            lsCEntidad.COD_PROVEIDOARCH = dr.GetString(dr.GetOrdinal("COD_PROVEIDOARCH"));
                            lsCEntidad.COD_ESTADO_SOLICITUD = dr.GetString(dr.GetOrdinal("COD_ESTADO_SOLICITUD"));
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
                        // Lista de Informe
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
                                ocampoEnt.TITULAR = dr["TITULAR"].ToString();
                                ocampoEnt.COD_RESODIREC = dr["COD_RESODIREC"].ToString();
                                ocampoEnt.COD_RESODIREC_INI_PAU = dr["COD_RESODIREC_INI_PAU"].ToString();
                                ocampoEnt.RegEstado = 0;
                                lsCEntidad.ListInformes.Add(ocampoEnt);
                            }
                        }
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            int pt0 = dr.GetOrdinal("COD_SENTIDAD");
                            int pt1 = dr.GetOrdinal("DESCRIPCION_SUBENTIDAD");
                            int pt2 = dr.GetOrdinal("DESCRIPCION_ENTIDAD");

                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidadC();
                                ocampoEnt.COD_SENTIDAD = dr.GetString(pt0);
                                ocampoEnt.DESCRIPCION_SUBENTIDAD = dr.GetString(pt1);
                                ocampoEnt.DESCRIPCION_ENTIDAD = dr.GetString(pt2);
                                ocampoEnt.RegEstado = 0;
                                lsCEntidad.ListarEntidades.Add(ocampoEnt);
                            }
                        }
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            int pt0 = dr.GetOrdinal("COD_INFFUN");
                            int pt1 = dr.GetOrdinal("COD_PERSONA");
                            int pt2 = dr.GetOrdinal("APELLIDOS_NOMBRES");
                            int pt3 = dr.GetOrdinal("TIPO");
                            int pt4 = dr.GetOrdinal("N_DOCUMENTO");
                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidadC();
                                ocampoEnt.COD_INFFUN = dr.GetString(pt0);
                                ocampoEnt.COD_PERSONA = dr.GetString(pt1);
                                ocampoEnt.APELLIDOS_NOMBRES = dr.GetString(pt2);
                                ocampoEnt.TIPO = dr.GetString(pt3);
                                ocampoEnt.NUMERO = dr.GetString(pt4);
                                ocampoEnt.RegEstado = 0;
                                lsCEntidad.ListProfesionales.Add(ocampoEnt);
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

        public List<Dictionary<string, string>> ReportesInformeFundamentado(OracleConnection cn, CEntidadC oCEntidad)
        {
            List<Dictionary<string, string>> lstResult = new List<Dictionary<string, string>>();

            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spReporteInformeFundamentado", oCEntidad))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            Dictionary<string, string> sFila;
                            switch (oCEntidad.TIPO_REPORTE)
                            {
                                #region Informes fundamentados registrados
                                case "REGISTRO_USUARIO":
                                    while (dr.Read())
                                    {
                                        sFila = new Dictionary<string, string>();
                                        sFila.Add("CODIGO", dr["CODIGO"].ToString());
                                        sFila.Add("NUMERO", dr["NUMERO"].ToString());
                                        sFila.Add("TIPO_FISCALIZA", dr["TIPO_FISCALIZA"].ToString());
                                        sFila.Add("NUMERO_EXPEDIENTE", dr["NUMERO_EXPEDIENTE"].ToString());
                                        sFila.Add("COD_INFORME", dr["COD_INFORME"].ToString());
                                        sFila.Add("NUMERO_INFORME", dr["NUMERO_INFORME"].ToString());
                                        sFila.Add("COD_RESODIREC", dr["COD_RESODIREC"].ToString());
                                        sFila.Add("COD_RPSECUENCIAL", dr["COD_RPSECUENCIAL"].ToString());
                                        sFila.Add("FECHA_CREACION", dr["FECHA_CREACION"].ToString());
                                        sFila.Add("ANIO_REGISTRO", dr["ANIO_REGISTRO"].ToString());
                                        sFila.Add("MES_REGISTRO", dr["MES_REGISTRO"].ToString());
                                        sFila.Add("USUARIO", dr["USUARIO"].ToString());
                                        lstResult.Add(sFila);
                                    }
                                    break;
                                    #endregion
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

        public CEntidadC RegMostrarListaEntidad(OracleConnection cn, CEntidadC oCEntidad)
        {
            CEntidadC oCampos = null;
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.SPINFFUN_ENTIDADESLISTAR", oCEntidad))
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
                                oCamposDet.COD_SENTIDAD = dr["COD_INFFUN_ENTIDADES"].ToString();
                                oCamposDet.DESCRIPCION_ENTIDAD = dr["DESCRIPCION"].ToString();
                                lsDetDetalle.Add(oCamposDet);
                            }
                        }
                        oCampos.ListarEntidades = lsDetDetalle;
                    }
                }
                return oCampos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CEntidadC RegMostrarListaSubEntidad(OracleConnection cn, CEntidadC oCEntidad)
        {
            CEntidadC oCampos = null;
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.SPINFFUN_SUB_ENTIDADESLISTAR", oCEntidad))
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
                                oCamposDet.COD_SENTIDAD = dr["COD_SENTIDAD"].ToString();
                                oCamposDet.DESCRIPCION_SUBENTIDAD = dr["DESCRIPCION"].ToString();
                                lsDetDetalle.Add(oCamposDet);
                            }
                        }
                        oCampos.ListarEntidades = lsDetDetalle;
                    }
                }
                return oCampos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

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
                        //01 01 Modalidad
                        lsDetDetalle = new List<CEntidadC>();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                //PARTE_DIARIO_DETALLE
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

                        //06 Tipo de Solicitud
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
                        oCampos.ListTipoSolicitud = lsDetDetalle;

                        //07 Vencimiento Plazo Legal
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
                        oCampos.ListVencimientoPlazoLegal = lsDetDetalle;

                        //07 Estado Solicitud Fema
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
                        oCampos.ListEstadoSolicitudFema = lsDetDetalle;
                    }
                }
                return oCampos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CEntidadC RegMostrarINFFUN_BuscarDatos(OracleConnection cn, CEntidadC oCEntidad)
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

        public List<Ent_MemoFirmeza> FiltrarMemoFirmeza(OracleConnection cn, string codigoInforme)
        {
            List<Ent_MemoFirmeza> lstentidad = new List<Ent_MemoFirmeza>();
            Ent_MemoFirmeza entidad = null;
            try
            {
                using (OracleCommand command = new OracleCommand("DOC_OSINFOR_ERP_MIGRACION.SPINFFUN_CONSULTAR_MEMO_FIRMEZA", cn))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add("COD_INFORME", OracleDbType.Varchar2).Value = codigoInforme;

                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            entidad = new Ent_MemoFirmeza();
                            while (reader.Read())
                            {
                                if (!reader.IsDBNull(reader.GetOrdinal("FECHA"))) entidad.FECHA = reader.GetString(reader.GetOrdinal("FECHA"));
                                if (!reader.IsDBNull(reader.GetOrdinal("NUMERO_EXPEDIENTE"))) entidad.NUMERO_EXPEDIENTE = reader.GetString(reader.GetOrdinal("NUMERO_EXPEDIENTE"));
                                if (!reader.IsDBNull(reader.GetOrdinal("COD_PROVEIDOARCH"))) entidad.COD_PROVEIDORARCH = reader.GetString(reader.GetOrdinal("COD_PROVEIDOARCH"));
                                entidad.COD_INFORME = reader.GetString(reader.GetOrdinal("COD_INFORME"));
                                lstentidad.Add(entidad);
                            }
                        }
                    }
                }

                return lstentidad;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region "SQL SERVER"

        public Ent_DocumentoEntradaSITD ObtenerDocumentoSITD(string numeroRegistro)
        {
            Ent_DocumentoEntradaSITD entidad = null;
            SQL oGDataSQL = new SQL();

            using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena_SITD()))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand("SP_CONSULTAR_DOC_ENTRADA_SITD", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NRO_DOCUMENTO", numeroRegistro);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader != null)
                            if (reader.Read())
                            {
                                entidad = new Ent_DocumentoEntradaSITD();
                                entidad.iCodTramite = reader.GetInt32(reader.GetOrdinal("iCodTramite"));
                                entidad.cCodificacion = reader.GetString(reader.GetOrdinal("cCodificacion"));
                                entidad.fFecDocumento = reader.GetString(reader.GetOrdinal("fFecDocumento"));
                                entidad.cNroDocumento = reader.GetString(reader.GetOrdinal("cNroDocumento"));
                                entidad.iCodTupa = reader.GetInt32(reader.GetOrdinal("iCodTupa"));
                                entidad.cAsunto = reader.GetString(reader.GetOrdinal("cAsunto"));
                                entidad.cNomRemite = reader.GetString(reader.GetOrdinal("cNomRemite"));
                                entidad.iCodRemitente = reader.GetInt32(reader.GetOrdinal("iCodRemitente"));
                                entidad.cFema = reader.GetString(reader.GetOrdinal("cFema"));

                                if (!reader.IsDBNull(reader.GetOrdinal("cTipoSolicitudFema"))) entidad.cTipoSolicitudFema = reader.GetString(reader.GetOrdinal("cTipoSolicitudFema"));
                                //entidad.cTipoSolicitudFema = reader.GetString(reader.GetOrdinal("cTipoSolicitudFema"));

                            }

                    }
                }
            }
            return entidad;
        }

        public string FiltrarFechaNotificacion(string numeroRegistro)
        {
            string resultado = "";
            SQL oGDataSQL = new SQL();

            using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena_SITD()))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand("SP_CONSULTAR_DOC_SALIDA_SITD", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NRO_DOCUMENTO", numeroRegistro);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader != null)
                            if (reader.Read())
                            {
                                resultado = reader.GetString(reader.GetOrdinal("fechaNotificacion"));
                            }

                    }
                }


            }
            return resultado;
        }

        #endregion

    }
}
