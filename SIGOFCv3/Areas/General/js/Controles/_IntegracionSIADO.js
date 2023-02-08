"use strict";
var _IntegracionSIADO = {};

_IntegracionSIADO.fnDescargar = function (obj) {
    var data = _IntegracionSIADO.dtIntegracionSIADO.row($(obj).parents('tr')).data();   
    var ss = urlLocalSigo + "General/Controles/DescargarIntegracionSIADO?fileName=" + data.DETINV_CODDOC + "&origen=" + data.ORIGEN;    
    var xhr = new XMLHttpRequest();
    xhr.onload = function () {          
        if (xhr.readyState == 4 && xhr.status == 200) {
            window.location.href = ss;
        }
        else if (xhr.status==404) {
            utilSigo.toastWarning("Aviso", "Sucedio un error, No existe la direccion de descarga");
        }
        else if (xhr.status == 0) {
            utilSigo.toastWarning("Aviso", "Sucedio un error, No existe el archivo");
        }
        else {
            utilSigo.toastWarning("Aviso", "Sucedio un error al descargar el archivo, Comuníquese con el Administrador");
        }  
    }
    xhr.open('head', ss);
    xhr.send(null);    
}
_IntegracionSIADO.fnInitDataTable_Detail = function () {
    var columns_label = [], columns_data = [], options = {}, sSubCriterio = "", sCriterio = "", sValor = "", url = "";
    columns_label = ["Cod. Documento", "Descripción", "Origen"];
    columns_data = ["DETINV_CODDOC", "DETINV_DESCRIPCION", "ORIGEN"];
    options = {
        page_length: initSigo.pageLengthBuscar, row_download: true, row_fnDownload: "_IntegracionSIADO.fnDescargar(this)", row_index: true
    };
    _IntegracionSIADO.dtIntegracionSIADO = utilDt.fnLoadDataTable_Detail(_IntegracionSIADO.frm.find("#tbIntegracionSIADO"), columns_label, columns_data, options);

    sCriterio = _IntegracionSIADO.frm.find("#hdfCriterio").val();
    sSubCriterio = _IntegracionSIADO.frm.find("#hdfSubCriterio").val();
    sValor = _IntegracionSIADO.frm.find("#hdfValor").val();
    url = initSigo.urlControllerGeneral + "buscarIntegracionSIADO?asCriterio=" + sCriterio + "&asSubCriterio=" + sSubCriterio + "&asValor=" + sValor;

    _IntegracionSIADO.dtIntegracionSIADO.ajax.url(url).load(function (data) {
        if (data.success == false) {
            utilSigo.toastError("Error", data.msj);
            console.log(data.msj);
        }
    });
}

_IntegracionSIADO.fnInit = function () {
    _IntegracionSIADO.frm = $("#dvFrmIntegracionSIADO");
    _IntegracionSIADO.fnInitDataTable_Detail();
}
$(document).ready(function () {
    _IntegracionSIADO.fnInit();
});