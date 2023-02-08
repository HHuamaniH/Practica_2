"use strict";
var _cSITD = {};
_cSITD.url = urlLocalSigo + "General/Controles/GetListaDocumentosSITDPaging?";
_cSITD.fnAsignarDatos = function (obj) {
    //se implementa en cada llamada
}
_cSITD.fnInitDataTablePaging = function (options) {
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
            "url": _cSITD.url,
            "data": function (d) {
                d.customSearchEnabled = true;
                d.customSearchForm = _cSITD.frm.find("#hdBusFormulario").val();
                d.customSearchType = _cSITD.frm.find("#cboCriterio").val();
                d.customSearchValue = _cSITD.frm.find("#txtValor").val().trim();
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
_cSITD.fnSearch = function () {
    var valorBuscar = _cSITD.frm.find("#txtValor").val().trim();
    if (valorBuscar == "") {
        utilSigo.toastWarning("Aviso", "Ingrese Valor a Buscar");
        return false;
    }
    if (valorBuscar.length < 3) {
        utilSigo.toastWarning("Aviso", "Ingrese mayor a dos caracteres");
        return false;
    }
    _cSITD.dt.ajax.reload();
}
_cSITD.fnInitEventos = function () {
    _cSITD.frm.find("#btnBuscar").click(function () {        
        _cSITD.fnSearch();

    });
    _cSITD.frm.submit(function (e) {
        _cSITD.fnSearch();
        e.preventDefault();
    });
    _cSITD.frm.find("#cboCriterio").change(function () {
        _cSITD.frm.find("#txtValor").focus();

    });
}
_cSITD.fnInit = function () {    
    _cSITD.frm = $("#frmConsultarDocSITD");
    $('.modal').on('shown.bs.modal', function () {
        _cSITD.frm.find("#txtValor").focus();
    });
    _cSITD.fnInitEventos();
    var columns_label = [], columns_data = [], options = {};
    columns_label = ["Fecha Doc", "Codigo", "Nro Doumento","Tipo Doc"];
    columns_data = ["fFecDocumento", "cCodificacion", "cNroDocumento","cDescTipoDoc"];
    options = {
        page_paging: true, page_length: 10, row_index: true, row_select: true, row_fnSelect: "_cSITD.fnAsignarDatos(this)"  
          
    };
    utilDt.fnLoadDataTable_Detail($("#tbBuscarDocumento"), columns_label, columns_data, options);
    _cSITD.dt = _cSITD.fnInitDataTablePaging(options);
}