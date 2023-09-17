using Herramienta;
using System;
using System.Collections.Generic;
//using System.Data.SqlClient;
//using CDatos = CapaDatos.DOC.Dat_Reporte_OBSERVATORIO;
using CDatos = CapaDatos.DOC.Dat_Reporte_OBSERVATORIO_SIMULACION;
using CEntidad = CapaEntidad.DOC.Ent_Reporte_OBSERVATORIO;
using Oracle.ManagedDataAccess.Client;
//using oCLogicaFooter = CapaLogica.PDFFooter;
//librerias para exportar a pdf
//using iTextSharp.text.pdf;

namespace CapaLogica.DOC
{
    public class Log_Reporte_OBSERVATORIO
    {
        private CDatos oCDatos = new CDatos();
        Utilitarios HerUtil = new Utilitarios();
        List<CEntidad> ListadoIncisos = new List<CEntidad>();
        //Document doc;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="oCampoEntrada"></param>
        /// <returns></returns>
        public CEntidad RegMostrarElement(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegMostrarElement(cn, oCampoEntrada);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="oCampoEntrada"></param>
        /// <returns></returns>
        public CEntidad RegMostrarListadoResumen(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegMostrarListadoResumen(cn, oCampoEntrada);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CEntidad RegMostrarFechaObserv(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegMostrarFechaObserv(cn, oCampoEntrada);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CEntidad> RegMostrarListEspecies(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegMostrarEspecies(cn, oCampoEntrada);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
