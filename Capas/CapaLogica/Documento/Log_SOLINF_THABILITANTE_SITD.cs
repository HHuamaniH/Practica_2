using CapaEntidad.ViewModel;
using CapaEntidad.ViewModel.DOC;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using CDatos = CapaDatos.DOC.Dat_SOLINF_THABILITANTE_SITD;
using CEntidad = CapaEntidad.DOC.Ent_SOLINF_THABILITANTE_SITD;

namespace CapaLogica.DOC
{
    public class Log_SOLINF_THABILITANTE_SITD
    {
        private CDatos oCDatos = new CDatos();

        //public List<CEntidad> RegMostrarGeneral(CEntidad oCEntidad)
        //{
        //    try
        //    {
        //        using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
        //        {
        //            cn.Open();
        //            return oCDatos.RegMostrarGeneral(cn, oCEntidad);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

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
        #region "Sigo v3"
        private String RegGrabar_Cabecera(CEntidad oCampoEntrada)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
                {
                    cn.Open();
                    return oCDatos.RegGrabar_Cabecera(cn, oCampoEntrada);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private String RegGrabar_Detalle(CEntidad oCampoEntrada)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
                {
                    cn.Open();
                    return oCDatos.RegGrabar_Detalle(cn, oCampoEntrada);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private String Eliminar_Detalle(CEntidad oCampoEntrada)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
                {
                    cn.Open();
                    return oCDatos.Eliminarv3(cn, oCampoEntrada);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private String AnularSolicitud(CEntidad oCampoEntrada)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
                {
                    cn.Open();
                    return oCDatos.AnularSolicitud(cn, oCampoEntrada);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public VM_SOLINF_THABILITANTE IniciarTransferencia(int tramiteId)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
                {
                    cn.Open();
                    return oCDatos.RegMostrarListaItems_Cabecera(cn, tramiteId, 1);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<Dictionary<string, string>> RegMostrarListaItems_Detalle(int tramiteId)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
                {
                    cn.Open();
                    return oCDatos.RegMostrarListaItems_Detalle(cn, tramiteId, 2);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public ListResult RegGrabar_Transferenia_Cabecera(string tramideId, string obsTransferencia, string cod_cuenta)
        {
            ListResult result = new ListResult();
            try
            {
                CEntidad entidad = new CEntidad();
                entidad.COD_TRAMITE_SITD = Convert.ToInt32(tramideId);
                entidad.OBSERVACION_TRANSFERENCIA = obsTransferencia;
                entidad.OUTPUTPARAM01 = "";
                entidad.COD_UCUENTA = cod_cuenta;
                this.RegGrabar_Cabecera(entidad);
                result.success = true;
                result.msj = "El Registro se Guardo Correctamente";
            }
            catch (Exception ex)
            {
                result.success = false;
                result.msj = "";
            }
            return result;
        }
        public ListResult RegGrabar_Transferencia_Detalle(VM_SOLINF_THABILITANTE_DETALLE vm, string codCuenta)
        {
            ListResult result = new ListResult();
            try
            {
                CEntidad entidad = new CEntidad();
                entidad.ListTHabilitante = new List<CEntidad>();
                entidad.ListTHabilitante.Add(new CEntidad()
                {
                    COD_TRAMITE_SITD = vm.cod_Tramite_Id,
                    COD_SECUENCIAL = vm.cod_secuencial,
                    COD_THABILITANTE = vm.cod_TH,
                    NUM_THABILITANTE = vm.num_TH,
                    NUM_POA = vm.num_poa,
                    NOMBRE_POA = vm.nombre_poa,
                    RESOLUCION_POA = vm.res_poa,
                    ESTADO_SUPERVISION = vm.estado_supervision,
                    OBSERVACION = vm.obs,
                    COD_UCUENTA = codCuenta,
                    RegEstado = vm.estado  //cuando viene 1 es nuevo, 2 es modificar

                }
                );
                this.RegGrabar_Detalle(entidad);
                result.success = true;
                result.msj = "El Registro se Guardo Correctamente";
            }
            catch (Exception ex)
            {
                result.success = false;
                result.msj = "";
            }
            return result;
        }
        public ListResult Eliminar_Transferencia_Detalle(List<VM_SOLINF_THABILITANTE_DETALLE> lstVm, string codCuenta)
        {
            ListResult result = new ListResult();
            try
            {
                CEntidad entidad = new CEntidad();
                entidad.ListEliTABLA = new List<CEntidad>();
                if (lstVm != null)
                {
                    foreach (var item in lstVm)
                    {
                        entidad.ListEliTABLA.Add(new CEntidad()
                        {
                            COD_TRAMITE_SITD = item.cod_Tramite_Id,
                            EliVALOR02 = item.cod_secuencial,
                            EliVALOR01 = "",
                            EliTABLA = "SOLINF_THABILITANTE_SITD",
                            COD_UCUENTA = codCuenta
                        }
                );
                    }
                }

                this.Eliminar_Detalle(entidad);
                result.success = true;
                result.msj = "El Registro se elimino Correctamente";
            }
            catch (Exception ex)
            {
                result.success = false;
                result.msj = "";
            }
            return result;
        }
        public ListResult AnularSolicitud(VM_SOLINF_THABILITANTE vm, string codCuenta)
        {
            ListResult result = new ListResult();
            try
            {
                CEntidad entidad = new CEntidad();
                entidad.EliTABLA = "Tra_M_Tramite";
                entidad.COD_TRAMITE_SITD = vm.cod_Tramite_Id;
                entidad.OBSERVACION_TRANSFERENCIA = vm.obs;
                entidad.COD_UCUENTA = codCuenta;
                this.AnularSolicitud(entidad);
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
        #endregion

        public List<CEntidad> ReporteSolicitudInformacionTH_Resumen(CEntidad oCEntidad)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
                {
                    cn.Open();
                    return oCDatos.ReporteSolicitudInformacionTH_Resumen(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CEntidad> ReporteSolicitudInformacionTH_Detalle(CEntidad oCEntidad)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
                {
                    cn.Open();
                    return oCDatos.ReporteSolicitudInformacionTH_Detalle(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CEntidad> ReportePMPlanificacionSupervisiones(CEntidad oCEntidad)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
                {
                    cn.Open();
                    return oCDatos.ReportePMPlanificacionSupervisiones(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
