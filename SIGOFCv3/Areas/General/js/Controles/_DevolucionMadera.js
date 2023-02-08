"use strict";
var _DevolucionMadera = {};

_DevolucionMadera.fnAsignarDatos = function (obj) { /*Se implementa en cada llamada*/ }

_DevolucionMadera.fnInitDataTable_Detail = function () {
    var columns_label = [], columns_data = [], options = {}, sFormulario = "", sCriterio = "", sValor = "", url = "";

    columns_label = ["Código", "Fecha", "N° Resolución"];
    columns_data = ["COD_DEVOLUCION", "FECHA_RESOLUCION", "NUM_RESOLUCION"];
    options = {
        page_length: initSigo.pageLengthBuscar, row_select: true, row_fnSelect: "_DevolucionMadera.fnAsignarDatos(this)", row_index: true
    };
    _DevolucionMadera.dtDevolucionMadera = utilDt.fnLoadDataTable_Detail(_DevolucionMadera.frm.find("#tbDevolucionMadera"), columns_label, columns_data, options);

    sFormulario = _DevolucionMadera.frm.find("#hdfFormulario").val();
    sCriterio = _DevolucionMadera.frm.find("#hdfCriterio").val();
    sValor = _DevolucionMadera.frm.find("#hdfValor").val();
    url = initSigo.urlControllerGeneral + "buscarDevolucionMadera?asFormulario=" + sFormulario + "&asCriterio=" + sCriterio + "&asValor=" + sValor;

    _DevolucionMadera.dtDevolucionMadera.ajax.url(url).load(function (data) {
        if (data.success == false) {
            utilSigo.toastError("Error", data.msj);
            console.log(data.msj);
        }
    });
}

_DevolucionMadera.fnInit = function () {
    _DevolucionMadera.frm = $("#frmDevolucionMadera");

    _DevolucionMadera.fnInitDataTable_Detail();
}