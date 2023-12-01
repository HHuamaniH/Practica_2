"use strict";
var _DivisionPredio = {};

_DivisionPredio.fnSaveForm = function (data) { /*implementado desde donde se instancia*/ }

_DivisionPredio.fnLoadDatos = function (data) {
    if (data != null && data != "") {
        _DivisionPredio.frm.find("#hdfRegEstado").val(data["RegEstado"]);
        _DivisionPredio.frm.find("#hdfCodSecuencial").val(data["COD_SECUENCIAL"]);
        _DivisionPredio.frm.find("#txtDivisionInternaDP").val(data["DIVISION_INTERNA"]);        
        _DivisionPredio.frm.find("#txtCoordEsteDP").val(data["COORDENADA_ESTE"]);
        _DivisionPredio.frm.find("#txtCoordNorteDP").val(data["COORDENADA_NORTE"]);
        _DivisionPredio.frm.find("#txtAltidudDP").val(data["ALTITUD"]);
        _DivisionPredio.frm.find("#txtObservacionDP").val(data["OBSERVACION"]);
    } else {
        _DivisionPredio.frm.find("#hdfRegEstado").val("1");
        _DivisionPredio.frm.find("#hdfCodSecuencial").val("0");
    }
}

_DivisionPredio.fnSetDatos = function () {
    var data = [];
    var regEstado = _DivisionPredio.frm.find("#hdfRegEstado").val();
    data["RegEstado"] = regEstado == "0" ? "2" : regEstado;
    data["COD_SECUENCIAL"] = _DivisionPredio.frm.find("#hdfCodSecuencial").val();
    data["DIVISION_INTERNA"] = _DivisionPredio.frm.find("#txtDivisionInternaDP").val();    
    data["COORDENADA_ESTE"] = _DivisionPredio.frm.find("#txtCoordEsteDP").val();
    data["COORDENADA_NORTE"] = _DivisionPredio.frm.find("#txtCoordNorteDP").val();
    data["ALTITUD"] = _DivisionPredio.frm.find("#txtAltidudDP").val();
    data["OBSERVACION"] = _DivisionPredio.frm.find("#txtObservacionDP").val();
    return data;
}

_DivisionPredio.fnCustomValidateForm = function () {

    return true;
}

_DivisionPredio.fnSubmitForm = function () {
    //const fechaActual = new Date();

    //let fecha = ($("#txtFecha").val()).split('/');

    //if (fecha.length == 3) {
    //    let fechaStr = fecha[2] + "-" + fecha[1] + "-" + fecha[0]
    //    const fechaIngresada = new Date(fechaStr);
    //    if (fechaActual > fechaIngresada) {
    //        _DivisionPredio.frm.submit();
    //    } else {
    //        utilSigo.toastWarning("Aviso", "La Fecha seleccionada no debe ser mayor a la actual."); return false;
    //    }
    //} else {
    //    utilSigo.toastWarning("Aviso", "La Fecha seleccionada no es válido."); return false;
    //}
    _DivisionPredio.frm.submit();

}

_DivisionPredio.fnInit = function (data) {
    _DivisionPredio.frm = $("#frmItemDivisionPredio");

    $.fn.select2.defaults.set("theme", "bootstrap4");
    //_DivisionPredio.frm.find("#ddlTipoAvistRegistroId").select2({ minimumResultsForSearch: -1 });
    //_DivisionPredio.frm.find("#ddlTipoAvistEstratoId").select2({ minimumResultsForSearch: -1 });
    //_DivisionPredio.frm.find("#ddlZonaId").select2({ minimumResultsForSearch: -1 });
    //utilSigo.fnFormatDate(_DivisionPredio.frm.find("#txtFecha"));

    _DivisionPredio.fnLoadDatos(data);

    //=====-----Para el registro de datos del formulario-----=====
    //Validación personalizada
    jQuery.validator.addMethod("invalidFrmDivisionPredio", function (value, element) {
        switch ($(element).attr('id')) {
            case 'ddlAreaDivisionPredioId':
                return (value == '0000000') ? false : true;
                break
        }
    });
    _DivisionPredio.frm.validate(utilSigo.fnValidate({
        rules: {
            //  ddlAreaDivisionPredioId: { ddlAreaDivisionPredioId: true },
            txtDivisionInternaDP: { required: true },
            txtCoordEsteDP: { required: true },
            txtCoordNorteDP: { required: true },
            txtAltidudDP: { required: true }
        },
        messages: {
            //   ddlAreaDivisionPredioId: { ddlAreaDivisionPredioId: "Seleccione área de Cobertura de Bosques Naturales" },
            txtDivisionInternaDP: { required: "Ingrese la División Interna" },
            txtCoordEsteDP: { required: "Ingrese la coordenada Este" },
            txtCoordNorteDP: { required: "Ingrese la coordenada Norte" },
            txtAltidudDP: { required: "Ingrese la altitud" }
        },
        fnSubmit: function (form) {
            if (_DivisionPredio.fnCustomValidateForm()) {
                _DivisionPredio.fnSaveForm(_DivisionPredio.fnSetDatos());
            }
        }
    }));
    //Validación de controles que usan Select2
    _DivisionPredio.frm.find("select.select2-hidden-accessible").on("change", function (e) {
        $(this).valid();
    });
}