"use strict";
var _VolumenAnalizado = {};

_VolumenAnalizado.fnSaveForm = function (data) { /*implementado desde donde se instancia*/ }

_VolumenAnalizado.fnLoadDatos = function (data) {
    if (data != null && data != "") {
        _VolumenAnalizado.frm.find("#hdfRegEstado").val(data["RegEstado"]);
        _VolumenAnalizado.frm.find("#hdfCodSecuencial").val(data["COD_SECUENCIAL"]);
        _VolumenAnalizado.frm.find("#txtVolAprobado").val(data["VOLUMEN_APROBADO"]);
        _VolumenAnalizado.frm.find("#txtVolMovilizado").val(data["VOLUMEN_MOVILIZADO"]);
        _VolumenAnalizado.frm.find("#txtVolInjustificado").val(data["VOLUMEN_INJUSTIFICADO"]);
        _VolumenAnalizado.frm.find("#txtVolJustificado").val(data["VOLUMEN_JUSTIFICADO"]);
        _VolumenAnalizado.frm.find("#txtParcelaVolumen").val(data["PCA"]);
        _VolumenAnalizado.frm.find("#txtObservacion").val(data["OBSERVACION"]);       
        _VolumenAnalizado.frm.find("#ddlTipoAprovechamiento_VolAn").val(data["TIPO_APROVECHAMIENTO"]);   
        _VolumenAnalizado.fnCrearUnidadMedida(data["TIPO_APROVECHAMIENTO"]);
        _VolumenAnalizado.frm.find("#ddlUnidadMedida_VolAn").val(data["UNIDAD_MEDIDA"]);       
        _renderComboEspecie.fnInit("FORESTAL", data["COD_ESPECIES"], data["ESPECIES"]);
    } else {
        _VolumenAnalizado.frm.find("#hdfRegEstado").val("1");
        _VolumenAnalizado.frm.find("#hdfCodSecuencial").val("0");
        _renderComboEspecie.fnInit("FORESTAL", "", "");
    }
}

_VolumenAnalizado.fnSetDatos = function () {
    var data = [];
    var regEstado = _VolumenAnalizado.frm.find("#hdfRegEstado").val();
    data["RegEstado"] = regEstado == "0" ? "2" : regEstado;
    data["COD_SECUENCIAL"] = _VolumenAnalizado.frm.find("#hdfCodSecuencial").val();
    data["COD_ESPECIES"] = _renderComboEspecie.fnGetCodEspecie();
    data["ESPECIES"] = _renderComboEspecie.fnGetEspecie();
    data["VOLUMEN_APROBADO"] = _VolumenAnalizado.frm.find("#txtVolAprobado").val();
    data["VOLUMEN_MOVILIZADO"] = _VolumenAnalizado.frm.find("#txtVolMovilizado").val();
    data["VOLUMEN_INJUSTIFICADO"] = _VolumenAnalizado.frm.find("#txtVolInjustificado").val();
    data["VOLUMEN_JUSTIFICADO"] = _VolumenAnalizado.frm.find("#txtVolJustificado").val();
    data["PCA"] = _VolumenAnalizado.frm.find("#txtParcelaVolumen").val() == "0000000" ? "" : _VolumenAnalizado.frm.find("#txtParcelaVolumen").val();
    data["OBSERVACION"] = _VolumenAnalizado.frm.find("#txtObservacion").val();   
    data["TIPO_APROVECHAMIENTO"] = _VolumenAnalizado.frm.find("#ddlTipoAprovechamiento_VolAn").val();   
    data["UNIDAD_MEDIDA"] = _VolumenAnalizado.frm.find("#ddlUnidadMedida_VolAn").val();   

    return data;
}

_VolumenAnalizado.fnCustomValidateForm = function () {
    if (_renderComboEspecie.fnGetCodEspecie() == null) {
        utilSigo.toastWarning("Aviso", "Seleccione la especie a registrar"); return false;
    }
    return true;
}

_VolumenAnalizado.fnCrearUnidadMedida = function (valor) {

    var htmlddlUnidadMedida_VolAn = "";
    var ddlUnidadMedida_VolAn = document.getElementById('ddlUnidadMedida_VolAn');
    switch (valor) {
        case "CARBON":
            htmlddlUnidadMedida_VolAn += '<option value="KG">KG</option>';
            ddlUnidadMedida_VolAn.innerHTML = htmlddlUnidadMedida_VolAn;
            break;
        case "MADERABLES":
            htmlddlUnidadMedida_VolAn += '<option value="M3">M3</option>';
            htmlddlUnidadMedida_VolAn += '<option value="KG">KG</option>';
            ddlUnidadMedida_VolAn.innerHTML = htmlddlUnidadMedida_VolAn;
            break;
        case "NO MADERABLES":
            htmlddlUnidadMedida_VolAn += '<option value="KG">KG</option>';
            htmlddlUnidadMedida_VolAn += '<option value="LT">LT</option>';
            ddlUnidadMedida_VolAn.innerHTML = htmlddlUnidadMedida_VolAn;
            break;
        default:
    }


    return true;
}

_VolumenAnalizado.fnSubmitForm = function () {
    _VolumenAnalizado.frm.submit();
}

_VolumenAnalizado.fnInit = function (data) {    

    _VolumenAnalizado.frm = $("#frmItemVolumenAnalizado");

    _VolumenAnalizado.fnLoadDatos(data);

    //=====-----Para el registro de datos del formulario-----=====
    //Validación personalizada
    jQuery.validator.addMethod("invalidFrmVolAnaliza", function (value, element) {
        switch ($(element).attr('id')) {
            case 'ddlRenderComboEspecieId':
                return (value == '0000000') ? false : true;
                break
        }
    });
    _VolumenAnalizado.frm.validate(utilSigo.fnValidate({
        rules: {
            ddlRenderComboEspecieId: { invalidFrmVolAnaliza: true },
            txtVolAprobado: { required: true },
            txtVolMovilizado: { required: true },
            txtVolInjustificado: { required: true },
            txtVolJustificado: { required: true }
        },
        messages: {
            ddlRenderComboEspecieId: { invalidFrmVolAnaliza: "Seleccione la especie" },
            txtVolAprobado: { required: "Ingrese el volumen aprobado analizado" },
            txtVolMovilizado: { required: "Ingrese el volumen movilizado analizado" },
            txtVolInjustificado: { required: "Ingrese el volumen injustificado" },
            txtVolJustificado: { required: "Ingrese el volumen justificado" }
        },
        fnSubmit: function (form) {
            if (_VolumenAnalizado.fnCustomValidateForm()) {
                _VolumenAnalizado.fnSaveForm(_VolumenAnalizado.fnSetDatos());
            }
        }
    }));
    //Validación de controles que usan Select2
    _VolumenAnalizado.frm.find("select.select2-hidden-accessible").on("change", function (e) {
        $(this).valid();
    });

    _VolumenAnalizado.frm.find("#ddlTipoAprovechamiento_VolAn").on("change", function (e) {
        _VolumenAnalizado.fnCrearUnidadMedida(this.value);
    });
}
