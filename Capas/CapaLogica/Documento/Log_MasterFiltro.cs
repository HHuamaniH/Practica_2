using Oracle.ManagedDataAccess.Client;
using System;
//using System.Data.SqlClient;
using CDatos = CapaDatos.DOC.Dat_MasterFiltro;
using CEntidad = CapaEntidad.DOC.Ent_MasterFiltro;

namespace CapaLogica.DOC
{
    public class Log_MasterFiltro
    {
        private CDatos oCDatos = new CDatos();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public CEntidad RegMostFiltro(CEntidad oCEntidad)
        {
            oCEntidad.BusFormulario = "GENERAL_FILTRO";
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegMostFiltro(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
