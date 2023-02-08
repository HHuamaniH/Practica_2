"use strict";
var _EspecieMaderaAserrada = {};

_EspecieMaderaAserrada.fnSaveForm = function (data) { /*implementado desde donde se instancia*/ }

_EspecieMaderaAserrada.fnLoadDatos = function (data) {
    if (data != null && data != "") {
        _EspecieMaderaAserrada.frm.find("#hdfRegEstado").val(data["RegEstado"]);
        _EspecieMaderaAserrada.frm.find("#hdfCodSecuencial").val(data["COD_SECUENCIAL"]);
        _EspecieMaderaAserrada.frm.find("#hdfCodTHabilitante").val(data["COD_THABILITANTE"]);
        _EspecieMaderaAserrada.frm.find("#txtCodigo").val(data["CODIGO"]);
        _EspecieMaderaAserrada.frm.find("#txtPieza").val(data["PIEZAS"]);
        _EspecieMaderaAserrada.frm.find("#ddlZonaId").select2("val", [data["ZONA"]]);
        _EspecieMaderaAserrada.frm.find("#txtCEste").val(data["COORDENADA_ESTE"]);
        _EspecieMaderaAserrada.frm.find("#txtCNorte").val(data["COORDENADA_NORTE"]);
        _EspecieMaderaAserrada.frm.find("#txtEspesor").val(data["ESPESOR"]);
        _EspecieMaderaAserrada.frm.find("#txtAncho").val(data["ANCHO"]);
        _EspecieMaderaAserrada.frm.find("#txtLargo").val(data["LARGO"]);
        _EspecieMaderaAserrada.frm.find("#txtObservacion").val(data["OBSERVACION"]);
        _renderComboEspecie.fnInit("FORESTAL", data["COD_ESPECIES"], data["ESPECIES"]);
    } else {
        _EspecieMaderaAserrada.frm.find("#hdfRegEstado").val("1");
        _EspecieMaderaAserrada.frm.find("#hdfCodSecuencial").val("0");
        _renderComboEspecie.fnInit("FORESTAL", "", "");
    }
}

_EspecieMaderaAserrada.fnSetDatos = function () {
    var data = [];
    var regEstado = _EspecieMaderaAserrada.frm.find("#hdfRegEstado").val();
    data["RegEstado"] = regEstado == "0" ? "2" : regEstado;
    data["COD_INFORME"] = _EspecieMaderaAserrada.frm.find("#hdfCodInforme").val();
    data["NUM_POA"] = _EspecieMaderaAserrada.frm.find("#hdfNumPoa").val();
    data["COD_SECUENCIAL"] = _EspecieMaderaAserrada.frm.find("#hdfCodSecuencial").val();
    data["COD_THABILITANTE"] = _EspecieMaderaAserrada.frm.find("#hdfCodTHabilitante").val();
    data["CODIGO"] = _EspecieMaderaAserrada.frm.find("#txtCodigo").val();
    data["COD_ESPECIES"] = _renderComboEspecie.fnGetCodEspecie();
    data["ESPECIES"] = _renderComboEspecie.fnGetEspecie();
    data["PIEZAS"] = _EspecieMaderaAserrada.frm.find("#txtPieza").val();
    data["ZONA"] = _EspecieMaderaAserrada.frm.find("#ddlZonaId").val();
    data["COORDENADA_ESTE"] = _EspecieMaderaAserrada.frm.find("#txtCEste").val();
    data["COORDENADA_NORTE"] = _EspecieMaderaAserrada.frm.find("#txtCNorte").val();
    data["ESPESOR"] = _EspecieMaderaAserrada.frm.find("#txtEspesor").val();
    data["ANCHO"] = _EspecieMaderaAserrada.frm.find("#txtAncho").val();
    data["LARGO"] = _EspecieMaderaAserrada.frm.find("#txtLargo").val();
    data["OBSERVACION"] = _EspecieMaderaAserrada.frm.find("#txtObservacion").val();
    return data;
}

_EspecieMaderaAserrada.fnCustomValidateForm = function () {
    if (_renderComboEspecie.fnGetCodEspecie() == null) {
        utilSigo.toastWarning("Aviso", "Seleccione la especie a registrar"); return false;
    }
    return true;
}

_EspecieMaderaAserrada.fnSubmitForm = function () {
    _EspecieMaderaAserrada.frm.submit();
}

_EspecieMaderaAserrada.fnInit = function (data) {
    _EspecieMaderaAserrada.frm = $("#frmItemTrozaCampo");

    $.fn.select2.defaults.set("theme", "bootstrap4");
    _EspecieMaderaAserrada.frm.find("#ddlZonaId").select2({ minimumResultsForSearch: -1 });

    _EspecieMaderaAserrada.fnLoadDatos(data);

    //=====-----Para el registro de datos del formulario-----=====
    //Validación personalizada
    jQuery.validator.addMethod("invalidFrmTroza", function (value, element) {
        switch ($(element).attr('id')) {
            case 'ddlZonaId':
                return (value == '0000000') ? false : true;
                break
        }
    });
    _EspecieMaderaAserrada.frm.validate(utilSigo.fnValidate({
        rules: {
            txtCodigo: { required: true },
            txtPieza: { required: true },
            ddlZonaId: { invalidFrmTroza: true },
            txtCEste: { required: true },
            txtCNorte: { required: true },
            txtEspesor: { required: true },
            txtAncho: { required: true },
            txtLargo: { required: true }
        },
        messages: {
            txtCodigo: { required: "Ingrese el código de la troza" },
            txtPieza: { required: "Ingrese el nro. de piezas o partes" },
            ddlZonaId: { invalidFrmTroza: "Seleccione la zona UTM" },
            txtCEste: { required: "Ingrese la coordenada este" },
            txtCNorte: { required: "Ingrese la coordenada norte" },
            txtEspesor: { required: "Ingrese el espesor (m)" },
            txtAncho: { required: "Ingrese el ancho (m)" },
            txtLargo: { required: "Ingrese el largo (m)" }
        },
        fnSubmit: function (form) {
            if (_EspecieMaderaAserrada.fnCustomValidateForm()) {
                var oEspecie = utilSigo.fnConvertArrayToObject(_EspecieMaderaAserrada.fnSetDatos());
                var url = urlLocalSigo + "Supervision/ManInforme/GrabarEspecieMaderaAserrada";
                var option = { url: url, datos: JSON.stringify(oEspecie), type: 'POST' };
                utilSigo.fnAjax(option, function (data) {
                    if (data.success) {
                        oEspecie["RegEstado"] = 0;
                        _EspecieMaderaAserrada.fnSaveForm(oEspecie);
                    }
                    else {
                        utilSigo.toastWarning("Aviso", data.msj);
                    }
                });
            }
        }
    }));
    //Validación de controles que usan Select2
    _EspecieMaderaAserrada.frm.find("select.select2-hidden-accessible").on("change", function (e) {
        $(this).valid();
    });
}