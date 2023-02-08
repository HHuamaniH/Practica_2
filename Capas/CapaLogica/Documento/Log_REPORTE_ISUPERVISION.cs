using System;
using System.Collections.Generic;
//using System.Data.SqlClient;
using CDatos = CapaDatos.DOC.Dat_REPORTE_ISUPERVISION;
using CEntidad = CapaEntidad.DOC.Ent_REPORTE_ISUPERVISION;
using Oracle.ManagedDataAccess.Client;
namespace CapaLogica.DOC
{
    /// <summary>
    /// 
    /// </summary>
    public class Log_REPORTE_ISUPERVISION
    {
        private CDatos oCDatos = new CDatos();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="oCampoEntrada"></param>
        /// <returns></returns>
        //public List<CEntidad> RegMostrarSUPERVISION_anio(CEntidad oCampoEntrada)
        //{
        //    try
        //    {
        //        using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
        //        {
        //            cn.Open();
        //            return oCDatos.RegMostrarSUPERVISION_anio(cn, oCampoEntrada);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="oCampoEntrada"></param>
        /// <returns></returns>
        //public List<CEntidad> MostrarArbol_Mayor_Aprovechamiento(CEntidad oCampoEntrada)
        //{
        //    try
        //    {
        //        using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
        //        {
        //            cn.Open();
        //            return oCDatos.MostrarArbol_Mayor_Aprovechamiento(cn, oCampoEntrada);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="oCampoEntrada"></param>
        /// <returns></returns>
        //public List<CEntidad> MostrarConsultor_Mayor_Poa(CEntidad oCampoEntrada)
        //{
        //    try
        //    {
        //        using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
        //        {
        //            cn.Open();
        //            return oCDatos.MostrarConsultor_Mayor_Poa(cn, oCampoEntrada);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="oCampoEntrada"></param>
        /// <returns></returns>
        //public CEntidad MostrarArbol_Inexistente(CEntidad oCampoEntrada)
        //{
        //    try
        //    {
        //        using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
        //        {
        //            cn.Open();
        //            return oCDatos.MostraraArbol_Inexistente(cn, oCampoEntrada);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="oCampoEntrada"></param>
        /// <returns></returns>
        //public List<CEntidad> MostrarInicio_PAU(CEntidad oCampoEntrada)
        //{
        //    try
        //    {
        //        using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
        //        {
        //            cn.Open();
        //            return oCDatos.MostrarInicio_PAU(cn, oCampoEntrada);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="oCampoEntrada"></param>
        /// <returns></returns>
        //public List<CEntidad> MostrarInfraccion_PAU(CEntidad oCampoEntrada)
        //{
        //    try
        //    {
        //        using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
        //        {
        //            cn.Open();
        //            return oCDatos.MostrarInfraccion_PAU(cn, oCampoEntrada);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="oCampoEntrada"></param>
        /// <returns></returns>
        //public List<CEntidad> MostrarVolumne_Inicio_PAU(CEntidad oCampoEntrada)
        //{
        //    try
        //    {
        //        using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
        //        {
        //            cn.Open();
        //            return oCDatos.MostrarVolumen_Inicio_PAU(cn, oCampoEntrada);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="oCampoEntrada"></param>
        /// <returns></returns>
        //public List<CEntidad> RegMostrarEncisos(CEntidad oCampoEntrada)
        //{
        //    try
        //    {
        //        using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
        //        {
        //            cn.Open();
        //            return oCDatos.MostrarEncisos(cn, oCampoEntrada);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //metodo para devolver la lista de personas 
        //public List<CEntidad> RegPopupBuscarPersonas(CEntidad oCEntidad)
        //{
        //    try
        //    {
        //        using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
        //        {
        //            cn.Open();
        //            return oCDatos.RegPopupBuscarPersonas(cn, oCEntidad);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public List<CEntidad> MostrarOportunidadSupervisiones_Resumen(CEntidad oCEntidad)
        {
            try
            {
                oCEntidad.TIPO_REPORTE = "RESUMEN";

                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.MostrarOportunidadSupervisiones_Resumen(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<CEntidad> MostrarOportunidadSupervisiones_Detalle(CEntidad oCEntidad)
        {
            try
            {
                oCEntidad.TIPO_REPORTE = "DETALLE";

                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.MostrarOportunidadSupervisiones_Detalle(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
