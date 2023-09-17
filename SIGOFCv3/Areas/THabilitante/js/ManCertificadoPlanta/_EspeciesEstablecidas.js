"use strict";
var _EspeciesEstablecidas = {};

_EspeciesEstablecidas.fnSaveForm = function (data) { /*implementado desde donde se instancia*/ }

_EspeciesEstablecidas.fnLoadDatos = function (data) {
    if (data != null && data != "") {
        _EspeciesEstablecidas.frm.find("#hdfRegEstado").val(data["RegEstado"]);
        _EspeciesEstablecidas.frm.find("#hdfCodSecuencial").val(data["COD_SECUENCIAL"]);        

        _renderComboEspecie.fnInit("FAUNA", data["COD_ESPECIES"], data["DESC_ESPECIES"]);
        _EspeciesEstablecidas.frm.find("#txtSisPlanta").val(data["SIS_PLANTA"]);
        _EspeciesEstablecidas.frm.find("#ddlUnidadMedidaId").select2("val", [data["UNI_MEDIDA"]]);
        _EspeciesEstablecidas.frm.find("#txtCantidad").val(data["CANTIDAD"]);
        _EspeciesEstablecidas.frm.find("#txtFines").val(data["FINES"]);
        _EspeciesEstablecidas.frm.find("#txtObservacion").val(data["OBSERVACION"]);        
    } else {
        _EspeciesEstablecidas.frm.find("#hdfRegEstado").val("1");
        _EspeciesEstablecidas.frm.find("#hdfCodSecuencial").val("0");
        _renderComboEspecie.fnInit("FAUNA", "", "");
    }
}

_EspeciesEstablecidas.fnSetDatos = function () {
    var data = [];
    var regEstado = _EspeciesEstablecidas.frm.find("#hdfRegEstado").val();
    data["RegEstado"] = regEstado == "0" ? "2" : regEstado;
    data["COD_SECUENCIAL"] = _EspeciesEstablecidas.frm.find("#hdfCodSecuencial").val();        
    data["COD_ESPECIES"] = _renderComboEspecie.fnGetCodEspecie();
    data["DESC_ESPECIES"] = _renderComboEspecie.fnGetEspecie();    
    data["SIS_PLANTA"] = _EspeciesEstablecidas.frm.find("#txtSisPlanta").val();
    data["UNI_MEDIDA"] = _EspeciesEstablecidas.frm.find("#ddlUnidadMedidaId").val();    
    data["CANTIDAD"] = _EspeciesEstablecidas.frm.find("#txtCantidad").val();
    data["FINES"] = _EspeciesEstablecidas.frm.find("#txtFines").val();
    data["OBSERVACION"] = _EspeciesEstablecidas.frm.find("#txtObservacion").val();    
    return data;
}

_EspeciesEstablecidas.fnCustomValidateForm = function () {
    if (_renderComboEspecie.fnGetCodEspecie() == null) {
        utilSigo.toastWarning("Aviso", "Seleccione la especie a registrar"); return false;
    } else if (_EspeciesEstablecidas.frm.find("#txtSisPlanta").val() == "" || _EspeciesEstablecidas.frm.find("#txtSisPlanta").val() == null) {
        utilSigo.toastWarning("Aviso", "Ingrese el Sistema de Plantación"); return false;
    } else if (_EspeciesEstablecidas.frm.find("#txtCantidad").val() == "" || _EspeciesEstablecidas.frm.find("#txtSisPlanta").val() == null) {
        utilSigo.toastWarning("Aviso", "Ingrese la Cantidad"); return false;
    }
    return true;
}

_EspeciesEstablecidas.fnSubmitForm = function () {
    _EspeciesEstablecidas.frm.submit();
}

_EspeciesEstablecidas.fnInit = function (data) {
    _EspeciesEstablecidas.frm = $("#frmItemEspeciesEstablecidas");

    $.fn.select2.defaults.set("theme", "bootstrap4");
    _EspeciesEstablecidas.frm.find("#ddlUnidadMedidaId").select2({ minimumResultsForSearch: -1 });
    _EspeciesEstablecidas.fnLoadDatos(data);

    //=====-----Para el registro de datos del formulario-----=====
    //Validación personalizada
    jQuery.validator.addMethod("invalidFrmFauna", function (value, element) {
        switch ($(element).attr('id')) {
            case 'ddlRenderComboEspecieId':
                return (value == '0000000') ? false : true;
                break
        }
    });
    _EspeciesEstablecidas.frm.validate(utilSigo.fnValidate({
        rules: {
            ddlRenderComboEspecieId: { invalidFrmFauna: true },
            txtSisPlanta: { required: true },
            txtCantidad: { required: true }           
        },
        messages: {
            ddlRenderComboEspecieId: { invalidFrmFauna: "Seleccione la especie" },
            txtSisPlanta: { required: "Ingrese el sistema de plantación" },
            txtCantidad: { required: "Ingrese la cantidad" }           
        },
        fnSubmit: function (form) {
            if (_EspeciesEstablecidas.fnCustomValidateForm()) {
                _EspeciesEstablecidas.fnSaveForm(_EspeciesEstablecidas.fnSetDatos());
            }
        }
    }));
    //Validación de controles que usan Select2
    _EspeciesEstablecidas.frm.find("select.select2-hidden-accessible").on("change", function (e) {
        $(this).valid();
    });
}