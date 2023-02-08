using Oracle.ManagedDataAccess.Client;
using System;
using System.Data.SqlClient;
using CDatos = CapaDatos.DOC.Dat_SINCRONIZACION;
using CEntidad = CapaEntidad.DOC.Ent_SINCRONIZACION;

namespace CapaLogica.DOC
{
    /// <summary>
    /// 
    /// </summary>
    public class Log_Sincronizacion
    {
        private CDatos oCDatos = new CDatos();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public CEntidad RegMostrarLista(CEntidad oCEntidad)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
                {
                    cn.Open();
                    return oCDatos.RegMostrarLista(cn, oCEntidad);
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        //public CEntidad RegMostCombo(CEntidad oCEntidad)
        //{
        //    try
        //    {
        //        using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena()))
        //        {
        //            cn.Open();
        //            return oCDatos.RegMostCombo(cn, oCEntidad);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        public CEntidad RegSincronizar(CEntidad oCampoEntrada)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
                {
                    cn.Open();
                    return oCDatos.RegSincronizar(cn, oCampoEntrada);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public CEntidad RegProcedimientos(CEntidad oCampoEntrada)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
                {
                    cn.Open();
                    return oCDatos.RegProcedimientos(cn, oCampoEntrada);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public String RegEliminar(CEntidad oCampoEntrada)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
                {
                    cn.Open();
                    return oCDatos.RegEliminar(cn, oCampoEntrada);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
