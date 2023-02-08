"use strict";
var _ManejoImpacto = {};

_ManejoImpacto.fnSaveForm = function (data) { /*implementado desde donde se instancia*/ }

_ManejoImpacto.fnLoadDatos = function (data) {
    if (data != null && data != "") {
        _ManejoImpacto.frm.find("#hdfRegEstado").val(data["RegEstado"]);
        _ManejoImpacto.frm.find("#hdfCodSecuencial").val(data["COD_SECUENCIAL"]);
        _ManejoImpacto.frm.find("#txtTipoImpacto").val(data["TIPO_IMPACTO"]);
        _ManejoImpacto.frm.find("#txtRiesgo").val(data["RIESGO_POTENCIAL"]);
        _ManejoImpacto.frm.find("#txtActividad").val(data["ACTIVIDAD"]);
        _ManejoImpacto.frm.find("#txtResultado").val(data["AVANCE_RESULTADO"]);
    } else {
        _ManejoImpacto.frm.find("#hdfRegEstado").val("1");
        _ManejoImpacto.frm.find("#hdfCodSecuencial").val("0");
    }
}

_ManejoImpacto.fnSetDatos = function () {
    var data = [];
    var regEstado = _ManejoImpacto.frm.find("#hdfRegEstado").val();
    data["RegEstado"] = regEstado == "0" ? "2" : regEstado;
    data["COD_SECUENCIAL"] = _ManejoImpacto.frm.find("#hdfCodSecuencial").val();
    data["TIPO_IMPACTO"] = _ManejoImpacto.frm.find("#txtTipoImpacto").val();
    data["RIESGO_POTENCIAL"] = _ManejoImpacto.frm.find("#txtRiesgo").val();
    data["ACTIVIDAD"] = _ManejoImpacto.frm.find("#txtActividad").val();
    data["AVANCE_RESULTADO"] = _ManejoImpacto.frm.find("#txtResultado").val();
    return data;
}

_ManejoImpacto.fnSubmitForm = function () {
    _ManejoImpacto.frm.submit();
}

_ManejoImpacto.fnInit = function (data) {
    _ManejoImpacto.frm = $("#frmItemManejoImpacto");

    _ManejoImpacto.fnLoadDatos(data);

    //=====-----Para el registro de datos del formulario-----=====
    _ManejoImpacto.frm.validate(utilSigo.fnValidate({
        rules: {
            txtTipoImpacto: { required: true },
            txtRiesgo: { required: true },
            txtActividad: { required: true },
            txtResultado: { required: true }
        },
        messages: {
            txtTipoImpacto: { required: "Ingrese el tipo de impacto" },
            txtRiesgo: { required: "Ingrese el riesgo potencial" },
            txtActividad: { required: "Ingrese las actividades preventivas/correctivas" },
            txtResultado: { required: "Ingrese el resultado" }
        },
        fnSubmit: function (form) {
            _ManejoImpacto.fnSaveForm(_ManejoImpacto.fnSetDatos());
        }
    }));
    //Validación de controles que usan Select2
    _ManejoImpacto.frm.find("select.select2-hidden-accessible").on("change", function (e) {
        $(this).valid();
    });
}