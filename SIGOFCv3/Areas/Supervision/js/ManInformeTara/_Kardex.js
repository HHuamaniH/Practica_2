"use strict";
var _Kardex = {};

_Kardex.fnSaveForm = function (data) { /*implementado desde donde se instancia*/ }

_Kardex.fnViewModalUbigeo = function () {
    var url = initSigo.urlControllerGeneral + "_Ubigeo";
    var option = { url: url, type: 'POST', datos: {}, divId: "mdlControles_Ubigeo" };
    utilSigo.fnOpenModal(option, function () {
        _Ubigeo.fnSelectUbigeo = function (_ubigeoText, _ubigeoId) {
            _Kardex.frm.find("#hdfCodUbigeoDestino").val(_ubigeoId);
            _Kardex.frm.find("#txtUbigeoDestino").val(_ubigeoText);
            $("#mdlControles_Ubigeo").modal('hide');
        }
        _Ubigeo.fnLoadModalView(_Kardex.frm.find("#hdfCodUbigeoDestino").val());
    });
}

_Kardex.fnLoadDatos = function (data) {
    if (data != null && data != "") {
        _Kardex.frm.find("#hdfRegEstado").val(data["RegEstado"]);
        _Kardex.frm.find("#hdfCodSecuencial").val(data["COD_SECUENCIAL"]);
        _Kardex.frm.find("#txtGuia").val(data["N_GUIA_TRANSPORTE"]);
        _Kardex.frm.find("#txtFechaEmision").val(data["FECHA_EMISION"]);
        _Kardex.frm.find("#txtZafra").val(data["ZAFRA"]);
        _Kardex.frm.find("#txtCantAutoriza").val(data["CANTIDAD_AQUINTAL"]);
        _Kardex.frm.find("#txtTotalSacado").val(data["TOTAL_SQUINTAL"]);
        _Kardex.frm.find("#txtSaldoQuint").val(data["SALDO_QUINTAL"]);
        _Kardex.frm.find("#txtSaldoCubic").val(data["SALDO_MTRES"]);
        _Kardex.frm.find("#txtUbigeoDestino").val(data["UBIGEO"]);
        _Kardex.frm.find("#hdfCodUbigeoDestino").val(data["DESTINO_COD_UBIGEO"]);
    } else {
        _Kardex.frm.find("#hdfRegEstado").val("1");
        _Kardex.frm.find("#hdfCodSecuencial").val("0");
    }
}

_Kardex.fnSetDatos = function () {
    var data = [];
    var regEstado = _Kardex.frm.find("#hdfRegEstado").val();
    data["RegEstado"] = regEstado == "0" ? "2" : regEstado;
    data["COD_SECUENCIAL"] = _Kardex.frm.find("#hdfCodSecuencial").val();
    data["N_GUIA_TRANSPORTE"] = _Kardex.frm.find("#txtGuia").val();
    data["FECHA_EMISION"] = _Kardex.frm.find("#txtFechaEmision").val();
    data["ZAFRA"] = _Kardex.frm.find("#txtZafra").val();
    data["CANTIDAD_AQUINTAL"] = _Kardex.frm.find("#txtCantAutoriza").val();
    data["TOTAL_SQUINTAL"] = _Kardex.frm.find("#txtTotalSacado").val();
    data["SALDO_QUINTAL"] = _Kardex.frm.find("#txtSaldoQuint").val();
    data["SALDO_MTRES"] = _Kardex.frm.find("#txtSaldoCubic").val();
    data["UBIGEO"] = _Kardex.frm.find("#txtUbigeoDestino").val();
    data["DESTINO_COD_UBIGEO"] = _Kardex.frm.find("#hdfCodUbigeoDestino").val();
    return data;
}

_Kardex.fnSubmitForm = function () {
    _Kardex.frm.submit();
}

_Kardex.fnInit = function (data) {
    _Kardex.frm = $("#frmItemKardex");

    utilSigo.fnFormatDate(_Kardex.frm.find("#txtFechaEmision"));
    _Kardex.fnLoadDatos(data);

    //=====-----Para el registro de datos del formulario-----=====
    _Kardex.frm.validate(utilSigo.fnValidate({
        rules: {
            txtGuia: { required: true },
            txtFechaEmision: { required: true },
            txtCantAutoriza: { required: true },
            txtTotalSacado: { required: true },
            txtSaldoQuint: { required: true },
            txtSaldoCubic: { required: true }
        },
        messages: {
            txtGuia: { required: "Ingrese el número de guía de transporte" },
            txtFechaEmision: { required: "Ingrese la fecha de emisión de la guía" },
            txtCantAutoriza: { required: "Ingrese la cantidad autorizada" },
            txtTotalSacado: { required: "Ingrese el total sacado" },
            txtSaldoQuint: { required: "Ingrese el saldo el quintales" },
            txtSaldoCubic: { required: "Ingrese el saldo en metros cúbicos" }
        },
        fnSubmit: function (form) {
            _Kardex.fnSaveForm(_Kardex.fnSetDatos());
        }
    }));

    //Validación de controles que usan Select2
    _Kardex.frm.find("select.select2-hidden-accessible").on("change", function (e) {
        $(this).valid();
    });
}