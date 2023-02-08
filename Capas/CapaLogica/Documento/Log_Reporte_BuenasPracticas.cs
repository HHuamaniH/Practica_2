using System;
using System.Collections.Generic;
//using System.Data.SqlClient;
using CDatos = CapaDatos.DOC.Dat_Reporte_BuenasPracticas;
using CEntidad = CapaEntidad.DOC.Ent_Reporte_BuenasPracticas;
using Oracle.ManagedDataAccess.Client;
namespace CapaLogica.DOC
{
    /// <summary>
    /// 
    /// </summary>
    public class Log_Reporte_BuenasPracticas
    {
        private CDatos oCDatos = new CDatos();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="oCampoEntrada"></param>
        /// <returns></returns>
        public CEntidad Log_MostrarBuenasPracticasGeneral(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.Dat_ArchivoBuenaPracticaGeneral(cn, oCampoEntrada);
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
        public List<CEntidad> Log_MostrarBuenasPracticaDetalle(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.Dat_ArchivoBuenaPracticaDetalle(cn, oCampoEntrada);
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
        public CEntidad Log_MostrarBuenasPracticasGeneralFauna(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.Dat_ArchivoBuenaPracticaGeneralFauna(cn, oCampoEntrada);
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
        public List<CEntidad> Log_MostrarBuenasPracticaDetalleFauna(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.Dat_ArchivoBuenaPracticaDetalleFauna(cn, oCampoEntrada);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
