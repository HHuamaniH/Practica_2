"use strict";
var _ManejoRegistro = {};

_ManejoRegistro.fnSaveForm = function (data) { /*implementado desde donde se instancia*/ }

_ManejoRegistro.fnLoadDatos = function (data) {
    if (data != null && data != "") {
        _ManejoRegistro.frm.find("#hdfRegEstado").val(data["RegEstado"]);
        _ManejoRegistro.frm.find("#ddlRegistroId").select2("val", [data["COD_TDESCRIPTIVA"]]);
        _ManejoRegistro.frm.find("#txtFechaActualiza").val(data["FECHA_ACTUALIZACION"]);
        _ManejoRegistro.frm.find("#txtObservacion").val(data["OBSERVACION"]);
    } else {
        _ManejoRegistro.frm.find("#hdfRegEstado").val("1");
    }
}

_ManejoRegistro.fnSetDatos = function () {
    var data = [];
    var regEstado = _ManejoRegistro.frm.find("#hdfRegEstado").val();
    data["RegEstado"] = regEstado == "0" ? "2" : regEstado;
    data["COD_TDESCRIPTIVA"] = _ManejoRegistro.frm.find("#ddlRegistroId").val();
    data["DESCRIPCION"] = _ManejoRegistro.frm.find("#ddlRegistroId").val() == "0000000" ? "" : _ManejoRegistro.frm.find("#ddlRegistroId").select2("data")[0].text;
    data["FECHA_ACTUALIZACION"] = _ManejoRegistro.frm.find("#txtFechaActualiza").val();
    data["OBSERVACION"] = _ManejoRegistro.frm.find("#txtObservacion").val();
    return data;
}

_ManejoRegistro.fnSubmitForm = function () {
    _ManejoRegistro.frm.submit();
}

_ManejoRegistro.fnInit = function (data) {
    _ManejoRegistro.frm = $("#frmItemManejoRegistro");

    $.fn.select2.defaults.set("theme", "bootstrap4");
    _ManejoRegistro.frm.find("#ddlRegistroId").select2();
    utilSigo.fnFormatDate(_ManejoRegistro.frm.find("#txtFechaActualiza"));

    _ManejoRegistro.fnLoadDatos(data);

    //=====-----Para el registro de datos del formulario-----=====
    //Validación personalizada
    jQuery.validator.addMethod("invalidFrmRegistro", function (value, element) {
        switch ($(element).attr('id')) {
            case 'ddlRegistroId':
                return (value == '0000000') ? false : true;
                break;
        }
    });

    _ManejoRegistro.frm.validate(utilSigo.fnValidate({
        rules: {
            ddlRegistroId: { invalidFrmRegistro: true }
        },
        messages: {
            ddlRegistroId: { invalidFrmRegistro: "Seleccione el registro" }
        },
        fnSubmit: function (form) {
            _ManejoRegistro.fnSaveForm(_ManejoRegistro.fnSetDatos());
        }
    }));
    //Validación de controles que usan Select2
    _ManejoRegistro.frm.find("select.select2-hidden-accessible").on("change", function (e) {
        $(this).valid();
    });
}