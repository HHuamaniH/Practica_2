"use strict";
var ManProgramaCapacitacion_AddEdit = {};

ManProgramaCapacitacion_AddEdit.fnReturnIndex = function (alertaInicial) {
    if (alertaInicial==null || alertaInicial=="") {
        window.location = ManProgramaCapacitacion_AddEdit.frm.data("request_url");
    } else {
        window.location = ManProgramaCapacitacion_AddEdit.frm.data("request_url") + "?_alertaIncial=" + alertaInicial;
    }
}

ManProgramaCapacitacion_AddEdit.fnShowEntFinancia_FuenteCoop = function () {
    ManProgramaCapacitacion_AddEdit.frm.find("#dvEntFinancia_FuenteCoop").hide();
    if (ManProgramaCapacitacion_AddEdit.frm.find("#ddlEntFinanciaId").val() == "0000038") {
        ManProgramaCapacitacion_AddEdit.frm.find("#dvEntFinancia_FuenteCoop").show();
    }
}

ManProgramaCapacitacion_AddEdit.fnShowTabConvenios = function () {
    ManProgramaCapacitacion_AddEdit.frm.find("#tabConvenios").hide();
    if (ManProgramaCapacitacion_AddEdit.frm.find("#chkMarConvenio").is(":checked")) {
        ManProgramaCapacitacion_AddEdit.frm.find("#tabConvenios").show();
    }
}

ManProgramaCapacitacion_AddEdit.fnViewModalUbigeo = function () {
    var url = urlLocalSigo + "General/Controles/_Ubigeo";
    var option = { url: url, type: 'POST', datos: {}, divId: "mdlManProgCapacitacion_AddEdit_Ubigeo" };
    utilSigo.fnOpenModal(option, function () {
        _Ubigeo.fnSelectUbigeo = function (_ubigeoText,_ubigeoId) {
            ManProgramaCapacitacion_AddEdit.frm.find("#hdfUbigeo").val(_ubigeoId);
            ManProgramaCapacitacion_AddEdit.frm.find("#lblUbigeo").val(_ubigeoText);
            $("#mdlManProgCapacitacion_AddEdit_Ubigeo").modal('hide');
        }
        _Ubigeo.fnLoadModalView(ManProgramaCapacitacion_AddEdit.frm.find("#hdfUbigeo").val());
    },ManProgramaCapacitacion_AddEdit.fnCustomValidateForm);
}

ManProgramaCapacitacion_AddEdit.fnCustomValidateForm = function () {
    if (!utilSigo.fnValidateForm_HideControl(ManProgramaCapacitacion_AddEdit.frm, ManProgramaCapacitacion_AddEdit.frm.find('#hdfUbigeo'), ManProgramaCapacitacion_AddEdit.frm.find('#iconUbigeo'), true)) return false;
    return true;
}

ManProgramaCapacitacion_AddEdit.fnSubmitForm = function () {
    var controls = ["txtNomPCapacitacion", "ddlTipPCapacitacionId", "ddlOdId", "ddlSumMetPoiId", "txtFecInicio", "ddlEntFinanciaId"];

    if (!utilSigo.fnValidateForm(ManProgramaCapacitacion_AddEdit.frm, controls)) {
        return ManProgramaCapacitacion_AddEdit.frm.valid();
    }
    ManProgramaCapacitacion_AddEdit.frm.submit();
}

ManProgramaCapacitacion_AddEdit.fnSaveForm = function () {
    var datosPCapacitacion = ManProgramaCapacitacion_AddEdit.frm.serializeObject();
    datosPCapacitacion.chkMarConvenio = ManProgramaCapacitacion_AddEdit.frm.find("#chkMarConvenio").is(":checked");
    datosPCapacitacion.ddlConvenioId = "";

    //Capturar los convenios seleccionados
    for (var i = 0; i < ManProgramaCapacitacion_AddEdit.frm.find("#ddlConvenioCapacitacionId").find("option").length; i++) {
        if (ManProgramaCapacitacion_AddEdit.frm.find("#ddlConvenioCapacitacionId").find("option")[i].style.display!="none") {
            if (datosPCapacitacion.ddlConvenioId=="") {
                datosPCapacitacion.ddlConvenioId = ManProgramaCapacitacion_AddEdit.frm.find("#ddlConvenioCapacitacionId").find("option")[i].value;
            } else {
                datosPCapacitacion.ddlConvenioId += "," + ManProgramaCapacitacion_AddEdit.frm.find("#ddlConvenioCapacitacionId").find("option")[i].value;
            }
        }
    }

    $.ajax({
        url: ManProgramaCapacitacion_AddEdit.frm.action,
        type: 'POST',
        data: JSON.stringify(datosPCapacitacion),
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function (data) {
            utilSigo.unblockUIGeneral();
            if (data.success) {
                ManProgramaCapacitacion_AddEdit.fnReturnIndex(data.msj);
            }
            else utilSigo.toastWarning("Aviso", data.msj);
        },
        beforeSend: function () {
            utilSigo.blockUIGeneral();
        },
        error: function (jqXHR, error, errorThrown) {
            utilSigo.unblockUIGeneral();
            utilSigo.toastError("Error", "Sucedio un error, Comuníquese con el Administrador");
            console.log(jqXHR.responseText);
        }
    });
}

ManProgramaCapacitacion_AddEdit.fnShowGrupoConvenio = function () {
    //Se asume que existen 3 grupos de convenios, posible error cuando esto cambie
    for (var i = 0; i < 3; i++) {
        ManProgramaCapacitacion_AddEdit.frm.find("#ddlConvenioOsinforId").find("optgroup")[i].style = "display:none";
        for (var iopt = 0; iopt < ManProgramaCapacitacion_AddEdit.frm.find("#ddlConvenioOsinforId").find("optgroup")[i].childNodes.length; iopt++) {
            if (ManProgramaCapacitacion_AddEdit.frm.find("#ddlConvenioOsinforId").find("optgroup")[i].childNodes[iopt].nodeName == "OPTION"
                && ManProgramaCapacitacion_AddEdit.frm.find("#ddlConvenioOsinforId").find("optgroup")[i].childNodes[iopt].style.display != "none") {
                ManProgramaCapacitacion_AddEdit.frm.find("#ddlConvenioOsinforId").find("optgroup")[i].style = "display:auto";
                break;
            }
        }

        ManProgramaCapacitacion_AddEdit.frm.find("#ddlConvenioCapacitacionId").find("optgroup")[i].style = "display:none";
        for (var iopt = 0; iopt < ManProgramaCapacitacion_AddEdit.frm.find("#ddlConvenioCapacitacionId").find("optgroup")[i].childNodes.length; iopt++) {
            if (ManProgramaCapacitacion_AddEdit.frm.find("#ddlConvenioCapacitacionId").find("optgroup")[i].childNodes[iopt].nodeName == "OPTION"
                && ManProgramaCapacitacion_AddEdit.frm.find("#ddlConvenioCapacitacionId").find("optgroup")[i].childNodes[iopt].style.display != "none") {
                ManProgramaCapacitacion_AddEdit.frm.find("#ddlConvenioCapacitacionId").find("optgroup")[i].style = "display:auto";
                break;
            }
        }
    }
}

ManProgramaCapacitacion_AddEdit.fnLoadListConvenios = function () {
    var lstConvenioSelect = ManProgramaCapacitacion_AddEdit.frm.find("#ddlConvenioId").val().split(',');

    if (lstConvenioSelect.length>0 && lstConvenioSelect[0]!="") {
        for (var i = 0; i < ManProgramaCapacitacion_AddEdit.frm.find("#ddlConvenioOsinforId").find("option").length; i++) {
            if (lstConvenioSelect.includes(ManProgramaCapacitacion_AddEdit.frm.find("#ddlConvenioOsinforId").find("option")[i].value)) {
                ManProgramaCapacitacion_AddEdit.frm.find("#ddlConvenioOsinforId").find("option")[i].style = "display:none";
            }
        }
        for (var i = 0; i < ManProgramaCapacitacion_AddEdit.frm.find("#ddlConvenioCapacitacionId").find("option").length; i++) {
            if (!lstConvenioSelect.includes(ManProgramaCapacitacion_AddEdit.frm.find("#ddlConvenioCapacitacionId").find("option")[i].value)) {
                ManProgramaCapacitacion_AddEdit.frm.find("#ddlConvenioCapacitacionId").find("option")[i].style = "display:none";
            }
        }
    } else {
        for (var i = 0; i < ManProgramaCapacitacion_AddEdit.frm.find("#ddlConvenioCapacitacionId").find("option").length; i++) {
            ManProgramaCapacitacion_AddEdit.frm.find("#ddlConvenioCapacitacionId").find("option")[i].style = "display:none";
        }
    }

    ManProgramaCapacitacion_AddEdit.fnShowGrupoConvenio();
}

ManProgramaCapacitacion_AddEdit.fnInit = function () {
    utilSigo.fnFormatDate(ManProgramaCapacitacion_AddEdit.frm.find("#txtFecInicio"));

    $.fn.select2.defaults.set("theme", "bootstrap4");
    ManProgramaCapacitacion_AddEdit.frm.find("#ddlTipPCapacitacionId").select2();
    ManProgramaCapacitacion_AddEdit.frm.find("#ddlOdId").select2();
    ManProgramaCapacitacion_AddEdit.frm.find("#ddlSumMetPoiId").select2({ minimumResultsForSearch: -1 });
    ManProgramaCapacitacion_AddEdit.frm.find("#ddlEntFinanciaId").select2({ minimumResultsForSearch: -1 });
}

$(document).ready(function () {
    ManProgramaCapacitacion_AddEdit.contenedor = "frmProgramaCapacitacion";
    ManProgramaCapacitacion_AddEdit.frm = $("#" + ManProgramaCapacitacion_AddEdit.contenedor);

    ManProgramaCapacitacion_AddEdit.fnInit();

    ManProgramaCapacitacion_AddEdit.fnShowEntFinancia_FuenteCoop();
    ManProgramaCapacitacion_AddEdit.frm.find("#ddlEntFinanciaId").change(function () {
        ManProgramaCapacitacion_AddEdit.fnShowEntFinancia_FuenteCoop();
    });

    ManProgramaCapacitacion_AddEdit.fnShowTabConvenios();
    ManProgramaCapacitacion_AddEdit.frm.find("#chkMarConvenio").click(function () {
        ManProgramaCapacitacion_AddEdit.fnShowTabConvenios();
    });

    ManProgramaCapacitacion_AddEdit.fnLoadListConvenios();

    ManProgramaCapacitacion_AddEdit.frm.find('#ddlConvenioOsinforId').dblclick(function () {
        ManProgramaCapacitacion_AddEdit.frm.find("#ddlConvenioCapacitacionId").find("option[value='" + $(this).val() + "']").show();
        ManProgramaCapacitacion_AddEdit.frm.find("#ddlConvenioOsinforId").find("option[value='" + $(this).val() + "']").hide();

        ManProgramaCapacitacion_AddEdit.fnShowGrupoConvenio();
    });

    ManProgramaCapacitacion_AddEdit.frm.find('#ddlConvenioCapacitacionId').dblclick(function () {
        ManProgramaCapacitacion_AddEdit.frm.find("#ddlConvenioOsinforId").find("option[value='" + $(this).val() + "']").show();
        ManProgramaCapacitacion_AddEdit.frm.find("#ddlConvenioCapacitacionId").find("option[value='" + $(this).val() + "']").hide();

        ManProgramaCapacitacion_AddEdit.fnShowGrupoConvenio();
    });

    //=====-----Para el registro de datos del formulario-----=====
    //Validación personalizada
    jQuery.validator.addMethod("invalidFrmProgCapacitacion", function (value, element) {
        switch ($(element).attr('id')) {
            case 'ddlTipPCapacitacionId':
            case 'ddlOdId':
            case 'ddlSumMetPoiId':
            case 'ddlEntFinanciaId':
                return (value == '0000000') ? false : true;
                break
        }
    });
    ManProgramaCapacitacion_AddEdit.frm.validate(utilSigo.fnValidate({
        rules: {
            txtNomPCapacitacion: { required: true },
            ddlTipPCapacitacionId: { invalidFrmProgCapacitacion: true },
            ddlOdId: { invalidFrmProgCapacitacion: true },
            ddlSumMetPoiId: { invalidFrmProgCapacitacion: true },
            txtFecInicio: { required: true },
            ddlEntFinanciaId: { invalidFrmProgCapacitacion: true },
            lblUbigeo: { required: true }
            //txtLugar: { required: true }
        },
        messages: {
            txtNomPCapacitacion: { required: "Ingrese el nombre de la capacitación programada" },
            ddlTipPCapacitacionId: { invalidFrmProgCapacitacion: "Seleccione el tipo de capacitación" },
            ddlOdId: { invalidFrmProgCapacitacion: "Seleccione la oficina desconcentrada" },
            ddlSumMetPoiId: { invalidFrmProgCapacitacion: "Seleccione una opción" },
            txtFecInicio: { required: "Ingrese la fecha de inicio de la capacitación" },
            ddlEntFinanciaId: { invalidFrmProgCapacitacion: "Seleccione la entidad que financia el taller" },
            lblUbigeo: { required: "Seleccione el ubigeo donde se llevará a cabo la capacitación" }
            //txtLugar: { required: "Ingrese el lugar donde se llevará a cabo la capacitación" }
        },
        fnSubmit: function (form) {
            if (ManProgramaCapacitacion_AddEdit.fnCustomValidateForm()) {
                utilSigo.dialogConfirm('', 'Desea continuar con el registro?', function (r) {
                    if (r) {
                        ManProgramaCapacitacion_AddEdit.fnSaveForm();
                    }
                });
            }
        }
    }));
    //Validación de controles que usan Select2
    ManProgramaCapacitacion_AddEdit.frm.find("select.select2-hidden-accessible").on("change", function (e) {
        $(this).valid();
    });
});