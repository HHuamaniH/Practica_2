"use strict";
var _ProduccionFruto = {};

_ProduccionFruto.fnSaveForm = function (data) { /*implementado desde donde se instancia*/ }

_ProduccionFruto.fnLoadDatos = function (data) {
    if (data != null && data != "") {
        _ProduccionFruto.frm.find("#hdfRegEstado").val(data["RegEstado"]);
        _ProduccionFruto.frm.find("#hdfCodSecuencial").val(data["COD_SECUENCIAL"]);
        _ProduccionFruto.frm.find("#txtArea").val(data["PREDIO_AREA"]);
        _ProduccionFruto.frm.find("#txt1Cosecha").val(data["PRIMERA_COSECHA"]);
        _ProduccionFruto.frm.find("#txt2Cosecha").val(data["SEGUNDA_COSECHA"]);
        _ProduccionFruto.frm.find("#txtTotalCosecha").val(data["TOTAL_PROD_ANUAL"]);
    } else {
        _ProduccionFruto.frm.find("#hdfRegEstado").val("1");
        _ProduccionFruto.frm.find("#hdfCodSecuencial").val("0");
    }
}

_ProduccionFruto.fnSetDatos = function () {
    var data = [];
    var regEstado = _ProduccionFruto.frm.find("#hdfRegEstado").val();
    data["RegEstado"] = regEstado == "0" ? "2" : regEstado;
    data["COD_SECUENCIAL"] = _ProduccionFruto.frm.find("#hdfCodSecuencial").val();
    data["PREDIO_AREA"] = _ProduccionFruto.frm.find("#txtArea").val();
    data["PRIMERA_COSECHA"] = _ProduccionFruto.frm.find("#txt1Cosecha").val();
    data["SEGUNDA_COSECHA"] = _ProduccionFruto.frm.find("#txt2Cosecha").val();
    data["TOTAL_PROD_ANUAL"] = _ProduccionFruto.frm.find("#txtTotalCosecha").val();
    return data;
}

_ProduccionFruto.fnSubmitForm = function () {
    _ProduccionFruto.frm.submit();
}

_ProduccionFruto.fnInit = function (data) {
    _ProduccionFruto.frm = $("#frmItemProduccionFruto");

    _ProduccionFruto.fnLoadDatos(data);

    //=====-----Para el registro de datos del formulario-----=====
    _ProduccionFruto.frm.validate(utilSigo.fnValidate({
        rules: {
            txtArea: { required: true },
            txt1Cosecha: { required: true },
            txt2Cosecha: { required: true },
            txtTotalCosecha: { required: true }
        },
        messages: {
            txtArea: { required: "Ingrese el Predio/Área" },
            txt1Cosecha: { required: "Ingrese un valor mayor o igual a 0" },
            txt2Cosecha: { required: "Ingrese un valor mayor o igual a 0" },
            txtTotalCosecha: { required: "Ingrese un valor mayor o igual a 0" }
        },
        fnSubmit: function (form) {
            _ProduccionFruto.fnSaveForm(_ProduccionFruto.fnSetDatos());
        }
    }));

    //Validación de controles que usan Select2
    _ProduccionFruto.frm.find("select.select2-hidden-accessible").on("change", function (e) {
        $(this).valid();
    });
}