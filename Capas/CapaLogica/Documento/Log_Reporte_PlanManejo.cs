using System;
using System.Collections.Generic;
//using System.Data.SqlClient;
using CDatos = CapaDatos.DOC.Dat_Reporte_PlanManejo;
using CEntidad = CapaEntidad.DOC.Ent_Reporte_PlanManejo;
using Oracle.ManagedDataAccess.Client;

namespace CapaLogica.DOC
{
    public class Log_Reporte_PlanManejo
    {
        private CDatos oCDatos = new CDatos();

        public List<CEntidad> MostrarPlanesManejoXpersona_Resumen(CEntidad oCEntidad)
        {
            try
            {
                oCEntidad.TIPO_REPORTE = "RESUMEN";

                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.MostrarPlanesManejoXpersona_Resumen(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<CEntidad> MostrarPlanesManejoXpersona_Detalle(CEntidad oCEntidad)
        {
            try
            {
                oCEntidad.TIPO_REPORTE = "DETALLE";

                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.MostrarPlanesManejoXpersona_Detalle(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
