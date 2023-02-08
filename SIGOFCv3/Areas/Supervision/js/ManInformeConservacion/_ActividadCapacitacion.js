"use strict";
var _ActividadCapacitacion = {};

_ActividadCapacitacion.fnSaveForm = function (data) { /*implementado desde donde se instancia*/ }

_ActividadCapacitacion.fnLoadDatos = function (asCodPrograma, data) {
    if (data != null && data != "") {
        _ActividadCapacitacion.frm.find("#hdfRegEstado").val(data["RegEstado"]);
        _ActividadCapacitacion.frm.find("#hdfCodPrograma").val(data["COD_PROGRAMA"]);
        _ActividadCapacitacion.frm.find("#hdfCodSecuencial").val(data["COD_SECUENCIAL"]);
        _ActividadCapacitacion.frm.find("#txtActividad").val(data["ACTIVIDAD_REALIZADA"]);
        _ActividadCapacitacion.frm.find("#txtFechaRealiza").val(data["FECHA_REALIZADA"]);
        _ActividadCapacitacion.frm.find("#txtNumParticipante").val(data["NUM_PERSONA"]);
        _ActividadCapacitacion.frm.find("#ddlEstadoDocumentoId").select2("val",[data["ESTADO_DOCUMENTO"] == true ? "SI" : "NO"]);
        _ActividadCapacitacion.frm.find("#txtTipoRegistro").val(data["DESC_TIPO_REGISTRO"]);
    } else {
        _ActividadCapacitacion.frm.find("#hdfRegEstado").val("1");
        _ActividadCapacitacion.frm.find("#hdfCodPrograma").val(asCodPrograma);
        _ActividadCapacitacion.frm.find("#hdfCodSecuencial").val("0");
    }
}

_ActividadCapacitacion.fnSetDatos = function () {
    var data = [];
    var regEstado = _ActividadCapacitacion.frm.find("#hdfRegEstado").val();
    data["RegEstado"] = regEstado == "0" ? "2" : regEstado;
    data["COD_PROGRAMA"] = _ActividadCapacitacion.frm.find("#hdfCodPrograma").val();
    data["COD_SECUENCIAL"] = _ActividadCapacitacion.frm.find("#hdfCodSecuencial").val();
    data["ACTIVIDAD_REALIZADA"] = _ActividadCapacitacion.frm.find("#txtActividad").val();
    data["FECHA_REALIZADA"] = _ActividadCapacitacion.frm.find("#txtFechaRealiza").val();
    data["NUM_PERSONA"] = _ActividadCapacitacion.frm.find("#txtNumParticipante").val();
    data["ESTADO_DOCUMENTO"] = _ActividadCapacitacion.frm.find("#ddlEstadoDocumentoId").val() == "SI" ? true : false;
    data["DESC_TIPO_REGISTRO"] = _ActividadCapacitacion.frm.find("#txtTipoRegistro").val();
    return data;
}

_ActividadCapacitacion.fnSubmitForm = function () {
    _ActividadCapacitacion.frm.submit();
}

_ActividadCapacitacion.fnInit = function (data,asCodPrograma) {
    _ActividadCapacitacion.frm = $("#frmItemActividadCapacitacion");

    $.fn.select2.defaults.set("theme", "bootstrap4");
    _ActividadCapacitacion.frm.find("#ddlEstadoDocumentoId").select2({ minimumResultsForSearch: -1 });
    utilSigo.fnFormatDate(_ActividadCapacitacion.frm.find("#txtFechaRealiza"));

    _ActividadCapacitacion.fnLoadDatos(asCodPrograma, data);

    _ActividadCapacitacion.frm.find("#dvDatosCapacitacion").hide();
    switch (asCodPrograma) {
        case 20: _ActividadCapacitacion.frm.find("#dvDatosCapacitacion").show(); break;
    }

    //=====-----Para el registro de datos del formulario-----=====
    _ActividadCapacitacion.frm.validate(utilSigo.fnValidate({
        rules: {
            txtActividad: { required: true },
            txtFechaRealiza: { required: true },
            txtNumParticipante: { required: true }
        },
        messages: {
            txtActividad: { required: "Ingrese la actividad realizada" },
            txtFechaRealiza: { required: "Ingrese la fecha de realización" },
            txtNumParticipante: { required: "Ingrese el número de participantes" }
        },
        fnSubmit: function (form) {
            _ActividadCapacitacion.fnSaveForm(_ActividadCapacitacion.fnSetDatos());
        }
    }));
    //Validación de controles que usan Select2
    _ActividadCapacitacion.frm.find("select.select2-hidden-accessible").on("change", function (e) {
        $(this).valid();
    });
}