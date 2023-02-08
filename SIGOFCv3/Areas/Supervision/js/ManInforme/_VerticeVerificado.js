"use strict";
var _VerticeVerificado = {};

_VerticeVerificado.fnSaveForm = function (data) { /*implementado desde donde se instancia*/ }

_VerticeVerificado.fnLoadDatos = function (data) {
    if (data != null && data != "") {
        _VerticeVerificado.frm.find("#hdfRegEstado").val(data["RegEstado"]);
        _VerticeVerificado.frm.find("#hdfCodTHabilitante").val(data["COD_THABILITANTE"]);
        _VerticeVerificado.frm.find("#hdfCodVertice").val(data["COD_INFORME_VERTICE"]);
        _VerticeVerificado.frm.find("#txtVertice").val(data["VERTICE"]);
        _VerticeVerificado.frm.find("#txtVerticeCampo").val(data["VERTICE_CAMPO"]);
        _VerticeVerificado.frm.find("#ddlZonaId").select2("val", [data["ZONA"] == "" ? "0000000" : data["ZONA"]]);
        _VerticeVerificado.frm.find("#ddlZonaCampoId").select2("val", [data["ZONA_CAMPO"] == "" ? "0000000" : data["ZONA_CAMPO"]]);
        _VerticeVerificado.frm.find("#txtCEste").val(data["COORDENADA_ESTE"]);
        _VerticeVerificado.frm.find("#txtCEsteCampo").val(data["COORDENADA_ESTE_CAMPO"]);
        _VerticeVerificado.frm.find("#txtCNorte").val(data["COORDENADA_NORTE"]);
        _VerticeVerificado.frm.find("#txtCNorteCampo").val(data["COORDENADA_NORTE_CAMPO"]);
        _VerticeVerificado.frm.find("#txtObservacion").val(data["OBSERVACION"]);
    } else {
        _VerticeVerificado.frm.find("#hdfRegEstado").val("1");
    }
}

_VerticeVerificado.fnSetDatos = function () {
    var data = [];
    var regEstado = _VerticeVerificado.frm.find("#hdfRegEstado").val();
    data["RegEstado"] = regEstado == "0" ? "2" : regEstado;
    data["COD_INFORME"] = _VerticeVerificado.frm.find("#hdfCodInforme").val();
    data["NUM_POA"] = _VerticeVerificado.frm.find("#hdfNumPoa").val();
    data["COD_INFORME_VERTICE"] = _VerticeVerificado.frm.find("#hdfCodVertice").val();
    data["COD_THABILITANTE"] = _VerticeVerificado.frm.find("#hdfCodTHabilitante").val();
    data["VERTICE"] = _VerticeVerificado.frm.find("#txtVertice").val();
    data["VERTICE_CAMPO"] = _VerticeVerificado.frm.find("#txtVerticeCampo").val();
    data["ZONA"] = _VerticeVerificado.frm.find("#ddlZonaId").val();
    data["ZONA_CAMPO"] = _VerticeVerificado.frm.find("#ddlZonaCampoId").val();
    data["COORDENADA_ESTE"] = _VerticeVerificado.frm.find("#txtCEste").val();
    data["COORDENADA_ESTE_CAMPO"] = _VerticeVerificado.frm.find("#txtCEsteCampo").val();
    data["COORDENADA_NORTE"] = _VerticeVerificado.frm.find("#txtCNorte").val();
    data["COORDENADA_NORTE_CAMPO"] = _VerticeVerificado.frm.find("#txtCNorteCampo").val();
    data["OBSERVACION"] = _VerticeVerificado.frm.find("#txtObservacion").val();
    return data;
}

_VerticeVerificado.fnSubmitForm = function () {
    _VerticeVerificado.frm.submit();
}

_VerticeVerificado.fnInit = function (data) {
    _VerticeVerificado.frm = $("#frmItemVerticeVerificado");

    $.fn.select2.defaults.set("theme", "bootstrap4");
    _VerticeVerificado.frm.find("#ddlZonaId").select2({ minimumResultsForSearch: -1 });
    _VerticeVerificado.frm.find("#ddlZonaCampoId").select2({ minimumResultsForSearch: -1 });

    _VerticeVerificado.fnLoadDatos(data);

    //=====-----Para el registro de datos del formulario-----=====
    //Validación personalizada
    jQuery.validator.addMethod("invalidFrmVertice", function (value, element) {
        switch ($(element).attr('id')) {
            case 'ddlZonaId':
            case 'ddlZonaCampoId':
                return (value == '0000000') ? false : true;
                break
        }
    });

    _VerticeVerificado.frm.validate(utilSigo.fnValidate({
        rules: {
            txtVertice: { required: true },
            txtVerticeCampo: { required: true },
            ddlZonaId: { invalidFrmVertice: true },
            ddlZonaCampoId: { invalidFrmVertice: true },
            txtCEste: { required: true },
            txtCEsteCampo: { required: true },
            txtCNorte: { required: true },
            txtCNorteCampo: { required: true }
        },
        messages: {
            txtVertice: { required: "Ingrese el vértice verificado" },
            txtVerticeCampo: { required: "Ingrese en vértice campo verificado" },
            ddlZonaId: { invalidFrmVertice: "Seleccione la zona UTM" },
            ddlZonaCampoId: { invalidFrmVertice: "Seleccione la zona UTM Campo" },
            txtCEste: { required: "Ingrese la coordenada este" },
            txtCEsteCampo: { required: "Ingrese la coordenada este campo" },
            txtCNorte: { required: "Ingrese la coordenada norte" },
            txtCNorteCampo: { required: "Ingrese la coordenada norte campo" }
        },
        fnSubmit: function (form) {
            var oVertice = utilSigo.fnConvertArrayToObject(_VerticeVerificado.fnSetDatos());
            var url = urlLocalSigo + "Supervision/ManInforme/GrabarVerticeVerificado";
            var option = { url: url, datos: JSON.stringify(oVertice), type: 'POST' };
            utilSigo.fnAjax(option, function (data) {
                if (data.success) {
                    oVertice["RegEstado"] = 0;
                    _VerticeVerificado.fnSaveForm(oVertice);
                }
                else {
                    utilSigo.toastWarning("Aviso", data.msj);
                }
            });
        }
    }));

    //Validación de controles que usan Select2
    _VerticeVerificado.frm.find("select.select2-hidden-accessible").on("change", function (e) {
        $(this).valid();
    });
}