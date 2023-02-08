"use strict";
var ManNotificacion_AddEdit = {};
/*Variables globales*/
ManNotificacion_AddEdit.tbEliTABLA = [];
ManNotificacion_AddEdit.selectFile = null;
ManNotificacion_AddEdit.DataPoa = [];
ManNotificacion_AddEdit.DataDevMad = [];

ManNotificacion_AddEdit.fnLoadData = function (obj, tipo) {
    switch (tipo) {
        case "DataPoa": ManNotificacion_AddEdit.DataPoa = JSON.parse(obj); break;
        case "DataDevMad": ManNotificacion_AddEdit.DataDevMad = JSON.parse(obj); break;
    }
}

ManNotificacion_AddEdit.fnReturnIndex = function (alertaInicial) {
    var url = urlLocalSigo + "Notificacion/ManNotificacion/Index";

    if (alertaInicial == null || alertaInicial == "") {
        window.location = url;
    } else {
        window.location = url + "?_alertaIncial=" + alertaInicial;
    }
}

ManNotificacion_AddEdit.fnBuscarPersona = function (_dom, _tipoPersonaSIGOsfc) {
    var url = urlLocalSigo + "General/Controles/_BuscarPersonaGeneral";
    var option = { url: url, type: 'GET', datos: { asBusGrupo: "PERSONA", asCodPTipo: _tipoPersonaSIGOsfc, asTipoPersona: "N" }, divId: "mdlBuscarPersona" };
    utilSigo.fnOpenModal(option, function () {
        _bPerGen.fnAsignarDatos = function (obj) {
            if (obj != null && obj != "") {
                var data = _bPerGen.dtBuscarPerona.row($(obj).parents('tr')).data();
                switch (_dom) {
                    case "NOTIFICADOR":
                        ManNotificacion_AddEdit.frm.find("#hdfCodNotificador").val(data["COD_PERSONA"]);
                        ManNotificacion_AddEdit.frm.find("#lblNotificador").val(data["PERSONA"]);
                        break;
                    case "RECIBE_NOTIFICA":
                        ManNotificacion_AddEdit.frm.find("#hdfCodPersonaRecibe").val(data["COD_PERSONA"]);
                        ManNotificacion_AddEdit.frm.find("#lblPersonaRecibe").val(data["PERSONA"]);
                        break;
                }
                utilSigo.fnCloseModal("mdlBuscarPersona");
            }
        }
        _bPerGen.fnInit();
    });
}
ManNotificacion_AddEdit.fnViewModalUbigeo = function (tipo) {
    var url = initSigo.urlControllerGeneral + "_Ubigeo";
    var option = { url: url, type: 'POST', datos: {}, divId: "mdlManNotificacion_Global" };
    utilSigo.fnOpenModal(option, function () {
        switch (tipo) {
            case "UBIGEO":
                _Ubigeo.fnSelectUbigeo = function (_ubigeoText, _ubigeoId) {
                    ManNotificacion_AddEdit.frm.find("#hdfCodUbigeo").val(_ubigeoId);
                    ManNotificacion_AddEdit.frm.find("#lblUbigeo").val(_ubigeoText);
                    $("#mdlManNotificacion_Global").modal('hide');
                }
                _Ubigeo.fnLoadModalView(ManNotificacion_AddEdit.frm.find("#hdfCodUbigeo").val());
                break;
            case "UBIGEO_CAMBIO":
                _Ubigeo.fnSelectUbigeo = function (_ubigeoText, _ubigeoId) {
                    ManNotificacion_AddEdit.frm.find("#hdfCodUbigeoCambio").val(_ubigeoId);
                    ManNotificacion_AddEdit.frm.find("#lblUbigeoCambio").val(_ubigeoText);
                    $("#mdlManNotificacion_Global").modal('hide');
                }
                _Ubigeo.fnLoadModalView(ManNotificacion_AddEdit.frm.find("#hdfCodUbigeoCambio").val());
                break;
        }
    }
);
}
ManNotificacion_AddEdit.fnViewModalTHabilitante = function () {
    if (ManNotificacion_AddEdit.frm.find("#ddlTipoCNotificacionId").val() != "0000002") {
        if (ManNotificacion_AddEdit.frm.find("#lstChkTipoSupervisionId").val() == "") {
            utilSigo.toastWarning("Aviso", "Seleccione el tipo de supervisión primero"); return false;
        }
    }

    var url = initSigo.urlControllerGeneral + "_THabilitante";
    var option = { url: url, type: 'GET', datos: { hdfFormulario: "TITULO_HABILITANTE" }, divId: "mdlManNotificacion_Global" };
    utilSigo.fnOpenModal(option, function () {
        vpTHabilitante.fnAsignarDatos = function (obj) {
            if (obj != null && obj != "") {
                var data = vpTHabilitante.dtTituloHabilitante.row($(obj).parents('tr')).data();
                ManNotificacion_AddEdit.frm.find("#hdfCodTHabilitante").val(data["CODIGO"]);
                ManNotificacion_AddEdit.frm.find("#lblTHabilitante").val(data["NUMERO"]);
                $("#mdlManNotificacion_Global").modal('hide');
            }
        }

        vpTHabilitante.fnInit_v2();
    }, ManNotificacion_AddEdit.fnCustomValidateForm);
}
ManNotificacion_AddEdit.fnViewModalCNotificacion = function () {
    if (ManNotificacion_AddEdit.frm.find("#hdfCodTHabilitante").val() == "") {
        utilSigo.toastWarning("Aviso", "Seleccione el título habilitante primero"); return false;
    }

    var url = "", sFormulario = "MODAL_NOTIFICACION", sCriterio = "FN_COD_THABILITANTE", sValor = ManNotificacion_AddEdit.frm.find("#hdfCodTHabilitante").val();
    url = initSigo.urlControllerGeneral + "_CNotificacion";
    var option = { url: url, type: 'POST', datos: { asFormulario: sFormulario, asCriterio: sCriterio, asValor: sValor, asTipo: "0000172,0000173" }, divId: "mdlManNotificacion_Global" };
    utilSigo.fnOpenModal(option, function () {
        _CNotificacion.fnAsignarDatos = function (obj) {
            if (obj != null && obj != "") {
                var data = _CNotificacion.dtCNotificacion.row($(obj).parents('tr')).data();
                ManNotificacion_AddEdit.frm.find("#hdfCodCNotificacionRef").val(data["COD_FISNOTI"]);
                var numCN = data["NUM_NOTIFICACION"] + " (" + data["FCTIPO"] + ")";
                ManNotificacion_AddEdit.frm.find("#lblCNotificacionRef").val(numCN);
                $("#mdlManNotificacion_Global").modal('hide');
            }
        }
        _CNotificacion.fnInit();
    });
}
ManNotificacion_AddEdit.fnViewModalPOA = function () {
    if (ManNotificacion_AddEdit.frm.find("#hdfCodTHabilitante").val() == "") {
        utilSigo.toastWarning("Aviso", "Seleccione el título habilitante primero"); return false;
    }

    var url = "", sFormulario = "TITULO_HABILITANTE", sCriterio = "CN_DEV_POA_PMANEJO", sValor = ManNotificacion_AddEdit.frm.find("#hdfCodTHabilitante").val();
    url = initSigo.urlControllerGeneral + "_POA";
    var option = { url: url, type: 'POST', datos: { asFormulario: sFormulario, asCriterio: sCriterio, asValor: sValor }, divId: "mdlManNotificacion_Global" };
    utilSigo.fnOpenModal(option, function () {
        _POA.fnAsignarDatos = function (obj) {
            if (obj != null && obj != "") {
                var data = _POA.dtPOA.row($(obj).parents('tr')).data();

                if (!utilDt.existValorSearch(ManNotificacion_AddEdit.dtPoaPo_Dema, "NUM_POA", data["NUM_POA"])) {
                    data["NUM_MUESTRA"] = 1;
                    data["RegEstado"] = 1;
                    ManNotificacion_AddEdit.dtPoaPo_Dema.rows.add([data]).draw(false);
                    $("#mdlManNotificacion_Global").modal('hide');
                } else {
                    utilSigo.toastWarning("Aviso", "El POA/PO | DEMA ya existe");
                }
            }
        }
        _POA.fnInit();
    });
}
ManNotificacion_AddEdit.fnViewModalDevolMadera = function () {
    if (ManNotificacion_AddEdit.frm.find("#hdfCodTHabilitante").val() == "") {
        utilSigo.toastWarning("Aviso", "Seleccione el título habilitante primero"); return false;
    }

    var url = "", sFormulario = "", sCriterio = "", sValor = ManNotificacion_AddEdit.frm.find("#hdfCodTHabilitante").val();
    url = initSigo.urlControllerGeneral + "_DevolucionMadera";
    var option = { url: url, type: 'POST', datos: { asFormulario: sFormulario, asCriterio: sCriterio, asValor: sValor }, divId: "mdlManNotificacion_Global" };
    utilSigo.fnOpenModal(option, function () {
        _DevolucionMadera.fnAsignarDatos = function (obj) {
            if (obj != null && obj != "") {
                var data = _DevolucionMadera.dtDevolucionMadera.row($(obj).parents('tr')).data();

                if (!utilDt.existValorSearch(ManNotificacion_AddEdit.dtDevolMadera, "COD_DEVOLUCION", data["COD_DEVOLUCION"])) {
                    data["RegEstado"] = 1;
                    ManNotificacion_AddEdit.dtDevolMadera.rows.add([data]).draw(false);
                    $("#mdlManNotificacion_Global").modal('hide');
                } else {
                    utilSigo.toastWarning("Aviso", "La Devolución de Madera ya existe");
                }
            }
        }
        _DevolucionMadera.fnInit();
    });
}

ManNotificacion_AddEdit.fnInit = function () {
    $.fn.select2.defaults.set("theme", "bootstrap4");
    ManNotificacion_AddEdit.frm.find("#ddlOdId").select2();
    ManNotificacion_AddEdit.frm.find("#ddlEstadoCargoId").select2({ minimumResultsForSearch: -1 });
    ManNotificacion_AddEdit.frm.find("#ddlParentescoId").select2();
    ManNotificacion_AddEdit.frm.find("#ddlFEntidadId").select2();
    ManNotificacion_AddEdit.frm.find("#ddlZonaId").select2({ minimumResultsForSearch: -1 });
    ManNotificacion_AddEdit.frm.find("#ddlMesSupervisionId").select2();

    utilSigo.fnFormatDate(ManNotificacion_AddEdit.frm.find("#txtFecEmision"));
    utilSigo.fnFormatDate(ManNotificacion_AddEdit.frm.find("#txtFecRecepcionOd"));
    utilSigo.fnFormatDate(ManNotificacion_AddEdit.frm.find("#txtFecEntregaNft"));
    utilSigo.fnFormatDate(ManNotificacion_AddEdit.frm.find("#txtFecNotificacion"));
    utilSigo.fnFormatDate(ManNotificacion_AddEdit.frm.find("#txtFecDevolSec"));
    utilSigo.fnFormatDate(ManNotificacion_AddEdit.frm.find("#txtFecPrimeraVisita"));
    utilSigo.fnFormatDate(ManNotificacion_AddEdit.frm.find("#txtFecSegundaVisita"));
    utilSigo.fnFormatDate(ManNotificacion_AddEdit.frm.find("#txtFecSupervision"));

    var cod_tnotif=ManNotificacion_AddEdit.frm.find("#hdfCodTipoNotificacion").val();

    ManNotificacion_AddEdit.frm.find(".dvDatosTitular").hide();
    ManNotificacion_AddEdit.frm.find(".dvDatosEntidad").hide();
    if (ManNotificacion_AddEdit.frm.find("#hdfNotifTitular").val()!='True') {
        ManNotificacion_AddEdit.frm.find("#lblNumNotificacion").text('N° Oficio de Notificación');
        ManNotificacion_AddEdit.frm.find("#txtFecNotificacion").prop('disabled', false);
        ManNotificacion_AddEdit.frm.find("#lblNotifDestino").text('Notificación a otras entidades');
        ManNotificacion_AddEdit.frm.find(".dvDatosEntidad").show();
    } else {
        if (cod_tnotif == '0000174') {
            ManNotificacion_AddEdit.frm.find("#lblNotifDestino").text('Notificación al regente');
        }
        ManNotificacion_AddEdit.frm.find(".dvDatosTitular").show();

        ManNotificacion_AddEdit.frm.find("#dvCNotificacionReferencia").hide();
        ManNotificacion_AddEdit.frm.find("#dvTipoSupervision").hide();
        if (cod_tnotif == "0000173") {//Reprogramación de supervisión
            ManNotificacion_AddEdit.frm.find("#dvCNotificacionReferencia").show();
        } else {
            ManNotificacion_AddEdit.frm.find("#dvTipoSupervision").show();
        }
    }

    var lstDetInf = "0000028|0000029|0000121";
    var lstDetExp = "0000037";
    var lstDetRes = "0000080|0000037|0000034|0000132|0000031|0000117|0000116|0000114|0000035|0000030|0000036|0000033|0000032|0000115|0000128";
    var lstDetIle = "0000109|0000110";
    var lstDetPoa = "0000172|0000173|0000174";

    if (lstDetInf.includes(cod_tnotif)) {
        ManNotificacion_AddEdit.frm.find("#dvRenderListInforme").show();
    }
    if (lstDetExp.includes(cod_tnotif)) {
        ManNotificacion_AddEdit.frm.find("#dvRenderListExpediente").show();
    }
    if (lstDetRes.includes(cod_tnotif)) {
        ManNotificacion_AddEdit.frm.find("#dvRenderListResolucion").show();
    }
    if (lstDetIle.includes(cod_tnotif)) {
        ManNotificacion_AddEdit.frm.find("#dvRenderListILegal").show();
    }
    ManNotificacion_AddEdit.frm.find("#lnkNavSupervision").hide();
    if (lstDetPoa.includes(cod_tnotif)) {
        ManNotificacion_AddEdit.frm.find("#lnkNavSupervision").show();
    }

    if (ManNotificacion_AddEdit.frm.find("#radListRecepcionId").val()!="") {
        ManNotificacion_AddEdit.frm.find("input[name=radListRecepcion][value=" + ManNotificacion_AddEdit.frm.find("#radListRecepcionId").val() + "]").prop('checked', 'checked');
    }
    if (ManNotificacion_AddEdit.frm.find("#radListMedidorId").val() != "") {
        ManNotificacion_AddEdit.frm.find("input[name=radListMedidor][value=" + ManNotificacion_AddEdit.frm.find("#radListMedidorId").val() + "]").prop('checked', 'checked');
    }

    ManNotificacion_AddEdit.frm.find("#btnDescargarCargo").hide();
    if (ManNotificacion_AddEdit.frm.find("#txtDocumentoCargo").val() != "") {
        ManNotificacion_AddEdit.frm.find("#lblDocumentoCargoField").text(ManNotificacion_AddEdit.frm.find("#txtDocumentoCargo").val());
        ManNotificacion_AddEdit.frm.find("#btnDescargarCargo").show();
    }
}

ManNotificacion_AddEdit.fnSubmitForm = function () {
    var controls = ["ddlIndicadorId", "ddlOdId", "ddlTipoCNotificacionId", "txtNumCNotificacion"];
    if (!utilSigo.fnValidateForm(ManNotificacion_AddEdit.frm, controls)) {
        return ManNotificacion_AddEdit.frm.valid();
    }

    var cod_tnotif = ManNotificacion_AddEdit.frm.find("#hdfCodTipoNotificacion").val();
    var cod_fctipo_coactiva = "0000133|0000134|0000135|0000136|0000137|0000138|0000139|0000140|0000141|0000142|0000143|0000144|0000145|0000146|0000147|0000148|0000149|0000150|0000151|0000152|0000153|0000154|0000155|0000156|0000157|0000158|0000159|0000160|0000161|0000162|0000163|0000164|0000165|0000166|0000167|0000168|0000169|0000170|0000171";

    if (!cod_fctipo_coactiva.includes(cod_tnotif)) {
        if (cod_tnotif == "0000172")//Carta de supervisión
        {
            switch (ManNotificacion_AddEdit.frm.find("#lstChkTipoSupervisionId").val()) {
                case "P":
                    if (ManNotificacion_AddEdit.fnGetListPoaPo_DemaCount() == 0) { utilSigo.toastWarning("Aviso", "Seleccione el POA/PO | DEMA"); return false; }
                    break;
                case "PM":
                case "TH":
                    break;
                case "DM":
                    if (ManNotificacion_AddEdit.fnGetListDevolMaderaCount() == 0) { utilSigo.toastWarning("Aviso", "Seleccione la Devolución de Madera"); return false; }
                    break;
                default: utilSigo.toastWarning("Aviso", "Debe seleccionar un tipo de supervisión"); return false;
            }
        } else if (cod_tnotif == "0000173" || cod_tnotif == "0000174") {//Carta de reprogramación de supervisión y notificación al regente

        } else {
            var nroDocAsociado = 0;
            nroDocAsociado += _renderListInforme.fnGetCount()
            nroDocAsociado += _renderListExpediente.fnGetCount()
            nroDocAsociado += _renderListResolucion.fnGetCount()
            nroDocAsociado += _renderListILegal.fnGetCount()
            if (nroDocAsociado == 0) {
                utilSigo.toastWarning("Aviso", "Es necesario asociar al menos un documento (informe, expediente, resolución u otros) a la notificación");
                return false;
            }
        }
    }

    ManNotificacion_AddEdit.frm.submit();
}

ManNotificacion_AddEdit.fnSaveForm = function () {
    var datosNotificacion = ManNotificacion_AddEdit.frm.serializeObject();
    datosNotificacion.vmControlCalidad = _ControlCalidad.fnGetDatosControlCalidad();
    datosNotificacion.chkPrimeraVisita = utilSigo.fnGetValChk(ManNotificacion_AddEdit.frm.find("#chkPrimeraVisita"));
    datosNotificacion.chkSegundaVisita = utilSigo.fnGetValChk(ManNotificacion_AddEdit.frm.find("#chkSegundaVisita"));
    datosNotificacion.radListRecepcionId = ManNotificacion_AddEdit.frm.find("input[name=radListRecepcion]:checked").val();
    datosNotificacion.chkActaNotifAdm = utilSigo.fnGetValChk(ManNotificacion_AddEdit.frm.find("#chkActaNotifAdm"));
    datosNotificacion.radListMedidorId = ManNotificacion_AddEdit.frm.find("input[name=radListMedidor]:checked").val();
    datosNotificacion.chkCambioDomicilio = utilSigo.fnGetValChk(ManNotificacion_AddEdit.frm.find("#chkCambioDomicilio"));
    datosNotificacion.chkCoincideDireccion = utilSigo.fnGetValChk(ManNotificacion_AddEdit.frm.find("#chkCoincideDireccion"));

    datosNotificacion.tbEliTABLA = ManNotificacion_AddEdit.tbEliTABLA;
    datosNotificacion.tbInforme = _renderListInforme.fnGetList();
    datosNotificacion.tbEliTABLA = datosNotificacion.tbEliTABLA.concat(_renderListInforme.fnGetListEliTABLA());
    datosNotificacion.tbExpediente = _renderListExpediente.fnGetList();
    datosNotificacion.tbEliTABLA = datosNotificacion.tbEliTABLA.concat(_renderListExpediente.fnGetListEliTABLA());
    datosNotificacion.tbResolucion = _renderListResolucion.fnGetList();
    datosNotificacion.tbEliTABLA = datosNotificacion.tbEliTABLA.concat(_renderListResolucion.fnGetListEliTABLA());
    datosNotificacion.tbILegal = _renderListILegal.fnGetList();
    datosNotificacion.tbEliTABLA = datosNotificacion.tbEliTABLA.concat(_renderListILegal.fnGetListEliTABLA());
    datosNotificacion.tbPoa = ManNotificacion_AddEdit.fnGetListPoaPo_Dema();
    datosNotificacion.tbDevolucionMadera = ManNotificacion_AddEdit.fnGetListDevolMadera();

    var option = { url: ManNotificacion_AddEdit.frm.action, datos: JSON.stringify(datosNotificacion), type: 'POST' };
    utilSigo.fnAjax(option, function (data) {
        if (data.success) {
            ManNotificacion_AddEdit.fnReturnIndex(data.msj);
        }
        else {
            utilSigo.toastWarning("Aviso", data.msj);
        }
    });
}

ManNotificacion_AddEdit.fnEnableFechaPrimeraVisita = function () {
    ManNotificacion_AddEdit.frm.find("#txtFecPrimeraVisita").prop("disabled", true);
    if (ManNotificacion_AddEdit.frm.find("#chkPrimeraVisita").is(":checked")) {
        ManNotificacion_AddEdit.frm.find("#txtFecPrimeraVisita").prop("disabled", false);
    }
}
ManNotificacion_AddEdit.fnEnableFechaSegundaVisita = function () {
    ManNotificacion_AddEdit.frm.find("#txtFecSegundaVisita").prop("disabled", true);
    if (ManNotificacion_AddEdit.frm.find("#chkSegundaVisita").is(":checked")) {
        ManNotificacion_AddEdit.frm.find("#txtFecSegundaVisita").prop("disabled", false);
    }
}
//ManNotificacion_AddEdit.fnShowPersonaRecibeNotif = function () {
//    if (ManNotificacion_AddEdit.frm.find("#hdfNotifTitular").val() == 'True') {
//        ManNotificacion_AddEdit.frm.find(".dvDatosPersonaRecibeNotif").hide();
//        if (ManNotificacion_AddEdit.frm.find("input[name=radListRecepcion]:checked").val()=="1") {
//            ManNotificacion_AddEdit.frm.find(".dvDatosPersonaRecibeNotif").show();
//        }
//    }
//}
ManNotificacion_AddEdit.fnShowParentesco = function () {
    if (ManNotificacion_AddEdit.frm.find("#hdfNotifTitular").val() == 'True') {
        ManNotificacion_AddEdit.frm.find("#dvDatosParentesco").hide();
        if (ManNotificacion_AddEdit.frm.find("#ddlParentescoId").val() == "0000019") {//Otros
            ManNotificacion_AddEdit.frm.find("#dvDatosParentesco").show();
        }
    }
}
ManNotificacion_AddEdit.fnShowCambioDomicilio = function () {
    if (ManNotificacion_AddEdit.frm.find("#hdfNotifTitular").val() == 'True') {
        ManNotificacion_AddEdit.frm.find(".dvDatosCambioDomicilio").hide();
        if (ManNotificacion_AddEdit.frm.find("#chkCambioDomicilio").is(":checked")) {
            ManNotificacion_AddEdit.frm.find(".dvDatosCambioDomicilio").show();
        }
    }
}

ManNotificacion_AddEdit.fnSelectCargo = function (e, obj) {
    var idFile = $(obj).attr("id");
    var files = e.target.files || e.dataTransfer.files;

    if (files != undefined && files.length > 0) {
        //Validar extensión archivo seleccionado
        var extension = files[0].name.substr((files[0].name.lastIndexOf('.') + 1));
        var extensiones_no_permitidas = "exe,bin,bat,run";

        if (!extensiones_no_permitidas.includes(extension)) {
            //Validar el tamaño del archivo
            var fileSize = parseFloat(files[0].size);
            if ((fileSize / 1048576) > 8) //4MB permitido por foto
            {
                utilSigo.toastError("Error", "El tamaño del archivo supera los 4MB permitidos"); return false;
            } else {
                $("#" + idFile).next().text(files[0].name);
                ManNotificacion_AddEdit.selectFile = files[0];
                ManNotificacion_AddEdit.frm.find("#btnDescargarCargo").hide();
            }
        } else {
            utilSigo.toastError("Error", "La extensión ." + extension + " no esta permitida"); return false;
        }
    }
}
ManNotificacion_AddEdit.fnSaveCargo = function () {
    utilSigo.dialogConfirm('', 'Desea registrar cargo y subir el archivo?', function (r) {
        if (r) {
            var cod_notificacion = ManNotificacion_AddEdit.frm.find("#hdfCodNotificacion").val();
            var codificacion_sitd = ManNotificacion_AddEdit.frm.find("#hdfCodificacionSITD").val();
            if ((typeof cod_notificacion === 'undefined' || cod_notificacion == "")) {
                utilSigo.toastWarning("Aviso", "Primero debe registrar la notificación para luego poder subir el cargo"); return false;
            }
            if ((typeof codificacion_sitd === 'undefined' || codificacion_sitd.trim() == "")) {
                utilSigo.toastError("Error", "La notificación no se encuentra asociada a un trámite SITD"); return false;
            }
            if (ManNotificacion_AddEdit.selectFile == null) {
                utilSigo.toastWarning("Aviso", "Seleccione el cargo a subir"); return false;
            }

            // Checking whether FormData is available in browser  
            if (window.FormData !== undefined) {
                var fileData = new FormData();
                var url = urlLocalSigo + "Notificacion/ManNotificacion/GrabarDocumentoCargo";

                fileData.append("cod_notificacion", cod_notificacion);
                fileData.append("codificacion_sitd", codificacion_sitd);
                fileData.append(ManNotificacion_AddEdit.selectFile.name, ManNotificacion_AddEdit.selectFile);

                utilSigo.blockUIGeneral();
                $.ajax({
                    url: url,
                    type: "POST",
                    contentType: false, // Not to set any content header  
                    processData: false, // Not to process data  
                    data: fileData,
                    success: function (result) {
                        if (result.success) {
                            ManNotificacion_AddEdit.frm.find("#txtDocumentoCargo").val(result.data.DOCUMENTO_CARGO);
                            if (ManNotificacion_AddEdit.frm.find("#txtDocumentoCargo").val() != "") {
                                ManNotificacion_AddEdit.frm.find("#lblDocumentoCargoField").text(result.data.DOCUMENTO_CARGO);
                                ManNotificacion_AddEdit.frm.find("#btnDescargarCargo").show();
                            }

                            ManNotificacion_AddEdit.selectFile = null;
                            utilSigo.toastSuccess("Éxito", result.msj);
                        }
                        else {
                            ManNotificacion_AddEdit.frm.find("#lblDocumentoCargoField").text("");
                            ManNotificacion_AddEdit.selectFile = null;
                            utilSigo.toastWarning("Aviso", result.msj);
                        }
                        utilSigo.unblockUIGeneral();
                    },
                    error: function (err) {
                        utilSigo.toastWarning("Aviso", "Sucedio un error, Comuníquese con el Administrador");
                        console.log(err.statusText);
                        utilSigo.unblockUIGeneral();
                    }
                });
            } else {
                utilSigo.toastWarning("Aviso", "Sucedio un error, Comuníquese con el Administrador");
                console.log("FormData is not available in your browser");
            }
        }
    });
}
ManNotificacion_AddEdit.fnDownloadCargo = function () {
    if (ManNotificacion_AddEdit.frm.find("#txtDocumentoCargo").val() != "") {
        document.location = "https://sitd.osinfor.gob.pe:8443/std/cInterfaseUsuario_SITD/download.php?direccion=//10.10.8.20/sitd-almacen/cAlmacenArchivos/&file=" + ManNotificacion_AddEdit.frm.find("#txtDocumentoCargo").val();
    }
}

ManNotificacion_AddEdit.fnClearAllCheckTipoSupervision = function () {
    for (var i = 1; i <= ManNotificacion_AddEdit.frm.find("[id*=lstChkTipoSupervision]").length; i++) {
        if (i % 2 == 0)
            ManNotificacion_AddEdit.frm.find("[id*=lstChkTipoSupervision]")[i - 1].checked = false;
    }
}
ManNotificacion_AddEdit.fnGetTipoSupervisionSelect = function () {
    ManNotificacion_AddEdit.frm.find("#lstChkTipoSupervisionId").val("");
    for (var i = 1; i <= ManNotificacion_AddEdit.frm.find("[id*=lstChkTipoSupervision]").length; i++) {
        if (i % 2 == 0) {
            if (ManNotificacion_AddEdit.frm.find("[id*=lstChkTipoSupervision]")[i - 1].checked) {
                ManNotificacion_AddEdit.frm.find("#lstChkTipoSupervisionId").val(ManNotificacion_AddEdit.frm.find("[id*=lstChkTipoSupervision]")[i - 2].value);
            }
        }
    }
}
ManNotificacion_AddEdit.fnCustomValidateForm = function () {
    if (!utilSigo.fnValidateForm_HideControl(ManNotificacion_AddEdit.frm, ManNotificacion_AddEdit.frm.find('#hdfCodTHabilitante'), ManNotificacion_AddEdit.frm.find('#iconTHabilitante'), true)) return false;
    return true;
}
ManNotificacion_AddEdit.fnShowTipoSupervisionDetalle = function () {
    ManNotificacion_AddEdit.frm.find("#dvPoaPo_Dema").hide();
    ManNotificacion_AddEdit.frm.find("#dvDevolMadera").hide();
    if (ManNotificacion_AddEdit.frm.find("#lstChkTipoSupervisionId").val() == "P") {
        ManNotificacion_AddEdit.frm.find("#dvPoaPo_Dema").show();
    } else if (ManNotificacion_AddEdit.frm.find("#lstChkTipoSupervisionId").val() == "DM") {
        ManNotificacion_AddEdit.frm.find("#dvPoaPo_Dema").show();
        ManNotificacion_AddEdit.frm.find("#dvDevolMadera").show();
    }
}

ManNotificacion_AddEdit.fnInitDataTable_Detail = function () {
    var columns_label = [], columns_data = [], options = {}, data_extend = [];

    columns_label = ["Plan de Manejo", "Resolución de Aprobación"];
    columns_data = ["NOMBRE_POA", "ARESOLUCION_NUM"];
    data_extend = [
        {
            "data": "NUM_MUESTRA", "title": "M1", "orderable": false, "searchable": false, "mRender": function (data, type, row, meta) {
                if (data == 1) {
                    return '<i class="fa fa-lg fa-check-circle-o" style="cursor:pointer;" title="Muestra 1 seleccionada"></i>';
                } else {
                    return '<i class="fa fa-lg fa-circle-o" style="cursor:pointer;" title="Seleccionar muestra 1" onclick="ManNotificacion_AddEdit.fnSetMuestraPoaPo_Dema(this,1);"></i>';
                }
            }
        },
        {
            "data": "NUM_MUESTRA", "title": "M2", "orderable": false, "searchable": false, "mRender": function (data, type, row, meta) {
                if (data == 2) {
                    return '<i class="fa fa-lg fa-check-circle-o" style="cursor:pointer;" title="Muestra 2 seleccionada"></i>';
                } else {
                    return '<i class="fa fa-lg fa-circle-o" style="cursor:pointer;" title="Seleccionar muestra 2" onclick="ManNotificacion_AddEdit.fnSetMuestraPoaPo_Dema(this,2);"></i>';
                }
            }
        },
        {
            "data": "NUM_MUESTRA", "title": "M3", "orderable": false, "searchable": false, "mRender": function (data, type, row, meta) {
                if (data == 3) {
                    return '<i class="fa fa-lg fa-check-circle-o" style="cursor:pointer;" title="Muestra 3 seleccionada"></i>';
                } else {
                    return '<i class="fa fa-lg fa-circle-o" style="cursor:pointer;" title="Seleccionar muestra 3" onclick="ManNotificacion_AddEdit.fnSetMuestraPoaPo_Dema(this,3);"></i>';
                }
            }
        }
    ];
    options = {
        page_length: 10, row_delete: true, row_fnDelete: "ManNotificacion_AddEdit.fnDeletePoaPo_Dema(this)"
        , row_index: true, data_extend: data_extend
    };
    ManNotificacion_AddEdit.dtPoaPo_Dema = utilDt.fnLoadDataTable_Detail(ManNotificacion_AddEdit.frm.find("#tbPoaPo_Dema"), columns_label, columns_data, options);
    ManNotificacion_AddEdit.dtPoaPo_Dema.rows.add(ManNotificacion_AddEdit.DataPoa).draw();

    columns_label = ["Cod. Devolución", "Fecha", "N° Resolución"];
    columns_data = ["COD_DEVOLUCION", "FECHA_RESOLUCION", "NUM_RESOLUCION"];
    options = {
        page_length: 10, row_delete: true, row_fnDelete: "ManNotificacion_AddEdit.fnDeleteDevolMadera(this)", row_index: true
    };
    ManNotificacion_AddEdit.dtDevolMadera = utilDt.fnLoadDataTable_Detail(ManNotificacion_AddEdit.frm.find("#tbDevolMadera"), columns_label, columns_data, options);
    ManNotificacion_AddEdit.dtDevolMadera.rows.add(ManNotificacion_AddEdit.DataDevMad).draw();
}

ManNotificacion_AddEdit.fnSetMuestraPoaPo_Dema = function (obj, val) {
    var data = ManNotificacion_AddEdit.dtPoaPo_Dema.row($(obj).parents('tr')).data();
    if (data["RegEstado"] == 1) {//Solo se puede cambiar de muestra cuando el registro sea nuevo
        data["NUM_MUESTRA"] = val;
        ManNotificacion_AddEdit.dtPoaPo_Dema.row($(obj).parents('tr')).data(data).draw(false);
    } else {
        utilSigo.toastWarning("Aviso", "No se puede cambiar el número de muestra");
    }
}
ManNotificacion_AddEdit.fnDeletePoaPo_Dema = function (obj) {
    utilSigo.dialogConfirm('', 'Desea eliminar el registro (POA/PO | DEMA)?', function (r) {
        if (r) {
            var data = ManNotificacion_AddEdit.dtPoaPo_Dema.row($(obj).parents('tr')).data();

            if (data["RegEstado"] == "0" || data["RegEstado"] == "2") {
                ManNotificacion_AddEdit.tbEliTABLA.push({
                    EliTABLA: "DETALLE_POA",
                    COD_THABILITANTE: data["COD_THABILITANTE"],
                    NUM_POA: data["NUM_POA"]
                });
            }
            ManNotificacion_AddEdit.dtPoaPo_Dema.row($(obj).parents('tr')).remove().draw(false);
            utilDt.enumColumn(ManNotificacion_AddEdit.dtPoaPo_Dema);
        }
    });
}
ManNotificacion_AddEdit.fnGetListPoaPo_Dema = function () {
    var list = [], rows, countFilas, data;

    rows = ManNotificacion_AddEdit.dtPoaPo_Dema.$("tr");
    countFilas = rows.length;
    if (countFilas > 0) {
        $.each(rows, function (i, o) {
            data = ManNotificacion_AddEdit.dtPoaPo_Dema.row($(o)).data();
            if (data.RegEstado==1 || data.RegEstado==2) {
                list.push(utilSigo.fnConvertArrayToObject(data));
            }
        });
    }
    return list;
}
ManNotificacion_AddEdit.fnGetListPoaPo_DemaCount = function () {
    return ManNotificacion_AddEdit.dtPoaPo_Dema.$("tr").length;
}

ManNotificacion_AddEdit.fnDeleteDevolMadera = function (obj) {
    utilSigo.dialogConfirm('', 'Desea eliminar el registro (Devolución de Madera)?', function (r) {
        if (r) {
            var data = ManNotificacion_AddEdit.dtDevolMadera.row($(obj).parents('tr')).data();

            if (data["RegEstado"] == "0" || data["RegEstado"] == "2") {
                ManNotificacion_AddEdit.tbEliTABLA.push({
                    EliTABLA: "DETALLE_DEVOLUCION_MADERA",
                    COD_THABILITANTE: data["COD_THABILITANTE"],
                    COD_DEVOLUCION: data["COD_DEVOLUCION"]
                });
            }
            ManNotificacion_AddEdit.dtDevolMadera.row($(obj).parents('tr')).remove().draw(false);
            utilDt.enumColumn(ManNotificacion_AddEdit.dtDevolMadera);
        }
    });
}
ManNotificacion_AddEdit.fnGetListDevolMadera = function () {
    var list = [], rows, countFilas, data;

    rows = ManNotificacion_AddEdit.dtDevolMadera.$("tr");
    countFilas = rows.length;
    if (countFilas > 0) {
        $.each(rows, function (i, o) {
            data = ManNotificacion_AddEdit.dtDevolMadera.row($(o)).data();
            if (data.RegEstado == 1 || data.RegEstado == 2) {
                list.push(utilSigo.fnConvertArrayToObject(data));
            }
        });
    }
    return list;
}
ManNotificacion_AddEdit.fnGetListDevolMaderaCount = function () {
    ManNotificacion_AddEdit.dtDevolMadera.$("tr").length;
}

$(document).ready(function () {
    ManNotificacion_AddEdit.frm = $("#frmManNotificacion_AddEdit");
    ManNotificacion_AddEdit.fnInit();
    ManNotificacion_AddEdit.fnInitDataTable_Detail();
    $('[data-toggle="tooltip"]').tooltip();

    ManNotificacion_AddEdit.fnEnableFechaPrimeraVisita();
    ManNotificacion_AddEdit.frm.find("#chkPrimeraVisita").change(function () {
        ManNotificacion_AddEdit.fnEnableFechaPrimeraVisita();
    });
    ManNotificacion_AddEdit.fnEnableFechaSegundaVisita();
    ManNotificacion_AddEdit.frm.find("#chkSegundaVisita").change(function () {
        ManNotificacion_AddEdit.fnEnableFechaSegundaVisita();
    });
    //ManNotificacion_AddEdit.fnShowPersonaRecibeNotif();
    //ManNotificacion_AddEdit.frm.find("input[name=radListRecepcion]").change(function () {
    //    ManNotificacion_AddEdit.fnShowPersonaRecibeNotif();
    //});
    ManNotificacion_AddEdit.fnShowParentesco();
    ManNotificacion_AddEdit.frm.find("#ddlParentescoId").change(function () {
        ManNotificacion_AddEdit.fnShowParentesco();
    });
    ManNotificacion_AddEdit.fnShowCambioDomicilio();
    ManNotificacion_AddEdit.frm.find("#chkCambioDomicilio").change(function () {
        ManNotificacion_AddEdit.fnShowCambioDomicilio();
    });

    ManNotificacion_AddEdit.frm.find("#txtFecSupervision").change(function () {
        ManNotificacion_AddEdit.frm.find("#ddlMesSupervisionId").select2("val", ["0000000"]);
    });
    ManNotificacion_AddEdit.frm.find("#ddlMesSupervisionId").change(function () {
        if ($(this).val() != "0000000") {
            ManNotificacion_AddEdit.frm.find("#txtFecSupervision").val("");
        }
    });
    ManNotificacion_AddEdit.fnShowTipoSupervisionDetalle();
    ManNotificacion_AddEdit.frm.find("[id*=lstChkTipoSupervision]").change(function () {
        var isChecked = $(this).is(":checked");
        ManNotificacion_AddEdit.fnClearAllCheckTipoSupervision();
        if (isChecked) {
            $(this).prop("checked", "checked");
        } else {
            $(this).prop("checked", "");
        }
        ManNotificacion_AddEdit.fnGetTipoSupervisionSelect();
        ManNotificacion_AddEdit.fnShowTipoSupervisionDetalle();
    });

    //=====-----Para el registro de datos del formulario-----=====
    //Validación personalizada
    jQuery.validator.addMethod("invalidManNot_AddEdit", function (value, element) {
        switch ($(element).attr('id')) {
            case 'ddlIndicadorId':
            case 'ddlOdId':
                return (value == '0000000') ? false : true;
                break
        }
    });
    ManNotificacion_AddEdit.frm.validate(utilSigo.fnValidate({
        rules: {
            ddlIndicadorId: { invalidManNot_AddEdit: true },
            ddlOdId: { invalidManNot_AddEdit: true },
            txtNumCNotificacion: { required: true }
        },
        messages: {
            ddlIndicadorId: { invalidManNot_AddEdit: "Seleccione el estado actual del registro" },
            ddlOdId: { invalidManNot_AddEdit: "Seleccione la oficina desconcentrada" },
            txtNumCNotificacion: { required: "Ingrese el número de la carta de notificación" }
        },
        fnSubmit: function (form) {
            utilSigo.dialogConfirm('', 'Desea continuar con el registro?', function (r) {
                if (r) {
                    ManNotificacion_AddEdit.fnSaveForm();
                }
            });
        }
    }));
    //Validación de controles que usan Select2
    ManNotificacion_AddEdit.frm.find("select.select2-hidden-accessible").on("change", function (e) {
        $(this).valid();
    });
});