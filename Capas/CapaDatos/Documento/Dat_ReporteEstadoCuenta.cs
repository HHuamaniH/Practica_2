using System;
using System.Collections.Generic;
//using System.Data.SqlClient;
using CEntidad = CapaEntidad.DOC.Ent_Reporte_EstadoCuenta;
using GeneralSQL;
using Oracle.ManagedDataAccess.Client;
//using SQL = GeneralSQL.Data.SQL;

namespace CapaDatos.DOC
{
    /// <summary>
    /// 
    /// </summary>
    public class Dat_ReporteEstadoCuenta
    {
        //private SQL oGDataSQL = new SQL();
        private DBOracle dBOracle = new DBOracle();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public List<CEntidad> RegMostrarLista(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC.spGeneral_Listar", oCEntidad))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            int p1 = dr.GetOrdinal("COD_THABILITANTE");
                            int p2 = dr.GetOrdinal("FECHA");
                            int p3 = dr.GetOrdinal("MODALIDAD");
                            int p4 = dr.GetOrdinal("NUMERO");
                            int p5 = dr.GetOrdinal("TIPO");
                            int p6 = dr.GetOrdinal("PERSONA_TITULAR");
                            int p7 = dr.GetOrdinal("PERSONA_RLEGAL");
                            int p8 = dr.GetOrdinal("DIRECCION");
                            int p9 = dr.GetOrdinal("AREA_OTORGADA");
                            int p10 = dr.GetOrdinal("UBICACION");
                            CEntidad oCampos;
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                oCampos.COD_THABILITANTE = dr.GetString(p1);
                                oCampos.FECHA_EMISION = dr.GetString(p2); //FECHA DE CREACION
                                oCampos.MODALIDAD = dr.GetString(p3);
                                oCampos.NUMERO = dr.GetString(p4);
                                oCampos.TIPO = dr.GetString(p5);
                                oCampos.PERSONA_TITULAR = dr.GetString(p6);
                                oCampos.PERSONA_RLEGAL = dr.GetString(p7);
                                oCampos.DIRECCION = dr.GetString(p8);
                                oCampos.AREA_OTORGADA = dr.GetDecimal(p9);
                                oCampos.UBICACION = dr.GetString(p10);
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
        public CEntidad Dat_DetalleEstadoCuenta(OracleConnection cn, CEntidad oCEntidad)
        {
            CEntidad oCampos = null;
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC.new_REPORTE_ESTADO_CUENTA", oCEntidad))
                {
                    if (dr != null)
                    {
                        oCampos = new CEntidad();
                        List<CEntidad> lsDetDetalle;
                        CEntidad oCamposDet;

                        //Antecedentes de Supervisiones
                        lsDetDetalle = new List<CEntidad>();
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("CODIGO");
                            int pt2 = dr.GetOrdinal("FECHA");
                            int pt3 = dr.GetOrdinal("INFORME");
                            int pt4 = dr.GetOrdinal("ZAFRA");
                            int pt5 = dr.GetOrdinal("NUM_POA");
                            int pt6 = dr.GetOrdinal("AREA");
                            int pt7 = dr.GetOrdinal("VOLUMEN_SUPERVISADO");
                            int pt8 = dr.GetOrdinal("VOLUMEN_AUTORIZADO");
                            int pt9 = dr.GetOrdinal("VOLUMEN_MOVILIZADO");
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.COD_INFORME = dr.GetString(pt1);
                                oCamposDet.FECHA_EMISION = dr.GetString(pt2);
                                oCamposDet.NUMERO_INFORME = dr.GetString(pt3);
                                oCamposDet.ZAFRA = dr.GetString(pt4);
                                oCamposDet.NUM_POA = dr.GetInt32(pt5);
                                oCamposDet.AREA = dr.GetDecimal(pt6);
                                oCamposDet.VOLUMEN_SUPERVISADO = dr.GetDecimal(pt7);
                                oCamposDet.VOLUMEN_AUTORIZADO = dr.GetDecimal(pt8);
                                oCamposDet.VOLUMEN_MOVILIZADO = dr.GetDecimal(pt9);
                                lsDetDetalle.Add(oCamposDet);
                            }
                        }
                        oCampos.ListAntecedentesSupervision = lsDetDetalle;

                        dr.NextResult();

                        lsDetDetalle = new List<CEntidad>();
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("COD_RESODIREC");
                            int pt2 = dr.GetOrdinal("NUMERO_EXPEDIENTE");
                            int pt3 = dr.GetOrdinal("NUMERO_RESOLUCION");
                            int pt4 = dr.GetOrdinal("NUMERO");
                            int pt5 = dr.GetOrdinal("MEDIDA_CAUTELAR");
                            int pt6 = dr.GetOrdinal("INFRACCION");
                            int pt7 = dr.GetOrdinal("VOLUMEN");
                            int pt8 = dr.GetOrdinal("FECHA_EMISION");

                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.COD_RINICIO = dr.GetString(pt1);
                                oCamposDet.EXPEDIENTE_ADMINISTRATIVO = dr.GetString(pt2);
                                oCamposDet.RINICIO = dr.GetString(pt3);
                                oCamposDet.NUMERO_INFORME = dr.GetString(pt4);
                                oCamposDet.MEDIDA_CAUTELAR = dr.GetString(pt5);
                                oCamposDet.INFRACCION = dr.GetString(pt6);
                                oCamposDet.VOLUMEN_INJUSTIFICADO = dr.GetDecimal(pt7);
                                oCamposDet.FECHA_EMISION = dr.GetString(pt8);
                                lsDetDetalle.Add(oCamposDet);
                            }
                        }
                        oCampos.ListInicioPau = lsDetDetalle;

                        dr.NextResult();

                        lsDetDetalle = new List<CEntidad>();
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("COD_RESODIREC");
                            int pt2 = dr.GetOrdinal("NUMERO_RESOLUCION");
                            int pt3 = dr.GetOrdinal("FECHA_EMISION");
                            int pt4 = dr.GetOrdinal("INFRACCION");
                            int pt5 = dr.GetOrdinal("MONTO");
                            int pt6 = dr.GetOrdinal("SITUACION");
                            int pt7 = dr.GetOrdinal("VOLUMEN");
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.COD_RTERMINO = dr.GetString(pt1);
                                oCamposDet.RTERMINO = dr.GetString(pt2);
                                oCamposDet.FECHA_EMISION = dr.GetString(pt3);
                                oCamposDet.INFRACCION = dr.GetString(pt4);
                                oCamposDet.MULTA = dr.GetDecimal(pt5);
                                oCamposDet.SITUACION = dr.GetString(pt6);
                                oCamposDet.VOLUMEN_INJUSTIFICADO = dr.GetDecimal(pt7);
                                lsDetDetalle.Add(oCamposDet);

                            }
                        }
                        oCampos.ListFinalizacionPau = lsDetDetalle;

                        dr.NextResult();

                        lsDetDetalle = new List<CEntidad>();
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("FECHA");
                            int pt2 = dr.GetOrdinal("ILEGAL_NUMERO");
                            int pt3 = dr.GetOrdinal("TIPO_DOC");
                            int pt4 = dr.GetOrdinal("DESCR");
                            int pt5 = dr.GetOrdinal("TIPO");
                            int pt6 = dr.GetOrdinal("RECOMENDACION");
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.FECHA_EMISION = dr.GetString(pt1);
                                oCamposDet.NUMERO = dr.GetString(pt2);
                                oCamposDet.BusCriterio = dr.GetString(pt3);
                                oCamposDet.DIRECCION = dr.GetString(pt4);
                                oCamposDet.TIPO = dr.GetString(pt5);
                                oCamposDet.SITUACION = dr.GetString(pt6);
                                lsDetDetalle.Add(oCamposDet);

                            }
                        }
                        oCampos.ListDocumentosEmitidos = lsDetDetalle;


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
