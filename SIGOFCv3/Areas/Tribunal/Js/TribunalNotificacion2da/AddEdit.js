var ManNotificacion_AddEdit = {};

ManNotificacion_AddEdit.tbEliTABLA = [];
ManNotificacion_AddEdit.selectFile = null;

//para iniciar los eventos
ManNotificacion_AddEdit.iniciarEventos = function () {
    ManNotificacion_AddEdit.frm.find("#txtFechaEmision").datepicker({ format: "dd/mm/yyyy", autoclose: true, language: 'es' });
    ManNotificacion_AddEdit.frm.find("#txtFechaEmision").prop("disabled", true);
    ManNotificacion_AddEdit.frm.find("#txtFechaRecepcion").datepicker({ format: "dd/mm/yyyy", autoclose: true, language: 'es' });
    ManNotificacion_AddEdit.frm.find("#txtFechaRecepcion").prop("disabled", true);
    ManNotificacion_AddEdit.frm.find("#txtFechaEntrega").datepicker({ format: "dd/mm/yyyy", autoclose: true, language: 'es' });
    ManNotificacion_AddEdit.frm.find("#txtFechaEntrega").prop("disabled", true);
    ManNotificacion_AddEdit.frm.find("#txtFechaNotificacion").datepicker({ format: "dd/mm/yyyy", autoclose: true, language: 'es' });
    ManNotificacion_AddEdit.frm.find("#txtFechaNotificacion").prop("disabled", true);
    ManNotificacion_AddEdit.frm.find("#txtFechaDevolucion").datepicker({ format: "dd/mm/yyyy", autoclose: true, language: 'es' });
    ManNotificacion_AddEdit.frm.find("#txtFechaPVisita").datepicker({ format: "dd/mm/yyyy", autoclose: true, language: 'es' });
    ManNotificacion_AddEdit.frm.find("#txtFechaPVisita").prop("disabled", true);
    ManNotificacion_AddEdit.frm.find("#txtFechaSVisita").datepicker({ format: "dd/mm/yyyy", autoclose: true, language: 'es' });
    ManNotificacion_AddEdit.frm.find("#txtFechaSVisita").prop("disabled", true);
    ManNotificacion_AddEdit.frm.find("#ddlTitularId").prop("disabled", true);
    ManNotificacion_AddEdit.frm.find("#txtNumCarta").prop("disabled", false);
    ManNotificacion_AddEdit.tbEliTABLA = {};

    $("#divParentesco").hide();
    $("#divNotificado").hide();
    $("#divLugarDJ").hide();
    $("#divUbigeoDJ").hide();

    var radSituacion;

    if (ManNotificacion_AddEdit.frm.find("#RegEstado").val() == 1) {
        if (ManNotificacion_AddEdit.frm.find("#hdfCodTipoNotificacion").val() == "0000080") {
            $("#liCaracteristicas").hide();
            $("#divDatosRecepcion").hide();
            $("#divNotificaEntidad").show();
            $("#divNotificaTitular").hide();
            $("#divNotificado").show();
        }
        else {
            $("#liCaracteristicas").show();
            $("#divDatosRecepcion").show();
            $("#divNotificaEntidad").hide();
            $("#divNotificaTitular").show();

            ManNotificacion_AddEdit.fnHabilitarFecha("#chkPrimeraVisita", "#txtFechaPVisita");
            ManNotificacion_AddEdit.fnHabilitarFecha("#chkSegundaVisita", "#txtFechaSVisita");

            radSituacion = ManNotificacion_AddEdit.frm.find('input:radio[name="radSituacion"]:checked').val();
            if (radSituacion != null) ManNotificacion_AddEdit.fnHabilitarComponentes(radSituacion);

            ManNotificacion_AddEdit.fnHabilitarCamposDJ(ManNotificacion_AddEdit.frm.find("#chkDeclaracionJurada").prop("checked"));
            ManNotificacion_AddEdit.fnHabilitarParentesco(ManNotificacion_AddEdit.frm.find("#ddlTitularId").val());
        }
    }
    else {
        if (ManNotificacion_AddEdit.frm.find("#idTramiteSITD").val() == 0) ManNotificacion_AddEdit.frm.find("#txtNumCarta").prop("disabled", true);

        if ((/true/i).test(ManNotificacion_AddEdit.frm.find("#chknotifTitular").val()) == true) {
            $("#liCaracteristicas").show();
            $("#divDatosRecepcion").show();
            $("#divNotificaEntidad").hide();
            $("#divNotificaTitular").show();

            ManNotificacion_AddEdit.fnHabilitarFecha("#chkPrimeraVisita", "#txtFechaPVisita");
            ManNotificacion_AddEdit.fnHabilitarFecha("#chkSegundaVisita", "#txtFechaSVisita");

            radSituacion = ManNotificacion_AddEdit.frm.find('input:radio[name="radSituacion"]:checked').val();
            if (radSituacion != null) ManNotificacion_AddEdit.fnHabilitarComponentes(radSituacion);

            ManNotificacion_AddEdit.fnHabilitarCamposDJ(ManNotificacion_AddEdit.frm.find("#chkDeclaracionJurada").prop("checked"));
            ManNotificacion_AddEdit.fnHabilitarParentesco(ManNotificacion_AddEdit.frm.find("#ddlTitularId").val());
        }
        else {
            $("#liCaracteristicas").hide();
            $("#divDatosRecepcion").hide();
            $("#divNotificaEntidad").show();
            $("#divNotificaTitular").hide();
            $("#divNotificado").show();
            ManNotificacion_AddEdit.frm.find("#txtFechaNotificacion").prop("disabled", false);
        }
    }

    

    if (ManNotificacion_AddEdit.frm.find("#txtnomArchOriginal").val().trim() == "") {
        $("#iconDownload").hide();
    }
    else {
        $("#iconDownload").show();
        ManNotificacion_AddEdit.frm.find("label[for='lblnomArchOriginal']").text(ManNotificacion_AddEdit.frm.find("#txtnomArchOriginal").val());
    }
};

//vuelve a la vista principal del listado
ManNotificacion_AddEdit.regresar = function (appServer) {
    var url = "";
    url = urlLocalSigo + "Tribunal/TribunalNotificacion2da/Index";
    window.location = url;

};

ManNotificacion_AddEdit.fnBuscarPersona = function (_dom, _tipoPersona) {
    var url = urlLocalSigo + "General/Controles/_BuscarPersonaGeneral";
    var option = { url: url, type: 'GET', datos: { asBusGrupo: "PERSONA", asCodPTipo: "TODOS", asTipoPersona: _tipoPersona }, divId: "mdlBuscarPersona" };
    utilSigo.fnOpenModal(option, function () {
        _bPerGen.fnAsignarDatos = function (obj) {
            if (obj != null && obj != "") {
                var data = _bPerGen.dtBuscarPerona.row($(obj).parents('tr')).data();
                switch (_dom) {
                    case "NOTIFICADOR":
                        ManNotificacion_AddEdit.frm.find("#hdfCodNotificador").val(data["COD_PERSONA"]);
                        ManNotificacion_AddEdit.frm.find("#txtNotificador").val(data["PERSONA"]);
                        ManNotificacion_AddEdit.frm.find("#hdTipoNotificador").val(_tipoPersona);
                        break;

                    case "NOTIFICADO":
                        ManNotificacion_AddEdit.frm.find("#hdfCodNotificado").val(data["COD_PERSONA"]);
                        ManNotificacion_AddEdit.frm.find("#txtNotificado").val(data["PERSONA"]);
                        ManNotificacion_AddEdit.frm.find("#hdTipoNotificado").val(_tipoPersona);
                        break;
                }
                utilSigo.fnCloseModal("mdlBuscarPersona");        
            }
        };
        _bPerGen.fnInit();
    });
};

ManNotificacion_AddEdit.fnBuscarUbigeo = function (_dom) {
    var url = urlLocalSigo + "General/Controles/_Ubigeo";
    var option = { url: url, type: 'POST', datos: {}, divId: "mdlBuscarUbigeo" };
    utilSigo.fnOpenModal(option, function () {
        _Ubigeo.fnSelectUbigeo = function (_ubigeoText, _ubigeoId) {
            switch (_dom) {
                case "UBIGEO":
                    ManNotificacion_AddEdit.frm.find("#hdfUbigeo").val(_ubigeoId);
                    ManNotificacion_AddEdit.frm.find("#txtUbigeo").val(_ubigeoText);
                    break;

                case "UBIGEO_DJ":
                    ManNotificacion_AddEdit.frm.find("#hdfUbigeoDJ").val(_ubigeoId);
                    ManNotificacion_AddEdit.frm.find("#txtUbigeoDJ").val(_ubigeoText);
                    break;
            }
            $("#mdlBuscarUbigeo").modal('hide');
        }

        switch (_dom) {
            case "UBIGEO":
                _Ubigeo.fnLoadModalView(ManNotificacion_AddEdit.frm.find("#hdfUbigeo").val());
                break;

            case "UBIGEO_DJ":
                _Ubigeo.fnLoadModalView(ManNotificacion_AddEdit.frm.find("#hdfUbigeoDJ").val());
                break;
        }

    }, ManNotificacion_AddEdit.fnCustomValidateForm);
};

ManNotificacion_AddEdit.fnSelectDocAdjunto = function (e, obj) {
    var idFile = $(obj).attr("id");
    var files = e.target.files || e.dataTransfer.files;

    if (files != undefined && files.length > 0) {
        //Validar extensión archivo seleccionado
        var extension = files[0].name.substr((files[0].name.lastIndexOf('.') + 1));
        var extensiones_no_permitidas = "exe,bin,bat,run";

        if (!extensiones_no_permitidas.includes(extension)) {
            //Validar el tamaño del archivo
            var fileSize = parseFloat(files[0].size);
            if ((fileSize / 1048576) > 20) //20MB permitido por foto
            {
                utilSigo.toastError("Error", "El tamaño del archivo supera los 20MB permitidos"); return false;
            } else {
                $("#" + idFile).next().text(files[0].name);
                ManNotificacion_AddEdit.selectFile = files[0];
                ManNotificacion_AddEdit.fnSaveDocumentoAdjunto();
            }
        } else {
            utilSigo.toastError("Error", "La extensión ." + extension + " no esta permitida"); return false;
        }
    }
}

ManNotificacion_AddEdit.fnSaveDocumentoAdjunto = function () {
    if (ManNotificacion_AddEdit.selectFile == null) {
        utilSigo.toastWarning("Aviso", "Seleccione el documento a adjuntar"); return false;
    }

    // Checking whether FormData is available in browser  
    if (window.FormData !== undefined) {
        var fileData = new FormData();
        //var url = urlLocalSigo + "Fiscalizacion/FiscalizacionNotificacion/GrabarDocumentoAdjunto";
        var url = urlLocalSigo + "Tribunal/TribunalNotificacion2da/GrabarDocumentoAdjunto";
        var data = {};

        /*data.COD_CAPACITACION = ManCapacitacion_AddEdit.frm.find("#hdfCodCapacitacion").val();
        data.MAE_COD_TIPOADJUNTO = ManCapacitacion_AddEdit.frm.find("#ddlTipoAdjuntoId").val();
        data.OBSERVACION = ManCapacitacion_AddEdit.frm.find("#txtObservacionTAdjunto").val();*/

        fileData.append("data", JSON.stringify(data));
        fileData.append(ManNotificacion_AddEdit.selectFile.name, ManNotificacion_AddEdit.selectFile);

        $.ajax({
            url: url,
            type: "POST",
            contentType: false, // Not to set any content header  
            processData: false, // Not to process data  
            data: fileData,
            success: function (result) {
                if (result.success) {
                    ManNotificacion_AddEdit.frm.find("#txtnomArchOriginal").val(result.data.NOMBRE_ARCHIVO);
                    ManNotificacion_AddEdit.frm.find("#txtnomArchTemporal").val(result.data.NOMBRE_TEMPORAL_ARCHIVO);
                    ManNotificacion_AddEdit.frm.find("#txtextArch").val(result.data.EXTENSION_ARCHIVO);
                    ManNotificacion_AddEdit.frm.find("#txtestadoArch").val(result.data.ESTADO_ARCHIVO);
                    $("#iconDownload").show();
                    ManNotificacion_AddEdit.frm.find("label[for='lblnomArchOriginal']").text(result.data.NOMBRE_ARCHIVO);

                    ManNotificacion_AddEdit.frm.find("#txtArchivoAdjunto").next().text("Seleccionar Archivo");
                    ManNotificacion_AddEdit.frm.find("#txtArchivoAdjunto").val("");
                    ManNotificacion_AddEdit.selectFile = null;
                    utilSigo.toastSuccess("Éxito", result.msj);

                    console.log(ManNotificacion_AddEdit.frm.find("#txtnomArchOriginal").val());
                    console.log(result.data);
                }
                else {
                    utilSigo.toastWarning("Aviso", result.msj);
                }
            },
            error: function (err) {
                utilSigo.toastWarning("Aviso", "Sucedio un error, Comuníquese con el Administrador");
                console.log(err.statusText);
            }
        });
    } else {
        utilSigo.toastWarning("Aviso", "Sucedio un error, Comuníquese con el Administrador");
        console.log("FormData is not available in your browser");
    }
};

ManNotificacion_AddEdit.fnDownloadDocumentoAdjunto = function () {
    var estado = ManNotificacion_AddEdit.frm.find("#txtestadoArch").val();
    var nombreOriginal = ManNotificacion_AddEdit.frm.find("#txtnomArchOriginal").val();
    var fname = ManNotificacion_AddEdit.frm.find("#txtnomArchTemporal").val();
    var opcion = 5;
    if (parseInt(estado) != 0) {
        var iframe = document.createElement("iframe");
        //iframe.src = urlLocalSigo + "Fiscalizacion/FiscalizacionNotificacion/DescargarDocumentoAdjunto?nombreArchivo=" + fname + "&nombreOriginal=" + nombreOriginal;
        iframe.src = urlLocalSigo + "Tribunal/TribunalNotificacion2da/DescargarDocumentoAdjunto?nombreArchivo=" + fname + "&nombreOriginal=" + nombreOriginal;
        iframe.style.display = "none";
        $("#divIframe").html(iframe);
    }
    else {
        var nroDocumento = nombreOriginal.trim();

        if (nroDocumento != "") {
            nroDocumento = nroDocumento.replace(" ", "%20").replace("°", "%B0");

            document.location = "https://sitd.osinfor.gob.pe:8443/std/cInterfaseUsuario_SITD/download.php?direccion=//10.10.8.20/sitd-almacen/cAlmacenAnexos/&file=" + nroDocumento;
        }
    }
};

ManNotificacion_AddEdit.fnSaveForm = function () {
    let hdfCodNotificacion = ManNotificacion_AddEdit.frm.find("#hdfCodNotificacion").val();
    let hdfCodTipoNotificacion = ManNotificacion_AddEdit.frm.find("#hdfCodTipoNotificacion").val();
    let RegEstado = ManNotificacion_AddEdit.frm.find("#RegEstado").val();
    let ddlOdId = ManNotificacion_AddEdit.frm.find("#ddlOdId").val();
    let hdfCodNotificador = ManNotificacion_AddEdit.frm.find("#hdfCodNotificador").val();
    let txtNotificador = ManNotificacion_AddEdit.frm.find("#txtNotificador").val();
    let txtNumCarta = ManNotificacion_AddEdit.frm.find("#txtNumCarta").val();
    let txtFechaEmision = ManNotificacion_AddEdit.frm.find("#txtFechaEmision").val();
    let txtFechaRecepcion = ManNotificacion_AddEdit.frm.find("#txtFechaRecepcion").val();
    let txtFechaEntrega = ManNotificacion_AddEdit.frm.find("#txtFechaEntrega").val();
    let txtFechaNotificacion = ManNotificacion_AddEdit.frm.find("#txtFechaNotificacion").val();
    let txtFechaDevolucion = ManNotificacion_AddEdit.frm.find("#txtFechaDevolucion").val();
    let ddlEstadoCargoId = ManNotificacion_AddEdit.frm.find("#ddlEstadoCargoId").val();
    let chkPrimeraVisita = ManNotificacion_AddEdit.frm.find("#chkPrimeraVisita").prop("checked");
    let chkSegundaVisita = ManNotificacion_AddEdit.frm.find("#chkSegundaVisita").prop("checked");
    let txtFechaPVisita = ManNotificacion_AddEdit.frm.find("#txtFechaPVisita").val();
    let txtFechaSVisita = ManNotificacion_AddEdit.frm.find("#txtFechaSVisita").val();
    let radSituacion = ManNotificacion_AddEdit.frm.find('input:radio[name="radSituacion"]:checked').val();
    let ddlTitularId = ManNotificacion_AddEdit.frm.find("#ddlTitularId").val();
    let ddlEntidadId = ManNotificacion_AddEdit.frm.find("#ddlEntidadId").val();
    let txtParentesco = ManNotificacion_AddEdit.frm.find("#txtParentesco").val();
    let hdfCodNotificado = ManNotificacion_AddEdit.frm.find("#hdfCodNotificado").val();
    let txtNotificado = ManNotificacion_AddEdit.frm.find("#txtNotificado").val();
    let hdfUbigeo = ManNotificacion_AddEdit.frm.find("#hdfUbigeo").val();
    let txtUbigeo = ManNotificacion_AddEdit.frm.find("#txtUbigeo").val();
    let txtDireccion = ManNotificacion_AddEdit.frm.find("#txtDireccion").val();
    let chkActa = ManNotificacion_AddEdit.frm.find("#chkActa").prop("checked");
    let radMedidor = ManNotificacion_AddEdit.frm.find('input:radio[name="radMedidor"]:checked').val();
    let txtNumMedidor = ManNotificacion_AddEdit.frm.find("#txtNumMedidor").val();
    let txtMatFachada = ManNotificacion_AddEdit.frm.find("#txtMatFachada").val();
    let txtMatPuerta = ManNotificacion_AddEdit.frm.find("#txtMatPuerta").val();
    let txtNumPisos = ManNotificacion_AddEdit.frm.find("#txtNumPisos").val();
    let ddlZonaUtmId = ManNotificacion_AddEdit.frm.find("#ddlZonaUtmId").val();
    let txtCoordEste = ManNotificacion_AddEdit.frm.find("#txtCoordEste").val();
    let txtCoordNorte = ManNotificacion_AddEdit.frm.find("#txtCoordNorte").val();
    let txtTelefono = ManNotificacion_AddEdit.frm.find("#txtTelefono").val();
    let chkDeclaracionJurada = ManNotificacion_AddEdit.frm.find("#chkDeclaracionJurada").prop("checked");
    let txtCalleDJ = ManNotificacion_AddEdit.frm.find("#txtCalleDJ").val();
    let txtLugarDJ = ManNotificacion_AddEdit.frm.find("#txtLugarDJ").val();
    let hdfUbigeoDJ = ManNotificacion_AddEdit.frm.find("#hdfUbigeoDJ").val();
    let txtUbigeoDJ = ManNotificacion_AddEdit.frm.find("#txtUbigeoDJ").val();
    let txtReferenciaDJ = ManNotificacion_AddEdit.frm.find("#txtReferenciaDJ").val();
    let txtObservaciones = ManNotificacion_AddEdit.frm.find("#txtObservaciones").val();
    let txtDocAdjuntos = ManNotificacion_AddEdit.frm.find("#txtDocAdjuntos").val();
    let txtnomArchOriginal = ManNotificacion_AddEdit.frm.find("#txtnomArchOriginal").val();
    let txtnomArchTemporal = ManNotificacion_AddEdit.frm.find("#txtnomArchTemporal").val();
    let txtextArch = ManNotificacion_AddEdit.frm.find("#txtextArch").val();
    let txtestadoArch = ManNotificacion_AddEdit.frm.find("#txtestadoArch").val();
    let txtcCodificacionSiTD = ManNotificacion_AddEdit.frm.find("#txtcCodificacionSiTD").val();
    let hdfIdOrigenRegistro = ManNotificacion_AddEdit.frm.find("#hdfIdOrigenRegistro").val();
    let hdfCodigoNotificacionAlerta = ManNotificacion_AddEdit.frm.find("#hdfCodigoNotificacionAlerta").val();
    let chknotifTitular = ManNotificacion_AddEdit.frm.find("#chknotifTitular").val();
    let idTramiteSITD = ManNotificacion_AddEdit.frm.find("#idTramiteSITD").val();
    let chkactadispensa = ManNotificacion_AddEdit.frm.find("#chkactadispensa").val();
    let chkdjcambiodomicilio = ManNotificacion_AddEdit.frm.find("#chkdjcambiodomicilio").val();

    let model = {
        hdfCodNotificacion, hdfCodTipoNotificacion, RegEstado, ddlOdId, hdfCodNotificador, txtNotificador, txtNumCarta, txtFechaEmision, txtFechaRecepcion,
        txtFechaEntrega, txtFechaNotificacion, txtFechaDevolucion, ddlEstadoCargoId, chkPrimeraVisita, chkSegundaVisita, txtFechaPVisita, txtFechaSVisita,
        radSituacion, ddlTitularId, ddlEntidadId, txtParentesco, hdfCodNotificado, txtNotificado, hdfUbigeo, txtUbigeo, txtDireccion, chkActa, radMedidor,
        txtNumMedidor, txtMatFachada, txtMatPuerta, txtNumPisos, ddlZonaUtmId, txtCoordEste, txtCoordNorte, txtTelefono, chkDeclaracionJurada, txtCalleDJ,
        txtLugarDJ, hdfUbigeoDJ, txtUbigeoDJ, txtReferenciaDJ, txtObservaciones, txtDocAdjuntos, txtnomArchOriginal, txtnomArchTemporal, txtextArch,
        txtestadoArch, txtcCodificacionSiTD, hdfIdOrigenRegistro, hdfCodigoNotificacionAlerta, chknotifTitular, idTramiteSITD, chkactadispensa, chkdjcambiodomicilio
    }
    model.vmControlCalidad = _ControlCalidad.fnGetDatosControlCalidad();
    model.tbInforme = _renderListExpediente.fnGetList();
    model.tbEliTABLA = _renderListExpediente.fnGetListEliTABLA();

    var falta = ManNotificacion_AddEdit.fnValidarAtributos(model);

    if (falta != "") {
        utilSigo.toastWarning("Aviso", falta);
    }
    else {
        utilSigo.dialogConfirm("", "Está seguro registrar los datos?", function (r) {
            if (r) {
                //let url = urlLocalSigo + "Fiscalizacion/FiscalizacionNotificacion/Grabar";
                let url = urlLocalSigo + "Tribunal/TribunalNotificacion2da/Grabar";
                let option = { url: url, datos: JSON.stringify(model), type: 'POST' };
                utilSigo.fnAjax(option, function (data) {
                    if (data.success) {
                        //window.location = `${urlLocalSigo}/Fiscalizacion/FiscalizacionNotificacion/Index`;
                        window.location = `${urlLocalSigo}/Tribunal/TribunalNotificacion2da/Index`;
                        utilSigo.toastSuccess("Éxito", "Datos actualizados correctamente");
                    }
                    else {
                        utilSigo.toastWarning("Aviso", data.msj);
                    }
                });
            }
        });
    }
};

ManNotificacion_AddEdit.fnValidarAtributos = function (obj) {
    var falta = "", band = 0;

    if (obj.vmControlCalidad.ddlIndicadorId == "0000000") {
        falta = "Debe seleccionar la situación actual de su registro";
        band = 1;
    }
    if (band == 0) {
        if (obj.ddlOdId == "0000000") {
            falta = "Debe seleccionar la O.D. desde donde se registra la información";
            band = 1;
        }
    }
    if (band == 0) {
        if (obj.txtNumCarta.trim() == "") {
            falta = "Ingrese Número de la notificación";
            band = 1;
        }
    }
    if (band == 0) {
        if (obj.txtFechaNotificacion.trim() == "") {
            falta = "Ingrese fecha de notificación al titular";
            band = 1;
        }
    }
    if (band == 0) {
        if ((/true/i).test(ManNotificacion_AddEdit.frm.find("#chknotifTitular").val()) == true){
            if (obj.ddlEstadoCargoId == "0") {
                falta = "Debe seleccionar estado del cargo";
                band = 1;
            }
            if (band == 0) {
                if (ManNotificacion_AddEdit.frm.find("#chkPrimeraVisita").is(":checked")) {
                    if (obj.txtFechaPVisita.trim() == "") {
                        falta = "Ingrese fecha de primera visita";
                        band = 1;
                    }
                }
            }
            if (band == 0) {
                if (ManNotificacion_AddEdit.frm.find("#chkSegundaVisita").is(":checked")) {
                    if (obj.txtFechaSVisita.trim() == "") {
                        falta = "Ingrese fecha de segunda visita";
                        band = 1;
                    }
                }
            }
            if (band == 0) {
                if (ManNotificacion_AddEdit.frm.find("#chkDeclaracionJurada").is(":checked")) {
                    if (obj.txtCalleDJ.trim() == "") {
                        falta = "Ingrese Dirección";
                        band = 1;
                    }
                    if (obj.txtCalleDJ.trim() == "" && band == 0) {
                        falta = "Ingrese Dirección";
                        band = 1;
                    }
                }
            }
            if (band == 0) {
                if (obj.ddlZonaUtmId != "0") {
                    if (obj.txtCoordEste.trim() == "" || obj.txtCoordNorte.trim() == "") {
                        falta = "Falta ingresar los campos Coordenada Este y Norte";
                        band = 1;
                    }
                }
            }
            if (band == 0) {
                if (obj.txtCoordEste.trim() != "" || obj.txtCoordNorte.trim() != "") {
                    if (obj.txtCoordEste.trim() != "" && obj.txtCoordNorte.trim() != "") {
                        if (obj.ddlZonaUtmId == "0") {
                            falta = "Falta seleccionar Zona UTM";
                            band = 1;
                        }
                    }
                    else {
                        if (obj.ddlZonaUtmId == "0") {
                            falta = "Falta seleccionar Zona UTM";
                            band = 1;
                        }
                    }
                }
            }
        }
    }

    return falta;
};

ManNotificacion_AddEdit.fnHabilitarFecha = function (elemento, campo) {
    var valor = ManNotificacion_AddEdit.frm.find(elemento).prop("checked");

    if (valor == true) ManNotificacion_AddEdit.frm.find(campo).prop("disabled", false);
    else ManNotificacion_AddEdit.frm.find(campo).prop("disabled", true);
};

ManNotificacion_AddEdit.fnHabilitarComponentes = function (valor) {
    if (valor == 1) {
        ManNotificacion_AddEdit.frm.find("#ddlTitularId").prop("disabled", false);
        $("#divNotificado").show();
    } else {
        ManNotificacion_AddEdit.frm.find("#ddlTitularId").val("0000000");
        ManNotificacion_AddEdit.frm.find("#ddlTitularId").prop("disabled", true);
        ManNotificacion_AddEdit.frm.find("#hdfCodNotificado").val("");
        ManNotificacion_AddEdit.frm.find("#txtNotificado").val("");
        ManNotificacion_AddEdit.frm.find("#hdTipoNotificado").val("");
        $("#divNotificado").hide();
    }
};

ManNotificacion_AddEdit.fnHabilitarCamposDJ = function (valor) {
    if (valor == true) {
        $("#divLugarDJ").show();
        $("#divUbigeoDJ").show();
    } else {
        ManNotificacion_AddEdit.frm.find("#txtCalleDJ").val("");
        ManNotificacion_AddEdit.frm.find("#txtLugarDJ").val("");
        ManNotificacion_AddEdit.frm.find("#txtUbigeoDJ").val("");
        ManNotificacion_AddEdit.frm.find("#hdfUbigeoDJ").val("");
        ManNotificacion_AddEdit.frm.find("#txtReferenciaDJ").val("");
        $("#divLugarDJ").hide();
        $("#divUbigeoDJ").hide();
    }
};

ManNotificacion_AddEdit.fnHabilitarParentesco = function (valor) {
    if (valor == "0000019") {
        $("#divParentesco").show();
    } else {
        ManNotificacion_AddEdit.frm.find("#txtParentesco").val("");
        $("#divParentesco").hide();
    }
};

$(document).ready(function () {
    ManNotificacion_AddEdit.frm = $("#frmNotificacionRegistro");
    ManNotificacion_AddEdit.iniciarEventos();  

    ManNotificacion_AddEdit.frm.find("#chkPrimeraVisita").change(function () {
        ManNotificacion_AddEdit.fnHabilitarFecha("#chkPrimeraVisita", "#txtFechaPVisita");
    });

    ManNotificacion_AddEdit.frm.find("#txtFechaPVisita").change(function () {
        ManNotificacion_AddEdit.frm.find("#txtFechaNotificacion").val(ManNotificacion_AddEdit.frm.find("#txtFechaPVisita").val());
    });

    ManNotificacion_AddEdit.frm.find("#chkSegundaVisita").change(function () {
        ManNotificacion_AddEdit.fnHabilitarFecha("#chkSegundaVisita", "#txtFechaSVisita");
    });

    ManNotificacion_AddEdit.frm.find("#txtFechaSVisita").change(function () {
        ManNotificacion_AddEdit.frm.find("#txtFechaNotificacion").val(ManNotificacion_AddEdit.frm.find("#txtFechaSVisita").val());
    });

    ManNotificacion_AddEdit.frm.find('input:radio[name="radSituacion"]').change(function () {
        ManNotificacion_AddEdit.fnHabilitarComponentes(ManNotificacion_AddEdit.frm.find(this).val());
    });

    ManNotificacion_AddEdit.frm.find("#chkDeclaracionJurada").change(function () {
        ManNotificacion_AddEdit.fnHabilitarCamposDJ(ManNotificacion_AddEdit.frm.find(this).prop("checked"));
    });

    ManNotificacion_AddEdit.frm.find("#ddlTitularId").change(function () {
        ManNotificacion_AddEdit.fnHabilitarParentesco(ManNotificacion_AddEdit.frm.find(this).val());
    });
});
