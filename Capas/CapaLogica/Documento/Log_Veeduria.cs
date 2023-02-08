using CapaDatos;
using CapaEntidad.DOC;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDatos = CapaDatos.DOC.Dat_Veeduria;
using CEntidad = CapaEntidad.DOC.Ent_Veeduria;

namespace CapaLogica.DOC
{
    public class Log_Veeduria
    {
        private CDatos oCDatos = new CDatos();

        public CEntidad ListarTipo(CEntidad oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.ListarTipo(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public List<Dictionary<string, string>> ListarEquipo(CEntidad oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.ListarEquipo(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public CEntidad MostrarEquipo(CEntidad oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.MostrarEquipo(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CEntidad MostrarOrganizacion(CEntidad oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.MostrarOrganizacion(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CEntidad MostrarIntegrante(CEntidad oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.MostrarIntegrante(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CEntidad MostrarUsuario(CEntidad oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.MostrarUsuario(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public String CambiarEstado(CEntidad oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.CambiarEstado(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Dictionary<string, string>> ListarRptHallazgo(CEntidad oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.ListarRptHallazgo(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public CEntidad MostrarHallazgo(CEntidad oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.MostrarHallazgo(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CEntidad ListarDetHallazgo(CEntidad oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.ListarDetHallazgo(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public CEntidad ListarTHabilitante(CEntidad oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.ListarTHabilitante(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public CEntidad ListarArchivo(CEntidad oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.ListarArchivo(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public String Inicia_ProcesarHallazgo(CEntidad oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.Inicia_ProcesarHallazgo(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public String GrabarHallazgo(CEntidad oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.GrabarHallazgo(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CEntidad ListarEnviado(CEntidad oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.ListarEnviado(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public CEntidad ListarCorreo(CEntidad oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.ListarCorreo(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public String GrabarEnviado(CEntidad oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.GrabarEnviado(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}