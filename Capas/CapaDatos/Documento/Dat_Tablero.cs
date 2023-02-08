using GeneralSQL;
using Oracle.ManagedDataAccess.Client;
using System;
using CEntidadP = CapaEntidad.DOC.Ent_Tablero_Parametros;
using CEntidadR = CapaEntidad.DOC.Ent_Tablero_Resultados;

namespace CapaDatos.DOC
{
    public class Dat_Tablero
    {
        private DBOracle dBOracle = new DBOracle();

        public CEntidadR RegMostIndDFFFS(OracleConnection cn, CEntidadP oCEntidad)
        {
            CEntidadR oCampos = null;
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spDFFS_TableroControl_Listar", oCEntidad))
                {
                    if (dr != null)
                    {
                        oCampos = new CEntidadR();

                        if (dr.HasRows)
                        {
                            dr.Read();

                            if (oCEntidad.VAFILTRO.Equals("1"))
                            {
                                oCampos.DERIVADOS_DFFFS = dr.GetInt32(dr.GetOrdinal("DERIVADOS_DFFFS"));
                                oCampos.INF_EVALUADOS = dr.GetInt32(dr.GetOrdinal("INF_EVALUADOS"));
                                oCampos.INF_ARCHIVO = dr.GetInt32(dr.GetOrdinal("INF_ARCHIVO"));
                                oCampos.INF_DEVUELTOS = dr.GetInt32(dr.GetOrdinal("INF_DEVUELTOS"));
                                oCampos.INF_RSD_INICIO = dr.GetInt32(dr.GetOrdinal("INF_RSD_INICIO"));
                                oCampos.RSD_PENDIENTE = dr.GetInt32(dr.GetOrdinal("RSD_PENDIENTE"));
                                oCampos.CON_IFI_EMITIDOS = dr.GetInt32(dr.GetOrdinal("CON_IFI_EMITIDOS"));
                                oCampos.CON_IFI_PENDIENTES = dr.GetInt32(dr.GetOrdinal("CON_IFI_PENDIENTES"));
                                oCampos.RD_EMITIDOS = dr.GetInt32(dr.GetOrdinal("RD_EMITIDOS"));
                                oCampos.RD_PENDIENTES = dr.GetInt32(dr.GetOrdinal("RD_PENDIENTES"));
                                oCampos.RD_FIRMEZA = dr.GetInt32(dr.GetOrdinal("RD_FIRMEZA"));
                                oCampos.RD_PENDIENTE_FIRMEZA = dr.GetInt32(dr.GetOrdinal("RD_PENDIENTE_FIRMEZA"));
                                oCampos.DIAS_INFORME = dr.GetInt32(dr.GetOrdinal("DIAS_INFORME"));
                                oCampos.DIAS_EVALUACION = dr.GetInt32(dr.GetOrdinal("DIAS_EVALUACION"));
                                oCampos.DIAS_INSTRUCCION = dr.GetInt32(dr.GetOrdinal("DIAS_INSTRUCCION"));
                                oCampos.DIAS_DECISION = dr.GetInt32(dr.GetOrdinal("DIAS_DECISION"));
                                oCampos.MES_PAU = dr.GetInt32(dr.GetOrdinal("MES_PAU"));
                                oCampos.MES_INF_PAU = dr.GetInt32(dr.GetOrdinal("MES_INF_PAU"));
                                oCampos.IFI_EN_PLAZO = dr.GetInt32(dr.GetOrdinal("IFI_EN_PLAZO"));
                                oCampos.IFI_PARA_EMITIR = dr.GetInt32(dr.GetOrdinal("IFI_PARA_EMITIR"));
                                oCampos.RD_EN_PLAZO = dr.GetInt32(dr.GetOrdinal("RD_EN_PLAZO"));
                                oCampos.RD_PARA_EMITIR = dr.GetInt32(dr.GetOrdinal("RD_PARA_EMITIR"));
                                oCampos.FIRMEZA_EN_PLAZO = dr.GetInt32(dr.GetOrdinal("FIRMEZA_EN_PLAZO"));
                                oCampos.FIRMEZA_PARA_EMITIR = dr.GetInt32(dr.GetOrdinal("FIRMEZA_PARA_EMITIR"));
                                oCampos.CON_RSD_INICIO_NOTIFICADO = dr.GetInt32(dr.GetOrdinal("CON_RSD_INICIO_NOTIFICADO"));
                                oCampos.RD_EMITIDOS_NOTIFICADOS = dr.GetInt32(dr.GetOrdinal("RD_EMITIDOS_NOTIFICADOS"));
                                //--calculo de promedios
                                oCampos.DIAS_INFORME = (oCampos.DERIVADOS_DFFFS!=0)?oCampos.DIAS_INFORME / oCampos.DERIVADOS_DFFFS:0;
                                oCampos.DIAS_EVALUACION = (oCampos.INF_EVALUADOS != 0)?oCampos.DIAS_EVALUACION / oCampos.INF_EVALUADOS : 0;
                                oCampos.DIAS_INSTRUCCION = (oCampos.CON_IFI_EMITIDOS!=0) ?oCampos.DIAS_INSTRUCCION / oCampos.CON_IFI_EMITIDOS:0;
                                oCampos.DIAS_DECISION = (oCampos.RD_EMITIDOS!=0)?oCampos.DIAS_DECISION / oCampos.RD_EMITIDOS:0;
                                oCampos.MES_PAU = (oCampos.RD_EMITIDOS_NOTIFICADOS != 0)?oCampos.MES_PAU / oCampos.RD_EMITIDOS_NOTIFICADOS : 0;
                                oCampos.MES_INF_PAU = (oCampos.RD_EMITIDOS_NOTIFICADOS != 0)?oCampos.MES_INF_PAU / oCampos.RD_EMITIDOS_NOTIFICADOS : 0;

                            }
                            else if (oCEntidad.VAFILTRO.Equals("2"))
                            {
                                oCampos.DERIVADOS_DFFFS = dr.GetInt32(dr.GetOrdinal("DERIVADOS_DFFFS"));
                                oCampos.INF_EVALUADOS = dr.GetInt32(dr.GetOrdinal("INF_EVALUADOS"));
                                oCampos.INF_ARCHIVO = dr.GetInt32(dr.GetOrdinal("INF_ARCHIVO"));
                                oCampos.INF_DEVUELTOS = dr.GetInt32(dr.GetOrdinal("INF_DEVUELTOS"));
                                oCampos.INF_RSD_INICIO = dr.GetInt32(dr.GetOrdinal("INF_RSD_INICIO"));
                                oCampos.RSD_PENDIENTE = dr.GetInt32(dr.GetOrdinal("RSD_PENDIENTE"));
                                oCampos.CON_IFI_EMITIDOS = dr.GetInt32(dr.GetOrdinal("CON_IFI_EMITIDOS"));
                                oCampos.CON_IFI_PENDIENTES = dr.GetInt32(dr.GetOrdinal("CON_IFI_PENDIENTES"));
                                oCampos.DIAS_INFORME = dr.GetInt32(dr.GetOrdinal("DIAS_INFORME"));
                                oCampos.DIAS_EVALUACION = dr.GetInt32(dr.GetOrdinal("DIAS_EVALUACION"));
                                oCampos.DIAS_INSTRUCCION = dr.GetInt32(dr.GetOrdinal("DIAS_INSTRUCCION"));
                                oCampos.IFI_EN_PLAZO = dr.GetInt32(dr.GetOrdinal("IFI_EN_PLAZO"));
                                oCampos.IFI_PARA_EMITIR = dr.GetInt32(dr.GetOrdinal("IFI_PARA_EMITIR"));
                                oCampos.CON_RSD_INICIO_NOTIFICADO = dr.GetInt32(dr.GetOrdinal("CON_RSD_INICIO_NOTIFICADO"));
                                oCampos.DIAS_INFORME = (oCampos.DERIVADOS_DFFFS!=0)?oCampos.DIAS_INFORME / oCampos.DERIVADOS_DFFFS:0;
                                oCampos.DIAS_EVALUACION = (oCampos.INF_EVALUADOS != 0)?oCampos.DIAS_EVALUACION / oCampos.INF_EVALUADOS : 0;
                                oCampos.DIAS_INSTRUCCION = (oCampos.CON_IFI_EMITIDOS!=0)?oCampos.DIAS_INSTRUCCION / oCampos.CON_IFI_EMITIDOS:0;
                            }
                            else if (oCEntidad.VAFILTRO.Equals("3-1"))
                            {
                                oCampos.DERIVADOS_DFFFS = dr.GetInt32(dr.GetOrdinal("DERIVADOS_DFFFS"));
                            }
                            else if (oCEntidad.VAFILTRO.Equals("3-2"))
                            {
                                oCampos.INF_EVALUADOS = dr.GetInt32(dr.GetOrdinal("INF_EVALUADOS"));    
                            }
                            else if (oCEntidad.VAFILTRO.Equals("3-3"))
                            {
                                oCampos.CON_IFI_PENDIENTES = dr.GetInt32(dr.GetOrdinal("CON_IFI_PENDIENTES"));
                            }
                            else if (oCEntidad.VAFILTRO.Equals("3-4"))
                            {
                                oCampos.CON_IFI_EMITIDOS = dr.GetInt32(dr.GetOrdinal("CON_IFI_EMITIDOS"));
                            }
                            else if (oCEntidad.VAFILTRO.Equals("3-5"))
                            {
                                oCampos.RD_APELADA_RESUELTA = dr.GetInt32(dr.GetOrdinal("RD_APELADA_RESUELTA"));
                            }
                            else if (oCEntidad.VAFILTRO.Equals("3-6"))
                            {
                                oCampos.RD_CONFIRMADA = dr.GetInt32(dr.GetOrdinal("RD_CONFIRMADA"));
                            }
                            else if (oCEntidad.VAFILTRO.Equals("3-7"))
                            {
                                oCampos.RD_RECONSIDERADA_RESUELTA = dr.GetInt32(dr.GetOrdinal("RD_RECONSIDERADA_RESUELTA"));
                            }
                            else if (oCEntidad.VAFILTRO.Equals("3-8"))
                            {
                                oCampos.RD_EMITIDA = dr.GetInt32(dr.GetOrdinal("RD_EMITIDA"));
                            }
                            else if (oCEntidad.VAFILTRO.Equals("4-1"))
                            {
                                oCampos.DERIVADOS_DFFFS = dr.GetInt32(dr.GetOrdinal("DERIVADOS_DFFFS"));
                                oCampos.INF_EVALUADOS = dr.GetInt32(dr.GetOrdinal("INF_EVALUADOS"));
                            }
                            /*else if (oCEntidad.VAFILTRO.Equals("4-2"))
                            {
                                oCampos.INF_EVALUADOS = dr.GetInt32(dr.GetOrdinal("INF_EVALUADOS"));
                            }*/
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
