"use strict";
var _Desplazamiento = {};

_Desplazamiento.fnSaveForm = function (data) { /*implementado desde donde se instancia*/ }

_Desplazamiento.fnLoadDatos = function (data) {
    if (data != null && data != "") {
        _Desplazamiento.frm.find("#hdfRegEstado").val(data["RegEstado"]);
        _Desplazamiento.frm.find("#hdfCodDesplazamiento").val(data["COD_DESPLAZAMIENTO"]);
        _Desplazamiento.frm.find("#ddlZonaId").select2("val", [data["ZONA"] == "" ? "0000000" : data["ZONA"]]);
        _Desplazamiento.frm.find("#txtCoordEste").val(data["COORDENADA_ESTE"]);
        _Desplazamiento.frm.find("#txtCoordNorte").val(data["COORDENADA_NORTE"]);
        _Desplazamiento.frm.find("#ddlZonaFinId").select2("val", [data["ZONA_CAMPO"] == "" ? "0000000" : data["ZONA_CAMPO"]]);
        _Desplazamiento.frm.find("#txtCoordEsteFin").val(data["COORDENADA_ESTE_CAMPO"]);
        _Desplazamiento.frm.find("#txtCoordNorteFin").val(data["COORDENADA_NORTE_CAMPO"]);
        _Desplazamiento.frm.find("#ddlTipoViaId").select2("val", [data["TipoVia"] == "" ? "0000000" : data["TipoVia"]]);
        _Desplazamiento.frm.find("#txtDescripcion").val(data["OBSERVACION"]);
    } else {
        _Desplazamiento.frm.find("#hdfRegEstado").val("1");
        _Desplazamiento.frm.find("#hdfCodDesplazamiento").val("0");
    }
}

_Desplazamiento.fnSetDatos = function () {
    var data = [];
    var regEstado = _Desplazamiento.frm.find("#hdfRegEstado").val();
    data["RegEstado"] = regEstado == "0" ? "2" : regEstado;
    data["COD_DESPLAZAMIENTO"] = _Desplazamiento.frm.find("#hdfCodDesplazamiento").val();
    data["ZONA"] = _Desplazamiento.frm.find("#ddlZonaId").val();
    data["COORDENADA_ESTE"] = _Desplazamiento.frm.find("#txtCoordEste").val();
    data["COORDENADA_NORTE"] = _Desplazamiento.frm.find("#txtCoordNorte").val();
    data["ZONA_CAMPO"] = _Desplazamiento.frm.find("#ddlZonaFinId").val();
    data["COORDENADA_ESTE_CAMPO"] = _Desplazamiento.frm.find("#txtCoordEsteFin").val();
    data["COORDENADA_NORTE_CAMPO"] = _Desplazamiento.frm.find("#txtCoordNorteFin").val();
    data["TipoVia"] = _Desplazamiento.frm.find("#ddlTipoViaId").val();
    data["OBSERVACION"] = _Desplazamiento.frm.find("#txtDescripcion").val();
    return data;
}

_Desplazamiento.fnSubmitForm = function () {
    _Desplazamiento.frm.submit();
}

_Desplazamiento.fnInit = function (data) {
    _Desplazamiento.frm = $("#frmItemDesplazamiento");

    $.fn.select2.defaults.set("theme", "bootstrap4");
    _Desplazamiento.frm.find("#ddlZonaId").select2({ minimumResultsForSearch: -1 });
    _Desplazamiento.frm.find("#ddlZonaFinId").select2({ minimumResultsForSearch: -1 });
    _Desplazamiento.frm.find("#ddlTipoViaId").select2({ minimumResultsForSearch: -1 });

    _Desplazamiento.fnLoadDatos(data);

    //=====-----Para el registro de datos del formulario-----=====
    //Validación personalizada
    jQuery.validator.addMethod("invalidFrmDespl", function (value, element) {
        switch ($(element).attr('id')) {
            case 'ddlZonaId':
            case 'ddlZonaFinId':
            case 'ddlTipoViaId':
                return (value == '0000000') ? false : true;
                break
        }
    });
    _Desplazamiento.frm.validate(utilSigo.fnValidate({
        rules: {
            ddlZonaId: { invalidFrmDespl: true },
            txtCoordEste: { required: true },
            txtCoordNorte: { required: true },
            ddlZonaFinId: { invalidFrmDespl: true },
            txtCoordEsteFin: { required: true },
            txtCoordNorteFin: { required: true },
            ddlTipoViaId: { invalidFrmDespl: true }
        },
        messages: {
            ddlZonaId: { invalidFrmDespl: "Seleccione la zona UTM del punto inicial" },
            txtCoordEste: { required: "Ingrese la coordenada este del punto inicial" },
            txtCoordNorte: { required: "Ingrese la coordenada norte del punto inicial" },
            ddlZonaFinId: { invalidFrmDespl: "Seleccione la zona UTM del punto final" },
            txtCoordEsteFin: { required: "Ingrese la coordenada este del punto final" },
            txtCoordNorteFin: { required: "Ingrese la coordenada norte del punto final" },
            ddlTipoViaId: { invalidFrmDespl: "Seleccione el tipo de vía" }
        },
        fnSubmit: function (form) {
            _Desplazamiento.fnSaveForm(_Desplazamiento.fnSetDatos());
        }
    }));
    //Validación de controles que usan Select2
    _Desplazamiento.frm.find("select.select2-hidden-accessible").on("change", function (e) {
        $(this).valid();
    });
}