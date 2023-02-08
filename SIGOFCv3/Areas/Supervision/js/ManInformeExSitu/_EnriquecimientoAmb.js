"use strict";
var _EnriquecimientoAmb = {};

_EnriquecimientoAmb.fnSaveForm = function (data) { /*implementado desde donde se instancia*/ }

_EnriquecimientoAmb.fnLoadDatos = function (data) {
    if (data != null && data != "") {
        _EnriquecimientoAmb.frm.find("#hdfRegEstado").val(data["RegEstado"]);
        _EnriquecimientoAmb.frm.find("#ddlTipoTaxonomicoId").select2("val", [data["COD_TDESCRIPTIVA"]]);
        _EnriquecimientoAmb.frm.find("#txtActImplemeta").val(data["ACTIVIDAD_IMPLEMENTADA"]);
        _EnriquecimientoAmb.frm.find("#txtMaterialUsa").val(data["MATERIAL_USADO"]);
        _EnriquecimientoAmb.frm.find("#txtObservacion").val(data["OBSERVACION"]);
    } else {
        _EnriquecimientoAmb.frm.find("#hdfRegEstado").val("1");
    }
}

_EnriquecimientoAmb.fnSetDatos = function () {
    var data = [];
    var regEstado = _EnriquecimientoAmb.frm.find("#hdfRegEstado").val();
    data["RegEstado"] = regEstado == "0" ? "2" : regEstado;
    data["COD_TDESCRIPTIVA"] = _EnriquecimientoAmb.frm.find("#ddlTipoTaxonomicoId").val();
    data["DESCRIPCION"] = _EnriquecimientoAmb.frm.find("#ddlTipoTaxonomicoId").val() == "0000000" ? "" : _EnriquecimientoAmb.frm.find("#ddlTipoTaxonomicoId").select2("data")[0].text;
    data["ACTIVIDAD_IMPLEMENTADA"] = _EnriquecimientoAmb.frm.find("#txtActImplemeta").val();
    data["MATERIAL_USADO"] = _EnriquecimientoAmb.frm.find("#txtMaterialUsa").val();
    data["OBSERVACION"] = _EnriquecimientoAmb.frm.find("#txtObservacion").val();
    return data;
}

_EnriquecimientoAmb.fnSubmitForm = function () {
    _EnriquecimientoAmb.frm.submit();
}

_EnriquecimientoAmb.fnInit = function (data) {
    _EnriquecimientoAmb.frm = $("#frmItemEnriquecimientoAmb");

    $.fn.select2.defaults.set("theme", "bootstrap4");
    _EnriquecimientoAmb.frm.find("#ddlTipoTaxonomicoId").select2();

    _EnriquecimientoAmb.fnLoadDatos(data);

    //=====-----Para el registro de datos del formulario-----=====
    //Validación personalizada
    jQuery.validator.addMethod("invalidFrmEnrAmb", function (value, element) {
        switch ($(element).attr('id')) {
            case 'ddlTipoTaxonomicoId':
                return (value == '0000000') ? false : true;
                break
        }
    });

    _EnriquecimientoAmb.frm.validate(utilSigo.fnValidate({
        rules: {
            ddlTipoTaxonomicoId: { invalidFrmEnrAmb: true }
        },
        messages: {
            ddlTipoTaxonomicoId: { invalidFrmEnrAmb: "Seleccione el tipo taxonómico" }
        },
        fnSubmit: function (form) {
            _EnriquecimientoAmb.fnSaveForm(_EnriquecimientoAmb.fnSetDatos());
        }
    }));
    //Validación de controles que usan Select2
    _EnriquecimientoAmb.frm.find("select.select2-hidden-accessible").on("change", function (e) {
        $(this).valid();
    });
}