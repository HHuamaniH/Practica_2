"use strict";
var _EspecieMaderableEdit = {};

_EspecieMaderableEdit.fnSaveForm = function (data) { /*implementado desde donde se instancia*/ }

_EspecieMaderableEdit.fnLoadDatos = function (data) {    
    _EspecieMaderableEdit.frm = $("#frmItemEspecieMaderableEdit");
    var regEstado = "1";
    if (data != null && data != "") {
        if (data.data[0]["CODIGO"] != "") {
            regEstado = "0";
        }
        _EspecieMaderableEdit.frm.find("#hdfCodInforme").val(data.data[0]["COD_INFORME"]);
        _EspecieMaderableEdit.frm.find("#hdfRegEstado").val(regEstado);
        _EspecieMaderableEdit.frm.find("#hdfCodSecuencial").val(data.data[0]["COD_SECUENCIAL"]);
        _EspecieMaderableEdit.frm.find("#hdfCodTHabilitante").val(data.data[0]["COD_THABILITANTE"]);
        _EspecieMaderableEdit.frm.find("#hdfNumPoa").val(data.data[0]["NUM_POA"]);
        _EspecieMaderableEdit.frm.find("#hdfNombrePoa").val(data.data[0]["POA"]);
        _EspecieMaderableEdit.frm.find("#hdfCodEspecie").val(data.data[0]["COD_ESPECIES"]);
        _EspecieMaderableEdit.frm.find("#txtEspecie").val(data.data[0]["DESC_ESPECIES"]);
        _EspecieMaderableEdit.frm.find("#ddlCoincideEspecieId").select2("val", [data.data[0]["COINCIDE_ESPECIES"]]);
        _EspecieMaderableEdit.frm.find("#txtBloque").val(data.data[0]["BLOQUE"]);
        _EspecieMaderableEdit.frm.find("#txtBloqueCampo").val(data.data[0]["BLOQUE_CAMPO"]);
        _EspecieMaderableEdit.frm.find("#txtFaja").val(data.data[0]["FAJA"]);
        _EspecieMaderableEdit.frm.find("#txtFajaCampo").val(data.data[0]["FAJA_CAMPO"]);
        _EspecieMaderableEdit.frm.find("#txtCodigo").val(data.data[0]["CODIGO"]);
        _EspecieMaderableEdit.frm.find("#txtCodigoCampo").val(data.data[0]["CODIGO_CAMPO"]);
        _EspecieMaderableEdit.frm.find("#txtDap").val(data.data[0]["DAP"]);
        _EspecieMaderableEdit.frm.find("#txtDapCampo").val(data.data[0]["DAP_CAMPO"]);
        _EspecieMaderableEdit.frm.find("#txtDapCampo1").val(data.data[0]["DAP_CAMPO1"]);
        _EspecieMaderableEdit.frm.find("#txtDapCampo2").val(data.data[0]["DAP_CAMPO2"]);
        _EspecieMaderableEdit.frm.find("#ddlMetodoMedirDapId").select2("val", [data.data[0]["MAE_TIP_MMEDIRDAP"]]);
        _EspecieMaderableEdit.frm.find("#ddlVigencia").select2("val", [data.data[0]["VIGENCIA"] == "" ? "SI" : data.data[0]["VIGENCIA"]]);
        _EspecieMaderableEdit.frm.find("#txtAc").val(data.data[0]["AC"]);
        _EspecieMaderableEdit.frm.find("#txtAcCampo").val(data.data[0]["AC_CAMPO"]);
        _EspecieMaderableEdit.frm.find("#txtZona").val(data.data[0]["ZONA"]);
        _EspecieMaderableEdit.frm.find("#ddlZonaCampoId").select2("val", [data.data[0]["ZONA_CAMPO"] == "000" ? "0000000" : data.data[0]["ZONA_CAMPO"]]);
        _EspecieMaderableEdit.frm.find("#txtCEste").val(data.data[0]["COORDENADA_ESTE"]);
        _EspecieMaderableEdit.frm.find("#txtCEsteCampo").val(data.data[0]["COORDENADA_ESTE_CAMPO"]);
        _EspecieMaderableEdit.frm.find("#txtCNorte").val(data.data[0]["COORDENADA_NORTE"]);
        _EspecieMaderableEdit.frm.find("#txtCNorteCampo").val(data.data[0]["COORDENADA_NORTE_CAMPO"]);
        _EspecieMaderableEdit.frm.find("#txtEstado").val(data.data[0]["DESC_EESTADO"]);
        _EspecieMaderableEdit.frm.find("#ddlEstadoCampoId").select2("val", [data.data[0]["COD_EESTADO"]]);
        _EspecieMaderableEdit.frm.find("#txtCondicion").val(data.data[0]["DESC_ECONDICION"]);
        _EspecieMaderableEdit.frm.find("#ddlCondicionEspCampoId").select2("val", [data.data[0]["COD_ECONDICION_CAMPO"]]);
        _EspecieMaderableEdit.frm.find("#txtCantSobreEst").val(data.data[0]["CANT_SOBRE_ESTIMA_DIAMETRO"]);
        _EspecieMaderableEdit.frm.find("#txtPorcSobreEst").val(data.data[0]["PORC_SOBRE_ESTIMA_DIAMETRO"]);
        _EspecieMaderableEdit.frm.find("#txtCantSubEst").val(data.data[0]["CANT_SUB_ESTIMA_DIAMETRO"]);
        _EspecieMaderableEdit.frm.find("#txtPorcSubEst").val(data.data[0]["PORC_SUB_ESTIMA_DIAMETRO"]);
        _EspecieMaderableEdit.frm.find("#txtVolumen").val(data.data[0]["VOLUMEN"]);
        _EspecieMaderableEdit.frm.find("#txtObservacion").val(data.data[0]["OBSERVACION"]);
        _EspecieMaderableEdit.frm.find("#txtPC").val(data.data[0]["PCA_POA"]);
        _EspecieMaderableEdit.frm.find("#txtParcelaCampo").val(data.data[0]["PCA"]);

        _renderComboEspecie.fnInit("FORESTAL", data.data[0]["COD_ESPECIES_CAMPO"], data.data[0]["DESC_ESPECIES_CAMPO"]);
    }
    Coincidencia();    
}

_EspecieMaderableEdit.fnSetDatos = function () {
    var data = [];
    var metod = _EspecieMaderableEdit.frm.find("#ddlMetodoMedirDapId").val(); 
    if (metod == null) {
        metod = "0000000";
    }
    var regEstado = _EspecieMaderableEdit.frm.find("#hdfRegEstado").val();
    data["RegEstado"] = regEstado == "0" ? "2" : regEstado;
    data["COD_INFORME"] = _EspecieMaderableEdit.frm.find("#hdfCodInforme").val();
    data["COD_SECUENCIAL"] = _EspecieMaderableEdit.frm.find("#hdfCodSecuencial").val();
    data["COD_THABILITANTE"] = _EspecieMaderableEdit.frm.find("#hdfCodTHabilitante").val();
    data["NUM_POA"] = _EspecieMaderableEdit.frm.find("#hdfNumPoa").val();
    data["POA"] = _EspecieMaderableEdit.frm.find("#hdfNombrePoa").val();;
    data["COD_ESPECIES_CAMPO"] = _renderComboEspecie.fnGetCodEspecie();
    data["DESC_ESPECIES_CAMPO"] = _renderComboEspecie.fnGetEspecie();
    data["COD_ESPECIES"] = _EspecieMaderableEdit.frm.find("#hdfCodEspecie").val();
    data["DESC_ESPECIES"] = _EspecieMaderableEdit.frm.find("#txtEspecie").val();
    data["COINCIDE_ESPECIES"] = _EspecieMaderableEdit.frm.find("#ddlCoincideEspecieId").val();
    data["DESC_COINCIDE_ESPECIES"] = _EspecieMaderableEdit.frm.find("#ddlCoincideEspecieId").val() == "-" ? "" : _EspecieMaderableEdit.frm.find("#ddlCoincideEspecieId").select2("data")[0].text;
    data["BLOQUE"] = _EspecieMaderableEdit.frm.find("#txtBloque").val();
    data["BLOQUE_CAMPO"] = _EspecieMaderableEdit.frm.find("#txtBloqueCampo").val();
    data["FAJA"] = _EspecieMaderableEdit.frm.find("#txtFaja").val();
    data["FAJA_CAMPO"] = _EspecieMaderableEdit.frm.find("#txtFajaCampo").val();
    data["CODIGO"] = _EspecieMaderableEdit.frm.find("#txtCodigo").val();
    data["CODIGO_CAMPO"] = _EspecieMaderableEdit.frm.find("#txtCodigoCampo").val();
    data["DAP"] = _EspecieMaderableEdit.frm.find("#txtDap").val();
    data["DAP_CAMPO"] = _EspecieMaderableEdit.frm.find("#txtDapCampo").val();
    data["DAP_CAMPO1"] = _EspecieMaderableEdit.frm.find("#txtDapCampo1").val();
    data["DAP_CAMPO2"] = _EspecieMaderableEdit.frm.find("#txtDapCampo2").val();
    data["MAE_TIP_MMEDIRDAP"] = _EspecieMaderableEdit.frm.find("#ddlMetodoMedirDapId").val();
    data["MMEDIR_DAP"] = metod == "0000000" ? "" : _EspecieMaderableEdit.frm.find("#ddlMetodoMedirDapId").select2("data")[0].text;//_EspecieMaderableEdit.frm.find("#ddlMetodoMedirDapId").val() == "0000000" ? "" : _EspecieMaderableEdit.frm.find("#ddlMetodoMedirDapId").select2("data")[0].text;
    data["VIGENCIA"] = _EspecieMaderableEdit.frm.find("#ddlVigencia").val() == "" ? "SI" : _EspecieMaderableEdit.frm.find("#ddlVigencia").select2("data")[0].text;
    data["AC"]=_EspecieMaderableEdit.frm.find("#txtAc").val();
    data["AC_CAMPO"]=_EspecieMaderableEdit.frm.find("#txtAcCampo").val();
    data["ZONA"]=_EspecieMaderableEdit.frm.find("#txtZona").val();
    data["ZONA_CAMPO"] = _EspecieMaderableEdit.frm.find("#ddlZonaCampoId").val();
    data["COORDENADA_ESTE"] = _EspecieMaderableEdit.frm.find("#txtCEste").val();
    data["COORDENADA_ESTE_CAMPO"] = _EspecieMaderableEdit.frm.find("#txtCEsteCampo").val();
    data["COORDENADA_NORTE"] = _EspecieMaderableEdit.frm.find("#txtCNorte").val();
    data["COORDENADA_NORTE_CAMPO"] = _EspecieMaderableEdit.frm.find("#txtCNorteCampo").val();
    data["DESC_EESTADO"] = _EspecieMaderableEdit.frm.find("#txtEstado").val();
    data["COD_EESTADO"] = _EspecieMaderableEdit.frm.find("#ddlEstadoCampoId").val();
    data["DESC_EESTADO_CAMPO"] = _EspecieMaderableEdit.frm.find("#ddlEstadoCampoId").val() == "0000000" ? "" : _EspecieMaderableEdit.frm.find("#ddlEstadoCampoId").select2("data")[0].text;
    data["DESC_ECONDICION"] = _EspecieMaderableEdit.frm.find("#txtCondicion").val();
    data["COD_ECONDICION_CAMPO"] = _EspecieMaderableEdit.frm.find("#ddlCondicionEspCampoId").val();
    data["DESC_ECONDICION_CAMPO"] = _EspecieMaderableEdit.frm.find("#ddlCondicionEspCampoId").val() == "0000000" ? "" : _EspecieMaderableEdit.frm.find("#ddlCondicionEspCampoId").select2("data")[0].text;
    data["CANT_SOBRE_ESTIMA_DIAMETRO"] = _EspecieMaderableEdit.frm.find("#txtCantSobreEst").val();
    data["PORC_SOBRE_ESTIMA_DIAMETRO"] = _EspecieMaderableEdit.frm.find("#txtPorcSobreEst").val();
    data["CANT_SUB_ESTIMA_DIAMETRO"] = _EspecieMaderableEdit.frm.find("#txtCantSubEst").val();
    data["PORC_SUB_ESTIMA_DIAMETRO"] = _EspecieMaderableEdit.frm.find("#txtPorcSubEst").val();
    data["VOLUMEN"] = _EspecieMaderableEdit.frm.find("#txtVolumen").val();
    data["OBSERVACION"] = _EspecieMaderableEdit.frm.find("#txtObservacion").val();
    data["PCA"] = _EspecieMaderableEdit.frm.find("#txtParcelaCampo").val() == "0000000" ? "" : _EspecieMaderableEdit.frm.find("#txtParcelaCampo").val();

    return data;
}

_EspecieMaderableEdit.fnCustomValidateForm = function () {
    if (_renderComboEspecie.fnGetCodEspecie() == null) {
        utilSigo.toastWarning("Aviso", "Seleccione la especie a registrar"); return false;
    }
    return true;
}

_EspecieMaderableEdit.fnSubmitForm = function () {
    _EspecieMaderableEdit.frm.submit();
}

_EspecieMaderableEdit.fnInit = function (data) {

    _EspecieMaderableEdit.frm = $("#frmItemEspecieMaderableEdit");

    _renderComboEspecie.fnInit("FORESTAL", '', '');

    $.fn.select2.defaults.set("theme", "bootstrap4");
    _EspecieMaderableEdit.frm.find("#ddlCoincideEspecieId").select2({ minimumResultsForSearch: -1 });
    _EspecieMaderableEdit.frm.find("#ddlMetodoMedirDapId").select2();
    _EspecieMaderableEdit.frm.find("#ddlZonaCampoId").select2({ minimumResultsForSearch: -1 });
    _EspecieMaderableEdit.frm.find("#ddlEstadoCampoId").select2();
    _EspecieMaderableEdit.frm.find("#ddlCondicionEspCampoId").select2({ minimumResultsForSearch: -1 });
    _EspecieMaderableEdit.frm.find("#ddlVigencia").select2();
    
    _EspecieMaderableEdit.fnLoadDatos(data);

    //=====-----Para el registro de datos del formulario-----=====
    //Validación personalizada
    jQuery.validator.addMethod("invalidFrmEspecie", function (value, element) {
        switch ($(element).attr('id')) {
            case 'ddlCoincideEspecieId':
            case 'ddlZonaCampoId':
            case 'ddlMetodoMedirDapId':
            case 'ddlEstadoCampoId':
            case 'ddlCondicionEspCampoId':
                return (value == '0000000') ? false : true;
                break
        }
    });
    _EspecieMaderableEdit.frm.validate(utilSigo.fnValidate({
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
            ddlCondicionEspCampoId: { invalidFrmEspecie: true },
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
            ddlCondicionEspCampoId: { invalidFrmEspecie: "Seleccione la condición de la especie campo" },
            txtCantSobreEst: { required: "Ingrese la cantidad sobre estimación de los diámetros" },
            txtPorcSobreEst: { required: "Ingrese el porcentaje sobre estimación de los diámetros" },
            txtCantSubEst: { required: "Ingrese la cantidad sub estimación de los diámetros" },
            txtPorcSubEst: { required: "Ingrese el porcentaje sub estimación de los diámetros" }
        },
        fnSubmit: function (form) {
            if (_EspecieMaderableEdit.fnCustomValidateForm()) {
                var oEspecie = utilSigo.fnConvertArrayToObject(_EspecieMaderableEdit.fnSetDatos());
                var url = urlLocalSigo + "Supervision/ManInforme/GrabarEspecieMaderable";
                var option = { url: url, datos: JSON.stringify(oEspecie), type: 'POST' };
                utilSigo.fnAjax(option, function (data) {
                    if (data.success) {
                        _EspecieMaderableEdit.fnSaveForm(oEspecie);
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
    _EspecieMaderableEdit.frm.find("select.select2-hidden-accessible").on("change", function (e) {
        $(this).valid();
    });

    _EspecieMaderableEdit.frm.find("#ddlRenderComboEspecieId").on("change", function (e) {
        Coincidencia();
    });

    _EspecieMaderableEdit.frm.find("#ddlEstadoCampoId").on("change", function (e) {
        clearValidationErrors();
        var est = _EspecieMaderableEdit.frm.find("#ddlEstadoCampoId").val();

        // VIGENCIA - Movilizado y Tumbado
        if (est == "0000003" || est == "0000010") {
            _EspecieMaderableEdit.frm.find("#ddlVigencia").removeAttr('disabled');
        }
        else {
            _EspecieMaderableEdit.frm.find("#ddlVigencia").val("SI");
            $('#ddlVigencia').select2().trigger('change');
            _EspecieMaderableEdit.frm.find("#ddlVigencia").attr('disabled', 'disabled');
        }

        switch (est) {
            case '0000009': //  No Existe
                //  Solo habilitamos Zona, Coordenadas y Observacion
                _EspecieMaderableEdit.frm.find("#txtDapCampo").rules('remove');
                _EspecieMaderableEdit.frm.find("#txtDapCampo1").rules('remove');
                _EspecieMaderableEdit.frm.find("#txtDapCampo2").rules('remove');
                _EspecieMaderableEdit.frm.find("#txtAcCampo").rules('remove');
                _EspecieMaderableEdit.frm.find("#ddlEstadoCampoId").rules('remove');
                _EspecieMaderableEdit.frm.find("#ddlCondicionEspCampoId").rules('remove');
                _EspecieMaderableEdit.frm.find("#txtCantSobreEst").rules('remove');
                _EspecieMaderableEdit.frm.find("#txtPorcSobreEst").rules('remove');
                _EspecieMaderableEdit.frm.find("#txtCantSubEst").rules('remove');
                _EspecieMaderableEdit.frm.find("#txtPorcSubEst").rules('remove');

                _EspecieMaderableEdit.frm.find("#ddlCoincideEspecieId").attr('disabled', 'disabled');
                _EspecieMaderableEdit.frm.find("#txtBloqueCampo").attr('disabled', 'disabled');
                _EspecieMaderableEdit.frm.find("#txtFajaCampo").attr('disabled', 'disabled');
                //_EspecieMaderableEdit.frm.find("#txtCodigoCampo").attr('disabled', 'disabled');
                _EspecieMaderableEdit.frm.find("#txtDapCampo").attr('disabled', 'disabled');
                _EspecieMaderableEdit.frm.find("#txtDapCampo1").attr('disabled', 'disabled');
                _EspecieMaderableEdit.frm.find("#txtDapCampo2").attr('disabled', 'disabled');
                _EspecieMaderableEdit.frm.find("#ddlMetodoMedirDapId").attr('disabled', 'disabled');
                _EspecieMaderableEdit.frm.find("#txtAcCampo").attr('disabled', 'disabled');
                _EspecieMaderableEdit.frm.find("#ddlCondicionEspCampoId").attr('disabled', 'disabled');
                _EspecieMaderableEdit.frm.find("#txtCantSobreEst").attr('disabled', 'disabled');
                _EspecieMaderableEdit.frm.find("#txtPorcSobreEst").attr('disabled', 'disabled');
                _EspecieMaderableEdit.frm.find("#txtCantSubEst").attr('disabled', 'disabled');
                _EspecieMaderableEdit.frm.find("#txtPorcSubEst").attr('disabled', 'disabled');
                _EspecieMaderableEdit.frm.find("#txtVolumen").attr('disabled', 'disabled');
                _EspecieMaderableEdit.frm.find("#ddlZonaCampoId").removeAttr('disabled');
                _EspecieMaderableEdit.frm.find("#txtCEsteCampo").removeAttr('disabled');
                _EspecieMaderableEdit.frm.find("#txtCNorteCampo").removeAttr('disabled');
                break;
            case '0000011': //  No Evaluado
                //  Solo habilitamos Observacion
                _EspecieMaderableEdit.frm.find("#txtDapCampo").rules('remove');
                _EspecieMaderableEdit.frm.find("#txtDapCampo1").rules('remove');
                _EspecieMaderableEdit.frm.find("#txtDapCampo2").rules('remove');
                _EspecieMaderableEdit.frm.find("#txtAcCampo").rules('remove');
                _EspecieMaderableEdit.frm.find("#ddlEstadoCampoId").rules('remove');
                _EspecieMaderableEdit.frm.find("#ddlCondicionEspCampoId").rules('remove');
                _EspecieMaderableEdit.frm.find("#txtCantSobreEst").rules('remove');
                _EspecieMaderableEdit.frm.find("#txtPorcSobreEst").rules('remove');
                _EspecieMaderableEdit.frm.find("#txtCantSubEst").rules('remove');
                _EspecieMaderableEdit.frm.find("#txtPorcSubEst").rules('remove');
                _EspecieMaderableEdit.frm.find("#ddlZonaCampoId").rules('remove');
                _EspecieMaderableEdit.frm.find("#txtCEsteCampo").rules('remove');
                _EspecieMaderableEdit.frm.find("#txtCNorteCampo").rules('remove');

                _EspecieMaderableEdit.frm.find("#ddlCoincideEspecieId").attr('disabled', 'disabled');
                _EspecieMaderableEdit.frm.find("#txtBloqueCampo").attr('disabled', 'disabled');
                _EspecieMaderableEdit.frm.find("#txtFajaCampo").attr('disabled', 'disabled');
                //_EspecieMaderableEdit.frm.find("#txtCodigoCampo").attr('disabled', 'disabled');
                _EspecieMaderableEdit.frm.find("#txtDapCampo").attr('disabled', 'disabled');
                _EspecieMaderableEdit.frm.find("#txtDapCampo1").attr('disabled', 'disabled');
                _EspecieMaderableEdit.frm.find("#txtDapCampo2").attr('disabled', 'disabled');
                _EspecieMaderableEdit.frm.find("#ddlMetodoMedirDapId").attr('disabled', 'disabled');
                _EspecieMaderableEdit.frm.find("#txtAcCampo").attr('disabled', 'disabled');
                _EspecieMaderableEdit.frm.find("#ddlCondicionEspCampoId").attr('disabled', 'disabled');
                _EspecieMaderableEdit.frm.find("#txtCantSobreEst").attr('disabled', 'disabled');
                _EspecieMaderableEdit.frm.find("#txtPorcSobreEst").attr('disabled', 'disabled');
                _EspecieMaderableEdit.frm.find("#txtCantSubEst").attr('disabled', 'disabled');
                _EspecieMaderableEdit.frm.find("#txtPorcSubEst").attr('disabled', 'disabled');
                _EspecieMaderableEdit.frm.find("#txtVolumen").attr('disabled', 'disabled');
                _EspecieMaderableEdit.frm.find("#ddlZonaCampoId").attr('disabled', 'disabled');
                _EspecieMaderableEdit.frm.find("#txtCEsteCampo").attr('disabled', 'disabled');
                _EspecieMaderableEdit.frm.find("#txtCNorteCampo").attr('disabled', 'disabled');
                break;
            case '0000004': //  En Pie
                _EspecieMaderableEdit.frm.find("#txtDapCampo").rules("add", { required: true, messages: { required: 'Ingrese el DAP campo (cm)' } });
                _EspecieMaderableEdit.frm.find("#txtDapCampo1").rules("add", { required: true, messages: { required: 'Ingrese el DAP campo 1 (cm)' } });
                _EspecieMaderableEdit.frm.find("#txtDapCampo2").rules("add", { required: true, messages: { required: 'Ingrese el DAP campo 2 (cm)' } });
                _EspecieMaderableEdit.frm.find("#txtAcCampo").rules("add", { required: true, messages: { required: "Ingrese el AC campo (m)" } });
                _EspecieMaderableEdit.frm.find("#ddlEstadoCampoId").rules("add", { invalidFrmEspecie: true, messages: { invalidFrmEspecie: "Seleccione el estado de la especie en campo" } });
                _EspecieMaderableEdit.frm.find("#ddlCondicionEspCampoId").rules("add", { invalidFrmEspecie: true, messages: { invalidFrmEspecie: "Seleccione la condición de la especie campo" } });
                _EspecieMaderableEdit.frm.find("#txtCantSobreEst").rules("add", { required: true, messages: { required: "Ingrese la cantidad sobre estimación de los diámetros" } });
                _EspecieMaderableEdit.frm.find("#txtPorcSobreEst").rules("add", { required: true, messages: { required: "Ingrese el porcentaje sobre estimación de los diámetros" } });
                _EspecieMaderableEdit.frm.find("#txtCantSubEst").rules("add", { required: true, messages: { required: "Ingrese la cantidad sub estimación de los diámetros" } });
                _EspecieMaderableEdit.frm.find("#txtPorcSubEst").rules("add", { required: true, messages: { required: "Ingrese el porcentaje sub estimación de los diámetros" } });
                _EspecieMaderableEdit.frm.find("#ddlZonaCampoId").rules("add", { invalidFrmEspecie: true, messages: { invalidFrmEspecie: "Seleccione la zona UTM campo" } });
                _EspecieMaderableEdit.frm.find("#txtCEsteCampo").rules("add", { required: true, messages: { required: "Ingrese la coordenada este campo" } });
                _EspecieMaderableEdit.frm.find("#txtCNorteCampo").rules("add", { required: true, messages: { required: "Ingrese la coordenada norte campo" } });
                _EspecieMaderableEdit.frm.find("#ddlMetodoMedirDapId").rules("add", { invalidFrmEspecie: true, messages: { invalidFrmEspecie: "Seleccione Metodologia" } });

                _EspecieMaderableEdit.frm.find("#ddlMetodoMedirDapId").removeAttr('disabled');
                _EspecieMaderableEdit.frm.find("#ddlCoincideEspecieId").removeAttr('disabled');
                _EspecieMaderableEdit.frm.find("#txtBloqueCampo").removeAttr('disabled');
                _EspecieMaderableEdit.frm.find("#txtFajaCampo").removeAttr('disabled');
                _EspecieMaderableEdit.frm.find("#txtCodigoCampo").removeAttr('disabled');
                _EspecieMaderableEdit.frm.find("#txtDapCampo").removeAttr('disabled');
                _EspecieMaderableEdit.frm.find("#txtDapCampo1").attr('disabled', 'disabled');
                _EspecieMaderableEdit.frm.find("#txtDapCampo2").attr('disabled', 'disabled');
                _EspecieMaderableEdit.frm.find("#ddlMetodoMedirDapId").removeAttr('disabled');
                _EspecieMaderableEdit.frm.find("#txtAcCampo").removeAttr('disabled');
                _EspecieMaderableEdit.frm.find("#ddlCondicionEspCampoId").removeAttr('disabled');
                _EspecieMaderableEdit.frm.find("#txtCantSobreEst").removeAttr('disabled');
                _EspecieMaderableEdit.frm.find("#txtPorcSobreEst").removeAttr('disabled');
                _EspecieMaderableEdit.frm.find("#txtCantSubEst").removeAttr('disabled');
                _EspecieMaderableEdit.frm.find("#txtPorcSubEst").removeAttr('disabled');
                _EspecieMaderableEdit.frm.find("#ddlZonaCampoId").removeAttr('disabled');
                _EspecieMaderableEdit.frm.find("#txtCEsteCampo").removeAttr('disabled');
                _EspecieMaderableEdit.frm.find("#txtCNorteCampo").removeAttr('disabled');
                _EspecieMaderableEdit.frm.find("#txtVolumen").removeAttr('disabled');
                break;
            case '0000010': //  Tumbado
                _EspecieMaderableEdit.frm.find("#txtDapCampo").rules('remove');
                _EspecieMaderableEdit.frm.find("#txtDapCampo1").rules('remove');
                _EspecieMaderableEdit.frm.find("#txtDapCampo2").rules('remove');
                _EspecieMaderableEdit.frm.find("#txtAcCampo").rules("add", { required: true, messages: { required: "Ingrese el AC campo (m)" } });
                _EspecieMaderableEdit.frm.find("#ddlEstadoCampoId").rules("add", { invalidFrmEspecie: true, messages: { invalidFrmEspecie: "Seleccione el estado de la especie en campo" } });
                _EspecieMaderableEdit.frm.find("#ddlCondicionEspCampoId").rules("add", { invalidFrmEspecie: true, messages: { invalidFrmEspecie: "Seleccione la condición de la especie campo" } });
                _EspecieMaderableEdit.frm.find("#txtCantSobreEst").rules("add", { required: true, messages: { required: "Ingrese la cantidad sobre estimación de los diámetros" } });
                _EspecieMaderableEdit.frm.find("#txtPorcSobreEst").rules("add", { required: true, messages: { required: "Ingrese el porcentaje sobre estimación de los diámetros" } });
                _EspecieMaderableEdit.frm.find("#txtCantSubEst").rules("add", { required: true, messages: { required: "Ingrese la cantidad sub estimación de los diámetros" } });
                _EspecieMaderableEdit.frm.find("#txtPorcSubEst").rules("add", { required: true, messages: { required: "Ingrese el porcentaje sub estimación de los diámetros" } });
                _EspecieMaderableEdit.frm.find("#ddlZonaCampoId").rules("add", { invalidFrmEspecie: true, messages: { invalidFrmEspecie: "Seleccione la zona UTM campo" } });
                _EspecieMaderableEdit.frm.find("#txtCEsteCampo").rules("add", { required: true, messages: { required: "Ingrese la coordenada este campo" } });
                _EspecieMaderableEdit.frm.find("#txtCNorteCampo").rules("add", { required: true, messages: { required: "Ingrese la coordenada norte campo" } });
                _EspecieMaderableEdit.frm.find("#ddlMetodoMedirDapId").rules('remove');

                _EspecieMaderableEdit.frm.find("#ddlCoincideEspecieId").removeAttr('disabled');
                _EspecieMaderableEdit.frm.find("#txtBloqueCampo").removeAttr('disabled');
                _EspecieMaderableEdit.frm.find("#txtFajaCampo").removeAttr('disabled');
                _EspecieMaderableEdit.frm.find("#txtCodigoCampo").removeAttr('disabled');
                _EspecieMaderableEdit.frm.find("#txtDapCampo").attr('disabled', 'disabled');
                _EspecieMaderableEdit.frm.find("#txtDapCampo1").removeAttr('disabled');
                _EspecieMaderableEdit.frm.find("#txtDapCampo2").removeAttr('disabled');
                _EspecieMaderableEdit.frm.find("#ddlMetodoMedirDapId").attr('disabled', 'disabled');
                _EspecieMaderableEdit.frm.find("#txtAcCampo").removeAttr('disabled');
                _EspecieMaderableEdit.frm.find("#ddlCondicionEspCampoId").removeAttr('disabled');
                _EspecieMaderableEdit.frm.find("#txtCantSobreEst").removeAttr('disabled');
                _EspecieMaderableEdit.frm.find("#txtPorcSobreEst").removeAttr('disabled');
                _EspecieMaderableEdit.frm.find("#txtCantSubEst").removeAttr('disabled');
                _EspecieMaderableEdit.frm.find("#txtPorcSubEst").removeAttr('disabled');
                _EspecieMaderableEdit.frm.find("#ddlZonaCampoId").removeAttr('disabled');
                _EspecieMaderableEdit.frm.find("#txtCEsteCampo").removeAttr('disabled');
                _EspecieMaderableEdit.frm.find("#txtCNorteCampo").removeAttr('disabled');         
                _EspecieMaderableEdit.frm.find("#txtVolumen").removeAttr('disabled');
                break;
            case '0000002':  // Caido Natural          
                _EspecieMaderableEdit.frm.find("#txtDapCampo").rules('remove');
                _EspecieMaderableEdit.frm.find("#txtDapCampo1").rules('remove');
                _EspecieMaderableEdit.frm.find("#txtDapCampo2").rules('remove');
                _EspecieMaderableEdit.frm.find("#txtAcCampo").rules("add", { required: true, messages: { required: "Ingrese el AC campo (m)" } });
                _EspecieMaderableEdit.frm.find("#ddlEstadoCampoId").rules("add", { invalidFrmEspecie: true, messages: { invalidFrmEspecie: "Seleccione el estado de la especie en campo" } });
                _EspecieMaderableEdit.frm.find("#ddlCondicionEspCampoId").rules("add", { invalidFrmEspecie: true, messages: { invalidFrmEspecie: "Seleccione la condición de la especie campo" } });
                _EspecieMaderableEdit.frm.find("#txtCantSobreEst").rules("add", { required: true, messages: { required: "Ingrese la cantidad sobre estimación de los diámetros" } });
                _EspecieMaderableEdit.frm.find("#txtPorcSobreEst").rules("add", { required: true, messages: { required: "Ingrese el porcentaje sobre estimación de los diámetros" } });
                _EspecieMaderableEdit.frm.find("#txtCantSubEst").rules("add", { required: true, messages: { required: "Ingrese la cantidad sub estimación de los diámetros" } });
                _EspecieMaderableEdit.frm.find("#txtPorcSubEst").rules("add", { required: true, messages: { required: "Ingrese el porcentaje sub estimación de los diámetros" } });
                _EspecieMaderableEdit.frm.find("#ddlZonaCampoId").rules("add", { invalidFrmEspecie: true, messages: { invalidFrmEspecie: "Seleccione la zona UTM campo" } });
                _EspecieMaderableEdit.frm.find("#txtCEsteCampo").rules("add", { required: true, messages: { required: "Ingrese la coordenada este campo" } });
                _EspecieMaderableEdit.frm.find("#txtCNorteCampo").rules("add", { required: true, messages: { required: "Ingrese la coordenada norte campo" } });
                //_EspecieMaderableEdit.frm.find("#ddlMetodoMedirDapId").rules('remove');
                
                _EspecieMaderableEdit.frm.find("#ddlCoincideEspecieId").removeAttr('disabled');
                _EspecieMaderableEdit.frm.find("#txtBloqueCampo").removeAttr('disabled');
                _EspecieMaderableEdit.frm.find("#txtFajaCampo").removeAttr('disabled');
                _EspecieMaderableEdit.frm.find("#txtCodigoCampo").removeAttr('disabled');
                _EspecieMaderableEdit.frm.find("#txtDapCampo").val("");
                _EspecieMaderableEdit.frm.find("#txtDapCampo").attr('disabled', 'disabled');
                //_EspecieMaderableEdit.frm.find("#txtDapCampo").removeAttr('disabled');
                _EspecieMaderableEdit.frm.find("#txtDapCampo1").removeAttr('disabled');
                _EspecieMaderableEdit.frm.find("#txtDapCampo2").removeAttr('disabled');
                _EspecieMaderableEdit.frm.find("#ddlMetodoMedirDapId").val("0000000");
                $('#ddlMetodoMedirDapId').select2().trigger('change');
                _EspecieMaderableEdit.frm.find("#ddlMetodoMedirDapId").attr('disabled', 'disabled');
                //_EspecieMaderableEdit.frm.find("#ddlMetodoMedirDapId").removeAttrattr('disabled', 'disabled');
                _EspecieMaderableEdit.frm.find("#txtAcCampo").removeAttr('disabled');
                _EspecieMaderableEdit.frm.find("#ddlCondicionEspCampoId").removeAttr('disabled');
                _EspecieMaderableEdit.frm.find("#txtCantSobreEst").removeAttr('disabled');
                _EspecieMaderableEdit.frm.find("#txtPorcSobreEst").removeAttr('disabled');
                _EspecieMaderableEdit.frm.find("#txtCantSubEst").removeAttr('disabled');
                _EspecieMaderableEdit.frm.find("#txtPorcSubEst").removeAttr('disabled');
                _EspecieMaderableEdit.frm.find("#ddlZonaCampoId").removeAttr('disabled');
                _EspecieMaderableEdit.frm.find("#txtCEsteCampo").removeAttr('disabled');
                _EspecieMaderableEdit.frm.find("#txtCNorteCampo").removeAttr('disabled');
                _EspecieMaderableEdit.frm.find("#txtVolumen").removeAttr('disabled');
                break;
            default:
                /*_EspecieMaderableEdit.frm.find("#txtDapCampo").rules("add", { required: true, messages: { required: 'Ingrese el DAP campo (cm)' } });*/
                _EspecieMaderableEdit.frm.find("#txtDapCampo").rules('remove');
                _EspecieMaderableEdit.frm.find("#txtDapCampo1").rules('remove');
                _EspecieMaderableEdit.frm.find("#txtDapCampo2").rules('remove');
                _EspecieMaderableEdit.frm.find("#txtAcCampo").rules("add", { required: true, messages: { required: "Ingrese el AC campo (m)" } });
                _EspecieMaderableEdit.frm.find("#ddlEstadoCampoId").rules("add", { invalidFrmEspecie: true, messages: { invalidFrmEspecie: "Seleccione el estado de la especie en campo" } });
                _EspecieMaderableEdit.frm.find("#ddlCondicionEspCampoId").rules("add", { invalidFrmEspecie: true, messages: { invalidFrmEspecie: "Seleccione la condición de la especie campo" } });
                _EspecieMaderableEdit.frm.find("#txtCantSobreEst").rules("add", { required: true, messages: { required: "Ingrese la cantidad sobre estimación de los diámetros" } });
                _EspecieMaderableEdit.frm.find("#txtPorcSobreEst").rules("add", { required: true, messages: { required: "Ingrese el porcentaje sobre estimación de los diámetros" } });
                _EspecieMaderableEdit.frm.find("#txtCantSubEst").rules("add", { required: true, messages: { required: "Ingrese la cantidad sub estimación de los diámetros" } });
                _EspecieMaderableEdit.frm.find("#txtPorcSubEst").rules("add", { required: true, messages: { required: "Ingrese el porcentaje sub estimación de los diámetros" } });
                _EspecieMaderableEdit.frm.find("#ddlZonaCampoId").rules("add", { invalidFrmEspecie: true, messages: { invalidFrmEspecie: "Seleccione la zona UTM campo" } });
                _EspecieMaderableEdit.frm.find("#txtCEsteCampo").rules("add", { required: true, messages: { required: "Ingrese la coordenada este campo" } });
                _EspecieMaderableEdit.frm.find("#txtCNorteCampo").rules("add", { required: true, messages: { required: "Ingrese la coordenada norte campo" } });
                _EspecieMaderableEdit.frm.find("#ddlMetodoMedirDapId").rules('remove');
                
                _EspecieMaderableEdit.frm.find("#ddlCoincideEspecieId").removeAttr('disabled');
                _EspecieMaderableEdit.frm.find("#txtBloqueCampo").removeAttr('disabled');
                _EspecieMaderableEdit.frm.find("#txtFajaCampo").removeAttr('disabled');
                _EspecieMaderableEdit.frm.find("#txtCodigoCampo").removeAttr('disabled');
                _EspecieMaderableEdit.frm.find("#txtDapCampo").attr('disabled', 'disabled');
                _EspecieMaderableEdit.frm.find("#txtDapCampo1").removeAttr('disabled');
                _EspecieMaderableEdit.frm.find("#txtDapCampo2").removeAttr('disabled');
                _EspecieMaderableEdit.frm.find("#ddlMetodoMedirDapId").attr('disabled', 'disabled');
                _EspecieMaderableEdit.frm.find("#txtAcCampo").removeAttr('disabled');
                _EspecieMaderableEdit.frm.find("#ddlCondicionEspCampoId").removeAttr('disabled');
                _EspecieMaderableEdit.frm.find("#txtCantSobreEst").removeAttr('disabled');
                _EspecieMaderableEdit.frm.find("#txtPorcSobreEst").removeAttr('disabled');
                _EspecieMaderableEdit.frm.find("#txtCantSubEst").removeAttr('disabled');
                _EspecieMaderableEdit.frm.find("#txtPorcSubEst").removeAttr('disabled');
                _EspecieMaderableEdit.frm.find("#ddlZonaCampoId").removeAttr('disabled');
                _EspecieMaderableEdit.frm.find("#txtCEsteCampo").removeAttr('disabled');
                _EspecieMaderableEdit.frm.find("#txtCNorteCampo").removeAttr('disabled');
                _EspecieMaderableEdit.frm.find("#txtVolumen").removeAttr('disabled');
        }

    });

}

_EspecieMaderableEdit.fnSearch = function () {
    var codInforme = $("#hdfCodInforme").val();
    var codTHabilitante = $("#hdfCodTHabilitante").val();
    var numPoa = _EspecieMaderableEdit.frm.find("#hdfNumPoa").val();
    var bloque = $("#txtBloqueB").val();
    var faja = $("#txtFajaB").val();
    var codigo = $("#txtCodigoB").val();
    var pca = _EspecieMaderableEdit.frm.find("#txtPCEM").val();
    var codSecuencial = 0; 
    $("#txtBloque").val(bloque);
    $("#txtFaja").val(faja);
    $("#txtCodigo").val(codigo);    
    var url = urlLocalSigo + "Supervision/ManInforme/GetDatosMaderable";
    var option = {
        url: url,
        datos: JSON.stringify({
            asCodInforme: codInforme,
            asCodTHabilitante: codTHabilitante,
            asNumPoa: numPoa,
            asBloque: bloque,
            asFaja: faja,
            asCodigo: codigo,
            asCodSecuencial: codSecuencial,
            asPCA: pca
        }),
        type: 'POST'
    };

    utilSigo.fnAjax(option, function (data) {
        if (data.success) {
            if (data.data.length == 1) {
                Limpiar();
                _EspecieMaderableEdit.fnLoadDatos(data);
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
                        var bloque = data.data[i].BLOQUE.trim();
                        var faja = data.data[i].FAJA.trim();
                        var este = data.data[i].COORDENADA_ESTE;
                        var norte = data.data[i].COORDENADA_NORTE;
                        var codSec = data.data[i].COD_SECUENCIAL;
                        var pca = data.data[i].PCA;
                        var arg = bloque + "'#'" + faja + "'#'" + codSec;
                        var aviso = pri + bloque + seg + faja + '\u00A0y\u00A0Coordenadas:\u00A0' + este + ',' + norte;
                        var miCadena = arg.replace(/["']/g, "");
                        mensaje += "<a href='#' onclick='AbrirOpciones(\"" + miCadena + "\");' data-dismiss='modal'>" + aviso + "</a>" + "<br/>";                      
                        //mensaje += "<a href='#' onclick=AbrirOpciones(\'" + bloque + "'#'" + faja + "'#'" + codSec + "\'');' data-dismiss='modal'>" + aviso + "</a>" + "<br/>";
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

_EspecieMaderableEdit.fnSearchR = function (bloque, faja, codigo, codSecuencial) {
    var codInforme = $("#hdfCodInforme").val();
    var codTHabilitante = $("#hdfCodTHabilitante").val();
    var numPoa = _EspecieMaderableEdit.frm.find("#hdfNumPoa").val();
    $("#txtBloque").val(bloque);
    $("#txtFaja").val(faja);
    $("#txtCodigo").val(codigo);

    var url = urlLocalSigo + "Supervision/ManInforme/GetDatosMaderable";
    var option = {
        url: url,
        datos: JSON.stringify({
            asCodInforme: codInforme,
            asCodTHabilitante: codTHabilitante,
            asNumPoa: numPoa,
            asBloque: bloque,
            asFaja: faja,
            asCodigo: codigo,
            asCodSecuencial: codSecuencial
        }),
        type: 'POST'
    };

    utilSigo.fnAjax(option, function (data) {
        if (data.success) {
            if (data.data.length == 1) {
                Limpiar();
                _EspecieMaderableEdit.fnLoadDatos(data);
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
                        var arg = bloque + "'#'" + faja + "'#'" + codSec;
                        var aviso = pri + bloque + seg + faja + '\u00A0y\u00A0Coordenadas:\u00A0' + este + ',' + norte;
                        var miCadena = arg.replace(/["']/g, "");
                        mensaje += "<a href='#' onclick='AbrirOpciones(\"" + miCadena + "\");' data-dismiss='modal'>" + aviso + "</a>" + "<br/>";
                        //mensaje += "<a href='#' onclick=AbrirOpciones('"+bloque+"#"+faja+"#"+codSec+"'); data-dismiss='modal'>" + aviso + "</a>" + "<br/>";
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
    _EspecieMaderableEdit.frm.find("#hdfCodSecuencial").val(c);
    $("#hdfCodSecuencial").val(c);
    var cod = $("#txtCodigoB").val();
    Limpiar();
    _EspecieMaderableEdit.fnSearchR(a, b, cod, c);

}

function Limpiar() {
    var sel = document.getElementById("ddlRenderComboEspecieId");
    sel.remove(sel.selectedIndex);

    _EspecieMaderableEdit.frm = $("#frmItemEspecieMaderableEdit");
    var regEstado = "1"; // Nuevo

    _EspecieMaderableEdit.frm.find("#txtPCEMS").val("0000000");
    _EspecieMaderableEdit.frm.find("#hdfRegEstado").val(regEstado);
    _EspecieMaderableEdit.frm.find("#hdfCodSecuencial").val("");
    _EspecieMaderableEdit.frm.find("#hdfCodEspecie").val("");
    _EspecieMaderableEdit.frm.find("#txtEspecie").val("");    
    _EspecieMaderableEdit.frm.find("#txtBloqueB").val("");
    _EspecieMaderableEdit.frm.find("#txtFajaB").val("");
    _EspecieMaderableEdit.frm.find("#txtCodigoB").val("");
    $("#ddlCoincideEspecieId").val("-");
    $('#ddlCoincideEspecieId').select2().trigger('change');
    _EspecieMaderableEdit.frm.find("#txtBloque").val("");
    _EspecieMaderableEdit.frm.find("#txtBloqueCampo").val("");
    _EspecieMaderableEdit.frm.find("#txtFaja").val("");
    _EspecieMaderableEdit.frm.find("#txtFajaCampo").val("");
    _EspecieMaderableEdit.frm.find("#txtCodigo").val("");
    _EspecieMaderableEdit.frm.find("#txtCodigoCampo").val("");
    _EspecieMaderableEdit.frm.find("#txtDap").val("");
    _EspecieMaderableEdit.frm.find("#txtDapCampo").val("");
    _EspecieMaderableEdit.frm.find("#txtDapCampo1").val("");
    _EspecieMaderableEdit.frm.find("#txtDapCampo2").val("");
    _EspecieMaderableEdit.frm.find("#ddlMetodoMedirDapId").val("0000000");
    $('#ddlMetodoMedirDapId').select2().trigger('change');
    _EspecieMaderableEdit.frm.find("#ddlVigencia").val("SI");
    $('#ddlVigencia').select2().trigger('change');
    _EspecieMaderableEdit.frm.find("#txtAc").val("");
    _EspecieMaderableEdit.frm.find("#txtAcCampo").val("");
    _EspecieMaderableEdit.frm.find("#txtZona").val("");
    _EspecieMaderableEdit.frm.find("#ddlZonaCampoId").val("0000000");
    $('#ddlZonaCampoId').select2().trigger('change');
    _EspecieMaderableEdit.frm.find("#txtCEste").val("");
    _EspecieMaderableEdit.frm.find("#txtCEsteCampo").val("");
    _EspecieMaderableEdit.frm.find("#txtCNorte").val("");
    _EspecieMaderableEdit.frm.find("#txtCNorteCampo").val("");
    _EspecieMaderableEdit.frm.find("#txtEstado").val("");
    _EspecieMaderableEdit.frm.find("#ddlEstadoCampoId").val("0000000");
    $('#ddlEstadoCampoId').select2().trigger('change');
    _EspecieMaderableEdit.frm.find("#txtCondicion").val("");
    _EspecieMaderableEdit.frm.find("#ddlCondicionEspCampoId").val("0000000");
    $('#ddlCondicionEspCampoId').select2().trigger('change');
    _EspecieMaderableEdit.frm.find("#txtCantSobreEst").val("");
    _EspecieMaderableEdit.frm.find("#txtPorcSobreEst").val("");
    _EspecieMaderableEdit.frm.find("#txtCantSubEst").val("");
    _EspecieMaderableEdit.frm.find("#txtPorcSubEst").val("");
    _EspecieMaderableEdit.frm.find("#txtVolumen").val("");
    _EspecieMaderableEdit.frm.find("#txtObservacion").val("");
    _renderComboEspecie.fnInit("FORESTAL", '', '');

}

function Coincidencia() {
    var a = _renderComboEspecie.fnGetEspecie();
    var b = _EspecieMaderableEdit.frm.find("#txtEspecie").val();
    if (a != "") {
        if (a == b) {
            $('#ddlCoincideEspecieId').val("SI");
        }
        else {
            //_EspecieMaderableEdit.frm.find("#ddlCoincideEspecieId").select2("val", 'NO');
            $('#ddlCoincideEspecieId').val("NO");
        }
        $('#ddlCoincideEspecieId').select2().trigger('change');
    }    
}

function clearValidationErrors() {
    $("#txtDapCampo").removeClass('form-control form-control-sm border-danger');
    $("#txtDapCampo").addClass('form-control form-control-sm');
    $("#txtDapCampo1").removeClass('form-control form-control-sm border-danger');
    $("#txtDapCampo1").addClass('form-control form-control-sm');
    $("#txtDapCampo2").removeClass('form-control form-control-sm border-danger');
    $("#txtDapCampo2").addClass('form-control form-control-sm');
    $("#txtAcCampo").removeClass('form-control form-control-sm border-danger');
    $("#txtAcCampo").addClass('form-control form-control-sm');
    $("#txtCEsteCampo").removeClass('form-control form-control-sm border-danger');
    $("#txtCEsteCampo").addClass('form-control form-control-sm');
    $("#txtCNorteCampo").removeClass('form-control form-control-sm border-danger');
    $("#txtCNorteCampo").addClass('form-control form-control-sm');    
    $("#txtCantSobreEst").removeClass('form-control form-control-sm border-danger');
    $("#txtCantSobreEst").addClass('form-control form-control-sm');
    $("#txtPorcSobreEst").removeClass('form-control form-control-sm border-danger');
    $("#txtPorcSobreEst").addClass('form-control form-control-sm');
    $("#txtCantSubEst").removeClass('form-control form-control-sm border-danger');
    $("#txtCantSubEst").addClass('form-control form-control-sm');
    $("#txtPorcSubEst").removeClass('form-control form-control-sm border-danger');
    $("#txtPorcSubEst").addClass('form-control form-control-sm');
    $("#ddlZonaCampoId").removeClass('select-css error border-danger'); 
    $("#ddlZonaCampoId").addClass('select-css');
    $(".has-error").removeClass("has-error");
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