using CapaEntidad.DOC;
using GeneralSQL;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using CEntidadC = CapaEntidad.DOC.Ent_ILEGAL;
using SQL = GeneralSQL.Data.SQL;

namespace CapaDatos.DOC
{
    /// <summary>
    /// Capa de Datos de Registro de Informes Legales del Modulo de Fiscalización
    /// </summary>
    public class Dat_ILEGAL
    {
        private SQL oGDataSQL = new SQL();
        private DBOracle dBOracle = new DBOracle();
        /// <summary>
        /// Metodo para crear un informe legal
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public String RegILEGAL_Grabar(OracleConnection cn, CEntidadC oCEntidad)
        {
            OracleTransaction tr = null;
            String OUTPUTPARAM01 = "";
            CEntidadC oCamposDet;
            String COD_IALERTA = "";
            try
            {
                tr = cn.BeginTransaction();
                //Grabando Cabecera
                using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, tr, "doc_osinfor_erp_migracion.spILEGAL_Grabar", oCEntidad))
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
                        throw new Exception("El Número del Informe Legal ya Existe");
                    }
                    else if (OUTPUTPARAM01 == "1")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("El Número del Informe Legal Existe en otro Registro");
                    }
                    else if (OUTPUTPARAM01 == "2")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("No Tiene Permisos para Modificar este Informe Legal");
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
                    oCEntidad.COD_ILEGAL = OUTPUTPARAM01;
                }

                //Eliminando Detalle
                if (oCEntidad.ListEliTABLA != null)
                {
                    foreach (var loDatos in oCEntidad.ListEliTABLA)
                    {
                        oCamposDet = new CEntidadC();
                        oCamposDet.COD_ILEGAL = OUTPUTPARAM01;
                        oCamposDet.EliTABLA = loDatos.EliTABLA;
                        oCamposDet.COD_INFORME = loDatos.COD_INFORME;
                        oCamposDet.COD_RESODIREC = loDatos.COD_RESODIREC;
                        oCamposDet.COD_RESODIREC_INI_PAU = loDatos.COD_RESODIREC_INI_PAU;
                        oCamposDet.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                        oCamposDet.COD_ILEGAL_ENCISOS = loDatos.COD_ILEGAL_ENCISOS;
                        oCamposDet.COD_ESPECIES = loDatos.COD_ESPECIES;
                        dBOracle.ManExecute(cn, tr, "doc_osinfor_erp_migracion.spILEGALEliminarDetalle", oCamposDet);
                    }
                }

                // Creando la lista de informes
                if (oCEntidad.ListInformesTemp != null)
                {
                    foreach (var loDatos in oCEntidad.ListInformesTemp)
                    {
                        if (loDatos.RegEstado == 1) //Nuevo
                        {
                            oCamposDet = new CEntidadC();
                            oCamposDet.COD_ILEGAL = OUTPUTPARAM01;
                            oCamposDet.COD_FCTIPO = oCEntidad.COD_FCTIPO;
                            if (loDatos.COD_RESODIREC != null && loDatos.COD_RESODIREC_INI_PAU != null)
                            {
                                //oCamposDet.COD_ILEGAL_CONFORMIDAD = OUTPUTPARAM02;
                                oCamposDet.COD_RESODIREC_INI_PAU = loDatos.COD_RESODIREC_INI_PAU;
                                oCamposDet.COD_RESODIREC = loDatos.COD_RESODIREC;
                                oCamposDet.RegEstado = loDatos.RegEstado;
                                dBOracle.ManExecute(cn, tr, "doc_osinfor_erp_migracion.spILEGAL_vs_INICIO_PAU_Grabar", oCamposDet);
                            }
                            else if (loDatos.COD_INFORME != null)
                            {
                                oCamposDet.COD_INFORME = loDatos.COD_INFORME;
                                dBOracle.ManExecute(cn, tr, "doc_osinfor_erp_migracion.spILEGAL_DET_INFGrabar", oCamposDet);
                            }
                            else if (loDatos.COD_INFORME_ALERTA != null)
                            {
                                oCamposDet = new CEntidadC();
                                oCamposDet.COD_ILEGAL = OUTPUTPARAM01;
                                oCamposDet.COD_INFORME_ALERTA = loDatos.COD_INFORME_ALERTA;
                                oCamposDet.COD_UCUENTA = oCEntidad.COD_UCUENTA;
                                COD_IALERTA = oCamposDet.COD_INFORME_ALERTA;
                                dBOracle.ManExecute(cn, tr, "doc_osinfor_erp_migracion.spILEGAL_DET_IALERTA_Grabar", oCamposDet);
                            }
                        }
                    }
                }
                //Grabando Detalle INCISOS ARCHIVO EVA. INFORME SUPERVISION
                if (oCEntidad.ListIncisos != null)
                {
                    foreach (var loDatos in oCEntidad.ListIncisos)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            oCamposDet = new CEntidadC();

                            //oCamposDet.COD_ILEGAL_EVA_INF_SUP = OUTPUTPARAM02;
                            oCamposDet.COD_ILEGAL_ENCISOS = loDatos.COD_ILEGAL_ENCISOS;
                            oCamposDet.COD_FCTIPO = oCEntidad.COD_FCTIPO;
                            oCamposDet.COD_ILEGAL = OUTPUTPARAM01;
                            dBOracle.ManExecute(cn, tr, "doc_osinfor_erp_migracion.spILEGAL_DET_ENCISOS_Grabar", oCamposDet);
                        }
                    }
                }
                //Especies medidas correctivas
                if (oCEntidad.ListEspeciesMCorrectiva != null)
                {
                    if (oCEntidad.ListEspeciesMCorrectiva.Count > 0)
                    {
                        foreach (var loDatos in oCEntidad.ListEspeciesMCorrectiva)
                        {
                            if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                            {
                                oCamposDet = new CEntidadC();
                                oCamposDet.COD_ILEGAL = OUTPUTPARAM01;
                                oCamposDet.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                                oCamposDet.COD_ESPECIES = loDatos.COD_ESPECIES;
                                oCamposDet.DESCRIPCION_ESPECIE = loDatos.DESCRIPCION_ESPECIE;
                                oCamposDet.VOLUMEN = loDatos.VOLUMEN;
                                oCamposDet.NUMERO_INDIVIDUOS = loDatos.NUMERO_INDIVIDUOS;
                                oCamposDet.OBSERVACION = loDatos.OBSERVACION;
                                oCamposDet.COD_UCUENTA = oCEntidad.COD_UCUENTA;
                                oCamposDet.RegEstado = loDatos.RegEstado;
                                dBOracle.ManExecute(cn, tr, "doc_osinfor_erp_migracion.spILEGAL_MCORRECTIVA_ESPECIES_Grabar", oCamposDet);
                            }
                        }
                    }
                }

                //08/08/2018 CAR MEDIDAS CUATELARES ANTES DEL PAU
                if (oCEntidad.ListEspecies != null)
                {
                    if (oCEntidad.ListEspecies.Count > 0)
                    {
                        foreach (var loDatos in oCEntidad.ListEspecies)
                        {
                            if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                            {
                                oCamposDet = new CEntidadC();
                                oCamposDet.COD_ILEGAL = OUTPUTPARAM01;
                                oCamposDet.COD_ESPECIES = loDatos.COD_ESPECIES;
                                oCamposDet.COD_UCUENTA = oCEntidad.COD_UCUENTA;
                                oCamposDet.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                                //oCamposDet.RegEstado = loDatos.RegEstado;
                                dBOracle.ManExecute(cn, tr, "doc_osinfor_erp_migracion.spILEGAL_DET_ESPECIES_Grabar", oCamposDet);
                            }
                        }
                    }
                }

                if (oCEntidad.ListMedCautAPAU != null)
                {
                    if (oCEntidad.ListMedCautAPAU.Count > 0)
                    {
                        foreach (var loDatos in oCEntidad.ListMedCautAPAU)
                        {
                            oCamposDet = new CEntidadC();
                            oCamposDet.COD_ILEGAL = OUTPUTPARAM01;
                            oCamposDet.COD_ILEGAL_IALERTA_DETALLE = loDatos.COD_ILEGAL_IALERTA_DETALLE;
                            if (oCamposDet.COD_ILEGAL_IALERTA_DETALLE == "" || oCamposDet.COD_ILEGAL_IALERTA_DETALLE == null)
                            {
                                oCamposDet.RegEstado = 1; //nuevo
                                oCamposDet.COD_ILEGAL_IALERTA_DETALLE = "";
                            }
                            else
                            {
                                oCamposDet.RegEstado = 0; // modificar
                            }
                            oCamposDet.COD_UCUENTA = oCEntidad.COD_UCUENTA;
                            oCamposDet.GTF = loDatos.GTF;
                            oCamposDet.LIST_TROZAS = loDatos.LIST_TROZAS;
                            oCamposDet.PLAN_MANEJO = loDatos.PLAN_MANEJO;
                            oCamposDet.POA2 = loDatos.POA2;
                            oCamposDet.ESPECIES = loDatos.ESPECIES;
                            oCamposDet.DESCRIPCION = loDatos.DESCRIPCION;
                            oCamposDet.RECOMENDACION = loDatos.RECOMENDACION_IA;
                            //oCamposDet.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "doc_osinfor_erp_migracion.spILEGAL_IALERTA_DETALLE_Grabar", oCamposDet);

                        }
                    }
                }

                //agregando los registros de expediente de accion 20/09/2022 TGS
                if (oCEntidad.listSTD01 != null)
                {
                    foreach (var loDatos in oCEntidad.listSTD01)
                    {
                        if (loDatos.RegEstado == 1) //Nuevo o Modificado
                        {
                            oCamposDet = new CEntidadC();
                            oCamposDet.COD_ILEGAL = OUTPUTPARAM01;
                            oCamposDet.CODIGO = loDatos.CODIGO;
                            oCamposDet.NUMERO = loDatos.NUMERO;
                            oCamposDet.PDF_DOCUMENTO = loDatos.PDF_DOCUMENTO;
                            oCamposDet.TIPO_DOCUMENTO = loDatos.TIPO_DOCUMENTO;
                            oCamposDet.SUBTIPO = "01";
                            oCamposDet.RegEstado = 1;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spILEGAL_DET_ACCIONGrabar", oCamposDet);
                        }
                    }
                }
                if (oCEntidad.listSTD02 != null)
                {
                    foreach (var loDatos in oCEntidad.listSTD02)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            oCamposDet = new CEntidadC();
                            oCamposDet.COD_ILEGAL = OUTPUTPARAM01;
                            oCamposDet.CODIGO = loDatos.CODIGO;
                            oCamposDet.NUMERO = loDatos.NUMERO;
                            oCamposDet.PDF_DOCUMENTO = loDatos.PDF_DOCUMENTO;
                            oCamposDet.TIPO_DOCUMENTO = loDatos.TIPO_DOCUMENTO;
                            oCamposDet.SUBTIPO = "02";
                            oCamposDet.RegEstado = 1;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spILEGAL_DET_ACCIONGrabar", oCamposDet);
                        }
                    }
                }

                //ELIMINADO EXPEDIENTE
                if (oCEntidad.listEliTSTD01 != null)
                {
                    foreach (var loDatos in oCEntidad.listEliTSTD01)
                    {
                        oCamposDet = new CEntidadC();
                        oCamposDet.COD_ILEGAL = OUTPUTPARAM01;
                        oCamposDet.EliTABLA = loDatos.EliTABLA;
                        oCamposDet.EliVALOR01 = loDatos.EliVALOR01;
                        dBOracle.ManExecute(cn, tr, "doc_osinfor_erp_migracion.spILegalEliminarDetalle", oCamposDet);
                    }
                }

                //Grabando detalle Infracciones Subsanadas
                if (oCEntidad.ListIncisosSubsanados != null)
                {
                    foreach (var loDatos in oCEntidad.ListIncisosSubsanados)
                    {
                        oCamposDet = new CEntidadC();
                        oCamposDet.COD_ILEGAL = OUTPUTPARAM01;
                        oCamposDet.COD_ENCISOS = loDatos.COD_ENCISOS;
                        oCamposDet.RegEstado = loDatos.RegEstado;
                        dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spILEGAL_SUBSANADA_Grabar", oCamposDet);
                    }
                }

                //Eliminando detalle Infracciones Subsanadas
                if (oCEntidad.ListEliTABLAIncisosSubsanados != null)
                {
                    foreach (var loDatos in oCEntidad.ListEliTABLAIncisosSubsanados)
                    {
                        oCamposDet = new CEntidadC();
                        oCamposDet.COD_ILEGAL_SUBSANADA = loDatos.COD_ILEGAL_SUBSANADA;
                        oCamposDet.COD_ILEGAL = loDatos.COD_ILEGAL;
                        oCamposDet.COD_ENCISOS = loDatos.COD_ENCISOS;
                        oCamposDet.ESTADO = loDatos.ESTADO;
                        oCamposDet.RegEstado = loDatos.RegEstado;
                        dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spILEGAL_SUBSANADA_Grabar", oCamposDet);
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
        //public CEntidadC RegMostrarListaILEGALItem(SqlConnection cn, CEntidadC oCEntidad)
        //{
        //    CEntidadC lsCEntidad = new CEntidadC();
        //    try
        //    {
        //        using (SqlDataReader dr = oGDataSQL.SelDrdDefault(cn, null, "DOC.spILEGAL_MostrarItems", oCEntidad))
        //        {
        //            if (dr != null)
        //            {
        //                //05/08/2020 CARR ya no es necesario el metodo se eliminara cuando se concluya

        //                //lsCEntidad.ListInformesTemp = new List<CEntidadC>();
        //                lsCEntidad.ListEliTABLA = new List<CEntidadC>();
        //                lsCEntidad.ListIncisos = new List<CEntidadC>();
        //                lsCEntidad.ListEspeciesMCorrectiva = new List<CEntidadC>();
        //                lsCEntidad.ListEspecies = new List<CEntidadC>();
        //                lsCEntidad.ListMedCautAPAU = new List<CEntidadC>();
        //                //CEntPresupSuper ocampodet;
        //                CEntidadC ocampoEnt;

        //                if (dr.HasRows)
        //                {
        //                    dr.Read();
        //                    lsCEntidad.COD_FCTIPO = dr.GetString(dr.GetOrdinal("COD_FCTIPO"));
        //                    lsCEntidad.TIPO_FISCALIZA = dr.GetString(dr.GetOrdinal("TIPO_FISCALIZA"));
        //                    lsCEntidad.ILEGAL_NUMERO = dr.GetString(dr.GetOrdinal("ILEGAL_NUMERO"));
        //                    lsCEntidad.COD_PROFESIONAL = dr.GetString(dr.GetOrdinal("COD_PROFESIONAL"));
        //                    lsCEntidad.APELLIDOS_NOMBRES = dr.GetString(dr.GetOrdinal("APELLIDOS_NOMBRES"));
        //                    lsCEntidad.ILEGAL_FECHA_EMISION = dr.GetString(dr.GetOrdinal("ILEGAL_FECHA_EMISION"));
        //                    //lsCEntidad.ILEGAL_FECHA_DERIVACION = dr.GetString(dr.GetOrdinal("ILEGAL_FECHA_DERIVACION"));
        //                    lsCEntidad.PRESENTO_PROYECTO_RD = dr.GetBoolean(dr.GetOrdinal("PRESENTO_PROYECTO_RD"));
        //                    lsCEntidad.COD_ILEGAL_INF_SUP_TIPO = dr.GetString(dr.GetOrdinal("COD_ILEGAL_INF_SUP_TIPO"));
        //                    lsCEntidad.OBSERVACION = dr.GetString(dr.GetOrdinal("OBSERVACION"));

        //                    lsCEntidad.EVIDENCIA_IRREGULARIDAD = dr.GetBoolean(dr.GetOrdinal("EVIDENCIA_IRREGULARIDAD"));
        //                    lsCEntidad.BUEN_MANEJO = dr.GetBoolean(dr.GetOrdinal("BUEN_MANEJO"));
        //                    lsCEntidad.DEFICIENCIA_NOTIFICACION = dr.GetBoolean(dr.GetOrdinal("DEFICIENCIA_NOTIFICACION"));
        //                    lsCEntidad.DEFICIENCIA_TECNICA = dr.GetBoolean(dr.GetOrdinal("DEFICIENCIA_TECNICA"));
        //                    lsCEntidad.ARCHIVOS_OTROS = dr.GetString(dr.GetOrdinal("ARCHIVOS_OTROS"));

        //                    lsCEntidad.INSPECCION_OCULAR = dr.GetBoolean(dr.GetOrdinal("INSPECCION_OCULAR"));
        //                    lsCEntidad.EMITIR_RD_FINAL = dr.GetBoolean(dr.GetOrdinal("EMITIR_RD_FINAL"));
        //                    lsCEntidad.CADUCIDAD = dr.GetBoolean(dr.GetOrdinal("CADUCIDAD"));
        //                    lsCEntidad.AMPLIACION_PAU = dr.GetBoolean(dr.GetOrdinal("AMPLIACION_PAU"));
        //                    lsCEntidad.ACUMULACION_PAU = dr.GetBoolean(dr.GetOrdinal("ACUMULACION_PAU"));
        //                    lsCEntidad.MEDIDAS_CORRECTIVAS = dr.GetBoolean(dr.GetOrdinal("MEDIDAS_CORRECTIVAS"));
        //                    lsCEntidad.NUEVA_SUPERVISION = dr.GetBoolean(dr.GetOrdinal("NUEVA_SUPERVISION"));
        //                    lsCEntidad.OTROS_EVA_INSTRUCTIVA = dr.GetString(dr.GetOrdinal("OTROS_EVA_INSTRUCTIVA"));

        //                    lsCEntidad.CONFORME = dr.GetBoolean(dr.GetOrdinal("CONFORME"));
        //                    lsCEntidad.OBESERVACIONES = dr.GetString(dr.GetOrdinal("OBESERVACIONES"));

        //                    lsCEntidad.MEDIDA_CAUTELAR = dr.GetBoolean(dr.GetOrdinal("MEDIDA_CAUTELAR"));
        //                    lsCEntidad.FIN_PAU = dr.GetBoolean(dr.GetOrdinal("FIN_PAU"));
        //                    lsCEntidad.IMPROCEDENTE = dr.GetBoolean(dr.GetOrdinal("IMPROCEDENTE"));
        //                    lsCEntidad.FUNDADA = dr.GetBoolean(dr.GetOrdinal("FUNDADA"));
        //                    lsCEntidad.FUNDADA_PARTE = dr.GetBoolean(dr.GetOrdinal("FUNDADA_PARTE"));
        //                    lsCEntidad.INFUNDADA = dr.GetBoolean(dr.GetOrdinal("INFUNDADA"));
        //                    lsCEntidad.PRUEBAS_PRESENTADAS = dr.GetString(dr.GetOrdinal("PRUEBAS_PRESENTADAS"));

        //                    lsCEntidad.MOTIVO = dr.GetString(dr.GetOrdinal("MOTIVO"));
        //                    lsCEntidad.RECOMENDACION = dr.GetString(dr.GetOrdinal("RECOMENDACION"));
        //                    lsCEntidad.COD_OD_REGISTRO = dr.GetString(dr.GetOrdinal("COD_OD_REGISTRO"));

        //                    lsCEntidad.PUBLICAR = dr.GetBoolean(dr.GetOrdinal("PUBLICAR"));
        //                    lsCEntidad.MUERTE_TITULAR = dr.GetBoolean(dr.GetOrdinal("MUERTE_TITULAR"));
        //                    lsCEntidad.NSUPERV_RECOM = dr.GetBoolean(dr.GetOrdinal("NSUPERV_RECOM"));
        //                    //MODIFICACION DEL FORMULARIO INFORME LEGAL 10/05/2016
        //                    lsCEntidad.SANCION = dr.GetBoolean(dr.GetOrdinal("SANCION"));
        //                    lsCEntidad.AMONESTACIONES = dr.GetBoolean(dr.GetOrdinal("AMONESTACIONES"));
        //                    lsCEntidad.ARCHIVO = dr.GetBoolean(dr.GetOrdinal("ARCHIVO"));
        //                    lsCEntidad.MEDIDA_PREVISORIA = dr.GetBoolean(dr.GetOrdinal("MED_PROVISORIA"));
        //                    lsCEntidad.MEDIDA_PREVISORIA_OBS = dr.GetString(dr.GetOrdinal("MED_PROVISORIA_OBS"));
        //                    lsCEntidad.PROCEDENTE = dr.GetBoolean(dr.GetOrdinal("PROCEDENTE"));
        //                    lsCEntidad.FUERA_PLAZO = dr.GetBoolean(dr.GetOrdinal("FUERA_PLAZO"));
        //                    lsCEntidad.FALTA_PRUEBAS = dr.GetBoolean(dr.GetOrdinal("FALTA_PRUEBAS"));
        //                    lsCEntidad.INFUNDADO_OBS = dr.GetString(dr.GetOrdinal("INFUNDADO_OBS"));
        //                    lsCEntidad.NUEVA_NOTIFICACION = dr.GetBoolean(dr.GetOrdinal("NUEVA_NOTIFICACION"));
        //                    lsCEntidad.VARIAR_MED_CAUT = dr.GetString(dr.GetOrdinal("VARIAR_MED_CAUT"));
        //                    lsCEntidad.RECTIFICACION_EMATERIAL = dr.GetBoolean(dr.GetOrdinal("RECTIFICACION_EMATERIAL"));

        //                    lsCEntidad.INFDIR = dr.GetBoolean(dr.GetOrdinal("INFDIR"));
        //                    lsCEntidad.INFSUBDIR = dr.GetBoolean(dr.GetOrdinal("INFSUBDIR"));
        //                    lsCEntidad.USUARIO_REGISTRO = dr.GetString(dr.GetOrdinal("USUARIO_REGISTRO"));

        //                    //Nuevos campos - evaluación informe de supervisión
        //                    lsCEntidad.MCORRECTIVA = dr.GetBoolean(dr.GetOrdinal("MCORRECTIVA"));
        //                    lsCEntidad.DESCRIPCION_MCORRECTIVA = dr.GetString(dr.GetOrdinal("DESCRIPCION_MCORRECTIVA"));
        //                    lsCEntidad.DIA_IMPLEMENT_MCORRECTIVA = dr.GetInt32(dr.GetOrdinal("DIA_IMPLEMENT_MCORRECTIVA"));
        //                    lsCEntidad.DIA_INFORME_MCORRECTIVA = dr.GetInt32(dr.GetOrdinal("DIA_INFORME_MCORRECTIVA"));
        //                    lsCEntidad.MES_IMPLEMENT_MCORRECTIVA = dr.GetInt32(dr.GetOrdinal("MES_IMPLEMENT_MCORRECTIVA"));
        //                    lsCEntidad.MES_INFORME_MCORRECTIVA = dr.GetInt32(dr.GetOrdinal("MES_INFORME_MCORRECTIVA"));
        //                    lsCEntidad.ANIO_IMPLEMENT_MCORRECTIVA = dr.GetInt32(dr.GetOrdinal("ANIO_IMPLEMENT_MCORRECTIVA"));
        //                    lsCEntidad.ANIO_INFORME_MCORRECTIVA = dr.GetInt32(dr.GetOrdinal("ANIO_INFORME_MCORRECTIVA"));
        //                    lsCEntidad.MANDATO = dr.GetBoolean(dr.GetOrdinal("MANDATO"));
        //                    lsCEntidad.DESCRIPCION_MANDATO = dr.GetString(dr.GetOrdinal("DESCRIPCION_MANDATO"));

        //                    // CAR 08/08/2018 MEDIDAS CAUTELARES ANTES DEL PAU
        //                    lsCEntidad.GTF = dr.GetBoolean(dr.GetOrdinal("GTF"));
        //                    lsCEntidad.LIST_TROZAS = dr.GetBoolean(dr.GetOrdinal("LIST_TROZAS"));
        //                    lsCEntidad.PLAN_MANEJO = dr.GetBoolean(dr.GetOrdinal("PLAN_MANEJO"));
        //                    lsCEntidad.POA2 = dr.GetBoolean(dr.GetOrdinal("_POA"));
        //                    lsCEntidad.ESPECIES = dr.GetBoolean(dr.GetOrdinal("ESPECIE"));
        //                    lsCEntidad.DESCRIPCION = dr.GetString(dr.GetOrdinal("DESCRIPCION"));
        //                    lsCEntidad.RECOMENDACION_IA = dr.GetString(dr.GetOrdinal("RECOMENDACION_IA"));
        //                    lsCEntidad.COD_ILEGAL_IALERTA_DETALLE = dr.GetString(dr.GetOrdinal("COD_ILEGAL_IALERTA_DETALLE"));

        //                }
        //                //Estado (Calidad)
        //                dr.NextResult();
        //                if (dr.HasRows)
        //                {
        //                    dr.Read();
        //                    lsCEntidad.COD_ESTADO_DOC = dr.GetString(dr.GetOrdinal("COD_ESTADO_DOC"));
        //                    lsCEntidad.OBSERVACIONES_CONTROL = dr.GetString(dr.GetOrdinal("OBSERVACIONES_CONTROL"));
        //                    lsCEntidad.OBSERV_SUBSANAR = dr.GetBoolean(dr.GetOrdinal("OBSERV_SUBSANAR"));
        //                    lsCEntidad.USUARIO_CONTROL = dr.GetString(dr.GetOrdinal("USUARIO_CONTROL"));
        //                }
        //                else
        //                {
        //                    lsCEntidad.COD_ESTADO_DOC = "";
        //                    lsCEntidad.OBSERVACIONES_CONTROL = "";
        //                    lsCEntidad.OBSERV_SUBSANAR = false;
        //                    lsCEntidad.USUARIO_CONTROL = "";
        //                }
        //                //Lista de INFORMES / EXPEDIENTES / RENUNCIAS
        //                dr.NextResult();
        //                if (dr.HasRows)
        //                {
        //                    while (dr.Read())
        //                    {
        //                        ocampoEnt = new CEntidadC();
        //                        ocampoEnt.COD_ILEGAL = dr["COD_ILEGAL"].ToString();
        //                        ocampoEnt.COD_INFORME = dr["COD_INFORME"].ToString();
        //                        ocampoEnt.COD_RESODIREC = dr["COD_RESODIREC"].ToString();
        //                        ocampoEnt.COD_RESODIREC_INI_PAU = dr["COD_RESODIREC_INI_PAU"].ToString();
        //                        ocampoEnt.NUMERO = dr["NUMERO"].ToString();
        //                        ocampoEnt.D_LINEA = dr["D_LINEA"].ToString();
        //                        ocampoEnt.NUM_THABILITANTE = dr["NUM_THABILITANTE"].ToString();
        //                        ocampoEnt.TITULAR = dr["TITULAR"].ToString();
        //                        ocampoEnt.RegEstado = 0;
        //                        //05/08/2020 ya no es necesario
        //                        // lsCEntidad.ListInformesTemp.Add(ocampoEnt);
        //                    }
        //                }
        //                //Infracciones Presuntamente Incurridas
        //                dr.NextResult();
        //                if (dr.HasRows)
        //                {
        //                    int pt0 = dr.GetOrdinal("COD_ILEGAL_ENCISOS");
        //                    int pt1 = dr.GetOrdinal("DESCRIPCION_ARTICULOS");
        //                    int pt2 = dr.GetOrdinal("DESCRIPCION_ENCISOS");
        //                    int pt4 = dr.GetOrdinal("COD_ILEGAL");
        //                    int pt5 = dr.GetOrdinal("COD_SECUENCIAL");
        //                    while (dr.Read())
        //                    {
        //                        ocampoEnt = new CEntidadC();
        //                        ocampoEnt.COD_ILEGAL_ENCISOS = dr.GetString(pt0);
        //                        ocampoEnt.DESCRIPCION_ARTICULOS = dr.GetString(pt1);
        //                        ocampoEnt.DESCRIPCION_ENCISOS = dr.GetString(pt2);
        //                        ocampoEnt.COD_ILEGAL = dr.GetString(pt4);
        //                        ocampoEnt.COD_SECUENCIAL = dr.GetInt32(pt5);
        //                        ocampoEnt.RegEstado = 0;
        //                        lsCEntidad.ListIncisos.Add(ocampoEnt);
        //                    }
        //                }
        //                //Especies medidas correctivas
        //                dr.NextResult();
        //                if (dr.HasRows)
        //                {
        //                    while (dr.Read())
        //                    {
        //                        ocampoEnt = new CEntidadC();
        //                        ocampoEnt.COD_SECUENCIAL = dr.GetInt32(dr.GetOrdinal("COD_SECUENCIAL"));
        //                        ocampoEnt.COD_ESPECIES = dr.GetString(dr.GetOrdinal("COD_ESPECIES"));
        //                        ocampoEnt.DESCRIPCION_ESPECIE = dr.GetString(dr.GetOrdinal("DESCRIPCION_ESPECIE"));
        //                        ocampoEnt.VOLUMEN = dr.GetDecimal(dr.GetOrdinal("VOLUMEN"));
        //                        ocampoEnt.NUMERO_INDIVIDUOS = dr.GetInt32(dr.GetOrdinal("NUMERO_INDIVIDUOS"));
        //                        ocampoEnt.OBSERVACION = dr.GetString(dr.GetOrdinal("OBSERVACION"));
        //                        ocampoEnt.RegEstado = 0;
        //                        lsCEntidad.ListEspeciesMCorrectiva.Add(ocampoEnt);
        //                    }
        //                }
        //                // CAR 08/08/2018 LISTA DE ESPECIES DE MEDIDAS CAUTELARES ANTES DEL PAU
        //                dr.NextResult();
        //                if (dr.HasRows)
        //                {
        //                    while (dr.Read())
        //                    {
        //                        ocampoEnt = new CEntidadC();
        //                        ocampoEnt.COD_ESPECIES = dr.GetString(dr.GetOrdinal("COD_ESPECIES"));
        //                        ocampoEnt.DESCRIPCION_ESPECIE = dr.GetString(dr.GetOrdinal("DESCRIPCION_ESPECIE"));
        //                        ocampoEnt.RegEstado = 0;
        //                        lsCEntidad.ListEspecies.Add(ocampoEnt);
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
        //public List<CEntidadC> RegMostrarINFORME_Bucar(SqlConnection cn, CEntidadC oCEntidad)
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
        //                        oCampos.COD_ILEGAL = dr["COD_ILEGAL"].ToString();
        //                        oCampos.COD_INFORME = dr["COD_INFORME"].ToString();
        //                        oCampos.COD_RESODIREC = dr["COD_RESODIREC"].ToString();
        //                        oCampos.COD_RESODIREC_INI_PAU = dr["COD_RESODIREC_INI_PAU"].ToString();
        //                        oCampos.NUMERO = dr["NUMERO"].ToString();
        //                        oCampos.D_LINEA = dr["D_LINEA"].ToString();
        //                        oCampos.NUM_THABILITANTE = dr["NUM_THABILITANTE"].ToString();
        //                        oCampos.TITULAR = dr["TITULAR"].ToString();
        //                        oCampos.COD_INFORME_ALERTA = dr["COD_INFORME_ALERTA"].ToString();
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
        public CEntidadC RegMostListPOAs(OracleConnection cn, CEntidadC oCEntidad)
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
                        //Lista de POAS
                        lsDetDetalle = new List<CEntidadC>();
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("NUM_POA");
                            int pt2 = dr.GetOrdinal("POA");
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidadC();
                                oCamposDet.NUM_POA = dr.GetString(pt1);
                                oCamposDet.POA = dr.GetString(pt2);
                                oCamposDet.RegEstado = 0;
                                lsDetDetalle.Add(oCamposDet);
                            }
                        }
                        oCampos.ListPOAs = lsDetDetalle;
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
        public Int32 RegPreProcesarObservatorio(OracleConnection cn, CEntidadC oCEntidad)
        {
            OracleTransaction tr = null;
            Int32 OUTPUTPARAM03 = 0;
            try
            {
                tr = cn.BeginTransaction();
                //Grabando Cabecera
                using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, tr, "HERR_OSINFOR_ERP_MIGRACION.spPROCESAMIENTO_OBSERVATORIO_v3", oCEntidad))
                {
                    cmd.ExecuteNonQuery();
                    OUTPUTPARAM03 = Int32.Parse(cmd.Parameters["OUTPUTPARAM03"].Value.ToString());
                }
                tr.Commit();
                return OUTPUTPARAM03;
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
        //public Int32 RegPublicarObservatorio(SqlConnection cn, CEntidadC oCEntidad)
        //{
        //    SqlTransaction tr = null;
        //    Int32 OUTPUTPARAM03 = 0;
        //    try
        //    {
        //        tr = cn.BeginTransaction();
        //        //Grabando Cabecera
        //        using (SqlCommand cmd = oGDataSQL.ManExecuteOutput(cn, tr, "HERR.spPUBLI_INMEDIATO_OBSERVATORIO", oCEntidad))
        //        {
        //            cmd.ExecuteNonQuery();
        //            OUTPUTPARAM03 = (Int32)cmd.Parameters["@OUTPUTPARAM01"].Value;
        //        }
        //        tr.Commit();
        //        return OUTPUTPARAM03;
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
        //public List<CEntidadC> List_EncisosIL(SqlConnection cn, CEntidadC oCEntidad)
        //{
        //    List<CEntidadC> lsCEntidad = new List<CEntidadC>();
        //    try
        //    {
        //        using (SqlDataReader dr = oGDataSQL.SelDrdResult(cn, null, "DOC.spRInfraccionesLegal0", oCEntidad))
        //        {
        //            if (dr != null)
        //            {
        //                if (dr.HasRows)
        //                {
        //                    int p1 = dr.GetOrdinal("COD_RESODIREC_INI_PAU");
        //                    int p2 = dr.GetOrdinal("COD_ILEGAL_ENCISOS");
        //                    int p4 = dr.GetOrdinal("ARTICULO");
        //                    int p5 = dr.GetOrdinal("ENCISO");

        //                    CEntidadC oCampos;
        //                    while (dr.Read())
        //                    {
        //                        oCampos = new CEntidadC();
        //                        oCampos.COD_RESODIREC_INI_PAU = dr.GetString(p1);
        //                        oCampos.COD_ILEGAL_ENCISOS = dr.GetString(p2);
        //                        oCampos.DESCRIPCION_ARTICULOS = dr.GetString(p4);
        //                        oCampos.DESCRIPCION_ENCISOS = dr.GetString(p5);
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
                        //Tipos Recomendaciones
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
                        oCampos.ListTiposRecom = lsDetDetalle;

                        //Especies Maderable
                        dr.NextResult();
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
                        oCampos.ListMComboEspecieForestal = lsDetDetalle;

                    }
                }
                return oCampos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region conecion a oracle v3
        public CEntidadC RegMostrarItem_v3(CEntidadC oCEntidad)
        {
            CEntidadC lsCEntidad = new CEntidadC();
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "doc_osinfor_erp_migracion.spILEGAL_MostrarItems", oCEntidad))
                    {
                        if (dr != null)
                        {
                            lsCEntidad.ListInformesTemp = new List<Ent_INFORME_CONSULTA_LEGAL>();
                            lsCEntidad.ListEliTABLA = new List<CEntidadC>();
                            lsCEntidad.ListIncisos = new List<CEntidadC>();
                            lsCEntidad.ListEspeciesMCorrectiva = new List<CEntidadC>();
                            lsCEntidad.ListEspecies = new List<CEntidadC>();
                            lsCEntidad.ListMedCautAPAU = new List<CEntidadC>();
                            //CEntPresupSuper ocampodet;

                            //20/09/2022 TGS
                            lsCEntidad.listSTD01 = new List<CEntidadC>();
                            lsCEntidad.listSTD02 = new List<CEntidadC>();
                            lsCEntidad.listSTD03 = new List<CEntidadC>();
                            lsCEntidad.ListIncisosSubsanados = new List<CEntidadC>();

                            CEntidadC ocampoEnt;

                            if (dr.HasRows)
                            {
                                dr.Read();
                                lsCEntidad.COD_ILEGAL = dr.GetString(dr.GetOrdinal("cod_ilegal"));
                                lsCEntidad.COD_FCTIPO = dr.GetString(dr.GetOrdinal("COD_FCTIPO"));
                                lsCEntidad.TIPO_FISCALIZA = dr.GetString(dr.GetOrdinal("TIPO_FISCALIZA"));
                                lsCEntidad.ILEGAL_NUMERO = dr["ILEGAL_NUMERO"] != DBNull.Value ? dr.GetString(dr.GetOrdinal("ILEGAL_NUMERO")) : null;
                                lsCEntidad.COD_PROFESIONAL = dr.GetString(dr.GetOrdinal("COD_PROFESIONAL"));
                                lsCEntidad.APELLIDOS_NOMBRES = dr.GetString(dr.GetOrdinal("APELLIDOS_NOMBRES"));
                                lsCEntidad.ILEGAL_FECHA_EMISION = dr["ILEGAL_FECHA_EMISION"] != DBNull.Value ? dr.GetString(dr.GetOrdinal("ILEGAL_FECHA_EMISION")) : "";
                                //lsCEntidad.ILEGAL_FECHA_DERIVACION = dr.GetString(dr.GetOrdinal("ILEGAL_FECHA_DERIVACION"));
                                lsCEntidad.PRESENTO_PROYECTO_RD = dr.GetBoolean(dr.GetOrdinal("PRESENTO_PROYECTO_RD"));
                                lsCEntidad.COD_ILEGAL_INF_SUP_TIPO = dr.GetString(dr.GetOrdinal("COD_ILEGAL_INF_SUP_TIPO"));
                                lsCEntidad.OBSERVACION = dr.GetString(dr.GetOrdinal("OBSERVACION"));
                                lsCEntidad.EVIDENCIA_IRREGULARIDAD = dr.GetBoolean(dr.GetOrdinal("EVIDENCIA_IRREGULARIDAD"));
                                lsCEntidad.BUEN_MANEJO = dr.GetBoolean(dr.GetOrdinal("BUEN_MANEJO"));
                                lsCEntidad.DEFICIENCIA_NOTIFICACION = dr.GetBoolean(dr.GetOrdinal("DEFICIENCIA_NOTIFICACION"));
                                lsCEntidad.DEFICIENCIA_TECNICA = dr.GetBoolean(dr.GetOrdinal("DEFICIENCIA_TECNICA"));
                                lsCEntidad.ARCHIVOS_OTROS = dr.GetString(dr.GetOrdinal("ARCHIVOS_OTROS"));
                                lsCEntidad.INSPECCION_OCULAR = dr.GetBoolean(dr.GetOrdinal("INSPECCION_OCULAR"));
                                lsCEntidad.EMITIR_RD_FINAL = dr.GetBoolean(dr.GetOrdinal("EMITIR_RD_FINAL"));
                                lsCEntidad.CADUCIDAD = dr.GetBoolean(dr.GetOrdinal("CADUCIDAD"));
                                lsCEntidad.AMPLIACION_PAU = dr.GetBoolean(dr.GetOrdinal("AMPLIACION_PAU"));
                                lsCEntidad.ACUMULACION_PAU = dr.GetBoolean(dr.GetOrdinal("ACUMULACION_PAU"));
                                lsCEntidad.MEDIDAS_CORRECTIVAS = dr.GetBoolean(dr.GetOrdinal("MEDIDAS_CORRECTIVAS"));
                                lsCEntidad.NUEVA_SUPERVISION = dr.GetBoolean(dr.GetOrdinal("NUEVA_SUPERVISION"));
                                lsCEntidad.OTROS_EVA_INSTRUCTIVA = dr.GetString(dr.GetOrdinal("OTROS_EVA_INSTRUCTIVA"));
                                lsCEntidad.CONFORME = dr.GetBoolean(dr.GetOrdinal("CONFORME"));
                                lsCEntidad.OBESERVACIONES = dr.GetString(dr.GetOrdinal("OBESERVACIONES"));
                                lsCEntidad.MEDIDA_CAUTELAR = dr.GetBoolean(dr.GetOrdinal("MEDIDA_CAUTELAR"));
                                lsCEntidad.FIN_PAU = dr.GetBoolean(dr.GetOrdinal("FIN_PAU"));
                                lsCEntidad.IMPROCEDENTE = dr.GetBoolean(dr.GetOrdinal("IMPROCEDENTE"));
                                lsCEntidad.FUNDADA = dr.GetBoolean(dr.GetOrdinal("FUNDADA"));
                                lsCEntidad.FUNDADA_PARTE = dr.GetBoolean(dr.GetOrdinal("FUNDADA_PARTE"));
                                lsCEntidad.INFUNDADA = dr.GetBoolean(dr.GetOrdinal("INFUNDADA"));
                                lsCEntidad.PRUEBAS_PRESENTADAS = dr.GetString(dr.GetOrdinal("PRUEBAS_PRESENTADAS"));
                                lsCEntidad.MOTIVO = dr.GetString(dr.GetOrdinal("MOTIVO"));
                                lsCEntidad.RECOMENDACION = dr.GetString(dr.GetOrdinal("RECOMENDACION"));
                                lsCEntidad.COD_OD_REGISTRO = dr.GetString(dr.GetOrdinal("COD_OD_REGISTRO"));
                                lsCEntidad.PUBLICAR = dr.GetBoolean(dr.GetOrdinal("PUBLICAR"));
                                lsCEntidad.MUERTE_TITULAR = dr.GetBoolean(dr.GetOrdinal("MUERTE_TITULAR"));
                                lsCEntidad.NSUPERV_RECOM = dr.GetBoolean(dr.GetOrdinal("NSUPERV_RECOM"));
                                //MODIFICACION DEL FORMULARIO INFORME LEGAL 10/05/2016
                                lsCEntidad.SANCION = dr.GetBoolean(dr.GetOrdinal("SANCION"));
                                lsCEntidad.AMONESTACIONES = dr.GetBoolean(dr.GetOrdinal("AMONESTACIONES"));
                                lsCEntidad.ARCHIVO = dr.GetBoolean(dr.GetOrdinal("ARCHIVO"));
                                lsCEntidad.MEDIDA_PREVISORIA = dr.GetBoolean(dr.GetOrdinal("MED_PROVISORIA"));
                                lsCEntidad.MEDIDA_PREVISORIA_OBS = dr.GetString(dr.GetOrdinal("MED_PROVISORIA_OBS"));
                                lsCEntidad.PROCEDENTE = dr.GetBoolean(dr.GetOrdinal("PROCEDENTE"));
                                lsCEntidad.FUERA_PLAZO = dr.GetBoolean(dr.GetOrdinal("FUERA_PLAZO"));
                                lsCEntidad.FALTA_PRUEBAS = dr.GetBoolean(dr.GetOrdinal("FALTA_PRUEBAS"));
                                lsCEntidad.INFUNDADO_OBS = dr.GetString(dr.GetOrdinal("INFUNDADO_OBS"));
                                lsCEntidad.NUEVA_NOTIFICACION = dr.GetBoolean(dr.GetOrdinal("NUEVA_NOTIFICACION"));
                                lsCEntidad.VARIAR_MED_CAUT = dr.GetString(dr.GetOrdinal("VARIAR_MED_CAUT"));
                                lsCEntidad.RECTIFICACION_EMATERIAL = dr.GetBoolean(dr.GetOrdinal("RECTIFICACION_EMATERIAL"));
                                lsCEntidad.INFDIR = dr.GetBoolean(dr.GetOrdinal("INFDIR"));
                                lsCEntidad.INFSUBDIR = dr.GetBoolean(dr.GetOrdinal("INFSUBDIR"));
                                lsCEntidad.USUARIO_REGISTRO = dr.GetString(dr.GetOrdinal("USUARIO_REGISTRO"));

                                //Nuevos campos - evaluación informe de supervisión
                                lsCEntidad.MCORRECTIVA = dr.GetBoolean(dr.GetOrdinal("MCORRECTIVA"));
                                lsCEntidad.DESCRIPCION_MCORRECTIVA = dr.GetString(dr.GetOrdinal("DESCRIPCION_MCORRECTIVA"));
                                lsCEntidad.DIA_IMPLEMENT_MCORRECTIVA = dr.GetInt32(dr.GetOrdinal("DIA_IMPLEMENT_MCORRECTIVA"));
                                lsCEntidad.DIA_INFORME_MCORRECTIVA = dr.GetInt32(dr.GetOrdinal("DIA_INFORME_MCORRECTIVA"));
                                lsCEntidad.MES_IMPLEMENT_MCORRECTIVA = dr.GetInt32(dr.GetOrdinal("MES_IMPLEMENT_MCORRECTIVA"));
                                lsCEntidad.MES_INFORME_MCORRECTIVA = dr.GetInt32(dr.GetOrdinal("MES_INFORME_MCORRECTIVA"));
                                lsCEntidad.ANIO_IMPLEMENT_MCORRECTIVA = dr.GetInt32(dr.GetOrdinal("ANIO_IMPLEMENT_MCORRECTIVA"));
                                lsCEntidad.ANIO_INFORME_MCORRECTIVA = dr.GetInt32(dr.GetOrdinal("ANIO_INFORME_MCORRECTIVA"));
                                lsCEntidad.MANDATO = dr.GetBoolean(dr.GetOrdinal("MANDATO"));
                                lsCEntidad.DESCRIPCION_MANDATO = dr.GetString(dr.GetOrdinal("DESCRIPCION_MANDATO"));

                                // CAR 08/08/2018 MEDIDAS CAUTELARES ANTES DEL PAU
                                lsCEntidad.GTF = dr.GetBoolean(dr.GetOrdinal("GTF"));
                                lsCEntidad.LIST_TROZAS = dr.GetBoolean(dr.GetOrdinal("LIST_TROZAS"));
                                lsCEntidad.PLAN_MANEJO = dr.GetBoolean(dr.GetOrdinal("PLAN_MANEJO"));
                                lsCEntidad.POA2 = dr.GetBoolean(dr.GetOrdinal("POA"));
                                lsCEntidad.ESPECIES = dr.GetBoolean(dr.GetOrdinal("ESPECIE"));
                                lsCEntidad.DESCRIPCION = dr.GetString(dr.GetOrdinal("DESCRIPCION"));
                                lsCEntidad.RECOMENDACION_IA = dr.GetString(dr.GetOrdinal("RECOMENDACION_IA"));
                                lsCEntidad.COD_ILEGAL_IALERTA_DETALLE = dr.GetString(dr.GetOrdinal("COD_ILEGAL_IALERTA_DETALLE"));

                                //CARR 27/08/2020 AGREGANDO NUEVAS VARIABLES
                                lsCEntidad.IF_INEXESP = dr.GetBoolean(dr.GetOrdinal("INEX_ESP"));
                                lsCEntidad.IF_DIFESP = dr.GetBoolean(dr.GetOrdinal("DIF_ESP"));
                                lsCEntidad.IF_SOBREVOL = dr.GetBoolean(dr.GetOrdinal("SOBRE_VOL"));

                                //22.09.2022 TGS
                                lsCEntidad.COD_TERCERO_SOLIDARIO = dr.GetString(dr.GetOrdinal("COD_TERCERO_SOLIDARIO"));
                                lsCEntidad.TERCERO_SOLIDARIO = dr.GetString(dr.GetOrdinal("TERCERO_SOLIDARIO"));

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
                            //Lista de INFORMES / EXPEDIENTES / RENUNCIAS
                            dr.NextResult();
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    Ent_INFORME_CONSULTA_LEGAL cEntidadIL = new Ent_INFORME_CONSULTA_LEGAL();
                                    cEntidadIL.COD_INFORME = dr["COD_INFORME"].ToString();
                                    cEntidadIL.COD_RESODIREC = dr["COD_RESODIREC"].ToString();
                                    cEntidadIL.COD_RESODIREC_INI_PAU = dr["COD_RESODIREC_INI_PAU"].ToString();
                                    cEntidadIL.NUM_INFORME = dr["NUMERO"].ToString();
                                    cEntidadIL.DLINEA = dr["D_LINEA"].ToString();
                                    cEntidadIL.NUM_THABILITANTE = dr["NUM_THABILITANTE"].ToString();
                                    cEntidadIL.TITULAR = dr["TITULAR"].ToString();
                                    cEntidadIL.RegEstado = 0;
                                    lsCEntidad.ListInformesTemp.Add(cEntidadIL);
                                }
                            }
                            //Infracciones Presuntamente Incurridas
                            dr.NextResult();
                            if (dr.HasRows)
                            {
                                int pt0 = dr.GetOrdinal("COD_ILEGAL_ENCISOS");
                                int pt1 = dr.GetOrdinal("DESCRIPCION_ARTICULOS");
                                int pt2 = dr.GetOrdinal("DESCRIPCION_ENCISOS");
                                int pt4 = dr.GetOrdinal("COD_ILEGAL");
                                int pt5 = dr.GetOrdinal("COD_SECUENCIAL");
                                int pt6 = dr.GetOrdinal("cod_ilegal_articulos");
                                while (dr.Read())
                                {
                                    ocampoEnt = new CEntidadC();
                                    ocampoEnt.COD_ILEGAL_ENCISOS = dr.GetString(pt0);
                                    ocampoEnt.DESCRIPCION_ARTICULOS = dr.GetString(pt1);
                                    ocampoEnt.DESCRIPCION_ENCISOS = dr.GetString(pt2);
                                    ocampoEnt.COD_ILEGAL = dr.GetString(pt4);
                                    ocampoEnt.COD_SECUENCIAL = dr.GetInt32(pt5);
                                    ocampoEnt.COD_ILEGAL_ARTICULOS = dr.GetString(pt6);
                                    ocampoEnt.RegEstado = 0;
                                    lsCEntidad.ListIncisos.Add(ocampoEnt);
                                }
                            }
                            //Especies medidas correctivas
                            dr.NextResult();
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    ocampoEnt = new CEntidadC();
                                    ocampoEnt.COD_SECUENCIAL = dr.GetInt32(dr.GetOrdinal("COD_SECUENCIAL"));
                                    ocampoEnt.COD_ESPECIES = dr.GetString(dr.GetOrdinal("COD_ESPECIES"));
                                    ocampoEnt.DESCRIPCION_ESPECIE = dr.GetString(dr.GetOrdinal("DESCRIPCION_ESPECIE"));
                                    ocampoEnt.VOLUMEN = dr.GetDecimal(dr.GetOrdinal("VOLUMEN"));
                                    ocampoEnt.NUMERO_INDIVIDUOS = dr.GetInt32(dr.GetOrdinal("NUMERO_INDIVIDUOS"));
                                    ocampoEnt.OBSERVACION = dr.GetString(dr.GetOrdinal("OBSERVACION"));
                                    ocampoEnt.RegEstado = 0;
                                    lsCEntidad.ListEspeciesMCorrectiva.Add(ocampoEnt);
                                }
                            }
                            // CAR 08/08/2018 LISTA DE ESPECIES DE MEDIDAS CAUTELARES ANTES DEL PAU
                            dr.NextResult();
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    ocampoEnt = new CEntidadC();
                                    ocampoEnt.COD_ESPECIES = dr.GetString(dr.GetOrdinal("COD_ESPECIES"));
                                    ocampoEnt.DESCRIPCION_ESPECIE = dr.GetString(dr.GetOrdinal("DESCRIPCION_ESPECIE"));
                                    ocampoEnt.COD_SECUENCIAL = dr.GetInt32(dr.GetOrdinal("cod_secuencial"));
                                    ocampoEnt.RegEstado = 0;
                                    lsCEntidad.ListEspecies.Add(ocampoEnt);
                                }
                            }

                            //20/09/2022 TGS
                            //lista de expedientes de allanamiento / subsanacion
                            dr.NextResult();
                            if (dr.HasRows)
                            {
                                CEntidadC oCEntidadSTD = new CEntidadC();

                                while (dr.Read())
                                {
                                    oCEntidadSTD = new CEntidadC();
                                    oCEntidadSTD.COD_ILACCION = dr.GetString(dr.GetOrdinal("COD_ILACCION"));
                                    oCEntidadSTD.CODIGO = dr["CODIGO"] != DBNull.Value ? dr["CODIGO"].ToString() : null;
                                    oCEntidadSTD.NUMERO = dr["NUMERO"] != DBNull.Value ? dr["NUMERO"].ToString() : null;
                                    oCEntidadSTD.TIPO_DOCUMENTO = dr["TIPO"] != DBNull.Value ? dr["TIPO"].ToString() : null;
                                    oCEntidadSTD.PDF_DOCUMENTO = dr["DESCARGA"] != DBNull.Value ? dr["DESCARGA"].ToString() : null;
                                    oCEntidadSTD.RegEstado = 0;

                                    string SUBTIPO = dr["SUBTIPO"] != DBNull.Value ? dr["SUBTIPO"].ToString() : null;
                                    if (SUBTIPO == "01") lsCEntidad.listSTD01.Add(oCEntidadSTD);
                                    else if (SUBTIPO == "02") lsCEntidad.listSTD02.Add(oCEntidadSTD);
                                    else lsCEntidad.listSTD03.Add(oCEntidadSTD);
                                }
                            }

                            //Infracciones Subsanadas
                            dr.NextResult();
                            if (dr.HasRows)
                            {
                                CEntidadC oCEntidadSTD = new CEntidadC();

                                while (dr.Read())
                                {
                                    oCEntidadSTD = new CEntidadC();
                                    oCEntidadSTD.COD_ILEGAL_SUBSANADA = dr["COD_ILEGAL_SUBSANADA"].ToString();
                                    oCEntidadSTD.COD_ILEGAL = dr["COD_ILEGAL"].ToString();
                                    oCEntidadSTD.COD_ENCISOS = dr["COD_ENCISOS"].ToString();
                                    oCEntidadSTD.INCISO = dr["INCISO"].ToString();
                                    oCEntidadSTD.ARTICULO = dr["ARTICULO"].ToString();
                                    oCEntidadSTD.RegEstado = 0;
                                    lsCEntidad.ListIncisosSubsanados.Add(oCEntidadSTD);
                                }
                            }
                        }
                    }
                    cn.Close();
                }
                return lsCEntidad;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Ent_INFORME_CONSULTA_LEGAL RegMostrarINFORME_Bucar_v3(OracleConnection cn, CEntidadC oCEntidad)
        {
            Ent_INFORME_CONSULTA_LEGAL busqueda = new Ent_INFORME_CONSULTA_LEGAL();
            busqueda.listBusqueda = new List<Ent_INFORME_CONSULTA_LEGAL>();

            List<Ent_INFORME_CONSULTA_LEGAL> lsCEntidad = new List<Ent_INFORME_CONSULTA_LEGAL>();
            Ent_INFORME_CONSULTA_LEGAL oCampos;
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "doc_osinfor_erp_migracion.spGeneral_Listar", oCEntidad))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {

                            while (dr.Read())
                            {
                                oCampos = new Ent_INFORME_CONSULTA_LEGAL();
                                oCampos.COD_ILEGAL = dr["COD_ILEGAL"].ToString();
                                oCampos.COD_INFORME = dr["COD_INFORME"].ToString();
                                oCampos.COD_RESODIREC = dr["COD_RESODIREC"].ToString();
                                oCampos.COD_RESODIREC_INI_PAU = dr["COD_RESODIREC_INI_PAU"].ToString();
                                oCampos.NUM_INFORME = dr["NUMERO"].ToString();
                                oCampos.DLINEA = dr["D_LINEA"].ToString();
                                oCampos.NUM_THABILITANTE = dr["NUM_THABILITANTE"].ToString();
                                oCampos.TITULAR = dr["TITULAR"].ToString();
                                oCampos.COD_INFORME_ALERTA = dr["COD_INFORME_ALERTA"].ToString();
                                lsCEntidad.Add(oCampos);
                            }

                        }
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                //oCampos = new Ent_INFORME_CONSULTA_LEGAL();
                                busqueda.v_ROW_INDEX = Int32.Parse(dr["TOTALROW"].ToString());
                                //lsCEntidad.Add(oCampos);
                            }
                        }
                    }
                }
                busqueda.listBusqueda = lsCEntidad;
                return busqueda;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// METODO PARA LLENAR EL COMBO DE RECOMENDACIONES
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public List<Ent_SBusqueda> RegMostCombo_V3(OracleConnection cn, CEntidadC oCEntidad)
        {
            List<Ent_SBusqueda> comboRecomendaciones = new List<Ent_SBusqueda>();
            Ent_SBusqueda oCampos = new Ent_SBusqueda();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "doc_osinfor_erp_migracion.CR_FISCA_GENERAL_LISTAR", oCEntidad))
                {
                    if (dr != null)
                    {
                        oCampos = new Ent_SBusqueda();
                        if (oCEntidad.BusCriterio != "ENCISOS")
                        {
                            oCampos.Value = "0000000";
                            oCampos.Text = "Seleccionar";
                            comboRecomendaciones.Add(oCampos);
                        }
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCampos = new Ent_SBusqueda();
                                oCampos.Value = dr["CODIGO"].ToString();
                                oCampos.Text = dr["DESCRIPCION"].ToString();
                                comboRecomendaciones.Add(oCampos);
                            }
                        }
                    }
                    cn.Close();
                }
                return comboRecomendaciones;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// metodo para listar la lista de infracciones asociadas a una resolucion directoral
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public List<CEntidadC> InfraccionesRD(OracleConnection cn, CEntidadC oCEntidad)
        {
            List<CEntidadC> lsCEntidad = new List<CEntidadC>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "doc_osinfor_erp_migracion.spRInfraccionesLegal0", oCEntidad))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            int p1 = dr.GetOrdinal("COD_RESODIREC_INI_PAU");
                            int p2 = dr.GetOrdinal("COD_ILEGAL_ENCISOS");
                            int p4 = dr.GetOrdinal("ARTICULO");
                            int p5 = dr.GetOrdinal("ENCISO");
                            int p6 = dr.GetOrdinal("COD_ILEGAL_ARTICULOS");

                            CEntidadC oCampos;
                            while (dr.Read())
                            {
                                oCampos = new CEntidadC();
                                oCampos.COD_RESODIREC_INI_PAU = dr.GetString(p1);
                                oCampos.COD_ILEGAL_ENCISOS = dr.GetString(p2);
                                oCampos.DESCRIPCION_ARTICULOS = dr.GetString(p4);
                                oCampos.DESCRIPCION_ENCISOS = dr.GetString(p5);
                                oCampos.COD_ILEGAL_ARTICULOS = dr.GetString(p6);
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
        /// para descargar los registros de la pagina inicial 27/08/2020
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
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
        #endregion
    }
}
