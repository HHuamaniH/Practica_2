"use strict";
var _VerticeTHCampo = {};

_VerticeTHCampo.fnSaveForm = function (data) { /*implementado desde donde se instancia*/ }

_VerticeTHCampo.fnLoadDatos = function (data) {
    if (data != null && data != "") {
        var codVer = data["COD_SISTEMA"] + "|" + data["VERTICE"] + "|" + data["ZONA"] + "|" + data["COORDENADA_ESTE"] + "|" + data["COORDENADA_NORTE"];

        _VerticeTHCampo.frm.find("#hdfRegEstado").val(data["RegEstado"]);
        _VerticeTHCampo.frm.find("#hdfCodSistema").val(data["COD_SISTEMA"]);
        _VerticeTHCampo.frm.find("#hdfVertice").val(data["VERTICE"]);
        _VerticeTHCampo.frm.find("#ddlVerticeId").select2("val",[codVer]);
        _VerticeTHCampo.frm.find("#ddlZonaId").select2("val",[data["ZONA"]]);
        _VerticeTHCampo.frm.find("#txtCoordEste").val(data["COORDENADA_ESTE"]);
        _VerticeTHCampo.frm.find("#txtCoordNorte").val(data["COORDENADA_NORTE"]);

        _VerticeTHCampo.frm.find("#txtVerticeCampo").val(data["VERTICE_CAMPO"]);
        _VerticeTHCampo.frm.find("#ddlZonaCampoId").select2("val", [data["ZONA_CAMPO"]]);
        _VerticeTHCampo.frm.find("#txtCoordEsteCampo").val(data["COORDENADA_ESTE_CAMPO"]);
        _VerticeTHCampo.frm.find("#txtCoordNorteCampo").val(data["COORDENADA_NORTE_CAMPO"]);
        _VerticeTHCampo.frm.find("#txtObservacionCampo").val(data["OBSERVACION_CAMPO"]);
    } else {
        _VerticeTHCampo.frm.find("#hdfCodSistema").val("");
        _VerticeTHCampo.frm.find("#hdfRegEstado").val("1");
    }
}

_VerticeTHCampo.fnSetDatos = function () {
    var data = [];
    var regEstado = _VerticeTHCampo.frm.find("#hdfRegEstado").val();
    data["RegEstado"] = regEstado == "0" ? "2" : regEstado;
    data["COD_SISTEMA"] = _VerticeTHCampo.frm.find("#hdfCodSistema").val();
    data["VERTICE"] = _VerticeTHCampo.frm.find("#hdfVertice").val();
    data["ZONA"] = _VerticeTHCampo.frm.find("#ddlZonaId").val();
    data["COORDENADA_ESTE"] = _VerticeTHCampo.frm.find("#txtCoordEste").val();
    data["COORDENADA_NORTE"] = _VerticeTHCampo.frm.find("#txtCoordNorte").val();
    data["VERTICE_CAMPO"] = _VerticeTHCampo.frm.find("#txtVerticeCampo").val();
    data["ZONA_CAMPO"] = _VerticeTHCampo.frm.find("#ddlZonaCampoId").val();
    data["COORDENADA_ESTE_CAMPO"] = _VerticeTHCampo.frm.find("#txtCoordEsteCampo").val();
    data["COORDENADA_NORTE_CAMPO"] = _VerticeTHCampo.frm.find("#txtCoordNorteCampo").val();
    data["OBSERVACION_CAMPO"] = _VerticeTHCampo.frm.find("#txtObservacionCampo").val();
    return data;
}

_VerticeTHCampo.fnEvents = function () {
    _VerticeTHCampo.frm.find("#ddlVerticeId").change(function () {
        if ($(this).val()!="0000000") {
            var datVer = $(this).val().split('|');
            _VerticeTHCampo.frm.find("#hdfCodSistema").val(datVer[0] + "|" + datVer[1] + "|" + datVer[2]);
            _VerticeTHCampo.frm.find("#hdfVertice").val(datVer[3]);
            _VerticeTHCampo.frm.find("#ddlZonaId").select2("val", [datVer[4]]);
            _VerticeTHCampo.frm.find("#txtCoordEste").val(datVer[5]);
            _VerticeTHCampo.frm.find("#txtCoordNorte").val(datVer[6]);
        }
    });
}

_VerticeTHCampo.fnSubmitForm = function () {
    _VerticeTHCampo.frm.submit();
}

_VerticeTHCampo.fnInit = function (data) {
    _VerticeTHCampo.frm = $("#frmItemVerticeTHCampo");

    $.fn.select2.defaults.set("theme", "bootstrap4");
    _VerticeTHCampo.frm.find("#ddlVerticeId").select2();
    _VerticeTHCampo.frm.find("#ddlZonaId").select2({ minimumResultsForSearch: -1 });
    _VerticeTHCampo.frm.find("#ddlZonaCampoId").select2({ minimumResultsForSearch: -1 });

    _VerticeTHCampo.fnLoadDatos(data);

    _VerticeTHCampo.fnEvents();

    //=====-----Para el registro de datos del formulario-----=====
    //Validación personalizada
    jQuery.validator.addMethod("invalidFrmVerticeTHCampo", function (value, element) {
        switch ($(element).attr('id')) {
            case 'ddlVerticeId':
                return (value == '0000000') ? false : true;
                break
            case 'ddlZonaCampoId':
                return (value == '0000000') ? false : true;
                break
        }
    });
    _VerticeTHCampo.frm.validate(utilSigo.fnValidate({
        rules: {
            ddlVerticeId: { invalidFrmVerticeTHCampo: true },
            txtVerticeCampo: { required: true },
            ddlZonaCampoId: { invalidFrmVerticeTHCampo: true },
            txtCoordEsteCampo: { required: true },
            txtCoordNorteCampo: { required: true }
        },
        messages: {
            ddlVerticeId: { invalidFrmVerticeTHCampo: "Seleccione el vértice del Título Habilitante" },
            txtVerticeCampo: { required: "Ingrese el vertice obtenido en campo" },
            ddlZonaCampoId: { invalidFrmVerticeTHCampo: "Seleccione la zona obtenido en campo" },
            txtCoordEsteCampo: { required: "Ingrese la coordenada este obtenida en campo" },
            txtCoordNorteCampo: { required: "Ingrese la coordenada norte obtenida en campo" }
        },
        fnSubmit: function (form) {
            _VerticeTHCampo.fnSaveForm(_VerticeTHCampo.fnSetDatos());
        }
    }));
    //Validación de controles que usan Select2
    _VerticeTHCampo.frm.find("select.select2-hidden-accessible").on("change", function (e) {
        $(this).valid();
    });
}


