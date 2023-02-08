"use strict";
var _EspecieCapturada = {};

_EspecieCapturada.fnSaveForm = function (data) { /*implementado desde donde se instancia*/ }

_EspecieCapturada.fnLoadDatos = function (data) {
    if (data != null && data != "") {
        _EspecieCapturada.frm.find("#hdfRegEstado").val(data["RegEstado"]);
        _EspecieCapturada.frm.find("#hdfCodSecuencial").val(data["COD_SECUENCIAL"]);
        _EspecieCapturada.frm.find("#txtIndivCapturado").val(data["NUM_ICAPTURADOS"]);
        _EspecieCapturada.frm.find("#txtZonaCaptura").val(data["ZONA_CAPTURA"]);
        _EspecieCapturada.frm.find("#txtObservacion").val(data["OBSERVACION"]);
        _renderComboEspecie.fnInit("FAUNA", data["COD_ESPECIES"], data["DESCRIPCION"]);
    } else {
        _EspecieCapturada.frm.find("#hdfRegEstado").val("1");
        _EspecieCapturada.frm.find("#hdfCodSecuencial").val("0");
        _renderComboEspecie.fnInit("FAUNA", "", "");
    }
}

_EspecieCapturada.fnSetDatos = function () {
    var data = [];
    var regEstado = _EspecieCapturada.frm.find("#hdfRegEstado").val();
    data["RegEstado"] = regEstado == "0" ? "2" : regEstado;
    data["COD_SECUENCIAL"] = _EspecieCapturada.frm.find("#hdfCodSecuencial").val();
    data["COD_ESPECIES"] = _renderComboEspecie.fnGetCodEspecie();
    data["DESCRIPCION"] = _renderComboEspecie.fnGetEspecie();
    data["NUM_ICAPTURADOS"] = _EspecieCapturada.frm.find("#txtIndivCapturado").val();
    data["ZONA_CAPTURA"] = _EspecieCapturada.frm.find("#txtZonaCaptura").val();
    data["OBSERVACION"] = _EspecieCapturada.frm.find("#txtObservacion").val();
    return data;
}

_EspecieCapturada.fnCustomValidateForm = function () {
    if (_renderComboEspecie.fnGetCodEspecie() == null) {
        utilSigo.toastWarning("Aviso", "Seleccione la especie a registrar"); return false;
    }
    return true;
}

_EspecieCapturada.fnSubmitForm = function () {
    _EspecieCapturada.frm.submit();
}

_EspecieCapturada.fnInit = function (data) {
    _EspecieCapturada.frm = $("#frmItemEspecieCapturada");

    _EspecieCapturada.fnLoadDatos(data);

    _EspecieCapturada.frm.validate(utilSigo.fnValidate({
        rules: {
            txtIndivCapturado: { required: true }
        },
        messages: {
            txtIndivCapturado: { required: "Ingrese el número de individuos capturados" }
        },
        fnSubmit: function (form) {
            if (_EspecieCapturada.fnCustomValidateForm()) {
                _EspecieCapturada.fnSaveForm(_EspecieCapturada.fnSetDatos());
            }
        }
    }));
    //Validación de controles que usan Select2
    _EspecieCapturada.frm.find("select.select2-hidden-accessible").on("change", function (e) {
        $(this).valid();
    });
}