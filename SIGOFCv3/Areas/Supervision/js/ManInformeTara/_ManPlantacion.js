"use strict";
var _ManPlantacion = {};

_ManPlantacion.fnSaveForm = function (data) { /*implementado desde donde se instancia*/ }

_ManPlantacion.fnLoadDatos = function (data) {
    if (data != null && data != "") {
        _ManPlantacion.frm.find("#hdfRegEstado").val(data["RegEstado"]);
        _ManPlantacion.frm.find("#ddlManActividadId").select2("val", [data["COD_TCONCEPTO"]]);
        _ManPlantacion.frm.find("#ddlExisteId").select2("val", [data["ESTADO_MPLANTACION"] == true ? "SI" : "NO"]);
        _ManPlantacion.frm.find("#txtObservacion").val(data["OBSERVACION"]);
    } else {
        _ManPlantacion.frm.find("#hdfRegEstado").val("1");
    }
}

_ManPlantacion.fnSetDatos = function () {
    var data = [];
    var regEstado = _ManPlantacion.frm.find("#hdfRegEstado").val();
    data["RegEstado"] = regEstado == "0" ? "2" : regEstado;
    data["COD_TCONCEPTO"] = _ManPlantacion.frm.find("#ddlManActividadId").val();
    data["DESCRIPCION"] = _ManPlantacion.frm.find("#ddlManActividadId").select2("data")[0].text;
    data["ESTADO_MPLANTACION"] = _ManPlantacion.frm.find("#ddlExisteId").val() == "SI" ? true : false;
    data["OBSERVACION"] = _ManPlantacion.frm.find("#txtObservacion").val();
    return data;
}

_ManPlantacion.fnSubmitForm = function () {
    _ManPlantacion.frm.submit();
}

_ManPlantacion.fnInit = function (data) {
    _ManPlantacion.frm = $("#frmItemManPlantacion");

    $.fn.select2.defaults.set("theme", "bootstrap4");
    _ManPlantacion.frm.find("#ddlManActividadId").select2();
    _ManPlantacion.frm.find("#ddlExisteId").select2({ minimumResultsForSearch: -1 });

    _ManPlantacion.fnLoadDatos(data);

    //=====-----Para el registro de datos del formulario-----=====
    //Validación personalizada
    jQuery.validator.addMethod("invalidFrmPlanta", function (value, element) {
        switch ($(element).attr('id')) {
            case 'ddlManActividadId':
            case 'ddlExisteId':
                return (value == '0000000' || value=='0') ? false : true;
                break
        }
    });
    _ManPlantacion.frm.validate(utilSigo.fnValidate({
        rules: {
            ddlManActividadId: { invalidFrmPlanta: true },
            ddlExisteId: { invalidFrmPlanta: true }
        },
        messages: {
            ddlManActividadId: { invalidFrmPlanta: "Seleccione la actividad de mantenimiento" },
            ddlExisteId: { invalidFrmPlanta: "Seleccione una opción" }
        },
        fnSubmit: function (form) {
            _ManPlantacion.fnSaveForm(_ManPlantacion.fnSetDatos());
        }
    }));

    //Validación de controles que usan Select2
    _ManPlantacion.frm.find("select.select2-hidden-accessible").on("change", function (e) {
        $(this).valid();
    });
}