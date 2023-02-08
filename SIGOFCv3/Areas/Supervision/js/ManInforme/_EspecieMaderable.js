"use strict";
var _EspecieMaderable = {};

_EspecieMaderable.fnSaveForm = function (data) { /*implementado desde donde se instancia*/ }

_EspecieMaderable.fnLoadDatos = function (data) {
    if (data != null && data != "") {

        _EspecieMaderable.frm.find("#hdfRegEstado").val(data["RegEstado"]);
        _EspecieMaderable.frm.find("#hdfCodSecuencial").val(data["COD_SECUENCIAL"]);
        _EspecieMaderable.frm.find("#hdfCodTHabilitante").val(data["COD_THABILITANTE"]);
        _EspecieMaderable.frm.find("#hdfNumPoa").val(data["NUM_POA"]);
        _EspecieMaderable.frm.find("#hdfNombrePoa").val(data["POA"]);
        _EspecieMaderable.frm.find("#hdfCodEspecie").val(data["COD_ESPECIES"]);
        _EspecieMaderable.frm.find("#txtEspecie").val(data["DESC_ESPECIES"]);
        _EspecieMaderable.frm.find("#ddlCoincideEspecieId").select2("val", [data["COINCIDE_ESPECIES"]]);
        _EspecieMaderable.frm.find("#txtBloque").val(data["BLOQUE"]);
        _EspecieMaderable.frm.find("#txtBloqueCampo").val(data["BLOQUE_CAMPO"]);
        _EspecieMaderable.frm.find("#txtFaja").val(data["FAJA"]);
        _EspecieMaderable.frm.find("#txtFajaCampo").val(data["FAJA_CAMPO"]);
        _EspecieMaderable.frm.find("#txtCodigo").val(data["CODIGO"]);
        _EspecieMaderable.frm.find("#txtCodigoCampo").val(data["CODIGO_CAMPO"]);
        _EspecieMaderable.frm.find("#txtDap").val(data["DAP"]);
        _EspecieMaderable.frm.find("#txtDapCampo").val(data["DAP_CAMPO"]);
        _EspecieMaderable.frm.find("#txtDapCampo1").val(data["DAP_CAMPO1"]);
        _EspecieMaderable.frm.find("#txtDapCampo2").val(data["DAP_CAMPO2"]);
        _EspecieMaderable.frm.find("#ddlMetodoMedirDapId").select2("val", [data["MAE_TIP_MMEDIRDAP"]]);
        _EspecieMaderable.frm.find("#txtAc").val(data["AC"]);
        _EspecieMaderable.frm.find("#txtAcCampo").val(data["AC_CAMPO"]);
        _EspecieMaderable.frm.find("#txtZona").val(data["ZONA"]);
        _EspecieMaderable.frm.find("#ddlZonaCampoId").select2("val", [data["ZONA_CAMPO"] == "000" ? "0000000" : data["ZONA_CAMPO"]]);
        _EspecieMaderable.frm.find("#txtCEste").val(data["COORDENADA_ESTE"]);
        _EspecieMaderable.frm.find("#txtCEsteCampo").val(data["COORDENADA_ESTE_CAMPO"]);
        _EspecieMaderable.frm.find("#txtCNorte").val(data["COORDENADA_NORTE"]);
        _EspecieMaderable.frm.find("#txtCNorteCampo").val(data["COORDENADA_NORTE_CAMPO"]);
        _EspecieMaderable.frm.find("#txtEstado").val(data["DESC_EESTADO"]);
        _EspecieMaderable.frm.find("#ddlEstadoCampoId").select2("val", [data["COD_EESTADO"]]);
        _EspecieMaderable.frm.find("#txtCondicion").val(data["DESC_ECONDICION"]);
        _EspecieMaderable.frm.find("#ddlCondicionEspCampoId").select2("val", [data["COD_ECONDICION_CAMPO"]]);
        _EspecieMaderable.frm.find("#txtCantSobreEst").val(data["CANT_SOBRE_ESTIMA_DIAMETRO"]);
        _EspecieMaderable.frm.find("#txtPorcSobreEst").val(data["PORC_SOBRE_ESTIMA_DIAMETRO"]);
        _EspecieMaderable.frm.find("#txtCantSubEst").val(data["CANT_SUB_ESTIMA_DIAMETRO"]);
        _EspecieMaderable.frm.find("#txtPorcSubEst").val(data["PORC_SUB_ESTIMA_DIAMETRO"]);
        _EspecieMaderable.frm.find("#txtObservacion").val(data["OBSERVACION"]);
        _EspecieMaderable.frm.find("#txtParcelaCenso").val(data["PCA"]);
        _EspecieMaderable.frm.find("#txtParcelaCPOA").val(data["PCA_POA"]);

        _renderComboEspecie.fnInit("FORESTAL", data["COD_ESPECIES_CAMPO"], data["DESC_ESPECIES_CAMPO"]);
    }
}

_EspecieMaderable.fnSetDatos = function () {
    var data = [];
    var regEstado = _EspecieMaderable.frm.find("#hdfRegEstado").val();
    data["RegEstado"] = regEstado == "0" ? "2" : regEstado;
    data["COD_INFORME"] = _EspecieMaderable.frm.find("#hdfCodInforme").val();
    data["COD_SECUENCIAL"] = _EspecieMaderable.frm.find("#hdfCodSecuencial").val();
    data["COD_THABILITANTE"] = _EspecieMaderable.frm.find("#hdfCodTHabilitante").val();
    data["NUM_POA"] = _EspecieMaderable.frm.find("#hdfNumPoa").val();
    data["POA"] = _EspecieMaderable.frm.find("#hdfNombrePoa").val();;
    data["COD_ESPECIES_CAMPO"] = _renderComboEspecie.fnGetCodEspecie();
    data["DESC_ESPECIES_CAMPO"] = _renderComboEspecie.fnGetEspecie();
    data["COD_ESPECIES"] = _EspecieMaderable.frm.find("#hdfCodEspecie").val();
    data["DESC_ESPECIES"] = _EspecieMaderable.frm.find("#txtEspecie").val();
    data["COINCIDE_ESPECIES"] = _EspecieMaderable.frm.find("#ddlCoincideEspecieId").val();
    data["DESC_COINCIDE_ESPECIES"] = _EspecieMaderable.frm.find("#ddlCoincideEspecieId").val() == "-" ? "" : _EspecieMaderable.frm.find("#ddlCoincideEspecieId").select2("data")[0].text;
    data["BLOQUE"] = _EspecieMaderable.frm.find("#txtBloque").val();
    data["BLOQUE_CAMPO"] = _EspecieMaderable.frm.find("#txtBloqueCampo").val();
    data["FAJA"] = _EspecieMaderable.frm.find("#txtFaja").val();
    data["FAJA_CAMPO"] = _EspecieMaderable.frm.find("#txtFajaCampo").val();
    data["CODIGO"] = _EspecieMaderable.frm.find("#txtCodigo").val();
    data["CODIGO_CAMPO"] = _EspecieMaderable.frm.find("#txtCodigoCampo").val();
    data["DAP"] = _EspecieMaderable.frm.find("#txtDap").val();
    data["DAP_CAMPO"] = _EspecieMaderable.frm.find("#txtDapCampo").val();
    data["DAP_CAMPO1"] = _EspecieMaderable.frm.find("#txtDapCampo1").val();
    data["DAP_CAMPO2"] = _EspecieMaderable.frm.find("#txtDapCampo2").val();
    data["MAE_TIP_MMEDIRDAP"] = _EspecieMaderable.frm.find("#ddlMetodoMedirDapId").val();
    data["MMEDIR_DAP"] = _EspecieMaderable.frm.find("#ddlMetodoMedirDapId").val() == "0000000" ? "" : _EspecieMaderable.frm.find("#ddlMetodoMedirDapId").select2("data")[0].text;
    data["AC"] = _EspecieMaderable.frm.find("#txtAc").val();
    data["AC_CAMPO"] = _EspecieMaderable.frm.find("#txtAcCampo").val();
    data["ZONA"] = _EspecieMaderable.frm.find("#txtZona").val();
    data["ZONA_CAMPO"] = _EspecieMaderable.frm.find("#ddlZonaCampoId").val();
    data["COORDENADA_ESTE"] = _EspecieMaderable.frm.find("#txtCEste").val();
    data["COORDENADA_ESTE_CAMPO"] = _EspecieMaderable.frm.find("#txtCEsteCampo").val();
    data["COORDENADA_NORTE"] = _EspecieMaderable.frm.find("#txtCNorte").val();
    data["COORDENADA_NORTE_CAMPO"] = _EspecieMaderable.frm.find("#txtCNorteCampo").val();
    data["DESC_EESTADO"] = _EspecieMaderable.frm.find("#txtEstado").val();
    data["COD_EESTADO"] = _EspecieMaderable.frm.find("#ddlEstadoCampoId").val();
    data["DESC_EESTADO_CAMPO"] = _EspecieMaderable.frm.find("#ddlEstadoCampoId").val() == "0000000" ? "" : _EspecieMaderable.frm.find("#ddlEstadoCampoId").select2("data")[0].text;
    data["DESC_ECONDICION"] = _EspecieMaderable.frm.find("#txtCondicion").val();
    data["COD_ECONDICION_CAMPO"] = _EspecieMaderable.frm.find("#ddlCondicionEspCampoId").val();
    data["DESC_ECONDICION_CAMPO"] = _EspecieMaderable.frm.find("#ddlCondicionEspCampoId").val() == "0000000" ? "" : _EspecieMaderable.frm.find("#ddlCondicionEspCampoId").select2("data")[0].text;
    data["CANT_SOBRE_ESTIMA_DIAMETRO"] = _EspecieMaderable.frm.find("#txtCantSobreEst").val();
    data["PORC_SOBRE_ESTIMA_DIAMETRO"] = _EspecieMaderable.frm.find("#txtPorcSobreEst").val();
    data["CANT_SUB_ESTIMA_DIAMETRO"] = _EspecieMaderable.frm.find("#txtCantSubEst").val();
    data["PORC_SUB_ESTIMA_DIAMETRO"] = _EspecieMaderable.frm.find("#txtPorcSubEst").val();
    data["OBSERVACION"] = _EspecieMaderable.frm.find("#txtObservacion").val();
    data["PCA"] = _EspecieMaderable.frm.find("#txtParcelaCenso").val() == "0000000" ? "" : _EspecieMaderable.frm.find("#txtParcelaCenso").val();
    data["PCA_POA"] = _EspecieMaderable.frm.find("#txtParcelaCPOA").val();
    return data;
}

_EspecieMaderable.fnCustomValidateForm = function () {
    if (_renderComboEspecie.fnGetCodEspecie() == null) {
        utilSigo.toastWarning("Aviso", "Seleccione la especie a registrar"); return false;
    }
    if (_EspecieMaderable.frm.find("#ddlMetodoMedirDapId").val() == null) {
        utilSigo.toastWarning("Aviso", "Seleccione la metodologia a registrar"); return false;
    }
    return true;
}

_EspecieMaderable.fnSubmitForm = function () {
    _EspecieMaderable.frm.submit();
}

_EspecieMaderable.fnInit = function (data) {
    _EspecieMaderable.frm = $("#frmItemEspecieMaderable");

    $.fn.select2.defaults.set("theme", "bootstrap4");
    _EspecieMaderable.frm.find("#ddlCoincideEspecieId").select2({ minimumResultsForSearch: -1 });
    _EspecieMaderable.frm.find("#ddlMetodoMedirDapId").select2({ minimumResultsForSearch: -1 });
    _EspecieMaderable.frm.find("#ddlZonaCampoId").select2({ minimumResultsForSearch: -1 });
    _EspecieMaderable.frm.find("#ddlEstadoCampoId").select2();
    _EspecieMaderable.frm.find("#ddlCondicionEspCampoId").select2({ minimumResultsForSearch: -1 });

    _EspecieMaderable.fnLoadDatos(data);

    //=====-----Para el registro de datos del formulario-----=====
    //Validación personalizada
    jQuery.validator.addMethod("invalidFrmEspecie", function (value, element) {
        switch ($(element).attr('id')) {
            case 'ddlCoincideEspecieId':
            case 'ddlZonaCampoId':
            case 'ddlEstadoCampoId':
            case 'ddlCondicionEspCampoId':
                return (value == '0000000') ? false : true;
                break
        }
    });
    _EspecieMaderable.frm.validate(utilSigo.fnValidate({
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
            ddlCondicionEspCampoId: { invalidFrmEspecie: true },
            txtCantSobreEst: { required: true },
            txtPorcSobreEst: { required: true },
            txtCantSubEst: { required: true },
            txtPorcSubEst: { required: true },
            ddlRenderComboEspecieId: { required: true }
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
            ddlCondicionEspCampoId: { invalidFrmEspecie: "Seleccione la condición de la especie campo" },
            txtCantSobreEst: { required: "Ingrese la cantidad sobre estimación de los diámetros" },
            txtPorcSobreEst: { required: "Ingrese el porcentaje sobre estimación de los diámetros" },
            txtCantSubEst: { required: "Ingrese la cantidad sub estimación de los diámetros" },
            txtPorcSubEst: { required: "Ingrese el porcentaje sub estimación de los diámetros" },
            ddlRenderComboEspecieId: { requiered: "Seleccione especie" }
        },
        fnSubmit: function (form) {
            var codEspecie = _renderComboEspecie.fnGetCodEspecie();
            if (codEspecie.trim() != "") {
                if (_EspecieMaderable.fnCustomValidateForm()) {
                    var oEspecie = utilSigo.fnConvertArrayToObject(_EspecieMaderable.fnSetDatos());
                    var url = urlLocalSigo + "Supervision/ManInforme/GrabarEspecieMaderable";
                    var option = { url: url, datos: JSON.stringify(oEspecie), type: 'POST' };
                    utilSigo.fnAjax(option, function (data) {
                        if (data.success) {
                            _EspecieMaderable.fnSaveForm(oEspecie);
                        }
                        else {
                            utilSigo.toastWarning("Aviso", data.msj);
                        }
                    });
                }
            } else {
                utilSigo.toastWarning("Aviso", "Seleccione la especie a registrar");
            }
        }
    }));
    //Validación de controles que usan Select2
    _EspecieMaderable.frm.find("select.select2-hidden-accessible").on("change", function (e) {
        $(this).valid();
    });
}