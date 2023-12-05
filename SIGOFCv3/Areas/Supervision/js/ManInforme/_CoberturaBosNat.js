"use strict";
var _CoberturaBosNat = {};

_CoberturaBosNat.fnSaveForm = function (data) { /*implementado desde donde se instancia*/ }

_CoberturaBosNat.fnLoadDatos = function (data) {
    if (data != null && data != "") {
        _CoberturaBosNat.frm.find("#hdfRegEstado").val(data["RegEstado"]);
        _CoberturaBosNat.frm.find("#hdfCodSecuencial").val(data["COD_SECUENCIAL"]);
        _CoberturaBosNat.frm.find("#ddlAreaCoberturaBosNatId").val(data["AREA_COBERTURA"]);
        _CoberturaBosNat.frm.find("#txtAreaBosNat").val(data["AREA"]);
        _CoberturaBosNat.frm.find("#txtCoordEsteBosNat").val(data["COORDENADA_ESTE"]);
        _CoberturaBosNat.frm.find("#txtCoordNorteBosNat").val(data["COORDENADA_NORTE"]);
        _CoberturaBosNat.frm.find("#txtAltitudBosNat").val(data["ALTITUD"]);      
        _CoberturaBosNat.frm.find("#txtObservacionBosNat").val(data["OBSERVACION"]);        
    } else {
        _CoberturaBosNat.frm.find("#hdfRegEstado").val("1");
        _CoberturaBosNat.frm.find("#hdfCodSecuencial").val("0");        
    }
}

_CoberturaBosNat.fnSetDatos = function () {
    var data = [];
    var regEstado = _CoberturaBosNat.frm.find("#hdfRegEstado").val();
    data["RegEstado"] = regEstado == "0" ? "2" : regEstado;
    data["COD_SECUENCIAL"] = _CoberturaBosNat.frm.find("#hdfCodSecuencial").val();
    data["AREA_COBERTURA"] = _CoberturaBosNat.frm.find("#ddlAreaCoberturaBosNatId").val();
    data["AREA"] = _CoberturaBosNat.frm.find("#txtAreaBosNat").val();
    data["COORDENADA_ESTE"] = _CoberturaBosNat.frm.find("#txtCoordEsteBosNat").val(); 
    data["COORDENADA_NORTE"] = _CoberturaBosNat.frm.find("#txtCoordNorteBosNat").val();
    data["ALTITUD"] = _CoberturaBosNat.frm.find("#txtAltitudBosNat").val();
    data["OBSERVACION"] = _CoberturaBosNat.frm.find("#txtObservacionBosNat").val();
    return data;
}

_CoberturaBosNat.fnCustomValidateForm = function () {

    return true;
}

_CoberturaBosNat.fnSubmitForm = function () {
    //const fechaActual = new Date();

    //let fecha = ($("#txtFecha").val()).split('/');

    //if (fecha.length == 3) {
    //    let fechaStr = fecha[2] + "-" + fecha[1] + "-" + fecha[0]
    //    const fechaIngresada = new Date(fechaStr);
    //    if (fechaActual > fechaIngresada) {
    //        _CoberturaBosNat.frm.submit();
    //    } else {
    //        utilSigo.toastWarning("Aviso", "La Fecha seleccionada no debe ser mayor a la actual."); return false;
    //    }
    //} else {
    //    utilSigo.toastWarning("Aviso", "La Fecha seleccionada no es válido."); return false;
    //}
    _CoberturaBosNat.frm.submit();

}

_CoberturaBosNat.fnInit = function (data) {
    _CoberturaBosNat.frm = $("#frmItemCoberturaBosNat");

    $.fn.select2.defaults.set("theme", "bootstrap4");
    //_CoberturaBosNat.frm.find("#ddlTipoAvistRegistroId").select2({ minimumResultsForSearch: -1 });
    //_CoberturaBosNat.frm.find("#ddlTipoAvistEstratoId").select2({ minimumResultsForSearch: -1 });
    //_CoberturaBosNat.frm.find("#ddlZonaId").select2({ minimumResultsForSearch: -1 });
    //utilSigo.fnFormatDate(_CoberturaBosNat.frm.find("#txtFecha"));

    _CoberturaBosNat.fnLoadDatos(data);

    //=====-----Para el registro de datos del formulario-----=====
    //Validación personalizada
    jQuery.validator.addMethod("invalidFrmCoberturaBosNat", function (value, element) {
        switch ($(element).attr('id')) {
            case 'ddlAreaCoberturaBosNatId':
                return (value == '0000000') ? false : true;
                break
        }
    });
    _CoberturaBosNat.frm.validate(utilSigo.fnValidate({
        rules: {
          //  ddlAreaCoberturaBosNatId: { ddlAreaCoberturaBosNatId: true },
            txtAreaBosNat: { required: true },
            txtCoordEsteBosNat: { required: true },
            txtCoordNorteBosNat: { required: true },
            txtAltitudBosNat: { required: true }
        },
        messages: {
         //   ddlAreaCoberturaBosNatId: { ddlAreaCoberturaBosNatId: "Seleccione área de Cobertura de Bosques Naturales" },
            txtAreaBosNat: { required: "Ingrese el área (has) de Cobertura de Bosques Naturales" },
            txtCoordEsteBosNat: { required: "Ingrese la coordenada Norte de Cobertura de Bosques Naturales" },
            txtCoordNorteBosNat: { required: "Ingrese la coordenada Este de Cobertura de Bosques Naturales" },
            txtAltitudBosNat: { required: "Ingrese la altitud de Cobertura de Bosques Naturales" }
        },
        fnSubmit: function (form) {
            if (_CoberturaBosNat.fnCustomValidateForm()) {
                _CoberturaBosNat.fnSaveForm(_CoberturaBosNat.fnSetDatos());
            }
        }
    }));
    //Validación de controles que usan Select2
    _CoberturaBosNat.frm.find("select.select2-hidden-accessible").on("change", function (e) {
        $(this).valid();
    });
}