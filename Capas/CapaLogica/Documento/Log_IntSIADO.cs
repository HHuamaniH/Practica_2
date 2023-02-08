using CapaEntidad.DOC;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
//using System.Data.SqlClient;
using CDatIntSIADO = CapaDatos.DOC.Dat_IntSIADO;
using CEntIntSIADO = CapaEntidad.DOC.Ent_IntSIADO;

namespace CapaLogica.DOC
{
    /// <summary>
    /// 24/08/2018  EPB: Se comentan los procedimientos de incersión y borrado porque esas tareas se realizan directamente desde el SIADO
    /// </summary>
    public class Log_IntSIADO
    {
        private CDatIntSIADO oCDatos = new CDatIntSIADO();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public CEntIntSIADO RegMostrarListaSIADO(CEntIntSIADO oCEntidad)
        {
            try
            {
                //SqlConnection cnSIADO = new OracleConnection(BDConexion.Conexion_Cadena_SIADO());
                //cnSIADO.Open();
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegMostrarListaSIADO(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Ent_IntSIADO_V3> RegMostrarListaSIADO_V3(CEntIntSIADO oCEntidad)
        {
            try
            {
                //SqlConnection cnSIADO = new OracleConnection(BDConexion.Conexion_Cadena_SIADO());
                //cnSIADO.Open();
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegMostrarListaSIADO_V3(cn, oCEntidad);
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
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public List<CEntIntSIADO> listarExpedientesSIADO(CEntIntSIADO oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.listarExpedientesSIADO(cn, oCEntidad);
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
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        //public String RegistrarFicheroSIADO(CEntIntSIADO oCEntidad)
        //{
        //    try
        //    {                
        //        using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIADO()))
        //        {
        //            cn.Open();
        //            return oCDatos.RegistrarFicheroSIADO(cn, oCEntidad);
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
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        //public String ReplicarFicheroSIGO(CEntIntSIADO oCEntidad)
        //{
        //    try
        //    {
        //        using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
        //        {
        //            cn.Open();
        //            return oCDatos.ReplicarFicheroSIGO(cn, oCEntidad);
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
        //public Int32 EliminarFicheroSIADO(CEntIntSIADO oCampoEntrada)
        //{
        //    try
        //    {
        //        using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIADO()))
        //        {
        //            cn.Open();
        //            return oCDatos.EliminarFicheroSIADO(cn, oCampoEntrada);
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
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        //public Int32 ActualizarSubidaFicheroSIADO(CEntIntSIADO oCEntidad)
        //{
        //    try
        //    {                
        //        using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIADO()))
        //        {
        //            cn.Open();
        //            return oCDatos.ActualizarSubidaFicheroSIADO(cn, oCEntidad);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
    }
}
