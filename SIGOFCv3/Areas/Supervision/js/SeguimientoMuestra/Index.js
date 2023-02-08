"use strict";
var ManSegMuestra = {};
ManSegMuestra.url = urlLocalSigo + "Supervision/SeguimientoMuestra/AddEdit";
ManSegMuestra.fnEdit = function (obj) {
    var $tr = $(obj).closest('tr');
    var dataRow = _ManGrillaPaging.dtManGrillaPaging.row($tr).data(); 
    window.location = ManSegMuestra.url + "?codSegMuestra=" + dataRow.COD_SEG_MUESTRA.trim();
}
ManSegMuestra.fnLoadManGrillaPaging = function () {
    var url = initSigo.urlControllerGeneral + "_ManGrillaPaging";
    var data = ManSegMuestra.frm.serializeObject();
    var option = { url: url, datos: JSON.stringify(data), type: 'POST', dataType: 'html' };
    var columns_label = [], columns_data = [], options = {};
    columns_label = ["Fecha de registro", "Cod Seguimiento","Nro SITD ", "Nro Informe", "Nro CNotificación", "Modalidad", "Nro THabililitante", "Titular Supervisado",
        "Supervisor", "POA Supervisado"];
    columns_data = ["FECHA", "COD_SEG_MUESTRA","CNRODOCUMENTO", "NUMERO", "NUM_CNOTIF", "MOD_T", "NUM_TH", "TITULAR", "AP_NOM", "POA"];
    options = {
        page_paging: true, page_length: 20, row_delete: true, row_fnDelete:"", row_index: true, row_edit: true,
        row_fnEdit: "ManSegMuestra.fnEdit(this)"
    };
    utilSigo.fnAjax(option, function (data) {
        ManSegMuestra.frm.find("#dvManSeguimientoMContenedor").html(data);
        _ManGrillaPaging.fnInit(columns_label, columns_data, options);       
        _ManGrillaPaging.fnCreate = function (obj, codTipoCN) {
            _ManGrillaPaging.fnReadConfigManGrillaPaging();
            window.location = ManSegMuestra.url;
        };
        $(document)
            .find('#btnDownload')
            .parent()
            .append('<a id="BTNDESINFORME" style="cursor:pointer;" data-toggle="tooltip" data-placement="top" title="" onclick="DescargarReporte()" data-original-title="Reporte"><span class="fa mx-2 fa-lg fa-download"></span></a>');
 
    });
}

function DescargarReporte() {
    var url = urlLocalSigo + "Supervision/SeguimientoMuestra/ExportarTabla";
    window.open(url, "_blank");
}

$(document).ready(function () {
    ManSegMuestra.frm = $("#frmManSeguimientoM");

    var alertaInicial = ManSegMuestra.frm.find("#alertaFormulario").val();
    if (alertaInicial != "") {
        utilSigo.toastSuccess("Aviso", alertaInicial);
    }
    ManSegMuestra.fnLoadManGrillaPaging();
});