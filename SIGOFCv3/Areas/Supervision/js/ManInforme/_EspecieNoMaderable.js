"use strict";
var _EspecieNoMaderable = {};

_EspecieNoMaderable.fnSaveForm = function (data) { /*implementado desde donde se instancia*/ }

_EspecieNoMaderable.fnLoadDatos = function (data) {
    if (data != null && data != "") {
        _EspecieNoMaderable.frm.find("#hdfRegEstado").val(data["RegEstado"]);
        _EspecieNoMaderable.frm.find("#hdfCodSecuencial").val(data["COD_SECUENCIAL"]);
        _EspecieNoMaderable.frm.find("#hdfCodTHabilitante").val(data["COD_THABILITANTE"]);
        _EspecieNoMaderable.frm.find("#hdfNumPoa").val(data["NUM_POA"]);
        _EspecieNoMaderable.frm.find("#hdfNombrePoa").val(data["POA"]);
        _EspecieNoMaderable.frm.find("#hdfCodEspecie").val(data["COD_ESPECIES"]);
        _EspecieNoMaderable.frm.find("#txtEspecie").val(data["DESC_ESPECIES"]);
        _EspecieNoMaderable.frm.find("#txtEstrada").val(data["NUM_ESTRADA"]);
        _EspecieNoMaderable.frm.find("#txtEstradaCampo").val(data["NUM_ESTRADA_CAMPO"]);
        _EspecieNoMaderable.frm.find("#txtCodigo").val(data["CODIGO"]);
        _EspecieNoMaderable.frm.find("#txtCodigoCampo").val(data["CODIGO_CAMPO"]);
        //_EspecieNoMaderable.frm.find("#txtDiametro").val(data["DIAMETRO"]);
        //_EspecieNoMaderable.frm.find("#txtDiametroCampo").val(data["DIAMETRO_CAMPO"]);
        //_EspecieNoMaderable.frm.find("#txtAltura").val(data["ALTURA"]);
        //_EspecieNoMaderable.frm.find("#txtAlturaCampo").val(data["ALTURA_CAMPO"]);
        _EspecieNoMaderable.frm.find("#ddlEstadoCampoId").select2("val", [data["COD_EESTADO"]]);
        //_EspecieNoMaderable.frm.find("#txtProdLata").val(data["PRODUCCION_LATAS"]);
        //_EspecieNoMaderable.frm.find("#txtProdLataCampo").val(data["PRODUCCION_LATAS_CAMPO"]);
        _EspecieNoMaderable.frm.find("#txtZona").val(data["ZONA"]);
        _EspecieNoMaderable.frm.find("#ddlZonaCampoId").select2("val", [data["ZONA_CAMPO"] == "000" ? "0000000" : data["ZONA_CAMPO"]]);
        _EspecieNoMaderable.frm.find("#txtCEste").val(data["COORDENADA_ESTE"]);
        _EspecieNoMaderable.frm.find("#txtCEsteCampo").val(data["COORDENADA_ESTE_CAMPO"]);
        _EspecieNoMaderable.frm.find("#txtCNorte").val(data["COORDENADA_NORTE"]);
        _EspecieNoMaderable.frm.find("#txtCNorteCampo").val(data["COORDENADA_NORTE_CAMPO"]);
        //_EspecieNoMaderable.frm.find("#txtCocoAbierto").val(data["NUM_COCOS_ABIERTOS"]);
        //_EspecieNoMaderable.frm.find("#txtCocoCerrado").val(data["NUM_COCOS_CERRADOS"]);
        //_EspecieNoMaderable.frm.find("#ddlCFusteId").select2("val", [data["COD_CFUSTE"]]);
        //_EspecieNoMaderable.frm.find("#ddlPCopaId").select2("val", [data["COD_PCOPA"]]);
        //_EspecieNoMaderable.frm.find("#ddlFCopaId").select2("val", [data["COD_FCOPA"]]);
        //_EspecieNoMaderable.frm.find("#ddlFenologiaId").select2("val", [data["COD_EFENOLOGICO"]]);
        _EspecieNoMaderable.frm.find("#ddlEstadoFitoId").select2("val", [data["COD_ESANITARIO"]]);
        _EspecieNoMaderable.frm.find("#ddlGradoInfestId").select2("val", [data["COD_ILIANAS"]]);
        _EspecieNoMaderable.frm.find("#ddlCondicionId").select2("val", [data["COD_ECONDICION_CAMPO"]]);
        _EspecieNoMaderable.frm.find("#txtObservacion").val(data["OBSERVACION"]);
        _renderComboEspecie.fnInit("FORESTAL", data["COD_ESPECIES_CAMPO"], data["DESC_ESPECIES_CAMPO"]);
    }
}

_EspecieNoMaderable.fnSetDatos = function () {
    var data = [];
    var regEstado = _EspecieNoMaderable.frm.find("#hdfRegEstado").val();
    data["RegEstado"] = regEstado == "0" ? "2" : regEstado;
    data["COD_INFORME"] = _EspecieNoMaderable.frm.find("#hdfCodInforme").val();
    data["COD_SECUENCIAL"] = _EspecieNoMaderable.frm.find("#hdfCodSecuencial").val();
    data["COD_THABILITANTE"] = _EspecieNoMaderable.frm.find("#hdfCodTHabilitante").val();
    data["NUM_POA"] = _EspecieNoMaderable.frm.find("#hdfNumPoa").val();
    data["POA"] = _EspecieNoMaderable.frm.find("#hdfNombrePoa").val();;
    data["COD_ESPECIES_CAMPO"] = _renderComboEspecie.fnGetCodEspecie();
    data["DESC_ESPECIES_CAMPO"] = _renderComboEspecie.fnGetEspecie();
    data["COD_ESPECIES"] = _EspecieNoMaderable.frm.find("#hdfCodEspecie").val();
    data["DESC_ESPECIES"] = _EspecieNoMaderable.frm.find("#txtEspecie").val();
    data["NUM_ESTRADA"]=_EspecieNoMaderable.frm.find("#txtEstrada").val();
    data["NUM_ESTRADA_CAMPO"]=_EspecieNoMaderable.frm.find("#txtEstradaCampo").val();
    data["CODIGO"] = _EspecieNoMaderable.frm.find("#txtCodigo").val();
    data["CODIGO_CAMPO"] = _EspecieNoMaderable.frm.find("#txtCodigoCampo").val();
    //data["DIAMETRO"]=_EspecieNoMaderable.frm.find("#txtDiametro").val();
    //data["DIAMETRO_CAMPO"]=_EspecieNoMaderable.frm.find("#txtDiametroCampo").val();
    //data["ALTURA"]=_EspecieNoMaderable.frm.find("#txtAltura").val();
    //data["ALTURA_CAMPO"] = _EspecieNoMaderable.frm.find("#txtAlturaCampo").val();
    data["COD_EESTADO"] = _EspecieNoMaderable.frm.find("#ddlEstadoCampoId").val();
    data["DESC_EESTADO_CAMPO"] = _EspecieNoMaderable.frm.find("#ddlEstadoCampoId").val() == "0000000" ? "" : _EspecieNoMaderable.frm.find("#ddlEstadoCampoId").select2("data")[0].text;
    //data["PRODUCCION_LATAS"]=_EspecieNoMaderable.frm.find("#txtProdLata").val();
    //data["PRODUCCION_LATAS_CAMPO"]=_EspecieNoMaderable.frm.find("#txtProdLataCampo").val();
    data["ZONA"] = _EspecieNoMaderable.frm.find("#txtZona").val();
    data["ZONA_CAMPO"] = _EspecieNoMaderable.frm.find("#ddlZonaCampoId").val();
    data["COORDENADA_ESTE"] = _EspecieNoMaderable.frm.find("#txtCEste").val();
    data["COORDENADA_ESTE_CAMPO"] = _EspecieNoMaderable.frm.find("#txtCEsteCampo").val();
    data["COORDENADA_NORTE"] = _EspecieNoMaderable.frm.find("#txtCNorte").val();
    data["COORDENADA_NORTE_CAMPO"] = _EspecieNoMaderable.frm.find("#txtCNorteCampo").val();
    //data["NUM_COCOS_ABIERTOS"]=_EspecieNoMaderable.frm.find("#txtCocoAbierto").val();
    //data["NUM_COCOS_CERRADOS"]=_EspecieNoMaderable.frm.find("#txtCocoCerrado").val();
    //data["COD_CFUSTE"] = _EspecieNoMaderable.frm.find("#ddlCFusteId").val();
    //data["DESC_CFUSTE"] = _EspecieNoMaderable.frm.find("#ddlCFusteId").select2("data")[0].text;
    //data["COD_PCOPA"] = _EspecieNoMaderable.frm.find("#ddlPCopaId").val();
    //data["DESC_PCOPA"] = _EspecieNoMaderable.frm.find("#ddlPCopaId").select2("data")[0].text;
    //data["COD_FCOPA"] = _EspecieNoMaderable.frm.find("#ddlFCopaId").val();
    //data["DESC_FCOPA"] = _EspecieNoMaderable.frm.find("#ddlFCopaId").select2("data")[0].text;
    //data["COD_EFENOLOGICO"] = _EspecieNoMaderable.frm.find("#ddlFenologiaId").val();
    //data["DESC_EFENOLOGICO"] = _EspecieNoMaderable.frm.find("#ddlFenologiaId").select2("data")[0].text;
    data["COD_ESANITARIO"] = _EspecieNoMaderable.frm.find("#ddlEstadoFitoId").val();
    data["DESC_ESANITARIO"] = _EspecieNoMaderable.frm.find("#ddlEstadoFitoId").select2("data")[0].text;
    data["COD_ILIANAS"] = _EspecieNoMaderable.frm.find("#ddlGradoInfestId").val();
    data["DESC_ILIANAS"] = _EspecieNoMaderable.frm.find("#ddlGradoInfestId").select2("data")[0].text;
    data["COD_ECONDICION_CAMPO"] = _EspecieNoMaderable.frm.find("#ddlCondicionId").val();
    data["DESC_ECONDICION_CAMPO"] = _EspecieNoMaderable.frm.find("#ddlCondicionId").select2("data")[0].text;
    data["OBSERVACION"] = _EspecieNoMaderable.frm.find("#txtObservacion").val();
    return data;
}

_EspecieNoMaderable.fnCustomValidateForm = function () {
    if (_renderComboEspecie.fnGetCodEspecie() == null) {
        utilSigo.toastWarning("Aviso", "Seleccione la especie a registrar"); return false;
    }
    return true;
}

_EspecieNoMaderable.fnSubmitForm = function () {
    _EspecieNoMaderable.frm.submit();
}

_EspecieNoMaderable.fnInit = function (data) {
    _EspecieNoMaderable.frm = $("#frmItemEspecieNoMaderable");

    $.fn.select2.defaults.set("theme", "bootstrap4");
    _EspecieNoMaderable.frm.find("#ddlZonaCampoId").select2({ minimumResultsForSearch: -1 });
    _EspecieNoMaderable.frm.find("#ddlEstadoCampoId").select2();
    //_EspecieNoMaderable.frm.find("#ddlFenologiaId").select2({ minimumResultsForSearch: -1 });
    //_EspecieNoMaderable.frm.find("#ddlCFusteId").select2({ minimumResultsForSearch: -1 });
    //_EspecieNoMaderable.frm.find("#ddlFCopaId").select2({ minimumResultsForSearch: -1 });
    //_EspecieNoMaderable.frm.find("#ddlPCopaId").select2({ minimumResultsForSearch: -1 });
    _EspecieNoMaderable.frm.find("#ddlEstadoFitoId").select2({ minimumResultsForSearch: -1 });
    _EspecieNoMaderable.frm.find("#ddlGradoInfestId").select2({ minimumResultsForSearch: -1 });
    _EspecieNoMaderable.frm.find("#ddlCondicionId").select2({ minimumResultsForSearch: -1 });
    _EspecieNoMaderable.fnLoadDatos(data);

    //=====-----Para el registro de datos del formulario-----=====
    //Validación personalizada
    jQuery.validator.addMethod("invalidFrmEspecie", function (value, element) {
        switch ($(element).attr('id')) {
            case 'ddlZonaCampoId':
            case 'ddlEstadoCampoId':
                return (value == '0000000') ? false : true;
                break
        }
    });
    _EspecieNoMaderable.frm.validate(utilSigo.fnValidate({
        rules: {
            //txtDiametroCampo: { required: true },
            //txtAlturaCampo: { required: true },
            //txtProdLataCampo: { required: true },
            ddlZonaCampoId: { invalidFrmEspecie: true },
            txtCEsteCampo: { required: true },
            txtCNorteCampo: { required: true },
            ddlEstadoCampoId: { invalidFrmEspecie: true }
            //txtCocoAbierto: { required: true },
            //txtCocoCerrado: { required: true }
        },
        messages: {
            //txtDiametroCampo: { required: "Ingrese el diámetro campo (cm)" },
            //txtAlturaCampo: { required: "Ingrese la altura campo (m)" },
            //txtProdLataCampo: { required: "Ingrese la producción latas campo 2 (cm)" },
            ddlZonaCampoId: { invalidFrmEspecie: "Seleccione la zona UTM campo" },
            txtCEsteCampo: { required: "Ingrese la coordenada este campo" },
            txtCNorteCampo: { required: "Ingrese la coordenada norte campo" },
            ddlEstadoCampoId: { invalidFrmEspecie: "Seleccione el estado de la especie en campo" }
            //txtCocoAbierto: { required: "Ingrese los cocos abiertos" },
            //txtCocoCerrado: { required: "Ingrese los cocos cerrados" }
        },
        fnSubmit: function (form) {
            if (_EspecieNoMaderable.fnCustomValidateForm()) {
                var oEspecie = utilSigo.fnConvertArrayToObject(_EspecieNoMaderable.fnSetDatos());
                var url = urlLocalSigo + "Supervision/ManInforme/GrabarEspecieNoMaderable";
                var option = { url: url, datos: JSON.stringify(oEspecie), type: 'POST' };
                utilSigo.fnAjax(option, function (data) {
                    if (data.success) {
                        _EspecieNoMaderable.fnSaveForm(oEspecie);
                    }
                    else {
                        utilSigo.toastWarning("Aviso", data.msj);
                    }
                });
            }
        }
    }));
    //Validación de controles que usan Select2
    _EspecieNoMaderable.frm.find("select.select2-hidden-accessible").on("change", function (e) {
        $(this).valid();
    });
}