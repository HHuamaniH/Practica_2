"use strict";
var _AprovechaForestal = {};

_AprovechaForestal.fnSaveForm = function (data) { /*implementado desde donde se instancia*/ }

_AprovechaForestal.fnLoadDatos = function (data) {
    if (data != null && data != "") {
        _AprovechaForestal.frm.find("#hdfRegEstado").val(data["RegEstado"]);
        _AprovechaForestal.frm.find("#hdfCodSecuencial").val(data["COD_SECUENCIAL"]);
        _AprovechaForestal.frm.find("#txtArea").val(data["PREDIO_AREA"]);
        _AprovechaForestal.frm.find("#txtZafra").val(data["ZAFRA"]);
        _AprovechaForestal.frm.find("#txtProdArb").val(data["P_ARBOL_PRODUCTIVO"]);
        _AprovechaForestal.frm.find("#txtProdArbNoProd").val(data["P_ARBOL_NOPRODUCTIVO"]);
        _AprovechaForestal.frm.find("#txtProdArbPlantado").val(data["P_ARBOL_PLANTADO"]);
        _AprovechaForestal.frm.find("#txtCantAutorizada").val(data["CANTIDAD_AEXTRAER"]);
        _AprovechaForestal.frm.find("#txtCantExtraida").val(data["CANTIDAD_EXTRAIDA"]);
        _AprovechaForestal.frm.find("#txtArbSupervisado").val(data["N_ARBOL_SUPERVISADO"]);
        _AprovechaForestal.frm.find("#txtCantSupervisada").val(data["CANTIDAD_SUPERVISADO"]);
        _AprovechaForestal.frm.find("#txtCantInjustificada").val(data["CANTIDAD_INJUSTIFICADA"]);
    } else {
        _AprovechaForestal.frm.find("#hdfRegEstado").val("1");
        _AprovechaForestal.frm.find("#hdfCodSecuencial").val("0");
    }
}

_AprovechaForestal.fnSetDatos = function () {
    var data = [];
    var regEstado = _AprovechaForestal.frm.find("#hdfRegEstado").val();
    data["RegEstado"] = regEstado == "0" ? "2" : regEstado;
    data["COD_SECUENCIAL"] = _AprovechaForestal.frm.find("#hdfCodSecuencial").val();
    data["PREDIO_AREA"] = _AprovechaForestal.frm.find("#txtArea").val();
    data["ZAFRA"]=_AprovechaForestal.frm.find("#txtZafra").val();
    data["P_ARBOL_PRODUCTIVO"]=_AprovechaForestal.frm.find("#txtProdArb").val();
    data["P_ARBOL_NOPRODUCTIVO"]=_AprovechaForestal.frm.find("#txtProdArbNoProd").val();
    data["P_ARBOL_PLANTADO"]=_AprovechaForestal.frm.find("#txtProdArbPlantado").val();
    data["CANTIDAD_AEXTRAER"]=_AprovechaForestal.frm.find("#txtCantAutorizada").val();
    data["CANTIDAD_EXTRAIDA"]=_AprovechaForestal.frm.find("#txtCantExtraida").val();
    data["N_ARBOL_SUPERVISADO"]= _AprovechaForestal.frm.find("#txtArbSupervisado").val();
    data["CANTIDAD_SUPERVISADO"]=_AprovechaForestal.frm.find("#txtCantSupervisada").val();
    data["CANTIDAD_INJUSTIFICADA"]=_AprovechaForestal.frm.find("#txtCantInjustificada").val();
    return data;
}

_AprovechaForestal.fnSubmitForm = function () {
    _AprovechaForestal.frm.submit();
}

_AprovechaForestal.fnInit = function (data) {
    _AprovechaForestal.frm = $("#frmItemAprovechaForestal");

    _AprovechaForestal.fnLoadDatos(data);

    //=====-----Para el registro de datos del formulario-----=====
    _AprovechaForestal.frm.validate(utilSigo.fnValidate({
        rules: {
            txtArea: { required: true },
            txtProdArb: { required: true },
            txtProdArbNoProd: { required: true },
            txtProdArbPlantado: { required: true },
            txtCantAutorizada: { required: true },
            txtCantExtraida: { required: true },
            txtArbSupervisado: { required: true },
            txtCantSupervisada: { required: true },
            txtCantInjustificada: { required: true }
        },
        messages: {
            txtArea: { required: "Ingrese el Predio/Área" },
            txtProdArb: { required: "Ingrese un valor mayor o igual a 0" },
            txtProdArbNoProd: { required: "Ingrese un valor mayor o igual a 0" },
            txtProdArbPlantado: { required: "Ingrese un valor mayor o igual a 0" },
            txtCantAutorizada: { required: "Ingrese un valor mayor o igual a 0" },
            txtCantExtraida: { required: "Ingrese un valor mayor o igual a 0" },
            txtArbSupervisado: { required: "Ingrese un valor mayor o igual a 0" },
            txtCantSupervisada: { required: "Ingrese un valor mayor o igual a 0" },
            txtCantInjustificada: { required: "Ingrese un valor mayor o igual a 0" }
        },
        fnSubmit: function (form) {
            _AprovechaForestal.fnSaveForm(_AprovechaForestal.fnSetDatos());
        }
    }));

    //Validación de controles que usan Select2
    _AprovechaForestal.frm.find("select.select2-hidden-accessible").on("change", function (e) {
        $(this).valid();
    });
}