using System;
using System.Collections.Generic;
//using System.Data.SqlClient;
using CEntidad = CapaEntidad.DOC.Ent_Reporte_SEGUIMIENTO_INFORMES;
using GeneralSQL;
using Oracle.ManagedDataAccess.Client;
//using SQL = GeneralSQL.Data.SQL;


namespace CapaDatos.DOC
{//1
    /// <summary>
    /// 
    /// </summary>
    public class Dat_Reporte_SEGUIMIENTO_INFORMES
    {//2
        //private SQL oGDataSQL = new SQL();
        private DBOracle dBOracle = new DBOracle();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public List<CEntidad> RegMostrarLista(OracleConnection cn, CEntidad oCEntidad)
        {//3
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            //string COD_INFORMEANT="";
            try
            {//4
                using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC.new_Reporte_SEGUIMIENTO_INFORMES", oCEntidad))
                {//5
                    if (dr != null)
                    {//6

                        CEntidad oCampos;
                        if (dr.HasRows)
                        {//7                            

                            while (dr.Read())
                            {//8
                                oCampos = new CEntidad();

                                oCampos.COD_INFORME = dr.GetString(dr.GetOrdinal("COD_INFORME")).ToString();
                                oCampos.INF_NUMERO = dr.GetString(dr.GetOrdinal("INF_NUMERO")).ToString();
                                oCampos.SUPERVISOR = dr.GetString(dr.GetOrdinal("SUPERVISOR")).ToString();
                                oCampos.FECHA_SUPERVISION_INI = dr.GetString(dr.GetOrdinal("FECHA_SUPERVISION_INI")).ToString();
                                oCampos.FECHA_SUPERVISION_FIN = dr.GetString(dr.GetOrdinal("FECHA_SUPERVISION_FIN")).ToString();
                                oCampos.FECHA_RECEPCION_INF = dr.GetString(dr.GetOrdinal("FECHA_RECEPCION_INF")).ToString();
                                oCampos.TIPO_INFORME = dr.GetString(dr.GetOrdinal("TIPO_INFORME")).ToString();
                                oCampos.OD = dr.GetString(dr.GetOrdinal("OD")).ToString();
                                oCampos.MODALIDAD = dr.GetString(dr.GetOrdinal("MODALIDAD")).ToString();
                                oCampos.TITULAR = dr.GetString(dr.GetOrdinal("TITULAR")).ToString();
                                oCampos.PERMISO_AUTORIZACION = dr.GetString(dr.GetOrdinal("PERMISO_AUTORIZACION")).ToString();
                                oCampos.REGION = dr.GetString(dr.GetOrdinal("REGION")).ToString();
                                oCampos.PROVINCIA = dr.GetString(dr.GetOrdinal("PROVINCIA")).ToString();
                                oCampos.DISTRITO = dr.GetString(dr.GetOrdinal("DISTRITO")).ToString();
                                oCampos.SECTOR = dr.GetString(dr.GetOrdinal("SECTOR")).ToString();
                                oCampos.AREA_TH = dr.GetDecimal(dr.GetOrdinal("AREA_TH"));
                                oCampos.AREA_POA = dr.GetString(dr.GetOrdinal("AREA_POA"));
                                oCampos.CN_NUMERO = dr.GetString(dr.GetOrdinal("CN_NUMERO")).ToString();
                                oCampos.CN_FECHA = dr.GetString(dr.GetOrdinal("CN_FECHA")).ToString();
                                oCampos.NUM_POA = dr.GetString(dr.GetOrdinal("NUM_POA")).ToString();
                                oCampos.ZAFRA_PCA = dr.GetString(dr.GetOrdinal("ZAFRA_PCA")).ToString();
                                oCampos.SOLIC_DOCS = dr.GetString(dr.GetOrdinal("SOLIC_DOCS")).ToString();
                                oCampos.ENVIO_DOC_SOLIC = dr.GetString(dr.GetOrdinal("ENVIO_DOC_SOLIC")).ToString();
                                oCampos.ILEGAL_NUMERO = dr.GetString(dr.GetOrdinal("ILEGAL_NUMERO")).ToString();
                                oCampos.ILEGAL_FECHA = dr.GetString(dr.GetOrdinal("ILEGAL_FECHA")).ToString();
                                oCampos.RD_INICIO_PAU = dr.GetString(dr.GetOrdinal("RD_INICIO_PAU")).ToString();
                                oCampos.RD_INICIO_FECHA = dr.GetString(dr.GetOrdinal("RD_INICIO_FECHA")).ToString();
                                oCampos.RD_INICIO_ARCHIVO = dr.GetString(dr.GetOrdinal("RD_INICIO_ARCHIVO")).ToString();
                                oCampos.RD_INICIO_FECHA_ARCHIVO = dr.GetString(dr.GetOrdinal("RD_INICIO_FECHA_ARCHIVO")).ToString();
                                oCampos.RD_INICIO_IMPROCEDENCIA = dr.GetString(dr.GetOrdinal("RD_INICIO_IMPROCEDENCIA")).ToString();
                                oCampos.RD_INICIO_RECTIFICACION = dr.GetString(dr.GetOrdinal("RD_INICIO_RECTIFICACION")).ToString();
                                oCampos.RD_INICIO_A_MED_CAU = dr.GetString(dr.GetOrdinal("RD_INICIO_A_MED_CAU")).ToString();
                                oCampos.INI_18a = dr.GetString(dr.GetOrdinal("INI_18a")).ToString();
                                oCampos.INI_18b = dr.GetString(dr.GetOrdinal("INI_18b")).ToString();
                                oCampos.INI_18c = dr.GetString(dr.GetOrdinal("INI_18c")).ToString();
                                oCampos.INI_18d = dr.GetString(dr.GetOrdinal("INI_18d")).ToString();
                                oCampos.INI_18e = dr.GetString(dr.GetOrdinal("INI_18e")).ToString();
                                oCampos.INI_295a = dr.GetString(dr.GetOrdinal("INI_295a")).ToString();
                                oCampos.INI_295b = dr.GetString(dr.GetOrdinal("INI_295b")).ToString();
                                oCampos.INI_295c = dr.GetString(dr.GetOrdinal("INI_295c")).ToString();
                                oCampos.INI_363e = dr.GetString(dr.GetOrdinal("INI_363e")).ToString();
                                oCampos.INI_363f = dr.GetString(dr.GetOrdinal("INI_363f")).ToString();
                                oCampos.INI_363g = dr.GetString(dr.GetOrdinal("INI_363g")).ToString();
                                oCampos.INI_363i = dr.GetString(dr.GetOrdinal("INI_363i")).ToString();
                                oCampos.INI_363k = dr.GetString(dr.GetOrdinal("INI_363k")).ToString();
                                oCampos.INI_363l = dr.GetString(dr.GetOrdinal("INI_363l")).ToString();
                                oCampos.INI_363m = dr.GetString(dr.GetOrdinal("INI_363m")).ToString();
                                oCampos.INI_363n = dr.GetString(dr.GetOrdinal("INI_363n")).ToString();
                                oCampos.INI_363r = dr.GetString(dr.GetOrdinal("INI_363r")).ToString();
                                oCampos.INI_363t = dr.GetString(dr.GetOrdinal("INI_363t")).ToString();
                                oCampos.INI_363u = dr.GetString(dr.GetOrdinal("INI_363u")).ToString();
                                oCampos.INI_363w = dr.GetString(dr.GetOrdinal("INI_363w")).ToString();
                                oCampos.INI_363v1 = dr.GetString(dr.GetOrdinal("INI_363v1")).ToString();
                                oCampos.RD_INICIO_INF_FALSA = dr.GetString(dr.GetOrdinal("RD_INICIO_INF_FALSA")).ToString();
                                oCampos.RD_INICIO_INF_FALSA_INEX = dr.GetString(dr.GetOrdinal("RD_INICIO_INF_FALSA_INEX")).ToString();
                                oCampos.RD_INICIO_INF_FALSA_DIF = dr.GetString(dr.GetOrdinal("RD_INICIO_INF_FALSA_DIF")).ToString();
                                oCampos.RD_INICIO_INF_FALSA_DAS = dr.GetString(dr.GetOrdinal("RD_INICIO_INF_FALSA_DAS")).ToString();
                                oCampos.RD_INICIO_CONSULTOR = dr.GetString(dr.GetOrdinal("RD_INICIO_CONSULTOR")).ToString();
                                oCampos.INI_364f = dr.GetString(dr.GetOrdinal("INI_364f")).ToString();
                                oCampos.INI_364g = dr.GetString(dr.GetOrdinal("INI_364g")).ToString();
                                oCampos.INI_364h = dr.GetString(dr.GetOrdinal("INI_364h")).ToString();
                                oCampos.INI_364l = dr.GetString(dr.GetOrdinal("INI_364l")).ToString();
                                oCampos.INI_364o = dr.GetString(dr.GetOrdinal("INI_364o")).ToString();
                                oCampos.INI_364q = dr.GetString(dr.GetOrdinal("INI_364q")).ToString();
                                oCampos.INI_364s = dr.GetString(dr.GetOrdinal("INI_364s")).ToString();
                                oCampos.INI_364t = dr.GetString(dr.GetOrdinal("INI_364t")).ToString();
                                oCampos.INI_91Aa = dr.GetString(dr.GetOrdinal("INI_91Aa")).ToString();
                                oCampos.INI_91Ab = dr.GetString(dr.GetOrdinal("INI_91Ab")).ToString();
                                oCampos.INI_91Ad = dr.GetString(dr.GetOrdinal("INI_91Ad")).ToString();
                                oCampos.INI_91Ae = dr.GetString(dr.GetOrdinal("INI_91Ae")).ToString();
                                oCampos.INI_91Af = dr.GetString(dr.GetOrdinal("INI_91Af")).ToString();
                                oCampos.INI_91Ag = dr.GetString(dr.GetOrdinal("INI_91Ag")).ToString();
                                oCampos.INI_91Ah = dr.GetString(dr.GetOrdinal("INI_91Ah")).ToString();
                                oCampos.NUMERO_EXPEDIENTE = dr.GetString(dr.GetOrdinal("NUMERO_EXPEDIENTE")).ToString();
                                oCampos.FECHA_NOTIF_RDINI = dr.GetString(dr.GetOrdinal("FECHA_NOTIF_RDINI")).ToString();
                                oCampos.RECIBE_NOTIF_RDINI = dr.GetString(dr.GetOrdinal("RECIBE_NOTIF_RDINI")).ToString();
                                oCampos.OBS_NOTIF_RDINI = dr.GetString(dr.GetOrdinal("OBS_NOTIF_RDINI")).ToString();
                                oCampos.TIT_DESCARGO = dr.GetString(dr.GetOrdinal("TIT_DESCARGO")).ToString();
                                oCampos.LETRADO_DESCARGO = dr.GetString(dr.GetOrdinal("LETRADO_DESCARGO")).ToString();
                                oCampos.SOLIC_NUE_DOCS = dr.GetString(dr.GetOrdinal("SOLIC_NUE_DOCS")).ToString();
                                oCampos.N_INFTEC = dr.GetString(dr.GetOrdinal("N_INFTEC")).ToString();
                                oCampos.INF_LEGAL_TER_PAU = dr.GetString(dr.GetOrdinal("INF_LEGAL_TER_PAU")).ToString();
                                oCampos.INF_IMP_MULTA = dr.GetString(dr.GetOrdinal("INF_IMP_MULTA")).ToString();
                                oCampos.AMP_PAU = dr.GetString(dr.GetOrdinal("AMP_PAU")).ToString();
                                oCampos.RD_TERMINO_PAU = dr.GetString(dr.GetOrdinal("RD_TERMINO_PAU")).ToString();
                                oCampos.ARCHIVO = dr.GetString(dr.GetOrdinal("ARCHIVO")).ToString();
                                oCampos.TER_18a = dr.GetString(dr.GetOrdinal("TER_18a")).ToString();
                                oCampos.TER_18b = dr.GetString(dr.GetOrdinal("TER_18b")).ToString();
                                oCampos.TER_18c = dr.GetString(dr.GetOrdinal("TER_18c")).ToString();
                                oCampos.TER_18d = dr.GetString(dr.GetOrdinal("TER_18d")).ToString();
                                oCampos.TER_18e = dr.GetString(dr.GetOrdinal("TER_18e")).ToString();
                                oCampos.TER_295a = dr.GetString(dr.GetOrdinal("TER_295a")).ToString();
                                oCampos.TER_295b = dr.GetString(dr.GetOrdinal("TER_295b")).ToString();
                                oCampos.TER_295c = dr.GetString(dr.GetOrdinal("TER_295c")).ToString();
                                oCampos.TER_363e = dr.GetString(dr.GetOrdinal("TER_363e")).ToString();
                                oCampos.TER_363f = dr.GetString(dr.GetOrdinal("TER_363f")).ToString();
                                oCampos.TER_363g = dr.GetString(dr.GetOrdinal("TER_363g")).ToString();
                                oCampos.TER_363i = dr.GetString(dr.GetOrdinal("TER_363i")).ToString();
                                oCampos.TER_363k = dr.GetString(dr.GetOrdinal("TER_363k")).ToString();
                                oCampos.TER_363l = dr.GetString(dr.GetOrdinal("TER_363l")).ToString();
                                oCampos.TER_363m = dr.GetString(dr.GetOrdinal("TER_363m")).ToString();
                                oCampos.TER_363n = dr.GetString(dr.GetOrdinal("TER_363n")).ToString();
                                oCampos.TER_363r = dr.GetString(dr.GetOrdinal("TER_363r")).ToString();
                                oCampos.TER_363t = dr.GetString(dr.GetOrdinal("TER_363t")).ToString();
                                oCampos.TER_363u = dr.GetString(dr.GetOrdinal("TER_363u")).ToString();
                                oCampos.TER_363w = dr.GetString(dr.GetOrdinal("TER_363w")).ToString();
                                oCampos.TER_363v1 = dr.GetString(dr.GetOrdinal("TER_363v1")).ToString();
                                oCampos.TER_364f = dr.GetString(dr.GetOrdinal("TER_364f")).ToString();
                                oCampos.TER_364g = dr.GetString(dr.GetOrdinal("TER_364g")).ToString();
                                oCampos.TER_364h = dr.GetString(dr.GetOrdinal("TER_364h")).ToString();
                                oCampos.TER_364l = dr.GetString(dr.GetOrdinal("TER_364l")).ToString();
                                oCampos.TER_364o = dr.GetString(dr.GetOrdinal("TER_364o")).ToString();
                                oCampos.TER_364q = dr.GetString(dr.GetOrdinal("TER_364q")).ToString();
                                oCampos.TER_364s = dr.GetString(dr.GetOrdinal("TER_364s")).ToString();
                                oCampos.TER_364t = dr.GetString(dr.GetOrdinal("TER_364t")).ToString();
                                oCampos.TER_91Aa = dr.GetString(dr.GetOrdinal("TER_91Aa")).ToString();
                                oCampos.TER_91Ab = dr.GetString(dr.GetOrdinal("TER_91Ab")).ToString();
                                oCampos.TER_91Ad = dr.GetString(dr.GetOrdinal("TER_91Ad")).ToString();
                                oCampos.TER_91Ae = dr.GetString(dr.GetOrdinal("TER_91Ae")).ToString();
                                oCampos.TER_91Af = dr.GetString(dr.GetOrdinal("TER_91Af")).ToString();
                                oCampos.TER_91Ag = dr.GetString(dr.GetOrdinal("TER_91Ag")).ToString();
                                oCampos.TER_91Ah = dr.GetString(dr.GetOrdinal("TER_91Ah")).ToString();
                                oCampos.CADUCIDAD = dr.GetString(dr.GetOrdinal("CADUCIDAD")).ToString();
                                oCampos.MULTA = dr.GetDecimal(dr.GetOrdinal("MULTA"));
                                oCampos.FECHA_NOTIF_RDTER = dr.GetString(dr.GetOrdinal("FECHA_NOTIF_RDTER")).ToString();
                                oCampos.RECIBE_NOTIF_RDTER = dr.GetString(dr.GetOrdinal("RECIBE_NOTIF_RDTER")).ToString();
                                oCampos.OBS_NOTIF_RDTER = dr.GetString(dr.GetOrdinal("OBS_NOTIF_RDTER")).ToString();
                                oCampos.INF_FUND = dr.GetString(dr.GetOrdinal("INF_FUND")).ToString();
                                oCampos.SOLIC_FRACC = dr.GetString(dr.GetOrdinal("SOLIC_FRACC")).ToString();
                                oCampos.FECHA_PAGO_MULTA = dr.GetString(dr.GetOrdinal("FECHA_PAGO_MULTA")).ToString();
                                oCampos.RECURSO_RECONSI = dr.GetString(dr.GetOrdinal("RECURSO_RECONSI")).ToString();
                                oCampos.LETRADO_RECONSI = dr.GetString(dr.GetOrdinal("LETRADO_RECONSI")).ToString();
                                oCampos.RECURSO_APELA = dr.GetString(dr.GetOrdinal("RECURSO_APELA")).ToString();
                                oCampos.LETRADO_APELA = dr.GetString(dr.GetOrdinal("LETRADO_APELA")).ToString();
                                oCampos.OBSERVACION = dr.GetString(dr.GetOrdinal("OBSERVACION")).ToString();
                                oCampos.SITUACION_ACTUAL = dr.GetString(dr.GetOrdinal("SITUACION_ACTUAL")).ToString();
                                oCampos.UBICACION = dr.GetString(dr.GetOrdinal("UBICACION")).ToString();
                                oCampos.CODIGO_COACTIVO = dr.GetString(dr.GetOrdinal("CODIGO_COACTIVO")).ToString();
                                oCampos.OTROS = dr.GetString(dr.GetOrdinal("OTROS")).ToString();
                                lsCEntidad.Add(oCampos);
                            }//8
                        }//7
                    }//6
                }//5
                return lsCEntidad;
            }//4

            catch (Exception ex)
            {
                throw ex;
            }
        }//3
    }//2
}//1