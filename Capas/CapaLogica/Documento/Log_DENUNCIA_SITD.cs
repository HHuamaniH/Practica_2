using CapaEntidad.ViewModel;
using CapaEntidad.ViewModel.DOC;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using CDatos = CapaDatos.DOC.Dat_DENUNCIA_SITD;
using CEntidad = CapaEntidad.DOC.Ent_DENUNCIA_SITD;

namespace CapaLogica.DOC
{
    public class Log_DENUNCIA_SITD
    {
        private CDatos oCDatos = new CDatos();

        public List<CEntidad> RegMostrarGeneral(CEntidad oCEntidad)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
                {
                    cn.Open();
                    return oCDatos.RegMostrarGeneral(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void RegEliminarDetalle(CEntidad oCampoEntrada)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
                {
                    cn.Open();
                    oCDatos.RegEliminarDetalle(cn, oCampoEntrada);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #region "Sigo v3"
        public void RegEliminar(CEntidad oCampoEntrada)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
                {
                    cn.Open();
                    oCDatos.RegEliminar(cn, oCampoEntrada);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ListResult AnularDenuncia(VM_SOLINF_THABILITANTE vm, string codCuenta)
        {
            ListResult result = new ListResult();
            try
            {
                CEntidad entidad = new CEntidad();
                entidad.EliTABLA = "Tra_M_Tramite";
                entidad.COD_TRAMITE_SITD = vm.cod_Tramite_Id;
                entidad.OBSERVACION_TRANSFERENCIA = vm.obs;
                entidad.COD_UCUENTA = codCuenta;
                this.RegEliminar(entidad);
                result.success = true;
                result.msj = "El Registro se anulo Correctamente";
            }
            catch (Exception)
            {
                result.success = false;
                result.msj = "";
            }
            return result;
        }
        public VM_DENUNCIA_SITD RegMostrarListaItems_V3(int tramiteId)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
                {
                    cn.Open();
                    return oCDatos.RegMostrarListaItems_V3(cn, tramiteId);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        public CEntidad RegMostrarListaItems(CEntidad oCEntidad)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
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

        public List<CEntidad> RegBuscarDenuncia(CEntidad oCEntidad)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
                {
                    cn.Open();
                    return oCDatos.RegBuscarDenuncia(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CEntidad> ReporteGestionDenuncias_Resumen(CEntidad oCEntidad)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
                {
                    cn.Open();
                    return oCDatos.ReporteGestionDenuncias_Resumen(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CEntidad> ReporteGestionDenuncias_DetalleDenunciaSITD(CEntidad oCEntidad)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
                {
                    cn.Open();
                    return oCDatos.ReporteGestionDenuncias_DetalleDenunciaSITD(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CEntidad> ReporteGestionDenuncias_DetalleDenunciaOSF(CEntidad oCEntidad)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
                {
                    cn.Open();
                    return oCDatos.ReporteGestionDenuncias_DetalleDenunciaOSF(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
