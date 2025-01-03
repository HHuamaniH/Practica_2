﻿using System;
using System.Collections.Generic;
//using System.Data.SqlClient;
using CEntidad = CapaEntidad.DOC.Ent_Reporte_ESTADISTICOS;
using GeneralSQL;
using Oracle.ManagedDataAccess.Client;
//using SQL = GeneralSQL.Data.SQL;


namespace CapaDatos.DOC
{
    // 12/02/2020   EPB Se añade el parametro DSMILVEINTE Y 2020 para generar las estadisticas actualizadas
    public class Dat_Reporte_ESTADISTICOS
    {
        //private SQL oGDataSQL = new SQL();
        private DBOracle dBOracle = new DBOracle();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public List<CEntidad> Reg_Prin_Esp_Aprob(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC_OSINFOR_ERP_MIGRACION.new_REPORTE_ESTADISTICOS", oCEntidad))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            CEntidad oCampos;
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                oCampos.NOMBRE_CIENTIFICO = dr["NOMBRE_CIENTIFICO"].ToString();
                                oCampos.VOL_AUTORIZADO = Decimal.Parse(dr["VOL_AUTORIZADO"].ToString());
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
        public CEntidad Reg_Super_OSINFOR(OracleConnection cn, CEntidad oCEntidad)
        {
            CEntidad oCEntReporte = new CEntidad();
            oCEntReporte.ListISupervision_Region_Modalidad = new List<CEntidad>();
            oCEntReporte.ListISupervision_Modalidad_Anio = new List<CEntidad>();
            oCEntReporte.ListISupervision_Region_Anio = new List<CEntidad>();

            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.new_REPORTE_ESTADISTICOS", oCEntidad))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            CEntidad oCampos;
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                oCampos.MODALIDAD = dr["MODALIDAD"].ToString();
                                oCampos.AMAZONAS = Int32.Parse(dr["'AMAZONAS'"].ToString());
                                oCampos.ANCASH = Int32.Parse(dr["'ANCASH'"].ToString());
                                oCampos.APURIMAC = Int32.Parse(dr["'APURIMAC'"].ToString());
                                oCampos.AREQUIPA = Int32.Parse(dr["'AREQUIPA'"].ToString());
                                oCampos.AYACUCHO = Int32.Parse(dr["'AYACUCHO'"].ToString());
                                oCampos.CAJAMARCA = Int32.Parse(dr["'CAJAMARCA'"].ToString());
                                oCampos.CALLAO = Int32.Parse(dr["'CALLAO'"].ToString());
                                oCampos.CUSCO = Int32.Parse(dr["'CUSCO'"].ToString());
                                oCampos.HUANCAVELICA = Int32.Parse(dr["'HUANCAVELICA'"].ToString());
                                oCampos.HUANUCO = Int32.Parse(dr["'HUANUCO'"].ToString());
                                oCampos.ICA = Int32.Parse(dr["'ICA'"].ToString());
                                oCampos.JUNIN = Int32.Parse(dr["'JUNIN'"].ToString());
                                oCampos.LALIBERTAD = Int32.Parse(dr["'LALIBERTAD'"].ToString());
                                oCampos.LAMBAYEQUE = Int32.Parse(dr["'LAMBAYEQUE'"].ToString());
                                oCampos.LIMA = Int32.Parse(dr["'LIMA'"].ToString());
                                oCampos.LORETO = Int32.Parse(dr["'LORETO'"].ToString());
                                oCampos.MADREDEDIOS = Int32.Parse(dr["'MADREDEDIOS'"].ToString());
                                oCampos.MOQUEGUA = Int32.Parse(dr["'MOQUEGUA'"].ToString());
                                oCampos.PASCO = Int32.Parse(dr["'PASCO'"].ToString());
                                oCampos.PIURA = Int32.Parse(dr["'PIURA'"].ToString());
                                oCampos.PUNO = Int32.Parse(dr["'PUNO'"].ToString());
                                oCampos.SANMARTIN = Int32.Parse(dr["'SANMARTIN'"].ToString());
                                oCampos.TACNA = Int32.Parse(dr["'TACNA'"].ToString());
                                oCampos.TUMBES = Int32.Parse(dr["'TUMBES'"].ToString());
                                oCampos.UCAYALI = Int32.Parse(dr["'UCAYALI'"].ToString());
                                oCampos.TOTAL = Int32.Parse(dr["TOTAL"].ToString());
                                oCEntReporte.ListISupervision_Region_Modalidad.Add(oCampos);
                            }
                        }
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            CEntidad oCampos;
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                oCampos.MODALIDAD = dr["MODALIDAD"].ToString();
                                oCampos.DOSMILNUEVE = Int32.Parse(dr["'2009'"].ToString());
                                oCampos.DOSMILDIEZ = Int32.Parse(dr["'2010'"].ToString());
                                oCampos.DOSMILONCE = Int32.Parse(dr["'2011'"].ToString());
                                oCampos.DOSMILDOCE = Int32.Parse(dr["'2012'"].ToString());
                                oCampos.DOSMILTRECE = Int32.Parse(dr["'2013'"].ToString());
                                oCampos.DOSMILCATORCE = Int32.Parse(dr["'2014'"].ToString());
                                oCampos.DOSMILQUINCE = Int32.Parse(dr["'2015'"].ToString());
                                oCampos.DOSMILDIECISEIS = Int32.Parse(dr["'2016'"].ToString());
                                oCampos.DOSMILDIECISIETE = Int32.Parse(dr["'2017'"].ToString());
                                oCampos.DOSMILDIECIOCHO = Int32.Parse(dr["'2018'"].ToString());
                                oCampos.DOSMILDIECINUEVE = Int32.Parse(dr["'2019'"].ToString());
                                oCampos.DOSMILVEINTE = Int32.Parse(dr["'2020'"].ToString());
                                oCampos.DOSMILVEINTIUNO = Int32.Parse(dr["'2021'"].ToString());
                                oCampos.DOSMILVEINTIDOS = Int32.Parse(dr["'2022'"].ToString());
                                oCampos.DOSMILVEINTITRES = Int32.Parse(dr["'2023'"].ToString());
                                oCampos.DOSMILVEINTICUATRO = Int32.Parse(dr["'2024'"].ToString());
                                oCampos.TOTAL = Int32.Parse(dr["TOTAL"].ToString());
                                oCEntReporte.ListISupervision_Modalidad_Anio.Add(oCampos);
                            }
                        }
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            CEntidad oCampos;
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                oCampos.DEPARTAMENTO = dr["REGION"].ToString();
                                oCampos.DOSMILNUEVE = Int32.Parse(dr["'2009'"].ToString());
                                oCampos.DOSMILDIEZ = Int32.Parse(dr["'2010'"].ToString());
                                oCampos.DOSMILONCE = Int32.Parse(dr["'2011'"].ToString());
                                oCampos.DOSMILDOCE = Int32.Parse(dr["'2012'"].ToString());
                                oCampos.DOSMILTRECE = Int32.Parse(dr["'2013'"].ToString());
                                oCampos.DOSMILCATORCE = Int32.Parse(dr["'2014'"].ToString());
                                oCampos.DOSMILQUINCE = Int32.Parse(dr["'2015'"].ToString());
                                oCampos.DOSMILDIECISEIS = Int32.Parse(dr["'2016'"].ToString());
                                oCampos.DOSMILDIECISIETE = Int32.Parse(dr["'2017'"].ToString());
                                oCampos.DOSMILDIECIOCHO = Int32.Parse(dr["'2018'"].ToString());
                                oCampos.DOSMILDIECINUEVE = Int32.Parse(dr["'2019'"].ToString());
                                oCampos.DOSMILVEINTE = Int32.Parse(dr["'2020'"].ToString());
                                oCampos.DOSMILVEINTIUNO = Int32.Parse(dr["'2021'"].ToString());
                                oCampos.DOSMILVEINTIDOS = Int32.Parse(dr["'2022'"].ToString());
                                oCampos.DOSMILVEINTITRES = Int32.Parse(dr["'2023'"].ToString());
                                oCampos.DOSMILVEINTICUATRO = Int32.Parse(dr["'2024'"].ToString());
                                oCampos.TOTAL = Int32.Parse(dr["TOTAL"].ToString());
                                oCEntReporte.ListISupervision_Region_Anio.Add(oCampos);
                            }
                        }
                    }
                }
                return oCEntReporte;
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
        public CEntidad Reg_Capacitaciones_OSINFOR(OracleConnection cn, CEntidad oCEntidad)
        {
            CEntidad lsCEntidad = new CEntidad();
            CEntidad oCampos;
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.new_REPORTE_ESTADISTICOS", oCEntidad))
                {
                    lsCEntidad.ListCapacitacionRegion = new List<CEntidad>();
                    lsCEntidad.ListCapacitacionParticipante = new List<CEntidad>();
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                oCampos.DEPARTAMENTO = dr["DEPARTAMENTO"].ToString();
                                oCampos.DOSMILNUEVE = Int32.Parse(dr["DOSMILNUEVE"].ToString());
                                oCampos.DOSMILDIEZ = Int32.Parse(dr["DOSMILDIEZ"].ToString());
                                oCampos.DOSMILONCE = Int32.Parse(dr["DOSMILONCE"].ToString());
                                oCampos.DOSMILDOCE = Int32.Parse(dr["DOSMILDOCE"].ToString());
                                oCampos.DOSMILTRECE = Int32.Parse(dr["DOSMILTRECE"].ToString());
                                oCampos.DOSMILCATORCE = Int32.Parse(dr["DOSMILCATORCE"].ToString());
                                oCampos.DOSMILQUINCE = Int32.Parse(dr["DOSMILQUINCE"].ToString());
                                oCampos.DOSMILDIECISEIS = Int32.Parse(dr["DOSMILDIECISEIS"].ToString());
                                oCampos.DOSMILDIECISIETE = Int32.Parse(dr["DOSMILDIECISIETE"].ToString());
                                oCampos.DOSMILDIECIOCHO = Int32.Parse(dr["DOSMILDIECIOCHO"].ToString());
                                oCampos.DOSMILDIECINUEVE = Int32.Parse(dr["DOSMILDIECINUEVE"].ToString());
                                oCampos.DOSMILVEINTE = Int32.Parse(dr["DOSMILVEINTE"].ToString());
                                oCampos.DOSMILVEINTIUNO = Int32.Parse(dr["DOSMILVEINTIUNO"].ToString());
                                oCampos.DOSMILVEINTIDOS = Int32.Parse(dr["DOSMILVEINTIDOS"].ToString());
                                oCampos.DOSMILVEINTITRES = Int32.Parse(dr["DOSMILVEINTITRES"].ToString());
                                oCampos.TOTAL = Int32.Parse(dr["TOTAL"].ToString());

                                lsCEntidad.ListCapacitacionRegion.Add(oCampos);
                            }
                        }
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                oCampos.ANIO = Int32.Parse(dr["ANIO"].ToString());
                                oCampos.NUM_CAPACITACIONES = Int32.Parse(dr["NUM_CAPACITACIONES"].ToString());
                                oCampos.NUM_PARTICIPANTES = Int32.Parse(dr["NUM_PARTICIPANTES"].ToString());
                                oCampos.NUM_HOMBRES = Int32.Parse(dr["NUM_HOMBRES"].ToString());
                                oCampos.NUM_MUJERES = Int32.Parse(dr["NUM_MUJERES"].ToString());
                                lsCEntidad.ListCapacitacionParticipante.Add(oCampos);
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
        public List<CEntidad> Reg_Arboles_OSINFOR(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC_OSINFOR_ERP_MIGRACION.new_REPORTE_ESTADISTICOS", oCEntidad))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            CEntidad oCampos;
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                oCampos.ANIO = Int32.Parse(dr["ANIO"].ToString());
                                oCampos.EXISTENTES = Int32.Parse(dr["EXISTENTES"].ToString());
                                oCampos.INEXISTENTES = Int32.Parse(dr["INEXISTENTES"].ToString());
                                oCampos.TOTAL_ARBOLES = Int32.Parse(dr["TOTAL"].ToString());
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

        public CEntidad Reg_Arboles_OSINFOR_v2(OracleConnection cn, CEntidad oCEntidad)
        {
            CEntidad lsCEntidad = new CEntidad();
            CEntidad oCampos;

            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.new_REPORTE_ESTADISTICOS", oCEntidad))
                {
                    lsCEntidad.ListISupervision_Region_Anio = new List<CEntidad>();//Reporte por año
                    lsCEntidad.ListISupervision_Modalidad_Anio = new List<CEntidad>();//Reporte por modalidad
                    lsCEntidad.ListISupervision_Region_Modalidad = new List<CEntidad>();//Reporte por departamento

                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                oCampos.ANIO = Int32.Parse(dr["ANIO"].ToString());
                                oCampos.EXISTENTES = Int32.Parse(dr["EXISTENTES"].ToString());
                                oCampos.INEXISTENTES = Int32.Parse(dr["INEXISTENTES"].ToString());
                                oCampos.TOTAL_ARBOLES = Int32.Parse(dr["TOTAL"].ToString());
                                lsCEntidad.ListISupervision_Region_Anio.Add(oCampos);
                            }
                        }
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                oCampos.MODALIDAD = dr["MODALIDAD"].ToString();
                                oCampos.EXISTENTES = Int32.Parse(dr["EXISTENTES"].ToString());
                                oCampos.INEXISTENTES = Int32.Parse(dr["INEXISTENTES"].ToString());
                                oCampos.TOTAL_ARBOLES = Int32.Parse(dr["TOTAL"].ToString());
                                lsCEntidad.ListISupervision_Modalidad_Anio.Add(oCampos);
                            }
                        }
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                oCampos.DEPARTAMENTO = dr["DEPARTAMENTO"].ToString();
                                oCampos.EXISTENTES = Int32.Parse(dr["EXISTENTES"].ToString());
                                oCampos.INEXISTENTES = Int32.Parse(dr["INEXISTENTES"].ToString());
                                oCampos.TOTAL_ARBOLES = Int32.Parse(dr["TOTAL"].ToString());
                                lsCEntidad.ListISupervision_Region_Modalidad.Add(oCampos);
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
        public List<CEntidad> Reg_PManejo_OSINFOR(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC_OSINFOR_ERP_MIGRACION.new_REPORTE_ESTADISTICOS", oCEntidad))
                //using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC.spReporte_Resumen_POASupervisado", oCEntidad))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            CEntidad oCampos;
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                oCampos.ANIO = Int32.Parse(dr["ANIO"].ToString());
                                oCampos.EXISTENTES = Int32.Parse(dr["EXISTENTES"].ToString());
                                oCampos.INEXISTENTES = Int32.Parse(dr["INEXISTENTES"].ToString());
                                oCampos.TOTAL_PLANES = Int32.Parse(dr["TOTAL"].ToString());
                                oCampos.REGENTES = Int32.Parse(dr["REGENTES"].ToString());
                                oCampos.REGENTES_EXISTENTE = Int32.Parse(dr["REGENTES_EXISTENTE"].ToString());
                                oCampos.FUNCIONARIOS = Int32.Parse(dr["FUNCIONARIOS"].ToString());
                                oCampos.FUNCIONARIOS_EXISTENTE = Int32.Parse(dr["FUNCIONARIOS_EXISTENTE"].ToString());
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
        public List<CEntidad> Reg_Esp_Vol_Injus_Superv(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC_OSINFOR_ERP_MIGRACION.new_REPORTE_ESTADISTICOS", oCEntidad))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            CEntidad oCampos;
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                oCampos.NOMBRE_CIENTIFICO = dr["NOMBRE_CIENTIFICO"].ToString();
                                oCampos.VOL_MOVILIZADO = Decimal.Parse(dr["VOL_MOVILIZADO"].ToString());
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
        public List<CEntidad> Reg_Esp_Movil_Ext_Ilegal_Fiscal(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC_OSINFOR_ERP_MIGRACION.new_REPORTE_ESTADISTICOS", oCEntidad))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            CEntidad oCampos;
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                oCampos.NOMBRE_CIENTIFICO = dr["NOMBRE_CIENTIFICO"].ToString();
                                oCampos.VOL_MOVILIZADO = Decimal.Parse(dr["VOL_MOVILIZADO"].ToString());
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
        public List<CEntidad> Reg_Vol_Mov_Ext_Ilegal(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC_OSINFOR_ERP_MIGRACION.new_REPORTE_ESTADISTICOS", oCEntidad))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            CEntidad oCampos;
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                oCampos.DEPARTAMENTO = dr["DEPARTAMENTO"].ToString();
                                oCampos.CANT_BS = Decimal.Parse(dr["CANT_BS"].ToString());
                                oCampos.CANT_CCNN = Decimal.Parse(dr["CANT_CCNN"].ToString());
                                oCampos.CANT_PP = Decimal.Parse(dr["CANT_PP"].ToString());
                                oCampos.CANT_CCCC = Decimal.Parse(dr["CANT_CCCC"].ToString());
                                oCampos.CANT_TARA = Decimal.Parse(dr["CANT_TARA"].ToString());
                                oCampos.CANT_BL = Decimal.Parse(dr["CANT_BL"].ToString());
                                oCampos.CANT_CMADE = Decimal.Parse(dr["CANT_CMADE"].ToString());
                                oCampos.CANT_NM = Decimal.Parse(dr["CANT_NMCAST"].ToString()) + Decimal.Parse(dr["CANT_NMSHI"].ToString()) + Decimal.Parse(dr["CANT_NMAGUAJE"].ToString());
                                oCampos.CANT_FYR = Decimal.Parse(dr["CANT_FYR"].ToString());
                                oCampos.TOTAL = Decimal.Parse(dr["TOTAL"].ToString());
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

        public List<CEntidad> Reg_Vol_Mov_Ext_Ilegal_Superv(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC_OSINFOR_ERP_MIGRACION.new_REPORTE_ESTADISTICOS", oCEntidad))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            CEntidad oCampos;
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                oCampos.DEPARTAMENTO = dr["DEPARTAMENTO"].ToString();
                                oCampos.CANT_BS = Decimal.Parse(dr["CANT_BS"].ToString());
                                oCampos.CANT_CCNN = Decimal.Parse(dr["CANT_CCNN"].ToString());
                                oCampos.CANT_PP = Decimal.Parse(dr["CANT_PP"].ToString());
                                oCampos.CANT_CCCC = Decimal.Parse(dr["CANT_CCCC"].ToString());
                                oCampos.CANT_BL = Decimal.Parse(dr["CANT_BL"].ToString());
                                oCampos.CANT_CMADE = Decimal.Parse(dr["CANT_CMADE"].ToString());
                                oCampos.CANT_NM = Decimal.Parse(dr["CANT_NMCAST"].ToString()) + Decimal.Parse(dr["CANT_NMSHI"].ToString()) + Decimal.Parse(dr["CANT_NMAGUAJE"].ToString());
                                oCampos.CANT_FYR = Decimal.Parse(dr["CANT_FYR"].ToString());
                                oCampos.CANT_CARRIZO = Decimal.Parse(dr["CANT_CARRIZO"].ToString());
                                oCampos.TOTAL = Decimal.Parse(dr["TOTAL"].ToString());
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

        public List<CEntidad> Lista_PAU_Concluidos(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.new_REPORTE_ESTADISTICOS", oCEntidad))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            CEntidad oCampos;
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                oCampos.ANIO = Int32.Parse(dr["ANIO"].ToString());
                                oCampos.SUPERVISION = Int32.Parse(dr["SUPERVISION"].ToString());
                                oCampos.ARCHIVO_PRELIMINAR = Int32.Parse(dr["ARCHIVO_PRELIMINAR"].ToString());
                                oCampos.INI_PAU = Int32.Parse(dr["INICIOPAU"].ToString());
                                oCampos.CANTIDAD = Int32.Parse(dr["PROCESOS"].ToString());
                                oCampos.AVANCE = Decimal.Parse(dr["PORCENTAJE"].ToString());
                                oCampos.TERMINO_PAU = Int32.Parse(dr["PAU_CONCLUIDOS"].ToString());
                                oCampos.AVANCE1 = Decimal.Parse(dr["PORCENTAJE_PAU_FIN"].ToString());
                                oCampos.SUPER_TERMINADO_PAU = Int32.Parse(dr["SUPER_TERMINADO_PAU"].ToString());
                                oCampos.CASOS = Int32.Parse(dr["CASOS"].ToString());
                                oCampos.AVANCE_CASOS = (oCampos.SUPERVISION) == 0 ? 0 : ((Decimal)(oCampos.CASOS) / (Decimal)(oCampos.SUPERVISION));
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
        public List<CEntidad> Reg_PManejo_Sancion_OSINFOR(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC_OSINFOR_ERP_MIGRACION.new_REPORTE_ESTADISTICOS", oCEntidad))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            CEntidad oCampos;
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                oCampos.ANIO = Int32.Parse(dr["ANIO_SUPERVISION"].ToString());
                                oCampos.TOTAL_PLANES = Int32.Parse(dr["SUPERVISADOS"].ToString());
                                oCampos.SANCIONADO_PAU = Int32.Parse(dr["SANCIONADOS"].ToString());
                                oCampos.AVANCE = Decimal.Parse(dr["PORCENTAJE"].ToString());
                                oCampos.ARCHIVO_PRELIMINAR_SIN = Int32.Parse(dr["ARCHIVOS_NO_OSF"].ToString());
                                oCampos.ARCHIVO_PRELIMINAR = Int32.Parse(dr["ARCHIVOS_INFORME"].ToString());
                                oCampos.ARCHIVO_PAU = Int32.Parse(dr["ARCHIVOS_PAU"].ToString());
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
    }
}
