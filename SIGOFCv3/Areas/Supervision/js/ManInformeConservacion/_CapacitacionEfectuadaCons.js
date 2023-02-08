"use strict";
var _CapacitacionEfectuadaCons = {};

_CapacitacionEfectuadaCons.fnSaveForm = function (data) { /*implementado desde donde se instancia*/ }

_CapacitacionEfectuadaCons.fnLoadDatos = function (asCodPrograma, data) {
    if (data != null && data != "") {
        _CapacitacionEfectuadaCons.frm.find("#hdfRegEstado").val(data["RegEstado"]);
        _CapacitacionEfectuadaCons.frm.find("#hdfCodPrograma").val(data["COD_PROGRAMA"]);
        _CapacitacionEfectuadaCons.frm.find("#hdfCodSecuencial").val(data["COD_SECUENCIAL"]);
        _CapacitacionEfectuadaCons.frm.find("#txtCapacitacion").val(data["ACTIVIDAD_REALIZADA"]);
        _CapacitacionEfectuadaCons.frm.find("#txtNumParticipante").val(data["NUM_PERSONA"]);
        _CapacitacionEfectuadaCons.frm.find("#txtLugar").val(data["LUGAR_CAPACITACION"]);
        _CapacitacionEfectuadaCons.frm.find("#txtObjetivo").val(data["OBJETIVO"]);
        _CapacitacionEfectuadaCons.frm.find("#txtObservacion").val(data["OBSERVACION"]);
    } else {
        _CapacitacionEfectuadaCons.frm.find("#hdfRegEstado").val("1");
        _CapacitacionEfectuadaCons.frm.find("#hdfCodPrograma").val(asCodPrograma);
        _CapacitacionEfectuadaCons.frm.find("#hdfCodSecuencial").val("0");
    }
}

_CapacitacionEfectuadaCons.fnSetDatos = function () {
    var data = [];
    var regEstado = _CapacitacionEfectuadaCons.frm.find("#hdfRegEstado").val();
    data["RegEstado"] = regEstado == "0" ? "2" : regEstado;
    data["COD_PROGRAMA"] = _CapacitacionEfectuadaCons.frm.find("#hdfCodPrograma").val();
    data["COD_SECUENCIAL"] = _CapacitacionEfectuadaCons.frm.find("#hdfCodSecuencial").val();
    data["ACTIVIDAD_REALIZADA"] = _CapacitacionEfectuadaCons.frm.find("#txtCapacitacion").val();
    data["NUM_PERSONA"] = _CapacitacionEfectuadaCons.frm.find("#txtNumParticipante").val();
    data["LUGAR_CAPACITACION"] = _CapacitacionEfectuadaCons.frm.find("#txtLugar").val();
    data["OBJETIVO"] = _CapacitacionEfectuadaCons.frm.find("#txtObjetivo").val();
    data["OBSERVACION"] = _CapacitacionEfectuadaCons.frm.find("#txtObservacion").val();
    return data;
}

_CapacitacionEfectuadaCons.fnSubmitForm = function () {
    _CapacitacionEfectuadaCons.frm.submit();
}

_CapacitacionEfectuadaCons.fnInit = function (data, asCodPrograma) {
    _CapacitacionEfectuadaCons.frm = $("#frmItemCapacitacionCons");

    _CapacitacionEfectuadaCons.fnLoadDatos(asCodPrograma, data);

    //=====-----Para el registro de datos del formulario-----=====
    _CapacitacionEfectuadaCons.frm.validate(utilSigo.fnValidate({
        rules: {
            txtCapacitacion: { required: true },
            txtNumParticipante: { required: true }
        },
        messages: {
            txtCapacitacion: { required: "Ingrese el nombre de la capacitación" },
            txtNumParticipante: { required: "Ingrese el número de participantes" }
        },
        fnSubmit: function (form) {
            _CapacitacionEfectuadaCons.fnSaveForm(_CapacitacionEfectuadaCons.fnSetDatos());
        }
    }));

    //Validación de controles que usan Select2
    _CapacitacionEfectuadaCons.frm.find("select.select2-hidden-accessible").on("change", function (e) {
        $(this).valid();
    });
}