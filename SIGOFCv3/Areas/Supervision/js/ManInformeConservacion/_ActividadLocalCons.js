"use strict";
var _ActividadLocalCons = {};

_ActividadLocalCons.fnSaveForm = function (data) { /*implementado desde donde se instancia*/ }

_ActividadLocalCons.fnLoadDatos = function (asCodPrograma, data) {
    if (data != null && data != "") {
        _ActividadLocalCons.frm.find("#hdfRegEstado").val(data["RegEstado"]);
        _ActividadLocalCons.frm.find("#hdfCodPrograma").val(data["COD_PROGRAMA"]);
        _ActividadLocalCons.frm.find("#hdfCodSecuencial").val(data["COD_SECUENCIAL"]);
        _ActividadLocalCons.frm.find("#txtActividad").val(data["ACTIVIDAD_REALIZADA"]);
        _ActividadLocalCons.frm.find("#txtNumParticipante").val(data["NUM_PERSONA"]);
        _ActividadLocalCons.frm.find("#txtComunidad").val(data["NOMBRE_COMUNIDAD_SECTOR"]);
        _ActividadLocalCons.frm.find("#txtObjetivo").val(data["OBJETIVO"]);
        _ActividadLocalCons.frm.find("#txtObservacion").val(data["OBSERVACION"]);
    } else {
        _ActividadLocalCons.frm.find("#hdfRegEstado").val("1");
        _ActividadLocalCons.frm.find("#hdfCodPrograma").val(asCodPrograma);
        _ActividadLocalCons.frm.find("#hdfCodSecuencial").val("0");
    }
}

_ActividadLocalCons.fnSetDatos = function () {
    var data = [];
    var regEstado = _ActividadLocalCons.frm.find("#hdfRegEstado").val();
    data["RegEstado"] = regEstado == "0" ? "2" : regEstado;
    data["COD_PROGRAMA"] = _ActividadLocalCons.frm.find("#hdfCodPrograma").val();
    data["COD_SECUENCIAL"] = _ActividadLocalCons.frm.find("#hdfCodSecuencial").val();
    data["ACTIVIDAD_REALIZADA"] = _ActividadLocalCons.frm.find("#txtActividad").val();
    data["NUM_PERSONA"] = _ActividadLocalCons.frm.find("#txtNumParticipante").val();
    data["NOMBRE_COMUNIDAD_SECTOR"] = _ActividadLocalCons.frm.find("#txtComunidad").val();
    data["OBJETIVO"] = _ActividadLocalCons.frm.find("#txtObjetivo").val();
    data["OBSERVACION"] = _ActividadLocalCons.frm.find("#txtObservacion").val();
    return data;
}

_ActividadLocalCons.fnSubmitForm = function () {
    _ActividadLocalCons.frm.submit();
}

_ActividadLocalCons.fnInit = function (data, asCodPrograma) {
    _ActividadLocalCons.frm = $("#frmItemActividadLocalCons");

    _ActividadLocalCons.fnLoadDatos(asCodPrograma, data);

    //=====-----Para el registro de datos del formulario-----=====
    _ActividadLocalCons.frm.validate(utilSigo.fnValidate({
        rules: {
            txtActividad: { required: true },
            txtNumParticipante: { required: true }
        },
        messages: {
            txtActividad: { required: "Ingrese la actividad desarrollada" },
            txtNumParticipante: { required: "Ingrese el número de participantes" }
        },
        fnSubmit: function (form) {
            _ActividadLocalCons.fnSaveForm(_ActividadLocalCons.fnSetDatos());
        }
    }));

    //Validación de controles que usan Select2
    _ActividadLocalCons.frm.find("select.select2-hidden-accessible").on("change", function (e) {
        $(this).valid();
    });
}