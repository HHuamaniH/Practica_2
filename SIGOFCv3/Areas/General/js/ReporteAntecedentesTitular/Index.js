"use strict";
var _reporte = {};

_reporte.valor;

_reporte.fnSearch = function () {
    var valorBusqueda = _reporte.frm.find("#txtBusquedaTitular").val().trim();

    if (valorBusqueda.trim() == "") {
        utilSigo.toastWarning("Aviso", "Ingrese datos a Buscar");
        _reporte.frm.find("#txtBusquedaTitular").focus();
        return false;
    }
    else {
        var cantCarateres = valorBusqueda.length;
        if (cantCarateres < 3) {
            utilSigo.toastWarning("Aviso", "Longitud del criterio de busqueda debe ser mayor a 2 caracteres");
            _reporte.frm.find("#txtBusquedaTitular").focus();
            return false;
        }
        _reporte.dtListTitular.ajax.reload(function () {
            var rows = _reporte.dtListTitular.rows().count();
            if (rows > 0) $("#dvListTitular").show();
            else $("#dvListTitular").hide();

            $("#dvReporte").hide();
            $("#dvExportaReporte").hide();
            $("#dvDetalleReporte").hide();
            _reporte.frm1.find("#hdfCodTitularReporte").val("");
        });
    }
};

_reporte.rptInitDataTable = function () {
    var columns_label = [], columns_data = [], options = {};

    //Tabla Principal
    columns_label = ["Nº", "Apellidos y Nombres", "Tipo Documento", "Nro. Documento", "Tipo Persona", ""];
    var columns = [
        {
            "name": "ROW_INDE", "width": "2%", "orderable": false, "searchable": false, "mRender": function (data, type, row, meta) {
                return parseInt(meta.row) + 1 + meta.settings._iDisplayStart;
            }
        },
        { "data": "APELLIDOS_NOMBRES", "autoWidth": true },
        { "data": "TIPO_DOCUMENTO", "autoWidth": true },
        { "data": "N_DOCUMENTO", "autoWidth": true },
        { "data": "TIPO_PERSONA", "autoWidth": true },
        {
            "data": "", "width": "2%", "orderable": false, "searchable": false, "mRender": function (data, type, row) {
                return '<div><i class="fa fa-lg fa-eye" style="color:black;cursor:pointer;" title="Observar" onclick="_reporte.fnGetReporte(\'' + row.COD_PERSONA + '\')"></i>';
            }
        }
    ];
    //**Cabecera**----
    var theadTable = "<tr>";
    for (var i = 0; i < columns_label.length; i++) {
        theadTable += '<th>' + columns_label[i] + '</th>';
    }
    theadTable += "</tr>";
    $("#tbListTitular").find("thead").append(theadTable);
    //**Cuerpo**----
    var optDt = { iLength: 6, iStart: 0, aSort: [] };

    _reporte.dtListTitular = $("#tbListTitular").DataTable({
        processing: true,
        serverSide: true,
        searching: false,
        ordering: true,
        paging: true,
        ajax: {
            "url": initSigo.urlControllerGeneral + "/GetListaGeneralPaging",
            "data": function (d) {
                d.customSearchEnabled = true;
                d.customSearchForm = _reporte.frm.find("#tipoFormulario").val(); 
                d.customSearchType = _reporte.frm.find("#ddlTipoBusquedaTitularId").val();
                d.customSearchValue = _reporte.frm.find("#txtBusquedaTitular").val();
                for (var i = 0; i < d.order.length; i++) {
                    d.order[i]["column_name"] = d.columns[d.order[i]["column"]]["data"];
                }
                d.columns = null;
            },
            "error": function (jqXHR) {
                utilSigo.unblockUIGeneral();
                utilSigo.toastError("Error", initSigo.MessageError);
                console.log(jqXHR.responseText);
            },
        },
        columns: columns,
        bInfo: true,
        "lengthMenu": [[10, 20, 50, 100], [10, 20, 50, 100]],
        "aaSorting": optDt.aSort,
        "pageLength": optDt.iLength,
        "displayStart": optDt.iStart,
        "oLanguage": initSigo.oLanguage,
        "drawCallback": initSigo.showPagination,
        "dom": 'Bfrtip'
    });

    //Tabla Reporte
    columns_label = ["Título Habilitante", "Modalidad de Aprovechamiento", "Infracciones Cometidas", "Sanción Impuesta", "Multa en UIT", "N° RD Término PAU",
        "Estado del Proceso Administrativo", "Fecha Notificación RD Término", "N° Resol. Tribunal", "Fecha Emisión Resol. Tribunal"];
    columns_data = ["NUM_THABILITANTE", "MODALIDAD", "INFRACCION", "SANCION", "MULTA", "RESOLUCION", "ESTADO_PAU", "FECHA_NOTIFICACION", "NUMRESOLUCIONFORESTAL", "FECRESOLUCIONFORESTAL"];
    options = {
        page_length: 10, row_index: true, page_sort: true
    };
    _reporte.dtReporte = utilDt.fnLoadDataTable_Detail(_reporte.frm1.find("#tbReporte"), columns_label, columns_data, options);
};

_reporte.fnGetReporte = function (codigo) {
    //console.log(codigo);
    var url = urlLocalSigo + "General/ReporteAntecedentesTitular/MostrarReporte";
    var option = { url: url, datos: JSON.stringify({ codpersona: codigo }), type: 'POST' };

    $("#dvReporte").hide();
    $("#dvExportaReporte").hide();
    $("#dvDetalleReporte").hide();
    _reporte.dtReporte.clear().draw();

    utilSigo.fnAjax(option, function (data) {
        if (data.success) {
            _reporte.frm1.find("label[for='lblDescripcionReporte']").text(data.texto);
            _reporte.frm1.find("#hdfCodTitularReporte").val(data.codpersona);
            $("#dvReporte").show();
            $("#dvExportaReporte").show();

            if (data.data.length>0) {
                _reporte.dtReporte.rows.add(data.data).draw();
                $("#dvDetalleReporte").show();
            }   
        }
        else {
            utilSigo.toastWarning("Aviso", "Sucedio un error, Comuníquese con el Administrador");
            console.log(data.msj);
        }
    });
};

_reporte.fnExportReportPDF = function () {
    window.location.href = urlLocalSigo + "General/ReporteAntecedentesTitular/GeneraReportePDF?codpersona=" + _reporte.frm1.find("#hdfCodTitularReporte").val();
    //var iframe = document.createElement("iframe");
    //iframe.src = urlLocalSigo + "General/ReporteAntecedentesTitular/GeneraReportePDF?codpersona=" + _reporte.frm1.find("#hdfCodTitularReporte").val();
    //iframe.style.display = "none";
    //$("#divIframe").html(iframe);
}

$(document).ready(function () {
    _reporte.frm = $("#frmBuscarTitular");
    _reporte.frm1 = $("#dvReporte");

    $.fn.select2.defaults.set("theme", "bootstrap4");
    _reporte.frm.find("#ddlTipoBusquedaTitularId").select2();
    _reporte.frm.find("#txtBusquedaTitular").focus();

    _reporte.rptInitDataTable();
});