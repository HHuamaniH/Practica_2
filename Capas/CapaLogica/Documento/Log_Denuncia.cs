using CapaEntidad.DOC;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
//using System.Data.SqlClient;
using CDatos = CapaDatos.DOC.Dat_Denuncia;
using Tra_M_Tramite = CapaEntidad.DOC.Tra_M_Tramite;

namespace CapaLogica.DOC
{
    public class Log_Denuncia
    {
        private CDatos oCDatos = new CDatos();
        public Tra_M_Tramite ConsultarTramite(IDENUNCIA tramite)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.ConsultarTramite(cn, tramite);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Tra_M_Tramite ConsultarTramite2(IDENUNCIA tramite)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.ConsultarTramite2(cn, tramite.tra_M_Tramite);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IDENUNCIA InsertarDenunciaCabecera(IDENUNCIA tramite, string CodUsuario)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.InsertarDenunciaCabecera(cn, tramite, CodUsuario);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IDENUNCIA obtenerDenuncias(IDENUNCIA tramite)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.obtenerDenuncias(cn, tramite);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IDENUNCIA obtenerPoaPorInformeSupervision(IDENUNCIA tramite)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.obtenerPoaPorInformeSupervision(cn, tramite);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<IINCIDENCIA> crudIncidencias(IINCIDENCIA tramite)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.crudIncidencias(cn, tramite);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Ent_INFORME> ConsultarInforme(Ent_INFORME informe)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.ConsultarInforme(cn, informe);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<IDENUNCIA_THABILITANTE> ConsultarTHabilitante(IDENUNCIA_THABILITANTE informe)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.ConsultarTHabilitante(cn, informe);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<IDENUNCIA> exportarDenuncias()
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.exportarDenuncias(cn);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Dictionary<string, string>> exportarDenunciasGrl()
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.exportarDenunciasGrl(cn);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IDENUNCIA insertarTramiteDenuncia(IDENUNCIA denuncia)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.insertarTramiteDenuncia(cn, denuncia);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IDENUNCIA obtenerDenunciaxInforme(IDENUNCIA denuncia)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.obtenerDenunciaxInforme(cn, denuncia);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<IINCIDENCIA_PROTOCOLOS> listarProtocolos(IINCIDENCIA_PROTOCOLOS denuncia)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.listarProtocolos(cn, denuncia);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //public Tra_M_Tramite ConsultarTramiteMandatos(Tra_M_Tramite tramite)
        //{
        //    try
        //    {
        //        using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
        //        {
        //            cn.Open();
        //            return oCDatos.ConsultarTramiteMandatos(cn, tramite);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public Tra_M_Tramite guardarTramite(Tra_M_Tramite tramite)
        //{
        //    try
        //    {
        //        using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
        //        {
        //            cn.Open();
        //            return oCDatos.guardarTramite(cn, tramite);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public Tra_M_Tramite cambioEtadoTramite(Tra_M_Tramite tramite)
        //{
        //    try
        //    {
        //        using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
        //        {
        //            cn.Open();
        //            return oCDatos.cambioEtadoTramite(cn, tramite);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public List<IINCIDENCIA> consultaGenerica()
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.consultaGenerica(cn);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //public VW_REPORTE_INFORME_SUPERVISION InformeDeSupervision()
        //{
        //    try
        //    {
        //        using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
        //        {
        //            cn.Open();
        //            return oCDatos.InformeDeSupervision(cn);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
    }

}
