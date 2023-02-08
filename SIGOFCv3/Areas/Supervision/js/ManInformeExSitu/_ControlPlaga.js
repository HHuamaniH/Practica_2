"use strict";
var _ControlPlaga = {};

_ControlPlaga.fnSaveForm = function (data) { /*implementado desde donde se instancia*/ }

_ControlPlaga.fnLoadDatos = function (data) {
    if (data != null && data != "") {
        _ControlPlaga.frm.find("#hdfRegEstado").val(data["RegEstado"]);
        _ControlPlaga.frm.find("#ddlPlagaId").select2("val", [data["COD_TDESCRIPTIVA"]]);
        _ControlPlaga.frm.find("#txtFrecuencia").val(data["FRECUENCIA"]);
        _ControlPlaga.frm.find("#txtMetFisico").val(data["METODO_FISICO"]);
        _ControlPlaga.frm.find("#txtMetQuimico").val(data["METODO_QUIMICO"]);
        _ControlPlaga.frm.find("#txtObservacion").val(data["OBSERVACION"]);
    } else {
        _ControlPlaga.frm.find("#hdfRegEstado").val("1");
    }
}

_ControlPlaga.fnSetDatos = function () {
    var data = [];
    var regEstado = _ControlPlaga.frm.find("#hdfRegEstado").val();
    data["RegEstado"] = regEstado == "0" ? "2" : regEstado;
    data["COD_TDESCRIPTIVA"] = _ControlPlaga.frm.find("#ddlPlagaId").val();
    data["DESCRIPCION"] = _ControlPlaga.frm.find("#ddlPlagaId").val() == "0000000" ? "" : _ControlPlaga.frm.find("#ddlPlagaId").select2("data")[0].text;
    data["FRECUENCIA"]=_ControlPlaga.frm.find("#txtFrecuencia").val();
    data["METODO_FISICO"]=_ControlPlaga.frm.find("#txtMetFisico").val();
    data["METODO_QUIMICO"]=_ControlPlaga.frm.find("#txtMetQuimico").val();
    data["OBSERVACION"] = _ControlPlaga.frm.find("#txtObservacion").val();
    return data;
}

_ControlPlaga.fnSubmitForm = function () {
    _ControlPlaga.frm.submit();
}

_ControlPlaga.fnInit = function (data) {
    _ControlPlaga.frm = $("#frmItemControlPlaga");

    $.fn.select2.defaults.set("theme", "bootstrap4");
    _ControlPlaga.frm.find("#ddlPlagaId").select2();

    _ControlPlaga.fnLoadDatos(data);

    //=====-----Para el registro de datos del formulario-----=====
    //Validación personalizada
    jQuery.validator.addMethod("invalidFrmPlaga", function (value, element) {
        switch ($(element).attr('id')) {
            case 'ddlPlagaId':
                return (value == '0000000') ? false : true;
                break
        }
    });

    _ControlPlaga.frm.validate(utilSigo.fnValidate({
        rules: {
            ddlPlagaId: { invalidFrmPlaga: true }
        },
        messages: {
            ddlPlagaId: { invalidFrmPlaga: "Seleccione la plaga a registrar" }
        },
        fnSubmit: function (form) {
            _ControlPlaga.fnSaveForm(_ControlPlaga.fnSetDatos());
        }
    }));
    //Validación de controles que usan Select2
    _ControlPlaga.frm.find("select.select2-hidden-accessible").on("change", function (e) {
        $(this).valid();
    });
}