using System;
using System.Collections.Generic;
//using CapaEntidadDet =  CapaEntidad.DOC.Ent_ControlCalidad;
//using System.Data.SqlClient;
using CEntidad = CapaEntidad.DOC.Ent_Reporte_DigitadoresOD;
using GeneralSQL;
using Oracle.ManagedDataAccess.Client;
//using SQL = GeneralSQL.Data.SQL;


namespace CapaDatos.DOC
{
    /// <summary>
    /// 
    /// </summary>
    public class Dat_ReporteDigitadoresOD
    {
        //private SQL oGDataSQL = new SQL();
        private DBOracle dBOracle = new DBOracle();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public CEntidad Dat_DigitadoresOD(OracleConnection cn, CEntidad oCEntidad)
        {
            CEntidad oCampos = null;
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC.new_REPORTE_AvanceDigitadorOD", oCEntidad))
                {
                    if (dr != null)
                    {
                        oCampos = new CEntidad();
                        List<CEntidad> lsDetDetalles;
                        CEntidad oCamposDet;
                        //
                        //Modalidad
                        lsDetDetalles = new List<CEntidad>();
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("DIGITADOR");
                            int pt2 = dr.GetOrdinal("OD");
                            int pt3 = dr.GetOrdinal("POA");
                            int pt4 = dr.GetOrdinal("PL");
                            int pt5 = dr.GetOrdinal("REGISTROS");
                            while (dr.Read())
                            {
                                //PARTE_DIARIO_DETALLE
                                oCamposDet = new CEntidad();
                                oCamposDet.DIGITADOR = dr.GetString(pt1);
                                oCamposDet.OD = dr.GetString(pt2);
                                oCamposDet.POA = dr.GetInt32(pt3);
                                oCamposDet.PL = dr.GetInt32(pt4);
                                oCamposDet.REGISTROS = dr.GetInt32(pt5);
                                lsDetDetalles.Add(oCamposDet);
                            }
                        }
                        oCampos.ListDigitadores = lsDetDetalles;

                        dr.NextResult();

                        lsDetDetalles = new List<CEntidad>();
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("DESCRIPCION");

                            while (dr.Read())
                            {
                                //PARTE_DIARIO_DETALLE
                                oCamposDet = new CEntidad();
                                oCamposDet.OD = dr.GetString(pt1);
                                lsDetDetalles.Add(oCamposDet);
                            }
                        }
                        oCampos.ListOD = lsDetDetalles;

                        dr.NextResult();

                        lsDetDetalles = new List<CEntidad>();
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("APELLIDOS_NOMBRES");
                            int pt2 = dr.GetOrdinal("DESCRIPCION");
                            int pt3 = dr.GetOrdinal("SUPERVISIONES");

                            while (dr.Read())
                            {
                                //PARTE_DIARIO_DETALLE
                                oCamposDet = new CEntidad();
                                oCamposDet.SUPERVISOR = dr.GetString(pt1);
                                oCamposDet.OD = dr.GetString(pt2);
                                oCamposDet.NUM_SUPERVISION = dr.GetInt32(pt3);
                                lsDetDetalles.Add(oCamposDet);
                            }
                        }
                        oCampos.ListSupervisores = lsDetDetalles;

                        dr.NextResult();

                        lsDetDetalles = new List<CEntidad>();
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("APELLIDOS_NOMBRES");
                            int pt2 = dr.GetOrdinal("DESCRIPCION");
                            int pt3 = dr.GetOrdinal("CARTNOTIFICACION");

                            while (dr.Read())
                            {
                                //PARTE_DIARIO_DETALLE
                                oCamposDet = new CEntidad();
                                oCamposDet.NOTIFICADOR = dr.GetString(pt1);
                                oCamposDet.OD = dr.GetString(pt2);
                                oCamposDet.NUM_NOTIFICACION = dr.GetInt32(pt3);
                                lsDetDetalles.Add(oCamposDet);
                            }
                        }
                        oCampos.ListNotificadores = lsDetDetalles;
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
        public CEntidad Dat_ResumenDetalleOD(OracleConnection cn, CEntidad oCEntidad)
        {
            CEntidad oCampos = null;
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC.new_REPORTE_AvanceDetalladoOD", oCEntidad))
                {
                    if (dr != null)
                    {
                        oCampos = new CEntidad();
                        List<CEntidad> lsDetDetalles;
                        CEntidad oCamposDet;
                        //
                        //Modalidad
                        lsDetDetalles = new List<CEntidad>();
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("ANIO");
                            int pt2 = dr.GetOrdinal("MESES");
                            int pt9 = dr.GetOrdinal("MES");
                            int pt3 = dr.GetOrdinal("TH");
                            int pt4 = dr.GetOrdinal("POA");
                            int pt5 = dr.GetOrdinal("CARTA_NOTIFICACION");
                            int pt6 = dr.GetOrdinal("INFORME");
                            int pt7 = dr.GetOrdinal("PNOTIFICACION");
                            int pt8 = dr.GetOrdinal("PSUPERVISION");
                            int pt10 = dr.GetOrdinal("TOTAL");
                            int pt11 = dr.GetOrdinal("RD");
                            int pt12 = dr.GetOrdinal("ILEG");
                            int pt13 = dr.GetOrdinal("INTEC");
                            int pt14 = dr.GetOrdinal("INTIT");
                            int pt15 = dr.GetOrdinal("TOTALGENERAL");

                            while (dr.Read())
                            {
                                //PARTE_DIARIO_DETALLE
                                oCamposDet = new CEntidad();
                                oCamposDet.BusAnio = dr.GetString(pt1);
                                oCamposDet.MESES = dr.GetString(pt2);
                                oCamposDet.FECHA = String.Format("{0} - {1}", oCamposDet.BusAnio, oCamposDet.MESES);
                                oCamposDet.BusMes = dr.GetString(pt9);
                                oCamposDet.TITULO_HABILITANTE = dr.GetInt32(pt3);
                                oCamposDet.POA = dr.GetInt32(pt4);
                                oCamposDet.NUM_NOTIFICACION = dr.GetInt32(pt5);
                                oCamposDet.NUM_SUPERVISION = dr.GetInt32(pt6);
                                oCamposDet.PNOTIFICACION = dr.GetInt32(pt7);
                                oCamposDet.PSUPERVISION = dr.GetInt32(pt8);
                                oCamposDet.TOTAL = dr.GetInt32(pt10);
                                oCamposDet.Item1 = dr.GetInt32(pt11);
                                oCamposDet.Item2 = dr.GetInt32(pt12);
                                oCamposDet.Item3 = dr.GetInt32(pt13);
                                oCamposDet.Item4 = dr.GetInt32(pt14);
                                oCamposDet.Item5 = dr.GetInt32(pt15);
                                lsDetDetalles.Add(oCamposDet);
                            }
                        }
                        oCampos.ListOD = lsDetDetalles;

                        dr.NextResult();

                        lsDetDetalles = new List<CEntidad>();
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("NOMBRES");
                            int pt2 = dr.GetOrdinal("DESCRIPCION");
                            int pt8 = dr.GetOrdinal("ESTADO_ORIGEN");
                            int pt3 = dr.GetOrdinal("1ERASEMANA");
                            int pt4 = dr.GetOrdinal("2DASEMANA");
                            int pt5 = dr.GetOrdinal("3DASEMANA");
                            int pt6 = dr.GetOrdinal("4TASEMANA");
                            int pt7 = dr.GetOrdinal("5DASEMANA");
                            int pt9 = dr.GetOrdinal("COD_UCUENTA");


                            while (dr.Read())
                            {
                                //PARTE_DIARIO_DETALLE
                                oCamposDet = new CEntidad();
                                oCamposDet.DIGITADOR = dr.GetString(pt1);
                                oCamposDet.CARGO = dr.GetString(pt2);
                                oCamposDet.TIPO = dr.GetString(pt8);
                                oCamposDet.SEMANA1 = dr.GetInt32(pt3);
                                oCamposDet.SEMANA2 = dr.GetInt32(pt4);
                                oCamposDet.SEMANA3 = dr.GetInt32(pt5);
                                oCamposDet.SEMANA4 = dr.GetInt32(pt6);
                                oCamposDet.SEMANA5 = dr.GetInt32(pt7);
                                oCamposDet.COD_UCUENTA = dr.GetString(pt9);
                                lsDetDetalles.Add(oCamposDet);
                            }
                        }
                        oCampos.ListDigitadores = lsDetDetalles;

                        //RESOLUCION
                        dr.NextResult();

                        lsDetDetalles = new List<CEntidad>();
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("APELLIDOS_NOMBRES");
                            int pt2 = dr.GetOrdinal("AIS");
                            int pt3 = dr.GetOrdinal("RDI");
                            int pt4 = dr.GetOrdinal("AP");
                            int pt5 = dr.GetOrdinal("RDT");
                            int pt6 = dr.GetOrdinal("RE");
                            int pt7 = dr.GetOrdinal("AEP");
                            int pt8 = dr.GetOrdinal("RR");
                            int pt9 = dr.GetOrdinal("MC");
                            int pt10 = dr.GetOrdinal("OTRO");
                            int pt11 = dr.GetOrdinal("TOTAL");

                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.APELLIDOS_NOMBRES = dr.GetString(pt1);
                                oCamposDet.Item1 = dr.GetInt32(pt2);
                                oCamposDet.Item2 = dr.GetInt32(pt3);
                                oCamposDet.Item3 = dr.GetInt32(pt4);
                                oCamposDet.Item4 = dr.GetInt32(pt5);
                                oCamposDet.Item5 = dr.GetInt32(pt6);
                                oCamposDet.Item6 = dr.GetInt32(pt7);
                                oCamposDet.Item7 = dr.GetInt32(pt8);
                                oCamposDet.Item8 = dr.GetInt32(pt9);
                                oCamposDet.Item9 = dr.GetInt32(pt10);
                                oCamposDet.TOTAL = dr.GetInt32(pt11);
                                lsDetDetalles.Add(oCamposDet);
                            }
                        }
                        oCampos.ListResoluciones = lsDetDetalles;

                        //INFORME LEGAL
                        dr.NextResult();

                        lsDetDetalles = new List<CEntidad>();
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("APELLIDOS_NOMBRES");
                            int pt2 = dr.GetOrdinal("EIS");
                            int pt3 = dr.GetOrdinal("EEI");
                            int pt4 = dr.GetOrdinal("DC");
                            int pt5 = dr.GetOrdinal("ERR");
                            int pt6 = dr.GetOrdinal("OTRO");
                            int pt7 = dr.GetOrdinal("TOTAL");

                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.APELLIDOS_NOMBRES = dr.GetString(pt1);
                                oCamposDet.Item1 = dr.GetInt32(pt2);
                                oCamposDet.Item2 = dr.GetInt32(pt3);
                                oCamposDet.Item3 = dr.GetInt32(pt4);
                                oCamposDet.Item4 = dr.GetInt32(pt5);
                                oCamposDet.Item5 = dr.GetInt32(pt6);
                                oCamposDet.TOTAL = dr.GetInt32(pt7);
                                lsDetDetalles.Add(oCamposDet);
                            }
                        }
                        oCampos.ListInformeLegales = lsDetDetalles;

                        //NOTIFICACIONES DE FISCALIZACION
                        dr.NextResult();

                        lsDetDetalles = new List<CEntidad>();
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("APELLIDOS_NOMBRES");
                            int pt2 = dr.GetOrdinal("AIS");
                            int pt3 = dr.GetOrdinal("RIS");
                            int pt4 = dr.GetOrdinal("RIP");
                            int pt5 = dr.GetOrdinal("RAP");
                            int pt6 = dr.GetOrdinal("RTP");
                            int pt7 = dr.GetOrdinal("RR");
                            int pt8 = dr.GetOrdinal("REP");
                            int pt9 = dr.GetOrdinal("RRR");
                            int pt10 = dr.GetOrdinal("RMC");
                            int pt11 = dr.GetOrdinal("OTRO");
                            int pt12 = dr.GetOrdinal("TOTAL");
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.APELLIDOS_NOMBRES = dr.GetString(pt1);
                                oCamposDet.Item1 = dr.GetInt32(pt2);
                                oCamposDet.Item2 = dr.GetInt32(pt3);
                                oCamposDet.Item3 = dr.GetInt32(pt4);
                                oCamposDet.Item4 = dr.GetInt32(pt5);
                                oCamposDet.Item5 = dr.GetInt32(pt6);
                                oCamposDet.Item6 = dr.GetInt32(pt7);
                                oCamposDet.Item7 = dr.GetInt32(pt8);
                                oCamposDet.Item8 = dr.GetInt32(pt9);
                                oCamposDet.Item9 = dr.GetInt32(pt10);
                                oCamposDet.Item10 = dr.GetInt32(pt11);
                                oCamposDet.TOTAL = dr.GetInt32(pt12);
                                lsDetDetalles.Add(oCamposDet);
                            }
                        }
                        oCampos.ListNotificadores = lsDetDetalles;

                        //IMFORMACION PRESENTADA POR TITULAR
                        dr.NextResult();

                        lsDetDetalles = new List<CEntidad>();
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("APELLIDOS_NOMBRES");
                            int pt2 = dr.GetOrdinal("INF_DESCA");
                            int pt3 = dr.GetOrdinal("SOL_VAR_MED_CA");
                            int pt4 = dr.GetOrdinal("INF_AUDI_ORAL");
                            int pt5 = dr.GetOrdinal("INSP_OCUL");
                            int pt6 = dr.GetOrdinal("AMPL_DESC");
                            int pt7 = dr.GetOrdinal("FRAC_MULT");
                            int pt8 = dr.GetOrdinal("REC_RECONS");
                            int pt9 = dr.GetOrdinal("REC_APEL");
                            int pt10 = dr.GetOrdinal("SOLIC_INF");
                            int pt11 = dr.GetOrdinal("TOTAL");

                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.APELLIDOS_NOMBRES = dr.GetString(pt1);
                                oCamposDet.Item1 = dr.GetInt32(pt2);
                                oCamposDet.Item2 = dr.GetInt32(pt3);
                                oCamposDet.Item3 = dr.GetInt32(pt4);
                                oCamposDet.Item4 = dr.GetInt32(pt5);
                                oCamposDet.Item5 = dr.GetInt32(pt6);
                                oCamposDet.Item6 = dr.GetInt32(pt7);
                                oCamposDet.Item7 = dr.GetInt32(pt8);
                                oCamposDet.Item8 = dr.GetInt32(pt9);
                                oCamposDet.Item9 = dr.GetInt32(pt10);
                                oCamposDet.TOTAL = dr.GetInt32(pt11);
                                lsDetDetalles.Add(oCamposDet);
                            }
                        }
                        oCampos.ListInformacionTitular = lsDetDetalles;

                        //IMFORME TÉCNICO
                        dr.NextResult();

                        lsDetDetalles = new List<CEntidad>();
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("APELLIDOS_NOMBRES");
                            int pt2 = dr.GetOrdinal("EVAL_DESC");
                            int pt3 = dr.GetOrdinal("INFOR_DETER_MULT");
                            int pt4 = dr.GetOrdinal("FORM_DETER_MULT");
                            int pt5 = dr.GetOrdinal("INFOR_COMPL");
                            int pt6 = dr.GetOrdinal("INFOR_ACLA");
                            int pt7 = dr.GetOrdinal("ISPEC_OCUL");
                            int pt8 = dr.GetOrdinal("OTROS");
                            int pt9 = dr.GetOrdinal("TOTAL");

                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.APELLIDOS_NOMBRES = dr.GetString(pt1);
                                oCamposDet.Item1 = dr.GetInt32(pt2);
                                oCamposDet.Item2 = dr.GetInt32(pt3);
                                oCamposDet.Item3 = dr.GetInt32(pt4);
                                oCamposDet.Item4 = dr.GetInt32(pt5);
                                oCamposDet.Item5 = dr.GetInt32(pt6);
                                oCamposDet.Item6 = dr.GetInt32(pt7);
                                oCamposDet.Item7 = dr.GetInt32(pt8);
                                oCamposDet.TOTAL = dr.GetInt32(pt9);
                                lsDetDetalles.Add(oCamposDet);
                            }
                        }
                        oCampos.ListInformeTecnicos = lsDetDetalles;
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
        public List<CEntidad> Dat_SemanaDetalle(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC.new_REPORTE_AvanceRelacionOD", oCEntidad))
                {
                    if (dr != null)
                    {
                        if (oCEntidad.BusCriterio == "POA")
                        {
                            if (dr.HasRows)
                            {
                                int p1 = dr.GetOrdinal("cod_thabilitante");
                                int p2 = dr.GetOrdinal("NUMERO");
                                int p3 = dr.GetOrdinal("APELLIDOS_NOMBRES");
                                int p4 = dr.GetOrdinal("UBIGEO");
                                int p5 = dr.GetOrdinal("FECHA_CREACION");
                                int p6 = dr.GetOrdinal("NUM_POA");
                                int p7 = dr.GetOrdinal("REGISTROS");
                                int p8 = dr.GetOrdinal("ESTADO_ORIGEN");

                                CEntidad oCampos;
                                while (dr.Read())
                                {
                                    oCampos = new CEntidad();
                                    oCampos.COD_UCUENTA = dr.GetString(p1);
                                    oCampos.TH = dr.GetString(p2);
                                    oCampos.APELLIDOS_NOMBRES = dr.GetString(p3);
                                    oCampos.UBIGEO = dr.GetString(p4);
                                    oCampos.FECHA = dr.GetString(p5);
                                    oCampos.POA = dr.GetInt32(p6);
                                    oCampos.TOTAL = dr.GetInt32(p7);
                                    oCampos.TIPO = dr.GetString(p8);
                                    lsCEntidad.Add(oCampos);
                                }
                            }
                        }
                        else
                        {
                            if (oCEntidad.BusCriterio == "NOTIFICACION")
                            {
                                if (dr.HasRows)
                                {
                                    int p1 = dr.GetOrdinal("COD_FISNOTI");
                                    int p2 = dr.GetOrdinal("NUMERO");
                                    int p3 = dr.GetOrdinal("APELLIDOS_NOMBRES");
                                    int p4 = dr.GetOrdinal("NUMERO_NOTIFICACION");
                                    //int p5 = dr.GetOrdinal("NUMERO_RESOLUCION");
                                    int p6 = dr.GetOrdinal("DESCRIPCION");
                                    int p7 = dr.GetOrdinal("fecha_creacion");

                                    CEntidad oCampos;
                                    while (dr.Read())
                                    {
                                        oCampos = new CEntidad();
                                        oCampos.COD_UCUENTA = dr.GetString(p1);
                                        oCampos.TH = dr.GetString(p2);
                                        oCampos.APELLIDOS_NOMBRES = dr.GetString(p3);
                                        oCampos.NOTIFICADOR = dr.GetString(p4);
                                        //oCampos.RESOLUCION = dr.GetString(p5);
                                        oCampos.TIPO = dr.GetString(p6);
                                        oCampos.FECHA = dr.GetString(p7);
                                        lsCEntidad.Add(oCampos);
                                    }
                                }

                            }
                            else
                            {
                                if (oCEntidad.BusCriterio == "INFORME")
                                {
                                    if (dr.HasRows)
                                    {
                                        int p1 = dr.GetOrdinal("COD_INFORME");
                                        int p2 = dr.GetOrdinal("TH");
                                        int p3 = dr.GetOrdinal("APELLIDOS_NOMBRES");
                                        int p4 = dr.GetOrdinal("FECHA_INICIO_SUPERVISION");
                                        int p5 = dr.GetOrdinal("FECHA_FIN_SUPERVISION");
                                        int p6 = dr.GetOrdinal("NUMERO");

                                        CEntidad oCampos;
                                        while (dr.Read())
                                        {
                                            oCampos = new CEntidad();
                                            oCampos.COD_UCUENTA = dr.GetString(p1);
                                            oCampos.TH = dr.GetString(p2);
                                            oCampos.APELLIDOS_NOMBRES = dr.GetString(p3);
                                            oCampos.FECHA = dr.GetString(p4);
                                            oCampos.FECHAFIN = dr.GetString(p5);
                                            oCampos.BusCriterio = dr.GetString(p6);
                                            lsCEntidad.Add(oCampos);
                                        }
                                    }
                                }
                                else
                                {
                                    if (dr.HasRows)
                                    {
                                        int p1 = dr.GetOrdinal("COD_PSUPERVISION");
                                        int p2 = dr.GetOrdinal("NUMERO");
                                        int p3 = dr.GetOrdinal("APELLIDOS_NOMBRES");
                                        int p4 = dr.GetOrdinal("NUMERO_DOC");
                                        int p5 = dr.GetOrdinal("ESTADO_ORIGEN");

                                        CEntidad oCampos;
                                        while (dr.Read())
                                        {
                                            oCampos = new CEntidad();
                                            oCampos.COD_UCUENTA = dr.GetString(p1);
                                            oCampos.TH = dr.GetString(p2);
                                            oCampos.APELLIDOS_NOMBRES = dr.GetString(p3);
                                            oCampos.SUPERVISOR = dr.GetString(p4);
                                            oCampos.TIPO = dr.GetString(p5);
                                            lsCEntidad.Add(oCampos);
                                        }
                                    }
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
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public List<CEntidad> Dat_AvanceODAnual(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC.new_REPORTE_AvancegeneralAnualOD", oCEntidad))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            int p2 = dr.GetOrdinal("OD");
                            int p3 = dr.GetOrdinal("MESES");
                            int p4 = dr.GetOrdinal("TH");
                            int p5 = dr.GetOrdinal("POA");
                            int p6 = dr.GetOrdinal("CARTA_NOTIFICACION");
                            int p7 = dr.GetOrdinal("PRESUPUESTO");
                            int p8 = dr.GetOrdinal("INFORME");
                            int p9 = dr.GetOrdinal("TOTAL");

                            CEntidad oCampos;
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                oCampos.OD = dr.GetString(p2);
                                oCampos.MESES = dr.GetString(p3);
                                oCampos.TITULO_HABILITANTE = dr.GetInt32(p4);
                                oCampos.POA = dr.GetInt32(p5);
                                oCampos.PNOTIFICACION = dr.GetInt32(p6);
                                oCampos.PSUPERVISION = dr.GetInt32(p7); //PRESUPUESTO
                                oCampos.NUM_SUPERVISION = dr.GetInt32(p8);
                                oCampos.TOTAL = dr.GetInt32(p9);
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
        public List<CEntidad> Dat_RelacionOD(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC.new_REPORTE_AvanceRelacionODMesImprimir", oCEntidad))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            int p2 = dr.GetOrdinal("NUMERO");
                            int p3 = dr.GetOrdinal("APELLIDOS_NOMBRES");
                            int p4 = dr.GetOrdinal("NUMERO_NOTIFICACION");
                            int p5 = dr.GetOrdinal("FECHA_NOTIFICACION");
                            int p6 = dr.GetOrdinal("DESCRIPCION");

                            CEntidad oCampos;
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                oCampos.TH = dr.GetString(p2);
                                oCampos.APELLIDOS_NOMBRES = dr.GetString(p3);
                                oCampos.NOTIFICADOR = dr.GetString(p4);
                                oCampos.FECHA = dr.GetString(p5);
                                oCampos.TIPO = dr.GetString(p6);
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
        public CEntidad Dat_VerificacionOD(OracleConnection cn, CEntidad oCEntidad)
        {
            CEntidad oCampos = null;
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC.new_REPORTE_Verificacion", oCEntidad))
                {
                    if (dr != null)
                    {
                        oCampos = new CEntidad();
                        List<CEntidad> lsDetDetalles;
                        CEntidad oCamposDet;
                        //
                        //Verificacion General
                        lsDetDetalles = new List<CEntidad>();
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("DESCRIPCION");
                            int pt2 = dr.GetOrdinal("DOC_INGRESADOS");
                            int pt3 = dr.GetOrdinal("VERIFICADOS");
                            int pt4 = dr.GetOrdinal("AVANCE");

                            while (dr.Read())
                            {
                                //PARTE_DIARIO_DETALLE
                                oCamposDet = new CEntidad();
                                oCamposDet.OD = dr.GetString(pt1);
                                oCamposDet.REGISTROS = dr.GetInt32(pt2);
                                oCamposDet.TOTAL = dr.GetInt32(pt3);
                                oCamposDet.AVANCE = dr.GetDecimal(pt4);
                                lsDetDetalles.Add(oCamposDet);
                            }
                        }
                        oCampos.ListOD = lsDetDetalles;

                        dr.NextResult();

                        lsDetDetalles = new List<CEntidad>();
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("DESCRIPCION");
                            int pt2 = dr.GetOrdinal("NUMERO");
                            int pt3 = dr.GetOrdinal("MES");
                            int pt4 = dr.GetOrdinal("TIPO");
                            int pt5 = dr.GetOrdinal("FECHA_REGISTRO");
                            int pt6 = dr.GetOrdinal("FECHA_VERIFICACION");
                            int pt7 = dr.GetOrdinal("DOC");

                            while (dr.Read())
                            {
                                //PARTE_DIARIO_DETALLE
                                oCamposDet = new CEntidad();
                                oCamposDet.OD = dr.GetString(pt1);
                                oCamposDet.TH = dr.GetString(pt2); //Son diversos documentos
                                oCamposDet.MESES = dr.GetString(pt3);
                                oCamposDet.TIPO = dr.GetString(pt4);
                                oCamposDet.FECHA = dr.GetString(pt5); //fecha de registro 
                                oCamposDet.FECHAFIN = dr.GetString(pt6); // fecha de verificacion
                                oCamposDet.BusCriterio = dr.GetString(pt7); //tipo de documento
                                lsDetDetalles.Add(oCamposDet);
                            }
                        }
                        oCampos.ListSupervisores = lsDetDetalles; //lista del detalles de los documentos
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
        //public CEntidad Dat_ControlCalidadOD(SqlConnection cn, CEntidad oCEntidad)
        //{
        //    CEntidad oCampos = null;
        //    try
        //    {
        //        using (SqlDataReader dr = oGDataSQL.SelDrdDefault(cn, null, "DOC.new_REPORTE_ControlCalidad", oCEntidad))
        //        {
        //            if (dr != null)
        //            {
        //                oCampos = new CEntidad();
        //                List<CEntidad> lsDetDetalles;
        //                CEntidad oCamposDet;
        //                CapaEntidadDet oDetCampo;
        //                //
        //                //Verificacion General
        //                lsDetDetalles = new List<CEntidad>();
        //                if (dr.HasRows)
        //                {
        //                    int pt1 = dr.GetOrdinal("DOCUMENTO");
        //                    int pt2 = dr.GetOrdinal("DESCRIPCION");
        //                    int pt3 = dr.GetOrdinal("CC");
        //                    int pt4 = dr.GetOrdinal("CO");

        //                    while (dr.Read())
        //                    {
        //                        //PARTE_DIARIO_DETALLE
        //                        oCamposDet = new CEntidad();
        //                        oCamposDet.BusCriterio = dr.GetString(pt1); //Diversos documentos
        //                        oCamposDet.OD = dr.GetString(pt2); 
        //                        oCamposDet.TOTAL = dr.GetInt32(pt3); //control de calidad conforme
        //                        oCamposDet.REGISTROS = dr.GetInt32(pt4);//control de calidad con observaciones
        //                        lsDetDetalles.Add(oCamposDet);
        //                    }
        //                }
        //                oCampos.ListSupervisores = lsDetDetalles; //lista del detalles de los documentos

        //                dr.NextResult();
        //                lsDetDetalles = new List<CEntidad>();
        //                if (dr.HasRows)
        //                {
        //                    while (dr.Read())
        //                    {
        //                        //PARTE_DIARIO_DETALLE
        //                        oCamposDet = new CEntidad();
        //                        oCamposDet.OD = dr.GetString(dr.GetOrdinal("TIPODOC"));
        //                        oCamposDet.PR = dr.GetInt32(dr.GetOrdinal("PR"));
        //                        oCamposDet.RC = dr.GetInt32(dr.GetOrdinal("RC"));
        //                        oCamposDet.CO = dr.GetInt32(dr.GetOrdinal("CO"));
        //                        oCamposDet.CC = dr.GetInt32(dr.GetOrdinal("CC"));

        //                        lsDetDetalles.Add(oCamposDet);
        //                    }
        //                }
        //                oCampos.ListOD = lsDetDetalles;

        //                dr.NextResult();
        //                lsDetDetalles = new List<CEntidad>();
        //                if (dr.HasRows)
        //                {
        //                    int pt1 = dr.GetOrdinal("MES");
        //                    int pt2 = dr.GetOrdinal("CONFORME");
        //                    int pt3 = dr.GetOrdinal("OBSERVACION");

        //                    while (dr.Read())
        //                    {
        //                        oCamposDet = new CEntidad();
        //                        oCamposDet.MESES = dr.GetString(pt1);
        //                        oCamposDet.REGISTROS = dr.GetInt32(pt2); //CC Conforme
        //                        oCamposDet.PSUPERVISION = dr.GetInt32(pt3); // CC con Observaciones
        //                        oCamposDet.TOTAL = dr.GetInt32(pt2) + dr.GetInt32(pt3);
        //                        lsDetDetalles.Add(oCamposDet);
        //                    }
        //                }
        //                oCampos.ListDigitadores = lsDetDetalles;

        //                dr.NextResult();
        //                List<CapaEntidadDet> lsDetDetallesCont = new List<CapaEntidadDet>();
        //                if (dr.HasRows)
        //                {
        //                    int pt1 = dr.GetOrdinal("DESCRIPCION");
        //                    int pt2 = dr.GetOrdinal("fecha_control");
        //                    int pt3 = dr.GetOrdinal("NUMERO");
        //                    int pt4 = dr.GetOrdinal("fecha_registro");
        //                    int pt5 = dr.GetOrdinal("OBSERV_SUBSANAR");
        //                    int pt6 = dr.GetOrdinal("Resps_calidad");
        //                    int pt7 = dr.GetOrdinal("Reps_Registro");
        //                    int pt8 = dr.GetOrdinal("TIPO_DOC");

        //                    while (dr.Read())
        //                    {
        //                        oDetCampo = new CapaEntidadDet();
        //                        oDetCampo.OD = dr.GetString(pt1);
        //                        oDetCampo.FECHA_CONTROL = dr.GetString(pt2); //CC Conforme
        //                        oDetCampo.NUM_DOC = dr.GetString(pt3); // CC con Observaciones
        //                        oDetCampo.FECHA_REGISTRO = dr.GetString(pt4) ;
        //                        oDetCampo.OBSERVA_SUBSANAR = dr.GetBoolean(pt5);
        //                        oDetCampo.RESP_CALIDAD = dr.GetString(pt6);
        //                        oDetCampo.RESP_REGISTRO = dr.GetString(pt7);
        //                        oDetCampo.TIPO_DOC = dr.GetString(pt8);
        //                        oDetCampo.ESTADO_DOC = dr.GetString(dr.GetOrdinal("ESTADO_DOC"));
        //                        lsDetDetallesCont.Add(oDetCampo);
        //                    }
        //                }
        //                oCampos.ListDigitadores = lsDetDetalles;
        //                oCampos.ListControlCalidad = lsDetDetallesCont;
        //            }
        //        }
        //        return oCampos;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
    }
}
