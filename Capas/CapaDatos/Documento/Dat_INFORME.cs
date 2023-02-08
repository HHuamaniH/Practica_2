using CapaEntidad.DOC;
using CapaEntidad.ViewModel.DOC;
using GeneralSQL;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
//using System.Data.SqlClient;
using System.Linq;
using CEntidad = CapaEntidad.DOC.Ent_INFORME;
using CEntISExsitu = CapaEntidad.DOC.Ent_ISUPERVISION_EXSITU_INFRA_AREA;
using CEntPersona = CapaEntidad.DOC.Ent_GENEPERSONA;
//using SQL = GeneralSQL.Data.SQL;

/*************************************************************************************
-- Procedimiento    :       DatosSemillero
-- Linea                  :       13994
----------------------------------------------------------------------------------------------------
-- Fec.Actualización                       : 08/01/2021
-- Responsable                              : Ernesto Llanos
-- Motivo                                      : Cambio de la forma de captura
**************************************************************************************/

namespace CapaDatos.DOC
{
    /// <summary>
    /// DEMO DEMO
    /// </summary>
    public class Dat_INFORME
    {
        //private SQL oGDataSQL = new SQL();
        private DBOracle dBOracle = new DBOracle();
        //LISTADO DE THABILITANTE VS CNOTIFICACION
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public List<CEntidad> RegMostrarCNotif_vs_THabilit_Bucar(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spGeneral_Listar", oCEntidad))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            int p1 = dr.GetOrdinal("COD_THABILITANTE");
                            int p3 = dr.GetOrdinal("MODALIDAD_TIPO");
                            int p4 = dr.GetOrdinal("COD_MTIPO");
                            int p5 = dr.GetOrdinal("NUM_THABILITANTE");
                            int p6 = dr.GetOrdinal("NUM_CNOTIFICACION");
                            int p7 = dr.GetOrdinal("COD_CNOTIFICACION");
                            int p8 = dr.GetOrdinal("DESCRIPCION");
                            int p9 = dr.GetOrdinal("THABILITANTE_SECTOR");
                            int p10 = dr.GetOrdinal("POA");
                            CEntidad oCampos;
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                oCampos.COD_THABILITANTE = dr.GetString(p1);
                                oCampos.MODALIDAD_TIPO = dr.GetString(p3);
                                oCampos.COD_MTIPO = dr.GetString(p4);
                                oCampos.NUM_THABILITANTE = dr.GetString(p5);
                                oCampos.NUM_CNOTIFICACION = dr.GetString(p6);
                                oCampos.COD_CNOTIFICACION = dr.GetString(p7);
                                oCampos.DESCRIPCION = dr.GetString(p8);
                                oCampos.THABILITANTE_SECTOR = dr.GetString(p9);
                                oCampos.POA = dr.GetString(p10);
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
        //
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
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.SPGENERAL_COMBO_LISTAR_INFORME", oCEntidad))
                {
                    if (dr != null)
                    {
                        oCampos = new CEntidad();
                        List<CEntidad> lsDetDetalle;
                        CEntidad oCamposDet;
                        //Documento Identidad
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

                        //Supervision Concepto
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
                        oCampos.ListMComboPSuperConcepto = lsDetDetalle;
                        //Supervision Motivo
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
                        oCampos.ListISupervision_Motivo = lsDetDetalle;
                        //ESPECIES CONDICION
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
                        oCampos.ListEspeciesCondicion = lsDetDetalle;
                        //Especie Det Datos
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
                        oCampos.ListEspeciesDetDatos = lsDetDetalle;
                        //Especie Estado
                        dr.NextResult();
                        lsDetDetalle = new List<CEntidad>();
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("CODIGO");
                            int pt2 = dr.GetOrdinal("DESCRIPCION");
                            int pt3 = dr.GetOrdinal("MADERABLE");
                            int pt4 = dr.GetOrdinal("NO_MADERABLE");
                            int pt5 = dr.GetOrdinal("ADICIONAL");
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.CODIGO = dr.GetString(pt1);
                                oCamposDet.DESCRIPCION = dr.GetString(pt2);
                                oCamposDet.MADERABLE = dr.GetBoolean(pt3);
                                oCamposDet.NO_MADERABLE = dr.GetBoolean(pt4);
                                oCamposDet.ADICIONAL = dr.GetBoolean(pt5);
                                lsDetDetalle.Add(oCamposDet);
                            }
                        }
                        oCampos.ListEspeciesEstado = lsDetDetalle;
                        //ISUPERVISION_AGRADO
                        //dr.NextResult();
                        //lsDetDetalle = new List<CEntidad>();
                        //if (dr.HasRows)
                        //{              
                        //	while (dr.Read())
                        //	{
                        //		oCamposDet = new CEntidad();
                        //		oCamposDet.CODIGO = dr["CODIGO"].ToString();
                        //		oCamposDet.DESCRIPCION = dr["DESCRIPCION"].ToString();
                        //		lsDetDetalle.Add(oCamposDet);
                        //	}
                        //}
                        //oCampos.ListISupervisionGradoCateg = lsDetDetalle;
                        //FUSTER
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
                        oCampos.ListISupervisionASCfuster = lsDetDetalle;
                        //FUSTER
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
                        oCampos.ListISupervisionASCFCopa = lsDetDetalle;
                        //COPA
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
                        oCampos.ListISupervisionASPCopa = lsDetDetalle;
                        //Fenologico
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
                        oCampos.ListISupervisionASEFenolog = lsDetDetalle;
                        //Sanitario
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
                        oCampos.ListISupervisionASESanit = lsDetDetalle;
                        //Lianas
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
                        oCampos.ListISupervisionASEILianas = lsDetDetalle;
                        //Silviculturales
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
                        oCampos.ListISupervisionASilvicult = lsDetDetalle;
                        //Persona Especialidad
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
                        oCampos.ListPersEspecialidad = lsDetDetalle;
                        //Nivel Academico
                        dr.NextResult();
                        lsDetDetalle = new List<CEntidad>();
                        if (dr.HasRows)
                        {
                            ;
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.CODIGO = dr["CODIGO"].ToString();
                                oCamposDet.DESCRIPCION = dr["DESCRIPCION"].ToString();
                                lsDetDetalle.Add(oCamposDet);
                            }
                        }
                        oCampos.ListNivelAcademico = lsDetDetalle;
                        //e. fitosanitaria
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
                        oCampos.ListISupervisionFitosanitario = lsDetDetalle;

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
                        oCampos.ListIEspecieMaderable = lsDetDetalle;

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
                        oCampos.ListIEspecieNoMaderable = lsDetDetalle;

                        //estado de cuenta
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
                        //Tipo Registro
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
                        oCampos.ListTipoRegistro = lsDetDetalle;
                        //Estrato
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
                        oCampos.ListEstrato = lsDetDetalle;
                        //Especies Fauna
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
                        oCampos.ListEspeciesDetFauna = lsDetDetalle;
                        //Especies Cientifico
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
                        oCampos.ListEspeciesCientifico = lsDetDetalle;
                        //Gravedad de daño
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
                        oCampos.ListGravedadDanio = lsDetDetalle;
                        //Tipo Cambio de Uso
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
                        oCampos.ListTipoCambioUso = lsDetDetalle;
                        //Estado aprovechamiento
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
                        oCampos.ListMComboEstadoAprovecha = lsDetDetalle;
                        //Tipo informe de ejecución forestal
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
                        oCampos.ListMComboTipoInfoEjecForestal = lsDetDetalle;
                        //Tipo metodología para la medición del DAP
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
                        oCampos.ListMComboTipoMMedirDap = lsDetDetalle;
                        //Tipo condición campo
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
                        oCampos.ListMComboCondicionCampo = lsDetDetalle;
                        //Supervisión motivada - TIPO
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
                        oCampos.ListMComboMotMotivada = lsDetDetalle;
                    }
                }
                return oCampos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <returns></returns>
        public CEntidad RegMostComboResultado(OracleConnection cn, CEntidad oCEntidad)
        {
            CEntidad oCampos = null;
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spGeneral_Combo_Listar", oCEntidad))
                {
                    if (dr != null)
                    {
                        oCampos = new CEntidad();
                        oCampos.ListMComboPSuperConcepto = new List<CEntidad>();
                        oCampos.ListComboPresenciaVaina = new List<CEntidad>();
                        CEntidad oCamposDet;
                        //Concepto Tara
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.CODIGO = dr["CODIGO"].ToString();
                                oCamposDet.DESCRIPCION = dr["DESCRIPCION"].ToString();
                                oCampos.ListMComboPSuperConcepto.Add(oCamposDet);
                            }
                        }

                        //PRESENCIA DE VAINAS
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.CODIGO = dr["CODIGO"].ToString();
                                oCamposDet.DESCRIPCION = dr["DESCRIPCION"].ToString();
                                oCampos.ListComboPresenciaVaina.Add(oCamposDet);
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
        /// LISTADO DE MUESTRA
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        //public List<CEntSDetMarable> RegMostrarPoaDetMaderableListaMuestra(OracleConnection cn, CEntSDetMarable oCEntidad)
        public List<CEntidad> RegMostrarPoaDetMaderableListaMuestra(OracleConnection cn, CEntidad oCEntidad)
        {
            //List<CEntSDetMarable> lsCEntidad = new List<CEntSDetMarable>();
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spPOA_DET_MADERABLE_ListarMuesta", oCEntidad))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            Int32 num_fila = 0;
                            CEntidad oCampos;
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                oCampos.COD_THABILITANTE = dr["COD_THABILITANTE"].ToString();
                                oCampos.NUM_POA = int.Parse(dr["NUM_POA"].ToString());
                                oCampos.COD_ESPECIES = dr["COD_ESPECIES"].ToString();
                                oCampos.DESC_ESPECIES = dr["DESC_ESPECIES"].ToString();
                                oCampos.COD_SECUENCIAL = int.Parse(dr["COD_SECUENCIAL"].ToString());
                                oCampos.BLOQUE = dr["BLOQUE"].ToString();
                                oCampos.FAJA = dr["FAJA"].ToString();
                                oCampos.CODIGO = dr["CODIGO"].ToString();
                                oCampos.DAP = decimal.Parse(dr["DAP"].ToString());
                                oCampos.AC = decimal.Parse(dr["AC"].ToString());
                                oCampos.COD_ECONDICION = dr["COD_ECONDICION"].ToString();
                                oCampos.COD_EESTADO = dr["COD_EESTADO"].ToString();
                                oCampos.DESC_EESTADO = dr["DESC_EESTADO"].ToString();
                                oCampos.COORDENADA_ESTE = int.Parse(dr["COORDENADA_ESTE"].ToString());
                                oCampos.COORDENADA_NORTE = int.Parse(dr["COORDENADA_NORTE"].ToString());
                                oCampos.ESTADO_MUESTRA = Boolean.Parse(dr["ESTADO_MUESTRA"].ToString());
                                oCampos.OBSERVACION = dr["OBSERVACION"].ToString();
                                oCampos.POA = dr["POA"].ToString();
                                oCampos.ESTADO_SUPERVISION = false;
                                oCampos.RegEstado = 1;
                                oCampos.NUMERO_FILA = num_fila;
                                num_fila++;
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
        //public List<CEntSDetMarable> RegMostrarPoaDetMaderableSemilleroListaMuestra(OracleConnection cn, CEntSDetMarable oCEntidad)
        public List<CEntidad> RegMostrarPoaDetMaderableSemilleroListaMuestra(OracleConnection cn, CEntidad oCEntidad)
        {
            //List<CEntSDetMarable> lsCEntidad = new List<CEntSDetMarable>();
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spPOA_DET_MADERABLE_SEMILLERO_ListarMuesta", oCEntidad))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            Int32 num_fila = 0;
                            CEntidad oCampos;
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                oCampos.COD_THABILITANTE = dr["COD_THABILITANTE"].ToString();
                                oCampos.NUM_POA = int.Parse(dr["NUM_POA"].ToString());
                                oCampos.COD_ESPECIES = dr["COD_ESPECIES"].ToString();
                                oCampos.DESC_ESPECIES = dr["DESC_ESPECIES"].ToString();
                                oCampos.COD_SECUENCIAL = int.Parse(dr["COD_SECUENCIAL"].ToString());
                                oCampos.BLOQUE = dr["BLOQUE"].ToString();
                                oCampos.FAJA = dr["FAJA"].ToString();
                                oCampos.CODIGO = dr["CODIGO"].ToString();
                                oCampos.DAP = decimal.Parse(dr["DAP"].ToString());
                                oCampos.AC = decimal.Parse(dr["AC"].ToString());
                                oCampos.COD_ECONDICION = dr["COD_ECONDICION"].ToString();
                                oCampos.COD_EESTADO = dr["COD_EESTADO"].ToString();
                                oCampos.DESC_EESTADO = dr["DESC_EESTADO"].ToString();
                                oCampos.COORDENADA_ESTE = int.Parse(dr["COORDENADA_ESTE"].ToString());
                                oCampos.COORDENADA_NORTE = int.Parse(dr["COORDENADA_NORTE"].ToString());
                                oCampos.ESTADO_MUESTRA = Boolean.Parse(dr["ESTADO_MUESTRA"].ToString());
                                oCampos.OBSERVACION = dr["OBSERVACION"].ToString();
                                oCampos.POA = dr["POA"].ToString();
                                oCampos.ESTADO_SUPERVISION = false;
                                oCampos.RegEstado = 1;
                                oCampos.NUMERO_FILA = num_fila;
                                num_fila++;
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
        /// LISTADO MUESTRA NO MADERABLE
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        //public List<CEntSDetMarable> RegMostrarPoaDetNoMadListaMuestra(OracleConnection cn, CEntSDetMarable oCEntidad)
        public List<CEntidad> RegMostrarPoaDetNoMadListaMuestra(OracleConnection cn, CEntidad oCEntidad)
        {
            //List<CEntSDetMarable> lsCEntidad = new List<CEntSDetMarable>();
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spPOA_DET_NOMADERABLE_ListarMuesta", oCEntidad))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            Int32 num_fila = 0;
                            CEntidad oCampos;
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                oCampos.COD_THABILITANTE = dr["COD_THABILITANTE"].ToString();
                                oCampos.NUM_POA = int.Parse(dr["NUM_POA"].ToString());
                                oCampos.COD_ESPECIES = dr["COD_ESPECIES"].ToString();
                                oCampos.DESC_ESPECIES = dr["DESC_ESPECIES"].ToString();
                                oCampos.COD_SECUENCIAL = int.Parse(dr["COD_SECUENCIAL"].ToString());
                                oCampos.NUM_ESTRADA = dr["NUM_ESTRADA"].ToString();
                                oCampos.CODIGO = dr["CODIGO"].ToString();
                                oCampos.DIAMETRO = decimal.Parse(dr["DIAMETRO"].ToString());
                                oCampos.ALTURA = decimal.Parse(dr["ALTURA"].ToString());
                                oCampos.PRODUCCION_LATAS = decimal.Parse(dr["PRODUCCION_LATAS"].ToString());
                                oCampos.COD_ECONDICION = dr["COD_ECONDICION"].ToString();
                                oCampos.COORDENADA_ESTE = int.Parse(dr["COORDENADA_ESTE"].ToString());
                                oCampos.COORDENADA_NORTE = int.Parse(dr["COORDENADA_NORTE"].ToString());
                                oCampos.OBSERVACION = dr["OBSERVACION"].ToString();
                                oCampos.POA = dr["POA"].ToString();
                                oCampos.ESTADO_SUPERVISION = false;
                                oCampos.RegEstado = 1;
                                oCampos.NUMERO_FILA = num_fila;
                                num_fila++;
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
        //public List<CEntSDetMarable> RegMostrarPoaDetNoMadSemilleroListaMuestra(OracleConnection cn, CEntSDetMarable oCEntidad)
        public List<CEntidad> RegMostrarPoaDetNoMadSemilleroListaMuestra(OracleConnection cn, CEntidad oCEntidad)
        {
            //List<CEntSDetMarable> lsCEntidad = new List<CEntSDetMarable>();
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spPOA_DET_NOMADERABLE_SEMILLERO_ListarMuesta", oCEntidad))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            Int32 num_fila = 0;
                            CEntidad oCampos;
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                oCampos.COD_THABILITANTE = dr["COD_THABILITANTE"].ToString();
                                oCampos.NUM_POA = int.Parse(dr["NUM_POA"].ToString());
                                oCampos.COD_ESPECIES = dr["COD_ESPECIES"].ToString();
                                oCampos.DESC_ESPECIES = dr["DESC_ESPECIES"].ToString();
                                oCampos.COD_SECUENCIAL = int.Parse(dr["COD_SECUENCIAL"].ToString());
                                oCampos.NUM_ESTRADA = dr["NUM_ESTRADA"].ToString();
                                oCampos.CODIGO = dr["CODIGO"].ToString();
                                oCampos.DIAMETRO = decimal.Parse(dr["DIAMETRO"].ToString());
                                oCampos.ALTURA = decimal.Parse(dr["ALTURA"].ToString());
                                oCampos.PRODUCCION_LATAS = decimal.Parse(dr["PRODUCCION_LATAS"].ToString());
                                oCampos.COD_ECONDICION = dr["COD_ECONDICION"].ToString();
                                oCampos.COORDENADA_ESTE = int.Parse(dr["COORDENADA_ESTE"].ToString());
                                oCampos.COORDENADA_NORTE = int.Parse(dr["COORDENADA_NORTE"].ToString());
                                oCampos.OBSERVACION = dr["OBSERVACION"].ToString();
                                oCampos.POA = dr["POA"].ToString();
                                oCampos.ESTADO_SUPERVISION = false;
                                oCampos.RegEstado = 1;
                                oCampos.NUMERO_FILA = num_fila;
                                num_fila++;
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
        //
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        //public CEntidad RegMostrarPoaDetMade_NoMade_ListaMuestra(OracleConnection cn, CEntSDetMarable oCEntidad)
        public CEntidad RegMostrarPoaDetMade_NoMade_ListaMuestra(OracleConnection cn, CEntidad oCEntidad)
        {
            CEntidad lsCEntidad = new CEntidad();
            CEntidad oCampos;
            Int32 num_fila;
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spPOA_DET_MADE_NOMADE_ListaMuestra", oCEntidad))
                {
                    lsCEntidad.ListISupervMaderableAprov = new List<CEntidad>();
                    lsCEntidad.ListISupervNoMaderableAprov = new List<CEntidad>();
                    lsCEntidad.ListISupervMaderableSemillero = new List<CEntidad>();
                    lsCEntidad.ListISupervNoMaderableSemillero = new List<CEntidad>();
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            num_fila = 0;

                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                oCampos.COD_THABILITANTE = dr["COD_THABILITANTE"].ToString();
                                oCampos.NUM_POA = int.Parse(dr["NUM_POA"].ToString());
                                oCampos.COD_ESPECIES = dr["COD_ESPECIES"].ToString();
                                oCampos.DESC_ESPECIES = dr["DESC_ESPECIES"].ToString();
                                oCampos.COD_SECUENCIAL = int.Parse(dr["COD_SECUENCIAL"].ToString());
                                oCampos.BLOQUE = dr["BLOQUE"].ToString();
                                oCampos.FAJA = dr["FAJA"].ToString();
                                oCampos.CODIGO = dr["CODIGO"].ToString();
                                oCampos.DAP = decimal.Parse(dr["DAP"].ToString());
                                oCampos.AC = decimal.Parse(dr["AC"].ToString());
                                oCampos.COD_ECONDICION = dr["COD_ECONDICION"].ToString();
                                oCampos.COD_EESTADO = dr["COD_EESTADO"].ToString();
                                oCampos.DESC_EESTADO = dr["DESC_EESTADO"].ToString();
                                oCampos.COORDENADA_ESTE = int.Parse(dr["COORDENADA_ESTE"].ToString());
                                oCampos.COORDENADA_NORTE = int.Parse(dr["COORDENADA_NORTE"].ToString());
                                oCampos.ESTADO_MUESTRA = Boolean.Parse(dr["ESTADO_MUESTRA"].ToString());
                                oCampos.OBSERVACION = dr["OBSERVACION"].ToString();
                                oCampos.POA = dr["POA"].ToString();
                                oCampos.ESTADO_SUPERVISION = true;
                                oCampos.RegEstado = 1;
                                oCampos.NUMERO_FILA = num_fila;
                                num_fila++;
                                lsCEntidad.ListISupervMaderableAprov.Add(oCampos);
                            }
                        }
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            num_fila = 0;

                            while (dr.Read())
                            {
                                oCampos = new CEntidad();

                                oCampos.COD_THABILITANTE = dr["COD_THABILITANTE"].ToString();
                                oCampos.NUM_POA = int.Parse(dr["NUM_POA"].ToString());
                                oCampos.COD_ESPECIES = dr["COD_ESPECIES"].ToString();
                                oCampos.DESC_ESPECIES = dr["DESC_ESPECIES"].ToString();
                                oCampos.COD_SECUENCIAL = int.Parse(dr["COD_SECUENCIAL"].ToString());
                                oCampos.BLOQUE = dr["BLOQUE"].ToString();
                                oCampos.FAJA = dr["FAJA"].ToString();
                                oCampos.CODIGO = dr["CODIGO"].ToString();
                                oCampos.DAP = decimal.Parse(dr["DAP"].ToString());
                                oCampos.AC = decimal.Parse(dr["AC"].ToString());
                                oCampos.COD_ECONDICION = dr["COD_ECONDICION"].ToString();
                                oCampos.COD_EESTADO = dr["COD_EESTADO"].ToString();
                                oCampos.DESC_EESTADO = dr["DESC_EESTADO"].ToString();
                                oCampos.COORDENADA_ESTE = int.Parse(dr["COORDENADA_ESTE"].ToString());
                                oCampos.COORDENADA_NORTE = int.Parse(dr["COORDENADA_NORTE"].ToString());
                                oCampos.ESTADO_MUESTRA = Boolean.Parse(dr["ESTADO_MUESTRA"].ToString());
                                oCampos.OBSERVACION = dr["OBSERVACION"].ToString();
                                oCampos.POA = dr["POA"].ToString();
                                oCampos.ESTADO_SUPERVISION = true;
                                oCampos.RegEstado = 1;
                                oCampos.NUMERO_FILA = num_fila;
                                num_fila++;
                                lsCEntidad.ListISupervMaderableSemillero.Add(oCampos);
                            }
                        }
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            num_fila = 0;
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                oCampos.COD_THABILITANTE = dr["COD_THABILITANTE"].ToString();
                                oCampos.NUM_POA = int.Parse(dr["NUM_POA"].ToString());
                                oCampos.COD_ESPECIES = dr["COD_ESPECIES"].ToString();
                                oCampos.DESC_ESPECIES = dr["DESC_ESPECIES"].ToString();
                                oCampos.COD_SECUENCIAL = int.Parse(dr["COD_SECUENCIAL"].ToString());
                                oCampos.NUM_ESTRADA = dr["NUM_ESTRADA"].ToString();
                                oCampos.CODIGO = dr["CODIGO"].ToString();
                                oCampos.DIAMETRO = decimal.Parse(dr["DIAMETRO"].ToString());
                                oCampos.ALTURA = decimal.Parse(dr["ALTURA"].ToString());
                                oCampos.PRODUCCION_LATAS = decimal.Parse(dr["PRODUCCION_LATAS"].ToString());
                                oCampos.COD_ECONDICION = dr["COD_ECONDICION"].ToString();
                                oCampos.COORDENADA_ESTE = int.Parse(dr["COORDENADA_ESTE"].ToString());
                                oCampos.COORDENADA_NORTE = int.Parse(dr["COORDENADA_NORTE"].ToString());
                                oCampos.OBSERVACION = dr["OBSERVACION"].ToString();
                                oCampos.POA = dr["POA"].ToString();
                                oCampos.ESTADO_SUPERVISION = true;
                                oCampos.RegEstado = 1;
                                oCampos.NUMERO_FILA = num_fila;
                                num_fila++;
                                lsCEntidad.ListISupervNoMaderableAprov.Add(oCampos);
                            }
                        }
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            num_fila = 0;
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                oCampos.COD_THABILITANTE = dr["COD_THABILITANTE"].ToString();
                                oCampos.NUM_POA = int.Parse(dr["NUM_POA"].ToString());
                                oCampos.COD_ESPECIES = dr["COD_ESPECIES"].ToString();
                                oCampos.DESC_ESPECIES = dr["DESC_ESPECIES"].ToString();
                                oCampos.COD_SECUENCIAL = int.Parse(dr["COD_SECUENCIAL"].ToString());
                                oCampos.NUM_ESTRADA = dr["NUM_ESTRADA"].ToString();
                                oCampos.CODIGO = dr["CODIGO"].ToString();
                                oCampos.DIAMETRO = decimal.Parse(dr["DIAMETRO"].ToString());
                                oCampos.ALTURA = decimal.Parse(dr["ALTURA"].ToString());
                                oCampos.PRODUCCION_LATAS = decimal.Parse(dr["PRODUCCION_LATAS"].ToString());
                                oCampos.COD_ECONDICION = dr["COD_ECONDICION"].ToString();
                                oCampos.COORDENADA_ESTE = int.Parse(dr["COORDENADA_ESTE"].ToString());
                                oCampos.COORDENADA_NORTE = int.Parse(dr["COORDENADA_NORTE"].ToString());
                                oCampos.OBSERVACION = dr["OBSERVACION"].ToString();
                                oCampos.POA = dr["POA"].ToString();
                                oCampos.ESTADO_SUPERVISION = true;
                                oCampos.RegEstado = 1;
                                oCampos.NUMERO_FILA = num_fila;
                                num_fila++;
                                lsCEntidad.ListISupervNoMaderableSemillero.Add(oCampos);
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

        //DEVOLUCION MADERA
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        //public CEntidad RegMostrarDevolMad_ListaMuestra(OracleConnection cn, CEntSDetMarable oCEntidad)
        public CEntidad RegMostrarDevolMad_ListaMuestra(OracleConnection cn, CEntidad oCEntidad)
        {
            CEntidad lsCEntidad = new CEntidad();
            CEntidad ocampoDevol;
            Int32 num_fila;
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spDEVOL_MAD_ListaMuestra", oCEntidad))
                {
                    lsCEntidad.ListISupervDevolTroza = new List<CEntidad>();
                    lsCEntidad.ListISupervDevolTocon = new List<CEntidad>();
                    lsCEntidad.ListISupervDevolArbol = new List<CEntidad>();
                    if (dr != null)
                    {
                        // DEVOLUCION TROZA
                        if (dr.HasRows)
                        {
                            num_fila = 0;
                            while (dr.Read())
                            {
                                ocampoDevol = new CEntidad();
                                ocampoDevol.NUMERO_FILA = num_fila;
                                ocampoDevol.COD_THABILITANTE = dr["COD_THABILITANTE"].ToString();
                                ocampoDevol.COD_DEVOLUCION = dr["COD_DEVOLUCION"].ToString();
                                ocampoDevol.COD_ESPECIES = dr["COD_ESPECIES"].ToString();
                                ocampoDevol.DESC_ESPECIES = dr["DESC_ESPECIES"].ToString();
                                ocampoDevol.COD_SECUENCIAL = int.Parse(dr["COD_SECUENCIAL"].ToString());
                                ocampoDevol.DAP = decimal.Parse(dr["DAP"].ToString());
                                ocampoDevol.ALTURA = decimal.Parse(dr["ALTURA"].ToString());
                                ocampoDevol.CODIGO = dr["CODIGO"].ToString();
                                ocampoDevol.VOLUMEN = decimal.Parse(dr["VOLUMEN"].ToString());
                                ocampoDevol.COORDENADA_ESTE = int.Parse(dr["COORDENADA_ESTE"].ToString());
                                ocampoDevol.COORDENADA_NORTE = int.Parse(dr["COORDENADA_NORTE"].ToString());
                                ocampoDevol.NUM_TROZAS = int.Parse(dr["NUM_TROZAS"].ToString());
                                ocampoDevol.OBSERVACION = dr["OBSERVACION"].ToString();
                                ocampoDevol.RegEstado = 0;
                                lsCEntidad.ListISupervDevolTroza.Add(ocampoDevol);
                            }
                        }

                        // DEVOLUCION TOCONES
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            num_fila = 0;
                            while (dr.Read())
                            {
                                ocampoDevol = new CEntidad();
                                ocampoDevol.NUMERO_FILA = num_fila;
                                ocampoDevol.COD_THABILITANTE = dr["COD_THABILITANTE"].ToString();
                                ocampoDevol.COD_DEVOLUCION = dr["COD_DEVOLUCION"].ToString();
                                ocampoDevol.COD_ESPECIES = dr["COD_ESPECIES"].ToString();
                                ocampoDevol.DESC_ESPECIES = dr["DESC_ESPECIES"].ToString();
                                ocampoDevol.COD_SECUENCIAL = int.Parse(dr["COD_SECUENCIAL"].ToString());
                                ocampoDevol.DIAMETRO = decimal.Parse(dr["DIAMETRO"].ToString());
                                ocampoDevol.CODIGO = dr["CODIGO"].ToString();
                                ocampoDevol.LARGO = decimal.Parse(dr["LARGO"].ToString());
                                ocampoDevol.VOLUMEN = decimal.Parse(dr["VOLUMEN"].ToString());
                                ocampoDevol.COORDENADA_ESTE = int.Parse(dr["COORDENADA_ESTE"].ToString());
                                ocampoDevol.COORDENADA_NORTE = int.Parse(dr["COORDENADA_NORTE"].ToString());
                                ocampoDevol.CANTIDAD = int.Parse(dr["CANTIDAD"].ToString());
                                ocampoDevol.OBSERVACION = dr["OBSERVACION"].ToString();
                                ocampoDevol.RegEstado = 0;
                                lsCEntidad.ListISupervDevolTocon.Add(ocampoDevol);
                            }
                        }
                        // DEVOLUCION ARBOL
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            num_fila = 0;
                            while (dr.Read())
                            {
                                ocampoDevol = new CEntidad();
                                ocampoDevol.NUMERO_FILA = num_fila;
                                ocampoDevol.COD_THABILITANTE = dr["COD_THABILITANTE"].ToString();
                                ocampoDevol.COD_DEVOLUCION = dr["COD_DEVOLUCION"].ToString();
                                ocampoDevol.COD_ESPECIES = dr["COD_ESPECIES"].ToString();
                                ocampoDevol.DESC_ESPECIES = dr["DESC_ESPECIES"].ToString();
                                ocampoDevol.COD_SECUENCIAL = int.Parse(dr["COD_SECUENCIAL"].ToString());
                                ocampoDevol.NUM_PCA = dr["NUM_PCA"].ToString();
                                ocampoDevol.CODIGO = dr["CODIGO"].ToString();
                                ocampoDevol.DAP = decimal.Parse(dr["DAP"].ToString());
                                ocampoDevol.ALTURA = decimal.Parse(dr["ALTURA"].ToString());
                                ocampoDevol.VOLUMEN = decimal.Parse(dr["VOLUMEN"].ToString());
                                ocampoDevol.COORDENADA_ESTE = int.Parse(dr["COORDENADA_ESTE"].ToString());
                                ocampoDevol.COORDENADA_NORTE = int.Parse(dr["COORDENADA_NORTE"].ToString());
                                ocampoDevol.ESTADO = dr["DESC_EESTADO"].ToString();
                                ocampoDevol.OBSERVACION = dr["OBSERVACION"].ToString();
                                ocampoDevol.RegEstado = 0;
                                lsCEntidad.ListISupervDevolArbol.Add(ocampoDevol);
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
        public String RegInsertar(OracleConnection cn, CEntidad oCEntidad)
        {
            OracleTransaction tr = null;
            String OUTPUTPARAM01 = "";
            CEntidad ocampoSuper;
            CEntPersona ocampoPer;
            try
            {
                tr = cn.BeginTransaction();
                //Grabando Cabecera
                using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.INFORME_Grabar", oCEntidad))
                {
                    cmd.ExecuteNonQuery();
                    OUTPUTPARAM01 = (String)cmd.Parameters["OUTPUTPARAM01"].Value;
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
                        throw new Exception("El Número de Informe ya Existe");
                    }
                    else if (OUTPUTPARAM01 == "1")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("El Número del Titulo Habilitante Existe en otro Registro");
                    }
                    else if (OUTPUTPARAM01 == "2")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("No Tiene Permisos para Modificar este Informe");
                    }
                    else if (OUTPUTPARAM01 == "3")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("Está con Control de Calidad, no puede modificar");
                    }

                }
                #region ListEliTABLA
                //Eliminando Detalle Informe
                if (oCEntidad.ListEliTABLA != null)
                {
                    foreach (var loDatos in oCEntidad.ListEliTABLA)
                    {
                        ocampoSuper = new CEntidad();
                        ocampoSuper.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                        ocampoSuper.COD_INFORME_FOTOS = loDatos.COD_INFORME_FOTOS;
                        ocampoSuper.EliTABLA = loDatos.EliTABLA;
                        ocampoSuper.COD_ESPECIES = loDatos.COD_ESPECIES;
                        ocampoSuper.COD_PERSONA = loDatos.COD_PERSONA;
                        ocampoSuper.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                        ocampoSuper.NUM_POA = loDatos.NUM_POA;
                        ocampoSuper.COD_THABILITANTE = loDatos.COD_THABILITANTE;
                        ocampoSuper.COD_CNOTIFICACION = loDatos.COD_CNOTIFICACION;
                        ocampoSuper.COD_MUESTRA_SUPERVISION = loDatos.COD_MUESTRA_SUPERVISION;
                        ocampoSuper.EliVALOR01 = loDatos.EliVALOR01;
                        ocampoSuper.COD_SECUENCIAL_ADENDA = loDatos.COD_SECUENCIAL_ADENDA;
                        dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spINFORME_Eliminar", ocampoSuper);
                    }
                }
                #endregion
                #region ListCNotificaciones
                if (oCEntidad.ListCNotificaciones != null)
                {
                    foreach (var loDatos in oCEntidad.ListCNotificaciones)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            ocampoSuper = new CEntidad();
                            ocampoSuper.COD_CNOTIFICACION = loDatos.COD_CNOTIFICACION;
                            ocampoSuper.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            ocampoSuper.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spINFORME_DET_CNOTIFICACIONES_Grabar", ocampoSuper);
                        }
                    }
                }
                #endregion
                #region ListInformeDetSupervisor
                if (oCEntidad.ListInformeDetSupervisor != null)
                {
                    foreach (var loDatos in oCEntidad.ListInformeDetSupervisor)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            ocampoPer = new CEntPersona();
                            ocampoPer.COD_PERSONA = loDatos.COD_PERSONA;
                            ocampoPer.CODIGO = OUTPUTPARAM01.Split('|')[0];
                            ocampoPer.COD_DIDENTIDAD = loDatos.COD_DIDENTIDAD;
                            ocampoPer.APE_PATERNO = loDatos.APE_PATERNO;
                            ocampoPer.APE_MATERNO = loDatos.APE_MATERNO;
                            ocampoPer.NOMBRES = loDatos.NOMBRES;
                            ocampoPer.N_DOCUMENTO = loDatos.N_DOCUMENTO;
                            ocampoPer.N_RUC = loDatos.N_RUC;
                            ocampoPer.COD_PTIPO = loDatos.COD_PTIPO;
                            ocampoPer.COLEGIATURA_NUM = loDatos.COLEGIATURA_NUM;
                            ocampoPer.COD_DPESPECIALIDAD = loDatos.COD_DPESPECIALIDAD;
                            ocampoPer.COD_NACADEMICO = loDatos.COD_NACADEMICO;
                            ocampoPer.CARGO = loDatos.CARGO;
                            ocampoPer.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.INFORME_DET_SUPERVISOR_Grabar", ocampoPer);
                        }
                    }
                }
                #endregion
                #region ListISupervMaderableAprov
                // INFORME MADERABLE APROVECHABLE
                if (oCEntidad.ListISupervMaderableAprov != null)
                {
                    foreach (var loDatos in oCEntidad.ListISupervMaderableAprov)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            //oCamposMad = new CEntSDetMarable();
                            ocampoSuper = new CEntidad();
                            ocampoSuper.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            ocampoSuper.COD_THABILITANTE = loDatos.COD_THABILITANTE;
                            ocampoSuper.NUM_POA = loDatos.NUM_POA;
                            ocampoSuper.COD_ESPECIES = loDatos.COD_ESPECIES;
                            ocampoSuper.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            ocampoSuper.COD_ESPECIES_CAMPO = loDatos.COD_ESPECIES_CAMPO == "" ? null : loDatos.COD_ESPECIES_CAMPO;
                            ocampoSuper.BLOQUE = loDatos.BLOQUE_CAMPO == null ? "" : loDatos.BLOQUE_CAMPO;
                            ocampoSuper.FAJA = loDatos.FAJA_CAMPO == null ? "" : loDatos.FAJA_CAMPO;
                            ocampoSuper.CODIGO = loDatos.CODIGO_CAMPO == null ? "" : loDatos.CODIGO_CAMPO;
                            ocampoSuper.DAP = loDatos.DAP_CAMPO == -1 ? 0 : loDatos.DAP_CAMPO;
                            ocampoSuper.AC = loDatos.AC_CAMPO == -1 ? 0 : loDatos.AC_CAMPO;
                            ocampoSuper.ZONA = loDatos.ZONA_CAMPO;
                            ocampoSuper.COORDENADA_ESTE = loDatos.COORDENADA_ESTE_CAMPO == -1 ? 0 : loDatos.COORDENADA_ESTE_CAMPO;
                            ocampoSuper.COORDENADA_NORTE = loDatos.COORDENADA_NORTE_CAMPO == -1 ? 0 : loDatos.COORDENADA_NORTE_CAMPO;
                            ocampoSuper.COD_EESTADO = loDatos.COD_EESTADO == "" ? null : loDatos.COD_EESTADO;
                            //ocampoSuper.COD_ACATEGORIA = loDatos.COD_ACATEGORIA == "" ? null : loDatos.COD_ACATEGORIA;
                            ocampoSuper.OBSERVACION = loDatos.OBSERVACION == null ? "" : loDatos.OBSERVACION;
                            //ocampoSuper.ESTADO_SUPERVISION = loDatos.ESTADO_SUPERVISION;
                            ocampoSuper.BS_ALTURA_TOTAL = loDatos.BS_ALTURA_TOTAL == -1 ? 0 : loDatos.BS_ALTURA_TOTAL;
                            ocampoSuper.BS_DIAMETRO_RAMA_1 = loDatos.BS_DIAMETRO_RAMA_1 == -1 ? 0 : loDatos.BS_DIAMETRO_RAMA_1;
                            ocampoSuper.BS_DIAMETRO_RAMA_2 = loDatos.BS_DIAMETRO_RAMA_2 == -1 ? 0 : loDatos.BS_DIAMETRO_RAMA_2;
                            ocampoSuper.BS_DIAMETRO_RAMA_3 = loDatos.BS_DIAMETRO_RAMA_3 == -1 ? 0 : loDatos.BS_DIAMETRO_RAMA_3;
                            ocampoSuper.BS_DIAMETRO_RAMA_4 = loDatos.BS_DIAMETRO_RAMA_4 == -1 ? 0 : loDatos.BS_DIAMETRO_RAMA_4;
                            ocampoSuper.BS_DIAMETRO_RAMA_5 = loDatos.BS_DIAMETRO_RAMA_5 == -1 ? 0 : loDatos.BS_DIAMETRO_RAMA_5;
                            ocampoSuper.BS_DIAMETRO_RAMA_6 = loDatos.BS_DIAMETRO_RAMA_6 == -1 ? 0 : loDatos.BS_DIAMETRO_RAMA_6;
                            ocampoSuper.BS_DIAMETRO_RAMA_7 = loDatos.BS_DIAMETRO_RAMA_7 == -1 ? 0 : loDatos.BS_DIAMETRO_RAMA_7;
                            ocampoSuper.BS_LONGITUD_RAMA_1 = loDatos.BS_LONGITUD_RAMA_1 == -1 ? 0 : loDatos.BS_LONGITUD_RAMA_1;
                            ocampoSuper.BS_LONGITUD_RAMA_2 = loDatos.BS_LONGITUD_RAMA_2 == -1 ? 0 : loDatos.BS_LONGITUD_RAMA_2;
                            ocampoSuper.BS_LONGITUD_RAMA_3 = loDatos.BS_LONGITUD_RAMA_3 == -1 ? 0 : loDatos.BS_LONGITUD_RAMA_3;
                            ocampoSuper.BS_LONGITUD_RAMA_4 = loDatos.BS_LONGITUD_RAMA_4 == -1 ? 0 : loDatos.BS_LONGITUD_RAMA_4;
                            ocampoSuper.BS_LONGITUD_RAMA_5 = loDatos.BS_LONGITUD_RAMA_5 == -1 ? 0 : loDatos.BS_LONGITUD_RAMA_5;
                            ocampoSuper.BS_LONGITUD_RAMA_6 = loDatos.BS_LONGITUD_RAMA_6 == -1 ? 0 : loDatos.BS_LONGITUD_RAMA_6;
                            ocampoSuper.BS_LONGITUD_RAMA_7 = loDatos.BS_LONGITUD_RAMA_7 == -1 ? 0 : loDatos.BS_LONGITUD_RAMA_7;
                            ocampoSuper.DAP2 = loDatos.DAP_CAMPO2 == -1 ? 0 : loDatos.DAP_CAMPO2;
                            ocampoSuper.DAP1 = loDatos.DAP_CAMPO1 == -1 ? 0 : loDatos.DAP_CAMPO1;
                            ocampoSuper.COINCIDE_ESPECIES = loDatos.COINCIDE_ESPECIES;
                            ocampoSuper.MAE_TIP_MMEDIRDAP = loDatos.MAE_TIP_MMEDIRDAP == "0000000" || loDatos.MAE_TIP_MMEDIRDAP == "" ? null : loDatos.MAE_TIP_MMEDIRDAP;
                            ocampoSuper.MMEDIR_DAP = loDatos.MMEDIR_DAP;
                            ocampoSuper.COD_ECONDICION = loDatos.COD_ECONDICION_CAMPO == "0000000" || loDatos.COD_ECONDICION_CAMPO == "" ? null : loDatos.COD_ECONDICION_CAMPO;
                            ocampoSuper.DESC_ECONDICION = loDatos.DESC_ECONDICION;
                            ocampoSuper.CANT_SOBRE_ESTIMA_DIAMETRO = loDatos.CANT_SOBRE_ESTIMA_DIAMETRO;
                            ocampoSuper.PORC_SOBRE_ESTIMA_DIAMETRO = loDatos.PORC_SOBRE_ESTIMA_DIAMETRO;
                            ocampoSuper.CANT_SUB_ESTIMA_DIAMETRO = loDatos.CANT_SUB_ESTIMA_DIAMETRO;
                            ocampoSuper.PORC_SUB_ESTIMA_DIAMETRO = loDatos.PORC_SUB_ESTIMA_DIAMETRO;
                            ocampoSuper.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.ISUPERVISION_DET_EMADERABLE_Grabar", ocampoSuper);
                        }
                    }
                }
                #endregion
                #region ListISupervMaderableSemillero
                // INFORME MADERABLE SEMILLERO
                if (oCEntidad.ListISupervMaderableSemillero != null)
                {
                    foreach (var loDatos in oCEntidad.ListISupervMaderableSemillero)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            //oCamposMad = new CEntSDetMarable();
                            ocampoSuper = new CEntidad();
                            ocampoSuper.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            ocampoSuper.COD_THABILITANTE = loDatos.COD_THABILITANTE;
                            ocampoSuper.NUM_POA = loDatos.NUM_POA;
                            ocampoSuper.COD_ESPECIES = loDatos.COD_ESPECIES;
                            ocampoSuper.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            ocampoSuper.COD_ESPECIES_CAMPO = loDatos.COD_ESPECIES_CAMPO == "" ? null : loDatos.COD_ESPECIES_CAMPO;
                            ocampoSuper.BLOQUE = loDatos.BLOQUE_CAMPO == null ? "" : loDatos.BLOQUE_CAMPO;
                            ocampoSuper.FAJA = loDatos.FAJA_CAMPO == null ? "" : loDatos.FAJA_CAMPO;
                            ocampoSuper.CODIGO = loDatos.CODIGO_CAMPO == null ? "" : loDatos.CODIGO_CAMPO;
                            ocampoSuper.DAP = loDatos.DAP_CAMPO == -1 ? 0 : loDatos.DAP_CAMPO;
                            ocampoSuper.AC = loDatos.AC_CAMPO == -1 ? 0 : loDatos.AC_CAMPO;
                            ocampoSuper.ZONA = loDatos.ZONA_CAMPO;
                            ocampoSuper.COORDENADA_ESTE = loDatos.COORDENADA_ESTE_CAMPO == -1 ? 0 : loDatos.COORDENADA_ESTE_CAMPO;
                            ocampoSuper.COORDENADA_NORTE = loDatos.COORDENADA_NORTE_CAMPO == -1 ? 0 : loDatos.COORDENADA_NORTE_CAMPO;
                            ocampoSuper.COD_EESTADO = loDatos.COD_EESTADO == "" ? null : loDatos.COD_EESTADO;
                            //ocampoSuper.COD_ACATEGORIA = loDatos.COD_ACATEGORIA == "" ? null : loDatos.COD_ACATEGORIA;
                            ocampoSuper.OBSERVACION = loDatos.OBSERVACION == null ? "" : loDatos.OBSERVACION;
                            ocampoSuper.COD_CFUSTE = loDatos.COD_CFUSTE == "" ? null : loDatos.COD_CFUSTE;
                            ocampoSuper.COD_FCOPA = loDatos.COD_FCOPA == "" ? null : loDatos.COD_FCOPA;
                            ocampoSuper.COD_PCOPA = loDatos.COD_PCOPA == "" ? null : loDatos.COD_PCOPA;
                            ocampoSuper.COD_EFENOLOGICO = loDatos.COD_EFENOLOGICO == "" ? null : loDatos.COD_EFENOLOGICO;
                            ocampoSuper.COD_ESANITARIO = loDatos.COD_ESANITARIO == "" ? null : loDatos.COD_ESANITARIO;
                            ocampoSuper.COD_ILIANAS = loDatos.COD_ILIANAS == "" ? null : loDatos.COD_ILIANAS;
                            //ocampoSuper.ESTADO_SUPERVISION = loDatos.ESTADO_SUPERVISION;
                            ocampoSuper.DAP2 = loDatos.DAP_CAMPO2 == -1 ? 0 : loDatos.DAP_CAMPO2;
                            ocampoSuper.DAP1 = loDatos.DAP_CAMPO1 == -1 ? 0 : loDatos.DAP_CAMPO1;
                            ocampoSuper.COINCIDE_ESPECIES = loDatos.COINCIDE_ESPECIES;
                            ocampoSuper.MAE_TIP_MMEDIRDAP = loDatos.MAE_TIP_MMEDIRDAP == "0000000" || loDatos.MAE_TIP_MMEDIRDAP == "" ? null : loDatos.MAE_TIP_MMEDIRDAP;
                            ocampoSuper.MMEDIR_DAP = loDatos.MMEDIR_DAP;
                            ocampoSuper.CANT_SOBRE_ESTIMA_DIAMETRO = loDatos.CANT_SOBRE_ESTIMA_DIAMETRO;
                            ocampoSuper.PORC_SOBRE_ESTIMA_DIAMETRO = loDatos.PORC_SOBRE_ESTIMA_DIAMETRO;
                            ocampoSuper.CANT_SUB_ESTIMA_DIAMETRO = loDatos.CANT_SUB_ESTIMA_DIAMETRO;
                            ocampoSuper.PORC_SUB_ESTIMA_DIAMETRO = loDatos.PORC_SUB_ESTIMA_DIAMETRO;
                            ocampoSuper.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.ISUPERVISION_DET_EMADERABLE_Grabar", ocampoSuper);
                        }
                    }
                }
                // INFORME NO MADERABLE APROVECHABLE
                //if (oCEntidad.ListISupervNoMaderableAprov != null)
                //{

                //	foreach (var loDatos in oCEntidad.ListISupervNoMaderableAprov)
                //	{
                //		if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                //		{
                //			//oCamposMad = new CEntSDetMarable();
                //			ocampoSuper = new CEntidad();
                //			ocampoSuper.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                //			ocampoSuper.COD_THABILITANTE = loDatos.COD_THABILITANTE;
                //			ocampoSuper.NUM_POA = loDatos.NUM_POA;
                //			ocampoSuper.COD_ESPECIES = loDatos.COD_ESPECIES;
                //			ocampoSuper.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                //			ocampoSuper.COD_ESPECIES_CAMPO = loDatos.COD_ESPECIES_CAMPO == "" ? null : loDatos.COD_ESPECIES_CAMPO;
                //			ocampoSuper.NUM_ESTRADA = loDatos.NUM_ESTRADA_CAMPO == null ? "" : loDatos.NUM_ESTRADA_CAMPO;
                //			ocampoSuper.CODIGO = loDatos.CODIGO_CAMPO == null ? "" : loDatos.CODIGO_CAMPO;
                //			ocampoSuper.DIAMETRO = loDatos.DIAMETRO_CAMPO == -1 ? 0 : loDatos.DIAMETRO_CAMPO;
                //			ocampoSuper.ALTURA = loDatos.ALTURA_CAMPO == -1 ? 0 : loDatos.ALTURA_CAMPO;
                //			ocampoSuper.PRODUCCION_LATAS = loDatos.PRODUCCION_LATAS_CAMPO == -1 ? 0 : loDatos.PRODUCCION_LATAS_CAMPO;
                //                        ocampoSuper.ZONA = loDatos.ZONA_CAMPO;
                //			ocampoSuper.COORDENADA_ESTE = loDatos.COORDENADA_ESTE_CAMPO == -1 ? 0 : loDatos.COORDENADA_ESTE_CAMPO;
                //			ocampoSuper.COORDENADA_NORTE = loDatos.COORDENADA_NORTE_CAMPO == -1 ? 0 : loDatos.COORDENADA_NORTE_CAMPO;
                //			ocampoSuper.COD_EESTADO = loDatos.COD_EESTADO == "" ? null : loDatos.COD_EESTADO;
                //			ocampoSuper.NUM_COCOS_ABIERTOS = loDatos.NUM_COCOS_ABIERTOS == -1 ? 0 : loDatos.NUM_COCOS_ABIERTOS;
                //			ocampoSuper.NUM_COCOS_CERRADOS = loDatos.NUM_COCOS_CERRADOS == -1 ? 0 : loDatos.NUM_COCOS_CERRADOS;
                //			ocampoSuper.OBSERVACION = loDatos.OBSERVACION == null ? "" : loDatos.OBSERVACION;                 
                //			//ocampoSuper.ESTADO_SUPERVISION = loDatos.ESTADO_SUPERVISION;                            
                //			ocampoSuper.RegEstado = loDatos.RegEstado;
                //			dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.ISUPERVISION_DET_ENOMADERABLE_Grabar", ocampoSuper);
                //		}
                //	}
                //}
                #endregion
                #region ListISupervNoMaderableSemillero
                // INFORME NO MADERABLE SEMILLERO
                if (oCEntidad.ListISupervNoMaderableSemillero != null)
                {

                    foreach (var loDatos in oCEntidad.ListISupervNoMaderableSemillero)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            //oCamposMad = new CEntSDetMarable();
                            ocampoSuper = new CEntidad();
                            ocampoSuper.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            ocampoSuper.COD_THABILITANTE = loDatos.COD_THABILITANTE;
                            ocampoSuper.NUM_POA = loDatos.NUM_POA;
                            ocampoSuper.COD_ESPECIES = loDatos.COD_ESPECIES;
                            ocampoSuper.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            ocampoSuper.COD_ESPECIES_CAMPO = loDatos.COD_ESPECIES_CAMPO == "" ? null : loDatos.COD_ESPECIES_CAMPO;
                            ocampoSuper.NUM_ESTRADA = loDatos.NUM_ESTRADA_CAMPO == null ? "" : loDatos.NUM_ESTRADA_CAMPO;
                            ocampoSuper.CODIGO = loDatos.CODIGO_CAMPO == null ? "" : loDatos.CODIGO_CAMPO;
                            ocampoSuper.DIAMETRO = loDatos.DIAMETRO_CAMPO == -1 ? 0 : loDatos.DIAMETRO_CAMPO;
                            ocampoSuper.ALTURA = loDatos.ALTURA_CAMPO == -1 ? 0 : loDatos.ALTURA_CAMPO;
                            ocampoSuper.PRODUCCION_LATAS = loDatos.PRODUCCION_LATAS_CAMPO == -1 ? 0 : loDatos.PRODUCCION_LATAS_CAMPO;
                            ocampoSuper.ZONA = loDatos.ZONA_CAMPO;
                            ocampoSuper.COORDENADA_ESTE = loDatos.COORDENADA_ESTE_CAMPO == -1 ? 0 : loDatos.COORDENADA_ESTE_CAMPO;
                            ocampoSuper.COORDENADA_NORTE = loDatos.COORDENADA_NORTE_CAMPO == -1 ? 0 : loDatos.COORDENADA_NORTE_CAMPO;
                            ocampoSuper.COD_EESTADO = loDatos.COD_EESTADO == "" ? null : loDatos.COD_EESTADO;
                            ocampoSuper.NUM_COCOS_ABIERTOS = loDatos.NUM_COCOS_ABIERTOS == -1 ? 0 : loDatos.NUM_COCOS_ABIERTOS;
                            ocampoSuper.NUM_COCOS_CERRADOS = loDatos.NUM_COCOS_CERRADOS == -1 ? 0 : loDatos.NUM_COCOS_CERRADOS;
                            ocampoSuper.OBSERVACION = loDatos.OBSERVACION == null ? "" : loDatos.OBSERVACION;
                            ocampoSuper.COD_CFUSTE = loDatos.COD_CFUSTE == "" ? null : loDatos.COD_CFUSTE;
                            ocampoSuper.COD_EFITOSANITARIO = loDatos.COD_EFITOSANITARIO == "" ? null : loDatos.COD_EFITOSANITARIO;
                            ocampoSuper.COD_FCOPA = loDatos.COD_FCOPA == "" ? null : loDatos.COD_FCOPA;
                            ocampoSuper.COD_PCOPA = loDatos.COD_PCOPA == "" ? null : loDatos.COD_PCOPA;
                            ocampoSuper.COD_EFENOLOGICO = loDatos.COD_EFENOLOGICO == "" ? null : loDatos.COD_EFENOLOGICO;
                            ocampoSuper.COD_ESANITARIO = loDatos.COD_ESANITARIO == "" ? null : loDatos.COD_ESANITARIO;
                            ocampoSuper.COD_ILIANAS = loDatos.COD_ILIANAS == "" ? null : loDatos.COD_ILIANAS;
                            //ocampoSuper.ESTADO_SUPERVISION = loDatos.ESTADO_SUPERVISION;
                            ocampoSuper.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.ISUPERVISION_DET_ENOMADERABLE_Grabar", ocampoSuper);
                        }
                    }
                }
                #endregion
                #region ListISupervMaderableAdicional
                if (oCEntidad.ListISupervMaderableAdicional != null)
                {
                    foreach (var loDatos in oCEntidad.ListISupervMaderableAdicional)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            //oCamposMad = new CEntSDetMarable();
                            ocampoSuper = new CEntidad();
                            ocampoSuper.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            ocampoSuper.COD_ESPECIES = loDatos.COD_ESPECIES;
                            ocampoSuper.DESC_ESPECIES = loDatos.DESC_ESPECIES;
                            ocampoSuper.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            ocampoSuper.BLOQUE = loDatos.BLOQUE;
                            ocampoSuper.FAJA = loDatos.FAJA;
                            ocampoSuper.CODIGO = loDatos.CODIGO;
                            ocampoSuper.DAP = loDatos.DAP;
                            ocampoSuper.AC = loDatos.AC;
                            ocampoSuper.ZONA = loDatos.ZONA;
                            ocampoSuper.COORDENADA_ESTE = loDatos.COORDENADA_ESTE;
                            ocampoSuper.COORDENADA_NORTE = loDatos.COORDENADA_NORTE;
                            ocampoSuper.COD_ECONDICION = loDatos.COD_ECONDICION;
                            ocampoSuper.COD_EESTADO = loDatos.COD_EESTADO;
                            ocampoSuper.DESC_EESTADO = loDatos.DESC_EESTADO;
                            //ocampoSuper.COD_ACATEGORIA = loDatos.COD_ACATEGORIA;
                            //ocampoSuper.DESC_ACATEGORIA_CITE = loDatos.DESC_ACATEGORIA_CITE;
                            //                     ocampoSuper.DESC_ACATEGORIA_DS = loDatos.DESC_ACATEGORIA_DS;
                            ocampoSuper.OBSERVACION = loDatos.OBSERVACION;
                            ocampoSuper.RegEstado = loDatos.RegEstado;
                            ocampoSuper.MAE_TIP_MADERABLE = loDatos.MAE_TIP_MADERABLE;
                            ocampoSuper.NUM_POA = loDatos.NUM_POA;
                            ocampoSuper.DAP2 = loDatos.DAP2 == -1 ? 0 : loDatos.DAP2;
                            ocampoSuper.DAP1 = loDatos.DAP1 == -1 ? 0 : loDatos.DAP1;
                            ocampoSuper.MAE_TIP_MMEDIRDAP = loDatos.MAE_TIP_MMEDIRDAP == "0000000" || loDatos.MAE_TIP_MMEDIRDAP == "" ? null : loDatos.MAE_TIP_MMEDIRDAP;
                            ocampoSuper.MMEDIR_DAP = loDatos.MMEDIR_DAP;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.ISUPERVISION_DET_EMADERABLE_ADICIONAL_Grabar", ocampoSuper);
                        }
                    }
                }
                #endregion
                #region ListISupervMaderableNoAutorizado
                if (oCEntidad.ListISupervMaderableNoAutorizado != null)
                {

                    foreach (var loDatos in oCEntidad.ListISupervMaderableNoAutorizado)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            //oCamposMad = new CEntSDetMarable();
                            ocampoSuper = new CEntidad();
                            ocampoSuper.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            ocampoSuper.COD_ESPECIES = loDatos.COD_ESPECIES;
                            ocampoSuper.DESC_ESPECIES = loDatos.DESC_ESPECIES;
                            ocampoSuper.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            ocampoSuper.BLOQUE = loDatos.BLOQUE;
                            ocampoSuper.FAJA = loDatos.FAJA;
                            ocampoSuper.CODIGO = loDatos.CODIGO;
                            ocampoSuper.DAP = loDatos.DAP;
                            ocampoSuper.AC = loDatos.AC;
                            ocampoSuper.ZONA = loDatos.ZONA;
                            ocampoSuper.COORDENADA_ESTE = loDatos.COORDENADA_ESTE;
                            ocampoSuper.COORDENADA_NORTE = loDatos.COORDENADA_NORTE;
                            ocampoSuper.COD_ECONDICION = loDatos.COD_ECONDICION;
                            ocampoSuper.COD_EESTADO = loDatos.COD_EESTADO;
                            ocampoSuper.DESC_EESTADO = loDatos.DESC_EESTADO;
                            //ocampoSuper.COD_ACATEGORIA = loDatos.COD_ACATEGORIA;
                            //ocampoSuper.DESC_ACATEGORIA_CITE = loDatos.DESC_ACATEGORIA_CITE;
                            //                     ocampoSuper.DESC_ACATEGORIA_DS = loDatos.DESC_ACATEGORIA_DS;
                            ocampoSuper.OBSERVACION = loDatos.OBSERVACION;
                            ocampoSuper.RegEstado = loDatos.RegEstado;
                            ocampoSuper.MAE_TIP_MADERABLE = loDatos.MAE_TIP_MADERABLE;
                            ocampoSuper.NUM_POA = loDatos.NUM_POA;
                            ocampoSuper.DAP1 = loDatos.DAP1 == -1 ? 0 : loDatos.DAP1;
                            ocampoSuper.DAP2 = loDatos.DAP2 == -1 ? 0 : loDatos.DAP2;
                            ocampoSuper.MAE_TIP_MMEDIRDAP = loDatos.MAE_TIP_MMEDIRDAP == "0000000" || loDatos.MAE_TIP_MMEDIRDAP == "" ? null : loDatos.MAE_TIP_MMEDIRDAP;
                            ocampoSuper.MMEDIR_DAP = loDatos.MMEDIR_DAP;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.ISUPERVISION_DET_EMADERABLE_ADICIONAL_Grabar", ocampoSuper);
                        }
                    }
                }
                #endregion
                #region ListISupervLindAreaVertice
                if (oCEntidad.ListISupervLindAreaVertice != null)
                {

                    foreach (var loDatos in oCEntidad.ListISupervLindAreaVertice)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            ocampoSuper = new CEntidad();
                            ocampoSuper.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            ocampoSuper.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            ocampoSuper.VERTICE = loDatos.VERTICE;
                            ocampoSuper.ZONA = loDatos.ZONA;
                            ocampoSuper.COORDENADA_ESTE = loDatos.COORDENADA_ESTE;
                            ocampoSuper.COORDENADA_NORTE = loDatos.COORDENADA_NORTE;
                            ocampoSuper.OBSERVACION = loDatos.OBSERVACION;
                            ocampoSuper.COD_UCUENTA = oCEntidad.COD_UCUENTA;
                            ocampoSuper.RegEstado = loDatos.RegEstado;
                            ocampoSuper.NUM_POA = loDatos.NUM_POA;

                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.ISUPERVISION_LINDAREA_VERTICE_Grabar", ocampoSuper);
                        }
                    }
                }
                #endregion
                #region ListISDSilvicultutal
                if (oCEntidad.ListISDSilvicultutal != null)
                {

                    foreach (var loDatos in oCEntidad.ListISDSilvicultutal)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            //oCampoSilv = new CEntISDSilvicultural();
                            ocampoSuper = new CEntidad();
                            ocampoSuper.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            ocampoSuper.COD_ASILVICULTURALES = loDatos.COD_ASILVICULTURALES;
                            ocampoSuper.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            ocampoSuper.COD_ESPECIES = loDatos.COD_ESPECIES;
                            ocampoSuper.FAJA = loDatos.FAJA;
                            ocampoSuper.NUM_PLANTULAS = loDatos.NUM_PLANTULAS;
                            ocampoSuper.UBICACION = loDatos.UBICACION;
                            ocampoSuper.TIEMPO = loDatos.TIEMPO;
                            ocampoSuper.CUMPLIMIENTO_ACTIVIDADES = loDatos.CUMPLIMIENTO_ACTIVIDADES;
                            ocampoSuper.OBSERVACION = loDatos.OBSERVACION;
                            ocampoSuper.NUM_POA = loDatos.NUM_POA;
                            ocampoSuper.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.ISUPERVISION_DET_ASILVICULTURALES_Grabar", ocampoSuper);
                        }
                    }
                }
                #endregion
                #region ListHuayronas
                if (oCEntidad.ListHuayronas != null)
                {

                    foreach (var loDatos in oCEntidad.ListHuayronas)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            //oCamposMad = new CEntSDetMarable();
                            ocampoSuper = new CEntidad();
                            ocampoSuper.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            ocampoSuper.NUMERO = loDatos.NUMERO;
                            ocampoSuper.ZONA = loDatos.ZONA;
                            ocampoSuper.COORDENADA_NORTE = loDatos.COORDENADA_NORTE;
                            ocampoSuper.COORDENADA_ESTE = loDatos.COORDENADA_ESTE;
                            ocampoSuper.VOLUMEN = loDatos.VOLUMEN;
                            ocampoSuper.NUM_POA = loDatos.NUM_POA;
                            ocampoSuper.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.ISUPERVISION_MADE_NOMADE_DET_PHUAYRONA_Grabar", ocampoSuper);
                        }
                    }
                }
                #endregion
                #region ListAvistamientoFauna
                if (oCEntidad.ListAvistamientoFauna != null)
                {

                    foreach (var loDatos in oCEntidad.ListAvistamientoFauna)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            ocampoSuper = new CEntidad();
                            ocampoSuper.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            ocampoSuper.COD_ESPECIES = loDatos.COD_ESPECIES;
                            ocampoSuper.DESC_ESPECIES = loDatos.DESC_ESPECIES;
                            ocampoSuper.NOMBRE_COMUN = loDatos.NOMBRE_COMUN;
                            ocampoSuper.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            ocampoSuper.NUM_INDIVIDUOS = loDatos.NUM_INDIVIDUOS;
                            ocampoSuper.COD_TIPO_REGISTRO = loDatos.COD_TIPO_REGISTRO;
                            ocampoSuper.DESC_TIPO_REGISTRO = loDatos.DESC_TIPO_REGISTRO;
                            ocampoSuper.COD_ESTRATO = loDatos.COD_ESTRATO;
                            ocampoSuper.DESC_ESTRATO = loDatos.DESC_ESTRATO;
                            ocampoSuper.FECHA_AVISTAMIENTO = loDatos.FECHA_AVISTAMIENTO;
                            ocampoSuper.HORA_AVISTAMIENTO = loDatos.HORA_AVISTAMIENTO;
                            ocampoSuper.ZONA = loDatos.ZONA;
                            ocampoSuper.COORDENADA_NORTE = loDatos.COORDENADA_NORTE;
                            ocampoSuper.COORDENADA_ESTE = loDatos.COORDENADA_ESTE;
                            ocampoSuper.ALTITUD = loDatos.ALTITUD;
                            ocampoSuper.DESCRIPCION = loDatos.DESCRIPCION;
                            ocampoSuper.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.ISUPERVISION_MADE_NOMADE_DET_AVISTAMIENTO_FAUNA_Grabar", ocampoSuper);
                        }
                    }
                }
                #endregion
                #region ListVolInjustificado - Comentado
                //if (oCEntidad.ListVolInjustificado != null)
                //{
                //	foreach (var loDatos in oCEntidad.ListVolInjustificado)
                //	{
                //		if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                //		{
                //			ocampoSuper = new CEntidad();
                //			ocampoSuper.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                //			ocampoSuper.COD_ENCIENTIFICO = loDatos.COD_ENCIENTIFICO;
                //			ocampoSuper.NOMBRE_CIENTIFICO = loDatos.NOMBRE_CIENTIFICO;
                //			ocampoSuper.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                //			ocampoSuper.NOMBRE_COMUN = loDatos.NOMBRE_COMUN;
                //			ocampoSuper.VOLUMEN = loDatos.VOLUMEN;
                //			ocampoSuper.NUM_POA = loDatos.NUM_POA;
                //			ocampoSuper.TIPOMADERABLE = loDatos.TIPOMADERABLE;
                //			ocampoSuper.OBSERVACION = loDatos.OBSERVACION;
                //			ocampoSuper.RegEstado = loDatos.RegEstado;
                //			dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.ISUPERVISION_MADE_NOMADE_DET_VOL_INJUSTIFICADO_Grabar", ocampoSuper);
                //		}
                //	}
                //}
                #endregion
                #region ListVolJustificado - Comentado
                //if (oCEntidad.ListVolJustificado != null)
                //{
                //	foreach (var loDatos in oCEntidad.ListVolJustificado)
                //	{
                //		if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                //		{
                //			ocampoSuper = new CEntidad();
                //			ocampoSuper.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                //			ocampoSuper.COD_ENCIENTIFICO = loDatos.COD_ENCIENTIFICO;
                //			ocampoSuper.NOMBRE_CIENTIFICO = loDatos.NOMBRE_CIENTIFICO;
                //			ocampoSuper.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                //			ocampoSuper.NOMBRE_COMUN = loDatos.NOMBRE_COMUN;
                //			ocampoSuper.VOLUMEN = loDatos.VOLUMEN;
                //			ocampoSuper.NUM_POA = loDatos.NUM_POA;
                //			ocampoSuper.TIPOMADERABLE = loDatos.TIPOMADERABLE;
                //			ocampoSuper.OBSERVACION = loDatos.OBSERVACION;
                //			ocampoSuper.JUSTIFICADO = loDatos.JUSTIFICADO;
                //			ocampoSuper.RegEstado = loDatos.RegEstado;
                //			dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.ISUPERVISION_MADE_NOMADE_DET_VOL_INJUSTIFICADO_Grabar", ocampoSuper);
                //		}
                //	}
                //}
                #endregion
                #region ListVolumen
                if (oCEntidad.ListVolumen != null)
                {
                    foreach (var loDatos in oCEntidad.ListVolumen)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            ocampoSuper = new CEntidad();
                            ocampoSuper.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            ocampoSuper.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            ocampoSuper.NUM_POA = loDatos.NUM_POA;
                            ocampoSuper.COD_ESPECIES = loDatos.COD_ESPECIES;
                            ocampoSuper.ESPECIES = loDatos.ESPECIES;
                            ocampoSuper.VOLUMEN_APROBADO = loDatos.VOLUMEN_APROBADO;
                            ocampoSuper.VOLUMEN_MOVILIZADO = loDatos.VOLUMEN_MOVILIZADO;
                            ocampoSuper.VOLUMEN_INJUSTIFICADO = loDatos.VOLUMEN_INJUSTIFICADO;
                            ocampoSuper.VOLUMEN_JUSTIFICADO = loDatos.VOLUMEN_JUSTIFICADO;
                            ocampoSuper.OBSERVACION = loDatos.OBSERVACION;
                            ocampoSuper.COD_UCUENTA = oCEntidad.COD_UCUENTA;
                            ocampoSuper.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spISUPERVISION_DET_VOLUMENGrabar", ocampoSuper);
                        }
                    }
                }
                #endregion
                #region ListOCEjecucionActividad
                if (oCEntidad.ListOCEjecucionActividad != null)
                {

                    foreach (var loDatos in oCEntidad.ListOCEjecucionActividad)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            ocampoSuper = new CEntidad();
                            ocampoSuper.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            ocampoSuper.COD_OCONTRACTUAL = loDatos.COD_OCONTRACTUAL;
                            ocampoSuper.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            ocampoSuper.COD_ESPECIES = "";
                            ocampoSuper.ACTIVIDAD_ACTOS = loDatos.ACTIVIDAD_ACTOS;
                            ocampoSuper.ESTA_AUTORIZADO = false;
                            ocampoSuper.DOCUMENTOS_AFORESTAL = "";
                            ocampoSuper.OBSERVACION = loDatos.OBSERVACION;
                            ocampoSuper.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spISUPERVISION_DET_OCONTRACTUALGrabar", ocampoSuper);
                        }
                    }
                }
                #endregion
                #region ListOCEspeciesExoticas
                if (oCEntidad.ListOCEspeciesExoticas != null)
                {
                    foreach (var loDatos in oCEntidad.ListOCEspeciesExoticas)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            ocampoSuper = new CEntidad();
                            ocampoSuper.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            ocampoSuper.COD_OCONTRACTUAL = loDatos.COD_OCONTRACTUAL;
                            ocampoSuper.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            ocampoSuper.COD_ESPECIES = "";
                            ocampoSuper.ACTIVIDAD_ACTOS = loDatos.ACTIVIDAD_ACTOS;
                            ocampoSuper.ESTA_AUTORIZADO = false;
                            ocampoSuper.DOCUMENTOS_AFORESTAL = "";
                            ocampoSuper.OBSERVACION = loDatos.OBSERVACION;
                            ocampoSuper.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spISUPERVISION_DET_OCONTRACTUALGrabar", ocampoSuper);
                        }
                    }
                }
                #endregion
                #region ListOCActosTercero
                if (oCEntidad.ListOCActosTercero != null)
                {
                    foreach (var loDatos in oCEntidad.ListOCActosTercero)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            ocampoSuper = new CEntidad();
                            ocampoSuper.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            ocampoSuper.COD_OCONTRACTUAL = loDatos.COD_OCONTRACTUAL;
                            ocampoSuper.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            ocampoSuper.COD_ESPECIES = "";
                            ocampoSuper.ACTIVIDAD_ACTOS = loDatos.ACTIVIDAD_ACTOS;
                            ocampoSuper.ESTA_AUTORIZADO = false;
                            ocampoSuper.DOCUMENTOS_AFORESTAL = loDatos.DOCUMENTOS_AFORESTAL;
                            ocampoSuper.OBSERVACION = "";
                            ocampoSuper.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spISUPERVISION_DET_OCONTRACTUALGrabar", ocampoSuper);
                        }
                    }
                }
                #endregion
                #region ListOCAprovechamientoDirecto
                if (oCEntidad.ListOCAprovechamientoDirecto != null)
                {
                    foreach (var loDatos in oCEntidad.ListOCAprovechamientoDirecto)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            ocampoSuper = new CEntidad();
                            ocampoSuper.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            ocampoSuper.COD_OCONTRACTUAL = loDatos.COD_OCONTRACTUAL;
                            ocampoSuper.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            ocampoSuper.COD_ESPECIES = loDatos.COD_ESPECIES;
                            ocampoSuper.ACTIVIDAD_ACTOS = "";
                            ocampoSuper.ESTA_AUTORIZADO = loDatos.ESTA_AUTORIZADO;
                            ocampoSuper.DOCUMENTOS_AFORESTAL = "";
                            ocampoSuper.OBSERVACION = loDatos.OBSERVACION;
                            ocampoSuper.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spISUPERVISION_DET_OCONTRACTUALGrabar", ocampoSuper);
                        }
                    }
                }
                #endregion
                #region ListINFORMEItemsDetalle
                //FORMATO CAMPO MODIFICAR
                if (oCEntidad.ListINFORMEItemsDetalle != null)
                {
                    foreach (var loDatos in oCEntidad.ListINFORMEItemsDetalle)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            ocampoSuper = new CEntidad();
                            ocampoSuper.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            ocampoSuper.COD_ESPECIES_CAMPO = loDatos.COD_ESPECIES_CAMPO == null ? "" : loDatos.COD_ESPECIES_CAMPO;
                            ocampoSuper.BLOQUE_CAMPO = loDatos.BLOQUE_CAMPO == null ? "" : loDatos.BLOQUE_CAMPO;
                            ocampoSuper.FAJA_CAMPO = loDatos.FAJA_CAMPO == null ? "" : loDatos.FAJA_CAMPO;
                            ocampoSuper.CODIGO_CAMPO = loDatos.CODIGO_CAMPO == null ? "" : loDatos.CODIGO_CAMPO;
                            ocampoSuper.DAP_CAMPO = loDatos.DAP_CAMPO == -1 ? 0 : loDatos.DAP_CAMPO;
                            ocampoSuper.AC_CAMPO = loDatos.AC_CAMPO == -1 ? 0 : loDatos.AC_CAMPO;
                            ocampoSuper.ZONA_CAMPO = loDatos.ZONA_CAMPO;
                            ocampoSuper.COORDENADA_ESTE_CAMPO = loDatos.COORDENADA_ESTE_CAMPO == -1 ? 0 : loDatos.COORDENADA_ESTE_CAMPO;
                            ocampoSuper.COORDENADA_NORTE_CAMPO = loDatos.COORDENADA_NORTE_CAMPO == -1 ? 0 : loDatos.COORDENADA_NORTE_CAMPO;
                            ocampoSuper.COD_EESTADO = loDatos.COD_EESTADO == null ? "" : loDatos.COD_EESTADO;
                            //ocampoSuper.COD_ACATEGORIA = loDatos.COD_ACATEGORIA == null ? "" : loDatos.COD_ACATEGORIA;
                            ocampoSuper.OBSERVACION_CAMPO = loDatos.OBSERVACION == null ? "" : loDatos.OBSERVACION_CAMPO;
                            ocampoSuper.COD_SISTEMA = loDatos.COD_SISTEMA;
                            ocampoSuper.RegEstado = loDatos.RegEstado;
                            ocampoSuper.DAP_CAMPO2 = loDatos.DAP_CAMPO2 == -1 ? 0 : loDatos.DAP_CAMPO2;
                            ocampoSuper.DAP_CAMPO1 = loDatos.DAP_CAMPO1 == -1 ? 0 : loDatos.DAP_CAMPO1;
                            ocampoSuper.COINCIDE_ESPECIES = loDatos.COINCIDE_ESPECIES;
                            ocampoSuper.MAE_TIP_MMEDIRDAP = loDatos.MAE_TIP_MMEDIRDAP == "0000000" || loDatos.MAE_TIP_MMEDIRDAP == "" ? null : loDatos.MAE_TIP_MMEDIRDAP;
                            ocampoSuper.MMEDIR_DAP = loDatos.MMEDIR_DAP;
                            ocampoSuper.COD_ECONDICION = loDatos.COD_ECONDICION == "0000000" || loDatos.COD_ECONDICION == "" ? null : loDatos.COD_ECONDICION;
                            ocampoSuper.DESC_ECONDICION = loDatos.DESC_ECONDICION;
                            ocampoSuper.CANT_SOBRE_ESTIMA_DIAMETRO = loDatos.CANT_SOBRE_ESTIMA_DIAMETRO;
                            ocampoSuper.PORC_SOBRE_ESTIMA_DIAMETRO = loDatos.PORC_SOBRE_ESTIMA_DIAMETRO;
                            ocampoSuper.CANT_SUB_ESTIMA_DIAMETRO = loDatos.CANT_SUB_ESTIMA_DIAMETRO;
                            ocampoSuper.PORC_SUB_ESTIMA_DIAMETRO = loDatos.PORC_SUB_ESTIMA_DIAMETRO;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.ISUPERVISION_DET_EMADERABLE_modificar", ocampoSuper);
                        }
                    }

                }
                #endregion
                #region ListISupervDevolTroza
                if (oCEntidad.ListISupervDevolTroza != null)
                {
                    foreach (var loDatos in oCEntidad.ListISupervDevolTroza)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            ocampoSuper = new CEntidad();
                            ocampoSuper.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            ocampoSuper.COD_THABILITANTE = loDatos.COD_THABILITANTE;
                            ocampoSuper.COD_DEVOLUCION = loDatos.COD_DEVOLUCION;
                            ocampoSuper.COD_ESPECIES = loDatos.COD_ESPECIES;
                            ocampoSuper.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            ocampoSuper.COD_ESPECIES_CAMPO = loDatos.COD_ESPECIES_CAMPO == null ? "" : loDatos.COD_ESPECIES_CAMPO; ;
                            ocampoSuper.CODIGO = loDatos.CODIGO_CAMPO == null ? "" : loDatos.CODIGO_CAMPO;
                            ocampoSuper.DAP = loDatos.DAP_CAMPO == -1 ? 0 : loDatos.DAP_CAMPO;
                            ocampoSuper.ALTURA = loDatos.ALTURA_CAMPO == -1 ? 0 : loDatos.ALTURA_CAMPO;
                            ocampoSuper.VOLUMEN = loDatos.VOLUMEN_CAMPO == -1 ? 0 : loDatos.VOLUMEN_CAMPO;
                            ocampoSuper.NUM_TROZAS = loDatos.NUM_TROZAS_CAMPO == -1 ? 0 : loDatos.NUM_TROZAS_CAMPO;
                            ocampoSuper.ZONA = loDatos.ZONA_CAMPO;
                            ocampoSuper.COORDENADA_ESTE = loDatos.COORDENADA_ESTE_CAMPO == -1 ? 0 : loDatos.COORDENADA_ESTE_CAMPO;
                            ocampoSuper.COORDENADA_NORTE = loDatos.COORDENADA_NORTE_CAMPO == -1 ? 0 : loDatos.COORDENADA_NORTE_CAMPO;
                            ocampoSuper.OBSERVACION = loDatos.OBSERVACION == null ? "" : loDatos.OBSERVACION;
                            ocampoSuper.ESTADO_SUPERVISION = loDatos.ESTADO_SUPERVISION;
                            ocampoSuper.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spISUPERVISION_DET_EDEV_TROZAGrabar", ocampoSuper);
                        }
                    }
                }
                #endregion
                #region ListISupervDevolTocon
                if (oCEntidad.ListISupervDevolTocon != null)
                {
                    foreach (var loDatos in oCEntidad.ListISupervDevolTocon)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            ocampoSuper = new CEntidad();
                            ocampoSuper.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            ocampoSuper.COD_THABILITANTE = loDatos.COD_THABILITANTE;
                            ocampoSuper.COD_DEVOLUCION = loDatos.COD_DEVOLUCION;
                            ocampoSuper.COD_ESPECIES = loDatos.COD_ESPECIES;
                            ocampoSuper.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            ocampoSuper.COD_ESPECIES_CAMPO = loDatos.COD_ESPECIES_CAMPO == null ? "" : loDatos.COD_ESPECIES_CAMPO; ;
                            ocampoSuper.CODIGO = loDatos.CODIGO_CAMPO == null ? "" : loDatos.CODIGO_CAMPO;
                            ocampoSuper.DIAMETRO = loDatos.DIAMETRO_CAMPO == -1 ? 0 : loDatos.DIAMETRO_CAMPO;
                            ocampoSuper.LARGO = loDatos.LARGO_CAMPO == -1 ? 0 : loDatos.LARGO_CAMPO;
                            ocampoSuper.VOLUMEN = loDatos.VOLUMEN_CAMPO == -1 ? 0 : loDatos.VOLUMEN_CAMPO;
                            ocampoSuper.CANTIDAD = loDatos.CANTIDAD_CAMPO == -1 ? 0 : loDatos.CANTIDAD_CAMPO;
                            ocampoSuper.ZONA = loDatos.ZONA_CAMPO;
                            ocampoSuper.COORDENADA_ESTE = loDatos.COORDENADA_ESTE_CAMPO == -1 ? 0 : loDatos.COORDENADA_ESTE_CAMPO;
                            ocampoSuper.COORDENADA_NORTE = loDatos.COORDENADA_NORTE_CAMPO == -1 ? 0 : loDatos.COORDENADA_NORTE_CAMPO;
                            ocampoSuper.OBSERVACION = loDatos.OBSERVACION == null ? "" : loDatos.OBSERVACION;
                            ocampoSuper.ESTADO_SUPERVISION = loDatos.ESTADO_SUPERVISION;
                            ocampoSuper.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spISUPERVISION_DET_EDEV_TOCONGrabar", ocampoSuper);
                        }
                    }
                }
                #endregion
                #region ListISupervDevolArbol
                if (oCEntidad.ListISupervDevolArbol != null)
                {
                    foreach (var loDatos in oCEntidad.ListISupervDevolArbol)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            ocampoSuper = new CEntidad();
                            ocampoSuper.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            ocampoSuper.COD_THABILITANTE = loDatos.COD_THABILITANTE;
                            ocampoSuper.COD_DEVOLUCION = loDatos.COD_DEVOLUCION;
                            ocampoSuper.COD_ESPECIES = loDatos.COD_ESPECIES;
                            ocampoSuper.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            ocampoSuper.COD_ESPECIES_CAMPO = loDatos.COD_ESPECIES_CAMPO == null ? "" : loDatos.COD_ESPECIES_CAMPO;
                            ocampoSuper.CODIGO = loDatos.CODIGO_CAMPO == null ? "" : loDatos.CODIGO_CAMPO;
                            ocampoSuper.NUM_PCA = loDatos.NUM_PCA_CAMPO == "" ? "" : loDatos.NUM_PCA_CAMPO.ToString();
                            ocampoSuper.DAP = loDatos.DAP_CAMPO == -1 ? 0 : loDatos.DAP_CAMPO;
                            ocampoSuper.ALTURA = loDatos.ALTURA_CAMPO == -1 ? 0 : loDatos.ALTURA_CAMPO;
                            ocampoSuper.VOLUMEN = loDatos.VOLUMEN_CAMPO == -1 ? 0 : loDatos.VOLUMEN_CAMPO;
                            ocampoSuper.ZONA = loDatos.ZONA_CAMPO;
                            ocampoSuper.COORDENADA_ESTE = loDatos.COORDENADA_ESTE_CAMPO == -1 ? 0 : loDatos.COORDENADA_ESTE_CAMPO;
                            ocampoSuper.COORDENADA_NORTE = loDatos.COORDENADA_NORTE_CAMPO == -1 ? 0 : loDatos.COORDENADA_NORTE_CAMPO;
                            ocampoSuper.COD_EESTADO = loDatos.COD_EESTADO == null ? "" : loDatos.COD_EESTADO;
                            //ocampoSuper.COD_ACATEGORIA = loDatos.COD_ACATEGORIA == null ? "" : loDatos.COD_ACATEGORIA;
                            ocampoSuper.OBSERVACION = loDatos.OBSERVACION == null ? "" : loDatos.OBSERVACION;
                            ocampoSuper.ESTADO_SUPERVISION = loDatos.ESTADO_SUPERVISION;
                            ocampoSuper.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spISUPERVISION_DET_EDEV_ARBOLGrabar", ocampoSuper);
                        }
                    }
                }
                #endregion
                #region ListFotos
                if (oCEntidad.ListFotos != null)
                {
                    foreach (var loDatos in oCEntidad.ListFotos)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            CEntidad ocampo = new CEntidad();
                            ocampo.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            ocampo.COD_INFORME_FOTOS = "";
                            ocampo.COD_THABILITANTE = loDatos.COD_THABILITANTE;
                            ocampo.COD_UCUENTA = loDatos.COD_UCUENTA;
                            ocampo.URL_FOTO = loDatos.URL_FOTO;
                            ocampo.FUENTE_FOTO = loDatos.FUENTE_FOTO;
                            ocampo.DISP_FOTO = loDatos.DISP_FOTO;
                            ocampo.DESC_FOTO = loDatos.DESC_FOTO;
                            ocampo.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spINFORME_FOTOSGrabar", ocampo);
                        }
                    }
                }
                #endregion
                #region ListMuestraNoMadeCarrizos
                if (oCEntidad.ListMuestraNoMadeCarrizos != null)
                {
                    foreach (var loDatos in oCEntidad.ListMuestraNoMadeCarrizos)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            CEntidad ocampo = new CEntidad();
                            ocampo.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            ocampo.COD_MUESTRA_SUPERVISION = loDatos.COD_MUESTRA_SUPERVISION;
                            ocampo.DESC_ESPECIES = loDatos.DESC_ESPECIES;
                            ocampo.TOTAL_UNIDADES = loDatos.TOTAL_UNIDADES;
                            ocampo.TOTAL_UNIDADES_APROVECHABLES = loDatos.TOTAL_UNIDADES_APROVECHABLES;
                            ocampo.ZONA = loDatos.ZONA;
                            ocampo.COORDENADA_ESTE = loDatos.COORDENADA_ESTE;
                            ocampo.COORDENADA_NORTE = loDatos.COORDENADA_NORTE;
                            ocampo.ALTURA_PROMEDIO = loDatos.ALTURA_PROMEDIO;
                            ocampo.OBSERVACION = loDatos.OBSERVACION;
                            ocampo.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.INFORME_MUESTRA_SUPERVISADAModificar", ocampo);
                        }
                    }
                }
                #endregion
                #region ListMuestraNoMadePMed
                // plantas medicinales
                if (oCEntidad.ListMuestraNoMadePMed != null)
                {
                    foreach (var loDatos in oCEntidad.ListMuestraNoMadePMed)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            CEntidad ocampo = new CEntidad();
                            ocampo.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            ocampo.COD_MUESTRA_SUPERVISION = loDatos.COD_MUESTRA_SUPERVISION;
                            ocampo.DESC_ESPECIES = loDatos.DESC_ESPECIES;
                            ocampo.UNIDAD_MEDIDA = loDatos.UNIDAD_MEDIDA;
                            ocampo.NUM_INDIVIDUOS = loDatos.NUM_INDIVIDUOS;
                            ocampo.ZONA = loDatos.ZONA;
                            ocampo.COORDENADA_ESTE = loDatos.COORDENADA_ESTE;
                            ocampo.COORDENADA_NORTE = loDatos.COORDENADA_NORTE;
                            ocampo.OBSERVACION = loDatos.OBSERVACION;
                            ocampo.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.INFORME_MUESTRA_SUPERVISADAMedicinalModificar", ocampo);
                        }
                    }
                }
                #endregion
                #region ListVerticesVerificar
                // vertices
                if (oCEntidad.ListVerticesVerificar != null)
                {
                    foreach (var loDatos in oCEntidad.ListVerticesVerificar)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            CEntidad ocampo = new CEntidad();
                            ocampo.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            ocampo.COD_INFORME_VERTICE = loDatos.COD_INFORME_VERTICE;
                            ocampo.VERTICE_POA = loDatos.VERTICE_POA;
                            ocampo.VERTICE_CAMPO = loDatos.VERTICE_CAMPO;
                            ocampo.ZONA = loDatos.ZONA;
                            ocampo.ZONA_CAMPO = loDatos.ZONA_CAMPO;
                            ocampo.COORDENADA_ESTE = loDatos.COORDENADA_ESTE;
                            ocampo.COORDENADA_ESTE_CAMPO = loDatos.COORDENADA_ESTE_CAMPO;
                            ocampo.COORDENADA_NORTE = loDatos.COORDENADA_NORTE;
                            ocampo.COORDENADA_NORTE_CAMPO = loDatos.COORDENADA_NORTE_CAMPO;
                            ocampo.OBSERVACION = loDatos.OBSERVACION;
                            ocampo.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.INFORME_VERTICEModificar", ocampo);
                        }
                    }
                }
                #endregion
                #region ListISupervCambioUso
                // CAMBIO DE USO
                if (oCEntidad.ListISupervCambioUso != null)
                {
                    foreach (var loDatos in oCEntidad.ListISupervCambioUso)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            CEntidad ocampo = new CEntidad();
                            ocampo.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            ocampo.MAE_TIP_CAMBIOUSO = loDatos.MAE_TIP_CAMBIOUSO;
                            ocampo.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            ocampo.AREA = loDatos.AREA;
                            ocampo.OBSERVACION = loDatos.OBSERVACION;
                            ocampo.AUTORIZADO = loDatos.AUTORIZADO;
                            ocampo.NUM_POA = loDatos.NUM_POA;
                            ocampo.COD_UCUENTA = oCEntidad.COD_UCUENTA;
                            ocampo.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.ISUPERVISION_CAMBIO_USO_Grabar", ocampo);
                        }
                    }
                }
                #endregion
                #region ListISupervInfoDocument
                // INFORMACIÓN DOCUMENTARIA DE LOS POA's
                if (oCEntidad.ListISupervInfoDocument != null)
                {
                    foreach (var loDatos in oCEntidad.ListISupervInfoDocument)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            CEntidad ocampo = new CEntidad();
                            ocampo.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            ocampo.NUM_POA = loDatos.NUM_POA;
                            ocampo.FEC_PRESENT_PM = loDatos.FEC_PRESENT_PM;
                            ocampo.FEC_APROB_PM = loDatos.FEC_APROB_PM;
                            ocampo.CUMPLE_PM_PGMF = loDatos.CUMPLE_PM_PGMF;
                            ocampo.OBSERV_PM_PGMF = loDatos.OBSERV_PM_PGMF;
                            ocampo.APROB_NORMAVIGENTE_PM = loDatos.APROB_NORMAVIGENTE_PM;
                            ocampo.OBSERV_NORMAVIGENTE_PM = loDatos.OBSERV_NORMAVIGENTE_PM;
                            ocampo.CUENTA_INFOEJECPO = loDatos.CUENTA_INFOEJECPO;
                            ocampo.FEC_PRESENT_INFOEJECPO = loDatos.FEC_PRESENT_INFOEJECPO;
                            ocampo.FEC_COMUNIC_INFOEJECPO = loDatos.FEC_COMUNIC_INFOEJECPO;
                            ocampo.CUMPLE_LINEA_INFOEJECPO = loDatos.CUMPLE_LINEA_INFOEJECPO;
                            ocampo.OBSERV_LINEA_INFOEJECPO = loDatos.OBSERV_LINEA_INFOEJECPO;
                            ocampo.CUMPLE_VIAL_PLANMAN = loDatos.CUMPLE_VIAL_PLANMAN;
                            ocampo.INDICIO_APROV = loDatos.INDICIO_APROV;
                            ocampo.OBSERV_APROV = loDatos.OBSERV_APROV;
                            ocampo.CUMPLE_PAGO_APROV = loDatos.CUMPLE_PAGO_APROV;
                            ocampo.OBSERV_PAGO_APROV = loDatos.OBSERV_PAGO_APROV;
                            ocampo.COD_RESODIREC_GRAVEDAD = loDatos.COD_RESODIREC_GRAVEDAD;
                            ocampo.LINDERAMIENTO_AREA = loDatos.LINDERAMIENTO_AREA;

                            ocampo.INEX_AGUAJAL = loDatos.INEX_AGUAJAL;
                            ocampo.INEX_AGUAJAL_PORC = loDatos.INEX_AGUAJAL_PORC;
                            ocampo.INEX_AGUAJAL_NOUB = loDatos.INEX_AGUAJAL_NOUB;
                            ocampo.INEX_AGUAJAL_OBS = loDatos.INEX_AGUAJAL_OBS;
                            ocampo.INEX_PASTIZAL = loDatos.INEX_PASTIZAL;
                            ocampo.INEX_PASTIZAL_PORC = loDatos.INEX_PASTIZAL_PORC;
                            ocampo.INEX_PASTIZAL_NOUB = loDatos.INEX_PASTIZAL_NOUB;
                            ocampo.INEX_PASTIZAL_OBS = loDatos.INEX_PASTIZAL_OBS;
                            ocampo.INEX_INACCESIBLE = loDatos.INEX_INACCESIBLE;
                            ocampo.INEX_INACCESIBLE_PORC = loDatos.INEX_INACCESIBLE_PORC;
                            ocampo.INEX_INACCESIBLE_NOUB = loDatos.INEX_INACCESIBLE_NOUB;
                            ocampo.INEX_INACCESIBLE_OBS = loDatos.INEX_INACCESIBLE_OBS;
                            ocampo.INEX_OTROS = loDatos.INEX_OTROS;
                            ocampo.INEX_OTROS_PORC = loDatos.INEX_OTROS_PORC;
                            ocampo.INEX_OTROS_NOUB = loDatos.INEX_OTROS_NOUB;
                            ocampo.INEX_OTROS_OBS = loDatos.INEX_OTROS_OBS;

                            ocampo.MAE_TIP_IEJECFOREST = loDatos.MAE_TIP_IEJECFOREST;
                            ocampo.FEC_ENTREGA_ACERVO = loDatos.FEC_ENTREGA_ACERVO;

                            ocampo.COD_TITULAR_EJECUTA = loDatos.COD_TITULAR_EJECUTA == "" ? null : loDatos.COD_TITULAR_EJECUTA;
                            ocampo.COD_REGENTE_IMPLEMENTA = loDatos.COD_REGENTE_IMPLEMENTA == "" ? null : loDatos.COD_REGENTE_IMPLEMENTA;
                            ocampo.MAE_EST_APROVECHA = loDatos.MAE_EST_APROVECHA;

                            ocampo.RECOMEND_REFORMULA = loDatos.RECOMEND_REFORMULA;
                            ocampo.RECOMEND_DESCRIPCION = loDatos.RECOMEND_DESCRIPCION;

                            ocampo.COD_UCUENTA = oCEntidad.COD_UCUENTA;
                            ocampo.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.ISUPERVISION_INFO_DOCUMENT_Grabar", ocampo);
                        }
                    }
                }
                #endregion
                #region ListISupervMadeNoMade
                // INFORMACIÓN MADERABLE|NO MADERABLE de los POS's
                if (oCEntidad.ListISupervMadeNoMade != null)
                {
                    foreach (var loDatos in oCEntidad.ListISupervMadeNoMade)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            CEntidad ocampo = new CEntidad();
                            ocampo.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            ocampo.NUM_POA = loDatos.NUM_POA;
                            ocampo.CUENTA_AREPOSICION = loDatos.CUENTA_AREPOSICION;
                            ocampo.AREA_DEMARCACION = loDatos.AREA_DEMARCACION;
                            ocampo.AREA_LINDERAMIENTO = loDatos.AREA_LINDERAMIENTO;
                            ocampo.TIPO_SAPROVECHAMIENTO = loDatos.TIPO_SAPROVECHAMIENTO;

                            ocampo.COD_UCUENTA = oCEntidad.COD_UCUENTA;
                            ocampo.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.ISUPERVISION_MADE_NOMADE_Grabar", ocampo);
                        }
                    }
                }
                #endregion
                #region ListTrozaCampo
                //Registro de Trozas
                if (oCEntidad.ListTrozaCampo != null)
                {
                    foreach (var loDatos in oCEntidad.ListTrozaCampo)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            CEntidad ocampo = new CEntidad();
                            ocampo.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            ocampo.COD_THABILITANTE = loDatos.COD_THABILITANTE;
                            ocampo.NUM_POA = loDatos.NUM_POA;
                            ocampo.COD_ESPECIES = loDatos.COD_ESPECIES;
                            ocampo.ESPECIES = loDatos.ESPECIES;
                            ocampo.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            ocampo.CODIGO = loDatos.CODIGO;
                            ocampo.ZONA = loDatos.ZONA;
                            ocampo.COORDENADA_ESTE = loDatos.COORDENADA_ESTE;
                            ocampo.COORDENADA_NORTE = loDatos.COORDENADA_NORTE;
                            ocampo.DAP1 = loDatos.DAP1;
                            ocampo.DAP2 = loDatos.DAP2;
                            ocampo.LC = loDatos.LC;
                            ocampo.OBSERVACION = loDatos.OBSERVACION;

                            ocampo.COD_UCUENTA = oCEntidad.COD_UCUENTA;
                            ocampo.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spISUPERVISION_DET_ETROZA_Grabar", ocampo);
                        }
                    }
                }
                #endregion
                #region ListMadeAserradaCampo
                //Registro de Madera Aserrada en Campo
                if (oCEntidad.ListMadeAserradaCampo != null)
                {
                    foreach (var loDatos in oCEntidad.ListMadeAserradaCampo)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            CEntidad ocampo = new CEntidad();
                            ocampo.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            ocampo.COD_THABILITANTE = loDatos.COD_THABILITANTE;
                            ocampo.NUM_POA = loDatos.NUM_POA;
                            ocampo.COD_ESPECIES = loDatos.COD_ESPECIES;
                            ocampo.ESPECIES = loDatos.ESPECIES;
                            ocampo.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            ocampo.CODIGO = loDatos.CODIGO;
                            ocampo.PIEZAS = loDatos.PIEZAS;
                            ocampo.ZONA = loDatos.ZONA;
                            ocampo.COORDENADA_ESTE = loDatos.COORDENADA_ESTE;
                            ocampo.COORDENADA_NORTE = loDatos.COORDENADA_NORTE;
                            ocampo.ESPESOR = loDatos.ESPESOR;
                            ocampo.ANCHO = loDatos.ANCHO;
                            ocampo.LARGO = loDatos.LARGO;
                            ocampo.OBSERVACION = loDatos.OBSERVACION;

                            ocampo.COD_UCUENTA = oCEntidad.COD_UCUENTA;
                            ocampo.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spISUPERVISION_DET_EASERRADA_Grabar", ocampo);
                        }
                    }
                }
                #endregion
                #region ListTHVerticeCampo
                //Registro de Vertices de Título Habilitante obtenido en Campo
                if (oCEntidad.ListTHVerticeCampo != null)
                {
                    foreach (var loDatos in oCEntidad.ListTHVerticeCampo)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            CEntidad ocampo = new CEntidad();
                            ocampo.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            ocampo.COD_THABILITANTE = loDatos.COD_THABILITANTE;
                            ocampo.COD_SECUENCIAL_ADENDA = loDatos.COD_SECUENCIAL_ADENDA;
                            ocampo.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            ocampo.COD_SISTEMA = loDatos.COD_SISTEMA;
                            ocampo.VERTICE = loDatos.VERTICE_CAMPO;
                            ocampo.ZONA = loDatos.ZONA_CAMPO;
                            ocampo.COORDENADA_ESTE = loDatos.COORDENADA_ESTE_CAMPO;
                            ocampo.COORDENADA_NORTE = loDatos.COORDENADA_NORTE_CAMPO;
                            ocampo.OBSERVACION = loDatos.OBSERVACION_CAMPO;

                            ocampo.COD_UCUENTA = oCEntidad.COD_UCUENTA;
                            ocampo.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spISUPERVISION_DET_VERTICE_THABILITANTE_Grabar", ocampo);
                        }
                    }
                }
                #endregion
                #region ListEvaluacionOtros
                //Registro de otros puntos de evaluación
                if (oCEntidad.ListEvaluacionOtros != null)
                {
                    foreach (var loDatos in oCEntidad.ListEvaluacionOtros)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            CEntidad ocampo = new CEntidad();
                            ocampo.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            ocampo.COD_THABILITANTE = loDatos.COD_THABILITANTE;
                            ocampo.NUM_POA = loDatos.NUM_POA;
                            ocampo.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            ocampo.EVALUACION = loDatos.EVALUACION;
                            ocampo.ZONA = loDatos.ZONA;
                            ocampo.COORDENADA_ESTE = loDatos.COORDENADA_ESTE;
                            ocampo.COORDENADA_NORTE = loDatos.COORDENADA_NORTE;
                            ocampo.DESCRIPCION = loDatos.DESCRIPCION;

                            ocampo.COD_UCUENTA = oCEntidad.COD_UCUENTA;
                            ocampo.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.ISUPERVISION_DET_EVALUACION_OTROS_Grabar", ocampo);
                        }
                    }
                }
                #endregion

                #region List POA Publicar
                //Registro de POA's a Publicar
                if (oCEntidad.ListPOAs != null)
                {
                    foreach (var loDatos in oCEntidad.ListPOAs)
                    {
                        CEntidad ocampo = new CEntidad();
                        ocampo.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                        ocampo.NUM_POA = loDatos.NUM_POA;
                        ocampo.PUBLICAR = loDatos.PUBLICAR;
                        ocampo.SUPERVISADO = loDatos.SUPERVISADO;
                        // object[] param = { ocampo.COD_INFORME, ocampo.NUM_POA, ocampo.PUBLICAR, ocampo.SUPERVISADO, loDatos.CODIGO_SEC_NOPOA };
                        dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.ISUPERVISION_INFO_DOCUMENT_Modificar", ocampo);
                    }
                }
                #endregion

                //Registro de DESPLAZAMIENTO
                if (oCEntidad.ListDesplazamientoInforme != null)
                {
                    foreach (var loDatos in oCEntidad.ListDesplazamientoInforme)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            CEntidad ocampo = new CEntidad();
                            ocampo.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            if (loDatos.COD_DESPLAZAMIENTO == null)
                            {
                                ocampo.COD_DESPLAZAMIENTO = "";
                            }
                            else
                            {
                                ocampo.COD_DESPLAZAMIENTO = loDatos.COD_DESPLAZAMIENTO;
                            }
                            ocampo.PTOI_COORDENADA_ESTE = loDatos.COORDENADA_ESTE;
                            ocampo.PTOI_COORDENADA_NORTE = loDatos.COORDENADA_NORTE;
                            ocampo.PTOF_COORDENADA_ESTE = loDatos.COORDENADA_ESTE_CAMPO;
                            ocampo.PTOF_COORDENADA_NORTE = loDatos.COORDENADA_NORTE_CAMPO;
                            ocampo.OBSERVACION = loDatos.OBSERVACION;
                            ocampo.TIPO = loDatos.TipoVia;
                            ocampo.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spINFORME_DESPLAZAMIENTOGrabar", ocampo);
                        }
                    }
                }
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

        //
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public CEntidad RegMostrarListaItem(OracleConnection cn, String codInforme)
        {
            CEntidad lsCEntidad = new CEntidad();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spINFORMEMostrarItem", codInforme))
                {
                    if (dr != null)
                    {
                        lsCEntidad.ListEliTABLA = new List<CEntidad>();

                        lsCEntidad.ListInformeDetSupervisor = new List<CEntPersona>();
                        lsCEntidad.ListCNotificaciones = new List<CEntidad>();
                        lsCEntidad.ListISDSilvicultutal = new List<CEntidad>();
                        lsCEntidad.ListHuayronas = new List<CEntidad>();
                        lsCEntidad.ListISupervMaderableAdicional = new List<CEntidad>();
                        lsCEntidad.ListISupervMaderableAprov = new List<CEntidad>();
                        lsCEntidad.ListISupervMaderableSemillero = new List<CEntidad>();
                        lsCEntidad.ListISupervNoMaderableAprov = new List<CEntidad>();
                        lsCEntidad.ListISupervNoMaderableSemillero = new List<CEntidad>();

                        lsCEntidad.LisCautiverioECapturado = new List<CEntISExsitu>();
                        lsCEntidad.LisCapacitacionFauna = new List<CEntISExsitu>();

                        lsCEntidad.ListOCEjecucionActividad = new List<CEntidad>();
                        lsCEntidad.ListOCEspeciesExoticas = new List<CEntidad>();
                        lsCEntidad.ListOCActosTercero = new List<CEntidad>();
                        lsCEntidad.ListOCAprovechamientoDirecto = new List<CEntidad>();
                        lsCEntidad.ListISupervDevolTroza = new List<CEntidad>();
                        lsCEntidad.ListISupervDevolTocon = new List<CEntidad>();
                        lsCEntidad.ListISupervDevolArbol = new List<CEntidad>();
                        lsCEntidad.ListAvistamientoFauna = new List<CEntidad>();
                        //lsCEntidad.ListVolInjustificado = new List<CEntidad>();
                        //lsCEntidad.ListVolJustificado = new List<CEntidad>();

                        lsCEntidad.ListFotos = new List<CEntidad>();
                        lsCEntidad.ListMuestraNoMadeCarrizos = new List<CEntidad>(); // muestra de listas carrizos
                        lsCEntidad.ListMuestraNoMadePMed = new List<CEntidad>();//muestra de lista plantas medicinales
                        lsCEntidad.ListVerticesVerificar = new List<CEntidad>();//lista de vertices

                        lsCEntidad.ListISupervMaderableNoAutorizado = new List<CEntidad>();
                        lsCEntidad.ListISupervCambioUso = new List<CEntidad>();
                        lsCEntidad.ListISupervLindAreaVertice = new List<CEntidad>();
                        lsCEntidad.ListISupervInfoDocument = new List<CEntidad>();
                        lsCEntidad.ListISupervMadeNoMade = new List<CEntidad>();

                        lsCEntidad.ListTrozaCampo = new List<CEntidad>();
                        lsCEntidad.ListMadeAserradaCampo = new List<CEntidad>();
                        lsCEntidad.ListTHVerticeCampo = new List<CEntidad>();
                        lsCEntidad.ListTHVertice = new List<CEntidad>();
                        lsCEntidad.ListEvaluacionOtros = new List<CEntidad>();

                        lsCEntidad.ListVolumen = new List<CEntidad>();
                        lsCEntidad.ListPOAs = new List<CEntidad>();

                        lsCEntidad.ListDesplazamientoInforme = new List<CEntidad>();

                        //CEntPresupSuper ocampodet;
                        CEntidad ocampoEnt;
                        CEntPersona ocampoEntPersona;
                        #region DATOS GENERALES
                        if (dr.HasRows)
                        {
                            dr.Read();
                            lsCEntidad.COD_ITIPO = dr.GetString(dr.GetOrdinal("COD_ITIPO"));
                            lsCEntidad.COD_CNOTIFICACION = dr.GetString(dr.GetOrdinal("COD_CNOTIFICACION"));
                            lsCEntidad.NUMERO = dr.GetString(dr.GetOrdinal("NUMERO"));
                            lsCEntidad.COD_DIRECTOR = dr.GetString(dr.GetOrdinal("COD_DIRECTOR"));
                            lsCEntidad.NOMBRE_DIRECTOR = dr.GetString(dr.GetOrdinal("APELLIDOS_NOMBRES"));
                            lsCEntidad.COD_IMOTIVO = dr.GetString(dr.GetOrdinal("COD_IMOTIVO"));
                            lsCEntidad.FECHA_ENTREGA = dr.GetString(dr.GetOrdinal("FECHA_ENTREGA"));
                            lsCEntidad.FECHA_RECEPCION_OD = dr.GetString(dr.GetOrdinal("FECHA_RECEPCION_OD"));
                            lsCEntidad.FECHA_RECEPCION_SCENTRAL = dr.GetString(dr.GetOrdinal("FECHA_RECEPCION_SCENTRAL"));
                            lsCEntidad.UBIGEO = dr.GetString(dr.GetOrdinal("UBIGEO"));
                            lsCEntidad.NUM_POA = dr.GetInt32(dr.GetOrdinal("NUM_POA"));
                            lsCEntidad.NUM_THABILITANTE = dr.GetString(dr.GetOrdinal("NUM_THABILITANTE"));
                            //lsCEntidad.CUENTA_AREPOSICION = dr.GetString(dr.GetOrdinal("CUENTA_AREPOSICION"));
                            //lsCEntidad.AREA_DEMARCACION = dr.GetString(dr.GetOrdinal("AREA_DEMARCACION"));
                            //lsCEntidad.AREA_LINDERAMIENTO = dr.GetString(dr.GetOrdinal("AREA_LINDERAMIENTO"));
                            ///*lsCEntidad.USO_LCALONGITUDINAL = dr.GetBoolean(dr.GetOrdinal("USO_LCALONGITUDINAL"));*/
                            //lsCEntidad.TIPO_SAPROVECHAMIENTO = dr.GetString(dr.GetOrdinal("TIPO_SAPROVECHAMIENTO"));
                            lsCEntidad.OBSERVACION = dr.GetString(dr.GetOrdinal("OBSERVACION"));
                            lsCEntidad.THABILITANTE_SECTOR = dr.GetString(dr.GetOrdinal("THABILITANTE_SECTOR"));
                            lsCEntidad.THABILITANTE_COD_UBIGEO = dr.GetString(dr.GetOrdinal("THABILITANTE_COD_UBIGEO"));
                            lsCEntidad.PHUAYRONA_ESTADO = dr.GetString(dr.GetOrdinal("PHUAYRONA_ESTADO"));
                            lsCEntidad.NUM_CNOTIFICACION = dr.GetString(dr.GetOrdinal("NUM_CNOTIFICACION"));
                            lsCEntidad.FECHA_SUPERVISION_INICIO = dr.GetString(dr.GetOrdinal("FECHA_SUPERVISION_INICIO"));
                            lsCEntidad.FECHA_SUPERVISION_FIN = dr.GetString(dr.GetOrdinal("FECHA_SUPERVISION_FIN"));
                            lsCEntidad.ASUNTO = dr.GetString(dr.GetOrdinal("ASUNTO"));
                            lsCEntidad.CONTENIDO = dr.GetString(dr.GetOrdinal("CONTENIDO"));
                            lsCEntidad.AREA_RECORRIDA = dr.GetDecimal(dr.GetOrdinal("AREA_RECORRIDA"));
                            lsCEntidad.CUENTA_MILEGAL = dr.GetBoolean(dr.GetOrdinal("CUENTA_MILEGAL"));
                            lsCEntidad.AREA_MILEGAL = dr.GetDecimal(dr.GetOrdinal("AREA_MILEGAL"));
                            lsCEntidad.OBSERVACION_MILEGAL = dr.GetString(dr.GetOrdinal("OBSERVACION_MILEGAL"));//COD_DLINEA
                            lsCEntidad.COD_DLINEA = dr.GetString(dr.GetOrdinal("COD_DLINEA"));
                            lsCEntidad.COD_ESTADO_DOC = dr.GetString(dr.GetOrdinal("COD_ESTADO_DOC"));
                            lsCEntidad.OBSERVACIONES_CONTROL = dr.GetString(dr.GetOrdinal("OBSERVACIONES_CONTROL"));
                            lsCEntidad.OBSERV_SUBSANAR = dr.GetBoolean(dr.GetOrdinal("OBSERV_SUBSANAR"));
                            lsCEntidad.COD_OD_REGISTRO = dr.GetString(dr.GetOrdinal("COD_OD_REGISTRO"));
                            lsCEntidad.PLAN_AMAZONAS = dr.GetBoolean(dr.GetOrdinal("PLAN_AMAZONAS"));
                            lsCEntidad.ANIO_PLAN_AMAZONAS = dr.GetString(dr.GetOrdinal("ANIO_PLAN_AMAZONAS"));
                            //lsCEntidad.INEX_AGUAJAL = dr.GetBoolean(dr.GetOrdinal("INEX_AGUAJAL"));
                            //lsCEntidad.INEX_AGUAJAL_PORC = dr.GetDecimal(dr.GetOrdinal("INEX_AGUAJAL_PORC"));
                            //lsCEntidad.INEX_AGUAJAL_NOUB = dr.GetInt32(dr.GetOrdinal("INEX_AGUAJAL_NOUB"));
                            //lsCEntidad.INEX_AGUAJAL_OBS = dr.GetString(dr.GetOrdinal("INEX_AGUAJAL_OBS"));
                            //lsCEntidad.INEX_PASTIZAL = dr.GetBoolean(dr.GetOrdinal("INEX_PASTIZAL"));
                            //lsCEntidad.INEX_PASTIZAL_PORC = dr.GetDecimal(dr.GetOrdinal("INEX_PASTIZAL_PORC"));
                            //lsCEntidad.INEX_PASTIZAL_NOUB = dr.GetInt32(dr.GetOrdinal("INEX_PASTIZAL_NOUB"));
                            //lsCEntidad.INEX_PASTIZAL_OBS = dr.GetString(dr.GetOrdinal("INEX_PASTIZAL_OBS"));
                            //lsCEntidad.INEX_INACCESIBLE = dr.GetBoolean(dr.GetOrdinal("INEX_INACCESIBLE"));
                            //lsCEntidad.INEX_INACCESIBLE_PORC = dr.GetDecimal(dr.GetOrdinal("INEX_INACCESIBLE_PORC"));
                            //lsCEntidad.INEX_INACCESIBLE_NOUB = dr.GetInt32(dr.GetOrdinal("INEX_INACCESIBLE_NOUB"));
                            //lsCEntidad.INEX_INACCESIBLE_OBS = dr.GetString(dr.GetOrdinal("INEX_INACCESIBLE_OBS"));
                            //lsCEntidad.INEX_OTROS = dr.GetBoolean(dr.GetOrdinal("INEX_OTROS"));
                            //lsCEntidad.INEX_OTROS_PORC = dr.GetDecimal(dr.GetOrdinal("INEX_OTROS_PORC"));
                            //lsCEntidad.INEX_OTROS_NOUB = dr.GetInt32(dr.GetOrdinal("INEX_OTROS_NOUB"));
                            //lsCEntidad.INEX_OTROS_OBS = dr.GetString(dr.GetOrdinal("INEX_OTROS_OBS"));
                            lsCEntidad.ID_TRAMITE_SITD = dr.GetInt32(dr.GetOrdinal("ID_TRAMITE_SITD"));
                            lsCEntidad.PROMOVIDO = dr.GetBoolean(dr.GetOrdinal("PROMOVIDO"));
                            lsCEntidad.COD_REQUE = dr.GetInt32(dr.GetOrdinal("COD_REQ"));
                            //NIVEL DE RIESGO
                            //lsCEntidad.NIVEL_RIESGO = dr.GetString(dr.GetOrdinal("NIVEL_RIESGO"));
                            //lsCEntidad.TIPO_RIESGO = dr.GetString(dr.GetOrdinal("TIPO_RIESGO"));
                            //lsCEntidad.OBSERVACION_RIESGO = dr.GetString(dr.GetOrdinal("OBSERVACION_RIESGO"));

                            lsCEntidad.CONCLUSION = dr.GetString(dr.GetOrdinal("CONCLUSION"));
                            lsCEntidad.PUBLICAR = dr.GetBoolean(dr.GetOrdinal("PUBLICAR"));

                            //Nuevos campos: 21/11/2016
                            lsCEntidad.REALIZADO_VEEDORFORESTAL = dr.GetBoolean(dr.GetOrdinal("REALIZADO_VEEDORFORESTAL"));
                            //lsCEntidad.CUMPLE_VIALES_PLANMANEJO= dr.GetBoolean(dr.GetOrdinal("CUMPLE_VIALES_PLANMANEJO"));
                            //lsCEntidad.INDICIO_APROVECHAMIENTO= dr.GetBoolean(dr.GetOrdinal("INDICIO_APROVECHAMIENTO"));
                            //lsCEntidad.OBSERVACION_APROVECHAMIENTO= dr.GetString(dr.GetOrdinal("OBSERVACION_APROVECHAMIENTO"));
                            //lsCEntidad.CUMPLIMIENTO_PAGO_APROV = dr.GetBoolean(dr.GetOrdinal("CUMPLIMIENTO_PAGO_APROV"));
                            //lsCEntidad.OBSERVACION_PAGO_APROV = dr.GetString(dr.GetOrdinal("OBSERVACION_PAGO_APROV"));
                            //lsCEntidad.COD_RESODIREC_GRAVEDAD = dr.GetString(dr.GetOrdinal("COD_RESODIREC_GRAVEDAD"));
                            //lsCEntidad.LINDERAMIENTO_AREA= dr.GetString(dr.GetOrdinal("LINDERAMIENTO_AREA"));
                            lsCEntidad.USUARIO_REGISTRO = dr.GetString(dr.GetOrdinal("USUARIO_REGISTRO"));
                            lsCEntidad.USUARIO_CONTROL = dr.GetString(dr.GetOrdinal("USUARIO_CONTROL"));

                            //lsCEntidad.MAE_EST_APROVECHA = dr.GetString(dr.GetOrdinal("MAE_EST_APROVECHA"));

                            lsCEntidad.GEOTEC_DESCRIPCION = dr.GetString(dr.GetOrdinal("GEOTEC_DESCRIPCION"));
                            lsCEntidad.GEOTEC_DRON = dr.GetBoolean(dr.GetOrdinal("GEOTEC_DRON"));
                            lsCEntidad.GEOTEC_GEOSUPERVISOR = dr.GetBoolean(dr.GetOrdinal("GEOTEC_GEOSUPERVISOR"));
                            lsCEntidad.GEOTEC_NINGUNO = dr.GetBoolean(dr.GetOrdinal("GEOTEC_NINGUNO"));
                            lsCEntidad.GEOTEC_OTROS = dr.GetBoolean(dr.GetOrdinal("GEOTEC_OTROS"));
                            lsCEntidad.IMOTIVO = dr.GetString(dr.GetOrdinal("IMOTIVO"));
                            lsCEntidad.MAE_TIP_MOTMOTIVADA = dr.GetString(dr.GetOrdinal("MAE_TIP_MOTMOTIVADA"));
                            lsCEntidad.COD_TRAMITE_SITD = dr.GetInt32(dr.GetOrdinal("COD_TRAMITE_SITD"));
                            lsCEntidad.NUM_DREFERENCIA = dr.GetString(dr.GetOrdinal("NUM_DREFERENCIA"));

                            //14/08/2018 Disposiciones Administrativas
                            //1
                            lsCEntidad.DISADM_APROBPMF = dr.GetString(dr.GetOrdinal("DISADM_APROBPMF"));
                            lsCEntidad.DISADM_APROBPMF_DESCRIPCION = dr.GetString(dr.GetOrdinal("DISADM_APROBPMF_DESCRIPCION"));
                            //2
                            lsCEntidad.DISADM_IODESARROLLOLINEAMIENTOS = dr.GetString(dr.GetOrdinal("DISADM_IODESARROLLOLINEAMIENTOS"));
                            lsCEntidad.DISADM_IODESARROLLOLINEAMIENTOS_DESCRIPCION = dr.GetString(dr.GetOrdinal("DISADM_IODESARROLLOLINEAMIENTOS_DESCRIPCION"));
                            //3
                            lsCEntidad.DISADM_AUTORIDADAPROBOPMF = dr.GetString(dr.GetOrdinal("DISADM_AUTORIDADAPROBOPMF"));
                            lsCEntidad.DISADM_AUTORIDADAPROBOPMF_DESCRIPCION = dr.GetString(dr.GetOrdinal("DISADM_AUTORIDADAPROBOPMF_DESCRIPCION"));
                            //4
                            lsCEntidad.DISADM_ESPECIESCORRESPONDEPMF = dr.GetString(dr.GetOrdinal("DISADM_ESPECIESCORRESPONDEPMF"));
                            lsCEntidad.DISADM_ESPECIESCORRESPONDEPMF_DESCRIPCION = dr.GetString(dr.GetOrdinal("DISADM_ESPECIESCORRESPONDEPMF_DESCRIPCION"));
                            //5
                            lsCEntidad.DISADM_AUTORIDADNOTIFICOTITULAR = dr.GetString(dr.GetOrdinal("DISADM_AUTORIDADNOTIFICOTITULAR"));
                            lsCEntidad.DISADM_AUTORIDADNOTIFICOTITULAR_DESCRIPCION = dr.GetString(dr.GetOrdinal("DISADM_AUTORIDADNOTIFICOTITULAR_DESCRIPCION"));
                            //6
                            lsCEntidad.DISADM_AUTORIDAREMITIOCOPIA = dr.GetString(dr.GetOrdinal("DISADM_AUTORIDAREMITIOCOPIA"));
                            lsCEntidad.DISADM_AUTORIDAREMITIOCOPIA_DESCRIPCION = dr.GetString(dr.GetOrdinal("DISADM_AUTORIDAREMITIOCOPIA_DESCRIPCION"));
                            //7
                            lsCEntidad.DISADM_TITULARENTREGOINFORMACION = dr.GetString(dr.GetOrdinal("DISADM_TITULARENTREGOINFORMACION"));
                            lsCEntidad.DISADM_TITULARENTREGOINFORMACION_DESCRIPCION = dr.GetString(dr.GetOrdinal("DISADM_TITULARENTREGOINFORMACION_DESCRIPCION"));
                            //8
                            lsCEntidad.DISADM_MAPACONTIENEINFORMACION = dr.GetString(dr.GetOrdinal("DISADM_MAPACONTIENEINFORMACION"));
                            lsCEntidad.DISADM_MAPACONTIENEINFORMACION_DESCRIPCION = dr.GetString(dr.GetOrdinal("DISADM_MAPACONTIENEINFORMACION_DESCRIPCION"));
                            //9
                            lsCEntidad.DISADM_ARFFSATENDIOSOLICITUD = dr.GetString(dr.GetOrdinal("DISADM_ARFFSATENDIOSOLICITUD"));
                            lsCEntidad.DISADM_ARFFSATENDIOSOLICITUD_DESCRIPCION = dr.GetString(dr.GetOrdinal("DISADM_ARFFSATENDIOSOLICITUD_DESCRIPCION"));
                            //10
                            lsCEntidad.DISADM_VIGENTEGARANTIA = dr.GetString(dr.GetOrdinal("DISADM_VIGENTEGARANTIA"));
                            lsCEntidad.DISADM_VIGENTEGARANTIA_DESCRIPCION = dr.GetString(dr.GetOrdinal("DISADM_VIGENTEGARANTIA_DESCRIPCION"));


                            // 14/08/2018 Obligacion Titulares TH Maderables
                            //1
                            lsCEntidad.OBLI_PRESENTOPLANMANEJO = dr.GetString(dr.GetOrdinal("OBLI_PRESENTOPLANMANEJO"));
                            lsCEntidad.OBLI_PRESENTOPLANMANEJO_DESCRIPCION = dr.GetString(dr.GetOrdinal("OBLI_PRESENTOPLANMANEJO_DESCRIPCION"));
                            //2
                            lsCEntidad.OBLI_PRESENTOPLANMANEJOCONFORMIDAD = dr.GetString(dr.GetOrdinal("OBLI_PRESENTOPLANMANEJOCONFORMIDAD"));
                            lsCEntidad.OBLI_PRESENTOPLANMANEJOCONFORMIDAD_DESCRIPCION = dr.GetString(dr.GetOrdinal("OBLI_PRESENTOPLANMANEJOCONFORMIDAD_DESCRIPCION"));
                            //3
                            lsCEntidad.OBLI_PAGOAPROVECHAMIENTO = dr.GetString(dr.GetOrdinal("OBLI_PAGOAPROVECHAMIENTO"));
                            lsCEntidad.OBLI_PAGOAPROVECHAMIENTO_DESCRIPCION = dr.GetString(dr.GetOrdinal("OBLI_PAGOAPROVECHAMIENTO_DESCRIPCION"));
                            //4
                            lsCEntidad.OBLI_MANTIENELIBROOPERACIONES = dr.GetString(dr.GetOrdinal("OBLI_MANTIENELIBROOPERACIONES"));
                            lsCEntidad.OBLI_MANTIENELIBROOPERACIONES_DESCRIPCION = dr.GetString(dr.GetOrdinal("OBLI_MANTIENELIBROOPERACIONES_DESCRIPCION"));
                            //5
                            lsCEntidad.OBLI_COMUNICOARFFSOSINFORSUSCRIPCION = dr.GetString(dr.GetOrdinal("OBLI_COMUNICOARFFSOSINFORSUSCRIPCION"));
                            lsCEntidad.OBLI_COMUNICOARFFSOSINFORSUSCRIPCION_DESCRIPCION = dr.GetString(dr.GetOrdinal("OBLI_COMUNICOARFFSOSINFORSUSCRIPCION_DESCRIPCION"));
                            //6
                            lsCEntidad.OBLI_REPORTOARFFSMINISTERIOAVISTAMIENTOS = dr.GetString(dr.GetOrdinal("OBLI_REPORTOARFFSMINISTERIOAVISTAMIENTOS"));
                            lsCEntidad.OBLI_REPORTOARFFSMINISTERIOAVISTAMIENTOS_DESCRIPCION = dr.GetString(dr.GetOrdinal("OBLI_REPORTOARFFSMINISTERIOAVISTAMIENTOS_DESCRIPCION"));
                            //7
                            lsCEntidad.OBLI_REALIZOACCIONESCUSTODIO = dr.GetString(dr.GetOrdinal("OBLI_REALIZOACCIONESCUSTODIO"));
                            lsCEntidad.OBLI_REALIZOACCIONESCUSTODIO_DESCRIPCION = dr.GetString(dr.GetOrdinal("OBLI_REALIZOACCIONESCUSTODIO_DESCRIPCION"));
                            //8
                            lsCEntidad.OBLI_FACILITODESARROLLO = dr.GetString(dr.GetOrdinal("OBLI_FACILITODESARROLLO"));
                            lsCEntidad.OBLI_FACILITODESARROLLO_DESCRIPCION = dr.GetString(dr.GetOrdinal("OBLI_FACILITODESARROLLO_DESCRIPCION"));
                            //9
                            lsCEntidad.OBLI_ASUMIOCOSTOSUPERVISIONES = dr.GetString(dr.GetOrdinal("OBLI_ASUMIOCOSTOSUPERVISIONES"));
                            lsCEntidad.OBLI_ASUMIOCOSTOSUPERVISIONES_DESCRIPCION = dr.GetString(dr.GetOrdinal("OBLI_ASUMIOCOSTOSUPERVISIONES_DESCRIPCION"));
                            //10
                            lsCEntidad.OBLI_IMPLEMENTAMECANISMOTRAZA = dr.GetString(dr.GetOrdinal("OBLI_IMPLEMENTAMECANISMOTRAZA"));
                            lsCEntidad.OBLI_IMPLEMENTAMECANISMOTRAZA_DESCRIPCION = dr.GetString(dr.GetOrdinal("OBLI_IMPLEMENTAMECANISMOTRAZA_DESCRIPCION"));
                            //11
                            lsCEntidad.OBLI_RESPETASERVIDUMBRE = dr.GetString(dr.GetOrdinal("OBLI_RESPETASERVIDUMBRE"));
                            lsCEntidad.OBLI_RESPETASERVIDUMBRE_DESCRIPCION = dr.GetString(dr.GetOrdinal("OBLI_RESPETASERVIDUMBRE_DESCRIPCION"));
                            //12
                            lsCEntidad.OBLI_CUENTAREGENTE = dr.GetString(dr.GetOrdinal("OBLI_CUENTAREGENTE"));
                            lsCEntidad.OBLI_CUENTAREGENTE_DESCRIPCION = dr.GetString(dr.GetOrdinal("OBLI_CUENTAREGENTE_DESCRIPCION"));
                            //13
                            lsCEntidad.OBLI_ADOPTAMEDIDASEXTENSION = dr.GetString(dr.GetOrdinal("OBLI_ADOPTAMEDIDASEXTENSION"));
                            lsCEntidad.OBLI_ADOPTAMEDIDASEXTENSION_DESCRIPCION = dr.GetString(dr.GetOrdinal("OBLI_ADOPTAMEDIDASEXTENSION_DESCRIPCION"));
                            //14
                            lsCEntidad.OBLI_RESPETAVALORES = dr.GetString(dr.GetOrdinal("OBLI_RESPETAVALORES"));
                            lsCEntidad.OBLI_RESPETAVALORES_DESCRIPCION = dr.GetString(dr.GetOrdinal("OBLI_RESPETAVALORES_DESCRIPCION"));
                            //15
                            lsCEntidad.OBLI_CUMPLEMEDIDAS = dr.GetString(dr.GetOrdinal("OBLI_CUMPLEMEDIDAS"));
                            lsCEntidad.OBLI_CUMPLEMEDIDAS_DESCRIPCION = dr.GetString(dr.GetOrdinal("OBLI_CUMPLEMEDIDAS_DESCRIPCION"));
                            //16
                            lsCEntidad.OBLI_CUMPLENORMAS = dr.GetString(dr.GetOrdinal("OBLI_CUMPLENORMAS"));
                            lsCEntidad.OBLI_CUMPLENORMAS_DESCRIPCION = dr.GetString(dr.GetOrdinal("OBLI_CUMPLENORMAS_DESCRIPCION"));
                            //17
                            lsCEntidad.OBLI_MOVILIZAFRUTOPRODUCTOS = dr.GetString(dr.GetOrdinal("OBLI_MOVILIZAFRUTOPRODUCTOS"));
                            lsCEntidad.OBLI_MOVILIZAFRUTOPRODUCTOS_DESCRIPCION = dr.GetString(dr.GetOrdinal("OBLI_MOVILIZAFRUTOPRODUCTOS_DESCRIPCION"));
                            //18
                            lsCEntidad.OBLI_CUMPLEMARCADOTROZAS = dr.GetString(dr.GetOrdinal("OBLI_CUMPLEMARCADOTROZAS"));
                            lsCEntidad.OBLI_CUMPLEMARCADOTROZAS_DESCRIPCION = dr.GetString(dr.GetOrdinal("OBLI_CUMPLEMARCADOTROZAS_DESCRIPCION"));
                            //19
                            lsCEntidad.OBLI_ESTABLECELINDEROS = dr.GetString(dr.GetOrdinal("OBLI_ESTABLECELINDEROS"));
                            lsCEntidad.OBLI_ESTABLECELINDEROS_DESCRIPCION = dr.GetString(dr.GetOrdinal("OBLI_ESTABLECELINDEROS_DESCRIPCION"));
                            //20
                            lsCEntidad.OBLI_IMPLEMENTACIONMEDIDASCORRECTIVAS = dr.GetString(dr.GetOrdinal("OBLI_IMPLEMENTACIONMEDIDASCORRECTIVAS"));
                            lsCEntidad.OBLI_IMPLEMENTACIONMEDIDASCORRECTIVAS_DESCRIPCION = dr.GetString(dr.GetOrdinal("OBLI_IMPLEMENTACIONMEDIDASCORRECTIVAS_DESCRIPCION"));
                            //21
                            lsCEntidad.OBLI_PROMUEVENBUENASPRACTICAS = dr.GetString(dr.GetOrdinal("OBLI_PROMUEVENBUENASPRACTICAS"));
                            lsCEntidad.OBLI_PROMUEVENBUENASPRACTICAS_DESCRIPCION = dr.GetString(dr.GetOrdinal("OBLI_PROMUEVENBUENASPRACTICAS_DESCRIPCION"));
                            //22
                            lsCEntidad.OBLI_PROMUEVEEQUIDAD = dr.GetString(dr.GetOrdinal("OBLI_PROMUEVEEQUIDAD"));
                            lsCEntidad.OBLI_PROMUEVEEQUIDAD_DESCRIPCION = dr.GetString(dr.GetOrdinal("OBLI_PROMUEVEEQUIDAD_DESCRIPCION"));
                            //23
                            lsCEntidad.OBLI_MANTIENEVIGENTEGARANTIA = dr.GetString(dr.GetOrdinal("OBLI_MANTIENEVIGENTEGARANTIA"));
                            lsCEntidad.OBLI_MANTIENEVIGENTEGARANTIA_DESCRIPCION = dr.GetString(dr.GetOrdinal("OBLI_MANTIENEVIGENTEGARANTIA_DESCRIPCION"));
                            //24
                            lsCEntidad.OBLI_CUMPLECOMPROMISOINVERSION = dr.GetString(dr.GetOrdinal("OBLI_CUMPLECOMPROMISOINVERSION"));
                            lsCEntidad.OBLI_CUMPLECOMPROMISOINVERSION_DESCRIPCION = dr.GetString(dr.GetOrdinal("OBLI_CUMPLECOMPROMISOINVERSION_DESCRIPCION"));



                            #region Obligacion Titulares TH no Maderables

                            //1
                            lsCEntidad.OBLI_NM_PRESENTOPMF = dr.GetString(dr.GetOrdinal("OBLI_NM_PRESENTOPMF"));
                            lsCEntidad.OBLI_NM_PRESENTOPMF_DESCRIPCION = dr.GetString(dr.GetOrdinal("OBLI_NM_PRESENTOPMF_DESCRIPCION"));
                            //2
                            lsCEntidad.OBLI_NM_PRESENTOINFORMEEJECUCION = dr.GetString(dr.GetOrdinal("OBLI_NM_PRESENTOINFORMEEJECUCION"));
                            lsCEntidad.OBLI_NM_PRESENTOINFORMEEJECUCION_DESCRIPCION = dr.GetString(dr.GetOrdinal("OBLI_NM_PRESENTOINFORMEEJECUCION_DESCRIPCION"));
                            //3
                            lsCEntidad.OBLI_NM_PAGOAPROVECHAMIENTO = dr.GetString(dr.GetOrdinal("OBLI_NM_PAGOAPROVECHAMIENTO"));
                            lsCEntidad.OBLI_NM_PAGOAPROVECHAMIENTO_DESCRIPCION = dr.GetString(dr.GetOrdinal("OBLI_NM_PAGOAPROVECHAMIENTO_DESCRIPCION"));
                            //4
                            lsCEntidad.OBLI_NM_COMUNICOARFFSOSINFORSUSCRIPCION = dr.GetString(dr.GetOrdinal("OBLI_NM_COMUNICOARFFSOSINFORSUSCRIPCION"));
                            lsCEntidad.OBLI_NM_COMUNICOARFFSOSINFORSUSCRIPCION_DESCRIPCION = dr.GetString(dr.GetOrdinal("OBLI_NM_COMUNICOARFFSOSINFORSUSCRIPCION_DESCRIPCION"));
                            //5
                            lsCEntidad.OBLI_NM_REPORTOARFFSMINISTERIOAVISTAMIENTOS = dr.GetString(dr.GetOrdinal("OBLI_NM_REPORTOARFFSMINISTERIOAVISTAMIENTOS"));
                            lsCEntidad.OBLI_NM_REPORTOARFFSMINISTERIOAVISTAMIENTOS_DESCRIPCION = dr.GetString(dr.GetOrdinal("OBLI_NM_REPORTOARFFSMINISTERIOAVISTAMIENTOS_DESCRIPCION"));
                            //6
                            lsCEntidad.OBLI_NM_REALIZOACCIONESCUSTODIO = dr.GetString(dr.GetOrdinal("OBLI_NM_REALIZOACCIONESCUSTODIO"));
                            lsCEntidad.OBLI_NM_REALIZOACCIONESCUSTODIO_DESCRIPCION = dr.GetString(dr.GetOrdinal("OBLI_NM_REALIZOACCIONESCUSTODIO_DESCRIPCION"));
                            //7
                            lsCEntidad.OBLI_NM_FACILITODESARROLLO = dr.GetString(dr.GetOrdinal("OBLI_NM_FACILITODESARROLLO"));
                            lsCEntidad.OBLI_NM_FACILITODESARROLLO_DESCRIPCION = dr.GetString(dr.GetOrdinal("OBLI_NM_FACILITODESARROLLO_DESCRIPCION"));
                            //8
                            lsCEntidad.OBLI_NM_ASUMIOCOSTOSUPERVISIONES = dr.GetString(dr.GetOrdinal("OBLI_NM_ASUMIOCOSTOSUPERVISIONES"));
                            lsCEntidad.OBLI_NM_ASUMIOCOSTOSUPERVISIONES_DESCRIPCION = dr.GetString(dr.GetOrdinal("OBLI_NM_ASUMIOCOSTOSUPERVISIONES_DESCRIPCION"));
                            //9
                            lsCEntidad.OBLI_NM_IMPLEMENTAMECANISMOTRAZA = dr.GetString(dr.GetOrdinal("OBLI_NM_IMPLEMENTAMECANISMOTRAZA"));
                            lsCEntidad.OBLI_NM_IMPLEMENTAMECANISMOTRAZA_DESCRIPCION = dr.GetString(dr.GetOrdinal("OBLI_NM_IMPLEMENTAMECANISMOTRAZA_DESCRIPCION"));
                            //10
                            lsCEntidad.OBLI_NM_RESPETASERVIDUMBRE = dr.GetString(dr.GetOrdinal("OBLI_NM_RESPETASERVIDUMBRE"));
                            lsCEntidad.OBLI_NM_RESPETASERVIDUMBRE_DESCRIPCION = dr.GetString(dr.GetOrdinal("OBLI_NM_RESPETASERVIDUMBRE_DESCRIPCION"));
                            //11
                            lsCEntidad.OBLI_NM_ADOPTAMEDIDASEXTENSION = dr.GetString(dr.GetOrdinal("OBLI_NM_ADOPTAMEDIDASEXTENSION"));
                            lsCEntidad.OBLI_NM_ADOPTAMEDIDASEXTENSION_DESCRIPCION = dr.GetString(dr.GetOrdinal("OBLI_NM_ADOPTAMEDIDASEXTENSION_DESCRIPCION"));
                            //12
                            lsCEntidad.OBLI_NM_RESPETAVALORES = dr.GetString(dr.GetOrdinal("OBLI_NM_RESPETAVALORES"));
                            lsCEntidad.OBLI_NM_RESPETAVALORES_DESCRIPCION = dr.GetString(dr.GetOrdinal("OBLI_NM_RESPETAVALORES_DESCRIPCION"));
                            //13
                            lsCEntidad.OBLI_NM_CUMPLEMEDIDAS = dr.GetString(dr.GetOrdinal("OBLI_NM_CUMPLEMEDIDAS"));
                            lsCEntidad.OBLI_NM_CUMPLEMEDIDAS_DESCRIPCION = dr.GetString(dr.GetOrdinal("OBLI_NM_CUMPLEMEDIDAS_DESCRIPCION"));
                            //14
                            lsCEntidad.OBLI_NM_CUMPLENORMAS = dr.GetString(dr.GetOrdinal("OBLI_NM_CUMPLENORMAS"));
                            lsCEntidad.OBLI_NM_CUMPLENORMAS_DESCRIPCION = dr.GetString(dr.GetOrdinal("OBLI_NM_CUMPLENORMAS_DESCRIPCION"));
                            //15
                            lsCEntidad.OBLI_NM_MOVILIZAFRUTOPRODUCTOS = dr.GetString(dr.GetOrdinal("OBLI_NM_MOVILIZAFRUTOPRODUCTOS"));
                            lsCEntidad.OBLI_NM_MOVILIZAFRUTOPRODUCTOS_DESCRIPCION = dr.GetString(dr.GetOrdinal("OBLI_NM_MOVILIZAFRUTOPRODUCTOS_DESCRIPCION"));
                            //16
                            lsCEntidad.OBLI_NM_IMPLEMENTACIONMEDIDASCORRECTIVAS = dr.GetString(dr.GetOrdinal("OBLI_NM_IMPLEMENTACIONMEDIDASCORRECTIVAS"));
                            lsCEntidad.OBLI_NM_IMPLEMENTACIONMEDIDASCORRECTIVAS_DESCRIPCION = dr.GetString(dr.GetOrdinal("OBLI_NM_IMPLEMENTACIONMEDIDASCORRECTIVAS_DESCRIPCION"));
                            //17
                            lsCEntidad.OBLI_NM_IMPMEDCORRECRESULTADOACCIONES = dr.GetString(dr.GetOrdinal("OBLI_NM_IMPMEDCORRECRESULTADOACCIONES"));
                            lsCEntidad.OBLI_NM_IMPMEDCORRECRESULTADOACCIONES_DESCRIPCION = dr.GetString(dr.GetOrdinal("OBLI_NM_IMPMEDCORRECRESULTADOACCIONES_DESCRIPCION"));
                            //18
                            lsCEntidad.OBLI_NM_PROMUEVENBUENASPRACTICAS = dr.GetString(dr.GetOrdinal("OBLI_NM_PROMUEVENBUENASPRACTICAS"));
                            lsCEntidad.OBLI_NM_PROMUEVENBUENASPRACTICAS_DESCRIPCION = dr.GetString(dr.GetOrdinal("OBLI_NM_PROMUEVENBUENASPRACTICAS_DESCRIPCION"));
                            //19
                            lsCEntidad.OBLI_NM_PROMUEVEEQUIDAD = dr.GetString(dr.GetOrdinal("OBLI_NM_PROMUEVEEQUIDAD"));
                            lsCEntidad.OBLI_NM_PROMUEVEEQUIDAD_DESCRIPCION = dr.GetString(dr.GetOrdinal("OBLI_NM_PROMUEVEEQUIDAD_DESCRIPCION"));
                            #endregion

                        }
                        #endregion
                        #region ListCNotificaciones
                        //Lista de Cartas de Notificación enlazadas
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidad();
                                ocampoEnt.COD_CNOTIFICACION = dr["COD_CNOTIFICACION"].ToString();
                                ocampoEnt.NUM_THABILITANTE = dr["NUM_THABILITANTE"].ToString();
                                ocampoEnt.NUM_CNOTIFICACION = dr["NUM_CNOTIFICACION"].ToString();
                                ocampoEnt.POA = dr["POA"].ToString();
                                ocampoEnt.RegEstado = 0;
                                lsCEntidad.ListCNotificaciones.Add(ocampoEnt);
                            }
                        }
                        #endregion
                        #region ListInformeDetSupervisor
                        //Lista de Supervisor
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                ocampoEntPersona = new CEntPersona();
                                ocampoEntPersona.COD_PERSONA = dr["COD_SUPERVISOR"].ToString();
                                ocampoEntPersona.APE_PATERNO = dr["APE_PATERNO"].ToString();
                                ocampoEntPersona.APE_MATERNO = dr["APE_MATERNO"].ToString();
                                ocampoEntPersona.NOMBRES = dr["NOMBRES"].ToString();
                                ocampoEntPersona.PERSONA = dr["NOMBRE_SUPERVISOR"].ToString();
                                ocampoEntPersona.N_DOCUMENTO = dr["N_DOCUMENTO"].ToString();
                                ocampoEntPersona.COD_DIDENTIDAD = dr["COD_DIDENTIDAD"].ToString();
                                ocampoEntPersona.COD_NACADEMICO = dr["COD_NACADEMICO"].ToString();
                                ocampoEntPersona.COD_DPESPECIALIDAD = dr["COD_DPESPECIALIDAD"].ToString();
                                ocampoEntPersona.COLEGIATURA_NUM = dr["COLEGIATURA_NUM"].ToString();
                                ocampoEntPersona.CARGO = dr["CARGO"].ToString();
                                ocampoEntPersona.COD_PTIPO = "0000007";
                                ocampoEntPersona.RegEstado = 0;
                                lsCEntidad.ListInformeDetSupervisor.Add(ocampoEntPersona);
                            }
                        }
                        #endregion
                        #region ListISDSilvicultutal
                        //SILVICULTURALES
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                //ocampoSilv = new CEntISDSilvicultural();
                                ocampoEnt = new CEntidad();
                                ocampoEnt.COD_ASILVICULTURALES = dr["COD_ASILVICULTURALES"].ToString();
                                ocampoEnt.DESC_SILVICULTURALES = dr["DESC_SILVICULTURALES"].ToString();
                                ocampoEnt.COD_SECUENCIAL = Int32.Parse(dr["COD_SECUENCIAL"].ToString());
                                ocampoEnt.COD_ESPECIES = dr["COD_ESPECIES"].ToString();
                                ocampoEnt.DESC_ESPECIES = dr["DESC_ESPECIES"].ToString();
                                ocampoEnt.NUM_PLANTULAS = Int32.Parse(dr["NUM_PLANTULAS"].ToString());
                                ocampoEnt.UBICACION = dr["UBICACION"].ToString();
                                ocampoEnt.TIEMPO = Int32.Parse(dr["TIEMPO"].ToString());
                                ocampoEnt.FAJA = dr["FAJA"].ToString();
                                ocampoEnt.OBSERVACION = dr["OBSERVACION"].ToString();
                                ocampoEnt.CUMPLIMIENTO_ACTIVIDADES = Boolean.Parse(dr["CUMPLIMIENTO_ACTIVIDADES"].ToString());
                                ocampoEnt.NUM_POA = Int32.Parse(dr["NUM_POA"].ToString());
                                ocampoEnt.POA = dr["POA"].ToString();
                                ocampoEnt.RegEstado = 0;
                                lsCEntidad.ListISDSilvicultutal.Add(ocampoEnt);
                            }
                        }
                        #endregion
                        #region ListHuayronas
                        //HUAYRONAS
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidad();
                                ocampoEnt.NUMERO = dr["NUMERO"].ToString();
                                ocampoEnt.ZONA = dr["ZONA"].ToString();
                                ocampoEnt.COORDENADA_ESTE = Int32.Parse(dr["COORDENADA_ESTE"].ToString());
                                ocampoEnt.COORDENADA_NORTE = Int32.Parse(dr["COORDENADA_NORTE"].ToString());
                                ocampoEnt.VOLUMEN = Decimal.Parse(dr["VOLUMEN"].ToString());
                                ocampoEnt.NUM_POA = Int32.Parse(dr["NUM_POA"].ToString());
                                ocampoEnt.POA = dr["POA"].ToString();
                                ocampoEnt.RegEstado = 0;
                                lsCEntidad.ListHuayronas.Add(ocampoEnt);
                            }
                        }
                        #endregion
                        #region ListISupervMaderableAdicional
                        //Maderable Adicionales
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            Int32 num_fila = 0;
                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidad();
                                ocampoEnt.NUMERO_FILA = num_fila;
                                ocampoEnt.COD_ESPECIES = dr["COD_ESPECIES"].ToString();
                                ocampoEnt.DESC_ESPECIES = dr["DESC_ESPECIES"].ToString();
                                ocampoEnt.COD_SECUENCIAL = Int32.Parse(dr["COD_SECUENCIAL"].ToString());
                                ocampoEnt.BLOQUE = dr["BLOQUE"].ToString();
                                ocampoEnt.FAJA = dr["FAJA"].ToString();
                                ocampoEnt.CODIGO = dr["CODIGO"].ToString();
                                ocampoEnt.DAP = Decimal.Parse(dr["DAP"].ToString());
                                ocampoEnt.AC = Decimal.Parse(dr["AC"].ToString());
                                ocampoEnt.ZONA = dr["ZONA"].ToString();
                                ocampoEnt.COORDENADA_ESTE = Int32.Parse(dr["COORDENADA_ESTE"].ToString());
                                ocampoEnt.COORDENADA_NORTE = Int32.Parse(dr["COORDENADA_NORTE"].ToString());
                                ocampoEnt.COD_ECONDICION = dr["COD_ECONDICION"].ToString();
                                ocampoEnt.DESC_ECONDICION = dr["DESC_ECONDICION"].ToString();
                                ocampoEnt.COD_EESTADO = dr["COD_EESTADO"].ToString();
                                ocampoEnt.DESC_EESTADO = dr["DESC_EESTADO"].ToString();
                                //ocampoEnt.COD_ACATEGORIA = dr["COD_ACATEGORIA"].ToString();
                                ocampoEnt.DESC_ACATEGORIA_CITE = dr["DESC_ACATEGORIA_CITE"].ToString();
                                ocampoEnt.DESC_ACATEGORIA_DS = dr["DESC_ACATEGORIA_DS"].ToString();
                                ocampoEnt.OBSERVACION = dr["OBSERVACION"].ToString();
                                ocampoEnt.NUM_POA = Int32.Parse(dr["NUM_POA"].ToString());
                                ocampoEnt.POA = dr["POA"].ToString();
                                ocampoEnt.RegEstado = 0;
                                ocampoEnt.DAP2 = Decimal.Parse(dr["DAP_2"].ToString());
                                ocampoEnt.MAE_TIP_MMEDIRDAP = dr["MAE_TIP_MMEDIRDAP"].ToString();
                                ocampoEnt.MMEDIR_DAP = dr["MMEDIR_DAP"].ToString();
                                ocampoEnt.DAP1 = Decimal.Parse(dr["DAP_1"].ToString());
                                lsCEntidad.ListISupervMaderableAdicional.Add(ocampoEnt);
                                num_fila++;
                            }
                        }
                        #endregion
                        #region ListISupervMaderableAprov
                        //Maderable Aprovechable
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            Int32 num_fila = 0;
                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidad();
                                ocampoEnt.NUMERO_FILA = num_fila;
                                ocampoEnt.COD_THABILITANTE = dr["COD_THABILITANTE"].ToString();
                                ocampoEnt.NUM_POA = Int32.Parse(dr["NUM_POA"].ToString());
                                ocampoEnt.COD_ESPECIES = dr["COD_ESPECIES"].ToString();
                                ocampoEnt.DESC_ESPECIES = dr["DESC_ESPECIES"].ToString();
                                ocampoEnt.COD_SECUENCIAL = Int32.Parse(dr["COD_SECUENCIAL"].ToString());
                                ocampoEnt.BLOQUE = dr["BLOQUE"].ToString();
                                ocampoEnt.FAJA = dr["FAJA"].ToString();
                                ocampoEnt.CODIGO = dr["CODIGO"].ToString();
                                ocampoEnt.DAP = Decimal.Parse(dr["DAP"].ToString());
                                ocampoEnt.AC = Decimal.Parse(dr["AC"].ToString());
                                ocampoEnt.COD_ECONDICION = dr["COD_ECONDICION"].ToString();
                                ocampoEnt.DESC_EESTADO = dr["DESC_EESTADO"].ToString();
                                ocampoEnt.ZONA = dr["ZONA"].ToString();
                                ocampoEnt.COORDENADA_ESTE = Int32.Parse(dr["COORDENADA_ESTE"].ToString());
                                ocampoEnt.COORDENADA_NORTE = Int32.Parse(dr["COORDENADA_NORTE"].ToString());
                                ocampoEnt.COD_EESTADO = dr["COD_EESTADO"].ToString();
                                ocampoEnt.COD_ESPECIES_CAMPO = dr["COD_ESPECIES_CAMPO"].ToString();
                                ocampoEnt.BLOQUE_CAMPO = dr["BLOQUE_2"].ToString();
                                ocampoEnt.FAJA_CAMPO = dr["FAJA_2"].ToString();
                                ocampoEnt.CODIGO_CAMPO = dr["CODIGO_2"].ToString();
                                ocampoEnt.DAP_CAMPO = Decimal.Parse(dr["DAP_CAMPO"].ToString());
                                ocampoEnt.AC_CAMPO = Decimal.Parse(dr["AC_2"].ToString());
                                ocampoEnt.ZONA_CAMPO = dr["ZONA_2"].ToString();
                                ocampoEnt.COORDENADA_ESTE_CAMPO = Int32.Parse(dr["COORDENADA_ESTE_2"].ToString());
                                ocampoEnt.COORDENADA_NORTE_CAMPO = Int32.Parse(dr["COORDENADA_NORTE_2"].ToString());
                                //ocampoEnt.COD_ACATEGORIA = dr["COD_ACATEGORIA"].ToString();
                                ocampoEnt.BS_ALTURA_TOTAL = Decimal.Parse(dr["BS_ALTURA_TOTAL"].ToString());
                                ocampoEnt.BS_DIAMETRO_RAMA_1 = Decimal.Parse(dr["BS_DIAMETRO_RAMA_1"].ToString());
                                ocampoEnt.BS_DIAMETRO_RAMA_2 = Decimal.Parse(dr["BS_DIAMETRO_RAMA_2"].ToString());
                                ocampoEnt.BS_DIAMETRO_RAMA_3 = Decimal.Parse(dr["BS_DIAMETRO_RAMA_3"].ToString());
                                ocampoEnt.BS_DIAMETRO_RAMA_4 = Decimal.Parse(dr["BS_DIAMETRO_RAMA_4"].ToString());
                                ocampoEnt.BS_DIAMETRO_RAMA_5 = Decimal.Parse(dr["BS_DIAMETRO_RAMA_5"].ToString());
                                ocampoEnt.BS_DIAMETRO_RAMA_6 = Decimal.Parse(dr["BS_DIAMETRO_RAMA_6"].ToString());
                                ocampoEnt.BS_DIAMETRO_RAMA_7 = Decimal.Parse(dr["BS_DIAMETRO_RAMA_7"].ToString());
                                ocampoEnt.BS_LONGITUD_RAMA_1 = Decimal.Parse(dr["BS_LONGITUD_RAMA_1"].ToString());
                                ocampoEnt.BS_LONGITUD_RAMA_2 = Decimal.Parse(dr["BS_LONGITUD_RAMA_2"].ToString());
                                ocampoEnt.BS_LONGITUD_RAMA_3 = Decimal.Parse(dr["BS_LONGITUD_RAMA_3"].ToString());
                                ocampoEnt.BS_LONGITUD_RAMA_4 = Decimal.Parse(dr["BS_LONGITUD_RAMA_4"].ToString());
                                ocampoEnt.BS_LONGITUD_RAMA_5 = Decimal.Parse(dr["BS_LONGITUD_RAMA_5"].ToString());
                                ocampoEnt.BS_LONGITUD_RAMA_6 = Decimal.Parse(dr["BS_LONGITUD_RAMA_6"].ToString());
                                ocampoEnt.BS_LONGITUD_RAMA_7 = Decimal.Parse(dr["BS_LONGITUD_RAMA_7"].ToString());
                                ocampoEnt.ESTADO_SUPERVISION = Boolean.Parse(dr["ESTADO_SUPERVISION"].ToString());
                                ocampoEnt.OBSERVACION = dr["OBSERVACION"].ToString();
                                ocampoEnt.POA = dr["POA"].ToString();
                                ocampoEnt.DESC_ESPECIES_CAMPO = dr["DESC_ESPECIES_2"].ToString();
                                ocampoEnt.DESC_EESTADO_CAMPO = dr["DESC_EESTADO_2"].ToString();
                                ocampoEnt.DESC_ACATEGORIA_CITE = dr["DESC_ACATEGORIA_CITE"].ToString();
                                ocampoEnt.DESC_ACATEGORIA_DS = dr["DESC_ACATEGORIA_DS"].ToString();
                                ocampoEnt.RegEstado = 0;
                                ocampoEnt.DAP_CAMPO1 = Decimal.Parse(dr["DAP_CAMPO1"].ToString());
                                ocampoEnt.DAP_CAMPO2 = Decimal.Parse(dr["DAP_CAMPO2"].ToString());
                                ocampoEnt.MAE_TIP_MMEDIRDAP = dr["MAE_TIP_MMEDIRDAP"].ToString();
                                ocampoEnt.MMEDIR_DAP = dr["MMEDIR_DAP"].ToString();
                                ocampoEnt.COD_ECONDICION_CAMPO = dr["COD_ECONDICION_CAMPO"].ToString();
                                ocampoEnt.DESC_ECONDICION_CAMPO = dr["DESC_ECONDICION_CAMPO"].ToString();
                                ocampoEnt.DESC_ECONDICION = dr["DESC_ECONDICION"].ToString();
                                ocampoEnt.COINCIDE_ESPECIES = dr["COINCIDE_ESPECIES"].ToString();
                                ocampoEnt.DESC_COINCIDE_ESPECIES = ocampoEnt.COINCIDE_ESPECIES == "NN" ? "Ninguno" : (ocampoEnt.COINCIDE_ESPECIES == "-" ? "" : ocampoEnt.COINCIDE_ESPECIES);
                                ocampoEnt.CANT_SOBRE_ESTIMA_DIAMETRO = Int32.Parse(dr["CANT_SOBRE_ESTIMA_DIAMETRO"].ToString());
                                ocampoEnt.PORC_SOBRE_ESTIMA_DIAMETRO = Decimal.Parse(dr["PORC_SOBRE_ESTIMA_DIAMETRO"].ToString());
                                ocampoEnt.CANT_SUB_ESTIMA_DIAMETRO = Int32.Parse(dr["CANT_SUB_ESTIMA_DIAMETRO"].ToString());
                                ocampoEnt.PORC_SUB_ESTIMA_DIAMETRO = Decimal.Parse(dr["PORC_SUB_ESTIMA_DIAMETRO"].ToString());

                                num_fila++;
                                lsCEntidad.ListISupervMaderableAprov.Add(ocampoEnt);
                            }
                        }
                        #endregion
                        #region ListISupervMaderableSemillero
                        //Maderable Semillero
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            Int32 num_fila = 0;
                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidad();
                                ocampoEnt.NUMERO_FILA = num_fila;
                                ocampoEnt.COD_THABILITANTE = dr["COD_THABILITANTE"].ToString();
                                ocampoEnt.NUM_POA = Int32.Parse(dr["NUM_POA"].ToString());
                                ocampoEnt.COD_ESPECIES = dr["COD_ESPECIES"].ToString();
                                ocampoEnt.DESC_ESPECIES = dr["DESC_ESPECIES"].ToString();
                                ocampoEnt.COD_SECUENCIAL = Int32.Parse(dr["COD_SECUENCIAL"].ToString());
                                ocampoEnt.BLOQUE = dr["BLOQUE"].ToString();
                                ocampoEnt.FAJA = dr["FAJA"].ToString();
                                ocampoEnt.CODIGO = dr["CODIGO"].ToString();
                                ocampoEnt.DAP = Decimal.Parse(dr["DAP"].ToString());
                                ocampoEnt.AC = Decimal.Parse(dr["AC"].ToString());
                                ocampoEnt.COD_ECONDICION = dr["COD_ECONDICION"].ToString();
                                ocampoEnt.DESC_EESTADO = dr["DESC_EESTADO"].ToString();
                                ocampoEnt.ZONA = dr["ZONA"].ToString();
                                ocampoEnt.COORDENADA_ESTE = Int32.Parse(dr["COORDENADA_ESTE"].ToString());
                                ocampoEnt.COORDENADA_NORTE = Int32.Parse(dr["COORDENADA_NORTE"].ToString());
                                ocampoEnt.COD_EESTADO = dr["COD_EESTADO"].ToString();
                                ocampoEnt.COD_ESPECIES_CAMPO = dr["COD_ESPECIES_CAMPO"].ToString();
                                ocampoEnt.BLOQUE_CAMPO = dr["BLOQUE_2"].ToString();
                                ocampoEnt.FAJA_CAMPO = dr["FAJA_2"].ToString();
                                ocampoEnt.CODIGO_CAMPO = dr["CODIGO_2"].ToString();
                                ocampoEnt.DAP_CAMPO = Decimal.Parse(dr["DAP_CAMPO"].ToString());
                                ocampoEnt.AC_CAMPO = Decimal.Parse(dr["AC_2"].ToString());
                                ocampoEnt.ZONA_CAMPO = dr["ZONA_2"].ToString();
                                ocampoEnt.COORDENADA_ESTE_CAMPO = Int32.Parse(dr["COORDENADA_ESTE_2"].ToString());
                                ocampoEnt.COORDENADA_NORTE_CAMPO = Int32.Parse(dr["COORDENADA_NORTE_2"].ToString());
                                //ocampoEnt.COD_ACATEGORIA = dr["COD_ACATEGORIA"].ToString();
                                ocampoEnt.BS_ALTURA_TOTAL = Decimal.Parse(dr["BS_ALTURA_TOTAL"].ToString());
                                ocampoEnt.BS_DIAMETRO_RAMA_1 = Decimal.Parse(dr["BS_DIAMETRO_RAMA_1"].ToString());
                                ocampoEnt.BS_DIAMETRO_RAMA_2 = Decimal.Parse(dr["BS_DIAMETRO_RAMA_2"].ToString());
                                ocampoEnt.BS_DIAMETRO_RAMA_3 = Decimal.Parse(dr["BS_DIAMETRO_RAMA_3"].ToString());
                                ocampoEnt.BS_DIAMETRO_RAMA_4 = Decimal.Parse(dr["BS_DIAMETRO_RAMA_4"].ToString());
                                ocampoEnt.BS_DIAMETRO_RAMA_5 = Decimal.Parse(dr["BS_DIAMETRO_RAMA_5"].ToString());
                                ocampoEnt.BS_DIAMETRO_RAMA_6 = Decimal.Parse(dr["BS_DIAMETRO_RAMA_6"].ToString());
                                ocampoEnt.BS_DIAMETRO_RAMA_7 = Decimal.Parse(dr["BS_DIAMETRO_RAMA_7"].ToString());
                                ocampoEnt.BS_LONGITUD_RAMA_1 = Decimal.Parse(dr["BS_LONGITUD_RAMA_1"].ToString());
                                ocampoEnt.BS_LONGITUD_RAMA_2 = Decimal.Parse(dr["BS_LONGITUD_RAMA_2"].ToString());
                                ocampoEnt.BS_LONGITUD_RAMA_3 = Decimal.Parse(dr["BS_LONGITUD_RAMA_3"].ToString());
                                ocampoEnt.BS_LONGITUD_RAMA_4 = Decimal.Parse(dr["BS_LONGITUD_RAMA_4"].ToString());
                                ocampoEnt.BS_LONGITUD_RAMA_5 = Decimal.Parse(dr["BS_LONGITUD_RAMA_5"].ToString());
                                ocampoEnt.BS_LONGITUD_RAMA_6 = Decimal.Parse(dr["BS_LONGITUD_RAMA_6"].ToString());
                                ocampoEnt.BS_LONGITUD_RAMA_7 = Decimal.Parse(dr["BS_LONGITUD_RAMA_7"].ToString());
                                ocampoEnt.COD_CFUSTE = dr["COD_CFUSTE"].ToString();
                                ocampoEnt.COD_FCOPA = dr["COD_FCOPA"].ToString();
                                ocampoEnt.COD_PCOPA = dr["COD_PCOPA"].ToString();
                                ocampoEnt.COD_EFENOLOGICO = dr["COD_EFENOLOGICO"].ToString();
                                ocampoEnt.COD_ESANITARIO = dr["COD_ESANITARIO"].ToString();
                                ocampoEnt.COD_ILIANAS = dr["COD_ILIANAS"].ToString();
                                ocampoEnt.ESTADO_SUPERVISION = Boolean.Parse(dr["ESTADO_SUPERVISION"].ToString());
                                ocampoEnt.OBSERVACION = dr["OBSERVACION"].ToString();
                                ocampoEnt.POA = dr["POA"].ToString();
                                ocampoEnt.DESC_ESPECIES_CAMPO = dr["DESC_ESPECIES_2"].ToString();
                                ocampoEnt.DESC_EESTADO_CAMPO = dr["DESC_EESTADO_2"].ToString();
                                ocampoEnt.DESC_CFUSTE = dr["DESC_CFUSTE"].ToString();
                                ocampoEnt.DESC_FCOPA = dr["DESC_FCOPA"].ToString();
                                ocampoEnt.DESC_PCOPA = dr["DESC_PCOPA"].ToString();
                                ocampoEnt.DESC_EFENOLOGICO = dr["DESC_EFENOLOGICO"].ToString();
                                ocampoEnt.DESC_ESANITARIO = dr["DESC_ESANITARIO"].ToString();
                                ocampoEnt.DESC_ILIANAS = dr["DESC_ILIANAS"].ToString();
                                ocampoEnt.DESC_ACATEGORIA_CITE = dr["DESC_ACATEGORIA_CITE"].ToString();
                                ocampoEnt.DESC_ACATEGORIA_DS = dr["DESC_ACATEGORIA_DS"].ToString();
                                ocampoEnt.RegEstado = 0;
                                ocampoEnt.DAP_CAMPO1 = Decimal.Parse(dr["DAP_CAMPO1"].ToString());
                                ocampoEnt.DAP_CAMPO2 = Decimal.Parse(dr["DAP_CAMPO2"].ToString());
                                ocampoEnt.MAE_TIP_MMEDIRDAP = dr["MAE_TIP_MMEDIRDAP"].ToString();
                                ocampoEnt.MMEDIR_DAP = dr["MMEDIR_DAP"].ToString();
                                ocampoEnt.COINCIDE_ESPECIES = dr["COINCIDE_ESPECIES"].ToString();
                                ocampoEnt.DESC_COINCIDE_ESPECIES = ocampoEnt.COINCIDE_ESPECIES == "NN" ? "Ninguno" : (ocampoEnt.COINCIDE_ESPECIES == "-" ? "" : ocampoEnt.COINCIDE_ESPECIES);
                                ocampoEnt.CANT_SOBRE_ESTIMA_DIAMETRO = Int32.Parse(dr["CANT_SOBRE_ESTIMA_DIAMETRO"].ToString());
                                ocampoEnt.PORC_SOBRE_ESTIMA_DIAMETRO = Decimal.Parse(dr["PORC_SOBRE_ESTIMA_DIAMETRO"].ToString());
                                ocampoEnt.CANT_SUB_ESTIMA_DIAMETRO = Int32.Parse(dr["CANT_SUB_ESTIMA_DIAMETRO"].ToString());
                                ocampoEnt.PORC_SUB_ESTIMA_DIAMETRO = Decimal.Parse(dr["PORC_SUB_ESTIMA_DIAMETRO"].ToString());

                                num_fila++;
                                lsCEntidad.ListISupervMaderableSemillero.Add(ocampoEnt);
                            }
                        }
                        #endregion
                        #region ListISupervNoMaderableSemillero
                        //NO MADERABLE APROVECHABLE Y SEMILLERO
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            Int32 num_fila = 0;
                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidad();
                                ocampoEnt.NUMERO_FILA = num_fila;
                                ocampoEnt.COD_THABILITANTE = dr["COD_THABILITANTE"].ToString();
                                ocampoEnt.NUM_POA = Int32.Parse(dr["NUM_POA"].ToString());
                                ocampoEnt.COD_ESPECIES = dr["COD_ESPECIES"].ToString();
                                ocampoEnt.DESC_ESPECIES = dr["DESC_ESPECIES"].ToString();
                                ocampoEnt.COD_SECUENCIAL = Int32.Parse(dr["COD_SECUENCIAL"].ToString());
                                ocampoEnt.NUM_ESTRADA = dr["NUM_ESTRADA"].ToString();
                                ocampoEnt.CODIGO = dr["CODIGO"].ToString();
                                ocampoEnt.DIAMETRO = Decimal.Parse(dr["DIAMETRO"].ToString());
                                ocampoEnt.ALTURA = Decimal.Parse(dr["ALTURA"].ToString());
                                ocampoEnt.PRODUCCION_LATAS = Decimal.Parse(dr["PRODUCCION_LATAS"].ToString());
                                ocampoEnt.COD_ECONDICION = dr["COD_ECONDICION"].ToString();
                                ocampoEnt.ZONA = dr["ZONA"].ToString();
                                ocampoEnt.COORDENADA_ESTE = Int32.Parse(dr["COORDENADA_ESTE"].ToString());
                                ocampoEnt.COORDENADA_NORTE = Int32.Parse(dr["COORDENADA_NORTE"].ToString());
                                ocampoEnt.COD_ESPECIES_CAMPO = dr["COD_ESPECIES_CAMPO"].ToString();
                                ocampoEnt.NUM_ESTRADA_CAMPO = dr["NUM_ESTRADA_2"].ToString();
                                ocampoEnt.CODIGO_CAMPO = dr["CODIGO_2"].ToString();
                                ocampoEnt.DIAMETRO_CAMPO = Decimal.Parse(dr["DIAMETRO_2"].ToString());
                                ocampoEnt.ALTURA_CAMPO = Decimal.Parse(dr["ALTURA_2"].ToString());
                                ocampoEnt.PRODUCCION_LATAS_CAMPO = Decimal.Parse(dr["PRODUCCION_LATAS_2"].ToString());
                                ocampoEnt.ZONA_CAMPO = dr["ZONA_2"].ToString();
                                ocampoEnt.COORDENADA_ESTE_CAMPO = Int32.Parse(dr["COORDENADA_ESTE_2"].ToString());
                                ocampoEnt.COORDENADA_NORTE_CAMPO = Int32.Parse(dr["COORDENADA_NORTE_2"].ToString());
                                ocampoEnt.COD_EESTADO = dr["COD_EESTADO"].ToString();
                                ocampoEnt.NUM_COCOS_ABIERTOS = Int32.Parse(dr["NUM_COCOS_ABIERTOS"].ToString());
                                ocampoEnt.NUM_COCOS_CERRADOS = Int32.Parse(dr["NUM_COCOS_CERRADOS"].ToString());
                                ocampoEnt.COD_CFUSTE = dr["COD_CFUSTE"].ToString();
                                ocampoEnt.COD_EFITOSANITARIO = dr["COD_EFITOSANITARIO"].ToString();
                                ocampoEnt.COD_FCOPA = dr["COD_FCOPA"].ToString();
                                ocampoEnt.COD_PCOPA = dr["COD_PCOPA"].ToString();
                                ocampoEnt.COD_EFENOLOGICO = dr["COD_EFENOLOGICO"].ToString();
                                ocampoEnt.COD_ESANITARIO = dr["COD_ESANITARIO"].ToString();
                                ocampoEnt.COD_ILIANAS = dr["COD_ILIANAS"].ToString();
                                ocampoEnt.OBSERVACION = dr["OBSERVACION"].ToString();
                                ocampoEnt.ESTADO_SUPERVISION = Boolean.Parse(dr["ESTADO_SUPERVISION"].ToString());
                                ocampoEnt.POA = dr["POA"].ToString();
                                ocampoEnt.DESC_ESPECIES_CAMPO = dr["DESC_ESPECIES_2"].ToString();
                                ocampoEnt.DESC_EESTADO_CAMPO = dr["DESC_EESTADO_2"].ToString();
                                ocampoEnt.DESC_CFUSTE = dr["DESC_CFUSTE"].ToString();
                                ocampoEnt.DESC_FCOPA = dr["DESC_FCOPA"].ToString();
                                ocampoEnt.DESC_PCOPA = dr["DESC_PCOPA"].ToString();
                                ocampoEnt.DESC_EFENOLOGICO = dr["DESC_EFENOLOGICO"].ToString();
                                ocampoEnt.DESC_ESANITARIO = dr["DESC_ESANITARIO"].ToString();
                                ocampoEnt.DESC_ILIANAS = dr["DESC_ILIANAS"].ToString();
                                ocampoEnt.DESC_EFITOSANITARIO = dr["DESC_EFITOSANITARIO"].ToString();
                                ocampoEnt.RegEstado = 0;
                                num_fila++;
                                lsCEntidad.ListISupervNoMaderableSemillero.Add(ocampoEnt);
                            }
                        }
                        #endregion
                        #region oListTempOblicagContractual
                        // OBLIGACIONES CONTRACTUALES
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            List<CEntidad> oListTempOblicagContractual = new List<CEntidad>();
                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidad();
                                ocampoEnt.COD_OCONTRACTUAL = dr["COD_OCONTRACTUAL"].ToString();
                                ocampoEnt.COD_SECUENCIAL = Int32.Parse(dr["COD_SECUENCIAL"].ToString());
                                ocampoEnt.COD_ESPECIES = dr["COD_ESPECIES"].ToString();
                                ocampoEnt.ESPECIES = dr["ESPECIES"].ToString();
                                ocampoEnt.ACTIVIDAD_ACTOS = dr["ACTIVIDAD_ACTOS"].ToString();
                                ocampoEnt.ESTA_AUTORIZADO = Boolean.Parse(dr["ESTA_AUTORIZADO"].ToString());
                                ocampoEnt.DOCUMENTOS_AFORESTAL = dr["DOCUMENTOS_AFORESTAL"].ToString();
                                ocampoEnt.OBSERVACION = dr["OBSERVACION"].ToString();
                                ocampoEnt.RegEstado = 0;
                                oListTempOblicagContractual.Add(ocampoEnt);
                            }
                            if (oListTempOblicagContractual != null && oListTempOblicagContractual.Count > 0)
                            {

                                lsCEntidad.ListOCEjecucionActividad = (from p in oListTempOblicagContractual where p.COD_OCONTRACTUAL == "01" select p).ToList<CEntidad>();
                                lsCEntidad.ListOCEspeciesExoticas = (from p in oListTempOblicagContractual where p.COD_OCONTRACTUAL == "02" select p).ToList<CEntidad>();
                                lsCEntidad.ListOCActosTercero = (from p in oListTempOblicagContractual where p.COD_OCONTRACTUAL == "03" select p).ToList<CEntidad>();
                                lsCEntidad.ListOCAprovechamientoDirecto = (from p in oListTempOblicagContractual where p.COD_OCONTRACTUAL == "04" select p).ToList<CEntidad>();
                            }
                        }
                        #endregion
                        #region ListISupervDevolTroza
                        // DEVOLUCION TROZA
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            Int32 num_fila = 0;
                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidad();
                                ocampoEnt.NUMERO_FILA = num_fila;
                                ocampoEnt.COD_THABILITANTE = dr["COD_THABILITANTE"].ToString();
                                ocampoEnt.COD_DEVOLUCION = dr["COD_DEVOLUCION"].ToString();
                                ocampoEnt.COD_ESPECIES = dr["COD_ESPECIES"].ToString();
                                ocampoEnt.DESC_ESPECIES = dr["DESC_ESPECIES"].ToString();
                                ocampoEnt.COD_SECUENCIAL = Int32.Parse(dr["COD_SECUENCIAL"].ToString());
                                ocampoEnt.DAP = Decimal.Parse(dr["DAP"].ToString());
                                ocampoEnt.ALTURA = Decimal.Parse(dr["ALTURA"].ToString());
                                ocampoEnt.CODIGO = dr["CODIGO"].ToString();
                                ocampoEnt.VOLUMEN = Decimal.Parse(dr["VOLUMEN"].ToString());
                                ocampoEnt.ZONA = dr["ZONA"].ToString();
                                ocampoEnt.COORDENADA_ESTE = Int32.Parse(dr["COORDENADA_ESTE"].ToString());
                                ocampoEnt.COORDENADA_NORTE = Int32.Parse(dr["COORDENADA_NORTE"].ToString());
                                ocampoEnt.NUM_TROZAS = Int32.Parse(dr["NUM_TROZAS"].ToString());
                                ocampoEnt.COD_ESPECIES_CAMPO = dr["COD_ESPECIES_CAMPO"].ToString();
                                ocampoEnt.DAP_CAMPO = Decimal.Parse(dr["DAP_2"].ToString());
                                ocampoEnt.ALTURA_CAMPO = Decimal.Parse(dr["ALTURA_2"].ToString());
                                ocampoEnt.CODIGO_CAMPO = dr["CODIGO_2"].ToString();
                                ocampoEnt.VOLUMEN_CAMPO = Decimal.Parse(dr["VOLUMEN_2"].ToString());
                                ocampoEnt.ZONA_CAMPO = dr["ZONA_2"].ToString();
                                ocampoEnt.COORDENADA_ESTE_CAMPO = Int32.Parse(dr["COORDENADA_ESTE_2"].ToString());
                                ocampoEnt.COORDENADA_NORTE_CAMPO = Int32.Parse(dr["COORDENADA_NORTE_2"].ToString());
                                ocampoEnt.NUM_TROZAS_CAMPO = Int32.Parse(dr["NUM_TROZAS_2"].ToString());
                                ocampoEnt.OBSERVACION = dr["OBSERVACION"].ToString();
                                ocampoEnt.ESTADO_SUPERVISION = Boolean.Parse(dr["ESTADO_SUPERVISION"].ToString());
                                ocampoEnt.RegEstado = 0;
                                lsCEntidad.ListISupervDevolTroza.Add(ocampoEnt);
                            }
                        }
                        #endregion
                        #region ListISupervDevolTocon
                        // DEVOLUCION TOCONES
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            Int32 num_fila = 0;
                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidad();
                                ocampoEnt.NUMERO_FILA = num_fila;
                                ocampoEnt.COD_THABILITANTE = dr["COD_THABILITANTE"].ToString();
                                ocampoEnt.COD_DEVOLUCION = dr["COD_DEVOLUCION"].ToString();
                                ocampoEnt.COD_ESPECIES = dr["COD_ESPECIES"].ToString();
                                ocampoEnt.DESC_ESPECIES = dr["DESC_ESPECIES"].ToString();
                                ocampoEnt.COD_SECUENCIAL = Int32.Parse(dr["COD_SECUENCIAL"].ToString());
                                ocampoEnt.DIAMETRO = Decimal.Parse(dr["DIAMETRO"].ToString());
                                ocampoEnt.CODIGO = dr["CODIGO"].ToString();
                                ocampoEnt.LARGO = Decimal.Parse(dr["LARGO"].ToString());
                                ocampoEnt.VOLUMEN = Decimal.Parse(dr["VOLUMEN"].ToString());
                                ocampoEnt.COORDENADA_ESTE = Int32.Parse(dr["COORDENADA_ESTE"].ToString());
                                ocampoEnt.COORDENADA_NORTE = Int32.Parse(dr["COORDENADA_NORTE"].ToString());
                                ocampoEnt.CANTIDAD = Int32.Parse(dr["CANTIDAD"].ToString());
                                ocampoEnt.COD_ESPECIES_CAMPO = dr["COD_ESPECIES_CAMPO"].ToString();
                                ocampoEnt.DIAMETRO_CAMPO = Decimal.Parse(dr["DIAMETRO_2"].ToString());
                                ocampoEnt.CODIGO_CAMPO = dr["CODIGO_2"].ToString();
                                ocampoEnt.LARGO_CAMPO = Decimal.Parse(dr["LARGO_2"].ToString());
                                ocampoEnt.VOLUMEN_CAMPO = Decimal.Parse(dr["VOLUMEN_2"].ToString());
                                ocampoEnt.ZONA_CAMPO = dr["ZONA_2"].ToString();
                                ocampoEnt.COORDENADA_ESTE_CAMPO = Int32.Parse(dr["COORDENADA_ESTE_2"].ToString());
                                ocampoEnt.COORDENADA_NORTE_CAMPO = Int32.Parse(dr["COORDENADA_NORTE_2"].ToString());
                                ocampoEnt.CANTIDAD_CAMPO = Int32.Parse(dr["CANTIDAD_2"].ToString());
                                ocampoEnt.OBSERVACION = dr["OBSERVACION"].ToString();
                                ocampoEnt.ESTADO_SUPERVISION = Boolean.Parse(dr["ESTADO_SUPERVISION"].ToString());
                                ocampoEnt.RegEstado = 0;

                                lsCEntidad.ListISupervDevolTocon.Add(ocampoEnt);
                            }
                        }
                        #endregion
                        #region ListISupervDevolArbol
                        // DEVOLUCION ARBOL
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            Int32 num_fila = 0;
                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidad();
                                ocampoEnt.NUMERO_FILA = num_fila;
                                ocampoEnt.COD_THABILITANTE = dr["COD_THABILITANTE"].ToString();
                                ocampoEnt.COD_DEVOLUCION = dr["COD_DEVOLUCION"].ToString();
                                ocampoEnt.COD_ESPECIES = dr["COD_ESPECIES"].ToString();
                                ocampoEnt.DESC_ESPECIES = dr["DESC_ESPECIES"].ToString();
                                ocampoEnt.COD_SECUENCIAL = Int32.Parse(dr["COD_SECUENCIAL"].ToString());
                                ocampoEnt.NUM_PCA = dr["NUM_PCA"].ToString();
                                ocampoEnt.CODIGO = dr["CODIGO"].ToString();
                                ocampoEnt.DAP = Decimal.Parse(dr["DAP"].ToString());
                                ocampoEnt.ALTURA = Decimal.Parse(dr["ALTURA"].ToString());
                                ocampoEnt.VOLUMEN = Decimal.Parse(dr["VOLUMEN"].ToString());
                                ocampoEnt.COORDENADA_ESTE = Int32.Parse(dr["COORDENADA_ESTE"].ToString());
                                ocampoEnt.COORDENADA_NORTE = Int32.Parse(dr["COORDENADA_NORTE"].ToString());
                                ocampoEnt.COD_EESTADO = dr["COD_EESTADO"].ToString();
                                ocampoEnt.COD_ESPECIES_CAMPO = dr["COD_ESPECIES_CAMPO"].ToString();
                                ocampoEnt.NUM_PCA_CAMPO = dr["NUM_PCA_2"].ToString();
                                ocampoEnt.CODIGO_CAMPO = dr["CODIGO_2"].ToString();
                                ocampoEnt.DAP_CAMPO = Decimal.Parse(dr["DAP_2"].ToString());
                                ocampoEnt.ALTURA_CAMPO = Decimal.Parse(dr["ALTURA_2"].ToString());
                                ocampoEnt.VOLUMEN_CAMPO = Decimal.Parse(dr["VOLUMEN_2"].ToString());
                                ocampoEnt.ZONA_CAMPO = dr["ZONA_2"].ToString();
                                ocampoEnt.COORDENADA_ESTE_CAMPO = Int32.Parse(dr["COORDENADA_ESTE_2"].ToString());
                                ocampoEnt.COORDENADA_NORTE_CAMPO = Int32.Parse(dr["COORDENADA_NORTE_2"].ToString());
                                ocampoEnt.COD_EESTADO = dr["COD_EESTADO_2"].ToString();
                                ocampoEnt.OBSERVACION = dr["OBSERVACION"].ToString();
                                //ocampoEnt.COD_ACATEGORIA = dr["COD_ACATEGORIA_2"].ToString();
                                ocampoEnt.ESTADO_SUPERVISION = Boolean.Parse(dr["ESTADO_SUPERVISION"].ToString());
                                ocampoEnt.RegEstado = 0;
                                lsCEntidad.ListISupervDevolArbol.Add(ocampoEnt);
                            }
                        }
                        #endregion
                        #region ListAvistamientoFauna
                        // AVISTAMIENTO FAUNA SILVESTRE
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidad();
                                ocampoEnt.COD_ESPECIES = dr["COD_ESPECIES"].ToString();
                                ocampoEnt.DESC_ESPECIES = dr["DESC_ESPECIES"].ToString();
                                ocampoEnt.COD_SECUENCIAL = Int32.Parse(dr["COD_SECUENCIAL"].ToString());
                                ocampoEnt.NOMBRE_COMUN = dr["NOMBRE_COMUN"].ToString();
                                ocampoEnt.NUM_INDIVIDUOS = Int32.Parse(dr["NUM_INDIVIDUOS"].ToString());
                                ocampoEnt.COD_TIPO_REGISTRO = dr["COD_TIPO_REGISTRO"].ToString();
                                ocampoEnt.DESC_TIPO_REGISTRO = dr["DESC_TIPO_REGISTRO"].ToString();
                                ocampoEnt.COD_ESTRATO = dr["COD_ESTRATO"].ToString();
                                ocampoEnt.DESC_ESTRATO = dr["DESC_ESTRATO"].ToString();
                                ocampoEnt.FECHA_AVISTAMIENTO = dr["FECHA_AVISTAMIENTO"].ToString();
                                ocampoEnt.HORA_AVISTAMIENTO = dr["HORA_AVISTAMIENTO"].ToString();
                                ocampoEnt.ZONA = dr["ZONA"].ToString();
                                ocampoEnt.COORDENADA_ESTE = Int32.Parse(dr["COORDENADA_ESTE"].ToString());
                                ocampoEnt.COORDENADA_NORTE = Int32.Parse(dr["COORDENADA_NORTE"].ToString());
                                ocampoEnt.ALTITUD = Decimal.Parse(dr["ALTITUD"].ToString());
                                ocampoEnt.DESCRIPCION = dr["DESCRIPCION"].ToString();
                                ocampoEnt.RegEstado = 0;
                                lsCEntidad.ListAvistamientoFauna.Add(ocampoEnt);
                            }
                        }
                        #endregion
                        #region ListVolInjustificado
                        // VOLUMEN INJUSTIFICADO
                        //dr.NextResult();
                        //if (dr.HasRows)
                        //{     
                        //	while (dr.Read())
                        //	{
                        //		ocampoEnt = new CEntidad();
                        //		ocampoEnt.COD_ENCIENTIFICO = dr["COD_ENCIENTIFICO"].ToString();
                        //		ocampoEnt.NOMBRE_CIENTIFICO = dr["NOMBRE_CIENTIFICO"].ToString();
                        //		ocampoEnt.COD_SECUENCIAL = Int32.Parse(dr["COD_SECUENCIAL"].ToString());
                        //		ocampoEnt.NOMBRE_COMUN = dr["NOMBRE_COMUN"].ToString();
                        //		ocampoEnt.VOLUMEN = Decimal.Parse(dr["VOLUMEN"].ToString());
                        //		ocampoEnt.NUM_POA = Int32.Parse(dr["NUM_POA"].ToString());
                        //		ocampoEnt.POA = dr["POA"].ToString();
                        //		ocampoEnt.OBSERVACION = dr["OBSERVACION"].ToString();
                        //		ocampoEnt.TIPOMADERABLE = dr["TIPOMADERABLE"].ToString();
                        //		ocampoEnt.RegEstado = 0;
                        //		lsCEntidad.ListVolInjustificado.Add(ocampoEnt);
                        //	}
                        //}
                        #endregion
                        #region ListFotos
                        // INFORME FOTOS
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                CEntidad ocampo = new CEntidad();
                                ocampo.COD_INFORME_FOTOS = dr["COD_INFORME_FOTOS"].ToString();
                                ocampo.COD_INFORME = dr["COD_INFORME"].ToString();
                                ocampo.COD_THABILITANTE = dr["COD_THABILITANTE"].ToString();
                                ocampo.COD_UCUENTA = dr["COD_UCUENTA"].ToString();
                                ocampo.URL_FOTO = dr["URL_FOTO"].ToString();
                                ocampo.DESC_FOTO = dr["DESCRIPCION"].ToString();
                                ocampo.FUENTE_FOTO = dr["FUENTE"].ToString();
                                ocampo.DISP_FOTO = dr["DISPOSITIVO"].ToString();
                                ocampo.NUMERO = lsCEntidad.NUMERO;
                                ocampo.NUM_THABILITANTE = lsCEntidad.NUM_THABILITANTE;
                                ocampo.FECHA = dr["FECHA"].ToString();
                                ocampo.RegEstado = 0;
                                lsCEntidad.ListFotos.Add(ocampo);
                            }
                        }
                        #endregion
                        #region ListMuestraNoMadeCarrizos
                        // muestra no maderable carrizos
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                CEntidad ocampo = new CEntidad();
                                ocampo.COD_INFORME = dr["COD_INFORME"].ToString();
                                ocampo.COD_MUESTRA_SUPERVISION = dr["COD_MUESTRA_SUPERVISION"].ToString();
                                ocampo.DESC_ESPECIES = dr["DESCRIPCION"].ToString();
                                ocampo.TOTAL_UNIDADES = Int32.Parse(dr["TOTAL_UNIDAD_MUEST"].ToString());
                                ocampo.TOTAL_UNIDADES_APROVECHABLES = Int32.Parse(dr["TOTAL_UNIDADES_APROV"].ToString());
                                ocampo.ZONA = dr["ZONA"].ToString();
                                ocampo.COORDENADA_ESTE = Int32.Parse(dr["COORDENADA_ESTE"].ToString());
                                ocampo.COORDENADA_NORTE = Int32.Parse(dr["COORDENADA_NORTE"].ToString());
                                ocampo.ALTURA_PROMEDIO = Decimal.Parse(dr["ALTURA_PROMEDIO"].ToString());
                                ocampo.OBSERVACION = dr["OBSERVACION"].ToString();
                                ocampo.RegEstado = 0;
                                lsCEntidad.ListMuestraNoMadeCarrizos.Add(ocampo);
                            }
                        }
                        #endregion
                        #region ListMuestraNoMadePMed
                        // muestra no maderable plantas medicinales
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                CEntidad ocampo = new CEntidad();
                                ocampo.COD_INFORME = dr["COD_INFORME"].ToString();
                                ocampo.COD_MUESTRA_SUPERVISION = dr["COD_MUESTRA_SUPERVISION"].ToString();
                                ocampo.DESC_ESPECIES = dr["DESCRIPCION"].ToString();
                                ocampo.UNIDAD_MEDIDA = dr["UNIDAD_MEDIDA"].ToString();
                                ocampo.NUM_INDIVIDUOS = Int32.Parse(dr["NUM_INDIVIDUOS"].ToString());
                                ocampo.ZONA = dr["ZONA"].ToString();
                                ocampo.COORDENADA_ESTE = Int32.Parse(dr["COORDENADA_ESTE"].ToString());
                                ocampo.COORDENADA_NORTE = Int32.Parse(dr["COORDENADA_NORTE"].ToString());
                                ocampo.OBSERVACION = dr["OBSERVACION"].ToString();
                                ocampo.RegEstado = 0;
                                lsCEntidad.ListMuestraNoMadePMed.Add(ocampo);
                            }
                        }
                        #endregion
                        #region ListVerticesVerificar
                        // VERTICES
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                CEntidad ocampo = new CEntidad();
                                ocampo.COD_INFORME = dr["COD_INFORME"].ToString();
                                ocampo.COD_INFORME_VERTICE = dr["COD_INFORME_VERTICE"].ToString();
                                ocampo.VERTICE_POA = dr["VERTICE_POA"].ToString();
                                ocampo.VERTICE_CAMPO = dr["VERTICE_CAMPO"].ToString();
                                ocampo.ZONA = dr["ZONA"].ToString();
                                ocampo.ZONA_CAMPO = dr["ZONA_CAMPO"].ToString();
                                ocampo.COORDENADA_ESTE = Int32.Parse(dr["COORDENADA_ESTE_POA"].ToString());
                                ocampo.COORDENADA_ESTE_CAMPO = Int32.Parse(dr["COORDENADA_ESTE_CAMPO"].ToString());
                                ocampo.COORDENADA_NORTE = Int32.Parse(dr["COORDENADA_NORTE_POA"].ToString());
                                ocampo.COORDENADA_NORTE_CAMPO = Int32.Parse(dr["COORDENADA_NORTE_CAMPO"].ToString());
                                ocampo.OBSERVACION = dr["OBSERVACION"].ToString();
                                ocampo.RegEstado = 0;
                                lsCEntidad.ListVerticesVerificar.Add(ocampo);
                            }
                        }
                        #endregion
                        #region ListISupervMaderableNoAutorizado
                        //Maderable No Autorizados
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            Int32 num_fila = 0;
                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidad();
                                ocampoEnt.NUMERO_FILA = num_fila;
                                ocampoEnt.COD_ESPECIES = dr["COD_ESPECIES"].ToString();
                                ocampoEnt.DESC_ESPECIES = dr["DESC_ESPECIES"].ToString();
                                ocampoEnt.COD_SECUENCIAL = Int32.Parse(dr["COD_SECUENCIAL"].ToString());
                                ocampoEnt.BLOQUE = dr["BLOQUE"].ToString();
                                ocampoEnt.FAJA = dr["FAJA"].ToString();
                                ocampoEnt.CODIGO = dr["CODIGO"].ToString();
                                ocampoEnt.DAP = Decimal.Parse(dr["DAP"].ToString());
                                ocampoEnt.AC = Decimal.Parse(dr["AC"].ToString());
                                ocampoEnt.ZONA = dr["ZONA"].ToString();
                                ocampoEnt.COORDENADA_ESTE = Int32.Parse(dr["COORDENADA_ESTE"].ToString());
                                ocampoEnt.COORDENADA_NORTE = Int32.Parse(dr["COORDENADA_NORTE"].ToString());
                                ocampoEnt.COD_ECONDICION = dr["COD_ECONDICION"].ToString();
                                ocampoEnt.DESC_ECONDICION = dr["DESC_ECONDICION"].ToString();
                                ocampoEnt.COD_EESTADO = dr["COD_EESTADO"].ToString();
                                ocampoEnt.DESC_EESTADO = dr["DESC_EESTADO"].ToString();
                                //ocampoEnt.COD_ACATEGORIA = dr["COD_ACATEGORIA"].ToString();
                                ocampoEnt.DESC_ACATEGORIA_CITE = dr["DESC_ACATEGORIA_CITE"].ToString();
                                ocampoEnt.DESC_ACATEGORIA_DS = dr["DESC_ACATEGORIA_DS"].ToString();
                                ocampoEnt.OBSERVACION = dr["OBSERVACION"].ToString();
                                ocampoEnt.NUM_POA = Int32.Parse(dr["NUM_POA"].ToString());
                                ocampoEnt.POA = dr["POA"].ToString();
                                ocampoEnt.DAP2 = Decimal.Parse(dr["DAP_2"].ToString());
                                ocampoEnt.DAP1 = Decimal.Parse(dr["DAP_1"].ToString());
                                ocampoEnt.MAE_TIP_MMEDIRDAP = dr["MAE_TIP_MMEDIRDAP"].ToString();
                                ocampoEnt.MMEDIR_DAP = dr["MMEDIR_DAP"].ToString();
                                ocampoEnt.RegEstado = 0;
                                lsCEntidad.ListISupervMaderableNoAutorizado.Add(ocampoEnt);
                                num_fila++;
                            }
                        }
                        #endregion
                        #region ListISupervCambioUso
                        //CAMBIO DE USO ISUPERVICIÓN
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidad();
                                ocampoEnt.COD_INFORME = dr["COD_INFORME"].ToString();
                                ocampoEnt.MAE_TIP_CAMBIOUSO = dr["MAE_TIP_CAMBIOUSO"].ToString();
                                ocampoEnt.COD_SECUENCIAL = Int32.Parse(dr["COD_SECUENCIAL"].ToString());
                                ocampoEnt.AREA = Decimal.Parse(dr["AREA"].ToString());
                                ocampoEnt.OBSERVACION = dr["OBSERVACION"].ToString();
                                ocampoEnt.NOM_TIP_CAMBIOUSO = dr["NOM_TIP_CAMBIOUSO"].ToString();
                                ocampoEnt.NUM_POA = Int32.Parse(dr["NUM_POA"].ToString());
                                ocampoEnt.POA = dr["POA"].ToString();
                                ocampoEnt.RegEstado = 0;

                                lsCEntidad.ListISupervCambioUso.Add(ocampoEnt);
                            }
                        }
                        #endregion
                        #region ListISupervLindAreaVertice
                        //VERTICES LINDERAMIENTO AREA TITULO HABILITANTE
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidad();
                                ocampoEnt.COD_INFORME = dr["COD_INFORME"].ToString();
                                ocampoEnt.COD_SECUENCIAL = Int32.Parse(dr["COD_SECUENCIAL"].ToString());
                                ocampoEnt.ZONA = dr["ZONA"].ToString();
                                ocampoEnt.COORDENADA_ESTE = Int32.Parse(dr["COORDENADA_ESTE"].ToString());
                                ocampoEnt.COORDENADA_NORTE = Int32.Parse(dr["COORDENADA_NORTE"].ToString());
                                ocampoEnt.OBSERVACION = dr["OBSERVACION"].ToString();
                                ocampoEnt.VERTICE = dr["VERTICE"].ToString();
                                ocampoEnt.NUM_POA = Int32.Parse(dr["NUM_POA"].ToString());
                                ocampoEnt.POA = dr["POA"].ToString();
                                ocampoEnt.RegEstado = 0;

                                lsCEntidad.ListISupervLindAreaVertice.Add(ocampoEnt);
                            }
                        }
                        #endregion
                        #region ListISupervInfoDocument
                        //INFORMACIÓN DOCUMENTARIA DE LOS POA's
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidad();
                                ocampoEnt.COD_INFORME = dr["COD_INFORME"].ToString();
                                ocampoEnt.NUM_POA = Int32.Parse(dr["NUM_POA"].ToString());
                                ocampoEnt.FEC_PRESENT_PM = dr["FEC_PRESENT_PM"].ToString();
                                ocampoEnt.FEC_APROB_PM = dr["FEC_APROB_PM"].ToString();
                                ocampoEnt.CUMPLE_PM_PGMF = Boolean.Parse(dr["CUMPLE_PM_PGMF"].ToString());
                                ocampoEnt.OBSERV_PM_PGMF = dr["OBSERV_PM_PGMF"].ToString();
                                ocampoEnt.APROB_NORMAVIGENTE_PM = Boolean.Parse(dr["APROB_NORMAVIGENTE_PM"].ToString());
                                ocampoEnt.OBSERV_NORMAVIGENTE_PM = dr["OBSERV_NORMAVIGENTE_PM"].ToString();
                                ocampoEnt.CUENTA_INFOEJECPO = dr["CUENTA_INFOEJECPO"].ToString();

                                ocampoEnt.FEC_PRESENT_INFOEJECPO = dr["FEC_PRESENT_INFOEJECPO"].ToString();
                                ocampoEnt.FEC_COMUNIC_INFOEJECPO = dr["FEC_COMUNIC_INFOEJECPO"].ToString();
                                ocampoEnt.CUMPLE_LINEA_INFOEJECPO = Boolean.Parse(dr["CUMPLE_LINEA_INFOEJECPO"].ToString());
                                ocampoEnt.OBSERV_LINEA_INFOEJECPO = dr["OBSERV_LINEA_INFOEJECPO"].ToString();

                                ocampoEnt.CUMPLE_VIAL_PLANMAN = Boolean.Parse(dr["CUMPLE_VIAL_PLANMAN"].ToString());
                                ocampoEnt.INDICIO_APROV = Boolean.Parse(dr["INDICIO_APROV"].ToString());
                                ocampoEnt.OBSERV_APROV = dr["OBSERV_APROV"].ToString();
                                ocampoEnt.CUMPLE_PAGO_APROV = Boolean.Parse(dr["CUMPLE_PAGO_APROV"].ToString());
                                ocampoEnt.OBSERV_PAGO_APROV = dr["OBSERV_PAGO_APROV"].ToString();
                                ocampoEnt.COD_RESODIREC_GRAVEDAD = dr["COD_RESODIREC_GRAVEDAD"].ToString();
                                ocampoEnt.LINDERAMIENTO_AREA = dr["LINDERAMIENTO_AREA"].ToString();

                                ocampoEnt.INEX_AGUAJAL = dr.GetBoolean(dr.GetOrdinal("INEX_AGUAJAL"));
                                ocampoEnt.INEX_AGUAJAL_PORC = dr.GetDecimal(dr.GetOrdinal("INEX_AGUAJAL_PORC"));
                                ocampoEnt.INEX_AGUAJAL_NOUB = dr.GetInt32(dr.GetOrdinal("INEX_AGUAJAL_NOUB"));
                                ocampoEnt.INEX_AGUAJAL_OBS = dr.GetString(dr.GetOrdinal("INEX_AGUAJAL_OBS"));
                                ocampoEnt.INEX_PASTIZAL = dr.GetBoolean(dr.GetOrdinal("INEX_PASTIZAL"));
                                ocampoEnt.INEX_PASTIZAL_PORC = dr.GetDecimal(dr.GetOrdinal("INEX_PASTIZAL_PORC"));
                                ocampoEnt.INEX_PASTIZAL_NOUB = dr.GetInt32(dr.GetOrdinal("INEX_PASTIZAL_NOUB"));
                                ocampoEnt.INEX_PASTIZAL_OBS = dr.GetString(dr.GetOrdinal("INEX_PASTIZAL_OBS"));
                                ocampoEnt.INEX_INACCESIBLE = dr.GetBoolean(dr.GetOrdinal("INEX_INACCESIBLE"));
                                ocampoEnt.INEX_INACCESIBLE_PORC = dr.GetDecimal(dr.GetOrdinal("INEX_INACCESIBLE_PORC"));
                                ocampoEnt.INEX_INACCESIBLE_NOUB = dr.GetInt32(dr.GetOrdinal("INEX_INACCESIBLE_NOUB"));
                                ocampoEnt.INEX_INACCESIBLE_OBS = dr.GetString(dr.GetOrdinal("INEX_INACCESIBLE_OBS"));
                                ocampoEnt.INEX_OTROS = dr.GetBoolean(dr.GetOrdinal("INEX_OTROS"));
                                ocampoEnt.INEX_OTROS_PORC = dr.GetDecimal(dr.GetOrdinal("INEX_OTROS_PORC"));
                                ocampoEnt.INEX_OTROS_NOUB = dr.GetInt32(dr.GetOrdinal("INEX_OTROS_NOUB"));
                                ocampoEnt.INEX_OTROS_OBS = dr.GetString(dr.GetOrdinal("INEX_OTROS_OBS"));

                                ocampoEnt.MAE_TIP_IEJECFOREST = dr.GetString(dr.GetOrdinal("MAE_TIP_IEJECFOREST"));
                                ocampoEnt.FEC_ENTREGA_ACERVO = dr.GetString(dr.GetOrdinal("FEC_ENTREGA_ACERVO"));

                                ocampoEnt.COD_TITULAR_EJECUTA = dr.GetString(dr.GetOrdinal("COD_TITULAR_EJECUTA"));
                                ocampoEnt.TITULAR_EJECUTA = dr.GetString(dr.GetOrdinal("TITULAR_EJECUTA"));
                                ocampoEnt.COD_REGENTE_IMPLEMENTA = dr.GetString(dr.GetOrdinal("COD_REGENTE_IMPLEMENTA"));
                                ocampoEnt.REGENTE_IMPLEMENTA = dr.GetString(dr.GetOrdinal("REGENTE_IMPLEMENTA"));
                                ocampoEnt.MAE_EST_APROVECHA = dr.GetString(dr.GetOrdinal("MAE_EST_APROVECHA"));

                                ocampoEnt.RECOMEND_REFORMULA = dr.GetBoolean(dr.GetOrdinal("RECOMEND_REFORMULA"));
                                ocampoEnt.RECOMEND_DESCRIPCION = dr.GetString(dr.GetOrdinal("RECOMEND_DESCRIPCION"));

                                ocampoEnt.RegEstado = 0;

                                lsCEntidad.ListISupervInfoDocument.Add(ocampoEnt);
                            }
                        }
                        #endregion
                        #region ListISupervMadeNoMade
                        //INFORMACIÓN MADERABLE|NO MADERABLE de los POA's
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidad();
                                ocampoEnt.COD_INFORME = dr["COD_INFORME"].ToString();
                                ocampoEnt.NUM_POA = Int32.Parse(dr["NUM_POA"].ToString());
                                ocampoEnt.CUENTA_AREPOSICION = dr.GetString(dr.GetOrdinal("CUENTA_AREPOSICION"));
                                ocampoEnt.AREA_DEMARCACION = dr.GetString(dr.GetOrdinal("AREA_DEMARCACION"));
                                ocampoEnt.AREA_LINDERAMIENTO = dr.GetString(dr.GetOrdinal("AREA_LINDERAMIENTO"));
                                ocampoEnt.TIPO_SAPROVECHAMIENTO = dr.GetString(dr.GetOrdinal("TIPO_SAPROVECHAMIENTO"));

                                ocampoEnt.RegEstado = 0;

                                lsCEntidad.ListISupervMadeNoMade.Add(ocampoEnt);
                            }
                        }
                        #endregion
                        #region ListVolJustificado
                        // VOLUMEN JUSTIFICADO
                        //dr.NextResult();
                        //if (dr.HasRows)
                        //{
                        //	while (dr.Read())
                        //	{
                        //		ocampoEnt = new CEntidad();
                        //		ocampoEnt.COD_ENCIENTIFICO = dr["COD_ENCIENTIFICO"].ToString();
                        //		ocampoEnt.NOMBRE_CIENTIFICO = dr["NOMBRE_CIENTIFICO"].ToString();
                        //		ocampoEnt.COD_SECUENCIAL = Int32.Parse(dr["COD_SECUENCIAL"].ToString());
                        //		ocampoEnt.NOMBRE_COMUN = dr["NOMBRE_COMUN"].ToString();
                        //		ocampoEnt.VOLUMEN = Decimal.Parse(dr["VOLUMEN"].ToString());
                        //		ocampoEnt.NUM_POA = Int32.Parse(dr["NUM_POA"].ToString());
                        //		ocampoEnt.POA = dr["POA"].ToString();
                        //		ocampoEnt.OBSERVACION = dr["OBSERVACION"].ToString();
                        //		ocampoEnt.TIPOMADERABLE = dr["TIPOMADERABLE"].ToString();
                        //		ocampoEnt.JUSTIFICADO = dr.GetBoolean(dr.GetOrdinal("JUSTIFICADO"));
                        //		ocampoEnt.RegEstado = 0;
                        //		lsCEntidad.ListVolJustificado.Add(ocampoEnt);
                        //	}
                        //}
                        #endregion
                        #region ListTrozaCampo
                        //Registro TROZA
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidad();
                                ocampoEnt.COD_THABILITANTE = dr["COD_THABILITANTE"].ToString();
                                ocampoEnt.NUM_POA = Int32.Parse(dr["NUM_POA"].ToString());
                                ocampoEnt.POA = dr["POA"].ToString();
                                ocampoEnt.COD_SECUENCIAL = Int32.Parse(dr["COD_SECUENCIAL"].ToString());
                                ocampoEnt.COD_ESPECIES = dr["COD_ESPECIES"].ToString();
                                ocampoEnt.ESPECIES = dr["ESPECIES"].ToString();
                                ocampoEnt.ZONA = dr["ZONA"].ToString();
                                ocampoEnt.COORDENADA_ESTE = Int32.Parse(dr["COORDENADA_ESTE"].ToString());
                                ocampoEnt.COORDENADA_NORTE = Int32.Parse(dr["COORDENADA_NORTE"].ToString());
                                ocampoEnt.DAP1 = Decimal.Parse(dr["DAP1"].ToString());
                                ocampoEnt.DAP2 = Decimal.Parse(dr["DAP2"].ToString());
                                ocampoEnt.LC = Decimal.Parse(dr["LC"].ToString());
                                ocampoEnt.OBSERVACION = dr["OBSERVACION"].ToString();
                                ocampoEnt.NOMBRE_CIENTIFICO = dr["NOMBRE_CIENTIFICO"].ToString();
                                ocampoEnt.NOMBRE_COMUN = dr["NOMBRE_COMUN"].ToString();
                                ocampoEnt.CODIGO = dr["CODIGO"].ToString();
                                ocampoEnt.RegEstado = 0;
                                lsCEntidad.ListTrozaCampo.Add(ocampoEnt);
                            }
                        }
                        #endregion
                        #region ListMadeAserradaCampo
                        //Registro Madera Aserrada en Campo
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidad();
                                ocampoEnt.COD_THABILITANTE = dr["COD_THABILITANTE"].ToString();
                                ocampoEnt.NUM_POA = Int32.Parse(dr["NUM_POA"].ToString());
                                ocampoEnt.POA = dr["POA"].ToString();
                                ocampoEnt.COD_SECUENCIAL = Int32.Parse(dr["COD_SECUENCIAL"].ToString());
                                ocampoEnt.CODIGO = dr["CODIGO"].ToString();
                                ocampoEnt.COD_ESPECIES = dr["COD_ESPECIES"].ToString();
                                ocampoEnt.ESPECIES = dr["ESPECIES"].ToString();
                                ocampoEnt.NOMBRE_CIENTIFICO = dr["NOMBRE_CIENTIFICO"].ToString();
                                ocampoEnt.NOMBRE_COMUN = dr["NOMBRE_COMUN"].ToString();
                                ocampoEnt.PIEZAS = Int32.Parse(dr["PIEZAS"].ToString());
                                ocampoEnt.ZONA = dr["ZONA"].ToString();
                                ocampoEnt.COORDENADA_ESTE = Int32.Parse(dr["COORDENADA_ESTE"].ToString());
                                ocampoEnt.COORDENADA_NORTE = Int32.Parse(dr["COORDENADA_NORTE"].ToString());
                                ocampoEnt.ESPESOR = Decimal.Parse(dr["ESPESOR"].ToString());
                                ocampoEnt.ANCHO = Decimal.Parse(dr["ANCHO"].ToString());
                                ocampoEnt.LARGO = Decimal.Parse(dr["LARGO"].ToString());
                                ocampoEnt.OBSERVACION = dr["OBSERVACION"].ToString();
                                ocampoEnt.RegEstado = 0;
                                lsCEntidad.ListMadeAserradaCampo.Add(ocampoEnt);
                            }
                        }
                        #endregion
                        #region ListTHVerticeCampo
                        //Registro vertices título habilitante obtenido en Campo
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidad();
                                ocampoEnt.COD_THABILITANTE = dr["COD_THABILITANTE"].ToString();
                                ocampoEnt.COD_SECUENCIAL_ADENDA = Int32.Parse(dr["COD_SECUENCIAL_ADENDA"].ToString());
                                ocampoEnt.COD_SECUENCIAL = Int32.Parse(dr["COD_SECUENCIAL"].ToString());
                                ocampoEnt.VERTICE = dr["VERTICE"].ToString();
                                ocampoEnt.VERTICE_CAMPO = dr["VERTICE_CAMPO"].ToString();
                                ocampoEnt.ZONA = dr["ZONA"].ToString();
                                ocampoEnt.ZONA_CAMPO = dr["ZONA_CAMPO"].ToString();
                                ocampoEnt.COORDENADA_ESTE = Int32.Parse(dr["COORDENADA_ESTE"].ToString());
                                ocampoEnt.COORDENADA_ESTE_CAMPO = Int32.Parse(dr["COORDENADA_ESTE_CAMPO"].ToString());
                                ocampoEnt.COORDENADA_NORTE = Int32.Parse(dr["COORDENADA_NORTE"].ToString());
                                ocampoEnt.COORDENADA_NORTE_CAMPO = Int32.Parse(dr["COORDENADA_NORTE_CAMPO"].ToString());
                                ocampoEnt.OBSERVACION_CAMPO = dr["OBSERVACION_CAMPO"].ToString();
                                ocampoEnt.CODIGO = dr["CODIGO"].ToString();
                                ocampoEnt.RegEstado = 0;
                                lsCEntidad.ListTHVerticeCampo.Add(ocampoEnt);
                            }
                        }
                        #endregion
                        #region ListTHVertice
                        //Vertices título habilitante cruzado con los vertices obtenidos en campo
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidad();
                                ocampoEnt.COD_INFORME = dr["COD_INFORME"].ToString();
                                ocampoEnt.CODIGO = dr["CODIGO"].ToString();
                                ocampoEnt.DESCRIPCION = dr["DESCRIPCION"].ToString();
                                ocampoEnt.COD_SISTEMA = dr["COD_SISTEMA"].ToString();
                                ocampoEnt.VERTICE = dr["VERTICE"].ToString();
                                ocampoEnt.VERTICE_CAMPO = dr["VERTICE_CAMPO"].ToString();
                                ocampoEnt.ZONA = dr["ZONA"].ToString();
                                ocampoEnt.ZONA_CAMPO = dr["ZONA_CAMPO"].ToString();
                                ocampoEnt.COORDENADA_ESTE = Int32.Parse(dr["COORDENADA_ESTE"].ToString());
                                ocampoEnt.COORDENADA_ESTE_CAMPO = Int32.Parse(dr["COORDENADA_ESTE_CAMPO"].ToString());
                                ocampoEnt.COORDENADA_NORTE = Int32.Parse(dr["COORDENADA_NORTE"].ToString());
                                ocampoEnt.COORDENADA_NORTE_CAMPO = Int32.Parse(dr["COORDENADA_NORTE_CAMPO"].ToString());
                                ocampoEnt.OBSERVACION_CAMPO = dr["OBSERVACION_CAMPO"].ToString();
                                ocampoEnt.RegEstado = 0;
                                lsCEntidad.ListTHVertice.Add(ocampoEnt);
                            }
                        }
                        #endregion
                        #region ListEvaluacionOtros
                        //Otros puntos de evaluación
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidad();
                                ocampoEnt.COD_THABILITANTE = dr["COD_THABILITANTE"].ToString();
                                ocampoEnt.NUM_POA = Int32.Parse(dr["NUM_POA"].ToString());
                                ocampoEnt.POA = dr["POA"].ToString();
                                ocampoEnt.COD_SECUENCIAL = Int32.Parse(dr["COD_SECUENCIAL"].ToString());
                                ocampoEnt.EVALUACION = dr["EVALUACION"].ToString();
                                ocampoEnt.ZONA = dr["ZONA"].ToString();
                                ocampoEnt.COORDENADA_ESTE = Int32.Parse(dr["COORDENADA_ESTE"].ToString());
                                ocampoEnt.COORDENADA_NORTE = Int32.Parse(dr["COORDENADA_NORTE"].ToString());
                                ocampoEnt.DESCRIPCION = dr["DESCRIPCION"].ToString();
                                ocampoEnt.RegEstado = 0;
                                lsCEntidad.ListEvaluacionOtros.Add(ocampoEnt);
                            }
                        }
                        #endregion
                        #region ListVolumen
                        // VOLUMEN JUSTIFICADO E INJUSTIFICADO
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidad();
                                ocampoEnt.COD_SECUENCIAL = Int32.Parse(dr["COD_SECUENCIAL"].ToString());
                                ocampoEnt.NUM_POA = Int32.Parse(dr["NUM_POA"].ToString());
                                ocampoEnt.POA = dr["POA"].ToString();
                                ocampoEnt.COD_ESPECIES = dr["COD_ESPECIES"].ToString();
                                ocampoEnt.ESPECIES = dr["ESPECIES"].ToString();
                                ocampoEnt.VOLUMEN_APROBADO = Decimal.Parse(dr["VOLUMEN_APROBADO"].ToString());
                                ocampoEnt.VOLUMEN_MOVILIZADO = Decimal.Parse(dr["VOLUMEN_MOVILIZADO"].ToString());
                                ocampoEnt.VOLUMEN_INJUSTIFICADO = Decimal.Parse(dr["VOLUMEN_INJUSTIFICADO"].ToString());
                                ocampoEnt.VOLUMEN_JUSTIFICADO = Decimal.Parse(dr["VOLUMEN_JUSTIFICADO"].ToString());
                                ocampoEnt.OBSERVACION = dr["OBSERVACION"].ToString();
                                ocampoEnt.RegEstado = 0;
                                lsCEntidad.ListVolumen.Add(ocampoEnt);
                            }
                        }
                        #endregion
                        #region ListPOA's Publicar
                        // POA con Check Publicar
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidad();
                                ocampoEnt.NUM_POA = Int32.Parse(dr["NUM_POA"].ToString());
                                ocampoEnt.POA = dr["POA"].ToString();
                                ocampoEnt.PUBLICAR = Convert.ToBoolean(dr["PUBLICAR"].ToString());
                                ocampoEnt.SUPERVISADO = Convert.ToBoolean(dr["SUPERVISADO"].ToString());
                                lsCEntidad.ListPOAs.Add(ocampoEnt);
                            }
                        }
                        #endregion
                        #region ListDesplazamiento
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidad();
                                ocampoEnt.COD_DESPLAZAMIENTO = dr["COD_DESPLAZAMIENTO"].ToString();
                                ocampoEnt.COORDENADA_ESTE = Int32.Parse(dr["PTOI_COORDENADA_ESTE"].ToString());
                                ocampoEnt.COORDENADA_NORTE = Int32.Parse(dr["PTOI_COORDENADA_NORTE"].ToString());
                                ocampoEnt.COORDENADA_ESTE_CAMPO = Int32.Parse(dr["PTOF_COORDENADA_ESTE"].ToString());
                                ocampoEnt.COORDENADA_NORTE_CAMPO = Int32.Parse(dr["PTOF_COORDENADA_NORTE"].ToString());
                                ocampoEnt.OBSERVACION = dr["OBSERVACION"].ToString();
                                ocampoEnt.TipoVia = dr["TIPO"].ToString();
                                ocampoEnt.RegEstado = 0;
                                lsCEntidad.ListDesplazamientoInforme.Add(ocampoEnt);
                            }
                        }
                        #endregion
                    }
                }
                return lsCEntidad;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // COMBO EXITU
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <returns></returns>
        public CEntidad RegMostComboExsitu(OracleConnection cn, CEntidad oCEntidad)
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
                        List<CEntISExsitu> lsDetExsitu;
                        CEntidad oCamposDet;
                        CEntISExsitu oCamposComboExsitu;
                        //Documento Identidad
                        lsDetDetalle = new List<CEntidad>();
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("CODIGO");
                            int pt2 = dr.GetOrdinal("DESCRIPCION");
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.CODIGO = dr.GetString(pt1);
                                oCamposDet.DESCRIPCION = dr.GetString(pt2);
                                lsDetDetalle.Add(oCamposDet);
                            }
                        }
                        oCampos.ListMComboDIdentidad = lsDetDetalle;

                        //Supervision Concepto
                        dr.NextResult();
                        lsDetDetalle = new List<CEntidad>();
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("CODIGO");
                            int pt2 = dr.GetOrdinal("DESCRIPCION");
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.CODIGO = dr.GetString(pt1);
                                oCamposDet.DESCRIPCION = dr.GetString(pt2);
                                lsDetDetalle.Add(oCamposDet);
                            }
                        }
                        oCampos.ListPersEspecialidad = lsDetDetalle;
                        //NIVEL ACADEMICO
                        dr.NextResult();
                        lsDetDetalle = new List<CEntidad>();
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("CODIGO");
                            int pt2 = dr.GetOrdinal("DESCRIPCION");
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.CODIGO = dr.GetString(pt1);
                                oCamposDet.DESCRIPCION = dr.GetString(pt2);
                                lsDetDetalle.Add(oCamposDet);
                            }
                        }
                        oCampos.ListNivelAcademico = lsDetDetalle;
                        //Supervision Motivo
                        dr.NextResult();
                        lsDetExsitu = new List<CEntISExsitu>();
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("COD_TDESCRIPTIVA");
                            int pt2 = dr.GetOrdinal("DESCRIPCION");
                            int pt3 = dr.GetOrdinal("TIPO");
                            while (dr.Read())
                            {
                                oCamposComboExsitu = new CEntISExsitu();
                                oCamposComboExsitu.COD_TDESCRIPTIVA = dr.GetString(pt1);
                                oCamposComboExsitu.DESCRIPCION = dr.GetString(pt2);
                                oCamposComboExsitu.TIPO = dr.GetString(pt3);
                                lsDetExsitu.Add(oCamposComboExsitu);
                            }
                        }
                        oCampos.ListComboISEXSITU = lsDetExsitu;
                        //ESTADO ORIGEN
                        dr.NextResult();
                        lsDetDetalle = new List<CEntidad>();
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("CODIGO");
                            int pt2 = dr.GetOrdinal("DESCRIPCION");
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.CODIGO = dr.GetString(pt1);
                                oCamposDet.DESCRIPCION = dr.GetString(pt2);
                                lsDetDetalle.Add(oCamposDet);
                            }
                        }
                        oCampos.ListEspecies_Origen = lsDetDetalle;
                        // ESPECIES
                        dr.NextResult();
                        lsDetDetalle = new List<CEntidad>();
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("CODIGO");
                            int pt2 = dr.GetOrdinal("DESCRIPCION");
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.CODIGO = dr.GetString(pt1);
                                oCamposDet.DESCRIPCION = dr.GetString(pt2);
                                lsDetDetalle.Add(oCamposDet);
                            }
                        }
                        oCampos.ListEspeciesDetDatos = lsDetDetalle;
                        //grado de amenaza
                        //dr.NextResult();
                        //lsDetDetalle = new List<CEntidad>();
                        //if (dr.HasRows)
                        //{
                        //	int pt1 = dr.GetOrdinal("CODIGO");
                        //	int pt2 = dr.GetOrdinal("DESCRIPCION");
                        //	while (dr.Read())
                        //	{
                        //		oCamposDet = new CEntidad();
                        //		oCamposDet.CODIGO = dr.GetString(pt1);
                        //		oCamposDet.DESCRIPCION = dr.GetString(pt2);
                        //		lsDetDetalle.Add(oCamposDet);
                        //	}
                        //}
                        //oCampos.ListISupervisionGradoCateg = lsDetDetalle;
                        // SEXO ANIMAL
                        dr.NextResult();
                        lsDetDetalle = new List<CEntidad>();
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("CODIGO");
                            int pt2 = dr.GetOrdinal("DESCRIPCION");
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.CODIGO = dr.GetString(pt1);
                                oCamposDet.DESCRIPCION = dr.GetString(pt2);
                                lsDetDetalle.Add(oCamposDet);
                            }
                        }
                        oCampos.ListISupvervisionSexo = lsDetDetalle;
                        //Oficinas Desconcentradas
                        dr.NextResult();
                        lsDetDetalle = new List<CEntidad>();
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("CODIGO");
                            int pt2 = dr.GetOrdinal("DESCRIPCION");
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.CODIGO = dr.GetString(pt1);
                                oCamposDet.DESCRIPCION = dr.GetString(pt2);
                                lsDetDetalle.Add(oCamposDet);
                            }
                        }
                        oCampos.ListODs = lsDetDetalle;
                        //estado de cuenta
                        dr.NextResult();
                        lsDetDetalle = new List<CEntidad>();
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("CODIGO");
                            int pt2 = dr.GetOrdinal("DESCRIPCION");
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.CODIGO = dr.GetString(pt1);
                                oCamposDet.DESCRIPCION = dr.GetString(pt2);
                                lsDetDetalle.Add(oCamposDet);
                            }
                        }
                        oCampos.ListIndicador = lsDetDetalle;
                        dr.NextResult();
                        // modalidad de egreso
                        lsDetDetalle = new List<CEntidad>();
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("CODIGO");
                            int pt2 = dr.GetOrdinal("DESCRIPCION");
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.CODIGO = dr.GetString(pt1);
                                oCamposDet.DESCRIPCION = dr.GetString(pt2);
                                lsDetDetalle.Add(oCamposDet);
                            }
                        }
                        oCampos.ListModEgreso = lsDetDetalle;
                        dr.NextResult();
                        lsDetDetalle = new List<CEntidad>();
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("CODIGO");
                            int pt2 = dr.GetOrdinal("DESCRIPCION");
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.CODIGO = dr.GetString(pt1);
                                oCamposDet.DESCRIPCION = dr.GetString(pt2);
                                lsDetDetalle.Add(oCamposDet);
                            }
                        }
                        oCampos.ListISupervision_Motivo = lsDetDetalle;

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
        public String RegInsertar_ExSitu(OracleConnection cn, CEntidad oCEntidad)
        {
            OracleTransaction tr = null;
            String OUTPUTPARAM01 = "";
            String OUTPUTPARAM02 = "";
            Int32 COD_SECUENCIAL = -1;
            CEntISExsitu oCampoExsitu;
            CEntISExsitu oCampoExsituDet;
            CEntidad ocampoSuper;
            CEntPersona ocampoPersona;
            try
            {
                tr = cn.BeginTransaction();
                //Grabando Cabecera
                using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.INFORME_Grabar_ExSitu", oCEntidad))
                {
                    cmd.ExecuteNonQuery();
                    OUTPUTPARAM01 = (String)cmd.Parameters["OUTPUTPARAM01"].Value;
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
                        throw new Exception("El Número de Informe ya Existe");
                    }
                    else if (OUTPUTPARAM01 == "1")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("El Número del Titulo Habilitante Existe en otro Registro");
                    }
                    else if (OUTPUTPARAM01 == "2")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("No Tiene Permisos para Modificar este Informe");
                    }
                    else if (OUTPUTPARAM01 == "3")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("Está con Control de Calidad, no puede modificar");
                    }
                }
                //
                //Eliminando Detalle Informe
                if (oCEntidad.ListEliTABLA != null)
                {
                    foreach (var loDatos in oCEntidad.ListEliTABLA)
                    {
                        ocampoSuper = new CEntidad();
                        ocampoSuper.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                        ocampoSuper.EliTABLA = loDatos.EliTABLA;
                        ocampoSuper.COD_PERSONA = loDatos.COD_PERSONA;
                        ocampoSuper.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                        ocampoSuper.COD_ESPECIES = loDatos.COD_ESPECIES;
                        ocampoSuper.COD_INFORME_FOTOS = loDatos.COD_INFORME_FOTOS;
                        ocampoSuper.EliVALOR01 = loDatos.EliVALOR01;
                        dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spINFORME_ISUPERVISION_EXSITU_Eliminar", ocampoSuper);
                    }
                }
                //
                if (oCEntidad.ListInformeDetSupervisor != null)
                {
                    foreach (var loDatos in oCEntidad.ListInformeDetSupervisor)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            ocampoPersona = new CEntPersona();
                            ocampoPersona.COD_PERSONA = loDatos.COD_PERSONA;
                            ocampoPersona.CODIGO = OUTPUTPARAM01.Split('|')[0];
                            ocampoPersona.COD_DIDENTIDAD = loDatos.COD_DIDENTIDAD;
                            ocampoPersona.APE_PATERNO = loDatos.APE_PATERNO;
                            ocampoPersona.APE_MATERNO = loDatos.APE_MATERNO;
                            ocampoPersona.NOMBRES = loDatos.NOMBRES;
                            ocampoPersona.N_DOCUMENTO = loDatos.N_DOCUMENTO;
                            ocampoPersona.N_RUC = loDatos.N_RUC;
                            ocampoPersona.COD_PTIPO = loDatos.COD_PTIPO;
                            ocampoPersona.COLEGIATURA_NUM = loDatos.COLEGIATURA_NUM;
                            ocampoPersona.COD_DPESPECIALIDAD = loDatos.COD_DPESPECIALIDAD;
                            ocampoPersona.COD_NACADEMICO = loDatos.COD_NACADEMICO;
                            ocampoPersona.CARGO = loDatos.CARGO;
                            ocampoPersona.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.INFORME_DET_SUPERVISOR_GrabarV3", ocampoPersona);
                        }
                    }
                }
                // INFORME MADERABLE
                if (oCEntidad.ListAreaExsitu != null)
                {
                    foreach (var loDatos in oCEntidad.ListAreaExsitu)
                    {
                        if ((loDatos.RegEstado == 1 || loDatos.RegEstado == 2) && loDatos.COD_SECUENCIAL != 999) //Nuevo o Modificado
                        {
                            oCampoExsitu = new CEntISExsitu();
                            oCampoExsitu.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            oCampoExsitu.COD_AREA = loDatos.COD_AREA;
                            oCampoExsitu.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            oCampoExsitu.NUMERO = loDatos.NUMERO ?? "";
                            oCampoExsitu.LARGO = loDatos.LARGO;
                            oCampoExsitu.ANCHO = loDatos.ANCHO;
                            oCampoExsitu.ALTURA = loDatos.ALTURA;
                            oCampoExsitu.AREA = loDatos.AREA;
                            oCampoExsitu.RegEstado = loDatos.RegEstado;
                            oCampoExsitu.OUTPUTPARAM01 = "";
                            using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.ISUPERVISION_EXSITU_INFRA_AREA_RECINTO_Grabar", oCampoExsitu))
                            {
                                cmd.ExecuteNonQuery();
                                COD_SECUENCIAL = Int32.Parse((String)cmd.Parameters["OUTPUTPARAM01"].Value);
                                if (OUTPUTPARAM02 == "0")
                                {
                                    throw new Exception("El Registro ya Existe");
                                }
                            }
                            if (loDatos.ListISupervision_exsitu_recinto_equipo != null)
                            {
                                foreach (var loDatosDet in loDatos.ListISupervision_exsitu_recinto_equipo)
                                {
                                    if (loDatosDet.RegEstado == 1 || loDatosDet.RegEstado == 2) //Nuevo o Modificado
                                    {
                                        oCampoExsituDet = new CEntISExsitu();
                                        oCampoExsituDet.COD_TDESCRIPTIVA = loDatosDet.COD_TDESCRIPTIVA;
                                        oCampoExsituDet.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                                        oCampoExsituDet.COD_AREA = loDatos.COD_AREA;
                                        oCampoExsituDet.DESCRIPCION = loDatosDet.DESCRIPCION;
                                        oCampoExsituDet.TIPO = loDatosDet.TIPO;
                                        oCampoExsituDet.COD_SECUENCIAL = COD_SECUENCIAL;
                                        dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.ISUPERVISION_EXSITU_INFRA_AREA_RECINTO_DET_EQUIPOS_Grabar", oCampoExsituDet);
                                    }
                                }
                            }
                        }
                    }
                }
                // ISUPEVISION EXSITU CAUTI PALIMENTACION
                if (oCEntidad.ListGrupoToxonomico != null)
                {

                    foreach (var loDatos in oCEntidad.ListGrupoToxonomico)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            oCampoExsitu = new CEntISExsitu();
                            oCampoExsitu.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            oCampoExsitu.COD_TDESCRIPTIVA = loDatos.COD_TDESCRIPTIVA;
                            oCampoExsitu.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            oCampoExsitu.TIPO_ALIMENTACION = loDatos.TIPO_ALIMENTACION;
                            oCampoExsitu.FRECUENCIA_RACION = loDatos.FRECUENCIA_RACION;
                            oCampoExsitu.GRUPOESPECIE = loDatos.GRUPOESPECIE;
                            oCampoExsitu.OBSERVACION = loDatos.OBSERVACION;
                            oCampoExsitu.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.ISUPERVISION_EXSITU_CAUTI_PALIMENTACION_Grabar", oCampoExsitu);
                        }
                    }
                }
                //CONTENCION FISICO
                if (oCEntidad.ListProgManejoSanitarioFisico != null)
                {

                    foreach (var loDatos in oCEntidad.ListProgManejoSanitarioFisico)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            oCampoExsitu = new CEntISExsitu();
                            oCampoExsitu.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            oCampoExsitu.COD_TDESCRIPTIVA = loDatos.COD_TDESCRIPTIVA;
                            oCampoExsitu.OBSERVACION = loDatos.OBSERVACION;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.ISUPERVISION_EXSITU_CAUTI_PCONTENCION_MFISICO_Grabar", oCampoExsitu);
                        }
                    }
                }
                //CONTENCION QUIMICA
                if (oCEntidad.ListProgManejoSanitarioQuimico != null)
                {

                    foreach (var loDatos in oCEntidad.ListProgManejoSanitarioQuimico)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            oCampoExsitu = new CEntISExsitu();
                            oCampoExsitu.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            oCampoExsitu.COD_TDESCRIPTIVA = loDatos.COD_TDESCRIPTIVA;
                            oCampoExsitu.OBSERVACION = loDatos.OBSERVACION;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.ISUPERVISION_EXSITU_CAUTI_PCONTENCION_QUIMICO_Grabar", oCampoExsitu);
                        }
                    }
                }
                //MLIMPIEZA
                if (oCEntidad.ListProgBioFrecuenciaLimpieza != null)
                {

                    foreach (var loDatos in oCEntidad.ListProgBioFrecuenciaLimpieza)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            oCampoExsitu = new CEntISExsitu();
                            oCampoExsitu.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            oCampoExsitu.COD_TDESCRIPTIVA = loDatos.COD_TDESCRIPTIVA;
                            oCampoExsitu.OBSERVACION = loDatos.OBSERVACION;
                            oCampoExsitu.RegEstado = loDatos.RegEstado;
                            oCampoExsitu.ESTADO = loDatos.ESTADO;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.ISUPERVISION_EXSITU_CAUTI_PBIO_DET_MLIMPIEZA_Grabar", oCampoExsitu);
                        }
                    }
                }
                //M_DESINFECCION
                if (oCEntidad.ListMaterialDesinfeccion != null)
                {

                    foreach (var loDatos in oCEntidad.ListMaterialDesinfeccion)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            oCampoExsitu = new CEntISExsitu();
                            oCampoExsitu.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            oCampoExsitu.COD_TDESCRIPTIVA = loDatos.COD_TDESCRIPTIVA;
                            oCampoExsitu.OBSERVACION = loDatos.OBSERVACION;
                            oCampoExsitu.RegEstado = loDatos.RegEstado;
                            oCampoExsitu.ESTADO = loDatos.ESTADO;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.ISUPERVISION_EXSITU_CAUTI_PBIO_DET_MDESINFECCION_Grabar", oCampoExsitu);
                        }
                    }
                }
                //
                if (oCEntidad.ListEquipoDesinfeccion != null)
                {

                    foreach (var loDatos in oCEntidad.ListEquipoDesinfeccion)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            oCampoExsitu = new CEntISExsitu();
                            oCampoExsitu.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            oCampoExsitu.COD_TDESCRIPTIVA = loDatos.COD_TDESCRIPTIVA;
                            oCampoExsitu.OBSERVACION = loDatos.OBSERVACION;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.ISUPERVISION_EXSITU_CAUTI_PBIO_DET_EDESINFECCION_Grabar", oCampoExsitu);
                        }
                    }
                }
                //
                if (oCEntidad.ListCautiverioControlPlaga != null)
                {

                    foreach (var loDatos in oCEntidad.ListCautiverioControlPlaga)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            oCampoExsitu = new CEntISExsitu();
                            oCampoExsitu.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            oCampoExsitu.COD_TDESCRIPTIVA = loDatos.COD_TDESCRIPTIVA;
                            oCampoExsitu.FRECUENCIA = loDatos.FRECUENCIA;
                            oCampoExsitu.METODO_FISICO = loDatos.METODO_FISICO;
                            oCampoExsitu.METODO_QUIMICO = loDatos.METODO_QUIMICO;
                            oCampoExsitu.OBSERVACION = loDatos.OBSERVACION;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.ISUPERVISION_EXSITU_CAUTI_PBIO_DET_CPLAGAS_Grabar", oCampoExsitu);
                        }
                    }
                }
                //ISUPERVISION_EXSITU_CAUTI_MREGISTRO
                if (oCEntidad.LisCautiveriotManejoRegistro != null)
                {

                    foreach (var loDatos in oCEntidad.LisCautiveriotManejoRegistro)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            oCampoExsitu = new CEntISExsitu();
                            oCampoExsitu.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            oCampoExsitu.COD_TDESCRIPTIVA = loDatos.COD_TDESCRIPTIVA;
                            oCampoExsitu.FECHA_ACTUALIZACION = loDatos.FECHA_ACTUALIZACION;
                            oCampoExsitu.OBSERVACION = loDatos.OBSERVACION;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.ISUPERVISION_EXSITU_CAUTI_MREGISTRO_Grabar", oCampoExsitu);
                        }
                    }
                }
                if (oCEntidad.LisCautiverioEnriquecAmbiental != null)
                {

                    foreach (var loDatos in oCEntidad.LisCautiverioEnriquecAmbiental)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            oCampoExsitu = new CEntISExsitu();
                            oCampoExsitu.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            oCampoExsitu.COD_TDESCRIPTIVA = loDatos.COD_TDESCRIPTIVA;
                            oCampoExsitu.ACTIVIDAD_IMPLEMENTADA = loDatos.ACTIVIDAD_IMPLEMENTADA;
                            oCampoExsitu.MATERIAL_USADO = loDatos.MATERIAL_USADO;
                            oCampoExsitu.OBSERVACION = loDatos.OBSERVACION;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.ISUPERVISION_EXSITU_CAUTI_PEAMBIENTAL_Grabar", oCampoExsitu);
                        }
                    }
                }
                if (oCEntidad.LisCautiverioEspecieReproducida != null)
                {

                    foreach (var loDatos in oCEntidad.LisCautiverioEspecieReproducida)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            oCampoExsitu = new CEntISExsitu();
                            oCampoExsitu.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            oCampoExsitu.COD_ESPECIES = loDatos.COD_ESPECIES;
                            oCampoExsitu.COD_EORIGEN = loDatos.COD_EORIGEN;
                            oCampoExsitu.NUM_CRIAS_ANO = loDatos.NUM_CRIAS_ANO;
                            oCampoExsitu.NUM_CRIAS_VIABLES = loDatos.NUM_CRIAS_VIABLES;
                            oCampoExsitu.NUM_CRIAS_MUERTAS = loDatos.NUM_CRIAS_MUERTAS;
                            oCampoExsitu.FRECUENCIA_COD_TDESCRIPTIVA = loDatos.FRECUENCIA_COD_TDESCRIPTIVA;
                            oCampoExsitu.REPRODUCCION_EPOCA = loDatos.REPRODUCCION_EPOCA;
                            oCampoExsitu.OBSERVACION = loDatos.OBSERVACION;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.ISUPERVISION_EXSITU_CAUTI_PMGENETICO_Grabar", oCampoExsitu);
                        }
                    }
                }
                if (oCEntidad.LisCautiverioActividadRealizada != null)
                {
                    foreach (var loDatos in oCEntidad.LisCautiverioActividadRealizada)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            oCampoExsitu = new CEntISExsitu();
                            oCampoExsitu.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            oCampoExsitu.COD_TDESCRIPTIVA = loDatos.COD_TDESCRIPTIVA;
                            oCampoExsitu.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            oCampoExsitu.OBSERVACION = loDatos.OBSERVACION;
                            //oCampoExsitu.FECHA_PUBLICACION = loDatos.FECHA_PUBLICACION;
                            oCampoExsitu.FECHA_EVENTO = loDatos.FECHA_EVENTO;
                            oCampoExsitu.RegEstado = loDatos.RegEstado;
                            oCampoExsitu.OUTPUTPARAM01 = "";
                            using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.ISUPERVISION_EXSITU_CAUTI_PEAMBI_ACTIVIDAD_Grabar", oCampoExsitu))
                            {
                                cmd.ExecuteNonQuery();
                                COD_SECUENCIAL = Int32.Parse((String)cmd.Parameters["OUTPUTPARAM01"].Value);
                                if (COD_SECUENCIAL == 0)
                                {
                                    throw new Exception("El Registro ya Existe");
                                }

                                if (loDatos.ListISupervision_exsitu_recinto_equipo != null)
                                {
                                    foreach (var loDatosDet in loDatos.ListISupervision_exsitu_recinto_equipo)
                                    {
                                        if (loDatosDet.RegEstado == 1 || loDatosDet.RegEstado == 2) //Nuevo o Modificado
                                        {
                                            oCampoExsituDet = new CEntISExsitu();
                                            oCampoExsituDet.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                                            oCampoExsituDet.COD_TDESCRIPTIVA = loDatos.COD_TDESCRIPTIVA;
                                            oCampoExsituDet.COD_SECUENCIAL = COD_SECUENCIAL;
                                            oCampoExsituDet.POBJETIVO_COD_TDESCRIPTIVA = loDatosDet.POBJETIVO_COD_TDESCRIPTIVA;
                                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.ISUPERVISION_EXSITU_CAUTI_PEAMBI_POBJETIVO_Grabar", oCampoExsituDet);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                if (oCEntidad.LisCautiverioCensoICientifica != null)
                {
                    foreach (var loDatos in oCEntidad.LisCautiverioCensoICientifica)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            oCampoExsitu = new CEntISExsitu();
                            oCampoExsitu.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            oCampoExsitu.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            oCampoExsitu.PUBLICADO = loDatos.PUBLICADO;
                            oCampoExsitu.FECHA_PUBLICACION = loDatos.FECHA_PUBLICACION;
                            oCampoExsitu.INVESTIGACION_REALIZADA = loDatos.INVESTIGACION_REALIZADA;
                            oCampoExsitu.OBJETIVO = loDatos.OBJETIVO;
                            oCampoExsitu.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.ISUPERVISION_EXSITU_CAUTI_ICIENTIFICA_Grabar", oCampoExsitu);
                        }
                    }
                }
                if (oCEntidad.LisCautiverioECapturado != null)
                {
                    foreach (var loDatos in oCEntidad.LisCautiverioECapturado)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            oCampoExsitu = new CEntISExsitu();
                            oCampoExsitu.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            oCampoExsitu.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            oCampoExsitu.COD_ESPECIES = loDatos.COD_ESPECIES;
                            oCampoExsitu.NUM_ICAPTURADOS = loDatos.NUM_ICAPTURADOS;
                            oCampoExsitu.ZONA_CAPTURA = loDatos.ZONA_CAPTURA;
                            oCampoExsitu.OBSERVACION = loDatos.OBSERVACION;
                            oCampoExsitu.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.ISUPERVISION_EXSITU_CAUTI_PCOLECTA_Grabar", oCampoExsitu);
                        }
                    }
                }

                if (oCEntidad.LisCapacitacionFauna != null)
                {
                    foreach (var loDatos in oCEntidad.LisCapacitacionFauna)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            oCampoExsitu = new CEntISExsitu();
                            oCampoExsitu.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            oCampoExsitu.COD_EXSITUCAPACITACION = loDatos.COD_EXSITUCAPACITACION;
                            oCampoExsitu.TEMA = loDatos.TEMA;
                            oCampoExsitu.NUM_BENEFICIADOS = loDatos.NUM_BENEFICIADOS;
                            oCampoExsitu.CAPACITADOR = loDatos.CAPACITADOR;
                            oCampoExsitu.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.ISUPERVISION_EXSITU_CAUTI_CAPACITACION_Grabar", oCampoExsitu);
                        }
                    }
                }
                if (oCEntidad.LisCautiverioCensoVertebrado != null)
                {

                    foreach (var loDatos in oCEntidad.LisCautiverioCensoVertebrado)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            oCampoExsitu = new CEntISExsitu();
                            oCampoExsitu.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            oCampoExsitu.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            oCampoExsitu.COD_ESPECIES = loDatos.COD_ESPECIES;
                            oCampoExsitu.DESCRIPCION = loDatos.DESCRIPCION;
                            oCampoExsitu.TIPO_VERTEBRADO = loDatos.TIPO_VERTEBRADO;
                            oCampoExsitu.PROCEDENCIA_COD_TDESCRIPTIVA = loDatos.PROCEDENCIA_COD_TDESCRIPTIVA;
                            oCampoExsitu.DESC_PROCEDENCIA = loDatos.DESC_PROCEDENCIA;
                            oCampoExsitu.PROCEDENCIA_NUM_INDIVIDUOS = loDatos.PROCEDENCIA_NUM_INDIVIDUOS;
                            oCampoExsitu.TIDENTI_COD_TDESCRIPTIVA = loDatos.TIDENTI_COD_TDESCRIPTIVA;
                            oCampoExsitu.DESC_TIDENTIFICACION = loDatos.DESC_TIDENTIFICACION;
                            oCampoExsitu.CODIGO_NOMBRE = loDatos.CODIGO_NOMBRE;
                            oCampoExsitu.COD_SEXO = loDatos.COD_SEXO;
                            oCampoExsitu.SEXO = loDatos.SEXO;
                            oCampoExsitu.COD_ACATEGORIA = loDatos.COD_ACATEGORIA;
                            oCampoExsitu.DESC_ACATEGORIA = loDatos.DESC_ACATEGORIA;
                            oCampoExsitu.OBSERVACION = loDatos.OBSERVACION;
                            oCampoExsitu.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.ISUPERVISION_EXSITU_CAUTI_CENSO_Grabar", oCampoExsitu);
                        }
                    }
                }
                if (oCEntidad.ListFotos != null)
                {
                    foreach (var loDatos in oCEntidad.ListFotos)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            CEntidad ocampo = new CEntidad();
                            ocampo.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            ocampo.COD_INFORME_FOTOS = "";
                            ocampo.COD_THABILITANTE = loDatos.COD_THABILITANTE;
                            ocampo.COD_UCUENTA = loDatos.COD_UCUENTA;
                            ocampo.URL_FOTO = loDatos.URL_FOTO;
                            ocampo.FUENTE_FOTO = loDatos.FUENTE_FOTO;
                            ocampo.DISP_FOTO = loDatos.DISP_FOTO;
                            ocampo.DESC_FOTO = loDatos.DESC_FOTO;
                            ocampo.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spINFORME_FOTOSGrabar", ocampo);
                        }
                    }
                }
                if (oCEntidad.ListNacimientosEspecies != null)
                {

                    foreach (var loDatos in oCEntidad.ListNacimientosEspecies)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            oCampoExsitu = new CEntISExsitu();
                            oCampoExsitu.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            oCampoExsitu.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            oCampoExsitu.COD_ESPECIES = loDatos.COD_ESPECIES;
                            oCampoExsitu.NOMBRE_COMUN = loDatos.NOMBRE_COMUN;
                            oCampoExsitu.COD_SEXO = loDatos.COD_SEXO;
                            oCampoExsitu.SEXO = loDatos.SEXO;
                            oCampoExsitu.NUMERO = loDatos.NUMERO;
                            oCampoExsitu.DESCRIPCION = loDatos.DESCRIPCION;
                            oCampoExsitu.OBJETIVO = loDatos.OBJETIVO;
                            oCampoExsitu.OBSERVACION = loDatos.OBSERVACION;
                            oCampoExsitu.FECHA_PUBLICACION = loDatos.FECHA_PUBLICACION;
                            oCampoExsitu.SEXO = loDatos.SEXO;
                            oCampoExsitu.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.ISUPERVISION_EXSITU_CAUTI_NACIMIENTO_Grabar", oCampoExsitu);
                        }
                    }
                }
                if (oCEntidad.ListEgresosEspecies != null)
                {

                    foreach (var loDatos in oCEntidad.ListEgresosEspecies)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            oCampoExsitu = new CEntISExsitu();
                            oCampoExsitu.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            oCampoExsitu.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            oCampoExsitu.COD_ESPECIES = loDatos.COD_ESPECIES;
                            oCampoExsitu.NOMBRE_COMUN = loDatos.NOMBRE_COMUN;
                            oCampoExsitu.FECHA_PUBLICACION = loDatos.FECHA_PUBLICACION;
                            oCampoExsitu.COD_SEXO = loDatos.COD_SEXO;
                            oCampoExsitu.SEXO = loDatos.SEXO;
                            oCampoExsitu.DOCUMENTO = loDatos.DOCUMENTO;
                            oCampoExsitu.NUMERO = loDatos.NUMERO;
                            oCampoExsitu.COD_MOTIVO = loDatos.COD_MOTIVO;
                            oCampoExsitu.MOTIVO = loDatos.MOTIVO;
                            oCampoExsitu.NECROPSIA = loDatos.NECROPSIA;
                            oCampoExsitu.DIAGNOSTICO = loDatos.DIAGNOSTICO;
                            oCampoExsitu.EDAD = loDatos.EDAD;
                            oCampoExsitu.OBSERVACION = loDatos.OBSERVACION;
                            oCampoExsitu.SEXO = loDatos.SEXO;
                            oCampoExsitu.CODIGO_NOMBRE = loDatos.CODIGO_NOMBRE;
                            oCampoExsitu.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.ISUPERVISION_EXSITU_CAUTI_EGRESO_Grabar", oCampoExsitu);
                        }
                    }
                }

                //BALANCE
                if (oCEntidad.ListISuperExsituBalance != null)
                {
                    foreach (var loDatos in oCEntidad.ListISuperExsituBalance)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            oCampoExsitu = new CEntISExsitu();
                            oCampoExsitu.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            oCampoExsitu.COD_BALANCE = loDatos.COD_BALANCE;
                            oCampoExsitu.COD_ESPECIES = loDatos.COD_ESPECIES;
                            oCampoExsitu.CENSO_INICIAL = loDatos.CENSO_INICIAL;
                            oCampoExsitu.CANT_INGRESO = loDatos.CANT_INGRESO;
                            oCampoExsitu.FECHA_INGRESO = loDatos.FECHA_INGRESO;
                            oCampoExsitu.DOCUMENTO_INGRESO = loDatos.DOCUMENTO_INGRESO;
                            oCampoExsitu.MOTIVO_INGRESO = loDatos.MOTIVO_INGRESO;
                            oCampoExsitu.OBSERV_INGRESO = loDatos.OBSERV_INGRESO;
                            oCampoExsitu.CANT_EGRESO = loDatos.CANT_EGRESO;
                            oCampoExsitu.FECHA_EGRESO = loDatos.FECHA_EGRESO;
                            oCampoExsitu.DOCUMENTO_EGRESO = loDatos.DOCUMENTO_EGRESO;
                            oCampoExsitu.MOTIVO_EGRESO = loDatos.MOTIVO_EGRESO;
                            oCampoExsitu.OBSERV_EGRESO = loDatos.OBSERV_EGRESO;
                            oCampoExsitu.BALANCE_PREVIO = loDatos.BALANCE_PREVIO;
                            oCampoExsitu.CENSO_FINAL = loDatos.CENSO_FINAL;
                            oCampoExsitu.NOMBRE_COMUN = loDatos.NOMBRE_COMUN;
                            oCampoExsitu.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.ISUPERVISION_EXSITU_CAUTI_BALANCE_Grabar", oCampoExsitu);
                        }
                    }
                }

                //OBLIGACIONES
                if (oCEntidad.ListISuperExsituOBLIGF != null)
                {

                    foreach (var loDatos in oCEntidad.ListISuperExsituOBLIGF)
                    {
                        oCampoExsitu = new CEntISExsitu();

                        oCampoExsitu.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                        oCampoExsitu.MAE_OBLIGTITULAR = loDatos.MAE_OBLIGTITULAR;
                        oCampoExsitu.EVAL_OBLIGTITULAR = loDatos.EVAL_OBLIGTITULAR;
                        oCampoExsitu.OBSERVACION = loDatos.OBSERVACION_OBLIG;
                        oCampoExsitu.COD_UCUENTA = oCEntidad.COD_UCUENTA;
                        oCampoExsitu.RegEstado = loDatos.RegEstado;
                        dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spISUPERVISION_OBLIG_TITULAR_FAUNAGrabar", oCampoExsitu);
                    }
                }

                //Registro de DESPLAZAMIENTO
                if (oCEntidad.ListDesplazamientoInforme != null)
                {
                    foreach (var loDatos in oCEntidad.ListDesplazamientoInforme)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            CEntidad ocampo = new CEntidad();
                            ocampo.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            if (loDatos.COD_DESPLAZAMIENTO == null)
                            {
                                ocampo.COD_DESPLAZAMIENTO = "";
                            }
                            else
                            {
                                ocampo.COD_DESPLAZAMIENTO = loDatos.COD_DESPLAZAMIENTO;
                            }
                            ocampo.ZONA = loDatos.ZONA ?? "";
                            ocampo.PTOI_COORDENADA_ESTE = loDatos.COORDENADA_ESTE;
                            ocampo.PTOI_COORDENADA_NORTE = loDatos.COORDENADA_NORTE;
                            ocampo.ZONA_CAMPO = loDatos.ZONA_CAMPO ?? "";
                            ocampo.PTOF_COORDENADA_ESTE = loDatos.COORDENADA_ESTE_CAMPO;
                            ocampo.PTOF_COORDENADA_NORTE = loDatos.COORDENADA_NORTE_CAMPO;
                            ocampo.OBSERVACION = loDatos.OBSERVACION;
                            ocampo.TIPO = loDatos.TipoVia;
                            ocampo.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spINFORME_DESPLAZAMIENTOGrabar", ocampo);
                        }
                    }
                }
                //Registro de Personal Técnico Profesionl
                if (oCEntidad.ListPersonalTecProf != null)
                {
                    foreach (var loDatos in oCEntidad.ListPersonalTecProf)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            CEntPersona ocampo = new CEntPersona();
                            ocampo.CODIGO = OUTPUTPARAM01.Split('|')[0];
                            if (loDatos.COD_PERSONALTECPROF == null)
                            {
                                ocampo.COD_PERSONALTECPROF = "";
                            }
                            else
                            {
                                ocampo.COD_PERSONALTECPROF = loDatos.COD_PERSONALTECPROF;
                            }
                            ocampo.NOMBRES = loDatos.NOMBRES ?? "";
                            ocampo.TIPO = loDatos.TIPO;
                            ocampo.OTRO = loDatos.OTRO;
                            ocampo.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spINFORME_PersonalTecProfGrabar", ocampo);
                        }
                    }
                }
                //Relacion de Personal Centro Cría
                if (oCEntidad.ListRelPelCentroCria != null)
                {
                    foreach (var loDatos in oCEntidad.ListRelPelCentroCria)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            CEntPersona ocampo = new CEntPersona();
                            ocampo.CODIGO = OUTPUTPARAM01.Split('|')[0];
                            if (loDatos.COD_RELPELCENTROCRIA == null)
                            {
                                ocampo.COD_RELPELCENTROCRIA = "";
                            }
                            else
                            {
                                ocampo.COD_RELPELCENTROCRIA = loDatos.COD_RELPELCENTROCRIA;
                            }
                            ocampo.NOMBRES = loDatos.NOMBRES ?? "";
                            ocampo.CARGO = loDatos.CARGO;
                            ocampo.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spINFORME_RelPelCentroCGrabar", ocampo);
                        }
                    }
                }
                if (oCEntidad.ListEvalZoObservatorio != null)
                {
                    foreach (var loDatos in oCEntidad.ListEvalZoObservatorio)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            CapaEntidad.DOC.Ent_ISUPERVISION_EXSITU_CAUTI_EVALZOO ocampo = new CapaEntidad.DOC.Ent_ISUPERVISION_EXSITU_CAUTI_EVALZOO();
                            ocampo.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            ocampo.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            ocampo.MAE_CRITERIO_EVALZOO = loDatos.MAE_CRITERIO_EVALZOO;
                            ocampo.CALIFICACION = loDatos.CALIFICACION;
                            ocampo.OBSERVACION = loDatos.OBSERVACION;
                            ocampo.COD_UCUENTA = oCEntidad.COD_UCUENTA;
                            ocampo.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spISUPERVISION_EXSITU_CAUTI_EVALZOOGrabar", ocampo);
                        }
                    }
                }

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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public String TEMP_CAMBIAR_CENSO(OracleConnection cn, CEntidad oCEntidad)
        {
            String OUTPUTPARAM01 = "";
            try
            {
                //Grabando Cabecera
                using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, null, "dbo.TEMP_CAMBIAR_ESPECIE_CENSO", oCEntidad))
                {
                    cmd.ExecuteNonQuery();
                    OUTPUTPARAM01 = (String)cmd.Parameters["OUTPUTPARAM01"].Value;
                    if (OUTPUTPARAM01 == "0")
                    {
                        throw new Exception("Número de registro actualizado (0)");
                    }
                }
                return OUTPUTPARAM01;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string RegCargaMaderableWS(OracleConnection cn, CEntidad oCEntidad)
        {
            String OUTPUTPARAM = "";
            OracleTransaction tr = null;
            try
            {
                tr = cn.BeginTransaction();
                if (oCEntidad != null)
                {
                    using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.ISUPERVISION_DET_EMADERABLE_WSCarga", oCEntidad))
                    {
                        cmd.ExecuteNonQuery();
                        OUTPUTPARAM = (String)cmd.Parameters["OUTPUTPARAM"].Value;
                    }
                }
                tr.Commit();
                return OUTPUTPARAM;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string RegCargaNoMaderableWS(OracleConnection cn, CEntidad oCEntidad)
        {
            String OUTPUTPARAM = "";
            OracleTransaction tr = null;
            try
            {
                tr = cn.BeginTransaction();
                if (oCEntidad != null)
                {
                    using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.ISUPERVISION_DET_NOMADERABLE_WSCarga", oCEntidad))
                    {
                        cmd.ExecuteNonQuery();
                        OUTPUTPARAM = (String)cmd.Parameters["OUTPUTPARAM"].Value;
                    }
                }
                tr.Commit();
                return OUTPUTPARAM;
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
        public void RegModificarFormato(OracleConnection cn, CEntidad oCEntidad)
        {
            OracleTransaction tr = null;
            try
            {
                tr = cn.BeginTransaction();
                if (oCEntidad.ListINFORMEItemsDetalle != null)
                {
                    CEntidad ocampoSuper;

                    foreach (var loDatos in oCEntidad.ListINFORMEItemsDetalle)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 0) //Nuevo o Modificado
                        {
                            ocampoSuper = new CEntidad();
                            ocampoSuper.COD_INFORME = loDatos.COD_INFORME;
                            // ocampoSuper.COD_ESPECIES_CAMPO = loDatos.COD_ESPECIES_CAMPO == null ? "" : loDatos.COD_ESPECIES_CAMPO;
                            ocampoSuper.BLOQUE_CAMPO = loDatos.BLOQUE_CAMPO == null ? "" : loDatos.BLOQUE_CAMPO;
                            ocampoSuper.FAJA_CAMPO = loDatos.FAJA_CAMPO == null ? "" : loDatos.FAJA_CAMPO;
                            ocampoSuper.CODIGO_CAMPO = loDatos.CODIGO_CAMPO == null ? "" : loDatos.CODIGO_CAMPO;
                            ocampoSuper.DAP_CAMPO = loDatos.DAP_CAMPO == -1 ? 0 : loDatos.DAP_CAMPO;
                            ocampoSuper.AC_CAMPO = loDatos.AC_CAMPO == -1 ? 0 : loDatos.AC_CAMPO;
                            ocampoSuper.ZONA_CAMPO = loDatos.ZONA_CAMPO;
                            ocampoSuper.COORDENADA_ESTE_CAMPO = loDatos.COORDENADA_ESTE_CAMPO == -1 ? 0 : loDatos.COORDENADA_ESTE_CAMPO;
                            ocampoSuper.COORDENADA_NORTE_CAMPO = loDatos.COORDENADA_NORTE_CAMPO == -1 ? 0 : loDatos.COORDENADA_NORTE_CAMPO;
                            ocampoSuper.OBSERVACION_CAMPO = loDatos.OBSERVACION_CAMPO == null ? "" : loDatos.OBSERVACION_CAMPO;
                            ocampoSuper.ESTADO_CAMPO = loDatos.ESTADO_CAMPO;
                            //ocampoSuper.GRADO_AMENAZA = loDatos.GRADO_AMENAZA;
                            ocampoSuper.DESC_CFUSTE = loDatos.DESC_CFUSTE == null ? "" : loDatos.DESC_CFUSTE;
                            ocampoSuper.DESC_FCOPA = loDatos.DESC_FCOPA == null ? "" : loDatos.DESC_FCOPA;
                            ocampoSuper.DESC_PCOPA = loDatos.DESC_PCOPA == null ? "" : loDatos.DESC_PCOPA;
                            ocampoSuper.DESC_EFENOLOGICO = loDatos.DESC_EFENOLOGICO == null ? "" : loDatos.DESC_EFENOLOGICO;
                            ocampoSuper.DESC_ESANITARIO = loDatos.DESC_ESANITARIO == null ? "" : loDatos.DESC_ESANITARIO;
                            ocampoSuper.DESC_ILIANAS = loDatos.DESC_ILIANAS == null ? "" : loDatos.DESC_ILIANAS;
                            //ocampoSuper.ESTADO_SUPERVISION = loDatos.ESTADO_SUPERVISION;
                            ocampoSuper.ESPECIES = loDatos.ESPECIES;
                            ocampoSuper.COD_SISTEMA = loDatos.COD_SISTEMA;
                            ocampoSuper.RegEstado = loDatos.RegEstado;
                            ocampoSuper.DAP_CAMPO2 = loDatos.DAP_CAMPO2 == -1 ? 0 : loDatos.DAP_CAMPO2;
                            ocampoSuper.DAP_CAMPO1 = loDatos.DAP_CAMPO1 == -1 ? 0 : loDatos.DAP_CAMPO1;
                            ocampoSuper.COINCIDE_ESPECIES = loDatos.COINCIDE_ESPECIES;
                            ocampoSuper.MAE_TIP_MMEDIRDAP = loDatos.MAE_TIP_MMEDIRDAP == "0000000" || loDatos.MAE_TIP_MMEDIRDAP == "" ? null : loDatos.MAE_TIP_MMEDIRDAP;
                            ocampoSuper.MMEDIR_DAP = loDatos.MMEDIR_DAP;
                            ocampoSuper.COD_ECONDICION = loDatos.COD_ECONDICION == "0000000" || loDatos.COD_ECONDICION == "" ? null : loDatos.COD_ECONDICION;
                            ocampoSuper.DESC_ECONDICION = loDatos.DESC_ECONDICION;
                            ocampoSuper.CANT_SOBRE_ESTIMA_DIAMETRO = loDatos.CANT_SOBRE_ESTIMA_DIAMETRO;
                            ocampoSuper.PORC_SOBRE_ESTIMA_DIAMETRO = loDatos.PORC_SOBRE_ESTIMA_DIAMETRO;
                            ocampoSuper.CANT_SUB_ESTIMA_DIAMETRO = loDatos.CANT_SUB_ESTIMA_DIAMETRO;
                            ocampoSuper.PORC_SUB_ESTIMA_DIAMETRO = loDatos.PORC_SUB_ESTIMA_DIAMETRO;
                            ocampoSuper.PCA = loDatos.PCA;
                            dBOracle.ManExecute(cn, tr, "doc_osinfor_erp_migracion.ISUPERVISION_DET_EMADERABLE_modificar", ocampoSuper);
                        }
                    }
                }
                tr.Commit();
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
        public void RegModificarFormatoNoMaderable(OracleConnection cn, CEntidad oCEntidad)
        {
            OracleTransaction tr = null;

            try
            {
                tr = cn.BeginTransaction();
                if (oCEntidad.ListINFORMEItemsDetalle != null)
                {
                    CEntidad ocampoSuper;

                    foreach (var loDatos in oCEntidad.ListINFORMEItemsDetalle)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 0) //Nuevo o Modificado
                        {
                            ocampoSuper = new CEntidad();
                            ocampoSuper.COD_INFORME = loDatos.COD_INFORME;
                            ocampoSuper.NUM_ESTRADA = loDatos.NUM_ESTRADA == null ? "" : loDatos.NUM_ESTRADA;
                            ocampoSuper.CODIGO_CAMPO = loDatos.CODIGO_CAMPO == null ? "" : loDatos.CODIGO_CAMPO;
                            //ocampoSuper.DIAMETRO_CAMPO = loDatos.DIAMETRO_CAMPO == -1 ? 0 : loDatos.DIAMETRO_CAMPO;
                            //ocampoSuper.ALTURA_CAMPO = loDatos.ALTURA_CAMPO == -1 ? 0 : loDatos.ALTURA_CAMPO;
                            //ocampoSuper.PRODUCCION_LATAS_CAMPO = loDatos.PRODUCCION_LATAS_CAMPO == -1 ? 0 : loDatos.PRODUCCION_LATAS_CAMPO;
                            ocampoSuper.ZONA_CAMPO = loDatos.ZONA_CAMPO;
                            ocampoSuper.COORDENADA_ESTE_CAMPO = loDatos.COORDENADA_ESTE_CAMPO == -1 ? 0 : loDatos.COORDENADA_ESTE_CAMPO;
                            ocampoSuper.COORDENADA_NORTE_CAMPO = loDatos.COORDENADA_NORTE_CAMPO == -1 ? 0 : loDatos.COORDENADA_NORTE_CAMPO;
                            ocampoSuper.OBSERVACION_CAMPO = loDatos.OBSERVACION_CAMPO == null ? "" : loDatos.OBSERVACION_CAMPO;
                            ocampoSuper.ESTADO_CAMPO = loDatos.ESTADO_CAMPO;
                            //ocampoSuper.NUM_COCOS_ABIERTOS = loDatos.NUM_COCOS_ABIERTOS == -1 ? 0 : loDatos.NUM_COCOS_ABIERTOS;
                            //ocampoSuper.NUM_COCOS_CERRADOS = loDatos.NUM_COCOS_CERRADOS == -1 ? 0 : loDatos.NUM_COCOS_CERRADOS;
                            //ocampoSuper.DESC_CFUSTE = loDatos.DESC_CFUSTE;
                            //ocampoSuper.DESC_PCOPA = loDatos.DESC_PCOPA;
                            //ocampoSuper.DESC_FCOPA = loDatos.DESC_FCOPA;
                            //ocampoSuper.DESC_EFENOLOGICO = loDatos.DESC_EFENOLOGICO;
                            ocampoSuper.DESC_ESANITARIO = loDatos.DESC_ESANITARIO;
                            ocampoSuper.DESC_ILIANAS = loDatos.DESC_ILIANAS;
                            //ocampoSuper.ESTADO_SUPERVISION = loDatos.ESTADO_SUPERVISION;
                            ocampoSuper.ESPECIES = loDatos.ESPECIES;
                            ocampoSuper.COD_SISTEMA = loDatos.COD_SISTEMA;
                            ocampoSuper.RegEstado = loDatos.RegEstado;
                            //ocampoSuper.COD_ECONDICION = loDatos.COD_ECONDICION;
                            ocampoSuper.DESC_ECONDICION = loDatos.DESC_ECONDICION_CAMPO;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.ISUPERVISION_DET_NOMADERABLE_modificar", ocampoSuper);
                        }
                    }
                }
                tr.Commit();

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
        public void RegModificarFormatoBosqueSeco(OracleConnection cn, CEntidad oCEntidad)
        {
            OracleTransaction tr = null;

            try
            {
                tr = cn.BeginTransaction();
                if (oCEntidad.ListINFORMEItemsDetalle != null)
                {
                    CEntidad ocampoSuper;

                    foreach (var loDatos in oCEntidad.ListINFORMEItemsDetalle)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 0) //Nuevo o Modificado
                        {
                            ocampoSuper = new CEntidad();
                            ocampoSuper.COD_INFORME = loDatos.COD_INFORME;
                            // ocampoSuper.COD_ESPECIES_CAMPO = loDatos.COD_ESPECIES_CAMPO == null ? "" : loDatos.COD_ESPECIES_CAMPO;
                            ocampoSuper.BLOQUE_CAMPO = loDatos.BLOQUE_CAMPO == null ? "" : loDatos.BLOQUE_CAMPO;
                            ocampoSuper.FAJA_CAMPO = loDatos.FAJA_CAMPO == null ? "" : loDatos.FAJA_CAMPO;
                            ocampoSuper.CODIGO_CAMPO = loDatos.CODIGO_CAMPO == null ? "" : loDatos.CODIGO_CAMPO;
                            ocampoSuper.DAP_CAMPO = loDatos.DAP_CAMPO == -1 ? 0 : loDatos.DAP_CAMPO;
                            ocampoSuper.AC_CAMPO = loDatos.AC_CAMPO == -1 ? 0 : loDatos.AC_CAMPO;
                            ocampoSuper.ZONA_CAMPO = loDatos.ZONA_CAMPO;
                            ocampoSuper.COORDENADA_ESTE_CAMPO = loDatos.COORDENADA_ESTE_CAMPO == -1 ? 0 : loDatos.COORDENADA_ESTE_CAMPO;
                            ocampoSuper.COORDENADA_NORTE_CAMPO = loDatos.COORDENADA_NORTE_CAMPO == -1 ? 0 : loDatos.COORDENADA_NORTE_CAMPO;
                            ocampoSuper.OBSERVACION_CAMPO = loDatos.OBSERVACION_CAMPO == null ? "" : loDatos.OBSERVACION_CAMPO;
                            ocampoSuper.ESTADO_CAMPO = loDatos.ESTADO_CAMPO;
                            ocampoSuper.BS_ALTURA_TOTAL = loDatos.BS_ALTURA_TOTAL == -1 ? 0 : loDatos.BS_ALTURA_TOTAL;
                            ocampoSuper.BS_DIAMETRO_RAMA_1 = loDatos.BS_DIAMETRO_RAMA_1 == -1 ? 0 : loDatos.BS_DIAMETRO_RAMA_1;
                            ocampoSuper.BS_DIAMETRO_RAMA_2 = loDatos.BS_DIAMETRO_RAMA_2 == -1 ? 0 : loDatos.BS_DIAMETRO_RAMA_2;
                            ocampoSuper.BS_DIAMETRO_RAMA_3 = loDatos.BS_DIAMETRO_RAMA_3 == -1 ? 0 : loDatos.BS_DIAMETRO_RAMA_3;
                            ocampoSuper.BS_DIAMETRO_RAMA_4 = loDatos.BS_DIAMETRO_RAMA_4 == -1 ? 0 : loDatos.BS_DIAMETRO_RAMA_4;
                            ocampoSuper.BS_DIAMETRO_RAMA_5 = loDatos.BS_DIAMETRO_RAMA_5 == -1 ? 0 : loDatos.BS_DIAMETRO_RAMA_5;
                            ocampoSuper.BS_DIAMETRO_RAMA_6 = loDatos.BS_DIAMETRO_RAMA_6 == -1 ? 0 : loDatos.BS_DIAMETRO_RAMA_6;
                            ocampoSuper.BS_DIAMETRO_RAMA_7 = loDatos.BS_DIAMETRO_RAMA_7 == -1 ? 0 : loDatos.BS_DIAMETRO_RAMA_7;
                            ocampoSuper.BS_LONGITUD_RAMA_1 = loDatos.BS_LONGITUD_RAMA_1 == -1 ? 0 : loDatos.BS_LONGITUD_RAMA_1;
                            ocampoSuper.BS_LONGITUD_RAMA_2 = loDatos.BS_LONGITUD_RAMA_2 == -1 ? 0 : loDatos.BS_LONGITUD_RAMA_2;
                            ocampoSuper.BS_LONGITUD_RAMA_3 = loDatos.BS_LONGITUD_RAMA_3 == -1 ? 0 : loDatos.BS_LONGITUD_RAMA_3;
                            ocampoSuper.BS_LONGITUD_RAMA_4 = loDatos.BS_LONGITUD_RAMA_4 == -1 ? 0 : loDatos.BS_LONGITUD_RAMA_4;
                            ocampoSuper.BS_LONGITUD_RAMA_5 = loDatos.BS_LONGITUD_RAMA_5 == -1 ? 0 : loDatos.BS_LONGITUD_RAMA_5;
                            ocampoSuper.BS_LONGITUD_RAMA_6 = loDatos.BS_LONGITUD_RAMA_6 == -1 ? 0 : loDatos.BS_LONGITUD_RAMA_6;
                            ocampoSuper.BS_LONGITUD_RAMA_7 = loDatos.BS_LONGITUD_RAMA_7 == -1 ? 0 : loDatos.BS_LONGITUD_RAMA_7;
                            //ocampoSuper.GRADO_AMENAZA = loDatos.GRADO_AMENAZA;
                            ocampoSuper.DESC_CFUSTE = loDatos.DESC_CFUSTE == null ? "" : loDatos.DESC_CFUSTE;
                            ocampoSuper.DESC_FCOPA = loDatos.DESC_FCOPA == null ? "" : loDatos.DESC_FCOPA;
                            ocampoSuper.DESC_PCOPA = loDatos.DESC_PCOPA == null ? "" : loDatos.DESC_PCOPA;
                            ocampoSuper.DESC_EFENOLOGICO = loDatos.DESC_EFENOLOGICO == null ? "" : loDatos.DESC_EFENOLOGICO;
                            ocampoSuper.DESC_ESANITARIO = loDatos.DESC_ESANITARIO == null ? "" : loDatos.DESC_ESANITARIO;
                            ocampoSuper.DESC_ILIANAS = loDatos.DESC_ILIANAS == null ? "" : loDatos.DESC_ILIANAS;
                            //ocampoSuper.ESTADO_SUPERVISION = loDatos.ESTADO_SUPERVISION;
                            ocampoSuper.ESPECIES = loDatos.ESPECIES;
                            ocampoSuper.COD_SISTEMA = loDatos.COD_SISTEMA;
                            ocampoSuper.RegEstado = loDatos.RegEstado;
                            ocampoSuper.DAP_CAMPO2 = loDatos.DAP_CAMPO2 == -1 ? 0 : loDatos.DAP_CAMPO2;
                            ocampoSuper.DAP_CAMPO1 = loDatos.DAP_CAMPO1 == -1 ? 0 : loDatos.DAP_CAMPO1;
                            ocampoSuper.COINCIDE_ESPECIES = loDatos.COINCIDE_ESPECIES;
                            ocampoSuper.MAE_TIP_MMEDIRDAP = loDatos.MAE_TIP_MMEDIRDAP == "0000000" || loDatos.MAE_TIP_MMEDIRDAP == "" ? null : loDatos.MAE_TIP_MMEDIRDAP;
                            ocampoSuper.MMEDIR_DAP = loDatos.MMEDIR_DAP;
                            ocampoSuper.COD_ECONDICION = loDatos.COD_ECONDICION == "0000000" || loDatos.COD_ECONDICION == "" ? null : loDatos.COD_ECONDICION;
                            ocampoSuper.DESC_ECONDICION = loDatos.DESC_ECONDICION;
                            ocampoSuper.CANT_SOBRE_ESTIMA_DIAMETRO = loDatos.CANT_SOBRE_ESTIMA_DIAMETRO;
                            ocampoSuper.PORC_SOBRE_ESTIMA_DIAMETRO = loDatos.PORC_SOBRE_ESTIMA_DIAMETRO;
                            ocampoSuper.CANT_SUB_ESTIMA_DIAMETRO = loDatos.CANT_SUB_ESTIMA_DIAMETRO;
                            ocampoSuper.PORC_SUB_ESTIMA_DIAMETRO = loDatos.PORC_SUB_ESTIMA_DIAMETRO;
                            ocampoSuper.PCA = loDatos.PCA;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.ISUPERVISION_DET_EMADERABLE_modificar", ocampoSuper);
                        }
                    }
                }
                tr.Commit();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        // INFORME FAUNA EXISTU
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public CEntidad INFORME_ISUPERVISION_EXSITU_MostItem(OracleConnection cn, CEntidad oCEntidad)
        {
            CEntidad lsCEntidad = new CEntidad();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spINFORME_ISUPERVISION_EXSITU_MostItem", oCEntidad))
                {
                    if (dr != null)
                    {
                        lsCEntidad.ListInformeDetSupervisor = new List<CEntPersona>();
                        lsCEntidad.ListPersonalTecProf = new List<CEntPersona>();//Persona técnico profesional
                        lsCEntidad.ListRelPelCentroCria = new List<CEntPersona>();
                        lsCEntidad.ListAreaExsitu = new List<CEntISExsitu>();
                        lsCEntidad.ListGrupoToxonomico = new List<CEntISExsitu>();
                        lsCEntidad.ListProgManejoSanitarioFisico = new List<CEntISExsitu>();
                        lsCEntidad.ListProgManejoSanitarioQuimico = new List<CEntISExsitu>();
                        lsCEntidad.ListProgBioFrecuenciaLimpieza = new List<CEntISExsitu>();
                        lsCEntidad.ListMaterialDesinfeccion = new List<CEntISExsitu>();
                        lsCEntidad.ListEquipoDesinfeccion = new List<CEntISExsitu>();
                        lsCEntidad.ListCautiverioControlPlaga = new List<CEntISExsitu>();
                        lsCEntidad.LisCautiveriotManejoRegistro = new List<CEntISExsitu>();
                        lsCEntidad.LisCautiverioEspecieReproducida = new List<CEntISExsitu>();
                        lsCEntidad.LisCautiverioActividadRealizada = new List<CEntISExsitu>();
                        lsCEntidad.LisCautiverioCensoICientifica = new List<CEntISExsitu>();
                        lsCEntidad.LisCautiverioEnriquecAmbiental = new List<CEntISExsitu>();
                        lsCEntidad.LisCautiverioCensoVertebrado = new List<CEntISExsitu>();//
                        lsCEntidad.LisCapacitacionFauna = new List<CEntISExsitu>();
                        lsCEntidad.LisCautiverioECapturado = new List<CEntISExsitu>();
                        lsCEntidad.ListOCEjecucionActividad = new List<CEntidad>();
                        lsCEntidad.ListOCEspeciesExoticas = new List<CEntidad>();
                        lsCEntidad.ListOCActosTercero = new List<CEntidad>();
                        lsCEntidad.ListOCAprovechamientoDirecto = new List<CEntidad>();
                        lsCEntidad.ListFotos = new List<CEntidad>();
                        lsCEntidad.ListObligacionTitular = new List<Ent_INFORME_OBLIGTITULAR>();


                        lsCEntidad.ListEliTABLA = new List<CEntidad>();
                        lsCEntidad.ListNacimientosEspecies = new List<CEntISExsitu>(); // nacimientos
                        lsCEntidad.ListEgresosEspecies = new List<CEntISExsitu>();//egreso de especies
                                                                                  //CEntPresupSuper ocampodet;
                                                                                  //CEntidad ocampoEnt;
                                                                                  //Evaluación ZoObservatorio
                        lsCEntidad.ListISuperExsituBalance = new List<CEntISExsitu>();//egreso de especies
                        lsCEntidad.ListISuperExsituOBLIGF = new List<CEntISExsitu>();//egreso de especies


                        lsCEntidad.ListDesplazamientoInforme = new List<CapaEntidad.DOC.Ent_INFORME>();
                        lsCEntidad.ListEvalZoObservatorio = new List<CapaEntidad.DOC.Ent_ISUPERVISION_EXSITU_CAUTI_EVALZOO>();

                        CEntPersona ocampoPersona;
                        CEntISExsitu ocampoExitu;
                        Int32 num_fila;
                        List<CEntISExsitu> ListISupervision_exsitu_recinto_equipo;
                        List<CEntISExsitu> ListISupervision_exsitu_recinto_equipo_temp;
                        if (dr.HasRows)
                        {
                            dr.Read();
                            lsCEntidad.NUMERO = dr.GetString(dr.GetOrdinal("NUMERO"));
                            lsCEntidad.FECHA_SUPERVISION_INICIO = dr.GetString(dr.GetOrdinal("FECHA_SUPERVISION_INICIO"));
                            lsCEntidad.FECHA_SUPERVISION_FIN = dr.GetString(dr.GetOrdinal("FECHA_SUPERVISION_FIN"));
                            lsCEntidad.FECHA_ENTREGA = dr.GetString(dr.GetOrdinal("FECHA_ENTREGA"));
                            lsCEntidad.COD_TIPO_SUPER = dr.GetString(dr.GetOrdinal("COD_TIPO_SUPER"));
                            lsCEntidad.TIPO_INFORME = dr.GetString(dr.GetOrdinal("TIPO_INFORME"));
                            //lsCEntidad.FECHA_RECEPCION_OD = dr.GetString(dr.GetOrdinal("FECHA_RECEPCION_OD"));
                            //lsCEntidad.FECHA_RECEPCION_SCENTRAL = dr.GetString(dr.GetOrdinal("FECHA_RECEPCION_SCENTRAL"));
                            lsCEntidad.LICENCIA_ESTADO = dr.GetBoolean(dr.GetOrdinal("LICENCIA_ESTADO"));
                            lsCEntidad.LICENCIA_NUMERO = dr.GetString(dr.GetOrdinal("LICENCIA_NUMERO"));
                            lsCEntidad.UBIGEO = dr.GetString(dr.GetOrdinal("UBIGEO"));
                            lsCEntidad.THABILITANTE_SECTOR = dr.GetString(dr.GetOrdinal("THABILITANTE_SECTOR"));
                            lsCEntidad.THABILITANTE_COD_UBIGEO = dr.GetString(dr.GetOrdinal("THABILITANTE_COD_UBIGEO"));
                            lsCEntidad.CUENTA_CROQUIS = dr.GetBoolean(dr.GetOrdinal("CUENTA_CROQUIS"));
                            lsCEntidad.TIENE_VIAS = dr.GetBoolean(dr.GetOrdinal("TIENE_VIAS"));
                            lsCEntidad.AREA_CUARENTENA_ALEJADO = dr.GetBoolean(dr.GetOrdinal("AREA_CUARENTENA_ALEJADO"));
                            lsCEntidad.AREA_ADMINISTRATIVA_TCARTEL = dr.GetBoolean(dr.GetOrdinal("AREA_ADMINISTRATIVA_TCARTEL"));
                            lsCEntidad.AREA_SHIGIENICO_TCARTEL = dr.GetBoolean(dr.GetOrdinal("AREA_SHIGIENICO_TCARTEL"));
                            lsCEntidad.AREA_OTROS_OBSERVACION = dr.GetString(dr.GetOrdinal("AREA_OTROS_OBSERVACION"));
                            lsCEntidad.PROGRAMA_ALIMENTACION = dr.GetBoolean(dr.GetOrdinal("PROGRAMA_ALIMENTACION"));
                            lsCEntidad.PICIENTIFICA_IREALIZADA = dr.GetBoolean(dr.GetOrdinal("PICIENTIFICA_IREALIZADA"));
                            lsCEntidad.PROTOCOLO_LIMPIEZA = dr.GetBoolean(dr.GetOrdinal("PROTOCOLO_LIMPIEZA"));
                            lsCEntidad.FLIMPIEZA_COD_TDESCRIPTIVA = dr.GetString(dr.GetOrdinal("FLIMPIEZA_COD_TDESCRIPTIVA"));
                            lsCEntidad.PEDILUVIOS = dr.GetBoolean(dr.GetOrdinal("PEDILUVIOS"));
                            lsCEntidad.MANEJO_RESIDUOS_SOLIDOS = dr.GetBoolean(dr.GetOrdinal("MANEJO_RESIDUOS_SOLIDOS"));
                            lsCEntidad.DRINORGANICO_COD_TDESCRIPTIVA = dr.GetString(dr.GetOrdinal("DRINORGANICO_COD_TDESCRIPTIVA"));
                            lsCEntidad.DRORGANICO_COD_TDESCRIPTIVA = dr.GetString(dr.GetOrdinal("DRORGANICO_COD_TDESCRIPTIVA"));
                            lsCEntidad.DCADAVERES_COD_TDESCRIPTIVA = dr.GetString(dr.GetOrdinal("DCADAVERES_COD_TDESCRIPTIVA"));
                            lsCEntidad.FDESINFECCION_COD_TDESCRIPTIVA = dr.GetString(dr.GetOrdinal("FDESINFECCION_COD_TDESCRIPTIVA"));
                            lsCEntidad.RESPONSABLE_COD_PERSONA = dr.GetString(dr.GetOrdinal("RESPONSABLE_COD_PERSONA"));
                            lsCEntidad.RESPONSABLE_NOMBRE = dr.GetString(dr.GetOrdinal("APELLIDOS_NOMBRES"));
                            lsCEntidad.COD_OD_REGISTRO = dr.GetString(dr.GetOrdinal("COD_OD_REGISTRO"));
                            lsCEntidad.ID_TRAMITE_SITD = dr.GetInt32(dr.GetOrdinal("ID_TRAMITE_SITD"));
                            lsCEntidad.PROMOVIDO = dr.GetBoolean(dr.GetOrdinal("PROMOVIDO"));
                            lsCEntidad.COD_ESTADO_DOC = dr.GetString(dr.GetOrdinal("COD_ESTADO_DOC"));
                            lsCEntidad.OBSERVACIONES_CONTROL = dr.GetString(dr.GetOrdinal("OBSERVACIONES_CONTROL"));
                            lsCEntidad.OBSERV_SUBSANAR = dr.GetBoolean(dr.GetOrdinal("OBSERV_SUBSANAR"));
                            lsCEntidad.PUBLICAR = dr.GetBoolean(dr.GetOrdinal("PUBLICAR"));
                            lsCEntidad.TODOSINDICADORES = dr.GetBoolean(dr.GetOrdinal("TODOSINDICADORES"));
                            lsCEntidad.HECHOSDENUNCIADOS = dr.GetBoolean(dr.GetOrdinal("HECHOSDENUNCIADOS"));
                            lsCEntidad.MANDATOS = dr.GetBoolean(dr.GetOrdinal("MANDATOS"));
                            lsCEntidad.MEDIDASCORRECTIVAS = dr.GetBoolean(dr.GetOrdinal("MEDIDASCORRECTIVAS"));
                            lsCEntidad.CUENTAMEDVET = dr.GetString(dr.GetOrdinal("CUENTAMEDVET"));
                            lsCEntidad.TIPOVISMED = dr.GetString(dr.GetOrdinal("TIPOVISMED"));
                            lsCEntidad.VISITAMES = dr.GetString(dr.GetOrdinal("VISITAMES"));
                            lsCEntidad.OBSMEDVET = dr.GetString(dr.GetOrdinal("OBSMEDVET"));
                            lsCEntidad.FFPROPIAS = dr.GetBoolean(dr.GetOrdinal("FFPROPIAS"));
                            lsCEntidad.FFDONACIONES = dr.GetBoolean(dr.GetOrdinal("FFDONACIONES"));
                            lsCEntidad.FFCREDITO = dr.GetBoolean(dr.GetOrdinal("FFCREDITO"));
                            lsCEntidad.FFINVERSIONISTA = dr.GetBoolean(dr.GetOrdinal("FFINVERSIONISTA"));
                            lsCEntidad.FFAPOYO = dr.GetBoolean(dr.GetOrdinal("FFAPOYO"));
                            lsCEntidad.FFVOLUNTARIO = dr.GetBoolean(dr.GetOrdinal("FFVOLUNTARIO"));
                            lsCEntidad.FFOTRO = dr.GetString(dr.GetOrdinal("FFOTRO"));
                            lsCEntidad.REALIZA_PCONTENCION = dr.GetString(dr.GetOrdinal("REALIZA_PCONTENCION"));
                            lsCEntidad.REALIZA_PBIOSEGURIDAD = dr.GetString(dr.GetOrdinal("REALIZA_PBIOSEGURIDAD"));
                            lsCEntidad.REALIZA_PENRIQUECIMIENTO = dr.GetString(dr.GetOrdinal("REALIZA_PENRIQUECIMIENTO"));
                            lsCEntidad.REALIZA_PMANEJOGEN = dr.GetString(dr.GetOrdinal("REALIZA_PMANEJOGEN"));
                            lsCEntidad.REALIZA_PEDUCAMB = dr.GetString(dr.GetOrdinal("REALIZA_PEDUCAMB"));
                            lsCEntidad.REALIZA_PINVCIENT = dr.GetString(dr.GetOrdinal("REALIZA_PINVCIENT"));
                            lsCEntidad.REALIZA_PCOLECTA = dr.GetString(dr.GetOrdinal("REALIZA_PCOLECTA"));
                            lsCEntidad.USUARIO_REGISTRO = dr.GetString(dr.GetOrdinal("USUARIO_REGISTRO"));
                            lsCEntidad.USUARIO_CONTROL = dr.GetString(dr.GetOrdinal("USUARIO_CONTROL"));

                            lsCEntidad.GEOTEC_DESCRIPCION = dr.GetString(dr.GetOrdinal("GEOTEC_DESCRIPCION"));
                            lsCEntidad.GEOTEC_DRON = dr.GetBoolean(dr.GetOrdinal("GEOTEC_DRON"));
                            lsCEntidad.GEOTEC_GEOSUPERVISOR = dr.GetBoolean(dr.GetOrdinal("GEOTEC_GEOSUPERVISOR"));
                            lsCEntidad.GEOTEC_NINGUNO = dr.GetBoolean(dr.GetOrdinal("GEOTEC_NINGUNO"));
                            lsCEntidad.GEOTEC_OTROS = dr.GetBoolean(dr.GetOrdinal("GEOTEC_OTROS"));
                            lsCEntidad.CUENTA_REGENTE = dr.GetBoolean(dr.GetOrdinal("CUENTA_REGENTE"));
                            lsCEntidad.CODIGO = dr.GetString(dr.GetOrdinal("COD_REGENTE"));
                            lsCEntidad.NOMBRE_REGENTE = dr.GetString(dr.GetOrdinal("NOMBRE_REGENTE"));
                            lsCEntidad.CODIGO_REGENTE = dr.GetString(dr.GetOrdinal("CODIGO_REGENTE"));
                            lsCEntidad.FECHA_REGENTE = dr.GetString(dr.GetOrdinal("FECHA_REGENTE"));

                            lsCEntidad.COD_ISU_EVALUACION = dr.GetString(dr.GetOrdinal("COD_ISU_EVALUACION"));

                            lsCEntidad.FINES_CREACION = dr.GetString(dr.GetOrdinal("FINES_CREACION"));
                            lsCEntidad.OBJETIVOS_PRINCIPALES = dr.GetString(dr.GetOrdinal("OBJETIVOS_PRINCIPALES"));
                            lsCEntidad.COND_ADECUADAS = dr.GetString(dr.GetOrdinal("COND_ADECUADAS"));
                            lsCEntidad.DOC_LEGAL = dr.GetString(dr.GetOrdinal("DOC_LEGAL"));
                            lsCEntidad.PROG_ESTABLECIDOPM = dr.GetString(dr.GetOrdinal("PROG_ESTABLECIDOPM"));
                            lsCEntidad.INF_RESPALDO = dr.GetString(dr.GetOrdinal("INF_RESPALDO"));
                            lsCEntidad.EGRE_ANIMALES = dr.GetString(dr.GetOrdinal("EGRE_ANIMALES"));
                            lsCEntidad.BD_ESPECIMENES = dr.GetString(dr.GetOrdinal("BD_ESPECIMENES"));
                            lsCEntidad.PRESENT_INFORMES = dr.GetString(dr.GetOrdinal("PRESENT_INFORMES"));
                            lsCEntidad.LIBRO_OPERAC = dr.GetString(dr.GetOrdinal("LIBRO_OPERAC"));
                            lsCEntidad.Evaluacion_Informe = dr.GetDouble(dr.GetOrdinal("Evaluacion_Informe"));
                            lsCEntidad.OBJ_ACTUAL = dr.GetString(dr.GetOrdinal("OBJ_ACTUAL"));
                            lsCEntidad.OBJ_PRINCIP = dr.GetString(dr.GetOrdinal("OBJ_PRINCIP"));
                            lsCEntidad.VISITA = dr.GetBoolean(dr.GetOrdinal("VISITA"));
                            lsCEntidad.REPRODUCE = dr.GetBoolean(dr.GetOrdinal("REPRODUCE"));
                            lsCEntidad.OBSERVACION_PUBLICAR = dr.GetString(dr.GetOrdinal("OBSERVACION_PUBLICAR"));

                            lsCEntidad.OB_FINES_CREACION = dr.GetString(dr.GetOrdinal("OB_FINES_CREACION"));
                            lsCEntidad.OB_OBJETIVOS_PRINCIPALES = dr.GetString(dr.GetOrdinal("OB_OBJETIVOS_PRINCIPALES"));
                            lsCEntidad.OB_COND_ADECUADAS = dr.GetString(dr.GetOrdinal("OB_COND_ADECUADAS"));
                            lsCEntidad.OB_DOC_LEGAL = dr.GetString(dr.GetOrdinal("OB_DOC_LEGAL"));
                            lsCEntidad.OB_PROG_ESTABLECIDOPM = dr.GetString(dr.GetOrdinal("OB_PROG_ESTABLECIDOPM"));
                            lsCEntidad.OB_INF_RESPALDO = dr.GetString(dr.GetOrdinal("OB_INF_RESPALDO"));
                            lsCEntidad.OB_EGRE_ANIMALES = dr.GetString(dr.GetOrdinal("OB_EGRE_ANIMALES"));
                            lsCEntidad.OB_BD_ESPECIMENES = dr.GetString(dr.GetOrdinal("OB_BD_ESPECIMENES"));
                            lsCEntidad.OB_PRESENT_INFORMES = dr.GetString(dr.GetOrdinal("OB_PRESENT_INFORMES"));
                            lsCEntidad.OB_LIBRO_OPERAC = dr.GetString(dr.GetOrdinal("OB_LIBRO_OPERAC"));
                            lsCEntidad.COD_IMOTIVO = dr.GetString(dr.GetOrdinal("COD_IMOTIVO"));
                            //Nuevas columnas
                            lsCEntidad.IMOTIVO = dr.GetString(dr.GetOrdinal("IMOTIVO"));
                            lsCEntidad.MAE_TIP_MOTMOTIVADA = dr.GetString(dr.GetOrdinal("MAE_TIP_MOTMOTIVADA"));
                            lsCEntidad.COD_TRAMITE_SITD = dr.GetInt32(dr.GetOrdinal("COD_TRAMITE_SITD"));
                            lsCEntidad.NUM_DREFERENCIA = dr.GetString(dr.GetOrdinal("NUM_DREFERENCIA"));
                            lsCEntidad.OBSERVACION = dr.GetString(dr.GetOrdinal("OBSERVACION"));
                            lsCEntidad.CALIFICACION_EVALZOO = dr.GetDouble(dr.GetOrdinal("CALIFICACION_EVALZOO"));
                            lsCEntidad.BIOSEGURIDADOTROS = dr.GetString(dr.GetOrdinal("BIOSEGURIDADOTROS"));
                            lsCEntidad.OBSERVACION_FRECUENCIA = dr.GetString(dr.GetOrdinal("OBSERVACION_FRECUENCIA"));

                            lsCEntidad.HORARIO_RALIMENTO = dr.GetString(dr.GetOrdinal("HORARIO_RALIMENTO"));
                            lsCEntidad.DIAS_ABASTECIMIENTO = dr.GetString(dr.GetOrdinal("DIAS_ABASTECIMIENTO"));

                            lsCEntidad.PROTOCOL_CONTINGENCIA = dr.GetString(dr.GetOrdinal("PROTOCOL_CONTINGENCIA"));
                            lsCEntidad.PROTOCOL_ACCION = dr.GetString(dr.GetOrdinal("PROTOCOL_ACCION"));
                            lsCEntidad.OBSERVACION_CONTENCION = dr.GetString(dr.GetOrdinal("OBSERVACION_CONTENCION"));
                            lsCEntidad.RESIDUOS_PELIGROSOS = dr.GetString(dr.GetOrdinal("RESIDUOS_PELIGROSOS"));

                            lsCEntidad.INFORME_EJECUCIONPM = dr.GetString(dr.GetOrdinal("INFORME_EJECUCIONPM"));
                            lsCEntidad.ANIOS_EJECUCIONPM = dr.GetString(dr.GetOrdinal("ANIOS_EJECUCIONPM"));
                            lsCEntidad.REALIZA_CAPCITAC = dr.GetString(dr.GetOrdinal("REALIZA_CAPCITAC"));
                            lsCEntidad.RECOMENDACIONC = dr.GetString(dr.GetOrdinal("RECOMENDACIONC"));
                            lsCEntidad.CONCLUSIONC = dr.GetString(dr.GetOrdinal("CONCLUSIONC"));
                            lsCEntidad.MANDATOC = dr.GetString(dr.GetOrdinal("MANDATOC"));
                            lsCEntidad.RECOMENDARC = dr.GetBoolean(dr.GetOrdinal("RECOMENDARC"));

                            lsCEntidad.chkOtrosMateriales = false;
                            lsCEntidad.txtOtrosMateriales = "";
                            lsCEntidad.chkOtrosMaterialesDesinf = false;
                            lsCEntidad.txtOtrosMaterialesDesinf = "";
                            lsCEntidad.BUEN_DESEMPENIO = dr.GetInt32(dr.GetOrdinal("BUEN_DESEMPENIO"));
                            lsCEntidad.ARCHIVA_INFORME = (!dr.IsDBNull(dr.GetOrdinal("ARCHIVA_INFORME"))) ? dr.GetInt32(dr.GetOrdinal("ARCHIVA_INFORME")) : -1;
                        }
                        //Lista de Supervisor
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            int pt0 = dr.GetOrdinal("COD_SUPERVISOR");
                            int pt1 = dr.GetOrdinal("APE_PATERNO");
                            int pt2 = dr.GetOrdinal("APE_MATERNO");
                            int pt3 = dr.GetOrdinal("NOMBRES");
                            int pt4 = dr.GetOrdinal("NOMBRE_SUPERVISOR");
                            int pt5 = dr.GetOrdinal("N_DOCUMENTO");
                            int pt6 = dr.GetOrdinal("COD_DIDENTIDAD");
                            int pt7 = dr.GetOrdinal("COD_NACADEMICO");
                            int pt8 = dr.GetOrdinal("COD_DPESPECIALIDAD");
                            int pt9 = dr.GetOrdinal("COLEGIATURA_NUM");
                            while (dr.Read())
                            {
                                ocampoPersona = new CEntPersona();
                                ocampoPersona.COD_PERSONA = dr.GetString(pt0);
                                ocampoPersona.APE_PATERNO = dr.GetString(pt1);
                                ocampoPersona.APE_MATERNO = dr.GetString(pt2);
                                ocampoPersona.NOMBRES = dr.GetString(pt3);
                                ocampoPersona.PERSONA = dr.GetString(pt4);
                                ocampoPersona.N_DOCUMENTO = dr.GetString(pt5);
                                ocampoPersona.COD_DIDENTIDAD = dr.GetString(pt6);
                                ocampoPersona.COD_NACADEMICO = dr.GetString(pt7);
                                ocampoPersona.COD_DPESPECIALIDAD = dr.GetString(pt8);
                                ocampoPersona.COLEGIATURA_NUM = dr.GetString(pt9);
                                ocampoPersona.ESTADO_FIRMA = dr["ESTADO_FIRMA"].ToString();
                                ocampoPersona.FLAG_FIRMA = Convert.ToInt32(dr["FLAG_FIRMA"]);
                                ocampoPersona.COD_PTIPO = "0000007";
                                ocampoPersona.RegEstado = 0;
                                lsCEntidad.ListInformeDetSupervisor.Add(ocampoPersona);
                            }
                        }
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            int pt0 = dr.GetOrdinal("COD_AREA");
                            int pt1 = dr.GetOrdinal("COD_SECUENCIAL");
                            int pt2 = dr.GetOrdinal("NUMERO");
                            int pt3 = dr.GetOrdinal("LARGO");
                            int pt4 = dr.GetOrdinal("ANCHO");
                            int pt5 = dr.GetOrdinal("ALTURA");
                            int pt6 = dr.GetOrdinal("AREA");
                            num_fila = 0;
                            while (dr.Read())
                            {
                                ocampoExitu = new CEntISExsitu();
                                ocampoExitu.COD_AREA = dr.GetString(pt0);
                                ocampoExitu.COD_SECUENCIAL = dr.GetInt32(pt1);
                                ocampoExitu.NUMERO = dr.GetString(pt2);
                                ocampoExitu.LARGO = dr.GetDecimal(pt3);
                                ocampoExitu.ANCHO = dr.GetDecimal(pt4);
                                ocampoExitu.ALTURA = dr.GetDecimal(pt5);
                                ocampoExitu.AREA = dr.GetDecimal(pt6);
                                ocampoExitu.NUM_FILA = num_fila;
                                num_fila++;
                                ocampoExitu.RegEstado = 0;
                                lsCEntidad.ListAreaExsitu.Add(ocampoExitu);
                            }
                        }
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            int pt0 = dr.GetOrdinal("COD_INFORME");
                            int pt1 = dr.GetOrdinal("COD_SECUENCIAL");
                            int pt2 = dr.GetOrdinal("COD_AREA");
                            int pt3 = dr.GetOrdinal("COD_TDESCRIPTIVA");
                            int pt4 = dr.GetOrdinal("DESCRIPCION");
                            int pt5 = dr.GetOrdinal("TIPO");
                            ListISupervision_exsitu_recinto_equipo = new List<CEntISExsitu>();
                            while (dr.Read())
                            {
                                ocampoExitu = new CEntISExsitu();
                                ocampoExitu.COD_INFORME = dr.GetString(pt0);
                                ocampoExitu.COD_SECUENCIAL = dr.GetInt32(pt1);
                                ocampoExitu.COD_AREA = dr.GetString(pt2);
                                ocampoExitu.COD_TDESCRIPTIVA = dr.GetString(pt3);
                                ocampoExitu.DESCRIPCION = dr.GetString(pt4);
                                ocampoExitu.TIPO = dr.GetString(pt5);
                                ocampoExitu.RegEstado = 0;
                                ListISupervision_exsitu_recinto_equipo.Add(ocampoExitu);
                            }
                            if (ListISupervision_exsitu_recinto_equipo.Count > 0)
                            {
                                foreach (var row in lsCEntidad.ListAreaExsitu)
                                {
                                    ListISupervision_exsitu_recinto_equipo_temp = new List<CEntISExsitu>();
                                    row.ListISupervision_exsitu_recinto_equipo = new List<CEntISExsitu>();
                                    ListISupervision_exsitu_recinto_equipo_temp = (from p in ListISupervision_exsitu_recinto_equipo where p.COD_AREA == row.COD_AREA && p.COD_SECUENCIAL == row.COD_SECUENCIAL select p).ToList<CEntISExsitu>();
                                    num_fila = 0;
                                    if (ListISupervision_exsitu_recinto_equipo_temp.Count > 0)
                                    {
                                        foreach (var row_det in ListISupervision_exsitu_recinto_equipo_temp)
                                        {
                                            row_det.NUM_FILA = num_fila;
                                            row.ListISupervision_exsitu_recinto_equipo.Add(row_det);
                                            num_fila++;
                                        }
                                    }
                                }
                            }
                        }

                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            int pt0 = dr.GetOrdinal("COD_TDESCRIPTIVA");
                            int pt1 = dr.GetOrdinal("DESCRIPCION");
                            int pt2 = dr.GetOrdinal("TIPO_ALIMENTACION");
                            int pt3 = dr.GetOrdinal("FRECUENCIA_RACION");
                            int pt4 = dr.GetOrdinal("OBSERVACION");
                            int pt5 = dr.GetOrdinal("COD_SECUENCIAL");
                            int pt6 = dr.GetOrdinal("GRUPOESPECIE");
                            while (dr.Read())
                            {
                                ocampoExitu = new CEntISExsitu();
                                ocampoExitu.COD_TDESCRIPTIVA = dr.GetString(pt0);
                                ocampoExitu.DESCRIPCION = dr.GetString(pt1);
                                ocampoExitu.TIPO_ALIMENTACION = dr.GetString(pt2);
                                ocampoExitu.FRECUENCIA_RACION = dr.GetString(pt3);
                                ocampoExitu.OBSERVACION = dr.GetString(pt4);
                                ocampoExitu.COD_SECUENCIAL = dr.GetInt32(pt5);
                                ocampoExitu.GRUPOESPECIE = dr.GetString(pt6);
                                ocampoExitu.RegEstado = 0;
                                lsCEntidad.ListGrupoToxonomico.Add(ocampoExitu);
                            }
                        }

                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            int pt0 = dr.GetOrdinal("COD_TDESCRIPTIVA");
                            int pt1 = dr.GetOrdinal("DESCRIPCION");
                            int pt2 = dr.GetOrdinal("OBSERVACION");
                            while (dr.Read())
                            {
                                ocampoExitu = new CEntISExsitu();
                                ocampoExitu.COD_TDESCRIPTIVA = dr.GetString(pt0);
                                ocampoExitu.DESCRIPCION = dr.GetString(pt1);
                                ocampoExitu.OBSERVACION = dr.GetString(pt2);
                                ocampoExitu.RegEstado = 0;
                                lsCEntidad.ListProgManejoSanitarioFisico.Add(ocampoExitu);
                            }
                        }
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            int pt0 = dr.GetOrdinal("COD_TDESCRIPTIVA");
                            int pt1 = dr.GetOrdinal("DESCRIPCION");
                            int pt2 = dr.GetOrdinal("OBSERVACION");
                            while (dr.Read())
                            {
                                ocampoExitu = new CEntISExsitu();
                                ocampoExitu.COD_TDESCRIPTIVA = dr.GetString(pt0);
                                ocampoExitu.DESCRIPCION = dr.GetString(pt1);
                                ocampoExitu.OBSERVACION = dr.GetString(pt2);
                                ocampoExitu.RegEstado = 0;
                                lsCEntidad.ListProgManejoSanitarioQuimico.Add(ocampoExitu);
                            }
                        }
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            int pt0 = dr.GetOrdinal("COD_TDESCRIPTIVA");
                            int pt1 = dr.GetOrdinal("DESCRIPCION");
                            int pt2 = dr.GetOrdinal("OBSERVACION");

                            while (dr.Read())
                            {
                                ocampoExitu = new CEntISExsitu();
                                ocampoExitu.COD_TDESCRIPTIVA = dr.GetString(pt0);
                                ocampoExitu.DESCRIPCION = dr.GetString(pt1);
                                ocampoExitu.OBSERVACION = dr.GetString(pt2);
                                ocampoExitu.RegEstado = 0;
                                lsCEntidad.ListProgBioFrecuenciaLimpieza.Add(ocampoExitu);
                                if (ocampoExitu.COD_TDESCRIPTIVA == "0000039")
                                {
                                    lsCEntidad.chkOtrosMateriales = true;
                                    lsCEntidad.txtOtrosMateriales = dr.GetString(pt2);
                                }

                            }
                        }
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            int pt0 = dr.GetOrdinal("COD_TDESCRIPTIVA");
                            int pt1 = dr.GetOrdinal("DESCRIPCION");
                            int pt2 = dr.GetOrdinal("OBSERVACION");
                            while (dr.Read())
                            {
                                ocampoExitu = new CEntISExsitu();
                                ocampoExitu.COD_TDESCRIPTIVA = dr.GetString(pt0);
                                ocampoExitu.DESCRIPCION = dr.GetString(pt1);
                                ocampoExitu.OBSERVACION = dr.GetString(pt2);
                                ocampoExitu.RegEstado = 0;
                                lsCEntidad.ListMaterialDesinfeccion.Add(ocampoExitu);
                                if (ocampoExitu.COD_TDESCRIPTIVA == "0000056")
                                {
                                    lsCEntidad.chkOtrosMaterialesDesinf = true;
                                    lsCEntidad.txtOtrosMaterialesDesinf = dr.GetString(pt2);
                                }
                            }
                        }
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            int pt0 = dr.GetOrdinal("COD_TDESCRIPTIVA");
                            int pt1 = dr.GetOrdinal("DESCRIPCION");
                            int pt2 = dr.GetOrdinal("OBSERVACION");
                            while (dr.Read())
                            {
                                ocampoExitu = new CEntISExsitu();
                                ocampoExitu.COD_TDESCRIPTIVA = dr.GetString(pt0);
                                ocampoExitu.DESCRIPCION = dr.GetString(pt1);
                                ocampoExitu.OBSERVACION = dr.GetString(pt2);
                                ocampoExitu.RegEstado = 0;
                                lsCEntidad.ListEquipoDesinfeccion.Add(ocampoExitu);
                            }
                        }
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            int pt0 = dr.GetOrdinal("COD_TDESCRIPTIVA");
                            int pt1 = dr.GetOrdinal("DESCRIPCION");
                            int pt2 = dr.GetOrdinal("FRECUENCIA");
                            int pt3 = dr.GetOrdinal("METODO_FISICO");
                            int pt4 = dr.GetOrdinal("METODO_QUIMICO");
                            int pt5 = dr.GetOrdinal("OBSERVACION");
                            while (dr.Read())
                            {
                                ocampoExitu = new CEntISExsitu();
                                ocampoExitu.COD_TDESCRIPTIVA = dr.GetString(pt0);
                                ocampoExitu.DESCRIPCION = dr.GetString(pt1);
                                ocampoExitu.FRECUENCIA = dr.GetString(pt2);
                                ocampoExitu.METODO_FISICO = dr.GetString(pt3);
                                ocampoExitu.METODO_QUIMICO = dr.GetString(pt4);
                                ocampoExitu.OBSERVACION = dr.GetString(pt5);
                                ocampoExitu.RegEstado = 0;
                                lsCEntidad.ListCautiverioControlPlaga.Add(ocampoExitu);
                            }
                        }
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            int pt0 = dr.GetOrdinal("COD_TDESCRIPTIVA");
                            int pt1 = dr.GetOrdinal("DESCRIPCION");
                            int pt2 = dr.GetOrdinal("FECHA_ACTUALIZACION");
                            int pt3 = dr.GetOrdinal("OBSERVACION");
                            while (dr.Read())
                            {
                                ocampoExitu = new CEntISExsitu();
                                ocampoExitu.COD_TDESCRIPTIVA = dr.GetString(pt0);
                                ocampoExitu.DESCRIPCION = dr.GetString(pt1);
                                ocampoExitu.FECHA_ACTUALIZACION = dr.GetString(pt2);
                                ocampoExitu.OBSERVACION = dr.GetString(pt3);
                                ocampoExitu.RegEstado = 0;
                                lsCEntidad.LisCautiveriotManejoRegistro.Add(ocampoExitu);
                            }
                        }
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            int pt0 = dr.GetOrdinal("COD_TDESCRIPTIVA");
                            int pt1 = dr.GetOrdinal("DESCRIPCION");
                            int pt2 = dr.GetOrdinal("ACTIVIDAD_IMPLEMENTADA");
                            int pt3 = dr.GetOrdinal("MATERIAL_USADO");
                            int pt4 = dr.GetOrdinal("OBSERVACION");
                            while (dr.Read())
                            {
                                ocampoExitu = new CEntISExsitu();
                                ocampoExitu.COD_TDESCRIPTIVA = dr.GetString(pt0);
                                ocampoExitu.DESCRIPCION = dr.GetString(pt1);
                                ocampoExitu.ACTIVIDAD_IMPLEMENTADA = dr.GetString(pt2);
                                ocampoExitu.MATERIAL_USADO = dr.GetString(pt3);
                                ocampoExitu.OBSERVACION = dr.GetString(pt4);
                                ocampoExitu.RegEstado = 0;
                                lsCEntidad.LisCautiverioEnriquecAmbiental.Add(ocampoExitu);
                            }
                        }
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            int pt0 = dr.GetOrdinal("COD_ESPECIES");
                            int pt1 = dr.GetOrdinal("DESCRIPCION");
                            int pt2 = dr.GetOrdinal("COD_EORIGEN");
                            int pt3 = dr.GetOrdinal("DESC_EORIGEN");
                            int pt4 = dr.GetOrdinal("NUM_CRIAS_ANO");
                            int pt5 = dr.GetOrdinal("NUM_CRIAS_VIABLES");
                            int pt6 = dr.GetOrdinal("NUM_CRIAS_MUERTAS");
                            int pt7 = dr.GetOrdinal("FRECUENCIA_COD_TDESCRIPTIVA");
                            int pt8 = dr.GetOrdinal("FRECUENCIA_DESCRIPCION");
                            int pt9 = dr.GetOrdinal("REPRODUCCION_EPOCA");
                            int pt10 = dr.GetOrdinal("OBSERVACION");
                            while (dr.Read())
                            {
                                ocampoExitu = new CEntISExsitu();
                                ocampoExitu.COD_ESPECIES = dr.GetString(pt0);
                                ocampoExitu.DESCRIPCION = dr.GetString(pt1);
                                ocampoExitu.COD_EORIGEN = dr.GetString(pt2);
                                ocampoExitu.DESC_EORIGEN = dr.GetString(pt3);
                                ocampoExitu.NUM_CRIAS_ANO = dr.GetInt32(pt4);
                                ocampoExitu.NUM_CRIAS_VIABLES = dr.GetInt32(pt5);
                                ocampoExitu.NUM_CRIAS_MUERTAS = dr.GetInt32(pt6);
                                ocampoExitu.FRECUENCIA_COD_TDESCRIPTIVA = dr.GetString(pt7);
                                ocampoExitu.FRECUENCIA_DESCRIPCION = dr.GetString(pt8);
                                ocampoExitu.REPRODUCCION_EPOCA = dr.GetString(pt9);
                                ocampoExitu.OBSERVACION = dr.GetString(pt10);
                                ocampoExitu.RegEstado = 0;
                                lsCEntidad.LisCautiverioEspecieReproducida.Add(ocampoExitu);
                            }
                        }
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            int pt0 = dr.GetOrdinal("COD_TDESCRIPTIVA");
                            int pt1 = dr.GetOrdinal("COD_SECUENCIAL");
                            int pt2 = dr.GetOrdinal("DESCRIPCION");
                            int pt3 = dr.GetOrdinal("FECHA_EVENTO");
                            int pt4 = dr.GetOrdinal("OBSERVACION");
                            while (dr.Read())
                            {
                                ocampoExitu = new CEntISExsitu();
                                ocampoExitu.COD_TDESCRIPTIVA = dr.GetString(pt0);
                                ocampoExitu.COD_SECUENCIAL = dr.GetInt32(pt1);
                                ocampoExitu.DESCRIPCION = dr.GetString(pt2);
                                ocampoExitu.FECHA_EVENTO = dr.GetString(pt3);
                                ocampoExitu.OBSERVACION = dr.GetString(pt4);
                                ocampoExitu.RegEstado = 0;
                                lsCEntidad.LisCautiverioActividadRealizada.Add(ocampoExitu);
                            }
                        }
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            ListISupervision_exsitu_recinto_equipo_temp = new List<CEntISExsitu>();
                            int pt0 = dr.GetOrdinal("COD_TDESCRIPTIVA");
                            int pt1 = dr.GetOrdinal("COD_SECUENCIAL");
                            int pt2 = dr.GetOrdinal("POBJETIVO_COD_TDESCRIPTIVA");
                            int pt3 = dr.GetOrdinal("DESCRIPCION");
                            while (dr.Read())
                            {
                                ocampoExitu = new CEntISExsitu();
                                ocampoExitu.COD_TDESCRIPTIVA = dr.GetString(pt0);
                                ocampoExitu.COD_SECUENCIAL = dr.GetInt32(pt1);
                                ocampoExitu.POBJETIVO_COD_TDESCRIPTIVA = dr.GetString(pt2);
                                ocampoExitu.DESCRIPCION = dr.GetString(pt3);
                                ocampoExitu.RegEstado = 0;
                                ListISupervision_exsitu_recinto_equipo_temp.Add(ocampoExitu);
                            }
                            if (lsCEntidad.LisCautiverioActividadRealizada != null)
                            {
                                foreach (var fila_det in lsCEntidad.LisCautiverioActividadRealizada)
                                {
                                    fila_det.ListISupervision_exsitu_recinto_equipo = new List<CEntISExsitu>();
                                    fila_det.ListISupervision_exsitu_recinto_equipo = (from p in ListISupervision_exsitu_recinto_equipo_temp where p.COD_TDESCRIPTIVA == fila_det.COD_TDESCRIPTIVA && p.COD_SECUENCIAL == fila_det.COD_SECUENCIAL select p).ToList<CEntISExsitu>();
                                }
                            }
                        }
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("COD_SECUENCIAL");
                            int pt2 = dr.GetOrdinal("PUBLICADO");
                            int pt3 = dr.GetOrdinal("FECHA_PUBLICACION");
                            int pt4 = dr.GetOrdinal("INVESTIGACION_REALIZADA");
                            int pt5 = dr.GetOrdinal("OBJETIVO");
                            while (dr.Read())
                            {
                                ocampoExitu = new CEntISExsitu();
                                ocampoExitu.COD_SECUENCIAL = dr.GetInt32(pt1);
                                ocampoExitu.PUBLICADO = dr.GetBoolean(pt2);
                                ocampoExitu.FECHA_PUBLICACION = dr.GetString(pt3);
                                ocampoExitu.INVESTIGACION_REALIZADA = dr.GetString(pt4);
                                ocampoExitu.OBJETIVO = dr.GetString(pt5);
                                ocampoExitu.RegEstado = 0;
                                lsCEntidad.LisCautiverioCensoICientifica.Add(ocampoExitu);
                            }
                        }
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("COD_SECUENCIAL");
                            int pt2 = dr.GetOrdinal("COD_ESPECIES");
                            int pt21 = dr.GetOrdinal("DESCRIPCION");
                            int pt3 = dr.GetOrdinal("NUM_ICAPTURADOS");
                            int pt4 = dr.GetOrdinal("ZONA_CAPTURA");
                            int pt5 = dr.GetOrdinal("OBSERVACION");
                            while (dr.Read())
                            {
                                ocampoExitu = new CEntISExsitu();
                                ocampoExitu.COD_SECUENCIAL = dr.GetInt32(pt1);
                                ocampoExitu.COD_ESPECIES = dr.GetString(pt2);
                                ocampoExitu.DESCRIPCION = dr.GetString(pt21);
                                ocampoExitu.NUM_ICAPTURADOS = dr.GetInt32(pt3);
                                ocampoExitu.ZONA_CAPTURA = dr.GetString(pt4);
                                ocampoExitu.OBSERVACION = dr.GetString(pt5);
                                ocampoExitu.RegEstado = 0;
                                lsCEntidad.LisCautiverioECapturado.Add(ocampoExitu);
                            }
                        }
                        //CAPACITACIONES FAUNA
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("COD_EXSITUCAPACITACION");
                            int pt2 = dr.GetOrdinal("TEMA");
                            int pt3 = dr.GetOrdinal("NUM_BENEFICIADOS");
                            int pt4 = dr.GetOrdinal("CAPACITADOR");
                            while (dr.Read())
                            {
                                ocampoExitu = new CEntISExsitu();
                                ocampoExitu.COD_EXSITUCAPACITACION = dr.GetString(pt1);
                                ocampoExitu.TEMA = dr.GetString(pt2);
                                ocampoExitu.NUM_BENEFICIADOS = dr.GetInt32(pt3);
                                ocampoExitu.CAPACITADOR = dr.GetString(pt4);
                                ocampoExitu.RegEstado = 0;
                                lsCEntidad.LisCapacitacionFauna.Add(ocampoExitu);
                            }
                        }
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("COD_SECUENCIAL");
                            int pt2 = dr.GetOrdinal("TIPO_VERTEBRADO");
                            int pt3 = dr.GetOrdinal("COD_ESPECIES");
                            int pt4 = dr.GetOrdinal("DESCRIPCION");
                            int pt5 = dr.GetOrdinal("PROCEDENCIA_COD_TDESCRIPTIVA");
                            int pt51 = dr.GetOrdinal("DESC_PROCEDENCIA");
                            int pt6 = dr.GetOrdinal("PROCEDENCIA_NUM_INDIVIDUOS");
                            int pt7 = dr.GetOrdinal("TIDENTI_COD_TDESCRIPTIVA");
                            int pt8 = dr.GetOrdinal("DESC_TIDENTIFICACION");
                            int pt9 = dr.GetOrdinal("CODIGO_NOMBRE");
                            int pt10 = dr.GetOrdinal("COD_SEXO");
                            int pt11 = dr.GetOrdinal("SEXO");
                            int pt12 = dr.GetOrdinal("COD_ACATEGORIA");
                            int pt13 = dr.GetOrdinal("DESC_ACATEGORIA");
                            int pt14 = dr.GetOrdinal("OBSERVACION");
                            num_fila = 0;
                            while (dr.Read())
                            {
                                ocampoExitu = new CEntISExsitu();
                                ocampoExitu.COD_SECUENCIAL = dr.GetInt32(pt1);
                                ocampoExitu.TIPO_VERTEBRADO = dr.GetString(pt2);
                                ocampoExitu.COD_ESPECIES = dr.GetString(pt3);
                                ocampoExitu.DESCRIPCION = dr.GetString(pt4);
                                ocampoExitu.PROCEDENCIA_COD_TDESCRIPTIVA = dr.GetString(pt5);
                                ocampoExitu.DESC_PROCEDENCIA = dr.GetString(pt51);
                                ocampoExitu.PROCEDENCIA_NUM_INDIVIDUOS = dr.GetInt32(pt6);
                                ocampoExitu.TIDENTI_COD_TDESCRIPTIVA = dr.GetString(pt7);
                                ocampoExitu.DESC_TIDENTIFICACION = dr.GetString(pt8);
                                ocampoExitu.CODIGO_NOMBRE = dr.GetString(pt9);
                                ocampoExitu.COD_SEXO = dr.GetString(pt10);
                                ocampoExitu.SEXO = dr.GetString(pt11);
                                ocampoExitu.COD_ACATEGORIA = dr.GetString(pt12);
                                ocampoExitu.DESC_ACATEGORIA = dr.GetString(pt13);
                                ocampoExitu.OBSERVACION = dr.GetString(pt14);
                                ocampoExitu.NUM_FILA = num_fila;
                                ocampoExitu.RegEstado = 0;
                                lsCEntidad.LisCautiverioCensoVertebrado.Add(ocampoExitu);
                                num_fila++;
                            }
                        }
                        // INFORME FOTOS
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                CEntidad ocampo = new CEntidad();
                                ocampo.COD_INFORME_FOTOS = dr["COD_INFORME_FOTOS"].ToString();
                                ocampo.COD_INFORME = dr["COD_INFORME"].ToString();
                                ocampo.COD_THABILITANTE = dr["COD_THABILITANTE"].ToString();
                                ocampo.COD_UCUENTA = dr["COD_UCUENTA"].ToString();
                                ocampo.USUARIO_REGISTRO = dr["USUARIO_REGISTRO"].ToString();
                                ocampo.URL_FOTO = dr["URL_FOTO"].ToString();
                                ocampo.DESC_FOTO = dr["DESCRIPCION"].ToString();
                                ocampo.FUENTE_FOTO = dr["FUENTE"].ToString();
                                ocampo.DISP_FOTO = dr["DISPOSITIVO"].ToString();
                                ocampo.NUMERO = lsCEntidad.NUMERO;
                                ocampo.NUM_THABILITANTE = lsCEntidad.NUM_THABILITANTE;
                                ocampo.FECHA = dr["FECHA"].ToString();
                                ocampo.RegEstado = 0;
                                lsCEntidad.ListFotos.Add(ocampo);
                            }
                        }
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                ocampoExitu = new CEntISExsitu();
                                ocampoExitu.COD_SECUENCIAL = Int32.Parse(dr["COD_SECUENCIAL"].ToString());
                                ocampoExitu.COD_ESPECIES = dr["COD_ESPECIES"].ToString();
                                ocampoExitu.NOMBRE_COMUN = dr["NOM_ESPECIE"].ToString();
                                ocampoExitu.COD_SEXO = dr["COD_SEXO"].ToString();
                                ocampoExitu.SEXO = dr["SEXO"].ToString();
                                ocampoExitu.NUMERO = dr["NUMERO"].ToString();
                                ocampoExitu.DESCRIPCION = dr["DOCUMENTO"].ToString();
                                ocampoExitu.OBJETIVO = dr["PROGRAMA"].ToString();
                                ocampoExitu.OBSERVACION = dr["OBSERVACIONES"].ToString();
                                ocampoExitu.FECHA_PUBLICACION = dr["FECHA"].ToString();
                                ocampoExitu.RegEstado = 0;
                                lsCEntidad.ListNacimientosEspecies.Add(ocampoExitu);
                            }
                        }
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                ocampoExitu = new CEntISExsitu();
                                ocampoExitu.COD_SECUENCIAL = Int32.Parse(dr["COD_SECUENCIAL"].ToString());
                                ocampoExitu.COD_ESPECIES = dr["COD_ESPECIES"].ToString();
                                ocampoExitu.NOMBRE_COMUN = dr["NOM_ESPECIE"].ToString();
                                ocampoExitu.COD_SEXO = dr["COD_SEXO"].ToString();
                                ocampoExitu.SEXO = dr["SEXO"].ToString();
                                ocampoExitu.NUMERO = dr["NUMERO"].ToString();
                                ocampoExitu.FECHA_PUBLICACION = dr["FECHA"].ToString();
                                ocampoExitu.DOCUMENTO = dr["DOCUMENTO"].ToString();
                                ocampoExitu.COD_MOTIVO = dr["COD_MOTIVO"].ToString();
                                ocampoExitu.MOTIVO = dr["MOTIVO"].ToString();
                                ocampoExitu.NECROPSIA = dr["NECROPSIA"].ToString();
                                ocampoExitu.DIAGNOSTICO = dr["DIAGNOSTICO"].ToString();
                                ocampoExitu.EDAD = dr["EDAD"].ToString();
                                ocampoExitu.CODIGO_NOMBRE = dr["CODIGO"].ToString();
                                ocampoExitu.OBSERVACION = dr["OBSERVACIONES"].ToString();
                                ocampoExitu.RegEstado = 0;
                                lsCEntidad.ListEgresosEspecies.Add(ocampoExitu);
                            }
                        }
                        #region ListDesplazamientoInforme
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            CEntidad ocampo;
                            while (dr.Read())
                            {
                                ocampo = new CEntidad();
                                ocampo.COD_DESPLAZAMIENTO = dr["COD_DESPLAZAMIENTO"].ToString();
                                ocampo.ZONA = dr["PTOI_ZONA_UTM"].ToString();
                                ocampo.COORDENADA_ESTE = Int32.Parse(dr["PTOI_COORDENADA_ESTE"].ToString());
                                ocampo.COORDENADA_NORTE = Int32.Parse(dr["PTOI_COORDENADA_NORTE"].ToString());
                                ocampo.ZONA_CAMPO = dr["PTOF_ZONA_UTM"].ToString();
                                ocampo.COORDENADA_ESTE_CAMPO = Int32.Parse(dr["PTOF_COORDENADA_ESTE"].ToString());
                                ocampo.COORDENADA_NORTE_CAMPO = Int32.Parse(dr["PTOF_COORDENADA_NORTE"].ToString());
                                ocampo.OBSERVACION = dr["OBSERVACION"].ToString();
                                ocampo.TipoVia = dr["TIPO"].ToString();
                                ocampo.RegEstado = 0;
                                lsCEntidad.ListDesplazamientoInforme.Add(ocampo);
                            }
                        }
                        #endregion
                        #region ListISuperExsituBalance
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                CapaEntidad.DOC.Ent_ISUPERVISION_EXSITU_INFRA_AREA ocampoEnt = new CapaEntidad.DOC.Ent_ISUPERVISION_EXSITU_INFRA_AREA();


                                ocampoEnt.COD_BALANCE = dr["COD_BALANCE"].ToString();
                                ocampoEnt.COD_ESPECIES = dr["COD_ESPECIES"].ToString();
                                ocampoEnt.CENSO_INICIAL = Int32.Parse(dr["CENSO_INICIAL"].ToString());
                                ocampoEnt.CANT_INGRESO = Int32.Parse(dr["CANT_INGRESO"].ToString());
                                ocampoEnt.FECHA_INGRESO = dr["FECHA_INGRESO"].ToString();
                                ocampoEnt.DOCUMENTO_INGRESO = dr["DOCUMENTO_INGRESO"].ToString();
                                ocampoEnt.MOTIVO_INGRESO = dr["MOTIVO_INGRESO"].ToString();
                                ocampoEnt.OBSERV_INGRESO = dr["OBSERV_INGRESO"].ToString();
                                ocampoEnt.CANT_EGRESO = Int32.Parse(dr["CANT_EGRESO"].ToString());
                                ocampoEnt.FECHA_EGRESO = dr["FECHA_EGRESO"].ToString();
                                ocampoEnt.DOCUMENTO_EGRESO = dr["DOCUMENTO_EGRESO"].ToString();
                                ocampoEnt.MOTIVO_EGRESO = dr["MOTIVO_EGRESO"].ToString();
                                ocampoEnt.OBSERV_EGRESO = dr["OBSERV_EGRESO"].ToString();
                                ocampoEnt.BALANCE_PREVIO = Int32.Parse(dr["BALANCE_PREVIO"].ToString());
                                ocampoEnt.CENSO_FINAL = Int32.Parse(dr["CENSO_FINAL"].ToString());
                                ocampoEnt.NOMBRE_COMUN = dr["NOMBRE_COMUN"].ToString();
                                ocampoEnt.RegEstado = 0;
                                lsCEntidad.ListISuperExsituBalance.Add(ocampoEnt);
                            }
                        }
                        #endregion
                        #region Obligaciones
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            //CapaEntidad.DOC.Ent_INFORME_OBLIGTITULAR ocampooblig;
                            while (dr.Read())
                            {
                                CapaEntidad.DOC.Ent_ISUPERVISION_EXSITU_INFRA_AREA ocampoEnt = new CapaEntidad.DOC.Ent_ISUPERVISION_EXSITU_INFRA_AREA();
                                ocampoEnt.COD_INFORME = dr["COD_INFORME"].ToString();
                                ocampoEnt.MAE_OBLIGTITULAR = dr["MAE_OBLIGTITULAR"].ToString();
                                ocampoEnt.CODIGO_NOMBRE = dr["DESC_OBLIG"].ToString();
                                ocampoEnt.EVAL_OBLIGTITULAR = dr["EVAL_OBLIGTITULAR"].ToString();
                                ocampoEnt.OBSERVACION_OBLIG = dr["OBSERVACION_OBLIG"].ToString();
                                ocampoEnt.RegEstado = 0;
                                lsCEntidad.ListISuperExsituOBLIGF.Add(ocampoEnt);
                                //ocampooblig = new CapaEntidad.DOC.Ent_INFORME_OBLIGTITULAR();
                                //ocampooblig.COD_OBLIGTITULAR = dr["COD_OBLIGTITULAR"].ToString();
                                //ocampooblig.OBLIGTITULAR = dr["OBLIGTITULAR"].ToString();
                                //ocampooblig.EVAL_OBLIGTITULAR = dr["EVAL_OBLIGTITULAR"].ToString();
                                //ocampooblig.OBSERVACION = dr["OBSERVACION"].ToString();
                                //ocampooblig.COD_GRUPO = dr["COD_GRUPO"].ToString();
                                //lsCEntidad.ListObligacionTitular.Add(ocampooblig);
                            }
                        }
                        #endregion
                        #region ListEvalZoObservatorio
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                CapaEntidad.DOC.Ent_ISUPERVISION_EXSITU_CAUTI_EVALZOO ocampoEnt = new CapaEntidad.DOC.Ent_ISUPERVISION_EXSITU_CAUTI_EVALZOO();
                                ocampoEnt.COD_SECUENCIAL = Int32.Parse(dr["COD_SECUENCIAL"].ToString());
                                ocampoEnt.MAE_CRITERIO_EVALZOO = dr["MAE_CRITERIO_EVALZOO"].ToString();
                                ocampoEnt.CRITERIO_EVALZOO = dr["CRITERIO_EVALZOO"].ToString();
                                ocampoEnt.CALIFICACION = dr["CALIFICACION"].ToString();
                                ocampoEnt.OBSERVACION = dr["OBSERVACION"].ToString();
                                ocampoEnt.RegEstado = 0;
                                lsCEntidad.ListEvalZoObservatorio.Add(ocampoEnt);
                            }
                        }
                        #endregion

                        #region ListPersonalTecProf
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            int pt0 = dr.GetOrdinal("COD_PERSONALTECPROF");
                            int pt1 = dr.GetOrdinal("NOMBRES");
                            int pt2 = dr.GetOrdinal("TIPO");
                            int pt3 = dr.GetOrdinal("OTRO");

                            while (dr.Read())
                            {
                                ocampoPersona = new CEntPersona();
                                ocampoPersona.COD_PERSONALTECPROF = dr.GetString(pt0);
                                ocampoPersona.NOMBRES = dr.GetString(pt1);
                                ocampoPersona.TIPO = dr.GetString(pt2);
                                ocampoPersona.OTRO = dr.GetString(pt3);
                                ocampoPersona.RegEstado = 0;
                                lsCEntidad.ListPersonalTecProf.Add(ocampoPersona);
                            }
                        }
                        #endregion

                        #region ListRelPelCentroCria
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            int pt0 = dr.GetOrdinal("COD_RELPELCENTROCRIA");
                            int pt1 = dr.GetOrdinal("NOMBRES");
                            int pt2 = dr.GetOrdinal("CARGO");

                            while (dr.Read())
                            {
                                ocampoPersona = new CEntPersona();
                                ocampoPersona.COD_RELPELCENTROCRIA = dr.GetString(pt0);
                                ocampoPersona.NOMBRES = dr.GetString(pt1);
                                ocampoPersona.CARGO = dr.GetString(pt2);
                                ocampoPersona.RegEstado = 0;
                                lsCEntidad.ListRelPelCentroCria.Add(ocampoPersona);
                            }
                        }
                        #endregion

                    }
                    return lsCEntidad;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //INFORME TARA
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public String RegITaraInsertar(OracleConnection cn, CEntidad oCEntidad)
        {
            OracleTransaction tr = null;
            String OUTPUTPARAM01 = "";
            CEntidad ocampoSuper;
            CEntPersona ocampoPersona;
            try
            {
                tr = cn.BeginTransaction();
                //Grabando Cabecera
                using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.INFORME_TARA_Grabar", oCEntidad))
                {
                    cmd.ExecuteNonQuery();
                    OUTPUTPARAM01 = (String)cmd.Parameters["OUTPUTPARAM01"].Value;
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
                        throw new Exception("El Número de Informe ya Existe");
                    }
                    else if (OUTPUTPARAM01 == "1")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("El Número del Titulo Habilitante Existe en otro Registro");
                    }
                    else if (OUTPUTPARAM01 == "2")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("No Tiene Permisos para Modificar este Informe");
                    }
                    else if (OUTPUTPARAM01 == "3")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("Está con Control de Calidad, no puede modificar");
                    }
                }
                //
                //Eliminando Detalle Informe
                if (oCEntidad.ListEliTABLA != null)
                {
                    foreach (var loDatos in oCEntidad.ListEliTABLA)
                    {
                        ocampoSuper = new CEntidad();
                        ocampoSuper.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                        ocampoSuper.EliTABLA = loDatos.EliTABLA;
                        ocampoSuper.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                        ocampoSuper.COD_PERSONA = loDatos.COD_PERSONA;
                        ocampoSuper.EliVALOR01 = loDatos.EliVALOR01;
                        dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spINFORME_TARAEliminarDet", ocampoSuper);
                    }
                }
                //
                if (oCEntidad.ListInformeDetSupervisor != null)
                {
                    foreach (var loDatos in oCEntidad.ListInformeDetSupervisor)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            ocampoPersona = new CEntPersona();
                            ocampoPersona.COD_PERSONA = loDatos.COD_PERSONA;
                            ocampoPersona.CODIGO = OUTPUTPARAM01.Split('|')[0];
                            ocampoPersona.COD_DIDENTIDAD = loDatos.COD_DIDENTIDAD;
                            ocampoPersona.APE_PATERNO = loDatos.APE_PATERNO;
                            ocampoPersona.APE_MATERNO = loDatos.APE_MATERNO;
                            ocampoPersona.NOMBRES = loDatos.NOMBRES;
                            ocampoPersona.N_DOCUMENTO = loDatos.N_DOCUMENTO;
                            ocampoPersona.N_RUC = loDatos.N_RUC;
                            ocampoPersona.COD_PTIPO = loDatos.COD_PTIPO;
                            ocampoPersona.COLEGIATURA_NUM = loDatos.COLEGIATURA_NUM;
                            ocampoPersona.COD_DPESPECIALIDAD = loDatos.COD_DPESPECIALIDAD;
                            ocampoPersona.COD_NACADEMICO = loDatos.COD_NACADEMICO;
                            ocampoPersona.CARGO = loDatos.CARGO;
                            ocampoPersona.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.INFORME_DET_SUPERVISOR_Grabar", ocampoPersona);
                        }
                    }
                }
                // MANTENIMIENTO DE PLANTACIONES
                if (oCEntidad.ListISUPERVISION_DET_TARA_CONCEPTO != null)
                {
                    foreach (var loDatos in oCEntidad.ListISUPERVISION_DET_TARA_CONCEPTO)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            ocampoSuper = new CEntidad();
                            ocampoSuper.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            ocampoSuper.COD_TCONCEPTO = loDatos.COD_TCONCEPTO;
                            ocampoSuper.ESTADO_MPLANTACION = loDatos.ESTADO_MPLANTACION;
                            ocampoSuper.OBSERVACION = loDatos.OBSERVACION;
                            ocampoSuper.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.INFORME_TARA_DET_CONCEPTO_Grabar", ocampoSuper);
                        }
                    }
                }
                // REGISTRO DE ARBOLES SUPERVISADO
                if (oCEntidad.ListISUPERVISION_DET_TARA_CENSO != null)
                {
                    foreach (var loDatos in oCEntidad.ListISUPERVISION_DET_TARA_CENSO)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            ocampoSuper = new CEntidad();
                            ocampoSuper.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            ocampoSuper.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            ocampoSuper.PREDIO_AREA = loDatos.PREDIO_AREA;
                            ocampoSuper.CODIGO_ARBOL = loDatos.CODIGO_ARBOL;
                            ocampoSuper.VAINAS_COD_PRESENCIA = loDatos.VAINAS_COD_PRESENCIA;
                            ocampoSuper.PRES_FLORES = loDatos.PRES_FLORES;
                            ocampoSuper.PRES_PLAGA_ENFERMEDA = loDatos.PRES_PLAGA_ENFERMEDA;
                            ocampoSuper.PRES_PLANTA_PARASITARIA = loDatos.PRES_PLANTA_PARASITARIA;
                            ocampoSuper.COORDENADA_NORTE = loDatos.COORDENADA_NORTE;
                            ocampoSuper.COORDENADA_ESTE = loDatos.COORDENADA_ESTE;
                            ocampoSuper.ALTURA_TOTAL = loDatos.ALTURA_TOTAL;
                            ocampoSuper.OBSERVACION = loDatos.OBSERVACION;
                            ocampoSuper.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.ISUPERVISION_TARA_DET_CENSO_Grabar", ocampoSuper);
                        }
                    }
                }
                // REGISTRO DE ARBOLES SUPERVISADO
                if (oCEntidad.ListISUPERVISION_DET_TARA_APROV != null)
                {
                    foreach (var loDatos in oCEntidad.ListISUPERVISION_DET_TARA_APROV)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            ocampoSuper = new CEntidad();
                            ocampoSuper.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            ocampoSuper.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            ocampoSuper.PREDIO_AREA = loDatos.PREDIO_AREA;
                            ocampoSuper.N_ARBOL_SUPERVISADO = loDatos.N_ARBOL_SUPERVISADO;
                            ocampoSuper.N_ARBOL_FVERDE = loDatos.N_ARBOL_FVERDE;
                            ocampoSuper.N_ARBOL_FVERDE_MADURO = loDatos.N_ARBOL_FVERDE_MADURO;
                            ocampoSuper.N_ARBOL_FLOR = loDatos.N_ARBOL_FLOR;
                            ocampoSuper.N_ARBOL_NOFRUTO = loDatos.N_ARBOL_NOFRUTO;
                            ocampoSuper.OBSERVACION = loDatos.OBSERVACION;
                            ocampoSuper.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.ISUPERVISION_TARA_DET_APROV_Grabar", ocampoSuper);
                        }
                    }
                }
                // KARDEX
                if (oCEntidad.ListISUPERVISION_DET_TARA_KARDEX != null)
                {
                    foreach (var loDatos in oCEntidad.ListISUPERVISION_DET_TARA_KARDEX)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            ocampoSuper = new CEntidad();
                            ocampoSuper.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            ocampoSuper.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            ocampoSuper.N_GUIA_TRANSPORTE = loDatos.N_GUIA_TRANSPORTE;
                            ocampoSuper.ZAFRA = loDatos.ZAFRA;
                            ocampoSuper.FECHA_EMISION = loDatos.FECHA_EMISION;
                            ocampoSuper.CANTIDAD_AQUINTAL = loDatos.CANTIDAD_AQUINTAL;
                            ocampoSuper.TOTAL_SQUINTAL = loDatos.TOTAL_SQUINTAL;
                            ocampoSuper.SALDO_QUINTAL = loDatos.SALDO_QUINTAL;
                            ocampoSuper.SALDO_MTRES = loDatos.SALDO_MTRES;
                            ocampoSuper.DESTINO_COD_UBIGEO = loDatos.DESTINO_COD_UBIGEO;
                            ocampoSuper.UBIGEO = loDatos.UBIGEO;
                            ocampoSuper.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.ISUPERVISION_TARA_DET_KARDEX_Grabar", ocampoSuper);
                        }
                    }
                }
                // promedio de frutos de tara
                if (oCEntidad.ListISUPERVISION_DET_TARA_PFRUTOS != null)
                {
                    foreach (var loDatos in oCEntidad.ListISUPERVISION_DET_TARA_PFRUTOS)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            ocampoSuper = new CEntidad();
                            ocampoSuper.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            ocampoSuper.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            ocampoSuper.PREDIO_AREA = loDatos.PREDIO_AREA;
                            ocampoSuper.PRIMERA_COSECHA = loDatos.PRIMERA_COSECHA;
                            ocampoSuper.SEGUNDA_COSECHA = loDatos.SEGUNDA_COSECHA;
                            ocampoSuper.TOTAL_PROD_ANUAL = loDatos.TOTAL_PROD_ANUAL;
                            ocampoSuper.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.ISUPERVISION_TARA_DET_PFRUTOS_Grabar", ocampoSuper);
                        }
                    }
                }
                // aprovechamiento forestañ
                if (oCEntidad.ListISUPERVISION_DET_TARA_APFORESTAL != null)
                {
                    foreach (var loDatos in oCEntidad.ListISUPERVISION_DET_TARA_APFORESTAL)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            ocampoSuper = new CEntidad();
                            ocampoSuper.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            ocampoSuper.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            ocampoSuper.PREDIO_AREA = loDatos.PREDIO_AREA;
                            ocampoSuper.ZAFRA = loDatos.ZAFRA;
                            ocampoSuper.P_ARBOL_PRODUCTIVO = loDatos.P_ARBOL_PRODUCTIVO;
                            ocampoSuper.P_ARBOL_NOPRODUCTIVO = loDatos.P_ARBOL_NOPRODUCTIVO;
                            ocampoSuper.P_ARBOL_PLANTADO = loDatos.P_ARBOL_PLANTADO;
                            ocampoSuper.CANTIDAD_AEXTRAER = loDatos.CANTIDAD_AEXTRAER;
                            ocampoSuper.CANTIDAD_EXTRAIDA = loDatos.CANTIDAD_EXTRAIDA;
                            ocampoSuper.N_ARBOL_SUPERVISADO = loDatos.N_ARBOL_SUPERVISADO;
                            ocampoSuper.CANTIDAD_SUPERVISADO = loDatos.CANTIDAD_SUPERVISADO;
                            ocampoSuper.CANTIDAD_INJUSTIFICADA = loDatos.CANTIDAD_INJUSTIFICADA;
                            ocampoSuper.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.ISUPERVISION_TARA_DET_APFORESTAL_Grabar", ocampoSuper);
                        }
                    }
                }
                if (oCEntidad.ListISUPERVISION_DET_TARA_CONCEPTO_OTROS != null)
                {
                    foreach (var loDatos in oCEntidad.ListISUPERVISION_DET_TARA_CONCEPTO_OTROS)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            ocampoSuper = new CEntidad();
                            ocampoSuper.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            ocampoSuper.COD_TCONCEPTO = loDatos.COD_TCONCEPTO;
                            ocampoSuper.ESTADO_MPLANTACION = loDatos.ESTADO_MPLANTACION;
                            ocampoSuper.OBSERVACION = loDatos.OBSERVACION;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.INFORME_TARA_DET_CONCEPTO_Grabar_Otros", ocampoSuper);
                        }
                    }
                }
                //Registro de DESPLAZAMIENTO
                if (oCEntidad.ListDesplazamientoInforme != null)
                {
                    foreach (var loDatos in oCEntidad.ListDesplazamientoInforme)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            CEntidad ocampo = new CEntidad();
                            ocampo.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            if (loDatos.COD_DESPLAZAMIENTO == null)
                            {
                                ocampo.COD_DESPLAZAMIENTO = "";
                            }
                            else
                            {
                                ocampo.COD_DESPLAZAMIENTO = loDatos.COD_DESPLAZAMIENTO;
                            }
                            ocampo.ZONA = loDatos.ZONA ?? "";
                            ocampo.PTOI_COORDENADA_ESTE = loDatos.COORDENADA_ESTE;
                            ocampo.PTOI_COORDENADA_NORTE = loDatos.COORDENADA_NORTE;
                            ocampo.ZONA_CAMPO = loDatos.ZONA_CAMPO ?? "";
                            ocampo.PTOF_COORDENADA_ESTE = loDatos.COORDENADA_ESTE_CAMPO;
                            ocampo.PTOF_COORDENADA_NORTE = loDatos.COORDENADA_NORTE_CAMPO;
                            ocampo.OBSERVACION = loDatos.OBSERVACION;
                            ocampo.TIPO = loDatos.TipoVia;
                            ocampo.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spINFORME_DESPLAZAMIENTOGrabar", ocampo);
                        }
                    }
                }
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public CEntidad RegITaraMostrarListaItem(OracleConnection cn, CEntidad oCEntidad)
        {
            CEntidad lsCEntidad = new CEntidad();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spINFORME_TARAMostrarItem", oCEntidad))
                {
                    if (dr != null)
                    {
                        lsCEntidad.ListInformeDetSupervisor = new List<CEntPersona>();
                        lsCEntidad.ListISUPERVISION_DET_TARA_CONCEPTO = new List<CEntidad>();
                        lsCEntidad.ListISUPERVISION_DET_TARA_CENSO = new List<CEntidad>();
                        lsCEntidad.ListISUPERVISION_DET_TARA_APROV = new List<CEntidad>();
                        lsCEntidad.ListISUPERVISION_DET_TARA_KARDEX = new List<CEntidad>();
                        lsCEntidad.ListISUPERVISION_DET_TARA_PFRUTOS = new List<CEntidad>();
                        lsCEntidad.ListISUPERVISION_DET_TARA_APFORESTAL = new List<CEntidad>();
                        lsCEntidad.ListISUPERVISION_DET_TARA_CAPACITACION = new List<CEntidad>();
                        lsCEntidad.ListISUPERVISION_DET_TARA_CONCEPTO_OTROS = new List<CEntidad>();
                        lsCEntidad.ListDesplazamientoInforme = new List<CEntidad>();

                        //CEntPresupSuper ocampodet;
                        CEntidad ocampoEnt;
                        CEntPersona ocampoPersona;
                        if (dr.HasRows)
                        {
                            dr.Read();
                            lsCEntidad.COD_CNOTIFICACION = dr.GetString(dr.GetOrdinal("COD_CNOTIFICACION"));
                            lsCEntidad.NUMERO = dr.GetString(dr.GetOrdinal("NUMERO"));
                            lsCEntidad.COD_DIRECTOR = dr.GetString(dr.GetOrdinal("COD_DIRECTOR"));
                            lsCEntidad.NOMBRE_DIRECTOR = dr.GetString(dr.GetOrdinal("APELLIDOS_NOMBRES"));
                            lsCEntidad.COD_IMOTIVO = dr.GetString(dr.GetOrdinal("COD_IMOTIVO"));
                            lsCEntidad.FECHA_ENTREGA = dr.GetString(dr.GetOrdinal("FECHA_ENTREGA"));
                            //lsCEntidad.FECHA_RECEPCION_OD = dr.GetString(dr.GetOrdinal("FECHA_RECEPCION_OD"));
                            //lsCEntidad.FECHA_RECEPCION_SCENTRAL = dr.GetString(dr.GetOrdinal("FECHA_RECEPCION_SCENTRAL"));
                            lsCEntidad.UBIGEO = dr.GetString(dr.GetOrdinal("UBIGEO"));
                            lsCEntidad.THABILITANTE_SECTOR = dr.GetString(dr.GetOrdinal("THABILITANTE_SECTOR"));
                            lsCEntidad.THABILITANTE_COD_UBIGEO = dr.GetString(dr.GetOrdinal("THABILITANTE_COD_UBIGEO"));
                            lsCEntidad.FECHA_SUPERVISION_INICIO = dr.GetString(dr.GetOrdinal("FECHA_SUPERVISION_INICIO"));
                            lsCEntidad.FECHA_SUPERVISION_FIN = dr.GetString(dr.GetOrdinal("FECHA_SUPERVISION_FIN"));
                            lsCEntidad.ANTECEDENTE = dr.GetString(dr.GetOrdinal("ANTECEDENTE"));
                            lsCEntidad.OBJETIVO = dr.GetString(dr.GetOrdinal("OBJETIVO"));
                            lsCEntidad.EQUIPOS_MATERIALES = dr.GetString(dr.GetOrdinal("EQUIPOS_MATERIALES"));
                            lsCEntidad.METODOLOGIA = dr.GetString(dr.GetOrdinal("METODOLOGIA"));
                            lsCEntidad.MAPAS_CINFORMACION = dr.GetString(dr.GetOrdinal("MAPAS_CINFORMACION"));
                            lsCEntidad.ESTADO_MAPAS_CINFORMACION = dr.GetBoolean(dr.GetOrdinal("ESTADO_MAPAS_CINFORMACION"));
                            lsCEntidad.ESTAB_AREA_MANEJO = dr.GetString(dr.GetOrdinal("ESTAB_AREA_MANEJO"));
                            lsCEntidad.ESTAB_PLANTACION = dr.GetString(dr.GetOrdinal("ESTAB_PLANTACION"));
                            lsCEntidad.EXISTEN_FOREST_REFOREST = dr.GetBoolean(dr.GetOrdinal("EXISTEN_FOREST_REFOREST"));
                            lsCEntidad.OBSERV_FOREST_REFOREST = dr.GetString(dr.GetOrdinal("OBSERV_FOREST_REFOREST"));
                            lsCEntidad.COD_PPLANTON = dr.GetInt32(dr.GetOrdinal("COD_PPLANTON"));
                            lsCEntidad.OBSERV_PROD_PLANTONES = dr.GetString(dr.GetOrdinal("OBSERV_PROD_PLANTONES"));
                            lsCEntidad.COMERCIALIZACION = dr.GetString(dr.GetOrdinal("COMERCIALIZACION"));
                            lsCEntidad.ANALISIS_RACERVO = dr.GetString(dr.GetOrdinal("ANALISIS_RACERVO"));
                            lsCEntidad.CONCLUSION = dr.GetString(dr.GetOrdinal("CONCLUSION"));
                            lsCEntidad.RECOMENDACION = dr.GetString(dr.GetOrdinal("RECOMENDACION"));
                            lsCEntidad.COD_OD_REGISTRO = dr.GetString(dr.GetOrdinal("COD_OD_REGISTRO"));
                            lsCEntidad.ID_TRAMITE_SITD = dr.GetInt32(dr.GetOrdinal("ID_TRAMITE_SITD"));
                            lsCEntidad.PROMOVIDO = dr.GetBoolean(dr.GetOrdinal("PROMOVIDO"));
                            lsCEntidad.COD_ESTADO_DOC = dr.GetString(dr.GetOrdinal("COD_ESTADO_DOC"));
                            lsCEntidad.OBSERVACIONES_CONTROL = dr.GetString(dr.GetOrdinal("OBSERVACIONES_CONTROL"));
                            lsCEntidad.OBSERV_SUBSANAR = dr.GetBoolean(dr.GetOrdinal("OBSERV_SUBSANAR"));
                            ////NIVEL DE RIESGO
                            //lsCEntidad.NIVEL_RIESGO = dr.GetString(dr.GetOrdinal("NIVEL_RIESGO"));
                            //lsCEntidad.TIPO_RIESGO = dr.GetString(dr.GetOrdinal("TIPO_RIESGO"));
                            //lsCEntidad.OBSERVACION_RIESGO = dr.GetString(dr.GetOrdinal("OBSERVACION_RIESGO"));
                            lsCEntidad.USUARIO_REGISTRO = dr.GetString(dr.GetOrdinal("USUARIO_REGISTRO"));
                            lsCEntidad.USUARIO_CONTROL = dr.GetString(dr.GetOrdinal("USUARIO_CONTROL"));


                            #region Obligacion Titulares TH no Maderables
                            //1
                            lsCEntidad.OBLI_NM_PRESENTOPMF = dr.GetString(dr.GetOrdinal("OBLI_NM_PRESENTOPMF"));
                            lsCEntidad.OBLI_NM_PRESENTOPMF_DESCRIPCION = dr.GetString(dr.GetOrdinal("OBLI_NM_PRESENTOPMF_DESCRIPCION"));
                            //2
                            lsCEntidad.OBLI_NM_PRESENTOINFORMEEJECUCION = dr.GetString(dr.GetOrdinal("OBLI_NM_PRESENTOINFORMEEJECUCION"));
                            lsCEntidad.OBLI_NM_PRESENTOINFORMEEJECUCION_DESCRIPCION = dr.GetString(dr.GetOrdinal("OBLI_NM_PRESENTOINFORMEEJECUCION_DESCRIPCION"));
                            //3
                            lsCEntidad.OBLI_NM_PAGOAPROVECHAMIENTO = dr.GetString(dr.GetOrdinal("OBLI_NM_PAGOAPROVECHAMIENTO"));
                            lsCEntidad.OBLI_NM_PAGOAPROVECHAMIENTO_DESCRIPCION = dr.GetString(dr.GetOrdinal("OBLI_NM_PAGOAPROVECHAMIENTO_DESCRIPCION"));
                            //4
                            lsCEntidad.OBLI_NM_COMUNICOARFFSOSINFORSUSCRIPCION = dr.GetString(dr.GetOrdinal("OBLI_NM_COMUNICOARFFSOSINFORSUSCRIPCION"));
                            lsCEntidad.OBLI_NM_COMUNICOARFFSOSINFORSUSCRIPCION_DESCRIPCION = dr.GetString(dr.GetOrdinal("OBLI_NM_COMUNICOARFFSOSINFORSUSCRIPCION_DESCRIPCION"));
                            //5
                            lsCEntidad.OBLI_NM_REPORTOARFFSMINISTERIOAVISTAMIENTOS = dr.GetString(dr.GetOrdinal("OBLI_NM_REPORTOARFFSMINISTERIOAVISTAMIENTOS"));
                            lsCEntidad.OBLI_NM_REPORTOARFFSMINISTERIOAVISTAMIENTOS_DESCRIPCION = dr.GetString(dr.GetOrdinal("OBLI_NM_REPORTOARFFSMINISTERIOAVISTAMIENTOS_DESCRIPCION"));
                            //6
                            lsCEntidad.OBLI_NM_REALIZOACCIONESCUSTODIO = dr.GetString(dr.GetOrdinal("OBLI_NM_REALIZOACCIONESCUSTODIO"));
                            lsCEntidad.OBLI_NM_REALIZOACCIONESCUSTODIO_DESCRIPCION = dr.GetString(dr.GetOrdinal("OBLI_NM_REALIZOACCIONESCUSTODIO_DESCRIPCION"));
                            //7
                            lsCEntidad.OBLI_NM_FACILITODESARROLLO = dr.GetString(dr.GetOrdinal("OBLI_NM_FACILITODESARROLLO"));
                            lsCEntidad.OBLI_NM_FACILITODESARROLLO_DESCRIPCION = dr.GetString(dr.GetOrdinal("OBLI_NM_FACILITODESARROLLO_DESCRIPCION"));
                            //8
                            lsCEntidad.OBLI_NM_ASUMIOCOSTOSUPERVISIONES = dr.GetString(dr.GetOrdinal("OBLI_NM_ASUMIOCOSTOSUPERVISIONES"));
                            lsCEntidad.OBLI_NM_ASUMIOCOSTOSUPERVISIONES_DESCRIPCION = dr.GetString(dr.GetOrdinal("OBLI_NM_ASUMIOCOSTOSUPERVISIONES_DESCRIPCION"));
                            //9
                            lsCEntidad.OBLI_NM_IMPLEMENTAMECANISMOTRAZA = dr.GetString(dr.GetOrdinal("OBLI_NM_IMPLEMENTAMECANISMOTRAZA"));
                            lsCEntidad.OBLI_NM_IMPLEMENTAMECANISMOTRAZA_DESCRIPCION = dr.GetString(dr.GetOrdinal("OBLI_NM_IMPLEMENTAMECANISMOTRAZA_DESCRIPCION"));
                            //10
                            lsCEntidad.OBLI_NM_RESPETASERVIDUMBRE = dr.GetString(dr.GetOrdinal("OBLI_NM_RESPETASERVIDUMBRE"));
                            lsCEntidad.OBLI_NM_RESPETASERVIDUMBRE_DESCRIPCION = dr.GetString(dr.GetOrdinal("OBLI_NM_RESPETASERVIDUMBRE_DESCRIPCION"));
                            //11
                            lsCEntidad.OBLI_NM_ADOPTAMEDIDASEXTENSION = dr.GetString(dr.GetOrdinal("OBLI_NM_ADOPTAMEDIDASEXTENSION"));
                            lsCEntidad.OBLI_NM_ADOPTAMEDIDASEXTENSION_DESCRIPCION = dr.GetString(dr.GetOrdinal("OBLI_NM_ADOPTAMEDIDASEXTENSION_DESCRIPCION"));
                            //12
                            lsCEntidad.OBLI_NM_RESPETAVALORES = dr.GetString(dr.GetOrdinal("OBLI_NM_RESPETAVALORES"));
                            lsCEntidad.OBLI_NM_RESPETAVALORES_DESCRIPCION = dr.GetString(dr.GetOrdinal("OBLI_NM_RESPETAVALORES_DESCRIPCION"));
                            //13
                            lsCEntidad.OBLI_NM_CUMPLEMEDIDAS = dr.GetString(dr.GetOrdinal("OBLI_NM_CUMPLEMEDIDAS"));
                            lsCEntidad.OBLI_NM_CUMPLEMEDIDAS_DESCRIPCION = dr.GetString(dr.GetOrdinal("OBLI_NM_CUMPLEMEDIDAS_DESCRIPCION"));
                            //14
                            lsCEntidad.OBLI_NM_CUMPLENORMAS = dr.GetString(dr.GetOrdinal("OBLI_NM_CUMPLENORMAS"));
                            lsCEntidad.OBLI_NM_CUMPLENORMAS_DESCRIPCION = dr.GetString(dr.GetOrdinal("OBLI_NM_CUMPLENORMAS_DESCRIPCION"));
                            //15
                            lsCEntidad.OBLI_NM_MOVILIZAFRUTOPRODUCTOS = dr.GetString(dr.GetOrdinal("OBLI_NM_MOVILIZAFRUTOPRODUCTOS"));
                            lsCEntidad.OBLI_NM_MOVILIZAFRUTOPRODUCTOS_DESCRIPCION = dr.GetString(dr.GetOrdinal("OBLI_NM_MOVILIZAFRUTOPRODUCTOS_DESCRIPCION"));
                            //16
                            lsCEntidad.OBLI_NM_IMPLEMENTACIONMEDIDASCORRECTIVAS = dr.GetString(dr.GetOrdinal("OBLI_NM_IMPLEMENTACIONMEDIDASCORRECTIVAS"));
                            lsCEntidad.OBLI_NM_IMPLEMENTACIONMEDIDASCORRECTIVAS_DESCRIPCION = dr.GetString(dr.GetOrdinal("OBLI_NM_IMPLEMENTACIONMEDIDASCORRECTIVAS_DESCRIPCION"));
                            //17
                            lsCEntidad.OBLI_NM_IMPMEDCORRECRESULTADOACCIONES = dr.GetString(dr.GetOrdinal("OBLI_NM_IMPMEDCORRECRESULTADOACCIONES"));
                            lsCEntidad.OBLI_NM_IMPMEDCORRECRESULTADOACCIONES_DESCRIPCION = dr.GetString(dr.GetOrdinal("OBLI_NM_IMPMEDCORRECRESULTADOACCIONES_DESCRIPCION"));
                            //18
                            lsCEntidad.OBLI_NM_PROMUEVENBUENASPRACTICAS = dr.GetString(dr.GetOrdinal("OBLI_NM_PROMUEVENBUENASPRACTICAS"));
                            lsCEntidad.OBLI_NM_PROMUEVENBUENASPRACTICAS_DESCRIPCION = dr.GetString(dr.GetOrdinal("OBLI_NM_PROMUEVENBUENASPRACTICAS_DESCRIPCION"));
                            //19
                            lsCEntidad.OBLI_NM_PROMUEVEEQUIDAD = dr.GetString(dr.GetOrdinal("OBLI_NM_PROMUEVEEQUIDAD"));
                            lsCEntidad.OBLI_NM_PROMUEVEEQUIDAD_DESCRIPCION = dr.GetString(dr.GetOrdinal("OBLI_NM_PROMUEVEEQUIDAD_DESCRIPCION"));
                            #endregion
                        }
                        //Lista de Supervisor
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            int pt0 = dr.GetOrdinal("COD_SUPERVISOR");
                            int pt1 = dr.GetOrdinal("APE_PATERNO");
                            int pt2 = dr.GetOrdinal("APE_MATERNO");
                            int pt3 = dr.GetOrdinal("NOMBRES");
                            int pt4 = dr.GetOrdinal("NOMBRE_SUPERVISOR");
                            int pt5 = dr.GetOrdinal("N_DOCUMENTO");
                            int pt6 = dr.GetOrdinal("COD_DIDENTIDAD");
                            int pt7 = dr.GetOrdinal("COD_NACADEMICO");
                            int pt8 = dr.GetOrdinal("COD_DPESPECIALIDAD");
                            int pt9 = dr.GetOrdinal("COLEGIATURA_NUM");
                            int pt10 = dr.GetOrdinal("CARGO");
                            while (dr.Read())
                            {
                                ocampoPersona = new CEntPersona();
                                ocampoPersona.COD_PERSONA = dr.GetString(pt0);
                                ocampoPersona.APE_PATERNO = dr.GetString(pt1);
                                ocampoPersona.APE_MATERNO = dr.GetString(pt2);
                                ocampoPersona.NOMBRES = dr.GetString(pt3);
                                ocampoPersona.PERSONA = dr.GetString(pt4);
                                ocampoPersona.N_DOCUMENTO = dr.GetString(pt5);
                                ocampoPersona.COD_DIDENTIDAD = dr.GetString(pt6);
                                ocampoPersona.COD_NACADEMICO = dr.GetString(pt7);
                                ocampoPersona.COD_DPESPECIALIDAD = dr.GetString(pt8);
                                ocampoPersona.COLEGIATURA_NUM = dr.GetString(pt9);
                                ocampoPersona.CARGO = dr.GetString(pt10);
                                ocampoPersona.COD_PTIPO = "0000007";
                                ocampoPersona.RegEstado = 0;
                                lsCEntidad.ListInformeDetSupervisor.Add(ocampoPersona);
                            }
                        }
                        //det concepto
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            List<CEntidad> oListTemp = new List<CEntidad>();
                            int pt0 = dr.GetOrdinal("COD_TCONCEPTO");
                            int pt1 = dr.GetOrdinal("DESCRIPCION");
                            int pt2 = dr.GetOrdinal("ESTADO_MPLANTACION");
                            int pt3 = dr.GetOrdinal("OBSERVACION");
                            int pt4 = dr.GetOrdinal("TIPO");
                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidad();
                                ocampoEnt.COD_TCONCEPTO = dr.GetInt32(pt0);
                                ocampoEnt.DESCRIPCION = dr.GetString(pt1);
                                ocampoEnt.ESTADO_MPLANTACION = dr.GetBoolean(pt2);
                                ocampoEnt.OBSERVACION = dr.GetString(pt3);
                                ocampoEnt.TIPO = dr.GetString(pt4);
                                ocampoEnt.RegEstado = 0;
                                oListTemp.Add(ocampoEnt);
                            }
                            if (oListTemp != null && oListTemp.Count > 0)
                            {

                                lsCEntidad.ListISUPERVISION_DET_TARA_CONCEPTO = (from p in oListTemp where p.TIPO == "MP" select p).ToList<CEntidad>();
                                lsCEntidad.ListISUPERVISION_DET_TARA_CONCEPTO_OTROS = (from p in oListTemp where p.TIPO != "MP" select p).ToList<CEntidad>();
                            }
                        }
                        //prod frutos
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            int pt0 = dr.GetOrdinal("COD_SECUENCIAL");
                            int pt1 = dr.GetOrdinal("PREDIO_AREA");
                            int pt2 = dr.GetOrdinal("PRIMERA_COSECHA");
                            int pt3 = dr.GetOrdinal("SEGUNDA_COSECHA");
                            int pt4 = dr.GetOrdinal("TOTAL_PROD_ANUAL");
                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidad();
                                ocampoEnt.COD_SECUENCIAL = dr.GetInt32(pt0);
                                ocampoEnt.PREDIO_AREA = dr.GetDecimal(pt1);
                                ocampoEnt.PRIMERA_COSECHA = dr.GetDecimal(pt2);
                                ocampoEnt.SEGUNDA_COSECHA = dr.GetDecimal(pt3);
                                ocampoEnt.TOTAL_PROD_ANUAL = dr.GetDecimal(pt4);
                                ocampoEnt.RegEstado = 0;
                                lsCEntidad.ListISUPERVISION_DET_TARA_PFRUTOS.Add(ocampoEnt);
                            }
                        }
                        //ListISUPERVISION_DET_TARA_APFORESTAL
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            int pt0 = dr.GetOrdinal("COD_SECUENCIAL");
                            int pt1 = dr.GetOrdinal("PREDIO_AREA");
                            int pt2 = dr.GetOrdinal("ZAFRA");
                            int pt3 = dr.GetOrdinal("P_ARBOL_PRODUCTIVO");
                            int pt4 = dr.GetOrdinal("P_ARBOL_NOPRODUCTIVO");
                            int pt5 = dr.GetOrdinal("P_ARBOL_PLANTADO");
                            int pt6 = dr.GetOrdinal("CANTIDAD_AEXTRAER");
                            int pt7 = dr.GetOrdinal("CANTIDAD_EXTRAIDA");
                            int pt8 = dr.GetOrdinal("N_ARBOL_SUPERVISADO");
                            int pt9 = dr.GetOrdinal("CANTIDAD_SUPERVISADO");
                            int pt10 = dr.GetOrdinal("CANTIDAD_INJUSTIFICADA");
                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidad();
                                ocampoEnt.COD_SECUENCIAL = dr.GetInt32(pt0);
                                ocampoEnt.PREDIO_AREA = dr.GetDecimal(pt1);
                                ocampoEnt.ZAFRA = dr.GetString(pt2);
                                ocampoEnt.P_ARBOL_PRODUCTIVO = dr.GetDecimal(pt3);
                                ocampoEnt.P_ARBOL_NOPRODUCTIVO = dr.GetDecimal(pt4);
                                ocampoEnt.P_ARBOL_PLANTADO = dr.GetDecimal(pt5);
                                ocampoEnt.CANTIDAD_AEXTRAER = dr.GetDecimal(pt6);
                                ocampoEnt.CANTIDAD_EXTRAIDA = dr.GetDecimal(pt7);
                                ocampoEnt.N_ARBOL_SUPERVISADO = dr.GetInt32(pt8);
                                ocampoEnt.CANTIDAD_SUPERVISADO = dr.GetDecimal(pt9);
                                ocampoEnt.CANTIDAD_INJUSTIFICADA = dr.GetDecimal(pt10);
                                ocampoEnt.RegEstado = 0;
                                lsCEntidad.ListISUPERVISION_DET_TARA_APFORESTAL.Add(ocampoEnt);
                            }
                        }
                        //ListISUPERVISION_DET_TARA_KARDEX
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            int pt0 = dr.GetOrdinal("COD_SECUENCIAL");
                            int pt1 = dr.GetOrdinal("N_GUIA_TRANSPORTE");
                            int pt2 = dr.GetOrdinal("ZAFRA");
                            int pt3 = dr.GetOrdinal("FECHA_EMISION");
                            int pt4 = dr.GetOrdinal("CANTIDAD_AQUINTAL");
                            int pt5 = dr.GetOrdinal("TOTAL_SQUINTAL");
                            int pt6 = dr.GetOrdinal("SALDO_QUINTAL");
                            int pt7 = dr.GetOrdinal("SALDO_MTRES");
                            int pt8 = dr.GetOrdinal("UBIGEO");
                            int pt9 = dr.GetOrdinal("DESTINO_COD_UBIGEO");
                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidad();
                                ocampoEnt.COD_SECUENCIAL = dr.GetInt32(pt0);
                                ocampoEnt.N_GUIA_TRANSPORTE = dr.GetString(pt1);
                                ocampoEnt.ZAFRA = dr.GetString(pt2);
                                ocampoEnt.FECHA_EMISION = dr.GetString(pt3);
                                ocampoEnt.CANTIDAD_AQUINTAL = dr.GetInt32(pt4);
                                ocampoEnt.TOTAL_SQUINTAL = dr.GetDecimal(pt5);
                                ocampoEnt.SALDO_QUINTAL = dr.GetDecimal(pt6);
                                ocampoEnt.SALDO_MTRES = dr.GetDecimal(pt7);
                                ocampoEnt.UBIGEO = dr.GetString(pt8);
                                ocampoEnt.DESTINO_COD_UBIGEO = dr.GetString(pt9);
                                ocampoEnt.RegEstado = 0;
                                lsCEntidad.ListISUPERVISION_DET_TARA_KARDEX.Add(ocampoEnt);
                            }
                        }
                        //ListISUPERVISION_DET_TARA_APROV
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            int pt0 = dr.GetOrdinal("COD_SECUENCIAL");
                            int pt1 = dr.GetOrdinal("PREDIO_AREA");
                            int pt2 = dr.GetOrdinal("N_ARBOL_SUPERVISADO");
                            int pt3 = dr.GetOrdinal("N_ARBOL_FVERDE");
                            int pt4 = dr.GetOrdinal("N_ARBOL_FVERDE_MADURO");
                            int pt5 = dr.GetOrdinal("N_ARBOL_FLOR");
                            int pt6 = dr.GetOrdinal("N_ARBOL_NOFRUTO");
                            int pt7 = dr.GetOrdinal("OBSERVACION");
                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidad();
                                ocampoEnt.COD_SECUENCIAL = dr.GetInt32(pt0);
                                ocampoEnt.PREDIO_AREA = dr.GetDecimal(pt1);
                                ocampoEnt.N_ARBOL_SUPERVISADO = dr.GetInt32(pt2);
                                ocampoEnt.N_ARBOL_FVERDE = dr.GetInt32(pt3);
                                ocampoEnt.N_ARBOL_FVERDE_MADURO = dr.GetInt32(pt4);
                                ocampoEnt.N_ARBOL_FLOR = dr.GetInt32(pt5);
                                ocampoEnt.N_ARBOL_NOFRUTO = dr.GetInt32(pt6);
                                ocampoEnt.OBSERVACION = dr.GetString(pt7);
                                ocampoEnt.RegEstado = 0;
                                lsCEntidad.ListISUPERVISION_DET_TARA_APROV.Add(ocampoEnt);
                            }
                        }

                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            int pt0 = dr.GetOrdinal("COD_SECUENCIAL");
                            int pt1 = dr.GetOrdinal("PREDIO_AREA");
                            int pt2 = dr.GetOrdinal("CODIGO_ARBOL");
                            int pt3 = dr.GetOrdinal("VAINAS_COD_PRESENCIA");
                            int pt4 = dr.GetOrdinal("DESCRIPCION");
                            int pt5 = dr.GetOrdinal("PRES_FLORES");
                            int pt6 = dr.GetOrdinal("PRES_PLAGA_ENFERMEDA");
                            int pt7 = dr.GetOrdinal("PRES_PLANTA_PARASITARIA");
                            int pt8 = dr.GetOrdinal("COORDENADA_NORTE");
                            int pt9 = dr.GetOrdinal("COORDENADA_ESTE");
                            int pt10 = dr.GetOrdinal("ALTURA_TOTAL");
                            int pt11 = dr.GetOrdinal("OBSERVACION");
                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidad();
                                ocampoEnt.COD_SECUENCIAL = dr.GetInt32(pt0);
                                ocampoEnt.PREDIO_AREA = dr.GetDecimal(pt1);
                                ocampoEnt.CODIGO_ARBOL = dr.GetString(pt2);
                                ocampoEnt.VAINAS_COD_PRESENCIA = dr.GetInt32(pt3);
                                ocampoEnt.DESCRIPCION = dr.GetString(pt4);
                                ocampoEnt.PRES_FLORES = dr.GetBoolean(pt5);
                                ocampoEnt.PRES_PLAGA_ENFERMEDA = dr.GetString(pt6);
                                ocampoEnt.PRES_PLANTA_PARASITARIA = dr.GetString(pt7);
                                ocampoEnt.COORDENADA_NORTE = dr.GetInt32(pt8);
                                ocampoEnt.COORDENADA_ESTE = dr.GetInt32(pt9);
                                ocampoEnt.ALTURA_TOTAL = dr.GetDecimal(pt10);
                                ocampoEnt.OBSERVACION = dr.GetString(pt11);
                                ocampoEnt.RegEstado = 0;
                                lsCEntidad.ListISUPERVISION_DET_TARA_CENSO.Add(ocampoEnt);
                            }
                        }
                        //ListISUPERVISION_DET_TARA_KARDEX
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            int pt0 = dr.GetOrdinal("COD_SECUENCIAL");
                            int pt1 = dr.GetOrdinal("NOMBRES");
                            int pt2 = dr.GetOrdinal("NUM_PERSONA");
                            int pt3 = dr.GetOrdinal("DESCRIPCION");
                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidad();
                                ocampoEnt.COD_SECUENCIAL = dr.GetInt32(pt0);
                                ocampoEnt.NOMBRES = dr.GetString(pt1);
                                ocampoEnt.NUM_PERSONA = dr.GetInt32(pt2);
                                ocampoEnt.DESCRIPCION = dr.GetString(pt3);
                                ocampoEnt.RegEstado = 0;
                                lsCEntidad.ListISUPERVISION_DET_TARA_CAPACITACION.Add(ocampoEnt);
                            }
                        }

                        #region ListDesplazamiento
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidad();
                                ocampoEnt.COD_DESPLAZAMIENTO = dr["COD_DESPLAZAMIENTO"].ToString();
                                ocampoEnt.COORDENADA_ESTE = Int32.Parse(dr["PTOI_COORDENADA_ESTE"].ToString());
                                ocampoEnt.COORDENADA_NORTE = Int32.Parse(dr["PTOI_COORDENADA_NORTE"].ToString());
                                ocampoEnt.COORDENADA_ESTE_CAMPO = Int32.Parse(dr["PTOF_COORDENADA_ESTE"].ToString());
                                ocampoEnt.COORDENADA_NORTE_CAMPO = Int32.Parse(dr["PTOF_COORDENADA_NORTE"].ToString());
                                ocampoEnt.OBSERVACION = dr["OBSERVACION"].ToString();
                                ocampoEnt.TipoVia = dr["TIPO"].ToString();
                                ocampoEnt.RegEstado = 0;
                                lsCEntidad.ListDesplazamientoInforme.Add(ocampoEnt);
                            }
                        }
                        #endregion
                        // OBLIGACIONES CONTRACTUALES
                        //dr.NextResult();
                        //if (dr.HasRows)
                        //{

                        //    int pt0 = dr.GetOrdinal("COD_OCONTRACTUAL");
                        //    int pt1 = dr.GetOrdinal("COD_SECUENCIAL");
                        //    int pt2 = dr.GetOrdinal("COD_ESPECIES");
                        //    int pt3 = dr.GetOrdinal("ESPECIES");
                        //    int pt4 = dr.GetOrdinal("ACTIVIDAD_ACTOS");
                        //    int pt5 = dr.GetOrdinal("ESTA_AUTORIZADO");
                        //    int pt6 = dr.GetOrdinal("DOCUMENTOS_AFORESTAL");
                        //    int pt7 = dr.GetOrdinal("OBSERVACION");
                        //    List<CEntidad> oListTempOblicagContractual = new List<CEntidad>();
                        //    while (dr.Read())
                        //    {
                        //        ocampoEnt = new CEntidad();
                        //        ocampoEnt.COD_OCONTRACTUAL = dr.GetString(pt0);
                        //        ocampoEnt.COD_SECUENCIAL = dr.GetInt32(pt1);
                        //        ocampoEnt.COD_ESPECIES = dr.GetString(pt2);
                        //        ocampoEnt.ESPECIES = dr.GetString(pt3);
                        //        ocampoEnt.ACTIVIDAD_ACTOS = dr.GetString(pt4);
                        //        ocampoEnt.ESTA_AUTORIZADO = dr.GetBoolean(pt5);
                        //        ocampoEnt.DOCUMENTOS_AFORESTAL = dr.GetString(pt6);
                        //        ocampoEnt.OBSERVACION = dr.GetString(pt7);
                        //        ocampoEnt.RegEstado = 0;
                        //        oListTempOblicagContractual.Add(ocampoEnt);
                        //    }
                        //    if (oListTempOblicagContractual != null && oListTempOblicagContractual.Count > 0)
                        //    {

                        //        lsCEntidad.ListOCEjecucionActividad = (from p in oListTempOblicagContractual where p.COD_OCONTRACTUAL == "01" select p).ToList<CEntidad>();
                        //        lsCEntidad.ListOCEspeciesExoticas = (from p in oListTempOblicagContractual where p.COD_OCONTRACTUAL == "02" select p).ToList<CEntidad>();
                        //        lsCEntidad.ListOCActosTercero = (from p in oListTempOblicagContractual where p.COD_OCONTRACTUAL == "03" select p).ToList<CEntidad>();
                        //        lsCEntidad.ListOCAprovechamientoDirecto = (from p in oListTempOblicagContractual where p.COD_OCONTRACTUAL == "04" select p).ToList<CEntidad>();
                        //    }
                        //}
                    }
                }
                return lsCEntidad;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //INFORME CONSERVACION
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public String RegIConservacionInsertar(OracleConnection cn, CEntidad oCEntidad)
        {
            OracleTransaction tr = null;
            String OUTPUTPARAM01 = "";
            CEntidad ocampoSuper;
            CEntPersona ocampoPersona;
            try
            {
                tr = cn.BeginTransaction();
                //Grabando Cabecera
                using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.INFORME_CONSERVACION_Grabar", oCEntidad))
                {
                    cmd.ExecuteNonQuery();
                    OUTPUTPARAM01 = (String)cmd.Parameters["OUTPUTPARAM01"].Value;
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
                        throw new Exception("El Número de Informe ya Existe");
                    }
                    else if (OUTPUTPARAM01 == "1")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("El Número del Titulo Habilitante Existe en otro Registro");
                    }
                    else if (OUTPUTPARAM01 == "2")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("No Tiene Permisos para Modificar este Informe");
                    }
                    else if (OUTPUTPARAM01 == "3")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("Está con Control de Calidad, no puede modificar");
                    }
                }
                //
                //Eliminando Detalle Informe
                if (oCEntidad.ListEliTABLA != null)
                {
                    foreach (var loDatos in oCEntidad.ListEliTABLA)
                    {
                        ocampoSuper = new CEntidad();
                        ocampoSuper.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                        ocampoSuper.EliTABLA = loDatos.EliTABLA;
                        ocampoSuper.EliVALOR01 = loDatos.EliVALOR01;
                        ocampoSuper.COD_SECUENCIAL = loDatos.EliVALOR02;
                        ocampoSuper.COD_PERSONA = loDatos.COD_PERSONA;
                        dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spINFORME_CONSERVEliminarDet", ocampoSuper);
                    }
                }
                //
                if (oCEntidad.ListInformeDetSupervisor != null)
                {
                    foreach (var loDatos in oCEntidad.ListInformeDetSupervisor)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            ocampoPersona = new CEntPersona();
                            ocampoPersona.COD_PERSONA = loDatos.COD_PERSONA;
                            ocampoPersona.CODIGO = OUTPUTPARAM01.Split('|')[0];
                            ocampoPersona.COD_DIDENTIDAD = loDatos.COD_DIDENTIDAD;
                            ocampoPersona.APE_PATERNO = loDatos.APE_PATERNO;
                            ocampoPersona.APE_MATERNO = loDatos.APE_MATERNO;
                            ocampoPersona.NOMBRES = loDatos.NOMBRES;
                            ocampoPersona.N_DOCUMENTO = loDatos.N_DOCUMENTO;
                            ocampoPersona.N_RUC = loDatos.N_RUC;
                            ocampoPersona.COD_PTIPO = loDatos.COD_PTIPO;
                            ocampoPersona.COLEGIATURA_NUM = loDatos.COLEGIATURA_NUM;
                            ocampoPersona.COD_DPESPECIALIDAD = loDatos.COD_DPESPECIALIDAD;
                            ocampoPersona.COD_NACADEMICO = loDatos.COD_NACADEMICO;
                            ocampoPersona.CARGO = loDatos.CARGO;
                            ocampoPersona.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.INFORME_DET_SUPERVISOR_Grabar", ocampoPersona);
                        }
                    }
                }
                // MANTENIMIENTO DE COORDENADA UTM
                if (oCEntidad.ListISUPERVISION_COORDENADAUTM != null)
                {
                    foreach (var loDatos in oCEntidad.ListISUPERVISION_COORDENADAUTM)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            ocampoSuper = new CEntidad();
                            ocampoSuper.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            ocampoSuper.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            ocampoSuper.VERTICE = loDatos.VERTICE;
                            ocampoSuper.COORDENADA_NORTE = loDatos.COORDENADA_NORTE;
                            ocampoSuper.COORDENADA_ESTE = loDatos.COORDENADA_ESTE;
                            ocampoSuper.COORDENADA_NORTE_CAMPO = loDatos.COORDENADA_NORTE_CAMPO;
                            ocampoSuper.COORDENADA_SUR_CAMPO = loDatos.COORDENADA_SUR_CAMPO;
                            ocampoSuper.ZONA = loDatos.ZONA;
                            ocampoSuper.ZONA_CAMPO = loDatos.ZONA_CAMPO;
                            ocampoSuper.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.ISUPERVISION_DET_COORDENADAUTM_Grabar", ocampoSuper);
                        }
                    }
                }
                // REGISTRO DE INFRAESTRUCTURA
                if (oCEntidad.ListISUPERVISION_INFRAESTRUCTURA != null)
                {
                    foreach (var loDatos in oCEntidad.ListISUPERVISION_INFRAESTRUCTURA)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            ocampoSuper = new CEntidad();
                            ocampoSuper.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            ocampoSuper.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            ocampoSuper.TIPO_AMBIENTE = loDatos.TIPO_AMBIENTE;
                            ocampoSuper.NUM_AMBIENTE = loDatos.NUM_AMBIENTE;
                            ocampoSuper.AREA = loDatos.AREA;
                            ocampoSuper.CAPACIDAD = loDatos.CAPACIDAD;
                            ocampoSuper.MATERIAL_CONSTRUCCION = loDatos.MATERIAL_CONSTRUCCION;
                            ocampoSuper.USO = loDatos.USO;
                            ocampoSuper.ESTADO_CONSERVACION = loDatos.ESTADO_CONSERVACION;
                            ocampoSuper.OBJETIVO = loDatos.OBJETIVO;
                            ocampoSuper.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.ISUPERVISION_DET_CONSERV_INFRA_Grabar", ocampoSuper);
                        }
                    }
                }
                // REGISTRO DE INFRAESTRUCTURA
                if (oCEntidad.ListISUPERVISION_INFRAESTRUCTURA_CONS != null)
                {
                    foreach (var loDatos in oCEntidad.ListISUPERVISION_INFRAESTRUCTURA_CONS)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            ocampoSuper = new CEntidad();
                            ocampoSuper.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            ocampoSuper.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            ocampoSuper.TIPO_AMBIENTE = loDatos.TIPO_AMBIENTE;
                            ocampoSuper.NUM_AMBIENTE = loDatos.NUM_AMBIENTE;
                            ocampoSuper.AREA = loDatos.AREA;
                            ocampoSuper.CAPACIDAD = loDatos.CAPACIDAD;
                            ocampoSuper.MATERIAL_CONSTRUCCION = loDatos.MATERIAL_CONSTRUCCION;
                            ocampoSuper.USO = loDatos.USO;
                            ocampoSuper.ESTADO_CONSERVACION = loDatos.ESTADO_CONSERVACION;
                            ocampoSuper.OBJETIVO = loDatos.OBJETIVO;
                            ocampoSuper.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.ISUPERVISION_DET_CONSERV_INFRA_Grabar", ocampoSuper);
                        }
                    }
                }
                // REGISTRO DE CAPACITACION LOCAL
                if (oCEntidad.ListISUPERVISION_DET_CAPACITACION_LOCAL != null)
                {
                    foreach (var loDatos in oCEntidad.ListISUPERVISION_DET_CAPACITACION_LOCAL)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            ocampoSuper = new CEntidad();
                            ocampoSuper.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            ocampoSuper.COD_PROGRAMA = loDatos.COD_PROGRAMA;
                            ocampoSuper.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            ocampoSuper.ACTIVIDAD_REALIZADA = loDatos.ACTIVIDAD_REALIZADA;
                            ocampoSuper.FECHA_REALIZADA = loDatos.FECHA_REALIZADA;
                            ocampoSuper.NUM_PERSONA = loDatos.NUM_PERSONA;
                            ocampoSuper.ESTADO_DOCUMENTO = loDatos.ESTADO_DOCUMENTO;
                            ocampoSuper.DESC_TIPO_REGISTRO = loDatos.DESC_TIPO_REGISTRO;
                            ocampoSuper.OBJETIVO = loDatos.OBJETIVO;
                            ocampoSuper.AVANCE_RESULTADO = loDatos.AVANCE_RESULTADO;
                            ocampoSuper.LUGAR_CAPACITACION = loDatos.LUGAR_CAPACITACION;
                            ocampoSuper.OBSERVACION = loDatos.OBSERVACION;
                            ocampoSuper.NOMBRE_COMUNIDAD_SECTOR = loDatos.NOMBRE_COMUNIDAD_SECTOR;
                            ocampoSuper.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.ISUPERVISION_DET_CONSERV_PROG_Grabar", ocampoSuper);
                        }
                    }
                }
                // REGISTRO DE CAPACITACION EFECTIVA
                if (oCEntidad.ListISUPERVISION_DET_CAPACITACION_EFECT != null)
                {
                    foreach (var loDatos in oCEntidad.ListISUPERVISION_DET_CAPACITACION_EFECT)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            ocampoSuper = new CEntidad();
                            ocampoSuper.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            ocampoSuper.COD_PROGRAMA = loDatos.COD_PROGRAMA;
                            ocampoSuper.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            ocampoSuper.ACTIVIDAD_REALIZADA = loDatos.ACTIVIDAD_REALIZADA;
                            ocampoSuper.FECHA_REALIZADA = loDatos.FECHA_REALIZADA;
                            ocampoSuper.NUM_PERSONA = loDatos.NUM_PERSONA;
                            ocampoSuper.ESTADO_DOCUMENTO = loDatos.ESTADO_DOCUMENTO;
                            ocampoSuper.DESC_TIPO_REGISTRO = loDatos.DESC_TIPO_REGISTRO;
                            ocampoSuper.OBJETIVO = loDatos.OBJETIVO;
                            ocampoSuper.AVANCE_RESULTADO = loDatos.AVANCE_RESULTADO;
                            ocampoSuper.LUGAR_CAPACITACION = loDatos.LUGAR_CAPACITACION;
                            ocampoSuper.OBSERVACION = loDatos.OBSERVACION;
                            ocampoSuper.NOMBRE_COMUNIDAD_SECTOR = loDatos.NOMBRE_COMUNIDAD_SECTOR;
                            ocampoSuper.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.ISUPERVISION_DET_CONSERV_PROG_Grabar", ocampoSuper);
                        }
                    }
                }
                // REGISTRO DE CAPACITACION - ACTIVIDADES
                if (oCEntidad.ListISUPERVISION_DET_CAPACITACION_ACTDES != null)
                {
                    foreach (var loDatos in oCEntidad.ListISUPERVISION_DET_CAPACITACION_ACTDES)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            ocampoSuper = new CEntidad();
                            ocampoSuper.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            ocampoSuper.COD_PROGRAMA = loDatos.COD_PROGRAMA;
                            ocampoSuper.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            ocampoSuper.ACTIVIDAD_REALIZADA = loDatos.ACTIVIDAD_REALIZADA;
                            ocampoSuper.FECHA_REALIZADA = loDatos.FECHA_REALIZADA;
                            ocampoSuper.NUM_PERSONA = loDatos.NUM_PERSONA;
                            ocampoSuper.ESTADO_DOCUMENTO = loDatos.ESTADO_DOCUMENTO;
                            ocampoSuper.DESC_TIPO_REGISTRO = loDatos.DESC_TIPO_REGISTRO;
                            ocampoSuper.OBJETIVO = loDatos.OBJETIVO;
                            ocampoSuper.AVANCE_RESULTADO = loDatos.AVANCE_RESULTADO;
                            ocampoSuper.LUGAR_CAPACITACION = loDatos.LUGAR_CAPACITACION;
                            ocampoSuper.NOMBRE_COMUNIDAD_SECTOR = loDatos.NOMBRE_COMUNIDAD_SECTOR;
                            ocampoSuper.OBSERVACION = loDatos.OBSERVACION;
                            ocampoSuper.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.ISUPERVISION_DET_CONSERV_PROG_Grabar", ocampoSuper);
                        }
                    }
                }
                // GESTION
                if (oCEntidad.ListISUPERVISION_DET_GESTION != null)
                {
                    foreach (var loDatos in oCEntidad.ListISUPERVISION_DET_GESTION)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            ocampoSuper = new CEntidad();
                            ocampoSuper.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            ocampoSuper.COD_PROGRAMA = loDatos.COD_PROGRAMA;
                            ocampoSuper.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            ocampoSuper.ACTIVIDAD_REALIZADA = loDatos.ACTIVIDAD_REALIZADA;
                            ocampoSuper.FECHA_REALIZADA = loDatos.FECHA_REALIZADA;
                            ocampoSuper.NUM_PERSONA = loDatos.NUM_PERSONA;
                            ocampoSuper.ESTADO_DOCUMENTO = loDatos.ESTADO_DOCUMENTO;
                            ocampoSuper.DESC_TIPO_REGISTRO = loDatos.DESC_TIPO_REGISTRO;
                            ocampoSuper.OBJETIVO = loDatos.OBJETIVO;
                            ocampoSuper.AVANCE_RESULTADO = loDatos.AVANCE_RESULTADO;
                            ocampoSuper.LUGAR_CAPACITACION = loDatos.LUGAR_CAPACITACION;
                            ocampoSuper.OBSERVACION = loDatos.OBSERVACION;
                            ocampoSuper.NOMBRE_COMUNIDAD_SECTOR = loDatos.NOMBRE_COMUNIDAD_SECTOR;
                            ocampoSuper.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.ISUPERVISION_DET_CONSERV_PROG_Grabar", ocampoSuper);
                        }
                    }
                }
                // REGISTRO DE CAPACITACION
                if (oCEntidad.ListISUPERVISION_DET_TARA_CAPACITACION != null)
                {
                    foreach (var loDatos in oCEntidad.ListISUPERVISION_DET_TARA_CAPACITACION)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            ocampoSuper = new CEntidad();
                            ocampoSuper.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            ocampoSuper.COD_PROGRAMA = loDatos.COD_PROGRAMA;
                            ocampoSuper.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            ocampoSuper.ACTIVIDAD_REALIZADA = loDatos.ACTIVIDAD_REALIZADA;
                            ocampoSuper.FECHA_REALIZADA = loDatos.FECHA_REALIZADA;
                            ocampoSuper.NUM_PERSONA = loDatos.NUM_PERSONA;
                            ocampoSuper.ESTADO_DOCUMENTO = loDatos.ESTADO_DOCUMENTO;
                            ocampoSuper.DESC_TIPO_REGISTRO = loDatos.DESC_TIPO_REGISTRO;
                            ocampoSuper.OBJETIVO = loDatos.OBJETIVO;
                            ocampoSuper.AVANCE_RESULTADO = loDatos.AVANCE_RESULTADO;
                            ocampoSuper.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.ISUPERVISION_DET_CONSERV_PROG_Grabar", ocampoSuper);
                        }
                    }
                }
                // REGISTRO DE INVESTIGACION
                if (oCEntidad.ListISUPERVISION_INVESTIGACION != null)
                {
                    foreach (var loDatos in oCEntidad.ListISUPERVISION_INVESTIGACION)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            ocampoSuper = new CEntidad();
                            ocampoSuper.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            ocampoSuper.COD_PROGRAMA = loDatos.COD_PROGRAMA;
                            ocampoSuper.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            ocampoSuper.ACTIVIDAD_REALIZADA = loDatos.ACTIVIDAD_REALIZADA;
                            ocampoSuper.OBJETIVO = loDatos.OBJETIVO;
                            ocampoSuper.AVANCE_RESULTADO = loDatos.AVANCE_RESULTADO;
                            ocampoSuper.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.ISUPERVISION_DET_CONSERV_PROG_Grabar", ocampoSuper);
                        }
                    }
                }
                // INVESTIGACION AMBIENTAL
                if (oCEntidad.ListISUPERVISION_INTERAMBIENTAL != null)
                {
                    foreach (var loDatos in oCEntidad.ListISUPERVISION_INTERAMBIENTAL)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            ocampoSuper = new CEntidad();
                            ocampoSuper.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            ocampoSuper.COD_PROGRAMA = loDatos.COD_PROGRAMA;
                            ocampoSuper.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            ocampoSuper.ACTIVIDAD_REALIZADA = loDatos.ACTIVIDAD_REALIZADA;
                            ocampoSuper.AVANCE_RESULTADO = loDatos.AVANCE_RESULTADO;
                            ocampoSuper.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.ISUPERVISION_DET_CONSERV_PROG_Grabar", ocampoSuper);
                        }
                    }
                }
                // MARKETING
                if (oCEntidad.ListISUPERVISION_PROMOMARKETING != null)
                {
                    foreach (var loDatos in oCEntidad.ListISUPERVISION_PROMOMARKETING)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            ocampoSuper = new CEntidad();
                            ocampoSuper.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            ocampoSuper.COD_PROGRAMA = loDatos.COD_PROGRAMA;
                            ocampoSuper.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            ocampoSuper.ACTIVIDAD_REALIZADA = loDatos.ACTIVIDAD_REALIZADA;
                            ocampoSuper.AVANCE_RESULTADO = loDatos.AVANCE_RESULTADO;
                            ocampoSuper.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.ISUPERVISION_DET_CONSERV_PROG_Grabar", ocampoSuper);
                        }
                    }
                }
                // MONITOREO Y EVALUACION
                if (oCEntidad.ListISUPERVISION_MONITOEVALUACION != null)
                {
                    foreach (var loDatos in oCEntidad.ListISUPERVISION_MONITOEVALUACION)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            ocampoSuper = new CEntidad();
                            ocampoSuper.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            ocampoSuper.COD_PROGRAMA = loDatos.COD_PROGRAMA;
                            ocampoSuper.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            ocampoSuper.ACTIVIDAD_REALIZADA = loDatos.ACTIVIDAD_REALIZADA;
                            ocampoSuper.AVANCE_RESULTADO = loDatos.AVANCE_RESULTADO;
                            ocampoSuper.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.ISUPERVISION_DET_CONSERV_PROG_Grabar", ocampoSuper);
                        }
                    }
                }
                // Prog identificación y  manejo de impactos
                if (oCEntidad.ListISUPERVISION_IDENTMANEJOIMPACTO != null)
                {
                    foreach (var loDatos in oCEntidad.ListISUPERVISION_IDENTMANEJOIMPACTO)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            ocampoSuper = new CEntidad();
                            ocampoSuper.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            ocampoSuper.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            ocampoSuper.TIPO_IMPACTO = loDatos.TIPO_IMPACTO;
                            ocampoSuper.RIESGO_POTENCIAL = loDatos.RIESGO_POTENCIAL;
                            ocampoSuper.ACTIVIDAD = loDatos.ACTIVIDAD;
                            ocampoSuper.AVANCE_RESULTADO = loDatos.AVANCE_RESULTADO;
                            ocampoSuper.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.ISUPERVISION_DET_CONSERV_IDENTMANIMPACT_Grabar", ocampoSuper);
                        }
                    }
                }
                // FAUNA SILVESTRE
                if (oCEntidad.ListAvistamientoFauna != null)
                {
                    foreach (var loDatos in oCEntidad.ListAvistamientoFauna)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            ocampoSuper = new CEntidad();
                            ocampoSuper.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            ocampoSuper.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            ocampoSuper.COD_ESPECIES = loDatos.COD_ESPECIES;
                            ocampoSuper.NUM_INDIVIDUOS = loDatos.NUM_INDIVIDUOS;
                            ocampoSuper.COD_TIPO_REGISTRO = loDatos.COD_TIPO_REGISTRO;
                            ocampoSuper.COD_ESTRATO = loDatos.COD_ESTRATO;
                            ocampoSuper.FECHA_AVISTAMIENTO = loDatos.FECHA_AVISTAMIENTO;
                            ocampoSuper.HORA_AVISTAMIENTO = loDatos.HORA_AVISTAMIENTO;
                            ocampoSuper.COORDENADA_NORTE = loDatos.COORDENADA_NORTE;
                            ocampoSuper.COORDENADA_ESTE = loDatos.COORDENADA_ESTE;
                            ocampoSuper.ALTITUD = loDatos.ALTITUD;
                            ocampoSuper.DESCRIPCION = loDatos.OBSERVACION;
                            ocampoSuper.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.ISUPERVISION_MADE_NOMADE_DET_AVISTAMIENTO_FAUNA_Grabar", ocampoSuper);
                            //dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.ISUPERVISION_DET_CONSERV_FAUNA_SILV_Grabar", ocampoSuper);
                        }
                    }
                }
                if (oCEntidad.ListISUPERVISION_FLORA_SILVESTRE != null)
                {
                    foreach (var loDatos in oCEntidad.ListISUPERVISION_FLORA_SILVESTRE)
                    {
                        ocampoSuper = new CEntidad();
                        ocampoSuper.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                        ocampoSuper.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                        ocampoSuper.COD_ESPECIES = loDatos.COD_ESPECIES;
                        ocampoSuper.DAP = loDatos.DAP;
                        ocampoSuper.ALTURA_TOTAL = loDatos.ALTURA_TOTAL;
                        ocampoSuper.COORDENADA_NORTE = loDatos.COORDENADA_NORTE;
                        ocampoSuper.COORDENADA_ESTE = loDatos.COORDENADA_ESTE;
                        ocampoSuper.ESTADO_ESPECIE = loDatos.ESTADO;
                        ocampoSuper.OBSERVACION = loDatos.OBSERVACION;
                        ocampoSuper.RegEstado = loDatos.RegEstado;
                        dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.ISUPERVISION_DET_CONSERV_FLORA_SILV_Grabar", ocampoSuper);
                    }
                }
                if (oCEntidad.ListISUPERVISION_REC_PAISAJE_CULTURAL != null)
                {
                    foreach (var loDatos in oCEntidad.ListISUPERVISION_REC_PAISAJE_CULTURAL)
                    {
                        ocampoSuper = new CEntidad();
                        ocampoSuper.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                        ocampoSuper.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                        ocampoSuper.TIPO = loDatos.TIPO;
                        ocampoSuper.ESTADO_PAISAJE = loDatos.ESTADO;
                        ocampoSuper.NUM_VISITANTE = loDatos.NUM_VISITANTE;
                        ocampoSuper.COORDENADA_NORTE = loDatos.COORDENADA_NORTE;
                        ocampoSuper.COORDENADA_ESTE = loDatos.COORDENADA_ESTE;
                        ocampoSuper.OBSERVACION = loDatos.OBSERVACION;
                        ocampoSuper.RegEstado = loDatos.RegEstado;
                        dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.ISUPERVISION_DET_CONSERV_RPAISAJ_CULT_Grabar", ocampoSuper);
                    }
                }
                if (oCEntidad.ListISUPERVISION_OCARACTE_AMB01 != null)
                {
                    foreach (var loDatos in oCEntidad.ListISUPERVISION_OCARACTE_AMB01)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            ocampoSuper = new CEntidad();
                            ocampoSuper.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            ocampoSuper.COD_PROGRAMA = loDatos.COD_PROGRAMA;
                            ocampoSuper.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            ocampoSuper.COD_ESPECIES = loDatos.COD_ESPECIES;
                            ocampoSuper.ACTIVIDAD = loDatos.ACTIVIDAD;
                            ocampoSuper.ESTA_AUTORIZADO = loDatos.ESTA_AUTORIZADO;
                            ocampoSuper.DOCUMENTOS_AFORESTAL = loDatos.DOCUMENTOS_AFORESTAL;
                            ocampoSuper.OBSERVACION = loDatos.OBSERVACION;
                            ocampoSuper.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.ISUPERVISION_DET_CONSERV_OBLIGCONTR_Grabar", ocampoSuper);
                        }
                    }
                }
                if (oCEntidad.ListISUPERVISION_OCARACTE_AMB02 != null)
                {
                    foreach (var loDatos in oCEntidad.ListISUPERVISION_OCARACTE_AMB02)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            ocampoSuper = new CEntidad();
                            ocampoSuper.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            ocampoSuper.COD_PROGRAMA = loDatos.COD_PROGRAMA;
                            ocampoSuper.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            ocampoSuper.COD_ESPECIES = loDatos.COD_ESPECIES;
                            ocampoSuper.ACTIVIDAD = loDatos.ACTIVIDAD;
                            ocampoSuper.ESTA_AUTORIZADO = loDatos.ESTA_AUTORIZADO;
                            ocampoSuper.DOCUMENTOS_AFORESTAL = loDatos.DOCUMENTOS_AFORESTAL;
                            ocampoSuper.OBSERVACION = loDatos.OBSERVACION;
                            ocampoSuper.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.ISUPERVISION_DET_CONSERV_OBLIGCONTR_Grabar", ocampoSuper);
                        }
                    }
                }
                if (oCEntidad.ListISUPERVISION_CARACTESOCIAL != null)
                {
                    foreach (var loDatos in oCEntidad.ListISUPERVISION_CARACTESOCIAL)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            ocampoSuper = new CEntidad();
                            ocampoSuper.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            ocampoSuper.COD_PROGRAMA = loDatos.COD_PROGRAMA;
                            ocampoSuper.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            ocampoSuper.COD_ESPECIES = loDatos.COD_ESPECIES;
                            ocampoSuper.ACTIVIDAD = loDatos.ACTIVIDAD;
                            ocampoSuper.ESTA_AUTORIZADO = loDatos.ESTA_AUTORIZADO;
                            ocampoSuper.DOCUMENTOS_AFORESTAL = loDatos.DOCUMENTOS_AFORESTAL;
                            ocampoSuper.OBSERVACION = loDatos.OBSERVACION;
                            ocampoSuper.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.ISUPERVISION_DET_CONSERV_OBLIGCONTR_Grabar", ocampoSuper);
                        }
                    }
                }
                if (oCEntidad.ListISUPERVISION_CARACTE_ECOLOG != null)
                {
                    foreach (var loDatos in oCEntidad.ListISUPERVISION_CARACTE_ECOLOG)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            ocampoSuper = new CEntidad();
                            ocampoSuper.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            ocampoSuper.COD_PROGRAMA = loDatos.COD_PROGRAMA;
                            ocampoSuper.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            ocampoSuper.COD_ESPECIES = loDatos.COD_ESPECIES;
                            ocampoSuper.ACTIVIDAD = loDatos.ACTIVIDAD;
                            ocampoSuper.ESTA_AUTORIZADO = loDatos.ESTA_AUTORIZADO;
                            ocampoSuper.DOCUMENTOS_AFORESTAL = loDatos.DOCUMENTOS_AFORESTAL;
                            ocampoSuper.OBSERVACION = loDatos.OBSERVACION;
                            ocampoSuper.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.ISUPERVISION_DET_CONSERV_OBLIGCONTR_Grabar", ocampoSuper);
                        }
                    }
                }
                if (oCEntidad.ListISUPERVISION_DET_PROGRAMA != null)
                {
                    foreach (var loDatos in oCEntidad.ListISUPERVISION_DET_PROGRAMA)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            ocampoSuper = new CEntidad();
                            ocampoSuper.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            ocampoSuper.COD_PROGRAMA = loDatos.COD_PROGRAMA;
                            ocampoSuper.ESTADO_PROGRAMA = loDatos.ESTADO_PROGRAMA;
                            ocampoSuper.OBSERVACION = loDatos.OBSERVACION;
                            ocampoSuper.TIPO = loDatos.TIPO;
                            ocampoSuper.FRECUENCIA = loDatos.FRECUENCIA;
                            ocampoSuper.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.ISUPERVISION_DET_PROGRAMA_Grabar", ocampoSuper);
                        }
                    }
                }
                if (oCEntidad.ListISUPERVISION_DET_ZONIFICACION != null)
                {
                    foreach (var loDatos in oCEntidad.ListISUPERVISION_DET_ZONIFICACION)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            ocampoSuper = new CEntidad();
                            ocampoSuper.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            ocampoSuper.COD_PROGRAMA = loDatos.COD_PROGRAMA;
                            ocampoSuper.NOMBRE_ZONA = loDatos.NOMBRE_ZONA;
                            ocampoSuper.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            ocampoSuper.CARACTERISTICA = loDatos.CARACTERISTICA;
                            ocampoSuper.COORDENADA_NORTE = loDatos.COORDENADA_NORTE;
                            ocampoSuper.COORDENADA_ESTE = loDatos.COORDENADA_ESTE;
                            ocampoSuper.TIPO_SENALIZACION = loDatos.TIPO_SENALIZACION;
                            ocampoSuper.TIPO_DELIMITACION = loDatos.TIPO_DELIMITACION;
                            ocampoSuper.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.ISUPERVISION_DET_CONSERV_ZONIFICACION_Grabar", ocampoSuper);
                        }
                    }
                }
                if (oCEntidad.ListISUPERVISION_DET_EQUIPACONSECION != null)
                {
                    foreach (var loDatos in oCEntidad.ListISUPERVISION_DET_EQUIPACONSECION)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            ocampoSuper = new CEntidad();
                            ocampoSuper.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            ocampoSuper.COD_PROGRAMA = loDatos.COD_PROGRAMA;
                            ocampoSuper.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            ocampoSuper.DESCRIPCION = loDatos.DESCRIPCION;
                            ocampoSuper.NUM_AMBIENTE = loDatos.NUM_AMBIENTE;
                            ocampoSuper.USO = loDatos.USO;
                            ocampoSuper.ESTADO_CONSERVACION = loDatos.ESTADO_CONSERVACION;
                            ocampoSuper.OBJETIVO = loDatos.OBJETIVO;
                            ocampoSuper.OBSERVACION = loDatos.OBSERVACION;
                            ocampoSuper.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.ISUPERVISION_DET_CONSERV_CONSECION_Grabar", ocampoSuper);
                        }
                    }
                }

                //Registro de DESPLAZAMIENTO
                if (oCEntidad.ListDesplazamientoInforme != null)
                {
                    foreach (var loDatos in oCEntidad.ListDesplazamientoInforme)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            CEntidad ocampo = new CEntidad();
                            ocampo.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            if (loDatos.COD_DESPLAZAMIENTO == null)
                            {
                                ocampo.COD_DESPLAZAMIENTO = "";
                            }
                            else
                            {
                                ocampo.COD_DESPLAZAMIENTO = loDatos.COD_DESPLAZAMIENTO;
                            }
                            ocampo.PTOI_COORDENADA_ESTE = loDatos.COORDENADA_ESTE;
                            ocampo.PTOI_COORDENADA_NORTE = loDatos.COORDENADA_NORTE;
                            ocampo.PTOF_COORDENADA_ESTE = loDatos.COORDENADA_ESTE_CAMPO;
                            ocampo.PTOF_COORDENADA_NORTE = loDatos.COORDENADA_NORTE_CAMPO;
                            ocampo.OBSERVACION = loDatos.OBSERVACION;
                            ocampo.TIPO = loDatos.TipoVia;
                            ocampo.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spINFORME_DESPLAZAMIENTOGrabar", ocampo);
                        }
                    }
                }
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <returns></returns>
        public CEntidad RegConservacionMostCombo(OracleConnection cn, CEntidad oCEntidad)
        {
            CEntidad oCampos = new CEntidad();
            oCampos.ListEspeciesDetFauna = new List<CEntidad>();
            oCampos.ListEspeciesDetFlora = new List<CEntidad>();
            oCampos.ListTipoRegistro = new List<CEntidad>();
            oCampos.ListEstrato = new List<CEntidad>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spGeneral_Combo_Listar", oCEntidad))
                {
                    if (dr != null)
                    {
                        CEntidad oCamposDet;
                        //Especies Fauna
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("CODIGO");
                            int pt2 = dr.GetOrdinal("DESCRIPCION");
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.CODIGO = dr.GetString(pt1);
                                oCamposDet.DESCRIPCION = dr.GetString(pt2);
                                oCampos.ListEspeciesDetFauna.Add(oCamposDet);
                            }
                        }
                        //Especies Flora
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("CODIGO");
                            int pt2 = dr.GetOrdinal("DESCRIPCION");
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.CODIGO = dr.GetString(pt1);
                                oCamposDet.DESCRIPCION = dr.GetString(pt2);
                                oCampos.ListEspeciesDetFlora.Add(oCamposDet);
                            }
                        }
                        //AVISTAMIENTO TIPO REGISTRO
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("CODIGO");
                            int pt2 = dr.GetOrdinal("DESCRIPCION");
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.CODIGO = dr.GetString(pt1);
                                oCamposDet.DESCRIPCION = dr.GetString(pt2);
                                oCampos.ListTipoRegistro.Add(oCamposDet);
                            }
                        }
                        //AVISTAMIENTO ESTRATO
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("CODIGO");
                            int pt2 = dr.GetOrdinal("DESCRIPCION");
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.CODIGO = dr.GetString(pt1);
                                oCamposDet.DESCRIPCION = dr.GetString(pt2);
                                oCampos.ListEstrato.Add(oCamposDet);
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
        public CEntidad RegIECOTURISMOMostrarListaItem(OracleConnection cn, CEntidad oCEntidad)
        {
            CEntidad lsCEntidad = new CEntidad();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spINFORME_ECOTURISMOMostrarItem", oCEntidad))
                {
                    if (dr != null)
                    {
                        lsCEntidad.ListInformeDetSupervisor = new List<CEntPersona>();
                        lsCEntidad.ListISUPERVISION_COORDENADAUTM = new List<CEntidad>();
                        lsCEntidad.ListISUPERVISION_DET_CAPACITACION_LOCAL = new List<CEntidad>();
                        lsCEntidad.ListISUPERVISION_DET_TARA_CAPACITACION = new List<CEntidad>();
                        lsCEntidad.ListISUPERVISION_INVESTIGACION = new List<CEntidad>();
                        lsCEntidad.ListISUPERVISION_DET_PROGRAMA = new List<CEntidad>();
                        lsCEntidad.ListISUPERVISION_IDENTMANEJOIMPACTO = new List<CEntidad>();

                        lsCEntidad.ListAvistamientoFauna = new List<CEntidad>();
                        lsCEntidad.ListISUPERVISION_FLORA_SILVESTRE = new List<CEntidad>();
                        lsCEntidad.ListISUPERVISION_CARACTESOCIAL = new List<CEntidad>();
                        lsCEntidad.ListISUPERVISION_OCARACTE_AMB01 = new List<CEntidad>();
                        lsCEntidad.ListISUPERVISION_OCARACTE_AMB02 = new List<CEntidad>();
                        lsCEntidad.ListISUPERVISION_INFRAESTRUCTURA = new List<CEntidad>();
                        lsCEntidad.ListISUPERVISION_REC_PAISAJE_CULTURAL = new List<CEntidad>();
                        lsCEntidad.ListISUPERVISION_INFRAESTRUCTURA_CONS = new List<CEntidad>();
                        lsCEntidad.ListISUPERVISION_DET_ZONIFICACION = new List<CEntidad>();
                        lsCEntidad.ListISUPERVISION_DET_EQUIPACONSECION = new List<CEntidad>();
                        lsCEntidad.ListISUPERVISION_DET_CAPACITACION_EFECT = new List<CEntidad>();
                        lsCEntidad.ListISUPERVISION_DET_CAPACITACION_ACTDES = new List<CEntidad>();
                        lsCEntidad.ListISUPERVISION_DET_GESTION = new List<CEntidad>();
                        lsCEntidad.ListISUPERVISION_INTERAMBIENTAL = new List<CEntidad>();
                        lsCEntidad.ListISUPERVISION_PROMOMARKETING = new List<CEntidad>();
                        lsCEntidad.ListISUPERVISION_MONITOEVALUACION = new List<CEntidad>();
                        lsCEntidad.ListISUPERVISION_CARACTE_ECOLOG = new List<CEntidad>();
                        lsCEntidad.ListDesplazamientoInforme = new List<CEntidad>();
                        //CEntPresupSuper ocampodet; ListISUPERVISION_INTERAMBIENTAL
                        CEntidad ocampoEnt;
                        CEntPersona ocampoPersona;
                        List<CEntidad> oListTemp;
                        if (dr.HasRows)
                        {
                            dr.Read();
                            lsCEntidad.COD_CNOTIFICACION = dr.GetString(dr.GetOrdinal("COD_CNOTIFICACION"));
                            lsCEntidad.NUMERO = dr.GetString(dr.GetOrdinal("NUMERO"));
                            lsCEntidad.FECHA_ENTREGA = dr.GetString(dr.GetOrdinal("FECHA_ENTREGA"));
                            //lsCEntidad.FECHA_RECEPCION_OD = dr.GetString(dr.GetOrdinal("FECHA_RECEPCION_OD"));
                            //lsCEntidad.FECHA_RECEPCION_SCENTRAL = dr.GetString(dr.GetOrdinal("FECHA_RECEPCION_SCENTRAL"));
                            lsCEntidad.UBIGEO = dr.GetString(dr.GetOrdinal("UBIGEO"));
                            lsCEntidad.THABILITANTE_SECTOR = dr.GetString(dr.GetOrdinal("THABILITANTE_SECTOR"));
                            lsCEntidad.THABILITANTE_COD_UBIGEO = dr.GetString(dr.GetOrdinal("THABILITANTE_COD_UBIGEO"));
                            lsCEntidad.FECHA_SUPERVISION_INICIO = dr.GetString(dr.GetOrdinal("FECHA_SUPERVISION_INICIO"));
                            lsCEntidad.FECHA_EMISION = dr.GetString(dr.GetOrdinal("FECHA_EMISION_DLINEA"));
                            lsCEntidad.FECHA_SUPERVISION_FIN = dr.GetString(dr.GetOrdinal("FECHA_SUPERVISION_FIN"));
                            lsCEntidad.LICENCIA_NUMERO = dr.GetString(dr.GetOrdinal("LICENCIA_NUMERO"));
                            lsCEntidad.LICENCIA_ESTADO = dr.GetBoolean(dr.GetOrdinal("LICENCIA_ESTADO"));
                            lsCEntidad.CUENTA_CROQUIS = dr.GetBoolean(dr.GetOrdinal("CUENTA_CROQUIS"));
                            lsCEntidad.CUENTA_SENDERO_RUTA = dr.GetBoolean(dr.GetOrdinal("CUENTA_SENDERO_RUTA"));
                            lsCEntidad.TIENE_VIAS = dr.GetBoolean(dr.GetOrdinal("TIENE_VIAS"));
                            lsCEntidad.COD_OD_REGISTRO = dr.GetString(dr.GetOrdinal("COD_OD_REGISTRO"));
                            lsCEntidad.ID_TRAMITE_SITD = dr.GetInt32(dr.GetOrdinal("ID_TRAMITE_SITD"));
                            lsCEntidad.PROMOVIDO = dr.GetBoolean(dr.GetOrdinal("PROMOVIDO"));
                            lsCEntidad.COD_ESTADO_DOC = dr.GetString(dr.GetOrdinal("COD_ESTADO_DOC"));
                            lsCEntidad.OBSERVACIONES_CONTROL = dr.GetString(dr.GetOrdinal("OBSERVACIONES_CONTROL"));
                            lsCEntidad.OBSERV_SUBSANAR = dr.GetBoolean(dr.GetOrdinal("OBSERV_SUBSANAR"));
                            ////NIVEL DE RIESGO
                            //lsCEntidad.NIVEL_RIESGO = dr.GetString(dr.GetOrdinal("NIVEL_RIESGO"));
                            //lsCEntidad.TIPO_RIESGO = dr.GetString(dr.GetOrdinal("TIPO_RIESGO"));
                            //lsCEntidad.OBSERVACION_RIESGO = dr.GetString(dr.GetOrdinal("OBSERVACION_RIESGO"));
                            lsCEntidad.USUARIO_REGISTRO = dr.GetString(dr.GetOrdinal("USUARIO_REGISTRO"));
                            lsCEntidad.USUARIO_CONTROL = dr.GetString(dr.GetOrdinal("USUARIO_CONTROL"));

                            lsCEntidad.COD_TITULAR_EJECUTA = dr.GetString(dr.GetOrdinal("COD_TITULAR_EJECUTA"));
                            lsCEntidad.TITULAR_EJECUTA = dr.GetString(dr.GetOrdinal("TITULAR_EJECUTA"));
                            lsCEntidad.COD_REGENTE_IMPLEMENTA = dr.GetString(dr.GetOrdinal("COD_REGENTE_IMPLEMENTA"));
                            lsCEntidad.REGENTE_IMPLEMENTA = dr.GetString(dr.GetOrdinal("REGENTE_IMPLEMENTA"));

                            lsCEntidad.GEOTEC_DESCRIPCION = dr.GetString(dr.GetOrdinal("GEOTEC_DESCRIPCION"));
                            lsCEntidad.GEOTEC_DRON = dr.GetBoolean(dr.GetOrdinal("GEOTEC_DRON"));
                            lsCEntidad.GEOTEC_GEOSUPERVISOR = dr.GetBoolean(dr.GetOrdinal("GEOTEC_GEOSUPERVISOR"));
                            lsCEntidad.GEOTEC_NINGUNO = dr.GetBoolean(dr.GetOrdinal("GEOTEC_NINGUNO"));
                            lsCEntidad.GEOTEC_OTROS = dr.GetBoolean(dr.GetOrdinal("GEOTEC_OTROS"));
                            #region Obligacion Titulares TH no Maderables

                            //1
                            lsCEntidad.OBLI_NM_PRESENTOPMF = dr.GetString(dr.GetOrdinal("OBLI_NM_PRESENTOPMF"));
                            lsCEntidad.OBLI_NM_PRESENTOPMF_DESCRIPCION = dr.GetString(dr.GetOrdinal("OBLI_NM_PRESENTOPMF_DESCRIPCION"));
                            //2
                            lsCEntidad.OBLI_NM_PRESENTOINFORMEEJECUCION = dr.GetString(dr.GetOrdinal("OBLI_NM_PRESENTOINFORMEEJECUCION"));
                            lsCEntidad.OBLI_NM_PRESENTOINFORMEEJECUCION_DESCRIPCION = dr.GetString(dr.GetOrdinal("OBLI_NM_PRESENTOINFORMEEJECUCION_DESCRIPCION"));
                            //3
                            lsCEntidad.OBLI_NM_PAGOAPROVECHAMIENTO = dr.GetString(dr.GetOrdinal("OBLI_NM_PAGOAPROVECHAMIENTO"));
                            lsCEntidad.OBLI_NM_PAGOAPROVECHAMIENTO_DESCRIPCION = dr.GetString(dr.GetOrdinal("OBLI_NM_PAGOAPROVECHAMIENTO_DESCRIPCION"));
                            //4
                            lsCEntidad.OBLI_NM_COMUNICOARFFSOSINFORSUSCRIPCION = dr.GetString(dr.GetOrdinal("OBLI_NM_COMUNICOARFFSOSINFORSUSCRIPCION"));
                            lsCEntidad.OBLI_NM_COMUNICOARFFSOSINFORSUSCRIPCION_DESCRIPCION = dr.GetString(dr.GetOrdinal("OBLI_NM_COMUNICOARFFSOSINFORSUSCRIPCION_DESCRIPCION"));
                            //5
                            lsCEntidad.OBLI_NM_REPORTOARFFSMINISTERIOAVISTAMIENTOS = dr.GetString(dr.GetOrdinal("OBLI_NM_REPORTOARFFSMINISTERIOAVISTAMIENTOS"));
                            lsCEntidad.OBLI_NM_REPORTOARFFSMINISTERIOAVISTAMIENTOS_DESCRIPCION = dr.GetString(dr.GetOrdinal("OBLI_NM_REPORTOARFFSMINISTERIOAVISTAMIENTOS_DESCRIPCION"));
                            //6
                            lsCEntidad.OBLI_NM_REALIZOACCIONESCUSTODIO = dr.GetString(dr.GetOrdinal("OBLI_NM_REALIZOACCIONESCUSTODIO"));
                            lsCEntidad.OBLI_NM_REALIZOACCIONESCUSTODIO_DESCRIPCION = dr.GetString(dr.GetOrdinal("OBLI_NM_REALIZOACCIONESCUSTODIO_DESCRIPCION"));
                            //7
                            lsCEntidad.OBLI_NM_FACILITODESARROLLO = dr.GetString(dr.GetOrdinal("OBLI_NM_FACILITODESARROLLO"));
                            lsCEntidad.OBLI_NM_FACILITODESARROLLO_DESCRIPCION = dr.GetString(dr.GetOrdinal("OBLI_NM_FACILITODESARROLLO_DESCRIPCION"));
                            //8
                            lsCEntidad.OBLI_NM_ASUMIOCOSTOSUPERVISIONES = dr.GetString(dr.GetOrdinal("OBLI_NM_ASUMIOCOSTOSUPERVISIONES"));
                            lsCEntidad.OBLI_NM_ASUMIOCOSTOSUPERVISIONES_DESCRIPCION = dr.GetString(dr.GetOrdinal("OBLI_NM_ASUMIOCOSTOSUPERVISIONES_DESCRIPCION"));
                            //9
                            lsCEntidad.OBLI_NM_IMPLEMENTAMECANISMOTRAZA = dr.GetString(dr.GetOrdinal("OBLI_NM_IMPLEMENTAMECANISMOTRAZA"));
                            lsCEntidad.OBLI_NM_IMPLEMENTAMECANISMOTRAZA_DESCRIPCION = dr.GetString(dr.GetOrdinal("OBLI_NM_IMPLEMENTAMECANISMOTRAZA_DESCRIPCION"));
                            //10
                            lsCEntidad.OBLI_NM_RESPETASERVIDUMBRE = dr.GetString(dr.GetOrdinal("OBLI_NM_RESPETASERVIDUMBRE"));
                            lsCEntidad.OBLI_NM_RESPETASERVIDUMBRE_DESCRIPCION = dr.GetString(dr.GetOrdinal("OBLI_NM_RESPETASERVIDUMBRE_DESCRIPCION"));
                            //11
                            lsCEntidad.OBLI_NM_ADOPTAMEDIDASEXTENSION = dr.GetString(dr.GetOrdinal("OBLI_NM_ADOPTAMEDIDASEXTENSION"));
                            lsCEntidad.OBLI_NM_ADOPTAMEDIDASEXTENSION_DESCRIPCION = dr.GetString(dr.GetOrdinal("OBLI_NM_ADOPTAMEDIDASEXTENSION_DESCRIPCION"));
                            //12
                            lsCEntidad.OBLI_NM_RESPETAVALORES = dr.GetString(dr.GetOrdinal("OBLI_NM_RESPETAVALORES"));
                            lsCEntidad.OBLI_NM_RESPETAVALORES_DESCRIPCION = dr.GetString(dr.GetOrdinal("OBLI_NM_RESPETAVALORES_DESCRIPCION"));
                            //13
                            lsCEntidad.OBLI_NM_CUMPLEMEDIDAS = dr.GetString(dr.GetOrdinal("OBLI_NM_CUMPLEMEDIDAS"));
                            lsCEntidad.OBLI_NM_CUMPLEMEDIDAS_DESCRIPCION = dr.GetString(dr.GetOrdinal("OBLI_NM_CUMPLEMEDIDAS_DESCRIPCION"));
                            //14
                            lsCEntidad.OBLI_NM_CUMPLENORMAS = dr.GetString(dr.GetOrdinal("OBLI_NM_CUMPLENORMAS"));
                            lsCEntidad.OBLI_NM_CUMPLENORMAS_DESCRIPCION = dr.GetString(dr.GetOrdinal("OBLI_NM_CUMPLENORMAS_DESCRIPCION"));
                            //15
                            lsCEntidad.OBLI_NM_MOVILIZAFRUTOPRODUCTOS = dr.GetString(dr.GetOrdinal("OBLI_NM_MOVILIZAFRUTOPRODUCTOS"));
                            lsCEntidad.OBLI_NM_MOVILIZAFRUTOPRODUCTOS_DESCRIPCION = dr.GetString(dr.GetOrdinal("OBLI_NM_MOVILIZAFRUTOPRODUCTOS_DESCRIPCION"));
                            //16
                            lsCEntidad.OBLI_NM_IMPLEMENTACIONMEDIDASCORRECTIVAS = dr.GetString(dr.GetOrdinal("OBLI_NM_IMPLEMENTACIONMEDIDASCORRECTIVAS"));
                            lsCEntidad.OBLI_NM_IMPLEMENTACIONMEDIDASCORRECTIVAS_DESCRIPCION = dr.GetString(dr.GetOrdinal("OBLI_NM_IMPLEMENTACIONMEDIDASCORRECTIVAS_DESCRIPCION"));
                            //17
                            lsCEntidad.OBLI_NM_IMPMEDCORRECRESULTADOACCIONES = dr.GetString(dr.GetOrdinal("OBLI_NM_IMPMEDCORRECRESULTADOACCIONES"));
                            lsCEntidad.OBLI_NM_IMPMEDCORRECRESULTADOACCIONES_DESCRIPCION = dr.GetString(dr.GetOrdinal("OBLI_NM_IMPMEDCORRECRESULTADOACCIONES_DESCRIPCION"));
                            //18
                            lsCEntidad.OBLI_NM_PROMUEVENBUENASPRACTICAS = dr.GetString(dr.GetOrdinal("OBLI_NM_PROMUEVENBUENASPRACTICAS"));
                            lsCEntidad.OBLI_NM_PROMUEVENBUENASPRACTICAS_DESCRIPCION = dr.GetString(dr.GetOrdinal("OBLI_NM_PROMUEVENBUENASPRACTICAS_DESCRIPCION"));
                            //19
                            lsCEntidad.OBLI_NM_PROMUEVEEQUIDAD = dr.GetString(dr.GetOrdinal("OBLI_NM_PROMUEVEEQUIDAD"));
                            lsCEntidad.OBLI_NM_PROMUEVEEQUIDAD_DESCRIPCION = dr.GetString(dr.GetOrdinal("OBLI_NM_PROMUEVEEQUIDAD_DESCRIPCION"));
                            #endregion
                            //
                            lsCEntidad.COD_IMOTIVO = dr.GetString(dr.GetOrdinal("COD_IMOTIVO"));
                            lsCEntidad.IMOTIVO = dr.GetString(dr.GetOrdinal("IMOTIVO"));
                            lsCEntidad.MAE_TIP_MOTMOTIVADA = dr.GetString(dr.GetOrdinal("MAE_TIP_MOTMOTIVADA"));
                            lsCEntidad.COD_TRAMITE_SITD = dr.GetInt32(dr.GetOrdinal("COD_TRAMITE_SITD"));
                            lsCEntidad.NUM_DREFERENCIA = dr.GetString(dr.GetOrdinal("NUM_DREFERENCIA"));
                        }
                        //Lista de Supervisor
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            int pt0 = dr.GetOrdinal("COD_SUPERVISOR");
                            int pt1 = dr.GetOrdinal("APE_PATERNO");
                            int pt2 = dr.GetOrdinal("APE_MATERNO");
                            int pt3 = dr.GetOrdinal("NOMBRES");
                            int pt4 = dr.GetOrdinal("NOMBRE_SUPERVISOR");
                            int pt5 = dr.GetOrdinal("N_DOCUMENTO");
                            int pt6 = dr.GetOrdinal("COD_DIDENTIDAD");
                            int pt7 = dr.GetOrdinal("COD_NACADEMICO");
                            int pt8 = dr.GetOrdinal("COD_DPESPECIALIDAD");
                            int pt9 = dr.GetOrdinal("COLEGIATURA_NUM");
                            int pt10 = dr.GetOrdinal("CARGO");
                            while (dr.Read())
                            {
                                ocampoPersona = new CEntPersona();
                                ocampoPersona.COD_PERSONA = dr.GetString(pt0);
                                ocampoPersona.APE_PATERNO = dr.GetString(pt1);
                                ocampoPersona.APE_MATERNO = dr.GetString(pt2);
                                ocampoPersona.NOMBRES = dr.GetString(pt3);
                                ocampoPersona.PERSONA = dr.GetString(pt4);
                                ocampoPersona.N_DOCUMENTO = dr.GetString(pt5);
                                ocampoPersona.COD_DIDENTIDAD = dr.GetString(pt6);
                                ocampoPersona.COD_NACADEMICO = dr.GetString(pt7);
                                ocampoPersona.COD_DPESPECIALIDAD = dr.GetString(pt8);
                                ocampoPersona.COLEGIATURA_NUM = dr.GetString(pt9);
                                ocampoPersona.CARGO = dr.GetString(pt10);
                                ocampoPersona.COD_PTIPO = "0000007";
                                ocampoPersona.RegEstado = 0;
                                lsCEntidad.ListInformeDetSupervisor.Add(ocampoPersona);
                            }
                        }
                        //COORDENADAS ATUM
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            int pt0 = dr.GetOrdinal("COD_SECUENCIAL");
                            int pt1 = dr.GetOrdinal("VERTICE");
                            int pt2 = dr.GetOrdinal("COORDENADA_NORTE");
                            int pt3 = dr.GetOrdinal("COORDENADA_ESTE");
                            int pt4 = dr.GetOrdinal("COORDENADA_NORTE_CAMPO");
                            int pt5 = dr.GetOrdinal("COORDENADA_SUR_CAMPO");
                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidad();
                                ocampoEnt.COD_SECUENCIAL = dr.GetInt32(pt0);
                                ocampoEnt.VERTICE = dr.GetString(pt1);
                                ocampoEnt.COORDENADA_NORTE = dr.GetInt32(pt2);
                                ocampoEnt.COORDENADA_ESTE = dr.GetInt32(pt3);
                                ocampoEnt.COORDENADA_NORTE_CAMPO = dr.GetInt32(pt4);
                                ocampoEnt.COORDENADA_SUR_CAMPO = dr.GetInt32(pt5);
                                ocampoEnt.RegEstado = 0;
                                lsCEntidad.ListISUPERVISION_COORDENADAUTM.Add(ocampoEnt);
                            }
                        }
                        //INFRA
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            int pt0 = dr.GetOrdinal("COD_SECUENCIAL");
                            int pt1 = dr.GetOrdinal("TIPO_AMBIENTE");
                            int pt2 = dr.GetOrdinal("NUM_AMBIENTE");
                            int pt3 = dr.GetOrdinal("AREA");
                            int pt4 = dr.GetOrdinal("CAPACIDAD");
                            int pt5 = dr.GetOrdinal("MATERIAL_CONSTRUCCION");
                            int pt6 = dr.GetOrdinal("USO");
                            int pt7 = dr.GetOrdinal("ESTADO_CONSERVACION");
                            int pt8 = dr.GetOrdinal("OBJETIVO");
                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidad();
                                ocampoEnt.COD_SECUENCIAL = dr.GetInt32(pt0);
                                ocampoEnt.TIPO_AMBIENTE = dr.GetString(pt1);
                                ocampoEnt.NUM_AMBIENTE = dr.GetInt32(pt2);
                                ocampoEnt.AREA = dr.GetDecimal(pt3);
                                ocampoEnt.CAPACIDAD = dr.GetString(pt4);
                                ocampoEnt.MATERIAL_CONSTRUCCION = dr.GetString(pt5);
                                ocampoEnt.USO = dr.GetString(pt6);
                                ocampoEnt.ESTADO_CONSERVACION = dr.GetString(pt7);
                                ocampoEnt.OBJETIVO = dr.GetString(pt8);
                                ocampoEnt.RegEstado = 0;
                                lsCEntidad.ListISUPERVISION_INFRAESTRUCTURA.Add(ocampoEnt);
                            }
                        }
                        //PROGRAMA
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            int pt0 = dr.GetOrdinal("COD_PROGRAMA");
                            int pt1 = dr.GetOrdinal("COD_SECUENCIAL");
                            int pt2 = dr.GetOrdinal("ACTIVIDAD_REALIZADA");
                            int pt3 = dr.GetOrdinal("FECHA_REALIZADA");
                            int pt4 = dr.GetOrdinal("NUM_PERSONA");
                            int pt5 = dr.GetOrdinal("ESTADO_DOCUMENTO");
                            int pt6 = dr.GetOrdinal("TIPO_REGISTRO");
                            int pt7 = dr.GetOrdinal("OBJETIVO");
                            int pt8 = dr.GetOrdinal("AVANCE_RESULTADO");
                            int pt9 = dr.GetOrdinal("LUGAR_CAPACITACION");
                            int pt10 = dr.GetOrdinal("OBSERVACION");
                            oListTemp = new List<CEntidad>();
                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidad();
                                ocampoEnt.COD_PROGRAMA = dr.GetInt32(pt0);
                                ocampoEnt.COD_SECUENCIAL = dr.GetInt32(pt1);
                                ocampoEnt.ACTIVIDAD_REALIZADA = dr.GetString(pt2);
                                ocampoEnt.FECHA_REALIZADA = dr.GetString(pt3);
                                ocampoEnt.NUM_PERSONA = dr.GetInt32(pt4);
                                ocampoEnt.ESTADO_DOCUMENTO = dr.GetBoolean(pt5);
                                ocampoEnt.DESC_TIPO_REGISTRO = dr.GetString(pt6);
                                ocampoEnt.OBJETIVO = dr.GetString(pt7);
                                ocampoEnt.AVANCE_RESULTADO = dr.GetString(pt8);
                                ocampoEnt.LUGAR_CAPACITACION = dr.GetString(pt9);
                                ocampoEnt.OBSERVACION = dr.GetString(pt10);
                                ocampoEnt.RegEstado = 0;
                                oListTemp.Add(ocampoEnt);
                            }
                            if (oListTemp != null && oListTemp.Count > 0)
                            {

                                lsCEntidad.ListISUPERVISION_DET_CAPACITACION_LOCAL = (from p in oListTemp where p.COD_PROGRAMA == 19 select p).ToList<CEntidad>();
                                lsCEntidad.ListISUPERVISION_DET_TARA_CAPACITACION = (from p in oListTemp where p.COD_PROGRAMA == 20 select p).ToList<CEntidad>();
                                lsCEntidad.ListISUPERVISION_INVESTIGACION = (from p in oListTemp where p.COD_PROGRAMA == 21 select p).ToList<CEntidad>();
                                lsCEntidad.ListISUPERVISION_INTERAMBIENTAL = (from p in oListTemp where p.COD_PROGRAMA == 22 select p).ToList<CEntidad>();
                                lsCEntidad.ListISUPERVISION_PROMOMARKETING = (from p in oListTemp where p.COD_PROGRAMA == 23 select p).ToList<CEntidad>();
                                lsCEntidad.ListISUPERVISION_MONITOEVALUACION = (from p in oListTemp where p.COD_PROGRAMA == 24 select p).ToList<CEntidad>();
                                lsCEntidad.ListISUPERVISION_DET_CAPACITACION_EFECT = (from p in oListTemp where p.COD_PROGRAMA == 26 select p).ToList<CEntidad>();
                                lsCEntidad.ListISUPERVISION_DET_CAPACITACION_ACTDES = (from p in oListTemp where p.COD_PROGRAMA == 27 select p).ToList<CEntidad>();
                                lsCEntidad.ListISUPERVISION_DET_GESTION = (from p in oListTemp where p.COD_PROGRAMA == 28 select p).ToList<CEntidad>();
                            }
                        }
                        //detalle PROGRAMA
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            int pt0 = dr.GetOrdinal("COD_PROGRAMA");
                            int pt1 = dr.GetOrdinal("ESTADO_PROGRAMA");
                            int pt2 = dr.GetOrdinal("OBSERVACION");
                            int pt3 = dr.GetOrdinal("TIPO");
                            int pt4 = dr.GetOrdinal("FRECUENCIA");
                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidad();
                                ocampoEnt.COD_PROGRAMA = dr.GetInt32(pt0);
                                ocampoEnt.ESTADO_PROGRAMA = dr.GetBoolean(pt1);
                                ocampoEnt.OBSERVACION = dr.GetString(pt2);
                                ocampoEnt.TIPO = dr.GetString(pt3);
                                ocampoEnt.FRECUENCIA = dr.GetString(pt4);
                                ocampoEnt.RegEstado = 2;
                                lsCEntidad.ListISUPERVISION_DET_PROGRAMA.Add(ocampoEnt);
                            }
                        }
                        //IDENTIFICACION Y MANEJO DE IMAPCTO
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            int pt0 = dr.GetOrdinal("COD_SECUENCIAL");
                            int pt1 = dr.GetOrdinal("TIPO_IMPACTO");
                            int pt2 = dr.GetOrdinal("RIESGO_POTENCIAL");
                            int pt3 = dr.GetOrdinal("ACTIVIDAD");
                            int pt4 = dr.GetOrdinal("AVANCE_RESULTADO");
                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidad();
                                ocampoEnt.COD_SECUENCIAL = dr.GetInt32(pt0);
                                ocampoEnt.TIPO_IMPACTO = dr.GetString(pt1);
                                ocampoEnt.RIESGO_POTENCIAL = dr.GetString(pt2);
                                ocampoEnt.ACTIVIDAD = dr.GetString(pt3);
                                ocampoEnt.AVANCE_RESULTADO = dr.GetString(pt4);
                                ocampoEnt.RegEstado = 0;
                                lsCEntidad.ListISUPERVISION_IDENTMANEJOIMPACTO.Add(ocampoEnt);
                            }
                        }
                        //FAUNA
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            oListTemp = new List<CEntidad>();
                            int pt0 = dr.GetOrdinal("COD_SECUENCIAL");
                            int pt1 = dr.GetOrdinal("COD_ESPECIES");
                            int pt11 = dr.GetOrdinal("ESPECIES");
                            int pt2 = dr.GetOrdinal("NUM_INDIVIDUOS");
                            int pt3 = dr.GetOrdinal("COD_TIPO_REGISTRO");
                            int pt4 = dr.GetOrdinal("COD_ESTRATO");
                            int pt5 = dr.GetOrdinal("FECHA_AVISTAMIENTO");
                            int pt6 = dr.GetOrdinal("HORA_AVISTAMIENTO");
                            int pt7 = dr.GetOrdinal("COORDENADA_NORTE");
                            int pt8 = dr.GetOrdinal("COORDENADA_ESTE");
                            int pt9 = dr.GetOrdinal("ALTITUD");
                            int pt10 = dr.GetOrdinal("OBSERVACION");
                            int pt12 = dr.GetOrdinal("DESC_TIPO_REGISTRO");
                            int pt13 = dr.GetOrdinal("DESC_ESTRATO");
                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidad();
                                ocampoEnt.COD_SECUENCIAL = dr.GetInt32(pt0);
                                ocampoEnt.COD_ESPECIES = dr.GetString(pt1);
                                ocampoEnt.ESPECIES = dr.GetString(pt11);
                                ocampoEnt.NUM_INDIVIDUOS = dr.GetInt32(pt2);
                                ocampoEnt.COD_TIPO_REGISTRO = dr.GetString(pt3);
                                ocampoEnt.COD_ESTRATO = dr.GetString(pt4);
                                ocampoEnt.FECHA_AVISTAMIENTO = dr.GetString(pt5);
                                ocampoEnt.HORA_AVISTAMIENTO = dr.GetString(pt6);
                                ocampoEnt.COORDENADA_NORTE = dr.GetInt32(pt7);
                                ocampoEnt.COORDENADA_ESTE = dr.GetInt32(pt8);
                                ocampoEnt.ALTITUD = dr.GetDecimal(pt9);
                                ocampoEnt.OBSERVACION = dr.GetString(pt10);
                                ocampoEnt.DESC_TIPO_REGISTRO = dr.GetString(pt12);
                                ocampoEnt.DESC_ESTRATO = dr.GetString(pt13);
                                ocampoEnt.RegEstado = 0;
                                lsCEntidad.ListAvistamientoFauna.Add(ocampoEnt);
                            }
                        }
                        //FLORA SILVESTRE
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            int pt0 = dr.GetOrdinal("COD_SECUENCIAL");
                            int pt1 = dr.GetOrdinal("COD_ESPECIES");
                            int pt11 = dr.GetOrdinal("ESPECIES");
                            int pt2 = dr.GetOrdinal("DAP");
                            int pt3 = dr.GetOrdinal("ALTURA_TOTAL");
                            int pt4 = dr.GetOrdinal("COORDENADA_NORTE");
                            int pt5 = dr.GetOrdinal("COORDENADA_ESTE");
                            int pt6 = dr.GetOrdinal("ESTADO_ESPECIE");
                            int pt7 = dr.GetOrdinal("OBSERVACION");
                            int pt8 = dr.GetOrdinal("TIPO_REGISTRO");
                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidad();
                                ocampoEnt.COD_SECUENCIAL = dr.GetInt32(pt0);
                                ocampoEnt.COD_ESPECIES = dr.GetString(pt1);
                                ocampoEnt.ESPECIES = dr.GetString(pt11);
                                ocampoEnt.DAP = dr.GetDecimal(pt2);
                                ocampoEnt.ALTURA_TOTAL = dr.GetDecimal(pt3);
                                ocampoEnt.COORDENADA_NORTE = dr.GetInt32(pt4);
                                ocampoEnt.COORDENADA_ESTE = dr.GetInt32(pt5);
                                ocampoEnt.ESTADO = dr.GetString(pt6);
                                ocampoEnt.OBSERVACION = dr.GetString(pt7);
                                ocampoEnt.DESC_TIPO_REGISTRO = dr.GetString(pt8);
                                ocampoEnt.RegEstado = 0;
                                lsCEntidad.ListISUPERVISION_FLORA_SILVESTRE.Add(ocampoEnt);
                            }
                        }
                        //PAISAJISTICO O CULTURAL
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            int pt0 = dr.GetOrdinal("COD_SECUENCIAL");
                            int pt1 = dr.GetOrdinal("TIPO");
                            int pt2 = dr.GetOrdinal("ESTADO_PAISAJE");
                            int pt3 = dr.GetOrdinal("NUM_VISITANTE");
                            int pt4 = dr.GetOrdinal("COORDENADA_NORTE");
                            int pt5 = dr.GetOrdinal("COORDENADA_ESTE");
                            int pt6 = dr.GetOrdinal("OBSERVACION");
                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidad();
                                ocampoEnt.COD_SECUENCIAL = dr.GetInt32(pt0);
                                ocampoEnt.TIPO = dr.GetString(pt1);
                                ocampoEnt.ESTADO = dr.GetString(pt2);
                                ocampoEnt.NUM_VISITANTE = dr.GetString(pt3);
                                ocampoEnt.COORDENADA_NORTE = dr.GetInt32(pt4);
                                ocampoEnt.COORDENADA_ESTE = dr.GetInt32(pt5);
                                ocampoEnt.OBSERVACION = dr.GetString(pt6);
                                ocampoEnt.RegEstado = 0;
                                lsCEntidad.ListISUPERVISION_REC_PAISAJE_CULTURAL.Add(ocampoEnt);
                            }
                        }
                        //PAISAJISTICO O CULTURAL
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            int pt0 = dr.GetOrdinal("COD_PROGRAMA");
                            int pt1 = dr.GetOrdinal("COD_SECUENCIAL");
                            int pt2 = dr.GetOrdinal("COD_ESPECIES");
                            int pt22 = dr.GetOrdinal("ESPECIES");
                            int pt3 = dr.GetOrdinal("ACTIVIDAD");
                            int pt4 = dr.GetOrdinal("ESTA_AUTORIZADO");
                            int pt5 = dr.GetOrdinal("DOCUMENTOS_AFORESTAL");
                            int pt6 = dr.GetOrdinal("OBSERVACION");
                            oListTemp = new List<CEntidad>();
                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidad();
                                ocampoEnt.COD_PROGRAMA = dr.GetInt32(pt0);
                                ocampoEnt.COD_SECUENCIAL = dr.GetInt32(pt1);
                                ocampoEnt.COD_ESPECIES = dr.GetString(pt2);
                                ocampoEnt.ESPECIES = dr.GetString(pt22);
                                ocampoEnt.ACTIVIDAD = dr.GetString(pt3);
                                ocampoEnt.ESTA_AUTORIZADO = dr.GetBoolean(pt4);
                                ocampoEnt.DOCUMENTOS_AFORESTAL = dr.GetString(pt5);
                                ocampoEnt.OBSERVACION = dr.GetString(pt6);
                                ocampoEnt.RegEstado = 0;
                                oListTemp.Add(ocampoEnt);
                            }
                            if (oListTemp != null && oListTemp.Count > 0)
                            {

                                lsCEntidad.ListISUPERVISION_OCARACTE_AMB01 = (from p in oListTemp where p.COD_PROGRAMA == 15 select p).ToList<CEntidad>();
                                lsCEntidad.ListISUPERVISION_OCARACTE_AMB02 = (from p in oListTemp where p.COD_PROGRAMA == 16 select p).ToList<CEntidad>();
                                lsCEntidad.ListISUPERVISION_CARACTESOCIAL = (from p in oListTemp where p.COD_PROGRAMA == 17 select p).ToList<CEntidad>();
                                lsCEntidad.ListISUPERVISION_CARACTE_ECOLOG = (from p in oListTemp where p.COD_PROGRAMA == 18 select p).ToList<CEntidad>();
                            }
                        }
                        //ZONIFICACION
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            int pt0 = dr.GetOrdinal("COD_SECUENCIAL");
                            int pt1 = dr.GetOrdinal("NOMBRE_ZONA");
                            int pt2 = dr.GetOrdinal("CARACTERISTICA");
                            int pt3 = dr.GetOrdinal("COORDENADA_NORTE");
                            int pt4 = dr.GetOrdinal("COORDENADA_ESTE");
                            int pt5 = dr.GetOrdinal("TIPO_SENALIZACION");
                            int pt6 = dr.GetOrdinal("TIPO_DELIMITACION");
                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidad();
                                ocampoEnt.COD_SECUENCIAL = dr.GetInt32(pt0);
                                ocampoEnt.NOMBRE_ZONA = dr.GetString(pt1);
                                ocampoEnt.CARACTERISTICA = dr.GetString(pt2);
                                ocampoEnt.COORDENADA_NORTE = dr.GetInt32(pt3);
                                ocampoEnt.COORDENADA_ESTE = dr.GetInt32(pt4);
                                ocampoEnt.TIPO_SENALIZACION = dr.GetString(pt5);
                                ocampoEnt.TIPO_DELIMITACION = dr.GetString(pt6);
                                ocampoEnt.RegEstado = 0;
                                lsCEntidad.ListISUPERVISION_DET_ZONIFICACION.Add(ocampoEnt);
                            }
                        }
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            int pt0 = dr.GetOrdinal("COD_SECUENCIAL");
                            int pt1 = dr.GetOrdinal("DESCRIPCION");
                            int pt2 = dr.GetOrdinal("NUM_AMBIENTE");
                            int pt3 = dr.GetOrdinal("USO");
                            int pt4 = dr.GetOrdinal("ESTADO_CONSERVACION");
                            int pt5 = dr.GetOrdinal("OBJETIVO");
                            int pt6 = dr.GetOrdinal("OBSERVACION");
                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidad();
                                ocampoEnt.COD_SECUENCIAL = dr.GetInt32(pt0);
                                ocampoEnt.DESCRIPCION = dr.GetString(pt1);
                                ocampoEnt.NUM_AMBIENTE = dr.GetInt32(pt2);
                                ocampoEnt.USO = dr.GetString(pt3);
                                ocampoEnt.ESTADO_CONSERVACION = dr.GetString(pt4);
                                ocampoEnt.OBJETIVO = dr.GetString(pt5);
                                ocampoEnt.OBSERVACION = dr.GetString(pt6);
                                ocampoEnt.RegEstado = 0;
                                lsCEntidad.ListISUPERVISION_DET_EQUIPACONSECION.Add(ocampoEnt);
                            }
                        }

                        #region ListDesplazamiento
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidad();
                                ocampoEnt.COD_DESPLAZAMIENTO = dr["COD_DESPLAZAMIENTO"].ToString();
                                ocampoEnt.COORDENADA_ESTE = Int32.Parse(dr["PTOI_COORDENADA_ESTE"].ToString());
                                ocampoEnt.COORDENADA_NORTE = Int32.Parse(dr["PTOI_COORDENADA_NORTE"].ToString());
                                ocampoEnt.COORDENADA_ESTE_CAMPO = Int32.Parse(dr["PTOF_COORDENADA_ESTE"].ToString());
                                ocampoEnt.COORDENADA_NORTE_CAMPO = Int32.Parse(dr["PTOF_COORDENADA_NORTE"].ToString());
                                ocampoEnt.OBSERVACION = dr["OBSERVACION"].ToString();
                                ocampoEnt.TipoVia = dr["TIPO"].ToString();
                                ocampoEnt.RegEstado = 0;
                                lsCEntidad.ListDesplazamientoInforme.Add(ocampoEnt);
                            }
                        }
                        #endregion
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
        public String RegISProyectoGenerar(OracleConnection cn, CEntidad oCEntidad)
        {
            String OUTPUTPARAM01 = "";
            try
            {
                //Grabando Cabecera
                using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, null, "HERR_OSINFOR_ERP_MIGRACION.spISProyecto_Generar", oCEntidad))
                {
                    cmd.ExecuteNonQuery();
                    OUTPUTPARAM01 = (String)cmd.Parameters["OUTPUTPARAM01"].Value;
                }
                return OUTPUTPARAM01;
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
        public List<CEntidad> RegMostrar_Requerimiento(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spzRequerimientos", oCEntidad))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            int p1 = dr.GetOrdinal("COD_REQUE");
                            int p3 = dr.GetOrdinal("COD_THABILITANTE");
                            int p4 = dr.GetOrdinal("NUM_THABILITANTE");
                            int p5 = dr.GetOrdinal("DES_THANILITANTE");
                            int p6 = dr.GetOrdinal("NUM_POA");
                            int p7 = dr.GetOrdinal("MODALIDAD_TIPO");

                            CEntidad oCampos;
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                oCampos.COD_REQUE = dr.GetInt32(p1);
                                oCampos.COD_THABILITANTE = dr.GetString(p3);
                                oCampos.NUM_THABILITANTE = dr.GetString(p4);
                                oCampos.DESCRIPCION = dr.GetString(p5);
                                oCampos.NUM_POA = Int32.Parse(dr.GetString(p6));
                                oCampos.MODALIDAD_TIPO = dr.GetString(p7);
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
        public List<CEntidad> RegMostrar_Informe(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spReporteFoto", oCEntidad))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            int p1 = dr.GetOrdinal("COD_INFORME");
                            int p2 = dr.GetOrdinal("NUMERO");
                            int p3 = dr.GetOrdinal("NUM_CNOTIFICACION");
                            int p4 = dr.GetOrdinal("NUM_THABILITANTE");
                            int p5 = dr.GetOrdinal("TITULAR");
                            int p6 = dr.GetOrdinal("MODALIDAD_TIPO");

                            CEntidad oCampos;
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                oCampos.COD_INFORME = dr.GetString(p1);
                                oCampos.NUMERO = dr.GetString(p2);
                                oCampos.NUM_CNOTIFICACION = dr.GetString(p3);
                                oCampos.NUM_THABILITANTE = dr.GetString(p4);
                                oCampos.NOMBRES = dr.GetString(p5);
                                oCampos.MODALIDAD_TIPO = dr.GetString(p6);
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
        public List<CEntidad> RegMostrar_Informe_fotos(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spReporteFoto", oCEntidad))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            int p1 = dr.GetOrdinal("COD_INFORME_FOTOS");
                            int p2 = dr.GetOrdinal("COD_INFORME");
                            int p3 = dr.GetOrdinal("APELLIDOS_NOMBRES");
                            int p4 = dr.GetOrdinal("URL_FOTO");
                            int p5 = dr.GetOrdinal("FUENTE");
                            int p6 = dr.GetOrdinal("FECHA");
                            int p7 = dr.GetOrdinal("DISPOSITIVO");
                            int p8 = dr.GetOrdinal("DESCRIPCION");

                            CEntidad oCampos;
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                oCampos.COD_INFORME_FOTOS = dr.GetString(p1);
                                oCampos.COD_INFORME = dr.GetString(p2);
                                oCampos.NOMBRES = dr.GetString(p3);
                                oCampos.URL_FOTO = dr.GetString(p4);
                                oCampos.FUENTE_FOTO = dr.GetString(p5);
                                oCampos.FECHA = dr.GetString(p6);
                                oCampos.DISP_FOTO = dr.GetString(p7);
                                oCampos.DESC_ESPECIES = dr.GetString(p8);
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
        public List<CEntidad> RegMostrar_Informe_fotos_Obs(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC_BD_OBSERVATORIO_MIGRACION.spReporteFoto", oCEntidad))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            int p1 = dr.GetOrdinal("COD_INFORME_FOTOS");
                            int p2 = dr.GetOrdinal("COD_INFORME");
                            int p3 = dr.GetOrdinal("APELLIDOS_NOMBRES");
                            int p4 = dr.GetOrdinal("URL_FOTO");
                            int p5 = dr.GetOrdinal("FUENTE");
                            int p6 = dr.GetOrdinal("FECHA");
                            int p7 = dr.GetOrdinal("DISPOSITIVO");
                            int p8 = dr.GetOrdinal("DESCRIPCION");

                            CEntidad oCampos;
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                oCampos.COD_INFORME_FOTOS = dr.GetString(p1);
                                oCampos.COD_INFORME = dr.GetString(p2);
                                oCampos.NOMBRES = dr.GetString(p3);
                                oCampos.URL_FOTO = dr.GetString(p4);
                                oCampos.FUENTE_FOTO = dr.GetString(p5);
                                oCampos.FECHA = dr.GetString(p6);
                                oCampos.DISP_FOTO = dr.GetString(p7);
                                oCampos.DESC_ESPECIES = dr.GetString(p8);
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
        public CEntidad RegMostListPOAs(OracleConnection cn, CEntidad oCEntidad)
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
                        //Lista de POAS
                        lsDetDetalle = new List<CEntidad>();
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("NUM_POA");
                            int pt2 = dr.GetOrdinal("POA");
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.NUM_POA = dr.GetInt32(pt1);
                                oCamposDet.POA = dr.GetString(pt2);
                                oCamposDet.COD_THABILITANTE = dr.GetString(dr.GetOrdinal("COD_THABILITANTE"));

                                oCamposDet.RegEstado = 0;
                                lsDetDetalle.Add(oCamposDet);
                            }
                        }
                        oCampos.ListPOAs = lsDetDetalle;
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
        public Int32 RegPreProcesarObservatorio(OracleConnection cn, CEntidad oCEntidad)
        {
            OracleTransaction tr = null;
            Int32 OUTPUTPARAM03 = 0;
            try
            {
                tr = cn.BeginTransaction();
                //Grabando Cabecera
                using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, tr, "HERR_OSINFOR_ERP_MIGRACION.spPROCESAMIENTO_OBSERVATORIO_v3", oCEntidad))
                {
                    cmd.ExecuteNonQuery();
                    OUTPUTPARAM03 = Int32.Parse(cmd.Parameters["OUTPUTPARAM03"].Value.ToString());
                }
                tr.Commit();
                return OUTPUTPARAM03;
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public String RegAjustarMuestra(OracleConnection cn, CEntidad oCEntidad)
        {
            OracleTransaction tr = null;
            String OUTPUTPARAM01 = "";
            try
            {
                tr = cn.BeginTransaction();
                //Grabando Cabecera
                using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spISUPERVISION_AJUSTAR_MUESTRA", oCEntidad))
                {
                    cmd.ExecuteNonQuery();
                    OUTPUTPARAM01 = (String)cmd.Parameters["OUTPUTPARAM01"].Value;
                }
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public CEntidad RegIFaunaMostrarListaItem(OracleConnection cn, String codInforme)
        {
            CEntidad lsCEntidad = new CEntidad();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spIFAUNAMostrarItem", codInforme))
                {
                    if (dr != null)
                    {
                        lsCEntidad.ListEliTABLA = new List<CEntidad>();

                        lsCEntidad.ListInformeDetSupervisor = new List<CEntPersona>();
                        lsCEntidad.ListCNotificaciones = new List<CEntidad>();
                        lsCEntidad.ListFotos = new List<CEntidad>();
                        lsCEntidad.ListISUPERVISION_DET_PROGRAMA = new List<CEntidad>();
                        lsCEntidad.ListISUPERVISION_COORDENADAUTM = new List<CEntidad>();
                        lsCEntidad.ListISUPERVISION_INFRAESTRUCTURA = new List<CEntidad>();
                        lsCEntidad.ListISUPERVISION_DET_ZONIFICACION = new List<CEntidad>();
                        lsCEntidad.ListAvistamientoFauna = new List<CEntidad>();
                        lsCEntidad.ListISUPERVISION_DET_CAPACITACION_ACTDES = new List<CEntidad>();
                        lsCEntidad.ListOCEjecucionActividad = new List<CEntidad>();
                        lsCEntidad.ListOCActosTercero = new List<CEntidad>();
                        lsCEntidad.ListISUPERVISION_IDENTMANEJOIMPACTO = new List<CEntidad>();
                        lsCEntidad.ListISupervFaunaAprov = new List<CEntidad>();

                        CEntidad ocampoEnt;
                        CEntPersona ocampoEntPersona;
                        if (dr.HasRows)
                        {
                            dr.Read();
                            lsCEntidad.COD_ITIPO = dr.GetString(dr.GetOrdinal("COD_ITIPO"));
                            lsCEntidad.COD_CNOTIFICACION = dr.GetString(dr.GetOrdinal("COD_CNOTIFICACION"));
                            lsCEntidad.NUMERO = dr.GetString(dr.GetOrdinal("NUMERO"));
                            lsCEntidad.COD_DIRECTOR = dr.GetString(dr.GetOrdinal("COD_DIRECTOR"));
                            lsCEntidad.NOMBRE_DIRECTOR = dr.GetString(dr.GetOrdinal("APELLIDOS_NOMBRES"));
                            lsCEntidad.COD_IMOTIVO = dr.GetString(dr.GetOrdinal("COD_IMOTIVO"));
                            lsCEntidad.FECHA_ENTREGA = dr.GetString(dr.GetOrdinal("FECHA_ENTREGA"));
                            lsCEntidad.FECHA_RECEPCION_OD = dr.GetString(dr.GetOrdinal("FECHA_RECEPCION_OD"));
                            lsCEntidad.FECHA_RECEPCION_SCENTRAL = dr.GetString(dr.GetOrdinal("FECHA_RECEPCION_SCENTRAL"));
                            lsCEntidad.UBIGEO = dr.GetString(dr.GetOrdinal("UBIGEO"));
                            lsCEntidad.NUM_POA = dr.GetInt32(dr.GetOrdinal("NUM_POA"));
                            lsCEntidad.NUM_THABILITANTE = dr.GetString(dr.GetOrdinal("NUM_THABILITANTE"));
                            lsCEntidad.OBSERVACION = dr.GetString(dr.GetOrdinal("OBSERVACION"));
                            lsCEntidad.THABILITANTE_SECTOR = dr.GetString(dr.GetOrdinal("THABILITANTE_SECTOR"));
                            lsCEntidad.THABILITANTE_COD_UBIGEO = dr.GetString(dr.GetOrdinal("THABILITANTE_COD_UBIGEO"));
                            lsCEntidad.PHUAYRONA_ESTADO = dr.GetString(dr.GetOrdinal("PHUAYRONA_ESTADO"));
                            lsCEntidad.NUM_CNOTIFICACION = dr.GetString(dr.GetOrdinal("NUM_CNOTIFICACION"));
                            lsCEntidad.FECHA_SUPERVISION_INICIO = dr.GetString(dr.GetOrdinal("FECHA_SUPERVISION_INICIO"));
                            lsCEntidad.FECHA_SUPERVISION_FIN = dr.GetString(dr.GetOrdinal("FECHA_SUPERVISION_FIN"));
                            lsCEntidad.ASUNTO = dr.GetString(dr.GetOrdinal("ASUNTO"));
                            lsCEntidad.CONTENIDO = dr.GetString(dr.GetOrdinal("CONTENIDO"));
                            lsCEntidad.AREA_RECORRIDA = dr.GetDecimal(dr.GetOrdinal("AREA_RECORRIDA"));
                            lsCEntidad.CUENTA_MILEGAL = dr.GetBoolean(dr.GetOrdinal("CUENTA_MILEGAL"));
                            lsCEntidad.AREA_MILEGAL = dr.GetDecimal(dr.GetOrdinal("AREA_MILEGAL"));
                            lsCEntidad.OBSERVACION_MILEGAL = dr.GetString(dr.GetOrdinal("OBSERVACION_MILEGAL"));//COD_DLINEA
                            lsCEntidad.COD_DLINEA = dr.GetString(dr.GetOrdinal("COD_DLINEA"));
                            lsCEntidad.COD_ESTADO_DOC = dr.GetString(dr.GetOrdinal("COD_ESTADO_DOC"));
                            lsCEntidad.OBSERVACIONES_CONTROL = dr.GetString(dr.GetOrdinal("OBSERVACIONES_CONTROL"));
                            lsCEntidad.OBSERV_SUBSANAR = dr.GetBoolean(dr.GetOrdinal("OBSERV_SUBSANAR"));
                            lsCEntidad.COD_OD_REGISTRO = dr.GetString(dr.GetOrdinal("COD_OD_REGISTRO"));
                            lsCEntidad.PLAN_AMAZONAS = dr.GetBoolean(dr.GetOrdinal("PLAN_AMAZONAS"));
                            lsCEntidad.ANIO_PLAN_AMAZONAS = dr.GetString(dr.GetOrdinal("ANIO_PLAN_AMAZONAS"));
                            lsCEntidad.ID_TRAMITE_SITD = dr.GetInt32(dr.GetOrdinal("ID_TRAMITE_SITD"));
                            lsCEntidad.PROMOVIDO = dr.GetBoolean(dr.GetOrdinal("PROMOVIDO"));
                            lsCEntidad.COD_REQUE = dr.GetInt32(dr.GetOrdinal("COD_REQ"));
                            lsCEntidad.CONCLUSION = dr.GetString(dr.GetOrdinal("CONCLUSION"));
                            lsCEntidad.PUBLICAR = dr.GetBoolean(dr.GetOrdinal("PUBLICAR"));
                            lsCEntidad.REALIZADO_VEEDORFORESTAL = dr.GetBoolean(dr.GetOrdinal("REALIZADO_VEEDORFORESTAL"));
                            lsCEntidad.COD_TECNICO = dr.GetString(dr.GetOrdinal("COD_TECNICO"));
                            lsCEntidad.NOMBRE_TECNICO = dr.GetString(dr.GetOrdinal("NOMBRE_TECNICO"));
                            lsCEntidad.USUARIO_REGISTRO = dr.GetString(dr.GetOrdinal("USUARIO_REGISTRO"));
                            lsCEntidad.USUARIO_CONTROL = dr.GetString(dr.GetOrdinal("USUARIO_CONTROL"));

                            lsCEntidad.COD_TITULAR_EJECUTA = dr.GetString(dr.GetOrdinal("COD_TITULAR_EJECUTA"));
                            lsCEntidad.TITULAR_EJECUTA = dr.GetString(dr.GetOrdinal("TITULAR_EJECUTA"));
                            lsCEntidad.COD_REGENTE_IMPLEMENTA = dr.GetString(dr.GetOrdinal("COD_REGENTE_IMPLEMENTA"));
                            lsCEntidad.REGENTE_IMPLEMENTA = dr.GetString(dr.GetOrdinal("REGENTE_IMPLEMENTA"));
                        }
                        //Lista de Cartas de Notificación enlazadas
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidad();
                                ocampoEnt.COD_CNOTIFICACION = dr["COD_CNOTIFICACION"].ToString();
                                ocampoEnt.NUM_THABILITANTE = dr["NUM_THABILITANTE"].ToString();
                                ocampoEnt.NUM_CNOTIFICACION = dr["NUM_CNOTIFICACION"].ToString();
                                ocampoEnt.POA = dr["POA"].ToString();
                                ocampoEnt.RegEstado = 0;
                                lsCEntidad.ListCNotificaciones.Add(ocampoEnt);
                            }
                        }
                        //Lista de Supervisor
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                ocampoEntPersona = new CEntPersona();
                                ocampoEntPersona.COD_PERSONA = dr["COD_SUPERVISOR"].ToString();
                                ocampoEntPersona.APE_PATERNO = dr["APE_PATERNO"].ToString();
                                ocampoEntPersona.APE_MATERNO = dr["APE_MATERNO"].ToString();
                                ocampoEntPersona.NOMBRES = dr["NOMBRES"].ToString();
                                ocampoEntPersona.PERSONA = dr["NOMBRE_SUPERVISOR"].ToString();
                                ocampoEntPersona.N_DOCUMENTO = dr["N_DOCUMENTO"].ToString();
                                ocampoEntPersona.COD_DIDENTIDAD = dr["COD_DIDENTIDAD"].ToString();
                                ocampoEntPersona.COD_NACADEMICO = dr["COD_NACADEMICO"].ToString();
                                ocampoEntPersona.COD_DPESPECIALIDAD = dr["COD_DPESPECIALIDAD"].ToString();
                                ocampoEntPersona.COLEGIATURA_NUM = dr["COLEGIATURA_NUM"].ToString();
                                ocampoEntPersona.CARGO = dr["CARGO"].ToString();
                                ocampoEntPersona.COD_PTIPO = "0000007";
                                ocampoEntPersona.RegEstado = 0;
                                lsCEntidad.ListInformeDetSupervisor.Add(ocampoEntPersona);
                            }
                        }
                        // INFORME FOTOS
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                CEntidad ocampo = new CEntidad();
                                ocampo.COD_INFORME_FOTOS = dr["COD_INFORME_FOTOS"].ToString();
                                ocampo.COD_INFORME = dr["COD_INFORME"].ToString();
                                ocampo.COD_THABILITANTE = dr["COD_THABILITANTE"].ToString();
                                ocampo.COD_UCUENTA = dr["COD_UCUENTA"].ToString();
                                ocampo.URL_FOTO = dr["URL_FOTO"].ToString();
                                ocampo.DESC_FOTO = dr["DESCRIPCION"].ToString();
                                ocampo.FUENTE_FOTO = dr["FUENTE"].ToString();
                                ocampo.DISP_FOTO = dr["DISPOSITIVO"].ToString();
                                ocampo.NUMERO = lsCEntidad.NUMERO;
                                ocampo.NUM_THABILITANTE = lsCEntidad.NUM_THABILITANTE;
                                ocampo.FECHA = dr["FECHA"].ToString();
                                ocampo.RegEstado = 0;
                                lsCEntidad.ListFotos.Add(ocampo);
                            }
                        }
                        //detalle PROGRAMA
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidad();
                                ocampoEnt.COD_PROGRAMA = dr.GetInt32(dr.GetOrdinal("COD_PROGRAMA"));
                                ocampoEnt.ESTADO_PROGRAMA = dr.GetBoolean(dr.GetOrdinal("ESTADO_PROGRAMA"));
                                ocampoEnt.OBSERVACION = dr.GetString(dr.GetOrdinal("OBSERVACION"));
                                ocampoEnt.TIPO = dr.GetString(dr.GetOrdinal("TIPO"));
                                ocampoEnt.FRECUENCIA = dr.GetString(dr.GetOrdinal("FRECUENCIA"));
                                ocampoEnt.RegEstado = 2;
                                lsCEntidad.ListISUPERVISION_DET_PROGRAMA.Add(ocampoEnt);
                            }
                        }
                        //COORDENADAS ATUM
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidad();
                                ocampoEnt.COD_SECUENCIAL = dr.GetInt32(dr.GetOrdinal("COD_SECUENCIAL"));
                                ocampoEnt.VERTICE = dr.GetString(dr.GetOrdinal("VERTICE"));
                                ocampoEnt.COORDENADA_NORTE = dr.GetInt32(dr.GetOrdinal("COORDENADA_NORTE"));
                                ocampoEnt.COORDENADA_ESTE = dr.GetInt32(dr.GetOrdinal("COORDENADA_ESTE"));
                                ocampoEnt.COORDENADA_NORTE_CAMPO = dr.GetInt32(dr.GetOrdinal("COORDENADA_NORTE_CAMPO"));
                                ocampoEnt.COORDENADA_SUR_CAMPO = dr.GetInt32(dr.GetOrdinal("COORDENADA_SUR_CAMPO"));
                                ocampoEnt.NUM_POA = dr.GetInt32(dr.GetOrdinal("NUM_POA"));
                                ocampoEnt.RegEstado = 0;
                                lsCEntidad.ListISUPERVISION_COORDENADAUTM.Add(ocampoEnt);
                            }
                        }
                        //INFRAESTRUCTURA IMPLEMENTADA
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidad();
                                ocampoEnt.COD_SECUENCIAL = dr.GetInt32(dr.GetOrdinal("COD_SECUENCIAL"));
                                ocampoEnt.DESCRIPCION = dr.GetString(dr.GetOrdinal("TIPO_AMBIENTE"));
                                ocampoEnt.AREA = dr.GetDecimal(dr.GetOrdinal("AREA"));
                                ocampoEnt.USO = dr.GetString(dr.GetOrdinal("USO"));
                                ocampoEnt.ESTADO_CONSERVACION = dr.GetString(dr.GetOrdinal("ESTADO_CONSERVACION"));
                                ocampoEnt.OBJETIVO = dr.GetString(dr.GetOrdinal("OBJETIVO"));
                                ocampoEnt.NUM_POA = dr.GetInt32(dr.GetOrdinal("NUM_POA"));
                                ocampoEnt.RegEstado = 0;
                                lsCEntidad.ListISUPERVISION_INFRAESTRUCTURA.Add(ocampoEnt);
                            }
                        }
                        //ZONIFICACION
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidad();
                                ocampoEnt.COD_SECUENCIAL = dr.GetInt32(dr.GetOrdinal("COD_SECUENCIAL"));
                                ocampoEnt.NOMBRE_ZONA = dr.GetString(dr.GetOrdinal("NOMBRE_ZONA"));
                                ocampoEnt.CARACTERISTICA = dr.GetString(dr.GetOrdinal("CARACTERISTICA"));
                                ocampoEnt.COORDENADA_NORTE = dr.GetInt32(dr.GetOrdinal("COORDENADA_NORTE"));
                                ocampoEnt.COORDENADA_ESTE = dr.GetInt32(dr.GetOrdinal("COORDENADA_ESTE"));
                                ocampoEnt.TIPO_SENALIZACION = dr.GetString(dr.GetOrdinal("TIPO_SENALIZACION"));
                                ocampoEnt.TIPO_DELIMITACION = dr.GetString(dr.GetOrdinal("TIPO_DELIMITACION"));
                                ocampoEnt.NUM_POA = dr.GetInt32(dr.GetOrdinal("NUM_POA"));
                                ocampoEnt.RegEstado = 0;
                                lsCEntidad.ListISUPERVISION_DET_ZONIFICACION.Add(ocampoEnt);
                            }
                        }
                        // FAUNA SILVESTRE
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidad();
                                ocampoEnt.COD_ESPECIES = dr["COD_ESPECIES"].ToString();
                                ocampoEnt.DESC_ESPECIES = dr["DESC_ESPECIES"].ToString();
                                ocampoEnt.COD_SECUENCIAL = Int32.Parse(dr["COD_SECUENCIAL"].ToString());
                                ocampoEnt.NOMBRE_COMUN = dr["NOMBRE_COMUN"].ToString();
                                ocampoEnt.NUM_INDIVIDUOS = Int32.Parse(dr["NUM_INDIVIDUOS"].ToString());
                                ocampoEnt.COD_TIPO_REGISTRO = dr["COD_TIPO_REGISTRO"].ToString();
                                ocampoEnt.DESC_TIPO_REGISTRO = dr["DESC_TIPO_REGISTRO"].ToString();
                                ocampoEnt.COD_ESTRATO = dr["COD_ESTRATO"].ToString();
                                ocampoEnt.DESC_ESTRATO = dr["DESC_ESTRATO"].ToString();
                                ocampoEnt.FECHA_AVISTAMIENTO = dr["FECHA_AVISTAMIENTO"].ToString();
                                ocampoEnt.HORA_AVISTAMIENTO = dr["HORA_AVISTAMIENTO"].ToString();
                                ocampoEnt.COORDENADA_ESTE = Int32.Parse(dr["COORDENADA_ESTE"].ToString());
                                ocampoEnt.COORDENADA_NORTE = Int32.Parse(dr["COORDENADA_NORTE"].ToString());
                                ocampoEnt.ALTITUD = Decimal.Parse(dr["ALTITUD"].ToString());
                                ocampoEnt.OBSERVACION = dr["DESCRIPCION"].ToString();
                                ocampoEnt.NUM_POA = Int32.Parse(dr["NUM_POA"].ToString());
                                ocampoEnt.RegEstado = 0;
                                lsCEntidad.ListAvistamientoFauna.Add(ocampoEnt);
                            }
                        }
                        //MEDIDAS DE RESPONSABILIDAD SOCIAL
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidad();
                                ocampoEnt.COD_PROGRAMA = dr.GetInt32(dr.GetOrdinal("COD_PROGRAMA"));
                                ocampoEnt.COD_SECUENCIAL = dr.GetInt32(dr.GetOrdinal("COD_SECUENCIAL"));
                                ocampoEnt.ACTIVIDAD_REALIZADA = dr.GetString(dr.GetOrdinal("ACTIVIDAD_REALIZADA"));
                                ocampoEnt.FECHA_REALIZADA = dr.GetString(dr.GetOrdinal("FECHA_REALIZADA"));
                                ocampoEnt.NUM_PERSONA = dr.GetInt32(dr.GetOrdinal("NUM_PERSONA"));
                                ocampoEnt.ESTADO_DOCUMENTO = dr.GetBoolean(dr.GetOrdinal("ESTADO_DOCUMENTO"));
                                ocampoEnt.DESC_TIPO_REGISTRO = dr.GetString(dr.GetOrdinal("TIPO_REGISTRO"));
                                ocampoEnt.OBJETIVO = dr.GetString(dr.GetOrdinal("OBJETIVO"));
                                ocampoEnt.AVANCE_RESULTADO = dr.GetString(dr.GetOrdinal("AVANCE_RESULTADO"));
                                ocampoEnt.LUGAR_CAPACITACION = dr.GetString(dr.GetOrdinal("LUGAR_CAPACITACION"));
                                ocampoEnt.OBSERVACION = dr.GetString(dr.GetOrdinal("OBSERVACION"));
                                ocampoEnt.RegEstado = 0;
                                lsCEntidad.ListISUPERVISION_DET_CAPACITACION_ACTDES.Add(ocampoEnt);
                            }
                        }
                        //OBLIGACIONES CONTRACTUALES
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            List<CEntidad> oListTempOblicagContractual = new List<CEntidad>();
                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidad();
                                ocampoEnt.COD_OCONTRACTUAL = dr["COD_OCONTRACTUAL"].ToString();
                                ocampoEnt.COD_SECUENCIAL = Int32.Parse(dr["COD_SECUENCIAL"].ToString());
                                ocampoEnt.COD_ESPECIES = dr["COD_ESPECIES"].ToString();
                                ocampoEnt.ESPECIES = dr["ESPECIES"].ToString();
                                ocampoEnt.ACTIVIDAD_ACTOS = dr["ACTIVIDAD_ACTOS"].ToString();
                                ocampoEnt.ESTA_AUTORIZADO = Boolean.Parse(dr["ESTA_AUTORIZADO"].ToString());
                                ocampoEnt.DOCUMENTOS_AFORESTAL = dr["DOCUMENTOS_AFORESTAL"].ToString();
                                ocampoEnt.OBSERVACION = dr["OBSERVACION"].ToString();
                                ocampoEnt.RegEstado = 0;
                                oListTempOblicagContractual.Add(ocampoEnt);
                            }
                            if (oListTempOblicagContractual != null && oListTempOblicagContractual.Count > 0)
                            {

                                lsCEntidad.ListOCEjecucionActividad = (from p in oListTempOblicagContractual where p.COD_OCONTRACTUAL == "01" select p).ToList<CEntidad>();
                                lsCEntidad.ListOCActosTercero = (from p in oListTempOblicagContractual where p.COD_OCONTRACTUAL == "03" select p).ToList<CEntidad>();
                            }
                        }
                        //MEDIDAS DE PREVENCIÓN Y MITIGACIÓN DE IMPACTOS
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidad();
                                ocampoEnt.COD_SECUENCIAL = dr.GetInt32(dr.GetOrdinal("COD_SECUENCIAL"));
                                ocampoEnt.TIPO_IMPACTO = dr.GetString(dr.GetOrdinal("TIPO_IMPACTO"));
                                ocampoEnt.RIESGO_POTENCIAL = dr.GetString(dr.GetOrdinal("RIESGO_POTENCIAL"));
                                ocampoEnt.ACTIVIDAD = dr.GetString(dr.GetOrdinal("ACTIVIDAD"));
                                ocampoEnt.AVANCE_RESULTADO = dr.GetString(dr.GetOrdinal("AVANCE_RESULTADO"));
                                ocampoEnt.RegEstado = 0;
                                lsCEntidad.ListISUPERVISION_IDENTMANEJOIMPACTO.Add(ocampoEnt);
                            }
                        }
                        //APROVECHAMIENTO SOSTENIBLE
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidad();
                                ocampoEnt.NUM_POA = dr.GetInt32(dr.GetOrdinal("NUM_POA"));
                                ocampoEnt.COD_ESPECIES = dr.GetString(dr.GetOrdinal("COD_ESPECIES"));
                                ocampoEnt.PERIODO = dr.GetString(dr.GetOrdinal("PERIODO"));
                                ocampoEnt.CUOTA_SACA = dr.GetInt32(dr.GetOrdinal("CUOTA_SACA"));
                                ocampoEnt.PERSONAL = dr.GetString(dr.GetOrdinal("PERSONAL"));
                                ocampoEnt.METODO_CAZA = dr.GetString(dr.GetOrdinal("METODO_CAZA"));
                                ocampoEnt.SISTEMA_MARCAJE = dr.GetString(dr.GetOrdinal("SISTEMA_MARCAJE"));
                                ocampoEnt.APROVECHAR = dr.GetString(dr.GetOrdinal("APROVECHAR"));
                                ocampoEnt.DESC_ESPECIES = dr.GetString(dr.GetOrdinal("DESC_ESPECIE"));
                                ocampoEnt.RegEstado = 0;
                                lsCEntidad.ListISupervFaunaAprov.Add(ocampoEnt);
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
        public String RegIFaunaInsertar(OracleConnection cn, CEntidad oCEntidad)
        {
            OracleTransaction tr = null;
            String OUTPUTPARAM01 = "";
            CEntidad ocampoSuper;
            CEntPersona ocampoPer;
            try
            {
                tr = cn.BeginTransaction();
                //Grabando Cabecera
                using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.INFORME_Grabar", oCEntidad))
                {
                    cmd.ExecuteNonQuery();
                    OUTPUTPARAM01 = (String)cmd.Parameters["OUTPUTPARAM01"].Value;
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
                        throw new Exception("El Número de Informe ya Existe");
                    }
                    else if (OUTPUTPARAM01 == "1")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("El Número del Titulo Habilitante Existe en otro Registro");
                    }
                    else if (OUTPUTPARAM01 == "2")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("No Tiene Permisos para Modificar este Informe");
                    }
                    else if (OUTPUTPARAM01 == "3")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("Está con Control de Calidad, no puede modificar");
                    }

                }
                //
                //Eliminando Detalle Informe
                if (oCEntidad.ListEliTABLA != null)
                {
                    foreach (var loDatos in oCEntidad.ListEliTABLA)
                    {
                        ocampoSuper = new CEntidad();
                        ocampoSuper.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                        ocampoSuper.COD_INFORME_FOTOS = loDatos.COD_INFORME_FOTOS;
                        ocampoSuper.EliTABLA = loDatos.EliTABLA;
                        ocampoSuper.COD_ESPECIES = loDatos.COD_ESPECIES;
                        ocampoSuper.COD_PERSONA = loDatos.COD_PERSONA;
                        ocampoSuper.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                        ocampoSuper.NUM_POA = loDatos.NUM_POA;
                        ocampoSuper.COD_THABILITANTE = loDatos.COD_THABILITANTE;
                        ocampoSuper.COD_CNOTIFICACION = loDatos.COD_CNOTIFICACION;
                        ocampoSuper.COD_MUESTRA_SUPERVISION = loDatos.COD_MUESTRA_SUPERVISION;
                        dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spINFORME_Eliminar", ocampoSuper);
                    }
                }
                //Registro de carta de notificaciones
                if (oCEntidad.ListCNotificaciones != null)
                {
                    foreach (var loDatos in oCEntidad.ListCNotificaciones)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            ocampoSuper = new CEntidad();
                            ocampoSuper.COD_CNOTIFICACION = loDatos.COD_CNOTIFICACION;
                            ocampoSuper.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            ocampoSuper.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spINFORME_DET_CNOTIFICACIONES_Grabar", ocampoSuper);
                        }
                    }
                }
                //Registro de supervisores
                if (oCEntidad.ListInformeDetSupervisor != null)
                {
                    foreach (var loDatos in oCEntidad.ListInformeDetSupervisor)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            ocampoPer = new CEntPersona();
                            ocampoPer.COD_PERSONA = loDatos.COD_PERSONA;
                            ocampoPer.CODIGO = OUTPUTPARAM01.Split('|')[0];
                            ocampoPer.COD_DIDENTIDAD = loDatos.COD_DIDENTIDAD;
                            ocampoPer.APE_PATERNO = loDatos.APE_PATERNO;
                            ocampoPer.APE_MATERNO = loDatos.APE_MATERNO;
                            ocampoPer.NOMBRES = loDatos.NOMBRES;
                            ocampoPer.N_DOCUMENTO = loDatos.N_DOCUMENTO;
                            ocampoPer.N_RUC = loDatos.N_RUC;
                            ocampoPer.COD_PTIPO = loDatos.COD_PTIPO;
                            ocampoPer.COLEGIATURA_NUM = loDatos.COLEGIATURA_NUM;
                            ocampoPer.COD_DPESPECIALIDAD = loDatos.COD_DPESPECIALIDAD;
                            ocampoPer.COD_NACADEMICO = loDatos.COD_NACADEMICO;
                            ocampoPer.CARGO = loDatos.CARGO;
                            ocampoPer.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.INFORME_DET_SUPERVISOR_Grabar", ocampoPer);
                        }
                    }
                }
                //Registro de fotos
                if (oCEntidad.ListFotos != null)
                {
                    foreach (var loDatos in oCEntidad.ListFotos)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            CEntidad ocampo = new CEntidad();
                            ocampo.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            ocampo.COD_INFORME_FOTOS = "";
                            ocampo.COD_THABILITANTE = loDatos.COD_THABILITANTE;
                            ocampo.COD_UCUENTA = loDatos.COD_UCUENTA;
                            ocampo.URL_FOTO = loDatos.URL_FOTO;
                            ocampo.FUENTE_FOTO = loDatos.FUENTE_FOTO;
                            ocampo.DISP_FOTO = loDatos.DISP_FOTO;
                            ocampo.DESC_FOTO = loDatos.DESC_FOTO;
                            ocampo.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spINFORME_FOTOSGrabar", ocampo);
                        }
                    }
                }
                //Delimitación y Vigilancia de la Concesión
                if (oCEntidad.ListISUPERVISION_DET_PROGRAMA != null)
                {
                    foreach (var loDatos in oCEntidad.ListISUPERVISION_DET_PROGRAMA)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            ocampoSuper = new CEntidad();
                            ocampoSuper.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            ocampoSuper.COD_PROGRAMA = loDatos.COD_PROGRAMA;
                            ocampoSuper.ESTADO_PROGRAMA = loDatos.ESTADO_PROGRAMA;
                            ocampoSuper.OBSERVACION = loDatos.OBSERVACION;
                            ocampoSuper.TIPO = loDatos.TIPO;
                            ocampoSuper.FRECUENCIA = loDatos.FRECUENCIA;
                            ocampoSuper.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.ISUPERVISION_DET_PROGRAMA_Grabar", ocampoSuper);
                        }
                    }
                }
                // MANTENIMIENTO DE COORDENADA UTM
                if (oCEntidad.ListISUPERVISION_COORDENADAUTM != null)
                {
                    foreach (var loDatos in oCEntidad.ListISUPERVISION_COORDENADAUTM)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            ocampoSuper = new CEntidad();
                            ocampoSuper.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            ocampoSuper.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            ocampoSuper.VERTICE = loDatos.VERTICE;
                            ocampoSuper.COORDENADA_NORTE = loDatos.COORDENADA_NORTE;
                            ocampoSuper.COORDENADA_ESTE = loDatos.COORDENADA_ESTE;
                            ocampoSuper.COORDENADA_NORTE_CAMPO = loDatos.COORDENADA_NORTE_CAMPO;
                            ocampoSuper.COORDENADA_SUR_CAMPO = loDatos.COORDENADA_SUR_CAMPO;
                            ocampoSuper.NUM_POA = loDatos.NUM_POA;
                            ocampoSuper.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.ISUPERVISION_DET_COORDENADAUTM_Grabar", ocampoSuper);
                        }
                    }
                }
                // REGISTRO DE INFRAESTRUCTURA
                if (oCEntidad.ListISUPERVISION_INFRAESTRUCTURA != null)
                {
                    foreach (var loDatos in oCEntidad.ListISUPERVISION_INFRAESTRUCTURA)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            ocampoSuper = new CEntidad();
                            ocampoSuper.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            ocampoSuper.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            //ocampoSuper.TIPO_AMBIENTE = loDatos.TIPO_AMBIENTE;
                            ocampoSuper.TIPO_AMBIENTE = loDatos.DESCRIPCION;
                            ocampoSuper.AREA = loDatos.AREA;
                            //ocampoSuper.CAPACIDAD = loDatos.CAPACIDAD;
                            //ocampoSuper.MATERIAL_CONSTRUCCION = loDatos.MATERIAL_CONSTRUCCION;
                            ocampoSuper.USO = loDatos.USO;
                            ocampoSuper.ESTADO_CONSERVACION = loDatos.ESTADO_CONSERVACION;
                            ocampoSuper.OBJETIVO = loDatos.OBJETIVO;
                            ocampoSuper.NUM_POA = loDatos.NUM_POA;
                            ocampoSuper.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.ISUPERVISION_DET_CONSERV_INFRA_Grabar", ocampoSuper);
                        }
                    }
                }
                //REGISTRO DE ZONIFICACIÓN
                if (oCEntidad.ListISUPERVISION_DET_ZONIFICACION != null)
                {
                    foreach (var loDatos in oCEntidad.ListISUPERVISION_DET_ZONIFICACION)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            ocampoSuper = new CEntidad();
                            ocampoSuper.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            ocampoSuper.COD_PROGRAMA = loDatos.COD_PROGRAMA;
                            ocampoSuper.NOMBRE_ZONA = loDatos.NOMBRE_ZONA;
                            ocampoSuper.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            ocampoSuper.CARACTERISTICA = loDatos.CARACTERISTICA;
                            ocampoSuper.COORDENADA_NORTE = loDatos.COORDENADA_NORTE;
                            ocampoSuper.COORDENADA_ESTE = loDatos.COORDENADA_ESTE;
                            ocampoSuper.TIPO_SENALIZACION = loDatos.TIPO_SENALIZACION;
                            ocampoSuper.TIPO_DELIMITACION = loDatos.TIPO_DELIMITACION;
                            ocampoSuper.NUM_POA = loDatos.NUM_POA;
                            ocampoSuper.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.ISUPERVISION_DET_CONSERV_ZONIFICACION_Grabar", ocampoSuper);
                        }
                    }
                }
                //REGISTRO DE FAUNA SILVESTRE
                if (oCEntidad.ListAvistamientoFauna != null)
                {

                    foreach (var loDatos in oCEntidad.ListAvistamientoFauna)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            ocampoSuper = new CEntidad();
                            ocampoSuper.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            ocampoSuper.COD_ESPECIES = loDatos.COD_ESPECIES;
                            ocampoSuper.DESC_ESPECIES = loDatos.DESC_ESPECIES;
                            ocampoSuper.NOMBRE_COMUN = loDatos.NOMBRE_COMUN;
                            ocampoSuper.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            ocampoSuper.NUM_INDIVIDUOS = loDatos.NUM_INDIVIDUOS;
                            ocampoSuper.COD_TIPO_REGISTRO = loDatos.COD_TIPO_REGISTRO;
                            ocampoSuper.DESC_TIPO_REGISTRO = loDatos.DESC_TIPO_REGISTRO;
                            ocampoSuper.COD_ESTRATO = loDatos.COD_ESTRATO;
                            ocampoSuper.DESC_ESTRATO = loDatos.DESC_ESTRATO;
                            ocampoSuper.FECHA_AVISTAMIENTO = loDatos.FECHA_AVISTAMIENTO;
                            ocampoSuper.HORA_AVISTAMIENTO = loDatos.HORA_AVISTAMIENTO;
                            ocampoSuper.COORDENADA_NORTE = loDatos.COORDENADA_NORTE;
                            ocampoSuper.COORDENADA_ESTE = loDatos.COORDENADA_ESTE;
                            ocampoSuper.ALTITUD = loDatos.ALTITUD;
                            ocampoSuper.DESCRIPCION = loDatos.OBSERVACION;
                            ocampoSuper.NUM_POA = loDatos.NUM_POA;
                            ocampoSuper.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.ISUPERVISION_MADE_NOMADE_DET_AVISTAMIENTO_FAUNA_Grabar", ocampoSuper);
                        }
                    }
                }
                // MEDIDAS DE RESPONSABILIDAD SOCIAL
                if (oCEntidad.ListISUPERVISION_DET_CAPACITACION_ACTDES != null)
                {
                    foreach (var loDatos in oCEntidad.ListISUPERVISION_DET_CAPACITACION_ACTDES)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            ocampoSuper = new CEntidad();
                            ocampoSuper.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            ocampoSuper.COD_PROGRAMA = loDatos.COD_PROGRAMA;
                            ocampoSuper.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            ocampoSuper.ACTIVIDAD_REALIZADA = loDatos.ACTIVIDAD_REALIZADA;
                            ocampoSuper.FECHA_REALIZADA = loDatos.FECHA_REALIZADA;
                            ocampoSuper.NUM_PERSONA = loDatos.NUM_PERSONA;
                            ocampoSuper.ESTADO_DOCUMENTO = loDatos.ESTADO_DOCUMENTO;
                            ocampoSuper.DESC_TIPO_REGISTRO = loDatos.DESC_TIPO_REGISTRO;
                            ocampoSuper.OBJETIVO = loDatos.OBJETIVO;
                            ocampoSuper.AVANCE_RESULTADO = loDatos.AVANCE_RESULTADO;
                            ocampoSuper.LUGAR_CAPACITACION = loDatos.LUGAR_CAPACITACION;
                            ocampoSuper.NOMBRE_COMUNIDAD_SECTOR = loDatos.NOMBRE_COMUNIDAD_SECTOR;
                            ocampoSuper.OBSERVACION = loDatos.OBSERVACION;
                            ocampoSuper.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.ISUPERVISION_DET_CONSERV_PROG_Grabar", ocampoSuper);
                        }
                    }
                }
                //CUMPLIMIENTO DE OBLIGACIONES CONTRACTUALES
                if (oCEntidad.ListOCEjecucionActividad != null)
                {

                    foreach (var loDatos in oCEntidad.ListOCEjecucionActividad)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            ocampoSuper = new CEntidad();
                            ocampoSuper.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            ocampoSuper.COD_OCONTRACTUAL = loDatos.COD_OCONTRACTUAL;
                            ocampoSuper.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            ocampoSuper.COD_ESPECIES = "";
                            ocampoSuper.ACTIVIDAD_ACTOS = loDatos.ACTIVIDAD_ACTOS;
                            ocampoSuper.ESTA_AUTORIZADO = false;
                            ocampoSuper.DOCUMENTOS_AFORESTAL = loDatos.DOCUMENTOS_AFORESTAL;
                            ocampoSuper.OBSERVACION = "";
                            ocampoSuper.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spISUPERVISION_DET_OCONTRACTUALGrabar", ocampoSuper);
                        }
                    }
                }
                if (oCEntidad.ListOCActosTercero != null)
                {
                    foreach (var loDatos in oCEntidad.ListOCActosTercero)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            ocampoSuper = new CEntidad();
                            ocampoSuper.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            ocampoSuper.COD_OCONTRACTUAL = loDatos.COD_OCONTRACTUAL;
                            ocampoSuper.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            ocampoSuper.COD_ESPECIES = "";
                            ocampoSuper.ACTIVIDAD_ACTOS = loDatos.ACTIVIDAD_ACTOS;
                            ocampoSuper.ESTA_AUTORIZADO = false;
                            ocampoSuper.DOCUMENTOS_AFORESTAL = loDatos.DOCUMENTOS_AFORESTAL;
                            ocampoSuper.OBSERVACION = "";
                            ocampoSuper.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spISUPERVISION_DET_OCONTRACTUALGrabar", ocampoSuper);
                        }
                    }
                }
                // MEDIDAS DE PREVENCIÓN Y MITIGACIÓN DE IMPACTOS
                if (oCEntidad.ListISUPERVISION_IDENTMANEJOIMPACTO != null)
                {
                    foreach (var loDatos in oCEntidad.ListISUPERVISION_IDENTMANEJOIMPACTO)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            ocampoSuper = new CEntidad();
                            ocampoSuper.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            ocampoSuper.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            ocampoSuper.TIPO_IMPACTO = loDatos.TIPO_IMPACTO;
                            ocampoSuper.RIESGO_POTENCIAL = loDatos.RIESGO_POTENCIAL;
                            ocampoSuper.ACTIVIDAD = loDatos.ACTIVIDAD;
                            ocampoSuper.AVANCE_RESULTADO = loDatos.AVANCE_RESULTADO;
                            ocampoSuper.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.ISUPERVISION_DET_CONSERV_IDENTMANIMPACT_Grabar", ocampoSuper);
                        }
                    }
                }
                // APROVECHAMIENTO SOSTENIBLE
                if (oCEntidad.ListISupervFaunaAprov != null)
                {
                    foreach (var loDatos in oCEntidad.ListISupervFaunaAprov)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            ocampoSuper = new CEntidad();
                            ocampoSuper.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            ocampoSuper.NUM_POA = loDatos.NUM_POA;
                            ocampoSuper.COD_ESPECIES = loDatos.COD_ESPECIES;
                            ocampoSuper.PERIODO = loDatos.PERIODO;
                            ocampoSuper.CUOTA_SACA = loDatos.CUOTA_SACA;
                            ocampoSuper.PERSONAL = loDatos.PERSONAL;
                            ocampoSuper.METODO_CAZA = loDatos.METODO_CAZA;
                            ocampoSuper.SISTEMA_MARCAJE = loDatos.SISTEMA_MARCAJE;
                            ocampoSuper.APROVECHAR = loDatos.APROVECHAR;
                            ocampoSuper.COD_UCUENTA = oCEntidad.COD_UCUENTA;
                            ocampoSuper.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spISUPERVISION_DET_FAUNA_APROVGrabar", ocampoSuper);
                        }
                    }
                }

                //Registro de DESPLAZAMIENTO
                if (oCEntidad.ListDesplazamientoInforme != null)
                {
                    foreach (var loDatos in oCEntidad.ListDesplazamientoInforme)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            CEntidad ocampo = new CEntidad();
                            ocampo.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            if (loDatos.COD_DESPLAZAMIENTO == "")
                            {
                                ocampo.COD_DESPLAZAMIENTO = "";
                            }
                            else
                            {
                                ocampo.COD_DESPLAZAMIENTO = loDatos.COD_DESPLAZAMIENTO;
                            }
                            ocampo.PTOI_COORDENADA_ESTE = loDatos.COORDENADA_ESTE;
                            ocampo.PTOI_COORDENADA_NORTE = loDatos.COORDENADA_NORTE;
                            ocampo.PTOF_COORDENADA_ESTE = loDatos.COORDENADA_ESTE_CAMPO;
                            ocampo.PTOF_COORDENADA_NORTE = loDatos.COORDENADA_NORTE_CAMPO;
                            ocampo.OBSERVACION = loDatos.OBSERVACION;
                            ocampo.TIPO = loDatos.TipoVia;
                            ocampo.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spINFORME_DESPLAZAMIENTOGrabar", ocampo);
                        }
                    }
                }
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

        //Obtener los datos de campo maderable de un informe de supervision por el código de informe o la RD
        public CEntidad RegMostrarDatosCampoISupervision(OracleConnection cn, CEntidad oCEntidad)
        {
            CEntidad lsCEntidad = new CEntidad();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spISUPERVISION_DET_EMADERABLEListar", oCEntidad))
                {
                    if (dr != null)
                    {
                        lsCEntidad.ListEMaderable = new List<CapaEntidad.DOC.Ent_INFORME>();
                        lsCEntidad.ListEMaderableSemillero = new List<CapaEntidad.DOC.Ent_INFORME>();
                        CapaEntidad.DOC.Ent_INFORME ocampoEnt;

                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                ocampoEnt = new CapaEntidad.DOC.Ent_INFORME();
                                ocampoEnt.COD_INFORME = dr["COD_INFORME"].ToString();
                                ocampoEnt.COD_THABILITANTE = dr["COD_THABILITANTE"].ToString();
                                ocampoEnt.NUM_POA = Convert.ToInt32(dr["NUM_POA"].ToString());
                                ocampoEnt.COD_ESPECIES = dr["COD_ESPECIES"].ToString();
                                ocampoEnt.COD_SECUENCIAL = Convert.ToInt32(dr["COD_SECUENCIAL"].ToString());
                                ocampoEnt.POA = dr["POA"].ToString();
                                ocampoEnt.BLOQUE = dr["BLOQUE"].ToString();
                                ocampoEnt.BLOQUE_CAMPO = dr["BLOQUE_CAMPO"].ToString();
                                ocampoEnt.FAJA = dr["FAJA"].ToString();
                                ocampoEnt.FAJA_CAMPO = dr["FAJA_CAMPO"].ToString();
                                ocampoEnt.CODIGO = dr["CODIGO"].ToString();
                                ocampoEnt.CODIGO_CAMPO = dr["CODIGO_CAMPO"].ToString();
                                ocampoEnt.DESC_ESPECIES = dr["ESPECIES"].ToString();
                                ocampoEnt.DESC_ESPECIES_CAMPO = dr["ESPECIES_CAMPO"].ToString();
                                ocampoEnt.DESC_COINCIDE_ESPECIES = dr["COINCIDE_ESPECIES"].ToString();
                                ocampoEnt.ZONA = dr["ZONA"].ToString();
                                ocampoEnt.ZONA_CAMPO = dr["ZONA_CAMPO"].ToString();
                                ocampoEnt.COORDENADA_ESTE = Convert.ToInt32(dr["COORDENADA_ESTE"].ToString());
                                ocampoEnt.COORDENADA_ESTE_CAMPO = Convert.ToInt32(dr["COORDENADA_ESTE_CAMPO"].ToString());
                                ocampoEnt.COORDENADA_NORTE = Convert.ToInt32(dr["COORDENADA_NORTE"].ToString());
                                ocampoEnt.COORDENADA_NORTE_CAMPO = Convert.ToInt32(dr["COORDENADA_NORTE_CAMPO"].ToString());
                                ocampoEnt.DAP = Convert.ToDecimal(dr["DAP"].ToString());
                                ocampoEnt.DAP_CAMPO = Convert.ToDecimal(dr["DAP_CAMPO"].ToString());
                                ocampoEnt.DAP_CAMPO1 = Convert.ToDecimal(dr["DAP_CAMPO1"].ToString());
                                ocampoEnt.DAP_CAMPO2 = Convert.ToDecimal(dr["DAP_CAMPO2"].ToString());
                                ocampoEnt.MMEDIR_DAP = dr["MMEDIR_DAP"].ToString();
                                ocampoEnt.AC = Convert.ToDecimal(dr["AC"].ToString());
                                ocampoEnt.AC_CAMPO = Convert.ToDecimal(dr["AC_CAMPO"].ToString());
                                ocampoEnt.DESC_EESTADO = dr["EESTADO"].ToString();
                                ocampoEnt.DESC_EESTADO_CAMPO = dr["EESTADO_CAMPO"].ToString();
                                ocampoEnt.COD_EESTADO = dr["COD_EESTADO_CAMPO"].ToString();
                                ocampoEnt.DESC_ECONDICION = dr["ECONDICION"].ToString();
                                ocampoEnt.DESC_ECONDICION_CAMPO = dr["ECONDICION_CAMPO"].ToString();
                                ocampoEnt.OBSERVACION = dr["OBSERVACION"].ToString();
                                lsCEntidad.ListEMaderable.Add(ocampoEnt);
                            }
                        }
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                ocampoEnt = new CapaEntidad.DOC.Ent_INFORME();
                                ocampoEnt.COD_INFORME = dr["COD_INFORME"].ToString();
                                ocampoEnt.COD_THABILITANTE = dr["COD_THABILITANTE"].ToString();
                                ocampoEnt.NUM_POA = Convert.ToInt32(dr["NUM_POA"].ToString());
                                ocampoEnt.COD_ESPECIES = dr["COD_ESPECIES"].ToString();
                                ocampoEnt.COD_SECUENCIAL = Convert.ToInt32(dr["COD_SECUENCIAL"].ToString());
                                ocampoEnt.POA = dr["POA"].ToString();
                                ocampoEnt.BLOQUE = dr["BLOQUE"].ToString();
                                ocampoEnt.BLOQUE_CAMPO = dr["BLOQUE_CAMPO"].ToString();
                                ocampoEnt.FAJA = dr["FAJA"].ToString();
                                ocampoEnt.FAJA_CAMPO = dr["FAJA_CAMPO"].ToString();
                                ocampoEnt.CODIGO = dr["CODIGO"].ToString();
                                ocampoEnt.CODIGO_CAMPO = dr["CODIGO_CAMPO"].ToString();
                                ocampoEnt.DESC_ESPECIES = dr["ESPECIES"].ToString();
                                ocampoEnt.DESC_ESPECIES_CAMPO = dr["ESPECIES_CAMPO"].ToString();
                                ocampoEnt.DESC_COINCIDE_ESPECIES = dr["COINCIDE_ESPECIES"].ToString();
                                ocampoEnt.ZONA = dr["ZONA"].ToString();
                                ocampoEnt.ZONA_CAMPO = dr["ZONA_CAMPO"].ToString();
                                ocampoEnt.COORDENADA_ESTE = Convert.ToInt32(dr["COORDENADA_ESTE"].ToString());
                                ocampoEnt.COORDENADA_ESTE_CAMPO = Convert.ToInt32(dr["COORDENADA_ESTE_CAMPO"].ToString());
                                ocampoEnt.COORDENADA_NORTE = Convert.ToInt32(dr["COORDENADA_NORTE"].ToString());
                                ocampoEnt.COORDENADA_NORTE_CAMPO = Convert.ToInt32(dr["COORDENADA_NORTE_CAMPO"].ToString());
                                ocampoEnt.DAP = Convert.ToDecimal(dr["DAP"].ToString());
                                ocampoEnt.DAP_CAMPO = Convert.ToDecimal(dr["DAP_CAMPO"].ToString());
                                ocampoEnt.DAP_CAMPO1 = Convert.ToDecimal(dr["DAP_CAMPO1"].ToString());
                                ocampoEnt.DAP_CAMPO2 = Convert.ToDecimal(dr["DAP_CAMPO2"].ToString());
                                ocampoEnt.MMEDIR_DAP = dr["MMEDIR_DAP"].ToString();
                                ocampoEnt.AC = Convert.ToDecimal(dr["AC"].ToString());
                                ocampoEnt.AC_CAMPO = Convert.ToDecimal(dr["AC_CAMPO"].ToString());
                                ocampoEnt.DESC_EESTADO = dr["EESTADO"].ToString();
                                ocampoEnt.DESC_EESTADO_CAMPO = dr["EESTADO_CAMPO"].ToString();
                                ocampoEnt.COD_EESTADO = dr["COD_EESTADO_CAMPO"].ToString();
                                ocampoEnt.DESC_EFENOLOGICO = dr["EFENOLOGICO"].ToString();
                                ocampoEnt.DESC_CFUSTE = dr["CFUSTE"].ToString();
                                ocampoEnt.DESC_FCOPA = dr["FCOPA"].ToString();
                                ocampoEnt.DESC_PCOPA = dr["PCOPA"].ToString();
                                ocampoEnt.DESC_EFITOSANITARIO = dr["ESANITARIO"].ToString();
                                ocampoEnt.DESC_ILIANAS = dr["ILIANAS"].ToString();
                                ocampoEnt.OBSERVACION = dr["OBSERVACION"].ToString();
                                lsCEntidad.ListEMaderableSemillero.Add(ocampoEnt);
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
        /// metodo que obtiene la lista dde descargas del informe
        /// CR 15/05/2018
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="codInforme"></param>
        /// <returns></returns>
        public CEntidad RegListaItemDescarga(OracleConnection cn, CEntidad oCEntidad)
        {
            CEntidad lsCEntidad = new CEntidad();
            object[] param = { oCEntidad.BusValor };
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, "DOC_OSINFOR_ERP_MIGRACION.spINFORMEDescargaS", param))
                {
                    CEntidad oCEntidadTemp = new CEntidad();
                    lsCEntidad = new CEntidad();
                    lsCEntidad.ListPOAs = new List<CEntidad>();
                    lsCEntidad.ListPOAsCampo = new List<CEntidad>();
                    lsCEntidad.ListISupervMaderableAprov = new List<CEntidad>();
                    lsCEntidad.ListISupervMaderableSemillero = new List<CEntidad>();
                    lsCEntidad.ListCastaña = new List<CEntidad>();
                    lsCEntidad.ListTrozaCampo = new List<CEntidad>();
                    lsCEntidad.ListMadeAserradaCampo = new List<CEntidad>();
                    lsCEntidad.ListISupervMaderableAdicional = new List<CEntidad>();
                    lsCEntidad.ListISupervMaderableNoAutorizado = new List<CEntidad>();
                    lsCEntidad.ListHuayronas = new List<CEntidad>();
                    lsCEntidad.ListEvaluacionOtros = new List<CEntidad>();
                    lsCEntidad.ListAvistamientoFauna = new List<CEntidad>();
                    lsCEntidad.ListMuestraNoMadeCarrizos = new List<CEntidad>();
                    //POA
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            oCEntidadTemp = new CEntidad();
                            oCEntidadTemp.POA = dr["POA"].ToString();
                            oCEntidadTemp.NUMERO = dr["TITULO"].ToString();
                            oCEntidadTemp.VERTICE = dr["VERTICE"].ToString();
                            oCEntidadTemp.ZONA = dr["ZONA"].ToString();
                            oCEntidadTemp.COORDENADA_ESTE = Int32.Parse(dr["COORDENADA_ESTE"].ToString());
                            oCEntidadTemp.COORDENADA_NORTE = Int32.Parse(dr["COORDENADA_NORTE"].ToString());
                            oCEntidadTemp.OBSERVACION = dr["OBSERVACION"].ToString();
                            oCEntidadTemp.TITULAR = dr["TITULAR"].ToString();
                            oCEntidadTemp.SUPERVISOR = dr["SUPERVISORES"].ToString();
                            oCEntidadTemp.COD_THABILITANTE = dr["COD_THABILITANTE"].ToString();
                            oCEntidadTemp.NUM_POA = Int32.Parse(dr["NUM_POA"].ToString());
                            oCEntidadTemp.FECHA_SUPERVISION_INICIO = dr["FECHA_INICIO"].ToString();
                            oCEntidadTemp.FECHA_SUPERVISION_FIN = dr["FECHA_FIN"].ToString();
                            oCEntidadTemp.COD_INFORME = dr["COD_INFORME"].ToString();
                            lsCEntidad.ListPOAs.Add(oCEntidadTemp);
                        }
                    }
                    dr.NextResult();
                    //CAMPO
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            oCEntidadTemp = new CEntidad();
                            oCEntidadTemp.POA = dr["NOMBRE_POA"].ToString();
                            oCEntidadTemp.NUMERO = dr["TITULO"].ToString();
                            oCEntidadTemp.VERTICE = dr["VERTICE"].ToString();
                            oCEntidadTemp.COORDENADA_ESTE = Int32.Parse(dr["COORDENADA_ESTE"].ToString());
                            oCEntidadTemp.COORDENADA_NORTE = Int32.Parse(dr["COORDENADA_NORTE"].ToString());
                            oCEntidadTemp.OBSERVACION = dr["OBSERVACION"].ToString();
                            oCEntidadTemp.COD_THABILITANTE = dr["COD_THABILITANTE"].ToString();
                            oCEntidadTemp.NUM_POA = Int32.Parse(dr["NUM_POA"].ToString());
                            oCEntidadTemp.COD_INFORME = dr["COD_INFORME"].ToString();
                            oCEntidadTemp.COD_SECUENCIAL = Int32.Parse(dr["COD_SECUENCIAL"].ToString());
                            lsCEntidad.ListPOAsCampo.Add(oCEntidadTemp);
                        }
                    }
                    ///APROVECHABLES
                    ///21/05/2018 CAR
                    dr.NextResult();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            oCEntidadTemp = new CEntidad();
                            oCEntidadTemp.POA = dr["NOMBRE_POA"].ToString();
                            oCEntidadTemp.NUMERO = dr["TITULO"].ToString();
                            oCEntidadTemp.FAJA = dr["FAJA"].ToString();
                            oCEntidadTemp.FAJA_CAMPO = dr["FAJA_CAMPO"].ToString();
                            oCEntidadTemp.CODIGO = dr["CODIGO"].ToString();
                            oCEntidadTemp.CODIGO_CAMPO = dr["CODIGO_CAMPO"].ToString();
                            oCEntidadTemp.ESPECIES = dr["ESPECIE"].ToString();
                            oCEntidadTemp.DESC_ESPECIES_CAMPO = dr["ESPECIE_CAMPO"].ToString();
                            oCEntidadTemp.COORDENADA_ESTE = Int32.Parse(dr["COORDENADA_ESTE"].ToString());
                            oCEntidadTemp.COORDENADA_ESTE_CAMPO = Int32.Parse(dr["COORDENADA_ESTE_CAMPO"].ToString());
                            oCEntidadTemp.COORDENADA_NORTE = Int32.Parse(dr["COORDENADA_NORTE"].ToString());
                            oCEntidadTemp.COORDENADA_NORTE_CAMPO = Int32.Parse(dr["COORDENADA_NORTE_CAMPO"].ToString());
                            oCEntidadTemp.DAP_CAMPO = Decimal.Parse(dr["DAP_CAMPO"].ToString());
                            oCEntidadTemp.AC_CAMPO = Decimal.Parse(dr["AC_CAMPO"].ToString());
                            oCEntidadTemp.ESTADO_CAMPO = dr["ESTADO_CAMPO"].ToString();
                            oCEntidadTemp.CONDICION_CAMPO = dr["CONDICION_CAMPO"].ToString();
                            oCEntidadTemp.OBSERVACION = dr["OBSERVACION"].ToString();
                            oCEntidadTemp.COD_THABILITANTE = dr["COD_THABILITANTE"].ToString();
                            oCEntidadTemp.NUM_POA = Int32.Parse(dr["NUM_POA"].ToString());
                            oCEntidadTemp.COD_ESPECIES = dr["COD_ESPECIES"].ToString();
                            oCEntidadTemp.COD_SECUENCIAL = Int32.Parse(dr["COD_SECUENCIAL"].ToString());
                            oCEntidadTemp.FECHA_SUPERVISION_INICIO = dr["FECHA_INICIO"].ToString();
                            oCEntidadTemp.FECHA_SUPERVISION_FIN = dr["FECHA_FIN"].ToString();
                            oCEntidadTemp.COD_INFORME = dr["COD_INFORME"].ToString();
                            oCEntidadTemp.FUENTE_FOTO = dr["FUENTE"].ToString();
                            lsCEntidad.ListISupervMaderableAprov.Add(oCEntidadTemp);
                        }
                    }

                    ///TROZAS
                    ///25/05/2018 CAR
                    dr.NextResult();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            oCEntidadTemp = new CEntidad();
                            oCEntidadTemp.POA = dr["NOMBRE_POA"].ToString();
                            oCEntidadTemp.NUMERO = dr["TITULO"].ToString();
                            oCEntidadTemp.CODIGO = dr["CODIGO"].ToString();
                            oCEntidadTemp.ESPECIES = dr["ESPECIES"].ToString();
                            oCEntidadTemp.COORDENADA_ESTE = Int32.Parse(dr["COORDENADA_ESTE"].ToString());
                            oCEntidadTemp.COORDENADA_NORTE = Int32.Parse(dr["COORDENADA_NORTE"].ToString());
                            oCEntidadTemp.OBSERVACION = dr["OBSERVACION"].ToString();
                            oCEntidadTemp.COD_THABILITANTE = dr["COD_THABILITANTE"].ToString();
                            oCEntidadTemp.NUM_POA = Int32.Parse(dr["NUM_POA"].ToString());
                            oCEntidadTemp.COD_ESPECIES = dr["COD_ESPECIES"].ToString();
                            oCEntidadTemp.COD_SECUENCIAL = Int32.Parse(dr["COD_SECUENCIAL"].ToString());
                            oCEntidadTemp.FECHA_SUPERVISION_INICIO = dr["FECHA_INICIO"].ToString();
                            oCEntidadTemp.FECHA_SUPERVISION_FIN = dr["FECHA_FIN"].ToString();
                            oCEntidadTemp.COD_INFORME = dr["COD_INFORME"].ToString();
                            oCEntidadTemp.FUENTE_FOTO = dr["FUENTE"].ToString();
                            lsCEntidad.ListTrozaCampo.Add(oCEntidadTemp);
                        }
                    }

                    ///HUAYRONAS
                    ///21/05/2018 CAR
                    dr.NextResult();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            oCEntidadTemp = new CEntidad();
                            oCEntidadTemp.POA = dr["NOMBRE_POA"].ToString();
                            oCEntidadTemp.NUMERO = dr["TITULO"].ToString();
                            oCEntidadTemp.CODIGO = dr["NUMERO"].ToString();
                            oCEntidadTemp.CONDICION = dr["CONDICION"].ToString();
                            oCEntidadTemp.COORDENADA_ESTE = Int32.Parse(dr["COORDENADA_ESTE"].ToString());
                            oCEntidadTemp.COORDENADA_NORTE = Int32.Parse(dr["COORDENADA_NORTE"].ToString());
                            oCEntidadTemp.VOLUMEN = Decimal.Parse(dr["VOLUMEN"].ToString());
                            oCEntidadTemp.COD_THABILITANTE = dr["COD_THABILITANTE"].ToString();
                            oCEntidadTemp.NUM_POA = Int32.Parse(dr["NUM_POA"].ToString());
                            oCEntidadTemp.COD_INFORME = dr["COD_INFORME"].ToString();
                            lsCEntidad.ListHuayronas.Add(oCEntidadTemp);
                        }
                    }
                    ///12/10/2018 CAR
                    /// CARRIZOS ESPECIES --SUPERVISADAS
                    ///MADERABLE ADICIONALES
                    ///21/05/2018 CAR
                    dr.NextResult();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            oCEntidadTemp = new CEntidad();
                            oCEntidadTemp.CODIGO = dr["CODIGO"].ToString();
                            oCEntidadTemp.NUMERO = dr["TITULO"].ToString();
                            oCEntidadTemp.ESPECIES = dr["ESPECIE"].ToString();
                            oCEntidadTemp.TOTAL_UNIDAD_MUEST = Int32.Parse(dr["TOTAL_UNIDAD_MUEST"].ToString());
                            oCEntidadTemp.TOTAL_UNIDADES_APROV = Int32.Parse(dr["TOTAL_UNIDADES_APROV"].ToString());
                            oCEntidadTemp.COORDENADA_ESTE = Int32.Parse(dr["COORDENADA_ESTE"].ToString());
                            oCEntidadTemp.COORDENADA_NORTE = Int32.Parse(dr["COORDENADA_NORTE"].ToString());
                            oCEntidadTemp.ALTURA_PROMEDIO = Decimal.Parse(dr["ALTURA_PROMEDIO"].ToString());
                            oCEntidadTemp.OBSERVACION = dr["OBSERVACION"].ToString();
                            oCEntidadTemp.COD_THABILITANTE = dr["COD_THABILITANTE"].ToString();
                            oCEntidadTemp.NUM_POA = Int32.Parse(dr["NUM_POA"].ToString());
                            oCEntidadTemp.COD_INFORME = dr["COD_INFORME"].ToString();
                            oCEntidadTemp.COD_ESPECIES = dr["COD_ESPECIES"].ToString();
                            oCEntidadTemp.COD_SECUENCIAL = Int32.Parse(dr["COD_SECUENCIAL"].ToString());

                            lsCEntidad.ListMuestraNoMadeCarrizos.Add(oCEntidadTemp);
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

        public List<CEntISExsitu> RegObligacionesListFauna(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntISExsitu> ListObligacionTitular = new List<CEntISExsitu>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spISUPERVISION_OBLIG_TITULAR_FAUNA_LIST", oCEntidad))
                {
                    if (dr != null)
                    {
                        CEntISExsitu oCamposDet;
                        //Especies Fauna
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("COD_INFORME");
                            int pt2 = dr.GetOrdinal("MAE_OBLIGTITULAR");
                            int pt5 = dr.GetOrdinal("DESC_OBLIG");
                            int pt3 = dr.GetOrdinal("EVAL_OBLIGTITULAR");
                            int pt4 = dr.GetOrdinal("OBSERVACION_OBLIG");

                            while (dr.Read())
                            {
                                oCamposDet = new CEntISExsitu();
                                oCamposDet.COD_INFORME = dr.GetString(pt1);
                                oCamposDet.MAE_OBLIGTITULAR = dr.GetString(pt2);
                                oCamposDet.CODIGO_NOMBRE = dr.GetString(pt5);
                                oCamposDet.EVAL_OBLIGTITULAR = dr.GetString(pt3);
                                oCamposDet.OBSERVACION_OBLIG = dr.GetString(pt4);
                                ListObligacionTitular.Add(oCamposDet);
                            }
                        }
                    }
                }
                return ListObligacionTitular;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region SIGOsfc v3
        public CEntidad RegMostrarListaItem_v3(OracleConnection cn, String codInforme)
        {
            CEntidad lsCEntidad = new CEntidad();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, "DOC_OSINFOR_ERP_MIGRACION.spINFORMEMostrarItem_v3", codInforme))
                {
                    if (dr != null)
                    {
                        lsCEntidad.ListCNotificaciones = new List<CEntidad>();
                        lsCEntidad.ListPOAs = new List<CEntidad>();
                        lsCEntidad.ListInformeDetSupervisor = new List<CEntPersona>();
                        lsCEntidad.ListTHVerticeCampo = new List<CEntidad>();
                        lsCEntidad.ListAvistamientoFauna = new List<CEntidad>();
                        lsCEntidad.ListFotos = new List<CEntidad>();
                        lsCEntidad.ListObligacionTitular = new List<CapaEntidad.DOC.Ent_INFORME_OBLIGTITULAR>();
                        lsCEntidad.ListISUPERVISION_OCARACTE_AMB01 = new List<CEntidad>();
                        lsCEntidad.ListDesplazamientoInforme = new List<CEntidad>();
                        CEntidad ocampoEnt;

                        #region "Datos Generales"
                        if (dr.HasRows)
                        {
                            dr.Read();
                            lsCEntidad.COD_ESTADO_DOC = dr["COD_ESTADO_DOC"].ToString();
                            lsCEntidad.OBSERVACIONES_CONTROL = dr["OBSERVACIONES_CONTROL"].ToString();
                            lsCEntidad.OBSERV_SUBSANAR = dr.GetBoolean(dr.GetOrdinal("OBSERV_SUBSANAR"));
                            lsCEntidad.USUARIO_CONTROL = dr["USUARIO_CONTROL"].ToString();
                            lsCEntidad.USUARIO_REGISTRO = dr.GetString(dr.GetOrdinal("USUARIO_REGISTRO"));

                            lsCEntidad.COD_INFORME = codInforme;
                            lsCEntidad.NUM_THABILITANTE = dr.GetString(dr.GetOrdinal("NUM_THABILITANTE"));
                            lsCEntidad.COD_CNOTIFICACION = dr.GetString(dr.GetOrdinal("COD_CNOTIFICACION"));
                            lsCEntidad.NUM_CNOTIFICACION = dr.GetString(dr.GetOrdinal("NUM_CNOTIFICACION"));
                            /*lsCEntidad.COD_FISNOTI = dr.GetString(dr.GetOrdinal("COD_FISNOTI"));
                            lsCEntidad.NUM_NOTIFICACION = dr.GetString(dr.GetOrdinal("NUM_NOTIFICACION"));*/
                            lsCEntidad.PUBLICAR = dr.GetBoolean(dr.GetOrdinal("PUBLICAR"));
                            lsCEntidad.NUMERO = dr.GetString(dr.GetOrdinal("NUMERO"));
                            lsCEntidad.COD_OD_REGISTRO = dr.GetString(dr.GetOrdinal("COD_OD_REGISTRO"));
                            lsCEntidad.PLAN_AMAZONAS = dr.GetBoolean(dr.GetOrdinal("PLAN_AMAZONAS"));
                            lsCEntidad.ANIO_PLAN_AMAZONAS = dr.GetString(dr.GetOrdinal("ANIO_PLAN_AMAZONAS"));
                            lsCEntidad.COD_IMOTIVO = dr.GetString(dr.GetOrdinal("COD_IMOTIVO"));
                            lsCEntidad.IMOTIVO = dr.GetString(dr.GetOrdinal("IMOTIVO"));
                            lsCEntidad.MAE_TIP_MOTMOTIVADA = dr.GetString(dr.GetOrdinal("MAE_TIP_MOTMOTIVADA"));
                            lsCEntidad.COD_TRAMITE_SITD = dr.GetInt32(dr.GetOrdinal("COD_TRAMITE_SITD"));
                            lsCEntidad.NUM_DREFERENCIA = dr["NUM_DREFERENCIA"].ToString();
                            lsCEntidad.FECHA_ENTREGA = dr.GetString(dr.GetOrdinal("FECHA_ENTREGA"));
                            lsCEntidad.COD_DIRECTOR = dr["COD_DIRECTOR"].ToString();
                            lsCEntidad.NOMBRE_DIRECTOR = dr["APELLIDOS_NOMBRES"].ToString();
                            lsCEntidad.FECHA_SUPERVISION_INICIO = dr.GetString(dr.GetOrdinal("FECHA_SUPERVISION_INICIO"));
                            lsCEntidad.FECHA_SUPERVISION_FIN = dr.GetString(dr.GetOrdinal("FECHA_SUPERVISION_FIN"));
                            lsCEntidad.ASUNTO = dr["ASUNTO"].ToString();
                            lsCEntidad.CONTENIDO = dr["CONTENIDO"].ToString();
                            lsCEntidad.REALIZADO_VEEDORFORESTAL = dr.GetBoolean(dr.GetOrdinal("REALIZADO_VEEDORFORESTAL"));
                            lsCEntidad.THABILITANTE_COD_UBIGEO = dr.GetString(dr.GetOrdinal("THABILITANTE_COD_UBIGEO"));
                            lsCEntidad.UBIGEO = dr["UBIGEO"].ToString();
                            lsCEntidad.THABILITANTE_SECTOR = dr["THABILITANTE_SECTOR"].ToString();
                            lsCEntidad.GEOTEC_DESCRIPCION = dr["GEOTEC_DESCRIPCION"].ToString();
                            lsCEntidad.GEOTEC_DRON = Convert.ToBoolean(dr["GEOTEC_DRON"]);
                            lsCEntidad.GEOTEC_GEOSUPERVISOR = dr.GetBoolean(dr.GetOrdinal("GEOTEC_GEOSUPERVISOR"));
                            lsCEntidad.GEOTEC_NINGUNO = dr.GetBoolean(dr.GetOrdinal("GEOTEC_NINGUNO"));
                            lsCEntidad.GEOTEC_OTROS = dr.GetBoolean(dr.GetOrdinal("GEOTEC_OTROS"));
                            lsCEntidad.OBSERVACION = dr["OBSERVACION"].ToString();
                            lsCEntidad.CONCLUSION = dr["CONCLUSION"].ToString();
                            lsCEntidad.COD_DLINEA = dr.GetString(dr.GetOrdinal("COD_DLINEA"));
                            lsCEntidad.ESTADO_ORIGEN = dr.GetString(dr.GetOrdinal("ESTADO_ORIGEN_CN"));
                            lsCEntidad.COD_TIPO_SUPER = dr.GetString(dr.GetOrdinal("COD_TIPO_SUPER"));
                            lsCEntidad.TIPO_INFORME = dr.GetString(dr.GetOrdinal("TIPO_INFORME"));
                            lsCEntidad.BUEN_DESEMPENIO = dr.GetInt32(dr.GetOrdinal("BUEN_DESEMPENIO"));
                            lsCEntidad.ARCHIVA_INFORME = (!dr.IsDBNull(dr.GetOrdinal("ARCHIVA_INFORME"))) ? dr.GetInt32(dr.GetOrdinal("ARCHIVA_INFORME")) : -1;
                            lsCEntidad.COD_SUP_CALIDAD = dr.GetString(dr.GetOrdinal("COD_SUP_CALIDAD"));
                            lsCEntidad.NOMBRE_SUP_CALIDAD = dr.GetString(dr.GetOrdinal("PERSONA_SUP_CALIDAD"));
                        }
                        #endregion
                        #region ListCNotificaciones
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidad();

                                ocampoEnt.COD_CNOTIFICACION = dr.GetString(dr.GetOrdinal("COD_CNOTIFICACION"));
                                ocampoEnt.NUMERO = dr.GetString(dr.GetOrdinal("NUMERO"));
                                /*ocampoEnt.COD_FISNOTI = dr.GetString(dr.GetOrdinal("COD_FISNOTI"));
                                ocampoEnt.NUM_NOTIFICACION = dr.GetString(dr.GetOrdinal("NUM_NOTIFICACION"));*/
                                ocampoEnt.NUM_THABILITANTE = dr.GetString(dr.GetOrdinal("NUM_THABILITANTE"));
                                ocampoEnt.ESTADO_ORIGEN = dr.GetString(dr.GetOrdinal("ESTADO_ORIGEN"));
                                ocampoEnt.ESTADO_ORIGEN_TEXT = dr.GetString(dr.GetOrdinal("ESTADO_ORIGEN_TEXT"));
                                ocampoEnt.MAE_CNTIPO = dr.GetString(dr.GetOrdinal("MAE_CNTIPO"));
                                ocampoEnt.MTIPO = dr.GetString(dr.GetOrdinal("MODALIDAD_TIPO"));
                                /*ocampoEnt.NOMBRE_POA = dr.GetString(dr.GetOrdinal("NOMBRE_POA"));
                                ocampoEnt.FCTIPO = dr.GetString(dr.GetOrdinal("FCTIPO"));
                                ocampoEnt.MTIPO = dr.GetString(dr.GetOrdinal("MTIPO"));*/
                                ocampoEnt.RegEstado = 0;
                                lsCEntidad.ListCNotificaciones.Add(ocampoEnt);
                            }
                        }
                        #endregion
                        #region ListPOAs
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidad();
                                ocampoEnt.COD_THABILITANTE = dr["COD_THABILITANTE"].ToString();
                                ocampoEnt.NUM_POA = Int32.Parse(dr["NUM_POA"].ToString());
                                ocampoEnt.POA = dr["POA"].ToString();
                                ocampoEnt.PUBLICAR = Convert.ToBoolean(dr["PUBLICAR"]);
                                ocampoEnt.SUPERVISADO = Convert.ToBoolean(dr["SUPERVISADO"]);
                                ocampoEnt.B_POA = Convert.ToInt32(dr["B_POA"]);
                                ocampoEnt.CODIGO_SEC_NOPOA = dr["CODIGO_SEC_NOPOA"].ToString();
                                ocampoEnt.RegEstado = 0;
                                lsCEntidad.ListPOAs.Add(ocampoEnt);
                            }
                        }
                        #endregion
                        #region ListInformeDetSupervisor
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            CEntPersona oPer;
                            while (dr.Read())
                            {
                                oPer = new CEntPersona();
                                oPer.COD_PERSONA = dr["COD_PERSONA"].ToString();
                                oPer.NOMBRES = dr["APELLIDOS_NOMBRES"].ToString();
                                oPer.ESTADO_FIRMA = dr["ESTADO_FIRMA"].ToString();
                                oPer.FLAG_FIRMA = Convert.ToInt32(dr["FLAG_FIRMA"]);
                                oPer.RegEstado = 0;
                                lsCEntidad.ListInformeDetSupervisor.Add(oPer);
                            }
                        }
                        #endregion
                        #region ListTHVerticeCampo
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidad();
                                ocampoEnt.COD_SISTEMA = dr["COD_SISTEMA"].ToString();
                                ocampoEnt.VERTICE = dr["VERTICE"].ToString();
                                ocampoEnt.VERTICE_CAMPO = dr["VERTICE_CAMPO"].ToString();
                                ocampoEnt.ZONA = dr["ZONA"].ToString();
                                ocampoEnt.ZONA_CAMPO = dr["ZONA_CAMPO"].ToString();
                                ocampoEnt.COORDENADA_ESTE = Int32.Parse(dr["COORDENADA_ESTE"].ToString());
                                ocampoEnt.COORDENADA_ESTE_CAMPO = Int32.Parse(dr["COORDENADA_ESTE_CAMPO"].ToString());
                                ocampoEnt.COORDENADA_NORTE = Int32.Parse(dr["COORDENADA_NORTE"].ToString());
                                ocampoEnt.COORDENADA_NORTE_CAMPO = Int32.Parse(dr["COORDENADA_NORTE_CAMPO"].ToString());
                                ocampoEnt.OBSERVACION_CAMPO = dr["OBSERVACION_CAMPO"].ToString();
                                ocampoEnt.RegEstado = 0;
                                lsCEntidad.ListTHVerticeCampo.Add(ocampoEnt);
                            }
                        }
                        #endregion
                        #region ListAvistamientoFauna
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidad();
                                ocampoEnt.COD_ESPECIES = dr["COD_ESPECIES"].ToString();
                                ocampoEnt.DESC_ESPECIES = dr["DESC_ESPECIES"].ToString();
                                ocampoEnt.COD_SECUENCIAL = Int32.Parse(dr["COD_SECUENCIAL"].ToString());
                                ocampoEnt.NOMBRE_COMUN = dr["NOMBRE_COMUN"].ToString();
                                ocampoEnt.NUM_INDIVIDUOS = Int32.Parse(dr["NUM_INDIVIDUOS"].ToString());
                                ocampoEnt.COD_TIPO_REGISTRO = dr["COD_TIPO_REGISTRO"].ToString();
                                ocampoEnt.DESC_TIPO_REGISTRO = dr["DESC_TIPO_REGISTRO"].ToString();
                                ocampoEnt.COD_ESTRATO = dr["COD_ESTRATO"].ToString();
                                ocampoEnt.DESC_ESTRATO = dr["DESC_ESTRATO"].ToString();
                                ocampoEnt.FECHA_AVISTAMIENTO = dr["FECHA_AVISTAMIENTO"].ToString();
                                ocampoEnt.HORA_AVISTAMIENTO = dr["HORA_AVISTAMIENTO"].ToString();
                                ocampoEnt.ZONA = dr["ZONA"].ToString();
                                ocampoEnt.COORDENADA_ESTE = Int32.Parse(dr["COORDENADA_ESTE"].ToString());
                                ocampoEnt.COORDENADA_NORTE = Int32.Parse(dr["COORDENADA_NORTE"].ToString());
                                ocampoEnt.ALTITUD = Decimal.Parse(dr["ALTITUD"].ToString());
                                ocampoEnt.DESCRIPCION = dr["DESCRIPCION"].ToString();
                                ocampoEnt.RegEstado = 0;
                                lsCEntidad.ListAvistamientoFauna.Add(ocampoEnt);
                            }
                        }
                        #endregion
                        #region ListFotos
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                CEntidad ocampo = new CEntidad();
                                ocampo.COD_INFORME_FOTOS = dr["COD_INFORME_FOTOS"].ToString();
                                ocampo.COD_INFORME = dr["COD_INFORME"].ToString();
                                ocampo.URL_FOTO = dr["URL_FOTO"].ToString();
                                ocampo.DESC_FOTO = dr["DESCRIPCION"].ToString();
                                ocampo.FUENTE_FOTO = dr["FUENTE"].ToString();
                                ocampo.DISP_FOTO = dr["DISPOSITIVO"].ToString();
                                ocampo.FECHA = dr["FECHA"].ToString();
                                ocampo.USUARIO_REGISTRO = dr["USUARIO_REGISTRO"].ToString();
                                lsCEntidad.ListFotos.Add(ocampo);
                            }
                        }
                        #endregion
                        #region "ListObligacionTitular"
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            CapaEntidad.DOC.Ent_INFORME_OBLIGTITULAR ocampooblig;
                            while (dr.Read())
                            {
                                ocampooblig = new CapaEntidad.DOC.Ent_INFORME_OBLIGTITULAR();
                                ocampooblig.COD_OBLIGTITULAR = dr["COD_OBLIGTITULAR"].ToString();
                                ocampooblig.OBLIGTITULAR = dr["OBLIGTITULAR"].ToString();
                                ocampooblig.EVAL_OBLIGTITULAR = dr["EVAL_OBLIGTITULAR"].ToString();
                                ocampooblig.OBSERVACION = dr["OBSERVACION"].ToString();
                                ocampooblig.COD_GRUPO = dr["COD_GRUPO"].ToString();
                                lsCEntidad.ListObligacionTitular.Add(ocampooblig);
                            }
                        }
                        #endregion
                        #region "ListISUPERVISION_OCARACTE_AMB01"
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidad();
                                ocampoEnt.COD_OCONTRACTUAL = dr.GetString(dr.GetOrdinal("COD_OCONTRACTUAL"));
                                ocampoEnt.COD_SECUENCIAL = dr.GetInt32(dr.GetOrdinal("COD_SECUENCIAL"));
                                ocampoEnt.COD_ESPECIES = dr.GetString(dr.GetOrdinal("COD_ESPECIES"));
                                ocampoEnt.ESPECIES = dr.GetString(dr.GetOrdinal("ESPECIES"));
                                ocampoEnt.ACTIVIDAD_ACTOS = dr.GetString(dr.GetOrdinal("ACTIVIDAD_ACTOS"));
                                ocampoEnt.ESTA_AUTORIZADO = dr.GetBoolean(dr.GetOrdinal("ESTA_AUTORIZADO"));
                                ocampoEnt.DOCUMENTOS_AFORESTAL = dr.GetString(dr.GetOrdinal("DOCUMENTOS_AFORESTAL"));
                                ocampoEnt.OBSERVACION = dr.GetString(dr.GetOrdinal("OBSERVACION"));
                                ocampoEnt.RegEstado = 0;
                                lsCEntidad.ListISUPERVISION_OCARACTE_AMB01.Add(ocampoEnt);
                            }
                        }
                        #endregion
                        #region ListDesplazamientoInforme
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidad();
                                ocampoEnt.COD_DESPLAZAMIENTO = dr["COD_DESPLAZAMIENTO"].ToString();
                                ocampoEnt.ZONA = dr["PTOI_ZONA_UTM"].ToString();
                                ocampoEnt.COORDENADA_ESTE = Int32.Parse(dr["PTOI_COORDENADA_ESTE"].ToString());
                                ocampoEnt.COORDENADA_NORTE = Int32.Parse(dr["PTOI_COORDENADA_NORTE"].ToString());
                                ocampoEnt.ZONA_CAMPO = dr["PTOF_ZONA_UTM"].ToString();
                                ocampoEnt.COORDENADA_ESTE_CAMPO = Int32.Parse(dr["PTOF_COORDENADA_ESTE"].ToString());
                                ocampoEnt.COORDENADA_NORTE_CAMPO = Int32.Parse(dr["PTOF_COORDENADA_NORTE"].ToString());
                                ocampoEnt.OBSERVACION = dr["OBSERVACION"].ToString();
                                ocampoEnt.TipoVia = dr["TIPO"].ToString();
                                ocampoEnt.RegEstado = 0;
                                lsCEntidad.ListDesplazamientoInforme.Add(ocampoEnt);
                            }
                        }
                        #endregion
                    }
                }
                return lsCEntidad;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ModificarNumeroInforme(string codInforme,string numeroInforme,string asunto,DateTime fechaOperacion)
        {            

           
            using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
            {
                cn.Open();              
                try
                {
                    object[] param = { codInforme, numeroInforme, asunto, fechaOperacion };
                    dBOracle.ManExecute(cn, null, "DOC_OSINFOR_ERP_MIGRACION.SPSUPERVISION_INFORME_NUMERO_GUARDAR", param);
                   
                }
                catch (Exception ex)
                {
                    
                    throw ex;
                }

            }           
        }
        public String RegInsertar_v3(OracleConnection cn, CEntidad oCEntidad)
        {
            OracleTransaction tr = null;
            String OUTPUTPARAM01 = "";

            try
            {
                tr = cn.BeginTransaction();
                #region "Datos Generales"
                using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.INFORME_Grabar_v3", oCEntidad))
                {
                    cmd.ExecuteNonQuery();
                    OUTPUTPARAM01 = (String)cmd.Parameters["OUTPUTPARAM01"].Value;
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
                        throw new Exception("El Número de Informe ya Existe");
                    }
                    else if (OUTPUTPARAM01 == "1")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("El Número del Titulo Habilitante Existe en otro Registro");
                    }
                    else if (OUTPUTPARAM01 == "2")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("No Tiene Permisos para Modificar este Informe");
                    }
                    else if (OUTPUTPARAM01 == "3")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("Está con Control de Calidad, no puede modificar");
                    }
                }
                #endregion

                CEntidad ocampo;

                #region ListEliTABLA
                if (oCEntidad.ListEliTABLA != null)
                {
                    foreach (var loDatos in oCEntidad.ListEliTABLA)
                    {
                        ocampo = new CEntidad();
                        ocampo.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                        ocampo.COD_INFORME_FOTOS = loDatos.COD_INFORME_FOTOS;
                        ocampo.EliTABLA = loDatos.EliTABLA;
                        ocampo.COD_ESPECIES = loDatos.COD_ESPECIES;
                        ocampo.COD_PERSONA = loDatos.COD_PERSONA;
                        ocampo.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                        ocampo.NUM_POA = loDatos.NUM_POA;
                        ocampo.COD_THABILITANTE = loDatos.COD_THABILITANTE;
                        ocampo.COD_CNOTIFICACION = loDatos.COD_CNOTIFICACION;
                        ocampo.COD_MUESTRA_SUPERVISION = loDatos.COD_MUESTRA_SUPERVISION;
                        ocampo.COD_SECUENCIAL_ADENDA = loDatos.COD_SECUENCIAL_ADENDA;
                        ocampo.EliVALOR01 = loDatos.EliVALOR01;
                        ocampo.COD_FISNOTI = loDatos.COD_FISNOTI;
                        dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spINFORME_Eliminar", ocampo);
                    }
                }
                #endregion
                #region ListCNotificaciones
                if (oCEntidad.ListCNotificaciones != null)
                {
                    foreach (var loDatos in oCEntidad.ListCNotificaciones)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            ocampo = new CEntidad();
                            ocampo.COD_CNOTIFICACION = loDatos.COD_CNOTIFICACION;
                            //ocampo.COD_FISNOTI = loDatos.COD_FISNOTI;
                            ocampo.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            ocampo.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spINFORME_DET_CNOTIFICACIONES_Grabar", ocampo);
                            //dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spINFORME_DET_NOTIFICACION_Grabar_v3", ocampo);
                        }
                    }
                }
                #endregion
                #region ListPOAs
                if (oCEntidad.ListPOAs != null)
                {
                    foreach (var loDatos in oCEntidad.ListPOAs)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            ocampo = new CEntidad();
                            ocampo.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            ocampo.NUM_POA = loDatos.NUM_POA;
                            ocampo.PUBLICAR = loDatos.PUBLICAR;
                            ocampo.SUPERVISADO = loDatos.SUPERVISADO;
                            ocampo.CODIGO_SEC_NOPOA = loDatos.CODIGO_SEC_NOPOA;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.ISUPERVISION_INFO_DOCUMENT_Modificar", ocampo);
                        }
                    }
                }
                #endregion
                #region ListInformeDetSupervisor
                if (oCEntidad.ListInformeDetSupervisor != null)
                {
                    CEntPersona ocampoPer;
                    foreach (var loDatos in oCEntidad.ListInformeDetSupervisor)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            ocampoPer = new CEntPersona();
                            ocampoPer.COD_PERSONA = loDatos.COD_PERSONA;
                            ocampoPer.CODIGO = OUTPUTPARAM01.Split('|')[0];
                            ocampoPer.RegEstado = 0;                       
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.INFORME_DET_SUPERVISOR_GrabarV3", ocampoPer);
                        }
                    }
                }
                #endregion
                #region ListTHVerticeCampo
                if (oCEntidad.ListTHVerticeCampo != null)
                {
                    foreach (var loDatos in oCEntidad.ListTHVerticeCampo)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            ocampo = new CEntidad();
                            ocampo.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            ocampo.COD_SISTEMA = loDatos.COD_SISTEMA;
                            ocampo.COD_THABILITANTE = loDatos.COD_SISTEMA.Split('|')[0];
                            ocampo.COD_SECUENCIAL_ADENDA = Convert.ToInt32(loDatos.COD_SISTEMA.Split('|')[1]);
                            ocampo.COD_SECUENCIAL = Convert.ToInt32(loDatos.COD_SISTEMA.Split('|')[2]);
                            ocampo.VERTICE = loDatos.VERTICE_CAMPO;
                            ocampo.ZONA = loDatos.ZONA_CAMPO;
                            ocampo.COORDENADA_ESTE = loDatos.COORDENADA_ESTE_CAMPO;
                            ocampo.COORDENADA_NORTE = loDatos.COORDENADA_NORTE_CAMPO;
                            ocampo.OBSERVACION = loDatos.OBSERVACION_CAMPO;
                            ocampo.COD_UCUENTA = oCEntidad.COD_UCUENTA;
                            ocampo.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spISUPERVISION_DET_VERTICE_THABILITANTE_Grabar", ocampo);
                        }
                    }
                }
                #endregion
                #region ListAvistamientoFauna
                string hora_minuto_segundo;
                //string fecha_avistamiento = "";
                if (oCEntidad.ListAvistamientoFauna != null)
                {
                    DateTime fechaActual;
                    foreach (var loDatos in oCEntidad.ListAvistamientoFauna)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            fechaActual = DateTime.Now;
                            ocampo = new CEntidad();
                            ocampo.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            ocampo.COD_ESPECIES = loDatos.COD_ESPECIES;
                            ocampo.DESC_ESPECIES = loDatos.DESC_ESPECIES;
                            ocampo.NOMBRE_COMUN = loDatos.NOMBRE_COMUN;
                            ocampo.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            ocampo.NUM_INDIVIDUOS = loDatos.NUM_INDIVIDUOS;
                            ocampo.COD_TIPO_REGISTRO = loDatos.COD_TIPO_REGISTRO;
                            ocampo.DESC_TIPO_REGISTRO = loDatos.DESC_TIPO_REGISTRO;
                            ocampo.COD_ESTRATO = loDatos.COD_ESTRATO;
                            ocampo.DESC_ESTRATO = loDatos.DESC_ESTRATO;
                            ocampo.FECHA_AVISTAMIENTO = loDatos.FECHA_AVISTAMIENTO;
                            hora_minuto_segundo = loDatos.HORA_AVISTAMIENTO.ToString();
                            TimeSpan ts;
                            try
                            {
                                ts = new TimeSpan(Convert.ToInt32(hora_minuto_segundo.Split(':')[0]), Convert.ToInt32(hora_minuto_segundo.Split(':')[1]), Convert.ToInt32(hora_minuto_segundo.Split(':')[2].Substring(0, 2)));
                            }
                            catch (Exception)
                            {

                                throw new Exception("Ingrese formato correcto en HH:MM:SS");
                            }

                            ocampo.HORA_AVISTAMIENTO = fechaActual.Date + ts; // fechaActual.AddHours(Convert.ToDouble(hora_minuto_segundo.Split(':')[0])).AddMinutes(Convert.ToDouble(hora_minuto_segundo.Split(':')[1])); // Convert.ToString(loDatos.HORA_AVISTAMIENTO);
                            ocampo.ZONA = loDatos.ZONA;
                            ocampo.COORDENADA_NORTE = loDatos.COORDENADA_NORTE;
                            ocampo.COORDENADA_ESTE = loDatos.COORDENADA_ESTE;
                            ocampo.ALTITUD = loDatos.ALTITUD;
                            ocampo.DESCRIPCION = loDatos.DESCRIPCION;
                            ocampo.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.ISUPERVISION_MADE_NOMADE_DET_AVISTAMIENTO_FAUNA_Grabar", ocampo);
                        }
                    }
                }
                #endregion
                #region ListObligacionTitular
                if (oCEntidad.ListObligacionTitular != null)
                {
                    CapaEntidad.DOC.Ent_INFORME_OBLIGTITULAR ocampooblig;
                    foreach (var loDatos in oCEntidad.ListObligacionTitular)
                    {
                        ocampooblig = new CapaEntidad.DOC.Ent_INFORME_OBLIGTITULAR();
                        ocampooblig.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                        ocampooblig.COD_OBLIGTITULAR = loDatos.COD_OBLIGTITULAR;
                        ocampooblig.EVAL_OBLIGTITULAR = loDatos.EVAL_OBLIGTITULAR ?? "";
                        ocampooblig.OBSERVACION = loDatos.OBSERVACION;
                        ocampooblig.COD_UCUENTA = oCEntidad.COD_UCUENTA;
                        dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spISUPERVISION_OBLIG_TITULARGrabar", ocampooblig);
                    }
                }
                #endregion
                #region "ListISUPERVISION_OCARACTE_AMB01"
                if (oCEntidad.ListISUPERVISION_OCARACTE_AMB01 != null)
                {
                    foreach (var loDatos in oCEntidad.ListISUPERVISION_OCARACTE_AMB01)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            ocampo = new CEntidad();
                            ocampo.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            ocampo.COD_OCONTRACTUAL = loDatos.COD_OCONTRACTUAL;
                            ocampo.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            ocampo.COD_ESPECIES = loDatos.COD_ESPECIES;
                            ocampo.ACTIVIDAD_ACTOS = loDatos.ACTIVIDAD_ACTOS;
                            ocampo.ESTA_AUTORIZADO = loDatos.ESTA_AUTORIZADO;
                            ocampo.DOCUMENTOS_AFORESTAL = loDatos.DOCUMENTOS_AFORESTAL;
                            ocampo.OBSERVACION = loDatos.OBSERVACION;
                            ocampo.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spISUPERVISION_DET_OCONTRACTUALGrabar", ocampo);
                        }
                    }
                }
                #endregion
                #region "ListDesplazamientoInforme"
                if (oCEntidad.ListDesplazamientoInforme != null)
                {
                    foreach (var loDatos in oCEntidad.ListDesplazamientoInforme)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            ocampo = new CEntidad();
                            ocampo.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            ocampo.COD_DESPLAZAMIENTO = loDatos.COD_DESPLAZAMIENTO;
                            ocampo.ZONA = loDatos.ZONA;
                            ocampo.PTOI_COORDENADA_ESTE = loDatos.COORDENADA_ESTE;
                            ocampo.PTOI_COORDENADA_NORTE = loDatos.COORDENADA_NORTE;
                            ocampo.ZONA_CAMPO = loDatos.ZONA_CAMPO;
                            ocampo.PTOF_COORDENADA_ESTE = loDatos.COORDENADA_ESTE_CAMPO;
                            ocampo.PTOF_COORDENADA_NORTE = loDatos.COORDENADA_NORTE_CAMPO;
                            ocampo.OBSERVACION = loDatos.OBSERVACION;
                            ocampo.TIPO = loDatos.TipoVia;
                            ocampo.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spINFORME_DESPLAZAMIENTOGrabar", ocampo);
                        }
                    }
                }
                #endregion

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

        public CEntidad RegMostrarDatosCabecera(OracleConnection cn, string codInforme)
        {
            CEntidad oCampos = new CEntidad();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, "DOC_OSINFOR_ERP_MIGRACION.spINFORME_Datos_Cabecera", codInforme))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            if (dr.Read())
                            {
                                oCampos.COD_INFORME = dr["COD_INFORME"].ToString();
                                oCampos.NUMERO = dr["NUMERO"].ToString();
                                oCampos.COD_CNOTIFICACION = dr["COD_CNOTIFICACION"].ToString();
                                oCampos.NUM_CNOTIFICACION = dr["NUM_CNOTIFICACION"].ToString();
                                oCampos.COD_THABILITANTE = dr["COD_THABILITANTE"].ToString();
                                oCampos.NUM_THABILITANTE = dr["NUM_THABILITANTE"].ToString();
                                oCampos.ESTADO_ORIGEN = dr["ESTADO_ORIGEN_CN"].ToString();
                                oCampos.COD_MTIPO = dr["COD_MTIPO"].ToString();
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
        public CEntidad RegMostrarDatosCabecera_v3(string codInforme)
        {
            CEntidad oCampos = new CEntidad();
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spINFORME_Datos_Cabecera_v3", codInforme))
                    {
                        if (dr != null)
                        {
                            if (dr.HasRows)
                            {
                                if (dr.Read())
                                {
                                    oCampos.COD_INFORME = dr["COD_INFORME"].ToString();
                                    oCampos.NUMERO = dr["NUMERO"].ToString();
                                    oCampos.COD_FISNOTI = dr["COD_FISNOTI"].ToString();
                                    oCampos.NUM_NOTIFICACION = dr["NUM_NOTIFICACION"].ToString();
                                    oCampos.COD_THABILITANTE = dr["COD_THABILITANTE"].ToString();
                                    oCampos.NUM_THABILITANTE = dr["NUM_THABILITANTE"].ToString();
                                    oCampos.ESTADO_ORIGEN = dr["ESTADO_ORIGEN"].ToString();
                                    oCampos.COD_MTIPO = dr["COD_MTIPO"].ToString();
                                }
                            }
                        }
                    }
                    return oCampos;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public String RegInsertarFotoSupervision(OracleConnection cn, CEntidad oCEntidad)
        {
            OracleTransaction tr = null;
            String OUTPUTPARAM01 = "";
            try
            {
                tr = cn.BeginTransaction();
                //Grabando Cabecera
                using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, tr, "doc_osinfor_erp_migracion.SPINFORME_FOTOSGRABAR_V3", oCEntidad))
                {
                    cmd.ExecuteNonQuery();
                    OUTPUTPARAM01 = (String)cmd.Parameters["OUTPUTPARAM01"].Value;
                }
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
        /// <summary>
        /// Eliminar un registro de la BD sin necesidad de grabar todo el formulario
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public void RegEliminar(OracleConnection cn, CEntidad oCEntidad)
        {
            try
            {
                Int32 RegNum = dBOracle.ManExecute(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spINFORME_Eliminar", oCEntidad);
                //if (RegNum == -1)
                //{
                //    throw new Exception("No se pudo eliminar el registro");
                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void RegEliminarList(OracleConnection cn, List<CEntidad> olCEntidad)
        {
            OracleTransaction tr = null;

            try
            {
                tr = cn.BeginTransaction();
                if (olCEntidad != null)
                {
                    CEntidad ocampo;

                    foreach (var loDatos in olCEntidad)
                    {
                        ocampo = new CEntidad();
                        ocampo.EliTABLA = loDatos.EliTABLA;
                        ocampo.COD_INFORME = loDatos.COD_INFORME;
                        ocampo.COD_THABILITANTE = loDatos.COD_THABILITANTE;
                        ocampo.NUM_POA = loDatos.NUM_POA;
                        ocampo.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                        ocampo.COD_ESPECIES = loDatos.COD_ESPECIES;
                        ocampo.COD_MUESTRA_SUPERVISION = loDatos.COD_MUESTRA_SUPERVISION;
                        dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spINFORME_Eliminar", ocampo);
                    }
                }
                tr.Commit();

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

        public CEntidad RegMostrarInfoDocumentPOASupervisado(CEntidad oCEntidad)
        {
            CEntidad lsCEntidad = new CEntidad();
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spISUPERVISION_INFO_DOCUMENTMostrarItem", oCEntidad))
                    {
                        if (dr != null)
                        {
                            lsCEntidad.ListCondicionArea = new List<CapaEntidad.DOC.Ent_INFORME_CONDICION_AREA>();
                            lsCEntidad.ListVerticeArea = new List<CapaEntidad.DOC.Ent_INFORME_VERTICE_AREA>();
                            lsCEntidad.ListEvalArbolAdicional = new List<CapaEntidad.DOC.Ent_INFORME_EVAL_ARBOL>();
                            lsCEntidad.ListEvalArbolNoAutorizado = new List<CapaEntidad.DOC.Ent_INFORME_EVAL_ARBOL>();
                            lsCEntidad.ListHuayrona_v3 = new List<CapaEntidad.DOC.Ent_INFORME_HUAYRONA>();
                            lsCEntidad.ListActividadSilvicultural = new List<CapaEntidad.DOC.Ent_INFORME_ACT_SILVICULTURAL>();
                            lsCEntidad.ListCambioUso = new List<CapaEntidad.DOC.Ent_INFORME_CAMBIO_USO>();
                            lsCEntidad.ListEvaluacionOtro_v3 = new List<CapaEntidad.DOC.Ent_INFORME_EVAL_OTRO>();
                            lsCEntidad.ListVolumenAnalizado = new List<CapaEntidad.DOC.Ent_INFORME_VOL_ANALIZADO>();
                            lsCEntidad.ListAnalisis = new List<CapaEntidad.DOC.Ent_INFORME_ANALISIS>();
                            lsCEntidad.ListConsolidado = new List<CapaEntidad.DOC.Ent_INFORME_CONSOLIDADO>();
                            lsCEntidad.ListConsolidadoNN = new List<CapaEntidad.DOC.Ent_INFORME_CONSOLIDADO>();
                            lsCEntidad.ListMaderable = new List<CapaEntidad.DOC.Ent_INFORME_MADERABLE_A>();
                            lsCEntidad.ListButtonParcelaCorta= new List<CapaEntidad.DOC.Ent_SBusqueda>();

                            #region "Datos Generales"
                            if (dr.HasRows)
                            {
                                dr.Read();
                                lsCEntidad.COD_INFORME = dr.GetString(dr.GetOrdinal("COD_INFORME"));
                                lsCEntidad.NUM_POA = dr.GetInt32(dr.GetOrdinal("NUM_POA"));
                                lsCEntidad.POA = dr.GetString(dr.GetOrdinal("POA"));
                                lsCEntidad.COD_MTIPO = dr.GetString(dr.GetOrdinal("COD_MTIPO"));
                                lsCEntidad.LINDERAMIENTO_AREA = dr.GetString(dr.GetOrdinal("LINDERAMIENTO_AREA"));
                                lsCEntidad.AREA_DEMARCACION = dr.GetString(dr.GetOrdinal("AREA_DEMARCACION"));
                                lsCEntidad.AREA_LINDERAMIENTO = dr.GetString(dr.GetOrdinal("AREA_LINDERAMIENTO"));
                                lsCEntidad.INDICIO_APROV = dr.GetBoolean(dr.GetOrdinal("INDICIO_APROV"));
                                lsCEntidad.OBSERV_APROV = dr.GetString(dr.GetOrdinal("OBSERV_APROV"));
                                lsCEntidad.TIPO_SAPROVECHAMIENTO = dr.GetString(dr.GetOrdinal("TIPO_SAPROVECHAMIENTO"));
                                lsCEntidad.PHUAYRONA_ESTADO = dr.GetString(dr.GetOrdinal("PHUAYRONA_ESTADO"));
                                lsCEntidad.CUMPLE_VIAL_PLANMAN = dr.GetBoolean(dr.GetOrdinal("CUMPLE_VIAL_PLANMAN"));
                                lsCEntidad.CUENTA_AREPOSICION = dr.GetString(dr.GetOrdinal("CUENTA_AREPOSICION"));
                                lsCEntidad.FEC_PRESENT_PM = dr.GetString(dr.GetOrdinal("FEC_PRESENT_PM"));
                                lsCEntidad.FEC_APROB_PM = dr.GetString(dr.GetOrdinal("FEC_APROB_PM"));
                                lsCEntidad.FEC_ENTREGA_ACERVO = dr.GetString(dr.GetOrdinal("FEC_ENTREGA_ACERVO"));
                                lsCEntidad.CUMPLE_PM_PGMF = dr.GetBoolean(dr.GetOrdinal("CUMPLE_PM_PGMF"));
                                lsCEntidad.OBSERV_PM_PGMF = dr.GetString(dr.GetOrdinal("OBSERV_PM_PGMF"));
                                lsCEntidad.APROB_NORMAVIGENTE_PM = dr.GetBoolean(dr.GetOrdinal("APROB_NORMAVIGENTE_PM"));
                                lsCEntidad.OBSERV_NORMAVIGENTE_PM = dr.GetString(dr.GetOrdinal("OBSERV_NORMAVIGENTE_PM"));
                                lsCEntidad.CUENTA_INFOEJECPO = dr.GetString(dr.GetOrdinal("CUENTA_INFOEJECPO"));
                                lsCEntidad.MAE_TIP_IEJECFOREST = dr.GetString(dr.GetOrdinal("MAE_TIP_IEJECFOREST"));
                                lsCEntidad.FEC_PRESENT_INFOEJECPO = dr.GetString(dr.GetOrdinal("FEC_PRESENT_INFOEJECPO"));
                                lsCEntidad.FEC_COMUNIC_INFOEJECPO = dr.GetString(dr.GetOrdinal("FEC_COMUNIC_INFOEJECPO"));
                                lsCEntidad.CUMPLE_LINEA_INFOEJECPO = dr.GetBoolean(dr.GetOrdinal("CUMPLE_LINEA_INFOEJECPO"));
                                lsCEntidad.OBSERV_LINEA_INFOEJECPO = dr.GetString(dr.GetOrdinal("OBSERV_LINEA_INFOEJECPO"));
                                lsCEntidad.CUMPLE_PAGO_APROV = dr.GetBoolean(dr.GetOrdinal("CUMPLE_PAGO_APROV"));
                                lsCEntidad.OBSERV_PAGO_APROV = dr.GetString(dr.GetOrdinal("OBSERV_PAGO_APROV"));
                                lsCEntidad.COD_RESODIREC_GRAVEDAD = dr.GetString(dr.GetOrdinal("COD_RESODIREC_GRAVEDAD"));
                                lsCEntidad.MAE_EST_APROVECHA = dr.GetString(dr.GetOrdinal("MAE_EST_APROVECHA"));
                                lsCEntidad.RECOMEND_REFORMULA = dr.GetBoolean(dr.GetOrdinal("RECOMEND_REFORMULA"));
                                lsCEntidad.RECOMEND_DESCRIPCION = dr.GetString(dr.GetOrdinal("RECOMEND_DESCRIPCION"));
                                lsCEntidad.COD_TITULAR_EJECUTA = dr.GetString(dr.GetOrdinal("COD_TITULAR_EJECUTA"));
                                lsCEntidad.TITULAR_EJECUTA = dr.GetString(dr.GetOrdinal("TITULAR_EJECUTA"));
                                lsCEntidad.COD_REGENTE_IMPLEMENTA = dr.GetString(dr.GetOrdinal("COD_REGENTE_IMPLEMENTA"));
                                lsCEntidad.REGENTE_IMPLEMENTA = dr.GetString(dr.GetOrdinal("REGENTE_IMPLEMENTA"));
                                lsCEntidad.MADERABLE = dr.GetBoolean(dr.GetOrdinal("MAD"));
                                lsCEntidad.NO_MADERABLE = dr.GetBoolean(dr.GetOrdinal("NOMAD"));
                                lsCEntidad.COD_UBIGEO_REGENTE = dr.GetString(dr.GetOrdinal("COD_UBIGEO_REGENTE"));
                                lsCEntidad.UBIGEO_REGENTE = dr.GetString(dr.GetOrdinal("UBIGEO_REGENTE"));
                                lsCEntidad.DIRECCION_REGENTE = dr.GetString(dr.GetOrdinal("DIRECCION_REGENTE"));
                                lsCEntidad.COD_TERCERO_SOLIDARIO = dr.GetString(dr.GetOrdinal("COD_TERCERO_SOLIDARIO"));
                                lsCEntidad.TERCERO_SOLIDARIO = dr.GetString(dr.GetOrdinal("TERCERO_SOLIDARIO"));
                            }
                            #endregion

                            #region ListCondicionArea
                            dr.NextResult();
                            if (dr.HasRows)
                            {
                                CapaEntidad.DOC.Ent_INFORME_CONDICION_AREA oCondicion;
                                while (dr.Read())
                                {
                                    oCondicion = new CapaEntidad.DOC.Ent_INFORME_CONDICION_AREA();
                                    oCondicion.ARBOL_INEX = dr.GetInt32(dr.GetOrdinal("ARBOL_INEX"));
                                    oCondicion.EXISTE_CONDICION = dr.GetBoolean(dr.GetOrdinal("EXISTE_CONDICION"));
                                    oCondicion.OBSERVACION_INEX = dr.GetString(dr.GetOrdinal("OBSERVACION_INEX"));
                                    oCondicion.PORCENTAJE_AREA = dr.GetDecimal(dr.GetOrdinal("PORCENTAJE_AREA"));
                                    oCondicion.COD_AREA = dr.GetString(dr.GetOrdinal("COD_AREA"));
                                    oCondicion.DESC_AREA = dr.GetString(dr.GetOrdinal("DESC_AREA"));
                                    lsCEntidad.ListCondicionArea.Add(oCondicion);
                                }
                            }
                            #endregion
                            #region ListVerticeArea
                            dr.NextResult();
                            if (dr.HasRows)
                            {
                                CapaEntidad.DOC.Ent_INFORME_VERTICE_AREA overtice;
                                while (dr.Read())
                                {
                                    overtice = new CapaEntidad.DOC.Ent_INFORME_VERTICE_AREA();
                                    overtice.COD_SISTEMA = dr["COD_SISTEMA"].ToString();
                                    overtice.COD_SECUENCIAL_POA = Int32.Parse(dr["COD_SECUENCIAL_POA"].ToString());
                                    overtice.COD_SECUENCIAL = Int32.Parse(dr["COD_SECUENCIAL"].ToString());
                                    overtice.COD_SECUENCIAL_POA = Int32.Parse(dr["COD_SECUENCIAL_POA"].ToString());
                                    overtice.ZONA = dr["ZONA"].ToString();
                                    overtice.ZONA_CAMPO = dr["ZONA_CAMPO"].ToString();
                                    overtice.COORDENADA_ESTE = Int32.Parse(dr["COORDENADA_ESTE"].ToString());
                                    overtice.COORDENADA_NORTE = Int32.Parse(dr["COORDENADA_NORTE"].ToString());
                                    overtice.COORDENADA_ESTE_CAMPO = Int32.Parse(dr["COORDENADA_ESTE_CAMPO"].ToString());
                                    overtice.COORDENADA_NORTE_CAMPO = Int32.Parse(dr["COORDENADA_NORTE_CAMPO"].ToString());
                                    overtice.OBSERVACION = dr["OBSERVACION"].ToString();
                                    overtice.VERTICE = dr["VERTICE"].ToString();
                                    overtice.VERTICE_CAMPO = dr["VERTICE_CAMPO"].ToString();
                                    overtice.COD_SISTEMA = dr["COD_SISTEMA"].ToString();
                                    overtice.PCA = dr["PCA"].ToString();
                                    //Datos de campo
                                    overtice.ZONA_CAMPO = dr["ZONA_CAMPO"].ToString();
                                    overtice.COORDENADA_ESTE_CAMPO = Int32.Parse(dr["COORDENADA_ESTE_CAMPO"].ToString());
                                    overtice.COORDENADA_NORTE_CAMPO = Int32.Parse(dr["COORDENADA_NORTE_CAMPO"].ToString());
                                    overtice.OBSERVACION = dr["OBSERVACION"].ToString();
                                    overtice.VERTICE_CAMPO = dr["VERTICE_CAMPO"].ToString();
                                    overtice.PCA_CAMPO = dr["PCA_CAMPO"].ToString();
                                    overtice.RegEstado = 0;
                                    lsCEntidad.ListVerticeArea.Add(overtice);
                                }
                            }
                            #endregion
                            #region ListISupervMaderableAdicional
                            CapaEntidad.DOC.Ent_INFORME_EVAL_ARBOL evalcampo;
                            dr.NextResult();
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    evalcampo = new CapaEntidad.DOC.Ent_INFORME_EVAL_ARBOL();
                                    evalcampo.COD_ESPECIES = dr["COD_ESPECIES"].ToString();
                                    evalcampo.DESC_ESPECIES = dr["DESC_ESPECIES"].ToString();
                                    evalcampo.COD_SECUENCIAL = Int32.Parse(dr["COD_SECUENCIAL"].ToString());
                                    evalcampo.BLOQUE = dr["BLOQUE"].ToString();
                                    evalcampo.FAJA = dr["FAJA"].ToString();
                                    evalcampo.CODIGO = dr["CODIGO"].ToString();
                                    evalcampo.DAP = Decimal.Parse(dr["DAP"].ToString());
                                    evalcampo.DAP1 = Decimal.Parse(dr["DAP_1"].ToString());
                                    evalcampo.DAP2 = Decimal.Parse(dr["DAP_2"].ToString());
                                    evalcampo.MAE_TIP_MMEDIRDAP = dr["MAE_TIP_MMEDIRDAP"].ToString();
                                    evalcampo.MMEDIR_DAP = dr["MMEDIR_DAP"].ToString();
                                    evalcampo.AC = Decimal.Parse(dr["AC"].ToString());
                                    evalcampo.ZONA = dr["ZONA"].ToString();
                                    evalcampo.COORDENADA_ESTE = Int32.Parse(dr["COORDENADA_ESTE"].ToString());
                                    evalcampo.COORDENADA_NORTE = Int32.Parse(dr["COORDENADA_NORTE"].ToString());
                                    evalcampo.COD_EESTADO = dr["COD_EESTADO"].ToString();
                                    evalcampo.DESC_EESTADO = dr["DESC_EESTADO"].ToString();
                                    evalcampo.DESC_ACATEGORIA_CITE = dr["DESC_ACATEGORIA_CITE"].ToString();
                                    evalcampo.DESC_ACATEGORIA_DS = dr["DESC_ACATEGORIA_DS"].ToString();
                                    evalcampo.OBSERVACION = dr["OBSERVACION"].ToString();
                                    evalcampo.RegEstado = 0;
                                    lsCEntidad.ListEvalArbolAdicional.Add(evalcampo);
                                }
                            }
                            #endregion
                            #region ListISupervMaderableNoAutorizado
                            dr.NextResult();
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    evalcampo = new CapaEntidad.DOC.Ent_INFORME_EVAL_ARBOL();
                                    evalcampo.COD_ESPECIES = dr["COD_ESPECIES"].ToString();
                                    evalcampo.DESC_ESPECIES = dr["DESC_ESPECIES"].ToString();
                                    evalcampo.COD_SECUENCIAL = Int32.Parse(dr["COD_SECUENCIAL"].ToString());
                                    evalcampo.BLOQUE = dr["BLOQUE"].ToString();
                                    evalcampo.FAJA = dr["FAJA"].ToString();
                                    evalcampo.CODIGO = dr["CODIGO"].ToString();
                                    evalcampo.DAP = Decimal.Parse(dr["DAP"].ToString());
                                    evalcampo.DAP1 = Decimal.Parse(dr["DAP_1"].ToString());
                                    evalcampo.DAP2 = Decimal.Parse(dr["DAP_2"].ToString());
                                    evalcampo.MAE_TIP_MMEDIRDAP = dr["MAE_TIP_MMEDIRDAP"].ToString();
                                    evalcampo.MMEDIR_DAP = dr["MMEDIR_DAP"].ToString();
                                    evalcampo.AC = Decimal.Parse(dr["AC"].ToString());
                                    evalcampo.ZONA = dr["ZONA"].ToString();
                                    evalcampo.COORDENADA_ESTE = Int32.Parse(dr["COORDENADA_ESTE"].ToString());
                                    evalcampo.COORDENADA_NORTE = Int32.Parse(dr["COORDENADA_NORTE"].ToString());
                                    evalcampo.COD_EESTADO = dr["COD_EESTADO"].ToString();
                                    evalcampo.DESC_EESTADO = dr["DESC_EESTADO"].ToString();
                                    evalcampo.DESC_ACATEGORIA_CITE = dr["DESC_ACATEGORIA_CITE"].ToString();
                                    evalcampo.DESC_ACATEGORIA_DS = dr["DESC_ACATEGORIA_DS"].ToString();
                                    evalcampo.OBSERVACION = dr["OBSERVACION"].ToString();
                                    evalcampo.RegEstado = 0;
                                    lsCEntidad.ListEvalArbolNoAutorizado.Add(evalcampo);
                                }
                            }
                            #endregion
                            #region ListHuayrona_v3
                            dr.NextResult();
                            if (dr.HasRows)
                            {
                                CapaEntidad.DOC.Ent_INFORME_HUAYRONA ocampohuay;
                                while (dr.Read())
                                {
                                    ocampohuay = new CapaEntidad.DOC.Ent_INFORME_HUAYRONA();
                                    ocampohuay.NUMERO = dr["NUMERO"].ToString();
                                    ocampohuay.ZONA = dr["ZONA"].ToString();
                                    ocampohuay.COORDENADA_ESTE = Int32.Parse(dr["COORDENADA_ESTE"].ToString());
                                    ocampohuay.COORDENADA_NORTE = Int32.Parse(dr["COORDENADA_NORTE"].ToString());
                                    ocampohuay.VOLUMEN = Decimal.Parse(dr["VOLUMEN"].ToString());
                                    ocampohuay.RegEstado = 0;
                                    lsCEntidad.ListHuayrona_v3.Add(ocampohuay);
                                }
                            }
                            #endregion
                            #region ListActividadSilvicultural
                            dr.NextResult();
                            if (dr.HasRows)
                            {
                                CapaEntidad.DOC.Ent_INFORME_ACT_SILVICULTURAL ocampoact;

                                while (dr.Read())
                                {
                                    //ocampoSilv = new CEntISDSilvicultural();
                                    ocampoact = new CapaEntidad.DOC.Ent_INFORME_ACT_SILVICULTURAL();
                                    ocampoact.COD_ASILVICULTURALES = dr["COD_ASILVICULTURALES"].ToString();
                                    ocampoact.DESC_SILVICULTURALES = dr["DESC_SILVICULTURALES"].ToString();
                                    ocampoact.COD_SECUENCIAL = Int32.Parse(dr["COD_SECUENCIAL"].ToString());
                                    ocampoact.COD_ESPECIES = dr["COD_ESPECIES"].ToString();
                                    ocampoact.DESC_ESPECIES = dr["DESC_ESPECIES"].ToString();
                                    ocampoact.NUM_PLANTULAS = Int32.Parse(dr["NUM_PLANTULAS"].ToString());
                                    ocampoact.UBICACION = dr["UBICACION"].ToString();
                                    ocampoact.TIEMPO = Int32.Parse(dr["TIEMPO"].ToString());
                                    ocampoact.FAJA = dr["FAJA"].ToString();
                                    ocampoact.OBSERVACION = dr["OBSERVACION"].ToString();
                                    ocampoact.CUMPLIMIENTO_ACTIVIDADES = Int32.Parse(dr["CUMPLIMIENTO_ACTIVIDADES"].ToString()) == 0 ? false : true;
                                    ocampoact.DESC_CUMPLIMIENTO = dr["DESC_CUMPLIMIENTO"].ToString();
                                    ocampoact.RegEstado = 0;
                                    lsCEntidad.ListActividadSilvicultural.Add(ocampoact);
                                }
                            }
                            #endregion
                            #region ListCambioUso
                            dr.NextResult();
                            if (dr.HasRows)
                            {
                                CapaEntidad.DOC.Ent_INFORME_CAMBIO_USO ocambio;
                                while (dr.Read())
                                {
                                    ocambio = new CapaEntidad.DOC.Ent_INFORME_CAMBIO_USO();
                                    ocambio.MAE_TIP_CAMBIOUSO = dr["MAE_TIP_CAMBIOUSO"].ToString();
                                    ocambio.NOM_TIP_CAMBIOUSO = dr["NOM_TIP_CAMBIOUSO"].ToString();
                                    ocambio.COD_SECUENCIAL = Int32.Parse(dr["COD_SECUENCIAL"].ToString());
                                    ocambio.AREA = Decimal.Parse(dr["AREA"].ToString());
                                    ocambio.OBSERVACION = dr["OBSERVACION"].ToString();
                                    ocambio.RegEstado = 0;
                                    ocambio.ZONA = dr["ZONA"].ToString();
                                    ocambio.AUTORIZADO = dr["AUTORIZADO"].ToString();
                                    ocambio.COORDENADA_ESTE = Int32.Parse(dr["COORDENADA_ESTE"].ToString());
                                    ocambio.COORDENADA_NORTE = Int32.Parse(dr["COORDENADA_NORTE"].ToString());
                                    lsCEntidad.ListCambioUso.Add(ocambio);
                                }
                            }
                            #endregion
                            #region ListEvaluacionOtro_v3
                            dr.NextResult();
                            if (dr.HasRows)
                            {
                                CapaEntidad.DOC.Ent_INFORME_EVAL_OTRO oevalotro;
                                while (dr.Read())
                                {
                                    oevalotro = new CapaEntidad.DOC.Ent_INFORME_EVAL_OTRO();
                                    oevalotro.COD_SECUENCIAL = Int32.Parse(dr["COD_SECUENCIAL"].ToString());
                                    oevalotro.EVALUACION = dr["EVALUACION"].ToString();
                                    oevalotro.ZONA = dr["ZONA"].ToString();
                                    oevalotro.COORDENADA_ESTE = Int32.Parse(dr["COORDENADA_ESTE"].ToString());
                                    oevalotro.COORDENADA_NORTE = Int32.Parse(dr["COORDENADA_NORTE"].ToString());
                                    oevalotro.DESCRIPCION = dr["DESCRIPCION"].ToString();
                                    oevalotro.RegEstado = 0;
                                    lsCEntidad.ListEvaluacionOtro_v3.Add(oevalotro);
                                }
                            }
                            #endregion
                            #region ListVolumen
                            dr.NextResult();
                            if (dr.HasRows)
                            {
                                CapaEntidad.DOC.Ent_INFORME_VOL_ANALIZADO ovolumen;
                                while (dr.Read())
                                {
                                    ovolumen = new CapaEntidad.DOC.Ent_INFORME_VOL_ANALIZADO();
                                    ovolumen.COD_SECUENCIAL = Int32.Parse(dr["COD_SECUENCIAL"].ToString());
                                    ovolumen.COD_ESPECIES = dr["COD_ESPECIES"].ToString();
                                    ovolumen.ESPECIES = dr["ESPECIES"].ToString();
                                    ovolumen.VOLUMEN_APROBADO = Decimal.Parse(dr["VOLUMEN_APROBADO"].ToString());
                                    ovolumen.VOLUMEN_MOVILIZADO = Decimal.Parse(dr["VOLUMEN_MOVILIZADO"].ToString());
                                    ovolumen.VOLUMEN_INJUSTIFICADO = Decimal.Parse(dr["VOLUMEN_INJUSTIFICADO"].ToString());
                                    ovolumen.VOLUMEN_JUSTIFICADO = Decimal.Parse(dr["VOLUMEN_JUSTIFICADO"].ToString());
                                    ovolumen.OBSERVACION = dr["OBSERVACION"].ToString();
                                    ovolumen.RegEstado = 0;
                                    ovolumen.PCA = dr["PCA"].ToString();
                                    lsCEntidad.ListVolumenAnalizado.Add(ovolumen);
                                }
                            }
                            #endregion
                            #region ListAnalisisMaderable
                            dr.NextResult();
                            if (dr.HasRows)
                            {
                                CapaEntidad.DOC.Ent_INFORME_ANALISIS oanalisis;
                                while (dr.Read())
                                {
                                    oanalisis = new CapaEntidad.DOC.Ent_INFORME_ANALISIS();
                                    oanalisis.COD_ESPECIES = dr["COD_ESPECIES"].ToString();
                                    oanalisis.NOMBRE_CIENTIFICO = dr["NOMBRE_CIENTIFICO"].ToString();
                                    oanalisis.NUM_PIEZAS = Int32.Parse(dr["NUM_PIEZAS"].ToString());
                                    oanalisis.VOLUMEN_AUTORIZADO = decimal.Parse(dr["VOLUMEN_AUTORIZADO"].ToString());
                                    oanalisis.VOLUMEN = decimal.Parse(dr["VOLUMEN"].ToString());
                                    oanalisis.PORC = decimal.Parse(dr["PORC"].ToString());
                                    oanalisis.SALDO = decimal.Parse(dr["SALDO"].ToString());
                                    oanalisis.NUM_ARBOLES = Int32.Parse(dr["NUM_ARBOLES"].ToString());
                                    oanalisis.VOLUMEN_MOVILIZADO = decimal.Parse(dr["VOLUMEN_MOVILIZADO"].ToString());
                                    oanalisis.DIFERENCIA = decimal.Parse(dr["DIFERENCIA"].ToString());
                                    oanalisis.BEXTRACCION_FEMISION = dr["BEXTRACCION_FEMISION"].ToString();
                                    lsCEntidad.ListAnalisis.Add(oanalisis);
                                }
                            }
                            #endregion
                            #region ListConsolidado
                            dr.NextResult();
                            if (dr.HasRows)
                            {
                                CapaEntidad.DOC.Ent_INFORME_CONSOLIDADO oconsolidado;
                                while (dr.Read())
                                {
                                    oconsolidado = new CapaEntidad.DOC.Ent_INFORME_CONSOLIDADO();
                                    oconsolidado.COD_ESPECIES = dr["COD_ESPECIES"].ToString();
                                    oconsolidado.NOMBRE_CIENTIFICO = dr["NOMBRE_CIENTIFICO"].ToString();
                                    oconsolidado.NUM_PIEZAS = Int32.Parse(dr["NUM_PIEZAS"].ToString());
                                    oconsolidado.VOLUMEN_AUTORIZADO = decimal.Parse(dr["VOLUMEN_AUTORIZADO"].ToString());
                                    oconsolidado.NUM_ARBOLES = Int32.Parse(dr["NUM_ARBOLES"].ToString());
                                    oconsolidado.VOLUMEN_CENSO = decimal.Parse(dr["VOLUMEN_CENSO"].ToString());
                                    oconsolidado.NUM_ARB_SEM = Int32.Parse(dr["NUM_ARB_SEM"].ToString());
                                    oconsolidado.NUM_ARB_TOT = Int32.Parse(dr["NUM_ARB_TOT"].ToString());
                                    oconsolidado.NUM_ARB_AEP = Int32.Parse(dr["NUM_ARB_AEP"].ToString());
                                    oconsolidado.VOLUMEN_AEP = decimal.Parse(dr["VOLUMEN_AEP"].ToString());
                                    oconsolidado.NUM_ARB_ATU = Int32.Parse(dr["NUM_ARB_ATU"].ToString());
                                    oconsolidado.VOLUMEN_ATU = decimal.Parse(dr["VOLUMEN_ATU"].ToString());
                                    oconsolidado.NUM_ARB_ATF = Int32.Parse(dr["NUM_ARB_ATF"].ToString());
                                    oconsolidado.VOLUMEN_ATF = decimal.Parse(dr["VOLUMEN_ATF"].ToString());
                                    oconsolidado.NUM_ARB_AMO = Int32.Parse(dr["NUM_ARB_AMO"].ToString());
                                    oconsolidado.VOLUMEN_AMO = decimal.Parse(dr["VOLUMEN_AMO"].ToString());
                                    oconsolidado.NUM_ARB_AMF = Int32.Parse(dr["NUM_ARB_AMF"].ToString());
                                    oconsolidado.VOLUMEN_AMF = decimal.Parse(dr["VOLUMEN_AMF"].ToString());
                                    oconsolidado.NUM_ARB_ACN = Int32.Parse(dr["NUM_ARB_ACN"].ToString());
                                    oconsolidado.VOLUMEN_ACN = decimal.Parse(dr["VOLUMEN_ACN"].ToString());
                                    oconsolidado.NUM_ARB_ANE = Int32.Parse(dr["NUM_ARB_ANE"].ToString());
                                    oconsolidado.NUM_ARB_NEP = Int32.Parse(dr["NUM_ARB_NEP"].ToString());
                                    oconsolidado.VOLUMEN_NEP = decimal.Parse(dr["VOLUMEN_NEP"].ToString());
                                    oconsolidado.NUM_ARB_NTU = Int32.Parse(dr["NUM_ARB_NTU"].ToString());
                                    oconsolidado.VOLUMEN_NTU = decimal.Parse(dr["VOLUMEN_NTU"].ToString());
                                    oconsolidado.NUM_ARB_NCN = Int32.Parse(dr["NUM_ARB_NCN"].ToString());
                                    oconsolidado.VOLUMEN_NCN = decimal.Parse(dr["VOLUMEN_NCN"].ToString());
                                    oconsolidado.NUM_ARB_SEP = Int32.Parse(dr["NUM_ARB_SEP"].ToString());
                                    oconsolidado.NUM_ARB_STU = Int32.Parse(dr["NUM_ARB_STU"].ToString());
                                    oconsolidado.VOLUMEN_STU = decimal.Parse(dr["VOLUMEN_STU"].ToString());
                                    oconsolidado.NUM_ARB_SMO = Int32.Parse(dr["NUM_ARB_SMO"].ToString());
                                    oconsolidado.VOLUMEN_SMO = decimal.Parse(dr["VOLUMEN_SMO"].ToString());
                                    oconsolidado.NUM_ARB_SCN = Int32.Parse(dr["NUM_ARB_SCN"].ToString());
                                    oconsolidado.NUM_ARB_SNE = Int32.Parse(dr["NUM_ARB_SNE"].ToString());

                                    oconsolidado.NUM_ARB_NEA = Int32.Parse(dr["NUM_ARB_NEA"].ToString());
                                    oconsolidado.NUM_ARB_NES = Int32.Parse(dr["NUM_ARB_NES"].ToString());
                                    oconsolidado.TOTAL_SUP = Int32.Parse(dr["TOTAL_SUP"].ToString());

                                    lsCEntidad.ListConsolidado.Add(oconsolidado);
                                }
                            }
                            #endregion
                            #region ListConsolidado NN
                            dr.NextResult();
                            if (dr.HasRows)
                            {
                                CapaEntidad.DOC.Ent_INFORME_CONSOLIDADO oconsolidado;
                                while (dr.Read())
                                {
                                    oconsolidado = new CapaEntidad.DOC.Ent_INFORME_CONSOLIDADO();
                                    oconsolidado.COD_ESPECIES = dr["COD_ESPECIES"].ToString();
                                    oconsolidado.NOMBRE_CIENTIFICO = dr["NOMBRE_CIENTIFICO"].ToString();
                                    oconsolidado.NUM_PIEZAS = Int32.Parse(dr["NUM_PIEZAS"].ToString());
                                    oconsolidado.VOLUMEN_AUTORIZADO = decimal.Parse(dr["VOLUMEN_AUTORIZADO"].ToString());
                                    oconsolidado.NUM_ARBOLES = Int32.Parse(dr["NUM_ARBOLES"].ToString());
                                    oconsolidado.VOLUMEN_CENSO = decimal.Parse(dr["VOLUMEN_CENSO"].ToString());
                                    oconsolidado.NUM_ARB_SEM = Int32.Parse(dr["NUM_ARB_SEM"].ToString());
                                    oconsolidado.NUM_ARB_TOT = Int32.Parse(dr["NUM_ARB_TOT"].ToString());
                                    oconsolidado.NUM_ARB_AEP = Int32.Parse(dr["NUM_ARB_AEP"].ToString());
                                    oconsolidado.VOLUMEN_AEP = decimal.Parse(dr["VOLUMEN_AEP"].ToString());
                                    oconsolidado.NUM_ARB_ATU = Int32.Parse(dr["NUM_ARB_ATU"].ToString());
                                    oconsolidado.VOLUMEN_ATU = decimal.Parse(dr["VOLUMEN_ATU"].ToString());
                                    oconsolidado.NUM_ARB_ATF = Int32.Parse(dr["NUM_ARB_ATF"].ToString());
                                    oconsolidado.VOLUMEN_ATF = decimal.Parse(dr["VOLUMEN_ATF"].ToString());
                                    oconsolidado.NUM_ARB_AMO = Int32.Parse(dr["NUM_ARB_AMO"].ToString());
                                    oconsolidado.VOLUMEN_AMO = decimal.Parse(dr["VOLUMEN_AMO"].ToString());
                                    oconsolidado.NUM_ARB_AMF = Int32.Parse(dr["NUM_ARB_AMF"].ToString());
                                    oconsolidado.VOLUMEN_AMF = decimal.Parse(dr["VOLUMEN_AMF"].ToString());
                                    oconsolidado.NUM_ARB_ACN = Int32.Parse(dr["NUM_ARB_ACN"].ToString());
                                    oconsolidado.VOLUMEN_ACN = decimal.Parse(dr["VOLUMEN_ACN"].ToString());
                                    oconsolidado.NUM_ARB_ANE = Int32.Parse(dr["NUM_ARB_ANE"].ToString());
                                    oconsolidado.NUM_ARB_NEP = Int32.Parse(dr["NUM_ARB_NEP"].ToString());
                                    oconsolidado.VOLUMEN_NEP = decimal.Parse(dr["VOLUMEN_NEP"].ToString());
                                    oconsolidado.NUM_ARB_NTU = Int32.Parse(dr["NUM_ARB_NTU"].ToString());
                                    oconsolidado.VOLUMEN_NTU = decimal.Parse(dr["VOLUMEN_NTU"].ToString());
                                    //oconsolidado.NUM_ARB_NMO = Int32.Parse(dr["NUM_ARB_NMO"].ToString());
                                    //oconsolidado.VOLUMEN_NMO = decimal.Parse(dr["VOLUMEN_NMO"].ToString());
                                    oconsolidado.NUM_ARB_NCN = Int32.Parse(dr["NUM_ARB_NCN"].ToString());
                                    oconsolidado.VOLUMEN_NCN = decimal.Parse(dr["VOLUMEN_NCN"].ToString());
                                    oconsolidado.NUM_ARB_SEP = Int32.Parse(dr["NUM_ARB_SEP"].ToString());
                                    oconsolidado.NUM_ARB_STU = Int32.Parse(dr["NUM_ARB_STU"].ToString());
                                    oconsolidado.VOLUMEN_STU = decimal.Parse(dr["VOLUMEN_STU"].ToString());
                                    oconsolidado.NUM_ARB_SMO = Int32.Parse(dr["NUM_ARB_SMO"].ToString());
                                    oconsolidado.VOLUMEN_SMO = decimal.Parse(dr["VOLUMEN_SMO"].ToString());
                                    oconsolidado.NUM_ARB_SCN = Int32.Parse(dr["NUM_ARB_SCN"].ToString());
                                    oconsolidado.NUM_ARB_SNE = Int32.Parse(dr["NUM_ARB_SNE"].ToString());

                                    oconsolidado.NUM_ARB_NEA = Int32.Parse(dr["NUM_ARB_NEA"].ToString());
                                    oconsolidado.NUM_ARB_NES = Int32.Parse(dr["NUM_ARB_NES"].ToString());
                                    oconsolidado.TOTAL_SUP = Int32.Parse(dr["TOTAL_SUP"].ToString());

                                    lsCEntidad.ListConsolidadoNN.Add(oconsolidado);
                                }
                            }
                            #endregion
                            #region ListMaderable
                            dr.NextResult();
                            if (dr.HasRows)
                            {
                                CapaEntidad.DOC.Ent_INFORME_MADERABLE_A omaderable;
                                while (dr.Read())
                                {
                                    omaderable = new CapaEntidad.DOC.Ent_INFORME_MADERABLE_A();
                                    omaderable.CODIGO = dr["CODIGO"].ToString();
                                    omaderable.CODIGO_CAMPO = dr["CODIGO_CAMPO"].ToString();
                                    omaderable.DESC_ESPECIES = dr["NOMBRE_PMF"].ToString();
                                    omaderable.DESC_ESPECIES_COMUN = dr["NOMBRE_COMUN_PMF"].ToString();
                                    omaderable.DESC_ESPECIES_CAMPO = dr["NOMBRE_SUP"].ToString();
                                    omaderable.DESC_ESPECIES_COMUN_CAMPO = dr["NOMBRE_COMUN_SUP"].ToString();
                                    omaderable.COORDENADA_ESTE = Int32.Parse(dr["COORDENADA_ESTE_PMF"].ToString());
                                    omaderable.COORDENADA_NORTE = Int32.Parse(dr["COORDENADA_NORTE_PMF"].ToString());
                                    omaderable.COORDENADA_ESTE_CAMPO = Int32.Parse(dr["COORDENADA_ESTE_SUP"].ToString());
                                    omaderable.COORDENADA_NORTE_CAMPO = Int32.Parse(dr["COORDENADA_NORTE_SUP"].ToString());
                                    omaderable.DAP = decimal.Parse(dr["DAP_PMF"].ToString());
                                    omaderable.DAP_CAMPO = decimal.Parse(dr["DAP_SUP"].ToString());
                                    omaderable.DAP_CAMPO1 = decimal.Parse(dr["DAP1_SUP"].ToString());
                                    omaderable.DAP_CAMPO2 = decimal.Parse(dr["DAP2_SUP"].ToString());
                                    omaderable.MMEDIR_DAP = dr["METOD_MEDIR_DAP"].ToString();
                                    omaderable.AC = decimal.Parse(dr["AC_PMF"].ToString());
                                    omaderable.AC_CAMPO = decimal.Parse(dr["AC_SUP"].ToString());
                                    omaderable.VOLUMEN = decimal.Parse(dr["VOL_PMF"].ToString());
                                    omaderable.VOLUMEN_CAMPO = decimal.Parse(dr["VOL_SUP"].ToString());
                                    omaderable.COINCIDE_CODIGO = dr["COINCIDE_CODIGO"].ToString();
                                    omaderable.COINCIDE_ESPECIES = dr["COINCIDE_ESPECIES"].ToString();
                                    omaderable.DAP_RP = decimal.Parse(dr["DAP_RP"].ToString());
                                    omaderable.AC_RP = decimal.Parse(dr["AC_RP"].ToString());
                                    omaderable.COO_RP = decimal.Parse(dr["COO_RP"].ToString());
                                    omaderable.DESC_EESTADO_CAMPO = dr["ESTADO"].ToString();
                                    omaderable.DESC_ECONDICION_CAMPO = dr["CONDICION"].ToString();
                                    lsCEntidad.ListMaderable.Add(omaderable);
                                }
                            }
                            #endregion
                            #region ListButtonParcelaCorta
                            dr.NextResult();
                            if (dr.HasRows)
                            {
                                CapaEntidad.DOC.Ent_SBusqueda oparcelacorta;
                                while (dr.Read())
                                {
                                    oparcelacorta = new CapaEntidad.DOC.Ent_SBusqueda();
                                    oparcelacorta.Value = dr["CODIGO"].ToString();
                                    oparcelacorta.Text = dr["DESCRIPCION"].ToString();
                                    lsCEntidad.ListButtonParcelaCorta.Add(oparcelacorta);
                                }
                            }
                            #endregion
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

        public CEntidad RegMostrarInfoParcelaCorta(CEntidad oCEntidad)
        {
            CEntidad lsCEntidad = new CEntidad();
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spISUPERVISION_INFO_PCMostrarItem", oCEntidad))
                    {
                        if (dr != null)
                        {
                            lsCEntidad.ListAnalisis = new List<CapaEntidad.DOC.Ent_INFORME_ANALISIS>();
                            lsCEntidad.ListConsolidado = new List<CapaEntidad.DOC.Ent_INFORME_CONSOLIDADO>();
                            lsCEntidad.ListConsolidadoNN = new List<CapaEntidad.DOC.Ent_INFORME_CONSOLIDADO>();
                            lsCEntidad.ListMaderable = new List<CapaEntidad.DOC.Ent_INFORME_MADERABLE_A>();

                            #region ListAnalisisMaderable
                            if (dr.HasRows)
                            {
                                CapaEntidad.DOC.Ent_INFORME_ANALISIS oanalisis;
                                while (dr.Read())
                                {
                                    oanalisis = new CapaEntidad.DOC.Ent_INFORME_ANALISIS();
                                    oanalisis.COD_ESPECIES = dr["COD_ESPECIES"].ToString();
                                    oanalisis.NOMBRE_CIENTIFICO = dr["NOMBRE_CIENTIFICO"].ToString();
                                    oanalisis.NUM_PIEZAS = Int32.Parse(dr["NUM_PIEZAS"].ToString());
                                    oanalisis.VOLUMEN_AUTORIZADO = decimal.Parse(dr["VOLUMEN_AUTORIZADO"].ToString());
                                    oanalisis.VOLUMEN = decimal.Parse(dr["VOLUMEN"].ToString());
                                    oanalisis.PORC = decimal.Parse(dr["PORC"].ToString());
                                    oanalisis.SALDO = decimal.Parse(dr["SALDO"].ToString());
                                    oanalisis.NUM_ARBOLES = Int32.Parse(dr["NUM_ARBOLES"].ToString());
                                    oanalisis.VOLUMEN_MOVILIZADO = decimal.Parse(dr["VOLUMEN_MOVILIZADO"].ToString());
                                    oanalisis.DIFERENCIA = decimal.Parse(dr["DIFERENCIA"].ToString());
                                    oanalisis.BEXTRACCION_FEMISION = dr["BEXTRACCION_FEMISION"].ToString();
                                    lsCEntidad.ListAnalisis.Add(oanalisis);
                                }
                            }
                            #endregion
                            #region ListConsolidado
                            dr.NextResult();
                            if (dr.HasRows)
                            {
                                CapaEntidad.DOC.Ent_INFORME_CONSOLIDADO oconsolidado;
                                while (dr.Read())
                                {
                                    oconsolidado = new CapaEntidad.DOC.Ent_INFORME_CONSOLIDADO();
                                    oconsolidado.COD_ESPECIES = dr["COD_ESPECIES"].ToString();
                                    oconsolidado.NOMBRE_CIENTIFICO = dr["NOMBRE_CIENTIFICO"].ToString();
                                    oconsolidado.NUM_PIEZAS = Int32.Parse(dr["NUM_PIEZAS"].ToString());
                                    oconsolidado.VOLUMEN_AUTORIZADO = decimal.Parse(dr["VOLUMEN_AUTORIZADO"].ToString());
                                    oconsolidado.NUM_ARBOLES = Int32.Parse(dr["NUM_ARBOLES"].ToString());
                                    oconsolidado.VOLUMEN_CENSO = decimal.Parse(dr["VOLUMEN_CENSO"].ToString());
                                    oconsolidado.NUM_ARB_SEM = Int32.Parse(dr["NUM_ARB_SEM"].ToString());
                                    oconsolidado.NUM_ARB_TOT = Int32.Parse(dr["NUM_ARB_TOT"].ToString());
                                    oconsolidado.NUM_ARB_AEP = Int32.Parse(dr["NUM_ARB_AEP"].ToString());
                                    oconsolidado.VOLUMEN_AEP = decimal.Parse(dr["VOLUMEN_AEP"].ToString());
                                    oconsolidado.NUM_ARB_ATU = Int32.Parse(dr["NUM_ARB_ATU"].ToString());
                                    oconsolidado.VOLUMEN_ATU = decimal.Parse(dr["VOLUMEN_ATU"].ToString());
                                    oconsolidado.NUM_ARB_ATF = Int32.Parse(dr["NUM_ARB_ATF"].ToString());
                                    oconsolidado.VOLUMEN_ATF = decimal.Parse(dr["VOLUMEN_ATF"].ToString());
                                    oconsolidado.NUM_ARB_AMO = Int32.Parse(dr["NUM_ARB_AMO"].ToString());
                                    oconsolidado.VOLUMEN_AMO = decimal.Parse(dr["VOLUMEN_AMO"].ToString());
                                    oconsolidado.NUM_ARB_AMF = Int32.Parse(dr["NUM_ARB_AMF"].ToString());
                                    oconsolidado.VOLUMEN_AMF = decimal.Parse(dr["VOLUMEN_AMF"].ToString());
                                    oconsolidado.NUM_ARB_ACN = Int32.Parse(dr["NUM_ARB_ACN"].ToString());
                                    oconsolidado.VOLUMEN_ACN = decimal.Parse(dr["VOLUMEN_ACN"].ToString());
                                    oconsolidado.NUM_ARB_ANE = Int32.Parse(dr["NUM_ARB_ANE"].ToString());
                                    oconsolidado.NUM_ARB_NEP = Int32.Parse(dr["NUM_ARB_NEP"].ToString());
                                    oconsolidado.VOLUMEN_NEP = decimal.Parse(dr["VOLUMEN_NEP"].ToString());
                                    oconsolidado.NUM_ARB_NTU = Int32.Parse(dr["NUM_ARB_NTU"].ToString());
                                    oconsolidado.VOLUMEN_NTU = decimal.Parse(dr["VOLUMEN_NTU"].ToString());
                                    oconsolidado.NUM_ARB_NCN = Int32.Parse(dr["NUM_ARB_NCN"].ToString());
                                    oconsolidado.VOLUMEN_NCN = decimal.Parse(dr["VOLUMEN_NCN"].ToString());
                                    oconsolidado.NUM_ARB_SEP = Int32.Parse(dr["NUM_ARB_SEP"].ToString());
                                    oconsolidado.NUM_ARB_STU = Int32.Parse(dr["NUM_ARB_STU"].ToString());
                                    oconsolidado.VOLUMEN_STU = decimal.Parse(dr["VOLUMEN_STU"].ToString());
                                    oconsolidado.NUM_ARB_SMO = Int32.Parse(dr["NUM_ARB_SMO"].ToString());
                                    oconsolidado.VOLUMEN_SMO = decimal.Parse(dr["VOLUMEN_SMO"].ToString());
                                    oconsolidado.NUM_ARB_SCN = Int32.Parse(dr["NUM_ARB_SCN"].ToString());
                                    oconsolidado.NUM_ARB_SNE = Int32.Parse(dr["NUM_ARB_SNE"].ToString());

                                    oconsolidado.NUM_ARB_NEA = Int32.Parse(dr["NUM_ARB_NEA"].ToString());
                                    oconsolidado.NUM_ARB_NES = Int32.Parse(dr["NUM_ARB_NES"].ToString());
                                    oconsolidado.TOTAL_SUP = Int32.Parse(dr["TOTAL_SUP"].ToString());

                                    lsCEntidad.ListConsolidado.Add(oconsolidado);
                                }
                            }
                            #endregion
                            #region ListConsolidado NN
                            dr.NextResult();
                            if (dr.HasRows)
                            {
                                CapaEntidad.DOC.Ent_INFORME_CONSOLIDADO oconsolidado;
                                while (dr.Read())
                                {
                                    oconsolidado = new CapaEntidad.DOC.Ent_INFORME_CONSOLIDADO();
                                    oconsolidado.COD_ESPECIES = dr["COD_ESPECIES"].ToString();
                                    oconsolidado.NOMBRE_CIENTIFICO = dr["NOMBRE_CIENTIFICO"].ToString();
                                    oconsolidado.NUM_PIEZAS = Int32.Parse(dr["NUM_PIEZAS"].ToString());
                                    oconsolidado.VOLUMEN_AUTORIZADO = decimal.Parse(dr["VOLUMEN_AUTORIZADO"].ToString());
                                    oconsolidado.NUM_ARBOLES = Int32.Parse(dr["NUM_ARBOLES"].ToString());
                                    oconsolidado.VOLUMEN_CENSO = decimal.Parse(dr["VOLUMEN_CENSO"].ToString());
                                    oconsolidado.NUM_ARB_SEM = Int32.Parse(dr["NUM_ARB_SEM"].ToString());
                                    oconsolidado.NUM_ARB_TOT = Int32.Parse(dr["NUM_ARB_TOT"].ToString());
                                    oconsolidado.NUM_ARB_AEP = Int32.Parse(dr["NUM_ARB_AEP"].ToString());
                                    oconsolidado.VOLUMEN_AEP = decimal.Parse(dr["VOLUMEN_AEP"].ToString());
                                    oconsolidado.NUM_ARB_ATU = Int32.Parse(dr["NUM_ARB_ATU"].ToString());
                                    oconsolidado.VOLUMEN_ATU = decimal.Parse(dr["VOLUMEN_ATU"].ToString());
                                    oconsolidado.NUM_ARB_ATF = Int32.Parse(dr["NUM_ARB_ATF"].ToString());
                                    oconsolidado.VOLUMEN_ATF = decimal.Parse(dr["VOLUMEN_ATF"].ToString());
                                    oconsolidado.NUM_ARB_AMO = Int32.Parse(dr["NUM_ARB_AMO"].ToString());
                                    oconsolidado.VOLUMEN_AMO = decimal.Parse(dr["VOLUMEN_AMO"].ToString());
                                    oconsolidado.NUM_ARB_AMF = Int32.Parse(dr["NUM_ARB_AMF"].ToString());
                                    oconsolidado.VOLUMEN_AMF = decimal.Parse(dr["VOLUMEN_AMF"].ToString());
                                    oconsolidado.NUM_ARB_ACN = Int32.Parse(dr["NUM_ARB_ACN"].ToString());
                                    oconsolidado.VOLUMEN_ACN = decimal.Parse(dr["VOLUMEN_ACN"].ToString());
                                    oconsolidado.NUM_ARB_ANE = Int32.Parse(dr["NUM_ARB_ANE"].ToString());
                                    oconsolidado.NUM_ARB_NEP = Int32.Parse(dr["NUM_ARB_NEP"].ToString());
                                    oconsolidado.VOLUMEN_NEP = decimal.Parse(dr["VOLUMEN_NEP"].ToString());
                                    oconsolidado.NUM_ARB_NTU = Int32.Parse(dr["NUM_ARB_NTU"].ToString());
                                    oconsolidado.VOLUMEN_NTU = decimal.Parse(dr["VOLUMEN_NTU"].ToString());
                                    //oconsolidado.NUM_ARB_NMO = Int32.Parse(dr["NUM_ARB_NMO"].ToString());
                                    //oconsolidado.VOLUMEN_NMO = decimal.Parse(dr["VOLUMEN_NMO"].ToString());
                                    oconsolidado.NUM_ARB_NCN = Int32.Parse(dr["NUM_ARB_NCN"].ToString());
                                    oconsolidado.VOLUMEN_NCN = decimal.Parse(dr["VOLUMEN_NCN"].ToString());
                                    oconsolidado.NUM_ARB_SEP = Int32.Parse(dr["NUM_ARB_SEP"].ToString());
                                    oconsolidado.NUM_ARB_STU = Int32.Parse(dr["NUM_ARB_STU"].ToString());
                                    oconsolidado.VOLUMEN_STU = decimal.Parse(dr["VOLUMEN_STU"].ToString());
                                    oconsolidado.NUM_ARB_SMO = Int32.Parse(dr["NUM_ARB_SMO"].ToString());
                                    oconsolidado.VOLUMEN_SMO = decimal.Parse(dr["VOLUMEN_SMO"].ToString());
                                    oconsolidado.NUM_ARB_SCN = Int32.Parse(dr["NUM_ARB_SCN"].ToString());
                                    oconsolidado.NUM_ARB_SNE = Int32.Parse(dr["NUM_ARB_SNE"].ToString());

                                    oconsolidado.NUM_ARB_NEA = Int32.Parse(dr["NUM_ARB_NEA"].ToString());
                                    oconsolidado.NUM_ARB_NES = Int32.Parse(dr["NUM_ARB_NES"].ToString());
                                    oconsolidado.TOTAL_SUP = Int32.Parse(dr["TOTAL_SUP"].ToString());

                                    lsCEntidad.ListConsolidadoNN.Add(oconsolidado);
                                }
                            }
                            #endregion
                            #region ListMaderable
                            dr.NextResult();
                            if (dr.HasRows)
                            {
                                CapaEntidad.DOC.Ent_INFORME_MADERABLE_A omaderable;
                                while (dr.Read())
                                {
                                    omaderable = new CapaEntidad.DOC.Ent_INFORME_MADERABLE_A();
                                    omaderable.CODIGO = dr["CODIGO"].ToString();
                                    omaderable.CODIGO_CAMPO = dr["CODIGO_CAMPO"].ToString();
                                    omaderable.DESC_ESPECIES = dr["NOMBRE_PMF"].ToString();
                                    omaderable.DESC_ESPECIES_COMUN = dr["NOMBRE_COMUN_PMF"].ToString();
                                    omaderable.DESC_ESPECIES_CAMPO = dr["NOMBRE_SUP"].ToString();
                                    omaderable.DESC_ESPECIES_COMUN_CAMPO = dr["NOMBRE_COMUN_SUP"].ToString();
                                    omaderable.COORDENADA_ESTE = Int32.Parse(dr["COORDENADA_ESTE_PMF"].ToString());
                                    omaderable.COORDENADA_NORTE = Int32.Parse(dr["COORDENADA_NORTE_PMF"].ToString());
                                    omaderable.COORDENADA_ESTE_CAMPO = Int32.Parse(dr["COORDENADA_ESTE_SUP"].ToString());
                                    omaderable.COORDENADA_NORTE_CAMPO = Int32.Parse(dr["COORDENADA_NORTE_SUP"].ToString());
                                    omaderable.DAP = decimal.Parse(dr["DAP_PMF"].ToString());
                                    omaderable.DAP_CAMPO = decimal.Parse(dr["DAP_SUP"].ToString());
                                    omaderable.DAP_CAMPO1 = decimal.Parse(dr["DAP1_SUP"].ToString());
                                    omaderable.DAP_CAMPO2 = decimal.Parse(dr["DAP2_SUP"].ToString());
                                    omaderable.MMEDIR_DAP = dr["METOD_MEDIR_DAP"].ToString();
                                    omaderable.AC = decimal.Parse(dr["AC_PMF"].ToString());
                                    omaderable.AC_CAMPO = decimal.Parse(dr["AC_SUP"].ToString());
                                    omaderable.VOLUMEN = decimal.Parse(dr["VOL_PMF"].ToString());
                                    omaderable.VOLUMEN_CAMPO = decimal.Parse(dr["VOL_SUP"].ToString());
                                    omaderable.COINCIDE_CODIGO = dr["COINCIDE_CODIGO"].ToString();
                                    omaderable.COINCIDE_ESPECIES = dr["COINCIDE_ESPECIES"].ToString();
                                    omaderable.DAP_RP = decimal.Parse(dr["DAP_RP"].ToString());
                                    omaderable.AC_RP = decimal.Parse(dr["AC_RP"].ToString());
                                    omaderable.COO_RP = decimal.Parse(dr["COO_RP"].ToString());
                                    omaderable.DESC_EESTADO_CAMPO = dr["ESTADO"].ToString();
                                    omaderable.DESC_ECONDICION_CAMPO = dr["CONDICION"].ToString();
                                    lsCEntidad.ListMaderable.Add(omaderable);
                                }
                            }
                            #endregion
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

        public String RegInsertarInfoDocumentPOASupervisado(OracleConnection cn, CEntidad oCEntidad)
        {
            OracleTransaction tr = null;
            String OUTPUTPARAM01 = "";

            try
            {
                tr = cn.BeginTransaction();
                #region "Datos Generales"
                using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.ISUPERVISION_INFO_DOCUMENT_Grabar_v3", oCEntidad))
                {
                    cmd.ExecuteNonQuery();
                    OUTPUTPARAM01 = cmd.Parameters["OUTPUTPARAM01"].Value.ToString();
                    if (OUTPUTPARAM01 == "99")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("Ud. no tiene permiso para realizar esta acción");
                    }
                    else if (OUTPUTPARAM01 == "2")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("No Tiene Permisos para Modificar este Informe");
                    }
                }
                #endregion

                CEntidad ocampo;

                #region ListEliTABLA
                if (oCEntidad.ListEliTABLA != null)
                {
                    foreach (var loDatos in oCEntidad.ListEliTABLA)
                    {
                        ocampo = new CEntidad();
                        ocampo.EliTABLA = loDatos.EliTABLA;
                        ocampo.COD_INFORME = oCEntidad.COD_INFORME;
                        ocampo.NUM_POA = oCEntidad.NUM_POA;
                        ocampo.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                        ocampo.COD_ESPECIES = loDatos.COD_ESPECIES;
                        dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spINFORME_Eliminar", ocampo);
                    }
                }
                #endregion
                #region ListCondicionArea
                if (oCEntidad.ListCondicionArea != null)
                {
                    CapaEntidad.DOC.Ent_INFORME_CONDICION_AREA oParams;
                    foreach (var loDatos in oCEntidad.ListCondicionArea)
                    {
                        oParams = new CapaEntidad.DOC.Ent_INFORME_CONDICION_AREA();
                        oParams.COD_INFORME = oCEntidad.COD_INFORME;
                        oParams.NUM_POA = oCEntidad.NUM_POA;
                        oParams.COD_AREA = loDatos.COD_AREA;
                        oParams.EXISTE_CONDICION = loDatos.EXISTE_CONDICION;
                        oParams.PORCENTAJE_AREA = loDatos.PORCENTAJE_AREA;
                        oParams.ARBOL_INEX = loDatos.ARBOL_INEX;
                        oParams.OBSERVACION_INEX = loDatos.OBSERVACION_INEX;
                        dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spISUPERVISION_CONDICION_AREAGrabar", oParams);
                    }
                }
                #endregion
                #region ListVerticeArea
                if (oCEntidad.ListVerticeArea != null)
                {
                    string codSistema = "";
                    foreach (var loDatos in oCEntidad.ListVerticeArea)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            codSistema = "";
                               ocampo = new CEntidad();
                            ocampo.COD_INFORME = oCEntidad.COD_INFORME;
                            codSistema = loDatos.COD_SISTEMA;
                            if (!string.IsNullOrEmpty(codSistema))
                            {
                                ocampo.COD_SECUENCIAL_POA =Convert.ToInt32(codSistema.Split('|')[1]);
                            }
                            
                            ocampo.NUM_POA = oCEntidad.NUM_POA;

                            if (!string.IsNullOrEmpty(loDatos.COD_SISTEMA) && loDatos.COD_SISTEMA.Split('|').Length > 1)
                            {
                                ocampo.COD_SECUENCIAL_POA = Convert.ToInt32(loDatos.COD_SISTEMA.Split('|')[1]);
                            }
                            
                            ocampo.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            ocampo.VERTICE = loDatos.VERTICE_CAMPO;
                            ocampo.ZONA = loDatos.ZONA_CAMPO;
                            ocampo.COORDENADA_ESTE = loDatos.COORDENADA_ESTE_CAMPO;
                            ocampo.COORDENADA_NORTE = loDatos.COORDENADA_NORTE_CAMPO;
                            ocampo.PCA = loDatos.PCA_CAMPO;
                            ocampo.OBSERVACION = loDatos.OBSERVACION;
                            ocampo.COD_UCUENTA = oCEntidad.COD_UCUENTA;
                            ocampo.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.ISUPERVISION_LINDAREA_VERTICE_Grabar", ocampo);
                        }
                    }
                }
                #endregion
                #region ListEvalArbolAdicional
                if (oCEntidad.ListEvalArbolAdicional != null)
                {
                    foreach (var loDatos in oCEntidad.ListEvalArbolAdicional)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            ocampo = new CEntidad();
                            ocampo.COD_INFORME = oCEntidad.COD_INFORME;
                            ocampo.NUM_POA = oCEntidad.NUM_POA;
                            ocampo.COD_ESPECIES = loDatos.COD_ESPECIES;
                            ocampo.DESC_ESPECIES = loDatos.DESC_ESPECIES;
                            ocampo.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            ocampo.BLOQUE = loDatos.BLOQUE ?? "";
                            ocampo.FAJA = loDatos.FAJA ?? "";
                            ocampo.CODIGO = loDatos.CODIGO ?? "";
                            ocampo.DAP = loDatos.DAP;
                            ocampo.DAP1 = loDatos.DAP1;
                            ocampo.DAP2 = loDatos.DAP2;
                            ocampo.AC = loDatos.AC;
                            ocampo.ZONA = loDatos.ZONA;
                            ocampo.COORDENADA_ESTE = loDatos.COORDENADA_ESTE;
                            ocampo.COORDENADA_NORTE = loDatos.COORDENADA_NORTE;
                            ocampo.COD_EESTADO = loDatos.COD_EESTADO;
                            ocampo.DESC_EESTADO = loDatos.DESC_EESTADO;
                            ocampo.MAE_TIP_MMEDIRDAP = loDatos.MAE_TIP_MMEDIRDAP;
                            ocampo.MMEDIR_DAP = loDatos.MMEDIR_DAP;
                            ocampo.OBSERVACION = loDatos.OBSERVACION ?? "";
                            ocampo.RegEstado = loDatos.RegEstado;
                            ocampo.MAE_TIP_MADERABLE = "0000001";
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.ISUPERVISION_DET_EMADERABLE_ADICIONAL_Grabar", ocampo);
                        }
                    }
                }
                #endregion
                #region ListEvalArbolNoAutorizado
                if (oCEntidad.ListEvalArbolNoAutorizado != null)
                {
                    foreach (var loDatos in oCEntidad.ListEvalArbolNoAutorizado)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            ocampo = new CEntidad();
                            ocampo.COD_INFORME = oCEntidad.COD_INFORME;
                            ocampo.NUM_POA = oCEntidad.NUM_POA;
                            ocampo.COD_ESPECIES = loDatos.COD_ESPECIES;
                            ocampo.DESC_ESPECIES = loDatos.DESC_ESPECIES;
                            ocampo.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            ocampo.BLOQUE = loDatos.BLOQUE ?? "";
                            ocampo.FAJA = loDatos.FAJA ?? "";
                            ocampo.CODIGO = loDatos.CODIGO ?? "";
                            ocampo.DAP = loDatos.DAP;
                            ocampo.DAP1 = loDatos.DAP1;
                            ocampo.DAP2 = loDatos.DAP2;
                            ocampo.AC = loDatos.AC;
                            ocampo.ZONA = loDatos.ZONA;
                            ocampo.COORDENADA_ESTE = loDatos.COORDENADA_ESTE;
                            ocampo.COORDENADA_NORTE = loDatos.COORDENADA_NORTE;
                            ocampo.COD_EESTADO = loDatos.COD_EESTADO;
                            ocampo.DESC_EESTADO = loDatos.DESC_EESTADO;
                            ocampo.MAE_TIP_MMEDIRDAP = loDatos.MAE_TIP_MMEDIRDAP;
                            ocampo.MMEDIR_DAP = loDatos.MMEDIR_DAP;
                            ocampo.OBSERVACION = loDatos.OBSERVACION ?? "";
                            ocampo.RegEstado = loDatos.RegEstado;
                            ocampo.MAE_TIP_MADERABLE = "0000002";
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.ISUPERVISION_DET_EMADERABLE_ADICIONAL_Grabar", ocampo);
                        }
                    }
                }
                #endregion
                #region ListHuayrona_v3
                if (oCEntidad.ListHuayrona_v3 != null)
                {
                    foreach (var loDatos in oCEntidad.ListHuayrona_v3)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            ocampo = new CEntidad();
                            ocampo.COD_INFORME = oCEntidad.COD_INFORME;
                            ocampo.NUM_POA = oCEntidad.NUM_POA;
                            ocampo.NUMERO = loDatos.NUMERO;
                            ocampo.ZONA = loDatos.ZONA;
                            ocampo.COORDENADA_NORTE = loDatos.COORDENADA_NORTE;
                            ocampo.COORDENADA_ESTE = loDatos.COORDENADA_ESTE;
                            ocampo.VOLUMEN = loDatos.VOLUMEN;
                            ocampo.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.ISUPERVISION_MADE_NOMADE_DET_PHUAYRONA_Grabar", ocampo);
                        }
                    }
                }
                #endregion
                #region ListActividadSilvicultural
                if (oCEntidad.ListActividadSilvicultural != null)
                {

                    foreach (var loDatos in oCEntidad.ListActividadSilvicultural)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            ocampo = new CEntidad();
                            ocampo.COD_INFORME = oCEntidad.COD_INFORME;
                            ocampo.NUM_POA = oCEntidad.NUM_POA;
                            ocampo.COD_ASILVICULTURALES = loDatos.COD_ASILVICULTURALES;
                            ocampo.DESC_SILVICULTURALES = loDatos.DESC_SILVICULTURALES;
                            ocampo.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            ocampo.COD_ESPECIES = loDatos.COD_ESPECIES;
                            ocampo.DESC_ESPECIES = loDatos.DESC_ESPECIES;
                            ocampo.FAJA = loDatos.FAJA ?? "";
                            ocampo.NUM_PLANTULAS = loDatos.NUM_PLANTULAS;
                            ocampo.UBICACION = loDatos.UBICACION ?? "";
                            ocampo.TIEMPO = loDatos.TIEMPO;
                            ocampo.CUMPLIMIENTO_ACTIVIDADES = (Boolean)loDatos.CUMPLIMIENTO_ACTIVIDADES == true ? 1 : 0;
                            ocampo.OBSERVACION = loDatos.OBSERVACION ?? "";
                            ocampo.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.ISUPERVISION_DET_ASILVICULTURALES_Grabar", ocampo);
                        }
                    }
                }
                #endregion
                #region ListCambioUso
                if (oCEntidad.ListCambioUso != null)
                {
                    foreach (var loDatos in oCEntidad.ListCambioUso)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            ocampo = new CEntidad();
                            ocampo.COD_INFORME = oCEntidad.COD_INFORME;
                            ocampo.NUM_POA = oCEntidad.NUM_POA;
                            ocampo.MAE_TIP_CAMBIOUSO = loDatos.MAE_TIP_CAMBIOUSO;
                            ocampo.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            ocampo.AREA = loDatos.AREA;
                            ocampo.OBSERVACION = loDatos.OBSERVACION;
                            ocampo.AUTORIZADO = loDatos.AUTORIZADO;
                            ocampo.COD_UCUENTA = oCEntidad.COD_UCUENTA;
                            ocampo.RegEstado = loDatos.RegEstado;
                            ocampo.ZONA = loDatos.ZONA;
                            ocampo.COORDENADA_ESTE = loDatos.COORDENADA_ESTE;
                            ocampo.COORDENADA_NORTE = loDatos.COORDENADA_NORTE;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.ISUPERVISION_CAMBIO_USO_Grabar", ocampo);
                        }
                    }
                }
                #endregion
                #region ListEvaluacionOtro_v3
                if (oCEntidad.ListEvaluacionOtro_v3 != null)
                {
                    foreach (var loDatos in oCEntidad.ListEvaluacionOtro_v3)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            ocampo = new CEntidad();
                            ocampo.COD_INFORME = oCEntidad.COD_INFORME;
                            ocampo.NUM_POA = oCEntidad.NUM_POA;
                            ocampo.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            ocampo.EVALUACION = loDatos.EVALUACION;
                            ocampo.ZONA = loDatos.ZONA;
                            ocampo.COORDENADA_ESTE = loDatos.COORDENADA_ESTE;
                            ocampo.COORDENADA_NORTE = loDatos.COORDENADA_NORTE;
                            ocampo.DESCRIPCION = loDatos.DESCRIPCION;
                            ocampo.COD_UCUENTA = oCEntidad.COD_UCUENTA;
                            ocampo.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.ISUPERVISION_DET_EVALUACION_OTROS_Grabar", ocampo);
                        }
                    }
                }
                #endregion
                #region ListVolumen
                if (oCEntidad.ListVolumenAnalizado != null)
                {
                    foreach (var loDatos in oCEntidad.ListVolumenAnalizado)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            ocampo = new CEntidad();
                            ocampo.COD_INFORME = oCEntidad.COD_INFORME;
                            ocampo.NUM_POA = oCEntidad.NUM_POA;
                            ocampo.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            ocampo.COD_ESPECIES = loDatos.COD_ESPECIES;
                            ocampo.ESPECIES = loDatos.ESPECIES;
                            ocampo.VOLUMEN_APROBADO = loDatos.VOLUMEN_APROBADO;
                            ocampo.VOLUMEN_MOVILIZADO = loDatos.VOLUMEN_MOVILIZADO;
                            ocampo.VOLUMEN_INJUSTIFICADO = loDatos.VOLUMEN_INJUSTIFICADO;
                            ocampo.VOLUMEN_JUSTIFICADO = loDatos.VOLUMEN_JUSTIFICADO;
                            ocampo.OBSERVACION = loDatos.OBSERVACION;
                            ocampo.COD_UCUENTA = oCEntidad.COD_UCUENTA;
                            ocampo.PCA = loDatos.PCA;
                            ocampo.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spISUPERVISION_DET_VOLUMENGrabar", ocampo);
                        }
                    }
                }
                #endregion

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

        public CEntidad RegMostrarInfoDocumentResumenSupervisado(CEntidad oCEntidad)
        {
            CEntidad lsCEntidad = new CEntidad();
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spISUPERVISION_INFO_RESUMEN", oCEntidad))
                    {
                        if(dr != null)
                        {
                            lsCEntidad.ListVolumenAnalizado = new List<Ent_INFORME_VOL_ANALIZADO>();

                            #region ListVolumen
                            //dr.NextResult();
                            if (dr.HasRows)
                            {
                                Ent_INFORME_VOL_ANALIZADO ovolumen;
                                while (dr.Read())
                                {
                                    ovolumen = new Ent_INFORME_VOL_ANALIZADO();
                                    ovolumen.COD_SECUENCIAL = Int32.Parse(dr["COD_SECUENCIAL"].ToString());
                                    ovolumen.COD_ESPECIES = dr["COD_ESPECIES"].ToString();
                                    ovolumen.ESPECIES = dr["ESPECIES"].ToString();
                                    ovolumen.VOLUMEN_APROBADO = Decimal.Parse(dr["VOLUMEN_APROBADO"].ToString());
                                    ovolumen.VOLUMEN_MOVILIZADO = Decimal.Parse(dr["VOLUMEN_MOVILIZADO"].ToString());
                                    ovolumen.VOLUMEN_INJUSTIFICADO = Decimal.Parse(dr["VOLUMEN_INJUSTIFICADO"].ToString());
                                    ovolumen.VOLUMEN_JUSTIFICADO = Decimal.Parse(dr["VOLUMEN_JUSTIFICADO"].ToString());
                                    ovolumen.OBSERVACION = dr["OBSERVACION"].ToString();
                                    ovolumen.RegEstado = 0;
                                    lsCEntidad.ListVolumenAnalizado.Add(ovolumen);
                                }
                            }
                            #endregion
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

        public String RegInsertarInfoDocumentPOAArboles(OracleConnection cn, CEntidad oCEntidad)
        {
            OracleTransaction tr = null;
            String OUTPUTPARAM01 = "";

            try
            {
                tr = cn.BeginTransaction();
                CEntidad ocampo;
                #region ListEliTABLA
                if (oCEntidad.ListEliTABLA != null)
                {
                    foreach (var loDatos in oCEntidad.ListEliTABLA)
                    {
                        ocampo = new CEntidad();
                        ocampo.EliTABLA = loDatos.EliTABLA;
                        ocampo.COD_INFORME = oCEntidad.COD_INFORME;
                        ocampo.NUM_POA = oCEntidad.NUM_POA;
                        ocampo.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                        ocampo.COD_ESPECIES = loDatos.COD_ESPECIES;
                        dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spINFORME_Eliminar", ocampo);
                    }
                }
                #endregion
                #region ListEvalArbolAdicional
                if (oCEntidad.ListEvalArbolAdicional != null)
                {
                    foreach (var loDatos in oCEntidad.ListEvalArbolAdicional)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            ocampo = new CEntidad();
                            ocampo.COD_INFORME = oCEntidad.COD_INFORME;
                            ocampo.NUM_POA = oCEntidad.NUM_POA;
                            ocampo.CODIGO_SEC_NOPOA = oCEntidad.CODIGO_SEC_NOPOA;
                            ocampo.COD_ESPECIES = loDatos.COD_ESPECIES;
                            ocampo.DESC_ESPECIES = loDatos.DESC_ESPECIES;
                            ocampo.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            ocampo.BLOQUE = loDatos.BLOQUE ?? "";
                            ocampo.FAJA = loDatos.FAJA ?? "";
                            ocampo.CODIGO = loDatos.CODIGO ?? "";
                            ocampo.DAP = loDatos.DAP;
                            ocampo.DAP1 = loDatos.DAP1;
                            ocampo.DAP2 = loDatos.DAP2;
                            ocampo.AC = loDatos.AC;
                            ocampo.ZONA = loDatos.ZONA;
                            ocampo.COORDENADA_ESTE = loDatos.COORDENADA_ESTE;
                            ocampo.COORDENADA_NORTE = loDatos.COORDENADA_NORTE;
                            ocampo.COD_EESTADO = loDatos.COD_EESTADO;
                            ocampo.DESC_EESTADO = loDatos.DESC_EESTADO;
                            ocampo.MAE_TIP_MMEDIRDAP = loDatos.MAE_TIP_MMEDIRDAP;
                            ocampo.MMEDIR_DAP = loDatos.MMEDIR_DAP;
                            ocampo.OBSERVACION = loDatos.OBSERVACION ?? "";
                            ocampo.RegEstado = loDatos.RegEstado;
                            ocampo.MAE_TIP_MADERABLE = "0000001";
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.ISUPERVISION_DET_EMADERABLE_ADICIONAL_Grabar", ocampo);
                        }
                    }
                }
                #endregion
                #region ListEvalArbolNoAutorizado
                if (oCEntidad.ListEvalArbolNoAutorizado != null)
                {
                    foreach (var loDatos in oCEntidad.ListEvalArbolNoAutorizado)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            ocampo = new CEntidad();
                            ocampo.COD_INFORME = oCEntidad.COD_INFORME;
                            ocampo.NUM_POA = oCEntidad.NUM_POA;
                            ocampo.CODIGO_SEC_NOPOA = oCEntidad.CODIGO_SEC_NOPOA;
                            ocampo.COD_ESPECIES = loDatos.COD_ESPECIES;
                            ocampo.DESC_ESPECIES = loDatos.DESC_ESPECIES;
                            ocampo.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            ocampo.BLOQUE = loDatos.BLOQUE ?? "";
                            ocampo.FAJA = loDatos.FAJA ?? "";
                            ocampo.CODIGO = loDatos.CODIGO ?? "";
                            ocampo.DAP = loDatos.DAP;
                            ocampo.DAP1 = loDatos.DAP1;
                            ocampo.DAP2 = loDatos.DAP2;
                            ocampo.AC = loDatos.AC;
                            ocampo.ZONA = loDatos.ZONA;
                            ocampo.COORDENADA_ESTE = loDatos.COORDENADA_ESTE;
                            ocampo.COORDENADA_NORTE = loDatos.COORDENADA_NORTE;
                            ocampo.COD_EESTADO = loDatos.COD_EESTADO;
                            ocampo.DESC_EESTADO = loDatos.DESC_EESTADO;
                            ocampo.MAE_TIP_MMEDIRDAP = loDatos.MAE_TIP_MMEDIRDAP;
                            ocampo.MMEDIR_DAP = loDatos.MMEDIR_DAP;
                            ocampo.OBSERVACION = loDatos.OBSERVACION ?? "";
                            ocampo.RegEstado = loDatos.RegEstado;
                            ocampo.MAE_TIP_MADERABLE = "0000002";
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.ISUPERVISION_DET_EMADERABLE_ADICIONAL_Grabar", ocampo);
                        }
                    }
                }
                #endregion
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
        public CEntidad RegMostrarCantidadMuestraDatosCampo(CEntidad oCEntidad)
        {
            CEntidad lsCEntidad = new CEntidad();
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.SPGET_CANTIDAD_MUESTRA_DATOSCAMPO_INFORME", oCEntidad))
                    {
                        if (dr != null)
                        {
                            if (dr.HasRows)
                            {
                                dr.Read();
                                lsCEntidad.CANTIDAD = dr.GetInt32(dr.GetOrdinal("CANTIDAD"));
                                lsCEntidad.CANTIDAD_CAMPO = dr.GetInt32(dr.GetOrdinal("CANTIDAD_CAMPO"));
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

        public List<CapaEntidad.DOC.Ent_INFORME_MADERABLE> RegMostrarMuestraDatosCampoMade(string asCodInforme)
        {
            List<CapaEntidad.DOC.Ent_INFORME_MADERABLE> lsCEntidad = new List<CapaEntidad.DOC.Ent_INFORME_MADERABLE>();
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spGETLIST_MUESTRA_DATOSCAMPO_INFORME", new CEntidad() { TIPO = "MADERABLE", COD_INFORME = asCodInforme }))
                    {
                        if (dr != null)
                        {
                            if (dr.HasRows)
                            {
                                CapaEntidad.DOC.Ent_INFORME_MADERABLE oCampo;

                                while (dr.Read())
                                {
                                    oCampo = new CapaEntidad.DOC.Ent_INFORME_MADERABLE();
                                    oCampo.COD_SECUENCIAL = Int32.Parse(dr["COD_SECUENCIAL"].ToString());
                                    oCampo.COD_THABILITANTE = dr["COD_THABILITANTE"].ToString();
                                    oCampo.NUM_POA = Int32.Parse(dr["NUM_POA"].ToString());
                                    oCampo.POA = dr["POA"].ToString();
                                    oCampo.BLOQUE = dr["BLOQUE"].ToString();
                                    oCampo.BLOQUE_CAMPO = dr["BLOQUE_2"].ToString();
                                    oCampo.FAJA = dr["FAJA"].ToString();
                                    oCampo.FAJA_CAMPO = dr["FAJA_2"].ToString();
                                    oCampo.CODIGO = dr["CODIGO"].ToString();
                                    oCampo.CODIGO_CAMPO = dr["CODIGO_2"].ToString();
                                    oCampo.COD_ESPECIES = dr["COD_ESPECIES"].ToString();
                                    oCampo.DESC_ESPECIES = dr["DESC_ESPECIES"].ToString();
                                    oCampo.COD_ESPECIES_CAMPO = dr["COD_ESPECIES_CAMPO"].ToString();
                                    oCampo.DESC_ESPECIES_CAMPO = dr["DESC_ESPECIES_2"].ToString();
                                    oCampo.COINCIDE_ESPECIES = dr["COINCIDE_ESPECIES"].ToString();
                                    oCampo.DESC_COINCIDE_ESPECIES = oCampo.COINCIDE_ESPECIES == "NN" ? "Ninguno" : (oCampo.COINCIDE_ESPECIES == "-" ? "" : oCampo.COINCIDE_ESPECIES);
                                    oCampo.ZONA = dr["ZONA"].ToString();
                                    oCampo.ZONA_CAMPO = dr["ZONA_2"].ToString();
                                    oCampo.COORDENADA_ESTE = Int32.Parse(dr["COORDENADA_ESTE"].ToString());
                                    oCampo.COORDENADA_ESTE_CAMPO = Int32.Parse(dr["COORDENADA_ESTE_2"].ToString());
                                    oCampo.COORDENADA_NORTE = Int32.Parse(dr["COORDENADA_NORTE"].ToString());
                                    oCampo.COORDENADA_NORTE_CAMPO = Int32.Parse(dr["COORDENADA_NORTE_2"].ToString());
                                    oCampo.DAP = Decimal.Parse(dr["DAP"].ToString());
                                    oCampo.DAP_CAMPO = Decimal.Parse(dr["DAP_CAMPO"].ToString());
                                    oCampo.DAP_CAMPO1 = Decimal.Parse(dr["DAP_CAMPO1"].ToString());
                                    oCampo.DAP_CAMPO2 = Decimal.Parse(dr["DAP_CAMPO2"].ToString());
                                    oCampo.MAE_TIP_MMEDIRDAP = dr["MAE_TIP_MMEDIRDAP"].ToString();
                                    oCampo.MMEDIR_DAP = dr["MMEDIR_DAP"].ToString();
                                    oCampo.AC = Decimal.Parse(dr["AC"].ToString());
                                    oCampo.AC_CAMPO = Decimal.Parse(dr["AC_2"].ToString());
                                    oCampo.DESC_EESTADO = dr["DESC_EESTADO"].ToString();
                                    oCampo.COD_EESTADO = dr["COD_EESTADO"].ToString();
                                    oCampo.DESC_EESTADO_CAMPO = dr["DESC_EESTADO_2"].ToString();
                                    oCampo.COD_ECONDICION = dr["COD_ECONDICION"].ToString();
                                    oCampo.DESC_ECONDICION = dr["DESC_ECONDICION"].ToString();
                                    oCampo.COD_ECONDICION_CAMPO = dr["COD_ECONDICION_CAMPO"].ToString();
                                    oCampo.DESC_ECONDICION_CAMPO = dr["DESC_ECONDICION_CAMPO"].ToString();
                                    oCampo.CANT_SOBRE_ESTIMA_DIAMETRO = Int32.Parse(dr["CANT_SOBRE_ESTIMA_DIAMETRO"].ToString());
                                    oCampo.PORC_SOBRE_ESTIMA_DIAMETRO = Decimal.Parse(dr["PORC_SOBRE_ESTIMA_DIAMETRO"].ToString());
                                    oCampo.CANT_SUB_ESTIMA_DIAMETRO = Int32.Parse(dr["CANT_SUB_ESTIMA_DIAMETRO"].ToString());
                                    oCampo.PORC_SUB_ESTIMA_DIAMETRO = Decimal.Parse(dr["PORC_SUB_ESTIMA_DIAMETRO"].ToString());
                                    oCampo.OBSERVACION = dr["OBSERVACION"].ToString();
                                    oCampo.PCA = dr["PCA"].ToString();
                                    oCampo.PCA_POA = dr["PCA_POA"].ToString();
                                    oCampo.RegEstado = 0;
                                    lsCEntidad.Add(oCampo);
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
        public String RegInsertarMuestraDatosCampoMade(OracleConnection cn, CapaEntidad.DOC.Ent_INFORME_MADERABLE oCEntidad)
        {
            OracleTransaction tr = null;
            try
            {
                //Set datos enviar
                CEntidad oParams = new CEntidad();
                oParams.COD_INFORME = oCEntidad.COD_INFORME;
                oParams.COD_THABILITANTE = oCEntidad.COD_THABILITANTE;
                oParams.NUM_POA = oCEntidad.NUM_POA;
                oParams.COD_ESPECIES = oCEntidad.COD_ESPECIES;
                oParams.COD_SECUENCIAL = oCEntidad.COD_SECUENCIAL;
                oParams.COD_ESPECIES_CAMPO = oCEntidad.COD_ESPECIES_CAMPO == "" ? null : oCEntidad.COD_ESPECIES_CAMPO;
                oParams.BLOQUE = oCEntidad.BLOQUE_CAMPO ?? "";
                oParams.FAJA = oCEntidad.FAJA_CAMPO ?? "";
                oParams.CODIGO = oCEntidad.CODIGO_CAMPO ?? "";
                oParams.DAP = oCEntidad.DAP_CAMPO == -1 ? 0 : oCEntidad.DAP_CAMPO;
                oParams.AC = oCEntidad.AC_CAMPO == -1 ? 0 : oCEntidad.AC_CAMPO;
                oParams.ZONA = oCEntidad.ZONA_CAMPO;
                oParams.COORDENADA_ESTE = oCEntidad.COORDENADA_ESTE_CAMPO == -1 ? 0 : oCEntidad.COORDENADA_ESTE_CAMPO;
                oParams.COORDENADA_NORTE = oCEntidad.COORDENADA_NORTE_CAMPO == -1 ? 0 : oCEntidad.COORDENADA_NORTE_CAMPO;
                oParams.COD_EESTADO = oCEntidad.COD_EESTADO == "" ? null : oCEntidad.COD_EESTADO;
                oParams.OBSERVACION = oCEntidad.OBSERVACION ?? "";
                oParams.DAP2 = oCEntidad.DAP_CAMPO2 == -1 ? 0 : oCEntidad.DAP_CAMPO2;
                oParams.DAP1 = oCEntidad.DAP_CAMPO1 == -1 ? 0 : oCEntidad.DAP_CAMPO1;
                oParams.COINCIDE_ESPECIES = oCEntidad.COINCIDE_ESPECIES;
                oParams.MAE_TIP_MMEDIRDAP = oCEntidad.MAE_TIP_MMEDIRDAP == "0000000" || oCEntidad.MAE_TIP_MMEDIRDAP == "" ? null : oCEntidad.MAE_TIP_MMEDIRDAP;
                oParams.MMEDIR_DAP = oCEntidad.MMEDIR_DAP;
                oParams.COD_ECONDICION = oCEntidad.COD_ECONDICION_CAMPO == "0000000" || oCEntidad.COD_ECONDICION_CAMPO == "" ? null : oCEntidad.COD_ECONDICION_CAMPO;
                oParams.DESC_ECONDICION = oCEntidad.DESC_ECONDICION;
                oParams.CANT_SOBRE_ESTIMA_DIAMETRO = oCEntidad.CANT_SOBRE_ESTIMA_DIAMETRO;
                oParams.PORC_SOBRE_ESTIMA_DIAMETRO = oCEntidad.PORC_SOBRE_ESTIMA_DIAMETRO;
                oParams.CANT_SUB_ESTIMA_DIAMETRO = oCEntidad.CANT_SUB_ESTIMA_DIAMETRO;
                oParams.PORC_SUB_ESTIMA_DIAMETRO = oCEntidad.PORC_SUB_ESTIMA_DIAMETRO;
                oParams.VIGENCIA = oCEntidad.VIGENCIA;
                oParams.VOLUMEN = oCEntidad.VOLUMEN;
                oParams.RegEstado = oCEntidad.RegEstado;
                oParams.PCA = oCEntidad.PCA;

                tr = cn.BeginTransaction();
                dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.ISUPERVISION_DET_EMADERABLE_Grabar", oParams);
                tr.Commit();
                return "Ok";
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

        public List<CapaEntidad.DOC.Ent_INFORME_BOSQUE_SECO> RegMostrarMuestraDatosCampoBosqueSeco(string asCodInforme)
        {
            List<CapaEntidad.DOC.Ent_INFORME_BOSQUE_SECO> lsCEntidad = new List<CapaEntidad.DOC.Ent_INFORME_BOSQUE_SECO>();
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spGETLIST_MUESTRA_DATOSCAMPO_INFORME", new CEntidad() { TIPO = "BOSQUE_SECO", COD_INFORME = asCodInforme }))
                    {
                        if (dr != null)
                        {
                            if (dr.HasRows)
                            {
                                CapaEntidad.DOC.Ent_INFORME_BOSQUE_SECO oCampo;

                                while (dr.Read())
                                {
                                    oCampo = new CapaEntidad.DOC.Ent_INFORME_BOSQUE_SECO();
                                    oCampo.COD_SECUENCIAL = Int32.Parse(dr["COD_SECUENCIAL"].ToString());
                                    oCampo.COD_THABILITANTE = dr["COD_THABILITANTE"].ToString();
                                    oCampo.NUM_POA = Int32.Parse(dr["NUM_POA"].ToString());
                                    oCampo.POA = dr["POA"].ToString();
                                    oCampo.COD_ESPECIES = dr["COD_ESPECIES"].ToString();
                                    oCampo.DESC_ESPECIES = dr["DESC_ESPECIES"].ToString();
                                    oCampo.COD_ESPECIES_CAMPO = dr["COD_ESPECIES_CAMPO"].ToString();
                                    oCampo.DESC_ESPECIES_CAMPO = dr["DESC_ESPECIES_2"].ToString();
                                    oCampo.BLOQUE = dr["BLOQUE"].ToString();
                                    oCampo.BLOQUE_CAMPO = dr["BLOQUE_2"].ToString();
                                    oCampo.FAJA = dr["FAJA"].ToString();
                                    oCampo.FAJA_CAMPO = dr["FAJA_2"].ToString();
                                    oCampo.CODIGO = dr["CODIGO"].ToString();
                                    oCampo.CODIGO_CAMPO = dr["CODIGO_2"].ToString();
                                    oCampo.DAP = Decimal.Parse(dr["DAP"].ToString());
                                    oCampo.DAP_CAMPO = Decimal.Parse(dr["DAP_CAMPO"].ToString());
                                    oCampo.AC = Decimal.Parse(dr["AC"].ToString());
                                    oCampo.AC_CAMPO = Decimal.Parse(dr["AC_2"].ToString());
                                    oCampo.ZONA = dr["ZONA"].ToString();
                                    oCampo.ZONA_CAMPO = dr["ZONA_2"].ToString();
                                    oCampo.COORDENADA_ESTE = Int32.Parse(dr["COORDENADA_ESTE"].ToString());
                                    oCampo.COORDENADA_ESTE_CAMPO = Int32.Parse(dr["COORDENADA_ESTE_2"].ToString());
                                    oCampo.COORDENADA_NORTE = Int32.Parse(dr["COORDENADA_NORTE"].ToString());
                                    oCampo.COORDENADA_NORTE_CAMPO = Int32.Parse(dr["COORDENADA_NORTE_2"].ToString());
                                    oCampo.DESC_EESTADO = dr["DESC_EESTADO"].ToString();
                                    oCampo.COD_EESTADO = dr["COD_EESTADO"].ToString();
                                    oCampo.DESC_EESTADO_CAMPO = dr["DESC_EESTADO_2"].ToString();
                                    oCampo.DESC_ACATEGORIA_CITE = dr["DESC_ACATEGORIA_CITE"].ToString();
                                    oCampo.DESC_ACATEGORIA_DS = dr["DESC_ACATEGORIA_DS"].ToString();
                                    oCampo.BS_ALTURA_TOTAL = Decimal.Parse(dr["BS_ALTURA_TOTAL"].ToString());
                                    oCampo.BS_DIAMETRO_RAMA_1 = Decimal.Parse(dr["BS_DIAMETRO_RAMA_1"].ToString());
                                    oCampo.BS_DIAMETRO_RAMA_2 = Decimal.Parse(dr["BS_DIAMETRO_RAMA_2"].ToString());
                                    oCampo.BS_DIAMETRO_RAMA_3 = Decimal.Parse(dr["BS_DIAMETRO_RAMA_3"].ToString());
                                    oCampo.BS_DIAMETRO_RAMA_4 = Decimal.Parse(dr["BS_DIAMETRO_RAMA_4"].ToString());
                                    oCampo.BS_DIAMETRO_RAMA_5 = Decimal.Parse(dr["BS_DIAMETRO_RAMA_5"].ToString());
                                    oCampo.BS_DIAMETRO_RAMA_6 = Decimal.Parse(dr["BS_DIAMETRO_RAMA_6"].ToString());
                                    oCampo.BS_DIAMETRO_RAMA_7 = Decimal.Parse(dr["BS_DIAMETRO_RAMA_7"].ToString());
                                    oCampo.BS_LONGITUD_RAMA_1 = Decimal.Parse(dr["BS_LONGITUD_RAMA_1"].ToString());
                                    oCampo.BS_LONGITUD_RAMA_2 = Decimal.Parse(dr["BS_LONGITUD_RAMA_2"].ToString());
                                    oCampo.BS_LONGITUD_RAMA_3 = Decimal.Parse(dr["BS_LONGITUD_RAMA_3"].ToString());
                                    oCampo.BS_LONGITUD_RAMA_4 = Decimal.Parse(dr["BS_LONGITUD_RAMA_4"].ToString());
                                    oCampo.BS_LONGITUD_RAMA_5 = Decimal.Parse(dr["BS_LONGITUD_RAMA_5"].ToString());
                                    oCampo.BS_LONGITUD_RAMA_6 = Decimal.Parse(dr["BS_LONGITUD_RAMA_6"].ToString());
                                    oCampo.BS_LONGITUD_RAMA_7 = Decimal.Parse(dr["BS_LONGITUD_RAMA_7"].ToString());
                                    oCampo.OBSERVACION = dr["OBSERVACION"].ToString();
                                    oCampo.RegEstado = 0;
                                    lsCEntidad.Add(oCampo);
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
        public String RegInsertarMuestraDatosCampoBosqueSeco(OracleConnection cn, CapaEntidad.DOC.Ent_INFORME_BOSQUE_SECO oCEntidad)
        {
            OracleTransaction tr = null;
            try
            {
                //Set datos enviar
                CEntidad oParams = new CEntidad();
                oParams.COD_INFORME = oCEntidad.COD_INFORME;
                oParams.COD_THABILITANTE = oCEntidad.COD_THABILITANTE;
                oParams.NUM_POA = oCEntidad.NUM_POA;
                oParams.COD_ESPECIES = oCEntidad.COD_ESPECIES;
                oParams.COD_SECUENCIAL = oCEntidad.COD_SECUENCIAL;
                oParams.COD_ESPECIES_CAMPO = oCEntidad.COD_ESPECIES_CAMPO == "" ? null : oCEntidad.COD_ESPECIES_CAMPO;
                oParams.BLOQUE = oCEntidad.BLOQUE_CAMPO ?? "";
                oParams.FAJA = oCEntidad.FAJA_CAMPO ?? "";
                oParams.CODIGO = oCEntidad.CODIGO_CAMPO ?? "";
                oParams.DAP = oCEntidad.DAP_CAMPO == -1 ? 0 : oCEntidad.DAP_CAMPO;
                oParams.AC = oCEntidad.AC_CAMPO == -1 ? 0 : oCEntidad.AC_CAMPO;
                oParams.ZONA = oCEntidad.ZONA_CAMPO;
                oParams.COORDENADA_ESTE = oCEntidad.COORDENADA_ESTE_CAMPO == -1 ? 0 : oCEntidad.COORDENADA_ESTE_CAMPO;
                oParams.COORDENADA_NORTE = oCEntidad.COORDENADA_NORTE_CAMPO == -1 ? 0 : oCEntidad.COORDENADA_NORTE_CAMPO;
                oParams.COD_EESTADO = oCEntidad.COD_EESTADO == "" ? null : oCEntidad.COD_EESTADO;
                oParams.BS_ALTURA_TOTAL = oCEntidad.BS_ALTURA_TOTAL == -1 ? 0 : oCEntidad.BS_ALTURA_TOTAL;
                oParams.BS_DIAMETRO_RAMA_1 = oCEntidad.BS_DIAMETRO_RAMA_1 == -1 ? 0 : oCEntidad.BS_DIAMETRO_RAMA_1;
                oParams.BS_DIAMETRO_RAMA_2 = oCEntidad.BS_DIAMETRO_RAMA_2 == -1 ? 0 : oCEntidad.BS_DIAMETRO_RAMA_2;
                oParams.BS_DIAMETRO_RAMA_3 = oCEntidad.BS_DIAMETRO_RAMA_3 == -1 ? 0 : oCEntidad.BS_DIAMETRO_RAMA_3;
                oParams.BS_DIAMETRO_RAMA_4 = oCEntidad.BS_DIAMETRO_RAMA_4 == -1 ? 0 : oCEntidad.BS_DIAMETRO_RAMA_4;
                oParams.BS_DIAMETRO_RAMA_5 = oCEntidad.BS_DIAMETRO_RAMA_5 == -1 ? 0 : oCEntidad.BS_DIAMETRO_RAMA_5;
                oParams.BS_DIAMETRO_RAMA_6 = oCEntidad.BS_DIAMETRO_RAMA_6 == -1 ? 0 : oCEntidad.BS_DIAMETRO_RAMA_6;
                oParams.BS_DIAMETRO_RAMA_7 = oCEntidad.BS_DIAMETRO_RAMA_7 == -1 ? 0 : oCEntidad.BS_DIAMETRO_RAMA_7;
                oParams.BS_LONGITUD_RAMA_1 = oCEntidad.BS_LONGITUD_RAMA_1 == -1 ? 0 : oCEntidad.BS_LONGITUD_RAMA_1;
                oParams.BS_LONGITUD_RAMA_2 = oCEntidad.BS_LONGITUD_RAMA_2 == -1 ? 0 : oCEntidad.BS_LONGITUD_RAMA_2;
                oParams.BS_LONGITUD_RAMA_3 = oCEntidad.BS_LONGITUD_RAMA_3 == -1 ? 0 : oCEntidad.BS_LONGITUD_RAMA_3;
                oParams.BS_LONGITUD_RAMA_4 = oCEntidad.BS_LONGITUD_RAMA_4 == -1 ? 0 : oCEntidad.BS_LONGITUD_RAMA_4;
                oParams.BS_LONGITUD_RAMA_5 = oCEntidad.BS_LONGITUD_RAMA_5 == -1 ? 0 : oCEntidad.BS_LONGITUD_RAMA_5;
                oParams.BS_LONGITUD_RAMA_6 = oCEntidad.BS_LONGITUD_RAMA_6 == -1 ? 0 : oCEntidad.BS_LONGITUD_RAMA_6;
                oParams.BS_LONGITUD_RAMA_7 = oCEntidad.BS_LONGITUD_RAMA_7 == -1 ? 0 : oCEntidad.BS_LONGITUD_RAMA_7;
                oParams.OBSERVACION = oCEntidad.OBSERVACION ?? "";
                oParams.RegEstado = oCEntidad.RegEstado;

                tr = cn.BeginTransaction();
                dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.ISUPERVISION_DET_EMADERABLE_Grabar", oParams);
                tr.Commit();
                return "Ok";
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

        public List<CapaEntidad.DOC.Ent_INFORME_SEMILLERO> RegMostrarMuestraDatosCampoSemi(string asCodInforme)
        {
            List<CapaEntidad.DOC.Ent_INFORME_SEMILLERO> lsCEntidad = new List<CapaEntidad.DOC.Ent_INFORME_SEMILLERO>();
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spGETLIST_MUESTRA_DATOSCAMPO_INFORME", new CEntidad() { TIPO = "SEMILLERO", COD_INFORME = asCodInforme }))
                    {
                        if (dr != null)
                        {
                            if (dr.HasRows)
                            {
                                CapaEntidad.DOC.Ent_INFORME_SEMILLERO oCampo;

                                while (dr.Read())
                                {
                                    oCampo = new CapaEntidad.DOC.Ent_INFORME_SEMILLERO();
                                    oCampo.COD_SECUENCIAL = Int32.Parse(dr["COD_SECUENCIAL"].ToString());
                                    oCampo.COD_THABILITANTE = dr["COD_THABILITANTE"].ToString();
                                    oCampo.NUM_POA = Int32.Parse(dr["NUM_POA"].ToString());
                                    oCampo.POA = dr["POA"].ToString();
                                    oCampo.COD_ESPECIES = dr["COD_ESPECIES"].ToString();
                                    oCampo.DESC_ESPECIES = dr["DESC_ESPECIES"].ToString();
                                    oCampo.COD_ESPECIES_CAMPO = dr["COD_ESPECIES_CAMPO"].ToString();
                                    oCampo.DESC_ESPECIES_CAMPO = dr["DESC_ESPECIES_2"].ToString();
                                    oCampo.BLOQUE = dr["BLOQUE"].ToString();
                                    oCampo.BLOQUE_CAMPO = dr["BLOQUE_2"].ToString();
                                    oCampo.FAJA = dr["FAJA"].ToString();
                                    oCampo.FAJA_CAMPO = dr["FAJA_2"].ToString();
                                    oCampo.CODIGO = dr["CODIGO"].ToString();
                                    oCampo.CODIGO_CAMPO = dr["CODIGO_2"].ToString();
                                    oCampo.COINCIDE_ESPECIES = dr["COINCIDE_ESPECIES"].ToString();
                                    oCampo.DESC_COINCIDE_ESPECIES = oCampo.COINCIDE_ESPECIES == "NN" ? "Ninguno" : (oCampo.COINCIDE_ESPECIES == "-" ? "" : oCampo.COINCIDE_ESPECIES);
                                    oCampo.ZONA = dr["ZONA"].ToString();
                                    oCampo.ZONA_CAMPO = dr["ZONA_2"].ToString();
                                    oCampo.COORDENADA_ESTE = Int32.Parse(dr["COORDENADA_ESTE"].ToString());
                                    oCampo.COORDENADA_ESTE_CAMPO = Int32.Parse(dr["COORDENADA_ESTE_2"].ToString());
                                    oCampo.COORDENADA_NORTE = Int32.Parse(dr["COORDENADA_NORTE"].ToString());
                                    oCampo.COORDENADA_NORTE_CAMPO = Int32.Parse(dr["COORDENADA_NORTE_2"].ToString());
                                    oCampo.DAP = Decimal.Parse(dr["DAP"].ToString());
                                    oCampo.DAP_CAMPO = Decimal.Parse(dr["DAP_CAMPO"].ToString());
                                    oCampo.DAP_CAMPO1 = Decimal.Parse(dr["DAP_CAMPO1"].ToString());
                                    oCampo.DAP_CAMPO2 = Decimal.Parse(dr["DAP_CAMPO2"].ToString());
                                    oCampo.MAE_TIP_MMEDIRDAP = dr["MAE_TIP_MMEDIRDAP"].ToString();
                                    oCampo.MMEDIR_DAP = dr["MMEDIR_DAP"].ToString();
                                    oCampo.AC = Decimal.Parse(dr["AC"].ToString());
                                    oCampo.AC_CAMPO = Decimal.Parse(dr["AC_2"].ToString());
                                    oCampo.DESC_EESTADO = dr["DESC_EESTADO"].ToString();
                                    oCampo.COD_EESTADO = dr["COD_EESTADO"].ToString();
                                    oCampo.DESC_EESTADO_CAMPO = dr["DESC_EESTADO_2"].ToString();
                                    oCampo.COD_EFENOLOGICO = dr["COD_EFENOLOGICO"].ToString();
                                    oCampo.DESC_EFENOLOGICO = dr["DESC_EFENOLOGICO"].ToString();
                                    oCampo.COD_CFUSTE = dr["COD_CFUSTE"].ToString();
                                    oCampo.DESC_CFUSTE = dr["DESC_CFUSTE"].ToString();
                                    oCampo.COD_FCOPA = dr["COD_FCOPA"].ToString();
                                    oCampo.DESC_FCOPA = dr["DESC_FCOPA"].ToString();
                                    oCampo.COD_PCOPA = dr["COD_PCOPA"].ToString();
                                    oCampo.DESC_PCOPA = dr["DESC_PCOPA"].ToString();
                                    oCampo.COD_ESANITARIO = dr["COD_ESANITARIO"].ToString();
                                    oCampo.DESC_ESANITARIO = dr["DESC_ESANITARIO"].ToString();
                                    oCampo.COD_ILIANAS = dr["COD_ILIANAS"].ToString();
                                    oCampo.DESC_ILIANAS = dr["DESC_ILIANAS"].ToString();
                                    oCampo.CANT_SOBRE_ESTIMA_DIAMETRO = Int32.Parse(dr["CANT_SOBRE_ESTIMA_DIAMETRO"].ToString());
                                    oCampo.PORC_SOBRE_ESTIMA_DIAMETRO = Decimal.Parse(dr["PORC_SOBRE_ESTIMA_DIAMETRO"].ToString());
                                    oCampo.CANT_SUB_ESTIMA_DIAMETRO = Int32.Parse(dr["CANT_SUB_ESTIMA_DIAMETRO"].ToString());
                                    oCampo.PORC_SUB_ESTIMA_DIAMETRO = Decimal.Parse(dr["PORC_SUB_ESTIMA_DIAMETRO"].ToString());
                                    oCampo.OBSERVACION = dr["OBSERVACION"].ToString();
                                    oCampo.PCA = dr["PCA"].ToString();
                                    oCampo.PCA_POA = dr["PCA_POA"].ToString();
                                    oCampo.RegEstado = 0;
                                    lsCEntidad.Add(oCampo);
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
        public String RegInsertarMuestraDatosCampoSemi(OracleConnection cn, CapaEntidad.DOC.Ent_INFORME_SEMILLERO oCEntidad)
        {
            OracleTransaction tr = null;
            try
            {
                //Set datos enviar
                CEntidad oParams = new CEntidad();
                oParams.COD_INFORME = oCEntidad.COD_INFORME;
                oParams.COD_THABILITANTE = oCEntidad.COD_THABILITANTE;
                oParams.NUM_POA = oCEntidad.NUM_POA;
                oParams.COD_ESPECIES = oCEntidad.COD_ESPECIES;
                oParams.COD_SECUENCIAL = oCEntidad.COD_SECUENCIAL;
                oParams.COD_ESPECIES_CAMPO = oCEntidad.COD_ESPECIES_CAMPO == "" ? null : oCEntidad.COD_ESPECIES_CAMPO;
                oParams.BLOQUE = oCEntidad.BLOQUE_CAMPO ?? "";
                oParams.FAJA = oCEntidad.FAJA_CAMPO ?? "";
                oParams.CODIGO = oCEntidad.CODIGO_CAMPO ?? "";
                oParams.DAP = oCEntidad.DAP_CAMPO == -1 ? 0 : oCEntidad.DAP_CAMPO;
                oParams.AC = oCEntidad.AC_CAMPO == -1 ? 0 : oCEntidad.AC_CAMPO;
                oParams.ZONA = oCEntidad.ZONA_CAMPO;
                oParams.COORDENADA_ESTE = oCEntidad.COORDENADA_ESTE_CAMPO == -1 ? 0 : oCEntidad.COORDENADA_ESTE_CAMPO;
                oParams.COORDENADA_NORTE = oCEntidad.COORDENADA_NORTE_CAMPO == -1 ? 0 : oCEntidad.COORDENADA_NORTE_CAMPO;
                oParams.COD_EESTADO = oCEntidad.COD_EESTADO == "" ? null : oCEntidad.COD_EESTADO;
                oParams.OBSERVACION = oCEntidad.OBSERVACION ?? "";
                oParams.DAP2 = oCEntidad.DAP_CAMPO2 == -1 ? 0 : oCEntidad.DAP_CAMPO2;
                oParams.DAP1 = oCEntidad.DAP_CAMPO1 == -1 ? 0 : oCEntidad.DAP_CAMPO1;
                oParams.COINCIDE_ESPECIES = oCEntidad.COINCIDE_ESPECIES;
                oParams.MAE_TIP_MMEDIRDAP = oCEntidad.MAE_TIP_MMEDIRDAP == "0000000" || oCEntidad.MAE_TIP_MMEDIRDAP == "" ? null : oCEntidad.MAE_TIP_MMEDIRDAP;
                oParams.MMEDIR_DAP = oCEntidad.MMEDIR_DAP;
                oParams.COD_CFUSTE = oCEntidad.COD_CFUSTE == "" ? null : oCEntidad.COD_CFUSTE;
                oParams.COD_FCOPA = oCEntidad.COD_FCOPA == "" ? null : oCEntidad.COD_FCOPA;
                oParams.COD_PCOPA = oCEntidad.COD_PCOPA == "" ? null : oCEntidad.COD_PCOPA;
                oParams.COD_EFENOLOGICO = oCEntidad.COD_EFENOLOGICO == "" ? null : oCEntidad.COD_EFENOLOGICO;
                oParams.COD_ESANITARIO = oCEntidad.COD_ESANITARIO == "" ? null : oCEntidad.COD_ESANITARIO;
                oParams.COD_ILIANAS = oCEntidad.COD_ILIANAS == "" ? null : oCEntidad.COD_ILIANAS;
                oParams.CANT_SOBRE_ESTIMA_DIAMETRO = oCEntidad.CANT_SOBRE_ESTIMA_DIAMETRO;
                oParams.PORC_SOBRE_ESTIMA_DIAMETRO = oCEntidad.PORC_SOBRE_ESTIMA_DIAMETRO;
                oParams.CANT_SUB_ESTIMA_DIAMETRO = oCEntidad.CANT_SUB_ESTIMA_DIAMETRO;
                oParams.PORC_SUB_ESTIMA_DIAMETRO = oCEntidad.PORC_SUB_ESTIMA_DIAMETRO;
                oParams.RegEstado = oCEntidad.RegEstado;
                oParams.PCA = oCEntidad.PCA;
                tr = cn.BeginTransaction();
                dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.ISUPERVISION_DET_EMADERABLE_Grabar", oParams);
                tr.Commit();
                return "Ok";
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

        public List<CapaEntidad.DOC.Ent_INFORME_NO_MADERABLE> RegMostrarMuestraDatosCampoNoMade(string asCodInforme)
        {
            List<CapaEntidad.DOC.Ent_INFORME_NO_MADERABLE> lsCEntidad = new List<CapaEntidad.DOC.Ent_INFORME_NO_MADERABLE>();
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spGETLIST_MUESTRA_DATOSCAMPO_INFORME", new CEntidad() { TIPO = "NO_MADERABLE", COD_INFORME = asCodInforme }))
                    {
                        if (dr != null)
                        {
                            if (dr.HasRows)
                            {
                                CapaEntidad.DOC.Ent_INFORME_NO_MADERABLE oCampo;

                                while (dr.Read())
                                {
                                    oCampo = new CapaEntidad.DOC.Ent_INFORME_NO_MADERABLE();
                                    oCampo.COD_SECUENCIAL = Int32.Parse(dr["COD_SECUENCIAL"].ToString());
                                    oCampo.COD_THABILITANTE = dr["COD_THABILITANTE"].ToString();
                                    oCampo.NUM_POA = Int32.Parse(dr["NUM_POA"].ToString());
                                    oCampo.POA = dr["POA"].ToString();
                                    oCampo.COD_ESPECIES = dr["COD_ESPECIES"].ToString();
                                    oCampo.DESC_ESPECIES = dr["DESC_ESPECIES"].ToString();
                                    oCampo.COD_ESPECIES_CAMPO = dr["COD_ESPECIES_CAMPO"].ToString();
                                    oCampo.DESC_ESPECIES_CAMPO = dr["DESC_ESPECIES_2"].ToString();
                                    oCampo.NUM_ESTRADA = dr["NUM_ESTRADA"].ToString();
                                    oCampo.NUM_ESTRADA_CAMPO = dr["NUM_ESTRADA_2"].ToString();
                                    oCampo.CODIGO = dr["CODIGO"].ToString();
                                    oCampo.CODIGO_CAMPO = dr["CODIGO_2"].ToString();
                                    oCampo.DIAMETRO = Decimal.Parse(dr["DIAMETRO"].ToString());
                                    oCampo.DIAMETRO_CAMPO = Decimal.Parse(dr["DIAMETRO_2"].ToString());
                                    oCampo.ALTURA = Decimal.Parse(dr["ALTURA"].ToString());
                                    oCampo.ALTURA_CAMPO = Decimal.Parse(dr["ALTURA_2"].ToString());
                                    oCampo.PRODUCCION_LATAS = Decimal.Parse(dr["PRODUCCION_LATAS"].ToString());
                                    oCampo.PRODUCCION_LATAS_CAMPO = Decimal.Parse(dr["PRODUCCION_LATAS_2"].ToString());
                                    oCampo.ZONA = dr["ZONA"].ToString();
                                    oCampo.ZONA_CAMPO = dr["ZONA_2"].ToString();
                                    oCampo.COORDENADA_ESTE = Int32.Parse(dr["COORDENADA_ESTE"].ToString());
                                    oCampo.COORDENADA_ESTE_CAMPO = Int32.Parse(dr["COORDENADA_ESTE_2"].ToString());
                                    oCampo.COORDENADA_NORTE = Int32.Parse(dr["COORDENADA_NORTE"].ToString());
                                    oCampo.COORDENADA_NORTE_CAMPO = Int32.Parse(dr["COORDENADA_NORTE_2"].ToString());
                                    oCampo.COD_EESTADO = dr["COD_EESTADO"].ToString();
                                    oCampo.DESC_EESTADO_CAMPO = dr["DESC_EESTADO_2"].ToString();
                                    oCampo.NUM_COCOS_ABIERTOS = Int32.Parse(dr["NUM_COCOS_ABIERTOS"].ToString());
                                    oCampo.NUM_COCOS_CERRADOS = Int32.Parse(dr["NUM_COCOS_CERRADOS"].ToString());
                                    oCampo.COD_CFUSTE = dr["COD_CFUSTE"].ToString();
                                    oCampo.DESC_CFUSTE = dr["DESC_CFUSTE"].ToString();
                                    oCampo.COD_PCOPA = dr["COD_PCOPA"].ToString();
                                    oCampo.DESC_PCOPA = dr["DESC_PCOPA"].ToString();
                                    oCampo.COD_FCOPA = dr["COD_FCOPA"].ToString();
                                    oCampo.DESC_FCOPA = dr["DESC_FCOPA"].ToString();
                                    oCampo.COD_EFENOLOGICO = dr["COD_EFENOLOGICO"].ToString();
                                    oCampo.DESC_EFENOLOGICO = dr["DESC_EFENOLOGICO"].ToString();
                                    oCampo.COD_ESANITARIO = dr["COD_ESANITARIO"].ToString();
                                    oCampo.DESC_ESANITARIO = dr["DESC_ESANITARIO"].ToString();
                                    oCampo.COD_ILIANAS = dr["COD_ILIANAS"].ToString();
                                    oCampo.DESC_ILIANAS = dr["DESC_ILIANAS"].ToString();
                                    oCampo.COD_ECONDICION = dr["COD_ECONDICION"].ToString();
                                    oCampo.DESC_ECONDICION = dr["DESC_ECONDICION"].ToString();
                                    oCampo.COD_ECONDICION_CAMPO = dr["COD_ECONDICION_CAMPO"].ToString();
                                    oCampo.DESC_ECONDICION_CAMPO = dr["DESC_ECONDICION_CAMPO"].ToString();
                                    oCampo.OBSERVACION = dr["OBSERVACION"].ToString();
                                    oCampo.RegEstado = 0;
                                    lsCEntidad.Add(oCampo);
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
        public String RegInsertarMuestraDatosCampoNoMade(OracleConnection cn, CapaEntidad.DOC.Ent_INFORME_NO_MADERABLE oCEntidad)
        {
            OracleTransaction tr = null;
            try
            {
                //Set datos enviar
                CEntidad oParams = new CEntidad();
                oParams.COD_INFORME = oCEntidad.COD_INFORME;
                oParams.COD_THABILITANTE = oCEntidad.COD_THABILITANTE;
                oParams.NUM_POA = oCEntidad.NUM_POA;
                oParams.COD_ESPECIES = oCEntidad.COD_ESPECIES;
                oParams.COD_SECUENCIAL = oCEntidad.COD_SECUENCIAL;
                oParams.COD_ESPECIES_CAMPO = oCEntidad.COD_ESPECIES_CAMPO == "" ? null : oCEntidad.COD_ESPECIES_CAMPO;
                oParams.NUM_ESTRADA = oCEntidad.NUM_ESTRADA_CAMPO == null ? "" : oCEntidad.NUM_ESTRADA_CAMPO;
                oParams.CODIGO = oCEntidad.CODIGO_CAMPO ?? "";
                oParams.DIAMETRO = oCEntidad.DIAMETRO_CAMPO == -1 ? 0 : oCEntidad.DIAMETRO_CAMPO;
                oParams.ALTURA = oCEntidad.ALTURA_CAMPO == -1 ? 0 : oCEntidad.ALTURA_CAMPO;
                oParams.PRODUCCION_LATAS = oCEntidad.PRODUCCION_LATAS_CAMPO == -1 ? 0 : oCEntidad.PRODUCCION_LATAS_CAMPO;
                oParams.ZONA = oCEntidad.ZONA_CAMPO;
                oParams.COORDENADA_ESTE = oCEntidad.COORDENADA_ESTE_CAMPO == -1 ? 0 : oCEntidad.COORDENADA_ESTE_CAMPO;
                oParams.COORDENADA_NORTE = oCEntidad.COORDENADA_NORTE_CAMPO == -1 ? 0 : oCEntidad.COORDENADA_NORTE_CAMPO;
                oParams.COD_EESTADO = oCEntidad.COD_EESTADO == "" ? null : oCEntidad.COD_EESTADO;
                oParams.NUM_COCOS_ABIERTOS = oCEntidad.NUM_COCOS_ABIERTOS == -1 ? 0 : oCEntidad.NUM_COCOS_ABIERTOS;
                oParams.NUM_COCOS_CERRADOS = oCEntidad.NUM_COCOS_CERRADOS == -1 ? 0 : oCEntidad.NUM_COCOS_CERRADOS;
                oParams.OBSERVACION = oCEntidad.OBSERVACION ?? "";
                oParams.COD_CFUSTE = oCEntidad.COD_CFUSTE == "" ? null : oCEntidad.COD_CFUSTE;
                oParams.COD_FCOPA = oCEntidad.COD_FCOPA == "" ? null : oCEntidad.COD_FCOPA;
                oParams.COD_PCOPA = oCEntidad.COD_PCOPA == "" ? null : oCEntidad.COD_PCOPA;
                oParams.COD_EFENOLOGICO = oCEntidad.COD_EFENOLOGICO == "" ? null : oCEntidad.COD_EFENOLOGICO;
                oParams.COD_ESANITARIO = oCEntidad.COD_ESANITARIO == "" ? null : oCEntidad.COD_ESANITARIO;
                oParams.COD_ILIANAS = oCEntidad.COD_ILIANAS == "" ? null : oCEntidad.COD_ILIANAS;
                oParams.COD_ECONDICION_CAMPO = oCEntidad.COD_ECONDICION_CAMPO == "" ? null : oCEntidad.COD_ECONDICION_CAMPO;
                oParams.RegEstado = oCEntidad.RegEstado;
                tr = cn.BeginTransaction();
                dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.ISUPERVISION_DET_ENOMADERABLE_Grabar", oParams);
                tr.Commit();
                return "Ok";
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

        public List<CapaEntidad.DOC.Ent_INFORME_TROZA_CAMPO> RegMostrarDatosTrozaCampo(string asCodInforme, Int32 aiNumPoa)
        {
            List<CapaEntidad.DOC.Ent_INFORME_TROZA_CAMPO> lsCEntidad = new List<CapaEntidad.DOC.Ent_INFORME_TROZA_CAMPO>();
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spGETLIST_MUESTRA_DATOSCAMPO_INFORME", new CEntidad() { TIPO = "TROZA_CAMPO", COD_INFORME = asCodInforme, NUM_POA = aiNumPoa }))
                    {
                        if (dr != null)
                        {
                            if (dr.HasRows)
                            {
                                CapaEntidad.DOC.Ent_INFORME_TROZA_CAMPO oCampo;

                                while (dr.Read())
                                {
                                    oCampo = new CapaEntidad.DOC.Ent_INFORME_TROZA_CAMPO();
                                    oCampo.COD_THABILITANTE = dr["COD_THABILITANTE"].ToString();
                                    oCampo.NUM_POA = Int32.Parse(dr["NUM_POA"].ToString());
                                    oCampo.COD_SECUENCIAL = Int32.Parse(dr["COD_SECUENCIAL"].ToString());
                                    oCampo.COD_ESPECIES = dr["COD_ESPECIES"].ToString();
                                    oCampo.ESPECIES = dr["ESPECIES"].ToString();
                                    oCampo.ZONA = dr["ZONA"].ToString();
                                    oCampo.COORDENADA_ESTE = Int32.Parse(dr["COORDENADA_ESTE"].ToString());
                                    oCampo.COORDENADA_NORTE = Int32.Parse(dr["COORDENADA_NORTE"].ToString());
                                    oCampo.DAP1 = Decimal.Parse(dr["DAP1"].ToString());
                                    oCampo.DAP2 = Decimal.Parse(dr["DAP2"].ToString());
                                    oCampo.LC = Decimal.Parse(dr["LC"].ToString());
                                    oCampo.OBSERVACION = dr["OBSERVACION"].ToString();
                                    oCampo.CODIGO = dr["CODIGO"].ToString();
                                    oCampo.RegEstado = 1;
                                  
                                    var itemExiste = lsCEntidad.Where(x => x.COD_ESPECIES == oCampo.COD_ESPECIES).FirstOrDefault();
                                    if (itemExiste != null)
                                    {
                                        itemExiste.DAP1 = itemExiste.DAP1 + oCampo.DAP1;
                                        itemExiste.DAP2 = itemExiste.DAP2 + oCampo.DAP2;
                                        itemExiste.LC = itemExiste.LC + oCampo.LC;
                                        itemExiste.RegEstado = itemExiste.RegEstado + oCampo.RegEstado;
                                    }
                                    else
                                    {
                                        lsCEntidad.Add(oCampo);
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
        public string RegInsertarDatosTrozaCampo(OracleConnection cn, List<CapaEntidad.DOC.Ent_INFORME_TROZA_CAMPO> olCEntidad, string asCodUCuenta)
        {
            OracleTransaction tr = null;

            try
            {
                tr = cn.BeginTransaction();
                if (olCEntidad != null)
                {
                    CEntidad ocampo;

                    foreach (var loDatos in olCEntidad)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            ocampo = new CEntidad();
                            ocampo.COD_INFORME = loDatos.COD_INFORME;
                            ocampo.NUM_POA = loDatos.NUM_POA;
                            ocampo.COD_ESPECIES = loDatos.COD_ESPECIES;
                            ocampo.ESPECIES = loDatos.ESPECIES;
                            ocampo.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            ocampo.CODIGO = loDatos.CODIGO;
                            ocampo.ZONA = loDatos.ZONA;
                            ocampo.COORDENADA_ESTE = loDatos.COORDENADA_ESTE;
                            ocampo.COORDENADA_NORTE = loDatos.COORDENADA_NORTE;
                            ocampo.DAP1 = loDatos.DAP1;
                            ocampo.DAP2 = loDatos.DAP2;
                            ocampo.LC = loDatos.LC;
                            ocampo.OBSERVACION = loDatos.OBSERVACION;
                            ocampo.COD_UCUENTA = asCodUCuenta;
                            ocampo.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spISUPERVISION_DET_ETROZA_Grabar", ocampo);
                        }
                    }
                }
                tr.Commit();
                return "Ok";
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

        public List<CapaEntidad.DOC.Ent_INFORME_MADERA_ASERRADA> RegMostrarDatosMaderaAserrada(string asCodInforme, Int32 aiNumPoa)
        {
            List<CapaEntidad.DOC.Ent_INFORME_MADERA_ASERRADA> lsCEntidad = new List<CapaEntidad.DOC.Ent_INFORME_MADERA_ASERRADA>();
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spGETLIST_MUESTRA_DATOSCAMPO_INFORME", new CEntidad() { TIPO = "MADERA_ASERRADA", COD_INFORME = asCodInforme, NUM_POA = aiNumPoa }))
                    {
                        if (dr != null)
                        {
                            if (dr.HasRows)
                            {
                                CapaEntidad.DOC.Ent_INFORME_MADERA_ASERRADA oCampo;

                                while (dr.Read())
                                {
                                    oCampo = new CapaEntidad.DOC.Ent_INFORME_MADERA_ASERRADA();
                                    oCampo.COD_THABILITANTE = dr["COD_THABILITANTE"].ToString();
                                    oCampo.NUM_POA = Int32.Parse(dr["NUM_POA"].ToString());
                                    oCampo.COD_SECUENCIAL = Int32.Parse(dr["COD_SECUENCIAL"].ToString());
                                    oCampo.CODIGO = dr["CODIGO"].ToString();
                                    oCampo.COD_ESPECIES = dr["COD_ESPECIES"].ToString();
                                    oCampo.ESPECIES = dr["ESPECIES"].ToString();
                                    oCampo.PIEZAS = Int32.Parse(dr["PIEZAS"].ToString());
                                    oCampo.ZONA = dr["ZONA"].ToString();
                                    oCampo.COORDENADA_ESTE = Int32.Parse(dr["COORDENADA_ESTE"].ToString());
                                    oCampo.COORDENADA_NORTE = Int32.Parse(dr["COORDENADA_NORTE"].ToString());
                                    oCampo.ESPESOR = Decimal.Parse(dr["ESPESOR"].ToString());
                                    oCampo.ANCHO = Decimal.Parse(dr["ANCHO"].ToString());
                                    oCampo.LARGO = Decimal.Parse(dr["LARGO"].ToString());
                                    oCampo.OBSERVACION = dr["OBSERVACION"].ToString();
                                    oCampo.RegEstado = 0;
                                    var itemExiste = lsCEntidad.Where(x => x.COD_ESPECIES == oCampo.COD_ESPECIES).FirstOrDefault();
                                    if (itemExiste != null)
                                    {
                                        itemExiste.ESPESOR = itemExiste.ESPESOR + oCampo.ESPESOR;
                                        itemExiste.ANCHO = itemExiste.ANCHO + oCampo.ANCHO;
                                        itemExiste.LARGO = itemExiste.LARGO + oCampo.LARGO;
                                        itemExiste.PIEZAS = itemExiste.PIEZAS + oCampo.PIEZAS;
                                    }
                                    else
                                    {
                                        lsCEntidad.Add(oCampo);
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
        public string RegInsertarDatosMaderaAserrada(OracleConnection cn, List<CapaEntidad.DOC.Ent_INFORME_MADERA_ASERRADA> olCEntidad, string asCodUCuenta)
        {
            OracleTransaction tr = null;

            try
            {
                tr = cn.BeginTransaction();
                if (olCEntidad != null)
                {
                    CEntidad ocampo;

                    foreach (var loDatos in olCEntidad)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            ocampo = new CEntidad();
                            ocampo.COD_INFORME = loDatos.COD_INFORME;
                            ocampo.COD_THABILITANTE = loDatos.COD_THABILITANTE;
                            ocampo.NUM_POA = loDatos.NUM_POA;
                            ocampo.COD_ESPECIES = loDatos.COD_ESPECIES;
                            ocampo.ESPECIES = loDatos.ESPECIES;
                            ocampo.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            ocampo.CODIGO = loDatos.CODIGO;
                            ocampo.PIEZAS = loDatos.PIEZAS;
                            ocampo.ZONA = loDatos.ZONA;
                            ocampo.COORDENADA_ESTE = loDatos.COORDENADA_ESTE;
                            ocampo.COORDENADA_NORTE = loDatos.COORDENADA_NORTE;
                            ocampo.ESPESOR = loDatos.ESPESOR;
                            ocampo.ANCHO = loDatos.ANCHO;
                            ocampo.LARGO = loDatos.LARGO;
                            ocampo.OBSERVACION = loDatos.OBSERVACION;
                            ocampo.COD_UCUENTA = asCodUCuenta;
                            ocampo.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spISUPERVISION_DET_EASERRADA_Grabar", ocampo);
                        }
                    }
                }
                tr.Commit();
                return "Ok";
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

        public List<CapaEntidad.DOC.Ent_INFORME_CARRIZO_CAMPO> RegMostrarDatosCarrizoCampo(string asCodInforme, Int32 aiNumPoa)
        {
            List<CapaEntidad.DOC.Ent_INFORME_CARRIZO_CAMPO> lsCEntidad = new List<CapaEntidad.DOC.Ent_INFORME_CARRIZO_CAMPO>();
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spGETLIST_MUESTRA_DATOSCAMPO_INFORME", new CEntidad() { TIPO = "CARRIZO_CAMPO", COD_INFORME = asCodInforme, NUM_POA = aiNumPoa }))
                    {
                        if (dr != null)
                        {
                            if (dr.HasRows)
                            {
                                CapaEntidad.DOC.Ent_INFORME_CARRIZO_CAMPO oCampo;

                                while (dr.Read())
                                {
                                    oCampo = new CapaEntidad.DOC.Ent_INFORME_CARRIZO_CAMPO();
                                    oCampo.COD_THABILITANTE = dr["COD_THABILITANTE"].ToString();
                                    oCampo.NUM_POA = Int32.Parse(dr["NUM_POA"].ToString());
                                    oCampo.COD_MUESTRA_SUPERVISION = Int32.Parse(dr["COD_MUESTRA_SUPERVISION"].ToString());
                                    oCampo.COD_ESPECIES = dr["COD_ESPECIES"].ToString();
                                    oCampo.ESPECIES = dr["ESPECIES"].ToString();
                                    oCampo.TOTAL_UNIDADES_APROV = Int32.Parse(dr["TOTAL_UNIDADES_APROV"].ToString());
                                    oCampo.TOTAL_UNIDAD_MUEST = Int32.Parse(dr["TOTAL_UNIDAD_MUEST"].ToString());
                                    oCampo.ZONA = dr["ZONA"].ToString();
                                    oCampo.ZONA = oCampo.ZONA == "000" ? "" : oCampo.ZONA;
                                    oCampo.COORDENADA_ESTE = Int32.Parse(dr["COORDENADA_ESTE"].ToString());
                                    oCampo.COORDENADA_NORTE = Int32.Parse(dr["COORDENADA_NORTE"].ToString());
                                    //oCampo.ALTURA_PROMEDIO = Decimal.Parse(dr["ALTURA_PROMEDIO"].ToString());
                                    //oCampo.UNIDAD_MEDIDA = dr["UNIDAD_MEDIDA"].ToString();
                                    //oCampo.NUM_INDIVIDUOS = Int32.Parse(dr["NUM_INDIVIDUOS"].ToString());
                                    oCampo.PRODUCTO_EXTRAER = dr["PRODUCTO_EXTRAER"].ToString();
                                    oCampo.OBSERVACION = dr["OBSERVACION"].ToString();
                                    oCampo.RegEstado = 0;
                                    lsCEntidad.Add(oCampo);
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
        public string RegInsertarDatosCarrizoCampo(OracleConnection cn, List<CapaEntidad.DOC.Ent_INFORME_CARRIZO_CAMPO> olCEntidad, string asCodUCuenta)
        {
            OracleTransaction tr = null;

            try
            {
                tr = cn.BeginTransaction();
                if (olCEntidad != null)
                {
                    CapaEntidad.DOC.Ent_INFORME_CARRIZO_CAMPO ocampo;

                    foreach (var loDatos in olCEntidad)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            ocampo = new CapaEntidad.DOC.Ent_INFORME_CARRIZO_CAMPO();
                            ocampo.COD_INFORME = loDatos.COD_INFORME;
                            //ocampo.COD_THABILITANTE = loDatos.COD_THABILITANTE;
                            ocampo.NUM_POA = loDatos.NUM_POA;
                            ocampo.COD_MUESTRA_SUPERVISION = loDatos.COD_MUESTRA_SUPERVISION;
                            ocampo.COD_ESPECIES = loDatos.COD_ESPECIES;
                            ocampo.ESPECIES = loDatos.ESPECIES;
                            ocampo.TOTAL_UNIDAD_MUEST = loDatos.TOTAL_UNIDAD_MUEST;
                            ocampo.TOTAL_UNIDADES_APROV = loDatos.TOTAL_UNIDADES_APROV;
                            ocampo.ZONA = loDatos.ZONA;
                            ocampo.COORDENADA_ESTE = loDatos.COORDENADA_ESTE;
                            ocampo.COORDENADA_NORTE = loDatos.COORDENADA_NORTE;
                            //ocampo.ALTURA_PROMEDIO = loDatos.ALTURA_PROMEDIO;
                            //ocampo.UNIDAD_MEDIDA = loDatos.UNIDAD_MEDIDA;
                            //ocampo.NUM_INDIVIDUOS = loDatos.NUM_INDIVIDUOS;
                            ocampo.PRODUCTO_EXTRAER = loDatos.PRODUCTO_EXTRAER;
                            ocampo.OBSERVACION = loDatos.OBSERVACION;
                            ocampo.COD_UCUENTA = asCodUCuenta;
                            ocampo.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spINFORME_MUESTRA_SUPERVISADA_Grabar", ocampo);
                        }
                    }
                }
                tr.Commit();
                return "Ok";
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

        public List<CapaEntidad.DOC.Ent_INFORME_VERTICE_VERIFICADO> RegMostrarDatosVerticeVerificado(string asCodInforme, Int32 aiNumPoa)
        {
            List<CapaEntidad.DOC.Ent_INFORME_VERTICE_VERIFICADO> lsCEntidad = new List<CapaEntidad.DOC.Ent_INFORME_VERTICE_VERIFICADO>();
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spGETLIST_MUESTRA_DATOSCAMPO_INFORME", new CEntidad() { TIPO = "VERTICE_VERIFICADO", COD_INFORME = asCodInforme, NUM_POA = aiNumPoa }))
                    {
                        if (dr != null)
                        {
                            if (dr.HasRows)
                            {
                                CapaEntidad.DOC.Ent_INFORME_VERTICE_VERIFICADO oCampo;

                                while (dr.Read())
                                {
                                    oCampo = new CapaEntidad.DOC.Ent_INFORME_VERTICE_VERIFICADO();
                                    oCampo.COD_THABILITANTE = dr["COD_THABILITANTE"].ToString();
                                    oCampo.NUM_POA = Int32.Parse(dr["NUM_POA"].ToString());
                                    oCampo.COD_INFORME_VERTICE = dr["COD_INFORME_VERTICE"].ToString();
                                    oCampo.VERTICE = dr["VERTICE"].ToString();
                                    oCampo.VERTICE_CAMPO = dr["VERTICE_CAMPO"].ToString();
                                    oCampo.ZONA = dr["ZONA"].ToString();
                                    oCampo.ZONA = oCampo.ZONA == "000" ? "" : oCampo.ZONA;
                                    oCampo.ZONA_CAMPO = dr["ZONA_CAMPO"].ToString();
                                    oCampo.ZONA_CAMPO = oCampo.ZONA_CAMPO == "000" ? "" : oCampo.ZONA_CAMPO;
                                    oCampo.COORDENADA_ESTE = Int32.Parse(dr["COORDENADA_ESTE"].ToString());
                                    oCampo.COORDENADA_ESTE_CAMPO = Int32.Parse(dr["COORDENADA_ESTE_CAMPO"].ToString());
                                    oCampo.COORDENADA_NORTE = Int32.Parse(dr["COORDENADA_NORTE"].ToString());
                                    oCampo.COORDENADA_NORTE_CAMPO = Int32.Parse(dr["COORDENADA_NORTE_CAMPO"].ToString());
                                    oCampo.OBSERVACION = dr["OBSERVACION"].ToString();
                                    oCampo.RegEstado = 0;
                                    lsCEntidad.Add(oCampo);
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
        public string RegInsertarDatosVerticeVerificado(OracleConnection cn, List<CapaEntidad.DOC.Ent_INFORME_VERTICE_VERIFICADO> olCEntidad, string asCodUCuenta)
        {
            OracleTransaction tr = null;

            try
            {
                tr = cn.BeginTransaction();
                if (olCEntidad != null)
                {
                    CapaEntidad.DOC.Ent_INFORME_VERTICE_VERIFICADO ocampo;

                    foreach (var loDatos in olCEntidad)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            ocampo = new CapaEntidad.DOC.Ent_INFORME_VERTICE_VERIFICADO
                            {
                                COD_INFORME = loDatos.COD_INFORME,
                                COD_THABILITANTE = loDatos.COD_THABILITANTE,
                                NUM_POA = loDatos.NUM_POA,
                                COD_INFORME_VERTICE = loDatos.COD_INFORME_VERTICE,
                                VERTICE = loDatos.VERTICE,
                                VERTICE_CAMPO = loDatos.VERTICE_CAMPO,
                                ZONA = loDatos.ZONA,
                                ZONA_CAMPO = loDatos.ZONA_CAMPO,
                                COORDENADA_ESTE = loDatos.COORDENADA_ESTE,
                                COORDENADA_ESTE_CAMPO = loDatos.COORDENADA_ESTE_CAMPO,
                                COORDENADA_NORTE = loDatos.COORDENADA_NORTE,
                                COORDENADA_NORTE_CAMPO = loDatos.COORDENADA_NORTE_CAMPO,
                                OBSERVACION = loDatos.OBSERVACION,
                                COD_UCUENTA = asCodUCuenta,
                                RegEstado = loDatos.RegEstado
                            };
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spINFORME_VERTICESGrabar", ocampo);
                        }
                    }
                }
                tr.Commit();
                return "Ok";
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

        public CEntidad RegIECOTURISMOMostrarListaItem_v3(OracleConnection cn, CEntidad oCEntidad)
        {
            CEntidad lsCEntidad = new CEntidad();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spINFORME_ECOTURISMOMostrarItem_v3", oCEntidad))
                {
                    if (dr != null)
                    {
                        lsCEntidad.ListInformeDetSupervisor = new List<CEntPersona>();
                        lsCEntidad.ListVertice = new List<CapaEntidad.DOC.Ent_INFORME_VERTICE>();
                        lsCEntidad.ListPrograma = new List<CapaEntidad.DOC.Ent_INFORME_PROGRAMA>();
                        lsCEntidad.ListISUPERVISION_INFRAESTRUCTURA = new List<CEntidad>();
                        lsCEntidad.ListISUPERVISION_DET_CAPACITACION_LOCAL = new List<CEntidad>();
                        lsCEntidad.ListISUPERVISION_IDENTMANEJOIMPACTO = new List<CEntidad>();
                        lsCEntidad.ListAvistamientoFauna = new List<CEntidad>();
                        lsCEntidad.ListRegistroFlora = new List<CapaEntidad.DOC.Ent_INFORME_REGFLORA>();
                        lsCEntidad.ListRegistroPaisaje = new List<CapaEntidad.DOC.Ent_INFORME_REGPAISAJE>();
                        lsCEntidad.ListISUPERVISION_DET_ZONIFICACION = new List<CEntidad>();
                        lsCEntidad.ListISUPERVISION_DET_EQUIPACONSECION = new List<CEntidad>();
                        lsCEntidad.ListISUPERVISION_OCARACTE_AMB01 = new List<CEntidad>();
                        lsCEntidad.ListObligacionTitular = new List<CapaEntidad.DOC.Ent_INFORME_OBLIGTITULAR>();
                        lsCEntidad.ListDesplazamientoInforme = new List<CEntidad>();
                        lsCEntidad.ListISDetConservActTuristica = new List<CEntidad>();
                        lsCEntidad.ListImpacto = new List<Ent_INFORME_IMPACTO>();
                        lsCEntidad.ListAfectacion = new List<Ent_INFORME_IMPACTO>();
                        lsCEntidad.ListISDetConservActIntAmbiental = new List<CEntidad>();
                        lsCEntidad.ListISDetConservActInvestigacion = new List<CEntidad>();
                        lsCEntidad.ListISDetConservActVisitas = new List<CEntidad>();
                        lsCEntidad.ListISDetConservActOtroPrograma = new List<CEntidad>();

                        CEntidad ocampoEnt;

                        #region "General"
                        if (dr.HasRows)
                        {
                            dr.Read();
                            lsCEntidad.COD_CNOTIFICACION = dr.GetString(dr.GetOrdinal("COD_CNOTIFICACION"));
                            lsCEntidad.NUMERO = dr.GetString(dr.GetOrdinal("NUMERO"));
                            lsCEntidad.FECHA_ENTREGA = dr.GetString(dr.GetOrdinal("FECHA_ENTREGA"));
                            lsCEntidad.COD_TIPO_SUPER = dr.GetString(dr.GetOrdinal("COD_TIPO_SUPER"));
                            lsCEntidad.UBIGEO = dr.GetString(dr.GetOrdinal("UBIGEO"));
                            lsCEntidad.THABILITANTE_SECTOR = dr.GetString(dr.GetOrdinal("THABILITANTE_SECTOR"));
                            lsCEntidad.THABILITANTE_COD_UBIGEO = dr.GetString(dr.GetOrdinal("THABILITANTE_COD_UBIGEO"));
                            lsCEntidad.FECHA_SUPERVISION_INICIO = dr.GetString(dr.GetOrdinal("FECHA_SUPERVISION_INICIO"));
                            lsCEntidad.FECHA_SUPERVISION_FIN = dr.GetString(dr.GetOrdinal("FECHA_SUPERVISION_FIN"));
                            lsCEntidad.COD_OD_REGISTRO = dr.GetString(dr.GetOrdinal("COD_OD_REGISTRO"));
                            lsCEntidad.COD_ESTADO_DOC = dr.GetString(dr.GetOrdinal("COD_ESTADO_DOC"));
                            lsCEntidad.OBSERVACIONES_CONTROL = dr.GetString(dr.GetOrdinal("OBSERVACIONES_CONTROL"));
                            lsCEntidad.OBSERV_SUBSANAR = dr.GetBoolean(dr.GetOrdinal("OBSERV_SUBSANAR"));
                            lsCEntidad.USUARIO_REGISTRO = dr.GetString(dr.GetOrdinal("USUARIO_REGISTRO"));
                            lsCEntidad.USUARIO_CONTROL = dr.GetString(dr.GetOrdinal("USUARIO_CONTROL"));
                            lsCEntidad.COD_TITULAR_EJECUTA = dr.GetString(dr.GetOrdinal("COD_TITULAR_EJECUTA"));
                            lsCEntidad.TITULAR_EJECUTA = dr.GetString(dr.GetOrdinal("TITULAR_EJECUTA"));
                            lsCEntidad.COD_REGENTE_IMPLEMENTA = dr.GetString(dr.GetOrdinal("COD_REGENTE_IMPLEMENTA"));
                            lsCEntidad.REGENTE_IMPLEMENTA = dr.GetString(dr.GetOrdinal("REGENTE_IMPLEMENTA"));
                            lsCEntidad.GEOTEC_DESCRIPCION = dr.GetString(dr.GetOrdinal("GEOTEC_DESCRIPCION"));
                            lsCEntidad.GEOTEC_DRON = dr.GetBoolean(dr.GetOrdinal("GEOTEC_DRON"));
                            lsCEntidad.GEOTEC_GEOSUPERVISOR = dr.GetBoolean(dr.GetOrdinal("GEOTEC_GEOSUPERVISOR"));
                            lsCEntidad.GEOTEC_NINGUNO = dr.GetBoolean(dr.GetOrdinal("GEOTEC_NINGUNO"));
                            lsCEntidad.GEOTEC_OTROS = dr.GetBoolean(dr.GetOrdinal("GEOTEC_OTROS"));
                            lsCEntidad.COD_IMOTIVO = dr.GetString(dr.GetOrdinal("COD_IMOTIVO"));
                            lsCEntidad.IMOTIVO = dr.GetString(dr.GetOrdinal("IMOTIVO"));
                            lsCEntidad.MAE_TIP_MOTMOTIVADA = dr.GetString(dr.GetOrdinal("MAE_TIP_MOTMOTIVADA"));
                            lsCEntidad.COD_TRAMITE_SITD = dr.GetInt32(dr.GetOrdinal("COD_TRAMITE_SITD"));
                            lsCEntidad.NUM_DREFERENCIA = dr.GetString(dr.GetOrdinal("NUM_DREFERENCIA"));
                            lsCEntidad.CUENTA_CROQUIS = dr.GetBoolean(dr.GetOrdinal("CUENTA_CROQUIS"));
                            lsCEntidad.CUENTA_SENDERO_RUTA = dr.GetBoolean(dr.GetOrdinal("CUENTA_SENDERO_RUTA"));
                            lsCEntidad.TIENE_VIAS = dr.GetBoolean(dr.GetOrdinal("TIENE_VIAS"));
                            lsCEntidad.COD_TIPO_SUPER = dr.GetString(dr.GetOrdinal("COD_TIPO_SUPER"));
                            lsCEntidad.TIPO_INFORME = dr.GetString(dr.GetOrdinal("TIPO_INFORME"));
                            lsCEntidad.OBSERVACION = dr.GetString(dr.GetOrdinal("OBSERVACION"));
                            lsCEntidad.CONCLUSION = dr.GetString(dr.GetOrdinal("CONCLUSION"));
                            lsCEntidad.ASUNTO = dr.GetString(dr.GetOrdinal("ASUNTO"));
                            lsCEntidad.CONTENIDO = dr.IsDBNull(dr.GetOrdinal("CONTENIDO")) ? "" : dr.GetString(dr.GetOrdinal("CONTENIDO"));
                            lsCEntidad.BUEN_DESEMPENIO = dr.GetInt32(dr.GetOrdinal("BUEN_DESEMPENIO"));
                            lsCEntidad.ARCHIVA_INFORME = (!dr.IsDBNull(dr.GetOrdinal("ARCHIVA_INFORME"))) ? dr.GetInt32(dr.GetOrdinal("ARCHIVA_INFORME")) : -1;

                        }
                        #endregion
                        #region ListInformeDetSupervisor
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            CEntPersona oPer;
                            while (dr.Read())
                            {
                                oPer = new CEntPersona();
                                oPer.COD_PERSONA = dr["COD_PERSONA"].ToString();
                                oPer.NOMBRES = dr["APELLIDOS_NOMBRES"].ToString();
                                oPer.FLAG_FIRMA = Convert.ToInt32(dr["FLAG_FIRMA"]);
                                oPer.ESTADO_FIRMA = dr["ESTADO_FIRMA"].ToString();
                                oPer.RegEstado = 0;
                                lsCEntidad.ListInformeDetSupervisor.Add(oPer);
                            }
                        }
                        #endregion
                        #region "ListVertice"
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            CapaEntidad.DOC.Ent_INFORME_VERTICE ocampoVer;
                            while (dr.Read())
                            {
                                ocampoVer = new CapaEntidad.DOC.Ent_INFORME_VERTICE();
                                ocampoVer.COD_SECUENCIAL = dr.GetInt32(dr.GetOrdinal("COD_SECUENCIAL"));
                                ocampoVer.VERTICE = dr.GetString(dr.GetOrdinal("VERTICE"));
                                ocampoVer.COORDENADA_NORTE = dr.GetInt32(dr.GetOrdinal("COORDENADA_NORTE"));
                                ocampoVer.COORDENADA_ESTE = dr.GetInt32(dr.GetOrdinal("COORDENADA_ESTE"));
                                ocampoVer.COORDENADA_NORTE_CAMPO = dr.GetInt32(dr.GetOrdinal("COORDENADA_NORTE_CAMPO"));
                                ocampoVer.COORDENADA_ESTE_CAMPO = dr.GetInt32(dr.GetOrdinal("COORDENADA_SUR_CAMPO"));
                                ocampoVer.ZONA = dr.GetString(dr.GetOrdinal("ZONA"));
                                ocampoVer.ZONA_CAMPO = dr.GetString(dr.GetOrdinal("ZONA_CAMPO"));
                                ocampoVer.RegEstado = 0;
                                lsCEntidad.ListVertice.Add(ocampoVer);
                            }
                        }
                        #endregion
                        #region "ListPrograma"
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            CapaEntidad.DOC.Ent_INFORME_PROGRAMA ocampoProg;
                            while (dr.Read())
                            {
                                ocampoProg = new CapaEntidad.DOC.Ent_INFORME_PROGRAMA();
                                ocampoProg.COD_PROGRAMA = dr.GetInt32(dr.GetOrdinal("COD_PROGRAMA"));
                                ocampoProg.ESTADO_PROGRAMA = dr.GetBoolean(dr.GetOrdinal("ESTADO_PROGRAMA"));
                                ocampoProg.TIPO_PROGRAMA = dr.GetString(dr.GetOrdinal("TIPO_PROGRAMA"));
                                ocampoProg.OBSERVACION = dr.GetString(dr.GetOrdinal("OBSERVACION"));
                                ocampoProg.TIPO = dr.GetString(dr.GetOrdinal("TIPO"));
                                ocampoProg.FRECUENCIA = dr.GetString(dr.GetOrdinal("FRECUENCIA"));
                                ocampoProg.DESCRIPCION = dr.GetString(dr.GetOrdinal("DESCRIPCION"));
                                ocampoProg.RegEstado = 0;
                                lsCEntidad.ListPrograma.Add(ocampoProg);
                            }
                        }
                        #endregion
                        #region "ListISUPERVISION_INFRAESTRUCTURA"
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidad();
                                ocampoEnt.COD_SECUENCIAL = dr.GetInt32(dr.GetOrdinal("COD_SECUENCIAL"));
                                ocampoEnt.TIPO_AMBIENTE = dr.GetString(dr.GetOrdinal("TIPO_AMBIENTE"));
                                ocampoEnt.NUM_AMBIENTE = dr.GetInt32(dr.GetOrdinal("NUM_AMBIENTE"));
                                ocampoEnt.AREA = dr.GetDecimal(dr.GetOrdinal("AREA"));
                                ocampoEnt.CAPACIDAD = dr.GetString(dr.GetOrdinal("CAPACIDAD"));
                                ocampoEnt.MATERIAL_CONSTRUCCION = dr.GetString(dr.GetOrdinal("MATERIAL_CONSTRUCCION"));
                                ocampoEnt.USO = dr.GetString(dr.GetOrdinal("USO"));
                                ocampoEnt.ESTADO_CONSERVACION = dr.GetString(dr.GetOrdinal("ESTADO_CONSERVACION"));
                                ocampoEnt.OBJETIVO = dr.GetString(dr.GetOrdinal("OBJETIVO"));
                                ocampoEnt.RegEstado = 0;
                                lsCEntidad.ListISUPERVISION_INFRAESTRUCTURA.Add(ocampoEnt);
                            }
                        }
                        #endregion
                        #region "ListISUPERVISION_DET_CAPACITACION_LOCAL"
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidad();
                                ocampoEnt.COD_PROGRAMA = dr.GetInt32(dr.GetOrdinal("COD_PROGRAMA"));
                                ocampoEnt.COD_SECUENCIAL = dr.GetInt32(dr.GetOrdinal("COD_SECUENCIAL"));
                                ocampoEnt.ACTIVIDAD_REALIZADA = dr.GetString(dr.GetOrdinal("ACTIVIDAD_REALIZADA"));
                                ocampoEnt.FECHA_REALIZADA = dr.GetString(dr.GetOrdinal("FECHA_REALIZADA"));
                                ocampoEnt.NUM_PERSONA = dr.GetInt32(dr.GetOrdinal("NUM_PERSONA"));
                                ocampoEnt.ESTADO_DOCUMENTO = dr.GetBoolean(dr.GetOrdinal("ESTADO_DOCUMENTO"));
                                ocampoEnt.DESC_TIPO_REGISTRO = dr.GetString(dr.GetOrdinal("TIPO_REGISTRO"));
                                ocampoEnt.OBJETIVO = dr.GetString(dr.GetOrdinal("OBJETIVO"));
                                ocampoEnt.AVANCE_RESULTADO = dr.GetString(dr.GetOrdinal("AVANCE_RESULTADO"));
                                ocampoEnt.LUGAR_CAPACITACION = dr.GetString(dr.GetOrdinal("LUGAR_CAPACITACION"));
                                ocampoEnt.OBSERVACION = dr.GetString(dr.GetOrdinal("OBSERVACION"));
                                ocampoEnt.RegEstado = 0;
                                lsCEntidad.ListISUPERVISION_DET_CAPACITACION_LOCAL.Add(ocampoEnt);
                            }
                        }
                        #endregion
                        #region "ListISUPERVISION_IDENTMANEJOIMPACTO"
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidad();
                                ocampoEnt.COD_SECUENCIAL = dr.GetInt32(dr.GetOrdinal("COD_SECUENCIAL"));
                                ocampoEnt.TIPO_IMPACTO = dr.GetString(dr.GetOrdinal("TIPO_IMPACTO"));
                                ocampoEnt.RIESGO_POTENCIAL = dr.GetString(dr.GetOrdinal("RIESGO_POTENCIAL"));
                                ocampoEnt.ACTIVIDAD = dr.GetString(dr.GetOrdinal("ACTIVIDAD"));
                                ocampoEnt.AVANCE_RESULTADO = dr.GetString(dr.GetOrdinal("AVANCE_RESULTADO"));
                                ocampoEnt.RegEstado = 0;
                                lsCEntidad.ListISUPERVISION_IDENTMANEJOIMPACTO.Add(ocampoEnt);
                            }
                        }
                        #endregion
                        #region "ListAvistamientoFauna"
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            CEntidad ocampoFau;
                            while (dr.Read())
                            {
                                ocampoFau = new CEntidad();
                                ocampoFau.COD_SECUENCIAL = dr.GetInt32(dr.GetOrdinal("COD_SECUENCIAL"));
                                ocampoFau.COD_ESPECIES = dr.GetString(dr.GetOrdinal("COD_ESPECIES"));
                                ocampoFau.DESC_ESPECIES = dr.GetString(dr.GetOrdinal("ESPECIES"));
                                ocampoFau.NUM_INDIVIDUOS = dr.GetInt32(dr.GetOrdinal("NUM_INDIVIDUOS"));
                                ocampoFau.COD_TIPO_REGISTRO = dr.GetString(dr.GetOrdinal("COD_TIPO_REGISTRO"));
                                ocampoFau.COD_ESTRATO = dr.GetString(dr.GetOrdinal("COD_ESTRATO"));
                                ocampoFau.FECHA_AVISTAMIENTO = dr.GetString(dr.GetOrdinal("FECHA_AVISTAMIENTO"));
                                ocampoFau.HORA_AVISTAMIENTO = dr.GetString(dr.GetOrdinal("HORA_AVISTAMIENTO"));
                                ocampoFau.ZONA = dr.GetString(dr.GetOrdinal("ZONA"));
                                ocampoFau.COORDENADA_NORTE = dr.GetInt32(dr.GetOrdinal("COORDENADA_NORTE"));
                                ocampoFau.COORDENADA_ESTE = dr.GetInt32(dr.GetOrdinal("COORDENADA_ESTE"));
                                ocampoFau.ALTITUD = dr.GetDecimal(dr.GetOrdinal("ALTITUD"));
                                ocampoFau.DESCRIPCION = dr.GetString(dr.GetOrdinal("OBSERVACION"));
                                ocampoFau.DESC_TIPO_REGISTRO = dr.GetString(dr.GetOrdinal("DESC_TIPO_REGISTRO"));
                                ocampoFau.DESC_ESTRATO = dr.GetString(dr.GetOrdinal("DESC_ESTRATO"));
                                ocampoFau.RegEstado = 0;
                                lsCEntidad.ListAvistamientoFauna.Add(ocampoFau);
                            }
                        }
                        #endregion
                        #region "ListRegistroFlora"
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            CapaEntidad.DOC.Ent_INFORME_REGFLORA ocampoFlo;
                            while (dr.Read())
                            {
                                ocampoFlo = new CapaEntidad.DOC.Ent_INFORME_REGFLORA();
                                ocampoFlo.COD_SECUENCIAL = dr.GetInt32(dr.GetOrdinal("COD_SECUENCIAL"));
                                ocampoFlo.COD_ESPECIES = dr.GetString(dr.GetOrdinal("COD_ESPECIES"));
                                ocampoFlo.ESPECIES = dr.GetString(dr.GetOrdinal("ESPECIES"));
                                ocampoFlo.DAP = dr.GetDecimal(dr.GetOrdinal("DAP"));
                                ocampoFlo.ALTURA_TOTAL = dr.GetDecimal(dr.GetOrdinal("ALTURA_TOTAL"));
                                ocampoFlo.ZONA = dr.GetString(dr.GetOrdinal("ZONA"));
                                ocampoFlo.COORDENADA_NORTE = dr.GetInt32(dr.GetOrdinal("COORDENADA_NORTE"));
                                ocampoFlo.COORDENADA_ESTE = dr.GetInt32(dr.GetOrdinal("COORDENADA_ESTE"));
                                ocampoFlo.ESTADO_ESPECIE = dr.GetString(dr.GetOrdinal("ESTADO_ESPECIE"));
                                ocampoFlo.OBSERVACION = dr.GetString(dr.GetOrdinal("OBSERVACION"));
                                ocampoFlo.DESC_TIPO_REGISTRO = dr.GetString(dr.GetOrdinal("TIPO_REGISTRO"));
                                ocampoFlo.RegEstado = 0;
                                lsCEntidad.ListRegistroFlora.Add(ocampoFlo);
                            }
                        }
                        #endregion
                        #region "ListRegistroPaisaje"
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            CapaEntidad.DOC.Ent_INFORME_REGPAISAJE ocampoPai;
                            while (dr.Read())
                            {
                                ocampoPai = new CapaEntidad.DOC.Ent_INFORME_REGPAISAJE();
                                ocampoPai.COD_SECUENCIAL = dr.GetInt32(dr.GetOrdinal("COD_SECUENCIAL"));
                                ocampoPai.TIPO = dr.GetString(dr.GetOrdinal("TIPO"));
                                ocampoPai.ESTADO_PAISAJE = dr.GetString(dr.GetOrdinal("ESTADO_PAISAJE"));
                                ocampoPai.NUM_VISITANTE = dr.GetString(dr.GetOrdinal("NUM_VISITANTE"));
                                ocampoPai.ZONA = dr.GetString(dr.GetOrdinal("ZONA"));
                                ocampoPai.COORDENADA_NORTE = dr.GetInt32(dr.GetOrdinal("COORDENADA_NORTE"));
                                ocampoPai.COORDENADA_ESTE = dr.GetInt32(dr.GetOrdinal("COORDENADA_ESTE"));
                                ocampoPai.OBSERVACION = dr.GetString(dr.GetOrdinal("OBSERVACION"));
                                ocampoPai.RegEstado = 0;
                                lsCEntidad.ListRegistroPaisaje.Add(ocampoPai);
                            }
                        }
                        #endregion
                        #region "ListISUPERVISION_DET_ZONIFICACION"
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidad();
                                ocampoEnt.COD_SECUENCIAL = dr.GetInt32(dr.GetOrdinal("COD_SECUENCIAL"));
                                ocampoEnt.NOMBRE_ZONA = dr.GetString(dr.GetOrdinal("NOMBRE_ZONA"));
                                ocampoEnt.CARACTERISTICA = dr.GetString(dr.GetOrdinal("CARACTERISTICA"));
                                ocampoEnt.COORDENADA_NORTE = dr.GetInt32(dr.GetOrdinal("COORDENADA_NORTE"));
                                ocampoEnt.COORDENADA_ESTE = dr.GetInt32(dr.GetOrdinal("COORDENADA_ESTE"));
                                ocampoEnt.TIPO_SENALIZACION = dr.GetString(dr.GetOrdinal("TIPO_SENALIZACION"));
                                ocampoEnt.TIPO_DELIMITACION = dr.GetString(dr.GetOrdinal("TIPO_DELIMITACION"));
                                ocampoEnt.ZONA = dr.GetString(dr.GetOrdinal("ZONA"));
                                ocampoEnt.RegEstado = 0;
                                lsCEntidad.ListISUPERVISION_DET_ZONIFICACION.Add(ocampoEnt);
                            }
                        }
                        #endregion
                        #region "ListISUPERVISION_DET_EQUIPACONSECION"
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidad();
                                ocampoEnt.COD_SECUENCIAL = dr.GetInt32(dr.GetOrdinal("COD_SECUENCIAL"));
                                ocampoEnt.DESCRIPCION = dr.GetString(dr.GetOrdinal("DESCRIPCION"));
                                ocampoEnt.NUM_AMBIENTE = dr.GetInt32(dr.GetOrdinal("NUM_AMBIENTE"));
                                ocampoEnt.USO = dr.GetString(dr.GetOrdinal("USO"));
                                ocampoEnt.ESTADO_CONSERVACION = dr.GetString(dr.GetOrdinal("ESTADO_CONSERVACION"));
                                ocampoEnt.OBJETIVO = dr.GetString(dr.GetOrdinal("OBJETIVO"));
                                ocampoEnt.OBSERVACION = dr.GetString(dr.GetOrdinal("OBSERVACION"));
                                ocampoEnt.RegEstado = 0;
                                lsCEntidad.ListISUPERVISION_DET_EQUIPACONSECION.Add(ocampoEnt);
                            }
                        }
                        #endregion
                        #region "ListISUPERVISION_OCARACTE_AMB01"
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidad();
                                switch (dr.GetInt32(dr.GetOrdinal("COD_PROGRAMA")))
                                {
                                    case 15: ocampoEnt.COD_OCONTRACTUAL = "01"; break;
                                    case 16: ocampoEnt.COD_OCONTRACTUAL = "02"; break;
                                    case 17: ocampoEnt.COD_OCONTRACTUAL = "03"; break;
                                    case 18: ocampoEnt.COD_OCONTRACTUAL = "04"; break;
                                }
                                ocampoEnt.COD_SECUENCIAL = dr.GetInt32(dr.GetOrdinal("COD_SECUENCIAL"));
                                ocampoEnt.COD_ESPECIES = dr.GetString(dr.GetOrdinal("COD_ESPECIES"));
                                ocampoEnt.ESPECIES = dr.GetString(dr.GetOrdinal("ESPECIES"));
                                ocampoEnt.ACTIVIDAD_ACTOS = dr.GetString(dr.GetOrdinal("ACTIVIDAD"));
                                ocampoEnt.ESTA_AUTORIZADO = dr.GetBoolean(dr.GetOrdinal("ESTA_AUTORIZADO"));
                                ocampoEnt.DOCUMENTOS_AFORESTAL = dr.GetString(dr.GetOrdinal("DOCUMENTOS_AFORESTAL"));
                                ocampoEnt.OBSERVACION = dr.GetString(dr.GetOrdinal("OBSERVACION"));
                                ocampoEnt.RegEstado = 0;
                                lsCEntidad.ListISUPERVISION_OCARACTE_AMB01.Add(ocampoEnt);
                            }
                        }
                        #endregion
                        #region "ListObligacionTitular"
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            CapaEntidad.DOC.Ent_INFORME_OBLIGTITULAR ocampooblig;
                            while (dr.Read())
                            {
                                ocampooblig = new CapaEntidad.DOC.Ent_INFORME_OBLIGTITULAR();
                                ocampooblig.COD_OBLIGTITULAR = dr["COD_OBLIGTITULAR"].ToString();
                                ocampooblig.OBLIGTITULAR = dr["OBLIGTITULAR"].ToString();
                                ocampooblig.EVAL_OBLIGTITULAR = dr["EVAL_OBLIGTITULAR"].ToString();
                                ocampooblig.OBSERVACION = dr["OBSERVACION"].ToString();
                                ocampooblig.COD_GRUPO = dr["COD_GRUPO"].ToString();
                                lsCEntidad.ListObligacionTitular.Add(ocampooblig);
                            }
                        }
                        #endregion
                        #region ListDesplazamientoInforme
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidad();
                                ocampoEnt.COD_DESPLAZAMIENTO = dr["COD_DESPLAZAMIENTO"].ToString();
                                ocampoEnt.ZONA = dr["PTOI_ZONA_UTM"].ToString();
                                ocampoEnt.COORDENADA_ESTE = Int32.Parse(dr["PTOI_COORDENADA_ESTE"].ToString());
                                ocampoEnt.COORDENADA_NORTE = Int32.Parse(dr["PTOI_COORDENADA_NORTE"].ToString());
                                ocampoEnt.ZONA_CAMPO = dr["PTOF_ZONA_UTM"].ToString();
                                ocampoEnt.COORDENADA_ESTE_CAMPO = Int32.Parse(dr["PTOF_COORDENADA_ESTE"].ToString());
                                ocampoEnt.COORDENADA_NORTE_CAMPO = Int32.Parse(dr["PTOF_COORDENADA_NORTE"].ToString());
                                ocampoEnt.OBSERVACION = dr["OBSERVACION"].ToString();
                                ocampoEnt.TipoVia = dr["TIPO"].ToString();
                                ocampoEnt.RegEstado = 0;
                                lsCEntidad.ListDesplazamientoInforme.Add(ocampoEnt);
                            }
                        }
                        #endregion
                        #region ListISDetConservActTuristica
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidad();
                                ocampoEnt.VCOD_INFORME = dr["VCOD_INFORME"].ToString(); ;
                                ocampoEnt.VDESCRIPCION = dr["VDESCRIPCION"].ToString();
                                ocampoEnt.NINDICE = int.Parse(dr["NINDICE"].ToString());
                                ocampoEnt.VCOORDENADAESTE = dr["VCOORDENADAESTE"].ToString();
                                ocampoEnt.VCOORDENADANORTE = dr["VCOORDENADANORTE"].ToString();
                                ocampoEnt.VZONAUTM = dr["VZONAUTM"].ToString();
                                ocampoEnt.RegEstado = 0;
                                lsCEntidad.ListISDetConservActTuristica.Add(ocampoEnt);
                            }
                        }
                        #endregion
                        #region lista de impacto
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            Ent_INFORME_IMPACTO infImpacto = new Ent_INFORME_IMPACTO();
                            while (dr.Read())
                            {
                                infImpacto = new Ent_INFORME_IMPACTO();
                                infImpacto.COD_INFORME = dr["COD_INFORME"].ToString();
                                infImpacto.COD_SECUENCIAL = decimal.Parse(dr["COD_SECUENCIAL"].ToString());
                                infImpacto.COD_ESPECIE = dr["COD_ESPECIE"].ToString();
                                infImpacto.NOM_CIENTIFICO = dr["NOMBRE_CIENTIFICO"].ToString();
                                infImpacto.NOM_COMUN = dr["NOMBRE_COMUN"].ToString();
                                infImpacto.DIAMETRO1 = decimal.Parse(dr["DIAMETRO1"].ToString());
                                infImpacto.DIAMETRO2 = decimal.Parse(dr["DIAMETRO2"].ToString());
                                infImpacto.LONGITUD = decimal.Parse(dr["LONGITUD"].ToString());
                                infImpacto.ESTADO = dr["ESTADO"].ToString();
                                infImpacto.OBSERVACIONES = dr["OBSERVACIONES"].ToString();
                                infImpacto.COORDENADA_ESTE = decimal.Parse(dr["COORDENADA_ESTE"].ToString());
                                infImpacto.COORDENADA_NORTE = decimal.Parse(dr["COODENADA_NORTE"].ToString());
                                infImpacto.ZONA = dr["ZONA"].ToString();
                                infImpacto.TIPO = int.Parse(dr["TIPO"].ToString());
                                infImpacto.RegEstado = 0;
                                lsCEntidad.ListImpacto.Add(infImpacto);
                            }
                        }
                        #endregion
                        #region lista de afectacion
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            Ent_INFORME_IMPACTO infImpacto = new Ent_INFORME_IMPACTO();
                            while (dr.Read())
                            {
                                infImpacto = new Ent_INFORME_IMPACTO();
                                infImpacto.COD_INFORME = dr["COD_INFORME"].ToString();
                                infImpacto.COD_SECUENCIAL = decimal.Parse(dr["COD_SECUENCIAL"].ToString());
                                infImpacto.ACTIVIDAD = dr["ACTIVIDAD"].ToString();
                                infImpacto.AREA = decimal.Parse(dr["AREA"].ToString());
                                infImpacto.OBSERVACIONES = dr["OBSERVACIONES"].ToString();
                                infImpacto.COORDENADA_ESTE = decimal.Parse(dr["COORDENADA_ESTE"].ToString());
                                infImpacto.COORDENADA_NORTE = decimal.Parse(dr["COODENADA_NORTE"].ToString());
                                infImpacto.ZONA = dr["ZONA"].ToString();
                                infImpacto.TIPO = int.Parse(dr["TIPO"].ToString());
                                infImpacto.RegEstado = 0;
                                lsCEntidad.ListAfectacion.Add(infImpacto);
                            }
                        }
                        #endregion
                        #region ListISDetConservActIntAmbiental
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidad();
                                ocampoEnt.VCOD_INFORME = dr["VCOD_INFORME"].ToString(); ;
                                ocampoEnt.VDESCRIPCION = dr["VDESCRIPCION"].ToString();
                                ocampoEnt.NINDICE = int.Parse(dr["NINDICE"].ToString());
                                ocampoEnt.VCOORDENADAESTE = dr["VCOORDENADAESTE"].ToString();
                                ocampoEnt.VCOORDENADANORTE = dr["VCOORDENADANORTE"].ToString();
                                ocampoEnt.VZONAUTM = dr["VZONAUTM"].ToString();
                                ocampoEnt.VOBSERVACION = dr["VOBSERVACION"].ToString();
                                ocampoEnt.RegEstado = 0;
                                lsCEntidad.ListISDetConservActIntAmbiental.Add(ocampoEnt);
                            }
                        }
                        #endregion
                        #region ListISDetConservActInvestigacion
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidad();
                                ocampoEnt.VCOD_INFORME = dr["VCOD_INFORME"].ToString(); ;
                                ocampoEnt.VDESCRIPCION = dr["VDESCRIPCION"].ToString();
                                ocampoEnt.VAVANCE = dr["VAVANCE"].ToString();
                                ocampoEnt.NINDICE = int.Parse(dr["NINDICE"].ToString());
                                ocampoEnt.VCOORDENADAESTE = dr["VCOORDENADAESTE"].ToString();
                                ocampoEnt.VCOORDENADANORTE = dr["VCOORDENADANORTE"].ToString();
                                ocampoEnt.VOBSERVACION = dr["VOBSERVACION"].ToString();
                                ocampoEnt.VZONAUTM = dr["VZONAUTM"].ToString();
                                ocampoEnt.VOBJETIVO = dr["VOBJETIVO"].ToString();
                                ocampoEnt.RegEstado = 0;
                                lsCEntidad.ListISDetConservActInvestigacion.Add(ocampoEnt);
                            }
                        }
                        #endregion
                        #region ListISDetConservActVisitas
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidad();
                                ocampoEnt.VCOD_INFORME = dr["VCOD_INFORME"].ToString(); ;
                                ocampoEnt.VDESCRIPCION = dr["VDESCRIPCION"].ToString();
                                ocampoEnt.NINDICE = int.Parse(dr["NINDICE"].ToString());
                                ocampoEnt.VPERFIL = dr["VPERFIL"].ToString();
                                ocampoEnt.RegEstado = 0;
                                lsCEntidad.ListISDetConservActVisitas.Add(ocampoEnt);
                            }
                        }
                        #endregion
                        #region ListISDetConservActOtroPrograma
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidad();
                                ocampoEnt.VCOD_INFORME = dr["VCOD_INFORME"].ToString(); ;
                                ocampoEnt.VDESCRIPCION = dr["VDESCRIPCION"].ToString();
                                ocampoEnt.NINDICE = int.Parse(dr["NINDICE"].ToString());
                                ocampoEnt.RegEstado = 0;
                                lsCEntidad.ListISDetConservActOtroPrograma.Add(ocampoEnt);
                            }
                        }
                        #endregion
                    }
                }
                return lsCEntidad;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public String RegIConservacionInsertar_v3(OracleConnection cn, CEntidad oCEntidad)
        {
            OracleTransaction tr = null;
            String OUTPUTPARAM01 = "";
            CEntidad ocampoSuper;
            try
            {
                tr = cn.BeginTransaction();
                #region "Grabando Cabecera"
                using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.INFORME_CONSERVACION_Grabar", oCEntidad))
                {
                    cmd.ExecuteNonQuery();
                    OUTPUTPARAM01 = (String)cmd.Parameters["OUTPUTPARAM01"].Value;
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
                        throw new Exception("El Número de Informe ya Existe");
                    }
                    else if (OUTPUTPARAM01 == "1")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("El Número del Titulo Habilitante Existe en otro Registro");
                    }
                    else if (OUTPUTPARAM01 == "2")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("No Tiene Permisos para Modificar este Informe");
                    }
                    else if (OUTPUTPARAM01 == "3")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("Está con Control de Calidad, no puede modificar");
                    }
                }
                #endregion
                #region "ListEliTABLA"
                if (oCEntidad.ListEliTABLA != null)
                {
                    foreach (var loDatos in oCEntidad.ListEliTABLA)
                    {
                        ocampoSuper = new CEntidad();
                        ocampoSuper.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                        ocampoSuper.EliTABLA = loDatos.EliTABLA;
                        ocampoSuper.EliVALOR01 = loDatos.EliVALOR01;
                        if (ocampoSuper.EliTABLA == "ListISUPERVISION_OCARACTE_AMB01")
                        {
                            switch (ocampoSuper.EliVALOR01)
                            {
                                case "01": ocampoSuper.EliVALOR01 = "15"; break;
                                case "02": ocampoSuper.EliVALOR01 = "16"; break;
                                case "03": ocampoSuper.EliVALOR01 = "17"; break;
                                case "04": ocampoSuper.EliVALOR01 = "18"; break;
                            }
                        }
                        ocampoSuper.COD_SECUENCIAL = loDatos.EliVALOR02;
                        ocampoSuper.COD_PERSONA = loDatos.COD_PERSONA;
                        ocampoSuper.COD_ESPECIES = loDatos.COD_ESPECIES;
                        ocampoSuper.COD_SECUENCIAL = ocampoSuper.EliTABLA == "AVISTAMIENTO" ? loDatos.COD_SECUENCIAL : ocampoSuper.COD_SECUENCIAL;
                        dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spINFORME_CONSERVEliminarDet", ocampoSuper);
                    }
                }
                #endregion
                #region ListInformeDetSupervisor
                if (oCEntidad.ListInformeDetSupervisor != null)
                {
                    CEntPersona ocampoPer;
                    foreach (var loDatos in oCEntidad.ListInformeDetSupervisor)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            ocampoPer = new CEntPersona();
                            ocampoPer.COD_PERSONA = loDatos.COD_PERSONA;
                            ocampoPer.CODIGO = OUTPUTPARAM01.Split('|')[0];
                            ocampoPer.RegEstado = 0;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.INFORME_DET_SUPERVISOR_GrabarV3", ocampoPer);
                        }
                    }
                }
                #endregion
                #region "ListVertice"
                if (oCEntidad.ListVertice != null)
                {
                    foreach (var loDatos in oCEntidad.ListVertice)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            ocampoSuper = new CEntidad();
                            ocampoSuper.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            ocampoSuper.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            ocampoSuper.VERTICE = loDatos.VERTICE;
                            ocampoSuper.COORDENADA_NORTE = loDatos.COORDENADA_NORTE;
                            ocampoSuper.COORDENADA_ESTE = loDatos.COORDENADA_ESTE;
                            ocampoSuper.COORDENADA_NORTE_CAMPO = loDatos.COORDENADA_NORTE_CAMPO;
                            ocampoSuper.COORDENADA_SUR_CAMPO = loDatos.COORDENADA_ESTE_CAMPO;
                            ocampoSuper.ZONA = loDatos.ZONA;
                            ocampoSuper.ZONA_CAMPO = loDatos.ZONA_CAMPO;
                            ocampoSuper.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.ISUPERVISION_DET_COORDENADAUTM_Grabar", ocampoSuper);
                        }
                    }
                }
                #endregion
                #region "ListISUPERVISION_INFRAESTRUCTURA"
                if (oCEntidad.ListISUPERVISION_INFRAESTRUCTURA != null)
                {
                    foreach (var loDatos in oCEntidad.ListISUPERVISION_INFRAESTRUCTURA)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            ocampoSuper = new CEntidad();
                            ocampoSuper.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            ocampoSuper.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            ocampoSuper.TIPO_AMBIENTE = loDatos.TIPO_AMBIENTE;
                            ocampoSuper.NUM_AMBIENTE = loDatos.NUM_AMBIENTE;
                            ocampoSuper.AREA = loDatos.AREA;
                            ocampoSuper.CAPACIDAD = loDatos.CAPACIDAD;
                            ocampoSuper.MATERIAL_CONSTRUCCION = loDatos.MATERIAL_CONSTRUCCION;
                            ocampoSuper.USO = loDatos.USO;
                            ocampoSuper.ESTADO_CONSERVACION = loDatos.ESTADO_CONSERVACION;
                            ocampoSuper.OBJETIVO = loDatos.OBJETIVO;
                            ocampoSuper.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.ISUPERVISION_DET_CONSERV_INFRA_Grabar", ocampoSuper);
                        }
                    }
                }
                #endregion
                #region "ListISUPERVISION_DET_CAPACITACION_LOCAL"
                if (oCEntidad.ListISUPERVISION_DET_CAPACITACION_LOCAL != null)
                {
                    foreach (var loDatos in oCEntidad.ListISUPERVISION_DET_CAPACITACION_LOCAL)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            ocampoSuper = new CEntidad();
                            ocampoSuper.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            ocampoSuper.COD_PROGRAMA = loDatos.COD_PROGRAMA;
                            ocampoSuper.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            ocampoSuper.ACTIVIDAD_REALIZADA = loDatos.ACTIVIDAD_REALIZADA;
                            ocampoSuper.FECHA_REALIZADA = loDatos.FECHA_REALIZADA;
                            ocampoSuper.NUM_PERSONA = loDatos.NUM_PERSONA;
                            ocampoSuper.ESTADO_DOCUMENTO = loDatos.ESTADO_DOCUMENTO;
                            ocampoSuper.DESC_TIPO_REGISTRO = loDatos.DESC_TIPO_REGISTRO;
                            ocampoSuper.OBJETIVO = loDatos.OBJETIVO;
                            ocampoSuper.AVANCE_RESULTADO = loDatos.AVANCE_RESULTADO;
                            ocampoSuper.LUGAR_CAPACITACION = loDatos.LUGAR_CAPACITACION;
                            ocampoSuper.OBSERVACION = loDatos.OBSERVACION;
                            ocampoSuper.NOMBRE_COMUNIDAD_SECTOR = loDatos.NOMBRE_COMUNIDAD_SECTOR;
                            ocampoSuper.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.ISUPERVISION_DET_CONSERV_PROG_Grabar", ocampoSuper);
                        }
                    }
                }
                #endregion
                #region "ListISUPERVISION_IDENTMANEJOIMPACTO"
                if (oCEntidad.ListISUPERVISION_IDENTMANEJOIMPACTO != null)
                {
                    foreach (var loDatos in oCEntidad.ListISUPERVISION_IDENTMANEJOIMPACTO)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            ocampoSuper = new CEntidad();
                            ocampoSuper.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            ocampoSuper.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            ocampoSuper.TIPO_IMPACTO = loDatos.TIPO_IMPACTO;
                            ocampoSuper.RIESGO_POTENCIAL = loDatos.RIESGO_POTENCIAL;
                            ocampoSuper.ACTIVIDAD = loDatos.ACTIVIDAD;
                            ocampoSuper.AVANCE_RESULTADO = loDatos.AVANCE_RESULTADO;
                            ocampoSuper.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.ISUPERVISION_DET_CONSERV_IDENTMANIMPACT_Grabar", ocampoSuper);
                        }
                    }
                }
                #endregion
                #region "ListAvistamientoFauna"
                if (oCEntidad.ListAvistamientoFauna != null)
                {
                    foreach (var loDatos in oCEntidad.ListAvistamientoFauna)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            ocampoSuper = new CEntidad();
                            ocampoSuper.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            ocampoSuper.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            ocampoSuper.COD_ESPECIES = loDatos.COD_ESPECIES;
                            ocampoSuper.NUM_INDIVIDUOS = loDatos.NUM_INDIVIDUOS;
                            ocampoSuper.COD_TIPO_REGISTRO = loDatos.COD_TIPO_REGISTRO;
                            ocampoSuper.COD_ESTRATO = loDatos.COD_ESTRATO;
                            ocampoSuper.FECHA_AVISTAMIENTO = loDatos.FECHA_AVISTAMIENTO;
                            ocampoSuper.HORA_AVISTAMIENTO = loDatos.HORA_AVISTAMIENTO;
                            ocampoSuper.ZONA = loDatos.ZONA;
                            ocampoSuper.COORDENADA_NORTE = loDatos.COORDENADA_NORTE;
                            ocampoSuper.COORDENADA_ESTE = loDatos.COORDENADA_ESTE;
                            ocampoSuper.ALTITUD = loDatos.ALTITUD;
                            ocampoSuper.DESCRIPCION = loDatos.DESCRIPCION;
                            ocampoSuper.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.ISUPERVISION_MADE_NOMADE_DET_AVISTAMIENTO_FAUNA_Grabar", ocampoSuper);
                        }
                    }
                }
                #endregion
                #region "ListRegistroFlora"
                if (oCEntidad.ListRegistroFlora != null)
                {
                    foreach (var loDatos in oCEntidad.ListRegistroFlora)
                    {
                        ocampoSuper = new CEntidad();
                        ocampoSuper.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                        ocampoSuper.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                        ocampoSuper.COD_ESPECIES = loDatos.COD_ESPECIES;
                        ocampoSuper.DAP = loDatos.DAP;
                        ocampoSuper.ALTURA_TOTAL = loDatos.ALTURA_TOTAL;
                        ocampoSuper.ZONA = loDatos.ZONA;
                        ocampoSuper.COORDENADA_NORTE = loDatos.COORDENADA_NORTE;
                        ocampoSuper.COORDENADA_ESTE = loDatos.COORDENADA_ESTE;
                        ocampoSuper.ESTADO_ESPECIE = loDatos.ESTADO_ESPECIE;
                        ocampoSuper.OBSERVACION = loDatos.OBSERVACION;
                        ocampoSuper.RegEstado = loDatos.RegEstado;
                        dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.ISUPERVISION_DET_CONSERV_FLORA_SILV_Grabar", ocampoSuper);
                    }
                }
                #endregion
                #region "ListRegistroPaisaje"
                if (oCEntidad.ListRegistroPaisaje != null)
                {
                    foreach (var loDatos in oCEntidad.ListRegistroPaisaje)
                    {
                        ocampoSuper = new CEntidad();
                        ocampoSuper.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                        ocampoSuper.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                        ocampoSuper.TIPO = loDatos.TIPO;
                        ocampoSuper.ESTADO_PAISAJE = loDatos.ESTADO_PAISAJE;
                        ocampoSuper.NUM_VISITANTE = loDatos.NUM_VISITANTE;
                        ocampoSuper.ZONA = loDatos.ZONA;
                        ocampoSuper.COORDENADA_NORTE = loDatos.COORDENADA_NORTE;
                        ocampoSuper.COORDENADA_ESTE = loDatos.COORDENADA_ESTE;
                        ocampoSuper.OBSERVACION = loDatos.OBSERVACION;
                        ocampoSuper.RegEstado = loDatos.RegEstado;
                        dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.ISUPERVISION_DET_CONSERV_RPAISAJ_CULT_Grabar", ocampoSuper);
                    }
                }
                #endregion
                #region "ListISUPERVISION_OCARACTE_AMB01"
                if (oCEntidad.ListISUPERVISION_OCARACTE_AMB01 != null)
                {
                    foreach (var loDatos in oCEntidad.ListISUPERVISION_OCARACTE_AMB01)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            ocampoSuper = new CEntidad();
                            ocampoSuper.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            switch (loDatos.COD_OCONTRACTUAL)
                            {
                                case "01": ocampoSuper.COD_PROGRAMA = 15; break;
                                case "02": ocampoSuper.COD_PROGRAMA = 16; break;
                                case "03": ocampoSuper.COD_PROGRAMA = 17; break;
                                case "04": ocampoSuper.COD_PROGRAMA = 18; break;
                            }
                            ocampoSuper.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            ocampoSuper.COD_ESPECIES = loDatos.COD_ESPECIES;
                            ocampoSuper.ACTIVIDAD = loDatos.ACTIVIDAD_ACTOS;
                            ocampoSuper.ESTA_AUTORIZADO = loDatos.ESTA_AUTORIZADO;
                            ocampoSuper.DOCUMENTOS_AFORESTAL = loDatos.DOCUMENTOS_AFORESTAL;
                            ocampoSuper.OBSERVACION = loDatos.OBSERVACION;
                            ocampoSuper.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.ISUPERVISION_DET_CONSERV_OBLIGCONTR_Grabar", ocampoSuper);
                        }
                    }
                }
                #endregion
                #region "ListPrograma"
                if (oCEntidad.ListPrograma != null)
                {
                    foreach (var loDatos in oCEntidad.ListPrograma)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            ocampoSuper = new CEntidad();
                            ocampoSuper.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            ocampoSuper.COD_PROGRAMA = loDatos.COD_PROGRAMA;
                            ocampoSuper.ESTADO_PROGRAMA = loDatos.ESTADO_PROGRAMA;
                            ocampoSuper.OBSERVACION = loDatos.OBSERVACION;
                            ocampoSuper.TIPO = loDatos.TIPO;
                            ocampoSuper.FRECUENCIA = loDatos.FRECUENCIA;
                            ocampoSuper.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.ISUPERVISION_DET_PROGRAMA_Grabar", ocampoSuper);
                        }
                    }
                }
                #endregion
                #region "ListISUPERVISION_DET_ZONIFICACION"
                if (oCEntidad.ListISUPERVISION_DET_ZONIFICACION != null)
                {
                    foreach (var loDatos in oCEntidad.ListISUPERVISION_DET_ZONIFICACION)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            ocampoSuper = new CEntidad();
                            ocampoSuper.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            ocampoSuper.COD_PROGRAMA = loDatos.COD_PROGRAMA;
                            ocampoSuper.NOMBRE_ZONA = loDatos.NOMBRE_ZONA;
                            ocampoSuper.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            ocampoSuper.CARACTERISTICA = loDatos.CARACTERISTICA;
                            ocampoSuper.COORDENADA_NORTE = loDatos.COORDENADA_NORTE;
                            ocampoSuper.COORDENADA_ESTE = loDatos.COORDENADA_ESTE;
                            ocampoSuper.TIPO_SENALIZACION = loDatos.TIPO_SENALIZACION;
                            ocampoSuper.TIPO_DELIMITACION = loDatos.TIPO_DELIMITACION;
                            ocampoSuper.ZONA = loDatos.ZONA;
                            ocampoSuper.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.ISUPERVISION_DET_CONSERV_ZONIFICACION_Grabar", ocampoSuper);
                        }
                    }
                }
                #endregion
                #region "ListISUPERVISION_DET_EQUIPACONSECION"
                if (oCEntidad.ListISUPERVISION_DET_EQUIPACONSECION != null)
                {
                    foreach (var loDatos in oCEntidad.ListISUPERVISION_DET_EQUIPACONSECION)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            ocampoSuper = new CEntidad();
                            ocampoSuper.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            ocampoSuper.COD_PROGRAMA = loDatos.COD_PROGRAMA;
                            ocampoSuper.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            ocampoSuper.DESCRIPCION = loDatos.DESCRIPCION;
                            ocampoSuper.NUM_AMBIENTE = loDatos.NUM_AMBIENTE;
                            ocampoSuper.USO = loDatos.USO;
                            ocampoSuper.ESTADO_CONSERVACION = loDatos.ESTADO_CONSERVACION;
                            ocampoSuper.OBJETIVO = loDatos.OBJETIVO;
                            ocampoSuper.OBSERVACION = loDatos.OBSERVACION;
                            ocampoSuper.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.ISUPERVISION_DET_CONSERV_CONSECION_Grabar", ocampoSuper);
                        }
                    }
                }
                #endregion
                #region ListObligacionTitular
                if (oCEntidad.ListObligacionTitular != null)
                {
                    CapaEntidad.DOC.Ent_INFORME_OBLIGTITULAR ocampooblig;
                    foreach (var loDatos in oCEntidad.ListObligacionTitular)
                    {
                        ocampooblig = new CapaEntidad.DOC.Ent_INFORME_OBLIGTITULAR();
                        ocampooblig.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                        ocampooblig.COD_OBLIGTITULAR = loDatos.COD_OBLIGTITULAR;
                        ocampooblig.EVAL_OBLIGTITULAR = loDatos.EVAL_OBLIGTITULAR;
                        ocampooblig.OBSERVACION = loDatos.OBSERVACION;
                        ocampooblig.COD_UCUENTA = oCEntidad.COD_UCUENTA;
                        dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spISUPERVISION_OBLIG_TITULARGrabar", ocampooblig);
                    }
                }
                #endregion
                #region "ListDesplazamientoInforme"
                if (oCEntidad.ListDesplazamientoInforme != null)
                {
                    foreach (var loDatos in oCEntidad.ListDesplazamientoInforme)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            ocampoSuper = new CEntidad();
                            ocampoSuper.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            ocampoSuper.COD_DESPLAZAMIENTO = loDatos.COD_DESPLAZAMIENTO;
                            ocampoSuper.ZONA = loDatos.ZONA;
                            ocampoSuper.PTOI_COORDENADA_ESTE = loDatos.COORDENADA_ESTE;
                            ocampoSuper.PTOI_COORDENADA_NORTE = loDatos.COORDENADA_NORTE;
                            ocampoSuper.ZONA_CAMPO = loDatos.ZONA_CAMPO;
                            ocampoSuper.PTOF_COORDENADA_ESTE = loDatos.COORDENADA_ESTE_CAMPO;
                            ocampoSuper.PTOF_COORDENADA_NORTE = loDatos.COORDENADA_NORTE_CAMPO;
                            ocampoSuper.OBSERVACION = loDatos.OBSERVACION;
                            ocampoSuper.TIPO = loDatos.TipoVia;
                            ocampoSuper.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spINFORME_DESPLAZAMIENTOGrabar", ocampoSuper);
                        }
                    }
                }
                #endregion
                #region "ListISDetConservActTuristica"
                if (oCEntidad.ListISDetConservActTuristica != null)
                {
                    foreach (var loDatos in oCEntidad.ListISDetConservActTuristica)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            ocampoSuper = new CEntidad();
                            ocampoSuper.VCOD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            ocampoSuper.NINDICE = loDatos.NINDICE;
                            ocampoSuper.VZONAUTM = loDatos.VZONAUTM;
                            ocampoSuper.VCOORDENADANORTE = loDatos.VCOORDENADANORTE;
                            ocampoSuper.VCOORDENADAESTE = loDatos.VCOORDENADAESTE;
                            ocampoSuper.VDESCRIPCION = loDatos.VDESCRIPCION;
                            ocampoSuper.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.SPISDETCONSERV_ACTTURISTICA_GRABAR", ocampoSuper);
                        }
                    }
                }
                #endregion
                #region "lista de impacto"
                if (oCEntidad.ListImpacto != null)
                {
                    Ent_INFORME_IMPACTO ocampoImpacto = new Ent_INFORME_IMPACTO();
                    foreach (var loDatos in oCEntidad.ListImpacto)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            ocampoImpacto = new Ent_INFORME_IMPACTO();
                            ocampoImpacto.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            ocampoImpacto.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            ocampoImpacto.COD_ESPECIE = loDatos.COD_ESPECIE;
                            ocampoImpacto.DIAMETRO1 = loDatos.DIAMETRO1;
                            ocampoImpacto.DIAMETRO2 = loDatos.DIAMETRO2;
                            ocampoImpacto.LONGITUD = loDatos.LONGITUD;
                            ocampoImpacto.ESTADO = loDatos.ESTADO;
                            ocampoImpacto.OBSERVACIONES = loDatos.OBSERVACIONES;
                            ocampoImpacto.COORDENADA_ESTE = loDatos.COORDENADA_ESTE;
                            ocampoImpacto.COORDENADA_NORTE = loDatos.COORDENADA_NORTE;
                            ocampoImpacto.ZONA = loDatos.ZONA;
                            ocampoImpacto.ACTIVIDAD = loDatos.ACTIVIDAD;
                            ocampoImpacto.AREA = loDatos.AREA;
                            ocampoImpacto.TIPO = loDatos.TIPO;
                            ocampoImpacto.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.SPISDETCONSERV_IMPACTO_GRABAR", ocampoImpacto);
                        }
                    }
                }
                #endregion
                #region "eliminar impacto"
                if (oCEntidad.ListEliTABLAImpacto != null)
                {
                    foreach (var loDatos in oCEntidad.ListEliTABLAImpacto)
                    {
                        ocampoSuper = new CEntidad();
                        ocampoSuper.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                        ocampoSuper.EliTABLA = loDatos.EliTABLA;
                        ocampoSuper.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                        dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spINFORME_CONSERVEliminarDet", ocampoSuper);
                    }
                }
                #endregion
                #region "ListISDetConservActTuristica"
                if (oCEntidad.ListISDetConservActTuristica != null)
                {
                    foreach (var loDatos in oCEntidad.ListISDetConservActTuristica)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            ocampoSuper = new CEntidad();
                            ocampoSuper.VCOD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            ocampoSuper.NINDICE = loDatos.NINDICE;
                            ocampoSuper.VZONAUTM = loDatos.VZONAUTM;
                            ocampoSuper.VCOORDENADANORTE = loDatos.VCOORDENADANORTE;
                            ocampoSuper.VCOORDENADAESTE = loDatos.VCOORDENADAESTE;
                            ocampoSuper.VDESCRIPCION = loDatos.VDESCRIPCION;
                            ocampoSuper.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.SPISDETCONSERV_ACTTURISTICA_GRABAR", ocampoSuper);
                        }
                    }
                }
                #endregion
                #region "lista de impacto"
                if (oCEntidad.ListImpacto != null)
                {
                    Ent_INFORME_IMPACTO ocampoImpacto = new Ent_INFORME_IMPACTO();
                    foreach (var loDatos in oCEntidad.ListImpacto)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            ocampoImpacto = new Ent_INFORME_IMPACTO();
                            ocampoImpacto.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            ocampoImpacto.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            ocampoImpacto.COD_ESPECIE = loDatos.COD_ESPECIE;
                            ocampoImpacto.DIAMETRO1 = loDatos.DIAMETRO1;
                            ocampoImpacto.DIAMETRO2 = loDatos.DIAMETRO2;
                            ocampoImpacto.LONGITUD = loDatos.LONGITUD;
                            ocampoImpacto.ESTADO = loDatos.ESTADO;
                            ocampoImpacto.OBSERVACIONES = loDatos.OBSERVACIONES;
                            ocampoImpacto.COORDENADA_ESTE = loDatos.COORDENADA_ESTE;
                            ocampoImpacto.COORDENADA_NORTE = loDatos.COORDENADA_NORTE;
                            ocampoImpacto.ZONA = loDatos.ZONA;
                            ocampoImpacto.ACTIVIDAD = loDatos.ACTIVIDAD;
                            ocampoImpacto.AREA = loDatos.AREA;
                            ocampoImpacto.TIPO = loDatos.TIPO;
                            ocampoImpacto.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.SPISDETCONSERV_IMPACTO_GRABAR", ocampoImpacto);
                        }
                    }
                }
                #endregion
                #region "eliminar impacto"
                if (oCEntidad.ListEliTABLAImpacto != null)
                {
                    foreach (var loDatos in oCEntidad.ListEliTABLAImpacto)
                    {
                        ocampoSuper = new CEntidad();
                        ocampoSuper.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                        ocampoSuper.EliTABLA = loDatos.EliTABLA;
                        ocampoSuper.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                        dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spINFORME_CONSERVEliminarDet", ocampoSuper);
                    }
                }
                #endregion
                #region "lista de afectacion"
                if (oCEntidad.ListAfectacion != null)
                {
                    Ent_INFORME_IMPACTO oCampos = new Ent_INFORME_IMPACTO();
                    foreach (var loDatos in oCEntidad.ListAfectacion)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            oCampos = new Ent_INFORME_IMPACTO();
                            oCampos.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            oCampos.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            oCampos.ACTIVIDAD = loDatos.ACTIVIDAD;
                            oCampos.AREA = loDatos.AREA;
                            oCampos.OBSERVACIONES = loDatos.OBSERVACIONES;
                            oCampos.COORDENADA_ESTE = loDatos.COORDENADA_ESTE;
                            oCampos.COORDENADA_NORTE = loDatos.COORDENADA_NORTE;
                            oCampos.ZONA = loDatos.ZONA;
                            oCampos.TIPO = loDatos.TIPO;
                            oCampos.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.SPISDETCONSERV_IMPACTO_GRABAR", oCampos);
                        }
                    }
                }
                #endregion
                #region "ListISDetConservActIntAmbiental"
                if (oCEntidad.ListISDetConservActIntAmbiental != null)
                {
                    foreach (var loDatos in oCEntidad.ListISDetConservActIntAmbiental)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            ocampoSuper = new CEntidad();
                            ocampoSuper.VCOD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            ocampoSuper.NINDICE = loDatos.NINDICE;
                            ocampoSuper.VZONAUTM = loDatos.VZONAUTM;
                            ocampoSuper.VCOORDENADANORTE = loDatos.VCOORDENADANORTE;
                            ocampoSuper.VCOORDENADAESTE = loDatos.VCOORDENADAESTE;
                            ocampoSuper.VDESCRIPCION = loDatos.VDESCRIPCION;
                            ocampoSuper.VOBSERVACION = loDatos.VOBSERVACION;
                            ocampoSuper.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.SPISDETCONSERV_ACTINTAMBIENTAL_GRABAR", ocampoSuper);
                        }
                    }
                }
                #endregion
                #region "ListISDetConservActInvestigacion"
                if (oCEntidad.ListISDetConservActInvestigacion != null)
                {
                    foreach (var loDatos in oCEntidad.ListISDetConservActInvestigacion)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            ocampoSuper = new CEntidad();
                            ocampoSuper.VCOD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            ocampoSuper.NINDICE = loDatos.NINDICE;
                            ocampoSuper.VZONAUTM = loDatos.VZONAUTM;
                            ocampoSuper.VAVANCE = loDatos.VAVANCE;
                            ocampoSuper.VCOORDENADANORTE = loDatos.VCOORDENADANORTE;
                            ocampoSuper.VCOORDENADAESTE = loDatos.VCOORDENADAESTE;
                            ocampoSuper.VDESCRIPCION = loDatos.VDESCRIPCION;
                            ocampoSuper.VOBSERVACION = loDatos.VOBSERVACION;
                            ocampoSuper.VOBJETIVO = loDatos.VOBJETIVO;
                            ocampoSuper.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.SPISDETCONSERV_ACTINVESTIGACION_GRABAR", ocampoSuper);
                        }
                    }
                }
                #endregion
                #region "ListISDetConservActVisitas"
                if (oCEntidad.ListISDetConservActVisitas != null)
                {
                    foreach (var loDatos in oCEntidad.ListISDetConservActVisitas)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            ocampoSuper = new CEntidad();
                            ocampoSuper.VCOD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            ocampoSuper.NINDICE = loDatos.NINDICE;
                            ocampoSuper.VPERFIL = loDatos.VPERFIL;
                            ocampoSuper.VDESCRIPCION = loDatos.VDESCRIPCION;
                            ocampoSuper.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.SPISDETCONSERV_ACTVISITAS_GRABAR", ocampoSuper);
                        }
                    }
                }
                #endregion
                #region "ListISDetConservActOtroPrograma"
                if (oCEntidad.ListISDetConservActOtroPrograma != null)
                {
                    foreach (var loDatos in oCEntidad.ListISDetConservActOtroPrograma)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            ocampoSuper = new CEntidad();
                            ocampoSuper.VCOD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            ocampoSuper.NINDICE = loDatos.NINDICE;
                            ocampoSuper.VDESCRIPCION = loDatos.VDESCRIPCION;
                            ocampoSuper.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.SPISDETCONSERV_ACTOTROSPROGRAMAS_GRABAR", ocampoSuper);
                        }
                    }
                }
                #endregion
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

        public CEntidad RegIFaunaMostrarListaItem_v3(OracleConnection cn, String codInforme)
        {
            CEntidad lsCEntidad = new CEntidad();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spIFAUNAMostrarItem_v3", new CEntidad() { COD_INFORME = codInforme } ))
                {
                    if (dr != null)
                    {
                        lsCEntidad.ListCNotificaciones = new List<CEntidad>();
                        lsCEntidad.ListPOAs = new List<CEntidad>();
                        lsCEntidad.ListInformeDetSupervisor = new List<CEntPersona>();
                        lsCEntidad.ListFotos = new List<CEntidad>();
                        lsCEntidad.ListPrograma = new List<CapaEntidad.DOC.Ent_INFORME_PROGRAMA>();
                        lsCEntidad.ListISUPERVISION_IDENTMANEJOIMPACTO = new List<CEntidad>();
                        lsCEntidad.ListISUPERVISION_DET_CAPACITACION_ACTDES = new List<CEntidad>();
                        lsCEntidad.ListOCActosTercero = new List<CEntidad>();
                        lsCEntidad.ListDesplazamientoInforme = new List<CEntidad>();
                        CEntidad ocampoEnt;

                        #region "Datos Generales"
                        if (dr.HasRows)
                        {
                            dr.Read();
                            lsCEntidad.COD_ESTADO_DOC = dr.GetString(dr.GetOrdinal("COD_ESTADO_DOC"));
                            lsCEntidad.OBSERVACIONES_CONTROL = dr.GetString(dr.GetOrdinal("OBSERVACIONES_CONTROL"));
                            lsCEntidad.OBSERV_SUBSANAR = dr.GetBoolean(dr.GetOrdinal("OBSERV_SUBSANAR"));
                            lsCEntidad.USUARIO_REGISTRO = dr.GetString(dr.GetOrdinal("USUARIO_REGISTRO"));
                            lsCEntidad.USUARIO_CONTROL = dr.GetString(dr.GetOrdinal("USUARIO_CONTROL"));
                            lsCEntidad.PUBLICAR = dr.GetBoolean(dr.GetOrdinal("PUBLICAR"));
                            lsCEntidad.COD_OD_REGISTRO = dr.GetString(dr.GetOrdinal("COD_OD_REGISTRO"));
                            lsCEntidad.NUMERO = dr.GetString(dr.GetOrdinal("NUMERO"));
                            lsCEntidad.FECHA_ENTREGA = dr.GetString(dr.GetOrdinal("FECHA_ENTREGA"));
                            lsCEntidad.COD_DIRECTOR = dr.GetString(dr.GetOrdinal("COD_DIRECTOR"));
                            lsCEntidad.NOMBRE_DIRECTOR = dr.GetString(dr.GetOrdinal("APELLIDOS_NOMBRES"));
                            lsCEntidad.ASUNTO = dr.GetString(dr.GetOrdinal("ASUNTO"));
                            lsCEntidad.CONTENIDO = dr.GetString(dr.GetOrdinal("CONTENIDO"));
                            lsCEntidad.FECHA_SUPERVISION_INICIO = dr.GetString(dr.GetOrdinal("FECHA_SUPERVISION_INICIO"));
                            lsCEntidad.FECHA_SUPERVISION_FIN = dr.GetString(dr.GetOrdinal("FECHA_SUPERVISION_FIN"));
                            lsCEntidad.COD_IMOTIVO = dr.GetString(dr.GetOrdinal("COD_IMOTIVO"));
                            lsCEntidad.IMOTIVO = dr.GetString(dr.GetOrdinal("IMOTIVO"));
                            lsCEntidad.MAE_TIP_MOTMOTIVADA = dr.GetString(dr.GetOrdinal("MAE_TIP_MOTMOTIVADA"));
                            lsCEntidad.COD_TRAMITE_SITD = dr.GetInt32(dr.GetOrdinal("COD_TRAMITE_SITD"));
                            lsCEntidad.NUM_DREFERENCIA = dr.GetString(dr.GetOrdinal("NUM_DREFERENCIA"));
                            lsCEntidad.GEOTEC_DESCRIPCION = dr.GetString(dr.GetOrdinal("GEOTEC_DESCRIPCION"));
                            lsCEntidad.GEOTEC_DRON = dr.GetBoolean(dr.GetOrdinal("GEOTEC_DRON"));
                            lsCEntidad.GEOTEC_GEOSUPERVISOR = dr.GetBoolean(dr.GetOrdinal("GEOTEC_GEOSUPERVISOR"));
                            lsCEntidad.GEOTEC_NINGUNO = dr.GetBoolean(dr.GetOrdinal("GEOTEC_NINGUNO"));
                            lsCEntidad.GEOTEC_OTROS = dr.GetBoolean(dr.GetOrdinal("GEOTEC_OTROS"));
                            lsCEntidad.REALIZADO_VEEDORFORESTAL = dr.GetBoolean(dr.GetOrdinal("REALIZADO_VEEDORFORESTAL"));
                            lsCEntidad.COD_TECNICO = dr.GetString(dr.GetOrdinal("COD_TECNICO"));
                            lsCEntidad.NOMBRE_TECNICO = dr.GetString(dr.GetOrdinal("NOMBRE_TECNICO"));
                            lsCEntidad.COD_TITULAR_EJECUTA = dr.GetString(dr.GetOrdinal("COD_TITULAR_EJECUTA"));
                            lsCEntidad.TITULAR_EJECUTA = dr.GetString(dr.GetOrdinal("TITULAR_EJECUTA"));
                            lsCEntidad.COD_REGENTE_IMPLEMENTA = dr.GetString(dr.GetOrdinal("COD_REGENTE_IMPLEMENTA"));
                            lsCEntidad.REGENTE_IMPLEMENTA = dr.GetString(dr.GetOrdinal("REGENTE_IMPLEMENTA"));
                            lsCEntidad.THABILITANTE_COD_UBIGEO = dr.GetString(dr.GetOrdinal("THABILITANTE_COD_UBIGEO"));
                            lsCEntidad.UBIGEO = dr.GetString(dr.GetOrdinal("UBIGEO"));
                            lsCEntidad.THABILITANTE_SECTOR = dr.GetString(dr.GetOrdinal("THABILITANTE_SECTOR"));
                            lsCEntidad.OBSERVACION = dr.GetString(dr.GetOrdinal("OBSERVACION"));
                            lsCEntidad.CONCLUSION = dr.GetString(dr.GetOrdinal("CONCLUSION"));
                            lsCEntidad.COD_TIPO_SUPER = dr.GetString(dr.GetOrdinal("COD_TIPO_SUPER"));
                            lsCEntidad.TIPO_INFORME = dr.GetString(dr.GetOrdinal("TIPO_INFORME"));
                            lsCEntidad.BUEN_DESEMPENIO = dr.GetInt32(dr.GetOrdinal("BUEN_DESEMPENIO"));
                            lsCEntidad.ARCHIVA_INFORME = (!dr.IsDBNull(dr.GetOrdinal("ARCHIVA_INFORME"))) ? dr.GetInt32(dr.GetOrdinal("ARCHIVA_INFORME")) : -1;
                        }
                        #endregion
                        #region "ListCNotificaciones"
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidad();
                                ocampoEnt.COD_CNOTIFICACION = dr.GetString(dr.GetOrdinal("COD_CNOTIFICACION"));
                                ocampoEnt.NUMERO = dr.GetString(dr.GetOrdinal("NUMERO"));
                                /*ocampoEnt.COD_FISNOTI = dr.GetString(dr.GetOrdinal("COD_FISNOTI"));
                                ocampoEnt.NUM_NOTIFICACION = dr.GetString(dr.GetOrdinal("NUM_NOTIFICACION"));*/
                                ocampoEnt.NUM_THABILITANTE = dr.GetString(dr.GetOrdinal("NUM_THABILITANTE"));
                                ocampoEnt.ESTADO_ORIGEN = dr.GetString(dr.GetOrdinal("ESTADO_ORIGEN"));
                                ocampoEnt.ESTADO_ORIGEN_TEXT = dr.GetString(dr.GetOrdinal("ESTADO_ORIGEN_TEXT"));
                                ocampoEnt.MAE_CNTIPO = dr.GetString(dr.GetOrdinal("MAE_CNTIPO"));
                                ocampoEnt.MTIPO = dr.GetString(dr.GetOrdinal("MODALIDAD_TIPO"));
                                /*ocampoEnt.NOMBRE_POA = dr.GetString(dr.GetOrdinal("NOMBRE_POA"));
                                ocampoEnt.FCTIPO = dr.GetString(dr.GetOrdinal("FCTIPO"));
                                ocampoEnt.MTIPO = dr.GetString(dr.GetOrdinal("MTIPO"));*/
                                ocampoEnt.RegEstado = 0;
                                lsCEntidad.ListCNotificaciones.Add(ocampoEnt);
                            }
                        }
                        #endregion
                        #region "ListPOAs"
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidad();
                                ocampoEnt.COD_THABILITANTE = dr["COD_THABILITANTE"].ToString();
                                ocampoEnt.NUM_POA = Int32.Parse(dr["NUM_POA"].ToString());
                                ocampoEnt.POA = dr["POA"].ToString();
                                ocampoEnt.PUBLICAR = Convert.ToBoolean(dr["PUBLICAR"]);
                                ocampoEnt.SUPERVISADO = Convert.ToBoolean(dr["SUPERVISADO"]);
                                ocampoEnt.B_POA = Int32.Parse(dr["B_POA"].ToString());
                                ocampoEnt.CODIGO_SEC_NOPOA = dr["CODIGO_SEC_NOPOA"].ToString();
                                ocampoEnt.RegEstado = 0;
                                lsCEntidad.ListPOAs.Add(ocampoEnt);
                            }
                        }
                        #endregion
                        #region "ListInformeDetSupervisor"
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            CEntPersona oPer;
                            while (dr.Read())
                            {
                                oPer = new CEntPersona();
                                oPer.COD_PERSONA = dr["COD_PERSONA"].ToString();
                                oPer.NOMBRES = dr["APELLIDOS_NOMBRES"].ToString();
                                oPer.ESTADO_FIRMA = dr["ESTADO_FIRMA"].ToString();
                                oPer.FLAG_FIRMA =Convert.ToInt32(dr["FLAG_FIRMA"]);
                                oPer.RegEstado = 0;
                                lsCEntidad.ListInformeDetSupervisor.Add(oPer);
                            }
                        }
                        #endregion
                        #region "ListFotos"
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                CEntidad ocampo = new CEntidad();
                                ocampo.COD_INFORME_FOTOS = dr["COD_INFORME_FOTOS"].ToString();
                                ocampo.COD_INFORME = dr["COD_INFORME"].ToString();
                                ocampo.URL_FOTO = dr["URL_FOTO"].ToString();
                                ocampo.DESC_FOTO = dr["DESCRIPCION"].ToString();
                                ocampo.FUENTE_FOTO = dr["FUENTE"].ToString();
                                ocampo.DISP_FOTO = dr["DISPOSITIVO"].ToString();
                                ocampo.FECHA = dr["FECHA"].ToString();
                                ocampo.USUARIO_REGISTRO = dr["USUARIO_REGISTRO"].ToString();
                                lsCEntidad.ListFotos.Add(ocampo);
                            }
                        }
                        #endregion
                        #region "ListPrograma"
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            CapaEntidad.DOC.Ent_INFORME_PROGRAMA ocampoProg;
                            while (dr.Read())
                            {
                                ocampoProg = new CapaEntidad.DOC.Ent_INFORME_PROGRAMA();
                                ocampoProg.COD_PROGRAMA = dr.GetInt32(dr.GetOrdinal("COD_PROGRAMA"));
                                ocampoProg.ESTADO_PROGRAMA = dr.GetBoolean(dr.GetOrdinal("ESTADO_PROGRAMA"));
                                ocampoProg.TIPO_PROGRAMA = dr.GetString(dr.GetOrdinal("TIPO_PROGRAMA"));
                                ocampoProg.OBSERVACION = dr.GetString(dr.GetOrdinal("OBSERVACION"));
                                ocampoProg.TIPO = dr.GetString(dr.GetOrdinal("TIPO"));
                                ocampoProg.FRECUENCIA = dr.GetString(dr.GetOrdinal("FRECUENCIA"));
                                ocampoProg.DESCRIPCION = dr.GetString(dr.GetOrdinal("DESCRIPCION"));
                                ocampoProg.RegEstado = 0;
                                lsCEntidad.ListPrograma.Add(ocampoProg);
                            }
                        }
                        #endregion
                        #region "ListISUPERVISION_IDENTMANEJOIMPACTO"
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidad();
                                ocampoEnt.COD_SECUENCIAL = dr.GetInt32(dr.GetOrdinal("COD_SECUENCIAL"));
                                ocampoEnt.TIPO_IMPACTO = dr.GetString(dr.GetOrdinal("TIPO_IMPACTO"));
                                ocampoEnt.RIESGO_POTENCIAL = dr.GetString(dr.GetOrdinal("RIESGO_POTENCIAL"));
                                ocampoEnt.ACTIVIDAD = dr.GetString(dr.GetOrdinal("ACTIVIDAD"));
                                ocampoEnt.AVANCE_RESULTADO = dr.GetString(dr.GetOrdinal("AVANCE_RESULTADO"));
                                ocampoEnt.RegEstado = 0;
                                lsCEntidad.ListISUPERVISION_IDENTMANEJOIMPACTO.Add(ocampoEnt);
                            }
                        }
                        #endregion
                        #region "ListISUPERVISION_DET_CAPACITACION_ACTDES"
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidad();
                                ocampoEnt.COD_PROGRAMA = dr.GetInt32(dr.GetOrdinal("COD_PROGRAMA"));
                                ocampoEnt.COD_SECUENCIAL = dr.GetInt32(dr.GetOrdinal("COD_SECUENCIAL"));
                                ocampoEnt.ACTIVIDAD_REALIZADA = dr.GetString(dr.GetOrdinal("ACTIVIDAD_REALIZADA"));
                                ocampoEnt.NUM_PERSONA = dr.GetInt32(dr.GetOrdinal("NUM_PERSONA"));
                                ocampoEnt.OBJETIVO = dr.GetString(dr.GetOrdinal("OBJETIVO"));
                                ocampoEnt.LUGAR_CAPACITACION = dr.GetString(dr.GetOrdinal("LUGAR_CAPACITACION"));
                                ocampoEnt.OBSERVACION = dr.GetString(dr.GetOrdinal("OBSERVACION"));
                                ocampoEnt.RegEstado = 0;
                                lsCEntidad.ListISUPERVISION_DET_CAPACITACION_ACTDES.Add(ocampoEnt);
                            }
                        }
                        #endregion
                        #region "ListOCActosTercero"
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidad();
                                ocampoEnt.COD_OCONTRACTUAL = dr["COD_OCONTRACTUAL"].ToString();
                                ocampoEnt.COD_SECUENCIAL = Int32.Parse(dr["COD_SECUENCIAL"].ToString());
                                ocampoEnt.ACTIVIDAD_ACTOS = dr["ACTIVIDAD_ACTOS"].ToString();
                                ocampoEnt.DOCUMENTOS_AFORESTAL = dr["DOCUMENTOS_AFORESTAL"].ToString();
                                ocampoEnt.RegEstado = 0;
                                lsCEntidad.ListOCActosTercero.Add(ocampoEnt);
                            }
                        }
                        #endregion
                        #region ListDesplazamientoInforme
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidad();
                                ocampoEnt.COD_DESPLAZAMIENTO = dr["COD_DESPLAZAMIENTO"].ToString();
                                ocampoEnt.ZONA = dr["PTOI_ZONA_UTM"].ToString();
                                ocampoEnt.COORDENADA_ESTE = Int32.Parse(dr["PTOI_COORDENADA_ESTE"].ToString());
                                ocampoEnt.COORDENADA_NORTE = Int32.Parse(dr["PTOI_COORDENADA_NORTE"].ToString());
                                ocampoEnt.ZONA_CAMPO = dr["PTOF_ZONA_UTM"].ToString();
                                ocampoEnt.COORDENADA_ESTE_CAMPO = Int32.Parse(dr["PTOF_COORDENADA_ESTE"].ToString());
                                ocampoEnt.COORDENADA_NORTE_CAMPO = Int32.Parse(dr["PTOF_COORDENADA_NORTE"].ToString());
                                ocampoEnt.OBSERVACION = dr["OBSERVACION"].ToString();
                                ocampoEnt.TipoVia = dr["TIPO"].ToString();
                                ocampoEnt.RegEstado = 0;
                                lsCEntidad.ListDesplazamientoInforme.Add(ocampoEnt);
                            }
                        }
                        #endregion
                    }
                }
                return lsCEntidad;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public String RegIFaunaInsertar_v3(OracleConnection cn, CEntidad oCEntidad)
        {
            OracleTransaction tr = null;
            String OUTPUTPARAM01 = "";
            CEntidad ocampoSuper;

            try
            {
                tr = cn.BeginTransaction();
                #region "Datos Generales"
                using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spINFORME_FAUNA_Grabar_v3", oCEntidad))
                {
                    cmd.ExecuteNonQuery();
                    OUTPUTPARAM01 = (String)cmd.Parameters["OUTPUTPARAM01"].Value;
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
                        throw new Exception("El Número de Informe ya Existe");
                    }
                    else if (OUTPUTPARAM01 == "1")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("El Número del Titulo Habilitante Existe en otro Registro");
                    }
                    else if (OUTPUTPARAM01 == "2")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("No Tiene Permisos para Modificar este Informe");
                    }
                    else if (OUTPUTPARAM01 == "3")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("Está con Control de Calidad, no puede modificar");
                    }

                }
                #endregion
                #region "ListEliTABLA"
                if (oCEntidad.ListEliTABLA != null)
                {
                    foreach (var loDatos in oCEntidad.ListEliTABLA)
                    {
                        ocampoSuper = new CEntidad();
                        ocampoSuper.EliTABLA = loDatos.EliTABLA;
                        ocampoSuper.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                        ocampoSuper.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                        ocampoSuper.COD_PROGRAMA = loDatos.COD_PROGRAMA;
                        ocampoSuper.EliVALOR01 = loDatos.EliVALOR01;
                        ocampoSuper.COD_PERSONA = loDatos.COD_PERSONA;
                        ocampoSuper.COD_FISNOTI = loDatos.COD_FISNOTI;
                        dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spINFORME_Eliminar", ocampoSuper);
                    }
                }
                #endregion
                #region "ListPOAs"
                if (oCEntidad.ListPOAs != null)
                {
                    foreach (var loDatos in oCEntidad.ListPOAs)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            ocampoSuper = new CEntidad();
                            ocampoSuper.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            ocampoSuper.NUM_POA = loDatos.NUM_POA;
                            ocampoSuper.PUBLICAR = loDatos.PUBLICAR;
                            ocampoSuper.SUPERVISADO = loDatos.SUPERVISADO;
                            ocampoSuper.CODIGO_SEC_NOPOA = loDatos.CODIGO_SEC_NOPOA;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.ISUPERVISION_INFO_DOCUMENT_Modificar", ocampoSuper);
                        }
                    }
                }
                #endregion
                #region "ListCNotificaciones"
                if (oCEntidad.ListCNotificaciones != null)
                {
                    foreach (var loDatos in oCEntidad.ListCNotificaciones)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            ocampoSuper = new CEntidad();
                            ocampoSuper.COD_CNOTIFICACION = loDatos.COD_CNOTIFICACION;
                            //ocampoSuper.COD_FISNOTI = loDatos.COD_FISNOTI;
                            ocampoSuper.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            ocampoSuper.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spINFORME_DET_CNOTIFICACIONES_Grabar", ocampoSuper);
                            //dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spINFORME_DET_NOTIFICACION_Grabar_v3", ocampoSuper);
                        }
                    }
                }
                #endregion
                #region "ListInformeDetSupervisor"
                if (oCEntidad.ListInformeDetSupervisor != null)
                {
                    CEntPersona ocampoPer;
                    foreach (var loDatos in oCEntidad.ListInformeDetSupervisor)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            ocampoPer = new CEntPersona();
                            ocampoPer.COD_PERSONA = loDatos.COD_PERSONA;
                            ocampoPer.CODIGO = OUTPUTPARAM01.Split('|')[0];
                            ocampoPer.RegEstado = 0;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.INFORME_DET_SUPERVISOR_GrabarV3", ocampoPer);
                        }
                    }
                }
                #endregion
                #region "ListPrograma"
                if (oCEntidad.ListPrograma != null)
                {
                    foreach (var loDatos in oCEntidad.ListPrograma)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            ocampoSuper = new CEntidad();
                            ocampoSuper.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            ocampoSuper.COD_PROGRAMA = loDatos.COD_PROGRAMA;
                            ocampoSuper.ESTADO_PROGRAMA = loDatos.ESTADO_PROGRAMA;
                            ocampoSuper.OBSERVACION = loDatos.OBSERVACION;
                            ocampoSuper.TIPO = loDatos.TIPO;
                            ocampoSuper.FRECUENCIA = loDatos.FRECUENCIA;
                            ocampoSuper.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.ISUPERVISION_DET_PROGRAMA_Grabar", ocampoSuper);
                        }
                    }
                }
                #endregion
                #region "ListISUPERVISION_IDENTMANEJOIMPACTO"
                if (oCEntidad.ListISUPERVISION_IDENTMANEJOIMPACTO != null)
                {
                    foreach (var loDatos in oCEntidad.ListISUPERVISION_IDENTMANEJOIMPACTO)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            ocampoSuper = new CEntidad();
                            ocampoSuper.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            ocampoSuper.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            ocampoSuper.TIPO_IMPACTO = loDatos.TIPO_IMPACTO;
                            ocampoSuper.RIESGO_POTENCIAL = loDatos.RIESGO_POTENCIAL;
                            ocampoSuper.ACTIVIDAD = loDatos.ACTIVIDAD;
                            ocampoSuper.AVANCE_RESULTADO = loDatos.AVANCE_RESULTADO;
                            ocampoSuper.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.ISUPERVISION_DET_CONSERV_IDENTMANIMPACT_Grabar", ocampoSuper);
                        }
                    }
                }
                #endregion
                #region "ListISUPERVISION_DET_CAPACITACION_ACTDES"
                if (oCEntidad.ListISUPERVISION_DET_CAPACITACION_ACTDES != null)
                {
                    foreach (var loDatos in oCEntidad.ListISUPERVISION_DET_CAPACITACION_ACTDES)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            ocampoSuper = new CEntidad();
                            ocampoSuper.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            ocampoSuper.COD_PROGRAMA = loDatos.COD_PROGRAMA;
                            ocampoSuper.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            ocampoSuper.ACTIVIDAD_REALIZADA = loDatos.ACTIVIDAD_REALIZADA;
                            ocampoSuper.NUM_PERSONA = loDatos.NUM_PERSONA;
                            ocampoSuper.OBJETIVO = loDatos.OBJETIVO;
                            ocampoSuper.LUGAR_CAPACITACION = loDatos.LUGAR_CAPACITACION;
                            ocampoSuper.OBSERVACION = loDatos.OBSERVACION;
                            ocampoSuper.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.ISUPERVISION_DET_CONSERV_PROG_Grabar", ocampoSuper);
                        }
                    }
                }
                #endregion
                #region "ListOCActosTercero"
                if (oCEntidad.ListOCActosTercero != null)
                {
                    foreach (var loDatos in oCEntidad.ListOCActosTercero)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            ocampoSuper = new CEntidad();
                            ocampoSuper.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            ocampoSuper.COD_OCONTRACTUAL = loDatos.COD_OCONTRACTUAL;
                            ocampoSuper.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            ocampoSuper.ACTIVIDAD_ACTOS = loDatos.ACTIVIDAD_ACTOS;
                            ocampoSuper.DOCUMENTOS_AFORESTAL = loDatos.DOCUMENTOS_AFORESTAL;
                            ocampoSuper.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spISUPERVISION_DET_OCONTRACTUALGrabar", ocampoSuper);
                        }
                    }
                }
                #endregion
                #region "ListDesplazamientoInforme"
                if (oCEntidad.ListDesplazamientoInforme != null)
                {
                    foreach (var loDatos in oCEntidad.ListDesplazamientoInforme)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            ocampoSuper = new CEntidad();
                            ocampoSuper.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            ocampoSuper.COD_DESPLAZAMIENTO = loDatos.COD_DESPLAZAMIENTO;
                            ocampoSuper.ZONA = loDatos.ZONA;
                            ocampoSuper.PTOI_COORDENADA_ESTE = loDatos.COORDENADA_ESTE;
                            ocampoSuper.PTOI_COORDENADA_NORTE = loDatos.COORDENADA_NORTE;
                            ocampoSuper.ZONA_CAMPO = loDatos.ZONA_CAMPO;
                            ocampoSuper.PTOF_COORDENADA_ESTE = loDatos.COORDENADA_ESTE_CAMPO;
                            ocampoSuper.PTOF_COORDENADA_NORTE = loDatos.COORDENADA_NORTE_CAMPO;
                            ocampoSuper.OBSERVACION = loDatos.OBSERVACION;
                            ocampoSuper.TIPO = loDatos.TipoVia;
                            ocampoSuper.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spINFORME_DESPLAZAMIENTOGrabar", ocampoSuper);
                        }
                    }
                }
                #endregion
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

        public CEntidad RegMostrarPOAFaunaSupervisado(CEntidad oCEntidad)
        {
            CEntidad lsCEntidad = new CEntidad();
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spISUPERVISION_POA_FAUNAMostrarItem", oCEntidad))
                    {
                        if (dr != null)
                        {
                            lsCEntidad.ListAvistamientoFauna = new List<CEntidad>();
                            lsCEntidad.ListVertice = new List<CapaEntidad.DOC.Ent_INFORME_VERTICE>();
                            lsCEntidad.ListISUPERVISION_INFRAESTRUCTURA = new List<CEntidad>();
                            lsCEntidad.ListISUPERVISION_DET_ZONIFICACION = new List<CEntidad>();
                            lsCEntidad.ListISupervFaunaAprov = new List<CEntidad>();
                            CEntidad ocampoEnt;

                            #region "Datos Generales"
                            if (dr.HasRows)
                            {
                                dr.Read();
                                lsCEntidad.COD_INFORME = dr.GetString(dr.GetOrdinal("COD_INFORME"));
                                lsCEntidad.NUM_POA = dr.GetInt32(dr.GetOrdinal("NUM_POA"));
                                lsCEntidad.POA = dr.GetString(dr.GetOrdinal("POA"));
                            }
                            #endregion
                            #region ListAvistamientoFauna
                            dr.NextResult();
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    ocampoEnt = new CEntidad();
                                    ocampoEnt.COD_ESPECIES = dr["COD_ESPECIES"].ToString();
                                    ocampoEnt.DESC_ESPECIES = dr["DESC_ESPECIES"].ToString();
                                    ocampoEnt.COD_SECUENCIAL = Int32.Parse(dr["COD_SECUENCIAL"].ToString());
                                    ocampoEnt.NOMBRE_COMUN = dr["NOMBRE_COMUN"].ToString();
                                    ocampoEnt.NUM_INDIVIDUOS = Int32.Parse(dr["NUM_INDIVIDUOS"].ToString());
                                    ocampoEnt.COD_TIPO_REGISTRO = dr["COD_TIPO_REGISTRO"].ToString();
                                    ocampoEnt.DESC_TIPO_REGISTRO = dr["DESC_TIPO_REGISTRO"].ToString();
                                    ocampoEnt.COD_ESTRATO = dr["COD_ESTRATO"].ToString();
                                    ocampoEnt.DESC_ESTRATO = dr["DESC_ESTRATO"].ToString();
                                    ocampoEnt.FECHA_AVISTAMIENTO = dr["FECHA_AVISTAMIENTO"].ToString();
                                    ocampoEnt.HORA_AVISTAMIENTO = dr["HORA_AVISTAMIENTO"].ToString();
                                    ocampoEnt.ZONA = dr["ZONA"].ToString();
                                    ocampoEnt.COORDENADA_ESTE = Int32.Parse(dr["COORDENADA_ESTE"].ToString());
                                    ocampoEnt.COORDENADA_NORTE = Int32.Parse(dr["COORDENADA_NORTE"].ToString());
                                    ocampoEnt.ALTITUD = Decimal.Parse(dr["ALTITUD"].ToString());
                                    ocampoEnt.DESCRIPCION = dr["DESCRIPCION"].ToString();
                                    ocampoEnt.NUM_POA = Int32.Parse(dr["NUM_POA"].ToString());
                                    ocampoEnt.RegEstado = 0;
                                    lsCEntidad.ListAvistamientoFauna.Add(ocampoEnt);
                                }
                            }
                            #endregion
                            #region "ListVertice"
                            dr.NextResult();
                            if (dr.HasRows)
                            {
                                CapaEntidad.DOC.Ent_INFORME_VERTICE ocampoVer;
                                while (dr.Read())
                                {
                                    ocampoVer = new CapaEntidad.DOC.Ent_INFORME_VERTICE();
                                    ocampoVer.COD_SECUENCIAL = dr.GetInt32(dr.GetOrdinal("COD_SECUENCIAL"));
                                    ocampoVer.VERTICE = dr.GetString(dr.GetOrdinal("VERTICE"));
                                    ocampoVer.COORDENADA_NORTE = dr.GetInt32(dr.GetOrdinal("COORDENADA_NORTE"));
                                    ocampoVer.COORDENADA_ESTE = dr.GetInt32(dr.GetOrdinal("COORDENADA_ESTE"));
                                    ocampoVer.COORDENADA_NORTE_CAMPO = dr.GetInt32(dr.GetOrdinal("COORDENADA_NORTE_CAMPO"));
                                    ocampoVer.COORDENADA_ESTE_CAMPO = dr.GetInt32(dr.GetOrdinal("COORDENADA_SUR_CAMPO"));
                                    ocampoVer.ZONA = dr.GetString(dr.GetOrdinal("ZONA"));
                                    ocampoVer.ZONA_CAMPO = dr.GetString(dr.GetOrdinal("ZONA_CAMPO"));
                                    ocampoVer.NUM_POA = dr.GetInt32(dr.GetOrdinal("NUM_POA"));
                                    ocampoVer.RegEstado = 0;
                                    lsCEntidad.ListVertice.Add(ocampoVer);
                                }
                            }
                            #endregion
                            #region "ListISUPERVISION_INFRAESTRUCTURA"
                            dr.NextResult();
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    ocampoEnt = new CEntidad();
                                    ocampoEnt.COD_SECUENCIAL = dr.GetInt32(dr.GetOrdinal("COD_SECUENCIAL"));
                                    ocampoEnt.DESCRIPCION = dr.GetString(dr.GetOrdinal("TIPO_AMBIENTE"));
                                    ocampoEnt.AREA = dr.GetDecimal(dr.GetOrdinal("AREA"));
                                    ocampoEnt.USO = dr.GetString(dr.GetOrdinal("USO"));
                                    ocampoEnt.ESTADO_CONSERVACION = dr.GetString(dr.GetOrdinal("ESTADO_CONSERVACION"));
                                    ocampoEnt.OBJETIVO = dr.GetString(dr.GetOrdinal("OBJETIVO"));
                                    ocampoEnt.NUM_POA = dr.GetInt32(dr.GetOrdinal("NUM_POA"));
                                    ocampoEnt.RegEstado = 0;
                                    lsCEntidad.ListISUPERVISION_INFRAESTRUCTURA.Add(ocampoEnt);
                                }
                            }
                            #endregion
                            #region "ListISUPERVISION_DET_ZONIFICACION"
                            dr.NextResult();
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    ocampoEnt = new CEntidad();
                                    ocampoEnt.COD_SECUENCIAL = dr.GetInt32(dr.GetOrdinal("COD_SECUENCIAL"));
                                    ocampoEnt.NOMBRE_ZONA = dr.GetString(dr.GetOrdinal("NOMBRE_ZONA"));
                                    ocampoEnt.CARACTERISTICA = dr.GetString(dr.GetOrdinal("CARACTERISTICA"));
                                    ocampoEnt.COORDENADA_NORTE = dr.GetInt32(dr.GetOrdinal("COORDENADA_NORTE"));
                                    ocampoEnt.COORDENADA_ESTE = dr.GetInt32(dr.GetOrdinal("COORDENADA_ESTE"));
                                    ocampoEnt.TIPO_SENALIZACION = dr.GetString(dr.GetOrdinal("TIPO_SENALIZACION"));
                                    ocampoEnt.TIPO_DELIMITACION = dr.GetString(dr.GetOrdinal("TIPO_DELIMITACION"));
                                    ocampoEnt.NUM_POA = dr.GetInt32(dr.GetOrdinal("NUM_POA"));
                                    ocampoEnt.ZONA = dr.GetString(dr.GetOrdinal("ZONA"));
                                    ocampoEnt.RegEstado = 0;
                                    lsCEntidad.ListISUPERVISION_DET_ZONIFICACION.Add(ocampoEnt);
                                }
                            }
                            #endregion
                            #region "ListISupervFaunaAprov"
                            dr.NextResult();
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    ocampoEnt = new CEntidad();
                                    ocampoEnt.NUM_POA = dr.GetInt32(dr.GetOrdinal("NUM_POA"));
                                    ocampoEnt.COD_ESPECIES = dr.GetString(dr.GetOrdinal("COD_ESPECIES"));
                                    ocampoEnt.PERIODO = dr.GetString(dr.GetOrdinal("PERIODO"));
                                    ocampoEnt.CUOTA_SACA = dr.GetInt32(dr.GetOrdinal("CUOTA_SACA"));
                                    ocampoEnt.PERSONAL = dr.GetString(dr.GetOrdinal("PERSONAL"));
                                    ocampoEnt.METODO_CAZA = dr.GetString(dr.GetOrdinal("METODO_CAZA"));
                                    ocampoEnt.SISTEMA_MARCAJE = dr.GetString(dr.GetOrdinal("SISTEMA_MARCAJE"));
                                    ocampoEnt.APROVECHAR = dr.GetString(dr.GetOrdinal("APROVECHAR"));
                                    ocampoEnt.DESC_ESPECIES = dr.GetString(dr.GetOrdinal("DESC_ESPECIE"));
                                    ocampoEnt.RegEstado = 0;
                                    lsCEntidad.ListISupervFaunaAprov.Add(ocampoEnt);
                                }
                            }
                            #endregion
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
        public String RegInsertarPOAFaunaSupervisado(OracleConnection cn, CEntidad oCEntidad)
        {
            OracleTransaction tr = null;
            String OUTPUTPARAM01 = "";

            try
            {
                tr = cn.BeginTransaction();
                CEntidad ocampo;

                #region ListEliTABLA
                if (oCEntidad.ListEliTABLA != null)
                {
                    foreach (var loDatos in oCEntidad.ListEliTABLA)
                    {
                        ocampo = new CEntidad();
                        ocampo.EliTABLA = loDatos.EliTABLA;
                        ocampo.COD_INFORME = oCEntidad.COD_INFORME;
                        ocampo.NUM_POA = oCEntidad.NUM_POA;
                        ocampo.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                        ocampo.COD_ESPECIES = loDatos.COD_ESPECIES;
                        dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spINFORME_Eliminar", ocampo);
                    }
                }
                #endregion
                #region ListAvistamientoFauna
                if (oCEntidad.ListAvistamientoFauna != null)
                {
                    foreach (var loDatos in oCEntidad.ListAvistamientoFauna)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            ocampo = new CEntidad();
                            ocampo.COD_INFORME = oCEntidad.COD_INFORME;
                            ocampo.COD_ESPECIES = loDatos.COD_ESPECIES;
                            ocampo.DESC_ESPECIES = loDatos.DESC_ESPECIES;
                            ocampo.NOMBRE_COMUN = loDatos.NOMBRE_COMUN;
                            ocampo.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            ocampo.NUM_INDIVIDUOS = loDatos.NUM_INDIVIDUOS;
                            ocampo.COD_TIPO_REGISTRO = loDatos.COD_TIPO_REGISTRO;
                            ocampo.DESC_TIPO_REGISTRO = loDatos.DESC_TIPO_REGISTRO;
                            ocampo.COD_ESTRATO = loDatos.COD_ESTRATO;
                            ocampo.DESC_ESTRATO = loDatos.DESC_ESTRATO;
                            ocampo.FECHA_AVISTAMIENTO = loDatos.FECHA_AVISTAMIENTO;
                            ocampo.HORA_AVISTAMIENTO = loDatos.HORA_AVISTAMIENTO;
                            ocampo.ZONA = loDatos.ZONA;
                            ocampo.COORDENADA_NORTE = loDatos.COORDENADA_NORTE;
                            ocampo.COORDENADA_ESTE = loDatos.COORDENADA_ESTE;
                            ocampo.ALTITUD = loDatos.ALTITUD;
                            ocampo.DESCRIPCION = loDatos.DESCRIPCION;
                            ocampo.NUM_POA = oCEntidad.NUM_POA;
                            ocampo.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.ISUPERVISION_MADE_NOMADE_DET_AVISTAMIENTO_FAUNA_Grabar", ocampo);
                        }
                    }
                }
                #endregion
                #region "ListVertice"
                if (oCEntidad.ListVertice != null)
                {
                    foreach (var loDatos in oCEntidad.ListVertice)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            ocampo = new CEntidad();
                            ocampo.COD_INFORME = oCEntidad.COD_INFORME;
                            ocampo.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            ocampo.VERTICE = loDatos.VERTICE;
                            ocampo.COORDENADA_NORTE = loDatos.COORDENADA_NORTE;
                            ocampo.COORDENADA_ESTE = loDatos.COORDENADA_ESTE;
                            ocampo.COORDENADA_NORTE_CAMPO = loDatos.COORDENADA_NORTE_CAMPO;
                            ocampo.COORDENADA_SUR_CAMPO = loDatos.COORDENADA_ESTE_CAMPO;
                            ocampo.ZONA = loDatos.ZONA;
                            ocampo.ZONA_CAMPO = loDatos.ZONA_CAMPO;
                            ocampo.NUM_POA = oCEntidad.NUM_POA;
                            ocampo.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.ISUPERVISION_DET_COORDENADAUTM_Grabar", ocampo);
                        }
                    }
                }
                #endregion
                #region "ListISUPERVISION_INFRAESTRUCTURA"
                if (oCEntidad.ListISUPERVISION_INFRAESTRUCTURA != null)
                {
                    foreach (var loDatos in oCEntidad.ListISUPERVISION_INFRAESTRUCTURA)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            ocampo = new CEntidad();
                            ocampo.COD_INFORME = oCEntidad.COD_INFORME;
                            ocampo.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            ocampo.TIPO_AMBIENTE = loDatos.DESCRIPCION;
                            ocampo.AREA = loDatos.AREA;
                            ocampo.USO = loDatos.USO;
                            ocampo.ESTADO_CONSERVACION = loDatos.ESTADO_CONSERVACION;
                            ocampo.OBJETIVO = loDatos.OBJETIVO;
                            ocampo.NUM_POA = oCEntidad.NUM_POA;
                            ocampo.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.ISUPERVISION_DET_CONSERV_INFRA_Grabar", ocampo);
                        }
                    }
                }
                #endregion
                #region "ListISUPERVISION_DET_ZONIFICACION"
                if (oCEntidad.ListISUPERVISION_DET_ZONIFICACION != null)
                {
                    foreach (var loDatos in oCEntidad.ListISUPERVISION_DET_ZONIFICACION)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            ocampo = new CEntidad();
                            ocampo.COD_INFORME = oCEntidad.COD_INFORME;
                            ocampo.NOMBRE_ZONA = loDatos.NOMBRE_ZONA;
                            ocampo.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            ocampo.CARACTERISTICA = loDatos.CARACTERISTICA;
                            ocampo.COORDENADA_NORTE = loDatos.COORDENADA_NORTE;
                            ocampo.COORDENADA_ESTE = loDatos.COORDENADA_ESTE;
                            ocampo.TIPO_SENALIZACION = loDatos.TIPO_SENALIZACION;
                            ocampo.TIPO_DELIMITACION = loDatos.TIPO_DELIMITACION;
                            ocampo.NUM_POA = oCEntidad.NUM_POA;
                            ocampo.ZONA = loDatos.ZONA;
                            ocampo.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.ISUPERVISION_DET_CONSERV_ZONIFICACION_Grabar", ocampo);
                        }
                    }
                }
                #endregion
                #region "ListISupervFaunaAprov"
                if (oCEntidad.ListISupervFaunaAprov != null)
                {
                    foreach (var loDatos in oCEntidad.ListISupervFaunaAprov)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            ocampo = new CEntidad();
                            ocampo.COD_INFORME = oCEntidad.COD_INFORME;
                            ocampo.NUM_POA = oCEntidad.NUM_POA;
                            ocampo.COD_ESPECIES = loDatos.COD_ESPECIES;
                            ocampo.PERIODO = loDatos.PERIODO;
                            ocampo.CUOTA_SACA = loDatos.CUOTA_SACA;
                            ocampo.PERSONAL = loDatos.PERSONAL;
                            ocampo.METODO_CAZA = loDatos.METODO_CAZA;
                            ocampo.SISTEMA_MARCAJE = loDatos.SISTEMA_MARCAJE;
                            ocampo.APROVECHAR = loDatos.APROVECHAR;
                            ocampo.COD_UCUENTA = oCEntidad.COD_UCUENTA;
                            ocampo.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spISUPERVISION_DET_FAUNA_APROVGrabar", ocampo);
                        }
                    }
                }
                #endregion
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

        public CEntidad RegITaraMostrarListaItem_v3(OracleConnection cn, String codInforme)
        {
            CEntidad lsCEntidad = new CEntidad();
            try
            {
                object[] param = { codInforme };
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, "DOC_OSINFOR_ERP_MIGRACION.spINFORME_TARAMostrarItem_v3", param))
                {
                    if (dr != null)
                    {
                        lsCEntidad.ListInformeDetSupervisor = new List<CEntPersona>();
                        lsCEntidad.ListTaraConcepto = new List<CapaEntidad.DOC.Ent_INFORME_TCONCEPTO>();
                        lsCEntidad.ListTaraManPlantacion = new List<CapaEntidad.DOC.Ent_INFORME_TCONCEPTO>();
                        lsCEntidad.ListISUPERVISION_DET_TARA_APROV = new List<CEntidad>();
                        lsCEntidad.ListISUPERVISION_DET_TARA_CAPACITACION = new List<CEntidad>();
                        lsCEntidad.ListISUPERVISION_DET_TARA_PFRUTOS = new List<CEntidad>();
                        lsCEntidad.ListISUPERVISION_DET_TARA_APFORESTAL = new List<CEntidad>();
                        lsCEntidad.ListTaraCenso = new List<CapaEntidad.DOC.Ent_INFORME_TCENSO>();
                        lsCEntidad.ListISUPERVISION_DET_TARA_KARDEX = new List<CEntidad>();
                        lsCEntidad.ListObligacionTitular = new List<CapaEntidad.DOC.Ent_INFORME_OBLIGTITULAR>();
                        lsCEntidad.ListDesplazamientoInforme = new List<CEntidad>();
                        CEntidad ocampoEnt;

                        #region "Datos Generales"
                        if (dr.HasRows)
                        {
                            dr.Read();
                            //Control de calidad
                            lsCEntidad.COD_ESTADO_DOC = dr.GetString(dr.GetOrdinal("COD_ESTADO_DOC"));
                            lsCEntidad.OBSERVACIONES_CONTROL = dr.GetString(dr.GetOrdinal("OBSERVACIONES_CONTROL"));
                            lsCEntidad.OBSERV_SUBSANAR = dr.GetBoolean(dr.GetOrdinal("OBSERV_SUBSANAR"));
                            lsCEntidad.USUARIO_REGISTRO = dr.GetString(dr.GetOrdinal("USUARIO_REGISTRO"));
                            lsCEntidad.USUARIO_CONTROL = dr.GetString(dr.GetOrdinal("USUARIO_CONTROL"));
                            //Datos informe
                            lsCEntidad.COD_OD_REGISTRO = dr.GetString(dr.GetOrdinal("COD_OD_REGISTRO"));
                            lsCEntidad.NUMERO = dr.GetString(dr.GetOrdinal("NUMERO"));
                            lsCEntidad.FECHA_ENTREGA = dr.GetString(dr.GetOrdinal("FECHA_ENTREGA"));
                            lsCEntidad.COD_DIRECTOR = dr.GetString(dr.GetOrdinal("COD_DIRECTOR"));
                            lsCEntidad.NOMBRE_DIRECTOR = dr.GetString(dr.GetOrdinal("APELLIDOS_NOMBRES"));
                            lsCEntidad.FECHA_EMISION = dr.GetString(dr.GetOrdinal("FECHA_EMISION_DLINEA"));
                            //Datos supervisión
                            lsCEntidad.FECHA_SUPERVISION_INICIO = dr.GetString(dr.GetOrdinal("FECHA_SUPERVISION_INICIO"));
                            lsCEntidad.FECHA_SUPERVISION_FIN = dr.GetString(dr.GetOrdinal("FECHA_SUPERVISION_FIN"));
                            lsCEntidad.COD_IMOTIVO = dr.GetString(dr.GetOrdinal("COD_IMOTIVO"));
                            lsCEntidad.IMOTIVO = dr.GetString(dr.GetOrdinal("IMOTIVO"));
                            lsCEntidad.MAE_TIP_MOTMOTIVADA = dr.GetString(dr.GetOrdinal("MAE_TIP_MOTMOTIVADA"));
                            lsCEntidad.COD_TRAMITE_SITD = dr.GetInt32(dr.GetOrdinal("COD_TRAMITE_SITD"));
                            //lsCEntidad.NUM_DREFERENCIA = dr.GetString(dr.GetOrdinal("NUM_DREFERENCIA"));
                            lsCEntidad.GEOTEC_DESCRIPCION = dr.GetString(dr.GetOrdinal("GEOTEC_DESCRIPCION"));
                            lsCEntidad.GEOTEC_DRON = dr.GetBoolean(dr.GetOrdinal("GEOTEC_DRON"));
                            lsCEntidad.GEOTEC_GEOSUPERVISOR = dr.GetBoolean(dr.GetOrdinal("GEOTEC_GEOSUPERVISOR"));
                            lsCEntidad.GEOTEC_NINGUNO = dr.GetBoolean(dr.GetOrdinal("GEOTEC_NINGUNO"));
                            lsCEntidad.GEOTEC_OTROS = dr.GetBoolean(dr.GetOrdinal("GEOTEC_OTROS"));
                            lsCEntidad.THABILITANTE_COD_UBIGEO = dr.GetString(dr.GetOrdinal("THABILITANTE_COD_UBIGEO"));
                            lsCEntidad.UBIGEO = dr.GetString(dr.GetOrdinal("UBIGEO"));
                            lsCEntidad.THABILITANTE_SECTOR = dr.GetString(dr.GetOrdinal("THABILITANTE_SECTOR"));
                            //
                            lsCEntidad.MAPAS_CINFORMACION = dr.GetString(dr.GetOrdinal("MAPAS_CINFORMACION"));
                            lsCEntidad.ESTADO_MAPAS_CINFORMACION = dr.GetBoolean(dr.GetOrdinal("ESTADO_MAPAS_CINFORMACION"));
                            lsCEntidad.ESTAB_AREA_MANEJO = dr.GetString(dr.GetOrdinal("ESTAB_AREA_MANEJO"));
                            lsCEntidad.ESTAB_PLANTACION = dr.GetString(dr.GetOrdinal("ESTAB_PLANTACION"));
                            lsCEntidad.EXISTEN_FOREST_REFOREST = dr.GetBoolean(dr.GetOrdinal("EXISTEN_FOREST_REFOREST"));
                            lsCEntidad.OBSERV_FOREST_REFOREST = dr.GetString(dr.GetOrdinal("OBSERV_FOREST_REFOREST"));
                            lsCEntidad.COD_PPLANTON = dr.GetInt32(dr.GetOrdinal("COD_PPLANTON"));
                            lsCEntidad.OBSERV_PROD_PLANTONES = dr.GetString(dr.GetOrdinal("OBSERV_PROD_PLANTONES"));
                            lsCEntidad.COMERCIALIZACION = dr.GetString(dr.GetOrdinal("COMERCIALIZACION"));
                            lsCEntidad.ANALISIS_RACERVO = dr.GetString(dr.GetOrdinal("ANALISIS_RACERVO"));
                            //Adicionales 08/08/2019 CLHC
                            lsCEntidad.OBSERVACION = dr.GetString(dr.GetOrdinal("OBSERVACION"));
                            lsCEntidad.CONCLUSION = dr.GetString(dr.GetOrdinal("CONCLUSION"));
                            lsCEntidad.COD_TIPO_SUPER = dr.GetString(dr.GetOrdinal("COD_TIPO_SUPER"));
                            lsCEntidad.TIPO_INFORME = dr.GetString(dr.GetOrdinal("TIPO_INFORME"));
                            lsCEntidad.BUEN_DESEMPENIO = dr.GetInt32(dr.GetOrdinal("BUEN_DESEMPENIO"));
                            lsCEntidad.ARCHIVA_INFORME = (!dr.IsDBNull(dr.GetOrdinal("ARCHIVA_INFORME"))) ? dr.GetInt32(dr.GetOrdinal("ARCHIVA_INFORME")) : -1;
                        }
                        #endregion
                        #region ListInformeDetSupervisor
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            CEntPersona oPer;
                            while (dr.Read())
                            {
                                oPer = new CEntPersona();
                                oPer.COD_PERSONA = dr["COD_PERSONA"].ToString();
                                oPer.NOMBRES = dr["APELLIDOS_NOMBRES"].ToString();
                                oPer.ESTADO_FIRMA = dr["ESTADO_FIRMA"].ToString();
                                oPer.FLAG_FIRMA =Convert.ToInt32(dr["FLAG_FIRMA"]);
                                oPer.RegEstado = 0;
                                lsCEntidad.ListInformeDetSupervisor.Add(oPer);
                            }
                        }
                        #endregion
                        #region "ListTaraConcepto"
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            CapaEntidad.DOC.Ent_INFORME_TCONCEPTO oTConcepto;
                            while (dr.Read())
                            {
                                oTConcepto = new CapaEntidad.DOC.Ent_INFORME_TCONCEPTO();
                                oTConcepto.COD_TCONCEPTO = dr.GetInt32(dr.GetOrdinal("COD_TCONCEPTO"));
                                oTConcepto.DESCRIPCION = dr.GetString(dr.GetOrdinal("DESCRIPCION"));
                                oTConcepto.ESTADO_MPLANTACION = dr.GetBoolean(dr.GetOrdinal("ESTADO_MPLANTACION"));
                                oTConcepto.OBSERVACION = dr.GetString(dr.GetOrdinal("OBSERVACION"));
                                oTConcepto.TIPO = dr.GetString(dr.GetOrdinal("TIPO"));
                                lsCEntidad.ListTaraConcepto.Add(oTConcepto);
                            }
                        }
                        #endregion
                        #region "ListTaraManPlantacion"
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            CapaEntidad.DOC.Ent_INFORME_TCONCEPTO oTManPlanta;
                            while (dr.Read())
                            {
                                oTManPlanta = new CapaEntidad.DOC.Ent_INFORME_TCONCEPTO();
                                oTManPlanta.COD_TCONCEPTO = dr.GetInt32(dr.GetOrdinal("COD_TCONCEPTO"));
                                oTManPlanta.DESCRIPCION = dr.GetString(dr.GetOrdinal("DESCRIPCION"));
                                oTManPlanta.ESTADO_MPLANTACION = dr.GetInt16(dr.GetOrdinal("ESTADO_MPLANTACION")) == 1;
                                oTManPlanta.OBSERVACION = Convert.ToString(dr["OBSERVACION"]); //.GetString(dr.GetOrdinal("OBSERVACION"));
                                oTManPlanta.RegEstado = 0;
                                lsCEntidad.ListTaraManPlantacion.Add(oTManPlanta);
                            }
                        }
                        #endregion
                        #region "ListISUPERVISION_DET_TARA_APROV"
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidad();
                                ocampoEnt.COD_SECUENCIAL = dr.GetInt32(dr.GetOrdinal("COD_SECUENCIAL"));
                                ocampoEnt.PREDIO_AREA = dr.GetDecimal(dr.GetOrdinal("PREDIO_AREA"));
                                ocampoEnt.N_ARBOL_SUPERVISADO = dr.GetInt32(dr.GetOrdinal("N_ARBOL_SUPERVISADO"));
                                ocampoEnt.N_ARBOL_FVERDE = dr.GetInt32(dr.GetOrdinal("N_ARBOL_FVERDE"));
                                ocampoEnt.N_ARBOL_FVERDE_MADURO = dr.GetInt32(dr.GetOrdinal("N_ARBOL_FVERDE_MADURO"));
                                ocampoEnt.N_ARBOL_FLOR = dr.GetInt32(dr.GetOrdinal("N_ARBOL_FLOR"));
                                ocampoEnt.N_ARBOL_NOFRUTO = dr.GetInt32(dr.GetOrdinal("N_ARBOL_NOFRUTO"));
                                ocampoEnt.OBSERVACION = dr.GetString(dr.GetOrdinal("OBSERVACION"));
                                ocampoEnt.RegEstado = 0;
                                lsCEntidad.ListISUPERVISION_DET_TARA_APROV.Add(ocampoEnt);
                            }
                        }
                        #endregion
                        #region "ListISUPERVISION_DET_TARA_CAPACITACION"
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidad();
                                ocampoEnt.COD_SECUENCIAL = dr.GetInt32(dr.GetOrdinal("COD_SECUENCIAL"));
                                ocampoEnt.NOMBRES = dr.GetString(dr.GetOrdinal("NOMBRES"));
                                ocampoEnt.NUM_PERSONA = dr.GetInt32(dr.GetOrdinal("NUM_PERSONA"));
                                ocampoEnt.DESCRIPCION = dr.GetString(dr.GetOrdinal("DESCRIPCION"));
                                ocampoEnt.RegEstado = 0;
                                lsCEntidad.ListISUPERVISION_DET_TARA_CAPACITACION.Add(ocampoEnt);
                            }
                        }
                        #endregion
                        #region "ListISUPERVISION_DET_TARA_PFRUTOS"
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidad();
                                ocampoEnt.COD_SECUENCIAL = dr.GetInt32(dr.GetOrdinal("COD_SECUENCIAL"));
                                ocampoEnt.PREDIO_AREA = dr.GetDecimal(dr.GetOrdinal("PREDIO_AREA"));
                                ocampoEnt.PRIMERA_COSECHA = dr.GetDecimal(dr.GetOrdinal("PRIMERA_COSECHA"));
                                ocampoEnt.SEGUNDA_COSECHA = dr.GetDecimal(dr.GetOrdinal("SEGUNDA_COSECHA"));
                                ocampoEnt.TOTAL_PROD_ANUAL = dr.GetDecimal(dr.GetOrdinal("TOTAL_PROD_ANUAL"));
                                ocampoEnt.RegEstado = 0;
                                lsCEntidad.ListISUPERVISION_DET_TARA_PFRUTOS.Add(ocampoEnt);
                            }
                        }
                        #endregion
                        #region "ListISUPERVISION_DET_TARA_APFORESTAL"
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidad();
                                ocampoEnt.COD_SECUENCIAL = dr.GetInt32(dr.GetOrdinal("COD_SECUENCIAL"));
                                ocampoEnt.PREDIO_AREA = dr.GetDecimal(dr.GetOrdinal("PREDIO_AREA"));
                                ocampoEnt.ZAFRA = dr.GetString(dr.GetOrdinal("ZAFRA"));
                                ocampoEnt.P_ARBOL_PRODUCTIVO = dr.GetDecimal(dr.GetOrdinal("P_ARBOL_PRODUCTIVO"));
                                ocampoEnt.P_ARBOL_NOPRODUCTIVO = dr.GetDecimal(dr.GetOrdinal("P_ARBOL_NOPRODUCTIVO"));
                                ocampoEnt.P_ARBOL_PLANTADO = dr.GetDecimal(dr.GetOrdinal("P_ARBOL_PLANTADO"));
                                ocampoEnt.CANTIDAD_AEXTRAER = dr.GetDecimal(dr.GetOrdinal("CANTIDAD_AEXTRAER"));
                                ocampoEnt.CANTIDAD_EXTRAIDA = dr.GetDecimal(dr.GetOrdinal("CANTIDAD_EXTRAIDA"));
                                ocampoEnt.N_ARBOL_SUPERVISADO = dr.GetInt32(dr.GetOrdinal("N_ARBOL_SUPERVISADO"));
                                ocampoEnt.CANTIDAD_SUPERVISADO = dr.GetDecimal(dr.GetOrdinal("CANTIDAD_SUPERVISADO"));
                                ocampoEnt.CANTIDAD_INJUSTIFICADA = dr.GetDecimal(dr.GetOrdinal("CANTIDAD_INJUSTIFICADA"));
                                ocampoEnt.RegEstado = 0;
                                lsCEntidad.ListISUPERVISION_DET_TARA_APFORESTAL.Add(ocampoEnt);
                            }
                        }
                        #endregion
                        #region "ListTaraCenso"
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            CapaEntidad.DOC.Ent_INFORME_TCENSO oTCenso;
                            while (dr.Read())
                            {
                                oTCenso = new CapaEntidad.DOC.Ent_INFORME_TCENSO();
                                oTCenso.COD_SECUENCIAL = dr.GetInt32(dr.GetOrdinal("COD_SECUENCIAL"));
                                oTCenso.PREDIO_AREA = dr.GetDecimal(dr.GetOrdinal("PREDIO_AREA"));
                                oTCenso.CODIGO_ARBOL = dr.GetString(dr.GetOrdinal("CODIGO_ARBOL"));
                                oTCenso.VAINAS_COD_PRESENCIA = dr.GetInt32(dr.GetOrdinal("VAINAS_COD_PRESENCIA"));
                                oTCenso.DESCRIPCION = dr.GetString(dr.GetOrdinal("DESCRIPCION"));
                                oTCenso.PRES_FLORES = dr.GetBoolean(dr.GetOrdinal("PRES_FLORES"));
                                oTCenso.PRES_FLORES_TEXT = (bool)oTCenso.PRES_FLORES == true ? "SI" : "NO";
                                oTCenso.PRES_PLAGA_ENFERMEDA = dr.GetString(dr.GetOrdinal("PRES_PLAGA_ENFERMEDA"));
                                oTCenso.PRES_PLANTA_PARASITARIA = dr.GetString(dr.GetOrdinal("PRES_PLANTA_PARASITARIA"));
                                oTCenso.COORDENADA_NORTE = dr.GetInt32(dr.GetOrdinal("COORDENADA_NORTE"));
                                oTCenso.COORDENADA_ESTE = dr.GetInt32(dr.GetOrdinal("COORDENADA_ESTE"));
                                oTCenso.ALTURA_TOTAL = dr.GetDecimal(dr.GetOrdinal("ALTURA_TOTAL"));
                                oTCenso.OBSERVACION = dr.GetString(dr.GetOrdinal("OBSERVACION"));
                                oTCenso.ZONA = dr.GetString(dr.GetOrdinal("ZONA"));
                                oTCenso.RegEstado = 0;
                                lsCEntidad.ListTaraCenso.Add(oTCenso);
                            }
                        }
                        #endregion
                        #region "ListISUPERVISION_DET_TARA_KARDEX"
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidad();
                                ocampoEnt.COD_SECUENCIAL = dr.GetInt32(dr.GetOrdinal("COD_SECUENCIAL"));
                                ocampoEnt.N_GUIA_TRANSPORTE = dr.GetString(dr.GetOrdinal("N_GUIA_TRANSPORTE"));
                                ocampoEnt.ZAFRA = dr.GetString(dr.GetOrdinal("ZAFRA"));
                                ocampoEnt.FECHA_EMISION = dr.GetString(dr.GetOrdinal("FECHA_EMISION"));
                                ocampoEnt.CANTIDAD_AQUINTAL = dr.GetInt32(dr.GetOrdinal("CANTIDAD_AQUINTAL"));
                                ocampoEnt.TOTAL_SQUINTAL = dr.GetDecimal(dr.GetOrdinal("TOTAL_SQUINTAL"));
                                ocampoEnt.SALDO_QUINTAL = dr.GetDecimal(dr.GetOrdinal("SALDO_QUINTAL"));
                                ocampoEnt.SALDO_MTRES = dr.GetDecimal(dr.GetOrdinal("SALDO_MTRES"));
                                ocampoEnt.UBIGEO = dr.GetString(dr.GetOrdinal("UBIGEO"));
                                ocampoEnt.DESTINO_COD_UBIGEO = dr.GetString(dr.GetOrdinal("DESTINO_COD_UBIGEO"));
                                ocampoEnt.RegEstado = 0;
                                lsCEntidad.ListISUPERVISION_DET_TARA_KARDEX.Add(ocampoEnt);
                            }
                        }
                        #endregion
                        #region "ListObligacionTitular"
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            CapaEntidad.DOC.Ent_INFORME_OBLIGTITULAR ocampooblig;
                            while (dr.Read())
                            {
                                ocampooblig = new CapaEntidad.DOC.Ent_INFORME_OBLIGTITULAR();
                                ocampooblig.COD_OBLIGTITULAR = dr["COD_OBLIGTITULAR"].ToString();
                                ocampooblig.OBLIGTITULAR = dr["OBLIGTITULAR"].ToString();
                                ocampooblig.EVAL_OBLIGTITULAR = dr["EVAL_OBLIGTITULAR"].ToString();
                                ocampooblig.OBSERVACION = dr["OBSERVACION"].ToString();
                                ocampooblig.COD_GRUPO = dr["COD_GRUPO"].ToString();
                                lsCEntidad.ListObligacionTitular.Add(ocampooblig);
                            }
                        }
                        #endregion
                        #region ListDesplazamientoInforme
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidad();
                                ocampoEnt.COD_DESPLAZAMIENTO = dr["COD_DESPLAZAMIENTO"].ToString();
                                ocampoEnt.ZONA = dr["PTOI_ZONA_UTM"].ToString();
                                ocampoEnt.COORDENADA_ESTE = Int32.Parse(dr["PTOI_COORDENADA_ESTE"].ToString());
                                ocampoEnt.COORDENADA_NORTE = Int32.Parse(dr["PTOI_COORDENADA_NORTE"].ToString());
                                ocampoEnt.ZONA_CAMPO = dr["PTOF_ZONA_UTM"].ToString();
                                ocampoEnt.COORDENADA_ESTE_CAMPO = Int32.Parse(dr["PTOF_COORDENADA_ESTE"].ToString());
                                ocampoEnt.COORDENADA_NORTE_CAMPO = Int32.Parse(dr["PTOF_COORDENADA_NORTE"].ToString());
                                ocampoEnt.OBSERVACION = dr["OBSERVACION"].ToString();
                                ocampoEnt.TipoVia = dr["TIPO"].ToString();
                                ocampoEnt.RegEstado = 0;
                                lsCEntidad.ListDesplazamientoInforme.Add(ocampoEnt);
                            }
                        }
                        #endregion
                    }
                }
                return lsCEntidad;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public String RegITaraInsertar_v3(OracleConnection cn, CEntidad oCEntidad)
        {
            OracleTransaction tr = null;
            String OUTPUTPARAM01 = "";
            CEntidad ocampoSuper;
            //CEntPersona ocampoPersona;
            try
            {
                tr = cn.BeginTransaction();
                #region "Grabando Cabecera"
                using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.INFORME_TARA_Grabar_v3", oCEntidad))
                {
                    cmd.ExecuteNonQuery();
                    OUTPUTPARAM01 = (String)cmd.Parameters["OUTPUTPARAM01"].Value;
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
                        throw new Exception("El Número de Informe ya Existe");
                    }
                    else if (OUTPUTPARAM01 == "1")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("El Número del Titulo Habilitante Existe en otro Registro");
                    }
                    else if (OUTPUTPARAM01 == "2")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("No Tiene Permisos para Modificar este Informe");
                    }
                    else if (OUTPUTPARAM01 == "3")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("Está con Control de Calidad, no puede modificar");
                    }
                }
                if(OUTPUTPARAM01.Length>15)
                  OUTPUTPARAM01 = OUTPUTPARAM01.Split('|')[0];
                #endregion
                #region "ListEliTABLA"
                if (oCEntidad.ListEliTABLA != null)
                {
                    foreach (var loDatos in oCEntidad.ListEliTABLA)
                    {
                        ocampoSuper = new CEntidad();
                        ocampoSuper.COD_INFORME = OUTPUTPARAM01;
                        ocampoSuper.EliTABLA = loDatos.EliTABLA;
                        ocampoSuper.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                        ocampoSuper.COD_PERSONA = loDatos.COD_PERSONA;
                        ocampoSuper.EliVALOR01 = loDatos.EliVALOR01;
                        dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spINFORME_TARAEliminarDet", ocampoSuper);
                    }
                }
                #endregion
                #region ListInformeDetSupervisor
                if (oCEntidad.ListInformeDetSupervisor != null)
                {
                    CEntPersona ocampoPer;
                    foreach (var loDatos in oCEntidad.ListInformeDetSupervisor)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            ocampoPer = new CEntPersona();
                            ocampoPer.COD_PERSONA = loDatos.COD_PERSONA;
                            ocampoPer.CODIGO = OUTPUTPARAM01;
                            ocampoPer.RegEstado = 0;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.INFORME_DET_SUPERVISOR_GrabarV3", ocampoPer);
                        }
                    }
                }
                #endregion
                #region "ListTaraConcepto"
                if (oCEntidad.ListTaraConcepto != null)
                {
                    foreach (var loDatos in oCEntidad.ListTaraConcepto)
                    {
                        ocampoSuper = new CEntidad();
                        ocampoSuper.COD_INFORME = OUTPUTPARAM01;
                        ocampoSuper.COD_TCONCEPTO = loDatos.COD_TCONCEPTO;
                        ocampoSuper.ESTADO_MPLANTACION = loDatos.ESTADO_MPLANTACION;
                        ocampoSuper.OBSERVACION = loDatos.OBSERVACION;
                        dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.INFORME_TARA_DET_CONCEPTO_Grabar", ocampoSuper);
                    }
                }
                #endregion
                #region "ListISUPERVISION_DET_TARA_APROV"
                if (oCEntidad.ListISUPERVISION_DET_TARA_APROV != null)
                {
                    foreach (var loDatos in oCEntidad.ListISUPERVISION_DET_TARA_APROV)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            ocampoSuper = new CEntidad();
                            ocampoSuper.COD_INFORME = OUTPUTPARAM01;
                            ocampoSuper.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            ocampoSuper.PREDIO_AREA = loDatos.PREDIO_AREA;
                            ocampoSuper.N_ARBOL_SUPERVISADO = loDatos.N_ARBOL_SUPERVISADO;
                            ocampoSuper.N_ARBOL_FVERDE = loDatos.N_ARBOL_FVERDE;
                            ocampoSuper.N_ARBOL_FVERDE_MADURO = loDatos.N_ARBOL_FVERDE_MADURO;
                            ocampoSuper.N_ARBOL_FLOR = loDatos.N_ARBOL_FLOR;
                            ocampoSuper.N_ARBOL_NOFRUTO = loDatos.N_ARBOL_NOFRUTO;
                            ocampoSuper.OBSERVACION = loDatos.OBSERVACION;
                            ocampoSuper.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.ISUPERVISION_TARA_DET_APROV_Grabar", ocampoSuper);
                        }
                    }
                }
                #endregion
                #region "ListISUPERVISION_DET_TARA_CAPACITACION"
                if (oCEntidad.ListISUPERVISION_DET_TARA_CAPACITACION != null)
                {
                    foreach (var loDatos in oCEntidad.ListISUPERVISION_DET_TARA_CAPACITACION)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            ocampoSuper = new CEntidad();
                            ocampoSuper.COD_INFORME = OUTPUTPARAM01;
                            ocampoSuper.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            ocampoSuper.NOMBRES = loDatos.NOMBRES;
                            ocampoSuper.NUM_PERSONA = loDatos.NUM_PERSONA;
                            ocampoSuper.DESCRIPCION = loDatos.DESCRIPCION;
                            ocampoSuper.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.ISUPERVISION_TARA_DET_CAPACITACION_Grabar", ocampoSuper);
                        }
                    }
                }
                #endregion
                #region "ListISUPERVISION_DET_TARA_PFRUTOS"
                if (oCEntidad.ListISUPERVISION_DET_TARA_PFRUTOS != null)
                {
                    foreach (var loDatos in oCEntidad.ListISUPERVISION_DET_TARA_PFRUTOS)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            ocampoSuper = new CEntidad();
                            ocampoSuper.COD_INFORME = OUTPUTPARAM01;
                            ocampoSuper.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            ocampoSuper.PREDIO_AREA = loDatos.PREDIO_AREA;
                            ocampoSuper.PRIMERA_COSECHA = loDatos.PRIMERA_COSECHA;
                            ocampoSuper.SEGUNDA_COSECHA = loDatos.SEGUNDA_COSECHA;
                            ocampoSuper.TOTAL_PROD_ANUAL = loDatos.TOTAL_PROD_ANUAL;
                            ocampoSuper.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.ISUPERVISION_TARA_DET_PFRUTOS_Grabar", ocampoSuper);
                        }
                    }
                }
                #endregion
                #region "ListISUPERVISION_DET_TARA_APFORESTAL"
                if (oCEntidad.ListISUPERVISION_DET_TARA_APFORESTAL != null)
                {
                    foreach (var loDatos in oCEntidad.ListISUPERVISION_DET_TARA_APFORESTAL)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            ocampoSuper = new CEntidad();
                            ocampoSuper.COD_INFORME = OUTPUTPARAM01;
                            ocampoSuper.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            ocampoSuper.PREDIO_AREA = loDatos.PREDIO_AREA;
                            ocampoSuper.ZAFRA = loDatos.ZAFRA;
                            ocampoSuper.P_ARBOL_PRODUCTIVO = loDatos.P_ARBOL_PRODUCTIVO;
                            ocampoSuper.P_ARBOL_NOPRODUCTIVO = loDatos.P_ARBOL_NOPRODUCTIVO;
                            ocampoSuper.P_ARBOL_PLANTADO = loDatos.P_ARBOL_PLANTADO;
                            ocampoSuper.CANTIDAD_AEXTRAER = loDatos.CANTIDAD_AEXTRAER;
                            ocampoSuper.CANTIDAD_EXTRAIDA = loDatos.CANTIDAD_EXTRAIDA;
                            ocampoSuper.N_ARBOL_SUPERVISADO = loDatos.N_ARBOL_SUPERVISADO;
                            ocampoSuper.CANTIDAD_SUPERVISADO = loDatos.CANTIDAD_SUPERVISADO;
                            ocampoSuper.CANTIDAD_INJUSTIFICADA = loDatos.CANTIDAD_INJUSTIFICADA;
                            ocampoSuper.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.ISUPERVISION_TARA_DET_APFORESTAL_Grabar", ocampoSuper);
                        }
                    }
                }
                #endregion
                #region "ListTaraCenso"
                if (oCEntidad.ListTaraCenso != null)
                {
                    foreach (var loDatos in oCEntidad.ListTaraCenso)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            ocampoSuper = new CEntidad();
                            ocampoSuper.COD_INFORME = OUTPUTPARAM01;
                            ocampoSuper.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            ocampoSuper.PREDIO_AREA = loDatos.PREDIO_AREA;
                            ocampoSuper.CODIGO_ARBOL = loDatos.CODIGO_ARBOL;
                            ocampoSuper.VAINAS_COD_PRESENCIA = loDatos.VAINAS_COD_PRESENCIA;
                            ocampoSuper.PRES_FLORES = loDatos.PRES_FLORES;
                            ocampoSuper.PRES_PLAGA_ENFERMEDA = loDatos.PRES_PLAGA_ENFERMEDA;
                            ocampoSuper.PRES_PLANTA_PARASITARIA = loDatos.PRES_PLANTA_PARASITARIA;
                            ocampoSuper.COORDENADA_NORTE = loDatos.COORDENADA_NORTE;
                            ocampoSuper.COORDENADA_ESTE = loDatos.COORDENADA_ESTE;
                            ocampoSuper.ALTURA_TOTAL = loDatos.ALTURA_TOTAL;
                            ocampoSuper.OBSERVACION = loDatos.OBSERVACION;
                            ocampoSuper.ZONA = loDatos.ZONA;
                            ocampoSuper.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.ISUPERVISION_TARA_DET_CENSO_Grabar", ocampoSuper);
                        }
                    }
                }
                #endregion
                #region "ListISUPERVISION_DET_TARA_KARDEX"
                if (oCEntidad.ListISUPERVISION_DET_TARA_KARDEX != null)
                {
                    foreach (var loDatos in oCEntidad.ListISUPERVISION_DET_TARA_KARDEX)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            ocampoSuper = new CEntidad();
                            ocampoSuper.COD_INFORME = OUTPUTPARAM01;
                            ocampoSuper.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            ocampoSuper.N_GUIA_TRANSPORTE = loDatos.N_GUIA_TRANSPORTE;
                            ocampoSuper.ZAFRA = loDatos.ZAFRA;
                            ocampoSuper.FECHA_EMISION = loDatos.FECHA_EMISION;
                            ocampoSuper.CANTIDAD_AQUINTAL = loDatos.CANTIDAD_AQUINTAL;
                            ocampoSuper.TOTAL_SQUINTAL = loDatos.TOTAL_SQUINTAL;
                            ocampoSuper.SALDO_QUINTAL = loDatos.SALDO_QUINTAL;
                            ocampoSuper.SALDO_MTRES = loDatos.SALDO_MTRES;
                            ocampoSuper.DESTINO_COD_UBIGEO = loDatos.DESTINO_COD_UBIGEO;
                            ocampoSuper.UBIGEO = loDatos.UBIGEO;
                            ocampoSuper.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.ISUPERVISION_TARA_DET_KARDEX_Grabar", ocampoSuper);
                        }
                    }
                }
                #endregion
                #region ListObligacionTitular
                if (oCEntidad.ListObligacionTitular != null)
                {
                    CapaEntidad.DOC.Ent_INFORME_OBLIGTITULAR ocampooblig;
                    foreach (var loDatos in oCEntidad.ListObligacionTitular)
                    {
                        ocampooblig = new CapaEntidad.DOC.Ent_INFORME_OBLIGTITULAR();
                        ocampooblig.COD_INFORME = OUTPUTPARAM01;
                        ocampooblig.COD_OBLIGTITULAR = loDatos.COD_OBLIGTITULAR;
                        ocampooblig.EVAL_OBLIGTITULAR = loDatos.EVAL_OBLIGTITULAR;
                        ocampooblig.OBSERVACION = loDatos.OBSERVACION;
                        ocampooblig.COD_UCUENTA = oCEntidad.COD_UCUENTA;
                        dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spISUPERVISION_OBLIG_TITULARGrabar", ocampooblig);
                    }
                }
                #endregion
                #region "ListDesplazamientoInforme"
                if (oCEntidad.ListDesplazamientoInforme != null)
                {
                    foreach (var loDatos in oCEntidad.ListDesplazamientoInforme)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            ocampoSuper = new CEntidad();
                            ocampoSuper.COD_INFORME = OUTPUTPARAM01;
                            ocampoSuper.COD_DESPLAZAMIENTO = loDatos.COD_DESPLAZAMIENTO;
                            ocampoSuper.ZONA = loDatos.ZONA;
                            ocampoSuper.PTOI_COORDENADA_ESTE = loDatos.COORDENADA_ESTE;
                            ocampoSuper.PTOI_COORDENADA_NORTE = loDatos.COORDENADA_NORTE;
                            ocampoSuper.ZONA_CAMPO = loDatos.ZONA_CAMPO;
                            ocampoSuper.PTOF_COORDENADA_ESTE = loDatos.COORDENADA_ESTE_CAMPO;
                            ocampoSuper.PTOF_COORDENADA_NORTE = loDatos.COORDENADA_NORTE_CAMPO;
                            ocampoSuper.OBSERVACION = loDatos.OBSERVACION;
                            ocampoSuper.TIPO = loDatos.TipoVia;
                            ocampoSuper.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spINFORME_DESPLAZAMIENTOGrabar", ocampoSuper);
                        }
                    }
                }
                #endregion

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

        public List<Dictionary<string, string>> ReportesInforme(OracleConnection cn, CEntidad oCEntidad)
        {
            List<Dictionary<string, string>> lstResult = new List<Dictionary<string, string>>();

            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, "DOC_OSINFOR_ERP_MIGRACION.spReporteInforme", oCEntidad.TIPO_REPORTE, oCEntidad.COD_UCUENTA, oCEntidad.COD_INFORME, oCEntidad.COD_CNOTIFICACION, oCEntidad.NUM_POA))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            Dictionary<string, string> sFila;
                            string sColumn = "";

                            while (dr.Read())
                            {
                                sFila = new Dictionary<string, string>();
                                for (int i = 0; i < dr.FieldCount; i++)
                                {
                                    sColumn = dr.GetName(i);
                                    sFila.Add(sColumn, dr[sColumn].ToString());
                                }
                                lstResult.Add(sFila);
                            }
                        }
                    }
                }

                return lstResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public VM_FControlCalidadSupervision obtenerFControlCalidad(string COD_INFORME)
        {
            VM_FControlCalidadSupervision formatos = new VM_FControlCalidadSupervision();

            using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
            {
                cn.Open();
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, "DOC_OSINFOR_ERP_MIGRACION.usp_InformeFormatoControlCalidad_V3", COD_INFORME))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            VM_FControlCalidadSupervision_Det formato;
                            formatos.conInforme = COD_INFORME;
                            formatos.lstISupervision = new List<VM_FControlCalidadSupervision_Det>();
                            formatos.lstDatosReg = new List<VM_FControlCalidadSupervision_Det>();
                            while (dr.Read())
                            {
                                formato = new VM_FControlCalidadSupervision_Det();
                                formato.id = int.Parse(dr["ID"].ToString());
                                formato.padre = dr["PADRE"].ToString();
                                formato.hijo = dr["HIJO"].ToString();
                                formato.ORDEN_HIJO = int.Parse(dr["ORDEN_HIJO"].ToString());
                                formato.codigo = dr["CODIGO"].ToString();
                                formato.SUB_GRUPO = int.Parse(dr["SUB_GRUPO"].ToString());
                                formato.PRESENTA_OBS = dr["PRESENTA_OBS"].ToString();
                                formato.LEVANTO_OBS = dr["LEVANTO_OBS"].ToString();
                                formato.OBS_ADICIONALES = dr["OBS_ADICIONALES"].ToString();
                                formato.DETALLE = dr["DETALLE"].ToString();
                                formato.FECHA_VARIOS = dr["FECHA_VARIOS"].ToString();
                                formato.cantHijos = int.Parse(dr["CANT_HIJOS"].ToString());
                                formato.est = Convert.ToInt32(dr["est"]);
                                if (formato.SUB_GRUPO == 1)
                                    formatos.lstISupervision.Add(formato);
                                else formatos.lstDatosReg.Add(formato);
                            }
                        }
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            dr.Read();
                            formatos.eJefeODCID = dr["JEFEOD_CONTROL_CALIDAD_ID"].ToString();
                            formatos.fechaRecepcionIS = dr["FECHA_RECEPCION_IS"].ToString();
                            formatos.eJefeODC = dr["JEFEOD_CONTROL_CALIDAD"].ToString();
                        }
                    }
                }
            }
            return formatos;
        }
        private DateTime? fechaAddTime(string fecha, string defaultDate = null)
        {
            DateTime actual = DateTime.Now;
            if ((fecha != null) && (fecha != ""))
            {
                DateTime fechaInforme = Convert.ToDateTime(fecha);
                fechaInforme = new DateTime(fechaInforme.Year, fechaInforme.Month, fechaInforme.Day
                                           , actual.Hour, actual.Minute, actual.Second);
                return fechaInforme;
            }
            else if (defaultDate == "1")
            {
                return new DateTime(actual.Year, actual.Month, actual.Day
                                           , actual.Hour, actual.Minute, actual.Second);  
            }
            else
            {
                return null;
            }

        }
        public bool registrarFControlCalidad(VM_FControlCalidadSupervision mv, string usuarioId)
        {
            Ent_FControlCalidadSupervision entidad;
            using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
            {
                OracleTransaction tr = null;
                try
                {
                    cn.Open();
                    //validando                    
                    using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, "DOC_OSINFOR_ERP_MIGRACION.usp_InformeFormatoControlCalidadValidar_V3", mv.conInforme, null, usuarioId, null,mv.codPerfil))
                    {
                        if (dr != null)
                        {
                            if (dr.HasRows)
                            {
                                dr.Read();
                                string bandera = "", obs = "";
                                bandera = dr["obsBandera"].ToString();
                                obs = dr["obsValidacion"].ToString();
                                if (bandera != "EXITO")
                                    throw new Exception(obs);
                            }
                        }
                    }

                    dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.usp_InformeFormatoControlCabeceraGuardar_V3", mv.conInforme, mv.eJefeODCID, this.fechaAddTime(mv.fechaRecepcionIS));

                    /*
                     * 135 - Inicio del control de calidad
                     * 84 - Se advierten observaciones
                     * 85 - Se levantan observaciones
                     * 86 - Persisten observaciones
                     * 87 - Se levantan observaciones
                     * 136 - Control finalizado - Sin observaciones
                     * 
                     * */
                    /*146 - Control finalizado - Persiste observaciones
                     * 147 - Control finalizado - Sin observaciones
                     * 148 - Control de calidad conforme
                     * */
                    int[] idControl = new int[] { 135, 84, 85, 86, 87, 150, 136, 144, 145, 146, 147, 148 };
                    //validando item supervision
                    if (mv.lstISupervision != null)
                    {
                        var lstInformeCalidad = mv.lstISupervision.Where(x => idControl.Contains(x.id));
                        foreach (var item in lstInformeCalidad)
                        {
                            using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, "DOC_OSINFOR_ERP_MIGRACION.usp_InformeFormatoControlCalidadValidar_V3", mv.conInforme, item.id, usuarioId, item.PRESENTA_OBS, mv.codPerfil))
                            {
                                if (dr != null)
                                {
                                    if (dr.HasRows)
                                    {
                                        dr.Read();
                                        string bandera = "", obs = "";
                                        bandera = dr["obsBandera"].ToString();
                                        obs = dr["obsValidacion"].ToString();
                                        if (bandera != "EXITO")
                                            throw new Exception(obs);
                                    }
                                }
                            }
                        }

                    }
                    //validando item Datos SIGOsfc
                    if (mv.lstDatosReg != null)
                    {
                        var lstDatosSigoSfcCalidad = mv.lstDatosReg.Where(x => idControl.Contains(x.id));
                        foreach (var item in lstDatosSigoSfcCalidad)
                        {
                            using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, "DOC_OSINFOR_ERP_MIGRACION.usp_InformeFormatoControlCalidadValidar_V3", mv.conInforme, item.id, usuarioId, item.PRESENTA_OBS, mv.codPerfil))
                            {
                                if (dr != null)
                                {
                                    if (dr.HasRows)
                                    {
                                        dr.Read();
                                        string bandera = "", obs = "";
                                        bandera = dr["obsBandera"].ToString();
                                        obs = dr["obsValidacion"].ToString();
                                        if (bandera != "EXITO")
                                            throw new Exception(obs);
                                    }
                                }
                            }
                        }
                    }
                    tr = cn.BeginTransaction();

                    //registrando o actualizando datos de control de calidad
                    //datos calidad informe
                    if (mv.lstISupervision != null)
                    {
                        foreach (var item in mv.lstISupervision)
                        {
                            entidad = new Ent_FControlCalidadSupervision();
                            entidad.COD_INFORME = mv.conInforme;
                            entidad.MAESTRO_FORMATO_ID = item.id;
                            entidad.COD_UCUENTA = usuarioId;
                            entidad.ESTADOREG = item.est;
                            entidad.PRESENTA_OBS = item.PRESENTA_OBS;
                            entidad.LEVANTO_OBS = item.LEVANTO_OBS;
                            entidad.OBS_ADICIONALES = null;
                            entidad.DETALLE = item.DETALLE;
                            entidad.FECHA_VARIOS = this.fechaAddTime(item.FECHA_VARIOS, "1");
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.usp_InformeFormatoControlCalidadGuardar_V3", entidad);
                        }

                        dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.usp_InformeFormatoControlCalidadCompletar_V3", mv.conInforme, usuarioId);
                    }
                    //datos calidad Sigosfc
                    if (mv.lstDatosReg != null)
                    {
                        foreach (var item in mv.lstDatosReg)
                        {
                            entidad = new Ent_FControlCalidadSupervision();
                            entidad.COD_INFORME = mv.conInforme;
                            entidad.MAESTRO_FORMATO_ID = item.id;
                            entidad.COD_UCUENTA = usuarioId;
                            entidad.ESTADOREG = item.est;
                            entidad.PRESENTA_OBS = item.PRESENTA_OBS;
                            entidad.LEVANTO_OBS = item.LEVANTO_OBS;
                            entidad.OBS_ADICIONALES = item.OBS_ADICIONALES;
                            entidad.DETALLE = item.DETALLE;
                            entidad.FECHA_VARIOS = this.fechaAddTime(item.FECHA_VARIOS);
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.usp_InformeFormatoControlCalidadGuardar_V3", entidad);
                        }
                    }
                    tr.Commit();
                }
                catch (Exception ex)
                {
                    if (tr != null)
                        tr.Rollback();
                    throw ex;
                }
            }
            return true;
        }

        //llanos
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public List<CapaEntidad.DOC.Ent_INFORME_MADERABLE> DatosMaderable(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CapaEntidad.DOC.Ent_INFORME_MADERABLE> lsCEntidad = new List<CapaEntidad.DOC.Ent_INFORME_MADERABLE>();
            //CEntidad oCampoS = null;
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.ISUPERVISION_DET_EMADERABLE_Datos", oCEntidad))
                {
                    if (dr != null)
                    {

                        if (dr.HasRows)
                        {
                            CapaEntidad.DOC.Ent_INFORME_MADERABLE oCampo;
                            int pt1 = dr.GetOrdinal("NUM_POA");
                            while (dr.Read())
                            {
                                oCampo = new CapaEntidad.DOC.Ent_INFORME_MADERABLE();
                                oCampo.COD_SECUENCIAL = Int32.Parse(dr["COD_SECUENCIAL"].ToString());
                                oCampo.COD_INFORME = dr["COD_INFORME"].ToString();
                                oCampo.COD_THABILITANTE = dr["COD_THABILITANTE"].ToString();
                                oCampo.NUM_POA = Int32.Parse(dr["NUM_POA"].ToString());
                                oCampo.POA = dr["POA"].ToString();
                                oCampo.BLOQUE = dr["BLOQUE"].ToString();
                                oCampo.BLOQUE_CAMPO = dr["BLOQUE_CAMPO"].ToString();
                                oCampo.FAJA = dr["FAJA"].ToString();
                                oCampo.FAJA_CAMPO = dr["FAJA_CAMPO"].ToString();
                                oCampo.CODIGO = dr["CODIGO"].ToString();
                                oCampo.CODIGO_CAMPO = dr["CODIGO_CAMPO"].ToString();
                                oCampo.COD_ESPECIES = dr["COD_ESPECIES"].ToString();
                                oCampo.DESC_ESPECIES = dr["DESC_ESPECIES"].ToString();
                                oCampo.COD_ESPECIES_CAMPO = dr["COD_ESPECIES_CAMPO"].ToString();
                                oCampo.DESC_ESPECIES_CAMPO = dr["DESC_ESPECIES_CAMPO"].ToString();
                                oCampo.COINCIDE_ESPECIES = dr["COINCIDE_ESPECIES"].ToString();
                                oCampo.DAP = Decimal.Parse(dr["DAP"].ToString());
                                oCampo.DAP_CAMPO = Decimal.Parse(dr["DAP_CAMPO"].ToString());
                                oCampo.DAP_CAMPO1 = Decimal.Parse(dr["DAP_CAMPO1"].ToString());
                                oCampo.DAP_CAMPO2 = Decimal.Parse(dr["DAP_CAMPO2"].ToString());
                                oCampo.MAE_TIP_MMEDIRDAP = dr.GetString(dr.GetOrdinal("MAE_TIP_MMEDIRDAP"));
                                oCampo.VIGENCIA = dr.GetString(dr.GetOrdinal("VIGENCIA"));
                                oCampo.AC = dr.GetDecimal(dr.GetOrdinal("AC"));
                                oCampo.AC_CAMPO = dr.GetDecimal(dr.GetOrdinal("AC_CAMPO"));
                                oCampo.ZONA = dr.GetString(dr.GetOrdinal("ZONA"));
                                oCampo.ZONA_CAMPO = dr.GetString(dr.GetOrdinal("ZONA_CAMPO"));
                                oCampo.COORDENADA_ESTE = dr.GetInt32(dr.GetOrdinal("COORDENADA_ESTE"));
                                oCampo.COORDENADA_ESTE_CAMPO = dr.GetInt32(dr.GetOrdinal("COORDENADA_ESTE_CAMPO"));
                                oCampo.COORDENADA_NORTE = dr.GetInt32(dr.GetOrdinal("COORDENADA_NORTE"));
                                oCampo.COORDENADA_NORTE_CAMPO = dr.GetInt32(dr.GetOrdinal("COORDENADA_NORTE_CAMPO"));
                                oCampo.DESC_EESTADO = dr.GetString(dr.GetOrdinal("DESC_EESTADO"));
                                oCampo.COD_EESTADO = dr.GetString(dr.GetOrdinal("COD_EESTADO"));
                                oCampo.DESC_ECONDICION = dr.GetString(dr.GetOrdinal("DESC_ECONDICION"));
                                oCampo.COD_ECONDICION_CAMPO = dr.GetString(dr.GetOrdinal("COD_ECONDICION_CAMPO"));
                                oCampo.CANT_SOBRE_ESTIMA_DIAMETRO = dr.GetInt32(dr.GetOrdinal("CANT_SOBRE_ESTIMA_DIAMETRO"));
                                oCampo.PORC_SOBRE_ESTIMA_DIAMETRO = dr.GetDecimal(dr.GetOrdinal("PORC_SOBRE_ESTIMA_DIAMETRO"));
                                oCampo.CANT_SUB_ESTIMA_DIAMETRO = dr.GetInt32(dr.GetOrdinal("CANT_SUB_ESTIMA_DIAMETRO"));
                                oCampo.PORC_SUB_ESTIMA_DIAMETRO = dr.GetDecimal(dr.GetOrdinal("PORC_SUB_ESTIMA_DIAMETRO"));
                                oCampo.VOLUMEN = Decimal.Parse(dr["VOLUMEN"].ToString());
                                oCampo.OBSERVACION = dr.GetString(dr.GetOrdinal("OBSERVACION"));
                                oCampo.PCA = dr.GetString(dr.GetOrdinal("PCA_CAMPO"));
                                oCampo.PCA_POA = dr.GetString(dr.GetOrdinal("PCA"));
                                lsCEntidad.Add(oCampo);
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

        public List<CapaEntidad.DOC.Ent_INFORME_SEMILLERO> DatosSemillero(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CapaEntidad.DOC.Ent_INFORME_SEMILLERO> lsCEntidad = new List<CapaEntidad.DOC.Ent_INFORME_SEMILLERO>();
            //CEntidad oCampoS = null;
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.ISUPERVISION_DET_SEMILLERO_Datos", oCEntidad))
                {
                    if (dr != null)
                    {

                        if (dr.HasRows)
                        {
                            CapaEntidad.DOC.Ent_INFORME_SEMILLERO oCampo;
                            int pt1 = dr.GetOrdinal("NUM_POA");
                            while (dr.Read())
                            {
                                oCampo = new CapaEntidad.DOC.Ent_INFORME_SEMILLERO();
                                oCampo.COD_SECUENCIAL = Int32.Parse(dr["COD_SECUENCIAL"].ToString());
                                oCampo.COD_INFORME = dr["COD_INFORME"].ToString();
                                oCampo.COD_THABILITANTE = dr["COD_THABILITANTE"].ToString();
                                oCampo.NUM_POA = Int32.Parse(dr["NUM_POA"].ToString());
                                oCampo.POA = dr["POA"].ToString();
                                oCampo.BLOQUE = dr["BLOQUE"].ToString();
                                oCampo.BLOQUE_CAMPO = dr["BLOQUE_CAMPO"].ToString();
                                oCampo.FAJA = dr["FAJA"].ToString();
                                oCampo.FAJA_CAMPO = dr["FAJA_CAMPO"].ToString();
                                oCampo.CODIGO = dr["CODIGO"].ToString();
                                oCampo.CODIGO_CAMPO = dr["CODIGO_CAMPO"].ToString();
                                oCampo.COD_ESPECIES = dr["COD_ESPECIES"].ToString();
                                oCampo.DESC_ESPECIES = dr["DESC_ESPECIES"].ToString();
                                oCampo.COD_ESPECIES_CAMPO = dr["COD_ESPECIES_CAMPO"].ToString();
                                oCampo.DESC_ESPECIES_CAMPO = dr["DESC_ESPECIES_CAMPO"].ToString();
                                oCampo.COINCIDE_ESPECIES = dr["COINCIDE_ESPECIES"].ToString();
                                oCampo.DAP = Decimal.Parse(dr["DAP"].ToString());
                                oCampo.DAP_CAMPO = Decimal.Parse(dr["DAP_CAMPO"].ToString());
                                oCampo.DAP_CAMPO1 = Decimal.Parse(dr["DAP_CAMPO1"].ToString());
                                oCampo.DAP_CAMPO2 = Decimal.Parse(dr["DAP_CAMPO2"].ToString());
                                oCampo.MAE_TIP_MMEDIRDAP = dr.GetString(dr.GetOrdinal("MAE_TIP_MMEDIRDAP"));
                                oCampo.AC = dr.GetDecimal(dr.GetOrdinal("AC"));
                                oCampo.AC_CAMPO = dr.GetDecimal(dr.GetOrdinal("AC_CAMPO"));
                                oCampo.ZONA = dr.GetString(dr.GetOrdinal("ZONA"));
                                oCampo.ZONA_CAMPO = dr.GetString(dr.GetOrdinal("ZONA_CAMPO"));
                                oCampo.COORDENADA_ESTE = dr.GetInt32(dr.GetOrdinal("COORDENADA_ESTE"));
                                oCampo.COORDENADA_ESTE_CAMPO = dr.GetInt32(dr.GetOrdinal("COORDENADA_ESTE_CAMPO"));
                                oCampo.COORDENADA_NORTE = dr.GetInt32(dr.GetOrdinal("COORDENADA_NORTE"));
                                oCampo.COORDENADA_NORTE_CAMPO = dr.GetInt32(dr.GetOrdinal("COORDENADA_NORTE_CAMPO"));
                                oCampo.DESC_EESTADO = dr["DESC_EESTADO"].ToString(); //dr.GetString(dr.GetOrdinal("DESC_EESTADO"));
                                oCampo.COD_EESTADO = dr.GetString(dr.GetOrdinal("COD_EESTADO"));
                                oCampo.COD_EFENOLOGICO = dr.GetString(dr.GetOrdinal("COD_EFENOLOGICO"));
                                oCampo.DESC_EFENOLOGICO = dr["DESC_EFENOLOGICO"].ToString(); //dr.GetString(dr.GetOrdinal("DESC_EFENOLOGICO"));
                                oCampo.COD_CFUSTE = dr.GetString(dr.GetOrdinal("COD_CFUSTE"));
                                oCampo.DESC_CFUSTE = dr["DESC_CFUSTE"].ToString(); //dr.GetString(dr.GetOrdinal("DESC_CFUSTE"));
                                oCampo.COD_FCOPA = dr.GetString(dr.GetOrdinal("COD_FCOPA"));
                                oCampo.DESC_FCOPA = dr["DESC_FCOPA"].ToString(); //dr.GetString(dr.GetOrdinal("DESC_FCOPA"));
                                oCampo.COD_PCOPA = dr.GetString(dr.GetOrdinal("COD_PCOPA")); ;
                                oCampo.DESC_PCOPA = dr["DESC_PCOPA"].ToString(); //dr.GetString(dr.GetOrdinal("DESC_PCOPA"));
                                oCampo.COD_ESANITARIO = dr.GetString(dr.GetOrdinal("COD_ESANITARIO"));
                                oCampo.DESC_ESANITARIO = dr["DESC_ESANITARIO"].ToString(); //dr.GetString(dr.GetOrdinal("DESC_ESANITARIO"));
                                oCampo.COD_ILIANAS = dr.GetString(dr.GetOrdinal("COD_ILIANAS"));
                                oCampo.DESC_ILIANAS = dr["DESC_ILIANAS"].ToString(); //dr.GetString(dr.GetOrdinal("DESC_ILIANAS"));
                                oCampo.CANT_SOBRE_ESTIMA_DIAMETRO = dr.GetInt32(dr.GetOrdinal("CANT_SOBRE_ESTIMA_DIAMETRO"));
                                oCampo.PORC_SOBRE_ESTIMA_DIAMETRO = dr.GetDecimal(dr.GetOrdinal("PORC_SOBRE_ESTIMA_DIAMETRO"));
                                oCampo.CANT_SUB_ESTIMA_DIAMETRO = dr.GetInt32(dr.GetOrdinal("CANT_SUB_ESTIMA_DIAMETRO"));
                                oCampo.PORC_SUB_ESTIMA_DIAMETRO = dr.GetDecimal(dr.GetOrdinal("PORC_SUB_ESTIMA_DIAMETRO"));
                                oCampo.OBSERVACION = dr.GetString(dr.GetOrdinal("OBSERVACION"));
                                oCampo.PCA = dr.GetString(dr.GetOrdinal("PCA_CAMPO"));
                                oCampo.PCA_POA = dr.GetString(dr.GetOrdinal("PCA"));

                                lsCEntidad.Add(oCampo);
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

        public List<CapaEntidad.DOC.Ent_INFORME_NO_MADERABLE> DatosNoMaderable(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CapaEntidad.DOC.Ent_INFORME_NO_MADERABLE> lsCEntidad = new List<CapaEntidad.DOC.Ent_INFORME_NO_MADERABLE>();
            //CEntidad oCampoS = null;
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.ISUPERVISION_DET_NOMADERABLE_Datos", oCEntidad))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            CapaEntidad.DOC.Ent_INFORME_NO_MADERABLE oCampo;
                            int pt1 = dr.GetOrdinal("NUM_POA");
                            while (dr.Read())
                            {
                                oCampo = new CapaEntidad.DOC.Ent_INFORME_NO_MADERABLE();
                                oCampo.COD_SECUENCIAL = Int32.Parse(dr["COD_SECUENCIAL"].ToString());
                                oCampo.COD_INFORME = dr["COD_INFORME"].ToString();
                                oCampo.COD_THABILITANTE = dr["COD_THABILITANTE"].ToString();
                                oCampo.NUM_POA = Int32.Parse(dr["NUM_POA"].ToString());
                                oCampo.POA = dr["POA"].ToString();
                                oCampo.NUM_ESTRADA = dr["NUM_ESTRADA"].ToString();
                                oCampo.NUM_ESTRADA_CAMPO = dr["NUM_ESTRADA_CAMPO"].ToString();
                                oCampo.DIAMETRO = decimal.Parse(dr["DIAMETRO"].ToString());
                                oCampo.DIAMETRO_CAMPO = decimal.Parse(dr["DIAMETRO_CAMPO"].ToString());
                                oCampo.ALTURA = decimal.Parse(dr["ALTURA"].ToString());
                                oCampo.ALTURA_CAMPO = decimal.Parse(dr["ALTURA_CAMPO"].ToString());
                                oCampo.COD_EESTADO = dr["COD_EESTADO"].ToString();
                                oCampo.PRODUCCION_LATAS = decimal.Parse(dr["PRODUCCION_LATAS"].ToString());
                                oCampo.PRODUCCION_LATAS_CAMPO = decimal.Parse(dr["PRODUCCION_LATAS_CAMPO"].ToString());
                                oCampo.NUM_COCOS_ABIERTOS = Int32.Parse(dr["NUM_COCOS_ABIERTOS"].ToString());
                                oCampo.NUM_COCOS_CERRADOS = Int32.Parse(dr["NUM_COCOS_CERRADOS"].ToString());
                                oCampo.CODIGO = dr["CODIGO"].ToString();
                                oCampo.CODIGO_CAMPO = dr["CODIGO_CAMPO"].ToString();
                                oCampo.COD_ESPECIES = dr["COD_ESPECIES"].ToString();
                                oCampo.DESC_ESPECIES = dr["DESC_ESPECIES"].ToString();
                                oCampo.COD_ESPECIES_CAMPO = dr["COD_ESPECIES_CAMPO"].ToString();
                                oCampo.DESC_ESPECIES_CAMPO = dr["DESC_ESPECIES_CAMPO"].ToString();
                                oCampo.ZONA = dr.GetString(dr.GetOrdinal("ZONA"));
                                oCampo.ZONA_CAMPO = dr.GetString(dr.GetOrdinal("ZONA_CAMPO"));
                                oCampo.COORDENADA_ESTE = dr.GetInt32(dr.GetOrdinal("COORDENADA_ESTE"));
                                oCampo.COORDENADA_ESTE_CAMPO = dr.GetInt32(dr.GetOrdinal("COORDENADA_ESTE_CAMPO"));
                                oCampo.COORDENADA_NORTE = dr.GetInt32(dr.GetOrdinal("COORDENADA_NORTE"));
                                oCampo.COORDENADA_NORTE_CAMPO = dr.GetInt32(dr.GetOrdinal("COORDENADA_NORTE_CAMPO"));
                                oCampo.COD_EESTADO = dr.GetString(dr.GetOrdinal("COD_EESTADO"));
                                oCampo.COD_EFENOLOGICO = dr.GetString(dr.GetOrdinal("COD_EFENOLOGICO"));
                                oCampo.DESC_EFENOLOGICO = dr.GetString(dr.GetOrdinal("DESC_EFENOLOGICO"));
                                oCampo.COD_CFUSTE = dr.GetString(dr.GetOrdinal("COD_CFUSTE"));
                                oCampo.DESC_CFUSTE = dr.GetString(dr.GetOrdinal("DESC_CFUSTE"));
                                oCampo.COD_FCOPA = dr.GetString(dr.GetOrdinal("COD_FCOPA"));
                                oCampo.DESC_FCOPA = dr.GetString(dr.GetOrdinal("DESC_FCOPA"));
                                oCampo.COD_PCOPA = dr.GetString(dr.GetOrdinal("COD_PCOPA")); ;
                                oCampo.DESC_PCOPA = dr.GetString(dr.GetOrdinal("DESC_PCOPA"));
                                oCampo.COD_ESANITARIO = dr.GetString(dr.GetOrdinal("COD_ESANITARIO"));
                                oCampo.DESC_ESANITARIO = dr.GetString(dr.GetOrdinal("DESC_ESANITARIO"));
                                oCampo.COD_ILIANAS = dr.GetString(dr.GetOrdinal("COD_ILIANAS"));
                                oCampo.DESC_ILIANAS = dr.GetString(dr.GetOrdinal("DESC_ILIANAS"));
                                oCampo.OBSERVACION = dr.GetString(dr.GetOrdinal("OBSERVACION"));
                                lsCEntidad.Add(oCampo);
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

        public List<CapaEntidad.DOC.Ent_INFORME_TROZA_CAMPO> DatosTrozaCampo(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CapaEntidad.DOC.Ent_INFORME_TROZA_CAMPO> lsCEntidad = new List<CapaEntidad.DOC.Ent_INFORME_TROZA_CAMPO>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.ISUPERVISION_DET_TROZA_CAMPO_Datos", oCEntidad))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            CapaEntidad.DOC.Ent_INFORME_TROZA_CAMPO oCampo;
                            int pt1 = dr.GetOrdinal("NUM_POA");
                            while (dr.Read())
                            {
                                oCampo = new CapaEntidad.DOC.Ent_INFORME_TROZA_CAMPO();
                                oCampo.COD_SECUENCIAL = Int32.Parse(dr["COD_SECUENCIAL"].ToString());
                                oCampo.COD_INFORME = dr["COD_INFORME"].ToString();
                                oCampo.COD_THABILITANTE = dr["COD_THABILITANTE"].ToString();
                                oCampo.NUM_POA = Int32.Parse(dr["NUM_POA"].ToString());
                                oCampo.CODIGO = dr["CODIGO"].ToString();
                                oCampo.COD_ESPECIES = dr["COD_ESPECIES"].ToString();
                                oCampo.ESPECIES = dr["ESPECIES"].ToString();
                                oCampo.ZONA = dr.GetString(dr.GetOrdinal("ZONA"));
                                oCampo.DAP1 = decimal.Parse(dr["DAP1"].ToString());
                                oCampo.DAP2 = decimal.Parse(dr["DAP2"].ToString());
                                oCampo.COORDENADA_ESTE = dr.GetInt32(dr.GetOrdinal("COORDENADA_ESTE"));
                                oCampo.COORDENADA_NORTE = dr.GetInt32(dr.GetOrdinal("COORDENADA_NORTE"));
                                oCampo.LC = decimal.Parse(dr["LC"].ToString());
                                oCampo.OBSERVACION = dr.GetString(dr.GetOrdinal("OBSERVACION"));
                                lsCEntidad.Add(oCampo);
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

        public List<CapaEntidad.DOC.Ent_INFORME_MADERA_ASERRADA> DatosMaderaAserrada(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CapaEntidad.DOC.Ent_INFORME_MADERA_ASERRADA> lsCEntidad = new List<CapaEntidad.DOC.Ent_INFORME_MADERA_ASERRADA>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.ISUPERVISION_DET_MADERA_ASERRADA_Datos", oCEntidad))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            CapaEntidad.DOC.Ent_INFORME_MADERA_ASERRADA oCampo;
                            int pt1 = dr.GetOrdinal("NUM_POA");
                            while (dr.Read())
                            {
                                oCampo = new CapaEntidad.DOC.Ent_INFORME_MADERA_ASERRADA();
                                oCampo.COD_SECUENCIAL = Int32.Parse(dr["COD_SECUENCIAL"].ToString());
                                oCampo.COD_INFORME = dr["COD_INFORME"].ToString();
                                oCampo.NUM_POA = Int32.Parse(dr["NUM_POA"].ToString());
                                oCampo.CODIGO = dr["CODIGO"].ToString();
                                oCampo.COD_ESPECIES = dr["COD_ESPECIES"].ToString();
                                oCampo.ESPECIES = dr["ESPECIES"].ToString();
                                oCampo.PIEZAS = Int32.Parse(dr["PIEZAS"].ToString());
                                oCampo.ZONA = dr.GetString(dr.GetOrdinal("ZONA"));
                                oCampo.COORDENADA_ESTE = dr.GetInt32(dr.GetOrdinal("COORDENADA_ESTE"));
                                oCampo.COORDENADA_NORTE = dr.GetInt32(dr.GetOrdinal("COORDENADA_NORTE"));
                                oCampo.ESPESOR = decimal.Parse(dr["ESPESOR"].ToString());
                                oCampo.LARGO = decimal.Parse(dr["LARGO"].ToString());
                                oCampo.ANCHO = decimal.Parse(dr["ANCHO"].ToString());
                                oCampo.OBSERVACION = dr.GetString(dr.GetOrdinal("OBSERVACION"));
                                lsCEntidad.Add(oCampo);
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

        public CEntidad AnalisisSupervision(string asCodInforme, string asCodTHabilitante, Int32 aiNumPoa)
        {
            CEntidad lsCEntidad = new CEntidad();
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spANALISIS_MADERABLE", new CEntidad() { COD_INFORME = asCodInforme, COD_THABILITANTE = asCodTHabilitante, NUM_POA = aiNumPoa }))
                    {
                        if (dr != null)
                        {
                            CapaEntidad.DOC.Ent_INFORME_ANALISIS ocampoEnt;

                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    ocampoEnt = new CapaEntidad.DOC.Ent_INFORME_ANALISIS();
                                    ocampoEnt.COD_ESPECIES = dr["COD_ESPECIES"].ToString();
                                    ocampoEnt.NOMBRE_CIENTIFICO = dr["OBSERVACION"].ToString();
                                    ocampoEnt.NUM_PIEZAS = Convert.ToInt32(dr["COD_SECUENCIAL"].ToString());
                                    ocampoEnt.VOLUMEN = Convert.ToDecimal(dr["VOLUMEN"].ToString());

                                    lsCEntidad.ListAnalisis.Add(ocampoEnt);
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

        public List<Dictionary<string, string>> ListarConsolidado(Ent_INFORME oCEntidad)
        {
            List<Dictionary<string, string>> lstResult = new List<Dictionary<string, string>>();

            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spCONSOLIDADO_Listar", oCEntidad))
                    {
                        if (dr != null)
                        {
                            if (dr.HasRows)
                            {
                                Dictionary<string, string> sFila;
                                string sColumn = "";

                                while (dr.Read())
                                {
                                    sFila = new Dictionary<string, string>();
                                    for (int i = 0; i < dr.FieldCount; i++)
                                    {
                                        sColumn = dr.GetName(i);
                                        sFila.Add(sColumn, dr[sColumn].ToString().Trim());
                                    }
                                    lstResult.Add(sFila);
                                }
                            }
                        }
                    }
                }

                return lstResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Dictionary<string, string>> ListarMaderable(Ent_INFORME oCEntidad)
        {
            List<Dictionary<string, string>> lstResult = new List<Dictionary<string, string>>();

            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    using (OracleDataReader dr =  dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spAPROVECHABLE_Listar", oCEntidad))
                    {
                        if (dr != null)
                        {
                            if (dr.HasRows)
                            {
                                Dictionary<string, string> sFila;
                                string sColumn = "";

                                while (dr.Read())
                                {
                                    sFila = new Dictionary<string, string>();
                                    for (int i = 0; i < dr.FieldCount; i++)
                                    {
                                        sColumn = dr.GetName(i);
                                        sFila.Add(sColumn, dr[sColumn].ToString().Trim());
                                    }
                                    lstResult.Add(sFila);
                                }
                            }
                        }
                    }
                }

                return lstResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
