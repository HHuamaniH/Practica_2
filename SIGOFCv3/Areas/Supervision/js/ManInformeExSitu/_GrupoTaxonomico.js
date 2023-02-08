"use strict";
var _GrupoTaxonomico = {};

_GrupoTaxonomico.fnSaveForm = function (data) { /*implementado desde donde se instancia*/ }

_GrupoTaxonomico.fnLoadDatos = function (data) {
    if (data != null && data != "") {
        _GrupoTaxonomico.frm.find("#hdfRegEstado").val(data["RegEstado"]);
        _GrupoTaxonomico.frm.find("#hdfCodSecuencial").val(data["COD_SECUENCIAL"]);
        _GrupoTaxonomico.frm.find("#ddlTipoTaxonomicoId").select2("val", [data["COD_TDESCRIPTIVA"]]);
        _GrupoTaxonomico.frm.find("#txtGrupo").val(data["GRUPOESPECIE"]);
        _GrupoTaxonomico.frm.find("#txtTipoAlimentacion").val(data["TIPO_ALIMENTACION"]);
        _GrupoTaxonomico.frm.find("#txtFrecRacion").val(data["FRECUENCIA_RACION"]);
        _GrupoTaxonomico.frm.find("#txtObservacion").val(data["OBSERVACION"]);
    } else {
        _GrupoTaxonomico.frm.find("#hdfRegEstado").val("1");
    }
}

_GrupoTaxonomico.fnSetDatos = function () {
    var data = [];
    var regEstado = _GrupoTaxonomico.frm.find("#hdfRegEstado").val();
    data["RegEstado"] = regEstado == "0" ? "2" : regEstado;
    data["COD_SECUENCIAL"] = _GrupoTaxonomico.frm.find("#hdfCodSecuencial").val();
    data["COD_TDESCRIPTIVA"] = _GrupoTaxonomico.frm.find("#ddlTipoTaxonomicoId").val();
    data["GRUPOESPECIE"] = _GrupoTaxonomico.frm.find("#txtGrupo").val();
    data["DESCRIPCION"] = _GrupoTaxonomico.frm.find("#ddlTipoTaxonomicoId").val()=="0000000"?"": _GrupoTaxonomico.frm.find("#ddlTipoTaxonomicoId").select2("data")[0].text;
    data["TIPO_ALIMENTACION"] = _GrupoTaxonomico.frm.find("#txtTipoAlimentacion").val();
    data["FRECUENCIA_RACION"] = _GrupoTaxonomico.frm.find("#txtFrecRacion").val();
    data["OBSERVACION"] = _GrupoTaxonomico.frm.find("#txtObservacion").val();
    return data;
}

_GrupoTaxonomico.fnSubmitForm = function () {
    _GrupoTaxonomico.frm.submit();
}

_GrupoTaxonomico.fnInit = function (data) {
    _GrupoTaxonomico.frm = $("#frmItemGrupoTaxonomico");

    $.fn.select2.defaults.set("theme", "bootstrap4");
    _GrupoTaxonomico.frm.find("#ddlTipoTaxonomicoId").select2();

    _GrupoTaxonomico.fnLoadDatos(data);

    //=====-----Para el registro de datos del formulario-----=====
    //Validación personalizada
    jQuery.validator.addMethod("invalidFrmTaxo", function (value, element) {
        switch ($(element).attr('id')) {
            case 'ddlTipoTaxonomicoId':
                return (value == '0000000') ? false : true;
                break;
        }
    });

    _GrupoTaxonomico.frm.validate(utilSigo.fnValidate({
        rules: {
            ddlTipoTaxonomicoId: { invalidFrmTaxo: true },
            txtTipoAlimentacion: { required: true },
            txtFrecRacion: { required: true }
        },
        messages: {
            ddlTipoTaxonomicoId: { invalidFrmTaxo: "Seleccione el tipo taxonómico" },
            txtTipoAlimentacion: { required: "Ingrese el tipo de alimentación" },
            txtFrecRacion: { required: "Ingrese la frecuencia de la ración" }
        },
        fnSubmit: function (form) {
            _GrupoTaxonomico.fnSaveForm(_GrupoTaxonomico.fnSetDatos());
        }
    }));
    //Validación de controles que usan Select2
    _GrupoTaxonomico.frm.find("select.select2-hidden-accessible").on("change", function (e) {
        $(this).valid();
    });
}