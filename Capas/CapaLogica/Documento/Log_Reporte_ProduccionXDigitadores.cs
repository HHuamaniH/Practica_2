using System;
using System.Collections.Generic;
//using System.Data.SqlClient;
//using CEntidadU = CapaEntidad.DOC.Ent_REPORTE_x_USUARIOS;
using CDatos = CapaDatos.DOC.Dat_Reporte_ProduccionXDigitadores;
using CEntidad = CapaEntidad.DOC.Ent_Reporte_ProduccionXDigitadores;
using Oracle.ManagedDataAccess.Client;
namespace CapaLogica.DOC
{
    public class Log_Reporte_ProduccionXDigitadores
    {
        private CDatos oCDatos = new CDatos();

        //public List<CEntidad> RegProdXDigitador01(CEntidad oCEntidad)
        //{
        //    try
        //    {
        //        using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
        //        {
        //            cn.Open();
        //            return oCDatos.RegProdXDigitador01(cn, oCEntidad);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}


        public List<CEntidad> RegProdXDigitador(CEntidad oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegProdXDigitador(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //public List<CEntidad> RegProdXDigitadorDetalle(CEntidad oCEntidad)
        //{
        //    try
        //    {
        //        using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
        //        {
        //            cn.Open();
        //            return oCDatos.RegProdXDigitadorDetalle(cn, oCEntidad);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        public List<CEntidad> RegProdXDigitadorDetalleRegistros(CEntidad oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegProdXDigitadorDetalleRegistros(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
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
        //para los reportes de usuarios
        //public List<CEntidadU> RegProdXUsuario (CEntidadU oCEntidad)
        //{
        //    try
        //    {
        //        using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
        //        {
        //            cn.Open();
        //            return oCDatos.RegProdXUsuario(cn, oCEntidad);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //public List<CEntidadU> RegProdXUsuarioDetalle(CEntidadU oCEntidad)
        //{
        //    try
        //    {
        //        using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
        //        {
        //            cn.Open();
        //            return oCDatos.RegProdXUsuarioDetalle(cn, oCEntidad);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //RegProdXUsuarioDetalle01

        //public List<CEntidadU> RegProdXUsuarioDetalle01(CEntidadU oCEntidad)
        //{
        //    try
        //    {
        //        using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
        //        {
        //            cn.Open();
        //            return oCDatos.RegProdXUsuarioDetalle01(cn, oCEntidad);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        /// <summary>
        /// metodo para obtener el registro de informacion _SIGO de las OD
        /// </summary>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public List<CEntidad> logRegistroInformacionList(CEntidad oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.datRegistroInformacion(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CEntidad> logRegistroInformacionDetalle(CEntidad oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.datRegistroInformacionDetalle(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CEntidad> logRegistroInformacionDetalle2(CEntidad oCEntidad)
        {
            try
            {




                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.datRegistroInformacionDetalle2(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CEntidad> logRegistroInformacionExpediente(CEntidad oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.datRegistroInformacionExpedientes(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CEntidad> logRegistroInformacionExpediente2(CEntidad oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();


                    return oCDatos.datRegistroInformacioExpediente2(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<CEntidad> logRegistroTalleres(CEntidad oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.datRegistroTalleres(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CEntidad> logProduccionEspecialista(CEntidad oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.datProduccionXEspecialistas(cn, oCEntidad);
                }
            }


            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
