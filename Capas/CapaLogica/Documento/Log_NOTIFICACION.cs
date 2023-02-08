using CapaEntidad.ViewModel;
using System;
using System.Collections.Generic;
//using System.Linq;
using CDatos = CapaDatos.DOC.Dat_NOTIFICACION;
//using CEntidad = CapaEntidad.DOC.Ent_NOTIFICACION;
//using CEntSDetDevol = CapaEntidad.DOC.Ent_DEVOLUCION_MADERA;
//using CEntSDetMarable = CapaEntidad.DOC.Ent_ISUPERVISION_DET_EMADERABLE;

namespace CapaLogica.DOC
{
    public class Log_NOTIFICACION
    {
        private CDatos oCDatos = new CDatos();

        //public VM_Notificacion InitDatos(string asCodNotificacion)
        //{
        //    VM_Notificacion vm = new VM_Notificacion();
        //    try
        //    {
        //        Log_BUSQUEDA exeBus = new Log_BUSQUEDA();

        //        vm.lblTituloCabecera = "Notificaciones";
        //        vm.ddlOd = exeBus.RegMostComboIndividual("OD", "");
        //        vm.ddlParentesco = exeBus.RegMostComboIndividual("PARENTESCO", "");
        //        vm.ddlFEntidad = exeBus.RegMostComboIndividual("FISCALIZACION_ENTIDAD", "");
        //        vm.ddlZona = exeBus.RegMostComboIndividual("ZONA_UTM", "");

        //        if (String.IsNullOrEmpty(asCodNotificacion))
        //        {
        //            vm.lblTituloEstado = "Nuevo Registro";
        //        }
        //        else
        //        {
        //            CEntidad datNot = oCDatos.RegMostrarListaItem(new CEntidad() { COD_FISNOTI = asCodNotificacion });

        //            vm.lblTituloEstado = "Modificando Registro";
        //            vm.hdfCodNotificacion = datNot.COD_FISNOTI;
        //            vm.vmControlCalidad.ddlIndicadorId = datNot.COD_ESTADO_DOC;
        //            vm.vmControlCalidad.txtUsuarioRegistro = datNot.USUARIO_REGISTRO;
        //            vm.vmControlCalidad.txtUsuarioControl = datNot.USUARIO_CONTROL;
        //            vm.vmControlCalidad.chkObsSubsanada = (bool)datNot.OBSERV_SUBSANAR;
        //            vm.vmControlCalidad.txtControlCalidadObservaciones = datNot.OBSERVACIONES_CONTROL.ToString();
        //            vm.ddlOdId = datNot.COD_OD_REGISTRO;
        //            vm.hdfCodTipoNotificacion = datNot.COD_FCTIPO;
        //            vm.lblTipoNotificacion = datNot.TIPO_NOTIFICACION;
        //            vm.txtNumNotificacion = datNot.NUMERO_NOTIFICACION;
        //            vm.txtFecEmision = datNot.FECHA_EMISION.ToString();
        //            vm.txtFecRecepcionOd = datNot.FECHA_RECEPCION_OD.ToString();
        //            vm.txtFecEntregaNft = datNot.FECHA_NOTIFICADOR.ToString();
        //            vm.txtFecNotificacion = datNot.FECHA_NOTIFICA_TITULAR.ToString();
        //            vm.hdfCodNotificador = datNot.COD_NOTIFICADOR;
        //            vm.lblNotificador = datNot.NOTIFICADOR;
        //            vm.hdfNotifTitular = (bool)datNot.NOTIF_TITULAR;
        //            vm.txtFecDevolSec = datNot.fdevolucionSEC.ToString();
        //            vm.ddlEstadoCargoId = datNot.IdEstadoCargo;
        //            vm.chkPrimeraVisita = (bool)datNot.FlagPrimeraVisita;
        //            vm.txtFecPrimeraVisita = datNot.FechaPrimeraVisita.ToString();
        //            vm.chkSegundaVisita = (bool)datNot.FlagSegundaVisita;
        //            vm.txtFecSegundaVisita = datNot.FechaSegundaVisita.ToString();
        //            if ((bool)datNot.FlagConformeRecepcion) vm.radListRecepcionId = "1";
        //            else if ((bool)datNot.FlagSeNegoRecibir) vm.radListRecepcionId = "2";
        //            else if ((bool)datNot.FlagSeNegoFirmar) vm.radListRecepcionId = "3";
        //            else if ((bool)datNot.FlagBajoPuerta) vm.radListRecepcionId = "4";
        //            vm.ddlParentescoId = datNot.COD_PARENTESCO;
        //            vm.txtParentesco = datNot.PARENTESCO;
        //            vm.hdfCodPersonaRecibe = datNot.COD_RECIBE_NOTIFICA;
        //            vm.lblPersonaRecibe = datNot.RECIBE_NOTIFICA;
        //            vm.ddlFEntidadId = datNot.COD_FENTIDAD;
        //            vm.hdfCodUbigeo = datNot.COD_UBIGEO;
        //            vm.lblUbigeo = datNot.UBIGEO;
        //            vm.txtDireccion = datNot.DIRECCION;
        //            vm.chkActaNotifAdm = (bool)datNot.FlagActaNotificacion;
        //            if ((bool)datNot.MedidorAgua) vm.radListMedidorId = "1";
        //            else if ((bool)datNot.MedidorLuz) vm.radListMedidorId = "2";
        //            vm.txtNumMedidor = datNot.NroMedidor;
        //            vm.txtDetalleFachada = datNot.MaterialColorFachada;
        //            vm.txtDetallePuerta = datNot.MaterialColorPuerta;
        //            vm.txtNroPisos = datNot.NroPisos;
        //            vm.ddlZonaId = datNot.ZONA;
        //            vm.txtCoordEste = datNot.COORDENADA_ESTE;
        //            vm.txtCoordNorte = datNot.COORDENADA_NORTE;
        //            vm.txtTelefono = datNot.TelefonoOtros;
        //            vm.chkCambioDomicilio = (bool)datNot.DJ_CAMBIO_DOMICILIO;
        //            vm.txtDireccionCambio = datNot.DireccionDeCambioDomicilio;
        //            vm.txtUrbanicacionCambio = datNot.UrbanizacionDeCambioDomicilio;
        //            vm.hdfCodUbigeoCambio = datNot.CodUbigeoCambioDomicilio;
        //            vm.lblUbigeoCambio = datNot.UbigeoCambioDomicilio;
        //            vm.txtReferenciaCambio = datNot.ReferenciaDeCambioDomicilio;
        //            vm.txtObservacion = datNot.OBSERVACION;
        //            vm.hdfCodificacionSITD = datNot.CODIFICACION_SITD;
        //            vm.txtDocumentoCargo = datNot.DOCUMENTO_CARGO;
        //            vm.chkCoincideDireccion = (bool)datNot.DIR_COINCIDE_DTITULAR;
        //            vm.txtFecSupervision = datNot.FECHA_PSUPERVISION.ToString();
        //            vm.ddlMesSupervisionId = datNot.MES_SUPERVISION == "Ninguno" ? "0000000" : datNot.MES_SUPERVISION;
        //            vm.lstChkTipoSupervisionId = datNot.ESTADO_ORIGEN;
        //            if (vm.lstChkTipoSupervisionId != "")
        //            {
        //                List<VM_Chk> lstTCap = vm.lstChkTipoSupervision.ToList();
        //                for (int i = 0; i < lstTCap.Count; i++)
        //                {
        //                    if (vm.lstChkTipoSupervisionId.Contains(lstTCap[i].Value))
        //                    {
        //                        lstTCap[i].Checked = true;
        //                    }
        //                }
        //                vm.lstChkTipoSupervision = lstTCap.ToList();
        //            }
        //            vm.hdfCodTHabilitante = datNot.COD_THABILITANTE;
        //            vm.lblTHabilitante = datNot.NUM_THABILITANTE;
        //            vm.hdfCodCNotificacionRef = datNot.COD_NOTIFICACION_REF;
        //            vm.lblCNotificacionRef = datNot.NUM_NOTIFICACION_REF;

        //            vm.tbInforme = datNot.ListInforme;
        //            vm.tbExpediente = datNot.ListExpediente;
        //            vm.tbResolucion = datNot.ListResolucion;
        //            vm.tbILegal = datNot.ListILegal;
        //            vm.tbPoa = datNot.ListPoa;
        //            vm.tbDevolucionMadera = datNot.ListDevolucionMadera;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return vm;
        //}

        //public ListResult GuardarDatos(VM_Notificacion aoDto, string asCodUCuenta)
        //{
        //    ListResult result = new ListResult();
        //    try
        //    {
        //        ValidarDatos(aoDto);
        //        CEntidad datNot = new CEntidad();
        //        datNot.COD_ESTADO_DOC = aoDto.vmControlCalidad.ddlIndicadorId;
        //        datNot.OBSERV_SUBSANAR = aoDto.vmControlCalidad.chkObsSubsanada;
        //        datNot.OBSERVACIONES_CONTROL = aoDto.vmControlCalidad.txtControlCalidadObservaciones;
        //        datNot.COD_OD_REGISTRO = aoDto.ddlOdId;
        //        datNot.COD_FISNOTI = aoDto.hdfCodNotificacion;
        //        datNot.NUMERO_NOTIFICACION = aoDto.txtNumNotificacion;
        //        datNot.FECHA_NOTIFICA_TITULAR = aoDto.txtFecNotificacion ?? "";
        //        datNot.COD_NOTIFICADOR = aoDto.hdfCodNotificador;
        //        datNot.fdevolucionSEC = aoDto.txtFecDevolSec ?? "";
        //        datNot.IdEstadoCargo = aoDto.ddlEstadoCargoId;
        //        datNot.FlagPrimeraVisita = aoDto.chkPrimeraVisita;
        //        datNot.FechaPrimeraVisita = aoDto.txtFecPrimeraVisita;
        //        datNot.FlagSegundaVisita = aoDto.chkSegundaVisita;
        //        datNot.FechaSegundaVisita = aoDto.txtFecSegundaVisita;
        //        switch (aoDto.radListRecepcionId)
        //        {
        //            case "1": datNot.FlagConformeRecepcion = true; break;
        //            case "2": datNot.FlagSeNegoRecibir = true; break;
        //            case "3": datNot.FlagSeNegoFirmar = true; break;
        //            case "4": datNot.FlagBajoPuerta = true; break;
        //        }
        //        datNot.COD_PARENTESCO = aoDto.ddlParentescoId;
        //        datNot.PARENTESCO = aoDto.txtParentesco;
        //        datNot.COD_RECIBE_NOTIFICA = aoDto.hdfCodPersonaRecibe;
        //        datNot.COD_FENTIDAD = aoDto.ddlFEntidadId;
        //        datNot.COD_UBIGEO = aoDto.hdfCodUbigeo;
        //        datNot.DIRECCION = aoDto.txtDireccion;
        //        datNot.FlagActaNotificacion = aoDto.chkActaNotifAdm;
        //        switch (aoDto.radListMedidorId)
        //        {
        //            case "1": datNot.MedidorAgua = true; break;
        //            case "2": datNot.MedidorLuz = true; break;
        //        }
        //        datNot.NroMedidor = aoDto.txtNumMedidor;
        //        datNot.MaterialColorFachada = aoDto.txtDetalleFachada;
        //        datNot.MaterialColorPuerta = aoDto.txtDetallePuerta;
        //        datNot.NroPisos = aoDto.txtNroPisos;
        //        datNot.ZONA = aoDto.ddlZonaId;
        //        datNot.COORDENADA_ESTE = aoDto.txtCoordEste;
        //        datNot.COORDENADA_NORTE = aoDto.txtCoordNorte;
        //        datNot.TelefonoOtros = aoDto.txtTelefono;
        //        datNot.DJ_CAMBIO_DOMICILIO = aoDto.chkCambioDomicilio;
        //        if ((bool)datNot.DJ_CAMBIO_DOMICILIO)
        //        {
        //            datNot.DireccionDeCambioDomicilio = aoDto.txtDireccionCambio;
        //            datNot.UrbanizacionDeCambioDomicilio = aoDto.txtUrbanicacionCambio;
        //            datNot.CodUbigeoCambioDomicilio = aoDto.hdfCodUbigeoCambio;
        //            datNot.UbigeoCambioDomicilio = aoDto.lblUbigeoCambio;
        //            datNot.ReferenciaDeCambioDomicilio = aoDto.txtReferenciaCambio;
        //        }
        //        datNot.OBSERVACION = aoDto.txtObservacion;
        //        datNot.DIR_COINCIDE_DTITULAR = aoDto.chkCoincideDireccion;

        //        datNot.FECHA_PSUPERVISION = aoDto.txtFecSupervision;
        //        datNot.MES_SUPERVISION = aoDto.ddlMesSupervisionId == "Ninguno" ? "" : aoDto.ddlMesSupervisionId;
        //        datNot.ESTADO_ORIGEN = aoDto.lstChkTipoSupervisionId;
        //        datNot.COD_THABILITANTE = aoDto.hdfCodTHabilitante;
        //        datNot.COD_NOTIFICACION_REF = aoDto.hdfCodCNotificacionRef;

        //        datNot.ListInforme = aoDto.tbInforme;
        //        datNot.ListExpediente = aoDto.tbExpediente;
        //        datNot.ListResolucion = aoDto.tbResolucion;
        //        datNot.ListILegal = aoDto.tbILegal;
        //        datNot.ListPoa = aoDto.tbPoa;
        //        datNot.ListDevolucionMadera = aoDto.tbDevolucionMadera;
        //        datNot.ListEliTABLA = aoDto.tbEliTABLA;

        //        datNot.COD_UCUENTA = asCodUCuenta;
        //        datNot.ORIGEN_REGISTRO = 1;
        //        datNot.OUTPUTPARAM01 = "";

        //        oCDatos.RegGrabar(datNot);
        //        result.AddResultado("El Registro se Modifico Correctamente", true);
        //    }
        //    catch (Exception ex)
        //    {
        //        result.AddResultado(ex.Message, false);
        //    }
        //    return result;
        //}

        private void ValidarDatos(VM_Notificacion aoDto)
        {
            if (aoDto.vmControlCalidad.ddlIndicadorId == "0000000") throw new Exception("Seleccione el estado actual del registro");
            if (aoDto.ddlOdId == "0000000") throw new Exception("Seleccione la oficina desconcentrada");
            if (string.IsNullOrEmpty(aoDto.txtNumNotificacion)) throw new Exception("Ingrese el número de la notificación");
        }

        //public void GrabarDocumentoCargo(CapaEntidad.DOC.Ent_NOTIFICACION_CARGO aoCargo)
        //{
        //    try
        //    {
        //        if (!string.IsNullOrEmpty(aoCargo.COD_FISNOTI) && !string.IsNullOrEmpty(aoCargo.DOCUMENTO_CARGO))
        //        {
        //            oCDatos.RegInsertarCargoSITD(aoCargo);
        //        }
        //        else
        //        {
        //            throw new Exception("Se encontro más de un error al grabar los datos del cargo [2]");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public VM_CNotificacionMuestra InitDatosCNotificacionMuestra(string asCodNotificacion, string asTipoMuestra)
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

                vmCNot.hdfCodCNotificacion = asCodNotificacion;
                vmCNot.hdfTipoMuestra = asTipoMuestra;
                vmCNot.lblTituloEstado = "Registro Muestra " + sTitulo;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return vmCNot;
        }
        //public ListResult GuardarDatosCNotificacionMuestra(VM_CNotificacionMuestra _dto, string asCodUCuenta)
        //{
        //    ListResult result = new ListResult();
        //    try
        //    {
        //        CapaEntidad.DOC.Ent_CNOTIFICACION paramsCN = new CapaEntidad.DOC.Ent_CNOTIFICACION();
        //        paramsCN.COD_FISNOTI = _dto.hdfCodCNotificacion;
        //        paramsCN.COD_THABILITANTE = _dto.hdfCodTHabilitante;
        //        paramsCN.COD_UCUENTA = asCodUCuenta;
        //        paramsCN.ListEliTABLACenso = _dto.tbEliTABLA;

        //        switch (_dto.hdfTipoMuestra)
        //        {
        //            case "M":
        //            case "NM":
        //                paramsCN.ListSDETMADERABLE_Muestra = _dto.tbMuestra;

        //                if (_dto.hdfTipoMuestra == "M")
        //                {
        //                    paramsCN.ELIM_TOTAL_MUESTRA_M = _dto.hdfRemoveAllMuestraSelect;
        //                    oCDatos.RegInsertar_Maderable_Muestra_v3(paramsCN);
        //                }
        //                else
        //                {
        //                    paramsCN.ELIM_TOTAL_MUESTRA_NM = _dto.hdfRemoveAllMuestraSelect;
        //                    oCDatos.RegInsertar_NoMaderable_Muestra_v3(paramsCN);
        //                }
        //                break;
        //            case "DTR":
        //                paramsCN.ListSDETDEVOLUCION_Muestra = _dto.tbMuestraDevolucion;
        //                paramsCN.ELIM_TOTAL_MUESTRA_DMTR = _dto.hdfRemoveAllMuestraSelect;
        //                oCDatos.RegInsertar_DevolTroza_Muestra_v3(paramsCN);
        //                break;
        //            case "DTO":
        //                paramsCN.ListSDETDEVOLUCION_Muestra = _dto.tbMuestraDevolucion;
        //                paramsCN.ELIM_TOTAL_MUESTRA_DMTO = _dto.hdfRemoveAllMuestraSelect;
        //                oCDatos.RegInsertar_DevolTocon_Muestra_v3(paramsCN);
        //                break;
        //            case "DAR":
        //                paramsCN.ListSDETDEVOLUCION_Muestra = _dto.tbMuestraDevolucion;
        //                paramsCN.ELIM_TOTAL_MUESTRA_DMAR = _dto.hdfRemoveAllMuestraSelect;
        //                oCDatos.RegInsertar_DevolArbol_Muestra_v3(paramsCN);
        //                break;
        //        }

        //        result.AddResultado("La Muestra se Guardo Correctamente", true);
        //    }
        //    catch (Exception ex)
        //    {
        //        result.AddResultado(ex.Message, false);
        //    }

        //    return result;
        //}
        //public ListResult CuardarCensoComoMuestra(string asCodNotificacion, string asTipoMuestra, string asCodUCuenta)
        //{
        //    ListResult result = new ListResult();

        //    try
        //    {
        //        CapaEntidad.DOC.Ent_CNOTIFICACION paramsCN = new CapaEntidad.DOC.Ent_CNOTIFICACION();
        //        paramsCN.COD_FISNOTI = asCodNotificacion;
        //        paramsCN.COD_THABILITANTE = "";
        //        paramsCN.COD_UCUENTA = asCodUCuenta;

        //        switch (asTipoMuestra)
        //        {
        //            case "M":
        //            case "NM":
        //                CEntSDetMarable paramMuestra = new CEntSDetMarable();
        //                paramMuestra.COD_FISNOTI = asCodNotificacion;
        //                List<CEntSDetMarable> lstCenso = new List<CEntSDetMarable>();

        //                if (asTipoMuestra == "M") { lstCenso = oCDatos.RegMostrarPoaDetMadCensoLista_v3(paramMuestra); }
        //                else { lstCenso = oCDatos.RegMostrarPoaDetNoMadCensoLista_v3(paramMuestra); }

        //                for (int i = 0; i < lstCenso.Count; i++)
        //                {
        //                    if ((lstCenso[i].NUM_MUESTRA == 1 && (bool)lstCenso[i].ESTADO_MUESTRA == false)
        //                        || (lstCenso[i].NUM_MUESTRA == 2 && (bool)lstCenso[i].ESTADO_MUESTRA2 == false)
        //                        || (lstCenso[i].NUM_MUESTRA == 3 && (bool)lstCenso[i].ESTADO_MUESTRA3 == false))
        //                    {
        //                        lstCenso[i].RegEstado = 1;
        //                    }
        //                }
        //                paramsCN.ListSDETMADERABLE_Muestra = lstCenso;
        //                break;
        //            case "DTR":
        //            case "DTO":
        //            case "DAR":
        //                CEntSDetDevol paramsDev = new CEntSDetDevol();
        //                List<CEntSDetDevol> lstCensoDev = new List<CEntSDetDevol>();
        //                paramsDev.COD_FISNOTI = asCodNotificacion;

        //                if (asTipoMuestra == "DTR") { lstCensoDev = oCDatos.RegMostrarDevolDetTrozaCensoLista_v3(paramsDev); }
        //                else if (asTipoMuestra == "DTO") { lstCensoDev = oCDatos.RegMostrarDevolDetToconCensoLista_v3(paramsDev); }
        //                else { lstCensoDev = oCDatos.RegMostrarDevolDetArbolCensoLista_v3(paramsDev); }

        //                for (int i = 0; i < lstCensoDev.Count; i++)
        //                {
        //                    if ((bool)lstCensoDev[i].ESTADO_MUESTRA == false)
        //                    {
        //                        lstCensoDev[i].RegEstado = 1;
        //                    }
        //                }
        //                paramsCN.ListSDETDEVOLUCION_Muestra = lstCensoDev;
        //                break;
        //        }

        //        switch (asTipoMuestra)
        //        {
        //            case "M": oCDatos.RegInsertar_Maderable_Muestra_v3(paramsCN); break;
        //            case "NM": oCDatos.RegInsertar_NoMaderable_Muestra_v3(paramsCN); break;
        //            case "DTR": oCDatos.RegInsertar_DevolTroza_Muestra_v3(paramsCN); break;
        //            case "DTO": oCDatos.RegInsertar_DevolTocon_Muestra_v3(paramsCN); break;
        //            case "DAR": oCDatos.RegInsertar_DevolArbol_Muestra_v3(paramsCN); break;
        //        }

        //        result.AddResultado("La Muestra se Guardo Correctamente", true);
        //    }
        //    catch (Exception ex)
        //    {
        //        result.AddResultado(ex.Message, false);
        //    }

        //    return result;
        //}

        //public List<CEntSDetMarable> RegMostrarPoaDetMadCensoLista_v3(CEntSDetMarable aoParams)
        //{
        //    try
        //    {
        //        return oCDatos.RegMostrarPoaDetMadCensoLista_v3(aoParams);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //public List<CEntSDetMarable> RegMostrarPoaDetNoMadCensoLista_v3(CEntSDetMarable aoParams)
        //{
        //    try
        //    {
        //        return oCDatos.RegMostrarPoaDetNoMadCensoLista_v3(aoParams);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //public List<CEntSDetDevol> RegMostrarDevolDetArbolCensoLista_v3(CEntSDetDevol aoParams)
        //{
        //    try
        //    {
        //        return oCDatos.RegMostrarDevolDetArbolCensoLista_v3(aoParams);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //public List<CEntSDetDevol> RegMostrarDevolDetToconCensoLista_v3(CEntSDetDevol aoParams)
        //{
        //    try
        //    {
        //        return oCDatos.RegMostrarDevolDetToconCensoLista_v3(aoParams);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //public List<CEntSDetDevol> RegMostrarDevolDetTrozaCensoLista_v3(CEntSDetDevol aoParams)
        //{
        //    try
        //    {
        //        return oCDatos.RegMostrarDevolDetTrozaCensoLista_v3(aoParams);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public List<CapaEntidad.DOC.Ent_NOTIFICACION_CONSULTA> RegListarNotificacionConsulta_v3(CapaEntidad.DOC.Ent_NOTIFICACION_CONSULTA aoParams)
        //{
        //    try
        //    {
        //        return oCDatos.RegListarNotificacionConsulta_v3(aoParams);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public List<Dictionary<string, string>> ReportesNotificacion(CEntidad oCEntidad)
        //{
        //    try
        //    {
        //        return oCDatos.ReportesNotificacion(oCEntidad);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
    }
}
