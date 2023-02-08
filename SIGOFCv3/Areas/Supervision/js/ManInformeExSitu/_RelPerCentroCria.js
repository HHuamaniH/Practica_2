"use strict";
var _RelPerCentroCria = {};

_RelPerCentroCria.fnSaveForm = function (data) { /*implementado desde donde se instancia*/ }

_RelPerCentroCria.fnLoadDatos = function (data) {
    
    if (data != null && data != "") {
        _RelPerCentroCria.frm.find("#hdfRegEstado").val(data["RegEstado"]);
        _RelPerCentroCria.frm.find("#hdfCodSecuencial").val(data["COD_SECUENCIAL"]);
        _RelPerCentroCria.frm.find("#ddlTipoTaxonomicoId").select2("val", [data["COD_TDESCRIPTIVA"]]);
        _RelPerCentroCria.frm.find("#txtGrupo").val(data["GRUPOESPECIE"]);
        _RelPerCentroCria.frm.find("#txtTipoAlimentacion").val(data["TIPO_ALIMENTACION"]);
        _RelPerCentroCria.frm.find("#txtFrecRacion").val(data["FRECUENCIA_RACION"]);
        _RelPerCentroCria.frm.find("#txtObservacion").val(data["OBSERVACION"]);
    } else {
        _RelPerCentroCria.frm.find("#hdfRegEstado").val("1");
    }
}

_RelPerCentroCria.fnSetDatos = function () {
    var data = [];
    var regEstado = _RelPerCentroCria.frm.find("#hdfRegEstado").val();
    data["RegEstado"] = regEstado == "0" ? "2" : regEstado;
    data["COD_SECUENCIAL"] = _RelPerCentroCria.frm.find("#hdfCodSecuencial").val();   
    data["NOMBRES"] = _RelPerCentroCria.frm.find("#txtNombre").val();
    data["CARGO"] = _RelPerCentroCria.frm.find("#txtCargo").val();
    return data;
}

_RelPerCentroCria.fnSubmitForm = function () {
    _RelPerCentroCria.frm.submit();
}

_RelPerCentroCria.fnInit = function (data) {
    _RelPerCentroCria.frm = $("#frmItemRelPerCentroCria");

    $.fn.select2.defaults.set("theme", "bootstrap4");    

    _RelPerCentroCria.fnLoadDatos(data);

    //=====-----Para el registro de datos del formulario-----=====
    //Validación personalizada
    jQuery.validator.addMethod("invalidFrmTaxo", function (value, element) {
        switch ($(element).attr('id')) {
            case 'ddlTipoTaxonomicoId':
                return (value == '0000000') ? false : true;
                break;
        }
    });

    _RelPerCentroCria.frm.validate(utilSigo.fnValidate({
        rules: {            
            txtNombre: { required: true },
            txtCargo: { required: true }
        },
        messages: {            
            txtNombre: { required: "Ingrese el Nombre" },
            txtCargo: { required: "Ingrese el Cargo" }
        },
        fnSubmit: function (form) {
            _RelPerCentroCria.fnSaveForm(_RelPerCentroCria.fnSetDatos());
        }
    }));
    //Validación de controles que usan Select2
    _RelPerCentroCria.frm.find("select.select2-hidden-accessible").on("change", function (e) {
        $(this).valid();
    });
}