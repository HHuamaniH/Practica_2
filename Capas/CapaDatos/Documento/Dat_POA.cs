using CapaEntidad.DOC;
using GeneralSQL;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CEntidad = CapaEntidad.DOC.Ent_POA;
using CEntidadEM = CapaEntidad.DOC.Ent_ERRORMATERIAL;
using CEntPersona = CapaEntidad.DOC.Ent_GENEPERSONA;
using SQL = GeneralSQL.Data.SQL;

/// <summary>
/// 2014-08-26  EPB Se añade el metodo RegMostItemsHijoMadNoMad
/// 2014-08-22  EPB Se añaden los metodos RegMostrarListaHijoItems y MostrarListaItems para que devuelvan las tablas de censos de POA Hijo segun el caso.
/// 2014-08-14  EPB Se modifica el codigo para considerar las consultas, modificaciones y borrados de vertices con el campo COD_SECUENCIAL como VERT_COD_SECUENCIAL
/// </summary>
namespace CapaDatos.DOC
{
    /// <summary>
    /// 
    /// </summary>
    public class Dat_POA
    {
        private SQL oGDataSQL = new SQL();

        // pa instaciar las clase que ejecutacle
        private DBOracle dBOracle = new DBOracle();
        /// <summary>
        /// Devuelve el Detalle del POA Hijo 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        //public CEntidad RegMostrarListaHijoItems(SqlConnection cn, CEntidad oCEntidad)
        public CEntidad RegMostrarListaHijoItems(OracleConnection cn, CEntidad oCEntidad)
        {
            try
            {
                return MostrarListaItems(cn, oCEntidad, 1);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Devuelve el Detalle del POA Padre
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public CEntidad RegMostrarListaItems(OracleConnection cn, CEntidad oCEntidad)
        {
            try
            {
                return MostrarListaItems(cn, oCEntidad, 0);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Devuelve el Detalle del POA Padre o Hijo segun sea el caso
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <param name="tipo">0=POA Padre, 1=POA Hijo</param>
        /// <returns></returns>
        private CEntidad MostrarListaItems(OracleConnection cn, CEntidad oCEntidad, int tipo)
        {
            CEntidad oCampos = new CEntidad();
            String stprocedure = "";
            try
            {
                if (tipo == 0)
                {
                    stprocedure = "DOC_OSINFOR_ERP_MIGRACION.spPOAMostItems";
                }
                if (tipo == 1)
                {
                    stprocedure = "DOC_OSINFOR_ERP_MIGRACION.spPOAMostItems";
                    //stprocedure = "DOC.spPOAHijoMostItemsPrueba";
                }
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, stprocedure, oCEntidad))
                {
                    if (dr != null)
                    {
                        oCampos.ListTIOCULAR = new List<CEntidad>();
                        oCampos.ListTRAPROBACION = new List<CEntidad>();
                        oCampos.ListSAPROBACION = new List<CEntidad>();
                        oCampos.ListRAprueba = new List<CEntidad>();
                        oCampos.ListRApruebaISitu = new List<CEntidad>();
                        //oCampos.ListRReformula = new List<CEntidad>();
                        oCampos.ListRReformulaISitu = new List<CEntidad>();
                        oCampos.ListASBSAmbientales = new List<CEntidad>();
                        oCampos.ListBioseguridad = new List<CEntidad>();
                        oCampos.ListMadeCENSO = new List<CEntidad>();
                        oCampos.ListMadeBusquedaCENSO = new List<CEntidad>();
                        oCampos.ListNoMadeCENSO = new List<CEntidad>();
                        //oCampos.ListMadeBEXTRACCION = new List<CEntidad>();
                        //oCampos.ListNoMadeBEXTRACCION = new List<CEntidad>();
                        //oCampos.ListISituBEXTRACCION = new List<CEntidad>();
                        oCampos.ListVERTICE = new List<CEntidad>();
                        oCampos.ListEliTABLA = new List<CEntidad>();
                        //oCampos.ListREFORMULAPOA = new List<CEntidad>();
                        oCampos.ListAOCULAR = new List<CEntidad>();
                        oCampos.ListKARDEX = new List<CEntidad>();
                        oCampos.ListHijoMadeCENSO = new List<CEntidad>();
                        oCampos.ListHijoNoMadeCENSO = new List<CEntidad>();
                        oCampos.ListRDReformulaPOA = new List<CEntidad>();
                        oCampos.ListBExtPOA = new List<CEntidad>();
                        oCampos.ListDependencia = new List<CEntidad>();
                        oCampos.ListPOAErrorMaterialG = new List<CEntidadEM>();
                        oCampos.ListPOAErrorMaterialA = new List<CEntidadEM>();
                        //linea para carrizos
                        //oCampos.ListCarrizos = new List<CEntidad>();
                        //oCampos.ListRRCarrizos = new List<CEntidad>();
                        //oCampos.ListEliCarrizos = new List<CEntidad>();
                        //oCampos.ListKardexCarrizos = new List<CEntidad>();
                        //plantas medicinales
                        //oCampos.ListMedicinales = new List<CEntidad>();
                        //oCampos.ListRRMedicinales = new List<CEntidad>();
                        //oCampos.ListBExtMedicinales = new List<CEntidad>();
                        //05/05/2021 lista de parcelas
                        oCampos.ListParcela = new List<CEntidad>();
                        //05/09/2023
                        oCampos.ListDETREGENTE = new List<CEntidad>();
                        CEntidad oCamposDet;
                        //
                        if (dr.HasRows)
                        {
                            dr.Read();
                            oCampos.COD_THABILITANTE = dr.GetString(dr.GetOrdinal("COD_THABILITANTE"));
                            oCampos.NUM_POA = dr.GetInt32(dr.GetOrdinal("NUM_POA"));
                            oCampos.NOMBRE_POA = dr.GetString(dr.GetOrdinal("NOMBRE_POA"));
                            oCampos.NP_NUM_POA = dr.GetBoolean(dr.GetOrdinal("NP_NUM_POA"));
                            oCampos.ESPO = dr.GetBoolean(dr.GetOrdinal("ESPO"));
                            oCampos.NUM_PCOMPLEMENTARIO = dr.GetInt32(dr.GetOrdinal("NUM_PCOMPLEMENTARIO"));
                            oCampos.AREA = dr.GetDecimal(dr.GetOrdinal("AREA"));
                            //oCampos.AREA = Decimal.Parse(dr.GetString(dr.GetOrdinal("AREA")));
                            oCampos.PCA = dr.GetString(dr.GetOrdinal("PCA"));
                            oCampos.ACTA_IOCULAR_NUM = dr.GetString(dr.GetOrdinal("ACTA_IOCULAR_NUM"));
                            oCampos.ACTA_IOCULAR_FECHA = dr.GetString(dr.GetOrdinal("ACTA_IOCULAR_FECHA")).Trim();
                            oCampos.ZAFRA_PCA = dr.GetString(dr.GetOrdinal("ZAFRA_PCA"));
                            oCampos.INICIO_VIGENCIA = dr.GetString(dr.GetOrdinal("INICIO_VIGENCIA")).Trim();
                            oCampos.FIN_VIGENCIA = dr.GetString(dr.GetOrdinal("FIN_VIGENCIA")).Trim();
                            oCampos.CONSULTOR_CODIGO = dr.GetString(dr.GetOrdinal("CONSULTOR_CODIGO"));

                            //CAMBIOS
                            oCampos.NROLICENCIA = dr.GetString(dr.GetOrdinal("NROLICENCIA"));
                            oCampos.RESAPROBACION = dr.GetString(dr.GetOrdinal("RESAPROBACION"));
                            oCampos.OTORGAMIENTO = dr.GetString(dr.GetOrdinal("OTORGAMIENTO"));
                            oCampos.CIP = dr.GetString(dr.GetOrdinal("CIP"));
                            oCampos.ESTADO_REGENTE = dr.GetString(dr.GetOrdinal("ESTADO_REGENTE"));

                            oCampos.CONSULTOR_NUM_REGISTRO_FFS = dr.GetString(dr.GetOrdinal("CONSULTOR_NUM_REGISTRO_FFS"));
                            oCampos.REGENTE_NUM_REGISTRO_FFS = dr.GetString(dr.GetOrdinal("REGENTE_NUM_REGISTRO_FFS"));
                            oCampos.CONSULTOR_NOMBRE = dr.GetString(dr.GetOrdinal("CONSULTOR_NOMBRE"));
                            oCampos.CONSULTOR_DNI = dr.GetString(dr.GetOrdinal("CONSULTOR_DNI"));
                            oCampos.CONSULTOR_NUM_REGISTRO_PROFESIONAL = dr.GetString(dr.GetOrdinal("CONSULTOR_NUM_REGISTRO_PROFESIONAL"));
                            oCampos.ITECNICO_IOCULAR_NUM = dr.GetString(dr.GetOrdinal("ITECNICO_IOCULAR_NUM"));
                            oCampos.ITECNICO_IOCULAR_FECHA = dr.GetString(dr.GetOrdinal("ITECNICO_IOCULAR_FECHA")).Trim();
                            oCampos.ITECNICO_RAPROBACION_NUM = dr.GetString(dr.GetOrdinal("ITECNICO_RAPROBACION_NUM"));
                            oCampos.ITECNICO_RAPROBACION_FECHA = dr.GetString(dr.GetOrdinal("ITECNICO_RAPROBACION_FECHA")).Trim();
                            oCampos.ITECNICO_REFORMULA_POA_NUM = dr.GetString(dr.GetOrdinal("ITECNICO_REFORMULA_POA_NUM"));
                            oCampos.ITECNICO_REFORMULA_POA_FECHA = dr.GetString(dr.GetOrdinal("ITECNICO_REFORMULA_POA_FECHA")).Trim();
                            oCampos.ARESOLUCION_NUM = dr.GetString(dr.GetOrdinal("ARESOLUCION_NUM"));
                            oCampos.ARESOLUCION_FECHA = dr.GetString(dr.GetOrdinal("ARESOLUCION_FECHA")).Trim();
                            oCampos.ARESOLUCION_COD_FUNCIONARIO = dr.GetString(dr.GetOrdinal("ARESOLUCION_COD_FUNCIONARIO"));
                            oCampos.ARESOLUCION_FUNCIONARIO_NOMBRE = dr.GetString(dr.GetOrdinal("ARESOLUCION_FUNCIONARIO_NOMBRE"));
                            oCampos.ARESOLUCION_FUNCIONARIO_ODATOS = dr.GetString(dr.GetOrdinal("ARESOLUCION_FUNCIONARIO_ODATOS"));

                            oCampos.ESTADO_ORIGEN = dr.GetString(dr.GetOrdinal("ESTADO_ORIGEN"));
                            oCampos.CUENTA_PCOMPLEMENTARIO = dr.GetBoolean(dr.GetOrdinal("CUENTA_PCOMPLEMENTARIO"));
                            oCampos.CUENTA_REINGRESO = dr.GetBoolean(dr.GetOrdinal("CUENTA_REINGRESO"));
                            oCampos.BEXTRACCION_FEMISION = dr.GetString(dr.GetOrdinal("BEXTRACCION_FEMISION"));
                            oCampos.CUENTA_FIN_ZAFRA = dr.GetBoolean(dr.GetOrdinal("CUENTA_FIN_ZAFRA"));
                            oCampos.OBSERVACION = dr.GetString(dr.GetOrdinal("OBSERVACION"));
                            oCampos.COD_MTIPO = dr.GetString(dr.GetOrdinal("COD_MTIPO"));
                            oCampos.COD_UBIDEPARTAMENTO = dr.GetString(dr.GetOrdinal("COD_UBIDEPARTAMENTO"));
                            oCampos.INDICADOR = dr.GetString(dr.GetOrdinal("INDICADOR"));

                            oCampos.TMETODO_EPOBLACIONAL = dr.GetString(dr.GetOrdinal("TMETODO_EPOBLACIONAL"));
                            oCampos.MANEJO_HABITAT = dr.GetString(dr.GetOrdinal("MANEJO_HABITAT"));
                            oCampos.COMERCIO = dr.GetString(dr.GetOrdinal("COMERCIO"));
                            oCampos.CONTROL_IMPACTO = dr.GetString(dr.GetOrdinal("CONTROL_IMPACTO"));
                            oCampos.INVESTIGACION = dr.GetString(dr.GetOrdinal("INVESTIGACION"));
                            oCampos.CAPACITACION = dr.GetString(dr.GetOrdinal("CAPACITACION"));

                            oCampos.COD_ESTADO_DOC = dr.GetString(dr.GetOrdinal("COD_ESTADO_DOC"));
                            oCampos.OBSERVACIONES_CONTROL = dr.GetString(dr.GetOrdinal("OBSERVACIONES_CONTROL"));
                            oCampos.OBSERV_SUBSANAR = dr.GetBoolean(dr.GetOrdinal("OBSERV_SUBSANAR"));
                            oCampos.COD_OD_REGISTRO = dr.GetString(dr.GetOrdinal("COD_OD_REGISTRO"));
                            oCampos.SIN_INS_OCULAR = dr.GetBoolean(dr.GetOrdinal("SIN_INS_OCULAR"));
                            oCampos.USUARIO_REGISTRO = dr.GetString(dr.GetOrdinal("USUARIO_REGISTRO"));
                            oCampos.USUARIO_CONTROL = dr.GetString(dr.GetOrdinal("USUARIO_CONTROL"));
                            oCampos.COD_DEPENDENCIA = dr.GetInt32(dr.GetOrdinal("COD_DEPENDENCIA"));

                            //Acervo Documentario                      

                            oCampos.RLEGAL_NOMBRES = dr.GetString(dr.GetOrdinal("RLEGAL_NOMBRES"));
                            oCampos.AD_ACTA_NRO = dr.GetString(dr.GetOrdinal("AD_ACTA_NRO"));
                            oCampos.AD_FECHA = dr.GetString(dr.GetOrdinal("AD_FECHA")).Trim();
                            oCampos.AD_VERIFICADOR_CODIGO = dr.GetString(dr.GetOrdinal("AD_VERIFICADOR_CODIGO"));
                            oCampos.VERIFICADOR_ACERVO_NOMBRES = dr.GetString(dr.GetOrdinal("VERIFICADOR_ACERVO_NOMBRES"));
                            oCampos.REGENTE_NRO_LICENCIA = dr.GetString(dr.GetOrdinal("REGENTE_NRO_LICENCIA"));
                            oCampos.REGENTE_EMAIL = dr.GetString(dr.GetOrdinal("REGENTE_EMAIL"));


                            oCampos.AD_THContrato = dr.GetBoolean(dr.GetOrdinal("AD_THContrato"));
                            oCampos.AD_THAdenda = dr.GetBoolean(dr.GetOrdinal("AD_THAdenda"));
                            oCampos.AD_THPermiso = dr.GetBoolean(dr.GetOrdinal("AD_THPermiso"));
                            oCampos.AD_THAutorizacion = dr.GetBoolean(dr.GetOrdinal("AD_THAutorizacion"));
                            oCampos.AD_THResolucion = dr.GetBoolean(dr.GetOrdinal("AD_THResolucion"));

                            oCampos.AD_REAprobacion = dr.GetBoolean(dr.GetOrdinal("AD_REAprobacion"));
                            oCampos.AD_RECargo = dr.GetBoolean(dr.GetOrdinal("AD_RECargo"));
                            oCampos.AD_REReingreso = dr.GetBoolean(dr.GetOrdinal("AD_REReingreso"));
                            oCampos.AD_REMovilizacion = dr.GetBoolean(dr.GetOrdinal("AD_REMovilizacion"));
                            oCampos.AD_REReajuste = dr.GetBoolean(dr.GetOrdinal("AD_REReajuste"));

                            oCampos.AD_DGPGMF = dr.GetBoolean(dr.GetOrdinal("AD_DGPGMF"));
                            oCampos.AD_DGPMFI = dr.GetBoolean(dr.GetOrdinal("AD_DGPMFI"));
                            oCampos.AD_DGPO = dr.GetBoolean(dr.GetOrdinal("AD_DGPO"));
                            oCampos.AD_DGDEMA = dr.GetBoolean(dr.GetOrdinal("AD_DGDEMA"));
                            oCampos.AD_DGPMCA = dr.GetBoolean(dr.GetOrdinal("AD_DGPMCA"));

                            oCampos.AD_ODBalance = dr.GetBoolean(dr.GetOrdinal("AD_ODBalance"));
                            oCampos.AD_ODRefinanciamiento = dr.GetBoolean(dr.GetOrdinal("AD_ODRefinanciamiento"));
                            oCampos.AD_ODSuspension = dr.GetBoolean(dr.GetOrdinal("AD_ODSuspension"));
                            oCampos.AD_ODGarantias = dr.GetBoolean(dr.GetOrdinal("AD_ODGarantias"));
                            oCampos.AD_ODInfEjecucionAnual = dr.GetBoolean(dr.GetOrdinal("AD_ODInfEjecucionAnual"));
                            oCampos.AD_ODInfEjecucionFinal = dr.GetBoolean(dr.GetOrdinal("AD_ODInfEjecucionFinal"));

                            oCampos.AD_EIGTF = dr.GetBoolean(dr.GetOrdinal("AD_EIGTF"));
                            oCampos.AD_EILibro = dr.GetBoolean(dr.GetOrdinal("AD_EILibro"));
                            oCampos.AD_EIKardex = dr.GetBoolean(dr.GetOrdinal("AD_EIKardex"));
                            oCampos.AD_EIForma20 = dr.GetBoolean(dr.GetOrdinal("AD_EIForma20"));
                            oCampos.AD_EIBalance = dr.GetBoolean(dr.GetOrdinal("AD_EIBalance"));
                            oCampos.AD_EILista = dr.GetBoolean(dr.GetOrdinal("AD_EILista"));

                            oCampos.AD_OTActa = dr.GetBoolean(dr.GetOrdinal("AD_OTActa"));
                            oCampos.AD_OTInfInspeccion = dr.GetBoolean(dr.GetOrdinal("AD_OTInfInspeccion"));
                            oCampos.AD_OTInfRecomienda = dr.GetBoolean(dr.GetOrdinal("AD_OTInfRecomienda"));
                            oCampos.AD_OTContratoRegente = dr.GetBoolean(dr.GetOrdinal("AD_OTContratoRegente"));
                            oCampos.AD_OTContratoTercero = dr.GetBoolean(dr.GetOrdinal("AD_OTContratoTercero"));
                            oCampos.AD_OTDenuncias = dr.GetBoolean(dr.GetOrdinal("AD_OTDenuncias"));

                            oCampos.AD_CAIncluyeCD = dr.GetBoolean(dr.GetOrdinal("AD_CAIncluyeCD"));
                            oCampos.AD_CANroTomos = dr["AD_CANroTomos"] == DBNull.Value ? "" : dr.GetInt32(dr.GetOrdinal("AD_CANroTomos")).ToString();
                            oCampos.AD_CANroFolios = dr["AD_CANroFolios"] == DBNull.Value ? "" : dr.GetInt32(dr.GetOrdinal("AD_CANroFolios")).ToString();

                            oCampos.AD_RSConcluido = dr.GetBoolean(dr.GetOrdinal("AD_RSConcluido"));

                            oCampos.AD_RSProceso = dr.GetBoolean(dr.GetOrdinal("AD_RSProceso"));
                            oCampos.AD_RSPendiente = dr.GetBoolean(dr.GetOrdinal("AD_RSPendiente"));
                            oCampos.AD_Observaciones = dr.GetString(dr.GetOrdinal("AD_Observaciones"));


                            //DIRECION UBIGEO REGENTE
                            oCampos.COD_UBIGEO_REGENTE = dr.GetString(dr.GetOrdinal("COD_UBIGEO_REGENTE"));
                            oCampos.UBIGEO_REGENTE = dr.GetString(dr.GetOrdinal("UBIGEO_REGENTE"));
                            oCampos.DIRECCION_REGENTE = dr.GetString(dr.GetOrdinal("DIRECCION_REGENTE"));

                            oCampos.SAPROBACION_NUM = dr.GetString(dr.GetOrdinal("SAPROBACION_NUM"));
                            oCampos.SAPROBACION_FECHA = dr.GetString(dr.GetOrdinal("SAPROBACION_FECHA"));
                            oCampos.ACTA_IOCULAR_COD_FUNCIONARIO = dr.GetString(dr.GetOrdinal("ACTA_IOCULAR_COD_FUNCIONARIO"));
                            oCampos.ACTA_IOCULAR_FUNCIONARIO = dr.GetString(dr.GetOrdinal("ACTA_IOCULAR_FUNCIONARIO"));
                            oCampos.ACTA_IOCULAR_CARGO = dr.GetString(dr.GetOrdinal("ACTA_IOCULAR_CARGO"));

                        }
                        //POA_DET_TIOCULAR
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.COD_PERSONA = dr["COD_PERSONA"].ToString();
                                oCamposDet.PERSONA = dr["PERSONA"].ToString();
                                oCamposDet.N_DOCUMENTO = dr["N_DOCUMENTO"].ToString();
                                //oCamposDet.CARGO = dr["CARGO"].ToString();
                                oCamposDet.COD_PTIPO = dr["COD_PTIPO"].ToString();
                                oCamposDet.TIPO_CARGO = dr["TIPO_CARGO"].ToString();
                                oCamposDet.RegEstado = 0;
                                oCampos.ListTIOCULAR.Add(oCamposDet);
                            }
                        }
                        //POA_DET_TRAPROBACION
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.COD_PERSONA = dr["COD_PERSONA"].ToString();
                                oCamposDet.PERSONA = dr["PERSONA"].ToString();
                                oCamposDet.N_DOCUMENTO = dr["N_DOCUMENTO"].ToString();
                                //oCamposDet.CARGO = dr["CARGO"].ToString();
                                oCamposDet.COD_PTIPO = dr["COD_PTIPO"].ToString();
                                oCamposDet.TIPO_CARGO = dr["TIPO_CARGO"].ToString();
                                oCamposDet.RegEstado = 0;
                                oCampos.ListTRAPROBACION.Add(oCamposDet);
                            }
                        }
                        if (oCampos.COD_MTIPO == "0000020")
                        {
                            //POA_DET_MADE_NOMADE_EAAPROVECHARCARRIZOS
                            dr.NextResult();
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    oCamposDet = new CEntidad();
                                    oCamposDet.COD_ESPECIES = dr["COD_ESPECIES"].ToString();
                                    oCamposDet.COD_SECUENCIAL = Int32.Parse(dr["COD_SECUENCIAL"].ToString());
                                    oCamposDet.ESPECIES = dr["ESPECIES"].ToString();
                                    oCamposDet.CANTIDAD = Int32.Parse(dr["CANTIDAD"].ToString());
                                    oCamposDet.SuperficieHa = Decimal.Parse(dr["SUPERFICIE_HA"].ToString());
                                    oCamposDet.TIPOMADERABLE = dr["TIPOMADERABLE"].ToString();
                                    oCamposDet.COD_ESPECIES_SERFOR = dr["COD_ESPECIES_SERFOR"].ToString();
                                    oCamposDet.ESPECIES_SERFOR = dr["ESPECIES_SERFOR"].ToString();
                                    oCamposDet.OBSERVACION = dr["OBSERVACION"].ToString();
                                    oCamposDet.PCA = dr["PCA"].ToString();
                                    oCamposDet.RegEstado = 0;
                                    oCampos.ListRAprueba.Add(oCamposDet);
                                }
                            }
                        }
                        else if (oCampos.COD_MTIPO == "0000021")
                        {
                            //POA_DET_MADE_NOMADE_EAAPROVECHAR plantas medicinales
                            dr.NextResult();
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    oCamposDet = new CEntidad();
                                    oCamposDet.COD_ESPECIES = dr["COD_ESPECIES"].ToString();
                                    oCamposDet.COD_SECUENCIAL = Int32.Parse(dr["COD_SECUENCIAL"].ToString());
                                    oCamposDet.ABUNDANCIA = Decimal.Parse(dr["ABUNDANCIA"].ToString());
                                    oCamposDet.NUMINDIVIDUOS = Decimal.Parse(dr["NUM_INDIVIDUOS"].ToString());
                                    oCamposDet.PESO = Decimal.Parse(dr["PESO"].ToString());
                                    oCamposDet.RENDIMIENTO = Decimal.Parse(dr["RENDIMIENTO"].ToString());
                                    oCamposDet.UNIDAD_MEDIDA = dr["UNIDAD_MEDIDA"].ToString();
                                    oCamposDet.TIPOMADERABLE = dr["TIPOMADERABLE"].ToString();
                                    oCamposDet.ESPECIES = dr["ESPECIES"].ToString();
                                    oCamposDet.COD_ESPECIES_SERFOR = dr["COD_ESPECIES_SERFOR"].ToString();
                                    oCamposDet.ESPECIES_SERFOR = dr["ESPECIES_SERFOR"].ToString();
                                    oCamposDet.OBSERVACION = dr["OBSERVACION"].ToString();
                                    oCamposDet.PCA = dr["PCA"].ToString();
                                    oCamposDet.RegEstado = 0;
                                    oCampos.ListRAprueba.Add(oCamposDet);
                                }
                            }
                        }
                        else
                        {
                            //POA_DET_MADE_NOMADE_EAAPROVECHAR
                            dr.NextResult();
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    oCamposDet = new CEntidad();
                                    oCamposDet.COD_ESPECIES = dr["COD_ESPECIES"].ToString();
                                    oCamposDet.COD_SECUENCIAL = Int32.Parse(dr["COD_SECUENCIAL"].ToString());
                                    oCamposDet.ESPECIES = dr["ESPECIES"].ToString();
                                    oCamposDet.NUM_ARBOLES = Int32.Parse(dr["NUM_ARBOLES"].ToString());
                                    oCamposDet.UNIDAD_MEDIDA = dr["UNIDAD_MEDIDA"].ToString();
                                    oCamposDet.VOLUMEN_KILOGRAMOS = dr.GetDecimal(dr.GetOrdinal("VOLUMEN_KILOGRAMOS"));
                                    //oCamposDet.VOLUMEN_KILOGRAMOS = Decimal.Parse(dr["VOLUMEN_KILOGRAMOS"].ToString());
                                    oCamposDet.OBSERVACION = dr["OBSERVACION"].ToString();
                                    oCamposDet.TIPOMADERABLE = dr["TIPOMADERABLE"].ToString();
                                    oCamposDet.COD_ESPECIES_SERFOR = dr["COD_ESPECIES_SERFOR"].ToString();
                                    oCamposDet.ESPECIES_SERFOR = dr["ESPECIES_SERFOR"].ToString();
                                    oCamposDet.RegEstado = 0;

                                    if (oCamposDet.UNIDAD_MEDIDA.Trim().Equals("") || oCamposDet.UNIDAD_MEDIDA.Equals("-"))
                                    {
                                        if (oCamposDet.TIPOMADERABLE.Equals("CARBON") || oCamposDet.TIPOMADERABLE.Equals("NO MADERABLES"))
                                            oCamposDet.UNIDAD_MEDIDA = "KG";
                                        else if (oCamposDet.TIPOMADERABLE.Equals("MADERABLES")) oCamposDet.UNIDAD_MEDIDA = "M3";
                                    }

                                    oCamposDet.PCA = dr["PCA"].ToString();
                                    oCampos.ListRAprueba.Add(oCamposDet);
                                }
                            }
                        }

                        //POA_INSITU_DET_EAAPROVECHAR
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("COD_ESPECIES");
                            int pt2 = dr.GetOrdinal("COD_SECUENCIAL");
                            int pt3 = dr.GetOrdinal("ESPECIES");
                            int pt4 = dr.GetOrdinal("PERIODO");
                            int pt5 = dr.GetOrdinal("CUOTA_SACA");
                            int pt6 = dr.GetOrdinal("METODO_CAZA");
                            int pt7 = dr.GetOrdinal("SISTEMA_MARCAJE");
                            int pt8 = dr.GetOrdinal("DENSIDAD");
                            int pt9 = dr.GetOrdinal("OBSERVACION");
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.COD_ESPECIES = dr.GetString(pt1);
                                oCamposDet.COD_SECUENCIAL = dr.GetInt32(pt2);
                                oCamposDet.ESPECIES = dr.GetString(pt3);
                                oCamposDet.PERIODO = dr.GetString(pt4);
                                oCamposDet.CUOTA_SACA = dr.GetInt32(pt5);
                                oCamposDet.METODO_CAZA = dr.GetString(pt6);
                                oCamposDet.SISTEMA_MARCAJE = dr.GetString(pt7);
                                oCamposDet.DENSIDAD = dr.GetInt32(pt8);
                                oCamposDet.COD_ESPECIES_SERFOR = dr.GetString(dr.GetOrdinal("COD_ESPECIES_SERFOR"));
                                oCamposDet.ESPECIES_SERFOR = dr.GetString(dr.GetOrdinal("ESPECIES_SERFOR"));
                                oCamposDet.OBSERVACION = dr.GetString(pt9);
                                oCamposDet.RegEstado = 0;
                                oCampos.ListRApruebaISitu.Add(oCamposDet);
                            }
                        }
                        //POA_INSITU_DET_ACTIVIDADES
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("COD_SECUENCIAL");
                            int pt2 = dr.GetOrdinal("ACTIVIDAD");
                            int pt3 = dr.GetOrdinal("OBJETIVOS");
                            int pt4 = dr.GetOrdinal("METODO");
                            int pt5 = dr.GetOrdinal("PRESUPUESTO");
                            int pt6 = dr.GetOrdinal("OBSERVACION");
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.COD_SECUENCIAL = dr.GetInt32(pt1);
                                oCamposDet.ACTIVIDAD = dr.GetString(pt2);
                                oCamposDet.OBJETIVOS = dr.GetString(pt3);
                                oCamposDet.METODO = dr.GetString(pt4);
                                oCamposDet.PRESUPUESTO = Decimal.Parse(dr.GetString(pt5));
                                oCamposDet.OBSERVACION = dr.GetString(pt6);
                                oCamposDet.RegEstado = 0;
                                oCampos.ListASBSAmbientales.Add(oCamposDet);
                            }
                        }
                        //POA_INSITU_DET_BIOSEGURIDAD
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("COD_BIOSEGURIDAD");
                            int pt2 = dr.GetOrdinal("BIOSEGURIDAD");
                            int pt3 = dr.GetOrdinal("DESCRIPCION");
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.COD_BIOSEGURIDAD = dr.GetString(pt1);
                                oCamposDet.BIOSEGURIDAD = dr.GetString(pt2);
                                oCamposDet.DESCRIPCION = dr.GetString(pt3);
                                oCamposDet.RegEstado = 0;
                                oCampos.ListBioseguridad.Add(oCamposDet);
                            }
                        }
                        //POA_DET_MADERABLE_CENSO
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            Int32 num_fila = 0;
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCampos.NUMERO_FILA = num_fila;
                                oCamposDet.COD_ESPECIES = dr["COD_ESPECIES"].ToString();
                                oCamposDet.COD_SECUENCIAL = Int32.Parse(dr["COD_SECUENCIAL"].ToString());
                                oCamposDet.COD_ECONDICION = dr["COD_ECONDICION"].ToString();
                                oCamposDet.COD_EESTADO = dr["COD_EESTADO"].ToString();
                                oCamposDet.ESPECIES = dr["ESPECIES"].ToString();
                                oCamposDet.BLOQUE = dr["BLOQUE"].ToString();
                                oCamposDet.FAJA = dr["FAJA"].ToString();
                                oCamposDet.CODIGO = dr["CODIGO"].ToString();
                                oCamposDet.VOLUMEN = Decimal.Parse(dr["VOLUMEN"].ToString());
                                oCamposDet.DAP = Decimal.Parse(dr["DAP"].ToString());
                                oCamposDet.AC = Decimal.Parse(dr["AC"].ToString());
                                oCamposDet.DMC = Int32.Parse(dr["DMC"].ToString());
                                oCamposDet.ZONA = dr["ZONA"].ToString();
                                oCamposDet.COORDENADA_ESTE = Int32.Parse(dr["COORDENADA_ESTE"].ToString());
                                oCamposDet.COORDENADA_NORTE = Int32.Parse(dr["COORDENADA_NORTE"].ToString());
                                oCamposDet.OBSERVACION = dr["OBSERVACION"].ToString();
                                oCamposDet.ESTADO_MUESTRA = dr["ESTADO_MUESTRA"].ToString();
                                oCamposDet.CONDICION = dr["CONDICION"].ToString();
                                oCamposDet.ESTADO = dr["ESTADO"].ToString();
                                oCamposDet.COD_ESPECIES_ARESOLUCION = dr["COD_ESPECIES_ARESOLUCION"].ToString();
                                oCamposDet.ESPECIES_ARESOLUCION = dr["ESPECIES_ARESOLUCION"].ToString();
                                oCamposDet.RegEstado = 0;
                                oCamposDet.PCA = dr["PCA"].ToString(); ;
                                oCampos.ListMadeCENSO.Add(oCamposDet);
                                num_fila++;
                            }
                        }
                        oCampos.ListMadeBusquedaCENSO = oCampos.ListMadeCENSO;
                        //POA_DET_NOMADERABLE_CENSO
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.COD_ESPECIES = dr["COD_ESPECIES"].ToString();
                                oCamposDet.COD_SECUENCIAL = Int32.Parse(dr["COD_SECUENCIAL"].ToString());
                                oCamposDet.COD_ECONDICION = dr["COD_ECONDICION"].ToString();
                                oCamposDet.ESPECIES = dr["ESPECIES"].ToString();
                                oCamposDet.NUM_ESTRADA = dr["NUM_ESTRADA"].ToString();
                                oCamposDet.CODIGO = dr["CODIGO"].ToString();
                                oCamposDet.DIAMETRO = Decimal.Parse(dr["DIAMETRO"].ToString());
                                oCamposDet.ALTURA = Decimal.Parse(dr["ALTURA"].ToString());
                                oCamposDet.PRODUCCION_LATAS = Decimal.Parse(dr["PRODUCCION_LATAS"].ToString());
                                oCamposDet.ZONA = dr["ZONA"].ToString();
                                oCamposDet.COORDENADA_ESTE = Int32.Parse(dr["COORDENADA_ESTE"].ToString());
                                oCamposDet.COORDENADA_NORTE = Int32.Parse(dr["COORDENADA_NORTE"].ToString());
                                oCamposDet.ESTADO_MUESTRA = dr["ESTADO_MUESTRA"].ToString();
                                oCamposDet.OBSERVACION = dr["OBSERVACION"].ToString();
                                oCamposDet.CONDICION = dr["CONDICION"].ToString();
                                oCamposDet.COD_ESPECIES_ARESOLUCION = dr["COD_ESPECIES_ARESOLUCION"].ToString();
                                oCamposDet.ESPECIES_ARESOLUCION = dr["ESPECIES_ARESOLUCION"].ToString();
                                oCamposDet.RegEstado = 0;
                                oCampos.ListNoMadeCENSO.Add(oCamposDet);
                            }
                        }
                        //POA_DET_VERTICE
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.VERTICE = dr["VERTICE"].ToString();
                                oCamposDet.ZONA = dr["ZONA"].ToString();
                                oCamposDet.COORDENADA_ESTE = Int32.Parse(dr["COORDENADA_ESTE"].ToString());
                                oCamposDet.COORDENADA_NORTE = Int32.Parse(dr["COORDENADA_NORTE"].ToString());
                                oCamposDet.OBSERVACION = dr["OBSERVACION"].ToString();
                                oCamposDet.COD_SECUENCIAL = Int32.Parse(dr["COD_SECUENCIAL"].ToString());
                                oCamposDet.RegEstado = 0;
                                oCamposDet.PCA = dr["PCA"].ToString();
                                oCampos.ListVERTICE.Add(oCamposDet);
                            }
                        }

                        // POA_DET_AIOCULAR
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("COD_PERSONA");
                            int pt2 = dr.GetOrdinal("PERSONA");
                            int pt3 = dr.GetOrdinal("N_DOCUMENTO");
                            //int pt4 = dr.GetOrdinal("CARGO");
                            int pt4 = dr.GetOrdinal("COD_PTIPO");
                            int pt5 = dr.GetOrdinal("TIPO_CARGO");
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.COD_PERSONA = dr.GetString(pt1);
                                oCamposDet.PERSONA = dr.GetString(pt2);
                                oCamposDet.N_DOCUMENTO = dr.GetString(pt3);
                                oCamposDet.COD_PTIPO = dr.GetString(pt4);
                                oCamposDet.TIPO_CARGO = dr.GetString(pt5);
                                oCamposDet.RegEstado = 0;
                                oCampos.ListAOCULAR.Add(oCamposDet);
                            }
                        }
                        //09/05/2023
                        //POA_DET_REGENTE
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("COD_PERSONA");
                            int pt2 = dr.GetOrdinal("PERSONA");
                            int pt3 = dr.GetOrdinal("N_DOCUMENTO");
                            int pt4 = dr.GetOrdinal("COD_PTIPO");
                            int pt5 = dr.GetOrdinal("TIPO_CARGO");
                            int pt6 = dr.GetOrdinal("ANIO");
                            int pt7 = dr.GetOrdinal("CIP");
                            int pt8 = dr.GetOrdinal("CATEGORIA");
                            int pt9 = dr.GetOrdinal("ESTADO_REGENTE");
                            int pt10 = dr.GetOrdinal("NROLICENCIA");
                            int pt11 = dr.GetOrdinal("OTORGAMIENTO");
                            int pt12 = dr.GetOrdinal("RESAPROBACION");
                            int pt13 = dr.GetOrdinal("COD_SECUENCIAL");
                            int pt14 = dr.GetOrdinal("NOMBRE_ARCH");
                            int pt15 = dr.GetOrdinal("FECHA_INI");
                            int pt16 = dr.GetOrdinal("FECHA_FIN");
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.COD_PERSONA = dr.GetString(pt1);
                                oCamposDet.PERSONA = dr.GetString(pt2);
                                oCamposDet.N_DOCUMENTO = dr.GetString(pt3);
                                oCamposDet.COD_PTIPO = dr.GetString(pt4);
                                oCamposDet.TIPO_CARGO = dr.GetString(pt5);
                                oCamposDet.ANIO = dr.GetString(pt6);
                                oCamposDet.CIP = dr.GetString(pt7);
                                oCamposDet.CATEGORIA = dr.GetString(pt8);
                                oCamposDet.ESTADO_REGENTE = dr.GetString(pt9);
                                oCamposDet.NROLICENCIA = dr.GetString(pt10);
                                oCamposDet.OTORGAMIENTO = dr.GetString(pt11);
                                oCamposDet.RESAPROBACION = dr.GetString(pt12);
                                oCamposDet.COD_SECUENCIAL = dr.GetInt32(pt13);
                                oCamposDet.NOMBRE_ARCH = dr.GetString(pt14);
                                oCamposDet.FECHA = dr.GetString(pt15);
                                oCamposDet.FECHA1 = dr.GetString(pt16);
                                oCamposDet.RegEstado = 0;
                                oCampos.ListDETREGENTE.Add(oCamposDet);
                            }
                        }

                        //POA_DET_KARDEX
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("COD_ESPECIES");
                            int pt2 = dr.GetOrdinal("ESPECIES");
                            int pt3 = dr.GetOrdinal("FECHA_EMISIONKARDEX");
                            int pt4 = dr.GetOrdinal("GUIA_TRANSPORTE");
                            int pt5 = dr.GetOrdinal("COD_KARDEX_PRODUCTO");
                            int pt6 = dr.GetOrdinal("PRODUCTO");
                            int pt7 = dr.GetOrdinal("COD_KARDEX_DESCRIPCION");
                            int pt8 = dr.GetOrdinal("DESCRIPCION_KARDEX");
                            int pt9 = dr.GetOrdinal("CANTIDAD");
                            int pt10 = dr.GetOrdinal("KILOGRAMOS_KARDEX");
                            int pt11 = dr.GetOrdinal("M3");
                            int pt12 = dr.GetOrdinal("ACUMULADO");
                            int pt13 = dr.GetOrdinal("SALDO_KARDEX");
                            int pt14 = dr.GetOrdinal("OBSERVACION_KARDEX");
                            int pt15 = dr.GetOrdinal("COD_SECUENCIAL");
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.COD_ESPECIES = dr.GetString(pt1);
                                oCamposDet.ESPECIES = dr.GetString(pt2);
                                oCamposDet.FECHA_EMISIONKARDEX = dr.GetString(pt3).Trim();
                                oCamposDet.GUIA_TRANSPORTE = dr.GetString(pt4);
                                oCamposDet.COD_KARDEX_PRODUCTO = dr.GetString(pt5);
                                oCamposDet.PRODUCTO = dr.GetString(pt6);
                                oCamposDet.COD_KARDEX_DESCRIPCION = dr.GetString(pt7);
                                oCamposDet.DESCRIPCION_KARDEX = dr.GetString(pt8);
                                oCamposDet.CANTIDAD = dr.GetInt32(pt9);
                                oCamposDet.KILOGRAMOS_KARDEX = dr.GetDecimal(pt10);
                                oCamposDet.M3 = dr.GetDecimal(pt11);
                                oCamposDet.ACUMULADO = dr.GetDecimal(pt12);
                                oCamposDet.SALDO_KARDEX = dr.GetDecimal(pt13);
                                oCamposDet.OBSERVACION_KARDEX = dr.GetString(pt14);
                                oCamposDet.COD_SECUENCIAL = dr.GetInt32(pt15);
                                oCamposDet.RegEstado = 0;
                                oCampos.ListKARDEX.Add(oCamposDet);
                            }
                        }
                        //POA_INSITU_DET_RREAAPROVECHAR
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("COD_ESPECIES");
                            int pt2 = dr.GetOrdinal("COD_SECUENCIAL");
                            int pt3 = dr.GetOrdinal("ESPECIES");
                            int pt4 = dr.GetOrdinal("PERIODO");
                            int pt5 = dr.GetOrdinal("CUOTA_SACA");
                            int pt6 = dr.GetOrdinal("METODO_CAZA");
                            int pt7 = dr.GetOrdinal("SISTEMA_MARCAJE");
                            int pt8 = dr.GetOrdinal("DENSIDAD");
                            int pt9 = dr.GetOrdinal("OBSERVACION");
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.COD_ESPECIES = dr.GetString(pt1);
                                oCamposDet.COD_SECUENCIAL = dr.GetInt32(pt2);
                                oCamposDet.ESPECIES = dr.GetString(pt3);
                                oCamposDet.PERIODO = dr.GetString(pt4);
                                oCamposDet.CUOTA_SACA = dr.GetInt32(pt5);
                                oCamposDet.METODO_CAZA = dr.GetString(pt6);
                                oCamposDet.SISTEMA_MARCAJE = dr.GetString(pt7);
                                oCamposDet.DENSIDAD = dr.GetInt32(pt8);
                                oCamposDet.OBSERVACION = dr.GetString(pt9);
                                oCamposDet.RegEstado = 0;
                                oCampos.ListRReformulaISitu.Add(oCamposDet);
                            }
                        }
                        //POA_DET_RDREFORMULA
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.COD_SECUENCIAL = dr.GetInt32(dr.GetOrdinal("COD_SECUENCIAL"));
                                oCamposDet.ITECNICO_REFORMULA_POA_NUM = dr.GetString(dr.GetOrdinal("ITECNICO_REFORMULA_POA_NUM"));
                                oCamposDet.ITECNICO_REFORMULA_POA_FECHA = dr.GetString(dr.GetOrdinal("ITECNICO_REFORMULA_POA_FECHA"));
                                oCamposDet.RegEstado = 0;
                                oCamposDet.ListREFORMULAPOA = new List<CEntidad>();
                                oCamposDet.ListRReformula = new List<CEntidad>();
                                oCampos.ListRDReformulaPOA.Add(oCamposDet);
                            }
                        }
                        //POA_DET_REFORMULA
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.COD_PERSONA = dr.GetString(dr.GetOrdinal("COD_PERSONA"));
                                oCamposDet.PERSONA = dr.GetString(dr.GetOrdinal("PERSONA"));
                                oCamposDet.N_DOCUMENTO = dr.GetString(dr.GetOrdinal("N_DOCUMENTO"));
                                oCamposDet.CARGO = dr.GetString(dr.GetOrdinal("CARGO"));
                                oCamposDet.COD_SECUENCIAL = dr.GetInt32(dr.GetOrdinal("COD_SECUENCIAL"));
                                oCamposDet.RegEstado = 0;

                                for (int i = 0; i < oCampos.ListRDReformulaPOA.Count; i++)
                                {
                                    if (oCampos.ListRDReformulaPOA[i].COD_SECUENCIAL == oCamposDet.COD_SECUENCIAL)
                                    {
                                        oCampos.ListRDReformulaPOA[i].ListREFORMULAPOA.Add(oCamposDet);
                                    }
                                }
                            }
                        }
                        //POA_DET_MADE_NOMADE_RREAAPROVECHAR
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.COD_ESPECIES = dr.GetString(dr.GetOrdinal("COD_ESPECIES"));
                                oCamposDet.COD_SECUENCIAL = dr.GetInt32(dr.GetOrdinal("COD_SECUENCIAL"));
                                oCamposDet.COD_SECUENCIAL_RDREF = dr.GetInt32(dr.GetOrdinal("COD_SECUENCIAL_RDREF"));
                                oCamposDet.ESPECIES = dr.GetString(dr.GetOrdinal("ESPECIES"));
                                oCamposDet.NUM_ARBOLES = dr.GetInt32(dr.GetOrdinal("NUM_ARBOLES"));
                                oCamposDet.TIPOMADERABLE = dr.GetString(dr.GetOrdinal("TIPOMADERABLE"));
                                oCamposDet.VOLUMEN_KILOGRAMOS = dr.GetDecimal(dr.GetOrdinal("VOLUMEN_KILOGRAMOS"));
                                oCamposDet.OBSERVACION = dr.GetString(dr.GetOrdinal("OBSERVACION"));
                                oCamposDet.CANTIDAD = dr.GetInt32(dr.GetOrdinal("CANTIDAD"));
                                oCamposDet.SuperficieHa = dr.GetDecimal(dr.GetOrdinal("SUPERFICIE_HA"));
                                oCamposDet.ABUNDANCIA = dr.GetDecimal(dr.GetOrdinal("ABUNDANCIA"));
                                oCamposDet.NUMINDIVIDUOS = dr.GetDecimal(dr.GetOrdinal("NUM_INDIVIDUOS"));
                                oCamposDet.PESO = dr.GetDecimal(dr.GetOrdinal("PESO"));
                                oCamposDet.RENDIMIENTO = dr.GetDecimal(dr.GetOrdinal("RENDIMIENTO"));
                                oCamposDet.UNIDAD_MEDIDA = dr.GetString(dr.GetOrdinal("UNIDAD_MEDIDA"));
                                oCamposDet.COD_ESPECIES_SERFOR = dr.GetString(dr.GetOrdinal("COD_ESPECIES_SERFOR"));
                                oCamposDet.ESPECIES_SERFOR = dr.GetString(dr.GetOrdinal("ESPECIES_SERFOR"));
                                oCamposDet.RegEstado = 0;

                                for (int i = 0; i < oCampos.ListRDReformulaPOA.Count; i++)
                                {
                                    if (oCampos.ListRDReformulaPOA[i].COD_SECUENCIAL == oCamposDet.COD_SECUENCIAL_RDREF)
                                    {
                                        oCampos.ListRDReformulaPOA[i].ListRReformula.Add(oCamposDet);
                                    }
                                }
                            }
                        }
                        //POA_DET_BEXTRACCION
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.COD_SECUENCIAL = dr.GetInt32(dr.GetOrdinal("COD_SECUENCIAL"));
                                oCamposDet.BEXTRACCION_FEMISION = dr.GetString(dr.GetOrdinal("BEXTRACCION_FEMISION"));
                                oCamposDet.RegEstado = 0;
                                oCamposDet.ListMadeBEXTRACCION = new List<CEntidad>();
                                oCamposDet.ListNoMadeBEXTRACCION = new List<CEntidad>();
                                oCamposDet.ListISituBEXTRACCION = new List<CEntidad>();
                                oCampos.ListBExtPOA.Add(oCamposDet);
                            }
                        }
                        //POA_DET_MADERABLE_BEXTRACCION
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.COD_ESPECIES = dr.GetString(dr.GetOrdinal("COD_ESPECIES"));
                                oCamposDet.COD_SECUENCIAL = dr.GetInt32(dr.GetOrdinal("COD_SECUENCIAL"));
                                oCamposDet.COD_SECUENCIAL_BEXT = dr.GetInt32(dr.GetOrdinal("COD_SECUENCIAL_BEXT"));
                                oCamposDet.ESPECIES = dr.GetString(dr.GetOrdinal("ESPECIES"));
                                oCamposDet.DMC = dr.GetInt32(dr.GetOrdinal("DMC"));
                                oCamposDet.TOTAL_ARBOLES = dr.GetInt32(dr.GetOrdinal("TOTAL_ARBOLES"));
                                oCamposDet.VOLUMEN_AUTORIZADO = dr.GetDecimal(dr.GetOrdinal("VOLUMEN_AUTORIZADO"));
                                //Decimal.Parse(dr.GetString(dr.GetOrdinal("VOLUMEN_MOVILIZADO")));
                                oCamposDet.VOLUMEN_MOVILIZADO = dr.GetDecimal(dr.GetOrdinal("VOLUMEN_MOVILIZADO"));
                                oCamposDet.SALDO = dr.GetDecimal(dr.GetOrdinal("SALDO"));
                                oCamposDet.FECHA1 = dr.GetString(dr.GetOrdinal("FECHA1")).Trim();//De No Maderable
                                oCamposDet.FECHA2 = dr.GetString(dr.GetOrdinal("FECHA2")).Trim();//De No Maderable
                                oCamposDet.GUIA_TRANSPORTE = dr.GetString(dr.GetOrdinal("GUIA_TRANSPORTE"));//De No Maderable
                                oCamposDet.CANTIDAD = dr.GetInt32(dr.GetOrdinal("CANTIDAD"));//De No Maderable
                                oCamposDet.RECIBO = dr.GetString(dr.GetOrdinal("RECIBO"));//De No Maderable
                                oCamposDet.UNIDAD_MEDIDA = dr.GetString(dr.GetOrdinal("UNIDAD_MEDIDA"));
                                oCamposDet.AUTORIZADO = dr.GetDecimal(dr.GetOrdinal("AUTORIZADO"));//De No Maderable
                                oCamposDet.EXTRAIDO = dr.GetDecimal(dr.GetOrdinal("EXTRAIDO"));//De No Maderable
                                oCamposDet.OBSERVACION = dr.GetString(dr.GetOrdinal("OBSERVACION"));
                                oCamposDet.TIPOMADERABLE = dr.GetString(dr.GetOrdinal("TIPOMADERABLE"));
                                oCamposDet.COD_ESPECIES_SERFOR = dr.GetString(dr.GetOrdinal("COD_ESPECIES_SERFOR"));
                                oCamposDet.ESPECIES_SERFOR = dr.GetString(dr.GetOrdinal("ESPECIES_SERFOR"));
                                oCamposDet.PCA = dr.GetString(dr.GetOrdinal("PCA"));

                                oCamposDet.RegEstado = 0;

                                if (oCamposDet.UNIDAD_MEDIDA.Trim().Equals("") || oCamposDet.UNIDAD_MEDIDA.Equals("-"))
                                {
                                    if (oCamposDet.TIPOMADERABLE.Equals("MADERABLES")) oCamposDet.UNIDAD_MEDIDA = "M3";
                                    else if (oCamposDet.TIPOMADERABLE.Equals("CARBON")) oCamposDet.UNIDAD_MEDIDA = "KG";
                                    else if (oCamposDet.TIPOMADERABLE.Equals("NO MADERABLES"))
                                    {
                                        if (!oCampos.COD_MTIPO.Equals("0000020")) oCamposDet.UNIDAD_MEDIDA = "KG";
                                    }
                                }

                                for (int i = 0; i < oCampos.ListBExtPOA.Count; i++)
                                {
                                    if (oCampos.ListBExtPOA[i].COD_SECUENCIAL == oCamposDet.COD_SECUENCIAL_BEXT)
                                    {
                                        oCampos.ListBExtPOA[i].ListMadeBEXTRACCION.Add(oCamposDet);
                                    }
                                }
                            }
                        }
                        //POA_DET_NOMADERABLE_BEXTRACCION, carrizo, plantas medicinales
                        /*dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.COD_ESPECIES = dr.GetString(dr.GetOrdinal("COD_ESPECIES"));
                                oCamposDet.COD_SECUENCIAL = dr.GetInt32(dr.GetOrdinal("COD_SECUENCIAL"));
                                oCamposDet.COD_SECUENCIAL_BEXT = dr.GetInt32(dr.GetOrdinal("COD_SECUENCIAL_BEXT"));
                                oCamposDet.ESPECIES = dr.GetString(dr.GetOrdinal("ESPECIES"));
                                oCamposDet.KILOGRAMO_AUTORIZADO = dr.GetDecimal(dr.GetOrdinal("KILOGRAMO_AUTORIZADO"));
                                oCamposDet.KILOGRAMO_MOVILIZADO = dr.GetDecimal(dr.GetOrdinal("KILOGRAMO_MOVILIZADO"));
                                oCamposDet.SALDO = dr.GetDecimal(dr.GetOrdinal("SALDO"));
                                oCamposDet.OBSERVACION = dr.GetString(dr.GetOrdinal("OBSERVACION"));

                                oCamposDet.FECHA1 = dr.GetString(dr.GetOrdinal("FECHA1")).Trim();
                                oCamposDet.FECHA2 = dr.GetString(dr.GetOrdinal("FECHA2")).Trim();
                                oCamposDet.GUIA_TRANSPORTE = dr.GetString(dr.GetOrdinal("GUIA_TRANSPORTE"));
                                oCamposDet.CANTIDAD = dr.GetInt32(dr.GetOrdinal("CANTIDAD"));
                                oCamposDet.RECIBO = dr.GetString(dr.GetOrdinal("RECIBO"));

                                oCamposDet.UNIDAD_MEDIDA = dr.GetString(dr.GetOrdinal("UNIDAD_MEDIDA"));
                                oCamposDet.AUTORIZADO = dr.GetDecimal(dr.GetOrdinal("AUTORIZADO"));
                                oCamposDet.EXTRAIDO = dr.GetDecimal(dr.GetOrdinal("EXTRAIDO"));
                                oCamposDet.COD_ESPECIES_SERFOR = dr.GetString(dr.GetOrdinal("COD_ESPECIES_SERFOR"));
                                oCamposDet.ESPECIES_SERFOR = dr.GetString(dr.GetOrdinal("ESPECIES_SERFOR"));
                                oCamposDet.RegEstado = 0;

                                for (int i = 0; i < oCampos.ListBExtPOA.Count; i++)
                                {
                                    if (oCampos.ListBExtPOA[i].COD_SECUENCIAL == oCamposDet.COD_SECUENCIAL_BEXT)
                                    {
                                        oCampos.ListBExtPOA[i].ListNoMadeBEXTRACCION.Add(oCamposDet);
                                    }
                                }
                            }
                        }*/
                        //POA_INSITU_DET_BEXTRACCION
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                /*Revisar Jose
                                oCamposDet = new CEntidad();
                                oCamposDet.COD_ESPECIES = dr.GetString(dr.GetOrdinal("COD_ESPECIES"));
                                oCamposDet.COD_SECUENCIAL = dr.GetInt32(dr.GetOrdinal("COD_SECUENCIAL"));
                                oCamposDet.COD_SECUENCIAL_BEXT = dr.GetInt32(dr.GetOrdinal("COD_SECUENCIAL_BEXT"));
                                oCamposDet.ESPECIES = dr.GetString(dr.GetOrdinal("ESPECIES"));
                                oCamposDet.CANTIDAD_AUTORIZADO = dr.GetDecimal(dr.GetOrdinal("CANTIDAD_AUTORIZADO"));
                                oCamposDet.CANTIDAD_MOVILIZADO = dr.GetDecimal(dr.GetOrdinal("CANTIDAD_MOVILIZADO"));
                                oCamposDet.SALDO = dr.GetDecimal(dr.GetOrdinal("SALDO"));
                                oCamposDet.OBSERVACION = dr.GetString(dr.GetOrdinal("OBSERVACION"));
                                oCamposDet.COD_ESPECIES_SERFOR = dr.GetString(dr.GetOrdinal("COD_ESPECIES_SERFOR"));
                                oCamposDet.ESPECIES_SERFOR = dr.GetString(dr.GetOrdinal("ESPECIES_SERFOR"));
                                oCamposDet.RegEstado = 0;
                                for (int i = 0; i < oCampos.ListBExtPOA.Count; i++)
                                {
                                    if (oCampos.ListBExtPOA[i].COD_SECUENCIAL == oCamposDet.COD_SECUENCIAL_BEXT)
                                    {
                                        oCampos.ListBExtPOA[i].ListISituBEXTRACCION.Add(oCamposDet);
                                    }
                                }*/
                            }
                        }
                        //Dependencias Ubigeo
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("CODIGO");
                            int pt2 = dr.GetOrdinal("DESCRIPCION");
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.CODIGO = dr.GetInt32(pt1).ToString();
                                oCamposDet.DESCRIPCION = dr.GetString(pt2);

                                oCampos.ListDependencia.Add(oCamposDet);
                            }
                        }

                        // lista de parcelas
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.COD_PARCELA = dr["COD_PARCELA"].ToString();
                                oCamposDet.COD_THABILITANTE = dr["COD_THABILITANTE"].ToString();
                                oCamposDet.NUM_POA = Int32.Parse(dr["NUM_POA"].ToString());
                                oCamposDet.COD_SECUENCIAL = Int32.Parse(dr["COD_SECUENCIAL"].ToString());
                                oCamposDet.PCA = dr["PARCELA"].ToString();
                                oCamposDet.AREA = decimal.Parse(dr["AREA"].ToString());
                                oCamposDet.RegEstado = 0;
                                oCampos.ListParcela.Add(oCamposDet);

                            }
                        }

                        //Error Material
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            CEntidadEM oCamposEM;

                            while (dr.Read())
                            {
                                oCamposEM = new CEntidadEM();
                                oCamposEM.COD_SECUENCIAL = dr.GetInt32(dr.GetOrdinal("COD_SECUENCIAL"));
                                oCamposEM.DA_FECRESOLUCION = dr.GetString(dr.GetOrdinal("DA_FECRESOLUCION"));
                                oCamposEM.NV_RESOLUCION = dr.GetString(dr.GetOrdinal("NV_RESOLUCION"));
                                oCamposEM.NV_NOMCAMPO = dr.GetString(dr.GetOrdinal("NV_NOMCAMPO"));
                                oCamposEM.NV_VALANTERIOR = dr.GetString(dr.GetOrdinal("NV_VALANTERIOR"));
                                oCamposEM.NV_VALACTUAL = dr.GetString(dr.GetOrdinal("NV_VALACTUAL"));
                                oCamposEM.NV_OBSERVACION = dr.GetString(dr.GetOrdinal("NV_OBSERVACION")).Replace("\n", "<br/>");

                                oCampos.ListPOAErrorMaterialG.Add(oCamposEM);
                            }
                        }
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            CEntidadEM oCamposEM;

                            while (dr.Read())
                            {
                                oCamposEM = new CEntidadEM();
                                oCamposEM.COD_SECUENCIAL = dr.GetInt32(dr.GetOrdinal("COD_SECUENCIAL"));
                                oCamposEM.DA_FECRESOLUCION = dr.GetString(dr.GetOrdinal("DA_FECRESOLUCION"));
                                oCamposEM.NV_RESOLUCION = dr.GetString(dr.GetOrdinal("NV_RESOLUCION"));
                                oCamposEM.NV_NOMCAMPO = dr.GetString(dr.GetOrdinal("NV_NOMCAMPO"));
                                oCamposEM.NV_VALANTERIOR = dr.GetString(dr.GetOrdinal("NV_VALANTERIOR"));
                                oCamposEM.NV_VALACTUAL = dr.GetString(dr.GetOrdinal("NV_VALACTUAL"));
                                oCamposEM.NV_OBSERVACION = dr.GetString(dr.GetOrdinal("NV_OBSERVACION")).Replace("\n", "<br/>");

                                oCampos.ListPOAErrorMaterialA.Add(oCamposEM);
                            }
                        }
                        // lista de parcelas
                        //dr.NextResult();
                        //if (dr.HasRows)
                        //{
                        //    while (dr.Read())
                        //    {
                        //        oCamposDet = new CEntidad();
                        //        oCamposDet.COD_PARCELA = dr["COD_PARCELA"].ToString();
                        //        oCamposDet.COD_THABILITANTE = dr["COD_THABILITANTE"].ToString();
                        //        oCamposDet.NUM_POA = Int32.Parse(dr["NUM_POA"].ToString());
                        //        oCamposDet.COD_SECUENCIAL = Int32.Parse(dr["COD_SECUENCIAL"].ToString());
                        //        oCamposDet.PCA = dr["PARCELA"].ToString();
                        //        oCamposDet.AREA = decimal.Parse(dr["AREA"].ToString());
                        //        oCamposDet.RegEstado = 0;
                        //        oCampos.ListParcela.Add(oCamposDet);
                        //    }
                        //}
                        //POA_DET_SAPROBACION
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.COD_PERSONA = dr["COD_PERSONA"].ToString();
                                oCamposDet.PERSONA = dr["PERSONA"].ToString();
                                oCamposDet.N_DOCUMENTO = dr["N_DOCUMENTO"].ToString();
                                //oCamposDet.CARGO = dr["CARGO"].ToString();
                                oCamposDet.COD_PTIPO = dr["COD_PTIPO"].ToString();
                                oCamposDet.TIPO_CARGO = dr["TIPO_CARGO"].ToString();
                                oCamposDet.RegEstado = 0;
                                oCampos.ListSAPROBACION.Add(oCamposDet);
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public String RegGrabar(OracleConnection cn, CEntidad oCEntidad)
        {
            OracleTransaction tr = null;
            String OUTPUTPARAM01 = "";
            String OUTPUTPARAM02 = "";
            CEntidad oCamposDet;
            try
            {
                tr = cn.BeginTransaction();
                //Grabando Cabecera
                using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spPOAGrabar", oCEntidad))
                {
                    cmd.ExecuteNonQuery();
                    OUTPUTPARAM01 = (String)cmd.Parameters["OUTPUTPARAM01"].Value;
                    OUTPUTPARAM02 = (String)cmd.Parameters["OUTPUTPARAM02"].Value;
                    if (OUTPUTPARAM01 == "100")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("El registro se encuentra con Control de Calidad Conforme, No se puede modificar el registro");
                    }
                    else if (OUTPUTPARAM01 == "99")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("Ud. no tiene permiso para realizar esta acción");
                    }
                    if (OUTPUTPARAM01 == "0")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("El Número de POA para este Titulo Habilitante ya Existe");
                    }
                    else if (OUTPUTPARAM01 == "1")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("El Número de Resolución ya Existe en Otra POA");
                    }
                    else if (OUTPUTPARAM01 == "2")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("No Tiene Permisos para Modificar este POA");
                    }
                    else if (OUTPUTPARAM01 == "3")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("Está con Control de Calidad, no puede modificar");
                    }
                    else if (OUTPUTPARAM01 == "4")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("No puede eliminar el Censo, ya existe muestra seleccionada sobre este Plan");
                    }

                    if (OUTPUTPARAM02 != "")
                    {
                        oCEntidad.COD_THABILITANTE = OUTPUTPARAM01;
                        oCEntidad.NUM_POA = Int32.Parse(OUTPUTPARAM02);
                    }
                }
                //
                //Eliminando Detalle
                if (oCEntidad.ListEliTABLA != null)
                {
                    foreach (var loDatos in oCEntidad.ListEliTABLA)
                    {
                        oCamposDet = new CEntidad();
                        oCamposDet.COD_THABILITANTE = oCEntidad.COD_THABILITANTE;
                        oCamposDet.NUM_POA = oCEntidad.NUM_POA;
                        oCamposDet.EliTABLA = loDatos.EliTABLA;
                        oCamposDet.EliVALOR01 = loDatos.EliVALOR01;
                        oCamposDet.EliVALOR02 = loDatos.EliVALOR02;
                        dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spPOAEliminarDetalle", oCamposDet);
                    }
                }
                // Grabando POA_DET_AIOCULAR
                if (oCEntidad.ListAOCULAR != null)
                {
                    foreach (var loDatos in oCEntidad.ListAOCULAR)
                    {
                        if (loDatos.RegEstado == 1) //Nuevo o Modificado
                        {
                            oCamposDet = new CEntidad();
                            oCamposDet.COD_THABILITANTE = oCEntidad.COD_THABILITANTE;
                            oCamposDet.NUM_POA = oCEntidad.NUM_POA;
                            oCamposDet.COD_POCULAR = loDatos.COD_PERSONA;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spPOA_DET_AIOCULARGrabar", oCamposDet);
                        }
                    }
                }
                //Grabando Detalle POA_DET_TIOCULAR
                if (oCEntidad.ListTIOCULAR != null)
                {
                    foreach (var loDatos in oCEntidad.ListTIOCULAR)
                    {
                        if (loDatos.RegEstado == 1) //Nuevo o Modificado
                        {
                            oCamposDet = new CEntidad();
                            oCamposDet.COD_THABILITANTE = oCEntidad.COD_THABILITANTE;
                            oCamposDet.NUM_POA = oCEntidad.NUM_POA;
                            oCamposDet.COD_TIOCULAR = loDatos.COD_PERSONA;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spPOA_DET_TIOCULARGrabar", oCamposDet);
                        }
                    }
                }
                //Grabando Detalle POA_DET_TRAPROBACION
                if (oCEntidad.ListTRAPROBACION != null)
                {
                    foreach (var loDatos in oCEntidad.ListTRAPROBACION)
                    {
                        if (loDatos.RegEstado == 1) //Nuevo o Modificado
                        {
                            oCamposDet = new CEntidad();
                            oCamposDet.COD_THABILITANTE = oCEntidad.COD_THABILITANTE;
                            oCamposDet.NUM_POA = oCEntidad.NUM_POA;
                            oCamposDet.COD_TRAPROBACION = loDatos.COD_PERSONA;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spPOA_DET_TRAPROBACIONGrabar", oCamposDet);
                        }
                    }
                }
                //// Grabando Detalle POA_DET_REFORMULA
                //if (oCEntidad.ListREFORMULAPOA != null)
                //{
                //    foreach (var loDatos in oCEntidad.ListREFORMULAPOA)
                //    {
                //        if (loDatos.RegEstado == 1) //Nuevo o Modificado
                //        {
                //            oCamposDet = new CEntidad();
                //            oCamposDet.COD_THABILITANTE = oCEntidad.COD_THABILITANTE;
                //            oCamposDet.NUM_POA = oCEntidad.NUM_POA;
                //            oCamposDet.COD_PREFORMULA = loDatos.COD_PERSONA;
                //            oGDataSQL.ManExecute(cn, tr, "DOC.spPOA_DET_REFORMULAGrabar", oCamposDet);
                //        }
                //    }
                //}
                //Grabando Detalle POA_DET_MADE_NOMADE_EAAPROVECHAR
                if (oCEntidad.ListRAprueba != null)
                {
                    foreach (var loDatos in oCEntidad.ListRAprueba)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            oCamposDet = new CEntidad();
                            oCamposDet.COD_THABILITANTE = oCEntidad.COD_THABILITANTE;
                            oCamposDet.NUM_POA = oCEntidad.NUM_POA;
                            oCamposDet.COD_ESPECIES = loDatos.COD_ESPECIES;
                            oCamposDet.ESPECIES = loDatos.ESPECIES;
                            oCamposDet.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;

                            if (oCEntidad.COD_MTIPO == "0000020")
                            {
                                oCamposDet.SuperficieHa = loDatos.SuperficieHa;
                                oCamposDet.CANTIDAD = loDatos.CANTIDAD;
                            }
                            else if (oCEntidad.COD_MTIPO == "0000021")
                            {
                                oCamposDet.ABUNDANCIA = loDatos.ABUNDANCIA;
                                oCamposDet.NUMINDIVIDUOS = loDatos.NUMINDIVIDUOS;
                                oCamposDet.PESO = loDatos.PESO;
                                oCamposDet.RENDIMIENTO = loDatos.RENDIMIENTO;
                                oCamposDet.UNIDAD_MEDIDA = loDatos.UNIDAD_MEDIDA;
                            }
                            else
                            {
                                oCamposDet.NUM_ARBOLES = loDatos.NUM_ARBOLES;
                                oCamposDet.VOLUMEN_KILOGRAMOS = loDatos.VOLUMEN_KILOGRAMOS;
                            }
                            if (loDatos.COD_ESPECIES_SERFOR != "-")
                            {
                                oCamposDet.COD_ESPECIES_SERFOR = loDatos.COD_ESPECIES_SERFOR;
                                oCamposDet.ESPECIES_SERFOR = loDatos.ESPECIES_SERFOR;
                            }
                            oCamposDet.TIPOMADERABLE = loDatos.TIPOMADERABLE;
                            oCamposDet.OBSERVACION = loDatos.OBSERVACION;
                            oCamposDet.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spPOA_DET_MADE_NOMADE_EAAPROVECHARGrabar", oCamposDet);
                        }
                    }
                }
                //Grabando Detalle POA_INSITU_DET_EAAPROVECHAR
                if (oCEntidad.ListRApruebaISitu != null)
                {
                    foreach (var loDatos in oCEntidad.ListRApruebaISitu)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            oCamposDet = new CEntidad();
                            oCamposDet.COD_THABILITANTE = oCEntidad.COD_THABILITANTE;
                            oCamposDet.NUM_POA = oCEntidad.NUM_POA;
                            oCamposDet.COD_ESPECIES = loDatos.COD_ESPECIES;
                            oCamposDet.ESPECIES = loDatos.ESPECIES;
                            oCamposDet.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            oCamposDet.PERIODO = loDatos.PERIODO;
                            oCamposDet.CUOTA_SACA = loDatos.CUOTA_SACA;
                            oCamposDet.METODO_CAZA = loDatos.METODO_CAZA;
                            oCamposDet.SISTEMA_MARCAJE = loDatos.SISTEMA_MARCAJE;
                            oCamposDet.DENSIDAD = loDatos.DENSIDAD;
                            if (loDatos.COD_ESPECIES_SERFOR != "-")
                            {
                                oCamposDet.COD_ESPECIES_SERFOR = loDatos.COD_ESPECIES_SERFOR;
                                oCamposDet.ESPECIES_SERFOR = loDatos.ESPECIES_SERFOR;
                            }
                            oCamposDet.OBSERVACION = loDatos.OBSERVACION;
                            oCamposDet.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spPOA_INSITU_DET_EAAPROVECHARGrabar", oCamposDet);
                        }
                    }
                }
                ////Grabando Detalle POA_DET_MADE_NOMADE_RREAAPROVECHAR
                //if (oCEntidad.ListRReformula != null)
                //{
                //    foreach (var loDatos in oCEntidad.ListRReformula)
                //    {
                //        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                //        {
                //            oCamposDet = new CEntidad();
                //            oCamposDet.COD_THABILITANTE = oCEntidad.COD_THABILITANTE;
                //            oCamposDet.NUM_POA = oCEntidad.NUM_POA;
                //            oCamposDet.COD_ESPECIES = loDatos.COD_ESPECIES;
                //            oCamposDet.ESPECIES = loDatos.ESPECIES;
                //            oCamposDet.COD_SECUENCIAL = loDatos.COD_SECUENCIAL; 
                //            if (oCEntidad.COD_MTIPO == "0000020")
                //            {
                //                oCamposDet.SuperficieHa = loDatos.SuperficieHa;
                //                oCamposDet.CANTIDAD = loDatos.CANTIDAD;
                //            }
                //            else if (oCEntidad.COD_MTIPO == "0000021")
                //            {
                //                oCamposDet.ABUNDANCIA = loDatos.ABUNDANCIA;
                //                oCamposDet.NUMINDIVIDUOS = loDatos.NUMINDIVIDUOS;
                //                oCamposDet.PESO = loDatos.PESO;
                //                oCamposDet.RENDIMIENTO = loDatos.RENDIMIENTO;
                //                oCamposDet.UNIDAD_MEDIDA = loDatos.UNIDAD_MEDIDA;
                //            }
                //            else
                //            {
                //                oCamposDet.NUM_ARBOLES = loDatos.NUM_ARBOLES;
                //                oCamposDet.VOLUMEN_KILOGRAMOS = loDatos.VOLUMEN_KILOGRAMOS;
                //                oCamposDet.TIPOMADERABLE = loDatos.TIPOMADERABLE;
                //            }
                //            oCamposDet.OBSERVACION = loDatos.OBSERVACION;
                //            oCamposDet.RegEstado = loDatos.RegEstado;
                //            oGDataSQL.ManExecute(cn, tr, "DOC.spPOA_DET_MADE_NOMADE_RREAAPROVECHARGrabar", oCamposDet);
                //        }
                //    }
                //}
                //Grabando Detalle POA_INSITU_DET_RREAAPROVECHAR
                if (oCEntidad.ListRReformulaISitu != null)
                {
                    foreach (var loDatos in oCEntidad.ListRReformulaISitu)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            oCamposDet = new CEntidad();
                            oCamposDet.COD_THABILITANTE = oCEntidad.COD_THABILITANTE;
                            oCamposDet.NUM_POA = oCEntidad.NUM_POA;
                            oCamposDet.COD_ESPECIES = loDatos.COD_ESPECIES;
                            oCamposDet.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            oCamposDet.PERIODO = loDatos.PERIODO;
                            oCamposDet.CUOTA_SACA = loDatos.CUOTA_SACA;
                            oCamposDet.METODO_CAZA = loDatos.METODO_CAZA;
                            oCamposDet.SISTEMA_MARCAJE = loDatos.SISTEMA_MARCAJE;
                            oCamposDet.DENSIDAD = loDatos.DENSIDAD;
                            oCamposDet.OBSERVACION = loDatos.OBSERVACION;
                            oCamposDet.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spPOA_INSITU_DET_RREAAPROVECHARGrabar", oCamposDet);
                        }
                    }
                }
                //Grabando Detalle POA_INSITU_DET_ACTIVIDADES
                if (oCEntidad.ListASBSAmbientales != null)
                {
                    foreach (var loDatos in oCEntidad.ListASBSAmbientales)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            oCamposDet = new CEntidad();
                            oCamposDet.COD_THABILITANTE = oCEntidad.COD_THABILITANTE;
                            oCamposDet.NUM_POA = oCEntidad.NUM_POA;
                            oCamposDet.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            oCamposDet.ACTIVIDAD = loDatos.ACTIVIDAD;
                            oCamposDet.OBJETIVOS = loDatos.OBJETIVOS;
                            oCamposDet.METODO = loDatos.METODO;
                            oCamposDet.PRESUPUESTO = loDatos.PRESUPUESTO;
                            oCamposDet.OBSERVACION = loDatos.OBSERVACION;
                            oCamposDet.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spPOA_INSITU_DET_ACTIVIDADESGrabar", oCamposDet);
                        }
                    }
                }
                //Grabando Detalle POA_INSITU_DET_BIOSEGURIDAD
                if (oCEntidad.ListBioseguridad != null)
                {
                    foreach (var loDatos in oCEntidad.ListBioseguridad)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            oCamposDet = new CEntidad();
                            oCamposDet.COD_THABILITANTE = oCEntidad.COD_THABILITANTE;
                            oCamposDet.NUM_POA = oCEntidad.NUM_POA;
                            oCamposDet.COD_BIOSEGURIDAD = loDatos.COD_BIOSEGURIDAD;
                            oCamposDet.DESCRIPCION = loDatos.DESCRIPCION;
                            oCamposDet.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spPOA_INSITU_DET_BIOSEGURIDADGrabar", oCamposDet);
                        }
                    }
                }
                //Grabando Detalle POA_DET_MADERABLE_CENSO
                if (oCEntidad.ListMadeCENSO != null)
                {
                    foreach (var loDatos in oCEntidad.ListMadeCENSO)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            oCamposDet = new CEntidad();
                            oCamposDet.COD_THABILITANTE = oCEntidad.COD_THABILITANTE;
                            oCamposDet.NUM_POA = oCEntidad.NUM_POA;
                            oCamposDet.COD_ESPECIES = loDatos.COD_ESPECIES;
                            oCamposDet.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            oCamposDet.BLOQUE = loDatos.BLOQUE;
                            oCamposDet.FAJA = loDatos.FAJA;
                            oCamposDet.CODIGO = loDatos.CODIGO;
                            oCamposDet.VOLUMEN = loDatos.VOLUMEN;
                            oCamposDet.DAP = loDatos.DAP;
                            oCamposDet.AC = loDatos.AC;
                            oCamposDet.DMC = loDatos.DMC;
                            oCamposDet.COD_ECONDICION = loDatos.COD_ECONDICION;
                            oCamposDet.COD_EESTADO = loDatos.COD_EESTADO;
                            oCamposDet.ZONA = loDatos.ZONA == "" ? null : loDatos.ZONA;
                            oCamposDet.COORDENADA_ESTE = loDatos.COORDENADA_ESTE;
                            oCamposDet.COORDENADA_NORTE = loDatos.COORDENADA_NORTE;
                            oCamposDet.OBSERVACION = loDatos.OBSERVACION;
                            oCamposDet.ESPECIES = loDatos.ESPECIES;
                            oCamposDet.CONDICION = loDatos.CONDICION;
                            oCamposDet.ESTADO = loDatos.ESTADO;
                            if (loDatos.COD_ESPECIES_ARESOLUCION != "-")
                            {
                                oCamposDet.COD_ESPECIES_ARESOLUCION = loDatos.COD_ESPECIES_ARESOLUCION;
                                oCamposDet.ESPECIES_ARESOLUCION = loDatos.ESPECIES_ARESOLUCION;
                            }
                            oCamposDet.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spPOA_DET_MADERABLE_CENSOGrabar", oCamposDet);
                        }
                    }
                }
                //Grabando Detalle POA_DET_NOMADERABLE_CENSO
                if (oCEntidad.ListNoMadeCENSO != null)
                {
                    foreach (var loDatos in oCEntidad.ListNoMadeCENSO)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            oCamposDet = new CEntidad();
                            oCamposDet.COD_THABILITANTE = oCEntidad.COD_THABILITANTE;
                            oCamposDet.NUM_POA = oCEntidad.NUM_POA;
                            oCamposDet.COD_ESPECIES = loDatos.COD_ESPECIES;
                            oCamposDet.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            oCamposDet.NUM_ESTRADA = loDatos.NUM_ESTRADA;
                            oCamposDet.CODIGO = loDatos.CODIGO;
                            oCamposDet.DIAMETRO = loDatos.DIAMETRO;
                            oCamposDet.ALTURA = loDatos.ALTURA;
                            oCamposDet.PRODUCCION_LATAS = loDatos.PRODUCCION_LATAS;
                            oCamposDet.COD_ECONDICION = loDatos.COD_ECONDICION;
                            oCamposDet.DMC = loDatos.DMC;
                            oCamposDet.COD_ECONDICION = loDatos.COD_ECONDICION;
                            oCamposDet.ZONA = loDatos.ZONA == "" ? null : loDatos.ZONA;
                            oCamposDet.COORDENADA_ESTE = loDatos.COORDENADA_ESTE;
                            oCamposDet.COORDENADA_NORTE = loDatos.COORDENADA_NORTE;
                            oCamposDet.OBSERVACION = loDatos.OBSERVACION;
                            oCamposDet.ESPECIES = loDatos.ESPECIES;
                            oCamposDet.CONDICION = loDatos.CONDICION;
                            if (loDatos.COD_ESPECIES_ARESOLUCION != "-")
                            {
                                oCamposDet.COD_ESPECIES_ARESOLUCION = loDatos.COD_ESPECIES_ARESOLUCION;
                                oCamposDet.ESPECIES_ARESOLUCION = loDatos.ESPECIES_ARESOLUCION;
                            }
                            oCamposDet.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spPOA_DET_NOMADERABLE_CENSOGrabar", oCamposDet);
                        }
                    }
                }
                ////Grabando Detalle POA_DET_MADERABLE_BEXTRACCION
                //if (oCEntidad.ListMadeBEXTRACCION != null)
                //{
                //    foreach (var loDatos in oCEntidad.ListMadeBEXTRACCION)
                //    {
                //        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                //        {
                //            oCamposDet = new CEntidad();
                //            oCamposDet.COD_THABILITANTE = oCEntidad.COD_THABILITANTE;
                //            oCamposDet.NUM_POA = oCEntidad.NUM_POA;
                //            oCamposDet.COD_ESPECIES = loDatos.COD_ESPECIES;
                //            oCamposDet.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                //            oCamposDet.DMC = loDatos.DMC;
                //            oCamposDet.TOTAL_ARBOLES = loDatos.TOTAL_ARBOLES;
                //            oCamposDet.VOLUMEN_AUTORIZADO = loDatos.VOLUMEN_AUTORIZADO;
                //            oCamposDet.VOLUMEN_MOVILIZADO = loDatos.VOLUMEN_MOVILIZADO;
                //            oCamposDet.SALDO = loDatos.SALDO;
                //            oCamposDet.OBSERVACION = loDatos.OBSERVACION;
                //            oCamposDet.ESPECIES = loDatos.ESPECIES;
                //            oCamposDet.TIPOMADERABLE = loDatos.TIPOMADERABLE;
                //            oCamposDet.RegEstado = loDatos.RegEstado;
                //            oGDataSQL.ManExecute(cn, tr, "DOC.spPOA_DET_MADERABLE_BEXTRACCIONGrabar", oCamposDet);
                //        }
                //    }
                //}
                ////Grabando Detalle POA_DET_NOMADERABLE_BEXTRACCION
                //if (oCEntidad.ListNoMadeBEXTRACCION != null)
                //{
                //    foreach (var loDatos in oCEntidad.ListNoMadeBEXTRACCION)
                //    {
                //        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                //        {
                //            oCamposDet = new CEntidad();
                //            oCamposDet.COD_THABILITANTE = oCEntidad.COD_THABILITANTE;
                //            oCamposDet.NUM_POA = oCEntidad.NUM_POA;
                //            oCamposDet.COD_ESPECIES = loDatos.COD_ESPECIES;
                //            oCamposDet.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;                            
                //            oCamposDet.OBSERVACION = loDatos.OBSERVACION;
                //            oCamposDet.ESPECIES = loDatos.ESPECIES;

                //            if (oCEntidad.COD_MTIPO == "0000020")
                //            {
                //                oCamposDet.FECHA1 = loDatos.FECHA1;
                //                oCamposDet.FECHA2 = loDatos.FECHA2;
                //                oCamposDet.SALDO = loDatos.SALDO;
                //                oCamposDet.CANTIDAD = loDatos.CANTIDAD;
                //                oCamposDet.GUIA_TRANSPORTE = loDatos.GUIA_TRANSPORTE;
                //                oCamposDet.RECIBO = loDatos.RECIBO;
                //            }
                //            else if (oCEntidad.COD_MTIPO == "0000021")
                //            {
                //                oCamposDet.UNIDAD_MEDIDA = loDatos.UNIDAD_MEDIDA;
                //                oCamposDet.AUTORIZADO = loDatos.AUTORIZADO;
                //                oCamposDet.EXTRAIDO = loDatos.EXTRAIDO;
                //                oCamposDet.SALDO = loDatos.SALDO;
                //            }
                //            else
                //            {
                //                oCamposDet.KILOGRAMO_AUTORIZADO = loDatos.KILOGRAMO_AUTORIZADO;
                //                oCamposDet.KILOGRAMO_MOVILIZADO = loDatos.KILOGRAMO_MOVILIZADO;
                //                oCamposDet.SALDO = loDatos.SALDO;
                //            }    

                //            oCamposDet.RegEstado = loDatos.RegEstado;
                //            oGDataSQL.ManExecute(cn, tr, "DOC.spPOA_DET_NOMADERABLE_BEXTRACCIONGrabar", oCamposDet);
                //        }
                //    }
                //}
                //grabando detalle POA_DET_NOMADERABLE_BEXTRACCION
                //if (oCEntidad.ListBExtMedicinales != null)
                //{
                //    foreach (var loDatos in oCEntidad.ListBExtMedicinales)
                //    {
                //        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                //        {
                //            oCamposDet = new CEntidad();
                //            oCamposDet.COD_THABILITANTE = oCEntidad.COD_THABILITANTE;
                //            oCamposDet.NUM_POA = oCEntidad.NUM_POA;
                //            oCamposDet.COD_ESPECIES = loDatos.COD_ESPECIES;
                //            oCamposDet.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                //            oCamposDet.UNIDAD_MEDIDA = loDatos.UNIDAD_MEDIDA;
                //            oCamposDet.AUTORIZADO = loDatos.AUTORIZADO;
                //            oCamposDet.EXTRAIDO = loDatos.EXTRAIDO;
                //            oCamposDet.SALDO = loDatos.SALDO;
                //            oCamposDet.OBSERVACION = loDatos.OBSERVACION;
                //            oCamposDet.ESPECIES = loDatos.ESPECIES;
                //            oCamposDet.RegEstado = loDatos.RegEstado;
                //            if (oCEntidad.COD_MTIPO == "0000021")
                //            {
                //                oGDataSQL.ManExecute(cn, tr, "DOC.spPOA_DET_NOMADERABLE_BEXTRACCIONMedicinalesGrabar", oCamposDet);
                //            }
                //        }
                //    }
                //}
                ////Grabando Detalle POA_INSITU_DET_BEXTRACCION
                //if (oCEntidad.ListISituBEXTRACCION != null)
                //{
                //    foreach (var loDatos in oCEntidad.ListISituBEXTRACCION)
                //    {
                //        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                //        {
                //            oCamposDet = new CEntidad();
                //            oCamposDet.COD_THABILITANTE = oCEntidad.COD_THABILITANTE;
                //            oCamposDet.NUM_POA = oCEntidad.NUM_POA;
                //            oCamposDet.COD_ESPECIES = loDatos.COD_ESPECIES;
                //            oCamposDet.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                //            oCamposDet.CANTIDAD_AUTORIZADO = loDatos.CANTIDAD_AUTORIZADO;
                //            oCamposDet.CANTIDAD_MOVILIZADO = loDatos.CANTIDAD_MOVILIZADO;
                //            oCamposDet.SALDO = loDatos.SALDO;
                //            oCamposDet.OBSERVACION = loDatos.OBSERVACION;
                //            oCamposDet.ESPECIES = loDatos.ESPECIES;
                //            oCamposDet.RegEstado = loDatos.RegEstado;
                //            oGDataSQL.ManExecute(cn, tr, "DOC.spPOA_INSITU_DET_BEXTRACCIONGrabar", oCamposDet);
                //        }
                //    }
                //}
                //Grabando Detalle POA_DET_VERTICE
                if (oCEntidad.ListVERTICE != null)
                {
                    foreach (var loDatos in oCEntidad.ListVERTICE)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            oCamposDet = new CEntidad();
                            oCamposDet.COD_THABILITANTE = oCEntidad.COD_THABILITANTE;
                            oCamposDet.NUM_POA = oCEntidad.NUM_POA;
                            oCamposDet.VERTICE = loDatos.VERTICE;
                            oCamposDet.ZONA = loDatos.ZONA == "" ? null : loDatos.ZONA;
                            oCamposDet.COORDENADA_ESTE = loDatos.COORDENADA_ESTE;
                            oCamposDet.COORDENADA_NORTE = loDatos.COORDENADA_NORTE;
                            oCamposDet.OBSERVACION = loDatos.OBSERVACION;
                            oCamposDet.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            oCamposDet.RegEstado = loDatos.RegEstado;
                            oCamposDet.PCA = loDatos.PCA;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spPOA_DET_VERTICEGrabar", oCamposDet);
                        }
                    }
                }
                //Grabando POA_DET_KARDEX
                if (oCEntidad.ListKARDEX != null)
                {
                    foreach (var loDatos in oCEntidad.ListKARDEX)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            oCamposDet = new CEntidad();
                            oCamposDet.COD_THABILITANTE = oCEntidad.COD_THABILITANTE;
                            oCamposDet.NUM_POA = oCEntidad.NUM_POA;
                            oCamposDet.COD_ESPECIES = loDatos.COD_ESPECIES;
                            oCamposDet.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            oCamposDet.FECHA_EMISIONKARDEX = loDatos.FECHA_EMISIONKARDEX;
                            oCamposDet.GUIA_TRANSPORTE = loDatos.GUIA_TRANSPORTE;
                            oCamposDet.COD_KARDEX_PRODUCTO = loDatos.COD_KARDEX_PRODUCTO;
                            oCamposDet.COD_KARDEX_DESCRIPCION = loDatos.COD_KARDEX_DESCRIPCION;
                            oCamposDet.CANTIDAD = loDatos.CANTIDAD;
                            oCamposDet.KILOGRAMOS_KARDEX = loDatos.KILOGRAMOS_KARDEX;
                            oCamposDet.M3 = loDatos.M3;
                            oCamposDet.ACUMULADO = loDatos.ACUMULADO;
                            oCamposDet.SALDO_KARDEX = loDatos.SALDO_KARDEX;
                            oCamposDet.OBSERVACION_KARDEX = loDatos.OBSERVACION_KARDEX;
                            oCamposDet.ESPECIES = loDatos.ESPECIES;
                            oCamposDet.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spPOA_DET_KARDEXGrabar", oCamposDet);
                        }
                    }
                }
                //Grabando POA_DET_RDREFORMULA
                if (oCEntidad.ListRDReformulaPOA != null)
                {
                    int i = 0;
                    CEntidad oCamposPersona;
                    CEntidad oCamposEspecie;

                    foreach (var loDatos in oCEntidad.ListRDReformulaPOA)
                    {
                        oCamposDet = new CEntidad();
                        oCamposDet.COD_THABILITANTE = oCEntidad.COD_THABILITANTE;
                        oCamposDet.NUM_POA = oCEntidad.NUM_POA;
                        oCamposDet.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                        oCamposDet.ITECNICO_REFORMULA_POA_NUM = loDatos.ITECNICO_REFORMULA_POA_NUM;
                        oCamposDet.ITECNICO_REFORMULA_POA_FECHA = loDatos.ITECNICO_REFORMULA_POA_FECHA;
                        oCamposDet.COD_UCUENTA = oCEntidad.COD_UCUENTA;
                        oCamposDet.RegEstado = loDatos.RegEstado;
                        oCamposDet.OUTPUTPARAMDET01 = "";

                        using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spPOA_DET_RDREFORMULAGrabar", oCamposDet))
                        {
                            cmd.ExecuteNonQuery();
                            oCamposDet.COD_SECUENCIAL = Convert.ToInt32(cmd.Parameters["OUTPUTPARAMDET01"].Value);
                        }

                        // Grabando Detalle POA_DET_REFORMULA
                        if (oCEntidad.ListRDReformulaPOA[i].ListREFORMULAPOA != null)
                        {
                            foreach (var person in oCEntidad.ListRDReformulaPOA[i].ListREFORMULAPOA)
                            {
                                if (person.RegEstado == 1) //Nuevo o Modificado
                                {
                                    oCamposPersona = new CEntidad();
                                    oCamposPersona.COD_THABILITANTE = oCEntidad.COD_THABILITANTE;
                                    oCamposPersona.NUM_POA = oCEntidad.NUM_POA;
                                    oCamposPersona.COD_SECUENCIAL = oCamposDet.COD_SECUENCIAL;
                                    oCamposPersona.COD_PREFORMULA = person.COD_PERSONA;
                                    oCamposPersona.COD_UCUENTA = oCEntidad.COD_UCUENTA;
                                    dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spPOA_DET_REFORMULAGrabar", oCamposPersona);
                                }
                            }
                        }

                        //Grabando Detalle POA_DET_MADE_NOMADE_RREAAPROVECHAR
                        if (oCEntidad.ListRDReformulaPOA[i].ListRReformula != null)
                        {
                            foreach (var especie in oCEntidad.ListRDReformulaPOA[i].ListRReformula)
                            {
                                if (especie.RegEstado == 1 || especie.RegEstado == 2) //Nuevo o Modificado
                                {
                                    oCamposEspecie = new CEntidad();
                                    oCamposEspecie.COD_THABILITANTE = oCEntidad.COD_THABILITANTE;
                                    oCamposEspecie.NUM_POA = oCEntidad.NUM_POA;
                                    oCamposEspecie.COD_SECUENCIAL_RDREF = oCamposDet.COD_SECUENCIAL;
                                    oCamposEspecie.COD_ESPECIES = especie.COD_ESPECIES;
                                    oCamposEspecie.ESPECIES = especie.ESPECIES;
                                    oCamposEspecie.COD_SECUENCIAL = especie.COD_SECUENCIAL;
                                    if (oCEntidad.COD_MTIPO == "0000020")
                                    {
                                        oCamposEspecie.SuperficieHa = especie.SuperficieHa;
                                        oCamposEspecie.CANTIDAD = especie.CANTIDAD;
                                    }
                                    else if (oCEntidad.COD_MTIPO == "0000021")
                                    {
                                        oCamposEspecie.ABUNDANCIA = especie.ABUNDANCIA;
                                        oCamposEspecie.NUMINDIVIDUOS = especie.NUMINDIVIDUOS;
                                        oCamposEspecie.PESO = especie.PESO;
                                        oCamposEspecie.RENDIMIENTO = especie.RENDIMIENTO;
                                        oCamposEspecie.UNIDAD_MEDIDA = especie.UNIDAD_MEDIDA;
                                    }
                                    else
                                    {
                                        oCamposEspecie.NUM_ARBOLES = especie.NUM_ARBOLES;
                                        oCamposEspecie.VOLUMEN_KILOGRAMOS = especie.VOLUMEN_KILOGRAMOS;
                                        oCamposEspecie.TIPOMADERABLE = especie.TIPOMADERABLE;
                                    }
                                    if (especie.COD_ESPECIES_SERFOR != "-")
                                    {
                                        oCamposEspecie.COD_ESPECIES_SERFOR = especie.COD_ESPECIES_SERFOR;
                                        oCamposEspecie.ESPECIES_SERFOR = especie.ESPECIES_SERFOR;
                                    }
                                    oCamposEspecie.OBSERVACION = especie.OBSERVACION;
                                    oCamposEspecie.COD_UCUENTA = oCEntidad.COD_UCUENTA;
                                    oCamposEspecie.RegEstado = especie.RegEstado;
                                    dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spPOA_DET_MADE_NOMADE_RREAAPROVECHARGrabar", oCamposEspecie);
                                }
                            }
                        }
                        i++;
                    }
                }
                //Grabando POA_DET_BEXTRACCION
                if (oCEntidad.ListBExtPOA != null)
                {
                    int i = 0;
                    CEntidad oCamposBExtMade;
                    CEntidad oCamposBExtNoMade;
                    CEntidad oCamposBEInSitu;

                    foreach (var loDatos in oCEntidad.ListBExtPOA)
                    {
                        oCamposDet = new CEntidad();
                        oCamposDet.COD_THABILITANTE = oCEntidad.COD_THABILITANTE;
                        oCamposDet.NUM_POA = oCEntidad.NUM_POA;
                        oCamposDet.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                        oCamposDet.BEXTRACCION_FEMISION = loDatos.BEXTRACCION_FEMISION;
                        oCamposDet.COD_UCUENTA = oCEntidad.COD_UCUENTA;
                        oCamposDet.RegEstado = loDatos.RegEstado;
                        oCamposDet.OUTPUTPARAMDET01 = "";

                        using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spPOA_DET_BEXTRACCIONGrabar", oCamposDet))
                        {
                            cmd.ExecuteNonQuery();
                            oCamposDet.COD_SECUENCIAL = Convert.ToInt32(cmd.Parameters["OUTPUTPARAMDET01"].Value);
                        }

                        //Grabando Detalle POA_DET_MADERABLE_BEXTRACCION
                        if (oCEntidad.ListBExtPOA[i].ListMadeBEXTRACCION != null)
                        {
                            foreach (var made in oCEntidad.ListBExtPOA[i].ListMadeBEXTRACCION)
                            {
                                if (made.RegEstado == 1 || made.RegEstado == 2) //Nuevo o Modificado
                                {
                                    oCamposBExtMade = new CEntidad();
                                    oCamposBExtMade.COD_THABILITANTE = oCEntidad.COD_THABILITANTE;
                                    oCamposBExtMade.NUM_POA = oCEntidad.NUM_POA;
                                    oCamposBExtMade.COD_SECUENCIAL_BEXT = oCamposDet.COD_SECUENCIAL;
                                    oCamposBExtMade.COD_ESPECIES = made.COD_ESPECIES;
                                    oCamposBExtMade.COD_SECUENCIAL = made.COD_SECUENCIAL;
                                    oCamposBExtMade.DMC = made.DMC;
                                    oCamposBExtMade.TOTAL_ARBOLES = made.TOTAL_ARBOLES;
                                    oCamposBExtMade.VOLUMEN_AUTORIZADO = made.VOLUMEN_AUTORIZADO;
                                    oCamposBExtMade.VOLUMEN_MOVILIZADO = made.VOLUMEN_MOVILIZADO;
                                    oCamposBExtMade.SALDO = made.SALDO;
                                    oCamposBExtMade.OBSERVACION = made.OBSERVACION;
                                    oCamposBExtMade.ESPECIES = made.ESPECIES;
                                    oCamposBExtMade.TIPOMADERABLE = made.TIPOMADERABLE;
                                    if (made.COD_ESPECIES_SERFOR != "-")
                                    {
                                        oCamposBExtMade.COD_ESPECIES_SERFOR = made.COD_ESPECIES_SERFOR;
                                        oCamposBExtMade.ESPECIES_SERFOR = made.ESPECIES_SERFOR;
                                    }
                                    oCamposBExtMade.COD_UCUENTA = oCEntidad.COD_UCUENTA;
                                    oCamposBExtMade.RegEstado = made.RegEstado;
                                    dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spPOA_DET_MADERABLE_BEXTRACCIONGrabar", oCamposBExtMade);
                                }
                            }
                        }

                        //Grabando Detalle POA_DET_NOMADERABLE_BEXTRACCION
                        if (oCEntidad.ListBExtPOA[i].ListNoMadeBEXTRACCION != null)
                        {
                            foreach (var nomade in oCEntidad.ListBExtPOA[i].ListNoMadeBEXTRACCION)
                            {
                                if (nomade.RegEstado == 1 || nomade.RegEstado == 2) //Nuevo o Modificado
                                {
                                    oCamposBExtNoMade = new CEntidad();
                                    oCamposBExtNoMade.COD_THABILITANTE = oCEntidad.COD_THABILITANTE;
                                    oCamposBExtNoMade.NUM_POA = oCEntidad.NUM_POA;
                                    oCamposBExtNoMade.COD_SECUENCIAL_BEXT = oCamposDet.COD_SECUENCIAL;
                                    oCamposBExtNoMade.COD_ESPECIES = nomade.COD_ESPECIES;
                                    oCamposBExtNoMade.COD_SECUENCIAL = nomade.COD_SECUENCIAL;
                                    oCamposBExtNoMade.OBSERVACION = nomade.OBSERVACION;
                                    oCamposBExtNoMade.ESPECIES = nomade.ESPECIES;

                                    if (oCEntidad.COD_MTIPO == "0000020")
                                    {
                                        oCamposBExtNoMade.FECHA1 = nomade.FECHA1;
                                        oCamposBExtNoMade.FECHA2 = nomade.FECHA2;
                                        oCamposBExtNoMade.SALDO = nomade.SALDO;
                                        oCamposBExtNoMade.CANTIDAD = nomade.CANTIDAD;
                                        oCamposBExtNoMade.GUIA_TRANSPORTE = nomade.GUIA_TRANSPORTE;
                                        oCamposBExtNoMade.RECIBO = nomade.RECIBO;
                                    }
                                    else if (oCEntidad.COD_MTIPO == "0000021")
                                    {
                                        oCamposBExtNoMade.UNIDAD_MEDIDA = nomade.UNIDAD_MEDIDA;
                                        oCamposBExtNoMade.AUTORIZADO = nomade.AUTORIZADO;
                                        oCamposBExtNoMade.EXTRAIDO = nomade.EXTRAIDO;
                                        oCamposBExtNoMade.SALDO = nomade.SALDO;
                                    }
                                    else
                                    {
                                        oCamposBExtNoMade.KILOGRAMO_AUTORIZADO = nomade.KILOGRAMO_AUTORIZADO;
                                        oCamposBExtNoMade.KILOGRAMO_MOVILIZADO = nomade.KILOGRAMO_MOVILIZADO;
                                        oCamposBExtNoMade.SALDO = nomade.SALDO;
                                    }
                                    if (nomade.COD_ESPECIES_SERFOR != "-")
                                    {
                                        oCamposBExtNoMade.COD_ESPECIES_SERFOR = nomade.COD_ESPECIES_SERFOR;
                                        oCamposBExtNoMade.ESPECIES_SERFOR = nomade.ESPECIES_SERFOR;
                                    }
                                    oCamposBExtNoMade.COD_UCUENTA = oCEntidad.COD_UCUENTA;
                                    oCamposBExtNoMade.RegEstado = nomade.RegEstado;
                                    dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spPOA_DET_NOMADERABLE_BEXTRACCIONGrabar", oCamposBExtNoMade);
                                }
                            }
                        }

                        //Grabando Detalle POA_INSITU_DET_BEXTRACCION
                        if (oCEntidad.ListBExtPOA[i].ListISituBEXTRACCION != null)
                        {
                            foreach (var insitu in oCEntidad.ListBExtPOA[i].ListISituBEXTRACCION)
                            {
                                if (insitu.RegEstado == 1 || insitu.RegEstado == 2) //Nuevo o Modificado
                                {
                                    oCamposBEInSitu = new CEntidad();
                                    oCamposBEInSitu.COD_THABILITANTE = oCEntidad.COD_THABILITANTE;
                                    oCamposBEInSitu.NUM_POA = oCEntidad.NUM_POA;
                                    oCamposBEInSitu.COD_SECUENCIAL_BEXT = oCamposDet.COD_SECUENCIAL;
                                    oCamposBEInSitu.COD_ESPECIES = insitu.COD_ESPECIES;
                                    oCamposBEInSitu.COD_SECUENCIAL = insitu.COD_SECUENCIAL;
                                    oCamposBEInSitu.CANTIDAD_AUTORIZADO = insitu.CANTIDAD_AUTORIZADO;
                                    oCamposBEInSitu.CANTIDAD_MOVILIZADO = insitu.CANTIDAD_MOVILIZADO;
                                    oCamposBEInSitu.SALDO = insitu.SALDO;
                                    oCamposBEInSitu.OBSERVACION = insitu.OBSERVACION;
                                    oCamposBEInSitu.ESPECIES = insitu.ESPECIES;
                                    if (insitu.COD_ESPECIES_SERFOR != "-")
                                    {
                                        oCamposBEInSitu.COD_ESPECIES_SERFOR = insitu.COD_ESPECIES_SERFOR;
                                        oCamposBEInSitu.ESPECIES_SERFOR = insitu.ESPECIES_SERFOR;
                                    }
                                    oCamposBEInSitu.RegEstado = insitu.RegEstado;
                                    dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spPOA_INSITU_DET_BEXTRACCIONGrabar", oCamposBEInSitu);
                                }
                            }
                        }
                        i++;
                    }
                }
                //grabando kardex carrizo
                //if (oCEntidad.ListKardexCarrizos != null)
                //{
                //    foreach (var loDatos in oCEntidad.ListKardexCarrizos)
                //    {
                //        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2)
                //        {
                //            oCamposDet = new CEntidad();
                //            oCamposDet.COD_THABILITANTE = oCEntidad.COD_THABILITANTE;
                //            oCamposDet.NUM_POA = oCEntidad.NUM_POA;
                //            oCamposDet.COD_ESPECIES = loDatos.COD_ESPECIES;
                //            oCamposDet.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                //            oCamposDet.FECHA1 = loDatos.FECHA1;
                //            oCamposDet.FECHA2 = loDatos.FECHA2;
                //            oCamposDet.SALDO = loDatos.SALDO;
                //            oCamposDet.CANTIDAD = loDatos.CANTIDAD;
                //            oCamposDet.OBSERVACION = loDatos.OBSERVACION;
                //            oCamposDet.GUIA_TRANSPORTE = loDatos.GUIA_TRANSPORTE;
                //            oCamposDet.RECIBO = loDatos.RECIBO;
                //            oCamposDet.ESPECIES = loDatos.ESPECIES;
                //            oCamposDet.RegEstado = loDatos.RegEstado;
                //            if (oCEntidad.COD_MTIPO == "0000020")
                //            {
                //                oGDataSQL.ManExecute(cn, tr, "DOC.spPOA_DET_KARDEXCarrizoGrabar", oCamposDet);
                //            }
                //        }
                //    }
                //}
                //
                tr.Commit();
                return OUTPUTPARAM01;
            }
            catch (Exception ex)
            {
                if (tr != null)
                {
                    tr.Rollback();
                }
                throw ex;
            }
        }


        public String RegGrabarV3(OracleConnection cn, CEntidad oCEntidad, OracleTransaction tr)
        {
            String OUTPUTPARAM01 = "";
            String OUTPUTPARAM02 = "";
            CEntidad oCamposDet;
            //OracleTransaction tr = null;
            try
            {

                //Grabando Cabecera
                using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spPOAGrabarV3", oCEntidad))
                {
                    cmd.ExecuteNonQuery();
                    OUTPUTPARAM01 = (String)cmd.Parameters["OUTPUTPARAM01"].Value;
                    OUTPUTPARAM02 = (String)cmd.Parameters["OUTPUTPARAM02"].Value;
                    if (OUTPUTPARAM01 == "99")
                    {
                        throw new Exception("Ud. no tiene permiso para realizar esta acción");
                    }
                    if (OUTPUTPARAM01 == "0")
                    {
                        throw new Exception("El Número de POA para este Titulo Habilitante ya Existe");
                    }
                    else if (OUTPUTPARAM01 == "1")
                    {
                        throw new Exception("El Número de Resolución ya Existe en Otra POA");
                    }
                    else if (OUTPUTPARAM01 == "2")
                    {
                        throw new Exception("No Tiene Permisos para Modificar este POA");
                    }
                    else if (OUTPUTPARAM01 == "3")
                    {
                        throw new Exception("Está con Control de Calidad, no puede modificar");
                    }
                    else if (OUTPUTPARAM01 == "4")
                    {
                        throw new Exception("No puede eliminar el Censo, ya existe muestra seleccionada sobre este Plan");
                    }

                    if (OUTPUTPARAM02 != "")
                    {
                        if (OUTPUTPARAM01.Length > 15)
                        {
                            oCEntidad.COD_THABILITANTE = OUTPUTPARAM01.Split('|')[1]; ;
                        }
                        else
                        {
                            oCEntidad.COD_THABILITANTE = OUTPUTPARAM01;
                        }

                        oCEntidad.NUM_POA = Int32.Parse(OUTPUTPARAM02);
                    }
                }
                //
                //Eliminando Detalle
                if (oCEntidad.ListEliTABLA != null)
                {
                    foreach (var loDatos in oCEntidad.ListEliTABLA)
                    {
                        oCamposDet = new CEntidad();
                        oCamposDet.COD_THABILITANTE = oCEntidad.COD_THABILITANTE;
                        oCamposDet.NUM_POA = oCEntidad.NUM_POA;
                        oCamposDet.EliTABLA = loDatos.EliTABLA;
                        oCamposDet.EliVALOR01 = loDatos.EliVALOR01;
                        oCamposDet.EliVALOR02 = loDatos.EliVALOR02;
                        dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spPOAEliminarDetalle", oCamposDet);
                    }
                }
                //05/05/2023
                // Grabando POA_DET_REGENTE
                if (oCEntidad.ListDETREGENTE != null)
                {
                    foreach (var loDatos in oCEntidad.ListDETREGENTE)
                    {

                        oCamposDet = new CEntidad();
                        oCamposDet.COD_THABILITANTE = oCEntidad.COD_THABILITANTE;
                        oCamposDet.NUM_POA = oCEntidad.NUM_POA;
                        oCamposDet.COD_PERSONA = loDatos.COD_PERSONA;
                        oCamposDet.NOMBRE_ARCH = loDatos.NOMBRE_ARCH;
                        oCamposDet.COD_PTIPO = loDatos.COD_PTIPO;
                        oCamposDet.FECHA = loDatos.FECHA;
                        oCamposDet.FECHA1 = loDatos.FECHA1;
                        dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.SPPOA_DET_REGENTEGRABAR", oCamposDet);

                    }
                }
                // Grabando POA_DET_AIOCULAR
                if (oCEntidad.ListAOCULAR != null)
                {

                    foreach (var loDatos in oCEntidad.ListAOCULAR)
                    {

                        oCamposDet = new CEntidad();
                        oCamposDet.COD_THABILITANTE = oCEntidad.COD_THABILITANTE;
                        oCamposDet.NUM_POA = oCEntidad.NUM_POA;
                        oCamposDet.COD_POCULAR = loDatos.COD_PERSONA;
                        oCamposDet.COD_PTIPO = loDatos.COD_PTIPO;
                        dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spPOA_DET_AIOCULARGrabar", oCamposDet);

                    }
                }
                //Grabando Detalle POA_DET_TIOCULAR
                if (oCEntidad.ListTIOCULAR != null)
                {
                    foreach (var loDatos in oCEntidad.ListTIOCULAR)
                    {

                        oCamposDet = new CEntidad();
                        oCamposDet.COD_THABILITANTE = oCEntidad.COD_THABILITANTE;
                        oCamposDet.NUM_POA = oCEntidad.NUM_POA;
                        oCamposDet.COD_TIOCULAR = loDatos.COD_PERSONA;
                        oCamposDet.COD_PTIPO = loDatos.COD_PTIPO;
                        dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spPOA_DET_TIOCULARGrabar", oCamposDet);

                    }
                }
                //Grabando Detalle POA_DET_TRAPROBACION
                if (oCEntidad.ListTRAPROBACION != null)
                {
                    foreach (var loDatos in oCEntidad.ListTRAPROBACION)
                    {

                        oCamposDet = new CEntidad();
                        oCamposDet.COD_THABILITANTE = oCEntidad.COD_THABILITANTE;
                        oCamposDet.NUM_POA = oCEntidad.NUM_POA;
                        oCamposDet.COD_TRAPROBACION = loDatos.COD_PERSONA;
                        oCamposDet.COD_PTIPO = loDatos.COD_PTIPO;
                        dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spPOA_DET_TRAPROBACIONGrabar", oCamposDet);

                    }
                }
                //Grabando Detalle POA_DET_SAPROBACION
                if (oCEntidad.ListSAPROBACION != null)
                {
                    foreach (var loDatos in oCEntidad.ListSAPROBACION)
                    {

                        oCamposDet = new CEntidad();
                        oCamposDet.COD_THABILITANTE = oCEntidad.COD_THABILITANTE;
                        oCamposDet.NUM_POA = oCEntidad.NUM_POA;
                        oCamposDet.COD_SAPROBACION = loDatos.COD_PERSONA;
                        oCamposDet.COD_PTIPO = loDatos.COD_PTIPO;
                        dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spPOA_DET_SAPROBACIONGrabar", oCamposDet);

                    }
                }

                //05/05/2021
                if (oCEntidad.ListParcela != null)
                {
                    foreach (var loDatos in oCEntidad.ListParcela)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            oCamposDet = new CEntidad();
                            oCamposDet.COD_THABILITANTE = oCEntidad.COD_THABILITANTE;
                            oCamposDet.NUM_POA = oCEntidad.NUM_POA;
                            oCamposDet.PCA = loDatos.PCA;
                            oCamposDet.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            oCamposDet.AREA = loDatos.AREA;
                            oCamposDet.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.SPPOA_PARCELA_GRABAR", oCamposDet);
                        }
                    }
                }

                //Grabando Detalle POA_DET_MADE_NOMADE_EAAPROVECHAR
                if (oCEntidad.ListRAprueba != null)
                {
                    foreach (var loDatos in oCEntidad.ListRAprueba)
                    {

                        oCamposDet = new CEntidad();
                        oCamposDet.COD_UCUENTA = oCEntidad.COD_UCUENTA;
                        oCamposDet.COD_THABILITANTE = oCEntidad.COD_THABILITANTE;
                        oCamposDet.NUM_POA = oCEntidad.NUM_POA;
                        oCamposDet.COD_ESPECIES = loDatos.COD_ESPECIES;
                        oCamposDet.ESPECIES = loDatos.ESPECIES;
                        oCamposDet.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;

                        if (oCEntidad.COD_MTIPO == "0000020")
                        {
                            oCamposDet.SuperficieHa = loDatos.SuperficieHa;
                            oCamposDet.CANTIDAD = loDatos.CANTIDAD;
                        }
                        else if (oCEntidad.COD_MTIPO == "0000021")
                        {
                            oCamposDet.ABUNDANCIA = loDatos.ABUNDANCIA;
                            oCamposDet.NUMINDIVIDUOS = loDatos.NUMINDIVIDUOS;
                            oCamposDet.PESO = loDatos.PESO;
                            oCamposDet.RENDIMIENTO = loDatos.RENDIMIENTO;
                            oCamposDet.UNIDAD_MEDIDA = loDatos.UNIDAD_MEDIDA;
                        }
                        else
                        {
                            oCamposDet.NUM_ARBOLES = loDatos.NUM_ARBOLES;
                            oCamposDet.VOLUMEN_KILOGRAMOS = loDatos.VOLUMEN_KILOGRAMOS;
                            oCamposDet.UNIDAD_MEDIDA = loDatos.UNIDAD_MEDIDA;
                        }
                        if (loDatos.COD_ESPECIES_SERFOR != "-")
                        {
                            oCamposDet.COD_ESPECIES_SERFOR = loDatos.COD_ESPECIES_SERFOR;
                            oCamposDet.ESPECIES_SERFOR = loDatos.ESPECIES_SERFOR;
                        }
                        oCamposDet.TIPOMADERABLE = loDatos.TIPOMADERABLE;
                        oCamposDet.OBSERVACION = loDatos.OBSERVACION;
                        oCamposDet.RegEstado = loDatos.RegEstado;
                        oCamposDet.PCA = loDatos.PCA;
                        dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spPOA_DET_MADE_NOMADE_EAAPROVECHARGrabar", oCamposDet);

                    }
                }
                //Grabando Detalle POA_INSITU_DET_EAAPROVECHAR
                if (oCEntidad.ListRApruebaISitu != null)
                {
                    foreach (var loDatos in oCEntidad.ListRApruebaISitu)
                    {

                        oCamposDet = new CEntidad();
                        oCamposDet.COD_THABILITANTE = oCEntidad.COD_THABILITANTE;
                        oCamposDet.NUM_POA = oCEntidad.NUM_POA;
                        oCamposDet.COD_ESPECIES = loDatos.COD_ESPECIES;
                        oCamposDet.ESPECIES = loDatos.ESPECIES;
                        oCamposDet.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                        oCamposDet.PERIODO = loDatos.PERIODO;
                        oCamposDet.CUOTA_SACA = loDatos.CUOTA_SACA;
                        oCamposDet.METODO_CAZA = loDatos.METODO_CAZA;
                        oCamposDet.SISTEMA_MARCAJE = loDatos.SISTEMA_MARCAJE;
                        oCamposDet.DENSIDAD = loDatos.DENSIDAD;
                        if (loDatos.COD_ESPECIES_SERFOR != "-")
                        {
                            oCamposDet.COD_ESPECIES_SERFOR = loDatos.COD_ESPECIES_SERFOR;
                            oCamposDet.ESPECIES_SERFOR = loDatos.ESPECIES_SERFOR;
                        }
                        oCamposDet.OBSERVACION = loDatos.OBSERVACION;
                        oCamposDet.RegEstado = loDatos.RegEstado;
                        dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spPOA_INSITU_DET_EAAPROVECHARGrabarV3", oCamposDet);

                    }
                }

                //Grabando Detalle POA_INSITU_DET_RREAAPROVECHAR
                if (oCEntidad.ListRReformulaISitu != null)
                {
                    foreach (var loDatos in oCEntidad.ListRReformulaISitu)
                    {

                        oCamposDet = new CEntidad();
                        oCamposDet.COD_THABILITANTE = oCEntidad.COD_THABILITANTE;
                        oCamposDet.NUM_POA = oCEntidad.NUM_POA;
                        oCamposDet.COD_ESPECIES = loDatos.COD_ESPECIES;
                        oCamposDet.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                        oCamposDet.PERIODO = loDatos.PERIODO;
                        oCamposDet.CUOTA_SACA = loDatos.CUOTA_SACA;
                        oCamposDet.METODO_CAZA = loDatos.METODO_CAZA;
                        oCamposDet.SISTEMA_MARCAJE = loDatos.SISTEMA_MARCAJE;
                        oCamposDet.DENSIDAD = loDatos.DENSIDAD;
                        oCamposDet.OBSERVACION = loDatos.OBSERVACION;
                        oCamposDet.RegEstado = loDatos.RegEstado;
                        dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spPOA_INSITU_DET_RREAAPROVECHARGrabar", oCamposDet);

                    }
                }
                //Grabando Detalle POA_INSITU_DET_ACTIVIDADES
                if (oCEntidad.ListASBSAmbientales != null)
                {
                    foreach (var loDatos in oCEntidad.ListASBSAmbientales)
                    {

                        oCamposDet = new CEntidad();
                        oCamposDet.COD_THABILITANTE = oCEntidad.COD_THABILITANTE;
                        oCamposDet.NUM_POA = oCEntidad.NUM_POA;
                        oCamposDet.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                        oCamposDet.ACTIVIDAD = loDatos.ACTIVIDAD;
                        oCamposDet.OBJETIVOS = loDatos.OBJETIVOS;
                        oCamposDet.METODO = loDatos.METODO;
                        oCamposDet.PRESUPUESTO = loDatos.PRESUPUESTO;
                        oCamposDet.OBSERVACION = loDatos.OBSERVACION;
                        oCamposDet.RegEstado = loDatos.RegEstado;
                        dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spPOA_INSITU_DET_ACTIVIDADESGrabar", oCamposDet);

                    }
                }
                //Grabando Detalle POA_INSITU_DET_BIOSEGURIDAD
                if (oCEntidad.ListBioseguridad != null)
                {
                    foreach (var loDatos in oCEntidad.ListBioseguridad)
                    {

                        oCamposDet = new CEntidad();
                        oCamposDet.COD_THABILITANTE = oCEntidad.COD_THABILITANTE;
                        oCamposDet.NUM_POA = oCEntidad.NUM_POA;
                        oCamposDet.COD_BIOSEGURIDAD = loDatos.COD_BIOSEGURIDAD;
                        oCamposDet.DESCRIPCION = loDatos.DESCRIPCION;
                        oCamposDet.RegEstado = loDatos.RegEstado;
                        dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spPOA_INSITU_DET_BIOSEGURIDADGrabar", oCamposDet);

                    }
                }
                //Grabando Detalle POA_DET_MADERABLE_CENSO
                if (oCEntidad.ListMadeCENSO != null)
                {
                    foreach (var loDatos in oCEntidad.ListMadeCENSO)
                    {

                        oCamposDet = new CEntidad();
                        oCamposDet.COD_THABILITANTE = oCEntidad.COD_THABILITANTE;
                        oCamposDet.NUM_POA = oCEntidad.NUM_POA;
                        oCamposDet.COD_ESPECIES = loDatos.COD_ESPECIES;
                        oCamposDet.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                        oCamposDet.BLOQUE = loDatos.BLOQUE;
                        oCamposDet.FAJA = loDatos.FAJA;
                        oCamposDet.CODIGO = loDatos.CODIGO;
                        oCamposDet.VOLUMEN = loDatos.VOLUMEN;
                        oCamposDet.DAP = loDatos.DAP;
                        oCamposDet.AC = loDatos.AC;
                        oCamposDet.DMC = loDatos.DMC;
                        oCamposDet.COD_ECONDICION = loDatos.COD_ECONDICION;
                        oCamposDet.COD_EESTADO = loDatos.COD_EESTADO;
                        oCamposDet.ZONA = loDatos.ZONA == "" ? null : loDatos.ZONA;
                        oCamposDet.COORDENADA_ESTE = loDatos.COORDENADA_ESTE;
                        oCamposDet.COORDENADA_NORTE = loDatos.COORDENADA_NORTE;
                        oCamposDet.OBSERVACION = loDatos.OBSERVACION;
                        oCamposDet.ESPECIES = loDatos.ESPECIES;
                        oCamposDet.CONDICION = loDatos.CONDICION;
                        oCamposDet.ESTADO = loDatos.ESTADO;
                        oCamposDet.PCA = loDatos.PCA;
                        //if (loDatos.COD_ESPECIES_ARESOLUCION.Length >5)
                        if (loDatos.COD_ESPECIES_ARESOLUCION != "-" && loDatos.COD_ESPECIES_ARESOLUCION != " | ")
                        {
                            oCamposDet.COD_ESPECIES_ARESOLUCION = loDatos.COD_ESPECIES_ARESOLUCION;
                            if (loDatos.ESPECIES_ARESOLUCION != " | ")
                            {
                                oCamposDet.ESPECIES_ARESOLUCION = loDatos.ESPECIES_ARESOLUCION;
                            }


                        }
                        oCamposDet.RegEstado = loDatos.RegEstado;
                        dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spPOA_DET_MADERABLE_CENSOGrabarV3", oCamposDet);

                    }
                }
                //Grabando Detalle POA_DET_NOMADERABLE_CENSO
                if (oCEntidad.ListNoMadeCENSO != null)
                {
                    foreach (var loDatos in oCEntidad.ListNoMadeCENSO)
                    {

                        oCamposDet = new CEntidad();
                        oCamposDet.COD_THABILITANTE = oCEntidad.COD_THABILITANTE;
                        oCamposDet.NUM_POA = oCEntidad.NUM_POA;
                        oCamposDet.COD_ESPECIES = loDatos.COD_ESPECIES;
                        oCamposDet.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                        oCamposDet.NUM_ESTRADA = loDatos.NUM_ESTRADA;
                        oCamposDet.CODIGO = loDatos.CODIGO;
                        oCamposDet.DIAMETRO = loDatos.DIAMETRO;
                        oCamposDet.ALTURA = loDatos.ALTURA;
                        oCamposDet.PRODUCCION_LATAS = loDatos.PRODUCCION_LATAS;
                        oCamposDet.COD_ECONDICION = loDatos.COD_ECONDICION;
                        oCamposDet.DMC = loDatos.DMC;
                        oCamposDet.COD_ECONDICION = loDatos.COD_ECONDICION;
                        oCamposDet.ZONA = loDatos.ZONA == "" ? null : loDatos.ZONA;
                        oCamposDet.COORDENADA_ESTE = loDatos.COORDENADA_ESTE;
                        oCamposDet.COORDENADA_NORTE = loDatos.COORDENADA_NORTE;
                        oCamposDet.OBSERVACION = loDatos.OBSERVACION;
                        oCamposDet.ESPECIES = loDatos.ESPECIES;
                        oCamposDet.CONDICION = loDatos.CONDICION;
                        if (loDatos.COD_ESPECIES_ARESOLUCION != "-")
                        {
                            oCamposDet.COD_ESPECIES_ARESOLUCION = loDatos.COD_ESPECIES_ARESOLUCION;
                            oCamposDet.ESPECIES_ARESOLUCION = loDatos.ESPECIES_ARESOLUCION;
                        }
                        oCamposDet.RegEstado = loDatos.RegEstado;
                        dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spPOA_DET_NOMADERABLE_CENSOGrabarV3", oCamposDet);

                    }
                }

                //Grabando Detalle POA_DET_VERTICE
                if (oCEntidad.ListVERTICE != null)
                {
                    foreach (var loDatos in oCEntidad.ListVERTICE)
                    {

                        oCamposDet = new CEntidad();
                        oCamposDet.COD_THABILITANTE = oCEntidad.COD_THABILITANTE;
                        oCamposDet.NUM_POA = oCEntidad.NUM_POA;
                        oCamposDet.VERTICE = loDatos.VERTICE;
                        oCamposDet.ZONA = loDatos.ZONA == "" ? null : loDatos.ZONA;
                        oCamposDet.COORDENADA_ESTE = loDatos.COORDENADA_ESTE;
                        oCamposDet.COORDENADA_NORTE = loDatos.COORDENADA_NORTE;
                        oCamposDet.OBSERVACION = loDatos.OBSERVACION;
                        oCamposDet.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                        oCamposDet.RegEstado = loDatos.RegEstado;
                        oCamposDet.PCA = loDatos.PCA;
                        dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spPOA_DET_VERTICEGrabar", oCamposDet);

                    }
                }
                //Grabando POA_DET_KARDEX
                if (oCEntidad.ListKARDEX != null)
                {
                    foreach (var loDatos in oCEntidad.ListKARDEX)
                    {

                        oCamposDet = new CEntidad();
                        oCamposDet.COD_THABILITANTE = oCEntidad.COD_THABILITANTE;
                        oCamposDet.NUM_POA = oCEntidad.NUM_POA;
                        oCamposDet.COD_ESPECIES = loDatos.COD_ESPECIES;
                        oCamposDet.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                        oCamposDet.FECHA_EMISIONKARDEX = loDatos.FECHA_EMISIONKARDEX;
                        oCamposDet.GUIA_TRANSPORTE = loDatos.GUIA_TRANSPORTE;
                        oCamposDet.COD_KARDEX_PRODUCTO = loDatos.COD_KARDEX_PRODUCTO;
                        oCamposDet.COD_KARDEX_DESCRIPCION = loDatos.COD_KARDEX_DESCRIPCION;
                        oCamposDet.CANTIDAD = loDatos.CANTIDAD;
                        oCamposDet.KILOGRAMOS_KARDEX = loDatos.KILOGRAMOS_KARDEX;
                        oCamposDet.M3 = loDatos.M3;
                        oCamposDet.ACUMULADO = loDatos.ACUMULADO;
                        oCamposDet.SALDO_KARDEX = loDatos.SALDO_KARDEX;
                        oCamposDet.OBSERVACION_KARDEX = loDatos.OBSERVACION_KARDEX;
                        oCamposDet.ESPECIES = loDatos.ESPECIES;
                        oCamposDet.RegEstado = loDatos.RegEstado;
                        dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spPOA_DET_KARDEXGrabarV3", oCamposDet);

                    }
                }
                //Grabando POA_DET_RDREFORMULA
                if (oCEntidad.ListRDReformulaPOA != null)
                {
                    int i = 0;
                    CEntidad oCamposPersona;
                    CEntidad oCamposEspecie;

                    foreach (var loDatos in oCEntidad.ListRDReformulaPOA)
                    {
                        oCamposDet = new CEntidad();
                        oCamposDet.COD_THABILITANTE = oCEntidad.COD_THABILITANTE;
                        oCamposDet.NUM_POA = oCEntidad.NUM_POA;
                        oCamposDet.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                        oCamposDet.ITECNICO_REFORMULA_POA_NUM = loDatos.ITECNICO_REFORMULA_POA_NUM;
                        oCamposDet.ITECNICO_REFORMULA_POA_FECHA = loDatos.ITECNICO_REFORMULA_POA_FECHA;
                        oCamposDet.COD_UCUENTA = oCEntidad.COD_UCUENTA;
                        oCamposDet.RegEstado = loDatos.RegEstado;
                        oCamposDet.OUTPUTPARAMDET01 = "";

                        using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spPOA_DET_RDREFORMULAGrabar", oCamposDet))
                        {
                            cmd.ExecuteNonQuery();
                            oCamposDet.COD_SECUENCIAL = Convert.ToInt32(cmd.Parameters["OUTPUTPARAMDET01"].Value);
                        }

                        // Grabando Detalle POA_DET_REFORMULA
                        if (oCEntidad.ListRDReformulaPOA[i].ListREFORMULAPOA != null)
                        {
                            foreach (var person in oCEntidad.ListRDReformulaPOA[i].ListREFORMULAPOA)
                            {

                                oCamposPersona = new CEntidad();
                                oCamposPersona.COD_THABILITANTE = oCEntidad.COD_THABILITANTE;
                                oCamposPersona.NUM_POA = oCEntidad.NUM_POA;
                                oCamposPersona.COD_SECUENCIAL = oCamposDet.COD_SECUENCIAL;
                                oCamposPersona.COD_PREFORMULA = person.COD_PERSONA;
                                oCamposPersona.COD_UCUENTA = oCEntidad.COD_UCUENTA;
                                dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spPOA_DET_REFORMULAGrabar", oCamposPersona);

                            }
                        }

                        //Grabando Detalle POA_DET_MADE_NOMADE_RREAAPROVECHAR
                        if (oCEntidad.ListRDReformulaPOA[i].ListRReformula != null)
                        {
                            foreach (var especie in oCEntidad.ListRDReformulaPOA[i].ListRReformula)
                            {

                                oCamposEspecie = new CEntidad();
                                oCamposEspecie.COD_THABILITANTE = oCEntidad.COD_THABILITANTE;
                                oCamposEspecie.NUM_POA = oCEntidad.NUM_POA;
                                oCamposEspecie.COD_SECUENCIAL_RDREF = oCamposDet.COD_SECUENCIAL;
                                oCamposEspecie.COD_ESPECIES = especie.COD_ESPECIES;
                                oCamposEspecie.ESPECIES = especie.ESPECIES;
                                oCamposEspecie.COD_SECUENCIAL = especie.COD_SECUENCIAL;
                                if (oCEntidad.COD_MTIPO == "0000020")
                                {
                                    oCamposEspecie.SuperficieHa = especie.SuperficieHa;
                                    oCamposEspecie.CANTIDAD = especie.CANTIDAD;
                                }
                                else if (oCEntidad.COD_MTIPO == "0000021")
                                {
                                    oCamposEspecie.ABUNDANCIA = especie.ABUNDANCIA;
                                    oCamposEspecie.NUMINDIVIDUOS = especie.NUMINDIVIDUOS;
                                    oCamposEspecie.PESO = especie.PESO;
                                    oCamposEspecie.RENDIMIENTO = especie.RENDIMIENTO;
                                    oCamposEspecie.UNIDAD_MEDIDA = especie.UNIDAD_MEDIDA;
                                }
                                else
                                {
                                    oCamposEspecie.NUM_ARBOLES = especie.NUM_ARBOLES;
                                    oCamposEspecie.VOLUMEN_KILOGRAMOS = especie.VOLUMEN_KILOGRAMOS;
                                    oCamposEspecie.TIPOMADERABLE = especie.TIPOMADERABLE;
                                }
                                if (especie.COD_ESPECIES_SERFOR != "-")
                                {
                                    oCamposEspecie.COD_ESPECIES_SERFOR = especie.COD_ESPECIES_SERFOR;
                                    oCamposEspecie.ESPECIES_SERFOR = especie.ESPECIES_SERFOR;
                                }
                                oCamposEspecie.OBSERVACION = especie.OBSERVACION;
                                oCamposEspecie.COD_UCUENTA = oCEntidad.COD_UCUENTA;
                                oCamposEspecie.RegEstado = especie.RegEstado;
                                dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spPOA_DET_MADE_NOMADE_RREAAPROVECHARGrabar", oCamposEspecie);

                            }
                        }
                        i++;
                    }
                }
                //Grabando POA_DET_BEXTRACCION
                if (oCEntidad.ListBExtPOA != null)
                {
                    int i = 0;
                    CEntidad oCamposBExtMade;
                    CEntidad oCamposBExtNoMade;
                    CEntidad oCamposBEInSitu;

                    foreach (var loDatos in oCEntidad.ListBExtPOA)
                    {
                        oCamposDet = new CEntidad();
                        oCamposDet.COD_THABILITANTE = oCEntidad.COD_THABILITANTE;
                        oCamposDet.NUM_POA = oCEntidad.NUM_POA;
                        oCamposDet.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                        oCamposDet.BEXTRACCION_FEMISION = loDatos.BEXTRACCION_FEMISION;
                        oCamposDet.COD_UCUENTA = oCEntidad.COD_UCUENTA;
                        oCamposDet.RegEstado = loDatos.RegEstado;
                        oCamposDet.OUTPUTPARAMDET01 = " ";

                        using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spPOA_DET_BEXTRACCIONGrabar", oCamposDet))
                        {
                            cmd.ExecuteNonQuery();
                            oCamposDet.COD_SECUENCIAL = Convert.ToInt32(cmd.Parameters["OUTPUTPARAMDET01"].Value);
                        }

                        //Grabando Detalle POA_DET_MADERABLE_BEXTRACCION
                        if (oCEntidad.ListBExtPOA[i].ListMadeBEXTRACCION != null)
                        {
                            foreach (var made in oCEntidad.ListBExtPOA[i].ListMadeBEXTRACCION)
                            {
                                oCamposBExtMade = new CEntidad();
                                oCamposBExtMade.COD_THABILITANTE = oCEntidad.COD_THABILITANTE;
                                oCamposBExtMade.NUM_POA = oCEntidad.NUM_POA;
                                oCamposBExtMade.COD_SECUENCIAL_BEXT = oCamposDet.COD_SECUENCIAL;
                                oCamposBExtMade.COD_ESPECIES = made.COD_ESPECIES;
                                oCamposBExtMade.COD_SECUENCIAL = made.COD_SECUENCIAL;
                                oCamposBExtMade.DMC = made.DMC;//Maderable
                                oCamposBExtMade.TOTAL_ARBOLES = made.TOTAL_ARBOLES;//Maderable
                                oCamposBExtMade.VOLUMEN_AUTORIZADO = made.VOLUMEN_AUTORIZADO;
                                oCamposBExtMade.VOLUMEN_MOVILIZADO = made.VOLUMEN_MOVILIZADO;
                                oCamposBExtMade.AUTORIZADO = made.AUTORIZADO;//No Maderable
                                oCamposBExtMade.EXTRAIDO = made.EXTRAIDO;//No Maderable
                                oCamposBExtMade.FECHA1 = made.FECHA1;//No Maderable
                                oCamposBExtMade.FECHA2 = made.FECHA2;//No Maderable
                                oCamposBExtMade.CANTIDAD = made.CANTIDAD;//No Maderable
                                oCamposBExtMade.GUIA_TRANSPORTE = made.GUIA_TRANSPORTE;//No Maderable
                                oCamposBExtMade.RECIBO = made.RECIBO;//No Maderable
                                oCamposBExtMade.SALDO = made.SALDO;
                                oCamposBExtMade.UNIDAD_MEDIDA = made.UNIDAD_MEDIDA;
                                oCamposBExtMade.OBSERVACION = made.OBSERVACION;
                                oCamposBExtMade.ESPECIES = made.ESPECIES;
                                oCamposBExtMade.TIPOMADERABLE = made.TIPOMADERABLE;//Maderable
                                if (made.COD_ESPECIES_SERFOR != "-")
                                {
                                    oCamposBExtMade.COD_ESPECIES_SERFOR = made.COD_ESPECIES_SERFOR;
                                    oCamposBExtMade.ESPECIES_SERFOR = made.ESPECIES_SERFOR;
                                }
                                oCamposBExtMade.COD_UCUENTA = oCEntidad.COD_UCUENTA;
                                oCamposBExtMade.RegEstado = made.RegEstado;
                                oCamposBExtMade.PCA = made.PCA;
                                dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spPOA_DET_MADERABLE_BEXTRACCIONGrabarV3", oCamposBExtMade);

                            }
                        }

                        //Grabando Detalle POA_DET_NOMADERABLE_BEXTRACCION
                        if (oCEntidad.ListBExtPOA[i].ListNoMadeBEXTRACCION != null)
                        {
                            foreach (var nomade in oCEntidad.ListBExtPOA[i].ListNoMadeBEXTRACCION)
                            {

                                oCamposBExtNoMade = new CEntidad();
                                oCamposBExtNoMade.COD_THABILITANTE = oCEntidad.COD_THABILITANTE;
                                oCamposBExtNoMade.NUM_POA = oCEntidad.NUM_POA;
                                oCamposBExtNoMade.COD_SECUENCIAL_BEXT = oCamposDet.COD_SECUENCIAL;
                                oCamposBExtNoMade.COD_ESPECIES = nomade.COD_ESPECIES;
                                oCamposBExtNoMade.COD_SECUENCIAL = nomade.COD_SECUENCIAL;
                                oCamposBExtNoMade.OBSERVACION = nomade.OBSERVACION;
                                oCamposBExtNoMade.ESPECIES = nomade.ESPECIES;

                                if (oCEntidad.COD_MTIPO == "0000020")
                                {
                                    oCamposBExtNoMade.FECHA1 = nomade.FECHA1;
                                    oCamposBExtNoMade.FECHA2 = nomade.FECHA2;
                                    oCamposBExtNoMade.SALDO = nomade.SALDO;
                                    oCamposBExtNoMade.CANTIDAD = nomade.CANTIDAD;
                                    oCamposBExtNoMade.GUIA_TRANSPORTE = nomade.GUIA_TRANSPORTE;
                                    oCamposBExtNoMade.RECIBO = nomade.RECIBO;
                                }
                                else if (oCEntidad.COD_MTIPO == "0000021")
                                {
                                    oCamposBExtNoMade.UNIDAD_MEDIDA = nomade.UNIDAD_MEDIDA;
                                    oCamposBExtNoMade.AUTORIZADO = nomade.AUTORIZADO;
                                    oCamposBExtNoMade.EXTRAIDO = nomade.EXTRAIDO;
                                    oCamposBExtNoMade.SALDO = nomade.SALDO;
                                }
                                else
                                {
                                    oCamposBExtNoMade.KILOGRAMO_AUTORIZADO = nomade.KILOGRAMO_AUTORIZADO;
                                    oCamposBExtNoMade.KILOGRAMO_MOVILIZADO = nomade.KILOGRAMO_MOVILIZADO;
                                    oCamposBExtNoMade.SALDO = nomade.SALDO;
                                    oCamposBExtNoMade.UNIDAD_MEDIDA = nomade.UNIDAD_MEDIDA;
                                }
                                if (nomade.COD_ESPECIES_SERFOR != "-")
                                {
                                    oCamposBExtNoMade.COD_ESPECIES_SERFOR = nomade.COD_ESPECIES_SERFOR;
                                    oCamposBExtNoMade.ESPECIES_SERFOR = nomade.ESPECIES_SERFOR;
                                }
                                oCamposBExtNoMade.COD_UCUENTA = oCEntidad.COD_UCUENTA;
                                oCamposBExtNoMade.RegEstado = nomade.RegEstado;
                                dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spPOA_DET_NOMADERABLE_BEXTRACCIONGrabarV3", oCamposBExtNoMade);


                            }
                        }

                        //Grabando Detalle POA_INSITU_DET_BEXTRACCION
                        if (oCEntidad.ListBExtPOA[i].ListISituBEXTRACCION != null)
                        {
                            foreach (var insitu in oCEntidad.ListBExtPOA[i].ListISituBEXTRACCION)
                            {

                                oCamposBEInSitu = new CEntidad();
                                oCamposBEInSitu.COD_THABILITANTE = oCEntidad.COD_THABILITANTE;
                                oCamposBEInSitu.NUM_POA = oCEntidad.NUM_POA;
                                oCamposBEInSitu.COD_SECUENCIAL_BEXT = oCamposDet.COD_SECUENCIAL;
                                oCamposBEInSitu.COD_ESPECIES = insitu.COD_ESPECIES;
                                oCamposBEInSitu.COD_SECUENCIAL = insitu.COD_SECUENCIAL;
                                oCamposBEInSitu.CANTIDAD_AUTORIZADO = insitu.CANTIDAD_AUTORIZADO;
                                oCamposBEInSitu.CANTIDAD_MOVILIZADO = insitu.CANTIDAD_MOVILIZADO;
                                oCamposBEInSitu.SALDO = insitu.SALDO;
                                oCamposBEInSitu.OBSERVACION = insitu.OBSERVACION;
                                oCamposBEInSitu.ESPECIES = insitu.ESPECIES;
                                if (insitu.COD_ESPECIES_SERFOR != "-")
                                {
                                    oCamposBEInSitu.COD_ESPECIES_SERFOR = insitu.COD_ESPECIES_SERFOR;
                                    oCamposBEInSitu.ESPECIES_SERFOR = insitu.ESPECIES_SERFOR;
                                }
                                oCamposBEInSitu.RegEstado = insitu.RegEstado;
                                dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spPOA_INSITU_DET_BEXTRACCIONGrabarV3", oCamposBEInSitu);

                            }
                        }
                        i++;
                    }
                }

                //Registrar Error Material
                if (oCEntidad.ListPOAErrorMaterialG != null)
                {
                    Ent_ERRORMATERIAL oCampos;

                    foreach (var loDatos in oCEntidad.ListPOAErrorMaterialG)
                    {
                        if (loDatos.COD_SECUENCIAL == -1)
                        {
                            oCampos = new Ent_ERRORMATERIAL();
                            oCampos.COD_THABILITANTE = oCEntidad.COD_THABILITANTE;
                            oCampos.NUM_POA = oCEntidad.NUM_POA;
                            oCampos.NV_TIPO = loDatos.NV_TIPO;
                            oCampos.NV_RESOLUCION = loDatos.NV_RESOLUCION;
                            oCampos.DA_FECRESOLUCION = loDatos.DA_FECRESOLUCION;
                            oCampos.NV_NOMCAMPO = loDatos.NV_NOMCAMPO;
                            oCampos.NV_VALANTERIOR = loDatos.NV_VALANTERIOR;
                            oCampos.NV_VALACTUAL = loDatos.NV_VALACTUAL;
                            oCampos.NV_OBSERVACION = loDatos.NV_OBSERVACION;
                            oCampos.COD_UCUENTA = oCEntidad.COD_UCUENTA;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spPOA_ERROR_MATERIAL_Grabar", oCampos);
                        }
                    }
                }

                if (oCEntidad.ListPOAErrorMaterialA != null)
                {
                    Ent_ERRORMATERIAL oCampos;

                    foreach (var loDatos in oCEntidad.ListPOAErrorMaterialA)
                    {
                        if (loDatos.COD_SECUENCIAL == -1)
                        {
                            oCampos = new Ent_ERRORMATERIAL();
                            oCampos.COD_THABILITANTE = oCEntidad.COD_THABILITANTE;
                            oCampos.NUM_POA = oCEntidad.NUM_POA;
                            oCampos.NV_TIPO = loDatos.NV_TIPO;
                            oCampos.NV_RESOLUCION = loDatos.NV_RESOLUCION;
                            oCampos.DA_FECRESOLUCION = loDatos.DA_FECRESOLUCION;
                            oCampos.NV_NOMCAMPO = loDatos.NV_NOMCAMPO;
                            oCampos.NV_VALANTERIOR = loDatos.NV_VALANTERIOR;
                            oCampos.NV_VALACTUAL = loDatos.NV_VALACTUAL;
                            oCampos.NV_OBSERVACION = loDatos.NV_OBSERVACION;
                            oCampos.COD_UCUENTA = oCEntidad.COD_UCUENTA;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spPOA_ERROR_MATERIAL_Grabar", oCampos);
                        }
                    }
                }


                //07/05/2021
                if (oCEntidad.ListEliTABLAParcela != null)
                {
                    foreach (var loDatos in oCEntidad.ListEliTABLAParcela)
                    {
                        oCamposDet = new CEntidad();
                        oCamposDet.COD_THABILITANTE = oCEntidad.COD_THABILITANTE;
                        oCamposDet.NUM_POA = oCEntidad.NUM_POA;
                        oCamposDet.EliTABLA = loDatos.EliTABLA;
                        oCamposDet.EliVALOR01 = loDatos.EliVALOR01;
                        oCamposDet.EliVALOR02 = loDatos.EliVALOR02;
                        dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spPOAEliminarDetalle", oCamposDet);
                    }
                }
                //return OUTPUTPARAM02;
                //se cambia para que devuelva la numeracion del poa
                return OUTPUTPARAM02;
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
        public Int32 RegEliminar(OracleConnection cn, CEntidad oCEntidad)
        {
            try
            {
                Int32 RegNum = dBOracle.ManExecute(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spPOAEliminar", oCEntidad);
                if (RegNum == -1)
                {
                    throw new Exception("No se logró realizar la operación");
                }
                return RegNum;
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
        public CEntidad RegMostCombo(OracleConnection cn, CEntidad oCEntidad)
        {
            CEntidad oCampos = null;
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spGeneral_Combo_Listar", oCEntidad))
                {
                    if (dr != null)
                    {
                        oCampos = new CEntidad();
                        List<CEntidad> lsDetDetalle;
                        CEntidad oCamposDet;
                        //
                        //Bio Seguridad
                        lsDetDetalle = new List<CEntidad>();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.CODIGO = dr["CODIGO"].ToString();
                                oCamposDet.DESCRIPCION = dr["DESCRIPCION"].ToString();
                                lsDetDetalle.Add(oCamposDet);
                            }
                        }
                        oCampos.ListMComboBSeguridad = lsDetDetalle;
                        //
                        //Documento de Identidad
                        dr.NextResult();
                        lsDetDetalle = new List<CEntidad>();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.CODIGO = dr["CODIGO"].ToString();
                                oCamposDet.DESCRIPCION = dr["DESCRIPCION"].ToString();
                                lsDetDetalle.Add(oCamposDet);
                            }
                        }
                        oCampos.ListMComboDIdentidad = lsDetDetalle;
                        //
                        //Especie Condicion
                        dr.NextResult();
                        lsDetDetalle = new List<CEntidad>();
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("CODIGO");
                            int pt2 = dr.GetOrdinal("DESCRIPCION");
                            int pt3 = dr.GetOrdinal("MADERABLE");
                            int pt4 = dr.GetOrdinal("NO_MADERABLE");
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.CODIGO = dr.GetString(pt1);
                                oCamposDet.DESCRIPCION = dr.GetString(pt2);
                                oCamposDet.MADERABLE = dr.GetBoolean(pt3);
                                oCamposDet.NO_MADERABLE = dr.GetBoolean(pt4);
                                lsDetDetalle.Add(oCamposDet);
                            }
                        }
                        oCampos.ListMComboEspeciesCondicion = lsDetDetalle;
                        //
                        //Especie Estado
                        dr.NextResult();
                        lsDetDetalle = new List<CEntidad>();
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("CODIGO");
                            int pt2 = dr.GetOrdinal("DESCRIPCION");
                            int pt3 = dr.GetOrdinal("MADERABLE");
                            int pt4 = dr.GetOrdinal("NO_MADERABLE");
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.CODIGO = dr.GetString(pt1);
                                oCamposDet.DESCRIPCION = dr.GetString(pt2);
                                oCamposDet.MADERABLE = dr.GetBoolean(pt3);
                                oCamposDet.NO_MADERABLE = dr.GetBoolean(pt4);
                                lsDetDetalle.Add(oCamposDet);
                            }
                        }
                        oCampos.ListMComboEspeciesEstado = lsDetDetalle;
                        //Estado del poa
                        dr.NextResult();
                        lsDetDetalle = new List<CEntidad>();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.CODIGO = dr["CODIGO"].ToString();
                                oCamposDet.DESCRIPCION = dr["DESCRIPCION"].ToString();
                                lsDetDetalle.Add(oCamposDet);
                            }
                        }
                        oCampos.ListIndicador = lsDetDetalle;

                        // listado kardex Producto

                        dr.NextResult();
                        lsDetDetalle = new List<CEntidad>();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.CODIGO = dr["CODIGO"].ToString();
                                oCamposDet.DESCRIPCION = dr["DESCRIPCION"].ToString();
                                lsDetDetalle.Add(oCamposDet);
                            }
                        }
                        oCampos.ListKARDEXPRODUCTO = lsDetDetalle;

                        // Listado Kardex descripcion

                        dr.NextResult();
                        lsDetDetalle = new List<CEntidad>();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.CODIGO = dr["CODIGO"].ToString();
                                oCamposDet.DESCRIPCION = dr["DESCRIPCION"].ToString();
                                lsDetDetalle.Add(oCamposDet);
                            }
                        }
                        oCampos.ListKARDEXDESCRIPCION = lsDetDetalle;
                        //Oficinas Desconcentradas
                        dr.NextResult();
                        lsDetDetalle = new List<CEntidad>();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.CODIGO = dr["CODIGO"].ToString();
                                oCamposDet.DESCRIPCION = dr["DESCRIPCION"].ToString();
                                lsDetDetalle.Add(oCamposDet);
                            }
                        }
                        oCampos.ListODs = lsDetDetalle;
                        //Especies
                        dr.NextResult();
                        lsDetDetalle = new List<CEntidad>();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.CODIGO = dr["CODIGO"].ToString();
                                oCamposDet.DESCRIPCION = dr["DESCRIPCION"].ToString();
                                lsDetDetalle.Add(oCamposDet);
                            }
                        }
                        oCampos.ListMComboEspecies = lsDetDetalle;
                        //Especies Resolución serfor
                        dr.NextResult();
                        lsDetDetalle = new List<CEntidad>();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.CODIGO = dr["CODIGO"].ToString();
                                oCamposDet.DESCRIPCION = dr["DESCRIPCION"].ToString();
                                lsDetDetalle.Add(oCamposDet);
                            }
                        }
                        oCampos.ListMComboEspeciesSerfor = lsDetDetalle;
                        //Parcelas
                        dr.NextResult();
                        lsDetDetalle = new List<CEntidad>();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.CODIGO = dr["CODIGO"].ToString();
                                oCamposDet.DESCRIPCION = dr["DESCRIPCION"].ToString();
                                lsDetDetalle.Add(oCamposDet);
                            }
                        }
                        oCampos.ListParcela = lsDetDetalle;
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
        /// Retorna la tabla de Censo Maderable y No Maderable
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad">Se pasan los parametros COD_THABILITANTE y NUM_POA</param>
        /// <returns></returns>
        public CEntidad RegMostItemsHijoMadNoMad(OracleConnection cn, CEntidad oCEntidad)
        {
            CEntidad oCampos = new CEntidad();
            oCampos.ListHijoMadeCENSO = new List<CEntidad>();
            oCampos.ListHijoNoMadeCENSO = new List<CEntidad>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spPOAMostItemsMadNoMad", oCEntidad))
                {
                    if (dr != null)
                    {
                        CEntidad oCamposDet;
                        //POA_DET_MADERABLE_CENSO_HIJO
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("COD_ESPECIES");
                            int pt2 = dr.GetOrdinal("COD_SECUENCIAL");
                            int pt3 = dr.GetOrdinal("COD_ECONDICION");
                            int pt4 = dr.GetOrdinal("COD_EESTADO");
                            int pt5 = dr.GetOrdinal("ESPECIES");
                            int pt6 = dr.GetOrdinal("BLOQUE");
                            int pt7 = dr.GetOrdinal("FAJA");
                            int pt8 = dr.GetOrdinal("CODIGO");
                            //int pt9 = dr.GetOrdinal("VOLUMEN");
                            //int pt10 = dr.GetOrdinal("DAP");
                            //int pt11 = dr.GetOrdinal("AC");
                            int pt12 = dr.GetOrdinal("DMC");
                            int pt13 = dr.GetOrdinal("COORDENADA_ESTE");
                            int pt14 = dr.GetOrdinal("COORDENADA_NORTE");
                            int pt15 = dr.GetOrdinal("OBSERVACION");
                            int pt16 = dr.GetOrdinal("ESTADO_MUESTRA");
                            int pt17 = dr.GetOrdinal("CONDICION");
                            int pt18 = dr.GetOrdinal("ESTADO");
                            int pt19 = dr.GetOrdinal("NUM_POA_REING");
                            int pt20 = dr.GetOrdinal("COD_SECUENCIAL_REING");
                            Int32 num_fila = 0;
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.NUMERO_FILA = num_fila;
                                oCamposDet.COD_ESPECIES = dr.GetString(pt1);
                                oCamposDet.COD_SECUENCIAL = dr.GetInt32(pt2);
                                oCamposDet.COD_ECONDICION = dr.GetString(pt3);
                                oCamposDet.COD_EESTADO = dr.GetString(pt4);
                                oCamposDet.ESPECIES = dr.GetString(pt5);
                                oCamposDet.BLOQUE = dr.GetString(pt6);
                                oCamposDet.FAJA = dr.GetString(pt7);
                                oCamposDet.CODIGO = dr.GetString(pt8);
                                oCamposDet.VOLUMEN = dr.GetDecimal(dr.GetOrdinal("VOLUMEN")); // Decimal.Parse(dr.GetString(pt9));
                                oCamposDet.DAP = dr.GetDecimal(dr.GetOrdinal("DAP")); // Decimal.Parse(dr.GetString(pt10));
                                oCamposDet.AC = dr.GetDecimal(dr.GetOrdinal("AC")); // Decimal.Parse(dr.GetString(pt11));
                                oCamposDet.DMC = dr.GetInt32(pt12);
                                oCamposDet.COORDENADA_ESTE = dr.GetInt32(pt13);
                                oCamposDet.COORDENADA_NORTE = dr.GetInt32(pt14);
                                oCamposDet.OBSERVACION = dr.GetString(pt15);
                                oCamposDet.ESTADO_MUESTRA = dr.GetBoolean(pt16);
                                oCamposDet.CONDICION = dr.GetString(pt17);
                                oCamposDet.ESTADO = dr.GetString(pt18);
                                if (dr.IsDBNull(pt19))
                                { oCamposDet.NUM_POA_REING = 0; }
                                else { oCamposDet.NUM_POA_REING = dr.GetInt32(pt19); }
                                if (dr.IsDBNull(pt20))
                                { oCamposDet.COD_SECUENCIAL_REING = 0; }
                                else { oCamposDet.COD_SECUENCIAL_REING = dr.GetInt32(pt20); }
                                oCamposDet.RegEstado = 0;
                                oCampos.ListHijoMadeCENSO.Add(oCamposDet);
                                num_fila++;
                            }
                        }
                        //POA_DET_NOMADERABLE_CENSO_HIJO
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("COD_ESPECIES");
                            int pt2 = dr.GetOrdinal("COD_SECUENCIAL");
                            int pt3 = dr.GetOrdinal("COD_ECONDICION");
                            int pt4 = dr.GetOrdinal("ESPECIES");
                            int pt5 = dr.GetOrdinal("NUM_ESTRADA");
                            int pt6 = dr.GetOrdinal("CODIGO");
                            //int pt7 = dr.GetOrdinal("DIAMETRO");
                            //int pt8 = dr.GetOrdinal("ALTURA");
                            //int pt9 = dr.GetOrdinal("PRODUCCION_LATAS");
                            int pt10 = dr.GetOrdinal("COORDENADA_ESTE");
                            int pt11 = dr.GetOrdinal("COORDENADA_NORTE");
                            int pt12 = dr.GetOrdinal("ESTADO_MUESTRA");
                            int pt13 = dr.GetOrdinal("OBSERVACION");
                            int pt14 = dr.GetOrdinal("CONDICION");
                            int pt15 = dr.GetOrdinal("NUM_POA_REING");
                            int pt16 = dr.GetOrdinal("COD_SECUENCIAL_REING");
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.COD_ESPECIES = dr.GetString(pt1);
                                oCamposDet.COD_SECUENCIAL = dr.GetInt32(pt2);
                                oCamposDet.COD_ECONDICION = dr.GetString(pt3);
                                oCamposDet.ESPECIES = dr.GetString(pt4);
                                oCamposDet.NUM_ESTRADA = dr.GetString(pt5);
                                oCamposDet.CODIGO = dr.GetString(pt6);
                                oCamposDet.DIAMETRO = dr.GetDecimal(dr.GetOrdinal("DIAMETRO"));
                                oCamposDet.ALTURA = dr.GetDecimal(dr.GetOrdinal("ALTURA"));
                                oCamposDet.PRODUCCION_LATAS = dr.GetDecimal(dr.GetOrdinal("PRODUCCION_LATAS"));
                                //oCamposDet.DIAMETRO = Decimal.Parse(dr.GetString(pt7));
                                //oCamposDet.ALTURA = Decimal.Parse(dr.GetString(pt8));
                                //oCamposDet.PRODUCCION_LATAS = Decimal.Parse(dr.GetString(pt9));
                                oCamposDet.COORDENADA_ESTE = dr.GetInt32(pt10);
                                oCamposDet.COORDENADA_NORTE = dr.GetInt32(pt11);
                                oCamposDet.ESTADO_MUESTRA = dr.GetBoolean(pt12);
                                oCamposDet.OBSERVACION = dr.GetString(pt13);
                                oCamposDet.CONDICION = dr.GetString(pt14);
                                if (dr.IsDBNull(pt15))
                                { oCamposDet.NUM_POA_REING = 0; }
                                else { oCamposDet.NUM_POA_REING = dr.GetInt32(pt15); }
                                if (dr.IsDBNull(pt16))
                                { oCamposDet.COD_SECUENCIAL_REING = 0; }
                                else { oCamposDet.COD_SECUENCIAL_REING = dr.GetInt32(pt16); }
                                oCamposDet.RegEstado = 0;
                                oCampos.ListHijoNoMadeCENSO.Add(oCamposDet);
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        //public List<CEntidad> RegNuevoBuscar(SqlConnection cn, CEntidad oCEntidad)
        //{
        //    List<CEntidad> lsCEntidad = new List<CEntidad>();
        //    try
        //    {
        //        using (SqlDataReader dr = oGDataSQL.SelDrdResult(cn, null, "DOC.spGeneral_Listar", oCEntidad))
        //        {
        //            if (dr != null)
        //            {
        //                if (dr.HasRows)
        //                {
        //                    int p1 = dr.GetOrdinal("COD_THABILITANTE");
        //                    int p2 = dr.GetOrdinal("MODALIDAD");
        //                    int p3 = dr.GetOrdinal("NUM_THABILITANTE");
        //                    int p4 = dr.GetOrdinal("PERSONA");
        //                    int p5 = dr.GetOrdinal("INDICADOR");
        //                    int p6 = dr.GetOrdinal("COD_MTIPO");
        //                    int p7 = dr.GetOrdinal("COD_UBIDEPARTAMENTO");
        //                    int p8 = dr.GetOrdinal("ESTADO_ORIGEN");
        //                    CEntidad oCampos;
        //                    while (dr.Read())
        //                    {
        //                        oCampos = new CEntidad();
        //                        oCampos.COD_THABILITANTE = dr.GetString(p1);
        //                        oCampos.MODALIDAD = dr.GetString(p2);
        //                        oCampos.NUM_THABILITANTE = dr.GetString(p3);
        //                        oCampos.PERSONA = dr.GetString(p4);
        //                        oCampos.INDICADOR = dr.GetString(p5);
        //                        oCampos.COD_MTIPO = dr.GetString(p6);
        //                        oCampos.COD_UBIDEPARTAMENTO = dr.GetString(p7);
        //                        oCampos.ESTADO_ORIGEN = dr.GetString(p8);
        //                        lsCEntidad.Add(oCampos);
        //                    }
        //                }
        //                else
        //                {
        //                    throw new Exception("( 0 ) Registros Encontrados");
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
        public List<CEntidad> Temp_Validar_Especie(OracleConnection cn, CEntidad oCEntidad)
        {
            String OUTPUTPARAM01 = "";
            List<CEntidad> LISTADO_PRUEBA = new List<CEntidad>();
            CEntidad campo;
            try
            {
                for (Int32 i = 0; i < oCEntidad.ListEliTABLA.Count; i++)
                {
                    campo = new CEntidad();
                    campo.DESCRIPCION = oCEntidad.ListEliTABLA[i].DESCRIPCION;
                    campo.OUTPUTPARAM01 = "";
                    using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, null, "DOC_OSINFOR_ERP_MIGRACION.TEMP_VALIDAR_ESPECIE", campo))
                    {
                        cmd.ExecuteNonQuery();
                        OUTPUTPARAM01 = (String)cmd.Parameters["OUTPUTPARAM01"].Value;
                        if (OUTPUTPARAM01 == "2")
                        {
                            campo.COD_SECUENCIAL = i + 1;
                            LISTADO_PRUEBA.Add(campo);
                        }
                    }
                }
                return LISTADO_PRUEBA;
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
        public CEntidad Temp_Validar2_Especie(OracleConnection cn, CEntidad oCEntidad)
        {
            CEntidad campo;
            try
            {

                campo = new CEntidad();
                campo.DESCRIPCION = oCEntidad.DESCRIPCION;
                campo.OUTPUTPARAM01 = "";
                ////DCM

                using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, null, "DOC_OSINFOR_ERP_MIGRACION.TEMP_VALIDAR_ESPECIE", campo))
                {
                    cmd.ExecuteNonQuery();
                    campo.OUTPUTPARAM01 = (String)cmd.Parameters["OUTPUTPARAM01"].Value;
                }
                return campo;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        /// <summary>
        /// Revisar Simplificación
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public List<CEntPersona> MostTOcularitem(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntPersona> lsCEntidad = new List<CEntPersona>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spPOAMostItemsTOcularmod", oCEntidad))
                {
                    if (dr != null)
                    {
                        CEntPersona oCampos;
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("COD_PERSONA");
                            int pt2 = dr.GetOrdinal("APE_PATERNO");
                            int pt3 = dr.GetOrdinal("APE_MATERNO");
                            int pt4 = dr.GetOrdinal("NOMBRES");
                            int pt5 = dr.GetOrdinal("COD_DIDENTIDAD");
                            int pt6 = dr.GetOrdinal("N_DOCUMENTO");
                            int pt7 = dr.GetOrdinal("CARGO");

                            while (dr.Read())
                            {
                                oCampos = new CEntPersona();
                                oCampos.COD_PERSONA = dr.GetString(pt1);
                                oCampos.APE_PATERNO = dr.GetString(pt2);
                                oCampos.APE_MATERNO = dr.GetString(pt3);
                                oCampos.NOMBRES = dr.GetString(pt4);
                                oCampos.COD_DIDENTIDAD = dr.GetString(pt5);
                                oCampos.N_DOCUMENTO = dr.GetString(pt6);
                                oCampos.CARGO = dr.GetString(pt7);
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
        /// Vertice Poa
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public List<CEntidad> listVertice(OracleConnection cn, CEntidad oCEntidad)
        {
            CEntidad oCampos = new CEntidad();
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.[spPOAVertice]", oCEntidad))
                {
                    if (dr != null)
                    {

                        if (dr.HasRows)
                        {

                            CEntidad oCamposDet;
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.VERTICE = dr["VERTICE"].ToString();
                                oCamposDet.ZONA = dr["ZONA"].ToString();
                                oCamposDet.COORDENADA_ESTE = Int32.Parse(dr["COORDENADA_ESTE"].ToString());
                                oCamposDet.COORDENADA_NORTE = Int32.Parse(dr["COORDENADA_NORTE"].ToString());
                                oCamposDet.OBSERVACION = dr["OBSERVACION"].ToString();
                                oCamposDet.COD_SECUENCIAL = Int32.Parse(dr["COD_SECUENCIAL"].ToString());
                                oCamposDet.RegEstado = 0;
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
        public List<CEntidad> listRAPoa(OracleConnection cn, CEntidad oCEntidad)
        {
            CEntidad oCampos = new CEntidad();
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.[spPOAVertice]", oCEntidad))
                {
                    if (dr != null)
                    {

                        if (dr.HasRows)
                        {

                            CEntidad oCamposDet;
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.VERTICE = dr["VERTICE"].ToString();
                                oCamposDet.ZONA = dr["ZONA"].ToString();
                                oCamposDet.COORDENADA_ESTE = Int32.Parse(dr["COORDENADA_ESTE"].ToString());
                                oCamposDet.COORDENADA_NORTE = Int32.Parse(dr["COORDENADA_NORTE"].ToString());
                                oCamposDet.OBSERVACION = dr["OBSERVACION"].ToString();
                                oCamposDet.COD_SECUENCIAL = Int32.Parse(dr["COD_SECUENCIAL"].ToString());
                                oCamposDet.RegEstado = 0;
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

        public bool Temp_Validad_CodSistema(OracleConnection cn, string asCodSistema)
        {
            bool result = false;

            try
            {
                CEntidad oParams = new CEntidad() { CODIGO = asCodSistema, OUTPUTPARAM01 = "" };

                using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, null, "DOC_OSINFOR_ERP_MIGRACION.TEMP_VALIDAR_CODSISTEMA", oParams))
                {
                    cmd.ExecuteNonQuery();
                    result = (string)cmd.Parameters["OUTPUTPARAM01"].Value == "1" ? true : false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }
        public void setArchivoDetRegenete(OracleConnection cn, Ent_Persona entP,string name)
        {
            CEntidad oCamposDet;
            try
            {
                oCamposDet = new CEntidad();
                oCamposDet.COD_PERSONA = entP.COD_PERSONA;
                oCamposDet.COD_SECUENCIAL = entP.COD_SECUENCIAL;
                oCamposDet.NOMBRE_ARCH = name;
                dBOracle.ManExecute(cn, null, "DOC_OSINFOR_ERP_MIGRACION.SPPOA_DET_REGENTEUPDATE", oCamposDet);
                
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
