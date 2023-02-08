using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using CDatos = CapaDatos.DOC.Dat_SOLINT;
using CEntidad = CapaEntidad.DOC.Ent_SOLINT;

namespace CapaLogica.DOC
{
    /// <summary>
    /// 
    /// </summary>
    public class Log_SOLINT
    {
        private CDatos oCDatos = new CDatos();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="oCampoEntrada"></param>
        /// <returns></returns>
        public List<CEntidad> RegMostrarSolInt_Buscar(CEntidad oCampoEntrada)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
                {
                    cn.Open();
                    return oCDatos.RegMostrarSOLINT_Buscar(cn, oCampoEntrada);
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
        /// <returns></returns>
        public CEntidad RegMostCombo(CEntidad oCampoEntrada)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
                {
                    cn.Open();
                    return oCDatos.RegMostCombo(cn, oCampoEntrada);
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
        public String RegSolictudInfInterna_Grabar(CEntidad oCampoEntrada)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
                {
                    cn.Open();
                    return oCDatos.RegGrabaSolicitudInterna(cn, oCampoEntrada);
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
        public CEntidad RegMostrarListaSolIntItem(CEntidad oCampoEntrada)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
                {
                    cn.Open();
                    return oCDatos.RegMostrarListaSolIntItem(cn, oCampoEntrada);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
