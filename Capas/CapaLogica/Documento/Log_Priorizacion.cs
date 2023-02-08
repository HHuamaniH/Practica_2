using CapaEntidad.DOC;
using System;
using System.Collections.Generic;
//using System.Data.SqlClient;
using Oracle.ManagedDataAccess.Client;
using CDatos = CapaDatos.DOC.Dat_Priorizacion;
using CEntidad = CapaEntidad.DOC.Ent_Priorizacion;
using CEntidad2 = CapaEntidad.DOC.Ent_Priorizacion_Detalle;
using CEntidad3 = CapaEntidad.DOC.Ent_Criterio_Focalizacion;

namespace CapaLogica.DOC
{
    public class Log_Priorizacion
    {
        private CDatos oCDatos = new CDatos();

        public List<Ent_Plan_Manejo_Supervisado> GetListPlanManejoSupervisado(string cod_od, string periodo)
        {
            Ent_Plan_Manejo_Supervisado oCEntidad = new Ent_Plan_Manejo_Supervisado();
            oCEntidad.COD_OD = cod_od;
            oCEntidad.PERIODO = periodo;
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.GetListPlanManejoSupervisado(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CEntidad3> GetListCriterios()
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.GetListCriterios(cn);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CEntidad2> ReportePriorizacion(string cod_od, string periodo)
        {
            CEntidad oCEntidad = new CEntidad();
            oCEntidad.COD_OD = cod_od;
            oCEntidad.PERIODO = periodo;

            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.DatosReportePriorizacion(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Boolean SeleccionarCriterios(List<Ent_Priorizacion_Detalle> listaPriorizacion, Ent_Priorizacion ent)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.SeleccionarCriterios(cn, listaPriorizacion, ent);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
