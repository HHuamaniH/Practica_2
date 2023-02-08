using CapaEntidad.DOC;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
//using System.Data.SqlClient;
using CDatos = CapaDatos.DOC.Dat_IMEDIDA;
using CEntidad = CapaEntidad.DOC.Ent_IMEDIDA;

namespace CapaLogica.DOC
{
    public class Log_IMEDIDA
    {
        private CDatos oCDatos = new CDatos();

        public CEntidad RegMostrarListaItems(CEntidad oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegMostrarListaItems(cn, oCEntidad);
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
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
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

        public CEntidad RegMostCombo(CEntidad oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegMostCombo(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Ent_IMEDIDA_EXPEDIENTE> RegListExpediente(CEntidad oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegListExpediente(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Ent_IMEDIDA_EXP_MEDIDA> RegListMedida(Ent_IMEDIDA_EXP_MEDIDA oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegListMedida(cn, oCEntidad);
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
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public List<Dictionary<string, string>> ReporteInformeMedidaCorrectiva(CEntidad oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.ReporteInformeMedidaCorrectiva(cn, oCEntidad);
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
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public CEntidad RegMostrarExpediente_BuscarDatos(CEntidad oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegMostrarExpediente_BuscarDatos(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public List<CEntidad> ReporteSeguimientoMCorrectiva(CEntidad oCEntidad)
        //{
        //    try
        //    {
        //        using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
        //        {
        //            cn.Open();
        //            return oCDatos.ReporteSeguimientoMCorrectiva(cn, oCEntidad);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

    }
}