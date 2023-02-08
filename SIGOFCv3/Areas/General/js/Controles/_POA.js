"use strict";
var _POA = {};

_POA.fnAsignarDatos = function (obj) { /*Se implementa en cada llamada*/ }

_POA.fnInitDataTable_Detail = function () {
    var columns_label = [], columns_data = [], options = {}, sFormulario = "", sCriterio = "", sValor = "", url = "";

    columns_label = ["Plan de Manejo", "Resolución de Aprobación"];
    columns_data = ["ESTADO_ORIGEN", "NUM_RESOLUCION"];
    options = {
        page_length: initSigo.pageLengthBuscar, row_select: true, row_fnSelect: "_POA.fnAsignarDatos(this)", row_index: true
    };
    _POA.dtPOA = utilDt.fnLoadDataTable_Detail(_POA.frm.find("#tbPOA"), columns_label, columns_data, options);

    sFormulario = _POA.frm.find("#hdfFormulario").val();
    sCriterio = _POA.frm.find("#hdfCriterio").val();
    sValor = _POA.frm.find("#hdfValor").val();
    url = initSigo.urlControllerGeneral + "buscarPOA?asFormulario=" + sFormulario + "&asCriterio=" + sCriterio + "&asValor=" + sValor;

    _POA.dtPOA.ajax.url(url).load(function (data) {
        if (data.success == false) {
            utilSigo.toastError("Error", initSigo.MessageError);
            console.log(data.msj);
        }
    });
}

_POA.fnInit = function () {
    _POA.frm = $("#frmPOA");

    _POA.fnInitDataTable_Detail();
}