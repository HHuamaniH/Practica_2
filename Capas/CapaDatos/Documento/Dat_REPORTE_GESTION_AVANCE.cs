using System;
using System.Collections.Generic;
//using System.Data.SqlClient;
using CEntidad = CapaEntidad.DOC.Ent_REPORTE_GESTION_AVANCE;
using GeneralSQL;
using Oracle.ManagedDataAccess.Client;
//using SQL = GeneralSQL.Data.SQL;

namespace CapaDatos.DOC
{
    /// <summary>
    /// 
    /// </summary>
    public class Dat_REPORTE_GESTION_AVANCE
    {
        //private SQL oGDataSQL = new SQL();
        private DBOracle dBOracle = new DBOracle();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public List<CEntidad> RegMostrarGESTION_Avance(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC.EJECUTADA_ISUPERVISION", oCEntidad))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            int p1 = dr.GetOrdinal("MODALIDAD");
                            int p2 = dr.GetOrdinal("META_ANUAL");
                            int p3 = dr.GetOrdinal("MES_ENERO");
                            int p4 = dr.GetOrdinal("EJEC_ENE");
                            int p5 = dr.GetOrdinal("MES_FEBRERO");
                            int p6 = dr.GetOrdinal("EJEC_FEB");
                            int p7 = dr.GetOrdinal("MES_MARZO");
                            int p8 = dr.GetOrdinal("EJEC_MAR");
                            int p9 = dr.GetOrdinal("MES_ABRIL");
                            int p10 = dr.GetOrdinal("EJEC_ABR");
                            int p11 = dr.GetOrdinal("MES_MAYO");
                            int p12 = dr.GetOrdinal("EJEC_MAY");
                            int p13 = dr.GetOrdinal("MES_JUNIO");
                            int p14 = dr.GetOrdinal("EJEC_JUN");
                            int p15 = dr.GetOrdinal("MES_JULIO");
                            int p16 = dr.GetOrdinal("EJEC_JUL");
                            int p17 = dr.GetOrdinal("MES_AGOSTO");
                            int p18 = dr.GetOrdinal("EJEC_AGO");
                            int p19 = dr.GetOrdinal("MES_SETIEMBRE");
                            int p20 = dr.GetOrdinal("EJEC_SET");
                            int p21 = dr.GetOrdinal("MES_OCTUBRE");
                            int p22 = dr.GetOrdinal("EJEC_OCT");
                            int p23 = dr.GetOrdinal("MES_NOVIEMBRE");
                            int p24 = dr.GetOrdinal("EJEC_NOV");
                            int p25 = dr.GetOrdinal("MES_DICIEMBRE");
                            int p26 = dr.GetOrdinal("EJEC_DIC");
                            int p39 = dr.GetOrdinal("TOTAL_EJEC");

                            CEntidad oCampos;
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                oCampos.MODALIDAD = dr.GetString(p1);
                                oCampos.META_ANUAL = dr.GetInt32(p2);
                                oCampos.MES_ENERO = dr.GetInt32(p3);
                                oCampos.EJEC_ENE = dr.GetInt32(p4);
                                oCampos.MES_FEBRERO = dr.GetInt32(p5);
                                oCampos.EJEC_FEB = dr.GetInt32(p6);
                                oCampos.MES_MARZO = dr.GetInt32(p7);
                                oCampos.EJEC_MAR = dr.GetInt32(p8);
                                oCampos.MES_ABRIL = dr.GetInt32(p9);
                                oCampos.EJEC_ABR = dr.GetInt32(p10);
                                oCampos.MES_MAYO = dr.GetInt32(p11);
                                oCampos.EJEC_MAY = dr.GetInt32(p12);
                                oCampos.MES_JUNIO = dr.GetInt32(p13);
                                oCampos.EJEC_JUN = dr.GetInt32(p14);
                                oCampos.MES_JULIO = dr.GetInt32(p15);
                                oCampos.EJEC_JUL = dr.GetInt32(p16);
                                oCampos.MES_AGOSTO = dr.GetInt32(p17);
                                oCampos.EJEC_AGO = dr.GetInt32(p18);
                                oCampos.MES_SETIEMBRE = dr.GetInt32(p19);
                                oCampos.EJEC_SET = dr.GetInt32(p20);
                                oCampos.MES_OCTUBRE = dr.GetInt32(p21);
                                oCampos.EJEC_OCT = dr.GetInt32(p22);
                                oCampos.MES_NOVIEMBRE = dr.GetInt32(p23);
                                oCampos.EJEC_NOV = dr.GetInt32(p24);
                                oCampos.MES_DICIEMBRE = dr.GetInt32(p25);
                                oCampos.EJEC_DIC = dr.GetInt32(p26);
                                oCampos.AVANCE_ENE = (oCampos.MES_ENERO != 0) ? (Decimal)oCampos.EJEC_ENE / (Decimal)oCampos.MES_ENERO : oCampos.EJEC_ENE;
                                oCampos.AVANCE_FEB = (oCampos.MES_FEBRERO != 0) ? (Decimal)oCampos.EJEC_FEB / (Decimal)oCampos.MES_FEBRERO : oCampos.EJEC_FEB;
                                oCampos.AVANCE_MAR = (oCampos.MES_MARZO != 0) ? (Decimal)oCampos.EJEC_MAR / (Decimal)oCampos.MES_MARZO : oCampos.EJEC_MAR;
                                oCampos.AVANCE_ABR = (oCampos.MES_ABRIL != 0) ? (Decimal)oCampos.EJEC_ABR / (Decimal)oCampos.MES_ABRIL : oCampos.EJEC_ABR;
                                oCampos.AVANCE_MAY = (oCampos.MES_MAYO != 0) ? (Decimal)oCampos.EJEC_MAY / (Decimal)oCampos.MES_MAYO : oCampos.EJEC_MAY;
                                oCampos.AVANCE_JUN = (oCampos.MES_JUNIO != 0) ? (Decimal)oCampos.EJEC_JUN / (Decimal)oCampos.MES_JUNIO : oCampos.EJEC_JUN;
                                oCampos.AVANCE_JUL = (oCampos.MES_JULIO != 0) ? (Decimal)oCampos.EJEC_JUL / (Decimal)oCampos.MES_JULIO : oCampos.EJEC_JUL;
                                oCampos.AVANCE_AGO = (oCampos.MES_AGOSTO != 0) ? (Decimal)oCampos.EJEC_AGO / (Decimal)oCampos.MES_AGOSTO : oCampos.EJEC_AGO;
                                oCampos.AVANCE_SET = (oCampos.MES_SETIEMBRE != 0) ? (Decimal)oCampos.EJEC_SET / (Decimal)oCampos.MES_SETIEMBRE : oCampos.EJEC_SET;
                                oCampos.AVANCE_OCT = (oCampos.MES_OCTUBRE != 0) ? (Decimal)oCampos.EJEC_OCT / (Decimal)oCampos.MES_OCTUBRE : oCampos.EJEC_OCT;
                                oCampos.AVANCE_NOV = (oCampos.MES_NOVIEMBRE != 0) ? (Decimal)oCampos.EJEC_NOV / (Decimal)oCampos.MES_NOVIEMBRE : oCampos.EJEC_NOV;
                                oCampos.AVANCE_DIC = (oCampos.MES_DICIEMBRE != 0) ? (Decimal)oCampos.EJEC_DIC / (Decimal)oCampos.MES_DICIEMBRE : oCampos.EJEC_DIC;
                                oCampos.TOTAL_EJEC = dr.GetInt32(p39);
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
        public List<CEntidad> RegMostrarRESOLUCIONES_Avance(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC.EJECUTADA_RESOLUCION_EMITIDA", oCEntidad))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            int p1 = dr.GetOrdinal("TITULO");
                            int p2 = dr.GetOrdinal("META_ANUAL");
                            int p3 = dr.GetOrdinal("MES_ENERO");
                            int p4 = dr.GetOrdinal("EJEC_ENE");
                            int p5 = dr.GetOrdinal("MES_FEBRERO");
                            int p6 = dr.GetOrdinal("EJEC_FEB");
                            int p7 = dr.GetOrdinal("MES_MARZO");
                            int p8 = dr.GetOrdinal("EJEC_MAR");
                            int p9 = dr.GetOrdinal("MES_ABRIL");
                            int p10 = dr.GetOrdinal("EJEC_ABR");
                            int p11 = dr.GetOrdinal("MES_MAYO");
                            int p12 = dr.GetOrdinal("EJEC_MAY");
                            int p13 = dr.GetOrdinal("MES_JUNIO");
                            int p14 = dr.GetOrdinal("EJEC_JUN");
                            int p15 = dr.GetOrdinal("MES_JULIO");
                            int p16 = dr.GetOrdinal("EJEC_JUL");
                            int p17 = dr.GetOrdinal("MES_AGOSTO");
                            int p18 = dr.GetOrdinal("EJEC_AGO");
                            int p19 = dr.GetOrdinal("MES_SETIEMBRE");
                            int p20 = dr.GetOrdinal("EJEC_SET");
                            int p21 = dr.GetOrdinal("MES_OCTUBRE");
                            int p22 = dr.GetOrdinal("EJEC_OCT");
                            int p23 = dr.GetOrdinal("MES_NOVIEMBRE");
                            int p24 = dr.GetOrdinal("EJEC_NOV");
                            int p25 = dr.GetOrdinal("MES_DICIEMBRE");
                            int p26 = dr.GetOrdinal("EJEC_DIC");
                            //int p27 = dr.GetOrdinal("AVANCE_ENE");
                            //int p28 = dr.GetOrdinal("AVANCE_FEB");
                            //int p29 = dr.GetOrdinal("AVANCE_MAR");
                            //int p30 = dr.GetOrdinal("AVANCE_ABR");
                            //int p31 = dr.GetOrdinal("AVANCE_MAY");
                            //int p32 = dr.GetOrdinal("AVANCE_JUN");
                            //int p33 = dr.GetOrdinal("AVANCE_JUL");
                            //int p34 = dr.GetOrdinal("AVANCE_AGO");
                            //int p35 = dr.GetOrdinal("AVANCE_SET");
                            //int p36 = dr.GetOrdinal("AVANCE_OCT");
                            //int p37 = dr.GetOrdinal("AVANCE_NOV");
                            //int p38 = dr.GetOrdinal("AVANCE_DIC");
                            int p39 = dr.GetOrdinal("TOTAL_EJEC");

                            CEntidad oCampos;
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                oCampos.MODALIDAD = dr.GetString(p1);
                                oCampos.META_ANUAL = dr.GetInt32(p2);
                                oCampos.MES_ENERO = dr.GetInt32(p3);
                                oCampos.EJEC_ENE = dr.GetInt32(p4);
                                oCampos.MES_FEBRERO = dr.GetInt32(p5);
                                oCampos.EJEC_FEB = dr.GetInt32(p6);
                                oCampos.MES_MARZO = dr.GetInt32(p7);
                                oCampos.EJEC_MAR = dr.GetInt32(p8);
                                oCampos.MES_ABRIL = dr.GetInt32(p9);
                                oCampos.EJEC_ABR = dr.GetInt32(p10);
                                oCampos.MES_MAYO = dr.GetInt32(p11);
                                oCampos.EJEC_MAY = dr.GetInt32(p12);
                                oCampos.MES_JUNIO = dr.GetInt32(p13);
                                oCampos.EJEC_JUN = dr.GetInt32(p14);
                                oCampos.MES_JULIO = dr.GetInt32(p15);
                                oCampos.EJEC_JUL = dr.GetInt32(p16);
                                oCampos.MES_AGOSTO = dr.GetInt32(p17);
                                oCampos.EJEC_AGO = dr.GetInt32(p18);
                                oCampos.MES_SETIEMBRE = dr.GetInt32(p19);
                                oCampos.EJEC_SET = dr.GetInt32(p20);
                                oCampos.MES_OCTUBRE = dr.GetInt32(p21);
                                oCampos.EJEC_OCT = dr.GetInt32(p22);
                                oCampos.MES_NOVIEMBRE = dr.GetInt32(p23);
                                oCampos.EJEC_NOV = dr.GetInt32(p24);
                                oCampos.MES_DICIEMBRE = dr.GetInt32(p25);
                                oCampos.EJEC_DIC = dr.GetInt32(p26);
                                oCampos.AVANCE_ENE = (oCampos.MES_ENERO != 0) ? (Decimal)oCampos.EJEC_ENE / (Decimal)oCampos.MES_ENERO : oCampos.EJEC_ENE;
                                oCampos.AVANCE_FEB = (oCampos.MES_FEBRERO != 0) ? (Decimal)oCampos.EJEC_FEB / (Decimal)oCampos.MES_FEBRERO : oCampos.EJEC_FEB;
                                oCampos.AVANCE_MAR = (oCampos.MES_MARZO != 0) ? (Decimal)oCampos.EJEC_MAR / (Decimal)oCampos.MES_MARZO : oCampos.EJEC_MAR;
                                oCampos.AVANCE_ABR = (oCampos.MES_ABRIL != 0) ? (Decimal)oCampos.EJEC_ABR / (Decimal)oCampos.MES_ABRIL : oCampos.EJEC_ABR;
                                oCampos.AVANCE_MAY = (oCampos.MES_MAYO != 0) ? (Decimal)oCampos.EJEC_MAY / (Decimal)oCampos.MES_MAYO : oCampos.EJEC_MAY;
                                oCampos.AVANCE_JUN = (oCampos.MES_JUNIO != 0) ? (Decimal)oCampos.EJEC_JUN / (Decimal)oCampos.MES_JUNIO : oCampos.EJEC_JUN;
                                oCampos.AVANCE_JUL = (oCampos.MES_JULIO != 0) ? (Decimal)oCampos.EJEC_JUL / (Decimal)oCampos.MES_JULIO : oCampos.EJEC_JUL;
                                oCampos.AVANCE_AGO = (oCampos.MES_AGOSTO != 0) ? (Decimal)oCampos.EJEC_AGO / (Decimal)oCampos.MES_AGOSTO : oCampos.EJEC_AGO;
                                oCampos.AVANCE_SET = (oCampos.MES_SETIEMBRE != 0) ? (Decimal)oCampos.EJEC_SET / (Decimal)oCampos.MES_SETIEMBRE : oCampos.EJEC_SET;
                                oCampos.AVANCE_OCT = (oCampos.MES_OCTUBRE != 0) ? (Decimal)oCampos.EJEC_OCT / (Decimal)oCampos.MES_OCTUBRE : oCampos.EJEC_OCT;
                                oCampos.AVANCE_NOV = (oCampos.MES_NOVIEMBRE != 0) ? (Decimal)oCampos.EJEC_NOV / (Decimal)oCampos.MES_NOVIEMBRE : oCampos.EJEC_NOV;
                                oCampos.AVANCE_DIC = (oCampos.MES_DICIEMBRE != 0) ? (Decimal)oCampos.EJEC_DIC / (Decimal)oCampos.MES_DICIEMBRE : oCampos.EJEC_DIC;
                                oCampos.TOTAL_EJEC = dr.GetInt32(p39);
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
        public List<CEntidad> DatInformeLegalTecnico(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC.EJECUTADA_ITECNICO_LEGAL", oCEntidad))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            int p1 = dr.GetOrdinal("DESCRIPCION");
                            int p2 = dr.GetOrdinal("META_ANUAL");
                            int p3 = dr.GetOrdinal("MES_ENERO");
                            int p4 = dr.GetOrdinal("EJEC_ENE");
                            int p5 = dr.GetOrdinal("MES_FEBRERO");
                            int p6 = dr.GetOrdinal("EJEC_FEB");
                            int p7 = dr.GetOrdinal("MES_MARZO");
                            int p8 = dr.GetOrdinal("EJEC_MAR");
                            int p9 = dr.GetOrdinal("MES_ABRIL");
                            int p10 = dr.GetOrdinal("EJEC_ABR");
                            int p11 = dr.GetOrdinal("MES_MAYO");
                            int p12 = dr.GetOrdinal("EJEC_MAY");
                            int p13 = dr.GetOrdinal("MES_JUNIO");
                            int p14 = dr.GetOrdinal("EJEC_JUN");
                            int p15 = dr.GetOrdinal("MES_JULIO");
                            int p16 = dr.GetOrdinal("EJEC_JUL");
                            int p17 = dr.GetOrdinal("MES_AGOSTO");
                            int p18 = dr.GetOrdinal("EJEC_AGO");
                            int p19 = dr.GetOrdinal("MES_SETIEMBRE");
                            int p20 = dr.GetOrdinal("EJEC_SET");
                            int p21 = dr.GetOrdinal("MES_OCTUBRE");
                            int p22 = dr.GetOrdinal("EJEC_OCT");
                            int p23 = dr.GetOrdinal("MES_NOVIEMBRE");
                            int p24 = dr.GetOrdinal("EJEC_NOV");
                            int p25 = dr.GetOrdinal("MES_DICIEMBRE");
                            int p26 = dr.GetOrdinal("EJEC_DIC");


                            CEntidad oCampos;
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                oCampos.MODALIDAD = dr.GetString(p1);
                                oCampos.META_ANUAL = dr.GetInt32(p2);
                                oCampos.MES_ENERO = dr.GetInt32(p3);
                                oCampos.EJEC_ENE = dr.GetInt32(p4);
                                oCampos.MES_FEBRERO = dr.GetInt32(p5);
                                oCampos.EJEC_FEB = dr.GetInt32(p6);
                                oCampos.MES_MARZO = dr.GetInt32(p7);
                                oCampos.EJEC_MAR = dr.GetInt32(p8);
                                oCampos.MES_ABRIL = dr.GetInt32(p9);
                                oCampos.EJEC_ABR = dr.GetInt32(p10);
                                oCampos.MES_MAYO = dr.GetInt32(p11);
                                oCampos.EJEC_MAY = dr.GetInt32(p12);
                                oCampos.MES_JUNIO = dr.GetInt32(p13);
                                oCampos.EJEC_JUN = dr.GetInt32(p14);
                                oCampos.MES_JULIO = dr.GetInt32(p15);
                                oCampos.EJEC_JUL = dr.GetInt32(p16);
                                oCampos.MES_AGOSTO = dr.GetInt32(p17);
                                oCampos.EJEC_AGO = dr.GetInt32(p18);
                                oCampos.MES_SETIEMBRE = dr.GetInt32(p19);
                                oCampos.EJEC_SET = dr.GetInt32(p20);
                                oCampos.MES_OCTUBRE = dr.GetInt32(p21);
                                oCampos.EJEC_OCT = dr.GetInt32(p22);
                                oCampos.MES_NOVIEMBRE = dr.GetInt32(p23);
                                oCampos.EJEC_NOV = dr.GetInt32(p24);
                                oCampos.MES_DICIEMBRE = dr.GetInt32(p25);
                                oCampos.EJEC_DIC = dr.GetInt32(p26);
                                oCampos.AVANCE_ENE = (oCampos.MES_ENERO != 0) ? (Decimal)oCampos.EJEC_ENE / (Decimal)oCampos.MES_ENERO : oCampos.EJEC_ENE;
                                oCampos.AVANCE_FEB = (oCampos.MES_FEBRERO != 0) ? (Decimal)oCampos.EJEC_FEB / (Decimal)oCampos.MES_FEBRERO : oCampos.EJEC_FEB;
                                oCampos.AVANCE_MAR = (oCampos.MES_MARZO != 0) ? (Decimal)oCampos.EJEC_MAR / (Decimal)oCampos.MES_MARZO : oCampos.EJEC_MAR;
                                oCampos.AVANCE_ABR = (oCampos.MES_ABRIL != 0) ? (Decimal)oCampos.EJEC_ABR / (Decimal)oCampos.MES_ABRIL : oCampos.EJEC_ABR;
                                oCampos.AVANCE_MAY = (oCampos.MES_MAYO != 0) ? (Decimal)oCampos.EJEC_MAY / (Decimal)oCampos.MES_MAYO : oCampos.EJEC_MAY;
                                oCampos.AVANCE_JUN = (oCampos.MES_JUNIO != 0) ? (Decimal)oCampos.EJEC_JUN / (Decimal)oCampos.MES_JUNIO : oCampos.EJEC_JUN;
                                oCampos.AVANCE_JUL = (oCampos.MES_JULIO != 0) ? (Decimal)oCampos.EJEC_JUL / (Decimal)oCampos.MES_JULIO : oCampos.EJEC_JUL;
                                oCampos.AVANCE_AGO = (oCampos.MES_AGOSTO != 0) ? (Decimal)oCampos.EJEC_AGO / (Decimal)oCampos.MES_AGOSTO : oCampos.EJEC_AGO;
                                oCampos.AVANCE_SET = (oCampos.MES_SETIEMBRE != 0) ? (Decimal)oCampos.EJEC_SET / (Decimal)oCampos.MES_SETIEMBRE : oCampos.EJEC_SET;
                                oCampos.AVANCE_OCT = (oCampos.MES_OCTUBRE != 0) ? (Decimal)oCampos.EJEC_OCT / (Decimal)oCampos.MES_OCTUBRE : oCampos.EJEC_OCT;
                                oCampos.AVANCE_NOV = (oCampos.MES_NOVIEMBRE != 0) ? (Decimal)oCampos.EJEC_NOV / (Decimal)oCampos.MES_NOVIEMBRE : oCampos.EJEC_NOV;
                                oCampos.AVANCE_DIC = (oCampos.MES_DICIEMBRE != 0) ? (Decimal)oCampos.EJEC_DIC / (Decimal)oCampos.MES_DICIEMBRE : oCampos.EJEC_DIC;
                                oCampos.TOTAL_EJEC = oCampos.EJEC_ENE + oCampos.EJEC_FEB + oCampos.EJEC_MAR + oCampos.EJEC_ABR + oCampos.EJEC_MAY + oCampos.EJEC_JUN + oCampos.EJEC_JUL + oCampos.EJEC_AGO + oCampos.EJEC_SET + oCampos.EJEC_OCT + oCampos.EJEC_NOV + oCampos.EJEC_DIC;
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
        public List<CEntidad> DatAvanceSupLinea(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC.spwAvancePOISuperv", oCEntidad))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            int p1 = dr.GetOrdinal("cNomOficina");
                            int p2 = dr.GetOrdinal("COD_LINEA");
                            int p3 = dr.GetOrdinal("TotalProgramado");
                            int p4 = dr.GetOrdinal("T1P");
                            int p5 = dr.GetOrdinal("T1E");
                            int p17 = dr.GetOrdinal("T1ECC");
                            int p7 = dr.GetOrdinal("T2P");
                            int p8 = dr.GetOrdinal("T2E");
                            int p18 = dr.GetOrdinal("T2ECC");
                            int p10 = dr.GetOrdinal("T3P");
                            int p11 = dr.GetOrdinal("T3E");
                            int p19 = dr.GetOrdinal("T3ECC");
                            int p13 = dr.GetOrdinal("T4P");
                            int p14 = dr.GetOrdinal("T4E");
                            int p20 = dr.GetOrdinal("T4ECC");
                            int p16 = dr.GetOrdinal("TotalEjecutado");
                            int p21 = dr.GetOrdinal("TotalEjecutadoCC");

                            CEntidad oCampos;
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                oCampos.nombre = dr.GetString(p1);
                                oCampos.COD_LINEA = dr.GetString(p2);
                                oCampos.TOTAL_Programado = dr.GetDouble(p3);
                                oCampos.T1Program = dr.GetDouble(p4);
                                oCampos.T1Ejecutado = dr.GetInt32(p5);
                                oCampos.T2Program = dr.GetDouble(p7);
                                oCampos.T2Ejecutado = dr.GetInt32(p8);
                                oCampos.T3Program = dr.GetDouble(p10);
                                oCampos.T3Ejecutado = dr.GetInt32(p11);
                                oCampos.T4Program = dr.GetDouble(p13);
                                oCampos.T4Ejecutado = dr.GetInt32(p14);
                                oCampos.TOTAL_EJEC = dr.GetInt32(p16);

                                oCampos.TOTAL_EjectCC = dr.GetInt32(p21);
                                oCampos.T1EjecutadoCC = dr.GetInt32(p17);
                                oCampos.T2EjecutadoCC = dr.GetInt32(p18);
                                oCampos.T3EjecutadoCC = dr.GetInt32(p19);
                                oCampos.T4EjecutadoCC = dr.GetInt32(p20);

                                oCampos.AvanceT1 = (oCampos.T1Program != 0) ? (Decimal)oCampos.T1Ejecutado / (Decimal)oCampos.T1Program : (Decimal)oCampos.T1Program;
                                oCampos.AvanceT2 = (oCampos.T2Program != 0) ? (Decimal)oCampos.T2Ejecutado / (Decimal)oCampos.T2Program : (Decimal)oCampos.T2Program;
                                oCampos.AvanceT3 = (oCampos.T3Program != 0) ? (Decimal)oCampos.T3Ejecutado / (Decimal)oCampos.T3Program : (Decimal)oCampos.T3Program;
                                oCampos.AvanceT4 = (oCampos.T4Program != 0) ? (Decimal)oCampos.T4Ejecutado / (Decimal)oCampos.T4Program : (Decimal)oCampos.T4Program;

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
        public List<CEntidad> DatInformeSupPOIDetalle(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC.spwAvancePOISuperv_Detalle", oCEntidad))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            int p1 = dr.GetOrdinal("Modalidad_Tipo");
                            int p2 = dr.GetOrdinal("TotalProgramado");
                            int p3 = dr.GetOrdinal("EneroProg");
                            int p4 = dr.GetOrdinal("EneroEjec");
                            int p40 = dr.GetOrdinal("EneroEjecCC");
                            int p6 = dr.GetOrdinal("FebProg");
                            int p7 = dr.GetOrdinal("FebEjec");
                            int p41 = dr.GetOrdinal("FebEjecCC");
                            int p9 = dr.GetOrdinal("MarzProg");
                            int p10 = dr.GetOrdinal("MarzEjec");
                            int p42 = dr.GetOrdinal("MarzEjecCC");
                            int p12 = dr.GetOrdinal("AbrilProg");
                            int p13 = dr.GetOrdinal("AbrilEjec");
                            int p43 = dr.GetOrdinal("AbrilEjecCC");
                            int p15 = dr.GetOrdinal("MayProg");
                            int p16 = dr.GetOrdinal("MayEjec");
                            int p44 = dr.GetOrdinal("MayEjecCC");
                            int p18 = dr.GetOrdinal("JunioProg");
                            int p19 = dr.GetOrdinal("JunEjec");
                            int p45 = dr.GetOrdinal("JunEjecCC");
                            int p21 = dr.GetOrdinal("JulioProg");
                            int p22 = dr.GetOrdinal("JulEjec");
                            int p46 = dr.GetOrdinal("JulEjecCC");
                            int p24 = dr.GetOrdinal("AgProg");
                            int p25 = dr.GetOrdinal("AgostEjec");
                            int p47 = dr.GetOrdinal("AgostEjecCC");
                            int p27 = dr.GetOrdinal("sepProg");
                            int p28 = dr.GetOrdinal("SeptEjec");
                            int p48 = dr.GetOrdinal("SeptEjecCC");
                            int p30 = dr.GetOrdinal("OctProg");
                            int p31 = dr.GetOrdinal("OctEjec");
                            int p49 = dr.GetOrdinal("OctEjecCC");
                            int p33 = dr.GetOrdinal("novProg");
                            int p34 = dr.GetOrdinal("NovEjec");
                            int p50 = dr.GetOrdinal("NovEjecCC");
                            int p36 = dr.GetOrdinal("DicProg");
                            int p37 = dr.GetOrdinal("DicEjec");
                            int p51 = dr.GetOrdinal("DicEjecCC");
                            int p39 = dr.GetOrdinal("TotalEjec");
                            int p52 = dr.GetOrdinal("TotalEjecCC");


                            CEntidad oCampos;
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                oCampos.MODALIDAD = dr.GetString(p1);
                                oCampos.TOTAL_ProgramadoD = dr.GetInt32(p2);
                                oCampos.MES_ENERO = dr.GetInt32(p3);
                                oCampos.EJEC_ENE = dr.GetInt32(p4);
                                oCampos.MES_FEBRERO = dr.GetInt32(p6);
                                oCampos.EJEC_FEB = dr.GetInt32(p7);
                                oCampos.MES_MARZO = dr.GetInt32(p9);
                                oCampos.EJEC_MAR = dr.GetInt32(p10);
                                oCampos.MES_ABRIL = dr.GetInt32(p12);
                                oCampos.EJEC_ABR = dr.GetInt32(p13);
                                oCampos.MES_MAYO = dr.GetInt32(p15);
                                oCampos.EJEC_MAY = dr.GetInt32(p16);
                                oCampos.MES_JUNIO = dr.GetInt32(p18);
                                oCampos.EJEC_JUN = dr.GetInt32(p19);
                                oCampos.MES_JULIO = dr.GetInt32(p21);
                                oCampos.EJEC_JUL = dr.GetInt32(p22);
                                oCampos.MES_AGOSTO = dr.GetInt32(p24);
                                oCampos.EJEC_AGO = dr.GetInt32(p25);
                                oCampos.MES_SETIEMBRE = dr.GetInt32(p27);
                                oCampos.EJEC_SET = dr.GetInt32(p28);
                                oCampos.MES_OCTUBRE = dr.GetInt32(p30);
                                oCampos.EJEC_OCT = dr.GetInt32(p31);
                                oCampos.MES_NOVIEMBRE = dr.GetInt32(p33);
                                oCampos.EJEC_NOV = dr.GetInt32(p34);
                                oCampos.MES_DICIEMBRE = dr.GetInt32(p36);
                                oCampos.EJEC_DIC = dr.GetInt32(p37);
                                oCampos.TOTAL_EJEC = dr.GetInt32(p39);


                                oCampos.EneroEjecCC = dr.GetInt32(p40);
                                oCampos.FebEjecCC = dr.GetInt32(p41);
                                oCampos.MarzEjecCC = dr.GetInt32(p42);
                                oCampos.AbrilEjecCC = dr.GetInt32(p43);
                                oCampos.MayEjecCC = dr.GetInt32(p44);
                                oCampos.JunEjecCC = dr.GetInt32(p45);
                                oCampos.JulEjecCC = dr.GetInt32(p46);
                                oCampos.AgostEjecCC = dr.GetInt32(p47);
                                oCampos.SeptEjecCC = dr.GetInt32(p48);
                                oCampos.OctEjecCC = dr.GetInt32(p49);
                                oCampos.NovEjecCC = dr.GetInt32(p50);
                                oCampos.DicEjecCC = dr.GetInt32(p51);

                                oCampos.TOTAL_EjectCC = dr.GetInt32(p52);

                                oCampos.AVANCE_ENE = (oCampos.MES_ENERO != 0) ? (Decimal)oCampos.EJEC_ENE / (Decimal)oCampos.MES_ENERO : oCampos.MES_ENERO;
                                oCampos.AVANCE_FEB = (oCampos.MES_FEBRERO != 0) ? (Decimal)oCampos.EJEC_FEB / (Decimal)oCampos.MES_FEBRERO : oCampos.MES_FEBRERO;
                                oCampos.AVANCE_MAR = (oCampos.MES_MARZO != 0) ? (Decimal)oCampos.EJEC_MAR / (Decimal)oCampos.MES_MARZO : oCampos.MES_MARZO;
                                oCampos.AVANCE_ABR = (oCampos.MES_ABRIL != 0) ? (Decimal)oCampos.EJEC_ABR / (Decimal)oCampos.MES_ABRIL : oCampos.MES_ABRIL;
                                oCampos.AVANCE_MAY = (oCampos.MES_MAYO != 0) ? (Decimal)oCampos.EJEC_MAY / (Decimal)oCampos.MES_MAYO : oCampos.MES_MAYO;
                                oCampos.AVANCE_JUN = (oCampos.MES_JUNIO != 0) ? (Decimal)oCampos.EJEC_JUN / (Decimal)oCampos.MES_JUNIO : oCampos.MES_JUNIO;
                                oCampos.AVANCE_JUL = (oCampos.MES_JULIO != 0) ? (Decimal)oCampos.EJEC_JUL / (Decimal)oCampos.MES_JULIO : oCampos.MES_JULIO;
                                oCampos.AVANCE_AGO = (oCampos.MES_AGOSTO != 0) ? (Decimal)oCampos.EJEC_AGO / (Decimal)oCampos.MES_AGOSTO : oCampos.MES_AGOSTO;
                                oCampos.AVANCE_SET = (oCampos.MES_SETIEMBRE != 0) ? (Decimal)oCampos.EJEC_SET / (Decimal)oCampos.MES_SETIEMBRE : oCampos.MES_SETIEMBRE;
                                oCampos.AVANCE_OCT = (oCampos.MES_OCTUBRE != 0) ? (Decimal)oCampos.EJEC_OCT / (Decimal)oCampos.MES_OCTUBRE : oCampos.MES_OCTUBRE;
                                oCampos.AVANCE_NOV = (oCampos.MES_NOVIEMBRE != 0) ? (Decimal)oCampos.EJEC_NOV / (Decimal)oCampos.MES_NOVIEMBRE : oCampos.MES_NOVIEMBRE;
                                oCampos.AVANCE_DIC = (oCampos.MES_DICIEMBRE != 0) ? (Decimal)oCampos.EJEC_DIC / (Decimal)oCampos.MES_DICIEMBRE : oCampos.MES_DICIEMBRE;
                                oCampos.AvanceT1 = (oCampos.TOTAL_ProgramadoD != 0) ? (Decimal)oCampos.TOTAL_EJEC / (Decimal)oCampos.TOTAL_ProgramadoD : oCampos.TOTAL_ProgramadoD;

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
        public List<CEntidad> DatPOIvsRD(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC.spwRDvsPOi", oCEntidad))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            int p1 = dr.GetOrdinal("cod");
                            int p2 = dr.GetOrdinal("cNomOficina");
                            int p3 = dr.GetOrdinal("cod_anterior");
                            int p4 = dr.GetOrdinal("Total_programado");
                            int p5 = dr.GetOrdinal("TP1");
                            int p6 = dr.GetOrdinal("TE1");
                            int p14 = dr.GetOrdinal("TE1CC");
                            int p7 = dr.GetOrdinal("TP2");
                            int p8 = dr.GetOrdinal("TE2");
                            int p15 = dr.GetOrdinal("TE2CC");
                            int p9 = dr.GetOrdinal("TP3");
                            int p10 = dr.GetOrdinal("TE3");
                            int p16 = dr.GetOrdinal("TE3CC");
                            int p11 = dr.GetOrdinal("TP4");
                            int p12 = dr.GetOrdinal("TE4");
                            int p17 = dr.GetOrdinal("TE4CC");
                            int p13 = dr.GetOrdinal("Total_Ejecutado");
                            int p18 = dr.GetOrdinal("Total_EjecutadoCC");

                            CEntidad oCampos;
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                oCampos.COD_LINEA = dr.GetString(p1);
                                oCampos.nombre = dr.GetString(p2);
                                oCampos.MODALIDAD = dr.GetString(p3);
                                oCampos.TOTAL_Programado = dr.GetDouble(p4);
                                oCampos.T1Program = dr.GetDouble(p5);
                                oCampos.T1Ejecutado = dr.GetInt32(p6);
                                oCampos.T2Program = dr.GetDouble(p7);
                                oCampos.T2Ejecutado = dr.GetInt32(p8);
                                oCampos.T3Program = dr.GetDouble(p9);
                                oCampos.T3Ejecutado = dr.GetInt32(p10);
                                oCampos.T4Program = dr.GetDouble(p11);
                                oCampos.T4Ejecutado = dr.GetInt32(p12);
                                oCampos.TOTAL_EJEC = dr.GetInt32(p13);

                                oCampos.T1EjecutadoCC = dr.GetInt32(p14);
                                oCampos.T2EjecutadoCC = dr.GetInt32(p15);
                                oCampos.T3EjecutadoCC = dr.GetInt32(p16);
                                oCampos.T4EjecutadoCC = dr.GetInt32(p17);
                                oCampos.TOTAL_EjectCC = dr.GetInt32(p18);


                                oCampos.AvanceT1 = (oCampos.T1Program != 0) ? (Decimal)oCampos.T1Ejecutado / (Decimal)oCampos.T1Program : (Decimal)oCampos.T1Program;
                                oCampos.AvanceT2 = (oCampos.T2Program != 0) ? (Decimal)oCampos.T2Ejecutado / (Decimal)oCampos.T2Program : (Decimal)oCampos.T2Program;
                                oCampos.AvanceT3 = (oCampos.T3Program != 0) ? (Decimal)oCampos.T3Ejecutado / (Decimal)oCampos.T3Program : (Decimal)oCampos.T3Program;
                                oCampos.AvanceT4 = (oCampos.T4Program != 0) ? (Decimal)oCampos.T4Ejecutado / (Decimal)oCampos.T4Program : (Decimal)oCampos.T4Program;
                                // oCampos.AVANCE_ENE = (oCampos.MES_ENERO != 0) ? (Decimal)oCampos.EJEC_ENE / (Decimal)oCampos.MES_ENERO : oCampos.EJEC_ENE;

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
        public List<CEntidad> DatPOIvsRDDetalle(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC.spwAvancePOIRD", oCEntidad))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            int p1 = dr.GetOrdinal("Programadas");
                            int p2 = dr.GetOrdinal("cod_anterior");
                            int p3 = dr.GetOrdinal("total_programadas");
                            int p4 = dr.GetOrdinal("Total_Ejec");
                            int p29 = dr.GetOrdinal("Total_EjecC");
                            int p5 = dr.GetOrdinal("Enero");
                            int p6 = dr.GetOrdinal("Ejec_Enero");
                            int p30 = dr.GetOrdinal("Ejec_EneroC");
                            int p7 = dr.GetOrdinal("Febrero");
                            int p8 = dr.GetOrdinal("Ejec_Febrero");
                            int p31 = dr.GetOrdinal("Ejec_FebreroC");
                            int p9 = dr.GetOrdinal("Marzo");
                            int p10 = dr.GetOrdinal("Ejec_Marzo");
                            int p32 = dr.GetOrdinal("Ejec_MarzoC");
                            int p11 = dr.GetOrdinal("Abril");
                            int p12 = dr.GetOrdinal("Ejec_Abril");
                            int p33 = dr.GetOrdinal("Ejec_AbrilC");
                            int p13 = dr.GetOrdinal("Mayo");
                            int p14 = dr.GetOrdinal("Ejec_Mayo");
                            int p34 = dr.GetOrdinal("Ejec_MayoC");
                            int p15 = dr.GetOrdinal("Junio");
                            int p16 = dr.GetOrdinal("Ejec_Junio");
                            int p35 = dr.GetOrdinal("Ejec_JunioC");
                            int p17 = dr.GetOrdinal("Julio");
                            int p18 = dr.GetOrdinal("Ejec_Julio");
                            int p36 = dr.GetOrdinal("Ejec_JulioC");
                            int p19 = dr.GetOrdinal("Agosto");
                            int p20 = dr.GetOrdinal("Ejec_Agosto");
                            int p37 = dr.GetOrdinal("Ejec_AgostoC");
                            int p21 = dr.GetOrdinal("Septiembre");
                            int p22 = dr.GetOrdinal("Ejec_Septiembre");
                            int p38 = dr.GetOrdinal("Ejec_SeptiembreC");
                            int p23 = dr.GetOrdinal("Octubre");
                            int p24 = dr.GetOrdinal("Ejec_Octubre");
                            int p39 = dr.GetOrdinal("Ejec_OctubreC");
                            int p25 = dr.GetOrdinal("Noviembre");
                            int p26 = dr.GetOrdinal("Ejec_Noviembre");
                            int p40 = dr.GetOrdinal("Ejec_NoviembreC");
                            int p27 = dr.GetOrdinal("Diciembre");
                            int p28 = dr.GetOrdinal("Ejec_Diciembre");
                            int p41 = dr.GetOrdinal("Ejec_DiciembreC");
                            CEntidad oCampos;
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                oCampos.MODALIDAD = dr.GetString(p1);
                                oCampos.TOTAL_Programado = dr.GetInt32(p3);
                                oCampos.TOTAL_EJEC = dr.GetInt32(p4);
                                oCampos.TOTAL_EjectCC = dr.GetInt32(p29);
                                oCampos.MES_ENERO = dr.GetInt32(p5);
                                oCampos.EJEC_ENE = dr.GetInt32(p6);
                                oCampos.EneroEjecCC = dr.GetInt32(p30);
                                oCampos.MES_FEBRERO = dr.GetInt32(p7);
                                oCampos.EJEC_FEB = dr.GetInt32(p8);
                                oCampos.FebEjecCC = dr.GetInt32(p31);
                                oCampos.MES_MARZO = dr.GetInt32(p9);
                                oCampos.EJEC_MAR = dr.GetInt32(p10);
                                oCampos.MarzEjecCC = dr.GetInt32(p32);
                                oCampos.MES_ABRIL = dr.GetInt32(p11);
                                oCampos.EJEC_ABR = dr.GetInt32(p12);
                                oCampos.AbrilEjecCC = dr.GetInt32(p33);
                                oCampos.MES_MAYO = dr.GetInt32(p13);
                                oCampos.EJEC_MAY = dr.GetInt32(p14);
                                oCampos.MayEjecCC = dr.GetInt32(p34);
                                oCampos.MES_JUNIO = dr.GetInt32(p15);
                                oCampos.EJEC_JUN = dr.GetInt32(p16);
                                oCampos.JunEjecCC = dr.GetInt32(p35);
                                oCampos.MES_JULIO = dr.GetInt32(p17);
                                oCampos.EJEC_JUL = dr.GetInt32(p18);
                                oCampos.JulEjecCC = dr.GetInt32(p36);
                                oCampos.MES_AGOSTO = dr.GetInt32(p19);
                                oCampos.EJEC_AGO = dr.GetInt32(p20);
                                oCampos.AgostEjecCC = dr.GetInt32(p37);
                                oCampos.MES_SETIEMBRE = dr.GetInt32(p21);
                                oCampos.EJEC_SET = dr.GetInt32(p22);
                                oCampos.SeptEjecCC = dr.GetInt32(p38);
                                oCampos.MES_OCTUBRE = dr.GetInt32(p23);
                                oCampos.EJEC_OCT = dr.GetInt32(p24);
                                oCampos.OctEjecCC = dr.GetInt32(p39);
                                oCampos.MES_NOVIEMBRE = dr.GetInt32(p25);
                                oCampos.EJEC_NOV = dr.GetInt32(p26);
                                oCampos.NovEjecCC = dr.GetInt32(p40);
                                oCampos.MES_DICIEMBRE = dr.GetInt32(p27);
                                oCampos.EJEC_DIC = dr.GetInt32(p28);
                                oCampos.DicEjecCC = dr.GetInt32(p41);

                                oCampos.AVANCE_ENE = (oCampos.MES_ENERO != 0) ? (Decimal)oCampos.EJEC_ENE / (Decimal)oCampos.MES_ENERO : oCampos.MES_ENERO;
                                oCampos.AVANCE_FEB = (oCampos.MES_FEBRERO != 0) ? (Decimal)oCampos.EJEC_FEB / (Decimal)oCampos.MES_FEBRERO : oCampos.MES_FEBRERO;
                                oCampos.AVANCE_MAR = (oCampos.MES_MARZO != 0) ? (Decimal)oCampos.EJEC_MAR / (Decimal)oCampos.MES_MARZO : oCampos.MES_MARZO;
                                oCampos.AVANCE_ABR = (oCampos.MES_ABRIL != 0) ? (Decimal)oCampos.EJEC_ABR / (Decimal)oCampos.MES_ABRIL : oCampos.MES_ABRIL;
                                oCampos.AVANCE_MAY = (oCampos.MES_MAYO != 0) ? (Decimal)oCampos.EJEC_MAY / (Decimal)oCampos.MES_MAYO : oCampos.MES_MAYO;
                                oCampos.AVANCE_JUN = (oCampos.MES_JUNIO != 0) ? (Decimal)oCampos.EJEC_JUN / (Decimal)oCampos.MES_JUNIO : oCampos.MES_JUNIO;
                                oCampos.AVANCE_JUL = (oCampos.MES_JULIO != 0) ? (Decimal)oCampos.EJEC_JUL / (Decimal)oCampos.MES_JULIO : oCampos.MES_JULIO;
                                oCampos.AVANCE_AGO = (oCampos.MES_AGOSTO != 0) ? (Decimal)oCampos.EJEC_AGO / (Decimal)oCampos.MES_AGOSTO : oCampos.MES_AGOSTO;
                                oCampos.AVANCE_SET = (oCampos.MES_SETIEMBRE != 0) ? (Decimal)oCampos.EJEC_SET / (Decimal)oCampos.MES_SETIEMBRE : oCampos.MES_SETIEMBRE;
                                oCampos.AVANCE_OCT = (oCampos.MES_OCTUBRE != 0) ? (Decimal)oCampos.EJEC_OCT / (Decimal)oCampos.MES_OCTUBRE : oCampos.MES_OCTUBRE;
                                oCampos.AVANCE_NOV = (oCampos.MES_NOVIEMBRE != 0) ? (Decimal)oCampos.EJEC_NOV / (Decimal)oCampos.MES_NOVIEMBRE : oCampos.MES_NOVIEMBRE;
                                oCampos.AVANCE_DIC = (oCampos.MES_DICIEMBRE != 0) ? (Decimal)oCampos.EJEC_DIC / (Decimal)oCampos.MES_DICIEMBRE : oCampos.MES_DICIEMBRE;


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
        public List<CEntidad> DatPOIvsInfLegalTF(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC.WAvancePOIvsInfLegal", oCEntidad))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            int p1 = dr.GetOrdinal("cod_tar");
                            int p2 = dr.GetOrdinal("Descripcion");
                            int p3 = dr.GetOrdinal("TotalProg");
                            int p4 = dr.GetOrdinal("EneP");
                            int p5 = dr.GetOrdinal("EneroE");
                            int p6 = dr.GetOrdinal("FebP");
                            int p7 = dr.GetOrdinal("FebreroE");
                            int p8 = dr.GetOrdinal("MarP");
                            int p9 = dr.GetOrdinal("MarzoE");
                            int p10 = dr.GetOrdinal("AbrP");
                            int p11 = dr.GetOrdinal("AbrilE");
                            int p12 = dr.GetOrdinal("MayP");
                            int p13 = dr.GetOrdinal("MayoE");
                            int p14 = dr.GetOrdinal("JunP");
                            int p15 = dr.GetOrdinal("JunioE");
                            int p16 = dr.GetOrdinal("JulP");
                            int p17 = dr.GetOrdinal("JulioE");
                            int p18 = dr.GetOrdinal("AgoP");
                            int p19 = dr.GetOrdinal("AgostoE");
                            int p20 = dr.GetOrdinal("SepP");
                            int p21 = dr.GetOrdinal("Septiembre");
                            int p22 = dr.GetOrdinal("OctP");
                            int p23 = dr.GetOrdinal("OctubreE");
                            int p24 = dr.GetOrdinal("NovP");
                            int p25 = dr.GetOrdinal("NoviembreE");
                            int p26 = dr.GetOrdinal("DicP");
                            int p27 = dr.GetOrdinal("DiciembreE");
                            int p28 = dr.GetOrdinal("TotalE");

                            CEntidad oCampos;
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                oCampos.MODALIDAD = dr.GetString(p1) + " - " + dr.GetString(p2);
                                oCampos.TOTAL_Programado = dr.GetInt32(p3);
                                oCampos.TOTAL_EJEC = dr.GetInt32(p28);
                                oCampos.MES_ENERO = dr.GetInt32(p4);
                                oCampos.EJEC_ENE = dr.GetInt32(p5);
                                oCampos.MES_FEBRERO = dr.GetInt32(p6);
                                oCampos.EJEC_FEB = dr.GetInt32(p7);
                                oCampos.MES_MARZO = dr.GetInt32(p8);
                                oCampos.EJEC_MAR = dr.GetInt32(p9);
                                oCampos.MES_ABRIL = dr.GetInt32(p10);
                                oCampos.EJEC_ABR = dr.GetInt32(p11);
                                oCampos.MES_MAYO = dr.GetInt32(p12);
                                oCampos.EJEC_MAY = dr.GetInt32(p13);
                                oCampos.MES_JUNIO = dr.GetInt32(p14);
                                oCampos.EJEC_JUN = dr.GetInt32(p15);
                                oCampos.MES_JULIO = dr.GetInt32(p16);
                                oCampos.EJEC_JUL = dr.GetInt32(p17);
                                oCampos.MES_AGOSTO = dr.GetInt32(p18);
                                oCampos.EJEC_AGO = dr.GetInt32(p19);
                                oCampos.MES_SETIEMBRE = dr.GetInt32(p20);
                                oCampos.EJEC_SET = dr.GetInt32(p21);
                                oCampos.MES_OCTUBRE = dr.GetInt32(p22);
                                oCampos.EJEC_OCT = dr.GetInt32(p23);
                                oCampos.MES_NOVIEMBRE = dr.GetInt32(p24);
                                oCampos.EJEC_NOV = dr.GetInt32(p25);
                                oCampos.MES_DICIEMBRE = dr.GetInt32(p26);
                                oCampos.EJEC_DIC = dr.GetInt32(p27);

                                oCampos.AVANCE_ENE = (oCampos.MES_ENERO != 0) ? (Decimal)oCampos.EJEC_ENE / (Decimal)oCampos.MES_ENERO : oCampos.MES_ENERO;
                                oCampos.AVANCE_FEB = (oCampos.MES_FEBRERO != 0) ? (Decimal)oCampos.EJEC_FEB / (Decimal)oCampos.MES_FEBRERO : oCampos.MES_FEBRERO;
                                oCampos.AVANCE_MAR = (oCampos.MES_MARZO != 0) ? (Decimal)oCampos.EJEC_MAR / (Decimal)oCampos.MES_MARZO : oCampos.MES_MARZO;
                                oCampos.AVANCE_ABR = (oCampos.MES_ABRIL != 0) ? (Decimal)oCampos.EJEC_ABR / (Decimal)oCampos.MES_ABRIL : oCampos.MES_ABRIL;
                                oCampos.AVANCE_MAY = (oCampos.MES_MAYO != 0) ? (Decimal)oCampos.EJEC_MAY / (Decimal)oCampos.MES_MAYO : oCampos.MES_MAYO;
                                oCampos.AVANCE_JUN = (oCampos.MES_JUNIO != 0) ? (Decimal)oCampos.EJEC_JUN / (Decimal)oCampos.MES_JUNIO : oCampos.MES_JUNIO;
                                oCampos.AVANCE_JUL = (oCampos.MES_JULIO != 0) ? (Decimal)oCampos.EJEC_JUL / (Decimal)oCampos.MES_JULIO : oCampos.MES_JULIO;
                                oCampos.AVANCE_AGO = (oCampos.MES_AGOSTO != 0) ? (Decimal)oCampos.EJEC_AGO / (Decimal)oCampos.MES_AGOSTO : oCampos.MES_AGOSTO;
                                oCampos.AVANCE_SET = (oCampos.MES_SETIEMBRE != 0) ? (Decimal)oCampos.EJEC_SET / (Decimal)oCampos.MES_SETIEMBRE : oCampos.MES_SETIEMBRE;
                                oCampos.AVANCE_OCT = (oCampos.MES_OCTUBRE != 0) ? (Decimal)oCampos.EJEC_OCT / (Decimal)oCampos.MES_OCTUBRE : oCampos.MES_OCTUBRE;
                                oCampos.AVANCE_NOV = (oCampos.MES_NOVIEMBRE != 0) ? (Decimal)oCampos.EJEC_NOV / (Decimal)oCampos.MES_NOVIEMBRE : oCampos.MES_NOVIEMBRE;
                                oCampos.AVANCE_DIC = (oCampos.MES_DICIEMBRE != 0) ? (Decimal)oCampos.EJEC_DIC / (Decimal)oCampos.MES_DICIEMBRE : oCampos.MES_DICIEMBRE;
                                oCampos.AvanceT1 = (oCampos.TOTAL_Programado != 0) ? (Decimal)oCampos.TOTAL_EJEC / (Decimal)oCampos.TOTAL_Programado : oCampos.TOTAL_ProgramadoD;


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
        public List<CEntidad> DatPOIvsLegal(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC.spwAvancePOIInfTecL", oCEntidad))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            int p1 = dr.GetOrdinal("cod");
                            int p2 = dr.GetOrdinal("cNomOficina");
                            int p3 = dr.GetOrdinal("cod_anterior");
                            int p4 = dr.GetOrdinal("Total_programado");
                            int p5 = dr.GetOrdinal("TP1");
                            int p6 = dr.GetOrdinal("TE1");
                            int p14 = dr.GetOrdinal("TE1CC");
                            int p7 = dr.GetOrdinal("TP2");
                            int p8 = dr.GetOrdinal("TE2");
                            int p15 = dr.GetOrdinal("TE2CC");
                            int p9 = dr.GetOrdinal("TP3");
                            int p10 = dr.GetOrdinal("TE3");
                            int p16 = dr.GetOrdinal("TE3CC");
                            int p11 = dr.GetOrdinal("TP4");
                            int p12 = dr.GetOrdinal("TE4");
                            int p17 = dr.GetOrdinal("TE4CC");
                            int p13 = dr.GetOrdinal("Total_Ejecutado");
                            int p18 = dr.GetOrdinal("Total_EjecutadoCC");

                            CEntidad oCampos;
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                oCampos.COD_LINEA = dr.GetString(p1);
                                oCampos.nombre = dr.GetString(p2);
                                oCampos.MODALIDAD = dr.GetString(p3);
                                oCampos.TOTAL_Programado = System.Convert.ToDouble(dr.GetInt32(p4));
                                oCampos.T1Program = System.Convert.ToDouble(dr.GetInt32(p5));
                                oCampos.T1Ejecutado = dr.GetInt32(p6);
                                oCampos.T2Program = System.Convert.ToDouble(dr.GetInt32(p7));
                                oCampos.T2Ejecutado = dr.GetInt32(p8);
                                oCampos.T3Program = System.Convert.ToDouble(dr.GetInt32(p9));
                                oCampos.T3Ejecutado = dr.GetInt32(p10);
                                oCampos.T4Program = System.Convert.ToDouble(dr.GetInt32(p11));
                                oCampos.T4Ejecutado = dr.GetInt32(p12);
                                oCampos.TOTAL_EJEC = dr.GetInt32(p13);

                                oCampos.T1EjecutadoCC = dr.GetInt32(p14);
                                oCampos.T2EjecutadoCC = dr.GetInt32(p15);
                                oCampos.T3EjecutadoCC = dr.GetInt32(p16);
                                oCampos.T4EjecutadoCC = dr.GetInt32(p17);
                                oCampos.TOTAL_EjectCC = dr.GetInt32(p18);


                                oCampos.AvanceT1 = (oCampos.T1Program != 0) ? (Decimal)oCampos.T1Ejecutado / (Decimal)oCampos.T1Program : (Decimal)oCampos.T1Program;
                                oCampos.AvanceT2 = (oCampos.T2Program != 0) ? (Decimal)oCampos.T2Ejecutado / (Decimal)oCampos.T2Program : (Decimal)oCampos.T2Program;
                                oCampos.AvanceT3 = (oCampos.T3Program != 0) ? (Decimal)oCampos.T3Ejecutado / (Decimal)oCampos.T3Program : (Decimal)oCampos.T3Program;
                                oCampos.AvanceT4 = (oCampos.T4Program != 0) ? (Decimal)oCampos.T4Ejecutado / (Decimal)oCampos.T4Program : (Decimal)oCampos.T4Program;
                                // oCampos.AVANCE_ENE = (oCampos.MES_ENERO != 0) ? (Decimal)oCampos.EJEC_ENE / (Decimal)oCampos.MES_ENERO : oCampos.EJEC_ENE;

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
