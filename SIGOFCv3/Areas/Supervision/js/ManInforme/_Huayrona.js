"use strict";
var _Huayrona = {};

_Huayrona.fnSaveForm = function (data) { /*implementado desde donde se instancia*/ }

_Huayrona.fnLoadDatos = function (data) {
    if (data != null && data != "") {
        _Huayrona.frm.find("#hdfRegEstado").val(data["RegEstado"]);
        _Huayrona.frm.find("#txtNumero").val(data["NUMERO"]);
        _Huayrona.frm.find("#ddlZonaId").select2("val", [data["ZONA"]]);
        _Huayrona.frm.find("#txtCoordEste").val(data["COORDENADA_ESTE"]);
        _Huayrona.frm.find("#txtCoordNorte").val(data["COORDENADA_NORTE"]);
        _Huayrona.frm.find("#txtVolumen").val(data["VOLUMEN"]);
    } else {
        _Huayrona.frm.find("#hdfRegEstado").val("1");
    }
}

_Huayrona.fnSetDatos = function () {
    var data = [];
    var regEstado = _Huayrona.frm.find("#hdfRegEstado").val();
    data["RegEstado"] = regEstado == "0" ? "2" : regEstado;
    data["NUMERO"] = _Huayrona.frm.find("#txtNumero").val();
    data["ZONA"] = _Huayrona.frm.find("#ddlZonaId").val() == "0000000" ? "" : _Huayrona.frm.find("#ddlZonaId").val();
    data["COORDENADA_ESTE"] = _Huayrona.frm.find("#txtCoordEste").val();
    data["COORDENADA_NORTE"] = _Huayrona.frm.find("#txtCoordNorte").val();
    data["VOLUMEN"] = _Huayrona.frm.find("#txtVolumen").val();
    return data;
}

_Huayrona.fnSubmitForm = function () {
    _Huayrona.frm.submit();
}

_Huayrona.fnInit = function (data) {
    _Huayrona.frm = $("#frmItemHuayrona");

    $.fn.select2.defaults.set("theme", "bootstrap4");
    _Huayrona.frm.find("#ddlZonaId").select2({ minimumResultsForSearch: -1 });

    _Huayrona.fnLoadDatos(data);

    //=====-----Para el registro de datos del formulario-----=====
    //Validación personalizada
    jQuery.validator.addMethod("invalidFrmHuayrona", function (value, element) {
        switch ($(element).attr('id')) {
            case 'ddlZonaId':
                return (value == '0000000') ? false : true;
                break
        }
    });
    _Huayrona.frm.validate(utilSigo.fnValidate({
        rules: {
            txtNumero: { required: true },
            ddlZonaId: { invalidFrmHuayrona: true },
            txtCoordEste: { required: true },
            txtCoordNorte: { required: true },
            txtVolumen: { required: true }
        },
        messages: {
            txtNumero: { required: "Ingrese el número de la huayrona" },
            ddlZonaId: { invalidFrmHuayrona: "Seleccione la zona UTM" },
            txtCoordEste: { required: "Ingrese la coordenada este" },
            txtCoordNorte: { required: "Ingrese la coordenada norte" },
            txtVolumen: { required: "Ingrese el volumen" }
        },
        fnSubmit: function (form) {
            _Huayrona.fnSaveForm(_Huayrona.fnSetDatos());
        }
    }));
    //Validación de controles que usan Select2
    _Huayrona.frm.find("select.select2-hidden-accessible").on("change", function (e) {
        $(this).valid();
    });
}