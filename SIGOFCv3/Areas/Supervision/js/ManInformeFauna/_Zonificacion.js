"use strict";
var _Zonificacion = {};

_Zonificacion.fnSaveForm = function (data) { /*implementado desde donde se instancia*/ }

_Zonificacion.fnLoadDatos = function (data) {
    if (data != null && data != "") {
        _Zonificacion.frm.find("#hdfRegEstado").val(data["RegEstado"]);
        _Zonificacion.frm.find("#hdfCodSecuencial").val(data["COD_SECUENCIAL"]);
        _Zonificacion.frm.find("#txtNombreZona").val(data["NOMBRE_ZONA"]);
        _Zonificacion.frm.find("#txtCaracteristica").val(data["CARACTERISTICA"]);
        _Zonificacion.frm.find("#ddlZonaId").select2("val", [data["ZONA"] == "" ? "0000000" : data["ZONA"]]);
        _Zonificacion.frm.find("#txtCEste").val(data["COORDENADA_ESTE"]);
        _Zonificacion.frm.find("#txtCNorte").val(data["COORDENADA_NORTE"]);
        _Zonificacion.frm.find("#txtSenalizacion").val(data["TIPO_SENALIZACION"]);
        _Zonificacion.frm.find("#txtDelimitacion").val(data["TIPO_DELIMITACION"]);
    } else {
        _Zonificacion.frm.find("#hdfRegEstado").val("1");
        _Zonificacion.frm.find("#hdfCodSecuencial").val("0");
    }
}

_Zonificacion.fnSetDatos = function () {
    var data = [];
    var regEstado = _Zonificacion.frm.find("#hdfRegEstado").val();
    data["RegEstado"] = regEstado == "0" ? "2" : regEstado;
    data["COD_SECUENCIAL"] = _Zonificacion.frm.find("#hdfCodSecuencial").val();
    data["NOMBRE_ZONA"] = _Zonificacion.frm.find("#txtNombreZona").val();
    data["CARACTERISTICA"] = _Zonificacion.frm.find("#txtCaracteristica").val();
    data["ZONA"] = _Zonificacion.frm.find("#ddlZonaId").val();
    data["COORDENADA_ESTE"] = _Zonificacion.frm.find("#txtCEste").val();
    data["COORDENADA_NORTE"] = _Zonificacion.frm.find("#txtCNorte").val();
    data["TIPO_SENALIZACION"] = _Zonificacion.frm.find("#txtSenalizacion").val();
    data["TIPO_DELIMITACION"] = _Zonificacion.frm.find("#txtDelimitacion").val();
    return data;
}

_Zonificacion.fnSubmitForm = function () {
    _Zonificacion.frm.submit();
}

_Zonificacion.fnInit = function (data) {
    _Zonificacion.frm = $("#frmItemZonificacion");

    $.fn.select2.defaults.set("theme", "bootstrap4");
    _Zonificacion.frm.find("#ddlZonaId").select2({ minimumResultsForSearch: -1 });

    _Zonificacion.fnLoadDatos(data);

    //=====-----Para el registro de datos del formulario-----=====
    _Zonificacion.frm.validate(utilSigo.fnValidate({
        rules: {
            txtNombreZona: { required: true },
            txtCaracteristica: { required: true },
            txtCEste: { required: true },
            txtCNorte: { required: true }
        },
        messages: {
            txtNombreZona: { required: "Ingrese el nombre de la zona" },
            txtCaracteristica: { required: "Ingrese la característica" },
            txtCEste: { required: "Ingrese la coordenada este" },
            txtCNorte: { required: "Ingrese la coordenada norte" }
        },
        fnSubmit: function (form) {
            _Zonificacion.fnSaveForm(_Zonificacion.fnSetDatos());
        }
    }));

    //Validación de controles que usan Select2
    _Zonificacion.frm.find("select.select2-hidden-accessible").on("change", function (e) {
        $(this).valid();
    });
}