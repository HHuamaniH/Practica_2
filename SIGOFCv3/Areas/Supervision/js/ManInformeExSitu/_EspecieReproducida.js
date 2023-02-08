"use strict";
var _EspecieReproducida = {};

_EspecieReproducida.fnSaveForm = function (data) { /*implementado desde donde se instancia*/ }

_EspecieReproducida.fnLoadDatos = function (data) {
    if (data != null && data != "") {
        _EspecieReproducida.frm.find("#hdfRegEstado").val(data["RegEstado"]);
        _EspecieReproducida.frm.find("#ddlEspecieOrigenId").select2("val", [data["COD_EORIGEN"]]);
        _EspecieReproducida.frm.find("#txtNumCriaAnio").val(data["NUM_CRIAS_ANO"]);
        _EspecieReproducida.frm.find("#txtCriaNumViable").val(data["NUM_CRIAS_VIABLES"]);
        _EspecieReproducida.frm.find("#txtNumCriaMuerta").val(data["NUM_CRIAS_MUERTAS"]);
        _EspecieReproducida.frm.find("#ddlFrecReproduccionId").select2("val", [data["FRECUENCIA_COD_TDESCRIPTIVA"]]);
        _EspecieReproducida.frm.find("#txtEpocaReprod").val(data["REPRODUCCION_EPOCA"]);
        _EspecieReproducida.frm.find("#txtObservacion").val(data["OBSERVACION"]);
        _renderComboEspecie.fnInit("FAUNA", data["COD_ESPECIES"], data["DESCRIPCION"]);
    } else {
        _EspecieReproducida.frm.find("#hdfRegEstado").val("1");
        _renderComboEspecie.fnInit("FAUNA", "", "");
    }
}

_EspecieReproducida.fnSetDatos = function () {
    var data = [];
    var regEstado = _EspecieReproducida.frm.find("#hdfRegEstado").val();
    data["RegEstado"] = regEstado == "0" ? "2" : regEstado;
    data["COD_EORIGEN"] = _EspecieReproducida.frm.find("#ddlEspecieOrigenId").val();
    data["DESC_EORIGEN"] = _EspecieReproducida.frm.find("#ddlEspecieOrigenId").val() == "0000000" ? "" : _EspecieReproducida.frm.find("#ddlEspecieOrigenId").select2("data")[0].text;
    data["COD_ESPECIES"] = _renderComboEspecie.fnGetCodEspecie();
    data["DESCRIPCION"] = _renderComboEspecie.fnGetEspecie();
    data["NUM_CRIAS_ANO"] = _EspecieReproducida.frm.find("#txtNumCriaAnio").val();
    data["NUM_CRIAS_VIABLES"] = _EspecieReproducida.frm.find("#txtCriaNumViable").val();
    data["NUM_CRIAS_MUERTAS"] = _EspecieReproducida.frm.find("#txtNumCriaMuerta").val();
    data["FRECUENCIA_COD_TDESCRIPTIVA"] = _EspecieReproducida.frm.find("#ddlFrecReproduccionId").val();
    data["FRECUENCIA_DESCRIPCION"] = _EspecieReproducida.frm.find("#ddlFrecReproduccionId").val() == "0000000" ? "" : _EspecieReproducida.frm.find("#ddlFrecReproduccionId").select2("data")[0].text;
    data["REPRODUCCION_EPOCA"] = _EspecieReproducida.frm.find("#txtEpocaReprod").val();
    data["OBSERVACION"] = _EspecieReproducida.frm.find("#txtObservacion").val();
    return data;
}

_EspecieReproducida.fnCustomValidateForm = function () {
    if (_renderComboEspecie.fnGetCodEspecie() == null) {
        utilSigo.toastWarning("Aviso", "Seleccione la especie a registrar"); return false;
    }
    return true;
}

_EspecieReproducida.fnSubmitForm = function () {
    _EspecieReproducida.frm.submit();
}

_EspecieReproducida.fnInit = function (data) {
    _EspecieReproducida.frm = $("#frmItemEspecieReproducida");

    $.fn.select2.defaults.set("theme", "bootstrap4");
    _EspecieReproducida.frm.find("#ddlEspecieOrigenId").select2({ minimumResultsForSearch: -1 });
    _EspecieReproducida.frm.find("#ddlFrecReproduccionId").select2({ minimumResultsForSearch: -1 });

    _EspecieReproducida.fnLoadDatos(data);

    //=====-----Para el registro de datos del formulario-----=====
    //Validación personalizada
    jQuery.validator.addMethod("invalidFrmReprod", function (value, element) {
        switch ($(element).attr('id')) {
            case 'ddlEspecieOrigenId':
            case 'ddlFrecReproduccionId':
                return (value == '0000000') ? false : true;
                break
        }
    });

    _EspecieReproducida.frm.validate(utilSigo.fnValidate({
        rules: {
            ddlEspecieOrigenId: { invalidFrmReprod: true },
            txtNumCriaAnio: { required: true },
        //    txtCriaNumViable: { required: true },
        //    txtNumCriaMuerta: { required: true },
         //   ddlFrecReproduccionId: { invalidFrmReprod: true }
        },
        messages: {
            ddlEspecieOrigenId: { invalidFrmReprod: "Seleccione el origen" },
            txtNumCriaAnio: { required: "Ingrese el número de crías por año" },
        //    txtCriaNumViable: { required: "Ingrese el número de crías viables" },
        //    txtNumCriaMuerta: { required: "Ingrese el número de crías muertas" },
       //     ddlFrecReproduccionId: { invalidFrmReprod: "Seleccione la frecuencia de reproducción" }
        },
        fnSubmit: function (form) {
            if (_EspecieReproducida.fnCustomValidateForm()) {
                _EspecieReproducida.fnSaveForm(_EspecieReproducida.fnSetDatos());
            }
        }
    }));
    //Validación de controles que usan Select2
    _EspecieReproducida.frm.find("select.select2-hidden-accessible").on("change", function (e) {
        $(this).valid();
    });
}