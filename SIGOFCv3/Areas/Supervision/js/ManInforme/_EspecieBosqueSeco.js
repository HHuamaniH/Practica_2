"use strict";
var _EspecieBosqueSeco = {};

_EspecieBosqueSeco.fnSaveForm = function (data) { /*implementado desde donde se instancia*/ }

_EspecieBosqueSeco.fnLoadDatos = function (data) {
    if (data != null && data != "") {
        _EspecieBosqueSeco.frm.find("#hdfRegEstado").val(data["RegEstado"]);
        _EspecieBosqueSeco.frm.find("#hdfCodSecuencial").val(data["COD_SECUENCIAL"]);
        _EspecieBosqueSeco.frm.find("#hdfCodTHabilitante").val(data["COD_THABILITANTE"]);
        _EspecieBosqueSeco.frm.find("#hdfNumPoa").val(data["NUM_POA"]);
        _EspecieBosqueSeco.frm.find("#hdfNombrePoa").val(data["POA"]);
        _EspecieBosqueSeco.frm.find("#hdfCodEspecie").val(data["COD_ESPECIES"]);
        _EspecieBosqueSeco.frm.find("#txtEspecie").val(data["DESC_ESPECIES"]);
        _EspecieBosqueSeco.frm.find("#txtBloque").val(data["BLOQUE"]);
        _EspecieBosqueSeco.frm.find("#txtBloqueCampo").val(data["BLOQUE_CAMPO"]);
        _EspecieBosqueSeco.frm.find("#txtFaja").val(data["FAJA"]);
        _EspecieBosqueSeco.frm.find("#txtFajaCampo").val(data["FAJA_CAMPO"]);
        _EspecieBosqueSeco.frm.find("#txtCodigo").val(data["CODIGO"]);
        _EspecieBosqueSeco.frm.find("#txtCodigoCampo").val(data["CODIGO_CAMPO"]);
        _EspecieBosqueSeco.frm.find("#txtDap").val(data["DAP"]);
        _EspecieBosqueSeco.frm.find("#txtDapCampo").val(data["DAP_CAMPO"]);
        _EspecieBosqueSeco.frm.find("#txtAc").val(data["AC"]);
        _EspecieBosqueSeco.frm.find("#txtAcCampo").val(data["AC_CAMPO"]);
        _EspecieBosqueSeco.frm.find("#txtZona").val(data["ZONA"]);
        _EspecieBosqueSeco.frm.find("#ddlZonaCampoId").select2("val", [data["ZONA_CAMPO"] == "000" ? "0000000" : data["ZONA_CAMPO"]]);
        _EspecieBosqueSeco.frm.find("#txtCEste").val(data["COORDENADA_ESTE"]);
        _EspecieBosqueSeco.frm.find("#txtCEsteCampo").val(data["COORDENADA_ESTE_CAMPO"]);
        _EspecieBosqueSeco.frm.find("#txtCNorte").val(data["COORDENADA_NORTE"]);
        _EspecieBosqueSeco.frm.find("#txtCNorteCampo").val(data["COORDENADA_NORTE_CAMPO"]);
        _EspecieBosqueSeco.frm.find("#txtEstado").val(data["DESC_EESTADO"]);
        _EspecieBosqueSeco.frm.find("#ddlEstadoCampoId").select2("val", [data["COD_EESTADO"]]);
        _EspecieBosqueSeco.frm.find("#txtAlturaTotal").val(data["BS_ALTURA_TOTAL"]);
        _EspecieBosqueSeco.frm.find("#txtD1").val(data["BS_DIAMETRO_RAMA_1"]);
        _EspecieBosqueSeco.frm.find("#txtD2").val(data["BS_DIAMETRO_RAMA_2"]);
        _EspecieBosqueSeco.frm.find("#txtD3").val(data["BS_DIAMETRO_RAMA_3"]);
        _EspecieBosqueSeco.frm.find("#txtD4").val(data["BS_DIAMETRO_RAMA_4"]);
        _EspecieBosqueSeco.frm.find("#txtD5").val(data["BS_DIAMETRO_RAMA_5"]);
        _EspecieBosqueSeco.frm.find("#txtD6").val(data["BS_DIAMETRO_RAMA_6"]);
        _EspecieBosqueSeco.frm.find("#txtD7").val(data["BS_DIAMETRO_RAMA_7"]);
        _EspecieBosqueSeco.frm.find("#txtL1").val(data["BS_LONGITUD_RAMA_1"]);
        _EspecieBosqueSeco.frm.find("#txtL2").val(data["BS_LONGITUD_RAMA_2"]);
        _EspecieBosqueSeco.frm.find("#txtL3").val(data["BS_LONGITUD_RAMA_3"]);
        _EspecieBosqueSeco.frm.find("#txtL4").val(data["BS_LONGITUD_RAMA_4"]);
        _EspecieBosqueSeco.frm.find("#txtL5").val(data["BS_LONGITUD_RAMA_5"]);
        _EspecieBosqueSeco.frm.find("#txtL6").val(data["BS_LONGITUD_RAMA_6"]);
        _EspecieBosqueSeco.frm.find("#txtL7").val(data["BS_LONGITUD_RAMA_7"]);
        _EspecieBosqueSeco.frm.find("#txtObservacion").val(data["OBSERVACION"]);
        _EspecieBosqueSeco.frm.find("#hdfDescAmenCite").val(data["DESC_ACATEGORIA_CITE"]);
        _EspecieBosqueSeco.frm.find("#hdfDescAmenDs").val(data["DESC_ACATEGORIA_DS"]);
        _renderComboEspecie.fnInit("FORESTAL", data["COD_ESPECIES_CAMPO"], data["DESC_ESPECIES_CAMPO"]);
    }
}

_EspecieBosqueSeco.fnSetDatos = function () {
    var data = [];
    var regEstado = _EspecieBosqueSeco.frm.find("#hdfRegEstado").val();
    data["RegEstado"] = regEstado == "0" ? "2" : regEstado;
    data["COD_INFORME"] = _EspecieBosqueSeco.frm.find("#hdfCodInforme").val();
    data["COD_SECUENCIAL"] = _EspecieBosqueSeco.frm.find("#hdfCodSecuencial").val();
    data["COD_THABILITANTE"] = _EspecieBosqueSeco.frm.find("#hdfCodTHabilitante").val();
    data["NUM_POA"] = _EspecieBosqueSeco.frm.find("#hdfNumPoa").val();
    data["POA"] = _EspecieBosqueSeco.frm.find("#hdfNombrePoa").val();;
    data["COD_ESPECIES_CAMPO"] = _renderComboEspecie.fnGetCodEspecie();
    data["DESC_ESPECIES_CAMPO"] = _renderComboEspecie.fnGetEspecie();
    data["COD_ESPECIES"] = _EspecieBosqueSeco.frm.find("#hdfCodEspecie").val();
    data["DESC_ESPECIES"] = _EspecieBosqueSeco.frm.find("#txtEspecie").val();
    data["BLOQUE"] = _EspecieBosqueSeco.frm.find("#txtBloque").val();
    data["BLOQUE_CAMPO"] = _EspecieBosqueSeco.frm.find("#txtBloqueCampo").val();
    data["FAJA"] = _EspecieBosqueSeco.frm.find("#txtFaja").val();
    data["FAJA_CAMPO"] = _EspecieBosqueSeco.frm.find("#txtFajaCampo").val();
    data["CODIGO"] = _EspecieBosqueSeco.frm.find("#txtCodigo").val();
    data["CODIGO_CAMPO"] = _EspecieBosqueSeco.frm.find("#txtCodigoCampo").val();
    data["DAP"] = _EspecieBosqueSeco.frm.find("#txtDap").val();
    data["DAP_CAMPO"] = _EspecieBosqueSeco.frm.find("#txtDapCampo").val();
    data["AC"] = _EspecieBosqueSeco.frm.find("#txtAc").val();
    data["AC_CAMPO"] = _EspecieBosqueSeco.frm.find("#txtAcCampo").val();
    data["ZONA"] = _EspecieBosqueSeco.frm.find("#txtZona").val();
    data["ZONA_CAMPO"] = _EspecieBosqueSeco.frm.find("#ddlZonaCampoId").val();
    data["COORDENADA_ESTE"] = _EspecieBosqueSeco.frm.find("#txtCEste").val();
    data["COORDENADA_ESTE_CAMPO"] = _EspecieBosqueSeco.frm.find("#txtCEsteCampo").val();
    data["COORDENADA_NORTE"] = _EspecieBosqueSeco.frm.find("#txtCNorte").val();
    data["COORDENADA_NORTE_CAMPO"] = _EspecieBosqueSeco.frm.find("#txtCNorteCampo").val();
    data["DESC_EESTADO"] = _EspecieBosqueSeco.frm.find("#txtEstado").val();
    data["COD_EESTADO"] = _EspecieBosqueSeco.frm.find("#ddlEstadoCampoId").val();
    data["DESC_EESTADO_CAMPO"] = _EspecieBosqueSeco.frm.find("#ddlEstadoCampoId").val() == "0000000" ? "" : _EspecieBosqueSeco.frm.find("#ddlEstadoCampoId").select2("data")[0].text;
    data["BS_ALTURA_TOTAL"]=_EspecieBosqueSeco.frm.find("#txtAlturaTotal").val();
    data["BS_DIAMETRO_RAMA_1"] = _EspecieBosqueSeco.frm.find("#txtD1").val();
    data["BS_DIAMETRO_RAMA_2"] = _EspecieBosqueSeco.frm.find("#txtD2").val();
    data["BS_DIAMETRO_RAMA_3"] = _EspecieBosqueSeco.frm.find("#txtD3").val();
    data["BS_DIAMETRO_RAMA_4"] = _EspecieBosqueSeco.frm.find("#txtD4").val();
    data["BS_DIAMETRO_RAMA_5"] = _EspecieBosqueSeco.frm.find("#txtD5").val();
    data["BS_DIAMETRO_RAMA_6"] = _EspecieBosqueSeco.frm.find("#txtD6").val();
    data["BS_DIAMETRO_RAMA_7"] = _EspecieBosqueSeco.frm.find("#txtD7").val();
    data["BS_LONGITUD_RAMA_1"] = _EspecieBosqueSeco.frm.find("#txtL1").val();
    data["BS_LONGITUD_RAMA_2"] = _EspecieBosqueSeco.frm.find("#txtL2").val();
    data["BS_LONGITUD_RAMA_3"] = _EspecieBosqueSeco.frm.find("#txtL3").val();
    data["BS_LONGITUD_RAMA_4"] = _EspecieBosqueSeco.frm.find("#txtL4").val();
    data["BS_LONGITUD_RAMA_5"] = _EspecieBosqueSeco.frm.find("#txtL5").val();
    data["BS_LONGITUD_RAMA_6"] = _EspecieBosqueSeco.frm.find("#txtL6").val();
    data["BS_LONGITUD_RAMA_7"] = _EspecieBosqueSeco.frm.find("#txtL7").val();
    data["DESC_ACATEGORIA_CITE"] = _EspecieBosqueSeco.frm.find("#hdfDescAmenCite").val();
    data["DESC_ACATEGORIA_DS"] = _EspecieBosqueSeco.frm.find("#hdfDescAmenDs").val();
    data["OBSERVACION"] = _EspecieBosqueSeco.frm.find("#txtObservacion").val();
    return data;
}

_EspecieBosqueSeco.fnCustomValidateForm = function () {
    if (_renderComboEspecie.fnGetCodEspecie() == null) {
        utilSigo.toastWarning("Aviso", "Seleccione la especie a registrar"); return false;
    }
    return true;
}

_EspecieBosqueSeco.fnSubmitForm = function () {
    _EspecieBosqueSeco.frm.submit();
}

_EspecieBosqueSeco.fnInit = function (data) {
    _EspecieBosqueSeco.frm = $("#frmItemEspecieBosqueSeco");

    $.fn.select2.defaults.set("theme", "bootstrap4");
    _EspecieBosqueSeco.frm.find("#ddlZonaCampoId").select2({ minimumResultsForSearch: -1 });
    _EspecieBosqueSeco.frm.find("#ddlEstadoCampoId").select2();

    _EspecieBosqueSeco.fnLoadDatos(data);

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
    _EspecieBosqueSeco.frm.validate(utilSigo.fnValidate({
        rules: {
            txtDapCampo: { required: true },
            txtAcCampo: { required: true },
            ddlZonaCampoId: { invalidFrmEspecie: true },
            txtCEsteCampo: { required: true },
            txtCNorteCampo: { required: true },
            ddlEstadoCampoId: { invalidFrmEspecie: true },
            txtAlturaTotal: { required: true },
            txtD1: { required: true },
            txtD2: { required: true },
            txtD3: { required: true },
            txtD4: { required: true },
            txtD5: { required: true },
            txtD6: { required: true },
            txtD7: { required: true },
            txtL1: { required: true },
            txtL2: { required: true },
            txtL3: { required: true },
            txtL4: { required: true },
            txtL5: { required: true },
            txtL6: { required: true },
            txtL7: { required: true }
        },
        messages: {
            txtDapCampo: { required: "Ingrese el DAP campo (cm)" },
            txtAcCampo: { required: "Ingrese el AC campo (m)" },
            ddlZonaCampoId: { invalidFrmEspecie: "Seleccione la zona UTM campo" },
            txtCEsteCampo: { required: "Ingrese la coordenada este campo" },
            txtCNorteCampo: { required: "Ingrese la coordenada norte campo" },
            ddlEstadoCampoId: { invalidFrmEspecie: "Seleccione el estado de la especie en campo" },
            txtAlturaTotal: { required: "Ingrese Altura Total de Campo" },
            txtD1: { required: "Ingrese D1 de Campo" },
            txtD2: { required: "Ingrese D2 de Campo" },
            txtD3: { required: "Ingrese D3 de Campo" },
            txtD4: { required: "Ingrese D4 de Campo" },
            txtD5: { required: "Ingrese D5 de Campo" },
            txtD6: { required: "Ingrese D6 de Campo" },
            txtD7: { required: "Ingrese D7 de Campo" },
            txtL1: { required: "Ingrese L1 de Campo" },
            txtL2: { required: "Ingrese L2 de Campo" },
            txtL3: { required: "Ingrese L3 de Campo" },
            txtL4: { required: "Ingrese L4 de Campo" },
            txtL5: { required: "Ingrese L5 de Campo" },
            txtL6: { required: "Ingrese L6 de Campo" },
            txtL7: { required: "Ingrese L7 de Campo" }
        },
        fnSubmit: function (form) {
            if (_EspecieBosqueSeco.fnCustomValidateForm()) {
                var oEspecie = utilSigo.fnConvertArrayToObject(_EspecieBosqueSeco.fnSetDatos());
                var url = urlLocalSigo + "Supervision/ManInforme/GrabarEspecieBosqueSeco";
                var option = { url: url, datos: JSON.stringify(oEspecie), type: 'POST' };
                utilSigo.fnAjax(option, function (data) {
                    if (data.success) {
                        _EspecieBosqueSeco.fnSaveForm(oEspecie);
                    }
                    else {
                        utilSigo.toastWarning("Aviso", data.msj);
                    }
                });
            }
        }
    }));
    //Validación de controles que usan Select2
    _EspecieBosqueSeco.frm.find("select.select2-hidden-accessible").on("change", function (e) {
        $(this).valid();
    });
}