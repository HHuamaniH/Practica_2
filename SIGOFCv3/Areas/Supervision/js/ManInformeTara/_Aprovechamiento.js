"use strict";
var _Aprovechamiento = {};

_Aprovechamiento.fnSaveForm = function (data) { /*implementado desde donde se instancia*/ }

_Aprovechamiento.fnLoadDatos = function (data) {
    if (data != null && data != "") {
        _Aprovechamiento.frm.find("#hdfRegEstado").val(data["RegEstado"]);
        _Aprovechamiento.frm.find("#hdfCodSecuencial").val(data["COD_SECUENCIAL"]);
        _Aprovechamiento.frm.find("#txtArea").val(data["PREDIO_AREA"]);
        _Aprovechamiento.frm.find("#txtNumArbolSuperv").val(data["N_ARBOL_SUPERVISADO"]);
        _Aprovechamiento.frm.find("#txtNumArbolVerde").val(data["N_ARBOL_FVERDE"]);
        _Aprovechamiento.frm.find("#txtNumArbolVerdeMad").val(data["N_ARBOL_FVERDE_MADURO"]);
        _Aprovechamiento.frm.find("#txtNumArbolFlor").val(data["N_ARBOL_FLOR"]);
        _Aprovechamiento.frm.find("#txtNumArbolNoFruto").val(data["N_ARBOL_NOFRUTO"]);
        _Aprovechamiento.frm.find("#txtObservacion").val(data["OBSERVACION"]);
    } else {
        _Aprovechamiento.frm.find("#hdfRegEstado").val("1");
        _Aprovechamiento.frm.find("#hdfCodSecuencial").val("0");
    }
}

_Aprovechamiento.fnSetDatos = function () {
    var data = [];
    var regEstado = _Aprovechamiento.frm.find("#hdfRegEstado").val();
    data["RegEstado"] = regEstado == "0" ? "2" : regEstado;
    data["COD_SECUENCIAL"] = _Aprovechamiento.frm.find("#hdfCodSecuencial").val();
    data["PREDIO_AREA"] = _Aprovechamiento.frm.find("#txtArea").val();
    data["N_ARBOL_SUPERVISADO"] = _Aprovechamiento.frm.find("#txtNumArbolSuperv").val();
    data["N_ARBOL_FVERDE"] = _Aprovechamiento.frm.find("#txtNumArbolVerde").val();
    data["N_ARBOL_FVERDE_MADURO"] = _Aprovechamiento.frm.find("#txtNumArbolVerdeMad").val();
    data["N_ARBOL_FLOR"] = _Aprovechamiento.frm.find("#txtNumArbolFlor").val();
    data["N_ARBOL_NOFRUTO"] = _Aprovechamiento.frm.find("#txtNumArbolNoFruto").val();
    data["OBSERVACION"] = _Aprovechamiento.frm.find("#txtObservacion").val();
    return data;
}

_Aprovechamiento.fnSubmitForm = function () {
    _Aprovechamiento.frm.submit();
}

_Aprovechamiento.fnInit = function (data) {
    _Aprovechamiento.frm = $("#frmItemAprovechamiento");

    _Aprovechamiento.fnLoadDatos(data);

    //=====-----Para el registro de datos del formulario-----=====
    _Aprovechamiento.frm.validate(utilSigo.fnValidate({
        rules: {
            txtArea: { required: true },
            txtNumArbolSuperv: { required: true },
            txtNumArbolVerde: { required: true },
            txtNumArbolVerdeMad: { required: true },
            txtNumArbolFlor: { required: true },
            txtNumArbolNoFruto: { required: true }
        },
        messages: {
            txtArea: { required: "Ingrese el Predio/Área" },
            txtNumArbolSuperv: { required: "Ingrese un valor mayor o igual a 0" },
            txtNumArbolVerde: { required: "Ingrese un valor mayor o igual a 0" },
            txtNumArbolVerdeMad: { required: "Ingrese un valor mayor o igual a 0" },
            txtNumArbolFlor: { required: "Ingrese un valor mayor o igual a 0" },
            txtNumArbolNoFruto: { required: "Ingrese un valor mayor o igual a 0" }
        },
        fnSubmit: function (form) {
            _Aprovechamiento.fnSaveForm(_Aprovechamiento.fnSetDatos());
        }
    }));

    //Validación de controles que usan Select2
    _Aprovechamiento.frm.find("select.select2-hidden-accessible").on("change", function (e) {
        $(this).valid();
    });
}