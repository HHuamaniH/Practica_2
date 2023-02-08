"use strict";
var _CoordenadaUTM = {};

_CoordenadaUTM.fnSaveForm = function (data) { /*implementado desde donde se instancia*/ }

_CoordenadaUTM.fnLoadDatos = function (data) {
    if (data != null && data != "") {
        _CoordenadaUTM.frm.find("#hdfRegEstado").val(data["RegEstado"]);
        _CoordenadaUTM.frm.find("#hdfCodSecuencial").val(data["COD_SECUENCIAL"]);
        _CoordenadaUTM.frm.find("#txtVertice").val(data["VERTICE"]);
        _CoordenadaUTM.frm.find("#ddlZonaId").select2("val", [data["ZONA"] == "" ? "0000000" : data["ZONA"]]);
        _CoordenadaUTM.frm.find("#ddlZonaCampoId").select2("val", [data["ZONA_CAMPO"] == "" ? "0000000" : data["ZONA_CAMPO"]]);
        _CoordenadaUTM.frm.find("#txtCEste").val(data["COORDENADA_ESTE"]);
        _CoordenadaUTM.frm.find("#txtCEsteCampo").val(data["COORDENADA_ESTE_CAMPO"]);
        _CoordenadaUTM.frm.find("#txtCNorte").val(data["COORDENADA_NORTE"]);
        _CoordenadaUTM.frm.find("#txtCNorteCampo").val(data["COORDENADA_NORTE_CAMPO"]);
    } else {
        _CoordenadaUTM.frm.find("#hdfRegEstado").val("1");
        _CoordenadaUTM.frm.find("#hdfCodSecuencial").val("0");
    }
}

_CoordenadaUTM.fnSetDatos = function () {
    var data = [];
    var regEstado = _CoordenadaUTM.frm.find("#hdfRegEstado").val();
    data["RegEstado"] = regEstado == "0" ? "2" : regEstado;
    data["COD_SECUENCIAL"] = _CoordenadaUTM.frm.find("#hdfCodSecuencial").val();
    data["VERTICE"] = _CoordenadaUTM.frm.find("#txtVertice").val();
    data["ZONA"] = _CoordenadaUTM.frm.find("#ddlZonaId").val();
    data["ZONA_CAMPO"] = _CoordenadaUTM.frm.find("#ddlZonaCampoId").val();
    data["COORDENADA_ESTE"] = _CoordenadaUTM.frm.find("#txtCEste").val();
    data["COORDENADA_ESTE_CAMPO"] = _CoordenadaUTM.frm.find("#txtCEsteCampo").val();
    data["COORDENADA_NORTE"] = _CoordenadaUTM.frm.find("#txtCNorte").val();
    data["COORDENADA_NORTE_CAMPO"] = _CoordenadaUTM.frm.find("#txtCNorteCampo").val();
    return data;
}

_CoordenadaUTM.fnSubmitForm = function () {
    _CoordenadaUTM.frm.submit();
}

_CoordenadaUTM.fnInit = function (data) {
    _CoordenadaUTM.frm = $("#frmItemCoordenadaUTM");

    $.fn.select2.defaults.set("theme", "bootstrap4");
    _CoordenadaUTM.frm.find("#ddlZonaId").select2({ minimumResultsForSearch: -1 });
    _CoordenadaUTM.frm.find("#ddlZonaCampoId").select2({ minimumResultsForSearch: -1 });

    _CoordenadaUTM.fnLoadDatos(data);

    //=====-----Para el registro de datos del formulario-----=====
    _CoordenadaUTM.frm.validate(utilSigo.fnValidate({
        rules: {
            txtVertice: { required: true },
            txtCEste: { required: true },
            txtCEsteCampo: { required: true },
            txtCNorte: { required: true },
            txtCNorteCampo: { required: true }
        },
        messages: {
            txtVertice: { required: "Ingrese el vértice" },
            txtCEste: { required: "Ingrese la coordenada este" },
            txtCEsteCampo: { required: "Ingrese la coordenada este campo" },
            txtCNorte: { required: "Ingrese la coordenada norte" },
            txtCNorteCampo: { required: "Ingrese la coordenada norte campo" }
        },
        fnSubmit: function (form) {
            _CoordenadaUTM.fnSaveForm(_CoordenadaUTM.fnSetDatos());
        }
    }));

    //Validación de controles que usan Select2
    _CoordenadaUTM.frm.find("select.select2-hidden-accessible").on("change", function (e) {
        $(this).valid();
    });
}