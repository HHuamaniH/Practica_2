"use strict";
var _ActoObligacion = {};

_ActoObligacion.fnSaveForm = function (data) { /*implementado desde donde se instancia*/ }

_ActoObligacion.fnLoadDatos = function (data,codObligacion) {
    if (data != null && data != "") {
        _ActoObligacion.frm.find("#hdfRegEstado").val(data["RegEstado"]);
        _ActoObligacion.frm.find("#hdfCodObligacion").val(data["COD_OCONTRACTUAL"]);
        _ActoObligacion.frm.find("#hdfCodSecuencial").val(data["COD_SECUENCIAL"]);
        _ActoObligacion.frm.find("#txtActo").val(data["ACTIVIDAD_ACTOS"]);
        _ActoObligacion.frm.find("#txtDocumento").val(data["DOCUMENTOS_AFORESTAL"]);
    } else {
        _ActoObligacion.frm.find("#hdfRegEstado").val("1");
        _ActoObligacion.frm.find("#hdfCodObligacion").val(codObligacion);
        _ActoObligacion.frm.find("#hdfCodSecuencial").val("0");
    }
}

_ActoObligacion.fnSetDatos = function () {
    var data = [];
    var regEstado = _ActoObligacion.frm.find("#hdfRegEstado").val();
    data["RegEstado"] = regEstado == "0" ? "2" : regEstado;
    data["COD_OCONTRACTUAL"]=_ActoObligacion.frm.find("#hdfCodObligacion").val();
    data["COD_SECUENCIAL"] = _ActoObligacion.frm.find("#hdfCodSecuencial").val();
    data["ACTIVIDAD_ACTOS"] = _ActoObligacion.frm.find("#txtActo").val();
    data["DOCUMENTOS_AFORESTAL"] = _ActoObligacion.frm.find("#txtDocumento").val();
    return data;
}

_ActoObligacion.fnSubmitForm = function () {
    _ActoObligacion.frm.submit();
}

_ActoObligacion.fnInit = function (data, codObligacion) {
    _ActoObligacion.frm = $("#frmItemActoObligacion");

    _ActoObligacion.fnLoadDatos(data, codObligacion);

    //=====-----Para el registro de datos del formulario-----=====
    _ActoObligacion.frm.validate(utilSigo.fnValidate({
        rules: {
            txtActo: { required: true },
            txtDocumento: { required: true }
        },
        messages: {
            txtActo: { required: "Ingrese la descripción" },
            txtDocumento: { required: "Ingrese el documento" }
        },
        fnSubmit: function (form) {
            _ActoObligacion.fnSaveForm(_ActoObligacion.fnSetDatos());
        }
    }));
    //Validación de controles que usan Select2
    _ActoObligacion.frm.find("select.select2-hidden-accessible").on("change", function (e) {
        $(this).valid();
    });
}