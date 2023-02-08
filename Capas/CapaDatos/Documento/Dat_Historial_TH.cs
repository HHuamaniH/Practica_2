using System;
using System.Collections.Generic;
using CEntidad = CapaEntidad.DOC.Ent_Reporte_Historial_TH;
using GeneralSQL;
using Oracle.ManagedDataAccess.Client;
using System.Data.SqlClient;
using SQL = GeneralSQL.Data.SQL;

namespace CapaDatos.DOC
{
    public class Dat_Historial_TH
    {
        private SQL oGDataSQL = new SQL();
        private DBOracle dBOracle = new DBOracle();
        public List<CEntidad> Dat_listarTH(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spRHistorial_TH_Titulo_Habilitante", oCEntidad))
                {
                    if (dr != null)
                    {
                        CEntidad oCampos = new CEntidad();
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("COD_THABILITANTE");
                            int pt2 = dr.GetOrdinal("TITULO");
                            int pt3 = dr.GetOrdinal("TITULAR");
                            int pt4 = dr.GetOrdinal("REP_LEGAL");
                            int pt5 = dr.GetOrdinal("UBIGEO");
                            int pt6 = dr.GetOrdinal("ESTAB_SECTOR");
                            int pt7 = dr.GetOrdinal("MODALIDAD");
                            int pt8 = dr.GetOrdinal("AREA_OTORGADA");
                            int pt9 = dr.GetOrdinal("CONTRATO_FECHA_INICIO");
                            int pt10 = dr.GetOrdinal("CONTRATO_FECHA_FIN");

                            while (dr.Read())
                            {
                                //PARTE_DIARIO_DETALLE
                                oCampos = new CEntidad();
                                oCampos.COD_THABILITANTE = dr["COD_THABILITANTE"].ToString();
                                oCampos.TITULO = dr["TITULO"].ToString();
                                oCampos.TITULAR = dr["TITULAR"].ToString();
                                oCampos.REPRESENTANTE_LEG = dr["REP_LEGAL"].ToString();
                                oCampos.UBICACION = dr["UBIGEO"].ToString() + " - " + dr["ESTAB_SECTOR"].ToString();
                                oCampos.MODALIDAD = dr["MODALIDAD"].ToString();
                                oCampos.AREA_O = Convert.ToDecimal(dr["AREA_OTORGADA"]);
                                oCampos.FECHA_INICIO = dr["CONTRATO_FECHA_INICIO"].ToString();
                                oCampos.FECHA_FIN = dr["CONTRATO_FECHA_FIN"].ToString();
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

        public CEntidad Titulo_Habilitante_Detalle(OracleConnection cn, CEntidad oCEntidad)
        {
            CEntidad oCampos = new CEntidad();
            List<CEntidad> ListPOA = new List<CEntidad>();
            List<CEntidad> List_Informe = new List<CEntidad>();
            oCampos.ListINFORMETH = new List<CEntidad>();
            oCampos.ListPOATH = new List<CEntidad>();
            List<CEntidad> List_InfTitular = new List<CEntidad>();

            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "doc_osinfor_erp_migracion.spRHistorial_TH_Titulo_Habilitante", oCEntidad))
                {
                    if (dr != null)
                    {
                        //  CEntidad oCampos = new CEntidad();
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("COD_THABILITANTE");
                            int pt2 = dr.GetOrdinal("TITULO");
                            int pt3 = dr.GetOrdinal("TITULAR");
                            int pt4 = dr.GetOrdinal("REP_LEGAL");
                            int pt5 = dr.GetOrdinal("UBIGEO");
                            int pt6 = dr.GetOrdinal("ESTAB_SECTOR");
                            int pt7 = dr.GetOrdinal("MODALIDAD");
                            int pt8 = dr.GetOrdinal("AREA_OTORGADA");
                            int pt9 = dr.GetOrdinal("CONTRATO_FECHA_INICIO");
                            int pt10 = dr.GetOrdinal("CONTRATO_FECHA_FIN");
                            int pt11 = dr.GetOrdinal("DIRECCION");
                            int pt12 = dr.GetOrdinal("DIRECCION_LEGAL");
                            int pt13 = dr.GetOrdinal("lista_infractor");
                            int pt14 = dr.GetOrdinal("T_DNI");
                            int pt15 = dr.GetOrdinal("T_RUC");
                            int pt16 = dr.GetOrdinal("R_DNI");
                            int pt17 = dr.GetOrdinal("R_RUC");


                            while (dr.Read())
                            {
                                //PARTE_DIARIO_DETALLE
                                oCampos = new CEntidad();
                                oCampos.COD_THABILITANTE = dr["COD_THABILITANTE"].ToString();
                                oCampos.TITULO = dr["TITULO"].ToString();
                                oCampos.TITULAR = dr["TITULAR"].ToString();
                                oCampos.REPRESENTANTE_LEG = dr["REP_LEGAL"].ToString();
                                oCampos.UBICACION = dr["UBIGEO"].ToString() + " - " + dr["ESTAB_SECTOR"].ToString();
                                oCampos.MODALIDAD = dr["MODALIDAD"].ToString();
                                oCampos.AREA_O = Convert.ToDecimal(dr["AREA_OTORGADA"]);
                                oCampos.FECHA_INICIO = dr["CONTRATO_FECHA_INICIO"].ToString();
                                oCampos.FECHA_FIN = dr["CONTRATO_FECHA_FIN"].ToString();
                                oCampos.DIRECCION_TH = dr["DIRECCION"].ToString();
                                oCampos.DIRECCION_LEGAL = dr["DIRECCION_LEGAL"].ToString();
                                oCampos.ESTADO_CONTA = dr["lista_infractor"].ToString();
                                oCampos.T_DNI = dr["T_DNI"].ToString();
                                oCampos.T_RUC = dr["T_RUC"].ToString();
                                oCampos.R_DNI = dr["R_DNI"].ToString();
                                oCampos.R_RUC = dr["R_RUC"].ToString();

                                // lsCEntidad.Add(oCampos);
                            }
                        }

                    }

                    dr.NextResult();
                    // POA
                    if (dr.HasRows)
                    {
                        CEntidad oCampos1 = new CEntidad();
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("COD_THABILITANTE");
                            int pt2 = dr.GetOrdinal("NUM_POA");
                            int pt3 = dr.GetOrdinal("NUM_PCOMPLEMENTARIO");
                            int pt4 = dr.GetOrdinal("AREA");
                            int pt5 = dr.GetOrdinal("PCA");
                            int pt6 = dr.GetOrdinal("ZAFRA_PCA");
                            int pt7 = dr.GetOrdinal("CONSULTOR");
                            int pt9 = dr.GetOrdinal("ARESOLUCION_NUM");
                            int pt10 = dr.GetOrdinal("Fecha_Resolucion");
                            int pt11 = dr.GetOrdinal("ARBOLES");
                            int pt12 = dr.GetOrdinal("VOLUMEN");
                            int pt13 = dr.GetOrdinal("NOMBRE_POA");
                            int pt14 = dr.GetOrdinal("COD_INFORME");
                            int pt15 = dr.GetOrdinal("NUM_INFORME");

                            while (dr.Read())
                            {
                                //PARTE_DIARIO_DETALLE
                                oCampos1 = new CEntidad();
                                oCampos1.COD_THABILITANTE =dr["COD_THABILITANTE"].ToString();
                                oCampos1.NUM_POA = Convert.ToInt32(dr["NUM_POA"]);
                                oCampos1.POA_COMPLEMENT = Convert.ToInt32(dr["NUM_PCOMPLEMENTARIO"]);
                                oCampos1.AREA_O = Convert.ToDecimal(dr["AREA"]);
                                oCampos1.PCA =  dr["PCA"].ToString();
                                oCampos1.ZAFRA = dr["ZAFRA_PCA"].ToString();
                                oCampos1.FECHA_INICIO = dr["CONSULTOR"].ToString();
                                oCampos1.consultor = dr["CONSULTOR"].ToString();
                                oCampos1.ARESOLUCION_NUM = dr["ARESOLUCION_NUM"].ToString();
                                oCampos1.fecha_aprobacion =  dr["Fecha_Resolucion"].ToString();
                                oCampos1.NUMERO_ARBOLES = Convert.ToInt32(dr["ARBOLES"]);
                                oCampos1.VOLUMEN_ARBOLES = Convert.ToDecimal(dr["VOLUMEN"]);
                                oCampos1.NUM_POA_STRING =   dr["NOMBRE_POA"].ToString();
                                oCampos1.COD_INFORME =   dr["COD_INFORME"].ToString();
                                oCampos1.NUM_INFORME =  dr["NUM_INFORME"].ToString();

                                ListPOA.Add(oCampos1);
                            }
                        }
                        oCampos.ListPOATH = ListPOA;
                    }

                    dr.NextResult();
                    // POA
                    if (dr.HasRows)
                    {
                        CEntidad oCampos3 = new CEntidad();
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("NUMERO");
                            int pt2 = dr.GetOrdinal("TIPO_FISCALIZA");
                            int pt3 = dr.GetOrdinal("NUMERO_EXPEDIENTE");
                            // int pt4 = dr.GetOrdinal("NUMERO_INFORME");
                            // int pt5 = dr.GetOrdinal("NUMERO_RESOLUCION");
                            // int pt6 = dr.GetOrdinal("REMITENTE");
                            // int pt7 = dr.GetOrdinal("TITULAR");
                            int pt8 = dr.GetOrdinal("FECHA");

                            while (dr.Read())
                            {
                                //PARTE_DIARIO_DETALLE
                                oCampos3 = new CEntidad();
                                oCampos3.NUMERO = dr["NUMERO"].ToString();
                                oCampos3.Tipo_Inicio = dr["TIPO_FISCALIZA"].ToString();
                                oCampos3.NUM_CNOTIFICACION = dr["NUMERO_EXPEDIENTE"].ToString();
                                // oCampos3.NUM_INFORME = dr.GetString(pt4);
                                // oCampos3.RD_INICIO = dr.GetString(pt5);
                                // oCampos3.consultor = dr.GetString(pt6);
                                // oCampos3.TITULAR = dr.GetString(pt7);
                                oCampos3.fecha_aprobacion = dr["FECHA"].ToString();
                                List_InfTitular.Add(oCampos3);
                            }
                        }
                        oCampos.ListINFTIT = List_InfTitular;
                    }

                }
                return oCampos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //public List<CEntidad> Informes_Sup_TH(OracleConnection cn, CEntidad oCEntidad)
        //{
        //    List<CEntidad> List_Informe = new List<CEntidad>();

        //    try
        //    {
        //        using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC.spRHistorial_TH_Titulo_Habilitante", oCEntidad))
        //        {
        //            // INFORMES
        //            if (dr.HasRows)
        //            {
        //                CEntidad oCampos2 = new CEntidad();
        //                if (dr.HasRows)
        //                {
        //                    int pt0 = dr.GetOrdinal("COD_INFORME");
        //                    int pt1 = dr.GetOrdinal("COD_THABILITANTE");
        //                    int pt2 = dr.GetOrdinal("NUM_POA");
        //                    int pt3 = dr.GetOrdinal("ORIGEN");
        //                    int pt4 = dr.GetOrdinal("NUM_INFORME");
        //                    int pt5 = dr.GetOrdinal("ANIO_SUP");
        //                    int pt98 = dr.GetOrdinal("COD_DOCINFORME");
        //                    int pt6 = dr.GetOrdinal("SUPERVISOR");
        //                    int pt7 = dr.GetOrdinal("OBSERVACION");
        //                    // R.D. inicio
        //                    int pt8 = dr.GetOrdinal("COD_RDINICIO");
        //                    int pt9 = dr.GetOrdinal("NUM_RDINICIO");
        //                    int pt99 = dr.GetOrdinal("COD_DOCRDINICIO");
        //                    int pt10 = dr.GetOrdinal("FECHA_RDINICIO");
        //                    int pt11 = dr.GetOrdinal("MEDIDA_CAUTELAR");
        //                    int pt12 = dr.GetOrdinal("CAUSAL_CADUCIDAD");
        //                    int pt13 = dr.GetOrdinal("INF_FALSA_DAS");
        //                    int pt14 = dr.GetOrdinal("INF_FALSA_DIF");
        //                    int pt15 = dr.GetOrdinal("INF_FALSA_INEX");
        //                    int pt16 = dr.GetOrdinal("INFRACCIONES");
        //                    int pt17 = dr.GetOrdinal("NUMERO_EXPEDIENTE");
        //                    //tribunal R.D. inicio
        //                    int pt103 = dr.GetOrdinal("COD_TRIBUNAL_INI");
        //                    int pt104 = dr.GetOrdinal("NUM_TFFSINI");
        //                    int pt105 = dr.GetOrdinal("DETERMINA");
        //                    int pt106 = dr.GetOrdinal("MOTIVO");
        //                    int pt107 = dr.GetOrdinal("DOC_RETRO");
        //                    int pt108 = dr.GetOrdinal("ESTADO_TFFS");
        //                    // R.D. termino
        //                    int pt18 = dr.GetOrdinal("COD_RDTERMINO");
        //                    int pt19 = dr.GetOrdinal("NUM_RDTERMINO");
        //                    int pt100 = dr.GetOrdinal("COD_DOCRDTERMINO");
        //                    int pt20 = dr.GetOrdinal("FECHA_RD_TERMINO");
        //                    int pt21 = dr.GetOrdinal("DETERMINACION_RDTERMINO");
        //                    int pt22 = dr.GetOrdinal("CADUCIDAD_RT");
        //                    int pt23 = dr.GetOrdinal("MULTA_RT");
        //                    int pt24 = dr.GetOrdinal("MONTO_RT");
        //                    int pt25 = dr.GetOrdinal("SANCION_EXTITULAR");
        //                    int pt26 = dr.GetOrdinal("EX_TITULAR");
        //                    int pt27 = dr.GetOrdinal("INFRACCIONES_RT");
        //                    int pt28 = dr.GetOrdinal("ESTADO_PROCESO");
        //                    // tribunal R.D. termino
        //                    int pt109 = dr.GetOrdinal("COD_TRIBUNAL_TER");
        //                    int pt110 = dr.GetOrdinal("NUM_TFFSTER");
        //                    int pt111 = dr.GetOrdinal("DETERMINA_TFFSTER");
        //                    int pt112 = dr.GetOrdinal("MOTIVO_TFFSTER");
        //                    int pt113 = dr.GetOrdinal("DOC_RETRO_TFFSTER");
        //                    int pt114 = dr.GetOrdinal("ESTADO_TFFSTER");
        //                    // R.D. reconsideracion
        //                    int pt29 = dr.GetOrdinal("RECONS_COD_RESODIREC");
        //                    int pt30 = dr.GetOrdinal("RECONS_NUM_RESOLUCION");
        //                    int pt101 = dr.GetOrdinal("DOC_RECONS");
        //                    int pt31 = dr.GetOrdinal("RECONS_CODFCTIPO");
        //                    int pt32 = dr.GetOrdinal("RECONS_RD_FECHA");
        //                    int pt33 = dr.GetOrdinal("RECONS_IMPROCEDENTE");
        //                    int pt34 = dr.GetOrdinal("RECONS_FUNDADA");
        //                    int pt35 = dr.GetOrdinal("RECONS_FUNDADA_PARTE");
        //                    int pt36 = dr.GetOrdinal("RECONS_INFUNDADA");
        //                    int pt37 = dr.GetOrdinal("RECONS_LEVANTAR_CADUCIDAD");
        //                    int pt38 = dr.GetOrdinal("RECONS_CAMBIO_MULTA");
        //                    int pt39 = dr.GetOrdinal("RECONS_MONTO");
        //                    //tribunal R.D. reconsideracion
        //                    int pt115 = dr.GetOrdinal("COD_TRIBUNAL_REC");
        //                    int pt116 = dr.GetOrdinal("NUM_TFFSREC");
        //                    int pt117 = dr.GetOrdinal("DETERMINA_TFFSREC");
        //                    int pt118 = dr.GetOrdinal("MOTIVO_TFFSREC");
        //                    int pt119 = dr.GetOrdinal("DOC_RETRO_TFFSREC");
        //                    int pt120 = dr.GetOrdinal("ESTADO_TFFSREC");
        //                    //R.D. rectificacion
        //                    int pt40 = dr.GetOrdinal("RECT_COD_RESODIREC");
        //                    int pt41 = dr.GetOrdinal("RECT_NUM_RESOLUCION");
        //                    int pt102 = dr.GetOrdinal("DOC_RECTIFICACION");
        //                    int pt42 = dr.GetOrdinal("RECT_CODFCTIPO");
        //                    int pt43 = dr.GetOrdinal("RECT_RD_FECHA");
        //                    int pt44 = dr.GetOrdinal("RECT_ERRORMATERIAL");
        //                    int pt45 = dr.GetOrdinal("RECT_CAMBIO_MULTA");
        //                    int pt46 = dr.GetOrdinal("RECT_MONTO");
        //                    int pt47 = dr.GetOrdinal("RECT_OTROS");
        //                    int pt48 = dr.GetOrdinal("RECT_DESC_OTROS");
        //                    int pt49 = dr.GetOrdinal("ACUM_COD_RESODIREC");
        //                    int pt50 = dr.GetOrdinal("ACUM_NUM_RESOLUCION");
        //                    int pt51 = dr.GetOrdinal("ACUM_COD_FCTIPO");
        //                    int pt52 = dr.GetOrdinal("ACUM_FECHA_EMISION");
        //                    int pt53 = dr.GetOrdinal("ACUM_DESCRIPCION");
        //                    int pt54 = dr.GetOrdinal("AMP_COD_RESODIREC");
        //                    int pt55 = dr.GetOrdinal("AMP_NUM_RESOLUCION");
        //                    int pt56 = dr.GetOrdinal("AMP_COD_FCTIPO");
        //                    int pt57 = dr.GetOrdinal("RD_FECHA_EMISION_AMP");
        //                    int pt58 = dr.GetOrdinal("AMP_IMPUTACION");
        //                    int pt59 = dr.GetOrdinal("AMP_OTRAS_INFRACCIONES");
        //                    int pt60 = dr.GetOrdinal("AMP_POR_PLAZOS");
        //                    int pt61 = dr.GetOrdinal("AMP_OTROS");
        //                    int pt62 = dr.GetOrdinal("CAD_COD_RESODIREC");
        //                    int pt63 = dr.GetOrdinal("CAD_NUM_RESOLUCION");
        //                    int pt64 = dr.GetOrdinal("CAD_COD_FCTIPO");
        //                    int pt65 = dr.GetOrdinal("CAD_RD_FECHA");
        //                    int pt66 = dr.GetOrdinal("CAD_NUM_EXP");
        //                    int pt67 = dr.GetOrdinal("CAD_CADUCIDAD");
        //                    int pt68 = dr.GetOrdinal("OTROS_COD_RESODIREC");
        //                    int pt69 = dr.GetOrdinal("OTROS_NUM_RESOLUCION");
        //                    int pt70 = dr.GetOrdinal("OTROS_COD_FCTIPO");
        //                    int pt71 = dr.GetOrdinal("OTROS_RD_FECHA");
        //                    int pt72 = dr.GetOrdinal("OTROS_DETERMINACION");
        //                    int pt73 = dr.GetOrdinal("VARI_COD_RESODIREC");
        //                    int pt74 = dr.GetOrdinal("VARI_NUM_RESOLUCION");
        //                    int pt75 = dr.GetOrdinal("VARI_COD_FCTIPO");
        //                    int pt76 = dr.GetOrdinal("VARI_RD_FECHA");
        //                    int pt77 = dr.GetOrdinal("VARI_LEVANTAR");
        //                    int pt78 = dr.GetOrdinal("VARI_LEVANTAR_PARTE");
        //                    int pt79 = dr.GetOrdinal("VARI_NO_LEVANTAR");
        //                    int pt80 = dr.GetOrdinal("VARI_MODIFICAR");
        //                    int pt81 = dr.GetOrdinal("VARI_DETERMINACION");
        //                    int pt82 = dr.GetOrdinal("ARCH_COD_RESODIREC");
        //                    int pt83 = dr.GetOrdinal("ARCH_NUM_RESOLUCION");
        //                    int pt84 = dr.GetOrdinal("ARCH_FECHA_RD");
        //                    int pt85 = dr.GetOrdinal("ARCH_COD_FCTIPO");
        //                    int pt86 = dr.GetOrdinal("ARCH_EVIDENCIA_IRRE");
        //                    int pt87 = dr.GetOrdinal("ARCH_SIN_INFRACCION");
        //                    int pt88 = dr.GetOrdinal("ARCH_BUEN_MANEJO");
        //                    int pt89 = dr.GetOrdinal("ARCH_DEFICIENTE_NOT");
        //                    int pt90 = dr.GetOrdinal("ARCH_DEFICIENCIA_TEC");
        //                    int pt91 = dr.GetOrdinal("OTROS");

        //                    while (dr.Read())
        //                    {
        //                        //PARTE_DIARIO_DETALLE
        //                        oCampos2 = new CEntidad();
        //                        oCampos2.COD_INFORME = dr.GetString(pt0);
        //                        oCampos2.COD_THABILITANTE = dr.GetString(pt1);
        //                        oCampos2.NUM_POA = dr.GetInt32(pt2);
        //                        oCampos2.ESTADO_ORIGEN_TIPO = dr.GetString(pt3);
        //                        oCampos2.NUMERO = dr.GetString(pt4); //numero de informe
        //                        oCampos2.COD_DOCINFORME = dr.GetString(pt98); // DOC SIADO INFORME
        //                        oCampos2.ANIO_SUP = dr.GetInt32(pt5).ToString();
        //                        oCampos2.Supervisor = dr.GetString(pt6);
        //                        oCampos2.OBSERVACIONES = dr.GetString(pt7);
        //                        // R.D. INICIO
        //                        oCampos2.COD_RESODIREC_Inicio = dr.GetString(pt8);
        //                        oCampos2.RD_INICIO = dr.GetString(pt9);
        //                        oCampos2.COD_DOCRDINICIO = dr.GetString(pt99);
        //                        oCampos2.FECHA_RDINICIO = dr.GetString(pt10);
        //                        oCampos2.MEDIDAS_CAUTELARES = dr.GetString(pt11);
        //                        oCampos2.CAUSAL_CADUCIDAD = dr.GetString(pt12);
        //                        oCampos2.INF_FALSA_DAS = dr.GetString(pt13);
        //                        oCampos2.INF_FALSA_DIF = dr.GetString(pt14);
        //                        oCampos2.INF_FALSA_INEX = dr.GetString(pt15);
        //                        oCampos2.INFRACCIONES = dr.GetString(pt16);
        //                        oCampos2.NUM_EXP = dr.GetString(pt17);// numero de expediente de la rd
        //                        // TRIBUNAL R.D. INICIO
        //                        oCampos2.COD_TRIBUNAL_INI = dr.GetString(pt103);
        //                        oCampos2.NUM_TFFSINI = dr.GetString(pt104);
        //                        oCampos2.DETERMINA = dr.GetString(pt105);
        //                        oCampos2.MOTIVO = dr.GetString(pt106);
        //                        oCampos2.DOC_RETRO = dr.GetString(pt107);
        //                        oCampos2.ESTADO_TFFS = dr.GetString(pt108);
        //                        // R.D. TERMINO
        //                        oCampos2.COD_RESODIREC_Termino = dr.GetString(pt18);//codigo de la RD de termino
        //                        oCampos2.RD_TERMINO = dr.GetString(pt19);
        //                        oCampos2.COD_DOCRDTERMINO = dr.GetString(pt100);
        //                        oCampos2.FECHA_RDTERMINO = dr.GetString(pt20);
        //                        oCampos2.DETERMINACION_RDTERMINO = dr.GetString(pt21);
        //                        oCampos2.CADUCIDAD_RDTERMINO = dr.GetString(pt22);
        //                        oCampos2.MULTA_RDTERMINO = dr.GetString(pt23);
        //                        oCampos2.MULTA_MONTO = dr.GetString(pt24);
        //                        oCampos2.SANCION_EXTITULAR_RDTERMINO = dr.GetString(pt25);
        //                        oCampos2.INFRACCIONES_TER = dr.GetString(pt27);
        //                        oCampos2.ESTADO_ORIGEN = dr.GetString(pt28);
        //                        oCampos2.TITULAR = dr.GetString(pt26);
        //                        //TRIBUNAL R.D. TERMINO
        //                        oCampos2.COD_TRIBUNAL_TER = dr.GetString(pt109);
        //                        oCampos2.NUM_TFFSTER = dr.GetString(pt110);
        //                        oCampos2.DETERMINA_TFFSTER = dr.GetString(pt111);
        //                        oCampos2.MOTIVO_TFFSTER = dr.GetString(pt112);
        //                        oCampos2.DOC_RETRO_TFFSTER = dr.GetString(pt113);
        //                        oCampos2.ESTADO_TFFSTER = dr.GetString(pt114);

        //                        //cambios en el reporte historial titulo habilitante interno 15/11/2016
        //                        oCampos2.RECONS_COD_RESODIREC = dr.GetString(pt29);
        //                        oCampos2.RECONS_NUM_RESOLUCION = dr.GetString(pt30);
        //                        oCampos2.DOC_RECONS = dr.GetString(pt101);
        //                        oCampos2.RECONS_CODFCTIPO = dr.GetString(pt31);
        //                        oCampos2.RECONS_RD_FECHA = dr.GetString(pt32);
        //                        oCampos2.RECONS_IMPROCEDENTE = dr.GetString(pt33);
        //                        oCampos2.RECONS_FUNDADA = dr.GetString(pt34);
        //                        oCampos2.RECONS_FUNDADA_PARTE = dr.GetString(pt35);
        //                        oCampos2.RECONS_INFUNDADA = dr.GetString(pt36);
        //                        oCampos2.RECONS_LEVANTAR_CADUCIDAD = dr.GetString(pt37);
        //                        oCampos2.RECONS_CAMBIO_MULTA = dr.GetString(pt38);
        //                        oCampos2.RECONS_MONTO = dr.GetDecimal(pt39).ToString();
        //                        //TRIBUNAL RECONSIDERACION
        //                        oCampos2.COD_TRIBUNAL_REC = dr.GetString(pt115);
        //                        oCampos2.NUM_TFFSREC = dr.GetString(pt116);
        //                        oCampos2.DETERMINA_TFFSREC = dr.GetString(pt117);
        //                        oCampos2.MOTIVO_TFFSREC = dr.GetString(pt118);
        //                        oCampos2.DOC_RETRO_TFFSREC = dr.GetString(pt119);
        //                        oCampos2.ESTADO_TFFSREC = dr.GetString(pt120);
        //                        //R.D. RECTIFICACION
        //                        oCampos2.RECT_COD_RESODIREC = dr.GetString(pt40);
        //                        oCampos2.RECT_NUM_RESOLUCION = dr.GetString(pt41);
        //                        oCampos2.DOC_RECTIFICACION = dr.GetString(pt102);
        //                        oCampos2.RECT_CODFCTIPO = dr.GetString(pt42);
        //                        oCampos2.RECT_RD_FECHA = dr.GetString(pt43);
        //                        oCampos2.RECT_ERRORMATERIAL = dr.GetString(pt44);
        //                        oCampos2.RECT_CAMBIO_MULTA = dr.GetString(pt45);
        //                        oCampos2.RECT_MONTO = dr.GetDecimal(pt46).ToString();
        //                        oCampos2.RECT_OTROS = dr.GetString(pt47);
        //                        oCampos2.RECT_DESC_OTROS = dr.GetString(pt48);
        //                        //R.D. ACUMULACION
        //                        oCampos2.ACUM_COD_RESODIREC = dr.GetString(pt49);
        //                        oCampos2.ACUM_NUM_RESOLUCION = dr.GetString(pt50);
        //                        oCampos2.ACUM_COD_FCTIPO = dr.GetString(pt51);
        //                        oCampos2.ACUM_FECHA_EMISION = dr.GetString(pt52);
        //                        oCampos2.ACUM_DESCRIPCION = dr.GetString(pt53);
        //                        // R.D. AMPLIACION
        //                        oCampos2.AMP_COD_RESODIREC = dr.GetString(pt54);
        //                        oCampos2.AMP_NUM_RESOLUCION = dr.GetString(pt55);
        //                        oCampos2.AMP_COD_FCTIPO = dr.GetString(pt56);
        //                        oCampos2.RD_FECHA_EMISION_AMP = dr.GetString(pt57);
        //                        oCampos2.AMP_IMPUTACION = dr.GetString(pt58);
        //                        oCampos2.AMP_OTRAS_INFRACCIONES = dr.GetString(pt59);
        //                        oCampos2.AMP_POR_PLAZOS = dr.GetString(pt60);
        //                        oCampos2.AMP_OTROS = dr.GetString(pt61);
        //                        // R.D. CADUCIDAD
        //                        oCampos2.CAD_COD_RESODIREC = dr.GetString(pt62);
        //                        oCampos2.CAD_NUM_RESOLUCION = dr.GetString(pt63);
        //                        oCampos2.CAD_COD_FCTIPO = dr.GetString(pt64);
        //                        oCampos2.CAD_RD_FECHA = dr.GetString(pt65);
        //                        oCampos2.CAD_NUM_EXP = dr.GetString(pt66);
        //                        oCampos2.CAD_CADUCIDAD = dr.GetString(pt67);
        //                        oCampos2.OTROS_COD_RESODIREC = dr.GetString(pt68);
        //                        oCampos2.OTROS_NUM_RESOLUCION = dr.GetString(pt69);
        //                        oCampos2.OTROS_COD_FCTIPO = dr.GetString(pt70);
        //                        oCampos2.OTROS_RD_FECHA = dr.GetString(pt71);
        //                        oCampos2.OTROS_DETERMINACION = dr.GetString(pt72);
        //                        oCampos2.VARI_COD_RESODIREC = dr.GetString(pt73);
        //                        oCampos2.VARI_NUM_RESOLUCION = dr.GetString(pt74);
        //                        oCampos2.VARI_COD_FCTIPO = dr.GetString(pt75);
        //                        oCampos2.VARI_RD_FECHA = dr.GetString(pt76);
        //                        oCampos2.VARI_LEVANTAR = dr.GetString(pt77);
        //                        oCampos2.VARI_LEVANTAR_PARTE = dr.GetString(pt78);
        //                        oCampos2.VARI_NO_LEVANTAR = dr.GetString(pt79);
        //                        oCampos2.VARI_MODIFICAR = dr.GetString(pt80);
        //                        oCampos2.VARI_DETERMINACION = dr.GetString(pt81);

        //                        oCampos2.ARCH_COD_RESODIREC = dr.GetString(pt82);
        //                        oCampos2.ARCH_NUM_RESOLUCION = dr.GetString(pt83);
        //                        oCampos2.ARCH_FECHA_RD = dr.GetString(pt84);
        //                        oCampos2.ARCH_COD_FCTIPO = dr.GetString(pt85);
        //                        oCampos2.ARCH_EVIDENCIA_IRRE = dr.GetString(pt86);
        //                        oCampos2.ARCH_SIN_INFRACCION = dr.GetString(pt87);
        //                        oCampos2.ARCH_BUEN_MANEJO = dr.GetString(pt88);
        //                        oCampos2.ARCH_DEFICIENTE_NOT = dr.GetString(pt89);
        //                        oCampos2.ARCH_DEFICIENCIA_TEC = dr.GetString(pt90);
        //                        oCampos2.OTROS = dr.GetString(pt91);

        //                        List_Informe.Add(oCampos2);
        //                    }
        //                }

        //            }

        //            return List_Informe;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        /// <summary>
        /// METODO PARA OBTENER EL TH
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        //public CEntidad Dat_Titulo_Habilitante(OracleConnection cn, CEntidad oCEntidad)
        //{
        //    CEntidad oCampos = null;
        //    CEntidad oCamposPOA = null;
        //    CEntidad oCamposAprob = null;
        //    CEntidad oCamposBalance = null;
        //    CEntidad oCamposReformula = null;
        //    CEntidad oCamposSupervision = null;
        //    CEntidad oCamposInfraccion = null;
        //    try
        //    {
        //        using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC.spRHistorial_TH_Titulo_Habilitante", oCEntidad))
        //        {
        //            if (dr != null)
        //            {
        //                oCampos = new CEntidad();
        //                if (dr.HasRows)
        //                {
        //                    int pt1 = dr.GetOrdinal("COD_THABILITANTE");
        //                    int pt2 = dr.GetOrdinal("NUMERO");
        //                    int pt3 = dr.GetOrdinal("APELLIDOS_NOMBRES");
        //                    int pt4 = dr.GetOrdinal("Repre_Legal");
        //                    int pt5 = dr.GetOrdinal("Ubicacion");
        //                    int pt6 = dr.GetOrdinal("N_POA");
        //                    int pt7 = dr.GetOrdinal("AREA_OTORGADA");
        //                    while (dr.Read())
        //                    {
        //                        //PARTE_DIARIO_DETALLE
        //                        oCampos = new CEntidad();
        //                        oCampos.COD_THABILITANTE = dr.GetString(pt1);
        //                        oCampos.TITULO = dr.GetString(pt2);
        //                        oCampos.TITULAR = dr.GetString(pt3);
        //                        oCampos.REPRESENTANTE_LEG = dr.GetString(pt4);
        //                        oCampos.UBICACION = dr.GetString(pt5);
        //                        oCampos.N_POA = dr.GetInt32(pt6);
        //                        oCampos.AREA_O = dr.GetDecimal(pt7);
        //                    }
        //                    if (oCampos.N_POA > 0)
        //                    {
        //                        try
        //                        {
        //                            using (OracleDataReader drPOA = dBOracle.SelDrdDefault(cn, null, "DOC.spRHistorial_TH_Titulo_POA", oCEntidad))
        //                                if (drPOA != null)
        //                                {
        //                                    oCampos.ListPOATH = new List<CEntidad>();
        //                                    oCamposPOA = new CEntidad();
        //                                    if (drPOA.HasRows)
        //                                    {
        //                                        int p1 = drPOA.GetOrdinal("COD_THABILITANTE");
        //                                        int p2 = drPOA.GetOrdinal("NUM_POA");
        //                                        int p12 = drPOA.GetOrdinal("AREA");
        //                                        int p3 = drPOA.GetOrdinal("consultor");
        //                                        int p4 = drPOA.GetOrdinal("ARESOLUCION_NUM");
        //                                        int p13 = drPOA.GetOrdinal("ITECNICO_REFORMULA_POA_NUM");
        //                                        int p5 = drPOA.GetOrdinal("fecha_aprobacion");
        //                                        int p14 = drPOA.GetOrdinal("ESTADO_ORIGEN_TIPO");

        //                                        while (drPOA.Read())
        //                                        {
        //                                            oCamposPOA = new CEntidad();
        //                                            oCamposPOA.COD_THABILITANTE = drPOA.GetString(p1);
        //                                            oCamposPOA.NUM_POA = drPOA.GetInt32(p2);
        //                                            oCamposPOA.consultor = drPOA.GetString(p3);
        //                                            oCamposPOA.ARESOLUCION_NUM = drPOA.GetString(p4);
        //                                            oCamposPOA.fecha_aprobacion = drPOA.GetString(p5);
        //                                            oCamposPOA.AREA_O = drPOA.GetDecimal(p12);
        //                                            oCamposPOA.ITECNICO_REFORMULA_POA_NUM = drPOA.GetString(p13);
        //                                            oCamposPOA.ESTADO_ORIGEN_TIPO = drPOA.GetString(p14);
        //                                            try
        //                                            {
        //                                                oCEntidad = new CEntidad();
        //                                                oCEntidad.NUM_POA = oCamposPOA.NUM_POA;
        //                                                oCEntidad.COD_THABILITANTE = oCamposPOA.COD_THABILITANTE;
        //                                                #region Aprobados
        //                                                using (OracleDataReader drAPROB = dBOracle.SelDrdDefault(cn, null, "DOC.spRHistorial_TH_POA_Listar_Aprob", oCEntidad))
        //                                                    if (drAPROB != null)
        //                                                    {
        //                                                        oCamposPOA.ListPOARBAPRO = new List<CEntidad>();
        //                                                        oCamposAprob = new CEntidad();
        //                                                        if (drAPROB.HasRows)
        //                                                        {
        //                                                            int pa1 = drAPROB.GetOrdinal("COD_THABILITANTE");
        //                                                            int pa2 = drAPROB.GetOrdinal("NUM_POA");
        //                                                            int pa3 = drAPROB.GetOrdinal("arboles_apro");
        //                                                            int pa4 = drAPROB.GetOrdinal("volumen_apro");
        //                                                            int pa5 = drAPROB.GetOrdinal("NOMBRE_CIENTIFICO");
        //                                                            int pa6 = drAPROB.GetOrdinal("NOMBRE_COMUN");

        //                                                            while (drAPROB.Read())
        //                                                            {
        //                                                                oCamposAprob = new CEntidad();
        //                                                                oCamposAprob.COD_THABILITANTE = drAPROB.GetString(pa1);
        //                                                                oCamposAprob.NUM_POA = drAPROB.GetInt32(pa2);
        //                                                                oCamposAprob.Arboles_aprob = drAPROB.GetInt32(pa3);
        //                                                                oCamposAprob.Volumen_apro = drAPROB.GetDecimal(pa4);
        //                                                                oCamposAprob.Nombre_Cienti = drAPROB.GetString(pa5);
        //                                                                oCamposAprob.Nombre_Comun = drAPROB.GetString(pa6);
        //                                                                oCamposPOA.ListPOARBAPRO.Add(oCamposAprob);
        //                                                            }
        //                                                        }
        //                                                    }
        //                                                #endregion
        //                                                //reformula
        //                                                #region reformula
        //                                                using (OracleDataReader drREAPRO = dBOracle.SelDrdDefault(cn, null, "DOC.spRHistorial_TH_POA_Listar_RRApro", oCEntidad))
        //                                                    if (drREAPRO != null)
        //                                                    {
        //                                                        oCamposPOA.ListPOAReformula = new List<CEntidad>();
        //                                                        oCamposReformula = new CEntidad();
        //                                                        if (drREAPRO.HasRows)
        //                                                        {
        //                                                            int pra1 = drREAPRO.GetOrdinal("COD_THABILITANTE");
        //                                                            int pra2 = drREAPRO.GetOrdinal("NUM_POA");
        //                                                            int pra3 = drREAPRO.GetOrdinal("arboles_re");
        //                                                            int pra4 = drREAPRO.GetOrdinal("volumen_re");
        //                                                            int pra5 = drREAPRO.GetOrdinal("NOMBRE_CIENTIFICO");
        //                                                            int pra6 = drREAPRO.GetOrdinal("NOMBRE_COMUN");

        //                                                            while (drREAPRO.Read())
        //                                                            {
        //                                                                oCamposReformula = new CEntidad();
        //                                                                oCamposReformula.COD_THABILITANTE = drREAPRO.GetString(pra1);
        //                                                                oCamposReformula.NUM_POA = drREAPRO.GetInt32(pra2);
        //                                                                oCamposReformula.Arboles_aprob = drREAPRO.GetInt32(pra3);
        //                                                                oCamposReformula.Volumen_apro = drREAPRO.GetDecimal(pra4);
        //                                                                oCamposReformula.Nombre_Cienti = drREAPRO.GetString(pra5);
        //                                                                oCamposReformula.Nombre_Comun = drREAPRO.GetString(pra6);
        //                                                                oCamposPOA.ListPOAReformula.Add(oCamposReformula);
        //                                                            }
        //                                                        }
        //                                                    }
        //                                                #endregion
        //                                                #region Balance
        //                                                using (OracleDataReader drBalance = dBOracle.SelDrdDefault(cn, null, "DOC.spRHistorial_TH_POA_Listar_BalanceAprob", oCEntidad))
        //                                                    if (drBalance != null)
        //                                                    {
        //                                                        oCamposPOA.ListPOABalance = new List<CEntidad>();
        //                                                        oCamposBalance = new CEntidad();
        //                                                        if (drBalance.HasRows)
        //                                                        {
        //                                                            int pb1 = drBalance.GetOrdinal("COD_THABILITANTE");
        //                                                            int pb2 = drBalance.GetOrdinal("NUM_POA");
        //                                                            int pb3 = drBalance.GetOrdinal("NOMBRE_CIENTIFICO");
        //                                                            int pb4 = drBalance.GetOrdinal("NOMBRE_COMUN");
        //                                                            int pb5 = drBalance.GetOrdinal("DMC");
        //                                                            int pb6 = drBalance.GetOrdinal("TOTAL_ARBOLES");
        //                                                            int pb7 = drBalance.GetOrdinal("VOLUMEN_AUTORIZADO");
        //                                                            int pb8 = drBalance.GetOrdinal("VOLUMEN_MOVILIZADO");
        //                                                            int pb9 = drBalance.GetOrdinal("SALDO");


        //                                                            while (drBalance.Read())
        //                                                            {
        //                                                                oCamposAprob = new CEntidad();
        //                                                                oCamposAprob.COD_THABILITANTE = drBalance.GetString(pb1);
        //                                                                oCamposAprob.NUM_POA = drBalance.GetInt32(pb2);
        //                                                                oCamposAprob.Nombre_Cienti = drBalance.GetString(pb3);
        //                                                                oCamposAprob.Nombre_Comun = drBalance.GetString(pb4);
        //                                                                oCamposAprob.DMC = drBalance.GetInt32(pb5);
        //                                                                oCamposAprob.TOTAL_ARBOLES = drBalance.GetInt32(pb6);
        //                                                                oCamposAprob.VOLUMEN_AUTORIZADO = drBalance.GetDecimal(pb7);
        //                                                                oCamposAprob.VOLUMEN_MOVILIZADO = drBalance.GetDecimal(pb8);
        //                                                                oCamposAprob.SALDO = drBalance.GetDecimal(pb9);
        //                                                                oCamposPOA.ListPOABalance.Add(oCamposAprob);
        //                                                            }
        //                                                        }
        //                                                    }
        //                                                #endregion
        //                                                #region Supervisiones
        //                                                using (OracleDataReader drSup = dBOracle.SelDrdDefault(cn, null, "DOC.spRHistorial_TH_POA_Listar_Superv", oCEntidad))
        //                                                    if (drSup != null)
        //                                                    {
        //                                                        oCamposPOA.ListSupervision = new List<CEntidad>();
        //                                                        oCamposSupervision = new CEntidad();
        //                                                        if (drSup.HasRows)
        //                                                        {
        //                                                            int ps1 = drSup.GetOrdinal("COD_THABILITANTE");
        //                                                            int ps2 = drSup.GetOrdinal("NUM_POA");
        //                                                            int ps5 = drSup.GetOrdinal("COD_RESODIREC");
        //                                                            int ps6 = drSup.GetOrdinal("NUMERO_RESOLUCION");
        //                                                            int ps3 = drSup.GetOrdinal("COD_ITIPO");
        //                                                            int ps4 = drSup.GetOrdinal("Fecha_Sup");
        //                                                            int ps7 = drSup.GetOrdinal("MEDIDAS_CAUTELARES");
        //                                                            int ps8 = drSup.GetOrdinal("CAUSALES_CADUCIDAD");

        //                                                            int ps9 = drSup.GetOrdinal("ileg_Descrip");
        //                                                            int ps10 = drSup.GetOrdinal("RD_tipo");
        //                                                            int ps11 = drSup.GetOrdinal("COD_RESODIREC_Inicio");
        //                                                            int ps12 = drSup.GetOrdinal("Tipo_Inicio");
        //                                                            int ps13 = drSup.GetOrdinal("RD_termino");
        //                                                            int ps14 = drSup.GetOrdinal("COD_RESODIREC_Termino");
        //                                                            int ps15 = drSup.GetOrdinal("Tipo_Termino");
        //                                                            int ps16 = drSup.GetOrdinal("descripFin");


        //                                                            while (drSup.Read())
        //                                                            {
        //                                                                oCamposSupervision = new CEntidad();
        //                                                                oCamposSupervision.COD_THABILITANTE = drSup.GetString(ps1);
        //                                                                oCamposSupervision.NUM_POA = drSup.GetInt32(ps2);
        //                                                                oCamposSupervision.COD_ITIPO = drSup.GetString(ps3);
        //                                                                oCamposSupervision.Fecha_Sup = drSup.GetString(ps4);
        //                                                                oCamposSupervision.COD_RESODIREC = drSup.GetString(ps5);
        //                                                                oCamposSupervision.NUMERO_RESOLUCION = drSup.GetString(ps6);
        //                                                                oCamposSupervision.MEDIDAS_CAUTELARES = drSup.GetBoolean(ps7);
        //                                                                oCamposSupervision.CAUSALES_CADUCIDAD = drSup.GetBoolean(ps8);

        //                                                                oCamposSupervision.ileg_Descrip = drSup.GetString(ps9);
        //                                                                oCamposSupervision.RD_tipo = drSup.GetString(ps10);
        //                                                                oCamposSupervision.COD_RESODIREC_Inicio = drSup.GetString(ps11);
        //                                                                oCamposSupervision.Tipo_Inicio = drSup.GetString(ps12);
        //                                                                oCamposSupervision.RD_termino = drSup.GetString(ps13);
        //                                                                oCamposSupervision.COD_RESODIREC_Termino = drSup.GetString(ps14);
        //                                                                oCamposSupervision.Tipo_Termino = drSup.GetString(ps15);
        //                                                                oCamposSupervision.descripFin = drSup.GetString(ps16);

        //                                                                //infracciones
        //                                                                oCEntidad = new CEntidad();
        //                                                                oCEntidad.COD_RESODIREC = oCamposSupervision.COD_RESODIREC;
        //                                                                using (OracleDataReader drInf = dBOracle.SelDrdDefault(cn, null, "DOC.spRHistorial_TH_POA_List_Infracciones", oCEntidad))
        //                                                                    if (drInf != null)
        //                                                                    {
        //                                                                        oCamposSupervision.ListInfracciones = new List<CEntidad>();
        //                                                                        oCamposInfraccion = new CEntidad();
        //                                                                        if (drInf.HasRows)
        //                                                                        {
        //                                                                            int pi1 = drInf.GetOrdinal("COD_RESODIREC");
        //                                                                            int pi2 = drInf.GetOrdinal("articulo");
        //                                                                            int pi3 = drInf.GetOrdinal("enciso");

        //                                                                            while (drInf.Read())
        //                                                                            {
        //                                                                                oCamposInfraccion = new CEntidad();
        //                                                                                oCamposInfraccion.COD_RESODIREC = drInf.GetString(pi1);
        //                                                                                oCamposInfraccion.Articulos = drInf.GetString(pi2);
        //                                                                                oCamposInfraccion.Encisos = drInf.GetString(pi3);
        //                                                                                oCamposSupervision.ListInfracciones.Add(oCamposInfraccion);
        //                                                                            }
        //                                                                        }
        //                                                                    }

        //                                                                oCamposPOA.ListSupervision.Add(oCamposSupervision);

        //                                                            }
        //                                                        }
        //                                                    }
        //                                                #endregion

        //                                            }
        //                                            catch (Exception ex)
        //                                            {
        //                                                throw ex;
        //                                            }

        //                                            oCampos.ListPOATH.Add(oCamposPOA);
        //                                        }
        //                                    }
        //                                }
        //                        }
        //                        catch (Exception ex)
        //                        {
        //                            throw ex;
        //                        }

        //                    }
        //                }

        //            }
        //        }
        //        return oCampos;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //}
        /// <summary>
        /// metodo para el estado de titulo habilitante
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        //public List<CEntidad> Dat_Estado_THabilitante(OracleConnection cn, CEntidad oCEntidad)
        //{
        //    List<CEntidad> lsCEntidad = new List<CEntidad>();
        //    CEntidad oCampos = null;
        //    CEntidad oCamposPOA = null;
        //    CEntidad oCamposSupervision = null;
        //    CEntidad oCamposInfraccion = null;
        //    CEntidad oCamposPOAComp = null;
        //    CEntidad oCamposPOAReing = null;
        //    CEntidad oCamposPOAMS = null;

        //    try
        //    {
        //        using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC.spREstado_TH_ListarTH", oCEntidad))
        //        {
        //            if (dr != null)
        //            {
        //                oCampos = new CEntidad();
        //                if (dr.HasRows)
        //                {
        //                    int pt1 = dr.GetOrdinal("COD_THABILITANTE");
        //                    int pt2 = dr.GetOrdinal("NUMERO");
        //                    int pt3 = dr.GetOrdinal("APELLIDOS_NOMBRES");
        //                    int pt4 = dr.GetOrdinal("modalidad");
        //                    int pt5 = dr.GetOrdinal("Ubicacion");
        //                    int pt6 = dr.GetOrdinal("N_POA");
        //                    while (dr.Read())
        //                    {
        //                        //PARTE_DIARIO_DETALLE
        //                        oCampos = new CEntidad();
        //                        oCampos.COD_THABILITANTE = dr.GetString(pt1);
        //                        oCampos.TITULO = dr.GetString(pt2);
        //                        oCampos.TITULAR = dr.GetString(pt3);
        //                        oCampos.MODALIDAD = dr.GetString(pt4);
        //                        oCampos.UBICACION = dr.GetString(pt5);
        //                        oCampos.N_POA = dr.GetInt32(pt6);
        //                        if (oCampos.N_POA > 0)
        //                        {
        //                            try
        //                            {
        //                                oCEntidad = new CEntidad();
        //                                oCEntidad.BusValor = oCampos.COD_THABILITANTE;
        //                                using (OracleDataReader drPOA = dBOracle.SelDrdDefault(cn, null, "DOC.spREstado_TH_POA", oCEntidad))
        //                                    if (drPOA != null)
        //                                    {
        //                                        oCampos.ListPOATH = new List<CEntidad>();
        //                                        oCamposPOA = new CEntidad();
        //                                        if (drPOA.HasRows)
        //                                        {
        //                                            int p1 = drPOA.GetOrdinal("COD_THABILITANTE");
        //                                            int p2 = drPOA.GetOrdinal("NUM_POA");
        //                                            int p3 = drPOA.GetOrdinal("ARESOLUCION_NUM");
        //                                            int p4 = drPOA.GetOrdinal("ESTADO_ORIGEN_TIPO");
        //                                            int p5 = drPOA.GetOrdinal("ESTADO_ORIGEN");
        //                                            int p6 = drPOA.GetOrdinal("HIJO_COD_THABILITANTE");
        //                                            int p7 = drPOA.GetOrdinal("HIJO_NUM_POA");
        //                                            int p8 = drPOA.GetOrdinal("HIJO_NIVEL");

        //                                            while (drPOA.Read())
        //                                            {
        //                                                oCamposPOA = new CEntidad();
        //                                                oCamposPOA.COD_THABILITANTE = drPOA.GetString(p1);
        //                                                oCamposPOA.NUM_POA = drPOA.GetInt32(p2);
        //                                                oCamposPOA.ARESOLUCION_NUM = drPOA.GetString(p3);
        //                                                oCamposPOA.ESTADO_ORIGEN_TIPO = drPOA.GetString(p4);
        //                                                oCamposPOA.ESTADO_ORIGEN = drPOA.GetString(p5);
        //                                                oCamposPOA.HIJO_COD_THABILITANTE = drPOA.GetString(p6);
        //                                                oCamposPOA.HIJO_NUM_POA = drPOA.GetInt32(p7);
        //                                                oCamposPOA.HIJO_NIVEL = drPOA.GetInt32(p8);
        //                                                try
        //                                                {
        //                                                    oCEntidad = new CEntidad();
        //                                                    oCEntidad.NUM_POA = oCamposPOA.NUM_POA;
        //                                                    oCEntidad.COD_THABILITANTE = oCamposPOA.COD_THABILITANTE;
        //                                                    #region Supervisiones
        //                                                    using (OracleDataReader drSup = dBOracle.SelDrdDefault(cn, null, "DOC.spRHistorial_TH_POA_Listar_Superv", oCEntidad))
        //                                                        if (drSup != null)
        //                                                        {
        //                                                            oCamposPOA.ListSupervision = new List<CEntidad>();
        //                                                            oCamposSupervision = new CEntidad();
        //                                                            if (drSup.HasRows)
        //                                                            {
        //                                                                int ps1 = drSup.GetOrdinal("COD_THABILITANTE");
        //                                                                int ps2 = drSup.GetOrdinal("NUM_POA");
        //                                                                int ps5 = drSup.GetOrdinal("COD_RESODIREC");
        //                                                                int ps6 = drSup.GetOrdinal("NUMERO_RESOLUCION");
        //                                                                int ps3 = drSup.GetOrdinal("COD_ITIPO");
        //                                                                int ps4 = drSup.GetOrdinal("Fecha_Sup");
        //                                                                int ps7 = drSup.GetOrdinal("MEDIDAS_CAUTELARES");
        //                                                                int ps8 = drSup.GetOrdinal("CAUSALES_CADUCIDAD");

        //                                                                int ps9 = drSup.GetOrdinal("ileg_Descrip");
        //                                                                int ps10 = drSup.GetOrdinal("RD_tipo");
        //                                                                int ps11 = drSup.GetOrdinal("COD_RESODIREC_Inicio");
        //                                                                int ps12 = drSup.GetOrdinal("Tipo_Inicio");
        //                                                                int ps13 = drSup.GetOrdinal("RD_termino");
        //                                                                int ps14 = drSup.GetOrdinal("COD_RESODIREC_Termino");
        //                                                                int ps15 = drSup.GetOrdinal("Tipo_Termino");
        //                                                                int ps16 = drSup.GetOrdinal("descripFin");


        //                                                                while (drSup.Read())
        //                                                                {
        //                                                                    oCamposSupervision = new CEntidad();
        //                                                                    oCamposSupervision.COD_THABILITANTE = drSup.GetString(ps1);
        //                                                                    oCamposSupervision.NUM_POA = drSup.GetInt32(ps2);
        //                                                                    oCamposSupervision.COD_ITIPO = drSup.GetString(ps3);
        //                                                                    oCamposSupervision.Fecha_Sup = drSup.GetString(ps4);
        //                                                                    oCamposSupervision.COD_RESODIREC = drSup.GetString(ps5);
        //                                                                    oCamposSupervision.NUMERO_RESOLUCION = drSup.GetString(ps6);
        //                                                                    oCamposSupervision.MEDIDAS_CAUTELARES = drSup.GetBoolean(ps7);
        //                                                                    oCamposSupervision.CAUSALES_CADUCIDAD = drSup.GetBoolean(ps8);

        //                                                                    oCamposSupervision.ileg_Descrip = drSup.GetString(ps9);
        //                                                                    oCamposSupervision.RD_tipo = drSup.GetString(ps10);
        //                                                                    oCamposSupervision.COD_RESODIREC_Inicio = drSup.GetString(ps11);
        //                                                                    oCamposSupervision.Tipo_Inicio = drSup.GetString(ps12);
        //                                                                    oCamposSupervision.RD_termino = drSup.GetString(ps13);
        //                                                                    oCamposSupervision.COD_RESODIREC_Termino = drSup.GetString(ps14);
        //                                                                    oCamposSupervision.Tipo_Termino = drSup.GetString(ps15);
        //                                                                    oCamposSupervision.descripFin = drSup.GetString(ps16);

        //                                                                    //infracciones
        //                                                                    oCEntidad = new CEntidad();
        //                                                                    oCEntidad.COD_RESODIREC = oCamposSupervision.COD_RESODIREC;
        //                                                                    using (OracleDataReader drInf = dBOracle.SelDrdDefault(cn, null, "DOC.spRHistorial_TH_POA_List_Infracciones", oCEntidad))
        //                                                                        if (drInf != null)
        //                                                                        {
        //                                                                            oCamposSupervision.ListInfracciones = new List<CEntidad>();
        //                                                                            oCamposInfraccion = new CEntidad();
        //                                                                            if (drInf.HasRows)
        //                                                                            {
        //                                                                                int pi1 = drInf.GetOrdinal("COD_RESODIREC");
        //                                                                                int pi2 = drInf.GetOrdinal("articulo");
        //                                                                                int pi3 = drInf.GetOrdinal("enciso");

        //                                                                                while (drInf.Read())
        //                                                                                {
        //                                                                                    oCamposInfraccion = new CEntidad();
        //                                                                                    oCamposInfraccion.COD_RESODIREC = drInf.GetString(pi1);
        //                                                                                    oCamposInfraccion.Articulos = drInf.GetString(pi2);
        //                                                                                    oCamposInfraccion.Encisos = drInf.GetString(pi3);
        //                                                                                    oCamposSupervision.ListInfracciones.Add(oCamposInfraccion);
        //                                                                                }
        //                                                                            }
        //                                                                        }

        //                                                                    oCamposPOA.ListSupervision.Add(oCamposSupervision);

        //                                                                }
        //                                                            }
        //                                                        }
        //                                                    #endregion


        //                                                    oCEntidad = new CEntidad();
        //                                                    oCEntidad.NUM_POA = oCamposPOA.NUM_POA;
        //                                                    oCEntidad.COD_THABILITANTE = oCamposPOA.COD_THABILITANTE;
        //                                                    oCEntidad.BusCriterio = "PC";
        //                                                    #region Plan Complementarios
        //                                                    using (OracleDataReader drPOAC = dBOracle.SelDrdDefault(cn, null, "DOC.spREstado_TH_POA_CAT", oCEntidad))
        //                                                        if (drPOAC != null)
        //                                                        {
        //                                                            oCamposPOA.ListPOACompl = new List<CEntidad>();
        //                                                            oCamposPOAComp = new CEntidad();
        //                                                            if (drPOAC.HasRows)
        //                                                            {
        //                                                                int pc1 = drPOAC.GetOrdinal("COD_THABILITANTE");
        //                                                                int pc2 = drPOAC.GetOrdinal("NUM_POA");
        //                                                                int pc3 = drPOAC.GetOrdinal("ARESOLUCION_NUM");
        //                                                                int pc4 = drPOAC.GetOrdinal("ESTADO_ORIGEN_TIPO");
        //                                                                int pc5 = drPOAC.GetOrdinal("ESTADO_ORIGEN");
        //                                                                int pc6 = drPOAC.GetOrdinal("HIJO_COD_THABILITANTE");
        //                                                                int pc7 = drPOAC.GetOrdinal("HIJO_NUM_POA");
        //                                                                int pc8 = drPOAC.GetOrdinal("HIJO_NIVEL");

        //                                                                while (drPOAC.Read())
        //                                                                {
        //                                                                    oCamposPOAComp = new CEntidad();
        //                                                                    oCamposPOAComp.COD_THABILITANTE = drPOAC.GetString(pc1);
        //                                                                    oCamposPOAComp.NUM_POA = drPOAC.GetInt32(pc2);
        //                                                                    oCamposPOAComp.ARESOLUCION_NUM = drPOAC.GetString(pc3);
        //                                                                    oCamposPOAComp.ESTADO_ORIGEN_TIPO = drPOAC.GetString(pc4);
        //                                                                    oCamposPOAComp.ESTADO_ORIGEN = drPOAC.GetString(pc5);
        //                                                                    oCamposPOAComp.HIJO_COD_THABILITANTE = drPOAC.GetString(pc6);
        //                                                                    oCamposPOAComp.HIJO_NUM_POA = drPOAC.GetInt32(pc7);
        //                                                                    oCamposPOAComp.HIJO_NIVEL = drPOAC.GetInt32(pc8);

        //                                                                    oCEntidad = new CEntidad();
        //                                                                    oCEntidad.NUM_POA = oCamposPOAComp.NUM_POA;
        //                                                                    oCEntidad.COD_THABILITANTE = oCamposPOAComp.COD_THABILITANTE;
        //                                                                    #region Supervisiones POA Complementario
        //                                                                    using (OracleDataReader drSupC = dBOracle.SelDrdDefault(cn, null, "DOC.spRHistorial_TH_POA_Listar_Superv", oCEntidad))
        //                                                                        if (drSupC != null)
        //                                                                        {
        //                                                                            oCamposPOAComp.ListSupervision = new List<CEntidad>();
        //                                                                            oCamposSupervision = new CEntidad();
        //                                                                            if (drSupC.HasRows)
        //                                                                            {
        //                                                                                int psc1 = drSupC.GetOrdinal("COD_THABILITANTE");
        //                                                                                int psc2 = drSupC.GetOrdinal("NUM_POA");
        //                                                                                int psc5 = drSupC.GetOrdinal("COD_RESODIREC");
        //                                                                                int psc6 = drSupC.GetOrdinal("NUMERO_RESOLUCION");
        //                                                                                int psc3 = drSupC.GetOrdinal("COD_ITIPO");
        //                                                                                int psc4 = drSupC.GetOrdinal("Fecha_Sup");
        //                                                                                int psc7 = drSupC.GetOrdinal("MEDIDAS_CAUTELARES");
        //                                                                                int psc8 = drSupC.GetOrdinal("CAUSALES_CADUCIDAD");

        //                                                                                int psc9 = drSupC.GetOrdinal("ileg_Descrip");
        //                                                                                int psc10 = drSupC.GetOrdinal("RD_tipo");
        //                                                                                int psc11 = drSupC.GetOrdinal("COD_RESODIREC_Inicio");
        //                                                                                int psc12 = drSupC.GetOrdinal("Tipo_Inicio");
        //                                                                                int psc13 = drSupC.GetOrdinal("RD_termino");
        //                                                                                int psc14 = drSupC.GetOrdinal("COD_RESODIREC_Termino");
        //                                                                                int psc15 = drSupC.GetOrdinal("Tipo_Termino");
        //                                                                                int psc16 = drSupC.GetOrdinal("descripFin");


        //                                                                                while (drSupC.Read())
        //                                                                                {
        //                                                                                    oCamposSupervision = new CEntidad();
        //                                                                                    oCamposSupervision.COD_THABILITANTE = drSupC.GetString(psc1);
        //                                                                                    oCamposSupervision.NUM_POA = drSupC.GetInt32(psc2);
        //                                                                                    oCamposSupervision.COD_ITIPO = drSupC.GetString(psc3);
        //                                                                                    oCamposSupervision.Fecha_Sup = drSupC.GetString(psc4);
        //                                                                                    oCamposSupervision.COD_RESODIREC = drSupC.GetString(psc5);
        //                                                                                    oCamposSupervision.NUMERO_RESOLUCION = drSupC.GetString(psc6);
        //                                                                                    oCamposSupervision.MEDIDAS_CAUTELARES = drSupC.GetBoolean(psc7);
        //                                                                                    oCamposSupervision.CAUSALES_CADUCIDAD = drSupC.GetBoolean(psc8);

        //                                                                                    oCamposSupervision.ileg_Descrip = drSupC.GetString(psc9);
        //                                                                                    oCamposSupervision.RD_tipo = drSupC.GetString(psc10);
        //                                                                                    oCamposSupervision.COD_RESODIREC_Inicio = drSupC.GetString(psc11);
        //                                                                                    oCamposSupervision.Tipo_Inicio = drSupC.GetString(psc12);
        //                                                                                    oCamposSupervision.RD_termino = drSupC.GetString(psc13);
        //                                                                                    oCamposSupervision.COD_RESODIREC_Termino = drSupC.GetString(psc14);
        //                                                                                    oCamposSupervision.Tipo_Termino = drSupC.GetString(psc15);
        //                                                                                    oCamposSupervision.descripFin = drSupC.GetString(psc16);

        //                                                                                    //infracciones
        //                                                                                    oCEntidad = new CEntidad();
        //                                                                                    oCEntidad.COD_RESODIREC = oCamposSupervision.COD_RESODIREC;
        //                                                                                    using (OracleDataReader drInf = dBOracle.SelDrdDefault(cn, null, "DOC.spRHistorial_TH_POA_List_Infracciones", oCEntidad))
        //                                                                                        if (drInf != null)
        //                                                                                        {
        //                                                                                            oCamposSupervision.ListInfracciones = new List<CEntidad>();
        //                                                                                            oCamposInfraccion = new CEntidad();
        //                                                                                            if (drInf.HasRows)
        //                                                                                            {
        //                                                                                                int pi1 = drInf.GetOrdinal("COD_RESODIREC");
        //                                                                                                int pi2 = drInf.GetOrdinal("articulo");
        //                                                                                                int pi3 = drInf.GetOrdinal("enciso");

        //                                                                                                while (drInf.Read())
        //                                                                                                {
        //                                                                                                    oCamposInfraccion = new CEntidad();
        //                                                                                                    oCamposInfraccion.COD_RESODIREC = drInf.GetString(pi1);
        //                                                                                                    oCamposInfraccion.Articulos = drInf.GetString(pi2);
        //                                                                                                    oCamposInfraccion.Encisos = drInf.GetString(pi3);
        //                                                                                                    oCamposSupervision.ListInfracciones.Add(oCamposInfraccion);
        //                                                                                                }
        //                                                                                            }
        //                                                                                        }

        //                                                                                    oCamposPOAComp.ListSupervision.Add(oCamposSupervision);

        //                                                                                }
        //                                                                            }
        //                                                                        }
        //                                                                    #endregion
        //                                                                    oCamposPOA.ListPOACompl.Add(oCamposPOAComp);
        //                                                                }
        //                                                            }
        //                                                        }
        //                                                    #endregion

        //                                                    oCEntidad = new CEntidad();
        //                                                    oCEntidad.NUM_POA = oCamposPOA.NUM_POA;
        //                                                    oCEntidad.COD_THABILITANTE = oCamposPOA.COD_THABILITANTE;
        //                                                    oCEntidad.BusCriterio = "R";
        //                                                    #region Reingreso
        //                                                    using (OracleDataReader drPOAR = dBOracle.SelDrdDefault(cn, null, "DOC.spREstado_TH_POA_CAT", oCEntidad))
        //                                                        if (drPOAR != null)
        //                                                        {
        //                                                            oCamposPOA.ListPOAReing = new List<CEntidad>();
        //                                                            oCamposPOAReing = new CEntidad();
        //                                                            if (drPOAR.HasRows)
        //                                                            {
        //                                                                int pr1 = drPOAR.GetOrdinal("COD_THABILITANTE");
        //                                                                int pr2 = drPOAR.GetOrdinal("NUM_POA");
        //                                                                int pr3 = drPOAR.GetOrdinal("ARESOLUCION_NUM");
        //                                                                int pr4 = drPOAR.GetOrdinal("ESTADO_ORIGEN_TIPO");
        //                                                                int pr5 = drPOAR.GetOrdinal("ESTADO_ORIGEN");
        //                                                                int pr6 = drPOAR.GetOrdinal("HIJO_COD_THABILITANTE");
        //                                                                int pr7 = drPOAR.GetOrdinal("HIJO_NUM_POA");
        //                                                                int pr8 = drPOAR.GetOrdinal("HIJO_NIVEL");

        //                                                                while (drPOAR.Read())
        //                                                                {
        //                                                                    oCamposPOAReing = new CEntidad();
        //                                                                    oCamposPOAReing.COD_THABILITANTE = drPOAR.GetString(pr1);
        //                                                                    oCamposPOAReing.NUM_POA = drPOAR.GetInt32(pr2);
        //                                                                    oCamposPOAReing.ARESOLUCION_NUM = drPOAR.GetString(pr3);
        //                                                                    oCamposPOAReing.ESTADO_ORIGEN_TIPO = drPOAR.GetString(pr4);
        //                                                                    oCamposPOAReing.ESTADO_ORIGEN = drPOAR.GetString(pr5);
        //                                                                    oCamposPOAReing.HIJO_COD_THABILITANTE = drPOAR.GetString(pr6);
        //                                                                    oCamposPOAReing.HIJO_NUM_POA = drPOAR.GetInt32(pr7);
        //                                                                    oCamposPOAReing.HIJO_NIVEL = drPOAR.GetInt32(pr8);

        //                                                                    oCEntidad = new CEntidad();
        //                                                                    oCEntidad.NUM_POA = oCamposPOAReing.NUM_POA;
        //                                                                    oCEntidad.COD_THABILITANTE = oCamposPOAReing.COD_THABILITANTE;
        //                                                                    #region Supervisiones POA Complementario
        //                                                                    using (OracleDataReader drSupC = dBOracle.SelDrdDefault(cn, null, "DOC.spRHistorial_TH_POA_Listar_Superv", oCEntidad))
        //                                                                        if (drSupC != null)
        //                                                                        {
        //                                                                            oCamposPOAReing.ListSupervision = new List<CEntidad>();
        //                                                                            oCamposSupervision = new CEntidad();
        //                                                                            if (drSupC.HasRows)
        //                                                                            {
        //                                                                                int psc1 = drSupC.GetOrdinal("COD_THABILITANTE");
        //                                                                                int psc2 = drSupC.GetOrdinal("NUM_POA");
        //                                                                                int psc5 = drSupC.GetOrdinal("COD_RESODIREC");
        //                                                                                int psc6 = drSupC.GetOrdinal("NUMERO_RESOLUCION");
        //                                                                                int psc3 = drSupC.GetOrdinal("COD_ITIPO");
        //                                                                                int psc4 = drSupC.GetOrdinal("Fecha_Sup");
        //                                                                                int psc7 = drSupC.GetOrdinal("MEDIDAS_CAUTELARES");
        //                                                                                int psc8 = drSupC.GetOrdinal("CAUSALES_CADUCIDAD");

        //                                                                                int psc9 = drSupC.GetOrdinal("ileg_Descrip");
        //                                                                                int psc10 = drSupC.GetOrdinal("RD_tipo");
        //                                                                                int psc11 = drSupC.GetOrdinal("COD_RESODIREC_Inicio");
        //                                                                                int psc12 = drSupC.GetOrdinal("Tipo_Inicio");
        //                                                                                int psc13 = drSupC.GetOrdinal("RD_termino");
        //                                                                                int psc14 = drSupC.GetOrdinal("COD_RESODIREC_Termino");
        //                                                                                int psc15 = drSupC.GetOrdinal("Tipo_Termino");
        //                                                                                int psc16 = drSupC.GetOrdinal("descripFin");


        //                                                                                while (drSupC.Read())
        //                                                                                {
        //                                                                                    oCamposSupervision = new CEntidad();
        //                                                                                    oCamposSupervision.COD_THABILITANTE = drSupC.GetString(psc1);
        //                                                                                    oCamposSupervision.NUM_POA = drSupC.GetInt32(psc2);
        //                                                                                    oCamposSupervision.COD_ITIPO = drSupC.GetString(psc3);
        //                                                                                    oCamposSupervision.Fecha_Sup = drSupC.GetString(psc4);
        //                                                                                    oCamposSupervision.COD_RESODIREC = drSupC.GetString(psc5);
        //                                                                                    oCamposSupervision.NUMERO_RESOLUCION = drSupC.GetString(psc6);
        //                                                                                    oCamposSupervision.MEDIDAS_CAUTELARES = drSupC.GetBoolean(psc7);
        //                                                                                    oCamposSupervision.CAUSALES_CADUCIDAD = drSupC.GetBoolean(psc8);

        //                                                                                    oCamposSupervision.ileg_Descrip = drSupC.GetString(psc9);
        //                                                                                    oCamposSupervision.RD_tipo = drSupC.GetString(psc10);
        //                                                                                    oCamposSupervision.COD_RESODIREC_Inicio = drSupC.GetString(psc11);
        //                                                                                    oCamposSupervision.Tipo_Inicio = drSupC.GetString(psc12);
        //                                                                                    oCamposSupervision.RD_termino = drSupC.GetString(psc13);
        //                                                                                    oCamposSupervision.COD_RESODIREC_Termino = drSupC.GetString(psc14);
        //                                                                                    oCamposSupervision.Tipo_Termino = drSupC.GetString(psc15);
        //                                                                                    oCamposSupervision.descripFin = drSupC.GetString(psc16);

        //                                                                                    //infracciones
        //                                                                                    oCEntidad = new CEntidad();
        //                                                                                    oCEntidad.COD_RESODIREC = oCamposSupervision.COD_RESODIREC;
        //                                                                                    using (OracleDataReader drInf = dBOracle.SelDrdDefault(cn, null, "DOC.spRHistorial_TH_POA_List_Infracciones", oCEntidad))
        //                                                                                        if (drInf != null)
        //                                                                                        {
        //                                                                                            oCamposSupervision.ListInfracciones = new List<CEntidad>();
        //                                                                                            oCamposInfraccion = new CEntidad();
        //                                                                                            if (drInf.HasRows)
        //                                                                                            {
        //                                                                                                int pi1 = drInf.GetOrdinal("COD_RESODIREC");
        //                                                                                                int pi2 = drInf.GetOrdinal("articulo");
        //                                                                                                int pi3 = drInf.GetOrdinal("enciso");

        //                                                                                                while (drInf.Read())
        //                                                                                                {
        //                                                                                                    oCamposInfraccion = new CEntidad();
        //                                                                                                    oCamposInfraccion.COD_RESODIREC = drInf.GetString(pi1);
        //                                                                                                    oCamposInfraccion.Articulos = drInf.GetString(pi2);
        //                                                                                                    oCamposInfraccion.Encisos = drInf.GetString(pi3);
        //                                                                                                    oCamposSupervision.ListInfracciones.Add(oCamposInfraccion);
        //                                                                                                }
        //                                                                                            }
        //                                                                                        }

        //                                                                                    oCamposPOAReing.ListSupervision.Add(oCamposSupervision);

        //                                                                                }
        //                                                                            }
        //                                                                        }
        //                                                                    #endregion
        //                                                                    oCamposPOA.ListPOAReing.Add(oCamposPOAReing);
        //                                                                }
        //                                                            }
        //                                                        }
        //                                                    #endregion

        //                                                    oCEntidad = new CEntidad();
        //                                                    oCEntidad.NUM_POA = oCamposPOA.NUM_POA;
        //                                                    oCEntidad.COD_THABILITANTE = oCamposPOA.COD_THABILITANTE;
        //                                                    oCEntidad.BusCriterio = "MS";
        //                                                    #region Movilizacion de Saldo
        //                                                    using (OracleDataReader drPOAMS = dBOracle.SelDrdDefault(cn, null, "DOC.spREstado_TH_POA_CAT", oCEntidad))
        //                                                        if (drPOAMS != null)
        //                                                        {
        //                                                            oCamposPOA.ListPOAMSaldo = new List<CEntidad>();
        //                                                            oCamposPOAMS = new CEntidad();
        //                                                            if (drPOAMS.HasRows)
        //                                                            {
        //                                                                int pr1 = drPOAMS.GetOrdinal("COD_THABILITANTE");
        //                                                                int pr2 = drPOAMS.GetOrdinal("NUM_POA");
        //                                                                int pr3 = drPOAMS.GetOrdinal("ARESOLUCION_NUM");
        //                                                                int pr4 = drPOAMS.GetOrdinal("ESTADO_ORIGEN_TIPO");
        //                                                                int pr5 = drPOAMS.GetOrdinal("ESTADO_ORIGEN");
        //                                                                int pr6 = drPOAMS.GetOrdinal("HIJO_COD_THABILITANTE");
        //                                                                int pr7 = drPOAMS.GetOrdinal("HIJO_NUM_POA");
        //                                                                int pr8 = drPOAMS.GetOrdinal("HIJO_NIVEL");

        //                                                                while (drPOAMS.Read())
        //                                                                {
        //                                                                    oCamposPOAMS = new CEntidad();
        //                                                                    oCamposPOAMS.COD_THABILITANTE = drPOAMS.GetString(pr1);
        //                                                                    oCamposPOAMS.NUM_POA = drPOAMS.GetInt32(pr2);
        //                                                                    oCamposPOAMS.ARESOLUCION_NUM = drPOAMS.GetString(pr3);
        //                                                                    oCamposPOAMS.ESTADO_ORIGEN_TIPO = drPOAMS.GetString(pr4);
        //                                                                    oCamposPOAMS.ESTADO_ORIGEN = drPOAMS.GetString(pr5);
        //                                                                    oCamposPOAMS.HIJO_COD_THABILITANTE = drPOAMS.GetString(pr6);
        //                                                                    oCamposPOAMS.HIJO_NUM_POA = drPOAMS.GetInt32(pr7);
        //                                                                    oCamposPOAMS.HIJO_NIVEL = drPOAMS.GetInt32(pr8);

        //                                                                    oCEntidad = new CEntidad();
        //                                                                    oCEntidad.NUM_POA = oCamposPOAMS.NUM_POA;
        //                                                                    oCEntidad.COD_THABILITANTE = oCamposPOAMS.COD_THABILITANTE;
        //                                                                    #region Supervisiones POA Movilizacion de Saldo
        //                                                                    using (OracleDataReader drSupC = dBOracle.SelDrdDefault(cn, null, "DOC.spRHistorial_TH_POA_Listar_Superv", oCEntidad))
        //                                                                        if (drSupC != null)
        //                                                                        {
        //                                                                            oCamposPOAMS.ListSupervision = new List<CEntidad>();
        //                                                                            oCamposSupervision = new CEntidad();
        //                                                                            if (drSupC.HasRows)
        //                                                                            {
        //                                                                                int psc1 = drSupC.GetOrdinal("COD_THABILITANTE");
        //                                                                                int psc2 = drSupC.GetOrdinal("NUM_POA");
        //                                                                                int psc5 = drSupC.GetOrdinal("COD_RESODIREC");
        //                                                                                int psc6 = drSupC.GetOrdinal("NUMERO_RESOLUCION");
        //                                                                                int psc3 = drSupC.GetOrdinal("COD_ITIPO");
        //                                                                                int psc4 = drSupC.GetOrdinal("Fecha_Sup");
        //                                                                                int psc7 = drSupC.GetOrdinal("MEDIDAS_CAUTELARES");
        //                                                                                int psc8 = drSupC.GetOrdinal("CAUSALES_CADUCIDAD");

        //                                                                                int psc9 = drSupC.GetOrdinal("ileg_Descrip");
        //                                                                                int psc10 = drSupC.GetOrdinal("RD_tipo");
        //                                                                                int psc11 = drSupC.GetOrdinal("COD_RESODIREC_Inicio");
        //                                                                                int psc12 = drSupC.GetOrdinal("Tipo_Inicio");
        //                                                                                int psc13 = drSupC.GetOrdinal("RD_termino");
        //                                                                                int psc14 = drSupC.GetOrdinal("COD_RESODIREC_Termino");
        //                                                                                int psc15 = drSupC.GetOrdinal("Tipo_Termino");
        //                                                                                int psc16 = drSupC.GetOrdinal("descripFin");


        //                                                                                while (drSupC.Read())
        //                                                                                {
        //                                                                                    oCamposSupervision = new CEntidad();
        //                                                                                    oCamposSupervision.COD_THABILITANTE = drSupC.GetString(psc1);
        //                                                                                    oCamposSupervision.NUM_POA = drSupC.GetInt32(psc2);
        //                                                                                    oCamposSupervision.COD_ITIPO = drSupC.GetString(psc3);
        //                                                                                    oCamposSupervision.Fecha_Sup = drSupC.GetString(psc4);
        //                                                                                    oCamposSupervision.COD_RESODIREC = drSupC.GetString(psc5);
        //                                                                                    oCamposSupervision.NUMERO_RESOLUCION = drSupC.GetString(psc6);
        //                                                                                    oCamposSupervision.MEDIDAS_CAUTELARES = drSupC.GetBoolean(psc7);
        //                                                                                    oCamposSupervision.CAUSALES_CADUCIDAD = drSupC.GetBoolean(psc8);

        //                                                                                    oCamposSupervision.ileg_Descrip = drSupC.GetString(psc9);
        //                                                                                    oCamposSupervision.RD_tipo = drSupC.GetString(psc10);
        //                                                                                    oCamposSupervision.COD_RESODIREC_Inicio = drSupC.GetString(psc11);
        //                                                                                    oCamposSupervision.Tipo_Inicio = drSupC.GetString(psc12);
        //                                                                                    oCamposSupervision.RD_termino = drSupC.GetString(psc13);
        //                                                                                    oCamposSupervision.COD_RESODIREC_Termino = drSupC.GetString(psc14);
        //                                                                                    oCamposSupervision.Tipo_Termino = drSupC.GetString(psc15);
        //                                                                                    oCamposSupervision.descripFin = drSupC.GetString(psc16);

        //                                                                                    //infracciones
        //                                                                                    oCEntidad = new CEntidad();
        //                                                                                    oCEntidad.COD_RESODIREC = oCamposSupervision.COD_RESODIREC;
        //                                                                                    using (OracleDataReader drInf = dBOracle.SelDrdDefault(cn, null, "DOC.spRHistorial_TH_POA_List_Infracciones", oCEntidad))
        //                                                                                        if (drInf != null)
        //                                                                                        {
        //                                                                                            oCamposSupervision.ListInfracciones = new List<CEntidad>();
        //                                                                                            oCamposInfraccion = new CEntidad();
        //                                                                                            if (drInf.HasRows)
        //                                                                                            {
        //                                                                                                int pi1 = drInf.GetOrdinal("COD_RESODIREC");
        //                                                                                                int pi2 = drInf.GetOrdinal("articulo");
        //                                                                                                int pi3 = drInf.GetOrdinal("enciso");

        //                                                                                                while (drInf.Read())
        //                                                                                                {
        //                                                                                                    oCamposInfraccion = new CEntidad();
        //                                                                                                    oCamposInfraccion.COD_RESODIREC = drInf.GetString(pi1);
        //                                                                                                    oCamposInfraccion.Articulos = drInf.GetString(pi2);
        //                                                                                                    oCamposInfraccion.Encisos = drInf.GetString(pi3);
        //                                                                                                    oCamposSupervision.ListInfracciones.Add(oCamposInfraccion);
        //                                                                                                }
        //                                                                                            }
        //                                                                                        }

        //                                                                                    oCamposPOAMS.ListSupervision.Add(oCamposSupervision);

        //                                                                                }
        //                                                                            }
        //                                                                        }
        //                                                                    #endregion
        //                                                                    oCamposPOA.ListPOAMSaldo.Add(oCamposPOAMS);
        //                                                                }
        //                                                            }
        //                                                        }
        //                                                    #endregion

        //                                                }
        //                                                catch (Exception ex)
        //                                                {
        //                                                    throw ex;
        //                                                }

        //                                                oCampos.ListPOATH.Add(oCamposPOA);
        //                                            }
        //                                        }
        //                                    }
        //                            }
        //                            catch (Exception ex)
        //                            {
        //                                throw ex;
        //                            }

        //                        }
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

        /**
         * metodo para obtener la lista de los arboles supervisados
         */
        public List<CEntidad> listInfSup_Arboles(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> List_Informe = new List<CEntidad>();

            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spRHistorial_TH_Titulo_Habilitante", oCEntidad))
                {
                    // INFORMES
                    if (dr.HasRows)
                    {
                        CEntidad oCampos2 = new CEntidad();
                        if (dr.HasRows)
                        {
                            int pt0 = dr.GetOrdinal("COD_ESPECIES");
                            int pt1 = dr.GetOrdinal("NOMBRE_COMUN");
                            int pt2 = dr.GetOrdinal("ESPECIES");
                            int pt3 = dr.GetOrdinal("INXISTENCIA");
                            int pt4 = dr.GetOrdinal("PORCENTAJE_INEX");
                            int pt5 = dr.GetOrdinal("EN_PIE");
                            int pt6 = dr.GetOrdinal("TUMBADO");
                            int pt7 = dr.GetOrdinal("TOCON");
                            int pt8 = dr.GetOrdinal("NO_EVALUADO");
                            int pt9 = dr.GetOrdinal("SIN_DATOS");



                            while (dr.Read())
                            {
                                //PARTE_DIARIO_DETALLE
                                oCampos2 = new CEntidad();
                                oCampos2.COD_ESPECIES = dr.GetString(pt0);
                                oCampos2.NOMBRE_COMUN = dr.GetString(pt1);
                                oCampos2.ESPECIES = dr.GetInt32(pt2);
                                oCampos2.INXISTENCIA = dr.GetInt32(pt3);
                                oCampos2.PORCENTAJE_INEX = dr.GetDecimal(pt4);
                                oCampos2.EN_PIE = dr.GetInt32(pt5);
                                oCampos2.TUMBADO = dr.GetInt32(pt6);
                                oCampos2.TOCON = dr.GetInt32(pt7);
                                oCampos2.NO_EVALUADO = dr.GetInt32(pt8);
                                oCampos2.SIN_DATOS = dr.GetInt32(pt9);
                                List_Informe.Add(oCampos2);
                            }
                        }

                    }

                    return List_Informe;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        // para las notificaciones
        public CEntidad RD_Notificacion(OracleConnection cn, CEntidad oCEntidad)
        {
            CEntidad Notificacion = new CEntidad();

            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spRHistorial_TH_Titulo_Habilitante", oCEntidad))
                {
                    // INFORMES
                    if (dr.HasRows)
                    {
                        CEntidad oCampos2 = new CEntidad();
                        if (dr.HasRows)
                        {
                            int pt0 = dr.GetOrdinal("FECHA_NOTIFICACION");
                            int pt1 = dr.GetOrdinal("PERSONA_NOTIFICADA");
                            int pt2 = dr.GetOrdinal("PARENTESCO");

                            while (dr.Read())
                            {
                                //PARTE_DIARIO_DETALLE
                                oCampos2 = new CEntidad();
                                oCampos2.FECHA_NOT = dr["FECHA_NOTIFICACION"].ToString();
                                oCampos2.PERSONA_NOT = dr.GetString(pt1);
                                oCampos2.PARENTESCO = dr.GetString(pt2);
                                Notificacion = oCampos2;

                            }
                        }

                    }
                    return Notificacion;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // documentacion presentada por el titular
        public List<CEntidad> dat_InformacionTitrula(OracleConnection cn, CEntidad oCEntidad)
        {
            CEntidad Notificacion = new CEntidad();
            List<CEntidad> listInformacionTitular = new List<CEntidad>();

            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spRHistorial_TH_Titulo_Habilitante", oCEntidad))
                {
                    // INFORMES
                    if (dr.HasRows)
                    {
                        CEntidad oCampos2 = new CEntidad();
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("NUMERO");
                            int pt2 = dr.GetOrdinal("TIPO_FISCALIZA");
                            int pt3 = dr.GetOrdinal("NUMERO_EXPEDIENTE");
                            int pt8 = dr.GetOrdinal("FECHA");

                            while (dr.Read())
                            {
                                //PARTE_DIARIO_DETALLE
                                oCampos2 = new CEntidad();
                                oCampos2.NUMERO = dr.GetString(pt1);
                                oCampos2.Tipo_Inicio = dr.GetString(pt2);
                                oCampos2.NUM_CNOTIFICACION = dr.GetString(pt3);
                                oCampos2.fecha_aprobacion = dr["FECHA"].ToString();
                                listInformacionTitular.Add(oCampos2);
                            }
                        }

                    }
                    return listInformacionTitular;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // metodos para las adendas
        public List<CEntidad> dat_AdendaTH(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> listAdendas = new List<CEntidad>();

            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spRHistorial_TH_Titulo_Habilitante", oCEntidad))
                {
                    // INFORMES
                    if (dr.HasRows)
                    {
                        CEntidad oCampos2 = new CEntidad();
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("TIPO");
                            int pt2 = dr.GetOrdinal("FECHA");
                            int pt3 = dr.GetOrdinal("OBSERVACION");
                            int pt4 = dr.GetOrdinal("TITULAR");

                            while (dr.Read())
                            {
                                //PARTE_DIARIO_DETALLE
                                oCampos2 = new CEntidad();
                                oCampos2.Tipo_Inicio = dr.GetString(pt1);
                                oCampos2.fecha_aprobacion = dr.GetString(pt2);
                                oCampos2.OBSERVACIONES = dr.GetString(pt3);
                                oCampos2.TITULAR = dr.GetString(pt4);
                                listAdendas.Add(oCampos2);
                            }
                        }

                    }
                    return listAdendas;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //metodo para los domicilios del titulo habilitante
        public List<CEntidad> dat_DomicilioTH(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> listAdendas = new List<CEntidad>();

            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spRHistorial_TH_Titulo_Habilitante", oCEntidad))
                {
                    // INFORMES
                    if (dr.HasRows)
                    {
                        CEntidad oCampos2 = new CEntidad();
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("FUENTE");
                            int pt2 = dr.GetOrdinal("FECHA");
                            int pt3 = dr.GetOrdinal("DIRECCION");

                            while (dr.Read())
                            {
                                //PARTE_DIARIO_DETALLE
                                oCampos2 = new CEntidad();
                                oCampos2.Tipo_Inicio = dr["FUENTE"].ToString();
                                oCampos2.fecha_aprobacion = dr["FECHA"].ToString();
                                oCampos2.OBSERVACIONES = dr["DIRECCION"].ToString();
                                listAdendas.Add(oCampos2);
                            }
                        }

                    }
                    return listAdendas;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //especies
        //metodo para los domicilios del titulo habilitante
        public List<CEntidad> dat_EspeciesTH(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> listAdendas = new List<CEntidad>();

            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "doc_OSINFOR_ERP_MIGRACION.spRHistorial_TH_Titulo_Habilitante", oCEntidad))
                {
                    // INFORMES
                    if (dr.HasRows)
                    {
                        CEntidad oCampos2 = new CEntidad();
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("DESCRIPCION_ARTICULOS");
                            int pt2 = dr.GetOrdinal("DESCRIPCION_ENCISOS");
                            int pt3 = dr.GetOrdinal("VOLUMEN");
                            int pt4 = dr.GetOrdinal("DESCRIPCION_ESPECIE");
                            int pt5 = dr.GetOrdinal("AREA");
                            int pt6 = dr.GetOrdinal("NUMERO_INDIVIDUOS");
                            int pt7 = dr.GetOrdinal("DESCRIPCION_INFRACCIONES");
                            int pt8 = dr.GetOrdinal("POA");


                            while (dr.Read())
                            {
                                //PARTE_DIARIO_DETALLE
                                oCampos2 = new CEntidad();
                                oCampos2.Articulos = dr.GetString(pt1);
                                oCampos2.Encisos = dr.GetString(pt2);
                                oCampos2.VOLUMEN_INEXISTENTE = dr.GetDecimal(pt3);
                                oCampos2.NOMBRE_COMUN = dr.GetString(pt4);
                                oCampos2.AREA_O = dr.GetDecimal(pt5);
                                oCampos2.NUMERO_ARBOLES = dr.GetInt32(pt6);
                                oCampos2.descripFin = dr.GetString(pt7);
                                oCampos2.NUM_EXP = dr.GetString(pt8);


                                listAdendas.Add(oCampos2);
                            }
                        }

                    }
                    return listAdendas;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //METODO JOEL
        public CEntidad dat_EstadoProcesoJudicializado_O(OracleConnection cn, CEntidad oCEntidad)
        {
           

            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdRow(cn, null, "DOC_OSINFOR_ERP_MIGRACION.SPASESORIALEGAL_OSINFOR_ESTADOPROCESOJUDICIALIZADOS", oCEntidad))
                {
                    CEntidad oCampos = new CEntidad();
                   
                   
                    if (dr.HasRows)
                    {
                        int pt1 = dr.GetOrdinal("NUMEROTITULOHABILITANTE");
                        int pt2 = dr.GetOrdinal("TITULAR");
                        int pt3 = dr.GetOrdinal("NUMERORESOLUCIONDIRECTORAL");
                        int pt4 = dr.GetOrdinal("FECHANOTIFICACION");
                        int pt5 = dr.GetOrdinal("NUMERO_EXP");
                        int pt6 = dr.GetOrdinal("ESTADO");
                        //PARTE_DIARIO_DETALLE
                        oCampos = new CEntidad();
                        oCampos.NUM_THABILITANTE = dr.GetString(pt1);
                        oCampos.TITULAR = dr.GetString(pt2);
                        oCampos.NUMERO_RESOLUCION = dr.GetString(pt3);
                        oCampos.FECHA_NOTIFICACION_RDTERMINO = dr.GetString(pt4);
                        oCampos.NUM_EXP = dr.GetString(pt5);
                        oCampos.ESTADO_PROCESOJUDICIALIZADO = dr.GetString(pt6);
                    }
                    return oCampos;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<CEntidad> dat_EstadoProcesoJudicializado_S(SqlConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lista = new List<CEntidad>();

            try
            {
                using (SqlDataReader dr = oGDataSQL.SelDrdDefault(cn, null, "OAJ.spAsesoriaLegal_OSINFOR_BusquedaJudicializados", oCEntidad))
                {
                    CEntidad oCampos = new CEntidad();
                    
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                           
                            int pt1 = dr.GetOrdinal("NUMEROTITULOHABILITANTE");
                            int pt2 = dr.GetOrdinal("TITULAR");
                            int pt3 = dr.GetOrdinal("NUMERORESOLUCIONDIRECTORAL");
                            int pt4 = dr.GetOrdinal("FECHANOTIFICACION");
                            int pt5 = dr.GetOrdinal("NUMERO_EXP");
                            int pt6 = dr.GetOrdinal("ESTADO");
                            int pt7 = dr.GetOrdinal("TIPOEXPEDIENTE");
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                oCampos.NUM_THABILITANTE = dr.GetString(pt1);
                                oCampos.TITULAR = dr.GetString(pt2);
                                oCampos.NUMERO_RESOLUCION = dr.GetString(pt3);
                                oCampos.FECHA_NOTIFICACION_RDTERMINO = dr.GetDateTime(pt4).ToString("dd/MM/yyyy");
                                oCampos.NUM_EXP = dr.GetString(pt5);
                                oCampos.ESTADO_PROCESOJUDICIALIZADO = dr.GetString(pt6);
                                oCampos.TIPO_EXPEDIENTE_RD = dr.GetString(pt7);
                                lista.Add(oCampos);
                            }
                        }

                    }
                                                          
                   
                    return lista;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CEntidad dat_ObtenerIdTitularPagos(SqlConnection cn, CEntidad oCEntidad)
        {


            try
            {
                using (SqlDataReader dr = oGDataSQL.SelDrdDefault(cn, null, "ingreso.usp_Contabilidad_ObtenerIdTransaccionTitular", oCEntidad))
                {
                    CEntidad oCampos = new CEntidad();

                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            dr.Read();
                            int pt1 = dr.GetOrdinal("RESIDENTITY");
                            int pt2 = dr.GetOrdinal("NOM_ESTADO_RESOLUCION");
                            int pt3 = dr.GetOrdinal("NOM_MODALIDAD_PAGO");
                            //oCampos = new CEntidad();
                            oCampos.ID_REGISTRO = dr.GetInt32(pt1);
                            oCampos.ESTADO_RESOLUCION = dr.GetString(pt2);
                            oCampos.MODALIDAD = dr.GetString(pt3);

                        }

                    }
                    return oCampos;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //DEUDA												
        public List<CEntidad> dat_ResumenDeuda(SqlConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> listDeudas = new List<CEntidad>();

            try
            {
                using (SqlDataReader dr = oGDataSQL.SelDrdDefault(cn, null, "ingreso.usp_Contabilidad_ConsolidadoResumenDeuda_Consultar", oCEntidad))
                {
                    CEntidad oCampos = new CEntidad();

                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                           
                            int pt1 = dr.GetOrdinal("id");
                            int pt2 = dr.GetOrdinal("uit");
                            int pt3 = dr.GetOrdinal("factor_uit");
                            int pt4 = dr.GetOrdinal("multa_impuesta");
                            int pt5 = dr.GetOrdinal("pago_multa");
                            int pt6 = dr.GetOrdinal("ajuste");
                            int pt7 = dr.GetOrdinal("descuento");
                            int pt8 = dr.GetOrdinal("compensacion");
                            int pt9 = dr.GetOrdinal("saldo");
                            int pt10 = dr.GetOrdinal("interes");
                            int pt11 = dr.GetOrdinal("total");
                            int pt12 = dr.GetOrdinal("cta_contable");
                            int pt13 = dr.GetOrdinal("otros_ingresos");

                            //oCampos = new CEntidad();
                            while (dr.Read())
                            {

                                oCampos = new CEntidad();
                                oCampos.ID_D = dr.GetInt32(pt1);
                                oCampos.UIT_D = dr.GetDecimal(pt2);
                                oCampos.FACTOR_UIT_D = dr.GetDecimal(pt3);
                                oCampos.MULTA_IMPUESTA_D = dr.GetDecimal(pt4);
                                oCampos.PAGO_MULTA_D = dr.GetDecimal(pt5);
                                oCampos.AJUSTE_D = dr.GetDecimal(pt6);
                                oCampos.DESCUENTO_D = dr.GetDecimal(pt7);
                                oCampos.COMPENSACION_D = dr.GetDecimal(pt8);
                                oCampos.SALDO_D = dr.GetDecimal(pt9);
                                oCampos.INTERES_D = dr.GetDecimal(pt10);
                                oCampos.TOTAL_D = dr.GetDecimal(pt11);
                                oCampos.CTA_CONTABLE_D = dr.IsDBNull(pt12) ? "" : dr.GetString(pt12);
                                oCampos.OTROS_INGRESOS_D = dr.GetDecimal(pt13);
                                listDeudas.Add(oCampos);
                            }
                           


                        }

                    }
                    return listDeudas;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //PAGOS												
        public List<CEntidad> dat_ResumenPagos(SqlConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> listPagos = new List<CEntidad>();

            try
            {
                using (SqlDataReader dr = oGDataSQL.SelDrdDefault(cn, null, "ingreso.usp_Contabilidad_ConsolidadoPagosRealizados_Consultar", oCEntidad))
                {
                    CEntidad oCampos = new CEntidad();

                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                           
                            //fecha	multa	interes	cuota	voucher	recibo	band	fecha_orden	otrosIngresos
                            int pt1 = dr.GetOrdinal("fecha");
                            int pt2 = dr.GetOrdinal("multa");
                            int pt3 = dr.GetOrdinal("interes");
                            int pt4 = dr.GetOrdinal("cuota");
                            int pt5 = dr.GetOrdinal("voucher");
                            int pt6 = dr.GetOrdinal("recibo");
                            int pt7 = dr.GetOrdinal("band");
                            int pt8 = dr.GetOrdinal("fecha_orden");
                            int pt9 = dr.GetOrdinal("otrosIngresos");
                           

                            //oCampos = new CEntidad();
                            while (dr.Read())
                            {

                                oCampos = new CEntidad();
                                oCampos.FECHA_P = dr.GetString(pt1);
                                oCampos.MULTA_P = dr.GetDouble(pt2);
                                oCampos.INTERES_P = dr.GetDouble(pt3);
                                oCampos.CUOTA_P = dr.GetDouble(pt4);
                                oCampos.VOUCHER_P = dr.GetString(pt5);
                                oCampos.RECIBO_P = dr.GetString(pt6);
                                oCampos.BAND_P = dr.GetString(pt7);
                                oCampos.FECHA_ORDEN_P = dr.IsDBNull(pt8)?"": dr.GetDateTime(pt8).ToString("dd/MM/yyyy");
                                oCampos.OTROSINGRESOS_P = dr.GetDouble(pt9);
                               
                                listPagos.Add(oCampos);
                            }
                          
                        }

                    }
                    return listPagos;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //CRONOGRAMA												
        public List<CEntidad> dat_ResumenCronograma(SqlConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> listCronograma = new List<CEntidad>();

            try
            {
                using (SqlDataReader dr = oGDataSQL.SelDrdDefault(cn, null, "ingreso.usp_Contabilidad_ConsolidadoComparativoFraccionamiento_Consultar", oCEntidad))
                {
                    CEntidad oCampos = new CEntidad();

                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            
                            //periodo	fecha	saldo	multa	interes	cuota	nroRecibo	periodo_p	fecha_p	saldo_p	multa_p	interes_p	cuota_p	nroRecibo_p
                            int pt1 = dr.GetOrdinal("periodo");
                            int pt2 = dr.GetOrdinal("fecha");
                            int pt3 = dr.GetOrdinal("saldo");
                            int pt4 = dr.GetOrdinal("multa");
                            int pt5 = dr.GetOrdinal("interes");
                            int pt6 = dr.GetOrdinal("cuota");
                            int pt7 = dr.GetOrdinal("nroRecibo");
                            int pt8 = dr.GetOrdinal("periodo_p");
                            int pt9 = dr.GetOrdinal("fecha_p");
                            int pt10 = dr.GetOrdinal("saldo_p");
                            int pt11 = dr.GetOrdinal("multa_p");
                            int pt12 = dr.GetOrdinal("interes_p");
                            int pt13 = dr.GetOrdinal("cuota_p");
                            int pt14 = dr.GetOrdinal("nroRecibo_p");

                            //oCampos = new CEntidad();
                            while (dr.Read())
                            {

                                oCampos = new CEntidad();
                                oCampos.PERIODO_C = dr.GetInt32(pt1);
                                oCampos.FECHA_C = dr.GetString(pt2);
                                oCampos.SALDO_C = dr.GetDecimal(pt3);
                                oCampos.MULTA_C = dr.GetDecimal(pt4);
                                oCampos.INTERES_C = dr.GetDecimal(pt5);
                                oCampos.CUOTA_C = dr.GetDecimal(pt6);
                                oCampos.NRORECIBO_C = dr.GetString(pt7);
                                oCampos.PERIODO_P_C = dr.GetInt32(pt8);
                                oCampos.FECHA_P_C = dr.GetString(pt9);
                                oCampos.SALDO_P_C = dr.GetDecimal(pt10);
                                oCampos.MULTA_P_C = dr.GetDecimal(pt11);
                                oCampos.INTERES_P_C = dr.GetDecimal(pt12);
                                oCampos.CUOTA_P_C = dr.GetDecimal(pt13);
                                oCampos.NRORECIBO_P_C = dr.GetString(pt14);

                                listCronograma.Add(oCampos);
                            }

                        }

                    }
                    return listCronograma;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //COMPENSACION												
        public List<CEntidad> dat_ResumenCompensacion(SqlConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> listCompensacion = new List<CEntidad>();

            try
            {
                using (SqlDataReader dr = oGDataSQL.SelDrdDefault(cn, null, "ingreso.usp_Contabilidad_ConsolidadoDatosModalidad_Consultar", oCEntidad))
                {
                    CEntidad oCampos = new CEntidad();

                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {

                            //
                            int pt1 = dr.GetOrdinal("SigCorrelativo");
                            int pt2 = dr.GetOrdinal("SigNomTitular");
                            int pt3 = dr.GetOrdinal("ResIdentity");      
                            int pt4 = dr.GetOrdinal("ResJefAprobComp_Nro");
                            int pt5 = dr.GetOrdinal("ResJefAprobComp_Fecha");
                            int pt6 = dr.GetOrdinal("ResJefAprobComp_NroActa");
                            int pt7 = dr.GetOrdinal("ResJefAprobComp_FechaNot");
                            int pt8 = dr.GetOrdinal("ResJefAprobCompFracc_Nro");
                            int pt9 = dr.GetOrdinal("ResJefAprobCompFracc_Fecha");
                            int pt10 = dr.GetOrdinal("ResJefAprobCompFracc_NroActa");
                            int pt11 = dr.GetOrdinal("ResJefAprobCompFracc_FechaNot");       
                            int pt12 = dr.GetOrdinal("ResJefPerdComp_Nro");
                            int pt13 = dr.GetOrdinal("ResJefPerdComp_Fecha");
                            int pt14 = dr.GetOrdinal("ResJefPerdComp_NroActa");
                            int pt15 = dr.GetOrdinal("ResJefPerdComp_FechaNot");
                            int pt16 = dr.GetOrdinal("ResJefPerdCompFracc_Nro");
                            int pt17 = dr.GetOrdinal("ResJefPerdCompFracc_Fecha");
                            int pt18 = dr.GetOrdinal("ResJefPerdCompFracc_NroActa");
                            int pt19 = dr.GetOrdinal("ResJefPerdCompFracc_FechaNot");

                            //oCampos = new CEntidad();
                            while (dr.Read())
                            {

                                oCampos = new CEntidad();
                                oCampos.SIGCORRELATIVO_CM = dr.GetInt32(pt1);
                                oCampos.SIGNOMTITULAR_CM = dr.IsDBNull(pt2) ? "" : dr.GetString(pt2);
                                oCampos.RESIDENTITY_CM = dr.GetInt32(pt3);
                                oCampos.RESJEFAPROBCOMP_NRO_CM = dr.IsDBNull(pt4)?"": dr.GetString(pt4);
                                oCampos.RESJEFAPROBCOMP_FECHA_CM = dr.IsDBNull(pt5) ? "" : dr.GetString(pt5);
                                oCampos.RESJEFAPROBCOMP_NROACTA_CM = dr.IsDBNull(pt6) ? "" : dr.GetString(pt6);
                                oCampos.RESJEFAPROBCOMP_FECHANOT_CM = dr.IsDBNull(pt7) ? "" : dr.GetString(pt7);
                                oCampos.RESJEFAPROBCOMPFRACC_NRO_CM = dr.IsDBNull(pt8) ? "" : dr.GetString(pt8);
                                oCampos.RESJEFAPROBCOMPFRACC_FECHA_CM = dr.IsDBNull(pt9) ? "" : dr.GetString(pt9);
                                oCampos.RESJEFAPROBCOMPFRACC_NROACTA_CM = dr.IsDBNull(pt10) ? "" : dr.GetString(pt10);
                                oCampos.RESJEFAPROBCOMPFRACC_FECHANOT_CM = dr.IsDBNull(pt11) ? "" : dr.GetString(pt11);
                                oCampos.RESJEFPERDCOMP_NRO_CM = dr.IsDBNull(pt12) ? "" : dr.GetString(pt12);
                                oCampos.RESJEFPERDCOMP_FECHA_CM = dr.IsDBNull(pt13) ? "" : dr.GetString(pt13);
                                oCampos.RESJEFPERDCOMP_NROACTA_CM = dr.IsDBNull(pt14) ? "" : dr.GetString(pt14);
                                oCampos.RESJEFPERDCOMP_FECHANOT_CM = dr.IsDBNull(pt15) ? "" : dr.GetString(pt15);
                                oCampos.RESJEFPERDCOMPFRACC_NRO_CM = dr.IsDBNull(pt16) ? "" : dr.GetString(pt16);
                                oCampos.RESJEFPERDCOMPFRACC_FECHA_CM = dr.IsDBNull(pt17) ? "" : dr.GetString(pt17);
                                oCampos.RESJEFPERDCOMPFRACC_NROACTA_CM = dr.IsDBNull(pt18) ? "" : dr.GetString(pt18);
                                oCampos.RESJEFPERDCOMPFRACC_FECHANOT_CM = dr.IsDBNull(pt19) ? "" : dr.GetString(pt19);


                                listCompensacion.Add(oCampos);
                            }

                        }

                    }
                    return listCompensacion;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //CRONOGRAMA COMPENSACION											
        public List<CEntidad> dat_ResumenCronogramaCompensacion(SqlConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> listCCompensacion = new List<CEntidad>();

            try
            {
                using (SqlDataReader dr = oGDataSQL.SelDrdDefault(cn, null, "ingreso.usp_Contabilidad_ConsolidadoComparativoCompensacion_Consultar", oCEntidad))
                {
                    CEntidad oCampos = new CEntidad();

                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {

                            //anio	fecha	montoCompensable	fecha_p	montoCompensable_p	nroInforme	fechaInforme	nroRJ	fechaRJ	cuentaContable	CompEstado
                            int pt1 = dr.GetOrdinal("anio");
                            int pt2 = dr.GetOrdinal("fecha");
                            int pt3 = dr.GetOrdinal("montoCompensable");
                            int pt4 = dr.GetOrdinal("fecha_p");
                            int pt5 = dr.GetOrdinal("montoCompensable_p");
                            int pt6 = dr.GetOrdinal("nroInforme");
                            int pt7 = dr.GetOrdinal("fechaInforme");
                            int pt8 = dr.GetOrdinal("nroRJ");
                            int pt9 = dr.GetOrdinal("fechaRJ");
                            int pt10 = dr.GetOrdinal("cuentaContable");
                            int pt11 = dr.GetOrdinal("CompEstado");

                            //oCampos = new CEntidad();
                            while (dr.Read())
                            {

                                oCampos = new CEntidad();
                                oCampos.ANIO_CC = dr.GetInt32(pt1);
                                oCampos.FECHA_CC= dr.GetString(pt2);
                                oCampos.MONTOCOMPENSABLE_CC= dr.GetDecimal(pt3);
                                oCampos.FECHA_P_CC = dr.GetString(pt4);
                                oCampos.MONTOCOMPENSABLE_P_CC= dr.GetDecimal(pt5);
                                oCampos.NROINFORME_CC = dr.GetString(pt6);
                                oCampos.FECHAINFORME_CC= dr.GetString(pt7);
                                oCampos.NRORJ_CC = dr.GetString(pt8);
                                oCampos.FECHARJ_CC = dr.IsDBNull(pt9) ? "" : dr.GetString(pt9);
                                oCampos.CUENTACONTABLE_CC = dr.IsDBNull(pt10) ? "" : dr.GetString(pt10);
                                oCampos.COMPESTADO_CC = dr.GetInt32(pt11);
                                listCCompensacion.Add(oCampos);
                            }

                        }

                    }
                    return listCCompensacion;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //metodo de las especies aprobadas en el POA
        public List<CEntidad> log_Especies_Detalle(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> listAdendas = new List<CEntidad>();

            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spRHistorial_TH_Titulo_Habilitante", oCEntidad))
                {
                    // INFORMES
                    if (dr.HasRows)
                    {
                        CEntidad oCampos2 = new CEntidad();
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("NON_ESPECIE");
                            int pt2 = dr.GetOrdinal("NUM_ARBOLES");
                            int pt3 = dr.GetOrdinal("VOLUMEN_KILOGRAMOS");
                            int pt4 = dr.GetOrdinal("NOMBRE_CIENTIFICO");
                            int pt5 = dr.GetOrdinal("NOMBRE_COMUN");

                            while (dr.Read())
                            {
                                //PARTE_DIARIO_DETALLE
                                oCampos2 = new CEntidad();
                                oCampos2.NOMBRE_COMUN = dr["NON_ESPECIE"].ToString();
                                oCampos2.NUMERO_ARBOLES = Convert.ToInt32(dr["NUM_ARBOLES"]);
                                oCampos2.VOLUMEN_AUTORIZADO = Convert.ToDecimal(dr["VOLUMEN_KILOGRAMOS"]);
                                oCampos2.Nombre_Cienti = dr["NOMBRE_CIENTIFICO"].ToString();
                                oCampos2.Nombre_Comun = dr["NOMBRE_COMUN"].ToString();
                                listAdendas.Add(oCampos2);
                            }
                        }

                    }
                    return listAdendas;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //para la busqueda de titulo habilitante
        public CEntidad Titulo_Habilitante_Externo(OracleConnection cn, CEntidad oCEntidad)
        {
            CEntidad oCampos = new CEntidad();

            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_BD_OBSERVATORIO_MIGRACION.spRHistorial_TH_Titulo_Habilitante", oCEntidad))
                {
                    if (dr != null)
                    {
                        //  CEntidad oCampos = new CEntidad();
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("COD_THABILITANTE");
                            int pt2 = dr.GetOrdinal("TITULO");
                            int pt3 = dr.GetOrdinal("TITULAR");
                            int pt4 = dr.GetOrdinal("REP_LEGAL");
                            int pt5 = dr.GetOrdinal("UBIGEO");
                            int pt6 = dr.GetOrdinal("ESTAB_SECTOR");
                            int pt7 = dr.GetOrdinal("MODALIDAD");
                            int pt8 = dr.GetOrdinal("AREA_OTORGADA");
                            int pt9 = dr.GetOrdinal("CONTRATO_FECHA_INICIO");
                            int pt10 = dr.GetOrdinal("CONTRATO_FECHA_FIN");
                            int pt11 = dr.GetOrdinal("DIRECCION");
                            int pt12 = dr.GetOrdinal("DIRECCION_LEGAL");
                            int pt13 = dr.GetOrdinal("CADUCIDAD");
                            int pt14 = dr.GetOrdinal("COD_MTIPO");
                            while (dr.Read())
                            {
                                //PARTE_DIARIO_DETALLE
                                oCampos = new CEntidad();
                                oCampos.COD_THABILITANTE = dr.GetString(pt1);
                                oCampos.TITULO = dr.GetString(pt2);
                                oCampos.TITULAR = dr.GetString(pt3);
                                oCampos.REPRESENTANTE_LEG = dr.GetString(pt4);
                                oCampos.UBICACION = dr.GetString(pt5) + " - " + dr.GetString(pt6);
                                oCampos.MODALIDAD = dr.GetString(pt7);
                                oCampos.AREA_O = dr.GetDecimal(pt8);
                                oCampos.FECHA_INICIO = dr.GetString(pt9);
                                oCampos.FECHA_FIN = dr.GetString(pt10);
                                oCampos.DIRECCION_TH = dr.GetString(pt11);
                                oCampos.DIRECCION_LEGAL = dr.GetString(pt12);
                                oCampos.CADUCIDAD_RDTERMINO = dr.GetString(pt13);
                                oCampos.COD_MTIPO = dr.GetString(pt14);
                                // lsCEntidad.Add(oCampos);
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

        public CEntidad Titulo_Habilitante_ExternoF(OracleConnection cn, CEntidad oCEntidad)
        {
            CEntidad oCampos = new CEntidad();

            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_BD_OBSERVATORIO_MIGRACION.spRHistorial_TH_Titulo_Habilitante", oCEntidad))
                {
                    if (dr != null)
                    {
                        //  CEntidad oCampos = new CEntidad();
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("COD_THABILITANTE");
                            int pt2 = dr.GetOrdinal("TITULO");
                            int pt3 = dr.GetOrdinal("TITULAR");
                            int pt4 = dr.GetOrdinal("REP_LEGAL");
                            int pt5 = dr.GetOrdinal("UBIGEO");
                            int pt6 = dr.GetOrdinal("ESTAB_SECTOR");
                            int pt7 = dr.GetOrdinal("MODALIDAD");
                            int pt8 = dr.GetOrdinal("AREA_OTORGADA");
                            int pt9 = dr.GetOrdinal("CONTRATO_FECHA_INICIO");
                            int pt10 = dr.GetOrdinal("CONTRATO_FECHA_FIN");
                            int pt11 = dr.GetOrdinal("DIRECCION");
                            int pt12 = dr.GetOrdinal("DIRECCION_LEGAL");
                            int pt13 = dr.GetOrdinal("CADUCIDAD");
                            int pt14 = dr.GetOrdinal("COD_MTIPO");
                            int pt15 = dr.GetOrdinal("OBJ_PRINCIPAL");
                            int pt16 = dr.GetOrdinal("OBJ_ACTUAL");
                            int pt17 = dr.GetOrdinal("FECHA_SUPERV");
                            int pt18 = dr.GetOrdinal("VISITA");
                            int pt19 = dr.GetOrdinal("REPROD");
                            int pt20 = dr.GetOrdinal("PROM");
                            int pt21 = dr.GetOrdinal("FECHA_OBSERVATORIO");
                            int pt22 = dr.GetOrdinal("ESTADO_ESTABLECIMIENTO");


                            while (dr.Read())
                            {
                                //PARTE_DIARIO_DETALLE
                                oCampos = new CEntidad();
                                oCampos.COD_THABILITANTE = dr.GetString(pt1);
                                oCampos.TITULO = dr.GetString(pt2);
                                oCampos.TITULAR = dr.GetString(pt3);
                                oCampos.REPRESENTANTE_LEG = dr.GetString(pt4);
                                oCampos.UBICACION = dr.GetString(pt5) + " - " + dr.GetString(pt6);
                                oCampos.MODALIDAD = dr.GetString(pt7);
                                oCampos.AREA_O = dr.GetDecimal(pt8);
                                oCampos.FECHA_INICIO = dr.GetString(pt9);
                                oCampos.FECHA_FIN = dr.GetString(pt10);
                                oCampos.DIRECCION_TH = dr.GetString(pt11);
                                oCampos.DIRECCION_LEGAL = dr.GetString(pt12);
                                oCampos.CADUCIDAD_RDTERMINO = dr.GetString(pt13);
                                oCampos.COD_MTIPO = dr.GetString(pt14);
                                oCampos.OBJ_ACTUAL = dr.GetString(pt16);
                                oCampos.OBJ_PRINCIP = dr.GetString(pt15);
                                oCampos.FECHA_FIN = dr.GetString(pt17);
                                oCampos.VISITA = dr.GetString(pt18);
                                oCampos.REPRODUCE = dr.GetString(pt19);
                                oCampos.PORCENTAJE_INEX = dr.GetDecimal(pt20);
                                oCampos.FECHA_TFFS = dr.GetString(pt21);
                                oCampos.ESTADO_ESTABLECIMIENTO = dr.GetString(pt22);
                                // lsCEntidad.Add(oCampos);
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
        public List<CEntidad> TH_POAExterno(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> listAdendas = new List<CEntidad>();

            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_BD_OBSERVATORIO_MIGRACION.spRHistorial_TH_Titulo_Habilitante", oCEntidad))
                {
                    // INFORMES
                    if (dr.HasRows)
                    {
                        CEntidad oCampos2 = new CEntidad();
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("COD_THABILITANTE");
                            int pt2 = dr.GetOrdinal("NUM_POA");
                            int pt3 = dr.GetOrdinal("ARESOLUCION_NUM");
                            int pt4 = dr.GetOrdinal("ARBOLES");
                            int pt5 = dr.GetOrdinal("VOLUMEN");
                            int pt6 = dr.GetOrdinal("CONSULTOR");
                            int pt7 = dr.GetOrdinal("SUPERVISION");
                            int pt13 = dr.GetOrdinal("ANIO_SUP");
                            int pt8 = dr.GetOrdinal("ESTADO");
                            int pt9 = dr.GetOrdinal("COLOR");
                            int pt10 = dr.GetOrdinal("ID_REGISTRO");
                            int pt11 = dr.GetOrdinal("NUM_POA_STRING");
                            int pt12 = dr.GetOrdinal("ESTADO_CONTA");
                            int pt14 = dr.GetOrdinal("NUM_RD");
                            while (dr.Read())
                            {
                                //PARTE_DIARIO_DETALLE
                                oCampos2 = new CEntidad();
                                oCampos2.COD_THABILITANTE = dr.GetString(pt1);
                                oCampos2.NUM_POA = dr.GetInt32(pt2);
                                oCampos2.ARESOLUCION_NUM = dr.GetString(pt3);
                                oCampos2.Arboles_aprob = dr.GetInt32(pt4);
                                oCampos2.VOLUMEN_AUTORIZADO = dr.GetDecimal(pt5);
                                oCampos2.consultor = dr.GetString(pt6);
                                oCampos2.Supervisor = dr.GetString(pt7);
                                oCampos2.ESTADO_ORIGEN = dr.GetString(pt8);
                                oCampos2.descripFin = dr.GetString(pt9);
                                oCampos2.ID_REGISTRO = dr.GetInt32(pt10);
                                oCampos2.NUM_POA_STRING = dr.GetString(pt11);
                                oCampos2.ESTADO_CONTA = dr.GetString(pt12);
                                oCampos2.ANIO_SUP = dr.GetString(pt13);
                                oCampos2.NUM_RESODIREC_RECONSIDERACION = dr.GetString(pt14);
                                listAdendas.Add(oCampos2);
                            }
                        }

                    }
                    return listAdendas;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // metodos para las adendas
        public List<CEntidad> datNumero_TH(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> listAdendas = new List<CEntidad>();

            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_BD_OBSERVATORIO_MIGRACION.spRHistorial_TH_Titulo_Habilitante", oCEntidad))
                {
                    // INFORMES
                    if (dr.HasRows)
                    {
                        CEntidad oCampos2 = new CEntidad();
                        if (dr.HasRows)
                        {
                            int pt0 = dr.GetOrdinal("COD_THABILITANTE");
                            int pt1 = dr.GetOrdinal("TITULO");
                            int pt2 = dr.GetOrdinal("TH_BUSQUEDA_EXT");

                            while (dr.Read())
                            {
                                //PARTE_DIARIO_DETALLE
                                oCampos2 = new CEntidad();
                                oCampos2.COD_THABILITANTE = dr.GetString(pt0);
                                oCampos2.TITULO = dr.GetString(pt1);
                                oCampos2.TITULAR = dr.GetString(pt2);
                                listAdendas.Add(oCampos2);
                            }
                        }

                    }
                    return listAdendas;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // METODO PARA INFRACCIONES DEL TITULAR
        public List<CEntidad> datInfraccionesTitular(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> listInfracciones = new List<CEntidad>();
                
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_BD_OBSERVATORIO_MIGRACION.spRhInfractores", oCEntidad))
                {
                    // INFORMES
                    if (dr.HasRows)
                    {
                        CEntidad oCampos2 = new CEntidad();
                        if (dr.HasRows)
                        {
                            int pt0 = dr.GetOrdinal("COD_THABILITANTE");
                            int pt1 = dr.GetOrdinal("TITULAR");
                            int pt2 = dr.GetOrdinal("DNI");
                            int pt3 = dr.GetOrdinal("TITULO");
                            int pt4 = dr.GetOrdinal("MODALIDAD");
                            int pt5 = dr.GetOrdinal("DEPARTAMENTO");
                            int pt13 = dr.GetOrdinal("PROVINCIA");
                            int pt14 = dr.GetOrdinal("DISTRITO");

                            int pt6 = dr.GetOrdinal("COD_RDTERMINO");
                            int pt7 = dr.GetOrdinal("RD_TERMINO");
                            int pt8 = dr.GetOrdinal("INFRACCIONES_RT");
                            int pt9 = dr.GetOrdinal("CODDOC");
                            int pt10 = dr.GetOrdinal("CADUCIDAD");
                            int pt11 = dr.GetOrdinal("NUM_RESODIREC_RR");
                            int pt12 = dr.GetOrdinal("COD_DOCSIADO");
                            int pt15 = dr.GetOrdinal("AREA");
                            int pt16 = dr.GetOrdinal("OBSERVACION");
                            int pt17 = dr.GetOrdinal("SANCION");
                            int pt18 = dr.GetOrdinal("MONTO_MULTA");
                            int pt19 = dr.GetOrdinal("ANIO_SUPERV");
                            while (dr.Read())
                            {
                                //PARTE_DIARIO_DETALLE
                                oCampos2 = new CEntidad();
                                oCampos2.COD_THABILITANTE = dr.GetString(pt0);
                                oCampos2.TITULAR = dr.GetString(pt1);
                                oCampos2.consultor = dr.GetString(pt2);// NUMERO DE DNI DEL TITULAR
                                oCampos2.TITULO = dr.GetString(pt3);
                                oCampos2.MODALIDAD = dr.GetString(pt4);
                                oCampos2.DEPARTAMENTO = dr.GetString(pt5);
                                oCampos2.PROVINCIA = dr.GetString(pt13);
                                oCampos2.DISTRITO = dr.GetString(pt14);
                                oCampos2.COD_RESODIREC_Termino = dr.GetString(pt6);
                                oCampos2.RD_termino = dr.GetString(pt7);
                                oCampos2.INFRACCIONES_TER = dr.GetString(pt8);
                                oCampos2.DOC_SIADO = dr.GetString(pt9);
                                oCampos2.CADUCIDAD_RDTERMINO = dr.GetString(pt10);
                                oCampos2.SANCION = dr.GetString(pt17);
                                oCampos2.MULTA_MONTO = dr.GetDecimal(pt18).ToString();
                                oCampos2.NUM_RESODIREC_RECONSIDERACION = dr.GetString(pt11);
                                oCampos2.DOC_SIADO_RECONSIDERACION = dr.GetString(pt12);
                                oCampos2.AREA_O = dr.GetDecimal(pt15);
                                oCampos2.OBSERVACIONES = dr.GetString(pt16);
                                oCampos2.ANIO_SUP = dr.GetString(pt19);
                                listInfracciones.Add(oCampos2);
                            }
                        }

                    }
                    return listInfracciones; 
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Metodo para obtener la lista de informes de supervisiones
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public List<CEntidad> datInfracciones_Supervisiones(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> listInfracciones = new List<CEntidad>();

            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_BD_OBSERVATORIO_MIGRACION.spRhInfractoresSupervisiones", oCEntidad))
                {
                    // INFORMES
                    if (dr.HasRows)
                    {
                        CEntidad oCampos2 = new CEntidad();
                        if (dr.HasRows)
                        {
                            int pt0 = dr.GetOrdinal("COD_THABILITANTE");
                            int pt1 = dr.GetOrdinal("TITULAR");
                            int pt2 = dr.GetOrdinal("DNI");
                            int pt3 = dr.GetOrdinal("TITULO");
                            int pt4 = dr.GetOrdinal("MODALIDAD");
                            int pt5 = dr.GetOrdinal("DEPARTAMENTO");
                            int pt9 = dr.GetOrdinal("PROVINCIA");
                            int pt10 = dr.GetOrdinal("DISTRITO");

                            int pt6 = dr.GetOrdinal("COD_INFORME");
                            int pt7 = dr.GetOrdinal("NUM_INFORME");
                            int pt8 = dr.GetOrdinal("DOC_INFORME");

                            while (dr.Read())
                            {
                                //PARTE_DIARIO_DETALLE
                                oCampos2 = new CEntidad();
                                oCampos2.COD_THABILITANTE = dr.GetString(pt0);
                                oCampos2.TITULAR = dr.GetString(pt1);
                                oCampos2.consultor = dr.GetString(pt2);// NUMERO DE DNI DEL TITULAR
                                oCampos2.TITULO = dr.GetString(pt3);
                                oCampos2.MODALIDAD = dr.GetString(pt4);
                                oCampos2.DEPARTAMENTO = dr.GetString(pt5);
                                oCampos2.PROVINCIA = dr.GetString(pt9);
                                oCampos2.DISTRITO = dr.GetString(pt10);

                                oCampos2.COD_INFORME = dr.GetString(pt6);
                                oCampos2.NUMERO = dr.GetString(pt7); //NUMERO DE INFORME DE SUPERVISION
                                oCampos2.DOC_SIADO = dr.GetString(pt8);
                                listInfracciones.Add(oCampos2);
                            }
                        }

                    }
                    return listInfracciones;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //metodo para titulos no maderables
        //public List<CEntidad> datTitular_No_Maderables(OracleConnection cn, CEntidad oCEntidad)
        //{
        //    List<CEntidad> listInfracciones = new List<CEntidad>();

        //    try
        //    {
        //        using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_BD_OBSERVATORIO_MIGRACION.spRHistorial_TH_Titulo_Habilitante", oCEntidad))
        //        {
        //            // INFORMES
        //            if (dr.HasRows)
        //            {
        //                CEntidad oCampos2 = new CEntidad();
        //                if (dr.HasRows)
        //                {
        //                    int pt0 = dr.GetOrdinal("COD_THABILITANTE");
        //                    int pt1 = dr.GetOrdinal("ANIO_SUPERV");
        //                    int pt2 = dr.GetOrdinal("ESTADO_PROCESO");



        //                    while (dr.Read())
        //                    {
        //                        //PARTE_DIARIO_DETALLE
        //                        oCampos2 = new CEntidad();
        //                        oCampos2.COD_THABILITANTE = dr.GetString(pt0);
        //                        oCampos2.ANIO_SUPERV = dr.GetInt32(pt1);
        //                        oCampos2.ESTADO_ORIGEN = dr.GetString(pt2);// NUMERO DE DNI DEL TITULAR

        //                        listInfracciones.Add(oCampos2);
        //                    }
        //                }

        //            }
        //            return listInfracciones;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        // volumen de inexistencia
        public CEntidad datInformeInexistencia(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> listInexistencia = new List<CEntidad>();
            List<CEntidad> listVolumen = new List<CEntidad>();
            CEntidad lsCEntidad = new CEntidad();

            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spRHistorial_TH_Titulo_Habilitante", oCEntidad))
                {
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {//  dr.Read();
                            lsCEntidad = new CEntidad();
                            lsCEntidad.COD_INFORME = dr.GetString(dr.GetOrdinal("COD_INFORME"));
                            lsCEntidad.INEX_AGUAJAL = dr.GetString(dr.GetOrdinal("INEX_AGUAJAL"));
                            lsCEntidad.PORC_AGUAJAL = dr.GetDecimal(dr.GetOrdinal("PORC_AGUAJAL")).ToString();
                            lsCEntidad.NUM_ARBNOU_AGUAJAL = dr.GetInt32(dr.GetOrdinal("NUM_ARBNOU_AGUAJAL")).ToString();
                            lsCEntidad.AGUAJAL_OBSERV = dr.GetString(dr.GetOrdinal("AGUAJAL_OBSERV"));
                            lsCEntidad.INEX_PASTIZAL = dr.GetString(dr.GetOrdinal("INEX_PASTIZAL"));
                            lsCEntidad.PORC_PASTIZAL = dr.GetDecimal(dr.GetOrdinal("PORC_PASTIZAL")).ToString();
                            lsCEntidad.PASTIZAL_OBSERV = dr.GetString(dr.GetOrdinal("PASTIZAL_OBSERV")).ToString();
                            lsCEntidad.INEX_INACCESIBLE = dr.GetString(dr.GetOrdinal("INEX_INACCESIBLE"));
                            lsCEntidad.PORC_INACCESIBLE = dr.GetDecimal(dr.GetOrdinal("PORC_INACCESIBLE")).ToString();
                            lsCEntidad.NUM_ARBNOU_INACCESIBLE = dr.GetInt32(dr.GetOrdinal("NUM_ARBNOU_INACCESIBLE")).ToString();
                            lsCEntidad.INACCESIBLE_OBSERV = dr.GetString(dr.GetOrdinal("INACCESIBLE_OBSERV"));
                            lsCEntidad.INEX_OTROS = dr.GetString(dr.GetOrdinal("INEX_OTROS"));
                            lsCEntidad.PORC_OTROS = dr.GetDecimal(dr.GetOrdinal("PORC_OTROS")).ToString();
                            lsCEntidad.NUM_ARBNOU_OTROS = dr.GetInt32(dr.GetOrdinal("NUM_ARBNOU_OTROS")).ToString();
                            lsCEntidad.OTROS_OBSERV = dr.GetString(dr.GetOrdinal("OTROS_OBSERV"));
                            listInexistencia.Add(lsCEntidad);
                        }
                    }
                    //Estado (Calidad)
                    dr.NextResult();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {//  dr.Read();
                            lsCEntidad = new CEntidad();
                            //  dr.Read();
                            lsCEntidad.COD_INFORME = dr.GetString(dr.GetOrdinal("COD_INFORME"));
                            lsCEntidad.Nombre_Cienti = dr.GetString(dr.GetOrdinal("NOMBRE_CIENTIFICO"));
                            lsCEntidad.Nombre_Comun = dr.GetString(dr.GetOrdinal("NOMBRE_COMUN"));
                            lsCEntidad.VOLUMEN_ARBOLES = dr.GetDecimal(dr.GetOrdinal("VOLUMEN"));
                            lsCEntidad.NUM_POA_STRING = dr.GetString(dr.GetOrdinal("NUM_POA"));
                            lsCEntidad.OBSERVACIONES = dr.GetString(dr.GetOrdinal("OBSERVACION"));
                            listVolumen.Add(lsCEntidad);
                        }
                    }
                    lsCEntidad = new CEntidad();
                    lsCEntidad.ListInexistencia = listInexistencia;
                    lsCEntidad.ListVolumenInexistencia = listVolumen;
                    return lsCEntidad;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CEntidad> datListTHFauna(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> listTHFauna = new List<CEntidad>();

            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_BD_OBSERVATORIO_MIGRACION.spZReporteFaunaListarGeneral", oCEntidad))
                {
                    // INFORMES
                    if (dr.HasRows)
                    {
                        CEntidad oCampos2 = new CEntidad();
                        if (dr.HasRows)
                        {
                            int pt0 = dr.GetOrdinal("COD_THABILITANTE");
                            int pt1 = dr.GetOrdinal("TITULAR");
                            int pt2 = dr.GetOrdinal("DOCUMENTO");
                            int pt3 = dr.GetOrdinal("TITULO");
                            int pt4 = dr.GetOrdinal("MODALIDAD");
                            int pt5 = dr.GetOrdinal("DEPARTAMENTO");
                            int pt6 = dr.GetOrdinal("SECTOR");
                            int pt9 = dr.GetOrdinal("COD_INFORME");
                            int pt10 = dr.GetOrdinal("FECHA_SUP");
                            int pt11 = dr.GetOrdinal("ESPECIES");
                            int pt12 = dr.GetOrdinal("EVAL");

                            while (dr.Read())
                            {
                                //PARTE_DIARIO_DETALLE
                                oCampos2 = new CEntidad();
                                oCampos2.COD_THABILITANTE = dr.GetString(pt0);
                                oCampos2.TITULAR = dr.GetString(pt1);
                                oCampos2.NUMERO = dr.GetString(pt2);// NUMERO DE DNI DEL TITULAR
                                oCampos2.TITULO = dr.GetString(pt3);
                                oCampos2.MODALIDAD = dr.GetString(pt4);
                                oCampos2.DEPARTAMENTO = dr.GetString(pt5);
                                oCampos2.DIRECCION = dr.GetString(pt6);
                                oCampos2.COD_INFORME = dr.GetString(pt9);
                                oCampos2.ANIO_SUP = dr.GetString(pt10);
                                oCampos2.COD_ESPECIES = dr.GetString(pt11);
                                oCampos2.PORCENTAJE_INEX = dr.GetDecimal(pt12);
                                listTHFauna.Add(oCampos2);
                            }
                        }

                    }
                    return listTHFauna;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //listado de especies de fauna
        public List<CEntidad> datListTHFaunaEspecie(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> listTHFauna = new List<CEntidad>();

            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_BD_OBSERVATORIO_MIGRACION.spZReporteFaunaEspecies", oCEntidad))
                {
                    // INFORMES
                    if (dr.HasRows)
                    {
                        CEntidad oCampos2 = new CEntidad();
                        if (dr.HasRows)
                        {
                            int pt0 = dr.GetOrdinal("NOMBRE");
                            int pt1 = dr.GetOrdinal("NOMBRE_CIENTIFICO");
                            int pt2 = dr.GetOrdinal("NOMBRE_COMUN");
                            while (dr.Read())
                            {
                                //PARTE_DIARIO_DETALLE
                                oCampos2 = new CEntidad();
                                oCampos2.Nombre_Comun = dr.GetString(pt0);
                                oCampos2.Nombre_Cienti = dr.GetString(pt1);
                                oCampos2.NOMBRE_COMUN = dr.GetString(pt2);
                                listTHFauna.Add(oCampos2);

                            }
                        }

                    }
                    return listTHFauna;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CEntidad RegMostFiltro(OracleConnection cn, CEntidad oCEntidad)
        {
            CEntidad oCampos = null;
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_BD_OBSERVATORIO_MIGRACION.spGeneral_Combo_Listar", oCEntidad))
                {
                    if (dr != null)
                    {
                        oCampos = new CEntidad();
                        oCampos.ListModalidad = new List<CEntidad>();
                        oCampos.ListRegion = new List<CEntidad>();
                        CEntidad oCamposDet;
                        //
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {//  dr.Read();
                                oCamposDet = new CEntidad();
                                oCamposDet.CODIGO = dr.GetString(dr.GetOrdinal("CODIGO"));
                                oCamposDet.DESCRIPCION = dr.GetString(dr.GetOrdinal("DESCRIPCION"));
                                oCampos.ListRegion.Add(oCamposDet);
                            }
                        }
                        //Estado (Calidad)
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {//  dr.Read();
                                oCamposDet = new CEntidad();
                                //  dr.Read();
                                oCamposDet.CODIGO = dr.GetString(dr.GetOrdinal("CODIGO"));
                                oCamposDet.DESCRIPCION = dr.GetString(dr.GetOrdinal("DESCRIPCION"));
                                oCampos.ListModalidad.Add(oCamposDet);
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

        public String RegAuditoriaGrabar(OracleConnection cn, CEntidad oCEntidad)
        {
            OracleTransaction tr = null;
            String OUTPUTPARAM01 = "";
            try
            {
                tr = cn.BeginTransaction();
                //Grabando Cabecera
                using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, tr, "HERR_BD_OBSERVATORIO_MIGRACION.spAUDITORIA_REPORTES", oCEntidad))
                {
                    cmd.ExecuteNonQuery();
                    OUTPUTPARAM01 = (String)cmd.Parameters["OUTPUTPARAM01"].Value;
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
        /// metodo para obtener la lista de informes antes de la supervision 
        /// 20/09/2017 CARR
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public List<CEntidad> datListInformeASuperv(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> listInfASupervision = new List<CEntidad>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_BD_OBSERVATORIO_MIGRACION.spRHistorial_TH_Titulo_Habilitante", oCEntidad))
                {
                    if (dr != null)
                    {
                        CEntidad oCamposDet;
                        //
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {//  dr.Read();
                                oCamposDet = new CEntidad();
                                oCamposDet.COD_THABILITANTE = dr.GetString(dr.GetOrdinal("COD_THABILITANTE"));
                                oCamposDet.COD_INFORME = dr.GetString(dr.GetOrdinal("COD_INFORME"));
                                oCamposDet.TITULAR = dr.GetString(dr.GetOrdinal("TITULAR"));
                                oCamposDet.TITULO = dr.GetString(dr.GetOrdinal("TITULO"));
                                oCamposDet.MODALIDAD = dr.GetString(dr.GetOrdinal("MODALIDAD"));
                                oCamposDet.DEPARTAMENTO = dr.GetString(dr.GetOrdinal("DEPARTAMENTO"));
                                oCamposDet.NUM_POA_STRING = dr.GetString(dr.GetOrdinal("NOMBRE_POA"));
                                oCamposDet.NUMERO_RESOLUCION = dr.GetString(dr.GetOrdinal("RD_APROVECHAMIENTO"));
                                oCamposDet.NUM_POA = dr.GetInt32(dr.GetOrdinal("NUM_POA"));
                                listInfASupervision.Add(oCamposDet);
                            }
                        }

                    }
                }
                return listInfASupervision;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// metodo que obtiene el detalle del informe de supervision antes de la supervision
        /// 20/09/2017
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public CEntidad dat_InformeASupervDet(OracleConnection cn, CEntidad oCEntidad)
        {
            CEntidad oCampos = null;
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_BD_OBSERVATORIO_MIGRACION.spRHistorial_TH_Titulo_Habilitante", oCEntidad))
                {
                    if (dr != null)
                    {
                        oCampos = new CEntidad();
                        oCampos.ListSupervision = new List<CEntidad>();
                        CEntidad oCamposDet;
                        //
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {//  dr.Read();
                                oCampos.COD_INFORME = dr.GetString(dr.GetOrdinal("COD_INFORME"));
                                oCampos.TITULAR = dr.GetString(dr.GetOrdinal("TITULAR"));
                                oCampos.TITULO = dr.GetString(dr.GetOrdinal("TITULO"));
                                oCampos.MODALIDAD = dr.GetString(dr.GetOrdinal("MODALIDAD"));
                                oCampos.UBICACION = dr.GetString(dr.GetOrdinal("UBICACION"));
                                oCampos.NUM_POA = dr.GetInt32(dr.GetOrdinal("NUM_POA"));
                                oCampos.NUM_POA_STRING = dr.GetString(dr.GetOrdinal("NOMBRE_POA"));
                                oCampos.OTROS_NUM_RESOLUCION = dr.GetString(dr.GetOrdinal("RD_APROBACION"));
                                oCampos.FECHA_TFFS = dr.GetString(dr.GetOrdinal("FECHA_EMISION"));
                                oCampos.PCA = dr.GetString(dr.GetOrdinal("PCA"));
                                oCampos.FECHA_INICIO = dr.GetString(dr.GetOrdinal("FECHA_INICIO_VIGENCIA"));
                                oCampos.FECHA_FIN = dr.GetString(dr.GetOrdinal("FECHA_FIN_VIGENCIA"));
                                oCampos.consultor = dr.GetString(dr.GetOrdinal("REGENTE_Y_O_COSULTOR"));
                                oCampos.Fecha_Sup = dr.GetString(dr.GetOrdinal("FECHA_SUPERV"));
                                oCampos.DESCRIPCION = dr.GetString(dr.GetOrdinal("CONCLUSION"));
                                oCampos.Tipo_Inicio = dr.GetString(dr.GetOrdinal("TIPO"));
                                oCampos.NUM_INFORME = dr.GetString(dr.GetOrdinal("NUM_INFORME"));
                                oCampos.MOTIVO = dr.GetString(dr.GetOrdinal("MOTIVO"));
                            }
                        }
                        //Estado (Calidad)
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {//  dr.Read();
                                oCamposDet = new CEntidad();
                                //  dr.Read();
                                oCamposDet.COD_INFORME = dr.GetString(dr.GetOrdinal("COD_INFORME"));
                                oCamposDet.COD_ESPECIES = dr.GetString(dr.GetOrdinal("COD_ESPECIES"));
                                oCamposDet.DESCRIPCION = dr.GetString(dr.GetOrdinal("DESCRIPCION"));
                                oCamposDet.NUMERO_ARBOLES = dr.GetInt32(dr.GetOrdinal("ARB_SUPERV"));
                                oCamposDet.PORCENTAJE_INEX = Decimal.Parse(dr.GetInt32(dr.GetOrdinal("PORC_INEX")).ToString());
                                oCamposDet.INEX = dr.GetInt32(dr.GetOrdinal("INEX"));
                                oCamposDet.PORCENT_INJUST_MOVIL = Decimal.Parse(dr.GetInt32(dr.GetOrdinal("PORC_COINC")).ToString());
                                oCamposDet.COINC = dr.GetInt32(dr.GetOrdinal("COINCIDENCIA"));

                                oCampos.ListSupervision.Add(oCamposDet);
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

        /// <summary>
        /// metodo que lista las dircciones del TH
        /// C.R. 20/03/2018
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        //public List<CEntidad> dat_DirectorioTH(OracleConnection cn, CEntidad oCEntidad)
        //{
        //    List<CEntidad> ListDirectorio = new List<CEntidad>();
        //    try
        //    {
        //        using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC.spRHistorial_TH_Titulo_Habilitante", oCEntidad))
        //        {
        //            if (dr != null)
        //            {
        //                //  CEntidad oCampos = new CEntidad();
        //                if (dr.HasRows)
        //                {
        //                    CEntidad oCampos = new CEntidad();
        //                    int pt1 = dr.GetOrdinal("NUMERO");
        //                    int pt2 = dr.GetOrdinal("FUENTE");
        //                    int pt3 = dr.GetOrdinal("FECHA");
        //                    int pt4 = dr.GetOrdinal("UBIGEO");
        //                    int pt5 = dr.GetOrdinal("DIRECCION");
        //                    int pt6 = dr.GetOrdinal("OBSERVACION");
        //                    int pt7 = dr.GetOrdinal("CODDOC");
        //                    while (dr.Read())
        //                    {
        //                        //PARTE_DIARIO_DETALLE
        //                        oCampos = new CEntidad();
        //                        oCampos.NUMERO = dr.GetString(pt1);
        //                        oCampos.FUENTE = dr.GetString(pt2);
        //                        oCampos.FECHA_INICIO = dr.GetString(pt3);
        //                        oCampos.UBICACION = dr.GetString(pt4);
        //                        oCampos.DIRECCION = dr.GetString(pt5);
        //                        oCampos.OBSERVACIONES = dr.GetString(pt6);
        //                        oCampos.COD_DOCINFORME = dr.GetString(pt7);
        //                        ListDirectorio.Add(oCampos);
        //                    }
        //                }

        //            }
        //        }
        //        return ListDirectorio;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        ///14/09/2018
        ///metodo del report historial del titulo habilitante resumen
        ///CAR
        public List<CEntidad> ReporteHistorialDetalleInt(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> List_Informe = new List<CEntidad>();

            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "doc_osinfor_erp_migracion.spRHistorial_TH_Titulo_Habilitante", oCEntidad))
                {
                    // INFORMES
                    if (dr.HasRows)
                    {
                        CEntidad oCampos2 = new CEntidad();
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("COD_INFORME");
                            int pt2 = dr.GetOrdinal("NUMERO");
                            int pt3 = dr.GetOrdinal("ORIGEN");
                            int pt4 = dr.GetOrdinal("ANIO_SUP");
                            int pt5 = dr.GetOrdinal("SUPERVISORES");
                            int pt6 = dr.GetOrdinal("COD_DOCINFORME");
                            int pt7 = dr.GetOrdinal("OBSERVACION");
                            // R.D. inicio
                            int pt8 = dr.GetOrdinal("COD_RDINICIO");
                            int pt9 = dr.GetOrdinal("RD_INICIO");
                            int pt10 = dr.GetOrdinal("COD_DOCRDINICIO");
                            int pt11 = dr.GetOrdinal("FECHA_RDINICIO");
                            int pt12 = dr.GetOrdinal("RDINICIO_MED_CAUTELAR");
                            int pt13 = dr.GetOrdinal("RDINICIO_CAUSAL_CADUCIDAD");
                            int pt14 = dr.GetOrdinal("RDIMICIO_INF_FALSA_DAS");
                            int pt15 = dr.GetOrdinal("RDINICIO_INF_FALSA_DIF");
                            int pt16 = dr.GetOrdinal("RDINICIO_INF_FALSA_INEX");
                            int pt17 = dr.GetOrdinal("RDINICIO_INFRACCIONES");
                            int pt18 = dr.GetOrdinal("NUM_EXPEDIENTE");

                            // R.D. termino
                            int pt19 = dr.GetOrdinal("COD_RDTERMINO");
                            int pt20 = dr.GetOrdinal("RD_TERMINO");
                            int pt21 = dr.GetOrdinal("COD_DOCRDTERMINO");
                            int pt22 = dr.GetOrdinal("FECHA_RDTERMINO");
                            int pt23 = dr.GetOrdinal("DETTERMINA_RT");
                            int pt24 = dr.GetOrdinal("CADUCIDAD_RT");
                            int pt25 = dr.GetOrdinal("MULTA_RT");
                            int pt26 = dr.GetOrdinal("MONTO_RT");
                            int pt27 = dr.GetOrdinal("EX_TITULARRT");
                            int pt28 = dr.GetOrdinal("EX_TITULAR");
                            int pt29 = dr.GetOrdinal("INFRACCIONES_RT");
                            int pt30 = dr.GetOrdinal("ESTADO_PROCESO");

                            // R.D. reconsideracion
                            int pt31 = dr.GetOrdinal("COD_RDRECONSIDERACION");
                            int pt32 = dr.GetOrdinal("RD_RECONSIDERACION");
                            int pt33 = dr.GetOrdinal("COD_DOCRDRECONS");
                            int pt34 = dr.GetOrdinal("FECHA_RDRECONS");
                            int pt35 = dr.GetOrdinal("RDR_IMPROCEDENTE");
                            int pt36 = dr.GetOrdinal("RDR_FUNDADA");
                            int pt37 = dr.GetOrdinal("RDR_FUNDADA_PARTE");
                            int pt38 = dr.GetOrdinal("RDR_INFUNDADO");
                            int pt39 = dr.GetOrdinal("RDR_LEVANTAR_CADUCIDAD");
                            int pt40 = dr.GetOrdinal("RDRR_CAMBIOMULTA");
                            int pt41 = dr.GetOrdinal("RDRR_MULTA");

                            //R.D. rectificacion
                            int pt42 = dr.GetOrdinal("RECT_COD_RESODIREC");
                            int pt43 = dr.GetOrdinal("RECT_NUM_RESOLUCION");
                            int pt44 = dr.GetOrdinal("DOC_RECTIFICACION");
                            int pt45 = dr.GetOrdinal("RECT_RD_FECHA");
                            int pt46 = dr.GetOrdinal("RECT_ERRORMATERIAL");
                            int pt47 = dr.GetOrdinal("RECT_CAMBIO_MULTA");
                            int pt48 = dr.GetOrdinal("RECT_MONTO");
                            int pt49 = dr.GetOrdinal("RECT_OTROS");
                            int pt50 = dr.GetOrdinal("RECT_DESC_OTROS");

                            // R.D. Acum
                            int pt51 = dr.GetOrdinal("ACUM_COD_RESODIREC");
                            int pt52 = dr.GetOrdinal("ACUM_NUM_RESOLUCION");
                            int pt53 = dr.GetOrdinal("ACUM_COD_FCTIPO");
                            int pt54 = dr.GetOrdinal("ACUM_FECHA_EMISION");
                            int pt55 = dr.GetOrdinal("ACUM_DESCRIPCION");

                            //R.D. AMP
                            int pt56 = dr.GetOrdinal("AMP_COD_RESODIREC");
                            int pt57 = dr.GetOrdinal("AMP_NUM_RESOLUCION");
                            int pt58 = dr.GetOrdinal("RD_FECHA_EMISION_AMP");
                            int pt59 = dr.GetOrdinal("AMP_IMPUTACION");
                            int pt60 = dr.GetOrdinal("AMP_OTRAS_INFRACCIONES");
                            int pt61 = dr.GetOrdinal("AMP_POR_PLAZOS");
                            int pt62 = dr.GetOrdinal("AMP_OTROS");

                            int pt63 = dr.GetOrdinal("CAD_COD_RESODIREC");
                            int pt64 = dr.GetOrdinal("CAD_NUM_RESOLUCION");
                            int pt65 = dr.GetOrdinal("CAD_RD_FECHA");
                            int pt66 = dr.GetOrdinal("CAD_NUM_EXP");
                            int pt67 = dr.GetOrdinal("CAD_CADUCIDAD");

                            int pt68 = dr.GetOrdinal("OTROS_COD_RESODIREC");
                            int pt69 = dr.GetOrdinal("OTROS_NUM_RESOLUCION");
                            int pt70 = dr.GetOrdinal("OTROS_RD_FECHA");
                            int pt71 = dr.GetOrdinal("OTROS_DETERMINACION");

                            int pt72 = dr.GetOrdinal("VARI_COD_RESODIREC");
                            int pt73 = dr.GetOrdinal("VARI_NUM_RESOLUCION");
                            int pt74 = dr.GetOrdinal("VARI_RD_FECHA");
                            int pt75 = dr.GetOrdinal("VARI_LEVANTAR");
                            int pt76 = dr.GetOrdinal("VARI_LEVANTAR_PARTE");
                            int pt77 = dr.GetOrdinal("VARI_NO_LEVANTAR");
                            int pt78 = dr.GetOrdinal("VARI_MODIFICAR");
                            int pt79 = dr.GetOrdinal("VARI_DETERMINACION");

                            int pt80 = dr.GetOrdinal("ARCH_COD_RESODIREC");
                            int pt81 = dr.GetOrdinal("ARCH_NUM_RESOLUCION");
                            int pt82 = dr.GetOrdinal("ARCH_FECHA_RD");
                            int pt83 = dr.GetOrdinal("ARCH_EVIDENCIA_IRRE");
                            int pt84 = dr.GetOrdinal("ARCH_SIN_INFRACCION");
                            int pt85 = dr.GetOrdinal("ARCH_BUEN_MANEJO");
                            int pt86 = dr.GetOrdinal("ARCH_DEFICIENTE_NOT");
                            int pt87 = dr.GetOrdinal("ARCH_DEFICIENCIA_TEC");
                            int pt88 = dr.GetOrdinal("OTROS");

                            //Proveido
                            int pt89 = dr.GetOrdinal("FECHA_PROVEIDO");
                            int pt90 = dr.GetOrdinal("TIPO_PROVEIDO");

                            //Tribunal
                            //int pt91 = dr.GetOrdinal("RD_TFFFS");
                            //int pt92 = dr.GetOrdinal("TFFS_DETERMINA");
                            //int pt93 = dr.GetOrdinal("TFFS_MOTIVO");
                            int pt94 = dr.GetOrdinal("NOMBRE_POA");
                            // TFFS INICIO
                            int pt95 = dr.GetOrdinal("COD_TRIBUNAL_INI");
                            int pt96 = dr.GetOrdinal("NUM_TFFSINI");
                            int pt97 = dr.GetOrdinal("DETERMINA");
                            int pt98 = dr.GetOrdinal("MOTIVO");
                            int pt99 = dr.GetOrdinal("ESTADO_TFFS");

                            // TFFS TERMINO
                            int pt100 = dr.GetOrdinal("COD_TRIBUNAL_TER");
                            int pt101 = dr.GetOrdinal("NUM_TFFSTER");
                            int pt102 = dr.GetOrdinal("DETERMINA_TFFSTER");
                            int pt103 = dr.GetOrdinal("MOTIVO_TFFSTER");
                            int pt104 = dr.GetOrdinal("ESTADO_TFFSTER");

                            // TFFS RR
                            int pt105 = dr.GetOrdinal("COD_TRIBUNAL_REC");
                            int pt106 = dr.GetOrdinal("NUM_TFFSREC");
                            int pt107 = dr.GetOrdinal("DETERMINA_TFFSREC");
                            int pt108 = dr.GetOrdinal("MOTIVO_TFFSREC");
                            int pt109 = dr.GetOrdinal("ESTADO_TFFSREC");
                            int pt110 = dr.GetOrdinal("ARCH_COD_FCTIPO");




                            while (dr.Read())
                            {
                                //PARTE_DIARIO_DETALLE
                                oCampos2 = new CEntidad();
                                oCampos2.COD_INFORME = dr.GetString(pt1);
                                oCampos2.NUMERO = dr.GetString(pt2); //numero de informe
                                oCampos2.ESTADO_ORIGEN_TIPO = dr.GetString(pt3);
                                oCampos2.ANIO_SUP = dr["ANIO_SUP"].ToString();
                                oCampos2.Supervisor = dr.GetString(pt5);
                                oCampos2.COD_DOCINFORME = dr.GetString(pt6); // DOC SIADO INFORME
                                oCampos2.OBSERVACIONES = dr.GetString(pt7);

                                // R.D. INICIO
                                oCampos2.COD_RESODIREC_Inicio = dr.GetString(pt8);
                                oCampos2.RD_INICIO = dr.GetString(pt9);
                                oCampos2.COD_DOCRDINICIO = dr.GetString(pt10);
                                oCampos2.FECHA_RDINICIO = dr.GetString(pt11);
                                oCampos2.MEDIDAS_CAUTELARES = dr.GetString(pt12);
                                oCampos2.CAUSAL_CADUCIDAD = dr.GetString(pt13);
                                oCampos2.INF_FALSA_DAS = dr.GetString(pt14);
                                oCampos2.INF_FALSA_DIF = dr.GetString(pt15);
                                oCampos2.INF_FALSA_INEX = dr.GetString(pt16);
                                oCampos2.INFRACCIONES = dr.GetString(pt17);
                                oCampos2.NUM_EXP = dr.GetString(pt18);// numero de expediente de la rd


                                // R.D. TERMINO
                                oCampos2.COD_RESODIREC_Termino = dr.GetString(pt19);//codigo de la RD de termino
                                oCampos2.RD_TERMINO = dr.GetString(pt20);
                                oCampos2.COD_DOCRDTERMINO = dr.GetString(pt21);
                                oCampos2.FECHA_RDTERMINO = dr.GetString(pt22);
                                oCampos2.DETERMINACION_RDTERMINO = dr.GetString(pt23);
                                oCampos2.CADUCIDAD_RDTERMINO = dr.GetString(pt24);
                                oCampos2.MULTA_RDTERMINO = dr.GetString(pt25);
                                oCampos2.MULTA_MONTO = dr.GetDecimal(pt26).ToString();
                                oCampos2.SANCION_EXTITULAR_RDTERMINO = dr.GetString(pt27);
                                oCampos2.TITULAR = dr.GetString(pt28);
                                oCampos2.INFRACCIONES_TER = dr.GetString(pt29);
                                oCampos2.ESTADO_ORIGEN = dr.GetString(pt30);

                                //cambios en el reporte historial titulo habilitante interno 15/11/2016
                                // R.D. reconsideracion
                                oCampos2.RECONS_COD_RESODIREC = dr.GetString(pt31);
                                oCampos2.RECONS_NUM_RESOLUCION = dr.GetString(pt32);
                                oCampos2.DOC_RECONS = dr.GetString(pt33);
                                oCampos2.RECONS_RD_FECHA = dr.GetString(pt34);
                                oCampos2.RECONS_IMPROCEDENTE = dr.GetString(pt35);
                                oCampos2.RECONS_FUNDADA = dr.GetString(pt36);
                                oCampos2.RECONS_FUNDADA_PARTE = dr.GetString(pt37);
                                oCampos2.RECONS_INFUNDADA = dr.GetString(pt38);
                                oCampos2.RECONS_LEVANTAR_CADUCIDAD = dr.GetString(pt39);
                                oCampos2.RECONS_CAMBIO_MULTA = dr.GetString(pt40);
                                oCampos2.RECONS_MONTO = dr.GetDecimal(pt41).ToString();

                                //R.D. RECTIFICACION
                                oCampos2.RECT_COD_RESODIREC = dr.GetString(pt42);
                                oCampos2.RECT_NUM_RESOLUCION = dr.GetString(pt43);
                                oCampos2.DOC_RECTIFICACION = dr.GetString(pt44);
                                oCampos2.RECT_RD_FECHA = dr.GetString(pt45);
                                oCampos2.RECT_ERRORMATERIAL = dr.GetString(pt46);
                                oCampos2.RECT_CAMBIO_MULTA = dr.GetString(pt47);
                                oCampos2.RECT_MONTO = dr.GetDecimal(pt48).ToString();
                                oCampos2.RECT_OTROS = dr.GetString(pt49);
                                oCampos2.RECT_DESC_OTROS = dr.GetString(pt50);

                                //R.D. ACUMULACION
                                oCampos2.ACUM_COD_RESODIREC = dr.GetString(pt51);
                                oCampos2.ACUM_NUM_RESOLUCION = dr.GetString(pt52);
                                oCampos2.ACUM_COD_FCTIPO = dr.GetString(pt53);
                                oCampos2.ACUM_FECHA_EMISION = dr.GetString(pt54);
                                oCampos2.ACUM_DESCRIPCION = dr.GetString(pt55);

                                // R.D. AMPLIACION
                                oCampos2.AMP_COD_RESODIREC = dr.GetString(pt56);
                                oCampos2.AMP_NUM_RESOLUCION = dr.GetString(pt57);
                                oCampos2.RD_FECHA_EMISION_AMP = dr.GetString(pt58);
                                oCampos2.AMP_IMPUTACION = dr.GetString(pt59);
                                oCampos2.AMP_OTRAS_INFRACCIONES = dr.GetString(pt60);
                                oCampos2.AMP_POR_PLAZOS = dr.GetString(pt61);
                                oCampos2.AMP_OTROS = dr.GetString(pt62);

                                // R.D. CADUCIDAD
                                oCampos2.CAD_COD_RESODIREC = dr.GetString(pt63);
                                oCampos2.CAD_NUM_RESOLUCION = dr.GetString(pt64);
                                oCampos2.CAD_RD_FECHA = dr.GetString(pt65);
                                oCampos2.CAD_NUM_EXP = dr.GetString(pt66);
                                oCampos2.CAD_CADUCIDAD = dr.GetString(pt67);

                                oCampos2.OTROS_COD_RESODIREC = dr.GetString(pt68);
                                oCampos2.OTROS_NUM_RESOLUCION = dr.GetString(pt69);
                                oCampos2.OTROS_RD_FECHA = dr.GetString(pt70);
                                oCampos2.OTROS_DETERMINACION = dr.GetString(pt71);

                                oCampos2.VARI_COD_RESODIREC = dr.GetString(pt72);
                                oCampos2.VARI_NUM_RESOLUCION = dr.GetString(pt73);
                                oCampos2.VARI_RD_FECHA = dr.GetString(pt74);
                                oCampos2.VARI_LEVANTAR = dr.GetString(pt75);
                                oCampos2.VARI_LEVANTAR_PARTE = dr.GetString(pt76);
                                oCampos2.VARI_NO_LEVANTAR = dr.GetString(pt77);
                                oCampos2.VARI_MODIFICAR = dr.GetString(pt78);
                                oCampos2.VARI_DETERMINACION = dr.GetString(pt79);

                                oCampos2.ARCH_COD_RESODIREC = dr.GetString(pt80);
                                oCampos2.ARCH_COD_FCTIPO = dr.GetString(pt110);
                                oCampos2.ARCH_NUM_RESOLUCION = dr.GetString(pt81);
                                oCampos2.ARCH_FECHA_RD = dr.GetString(pt82);
                                oCampos2.ARCH_EVIDENCIA_IRRE = dr.GetString(pt83);
                                oCampos2.ARCH_SIN_INFRACCION = dr.GetString(pt84);
                                oCampos2.ARCH_BUEN_MANEJO = dr.GetString(pt85);
                                oCampos2.ARCH_DEFICIENTE_NOT = dr.GetString(pt86);
                                oCampos2.ARCH_DEFICIENCIA_TEC = dr.GetString(pt87);
                                oCampos2.OTROS = dr.GetString(pt88);

                                // PROVEIDO
                                oCampos2.FECHA_PROVEIDO = dr.GetString(pt89);
                                oCampos2.PROVEIDO = dr.GetString(pt90);
                                // TRIBUNAL
                                //oCampos2.NUM_RDTFFS = dr.GetString(pt91);
                                //oCampos2.DETERMINA_TFFSTER = dr.GetString(pt92);
                                //oCampos2.MOTIVO_TFFSTER = dr.GetString(pt93);
                                oCampos2.NUM_POA_STRING = dr.GetString(pt94);

                                // TRIBUNAL R.D. INICIO
                                oCampos2.COD_TRIBUNAL_INI = dr.GetString(pt95);
                                oCampos2.NUM_TFFSINI = dr.GetString(pt96);
                                oCampos2.DETERMINA = dr.GetString(pt97);
                                oCampos2.MOTIVO = dr.GetString(pt98);
                                oCampos2.ESTADO_TFFS = dr.GetString(pt99);
                                //TRIBUNAL R.D. TERMINO
                                oCampos2.COD_TRIBUNAL_TER = dr.GetString(pt100);
                                oCampos2.NUM_TFFSTER = dr.GetString(pt101);
                                oCampos2.DETERMINA_TFFSTER = dr.GetString(pt102);
                                oCampos2.MOTIVO_TFFSTER = dr.GetString(pt103);
                                oCampos2.ESTADO_TFFSTER = dr.GetString(pt104);
                                //TRIBUNAL RECONSIDERACION
                                oCampos2.COD_TRIBUNAL_REC = dr.GetString(pt105);
                                oCampos2.NUM_TFFSREC = dr.GetString(pt106);
                                oCampos2.DETERMINA_TFFSREC = dr.GetString(pt107);
                                oCampos2.MOTIVO_TFFSREC = dr.GetString(pt108);
                                oCampos2.ESTADO_TFFSREC = dr.GetString(pt109);

                                List_Informe.Add(oCampos2);
                            }
                        }

                    }

                    return List_Informe;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}