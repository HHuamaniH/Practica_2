"use strict";
var _IntegracionDOCSIADO = {};
_IntegracionDOCSIADO.fnDescargar = function (obj) {
    var data = _IntegracionDOCSIADO.dtIntegracionDOCSIADO.row($(obj).parents('tr')).data();   
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
_IntegracionDOCSIADO.fnInitDataTable_Detail = function () {
    var columns_label = [], columns_data = [], options = {}, sSubCriterio = "", sCriterio = "", sValor = "", url = "";
    columns_label = ["Cod. Documento", "Sub Tipo", "Detalle Sub Tipo", "Número", "Fecha del Documento", "Descripción", "N° Trámite", "Origen"];
    columns_data = ["DETINV_CODDOC","SUBTIPO", "DETALLESUBTIPO", "NUMERO", "FECHA_DOCUMENTO", "DETINV_DESCRIPCION", "NUMEROTRAMITESITD", "ORIGEN"];
    options = {
        page_length: initSigo.pageLengthBuscar, row_download: true, row_fnDownload: "_IntegracionDOCSIADO.fnDescargar(this)", row_index: true
    };
    _IntegracionDOCSIADO.dtIntegracionDOCSIADO = utilDt.fnLoadDataTable_Detail(_IntegracionDOCSIADO.frm.find("#tbIntegracionDOCSIADO"), columns_label, columns_data, options);

    sCriterio = _IntegracionDOCSIADO.frm.find("#hdfCriterio").val();
    sSubCriterio = _IntegracionDOCSIADO.frm.find("#hdfSubCriterio").val();
    sValor = _IntegracionDOCSIADO.frm.find("#hdfValor").val();
    url = initSigo.urlControllerGeneral + "buscarIntegracionDOCSIADO?asCriterio=" + sCriterio + "&asSubCriterio=" + sSubCriterio + "&asValor=" + sValor;

    _IntegracionDOCSIADO.dtIntegracionDOCSIADO.ajax.url(url).load(function (data) {
        if (data.success == false) {
            utilSigo.toastError("Error", data.msj);
            console.log(data.msj);
        }
    });
}

_IntegracionDOCSIADO.fnInit = function () {
    _IntegracionDOCSIADO.frm = $("#dvFrmIntegracionDOCSIADO");
    _IntegracionDOCSIADO.fnInitDataTable_Detail();
}
$(document).ready(function () {
    _IntegracionDOCSIADO.fnInit();
});