"use strict";
var _AprovEspecieObligacion = {};

_AprovEspecieObligacion.fnSaveForm = function (data) { /*implementado desde donde se instancia*/ }

_AprovEspecieObligacion.fnLoadDatos = function (data, codObligacion) {
    if (data != null && data != "") {
        _AprovEspecieObligacion.frm.find("#hdfRegEstado").val(data["RegEstado"]);
        _AprovEspecieObligacion.frm.find("#hdfCodObligacion").val(data["COD_OCONTRACTUAL"]);
        _AprovEspecieObligacion.frm.find("#hdfCodSecuencial").val(data["COD_SECUENCIAL"]);
        _AprovEspecieObligacion.frm.find("#ddlAutorizadoId").select2("val", [data["ESTA_AUTORIZADO"] == true ? "SI" : "NO"]);
        _AprovEspecieObligacion.frm.find("#txtObservacion").val(data["OBSERVACION"]);
        _renderComboEspecie.fnInit("TODOS", data["COD_ESPECIES"], data["ESPECIES"]);
    } else {
        _AprovEspecieObligacion.frm.find("#hdfRegEstado").val("1");
        _AprovEspecieObligacion.frm.find("#hdfCodObligacion").val(codObligacion);
        _AprovEspecieObligacion.frm.find("#hdfCodSecuencial").val("0");
        _renderComboEspecie.fnInit("TODOS", "", "");
    }
}

_AprovEspecieObligacion.fnSetDatos = function () {
    var data = [];
    var regEstado = _AprovEspecieObligacion.frm.find("#hdfRegEstado").val();
    data["RegEstado"] = regEstado == "0" ? "2" : regEstado;
    data["COD_OCONTRACTUAL"] = _AprovEspecieObligacion.frm.find("#hdfCodObligacion").val();
    data["COD_SECUENCIAL"] = _AprovEspecieObligacion.frm.find("#hdfCodSecuencial").val();
    data["COD_ESPECIES"] = _renderComboEspecie.fnGetCodEspecie();
    data["ESPECIES"] = _renderComboEspecie.fnGetEspecie();
    data["ESTA_AUTORIZADO"] = _AprovEspecieObligacion.frm.find("#ddlAutorizadoId").val() == "SI" ? true : false;
    data["OBSERVACION"] = _AprovEspecieObligacion.frm.find("#txtObservacion").val();
    return data;
}

_AprovEspecieObligacion.fnCustomValidateForm = function () {
    if (_renderComboEspecie.fnGetCodEspecie() == null) {
        utilSigo.toastWarning("Aviso", "Seleccione la especie a registrar"); return false;
    }
    return true;
}

_AprovEspecieObligacion.fnSubmitForm = function () {
    _AprovEspecieObligacion.frm.submit();
}

_AprovEspecieObligacion.fnInit = function (data, codObligacion) {
    _AprovEspecieObligacion.frm = $("#frmItemAprovEspecieObligacion");

    $.fn.select2.defaults.set("theme", "bootstrap4");
    _AprovEspecieObligacion.frm.find("#ddlAutorizadoId").select2({ minimumResultsForSearch: -1 });

    _AprovEspecieObligacion.fnLoadDatos(data, codObligacion);

    //=====-----Para el registro de datos del formulario-----=====
    _AprovEspecieObligacion.frm.validate(utilSigo.fnValidate({
        rules: {

        },
        messages: {

        },
        fnSubmit: function (form) {
            if (_AprovEspecieObligacion.fnCustomValidateForm()) {
                _AprovEspecieObligacion.fnSaveForm(_AprovEspecieObligacion.fnSetDatos());
            }
        }
    }));
    //Validación de controles que usan Select2
    _AprovEspecieObligacion.frm.find("select.select2-hidden-accessible").on("change", function (e) {
        $(this).valid();
    });
}