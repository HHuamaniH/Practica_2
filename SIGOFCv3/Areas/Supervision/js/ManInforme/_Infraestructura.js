"use strict";
var _Infraestructura = {};

_Infraestructura.fnSaveForm = function (data) { /*implementado desde donde se instancia*/ }

_Infraestructura.fnLoadDatos = function (data) {    
    if (data != null && data != "") {
        _Infraestructura.frm.find("#hdfRegEstadoInfr").val(data["RegEstado"]);
        _Infraestructura.frm.find("#hdfCodSecuencialInfr").val(data["COD_SECUENCIAL"]);
        _Infraestructura.frm.find("#txtDescripcion").val(data["DESCRIPCION"]);
        _Infraestructura.frm.find("#txtDimensiones").val(data["DIMENSIONES"]);
        _Infraestructura.frm.find("#txtUso").val(data["USO"]);
        _Infraestructura.frm.find("#txtEstadoConservacion").val(data["ESTADO_CONSERVACION"]);
        _Infraestructura.frm.find("#txtObjetivos").val(data["OBJETIVOS"]);
    } else {
        _Infraestructura.frm.find("#hdfRegEstadoInfr").val("1");
        _Infraestructura.frm.find("#hdfCodSecuencialInfr").val("0");
    }
}

_Infraestructura.fnSetDatos = function () {
    var data = [];    
    var regEstado = _Infraestructura.frm.find("#hdfRegEstadoInfr").val();
    data["RegEstado"] = regEstado == "0" ? "2" : regEstado;
    data["COD_SECUENCIAL"] = _Infraestructura.frm.find("#hdfCodSecuencialInfr").val();
    data["DESCRIPCION"] = _Infraestructura.frm.find("#txtDescripcion").val();
    data["DIMENSIONES"] = _Infraestructura.frm.find("#txtDimensiones").val();
    data["USO"] = _Infraestructura.frm.find("#txtUso").val();
    data["ESTADO_CONSERVACION"] = _Infraestructura.frm.find("#txtEstadoConservacion").val();
    data["OBJETIVOS"] = _Infraestructura.frm.find("#txtObjetivos").val();
    return data;
}

_Infraestructura.fnSubmitForm = function () {
    _Infraestructura.frm.submit();
}

_Infraestructura.fnInit = function (data) {
    _Infraestructura.frm = $("#frmItemInfraestructura");

    $.fn.select2.defaults.set("theme", "bootstrap4");
    _Infraestructura.frm.find("#ddlZonaId").select2({ minimumResultsForSearch: -1 });

    _Infraestructura.fnLoadDatos(data);

    //_Infraestructura.fnEvents();

    //=====-----Para el registro de datos del formulario-----=====
    //Validación personalizada
    jQuery.validator.addMethod("invalidFrmCoberturaBoscosa", function (value, element) {
        switch ($(element).attr('id')) {
            case 'ddlZonaId':
                return (value == '0000000') ? false : true;
                break
        }
    });
    _Infraestructura.frm.validate(utilSigo.fnValidate({
        rules: {           
            txtDescripcion: { required: true },
            txtDimensiones: { required: true },
            txtUso: { required: true },
            txtEstadoConservacion: { required: true }
        },
        messages: {
            txtDescripcion: { required: "Ingrese la descripción" },
            txtDimensiones: { required: "Ingrese dimensiones" },
            txtUso: { required: "Ingrese uso" },
            txtEstadoConservacion: { required: "Ingrese estado de conservación" }
        },
        fnSubmit: function (form) {
            _Infraestructura.fnSaveForm(_Infraestructura.fnSetDatos());
        }
    }));
    //Validación de controles que usan Select2
    _Infraestructura.frm.find("select.select2-hidden-accessible").on("change", function (e) {
        $(this).valid();
    });
}


