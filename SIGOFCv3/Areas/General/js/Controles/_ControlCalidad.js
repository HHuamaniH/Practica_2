"use strict";
var _ControlCalidad = {};

_ControlCalidad.fnShowObservacionCalidad = function () {
    _ControlCalidad.frm.find("#dvObservacionCalidad").hide("slow");
    if ((_ControlCalidad.frm.find("#ddlIndicadorId").val() == "0000007") && (_ControlCalidad.frm.find("#hdnDisableControl").val() == "False")) {
        _ControlCalidad.frm.find("#dvObservacionCalidad").show("slow");
    }
}

_ControlCalidad.fnInit = function () {
    $.fn.select2.defaults.set("theme", "bootstrap4");
    _ControlCalidad.frm.find("#ddlIndicadorId").select2();
    _ControlCalidad.frm.find("#dvObservacionSubsanar").hide();
    if ((_ControlCalidad.frm.find("#ddlIndicadorId").val() == "0000007") && (_ControlCalidad.frm.find("#hdnDisableControl").val() == "False")) {
        _ControlCalidad.frm.find("#dvObservacionSubsanar").show();
    }

    _ControlCalidad.frm.find("#ddlIndicadorId").prop("disabled", "");
    if (_ControlCalidad.frm.find("#ddlIndicadorEnable").val() != "True") {
        _ControlCalidad.frm.find("#ddlIndicadorId").prop("disabled", "disabled");
    }

    //CKEDITOR.replace('txtControlCalidadObservaciones', {
    //    toolbar: initSigo.configuracionCKEDITOR
    //});
}

_ControlCalidad.fnGetDatosControlCalidad = function () {
    var datosCalidad = {};
    datosCalidad.ddlIndicadorId = _ControlCalidad.frm.find("#ddlIndicadorId").val();

    if (datosCalidad.ddlIndicadorId == "0000007") {
        //datosCalidad.txtControlCalidadObservaciones = CKEDITOR.instances["txtControlCalidadObservaciones"].getData();
        datosCalidad.txtControlCalidadObservaciones = _ControlCalidad.frm.find("#txtControlCalidadObservaciones").val();
    }
    datosCalidad.chkObsSubsanada = utilSigo.fnGetValChk(_ControlCalidad.frm.find("#chkObsSubsanada"));
    return datosCalidad;
}

$(document).ready(function () {
    _ControlCalidad.frm = $("#frmControlCalidad");

    _ControlCalidad.fnInit();

    _ControlCalidad.fnShowObservacionCalidad();
    _ControlCalidad.frm.find("#ddlIndicadorId").change(function () {
        _ControlCalidad.fnShowObservacionCalidad();
    });

    if (_ControlCalidad.frm.find("#hdfCodGrupoUsuario").val() != "0000011" && _ControlCalidad.frm.find("#hdfCodGrupoUsuario").val() != "0000001") {
        _ControlCalidad.frm.find("#chkPublicar").prop("disabled", "disabled");
    }

    _ControlCalidad.frm.find("select.select2-hidden-accessible").on("change", function (e) {
        $(this).valid();
    });
});