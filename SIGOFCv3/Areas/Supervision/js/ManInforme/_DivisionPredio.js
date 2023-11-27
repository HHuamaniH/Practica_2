"use strict";
var _DivisionPredio = {};

_DivisionPredio.fnSaveForm = function (data) { /*implementado desde donde se instancia*/ }

_DivisionPredio.fnAgregarLinea = function () {
    let txtCoordEsteDP = $("#txtCoordEsteDP").val();
    let txtCoordNorteDP = $("#txtCoordNorteDP").val();
    let txtAltidudDP = $("#txtAltidudDP").val();    
    if (txtCoordEsteDP == "" || txtCoordEsteDP == null) {
        utilSigo.toastWarning("Aviso", "Para agregar debe ingresar la Coordenada Este."); return false;
    } else if (txtCoordNorteDP == "" || txtCoordNorteDP == null) {
        utilSigo.toastWarning("Aviso", "Para agregar debe ingresar la Coordenada Norte."); return false;
    } else if (txtAltidudDP == "" || txtAltidudDP == null) {
        utilSigo.toastWarning("Aviso", "Para agregar debe ingresar la Altitud."); return false;
    }
    if ($("#txtACoordEsteDP").val() == "") {
        $("#txtACoordEsteDP").val(txtCoordEsteDP);
        $("#txtACoordNorteDP").val(txtCoordNorteDP);
        $("#txtAAltidudDP").val(txtAltidudDP);
    } else {
        $("#txtACoordEsteDP").val($("#txtACoordEsteDP").val() + "," + txtCoordEsteDP);
        $("#txtACoordNorteDP").val($("#txtACoordNorteDP").val() + "," + txtCoordNorteDP);
        $("#txtAAltidudDP").val($("#txtAAltidudDP").val() + "," + txtAltidudDP);
    }    
    $("#txtCoordEsteDP").val(''); $("#txtCoordNorteDP").val(''); $("#txtAltidudDP").val('');
}
_DivisionPredio.fnClearLinea = function (data) {
    $("#txtACoordEsteDP").val("");
    $("#txtACoordNorteDP").val("");
    $("#txtAAltidudDP").val("");
}
_DivisionPredio.fnLoadDatos = function (data) {
    //if (data != null && data != "") {
    //    _DivisionPredio.frm.find("#txtDivisionInternaDP").val(data["DIVISION_INTERNA"]);
    //    _DivisionPredio.frm.find("#txtDivisionInternaDP").val(data["OBSERVACION"]);
    //    _DivisionPredio.frm.find("#txtAreaBosNat").val(data["AREA"]);
    //    _DivisionPredio.frm.find("#txtCoordEsteBosNat").val(data["COORDENADA_ESTE"]);
    //    _DivisionPredio.frm.find("#txtCoordNorteBosNat").val(data["COORDENADA_NORTE"]);
    //    _DivisionPredio.frm.find("#txtAltitudBosNat").val(data["ALTITUD"]);      
    //    _DivisionPredio.frm.find("#txtObservacionDP").val(data["OBSERVACION"]);        
    //} else {
    //    _DivisionPredio.frm.find("#hdfRegEstado").val("1");
    //    _DivisionPredio.frm.find("#hdfCodSecuencial").val("0");        
    //}
}

_DivisionPredio.fnSetDatos = function () {
    var data = [];
   
    data["DIVISION_INTERNA"] = _DivisionPredio.frm.find("#txtDivisionInternaDP").val();
    data["COORDENADA_ESTE"] = _DivisionPredio.frm.find("#txtACoordEsteDP").val();
    data["COORDENADA_NORTE"] = _DivisionPredio.frm.find("#txtACoordNorteDP").val(); 
    data["ALTITUD"] = _DivisionPredio.frm.find("#txtAAltidudDP").val();    
    data["OBSERVACION"] = _DivisionPredio.frm.find("#txtObservacionDP").val();
    return data;
}

_DivisionPredio.fnCustomValidateForm = function () {

    if ($("#txtDivisionInternaDP").val() == '' || $("#txtDivisionInternaDP").val() == null) {
        utilSigo.toastWarning("Aviso", "Debe ingresar División Interna."); return false;
    } else if ($("#txtACoordEsteDP").val() == '' || $("#txtACoordEsteDP").val() == null) {
        utilSigo.toastWarning("Aviso", "Debe ingresar Coordena Este."); return false;
    } else if ($("#txtACoordNorteDP").val() == '' || $("#txtACoordNorteDP").val() == null) {
        utilSigo.toastWarning("Aviso", "Debe ingresar Coordena Norte."); return false;
    } else if ($("#txtAAltidudDP").val() == '' || $("#txtAAltidudDP").val() == null) {
        utilSigo.toastWarning("Aviso", "Debe ingresar Altitud."); return false;
    }

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
    _DivisionPredio.fnLoadDatos(data);

    //=====-----Para el registro de datos del formulario-----=====
    //Validación personalizada
    jQuery.validator.addMethod("invalidFrmDivisionPredio", function (value, element) {
        switch ($(element).attr('id')) {
            //case 'ddlAreaDivisionPredioId':
            //    return (value == '0000000') ? false : true;
            //    break
        }
    });
    _DivisionPredio.frm.validate(utilSigo.fnValidate({
        rules: {
            txtDivisionInternaDP: { required: true },
            txtACoordEsteDP: { required: true },
            txtACoordNorteDP: { required: true },
            txtAAltidudDP: { required: true }
        },
        messages: {
            txtDivisionInternaDP: { required: "Ingrese la división de predio." },
            txtACoordEsteDP: { required: "Ingrese la coordenada Este" },
            txtACoordNorteDP: { required: "Ingrese la coordenada Norte" },
            txtAAltidudDP: { required: "Ingrese la Altidud" }            
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