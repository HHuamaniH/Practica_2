"use strict";
var _ResponsabilidadSocial = {};

_ResponsabilidadSocial.fnSaveForm = function (data) { /*implementado desde donde se instancia*/ }

_ResponsabilidadSocial.fnLoadDatos = function (data) {
    if (data != null && data != "") {
        _ResponsabilidadSocial.frm.find("#hdfRegEstado").val(data["RegEstado"]);
        _ResponsabilidadSocial.frm.find("#hdfCodPrograma").val(data["COD_PROGRAMA"]);
        _ResponsabilidadSocial.frm.find("#hdfCodSecuencial").val(data["COD_SECUENCIAL"]);
        _ResponsabilidadSocial.frm.find("#txtActividad").val(data["ACTIVIDAD_REALIZADA"]);
        _ResponsabilidadSocial.frm.find("#txtNumParticipante").val(data["NUM_PERSONA"]);
        _ResponsabilidadSocial.frm.find("#txtLugar").val(data["LUGAR_CAPACITACION"]);
        _ResponsabilidadSocial.frm.find("#txtObjetivo").val(data["OBJETIVO"]);
        _ResponsabilidadSocial.frm.find("#txtObservacion").val(data["OBSERVACION"]);
    } else {
        _ResponsabilidadSocial.frm.find("#hdfRegEstado").val("1");
        _ResponsabilidadSocial.frm.find("#hdfCodPrograma").val(27);//DOC.ISUPERVISION_PROGRAMA (COD_PROGRAMA)
        _ResponsabilidadSocial.frm.find("#hdfCodSecuencial").val("0");
    }
}

_ResponsabilidadSocial.fnSetDatos = function () {
    var data = [];
    var regEstado = _ResponsabilidadSocial.frm.find("#hdfRegEstado").val();
    data["RegEstado"] = regEstado == "0" ? "2" : regEstado;
    data["COD_PROGRAMA"] = _ResponsabilidadSocial.frm.find("#hdfCodPrograma").val();
    data["COD_SECUENCIAL"] = _ResponsabilidadSocial.frm.find("#hdfCodSecuencial").val();
    data["ACTIVIDAD_REALIZADA"] = _ResponsabilidadSocial.frm.find("#txtActividad").val();
    data["NUM_PERSONA"] = _ResponsabilidadSocial.frm.find("#txtNumParticipante").val();
    data["LUGAR_CAPACITACION"] = _ResponsabilidadSocial.frm.find("#txtLugar").val();
    data["OBJETIVO"] = _ResponsabilidadSocial.frm.find("#txtObjetivo").val();
    data["OBSERVACION"] = _ResponsabilidadSocial.frm.find("#txtObservacion").val();
    return data;
}

_ResponsabilidadSocial.fnSubmitForm = function () {
    _ResponsabilidadSocial.frm.submit();
}

_ResponsabilidadSocial.fnInit = function (data) {
    _ResponsabilidadSocial.frm = $("#frmItemResponsabilidadSocial");

    _ResponsabilidadSocial.fnLoadDatos(data);

    //=====-----Para el registro de datos del formulario-----=====
    _ResponsabilidadSocial.frm.validate(utilSigo.fnValidate({
        rules: {
            txtActividad: { required: true },
            txtNumParticipante: { required: true },
            txtLugar: { required: true }
        },
        messages: {
            txtActividad: { required: "Ingrese la actividad realizada" },
            txtNumParticipante: { required: "Ingrese el número de participantes" },
            txtLugar: { required: "Ingrese el lugar de capacitación" }
        },
        fnSubmit: function (form) {
            _ResponsabilidadSocial.fnSaveForm(_ResponsabilidadSocial.fnSetDatos());
        }
    }));
    //Validación de controles que usan Select2
    _ResponsabilidadSocial.frm.find("select.select2-hidden-accessible").on("change", function (e) {
        $(this).valid();
    });
}