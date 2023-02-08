"use strict";
var _EquipoContencion = {};

_EquipoContencion.fnSaveForm = function (data) { /*implementado desde donde se instancia*/ }

_EquipoContencion.fnLoadDatos = function (data) {
    if (data != null && data != "") {
        _EquipoContencion.frm.find("#hdfRegEstado").val(data["RegEstado"]);
        _EquipoContencion.frm.find("#ddlTipoEquipoId").select2("val", [data["COD_TDESCRIPTIVA"]]);
        _EquipoContencion.frm.find("#txtObservacion").val(data["OBSERVACION"]);
    } else {
        _EquipoContencion.frm.find("#hdfRegEstado").val("1");
    }
}

_EquipoContencion.fnSetDatos = function () {
    var data = [];
    var regEstado = _EquipoContencion.frm.find("#hdfRegEstado").val();
    data["RegEstado"] = regEstado == "0" ? "2" : regEstado;
    data["COD_TDESCRIPTIVA"] = _EquipoContencion.frm.find("#ddlTipoEquipoId").val();
    data["DESCRIPCION"] = _EquipoContencion.frm.find("#ddlTipoEquipoId").val() == "0000000" ? "" : _EquipoContencion.frm.find("#ddlTipoEquipoId").select2("data")[0].text;
    data["OBSERVACION"] = _EquipoContencion.frm.find("#txtObservacion").val();
    return data;
}

_EquipoContencion.fnSubmitForm = function () {
    _EquipoContencion.frm.submit();
}

_EquipoContencion.fnInit = function (data) {
    _EquipoContencion.frm = $("#frmItemEquipoContencion");

    $.fn.select2.defaults.set("theme", "bootstrap4");
    _EquipoContencion.frm.find("#ddlTipoEquipoId").select2();

    _EquipoContencion.fnLoadDatos(data);

    if (_EquipoContencion.frm.find("#hdfTipo").val() == "EQUIPO_DESINFECCION") {
        $("#lblItemEquipoContencionTitulo").text("Equipo de Desinfección");
    }

    //=====-----Para el registro de datos del formulario-----=====
    //Validación personalizada
    jQuery.validator.addMethod("invalidFrmEquipo", function (value, element) {
        switch ($(element).attr('id')) {
            case 'ddlTipoEquipoId':
                return (value == '0000000') ? false : true;
                break
        }
    });

    _EquipoContencion.frm.validate(utilSigo.fnValidate({
        rules: {
            ddlTipoEquipoId: { invalidFrmEquipo: true }
        },
        messages: {
            ddlTipoEquipoId: { invalidFrmEquipo: "Seleccione el material o equipo de contención" }
        },
        fnSubmit: function (form) {
            _EquipoContencion.fnSaveForm(_EquipoContencion.fnSetDatos());
        }
    }));
    //Validación de controles que usan Select2
    _EquipoContencion.frm.find("select.select2-hidden-accessible").on("change", function (e) {
        $(this).valid();
    });
}