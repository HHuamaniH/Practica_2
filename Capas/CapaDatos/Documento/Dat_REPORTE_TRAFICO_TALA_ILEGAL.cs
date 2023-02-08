using System;
using System.Collections.Generic;
//using System.Data.SqlClient;
using CEntidad = CapaEntidad.DOC.Ent_REPORTE_TRAFICO_TALA_ILEGAL;
using GeneralSQL;
using Oracle.ManagedDataAccess.Client;
//using SQL = GeneralSQL.Data.SQL;


namespace CapaDatos.DOC
{
    /// <summary>
    /// 
    /// </summary>
    public class Dat_REPORTE_TRAFICO_TALA_ILEGAL
    {

        //private SQL oGDataSQL = new SQL();
        private DBOracle dBOracle = new DBOracle();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public List<CEntidad> MostrarVolumenIlegal(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC.REPORTE_VOLUMEN_MOVILIZADO_EXTRAIDO_ILEGAL", oCEntidad))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            int p1 = dr.GetOrdinal("NOMBRE_CIENTIFICO");
                            int p2 = dr.GetOrdinal("VOL_AUTORIZADO");
                            int p3 = dr.GetOrdinal("VOL_MOVILIZADOB");
                            int p4 = dr.GetOrdinal("VOL_EXTRAIDO");
                            int p5 = dr.GetOrdinal("VOL_MOVILIZADO");

                            CEntidad oCampos;
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                oCampos.DESCRIPCION = dr.GetString(p1);
                                oCampos.VOL_AUTORIZADO = dr.GetDecimal(p2);
                                oCampos.VOL_MOVILIZADOB = dr.GetDecimal(p3);
                                oCampos.VOL_EXTRAIDO = dr.GetDecimal(p4);
                                oCampos.VOL_MOVILIZADO = dr.GetDecimal(p5);
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
        public List<CEntidad> MostrarConsultor(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC.new_REPORTE_CONSULTORES_POA_FALSO", oCEntidad))
                {
                    if (dr != null)
                    {

                        if (dr.HasRows)
                        {
                            int p1 = dr.GetOrdinal("CONSULTOR_CODIGO");
                            int p2 = dr.GetOrdinal("CONSULTOR");
                            int p3 = dr.GetOrdinal("POAREALIZADO");
                            int p4 = dr.GetOrdinal("FALSEDADINFORMACION");

                            CEntidad oCampos;
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                oCampos.CODIGO = dr.GetString(p1);
                                oCampos.DESCRIPCION = dr.GetString(p2);
                                oCampos.POAREALIZADO = dr.GetInt32(p3);
                                oCampos.FALSEDADINFORMACION = dr.GetInt32(p4);

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
        public CEntidad MostrarHistorial(OracleConnection cn, CEntidad oCEntidad)
        {
            CEntidad oCampos = null;
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC.ReporteConsultorHistorial", oCEntidad))
                {
                    if (dr != null)
                    {
                        oCampos = new CEntidad();
                        List<CEntidad> lsDetDetalles;
                        CEntidad oCamposDet;
                        CEntidad oCamposDetalle;
                        //Tipor de Modalidad
                        lsDetDetalles = new List<CEntidad>();
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("ANIO");
                            int pt2 = dr.GetOrdinal("POAREALIZADO");
                            int pt3 = dr.GetOrdinal("FALSEDADINFORMACION");
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.ANIO = dr.GetInt32(pt1);
                                oCamposDet.POAREALIZADO = dr.GetInt32(pt2);
                                oCamposDet.FALSEDADINFORMACION = dr.GetInt32(pt3);

                                lsDetDetalles.Add(oCamposDet);
                            }
                        }
                        oCampos.ListHistorico = lsDetDetalles;

                        dr.NextResult();

                        lsDetDetalles = new List<CEntidad>();
                        if (dr.HasRows)
                        {
                            int ptp1 = dr.GetOrdinal("TITULAR");
                            int ptp2 = dr.GetOrdinal("CONTRATO");
                            int ptp3 = dr.GetOrdinal("NUM_POA");
                            int ptp4 = dr.GetOrdinal("DESCRIPCION");
                            int ptp5 = dr.GetOrdinal("NUMERO_RESOLUCION");
                            int ptp6 = dr.GetOrdinal("ANIO");
                            while (dr.Read())
                            {
                                oCamposDetalle = new CEntidad();
                                oCamposDetalle.TITULAR = dr.GetString(ptp1);
                                oCamposDetalle.TITULO_HABILITANTE = dr.GetString(ptp2);
                                oCamposDetalle.NUM_POA = dr.GetInt32(ptp3);
                                oCamposDetalle.DESCRIPCION = dr.GetString(ptp4);
                                oCamposDetalle.NUMERO_RESOLUCION = dr.GetString(ptp5);
                                oCamposDetalle.ANIO = dr.GetInt32(ptp6);
                                lsDetDetalles.Add(oCamposDetalle);
                            }
                        }
                        oCampos.ListPoaFalsedad = lsDetDetalles;
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
        public List<CEntidad> MostrarZafra(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC.new_REPORTE_ZAFRA_INFORMACION_FALSA", oCEntidad))
                {
                    if (dr != null)
                    {

                        if (dr.HasRows)
                        {
                            int p1 = dr.GetOrdinal("ZAFRA_PCA");
                            int p2 = dr.GetOrdinal("FALSEDADINFORMACION");

                            CEntidad oCampos;
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                oCampos.DESCRIPCION = dr.GetString(p1);
                                oCampos.FALSEDADINFORMACION = dr.GetInt32(p2);
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
        public CEntidad Dat_EspeciesMayorInformalidad(OracleConnection cn, CEntidad oCEntidad)
        {
            CEntidad oCampos = null;
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC.new_REPORTE_EspeciesConMayorInformalidad", oCEntidad))
                {
                    if (dr != null)
                    {
                        oCampos = new CEntidad();
                        List<CEntidad> lsDetDetalles;
                        CEntidad oCamposDet;

                        lsDetDetalles = new List<CEntidad>();
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("AÑO_SUP");
                            int pt6 = dr.GetOrdinal("DEPARTAMENTO");
                            int pt2 = dr.GetOrdinal("NUM_ARBOLES");
                            int pt3 = dr.GetOrdinal("MUESTRA");
                            int pt4 = dr.GetOrdinal("INEXISTENTE");
                            int pt5 = dr.GetOrdinal("% INEXT");

                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.ANIO_SUPER = dr.GetString(pt1);
                                oCamposDet.DEPARTAMENTO = dr.GetString(pt6);
                                oCamposDet.NUM_ARBOLES = dr.GetInt32(pt2);
                                oCamposDet.MUESTRA = dr.GetInt32(pt3);
                                oCamposDet.INEXISTENCIA = dr.GetInt32(pt4);
                                oCamposDet.PORCENTAJE = dr.GetDecimal(pt5);

                                lsDetDetalles.Add(oCamposDet);
                            }
                        }
                        oCampos.ListGeneralAnio = lsDetDetalles;

                        dr.NextResult();

                        lsDetDetalles = new List<CEntidad>();
                        if (dr.HasRows)
                        {
                            int ptp1 = dr.GetOrdinal("NOMBRE_CIENTIFICO");
                            int ptp14 = dr.GetOrdinal("DEPARTAMENTO");
                            int ptp2 = dr.GetOrdinal("MUESTRA2009");
                            int ptp3 = dr.GetOrdinal("INEX2009");
                            int ptp4 = dr.GetOrdinal("MUESTRA2010");
                            int ptp5 = dr.GetOrdinal("INEX2010");
                            int ptp6 = dr.GetOrdinal("MUESTRA2011");
                            int ptp7 = dr.GetOrdinal("INEX2011");
                            int ptp8 = dr.GetOrdinal("MUESTRA2012");
                            int ptp9 = dr.GetOrdinal("INEX2012");
                            int ptp10 = dr.GetOrdinal("MUESTRA2013");
                            int ptp11 = dr.GetOrdinal("INEX2013");
                            int ptp12 = dr.GetOrdinal("MUESTRA2014");
                            int ptp13 = dr.GetOrdinal("INEX2014");
                            int ptp15 = dr.GetOrdinal("TOTAL");

                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.NOMBRE_CIENTIFICO = dr.GetString(ptp1);
                                oCamposDet.DEPARTAMENTO = dr.GetString(ptp14);
                                oCamposDet.MUESTRA2009 = dr.GetInt32(ptp2);
                                oCamposDet.INEX2009 = dr.GetInt32(ptp3);
                                oCamposDet.MUESTRA2010 = dr.GetInt32(ptp4);
                                oCamposDet.INEX2010 = dr.GetInt32(ptp5);
                                oCamposDet.MUESTRA2011 = dr.GetInt32(ptp6);
                                oCamposDet.INEX2011 = dr.GetInt32(ptp7);
                                oCamposDet.MUESTRA2012 = dr.GetInt32(ptp8);
                                oCamposDet.INEX2012 = dr.GetInt32(ptp9);
                                oCamposDet.MUESTRA2013 = dr.GetInt32(ptp10);
                                oCamposDet.INEX2013 = dr.GetInt32(ptp11);
                                oCamposDet.MUESTRA2014 = dr.GetInt32(ptp12);
                                oCamposDet.INEX2014 = dr.GetInt32(ptp13);
                                oCamposDet.TOTAL = dr.GetInt32(ptp15);
                                lsDetDetalles.Add(oCamposDet);
                            }
                        }
                        oCampos.ListEspecieAnio = lsDetDetalles;
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
