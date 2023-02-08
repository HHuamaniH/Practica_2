"use strict";
var _ActividadCapacitacion = {};

_ActividadCapacitacion.fnSaveForm = function (data, data_eli) { /*implementado desde donde se instancia*/ }

_ActividadCapacitacion.fnLoadDatos = function (data) {
    if (data != null && data != "") {
        _ActividadCapacitacion.frm.find("#hdfRegEstado").val(data["RegEstado"]);
        _ActividadCapacitacion.frm.find("#hdfCodCapacitacion").val(data["COD_EXSITUCAPACITACION"]);
        _ActividadCapacitacion.frm.find("#txtTema").val(data["TEMA"]);
        _ActividadCapacitacion.frm.find("#txtNumBeneficiado").val(data["NUM_BENEFICIADOS"]);
        _ActividadCapacitacion.frm.find("#txtCapacitador").val(data["CAPACITADOR"]);
    } else {
        _ActividadCapacitacion.frm.find("#hdfRegEstado").val("1");
        _ActividadCapacitacion.frm.find("#hdfCodCapacitacion").val("");
    }
}

_ActividadCapacitacion.fnSetDatos = function () {
    var data = [];
    var regEstado = _ActividadCapacitacion.frm.find("#hdfRegEstado").val();
    data["RegEstado"] = regEstado == "0" ? "2" : regEstado;
    data["COD_EXSITUCAPACITACION"] = _ActividadCapacitacion.frm.find("#hdfCodCapacitacion").val();
    data["TEMA"] = _ActividadCapacitacion.frm.find("#txtTema").val();
    data["NUM_BENEFICIADOS"] = _ActividadCapacitacion.frm.find("#txtNumBeneficiado").val();
    data["CAPACITADOR"] = _ActividadCapacitacion.frm.find("#txtCapacitador").val();
    return data;
}

_ActividadCapacitacion.fnSubmitForm = function () {
    _ActividadCapacitacion.frm.submit();
}

_ActividadCapacitacion.fnInit = function (data) {
    _ActividadCapacitacion.frm = $("#frmItemActCapacitacion");

    _ActividadCapacitacion.fnLoadDatos(data);

    //=====-----Para el registro de datos del formulario-----=====
    _ActividadCapacitacion.frm.validate(utilSigo.fnValidate({
        rules: {
            txtTema: { required: true },
            txtNumBeneficiado: { required: true },
            txtCapacitador: { required: true }
        },
        messages: {
            txtTema: { required: "Ingrese el tema" },
            txtNumBeneficiado: { required: "Ingrese el número de personal beneficiado" },
            txtCapacitador: { required: "Ingrese la entidad o profesional capacitador" }
        },
        fnSubmit: function (form) {
            _ActividadCapacitacion.fnSaveForm(_ActividadCapacitacion.fnSetDatos());
        }
    }));
}