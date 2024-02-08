using System;
using System.Collections.Generic;
//using System.Data.SqlClient;
using CEntidad = CapaEntidad.DOC.Ent_Reporte_OBSERVATORIO;
using GeneralSQL;
using Oracle.ManagedDataAccess.Client;
//using SQL = GeneralSQL.Data.SQL;

namespace CapaDatos.DOC
{
    public class Dat_Reporte_OBSERVATORIO_SIMULACION
    {
        //private SQL oGDataSQL = new SQL();
        private DBOracle dBOracle = new DBOracle();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public CEntidad RegMostrarElement(OracleConnection cn, CEntidad oCEntidad)
        {
            CEntidad oCampos = new CEntidad();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.new_REPORTE_Observatorio_v2", oCEntidad))
                {
                    if (dr != null)
                    {   //LISTA ROJA
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                oCampos.ID_REGISTRO = Int32.Parse(dr["ID_REGISTRO"].ToString());
                                oCampos.TITULAR = dr["TITULAR"].ToString();
                                oCampos.NUM_THABILITANTE = dr["NUM_THABILITANTE"].ToString();
                                oCampos.RUC = dr["RUC"].ToString();
                                oCampos.REGION = dr["REGION"].ToString();
                                oCampos.UBICACION = dr["REGION"].ToString() + " / " + dr["PROVINCIA"].ToString() + " / " + dr["DISTRITO"].ToString();
                                oCampos.PLAN_MANEJO_TOP = dr["PLAN_MANEJO_TOP"].ToString();
                                oCampos.NUM_POA = dr["NUM_POA"].ToString();
                                oCampos.VOLUMEN = Decimal.Parse(dr["VOLUMEN"].ToString());
                                oCampos.RES_APROBACION_POA = dr["RES_APROBACION_POA"].ToString();
                                oCampos.VIGENCIA = dr["VIGENCIA"].ToString();
                                oCampos.FIN_VIGENCIA = dr["VIGENCIA_FIN"].ToString();
                                oCampos.ZAFRA = dr["ZAFRA"].ToString();
                                oCampos.INF_FALSA = dr["INF_FALSA"].ToString();
                                oCampos.ESTADO = dr["ESTADO"].ToString();
                                oCampos.DESCRIPCION_ESTADO = dr["DESCRIPCION_ESTADO"].ToString();
                                oCampos.COD_MTIPO = dr["COD_MTIPO"].ToString();
                                oCampos.MODALIDAD = dr["MODALIDAD"].ToString();
                                oCampos.MEDIDA_CAUTELAR = dr["MED_CAU"].ToString();
                                oCampos.MEDIDA_PRECAUTORIA = dr["MED_PRECAU"].ToString();
                                oCampos.CADUCADO = dr["CADUCADO"].ToString();
                                oCampos.ARBOLES_INEX = dr["ARBOLES_INEX"].ToString();
                                oCampos.NUM_ARBOLES_INEX = Int32.Parse(dr["NUM_ARBOLES_INEX"].ToString());
                                oCampos.FECHA_INICIO_TH = dr["FECHA_INICIO_TH"].ToString();
                                oCampos.FECHA_TERMINO_TH = dr["FECHA_TERMINO_TH"].ToString();
                                //oCampos.NIVEL_RIESGO = dr["NIVEL_RIESGO"].ToString();
                                oCampos.FECHA_INGRESO = dr["FECHA_INGRESO"].ToString();
                                oCampos.NUM_INFORME = dr["NUM_INFORME"].ToString();
                                oCampos.FECHA_SUPERVISION_INICIO = dr["FECHA_SUPERVISION_INICIO"].ToString();
                                oCampos.FECHA_SUPERVISION_TERMINO = dr["FECHA_SUPERVISION_TERMINO"].ToString();
                                oCampos.ANIO_REFERENCIA = string.IsNullOrEmpty(dr["ANIO_REFERENCIA"].ToString()) ? -1 : Int32.Parse(dr["ANIO_REFERENCIA"].ToString());
                                oCampos.COD_THABILITANTE = dr["COD_THABILITANTE"].ToString();
                                oCampos.NUM_POA_INT = Int32.Parse(dr["NUM_POA_INT"].ToString());
                                oCampos.FECHA_BEXT = dr["FECHA_BEXT"].ToString();
                                oCampos.COLOR = dr["COLOR"].ToString();
                                oCampos.MONTO = Decimal.Parse(dr["MONTO"].ToString());
                                oCampos.RES_REFORMULA_POA = dr["RES_REFORMULA_POA"].ToString();
                                oCampos.TEXTO_CADUCA = dr["TEXTO_CADUCA"].ToString();
                                oCampos.CONSULTOR = dr["CONSULTOR"].ToString();
                                oCampos.REGENTE_IMPLEMENTA = dr["REGENTE_IMPLEMENTA"].ToString();
                                oCampos.ES_ALERTA_OSINFOR = dr["ES_ALERTA_OSINFOR"].ToString();
                                oCampos.TIPO_SUPERVISION = dr["TIPO_SUPERVISION"].ToString();
                                oCampos.TIPO_MEDIDA = dr["TIPO_MEDIDA"].ToString();
                                oCampos.NUM_RESOLUCION_DERICTORAL = dr["NUM_RESOLUCION_DERICTORAL"].ToString();

                                oCampos.RESULTADO = Int32.Parse(dr["RESULTADO"].ToString());
                                oCampos.VALOR_PROBABILIDAD_1 = Int32.Parse(dr["VALOR_PROBABILIDAD_1"].ToString());
                                oCampos.VALOR_PROBABILIDAD_2 = Int32.Parse(dr["VALOR_PROBABILIDAD_2"].ToString());
                                oCampos.VALOR_PROBABILIDAD_3 = Int32.Parse(dr["VALOR_PROBABILIDAD_3"].ToString());

                                oCampos.PERDIDA_COBERTURA = decimal.Parse(dr["PERDIDA_COBERTURA"].ToString());
                                oCampos.APROV_NO_AUTORIZADO = decimal.Parse(dr["APROV_NO_AUTORIZADO"].ToString());
                                oCampos.SIGNIFICANCIA = Int32.Parse(dr["SIGNIFICANCIA"].ToString());
                                oCampos.IRREPARABILIDAD = Int32.Parse(dr["IRREPARABILIDAD"].ToString());

                                oCampos.VALOR_IMPACTO = Int32.Parse(dr["VALOR_IMPACTO"].ToString());
                                oCampos.PORCENT_INEX = dr["PORCENT_INEX"].ToString();
                                oCampos.VOL_INJUS = dr["VOL_INJUS"].ToString();
                                oCampos.PORCENT_INJUS_VOL = dr["PORCENT_INJUS_VOL"].ToString();
                                oCampos.CANT_ESP_VOL_INJUS = Int32.Parse(dr["CANT_ESP_VOL_INJUS"].ToString());
                                oCampos.CANT_ESP_SUPER = Int32.Parse(dr["CANT_ESP_SUPER"].ToString());
                                oCampos.OBSERVACION = dr["OBSERVACION"].ToString();
                                oCampos.INFRACCIONES = dr["INFRACCIONES"].ToString();
                                oCampos.ARCH_EVI_IRREG = dr["ARCH_EVI_IRREG"].ToString();
                                //oCampos.NUMERO_RESOLUCION_ALERTA= dr["NUMERO_RESOLUCION_ALERTA"].ToString();
                                //30/05/2019
                                oCampos.ALERTA = dr["ALERTA"].ToString();
                                oCampos.FECHA_ENVIO_ALERTA = dr["FECHA_ALERTA"].ToString();
                                oCampos.NUM_RESOLUCION_ANT_PAU = dr["RD_MEDCAUAPAU"].ToString();
                                oCampos.VOLUMEN_ALERTA = Decimal.Parse(dr["VOLUMEN_ALERTA"].ToString());

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
        public CEntidad RegMostrarListadoResumen(OracleConnection cn, CEntidad oCEntidad)
        {
            CEntidad lsCEntidad = new CEntidad();
            CEntidad oCampos;
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.new_REPORTE_Observatorio_v2", oCEntidad))
                {
                    lsCEntidad.List_Resumen_ROJO = new List<CEntidad>();
                    lsCEntidad.List_Resumen_AMBAR = new List<CEntidad>();
                    lsCEntidad.List_Resumen_VERDE = new List<CEntidad>();
                    if (dr != null)
                    {
                        if (oCEntidad.TIPO_REPORTE == "1")
                        {
                            //LISTA ROJA
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    oCampos = new CEntidad();
                                    oCampos.ID_REGISTRO = Int32.Parse(dr["ID_REGISTRO"].ToString());
                                    oCampos.TITULAR = dr["TITULAR"].ToString();
                                    oCampos.TITULAR_BUSQUEDA = dr["TITULAR_BUSQUEDA"].ToString();
                                    oCampos.NUM_THABILITANTE = dr["NUM_THABILITANTE"].ToString();
                                    oCampos.REGION = dr["REGION"].ToString();
                                    oCampos.UBICACION = dr["REGION"].ToString() + " / " + dr["PROVINCIA"].ToString() + " / " + dr["DISTRITO"].ToString();
                                    oCampos.NUM_POA = dr["NUM_POA"].ToString();
                                    oCampos.VOLUMEN = Decimal.Parse(dr["VOLUMEN"].ToString());
                                    oCampos.RES_APROBACION_POA = dr["RES_APROBACION_POA"].ToString();
                                    oCampos.VIGENCIA = dr["VIGENCIA"].ToString();
                                    oCampos.ZAFRA = dr["ZAFRA"].ToString();
                                    oCampos.INF_FALSA = dr["INF_FALSA"].ToString();
                                    oCampos.ESTADO = dr["ESTADO"].ToString();
                                    oCampos.MODALIDAD = dr["MODALIDAD"].ToString();
                                    oCampos.MEDIDA_CAUTELAR = dr["MED_CAU"].ToString();
                                    oCampos.ARBOLES_INEX = dr["ARBOLES_INEX"].ToString();
                                    oCampos.NUM_ARBOLES_INEX = Int32.Parse(dr["NUM_ARBOLES_INEX"].ToString());
                                    oCampos.FECHA_INICIO_TH = dr["FECHA_INICIO_TH"].ToString();
                                    oCampos.FECHA_TERMINO_TH = dr["FECHA_TERMINO_TH"].ToString();
                                    //oCampos.NIVEL_RIESGO = dr["NIVEL_RIESGO"].ToString();
                                    oCampos.FECHA_INGRESO = dr["FECHA_INGRESO"].ToString();
                                    oCampos.FECHA_SUPERVISION_INICIO = dr["FECHA_SUPERVISION_INICIO"].ToString();
                                    oCampos.FECHA_SUPERVISION_TERMINO = dr["FECHA_SUPERVISION_TERMINO"].ToString();
                                    oCampos.COD_THABILITANTE = dr["COD_THABILITANTE"].ToString();
                                    oCampos.NUM_POA_INT = Int32.Parse(dr["NUM_POA_INT"].ToString());
                                    oCampos.FECHA_BEXT = dr["FECHA_BEXT"].ToString();
                                    oCampos.MONTO = Decimal.Parse(dr["MONTO"].ToString());
                                    oCampos.RES_REFORMULA_POA = dr["RES_REFORMULA_POA"].ToString();
                                    oCampos.TEXTO_CADUCA = dr["TEXTO_CADUCA"].ToString();
                                    lsCEntidad.List_Resumen_ROJO.Add(oCampos);
                                }
                            }//LISTA AMBAR
                            dr.NextResult();
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    oCampos = new CEntidad();
                                    oCampos.ID_REGISTRO = Int32.Parse(dr["ID_REGISTRO"].ToString());
                                    oCampos.TITULAR = dr["TITULAR"].ToString();
                                    oCampos.TITULAR_BUSQUEDA = dr["TITULAR_BUSQUEDA"].ToString();
                                    oCampos.NUM_THABILITANTE = dr["NUM_THABILITANTE"].ToString();
                                    oCampos.REGION = dr["REGION"].ToString();
                                    oCampos.UBICACION = dr["REGION"].ToString() + " / " + dr["PROVINCIA"].ToString() + " / " + dr["DISTRITO"].ToString();
                                    oCampos.NUM_POA = dr["NUM_POA"].ToString();
                                    oCampos.VOLUMEN = Decimal.Parse(dr["VOLUMEN"].ToString());
                                    oCampos.RES_APROBACION_POA = dr["RES_APROBACION_POA"].ToString();
                                    oCampos.VIGENCIA = dr["VIGENCIA"].ToString();
                                    oCampos.ZAFRA = dr["ZAFRA"].ToString();
                                    oCampos.ESTADO = dr["ESTADO"].ToString();
                                    oCampos.MODALIDAD = dr["MODALIDAD"].ToString();
                                    oCampos.MEDIDA_CAUTELAR = dr["MED_CAU"].ToString();
                                    oCampos.MONTO = Decimal.Parse(dr["MONTO"].ToString());
                                    oCampos.RES_REFORMULA_POA = dr["RES_REFORMULA_POA"].ToString();
                                    lsCEntidad.List_Resumen_AMBAR.Add(oCampos);
                                }
                            }//LISTA VERDE
                            dr.NextResult();
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    oCampos = new CEntidad();
                                    oCampos.ID_REGISTRO = Int32.Parse(dr["ID_REGISTRO"].ToString());
                                    oCampos.TITULAR = dr["TITULAR"].ToString();
                                    oCampos.TITULAR_BUSQUEDA = dr["TITULAR_BUSQUEDA"].ToString();
                                    oCampos.NUM_THABILITANTE = dr["NUM_THABILITANTE"].ToString();
                                    oCampos.REGION = dr["REGION"].ToString();
                                    oCampos.UBICACION = dr["REGION"].ToString() + " / " + dr["PROVINCIA"].ToString() + " / " + dr["DISTRITO"].ToString();
                                    oCampos.NUM_POA = dr["NUM_POA"].ToString();
                                    oCampos.VOLUMEN = Decimal.Parse(dr["VOLUMEN"].ToString());
                                    oCampos.RES_APROBACION_POA = dr["RES_APROBACION_POA"].ToString();
                                    oCampos.VIGENCIA = dr["VIGENCIA"].ToString();
                                    oCampos.ZAFRA = dr["ZAFRA"].ToString();
                                    oCampos.ESTADO = dr["ESTADO"].ToString();
                                    oCampos.MODALIDAD = dr["MODALIDAD"].ToString();
                                    oCampos.INF_FALSA = dr["INF_FALSA"].ToString();
                                    oCampos.ARBOLES_INEX = dr["ARBOLES_INEX"].ToString();
                                    oCampos.NUM_ARBOLES_INEX = Int32.Parse(dr["NUM_ARBOLES_INEX"].ToString());
                                    oCampos.FECHA_INICIO_TH = dr["FECHA_INICIO_TH"].ToString();
                                    oCampos.FECHA_TERMINO_TH = dr["FECHA_TERMINO_TH"].ToString();
                                    oCampos.FECHA_INGRESO = dr["FECHA_INGRESO"].ToString();
                                    oCampos.FECHA_SUPERVISION_INICIO = dr["FECHA_SUPERVISION_INICIO"].ToString();
                                    oCampos.FECHA_SUPERVISION_TERMINO = dr["FECHA_SUPERVISION_TERMINO"].ToString();
                                    oCampos.COD_THABILITANTE = dr["COD_THABILITANTE"].ToString();
                                    oCampos.NUM_POA_INT = Int32.Parse(dr["NUM_POA_INT"].ToString());
                                    oCampos.FECHA_BEXT = dr["FECHA_BEXT"].ToString();
                                    oCampos.MONTO = Decimal.Parse(dr["MONTO"].ToString());
                                    oCampos.RES_REFORMULA_POA = dr["RES_REFORMULA_POA"].ToString();
                                    oCampos.TEXTO_CADUCA = dr["TEXTO_CADUCA"].ToString();
                                    lsCEntidad.List_Resumen_VERDE.Add(oCampos);
                                }
                            }
                        }
                        else if (oCEntidad.TIPO_REPORTE == "11")
                        {//LISTA ROJA
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    oCampos = new CEntidad();
                                    oCampos.ID_REGISTRO = Int32.Parse(dr["ID_REGISTRO"].ToString());
                                    oCampos.TITULAR = dr["TITULAR"].ToString();
                                    oCampos.TITULAR_BUSQUEDA = dr["TITULAR_BUSQUEDA"].ToString();
                                    oCampos.NUM_THABILITANTE = dr["NUM_THABILITANTE"].ToString();
                                    oCampos.REGION = dr["REGION"].ToString();
                                    oCampos.UBICACION = dr["REGION"].ToString() + " / " + dr["PROVINCIA"].ToString() + " / " + dr["DISTRITO"].ToString();
                                    oCampos.NUM_POA = dr["NUM_POA"].ToString();
                                    oCampos.VOLUMEN = Decimal.Parse(dr["VOLUMEN"].ToString());
                                    oCampos.RES_APROBACION_POA = dr["RES_APROBACION_POA"].ToString();
                                    oCampos.VIGENCIA = dr["VIGENCIA"].ToString();
                                    oCampos.ZAFRA = dr["ZAFRA"].ToString();
                                    oCampos.INF_FALSA = dr["INF_FALSA"].ToString();
                                    oCampos.ESTADO = dr["ESTADO"].ToString();
                                    oCampos.MODALIDAD = dr["MODALIDAD"].ToString();
                                    oCampos.MEDIDA_CAUTELAR = dr["MED_CAU"].ToString();
                                    oCampos.ARBOLES_INEX = dr["ARBOLES_INEX"].ToString();
                                    oCampos.NUM_ARBOLES_INEX = Int32.Parse(dr["NUM_ARBOLES_INEX"].ToString());
                                    oCampos.FECHA_INICIO_TH = dr["FECHA_INICIO_TH"].ToString();
                                    oCampos.FECHA_TERMINO_TH = dr["FECHA_TERMINO_TH"].ToString();
                                    //oCampos.NIVEL_RIESGO = dr["NIVEL_RIESGO"].ToString();
                                    oCampos.FECHA_INGRESO = dr["FECHA_INGRESO"].ToString();
                                    oCampos.FECHA_SUPERVISION_INICIO = dr["FECHA_SUPERVISION_INICIO"].ToString();
                                    oCampos.FECHA_SUPERVISION_TERMINO = dr["FECHA_SUPERVISION_TERMINO"].ToString();
                                    oCampos.COD_THABILITANTE = dr["COD_THABILITANTE"].ToString();
                                    oCampos.NUM_POA_INT = Int32.Parse(dr["NUM_POA_INT"].ToString());
                                    oCampos.FECHA_BEXT = dr["FECHA_BEXT"].ToString();
                                    oCampos.MONTO = Decimal.Parse(dr["MONTO"].ToString());
                                    oCampos.RES_REFORMULA_POA = dr["RES_REFORMULA_POA"].ToString();
                                    oCampos.TEXTO_CADUCA = dr["TEXTO_CADUCA"].ToString();
                                    oCampos.CONSULTOR = dr["CONSULTOR"].ToString();
                                    oCampos.ALERTA = dr["ALERTA"].ToString();
                                    oCampos.FECHA_ENVIO_ALERTA = dr["FECHA_ALERTA"].ToString();
                                    oCampos.NUM_RESOLUCION_ANT_PAU = dr["RD_MEDCAUAPAU"].ToString();

                                    lsCEntidad.List_Resumen_ROJO.Add(oCampos);
                                }
                            }
                        }
                        else if (oCEntidad.TIPO_REPORTE == "12")
                        {//LISTA AMBAR
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    oCampos = new CEntidad();
                                    oCampos.ID_REGISTRO = Int32.Parse(dr["ID_REGISTRO"].ToString());
                                    oCampos.TITULAR = dr["TITULAR"].ToString();
                                    oCampos.TITULAR_BUSQUEDA = dr["TITULAR_BUSQUEDA"].ToString();
                                    oCampos.NUM_THABILITANTE = dr["NUM_THABILITANTE"].ToString();
                                    oCampos.REGION = dr["REGION"].ToString();
                                    oCampos.UBICACION = dr["REGION"].ToString() + " / " + dr["PROVINCIA"].ToString() + " / " + dr["DISTRITO"].ToString();
                                    oCampos.NUM_POA = dr["NUM_POA"].ToString();
                                    oCampos.VOLUMEN = Decimal.Parse(dr["VOLUMEN"].ToString());
                                    oCampos.RES_APROBACION_POA = dr["RES_APROBACION_POA"].ToString();
                                    oCampos.VIGENCIA = dr["VIGENCIA"].ToString();
                                    oCampos.ZAFRA = dr["ZAFRA"].ToString();
                                    oCampos.ESTADO = dr["ESTADO"].ToString();
                                    oCampos.MODALIDAD = dr["MODALIDAD"].ToString();
                                    oCampos.MEDIDA_CAUTELAR = dr["MED_CAU"].ToString();
                                    oCampos.MONTO = Decimal.Parse(dr["MONTO"].ToString());
                                    oCampos.RES_REFORMULA_POA = dr["RES_REFORMULA_POA"].ToString();
                                    oCampos.CONSULTOR = dr["CONSULTOR"].ToString();
                                    lsCEntidad.List_Resumen_AMBAR.Add(oCampos);
                                }
                            }
                        }
                        else if (oCEntidad.TIPO_REPORTE == "13")
                        {//LISTA VERDE
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    oCampos = new CEntidad();
                                    oCampos.ID_REGISTRO = Int32.Parse(dr["ID_REGISTRO"].ToString());
                                    oCampos.TITULAR = dr["TITULAR"].ToString();
                                    oCampos.TITULAR_BUSQUEDA = dr["TITULAR_BUSQUEDA"].ToString();
                                    oCampos.NUM_THABILITANTE = dr["NUM_THABILITANTE"].ToString();
                                    oCampos.REGION = dr["REGION"].ToString();
                                    oCampos.UBICACION = dr["REGION"].ToString() + " / " + dr["PROVINCIA"].ToString() + " / " + dr["DISTRITO"].ToString();
                                    oCampos.NUM_POA = dr["NUM_POA"].ToString();
                                    oCampos.VOLUMEN = Decimal.Parse(dr["VOLUMEN"].ToString());
                                    oCampos.RES_APROBACION_POA = dr["RES_APROBACION_POA"].ToString();
                                    oCampos.VIGENCIA = dr["VIGENCIA"].ToString();
                                    oCampos.ZAFRA = dr["ZAFRA"].ToString();
                                    oCampos.ESTADO = dr["ESTADO"].ToString();
                                    oCampos.MODALIDAD = dr["MODALIDAD"].ToString();
                                    oCampos.INF_FALSA = dr["INF_FALSA"].ToString();
                                    oCampos.ARBOLES_INEX = dr["ARBOLES_INEX"].ToString();
                                    oCampos.NUM_ARBOLES_INEX = Int32.Parse(dr["NUM_ARBOLES_INEX"].ToString());
                                    oCampos.FECHA_INICIO_TH = dr["FECHA_INICIO_TH"].ToString();
                                    oCampos.FECHA_TERMINO_TH = dr["FECHA_TERMINO_TH"].ToString();
                                    oCampos.FECHA_INGRESO = dr["FECHA_INGRESO"].ToString();
                                    oCampos.FECHA_SUPERVISION_INICIO = dr["FECHA_SUPERVISION_INICIO"].ToString();
                                    oCampos.FECHA_SUPERVISION_TERMINO = dr["FECHA_SUPERVISION_TERMINO"].ToString();
                                    oCampos.COD_THABILITANTE = dr["COD_THABILITANTE"].ToString();
                                    oCampos.NUM_POA_INT = Int32.Parse(dr["NUM_POA_INT"].ToString());
                                    oCampos.FECHA_BEXT = dr["FECHA_BEXT"].ToString();
                                    oCampos.MONTO = Decimal.Parse(dr["MONTO"].ToString());
                                    oCampos.RES_REFORMULA_POA = dr["RES_REFORMULA_POA"].ToString();
                                    oCampos.TEXTO_CADUCA = dr["TEXTO_CADUCA"].ToString();
                                    oCampos.CONSULTOR = dr["CONSULTOR"].ToString();
                                    lsCEntidad.List_Resumen_VERDE.Add(oCampos);
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
        public CEntidad RegMostrarListadoResoluciones(OracleConnection cn, CEntidad oCEntidad)
        {
            CEntidad lsCEntidad = new CEntidad();
            CEntidad oCampos;
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.new_REPORTE_Observatorio_v2", oCEntidad))
                {
                    lsCEntidad.List_Resoluciones = new List<CEntidad>();
                    //lsCEntidad.List_Injus_Inf = new List<CEntidad>();
                    if (dr != null)
                    {
                        //if (dr.HasRows)
                        //{
                        //    while (dr.Read())
                        //    {
                        //        oCampos = new CEntidad();
                        //        oCampos.COD_INFORME = dr["COD_INFORME"].ToString();
                        //        oCampos.COD_ENCIENTIFICO = dr["COD_ENCIENTIFICO"].ToString();
                        //        oCampos.NOM_CIENTIFICO = dr["NOM_CIENTIFICO"].ToString();
                        //        oCampos.NOMBRE_COMUN = dr["NOMBRE_COMUN"].ToString();
                        //        oCampos.VOLUMEN_BEXT = Decimal.Parse(dr["VOLUMEN_BEXT"].ToString());
                        //        oCampos.VOLUMEN_AUT = Decimal.Parse(dr["VOLUMEN_AUT"].ToString());
                        //        oCampos.VOLUMEN = Decimal.Parse(dr["VOLUMEN"].ToString());
                        //        oCampos.PORCENT_BEXT = dr["PORCENT_BEXT"].ToString();
                        //        oCampos.PORCENT_AUT = dr["PORCENT_AUT"].ToString();
                        //        oCampos.OBSERVACION = dr["OBSERVACION"].ToString();
                        //        lsCEntidad.List_Injus_Inf.Add(oCampos);
                        //    }
                        //}


                        //dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                oCampos.COD_RESODIREC = dr["COD_RESODIREC"].ToString();
                                oCampos.NUM_RESOLUCION = dr["NUM_RESOLUCION"].ToString();
                                oCampos.TIPO_RESOLUCION = dr["TIPO_RESOLUCION"].ToString();
                                oCampos.MEDIDA_CAUTELAR = Int32.Parse(dr["MEDIDA_CAUTELAR"].ToString());
                                oCampos.CADUCIDAD = Int32.Parse(dr["CADUCIDAD"].ToString());

                                oCampos.IMPROCEDENTE = Int32.Parse(dr["IMPROCEDENTE"].ToString());
                                oCampos.FUNDADA = Int32.Parse(dr["FUNDADA"].ToString());
                                oCampos.FUNDADA_PARTE = Int32.Parse(dr["FUNDADA_PARTE"].ToString());
                                oCampos.INFUNDADA = Int32.Parse(dr["INFUNDADA"].ToString());
                                oCampos.DESISTIMIENTO = Int32.Parse(dr["DESISTIMIENTO"].ToString());
                                oCampos.INADMISIBLE = Int32.Parse(dr["INADMISIBLE"].ToString());
                                oCampos.NULIDAD = Int32.Parse(dr["NULIDAD"].ToString());
                                oCampos.REVOCAR = Int32.Parse(dr["REVOCAR"].ToString());
                                oCampos.SUSPENSION = Int32.Parse(dr["SUSPENSION"].ToString());
                                oCampos.LEVANTAR_CADUCIDAD = Int32.Parse(dr["LEVANTAR_CADUCIDAD"].ToString());
                                oCampos.CAMBIO_MULTA = Int32.Parse(dr["CAMBIO_MULTA"].ToString());

                                oCampos.CAMBIO_USO = dr["CAMBIO_USO"].ToString();
                                oCampos.AREA_CAMBIO_USO = Decimal.Parse(dr["AREA_CAMBIO_USO"].ToString());
                                oCampos.FECHA_INGRESO = dr["FECHA_INGRESO"].ToString();
                                oCampos.INFRACCIONES = dr["INFRACCIONES"].ToString();
                                oCampos.URL_RESOLUCION = dr["URL_RESOLUCION"].ToString();
                                oCampos.RD_MOSTRAR_INCISOS = Int32.Parse(dr["MOSTRAR_INCISOS"].ToString());

                                oCampos.DETERMINACION = dr["DETERMINACION"].ToString();
                                oCampos.MONTO = Decimal.Parse(dr["MONTO"].ToString());

                                oCampos.MULTA = Decimal.Parse(dr["MULTA"].ToString());
                                oCampos.LITERAL = dr["LITERAL"].ToString();

                                oCampos.SENTIDO_RES = dr["SENTIDO_RES"].ToString();
                                oCampos.RESOL_DET = dr["RESOL_DET"].ToString();
                                oCampos.RESOL_DET2 = dr["RESOL_DET2"].ToString();
                                oCampos.CHKCONFIRMAR = Int32.Parse(dr["CHKCONFIRMAR"].ToString());
                                oCampos.CHKREVOCAR = Int32.Parse(dr["CHKREVOCAR"].ToString());
                                oCampos.RADREVOCAR = dr["RADREVOCAR"].ToString();
                                oCampos.CHKREVOCARPARTE = Int32.Parse(dr["CHKREVOCARPARTE"].ToString());
                                oCampos.CHKRETROTRAER = Int32.Parse(dr["CHKRETROTRAER"].ToString());
                                oCampos.RADRETROTRAER = dr["RADRETROTRAER"].ToString();

                                oCampos.CHKPRESCRIBIR = Int32.Parse(dr["CHKPRESCRIBIR"].ToString());
                                oCampos.CHKARCHIVAR = Int32.Parse(dr["CHKARCHIVAR"].ToString());
                                oCampos.CHKNULIDAD = Int32.Parse(dr["CHKNULIDAD"].ToString());
                                oCampos.RADNULIDAD = dr["RADNULIDAD"].ToString();
                                oCampos.CHKLEVANTAR = Int32.Parse(dr["CHKLEVANTAR"].ToString());
                                oCampos.CHKCARECE = Int32.Parse(dr["CHKCARECE"].ToString());
                                oCampos.CHKOTRO = Int32.Parse(dr["CHKOTRO"].ToString());
                                oCampos.CHKCONFIRMAR2 = Int32.Parse(dr["CHKCONFIRMAR2"].ToString());
                                oCampos.CHKREVOCAR2 = Int32.Parse(dr["CHKREVOCAR2"].ToString());
                                oCampos.RADREVOCAR2 = dr["RADREVOCAR2"].ToString();
                                oCampos.CHKREVOCARPARTE2 = Int32.Parse(dr["CHKREVOCARPARTE2"].ToString());
                                oCampos.CHKRETROTRAER2 = Int32.Parse(dr["CHKRETROTRAER2"].ToString());
                                oCampos.RADRETROTRAER2 = dr["RADRETROTRAER2"].ToString();
                                oCampos.CHKPRESCRIBIR2 = Int32.Parse(dr["CHKPRESCRIBIR2"].ToString());
                                oCampos.CHKARCHIVAR2 = Int32.Parse(dr["CHKARCHIVAR2"].ToString());
                                oCampos.CHKNULIDAD2 = Int32.Parse(dr["CHKNULIDAD2"].ToString());
                                oCampos.RADNULIDAD2 = dr["RADNULIDAD2"].ToString();
                                oCampos.CHKLEVANTAR2 = Int32.Parse(dr["CHKLEVANTAR2"].ToString());
                                oCampos.CHKCARECE2 = Int32.Parse(dr["CHKCARECE2"].ToString());
                                oCampos.CHKOTRO2 = Int32.Parse(dr["CHKOTRO2"].ToString());
                                oCampos.RESOL_DET3 = dr["RESOL_DET3"].ToString();
                                oCampos.DETERMINA_RETROTRAER = dr["DETERMINA_RETROTRAER"].ToString();
                                oCampos.RETRO_VALOR1 = dr["RETRO_VALOR1"].ToString();
                                oCampos.DETERMINA_RETROTRAER2 = dr["DETERMINA_RETROTRAER2"].ToString();
                                oCampos.RETRO_VALOR2 = dr["RETRO_VALOR2"].ToString();
                                oCampos.RADREVOCARPARTE = dr["RADREVOCARPARTE"].ToString();
                                oCampos.RADREVOCARPARTE2 = dr["RADREVOCARPARTE2"].ToString();

                                lsCEntidad.List_Resoluciones.Add(oCampos);
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
        public List<CEntidad> RegMostrarDesListadoIncisos(OracleConnection cn, CEntidad oCEntidad)
        {
            CEntidad lsCEntidad = new CEntidad();
            CEntidad oCampos;
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.new_REPORTE_Observatorio_v2", oCEntidad))
                {
                    lsCEntidad.List_Detalle_Titular = new List<CEntidad>();
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                oCampos.INFRACCIONES = dr["INFRACCIONES"].ToString();
                                oCampos.INCISO = dr["INCISO"].ToString();
                                oCampos.TEXTO = dr["TEXTO"].ToString();
                                lsCEntidad.List_Detalle_Titular.Add(oCampos);
                            }
                        }
                    }
                }
                return lsCEntidad.List_Detalle_Titular;
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
        public List<CEntidad> RegMostrarListadoIncisos(OracleConnection cn, CEntidad oCEntidad)
        {
            CEntidad lsCEntidad = new CEntidad();
            CEntidad oCampos;
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.new_REPORTE_Observatorio_v2", oCEntidad))
                {
                    lsCEntidad.List_Detalle_Titular = new List<CEntidad>();
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                oCampos.INCISO = dr["INCISO"].ToString();
                                oCampos.DESC_ESPECIES = dr["DESC_ESPECIES"].ToString();
                                oCampos.VOLUMEN_BEXT = Decimal.Parse(dr["VOLUMEN_BEXT"].ToString());
                                oCampos.VOLUMEN_AUT = Decimal.Parse(dr["VOLUMEN_AUT"].ToString());
                                oCampos.VOLUMEN = Decimal.Parse(dr["VOLUMEN"].ToString());
                                oCampos.PORCENT_BEXT = dr["PORCENT_BEXT"].ToString();
                                oCampos.PORCENT_AUT = dr["PORCENT_AUT"].ToString();
                                oCampos.PC = dr["PARCELA"].ToString();
                                lsCEntidad.List_Detalle_Titular.Add(oCampos);
                            }
                        }
                    }
                }
                return lsCEntidad.List_Detalle_Titular;
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
        public List<CEntidad> RegMostrarListadoInexistentes(OracleConnection cn, CEntidad oCEntidad)
        {
            CEntidad lsCEntidad = new CEntidad();
            CEntidad oCampos;
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.new_REPORTE_Observatorio_v2", oCEntidad))
                {
                    lsCEntidad.List_Detalle_Titular = new List<CEntidad>();
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                oCampos.DESC_ESPECIES = dr["DESC_ESPECIE"].ToString();
                                oCampos.NUM_ARB_MUESTRA = Int32.Parse(dr["NUM_ARB_MUESTRA"].ToString());
                                oCampos.NUM_ARB_EXIST = Int32.Parse(dr["NUM_ARB_EXIST"].ToString());
                                oCampos.NUM_ARB_INEX = Int32.Parse(dr["NUM_ARB_INEX"].ToString());
                                oCampos.VOLUMEN_DECLARADO = Decimal.Parse(dr["VOLUMEN_DECLARADO"].ToString());
                                oCampos.PORCENT_INEX = dr["PORCENT_INEX"].ToString();
                                lsCEntidad.List_Detalle_Titular.Add(oCampos);
                            }
                        }
                    }
                }
                return lsCEntidad.List_Detalle_Titular;
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
        public List<CEntidad> RegMostrarListadoJustNoJust(OracleConnection cn, CEntidad oCEntidad)
        {
            CEntidad lsCEntidad = new CEntidad();
            CEntidad oCampos;
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.new_REPORTE_Observatorio_v2", oCEntidad))
                {
                    lsCEntidad.List_Detalle_Titular = new List<CEntidad>();
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                oCampos.DESC_ESPECIES = dr["DESC_ESPECIE"].ToString();
                                oCampos.VOLUMEN_AUT = Decimal.Parse(dr["VOLUMEN_AUT"].ToString());
                                oCampos.VOLUMEN_BEXT = Decimal.Parse(dr["VOLUMEN_BEXT"].ToString());
                                oCampos.VOLUMEN_VERIFICADO = Decimal.Parse(dr["VOLUMEN_VERIFICADO"].ToString());
                                oCampos.PC = dr["PARCELA"].ToString();

                                lsCEntidad.List_Detalle_Titular.Add(oCampos);
                            }
                        }
                    }
                }
                return lsCEntidad.List_Detalle_Titular;
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
        public CEntidad RegMostrarFechaObserv(OracleConnection cn, CEntidad oCEntidad)
        {
            CEntidad oCampos = new CEntidad();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.new_REPORTE_ObservatorioFecha", oCEntidad))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                oCampos.PARAMETRO = dr["PARAMETRO"].ToString();
                                oCampos.FECHA = dr["VALOR"].ToString();
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
        /// metodo para descargar la lista de especies del observatorio
        /// 03/05/2018 CR
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public List<CEntidad> RegMostrarEspecies(OracleConnection cn, CEntidad oCEntidad)
        {

            List<CEntidad> lsCEntidad = new List<CEntidad>();
            //CEntidad oCampos = new CEntidad();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "HERR_OSINFOR_ERP_MIGRACION.spDESCARGA_ESP", oCEntidad))
                {
                    if (dr != null)
                    {
                        CEntidad oCampos = new CEntidad();
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("TITULAR");
                            int pt2 = dr.GetOrdinal("TITULO");
                            int pt3 = dr.GetOrdinal("MODALIDAD");
                            int pt4 = dr.GetOrdinal("DEPARTAMENTO");
                            int pt5 = dr.GetOrdinal("NUM_POA");
                            int pt24 = dr.GetOrdinal("RES_APROBACION_POA");
                            int pt25 = dr.GetOrdinal("RES_REFORMULA_POA");
                            int pt6 = dr.GetOrdinal("VIGENCIA");
                            int pt7 = dr.GetOrdinal("ZAFRA");
                            int pt8 = dr.GetOrdinal("COLOR_STRING");
                            int pt9 = dr.GetOrdinal("ESTADO_TH");
                            int pt10 = dr.GetOrdinal("NUM_RDINICIO");
                            int pt11 = dr.GetOrdinal("NUM_RDTERMINO");
                            int pt12 = dr.GetOrdinal("ESTADO_PROCESO");
                            int pt13 = dr.GetOrdinal("TIPO_DETALLE");
                            int pt14 = dr.GetOrdinal("NOMBRE_CIENTIFICO");
                            int pt15 = dr.GetOrdinal("NOMBRE_COMUN");
                            int pt16 = dr.GetOrdinal("VOLUMEN_AUT");
                            int pt17 = dr.GetOrdinal("VOLUMEN_BEXT");
                            int pt18 = dr.GetOrdinal("VOLUMEN");
                            int pt19 = dr.GetOrdinal("PORC_MOV");
                            int pt20 = dr.GetOrdinal("PORC_MOV2");
                            int pt21 = dr.GetOrdinal("NUM_ARB_MUESTRA");
                            int pt22 = dr.GetOrdinal("NUM_ARB_INEX");
                            int pt23 = dr.GetOrdinal("PORC_INEX");

                            while (dr.Read())
                            {
                                //PARTE_DIARIO_DETALLE
                                oCampos = new CEntidad();
                                oCampos.TITULAR = dr.GetString(pt1);
                                oCampos.NUM_THABILITANTE = dr.GetString(pt2);
                                oCampos.MODALIDAD = dr.GetString(pt3);
                                oCampos.REGION = dr.GetString(pt4);
                                oCampos.NUM_POA = dr.GetString(pt5);
                                oCampos.RES_APROBACION_POA = dr.GetString(pt24);
                                oCampos.RES_REFORMULA_POA = dr.GetString(pt25);
                                oCampos.VIGENCIA = dr.GetString(pt6);
                                oCampos.ZAFRA = dr.GetString(pt7);
                                oCampos.COLOR = dr.GetString(pt8);
                                oCampos.ESTADO_TH = dr.GetString(pt9);
                                oCampos.NUM_RDINICIO = dr.GetString(pt10);
                                oCampos.NUM_RDTERMINO = dr.GetString(pt11);
                                oCampos.ESTADO = dr.GetString(pt12);
                                oCampos.TIPO_REPORTE = dr.GetString(pt13);
                                oCampos.NOM_CIENTIFICO = dr.GetString(pt14);
                                oCampos.NOMBRE_COMUN = dr.GetString(pt15);
                                oCampos.VOLUMEN_AUT = dr.GetDecimal(pt16);
                                oCampos.VOLUMEN_BEXT = dr.GetDecimal(pt17);
                                oCampos.VOLUMEN = dr.GetDecimal(pt18);
                                oCampos.PORCENT_AUT = dr.GetDecimal(pt19).ToString();
                                oCampos.PORCENT_INJUS_VOL = dr.GetDecimal(pt20).ToString();
                                oCampos.NUM_ARB_MUESTRA = dr.GetInt32(pt21);
                                oCampos.NUM_ARBOLES_INEX = dr.GetInt32(pt22);
                                oCampos.PORCENT_INEX = dr.GetDecimal(pt23).ToString();
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
