using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using CDatos = CapaDatos.DOC.Dat_Actividad;
using CEntidad = CapaEntidad.DOC.Ent_Actividad;

namespace CapaLogica.DOC
{

    public class Log_Actividades
    {
        private CDatos oCDatos = new CDatos();

        public List<CEntidad> RegListarPrioridad(CEntidad oCEntidad)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
                {
                    cn.Open();
                    return oCDatos.RegListarPrioridad(cn, oCEntidad);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<CEntidad> RegListarOficina(CEntidad oCEntidad)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
                {
                    cn.Open();
                    return oCDatos.RegListarOficina(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<CEntidad> RegListarEstado(CEntidad oCEntidad)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
                {
                    cn.Open();
                    return oCDatos.RegListarEstado(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //metodo para devolver la lista de personas 
        public List<CEntidad> RegBuscarPersonas(CEntidad oCEntidad)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
                {
                    cn.Open();
                    return oCDatos.RegBuscarPersonas(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public CEntidad RegPopupBuscarPersonas(CEntidad oCEntidad)
        //{
        //    try
        //    {
        //        using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
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

        public String RegGrabar(CEntidad oCampoEntrada)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
                {
                    cn.Open();
                    return oCDatos.RegGrabar(cn, oCampoEntrada);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public String RegGrabarOCI(CEntidad oCampoEntrada)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
                {
                    cn.Open();
                    return oCDatos.RegGrabarOCI(cn, oCampoEntrada);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public String RegGrabarOFI(CEntidad oCampoEntrada)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
                {
                    cn.Open();
                    return oCDatos.RegGrabarOFI(cn, oCampoEntrada);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CEntidad RegMostrarActv(CEntidad oCampoEntrada)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
                {
                    cn.Open();
                    return oCDatos.RegMostrarActv(cn, oCampoEntrada);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public CEntidad RegMostrarActvOCI(CEntidad oCampoEntrada)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
                {
                    cn.Open();
                    return oCDatos.RegMostrarActvOCI(cn, oCampoEntrada);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CEntidad RegMostrarActvOFI(CEntidad oCampoEntrada)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
                {
                    cn.Open();
                    return oCDatos.RegMostrarActvOFI(cn, oCampoEntrada);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// metodo para listar lasactividades por usuario segun el login
        /// </summary>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public List<CEntidad> RegListActv(CEntidad oCEntidad)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
                {
                    cn.Open();
                    return oCDatos.RegListActv(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public String RegGrabarAvance(CEntidad oCampoEntrada)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
                {
                    cn.Open();
                    return oCDatos.RegGrabarAvance(cn, oCampoEntrada);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CEntidad> RegListarActiv_Estado(CEntidad oCEntidad)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
                {
                    cn.Open();
                    return oCDatos.RegListarActiv_Estado(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CEntidad> RegListarActiv_EstadoDesc(CEntidad oCEntidad)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
                {
                    cn.Open();
                    return oCDatos.RegListarActiv_EstadoDesc(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CEntidad> RegListarActivTotalXAnio(CEntidad oCEntidad)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
                {
                    cn.Open();
                    return oCDatos.RegListarActivTotalXAnio(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CEntidad> RegListarActivTotalXTriemestre(CEntidad oCEntidad)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
                {
                    cn.Open();
                    return oCDatos.RegListarActivTotalXTrimestre(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CEntidad> RegListarActivTotalXOficinas(CEntidad oCEntidad)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
                {
                    cn.Open();
                    return oCDatos.RegListarActivTotalXOficinas(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CEntidad> RLisBusqAvan(CEntidad oCEntidad)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
                {
                    cn.Open();
                    return oCDatos.RLisBusqAvan(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public String RActvEliminar(CEntidad oCEntidad)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
                {
                    cn.Open();
                    return oCDatos.RegACTEliminar(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CEntidad> LogActividad_Detalla(CEntidad oCEntidad)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
                {
                    cn.Open();
                    return oCDatos.RegListarActivAvanceDetalle(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CEntidad> LogListarReferencias(CEntidad oCEntidad)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
                {
                    cn.Open();
                    return oCDatos.RegListarReferencia(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CEntidad> LogListarActividadXReferencias(CEntidad oCEntidad)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
                {
                    cn.Open();
                    return oCDatos.RegListActvXReferencia(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// 25/09/2017 cambioa nueva plataforma
        /// 
        public List<CEntidad> Log_ListarActividades(CEntidad oCEntidad)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
                {
                    cn.Open();
                    return oCDatos.dat_ListActividades(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<CEntidad> RegListSubActv(CEntidad oCEntidad)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
                {
                    cn.Open();
                    return oCDatos.RegListSubActv(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CEntidad> RegListSubActvRep(CEntidad oCEntidad)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
                {
                    cn.Open();
                    return oCDatos.RegListSubActvRep(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CEntidad> RegListarActiv_EstadoSUB(CEntidad oCEntidad)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
                {
                    cn.Open();
                    return oCDatos.RegListarActiv_EstadoSUB(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CEntidad> RegListarActiv_EstadoDescSUB(CEntidad oCEntidad)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
                {
                    cn.Open();
                    return oCDatos.RegListarActiv_EstadoDescSUB(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CEntidad> LogActividad_DetallaSUB(CEntidad oCEntidad)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
                {
                    cn.Open();
                    return oCDatos.RegListarActivAvanceDetalleSUB(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
