using GeneralSQL;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using CEntidadC = CapaEntidad.DOC.Ent_INFTEC;
using SQL = GeneralSQL.Data.SQL;

namespace CapaDatos.DOC
{
    /// <summary>
    /// 
    /// </summary>
    public class Dat_INFTEC
    {
        private SQL oGDataSQL = new SQL();
        private DBOracle dBOracle = new DBOracle();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        //public List<CEntidadC> RegMostrarINFTEC_Buscar(SqlConnection cn, CEntidadC oCEntidad)
        //{
        //    List<CEntidadC> lsCEntidad = new List<CEntidadC>();
        //    try
        //    {
        //        using (SqlDataReader dr = oGDataSQL.SelDrdResult(cn, null, "DOC.spGeneral_Listar", oCEntidad))
        //        {
        //            if (dr != null)
        //            {
        //                if (dr.HasRows)
        //                {
        //                    CEntidadC oCampos;
        //                    while (dr.Read())
        //                    {
        //                        oCampos = new CEntidadC();
        //                        oCampos.COD_INFORME = dr["COD_INFORME"].ToString();
        //                        oCampos.COD_RESODIREC = dr["COD_RESODIREC"].ToString();
        //                        oCampos.COD_RESODIREC_INI_PAU = dr["COD_RESODIREC_INI_PAU"].ToString();
        //                        oCampos.NUMERO = dr["NUMERO"].ToString();
        //                        oCampos.D_LINEA = dr["D_LINEA"].ToString();
        //                        oCampos.NUM_THABILITANTE = dr["NUM_THABILITANTE"].ToString();
        //                        oCampos.TITULAR = dr["TITULAR"].ToString();
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
                        //Listado de Articulos Incisos
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
                        oCampos.ListComboInciso = lsDetDetalle;
                        //
                        //Listado de Especies
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
                        oCampos.ListComboEspecies = lsDetDetalle;
                        //listado para el nuevo formulario 14/09/2017 Carlos Rios
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
                        oCampos.listacombo = lsDetDetalle;
                        //listado para combo de OD's
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
                        oCampos.ListODs = lsDetDetalle;
                    }
                }
                return oCampos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public String RegGrabaInfTecnico(OracleConnection cn, CEntidadC oCEntidad)
        {
            OracleTransaction tr = null;
            String OUTPUTPARAM01 = "";
            CEntidadC oCamposDet;
            try
            {
                tr = cn.BeginTransaction();
                //Grabando Cabecera
                using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spINFTEC_Grabar", oCEntidad))
                {
                    cmd.ExecuteNonQuery();
                    OUTPUTPARAM01 = cmd.Parameters["OUTPUTPARAM01"].Value is DBNull ? string.Empty : (String)cmd.Parameters["OUTPUTPARAM01"].Value;
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
                        throw new Exception("El Número del Informe Técnico ya existe");
                    }
                    else if (OUTPUTPARAM01 == "1")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("El Número de Informe Técnico existe en otro Registro");
                    }
                    else if (OUTPUTPARAM01 == "2")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("No Tiene Permisos para Modificar este informe técnico");
                    }
                    else if (OUTPUTPARAM01 == "3")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("Está con Control de Calidad, no puede modificar");
                    }
                }
                if (oCEntidad.RegEstado == 1) //Nuevo
                {
                    oCEntidad.COD_INFTEC = OUTPUTPARAM01;
                    //oCEntidad.COD_INFTEC_DETERMINACION_MULTA = OUTPUTPARAM02;

                }
                //Eliminando Detalle
                if (oCEntidad.ListEliTABLA != null)
                {
                    foreach (var loDatos in oCEntidad.ListEliTABLA)
                    {
                        oCamposDet = new CEntidadC();
                        oCamposDet.COD_INFTEC = OUTPUTPARAM01;
                        oCamposDet.EliTABLA = loDatos.EliTABLA;
                        //oCamposDet.EliVALOR01 = OUTPUTPARAM02;
                        oCamposDet.EliVALOR02 = loDatos.EliVALOR02;
                        oCamposDet.COD_INFORME = loDatos.COD_INFORME;
                        oCamposDet.COD_RESODIREC = loDatos.COD_RESODIREC;
                        oCamposDet.COD_RESODIREC_INI_PAU = loDatos.COD_RESODIREC_INI_PAU;
                        dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spINFTECEliminarDetalle", oCamposDet);
                    }
                }
                if (oCEntidad.ListInformes != null)
                {
                    foreach (var loDatos in oCEntidad.ListInformes)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            oCamposDet = new CEntidadC();
                            oCamposDet.COD_INFTEC = OUTPUTPARAM01;
                            oCamposDet.RegEstado = 1;
                            if (loDatos.COD_RESODIREC != null && loDatos.COD_RESODIREC_INI_PAU != null)
                            {
                                oCamposDet.COD_RESODIREC_INI_PAU = loDatos.COD_RESODIREC_INI_PAU;
                                oCamposDet.COD_RESODIREC = loDatos.COD_RESODIREC;
                                dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spINFTEC_DET_EXPADM_Grabar", oCamposDet);
                            }
                            else if (loDatos.COD_INFORME != null)
                            {
                                oCamposDet.COD_INFORME = loDatos.COD_INFORME;
                                dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spINFTEC__DET_INFORME_Grabar", oCamposDet);
                            }
                        }
                    }
                }
                if (oCEntidad.Listardetdescargo != null)
                {
                    foreach (var loDatos in oCEntidad.Listardetdescargo)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            oCamposDet = new CEntidadC();
                            oCamposDet.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            oCamposDet.COD_ILEGAL_ENCISOS = loDatos.COD_ILEGAL_ENCISOS;
                            oCamposDet.COD_ESPECIES = loDatos.COD_ESPECIES;
                            oCamposDet.VOLUMEN = loDatos.VOLUMEN;
                            oCamposDet.AREA = loDatos.AREA;
                            oCamposDet.NUMERO_INDIVIDUOS = loDatos.NUMERO_INDIVIDUOS;
                            oCamposDet.DESCRIPCION_DET_DESCARGO = loDatos.DESCRIPCION_DET_DESCARGO;
                            oCamposDet.COD_INFTEC = OUTPUTPARAM01;
                            //oCamposDet.COD_INFTEC_DESCARGO = OUTPUTPARAM02;
                            oCamposDet.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spINFTEC_DET_DESCARGOGrabar", oCamposDet);
                        }
                    }
                }
                if (oCEntidad.Listarlffs != null)
                {
                    foreach (var loDatos in oCEntidad.Listarlffs)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            oCamposDet = new CEntidadC();
                            oCamposDet.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            oCamposDet.COD_ILEGAL_ENCISOSLFFS = loDatos.COD_ILEGAL_ENCISOSLFFS;
                            oCamposDet.RESOLUCION = loDatos.RESOLUCION;
                            oCamposDet.SANCION = loDatos.SANCION;
                            oCamposDet.COD_INFTEC = OUTPUTPARAM01;
                            //oCamposDet.COD_INFTEC_DESCARGO = OUTPUTPARAM02;
                            oCamposDet.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spINFTEC_INFRACCION_LFFSGrabar", oCamposDet);
                        }
                    }
                }
                if (oCEntidad.Listarmulta != null)
                {
                    foreach (var loDatos in oCEntidad.Listarmulta)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            oCamposDet = new CEntidadC();
                            //  oCamposDet.COD_SECUENCIAL = 0;
                            oCamposDet.COD_ILEGAL_ENCISOS = loDatos.COD_ILEGAL_ENCISOS;
                            oCamposDet.COD_ESPECIES = loDatos.COD_ESPECIES;
                            oCamposDet.COD_INCISO_OPCIONAL = loDatos.COD_INCISO_OPCIONAL;
                            oCamposDet.VOLUMENMULTA = loDatos.VOLUMENMULTA;
                            oCamposDet.BENEFICIOILICITO = loDatos.BENEFICIOILICITO;
                            oCamposDet.PE = loDatos.PE;
                            oCamposDet.K = loDatos.K;
                            oCamposDet.ALFA = loDatos.ALFA;
                            oCamposDet.VSUBFORMULA = loDatos.VSUBFORMULA;
                            oCamposDet.F = loDatos.F;
                            oCamposDet.R = loDatos.R;
                            oCamposDet.MULTASUBTOTALSOL = loDatos.MULTASUBTOTALSOL;
                            oCamposDet.MULTASUBTOTALUIT = loDatos.MULTASUBTOTALUIT;
                            oCamposDet.MULTATOTALUIT = loDatos.MULTATOTALUIT;
                            oCamposDet.COD_INFTEC = OUTPUTPARAM01;
                            //oCamposDet.COD_INFTEC_MULTA = OUTPUTPARAM02;
                            oCamposDet.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            oCamposDet.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spINFTEC_DET_FORMATOMULTAGrabar", oCamposDet);
                        }
                    }
                }
                if (oCEntidad.Listarmultaantiguo != null)
                {
                    foreach (var loDatos in oCEntidad.Listarmultaantiguo)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            oCamposDet = new CEntidadC();
                            //  oCamposDet.COD_SECUENCIAL = 0;
                            oCamposDet.COD_ILEGAL_ENCISOS = loDatos.COD_INCISOMULTA;
                            oCamposDet.COD_ESPECIES = loDatos.COD_ESPECIESMULTA;
                            oCamposDet.UIT_100 = loDatos.UIT_100;
                            oCamposDet.UIT_500 = loDatos.UIT_500;
                            oCamposDet.UIT_501 = loDatos.UIT_501;
                            oCamposDet.MULTA_SUBTOT1 = loDatos.MULTA_SUBTOT1;
                            oCamposDet.UIT = loDatos.UIT;
                            oCamposDet.MULTA_SUBTOT2 = loDatos.MULTA_SUBTOT2;
                            oCamposDet.VOLUMEN_M3 = loDatos.VOLUMEN_M3;
                            oCamposDet.VOLUMEN_PT = loDatos.VOLUMEN_PT;
                            oCamposDet.VCF = loDatos.VCF;
                            oCamposDet.DMC = loDatos.DMC;
                            oCamposDet.MULTA_CITE = loDatos.MULTA_CITE;
                            oCamposDet.MULTA_SUBTOTAL3 = loDatos.MULTA_SUBTOTAL3;
                            oCamposDet.MULTA_SUBTOTAL = loDatos.MULTA_SUBTOTAL;
                            oCamposDet.MULTA_TOTAL_UIT = loDatos.MULTA_TOTAL_UIT;
                            oCamposDet.COD_INFTEC = OUTPUTPARAM01;
                            //oCamposDet.COD_INFTEC_MULTA = OUTPUTPARAM02;
                            oCamposDet.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spINFTEC_DET_FORMATOANTIGUOGrabar", oCamposDet);
                        }
                    }
                }
                if (oCEntidad.ListVolumen != null)
                {
                    foreach (var loDatos in oCEntidad.ListVolumen)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            oCamposDet = new CEntidadC();
                            oCamposDet.COD_INFTEC = OUTPUTPARAM01;
                            oCamposDet.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            oCamposDet.COD_ESPECIES = loDatos.COD_ESPECIES;
                            oCamposDet.ESPECIES = loDatos.ESPECIES;
                            oCamposDet.VOLUMEN_APROBADO = loDatos.VOLUMEN_APROBADO;
                            oCamposDet.VOLUMEN_MOVILIZADO = loDatos.VOLUMEN_MOVILIZADO;
                            oCamposDet.VOLUMEN_INJUSTIFICADO = loDatos.VOLUMEN_INJUSTIFICADO;
                            oCamposDet.VOLUMEN_JUSTIFICADO = loDatos.VOLUMEN_JUSTIFICADO;
                            oCamposDet.OBSERVACION = loDatos.OBSERVACION;
                            oCamposDet.COD_UCUENTA = oCEntidad.COD_UCUENTA;
                            oCamposDet.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spINFTEC_DET_VOLUMENGrabar", oCamposDet);
                        }
                    }
                }
                if (oCEntidad.ListEMaderable != null)
                {
                    foreach (var loDatos in oCEntidad.ListEMaderable)
                    {
                        oCamposDet = new CEntidadC();
                        oCamposDet.COD_INFTEC = OUTPUTPARAM01;
                        oCamposDet.COD_INFORME = loDatos.COD_INFORME;
                        oCamposDet.COD_THABILITANTE = loDatos.COD_THABILITANTE;
                        oCamposDet.NUM_POA = loDatos.NUM_POA;
                        oCamposDet.COD_ESPECIES = loDatos.COD_ESPECIES;
                        oCamposDet.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                        oCamposDet.COD_EESTADO = loDatos.COD_EESTADO;
                        oCamposDet.COD_UCUENTA = oCEntidad.COD_UCUENTA;
                        dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spINFTEC_DET_EMADERABLEGrabar", oCamposDet);
                    }
                }
                if (oCEntidad.ListEMaderableSemillero != null)
                {
                    foreach (var loDatos in oCEntidad.ListEMaderableSemillero)
                    {
                        oCamposDet = new CEntidadC();
                        oCamposDet.COD_INFTEC = OUTPUTPARAM01;
                        oCamposDet.COD_INFORME = loDatos.COD_INFORME;
                        oCamposDet.COD_THABILITANTE = loDatos.COD_THABILITANTE;
                        oCamposDet.NUM_POA = loDatos.NUM_POA;
                        oCamposDet.COD_ESPECIES = loDatos.COD_ESPECIES;
                        oCamposDet.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                        oCamposDet.COD_EESTADO = loDatos.COD_EESTADO;
                        oCamposDet.COD_UCUENTA = oCEntidad.COD_UCUENTA;
                        dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spINFTEC_DET_EMADERABLEGrabar", oCamposDet);
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public CEntidadC RegMostrarListaInfTecItem(OracleConnection cn, CEntidadC oCEntidad)
        {
            CEntidadC lsCEntidad = new CEntidadC();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spINFTETMostrarItems", oCEntidad))
                {
                    if (dr != null)
                    {
                        lsCEntidad.ListInformes = new List<CEntidadC>();
                        lsCEntidad.Listarmultaantiguo = new List<CEntidadC>();
                        lsCEntidad.Listarmulta = new List<CEntidadC>();
                        lsCEntidad.Listardetdescargo = new List<CEntidadC>();
                        lsCEntidad.Listarlffs = new List<CEntidadC>();
                        lsCEntidad.ListVolumen = new List<CEntidadC>();
                        lsCEntidad.ListEMaderable = new List<CapaEntidad.DOC.Ent_INFORME>();
                        lsCEntidad.ListEMaderableSemillero = new List<CapaEntidad.DOC.Ent_INFORME>();
                        lsCEntidad.ListPManejo = new List<CEntidadC>();
                        lsCEntidad.ListEliTABLA = new List<CEntidadC>();
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
                            lsCEntidad.DESCRIPCION_MULTA = dr.GetString(dr.GetOrdinal("DESCRIPCION_MULTA"));
                            lsCEntidad.DESCRIPCION_MULTA_ANTIGUO = dr.GetString(dr.GetOrdinal("DESCRIPCION_MULTA_ANTIGUO"));
                            lsCEntidad.DESCRIPCION_INFORME = dr.GetString(dr.GetOrdinal("DESCRIPCION_INFORME"));

                            lsCEntidad.MULTA_RECOMENDADA_SOLES = dr.GetDecimal(dr.GetOrdinal("MULTA_RECOMENDADA_SOLES"));
                            lsCEntidad.MULTA_RECOMENDADA_UIT = dr.GetDecimal(dr.GetOrdinal("MULTA_RECOMENDADA_UIT"));
                            lsCEntidad.MOTIVO_MULTA = dr.GetString(dr.GetOrdinal("MOTIVO_MULTA"));

                            lsCEntidad.DOCUMENTOS_ADJUNTOS = dr.GetString(dr.GetOrdinal("DOCUMENTOS_ADJUNTOS"));
                            lsCEntidad.INFORMACION_ACLARO = dr.GetString(dr.GetOrdinal("INFORMACION_ACLARO"));

                            lsCEntidad.CONCLUSION = dr.GetString(dr.GetOrdinal("CONCLUSION"));
                            lsCEntidad.INFORMACION_COMPLEMENTO = dr.GetString(dr.GetOrdinal("INFORMACION_COMPLEMENTO"));
                            lsCEntidad.REFERENCIA = dr.GetString(dr.GetOrdinal("REFERENCIA"));

                            lsCEntidad.FECHA_INICIO_INSPECCION = dr.GetString(dr.GetOrdinal("FECHA_INICIO_INSPECCION"));
                            lsCEntidad.FECHA_FIN_INSPECCION = dr.GetString(dr.GetOrdinal("FECHA_FIN_INSPECCION"));
                            lsCEntidad.PRINCIPALES_RESULTADOS = dr.GetString(dr.GetOrdinal("PRINCIPALES_RESULTADOS"));

                            lsCEntidad.COMENTARIOS = dr.GetString(dr.GetOrdinal("COMENTARIOS"));
                            lsCEntidad.COD_OD_REGISTRO = dr.GetString(dr.GetOrdinal("COD_OD_REGISTRO"));
                            lsCEntidad.USUARIO_REGISTRO = dr.GetString(dr.GetOrdinal("USUARIO_REGISTRO"));
                            //´para los informes tecnicos de evaluacion del informe de actividad y del recurso de reconsideracion 15/09/2017
                            lsCEntidad.NUM_INF_ACTIV = dr.GetString(dr.GetOrdinal("NUM_INF_ACTIV"));
                            lsCEntidad.CONCLUCION = dr.GetString(dr.GetOrdinal("CONCLUCION"));
                            lsCEntidad.RECOMENDACION = dr.GetString(dr.GetOrdinal("RECOMENDACION"));

                            lsCEntidad.CAMBIA_VOL_ISUPERVISION = dr.GetBoolean(dr.GetOrdinal("CAMBIA_VOL_ISUPERVISION"));
                            lsCEntidad.CAMBIA_ESTADO_ESPECIES = dr.GetBoolean(dr.GetOrdinal("CAMBIA_ESTADO_ESPECIES"));
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
                            int pt0 = dr.GetOrdinal("COD_ILEGAL_ENCISOS");
                            int pt1 = dr.GetOrdinal("DESCRIPCION_INCISOSMULTA");
                            int pt2 = dr.GetOrdinal("COD_ESPECIES");
                            int pt3 = dr.GetOrdinal("DESCRIPCION_ESPECIEMULTA");
                            int pt4 = dr.GetOrdinal("COD_SECUENCIAL");
                            int pt5 = dr.GetOrdinal("UIT");
                            int pt6 = dr.GetOrdinal("UIT_100");
                            int pt7 = dr.GetOrdinal("UIT_500");
                            int pt8 = dr.GetOrdinal("UIT_501");
                            int pt9 = dr.GetOrdinal("MULTA_SUBTOT1");
                            int pt10 = dr.GetOrdinal("MULTA_SUBTOT2");
                            int pt11 = dr.GetOrdinal("VOLUMEN_M3");
                            int pt12 = dr.GetOrdinal("VOLUMEN_PT");
                            int pt13 = dr.GetOrdinal("VCF");
                            int pt14 = dr.GetOrdinal("DMC");
                            int pt15 = dr.GetOrdinal("MULTA_CITE");
                            int pt16 = dr.GetOrdinal("MULTA_SUBTOTAL3");
                            int pt17 = dr.GetOrdinal("MULTA_SUBTOTAL");
                            int pt18 = dr.GetOrdinal("MULTA_TOTAL_UIT");
                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidadC();
                                ocampoEnt.COD_ILEGAL_ENCISOS = dr.GetString(pt0);
                                ocampoEnt.DESCRIPCION_INCISOSMULTA = dr.GetString(pt1);
                                ocampoEnt.COD_ESPECIES = dr.GetString(pt2);
                                ocampoEnt.DESCRIPCION_ESPECIEMULTA = dr.GetString(pt3);
                                ocampoEnt.COD_SECUENCIAL = dr.GetInt32(pt4);
                                ocampoEnt.UIT = dr.GetDecimal(pt5);
                                ocampoEnt.UIT_100 = dr.GetDecimal(pt6);
                                ocampoEnt.UIT_500 = dr.GetDecimal(pt7);
                                ocampoEnt.UIT_501 = dr.GetDecimal(pt8);
                                ocampoEnt.MULTA_SUBTOT1 = dr.GetDecimal(pt9);
                                ocampoEnt.MULTA_SUBTOT2 = dr.GetDecimal(pt10);
                                ocampoEnt.VOLUMEN_M3 = dr.GetDecimal(pt11);
                                ocampoEnt.VOLUMEN_PT = dr.GetDecimal(pt12);
                                ocampoEnt.VCF = dr.GetDecimal(pt13);
                                ocampoEnt.DMC = dr.GetDecimal(pt14);
                                ocampoEnt.MULTA_CITE = dr.GetDecimal(pt15);
                                ocampoEnt.MULTA_SUBTOTAL3 = dr.GetDecimal(pt16);
                                ocampoEnt.MULTA_SUBTOTAL = dr.GetDecimal(pt17);
                                ocampoEnt.MULTA_TOTAL_UIT = dr.GetDecimal(pt18);
                                ocampoEnt.RegEstado = 0;
                                lsCEntidad.Listarmultaantiguo.Add(ocampoEnt);
                            }
                        }
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            int pt0 = dr.GetOrdinal("COD_ILEGAL_ENCISOS");
                            int pt1 = dr.GetOrdinal("DESCRIPCION_INCISOSMULTA");
                            int pt2 = dr.GetOrdinal("COD_INCISO_OPCIONAL");
                            int pt3 = dr.GetOrdinal("DESCRIPCION_INCISOSMULTA2");
                            int pt4 = dr.GetOrdinal("COD_ESPECIES");
                            int pt5 = dr.GetOrdinal("DESCRIPCION_ESPECIEMULTA");
                            int pt6 = dr.GetOrdinal("COD_SECUENCIAL");
                            int pt7 = dr.GetOrdinal("VOLUMENMULTA");
                            int pt8 = dr.GetOrdinal("BENEFICIOILICITO");
                            int pt9 = dr.GetOrdinal("PE");
                            int pt10 = dr.GetOrdinal("K");
                            int pt11 = dr.GetOrdinal("ALFA");
                            int pt12 = dr.GetOrdinal("VSUBFORMULA");
                            int pt13 = dr.GetOrdinal("MULTASUBTOTALSOL");
                            int pt14 = dr.GetOrdinal("MULTASUBTOTALUIT");
                            int pt15 = dr.GetOrdinal("MULTATOTALUIT");
                            int pt16 = dr.GetOrdinal("R");
                            int pt17 = dr.GetOrdinal("F");

                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidadC();
                                ocampoEnt.COD_ILEGAL_ENCISOS = dr.GetString(pt0);
                                ocampoEnt.DESCRIPCION_INCISOSMULTA = dr.GetString(pt1);
                                ocampoEnt.COD_INCISO_OPCIONAL = dr.GetString(pt2);
                                ocampoEnt.DESCRIPCION_INCISOSMULTA2 = dr.GetString(pt3);
                                ocampoEnt.COD_ESPECIES = dr.GetString(pt4);
                                ocampoEnt.DESCRIPCION_ESPECIEMULTA = dr.GetString(pt5);
                                ocampoEnt.COD_SECUENCIAL = dr.GetInt32(pt6);
                                ocampoEnt.VOLUMENMULTA = dr.GetDecimal(pt7);
                                ocampoEnt.BENEFICIOILICITO = dr.GetDecimal(pt8);
                                ocampoEnt.PE = dr.GetInt32(pt9);
                                ocampoEnt.K = dr.GetDecimal(pt10);
                                ocampoEnt.ALFA = dr.GetDecimal(pt11);
                                ocampoEnt.VSUBFORMULA = dr.GetDecimal(pt12);
                                ocampoEnt.MULTASUBTOTALSOL = dr.GetDecimal(pt13);
                                ocampoEnt.MULTASUBTOTALUIT = dr.GetDecimal(pt14);
                                ocampoEnt.MULTATOTALUIT = dr.GetDecimal(pt15);
                                ocampoEnt.R = dr.GetDecimal(pt16);
                                ocampoEnt.F = dr.GetDecimal(pt17);
                                ocampoEnt.RegEstado = 0;
                                lsCEntidad.Listarmulta.Add(ocampoEnt);
                            }
                        }
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            int pt0 = dr.GetOrdinal("COD_ILEGAL_ENCISOS");
                            int pt1 = dr.GetOrdinal("DESCRIPCION_ARTICULOS");
                            int pt2 = dr.GetOrdinal("DESCRIPCION_ENCISOS");
                            int pt3 = dr.GetOrdinal("COD_ESPECIES");
                            int pt4 = dr.GetOrdinal("DESCRIPCION_ESPECIE");
                            int pt5 = dr.GetOrdinal("VOLUMEN");
                            int pt6 = dr.GetOrdinal("AREA");
                            int pt7 = dr.GetOrdinal("NUMERO_INDIVIDUOS");
                            int pt8 = dr.GetOrdinal("DESCRIPCION_DET_DESCARGO");
                            int pt9 = dr.GetOrdinal("COD_SECUENCIAL");
                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidadC();
                                ocampoEnt.COD_ILEGAL_ENCISOS = dr.GetString(pt0);
                                ocampoEnt.DESCRIPCION_ARTICULOS = dr.GetString(pt1);
                                ocampoEnt.DESCRIPCION_ENCISOS = dr.GetString(pt2);
                                ocampoEnt.COD_ESPECIES = dr.GetString(pt3);
                                ocampoEnt.DESCRIPCION_ESPECIE = dr.GetString(pt4);
                                ocampoEnt.VOLUMEN = dr.GetDecimal(pt5);
                                ocampoEnt.AREA = dr.GetDecimal(pt6);
                                ocampoEnt.NUMERO_INDIVIDUOS = dr.GetInt32(pt7);
                                ocampoEnt.DESCRIPCION_DET_DESCARGO = dr.GetString(pt8);
                                ocampoEnt.COD_SECUENCIAL = dr.GetInt32(pt9);
                                ocampoEnt.RegEstado = 0;
                                lsCEntidad.Listardetdescargo.Add(ocampoEnt);
                            }
                        }
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            int pt0 = dr.GetOrdinal("COD_SECUENCIAL");
                            int pt1 = dr.GetOrdinal("RESOLUCION");
                            int pt2 = dr.GetOrdinal("COD_ILEGAL_ENCISOS");
                            int pt3 = dr.GetOrdinal("SANCION");
                            int pt4 = dr.GetOrdinal("DESCRIPCION_ARTICULOSLFFS");
                            int pt5 = dr.GetOrdinal("DESCRIPCION_ENCISOSLFFS");
                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidadC();
                                ocampoEnt.COD_SECUENCIAL = dr.GetInt32(pt0);
                                ocampoEnt.RESOLUCION = dr.GetString(pt1);
                                ocampoEnt.COD_ILEGAL_ENCISOS = dr.GetString(pt2);
                                ocampoEnt.SANCION = dr.GetString(pt3);
                                ocampoEnt.DESCRIPCION_ARTICULOSLFFS = dr.GetString(pt4);
                                ocampoEnt.DESCRIPCION_ENCISOSLFFS = dr.GetString(pt5);
                                ocampoEnt.RegEstado = 0;
                                lsCEntidad.Listarlffs.Add(ocampoEnt);
                            }
                        }
                        //Volumen Injustificado y Justificado
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidadC();
                                ocampoEnt.COD_SECUENCIAL = dr.GetInt32(dr.GetOrdinal("COD_SECUENCIAL"));
                                ocampoEnt.COD_ESPECIES = dr.GetString(dr.GetOrdinal("COD_ESPECIES"));
                                ocampoEnt.ESPECIES = dr.GetString(dr.GetOrdinal("ESPECIES"));
                                ocampoEnt.VOLUMEN_APROBADO = dr.GetDecimal(dr.GetOrdinal("VOLUMEN_APROBADO"));
                                ocampoEnt.VOLUMEN_MOVILIZADO = dr.GetDecimal(dr.GetOrdinal("VOLUMEN_MOVILIZADO"));
                                ocampoEnt.VOLUMEN_INJUSTIFICADO = dr.GetDecimal(dr.GetOrdinal("VOLUMEN_INJUSTIFICADO"));
                                ocampoEnt.VOLUMEN_JUSTIFICADO = dr.GetDecimal(dr.GetOrdinal("VOLUMEN_JUSTIFICADO"));
                                ocampoEnt.OBSERVACION = dr.GetString(dr.GetOrdinal("OBSERVACION"));
                                ocampoEnt.RegEstado = 0;
                                lsCEntidad.ListVolumen.Add(ocampoEnt);
                            }
                        }

                        CapaEntidad.DOC.Ent_INFORME ocampoisup;
                        //Datos de campo maderable
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                ocampoisup = new CapaEntidad.DOC.Ent_INFORME();
                                ocampoisup.COD_INFORME = dr["COD_INFORME"].ToString();
                                ocampoisup.COD_THABILITANTE = dr["COD_THABILITANTE"].ToString();
                                ocampoisup.NUM_POA = Convert.ToInt32(dr["NUM_POA"].ToString());
                                ocampoisup.COD_ESPECIES = dr["COD_ESPECIES"].ToString();
                                ocampoisup.COD_SECUENCIAL = Convert.ToInt32(dr["COD_SECUENCIAL"].ToString());
                                ocampoisup.POA = dr["POA"].ToString();
                                ocampoisup.BLOQUE = dr["BLOQUE"].ToString();
                                ocampoisup.BLOQUE_CAMPO = dr["BLOQUE_CAMPO"].ToString();
                                ocampoisup.FAJA = dr["FAJA"].ToString();
                                ocampoisup.FAJA_CAMPO = dr["FAJA_CAMPO"].ToString();
                                ocampoisup.CODIGO = dr["CODIGO"].ToString();
                                ocampoisup.CODIGO_CAMPO = dr["CODIGO_CAMPO"].ToString();
                                ocampoisup.DESC_ESPECIES = dr["ESPECIES"].ToString();
                                ocampoisup.DESC_ESPECIES_CAMPO = dr["ESPECIES_CAMPO"].ToString();
                                ocampoisup.DESC_COINCIDE_ESPECIES = dr["COINCIDE_ESPECIES"].ToString();
                                ocampoisup.ZONA = dr["ZONA"].ToString();
                                ocampoisup.ZONA_CAMPO = dr["ZONA_CAMPO"].ToString();
                                ocampoisup.COORDENADA_ESTE = Convert.ToInt32(dr["COORDENADA_ESTE"].ToString());
                                ocampoisup.COORDENADA_ESTE_CAMPO = Convert.ToInt32(dr["COORDENADA_ESTE_CAMPO"].ToString());
                                ocampoisup.COORDENADA_NORTE = Convert.ToInt32(dr["COORDENADA_NORTE"].ToString());
                                ocampoisup.COORDENADA_NORTE_CAMPO = Convert.ToInt32(dr["COORDENADA_NORTE_CAMPO"].ToString());
                                ocampoisup.DAP = Convert.ToDecimal(dr["DAP"].ToString());
                                ocampoisup.DAP_CAMPO = Convert.ToDecimal(dr["DAP_CAMPO"].ToString());
                                ocampoisup.DAP_CAMPO1 = Convert.ToDecimal(dr["DAP_CAMPO1"].ToString());
                                ocampoisup.DAP_CAMPO2 = Convert.ToDecimal(dr["DAP_CAMPO2"].ToString());
                                ocampoisup.MMEDIR_DAP = dr["MMEDIR_DAP"].ToString();
                                ocampoisup.AC = Convert.ToDecimal(dr["AC"].ToString());
                                ocampoisup.AC_CAMPO = Convert.ToDecimal(dr["AC_CAMPO"].ToString());
                                ocampoisup.DESC_EESTADO = dr["EESTADO"].ToString();
                                ocampoisup.DESC_EESTADO_CAMPO = dr["EESTADO_CAMPO"].ToString();
                                ocampoisup.COD_EESTADO = dr["COD_EESTADO_CAMPO"].ToString();
                                ocampoisup.DESC_ECONDICION = dr["ECONDICION"].ToString();
                                ocampoisup.DESC_ECONDICION_CAMPO = dr["ECONDICION_CAMPO"].ToString();
                                ocampoisup.OBSERVACION = dr["OBSERVACION"].ToString();
                                lsCEntidad.ListEMaderable.Add(ocampoisup);
                            }
                        }
                        //Datos de campo maderable semillero
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                ocampoisup = new CapaEntidad.DOC.Ent_INFORME();
                                ocampoisup.COD_INFORME = dr["COD_INFORME"].ToString();
                                ocampoisup.COD_THABILITANTE = dr["COD_THABILITANTE"].ToString();
                                ocampoisup.NUM_POA = Convert.ToInt32(dr["NUM_POA"].ToString());
                                ocampoisup.COD_ESPECIES = dr["COD_ESPECIES"].ToString();
                                ocampoisup.COD_SECUENCIAL = Convert.ToInt32(dr["COD_SECUENCIAL"].ToString());
                                ocampoisup.POA = dr["POA"].ToString();
                                ocampoisup.BLOQUE = dr["BLOQUE"].ToString();
                                ocampoisup.BLOQUE_CAMPO = dr["BLOQUE_CAMPO"].ToString();
                                ocampoisup.FAJA = dr["FAJA"].ToString();
                                ocampoisup.FAJA_CAMPO = dr["FAJA_CAMPO"].ToString();
                                ocampoisup.CODIGO = dr["CODIGO"].ToString();
                                ocampoisup.CODIGO_CAMPO = dr["CODIGO_CAMPO"].ToString();
                                ocampoisup.DESC_ESPECIES = dr["ESPECIES"].ToString();
                                ocampoisup.DESC_ESPECIES_CAMPO = dr["ESPECIES_CAMPO"].ToString();
                                ocampoisup.DESC_COINCIDE_ESPECIES = dr["COINCIDE_ESPECIES"].ToString();
                                ocampoisup.ZONA = dr["ZONA"].ToString();
                                ocampoisup.ZONA_CAMPO = dr["ZONA_CAMPO"].ToString();
                                ocampoisup.COORDENADA_ESTE = Convert.ToInt32(dr["COORDENADA_ESTE"].ToString());
                                ocampoisup.COORDENADA_ESTE_CAMPO = Convert.ToInt32(dr["COORDENADA_ESTE_CAMPO"].ToString());
                                ocampoisup.COORDENADA_NORTE = Convert.ToInt32(dr["COORDENADA_NORTE"].ToString());
                                ocampoisup.COORDENADA_NORTE_CAMPO = Convert.ToInt32(dr["COORDENADA_NORTE_CAMPO"].ToString());
                                ocampoisup.DAP = Convert.ToDecimal(dr["DAP"].ToString());
                                ocampoisup.DAP_CAMPO = Convert.ToDecimal(dr["DAP_CAMPO"].ToString());
                                ocampoisup.DAP_CAMPO1 = Convert.ToDecimal(dr["DAP_CAMPO1"].ToString());
                                ocampoisup.DAP_CAMPO2 = Convert.ToDecimal(dr["DAP_CAMPO2"].ToString());
                                ocampoisup.MMEDIR_DAP = dr["MMEDIR_DAP"].ToString();
                                ocampoisup.AC = Convert.ToDecimal(dr["AC"].ToString());
                                ocampoisup.AC_CAMPO = Convert.ToDecimal(dr["AC_CAMPO"].ToString());
                                ocampoisup.DESC_EESTADO = dr["EESTADO"].ToString();
                                ocampoisup.DESC_EESTADO_CAMPO = dr["EESTADO_CAMPO"].ToString();
                                ocampoisup.COD_EESTADO = dr["COD_EESTADO_CAMPO"].ToString();
                                ocampoisup.DESC_EFENOLOGICO = dr["EFENOLOGICO"].ToString();
                                ocampoisup.DESC_CFUSTE = dr["CFUSTE"].ToString();
                                ocampoisup.DESC_FCOPA = dr["FCOPA"].ToString();
                                ocampoisup.DESC_PCOPA = dr["PCOPA"].ToString();
                                ocampoisup.DESC_EFITOSANITARIO = dr["ESANITARIO"].ToString();
                                ocampoisup.DESC_ILIANAS = dr["ILIANAS"].ToString();
                                ocampoisup.OBSERVACION = dr["OBSERVACION"].ToString();
                                lsCEntidad.ListEMaderableSemillero.Add(ocampoisup);
                            }
                        }
                        //Datos adicionales Informe Técnico de Evaluación de Denuncias
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            if (dr.Read())
                            {
                                lsCEntidad.COD_INFTEC = dr.GetString(dr.GetOrdinal("COD_INFTEC"));
                                lsCEntidad.COD_THABILITANTE = dr.GetString(dr.GetOrdinal("COD_THABILITANTE"));
                                lsCEntidad.NUM_THABILITANTE = dr.GetString(dr.GetOrdinal("NUM_THABILITANTE"));
                                lsCEntidad.COD_PERSONA_DIRIGIDO = dr.GetString(dr.GetOrdinal("COD_PERSONA_DIRIGIDO"));
                                lsCEntidad.PERSONA_DIRIGIDO = dr.GetString(dr.GetOrdinal("PERSONA_DIRIGIDO"));
                                lsCEntidad.COD_TRAMITE_SITD = dr.GetInt32(dr.GetOrdinal("COD_TRAMITE_SITD"));
                                lsCEntidad.NUM_DREFERECIA = dr.GetString(dr.GetOrdinal("NUM_DREFERECIA"));
                                lsCEntidad.MOTIVO_CAMBIO_USO = dr.GetBoolean(dr.GetOrdinal("MOTIVO_CAMBIO_USO"));
                                lsCEntidad.MOTIVO_INVASION = dr.GetBoolean(dr.GetOrdinal("MOTIVO_INVASION"));
                                lsCEntidad.MOTIVO_MINERIA_ILEGAL = dr.GetBoolean(dr.GetOrdinal("MOTIVO_MINERIA_ILEGAL"));
                                lsCEntidad.MOTIVO_TALA_ILEGAL = dr.GetBoolean(dr.GetOrdinal("MOTIVO_TALA_ILEGAL"));
                                lsCEntidad.MOTIVO_OTROS = dr.GetBoolean(dr.GetOrdinal("MOTIVO_OTROS"));
                                lsCEntidad.DESCRIPCION_MOTROS = dr.GetString(dr.GetOrdinal("DESCRIPCION_MOTROS"));
                                lsCEntidad.TITULAR_PAU_TRAMITE = dr.GetString(dr.GetOrdinal("TITULAR_PAU_TRAMITE"));
                                lsCEntidad.REQUIERE_SUPERVISION = dr.GetString(dr.GetOrdinal("REQUIERE_SUPERVISION"));
                                lsCEntidad.TRANSLADAR_ENTIDAD = dr.GetBoolean(dr.GetOrdinal("TRANSLADAR_ENTIDAD"));
                                lsCEntidad.DGFFS = dr.GetBoolean(dr.GetOrdinal("DGFFS"));
                                lsCEntidad.DETALLE_DGFFS = dr.GetString(dr.GetOrdinal("DETALLE_DGFFS"));
                                lsCEntidad.ATFFS = dr.GetBoolean(dr.GetOrdinal("ATFFS"));
                                lsCEntidad.DETALLE_ATFFS = dr.GetString(dr.GetOrdinal("DETALLE_ATFFS"));
                                lsCEntidad.OCI = dr.GetBoolean(dr.GetOrdinal("OCI"));
                                lsCEntidad.DETALLE_OCI = dr.GetString(dr.GetOrdinal("DETALLE_OCI"));
                                lsCEntidad.PROGRAMA_REGIONAL = dr.GetBoolean(dr.GetOrdinal("PROGRAMA_REGIONAL"));
                                lsCEntidad.DETALLE_PROREG = dr.GetString(dr.GetOrdinal("DETALLE_PROREG"));
                                lsCEntidad.MINISTERIO_PUBLICO = dr.GetBoolean(dr.GetOrdinal("MINISTERIO_PUBLICO"));
                                lsCEntidad.DETALLE_MINPUB = dr.GetString(dr.GetOrdinal("DETALLE_MINPUB"));
                                lsCEntidad.COLEGIO_INGENIEROS = dr.GetBoolean(dr.GetOrdinal("COLEGIO_INGENIEROS"));
                                lsCEntidad.DETALLE_COLING = dr.GetString(dr.GetOrdinal("DETALLE_COLING"));
                                lsCEntidad.OEFA = dr.GetBoolean(dr.GetOrdinal("OEFA"));
                                lsCEntidad.DETALLE_OEFA = dr.GetString(dr.GetOrdinal("DETALLE_OEFA"));
                                lsCEntidad.SUNAT = dr.GetBoolean(dr.GetOrdinal("SUNAT"));
                                lsCEntidad.DETALLE_SUNAT = dr.GetString(dr.GetOrdinal("DETALLE_SUNAT"));
                                lsCEntidad.SERFOR = dr.GetBoolean(dr.GetOrdinal("SERFOR"));
                                lsCEntidad.DETALLE_SERFOR = dr.GetString(dr.GetOrdinal("DETALLE_SERFOR"));
                                lsCEntidad.MIN_ENERGIA_MINAS = dr.GetBoolean(dr.GetOrdinal("MIN_ENERGIA_MINAS"));
                                lsCEntidad.DETALLE_MINENMIN = dr.GetString(dr.GetOrdinal("DETALLE_MINENMIN"));
                                lsCEntidad.OTROS = dr.GetBoolean(dr.GetOrdinal("OTROS"));
                                lsCEntidad.DETALLE_OTROS = dr.GetString(dr.GetOrdinal("DETALLE_OTROS"));
                            }
                        }
                        //Listado de planes de manejo (POA/PO|DEMA,etc...) de un TH asociado a una informe técnico de evaluación de denuncias
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidadC();
                                ocampoEnt.COD_INFTEC = dr.GetString(dr.GetOrdinal("COD_INFTEC"));
                                ocampoEnt.COD_THABILITANTE = dr.GetString(dr.GetOrdinal("COD_THABILITANTE"));
                                ocampoEnt.NUM_POA = dr.GetInt32(dr.GetOrdinal("NUM_POA"));
                                ocampoEnt.NOMBRE_POA = dr.GetString(dr.GetOrdinal("NOMBRE_POA"));
                                ocampoEnt.RESOLUCION = dr.GetString(dr.GetOrdinal("RESOLUCION"));
                                ocampoEnt.RegEstado = 0;
                                lsCEntidad.ListPManejo.Add(ocampoEnt);
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

        //public String RegGrabaInfTecnicoDenuncia(SqlConnection cn, CEntidadC oCEntidad)
        //{
        //    SqlTransaction tr = null;
        //    String OUTPUTPARAM01 = "";
        //    CEntidadC oCamposDet;
        //    try
        //    {
        //        tr = cn.BeginTransaction();
        //        //Grabando Cabecera
        //        using (SqlCommand cmd = oGDataSQL.ManExecuteOutput(cn, tr, "DOC.spINFTEC_DENUNCIAGrabar", oCEntidad))
        //        {
        //            cmd.ExecuteNonQuery();
        //            OUTPUTPARAM01 = (String)cmd.Parameters["@OUTPUTPARAM01"].Value;
        //            if (OUTPUTPARAM01 == "99")
        //            {
        //                tr.Rollback();
        //                tr = null;
        //                throw new Exception("Ud. no tiene permiso para realizar esta acción");
        //            }
        //            if (OUTPUTPARAM01 == "0")
        //            {
        //                tr.Rollback();
        //                tr = null;
        //                throw new Exception("El Número del Informe Técnico ya existe");
        //            }
        //            else if (OUTPUTPARAM01 == "1")
        //            {
        //                tr.Rollback();
        //                tr = null;
        //                throw new Exception("El Número de Informe Técnico existe en otro Registro");
        //            }
        //            else if (OUTPUTPARAM01 == "2")
        //            {
        //                tr.Rollback();
        //                tr = null;
        //                throw new Exception("No Tiene Permisos para Modificar este informe técnico");
        //            }
        //            else if (OUTPUTPARAM01 == "3")
        //            {
        //                tr.Rollback();
        //                tr = null;
        //                throw new Exception("Está con Control de Calidad, no puede modificar");
        //            }
        //        }
        //        if (oCEntidad.RegEstado == 1) //Nuevo
        //        {
        //            oCEntidad.COD_INFTEC = OUTPUTPARAM01;
        //        }
        //        //Eliminando Detalle
        //        if (oCEntidad.ListEliTABLA != null)
        //        {
        //            foreach (var loDatos in oCEntidad.ListEliTABLA)
        //            {
        //                oCamposDet = new CEntidadC();
        //                oCamposDet.COD_INFTEC = OUTPUTPARAM01;
        //                oCamposDet.EliTABLA = loDatos.EliTABLA;
        //                oCamposDet.EliVALOR01 = loDatos.COD_THABILITANTE;
        //                oCamposDet.EliVALOR02 = loDatos.NUM_POA;
        //                oGDataSQL.ManExecute(cn, tr, "DOC.spINFTECEliminarDetalle", oCamposDet);
        //            }
        //        }
        //        if (oCEntidad.ListPManejo != null)
        //        {
        //            foreach (var loDatos in oCEntidad.ListPManejo)
        //            {
        //                if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
        //                {
        //                    oCamposDet = new CEntidadC();
        //                    oCamposDet.COD_INFTEC = OUTPUTPARAM01;
        //                    oCamposDet.COD_THABILITANTE = loDatos.COD_THABILITANTE;
        //                    oCamposDet.NUM_POA = loDatos.NUM_POA;
        //                    oCamposDet.COD_UCUENTA = oCEntidad.COD_UCUENTA;
        //                    oCamposDet.RegEstado = loDatos.RegEstado;
        //                    oGDataSQL.ManExecute(cn, tr, "DOC.spINFTEC_DET_POAGrabar", oCamposDet);
        //                }
        //            }
        //        }

        //        tr.Commit();
        //        return OUTPUTPARAM01;
        //    }
        //    catch (Exception ex)
        //    {
        //        if (tr != null)
        //        {
        //            tr.Rollback();
        //        }
        //        throw ex;
        //    }
        //}


        public List<Dictionary<string, string>> RegistroUsuarios(OracleConnection cn, CEntidadC oCEntidad)
        {
            List<Dictionary<string, string>> lstResult = new List<Dictionary<string, string>>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "doc_osinfor_erp_migracion.CR_FISCA_GENERAL_LISTAR", oCEntidad))
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

    }
}
