"use strict";
var _CoberturaBoscosa = {};

_CoberturaBoscosa.fnSaveForm = function (data) { /*implementado desde donde se instancia*/ }

_CoberturaBoscosa.fnLoadDatos = function (data) {    
    if (data != null && data != "") {
        _CoberturaBoscosa.frm.find("#hdfRegEstadoCobBoscosa").val(data["RegEstado"]); 
        _CoberturaBoscosa.frm.find("#hdfCodSecuencialCobBos").val(data["COD_SECUENCIAL"]);
        _CoberturaBoscosa.frm.find("#txtActividad").val(data["ACTIVIDAD"]);
        _CoberturaBoscosa.frm.find("#txtArea").val(data["AREA"]);
        _CoberturaBoscosa.frm.find("#txtAutorizado").val(data["AUTORIZADO"]);
        _CoberturaBoscosa.frm.find("#ddlZonaId").select2("val", [data["ZONA"]]);
        _CoberturaBoscosa.frm.find("#txtCoordEste").val(data["COORDENADA_ESTE"]);
        _CoberturaBoscosa.frm.find("#txtCoordNorte").val(data["COORDENADA_NORTE"]);
        _CoberturaBoscosa.frm.find("#txtObservacion").val(data["OBSERVACION"]);
    } else {
        _CoberturaBoscosa.frm.find("#hdfRegEstadoCobBoscosa").val("1");
        _CoberturaBoscosa.frm.find("#hdfCodSecuencialCobBos").val("0");
    }
}

_CoberturaBoscosa.fnSetDatos = function () {
    var data = [];    
    var regEstado = _CoberturaBoscosa.frm.find("#hdfRegEstadoCobBoscosa").val();
    data["RegEstado"] = regEstado == "0" ? "2" : regEstado;
    data["COD_SECUENCIAL"] = _CoberturaBoscosa.frm.find("#hdfCodSecuencialCobBos").val();
    data["ACTIVIDAD"] = _CoberturaBoscosa.frm.find("#txtActividad").val();
    data["AREA"] = _CoberturaBoscosa.frm.find("#txtArea").val();
    data["AUTORIZADO"] = _CoberturaBoscosa.frm.find("#txtAutorizado").val();
    data["ZONA"] = _CoberturaBoscosa.frm.find("#ddlZonaId").val();
    data["COORDENADA_ESTE"] = _CoberturaBoscosa.frm.find("#txtCoordEste").val();
    data["COORDENADA_NORTE"] = _CoberturaBoscosa.frm.find("#txtCoordNorte").val();
    data["OBSERVACION"] = _CoberturaBoscosa.frm.find("#txtObservacion").val();
    return data;
}

_CoberturaBoscosa.fnSubmitForm = function () {
    _CoberturaBoscosa.frm.submit();
}

_CoberturaBoscosa.fnInit = function (data) {
    _CoberturaBoscosa.frm = $("#frmItemCoberturaBoscosa");

    $.fn.select2.defaults.set("theme", "bootstrap4");
    _CoberturaBoscosa.frm.find("#ddlZonaId").select2({ minimumResultsForSearch: -1 });

    _CoberturaBoscosa.fnLoadDatos(data);

    //_CoberturaBoscosa.fnEvents();

    //=====-----Para el registro de datos del formulario-----=====
    //Validación personalizada
    jQuery.validator.addMethod("invalidFrmCoberturaBoscosa", function (value, element) {
        switch ($(element).attr('id')) {
            case 'ddlZonaId':
                return (value == '0000000') ? false : true;
                break
        }
    });
    _CoberturaBoscosa.frm.validate(utilSigo.fnValidate({
        rules: {           
            txtActividad: { required: true },
            txtArea: { required: true },
            txtAutorizado: { required: true },
            ddlZonaId: { invalidFrmCoberturaBoscosa: true },
            txtCoordEste: { required: true },
            txtCoordNorte: { required: true }
        },
        messages: {
            txtActividad: { required: "Ingrese la actividad" },
            txtArea: { required: "Ingrese área" },
            txtAutorizado: { required: "Ingrese autorizado" },
            ddlZonaId: { invalidFrmCoberturaBoscosa: "Seleccione la zona" },
            txtCoordEste: { required: "Ingrese la coordenada este" },
            txtCoordNorte: { required: "Ingrese la coordenada norte" }
        },
        fnSubmit: function (form) {
            _CoberturaBoscosa.fnSaveForm(_CoberturaBoscosa.fnSetDatos());
        }
    }));
    //Validación de controles que usan Select2
    _CoberturaBoscosa.frm.find("select.select2-hidden-accessible").on("change", function (e) {
        $(this).valid();
    });
}


