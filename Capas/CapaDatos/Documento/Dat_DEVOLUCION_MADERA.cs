using GeneralSQL;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using CEntidad = CapaEntidad.DOC.Ent_DEVOLUCION_MADERA;
using CEntPersona = CapaEntidad.DOC.Ent_GENEPERSONA;
using SQL = GeneralSQL.Data.SQL;
/// <summary>
/// </summary>
namespace CapaDatos.DOC
{
    /// <summary>
    /// 
    /// </summary>
    public class Dat_DEVOLUCION_MADERA
    {
        private SQL oGDataSQL = new SQL();
        private DBOracle dBOracle = new DBOracle();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        //public CEntidad RegMostrarListaItems(SqlConnection cn, CEntidad oCEntidad)
        //{
        //    CEntidad oCampos = new CEntidad();
        //    try
        //    {
        //        using (SqlDataReader dr = oGDataSQL.SelDrdDefault(cn, null, "DOC.spDEV_MADMostItemsPrueba", oCEntidad))
        //        {
        //            if (dr != null)
        //            {
        //                oCampos.ListNUM_POA = new List<CEntidad>();
        //                oCampos.ListESPDEVUELTAS = new List<CEntidad>();
        //                oCampos.ListPINFTEC = new List<CEntidad>();
        //                oCampos.ListVERTICE = new List<CEntidad>();
        //                oCampos.ListESPHALLADAS = new List<CEntidad>();
        //                oCampos.ListBEXTRACCION = new List<CEntidad>();
        //                oCampos.ListDEVOLCENSOTROZA = new List<CEntidad>();
        //                oCampos.ListDEVOLCENSOTOCON = new List<CEntidad>();
        //                oCampos.ListDEVOLCENSOARBOL = new List<CEntidad>();
        //                oCampos.ListEliTABLA = new List<CEntidad>();
        //                CEntidad oCamposDet;
        //                //
        //                if (dr.HasRows)
        //                {
        //                    dr.Read();
        //                    oCampos.COD_THABILITANTE = dr.GetString(dr.GetOrdinal("COD_THABILITANTE"));
        //                    oCampos.COD_MTIPO = dr.GetString(dr.GetOrdinal("COD_MTIPO"));
        //                    oCampos.MODALIDAD = dr.GetString(dr.GetOrdinal("MODALIDAD"));
        //                    oCampos.NUM_THABILITANTE = dr.GetString(dr.GetOrdinal("NUM_THABILITANTE"));
        //                    oCampos.PERSONA_TITULAR = dr.GetString(dr.GetOrdinal("PERSONA_TITULAR"));
        //                    oCampos.COD_DEVOLUCION = dr.GetString(dr.GetOrdinal("COD_DEVOLUCION"));
        //                    oCampos.COD_PERSONA_FIRMA = dr.GetString(dr.GetOrdinal("COD_PERSONA_FIRMA"));
        //                    oCampos.PERSONA_FIRMA = dr.GetString(dr.GetOrdinal("PERSONA_FIRMA"));
        //                    oCampos.NUM_RESOLUCION = dr.GetString(dr.GetOrdinal("NUM_RESOLUCION"));
        //                    oCampos.FECHA_RESOLUCION = dr.GetString(dr.GetOrdinal("FECHA_RESOLUCION"));
        //                    oCampos.ZAFRA_EJECUTAR = dr.GetString(dr.GetOrdinal("ZAFRA_EJECUTAR"));
        //                    oCampos.INICIO_PERIODO_EJECUCION = dr.GetString(dr.GetOrdinal("INICIO_PERIODO_EJECUCION"));
        //                    oCampos.FIN_PERIODO_EJECUCION = dr.GetString(dr.GetOrdinal("FIN_PERIODO_EJECUCION"));
        //                    oCampos.FECHA_EMISION_BEXTRACCION = dr.GetString(dr.GetOrdinal("FECHA_EMISION_BEXTRACCION"));
        //                    oCampos.TIENE_POA = dr.GetBoolean(dr.GetOrdinal("TIENE_POA"));
        //                    //
        //                    oCampos.COD_ESTADO_DOC = dr.GetString(dr.GetOrdinal("COD_ESTADO_DOC"));
        //                    oCampos.OBSERVACIONES_CONTROL = dr.GetString(dr.GetOrdinal("OBSERVACIONES_CONTROL"));
        //                    oCampos.OBSERV_SUBSANAR = dr.GetBoolean(dr.GetOrdinal("OBSERV_SUBSANAR"));
        //                    oCampos.COD_OD_REGISTRO = dr.GetString(dr.GetOrdinal("COD_OD_REGISTRO"));

        //                    oCampos.USUARIO_REGISTRO = dr.GetString(dr.GetOrdinal("USUARIO_REGISTRO"));
        //                    oCampos.USUARIO_CONTROL = dr.GetString(dr.GetOrdinal("USUARIO_CONTROL"));
        //                }
        //                //DOC.POA_VS_DEV_MAD
        //                dr.NextResult();
        //                if (dr.HasRows)
        //                {
        //                    int pt1 = dr.GetOrdinal("NUM_POA");
        //                    int pt2 = dr.GetOrdinal("NUM_PCOMPLEMENTARIO");
        //                    int pt3 = dr.GetOrdinal("ESTADO_ORIGEN");
        //                    while (dr.Read())
        //                    {
        //                        oCamposDet = new CEntidad();
        //                        oCamposDet.NUM_POA = dr.GetInt32(pt1);
        //                        oCamposDet.NUM_PCOMPLEMENTARIO = dr.GetInt32(pt2);
        //                        oCamposDet.ESTADO_ORIGEN = dr.GetString(pt3);
        //                        oCamposDet.RegEstado = 0;
        //                        oCampos.ListNUM_POA.Add(oCamposDet);
        //                    }
        //                }
        //                //DOC.DEV_MAD_DET_ESP_DEVUELTAS
        //                dr.NextResult();
        //                if (dr.HasRows)
        //                {
        //                    int pt1 = dr.GetOrdinal("COD_ESPECIES");
        //                    int pt2 = dr.GetOrdinal("ESPECIES");
        //                    int pt3 = dr.GetOrdinal("COD_SECUENCIAL");
        //                    int pt4 = dr.GetOrdinal("VOLUMEN");
        //                    int pt5 = dr.GetOrdinal("NUM_TROZAS");
        //                    int pt6 = dr.GetOrdinal("COORDENADA_ESTE");
        //                    int pt7 = dr.GetOrdinal("COORDENADA_NORTE");
        //                    int pt8 = dr.GetOrdinal("OBSERVACION");
        //                    while (dr.Read())
        //                    {
        //                        oCamposDet = new CEntidad();
        //                        oCamposDet.COD_ESPECIES = dr.GetString(pt1);
        //                        oCamposDet.ESPECIES = dr.GetString(pt2);
        //                        oCamposDet.COD_SECUENCIAL = dr.GetInt32(pt3);
        //                        oCamposDet.VOLUMEN = Decimal.Parse(dr.GetString(pt4));
        //                        oCamposDet.NUM_TROZAS = dr.GetInt32(pt5);
        //                        oCamposDet.COORDENADA_ESTE = dr.GetInt32(pt6);
        //                        oCamposDet.COORDENADA_NORTE = dr.GetInt32(pt7);
        //                        oCamposDet.OBSERVACION = dr.GetString(pt8);
        //                        oCamposDet.RegEstado = 0;
        //                        oCampos.ListESPDEVUELTAS.Add(oCamposDet);
        //                    }
        //                }

        //                //DOC.DEV_MAD_DET_PINFTEC
        //                dr.NextResult();
        //                if (dr.HasRows)
        //                {

        //                    int pt1 = dr.GetOrdinal("NUMERO_INFORME");
        //                    int pt2 = dr.GetOrdinal("FECHA_INFORME");
        //                    int pt3 = dr.GetOrdinal("COD_PERSONA");
        //                    int pt4 = dr.GetOrdinal("PERSONA");
        //                    int pt5 = dr.GetOrdinal("N_DOCUMENTO");
        //                    int pt6 = dr.GetOrdinal("CARGO");
        //                    while (dr.Read())
        //                    {
        //                        oCamposDet = new CEntidad();
        //                        oCamposDet.NUM_INFORME = dr.GetString(pt1);
        //                        oCamposDet.FECHA_INFORME = dr.GetString(pt2);
        //                        oCamposDet.COD_PERSONA = dr.GetString(pt3);
        //                        oCamposDet.PERSONA = dr.GetString(pt4);
        //                        oCamposDet.N_DOCUMENTO = dr.GetString(pt5);
        //                        oCamposDet.CARGO = dr.GetString(pt6);
        //                        oCamposDet.RegEstado = 0;
        //                        oCampos.ListPINFTEC.Add(oCamposDet);
        //                    }
        //                }

        //                //DOC.DEV_MAD_DET_VERTICE
        //                dr.NextResult();
        //                if (dr.HasRows)
        //                {
        //                    int pt1 = dr.GetOrdinal("VERTICE");
        //                    int pt2 = dr.GetOrdinal("COORDENADA_ESTE");
        //                    int pt3 = dr.GetOrdinal("COORDENADA_NORTE");
        //                    int pt4 = dr.GetOrdinal("OBSERVACION");
        //                    int pt5 = dr.GetOrdinal("COD_SECUENCIAL");
        //                    while (dr.Read())
        //                    {
        //                        oCamposDet = new CEntidad();
        //                        oCamposDet.VERTICE = dr.GetString(pt1);
        //                        oCamposDet.COORDENADA_ESTE = dr.GetInt32(pt2);
        //                        oCamposDet.COORDENADA_NORTE = dr.GetInt32(pt3);
        //                        oCamposDet.OBSERVACION = dr.GetString(pt4);
        //                        oCamposDet.COD_SECUENCIAL = dr.GetInt32(pt5);
        //                        oCamposDet.RegEstado = 0;
        //                        oCampos.ListVERTICE.Add(oCamposDet);
        //                    }
        //                }
        //                //DOC.DEV_MAD_DET_ESP_HALLADAS
        //                dr.NextResult();
        //                if (dr.HasRows)
        //                {
        //                    int pt1 = dr.GetOrdinal("COD_ESPECIES");
        //                    int pt2 = dr.GetOrdinal("ESPECIES");
        //                    int pt3 = dr.GetOrdinal("COD_SECUENCIAL");
        //                    int pt4 = dr.GetOrdinal("VOLUMEN");
        //                    int pt5 = dr.GetOrdinal("NUM_TROZAS");
        //                    int pt6 = dr.GetOrdinal("COORDENADA_ESTE");
        //                    int pt7 = dr.GetOrdinal("COORDENADA_NORTE");
        //                    int pt8 = dr.GetOrdinal("OBSERVACION");
        //                    while (dr.Read())
        //                    {
        //                        oCamposDet = new CEntidad();
        //                        oCamposDet.COD_ESPECIES = dr.GetString(pt1);
        //                        oCamposDet.ESPECIES = dr.GetString(pt2);
        //                        oCamposDet.COD_SECUENCIAL = dr.GetInt32(pt3);
        //                        oCamposDet.VOLUMEN = Decimal.Parse(dr.GetString(pt4));
        //                        oCamposDet.NUM_TROZAS = dr.GetInt32(pt5);
        //                        oCamposDet.COORDENADA_ESTE = dr.GetInt32(pt6);
        //                        oCamposDet.COORDENADA_NORTE = dr.GetInt32(pt7);
        //                        oCamposDet.OBSERVACION = dr.GetString(pt8);
        //                        oCamposDet.RegEstado = 0;
        //                        oCampos.ListESPHALLADAS.Add(oCamposDet);
        //                    }
        //                }
        //                //DOC.DEV_MAD_DET_BEXTRACCION
        //                dr.NextResult();
        //                if (dr.HasRows)
        //                {
        //                    int pt1 = dr.GetOrdinal("COD_ESPECIES");
        //                    int pt2 = dr.GetOrdinal("COD_SECUENCIAL");
        //                    int pt3 = dr.GetOrdinal("ESPECIES");
        //                    int pt4 = dr.GetOrdinal("VOLUMEN_AUTORIZADO");
        //                    int pt5 = dr.GetOrdinal("VOLUMEN_MOVILIZADO");
        //                    int pt6 = dr.GetOrdinal("SALDO");
        //                    int pt7 = dr.GetOrdinal("OBSERVACION");
        //                    while (dr.Read())
        //                    {
        //                        oCamposDet = new CEntidad();
        //                        oCamposDet.COD_ESPECIES = dr.GetString(pt1);
        //                        oCamposDet.COD_SECUENCIAL = dr.GetInt32(pt2);
        //                        oCamposDet.ESPECIES = dr.GetString(pt3);
        //                        oCamposDet.VOLUMEN_AUTORIZADO = Decimal.Parse(dr.GetString(pt4));
        //                        oCamposDet.VOLUMEN_MOVILIZADO = Decimal.Parse(dr.GetString(pt5));
        //                        oCamposDet.SALDO = Decimal.Parse(dr.GetString(pt6));
        //                        oCamposDet.OBSERVACION = dr.GetString(pt7);
        //                        oCamposDet.RegEstado = 0;
        //                        oCampos.ListBEXTRACCION.Add(oCamposDet);
        //                    }
        //                }
        //                //DOC.DEV_MAD_DET_CENSO_TROZA
        //                dr.NextResult();
        //                if (dr.HasRows)
        //                {
        //                    int pt1 = dr.GetOrdinal("COD_ESPECIES");
        //                    int pt2 = dr.GetOrdinal("COD_SECUENCIAL");
        //                    int pt3 = dr.GetOrdinal("ESPECIES");
        //                    int pt4 = dr.GetOrdinal("DAP");
        //                    int pt5 = dr.GetOrdinal("CODIGO");
        //                    int pt6 = dr.GetOrdinal("ALTURA");
        //                    int pt7 = dr.GetOrdinal("VOLUMEN");
        //                    int pt8 = dr.GetOrdinal("COORDENADA_ESTE");
        //                    int pt9 = dr.GetOrdinal("COORDENADA_NORTE");
        //                    int pt10 = dr.GetOrdinal("NUM_TROZAS");
        //                    int pt11 = dr.GetOrdinal("DESCRIPCION");
        //                    int pt12 = dr.GetOrdinal("OBSERVACION");
        //                    Int32 num_fila = 0;
        //                    while (dr.Read())
        //                    {
        //                        oCamposDet = new CEntidad();
        //                        oCampos.NUMERO_FILA = num_fila;
        //                        oCamposDet.COD_ESPECIES = dr.GetString(pt1);
        //                        oCamposDet.COD_SECUENCIAL = dr.GetInt32(pt2);
        //                        oCamposDet.ESPECIES = dr.GetString(pt3);
        //                        oCamposDet.DAP = Decimal.Parse(dr.GetString(pt4));
        //                        oCamposDet.CODIGO = dr.GetString(pt5);
        //                        oCamposDet.ALTURA = Decimal.Parse(dr.GetString(pt6));
        //                        oCamposDet.VOLUMEN = Decimal.Parse(dr.GetString(pt7));
        //                        oCamposDet.COORDENADA_ESTE = dr.GetInt32(pt8);
        //                        oCamposDet.COORDENADA_NORTE = dr.GetInt32(pt9);
        //                        oCamposDet.NUM_TROZAS = dr.GetInt32(pt10);
        //                        oCamposDet.DESCRIPCION = dr.GetString(pt11);
        //                        oCamposDet.OBSERVACION = dr.GetString(pt12);
        //                        oCamposDet.RegEstado = 0;
        //                        oCampos.ListDEVOLCENSOTROZA.Add(oCamposDet);
        //                        num_fila++;
        //                    }
        //                }
        //                //DOC.DEV_MAD_DET_CENSO_TOCON
        //                dr.NextResult();
        //                if (dr.HasRows)
        //                {
        //                    int pt1 = dr.GetOrdinal("COD_ESPECIES");
        //                    int pt2 = dr.GetOrdinal("COD_SECUENCIAL");
        //                    int pt3 = dr.GetOrdinal("ESPECIES");
        //                    int pt4 = dr.GetOrdinal("DIAMETRO");
        //                    int pt5 = dr.GetOrdinal("CODIGO");
        //                    int pt6 = dr.GetOrdinal("LARGO");
        //                    int pt7 = dr.GetOrdinal("VOLUMEN");
        //                    int pt8 = dr.GetOrdinal("COORDENADA_ESTE");
        //                    int pt9 = dr.GetOrdinal("COORDENADA_NORTE");
        //                    int pt10 = dr.GetOrdinal("CANTIDAD");
        //                    int pt11 = dr.GetOrdinal("DESCRIPCION");
        //                    int pt12 = dr.GetOrdinal("OBSERVACION");
        //                    Int32 num_fila = 0;
        //                    while (dr.Read())
        //                    {
        //                        oCamposDet = new CEntidad();
        //                        oCampos.NUMERO_FILA = num_fila;
        //                        oCamposDet.COD_ESPECIES = dr.GetString(pt1);
        //                        oCamposDet.COD_SECUENCIAL = dr.GetInt32(pt2);
        //                        oCamposDet.ESPECIES = dr.GetString(pt3);
        //                        oCamposDet.DIAMETRO = Decimal.Parse(dr.GetString(pt4));
        //                        oCamposDet.CODIGO = dr.GetString(pt5);
        //                        oCamposDet.LARGO = Decimal.Parse(dr.GetString(pt6));
        //                        oCamposDet.VOLUMEN = Decimal.Parse(dr.GetString(pt7));
        //                        oCamposDet.COORDENADA_ESTE = dr.GetInt32(pt8);
        //                        oCamposDet.COORDENADA_NORTE = dr.GetInt32(pt9);
        //                        oCamposDet.CANTIDAD = dr.GetInt32(pt10);
        //                        oCamposDet.DESCRIPCION = dr.GetString(pt11);
        //                        oCamposDet.OBSERVACION = dr.GetString(pt12);
        //                        oCamposDet.RegEstado = 0;
        //                        oCampos.ListDEVOLCENSOTOCON.Add(oCamposDet);
        //                        num_fila++;
        //                    }
        //                }
        //                //DOC.DEV_MAD_DET_CENSO_ARBOL
        //                dr.NextResult();
        //                if (dr.HasRows)
        //                {
        //                    int pt1 = dr.GetOrdinal("COD_ESPECIES");
        //                    int pt2 = dr.GetOrdinal("COD_SECUENCIAL");
        //                    int pt3 = dr.GetOrdinal("NUM_PCA");
        //                    int pt4 = dr.GetOrdinal("ESPECIES");
        //                    int pt5 = dr.GetOrdinal("DAP");
        //                    int pt6 = dr.GetOrdinal("CODIGO");
        //                    int pt7 = dr.GetOrdinal("ALTURA");
        //                    int pt8 = dr.GetOrdinal("VOLUMEN");
        //                    int pt9 = dr.GetOrdinal("COORDENADA_ESTE");
        //                    int pt10 = dr.GetOrdinal("COORDENADA_NORTE");
        //                    int pt11 = dr.GetOrdinal("COD_ECONDICION");
        //                    int pt12 = dr.GetOrdinal("COD_EESTADO");
        //                    int pt13 = dr.GetOrdinal("CONDICION");
        //                    int pt14 = dr.GetOrdinal("ESTADO");
        //                    int pt15 = dr.GetOrdinal("OBSERVACION");
        //                    Int32 num_fila = 0;
        //                    while (dr.Read())
        //                    {
        //                        oCamposDet = new CEntidad();
        //                        oCampos.NUMERO_FILA = num_fila;

        //                        oCamposDet.COD_ESPECIES = dr.GetString(pt1);
        //                        oCamposDet.COD_SECUENCIAL = dr.GetInt32(pt2);
        //                        oCamposDet.NUM_PCA = dr.GetString(pt3);
        //                        oCamposDet.ESPECIES = dr.GetString(pt4);
        //                        oCamposDet.DAP = Decimal.Parse(dr.GetString(pt5));
        //                        oCamposDet.CODIGO = dr.GetString(pt6);
        //                        oCamposDet.ALTURA = Decimal.Parse(dr.GetString(pt7));
        //                        oCamposDet.VOLUMEN = Decimal.Parse(dr.GetString(pt8));
        //                        oCamposDet.COORDENADA_ESTE = dr.GetInt32(pt9);
        //                        oCamposDet.COORDENADA_NORTE = dr.GetInt32(pt10);
        //                        oCamposDet.COD_ECONDICION = dr.GetString(pt11);
        //                        oCamposDet.COD_EESTADO = dr.GetString(pt12);
        //                        oCamposDet.CONDICION = dr.GetString(pt13);
        //                        oCamposDet.ESTADO = dr.GetString(pt14);
        //                        oCamposDet.OBSERVACION = dr.GetString(pt15);
        //                        oCamposDet.RegEstado = 0;
        //                        oCampos.ListDEVOLCENSOARBOL.Add(oCamposDet);
        //                        num_fila++;
        //                    }
        //                }
        //            }
        //        }
        //        return oCampos;
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
        //public CEntidad RegMostrarListaItemsV3(SqlConnection cn, CEntidad oCEntidad)
        //{
        //    CEntidad oCampos = new CEntidad();
        //    try
        //    {
        //        using (SqlDataReader dr = oGDataSQL.SelDrdDefault(cn, null, "DOC.spDEV_MADMostItemsPruebaV3", oCEntidad))
        //        {
        //            if (dr != null)
        //            {
        //                oCampos.ListNUM_POA = new List<CEntidad>();
        //                oCampos.ListESPDEVUELTAS = new List<CEntidad>();
        //                oCampos.ListPINFTEC = new List<CEntidad>();
        //                oCampos.ListVERTICE = new List<CEntidad>();
        //                oCampos.ListESPHALLADAS = new List<CEntidad>();
        //                oCampos.ListBEXTRACCION = new List<CEntidad>();
        //                oCampos.ListDEVOLCENSOTROZA = new List<CEntidad>();
        //                oCampos.ListDEVOLCENSOTOCON = new List<CEntidad>();
        //                oCampos.ListDEVOLCENSOARBOL = new List<CEntidad>();
        //                oCampos.ListEliTABLA = new List<CEntidad>();
        //                CEntidad oCamposDet;
        //                //
        //                if (dr.HasRows)
        //                {
        //                    dr.Read();
        //                    oCampos.COD_THABILITANTE = dr.GetString(dr.GetOrdinal("COD_THABILITANTE"));
        //                    oCampos.COD_MTIPO = dr.GetString(dr.GetOrdinal("COD_MTIPO"));
        //                    oCampos.MODALIDAD = dr.GetString(dr.GetOrdinal("MODALIDAD"));
        //                    oCampos.NUM_THABILITANTE = dr.GetString(dr.GetOrdinal("NUM_THABILITANTE"));
        //                    oCampos.PERSONA_TITULAR = dr.GetString(dr.GetOrdinal("PERSONA_TITULAR"));
        //                    oCampos.COD_DEVOLUCION = dr.GetString(dr.GetOrdinal("COD_DEVOLUCION"));
        //                    oCampos.COD_PERSONA_FIRMA = dr.GetString(dr.GetOrdinal("COD_PERSONA_FIRMA"));
        //                    oCampos.PERSONA_FIRMA = dr.GetString(dr.GetOrdinal("PERSONA_FIRMA"));
        //                    oCampos.NUM_RESOLUCION = dr.GetString(dr.GetOrdinal("NUM_RESOLUCION"));
        //                    oCampos.FECHA_RESOLUCION = dr.GetString(dr.GetOrdinal("FECHA_RESOLUCION"));

        //                    oCampos.FECHA_INFORME = dr.GetString(dr.GetOrdinal("FECHA_INFORME"));
        //                    oCampos.NUM_INFORME = dr.GetString(dr.GetOrdinal("NUM_INFORME"));

        //                    oCampos.ZAFRA_EJECUTAR = dr.GetString(dr.GetOrdinal("ZAFRA_EJECUTAR"));
        //                    oCampos.INICIO_PERIODO_EJECUCION = dr.GetString(dr.GetOrdinal("INICIO_PERIODO_EJECUCION"));
        //                    oCampos.FIN_PERIODO_EJECUCION = dr.GetString(dr.GetOrdinal("FIN_PERIODO_EJECUCION"));
        //                    oCampos.FECHA_EMISION_BEXTRACCION = dr.GetString(dr.GetOrdinal("FECHA_EMISION_BEXTRACCION"));
        //                    oCampos.TIENE_POA = dr.GetBoolean(dr.GetOrdinal("TIENE_POA"));
        //                    //
        //                    oCampos.COD_ESTADO_DOC = dr.GetString(dr.GetOrdinal("COD_ESTADO_DOC"));
        //                    oCampos.OBSERVACIONES_CONTROL = dr.GetString(dr.GetOrdinal("OBSERVACIONES_CONTROL"));
        //                    oCampos.OBSERV_SUBSANAR = dr.GetBoolean(dr.GetOrdinal("OBSERV_SUBSANAR"));
        //                    oCampos.COD_OD_REGISTRO = dr.GetString(dr.GetOrdinal("COD_OD_REGISTRO"));

        //                    oCampos.USUARIO_REGISTRO = dr.GetString(dr.GetOrdinal("USUARIO_REGISTRO"));
        //                    oCampos.USUARIO_CONTROL = dr.GetString(dr.GetOrdinal("USUARIO_CONTROL"));
        //                }
        //                //DOC.POA_VS_DEV_MAD
        //                dr.NextResult();
        //                if (dr.HasRows)
        //                {
        //                    int pt1 = dr.GetOrdinal("NUM_POA");
        //                    int pt2 = dr.GetOrdinal("NUM_PCOMPLEMENTARIO");
        //                    int pt3 = dr.GetOrdinal("ESTADO_ORIGEN");
        //                    while (dr.Read())
        //                    {
        //                        oCamposDet = new CEntidad();
        //                        oCamposDet.NUM_POA = dr.GetInt32(pt1);
        //                        oCamposDet.NUM_PCOMPLEMENTARIO = dr.GetInt32(pt2);
        //                        oCamposDet.ESTADO_ORIGEN = dr.GetString(pt3);
        //                        oCamposDet.RegEstado = 0;
        //                        oCampos.ListNUM_POA.Add(oCamposDet);
        //                    }
        //                }
        //                //DOC.DEV_MAD_DET_ESP_DEVUELTAS
        //                dr.NextResult();
        //                if (dr.HasRows)
        //                {
        //                    int pt1 = dr.GetOrdinal("COD_ESPECIES");
        //                    int pt2 = dr.GetOrdinal("ESPECIES");
        //                    int pt3 = dr.GetOrdinal("COD_SECUENCIAL");
        //                    int pt4 = dr.GetOrdinal("VOLUMEN");
        //                    int pt5 = dr.GetOrdinal("NUM_TROZAS");
        //                    int pt6 = dr.GetOrdinal("COORDENADA_ESTE");
        //                    int pt7 = dr.GetOrdinal("COORDENADA_NORTE");
        //                    int pt8 = dr.GetOrdinal("OBSERVACION");
        //                    while (dr.Read())
        //                    {
        //                        oCamposDet = new CEntidad();
        //                        oCamposDet.COD_ESPECIES = dr.GetString(pt1);
        //                        oCamposDet.ESPECIES = dr.GetString(pt2);
        //                        oCamposDet.COD_SECUENCIAL = dr.GetInt32(pt3);
        //                        oCamposDet.VOLUMEN = Decimal.Parse(dr.GetString(pt4));
        //                        oCamposDet.NUM_TROZAS = dr.GetInt32(pt5);
        //                        oCamposDet.COORDENADA_ESTE = dr.GetInt32(pt6);
        //                        oCamposDet.COORDENADA_NORTE = dr.GetInt32(pt7);
        //                        oCamposDet.OBSERVACION = dr.GetString(pt8);
        //                        oCamposDet.RegEstado = 0;
        //                        oCampos.ListESPDEVUELTAS.Add(oCamposDet);
        //                    }
        //                }

        //                //DOC.DEV_MAD_DET_PINFTEC
        //                dr.NextResult();
        //                if (dr.HasRows)
        //                {

        //                    // int pt1 = dr.GetOrdinal("NUMERO_INFORME");
        //                    // int pt2 = dr.GetOrdinal("FECHA_INFORME");
        //                    int pt3 = dr.GetOrdinal("COD_PERSONA");
        //                    int pt4 = dr.GetOrdinal("PERSONA");
        //                    int pt5 = dr.GetOrdinal("N_DOCUMENTO");
        //                    int pt6 = dr.GetOrdinal("CARGO");
        //                    int pt7 = dr.GetOrdinal("COD_SECUENCIAL");
        //                    while (dr.Read())
        //                    {
        //                        oCamposDet = new CEntidad();
        //                        // oCamposDet.NUM_INFORME = dr.GetString(pt1);
        //                        // oCamposDet.FECHA_INFORME = dr.GetString(pt2);
        //                        oCamposDet.COD_PERSONA = dr.GetString(pt3);
        //                        oCamposDet.PERSONA = dr.GetString(pt4);
        //                        oCamposDet.N_DOCUMENTO = dr.GetString(pt5);
        //                        oCamposDet.CARGO = dr.GetString(pt6);
        //                        oCamposDet.COD_SECUENCIAL = dr.GetInt32(pt7);
        //                        oCamposDet.RegEstado = 0;
        //                        oCampos.ListPINFTEC.Add(oCamposDet);
        //                    }
        //                }

        //                //DOC.DEV_MAD_DET_VERTICE
        //                dr.NextResult();
        //                if (dr.HasRows)
        //                {
        //                    int pt1 = dr.GetOrdinal("VERTICE");
        //                    int pt2 = dr.GetOrdinal("COORDENADA_ESTE");
        //                    int pt3 = dr.GetOrdinal("COORDENADA_NORTE");
        //                    int pt4 = dr.GetOrdinal("OBSERVACION");
        //                    int pt5 = dr.GetOrdinal("COD_SECUENCIAL");
        //                    while (dr.Read())
        //                    {
        //                        oCamposDet = new CEntidad();
        //                        oCamposDet.VERTICE = dr.GetString(pt1);
        //                        oCamposDet.COORDENADA_ESTE = dr.GetInt32(pt2);
        //                        oCamposDet.COORDENADA_NORTE = dr.GetInt32(pt3);
        //                        oCamposDet.OBSERVACION = dr.GetString(pt4);
        //                        oCamposDet.COD_SECUENCIAL = dr.GetInt32(pt5);
        //                        oCamposDet.RegEstado = 0;
        //                        oCampos.ListVERTICE.Add(oCamposDet);
        //                    }
        //                }
        //                //DOC.DEV_MAD_DET_ESP_HALLADAS
        //                dr.NextResult();
        //                if (dr.HasRows)
        //                {
        //                    int pt1 = dr.GetOrdinal("COD_ESPECIES");
        //                    int pt2 = dr.GetOrdinal("ESPECIES");
        //                    int pt3 = dr.GetOrdinal("COD_SECUENCIAL");
        //                    int pt4 = dr.GetOrdinal("VOLUMEN");
        //                    int pt5 = dr.GetOrdinal("NUM_TROZAS");
        //                    int pt6 = dr.GetOrdinal("COORDENADA_ESTE");
        //                    int pt7 = dr.GetOrdinal("COORDENADA_NORTE");
        //                    int pt8 = dr.GetOrdinal("OBSERVACION");
        //                    while (dr.Read())
        //                    {
        //                        oCamposDet = new CEntidad();
        //                        oCamposDet.COD_ESPECIES = dr.GetString(pt1);
        //                        oCamposDet.ESPECIES = dr.GetString(pt2);
        //                        oCamposDet.COD_SECUENCIAL = dr.GetInt32(pt3);
        //                        oCamposDet.VOLUMEN = Decimal.Parse(dr.GetString(pt4));
        //                        oCamposDet.NUM_TROZAS = dr.GetInt32(pt5);
        //                        oCamposDet.COORDENADA_ESTE = dr.GetInt32(pt6);
        //                        oCamposDet.COORDENADA_NORTE = dr.GetInt32(pt7);
        //                        oCamposDet.OBSERVACION = dr.GetString(pt8);
        //                        oCamposDet.RegEstado = 0;
        //                        oCampos.ListESPHALLADAS.Add(oCamposDet);
        //                    }
        //                }
        //                //DOC.DEV_MAD_DET_BEXTRACCION
        //                dr.NextResult();
        //                if (dr.HasRows)
        //                {
        //                    int pt1 = dr.GetOrdinal("COD_ESPECIES");
        //                    int pt2 = dr.GetOrdinal("COD_SECUENCIAL");
        //                    int pt3 = dr.GetOrdinal("ESPECIES");
        //                    int pt4 = dr.GetOrdinal("VOLUMEN_AUTORIZADO");
        //                    int pt5 = dr.GetOrdinal("VOLUMEN_MOVILIZADO");
        //                    int pt6 = dr.GetOrdinal("SALDO");
        //                    int pt7 = dr.GetOrdinal("OBSERVACION");
        //                    while (dr.Read())
        //                    {
        //                        oCamposDet = new CEntidad();
        //                        oCamposDet.COD_ESPECIES = dr.GetString(pt1);
        //                        oCamposDet.COD_SECUENCIAL = dr.GetInt32(pt2);
        //                        oCamposDet.ESPECIES = dr.GetString(pt3);
        //                        oCamposDet.VOLUMEN_AUTORIZADO = Decimal.Parse(dr.GetString(pt4));
        //                        oCamposDet.VOLUMEN_MOVILIZADO = Decimal.Parse(dr.GetString(pt5));
        //                        oCamposDet.SALDO = Decimal.Parse(dr.GetString(pt6));
        //                        oCamposDet.OBSERVACION = dr.GetString(pt7);
        //                        oCamposDet.RegEstado = 0;
        //                        oCampos.ListBEXTRACCION.Add(oCamposDet);
        //                    }
        //                }
        //                //DOC.DEV_MAD_DET_CENSO_TROZA
        //                dr.NextResult();
        //                if (dr.HasRows)
        //                {
        //                    int pt1 = dr.GetOrdinal("COD_ESPECIES");
        //                    int pt2 = dr.GetOrdinal("COD_SECUENCIAL");
        //                    int pt3 = dr.GetOrdinal("ESPECIES");
        //                    int pt4 = dr.GetOrdinal("DAP");
        //                    int pt5 = dr.GetOrdinal("CODIGO");
        //                    int pt6 = dr.GetOrdinal("ALTURA");
        //                    int pt7 = dr.GetOrdinal("VOLUMEN");
        //                    int pt8 = dr.GetOrdinal("COORDENADA_ESTE");
        //                    int pt9 = dr.GetOrdinal("COORDENADA_NORTE");
        //                    int pt10 = dr.GetOrdinal("NUM_TROZAS");
        //                    int pt11 = dr.GetOrdinal("DESCRIPCION");
        //                    int pt12 = dr.GetOrdinal("OBSERVACION");
        //                    Int32 num_fila = 0;
        //                    while (dr.Read())
        //                    {
        //                        oCamposDet = new CEntidad();
        //                        oCampos.NUMERO_FILA = num_fila;
        //                        oCamposDet.COD_ESPECIES = dr.GetString(pt1);
        //                        oCamposDet.COD_SECUENCIAL = dr.GetInt32(pt2);
        //                        oCamposDet.ESPECIES = dr.GetString(pt3);
        //                        oCamposDet.DAP = Decimal.Parse(dr.GetString(pt4));
        //                        oCamposDet.CODIGO = dr.GetString(pt5);
        //                        oCamposDet.ALTURA = Decimal.Parse(dr.GetString(pt6));
        //                        oCamposDet.VOLUMEN = Decimal.Parse(dr.GetString(pt7));
        //                        oCamposDet.COORDENADA_ESTE = dr.GetInt32(pt8);
        //                        oCamposDet.COORDENADA_NORTE = dr.GetInt32(pt9);
        //                        oCamposDet.NUM_TROZAS = dr.GetInt32(pt10);
        //                        oCamposDet.DESCRIPCION = dr.GetString(pt11);
        //                        oCamposDet.OBSERVACION = dr.GetString(pt12);
        //                        oCamposDet.RegEstado = 0;
        //                        oCampos.ListDEVOLCENSOTROZA.Add(oCamposDet);
        //                        num_fila++;
        //                    }
        //                }
        //                //DOC.DEV_MAD_DET_CENSO_TOCON
        //                dr.NextResult();
        //                if (dr.HasRows)
        //                {
        //                    int pt1 = dr.GetOrdinal("COD_ESPECIES");
        //                    int pt2 = dr.GetOrdinal("COD_SECUENCIAL");
        //                    int pt3 = dr.GetOrdinal("ESPECIES");
        //                    int pt4 = dr.GetOrdinal("DIAMETRO");
        //                    int pt5 = dr.GetOrdinal("CODIGO");
        //                    int pt6 = dr.GetOrdinal("LARGO");
        //                    int pt7 = dr.GetOrdinal("VOLUMEN");
        //                    int pt8 = dr.GetOrdinal("COORDENADA_ESTE");
        //                    int pt9 = dr.GetOrdinal("COORDENADA_NORTE");
        //                    int pt10 = dr.GetOrdinal("CANTIDAD");
        //                    int pt11 = dr.GetOrdinal("DESCRIPCION");
        //                    int pt12 = dr.GetOrdinal("OBSERVACION");
        //                    Int32 num_fila = 0;
        //                    while (dr.Read())
        //                    {
        //                        oCamposDet = new CEntidad();
        //                        oCampos.NUMERO_FILA = num_fila;
        //                        oCamposDet.COD_ESPECIES = dr.GetString(pt1);
        //                        oCamposDet.COD_SECUENCIAL = dr.GetInt32(pt2);
        //                        oCamposDet.ESPECIES = dr.GetString(pt3);
        //                        oCamposDet.DIAMETRO = Decimal.Parse(dr.GetString(pt4));
        //                        oCamposDet.CODIGO = dr.GetString(pt5);
        //                        oCamposDet.LARGO = Decimal.Parse(dr.GetString(pt6));
        //                        oCamposDet.VOLUMEN = Decimal.Parse(dr.GetString(pt7));
        //                        oCamposDet.COORDENADA_ESTE = dr.GetInt32(pt8);
        //                        oCamposDet.COORDENADA_NORTE = dr.GetInt32(pt9);
        //                        oCamposDet.CANTIDAD = dr.GetInt32(pt10);
        //                        oCamposDet.DESCRIPCION = dr.GetString(pt11);
        //                        oCamposDet.OBSERVACION = dr.GetString(pt12);
        //                        oCamposDet.RegEstado = 0;
        //                        oCampos.ListDEVOLCENSOTOCON.Add(oCamposDet);
        //                        num_fila++;
        //                    }
        //                }
        //                //DOC.DEV_MAD_DET_CENSO_ARBOL
        //                dr.NextResult();
        //                if (dr.HasRows)
        //                {
        //                    int pt1 = dr.GetOrdinal("COD_ESPECIES");
        //                    int pt2 = dr.GetOrdinal("COD_SECUENCIAL");
        //                    int pt3 = dr.GetOrdinal("NUM_PCA");
        //                    int pt4 = dr.GetOrdinal("ESPECIES");
        //                    int pt5 = dr.GetOrdinal("DAP");
        //                    int pt6 = dr.GetOrdinal("CODIGO");
        //                    int pt7 = dr.GetOrdinal("ALTURA");
        //                    int pt8 = dr.GetOrdinal("VOLUMEN");
        //                    int pt9 = dr.GetOrdinal("COORDENADA_ESTE");
        //                    int pt10 = dr.GetOrdinal("COORDENADA_NORTE");
        //                    int pt11 = dr.GetOrdinal("COD_ECONDICION");
        //                    int pt12 = dr.GetOrdinal("COD_EESTADO");
        //                    int pt13 = dr.GetOrdinal("CONDICION");
        //                    int pt14 = dr.GetOrdinal("ESTADO");
        //                    int pt15 = dr.GetOrdinal("OBSERVACION");
        //                    Int32 num_fila = 0;
        //                    while (dr.Read())
        //                    {
        //                        oCamposDet = new CEntidad();
        //                        oCampos.NUMERO_FILA = num_fila;

        //                        oCamposDet.COD_ESPECIES = dr.GetString(pt1);
        //                        oCamposDet.COD_SECUENCIAL = dr.GetInt32(pt2);
        //                        oCamposDet.NUM_PCA = dr.GetString(pt3);
        //                        oCamposDet.ESPECIES = dr.GetString(pt4);
        //                        oCamposDet.DAP = Decimal.Parse(dr.GetString(pt5));
        //                        oCamposDet.CODIGO = dr.GetString(pt6);
        //                        oCamposDet.ALTURA = Decimal.Parse(dr.GetString(pt7));
        //                        oCamposDet.VOLUMEN = Decimal.Parse(dr.GetString(pt8));
        //                        oCamposDet.COORDENADA_ESTE = dr.GetInt32(pt9);
        //                        oCamposDet.COORDENADA_NORTE = dr.GetInt32(pt10);
        //                        oCamposDet.COD_ECONDICION = dr.GetString(pt11);
        //                        oCamposDet.COD_EESTADO = dr.GetString(pt12);
        //                        oCamposDet.CONDICION = dr.GetString(pt13);
        //                        oCamposDet.ESTADO = dr.GetString(pt14);
        //                        oCamposDet.OBSERVACION = dr.GetString(pt15);
        //                        oCamposDet.RegEstado = 0;
        //                        oCampos.ListDEVOLCENSOARBOL.Add(oCamposDet);
        //                        num_fila++;
        //                    }
        //                }
        //            }
        //        }
        //        return oCampos;
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
        //public String RegGrabar(SqlConnection cn, CEntidad oCEntidad)
        //{
        //    SqlTransaction tr = null;
        //    String OUTPUTPARAM01 = "";
        //    String OUTPUTPARAM02 = "";
        //    CEntidad oCamposDet;
        //    try
        //    {
        //        tr = cn.BeginTransaction();
        //        //Grabando Cabecera
        //        using (SqlCommand cmd = oGDataSQL.ManExecuteOutput(cn, tr, "DOC.spDEV_MADGrabarPrueba", oCEntidad))
        //        {
        //            cmd.ExecuteNonQuery();
        //            OUTPUTPARAM01 = (String)cmd.Parameters["@OUTPUTPARAM01"].Value;
        //            OUTPUTPARAM02 = (String)cmd.Parameters["@OUTPUTPARAM02"].Value;
        //            if (OUTPUTPARAM01 == "100")
        //            {
        //                tr.Rollback();
        //                tr = null;
        //                throw new Exception("El registro se encuentra con Control de Calidad Conforme, No se puede modificar el registro");
        //            }
        //            else if (OUTPUTPARAM01 == "99")
        //            {
        //                tr.Rollback();
        //                tr = null;
        //                throw new Exception("Ud. no tiene permiso para realizar esta acción");
        //            }
        //            if (OUTPUTPARAM01 == "0")
        //            {
        //                tr.Rollback();
        //                tr = null;
        //                throw new Exception("El Número de la Resolucion ya Existe");
        //            }
        //            else if (OUTPUTPARAM01 == "3")
        //            {
        //                tr.Rollback();
        //                tr = null;
        //                throw new Exception("Está Control de Calidad no puede modificar");
        //            }
        //            else if (OUTPUTPARAM01 == "2")
        //            {
        //                tr.Rollback();
        //                tr = null;
        //                throw new Exception("No Tiene Permisos para Modificar esta Resolucion de Devolucion");
        //            }
        //            else if (OUTPUTPARAM01 == "1")
        //            {
        //                tr.Rollback();
        //                tr = null;
        //                throw new Exception("El Número de la resolucion Existe en otro Registro");
        //            }
        //        }
        //        //Reemplazando El Nuevo Codigo Creado
        //        if (oCEntidad.RegEstado == 1) //Nuevo
        //        {
        //            oCEntidad.COD_DEVOLUCION = OUTPUTPARAM01;
        //        }
        //        //
        //        //Eliminando Detalle
        //        if (oCEntidad.ListEliTABLA != null)
        //        {
        //            foreach (var loDatos in oCEntidad.ListEliTABLA)
        //            {
        //                oCamposDet = new CEntidad();
        //                oCamposDet.COD_THABILITANTE = oCEntidad.COD_THABILITANTE;
        //                oCamposDet.COD_DEVOLUCION = oCEntidad.COD_DEVOLUCION;
        //                oCamposDet.EliTABLA = loDatos.EliTABLA;
        //                oCamposDet.EliVALOR01 = loDatos.EliVALOR01;
        //                oCamposDet.EliVALOR02 = loDatos.EliVALOR02;
        //                oGDataSQL.ManExecute(cn, tr, "DOC.spDEV_MADEliminarDetalle", oCamposDet);
        //            }
        //        }
        //        if (oCEntidad.ListNUM_POA != null)
        //        {
        //            foreach (var loDatos in oCEntidad.ListNUM_POA)
        //            {
        //                if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
        //                {
        //                    oCamposDet = new CEntidad();
        //                    oCamposDet.COD_THABILITANTE_POA = oCEntidad.COD_THABILITANTE;
        //                    oCamposDet.COD_THABILITANTE_DEV = oCEntidad.COD_THABILITANTE;
        //                    oCamposDet.NUM_POA = loDatos.NUM_POA;
        //                    oCamposDet.COD_DEVOLUCION = oCEntidad.COD_DEVOLUCION;
        //                    oGDataSQL.ManExecute(cn, tr, "DOC.spDEVOLUCION_VS_POA_Grabar", oCamposDet);
        //                }
        //            }
        //        }
        //        // Grabando DOC.DEV_MAD_DET_ESP_DEVUELTAS;
        //        if (oCEntidad.ListESPDEVUELTAS != null)
        //        {
        //            foreach (var loDatos in oCEntidad.ListESPDEVUELTAS)
        //            {
        //                if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
        //                {
        //                    oCamposDet = new CEntidad();
        //                    oCamposDet.COD_THABILITANTE = oCEntidad.COD_THABILITANTE;
        //                    oCamposDet.COD_DEVOLUCION = oCEntidad.COD_DEVOLUCION;
        //                    oCamposDet.COD_ESPECIES = loDatos.COD_ESPECIES;
        //                    oCamposDet.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
        //                    oCamposDet.VOLUMEN = loDatos.VOLUMEN;
        //                    oCamposDet.NUM_TROZAS = loDatos.NUM_TROZAS;
        //                    oCamposDet.COORDENADA_ESTE = loDatos.COORDENADA_ESTE;
        //                    oCamposDet.COORDENADA_NORTE = loDatos.COORDENADA_NORTE;
        //                    oCamposDet.OBSERVACION = loDatos.OBSERVACION;
        //                    oCamposDet.ESPECIES = loDatos.ESPECIES;
        //                    oCamposDet.RegEstado = loDatos.RegEstado;
        //                    oGDataSQL.ManExecute(cn, tr, "DOC.spDEV_MAD_DET_ESP_DEVGrabar", oCamposDet);
        //                }
        //            }
        //        }
        //        // Grabando DOC.DEV_MAD_DET_PINFTEC;
        //        if (oCEntidad.ListPINFTEC != null)
        //        {
        //            foreach (var loDatos in oCEntidad.ListPINFTEC)
        //            {
        //                if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
        //                {
        //                    oCamposDet = new CEntidad();
        //                    oCamposDet.COD_THABILITANTE = oCEntidad.COD_THABILITANTE;
        //                    oCamposDet.COD_DEVOLUCION = oCEntidad.COD_DEVOLUCION;
        //                    oCamposDet.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
        //                    oCamposDet.COD_PERSONA = loDatos.COD_PERSONA;
        //                    oCamposDet.NUM_INFORME = loDatos.NUM_INFORME;
        //                    oCamposDet.FECHA_INFORME = loDatos.FECHA_INFORME;
        //                    oCamposDet.RegEstado = loDatos.RegEstado;
        //                    oGDataSQL.ManExecute(cn, tr, "DOC.spDEV_MAD_DET_PINFTECGrabar", oCamposDet);
        //                }
        //            }
        //        }
        //        // Grabando DOC.DEV_MAD_DET_VERTICE;
        //        if (oCEntidad.ListVERTICE != null)
        //        {
        //            foreach (var loDatos in oCEntidad.ListVERTICE)
        //            {
        //                if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
        //                {
        //                    oCamposDet = new CEntidad();
        //                    oCamposDet.COD_THABILITANTE = oCEntidad.COD_THABILITANTE;
        //                    oCamposDet.COD_DEVOLUCION = oCEntidad.COD_DEVOLUCION;
        //                    oCamposDet.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
        //                    oCamposDet.VERTICE = loDatos.VERTICE;
        //                    oCamposDet.COORDENADA_ESTE = loDatos.COORDENADA_ESTE;
        //                    oCamposDet.COORDENADA_NORTE = loDatos.COORDENADA_NORTE;
        //                    oCamposDet.OBSERVACION = loDatos.OBSERVACION;
        //                    oCamposDet.RegEstado = loDatos.RegEstado;
        //                    oGDataSQL.ManExecute(cn, tr, "DOC.spDEV_MAD_DET_VERTICEGrabar", oCamposDet);
        //                }
        //            }
        //        }
        //        // Grabando DOC.DEV_MAD_DET_ESP_HALLADAS;
        //        if (oCEntidad.ListESPHALLADAS != null)
        //        {
        //            foreach (var loDatos in oCEntidad.ListESPHALLADAS)
        //            {
        //                if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
        //                {
        //                    oCamposDet = new CEntidad();
        //                    oCamposDet.COD_THABILITANTE = oCEntidad.COD_THABILITANTE;
        //                    oCamposDet.COD_DEVOLUCION = oCEntidad.COD_DEVOLUCION;
        //                    oCamposDet.COD_ESPECIES = loDatos.COD_ESPECIES;
        //                    oCamposDet.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
        //                    oCamposDet.VOLUMEN = loDatos.VOLUMEN;
        //                    oCamposDet.NUM_TROZAS = loDatos.NUM_TROZAS;
        //                    oCamposDet.COORDENADA_ESTE = loDatos.COORDENADA_ESTE;
        //                    oCamposDet.COORDENADA_NORTE = loDatos.COORDENADA_NORTE;
        //                    oCamposDet.OBSERVACION = loDatos.OBSERVACION;
        //                    oCamposDet.ESPECIES = loDatos.ESPECIES;
        //                    oCamposDet.RegEstado = loDatos.RegEstado;
        //                    oGDataSQL.ManExecute(cn, tr, "DOC.spDEV_MAD_DET_ESP_HALLADASGrabar", oCamposDet);
        //                }
        //            }
        //        }
        //        // Grabando DOC.DEV_MAD_DET_BEXTRACCION;
        //        if (oCEntidad.ListBEXTRACCION != null)
        //        {
        //            foreach (var loDatos in oCEntidad.ListBEXTRACCION)
        //            {
        //                if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
        //                {
        //                    oCamposDet = new CEntidad();
        //                    oCamposDet.COD_THABILITANTE = oCEntidad.COD_THABILITANTE;
        //                    oCamposDet.COD_DEVOLUCION = oCEntidad.COD_DEVOLUCION;
        //                    oCamposDet.COD_ESPECIES = loDatos.COD_ESPECIES;
        //                    oCamposDet.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
        //                    oCamposDet.VOLUMEN_AUTORIZADO = loDatos.VOLUMEN_AUTORIZADO;
        //                    oCamposDet.VOLUMEN_MOVILIZADO = loDatos.VOLUMEN_MOVILIZADO;
        //                    oCamposDet.SALDO = loDatos.SALDO;
        //                    oCamposDet.OBSERVACION = loDatos.OBSERVACION;
        //                    oCamposDet.ESPECIES = loDatos.ESPECIES;
        //                    oCamposDet.RegEstado = loDatos.RegEstado;
        //                    oGDataSQL.ManExecute(cn, tr, "DOC.spDEV_MAD_DET_BEXTRACCIONGrabar", oCamposDet);
        //                }
        //            }
        //        }
        //        // Grabando DOC.DEV_MAD_DET_CENSO_TROZA;
        //        if (oCEntidad.ListDEVOLCENSOTROZA != null)
        //        {
        //            foreach (var loDatos in oCEntidad.ListDEVOLCENSOTROZA)
        //            {
        //                if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
        //                {
        //                    oCamposDet = new CEntidad();
        //                    oCamposDet.COD_THABILITANTE = oCEntidad.COD_THABILITANTE;
        //                    oCamposDet.COD_DEVOLUCION = oCEntidad.COD_DEVOLUCION;
        //                    oCamposDet.COD_ESPECIES = loDatos.COD_ESPECIES;
        //                    oCamposDet.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
        //                    oCamposDet.DAP = loDatos.DAP;
        //                    oCamposDet.ALTURA = loDatos.ALTURA;
        //                    oCamposDet.CODIGO = loDatos.CODIGO;
        //                    oCamposDet.VOLUMEN = loDatos.VOLUMEN;
        //                    oCamposDet.COORDENADA_ESTE = loDatos.COORDENADA_ESTE;
        //                    oCamposDet.COORDENADA_NORTE = loDatos.COORDENADA_NORTE;
        //                    oCamposDet.NUM_TROZAS = loDatos.NUM_TROZAS;
        //                    oCamposDet.DESCRIPCION = loDatos.DESCRIPCION;
        //                    oCamposDet.OBSERVACION = loDatos.OBSERVACION;
        //                    oCamposDet.ESPECIES = loDatos.ESPECIES;
        //                    oCamposDet.RegEstado = loDatos.RegEstado;
        //                    oGDataSQL.ManExecute(cn, tr, "DOC.spDEV_MAD_DET_CENSO_TROZAGrabar", oCamposDet);
        //                }
        //            }
        //        }
        //        // Grabando DOC.DEV_MAD_DET_CENSO_TOCON;
        //        if (oCEntidad.ListDEVOLCENSOTOCON != null)
        //        {
        //            foreach (var loDatos in oCEntidad.ListDEVOLCENSOTOCON)
        //            {
        //                if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
        //                {
        //                    oCamposDet = new CEntidad();
        //                    oCamposDet.COD_THABILITANTE = oCEntidad.COD_THABILITANTE;
        //                    oCamposDet.COD_DEVOLUCION = oCEntidad.COD_DEVOLUCION;
        //                    oCamposDet.COD_ESPECIES = loDatos.COD_ESPECIES;
        //                    oCamposDet.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
        //                    oCamposDet.DIAMETRO = loDatos.DIAMETRO;
        //                    oCamposDet.CODIGO = loDatos.CODIGO;
        //                    oCamposDet.LARGO = loDatos.LARGO;
        //                    oCamposDet.VOLUMEN = loDatos.VOLUMEN;
        //                    oCamposDet.COORDENADA_ESTE = loDatos.COORDENADA_ESTE;
        //                    oCamposDet.COORDENADA_NORTE = loDatos.COORDENADA_NORTE;
        //                    oCamposDet.CANTIDAD = loDatos.CANTIDAD;
        //                    oCamposDet.DESCRIPCION = loDatos.DESCRIPCION;
        //                    oCamposDet.OBSERVACION = loDatos.OBSERVACION;
        //                    oCamposDet.ESPECIES = loDatos.ESPECIES;
        //                    oCamposDet.RegEstado = loDatos.RegEstado;
        //                    oGDataSQL.ManExecute(cn, tr, "DOC.spDEV_MAD_DET_CENSO_TOCONGrabar", oCamposDet);
        //                }
        //            }
        //        }
        //        // Grabando DOC.DEV_MAD_DET_CENSO_ARBOL;
        //        if (oCEntidad.ListDEVOLCENSOARBOL != null)
        //        {
        //            foreach (var loDatos in oCEntidad.ListDEVOLCENSOARBOL)
        //            {
        //                if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
        //                {
        //                    oCamposDet = new CEntidad();
        //                    oCamposDet.COD_THABILITANTE = oCEntidad.COD_THABILITANTE;
        //                    oCamposDet.COD_DEVOLUCION = oCEntidad.COD_DEVOLUCION;
        //                    oCamposDet.COD_ESPECIES = loDatos.COD_ESPECIES;
        //                    oCamposDet.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
        //                    oCamposDet.NUM_PCA = loDatos.NUM_PCA;
        //                    oCamposDet.CODIGO = loDatos.CODIGO;
        //                    oCamposDet.DAP = loDatos.DAP;
        //                    oCamposDet.ALTURA = loDatos.ALTURA;
        //                    oCamposDet.VOLUMEN = loDatos.VOLUMEN;
        //                    oCamposDet.COORDENADA_ESTE = loDatos.COORDENADA_ESTE;
        //                    oCamposDet.COORDENADA_NORTE = loDatos.COORDENADA_NORTE;
        //                    oCamposDet.COD_ECONDICION = loDatos.COD_ECONDICION;
        //                    oCamposDet.COD_EESTADO = loDatos.COD_EESTADO;
        //                    oCamposDet.OBSERVACION = loDatos.OBSERVACION;
        //                    oCamposDet.ESPECIES = loDatos.ESPECIES;
        //                    oCamposDet.CONDICION = loDatos.CONDICION;
        //                    oCamposDet.ESTADO = loDatos.ESTADO;
        //                    oCamposDet.RegEstado = loDatos.RegEstado;
        //                    oGDataSQL.ManExecute(cn, tr, "DOC.spDEV_MAD_DET_CENSO_ARBOLGrabar", oCamposDet);
        //                }
        //            }
        //        }
        //        //
        //        tr.Commit();
        //        return OUTPUTPARAM02 + '|' + OUTPUTPARAM01;
        //    }
        //    catch (Exception ex)
        //    {
        //        if (tr != null)
        //        {
        //            tr.Rollback();
        //        }
        //        throw ex;
        //    }
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        //public String RegGrabarV3(SqlConnection cn, CEntidad oCEntidad)
        //{
        //    SqlTransaction tr = null;
        //    String OUTPUTPARAM01 = "";
        //    String OUTPUTPARAM02 = "";
        //    CEntidad oCamposDet;
        //    try
        //    {
        //        tr = cn.BeginTransaction();
        //        //Grabando Cabecera
        //        using (SqlCommand cmd = oGDataSQL.ManExecuteOutput(cn, tr, "DOC.spDEV_MADGrabarPruebaV3", oCEntidad))
        //        {
        //            cmd.ExecuteNonQuery();
        //            OUTPUTPARAM01 = (String)cmd.Parameters["@OUTPUTPARAM01"].Value;
        //            OUTPUTPARAM02 = (String)cmd.Parameters["@OUTPUTPARAM02"].Value;
        //            if (OUTPUTPARAM01 == "99")
        //            {
        //                tr.Rollback();
        //                tr = null;
        //                throw new Exception("Ud. no tiene permiso para realizar esta acción");
        //            }
        //            if (OUTPUTPARAM01 == "0")
        //            {
        //                tr.Rollback();
        //                tr = null;
        //                throw new Exception("El Número de la Resolucion ya Existe");
        //            }
        //            else if (OUTPUTPARAM01 == "3")
        //            {
        //                tr.Rollback();
        //                tr = null;
        //                throw new Exception("Está Control de Calidad no puede modificar");
        //            }
        //            else if (OUTPUTPARAM01 == "2")
        //            {
        //                tr.Rollback();
        //                tr = null;
        //                throw new Exception("No Tiene Permisos para Modificar esta Resolucion de Devolucion");
        //            }
        //            else if (OUTPUTPARAM01 == "1")
        //            {
        //                tr.Rollback();
        //                tr = null;
        //                throw new Exception("El Número de la resolucion Existe en otro Registro");
        //            }
        //        }
        //        //Reemplazando El Nuevo Codigo Creado
        //        if (oCEntidad.RegEstado == 1) //Nuevo
        //        {
        //            oCEntidad.COD_DEVOLUCION = OUTPUTPARAM01;
        //        }
        //        //
        //        //Eliminando Detalle
        //        if (oCEntidad.ListEliTABLA != null)
        //        {
        //            foreach (var loDatos in oCEntidad.ListEliTABLA)
        //            {
        //                oCamposDet = new CEntidad();
        //                oCamposDet.COD_THABILITANTE = oCEntidad.COD_THABILITANTE;
        //                oCamposDet.COD_DEVOLUCION = oCEntidad.COD_DEVOLUCION;
        //                oCamposDet.EliTABLA = loDatos.EliTABLA;
        //                oCamposDet.EliVALOR01 = loDatos.EliVALOR01;
        //                oCamposDet.EliVALOR02 = loDatos.EliVALOR02;
        //                oGDataSQL.ManExecute(cn, tr, "DOC.spDEV_MADEliminarDetallev3", oCamposDet);
        //            }
        //        }
        //        if (oCEntidad.ListNUM_POA != null)
        //        {
        //            foreach (var loDatos in oCEntidad.ListNUM_POA)
        //            {

        //                oCamposDet = new CEntidad();
        //                oCamposDet.COD_THABILITANTE_POA = oCEntidad.COD_THABILITANTE;
        //                oCamposDet.COD_THABILITANTE_DEV = oCEntidad.COD_THABILITANTE;
        //                oCamposDet.NUM_POA = loDatos.NUM_POA;
        //                oCamposDet.COD_DEVOLUCION = oCEntidad.COD_DEVOLUCION;
        //                oGDataSQL.ManExecute(cn, tr, "DOC.spDEVOLUCION_VS_POA_GrabarV3", oCamposDet);

        //            }
        //        }
        //        // Grabando DOC.DEV_MAD_DET_ESP_DEVUELTAS;
        //        if (oCEntidad.ListESPDEVUELTAS != null)
        //        {
        //            foreach (var loDatos in oCEntidad.ListESPDEVUELTAS)
        //            {

        //                oCamposDet = new CEntidad();
        //                oCamposDet.COD_THABILITANTE = oCEntidad.COD_THABILITANTE;
        //                oCamposDet.COD_DEVOLUCION = oCEntidad.COD_DEVOLUCION;
        //                oCamposDet.COD_ESPECIES = loDatos.COD_ESPECIES;
        //                oCamposDet.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
        //                oCamposDet.VOLUMEN = loDatos.VOLUMEN;
        //                oCamposDet.NUM_TROZAS = loDatos.NUM_TROZAS;
        //                oCamposDet.COORDENADA_ESTE = loDatos.COORDENADA_ESTE;
        //                oCamposDet.COORDENADA_NORTE = loDatos.COORDENADA_NORTE;
        //                oCamposDet.OBSERVACION = loDatos.OBSERVACION;
        //                oCamposDet.ESPECIES = loDatos.ESPECIES;
        //                oCamposDet.RegEstado = loDatos.RegEstado;
        //                oGDataSQL.ManExecute(cn, tr, "DOC.spDEV_MAD_DET_ESP_DEVGrabarV3", oCamposDet);

        //            }
        //        }
        //        // Grabando DOC.DEV_MAD_DET_PINFTEC;
        //        if (oCEntidad.ListPINFTEC != null)
        //        {
        //            foreach (var loDatos in oCEntidad.ListPINFTEC)
        //            {

        //                oCamposDet = new CEntidad();
        //                oCamposDet.COD_THABILITANTE = oCEntidad.COD_THABILITANTE;
        //                oCamposDet.COD_DEVOLUCION = oCEntidad.COD_DEVOLUCION;
        //                oCamposDet.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
        //                oCamposDet.COD_PERSONA = loDatos.COD_PERSONA;
        //                //oCamposDet.NUM_INFORME = loDatos.NUM_INFORME;
        //                //oCamposDet.FECHA_INFORME = loDatos.FECHA_INFORME;
        //                oCamposDet.RegEstado = loDatos.RegEstado;
        //                oGDataSQL.ManExecute(cn, tr, "DOC.spDEV_MAD_DET_PINFTECGrabarV3", oCamposDet);

        //            }
        //        }
        //        // Grabando DOC.DEV_MAD_DET_VERTICE;
        //        if (oCEntidad.ListVERTICE != null)
        //        {
        //            foreach (var loDatos in oCEntidad.ListVERTICE)
        //            {

        //                oCamposDet = new CEntidad();
        //                oCamposDet.COD_THABILITANTE = oCEntidad.COD_THABILITANTE;
        //                oCamposDet.COD_DEVOLUCION = oCEntidad.COD_DEVOLUCION;
        //                oCamposDet.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
        //                oCamposDet.VERTICE = loDatos.VERTICE;
        //                oCamposDet.COORDENADA_ESTE = loDatos.COORDENADA_ESTE;
        //                oCamposDet.COORDENADA_NORTE = loDatos.COORDENADA_NORTE;
        //                oCamposDet.OBSERVACION = loDatos.OBSERVACION;
        //                oCamposDet.RegEstado = loDatos.RegEstado;
        //                oGDataSQL.ManExecute(cn, tr, "DOC.spDEV_MAD_DET_VERTICEGrabarV3", oCamposDet);

        //            }
        //        }
        //        // Grabando DOC.DEV_MAD_DET_ESP_HALLADAS;
        //        if (oCEntidad.ListESPHALLADAS != null)
        //        {
        //            foreach (var loDatos in oCEntidad.ListESPHALLADAS)
        //            {

        //                oCamposDet = new CEntidad();
        //                oCamposDet.COD_THABILITANTE = oCEntidad.COD_THABILITANTE;
        //                oCamposDet.COD_DEVOLUCION = oCEntidad.COD_DEVOLUCION;
        //                oCamposDet.COD_ESPECIES = loDatos.COD_ESPECIES;
        //                oCamposDet.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
        //                oCamposDet.VOLUMEN = loDatos.VOLUMEN;
        //                oCamposDet.NUM_TROZAS = loDatos.NUM_TROZAS;
        //                oCamposDet.COORDENADA_ESTE = loDatos.COORDENADA_ESTE;
        //                oCamposDet.COORDENADA_NORTE = loDatos.COORDENADA_NORTE;
        //                oCamposDet.OBSERVACION = loDatos.OBSERVACION;
        //                oCamposDet.ESPECIES = loDatos.ESPECIES;
        //                oCamposDet.RegEstado = loDatos.RegEstado;
        //                oGDataSQL.ManExecute(cn, tr, "DOC.spDEV_MAD_DET_ESP_HALLADASGrabarV3", oCamposDet);

        //            }
        //        }
        //        // Grabando DOC.DEV_MAD_DET_BEXTRACCION;
        //        if (oCEntidad.ListBEXTRACCION != null)
        //        {
        //            foreach (var loDatos in oCEntidad.ListBEXTRACCION)
        //            {

        //                oCamposDet = new CEntidad();
        //                oCamposDet.COD_THABILITANTE = oCEntidad.COD_THABILITANTE;
        //                oCamposDet.COD_DEVOLUCION = oCEntidad.COD_DEVOLUCION;
        //                oCamposDet.COD_ESPECIES = loDatos.COD_ESPECIES;
        //                oCamposDet.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
        //                oCamposDet.VOLUMEN_AUTORIZADO = loDatos.VOLUMEN_AUTORIZADO;
        //                oCamposDet.VOLUMEN_MOVILIZADO = loDatos.VOLUMEN_MOVILIZADO;
        //                oCamposDet.SALDO = loDatos.SALDO;
        //                oCamposDet.OBSERVACION = loDatos.OBSERVACION;
        //                oCamposDet.ESPECIES = loDatos.ESPECIES;
        //                oCamposDet.RegEstado = loDatos.RegEstado;
        //                oGDataSQL.ManExecute(cn, tr, "DOC.spDEV_MAD_DET_BEXTRACCIONGrabarv3", oCamposDet);

        //            }
        //        }
        //        // Grabando DOC.DEV_MAD_DET_CENSO_TROZA;
        //        if (oCEntidad.ListDEVOLCENSOTROZA != null)
        //        {
        //            foreach (var loDatos in oCEntidad.ListDEVOLCENSOTROZA)
        //            {

        //                oCamposDet = new CEntidad();
        //                oCamposDet.COD_THABILITANTE = oCEntidad.COD_THABILITANTE;
        //                oCamposDet.COD_DEVOLUCION = oCEntidad.COD_DEVOLUCION;
        //                oCamposDet.COD_ESPECIES = loDatos.COD_ESPECIES;
        //                oCamposDet.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
        //                oCamposDet.DAP = loDatos.DAP;
        //                oCamposDet.ALTURA = loDatos.ALTURA;
        //                oCamposDet.CODIGO = loDatos.CODIGO;
        //                oCamposDet.VOLUMEN = loDatos.VOLUMEN;
        //                oCamposDet.COORDENADA_ESTE = loDatos.COORDENADA_ESTE;
        //                oCamposDet.COORDENADA_NORTE = loDatos.COORDENADA_NORTE;
        //                oCamposDet.NUM_TROZAS = loDatos.NUM_TROZAS;
        //                oCamposDet.DESCRIPCION = loDatos.DESCRIPCION;
        //                oCamposDet.OBSERVACION = loDatos.OBSERVACION;
        //                oCamposDet.ESPECIES = loDatos.ESPECIES;
        //                oCamposDet.RegEstado = loDatos.RegEstado;
        //                oGDataSQL.ManExecute(cn, tr, "DOC.spDEV_MAD_DET_CENSO_TROZAGrabarv3", oCamposDet);
        //            }

        //        }
        //        // Grabando DOC.DEV_MAD_DET_CENSO_TOCON;
        //        if (oCEntidad.ListDEVOLCENSOTOCON != null)
        //        {
        //            foreach (var loDatos in oCEntidad.ListDEVOLCENSOTOCON)
        //            {

        //                oCamposDet = new CEntidad();
        //                oCamposDet.COD_THABILITANTE = oCEntidad.COD_THABILITANTE;
        //                oCamposDet.COD_DEVOLUCION = oCEntidad.COD_DEVOLUCION;
        //                oCamposDet.COD_ESPECIES = loDatos.COD_ESPECIES;
        //                oCamposDet.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
        //                oCamposDet.DIAMETRO = loDatos.DIAMETRO;
        //                oCamposDet.CODIGO = loDatos.CODIGO;
        //                oCamposDet.LARGO = loDatos.LARGO;
        //                oCamposDet.VOLUMEN = loDatos.VOLUMEN;
        //                oCamposDet.COORDENADA_ESTE = loDatos.COORDENADA_ESTE;
        //                oCamposDet.COORDENADA_NORTE = loDatos.COORDENADA_NORTE;
        //                oCamposDet.CANTIDAD = loDatos.CANTIDAD;
        //                oCamposDet.DESCRIPCION = loDatos.DESCRIPCION;
        //                oCamposDet.OBSERVACION = loDatos.OBSERVACION;
        //                oCamposDet.ESPECIES = loDatos.ESPECIES;
        //                oCamposDet.RegEstado = loDatos.RegEstado;
        //                oGDataSQL.ManExecute(cn, tr, "DOC.spDEV_MAD_DET_CENSO_TOCONGrabarV3", oCamposDet);

        //            }
        //        }
        //        // Grabando DOC.DEV_MAD_DET_CENSO_ARBOL;
        //        if (oCEntidad.ListDEVOLCENSOARBOL != null)
        //        {
        //            foreach (var loDatos in oCEntidad.ListDEVOLCENSOARBOL)
        //            {

        //                oCamposDet = new CEntidad();
        //                oCamposDet.COD_THABILITANTE = oCEntidad.COD_THABILITANTE;
        //                oCamposDet.COD_DEVOLUCION = oCEntidad.COD_DEVOLUCION;
        //                oCamposDet.COD_ESPECIES = loDatos.COD_ESPECIES;
        //                oCamposDet.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
        //                oCamposDet.NUM_PCA = loDatos.NUM_PCA;
        //                oCamposDet.CODIGO = loDatos.CODIGO;
        //                oCamposDet.DAP = loDatos.DAP;
        //                oCamposDet.ALTURA = loDatos.ALTURA;
        //                oCamposDet.VOLUMEN = loDatos.VOLUMEN;
        //                oCamposDet.COORDENADA_ESTE = loDatos.COORDENADA_ESTE;
        //                oCamposDet.COORDENADA_NORTE = loDatos.COORDENADA_NORTE;
        //                oCamposDet.COD_ECONDICION = loDatos.COD_ECONDICION;
        //                oCamposDet.COD_EESTADO = loDatos.COD_EESTADO;
        //                oCamposDet.OBSERVACION = loDatos.OBSERVACION;
        //                oCamposDet.ESPECIES = loDatos.ESPECIES;
        //                oCamposDet.CONDICION = loDatos.CONDICION;
        //                oCamposDet.ESTADO = loDatos.ESTADO;
        //                oCamposDet.RegEstado = loDatos.RegEstado;
        //                oGDataSQL.ManExecute(cn, tr, "DOC.spDEV_MAD_DET_CENSO_ARBOLGrabarV3", oCamposDet);

        //            }
        //        }
        //        //
        //        tr.Commit();
        //        return OUTPUTPARAM02 + '|' + OUTPUTPARAM01;
        //    }
        //    catch (Exception ex)
        //    {
        //        if (tr != null)
        //        {
        //            tr.Rollback();
        //        }
        //        throw ex;
        //    }
        //}





        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        //public Int32 RegEliminar(SqlConnection cn, CEntidad oCEntidad)
        //{
        //    try
        //    {
        //        Int32 RegNum = oGDataSQL.ManExecute(cn, null, "DOC.spDEV_MADEliminar", oCEntidad);
        //        if (RegNum == -1)
        //        {
        //            throw new Exception("No se logró realizar la operación");
        //        }
        //        return RegNum;
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
        //public List<CEntidad> RegMostPoa_Thabilitante_Lista_x_Numero(SqlConnection cn, CEntidad oCEntidad)
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
        //                    int p1 = dr.GetOrdinal("NUM_POA");
        //                    int p2 = dr.GetOrdinal("NUM_PCOMPLEMENTARIO");
        //                    int p3 = dr.GetOrdinal("ESTADO_ORIGEN");
        //                    CEntidad oCampos;
        //                    while (dr.Read())
        //                    {
        //                        oCampos = new CEntidad();
        //                        oCampos.NUM_POA = dr.GetInt32(p1);
        //                        oCampos.NUM_PCOMPLEMENTARIO = dr.GetInt32(p2);
        //                        oCampos.ESTADO_ORIGEN = dr.GetString(p3);
        //                        lsCEntidad.Add(oCampos);
        //                    }
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
                            int pt3 = dr.GetOrdinal("MADERABLE");
                            int pt4 = dr.GetOrdinal("NO_MADERABLE");
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.CODIGO = dr["CODIGO"].ToString();
                                oCamposDet.DESCRIPCION = dr["DESCRIPCION"].ToString();
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
                            int pt3 = dr.GetOrdinal("MADERABLE");
                            int pt4 = dr.GetOrdinal("NO_MADERABLE");
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.CODIGO = dr["CODIGO"].ToString();
                                oCamposDet.DESCRIPCION = dr["DESCRIPCION"].ToString();
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
        public List<CEntPersona> MostPInformeitem(SqlConnection cn, CEntidad oCEntidad)
        {
            List<CEntPersona> lsCEntidad = new List<CEntPersona>();
            try
            {
                using (SqlDataReader dr = oGDataSQL.SelDrdDefault(cn, null, "DOC.spDEV_MADMostItemsPInforme", oCEntidad))
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
    }
}
