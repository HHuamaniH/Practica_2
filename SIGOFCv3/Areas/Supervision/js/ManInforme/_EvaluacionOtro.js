"use strict";
var _EvaluacionOtro = {};

_EvaluacionOtro.fnSaveForm = function (data) { /*implementado desde donde se instancia*/ }

_EvaluacionOtro.fnLoadDatos = function (data) {
    if (data != null && data != "") {
        _EvaluacionOtro.frm.find("#hdfRegEstado").val(data["RegEstado"]);
        _EvaluacionOtro.frm.find("#hdfCodSecuencial").val(data["COD_SECUENCIAL"]);
        _EvaluacionOtro.frm.find("#txtEvaluacion").val(data["EVALUACION"]);
        _EvaluacionOtro.frm.find("#ddlZonaId").select2("val", [data["ZONA"]]);
        _EvaluacionOtro.frm.find("#txtCoordEste").val(data["COORDENADA_ESTE"]);
        _EvaluacionOtro.frm.find("#txtCoordNorte").val(data["COORDENADA_NORTE"]);
        _EvaluacionOtro.frm.find("#txtDescripcion").val(data["DESCRIPCION"]);
    } else {
        _EvaluacionOtro.frm.find("#hdfRegEstado").val("1");
        _EvaluacionOtro.frm.find("#hdfCodSecuencial").val("0");
    }
}

_EvaluacionOtro.fnSetDatos = function () {
    var data = [];
    var regEstado = _EvaluacionOtro.frm.find("#hdfRegEstado").val();
    data["RegEstado"] = regEstado == "0" ? "2" : regEstado;
    data["COD_SECUENCIAL"] = _EvaluacionOtro.frm.find("#hdfCodSecuencial").val();
    data["EVALUACION"] = _EvaluacionOtro.frm.find("#txtEvaluacion").val();
    data["ZONA"] = _EvaluacionOtro.frm.find("#ddlZonaId").val();
    data["COORDENADA_ESTE"] = _EvaluacionOtro.frm.find("#txtCoordEste").val();
    data["COORDENADA_NORTE"] = _EvaluacionOtro.frm.find("#txtCoordNorte").val();
    data["DESCRIPCION"] = _EvaluacionOtro.frm.find("#txtDescripcion").val();
    return data;
}

_EvaluacionOtro.fnSubmitForm = function () {
    _EvaluacionOtro.frm.submit();
}

_EvaluacionOtro.fnInit = function (data) {
    _EvaluacionOtro.frm = $("#frmItemEvaluacionOtro");

    $.fn.select2.defaults.set("theme", "bootstrap4");
    _EvaluacionOtro.frm.find("#ddlZonaId").select2({ minimumResultsForSearch: -1 });

    _EvaluacionOtro.fnLoadDatos(data);

    //=====-----Para el registro de datos del formulario-----=====
    //Validación personalizada
    jQuery.validator.addMethod("invalidFrmEvalOtro", function (value, element) {
        switch ($(element).attr('id')) {
            case 'ddlZonaId':
                return (value == '0000000') ? false : true;
                break
        }
    });
    _EvaluacionOtro.frm.validate(utilSigo.fnValidate({
        rules: {
            txtEvaluacion: { required: true },
            ddlZonaId: { invalidFrmEvalOtro: true },
            txtCoordEste: { required: true },
            txtCoordNorte: { required: true }
        },
        messages: {
            txtEvaluacion: { required: "Ingrese el punto de evaluación" },
            ddlZonaId: { invalidFrmEvalOtro: "Seleccione la zona UTM" },
            txtCoordEste: { required: "Ingrese la coordenada este" },
            txtCoordNorte: { required: "Ingrese la coordenada norte" }
        },
        fnSubmit: function (form) {
            _EvaluacionOtro.fnSaveForm(_EvaluacionOtro.fnSetDatos());
        }
    }));
    //Validación de controles que usan Select2
    _EvaluacionOtro.frm.find("select.select2-hidden-accessible").on("change", function (e) {
        $(this).valid();
    });
}