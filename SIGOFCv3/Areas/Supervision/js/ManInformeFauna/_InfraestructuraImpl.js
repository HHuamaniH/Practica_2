"use strict";
var _InfraestructuraImpl = {};

_InfraestructuraImpl.fnSaveForm = function (data) { /*implementado desde donde se instancia*/ }

_InfraestructuraImpl.fnLoadDatos = function (data) {
    if (data != null && data != "") {
        _InfraestructuraImpl.frm.find("#hdfRegEstado").val(data["RegEstado"]);
        _InfraestructuraImpl.frm.find("#hdfCodSecuencial").val(data["COD_SECUENCIAL"]);
        _InfraestructuraImpl.frm.find("#txtDescripcion").val(data["DESCRIPCION"]);
        _InfraestructuraImpl.frm.find("#txtArea").val(data["AREA"]);
        _InfraestructuraImpl.frm.find("#txtUso").val(data["USO"]);
        _InfraestructuraImpl.frm.find("#txtEstado").val(data["ESTADO_CONSERVACION"]);
        _InfraestructuraImpl.frm.find("#txtObjetivo").val(data["OBJETIVO"]);
    } else {
        _InfraestructuraImpl.frm.find("#hdfRegEstado").val("1");
        _InfraestructuraImpl.frm.find("#hdfCodSecuencial").val("0");
    }
}

_InfraestructuraImpl.fnSetDatos = function () {
    var data = [];
    var regEstado = _InfraestructuraImpl.frm.find("#hdfRegEstado").val();
    data["RegEstado"] = regEstado == "0" ? "2" : regEstado;
    data["COD_SECUENCIAL"] = _InfraestructuraImpl.frm.find("#hdfCodSecuencial").val();
    data["DESCRIPCION"] = _InfraestructuraImpl.frm.find("#txtDescripcion").val();
    data["AREA"] = _InfraestructuraImpl.frm.find("#txtArea").val();
    data["USO"] = _InfraestructuraImpl.frm.find("#txtUso").val();
    data["ESTADO_CONSERVACION"] = _InfraestructuraImpl.frm.find("#txtEstado").val();
    data["OBJETIVO"] = _InfraestructuraImpl.frm.find("#txtObjetivo").val();
    return data;
}

_InfraestructuraImpl.fnSubmitForm = function () {
    _InfraestructuraImpl.frm.submit();
}

_InfraestructuraImpl.fnInit = function (data) {
    _InfraestructuraImpl.frm = $("#frmItemInfraestructuraImpl");

    _InfraestructuraImpl.fnLoadDatos(data);

    //=====-----Para el registro de datos del formulario-----=====
    _InfraestructuraImpl.frm.validate(utilSigo.fnValidate({
        rules: {
            txtDescripción: { required: true },
            txtArea: { required: true },
            txtUso: { required: true }
        },
        messages: {
            txtDescripción: { required: "Ingrese la descripción" },
            txtArea: { required: "Ingrese el área" },
            txtUso: { required: "Ingrese el uso" }
        },
        fnSubmit: function (form) {
            _InfraestructuraImpl.fnSaveForm(_InfraestructuraImpl.fnSetDatos());
        }
    }));
    //Validación de controles que usan Select2
    _InfraestructuraImpl.frm.find("select.select2-hidden-accessible").on("change", function (e) {
        $(this).valid();
    });
}