"use strict";
var _ActividadInvestigacion = {};

_ActividadInvestigacion.fnSaveForm = function (data) { /*implementado desde donde se instancia*/ }

_ActividadInvestigacion.fnLoadDatos = function (asCodPrograma,data) {
    if (data != null && data != "") {
        _ActividadInvestigacion.frm.find("#hdfRegEstado").val(data["RegEstado"]);
        _ActividadInvestigacion.frm.find("#hdfCodPrograma").val(data["COD_PROGRAMA"]);
        _ActividadInvestigacion.frm.find("#hdfCodSecuencial").val(data["COD_SECUENCIAL"]);
        _ActividadInvestigacion.frm.find("#txtActividad").val(data["ACTIVIDAD_REALIZADA"]);
        _ActividadInvestigacion.frm.find("#txtObjetivo").val(data["OBJETIVO"]);
        _ActividadInvestigacion.frm.find("#txtAvance").val(data["AVANCE_RESULTADO"]);
    } else {
        _ActividadInvestigacion.frm.find("#hdfRegEstado").val("1");
        _ActividadInvestigacion.frm.find("#hdfCodPrograma").val(asCodPrograma);
        _ActividadInvestigacion.frm.find("#hdfCodSecuencial").val("0");
    }
}

_ActividadInvestigacion.fnSetDatos = function () {
    var data = [];
    var regEstado = _ActividadInvestigacion.frm.find("#hdfRegEstado").val();
    data["RegEstado"] = regEstado == "0" ? "2" : regEstado;
    data["COD_PROGRAMA"] = _ActividadInvestigacion.frm.find("#hdfCodPrograma").val();
    data["COD_SECUENCIAL"] = _ActividadInvestigacion.frm.find("#hdfCodSecuencial").val();
    data["ACTIVIDAD_REALIZADA"] = _ActividadInvestigacion.frm.find("#txtActividad").val();
    data["OBJETIVO"] = _ActividadInvestigacion.frm.find("#txtObjetivo").val();
    data["AVANCE_RESULTADO"] = _ActividadInvestigacion.frm.find("#txtAvance").val();
    return data;
}

_ActividadInvestigacion.fnSubmitForm = function () {
    _ActividadInvestigacion.frm.submit();
}

_ActividadInvestigacion.fnInit = function (data,asCodPrograma) {
    _ActividadInvestigacion.frm = $("#frmItemActividadInvestigacion");

    _ActividadInvestigacion.fnLoadDatos(asCodPrograma, data);

    _ActividadInvestigacion.frm.find("#dvDatosObjetivo").hide();
    switch (asCodPrograma) {
        case 21: _ActividadInvestigacion.frm.find("#dvDatosObjetivo").show(); break;
    }

    //=====-----Para el registro de datos del formulario-----=====
    _ActividadInvestigacion.frm.validate(utilSigo.fnValidate({
        rules: {
            txtActividad: { required: true }
        },
        messages: {
            txtActividad: { required: "Ingrese la actividad de investigación" }
        },
        fnSubmit: function (form) {
            _ActividadInvestigacion.fnSaveForm(_ActividadInvestigacion.fnSetDatos());
        }
    }));

    //Validación de controles que usan Select2
    _ActividadInvestigacion.frm.find("select.select2-hidden-accessible").on("change", function (e) {
        $(this).valid();
    });
}