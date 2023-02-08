"use strict";
var _ErrorMaterial = {};

_ErrorMaterial.fnCloseModal = function () { /*implementado desde donde se instancia*/ }
_ErrorMaterial.fnSaveForm = function (data) { /*implementado desde donde se instancia*/ }

_ErrorMaterial.fnSetDatos = function (tipo) {
    var data = {};
    data.NV_TIPO = tipo;
    data.DA_FECRESOLUCION = _ErrorMaterial.frm.find("#txtFechaResolucion").val();
    data.NV_RESOLUCION = _ErrorMaterial.frm.find("#txtResolucion").val();
    data.NV_NOMCAMPO = _ErrorMaterial.frm.find("#txtNombreCampo").val();
    data.NV_VALANTERIOR = _ErrorMaterial.frm.find("#txtValorAnterior").val();
    data.NV_VALACTUAL = _ErrorMaterial.frm.find("#txtValorActual").val();
    data.NV_OBSERVACION = _ErrorMaterial.frm.find("#txtObservacion").val();

    return data;
}

_ErrorMaterial.fnSubmitForm = function () {
    _ErrorMaterial.frm.submit();
}

_ErrorMaterial.fnInit = function (tipo) {
    _ErrorMaterial.frm = $("#frmAddErrorMaterial");

    _ErrorMaterial.frm.find("#txtFechaResolucion").datepicker({ format: "dd/mm/yyyy", autoclose: true, language: 'es' });
    _ErrorMaterial.frm.find("#txtFechaResolucion").keyup(function () {
        return formateafecha(this.value);
    });

    //=====-----Para el registro de datos del formulario-----=====
    //Validación personalizada
    _ErrorMaterial.frm.validate(utilSigo.fnValidate({
        rules: {
            txtFechaResolucion: { required: true },
            txtResolucion: { required: true },
            txtNombreCampo: { required: true },
            txtValorAnterior: { required: true },
            txtValorActual: { required: true }
        },
        messages: {
            txtFechaResolucion: { required: "Ingrese Fecha de Resolución" },
            txtResolucion: { required: "Ingrese Resolución" },
            txtNombreCampo: { required: "Ingrese Nombre de Campo" },
            txtValorAnterior: { required: "Ingrese Valor Anterior" },
            txtValorActual: { required: "Ingrese Valor Actual" }
        },
        fnSubmit: function (form) {
            _ErrorMaterial.fnSaveForm(_ErrorMaterial.fnSetDatos(tipo));
        }
    }));
}