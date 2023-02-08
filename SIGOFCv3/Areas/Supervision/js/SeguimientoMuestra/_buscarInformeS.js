"use strict";
var _bInformeMuestra = {};
_bInformeMuestra.url = urlLocalSigo + "SeguimientoMuestra/buscarInformeSupervision";
_bInformeMuestra.fnAsignarDatos = function (obj) {
    //se implementa en cada llamada
}
_bInformeMuestra.fnInitDataTablePaging = function (options) {
    var optDt = {};
    optDt.iLength =options.page_length;
    optDt.iStart = 0;
    optDt.bSearch = false;
    optDt.bInfo = true;
    optDt.bSort = true;   
    optDt.aSort = [];
    return $("#tbBuscarInforme").DataTable({
        processing: true,
        serverSide: true,
        searching: optDt.bSearch,
        ordering: optDt.bSort,
        deferLoading: 0, 
        paging: true,
        ajax: {
            "url": _bInformeMuestra.url,
            "data": function (d) {
                d.customSearchEnabled = true;
                d.customSearchForm = "INFORME_SUPERVISION_MODAL";
                d.customSearchType = _bInformeMuestra.frm.find("#cboCriterio").val();
                d.customSearchValue = _bInformeMuestra.frm.find("#txtValor").val().trim();
                for (var i = 0; i < d.order.length; i++) {
                    d.order[i]["column_name"] = d.columns[d.order[i]["column"]]["data"];
                }
                d.columns = null;
            },
            "error": function (jqXHR) {
                utilSigo.unblockUIGeneral();
                utilSigo.toastError("Error", initSigo.MessageError);
                console.log(jqXHR.responseText);
            }
        },
        columns: options.table_columns,
        bInfo: optDt.bInfo,
        "lengthMenu": [[10, 20, 50, 100], [10, 20, 50, 100]],
        "aaSorting": optDt.aSort,
        "pageLength": optDt.iLength,
        "displayStart": optDt.iStart,
        "oLanguage": initSigo.oLanguage,
        "drawCallback": initSigo.showPagination,
    });
}
//Búsqueda de registros
_bInformeMuestra.fnSearch = function () {
    _bInformeMuestra.dt.ajax.reload();
}
_bInformeMuestra.fnInitEventos = function () {
    _bInformeMuestra.frm.find("#btnBuscarInforme").click(function () {
        _bInformeMuestra.fnSearch();
        
    });
    _bInformeMuestra.frm.submit(function (e) {
        _bInformeMuestra.fnSearch();
        e.preventDefault();
    });
    _bInformeMuestra.frm.find("#cboCriterio").change(function () {
        _bInformeMuestra.frm.find("#txtValor").focus();

    });
 }
_bInformeMuestra.fnInit = function () {
   // $('[data-toggle="tooltip"]').tooltip();
    _bInformeMuestra.frm = $("#frmBuscarInforme"); 
    $('.modal').on('shown.bs.modal', function () {
        _bInformeMuestra.frm.find("#txtValor").focus();
    });
    _bInformeMuestra.fnInitEventos();
    var columns_label = [], columns_data = [], options = {};
    columns_label = ["Fecha de registro", "Nro Informe", "Nro CNotificación", "Modalidad", "Nro THabililitante", "Titular Supervisado",
        "Supervisor", "POA Supervisado"];
    columns_data = ["FECHA", "NUMERO", "NUM_CNOTIF", "MOD_T", "NUM_TH", "TITULAR", "AP_NOM", "POA"];
    options = {
        page_paging: true, page_length: 10, row_index: true, row_select: true, row_fnSelect: "_bInformeMuestra.fnAsignarDatos(this)",
        firstSelect:true,page_sort:false
    };
    utilDt.fnLoadDataTable_Detail($("#tbBuscarInforme"), columns_label, columns_data, options);
    _bInformeMuestra.dt = _bInformeMuestra.fnInitDataTablePaging(options);
}