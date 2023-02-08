"use strict";
var _EquipamientoCons = {};

_EquipamientoCons.fnSaveForm = function (data) { /*implementado desde donde se instancia*/ }

_EquipamientoCons.fnLoadDatos = function (asCodPrograma, data) {
    if (data != null && data != "") {
        _EquipamientoCons.frm.find("#hdfRegEstado").val(data["RegEstado"]);
        _EquipamientoCons.frm.find("#hdfCodPrograma").val(data["COD_PROGRAMA"]);
        _EquipamientoCons.frm.find("#hdfCodSecuencial").val(data["COD_SECUENCIAL"]);
        _EquipamientoCons.frm.find("#txtDescripcion").val(data["DESCRIPCION"]);
        _EquipamientoCons.frm.find("#txtNumAmbiente").val(data["NUM_AMBIENTE"]);
        _EquipamientoCons.frm.find("#txtUso").val(data["USO"]);
        _EquipamientoCons.frm.find("#txtEstConservacion").val(data["ESTADO_CONSERVACION"]);
        _EquipamientoCons.frm.find("#txtObjetivo").val(data["OBJETIVO"]);
        _EquipamientoCons.frm.find("#txtObservacion").val(data["OBSERVACION"]);
    } else {
        _EquipamientoCons.frm.find("#hdfRegEstado").val("1");
        _EquipamientoCons.frm.find("#hdfCodPrograma").val(asCodPrograma);
        _EquipamientoCons.frm.find("#hdfCodSecuencial").val("0");
    }
}

_EquipamientoCons.fnSetDatos = function () {
    var data = [];
    var regEstado = _EquipamientoCons.frm.find("#hdfRegEstado").val();
    data["RegEstado"] = regEstado == "0" ? "2" : regEstado;
    data["COD_PROGRAMA"] = _EquipamientoCons.frm.find("#hdfCodPrograma").val();
    data["COD_SECUENCIAL"] = _EquipamientoCons.frm.find("#hdfCodSecuencial").val();
    data["DESCRIPCION"] = _EquipamientoCons.frm.find("#txtDescripcion").val();
    data["NUM_AMBIENTE"] = _EquipamientoCons.frm.find("#txtNumAmbiente").val();
    data["USO"] = _EquipamientoCons.frm.find("#txtUso").val();
    data["ESTADO_CONSERVACION"] = _EquipamientoCons.frm.find("#txtEstConservacion").val();
    data["OBJETIVO"] = _EquipamientoCons.frm.find("#txtObjetivo").val();
    data["OBSERVACION"] = _EquipamientoCons.frm.find("#txtObservacion").val();
    return data;
}

_EquipamientoCons.fnSubmitForm = function () {
    _EquipamientoCons.frm.submit();
}

_EquipamientoCons.fnInit = function (data, asCodPrograma) {
    _EquipamientoCons.frm = $("#frmItemEquipamientoCons");

    _EquipamientoCons.fnLoadDatos(asCodPrograma, data);

    //=====-----Para el registro de datos del formulario-----=====
    _EquipamientoCons.frm.validate(utilSigo.fnValidate({
        rules: {
            txtDescripcion: { required: true },
            txtNumAmbiente: { required: true }
        },
        messages: {
            txtDescripcion: { required: "Ingrese la descripción del equipamiento" },
            txtNumAmbiente: { required: "Ingrese el número de ambiente" }
        },
        fnSubmit: function (form) {
            _EquipamientoCons.fnSaveForm(_EquipamientoCons.fnSetDatos());
        }
    }));

    //Validación de controles que usan Select2
    _EquipamientoCons.frm.find("select.select2-hidden-accessible").on("change", function (e) {
        $(this).valid();
    });
}