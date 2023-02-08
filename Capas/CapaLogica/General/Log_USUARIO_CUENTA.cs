using Oracle.ManagedDataAccess.Client;

using System;
using System.Collections.Generic;
//using System.Data.SqlClient;
using CDatos = CapaDatos.GENE.Dat_USUARIO_CUENTA;
using CEntidad = CapaEntidad.GENE.Ent_USUARIO_CUENTA;
//using CEntidadUCDMS = CapaEntidad.GENE.Ent_USUARIO_CUENTA_DET_MODULOS;
//using CEntidadUCDMMU = CapaEntidad.GENE.Ent_USUARIO_CUENTA_DET_MODULOS_MENU;

namespace CapaLogica.GENE
{
    public class Log_USUARIO_CUENTA
    {
        private CDatos oCDatos = new CDatos();
        //public List<CEntidad> RegLoginValidando(CEntidad oCEntidad, string version)
        //{
        //    try
        //    {
        //        using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
        //        {
        //            cn.Open();
        //            return oCDatos.RegLoginValidando(cn, oCEntidad, version);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //Obtiene los accesos por perfil y accesos por usuarios de una cuenta
        public List<CEntidad> RegLoginValidandoV3(CEntidad oCEntidad, string version)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegLoginValidandoV3(cn, oCEntidad, version);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Metodo para modificar la contrase�a para usuarios de la base de datos del SITD desde el SIGO (para usuarios de base de datos principal)
        /// </summary>
        /// <param name="oCampoEntrada"></param>
        /// <returns></returns>
        public String RegUpdatePasswordSITD(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegUpdatePasswordSITD(cn, oCampoEntrada);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //public String RegInstanciaSIGO(CEntidad oCampoEntrada)
        //{
        //    try
        //    {
        //        using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
        //        {
        //            cn.Open();
        //            return oCDatos.RegInstanciaSIGO(cn, oCampoEntrada);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        public String devuelvetipoAutenticacion()
        {
            CEntidad oCEntidad = new CEntidad();
            oCEntidad.OUTPUTPARAM01 = "";
            try
            {                
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.devuelvetipoAutenticacion(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public List<CEntidad> RegLoginValidandoIntegrado(CEntidad oCEntidad, string version)
        //{
        //    try
        //    {
        //        using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
        //        {
        //            cn.Open();
        //            return oCDatos.RegLoginValidandoiNTEGRADO(cn, oCEntidad, version);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        public List<CEntidad> RegLoginValidandoIntegradoV3(CEntidad oCEntidad, string version)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegLoginValidandoIntegradoV3(cn, oCEntidad, version);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public String RegAuditoriaUsuario(CapaEntidad.GENE.Ent_AUDITORIA aoCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegAuditoriaUsuario(cn, aoCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
