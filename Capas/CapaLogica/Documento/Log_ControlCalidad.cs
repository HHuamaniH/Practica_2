using Oracle.ManagedDataAccess.Client;
using System;
//using System.Collections.Generic;
//using System.Data.SqlClient;
using CDatos = CapaDatos.DOC.Dat_ControlCalidad;
using CEntidad = CapaEntidad.DOC.Ent_ControlCalidad;

namespace CapaLogica.DOC
{
    public class Log_ControlCalidad
    {
        private CDatos oCDatos = new CDatos();

        public CEntidad RegMostCombo(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    oCampoEntrada.BusFormulario = "REPORTE_CONTROL_CALIDAD";
                    return oCDatos.RegMostCombo(cn, oCampoEntrada);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public CEntidad RegMostrarControlCalidadResumen(CEntidad oCampoEntrada)
        //{
        //    try
        //    {
        //        oCampoEntrada.TIPO_REPORTE = "RESUMEN";
        //        oCampoEntrada.COD_ESTADO_DOC = GetCodEstadoDocumento(oCampoEntrada.COD_ESTADO_DOC);

        //        using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
        //        {
        //            cn.Open();
        //            return oCDatos.RegMostrarControlCalidadResumen(cn, oCampoEntrada);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public List<CEntidad> RegMostrarControlCalidadDetalle(CEntidad oCampoEntrada)
        //{
        //    try
        //    {
        //        oCampoEntrada.TIPO_REPORTE = "DETALLE";
        //        oCampoEntrada.COD_ESTADO_DOC = GetCodEstadoDocumento(oCampoEntrada.COD_ESTADO_DOC);

        //        using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
        //        {
        //            cn.Open();
        //            return oCDatos.RegMostrarControlCalidadDetalle(cn, oCampoEntrada);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        private string GetCodEstadoDocumento(string aoColumnaEstado)
        {
            string codigo = "";

            switch (aoColumnaEstado)
            {
                case "PR": codigo = "0000001"; break;
                case "RC": codigo = "0000002"; break;
                case "PCC": codigo = "0000005"; break;
                case "CCC": codigo = "0000006"; break;
                case "CCO": codigo = "0000007"; break;
            }

            return codigo;
        }
    }
}
