using System;
using GeneralSQL;
using System.Collections.Generic;
using Oracle.ManagedDataAccess.Client;
//using System.Data.SqlClient;
using CEntidad = CapaEntidad.DOC.Ent_WS_OSINFOR;
//using SQL = GeneralSQL.Data.SQL;

namespace CapaDatos.DOC
{
    public class Dat_WS_OSINFOR
    {
        //private SQL oGDataSQL = new SQL();
        private DBOracle dBOracle = new DBOracle();

        public List<CEntidad> RegMostrarSupervisiones(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "HERR_OSINFOR_ERP_MIGRACION.spWS_OSINFOR", oCEntidad))
                {
                    if (dr != null)
                    {
                        CEntidad oCampos;
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                oCampos.COD_THABILITANTE = dr["COD_THABILITANTE"].ToString();
                                oCampos.NUM_THABILITANTE = dr["NUM_THABILITANTE"].ToString();
                                oCampos.TITULAR = dr["TITULAR"].ToString();
                                oCampos.MODALIDAD = dr["MODALIDAD"].ToString();
                                oCampos.CADUCADO_TH = int.Parse(dr["CADUCADO_TH"].ToString());
                                oCampos.NUM_POA = int.Parse(dr["NUM_POA"].ToString());
                                oCampos.NOMBRE_POA = dr["NOMBRE_POA"].ToString();
                                oCampos.ARESOLUCION_NUM = dr["ARESOLUCION_NUM"].ToString();

                                oCampos.COD_INFORME = dr["COD_INFORME"].ToString();
                                oCampos.NUM_INFORME = dr["NUM_INFORME"].ToString();
                                oCampos.FECHA_SUPERVISION_INI = dr["FECHA_SUPERVISION_INI"].ToString();
                                oCampos.FECHA_SUPERVISION_FIN = dr["FECHA_SUPERVISION_FIN"].ToString();

                                oCampos.NUM_RESOLUCION_INI_1 = dr["NUM_RESOLUCION_INI_1"].ToString();
                                oCampos.FECHA_EMISION_INI_1 = dr["FECHA_EMISION_INI_1"].ToString();
                                oCampos.MED_CAU_INI_1 = int.Parse(dr["MED_CAU_INI_1"].ToString());
                                oCampos.INFRACCIONES_INI_1 = dr["INFRACCIONES_INI_1"].ToString();
                                oCampos.NUM_RESOLUCION_AMP = dr["NUM_RESOLUCION_AMP"].ToString();
                                oCampos.FECHA_EMISION_AMP = dr["FECHA_EMISION_AMP"].ToString();
                                oCampos.INFRACCIONES_AMP = dr["INFRACCIONES_AMP"].ToString();
                                oCampos.NUM_RESOLUCION_VAIMP = dr["NUM_RESOLUCION_VAIMP"].ToString();
                                oCampos.FECHA_EMISION_VAIMP = dr["FECHA_EMISION_VAIMP"].ToString();
                                oCampos.INFRACCIONES_VAIMP = dr["INFRACCIONES_VAIMP"].ToString();
                                oCampos.NUM_RESOLUCION_TER_1 = dr["NUM_RESOLUCION_TER_1"].ToString();
                                oCampos.FECHA_EMISION_TER_1 = dr["FECHA_EMISION_TER_1"].ToString();
                                oCampos.DETER_TER_1 = dr["DETER_TER_1"].ToString();
                                oCampos.MONTO_MULTA_TER_1 = decimal.Parse(dr["MONTO_MULTA_TER_1"].ToString());
                                oCampos.AMONESTACION_TER_1 = int.Parse(dr["AMONESTACION_TER_1"].ToString());
                                oCampos.CADUCIDAD_TER_1 = int.Parse(dr["CADUCIDAD_TER_1"].ToString());
                                oCampos.MED_PRECAU_TER_1 = int.Parse(dr["MED_PRECAU_TER_1"].ToString());
                                oCampos.MED_CORREC_TER_1 = int.Parse(dr["MED_CORREC_TER_1"].ToString());
                                oCampos.INFRACCIONES_TER_1 = dr["INFRACCIONES_TER_1"].ToString();
                                oCampos.NUM_RESOLUCION_RECONS = dr["NUM_RESOLUCION_RECONS"].ToString();
                                oCampos.FECHA_EMISION_RECONS = dr["FECHA_EMISION_RECONS"].ToString();
                                oCampos.DETER_RECONS = dr["DETER_RECONS"].ToString();
                                oCampos.LEV_CADUCIDAD_RECONS = int.Parse(dr["LEV_CADUCIDAD_RECONS"].ToString());
                                oCampos.CAMBIO_MULTA_RECONS = int.Parse(dr["CAMBIO_MULTA_RECONS"].ToString());
                                oCampos.MONTO_MULTA_RECONS = decimal.Parse(dr["MONTO_MULTA_RECONS"].ToString());
                                oCampos.NUM_RESOLUCION_RECTI = dr["NUM_RESOLUCION_RECTI"].ToString();
                                oCampos.FECHA_EMISION_RECTI = dr["FECHA_EMISION_RECTI"].ToString();
                                oCampos.MOTIVO_RECTI = dr["MOTIVO_RECTI"].ToString();
                                oCampos.MONTO_MULTA_RECTI = decimal.Parse(dr["MONTO_MULTA_RECTI"].ToString());
                                oCampos.NUM_RESOLUCION_TFFS_1 = dr["NUM_RESOLUCION_TFFS_1"].ToString();
                                oCampos.FECHA_EMISION_TFFS_1 = dr["FECHA_EMISION_TFFS_1"].ToString();
                                oCampos.RECURSO_TFFS_1 = dr["RECURSO_TFFS_1"].ToString();
                                oCampos.DETERMINA_TFFS_1 = dr["DETERMINA_TFFS_1"].ToString();
                                oCampos.MOTIVO_TFFS_1 = dr["MOTIVO_TFFS_1"].ToString();

                                oCampos.NUM_RESOLUCION_INI_2 = dr["NUM_RESOLUCION_INI_2"].ToString();
                                oCampos.FECHA_EMISION_INI_2 = dr["FECHA_EMISION_INI_2"].ToString();
                                oCampos.MED_CAU_INI_2 = int.Parse(dr["MED_CAU_INI_2"].ToString());
                                oCampos.INFRACCIONES_INI_2 = dr["INFRACCIONES_INI_2"].ToString();
                                oCampos.NUM_RESOLUCION_TER_2 = dr["NUM_RESOLUCION_TER_2"].ToString();
                                oCampos.FECHA_EMISION_TER_2 = dr["FECHA_EMISION_TER_2"].ToString();
                                oCampos.DETER_TER_2 = dr["DETER_TER_2"].ToString();
                                oCampos.MONTO_MULTA_TER_2 = decimal.Parse(dr["MONTO_MULTA_TER_2"].ToString());
                                oCampos.AMONESTACION_TER_2 = int.Parse(dr["AMONESTACION_TER_2"].ToString());
                                oCampos.CADUCIDAD_TER_2 = int.Parse(dr["CADUCIDAD_TER_2"].ToString());
                                oCampos.MED_PRECAU_TER_2 = int.Parse(dr["MED_PRECAU_TER_2"].ToString());
                                oCampos.MED_CORREC_TER_2 = int.Parse(dr["MED_CORREC_TER_2"].ToString());
                                oCampos.INFRACCIONES_TER_2 = dr["INFRACCIONES_TER_2"].ToString();
                                oCampos.NUM_RESOLUCION_TFFS_2 = dr["NUM_RESOLUCION_TFFS_2"].ToString();
                                oCampos.FECHA_EMISION_TFFS_2 = dr["FECHA_EMISION_TFFS_2"].ToString();
                                oCampos.RECURSO_TFFS_2 = dr["RECURSO_TFFS_2"].ToString();
                                oCampos.DETERMINA_TFFS_2 = dr["DETERMINA_TFFS_2"].ToString();
                                oCampos.MOTIVO_TFFS_2 = dr["MOTIVO_TFFS_2"].ToString();

                                oCampos.ESTADO_PAU = dr["ESTADO_PAU"].ToString();
                                oCampos.FECHA_ACTUALIZACION = dr["FECHA_ACTUALIZACION"].ToString();

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

        public List<CEntidad> RegDetalleSupervision(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "HERR_OSINFOR_ERP_MIGRACION.spWS_OSINFOR", oCEntidad))
                {
                    if (dr != null)
                    {
                        CEntidad oCampos;
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                oCampos.COD_INFORME = dr["COD_INFORME"].ToString();
                                oCampos.COD_THABILITANTE = dr["COD_THABILITANTE"].ToString();
                                oCampos.NUM_POA = int.Parse(dr["NUM_POA"].ToString());
                                oCampos.POA = dr["POA"].ToString();
                                oCampos.COD_ESPECIES = dr["COD_ESPECIES"].ToString();
                                oCampos.DESC_ESPECIES = dr["DESC_ESPECIES"].ToString();
                                oCampos.COD_SECUENCIAL = dr["COD_SECUENCIAL"].ToString();
                                oCampos.BLOQUE = dr["BLOQUE"].ToString();
                                oCampos.FAJA = dr["FAJA"].ToString();
                                oCampos.CODIGO = dr["CODIGO"].ToString();
                                oCampos.DAP = dr["DAP"].ToString();
                                oCampos.AC = dr["AC"].ToString();
                                oCampos.COD_ECONDICION = dr["COD_ECONDICION"].ToString();
                                oCampos.DESC_ECONDICION = dr["DESC_ECONDICION"].ToString();
                                oCampos.DESC_EESTADO = dr["DESC_EESTADO"].ToString();
                                oCampos.ZONA_UTM = dr["ZONA_UTM"].ToString();
                                oCampos.COORDENADA_ESTE = dr["COORDENADA_ESTE"].ToString();
                                oCampos.COORDENADA_NORTE = dr["COORDENADA_NORTE"].ToString();
                                oCampos.COD_ESPECIES_CAMPO = dr["COD_ESPECIES_CAMPO"].ToString();
                                oCampos.DESC_ESPECIES_CAMPO = dr["DESC_ESPECIES_CAMPO"].ToString();
                                oCampos.BLOQUE_CAMPO = dr["BLOQUE_CAMPO"].ToString();
                                oCampos.FAJA_CAMPO = dr["FAJA_CAMPO"].ToString();
                                oCampos.CODIGO_CAMPO = dr["CODIGO_CAMPO"].ToString();
                                oCampos.DAP_CAMPO = dr["DAP_CAMPO"].ToString();
                                oCampos.DAP_CAMPO1 = dr["DAP_CAMPO1"].ToString();
                                oCampos.DAP_CAMPO2 = dr["DAP_CAMPO2"].ToString();
                                oCampos.AC_CAMPO = dr["AC_CAMPO"].ToString();
                                oCampos.ZONA_UTM_CAMPO = dr["ZONA_UTM_CAMPO"].ToString();
                                oCampos.COORDENADA_ESTE_CAMPO = dr["COORDENADA_ESTE_CAMPO"].ToString();
                                oCampos.COORDENADA_NORTE_CAMPO = dr["COORDENADA_NORTE_CAMPO"].ToString();
                                oCampos.DESC_ACATEGORIA_CITE = dr["DESC_ACATEGORIA_CITE"].ToString();
                                oCampos.DESC_ACATEGORIA_DS = dr["DESC_ACATEGORIA_DS"].ToString();
                                oCampos.BS_ALTURA_TOTAL = dr["BS_ALTURA_TOTAL"].ToString();
                                oCampos.BS_DIAMETRO_RAMA_1 = dr["BS_DIAMETRO_RAMA_1"].ToString();
                                oCampos.BS_DIAMETRO_RAMA_2 = dr["BS_DIAMETRO_RAMA_2"].ToString();
                                oCampos.BS_DIAMETRO_RAMA_3 = dr["BS_DIAMETRO_RAMA_3"].ToString();
                                oCampos.BS_DIAMETRO_RAMA_4 = dr["BS_DIAMETRO_RAMA_4"].ToString();
                                oCampos.BS_DIAMETRO_RAMA_5 = dr["BS_DIAMETRO_RAMA_5"].ToString();
                                oCampos.BS_DIAMETRO_RAMA_6 = dr["BS_DIAMETRO_RAMA_6"].ToString();
                                oCampos.BS_DIAMETRO_RAMA_7 = dr["BS_DIAMETRO_RAMA_7"].ToString();
                                oCampos.BS_LONGITUD_RAMA_1 = dr["BS_LONGITUD_RAMA_1"].ToString();
                                oCampos.BS_LONGITUD_RAMA_2 = dr["BS_LONGITUD_RAMA_2"].ToString();
                                oCampos.BS_LONGITUD_RAMA_3 = dr["BS_LONGITUD_RAMA_3"].ToString();
                                oCampos.BS_LONGITUD_RAMA_4 = dr["BS_LONGITUD_RAMA_4"].ToString();
                                oCampos.BS_LONGITUD_RAMA_5 = dr["BS_LONGITUD_RAMA_5"].ToString();
                                oCampos.BS_LONGITUD_RAMA_6 = dr["BS_LONGITUD_RAMA_6"].ToString();
                                oCampos.BS_LONGITUD_RAMA_7 = dr["BS_LONGITUD_RAMA_7"].ToString();
                                oCampos.COD_EESTADO_CAMPO = dr["COD_EESTADO_CAMPO"].ToString();
                                oCampos.DESC_EESTADO_CAMPO = dr["DESC_EESTADO_CAMPO"].ToString();
                                oCampos.COD_ECONDICION_CAMPO = dr["COD_ECONDICION_CAMPO"].ToString();
                                oCampos.DESC_ECONDICION_CAMPO = dr["DESC_ECONDICION_CAMPO"].ToString();

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

        public List<CEntidad> RegDetalleResodirec(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "HERR_OSINFOR_ERP_MIGRACION.spWS_OSINFOR", oCEntidad))
                {
                    if (dr != null)
                    {
                        CEntidad oCampos;
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                oCampos.COD_RESODIREC = dr["COD_RESODIREC"].ToString();
                                oCampos.COD_SECUENCIAL = dr["COD_SECUENCIAL"].ToString();
                                oCampos.COD_INCISO = dr["COD_INCISO"].ToString();
                                oCampos.DESC_ART = dr["DESC_ART"].ToString();
                                oCampos.DESC_INCISO = dr["DESC_INCISO"].ToString();
                                oCampos.COD_ESPECIES = dr["COD_ESPECIES"].ToString();
                                oCampos.DESC_ESPECIES = dr["DESC_ESPECIES"].ToString();
                                oCampos.VOLUMEN = dr["VOLUMEN"].ToString();
                                oCampos.AREA = dr["AREA"].ToString();
                                oCampos.NUMERO_INDIVIDUOS = dr["NUMERO_INDIVIDUOS"].ToString();
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

        public List<CEntidad> RegDetalleSancioCaduc(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "HERR_OSINFOR_ERP_MIGRACION.spWS_OSINFOR", oCEntidad))
                {
                    if (dr != null)
                    {
                        CEntidad oCampos;
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                oCampos.COD_THABILITANTE = dr["COD_THABILITANTE"].ToString();
                                oCampos.TITULAR = dr["TITULAR"].ToString();
                                oCampos.DOCUMENTO = dr["DOCUMENTO"].ToString();
                                oCampos.NUM_THABILITANTE = dr["NUM_THABILITANTE"].ToString();
                                oCampos.MODALIDAD = dr["MODALIDAD"].ToString();
                                oCampos.DEPARTAMENTO = dr["DEPARTAMENTO"].ToString();
                                oCampos.PROVINCIA = dr["PROVINCIA"].ToString();
                                oCampos.DISTRITO = dr["DISTRITO"].ToString();
                                oCampos.NUM_RESOLUCION_TER_1 = dr["NUM_RESOLUCION_TER"].ToString();
                                oCampos.INFRACCIONES_TER_1 = dr["INFRACCIONES_TER"].ToString();
                                oCampos.NUM_RESOLUCION_RECONS = dr["NUM_RESOLUCION_RECONS"].ToString();
                                oCampos.CADUCADO_TH = dr["CADUCADO_TH"].ToString();
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

        public List<CEntidad> RegTHs(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "HERR_OSINFOR_ERP_MIGRACION.spWS_OSINFOR", oCEntidad))
                {
                    if (dr != null)
                    {
                        CEntidad oCampos;
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                //oCampos.COD_THABILITANTE = dr["COD_THABILITANTE"].ToString();
                                oCampos.NUM_THABILITANTE = dr["NUM_THABILITANTE"].ToString();
                                //oCampos.TITULAR = dr["TITULAR"].ToString();
                                oCampos.FECHA_ACTUALIZACION = dr["FECHA_ACTUALIZACION"].ToString();

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


        public List<CEntidad> RegDatosPOAs(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "HERR_OSINFOR_ERP_MIGRACION.spWS_OSINFOR", oCEntidad))
                {
                    if (dr != null)
                    {
                        CEntidad oCampos;
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();

                                oCampos.MODALIDAD = dr["MODALIDAD"].ToString();
                                oCampos.NUM_THABILITANTE = dr["NUM_THABILITANTE"].ToString();
                                oCampos.TITULAR = dr["TITULAR"].ToString();
                                oCampos.OD = dr["OD"].ToString();
                                oCampos.ARESOLUCION_NUM = dr["ARESOLUCION_NUM"].ToString();
                                oCampos.NOMBRE_POA = dr["NOMBRE_POA"].ToString();
                                oCampos.NUM_PCOMPLEMENTARIO = dr["NUM_PCOMPLEMENTARIO"].ToString();
                                oCampos.AREA_POA = dr["AREA_POA"].ToString();
                                oCampos.PCA = dr["PCA"].ToString();
                                oCampos.ZAFRA_PCA = dr["ZAFRA_PCA"].ToString();
                                oCampos.INICIO_VIGENCIA = dr["INICIO_VIGENCIA"].ToString();
                                oCampos.FIN_VIGENCIA = dr["FIN_VIGENCIA"].ToString();
                                oCampos.DEPARTAMENTO = dr["DEPARTAMENTO"].ToString();
                                oCampos.PROVINCIA = dr["PROVINCIA"].ToString();
                                oCampos.DISTRITO = dr["DISTRITO"].ToString();
                                oCampos.FECHA_SUPERVISION_INI = dr["INICIO_SUPERVISION"].ToString();
                                oCampos.FECHA_SUPERVISION_FIN = dr["FIN_SUPERVISION"].ToString();
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
