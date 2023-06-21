"use strict";
var _bMandatos = {};
_bMandatos.url = urlLocalSigo + "General/Controles/buscarMandatos?";
_bMandatos.fnAsignarDatos = function (obj) { /*se implementa en cada llamada*/ }

_bMandatos.fnBuscarMandatos = function () {
    var valBuscar;

    valBuscar = _bMandatos.frm.find("#txtValor").val().trim();
 
    var url = _bMandatos.url + "&asBusValor=" + valBuscar;

    if (valBuscar == "") {
        utilSigo.toastWarning("Aviso", "Ingrese el dato de la persona a buscar");
        return false;
    }
    if (valBuscar.length < 3) {
        utilSigo.toastWarning("Aviso", "El dato de la persona a buscar debe ser mayor a dos caracteres");
        return false;
    }

    _bMandatos.dtBuscarMandatos.ajax.url(url).load(function (data) {
        if (data.success == false) {
            utilSigo.toastError("Error", "Sucedió un error al realizar la consulta, por favor comuníquese con el administrador");
            //console.log(data.er);
        }
    });
}

_bMandatos.fnInitEventos = function () {
    _bMandatos.frm.find("#btnBuscarMandatos").click(function () {
        _bMandatos.fnBuscarMandatos();
    });
    _bMandatos.frm.submit(function (e) {
        _bMandatos.fnBuscarMandatos();
        e.preventDefault();
    });

    _bMandatos.frm.find("#cboCriterio").change(function () {
        _bMandatos.frm.find("#txtValor").focus();
    });
}

_bMandatos.fnInitDataTable_Detail = function () {
    var columns_label = ["N°", "N° de Informe", "Título Habilitante", "Titular", "Modalidad", "Mandato", "", ""];
    var columns_data = [
        {
            "name": "ROW_INDE", "width": "2%", "orderable": false, "searchable": false, "mRender": function (data, type, row, meta) {
                return parseInt(meta.row) + 1 + meta.settings._iDisplayStart;
            }
        },
        { "data": "NUM_INFORME", "autoWidth": true },
        { "data": "TH_NUMERO", "autoWidth": true },
        { "data": "TITULAR_ACTUAL", "autoWidth": true },
        { "data": "MODALIDAD", "autoWidth": true },             
        { "data": "MANDATO", "autoWidth": true },             
        {
            "data": "", "width": "2%", "orderable": false, "searchable": false, "mRender": function (data, type, row) {
                return '<div><i class="fa fa-lg fa-check" style="cursor: pointer;color:forestgreen;" title="Seleccionar" onclick="_bMandatos.fnAsignarDatos(this)"></i>';
            }
        },
        { "data": "COD_SECUENCIAL", "visible": false },
        { "data": "COD_INFORME", "visible": false },
        { "data": "PLAZO_IMPL_DIA", "visible": false },
        { "data": "PLAZO_INF_DIA", "visible": false },
        { "data": "CUMPLIO_MANDATO", "visible": false },
        { "data": "OBSERVACION", "visible": false },
        { "data": "PRESENTA_INFORME_IMPL", "visible": false },
        { "data": "FECHA_PRESENT_INF", "visible": false },
        { "data": "PRESENTA_INFORME_DP", "visible": false }
    ];

    //**Cabecera**----
    var theadTable = "<tr>";
    for (var i = 0; i < columns_label.length; i++) {
        theadTable += '<th>' + columns_label[i] + '</th>';
    }
    theadTable += "</tr>";
    $("#tbBuscarMandatos").find("thead").append(theadTable);

    var optDt = { iLength: initSigo.pageLengthBuscar, aSort: [] };

    _bMandatos.dtBuscarMandatos = _bMandatos.frm.find("#tbBuscarMandatos").DataTable({
        processing: true,
        ServerSide: false,
        bFilter: false,
        bLengthChange: false,
        ordering: false,
        paging: true,
        bInfo: false,
        aaSorting: optDt.aSort,
        pageLength: optDt.iLength,
        oLanguage: initSigo.oLanguage,
        drawCallback: initSigo.showPagination,
        columns: columns_data
    });
}

_bMandatos.fnInit = function () {
    $('[data-toggle="tooltip"]').tooltip();    
    _bMandatos.frm = $("#frmBuscarMandatos");

    _bMandatos.frm.find("#cboCriterio").select2({ minimumResultsForSearch: -1 });
    $('.modal').on('shown.bs.modal', function () {
        _bMandatos.frm.find("#txtValor").focus();
    });

    _bMandatos.fnInitDataTable_Detail();
    _bMandatos.fnInitEventos();
   
}