"use strict";
var _ActividadSilvicultural = {};

_ActividadSilvicultural.fnSaveForm = function (data) { /*implementado desde donde se instancia*/ }

_ActividadSilvicultural.fnLoadDatos = function (data) {
    if (data != null && data != "") {
        _ActividadSilvicultural.frm.find("#hdfRegEstado").val(data["RegEstado"]);
        _ActividadSilvicultural.frm.find("#hdfCodSecuencial").val(data["COD_SECUENCIAL"]);
        _ActividadSilvicultural.frm.find("#ddlActSilviculturalId").select2("val", [data["COD_ASILVICULTURALES"]]);
        _ActividadSilvicultural.frm.find("#txtFaja").val(data["FAJA"]);
        _ActividadSilvicultural.frm.find("#txtPlantula").val(data["NUM_PLANTULAS"]);
        _ActividadSilvicultural.frm.find("#txtUbicacion").val(data["UBICACION"]);
        _ActividadSilvicultural.frm.find("#txtTiempo").val(data["TIEMPO"]);
        _ActividadSilvicultural.frm.find("#chkCumplimiento").prop("checked", data["CUMPLIMIENTO_ACTIVIDADES"]);
        _ActividadSilvicultural.frm.find("#txtObservacion").val(data["OBSERVACION"]);
        _renderComboEspecie.fnInit("FORESTAL", data["COD_ESPECIES"], data["DESC_ESPECIES"]);
    } else {
        _ActividadSilvicultural.frm.find("#hdfRegEstado").val("1");
        _ActividadSilvicultural.frm.find("#hdfCodSecuencial").val("0");
        _renderComboEspecie.fnInit("FORESTAL", "", "");
    }
}

_ActividadSilvicultural.fnSetDatos = function () {
    var data = [];
    var regEstado = _ActividadSilvicultural.frm.find("#hdfRegEstado").val();
    data["RegEstado"] = regEstado == "0" ? "2" : regEstado;
    data["COD_SECUENCIAL"] = _ActividadSilvicultural.frm.find("#hdfCodSecuencial").val();
    data["COD_ESPECIES"] = _renderComboEspecie.fnGetCodEspecie();
    data["DESC_ESPECIES"] = _renderComboEspecie.fnGetEspecie();
    data["COD_ASILVICULTURALES"] = _ActividadSilvicultural.frm.find("#ddlActSilviculturalId").val();
    data["DESC_SILVICULTURALES"] = _ActividadSilvicultural.frm.find("#ddlActSilviculturalId").select2("data")[0].text;
    data["FAJA"] = _ActividadSilvicultural.frm.find("#txtFaja").val();
    data["NUM_PLANTULAS"] = _ActividadSilvicultural.frm.find("#txtPlantula").val();
    data["UBICACION"] = _ActividadSilvicultural.frm.find("#txtUbicacion").val();
    data["TIEMPO"] = _ActividadSilvicultural.frm.find("#txtTiempo").val();
    var cumpleAct=utilSigo.fnGetValChk(_ActividadSilvicultural.frm.find("#chkCumplimiento"));
    data["CUMPLIMIENTO_ACTIVIDADES"] = cumpleAct;
    data["DESC_CUMPLIMIENTO"] = cumpleAct == true ? "SI" : "";
    data["OBSERVACION"] = _ActividadSilvicultural.frm.find("#txtObservacion").val();
    return data;
}

_ActividadSilvicultural.fnSubmitForm = function () {
    _ActividadSilvicultural.frm.submit();
}

_ActividadSilvicultural.fnInit = function (data) {
    _ActividadSilvicultural.frm = $("#frmItemActividadSilvicultural");

    $.fn.select2.defaults.set("theme", "bootstrap4");
    _ActividadSilvicultural.frm.find("#ddlActSilviculturalId").select2();

    _ActividadSilvicultural.fnLoadDatos(data);

    //=====-----Para el registro de datos del formulario-----=====
    _ActividadSilvicultural.frm.validate(utilSigo.fnValidate({
        rules: {
            txtPlantula: { required: true },
            txtTiempo: { required: true }
        },
        messages: {
            txtPlantula: { required: "Ingrese el número de plantulas" },
            txtTiempo: { required: "Ingrese el tiempo" }
        },
        fnSubmit: function (form) {
            _ActividadSilvicultural.fnSaveForm(_ActividadSilvicultural.fnSetDatos());
        }
    }));
    //Validación de controles que usan Select2
    _ActividadSilvicultural.frm.find("select.select2-hidden-accessible").on("change", function (e) {
        $(this).valid();
    });
}