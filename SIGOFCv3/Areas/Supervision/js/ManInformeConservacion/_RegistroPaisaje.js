"use strict";
var _RegistroPaisaje = {};

_RegistroPaisaje.fnSaveForm = function (data) { /*implementado desde donde se instancia*/ }

_RegistroPaisaje.fnLoadDatos = function (data) {
    if (data != null && data != "") {
        _RegistroPaisaje.frm.find("#hdfRegEstado").val(data["RegEstado"]);
        _RegistroPaisaje.frm.find("#hdfCodSecuencial").val(data["COD_SECUENCIAL"]);
        _RegistroPaisaje.frm.find("#txtPaisaje").val(data["TIPO"]);
        _RegistroPaisaje.frm.find("#txtEstado").val(data["ESTADO_PAISAJE"]);
        _RegistroPaisaje.frm.find("#txtNumVisita").val(data["NUM_VISITANTE"]);
        _RegistroPaisaje.frm.find("#ddlZonaId").select2("val", [data["ZONA"]]);
        _RegistroPaisaje.frm.find("#txtCoordEste").val(data["COORDENADA_ESTE"]);
        _RegistroPaisaje.frm.find("#txtCoordNorte").val(data["COORDENADA_NORTE"]);
        _RegistroPaisaje.frm.find("#txtObservacion").val(data["OBSERVACION"]);
    } else {
        _RegistroPaisaje.frm.find("#hdfRegEstado").val("1");
        _RegistroPaisaje.frm.find("#hdfCodSecuencial").val("0");
    }
}

_RegistroPaisaje.fnSetDatos = function () {
    var data = [];
    var regEstado = _RegistroPaisaje.frm.find("#hdfRegEstado").val();
    data["RegEstado"] = regEstado == "0" ? "2" : regEstado;
    data["COD_SECUENCIAL"] = _RegistroPaisaje.frm.find("#hdfCodSecuencial").val();
    data["TIPO"] = _RegistroPaisaje.frm.find("#txtPaisaje").val();
    data["ESTADO_PAISAJE"] = _RegistroPaisaje.frm.find("#txtEstado").val();
    data["NUM_VISITANTE"] = _RegistroPaisaje.frm.find("#txtNumVisita").val();
    data["ZONA"] = _RegistroPaisaje.frm.find("#ddlZonaId").val();
    data["COORDENADA_ESTE"] = _RegistroPaisaje.frm.find("#txtCoordEste").val();
    data["COORDENADA_NORTE"] = _RegistroPaisaje.frm.find("#txtCoordNorte").val();
    data["OBSERVACION"] = _RegistroPaisaje.frm.find("#txtObservacion").val();
    return data;
}

_RegistroPaisaje.fnSubmitForm = function () {
    _RegistroPaisaje.frm.submit();
}

_RegistroPaisaje.fnInit = function (data) {
    _RegistroPaisaje.frm = $("#frmItemRegPaisaje");

    $.fn.select2.defaults.set("theme", "bootstrap4");
    _RegistroPaisaje.frm.find("#ddlZonaId").select2({ minimumResultsForSearch: -1 });

    _RegistroPaisaje.fnLoadDatos(data);

    //=====-----Para el registro de datos del formulario-----=====
    //Validación personalizada
    jQuery.validator.addMethod("invalidFrmPaisaje", function (value, element) {
        switch ($(element).attr('id')) {
            case 'ddlZonaId':
                return (value == '0000000') ? false : true;
                break
        }
    });
    _RegistroPaisaje.frm.validate(utilSigo.fnValidate({
        rules: {
            txtPaisaje: { required: true },
            txtNumVisita: { required: true },
            ddlZonaId: { invalidFrmPaisaje: true },
            txtCoordEste: { required: true },
            txtCoordNorte: { required: true }
        },
        messages: {
            txtPaisaje: { required: "Ingrese el paisaje/tipo" },
            txtNumVisita: { required: "Ingrese el número de visitantes por mes" },
            ddlZonaId: { invalidFrmPaisaje: "Seleccione la zona UTM" },
            txtCoordEste: { required: "Ingrese la coordenada este" },
            txtCoordNorte: { required: "Ingrese la coordenada norte" }
        },
        fnSubmit: function (form) {
            _RegistroPaisaje.fnSaveForm(_RegistroPaisaje.fnSetDatos());
        }
    }));
    //Validación de controles que usan Select2
    _RegistroPaisaje.frm.find("select.select2-hidden-accessible").on("change", function (e) {
        $(this).valid();
    });
}