"use strict";
var _EspecieCenso = {};

_EspecieCenso.fnSaveForm = function (data) { /*implementado desde donde se instancia*/ }

_EspecieCenso.fnLoadDatos = function (data) {
    if (data != null && data != "") {
        _EspecieCenso.frm.find("#hdfRegEstado").val(data["RegEstado"]);
        _EspecieCenso.frm.find("#hdfCodSecuencial").val(data["COD_SECUENCIAL"]);
        _EspecieCenso.frm.find("#ddlProcedenciaId").select2("val", [data["PROCEDENCIA_COD_TDESCRIPTIVA"]]);
        _EspecieCenso.frm.find("#txtNumeroIndiv").val(data["PROCEDENCIA_NUM_INDIVIDUOS"]);
        if (_EspecieCenso.frm.find("#hdfTipo").val() == "ESPECIE_VERTEBRADO") {
            _EspecieCenso.frm.find("#ddlTipoIdentificacionId").select2("val", [data["TIDENTI_COD_TDESCRIPTIVA"]]);
            _EspecieCenso.frm.find("#txtCodigo").val(data["CODIGO_NOMBRE"]);
            _EspecieCenso.frm.find("#ddlEspecieSexoId").select2("val", [data["COD_SEXO"]]);
        }
        _EspecieCenso.frm.find("#txtObservacion").val(data["OBSERVACION"]);
        _renderComboEspecie.fnInit("FAUNA", data["COD_ESPECIES"], data["DESCRIPCION"]);
    } else {
        _EspecieCenso.frm.find("#hdfRegEstado").val("1");
        _EspecieCenso.frm.find("#hdfCodSecuencial").val("0");
        _renderComboEspecie.fnInit("FAUNA", "", "");
    }
}

_EspecieCenso.fnSetDatos = function () {
    var data = [];
    var regEstado = _EspecieCenso.frm.find("#hdfRegEstado").val();
    data["RegEstado"] = regEstado == "0" ? "2" : regEstado;
    data["COD_SECUENCIAL"] = _EspecieCenso.frm.find("#hdfCodSecuencial").val();
    data["COD_ESPECIES"] = _renderComboEspecie.fnGetCodEspecie();
    data["DESCRIPCION"] = _renderComboEspecie.fnGetEspecie();
    data["PROCEDENCIA_COD_TDESCRIPTIVA"] = _EspecieCenso.frm.find("#ddlProcedenciaId").val();
    data["DESC_PROCEDENCIA"] = _EspecieCenso.frm.find("#ddlProcedenciaId").val() == "0000000" ? "" : _EspecieCenso.frm.find("#ddlProcedenciaId").select2("data")[0].text;
    data["PROCEDENCIA_NUM_INDIVIDUOS"] = _EspecieCenso.frm.find("#txtNumeroIndiv").val();
    data["TIPO_VERTEBRADO"]="MI";
    if (_EspecieCenso.frm.find("#hdfTipo").val() == "ESPECIE_VERTEBRADO") {
        data["TIDENTI_COD_TDESCRIPTIVA"]=_EspecieCenso.frm.find("#ddlTipoIdentificacionId").val();
        data["DESC_TIDENTIFICACION"] = _EspecieCenso.frm.find("#ddlTipoIdentificacionId").val() == "0000000" ? "" : _EspecieCenso.frm.find("#ddlTipoIdentificacionId").select2("data")[0].text;
        data["CODIGO_NOMBRE"]=_EspecieCenso.frm.find("#txtCodigo").val();
        data["COD_SEXO"] = _EspecieCenso.frm.find("#ddlEspecieSexoId").val();
        data["SEXO"] = _EspecieCenso.frm.find("#ddlEspecieSexoId").val() == "0000000" ? "" : _EspecieCenso.frm.find("#ddlEspecieSexoId").select2("data")[0].text;
        data["TIPO_VERTEBRADO"]="MA";
    }
    data["OBSERVACION"] = _EspecieCenso.frm.find("#txtObservacion").val();
    data["DESC_ACATEGORIA"] = "";
    return data;
}

_EspecieCenso.fnCustomValidateForm = function () {
    if (_renderComboEspecie.fnGetCodEspecie() == null) {
        utilSigo.toastWarning("Aviso", "Seleccione la especie a registrar"); return false;
    }
    return true;
}

_EspecieCenso.fnSubmitForm = function () {
    _EspecieCenso.frm.submit();
}

_EspecieCenso.fnInit = function (data) {
    _EspecieCenso.frm = $("#frmItemEspecieCenso");

    $.fn.select2.defaults.set("theme", "bootstrap4");
    _EspecieCenso.frm.find("#ddlEspecieSexoId").select2({ minimumResultsForSearch: -1 });
    _EspecieCenso.frm.find("#ddlProcedenciaId").select2({ minimumResultsForSearch: -1 });
    _EspecieCenso.frm.find("#ddlTipoIdentificacionId").select2();

    _EspecieCenso.fnLoadDatos(data);

    _EspecieCenso.frm.find(".datos_vertebrado").hide();
    $("#lblItemEspecieCensoTitulo").text("Nacimiento");
    if (_EspecieCenso.frm.find("#hdfTipo").val() == "ESPECIE_VERTEBRADO") {
        _EspecieCenso.frm.find(".datos_vertebrado").show();
        $("#lblItemEspecieCensoTitulo").text("Vertebrado Menor e Invertebrado");
    }

    if (_EspecieCenso.frm.find("#hdfTipo").val() == "ESPECIE_VERTEBRADO") {
        //=====-----Para el registro de datos del formulario-----=====
        //Validación personalizada
        jQuery.validator.addMethod("invalidFrmInvert", function (value, element) {
            switch ($(element).attr('id')) {
                case 'ddlProcedenciaId':
                case 'ddlTipoIdentificacionId':
                case 'ddlEspecieSexoId':
                    return (value == '0000000') ? false : true;
                    break
            }
        });

        _EspecieCenso.frm.validate(utilSigo.fnValidate({
            rules: {
                txtNumeroIndiv: { required: true },
                ddlProcedenciaId: { invalidFrmInvert: true },
                ddlTipoIdentificacionId: { invalidFrmInvert: true },
                ddlEspecieSexoId: { invalidFrmInvert: true }
            },
            messages: {
                txtNumeroIndiv: { required: "Ingrese el número de individuos" },
                ddlProcedenciaId: { invalidFrmInvert: "Seleccione la procedencia" },
                ddlTipoIdentificacionId: { invalidFrmInvert: "Seleccione el tipo de identificación" },
                ddlEspecieSexoId: { invalidFrmInvert: "Seleccione el sexo de la especie" }
            },
            fnSubmit: function (form) {
                if (_EspecieCenso.fnCustomValidateForm()) {
                    _EspecieCenso.fnSaveForm(_EspecieCenso.fnSetDatos());
                }
            }
        }));
    } else {
        //=====-----Para el registro de datos del formulario-----=====
        //Validación personalizada
        jQuery.validator.addMethod("invalidFrmInvert", function (value, element) {
            switch ($(element).attr('id')) {
                case 'ddlProcedenciaId':
                    return (value == '0000000') ? false : true;
                    break
            }
        });

        _EspecieCenso.frm.validate(utilSigo.fnValidate({
            rules: {
                txtNumeroIndiv: { required: true },
                ddlProcedenciaId: { invalidFrmInvert: true }
            },
            messages: {
                txtNumeroIndiv: { required: "Ingrese el número de individuos" },
                ddlProcedenciaId: { invalidFrmInvert: "Seleccione la procedencia" }
            },
            fnSubmit: function (form) {
                if (_EspecieCenso.fnCustomValidateForm()) {
                    _EspecieCenso.fnSaveForm(_EspecieCenso.fnSetDatos());
                }
            }
        }));
    }

    //Validación de controles que usan Select2
    _EspecieCenso.frm.find("select.select2-hidden-accessible").on("change", function (e) {
        $(this).valid();
    });
}