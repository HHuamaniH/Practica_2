"use strict";
var _VerticeArea = {};

_VerticeArea.fnSaveForm = function (data) { /*implementado desde donde se instancia*/ }

_VerticeArea.fnLoadDatos = function (data) {
    if (data != null && data != "") {
        if (data["COD_SISTEMA"].split('|').length > 2) {
            data["COD_SISTEMA"] = data["COD_SISTEMA"].split('|')[0] + "|" + data["COD_SISTEMA"].split('|')[1];
        }

        var codVer = data["COD_SISTEMA"] + "|" + data["VERTICE"] + "|" + data["ZONA"] + "|" + data["COORDENADA_ESTE"] + "|" + data["COORDENADA_NORTE"] + "|" + data["PCA"];
        _VerticeArea.frm.find("#hdfRegEstado").val(data["RegEstado"]);
        _VerticeArea.frm.find("#hdfCodSecuencial").val(data["COD_SECUENCIAL"]);
        _VerticeArea.frm.find("#txtVertice").val(data["VERTICE_CAMPO"]);
        _VerticeArea.frm.find("#ddlVerticeId").select2("val", [codVer]);
        _VerticeArea.frm.find("#ddlZonaId").select2("val", [data["ZONA"]]);
        _VerticeArea.frm.find("#txtCoordEste").val(data["COORDENADA_ESTE"]);
        _VerticeArea.frm.find("#txtCoordNorte").val(data["COORDENADA_NORTE"]);
        _VerticeArea.frm.find("#ddlZonaCampoId").select2("val", [data["ZONA_CAMPO"]]);
        _VerticeArea.frm.find("#txtCoordEsteCampo").val(data["COORDENADA_ESTE_CAMPO"]);
        _VerticeArea.frm.find("#txtCoordNorteCampo").val(data["COORDENADA_NORTE_CAMPO"]);
        _VerticeArea.frm.find("#txtObservacion").val(data["OBSERVACION"]);
        _VerticeArea.frm.find("#txtPCPOA").val(data["PCA"]);
        _VerticeArea.frm.find("#txtParceVertice").val(data["PCA_CAMPO"]);
    } else {
        _VerticeArea.frm.find("#hdfRegEstado").val("1");
        _VerticeArea.frm.find("#hdfCodSecuencial").val("0");
    }
}

_VerticeArea.fnSetDatos = function () {
    var data = [];
    var regEstado = _VerticeArea.frm.find("#hdfRegEstado").val();
    data["RegEstado"] = regEstado == "0" ? "2" : regEstado;
    data["COD_SISTEMA"] = _VerticeArea.frm.find("#hdfCodSistema").val();
    data["COD_SECUENCIAL"] = _VerticeArea.frm.find("#hdfCodSecuencial").val();
    data["VERTICE"] = _VerticeArea.frm.find("#hdfVertice").val();
    data["VERTICE_CAMPO"] = _VerticeArea.frm.find("#txtVertice").val();
    data["ZONA_CAMPO"] = _VerticeArea.frm.find("#ddlZonaCampoId").val();
    data["ZONA"] = _VerticeArea.frm.find("#ddlZonaId").val();
    data["COORDENADA_ESTE_CAMPO"] = _VerticeArea.frm.find("#txtCoordEsteCampo").val();
    data["COORDENADA_ESTE"] = _VerticeArea.frm.find("#txtCoordEste").val();
    data["COORDENADA_NORTE_CAMPO"] = _VerticeArea.frm.find("#txtCoordNorteCampo").val();
    data["COORDENADA_NORTE"] = _VerticeArea.frm.find("#txtCoordNorte").val();
    data["OBSERVACION"] = _VerticeArea.frm.find("#txtObservacion").val();
    data["PCA_CAMPO"] = _VerticeArea.frm.find("#txtParceVertice").val() == "0000000" ? "" : _VerticeArea.frm.find("#txtParceVertice").val();
    data["PCA"] = _VerticeArea.frm.find("#txtPCPOA").val();
    return data;
}

_VerticeArea.fnEvents = function () {
    _VerticeArea.frm.find("#ddlVerticeId").change(function () {
        if ($(this).val() != "0000000") {
            var datVer = $(this).val().split('|');
            _VerticeArea.frm.find("#hdfCodSistema").val(datVer[0] + "|" + datVer[1]);
            _VerticeArea.frm.find("#hdfVertice").val(datVer[2]);
            _VerticeArea.frm.find("#txtVertice").val(datVer[2]);
            _VerticeArea.frm.find("#ddlZonaId").select2("val", [datVer[3]]);
            _VerticeArea.frm.find("#txtCoordEste").val(datVer[4]);
            _VerticeArea.frm.find("#txtCoordNorte").val(datVer[5]);
            _VerticeArea.frm.find("#txtPCPOA").val(datVer[6]);
        }
    });
}

_VerticeArea.fnSubmitForm = function () {
    //alert('123');
    _VerticeArea.frm.submit();
   
}

_VerticeArea.fnInit = function (data) {
    _VerticeArea.frm = $("#frmItemVerticeArea");
    $.fn.select2.defaults.set("theme", "bootstrap4");
    _VerticeArea.frm.find("#ddlZonaId").select2({ minimumResultsForSearch: -1 });
    _VerticeArea.frm.find("#ddlZonaCampoId").select2({ minimumResultsForSearch: -1 });
    _VerticeArea.frm.find("#ddlVerticeId").select2();
    _VerticeArea.fnLoadDatos(data);
    _VerticeArea.fnEvents();

    //=====-----Para el registro de datos del formulario-----=====
    //Validación personalizada
    jQuery.validator.addMethod("invalidFrmVertice", function (value, element) {
        switch ($(element).attr('id')) {
            case 'ddlZonaId':
                return (value == '0000000') ? false : true;
                break
        }
    });

    _VerticeArea.frm.validate(utilSigo.fnValidate({
        
        rules: {
            txtVertice: { required: true },
            ddlZonaId: { invalidFrmVertice: true },
            txtCoordEste: { required: true },
            txtCoordNorte: { required: true }
        },
        messages: {
            txtVertice: { required: "Ingrese el número de individuos" },
            ddlZonaId: { invalidFrmVertice: "Seleccione la zona UTM" },
            txtCoordEste: { required: "Ingrese la coordenada este" },
            txtCoordNorte: { required: "Ingrese la coordenada norte" }
        },
        fnSubmit: function (form) {    
            //alert("validaciones");
            _VerticeArea.fnSaveForm(_VerticeArea.fnSetDatos());
        }
    }));
    //Validación de controles que usan Select2
    _VerticeArea.frm.find("select.select2-hidden-accessible").on("change", function (e) {
        $(this).valid();
    });
}