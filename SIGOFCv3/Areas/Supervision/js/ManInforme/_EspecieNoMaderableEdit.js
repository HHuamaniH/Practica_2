"use strict";
var _EspecieNoMaderableEdit = {};

_EspecieNoMaderableEdit.fnSaveForm = function (data) { /*implementado desde donde se instancia*/ }

_EspecieNoMaderableEdit.fnLoadDatos = function (data) {
    var regEstado = "1";
    if (data != null && data != "") {
        if (data.data[0]["CODIGO"] != "") {
            regEstado = "0";
        }
        _EspecieNoMaderableEdit.frm.find("#hdfRegEstado").val(regEstado);
        _EspecieNoMaderableEdit.frm.find("#hdfCodSecuencial").val(data.data[0]["COD_SECUENCIAL"]);
        _EspecieNoMaderableEdit.frm.find("#hdfCodTHabilitante").val(data.data[0]["COD_THABILITANTE"]);
        _EspecieNoMaderableEdit.frm.find("#hdfNumPoa").val(data.data[0]["NUM_POA"]);
        _EspecieNoMaderableEdit.frm.find("#hdfNombrePoa").val(data.data[0]["POA"]);
        _EspecieNoMaderableEdit.frm.find("#hdfCodEspecie").val(data.data[0]["COD_ESPECIES"]);
        _EspecieNoMaderableEdit.frm.find("#txtEspecie").val(data.data[0]["DESC_ESPECIES"]);
        _EspecieNoMaderableEdit.frm.find("#txtEstrada").val(data.data[0]["NUM_ESTRADA"]);
        _EspecieNoMaderableEdit.frm.find("#txtEstradaCampo").val(data.data[0]["NUM_ESTRADA_CAMPO"]);
        _EspecieNoMaderableEdit.frm.find("#txtCodigo").val(data.data[0]["CODIGO"]);
        _EspecieNoMaderableEdit.frm.find("#txtCodigoCampo").val(data.data[0]["CODIGO_CAMPO"]);
        //_EspecieNoMaderableEdit.frm.find("#txtDiametro").val(data.data[0]["DIAMETRO"]);
        //_EspecieNoMaderableEdit.frm.find("#txtDiametroCampo").val(data.data[0]["DIAMETRO_CAMPO"]);
        //_EspecieNoMaderableEdit.frm.find("#txtAltura").val(data.data[0]["ALTURA"]);
        //_EspecieNoMaderableEdit.frm.find("#txtAlturaCampo").val(data.data[0]["ALTURA_CAMPO"]);
        _EspecieNoMaderableEdit.frm.find("#ddlEstadoCampoId").val(data.data[0]["COD_EESTADO"]);
        //_EspecieNoMaderableEdit.frm.find("#txtProdLata").val(data.data[0]["PRODUCCION_LATAS"]);
        //_EspecieNoMaderableEdit.frm.find("#txtProdLataCampo").val(data.data[0]["PRODUCCION_LATAS_CAMPO"]);
        _EspecieNoMaderableEdit.frm.find("#txtZona").val(data.data[0]["ZONA"]);
        _EspecieNoMaderableEdit.frm.find("#ddlZonaCampoId").val(data.data[0]["ZONA_CAMPO"] == "000" ? "0000000" : data.data[0]["ZONA_CAMPO"]);
        _EspecieNoMaderableEdit.frm.find("#txtCEste").val(data.data[0]["COORDENADA_ESTE"]);
        _EspecieNoMaderableEdit.frm.find("#txtCEsteCampo").val(data.data[0]["COORDENADA_ESTE_CAMPO"]);
        _EspecieNoMaderableEdit.frm.find("#txtCNorte").val(data.data[0]["COORDENADA_NORTE"]);
        _EspecieNoMaderableEdit.frm.find("#txtCNorteCampo").val(data.data[0]["COORDENADA_NORTE_CAMPO"]);
        //_EspecieNoMaderableEdit.frm.find("#txtCocoAbierto").val(data.data[0]["NUM_COCOS_ABIERTOS"]);
        //_EspecieNoMaderableEdit.frm.find("#txtCocoCerrado").val(data.data[0]["NUM_COCOS_CERRADOS"]);
        //_EspecieNoMaderableEdit.frm.find("#ddlCFusteId").val(data.data[0]["COD_CFUSTE"]);
        //_EspecieNoMaderableEdit.frm.find("#ddlPCopaId").val(data.data[0]["COD_PCOPA"]);
        //_EspecieNoMaderableEdit.frm.find("#ddlFCopaId").val(data.data[0]["COD_FCOPA"]);
        //_EspecieNoMaderableEdit.frm.find("#ddlFenologiaId").val(data.data[0]["COD_EFENOLOGICO"]);
        _EspecieNoMaderableEdit.frm.find("#ddlEstadoFitoId").val(data.data[0]["COD_ESANITARIO"]);
        _EspecieNoMaderableEdit.frm.find("#ddlGradoInfestId").val(data.data[0]["COD_ILIANAS"]);
        _EspecieNoMaderableEdit.frm.find("#ddlCondicionId").val(data.data[0]["COD_ECONDICION"]);
        _EspecieNoMaderableEdit.frm.find("#txtObservacion").val(data.data[0]["OBSERVACION"]);
        _renderComboEspecie.fnInit("FORESTAL", data.data[0]["COD_ESPECIES_CAMPO"], data.data[0]["DESC_ESPECIES_CAMPO"]);
    }
}

_EspecieNoMaderableEdit.fnSetDatos = function () {
    var data = [];
    var regEstado = _EspecieNoMaderableEdit.frm.find("#hdfRegEstado").val();
    data["RegEstado"] = regEstado == "0" ? "2" : regEstado;
    data["COD_INFORME"] = _EspecieNoMaderableEdit.frm.find("#hdfCodInforme").val();
    data["COD_SECUENCIAL"] = _EspecieNoMaderableEdit.frm.find("#hdfCodSecuencial").val();
    data["COD_THABILITANTE"] = _EspecieNoMaderableEdit.frm.find("#hdfCodTHabilitante").val();
    data["NUM_POA"] = _EspecieNoMaderableEdit.frm.find("#hdfNumPoa").val();
    data["POA"] = _EspecieNoMaderableEdit.frm.find("#hdfNombrePoa").val();;
    data["COD_ESPECIES_CAMPO"] = _renderComboEspecie.fnGetCodEspecie();
    data["DESC_ESPECIES_CAMPO"] = _renderComboEspecie.fnGetEspecie();
    data["COD_ESPECIES"] = _EspecieNoMaderableEdit.frm.find("#hdfCodEspecie").val();
    data["DESC_ESPECIES"] = _EspecieNoMaderableEdit.frm.find("#txtEspecie").val();
    data["NUM_ESTRADA"]=_EspecieNoMaderableEdit.frm.find("#txtEstrada").val();
    data["NUM_ESTRADA_CAMPO"]=_EspecieNoMaderableEdit.frm.find("#txtEstradaCampo").val();
    data["CODIGO"] = _EspecieNoMaderableEdit.frm.find("#txtCodigo").val();
    data["CODIGO_CAMPO"] = _EspecieNoMaderableEdit.frm.find("#txtCodigoCampo").val();
    //data["DIAMETRO"]=_EspecieNoMaderableEdit.frm.find("#txtDiametro").val();
    //data["DIAMETRO_CAMPO"]=_EspecieNoMaderableEdit.frm.find("#txtDiametroCampo").val();
    //data["ALTURA"]=_EspecieNoMaderableEdit.frm.find("#txtAltura").val();
    //data["ALTURA_CAMPO"] = _EspecieNoMaderableEdit.frm.find("#txtAlturaCampo").val();
    data["COD_EESTADO"] = _EspecieNoMaderableEdit.frm.find("#ddlEstadoCampoId").val();
    data["DESC_EESTADO_CAMPO"] = _EspecieNoMaderableEdit.frm.find("#ddlEstadoCampoId").val() == "0000000" ? "" : _EspecieNoMaderableEdit.frm.find("#ddlEstadoCampoId").val();
    //data["PRODUCCION_LATAS"]=_EspecieNoMaderableEdit.frm.find("#txtProdLata").val();
    //data["PRODUCCION_LATAS_CAMPO"]=_EspecieNoMaderableEdit.frm.find("#txtProdLataCampo").val();
    data["ZONA"] = _EspecieNoMaderableEdit.frm.find("#txtZona").val();
    data["ZONA_CAMPO"] = _EspecieNoMaderableEdit.frm.find("#ddlZonaCampoId").val();
    data["COORDENADA_ESTE"] = _EspecieNoMaderableEdit.frm.find("#txtCEste").val();
    data["COORDENADA_ESTE_CAMPO"] = _EspecieNoMaderableEdit.frm.find("#txtCEsteCampo").val();
    data["COORDENADA_NORTE"] = _EspecieNoMaderableEdit.frm.find("#txtCNorte").val();
    data["COORDENADA_NORTE_CAMPO"] = _EspecieNoMaderableEdit.frm.find("#txtCNorteCampo").val();
    //data["NUM_COCOS_ABIERTOS"]=_EspecieNoMaderableEdit.frm.find("#txtCocoAbierto").val();
    //data["NUM_COCOS_CERRADOS"]=_EspecieNoMaderableEdit.frm.find("#txtCocoCerrado").val();
    //data["COD_CFUSTE"] = _EspecieNoMaderableEdit.frm.find("#ddlCFusteId").val();
    //data["DESC_CFUSTE"] = _EspecieNoMaderableEdit.frm.find("#ddlCFusteId").val();
    //data["COD_PCOPA"] = _EspecieNoMaderableEdit.frm.find("#ddlPCopaId").val();
    //data["DESC_PCOPA"] = _EspecieNoMaderableEdit.frm.find("#ddlPCopaId").val();
    //data["COD_FCOPA"] = _EspecieNoMaderableEdit.frm.find("#ddlFCopaId").val();
    //data["DESC_FCOPA"] = _EspecieNoMaderableEdit.frm.find("#ddlFCopaId").val();
    //data["COD_EFENOLOGICO"] = _EspecieNoMaderableEdit.frm.find("#ddlFenologiaId").val();
    //data["DESC_EFENOLOGICO"] = _EspecieNoMaderableEdit.frm.find("#ddlFenologiaId").val();
    data["COD_ESANITARIO"] = _EspecieNoMaderableEdit.frm.find("#ddlEstadoFitoId").val();
    data["DESC_ESANITARIO"] = _EspecieNoMaderableEdit.frm.find("#ddlEstadoFitoId").val();
    data["COD_ILIANAS"] = _EspecieNoMaderableEdit.frm.find("#ddlGradoInfestId").val();
    data["DESC_ILIANAS"] = _EspecieNoMaderableEdit.frm.find("#ddlGradoInfestId").val();
    data["COD_ECONDICION_CAMPO"] = _EspecieNoMaderableEdit.frm.find("#ddlCondicionId").val();
    data["DESC_ECONDICION_CAMPO"] = _EspecieNoMaderableEdit.frm.find("#ddlCondicionId").val();
    data["OBSERVACION"] = _EspecieNoMaderableEdit.frm.find("#txtObservacion").val();
    return data;
}

_EspecieNoMaderableEdit.fnCustomValidateForm = function () {
    if (_renderComboEspecie.fnGetCodEspecie() == null) {
        utilSigo.toastWarning("Aviso", "Seleccione la especie a registrar"); return false;
    }

    return true;
}

_EspecieNoMaderableEdit.fnSubmitForm = function () {
    _EspecieNoMaderableEdit.frm.submit();
}

_EspecieNoMaderableEdit.fnInit = function (data) {
  
    _EspecieNoMaderableEdit.frm = $("#frmItemEspecieNoMaderableEdit");
    _renderComboEspecie.fnInit("FORESTAL", '', '');

    $.fn.select2.defaults.set("theme", "bootstrap4");
    _EspecieNoMaderableEdit.frm.find("#ddlZonaCampoId").select2({ minimumResultsForSearch: -1 });
    _EspecieNoMaderableEdit.frm.find("#ddlEstadoCampoId").select2();
    //_EspecieNoMaderableEdit.frm.find("#ddlFenologiaId").select2({ minimumResultsForSearch: -1 });
    //_EspecieNoMaderableEdit.frm.find("#ddlCFusteId").select2({ minimumResultsForSearch: -1 });
    //_EspecieNoMaderableEdit.frm.find("#ddlFCopaId").select2({ minimumResultsForSearch: -1 });
    //_EspecieNoMaderableEdit.frm.find("#ddlPCopaId").select2({ minimumResultsForSearch: -1 });
    _EspecieNoMaderableEdit.frm.find("#ddlEstadoFitoId").select2({ minimumResultsForSearch: -1 });
    _EspecieNoMaderableEdit.frm.find("#ddlGradoInfestId").select2({ minimumResultsForSearch: -1 });
    _EspecieNoMaderableEdit.frm.find("#ddlCondicionId").select2({ minimumResultsForSearch: -1 });

    _EspecieNoMaderableEdit.fnLoadDatos(data);

    //=====-----Para el registro de datos del formulario-----=====
    //Validación personalizada
    jQuery.validator.addMethod("invalidFrmEspecie", function (value, element) {
        switch ($(element).attr('id')) {
            case 'ddlZonaCampoId':
            case 'ddlEstadoCampoId':
            case 'ddlEstadoFitoId':
            case 'ddlGradoInfestId':
                return (value == '0000000') ? false : true;
                break
            case 'ddlCondicionId':
                return (value == '0000017') ? false : true;
                break
        }
    });

    _EspecieNoMaderableEdit.frm.validate(utilSigo.fnValidate({
        rules: {
            //txtDiametroCampo: { required: true },
            //txtAlturaCampo: { required: true },
            //txtProdLataCampo: { required: true },
            ddlZonaCampoId: { invalidFrmEspecie: true },
            txtCEsteCampo: { required: true, minlenfrmCEste: true  },
            txtCNorteCampo: { required: true, minlenfrmCNorte: true },
            ddlEstadoCampoId: { invalidFrmEspecie: true },
            ddlEstadoFitoId: { invalidFrmEspecie: true },
            ddlGradoInfestId: { invalidFrmEspecie: true },
            ddlCondicionId: { invalidFrmEspecie: true }
            //txtCocoAbierto: { required: true },
            //txtCocoCerrado: { required: true }
        },
        messages: {
            //txtDiametroCampo: { required: "Ingrese el diámetro campo (cm)" },
            //txtAlturaCampo: { required: "Ingrese la altura campo (m)" },
            //txtProdLataCampo: { required: "Ingrese la producción latas campo 2 (cm)" },
            ddlZonaCampoId: { invalidFrmEspecie: "Seleccione la zona UTM campo" },
            txtCEsteCampo: { required: "Ingrese la coordenada este campo", minlenfrmCEste: "Ingrese una coordenada de 6 digitos" },
            txtCNorteCampo: { required: "Ingrese la coordenada norte campo", minlenfrmCNorte: "Ingrese una coordenada de 7 digitos" },
            ddlEstadoCampoId: { invalidFrmEspecie: "Seleccione el estado de la especie en campo" },
            ddlEstadoFitoId: { invalidFrmEspecie: "Seleccione el estado fitosanitario" },
            ddlGradoInfestId: { invalidFrmEspecie: "Seleccione el grado de infestacion de lianas" },
            ddlCondicionId: { invalidFrmEspecie: "Seleccione la condicion" }
            //txtCocoAbierto: { required: "Ingrese los cocos abiertos" },
            //txtCocoCerrado: { required: "Ingrese los cocos cerrados" }
        },
        fnSubmit: function (form) {
            if (_EspecieNoMaderableEdit.fnCustomValidateForm()) {
                var oEspecie = utilSigo.fnConvertArrayToObject(_EspecieNoMaderableEdit.fnSetDatos());
                var url = urlLocalSigo + "Supervision/ManInforme/GrabarEspecieNoMaderable";
                var option = { url: url, datos: JSON.stringify(oEspecie), type: 'POST' };
                utilSigo.fnAjax(option, function (data) {
                    if (data.success) {
                        _EspecieNoMaderableEdit.fnSaveForm(oEspecie);
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
    _EspecieNoMaderableEdit.frm.find("select.select2-hidden-accessible").on("change", function (e) {
        $(this).valid();
    });

    _EspecieNoMaderableEdit.frm.find("#ddlEstadoCampoId").on("change", function (e) {
        clearValidationErrors();
        var est = _EspecieNoMaderableEdit.frm.find("#ddlEstadoCampoId").val();
        if (est == "0000009") {
            //  Solo habilitamos Zona, Coordenadas y Observacion
            _EspecieNoMaderableEdit.frm.find("#txtEstradaCampo").rules('remove');
            _EspecieNoMaderableEdit.frm.find("#txtCodigoCampo").rules('remove')
            //_EspecieNoMaderableEdit.frm.find("#txtDiametroCampo").rules('remove');
            //_EspecieNoMaderableEdit.frm.find("#txtAlturaCampo").rules('remove');
           // _EspecieNoMaderableEdit.frm.find("#txtProdLataCampo").rules('remove');
            //_EspecieNoMaderableEdit.frm.find("#txtCocoAbierto").rules('remove');
            //_EspecieNoMaderableEdit.frm.find("#txtCocoCerrado").rules('remove');


            //_EspecieNoMaderableEdit.frm.find("#ddlRenderComboEspecieId").attr('disabled', 'disabled');            
            _EspecieNoMaderableEdit.frm.find("#txtEstradaCampo").attr('disabled', 'disabled');
            _EspecieNoMaderableEdit.frm.find("#txtCodigoCampo").attr('disabled', 'disabled');
            //_EspecieNoMaderableEdit.frm.find("#txtDiametroCampo").attr('disabled', 'disabled');
            //_EspecieNoMaderableEdit.frm.find("#txtAlturaCampo").attr('disabled', 'disabled');
            //_EspecieNoMaderableEdit.frm.find("#txtProdLataCampo").attr('disabled', 'disabled');
            //_EspecieNoMaderableEdit.frm.find("#txtCocoAbierto").attr('disabled', 'disabled');
            //_EspecieNoMaderableEdit.frm.find("#txtCocoCerrado").attr('disabled', 'disabled');
            //_EspecieNoMaderableEdit.frm.find("#ddlCFusteId").attr('disabled', 'disabled');
            //_EspecieNoMaderableEdit.frm.find("#txtCantSobreEst").attr('disabled', 'disabled');
            //_EspecieNoMaderableEdit.frm.find("#txtPorcSobreEst").attr('disabled', 'disabled');
            //_EspecieNoMaderableEdit.frm.find("#txtCantSubEst").attr('disabled', 'disabled');
           // _EspecieNoMaderableEdit.frm.find("#txtPorcSubEst").attr('disabled', 'disabled');
            //_EspecieNoMaderableEdit.frm.find("#ddlFenologiaId").attr('disabled', 'disabled');
            //_EspecieNoMaderableEdit.frm.find("#ddlCFusteId").attr('disabled', 'disabled');
            //_EspecieNoMaderableEdit.frm.find("#ddlPCopaId").attr('disabled', 'disabled');
            //_EspecieNoMaderableEdit.frm.find("#ddlFCopaId").attr('disabled', 'disabled');
            _EspecieNoMaderableEdit.frm.find("#ddlEstadoFitoId").attr('disabled', 'disabled');
            _EspecieNoMaderableEdit.frm.find("#ddlGradoInfestId").attr('disabled', 'disabled');
            _EspecieNoMaderableEdit.frm.find("#ddlCondicionId").attr('disabled', 'disabled');
            _EspecieNoMaderableEdit.frm.find("#ddlZonaCampoId").removeAttr('disabled');
            _EspecieNoMaderableEdit.frm.find("#txtCEsteCampo").removeAttr('disabled');
            _EspecieNoMaderableEdit.frm.find("#txtCNorteCampo").removeAttr('disabled');
        }
        else {
            if (est == "0000011") {
                //Solo habilitamos Observacion
                _EspecieNoMaderableEdit.frm.find("#txtEstradaCampo").rules('remove');
                _EspecieNoMaderableEdit.frm.find("#txtCodigoCampo").rules('remove');
                //_EspecieNoMaderableEdit.frm.find("#txtDiametroCampo").rules('remove');
                //_EspecieNoMaderableEdit.frm.find("#txtAlturaCampo").rules('remove');
                //_EspecieNoMaderableEdit.frm.find("#txtProdLataCampo").rules('remove');
                //_EspecieNoMaderableEdit.frm.find("#txtCocoAbierto").rules('remove');
                //_EspecieNoMaderableEdit.frm.find("#txtCocoCerrado").rules('remove');
                _EspecieNoMaderableEdit.frm.find("#ddlZonaCampoId").rules('remove');
                _EspecieNoMaderableEdit.frm.find("#txtCEsteCampo").rules('remove');
                _EspecieNoMaderableEdit.frm.find("#txtCNorteCampo").rules('remove');


                //_EspecieNoMaderableEdit.frm.find("#ddlRenderComboEspecieId").attr('disabled', 'disabled');
                _EspecieNoMaderableEdit.frm.find("#txtEstradaCampo").attr('disabled', 'disabled');
                _EspecieNoMaderableEdit.frm.find("#txtCodigoCampo").attr('disabled', 'disabled');
                _EspecieNoMaderableEdit.frm.find("#txtDiametroCampo").attr('disabled', 'disabled');
                //_EspecieNoMaderableEdit.frm.find("#txtAlturaCampo").attr('disabled', 'disabled');
                //_EspecieNoMaderableEdit.frm.find("#txtProdLataCampo").attr('disabled', 'disabled');
                //_EspecieNoMaderableEdit.frm.find("#txtCocoAbierto").attr('disabled', 'disabled');
                //_EspecieNoMaderableEdit.frm.find("#txtCocoCerrado").attr('disabled', 'disabled');
                //_EspecieNoMaderableEdit.frm.find("#ddlCFusteId").attr('disabled', 'disabled');
                //_EspecieNoMaderableEdit.frm.find("#txtCantSobreEst").attr('disabled', 'disabled');
                //_EspecieNoMaderableEdit.frm.find("#txtPorcSobreEst").attr('disabled', 'disabled');
                //_EspecieNoMaderableEdit.frm.find("#txtCantSubEst").attr('disabled', 'disabled');
                //_EspecieNoMaderableEdit.frm.find("#txtPorcSubEst").attr('disabled', 'disabled');
                //_EspecieNoMaderableEdit.frm.find("#ddlFenologiaId").attr('disabled', 'disabled');
                //_EspecieNoMaderableEdit.frm.find("#ddlCFusteId").attr('disabled', 'disabled');
                //_EspecieNoMaderableEdit.frm.find("#ddlPCopaId").attr('disabled', 'disabled');
                //_EspecieNoMaderableEdit.frm.find("#ddlFCopaId").attr('disabled', 'disabled');
                _EspecieNoMaderableEdit.frm.find("#ddlEstadoFitoId").attr('disabled', 'disabled');
                _EspecieNoMaderableEdit.frm.find("#ddlGradoInfestId").attr('disabled', 'disabled');
                _EspecieNoMaderableEdit.frm.find("#ddlCondicionId").attr('disabled', 'disabled');
                _EspecieNoMaderableEdit.frm.find("#ddlZonaCampoId").attr('disabled', 'disabled');
                _EspecieNoMaderableEdit.frm.find("#txtCEsteCampo").attr('disabled', 'disabled');
                _EspecieNoMaderableEdit.frm.find("#txtCNorteCampo").attr('disabled', 'disabled');
            }
            else {
                //_EspecieNoMaderableEdit.frm.find("#txtDiametroCampo").rules("add", { required: true, messages: { required: 'Ingrese el diámetro campo (cm)' } });
                //_EspecieNoMaderableEdit.frm.find("#txtAlturaCampo").rules("add", { required: true, messages: { required: 'Ingrese la altura campo (m)' } });
                //_EspecieNoMaderableEdit.frm.find("#txtProdLataCampo").rules("add", { required: true, messages: { required: 'Ingrese la producción latas campo 2 (cm)' } });
                _EspecieNoMaderableEdit.frm.find("#ddlZonaCampoId").rules("add", { required: true, messages: { required: 'Seleccione la zona UTM campo' } });
                _EspecieNoMaderableEdit.frm.find("#txtCEsteCampo").rules("add", { required: true, messages: { required: 'Ingrese la coordenada este campo' } });
                _EspecieNoMaderableEdit.frm.find("#txtCNorteCampo").rules("add", { required: true, messages: { required: 'Ingrese la coordenada norte campo' } });
                _EspecieNoMaderableEdit.frm.find("#ddlEstadoCampoId").rules("add", { required: true, messages: { required: 'Seleccione el estado de la especie en campo' } });
                _EspecieNoMaderableEdit.frm.find("#ddlEstadoFitoId").rules("add", { required: true, messages: { required: 'Seleccione el estado fitosanitario' } });
                _EspecieNoMaderableEdit.frm.find("#ddlGradoInfestId").rules("add", { required: true, messages: { required: 'Seleccione el grado de infestación de lianas' } });
                _EspecieNoMaderableEdit.frm.find("#ddlCondicionId").rules("add", { required: true, messages: { required: 'Seleccione la condición' } });
                //_EspecieNoMaderableEdit.frm.find("#txtCocoAbierto").rules("add", { required: true, messages: { required: 'Ingrese los cocos abiertos' } });
                //_EspecieNoMaderableEdit.frm.find("#txtCocoCerrado").rules("add", { required: true, messages: { required: 'Ingrese los cocos cerrados' } });

                //_EspecieNoMaderableEdit.frm.find("#ddlRenderComboEspecieId").removeAttr('disabled');
                _EspecieNoMaderableEdit.frm.find("#txtEstradaCampo").removeAttr('disabled');
                _EspecieNoMaderableEdit.frm.find("#txtCodigoCampo").removeAttr('disabled');
                //_EspecieNoMaderableEdit.frm.find("#txtDiametroCampo").removeAttr('disabled');
                //_EspecieNoMaderableEdit.frm.find("#txtAlturaCampo").removeAttr('disabled');
                //_EspecieNoMaderableEdit.frm.find("#txtProdLataCampo").removeAttr('disabled');
                //_EspecieNoMaderableEdit.frm.find("#txtCocoAbierto").removeAttr('disabled');
                //_EspecieNoMaderableEdit.frm.find("#txtCocoCerrado").removeAttr('disabled');
                //_EspecieNoMaderableEdit.frm.find("#ddlCFusteId").removeAttr('disabled');
                //_EspecieNoMaderableEdit.frm.find("#txtCantSobreEst").removeAttr('disabled');
                //_EspecieNoMaderableEdit.frm.find("#txtPorcSobreEst").removeAttr('disabled');
                //_EspecieNoMaderableEdit.frm.find("#txtCantSubEst").removeAttr('disabled');
                //_EspecieNoMaderableEdit.frm.find("#txtPorcSubEst").removeAttr('disabled');
                //_EspecieNoMaderableEdit.frm.find("#ddlFenologiaId").removeAttr('disabled');
                //_EspecieNoMaderableEdit.frm.find("#ddlCFusteId").removeAttr('disabled');
                //_EspecieNoMaderableEdit.frm.find("#ddlPCopaId").removeAttr('disabled');
                //_EspecieNoMaderableEdit.frm.find("#ddlFCopaId").removeAttr('disabled');
                _EspecieNoMaderableEdit.frm.find("#ddlEstadoFitoId").removeAttr('disabled');
                _EspecieNoMaderableEdit.frm.find("#ddlGradoInfestId").removeAttr('disabled');
                _EspecieNoMaderableEdit.frm.find("#ddlCondicionId").removeAttr('disabled');
                _EspecieNoMaderableEdit.frm.find("#ddlZonaCampoId").removeAttr('disabled');
                _EspecieNoMaderableEdit.frm.find("#txtCEsteCampo").removeAttr('disabled');
                _EspecieNoMaderableEdit.frm.find("#txtCNorteCampo").removeAttr('disabled');
            }
        }
    });
}

_EspecieNoMaderableEdit.fnSearch = function () {

    var codInforme = $("#hdfCodInforme").val();
    var codTHabilitante = $("#hdfCodTHabilitante").val(); //_DatosCampo.frm.find("#hdfCodTHabilitante").val();
    var numPoa = $("#hdfNumPoa").val(); //_DatosCampo.frm.find("#hdfNumPoa").val();
    var codigo = $("#txtCodigoB").val();

    $("#txtCodigo").val(codigo);
    
    var secuencial = $("#hdfCodSecuencialB").val();

    var url = urlLocalSigo + "Supervision/ManInforme/GetDatosNoMaderable";
    var option = {
        url: url,
        datos: JSON.stringify({
            asCodInforme: codInforme,
            asCodTHabilitante: codTHabilitante,
            asNumPoa: numPoa,
            asCodigo: codigo,
            asCodSecuencial: secuencial
        }),
        type: 'POST'
    };

    utilSigo.fnAjax(option, function (data) {
        if (data.success) {
            if (data.data.length == 1) {
                Limpiar();
                $("#hdfCodSecuencialB").val(-1);
                _EspecieNoMaderableEdit.fnLoadDatos(data);
            }
            else {
                if (data.data.length == 0) {
                    Limpiar();
                    utilSigo.toastWarning("Aviso", "No se encontraron resultados");
                }
                else {
                    var mensaje = "";
                    for (var i = 0; i < data.data.length; i++) {
                        //var pri = 'Bloque:\u00A0';
                        //var seg = ',\u00A0Faja:\u00A0';
                        var este = data.data[i].COORDENADA_ESTE;
                        var norte = data.data[i].COORDENADA_NORTE;

                        //var aviso = pri + bloque + seg + faja + '\u00A0y\u00A0Coordenadas:\u00A0' + este + ',' + norte;
                        var aviso = '\u00A0Coordenadas:\u00A0' + este + ',' + norte;

                        mensaje += "<a href='#' onclick=AbrirOpciones('" + data.data[i].COD_SECUENCIAL + "'); data-dismiss='modal'>" + aviso + "</a>" + "<br/>";
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
            //Ok: {
            //    label: 'Aceptar',
            //    className: 'btn-sm  btn-primary',
            //    iconFa: 'fa-check',
            //    callback: fnOk
            //},
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

function AbrirOpciones(asCodSecuencial) {

    $("#hdfCodSecuencialB").val(asCodSecuencial);
    //Limpiar();

    _EspecieNoMaderableEdit.fnSearch();

}

function Limpiar() {
    var sel = document.getElementById("ddlRenderComboEspecieId");
    sel.remove(sel.selectedIndex);

    _EspecieNoMaderableEdit.frm = $("#frmItemEspecieNoMaderableEdit");
    var regEstado = "1"; // Nuevo

    _EspecieNoMaderableEdit.frm.find("#hdfRegEstado").val(regEstado);
    _EspecieNoMaderableEdit.frm.find("#hdfCodSecuencial").val("");
    _EspecieNoMaderableEdit.frm.find("#hdfCodEspecie").val("");
    _EspecieNoMaderableEdit.frm.find("#txtCodigoB").val("");
    _EspecieNoMaderableEdit.frm.find("#txtEspecie").val("");
    _EspecieNoMaderableEdit.frm.find("#ddlCoincideEspecieId").val("-");
    _EspecieNoMaderableEdit.frm.find("#txtEstrada").val("");
    _EspecieNoMaderableEdit.frm.find("#txtEstradaCampo").val("");
    //_EspecieNoMaderableEdit.frm.find("#txtDiametro").val("");
    //_EspecieNoMaderableEdit.frm.find("#txtAltura").val("");
    _EspecieNoMaderableEdit.frm.find("#txtCodigo").val("");
    _EspecieNoMaderableEdit.frm.find("#txtCodigoCampo").val("");
    //_EspecieNoMaderableEdit.frm.find("#txtDap").val("");
    //_EspecieNoMaderableEdit.frm.find("#txtDiametroCampo").val("");
    //_EspecieNoMaderableEdit.frm.find("#txtProdLata").val("");
    //_EspecieNoMaderableEdit.frm.find("#txtAltura").val("");
    //_EspecieNoMaderableEdit.frm.find("#txtAlturaCampo").val("");
    //_EspecieNoMaderableEdit.frm.find("#txtProdLataCampo").val("");
    _EspecieNoMaderableEdit.frm.find("#ddlZonaCampoId").val("0000000");
    $('#ddlZonaCampoId').select2().trigger('change');
    _EspecieNoMaderableEdit.frm.find("#txtCEste").val("");
    _EspecieNoMaderableEdit.frm.find("#txtCEsteCampo").val("");
    _EspecieNoMaderableEdit.frm.find("#txtCNorte").val("");
    _EspecieNoMaderableEdit.frm.find("#txtCNorteCampo").val("");
    _EspecieNoMaderableEdit.frm.find("#txtEstado").val("");
    _EspecieNoMaderableEdit.frm.find("#ddlEstadoCampoId").val("0000000");
    $('#ddlEstadoCampoId').select2().trigger('change');
    _EspecieNoMaderableEdit.frm.find("#txtZona").val("");    
    //_EspecieNoMaderableEdit.frm.find("#ddlFenologiaId").val("0000001");
    //_EspecieNoMaderableEdit.frm.find("#ddlCFusteId").val("0000000");
    //_EspecieNoMaderableEdit.frm.find("#ddlFCopaId").val("0000000");
    //_EspecieNoMaderableEdit.frm.find("#ddlPCopaId").val("0000000");
    _EspecieNoMaderableEdit.frm.find("#ddlEstadoFitoId").val("0000000");
    $('#ddlEstadoFitoId').select2().trigger('change');
    _EspecieNoMaderableEdit.frm.find("#ddlGradoInfestId").val("0000000");
    $('#ddlGradoInfestId').select2().trigger('change');
    //_EspecieNoMaderableEdit.frm.find("#txtCantSobreEst").val("");
    //_EspecieNoMaderableEdit.frm.find("#txtPorcSobreEst").val("");
    //_EspecieNoMaderableEdit.frm.find("#txtCantSubEst").val("");
    //_EspecieNoMaderableEdit.frm.find("#txtPorcSubEst").val("");
    _EspecieNoMaderableEdit.frm.find("#ddlCondicionId").val("0000017");
    $('#ddlCondicionId').select2().trigger('change');
    _EspecieNoMaderableEdit.frm.find("#txtObservacion").val("");
    _renderComboEspecie.fnInit("FORESTAL", '', '');

}

function clearValidationErrors() {
    _EspecieNoMaderableEdit.frm.find("#txtEstradaCampo").removeClass('form-control form-control-sm border-danger');
    _EspecieNoMaderableEdit.frm.find("#txtEstradaCampo").addClass('form-control form-control-sm');
    _EspecieNoMaderableEdit.frm.find("#txtCodigoCampo").removeClass('form-control form-control-sm border-danger');
    _EspecieNoMaderableEdit.frm.find("#txtCodigoCampo").addClass('form-control form-control-sm');
    //_EspecieNoMaderableEdit.frm.find("#txtDiametroCampo").removeClass('form-control form-control-sm border-danger');
    //_EspecieNoMaderableEdit.frm.find("#txtDiametroCampo").addClass('form-control form-control-sm');
    //_EspecieNoMaderableEdit.frm.find("#txtAlturaCampo").removeClass('form-control form-control-sm border-danger');
    //_EspecieNoMaderableEdit.frm.find("#txtAlturaCampo").addClass('form-control form-control-sm');
    //_EspecieNoMaderableEdit.frm.find("#txtProdLataCampo").removeClass('form-control form-control-sm border-danger');
    //_EspecieNoMaderableEdit.frm.find("#txtProdLataCampo").addClass('form-control form-control-sm');
    //_EspecieNoMaderableEdit.frm.find("#txtCocoAbierto").removeClass('form-control form-control-sm border-danger');
    //_EspecieNoMaderableEdit.frm.find("#txtCocoAbierto").addClass('form-control form-control-sm');
    //_EspecieNoMaderableEdit.frm.find("#txtCocoCerrado").removeClass('form-control form-control-sm border-danger');
    //_EspecieNoMaderableEdit.frm.find("#txtCocoCerrado").addClass('form-control form-control-sm');
    _EspecieNoMaderableEdit.frm.find("#txtCEsteCampo").removeClass('form-control form-control-sm border-danger');
    _EspecieNoMaderableEdit.frm.find("#txtCEsteCampo").addClass('form-control form-control-sm');
    _EspecieNoMaderableEdit.frm.find("#txtCNorteCampo").removeClass('form-control form-control-sm border-danger');
    _EspecieNoMaderableEdit.frm.find("#txtCNorteCampo").addClass('form-control form-control-sm');
    _EspecieNoMaderableEdit.frm.find(".has-error").removeClass("has-error");
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