using CapaEntidad.ViewModel;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
//using System.Data.SqlClient;
using System.Linq;
using CDatos = CapaDatos.DOC.Dat_CNOTIFICACION;
using CEntidad = CapaEntidad.DOC.Ent_CNOTIFICACION;
using CEntSDetDevol = CapaEntidad.DOC.Ent_DEVOLUCION_MADERA;
using CEntSDetMarable = CapaEntidad.DOC.Ent_ISUPERVISION_DET_EMADERABLE;

namespace CapaLogica.DOC
{
    /// <summary>
    /// 
    /// </summary>
    public class Log_CNOTIFICACION
    {
        private CDatos oCDatos = new CDatos();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        //public List<CEntidad> RegMostrarLista(CEntidad oCEntidad)
        //{
        //    try
        //    {
        //        using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
        //        {
        //            cn.Open();
        //            return oCDatos.RegMostrarLista(cn, oCEntidad);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public List<CEntidad> RegMostPoa_Thabilitante_Lista_x_Numero(CEntidad oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegMostPoa_Thabilitante_Lista_x_Numero(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //public List<CEntidad> RegMostCNotificacion_Thabilitante_Lista_x_Numero(CEntidad oCEntidad)
        //{
        //    try
        //    {
        //        using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
        //        {
        //            cn.Open();
        //            return oCDatos.RegMostCNotificacion_Thabilitante_Lista_x_Numero(cn, oCEntidad);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public List<CEntidad> RegMostDevol_Thabilitante_Lista_x_Numero(CEntidad oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegMostDevol_Thabilitante_Lista_x_Numero(cn, oCEntidad);
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
        public CEntidad RegMostrarListaItem(CEntidad oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegMostrarListaItem(cn, oCEntidad);
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
        public String RegInsertar(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegInsertar(cn, oCampoEntrada);
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
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /*public CEntidad RegPresupuestoMostCombo()
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
                {
                    cn.Open();
                    return oCDatos.RegPresupuestoMostCombo(cn);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }*/
        //Persona Natural
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="oCampoEntrada"></param>
        ///// <returns></returns>
        //public String RegPRNaturalInsertar(CEntidad oCampoEntrada)
        //{
        //    try
        //    {
        //        using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
        //        {
        //            cn.Open();
        //            return oCDatos.RegPRNaturalInsertar(cn, oCampoEntrada);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="oCampoEntrada"></param>
        //public void RegPRNaturalActualizar(CEntidad oCampoEntrada)
        //{
        //    try
        //    {
        //        using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
        //        {
        //            cn.Open();
        //            oCDatos.RegPRNaturalInsertar(cn, oCampoEntrada);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="oCampoEntrada"></param>
        /// <returns></returns>
        public CEntidad RegMostrarPoaDetMadCensoLista(CEntSDetMarable oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegMostrarPoaDetMadCensoLista(cn, oCampoEntrada);
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
        public CEntidad RegMostrarPoaDetNoMadCensoLista(CEntSDetMarable oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegMostrarPoaDetNoMadCensoLista(cn, oCampoEntrada);
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
        //public CEntidad RegMostrarDevolDetTrozaCensoLista(CEntSDetDevol oCampoEntrada)
        //{
        //    try
        //    {
        //        using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
        //        {
        //            cn.Open();
        //            return oCDatos.RegMostrarDevolDetTrozaCensoLista(cn, oCampoEntrada);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="oCampoEntrada"></param>
        /// <returns></returns>
        //public CEntidad RegMostrarDevolDetToconCensoLista(CEntSDetDevol oCampoEntrada)
        //{
        //    try
        //    {
        //        using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
        //        {
        //            cn.Open();
        //            return oCDatos.RegMostrarDevolDetToconCensoLista(cn, oCampoEntrada);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="oCampoEntrada"></param>
        /// <returns></returns>
        //public CEntidad RegMostrarDevolDetArbolCensoLista(CEntSDetDevol oCampoEntrada)
        //{
        //    try
        //    {
        //        using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
        //        {
        //            cn.Open();
        //            return oCDatos.RegMostrarDevolDetArbolCensoLista(cn, oCampoEntrada);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="oCampoEntrada"></param>
        ///// <returns></returns>
        //public CEntidad RegPNaturalBuscar(CEntidad oCampoEntrada)
        //{
        //    try
        //    {
        //        using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
        //        {
        //            cn.Open();
        //            return oCDatos.RegPRNaturalBuscar(cn, oCampoEntrada);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="oCampoEntrada"></param>
        /// <returns></returns>
        //public List<CEntidad> RegMostrarThabiliPoaLista(CEntidad oCampoEntrada)
        //{
        //    try
        //    {
        //        using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
        //        {
        //            cn.Open();
        //            return oCDatos.RegMostrarThabiliPoaLista(cn, oCampoEntrada);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="oCampoEntrada"></param>
        /// <returns></returns>
        public Int32 RegInsertar_Maderable_Muestra(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegInsertar_Maderable_Muestra(cn, oCampoEntrada);
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
        public Int32 RegInsertar_NoMaderable_Muestra(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegInsertar_NoMaderable_Muestra(cn, oCampoEntrada);
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
        //public Int32 RegInsertar_DevolArbol_Muestra(CEntidad oCampoEntrada)
        //{
        //    try
        //    {
        //        using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
        //        {
        //            cn.Open();
        //            return oCDatos.RegInsertar_DevolArbol_Muestra(cn, oCampoEntrada);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="oCampoEntrada"></param>
        /// <returns></returns>
        //public Int32 RegInsertar_DevolTocon_Muestra(CEntidad oCampoEntrada)
        //{
        //    try
        //    {
        //        using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
        //        {
        //            cn.Open();
        //            return oCDatos.RegInsertar_DevolTocon_Muestra(cn, oCampoEntrada);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="oCampoEntrada"></param>
        /// <returns></returns>
        //public Int32 RegInsertar_DevolTroza_Muestra(CEntidad oCampoEntrada)
        //{
        //    try
        //    {
        //        using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
        //        {
        //            cn.Open();
        //            return oCDatos.RegInsertar_DevolTroza_Muestra(cn, oCampoEntrada);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //#region "PRESUPUESTO CARTA NOTIFICACION"       
        //public String RegCNOTIFICACION_VS_PSUPERVISION_Insertar(CEntidad oCampoEntrada)
        //{
        //    try
        //    {
        //        using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
        //        {
        //            cn.Open();
        //            return oCDatos.RegCNOTIFICACION_VS_PSUPERVISION_Insertar(cn, oCampoEntrada);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}    
        //#endregion
        //#region zafra
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="oCEntidad"></param>
        ///// <returns></returns>
        //public CEntidad RegMostZafraMuestraItem(CEntidad oCEntidad)
        //{
        //    try
        //    {
        //        using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
        //        {
        //            cn.Open();
        //            return oCDatos.RegMostZafraMuestraItem(cn, oCEntidad);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="oCampoEntrada"></param>
        /// <returns></returns>
        //public String RegInsertarZafraMuestra(CEntidad oCampoEntrada)
        //{
        //    try
        //    {
        //        using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
        //        {
        //            cn.Open();
        //            return oCDatos.RegInsertarZafraMuestra(cn, oCampoEntrada);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //#endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="oCampoEntrada"></param>
        /// <returns></returns>
        //public Int32 RegActualizarNumeroMuestraPOA(CEntidad oCampoEntrada)
        //{
        //    try
        //    {
        //        using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
        //        {
        //            cn.Open();
        //            return oCDatos.RegActualizarNumeroMuestraPOA(cn, oCampoEntrada);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        /*########################## SIGOsfc v3 ##############################*/
        #region SIGOsfc v3
        public List<CEntidad> RegMostCNotificacion_Consulta(CEntidad oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegMostCNotificacion_Consulta(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public VM_CartaNotificacion IniDatosCNotificacion(string asCodCNotificacion, string asCodTipoCN, string asCodUCuenta)
        {
            VM_CartaNotificacion VM_CN = new VM_CartaNotificacion();

            try
            {
                VM_CN.lblTituloCabecera = "Carta de Notificación";

                CEntidad entCN = new CEntidad();
                entCN.BusFormulario = "CARTA_NOTIFICACION";
                entCN.COD_UCUENTA = asCodUCuenta;
                entCN = RegMostCombo(entCN);
                VM_CN.ddlOd = entCN.ListODs.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION });
                VM_CN.ddlTipoCNotificacion = entCN.ListTipoCN.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION });
                VM_CN.ddlParentesco = entCN.ListMComboParentesco.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION });

                if (String.IsNullOrEmpty(asCodCNotificacion))
                {
                    VM_CN.lblTituloEstado = "Nuevo Registro";
                    VM_CN.ddlTipoCNotificacionId = asCodTipoCN;
                    if (asCodTipoCN == "0000005" || asCodTipoCN == "0000006" || asCodTipoCN == "0000007")
                    {
                        VM_CN.lstChkTipoSupervisionId = "AQ";
                    }
                }
                else
                {
                    entCN = new CEntidad();
                    entCN.COD_CNOTIFICACION = asCodCNotificacion;
                    entCN = RegMostrarListaItem(entCN);

                    VM_CN.lblTituloEstado = "Modificando Registro";
                    VM_CN.hdfCodCNotificacion = asCodCNotificacion;
                    VM_CN.hdfRegEstado = 0;
                    VM_CN.hdfiCodTramite = entCN.ID_TRAMITE_SITD;
                    VM_CN.vmControlCalidad.ddlIndicadorId = entCN.COD_ESTADO_DOC;
                    VM_CN.vmControlCalidad.txtUsuarioRegistro = entCN.USUARIO_REGISTRO;
                    VM_CN.vmControlCalidad.txtUsuarioControl = entCN.USUARIO_CONTROL;
                    VM_CN.vmControlCalidad.chkObsSubsanada = (bool)entCN.OBSERV_SUBSANAR;
                    VM_CN.vmControlCalidad.txtControlCalidadObservaciones = entCN.OBSERVACIONES_CONTROL.ToString();

                    VM_CN.ddlOdId = entCN.COD_OD_REGISTRO;
                    VM_CN.ddlTipoCNotificacionId = entCN.MAE_COD_CNTIPO;
                    VM_CN.txtNumCNotificacion = entCN.NUMERO;
                    VM_CN.txtFecEmision = entCN.FECHA_EMISION.ToString();
                    VM_CN.txtFecSupervision = entCN.FECHA_PSUPERVISION.ToString();
                    VM_CN.ddlMesSupervisionId = entCN.MES_SUPERVISION == "Ninguno" ? "0000000" : entCN.MES_SUPERVISION;
                    VM_CN.lstChkTipoSupervisionId = entCN.ESTADO_ORIGEN;
                    if (VM_CN.lstChkTipoSupervisionId != "")
                    {
                        List<VM_Chk> lstTCap = VM_CN.lstChkTipoSupervision.ToList();
                        for (int i = 0; i < lstTCap.Count; i++)
                        {
                            var itemOrigen = lstTCap[i].Value == "P" ? "PP" : lstTCap[i].Value;

                            if (VM_CN.lstChkTipoSupervisionId.Contains(itemOrigen) || (itemOrigen == "PP" && VM_CN.lstChkTipoSupervisionId == "P"))
                            {
                                lstTCap[i].Checked = true;
                            }
                        }
                        VM_CN.lstChkTipoSupervision = lstTCap.ToList();
                    }
                    VM_CN.lblTHabilitante = entCN.NUM_THABILITANTE;
                    VM_CN.hdfCodTHabilitante = entCN.COD_THABILITANTE;

                    VM_CN.txtFecRecepcionOd = entCN.FECHA_RECEPCION_OD.ToString();
                    VM_CN.txtFecEntregaNft = entCN.FECHA_NOTIFICADOR.ToString();
                    VM_CN.txtFecNotificacion = entCN.RNOTIFICACION_FECHA.ToString();
                    VM_CN.lblPersonaNotificada = entCN.PERSONA_RNOTIFICACION;
                    VM_CN.hdfCodPersonaNatificada = entCN.RNOTIFICACION_COD_PERSONA;
                    VM_CN.ddlParentescoId = entCN.COD_PARENTESCO_RTITULAR;
                    VM_CN.chkNtfBajoPuerta = (bool)entCN.BUZON;
                    VM_CN.lblUbigeo = entCN.LNOTIFI_UBIGEO;
                    VM_CN.hdfCodUbigeo = entCN.LNOTIFI_COD_UBIGEO;
                    VM_CN.txtDireccion = entCN.LNOTIFI_DIRECCION;
                    VM_CN.lblUbigeo_actual = entCN.LNOTIFI_UBIGEO_ACTUAL;
                    VM_CN.hdfCodUbigeo_actual = entCN.LNOTIFI_COD_UBIGEO_ACTUAL;
                    VM_CN.txtDireccion_actual = entCN.LNOTIFI_DIRECCION_ACTUAL;
                    VM_CN.lblReferencia_actual = entCN.LNOTIFI_REFERENCIA_ACTUAL;

                    VM_CN.chkCoincideDirTh = (bool)entCN.DIR_COINCIDE_DTITULAR;
                    VM_CN.lblNotificador = entCN.PERSONA_NOTIFICADOR;
                    VM_CN.hdfCodNatificador = entCN.COD_PERSONA_NOTIFICADOR;
                    VM_CN.txtObservacion = entCN.OBSERVACION.ToString();
                    VM_CN.lblCNotificacionRef = entCN.NUMERO_REF;
                    VM_CN.hdfCodCNotificacionRef = entCN.COD_CNOTIFICACION_REF;
                    VM_CN.hdfCodInforme = entCN.COD_INFORME;
                    VM_CN.lblInforme = entCN.NUM_INFORME;

                    VM_CN.tbPoaPo_Dema = entCN.ListNUM_POA;
                    VM_CN.tbDevolMadera = entCN.ListNUM_DEVOL;

                    VM_CN.Ent_Notificado = entCN.ENT_NOTIFICADO;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return VM_CN;
        }

        public ListResult GuardarDatosCNotificacion(VM_CartaNotificacion _dto, string asCodUCuenta)
        {
            ListResult result = new ListResult();

            try
            {
                ValidarDatosCNotificacion(_dto);

                CEntidad paramsCN = new CEntidad();
                paramsCN.ENT_NOTIFICADO = new VM_Persona();
                paramsCN.COD_CNOTIFICACION = _dto.hdfCodCNotificacion ?? "";
                paramsCN.NUMERO = _dto.txtNumCNotificacion;
                paramsCN.MAE_COD_CNTIPO = _dto.ddlTipoCNotificacionId;
                paramsCN.FECHA_EMISION =Convert.ToDateTime(_dto.txtFecEmision);
                paramsCN.FECHA_PSUPERVISION = string.IsNullOrEmpty(_dto.txtFecSupervision)?(DateTime?)null:Convert.ToDateTime(_dto.txtFecSupervision);
                paramsCN.MES_SUPERVISION = _dto.ddlMesSupervisionId == "0000000" ? null : _dto.ddlMesSupervisionId;
                paramsCN.COD_THABILITANTE = _dto.hdfCodTHabilitante;

                paramsCN.FECHA_RECEPCION_OD = string.IsNullOrEmpty(_dto.txtFecRecepcionOd) ? (DateTime?)null : Convert.ToDateTime(_dto.txtFecRecepcionOd);  
                paramsCN.FECHA_NOTIFICADOR = string.IsNullOrEmpty(_dto.txtFecEntregaNft) ? (DateTime?)null : Convert.ToDateTime(_dto.txtFecEntregaNft);  
                paramsCN.RNOTIFICACION_FECHA = string.IsNullOrEmpty(_dto.txtFecNotificacion) ? (DateTime?)null : Convert.ToDateTime(_dto.txtFecNotificacion); 
                paramsCN.COD_PERSONA_NOTIFICADOR = _dto.hdfCodNatificador ?? "";
                paramsCN.BUZON = _dto.chkNtfBajoPuerta;
                if (!(bool)paramsCN.BUZON)
                {
                    paramsCN.RNOTIFICACION_COD_PERSONA = _dto.hdfCodPersonaNatificada;
                    paramsCN.COD_PARENTESCO_RTITULAR = _dto.ddlParentescoId;
                }
                paramsCN.LNOTIFI_COD_UBIGEO = _dto.hdfCodUbigeo ?? "";
                paramsCN.LNOTIFI_DIRECCION = _dto.txtDireccion ?? "";
                paramsCN.LNOTIFI_COD_UBIGEO_ACTUAL = _dto.hdfCodUbigeo_actual ?? "";
                paramsCN.LNOTIFI_DIRECCION_ACTUAL = _dto.txtDireccion_actual ?? "";
                paramsCN.LNOTIFI_REFERENCIA_ACTUAL = _dto.lblReferencia_actual ?? "";
                //datos del notificado
                paramsCN.ENT_NOTIFICADO.tbCorreo = _dto.Ent_Notificado.tbCorreo;
                paramsCN.ENT_NOTIFICADO.tbTelefono = _dto.Ent_Notificado.tbTelefono;

                paramsCN.DIR_COINCIDE_DTITULAR = _dto.chkCoincideDirTh;
                paramsCN.NINTERNET_TITULAR = _dto.Ent_Notificado.rb_internet;
                paramsCN.OBSERVACION = _dto.txtObservacion ?? "";

                if (paramsCN.MAE_COD_CNTIPO == "0000002") // Carta de Reprogramación de Supervisión
                {
                    paramsCN.COD_CNOTIFICACION_REF = _dto.hdfCodCNotificacionRef ?? "";
                }
                else if (paramsCN.MAE_COD_CNTIPO == "0000006") //Carta de Notificación de Informe de Hallazgos
                {
                    paramsCN.COD_INFORME = _dto.hdfCodInforme;
                    paramsCN.ESTADO_ORIGEN = _dto.lstChkTipoSupervisionId ?? "";
                }
                else
                {
                    paramsCN.ESTADO_ORIGEN = _dto.lstChkTipoSupervisionId ?? "";
                }

                paramsCN.ListNUM_POA = _dto.tbPoaPo_Dema;
                paramsCN.ListEliTABLA = _dto.tbEliTABLA;

                //Variables de control de calidad
                paramsCN.COD_ESTADO_DOC = _dto.vmControlCalidad.ddlIndicadorId;
                paramsCN.OBSERVACIONES_CONTROL = _dto.vmControlCalidad.txtControlCalidadObservaciones;
                paramsCN.OBSERV_SUBSANAR = _dto.vmControlCalidad.chkObsSubsanada;
                paramsCN.COD_OD_REGISTRO = _dto.ddlOdId;

                paramsCN.RegEstado = _dto.hdfRegEstado;
                paramsCN.COD_UCUENTA = asCodUCuenta;
                paramsCN.ID_TRAMITE_SITD = _dto.hdfiCodTramite;
                paramsCN.OUTPUTPARAM01 = "";

                RegInsertar(paramsCN);

                string msjRespuesta = _dto.hdfRegEstado == 1 ? "El Registro se Guardo Correctamente" : "El Registro se Modifico Correctamente";
                result.AddResultado(msjRespuesta, true);
            }
            catch (Exception ex)
            {
                result.AddResultado(ex.Message, false);
                //result.AddResultado("Hubo un problema en el registro, por favor de verifique sus datos o intente en unos minutos.", false);
            }

            return result;
        }
        private void ValidarDatosCNotificacion(VM_CartaNotificacion _dto)
        {
            if (_dto.vmControlCalidad.ddlIndicadorId == "0000000") throw new Exception("Seleccione el estado actual del registro");
            if (_dto.ddlOdId == "0000000") throw new Exception("Seleccione la oficina desconcentrada");
            if (_dto.ddlTipoCNotificacionId == "0000000") throw new Exception("Seleccione el tipo de carta de notificación");
            if (string.IsNullOrEmpty(_dto.txtNumCNotificacion)) throw new Exception("Ingrese el número de la carta de notificación");
            if (string.IsNullOrEmpty(_dto.txtFecEmision)) throw new Exception("Seleccione la fecha de emisión");
            if (string.IsNullOrEmpty(_dto.hdfCodTHabilitante)) throw new Exception("Seleccione el Título Habilitante");

            if (_dto.ddlTipoCNotificacionId == "0000001")//Carta de supervisión
            {
                switch (_dto.lstChkTipoSupervisionId ?? "")
                {
                    case "P":
                        if (_dto.tbPoaPo_Dema.Count == 0) throw new Exception("Seleccione el POA/PO | DEMA");
                        break;
                    case "PM":
                    case "TH":
                        break;
                    case "DM":
                        if (_dto.tbDevolMadera.Count == 0) throw new Exception("Seleccione la Devolución de Madera");
                        break;
                    default: throw new Exception("Debe seleccionar un tipo de supervisión");
                }
            }
        }

        public VM_CNotificacionMuestra InitDatosCNotificacionMuestra(string asCodCNotificacion, string asTipoMuestra)
        {
            VM_CNotificacionMuestra vmCNot = new VM_CNotificacionMuestra();

            try
            {
                string sTitulo = "";

                switch (asTipoMuestra)
                {
                    case "M": sTitulo += "MADERABLES"; break;
                    case "NM":
                        sTitulo += "NO MADERABLES";
                        vmCNot.ddlFiltroBusqueda = new List<VM_Cbo>() {
                            new VM_Cbo() { Value="TODOS",Text="Todos"},
                            new VM_Cbo() { Value = "MUESTRA", Text = "Muestra" },
                            new VM_Cbo() { Value = "NO_MUESTRA", Text = "No Muestra" },
                            new VM_Cbo() { Value = "COND_PRODUCTIVO", Text = "Condición Productivo" },
                            new VM_Cbo() { Value = "COND_NO_PRODUCTIVO", Text = "Condición No Productivo" }
                        };
                        vmCNot.ddlCriterioBusqueda = new List<VM_Cbo>() {
                            new VM_Cbo() { Value="ESPECIE",Text="Especie"},
                            new VM_Cbo() { Value = "CESTE", Text = "Coordenada Este" },
                            new VM_Cbo() { Value = "CNORTE", Text = "Coordenada Norte" },
                            new VM_Cbo() { Value = "ESTRADA", Text = "Estrada" },
                            new VM_Cbo() { Value = "CODIGO", Text = "Código" },
                            new VM_Cbo() { Value = "POA", Text = "POA" }
                        };
                        break;
                    case "DTR":
                    case "DTO":
                    case "DAR":
                        if (asTipoMuestra == "DTR") { sTitulo += "DEVOLUCIÓN DE TROZAS"; }
                        else if (asTipoMuestra == "DTO") { sTitulo += "DEVOLUCIÓN DE TOCONES"; }
                        else { sTitulo += "DEVOLUCIÓN DE ÁRBOLES"; }

                        vmCNot.ddlFiltroBusqueda = new List<VM_Cbo>() {
                            new VM_Cbo() { Value="TODOS",Text="Todos"},
                            new VM_Cbo() { Value = "MUESTRA", Text = "Muestra" },
                            new VM_Cbo() { Value = "NO_MUESTRA", Text = "No Muestra" }
                        };
                        vmCNot.ddlCriterioBusqueda = new List<VM_Cbo>() {
                            new VM_Cbo() { Value="ESPECIE",Text="Especie"},
                            new VM_Cbo() { Value = "CESTE", Text = "Coordenada Este" },
                            new VM_Cbo() { Value = "CNORTE", Text = "Coordenada Norte" },
                            new VM_Cbo() { Value = "CODIGO", Text = "Código" }
                        };
                        break;
                }

                vmCNot.hdfCodCNotificacion = asCodCNotificacion;
                vmCNot.hdfTipoMuestra = asTipoMuestra;
                vmCNot.lblTituloEstado = "Registro Muestra " + sTitulo;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return vmCNot;
        }
        public ListResult GuardarDatosCNotificacionMuestra(VM_CNotificacionMuestra _dto, string asCodUCuenta)
        {
            ListResult result = new ListResult();

            try
            {
                CEntidad paramsCN = new CEntidad();

                paramsCN.COD_CNOTIFICACION = _dto.hdfCodCNotificacion;
                paramsCN.COD_THABILITANTE = _dto.hdfCodTHabilitante;
                paramsCN.COD_UCUENTA = asCodUCuenta;
                paramsCN.ListEliTABLACenso = _dto.tbEliTABLA;

                switch (_dto.hdfTipoMuestra)
                {
                    case "M":
                    case "NM":
                        paramsCN.ListSDETMADERABLE_Muestra = _dto.tbMuestra;

                        if (_dto.hdfTipoMuestra == "M")
                        {
                            paramsCN.ELIM_TOTAL_MUESTRA_M = _dto.hdfRemoveAllMuestraSelect;
                            RegInsertar_Maderable_Muestra(paramsCN);
                        }
                        else
                        {
                            paramsCN.ELIM_TOTAL_MUESTRA_NM = _dto.hdfRemoveAllMuestraSelect;
                            RegInsertar_NoMaderable_Muestra(paramsCN);
                        }
                        break;
                    case "DTR":
                        paramsCN.ListSDETDEVOLUCION_Muestra = _dto.tbMuestraDevolucion;
                        paramsCN.ELIM_TOTAL_MUESTRA_DMTR = _dto.hdfRemoveAllMuestraSelect;
                        //RegInsertar_DevolTroza_Muestra(paramsCN);
                        break;
                    case "DTO":
                        paramsCN.ListSDETDEVOLUCION_Muestra = _dto.tbMuestraDevolucion;
                        paramsCN.ELIM_TOTAL_MUESTRA_DMTO = _dto.hdfRemoveAllMuestraSelect;
                        //RegInsertar_DevolTocon_Muestra(paramsCN);
                        break;
                    case "DAR":
                        paramsCN.ListSDETDEVOLUCION_Muestra = _dto.tbMuestraDevolucion;
                        paramsCN.ELIM_TOTAL_MUESTRA_DMAR = _dto.hdfRemoveAllMuestraSelect;
                        //RegInsertar_DevolArbol_Muestra(paramsCN);
                        break;
                }

                result.AddResultado("La Muestra se Guardo Correctamente", true);
            }
            catch (Exception ex)
            {
                result.AddResultado(ex.Message, false);
            }

            return result;
        }

        public ListResult CuardarCensoComoMuestra(string asCodCNotificacion, string asTipoMuestra, string asCodUCuenta)
        {
            ListResult result = new ListResult();

            try
            {
                CEntidad paramsCN = new CEntidad();
                paramsCN.COD_CNOTIFICACION = asCodCNotificacion;
                paramsCN.COD_THABILITANTE = "";
                paramsCN.COD_UCUENTA = asCodUCuenta;

                switch (asTipoMuestra)
                {
                    case "M":
                    case "NM":
                        CEntSDetMarable paramMuestra = new CEntSDetMarable();
                        paramMuestra.COD_CNOTIFICACION = asCodCNotificacion;
                        List<CEntSDetMarable> lstCenso = new List<CEntSDetMarable>();

                        if (asTipoMuestra == "M") { lstCenso = RegMostrarPoaDetMadCensoLista(paramMuestra).ListSDETMADERABLE; }
                        else { lstCenso = RegMostrarPoaDetNoMadCensoLista(paramMuestra).ListSDETMADERABLE; }

                        for (int i = 0; i < lstCenso.Count; i++)
                        {
                            if ((lstCenso[i].NUM_MUESTRA == 1 && (bool)lstCenso[i].ESTADO_MUESTRA == false)
                                || (lstCenso[i].NUM_MUESTRA == 2 && (bool)lstCenso[i].ESTADO_MUESTRA2 == false)
                                || (lstCenso[i].NUM_MUESTRA == 3 && (bool)lstCenso[i].ESTADO_MUESTRA3 == false))
                            {
                                lstCenso[i].RegEstado = 1;
                            }
                        }
                        paramsCN.ListSDETMADERABLE_Muestra = lstCenso;
                        break;
                    case "DTR":
                    case "DTO":
                    case "DAR":
                        CEntSDetDevol paramsDev = new CEntSDetDevol();
                        List<CEntSDetDevol> lstCensoDev = new List<CEntSDetDevol>();
                        paramsDev.COD_CNOTIFICACION = asCodCNotificacion;

                        //if (asTipoMuestra == "DTR") { lstCensoDev = RegMostrarDevolDetTrozaCensoLista(paramsDev).ListSDETDEVOLUCION; }
                        //else if (asTipoMuestra == "DTO") { lstCensoDev = RegMostrarDevolDetToconCensoLista(paramsDev).ListSDETDEVOLUCION; }
                        //else { lstCensoDev = RegMostrarDevolDetArbolCensoLista(paramsDev).ListSDETDEVOLUCION; }

                        for (int i = 0; i < lstCensoDev.Count; i++)
                        {
                            if ((bool)lstCensoDev[i].ESTADO_MUESTRA == false)
                            {
                                lstCensoDev[i].RegEstado = 1;
                            }
                        }
                        paramsCN.ListSDETDEVOLUCION_Muestra = lstCensoDev;
                        break;
                }

                switch (asTipoMuestra)
                {
                    case "M": RegInsertar_Maderable_Muestra(paramsCN); break;
                    case "NM": RegInsertar_NoMaderable_Muestra(paramsCN); break;
                    //case "DTR": RegInsertar_DevolTroza_Muestra(paramsCN); break;
                    //case "DTO": RegInsertar_DevolTocon_Muestra(paramsCN); break;
                    //case "DAR": RegInsertar_DevolArbol_Muestra(paramsCN); break;
                }

                result.AddResultado("La Muestra se Guardo Correctamente", true);
            }
            catch (Exception ex)
            {
                result.AddResultado(ex.Message, false);
            }

            return result;
        }

        public List<Dictionary<string, string>> ReportesCNotificacion(CEntidad oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.ReportesCNotificacion(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
