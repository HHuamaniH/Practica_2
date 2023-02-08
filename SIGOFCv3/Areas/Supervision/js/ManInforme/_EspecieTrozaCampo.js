"use strict";
var _EspecieTrozaCampo = {};

_EspecieTrozaCampo.fnSaveForm = function (data) { /*implementado desde donde se instancia*/ }

_EspecieTrozaCampo.fnLoadDatos = function (data) {
    if (data != null && data != "") {
        _EspecieTrozaCampo.frm.find("#hdfRegEstado").val(data["RegEstado"]);
        _EspecieTrozaCampo.frm.find("#hdfCodSecuencial").val(data["COD_SECUENCIAL"]);
        _EspecieTrozaCampo.frm.find("#hdfCodTHabilitante").val(data["COD_THABILITANTE"]);
        _EspecieTrozaCampo.frm.find("#txtCodigo").val(data["CODIGO"]);
        _EspecieTrozaCampo.frm.find("#ddlZonaId").select2("val", [data["ZONA"]]);
        _EspecieTrozaCampo.frm.find("#txtCEste").val(data["COORDENADA_ESTE"]);
        _EspecieTrozaCampo.frm.find("#txtCNorte").val(data["COORDENADA_NORTE"]);
        _EspecieTrozaCampo.frm.find("#txtDap1").val(data["DAP1"]);
        _EspecieTrozaCampo.frm.find("#txtDap2").val(data["DAP2"]);
        _EspecieTrozaCampo.frm.find("#txtLc").val(data["LC"]);
        _EspecieTrozaCampo.frm.find("#txtObservacion").val(data["OBSERVACION"]);
        _renderComboEspecie.fnInit("FORESTAL", data["COD_ESPECIES"], data["ESPECIES"]);
    } else {
        _EspecieTrozaCampo.frm.find("#hdfRegEstado").val("1");
        _EspecieTrozaCampo.frm.find("#hdfCodSecuencial").val("0");
        _renderComboEspecie.fnInit("FORESTAL", "", "");
    }
}

_EspecieTrozaCampo.fnSetDatos = function () {
    var data = [];
    var regEstado = _EspecieTrozaCampo.frm.find("#hdfRegEstado").val();
    data["RegEstado"] = regEstado == "0" ? "2" : regEstado;
    data["COD_INFORME"] = _EspecieTrozaCampo.frm.find("#hdfCodInforme").val();
    data["NUM_POA"] = _EspecieTrozaCampo.frm.find("#hdfNumPoa").val();
    data["COD_SECUENCIAL"] = _EspecieTrozaCampo.frm.find("#hdfCodSecuencial").val();
    data["COD_THABILITANTE"]=_EspecieTrozaCampo.frm.find("#hdfCodTHabilitante").val();
    data["CODIGO"] = _EspecieTrozaCampo.frm.find("#txtCodigo").val();
    data["COD_ESPECIES"] = _renderComboEspecie.fnGetCodEspecie();
    data["ESPECIES"] = _renderComboEspecie.fnGetEspecie();
    data["ZONA"] = _EspecieTrozaCampo.frm.find("#ddlZonaId").val();
    data["COORDENADA_ESTE"] = _EspecieTrozaCampo.frm.find("#txtCEste").val();
    data["COORDENADA_NORTE"] = _EspecieTrozaCampo.frm.find("#txtCNorte").val();
    data["DAP1"] = _EspecieTrozaCampo.frm.find("#txtDap1").val();
    data["DAP2"] = _EspecieTrozaCampo.frm.find("#txtDap2").val();
    data["LC"] = _EspecieTrozaCampo.frm.find("#txtLc").val();
    data["OBSERVACION"] = _EspecieTrozaCampo.frm.find("#txtObservacion").val();
    return data;
}

_EspecieTrozaCampo.fnCustomValidateForm = function () {
    if (_renderComboEspecie.fnGetCodEspecie() == null) {
        utilSigo.toastWarning("Aviso", "Seleccione la especie a registrar"); return false;
    }
    return true;
}

_EspecieTrozaCampo.fnSubmitForm = function () {
    _EspecieTrozaCampo.frm.submit();
}

_EspecieTrozaCampo.fnInit = function (data) {
    _EspecieTrozaCampo.frm = $("#frmItemTrozaCampo");

    $.fn.select2.defaults.set("theme", "bootstrap4");
    _EspecieTrozaCampo.frm.find("#ddlZonaId").select2({ minimumResultsForSearch: -1 });

    _EspecieTrozaCampo.fnLoadDatos(data);

    //=====-----Para el registro de datos del formulario-----=====
    //Validación personalizada
    jQuery.validator.addMethod("invalidFrmTroza", function (value, element) {
        switch ($(element).attr('id')) {
            case 'ddlZonaId':
                return (value == '0000000') ? false : true;
                break
        }
    });
    _EspecieTrozaCampo.frm.validate(utilSigo.fnValidate({
        rules: {
            txtCodigo: { required: true },
            ddlZonaId: { invalidFrmTroza: true },
            txtCEste: { required: true },
            txtCNorte: { required: true },
            txtDap1: { required: true },
            txtDap2: { required: true },
            txtLc: { required: true }
        },
        messages: {
            txtCodigo: { required: "Ingrese el código de la troza" },
            ddlZonaId: { invalidFrmTroza: "Seleccione la zona UTM" },
            txtCEste: { required: "Ingrese la coordenada este" },
            txtCNorte: { required: "Ingrese la coordenada norte" },
            txtDap1: { required: "Ingrese el DAP 1 (cm)" },
            txtDap2: { required: "Ingrese el DAP 2 (cm)" },
            txtLc: { required: "Ingrese el LC (m)" }
        },
        fnSubmit: function (form) {
            if (_EspecieTrozaCampo.fnCustomValidateForm()) {
                var oEspecie = utilSigo.fnConvertArrayToObject(_EspecieTrozaCampo.fnSetDatos());
                var url = urlLocalSigo + "Supervision/ManInforme/GrabarEspecieTrozaCampo";
                var option = { url: url, datos: JSON.stringify(oEspecie), type: 'POST' };
                utilSigo.fnAjax(option, function (data) {
                    if (data.success) {
                        oEspecie["RegEstado"] = 0;
                        _EspecieTrozaCampo.fnSaveForm(oEspecie);
                    }
                    else {
                        utilSigo.toastWarning("Aviso", data.msj);
                    }
                });
            }
        }
    }));
    //Validación de controles que usan Select2
    _EspecieTrozaCampo.frm.find("select.select2-hidden-accessible").on("change", function (e) {
        $(this).valid();
    });
}