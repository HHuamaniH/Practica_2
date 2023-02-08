"use strict";
var ManCNotificacion_AddEdit = {};
/*Variables globales*/
ManCNotificacion_AddEdit.tbEliTABLA = [];

ManCNotificacion_AddEdit.fnReturnIndex = function (alertaInicial) {
    var url = urlLocalSigo + "Supervision/ManCNotificacion/Index";

    if (alertaInicial == null || alertaInicial == "") {
        window.location = url;
    } else {
        window.location = url + "?_alertaIncial=" + alertaInicial;
    }
}

ManCNotificacion_AddEdit.fnShowPersonaNotificada = function () {
    ManCNotificacion_AddEdit.frm.find(".dvPersona_Notificada").show();
    if (utilSigo.fnGetValChk(ManCNotificacion_AddEdit.frm.find("#chkNtfBajoPuerta"))) {
        ManCNotificacion_AddEdit.frm.find(".dvPersona_Notificada").hide();
    }
}

ManCNotificacion_AddEdit.fnShowTipoSupervisionDetalle = function () {
    ManCNotificacion_AddEdit.frm.find("#dvPoaPo_Dema").hide();
    ManCNotificacion_AddEdit.frm.find("#dvDevolMadera").hide();
    ManCNotificacion_AddEdit.frm.find("#dvPoaPo_Quinquenal").hide();

    if (ManCNotificacion_AddEdit.frm.find("#lstChkTipoSupervisionId").val() == "P") {
        ManCNotificacion_AddEdit.frm.find("#dvPoaPo_Dema").show();
    } if (ManCNotificacion_AddEdit.frm.find("#lstChkTipoSupervisionId").val() == "DM") {
        ManCNotificacion_AddEdit.frm.find("#dvPoaPo_Dema").show();
        ManCNotificacion_AddEdit.frm.find("#dvDevolMadera").show();
    } if (ManCNotificacion_AddEdit.frm.find("#lstChkTipoSupervisionId").val() == "AQ") {
        ManCNotificacion_AddEdit.frm.find("#dvPoaPo_Quinquenal").show();
        // ManCNotificacion_AddEdit.frm.find("#dvDevolMadera").show();
    }
}

ManCNotificacion_AddEdit.fnInit = function () {
    $.fn.select2.defaults.set("theme", "bootstrap4");
    ManCNotificacion_AddEdit.frm.find("#ddlOdId").select2();
    ManCNotificacion_AddEdit.frm.find("#ddlTipoCNotificacionId").select2();
    ManCNotificacion_AddEdit.frm.find("#ddlMesSupervisionId").select2();
    ManCNotificacion_AddEdit.frm.find("#ddlParentescoId").select2();

    utilSigo.fnFormatDate(ManCNotificacion_AddEdit.frm.find("#txtFecEmision"));
    utilSigo.fnFormatDate(ManCNotificacion_AddEdit.frm.find("#txtFecSupervision"));
    utilSigo.fnFormatDate(ManCNotificacion_AddEdit.frm.find("#txtFecRecepcionOd"));
    utilSigo.fnFormatDate(ManCNotificacion_AddEdit.frm.find("#txtFecEntregaNft"));
    utilSigo.fnFormatDate(ManCNotificacion_AddEdit.frm.find("#txtFecNotificacion"));

    ManCNotificacion_AddEdit.frm.find(".dvRegModificar").hide();
    if (ManCNotificacion_AddEdit.frm.find("#hdfCodCNotificacion").val() != "") {
        ManCNotificacion_AddEdit.frm.find(".dvRegModificar").show();
    }

    ManCNotificacion_AddEdit.frm.find("#dvCNotificacionReferencia").hide();
    ManCNotificacion_AddEdit.frm.find("#dvTipoSupervision").hide();
    if (ManCNotificacion_AddEdit.frm.find("#ddlTipoCNotificacionId").val() == "0000002") {
        ManCNotificacion_AddEdit.frm.find("#dvCNotificacionReferencia").show();
    } else {
        ManCNotificacion_AddEdit.frm.find("#dvTipoSupervision").show();
    }
}

ManCNotificacion_AddEdit.fnSubmitForm = function () {
    var controls = ["ddlIndicadorId", "ddlOdId", "ddlTipoCNotificacionId", "txtNumCNotificacion", "txtFecEmision"];
    if (!utilSigo.fnValidateForm(ManCNotificacion_AddEdit.frm, controls)) {
        return ManCNotificacion_AddEdit.frm.valid();
    }

    if (ManCNotificacion_AddEdit.frm.find("#ddlTipoCNotificacionId").val() == "0000001")//Carta de supervisión
    {
        switch (ManCNotificacion_AddEdit.frm.find("#lstChkTipoSupervisionId").val()) {
            case "P":
                if (ManCNotificacion_AddEdit.fnGetListPoaPo_Dema().length == 0) { utilSigo.toastWarning("Aviso", "Seleccione el POA/PO | DEMA"); return false; }
                break;
            case "PM":
            case "TH":
                break;
           /* case "AQ":
                if (ManCNotificacion_AddEdit.fnGetListPoaPo_Quinquenal().length == 0) { utilSigo.toastWarning("Aviso", "Seleccione el POA/PO | DEMA"); return false; }
                break;*/
            case "DM":
                if (ManCNotificacion_AddEdit.fnGetListDevolMadera().length == 0) { utilSigo.toastWarning("Aviso", "Seleccione la Devolución de Madera"); return false; }
                break;
            default: utilSigo.toastWarning("Aviso", "Debe seleccionar un tipo de supervisión"); return false;
        }
    }
    ManCNotificacion_AddEdit.frm.submit();
}

ManCNotificacion_AddEdit.fnSaveForm = function () {
    var datosCNotificacion = ManCNotificacion_AddEdit.frm.serializeObject();
    datosCNotificacion.ddlTipoCNotificacionId = ManCNotificacion_AddEdit.frm.find("#ddlTipoCNotificacionId").val();
    datosCNotificacion.chkNtfBajoPuerta = utilSigo.fnGetValChk(ManCNotificacion_AddEdit.frm.find("#chkNtfBajoPuerta"));
    datosCNotificacion.chkCoincideDirTh = utilSigo.fnGetValChk(ManCNotificacion_AddEdit.frm.find("#chkCoincideDirTh"));
    datosCNotificacion.vmControlCalidad = _ControlCalidad.fnGetDatosControlCalidad();
    datosCNotificacion.tbPoaPo_Dema = ManCNotificacion_AddEdit.fnGetListPoaPo_Dema();
    datosCNotificacion.tbPoaPo_Quinquenal = ManCNotificacion_AddEdit.fnGetListPoaPo_Dema();
    //datosCNotificacion.tbPoaPo_Quinquenal = ManCNotificacion_AddEdit.fnGetListPoaPo_Quinquenal();
    datosCNotificacion.tbDevolMadera = ManCNotificacion_AddEdit.fnGetListDevolMadera();
    datosCNotificacion.tbEliTABLA = ManCNotificacion_AddEdit.tbEliTABLA;

    var option = { url: ManCNotificacion_AddEdit.frm.action, datos: JSON.stringify(datosCNotificacion), type: 'POST' };
    utilSigo.fnAjax(option, function (data) {
        if (data.success) {
            ManCNotificacion_AddEdit.fnReturnIndex(data.msj);
        }
        else {
            utilSigo.toastWarning("Aviso", data.msj);
        }
    });
}

ManCNotificacion_AddEdit.fnClearAllCheckTipoSupervision = function () {
    for (var i = 1; i <= ManCNotificacion_AddEdit.frm.find("[id*=lstChkTipoSupervision]").length; i++) {
        if (i % 2 == 0)
            ManCNotificacion_AddEdit.frm.find("[id*=lstChkTipoSupervision]")[i - 1].checked = false;
    }
}
ManCNotificacion_AddEdit.fnGetTipoSupervisionSelect = function () {
    ManCNotificacion_AddEdit.frm.find("#lstChkTipoSupervisionId").val("");
    for (var i = 1; i <= ManCNotificacion_AddEdit.frm.find("[id*=lstChkTipoSupervision]").length; i++) {
        if (i % 2 == 0) {
            if (ManCNotificacion_AddEdit.frm.find("[id*=lstChkTipoSupervision]")[i - 1].checked) {
                ManCNotificacion_AddEdit.frm.find("#lstChkTipoSupervisionId").val(ManCNotificacion_AddEdit.frm.find("[id*=lstChkTipoSupervision]")[i - 2].value);
            }
        }
    }
}

ManCNotificacion_AddEdit.fnViewModalTHabilitante = function () {
    if (ManCNotificacion_AddEdit.frm.find("#ddlTipoCNotificacionId").val() != "0000002") {
        if (ManCNotificacion_AddEdit.frm.find("#lstChkTipoSupervisionId").val() == "") {
            utilSigo.toastWarning("Aviso", "Seleccione el tipo de supervisión primero"); return false;
        }
    }

    var url = initSigo.urlControllerGeneral + "_THabilitante";
    var option = { url: url, type: 'GET', datos: { hdfFormulario: "TITULO_HABILITANTE" }, divId: "mdlManCNot_AddEdit_THabilitante" };
    utilSigo.fnOpenModal(option, function () {
        vpTHabilitante.fnAsignarDatos = function (obj) {
            if (obj != null && obj != "") {
                var data = vpTHabilitante.dtTituloHabilitante.row($(obj).parents('tr')).data();
                ManCNotificacion_AddEdit.frm.find("#hdfCodTHabilitante").val(data["CODIGO"]);
                ManCNotificacion_AddEdit.frm.find("#lblTHabilitante").val(data["NUMERO"]);
                $("#mdlManCNot_AddEdit_THabilitante").modal('hide');
            }
        }

        vpTHabilitante.fnInit_v2();
    }, ManCNotificacion_AddEdit.fnCustomValidateForm);
}
ManCNotificacion_AddEdit.fnViewModalUbigeo = function () {
    var url = initSigo.urlControllerGeneral + "_Ubigeo";
    var option = { url: url, type: 'POST', datos: {}, divId: "mdlManCNot_AddEdit_Ubigeo" };
    utilSigo.fnOpenModal(option, function () {
        _Ubigeo.fnSelectUbigeo = function (_ubigeoText, _ubigeoId) {
            ManCNotificacion_AddEdit.frm.find("#hdfCodUbigeo").val(_ubigeoId);
            ManCNotificacion_AddEdit.frm.find("#lblUbigeo").val(_ubigeoText);
            $("#mdlManCNot_AddEdit_Ubigeo").modal('hide');
        }
        _Ubigeo.fnLoadModalView(ManCNotificacion_AddEdit.frm.find("#hdfCodUbigeo").val());
    });
}

ManCNotificacion_AddEdit.fnBuscarPersona = function (_dom) {
    var url = urlLocalSigo + "General/Controles/_BuscarPersonaGeneral";
    var option = { url: url, type: 'GET', datos: { asBusGrupo: "PERSONA", asCodPTipo: "TODOS", asTipoPersona: "N" }, divId: "mdlBuscarPersona" };
    utilSigo.fnOpenModal(option, function () {
        _bPerGen.fnAsignarDatos = function (obj) {
            if (obj != null && obj != "") {
                var data = _bPerGen.dtBuscarPerona.row($(obj).parents('tr')).data();
                if (_dom == "NOTIFICADOR") {
                    ManCNotificacion_AddEdit.frm.find("#hdfCodNatificador").val(data["COD_PERSONA"]);
                    ManCNotificacion_AddEdit.frm.find("#lblNotificador").val(data["PERSONA"]);
                } else if (_dom == "PERSONA_NOTIFICADA") {
                    ManCNotificacion_AddEdit.frm.find("#hdfCodPersonaNatificada").val(data["COD_PERSONA"]);
                    ManCNotificacion_AddEdit.frm.find("#lblPersonaNotificada").val(data["PERSONA"]);
                }
            }
        }
        _bPerGen.fnInit();
    });
}

ManCNotificacion_AddEdit.fnViewModalCNotificacion = function () {
    if (ManCNotificacion_AddEdit.frm.find("#hdfCodTHabilitante").val() == "") {
        utilSigo.toastWarning("Aviso", "Seleccione el título habilitante primero"); return false;
    }

    var url = "", sFormulario = "MODAL_CNOTIFICACION", sCriterio = "CN_CODTH_GENERAL", sValor = ManCNotificacion_AddEdit.frm.find("#hdfCodTHabilitante").val();
    url = initSigo.urlControllerGeneral + "_CNotificacion";
    var option = { url: url, type: 'POST', datos: { asFormulario: sFormulario, asCriterio: sCriterio, asValor: sValor }, divId: "mdlManCNot_AddEdit_Referencia" };
    utilSigo.fnOpenModal(option, function () {
        _CNotificacion.fnAsignarDatos = function (obj) {
            if (obj != null && obj != "") {
                var data = _CNotificacion.dtCNotificacion.row($(obj).parents('tr')).data();
                ManCNotificacion_AddEdit.frm.find("#hdfCodCNotificacionRef").val(data["COD_CNOTIFICACION"]);
                var numCN = data["NUMERO"] + " (" + data["MAE_CNTIPO"] + ")";
                ManCNotificacion_AddEdit.frm.find("#lblCNotificacionRef").val(numCN);
                $("#mdlManCNot_AddEdit_Referencia").modal('hide');
            }
        }

        _CNotificacion.fnInit();
    });
}
ManCNotificacion_AddEdit.fnViewModalPOA = function () {
    if (ManCNotificacion_AddEdit.frm.find("#hdfCodTHabilitante").val() == "") {
        utilSigo.toastWarning("Aviso", "Seleccione el título habilitante primero"); return false;
    }

    var url = "", sFormulario = "TITULO_HABILITANTE", sCriterio = "CN_DEV_POA_PMANEJO", sValor = ManCNotificacion_AddEdit.frm.find("#hdfCodTHabilitante").val();
    url = initSigo.urlControllerGeneral + "_POA";
    var option = { url: url, type: 'POST', datos: { asFormulario: sFormulario, asCriterio: sCriterio, asValor: sValor }, divId: "mdlManCNot_AddEdit_POA" };
    utilSigo.fnOpenModal(option, function () {
        _POA.fnAsignarDatos = function (obj) {
            if (obj != null && obj != "") {
                var data = _POA.dtPOA.row($(obj).parents('tr')).data();

                if (!utilDt.existValorSearch(ManCNotificacion_AddEdit.dtPoaPo_Dema, "NUM_POA", data["NUM_POA"])) {
                    data["NUM_MUESTRA"] = 1;
                    data["RegEstado"] = 1;
                    ManCNotificacion_AddEdit.dtPoaPo_Dema.rows.add([data]).draw(false);
                    $("#mdlManCNot_AddEdit_POA").modal('hide');
                } else {
                    utilSigo.toastWarning("Aviso", "El POA/PO | DEMA ya existe");
                }
            }
        }
        _POA.fnInit();
    });
}

ManCNotificacion_AddEdit.fnViewModalPOAQuinquenal = function () {
    if (ManCNotificacion_AddEdit.frm.find("#hdfCodTHabilitante").val() == "") {
        utilSigo.toastWarning("Aviso", "Seleccione el título habilitante primero"); return false;
    }

    var url = "", sFormulario = "TITULO_HABILITANTE", sCriterio = "CN_DEV_POA_PMANEJO", sValor = ManCNotificacion_AddEdit.frm.find("#hdfCodTHabilitante").val();
    url = initSigo.urlControllerGeneral + "_POA";
    var option = { url: url, type: 'POST', datos: { asFormulario: sFormulario, asCriterio: sCriterio, asValor: sValor }, divId: "mdlManCNot_AddEdit_POA" };
    utilSigo.fnOpenModal(option, function () {
        _POA.fnAsignarDatos = function (obj) {
            if (obj != null && obj != "") {
                var data = _POA.dtPOA.row($(obj).parents('tr')).data();

                if (!utilDt.existValorSearch(ManCNotificacion_AddEdit.dtPoaPo_Dema, "NUM_POA", data["NUM_POA"])) {
                    data["NUM_MUESTRA"] = 1;
                    data["RegEstado"] = 1;
                    ManCNotificacion_AddEdit.dtPoaPo_Dema.rows.add([data]).draw(false);
                    $("#mdlManCNot_AddEdit_POA").modal('hide');
                } else {
                    utilSigo.toastWarning("Aviso", "El POA/PO | DEMA ya existe");
                }
            }
        }
        _POA.fnInit();
    });
}

ManCNotificacion_AddEdit.fnViewModalDevolMadera = function () {
    if (ManCNotificacion_AddEdit.frm.find("#hdfCodTHabilitante").val() == "") {
        utilSigo.toastWarning("Aviso", "Seleccione el título habilitante primero"); return false;
    }

    var url = "", sFormulario = "", sCriterio = "", sValor = ManCNotificacion_AddEdit.frm.find("#hdfCodTHabilitante").val();
    url = initSigo.urlControllerGeneral + "_DevolucionMadera";
    var option = { url: url, type: 'POST', datos: { asFormulario: sFormulario, asCriterio: sCriterio, asValor: sValor }, divId: "mdlManCNot_AddEdit_DevolMadera" };
    utilSigo.fnOpenModal(option, function () {
        _DevolucionMadera.fnAsignarDatos = function (obj) {
            if (obj != null && obj != "") {
                var data = _DevolucionMadera.dtDevolucionMadera.row($(obj).parents('tr')).data();

                if (!utilDt.existValorSearch(ManCNotificacion_AddEdit.dtDevolMadera, "COD_DEVOLUCION", data["COD_DEVOLUCION"])) {
                    data["RegEstado"] = 1;
                    ManCNotificacion_AddEdit.dtDevolMadera.rows.add([data]).draw(false);
                    $("#mdlManCNot_AddEdit_DevolMadera").modal('hide');
                } else {
                    utilSigo.toastWarning("Aviso", "La Devolución de Madera ya existe");
                }
            }
        }

        _DevolucionMadera.fnInit();
    });
}

ManCNotificacion_AddEdit.fnCustomValidateForm = function () {
    if (!utilSigo.fnValidateForm_HideControl(ManCNotificacion_AddEdit.frm, ManCNotificacion_AddEdit.frm.find('#hdfCodTHabilitante'), ManCNotificacion_AddEdit.frm.find('#iconTHabilitante'), true)) return false;
    return true;
}

ManCNotificacion_AddEdit.fnSetMuestraPoaPo_Dema = function (obj, val) {
    var data = ManCNotificacion_AddEdit.dtPoaPo_Dema.row($(obj).parents('tr')).data();

    if (data["RegEstado"] == 1) {//Solo se puede cambiar de muestra cuando el registro sea nuevo
        data["NUM_MUESTRA"] = val;
        ManCNotificacion_AddEdit.dtPoaPo_Dema.row($(obj).parents('tr')).data(data).draw(false);
    } else {
        data["RegEstado"] = 2;
        ManCNotificacion_AddEdit.dtPoaPo_Dema.row($(obj).parents('tr')).data(data).draw(false);
        utilSigo.toastWarning("Aviso", "No se puede cambiar el número de muestra");
    }
}

ManCNotificacion_AddEdit.fnDeletePoaPo_Dema = function (obj) {
    utilSigo.dialogConfirm('', 'Desea eliminar el registro (POA/PO | DEMA)?', function (r) {
        if (r) {
            var data = ManCNotificacion_AddEdit.dtPoaPo_Dema.row($(obj).parents('tr')).data();

            if (data["RegEstado"] == "0" || data["RegEstado"] == "2") {
                ManCNotificacion_AddEdit.tbEliTABLA.push({
                    EliTABLA: "CNOTIFICACION_VS_POA",
                    NUM_POA: data["NUM_POA"]
                });
            }
            ManCNotificacion_AddEdit.dtPoaPo_Dema.row($(obj).parents('tr')).remove().draw(false);
            utilDt.enumColumn(ManCNotificacion_AddEdit.dtPoaPo_Dema);
        }
    });
}

ManCNotificacion_AddEdit.fnGetListPoaPo_Dema = function () {
    var list = [], rows, countFilas, data;

    rows = ManCNotificacion_AddEdit.dtPoaPo_Dema.$("tr");
    countFilas = rows.length;
    if (countFilas > 0) {
        $.each(rows, function (i, o) {
            data = ManCNotificacion_AddEdit.dtPoaPo_Dema.row($(o)).data();
            list.push(utilSigo.fnConvertArrayToObject(data));
        });
    }

    return list;
}

ManCNotificacion_AddEdit.fnGetListPoaPo_Quinquenal = function () {
    var list = [], rows, countFilas, data;

    rows = ManCNotificacion_AddEdit.dtPoaPo_Quinquenal.$("tr");
    countFilas = rows.length;
    if (countFilas > 0) {
        $.each(rows, function (i, o) {
            data = ManCNotificacion_AddEdit.dtPoaPo_Quinquenal.row($(o)).data();
            list.push(utilSigo.fnConvertArrayToObject(data));
        });
    }

    return list;
}

ManCNotificacion_AddEdit.fnDeleteDevolMadera = function (obj) {
    utilSigo.dialogConfirm('', 'Desea eliminar el registro (Devolución de Madera)?', function (r) {
        if (r) {
            var data = ManCNotificacion_AddEdit.dtDevolMadera.row($(obj).parents('tr')).data();

            if (data["RegEstado"] == "0" || data["RegEstado"] == "2") {
                ManCNotificacion_AddEdit.tbEliTABLA.push({
                    EliTABLA: "CNOTIFICACION_VS_DEVOLUCION_MADERA",
                    COD_DEVOLUCION: data["COD_DEVOLUCION"]
                });
            }
            ManCNotificacion_AddEdit.dtDevolMadera.row($(obj).parents('tr')).remove().draw(false);
            utilDt.enumColumn(ManCNotificacion_AddEdit.dtDevolMadera);
        }
    });
}

ManCNotificacion_AddEdit.fnGetListDevolMadera = function () {
    var list = [], rows, countFilas, data;

    rows = ManCNotificacion_AddEdit.dtDevolMadera.$("tr");
    countFilas = rows.length;
    if (countFilas > 0) {
        $.each(rows, function (i, o) {
            data = ManCNotificacion_AddEdit.dtDevolMadera.row($(o)).data();
            list.push(utilSigo.fnConvertArrayToObject(data));
        });
    }

    return list;
}

ManCNotificacion_AddEdit.fnInitDataTable_Detail = function () {
    var url, columns_label = [], columns_data = [], options = {}, data_extend = [];

    url = urlLocalSigo + "SUPERVISION/ManCNotificacion/GetAllPoaPo_Dema";
    columns_label = ["Plan de Manejo", "Resolución de Aprobación"];
    columns_data = ["ESTADO_ORIGEN", "NUM_RESOLUCION"];
    data_extend = [
        {
            "data": "NUM_MUESTRA", "title": "M1", "orderable": false, "searchable": false, "mRender": function (data, type, row, meta) {
                if (data == 1) {
                    return '<i class="fa fa-lg fa-check-circle-o" style="cursor:pointer;" title="Muestra 1 seleccionada"></i>';
                } else {
                    return '<i class="fa fa-lg fa-circle-o" style="cursor:pointer;" title="Seleccionar muestra 1" onclick="ManCNotificacion_AddEdit.fnSetMuestraPoaPo_Dema(this,1);"></i>';
                }
            }
        },
        {
            "data": "NUM_MUESTRA", "title": "M2", "orderable": false, "searchable": false, "mRender": function (data, type, row, meta) {
                if (data == 2) {
                    return '<i class="fa fa-lg fa-check-circle-o" style="cursor:pointer;" title="Muestra 2 seleccionada"></i>';
                } else {
                    return '<i class="fa fa-lg fa-circle-o" style="cursor:pointer;" title="Seleccionar muestra 2" onclick="ManCNotificacion_AddEdit.fnSetMuestraPoaPo_Dema(this,2);"></i>';
                }
            }
        },
        {
            "data": "NUM_MUESTRA", "title": "M3", "orderable": false, "searchable": false, "mRender": function (data, type, row, meta) {
                if (data == 3) {
                    return '<i class="fa fa-lg fa-check-circle-o" style="cursor:pointer;" title="Muestra 3 seleccionada"></i>';
                } else {
                    return '<i class="fa fa-lg fa-circle-o" style="cursor:pointer;" title="Seleccionar muestra 3" onclick="ManCNotificacion_AddEdit.fnSetMuestraPoaPo_Dema(this,3);"></i>';
                }
            }
        }
    ];
    options = {
        page_length: 10, row_delete: true, row_fnDelete: "ManCNotificacion_AddEdit.fnDeletePoaPo_Dema(this)"
        , row_index: true, data_extend: data_extend
    };
    ManCNotificacion_AddEdit.dtPoaPo_Dema = utilDt.fnLoadDataTable_Detail(ManCNotificacion_AddEdit.frm.find("#tbPoaPo_Dema"), columns_label, columns_data, options);

    ManCNotificacion_AddEdit.dtPoaPo_Dema.ajax.url(url).load(function (data) {
        if (data.success == false) {
            utilSigo.toastError("Error", initSigo.MessageError);
            console.log(data.e);
        }
    });

    url = urlLocalSigo + "SUPERVISION/ManCNotificacion/GetAllDevolMadera";
    columns_label = ["Código", "Fecha", "N° Resolución"];
    columns_data = ["COD_DEVOLUCION", "FECHA_RESOLUCION", "NUM_RESOLUCION"];
    options = {
        page_length: 10, row_delete: true, row_fnDelete: "ManCNotificacion_AddEdit.fnDeleteDevolMadera(this)", row_index: true
    };
    ManCNotificacion_AddEdit.dtDevolMadera = utilDt.fnLoadDataTable_Detail(ManCNotificacion_AddEdit.frm.find("#tbDevolMadera"), columns_label, columns_data, options);

    ManCNotificacion_AddEdit.dtDevolMadera.ajax.url(url).load(function (data) {
        if (data.success == false) {
            utilSigo.toastError("Error", initSigo.MessageError);
            console.log(data.e);
        }
    });

    url = urlLocalSigo + "SUPERVISION/ManCNotificacion/GetAllPoaPo_Quinquenal";
    columns_label = ["Plan de Manejo", "Resolución de Aprobación"];
    columns_data = ["ESTADO_ORIGEN", "NUM_RESOLUCION"];
    data_extend = [
        {
            "data": "NUM_MUESTRA", "title": "I", "orderable": false, "searchable": false, "mRender": function (data, type, row, meta) {
                if (data == 1) {
                    return '<i class="fa fa-lg fa-check-circle-o" style="cursor:pointer;" title="I Quinquenio"></i>';
                } else {
                    return '<i class="fa fa-lg fa-circle-o" style="cursor:pointer;" title="Seleccionar I Quinquenio" onclick="ManCNotificacion_AddEdit.fnSetMuestraPoaPo_Dema(this,1);"></i>';
                }
            }
        },
        {
            "data": "NUM_MUESTRA", "title": "II", "orderable": false, "searchable": false, "mRender": function (data, type, row, meta) {
                if (data == 2) {
                    return '<i class="fa fa-lg fa-check-circle-o" style="cursor:pointer;" title="II Quinquenio"></i>';
                } else {
                    return '<i class="fa fa-lg fa-circle-o" style="cursor:pointer;" title="Seleccionar II Quinquenio" onclick="ManCNotificacion_AddEdit.fnSetMuestraPoaPo_Dema(this,2);"></i>';
                }
            }
        },

        {
            "data": "NUM_MUESTRA", "title": "III", "orderable": false, "searchable": false, "mRender": function (data, type, row, meta) {
                if (data == 3) {
                    return '<i class="fa fa-lg fa-check-circle-o" style="cursor:pointer;" title="III Quinquenio"></i>';
                } else {
                    return '<i class="fa fa-lg fa-circle-o" style="cursor:pointer;" title="Seleccionar III Quinquenio" onclick="ManCNotificacion_AddEdit.fnSetMuestraPoaPo_Dema(this,1);"></i>';
                }
            }
        },
        {
            "data": "NUM_MUESTRA", "title": "IV", "orderable": false, "searchable": false, "mRender": function (data, type, row, meta) {
                if (data == 4) {
                    return '<i class="fa fa-lg fa-check-circle-o" style="cursor:pointer;" title="IV Quinquenio"></i>';
                } else {
                    return '<i class="fa fa-lg fa-circle-o" style="cursor:pointer;" title="Seleccionar IV Quinquenio" onclick="ManCNotificacion_AddEdit.fnSetMuestraPoaPo_Dema(this,2);"></i>';
                }
            }
        }
    ];

    options = {
        page_length: 10, row_delete: true, row_fnDelete: "ManCNotificacion_AddEdit.fnDeletePoaPo_Dema(this)"
        , row_index: true, data_extend: data_extend
    };
    ManCNotificacion_AddEdit.tbPoaPo_Quinquenal = utilDt.fnLoadDataTable_Detail(ManCNotificacion_AddEdit.frm.find("#tbPoaPo_Quinquenal"), columns_label, columns_data, options);

   
    ManCNotificacion_AddEdit.tbPoaPo_Quinquenal.ajax.url(url).load(function (data) {
        if (data.success == false) {
            utilSigo.toastError("Error", initSigo.MessageError);
            console.log(data.e);
        }
    });
}

$(document).ready(function () {
    ManCNotificacion_AddEdit.frm = $("#frmManCNotificacion_AddEdit");

    ManCNotificacion_AddEdit.fnInit();

    ManCNotificacion_AddEdit.frm.find("#txtFecSupervision").change(function () {
        ManCNotificacion_AddEdit.frm.find("#ddlMesSupervisionId").select2("val", ["0000000"]);
    });
    ManCNotificacion_AddEdit.frm.find("#ddlMesSupervisionId").change(function () {
        if ($(this).val() != "0000000") {
            ManCNotificacion_AddEdit.frm.find("#txtFecSupervision").val("");
        }
    });

    ManCNotificacion_AddEdit.fnShowTipoSupervisionDetalle();
    ManCNotificacion_AddEdit.frm.find("[id*=lstChkTipoSupervision]").change(function () {
        var isChecked = $(this).is(":checked");
        ManCNotificacion_AddEdit.fnClearAllCheckTipoSupervision();
        if (isChecked) {
            $(this).prop("checked", "checked");
        } else {
            $(this).prop("checked", "");
        }
        ManCNotificacion_AddEdit.fnGetTipoSupervisionSelect();
        ManCNotificacion_AddEdit.fnShowTipoSupervisionDetalle();
    });

    ManCNotificacion_AddEdit.fnShowPersonaNotificada();
    ManCNotificacion_AddEdit.frm.find("#chkNtfBajoPuerta").click(function () {
        ManCNotificacion_AddEdit.fnShowPersonaNotificada();
    });

    ManCNotificacion_AddEdit.fnInitDataTable_Detail();

    $('[data-toggle="tooltip"]').tooltip();

    //=====-----Para el registro de datos del formulario-----=====
    //Validación personalizada
    jQuery.validator.addMethod("invalidManCNot_AddEdit", function (value, element) {
        switch ($(element).attr('id')) {
            case 'ddlIndicadorId':
            case 'ddlOdId':
            case 'ddlTipoCNotificacionId':
                return (value == '0000000') ? false : true;
                break
        }
    });
    ManCNotificacion_AddEdit.frm.validate(utilSigo.fnValidate({
        rules: {
            ddlIndicadorId: { invalidManCNot_AddEdit: true },
            ddlOdId: { invalidManCNot_AddEdit: true },
            ddlTipoCNotificacionId: { invalidManCNot_AddEdit: true },
            txtNumCNotificacion: { required: true },
            txtFecEmision: { required: true }
        },
        messages: {
            ddlIndicadorId: { invalidManCNot_AddEdit: "Seleccione el estado actual del registro" },
            ddlOdId: { invalidManCNot_AddEdit: "Seleccione la oficina desconcentrada" },
            ddlTipoCNotificacionId: { invalidManCNot_AddEdit: "Seleccione el tipo de carta de notificación" },
            txtNumCNotificacion: { required: "Ingrese el número de la carta de notificación" },
            txtFecEmision: { required: "Seleccione la fecha de emisión" }
        },
        fnSubmit: function (form) {
            if (ManCNotificacion_AddEdit.fnCustomValidateForm()) {
                utilSigo.dialogConfirm('', 'Desea continuar con el registro?', function (r) {
                    if (r) {
                        ManCNotificacion_AddEdit.fnSaveForm();
                    }
                });
            }
        }
    }));
    //Validación de controles que usan Select2
    ManCNotificacion_AddEdit.frm.find("select.select2-hidden-accessible").on("change", function (e) {
        $(this).valid();
    });
});