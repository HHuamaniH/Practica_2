"use strict";
var _EspecieSemilleroEdit = {};

_EspecieSemilleroEdit.fnSaveForm = function (data) { /*implementado desde donde se instancia*/ }

_EspecieSemilleroEdit.fnLoadDatos = function (data) {
    var regEstado = "1";
    _EspecieSemilleroEdit.frm = $("#frmItemEspecieSemilleroEdit");
    if (data != null && data != "") {
        if (data.data[0]["CODIGO"] != "") {
            regEstado = "0";
        }
        _EspecieSemilleroEdit.frm.find("#hdfRegEstado").val(regEstado);
        _EspecieSemilleroEdit.frm.find("#hdfCodSecuencial").val(data.data[0]["COD_SECUENCIAL"]);
        _EspecieSemilleroEdit.frm.find("#hdfCodTHabilitante").val(data.data[0]["COD_THABILITANTE"]);
        _EspecieSemilleroEdit.frm.find("#hdfNumPoa").val(data.data[0]["NUM_POA"]);
        _EspecieSemilleroEdit.frm.find("#hdfNombrePoa").val(data.data[0]["POA"]);
        _EspecieSemilleroEdit.frm.find("#hdfCodEspecie").val(data.data[0]["COD_ESPECIES"]);
        _EspecieSemilleroEdit.frm.find("#txtEspecie").val(data.data[0]["DESC_ESPECIES"]);
        _EspecieSemilleroEdit.frm.find("#ddlCoincideEspecieId").select2("val", [data.data[0]["COINCIDE_ESPECIES"]]);
        _EspecieSemilleroEdit.frm.find("#txtBloque").val(data.data[0]["BLOQUE"]);
        _EspecieSemilleroEdit.frm.find("#txtBloqueCampo").val(data.data[0]["BLOQUE_CAMPO"]);
        _EspecieSemilleroEdit.frm.find("#txtFaja").val(data.data[0]["FAJA"]);
        _EspecieSemilleroEdit.frm.find("#txtFajaCampo").val(data.data[0]["FAJA_CAMPO"]);
        _EspecieSemilleroEdit.frm.find("#txtCodigo").val(data.data[0]["CODIGO"]);
        _EspecieSemilleroEdit.frm.find("#txtCodigoCampo").val(data.data[0]["CODIGO_CAMPO"]);
        _EspecieSemilleroEdit.frm.find("#txtDap").val(data.data[0]["DAP"]);
        _EspecieSemilleroEdit.frm.find("#txtDapCampo").val(data.data[0]["DAP_CAMPO"]);
        _EspecieSemilleroEdit.frm.find("#txtDapCampo1").val(data.data[0]["DAP_CAMPO1"]);
        _EspecieSemilleroEdit.frm.find("#txtDapCampo2").val(data.data[0]["DAP_CAMPO2"]);
        _EspecieSemilleroEdit.frm.find("#ddlMetodoMedirDapId").select2("val", [data.data[0]["MAE_TIP_MMEDIRDAP"]]);
        _EspecieSemilleroEdit.frm.find("#txtAc").val(data.data[0]["AC"]);
        _EspecieSemilleroEdit.frm.find("#txtAcCampo").val(data.data[0]["AC_CAMPO"]);
        _EspecieSemilleroEdit.frm.find("#txtZona").val(data.data[0]["ZONA"]);
        _EspecieSemilleroEdit.frm.find("#ddlZonaCampoId").select2("val", [data.data[0]["ZONA_CAMPO"] == "000" ? "0000000" : data.data[0]["ZONA_CAMPO"]]);
        _EspecieSemilleroEdit.frm.find("#txtCEste").val(data.data[0]["COORDENADA_ESTE"]);
        _EspecieSemilleroEdit.frm.find("#txtCEsteCampo").val(data.data[0]["COORDENADA_ESTE_CAMPO"]);
        _EspecieSemilleroEdit.frm.find("#txtCNorte").val(data.data[0]["COORDENADA_NORTE"]);
        _EspecieSemilleroEdit.frm.find("#txtCNorteCampo").val(data.data[0]["COORDENADA_NORTE_CAMPO"]);
        _EspecieSemilleroEdit.frm.find("#txtEstado").val(data.data[0]["DESC_EESTADO"]);
        _EspecieSemilleroEdit.frm.find("#ddlEstadoCampoId").select2("val", [data.data[0]["COD_EESTADO"]]);
        _EspecieSemilleroEdit.frm.find("#ddlFenologiaId").select2("val", [data.data[0]["COD_EFENOLOGICO"]]);
        _EspecieSemilleroEdit.frm.find("#ddlCFusteId").select2("val", [data.data[0]["COD_CFUSTE"]]);
        _EspecieSemilleroEdit.frm.find("#ddlFCopaId").select2("val", [data.data[0]["COD_FCOPA"]]);
        _EspecieSemilleroEdit.frm.find("#ddlPCopaId").select2("val", [data.data[0]["COD_PCOPA"]]);
        _EspecieSemilleroEdit.frm.find("#ddlEstadoFitoId").select2("val", [data.data[0]["COD_ESANITARIO"]]);
        _EspecieSemilleroEdit.frm.find("#ddlGradoInfestId").select2("val", [data.data[0]["COD_ILIANAS"]]);
        _EspecieSemilleroEdit.frm.find("#txtCantSobreEst").val(data.data[0]["CANT_SOBRE_ESTIMA_DIAMETRO"]);
        _EspecieSemilleroEdit.frm.find("#txtPorcSobreEst").val(data.data[0]["PORC_SOBRE_ESTIMA_DIAMETRO"]);
        _EspecieSemilleroEdit.frm.find("#txtCantSubEst").val(data.data[0]["CANT_SUB_ESTIMA_DIAMETRO"]);
        _EspecieSemilleroEdit.frm.find("#txtPorcSubEst").val(data.data[0]["PORC_SUB_ESTIMA_DIAMETRO"]);
        _EspecieSemilleroEdit.frm.find("#txtObservacion").val(data.data[0]["OBSERVACION"]);
        _EspecieSemilleroEdit.frm.find("#txtPCSem").val(data.data[0]["PCA_POA"]);
        _EspecieSemilleroEdit.frm.find("#txtParcelaCampoS").val(data.data[0]["PCA"]);

        _renderComboEspecie.fnInit("FORESTAL", data.data[0]["COD_ESPECIES_CAMPO"], data.data[0]["DESC_ESPECIES_CAMPO"]);
    }
}

_EspecieSemilleroEdit.fnSetDatos = function () {
    var data = [];
    var regEstado = _EspecieSemilleroEdit.frm.find("#hdfRegEstado").val();
    data["RegEstado"] = regEstado == "0" ? "2" : regEstado;
    data["COD_INFORME"] = _EspecieSemilleroEdit.frm.find("#hdfCodInforme").val();
    data["COD_SECUENCIAL"] = _EspecieSemilleroEdit.frm.find("#hdfCodSecuencial").val();
    data["COD_THABILITANTE"] = _EspecieSemilleroEdit.frm.find("#hdfCodTHabilitante").val();
    data["NUM_POA"] = _EspecieSemilleroEdit.frm.find("#hdfNumPoa").val();
    data["POA"] = _EspecieSemilleroEdit.frm.find("#hdfNombrePoa").val();;
    data["COD_ESPECIES_CAMPO"] = _renderComboEspecie.fnGetCodEspecie();
    data["DESC_ESPECIES_CAMPO"] = _renderComboEspecie.fnGetEspecie();
    data["COD_ESPECIES"] = _EspecieSemilleroEdit.frm.find("#hdfCodEspecie").val();
    data["DESC_ESPECIES"] = _EspecieSemilleroEdit.frm.find("#txtEspecie").val();
    data["COINCIDE_ESPECIES"] = _EspecieSemilleroEdit.frm.find("#ddlCoincideEspecieId").val();
    //data["DESC_COINCIDE_ESPECIES"] = _EspecieSemilleroEdit.frm.find("#ddlCoincideEspecieId").val() == "-" ? "" : _EspecieSemilleroEdit.frm.find("#ddlCoincideEspecieId").select2("data")[0].text;
    data["DESC_COINCIDE_ESPECIES"] = _EspecieSemilleroEdit.frm.find("#ddlCoincideEspecieId").val() == "-" ? "" : _EspecieSemilleroEdit.frm.find("#ddlCoincideEspecieId").val();
    data["BLOQUE"] = _EspecieSemilleroEdit.frm.find("#txtBloque").val();
    data["BLOQUE_CAMPO"] = _EspecieSemilleroEdit.frm.find("#txtBloqueCampo").val();
    data["FAJA"] = _EspecieSemilleroEdit.frm.find("#txtFaja").val();
    data["FAJA_CAMPO"] = _EspecieSemilleroEdit.frm.find("#txtFajaCampo").val();
    data["CODIGO"] = _EspecieSemilleroEdit.frm.find("#txtCodigo").val();
    data["CODIGO_CAMPO"] = _EspecieSemilleroEdit.frm.find("#txtCodigoCampo").val();
    data["DAP"] = _EspecieSemilleroEdit.frm.find("#txtDap").val();
    data["DAP_CAMPO"] = _EspecieSemilleroEdit.frm.find("#txtDapCampo").val();
    data["DAP_CAMPO1"] = _EspecieSemilleroEdit.frm.find("#txtDapCampo1").val();
    data["DAP_CAMPO2"] = _EspecieSemilleroEdit.frm.find("#txtDapCampo2").val();
    data["MAE_TIP_MMEDIRDAP"] = _EspecieSemilleroEdit.frm.find("#ddlMetodoMedirDapId").val();
    //data["MMEDIR_DAP"] = _EspecieSemilleroEdit.frm.find("#ddlMetodoMedirDapId").val() == "0000000" ? "" : _EspecieSemilleroEdit.frm.find("#ddlMetodoMedirDapId").select2("data")[0].text;
    data["MMEDIR_DAP"] = _EspecieSemilleroEdit.frm.find("#ddlMetodoMedirDapId").val() == "0000000" ? "" : _EspecieSemilleroEdit.frm.find("#ddlMetodoMedirDapId").val();
    data["AC"] = _EspecieSemilleroEdit.frm.find("#txtAc").val();
    data["AC_CAMPO"] = _EspecieSemilleroEdit.frm.find("#txtAcCampo").val();
    data["ZONA"] = _EspecieSemilleroEdit.frm.find("#txtZona").val();
    data["ZONA_CAMPO"] = _EspecieSemilleroEdit.frm.find("#ddlZonaCampoId").val();
    data["COORDENADA_ESTE"] = _EspecieSemilleroEdit.frm.find("#txtCEste").val();
    data["COORDENADA_ESTE_CAMPO"] = _EspecieSemilleroEdit.frm.find("#txtCEsteCampo").val();
    data["COORDENADA_NORTE"] = _EspecieSemilleroEdit.frm.find("#txtCNorte").val();
    data["COORDENADA_NORTE_CAMPO"] = _EspecieSemilleroEdit.frm.find("#txtCNorteCampo").val();
    data["DESC_EESTADO"] = _EspecieSemilleroEdit.frm.find("#txtEstado").val();
    data["COD_EESTADO"] = _EspecieSemilleroEdit.frm.find("#ddlEstadoCampoId").val();
    //data["DESC_EESTADO_CAMPO"] = _EspecieSemilleroEdit.frm.find("#ddlEstadoCampoId").val() == "0000000" ? "" : _EspecieSemilleroEdit.frm.find("#ddlEstadoCampoId").select2("data")[0].text;
    data["DESC_EESTADO_CAMPO"] = _EspecieSemilleroEdit.frm.find("#ddlEstadoCampoId").val() == "0000000" ? "" : _EspecieSemilleroEdit.frm.find("#ddlEstadoCampoId").val();
    data["COD_EFENOLOGICO"] = _EspecieSemilleroEdit.frm.find("#ddlFenologiaId").val();
    //data["DESC_EFENOLOGICO"] = _EspecieSemilleroEdit.frm.find("#ddlFenologiaId").select2("data")[0].text;
    data["DESC_EFENOLOGICO"] = _EspecieSemilleroEdit.frm.find("#ddlFenologiaId").val();
    data["COD_CFUSTE"] = _EspecieSemilleroEdit.frm.find("#ddlCFusteId").val();
    //data["DESC_CFUSTE"] = _EspecieSemilleroEdit.frm.find("#ddlCFusteId").select2("data")[0].text;
    data["DESC_CFUSTE"] = _EspecieSemilleroEdit.frm.find("#ddlCFusteId").val();
    data["COD_FCOPA"] = _EspecieSemilleroEdit.frm.find("#ddlFCopaId").val();
    //data["DESC_FCOPA"] = _EspecieSemilleroEdit.frm.find("#ddlFCopaId").select2("data")[0].text;
    data["DESC_FCOPA"] = _EspecieSemilleroEdit.frm.find("#ddlFCopaId").val();
    data["COD_PCOPA"] = _EspecieSemilleroEdit.frm.find("#ddlPCopaId").val();
    //data["DESC_PCOPA"] = _EspecieSemilleroEdit.frm.find("#ddlPCopaId").select2("data")[0].text;
    data["DESC_PCOPA"] = _EspecieSemilleroEdit.frm.find("#ddlPCopaId").val();
    data["COD_ESANITARIO"] = _EspecieSemilleroEdit.frm.find("#ddlEstadoFitoId").val();
    //data["DESC_ESANITARIO"] = _EspecieSemilleroEdit.frm.find("#ddlEstadoFitoId").select2("data")[0].text;
    data["DESC_ESANITARIO"] = _EspecieSemilleroEdit.frm.find("#ddlEstadoFitoId").val();
    data["COD_ILIANAS"] = _EspecieSemilleroEdit.frm.find("#ddlGradoInfestId").val();
    //data["DESC_ILIANAS"] = _EspecieSemilleroEdit.frm.find("#ddlGradoInfestId").select2("data")[0].text;
    data["DESC_ILIANAS"] = _EspecieSemilleroEdit.frm.find("#ddlGradoInfestId").val();
    data["CANT_SOBRE_ESTIMA_DIAMETRO"] = _EspecieSemilleroEdit.frm.find("#txtCantSobreEst").val();
    data["PORC_SOBRE_ESTIMA_DIAMETRO"] = _EspecieSemilleroEdit.frm.find("#txtPorcSobreEst").val();
    data["CANT_SUB_ESTIMA_DIAMETRO"] = _EspecieSemilleroEdit.frm.find("#txtCantSubEst").val();
    data["PORC_SUB_ESTIMA_DIAMETRO"] = _EspecieSemilleroEdit.frm.find("#txtPorcSubEst").val();
    data["OBSERVACION"] = _EspecieSemilleroEdit.frm.find("#txtObservacion").val();
    data["PCA"] = _EspecieSemilleroEdit.frm.find("#txtParcelaCampoS").val() == "0000000" ? "" : _EspecieSemilleroEdit.frm.find("#txtParcelaCampoS").val();

    return data;
}

_EspecieSemilleroEdit.fnCustomValidateForm = function () {
    if (_renderComboEspecie.fnGetCodEspecie() == null) {
        utilSigo.toastWarning("Aviso", "Seleccione la especie a registrar"); return false;
    }
    return true;
}

_EspecieSemilleroEdit.fnSubmitForm = function () {
    _EspecieSemilleroEdit.frm.submit();
}

_EspecieSemilleroEdit.fnInit = function (data) {

    _EspecieSemilleroEdit.frm = $("#frmItemEspecieSemilleroEdit");

    _renderComboEspecie.fnInit("FORESTAL", '', '');

    $.fn.select2.defaults.set("theme", "bootstrap4");
    _EspecieSemilleroEdit.frm.find("#ddlCoincideEspecieId").select2({ minimumResultsForSearch: -1 });
    _EspecieSemilleroEdit.frm.find("#ddlMetodoMedirDapId").select2({ minimumResultsForSearch: -1 });
    _EspecieSemilleroEdit.frm.find("#ddlZonaCampoId").select2({ minimumResultsForSearch: -1 });
    _EspecieSemilleroEdit.frm.find("#ddlEstadoCampoId").select2();
    _EspecieSemilleroEdit.frm.find("#ddlFenologiaId").select2({ minimumResultsForSearch: -1 });
    _EspecieSemilleroEdit.frm.find("#ddlCFusteId").select2({ minimumResultsForSearch: -1 });
    _EspecieSemilleroEdit.frm.find("#ddlFCopaId").select2({ minimumResultsForSearch: -1 });
    _EspecieSemilleroEdit.frm.find("#ddlPCopaId").select2({ minimumResultsForSearch: -1 });
    _EspecieSemilleroEdit.frm.find("#ddlEstadoFitoId").select2({ minimumResultsForSearch: -1 });
    _EspecieSemilleroEdit.frm.find("#ddlGradoInfestId").select2({ minimumResultsForSearch: -1 });

    _EspecieSemilleroEdit.fnLoadDatos(data);

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
    _EspecieSemilleroEdit.frm.validate(utilSigo.fnValidate({
        rules: {
            ddlCoincideEspecieId: { invalidFrmEspecie: true },
            txtDapCampo: { required: true },
            txtDapCampo1: { required: true },
            txtDapCampo2: { required: true },
            txtAcCampo: { required: true },
            ddlZonaCampoId: { invalidFrmEspecie: true },
            txtCEsteCampo: { required: true, minlenfrmCEste: true },
            txtCNorteCampo: { required: true, minlenfrmCNorte: true },
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
            txtCEsteCampo: { required: "Ingrese la coordenada este campo", minlenfrmCEste: "Ingrese una coordenada de 6 digitos" },
            txtCNorteCampo: { required: "Ingrese la coordenada norte campo", minlenfrmCNorte: "Ingrese una coordenada de 7 digitos" },
            ddlEstadoCampoId: { invalidFrmEspecie: "Seleccione el estado de la especie en campo" },
            txtCantSobreEst: { required: "Ingrese la cantidad sobre estimación de los diámetros" },
            txtPorcSobreEst: { required: "Ingrese el porcentaje sobre estimación de los diámetros" },
            txtCantSubEst: { required: "Ingrese la cantidad sub estimación de los diámetros" },
            txtPorcSubEst: { required: "Ingrese el porcentaje sub estimación de los diámetros" }
        },
        fnSubmit: function (form) {
            if (_EspecieSemilleroEdit.fnCustomValidateForm()) {
                var oEspecie = utilSigo.fnConvertArrayToObject(_EspecieSemilleroEdit.fnSetDatos());
                var url = urlLocalSigo + "Supervision/ManInforme/GrabarEspecieSemillero";
                var option = { url: url, datos: JSON.stringify(oEspecie), type: 'POST' };
                utilSigo.fnAjax(option, function (data) {
                    if (data.success) {
                        _EspecieSemilleroEdit.fnSaveForm(oEspecie);
                        utilSigo.toastSuccess("Aviso", "Datos guardados correctamente");
                        Limpiar();
                    }
                    else {
                        utilSigo.toastWarning("Aviso", data.msj);
                    }
                });
            }
        }
    }));
    //Validación de controles que usan Select2
    _EspecieSemilleroEdit.frm.find("select.select2-hidden-accessible").on("change", function (e) {
        $(this).valid();
    });

    _EspecieSemilleroEdit.frm.find("#ddlRenderComboEspecieId").on("change", function (e) {
        Coincidencia();
    });

    _EspecieSemilleroEdit.frm.find("#ddlEstadoCampoId").on("change", function (e) {
        clearValidationErrors();
        var est = _EspecieSemilleroEdit.frm.find("#ddlEstadoCampoId").val();
        if (est == "0000009") { // No existe
            //  Solo habilitamos Zona, Coordenadas y Observacion
            _EspecieSemilleroEdit.frm.find("#txtDapCampo").rules('remove');
            _EspecieSemilleroEdit.frm.find("#txtDapCampo1").rules('remove');
            _EspecieSemilleroEdit.frm.find("#txtDapCampo2").rules('remove');
            _EspecieSemilleroEdit.frm.find("#txtAcCampo").rules('remove');
            _EspecieSemilleroEdit.frm.find("#ddlEstadoCampoId").rules('remove');
            _EspecieSemilleroEdit.frm.find("#txtCantSobreEst").rules('remove');
            _EspecieSemilleroEdit.frm.find("#txtPorcSobreEst").rules('remove');
            _EspecieSemilleroEdit.frm.find("#txtCantSubEst").rules('remove');
            _EspecieSemilleroEdit.frm.find("#txtPorcSubEst").rules('remove');

            //_EspecieSemilleroEdit.frm.find("#ddlRenderComboEspecieId").attr('disabled', 'disabled');
            _EspecieSemilleroEdit.frm.find("#ddlCoincideEspecieId").attr('disabled', 'disabled');
            _EspecieSemilleroEdit.frm.find("#txtBloqueCampo").attr('disabled', 'disabled');
            _EspecieSemilleroEdit.frm.find("#txtFajaCampo").attr('disabled', 'disabled');
            _EspecieSemilleroEdit.frm.find("#txtCodigoCampo").attr('disabled', 'disabled');
            _EspecieSemilleroEdit.frm.find("#txtDapCampo").attr('disabled', 'disabled');
            _EspecieSemilleroEdit.frm.find("#txtDapCampo1").attr('disabled', 'disabled');
            _EspecieSemilleroEdit.frm.find("#txtDapCampo2").attr('disabled', 'disabled');
            _EspecieSemilleroEdit.frm.find("#ddlMetodoMedirDapId").attr('disabled', 'disabled');
            _EspecieSemilleroEdit.frm.find("#txtAcCampo").attr('disabled', 'disabled');
            _EspecieSemilleroEdit.frm.find("#txtCantSobreEst").attr('disabled', 'disabled');
            _EspecieSemilleroEdit.frm.find("#txtPorcSobreEst").attr('disabled', 'disabled');
            _EspecieSemilleroEdit.frm.find("#txtCantSubEst").attr('disabled', 'disabled');
            _EspecieSemilleroEdit.frm.find("#txtPorcSubEst").attr('disabled', 'disabled');
            _EspecieSemilleroEdit.frm.find("#ddlFenologiaId").attr('disabled', 'disabled');
            _EspecieSemilleroEdit.frm.find("#ddlCFusteId").attr('disabled', 'disabled');
            _EspecieSemilleroEdit.frm.find("#ddlFCopaId").attr('disabled', 'disabled');
            _EspecieSemilleroEdit.frm.find("#ddlPCopaId").attr('disabled', 'disabled');
            _EspecieSemilleroEdit.frm.find("#ddlEstadoFitoId").attr('disabled', 'disabled');
            _EspecieSemilleroEdit.frm.find("#ddlGradoInfestId").attr('disabled', 'disabled');

            _EspecieSemilleroEdit.frm.find("#ddlZonaCampoId").removeAttr('disabled');
            _EspecieSemilleroEdit.frm.find("#txtCEsteCampo").removeAttr('disabled');
            _EspecieSemilleroEdit.frm.find("#txtCNorteCampo").removeAttr('disabled');
        }
        else {
            if (est == "0000011") { // No Evaluado
                //Solo habilitamos Observacion
                _EspecieSemilleroEdit.frm.find("#txtDapCampo").rules('remove');
                _EspecieSemilleroEdit.frm.find("#txtDapCampo1").rules('remove');
                _EspecieSemilleroEdit.frm.find("#txtDapCampo2").rules('remove');
                _EspecieSemilleroEdit.frm.find("#txtAcCampo").rules('remove');
                _EspecieSemilleroEdit.frm.find("#ddlEstadoCampoId").rules('remove');
                _EspecieSemilleroEdit.frm.find("#txtCantSobreEst").rules('remove');
                _EspecieSemilleroEdit.frm.find("#txtPorcSobreEst").rules('remove');
                _EspecieSemilleroEdit.frm.find("#txtCantSubEst").rules('remove');
                _EspecieSemilleroEdit.frm.find("#txtPorcSubEst").rules('remove');
                _EspecieSemilleroEdit.frm.find("#ddlZonaCampoId").rules('remove');
                _EspecieSemilleroEdit.frm.find("#txtCEsteCampo").rules('remove');
                _EspecieSemilleroEdit.frm.find("#txtCNorteCampo").rules('remove');

                //_EspecieSemilleroEdit.frm.find("#ddlRenderComboEspecieId").attr('disabled', 'disabled');
                _EspecieSemilleroEdit.frm.find("#ddlCoincideEspecieId").attr('disabled', 'disabled');
                _EspecieSemilleroEdit.frm.find("#txtBloqueCampo").attr('disabled', 'disabled');
                _EspecieSemilleroEdit.frm.find("#txtFajaCampo").attr('disabled', 'disabled');
                _EspecieSemilleroEdit.frm.find("#txtCodigoCampo").attr('disabled', 'disabled');
                _EspecieSemilleroEdit.frm.find("#txtDapCampo").attr('disabled', 'disabled');
                _EspecieSemilleroEdit.frm.find("#txtDapCampo1").attr('disabled', 'disabled');
                _EspecieSemilleroEdit.frm.find("#txtDapCampo2").attr('disabled', 'disabled');
                _EspecieSemilleroEdit.frm.find("#ddlMetodoMedirDapId").attr('disabled', 'disabled');
                _EspecieSemilleroEdit.frm.find("#txtAcCampo").attr('disabled', 'disabled');
                _EspecieSemilleroEdit.frm.find("#txtCantSobreEst").attr('disabled', 'disabled');
                _EspecieSemilleroEdit.frm.find("#txtPorcSobreEst").attr('disabled', 'disabled');
                _EspecieSemilleroEdit.frm.find("#txtCantSubEst").attr('disabled', 'disabled');
                _EspecieSemilleroEdit.frm.find("#txtPorcSubEst").attr('disabled', 'disabled');
                _EspecieSemilleroEdit.frm.find("#ddlFenologiaId").attr('disabled', 'disabled');
                _EspecieSemilleroEdit.frm.find("#ddlCFusteId").attr('disabled', 'disabled');
                _EspecieSemilleroEdit.frm.find("#ddlFCopaId").attr('disabled', 'disabled');
                _EspecieSemilleroEdit.frm.find("#ddlPCopaId").attr('disabled', 'disabled');
                _EspecieSemilleroEdit.frm.find("#ddlEstadoFitoId").attr('disabled', 'disabled');
                _EspecieSemilleroEdit.frm.find("#ddlGradoInfestId").attr('disabled', 'disabled');

                _EspecieSemilleroEdit.frm.find("#ddlZonaCampoId").attr('disabled', 'disabled');
                _EspecieSemilleroEdit.frm.find("#txtCEsteCampo").attr('disabled', 'disabled');
                _EspecieSemilleroEdit.frm.find("#txtCNorteCampo").attr('disabled', 'disabled');
            }
            else {
                if (est == "0000003" | est == "0000002" | est == "0000010") { // Movilizado
                    _EspecieSemilleroEdit.frm.find("#txtDapCampo").rules('remove');
                    _EspecieSemilleroEdit.frm.find("#txtDapCampo1").rules("add", { required: true, messages: { required: 'Ingrese el DAP campo 1 (cm)' } });
                    _EspecieSemilleroEdit.frm.find("#txtDapCampo2").rules("add", { required: true, messages: { required: 'Ingrese el DAP campo 2 (cm)' } });
                    _EspecieSemilleroEdit.frm.find("#txtAcCampo").rules("add", { required: true, messages: { required: "Ingrese el AC campo (m)" } });
                    _EspecieSemilleroEdit.frm.find("#ddlEstadoCampoId").rules("add", { required: true, messages: { required: "Seleccione el estado de la especie en campo" } });
                    _EspecieSemilleroEdit.frm.find("#txtCantSobreEst").rules("add", { required: true, messages: { required: "Ingrese la cantidad sobre estimación de los diámetros" } });
                    _EspecieSemilleroEdit.frm.find("#txtPorcSobreEst").rules("add", { required: true, messages: { required: "Ingrese el porcentaje sobre estimación de los diámetros" } });
                    _EspecieSemilleroEdit.frm.find("#txtCantSubEst").rules("add", { required: true, messages: { required: "Ingrese la cantidad sub estimación de los diámetros" } });
                    _EspecieSemilleroEdit.frm.find("#txtPorcSubEst").rules("add", { required: true, messages: { required: "Ingrese el porcentaje sub estimación de los diámetros" } });
                    _EspecieSemilleroEdit.frm.find("#ddlZonaCampoId").rules("add", { required: true, messages: { required: "Seleccione la zona UTM campo" } });
                    _EspecieSemilleroEdit.frm.find("#txtCEsteCampo").rules("add", { required: true, messages: { required: "Ingrese la coordenada este campo" } });
                    _EspecieSemilleroEdit.frm.find("#txtCNorteCampo").rules("add", { required: true, messages: { required: "Ingrese la coordenada norte campo" } });

                    _EspecieSemilleroEdit.frm.find("#ddlCoincideEspecieId").removeAttr('disabled');
                    _EspecieSemilleroEdit.frm.find("#txtBloqueCampo").removeAttr('disabled');
                    _EspecieSemilleroEdit.frm.find("#txtFajaCampo").removeAttr('disabled');
                    _EspecieSemilleroEdit.frm.find("#txtCodigoCampo").removeAttr('disabled');
                    _EspecieSemilleroEdit.frm.find("#txtDapCampo").val("");
                    _EspecieSemilleroEdit.frm.find("#txtDapCampo").attr('disabled', 'disabled');
                    _EspecieSemilleroEdit.frm.find("#txtDapCampo1").removeAttr('disabled');
                    _EspecieSemilleroEdit.frm.find("#txtDapCampo2").removeAttr('disabled');
                    _EspecieSemilleroEdit.frm.find("#ddlMetodoMedirDapId").val("0000000");
                    $('#ddlMetodoMedirDapId').select2().trigger('change');
                    _EspecieSemilleroEdit.frm.find("#ddlMetodoMedirDapId").attr('disabled', 'disabled');
                    _EspecieSemilleroEdit.frm.find("#txtAcCampo").removeAttr('disabled');
                    _EspecieSemilleroEdit.frm.find("#txtCantSobreEst").removeAttr('disabled');
                    _EspecieSemilleroEdit.frm.find("#txtPorcSobreEst").removeAttr('disabled');
                    _EspecieSemilleroEdit.frm.find("#txtCantSubEst").removeAttr('disabled');
                    _EspecieSemilleroEdit.frm.find("#txtPorcSubEst").removeAttr('disabled');
                    _EspecieSemilleroEdit.frm.find("#ddlZonaCampoId").removeAttr('disabled');
                    _EspecieSemilleroEdit.frm.find("#txtCEsteCampo").removeAttr('disabled');
                    _EspecieSemilleroEdit.frm.find("#txtCNorteCampo").removeAttr('disabled');
                    _EspecieSemilleroEdit.frm.find("#ddlFenologiaId").removeAttr('disabled');
                    _EspecieSemilleroEdit.frm.find("#ddlCFusteId").removeAttr('disabled');
                    _EspecieSemilleroEdit.frm.find("#ddlFCopaId").removeAttr('disabled');
                    _EspecieSemilleroEdit.frm.find("#ddlPCopaId").removeAttr('disabled');
                    _EspecieSemilleroEdit.frm.find("#ddlEstadoFitoId").removeAttr('disabled');
                    _EspecieSemilleroEdit.frm.find("#ddlGradoInfestId").removeAttr('disabled');
                }
                else {
                    if (est == "0000004") { // En Pie
                        _EspecieSemilleroEdit.frm.find("#txtDapCampo").rules("add", { required: true, messages: { required: 'Ingrese el DAP campo (cm)' } });
                        _EspecieSemilleroEdit.frm.find("#txtDapCampo1").rules("add", { required: true, messages: { required: 'Ingrese el DAP campo 1 (cm)' } });
                        _EspecieSemilleroEdit.frm.find("#txtDapCampo2").rules("add", { required: true, messages: { required: 'Ingrese el DAP campo 2 (cm)' } });
                        _EspecieSemilleroEdit.frm.find("#txtAcCampo").rules("add", { required: true, messages: { required: "Ingrese el AC campo (m)" } });
                        _EspecieSemilleroEdit.frm.find("#ddlEstadoCampoId").rules("add", { required: true, messages: { required: "Seleccione el estado de la especie en campo" } });
                        _EspecieSemilleroEdit.frm.find("#txtCantSobreEst").rules("add", { required: true, messages: { required: "Ingrese la cantidad sobre estimación de los diámetros" } });
                        _EspecieSemilleroEdit.frm.find("#txtPorcSobreEst").rules("add", { required: true, messages: { required: "Ingrese el porcentaje sobre estimación de los diámetros" } });
                        _EspecieSemilleroEdit.frm.find("#txtCantSubEst").rules("add", { required: true, messages: { required: "Ingrese la cantidad sub estimación de los diámetros" } });
                        _EspecieSemilleroEdit.frm.find("#txtPorcSubEst").rules("add", { required: true, messages: { required: "Ingrese el porcentaje sub estimación de los diámetros" } });
                        _EspecieSemilleroEdit.frm.find("#ddlZonaCampoId").rules("add", { required: true, messages: { required: "Seleccione la zona UTM campo" } });
                        _EspecieSemilleroEdit.frm.find("#txtCEsteCampo").rules("add", { required: true, messages: { required: "Ingrese la coordenada este campo" } });
                        _EspecieSemilleroEdit.frm.find("#txtCNorteCampo").rules("add", { required: true, messages: { required: "Ingrese la coordenada norte campo" } });
                        _EspecieSemilleroEdit.frm.find("#ddlCoincideEspecieId").removeAttr('disabled');
                        _EspecieSemilleroEdit.frm.find("#txtBloqueCampo").removeAttr('disabled');
                        _EspecieSemilleroEdit.frm.find("#txtFajaCampo").removeAttr('disabled');
                        _EspecieSemilleroEdit.frm.find("#txtCodigoCampo").removeAttr('disabled');
                        _EspecieSemilleroEdit.frm.find("#txtDapCampo").removeAttr('disabled');
                        _EspecieSemilleroEdit.frm.find("#txtDapCampo1").attr('disabled', 'disabled');
                        _EspecieSemilleroEdit.frm.find("#txtDapCampo2").attr('disabled', 'disabled');
                        _EspecieSemilleroEdit.frm.find("#ddlMetodoMedirDapId").removeAttr('disabled');
                        _EspecieSemilleroEdit.frm.find("#txtAcCampo").removeAttr('disabled');
                        _EspecieSemilleroEdit.frm.find("#txtCantSobreEst").removeAttr('disabled');
                        _EspecieSemilleroEdit.frm.find("#txtPorcSobreEst").removeAttr('disabled');
                        _EspecieSemilleroEdit.frm.find("#txtCantSubEst").removeAttr('disabled');
                        _EspecieSemilleroEdit.frm.find("#txtPorcSubEst").removeAttr('disabled');
                        _EspecieSemilleroEdit.frm.find("#ddlZonaCampoId").removeAttr('disabled');
                        _EspecieSemilleroEdit.frm.find("#txtCEsteCampo").removeAttr('disabled');
                        _EspecieSemilleroEdit.frm.find("#txtCNorteCampo").removeAttr('disabled');
                        _EspecieSemilleroEdit.frm.find("#ddlFenologiaId").removeAttr('disabled');
                        _EspecieSemilleroEdit.frm.find("#ddlCFusteId").removeAttr('disabled');
                        _EspecieSemilleroEdit.frm.find("#ddlFCopaId").removeAttr('disabled');
                        _EspecieSemilleroEdit.frm.find("#ddlPCopaId").removeAttr('disabled');
                        _EspecieSemilleroEdit.frm.find("#ddlEstadoFitoId").removeAttr('disabled');
                        _EspecieSemilleroEdit.frm.find("#ddlGradoInfestId").removeAttr('disabled');
                    } else {
                        _EspecieSemilleroEdit.frm.find("#txtDapCampo").rules("add", { required: true, messages: { required: 'Ingrese el DAP campo (cm)' } });
                        _EspecieSemilleroEdit.frm.find("#txtDapCampo1").rules("add", { required: true, messages: { required: 'Ingrese el DAP campo 1 (cm)' } });
                        _EspecieSemilleroEdit.frm.find("#txtDapCampo2").rules("add", { required: true, messages: { required: 'Ingrese el DAP campo 2 (cm)' } });
                        _EspecieSemilleroEdit.frm.find("#txtAcCampo").rules("add", { required: true, messages: { required: "Ingrese el AC campo (m)" } });
                        _EspecieSemilleroEdit.frm.find("#ddlEstadoCampoId").rules("add", { required: true, messages: { required: "Seleccione el estado de la especie en campo" } });
                        _EspecieSemilleroEdit.frm.find("#txtCantSobreEst").rules("add", { required: true, messages: { required: "Ingrese la cantidad sobre estimación de los diámetros" } });
                        _EspecieSemilleroEdit.frm.find("#txtPorcSobreEst").rules("add", { required: true, messages: { required: "Ingrese el porcentaje sobre estimación de los diámetros" } });
                        _EspecieSemilleroEdit.frm.find("#txtCantSubEst").rules("add", { required: true, messages: { required: "Ingrese la cantidad sub estimación de los diámetros" } });
                        _EspecieSemilleroEdit.frm.find("#txtPorcSubEst").rules("add", { required: true, messages: { required: "Ingrese el porcentaje sub estimación de los diámetros" } });
                        _EspecieSemilleroEdit.frm.find("#ddlZonaCampoId").rules("add", { required: true, messages: { required: "Seleccione la zona UTM campo" } });
                        _EspecieSemilleroEdit.frm.find("#txtCEsteCampo").rules("add", { required: true, messages: { required: "Ingrese la coordenada este campo" } });
                        _EspecieSemilleroEdit.frm.find("#txtCNorteCampo").rules("add", { required: true, messages: { required: "Ingrese la coordenada norte campo" } });

                        //_EspecieSemilleroEdit.frm.find("#ddlRenderComboEspecieId").removeAttr('disabled');
                        _EspecieSemilleroEdit.frm.find("#ddlCoincideEspecieId").removeAttr('disabled');
                        _EspecieSemilleroEdit.frm.find("#txtBloqueCampo").removeAttr('disabled');
                        _EspecieSemilleroEdit.frm.find("#txtFajaCampo").removeAttr('disabled');
                        _EspecieSemilleroEdit.frm.find("#txtCodigoCampo").removeAttr('disabled');
                        _EspecieSemilleroEdit.frm.find("#txtDapCampo").removeAttr('disabled');
                        _EspecieSemilleroEdit.frm.find("#txtDapCampo1").removeAttr('disabled');
                        _EspecieSemilleroEdit.frm.find("#txtDapCampo2").removeAttr('disabled');
                        _EspecieSemilleroEdit.frm.find("#ddlMetodoMedirDapId").removeAttr('disabled');
                        _EspecieSemilleroEdit.frm.find("#txtAcCampo").removeAttr('disabled');
                        _EspecieSemilleroEdit.frm.find("#txtCantSobreEst").removeAttr('disabled');
                        _EspecieSemilleroEdit.frm.find("#txtPorcSobreEst").removeAttr('disabled');
                        _EspecieSemilleroEdit.frm.find("#txtCantSubEst").removeAttr('disabled');
                        _EspecieSemilleroEdit.frm.find("#txtPorcSubEst").removeAttr('disabled');
                        _EspecieSemilleroEdit.frm.find("#ddlZonaCampoId").removeAttr('disabled');
                        _EspecieSemilleroEdit.frm.find("#txtCEsteCampo").removeAttr('disabled');
                        _EspecieSemilleroEdit.frm.find("#txtCNorteCampo").removeAttr('disabled');
                        _EspecieSemilleroEdit.frm.find("#ddlFenologiaId").removeAttr('disabled');
                        _EspecieSemilleroEdit.frm.find("#ddlCFusteId").removeAttr('disabled');
                        _EspecieSemilleroEdit.frm.find("#ddlFCopaId").removeAttr('disabled');
                        _EspecieSemilleroEdit.frm.find("#ddlPCopaId").removeAttr('disabled');
                        _EspecieSemilleroEdit.frm.find("#ddlEstadoFitoId").removeAttr('disabled');
                        _EspecieSemilleroEdit.frm.find("#ddlGradoInfestId").removeAttr('disabled');
                    }
                }                
            }
        }
    });

};

_EspecieSemilleroEdit.fnSearch = function () {

    var codInforme = $("#hdfCodInforme").val();
    var codTHabilitante = $("#hdfCodTHabilitante").val();
    var numPoa = $("#hdfNumPoa").val();

    //Uno
    //var codInforme = "000120180000803"; //$("#hdfCodInforme").val();
    //var codTHabilitante = "20130002078";
    //var numPoa = "0";

    //  Varios
    //var codInforme = "20130002398";
    //var codTHabilitante = "20130001013";
    //var numPoa = "7";

    var bloque = $("#txtBloqueB").val();
    var faja = $("#txtFajaB").val();
    var codigo = $("#txtCodigoB").val();
    var pca = _EspecieSemilleroEdit.frm.find("#txtPCEMS").val();

    $("#txtBloque").val(bloque);
    $("#txtFaja").val(faja);
    $("#txtCodigo").val(codigo);

    var secuencial = 0;

    var url = urlLocalSigo + "Supervision/ManInforme/GetDatosSemillero";
    var option = {
        url: url,
        datos: JSON.stringify({
            asCodInforme: codInforme,
            asCodTHabilitante: codTHabilitante,
            asNumPoa: numPoa,
            asBloque: bloque,
            asFaja: faja,
            asCodigo: codigo,
            asPCA: pca,
            asCodSecuencial: secuencial
        }),
        type: 'POST'
    };

    utilSigo.fnAjax(option, function (data) {
        if (data.success) {
            if (data.data.length == 1) {
                Limpiar();
                _EspecieSemilleroEdit.fnLoadDatos(data);
            }
            else {
                if (data.data.length == 0) {
                    Limpiar();
                    utilSigo.toastWarning("Aviso", "No se encontraron resultados");
                }
                else {
                    var mensaje = "";
                    for (var i = 0; i < data.data.length; i++) {
                        var pri = 'Bloque:\u00A0';
                        var seg = ',\u00A0Faja:\u00A0';
                        var bloque = data.data[i].BLOQUE;
                        var faja = data.data[i].FAJA;
                        var este = data.data[i].COORDENADA_ESTE;
                        var norte = data.data[i].COORDENADA_NORTE;
                        var codSec = data.data[i].COD_SECUENCIAL;
                        var aviso = pri + bloque + seg + faja + '\u00A0y\u00A0Coordenadas:\u00A0' + este + ',' + norte;

                        mensaje += "<a href='#' onclick=AbrirOpciones('" + bloque + "#" + faja + "#" + codSec + "'); data-dismiss='modal'>" + aviso + "</a>" + "<br/>";
                    }
                    utilSigo.dialogConfirma("Se encontro mas de un registro:", mensaje, function (r) {
                        if (r) {
                            return false;
                        }
                    });
                }
            }
        }
        else {
            utilSigo.toastWarning("Aviso", data.msj);

            setTimeout(function () {
                $('#dvAlerta').fadeOut('fast');
            }, 1000);
        }
    })
}

_EspecieSemilleroEdit.fnSearchR = function (bloque, faja, codigo, secuencial) {

    var codInforme = $("#hdfCodInforme").val();
    var codTHabilitante = $("#hdfCodTHabilitante").val();
    var numPoa = _EspecieSemilleroEdit.frm.find("#hdfNumPoa").val();

    $("#txtBloque").val(bloque);
    $("#txtFaja").val(faja);
    $("#txtCodigo").val(codigo);
    var pca = '0000000';
    var secuencial = secuencial;
    var url = urlLocalSigo + "Supervision/ManInforme/GetDatosSemillero";
    var option = {
        url: url,
        datos: JSON.stringify({
            asCodInforme: codInforme,
            asCodTHabilitante: codTHabilitante,
            asNumPoa: numPoa,
            asBloque: bloque,
            asFaja: faja,
            asCodigo: codigo,
            asPCA: pca,
            asCodSecuencial: secuencial
        }),
        type: 'POST'
    };

    utilSigo.fnAjax(option, function (data) {
        if (data.success) {
            if (data.data.length == 1) {
                Limpiar();
                _EspecieSemilleroEdit.fnLoadDatos(data);
            }
            else {
                if (data.data.length == 0) {
                    Limpiar();
                    utilSigo.toastWarning("Aviso", "No se encontraron resultados");
                }
                else {
                    var mensaje = "";
                    for (var i = 0; i < data.data.length; i++) {
                        var pri = 'Bloque:\u00A0';
                        var seg = ',\u00A0Faja:\u00A0';
                        var bloque = data.data[i].BLOQUE;
                        var faja = data.data[i].FAJA;
                        var este = data.data[i].COORDENADA_ESTE;
                        var norte = data.data[i].COORDENADA_NORTE;
                        var codSec = data.data[i].COD_SECUENCIAL;

                        var aviso = pri + bloque + seg + faja + '\u00A0y\u00A0Coordenadas:\u00A0' + este + ',' + norte;

                        mensaje += "<a href='#' onclick=AbrirOpciones('" + bloque + "#" + faja + "#" + codSec + "'); data-dismiss='modal'>" + aviso + "</a>" + "<br/>";
                    }
                    utilSigo.dialogConfirma("Se encontro mas de un registro:", mensaje, function (r) {
                        if (r) {
                            return false;
                        }
                    });
                }
            }
        }
        else {
            utilSigo.toastWarning("Aviso", data.msj);

            setTimeout(function () {
                $('#dvAlerta').fadeOut('fast');
            }, 1000);
        }
    })
}
utilSigo.dialogConfirma = function (_title, _msg, fnOk, fnCancel) {
    //var ventana_alto = $(window).height();
    var altNavegador = $(window).height();
    bootbox.dialog({
        title: "",
        message: _title + "<br/>" + "<br/>" + _msg,
        buttons: {
            Cancel: {
                label: 'Cancelar',
                className: "btn-sm",
                iconFa: 'fa-times',
                callback: fnCancel
            }
        }
    }).css({ top: altNavegador / 5 });

    //Poner el enfoque en el modal que se encuentra abierto (problema con el scroll)
    $(document).unbind("bootbox.modal").on('hidden.bs.modal', function () {
        if ($('.modal:visible').length) { // check whether parent modal is opend after child modal close
            $('body').addClass('modal-open'); // if open mean length is 1 then add a bootstrap css class to body of the page
        }
    });
};

function AbrirOpciones(valores) {
    var separador = "#",
        arreglo = valores.split(separador);
    var a = arreglo[0];
    var b = arreglo[1];
    var c = arreglo[2];

    $("#txtBloqueB").val(a);
    $("#txtFajaB").val(b);
    var cod = $("#txtCodigoB").val();
    
    Limpiar();

    _EspecieSemilleroEdit.fnSearchR(a, b, cod,c);

}

function Limpiar() {
    var sel = document.getElementById("ddlRenderComboEspecieId");
    sel.remove(sel.selectedIndex);

    _EspecieSemilleroEdit.frm = $("#frmItemEspecieSemilleroEdit");
    var regEstado = "1"; // Nuevo
    _EspecieSemilleroEdit.frm.find("#txtPCEMS").val("0000000");

    _EspecieSemilleroEdit.frm.find("#hdfRegEstado").val(regEstado);
    _EspecieSemilleroEdit.frm.find("#hdfCodSecuencial").val("");
    _EspecieSemilleroEdit.frm.find("#hdfCodEspecie").val("");
    _EspecieSemilleroEdit.frm.find("#txtCodigoB").val("");
    _EspecieSemilleroEdit.frm.find("#txtEspecie").val("");
    _EspecieSemilleroEdit.frm.find("#txtBloqueB").val("");
    _EspecieSemilleroEdit.frm.find("#txtFajaB").val("");
    _EspecieSemilleroEdit.frm.find("#txtCodigoB").val("");
    _EspecieSemilleroEdit.frm.find("#ddlCoincideEspecieId").val("-");
    $('#ddlCoincideEspecieId').select2().trigger('change');
    _EspecieSemilleroEdit.frm.find("#txtBloque").val("");
    _EspecieSemilleroEdit.frm.find("#txtBloqueCampo").val("");
    _EspecieSemilleroEdit.frm.find("#txtFaja").val("");
    _EspecieSemilleroEdit.frm.find("#txtFajaCampo").val("");
    _EspecieSemilleroEdit.frm.find("#txtCodigo").val("");
    _EspecieSemilleroEdit.frm.find("#txtCodigoCampo").val("");
    _EspecieSemilleroEdit.frm.find("#txtDap").val("");
    _EspecieSemilleroEdit.frm.find("#txtDapCampo").val("");
    _EspecieSemilleroEdit.frm.find("#txtDapCampo1").val("");
    _EspecieSemilleroEdit.frm.find("#txtDapCampo2").val("");
    _EspecieSemilleroEdit.frm.find("#ddlMetodoMedirDapId").val("0000000");
    $('#ddlMetodoMedirDapId').select2().trigger('change');
    _EspecieSemilleroEdit.frm.find("#txtAc").val("");
    _EspecieSemilleroEdit.frm.find("#txtAcCampo").val("");
    _EspecieSemilleroEdit.frm.find("#txtZona").val("");
    _EspecieSemilleroEdit.frm.find("#ddlZonaCampoId").val("0000000");
    $('#ddlZonaCampoId').select2().trigger('change');
    _EspecieSemilleroEdit.frm.find("#txtCEste").val("");
    _EspecieSemilleroEdit.frm.find("#txtCEsteCampo").val("");
    _EspecieSemilleroEdit.frm.find("#txtCNorte").val("");
    _EspecieSemilleroEdit.frm.find("#txtCNorteCampo").val("");
    _EspecieSemilleroEdit.frm.find("#txtEstado").val("");
    _EspecieSemilleroEdit.frm.find("#ddlEstadoCampoId").val("0000000");
    $('#ddlEstadoCampoId').select2().trigger('change');
    _EspecieSemilleroEdit.frm.find("#txtCondicion").val("");
    _EspecieSemilleroEdit.frm.find("#ddlFenologiaId").val("0000001");
    $('#ddlFenologiaId').select2().trigger('change');
    _EspecieSemilleroEdit.frm.find("#ddlCFusteId").val("0000000");
    $('#ddlCFusteId').select2().trigger('change');
    _EspecieSemilleroEdit.frm.find("#ddlFCopaId").val("0000000");
    $('#ddlFCopaId').select2().trigger('change');
    _EspecieSemilleroEdit.frm.find("#ddlPCopaId").val("0000000");
    $('#ddlPCopaId').select2().trigger('change');
    _EspecieSemilleroEdit.frm.find("#ddlEstadoFitoId").val("0000000");
    $('#ddlEstadoFitoId').select2().trigger('change');
    _EspecieSemilleroEdit.frm.find("#ddlGradoInfestId").val("0000000");
    $('#ddlGradoInfestId').select2().trigger('change');
    _EspecieSemilleroEdit.frm.find("#txtCantSobreEst").val("");
    _EspecieSemilleroEdit.frm.find("#txtPorcSobreEst").val("");
    _EspecieSemilleroEdit.frm.find("#txtCantSubEst").val("");
    _EspecieSemilleroEdit.frm.find("#txtPorcSubEst").val("");
    _EspecieSemilleroEdit.frm.find("#txtObservacion").val("");
    _renderComboEspecie.fnInit("FORESTAL", '', '');

}

function Coincidencia() {
    var a = _renderComboEspecie.fnGetEspecie();
    var b = _EspecieSemilleroEdit.frm.find("#txtEspecie").val();
    if (a == b) {
        _EspecieSemilleroEdit.frm.find("#ddlCoincideEspecieId").val("SI");
    }
    else {
        _EspecieSemilleroEdit.frm.find("#ddlCoincideEspecieId").val("NO");
    }
    _EspecieSemilleroEdit.frm.find("#ddlCoincideEspecieId").select2().trigger('change');
}

function clearValidationErrors() {
    _EspecieSemilleroEdit.frm.find("#txtDapCampo").removeClass('form-control form-control-sm border-danger');
    _EspecieSemilleroEdit.frm.find("#txtDapCampo").addClass('form-control form-control-sm');
    _EspecieSemilleroEdit.frm.find("#txtDapCampo1").removeClass('form-control form-control-sm border-danger');
    _EspecieSemilleroEdit.frm.find("#txtDapCampo1").addClass('form-control form-control-sm');
    _EspecieSemilleroEdit.frm.find("#txtDapCampo2").removeClass('form-control form-control-sm border-danger');
    _EspecieSemilleroEdit.frm.find("#txtDapCampo2").addClass('form-control form-control-sm');
    _EspecieSemilleroEdit.frm.find("#txtAcCampo").removeClass('form-control form-control-sm border-danger');
    _EspecieSemilleroEdit.frm.find("#txtAcCampo").addClass('form-control form-control-sm');
    _EspecieSemilleroEdit.frm.find("#txtCEsteCampo").removeClass('form-control form-control-sm border-danger');
    _EspecieSemilleroEdit.frm.find("#txtCEsteCampo").addClass('form-control form-control-sm');
    _EspecieSemilleroEdit.frm.find("#txtCNorteCampo").removeClass('form-control form-control-sm border-danger');
    _EspecieSemilleroEdit.frm.find("#txtCNorteCampo").addClass('form-control form-control-sm');
    _EspecieSemilleroEdit.frm.find("#txtCantSobreEst").removeClass('form-control form-control-sm border-danger');
    _EspecieSemilleroEdit.frm.find("#txtCantSobreEst").addClass('form-control form-control-sm');
    _EspecieSemilleroEdit.frm.find("#txtPorcSobreEst").removeClass('form-control form-control-sm border-danger');
    _EspecieSemilleroEdit.frm.find("#txtPorcSobreEst").addClass('form-control form-control-sm');
    _EspecieSemilleroEdit.frm.find("#txtCantSubEst").removeClass('form-control form-control-sm border-danger');
    _EspecieSemilleroEdit.frm.find("#txtCantSubEst").addClass('form-control form-control-sm');
    _EspecieSemilleroEdit.frm.find("#txtPorcSubEst").removeClass('form-control form-control-sm border-danger');
    _EspecieSemilleroEdit.frm.find("#txtPorcSubEst").addClass('form-control form-control-sm');
    _EspecieSemilleroEdit.frm.find(".has-error").removeClass("has-error");
}

jQuery.validator.addMethod("minlenfrmCEste", function (value, element) {
    switch ($(element).attr('id')) {
        case 'txtCEsteCampo':
            return (value.trim().length < 6 || value.trim().length > 6) ? false : true;
            break;
    }
});
jQuery.validator.addMethod("minlenfrmCNorte", function (value, element) {
    switch ($(element).attr('id')) {
        case 'txtCNorteCampo':
            return (value.trim().length < 7 || value.trim().length > 7) ? false : true;
            break;
    }
});