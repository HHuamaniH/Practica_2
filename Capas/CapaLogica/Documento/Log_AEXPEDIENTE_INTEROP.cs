using System;
using System.Data.SqlClient;
using CDatos = CapaDatos.DOC.Dat_AEXPEDIENTE_INTEROP;
using CEntidad = CapaEntidad.DOC.Ent_AEXPEDIENTE_INTEROP;

namespace CapaLogica.DOC
{
    public class Log_AEXPEDIENTE_INTEROP
    {
        private CDatos oCDatos = new CDatos();

        public CEntidad VerificarEstadoAExpedienteInterop(CEntidad oCEntidad)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
                {
                    cn.Open();
                    return oCDatos.VerificarEstadoAExpedienteInterop(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

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
    }
}
