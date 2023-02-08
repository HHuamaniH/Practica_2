using System;
using System.Collections.Generic;
//using System.Data.SqlClient;
using CDatos = CapaDatos.DOC.Dat_Reporte_SEGUIMIENTO_INFORMES;
using CEntidad = CapaEntidad.DOC.Ent_Reporte_SEGUIMIENTO_INFORMES;
using Oracle.ManagedDataAccess.Client;
namespace CapaLogica.DOC
{
    /// <summary>
    /// 
    /// </summary>
    public class Log_Reporte_SEGUIMIENTO_INFORMES
    {
        private CDatos oCDatos = new CDatos();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public List<CEntidad> RegMostrarLista(CEntidad oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
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
    }
}
