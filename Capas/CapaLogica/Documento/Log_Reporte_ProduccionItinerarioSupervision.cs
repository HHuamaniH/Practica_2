using System;
using System.Collections.Generic;
//using System.Data.SqlClient;
using CDatos = CapaDatos.DOC.Dat_Reporte_ProduccionItinerarioSupervision;
using CEntidad = CapaEntidad.DOC.Ent_Reporte_ProduccionItinerarioSupervision;
using Oracle.ManagedDataAccess.Client;
namespace CapaLogica.DOC
{
    public class Log_Reporte_ProduccionItinerarioSupervision
    {
        private CDatos oCDatos = new CDatos();

        public List<CEntidad> MostReporteResumen(CEntidad oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.MostReporteResumen(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CEntidad> MostReporteDetalle(CEntidad oCEntidad)
        {
            //try
            //{
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.MostReporteDetalle(cn, oCEntidad);
                }
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
        }
    }
}
