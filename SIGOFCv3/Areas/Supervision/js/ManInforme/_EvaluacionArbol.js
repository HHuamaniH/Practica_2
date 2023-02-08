"use strict";
var _EvaluacionArbol = {};

_EvaluacionArbol.fnSaveForm = function (data) { /*implementado desde donde se instancia*/ }

_EvaluacionArbol.fnLoadDatos = function (data) {
    if (data != null && data != "") {
        _EvaluacionArbol.frm.find("#hdfRegEstado").val(data["RegEstado"]);
        _EvaluacionArbol.frm.find("#hdfCodSecuencial").val(data["COD_SECUENCIAL"]);
        _EvaluacionArbol.frm.find("#txtBloque").val(data["BLOQUE"]);
        _EvaluacionArbol.frm.find("#txtFaja").val(data["FAJA"]);
        _EvaluacionArbol.frm.find("#txtCodigo").val(data["CODIGO"]);
        _EvaluacionArbol.frm.find("#txtDap").val(data["DAP"]);
        _EvaluacionArbol.frm.find("#txtDap1").val(data["DAP1"]);
        _EvaluacionArbol.frm.find("#txtDap2").val(data["DAP2"]);
        _EvaluacionArbol.frm.find("#ddlMetodoMedirDapId").select2("val", [data["MAE_TIP_MMEDIRDAP"]]);
        _EvaluacionArbol.frm.find("#txtAc").val(data["AC"]);
        _EvaluacionArbol.frm.find("#ddlEstadoId").select2("val", [data["COD_EESTADO"]]);
        _EvaluacionArbol.frm.find("#ddlZonaId").select2("val", [data["ZONA"]]);
        _EvaluacionArbol.frm.find("#txtCoordEste").val(data["COORDENADA_ESTE"]);
        _EvaluacionArbol.frm.find("#txtCoordNorte").val(data["COORDENADA_NORTE"]);
        _EvaluacionArbol.frm.find("#txtObservacion").val(data["OBSERVACION"]);
        _renderComboEspecie.fnInit("FORESTAL", data["COD_ESPECIES"], data["DESC_ESPECIES"]);
    } else {
        _EvaluacionArbol.frm.find("#hdfRegEstado").val("1");
        _EvaluacionArbol.frm.find("#hdfCodSecuencial").val("0");
        _renderComboEspecie.fnInit("FORESTAL", "", "");
    }
}

_EvaluacionArbol.fnSetDatos = function () {
    var data = [];
    var regEstado = _EvaluacionArbol.frm.find("#hdfRegEstado").val();
    data["RegEstado"] = regEstado == "0" ? "2" : regEstado;
    data["COD_SECUENCIAL"] = _EvaluacionArbol.frm.find("#hdfCodSecuencial").val();
    data["COD_ESPECIES"] = _renderComboEspecie.fnGetCodEspecie();
    data["DESC_ESPECIES"] = _renderComboEspecie.fnGetEspecie();
    data["BLOQUE"] = _EvaluacionArbol.frm.find("#txtBloque").val();
    data["FAJA"] = _EvaluacionArbol.frm.find("#txtFaja").val();
    data["CODIGO"] = _EvaluacionArbol.frm.find("#txtCodigo").val();
    data["DAP"] = _EvaluacionArbol.frm.find("#txtDap").val();
    data["DAP1"] = _EvaluacionArbol.frm.find("#txtDap1").val();
    data["DAP2"] = _EvaluacionArbol.frm.find("#txtDap2").val();
    data["MAE_TIP_MMEDIRDAP"] = _EvaluacionArbol.frm.find("#ddlMetodoMedirDapId").val();
    data["MMEDIR_DAP"] = data["MAE_TIP_MMEDIRDAP"] == "0000000" ? "" : _EvaluacionArbol.frm.find("#ddlMetodoMedirDapId").select2("data")[0].text;
    data["AC"] = _EvaluacionArbol.frm.find("#txtAc").val();
    data["COD_EESTADO"] = _EvaluacionArbol.frm.find("#ddlEstadoId").val();
    data["DESC_EESTADO"] = data["COD_EESTADO"] == "0000000" ? "" : _EvaluacionArbol.frm.find("#ddlEstadoId").select2("data")[0].text;
    data["ZONA"] = _EvaluacionArbol.frm.find("#ddlZonaId").val();
    data["COORDENADA_ESTE"] = _EvaluacionArbol.frm.find("#txtCoordEste").val();
    data["COORDENADA_NORTE"] = _EvaluacionArbol.frm.find("#txtCoordNorte").val();
    data["OBSERVACION"] = _EvaluacionArbol.frm.find("#txtObservacion").val();
    data["DESC_ACATEGORIA_CITE"] = "";
    data["DESC_ACATEGORIA_DS"] = "";
    return data;
}

_EvaluacionArbol.fnCustomValidateForm = function () {
    if (_renderComboEspecie.fnGetCodEspecie() == null) {
        utilSigo.toastWarning("Aviso", "Seleccione la especie a registrar"); return false;
    }
    return true;
}

_EvaluacionArbol.fnSubmitForm = function () {
    _EvaluacionArbol.frm.submit();
}

_EvaluacionArbol.fnInit = function (data) {
    _EvaluacionArbol.frm = $("#frmItemEvaluacionArbol");

    $.fn.select2.defaults.set("theme", "bootstrap4");
    _EvaluacionArbol.frm.find("#ddlMetodoMedirDapId").select2({ minimumResultsForSearch: -1 });
    _EvaluacionArbol.frm.find("#ddlEstadoId").select2();
    _EvaluacionArbol.frm.find("#ddlZonaId").select2({ minimumResultsForSearch: -1 });

    _EvaluacionArbol.fnLoadDatos(data);

    //=====-----Para el registro de datos del formulario-----=====
    //Validación personalizada
    jQuery.validator.addMethod("invalidFrmArbol", function (value, element) {
        switch ($(element).attr('id')) {
            case 'ddlEstadoId':
            case 'ddlZonaId':
                return (value == '0000000') ? false : true;
                break
        }
    });
    _EvaluacionArbol.frm.validate(utilSigo.fnValidate({
        rules: {
            txtDap: { required: true },
            txtDap1: { required: true },
            txtDap2: { required: true },
            txtAc: { required: true },
            ddlEstadoId: { invalidFrmArbol: true },
            ddlZonaId: { invalidFrmArbol: true },
            txtCoordEste: { required: true },
            txtCoordNorte: { required: true }
        },
        messages: {
            txtDap: { required: "Ingrese el DAP (cm)" },
            txtDap1: { required: "Ingrese el DAP 1 (cm)" },
            txtDap2: { required: "Ingrese el DAP 2 (cm)" },
            txtAc: { required: "Ingrese el AC (m)" },
            ddlEstadoId: { invalidFrmArbol: "Seleccione el estado de la especie" },
            ddlZonaId: { invalidFrmArbol: "Seleccione la zona UTM" },
            txtCoordEste: { required: "Ingrese la coordenada este" },
            txtCoordNorte: { required: "Ingrese la coordenada norte" }
        },
        fnSubmit: function (form) {
            if (_EvaluacionArbol.fnCustomValidateForm()) {
                _EvaluacionArbol.fnSaveForm(_EvaluacionArbol.fnSetDatos());
            }
        }
    }));
    //Validación de controles que usan Select2
    _EvaluacionArbol.frm.find("select.select2-hidden-accessible").on("change", function (e) {
        $(this).valid();
    });
}