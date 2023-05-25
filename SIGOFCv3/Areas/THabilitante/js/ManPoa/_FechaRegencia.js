"use strict";
var _FechaRegencia = {};

_FechaRegencia.fnCloseModal = function () { /*implementado desde donde se instancia*/ }
_FechaRegencia.fnSaveForm = function (data) { /*implementado desde donde se instancia*/ }

_FechaRegencia.fnSetDatos = function () {
    var data = {};
    data.FECHA_INI = _FechaRegencia.frm.find("#txtFechaIni").val();
    data.FECHA_FIN = _FechaRegencia.frm.find("#txtFechaFin").val();

    return data;
}

_FechaRegencia.fnSubmitForm = function () {
    _FechaRegencia.frm.submit();
}

_FechaRegencia.fnInit = function () {
    _FechaRegencia.frm = $("#frmAddFechaRegencia");

    _FechaRegencia.frm.find("#txtFechaIni").datepicker({ format: "dd/mm/yyyy", autoclose: true, language: 'es' });

    _FechaRegencia.frm.find("#txtFechaFin").datepicker({ format: "dd/mm/yyyy", autoclose: true, language: 'es' });
    //_FechaRegencia.frm.find("#txtFechaFin").keyup(function () {
    //    return formateafecha(this.value);
    //});

    //=====-----Para el registro de datos del formulario-----=====
    //Validación personalizada
    _FechaRegencia.frm.validate(utilSigo.fnValidate({
        rules: {
            txtFechaIni: { required: true },
            txtFechaFin: { required: true },
        },
        messages: {
            txtFechaIni: { required: "Ingrese Fecha de inicio" },
            txtFechaFin: { required: "Ingrese Fecha de fin" },

        },
        fnSubmit: function (form) {
            _FechaRegencia.fnSaveForm(_FechaRegencia.fnSetDatos());
        }
    }));
}