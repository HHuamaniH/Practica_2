using CapaEntidad.General;
using CapaEntidad.ViewModel;
using CapaEntidad.ViewModel.General;
using GeneralSQL;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using CEntidad = CapaEntidad.DOC.Ent_BUSQUEDA;
using SQL = GeneralSQL.Data.SQL;

/// <summary>
/// </summary>
namespace CapaDatos.DOC
{
    /// <summary>
    /// 
    /// </summary>
    public class Dat_BUSQUEDA
    {
        private SQL oGDataSQL = new SQL();

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
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spGeneral_Listar", oCEntidad))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            CEntidad oCampos;
                            switch (oCEntidad.BusFormulario)
                            {
                                #region TITULO_HABILITANTE
                                case "TITULO_HABILITANTE":
                                    while (dr.Read())
                                    {
                                        oCampos = new CEntidad();
                                        oCampos.CODIGO = dr["COD_THABILITANTE"].ToString();
                                        oCampos.NUMERO = dr["NUMERO"].ToString();
                                        oCampos.PARAMETRO01 = dr["MODALIDAD"].ToString();
                                        oCampos.PARAMETRO02 = dr["PERSONA_TITULAR"].ToString();
                                        oCampos.PARAMETRO03 = dr["PERSONA_RLEGAL"].ToString();
                                        oCampos.PARAMETRO04 = dr["REGION"].ToString();
                                        oCampos.PARAMETRO10 = dr["FECHA"].ToString();
                                        lsCEntidad.Add(oCampos);
                                    }
                                    break;
                                #endregion
                                #region POA
                                case "POA":
                                    switch (oCEntidad.BusCriterio)
                                    {
                                        case "GRI_TH_NUMERO":
                                        case "GRI_TH_TITULAR":
                                            while (dr.Read())
                                            {
                                                oCampos = new CEntidad();
                                                oCampos.CODIGO = dr["COD_THABILITANTE"].ToString();
                                                oCampos.NUMERO = dr["NUM_THABILITANTE"].ToString();
                                                oCampos.PARAMETRO01 = dr["MODALIDAD"].ToString();
                                                oCampos.PARAMETRO02 = dr["PERSONA"].ToString();
                                                oCampos.PARAMETRO03 = dr["INDICADOR"].ToString();
                                                oCampos.PARAMETRO04 = dr["COD_MTIPO"].ToString();
                                                oCampos.PARAMETRO05 = dr["COD_UBIDEPARTAMENTO"].ToString();
                                                oCampos.PARAMETRO06 = dr["ESTADO_ORIGEN"].ToString();
                                                oCampos.PARAMETRO11 = dr["REPRESENTANTE_LEGAL"].ToString();
                                                lsCEntidad.Add(oCampos);
                                            }
                                            break;
                                        case "CODDOC_POA_CENSO":
                                            while (dr.Read())
                                            {
                                                oCampos = new CEntidad();
                                                if (dr["IdSistema"].ToString() != "0")
                                                {
                                                    oCampos.PARAMETRO01 = dr["Numero"].ToString();
                                                    oCampos.PARAMETRO02 = dr["Bloque"].ToString();
                                                    oCampos.PARAMETRO03 = dr["Faja"].ToString();
                                                    oCampos.PARAMETRO04 = dr["CodArbol"].ToString();
                                                    oCampos.PARAMETRO05 = dr["NombreComun"].ToString();
                                                    oCampos.PARAMETRO06 = dr["NombreCientifico"].ToString();
                                                    oCampos.PARAMETRO07 = dr["DAP"].ToString();
                                                    oCampos.PARAMETRO08 = dr["HCT"].ToString();
                                                    oCampos.PARAMETRO09 = dr["CF"].ToString();
                                                    oCampos.PARAMETRO10 = dr["CoordenadaEste"].ToString();
                                                    oCampos.PARAMETRO11 = dr["CoordenadaNorte"].ToString();
                                                    oCampos.PARAMETRO12 = dr["Volumen"].ToString();
                                                    oCampos.PARAMETRO13 = dr["Condicion"].ToString();
                                                    oCampos.PARAMETRO14 = dr["TipoArbol"].ToString();
                                                    oCampos.PARAMETRO15 = dr["ParcelaCorta"].ToString();
                                                    oCampos.PARAMETRO16 = dr["NroExpediente"].ToString();
                                                    oCampos.PARAMETRO17 = dr["NroResolucionAprobacion"].ToString();
                                                    oCampos.PARAMETRO18 = dr["NroArbolVolumen"].ToString();
                                                    oCampos.PARAMETRO19 = dr["NroArbol"].ToString();
                                                    oCampos.PARAMETRO20 = dr["NroPlanManejo"].ToString();
                                                    lsCEntidad.Add(oCampos);
                                                }

                                            }
                                            break;
                                        default:
                                            while (dr.Read())
                                            {
                                                oCampos = new CEntidad();
                                                oCampos.CODIGO = dr["COD_THABILITANTE"].ToString();
                                                oCampos.NUMERO = dr["NUM_POA"].ToString();
                                                oCampos.PARAMETRO01 = dr["POA"].ToString();
                                                oCampos.PARAMETRO02 = dr["ARESOLUCION_NUM"].ToString();
                                                oCampos.PARAMETRO03 = dr["POA_PADRE"].ToString();
                                                oCampos.PARAMETRO04 = dr["COD_MTIPO"].ToString();
                                                oCampos.PARAMETRO05 = dr["MODALIDAD"].ToString();
                                                oCampos.PARAMETRO06 = dr["TITULAR"].ToString();
                                                oCampos.PARAMETRO07 = dr["NUM_THABILITANTE"].ToString();
                                                oCampos.PARAMETRO08 = dr["ESTADO_ORIGEN"].ToString();
                                                oCampos.PARAMETRO09 = dr["FECHA"].ToString();
                                                oCampos.PARAMETRO10 = dr["INDICADOR"].ToString();
                                                //      oCampos.PARAMETRO11 = dr["REPRESENTANTE_LEGAL"].ToString();
                                                lsCEntidad.Add(oCampos);
                                            }
                                            break;
                                    }
                                    break;
                                #endregion
                                #region DEMA
                                case "DEMA":
                                    switch (oCEntidad.BusCriterio)
                                    {
                                        case "GRI_TH_NUMERO":
                                        case "GRI_TH_TITULAR":
                                            while (dr.Read())
                                            {
                                                oCampos = new CEntidad();
                                                oCampos.CODIGO = dr["COD_THABILITANTE"].ToString();
                                                oCampos.NUMERO = dr["NUM_THABILITANTE"].ToString();
                                                oCampos.PARAMETRO01 = dr["MODALIDAD"].ToString();
                                                oCampos.PARAMETRO02 = dr["PERSONA"].ToString();
                                                oCampos.PARAMETRO03 = dr["INDICADOR"].ToString();
                                                oCampos.PARAMETRO04 = dr["COD_MTIPO"].ToString();
                                                oCampos.PARAMETRO05 = dr["COD_UBIDEPARTAMENTO"].ToString();
                                                oCampos.PARAMETRO06 = dr["ESTADO_ORIGEN"].ToString();
                                                oCampos.PARAMETRO11 = dr["REPRESENTANTE_LEGAL"].ToString();
                                                lsCEntidad.Add(oCampos);
                                            }
                                            break;
                                        default:
                                            while (dr.Read())
                                            {
                                                oCampos = new CEntidad();
                                                oCampos.CODIGO = dr["COD_THABILITANTE"].ToString();
                                                oCampos.NUMERO = dr["NUM_POA"].ToString();
                                                oCampos.PARAMETRO01 = dr["POA"].ToString();
                                                oCampos.PARAMETRO02 = dr["ARESOLUCION_NUM"].ToString();
                                                oCampos.PARAMETRO03 = dr["POA_PADRE"].ToString();
                                                oCampos.PARAMETRO04 = dr["COD_MTIPO"].ToString();
                                                oCampos.PARAMETRO05 = dr["MODALIDAD"].ToString();
                                                oCampos.PARAMETRO06 = dr["TITULAR"].ToString();
                                                oCampos.PARAMETRO07 = dr["NUM_THABILITANTE"].ToString();
                                                oCampos.PARAMETRO08 = dr["ESTADO_ORIGEN"].ToString();
                                                oCampos.PARAMETRO09 = dr["FECHA"].ToString();
                                                oCampos.PARAMETRO10 = dr["INDICADOR"].ToString();
                                                lsCEntidad.Add(oCampos);
                                            }
                                            break;
                                    }
                                    break;
                                #endregion
                                #region PLAN_MANEJO
                                case "PLAN_MANEJO":
                                    while (dr.Read())
                                    {
                                        oCampos = new CEntidad();
                                        oCampos.CODIGO = dr["COD_PMANEJO"].ToString();
                                        oCampos.NUMERO = dr["COD_THABILITANTE"].ToString();
                                        oCampos.PARAMETRO01 = dr["FECHA"].ToString();
                                        oCampos.PARAMETRO02 = dr["FECHA_PRESENTACION"].ToString();
                                        oCampos.PARAMETRO03 = dr["MODALIDAD"].ToString();
                                        oCampos.PARAMETRO04 = dr["NUM_THABILITANTE"].ToString();
                                        oCampos.PARAMETRO05 = dr["PERSONA_TITULAR"].ToString();
                                        oCampos.PARAMETRO06 = dr["ARESOLUCION_NUM"].ToString();
                                        oCampos.PARAMETRO07 = dr["COD_MTIPO"].ToString();
                                        oCampos.PARAMETRO08 = dr["ESTADO_ORIGEN_TIPO"].ToString();
                                        oCampos.PARAMETRO09 = dr["INDICADOR"].ToString();
                                        oCampos.PARAMETRO10 = dr["ESTADO_ORIGEN"].ToString();
                                        oCampos.PARAMETRO11 = dr["HIJO_COD_PMANEJO"].ToString();
                                        oCampos.PARAMETRO12 = dr["HIJO_NIVEL"].ToString();
                                        lsCEntidad.Add(oCampos);
                                    }
                                    break;
                                #endregion
                                #region BITACORA_SUPER
                                case "BITACORA_SUPER":
                                    while (dr.Read())
                                    {
                                        oCampos = new CEntidad();
                                        oCampos.CODIGO = dr["COD_BITACORA"].ToString();
                                        oCampos.NUMERO = dr["NUM_THABILITANTE"].ToString();
                                        oCampos.PARAMETRO01 = dr["OD"].ToString();
                                        oCampos.PARAMETRO02 = dr["SUPERVISOR"].ToString();
                                        oCampos.PARAMETRO03 = dr["CARTA_NOTIFICACION"].ToString();
                                        oCampos.PARAMETRO04 = dr["SUPERVISADO"].ToString();
                                        oCampos.PARAMETRO05 = dr["TIPO_INFORME"].ToString();
                                        oCampos.PARAMETRO06 = dr["FECHA"].ToString();
                                        lsCEntidad.Add(oCampos);
                                    }
                                    break;
                                #endregion
                                #region ALERTA_OSINFOR
                                case "ALERTA_OSINFOR":
                                    while (dr.Read())
                                    {
                                        oCampos = new CEntidad();
                                        oCampos.CODIGO = dr["COD_BITACORA"].ToString();
                                        oCampos.NUMERO = dr["NUM_THABILITANTE"].ToString();
                                        oCampos.PARAMETRO01 = dr["OD"].ToString();
                                        oCampos.PARAMETRO02 = dr["SUPERVISOR"].ToString();
                                        oCampos.PARAMETRO03 = dr["CARTA_NOTIFICACION"].ToString();
                                        oCampos.PARAMETRO04 = dr["SUPERVISADO"].ToString();
                                        oCampos.PARAMETRO05 = dr["TIPO_INFORME"].ToString();
                                        oCampos.PARAMETRO06 = dr["FECHA"].ToString();
                                        oCampos.PARAMETRO07 = dr["ENVIAR_ALERTA_TEXT"].ToString();
                                        oCampos.PARAMETRO08 = dr["COD_THABILITANTE"].ToString();
                                        oCampos.PARAMETRO09 = dr["COD_SECUENCIAL"].ToString();
                                        oCampos.PARAMETRO14 = dr["FECHA_SALIDA"].ToString();
                                        oCampos.PARAMETRO15 = dr["FECHA_LLEGADA"].ToString();
                                        lsCEntidad.Add(oCampos);
                                    }
                                    break;
                                #endregion
                                #region CARTA_NOTIFICACION
                                case "CARTA_NOTIFICACION":
                                    switch (oCEntidad.BusCriterio)
                                    {
                                        case "IS_CN_NUMERO":
                                            while (dr.Read())
                                            {
                                                oCampos = new CEntidad();
                                                oCampos.PARAMETRO01 = dr["COD_THABILITANTE"].ToString();
                                                oCampos.PARAMETRO02 = dr["MODALIDAD_TIPO"].ToString();
                                                oCampos.PARAMETRO03 = dr["NUM_THABILITANTE"].ToString();
                                                oCampos.NUMERO = dr["NUM_CNOTIFICACION"].ToString();
                                                oCampos.CODIGO = dr["COD_CNOTIFICACION"].ToString();
                                                oCampos.PARAMETRO04 = dr["DESCRIPCION"].ToString();
                                                oCampos.PARAMETRO05 = dr["THABILITANTE_SECTOR"].ToString();
                                                oCampos.PARAMETRO06 = dr["COD_MTIPO"].ToString();
                                                oCampos.PARAMETRO07 = dr["ESTADO_ORIGEN"].ToString();
                                                oCampos.PARAMETRO08 = dr["COD_THABILITANTE"].ToString();
                                                lsCEntidad.Add(oCampos);
                                            }
                                            break;
                                        default:
                                            while (dr.Read())
                                            {
                                                oCampos = new CEntidad();
                                                oCampos.CODIGO = dr["COD_CNOTIFICACION"].ToString();
                                                oCampos.NUMERO = dr["NUMERO"].ToString();
                                                oCampos.PARAMETRO01 = dr["FECHA"].ToString();
                                                oCampos.PARAMETRO02 = dr["NUM_THABILITANTE"].ToString();
                                                oCampos.PARAMETRO03 = dr["TITULAR"].ToString();
                                                oCampos.PARAMETRO04 = dr["PERSONA_NOTIFICADOR"].ToString();
                                                oCampos.PARAMETRO05 = dr["ESTADO_ORIGEN"].ToString();
                                                oCampos.PARAMETRO06 = dr["COD_THABILITANTE"].ToString();
                                                oCampos.PARAMETRO07 = dr["M"].ToString();
                                                oCampos.PARAMETRO08 = dr["NM"].ToString();
                                                oCampos.PARAMETRO09 = dr["DTR"].ToString();
                                                oCampos.PARAMETRO10 = dr["DTO"].ToString();
                                                oCampos.PARAMETRO11 = dr["DAR"].ToString();
                                                oCampos.PARAMETRO12 = dr["MAE_CNTIPO"].ToString();
                                                lsCEntidad.Add(oCampos);
                                            }
                                            break;
                                    }
                                    break;
                                #endregion
                                #region INFORME_SUPERVISION
                                case "INFORME_SUPERVISION":
                                    while (dr.Read())
                                    {
                                        oCampos = new CEntidad();
                                        oCampos.CODIGO = dr["COD_INFORME"].ToString();
                                        oCampos.NUMERO = dr["NUMERO"].ToString();
                                        oCampos.PARAMETRO01 = dr["NUM_CNOTIFICACION"].ToString();
                                        oCampos.PARAMETRO02 = dr["MODALIDAD_TIPO"].ToString();
                                        oCampos.PARAMETRO03 = dr["NUM_THABILITANTE"].ToString();
                                        oCampos.PARAMETRO04 = dr["APELLIDOS_NOMBRES"].ToString();
                                        oCampos.PARAMETRO05 = dr["COD_CNOTIFICACION"].ToString();
                                        oCampos.PARAMETRO06 = dr["COD_MTIPO"].ToString();
                                        oCampos.PARAMETRO07 = dr["COD_THABILITANTE"].ToString();
                                        oCampos.PARAMETRO08 = dr["ESTADO_ORIGEN"].ToString();
                                        oCampos.PARAMETRO09 = dr["TITULAR"].ToString();
                                        oCampos.PARAMETRO10 = dr["FECHA"].ToString();
                                        oCampos.PARAMETRO11 = dr["POA"].ToString();
                                        oCampos.PARAMETRO12 = dr["DOC"].ToString();
                                        lsCEntidad.Add(oCampos);
                                    }
                                    break;
                                #endregion
                                #region INFORME_SUSPENSION
                                case "INFORME_SUSPENSION":
                                    while (dr.Read())
                                    {
                                        oCampos = new CEntidad();
                                        oCampos.CODIGO = dr["COD_INFORME"].ToString();
                                        oCampos.NUMERO = dr["NUMERO"].ToString();
                                        oCampos.PARAMETRO01 = dr["CNOTIFICACION"].ToString();
                                        oCampos.PARAMETRO02 = dr["MODALIDAD_TIPO"].ToString();
                                        oCampos.PARAMETRO03 = dr["COD_THABILITANTE"].ToString();
                                        oCampos.PARAMETRO04 = dr["THABILITANTE"].ToString();
                                        oCampos.PARAMETRO05 = dr["COD_CNOTIFICACION"].ToString();
                                        oCampos.PARAMETRO06 = dr["COD_MTIPO"].ToString();
                                        oCampos.PARAMETRO07 = dr["SUPERVISION"].ToString();
                                        oCampos.PARAMETRO10 = dr["FECHA"].ToString();
                                        lsCEntidad.Add(oCampos);
                                    }
                                    break;
                                #endregion
                                #region INFORME_CANCELACION
                                case "INFORME_CANCELACION":
                                    switch (oCEntidad.BusCriterio)
                                    {
                                        case "IC_CN_NUMERO":
                                            while (dr.Read())
                                            {
                                                oCampos = new CEntidad();
                                                oCampos.PARAMETRO01 = dr["COD_THABILITANTE"].ToString();
                                                oCampos.PARAMETRO02 = dr["MODALIDAD_TIPO"].ToString();
                                                oCampos.PARAMETRO03 = dr["THABILITANTE"].ToString();
                                                oCampos.NUMERO = dr["CNOTIFICACION"].ToString();
                                                oCampos.CODIGO = dr["COD_CNOTIFICACION"].ToString();
                                                lsCEntidad.Add(oCampos);
                                            }
                                            break;
                                        default:
                                            while (dr.Read())
                                            {
                                                oCampos = new CEntidad();
                                                oCampos.CODIGO = dr["COD_INFORME"].ToString();
                                                oCampos.NUMERO = dr["NUMERO"].ToString();
                                                oCampos.PARAMETRO01 = dr["CNOTIFICACION"].ToString();
                                                oCampos.PARAMETRO02 = dr["MODALIDAD_TIPO"].ToString();
                                                oCampos.PARAMETRO03 = dr["COD_THABILITANTE"].ToString();
                                                oCampos.PARAMETRO04 = dr["THABILITANTE"].ToString();
                                                oCampos.PARAMETRO05 = dr["COD_CNOTIFICACION"].ToString();
                                                oCampos.PARAMETRO06 = dr["COD_MTIPO"].ToString();
                                                oCampos.PARAMETRO08 = dr["ESTADO_ORIGEN"].ToString();
                                                oCampos.PARAMETRO10 = dr["FECHA"].ToString();
                                                lsCEntidad.Add(oCampos);
                                            }
                                            break;
                                    }
                                    break;
                                #endregion
                                #region INFORME_AUT_FORESTAL
                                case "INFORME_AUT_FORESTAL":
                                    while (dr.Read())
                                    {
                                        oCampos = new CEntidad();
                                        oCampos.CODIGO = dr["COD_INFORME"].ToString();
                                        oCampos.NUMERO = dr["NUM_INFORME"].ToString();
                                        oCampos.PARAMETRO01 = dr["ENTIDAD"].ToString();
                                        oCampos.PARAMETRO02 = dr["NUM_THABILITANTE"].ToString();
                                        oCampos.PARAMETRO03 = dr["MODALIDAD"].ToString();
                                        oCampos.PARAMETRO04 = dr["TITULAR"].ToString();
                                        oCampos.PARAMETRO05 = dr["NUM_POA"].ToString();
                                        oCampos.PARAMETRO10 = dr["FECHA"].ToString();
                                        lsCEntidad.Add(oCampos);
                                    }
                                    break;
                                #endregion
                                #region RENUNCIA_CONCESION
                                case "RENUNCIA_CONCESION":
                                    while (dr.Read())
                                    {
                                        oCampos = new CEntidad();
                                        oCampos.CODIGO = dr["COD_INFORME"].ToString();
                                        oCampos.NUMERO = dr["NUM_INFORME"].ToString();
                                        oCampos.PARAMETRO01 = dr["NUM_DOCUMENTO_AUTORIDAD"].ToString();
                                        oCampos.PARAMETRO02 = dr["NUM_THABILITANTE"].ToString();
                                        oCampos.PARAMETRO03 = dr["MODALIDAD"].ToString();
                                        oCampos.PARAMETRO04 = dr["TITULAR"].ToString();
                                        oCampos.PARAMETRO10 = dr["FECHA"].ToString();
                                        lsCEntidad.Add(oCampos);
                                    }
                                    break;
                                #endregion
                                #region OTROS_INFORMES
                                case "OTROS_INFORMES":
                                    while (dr.Read())
                                    {
                                        oCampos = new CEntidad();
                                        oCampos.CODIGO = dr["COD_INFORME"].ToString();
                                        oCampos.NUMERO = dr["NUM_INFORME"].ToString();
                                        oCampos.PARAMETRO01 = dr["ENTIDAD"].ToString();
                                        oCampos.PARAMETRO02 = dr["NUM_THABILITANTE"].ToString();
                                        oCampos.PARAMETRO03 = dr["MODALIDAD"].ToString();
                                        oCampos.PARAMETRO04 = dr["TITULAR"].ToString();
                                        oCampos.PARAMETRO05 = dr["NUM_POA"].ToString();
                                        oCampos.PARAMETRO06 = dr["TIPO_INFORME"].ToString();
                                        oCampos.PARAMETRO10 = dr["FECHA"].ToString();
                                        lsCEntidad.Add(oCampos);
                                    }
                                    break;
                                #endregion
                                #region DEVOLUCION_MADERA
                                case "DEVOLUCION_MADERA":
                                    switch (oCEntidad.BusCriterio)
                                    {
                                        case "GRI_TH_NUMERO":
                                            while (dr.Read())
                                            {
                                                oCampos = new CEntidad();
                                                oCampos.CODIGO = dr["COD_THABILITANTE"].ToString();
                                                oCampos.NUMERO = dr["NUM_THABILITANTE"].ToString();
                                                oCampos.PARAMETRO01 = dr["MODALIDAD"].ToString();
                                                oCampos.PARAMETRO02 = dr["PERSONA"].ToString();
                                                oCampos.PARAMETRO03 = dr["INDICADOR"].ToString();
                                                oCampos.PARAMETRO04 = dr["COD_MTIPO"].ToString();
                                                oCampos.PARAMETRO05 = dr["COD_UBIDEPARTAMENTO"].ToString();
                                                oCampos.PARAMETRO06 = dr["ESTADO_ORIGEN"].ToString();
                                                lsCEntidad.Add(oCampos);
                                            }
                                            break;
                                        case "GRI_TH_TITULAR":
                                            while (dr.Read())
                                            {
                                                oCampos = new CEntidad();
                                                oCampos.CODIGO = dr["COD_THABILITANTE"].ToString();
                                                oCampos.NUMERO = dr["NUM_THABILITANTE"].ToString();
                                                oCampos.PARAMETRO01 = dr["MODALIDAD"].ToString();
                                                oCampos.PARAMETRO02 = dr["PERSONA"].ToString();
                                                oCampos.PARAMETRO03 = dr["INDICADOR"].ToString();
                                                oCampos.PARAMETRO04 = dr["COD_MTIPO"].ToString();
                                                oCampos.PARAMETRO05 = dr["COD_UBIDEPARTAMENTO"].ToString();
                                                oCampos.PARAMETRO06 = dr["ESTADO_ORIGEN"].ToString();
                                                lsCEntidad.Add(oCampos);
                                            }
                                            break;
                                        default:
                                            while (dr.Read())
                                            {
                                                oCampos = new CEntidad();
                                                oCampos.CODIGO = dr["COD_DEVOLUCION"].ToString();
                                                oCampos.NUMERO = dr["NUM_RESOLUCION"].ToString();
                                                oCampos.PARAMETRO01 = dr["COD_THABILITANTE"].ToString();
                                                oCampos.PARAMETRO03 = dr["FECHA_RESOLUCION"].ToString();
                                                oCampos.PARAMETRO04 = dr["MODALIDAD"].ToString();
                                                oCampos.PARAMETRO05 = dr["PERSONA_FIRMA"].ToString();
                                                oCampos.PARAMETRO06 = dr["NUM_THABILITANTE"].ToString();
                                                oCampos.PARAMETRO07 = dr["PERSONA_TITULAR"].ToString();
                                                oCampos.PARAMETRO10 = dr["FECHA"].ToString();
                                                lsCEntidad.Add(oCampos);
                                            }
                                            break;
                                    }
                                    break;
                                #endregion
                                #region CAPACITACION
                                case "CAPACITACION":
                                    while (dr.Read())
                                    {
                                        oCampos = new CEntidad();
                                        oCampos.CODIGO = dr["COD_CAPACITACION"].ToString();
                                        oCampos.NUMERO = dr["NOMBRE"].ToString();
                                        oCampos.PARAMETRO02 = dr["TIPO_TALLER"].ToString();
                                        oCampos.PARAMETRO03 = dr["PARTICIPANTES"].ToString();
                                        oCampos.PARAMETRO04 = dr["COD_OD"].ToString();
                                        oCampos.PARAMETRO05 = dr["FECHA_INICIO"].ToString();
                                        oCampos.PARAMETRO06 = dr["REGISTRADOS"].ToString();
                                        oCampos.PARAMETRO10 = dr["FECHA"].ToString();
                                        lsCEntidad.Add(oCampos);
                                    }
                                    break;
                                #endregion
                                #region OTROS_EVENTOS
                                case "OTROS_EVENTOS":
                                    while (dr.Read())
                                    {
                                        oCampos = new CEntidad();
                                        oCampos.CODIGO = dr["COD_CAPACITACION"].ToString();
                                        oCampos.NUMERO = dr["NOMBRE"].ToString();
                                        oCampos.PARAMETRO02 = dr["TIPO_TALLER"].ToString();
                                        oCampos.PARAMETRO03 = dr["PARTICIPANTES"].ToString();
                                        oCampos.PARAMETRO04 = dr["COD_OD"].ToString();
                                        oCampos.PARAMETRO05 = dr["FECHA_INICIO"].ToString();
                                        oCampos.PARAMETRO06 = dr["REGISTRADOS"].ToString();
                                        oCampos.PARAMETRO10 = dr["FECHA"].ToString();
                                        lsCEntidad.Add(oCampos);
                                    }
                                    break;
                                #endregion
                                #region PROGRAMA_CAPACITACION
                                case "PROGRAMA_CAPACITACION":
                                    while (dr.Read())
                                    {
                                        oCampos = new CEntidad();
                                        oCampos.CODIGO = dr["COD_PCAPACITACION"].ToString();
                                        oCampos.PARAMETRO01 = dr["NOMBRE"].ToString();
                                        oCampos.PARAMETRO02 = dr["TIPO_TALLER"].ToString();
                                        oCampos.PARAMETRO04 = dr["OD"].ToString();
                                        oCampos.PARAMETRO05 = dr["FECHA_INICIO"].ToString();
                                        oCampos.PARAMETRO10 = dr["FECHA"].ToString();
                                        lsCEntidad.Add(oCampos);
                                    }
                                    break;
                                #endregion
                                #region INFORME_LEGAL
                                case "INFORME_LEGAL":
                                    while (dr.Read())
                                    {
                                        oCampos = new CEntidad();
                                        oCampos.CODIGO = dr["COD_ILEGAL"].ToString();
                                        oCampos.NUMERO = dr["ILEGAL_NUMERO"].ToString();
                                        oCampos.PARAMETRO02 = dr["TIPO_FISCALIZA"].ToString();
                                        oCampos.PARAMETRO03 = dr["NUMERO_INFORME"].ToString();
                                        oCampos.PARAMETRO04 = dr["NUMERO_RESOLUCION"].ToString();
                                        oCampos.PARAMETRO06 = dr["NUMERO_EXPEDIENTE"].ToString();
                                        oCampos.PARAMETRO10 = dr["FECHA"].ToString();
                                        lsCEntidad.Add(oCampos);
                                    }
                                    break;
                                #endregion
                                #region RESOLUCION_DIRECTORAL
                                case "RESOLUCION_DIRECTORAL":
                                    while (dr.Read())
                                    {
                                        oCampos = new CEntidad();
                                        oCampos.CODIGO = dr["COD_RESODIREC"].ToString();
                                        oCampos.NUMERO = dr["NUMERO_RESOLUCION"].ToString();
                                        oCampos.PARAMETRO01 = dr["TIPO_FISCALIZA"].ToString();
                                        oCampos.PARAMETRO02 = dr["COD_RESODIREC_INI_PAU"].ToString();
                                        oCampos.PARAMETRO03 = dr["NUMERO_EXPEDIENTE"].ToString();
                                        oCampos.PARAMETRO05 = dr["NUMERO_INFORME"].ToString();
                                        oCampos.PARAMETRO10 = dr["FECHA"].ToString();
                                        lsCEntidad.Add(oCampos);
                                    }
                                    break;
                                #endregion
                                #region INFORME_TECNICO
                                case "INFORME_TECNICO":
                                    while (dr.Read())
                                    {
                                        oCampos = new CEntidad();
                                        oCampos.CODIGO = dr["CODIGO"].ToString();
                                        oCampos.NUMERO = dr["NUMERO"].ToString();
                                        oCampos.PARAMETRO01 = dr["TIPO_FISCALIZA"].ToString();
                                        oCampos.PARAMETRO02 = dr["COD_RESODIREC"].ToString();
                                        oCampos.PARAMETRO04 = dr["NUMERO_EXPEDIENTE"].ToString();
                                        oCampos.PARAMETRO05 = dr["NUMERO_INFORME"].ToString();
                                        oCampos.PARAMETRO10 = dr["FECHA"].ToString();
                                        oCampos.PARAMETRO06 = dr["NUM_THABILITANTE"].ToString();
                                        oCampos.PARAMETRO07 = dr["TITULAR"].ToString();
                                        oCampos.PARAMETRO08 = dr["MODALIDAD"].ToString();
                                        lsCEntidad.Add(oCampos);
                                    }
                                    break;
                                #endregion
                                #region INFORME_TECNICO_EV
                                case "INFORME_TECNICO_EV":
                                    while (dr.Read())
                                    {
                                        oCampos = new CEntidad();
                                        oCampos.CODIGO = dr["CODIGO"].ToString();
                                        oCampos.NUMERO = dr["NUMERO"].ToString();
                                        oCampos.PARAMETRO01 = dr["TIPO_FISCALIZA"].ToString();
                                        oCampos.PARAMETRO05 = dr["NUM_INF_ACTIV"].ToString();
                                        oCampos.PARAMETRO10 = dr["FECHA"].ToString();
                                        lsCEntidad.Add(oCampos);
                                    }
                                    break;
                                #endregion
                                #region INFORME_TECNICO
                                case "INFORME_TECNICO_DENUNCIA":
                                    while (dr.Read())
                                    {
                                        oCampos = new CEntidad();
                                        oCampos.CODIGO = dr["CODIGO"].ToString();
                                        oCampos.NUMERO = dr["NUMERO"].ToString();
                                        oCampos.PARAMETRO01 = dr["TIPO_FISCALIZA"].ToString();
                                        oCampos.PARAMETRO04 = dr["APELLIDOS_NOMBRES"].ToString();
                                        oCampos.PARAMETRO05 = dr["NUMERO_INFORME"].ToString();
                                        oCampos.PARAMETRO10 = dr["FECHA"].ToString();
                                        oCampos.PARAMETRO06 = dr["NUM_THABILITANTE"].ToString();
                                        oCampos.PARAMETRO07 = dr["TITULAR"].ToString();
                                        oCampos.PARAMETRO08 = dr["MODALIDAD"].ToString();
                                        lsCEntidad.Add(oCampos);
                                    }
                                    break;
                                #endregion
                                #region INFORME_FUNDAMENTADO
                                case "INFORME_FUNDAMENTADO":
                                    while (dr.Read())
                                    {
                                        oCampos = new CEntidad();
                                        oCampos.CODIGO = dr["CODIGO"].ToString();
                                        oCampos.NUMERO = dr["NUMERO"].ToString();
                                        oCampos.PARAMETRO01 = dr["TIPO_FISCALIZA"].ToString();
                                        oCampos.PARAMETRO02 = dr["COD_RESODIREC"].ToString();
                                        oCampos.PARAMETRO04 = dr["NUMERO_EXPEDIENTE"].ToString();
                                        oCampos.PARAMETRO05 = dr["NUMERO_INFORME"].ToString();
                                        oCampos.PARAMETRO10 = dr["FECHA"].ToString();
                                        lsCEntidad.Add(oCampos);
                                    }
                                    break;
                                #endregion
                                #region FIS_NOTIFICACION
                                case "FIS_NOTIFICACION":
                                    while (dr.Read())
                                    {
                                        oCampos = new CEntidad();
                                        oCampos.CODIGO = dr["CODIGO"].ToString();
                                        oCampos.NUMERO = dr["NUMERO"].ToString();
                                        oCampos.PARAMETRO01 = dr["TIPO_FISCALIZA"].ToString();
                                        oCampos.PARAMETRO04 = dr["NUMERO_EXPEDIENTE"].ToString();
                                        oCampos.PARAMETRO05 = dr["NUMERO_RESOLUCION"].ToString();
                                        oCampos.PARAMETRO06 = dr["NUMERO_INFORME"].ToString();
                                        oCampos.PARAMETRO07 = dr["DESTINATARIO"].ToString();
                                        oCampos.PARAMETRO08 = dr["FECHA_NOTIFICACION"].ToString();
                                        oCampos.PARAMETRO10 = dr["FECHA"].ToString();
                                        lsCEntidad.Add(oCampos);
                                    }
                                    break;
                                #endregion
                                #region INFORMACION_TITULAR
                                case "INFORMACION_TITULAR":
                                    while (dr.Read())
                                    {
                                        oCampos = new CEntidad();
                                        oCampos.CODIGO = dr["CODIGO"].ToString();
                                        oCampos.NUMERO = dr["NUMERO"].ToString();
                                        oCampos.PARAMETRO01 = dr["TIPO_FISCALIZA"].ToString();
                                        oCampos.PARAMETRO02 = dr["NUMERO_RESOLUCION"].ToString();
                                        oCampos.PARAMETRO04 = dr["NUMERO_EXPEDIENTE"].ToString();
                                        oCampos.PARAMETRO05 = dr["NUMERO_INFORME"].ToString();
                                        oCampos.PARAMETRO06 = dr["REMITENTE"].ToString();
                                        oCampos.PARAMETRO07 = dr["TITULAR"].ToString();
                                        oCampos.PARAMETRO08 = dr["NUM_THABILITANTE"].ToString();
                                        oCampos.PARAMETRO10 = dr["FECHA"].ToString();
                                        oCampos.PARAMETRO08 = dr["NUM_THABILITANTE"].ToString();
                                        lsCEntidad.Add(oCampos);
                                    }
                                    break;
                                #endregion
                                #region DOC_REM_OTRA_INST
                                case "DOC_REM_OTRA_INST":
                                    while (dr.Read())
                                    {
                                        oCampos = new CEntidad();
                                        oCampos.CODIGO = dr["CODIGO"].ToString();
                                        oCampos.NUMERO = dr["NUMERO"].ToString();
                                        oCampos.PARAMETRO01 = dr["TIPO_FISCALIZA"].ToString();
                                        oCampos.PARAMETRO02 = dr["NUMERO_POA"].ToString();
                                        oCampos.PARAMETRO03 = dr["NUMERO_THABILITANTE"].ToString();
                                        oCampos.PARAMETRO10 = dr["FECHA"].ToString();
                                        lsCEntidad.Add(oCampos);
                                    }
                                    break;
                                #endregion
                                #region SOL_INTERNA
                                case "SOL_INTERNA":
                                    while (dr.Read())
                                    {
                                        oCampos = new CEntidad();
                                        oCampos.CODIGO = dr["CODIGO"].ToString();
                                        oCampos.NUMERO = dr["NUMERO"].ToString();
                                        oCampos.PARAMETRO01 = dr["TIPO_FISCALIZA"].ToString();
                                        oCampos.PARAMETRO02 = dr["NUMERO_INFORME"].ToString();
                                        oCampos.PARAMETRO03 = dr["NUMERO_THABILITANTE"].ToString();
                                        oCampos.PARAMETRO10 = dr["FECHA"].ToString();
                                        lsCEntidad.Add(oCampos);
                                    }
                                    break;
                                #endregion
                                #region SOL_EXTERNA
                                case "SOL_EXTERNA":
                                    while (dr.Read())
                                    {
                                        oCampos = new CEntidad();
                                        oCampos.CODIGO = dr["CODIGO"].ToString();
                                        oCampos.NUMERO = dr["NUMERO"].ToString();
                                        oCampos.PARAMETRO01 = dr["TIPO_FISCALIZA"].ToString();
                                        oCampos.PARAMETRO02 = dr["NUMERO_INFORME"].ToString();
                                        oCampos.PARAMETRO03 = dr["NUMERO_THABILITANTE"].ToString();
                                        oCampos.PARAMETRO04 = dr["COD_RESODIREC_INI_PAU"].ToString();
                                        oCampos.PARAMETRO06 = dr["NUMERO_EXPEDIENTE"].ToString();
                                        oCampos.PARAMETRO10 = dr["FECHA"].ToString();
                                        lsCEntidad.Add(oCampos);
                                    }
                                    break;
                                #endregion
                                #region PROVEIDO
                                case "PROVEIDO":
                                    while (dr.Read())
                                    {
                                        oCampos = new CEntidad();
                                        oCampos.CODIGO = dr["CODIGO"].ToString();
                                        oCampos.PARAMETRO03 = dr["DIRECCION_LINEA"].ToString();
                                        oCampos.PARAMETRO04 = dr["FUNCIONARIO"].ToString();
                                        oCampos.PARAMETRO05 = dr["PROFESIONAL"].ToString();
                                        oCampos.PARAMETRO06 = dr["FECHA_DERIVACION"].ToString();
                                        oCampos.PARAMETRO07 = dr["DOCUMENTO"].ToString();
                                        oCampos.PARAMETRO08 = dr["TIPO_DERIVACION"].ToString();
                                        oCampos.PARAMETRO09 = dr["INFORME"].ToString();
                                        lsCEntidad.Add(oCampos);
                                    }
                                    break;
                                #endregion
                                #region PROVEIDO_ARCHIVO
                                case "PROVEIDO_ARCHIVO":
                                    while (dr.Read())
                                    {
                                        oCampos = new CEntidad();
                                        oCampos.CODIGO = dr["CODIGO"].ToString();
                                        oCampos.NUMERO = dr["NUMERO"].ToString();
                                        oCampos.PARAMETRO01 = dr["TIPO_FISCALIZA"].ToString();
                                        oCampos.PARAMETRO02 = dr["NUMERO_INFORME"].ToString();
                                        oCampos.PARAMETRO05 = dr["NUMERO_EXPEDIENTE"].ToString();
                                        oCampos.PARAMETRO06 = dr["NUM_THABILITANTE"].ToString();
                                        oCampos.PARAMETRO07 = dr["TITULAR"].ToString();
                                        oCampos.PARAMETRO10 = dr["FECHA"].ToString();
                                        lsCEntidad.Add(oCampos);
                                    }
                                    break;
                                #endregion
                                #region GUIA_TRANSPORTE
                                case "GUIA_TRANSPORTE":
                                    switch (oCEntidad.BusCriterio)
                                    {
                                        case "GTF_TH_NUMERO":
                                            while (dr.Read())
                                            {
                                                oCampos = new CEntidad();
                                                oCampos.CODIGO = dr["COD_THABILITANTE"].ToString();
                                                oCampos.NUMERO = dr["NUMERO"].ToString();
                                                oCampos.PARAMETRO01 = dr["COD_TITULAR"].ToString();
                                                oCampos.PARAMETRO02 = dr["APELLIDOS_NOMBRES"].ToString();
                                                oCampos.PARAMETRO03 = dr["DOCUMENTO"].ToString();
                                                oCampos.PARAMETRO04 = dr["RUC"].ToString();
                                                oCampos.PARAMETRO05 = dr["DIRECCION"].ToString();
                                                oCampos.PARAMETRO06 = dr["NUMEROTELEFONICO"].ToString();
                                                oCampos.PARAMETRO07 = dr["COD_UBIGEO"].ToString();
                                                oCampos.PARAMETRO08 = dr["UBIGEONAME"].ToString();
                                                oCampos.PARAMETRO09 = dr["COD_RLEGAL"].ToString();
                                                oCampos.PARAMETRO10 = dr["REPRESENTANTE_LEGAL"].ToString();
                                                lsCEntidad.Add(oCampos);
                                            }


                                            break;
                                        default:
                                            while (dr.Read())
                                            {
                                                oCampos = new CEntidad();
                                                oCampos.CODIGO = dr["CODIGO"].ToString();
                                                oCampos.NUMERO = dr["NUMERO"].ToString();
                                                oCampos.PARAMETRO01 = dr["NOMBRE_GUIA"].ToString();
                                                oCampos.PARAMETRO02 = dr["FECHA_EXPEDICION"].ToString();
                                                oCampos.PARAMETRO03 = dr["NUMERO_THABILITANTE"].ToString();
                                                oCampos.PARAMETRO04 = dr["TITULAR"].ToString();
                                                oCampos.PARAMETRO06 = dr["NUM_POA"].ToString();
                                                oCampos.PARAMETRO07 = dr["COD_ZAFRA"].ToString();
                                                oCampos.PARAMETRO05 = dr["DESTINATARIO"].ToString();
                                                oCampos.PARAMETRO10 = dr["FECHA"].ToString();
                                                lsCEntidad.Add(oCampos);
                                            }

                                            break;

                                    }

                                    break;
                                #endregion
                                #region ACTIVIDAD
                                case "ACTIVIDAD":

                                    while (dr.Read())
                                    {
                                        oCampos = new CEntidad();
                                        oCampos.CODIGO = dr["COD_ACTIVIDAD"].ToString();
                                        oCampos.NUMERO = dr["NOMBRE"].ToString();
                                        oCampos.PARAMETRO01 = dr["DESCRIPCION"].ToString();
                                        oCampos.PARAMETRO11 = dr["ENTREGABLE"].ToString();
                                        oCampos.PARAMETRO02 = dr["PRIORIDAD"].ToString();
                                        oCampos.PARAMETRO03 = dr["FECHA_INICIO"].ToString();
                                        oCampos.PARAMETRO04 = dr["FECHA_FIN"].ToString();
                                        oCampos.PARAMETRO06 = dr["Tiempo_Restante"].ToString();
                                        oCampos.PARAMETRO09 = dr["Tiempo_Vencimiento"].ToString();
                                        oCampos.PARAMETRO07 = dr["ESTADO"].ToString();
                                        oCampos.PARAMETRO05 = dr["AVANCE"].ToString();
                                        oCampos.PARAMETRO08 = dr["OFICINA"].ToString();
                                        lsCEntidad.Add(oCampos);
                                    }
                                    break;
                                #endregion
                                #region ACTIVIDADOCI
                                case "ACTIVIDADOCI":

                                    while (dr.Read())
                                    {
                                        oCampos = new CEntidad();
                                        oCampos.CODIGO = dr["COD_ACTIVIDAD"].ToString();
                                        oCampos.NUMERO = dr["NOMBRE"].ToString();
                                        oCampos.PARAMETRO01 = dr["DESCRIPCION"].ToString();
                                        oCampos.PARAMETRO11 = dr["ENTREGABLE"].ToString();
                                        oCampos.PARAMETRO02 = dr["PRIORIDAD"].ToString();
                                        oCampos.PARAMETRO03 = dr["FECHA_INICIO"].ToString();
                                        oCampos.PARAMETRO04 = dr["FECHA_FIN"].ToString();
                                        oCampos.PARAMETRO06 = dr["Tiempo_Restante"].ToString();
                                        oCampos.PARAMETRO09 = dr["Tiempo_Vencimiento"].ToString();
                                        oCampos.PARAMETRO07 = dr["ESTADO"].ToString();
                                        oCampos.PARAMETRO05 = dr["AVANCE"].ToString();
                                        oCampos.PARAMETRO08 = dr["OFICINA"].ToString();
                                        lsCEntidad.Add(oCampos);
                                    }
                                    break;
                                #endregion
                                #region PRECIO_ESPECIES
                                case "PRECIO_ESPECIES":
                                    while (dr.Read())
                                    {
                                        oCampos = new CEntidad();
                                        oCampos.CODIGO = dr["CODIGO"].ToString();
                                        oCampos.NUMERO = dr["NOMBRE_LISTA_PRECIOS"].ToString();
                                        oCampos.PARAMETRO01 = dr["FECHA_SONDEO"].ToString();
                                        oCampos.PARAMETRO02 = dr["OD_DESCRIPCION"].ToString();
                                        oCampos.PARAMETRO03 = dr["USUARIO"].ToString();
                                        oCampos.PARAMETRO04 = dr["CANT_ESPECIES"].ToString();
                                        lsCEntidad.Add(oCampos);
                                    }
                                    break;
                                #endregion
                                #region TFFS
                                case "TFFS":
                                    while (dr.Read())
                                    {
                                        oCampos = new CEntidad();
                                        oCampos.CODIGO = dr["COD_RESOLUCION_TFFS"].ToString();
                                        oCampos.NUMERO = dr["NUM_RESOLUCION_TFFS"].ToString();
                                        oCampos.PARAMETRO02 = dr["NUM_RESOLUCION"].ToString();
                                        oCampos.PARAMETRO03 = dr["NUMERO_EXPEDIENTE"].ToString();
                                        oCampos.PARAMETRO04 = dr["FECHA"].ToString();
                                        oCampos.PARAMETRO05 = dr["NUM_THABILITANTE"].ToString();
                                        oCampos.PARAMETRO06 = dr["TITULAR"].ToString();
                                        oCampos.PARAMETRO07 = dr["MODALIDAD"].ToString();
                                        lsCEntidad.Add(oCampos);
                                    }
                                    break;
                                #endregion
                                #region REUNION
                                case "REUNION":
                                    while (dr.Read())
                                    {
                                        oCampos = new CEntidad();
                                        oCampos.CODIGO = dr["COD_REUNION"].ToString();
                                        oCampos.NUMERO = dr["REF_CONVOCATORIA"].ToString();
                                        oCampos.PARAMETRO01 = dr["FECHA_INICIO"].ToString();
                                        oCampos.PARAMETRO02 = dr["DURACION"].ToString();
                                        oCampos.PARAMETRO03 = dr["HORA_INICIO"].ToString();
                                        oCampos.PARAMETRO04 = dr["HORA_FIN"].ToString();
                                        oCampos.PARAMETRO05 = dr["LUGAR"].ToString();
                                        oCampos.PARAMETRO06 = dr["FECHA_FIN"].ToString();
                                        lsCEntidad.Add(oCampos);
                                    }
                                    break;
                                #endregion
                                #region PLAN_GENERAL_MANEJO_FORESTAL
                                case "PLAN_GENERAL_MANEJO_FORESTAL":
                                    while (dr.Read())
                                    {
                                        oCampos = new CEntidad();
                                        oCampos.CODIGO = dr["COD_PGMF"].ToString();
                                        oCampos.NUMERO = dr["RESOL_APROBACION"].ToString();
                                        oCampos.PARAMETRO01 = dr["FECHA_CREACION"].ToString();
                                        oCampos.PARAMETRO02 = dr["PERIODO"].ToString();
                                        oCampos.PARAMETRO03 = dr["NUM_THABILITANTE"].ToString();
                                        lsCEntidad.Add(oCampos);
                                    }
                                    break;
                                #endregion
                                #region PLAN_MANEJO_FORESTAL_INTERMEDIO
                                case "PLAN_MANEJO_FORESTAL_INTERMEDIO":
                                    while (dr.Read())
                                    {
                                        oCampos = new CEntidad();
                                        oCampos.CODIGO = dr["COD_PGMF"].ToString();
                                        oCampos.NUMERO = dr["RESOL_APROBACION"].ToString();
                                        oCampos.PARAMETRO01 = dr["FECHA_CREACION"].ToString();
                                        oCampos.PARAMETRO02 = dr["PERIODO"].ToString();
                                        oCampos.PARAMETRO03 = dr["NUM_THABILITANTE"].ToString();
                                        lsCEntidad.Add(oCampos);
                                    }
                                    break;
                                #endregion  
                                #region CRONOGRAMA_SUPERVISION
                                case "CRONOGRAMA_SUPERVISION":
                                    while (dr.Read())
                                    {
                                        oCampos = new CEntidad();
                                        oCampos.CODIGO = dr["COD_CSUPERVISION"].ToString();
                                        oCampos.NUMERO = dr["NUM_THABILITANTE"].ToString();
                                        oCampos.PARAMETRO01 = dr["FECHA_CREACION"].ToString();
                                        oCampos.PARAMETRO02 = dr["TITULAR"].ToString();
                                        oCampos.PARAMETRO03 = dr["MODALIDAD"].ToString();
                                        oCampos.PARAMETRO04 = dr["DEPARTAMENTO"].ToString();
                                        oCampos.PARAMETRO05 = dr["POA_PM"].ToString();
                                        oCampos.PARAMETRO06 = dr["SUPERVISOR"].ToString();
                                        oCampos.PARAMETRO07 = dr["ANIO"].ToString() + "-" + dr["MES"].ToString();
                                        oCampos.PARAMETRO08 = dr["NUM_DIA_SUPERV"].ToString();

                                        lsCEntidad.Add(oCampos);
                                    }
                                    break;
                                #endregion
                                #region PERSONA
                                case "PERSONA":
                                    while (dr.Read())
                                    {
                                        oCampos = new CEntidad();
                                        oCampos.CODIGO = dr["COD_PERSONA"].ToString();
                                        oCampos.PARAMETRO01 = dr["APELLIDOS_NOMBRES"].ToString();
                                        oCampos.PARAMETRO02 = dr["TIPO_DOCUMENTO"].ToString();
                                        oCampos.PARAMETRO03 = dr["N_DOCUMENTO"].ToString();
                                        oCampos.PARAMETRO04 = dr["TIPO_PERSONA"].ToString();
                                        oCampos.PARAMETRO05 = dr["ESTADO"].ToString();
                                        oCampos.PARAMETRO06 = dr["SEXO"].ToString();
                                        lsCEntidad.Add(oCampos);
                                    }
                                    break;
                                #endregion
                                #region USUARIO
                                case "USUARIO":
                                    while (dr.Read())
                                    {
                                        oCampos = new CEntidad();
                                        oCampos.CODIGO = dr["COD_UCUENTA"].ToString();
                                        oCampos.PARAMETRO01 = dr["USUARIO_LOGIN"].ToString();
                                        oCampos.PARAMETRO02 = dr["GRUPO"].ToString();
                                        oCampos.PARAMETRO03 = dr["APELLIDOS_NOMBRES"].ToString();
                                        oCampos.PARAMETRO04 = dr["ESTADO_ACTIVO"].ToString();

                                        lsCEntidad.Add(oCampos);
                                    }
                                    break;
                                #endregion
                                #region INFORME QUINQUENAL
                                case "INFORME QUINQUENAL":
                                    while (dr.Read())
                                    {
                                        oCampos = new CEntidad();
                                        oCampos.CODIGO = dr["COD_INFORME"].ToString();
                                        oCampos.NUMERO = dr["NUM_INFORME"].ToString();
                                        oCampos.PARAMETRO01 = dr["FECHA_CREACION"].ToString();
                                        oCampos.PARAMETRO02 = dr["TIPO"].ToString();
                                        oCampos.PARAMETRO03 = dr["RD_QUINQUENAL"].ToString();
                                        oCampos.PARAMETRO04 = dr["NUM_THABILITANTE"].ToString();
                                        oCampos.PARAMETRO05 = dr["TITULAR"].ToString();
                                        lsCEntidad.Add(oCampos);
                                    }
                                    break;
                                #endregion
                                #region IMEDIDA
                                case "IMEDIDA":
                                    while (dr.Read())
                                    {
                                        oCampos = new CEntidad();
                                        oCampos.CODIGO = dr["COD_INFORME"].ToString();
                                        oCampos.NUMERO = dr["NUM_INFORME"].ToString();
                                        oCampos.PARAMETRO01 = dr["TIPO_INFORME"].ToString();
                                        oCampos.PARAMETRO02 = dr["NUM_THABILITANTE"].ToString();
                                        oCampos.PARAMETRO03 = dr["MODALIDAD"].ToString();
                                        oCampos.PARAMETRO04 = dr["NUM_EXPEDIENTE"].ToString();
                                        oCampos.PARAMETRO05 = dr["TITULAR"].ToString();
                                        oCampos.PARAMETRO10 = dr["FECHA_CREACION"].ToString();
                                        lsCEntidad.Add(oCampos);
                                    }
                                    break;
                                #endregion
                                #region ACTIVIDADOFI
                                case "ACTIVIDADOFI":

                                    while (dr.Read())
                                    {
                                        oCampos = new CEntidad();
                                        oCampos.CODIGO = dr["COD_ACTIVIDAD"].ToString();
                                        oCampos.NUMERO = dr["NOMBRE"].ToString();
                                        oCampos.PARAMETRO01 = dr["DESCRIPCION"].ToString();
                                        oCampos.PARAMETRO11 = dr["ENTREGABLE"].ToString();
                                        oCampos.PARAMETRO02 = dr["PRIORIDAD"].ToString();
                                        oCampos.PARAMETRO03 = dr["FECHA_INICIO"].ToString();
                                        oCampos.PARAMETRO04 = dr["FECHA_FIN"].ToString();
                                        oCampos.PARAMETRO06 = dr["Tiempo_Restante"].ToString();
                                        oCampos.PARAMETRO09 = dr["Tiempo_Vencimiento"].ToString();
                                        oCampos.PARAMETRO07 = dr["ESTADO"].ToString();
                                        oCampos.PARAMETRO05 = dr["AVANCE"].ToString();
                                        oCampos.PARAMETRO08 = dr["OFICINA"].ToString();
                                        lsCEntidad.Add(oCampos);
                                    }
                                    break;
                                #endregion
                                #region PMFI
                                case "PMFI":
                                    switch (oCEntidad.BusCriterio)
                                    {
                                        case "GRI_TH_NUMERO":
                                        case "GRI_TH_TITULAR":
                                            while (dr.Read())
                                            {
                                                oCampos = new CEntidad();
                                                oCampos.CODIGO = dr["COD_THABILITANTE"].ToString();
                                                oCampos.NUMERO = dr["NUM_THABILITANTE"].ToString();
                                                oCampos.PARAMETRO01 = dr["MODALIDAD"].ToString();
                                                oCampos.PARAMETRO02 = dr["PERSONA"].ToString();
                                                oCampos.PARAMETRO03 = dr["INDICADOR"].ToString();
                                                oCampos.PARAMETRO04 = dr["COD_MTIPO"].ToString();
                                                oCampos.PARAMETRO05 = dr["COD_UBIDEPARTAMENTO"].ToString();
                                                oCampos.PARAMETRO06 = dr["ESTADO_ORIGEN"].ToString();
                                                oCampos.PARAMETRO11 = dr["REPRESENTANTE_LEGAL"].ToString();
                                                lsCEntidad.Add(oCampos);
                                            }
                                            break;
                                        default:
                                            while (dr.Read())
                                            {
                                                oCampos = new CEntidad();
                                                oCampos.CODIGO = dr["COD_THABILITANTE"].ToString();
                                                oCampos.NUMERO = dr["NUM_POA"].ToString();
                                                oCampos.PARAMETRO01 = dr["POA"].ToString();
                                                oCampos.PARAMETRO02 = dr["ARESOLUCION_NUM"].ToString();
                                                oCampos.PARAMETRO03 = dr["POA_PADRE"].ToString();
                                                oCampos.PARAMETRO04 = dr["COD_MTIPO"].ToString();
                                                oCampos.PARAMETRO05 = dr["MODALIDAD"].ToString();
                                                oCampos.PARAMETRO06 = dr["TITULAR"].ToString();
                                                oCampos.PARAMETRO07 = dr["NUM_THABILITANTE"].ToString();
                                                oCampos.PARAMETRO08 = dr["ESTADO_ORIGEN"].ToString();
                                                oCampos.PARAMETRO09 = dr["FECHA"].ToString();
                                                oCampos.PARAMETRO10 = dr["INDICADOR"].ToString();
                                                lsCEntidad.Add(oCampos);
                                            }
                                            break;
                                    }
                                    break;
                                #endregion
                                #region ACTIVIDADOTI
                                case "ACTIVIDADOTI":

                                    while (dr.Read())
                                    {
                                        oCampos = new CEntidad();
                                        oCampos.CODIGO = dr["COD_ACTIVIDAD"].ToString();
                                        oCampos.NUMERO = dr["NOMBRE"].ToString();
                                        oCampos.PARAMETRO01 = dr["DESCRIPCION"].ToString();
                                        oCampos.PARAMETRO11 = dr["ENTREGABLE"].ToString();
                                        oCampos.PARAMETRO02 = dr["PRIORIDAD"].ToString();
                                        oCampos.PARAMETRO03 = dr["FECHA_INICIO"].ToString();
                                        oCampos.PARAMETRO04 = dr["FECHA_FIN"].ToString();
                                        oCampos.PARAMETRO06 = dr["Tiempo_Restante"].ToString();
                                        oCampos.PARAMETRO09 = dr["Tiempo_Vencimiento"].ToString();
                                        oCampos.PARAMETRO07 = dr["ESTADO"].ToString();
                                        oCampos.PARAMETRO05 = dr["AVANCE"].ToString();
                                        oCampos.PARAMETRO08 = dr["OFICINA"].ToString();
                                        lsCEntidad.Add(oCampos);
                                    }
                                    break;
                                #endregion
                                #region RESOLUCION_DIRECTORAL_MANDATORIOS
                                case "RESOLUCION_DIRECTORAL_MANDATORIOS":
                                    while (dr.Read())
                                    {
                                        oCampos = new CEntidad();
                                        oCampos.CODIGO = dr["COD_RESODIREC"].ToString();
                                        oCampos.NUMERO = dr["NUMERO_RESOLUCION"].ToString();
                                        oCampos.PARAMETRO01 = dr["TIPO_FISCALIZA"].ToString();
                                        //oCampos.PARAMETRO02 = dr["COD_RESODIREC_INI_PAU"].ToString();
                                        oCampos.PARAMETRO03 = dr["NUMERO_EXPEDIENTE"].ToString();
                                        oCampos.PARAMETRO05 = dr["NUMERO_INFORME"].ToString();
                                        oCampos.PARAMETRO10 = dr["FECHA"].ToString();
                                        oCampos.TIPO_DOC = dr["TIPODOC"].ToString();
                                        oCampos.MANDATO = dr["MANDATO"].ToString();
                                        oCampos.DESDE = dr["DESDE"].ToString();
                                        oCampos.HASTA = dr["HASTA"].ToString();

                                        lsCEntidad.Add(oCampos);
                                        //oCampos = new CEntidad();
                                        //oCampos.CODIGO = dr["COD_RESODIREC"].ToString();
                                        //oCampos.NUMERO = dr["NUMERO_RESOLUCION"].ToString();
                                        //oCampos.PARAMETRO01 = dr["TIPO_FISCALIZA"].ToString();
                                        //oCampos.PARAMETRO02 = dr["COD_RESODIREC_INI_PAU"].ToString();
                                        //oCampos.PARAMETRO03 = dr["NUMERO_EXPEDIENTE"].ToString();
                                        //oCampos.PARAMETRO05 = dr["NUMERO_INFORME"].ToString();
                                        //oCampos.PARAMETRO10 = dr["FECHA"].ToString();
                                        //oCampos.MANDATO = dr["MANDATO"].ToString();
                                        //oCampos.DESDE = dr["DESDE"].ToString();
                                        //oCampos.HASTA = dr["HASTA"].ToString();
                                        //lsCEntidad.Add(oCampos);
                                    }
                                    break;
                                    #endregion
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
                        //01 Modalidad
                        lsDetDetalle = new List<CEntidad>();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                //PARTE_DIARIO_DETALLE
                                oCamposDet = new CEntidad();
                                oCamposDet.COD_FISCALIZACION_CATEGORIA = dr["CODIGO"].ToString();
                                oCamposDet.DESCRIPCION_CATEGORIA = dr["DESCRIPCION"].ToString();
                                oCamposDet.Orden_Categoria = Int32.Parse(dr["Orden_Categoria"].ToString());

                                lsDetDetalle.Add(oCamposDet);
                            }
                        }
                        oCampos.ListMComboCategoria = lsDetDetalle;
                        //02 Documento Identidad
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
                        //03 Estado Documento
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
                        //04 Oficinas Desconcentradas
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
                        //05 Tipo de Carta de Notificación
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
                        oCampos.ListTipoCNotificacion = lsDetDetalle;
                        // 06
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
                        oCampos.ListEstadoNotificacion = lsDetDetalle;
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
        public List<CEntidad> RegOpcionesCombo(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lsDetDetalle = new List<CEntidad>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.SPGENERAL_COMBO_LISTAR", oCEntidad))//"DOC_OSINFOR_ERP_MIGRACION.spGeneral_Combo_Listar"
                {
                    if (dr != null)
                    {
                        CEntidad oCamposDet;
                        //
                        //Modalidad
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
                    }
                }
                return lsDetDetalle;
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
        public CEntidad RegListasValidacion(OracleConnection cn, CEntidad oCEntidad)
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
                        //Especies
                        lsDetDetalle = new List<CEntidad>();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                //Especies
                                oCamposDet = new CEntidad();
                                oCamposDet.CODIGO = dr["CODIGO"].ToString();
                                oCamposDet.DESCRIPCION = dr["DESCRIPCION"].ToString();
                                lsDetDetalle.Add(oCamposDet);
                            }
                        }
                        oCampos.ListEspecies = lsDetDetalle;
                        //Titulos Habilitantes
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
                        oCampos.ListTH = lsDetDetalle;
                        //Especies NCientifico
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
                        oCampos.ListEspNCientifico = lsDetDetalle;
                        //Condición Maderable
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
                        oCampos.ListCondicionMad = lsDetDetalle;
                        //Condición No Maderable
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
                        oCampos.ListCondicionNoMad = lsDetDetalle;
                        //Estado Campo Maderable
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
                        oCampos.ListEstadoMad = lsDetDetalle;
                        //Estado Campo No Maderable
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
                        oCampos.ListEstadoNoMad = lsDetDetalle;
                        //Instituciones Capacitaciones
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
                        oCampos.ListInstitucionesCapac = lsDetDetalle;
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
        public Boolean permisoUsu(OracleConnection cn, CEntidad oCEntidad)
        {
            OracleTransaction tr = null;
            Boolean OUTPUTPARAM01 = false;
            try
            {
                tr = cn.BeginTransaction();
                using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, tr, "HERR.sfRLoginPermiso", oCEntidad))
                {
                    cmd.ExecuteNonQuery();
                    OUTPUTPARAM01 = (Boolean)cmd.Parameters["@RETURN_VALUE"].Value;
                    if (!OUTPUTPARAM01)
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("Ud. No tiene habilitado el acceso a esta opción");
                    }
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
        public List<CEntidad> regllenarEspecies(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DBO.lista_especies_excel", oCEntidad))
                {
                    if (dr != null)
                    {
                        CEntidad oCampos;
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                oCampos.COD_ESPECIES = dr["COD_ESP"].ToString();
                                oCampos.NOMBRE_CIENTIFICO = dr["NOM_CIENTIFICO"].ToString();
                                oCampos.DESCRIPCION = dr["NOM_COMUN"].ToString();
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
        /// metodo para listar parentesco
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public List<CEntidad> ListParentesco(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spGeneral_Combo_Listar", oCEntidad))
                {
                    if (dr != null)
                    {
                        CEntidad oCampos;
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                oCampos.CODIGO = dr["CODIGO"].ToString();
                                oCampos.DESCRIPCION = dr["DESCRIPCION"].ToString();
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

        public List<CEntidad> mostrarRegistrosUsuario(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spGeneral_Listar", oCEntidad))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            CEntidad oCampos;
                            switch (oCEntidad.BusFormulario)
                            {
                                #region TITULO_HABILITANTE
                                case "TITULO_HABILITANTE":
                                    while (dr.Read())
                                    {
                                        oCampos = new CEntidad();
                                        oCampos.CODIGO = dr["COD_THABILITANTE"].ToString();
                                        oCampos.NUMERO = dr["NUMERO"].ToString();
                                        oCampos.PARAMETRO01 = dr["MODALIDAD"].ToString();
                                        oCampos.PARAMETRO02 = dr["PERSONA_TITULAR"].ToString();
                                        oCampos.PARAMETRO03 = dr["PERSONA_RLEGAL"].ToString();
                                        oCampos.PARAMETRO04 = dr["REGION"].ToString();
                                        oCampos.PARAMETRO05 = dr["PROVINCIA"].ToString();
                                        oCampos.PARAMETRO06 = dr["DISTRITO"].ToString();
                                        oCampos.PARAMETRO07 = dr["OD_AMBITO"].ToString();
                                        oCampos.PARAMETRO08 = dr["OD_REGISTRO"].ToString();
                                        oCampos.PARAMETRO10 = dr["FECHA"].ToString();
                                        oCampos.PARAMETRO11 = dr["ANIO_REGISTRO"].ToString();
                                        oCampos.PARAMETRO12 = dr["MES_REGISTRO"].ToString();
                                        oCampos.PARAMETRO13 = dr["USUARIO"].ToString();
                                        oCampos.PARAMETRO14 = dr["CONTRATO_FECHA_INICIO"].ToString();
                                        oCampos.PARAMETRO15 = dr["CONTRATO_FECHA_FIN"].ToString();
                                        oCampos.PARAMETRO16 = dr["AREA"].ToString();
                                        oCampos.PARAMETRO17 = dr["ESTADO_DOCUMENTO"].ToString();
                                        oCampos.PARAMETRO18 = dr["TIPO_PERSONA"].ToString();
                                        oCampos.PARAMETRO19 = dr["SEXO"].ToString();
                                        lsCEntidad.Add(oCampos);
                                    }

                                    break;
                                #endregion
                                case "POA":
                                    while (dr.Read())
                                    {



                                        oCampos = new CEntidad();
                                        oCampos.CODIGO = dr["COD_THABILITANTE"].ToString();
                                        oCampos.NUMERO = dr["NUM_POA"].ToString();
                                        oCampos.PARAMETRO01 = dr["POA"].ToString();
                                        oCampos.PARAMETRO02 = dr["ARESOLUCION_NUM"].ToString();
                                        oCampos.PARAMETRO03 = dr["POA_PADRE"].ToString();
                                        oCampos.PARAMETRO04 = dr["COD_MTIPO"].ToString();
                                        oCampos.PARAMETRO05 = dr["MODALIDAD"].ToString();
                                        oCampos.PARAMETRO06 = dr["TITULAR"].ToString();
                                        oCampos.PARAMETRO07 = dr["NUM_THABILITANTE"].ToString();
                                        oCampos.PARAMETRO08 = dr["ESTADO_ORIGEN"].ToString();
                                        oCampos.PARAMETRO09 = dr["FECHA"].ToString();
                                        oCampos.PARAMETRO10 = dr["INDICADOR"].ToString();
                                        lsCEntidad.Add(oCampos);


                                    }
                                    break;
                                //case "PLAN_MANEJO":
                                //    while (dr.Read())
                                //    {
                                //    }
                                //    break;
                                #region DEMA
                                case "DEMA":
                                    while (dr.Read())
                                    {
                                        oCampos = new CEntidad();
                                        oCampos.CODIGO = dr["COD_THABILITANTE"].ToString();
                                        oCampos.NUMERO = dr["NUM_POA"].ToString();
                                        oCampos.PARAMETRO01 = dr["POA"].ToString();
                                        oCampos.PARAMETRO02 = dr["ARESOLUCION_NUM"].ToString();
                                        oCampos.PARAMETRO03 = dr["POA_PADRE"].ToString();
                                        oCampos.PARAMETRO04 = dr["COD_MTIPO"].ToString();
                                        oCampos.PARAMETRO05 = dr["MODALIDAD"].ToString();
                                        oCampos.PARAMETRO06 = dr["TITULAR"].ToString();
                                        oCampos.PARAMETRO07 = dr["NUM_THABILITANTE"].ToString();
                                        oCampos.PARAMETRO08 = dr["ESTADO_ORIGEN"].ToString();
                                        oCampos.PARAMETRO09 = dr["FECHA"].ToString();
                                        oCampos.PARAMETRO10 = dr["INDICADOR"].ToString();
                                        oCampos.PARAMETRO11 = dr["ANIO_REGISTRO"].ToString();
                                        oCampos.PARAMETRO12 = dr["MES_REGISTRO"].ToString();
                                        oCampos.PARAMETRO13 = dr["USUARIO"].ToString();
                                        lsCEntidad.Add(oCampos);
                                    }
                                    break;
                                #endregion
                                #region PMFI
                                case "PMFI":
                                    while (dr.Read())
                                    {
                                        oCampos = new CEntidad();
                                        oCampos.CODIGO = dr["COD_THABILITANTE"].ToString();
                                        oCampos.NUMERO = dr["NUM_POA"].ToString();
                                        oCampos.PARAMETRO01 = dr["POA"].ToString();
                                        oCampos.PARAMETRO02 = dr["ARESOLUCION_NUM"].ToString();
                                        oCampos.PARAMETRO03 = dr["POA_PADRE"].ToString();
                                        oCampos.PARAMETRO04 = dr["COD_MTIPO"].ToString();
                                        oCampos.PARAMETRO05 = dr["MODALIDAD"].ToString();
                                        oCampos.PARAMETRO06 = dr["TITULAR"].ToString();
                                        oCampos.PARAMETRO07 = dr["NUM_THABILITANTE"].ToString();
                                        oCampos.PARAMETRO08 = dr["ESTADO_ORIGEN"].ToString();
                                        oCampos.PARAMETRO09 = dr["FECHA"].ToString();
                                        oCampos.PARAMETRO10 = dr["INDICADOR"].ToString();
                                        oCampos.PARAMETRO11 = dr["ANIO_REGISTRO"].ToString();
                                        oCampos.PARAMETRO12 = dr["MES_REGISTRO"].ToString();
                                        oCampos.PARAMETRO13 = dr["USUARIO"].ToString();
                                        lsCEntidad.Add(oCampos);
                                    }
                                    break;
                                #endregion
                                #region BITACORA_SUPER
                                case "BITACORA_SUPER":
                                    while (dr.Read())
                                    {
                                        oCampos = new CEntidad();
                                        oCampos.CODIGO = dr["COD_BITACORA"].ToString();
                                        oCampos.NUMERO = dr["NUM_THABILITANTE"].ToString();
                                        oCampos.PARAMETRO01 = dr["OD"].ToString();
                                        oCampos.PARAMETRO02 = dr["SUPERVISOR"].ToString();
                                        oCampos.PARAMETRO03 = dr["CARTA_NOTIFICACION"].ToString();
                                        oCampos.PARAMETRO04 = dr["SUPERVISADO"].ToString();
                                        oCampos.PARAMETRO05 = dr["TIPO_INFORME"].ToString();
                                        oCampos.PARAMETRO06 = dr["FECHA"].ToString();
                                        oCampos.PARAMETRO11 = dr["ANIO_REGISTRO"].ToString();
                                        oCampos.PARAMETRO12 = dr["MES_REGISTRO"].ToString();
                                        oCampos.PARAMETRO13 = dr["USUARIO"].ToString();
                                        oCampos.PARAMETRO14 = dr["FECHA_HORA_SALIDA"].ToString();
                                        oCampos.PARAMETRO15 = dr["FECHA_RECEPCION_CHEQUE"].ToString();
                                        oCampos.PARAMETRO16 = dr["FECHA_COBRO_CHEQUE"].ToString();

                                        lsCEntidad.Add(oCampos);
                                    }
                                    break;
                                #endregion
                                #region ALERTA_OSINFOR
                                case "ALERTA_OSINFOR":
                                    while (dr.Read())
                                    {
                                        oCampos = new CEntidad();
                                        oCampos.CODIGO = dr["COD_BITACORA"].ToString();
                                        oCampos.NUMERO = dr["NUM_THABILITANTE"].ToString();
                                        oCampos.PARAMETRO01 = dr["OD"].ToString();
                                        oCampos.PARAMETRO02 = dr["SUPERVISOR"].ToString();
                                        oCampos.PARAMETRO03 = dr["CARTA_NOTIFICACION"].ToString();
                                        oCampos.PARAMETRO04 = dr["SUPERVISADO"].ToString();
                                        oCampos.PARAMETRO05 = dr["TIPO_INFORME"].ToString();
                                        oCampos.PARAMETRO06 = dr["FECHA"].ToString();
                                        oCampos.PARAMETRO07 = dr["ENVIAR_ALERTA_TEXT"].ToString();
                                        oCampos.PARAMETRO08 = dr["COD_THABILITANTE"].ToString();
                                        oCampos.PARAMETRO09 = dr["COD_SECUENCIAL"].ToString();
                                        oCampos.PARAMETRO11 = dr["ANIO_REGISTRO"].ToString();
                                        oCampos.PARAMETRO12 = dr["MES_REGISTRO"].ToString();
                                        oCampos.PARAMETRO13 = dr["USUARIO"].ToString();
                                        oCampos.PARAMETRO14 = dr["FECHA_SALIDA"].ToString();
                                        oCampos.PARAMETRO15 = dr["FECHA_LLEGADA"].ToString();
                                        lsCEntidad.Add(oCampos);
                                    }
                                    break;
                                #endregion
                                #region CARTA_NOTIFICACION
                                case "CARTA_NOTIFICACION":
                                    while (dr.Read())
                                    {
                                        oCampos = new CEntidad();
                                        oCampos.CODIGO = dr["COD_CNOTIFICACION"].ToString();
                                        oCampos.NUMERO = dr["NUMERO"].ToString();
                                        oCampos.PARAMETRO01 = dr["FECHA"].ToString();
                                        oCampos.PARAMETRO02 = dr["NUM_THABILITANTE"].ToString();
                                        oCampos.PARAMETRO03 = dr["TITULAR"].ToString();
                                        oCampos.PARAMETRO04 = dr["PERSONA_NOTIFICADOR"].ToString();
                                        oCampos.PARAMETRO05 = dr["ESTADO_ORIGEN"].ToString();
                                        oCampos.PARAMETRO06 = dr["COD_THABILITANTE"].ToString();
                                        oCampos.PARAMETRO07 = dr["M"].ToString();
                                        oCampos.PARAMETRO08 = dr["NM"].ToString();
                                        oCampos.PARAMETRO09 = dr["DTR"].ToString();
                                        oCampos.PARAMETRO10 = dr["DTO"].ToString();
                                        oCampos.PARAMETRO11 = dr["DAR"].ToString();
                                        oCampos.PARAMETRO12 = dr["MAE_CNTIPO"].ToString();
                                        oCampos.PARAMETRO14 = dr["ANIO_REGISTRO"].ToString();
                                        oCampos.PARAMETRO15 = dr["MES_REGISTRO"].ToString();
                                        oCampos.PARAMETRO13 = dr["USUARIO"].ToString();
                                        lsCEntidad.Add(oCampos);
                                    }
                                    break;
                                #endregion
                                #region INFORME_SUPERVISION
                                case "INFORME_SUPERVISION":
                                    while (dr.Read())
                                    {
                                        oCampos = new CEntidad();
                                        oCampos.CODIGO = dr["COD_INFORME"].ToString();
                                        oCampos.NUMERO = dr["NUMERO"].ToString();
                                        oCampos.PARAMETRO01 = dr["NUM_CNOTIFICACION"].ToString();
                                        oCampos.PARAMETRO02 = dr["MODALIDAD_TIPO"].ToString();
                                        oCampos.PARAMETRO03 = dr["NUM_THABILITANTE"].ToString();
                                        oCampos.PARAMETRO04 = dr["APELLIDOS_NOMBRES"].ToString();
                                        oCampos.PARAMETRO05 = dr["COD_CNOTIFICACION"].ToString();
                                        oCampos.PARAMETRO06 = dr["COD_MTIPO"].ToString();
                                        oCampos.PARAMETRO07 = dr["COD_THABILITANTE"].ToString();
                                        oCampos.PARAMETRO08 = dr["ESTADO_ORIGEN"].ToString();
                                        oCampos.PARAMETRO09 = dr["TITULAR"].ToString();
                                        oCampos.PARAMETRO10 = dr["FECHA"].ToString();
                                        oCampos.PARAMETRO11 = dr["POA"].ToString();
                                        oCampos.PARAMETRO12 = dr["DOC"].ToString();
                                        oCampos.PARAMETRO14 = dr["ANIO_REGISTRO"].ToString();
                                        oCampos.PARAMETRO15 = dr["MES_REGISTRO"].ToString();
                                        oCampos.PARAMETRO13 = dr["USUARIO"].ToString();
                                        lsCEntidad.Add(oCampos);
                                    }
                                    break;
                                #endregion
                                #region INFORME_SUSPENSION
                                case "INFORME_SUSPENSION":
                                    while (dr.Read())
                                    {
                                        oCampos = new CEntidad();
                                        oCampos.CODIGO = dr["COD_INFORME"].ToString();
                                        oCampos.NUMERO = dr["NUMERO"].ToString();
                                        oCampos.PARAMETRO01 = dr["CNOTIFICACION"].ToString();
                                        oCampos.PARAMETRO02 = dr["MODALIDAD_TIPO"].ToString();
                                        oCampos.PARAMETRO03 = dr["COD_THABILITANTE"].ToString();
                                        oCampos.PARAMETRO04 = dr["THABILITANTE"].ToString();
                                        oCampos.PARAMETRO05 = dr["COD_CNOTIFICACION"].ToString();
                                        oCampos.PARAMETRO06 = dr["COD_MTIPO"].ToString();
                                        oCampos.PARAMETRO07 = dr["SUPERVISION"].ToString();
                                        oCampos.PARAMETRO10 = dr["FECHA"].ToString();
                                        oCampos.PARAMETRO11 = dr["ANIO_REGISTRO"].ToString();
                                        oCampos.PARAMETRO12 = dr["MES_REGISTRO"].ToString();
                                        oCampos.PARAMETRO13 = dr["USUARIO"].ToString();
                                        lsCEntidad.Add(oCampos);
                                    }
                                    break;
                                #endregion
                                //case "INFORME_CANCELACION":
                                //    switch (oCEntidad.BusCriterio)
                                //    {
                                //    }
                                //    break;
                                #region INFORME_AUT_FORESTAL
                                case "INFORME_AUT_FORESTAL":
                                    while (dr.Read())
                                    {
                                        oCampos = new CEntidad();
                                        oCampos.CODIGO = dr["COD_INFORME"].ToString();
                                        oCampos.NUMERO = dr["NUM_INFORME"].ToString();
                                        oCampos.PARAMETRO01 = dr["ENTIDAD"].ToString();
                                        oCampos.PARAMETRO02 = dr["NUM_THABILITANTE"].ToString();
                                        oCampos.PARAMETRO03 = dr["MODALIDAD"].ToString();
                                        oCampos.PARAMETRO04 = dr["TITULAR"].ToString();
                                        oCampos.PARAMETRO05 = dr["NUM_POA"].ToString();
                                        oCampos.PARAMETRO10 = dr["FECHA"].ToString();
                                        oCampos.PARAMETRO11 = dr["ANIO_REGISTRO"].ToString();
                                        oCampos.PARAMETRO12 = dr["MES_REGISTRO"].ToString();
                                        oCampos.PARAMETRO13 = dr["USUARIO"].ToString();
                                        lsCEntidad.Add(oCampos);
                                    }
                                    break;
                                #endregion
                                #region RENUNCIA_CONCESION
                                case "RENUNCIA_CONCESION":
                                    while (dr.Read())
                                    {
                                        oCampos = new CEntidad();
                                        oCampos.CODIGO = dr["COD_INFORME"].ToString();
                                        oCampos.NUMERO = dr["NUM_INFORME"].ToString();
                                        oCampos.PARAMETRO01 = dr["NUM_DOCUMENTO_AUTORIDAD"].ToString();
                                        oCampos.PARAMETRO02 = dr["NUM_THABILITANTE"].ToString();
                                        oCampos.PARAMETRO03 = dr["MODALIDAD"].ToString();
                                        oCampos.PARAMETRO04 = dr["TITULAR"].ToString();
                                        oCampos.PARAMETRO10 = dr["FECHA"].ToString();
                                        oCampos.PARAMETRO11 = dr["ANIO_REGISTRO"].ToString();
                                        oCampos.PARAMETRO12 = dr["MES_REGISTRO"].ToString();
                                        oCampos.PARAMETRO13 = dr["USUARIO"].ToString();
                                        lsCEntidad.Add(oCampos);
                                    }
                                    break;
                                #endregion
                                #region OTROS_INFORMES
                                case "OTROS_INFORMES":
                                    while (dr.Read())
                                    {
                                        oCampos = new CEntidad();
                                        oCampos.CODIGO = dr["COD_INFORME"].ToString();
                                        oCampos.NUMERO = dr["NUM_INFORME"].ToString();
                                        oCampos.PARAMETRO01 = dr["ENTIDAD"].ToString();
                                        oCampos.PARAMETRO02 = dr["NUM_THABILITANTE"].ToString();
                                        oCampos.PARAMETRO03 = dr["MODALIDAD"].ToString();
                                        oCampos.PARAMETRO04 = dr["TITULAR"].ToString();
                                        oCampos.PARAMETRO05 = dr["NUM_POA"].ToString();
                                        oCampos.PARAMETRO06 = dr["TIPO_INFORME"].ToString();
                                        oCampos.PARAMETRO10 = dr["FECHA"].ToString();
                                        oCampos.PARAMETRO11 = dr["ANIO_REGISTRO"].ToString();
                                        oCampos.PARAMETRO12 = dr["MES_REGISTRO"].ToString();
                                        oCampos.PARAMETRO13 = dr["USUARIO"].ToString();
                                        lsCEntidad.Add(oCampos);
                                    }
                                    break;
                                #endregion
                                #region DEVOLUCION_MADERA
                                case "DEVOLUCION_MADERA":
                                    while (dr.Read())
                                    {
                                        oCampos = new CEntidad();
                                        oCampos.CODIGO = dr["COD_DEVOLUCION"].ToString();
                                        oCampos.NUMERO = dr["NUM_RESOLUCION"].ToString();
                                        oCampos.PARAMETRO01 = dr["COD_THABILITANTE"].ToString();
                                        oCampos.PARAMETRO03 = dr["FECHA_RESOLUCION"].ToString();
                                        oCampos.PARAMETRO04 = dr["MODALIDAD"].ToString();
                                        oCampos.PARAMETRO05 = dr["PERSONA_FIRMA"].ToString();
                                        oCampos.PARAMETRO06 = dr["NUM_THABILITANTE"].ToString();
                                        oCampos.PARAMETRO07 = dr["PERSONA_TITULAR"].ToString();
                                        oCampos.PARAMETRO10 = dr["FECHA"].ToString();
                                        oCampos.PARAMETRO11 = dr["ANIO_REGISTRO"].ToString();
                                        oCampos.PARAMETRO12 = dr["MES_REGISTRO"].ToString();
                                        oCampos.PARAMETRO13 = dr["USUARIO"].ToString();
                                        lsCEntidad.Add(oCampos);
                                    }
                                    break;
                                #endregion
                                case "CAPACITACION":
                                    while (dr.Read())
                                    {
                                        oCampos = new CEntidad();
                                        oCampos.CODIGO = dr["COD_CAPACITACION"].ToString();
                                        oCampos.NUMERO = dr["NOMBRE"].ToString();
                                        oCampos.PARAMETRO02 = dr["TIPO_TALLER"].ToString();
                                        oCampos.PARAMETRO03 = dr["PARTICIPANTES"].ToString();
                                        oCampos.PARAMETRO04 = dr["COD_OD"].ToString();
                                        oCampos.PARAMETRO05 = dr["FECHA_INICIO"].ToString();
                                        oCampos.PARAMETRO06 = dr["REGISTRADOS"].ToString();
                                        oCampos.PARAMETRO10 = dr["FECHA"].ToString();
                                        oCampos.PARAMETRO11 = dr["ANIO_REGISTRO"].ToString();
                                        oCampos.PARAMETRO12 = dr["MES_REGISTRO"].ToString();
                                        oCampos.PARAMETRO13 = dr["USUARIO"].ToString();
                                        lsCEntidad.Add(oCampos);
                                    }
                                    break;
                                case "OTROS_EVENTOS":
                                    while (dr.Read())
                                    {
                                        oCampos = new CEntidad();
                                        oCampos.CODIGO = dr["COD_CAPACITACION"].ToString();
                                        oCampos.NUMERO = dr["NOMBRE"].ToString();
                                        oCampos.PARAMETRO02 = dr["TIPO_TALLER"].ToString();
                                        oCampos.PARAMETRO03 = dr["PARTICIPANTES"].ToString();
                                        oCampos.PARAMETRO04 = dr["COD_OD"].ToString();
                                        oCampos.PARAMETRO05 = dr["FECHA_INICIO"].ToString();
                                        oCampos.PARAMETRO06 = dr["REGISTRADOS"].ToString();
                                        oCampos.PARAMETRO10 = dr["FECHA"].ToString();
                                        oCampos.PARAMETRO11 = dr["ANIO_REGISTRO"].ToString();
                                        oCampos.PARAMETRO12 = dr["MES_REGISTRO"].ToString();
                                        oCampos.PARAMETRO13 = dr["USUARIO"].ToString();
                                        lsCEntidad.Add(oCampos);
                                    }
                                    break;
                                #region INFORME_LEGAL
                                case "INFORME_LEGAL":
                                    while (dr.Read())
                                    {
                                        oCampos = new CEntidad();
                                        oCampos.CODIGO = dr["COD_ILEGAL"].ToString();
                                        oCampos.NUMERO = dr["ILEGAL_NUMERO"].ToString();
                                        oCampos.PARAMETRO02 = dr["TIPO_FISCALIZA"].ToString();
                                        oCampos.PARAMETRO03 = dr["NUMERO_INFORME"].ToString();
                                        oCampos.PARAMETRO04 = dr["NUMERO_RESOLUCION"].ToString();
                                        oCampos.PARAMETRO06 = dr["NUMERO_EXPEDIENTE"].ToString();
                                        oCampos.PARAMETRO10 = dr["FECHA"].ToString();
                                        oCampos.PARAMETRO11 = dr["ANIO_REGISTRO"].ToString();
                                        oCampos.PARAMETRO12 = dr["MES_REGISTRO"].ToString();
                                        oCampos.PARAMETRO13 = dr["USUARIO"].ToString();
                                        oCampos.PARAMETRO14 = dr["ANIO_INFORME"].ToString();
                                        lsCEntidad.Add(oCampos);
                                    }
                                    break;
                                #endregion
                                #region RESOLUCION_DIRECTORAL
                                case "RESOLUCION_DIRECTORAL":
                                    while (dr.Read())
                                    {
                                        oCampos = new CEntidad();
                                        oCampos.CODIGO = dr["COD_RESODIREC"].ToString();
                                        oCampos.NUMERO = dr["NUMERO_RESOLUCION"].ToString();
                                        oCampos.PARAMETRO01 = dr["TIPO_FISCALIZA"].ToString();
                                        oCampos.PARAMETRO02 = dr["COD_RESODIREC_INI_PAU"].ToString();
                                        oCampos.PARAMETRO03 = dr["NUMERO_EXPEDIENTE"].ToString();
                                        oCampos.PARAMETRO05 = dr["NUMERO_INFORME"].ToString();
                                        oCampos.PARAMETRO10 = dr["FECHA"].ToString();
                                        oCampos.PARAMETRO11 = dr["ANIO_REGISTRO"].ToString();
                                        oCampos.PARAMETRO12 = dr["MES_REGISTRO"].ToString();
                                        oCampos.PARAMETRO13 = dr["USUARIO"].ToString();
                                        lsCEntidad.Add(oCampos);
                                    }
                                    break;
                                #endregion
                                #region INFORME_TECNICO
                                case "INFORME_TECNICO":
                                    while (dr.Read())
                                    {
                                        oCampos = new CEntidad();
                                        oCampos.CODIGO = dr["CODIGO"].ToString();
                                        oCampos.NUMERO = dr["NUMERO"].ToString();
                                        oCampos.PARAMETRO01 = dr["TIPO_FISCALIZA"].ToString();
                                        oCampos.PARAMETRO02 = dr["COD_RESODIREC"].ToString();
                                        oCampos.PARAMETRO04 = dr["NUMERO_EXPEDIENTE"].ToString();
                                        oCampos.PARAMETRO05 = dr["NUMERO_INFORME"].ToString();
                                        oCampos.PARAMETRO10 = dr["FECHA"].ToString();
                                        oCampos.PARAMETRO06 = dr["NUM_THABILITANTE"].ToString();
                                        oCampos.PARAMETRO07 = dr["TITULAR"].ToString();
                                        oCampos.PARAMETRO08 = dr["MODALIDAD"].ToString();
                                        oCampos.PARAMETRO11 = dr["ANIO_REGISTRO"].ToString();
                                        oCampos.PARAMETRO12 = dr["MES_REGISTRO"].ToString();
                                        oCampos.PARAMETRO13 = dr["USUARIO"].ToString();
                                        lsCEntidad.Add(oCampos);
                                    }
                                    break;
                                #endregion
                                #region INFORME_FUNDAMENTADO
                                case "INFORME_FUNDAMENTADO":
                                    while (dr.Read())
                                    {
                                        oCampos = new CEntidad();
                                        oCampos.CODIGO = dr["CODIGO"].ToString();
                                        oCampos.NUMERO = dr["NUMERO"].ToString();
                                        oCampos.PARAMETRO01 = dr["TIPO_FISCALIZA"].ToString();
                                        oCampos.PARAMETRO02 = dr["COD_RESODIREC"].ToString();
                                        oCampos.PARAMETRO04 = dr["NUMERO_EXPEDIENTE"].ToString();
                                        oCampos.PARAMETRO05 = dr["NUMERO_INFORME"].ToString();
                                        oCampos.PARAMETRO10 = dr["FECHA"].ToString();
                                        oCampos.PARAMETRO11 = dr["ANIO_REGISTRO"].ToString();
                                        oCampos.PARAMETRO12 = dr["MES_REGISTRO"].ToString();
                                        oCampos.PARAMETRO13 = dr["USUARIO"].ToString();
                                        lsCEntidad.Add(oCampos);
                                    }
                                    break;
                                #endregion
                                #region FIS_NOTIFICACION
                                case "FIS_NOTIFICACION":
                                    while (dr.Read())
                                    {
                                        oCampos = new CEntidad();
                                        oCampos.CODIGO = dr["COD_FISNOTI"].ToString();
                                        oCampos.PARAMETRO01 = dr["FECHA_REGISTRO"].ToString();
                                        oCampos.PARAMETRO02 = dr["NUMERO_NOTIFICACION"].ToString();
                                        oCampos.PARAMETRO03 = dr["FEC_EMI"].ToString();
                                        oCampos.PARAMETRO04 = dr["FECHA_NOTIFICACION"].ToString();
                                        oCampos.PARAMETRO05 = dr["NUM_RESODIREC"].ToString();
                                        oCampos.PARAMETRO06 = dr["NUMERO_EXPEDIENTE"].ToString();
                                        oCampos.PARAMETRO07 = dr["NUM_INFORME"].ToString();
                                        oCampos.PARAMETRO08 = dr["DESTINATARIO"].ToString();
                                        oCampos.PARAMETRO09 = dr["USUARIO"].ToString();
                                        oCampos.PARAMETRO11 = dr["ANIO_REGISTRO"].ToString();
                                        oCampos.PARAMETRO12 = dr["MES_REGISTRO"].ToString();
                                        lsCEntidad.Add(oCampos);
                                    }
                                    break;
                                #endregion
                                #region INFORMACION_TITULAR
                                case "INFORMACION_TITULAR":
                                    while (dr.Read())
                                    {
                                        oCampos = new CEntidad();
                                        oCampos.CODIGO = dr["CODIGO"].ToString();
                                        oCampos.NUMERO = dr["NUMERO"].ToString();
                                        oCampos.PARAMETRO01 = dr["TIPO_FISCALIZA"].ToString();
                                        oCampos.PARAMETRO02 = dr["NUMERO_RESOLUCION"].ToString();
                                        oCampos.PARAMETRO04 = dr["NUMERO_EXPEDIENTE"].ToString();
                                        oCampos.PARAMETRO05 = dr["NUMERO_INFORME"].ToString();
                                        oCampos.PARAMETRO06 = dr["REMITENTE"].ToString();
                                        oCampos.PARAMETRO07 = dr["TITULAR"].ToString();
                                        oCampos.PARAMETRO08 = dr["NUM_THABILITANTE"].ToString();
                                        oCampos.PARAMETRO10 = dr["FECHA"].ToString();
                                        oCampos.PARAMETRO08 = dr["NUM_THABILITANTE"].ToString();
                                        oCampos.PARAMETRO11 = dr["ANIO_REGISTRO"].ToString();
                                        oCampos.PARAMETRO12 = dr["MES_REGISTRO"].ToString();
                                        oCampos.PARAMETRO13 = dr["USUARIO"].ToString();
                                        lsCEntidad.Add(oCampos);
                                    }
                                    break;
                                #endregion
                                #region DOC_REM_OTRA_INST
                                case "DOC_REM_OTRA_INST":
                                    while (dr.Read())
                                    {
                                        oCampos = new CEntidad();
                                        oCampos.CODIGO = dr["CODIGO"].ToString();
                                        oCampos.NUMERO = dr["NUMERO"].ToString();
                                        oCampos.PARAMETRO01 = dr["TIPO_FISCALIZA"].ToString();
                                        oCampos.PARAMETRO02 = dr["NUMERO_POA"].ToString();
                                        oCampos.PARAMETRO03 = dr["NUMERO_THABILITANTE"].ToString();
                                        oCampos.PARAMETRO10 = dr["FECHA"].ToString();
                                        oCampos.PARAMETRO11 = dr["ANIO_REGISTRO"].ToString();
                                        oCampos.PARAMETRO12 = dr["MES_REGISTRO"].ToString();
                                        oCampos.PARAMETRO13 = dr["USUARIO"].ToString();
                                        lsCEntidad.Add(oCampos);
                                    }
                                    break;
                                #endregion
                                #region SOL_INTERNA
                                case "SOL_INTERNA":
                                    while (dr.Read())
                                    {
                                        oCampos = new CEntidad();
                                        oCampos.CODIGO = dr["CODIGO"].ToString();
                                        oCampos.NUMERO = dr["NUMERO"].ToString();
                                        oCampos.PARAMETRO01 = dr["TIPO_FISCALIZA"].ToString();
                                        oCampos.PARAMETRO02 = dr["NUMERO_INFORME"].ToString();
                                        oCampos.PARAMETRO03 = dr["NUMERO_THABILITANTE"].ToString();
                                        oCampos.PARAMETRO10 = dr["FECHA"].ToString();
                                        oCampos.PARAMETRO11 = dr["ANIO_REGISTRO"].ToString();
                                        oCampos.PARAMETRO12 = dr["MES_REGISTRO"].ToString();
                                        oCampos.PARAMETRO13 = dr["USUARIO"].ToString();
                                        lsCEntidad.Add(oCampos);
                                    }
                                    break;
                                #endregion
                                #region SOL_EXTERNA
                                case "SOL_EXTERNA":
                                    while (dr.Read())
                                    {
                                        oCampos = new CEntidad();
                                        oCampos.CODIGO = dr["CODIGO"].ToString();
                                        oCampos.NUMERO = dr["NUMERO"].ToString();
                                        oCampos.PARAMETRO01 = dr["TIPO_FISCALIZA"].ToString();
                                        oCampos.PARAMETRO02 = dr["NUMERO_INFORME"].ToString();
                                        oCampos.PARAMETRO03 = dr["NUMERO_THABILITANTE"].ToString();
                                        oCampos.PARAMETRO04 = dr["COD_RESODIREC_INI_PAU"].ToString();
                                        oCampos.PARAMETRO06 = dr["NUMERO_EXPEDIENTE"].ToString();
                                        oCampos.PARAMETRO10 = dr["FECHA"].ToString();
                                        oCampos.PARAMETRO11 = dr["ANIO_REGISTRO"].ToString();
                                        oCampos.PARAMETRO12 = dr["MES_REGISTRO"].ToString();
                                        oCampos.PARAMETRO13 = dr["USUARIO"].ToString();
                                        lsCEntidad.Add(oCampos);
                                    }
                                    break;
                                #endregion
                                #region PROVEIDO
                                case "PROVEIDO":
                                    while (dr.Read())
                                    {
                                        oCampos = new CEntidad();
                                        oCampos.CODIGO = dr["CODIGO"].ToString();
                                        oCampos.PARAMETRO03 = dr["DIRECCION_LINEA"].ToString();
                                        oCampos.PARAMETRO04 = dr["FUNCIONARIO"].ToString();
                                        oCampos.PARAMETRO05 = dr["PROFESIONAL"].ToString();
                                        oCampos.PARAMETRO06 = dr["FECHA_DERIVACION"].ToString();
                                        oCampos.PARAMETRO07 = dr["DOCUMENTO"].ToString();
                                        oCampos.PARAMETRO08 = dr["TIPO_DERIVACION"].ToString();
                                        oCampos.PARAMETRO09 = dr["INFORME"].ToString();
                                        oCampos.PARAMETRO10 = dr["FECHA"].ToString();
                                        oCampos.PARAMETRO11 = dr["ANIO_REGISTRO"].ToString();
                                        oCampos.PARAMETRO12 = dr["MES_REGISTRO"].ToString();
                                        oCampos.PARAMETRO13 = dr["USUARIO"].ToString();
                                        lsCEntidad.Add(oCampos);
                                    }
                                    break;
                                #endregion
                                #region PROVEIDO_ARCHIVO
                                case "PROVEIDO_ARCHIVO":
                                    while (dr.Read())
                                    {
                                        oCampos = new CEntidad();
                                        oCampos.CODIGO = dr["CODIGO"].ToString();
                                        oCampos.NUMERO = dr["NUMERO"].ToString();
                                        oCampos.PARAMETRO01 = dr["TIPO_FISCALIZA"].ToString();
                                        oCampos.PARAMETRO02 = dr["NUMERO_INFORME"].ToString();
                                        oCampos.PARAMETRO05 = dr["NUMERO_EXPEDIENTE"].ToString();
                                        oCampos.PARAMETRO06 = dr["NUM_THABILITANTE"].ToString();
                                        oCampos.PARAMETRO07 = dr["TITULAR"].ToString();
                                        oCampos.PARAMETRO10 = dr["FECHA"].ToString();
                                        oCampos.PARAMETRO11 = dr["ANIO_REGISTRO"].ToString();
                                        oCampos.PARAMETRO12 = dr["MES_REGISTRO"].ToString();
                                        oCampos.PARAMETRO13 = dr["MODALIDAD"].ToString();
                                        oCampos.PARAMETRO14 = dr["USUARIO"].ToString();
                                        lsCEntidad.Add(oCampos);
                                    }
                                    break;
                                #endregion
                                #region GUIA_TRANSPORTE
                                case "GUIA_TRANSPORTE":
                                    while (dr.Read())
                                    {
                                        oCampos = new CEntidad();
                                        oCampos.CODIGO = dr["COD_GUIA_TRANSPORTE"].ToString();
                                        oCampos.PARAMETRO01 = dr["FECHA_REGISTRO"].ToString();
                                        oCampos.PARAMETRO02 = dr["NUMERO_GUIA"].ToString();
                                        oCampos.PARAMETRO03 = dr["NOMBRE_GUIA"].ToString();
                                        oCampos.PARAMETRO04 = dr["SEDE"].ToString();
                                        oCampos.PARAMETRO05 = dr["NUM_THABILITANTE"].ToString();
                                        oCampos.PARAMETRO06 = dr["TITULAR"].ToString();
                                        oCampos.PARAMETRO07 = dr["NUM_POA"].ToString();
                                        oCampos.PARAMETRO08 = dr["ZAFRA"].ToString();
                                        oCampos.PARAMETRO09 = dr["DESTINATARIO"].ToString();
                                        oCampos.PARAMETRO10 = dr["FECHA_EXPEDICION"].ToString();
                                        oCampos.PARAMETRO11 = dr["ANIO_REGISTRO"].ToString();
                                        oCampos.PARAMETRO12 = dr["MES_REGISTRO"].ToString();
                                        oCampos.PARAMETRO13 = dr["USUARIO"].ToString();


                                        oCampos.PARAMETRO14 = dr["COD_UBIGEOTH"].ToString();
                                        oCampos.PARAMETRO15 = dr["NOMBRE_UBIGEOTH"].ToString();
                                        oCampos.PARAMETRO16 = dr["FECHA_VENCIMIENTO"].ToString();
                                        oCampos.PARAMETRO17 = dr["DNI_TH"].ToString();
                                        oCampos.PARAMETRO18 = dr["RUC_TH"].ToString();
                                        oCampos.PARAMETRO19 = dr["DIRECCION_TH"].ToString();
                                        oCampos.PARAMETRO20 = dr["PROPIETARIO"].ToString();
                                        oCampos.PARAMETRO21 = dr["DNI_PROP"].ToString();
                                        oCampos.PARAMETRO22 = dr["RUC_PROP"].ToString();
                                        oCampos.PARAMETRO23 = dr["DIRECCION_PROP"].ToString();
                                        oCampos.PARAMETRO24 = dr["DNI_DEST"].ToString();
                                        oCampos.PARAMETRO25 = dr["RUC_DEST"].ToString();
                                        oCampos.PARAMETRO26 = dr["DIRECCION_DEST"].ToString();
                                        oCampos.PARAMETRO27 = dr["UBIGEO_DEST"].ToString();
                                        oCampos.PARAMETRO28 = dr["UBIGEO_NAME_DEST"].ToString();
                                        //oCampos.PARAMETRO29 = dr["RECIBO_PRODNATURAL"].ToString();
                                        //oCampos.PARAMETRO30 = dr["RECIBO_CANON"].ToString();
                                        //oCampos.PARAMETRO31 = dr["MONTO_PROD"].ToString();
                                        //oCampos.PARAMETRO32 = dr["MONTO_CANON"].ToString();
                                        //oCampos.PARAMETRO33 = dr["TIPO_TRANS"].ToString();
                                        //oCampos.PARAMETRO34 = dr["PLACA_VEHICULO"].ToString();

                                        //oCampos.PARAMETRO35 = dr["CONDUCTOR"].ToString();
                                        //oCampos.PARAMETRO36 = dr["LICENCIA"].ToString();
                                        //oCampos.PARAMETRO37 = dr["OBSERVACIONES_PROD"].ToString();
                                        //oCampos.PARAMETRO38 = dr["PESO_CARGA"].ToString();
                                        //oCampos.PARAMETRO39 = dr["OBSERVACIONES_GUIA"].ToString();
                                        oCampos.PARAMETRO40 = dr["DESPACHADOR"].ToString();
                                        oCampos.PARAMETRO41 = dr["AUTORIZANTE"].ToString();

                                        oCampos.PARAMETRO42 = dr["ORIGEN_RECURSO"].ToString();

                                        //oCampos.PARAMETRO42 = dr["ORIGEN_AUT"].ToString();
                                        //oCampos.PARAMETRO43 = dr["ORIGEN_BL"].ToString();
                                        //oCampos.PARAMETRO44 = dr["ORIGEN_CAMBUSO"].ToString();
                                        //oCampos.PARAMETRO45 = dr["ORIGEN_CONC"].ToString();
                                        //oCampos.PARAMETRO46 = dr["ORIGEN_DESBLOQUE"].ToString();
                                        //oCampos.PARAMETRO47 = dr["ORIGEN_OTROS"].ToString();
                                        //oCampos.PARAMETRO48 = dr["ORIGEN_PERM"].ToString();
                                        //oCampos.PARAMETRO49 = dr["ORIGEN_PLANTACION"].ToString();
                                        //oCampos.PARAMETRO50 = dr["ORIGEN_PMC"].ToString();
                                        oCampos.PARAMETRO51 = dr["DET_ORIGEN_OTROS"].ToString();
                                        oCampos.PARAMETRO52 = dr["REPRESENTANTE_LEGAL"].ToString();
                                        oCampos.PARAMETRO53 = dr["NUM_ARESOLUCION"].ToString();
                                        oCampos.PARAMETRO54 = dr["PLAN_MANEJO_TIPO"].ToString();
                                        //oCampos.PARAMETRO55 = dr["TIPO_COMPROBANTE"].ToString();
                                        //oCampos.PARAMETRO56 = dr["NUM_COMPROBANTE"].ToString();
                                        oCampos.PARAMETRO57 = dr["GTF_ARCHIVO"].ToString();



                                        lsCEntidad.Add(oCampos);
                                    }
                                    break;
                                #endregion
                                //case "ACTIVIDAD":
                                //    while (dr.Read())
                                //    {
                                //    }
                                //    break;
                                //case "ACTIVIDADOCI":
                                //    while (dr.Read())
                                //    {
                                //    }
                                //    break;
                                //case "PRECIO_ESPECIES":
                                //    while (dr.Read())
                                //    {
                                //    }
                                //    break;
                                #region TFFS
                                case "TFFS":
                                    while (dr.Read())
                                    {
                                        oCampos = new CEntidad();
                                        oCampos.CODIGO = dr["COD_RESOLUCION_TFFS"].ToString();
                                        oCampos.NUMERO = dr["NUM_RESOLUCION_TFFS"].ToString();
                                        oCampos.PARAMETRO02 = dr["NUM_RESOLUCION"].ToString();
                                        oCampos.PARAMETRO03 = dr["NUMERO_EXPEDIENTE"].ToString();
                                        oCampos.PARAMETRO04 = dr["FECHA"].ToString();
                                        oCampos.PARAMETRO05 = dr["NUM_THABILITANTE"].ToString();
                                        oCampos.PARAMETRO06 = dr["TITULAR"].ToString();
                                        oCampos.PARAMETRO07 = dr["MODALIDAD"].ToString();
                                        oCampos.PARAMETRO08 = dr["ANIO_REGISTRO"].ToString();
                                        oCampos.PARAMETRO09 = dr["MES_REGISTRO"].ToString();
                                        oCampos.PARAMETRO10 = dr["USUARIO"].ToString();
                                        lsCEntidad.Add(oCampos);
                                    }
                                    break;
                                #endregion
                                //    break;
                                //case "REUNION":
                                //    while (dr.Read())
                                //    {
                                //    }
                                //    break;
                                #region CRONOGRAMA_SUPERVISION
                                case "CRONOGRAMA_SUPERVISION":
                                    while (dr.Read())
                                    {
                                        oCampos = new CEntidad();
                                        oCampos.CODIGO = dr["COD_CSUPERVISION"].ToString();
                                        oCampos.NUMERO = dr["NUM_THABILITANTE"].ToString();
                                        oCampos.PARAMETRO01 = dr["FECHA_CREACION"].ToString();
                                        oCampos.PARAMETRO02 = dr["TITULAR"].ToString();
                                        oCampos.PARAMETRO03 = dr["MODALIDAD"].ToString();
                                        oCampos.PARAMETRO04 = dr["DEPARTAMENTO"].ToString();
                                        oCampos.PARAMETRO05 = dr["POA_PM"].ToString();
                                        oCampos.PARAMETRO06 = dr["SUPERVISOR"].ToString();
                                        oCampos.PARAMETRO07 = dr["ANIO"].ToString() + "-" + dr["MES"].ToString();
                                        oCampos.PARAMETRO08 = dr["NUM_DIA_SUPERV"].ToString();
                                        oCampos.PARAMETRO11 = dr["ANIO_REGISTRO"].ToString();
                                        oCampos.PARAMETRO12 = dr["MES_REGISTRO"].ToString();
                                        oCampos.PARAMETRO13 = dr["USUARIO"].ToString();
                                        lsCEntidad.Add(oCampos);
                                    }
                                    break;
                                #endregion
                                #region IMEDIDA
                                case "IMEDIDA":
                                    while (dr.Read())
                                    {
                                        oCampos = new CEntidad();
                                        oCampos.CODIGO = dr["COD_INFORME"].ToString();
                                        oCampos.NUMERO = dr["NUM_INFORME"].ToString();
                                        oCampos.PARAMETRO01 = dr["FECHA_CREACION"].ToString();
                                        oCampos.PARAMETRO02 = dr["ANIO_REGISTRO"].ToString();
                                        oCampos.PARAMETRO03 = dr["MES_REGISTRO"].ToString();
                                        oCampos.PARAMETRO04 = dr["TIPO_INFORME"].ToString();
                                        oCampos.PARAMETRO05 = dr["NUM_THABILITANTE"].ToString();
                                        oCampos.PARAMETRO06 = dr["TITULAR"].ToString();
                                        oCampos.PARAMETRO07 = dr["MODALIDAD"].ToString();
                                        oCampos.PARAMETRO08 = dr["NUM_EXPEDIENTE"].ToString();
                                        oCampos.PARAMETRO09 = dr["USUARIO"].ToString();
                                        lsCEntidad.Add(oCampos);
                                    }
                                    break;
                                #endregion

                                #region PROVEIDO_ARCHIVO_SUP
                                case "PROVEIDO_ARCHIVO_SUP":
                                        while (dr.Read())
                                    {
                                        oCampos = new CEntidad();
                                        oCampos.CODIGO = dr["CODIGO"].ToString();
                                        oCampos.NUMERO = dr["NUMERO"].ToString();
                                        oCampos.PARAMETRO01 = dr["TIPO_FISCALIZA"].ToString();
                                        oCampos.PARAMETRO02 = dr["FECHA"].ToString();
                                        oCampos.PARAMETRO03 = dr["FECHA_CREACION"].ToString();
                                        oCampos.PARAMETRO04 = dr["NUM_THABILITANTE"].ToString();
                                        oCampos.PARAMETRO05 = dr["TITULAR"].ToString();
                                        oCampos.PARAMETRO06 = dr["NUMERO_INFORME"].ToString();
                                        oCampos.PARAMETRO07 = dr["NUMERO_EXPEDIENTE"].ToString();
                                        oCampos.PARAMETRO08 = dr["MODALIDAD"].ToString();
                                        oCampos.PARAMETRO09 = dr["USUARIO"].ToString();
                                        lsCEntidad.Add(oCampos);
                                    }
                                    break;
                                    #endregion
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
        public void regTrackSIGO(OracleConnection cn, CEntidad CEntTrack)
        {
            OracleTransaction tr = null;
            try
            {
                tr = cn.BeginTransaction();
                //Grabando Cabecera
                using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spAUDITORIA_FORMULARIOGrabar", CEntTrack))
                {
                    cmd.ExecuteNonQuery();
                }
                //
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
        #region SIGOsfc v3
        public List<Dictionary<string, string>> CartaNotificacionGetAll(string criterio, string valorBusqueda, int currentPage, int pageSize, string sort, ref int rowCount)
        {
            List<Dictionary<string, string>> lstResult = new List<Dictionary<string, string>>();
            rowCount = 0;

            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, "DOC_OSINFOR_ERP_MIGRACION.USP_CNOTIFICACION_LISTAR", criterio, valorBusqueda, currentPage, pageSize, sort))
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

                                dr.NextResult();
                                if (dr.HasRows)
                                {
                                    if (dr.Read())
                                    {
                                        rowCount = Convert.ToInt32(dr["rowcount"].ToString());
                                    }
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
        public List<Dictionary<string, string>> InformeSupervisionGetAll(string criterio, string valorBusqueda, int currentPage, int pageSize, string sort, ref int rowCount)
        {
            List<Dictionary<string, string>> lstResult = new List<Dictionary<string, string>>();
            rowCount = 0;

            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, "DOC_OSINFOR_ERP_MIGRACION.USP_INFORME_SUPERVISION_LISTAR", criterio, valorBusqueda, currentPage, pageSize, sort))
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

                                dr.NextResult();
                                if (dr.HasRows)
                                {
                                    if (dr.Read())
                                    {
                                        rowCount = Convert.ToInt32(dr["rowcount"].ToString());
                                    }
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
        public List<Dictionary<string, string>> PAUGetAll(string criterio, string valorBusqueda, int currentPage, int pageSize, string sort, ref int rowCount)
        {
            List<Dictionary<string, string>> lstResult = new List<Dictionary<string, string>>();
            rowCount = 0;

            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, "DOC_OSINFOR_ERP_MIGRACION.SPFISCALIZACION_PAU_LISTAR", criterio, valorBusqueda, currentPage, pageSize, sort))
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

                                dr.NextResult();
                                if (dr.HasRows)
                                {
                                    if (dr.Read())
                                    {
                                        rowCount = Convert.ToInt32(dr["rowcount"].ToString());
                                    }
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
        public List<Dictionary<string, string>> MuestrasDendrologicasGetAll(string criterio, string valorBusqueda, int currentPage, int pageSize, string sort, ref int rowCount)
        {
            List<Dictionary<string, string>> lstResult = new List<Dictionary<string, string>>();
            rowCount = 0;

            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, "DOC_OSINFOR_ERP_MIGRACION.USP_MUESTRA_DENDROLOGICA_LISTAR_PAGING", criterio, valorBusqueda, currentPage, pageSize, sort))
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

                                dr.NextResult();
                                if (dr.HasRows)
                                {
                                    if (dr.Read())
                                    {
                                        rowCount = Convert.ToInt32(dr["rowcount"].ToString());
                                    }
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
        public List<Dictionary<string, string>> InformeQuinquenalGetAll(string criterio, string valorBusqueda, int currentPage, int pageSize, string sort, ref int rowCount)
        {
            List<Dictionary<string, string>> lstResult = new List<Dictionary<string, string>>();
            rowCount = 0;

            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, "DOC_OSINFOR_ERP_MIGRACION.USP_INFORME_QUINQUENAL_LISTAR", criterio, valorBusqueda, currentPage, pageSize, sort))
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

                                dr.NextResult();
                                if (dr.HasRows)
                                {
                                    if (dr.Read())
                                    {
                                        rowCount = Convert.ToInt32(dr["rowcount"].ToString());
                                    }
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
        public List<VM_Reporte> InformeQuinquenalReporte(string criterio, string valorBusqueda, int currentPage, int pageSize, string sort, ref int rowCount)
        {
            List<VM_Reporte> lstResult = new List<VM_Reporte>();
            rowCount = 0;

            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, "DOC_OSINFOR_ERP_MIGRACION.USP_INFORME_QUINQUENAL_LISTAR", criterio, valorBusqueda, currentPage, pageSize, sort))
                    {
                        if (dr != null)
                        {
                            if (dr.HasRows)
                            {
                                VM_Reporte sFila;
                               
                                while (dr.Read())
                                {
                                    sFila = new VM_Reporte();
                                    sFila.FECHA_CREACION = Convert.ToDateTime(dr["FECHA_CREACION"]);
                                    sFila.NUM_INFORME = dr["NUM_INFORME"].ToString();
                                    sFila.TIPO = dr["TIPO"].ToString();
                                    sFila.RD_QUINQUENAL = dr["RD_QUINQUENAL"].ToString();
                                    sFila.NUM_THABILITANTE = dr["NUM_THABILITANTE"].ToString();
                                    sFila.TITULAR = dr["TITULAR"].ToString();
                                    lstResult.Add(sFila);
                                }

                                dr.NextResult();
                                if (dr.HasRows)
                                {
                                    if (dr.Read())
                                    {
                                        rowCount = Convert.ToInt32(dr["rowcount"].ToString());
                                    }
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
        public List<Dictionary<string, string>> RegMostrarListaPaging(OracleConnection cn, CEntidad oCEntidad, ref int rowcount)
        {
            List<Dictionary<string, string>> lstResult = new List<Dictionary<string, string>>();
            rowcount = 0;

            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spGeneral_Listar_Paging", oCEntidad))
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

                            dr.NextResult();
                            if (dr.HasRows)
                            {
                                if (dr.Read())
                                {
                                    rowcount = Convert.ToInt32(dr["rowcount"].ToString());
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
        
        public List<Dictionary<string, string>> RegMostrarTHCalificacion(OracleConnection cn, CEntidad oCEntidad, ref int rowcount)
        {
            List<Dictionary<string, string>> lstResult = new List<Dictionary<string, string>>();
            rowcount = 0;

            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "doc_bd_observatorio_migracion.spCTH_Comportamiento_Listarv2", oCEntidad))
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

                            dr.NextResult();
                            if (dr.HasRows)
                            {
                                if (dr.Read())
                                {
                                    rowcount = Convert.ToInt32(dr["rowcount"].ToString());
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

        /// <summary>
        /// metodo que lista la lista de informe Legal
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <param name="rowcount"></param>
        /// <returns></returns>
        public List<Dictionary<string, string>> RegMostrarListaPaging_v3(OracleConnection cn, CEntidad oCEntidad, ref int rowcount)
        {
            List<Dictionary<string, string>> lstResult = new List<Dictionary<string, string>>();
            rowcount = 0;
            try
            {
                OracleTransaction tr = null;
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.CR_FISCA_GENERAL_LISTAR", oCEntidad))
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

                            dr.NextResult();
                            if (dr.HasRows)
                            {
                                if (dr.Read())
                                {
                                    rowcount = Convert.ToInt32(dr["totalRow"].ToString());
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
        public Select2PagedResult GetListComboPaging(Ent_BUSQUEDA_V3 ent)
        {
            Select2PagedResult vmSelect2 = new Select2PagedResult();
            vmSelect2.Results = new object();
            int rowcount = 0;
            List<Dictionary<string, string>> lstResult = new List<Dictionary<string, string>>();
            try
            {
                object[] param = {ent.BusFormulario,ent.BusCriterio,ent.BusValor,ent.currentpage,ent.pagesize," "," " };
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, "DOC_OSINFOR_ERP_MIGRACION.spGeneral_Listar_Paging", param))
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
                                        sColumn = dr.GetName(i).ToLower();
                                        sFila.Add(sColumn, dr[sColumn].ToString());
                                    }
                                    lstResult.Add(sFila);
                                }
                                dr.NextResult();
                                if (dr.HasRows)
                                {
                                    if (dr.Read())
                                    {
                                        rowcount = Convert.ToInt32(dr["rowcount"].ToString());
                                    }
                                }
                            }
                        }
                    }
                }
                vmSelect2.Results = lstResult;
                vmSelect2.Total = rowcount;
                return vmSelect2;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Consulta documentos del sistema documentario SITD         
        public List<Dictionary<string, string>> ListarDocumentosSITD_Paging(SqlConnection cn, CEntidad oCEntidad, ref int rowcount)
        {
            List<Dictionary<string, string>> lstResult = new List<Dictionary<string, string>>();
            rowcount = 0;

            try
            {
                using (SqlDataReader dr = oGDataSQL.SelDrdDefault(cn, null, "usp_Consultar_Documentos_SITD_PagingV3", oCEntidad))
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

                            dr.NextResult();
                            if (dr.HasRows)
                            {
                                if (dr.Read())
                                {
                                    rowcount = Convert.ToInt32(dr["rowcount"].ToString());
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
        public List<CEntidad> RegMostComboIndividual(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lstCampos = new List<CEntidad>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.uspGeneral_Combo_Listar_SigoV3", oCEntidad))
                {
                    if (dr != null)
                    {
                        CEntidad oCampos;

                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                oCampos.CODIGO = dr["CODIGO"].ToString();
                                oCampos.DESCRIPCION = dr["DESCRIPCION"].ToString();
                                lstCampos.Add(oCampos);
                            }
                        }
                    }
                }
                return lstCampos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<CEntidad> RegMostComboIndividual(CEntidad oCEntidad)
        {
            List<CEntidad> lstCampos = new List<CEntidad>();
            using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                try
                {
                    cn.Open();
                    using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.uspGeneral_Combo_Listar_SigoV3", oCEntidad))
                    {
                        if (dr != null)
                        {
                            CEntidad oCampos;

                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    oCampos = new CEntidad();
                                    oCampos.CODIGO = dr["CODIGO"].ToString();
                                    oCampos.DESCRIPCION = dr["DESCRIPCION"].ToString();
                                    lstCampos.Add(oCampos);
                                }
                            }
                        }
                    }
                    return lstCampos;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
        }
        public Select2PagedResult RegMostComboIndividualPaging(Ent_BUSQUEDA_V3 ent)
        {
            Select2PagedResult vmSelect2 = new Select2PagedResult();
            vmSelect2.Results = new object();
            int rowcount = 0;
            ent.v_pagesize = 10;
            List<Dictionary<string, string>> lstResult = new List<Dictionary<string, string>>();
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spGeneral_Combo_Listar_Paging", ent))
                    {
                        if (dr != null)
                        {
                            //if (ent.BusFormulario == "ESPECIES" )
                            //{
                            //    if (dr.HasRows)
                            //    {
                            //        Dictionary<string, string> sFila;
                            //        string sColumn = "";
                            //        while (dr.Read())
                            //        {
                            //            sFila = new Dictionary<string, int>();
                            //            for (int i = 0; i < dr.FieldCount; i++)
                            //            {
                            //                sColumn = dr.GetName(i);
                            //                if(sColumn=="ID")
                            //                    sFila.Add(sColumn, dr[sColumn].ToString());
                            //                else
                            //                    sFila.Add(sColumn, dr[sColumn].ToString());
                            //            }
                            //            lstResult.Add(sFila);
                            //        }
                            //        dr.NextResult();
                            //        if (dr.HasRows)
                            //        {
                            //            if (dr.Read())
                            //            {
                            //                rowcount = Convert.ToInt32(dr["rowcount"].ToString());
                            //            }
                            //        }
                            //    }
                            //}
                            //else
                            //{
                                if (dr.HasRows)
                                {
                                    Dictionary<string, string> sFila;
                                    string sColumn = "";
                                    while (dr.Read())
                                    {
                                        sFila = new Dictionary<string, string>();
                                        for (int i = 0; i < dr.FieldCount; i++)
                                        {
                                            sColumn = dr.GetName(i).ToLower();
                                            sFila.Add(sColumn.ToLower(), dr[sColumn].ToString());


                                        }
                                        lstResult.Add(sFila);
                                    }
                                    dr.NextResult();
                                    if (dr.HasRows)
                                    {
                                        if (dr.Read())
                                        {
                                            rowcount = Convert.ToInt32(dr["rowcount"].ToString());
                                        }
                                    }
                                }
                            //}

                                
                        }
                    }
                }
                vmSelect2.Results = lstResult;
                vmSelect2.Total = rowcount;
                return vmSelect2;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<VM_Cbo> RegMostComboIndividualV3(OracleConnection cn, CEntidad oCEntidad, bool addSeleccionar = false)
        {
            List<VM_Cbo> oCampos = new List<VM_Cbo>();
            if (addSeleccionar)
            {
                oCampos.Add(new VM_Cbo { Value = "-", Text = "(Seleccionar)" });
            }
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.uspGeneral_Combo_Listar_SigoV3", oCEntidad))
                {
                    if (dr != null)
                    {
                        VM_Cbo ocampoEnt;
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                ocampoEnt = new VM_Cbo();
                                ocampoEnt.Value = dr["CODIGO"].ToString();
                                ocampoEnt.Text = dr["DESCRIPCION"].ToString();
                                switch (oCEntidad.BusCriterio)
                                {
                                    case "Motivo_Exsitu": ocampoEnt.Tipo = dr["TIPO"].ToString(); break;
                                }
                                oCampos.Add(ocampoEnt);
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
        public VM_ValidacionFormatos RegListasValidacionV3(OracleConnection cn, CEntidad oCEntidad)
        {
            VM_ValidacionFormatos oCampos = null;
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spGeneral_Combo_Listar", oCEntidad))
                {
                    if (dr != null)
                    {
                        oCampos = new VM_ValidacionFormatos();
                        //List<VM_Cbo> lsDetDetalle;
                        //Condición  Maderable
                        VM_Cbo oCamposDet;
                        if (dr.HasRows)
                        {
                            oCampos.ListCondicionMad = new List<VM_Cbo>();
                            while (dr.Read())
                            {
                                oCamposDet = new VM_Cbo();
                                oCamposDet.Value = dr["CODIGO"].ToString();
                                oCamposDet.Text = dr["DESCRIPCION"].ToString();
                                oCampos.ListCondicionMad.Add(oCamposDet);
                            }
                        }
                        //Condición No Maderable
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            oCampos.ListCondicionNoMad = new List<VM_Cbo>();
                            while (dr.Read())
                            {
                                oCamposDet = new VM_Cbo();
                                oCamposDet.Value = dr["CODIGO"].ToString();
                                oCamposDet.Text = dr["DESCRIPCION"].ToString();
                                oCampos.ListCondicionNoMad.Add(oCamposDet);
                            }
                        }
                        //Estado Campo Maderable
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            oCampos.ListEstadoMad = new List<VM_Cbo>();
                            while (dr.Read())
                            {
                                oCamposDet = new VM_Cbo();
                                oCamposDet.Value = dr["CODIGO"].ToString();
                                oCamposDet.Text = dr["DESCRIPCION"].ToString();
                                oCampos.ListEstadoMad.Add(oCamposDet);
                            }
                        }
                        //Estado Campo No Maderable
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            oCampos.ListEstadoNoMad = new List<VM_Cbo>();
                            while (dr.Read())
                            {
                                oCamposDet = new VM_Cbo();
                                oCamposDet.Value = dr["CODIGO"].ToString();
                                oCamposDet.Text = dr["DESCRIPCION"].ToString();
                                oCampos.ListEstadoNoMad.Add(oCamposDet);
                            }
                        }
                        //Instituciones Capacitaciones
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            oCampos.ListInstitucionesCapac = new List<VM_Cbo>();
                            while (dr.Read())
                            {
                                oCamposDet = new VM_Cbo();
                                oCamposDet.Value = dr["CODIGO"].ToString();
                                oCamposDet.Text = dr["DESCRIPCION"].ToString();
                                oCampos.ListInstitucionesCapac.Add(oCamposDet);
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
        public List<VM_Cbo> RegMostComboSupervision(string BUSFORMULARIO,string BUSCRITERIO,string BUSVALOR)
        {
            List<VM_Cbo> lstCampos = new List<VM_Cbo>();
            using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                try
                {
                    cn.Open();
                    using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, "DOC_OSINFOR_ERP_MIGRACION.USP_COMBO_LISTAR_SUPERVISION", BUSFORMULARIO,BUSCRITERIO,BUSVALOR))
                    {
                        if (dr != null)
                        {
                            VM_Cbo oCampos;

                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    oCampos = new VM_Cbo();
                                    oCampos.Value = dr["CODIGO"].ToString();
                                    oCampos.Text = dr["DESCRIPCION"].ToString();
                                    lstCampos.Add(oCampos);
                                }
                            }
                        }
                    }
                    return lstCampos;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
        }
        #endregion
        #region "Control de calidad"
        public CapaEntidad.ViewModel.VM_ControlCalidad obtenerObservacionControlCalidadV3(CEntidad oCEntidad)
        {
            CapaEntidad.ViewModel.VM_ControlCalidad oCampos = new CapaEntidad.ViewModel.VM_ControlCalidad();
            using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
            {
                try
                {
                    cn.Open();
                    using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.usp_ObtenerControlCalidad_SigoV3", oCEntidad))
                    {
                        if (dr != null)
                        {
                            if (dr.HasRows)
                            {
                                dr.Read();
                                oCampos.COD_ESTADO_DOC = dr.GetString(dr.GetOrdinal("COD_ESTADO_DOC"));
                                oCampos.OBSERVACIONES_CONTROL = dr.GetString(dr.GetOrdinal("OBSERVACIONES_CONTROL"));
                                oCampos.OBSERV_SUBSANAR = dr.GetBoolean(dr.GetOrdinal("OBSERV_SUBSANAR"));
                                oCampos.USUARIO_CONTROL = dr.GetString(dr.GetOrdinal("USUARIO_CONTROL"));

                            }
                            else
                            {
                                oCampos.COD_ESTADO_DOC = "";
                                oCampos.OBSERVACIONES_CONTROL = "";
                                oCampos.OBSERV_SUBSANAR = false;
                                oCampos.USUARIO_CONTROL = "";
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
        public CapaEntidad.ViewModel.VM_ControlCalidad_2 obtenerControlCalidadV3(CEntidad oCEntidad)
        {
            CapaEntidad.ViewModel.VM_ControlCalidad_2 oCampos = new CapaEntidad.ViewModel.VM_ControlCalidad_2();
            using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
            {
                try
                {
                    cn.Open();
                    using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.usp_ObtenerControlCalidad_SigoV3", oCEntidad))
                    {
                        if (dr != null)
                        {
                            if (dr.HasRows)
                            {
                                dr.Read();

                                oCampos.txtUsuarioRegistro = dr.GetString(dr.GetOrdinal("USUARIO_REGISTRO"));
                                oCampos.COD_ESTADO_DOC = dr.GetString(dr.GetOrdinal("COD_ESTADO_DOC"));
                                oCampos.txtControlCalidadObservaciones = dr.GetString(dr.GetOrdinal("OBSERVACIONES_CONTROL"));
                                oCampos.chkObsSubsanada = dr.GetBoolean(dr.GetOrdinal("OBSERV_SUBSANAR"));
                                oCampos.txtUsuarioControl = dr.GetString(dr.GetOrdinal("USUARIO_CONTROL"));

                            }
                            else
                            {
                                oCampos.COD_ESTADO_DOC = "";
                                oCampos.txtControlCalidadObservaciones = "";
                                oCampos.chkObsSubsanada = false;
                                oCampos.txtUsuarioRegistro = "";
                                oCampos.txtUsuarioControl = "";
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
        #endregion

        #region oracle
        public List<VM_Cbo> RegMostComboIndividual_v3(OracleConnection cn, CEntidad oCEntidad)
        {
            List<VM_Cbo> lstCampos = new List<VM_Cbo>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.CR_FISCA_GENERAL_LISTAR", oCEntidad))
                {
                    if (dr != null)
                    {
                        VM_Cbo oCampos;

                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCampos = new VM_Cbo();
                                oCampos.Value = dr["CODIGO"].ToString();
                                oCampos.Text = dr["DESCRIPCION"].ToString();
                                lstCampos.Add(oCampos);
                            }
                        }
                    }
                }
                return lstCampos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Expediente
        public List<CEntidad> BuscarExpediente(CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spGeneral_Listar_Paging", oCEntidad))
                    {
                        if (dr != null)
                        {
                            CEntidad oCampos;
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    oCampos = new CEntidad();
                                    oCampos.EXPEDIENTE = dr["EXPEDIENTE"].ToString();
                                    oCampos.ADMINISTRADO = dr["ADMINISTRADO"].ToString();
                                    oCampos.TIPO_DOC = dr["TIPO_DOC"].ToString();
                                    oCampos.THABILITANTE = dr["THABILITANTE"].ToString();
                                    lsCEntidad.Add(oCampos);
                                }
                            }
                        }
                    }
                    return lsCEntidad;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}