"use strict";
var _ActividadObligacion = {};

_ActividadObligacion.fnSaveForm = function (data) { /*implementado desde donde se instancia*/ }

_ActividadObligacion.fnLoadDatos = function (data, codObligacion) {
    if (data != null && data != "") {
        _ActividadObligacion.frm.find("#hdfRegEstado").val(data["RegEstado"]);
        _ActividadObligacion.frm.find("#hdfCodObligacion").val(data["COD_OCONTRACTUAL"]);
        _ActividadObligacion.frm.find("#hdfCodSecuencial").val(data["COD_SECUENCIAL"]);
        _ActividadObligacion.frm.find("#txtActividad").val(data["ACTIVIDAD_ACTOS"]);
        _ActividadObligacion.frm.find("#txtObservacion").val(data["OBSERVACION"]);
    } else {
        _ActividadObligacion.frm.find("#hdfRegEstado").val("1");
        _ActividadObligacion.frm.find("#hdfCodObligacion").val(codObligacion);
        _ActividadObligacion.frm.find("#hdfCodSecuencial").val("0");
    }
}

_ActividadObligacion.fnSetDatos = function () {
    var data = [];
    var regEstado = _ActividadObligacion.frm.find("#hdfRegEstado").val();
    data["RegEstado"] = regEstado == "0" ? "2" : regEstado;
    data["COD_OCONTRACTUAL"] = _ActividadObligacion.frm.find("#hdfCodObligacion").val();
    data["COD_SECUENCIAL"] = _ActividadObligacion.frm.find("#hdfCodSecuencial").val();
    data["ACTIVIDAD_ACTOS"] = _ActividadObligacion.frm.find("#txtActividad").val();
    data["OBSERVACION"] = _ActividadObligacion.frm.find("#txtObservacion").val();
    return data;
}

_ActividadObligacion.fnSubmitForm = function () {
    _ActividadObligacion.frm.submit();
}

_ActividadObligacion.fnInit = function (data, codObligacion) {
    _ActividadObligacion.frm = $("#frmItemActividadObligacion");

    _ActividadObligacion.fnLoadDatos(data, codObligacion);

    //=====-----Para el registro de datos del formulario-----=====
    _ActividadObligacion.frm.validate(utilSigo.fnValidate({
        rules: {
            txtActividad: { required: true }
        },
        messages: {
            txtActividad: { required: "Ingrese la actividad ejecutada" }
        },
        fnSubmit: function (form) {
            _ActividadObligacion.fnSaveForm(_ActividadObligacion.fnSetDatos());
        }
    }));
    //Validación de controles que usan Select2
    _ActividadObligacion.frm.find("select.select2-hidden-accessible").on("change", function (e) {
        $(this).valid();
    });
}