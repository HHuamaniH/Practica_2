"use strict";
var _EspecieNacimiento = {};

_EspecieNacimiento.fnSaveForm = function (data) { /*implementado desde donde se instancia*/ }

_EspecieNacimiento.fnLoadDatos = function (data) {
    if (data != null && data != "") {
        _EspecieNacimiento.frm.find("#hdfRegEstado").val(data["RegEstado"]);
        _EspecieNacimiento.frm.find("#hdfCodSecuencial").val(data["COD_SECUENCIAL"]);
        _EspecieNacimiento.frm.find("#ddlEspecieSexoId").select2("val", [data["COD_SEXO"]]);
        _EspecieNacimiento.frm.find("#txtNumeroIndiv").val(data["NUMERO"]);
        _EspecieNacimiento.frm.find("#txtFecha").val(data["FECHA_PUBLICACION"]);
        if (_EspecieNacimiento.frm.find("#hdfTipo").val()=="NACIMIENTO_ESPECIE") {
            _EspecieNacimiento.frm.find("#txtDocumento").val(data["DESCRIPCION"]);
            _EspecieNacimiento.frm.find("#ddlProgramaId").select2("val", [data["OBJETIVO"]]);
        } else {//EGRESO_ESPECIE
            _EspecieNacimiento.frm.find("#txtDocumento").val(data["DOCUMENTO"]);
            _EspecieNacimiento.frm.find("#ddlMotivoId").select2("val", [data["COD_MOTIVO"]]);
            _EspecieNacimiento.frm.find("#ddlNecropsiaId").select2("val", [data["NECROPSIA"] == "" ? "0000000" : data["NECROPSIA"]]);
            _EspecieNacimiento.frm.find("#txtEdad").val(data["EDAD"]);
            _EspecieNacimiento.frm.find("#txtCodigo").val(data["CODIGO_NOMBRE"]);
            _EspecieNacimiento.frm.find("#txtDiagnostico").val(data["DIAGNOSTICO"]);
        }
        _EspecieNacimiento.frm.find("#txtObservacion").val(data["OBSERVACION"]);
        _renderComboEspecie.fnInit("FAUNA", data["COD_ESPECIES"], data["NOMBRE_COMUN"]);
    } else {
        _EspecieNacimiento.frm.find("#hdfRegEstado").val("1");
        _EspecieNacimiento.frm.find("#hdfCodSecuencial").val("0");
        _renderComboEspecie.fnInit("FAUNA", "", "");
    }
}

_EspecieNacimiento.fnSetDatos = function () {
    var data = [];
    var regEstado = _EspecieNacimiento.frm.find("#hdfRegEstado").val();
    data["RegEstado"] = regEstado == "0" ? "2" : regEstado;
    data["COD_SECUENCIAL"] = _EspecieNacimiento.frm.find("#hdfCodSecuencial").val();
    data["COD_ESPECIES"] = _renderComboEspecie.fnGetCodEspecie();
    data["NOMBRE_COMUN"] = _renderComboEspecie.fnGetEspecie();
    data["COD_SEXO"] = _EspecieNacimiento.frm.find("#ddlEspecieSexoId").val();
    data["SEXO"] = _EspecieNacimiento.frm.find("#ddlEspecieSexoId").val() == "0000000" ? "" : _EspecieNacimiento.frm.find("#ddlEspecieSexoId").select2("data")[0].text;
    data["NUMERO"] = _EspecieNacimiento.frm.find("#txtNumeroIndiv").val();
    data["FECHA_PUBLICACION"] = _EspecieNacimiento.frm.find("#txtFecha").val();
    if (_EspecieNacimiento.frm.find("#hdfTipo").val() == "NACIMIENTO_ESPECIE") {
        data["DESCRIPCION"] = _EspecieNacimiento.frm.find("#txtDocumento").val();
        data["OBJETIVO"] = _EspecieNacimiento.frm.find("#ddlProgramaId").val();
    } else {//EGRESO_ESPECIE
        data["DOCUMENTO"] = _EspecieNacimiento.frm.find("#txtDocumento").val();
        data["COD_MOTIVO"] = _EspecieNacimiento.frm.find("#ddlMotivoId").val();
        data["MOTIVO"] = _EspecieNacimiento.frm.find("#ddlMotivoId").val() == "0000000" ? "" : _EspecieNacimiento.frm.find("#ddlMotivoId").select2("data")[0].text;
        if (data["COD_MOTIVO"]=="0000001") {
            data["NECROPSIA"] = _EspecieNacimiento.frm.find("#ddlNecropsiaId").val() == "0000000" ? "" : _EspecieNacimiento.frm.find("#ddlNecropsiaId").select2("data")[0].text;
            data["DIAGNOSTICO"] = _EspecieNacimiento.frm.find("#txtDiagnostico").val();
        } else {
            data["NECROPSIA"] = "";
            data["DIAGNOSTICO"] = "";
        }
        data["EDAD"] = _EspecieNacimiento.frm.find("#txtEdad").val();
        data["CODIGO_NOMBRE"] = _EspecieNacimiento.frm.find("#txtCodigo").val();
    }
    data["OBSERVACION"] = _EspecieNacimiento.frm.find("#txtObservacion").val();
    return data;
}

_EspecieNacimiento.fnCustomValidateForm = function () {
    if (_renderComboEspecie.fnGetCodEspecie() == null) {
        utilSigo.toastWarning("Aviso", "Seleccione la especie a registrar"); return false;
    }
    return true;
}

_EspecieNacimiento.fnSubmitForm = function () {
    _EspecieNacimiento.frm.submit();
}

_EspecieNacimiento.fnShowEgresoMuerte = function () {
    _EspecieNacimiento.frm.find("#dvNecropsia").hide();
    _EspecieNacimiento.frm.find("#dvDiagnostico").hide();
    if (_EspecieNacimiento.frm.find("#ddlMotivoId").val() == "0000001") {
        _EspecieNacimiento.frm.find("#dvNecropsia").show();
        _EspecieNacimiento.frm.find("#dvDiagnostico").show();
    }
}

_EspecieNacimiento.fnInit = function (data) {
    _EspecieNacimiento.frm = $("#frmItemEspecieNacimiento");
    debugger;
    $.fn.select2.defaults.set("theme", "bootstrap4");
    _EspecieNacimiento.frm.find("#ddlEspecieSexoId").select2({ minimumResultsForSearch: -1 });
    _EspecieNacimiento.frm.find("#ddlProgramaId").select2({ minimumResultsForSearch: -1 });
    _EspecieNacimiento.frm.find("#ddlMotivoId").select2({ minimumResultsForSearch: -1 });
    _EspecieNacimiento.frm.find("#ddlNecropsiaId").select2({ minimumResultsForSearch: -1 });

    utilSigo.fnFormatDate(_EspecieNacimiento.frm.find("#txtFecha"));

    _EspecieNacimiento.fnLoadDatos(data);

    _EspecieNacimiento.frm.find(".datos_nacimiento").hide();
    _EspecieNacimiento.frm.find(".datos_egreso").hide();
    if (_EspecieNacimiento.frm.find("#hdfTipo").val()=="NACIMIENTO_ESPECIE") {
        _EspecieNacimiento.frm.find(".datos_nacimiento").show();
        $("#lblItemEspecieNacimientoTitulo").text("Nacimiento");
    } else {//EGRESO_ESPECIE
        _EspecieNacimiento.frm.find(".datos_egreso").show();
        $("#lblItemEspecieNacimientoTitulo").text("Egreso");
    }

    _EspecieNacimiento.fnShowEgresoMuerte();
    _EspecieNacimiento.frm.find("#ddlMotivoId").change(function () {
        _EspecieNacimiento.fnShowEgresoMuerte();
    });

    if (_EspecieNacimiento.frm.find("#hdfTipo").val() == "NACIMIENTO_ESPECIE") {
        //=====-----Para el registro de datos del formulario-----=====
        //Validación personalizada
        jQuery.validator.addMethod("invalidFrmNac", function (value, element) {
            switch ($(element).attr('id')) {
                case 'ddlEspecieSexoId':
                case 'ddlProgramaId':
                    return (value == '0000000') ? false : true;
                    break
            }
        });

        _EspecieNacimiento.frm.validate(utilSigo.fnValidate({
            rules: {
                txtNumeroIndiv: { required: true },
                ddlEspecieSexoId: { invalidFrmNac: true },
                ddlProgramaId: { invalidFrmNac: true }
            },
            messages: {
                txtNumeroIndiv: { required: "Ingrese el número de individuos" },
                ddlEspecieSexoId: { invalidFrmNac: "Seleccione el sexo de la especie" },
                ddlProgramaId: { invalidFrmNac: "Seleccione una opción" }
            },
            fnSubmit: function (form) {
                if (_EspecieNacimiento.fnCustomValidateForm()) {
                    _EspecieNacimiento.fnSaveForm(_EspecieNacimiento.fnSetDatos());
                }
            }
        }));
    } else {
        //=====-----Para el registro de datos del formulario-----=====
        //Validación personalizada
        jQuery.validator.addMethod("invalidFrmNac", function (value, element) {
            switch ($(element).attr('id')) {
                case 'ddlEspecieSexoId':
                case 'ddlMotivoId':
                    return (value == '0000000') ? false : true;
                    break
            }
        });

        _EspecieNacimiento.frm.validate(utilSigo.fnValidate({
            rules: {
                txtNumeroIndiv: { required: true },
                ddlEspecieSexoId: { invalidFrmNac: true },
                txtDocumento: { required: true },
                ddlMotivoId: { invalidFrmNac: true }
            },
            messages: {
                txtNumeroIndiv: { required: "Ingrese el número de individuos" },
                ddlEspecieSexoId: { invalidFrmNac: "Seleccione el sexo de la especie" },
                txtDocumento: { required: "Ingrese el documento" },
                ddlMotivoId: { invalidFrmNac: "Seleccione el motivo" }
            },
            fnSubmit: function (form) {
                if (_EspecieNacimiento.fnCustomValidateForm()) {
                    _EspecieNacimiento.fnSaveForm(_EspecieNacimiento.fnSetDatos());
                }
            }
        }));
    }

    //Validación de controles que usan Select2
    _EspecieNacimiento.frm.find("select.select2-hidden-accessible").on("change", function (e) {
        $(this).valid();
    });
}