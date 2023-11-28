"use strict";
var _EspecieForEst = {};

_EspecieForEst.fnSaveForm = function (data) { /*implementado desde donde se instancia*/ }

_EspecieForEst.fnLoadDatos = function (data) {
    if (data != null && data != "") {
        _EspecieForEst.frm.find("#hdfRegEstado").val(data["RegEstado"]);
        _EspecieForEst.frm.find("#hdfCodSecuencial").val(data["COD_SECUENCIAL"]);
        _EspecieForEst.frm.find("#txtCoordEsteRP").val(data["COORDENADA_ESTE_REPLA"]);
        _EspecieForEst.frm.find("#txtCoordNorteRP").val(data["COORDENADA_NORTE_REPLA"]);
        _EspecieForEst.frm.find("#txtCoordEsteRS").val(data["COORDENADA_ESTE_RESUP"]);
        _EspecieForEst.frm.find("#txtCoordNorteRS").val(data["COORDENADA_NORTE_RESUP"]);
        _EspecieForEst.frm.find("#txtDAP").val(data["DAP"]);
        _EspecieForEst.frm.find("#txtAC").val(data["AC"]);        
        _EspecieForEst.frm.find("#txtObservacion").val(data["OBSERVACION"]);        
        _renderComboEspecie.fnInit("FORESTAL", data["COD_ESPECIES_REPLA"], data["DESC_ESPECIES_REPLA"]);
        _renderComboEspecie2.fnInit("FORESTAL", data["COD_ESPECIES_RESUP"], data["DESC_ESPECIES_RESUP"]);
    } else {
        _EspecieForEst.frm.find("#hdfRegEstado").val("1");
        _EspecieForEst.frm.find("#hdfCodSecuencial").val("0");
        _renderComboEspecie.fnInit("FORESTAL", "", "");
        _renderComboEspecie2.fnInit("FORESTAL", "", "");
    }
}

_EspecieForEst.fnSetDatos = function () {
    var data = [];
    var regEstado = _EspecieForEst.frm.find("#hdfRegEstado").val();
    data["RegEstado"] = regEstado == "0" ? "2" : regEstado;
    data["COD_SECUENCIAL"] = _EspecieForEst.frm.find("#hdfCodSecuencial").val();
    data["COD_ESPECIES_REPLA"] = _renderComboEspecie.fnGetCodEspecie();
    data["DESC_ESPECIES_REPLA"] = _renderComboEspecie.fnGetEspecie();
    data["COD_ESPECIES_RESUP"] = _renderComboEspecie2.fnGetCodEspecie();    
    data["DESC_ESPECIES_RESUP"] = _renderComboEspecie2.fnGetEspecie();
    data["COORDENADA_ESTE_REPLA"] = _EspecieForEst.frm.find("#txtCoordEsteRP").val();
    data["COORDENADA_NORTE_REPLA"] = _EspecieForEst.frm.find("#txtCoordNorteRP").val();
    data["COORDENADA_ESTE_RESUP"] = _EspecieForEst.frm.find("#txtCoordEsteRS").val();
    data["COORDENADA_NORTE_RESUP"] = _EspecieForEst.frm.find("#txtCoordNorteRS").val();
    data["DAP"] = _EspecieForEst.frm.find("#txtDAP").val();
    data["AC"] = _EspecieForEst.frm.find("#txtAC").val();
    data["OBSERVACION"] = _EspecieForEst.frm.find("#txtObservacion").val();
    return data;
}

_EspecieForEst.fnCustomValidateForm = function () {
    if (_renderComboEspecie.fnGetCodEspecie() == null) {
        utilSigo.toastWarning("Aviso", "Seleccione la especie a registrar"); return false;
    }
    if (_renderComboEspecie2.fnGetCodEspecie() == null) {
        utilSigo.toastWarning("Aviso", "Seleccione la especie a registrar"); return false;
    }

    return true;
}

_EspecieForEst.fnSubmitForm = function () {
    //const fechaActual = new Date();

    //let fecha = ($("#txtFecha").val()).split('/');

    //if (fecha.length == 3) {
    //    let fechaStr = fecha[2] + "-" + fecha[1] + "-" + fecha[0]
    //    const fechaIngresada = new Date(fechaStr);
    //    if (fechaActual > fechaIngresada) {
    //        _EspecieForEst.frm.submit();
    //    } else {
    //        utilSigo.toastWarning("Aviso", "La Fecha seleccionada no debe ser mayor a la actual."); return false;
    //    }
    //} else {
    //    utilSigo.toastWarning("Aviso", "La Fecha seleccionada no es válido."); return false;
    //}
    _EspecieForEst.frm.submit();

}

_EspecieForEst.fnInit = function (data) {
    _EspecieForEst.frm = $("#frmItemEspecieForEst");

    $.fn.select2.defaults.set("theme", "bootstrap4");
    //_EspecieForEst.frm.find("#ddlTipoAvistRegistroId").select2({ minimumResultsForSearch: -1 });
    //_EspecieForEst.frm.find("#ddlTipoAvistEstratoId").select2({ minimumResultsForSearch: -1 });
    //_EspecieForEst.frm.find("#ddlZonaId").select2({ minimumResultsForSearch: -1 });
    //utilSigo.fnFormatDate(_EspecieForEst.frm.find("#txtFecha"));

    _EspecieForEst.fnLoadDatos(data);

    //=====-----Para el registro de datos del formulario-----=====
    //Validación personalizada
    jQuery.validator.addMethod("invalidFrmEspecieForEst", function (value, element) {
        switch ($(element).attr('id')) {
            case 'ddlRenderComboEspecieId1':
            case 'ddlRenderComboEspecieId2':
                return (value == '0000000') ? false : true;
                break
        }
    });
    _EspecieForEst.frm.validate(utilSigo.fnValidate({
        rules: {
            ddlRenderComboEspecieId1: { invalidFrmEspecieForEst: true },
            ddlRenderComboEspecieId2: { invalidFrmEspecieForEst: true },
            txtCoordEsteRP: { required: true },
            txtCoordNorteRP: { required: true },
            txtCoordEsteRS: { required: true },
            txtCoordNorteRS: { required: true }
        },
        messages: {
            ddlRenderComboEspecieId1: { invalidFrmEspecieForEst: "Seleccione la especie Registro de Plantación" },
            ddlRenderComboEspecieId2: { invalidFrmEspecieForEst: "Seleccione la especie Registro de Supervisión" },
            txtCoordEsteRP: { required: "Ingrese la coordinada Este de Registro de Plantación" },
            txtCoordNorteRP: { required: "Ingrese la coordinada Norte de Registro de Plantación" },
            txtCoordEsteRS: { required: "Ingrese la coordinada Este de Registro de Supervisión" },
            txtCoordNorteRS: { required: "Ingrese la coordinada Norte de Registro de Supervisión" },
        },
        fnSubmit: function (form) {
            if (_EspecieForEst.fnCustomValidateForm()) {
                _EspecieForEst.fnSaveForm(_EspecieForEst.fnSetDatos());
            }
        }
    }));
    //Validación de controles que usan Select2
    _EspecieForEst.frm.find("select.select2-hidden-accessible").on("change", function (e) {
        $(this).valid();
    });
}