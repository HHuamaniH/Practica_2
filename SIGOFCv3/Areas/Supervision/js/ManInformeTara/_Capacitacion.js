"use strict";
var _Capacitacion = {};

_Capacitacion.fnSaveForm = function (data) { /*implementado desde donde se instancia*/ }

_Capacitacion.fnLoadDatos = function (data) {
    if (data != null && data != "") {
        _Capacitacion.frm.find("#hdfRegEstado").val(data["RegEstado"]);
        _Capacitacion.frm.find("#hdfCodSecuencial").val(data["COD_SECUENCIAL"]);
        _Capacitacion.frm.find("#txtNombre").val(data["NOMBRES"]);
        _Capacitacion.frm.find("#txtNumPersona").val(data["NUM_PERSONA"]);
        _Capacitacion.frm.find("#txtDescripcion").val(data["DESCRIPCION"]);
    } else {
        _Capacitacion.frm.find("#hdfRegEstado").val("1");
        _Capacitacion.frm.find("#hdfCodSecuencial").val("0");
    }
}

_Capacitacion.fnSetDatos = function () {
    var data = [];
    var regEstado = _Capacitacion.frm.find("#hdfRegEstado").val();
    data["RegEstado"] = regEstado == "0" ? "2" : regEstado;
    data["COD_SECUENCIAL"] = _Capacitacion.frm.find("#hdfCodSecuencial").val();
    data["NOMBRES"] = _Capacitacion.frm.find("#txtNombre").val();
    data["NUM_PERSONA"] = _Capacitacion.frm.find("#txtNumPersona").val();
    data["DESCRIPCION"] = _Capacitacion.frm.find("#txtDescripcion").val();
    return data;
}

_Capacitacion.fnSubmitForm = function () {
    _Capacitacion.frm.submit();
}

_Capacitacion.fnInit = function (data) {
    _Capacitacion.frm = $("#frmItemCapacitacion");

    _Capacitacion.fnLoadDatos(data);

    //=====-----Para el registro de datos del formulario-----=====
    _Capacitacion.frm.validate(utilSigo.fnValidate({
        rules: {
            txtNombre: { required: true },
            txtNumPersona: { required: true }
        },
        messages: {
            txtNombre: { required: "Ingrese el nombre de la capacitación" },
            txtNumPersona: { required: "Ingrese el número de personas" }
        },
        fnSubmit: function (form) {
            _Capacitacion.fnSaveForm(_Capacitacion.fnSetDatos());
        }
    }));

    //Validación de controles que usan Select2
    _Capacitacion.frm.find("select.select2-hidden-accessible").on("change", function (e) {
        $(this).valid();
    });
}