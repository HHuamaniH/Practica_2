"use strict";
var _EspecieSemillero = {};

_EspecieSemillero.fnSaveForm = function (data) { /*implementado desde donde se instancia*/ }

_EspecieSemillero.fnLoadDatos = function (data) {
    if (data != null && data != "") {
        _EspecieSemillero.frm.find("#hdfRegEstado").val(data["RegEstado"]);
        _EspecieSemillero.frm.find("#hdfCodSecuencial").val(data["COD_SECUENCIAL"]);
        _EspecieSemillero.frm.find("#hdfCodTHabilitante").val(data["COD_THABILITANTE"]);
        _EspecieSemillero.frm.find("#hdfNumPoa").val(data["NUM_POA"]);
        _EspecieSemillero.frm.find("#hdfNombrePoa").val(data["POA"]);
        _EspecieSemillero.frm.find("#hdfCodEspecie").val(data["COD_ESPECIES"]);
        _EspecieSemillero.frm.find("#txtEspecie").val(data["DESC_ESPECIES"]);
        _EspecieSemillero.frm.find("#ddlCoincideEspecieId").select2("val", [data["COINCIDE_ESPECIES"]]);
        _EspecieSemillero.frm.find("#txtBloque").val(data["BLOQUE"]);
        _EspecieSemillero.frm.find("#txtBloqueCampo").val(data["BLOQUE_CAMPO"]);
        _EspecieSemillero.frm.find("#txtFaja").val(data["FAJA"]);
        _EspecieSemillero.frm.find("#txtFajaCampo").val(data["FAJA_CAMPO"]);
        _EspecieSemillero.frm.find("#txtCodigo").val(data["CODIGO"]);
        _EspecieSemillero.frm.find("#txtCodigoCampo").val(data["CODIGO_CAMPO"]);
        _EspecieSemillero.frm.find("#txtDap").val(data["DAP"]);
        _EspecieSemillero.frm.find("#txtDapCampo").val(data["DAP_CAMPO"]);
        _EspecieSemillero.frm.find("#txtDapCampo1").val(data["DAP_CAMPO1"]);
        _EspecieSemillero.frm.find("#txtDapCampo2").val(data["DAP_CAMPO2"]);
        _EspecieSemillero.frm.find("#ddlMetodoMedirDapId").select2("val", [data["MAE_TIP_MMEDIRDAP"]]);
        _EspecieSemillero.frm.find("#txtAc").val(data["AC"]);
        _EspecieSemillero.frm.find("#txtAcCampo").val(data["AC_CAMPO"]);
        _EspecieSemillero.frm.find("#txtZona").val(data["ZONA"]);
        _EspecieSemillero.frm.find("#ddlZonaCampoId").select2("val", [data["ZONA_CAMPO"] == "000" ? "0000000" : data["ZONA_CAMPO"]]);
        _EspecieSemillero.frm.find("#txtCEste").val(data["COORDENADA_ESTE"]);
        _EspecieSemillero.frm.find("#txtCEsteCampo").val(data["COORDENADA_ESTE_CAMPO"]);
        _EspecieSemillero.frm.find("#txtCNorte").val(data["COORDENADA_NORTE"]);
        _EspecieSemillero.frm.find("#txtCNorteCampo").val(data["COORDENADA_NORTE_CAMPO"]);
        _EspecieSemillero.frm.find("#txtEstado").val(data["DESC_EESTADO"]);
        _EspecieSemillero.frm.find("#ddlEstadoCampoId").select2("val", [data["COD_EESTADO"]]);
        _EspecieSemillero.frm.find("#ddlFenologiaId").select2("val", [data["COD_EFENOLOGICO"]]);
        _EspecieSemillero.frm.find("#ddlCFusteId").select2("val", [data["COD_CFUSTE"]]);
        _EspecieSemillero.frm.find("#ddlFCopaId").select2("val", [data["COD_FCOPA"]]);
        _EspecieSemillero.frm.find("#ddlPCopaId").select2("val", [data["COD_PCOPA"]]);
        _EspecieSemillero.frm.find("#ddlEstadoFitoId").select2("val", [data["COD_ESANITARIO"]]);
        _EspecieSemillero.frm.find("#ddlGradoInfestId").select2("val", [data["COD_ILIANAS"]]);
        _EspecieSemillero.frm.find("#txtCantSobreEst").val(data["CANT_SOBRE_ESTIMA_DIAMETRO"]);
        _EspecieSemillero.frm.find("#txtPorcSobreEst").val(data["PORC_SOBRE_ESTIMA_DIAMETRO"]);
        _EspecieSemillero.frm.find("#txtCantSubEst").val(data["CANT_SUB_ESTIMA_DIAMETRO"]);
        _EspecieSemillero.frm.find("#txtPorcSubEst").val(data["PORC_SUB_ESTIMA_DIAMETRO"]);
        _EspecieSemillero.frm.find("#txtObservacion").val(data["OBSERVACION"]);
        _EspecieSemillero.frm.find("#txtParcelaCenso").val(data["PCA"]);
        _EspecieSemillero.frm.find("#txtParcelaCPOA").val(data["PCA_POA"]);
        _renderComboEspecie.fnInit("FORESTAL", data["COD_ESPECIES_CAMPO"], data["DESC_ESPECIES_CAMPO"]);
    }
}

_EspecieSemillero.fnSetDatos = function () {
    var data = [];
    var regEstado = _EspecieSemillero.frm.find("#hdfRegEstado").val();
    data["RegEstado"] = regEstado == "0" ? "2" : regEstado;
    data["COD_INFORME"] = _EspecieSemillero.frm.find("#hdfCodInforme").val();
    data["COD_SECUENCIAL"] = _EspecieSemillero.frm.find("#hdfCodSecuencial").val();
    data["COD_THABILITANTE"] = _EspecieSemillero.frm.find("#hdfCodTHabilitante").val();
    data["NUM_POA"] = _EspecieSemillero.frm.find("#hdfNumPoa").val();
    data["POA"] = _EspecieSemillero.frm.find("#hdfNombrePoa").val();;
    data["COD_ESPECIES_CAMPO"] = _renderComboEspecie.fnGetCodEspecie();
    data["DESC_ESPECIES_CAMPO"] = _renderComboEspecie.fnGetEspecie();
    data["COD_ESPECIES"] = _EspecieSemillero.frm.find("#hdfCodEspecie").val();
    data["DESC_ESPECIES"] = _EspecieSemillero.frm.find("#txtEspecie").val();
    data["COINCIDE_ESPECIES"] = _EspecieSemillero.frm.find("#ddlCoincideEspecieId").val();
    data["DESC_COINCIDE_ESPECIES"] = _EspecieSemillero.frm.find("#ddlCoincideEspecieId").val() == "-" ? "" : _EspecieSemillero.frm.find("#ddlCoincideEspecieId").select2("data")[0].text;
    data["BLOQUE"] = _EspecieSemillero.frm.find("#txtBloque").val();
    data["BLOQUE_CAMPO"] = _EspecieSemillero.frm.find("#txtBloqueCampo").val();
    data["FAJA"] = _EspecieSemillero.frm.find("#txtFaja").val();
    data["FAJA_CAMPO"] = _EspecieSemillero.frm.find("#txtFajaCampo").val();
    data["CODIGO"] = _EspecieSemillero.frm.find("#txtCodigo").val();
    data["CODIGO_CAMPO"] = _EspecieSemillero.frm.find("#txtCodigoCampo").val();
    data["DAP"] = _EspecieSemillero.frm.find("#txtDap").val();
    data["DAP_CAMPO"] = _EspecieSemillero.frm.find("#txtDapCampo").val();
    data["DAP_CAMPO1"] = _EspecieSemillero.frm.find("#txtDapCampo1").val();
    data["DAP_CAMPO2"] = _EspecieSemillero.frm.find("#txtDapCampo2").val();
    data["MAE_TIP_MMEDIRDAP"] = _EspecieSemillero.frm.find("#ddlMetodoMedirDapId").val();
    data["MMEDIR_DAP"] = _EspecieSemillero.frm.find("#ddlMetodoMedirDapId").val() == "0000000" ? "" : _EspecieSemillero.frm.find("#ddlMetodoMedirDapId").select2("data")[0].text;
    data["AC"] = _EspecieSemillero.frm.find("#txtAc").val();
    data["AC_CAMPO"] = _EspecieSemillero.frm.find("#txtAcCampo").val();
    data["ZONA"] = _EspecieSemillero.frm.find("#txtZona").val();
    data["ZONA_CAMPO"] = _EspecieSemillero.frm.find("#ddlZonaCampoId").val();
    data["COORDENADA_ESTE"] = _EspecieSemillero.frm.find("#txtCEste").val();
    data["COORDENADA_ESTE_CAMPO"] = _EspecieSemillero.frm.find("#txtCEsteCampo").val();
    data["COORDENADA_NORTE"] = _EspecieSemillero.frm.find("#txtCNorte").val();
    data["COORDENADA_NORTE_CAMPO"] = _EspecieSemillero.frm.find("#txtCNorteCampo").val();
    data["DESC_EESTADO"] = _EspecieSemillero.frm.find("#txtEstado").val();
    data["COD_EESTADO"] = _EspecieSemillero.frm.find("#ddlEstadoCampoId").val();
    data["DESC_EESTADO_CAMPO"] = _EspecieSemillero.frm.find("#ddlEstadoCampoId").val() == "0000000" ? "" : _EspecieSemillero.frm.find("#ddlEstadoCampoId").select2("data")[0].text;
    data["COD_EFENOLOGICO"] = _EspecieSemillero.frm.find("#ddlFenologiaId").val();
    data["DESC_EFENOLOGICO"] = _EspecieSemillero.frm.find("#ddlFenologiaId").select2("data")[0].text;
    data["COD_CFUSTE"] = _EspecieSemillero.frm.find("#ddlCFusteId").val();
    data["DESC_CFUSTE"] = _EspecieSemillero.frm.find("#ddlCFusteId").select2("data")[0].text;
    data["COD_FCOPA"] = _EspecieSemillero.frm.find("#ddlFCopaId").val();
    data["DESC_FCOPA"] = _EspecieSemillero.frm.find("#ddlFCopaId").select2("data")[0].text;
    data["COD_PCOPA"] = _EspecieSemillero.frm.find("#ddlPCopaId").val();
    data["DESC_PCOPA"] = _EspecieSemillero.frm.find("#ddlPCopaId").select2("data")[0].text;
    data["COD_ESANITARIO"] = _EspecieSemillero.frm.find("#ddlEstadoFitoId").val();
    data["DESC_ESANITARIO"] = _EspecieSemillero.frm.find("#ddlEstadoFitoId").select2("data")[0].text;
    data["COD_ILIANAS"] = _EspecieSemillero.frm.find("#ddlGradoInfestId").val();
    data["DESC_ILIANAS"] = _EspecieSemillero.frm.find("#ddlGradoInfestId").select2("data")[0].text;
    data["CANT_SOBRE_ESTIMA_DIAMETRO"] = _EspecieSemillero.frm.find("#txtCantSobreEst").val();
    data["PORC_SOBRE_ESTIMA_DIAMETRO"] = _EspecieSemillero.frm.find("#txtPorcSobreEst").val();
    data["CANT_SUB_ESTIMA_DIAMETRO"] = _EspecieSemillero.frm.find("#txtCantSubEst").val();
    data["PORC_SUB_ESTIMA_DIAMETRO"] = _EspecieSemillero.frm.find("#txtPorcSubEst").val();
    data["OBSERVACION"] = _EspecieSemillero.frm.find("#txtObservacion").val();
    data["PCA"] = _EspecieSemillero.frm.find("#txtParcelaCenso").val() == "0000000" ? "" : _EspecieSemillero.frm.find("#txtParcelaCenso").val();
    data["PCA_POA"] = _EspecieSemillero.frm.find("#txtParcelaCPOA").val();
    return data;
}

_EspecieSemillero.fnCustomValidateForm = function () {
    if (_renderComboEspecie.fnGetCodEspecie() == null) {
        utilSigo.toastWarning("Aviso", "Seleccione la especie a registrar"); return false;
    }
    return true;
}

_EspecieSemillero.fnSubmitForm = function () {
    _EspecieSemillero.frm.submit();
}

_EspecieSemillero.fnInit = function (data) {
    _EspecieSemillero.frm = $("#frmItemEspecieSemillero");

    $.fn.select2.defaults.set("theme", "bootstrap4");
    _EspecieSemillero.frm.find("#ddlCoincideEspecieId").select2({ minimumResultsForSearch: -1 });
    _EspecieSemillero.frm.find("#ddlMetodoMedirDapId").select2({ minimumResultsForSearch: -1 });
    _EspecieSemillero.frm.find("#ddlZonaCampoId").select2({ minimumResultsForSearch: -1 });
    _EspecieSemillero.frm.find("#ddlEstadoCampoId").select2();
    _EspecieSemillero.frm.find("#ddlFenologiaId").select2({ minimumResultsForSearch: -1 });
    _EspecieSemillero.frm.find("#ddlCFusteId").select2({ minimumResultsForSearch: -1 });
    _EspecieSemillero.frm.find("#ddlFCopaId").select2({ minimumResultsForSearch: -1 });
    _EspecieSemillero.frm.find("#ddlPCopaId").select2({ minimumResultsForSearch: -1 });
    _EspecieSemillero.frm.find("#ddlEstadoFitoId").select2({ minimumResultsForSearch: -1 });
    _EspecieSemillero.frm.find("#ddlGradoInfestId").select2({ minimumResultsForSearch: -1 });

    _EspecieSemillero.fnLoadDatos(data);

    //=====-----Para el registro de datos del formulario-----=====
    //Validación personalizada
    jQuery.validator.addMethod("invalidFrmEspecie", function (value, element) {
        switch ($(element).attr('id')) {
            case 'ddlCoincideEspecieId':
            case 'ddlZonaCampoId':
            case 'ddlEstadoCampoId':
                return (value == '0000000') ? false : true;
                break
        }
    });
    _EspecieSemillero.frm.validate(utilSigo.fnValidate({
        rules: {
            ddlCoincideEspecieId: { invalidFrmEspecie: true },
            txtDapCampo: { required: true },
            txtDapCampo1: { required: true },
            txtDapCampo2: { required: true },
            txtAcCampo: { required: true },
            ddlZonaCampoId: { invalidFrmEspecie: true },
            txtCEsteCampo: { required: true },
            txtCNorteCampo: { required: true },
            ddlEstadoCampoId: { invalidFrmEspecie: true },
            txtCantSobreEst: { required: true },
            txtPorcSobreEst: { required: true },
            txtCantSubEst: { required: true },
            txtPorcSubEst: { required: true }
        },
        messages: {
            ddlCoincideEspecieId: { invalidFrmEspecie: "Seleccione una opción" },
            txtDapCampo: { required: "Ingrese el DAP campo (cm)" },
            txtDapCampo1: { required: "Ingrese el DAP campo 1 (cm)" },
            txtDapCampo2: { required: "Ingrese el DAP campo 2 (cm)" },
            txtAcCampo: { required: "Ingrese el AC campo (m)" },
            ddlZonaCampoId: { invalidFrmEspecie: "Seleccione la zona UTM campo" },
            txtCEsteCampo: { required: "Ingrese la coordenada este campo" },
            txtCNorteCampo: { required: "Ingrese la coordenada norte campo" },
            ddlEstadoCampoId: { invalidFrmEspecie: "Seleccione el estado de la especie en campo" },
            txtCantSobreEst: { required: "Ingrese la cantidad sobre estimación de los diámetros" },
            txtPorcSobreEst: { required: "Ingrese el porcentaje sobre estimación de los diámetros" },
            txtCantSubEst: { required: "Ingrese la cantidad sub estimación de los diámetros" },
            txtPorcSubEst: { required: "Ingrese el porcentaje sub estimación de los diámetros" }
        },
        fnSubmit: function (form) {
            if (_EspecieSemillero.fnCustomValidateForm()) {
                var oEspecie = utilSigo.fnConvertArrayToObject(_EspecieSemillero.fnSetDatos());
                var url = urlLocalSigo + "Supervision/ManInforme/GrabarEspecieSemillero";
                var option = { url: url, datos: JSON.stringify(oEspecie), type: 'POST' };
                utilSigo.fnAjax(option, function (data) {
                    if (data.success) {
                        _EspecieSemillero.fnSaveForm(oEspecie);
                    }
                    else {
                        utilSigo.toastWarning("Aviso", data.msj);
                    }
                });
            }
        }
    }));
    //Validación de controles que usan Select2
    _EspecieSemillero.frm.find("select.select2-hidden-accessible").on("change", function (e) {
        $(this).valid();
    });
}