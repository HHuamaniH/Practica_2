using System;
using System.Collections.Generic;
//using System.Data.SqlClient;
using CEntidad = CapaEntidad.DOC.Ent_REPORTE_SUPERVISION_GENERAL;
using GeneralSQL;
using Oracle.ManagedDataAccess.Client;
//using SQL = GeneralSQL.Data.SQL;


namespace CapaDatos.DOC
{


    /// <summary>
    /// 
    /// </summary>
    public class Dat_SUPERVISION_GENERAL
    {
        //private SQL oGDataSQL = new SQL();
        private DBOracle dBOracle = new DBOracle();
        //LISTADO DE SUPERVISORES        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        //public CEntidad RegMostrarSUPERVISOR_SUPERVISION(SqlConnection cn, CEntidad oCEntidad)
        //{
        //    CEntidad lsCEntidad = new CEntidad();
        //    CEntidad oCampos;
        //    try
        //    {
        //        using (SqlDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC.new_REPORTE_SupervisorxSupervicionyPromedio", oCEntidad))
        //        {
        //            lsCEntidad.ListISupervision_Modalidades = new List<CEntidad>();
        //            lsCEntidad.ListTiempoModalidad = new List<CEntidad>();

        //            if (dr != null)
        //            {
        //                if (dr.HasRows)
        //                {
        //                    while (dr.Read())
        //                    {
        //                        oCampos = new CEntidad();
        //                        oCampos.CODIGO = dr["CODIGO"].ToString();
        //                        oCampos.DESCRIPCION = dr["SUPERVISOR"].ToString();
        //                        oCampos.CANT_ZOOL = Decimal.Parse(dr["Zoologicos"].ToString());
        //                        oCampos.CANT_ZOOC = Decimal.Parse(dr["Zoocriaderos"].ToString());
        //                        oCampos.CANT_CRES = Decimal.Parse(dr["CentrosdeRescate"].ToString());
        //                        oCampos.CANT_CCT = Decimal.Parse(dr["CentrosdeCustodiaTemporal"].ToString());
        //                        oCampos.CANT_TARA = Decimal.Parse(dr["Tara"].ToString());
        //                        oCampos.CANT_BS = Decimal.Parse(dr["BosquesSecos"].ToString());
        //                        oCampos.CANT_CMADE = Decimal.Parse(dr["Maderables"].ToString());
        //                        oCampos.CANT_NMCAST = Decimal.Parse(dr["NoMaderablesCastana"].ToString());
        //                        oCampos.CANT_NMSHIR = Decimal.Parse(dr["NoMaderablesShiringa"].ToString());
        //                        oCampos.CANT_FYR = Decimal.Parse(dr["ForestacionReforestacion"].ToString());
        //                        oCampos.CANT_ECO = Decimal.Parse(dr["Ecoturismo"].ToString());
        //                        oCampos.CANT_CONS = Decimal.Parse(dr["Conservacion"].ToString());
        //                        oCampos.CANT_CFAUNA = Decimal.Parse(dr["FaunaSilvestre"].ToString());
        //                        oCampos.CANT_PP = Decimal.Parse(dr["PredioPrivado"].ToString());
        //                        oCampos.CANT_CCNN = Decimal.Parse(dr["ComunidadNativa"].ToString());
        //                        oCampos.CANT_CCCC = Decimal.Parse(dr["ComunidadCampesina"].ToString());
        //                        oCampos.CANT_BL = Decimal.Parse(dr["ContratosdeAdministracióndeBosquesLocales"].ToString());
        //                        oCampos.CANT_NMAGU = Decimal.Parse(dr["NoMaderablesAguaje"].ToString());
        //                        oCampos.CANT_SISAG = Decimal.Parse(dr["SistemasAgroforestales"].ToString());
        //                        oCampos.TOTALDOUBLE = Double.Parse(dr["TOTAL"].ToString());
        //                        lsCEntidad.ListISupervision_Modalidades.Add(oCampos);
        //                    }
        //                }
        //                dr.NextResult();
        //                if (dr.HasRows)
        //                {
        //                    int p1 = dr.GetOrdinal("MODALIDAD");
        //                    int p2 = dr.GetOrdinal("DIAS");

        //                    while (dr.Read())
        //                    {
        //                        oCampos = new CEntidad();
        //                        oCampos.MODALIDAD = dr.GetString(p1);
        //                        oCampos.TOTAL = dr.GetInt32(p2);

        //                        lsCEntidad.ListTiempoModalidad.Add(oCampos);
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

        public CEntidad RegMostrarListSupervisionXsupervisorResumen(OracleConnection cn, CEntidad oCEntidad)
        {
            CEntidad lsCEntidad = new CEntidad();
            CEntidad oCampos;
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spReporte_SupervisionesXsupervisor", oCEntidad))
                {
                    lsCEntidad.ListSupervisionSupervisorXmodalidad = new List<CEntidad>();
                    lsCEntidad.ListSupervisionXsupervisor = new List<CEntidad>();
                    lsCEntidad.ListSupervisionXmodalidad = new List<CEntidad>();

                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                oCampos.COD_SUPERVISOR = dr["COD_SUPERVISOR"].ToString();
                                oCampos.SUPERVISOR = dr["SUPERVISOR"].ToString();
                                oCampos.CANT_ZOOL = Decimal.Parse(dr["Zoologicos"].ToString());
                                oCampos.CANT_ZOOC = Decimal.Parse(dr["Zoocriaderos"].ToString());
                                oCampos.CANT_CRES = Decimal.Parse(dr["CentrosdeRescate"].ToString());
                                oCampos.CANT_CCT = Decimal.Parse(dr["CentrosdeCustodiaTemporal"].ToString());
                                oCampos.CANT_TARA = Decimal.Parse(dr["Tara"].ToString());
                                oCampos.CANT_BS = Decimal.Parse(dr["BosquesSecos"].ToString());
                                oCampos.CANT_CMADE = Decimal.Parse(dr["Maderables"].ToString());
                                oCampos.CANT_NMCAST = Decimal.Parse(dr["NoMaderablesCastana"].ToString());
                                oCampos.CANT_NMSHIR = Decimal.Parse(dr["NoMaderablesShiringa"].ToString());
                                oCampos.CANT_FYR = Decimal.Parse(dr["ForestacionReforestacion"].ToString());
                                oCampos.CANT_ECO = Decimal.Parse(dr["Ecoturismo"].ToString());
                                oCampos.CANT_CONS = Decimal.Parse(dr["Conservacion"].ToString());
                                oCampos.CANT_CFAUNA = Decimal.Parse(dr["FaunaSilvestre"].ToString());
                                oCampos.CANT_PP = Decimal.Parse(dr["PredioPrivado"].ToString());
                                oCampos.CANT_CCNN = Decimal.Parse(dr["ComunidadNativa"].ToString());
                                oCampos.CANT_CCCC = Decimal.Parse(dr["ComunidadCampesina"].ToString());
                                oCampos.CANT_BL = Decimal.Parse(dr["ContratosdeAdministracióndeBosquesLocales"].ToString());
                                oCampos.CANT_NMAGU = Decimal.Parse(dr["NoMaderablesAguaje"].ToString());
                                oCampos.CANT_SISAG = Decimal.Parse(dr["SistemasAgroforestales"].ToString());
                                oCampos.TOTALDOUBLE = Double.Parse(dr["TOTAL"].ToString());
                                lsCEntidad.ListSupervisionSupervisorXmodalidad.Add(oCampos);
                            }
                        }
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                oCampos.COD_SUPERVISOR = dr["COD_SUPERVISOR"].ToString();
                                oCampos.SUPERVISOR = dr["SUPERVISOR"].ToString();
                                oCampos.TOTALDOUBLE = Double.Parse(dr["TOTAL"].ToString());
                                lsCEntidad.ListSupervisionXsupervisor.Add(oCampos);
                            }
                        }
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                oCampos.COD_MTIPO = dr["COD_MTIPO"].ToString();
                                oCampos.MODALIDAD = dr["MODALIDAD"].ToString();
                                oCampos.TOTALDOUBLE = Double.Parse(dr["TOTAL"].ToString());
                                lsCEntidad.ListSupervisionXmodalidad.Add(oCampos);
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
        public List<CEntidad> RegMostrarListSupervisionXsupervisorDetalle(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            CEntidad oCampos;
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spReporte_SupervisionesXsupervisor", oCEntidad))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                oCampos.NUM_THABILITANTE = dr["NUM_THABILITANTE"].ToString();
                                oCampos.TITULAR = dr["TITULAR"].ToString();
                                oCampos.MODALIDAD = dr["MODALIDAD"].ToString();
                                oCampos.DEPARTAMENTO = dr["DEPARTAMENTO"].ToString();
                                oCampos.SUPERVISOR = dr["SUPERVISOR"].ToString();
                                oCampos.FECHA_INICIO = dr["FECHA_INICIO"].ToString();
                                oCampos.FECHA_FIN = dr["FECHA_FIN"].ToString();
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
        /// 
        //supervision general por linea DatInformeSupervisionLinea
        public List<CEntidad> DatInformeSupervisionLinea(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();

            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.new_REPORTE_SupervicionLinea_v2", oCEntidad))
                {


                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            CEntidad oCampos;
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                oCampos.NUMERO_DOCUMENTO = dr.GetString(dr.GetOrdinal("numero"));
                                oCampos.APELLIDOS_NOMBRES = dr.GetString(dr.GetOrdinal("supervisor"));
                                oCampos.TITULAR = dr.GetString(dr.GetOrdinal("titular"));
                                oCampos.NUM_THABILITANTE = dr.GetString(dr.GetOrdinal("titulo"));
                                oCampos.MODALIDAD = dr.GetString(dr.GetOrdinal("modalidad"));
                                oCampos.DEPARTAMENTO = dr.GetString(dr.GetOrdinal("departamento"));
                                oCampos.DESCRIPCION = dr.GetString(dr.GetOrdinal("descripcion"));
                                oCampos.TOTAL = dr.GetInt32(dr.GetOrdinal("muestra"));
                                oCampos.TOTALCONCESION = dr.GetInt32(dr.GetOrdinal("campos"));
                                oCampos.FECHA = dr.GetString(dr.GetOrdinal("fecha"));
                                oCampos.FIC_SIADO = dr.GetString(dr.GetOrdinal("FIC_SIADO"));
                                oCampos.ANIO = dr.GetInt32(dr.GetOrdinal("ANIO"));
                                oCampos.PROVINCIA = dr.GetString(dr.GetOrdinal("PROVINCIA"));
                                oCampos.DISTRITO = dr.GetString(dr.GetOrdinal("DISTRITO"));
                                oCampos.AREA_TH = dr.GetDecimal(dr.GetOrdinal("AREA_TH"));
                                oCampos.AREA_POA = dr.GetDecimal(dr.GetOrdinal("AREA_POA"));
                                oCampos.POAS = dr.GetString(dr.GetOrdinal("POAS"));
                                oCampos.POAS_RD = dr.GetString(dr.GetOrdinal("POAS_RD"));
                                oCampos.PUBLICAR_TEXT = dr.GetString(dr.GetOrdinal("PUBLICAR_TEXT"));
                                //Nuevas columnas
                                oCampos.OD_AMBITO = dr.GetString(dr.GetOrdinal("OD_AMBITO"));
                                oCampos.TIPO_INFORME = dr.GetString(dr.GetOrdinal("TIPO_INFORME"));
                                oCampos.VOLUMEN_JUSTIFICADO = dr.GetDecimal(dr.GetOrdinal("VOLUMEN_JUSTIFICADO"));
                                oCampos.VOLUMEN_INJUSTIFICADO = dr.GetDecimal(dr.GetOrdinal("VOLUMEN_INJUSTIFICADO"));
                                oCampos.TOTAL_INEXISTENTE = dr.GetInt32(dr.GetOrdinal("INEXISTENTE"));
                                oCampos.OPORTUNIDAD = dr.GetString(dr.GetOrdinal("OPORTUNIDAD"));
                                oCampos.MOTIVO = dr.GetString(dr.GetOrdinal("MOTIVO"));

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
        /// suspension devuelve las suspenciones por linea segun filtro
        /// </summary>
        /// <param name="cn"> conexion al servidor de base de datos</param>
        /// <param name="oCEntidad">el objeto para la busqueda en el procedimiento</param>
        /// <returns>lista de objetos del procedimiento en este caso lista de suspenciones por linea de direccion</returns>
        public List<CEntidad> DatInformeSuspensionLinea(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();

            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.new_REPORTE_SuspencionLinea", oCEntidad))
                {


                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {

                            int p1 = dr.GetOrdinal("numero");
                            int p2 = dr.GetOrdinal("supervisor");
                            int p3 = dr.GetOrdinal("titular");
                            int p4 = dr.GetOrdinal("titulo");
                            int p5 = dr.GetOrdinal("modalidad");
                            int p6 = dr.GetOrdinal("departamento");
                            int p7 = dr.GetOrdinal("descripcion");
                            int p8 = dr.GetOrdinal("motivo");
                            CEntidad oCampos;
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                oCampos.NUMERO_DOCUMENTO = dr.GetString(p1);
                                oCampos.APELLIDOS_NOMBRES = dr.GetString(p2);
                                oCampos.TITULAR = dr.GetString(p3);
                                oCampos.NUM_THABILITANTE = dr.GetString(p4);
                                oCampos.MODALIDAD = dr.GetString(p5);
                                oCampos.DEPARTAMENTO = dr.GetString(p6);
                                oCampos.DESCRIPCION = dr.GetString(p7);
                                oCampos.MOTIVO = dr.GetString(p8);
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
        public CEntidad RegMostrarACTIVIDAD_SIL(OracleConnection cn, CEntidad oCEntidad)
        {
            CEntidad lsCEntidad = new CEntidad();
            CEntidad oCampos;
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.new_REPORTE_ActividadesSilviculturales", oCEntidad))
                {
                    lsCEntidad.ListISupervision_Modalidades = new List<CEntidad>();
                    lsCEntidad.ListTiempoModalidad = new List<CEntidad>();

                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {

                            int p0 = dr.GetOrdinal("REGION");
                            int p1 = dr.GetOrdinal("SICORTE_LIANA");
                            int p2 = dr.GetOrdinal("NOCORTE_LIANA");
                            int p3 = dr.GetOrdinal("SIENRIQUECIEMINTO_BOSTE");
                            int p4 = dr.GetOrdinal("NOENRIQUECIEMINTO_BOSTE");
                            int p5 = dr.GetOrdinal("SIMANEJO_REGENERACION_NATURA");
                            int p6 = dr.GetOrdinal("NOMANEJO_REGENERACION_NATURAL");
                            int p7 = dr.GetOrdinal("SIMANEJO_VIVEROS");
                            int p8 = dr.GetOrdinal("NOMANEJO_VIVEROS");
                            int p9 = dr.GetOrdinal("SIPROTECCION_SEMILLEROS");
                            int p10 = dr.GetOrdinal("NOPROTECCION_SEMILLEROS");
                            int p11 = dr.GetOrdinal("SIRALEO_PODA");
                            int p12 = dr.GetOrdinal("NORALEO_PODA");
                            int p13 = dr.GetOrdinal("SIESTABLECIMIENTO_REPOSICION");
                            int p14 = dr.GetOrdinal("NOESTABLECIMIENTO_REPOSICION");
                            int p15 = dr.GetOrdinal("SIOTROS");
                            int p16 = dr.GetOrdinal("NOOTROS");
                            int p17 = dr.GetOrdinal("SI_TOTAL");
                            int p18 = dr.GetOrdinal("NO_TOTAL");

                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                oCampos.DEPARTAMENTO = dr.GetString(p0);
                                oCampos.CANT_CMADE = dr.GetInt32(p1);
                                oCampos.CANT_NMCAST = dr.GetInt32(p2);
                                oCampos.CANT_FYR = dr.GetInt32(p3);
                                oCampos.CANT_ECO = dr.GetInt32(p4);
                                oCampos.CANT_CONS = dr.GetInt32(p5);
                                oCampos.CANT_CFAUNA = dr.GetInt32(p6);
                                oCampos.CANT_BL = dr.GetInt32(p7);
                                oCampos.CANT_CCNN = dr.GetInt32(p8);
                                oCampos.CANT_CCCC = dr.GetInt32(p9);
                                oCampos.CANT_CRES = dr.GetInt32(10);
                                oCampos.CANT_CCT = dr.GetInt32(11);
                                oCampos.CANT_BS = dr.GetInt32(12);
                                oCampos.CANT_NMSHIR = dr.GetInt32(13);
                                oCampos.CANT_PP = dr.GetInt32(14);
                                oCampos.CANT_TARA = dr.GetInt32(15);
                                oCampos.CANT_ZOOC = dr.GetInt32(16);
                                oCampos.TOTAL = dr.GetInt32(17);
                                oCampos.TOTALCONCESION = dr.GetInt32(18);

                                lsCEntidad.ListISupervision_Modalidades.Add(oCampos);
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
        public CEntidad RegMostrarPROGRAMADO_SUPER(OracleConnection cn, CEntidad oCEntidad)
        {
            CEntidad lsCEntidad = new CEntidad();
            CEntidad oCampos;
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.new_REPORTE_ArbolesProgramadosMuestra", oCEntidad))
                {
                    lsCEntidad.ListISupervision_Modalidades = new List<CEntidad>();
                    lsCEntidad.ListTiempoModalidad = new List<CEntidad>();

                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            if (oCEntidad.BusCriterio == "1")
                            {

                                int p1 = dr.GetOrdinal("Bosques Secos");
                                int p2 = dr.GetOrdinal("Maderables");
                                int p3 = dr.GetOrdinal("No Maderables Castana");
                                int p4 = dr.GetOrdinal("ForestacionReforestacion");
                                int p5 = dr.GetOrdinal("Predio Privado");
                                int p6 = dr.GetOrdinal("Comunidad Nativa");
                                int p7 = dr.GetOrdinal("Comunidad Campesina");
                                int p8 = dr.GetOrdinal("Contratos de Administracion de Bosques Locales");
                                int p9 = dr.GetOrdinal("ANIO");

                                while (dr.Read())
                                {

                                    oCampos = new CEntidad();
                                    oCampos.CANT_BS = dr.GetDecimal(p1);
                                    oCampos.CANT_CMADE = dr.GetDecimal(p2);
                                    oCampos.CANT_NMCAST = dr.GetDecimal(p3);
                                    oCampos.CANT_FYR = dr.GetDecimal(p4);
                                    oCampos.CANT_PP = dr.GetDecimal(p5);
                                    oCampos.CANT_CCNN = dr.GetDecimal(p6);
                                    oCampos.CANT_CCCC = dr.GetDecimal(p7);
                                    oCampos.CANT_BL = dr.GetDecimal(p8);
                                    oCampos.ANIO = dr.GetInt32(p9);
                                    lsCEntidad.ListISupervision_Modalidades.Add(oCampos);
                                }
                            }
                            else
                            {
                                int p1 = dr.GetOrdinal("NOMBRE_CIENTIFICO");
                                int p2 = dr.GetOrdinal("Arboles_numero");
                                int p3 = dr.GetOrdinal("Arboles_programados");
                                int p4 = dr.GetOrdinal("Arboles_supervisados");
                                int p5 = dr.GetOrdinal("Muestra");

                                while (dr.Read())
                                {

                                    oCampos = new CEntidad();
                                    oCampos.DESCRIPCION = dr.GetString(p1);
                                    oCampos.TOTAL = dr.GetInt32(p2);
                                    oCampos.TOTALCONCESION = dr.GetInt32(p3);
                                    oCampos.ArbolesSupervisados = dr.GetInt32(p4);
                                    oCampos.CATEGORIA = dr.GetInt32(p5);

                                    lsCEntidad.ListTiempoModalidad.Add(oCampos);
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
        }        /// <summary>

        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public List<CEntidad> MostrarSupervisionXAnio(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC_OSINFOR_ERP_MIGRACION.new_REPORTE_TotalSupervicionesXDepartament", oCEntidad))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            int p1 = dr.GetOrdinal("DEPARTAMENTO");
                            int p2 = dr.GetOrdinal("2006");
                            int p3 = dr.GetOrdinal("2007");
                            int p4 = dr.GetOrdinal("2008");
                            int p5 = dr.GetOrdinal("2009");
                            int p6 = dr.GetOrdinal("2010");
                            int p7 = dr.GetOrdinal("2011");
                            int p8 = dr.GetOrdinal("2012");
                            int p9 = dr.GetOrdinal("2013");
                            int p10 = dr.GetOrdinal("2014");
                            int p11 = dr.GetOrdinal("2015");
                            int p12 = dr.GetOrdinal("TOTAL");

                            CEntidad oCampos;
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                oCampos.DEPARTAMENTO = dr.GetString(p1);
                                oCampos.TOTALDOUBLE = dr.GetInt32(p2);
                                oCampos.TOTALCONCESION = dr.GetInt32(p3);
                                oCampos.CATEGORIA = dr.GetInt32(p4);
                                oCampos.DOSMILNUEVE = dr.GetInt32(p5);
                                oCampos.DOSMILDIEZ = dr.GetInt32(p6);
                                oCampos.DOSMILONCE = dr.GetInt32(p7);
                                oCampos.DOSMILDOCE = dr.GetInt32(p8);
                                oCampos.DOSMILTRECE = dr.GetInt32(p9);
                                oCampos.DOSMILCATORCE = dr.GetInt32(p10);
                                oCampos.DOSMILQUINCE = dr.GetInt32(p11);
                                oCampos.TOTAL = dr.GetInt32(p12);

                                lsCEntidad.Add(oCampos);
                            }
                        }
                    }
                }
                return lsCEntidad;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        //public List<CEntidad> MostrarSupervision_General(SqlConnection cn, CEntidad oCEntidad)
        //{
        //    List<CEntidad> lsCEntidad = new List<CEntidad>();
        //    try
        //    {
        //        using (SqlDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC.new_SUPERVISIONES_GENERAL", oCEntidad))
        //        {
        //            if (dr != null)
        //            {
        //                if (dr.HasRows)
        //                {

        //                    int p1 = dr.GetOrdinal("AÑO");
        //                    int p2 = dr.GetOrdinal("CONCESIONES");
        //                    int p3 = dr.GetOrdinal("PERMISO");
        //                    int p4 = dr.GetOrdinal("TOTAL");

        //                    CEntidad oCampos;
        //                    while (dr.Read())
        //                    {
        //                        oCampos = new CEntidad();
        //                        oCampos.ANIO = dr.GetInt32(p1);
        //                        oCampos.CONCESIONES = dr.GetInt32(p2);
        //                        oCampos.PERMISO = dr.GetInt32(p3);
        //                        oCampos.TOTAL = dr.GetInt32(p4);

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
        public CEntidad MostrarHistorial(OracleConnection cn, CEntidad oCEntidad)
        {
            CEntidad oCampos = null;
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.new_ReporteSupervisorxSupervision_detalle", oCEntidad))
                {
                    if (dr != null)
                    {
                        oCampos = new CEntidad();
                        List<CEntidad> lsDetDetalles;

                        CEntidad oCamposDetalle;
                        //Tipor de Modalidad
                        lsDetDetalles = new List<CEntidad>();
                        if (dr.HasRows)
                        {
                            int ptp1 = dr.GetOrdinal("TITULAR");
                            int ptp2 = dr.GetOrdinal("THABILITANTE");
                            int ptp4 = dr.GetOrdinal("MODALIDAD");
                            int ptp5 = dr.GetOrdinal("INFORME");
                            int ptp6 = dr.GetOrdinal("ANIO");
                            while (dr.Read())
                            {
                                oCamposDetalle = new CEntidad();
                                oCamposDetalle.TITULAR = dr.GetString(ptp1);
                                oCamposDetalle.NUM_THABILITANTE = dr.GetString(ptp2);
                                oCamposDetalle.MODALIDAD = dr.GetString(ptp4);
                                oCamposDetalle.NUMERO_DOCUMENTO = dr.GetString(ptp5);
                                oCamposDetalle.ANIO = dr.GetInt32(ptp6);
                                lsDetDetalles.Add(oCamposDetalle);
                            }
                        }
                        oCampos.ListDetalleSupervisor = lsDetDetalles;

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
        /// <returns></returns>
        //public CEntidad RegMostComboNoFauna(SqlConnection cn)
        //{
        //    CEntidad oCampos = null;
        //    try
        //    {
        //        using (SqlDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC.new_REPORTE_ModalidadesNoFuna", null))
        //        {
        //            if (dr != null)
        //            {
        //                oCampos = new CEntidad();
        //                List<CEntidad> lsDetDetalles;
        //                CEntidad oCamposDet;

        //                //Tipor de Modalidad
        //                lsDetDetalles = new List<CEntidad>();
        //                if (dr.HasRows)
        //                {
        //                    int pt1 = dr.GetOrdinal("CODIGO");
        //                    int pt2 = dr.GetOrdinal("DESCRIPCION");
        //                    while (dr.Read())
        //                    {
        //                        oCamposDet = new CEntidad();
        //                        oCamposDet.CODIGO = dr.GetString(pt1);
        //                        oCamposDet.DESCRIPCION = dr.GetString(pt2);
        //                        lsDetDetalles.Add(oCamposDet);
        //                    }
        //                }
        //                oCampos.ListISupervision_Modalidades = lsDetDetalles;

        //                dr.NextResult();

        //                lsDetDetalles = new List<CEntidad>();
        //                if (dr.HasRows)
        //                {
        //                    int pt1 = dr.GetOrdinal("CODIGO");
        //                    int pt2 = dr.GetOrdinal("DESCRIPCION");
        //                    while (dr.Read())
        //                    {
        //                        oCamposDet = new CEntidad();
        //                        oCamposDet.CODIGO = dr.GetString(pt1);
        //                        oCamposDet.DESCRIPCION = dr.GetString(pt2);
        //                        lsDetDetalles.Add(oCamposDet);

        //                    }
        //                }
        //                oCampos.ListRegiones = lsDetDetalles;
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
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public List<CEntidad> DatMostrarZafraSupervisado(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC_OSINFOR_ERP_MIGRACION.new_REPORTE_ZafraSupervisada", oCEntidad))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            int p1 = dr.GetOrdinal("ZAFRA_PCA");
                            int p2 = dr.GetOrdinal("2009");
                            int p3 = dr.GetOrdinal("2010");
                            int p4 = dr.GetOrdinal("2011");
                            int p5 = dr.GetOrdinal("2012");
                            int p6 = dr.GetOrdinal("2013");
                            int p7 = dr.GetOrdinal("2014");
                            int p8 = dr.GetOrdinal("TOTAL");
                            CEntidad oCampos;
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                oCampos.ZAFRA_PCA = dr.GetString(p1);
                                oCampos.DOSMILNUEVE = dr.GetInt32(p2);
                                oCampos.DOSMILDIEZ = dr.GetInt32(p3);
                                oCampos.DOSMILONCE = dr.GetInt32(p4);
                                oCampos.DOSMILDOCE = dr.GetInt32(p5);
                                oCampos.DOSMILTRECE = dr.GetInt32(p6);
                                oCampos.DOSMILCATORCE = dr.GetInt32(p7);
                                oCampos.TOTAL = dr.GetInt32(p8);
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
        public List<CEntidad> DatDetalleZafraSupervisado(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC_OSINFOR_ERP_MIGRACION.new_REPORTE_ZafraSupervisada", oCEntidad))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            int p1 = dr.GetOrdinal("NUMERO");
                            int p2 = dr.GetOrdinal("INTERVENCION");
                            int p3 = dr.GetOrdinal("INFORME");
                            CEntidad oCampos;
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                oCampos.NUM_THABILITANTE = dr.GetString(p1);
                                oCampos.DESCRIPCION = dr.GetString(p2);
                                oCampos.NUMERO_DOCUMENTO = dr.GetString(p3); //IS
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
        public List<CEntidad> DatArbolesAdicionales(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC_OSINFOR_ERP_MIGRACION.new_REPORTE_ArbolesAdicionalesSupervisados", oCEntidad))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            int p1 = dr.GetOrdinal("ESPECIE");
                            int p2 = dr.GetOrdinal("N_ARBOL");
                            int p3 = dr.GetOrdinal("DESCRIPCION");
                            int p4 = dr.GetOrdinal("COD_EESTADO");
                            int p5 = dr.GetOrdinal("COD_ESPECIES");
                            CEntidad oCampos;
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                oCampos.BusEspecie = dr.GetString(p1);
                                oCampos.NUM_ARBOL = dr.GetInt32(p2);
                                oCampos.BusEstado = dr.GetString(p3);
                                oCampos.COD_EESTADO = dr.GetString(p4);
                                oCampos.COD_ESPECIES = dr.GetString(p5);
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
        public List<CEntidad> DatDetArbolesAdicionalesTitulares(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC_OSINFOR_ERP_MIGRACION.new_REPORTE_ArbolesAdicionalesSupervisados", oCEntidad))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            int p1 = dr.GetOrdinal("APELLIDOS_NOMBRES");
                            int p2 = dr.GetOrdinal("NUM_THABILITANTE");
                            int p3 = dr.GetOrdinal("DESCRIPCION");
                            int p4 = dr.GetOrdinal("NUM_INFORME");
                            int p5 = dr.GetOrdinal("CANTIDAD");
                            CEntidad oCampos;
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                oCampos.TITULAR = dr.GetString(p1);
                                oCampos.NUM_THABILITANTE = dr.GetString(p2);
                                oCampos.BusModalidad = dr.GetString(p3);
                                oCampos.INFORME = dr.GetString(p4);
                                oCampos.NUM_ARBOL = dr.GetInt32(p5);
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
        public List<CEntidad> Dat_MostrarCategoriaDiametrica(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC_OSINFOR_ERP_MIGRACION.new_REPORTE_DAP", oCEntidad))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            int p1 = dr.GetOrdinal("RANGO");
                            int p2 = dr.GetOrdinal("CANTIDAD");


                            CEntidad oCampos;
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                oCampos.RANGO = dr.GetString(p1);
                                oCampos.DAP = dr.GetInt32(p2);
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

        //Supervision total
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public List<CEntidad> DatSupTotal(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC_OSINFOR_ERP_MIGRACION.new_REPORTE_Supervision_Total", oCEntidad))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            int p1 = dr.GetOrdinal("ANIO");
                            int p2 = dr.GetOrdinal("N_SUPERVISIONES");
                            int p3 = dr.GetOrdinal("AREA_POA_SUP");
                            int p4 = dr.GetOrdinal("AREA_TH_SUP");
                            CEntidad oCampos;
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                oCampos.Anios = dr.GetInt32(p1);
                                oCampos.N_Supervisiones = dr.GetInt32(p2);
                                oCampos.AREA_POA = dr.GetDecimal(p3);
                                oCampos.AREA_TH = dr.GetDecimal(p4);
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
        public List<CEntidad> DatSupTotalAnio(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spSupervisionXAnio", oCEntidad))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            int p1 = dr.GetOrdinal("ANIO");
                            int p2 = dr.GetOrdinal("N_SUPERVISION");
                            CEntidad oCampos;
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                oCampos.Anios = dr.GetInt32(p1);
                                oCampos.N_Supervisiones = dr.GetInt32(p2);
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
        public List<CEntidad> dat_SupervisionArboles(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spReporteSupervArboles", oCEntidad))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            int p1 = dr.GetOrdinal("Anio");
                            int p2 = dr.GetOrdinal("DEPARTAMENTO");
                            int p3 = dr.GetOrdinal("Arboles");
                            CEntidad oCampos;
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                oCampos.ANIO = dr.GetInt32(p1);
                                oCampos.DEPARTAMENTO = dr.GetString(p2);
                                oCampos.NUM_ARBOL = dr.GetInt32(p3);
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
        public List<CEntidad> dat_SupervisionArboleAnio(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spReporteSupervArbolesAnio", oCEntidad))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            int p1 = dr.GetOrdinal("Anio");
                            int p3 = dr.GetOrdinal("Arboles");
                            CEntidad oCampos;
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                oCampos.ANIO = dr.GetInt32(p1);
                                oCampos.NUM_ARBOL = dr.GetInt32(p3);
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
        public List<CEntidad> dat_ResumenTH(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spzTitularResumen", oCEntidad))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {

                            CEntidad oCampos;
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                oCampos.INFORME = dr["INFORME"].ToString();
                                oCampos.FECHA_INFORME = dr["FECHA_INFORME"].ToString();
                                oCampos.TITULAR = dr["TITULAR"].ToString();
                                oCampos.DOCUMENTO_TITULAR = dr["DOCUMENTO_TITULAR"].ToString();
                                oCampos.RUC_TITULAR = dr["RUC_TITULAR"].ToString();
                                oCampos.TIPO_PERSONA_TITULAR = dr["TIPO_PERSONA_TITULAR"].ToString();
                                oCampos.DIRECCION_TITULAR = dr["DIRECCION_TITULAR"].ToString();
                                oCampos.D_LINEA = dr["D_LINEA"].ToString();
                                oCampos.COD_UBIGEO = dr["COD_UBIGEO"].ToString();
                                oCampos.DEPARTAMENTO = dr["DEPARTAMENTO"].ToString();
                                oCampos.PROVINCIA = dr["PROVINCIA"].ToString();
                                oCampos.DISTRITO = dr["DISTRITO"].ToString();
                                oCampos.R_LEGAL = dr["REPRESENTANTE_LEGAL"].ToString();
                                oCampos.DOCUMENTO_RLEGAL = dr["DNI_LEGAL"].ToString();
                                oCampos.NUM_THABILITANTE = dr["TITULO"].ToString();
                                oCampos.MODALIDAD = dr["MODALIDAD"].ToString();
                                oCampos.SECTOR = dr["SECTOR"].ToString();
                                oCampos.UBICACION = dr["UBIGEO"].ToString();
                                oCampos.N_POA = dr["N_POA"].ToString();
                                oCampos.ARCHIVO_PRELIMINAR = dr["ARCH"].ToString();
                                oCampos.RD_INICIO = dr["RD_INICIO"].ToString();
                                oCampos.RD_TERMINO = dr["RD_TERMINO"].ToString();
                                oCampos.FECHA_RD_TERMINO = dr["FECHA_RDTERM"].ToString();
                                oCampos.DETER_RD_TERMINO = dr["PAU_FIN_TIPO"].ToString();
                                oCampos.AMONESTACION = dr["AMONESTACION"].ToString();
                                oCampos.MULTA_RDTERMINO = Decimal.Parse(dr["MULTA"].ToString());
                                oCampos.INFRACCIONES = dr["Infracciones"].ToString();
                                oCampos.FECHA_NOTIF_RD_TERMINO = dr["NOTIFICACION_RD_TERMINO"].ToString();

                                oCampos.Recurso_Reconsideracion = dr["RECURSO_RECONSIDERACION"].ToString();
                                oCampos.Fecha_Recurso_Reconsideracion = dr["FECHA_RECONSIDERACION"].ToString();

                                oCampos.RD_Reconsideracion = dr["RD_RECONSIDERACION"].ToString();
                                oCampos.Fecha_RD_Reconsideracion = dr["FECHA_RD_RECONSIDERACION"].ToString();
                                oCampos.DETER_RD_RECON = dr["DETER_RECON"].ToString();
                                oCampos.CAMBIO_MULTA_RDRECON = dr["CAMBIO_MULTA_RDRECON"].ToString();
                                oCampos.MULTA_RDRECON = Decimal.Parse(dr["MULTA_RDRECON"].ToString());
                                oCampos.Fecha_NotificaRDR = dr["NOTIF_RD_RECON"].ToString();

                                oCampos.RD_Rectificacion = dr["RD_RECTIFICACION"].ToString();
                                oCampos.Fecha_RD_Rectificacion = dr["FECHA_RD_RECTIFICACION"].ToString();
                                oCampos.CAMBIO_MULTA_RDRECTIF = dr["CAMBIO_MULTA_RDRECTIF"].ToString();
                                oCampos.MULTA_RDRECTIF = Decimal.Parse(dr["MULTA_RECTIFICACION"].ToString());
                                oCampos.Fecha_NotificaRDRectificacion = dr["NOTIF_RD_RECTIF"].ToString();

                                oCampos.RECURSO_APELA = dr["RECURSO_APELA"].ToString();
                                oCampos.FECHA_RECURSO_APELA = dr["FECHA_RECURSO_APELA"].ToString();

                                oCampos.NUM_RESOLUCION_TFFS = dr["NUM_RESOLUCION_TFFS"].ToString();
                                oCampos.FECHA_TFFS = dr["FECHA_TFFS"].ToString();
                                oCampos.NOM_RECAPE = dr["NOM_RECAPE"].ToString();
                                oCampos.NOM_TIPDET = dr["NOM_TIPDET"].ToString();
                                oCampos.NOM_MOTDET = dr["NOM_MOTDET"].ToString();
                                oCampos.CAMBIO_MULTA_TFFS = dr["CAMBIO_MULTA_TFFS"].ToString();
                                oCampos.MULTA_TFFS = Decimal.Parse(dr["MULTA_TFFS"].ToString());

                                ////////////
                                oCampos.RD_TERMINO_2 = dr["RD_TERMINO_2"].ToString();
                                oCampos.FECHA_RD_TERMINO_2 = dr["FECHA_RDTERM_2"].ToString();
                                oCampos.DETER_RD_TERMINO_2 = dr["PAU_FIN_TIPO_2"].ToString();
                                oCampos.AMONESTACION_2 = dr["AMONESTACION_2"].ToString();
                                oCampos.MULTA_RDTERMINO_2 = Decimal.Parse(dr["MULTA_2"].ToString());
                                oCampos.INFRACCIONES_2 = dr["Infracciones_2"].ToString();
                                oCampos.FECHA_NOTIF_RD_TERMINO_2 = dr["NOTIFICACION_RD_TERMINO_2"].ToString();

                                oCampos.Recurso_Reconsideracion_2 = dr["RECURSO_RECONSIDERACION_2"].ToString();
                                oCampos.Fecha_Recurso_Reconsideracion_2 = dr["FECHA_RECONSIDERACION_2"].ToString();

                                oCampos.RD_Reconsideracion_2 = dr["RD_RECONSIDERACION_2"].ToString();
                                oCampos.Fecha_RD_Reconsideracion_2 = dr["FECHA_RD_RECONSIDERACION_2"].ToString();
                                oCampos.DETER_RD_RECON_2 = dr["DETER_RECON_2"].ToString();
                                oCampos.CAMBIO_MULTA_RDRECON_2 = dr["CAMBIO_MULTA_RDRECON_2"].ToString();
                                oCampos.MULTA_RDRECON_2 = Decimal.Parse(dr["MULTA_RDRECON_2"].ToString());
                                oCampos.Fecha_NotificaRDR_2 = dr["NOTIF_RD_RECON_2"].ToString();

                                oCampos.RD_Rectificacion_2 = dr["RD_RECTIFICACION_2"].ToString();
                                oCampos.Fecha_RD_Rectificacion_2 = dr["FECHA_RD_RECTIFICACION_2"].ToString();
                                oCampos.CAMBIO_MULTA_RDRECTIF_2 = dr["CAMBIO_MULTA_RDRECTIF_2"].ToString();
                                oCampos.MULTA_RDRECTIF_2 = Decimal.Parse(dr["MULTA_RECTIFICACION_2"].ToString());
                                oCampos.Fecha_NotificaRDRectificacion_2 = dr["NOTIF_RD_RECTIF_2"].ToString();

                                oCampos.RECURSO_APELA_2 = dr["RECURSO_APELA_2"].ToString();
                                oCampos.FECHA_RECURSO_APELA_2 = dr["FECHA_RECURSO_APELA_2"].ToString();

                                oCampos.NUM_RESOLUCION_TFFS_2 = dr["NUM_RESOLUCION_TFFS_2"].ToString();
                                oCampos.FECHA_TFFS_2 = dr["FECHA_TFFS_2"].ToString();
                                oCampos.NOM_RECAPE_2 = dr["NOM_RECAPE_2"].ToString();
                                oCampos.NOM_TIPDET_2 = dr["NOM_TIPDET_2"].ToString();
                                oCampos.NOM_MOTDET_2 = dr["NOM_MOTDET_2"].ToString();
                                oCampos.CAMBIO_MULTA_TFFS_2 = dr["CAMBIO_MULTA_TFFS_2"].ToString();
                                oCampos.MULTA_TFFS_2 = Decimal.Parse(dr["MULTA_TFFS_2"].ToString());

                                oCampos.PROVEIDO = dr["PROVEIDO"].ToString();
                                oCampos.FECHA_FIRME = dr["FECHA_FIRME"].ToString();

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
        public List<CEntidad> DatTitulares(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC_OSINFOR_ERP_MIGRACION.new_REPORTE_TitularesconmasSupervisiones", oCEntidad))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("THABILITANTE");
                            int pt2 = dr.GetOrdinal("TITULAR");
                            int pt3 = dr.GetOrdinal("DOSMILNUEVE");
                            int pt4 = dr.GetOrdinal("DOSMILDIEZ");
                            int pt5 = dr.GetOrdinal("DOSMILONCE");
                            int pt6 = dr.GetOrdinal("DOSMILDOCE");
                            int pt7 = dr.GetOrdinal("DOSMILTRECE");
                            int pt8 = dr.GetOrdinal("DOSMILCATORCE");
                            int pt9 = dr.GetOrdinal("DOSMILQUINCE");
                            int pt10 = dr.GetOrdinal("TOTAL");
                            CEntidad oCampos;
                            while (dr.Read())
                            {
                                //PARTE_DIARIO_DETALLE
                                oCampos = new CEntidad();
                                oCampos.NUM_THABILITANTE = dr.GetString(pt1);
                                oCampos.TITULAR = dr.GetString(pt2);
                                oCampos.DOSMILNUEVE = dr.GetInt32(pt3);
                                oCampos.DOSMILDIEZ = dr.GetInt32(pt4);
                                oCampos.DOSMILONCE = dr.GetInt32(pt5);
                                oCampos.DOSMILDOCE = dr.GetInt32(pt6);
                                oCampos.DOSMILTRECE = dr.GetInt32(pt7);
                                oCampos.DOSMILCATORCE = dr.GetInt32(pt8);
                                oCampos.DOSMILQUINCE = dr.GetInt32(pt9);
                                oCampos.TOTAL = dr.GetInt32(pt10);
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
        public CEntidad DatPoasTHabilitante(OracleConnection cn, CEntidad oCEntidad)
        {
            CEntidad oCampos = null;
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.new_REPORTE_TitularesconmasSupervisionesPoas", oCEntidad))
                {
                    if (dr != null)
                    {
                        oCampos = new CEntidad();
                        List<CEntidad> lsDetDetalles;
                        CEntidad oCamposDet;
                        //
                        //pivot 
                        lsDetDetalles = new List<CEntidad>();
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("AREA_OTORGADA");

                            while (dr.Read())
                            {
                                //PARTE_DIARIO_DETALLE
                                oCamposDet = new CEntidad();
                                oCamposDet.AREA_TH = dr.GetDecimal(pt1);
                                lsDetDetalles.Add(oCamposDet);
                            }
                        }
                        oCampos.ListTitularSup = lsDetDetalles;

                        dr.NextResult();

                        lsDetDetalles = new List<CEntidad>();
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("POAs");
                            int pt2 = dr.GetOrdinal("SUPERVISADO");
                            int pt3 = dr.GetOrdinal("INFORME");
                            int pt4 = dr.GetOrdinal("AREA");

                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.POAs = dr.GetString(pt1);
                                oCamposDet.SUPERVISADO = dr.GetBoolean(pt2);
                                oCamposDet.INFORME = dr.GetString(pt3);
                                oCamposDet.AREA_POA = dr.GetDecimal(pt4);
                                lsDetDetalles.Add(oCamposDet);
                            }
                        }
                        oCampos.ListPoasTHabilitante = lsDetDetalles;
                    }
                }
                return oCampos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CEntidad> DatSupTotalAnio2(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spwReport_Superv_superf_Superv", oCEntidad))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            int p1 = dr.GetOrdinal("ANIO");
                            int p2 = dr.GetOrdinal("N_superv");
                            int p3 = dr.GetOrdinal("poa_area");
                            int p4 = dr.GetOrdinal("th_area");

                            CEntidad oCampos;
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                oCampos.Anios = dr.GetInt32(p1);
                                oCampos.N_Supervisiones = dr.GetInt32(p2);
                                //Double area_poa = dr.GetDouble(p3);
                                oCampos.AREA_POA = dr.GetDecimal(p3);
                                oCampos.AREA_TH = dr.GetDecimal(p4);

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
        /// metodo que obtiene la lista de arboles supervisados
        /// fecha: 28/08/2017
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public List<CEntidad> DatReporte_Supervision_Arboles(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spCRArbolesSupervisados", oCEntidad))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            int p1 = dr.GetOrdinal("AÑO_SUP");
                            int p2 = dr.GetOrdinal("MUESTRA");
                            int p3 = dr.GetOrdinal("ADICIONAL");
                            int p4 = dr.GetOrdinal("NO_AUTORIZADO");

                            CEntidad oCampos;
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                oCampos.Anios = dr.GetInt32(p1);
                                oCampos.MUESTRA = dr.GetInt32(p2);
                                oCampos.ADICIONAL = dr.GetInt32(p3);
                                oCampos.NO_AUTORIZADO = dr.GetInt32(p4);
                                oCampos.TOTAL = dr.GetInt32(p2) + dr.GetInt32(p3) + dr.GetInt32(p4);
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
        public CEntidad DatReporte_DispObligaciones(OracleConnection cn, CEntidad oCEntidad)
        {

            CEntidad oCampos = new CEntidad();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spDispObligacionesSupervisados", oCEntidad))
                {
                    if (dr != null)
                    {



                        CEntidad oCamposDet;
                        oCampos.ListObligacionMaderable = new List<CEntidad>();
                        oCampos.ListObligacionNoMaderable = new List<CEntidad>();
                        if (dr.HasRows)
                        {

                            //General
                            int g1 = dr.GetOrdinal("DEPARTAMENTO");
                            int g2 = dr.GetOrdinal("MODALIDAD_TIPO");
                            int g3 = dr.GetOrdinal("NUM_THABILITANTE");
                            int g4 = dr.GetOrdinal("TITULAR");
                            int g5 = dr.GetOrdinal("INFORME");
                            int g6 = dr.GetOrdinal("COD_MTIPO");
                            int g7 = dr.GetOrdinal("FECHA_SUPERVISION_INICIO");
                            int g8 = dr.GetOrdinal("OPORTUNIDAD_SUPERVISION");

                            //Obligaciones maderables
                            int o1 = dr.GetOrdinal("OBLI_PRESENTOPLANMANEJO");
                            int o2 = dr.GetOrdinal("OBLI_PRESENTOPLANMANEJOCONFORMIDAD");
                            int o3 = dr.GetOrdinal("OBLI_PAGOAPROVECHAMIENTO");
                            int o4 = dr.GetOrdinal("OBLI_MANTIENELIBROOPERACIONES");
                            int o5 = dr.GetOrdinal("OBLI_COMUNICOARFFSOSINFORSUSCRIPCION");
                            int o6 = dr.GetOrdinal("OBLI_REPORTOARFFSMINISTERIOAVISTAMIENTOS");
                            int o7 = dr.GetOrdinal("OBLI_REALIZOACCIONESCUSTODIO");
                            int o8 = dr.GetOrdinal("OBLI_FACILITODESARROLLO");
                            int o9 = dr.GetOrdinal("OBLI_ASUMIOCOSTOSUPERVISIONES");
                            int o10 = dr.GetOrdinal("OBLI_IMPLEMENTAMECANISMOTRAZA");
                            int o11 = dr.GetOrdinal("OBLI_RESPETASERVIDUMBRE");
                            int o12 = dr.GetOrdinal("OBLI_CUENTAREGENTE");
                            int o13 = dr.GetOrdinal("OBLI_ADOPTAMEDIDASEXTENSION");
                            int o14 = dr.GetOrdinal("OBLI_RESPETAVALORES");
                            int o15 = dr.GetOrdinal("OBLI_CUMPLEMEDIDAS");
                            int o16 = dr.GetOrdinal("OBLI_CUMPLENORMAS");
                            int o17 = dr.GetOrdinal("OBLI_MOVILIZAFRUTOPRODUCTOS");
                            int o18 = dr.GetOrdinal("OBLI_CUMPLEMARCADOTROZAS");
                            int o19 = dr.GetOrdinal("OBLI_ESTABLECELINDEROS");
                            int o20 = dr.GetOrdinal("OBLI_IMPLEMENTACIONMEDIDASCORRECTIVAS");
                            int o21 = dr.GetOrdinal("OBLI_PROMUEVENBUENASPRACTICAS");
                            int o22 = dr.GetOrdinal("OBLI_PROMUEVEEQUIDAD");
                            int o23 = dr.GetOrdinal("OBLI_MANTIENEVIGENTEGARANTIA");
                            int o24 = dr.GetOrdinal("OBLI_CUMPLECOMPROMISOINVERSION");

                            //Obligaciones no maderables
                            int m1 = dr.GetOrdinal("OBLI_NM_PRESENTOPMF");
                            int m2 = dr.GetOrdinal("OBLI_NM_PRESENTOINFORMEEJECUCION");
                            int m3 = dr.GetOrdinal("OBLI_NM_PAGOAPROVECHAMIENTO");
                            int m4 = dr.GetOrdinal("OBLI_NM_COMUNICOARFFSOSINFORSUSCRIPCION");
                            int m5 = dr.GetOrdinal("OBLI_NM_REPORTOARFFSMINISTERIOAVISTAMIENTOS");

                            int m6 = dr.GetOrdinal("OBLI_NM_REALIZOACCIONESCUSTODIO");
                            int m7 = dr.GetOrdinal("OBLI_NM_FACILITODESARROLLO");
                            int m8 = dr.GetOrdinal("OBLI_NM_ASUMIOCOSTOSUPERVISIONES");
                            int m9 = dr.GetOrdinal("OBLI_NM_IMPLEMENTAMECANISMOTRAZA");
                            int m10 = dr.GetOrdinal("OBLI_NM_RESPETASERVIDUMBRE");

                            int m11 = dr.GetOrdinal("OBLI_NM_ADOPTAMEDIDASEXTENSION");
                            int m12 = dr.GetOrdinal("OBLI_NM_RESPETAVALORES");
                            int m13 = dr.GetOrdinal("OBLI_NM_CUMPLEMEDIDAS");
                            int m14 = dr.GetOrdinal("OBLI_NM_CUMPLENORMAS");
                            int m15 = dr.GetOrdinal("OBLI_NM_MOVILIZAFRUTOPRODUCTOS");

                            int m16 = dr.GetOrdinal("OBLI_NM_IMPLEMENTACIONMEDIDASCORRECTIVAS");
                            int m17 = dr.GetOrdinal("OBLI_NM_IMPMEDCORRECRESULTADOACCIONES");
                            int m18 = dr.GetOrdinal("OBLI_NM_PROMUEVENBUENASPRACTICAS");
                            int m19 = dr.GetOrdinal("OBLI_NM_PROMUEVEEQUIDAD");



                            while (dr.Read())
                            {

                                oCamposDet = new CEntidad();
                                //1
                                oCamposDet.DEPARTAMENTO = dr.GetString(g1);
                                //2
                                oCamposDet.MODALIDAD = dr.GetString(g2);
                                //3
                                oCamposDet.NUM_THABILITANTE = dr.GetString(g3);
                                //4
                                oCamposDet.TITULAR = dr.GetString(g4);
                                //5                             
                                oCamposDet.INFORME = dr.GetString(g5);
                                //6                       
                                oCamposDet.FECHA_INICIO = dr.GetString(g7);
                                //7                             
                                oCamposDet.OPORTUNIDAD = dr.GetString(g8);

                                //MADERABLES
                                if (dr.GetString(g6) == "0000007" || dr.GetString(g6) == "0000010" || dr.GetString(g6) == "0000014" ||
                                    dr.GetString(g6) == "0000015" || dr.GetString(g6) == "0000016" || dr.GetString(g6) == "0000017" || dr.GetString(g6) == "0000006")
                                {
                                    //1
                                    oCamposDet.OBLI_PRESENTOPLANMANEJO = dr.GetString(o1);
                                    //2
                                    oCamposDet.OBLI_PRESENTOPLANMANEJOCONFORMIDAD = dr.GetString(o2);
                                    //3
                                    oCamposDet.OBLI_PAGOAPROVECHAMIENTO = dr.GetString(o3);
                                    //4
                                    oCamposDet.OBLI_MANTIENELIBROOPERACIONES = dr.GetString(o4);
                                    //5
                                    oCamposDet.OBLI_COMUNICOARFFSOSINFORSUSCRIPCION = dr.GetString(o5);
                                    //6
                                    oCamposDet.OBLI_REPORTOARFFSMINISTERIOAVISTAMIENTOS = dr.GetString(o6);
                                    //7
                                    oCamposDet.OBLI_REALIZOACCIONESCUSTODIO = dr.GetString(o7);
                                    //8
                                    oCamposDet.OBLI_FACILITODESARROLLO = dr.GetString(o8);
                                    //9
                                    oCamposDet.OBLI_ASUMIOCOSTOSUPERVISIONES = dr.GetString(o9);
                                    //10
                                    oCamposDet.OBLI_IMPLEMENTAMECANISMOTRAZA = dr.GetString(o10);
                                    //11
                                    oCamposDet.OBLI_RESPETASERVIDUMBRE = dr.GetString(o11);
                                    //12
                                    oCamposDet.OBLI_CUENTAREGENTE = dr.GetString(o12);
                                    //13
                                    oCamposDet.OBLI_ADOPTAMEDIDASEXTENSION = dr.GetString(o13);
                                    //14
                                    oCamposDet.OBLI_RESPETAVALORES = dr.GetString(o14);
                                    //15
                                    oCamposDet.OBLI_CUMPLEMEDIDAS = dr.GetString(o15);
                                    //16
                                    oCamposDet.OBLI_CUMPLENORMAS = dr.GetString(o16);
                                    //17
                                    oCamposDet.OBLI_MOVILIZAFRUTOPRODUCTOS = dr.GetString(o17);
                                    //18
                                    oCamposDet.OBLI_CUMPLEMARCADOTROZAS = dr.GetString(o18);
                                    //19
                                    oCamposDet.OBLI_ESTABLECELINDEROS = dr.GetString(o19);
                                    //20
                                    oCamposDet.OBLI_IMPLEMENTACIONMEDIDASCORRECTIVAS = dr.GetString(o20);
                                    //21
                                    oCamposDet.OBLI_PROMUEVENBUENASPRACTICAS = dr.GetString(o21);
                                    //22
                                    oCamposDet.OBLI_PROMUEVEEQUIDAD = dr.GetString(o22);
                                    //23
                                    oCamposDet.OBLI_MANTIENEVIGENTEGARANTIA = dr.GetString(o23);
                                    //24
                                    oCamposDet.OBLI_CUMPLECOMPROMISOINVERSION = dr.GetString(o24);
                                    oCampos.ListObligacionMaderable.Add(oCamposDet);
                                }
                                //NO MADERABLE
                                if (dr.GetString(g6) == "0000005" || dr.GetString(g6) == "0000008" || dr.GetString(g6) == "0000009" || dr.GetString(g6) == "0000011" ||
                                    dr.GetString(g6) == "0000012" || dr.GetString(g6) == "0000018" || dr.GetString(g6) == "0000020" || dr.GetString(g6) == "0000021" ||
                                    dr.GetString(g6) == "0000022" || dr.GetString(g6) == "0000025" || dr.GetString(g6) == "0000026" || dr.GetString(g6) == "0000027")
                                {
                                    //1
                                    oCamposDet.OBLI_NM_PRESENTOPMF = dr.GetString(m1);
                                    //2
                                    oCamposDet.OBLI_NM_PRESENTOINFORMEEJECUCION = dr.GetString(m2);
                                    //3
                                    oCamposDet.OBLI_NM_PAGOAPROVECHAMIENTO = dr.GetString(m3);
                                    //4
                                    oCamposDet.OBLI_NM_COMUNICOARFFSOSINFORSUSCRIPCION = dr.GetString(m4);
                                    //5
                                    oCamposDet.OBLI_NM_REPORTOARFFSMINISTERIOAVISTAMIENTOS = dr.GetString(m5);
                                    //6
                                    oCamposDet.OBLI_NM_REALIZOACCIONESCUSTODIO = dr.GetString(m6);
                                    //7
                                    oCamposDet.OBLI_NM_FACILITODESARROLLO = dr.GetString(m7);
                                    //8
                                    oCamposDet.OBLI_NM_ASUMIOCOSTOSUPERVISIONES = dr.GetString(m8);
                                    //9
                                    oCamposDet.OBLI_NM_IMPLEMENTAMECANISMOTRAZA = dr.GetString(m9);
                                    //10
                                    oCamposDet.OBLI_NM_RESPETASERVIDUMBRE = dr.GetString(m10);
                                    //11
                                    oCamposDet.OBLI_NM_ADOPTAMEDIDASEXTENSION = dr.GetString(m11);
                                    //12
                                    oCamposDet.OBLI_NM_RESPETAVALORES = dr.GetString(m12);
                                    //13
                                    oCamposDet.OBLI_NM_CUMPLEMEDIDAS = dr.GetString(m13);
                                    //14
                                    oCamposDet.OBLI_NM_CUMPLENORMAS = dr.GetString(m14);
                                    //15
                                    oCamposDet.OBLI_NM_MOVILIZAFRUTOPRODUCTOS = dr.GetString(m15);
                                    //16
                                    oCamposDet.OBLI_NM_IMPLEMENTACIONMEDIDASCORRECTIVAS = dr.GetString(m16);
                                    //17
                                    oCamposDet.OBLI_NM_IMPMEDCORRECRESULTADOACCIONES = dr.GetString(m17);
                                    //18
                                    oCamposDet.OBLI_NM_PROMUEVENBUENASPRACTICAS = dr.GetString(m18);
                                    //19
                                    oCamposDet.OBLI_NM_PROMUEVEEQUIDAD = dr.GetString(m19);

                                    oCampos.ListObligacionNoMaderable.Add(oCamposDet);
                                }



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
    }
}
