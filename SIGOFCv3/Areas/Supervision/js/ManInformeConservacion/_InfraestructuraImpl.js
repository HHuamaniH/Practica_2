"use strict";
var _InfraestructuraImpl = {};

_InfraestructuraImpl.fnSaveForm = function (data) { /*implementado desde donde se instancia*/ }

_InfraestructuraImpl.fnLoadDatos = function (data) {
    if (data != null && data != "") {
        _InfraestructuraImpl.frm.find("#hdfRegEstado").val(data["RegEstado"]);
        _InfraestructuraImpl.frm.find("#hdfCodSecuencial").val(data["COD_SECUENCIAL"]);
        _InfraestructuraImpl.frm.find("#txtTipoAmbiente").val(data["TIPO_AMBIENTE"]);
        _InfraestructuraImpl.frm.find("#txtNumAmbiente").val(data["NUM_AMBIENTE"]);
        _InfraestructuraImpl.frm.find("#txtArea").val(data["AREA"]);
        _InfraestructuraImpl.frm.find("#txtCapacidad").val(data["CAPACIDAD"]);
        _InfraestructuraImpl.frm.find("#txtMaterial").val(data["MATERIAL_CONSTRUCCION"]);
        _InfraestructuraImpl.frm.find("#txtUso").val(data["USO"]);
        _InfraestructuraImpl.frm.find("#txtEstadoCons").val(data["ESTADO_CONSERVACION"]);
        _InfraestructuraImpl.frm.find("#txtObjetivo").val(data["OBJETIVO"]);
    } else {
        _InfraestructuraImpl.frm.find("#hdfRegEstado").val("1");
        _InfraestructuraImpl.frm.find("#hdfCodSecuencial").val("0");
    }
}

_InfraestructuraImpl.fnSetDatos = function () {
    var data = [];
    var regEstado = _InfraestructuraImpl.frm.find("#hdfRegEstado").val();
    data["RegEstado"] = regEstado == "0" ? "2" : regEstado;
    data["COD_SECUENCIAL"] = _InfraestructuraImpl.frm.find("#hdfCodSecuencial").val();
    data["TIPO_AMBIENTE"] = _InfraestructuraImpl.frm.find("#txtTipoAmbiente").val();
    data["NUM_AMBIENTE"] = _InfraestructuraImpl.frm.find("#txtNumAmbiente").val();
    data["AREA"] = _InfraestructuraImpl.frm.find("#txtArea").val();
    data["CAPACIDAD"] = _InfraestructuraImpl.frm.find("#txtCapacidad").val() == "" ? 0 : _InfraestructuraImpl.frm.find("#txtCapacidad").val();
    data["MATERIAL_CONSTRUCCION"] = _InfraestructuraImpl.frm.find("#txtMaterial").val();
    data["USO"] = _InfraestructuraImpl.frm.find("#txtUso").val();
    data["ESTADO_CONSERVACION"] = _InfraestructuraImpl.frm.find("#txtEstadoCons").val();
    data["OBJETIVO"] = _InfraestructuraImpl.frm.find("#txtObjetivo").val();
    return data;
}

_InfraestructuraImpl.fnSubmitForm = function () {
    _InfraestructuraImpl.frm.submit();
}

_InfraestructuraImpl.fnInit = function (data,_codmtipo) {
    _InfraestructuraImpl.frm = $("#frmItemInfraestructuraImpl");

    _InfraestructuraImpl.fnLoadDatos(data);

    _InfraestructuraImpl.frm.find(".dvDatosCons").hide();
    _InfraestructuraImpl.frm.find(".dvDatosEcot").hide();
    if (_codmtipo=="0000011") { //Ecoturismo
        _InfraestructuraImpl.frm.find(".dvDatosEcot").show();
    } else {
        _InfraestructuraImpl.frm.find(".dvDatosCons").show();
    }

    //=====-----Para el registro de datos del formulario-----=====
    _InfraestructuraImpl.frm.validate(utilSigo.fnValidate({
        rules: {
            txtTipoAmbiente: { required: true },
            txtNumAmbiente: { required: true },
            txtArea: { required: true }
        },
        messages: {
            txtTipoAmbiente: { required: "Ingrese el tipo de ambiente" },
            txtNumAmbiente: { required: "Ingrese el número de ambientes" },
            txtArea: { required: "Ingrese el área" }
        },
        fnSubmit: function (form) {
            _InfraestructuraImpl.fnSaveForm(_InfraestructuraImpl.fnSetDatos());
        }
    }));

    //Validación de controles que usan Select2
    _InfraestructuraImpl.frm.find("select.select2-hidden-accessible").on("change", function (e) {
        $(this).valid();
    });
}