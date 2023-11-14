"use strict";
var _OtrosPuntosEval = {};

_OtrosPuntosEval.fnSaveForm = function (data) { /*implementado desde donde se instancia*/ }

_OtrosPuntosEval.fnLoadDatos = function (data) {    
    if (data != null && data != "") {
        _OtrosPuntosEval.frm.find("#hdfRegEstadoOPE").val(data["RegEstado"]); 
        _OtrosPuntosEval.frm.find("#hdfCodSecuencialOPE").val(data["COD_SECUENCIAL"]);
        _OtrosPuntosEval.frm.find("#txtEvaluacion").val(data["EVALUACION"]);
        _OtrosPuntosEval.frm.find("#ddlZonaId").select2("val", [data["ZONA"]]);
        _OtrosPuntosEval.frm.find("#txtCoordEste").val(data["COORDENADA_ESTE"]);
        _OtrosPuntosEval.frm.find("#txtCoordNorte").val(data["COORDENADA_NORTE"]);
        _OtrosPuntosEval.frm.find("#txtDescripcion").val(data["DESCRIPCION"]);
    } else {
        _OtrosPuntosEval.frm.find("#hdfRegEstadoOPE").val("1");
        _OtrosPuntosEval.frm.find("#hdfCodSecuencialOPE").val("0");
    }
}

_OtrosPuntosEval.fnSetDatos = function () {
    var data = [];    
    var regEstado = _OtrosPuntosEval.frm.find("#hdfRegEstadoOPE").val();
    data["RegEstado"] = regEstado == "0" ? "2" : regEstado;
    data["COD_SECUENCIAL"] = _OtrosPuntosEval.frm.find("#hdfCodSecuencialOPE").val();
    data["EVALUACION"] = _OtrosPuntosEval.frm.find("#txtEvaluacion").val();   
    data["ZONA"] = _OtrosPuntosEval.frm.find("#ddlZonaId").val();
    data["COORDENADA_ESTE"] = _OtrosPuntosEval.frm.find("#txtCoordEste").val();
    data["COORDENADA_NORTE"] = _OtrosPuntosEval.frm.find("#txtCoordNorte").val();
    data["DESCRIPCION"] = _OtrosPuntosEval.frm.find("#txtDescripcion").val();
    return data;
}

_OtrosPuntosEval.fnSubmitForm = function () {
    _OtrosPuntosEval.frm.submit();
}

_OtrosPuntosEval.fnInit = function (data) {
    _OtrosPuntosEval.frm = $("#frmItemOtrosPuntosEval");

    $.fn.select2.defaults.set("theme", "bootstrap4");
    _OtrosPuntosEval.frm.find("#ddlZonaId").select2({ minimumResultsForSearch: -1 });

    _OtrosPuntosEval.fnLoadDatos(data);

    //_OtrosPuntosEval.fnEvents();

    //=====-----Para el registro de datos del formulario-----=====
    //Validación personalizada
    jQuery.validator.addMethod("invalidFrmOtrosPuntosEval", function (value, element) {
        switch ($(element).attr('id')) {
            case 'ddlZonaId':
                return (value == '0000000') ? false : true;
                break
        }
    });
    _OtrosPuntosEval.frm.validate(utilSigo.fnValidate({
        rules: {           
            txtEvaluacion: { required: true },            
            ddlZonaId: { invalidFrmOtrosPuntosEval: true },
            txtCoordEste: { required: true },
            txtCoordNorte: { required: true }
        },
        messages: {
            txtEvaluacion: { required: "Ingrese la evaluación" },
            ddlZonaId: { invalidFrmOtrosPuntosEval: "Seleccione la zona" },
            txtCoordEste: { required: "Ingrese la coordenada este" },
            txtCoordNorte: { required: "Ingrese la coordenada norte" }
        },
        fnSubmit: function (form) {
            _OtrosPuntosEval.fnSaveForm(_OtrosPuntosEval.fnSetDatos());
        }
    }));
    //Validación de controles que usan Select2
    _OtrosPuntosEval.frm.find("select.select2-hidden-accessible").on("change", function (e) {
        $(this).valid();
    });
}


