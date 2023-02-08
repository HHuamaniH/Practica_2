"use strict";
var _CambioUso = {};

_CambioUso.fnSaveForm = function (data) { /*implementado desde donde se instancia*/ }

_CambioUso.fnLoadDatos = function (data) {
    if (data != null && data != "") {
        _CambioUso.frm.find("#hdfRegEstado").val(data["RegEstado"]);
        _CambioUso.frm.find("#hdfCodSecuencial").val(data["COD_SECUENCIAL"]);
        _CambioUso.frm.find("#ddlCambioUsoId").select2("val", [data["MAE_TIP_CAMBIOUSO"]]);
        _CambioUso.frm.find("#ddlAutorizadoId").select2("val", [data["AUTORIZADO"]]);
        _CambioUso.frm.find("#txtArea").val(data["AREA"]);
        _CambioUso.frm.find("#txtCoordEste").val(data["COORDENADA_ESTE"]);
        _CambioUso.frm.find("#txtCoordNorte").val(data["COORDENADA_NORTE"]);
        _CambioUso.frm.find("#txtObservacion").val(data["OBSERVACION"]);
    } else {
        _CambioUso.frm.find("#hdfRegEstado").val("1");
        _CambioUso.frm.find("#hdfCodSecuencial").val("0");
    }
}

_CambioUso.fnSetDatos = function () {
    var data = [];
    var regEstado = _CambioUso.frm.find("#hdfRegEstado").val();
    data["RegEstado"] = regEstado == "0" ? "2" : regEstado;
    data["COD_SECUENCIAL"] = _CambioUso.frm.find("#hdfCodSecuencial").val();
    data["MAE_TIP_CAMBIOUSO"] = _CambioUso.frm.find("#ddlCambioUsoId").val();
    data["NOM_TIP_CAMBIOUSO"] = data["MAE_TIP_CAMBIOUSO"] == "0000000" ? "" : _CambioUso.frm.find("#ddlCambioUsoId").select2("data")[0].text;
    data["AREA"] = _CambioUso.frm.find("#txtArea").val();
    data["ZONA"] = _CambioUso.frm.find("#ddlZonaId").val();
    data["AUTORIZADO"] = _CambioUso.frm.find("#ddlAutorizadoId").val();
    data["COORDENADA_ESTE"] = _CambioUso.frm.find("#txtCoordEste").val();
    data["COORDENADA_NORTE"] = _CambioUso.frm.find("#txtCoordNorte").val();
    data["OBSERVACION"] = _CambioUso.frm.find("#txtObservacion").val();
    return data;
}

_CambioUso.fnSubmitForm = function () {
    _CambioUso.frm.submit();
}

_CambioUso.fnInit = function (data) {
    _CambioUso.frm = $("#frmItemCambioUso");

    $.fn.select2.defaults.set("theme", "bootstrap4");
    _CambioUso.frm.find("#ddlCambioUsoId").select2({ minimumResultsForSearch: -1 });
    _CambioUso.frm.find("#ddlZonaId").select2({ minimumResultsForSearch: -1 });
    _CambioUso.frm.find("#ddlAutorizadoId").select2({ minimumResultsForSearch: -1 });
    _CambioUso.fnLoadDatos(data);

    //=====-----Para el registro de datos del formulario-----=====
    //Validación personalizada
    jQuery.validator.addMethod("invalidFrmCambioUso", function (value, element) {
        switch ($(element).attr('id')) {
            case 'ddlCambioUsoId':
                return (value == '0000000') ? false : true;
                break;
            case 'ddlZonaId':
                return (value == '0000000') ? false : true;
                break;
            case 'ddlAutorizadoId':
                return (value == '0000000') ? false : true;
                break;
        }
    });
    _CambioUso.frm.validate(utilSigo.fnValidate({
        rules: {
            ddlCambioUsoId: { invalidFrmCambioUso: true },
            txtArea: { required: true },
            ddlZonaId: { invalidFrmCambioUso: true },
            ddlAutorizadoId: { invalidFrmCambioUso: true },
            txtCoordEste: { required: true },
            txtCoordNorte: { required: true },
            txtObservacion: { required: true }
        },
        messages: {
            ddlCambioUsoId: { invalidFrmCambioUso: "Seleccione el cambio de uso" },
            txtArea: { required: "Ingrese el área" },
            ddlZonaId: { invalidFrmCambioUso: "Seleccione la Zona" },
            ddlAutorizadoId: { invalidFrmCambioUso: "Seleccione si está Autorizado" },
            txtCoordEste: { required: "Ingrese la coordenada este obtenida en campo" },
            txtCoordNorte: { required: "Ingrese la coordenada norte obtenida en campo" },
            txtObservacion: { required: "Ingrese la observación del cambio de uso" }
        },
        fnSubmit: function (form) {
            _CambioUso.fnSaveForm(_CambioUso.fnSetDatos());
        }
    }));
    //Validación de controles que usan Select2
    _CambioUso.frm.find("select.select2-hidden-accessible").on("change", function (e) {
        $(this).valid();
    });
}