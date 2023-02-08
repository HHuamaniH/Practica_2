using Oracle.ManagedDataAccess.Client;
using System;
using System.Data.SqlClient;
using CDatos = CapaDatos.DOC.Dat_Reunion;
using CEntidad = CapaEntidad.DOC.Ent_Reunion;

namespace CapaLogica.DOC
{
    public class Log_Reunion
    {
        private CDatos oCDatos = new CDatos();

        public CEntidad RegMostrarListaItems(CEntidad oCEntidad)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
                {
                    cn.Open();
                    return oCDatos.RegMostrarReunion(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //public CEntidad RegMostrarCombos(CEntidad oCEntidad)
        //{
        //    try
        //    {
        //        using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena()))
        //        {
        //            cn.Open();
        //            return oCDatos.RegMostrarCombos(cn, oCEntidad);
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
    }
}
