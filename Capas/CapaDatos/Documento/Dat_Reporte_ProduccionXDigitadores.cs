using System;
using System.Collections.Generic;
//using System.Data.SqlClient;
using CEntidad = CapaEntidad.DOC.Ent_Reporte_ProduccionXDigitadores;
using GeneralSQL;
using Oracle.ManagedDataAccess.Client;
//using CEntidadU = CapaEntidad.DOC.Ent_REPORTE_x_USUARIOS;
//using SQL = GeneralSQL.Data.SQL;

namespace CapaDatos.DOC
{

    public class Dat_Reporte_ProduccionXDigitadores
    {
        //private SQL oGDataSQL = new SQL();
        private DBOracle dBOracle = new DBOracle();
        //lista para el thabilitante
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public List<CEntidad> RegProdXDigitador(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            CEntidad oCampos = new CEntidad();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spReporteProduccionXDigitadores", oCEntidad))
                {
                    if (dr != null)
                    {
                        CEntidad oCamposDet;
                        if (dr.HasRows)
                        {
                            int p1 = dr.GetOrdinal("ANIO");
                            int p2 = dr.GetOrdinal("MESES");
                            int p3 = dr.GetOrdinal("MES");
                            int p4 = dr.GetOrdinal("TH");
                            int p6 = dr.GetOrdinal("POA");
                            int p9 = dr.GetOrdinal("PM");
                            int p14 = dr.GetOrdinal("CARTA_NOTIFICACION");
                            int p16 = dr.GetOrdinal("RD");
                            int p17 = dr.GetOrdinal("ILEG");
                            int p19 = dr.GetOrdinal("INTIT");
                            int p20 = dr.GetOrdinal("TOTAL");

                            int p22 = dr.GetOrdinal("CAP");
                            int p23 = dr.GetOrdinal("NOT_FISC");

                            int p26 = dr.GetOrdinal("ISUP");
                            int p27 = dr.GetOrdinal("GTF");
                            int p28 = dr.GetOrdinal("IFUN");
                            int p29 = dr.GetOrdinal("BusDLinea");

                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.Anio = dr.GetInt32(p1);
                                oCamposDet.MesNombre = dr.GetString(p2);
                                oCamposDet.MesNum = dr.GetInt32(p3);
                                oCamposDet.TH = dr.GetInt32(p4);
                                oCamposDet.POA = dr.GetInt32(p6);
                                oCamposDet.PM = dr.GetInt32(p9);
                                oCamposDet.CN = dr.GetInt32(p14);
                                oCamposDet.RD = dr.GetInt32(p16);
                                oCamposDet.ILEG = dr.GetInt32(p17);
                                oCamposDet.INTIT = dr.GetInt32(p19);
                                oCamposDet.TOTAL = dr.GetInt32(p20);
                                oCamposDet.CAP = dr.GetInt32(p22);
                                oCamposDet.NOT_FISC = dr.GetInt32(p23);
                                oCamposDet.FECHA = dr.GetInt32(p1).ToString() + " " + dr.GetString(p2);

                                oCamposDet.NOT_FISC_NTF = dr.GetInt32(dr.GetOrdinal("NOT_FISC_NTF"));
                                oCamposDet.CN_NTF = dr.GetInt32(dr.GetOrdinal("CARTA_NOTIFICACION_NTF"));

                                oCamposDet.ISUP = dr.GetInt32(p26);
                                oCamposDet.GTF = dr.GetInt32(p27);
                                oCamposDet.IFUN = dr.GetInt32(p28);
                                oCamposDet.BusDLinea = "";
                                //string listDLinea = dr.GetString(p29);
                                //for (int i = 0; i < listDLinea.Length; i = i + 7)
                                //{
                                // if (i != 0) oCamposDet.BusDLinea += ",";
                                oCamposDet.BusDLinea = dr.GetString(p29);
                                // }

                                lsCEntidad.Add(oCamposDet);
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
        //lista que devuelve personas
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        //public List<CEntidad> RegPopupBuscarPersonas(OracleConnection cn, CEntidad oCEntidad)
        //{
        //    List<CEntidad> lsCEntidad = new List<CEntidad>();
        //    CEntidad oCampos = new CEntidad();
        //    try
        //    {
        //        using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC.spReporteProduccionXDigitadoresUsuarios", oCEntidad))
        //        {
        //            if (dr != null)
        //            {
        //                CEntidad oCamposDet;
        //                if (dr.HasRows)
        //                {
        //                    int p1 = dr.GetOrdinal("COD_UCUENTA");
        //                    int p2 = dr.GetOrdinal("COD_UGRUPO");
        //                    int p3 = dr.GetOrdinal("APELLIDOS_NOMBRES");
        //                    int p4 = dr.GetOrdinal("N_DOCUMENTO");

        //                    while (dr.Read())
        //                    {
        //                        oCamposDet = new CEntidad();
        //                        oCamposDet.COD_UCUENTA = dr.GetString(p1);
        //                        oCamposDet.COD_UGRUPO = dr.GetString(p2);
        //                        oCamposDet.APELLIDOS_NOMBRES = dr.GetString(p3);
        //                        oCamposDet.N_DOCUMENTO = dr.GetString(p4);


        //                        lsCEntidad.Add(oCamposDet);
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
        //public List<CEntidad> RegProdXDigitadorDetalle(SqlConnection cn, CEntidad oCEntidad)
        //{
        //    List<CEntidad> lsCEntidad = new List<CEntidad>();
        //    CEntidad oCampos = new CEntidad();
        //    try
        //    {
        //        using (SqlDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC.spReporteProduccionXDigitadoresDetalle", oCEntidad))
        //        {
        //            if (dr != null)
        //            {
        //                CEntidad oCamposDet;
        //                if (dr.HasRows)
        //                {
        //                    int p1 = dr.GetOrdinal("NOMBRES");
        //                    int p2 = dr.GetOrdinal("DESCRIPCION");
        //                    int p3 = dr.GetOrdinal("ESTADO_ORIGEN");
        //                    int p4 = dr.GetOrdinal("COD_UCUENTA");
        //                    int p5 = dr.GetOrdinal("1ERASEMANA");
        //                    int p6 = dr.GetOrdinal("2DASEMANA");
        //                    int p7 = dr.GetOrdinal("3DASEMANA");
        //                    int p8 = dr.GetOrdinal("4TASEMANA");
        //                    int p9 = dr.GetOrdinal("5DASEMANA");

        //                    while (dr.Read())
        //                    {
        //                        oCamposDet = new CEntidad();
        //                        oCamposDet.NOMBRES = dr.GetString(p1);
        //                        oCamposDet.DESCRIPCION = dr.GetString(p2);
        //                        oCamposDet.ESTADO_ORIGEN = dr.GetString(p3);
        //                        oCamposDet.COD_UCUENTA = dr.GetString(p4);
        //                        oCamposDet.SEMANAUNO = dr.GetInt32(p5);
        //                        oCamposDet.SEMANADOS = dr.GetInt32(p6);
        //                        oCamposDet.SEMANATRES = dr.GetInt32(p7);
        //                        oCamposDet.SEMANACUATRO = dr.GetInt32(p8);
        //                        oCamposDet.SEMANACINCO = dr.GetInt32(p9);
        //                        lsCEntidad.Add(oCamposDet);
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
        /// Devuelde un listado de todos los registros realizados por el digitador en un determiando año, mes y OD
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public List<CEntidad> RegProdXDigitadorDetalleRegistros(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spReporteProduccionXDigitadoresDetalleRegistros", oCEntidad))
                {
                    if (dr != null)
                    {
                        CEntidad oCamposDet;
                        if (dr.HasRows)
                        {
                            switch (oCEntidad.BusCriterio)
                            {
                                case "TITULO_HABILITANTE":
                                    while (dr.Read())
                                    {
                                        oCamposDet = new CEntidad();
                                        oCamposDet.NUM_THABILITANTE = dr.GetString(dr.GetOrdinal("NUM_THABILITANTE"));
                                        oCamposDet.TITULAR = dr.GetString(dr.GetOrdinal("TITULAR"));
                                        oCamposDet.D_LINEA = dr.GetString(dr.GetOrdinal("D_LINEA"));
                                        oCamposDet.MODALIDAD = dr.GetString(dr.GetOrdinal("MODALIDAD"));
                                        oCamposDet.DEPARTAMENTO = dr.GetString(dr.GetOrdinal("DEPARTAMENTO"));
                                        oCamposDet.THV = dr.GetInt32(dr.GetOrdinal("THV"));

                                        lsCEntidad.Add(oCamposDet);
                                    }
                                    break;
                                case "POA":
                                    while (dr.Read())
                                    {
                                        oCamposDet = new CEntidad();
                                        oCamposDet.NUM_THABILITANTE = dr.GetString(dr.GetOrdinal("NUM_THABILITANTE"));
                                        oCamposDet.TITULAR = dr.GetString(dr.GetOrdinal("TITULAR"));
                                        oCamposDet.D_LINEA = dr.GetString(dr.GetOrdinal("D_LINEA"));
                                        oCamposDet.NUM_POA = dr.GetString(dr.GetOrdinal("NUM_POA"));
                                        oCamposDet.DEPARTAMENTO = dr.GetString(dr.GetOrdinal("DEPARTAMENTO"));
                                        oCamposDet.NUM_RESOLUCION = dr.GetString(dr.GetOrdinal("NUM_RESOLUCION"));
                                        oCamposDet.POAM = dr.GetInt32(dr.GetOrdinal("POAM"));
                                        oCamposDet.POANMAD = dr.GetInt32(dr.GetOrdinal("POANMAD"));

                                        lsCEntidad.Add(oCamposDet);
                                    }
                                    break;
                                case "PLAN_MANEJO":
                                    while (dr.Read())
                                    {
                                        oCamposDet = new CEntidad();
                                        oCamposDet.NUM_THABILITANTE = dr.GetString(dr.GetOrdinal("NUM_THABILITANTE"));
                                        oCamposDet.TITULAR = dr.GetString(dr.GetOrdinal("TITULAR"));
                                        oCamposDet.D_LINEA = dr.GetString(dr.GetOrdinal("D_LINEA"));
                                        oCamposDet.NUM_RESOLUCION = dr.GetString(dr.GetOrdinal("NUM_RESOLUCION"));
                                        oCamposDet.DEPARTAMENTO = dr.GetString(dr.GetOrdinal("DEPARTAMENTO"));
                                        oCamposDet.PMTC = dr.GetInt32(dr.GetOrdinal("PMTC"));
                                        oCamposDet.PMTI = dr.GetInt32(dr.GetOrdinal("PMTI"));

                                        lsCEntidad.Add(oCamposDet);
                                    }
                                    break;
                                case "CAPACITACION":
                                    while (dr.Read())
                                    {
                                        oCamposDet = new CEntidad();
                                        oCamposDet.NOM_CAPACITACION = dr.GetString(dr.GetOrdinal("NOM_CAPACITACION"));
                                        oCamposDet.CAPPART = dr.GetInt32(dr.GetOrdinal("CAPPART"));
                                        oCamposDet.DEPARTAMENTO = dr.GetString(dr.GetOrdinal("DEPARTAMENTO"));
                                        oCamposDet.D_LINEA = dr.GetString(dr.GetOrdinal("D_LINEA"));
                                        oCamposDet.NOM_OD = dr.GetString(dr.GetOrdinal("NOM_OD"));
                                        oCamposDet.FECHA_INICIO = dr.GetString(dr.GetOrdinal("FECHA_INICIO"));

                                        lsCEntidad.Add(oCamposDet);
                                    }
                                    break;
                                case "CARTA_NOTIFICACION":
                                case "CARTA_NOTIFICACION_NTF":
                                    while (dr.Read())
                                    {
                                        oCamposDet = new CEntidad();
                                        oCamposDet.NUM_CNOTIFICACION = dr.GetString(dr.GetOrdinal("NUM_CNOTIFICACION"));
                                        oCamposDet.NUM_THABILITANTE = dr.GetString(dr.GetOrdinal("NUM_THABILITANTE"));
                                        oCamposDet.TITULAR = dr.GetString(dr.GetOrdinal("TITULAR"));
                                        oCamposDet.DEPARTAMENTO = dr.GetString(dr.GetOrdinal("DEPARTAMENTO"));
                                        try  //Datos que no cuentan con valor y no se le puede asignar un valor por defecto en la BD
                                        {
                                            oCamposDet.FECHA_NOTIFICACION = dr.GetString(dr.GetOrdinal("FECHA_NOTIFICACION"));
                                        }
                                        catch (Exception)
                                        {
                                            oCamposDet.FECHA_NOTIFICACION = "";
                                        }
                                        oCamposDet.D_LINEA = dr.GetString(dr.GetOrdinal("D_LINEA"));
                                        oCamposDet.FECHA_CREACION = dr.GetString(dr.GetOrdinal("FECHA_CREACION"));

                                        lsCEntidad.Add(oCamposDet);
                                    }
                                    break;
                                case "NOTIFICACION_FISCALIZACION":
                                case "NOTIFICACION_FISCALIZACION_NTF":
                                    while (dr.Read())
                                    {
                                        oCamposDet = new CEntidad();
                                        oCamposDet.NUM_THABILITANTE = dr.GetString(dr.GetOrdinal("NUM_THABILITANTE"));
                                        oCamposDet.TITULAR = dr.GetString(dr.GetOrdinal("TITULAR"));
                                        oCamposDet.DEPARTAMENTO = dr.GetString(dr.GetOrdinal("DEPARTAMENTO"));
                                        oCamposDet.NUM_CNOTIFICACION = dr.GetString(dr.GetOrdinal("NUM_CNOTIFICACION"));
                                        oCamposDet.TIPO_DOCUMENTO = dr.GetString(dr.GetOrdinal("TIPO_NOTIFICACION"));
                                        oCamposDet.NUM_INFORME = dr.GetString(dr.GetOrdinal("NUM_INFORME"));
                                        oCamposDet.NUM_RESOLUCION = dr.GetString(dr.GetOrdinal("NUM_RESOLUCION"));

                                        try  //Datos que no cuentan con valor y no se le puede asignar un valor por defecto en la BD
                                        {
                                            oCamposDet.FECHA_NOTIFICACION = dr.GetString(dr.GetOrdinal("FECHA_NOTIFICA_TITULAR"));
                                        }
                                        catch (Exception)
                                        {
                                            oCamposDet.FECHA_NOTIFICACION = "";
                                        }
                                        oCamposDet.D_LINEA = dr.GetString(dr.GetOrdinal("D_LINEA"));
                                        oCamposDet.FECHA_CREACION = dr.GetString(dr.GetOrdinal("FECHA_CREACION"));

                                        lsCEntidad.Add(oCamposDet);
                                    }
                                    break;
                                case "INFORME_SUPERVISION":
                                    while (dr.Read())
                                    {
                                        oCamposDet = new CEntidad();
                                        oCamposDet.NUM_INFORME = dr.GetString(dr.GetOrdinal("NUM_INFORME"));
                                        oCamposDet.NUM_THABILITANTE = dr.GetString(dr.GetOrdinal("NUM_THABILITANTE"));
                                        oCamposDet.TITULAR = dr.GetString(dr.GetOrdinal("TITULAR"));
                                        oCamposDet.MODALIDAD = dr.GetString(dr.GetOrdinal("MODALIDAD"));
                                        oCamposDet.FECHA_INICIO = dr.GetString(dr.GetOrdinal("FECHA_INICIO"));
                                        oCamposDet.FECHA_TERMINO = dr.GetString(dr.GetOrdinal("FECHA_TERMINO"));
                                        oCamposDet.D_LINEA = dr.GetString(dr.GetOrdinal("D_LINEA"));
                                        oCamposDet.ISUPM = dr.GetInt32(dr.GetOrdinal("ISUPM"));
                                        oCamposDet.ISUPNM = dr.GetInt32(dr.GetOrdinal("ISUPNM"));

                                        lsCEntidad.Add(oCamposDet);
                                    }
                                    break;
                                case "GUIA_TRANSPORTE":
                                    while (dr.Read())
                                    {
                                        oCamposDet = new CEntidad();
                                        oCamposDet.NUM_GUIA = dr.GetString(dr.GetOrdinal("NUM_GUIA"));
                                        oCamposDet.NUM_THABILITANTE = dr.GetString(dr.GetOrdinal("NUM_THABILITANTE"));
                                        oCamposDet.TITULAR = dr.GetString(dr.GetOrdinal("TITULAR"));
                                        oCamposDet.NOM_GUIA = dr.GetString(dr.GetOrdinal("NOM_GUIA"));

                                        lsCEntidad.Add(oCamposDet);
                                    }
                                    break;
                                case "INFORME_LEGAL":
                                    while (dr.Read())
                                    {
                                        oCamposDet = new CEntidad();
                                        oCamposDet.NUM_INFORME = dr.GetString(dr.GetOrdinal("NUM_INFORME"));
                                        oCamposDet.NUM_THABILITANTE = dr.GetString(dr.GetOrdinal("NUM_THABILITANTE"));
                                        oCamposDet.TITULAR = dr.GetString(dr.GetOrdinal("TITULAR"));
                                        oCamposDet.MODALIDAD = dr.GetString(dr.GetOrdinal("MODALIDAD"));
                                        oCamposDet.FECHA_EMISION = dr.GetString(dr.GetOrdinal("FECHA_EMISION"));
                                        oCamposDet.D_LINEA = dr.GetString(dr.GetOrdinal("D_LINEA"));

                                        lsCEntidad.Add(oCamposDet);
                                    }
                                    break;
                                case "RESOLUCION_DIRECTORAL":
                                    while (dr.Read())
                                    {
                                        oCamposDet = new CEntidad();
                                        oCamposDet.NUM_THABILITANTE = dr.GetString(dr.GetOrdinal("NUM_THABILITANTE"));
                                        oCamposDet.TITULAR = dr.GetString(dr.GetOrdinal("TITULAR"));
                                        oCamposDet.MODALIDAD = dr.GetString(dr.GetOrdinal("MODALIDAD"));
                                        oCamposDet.NUM_RESOLUCION = dr.GetString(dr.GetOrdinal("NUM_RESOLUCION"));
                                        oCamposDet.FECHA_EMISION = dr.GetString(dr.GetOrdinal("FECHA_EMISION"));
                                        oCamposDet.D_LINEA = dr.GetString(dr.GetOrdinal("D_LINEA"));

                                        lsCEntidad.Add(oCamposDet);
                                    }
                                    break;
                                case "INFORME_FUNDAMENTADO":
                                    while (dr.Read())
                                    {
                                        oCamposDet = new CEntidad();
                                        oCamposDet.NUM_INFORME = dr.GetString(dr.GetOrdinal("NUM_INFORME"));
                                        oCamposDet.NUM_THABILITANTE = dr.GetString(dr.GetOrdinal("NUM_THABILITANTE"));
                                        oCamposDet.TITULAR = dr.GetString(dr.GetOrdinal("TITULAR"));
                                        oCamposDet.MODALIDAD = dr.GetString(dr.GetOrdinal("MODALIDAD"));
                                        oCamposDet.DEPARTAMENTO = dr.GetString(dr.GetOrdinal("DEPARTAMENTO"));
                                        oCamposDet.FECHA_EMISION = dr.GetString(dr.GetOrdinal("FECHA_EMISION"));
                                        oCamposDet.D_LINEA = dr.GetString(dr.GetOrdinal("D_LINEA"));

                                        lsCEntidad.Add(oCamposDet);
                                    }
                                    break;
                                case "INFORMACION_TITULAR":
                                    while (dr.Read())
                                    {
                                        oCamposDet = new CEntidad();
                                        oCamposDet.NUM_INFORME = dr.GetString(dr.GetOrdinal("NUM_INFORME"));
                                        oCamposDet.NUM_THABILITANTE = dr.GetString(dr.GetOrdinal("NUM_THABILITANTE"));
                                        oCamposDet.TITULAR = dr.GetString(dr.GetOrdinal("TITULAR"));
                                        oCamposDet.MODALIDAD = dr.GetString(dr.GetOrdinal("MODALIDAD"));
                                        oCamposDet.FECHA_EMISION = dr.GetString(dr.GetOrdinal("FECHA_EMISION"));
                                        oCamposDet.D_LINEA = dr.GetString(dr.GetOrdinal("D_LINEA"));
                                        oCamposDet.TIPO_DOCUMENTO = dr.GetString(dr.GetOrdinal("TIPO_DOCUMENTO"));
                                        lsCEntidad.Add(oCamposDet);
                                    }
                                    break;
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
        //public List<CEntidad> RegProdXDigitador01(OracleConnection cn, CEntidad oCEntidad)
        //{
        //    List<CEntidad> lsCEntidad = new List<CEntidad>();
        //    CEntidad oCampos = new CEntidad();
        //    try
        //    {
        //        if (oCEntidad.listAnio != null)
        //        {
        //            foreach (var loDatos in oCEntidad.listAnio)
        //            {
        //                using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC.spReporteProduccionXDigitadores", loDatos))
        //                {
        //                    if (dr != null)
        //                    {
        //                        CEntidad oCamposDet;
        //                        if (dr.HasRows)
        //                        {
        //                            int p1 = dr.GetOrdinal("ANIO");
        //                            int p2 = dr.GetOrdinal("MESES");
        //                            int p3 = dr.GetOrdinal("MES");
        //                            int p4 = dr.GetOrdinal("TH");
        //                            int p5 = dr.GetOrdinal("THV");
        //                            int p6 = dr.GetOrdinal("POA");
        //                            int p7 = dr.GetOrdinal("POAM");
        //                            int p8 = dr.GetOrdinal("POANMAD");
        //                            int p9 = dr.GetOrdinal("PM");
        //                            int p10 = dr.GetOrdinal("PMTC");
        //                            int p11 = dr.GetOrdinal("PMTI");
        //                            int p12 = dr.GetOrdinal("ISUPM");
        //                            int p13 = dr.GetOrdinal("ISUPNM");
        //                            int p14 = dr.GetOrdinal("CARTA_NOTIFICACION");
        //                            int p15 = dr.GetOrdinal("INFORME");
        //                            int p16 = dr.GetOrdinal("RD");
        //                            int p17 = dr.GetOrdinal("ILEG");
        //                            int p18 = dr.GetOrdinal("INTEC");
        //                            int p19 = dr.GetOrdinal("INTIT");
        //                            int p20 = dr.GetOrdinal("TOTAL");
        //                            int p21 = dr.GetOrdinal("TOTALGENERAL");
        //                            while (dr.Read())
        //                            {
        //                                oCamposDet = new CEntidad();
        //                                oCamposDet.Anio = dr.GetInt32(p1);
        //                                oCamposDet.MesNombre = dr.GetString(p2);
        //                                oCamposDet.MesNum = dr.GetInt32(p3);
        //                                oCamposDet.TH = dr.GetInt32(p4);
        //                                oCamposDet.THV = dr.GetInt32(p5);
        //                                oCamposDet.POA = dr.GetInt32(p6);
        //                                oCamposDet.POAM = dr.GetInt32(p7);
        //                                oCamposDet.POANMAD = dr.GetInt32(p8);
        //                                oCamposDet.PM = dr.GetInt32(p9);
        //                                oCamposDet.PMTC = dr.GetInt32(p10);
        //                                oCamposDet.PMTI = dr.GetInt32(p11);
        //                                oCamposDet.ISUPM = dr.GetInt32(p12);
        //                                oCamposDet.ISUPNM = dr.GetInt32(p13);
        //                                oCamposDet.CN = dr.GetInt32(p14);
        //                                oCamposDet.INF = dr.GetInt32(p15);
        //                                oCamposDet.RD = dr.GetInt32(p16);
        //                                oCamposDet.ILEG = dr.GetInt32(p17);
        //                                oCamposDet.INTEC = dr.GetInt32(p18);
        //                                oCamposDet.INTIT = dr.GetInt32(p19);
        //                                oCamposDet.TOTAL = dr.GetInt32(p20);
        //                                oCamposDet.TOTALGENERAL = dr.GetInt32(p21);
        //                                oCamposDet.FECHA = dr.GetInt32(p1).ToString() + " " + dr.GetString(p2);

        //                                lsCEntidad.Add(oCamposDet);
        //                            }

        //                        }
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
        //public List<CEntidadU> RegProdXUsuario(SqlConnection cn, CEntidadU oCEntidad)
        //{
        //    List<CEntidadU> lsCEntidad = new List<CEntidadU>();
        //    CEntidadU oCampos = new CEntidadU();
        //    try
        //    {
        //        using (SqlDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC.spReporteProduccionXUsuario", oCEntidad))
        //        {
        //            if (dr != null)
        //            {
        //                CEntidadU oCamposDet;
        //                if (dr.HasRows)
        //                {
        //                    int p1 = dr.GetOrdinal("ANIO");
        //                    int p2 = dr.GetOrdinal("MESES");
        //                    int p3 = dr.GetOrdinal("MES");
        //                    int p9 = dr.GetOrdinal("RD");
        //                    int p10 = dr.GetOrdinal("ILEG");
        //                    int p11 = dr.GetOrdinal("INTEC");
        //                    int p17 = dr.GetOrdinal("INFUN");
        //                    int p18 = dr.GetOrdinal("SE");
        //                    int p19 = dr.GetOrdinal("SI");
        //                    int p12 = dr.GetOrdinal("FISNOT");
        //                    int p4 = dr.GetOrdinal("FISNOTSUP");
        //                    int p5 = dr.GetOrdinal("FISNOTOFIC");
        //                    int p13 = dr.GetOrdinal("INF_TITULAR");
        //                    int p14 = dr.GetOrdinal("DOCREM");
        //                    int p15 = dr.GetOrdinal("TOTAL");
        //                    int p16 = dr.GetOrdinal("TOTALGENERAL");
        //                    while (dr.Read())
        //                    {
        //                        oCamposDet = new CEntidadU();
        //                        oCamposDet.Anio = dr.GetInt32(p1);
        //                        oCamposDet.MesNombre = dr.GetString(p2);
        //                        oCamposDet.MesNum = dr.GetInt32(p3);
        //                        oCamposDet.FISNOTOFIC = dr.GetInt32(p5);
        //                        oCamposDet.FISNOTSUP = dr.GetInt32(p4);
        //                        oCamposDet.RD = dr.GetInt32(p9);
        //                        oCamposDet.ILEG = dr.GetInt32(p10);
        //                        oCamposDet.INTEC = dr.GetInt32(p11);
        //                        oCamposDet.INFUN = dr.GetInt32(p17);
        //                        oCamposDet.SEXT = dr.GetInt32(p18);
        //                        oCamposDet.SINT = dr.GetInt32(p19);
        //                        oCamposDet.FISNOTI = dr.GetInt32(p12);
        //                        oCamposDet.INFTIT = dr.GetInt32(p13);
        //                        oCamposDet.DOCREM = dr.GetInt32(p14);

        //                        oCamposDet.TOTAL = dr.GetInt32(p15);
        //                        oCamposDet.TOTALGENERAL = dr.GetInt32(p16);
        //                        oCamposDet.FECHA = dr.GetInt32(p1).ToString() + " " + dr.GetString(p2);

        //                        lsCEntidad.Add(oCamposDet);
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
        //public List<CEntidadU> RegProdXUsuarioDetalle(SqlConnection cn, CEntidadU oCEntidad)
        //{
        //    List<CEntidadU> lsCEntidad = new List<CEntidadU>();
        //    CEntidadU oCampos = new CEntidadU();
        //    try
        //    {
        //        using (SqlDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC.spReporteUsuariosDetalle", oCEntidad))
        //        {
        //            if (dr != null)
        //            {
        //                CEntidadU oCamposDet;
        //                if (dr.HasRows)
        //                {
        //                    int p1 = dr.GetOrdinal("NOMBRES");
        //                    int p2 = dr.GetOrdinal("DESCRIPCION");
        //                    int p3 = dr.GetOrdinal("ESTADO");
        //                    int p4 = dr.GetOrdinal("COD_UCUENTA");
        //                    int p5 = dr.GetOrdinal("1ERASEMANA");
        //                    int p6 = dr.GetOrdinal("2DASEMANA");
        //                    int p7 = dr.GetOrdinal("3DASEMANA");
        //                    int p8 = dr.GetOrdinal("4TASEMANA");
        //                    int p9 = dr.GetOrdinal("5DASEMANA");

        //                    while (dr.Read())
        //                    {
        //                        oCamposDet = new CEntidadU();
        //                        oCamposDet.NOMBRES = dr.GetString(p1);
        //                        oCamposDet.DESCRIPCION = dr.GetString(p2);
        //                        oCamposDet.ESTADO_ORIGEN = dr.GetString(p3);
        //                        oCamposDet.COD_UCUENTA = dr.GetString(p4);
        //                        oCamposDet.SEMANAUNO = dr.GetInt32(p5);
        //                        oCamposDet.SEMANADOS = dr.GetInt32(p6);
        //                        oCamposDet.SEMANATRES = dr.GetInt32(p7);
        //                        oCamposDet.SEMANACUATRO = dr.GetInt32(p8);
        //                        oCamposDet.SEMANACINCO = dr.GetInt32(p9);
        //                        lsCEntidad.Add(oCamposDet);
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
        //public List<CEntidadU> RegProdXUsuarioDetalle01(SqlConnection cn, CEntidadU oCEntidad)
        //{
        //    List<CEntidadU> lsCEntidad = new List<CEntidadU>();
        //    CEntidadU oCampos = new CEntidadU();
        //    try
        //    {
        //        using (SqlDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC.spReporteUsuariosDetalle01", oCEntidad))
        //        {
        //            if (dr != null)
        //            {
        //                CEntidadU oCamposDet;
        //                if (dr.HasRows)
        //                {
        //                    int p1 = dr.GetOrdinal("APELLIDOS_NOMBRES");
        //                    int p2 = dr.GetOrdinal("NUMERO");
        //                    int p5 = dr.GetOrdinal("TIPO");
        //                    int p6 = dr.GetOrdinal("DESCRIPCION");
        //                    int p3 = dr.GetOrdinal("FECHA");
        //                    int p4 = dr.GetOrdinal("HORA");


        //                    while (dr.Read())
        //                    {
        //                        oCamposDet = new CEntidadU();
        //                        oCamposDet.APELLIDOS_NOMBRES = dr.GetString(p1);
        //                        oCamposDet.N_DOCUMENTO = dr.GetString(p2);
        //                        oCamposDet.FECHA1 = dr.GetString(p3);
        //                        oCamposDet.HORA = dr.GetString(p4);
        //                        oCamposDet.TIPO = dr.GetString(p5);
        //                        oCamposDet.DESCRIPCION = dr.GetString(p6);
        //                        lsCEntidad.Add(oCamposDet);
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
        public List<CEntidad> datRegistroInformacion(OracleConnection cn, CEntidad oCEntidad)
        {

            List<CEntidad> lsCEntidad = new List<CEntidad>();
            CEntidad oCampos = new CEntidad();
            try
            {



                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spCR_ReporteRegistroOD", oCEntidad))
                {
                    if (dr != null)
                    {
                        CEntidad oCamposDet;
                        if (dr.HasRows)
                        {
                            int p1 = dr.GetOrdinal("NOMBRE");
                            int p2 = dr.GetOrdinal("COD_OD_REGISTRO");
                            int p3 = dr.GetOrdinal("ENERO");
                            int p4 = dr.GetOrdinal("FEBRERO");
                            int p5 = dr.GetOrdinal("MARZO");
                            int p6 = dr.GetOrdinal("ABRIL");
                            int p7 = dr.GetOrdinal("MAYO");
                            int p8 = dr.GetOrdinal("JUNIO");
                            int p9 = dr.GetOrdinal("JULIO");
                            int p10 = dr.GetOrdinal("AGOSTO");
                            int p11 = dr.GetOrdinal("SEPTIEMBRE");
                            int p12 = dr.GetOrdinal("OCTUBRE");
                            int p13 = dr.GetOrdinal("NOVIEMBRE");
                            int p14 = dr.GetOrdinal("DICIEMBRE");


                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.DESCRIPCION = dr.GetString(p1);
                                oCamposDet.NOM_OD = dr.GetString(p2);
                                oCamposDet.enero = dr.GetInt32(p3);
                                oCamposDet.febrero = dr.GetInt32(p4);
                                oCamposDet.marzo = dr.GetInt32(p5);
                                oCamposDet.abril = dr.GetInt32(p6);
                                oCamposDet.mayo = dr.GetInt32(p7);
                                oCamposDet.junio = dr.GetInt32(p8);
                                oCamposDet.julio = dr.GetInt32(p9);
                                oCamposDet.agosto = dr.GetInt32(p10);
                                oCamposDet.septiembre = dr.GetInt32(p11);
                                oCamposDet.octubre = dr.GetInt32(p12);
                                oCamposDet.noviembre = dr.GetInt32(p13);
                                oCamposDet.diciembre = dr.GetInt32(p14);
                                oCamposDet.TOTAL = oCamposDet.enero + oCamposDet.febrero + oCamposDet.marzo + oCamposDet.abril + oCamposDet.mayo + oCamposDet.junio + oCamposDet.julio + oCamposDet.agosto + oCamposDet.septiembre + oCamposDet.octubre + oCamposDet.noviembre + oCamposDet.diciembre;
                                lsCEntidad.Add(oCamposDet);
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

        public List<CEntidad> datRegistroInformacionDetalle(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            CEntidad oCampos = new CEntidad();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spCR_ReporteRegistroODDetalle", oCEntidad))
                {
                    if (dr != null)
                    {
                        CEntidad oCamposDet;
                        if (dr.HasRows)
                        {
                            int p1 = dr.GetOrdinal("NOMBRE");
                            int p2 = dr.GetOrdinal("COD_OD_REGISTRO");
                            int p3 = dr.GetOrdinal("ENERO");
                            int p4 = dr.GetOrdinal("FEBRERO");
                            int p5 = dr.GetOrdinal("MARZO");
                            int p6 = dr.GetOrdinal("ABRIL");
                            int p7 = dr.GetOrdinal("MAYO");
                            int p8 = dr.GetOrdinal("JUNIO");
                            int p9 = dr.GetOrdinal("JULIO");
                            int p10 = dr.GetOrdinal("AGOSTO");
                            int p11 = dr.GetOrdinal("SEPTIEMBRE");
                            int p12 = dr.GetOrdinal("OCTUBRE");
                            int p13 = dr.GetOrdinal("NOVIEMBRE");
                            int p14 = dr.GetOrdinal("DICIEMBRE");


                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.DESCRIPCION = dr.GetString(p1);
                                oCamposDet.NOM_OD = dr.GetString(p2);
                                oCamposDet.enero = dr.GetInt32(p3);
                                oCamposDet.febrero = dr.GetInt32(p4);
                                oCamposDet.marzo = dr.GetInt32(p5);
                                oCamposDet.abril = dr.GetInt32(p6);
                                oCamposDet.mayo = dr.GetInt32(p7);
                                oCamposDet.junio = dr.GetInt32(p8);
                                oCamposDet.julio = dr.GetInt32(p9);
                                oCamposDet.agosto = dr.GetInt32(p10);
                                oCamposDet.septiembre = dr.GetInt32(p11);
                                oCamposDet.octubre = dr.GetInt32(p12);
                                oCamposDet.noviembre = dr.GetInt32(p13);
                                oCamposDet.diciembre = dr.GetInt32(p14);
                                oCamposDet.TOTAL = oCamposDet.enero + oCamposDet.febrero + oCamposDet.marzo + oCamposDet.abril + oCamposDet.mayo + oCamposDet.junio + oCamposDet.julio + oCamposDet.agosto + oCamposDet.septiembre + oCamposDet.octubre + oCamposDet.noviembre + oCamposDet.diciembre;
                                lsCEntidad.Add(oCamposDet);
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

        public List<CEntidad> datRegistroInformacionDetalle2(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            CEntidad oCampos = new CEntidad();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spCRReporteRegistroInformacion2", oCEntidad))
                {
                    if (dr != null)
                    {
                        CEntidad oCamposDet;




                        if (dr.HasRows)
                        {
                            int p1 = dr.GetOrdinal("CODIGO");
                            int p2 = dr.GetOrdinal("TIPO");
                            int p3 = dr.GetOrdinal("MODALIDAD");
                            int p4 = dr.GetOrdinal("TITULO");
                            int p5 = dr.GetOrdinal("CARTA");
                            int p6 = dr.GetOrdinal("NUM_RD");
                            int p7 = dr.GetOrdinal("FECHA_EMISION");
                            int p8 = dr.GetOrdinal("FECHA_NOTIFICACION_TITULAR");
                            int p9 = dr.GetOrdinal("DEPARTAMENTO");
                            int p10 = dr.GetOrdinal("PROVINCIA");

                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.CODIGO = dr["CODIGO"].ToString();
                                oCamposDet.TIPO = dr["TIPO"].ToString();
                                oCamposDet.MODALIDAD = dr["MODALIDAD"].ToString();
                                oCamposDet.TITULO = dr["TITULO"].ToString();
                                oCamposDet.CARTA = dr["CARTA"].ToString();
                                oCamposDet.NUM_RD = dr["NUM_RD"].ToString();
                                oCamposDet.FECHA_EMISION = dr["FECHA_EMISION"].ToString();
                                oCamposDet.FECHA_NOTIFICACION_TITULAR = dr["FECHA_NOTIFICACION_TITULAR"].ToString();
                                oCamposDet.DEPARTAMENTO = dr["DEPARTAMENTO"].ToString();
                                oCamposDet.PROVINCIA = dr["PROVINCIA"].ToString();
                                lsCEntidad.Add(oCamposDet);
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

        public List<CEntidad> datRegistroInformacionExpedientes(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            CEntidad oCampos = new CEntidad();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spCR_ReporteRegistroDLINEA", oCEntidad))
                {
                    if (dr != null)
                    {
                        CEntidad oCamposDet;
                        if (dr.HasRows)
                        {
                            int p1 = dr.GetOrdinal("NOMBRE");
                            int p2 = dr.GetOrdinal("COD_OD_REGISTRO");
                            int p3 = dr.GetOrdinal("ENERO");
                            int p4 = dr.GetOrdinal("FEBRERO");
                            int p5 = dr.GetOrdinal("MARZO");
                            int p6 = dr.GetOrdinal("ABRIL");
                            int p7 = dr.GetOrdinal("MAYO");
                            int p8 = dr.GetOrdinal("JUNIO");
                            int p9 = dr.GetOrdinal("JULIO");
                            int p10 = dr.GetOrdinal("AGOSTO");
                            int p11 = dr.GetOrdinal("SEPTIEMBRE");
                            int p12 = dr.GetOrdinal("OCTUBRE");
                            int p13 = dr.GetOrdinal("NOVIEMBRE");
                            int p14 = dr.GetOrdinal("DICIEMBRE");

                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.MODALIDAD = dr.GetString(p1);
                                oCamposDet.NOM_OD = dr.GetString(p2);
                                oCamposDet.enero = dr.GetInt32(p3);
                                oCamposDet.febrero = dr.GetInt32(p4);
                                oCamposDet.marzo = dr.GetInt32(p5);
                                oCamposDet.abril = dr.GetInt32(p6);
                                oCamposDet.mayo = dr.GetInt32(p7);
                                oCamposDet.junio = dr.GetInt32(p8);
                                oCamposDet.julio = dr.GetInt32(p9);
                                oCamposDet.agosto = dr.GetInt32(p10);
                                oCamposDet.septiembre = dr.GetInt32(p11);
                                oCamposDet.octubre = dr.GetInt32(p12);
                                oCamposDet.noviembre = dr.GetInt32(p13);
                                oCamposDet.diciembre = dr.GetInt32(p14);
                                oCamposDet.TOTAL = oCamposDet.enero + oCamposDet.febrero + oCamposDet.marzo + oCamposDet.abril + oCamposDet.mayo + oCamposDet.junio + oCamposDet.julio + oCamposDet.agosto + oCamposDet.septiembre + oCamposDet.octubre + oCamposDet.noviembre + oCamposDet.diciembre;

                                lsCEntidad.Add(oCamposDet);
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

        public List<CEntidad> datRegistroInformacioExpediente2(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            CEntidad oCampos = new CEntidad();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spCR_ReporteRegistroDLINEA2", oCEntidad))
                {
                    if (dr != null)
                    {
                        CEntidad oCamposDet;
                        if (dr.HasRows)
                        {
                            int p1 = dr.GetOrdinal("FECHA");
                            int p2 = dr.GetOrdinal("MODALIDAD");
                            int p3 = dr.GetOrdinal("N_THABILITANTE");
                            int p4 = dr.GetOrdinal("TIPO_DOCUMENTO");



                            int p5 = dr.GetOrdinal("DEPARTAMENTO");
                            int p6 = dr.GetOrdinal("PROVINCIA");

                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.FECHA = dr["FECHA"].ToString();
                                oCamposDet.MODALIDAD = dr.GetString(p2);
                                oCamposDet.TITULO = dr.GetString(p3);
                                oCamposDet.TIPO = dr.GetString(p4);
                                oCamposDet.DEPARTAMENTO = dr.GetString(p5);
                                oCamposDet.PROVINCIA = dr.GetString(p6);
                                lsCEntidad.Add(oCamposDet);
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

        public List<CEntidad> datRegistroTalleres(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            CEntidad oCampos = new CEntidad();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spCR_ReporteTaller", oCEntidad))
                {
                    if (dr != null)
                    {
                        CEntidad oCamposDet;
                        if (dr.HasRows)
                        {
                            int p1 = dr.GetOrdinal("TIPO");
                            int p2 = dr.GetOrdinal("NOMBRE");
                            int p3 = dr.GetOrdinal("DEPARTAMENTO");
                            int p4 = dr.GetOrdinal("FECHA");
                            int p5 = dr.GetOrdinal("ORGANIZADOR");
                            int p6 = dr.GetOrdinal("PUBLICO_OBJECTIVO");
                            int p7 = dr.GetOrdinal("N_PARTICIPANTES");
                            int p8 = dr.GetOrdinal("MARCO_CONVENIO");


                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.TIPO = dr.GetString(p1);
                                oCamposDet.NOMBRES = dr.GetString(p2);
                                oCamposDet.DEPARTAMENTO = dr.GetString(p3);
                                oCamposDet.FECHA = dr["FECHA"].ToString();
                                oCamposDet.ORGANIZADOR = dr.GetString(p5);
                                oCamposDet.PUBLICO_OBJECTIVO = dr.GetString(p6);
                                oCamposDet.N_PARTICIPANTES = dr.GetInt32(p7);
                                oCamposDet.MARCO_CONVENIO = dr.GetString(p8);
                                lsCEntidad.Add(oCamposDet);
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

        public List<CEntidad> datProduccionXEspecialistas(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            CEntidad oCampos = new CEntidad();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spCR_ProduccionEspecialistas", oCEntidad))
                {
                    if (dr != null)
                    {
                        CEntidad oCamposDet;
                        if (dr.HasRows)
                        {
                            int p1 = dr.GetOrdinal("NOMBRE");
                            int p2 = dr.GetOrdinal("META");
                            int p3 = dr.GetOrdinal("ENERO");
                            int p4 = dr.GetOrdinal("FEBRERO");
                            int p5 = dr.GetOrdinal("MARZO");
                            int p6 = dr.GetOrdinal("ABRIL");
                            int p7 = dr.GetOrdinal("MAYO");
                            int p8 = dr.GetOrdinal("JUNIO");
                            int p9 = dr.GetOrdinal("JULIO");
                            int p10 = dr.GetOrdinal("AGOSTO");
                            int p11 = dr.GetOrdinal("SEPTIEMBRE");
                            int p12 = dr.GetOrdinal("OCTUBRE");
                            int p13 = dr.GetOrdinal("NOVIEMBRE");
                            int p14 = dr.GetOrdinal("DICIEMBRE");

                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.NOMBRES = dr.GetString(p1);
                                oCamposDet.META = dr.GetInt32(p2);
                                oCamposDet.enero = dr.GetInt32(p3);
                                oCamposDet.febrero = dr.GetInt32(p4);
                                oCamposDet.marzo = dr.GetInt32(p5);
                                oCamposDet.abril = dr.GetInt32(p6);
                                oCamposDet.mayo = dr.GetInt32(p7);
                                oCamposDet.junio = dr.GetInt32(p8);
                                oCamposDet.julio = dr.GetInt32(p9);
                                oCamposDet.agosto = dr.GetInt32(p10);
                                oCamposDet.septiembre = dr.GetInt32(p11);
                                oCamposDet.octubre = dr.GetInt32(p12);
                                oCamposDet.noviembre = dr.GetInt32(p13);
                                oCamposDet.diciembre = dr.GetInt32(p14);
                                oCamposDet.TOTAL = oCamposDet.enero + oCamposDet.febrero + oCamposDet.marzo + oCamposDet.abril + oCamposDet.mayo + oCamposDet.junio + oCamposDet.julio + oCamposDet.agosto + oCamposDet.septiembre + oCamposDet.octubre + oCamposDet.noviembre + oCamposDet.diciembre;
                                oCamposDet.eneroAV = (oCamposDet.enero * 100) / oCamposDet.META;
                                oCamposDet.febreroAV = (oCamposDet.febrero * 100) / oCamposDet.META;
                                oCamposDet.marzoAV = (oCamposDet.marzo * 100) / oCamposDet.META;
                                oCamposDet.abrilAV = (oCamposDet.abril * 100) / oCamposDet.META;
                                oCamposDet.mayoAV = (oCamposDet.mayo * 100) / oCamposDet.META;
                                oCamposDet.junioAV = (oCamposDet.junio * 100) / oCamposDet.META;
                                oCamposDet.julioAV = (oCamposDet.julio * 100) / oCamposDet.META;
                                oCamposDet.agostoAV = (oCamposDet.agosto * 100) / oCamposDet.META;
                                oCamposDet.septiembreAV = (oCamposDet.septiembre * 100) / oCamposDet.META;
                                oCamposDet.octubreAV = (oCamposDet.octubre * 100) / oCamposDet.META;
                                oCamposDet.noviembreAV = (oCamposDet.noviembre * 100) / oCamposDet.META;
                                oCamposDet.diciembreAV = (oCamposDet.diciembre * 100) / oCamposDet.META;
                                lsCEntidad.Add(oCamposDet);
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
    }
}
