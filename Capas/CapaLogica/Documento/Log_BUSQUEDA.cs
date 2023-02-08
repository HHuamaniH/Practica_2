using CapaDatos.DOC;
using CapaEntidad.General;
using CapaEntidad.ViewModel;
using CapaEntidad.ViewModel.General;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using CDatos = CapaDatos.DOC.Dat_BUSQUEDA;
using CEntidad = CapaEntidad.DOC.Ent_BUSQUEDA;

namespace CapaLogica.DOC
{
    /// <summary>
    /// 
    /// </summary>
    public class Log_BUSQUEDA
    {
        private CDatos oCDatos = new CDatos();
        CEntidad CEntBusqueda = new CEntidad();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public List<CEntidad> RegMostrarLista(CEntidad oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegMostrarLista(cn, oCEntidad);
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
        public List<CEntidad> mostrarRegistrosUsuario(CEntidad oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.mostrarRegistrosUsuario(cn, oCEntidad);
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
        public CEntidad RegMostCombo(CEntidad oCEntidad)
        {
            oCEntidad.BusFormulario = "GENERAL";
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
        public List<CEntidad> RegOpcionesCombo(CEntidad oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegOpcionesCombo(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public CEntidad RegListasValidacion(CEntidad oCEntidad)
        {
            oCEntidad.BusFormulario = "VALIDACION";
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegListasValidacion(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// metodo para obtener el permiso del usuario
        /// </summary>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public Boolean permisoUsu(CEntidad oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.permisoUsu(cn, oCEntidad);
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
        public List<CEntidad> regllenarEspecies(CEntidad oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.regllenarEspecies(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// metodo para listar parentesco
        /// </summary>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public List<CEntidad> logListParentesco(CEntidad oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.ListParentesco(cn, oCEntidad);
                    //return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Para registrar el IP desde donde se realiza la acción
        /// </summary>
        /// <param name="direccionIP"></param>
        /// <param name="hostName"></param>
        /// <param name="ipBehindProxy"></param>
        /// <param name="camposAfectados"></param>
        /// <param name="tipoAccion"></param>
        /// <param name="codUcuenta"></param>
        /// <param name="codReferencia"></param>
        /// <param name="codReferenciaAux"></param>
        public void logRegistroAccion(String codFormulario, String direccionIP, String hostName, String ipBehindProxy, String camposAfectados, String tipoAccion, String codUcuenta, String codReferencia = null, String codReferenciaAux = null)
        {
            try
            {
                CEntBusqueda = new CEntidad();
                CEntBusqueda.COD_FORMULARIO = codFormulario;
                CEntBusqueda.DIRECCION_IP = direccionIP;
                CEntBusqueda.CAMPOS_AFECTADOS = "HOSTNAME=" + hostName + "; IP_BEHIND_PROXY=" + ipBehindProxy + "; " + camposAfectados;
                CEntBusqueda.ACCION = tipoAccion;
                CEntBusqueda.COD_UCUENTA = codUcuenta;
                CEntBusqueda.COD_REFERENCIA = codReferencia;
                CEntBusqueda.COD_REFERENCIA_AUX = codReferenciaAux;
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    oCDatos.regTrackSIGO(cn, CEntBusqueda);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*########################## SIGOsfc v3 ##############################*/
        #region SIGOsfc v3
        public List<Dictionary<string, string>> CartaNotificacionGetAll(string criterio, string valorBusqueda, int currentPage, int pageSize, string sort, ref int rowCount)
        {
            return oCDatos.CartaNotificacionGetAll(criterio, valorBusqueda, currentPage, pageSize, sort, ref rowCount);
        }
        public List<Dictionary<string, string>> InformeSupervisionGetAll(string criterio, string valorBusqueda, int currentPage, int pageSize, string sort, ref int rowCount)
        {
            return oCDatos.InformeSupervisionGetAll(criterio, valorBusqueda, currentPage, pageSize, sort, ref rowCount);
        }
        public List<Dictionary<string, string>> PAUGetAll(string criterio, string valorBusqueda, int currentPage, int pageSize, string sort, ref int rowCount)
        {
            return oCDatos.PAUGetAll(criterio, valorBusqueda, currentPage, pageSize, sort, ref rowCount);
        }
        public List<Dictionary<string, string>> MuestrasDendrologicasGetAll(string criterio, string valorBusqueda, int currentPage, int pageSize, string sort, ref int rowCount)
        {
            return oCDatos.MuestrasDendrologicasGetAll(criterio, valorBusqueda, currentPage, pageSize, sort, ref rowCount);
        }
        public List<Dictionary<string, string>> InformeQuinquenalGetAll(string criterio, string valorBusqueda, int currentPage, int pageSize, string sort, ref int rowCount)
        {
            return oCDatos.InformeQuinquenalGetAll(criterio, valorBusqueda, currentPage, pageSize, sort, ref rowCount);
        }
        public List<VM_Reporte> InformeQuinquenalReporte(string criterio, string valorBusqueda, int currentPage, int pageSize, string sort, ref int rowCount)
        {
            return oCDatos.InformeQuinquenalReporte(criterio, valorBusqueda, currentPage, pageSize, sort, ref rowCount);
        }
        public List<Dictionary<string, string>> RegMostrarListaPaging(CEntidad oCEntidad, ref int rowcount)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegMostrarListaPaging(cn, oCEntidad, ref rowcount);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Dictionary<string, string>> RegMostrarTHCalificacion(CEntidad oCEntidad, ref int rowcount)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_OBSERVATORIO()))
                {
                    cn.Open();
                    return oCDatos.RegMostrarTHCalificacion(cn, oCEntidad, ref rowcount);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// metodo que consume de la bd de oracle CR
        /// </summary>
        /// <param name="oCEntidad"></param>
        /// <param name="rowcount"></param>
        /// <returns></returns>
        public List<Dictionary<string, string>> RegMostrarListaPaging_v3(CEntidad oCEntidad, ref int rowcount)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegMostrarListaPaging_v3(cn, oCEntidad, ref rowcount);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Select2PagedResult GetListComboPaging(string busFormulario, string busCriterio, string busValor, int pagesize, int currentpage)
        {

            Ent_BUSQUEDA_V3 paramsBus = new Ent_BUSQUEDA_V3();
            Dat_BUSQUEDA dat = new Dat_BUSQUEDA();
            paramsBus.BusFormulario = busFormulario;
            paramsBus.BusCriterio = busCriterio;
            paramsBus.BusValor = busValor;
            paramsBus.pagesize = pagesize;
            paramsBus.currentpage = currentpage;
            return dat.GetListComboPaging(paramsBus);
        }
        public List<Dictionary<string, string>> ListarDocumentosSITD_Paging(CEntidad oCEntidad, ref int rowcount)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(CapaDatos.BDConexion.Conexion_Cadena_SITD()))
                {
                    cn.Open();
                    return oCDatos.ListarDocumentosSITD_Paging(cn, oCEntidad, ref rowcount);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<VM_Cbo> RegMostComboIndividual(string asBusCriterio, string asBusValor)
        {
            List<VM_Cbo> lstResult = new List<VM_Cbo>();

            try
            {
                CEntidad entBus = new CEntidad();
                Log_BUSQUEDA logBus = new Log_BUSQUEDA();
                entBus.BusFormulario = "COMBO_INDIVIDUAL";
                entBus.BusCriterio = asBusCriterio;
                entBus.BusValor = asBusValor;

                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    lstResult = oCDatos.RegMostComboIndividual(cn, entBus).Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION }).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return lstResult;
        }
        public Select2PagedResult RegMostComboIndividualPaging(string busFormulario, string busCriterio, string busValor, int pagesize, int currentpage, int criterio1 = 0)
        {

            Ent_BUSQUEDA_V3 paramsBus = new Ent_BUSQUEDA_V3();
            Dat_BUSQUEDA dat = new Dat_BUSQUEDA();
            paramsBus.BusFormulario = busFormulario;
            paramsBus.BusCriterio = busCriterio;
            paramsBus.BusValor = busValor;
            paramsBus.pagesize = pagesize;
            paramsBus.currentpage = currentpage;
            paramsBus.param03 = criterio1;
            return dat.RegMostComboIndividualPaging(paramsBus);
        }

        public List<VM_Cbo> RegMostComboIndividualV3(string busFormulario, string busCriterio, string busValor, bool addSeleccionar = false)
        {
            List<VM_Cbo> lstResult = new List<VM_Cbo>();

            try
            {
                CEntidad entBus = new CEntidad();
                Log_BUSQUEDA logBus = new Log_BUSQUEDA();
                entBus.BusFormulario = busFormulario;
                entBus.BusCriterio = busCriterio;
                entBus.BusValor = busValor;

                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    lstResult = oCDatos.RegMostComboIndividualV3(cn, entBus, addSeleccionar);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return lstResult;
        }
        public VM_ValidacionFormatos RegListasValidacionV3()
        {
            CEntidad oCEntidad = new CEntidad();
            oCEntidad.BusFormulario = "VALIDACION_V3";
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegListasValidacionV3(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region "Control de calidad"
        public VM_ControlCalidad obtenerObservacionControlCalidadV3(string busFormulario, string busValor)
        {
            CEntidad oCampoEntrada = new CEntidad();
            oCampoEntrada.BusFormulario = busFormulario;
            oCampoEntrada.BusCriterio = "";
            oCampoEntrada.BusValor = busValor;
            return oCDatos.obtenerObservacionControlCalidadV3(oCampoEntrada);
        }
        public VM_ControlCalidad_2 obtenerControlCalidadV3(string busFormulario, string busValor, string codCuenta)
        {
            CEntidad eBusqueda = new CEntidad();
            //datos combo
            eBusqueda.BusFormulario = "PASPEQ_PLAN_COMBO";
            eBusqueda.COD_UCUENTA = codCuenta;
            var lstCombo = oCDatos.RegMostComboIndividual(eBusqueda);
            List<VM_Cbo> listIndicador = lstCombo.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION }).ToList();
            //datos calidad
            eBusqueda = new CEntidad();
            eBusqueda.BusFormulario = busFormulario;
            eBusqueda.BusCriterio = "";
            eBusqueda.BusValor = busValor;
            var datosCalidad = oCDatos.obtenerControlCalidadV3(eBusqueda);
            bool enableIndicador = true;
            string itemSelectIndicador = datosCalidad.COD_ESTADO_DOC;
            Log_Helper.controla_estado_calidad(datosCalidad.COD_ESTADO_DOC, ref listIndicador, ref enableIndicador, ref itemSelectIndicador);
            datosCalidad.ddlIndicador = listIndicador;
            datosCalidad.ddlIndicadorId = itemSelectIndicador;
            datosCalidad.ddlIndicadorEnable = enableIndicador;

            return datosCalidad;
        }
        #endregion


        #region Oracle
        public List<VM_Cbo> RegMostComboIndividual_v3(string asBusCriterio, string asBusValor)
        {
            List<VM_Cbo> lstResult = new List<VM_Cbo>();

            try
            {
                CEntidad entBus = new CEntidad();
                Log_BUSQUEDA logBus = new Log_BUSQUEDA();
                entBus.BusFormulario = "COMBO_INDIVIDUAL";
                entBus.BusCriterio = asBusCriterio;
                entBus.BusValor = asBusValor;
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    lstResult = oCDatos.RegMostComboIndividual_v3(cn, entBus).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return lstResult;
        }
        #endregion

        #region Expediente
        public List<CEntidad> BuscarExpediente(CEntidad oCEntidad)
        {
            try
            {
                return oCDatos.BuscarExpediente(oCEntidad);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
