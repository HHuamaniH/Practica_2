"use strict";
var _cMemSITD = {};
_cMemSITD.url = urlLocalSigo + "General/Controles/GetListaDocumentosMemSITDPaging?";
_cMemSITD.fnAsignarDatos = function (obj) {
    //se implementa en cada llamada
}
_cMemSITD.fnInitDataTablePaging = function (options) {
    var optDt = {};
    optDt.iLength = options.page_length;
    optDt.iStart = 0;
    optDt.bSearch = false;
    optDt.bInfo = true;
    optDt.bSort = true;
    optDt.aSort = [];
    return $("#tbBuscarDocumento").DataTable({
        processing: true,
        serverSide: true,
        searching: optDt.bSearch,
        ordering: optDt.bSort,
        paging: true,
        deferLoading: 0, 
        ajax: {
            "url": _cMemSITD.url,
            "data": function (d) {
                d.customSearchEnabled = true;
                d.customSearchForm = _cMemSITD.frm.find("#hdBusFormulario").val();
                d.customSearchType = _cMemSITD.frm.find("#cboCriterio").val();
                d.customSearchValue = _cMemSITD.frm.find("#txtValor").val().trim();
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
_cMemSITD.fnSearch = function () {
    var valorBuscar = _cMemSITD.frm.find("#txtValor").val().trim();
    if (valorBuscar == "") {
        utilSigo.toastWarning("Aviso", "Ingrese Valor a Buscar");
        return false;
    }
    if (valorBuscar.length < 3) {
        utilSigo.toastWarning("Aviso", "Ingrese mayor a dos caracteres");
        return false;
    }
    _cMemSITD.dt.ajax.reload();
}
_cMemSITD.fnInitEventos = function () {
    _cMemSITD.frm.find("#btnBuscar").click(function () {        
        _cMemSITD.fnSearch();

    });
    _cMemSITD.frm.submit(function (e) {
        _cMemSITD.fnSearch();
        e.preventDefault();
    });
    _cMemSITD.frm.find("#cboCriterio").change(function () {
        _cMemSITD.frm.find("#txtValor").focus();

    });
}
_cMemSITD.fnInit = function () {    
    _cMemSITD.frm = $("#frmConsultarDocSITD");
    $('.modal').on('shown.bs.modal', function () {
        _cMemSITD.frm.find("#txtValor").focus();
    });
    _cMemSITD.fnInitEventos();
    var columns_label = [], columns_data = [], options = {};
    columns_label = ["Codigo", "Fecha Doc","Asunto","Tipo Doc."];
    columns_data = ["cCodificacion", "fFecDocumento","cAsunto","cDescTipoDoc"];
    options = {
        page_paging: true, page_length: 10, row_index: true, row_select: true, row_fnSelect: "_cMemSITD.fnAsignarDatos(this)"  
          
    };
    utilDt.fnLoadDataTable_Detail($("#tbBuscarDocumento"), columns_label, columns_data, options);
    _cMemSITD.dt = _cMemSITD.fnInitDataTablePaging(options);
}