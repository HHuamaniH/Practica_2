"use strict";
var _ActividadInvestigacion = {};

_ActividadInvestigacion.fnSaveForm = function (data, data_eli) { /*implementado desde donde se instancia*/ }

_ActividadInvestigacion.fnLoadDatos = function (data) {
    if (data != null && data != "") {
        _ActividadInvestigacion.frm.find("#hdfRegEstado").val(data["RegEstado"]);
        _ActividadInvestigacion.frm.find("#hdfCodSecuencial").val(data["COD_SECUENCIAL"]);
        _ActividadInvestigacion.frm.find("#chkPublicar").prop("checked",data["PUBLICADO"]);
        _ActividadInvestigacion.frm.find("#txtFechaPublicacion").val(data["FECHA_PUBLICACION"]);
        _ActividadInvestigacion.frm.find("#txtInvestigacion").val(data["INVESTIGACION_REALIZADA"]);
        _ActividadInvestigacion.frm.find("#txtObjetivo").val(data["OBJETIVO"]);
    } else {
        _ActividadInvestigacion.frm.find("#hdfRegEstado").val("1");
        _ActividadInvestigacion.frm.find("#hdfCodSecuencial").val("0");
    }
}

_ActividadInvestigacion.fnSetDatos = function () {
    var data = [];
    var regEstado = _ActividadInvestigacion.frm.find("#hdfRegEstado").val();
    data["RegEstado"] = regEstado == "0" ? "2" : regEstado;
    data["COD_SECUENCIAL"] = _ActividadInvestigacion.frm.find("#hdfCodSecuencial").val();
    data["PUBLICADO"] = utilSigo.fnGetValChk(_ActividadInvestigacion.frm.find("#chkPublicar"));
    data["FECHA_PUBLICACION"] = _ActividadInvestigacion.frm.find("#txtFechaPublicacion").val();
    data["INVESTIGACION_REALIZADA"] = _ActividadInvestigacion.frm.find("#txtInvestigacion").val();
    data["OBJETIVO"] = _ActividadInvestigacion.frm.find("#txtObjetivo").val();
    return data;
}

_ActividadInvestigacion.fnSubmitForm = function () {
    _ActividadInvestigacion.frm.submit();
}

_ActividadInvestigacion.fnInit = function (data) {
    _ActividadInvestigacion.frm = $("#frmItemActInvestigacion");

    utilSigo.fnFormatDate(_ActividadInvestigacion.frm.find("#txtFechaPublicacion"));

    _ActividadInvestigacion.fnLoadDatos(data);

    //=====-----Para el registro de datos del formulario-----=====
    _ActividadInvestigacion.frm.validate(utilSigo.fnValidate({
        rules: {
            txtInvestigacion: { required: true }
        },
        messages: {
            txtInvestigacion: { required: "Ingrese la investigación realizada" }
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