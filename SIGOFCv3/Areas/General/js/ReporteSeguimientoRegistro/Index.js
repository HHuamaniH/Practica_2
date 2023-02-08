
"use strict";
var _reporte = {};

_reporte.lblTituloCabecera = "";
_reporte.rowMes = "";

_reporte.fnLoadTituloCabecera = function (titulo) {
    _reporte.lblTituloCabecera = titulo;
};

/*GENERAL*/
_reporte.fnSubmitForm = function () { /*Implementar de acuerdo al reporte consultado*/ }
/*******************Fin General********************/

/*FILTROS Reporte*/
_reporte.filter_lstChkAnioId_change = function () { /*Implementar de acuerdo al reporte consultado*/ }
/*******************Fin Filtros Reportes********************/

_reporte.filterAnioClearAllCheck = function () {
    for (var i = 1; i <= _reporte.frm.find("[id*=lstChkAnio]").length; i++) {
        if (i % 2 == 0)
            _reporte.frm.find("[id*=lstChkAnio]")[i - 1].checked = false;
    }
}
_reporte.filterAnioGetAllCheck = function () {
    var selectAnio = "";
    for (var i = 1; i <= _reporte.frm.find("[id*=lstChkAnio]").length; i++) {
        if (i % 2 == 0) {
            if (_reporte.frm.find("[id*=lstChkAnio]")[i - 1].checked) {
                selectAnio += selectAnio == "" ? "" : ",";
                selectAnio += _reporte.frm.find("[id*=lstChkAnio]")[i - 2].value;
            }
        }
    }
    _reporte.frm.find("#lstChkAnioId").val(selectAnio);
}
_reporte.filterValidate = function () {
    var sShow = "none";

    sShow = _reporte.frm.find("#dvFiltroAnio")[0].style.display;
    if (sShow == "") {
        if (_reporte.frm.find("#lstChkAnioId").val() == "") {
            utilSigo.toastWarning("Aviso", "Seleccione el año a consultar"); return false;
        }
    }

    return true;
}
_reporte.filterEvent = function () {
    //Mostrar y ocultar filtros
    $("#dvHideFiltro").click(function () {
        $("#dvHideFiltro").hide();
        $("#dvShowFiltro").show();
        $("#dvFiltro").hide();
    });
    $("#dvShowFiltro").click(function () {
        $("#dvHideFiltro").show();
        $("#dvShowFiltro").hide();
        $("#dvFiltro").show();
    });

    //Filtro: Año
    _reporte.frm.find("#chkAnioAll").change(function () {
        for (var i = 1; i <= _reporte.frm.find("[id*=lstChkAnio]").length; i++) {
            if (i % 2 == 0)
                _reporte.frm.find("[id*=lstChkAnio]")[i - 1].checked = $(this).is(":checked");
        }
        _reporte.filterAnioGetAllCheck();
        _reporte.filter_lstChkAnioId_change();
    });
    _reporte.frm.find("[id*=lstChkAnio]").change(function () {
        var isChecked = $(this).is(":checked");
        _reporte.filterAnioClearAllCheck();
        if (isChecked) {
            $(this).prop("checked", "checked");
        } else {
            $(this).prop("checked", "");
            _reporte.frm.find("#chkAnioAll").prop("checked", "");
        }

        _reporte.filterAnioGetAllCheck();
        _reporte.filter_lstChkAnioId_change();
    });
}

_reporte.fnInitFiltro = function () {
    _reporte.filterEvent();
}
/******************Fin Filtros*******************/

/*REPORTE 1 - Seguimiento Informes Supervisión*/
_reporte.rpt1InitDataTable = function () {
    var columns_label = [], columns_data = [], columns_event = [], options = {};

    //Tabla Resumen
    columns_label = ["Mes", "N° de supervisiones Itinerario", "N° de informes de supervisión", "N° de informes de supervisión con control de calidad conforme",
        "N° de informes digitalizados", "N° de informes remitidos a la DFFFS"];
    columns_event = ["fn(c2)", "", "", "", "", ""];
    columns_data = ["MES_NOMBRE", "PROGRAMADO", "SUPERVISADO", "SUPERVISADO_CA", "SUPERVISADO_DOC", "REMITIDOS"];
    options = {
        button_copy: true, button_csv: true, button_excel: true, button_pdf: true, button_print: true
        , export_title: $("#tbInfSupervisionMensual_Resumen").find("thead tr")[0].innerText.trim(), row_index: true
    };
    _reporte.dtInfSupervisionMensual_Resumen = utilDt.fnLoadDataTable_EventColumn($("#tbInfSupervisionMensual_Resumen"), columns_label, columns_data, columns_event, options);

    //Tabla Detalle
    columns_label = ["N°", "Mes", "Titular", "Título", "Modalidad", "Supervisor", "N° Informe", "Fecha de Supervisión", "Fecha de emisión", "Fecha registro SIGO",
        "Con Control de Calidad Conforme", "Fecha registro Control de calidad", "Estado del Documento", "Informe de supervisión digitalizado", "Doc", "Fecha de remisión a la DFFFS"];
    var columns = [
        /*{
            "name": "ROW_INDE", "width": "2%", "orderable": false, "searchable": false, "mRender": function (data, type, row, meta) {
                return parseInt(meta.row) + 1;
            }
        },*/
        { "name": "ROW_INDE", "width": "2%", "orderable": false, "searchable": false, "defaultContent": ""},
        { "data": "MES_NOMBRE", "autoWidth": true },
        { "data": "TITULAR", "autoWidth": true },
        { "data": "TITULO", "autoWidth": true },
        { "data": "TIPO_DOCUMENTO", "autoWidth": true },
        { "data": "SUPERVISOR", "autoWidth": true },
        { "data": "Numero_Inform", "autoWidth": true },
        {
            "data": "", "autoWidth": true, "orderable": false, "searchable": false, "mRender": function (data, type, row) {
                return row.FECHA_INICIO + ' - ' + row.FECHA_FIN;
            }
        },
        { "data": "FECHA_ENTREGA", "autoWidth": true },
        { "data": "FECHA", "autoWidth": true },
        { "data": "CONTROL_CALIDAD", "autoWidth": true },
        { "data": "FECHA_CCA", "autoWidth": true },
        { "data": "ESTADO_PAU", "autoWidth": true },
        { "data": "DIGITALIZADO", "autoWidth": true },
        {
            "data": "", "width": "2%", "orderable": false, "searchable": false, "mRender": function (data, type, row) {
                if (row.CODIGO.trim() != "")
                    return '<div><i class="fa fa-lg fa-download" style="cursor:pointer;color:dodgerblue;" onclick="_reporte.fnValidaDocSIADO(\'' + row.CODIGO.trim() + '\')"></i>';
                else return "";
            }
        },
        { "data": "FECHA_DERIVACION", "autoWidth": true }
    ];

    //**Cabecera**----
    var theadTable = "<tr>";
    for (var i = 0; i < columns_label.length; i++) {
        theadTable += '<th>' + columns_label[i] + '</th>';
    }
    theadTable += "</tr>";
    $("#tbInfSupervisionMensual_Detalle").find("thead").append(theadTable);
    //**Cuerpo**----
    var optDt = { iLength: 20, iStart: 0, aSort: [] };
    var columns_hide = [14];

    _reporte.dtInfSupervisionMensual_Detalle = $("#tbInfSupervisionMensual_Detalle").DataTable({
        processing: true,
        searching: false,
        ordering: true,
        paging: true,
        ajax: {
            "url": urlLocalSigo + "General/ReporteSeguimientoRegistro/DetalleReporte",
            "data": function (params) {
                params.lstChkMesId = _reporte.rowMes;
                params.lstChkAnioId = _reporte.frm.find("#lstChkAnioId").val();
                params.hdfTipoReporte = "INFSUPERVISION_DETALLE";
            },
            "type": "POST",
            "error": function (jqXHR) {
                utilSigo.unblockUIGeneral();
                utilSigo.toastError("Error", initSigo.MessageError);
                console.log(jqXHR.responseText);
            },
        },
        columns: columns,
        bInfo: true,
        "aaSorting": optDt.aSort,
        "pageLength": optDt.iLength,
        "displayStart": optDt.iStart,
        "oLanguage": initSigo.oLanguage,
        "drawCallback": initSigo.showPagination,
        "dom": 'Bfrtip',
        "buttons": [{ extend: 'copyHtml5', footer: true, text: 'Copiar', title: _reporte.lblTituloCabecera, exportOptions: { columns: columns_hide }, messageTop: $("#tbInfSupervisionMensual_Detalle").find("thead tr")[0].innerText.trim() },
            { extend: 'csvHtml5', footer: true, text: 'CSV', title: _reporte.lblTituloCabecera, exportOptions: { columns: columns_hide }, messageTop: $("#tbInfSupervisionMensual_Detalle").find("thead tr")[0].innerText.trim()},
            { extend: 'excelHtml5', footer: true, text: 'Excel', title: _reporte.lblTituloCabecera, exportOptions: { columns: columns_hide }, messageTop: $("#tbInfSupervisionMensual_Detalle").find("thead tr")[0].innerText.trim()},
            { extend: 'pdfHtml5', footer: true, text: 'PDF', title: _reporte.lblTituloCabecera, orientation: 'landscape', pageSize: 'LEGAL', exportOptions: { columns: columns_hide }, messageTop: $("#tbInfSupervisionMensual_Detalle").find("thead tr")[0].innerText.trim()},
            { extend: 'print', footer: true, text: 'Imprimir', title: _reporte.lblTituloCabecera, exportOptions: { columns: columns_hide }, messageTop: $("#tbInfSupervisionMensual_Detalle").find("thead tr")[0].innerText.trim() }]
    });

    _reporte.dtInfSupervisionMensual_Detalle.on('order.dt search.dt', function () {
        _reporte.dtInfSupervisionMensual_Detalle.column(0, { search: 'applied', order: 'applied' }).nodes().each(function (cell, i) {
            cell.innerHTML = i + 1;
            _reporte.dtInfSupervisionMensual_Detalle.cell(cell).invalidate('dom');
        });
    }).draw();
}

_reporte.fnInitInfSupervision = function () {
    var chartInfSupervisionMensual_Resumen = null;

    //Activar Filtros
    _reporte.frm.find("#dvFiltroAnio").show();
    $("#dvInfSupervisionMensual").show();

    _reporte.rpt1InitDataTable();
    //Implementar eventos a ejecutar despúes de realizar una acción
    var fnLimpiarReporte = function () {
        _reporte.dtInfSupervisionMensual_Resumen.clear().draw();
        _reporte.dtInfSupervisionMensual_Detalle.clear().draw();
        _reporte.rowMes = "";
        var tb = $("#tbInfSupervisionMensual_Resumen");
        tb.find("#col3").text(0); tb.find("#col4").text(0); tb.find("#col5").text(0); tb.find("#col6").text(0); tb.find("#col7").text(0);

        if (chartInfSupervisionMensual_Resumen != null) {
            chartInfSupervisionMensual_Resumen.clear();
            $("#cnvInfSuspervisionMensual_Resumen").hide();
        }
    }

    _reporte.filter_lstChkAnioId_change = function () {
        fnLimpiarReporte();
    }

    _reporte.fnSubmitForm = function () {
        _reporte.dtInfSupervisionMensual_Resumen.clear().draw();
        _reporte.dtInfSupervisionMensual_Detalle.clear().draw();
        if (_reporte.filterValidate()) {
            var datosReporte = _reporte.frm.serializeObject();
            var option = { url: _reporte.frm.attr("action"), datos: JSON.stringify(datosReporte), type: 'POST' };

            utilSigo.fnAjax(option, function (data) {
                if (data.success) {
                    _reporte.dtInfSupervisionMensual_Resumen.rows.add(data.data).draw();

                    var c3 = 0, c4 = 0, c5 = 0, c6 = 0, c7 = 0;
                    for (var i = 0; i < data.data.length; i++) {
                        c3 += parseInt(data.data[i]["PROGRAMADO"]); c4 += parseInt(data.data[i]["SUPERVISADO"]);
                        c5 += parseInt(data.data[i]["SUPERVISADO_CA"]); c6 += parseInt(data.data[i]["SUPERVISADO_DOC"]);
                        c7 += parseInt(data.data[i]["REMITIDOS"]);
                    }

                    var tb = $("#tbInfSupervisionMensual_Resumen");
                    tb.find("#col3").text(c3); tb.find("#col4").text(c4); tb.find("#col5").text(c5); tb.find("#col6").text(c6); tb.find("#col7").text(c7);

                    $("#cnvInfSuspervisionMensual_Resumen").show();
                    chartInfSupervisionMensual_Resumen = customChart.LoadBarraSimple_DataTable(_reporte.dtInfSupervisionMensual_Resumen, "MES_NOMBRE", { colIndex: [2, 3, 4, 5, 6], data: ["PROGRAMADO", "SUPERVISADO", "SUPERVISADO_CA", "SUPERVISADO_DOC", "REMITIDOS"], color: ["green", "blue", "red", "yellow", "black"] }, { title: "", canvas: "cnvInfSuspervisionMensual_Resumen" });
                }
                else {
                    utilSigo.toastWarning("Aviso", "Sucedio un error, Comuníquese con el Administrador");
                    console.log(data.msj);
                }
            });
        }

        return false;
    }

    utilDt.fnEventColumn = function (obj, col) {
        var numMes = "";

        if (obj != "") {
            numMes = _reporte.dtInfSupervisionMensual_Resumen.row($(obj).parents('tr')).data()["MES_"];
            _reporte.rowMes = numMes;
        }

        if (_reporte.filterValidate()) {
            _reporte.dtInfSupervisionMensual_Detalle.ajax.reload();
        }

        return false;
    }
}
/******************Fin Reporte 1*****************/ 

/*REPORTE 2 - Seguimiento Informes Suspensión*/
_reporte.rpt2InitDataTable = function () {
    var columns_label = [], columns_data = [], columns_event = [], options = {};

    //Tabla Resumen
    columns_label = ["Mes", "N° de suspensiones", "N° de informes de suspensión", "N° de informes de suspensión con control de calidad conforme", "N° de informes digitalizados", "N° de informes remitidos a la DFFFS"];
    columns_event = ["fn(c2)", "", "", "", "", ""];
    columns_data = ["MES_NOMBRE", "PROGRAMADO", "SUPERVISADO", "SUPERVISADO_CA", "SUPERVISADO_DOC","REMITIDOS"];
    options = {
        button_copy: true, button_csv: true, button_excel: true, button_pdf: true, button_print: true
        , export_title: $("#tbInfSuspensionMensual_Resumen").find("thead tr")[0].innerText.trim(), row_index: true
    };
    _reporte.dtInfSuspensionMensual_Resumen = utilDt.fnLoadDataTable_EventColumn($("#tbInfSuspensionMensual_Resumen"), columns_label, columns_data, columns_event, options);

    //Tabla Detalle
    columns_label = ["N°", "Mes", "Titular", "Título", "Modalidad", "Supervisor", "N° Informe de Suspensión", "Fecha de emisión", "Fecha registro SIGO", "Con Control de Calidad Conforme",
        "Fecha registro Control de calidad", "Estado del Documento", "Informe de supervisión digitalizado", "Doc", "Fecha de remisión a la DFFFS"];
    var columns = [
        { "name": "ROW_INDE", "width": "2%", "orderable": false, "searchable": false, "defaultContent": "" },
        { "data": "MES_NOMBRE", "autoWidth": true },
        { "data": "TITULAR", "autoWidth": true },
        { "data": "TITULO", "autoWidth": true },
        { "data": "TIPO_DOCUMENTO", "autoWidth": true },
        { "data": "SUPERVISOR", "autoWidth": true },
        { "data": "Numero_Inform", "autoWidth": true },
        { "data": "FECHA_ENTREGA", "autoWidth": true },
        { "data": "FECHA", "autoWidth": true },
        { "data": "CONTROL_CALIDAD", "autoWidth": true },
        { "data": "FECHA_CCA", "autoWidth": true },
        { "data": "ESTADO_PAU", "autoWidth": true },
        { "data": "DIGITALIZADO", "autoWidth": true },
        {
            "data": "", "width": "2%", "orderable": false, "searchable": false, "mRender": function (data, type, row) {
                if (row.CODIGO.trim() != "")
                    return '<div><i class="fa fa-lg fa-download" style="cursor:pointer;color:dodgerblue;" onclick="_reporte.fnValidaDocSIADO(\'' + row.CODIGO.trim() + '\')"></i>';
                else return "";
            }
        },
        { "data": "FECHA_DERIVACION", "autoWidth": true }
    ];

    //**Cabecera**----
    var theadTable = "<tr>";
    for (var i = 0; i < columns_label.length; i++) {
        theadTable += '<th>' + columns_label[i] + '</th>';
    }
    theadTable += "</tr>";
    $("#tbInfSuspensionMensual_Detalle").find("thead").append(theadTable);
    //**Cuerpo**----
    var optDt = { iLength: 20, iStart: 0, aSort: [] };
    var columns_hide = [13];

    _reporte.dtInfSuspensionMensual_Detalle = $("#tbInfSuspensionMensual_Detalle").DataTable({
        processing: true,
        searching: false,
        ordering: true,
        paging: true,
        ajax: {
            "url": urlLocalSigo + "General/ReporteSeguimientoRegistro/DetalleReporte",
            "data": function (params) {
                params.lstChkMesId = _reporte.rowMes;
                params.lstChkAnioId = _reporte.frm.find("#lstChkAnioId").val();
                params.hdfTipoReporte = "INFSUSPENSION_DETALLE";
            },
            "type": "POST",
            "error": function (jqXHR) {
                utilSigo.unblockUIGeneral();
                utilSigo.toastError("Error", initSigo.MessageError);
                console.log(jqXHR.responseText);
            }
        },
        columns: columns,
        bInfo: true,
        "lengthMenu": [[10, 20, 50, 100], [10, 20, 50, 100]],
        "aaSorting": optDt.aSort,
        "pageLength": optDt.iLength,
        "displayStart": optDt.iStart,
        "oLanguage": initSigo.oLanguage,
        "drawCallback": initSigo.showPagination,
        "dom": 'Bfrtip',
        "buttons": [{ extend: 'copyHtml5', footer: true, text: 'Copiar', title: _reporte.lblTituloCabecera, exportOptions: { columns: columns_hide }, messageTop: $("#tbInfSuspensionMensual_Detalle").find("thead tr")[0].innerText.trim() },
            { extend: 'csvHtml5', footer: true, text: 'CSV', title: _reporte.lblTituloCabecera, exportOptions: { columns: columns_hide }, messageTop: $("#tbInfSuspensionMensual_Detalle").find("thead tr")[0].innerText.trim() },
            { extend: 'excelHtml5', footer: true, text: 'Excel', title: _reporte.lblTituloCabecera, exportOptions: { columns: columns_hide }, messageTop: $("#tbInfSuspensionMensual_Detalle").find("thead tr")[0].innerText.trim() },
            { extend: 'pdfHtml5', footer: true, text: 'PDF', title: _reporte.lblTituloCabecera, orientation: 'landscape', pageSize: 'LEGAL', exportOptions: { columns: columns_hide }, messageTop: $("#tbInfSuspensionMensual_Detalle").find("thead tr")[0].innerText.trim() },
            { extend: 'print', footer: true, text: 'Imprimir', title: _reporte.lblTituloCabecera, exportOptions: { columns: columns_hide }, messageTop: $("#tbInfSuspensionMensual_Detalle").find("thead tr")[0].innerText.trim() }]
    });

    _reporte.dtInfSuspensionMensual_Detalle.on('order.dt search.dt', function () {
        _reporte.dtInfSuspensionMensual_Detalle.column(0, { search: 'applied', order: 'applied' }).nodes().each(function (cell, i) {
            cell.innerHTML = i + 1;
            _reporte.dtInfSuspensionMensual_Detalle.cell(cell).invalidate('dom');
        });
    }).draw();
}

_reporte.fnInitInfSuspension = function () {
    var chartInfSuspensionMensual_Resumen = null;

    //Activar Filtros
    _reporte.frm.find("#dvFiltroAnio").show();
    $("#dvInfSuspensionMensual").show();

    _reporte.rpt2InitDataTable();
    //Implementar eventos a ejecutar despúes de realizar una acción
    var fnLimpiarReporte = function () {
        _reporte.dtInfSuspensionMensual_Resumen.clear().draw();
        _reporte.dtInfSuspensionMensual_Detalle.clear().draw();
        _reporte.rowMes = "";
        var tb = $("#tbInfSuspensionMensual_Resumen");
        tb.find("#col3").text(0); tb.find("#col4").text(0); tb.find("#col5").text(0); tb.find("#col6").text(0); tb.find("#col7").text(0);

        if (chartInfSuspensionMensual_Resumen != null) {
            chartInfSuspensionMensual_Resumen.clear();
            $("#cnvInfSuspensionMensual_Resumen").hide();
        }
    }

    _reporte.filter_lstChkAnioId_change = function () {
        fnLimpiarReporte();
    }

    _reporte.fnSubmitForm = function () {
        _reporte.dtInfSuspensionMensual_Resumen.clear().draw();
        _reporte.dtInfSuspensionMensual_Detalle.clear().draw();
        if (_reporte.filterValidate()) {
            var datosReporte = _reporte.frm.serializeObject();
            var option = { url: _reporte.frm.attr("action"), datos: JSON.stringify(datosReporte), type: 'POST' };

            utilSigo.fnAjax(option, function (data) {
                if (data.success) {
                    _reporte.dtInfSuspensionMensual_Resumen.rows.add(data.data).draw();

                    var c3 = 0, c4 = 0, c5 = 0, c6 = 0, c7 = 0;
                    for (var i = 0; i < data.data.length; i++) {
                        c3 += parseInt(data.data[i]["PROGRAMADO"]); c4 += parseInt(data.data[i]["SUPERVISADO"]);
                        c5 += parseInt(data.data[i]["SUPERVISADO_CA"]); c6 += parseInt(data.data[i]["SUPERVISADO_DOC"]);
                        c7 += parseInt(data.data[i]["REMITIDOS"]);
                    }

                    var tb = $("#tbInfSuspensionMensual_Resumen");
                    tb.find("#col3").text(c3); tb.find("#col4").text(c4); tb.find("#col5").text(c5); tb.find("#col6").text(c6); tb.find("#col7").text(c7);

                    $("#cnvInfSuspensionMensual_Resumen").show();
                    chartInfSuspensionMensual_Resumen = customChart.LoadBarraSimple_DataTable(_reporte.dtInfSuspensionMensual_Resumen, "MES_NOMBRE", { colIndex: [2, 3, 4, 5, 6], data: ["PROGRAMADO", "SUPERVISADO", "SUPERVISADO_CA", "SUPERVISADO_DOC", "REMITIDOS"], color: ["green", "blue", "red", "yellow", "black"] }, { title: "", canvas: "cnvInfSuspensionMensual_Resumen" });
                }
                else {
                    utilSigo.toastWarning("Aviso", "Sucedio un error, Comuníquese con el Administrador");
                    console.log(data.msj);
                }
            });
        }

        return false;
    }

    utilDt.fnEventColumn = function (obj, col) {
        var numMes = "";

        if (obj != "") {
            numMes = _reporte.dtInfSuspensionMensual_Resumen.row($(obj).parents('tr')).data()["MES_"];
            _reporte.rowMes = numMes;
        }

        if (_reporte.filterValidate()) {
            _reporte.dtInfSuspensionMensual_Detalle.ajax.reload();
        }

        return false;
    }
}
/******************Fin Reporte 2*****************/

/*REPORTE 3 - Seguimiento Informes Quinquenales*/
_reporte.rpt3InitDataTable = function () {
    var columns_label = [], columns_data = [], columns_event = [], options = {};

    //Tabla Resumen
    columns_label = ["Mes", "N° auditorías quinquenales iniciadas", "N° de informes de auditoría quinquenal", "N° de informes de auditoría quinquenal con control de calidad conforme", "N° de informes de auditoría quinquenales digitalizados", "N° de informes de auditoría quinquenales remitidos a la DFFFS"];
    columns_event = ["fn(c2)", "", "", "", "", ""];
    columns_data = ["MES_NOMBRE", "PROGRAMADO", "SUPERVISADO", "SUPERVISADO_CA", "SUPERVISADO_DOC", "REMITIDOS"];
    options = {
        button_copy: true, button_csv: true, button_excel: true, button_pdf: true, button_print: true
        , export_title: $("#tbInfQuinquenalMensual_Resumen").find("thead tr")[0].innerText.trim(), row_index: true
    };
    _reporte.dtInfQuinquenalMensual_Resumen = utilDt.fnLoadDataTable_EventColumn($("#tbInfQuinquenalMensual_Resumen"), columns_label, columns_data, columns_event, options);

    //Tabla Detalle
    columns_label = ["N°", "Mes", "Titular", "Título", "Equipo auditor", "Fecha de inicio auditoría", "N° Informe final de auditoría", "Fecha de emisión del informe", "Con Control de Calidad Conforme", "Fecha registro Control de calidad",
        "Estado del Documento", "Informe de supervisión digitalizado", "Doc", "Fecha de remisión a la DFFFS"];
    var columns = [
        { "name": "ROW_INDE", "width": "2%", "orderable": false, "searchable": false, "defaultContent": "" },
        { "data": "MES_NOMBRE", "autoWidth": true },
        { "data": "TITULAR", "autoWidth": true },
        { "data": "TITULO", "autoWidth": true },
        { "data": "SUPERVISOR", "autoWidth": true },
        { "data": "FECHA_INICIO", "autoWidth": true },
        { "data": "Numero_Inform", "autoWidth": true },
        { "data": "FECHA", "autoWidth": true },
        { "data": "CONTROL_CALIDAD", "autoWidth": true },
        { "data": "FECHA_CCA", "autoWidth": true },
        { "data": "ESTADO_PAU", "autoWidth": true },
        { "data": "DIGITALIZADO", "autoWidth": true },
        {
            "data": "", "width": "2%", "orderable": false, "searchable": false, "mRender": function (data, type, row) {
                if (row.CODIGO.trim() != "")
                    return '<div><i class="fa fa-lg fa-download" style="cursor:pointer;color:dodgerblue;" onclick="_reporte.fnValidaDocSIADO(\'' + row.CODIGO.trim() + '\')"></i>';
                else return "";
            }
        },
        { "data": "FECHA_DERIVACION", "autoWidth": true }
    ];

    //**Cabecera**----
    var theadTable = "<tr>";
    for (var i = 0; i < columns_label.length; i++) {
        theadTable += '<th>' + columns_label[i] + '</th>';
    }
    theadTable += "</tr>";
    $("#tbInfQuinquenalMensual_Detalle").find("thead").append(theadTable);
    //**Cuerpo**----
    var optDt = { iLength: 20, iStart: 0, aSort: [] };
    var columns_hide = [12];

    _reporte.dtInfQuinquenalMensual_Detalle = $("#tbInfQuinquenalMensual_Detalle").DataTable({
        processing: true,
        searching: false,
        ordering: true,
        paging: true,
        ajax: {
            "url": urlLocalSigo + "General/ReporteSeguimientoRegistro/DetalleReporte",
            "data": function (params) {
                params.lstChkMesId = _reporte.rowMes;
                params.lstChkAnioId = _reporte.frm.find("#lstChkAnioId").val();
                params.hdfTipoReporte = "INFQUINQUENAL_DETALLE";
            },
            "type": "POST",
            "error": function (jqXHR) {
                utilSigo.unblockUIGeneral();
                utilSigo.toastError("Error", initSigo.MessageError);
                console.log(jqXHR.responseText);
            }
        },
        columns: columns,
        bInfo: true,
        "lengthMenu": [[10, 20, 50, 100], [10, 20, 50, 100]],
        "aaSorting": optDt.aSort,
        "pageLength": optDt.iLength,
        "displayStart": optDt.iStart,
        "oLanguage": initSigo.oLanguage,
        "drawCallback": initSigo.showPagination,
        "dom": 'Bfrtip',
        "buttons": [{ extend: 'copyHtml5', footer: true, text: 'Copiar', title: _reporte.lblTituloCabecera, exportOptions: { columns: columns_hide }, messageTop: $("#tbInfQuinquenalMensual_Detalle").find("thead tr")[0].innerText.trim() },
            { extend: 'csvHtml5', footer: true, text: 'CSV', title: _reporte.lblTituloCabecera, exportOptions: { columns: columns_hide }, messageTop: $("#tbInfQuinquenalMensual_Detalle").find("thead tr")[0].innerText.trim() },
            { extend: 'excelHtml5', footer: true, text: 'Excel', title: _reporte.lblTituloCabecera, exportOptions: { columns: columns_hide }, messageTop: $("#tbInfQuinquenalMensual_Detalle").find("thead tr")[0].innerText.trim() },
            { extend: 'pdfHtml5', footer: true, text: 'PDF', title: _reporte.lblTituloCabecera, orientation: 'landscape', pageSize: 'LEGAL', exportOptions: { columns: columns_hide }, messageTop: $("#tbInfQuinquenalMensual_Detalle").find("thead tr")[0].innerText.trim() },
            { extend: 'print', footer: true, text: 'Imprimir', title: _reporte.lblTituloCabecera, exportOptions: { columns: columns_hide }, messageTop: $("#tbInfQuinquenalMensual_Detalle").find("thead tr")[0].innerText.trim() }]
    });

    _reporte.dtInfQuinquenalMensual_Detalle.on('order.dt search.dt', function () {
        _reporte.dtInfQuinquenalMensual_Detalle.column(0, { search: 'applied', order: 'applied' }).nodes().each(function (cell, i) {
            cell.innerHTML = i + 1;
            _reporte.dtInfQuinquenalMensual_Detalle.cell(cell).invalidate('dom');
        });
    }).draw();
}

_reporte.fnInitInfQuinquenal = function () {
    var chartInfQuinquenalMensual_Resumen = null;

    //Activar Filtros
    _reporte.frm.find("#dvFiltroAnio").show();
    $("#dvInfQuinquenalMensual").show();

    _reporte.rpt3InitDataTable();
    //Implementar eventos a ejecutar despúes de realizar una acción
    var fnLimpiarReporte = function () {
        _reporte.dtInfQuinquenalMensual_Resumen.clear().draw();
        _reporte.dtInfQuinquenalMensual_Detalle.clear().draw();
        _reporte.rowMes = "";
        var tb = $("#tbInfQuinquenalMensual_Resumen");
        tb.find("#col3").text(0); tb.find("#col4").text(0); tb.find("#col5").text(0); tb.find("#col6").text(0); tb.find("#col7").text(0);

        if (chartInfQuinquenalMensual_Resumen != null) {
            chartInfQuinquenalMensual_Resumen.clear();
            $("#cnvInfQuinquenalMensual_Resumen").hide();
        }
    }

    _reporte.filter_lstChkAnioId_change = function () {
        fnLimpiarReporte();
    }

    _reporte.fnSubmitForm = function () {
        _reporte.dtInfQuinquenalMensual_Resumen.clear().draw();
        _reporte.dtInfQuinquenalMensual_Detalle.clear().draw();
        if (_reporte.filterValidate()) {
            var datosReporte = _reporte.frm.serializeObject();
            var option = { url: _reporte.frm.attr("action"), datos: JSON.stringify(datosReporte), type: 'POST' };

            utilSigo.fnAjax(option, function (data) {
                if (data.success) {
                    _reporte.dtInfQuinquenalMensual_Resumen.rows.add(data.data).draw();

                    var c3 = 0, c4 = 0, c5 = 0, c6 = 0, c7 = 0;
                    for (var i = 0; i < data.data.length; i++) {
                        c3 += parseInt(data.data[i]["PROGRAMADO"]); c4 += parseInt(data.data[i]["SUPERVISADO"]);
                        c5 += parseInt(data.data[i]["SUPERVISADO_CA"]); c6 += parseInt(data.data[i]["SUPERVISADO_DOC"]);
                        c7 += parseInt(data.data[i]["REMITIDOS"]);
                    }

                    var tb = $("#tbInfQuinquenalMensual_Resumen");
                    tb.find("#col3").text(c3); tb.find("#col4").text(c4); tb.find("#col5").text(c5); tb.find("#col6").text(c6); tb.find("#col7").text(c7);

                    $("#cnvInfQuinquenalMensual_Resumen").show();
                    chartInfQuinquenalMensual_Resumen = customChart.LoadBarraSimple_DataTable(_reporte.dtInfQuinquenalMensual_Resumen, "MES_NOMBRE", { colIndex: [2, 3, 4, 5, 6], data: ["PROGRAMADO", "SUPERVISADO", "SUPERVISADO_CA", "SUPERVISADO_DOC", "REMITIDOS"], color: ["green", "blue", "red", "yellow", "black"] }, { title: "", canvas: "cnvInfQuinquenalMensual_Resumen" });
                }
                else {
                    utilSigo.toastWarning("Aviso", "Sucedio un error, Comuníquese con el Administrador");
                    console.log(data.msj);
                }
            });
        }

        return false;
    }

    utilDt.fnEventColumn = function (obj, col) {
        var numMes = "";

        if (obj != "") {
            numMes = _reporte.dtInfQuinquenalMensual_Resumen.row($(obj).parents('tr')).data()["MES_"];
            _reporte.rowMes = numMes;
        }

        if (_reporte.filterValidate()) {
            _reporte.dtInfQuinquenalMensual_Detalle.ajax.reload();
        }

        return false;
    }
}
/******************Fin Reporte 3*****************/

/*REPORTE 4 - Seguimiento de Informes de verificación de medidas correctivas*/
_reporte.rpt4InitDataTable = function () {
    var columns_label = [], columns_data = [], columns_event = [], options = {};

    //Tabla Resumen
    columns_label = ["Mes", "N° de informes de verificación medidas correctivas", "N° de informes de verificación medidas correctivas con control de calidad conforme", "N° de informes de verificación medidas correctivas digitalizados", "N° de informes de verificación medidas correctivas remitidos a la DFFFS"];
    columns_event = ["fn(c2)", "", "", "", ""];
    columns_data = ["MES_NOMBRE", "SUPERVISADO", "SUPERVISADO_CA", "SUPERVISADO_DOC", "REMITIDOS"];
    options = {
        button_copy: true, button_csv: true, button_excel: true, button_pdf: true, button_print: true
        , export_title: $("#tbInfVMCMensual_Resumen").find("thead tr")[0].innerText.trim(), row_index: true
    };
    _reporte.dtInfVMCMensual_Resumen = utilDt.fnLoadDataTable_EventColumn($("#tbInfVMCMensual_Resumen"), columns_label, columns_data, columns_event, options);

    //Tabla Detalle
    columns_label = ["N°", "Mes", "N° Informe de verificación medidas correctivas", "Fecha registro SIGO", "Titular", "Título", "Fecha de inicio", "Fecha registro SIGO", "Con Control de Calidad Conforme",
        "Fecha registro Control de calidad", "Estado del Documento", "Informe de supervisión digitalizado", "Doc", "Fecha de remisión a la DFFFS"];
    var columns = [
        { "name": "ROW_INDE", "width": "2%", "orderable": false, "searchable": false, "defaultContent": "" },
        { "data": "MES_NOMBRE", "autoWidth": true },
        { "data": "NUMERO_RD", "autoWidth": true },
        { "data": "FECHA", "autoWidth": true },
        { "data": "TITULAR", "autoWidth": true },
        { "data": "TITULO", "autoWidth": true },
        { "data": "FECHA_EMISION", "autoWidth": true },
        { "data": "FECHA", "autoWidth": true },
        { "data": "CONTROL_CALIDAD", "autoWidth": true },
        { "data": "FECHA_CCA", "autoWidth": true },
        { "data": "ESTADO_PAU", "autoWidth": true },
        { "data": "DIGITALIZADO", "autoWidth": true },
        {
            "data": "", "width": "2%", "orderable": false, "searchable": false, "mRender": function (data, type, row) {
                if (row.CODIGO.trim() != "")
                    return '<div><i class="fa fa-lg fa-download" style="cursor:pointer;color:dodgerblue;" onclick="_reporte.fnValidaDocSIADO(\'' + row.CODIGO.trim() + '\')"></i>';
                else return "";
            }
        },
        { "data": "FECHA_DERIVACION", "autoWidth": true }
    ];

    //**Cabecera**----
    var theadTable = "<tr>";
    for (var i = 0; i < columns_label.length; i++) {
        theadTable += '<th>' + columns_label[i] + '</th>';
    }
    theadTable += "</tr>";
    $("#tbInfVMCMensual_Detalle").find("thead").append(theadTable);
    //**Cuerpo**----
    var optDt = { iLength: 20, iStart: 0, aSort: [] };
    var columns_hide = [12];

    _reporte.dtInfVMCMensual_Detalle = $("#tbInfVMCMensual_Detalle").DataTable({
        processing: true,
        searching: false,
        ordering: true,
        paging: true,
        ajax: {
            "url": urlLocalSigo + "General/ReporteSeguimientoRegistro/DetalleReporte",
            "data": function (params) {
                params.lstChkMesId = _reporte.rowMes;
                params.lstChkAnioId = _reporte.frm.find("#lstChkAnioId").val();
                params.hdfTipoReporte = "VMC_DETALLE";
            },
            "type": "POST",
            "error": function (jqXHR) {
                utilSigo.unblockUIGeneral();
                utilSigo.toastError("Error", initSigo.MessageError);
                console.log(jqXHR.responseText);
            }
        },
        columns: columns,
        bInfo: true,
        "lengthMenu": [[10, 20, 50, 100], [10, 20, 50, 100]],
        "aaSorting": optDt.aSort,
        "pageLength": optDt.iLength,
        "displayStart": optDt.iStart,
        "oLanguage": initSigo.oLanguage,
        "drawCallback": initSigo.showPagination,
        "dom": 'Bfrtip',
        "buttons": [{ extend: 'copyHtml5', footer: true, text: 'Copiar', title: _reporte.lblTituloCabecera, exportOptions: { columns: columns_hide }, messageTop: $("#tbInfVMCMensual_Detalle").find("thead tr")[0].innerText.trim() },
            { extend: 'csvHtml5', footer: true, text: 'CSV', title: _reporte.lblTituloCabecera, exportOptions: { columns: columns_hide }, messageTop: $("#tbInfVMCMensual_Detalle").find("thead tr")[0].innerText.trim() },
            { extend: 'excelHtml5', footer: true, text: 'Excel', title: _reporte.lblTituloCabecera, exportOptions: { columns: columns_hide }, messageTop: $("#tbInfVMCMensual_Detalle").find("thead tr")[0].innerText.trim() },
            { extend: 'pdfHtml5', footer: true, text: 'PDF', title: _reporte.lblTituloCabecera, orientation: 'landscape', pageSize: 'LEGAL', exportOptions: { columns: columns_hide }, messageTop: $("#tbInfVMCMensual_Detalle").find("thead tr")[0].innerText.trim() },
            { extend: 'print', footer: true, text: 'Imprimir', title: _reporte.lblTituloCabecera, exportOptions: { columns: columns_hide }, messageTop: $("#tbInfVMCMensual_Detalle").find("thead tr")[0].innerText.trim() }]
    });

    _reporte.dtInfVMCMensual_Detalle.on('order.dt search.dt', function () {
        _reporte.dtInfVMCMensual_Detalle.column(0, { search: 'applied', order: 'applied' }).nodes().each(function (cell, i) {
            cell.innerHTML = i + 1;
            _reporte.dtInfVMCMensual_Detalle.cell(cell).invalidate('dom');
        });
    }).draw();
}

_reporte.fnInitInfVMC = function () {
    var chartInfVMCMensual_Resumen = null;

    //Activar Filtros
    _reporte.frm.find("#dvFiltroAnio").show();
    $("#dvInfVMCMensual").show();

    _reporte.rpt4InitDataTable();
    //Implementar eventos a ejecutar despúes de realizar una acción
    var fnLimpiarReporte = function () {
        _reporte.dtInfVMCMensual_Resumen.clear().draw();
        _reporte.dtInfVMCMensual_Detalle.clear().draw();
        _reporte.rowMes = "";
        var tb = $("#tbInfVMCMensual_Resumen");
        tb.find("#col3").text(0); tb.find("#col4").text(0); tb.find("#col5").text(0); tb.find("#col6").text(0);

        if (chartInfVMCMensual_Resumen != null) {
            chartInfVMCMensual_Resumen.clear();
            $("#cnvInfVMCMensual_Resumen").hide();
        }
    }

    _reporte.filter_lstChkAnioId_change = function () {
        fnLimpiarReporte();
    }

    _reporte.fnSubmitForm = function () {
        _reporte.dtInfVMCMensual_Resumen.clear().draw();
        _reporte.dtInfVMCMensual_Detalle.clear().draw();
        if (_reporte.filterValidate()) {
            var datosReporte = _reporte.frm.serializeObject();
            var option = { url: _reporte.frm.attr("action"), datos: JSON.stringify(datosReporte), type: 'POST' };

            utilSigo.fnAjax(option, function (data) {
                if (data.success) {
                    _reporte.dtInfVMCMensual_Resumen.rows.add(data.data).draw();

                    var c3 = 0, c4 = 0, c5 = 0, c6 = 0;
                    for (var i = 0; i < data.data.length; i++) {
                        c3 += parseInt(data.data[i]["SUPERVISADO"]); c4 += parseInt(data.data[i]["SUPERVISADO_CA"]);
                        c5 += parseInt(data.data[i]["SUPERVISADO_DOC"]); c6 += parseInt(data.data[i]["REMITIDOS"]);
                    }

                    var tb = $("#tbInfVMCMensual_Resumen");
                    tb.find("#col3").text(c3); tb.find("#col4").text(c4); tb.find("#col5").text(c5); tb.find("#col6").text(c6);

                    $("#cnvInfVMCMensual_Resumen").show();
                    chartInfVMCMensual_Resumen = customChart.LoadBarraSimple_DataTable(_reporte.dtInfVMCMensual_Resumen, "MES_NOMBRE", { colIndex: [2, 3, 4, 5], data: ["SUPERVISADO", "SUPERVISADO_CA", "SUPERVISADO_DOC", "REMITIDOS"], color: ["green", "blue", "red", "yellow"] }, { title: "", canvas: "cnvInfVMCMensual_Resumen" });
                }
                else {
                    utilSigo.toastWarning("Aviso", "Sucedio un error, Comuníquese con el Administrador");
                    console.log(data.msj);
                }
            });
        }

        return false;
    }

    utilDt.fnEventColumn = function (obj, col) {
        var numMes = "";

        if (obj != "") {
            numMes = _reporte.dtInfVMCMensual_Resumen.row($(obj).parents('tr')).data()["MES_"];
            _reporte.rowMes = numMes;
        }

        if (_reporte.filterValidate()) {
            _reporte.dtInfVMCMensual_Detalle.ajax.reload();
        }

        return false;
    }
}
/******************Fin Reporte 4*****************/

/*REPORTE 5 - Seguimiento Títulos Habilitantes*/
_reporte.rpt5InitDataTable = function () {
    var columns_label = [], columns_data = [], columns_event = [], options = {};

    //Tabla Resumen
    columns_label = ["Mes", "N° Títulos Habilitantes registrados en el SIGO - SFC", "N° Títulos Habilitantes con control de calidad conforme", "N° Títulos Habilitantes digitalizados"];
    columns_event = ["fn(c2)", "", "", ""];
    columns_data = ["MES_NOMBRE", "SUPERVISADO", "SUPERVISADO_CA", "SUPERVISADO_DOC"];
    options = {
        button_copy: true, button_csv: true, button_excel: true, button_pdf: true, button_print: true
        , export_title: $("#tbTituloHabilitanteMensual_Resumen").find("thead tr")[0].innerText.trim(), row_index: true
    };
    _reporte.dtTituloHabilitanteMensual_Resumen = utilDt.fnLoadDataTable_EventColumn($("#tbTituloHabilitanteMensual_Resumen"), columns_label, columns_data, columns_event, options);

    //Tabla Detalle
    columns_label = ["N°", "Mes", "Título", "Modalidad", "Fecha registro SIGO", "Titular", "Con Control de Calidad Conforme", "Estado del Documento", "Fecha registro Control de calidad",
        "Digitalizado", "Doc"];
    var columns = [
        { "name": "ROW_INDE", "width": "2%", "orderable": false, "searchable": false, "defaultContent": "" },
        { "data": "MES_NOMBRE", "autoWidth": true },
        { "data": "NUMERO_RD", "autoWidth": true },
        { "data": "TIPO_RD", "autoWidth": true },
        { "data": "FECHA", "autoWidth": true },
        { "data": "TITULAR", "autoWidth": true },
        { "data": "CONTROL_CALIDAD", "autoWidth": true },
        { "data": "ESTADO_PAU", "autoWidth": true },
        { "data": "FECHA_CCA", "autoWidth": true },
        { "data": "DIGITALIZADO", "autoWidth": true },
        {
            "data": "", "width": "2%", "orderable": false, "searchable": false, "mRender": function (data, type, row) {
                if (row.CODIGO.trim() != "")
                    return '<div><i class="fa fa-lg fa-download" style="cursor:pointer;color:dodgerblue;" onclick="_reporte.fnValidaDocSIADO(\'' + row.CODIGO.trim() + '\')"></i>';
                else return "";
            }
        }
    ];

    //**Cabecera**----
    var theadTable = "<tr>";
    for (var i = 0; i < columns_label.length; i++) {
        theadTable += '<th>' + columns_label[i] + '</th>';
    }
    theadTable += "</tr>";
    $("#tbTituloHabilitanteMensual_Detalle").find("thead").append(theadTable);
    //**Cuerpo**----
    var optDt = { iLength: 20, iStart: 0, aSort: [] };
    var columns_hide = [10];

    _reporte.dtTituloHabilitanteMensual_Detalle = $("#tbTituloHabilitanteMensual_Detalle").DataTable({
        processing: true,
        searching: false,
        ordering: true,
        paging: true,
        ajax: {
            "url": urlLocalSigo + "General/ReporteSeguimientoRegistro/DetalleReporte",
            "data": function (params) {
                params.lstChkMesId = _reporte.rowMes;
                params.lstChkAnioId = _reporte.frm.find("#lstChkAnioId").val();
                params.hdfTipoReporte = "TH_DETALLE";
            },
            "type": "POST",
            "error": function (jqXHR) {
                utilSigo.unblockUIGeneral();
                utilSigo.toastError("Error", initSigo.MessageError);
                console.log(jqXHR.responseText);
            }
        },
        columns: columns,
        bInfo: true,
        "lengthMenu": [[10, 20, 50, 100], [10, 20, 50, 100]],
        "aaSorting": optDt.aSort,
        "pageLength": optDt.iLength,
        "displayStart": optDt.iStart,
        "oLanguage": initSigo.oLanguage,
        "drawCallback": initSigo.showPagination,
        "dom": 'Bfrtip',
        "buttons": [{ extend: 'copyHtml5', footer: true, text: 'Copiar', title: _reporte.lblTituloCabecera, exportOptions: { columns: columns_hide }, messageTop: $("#tbTituloHabilitanteMensual_Detalle").find("thead tr")[0].innerText.trim() },
            { extend: 'csvHtml5', footer: true, text: 'CSV', title: _reporte.lblTituloCabecera, exportOptions: { columns: columns_hide }, messageTop: $("#tbTituloHabilitanteMensual_Detalle").find("thead tr")[0].innerText.trim() },
            { extend: 'excelHtml5', footer: true, text: 'Excel', title: _reporte.lblTituloCabecera, exportOptions: { columns: columns_hide }, messageTop: $("#tbTituloHabilitanteMensual_Detalle").find("thead tr")[0].innerText.trim() },
            { extend: 'pdfHtml5', footer: true, text: 'PDF', title: _reporte.lblTituloCabecera, orientation: 'landscape', pageSize: 'LEGAL', exportOptions: { columns: columns_hide }, messageTop: $("#tbTituloHabilitanteMensual_Detalle").find("thead tr")[0].innerText.trim() },
            { extend: 'print', footer: true, text: 'Imprimir', title: _reporte.lblTituloCabecera, exportOptions: { columns: columns_hide }, messageTop: $("#tbTituloHabilitanteMensual_Detalle").find("thead tr")[0].innerText.trim() }]
    });

    _reporte.dtTituloHabilitanteMensual_Detalle.on('order.dt search.dt', function () {
        _reporte.dtTituloHabilitanteMensual_Detalle.column(0, { search: 'applied', order: 'applied' }).nodes().each(function (cell, i) {
            cell.innerHTML = i + 1;
            _reporte.dtTituloHabilitanteMensual_Detalle.cell(cell).invalidate('dom');
        });
    }).draw();
}

_reporte.fnInitTituloHabilitante = function () {
    var chartTituloHabilitanteMensual_Resumen = null;

    //Activar Filtros
    _reporte.frm.find("#dvFiltroAnio").show();
    $("#dvTituloHabilitanteMensual").show();

    _reporte.rpt5InitDataTable();
    //Implementar eventos a ejecutar despúes de realizar una acción
    var fnLimpiarReporte = function () {
        _reporte.dtTituloHabilitanteMensual_Resumen.clear().draw();
        _reporte.dtTituloHabilitanteMensual_Detalle.clear().draw();
        _reporte.rowMes = "";
        var tb = $("#tbTituloHabilitanteMensual_Resumen");
        tb.find("#col3").text(0); tb.find("#col4").text(0); tb.find("#col5").text(0);

        if (chartTituloHabilitanteMensual_Resumen != null) {
            chartTituloHabilitanteMensual_Resumen.clear();
            $("#cnvTituloHabilitanteMensual_Resumen").hide();
        }
    }

    _reporte.filter_lstChkAnioId_change = function () {
        fnLimpiarReporte();
    }

    _reporte.fnSubmitForm = function () {
        _reporte.dtTituloHabilitanteMensual_Resumen.clear().draw();
        _reporte.dtTituloHabilitanteMensual_Detalle.clear().draw();
        if (_reporte.filterValidate()) {
            var datosReporte = _reporte.frm.serializeObject();
            var option = { url: _reporte.frm.attr("action"), datos: JSON.stringify(datosReporte), type: 'POST' };

            utilSigo.fnAjax(option, function (data) {
                if (data.success) {
                    _reporte.dtTituloHabilitanteMensual_Resumen.rows.add(data.data).draw();

                    var c3 = 0, c4 = 0, c5 = 0;
                    for (var i = 0; i < data.data.length; i++) {
                        c3 += parseInt(data.data[i]["SUPERVISADO"]); c4 += parseInt(data.data[i]["SUPERVISADO_CA"]);
                        c5 += parseInt(data.data[i]["SUPERVISADO_DOC"]);
                    }

                    var tb = $("#tbTituloHabilitanteMensual_Resumen");
                    tb.find("#col3").text(c3); tb.find("#col4").text(c4); tb.find("#col5").text(c5);

                    $("#cnvTituloHabilitanteMensual_Resumen").show();
                    chartTituloHabilitanteMensual_Resumen = customChart.LoadBarraSimple_DataTable(_reporte.dtTituloHabilitanteMensual_Resumen, "MES_NOMBRE", { colIndex: [2, 3, 4], data: ["SUPERVISADO", "SUPERVISADO_CA", "SUPERVISADO_DOC"], color: ["green", "blue", "red"] }, { title: "", canvas: "cnvTituloHabilitanteMensual_Resumen" });
                }
                else {
                    utilSigo.toastWarning("Aviso", "Sucedio un error, Comuníquese con el Administrador");
                    console.log(data.msj);
                }
            });
        }

        return false;
    }

    utilDt.fnEventColumn = function (obj, col) {
        var numMes = "";

        if (obj != "") {
            numMes = _reporte.dtTituloHabilitanteMensual_Resumen.row($(obj).parents('tr')).data()["MES_"];
            _reporte.rowMes = numMes;
        }

        if (_reporte.filterValidate()) {
            _reporte.dtTituloHabilitanteMensual_Detalle.ajax.reload();
        }

        return false;
    }
}
/******************Fin Reporte 5*****************/

/*REPORTE 6 - Seguimiento POA*/
_reporte.rpt6InitDataTable = function () {
    var columns_label = [], columns_data = [], columns_event = [], options = {};

    //Tabla Resumen
    columns_label = ["Mes", "N° Planes de manejo registrados en el SIGO - SFC", "N° Planes de manejo con control de calidad conforme", "N° Planes de manejo digitalizados"];
    columns_event = ["fn(c2)", "", "", ""];
    columns_data = ["MES_NOMBRE", "SUPERVISADO", "SUPERVISADO_CA", "SUPERVISADO_DOC"];
    options = {
        button_copy: true, button_csv: true, button_excel: true, button_pdf: true, button_print: true
        , export_title: $("#tbPOAMensual_Resumen").find("thead tr")[0].innerText.trim(), row_index: true
    };
    _reporte.dtPOAMensual_Resumen = utilDt.fnLoadDataTable_EventColumn($("#tbPOAMensual_Resumen"), columns_label, columns_data, columns_event, options);

    //Tabla Detalle
    columns_label = ["N°", "Mes", "N° Plan de Manejo", "Zafra", "Fecha de inicio y termino de vigencia", "Fecha registro SIGO", "Titular", "Título", "Modalidad",
        "Con Control de Calidad Conforme", "Estado del Documento", "Fecha registro Control de calidad", "Digitalizado", "Doc"];
    var columns = [
        { "name": "ROW_INDE", "width": "2%", "orderable": false, "searchable": false, "defaultContent": "" },
        { "data": "MES_NOMBRE", "autoWidth": true },
        { "data": "NUMERO_RD", "autoWidth": true },
        { "data": "TIPO_RD", "autoWidth": true },
        { "data": "FECHA_EMISION", "autoWidth": true },
        { "data": "FECHA", "autoWidth": true },
        { "data": "TITULAR", "autoWidth": true },
        { "data": "TITULO", "autoWidth": true },
        { "data": "Numero_Inform", "autoWidth": true },
        { "data": "CONTROL_CALIDAD", "autoWidth": true },
        { "data": "ESTADO_PAU", "autoWidth": true },
        { "data": "FECHA_CCA", "autoWidth": true },
        { "data": "DIGITALIZADO", "autoWidth": true },
        {
            "data": "", "width": "2%", "orderable": false, "searchable": false, "mRender": function (data, type, row) {
                if (row.CODIGO.trim() != "")
                    return '<div><i class="fa fa-lg fa-download" style="cursor:pointer;color:dodgerblue;" onclick="_reporte.fnValidaDocSIADO(\'' + row.CODIGO.trim() + '\')"></i>';
                else return "";
            }
        }
    ];

    //**Cabecera**----
    var theadTable = "<tr>";
    for (var i = 0; i < columns_label.length; i++) {
        theadTable += '<th>' + columns_label[i] + '</th>';
    }
    theadTable += "</tr>";
    $("#tbPOAMensual_Detalle").find("thead").append(theadTable);
    //**Cuerpo**----
    var optDt = { iLength: 20, iStart: 0, aSort: [] };
    var columns_hide = [13];

    _reporte.dtPOAMensual_Detalle = $("#tbPOAMensual_Detalle").DataTable({
        processing: true,
        searching: false,
        ordering: true,
        paging: true,
        ajax: {
            "url": urlLocalSigo + "General/ReporteSeguimientoRegistro/DetalleReporte",
            "data": function (params) {
                params.lstChkMesId = _reporte.rowMes;
                params.lstChkAnioId = _reporte.frm.find("#lstChkAnioId").val();
                params.hdfTipoReporte = "POA_DETALLE";
            },
            "type": "POST",
            "error": function (jqXHR) {
                utilSigo.unblockUIGeneral();
                utilSigo.toastError("Error", initSigo.MessageError);
                console.log(jqXHR.responseText);
            }
        },
        columns: columns,
        bInfo: true,
        "lengthMenu": [[10, 20, 50, 100], [10, 20, 50, 100]],
        "aaSorting": optDt.aSort,
        "pageLength": optDt.iLength,
        "displayStart": optDt.iStart,
        "oLanguage": initSigo.oLanguage,
        "drawCallback": initSigo.showPagination,
        "dom": 'Bfrtip',
        "buttons": [{ extend: 'copyHtml5', footer: true, text: 'Copiar', title: _reporte.lblTituloCabecera, exportOptions: { columns: columns_hide }, messageTop: $("#tbPOAMensual_Detalle").find("thead tr")[0].innerText.trim() },
            { extend: 'csvHtml5', footer: true, text: 'CSV', title: _reporte.lblTituloCabecera, exportOptions: { columns: columns_hide }, messageTop: $("#tbPOAMensual_Detalle").find("thead tr")[0].innerText.trim() },
            { extend: 'excelHtml5', footer: true, text: 'Excel', title: _reporte.lblTituloCabecera, exportOptions: { columns: columns_hide }, messageTop: $("#tbPOAMensual_Detalle").find("thead tr")[0].innerText.trim() },
            { extend: 'pdfHtml5', footer: true, text: 'PDF', title: _reporte.lblTituloCabecera, orientation: 'landscape', pageSize: 'LEGAL', exportOptions: { columns: columns_hide }, messageTop: $("#tbPOAMensual_Detalle").find("thead tr")[0].innerText.trim() },
            { extend: 'print', footer: true, text: 'Imprimir', title: _reporte.lblTituloCabecera, exportOptions: { columns: columns_hide }, messageTop: $("#tbPOAMensual_Detalle").find("thead tr")[0].innerText.trim() }]
    });

    _reporte.dtPOAMensual_Detalle.on('order.dt search.dt', function () {
        _reporte.dtPOAMensual_Detalle.column(0, { search: 'applied', order: 'applied' }).nodes().each(function (cell, i) {
            cell.innerHTML = i + 1;
            _reporte.dtPOAMensual_Detalle.cell(cell).invalidate('dom');
        });
    }).draw();
}

_reporte.fnInitPOA = function () {
    var chartPOAMensual_Resumen = null;

    //Activar Filtros
    _reporte.frm.find("#dvFiltroAnio").show();
    $("#dvPOAMensual").show();

    _reporte.rpt6InitDataTable();
    //Implementar eventos a ejecutar despúes de realizar una acción
    var fnLimpiarReporte = function () {
        _reporte.dtPOAMensual_Resumen.clear().draw();
        _reporte.dtPOAMensual_Detalle.clear().draw();
        _reporte.rowMes = "";
        var tb = $("#tbPOAMensual_Resumen");
        tb.find("#col3").text(0); tb.find("#col4").text(0); tb.find("#col5").text(0);

        if (chartPOAMensual_Resumen != null) {
            chartPOAMensual_Resumen.clear();
            $("#cnvPOAMensual_Resumen").hide();
        }
    }

    _reporte.filter_lstChkAnioId_change = function () {
        fnLimpiarReporte();
    }

    _reporte.fnSubmitForm = function () {
        _reporte.dtPOAMensual_Resumen.clear().draw();
        _reporte.dtPOAMensual_Detalle.clear().draw();
        if (_reporte.filterValidate()) {
            var datosReporte = _reporte.frm.serializeObject();
            var option = { url: _reporte.frm.attr("action"), datos: JSON.stringify(datosReporte), type: 'POST' };

            utilSigo.fnAjax(option, function (data) {
                if (data.success) {
                    _reporte.dtPOAMensual_Resumen.rows.add(data.data).draw();

                    var c3 = 0, c4 = 0, c5 = 0;
                    for (var i = 0; i < data.data.length; i++) {
                        c3 += parseInt(data.data[i]["SUPERVISADO"]); c4 += parseInt(data.data[i]["SUPERVISADO_CA"]);
                        c5 += parseInt(data.data[i]["SUPERVISADO_DOC"]);
                    }

                    var tb = $("#tbPOAMensual_Resumen");
                    tb.find("#col3").text(c3); tb.find("#col4").text(c4); tb.find("#col5").text(c5);

                    $("#cnvPOAMensual_Resumen").show();
                    chartPOAMensual_Resumen = customChart.LoadBarraSimple_DataTable(_reporte.dtPOAMensual_Resumen, "MES_NOMBRE", { colIndex: [2, 3, 4], data: ["SUPERVISADO", "SUPERVISADO_CA", "SUPERVISADO_DOC"], color: ["green", "blue", "red"] }, { title: "", canvas: "cnvPOAMensual_Resumen" });
                }
                else {
                    utilSigo.toastWarning("Aviso", "Sucedio un error, Comuníquese con el Administrador");
                    console.log(data.msj);
                }
            });
        }

        return false;
    }

    utilDt.fnEventColumn = function (obj, col) {
        var numMes = "";

        if (obj != "") {
            numMes = _reporte.dtPOAMensual_Resumen.row($(obj).parents('tr')).data()["MES_"];
            _reporte.rowMes = numMes;
        }

        if (_reporte.filterValidate()) {
            _reporte.dtPOAMensual_Detalle.ajax.reload();
        }

        return false;
    }
}
/******************Fin Reporte 6*****************/

/*REPORTE 7 - Seguimiento RD*/
_reporte.rpt7InitDataTable = function () {
    var columns_label = [], columns_data = [], columns_event = [], options = {};

    //Tabla Resumen
    columns_label = ["Mes", "N° R.D. registrados en SIGO - sfc", "N° R.D. con control de calidad conforme", "N° R.D. digitalizados"];
    columns_event = ["fn(c2)", "", "", ""];
    columns_data = ["MES_NOMBRE", "SUPERVISADO", "SUPERVISADO_CA", "SUPERVISADO_DOC"];
    options = {
        button_copy: true, button_csv: true, button_excel: true, button_pdf: true, button_print: true
        , export_title: $("#tbResolucionDirectoralMensual_Resumen").find("thead tr")[0].innerText.trim(), row_index: true
    };
    _reporte.dtResolucionDirectoralMensual_Resumen = utilDt.fnLoadDataTable_EventColumn($("#tbResolucionDirectoralMensual_Resumen"), columns_label, columns_data, columns_event, options);

    //Tabla Detalle
    columns_label = ["N°", "Mes", "N° R.D.", "Tipo R.D.", "Fecha de emisión R.D.", "Fecha registro SIGO", "Titular", "Título", "Con Control de Calidad Conforme",
        "Estado del Documento", "Fecha registro Control de calidad", "Digitalizado", "Doc"];
    var columns = [
        { "name": "ROW_INDE", "width": "2%", "orderable": false, "searchable": false, "defaultContent": "" },
        { "data": "MES_NOMBRE", "autoWidth": true },
        { "data": "NUMERO_RD", "autoWidth": true },
        { "data": "TIPO_RD", "autoWidth": true },
        { "data": "FECHA_EMISION", "autoWidth": true },
        { "data": "FECHA", "autoWidth": true },
        { "data": "TITULAR", "autoWidth": true },
        { "data": "TITULO", "autoWidth": true },
        { "data": "CONTROL_CALIDAD", "autoWidth": true },
        { "data": "ESTADO_PAU", "autoWidth": true },
        { "data": "FECHA_CCA", "autoWidth": true },
        { "data": "DIGITALIZADO", "autoWidth": true },
        {
            "data": "", "width": "2%", "orderable": false, "searchable": false, "mRender": function (data, type, row) {
                if (row.CODIGO.trim() != "")
                    return '<div><i class="fa fa-lg fa-download" style="cursor:pointer;color:dodgerblue;" onclick="_reporte.fnValidaDocSIADO(\'' + row.CODIGO.trim() + '\')"></i>';
                else return "";
            }
        }
    ];

    //**Cabecera**----
    var theadTable = "<tr>";
    for (var i = 0; i < columns_label.length; i++) {
        theadTable += '<th>' + columns_label[i] + '</th>';
    }
    theadTable += "</tr>";
    $("#tbResolucionDirectoralMensual_Detalle").find("thead").append(theadTable);
    //**Cuerpo**----
    var optDt = { iLength: 20, iStart: 0, aSort: [] };
    var columns_hide = [12];

    _reporte.dtResolucionDirectoralMensual_Detalle = $("#tbResolucionDirectoralMensual_Detalle").DataTable({
        processing: true,
        searching: false,
        ordering: true,
        paging: true,
        ajax: {
            "url": urlLocalSigo + "General/ReporteSeguimientoRegistro/DetalleReporte",
            "data": function (params) {
                params.lstChkMesId = _reporte.rowMes;
                params.lstChkAnioId = _reporte.frm.find("#lstChkAnioId").val();
                params.hdfTipoReporte = "RD_DETALLE";
            },
            "type": "POST",
            "error": function (jqXHR) {
                utilSigo.unblockUIGeneral();
                utilSigo.toastError("Error", initSigo.MessageError);
                console.log(jqXHR.responseText);
            }
        },
        columns: columns,
        bInfo: true,
        "lengthMenu": [[10, 20, 50, 100], [10, 20, 50, 100]],
        "aaSorting": optDt.aSort,
        "pageLength": optDt.iLength,
        "displayStart": optDt.iStart,
        "oLanguage": initSigo.oLanguage,
        "drawCallback": initSigo.showPagination,
        "dom": 'Bfrtip',
        "buttons": [{ extend: 'copyHtml5', footer: true, text: 'Copiar', title: _reporte.lblTituloCabecera, exportOptions: { columns: columns_hide }, messageTop: $("#tbResolucionDirectoralMensual_Detalle").find("thead tr")[0].innerText.trim() },
            { extend: 'csvHtml5', footer: true, text: 'CSV', title: _reporte.lblTituloCabecera, exportOptions: { columns: columns_hide }, messageTop: $("#tbResolucionDirectoralMensual_Detalle").find("thead tr")[0].innerText.trim() },
            { extend: 'excelHtml5', footer: true, text: 'Excel', title: _reporte.lblTituloCabecera, exportOptions: { columns: columns_hide }, messageTop: $("#tbResolucionDirectoralMensual_Detalle").find("thead tr")[0].innerText.trim() },
            { extend: 'pdfHtml5', footer: true, text: 'PDF', title: _reporte.lblTituloCabecera, orientation: 'landscape', pageSize: 'LEGAL', exportOptions: { columns: columns_hide }, messageTop: $("#tbResolucionDirectoralMensual_Detalle").find("thead tr")[0].innerText.trim() },
            { extend: 'print', footer: true, text: 'Imprimir', title: _reporte.lblTituloCabecera, exportOptions: { columns: columns_hide }, messageTop: $("#tbResolucionDirectoralMensual_Detalle").find("thead tr")[0].innerText.trim() }]
    });

    _reporte.dtResolucionDirectoralMensual_Detalle.on('order.dt search.dt', function () {
        _reporte.dtResolucionDirectoralMensual_Detalle.column(0, { search: 'applied', order: 'applied' }).nodes().each(function (cell, i) {
            cell.innerHTML = i + 1;
            _reporte.dtResolucionDirectoralMensual_Detalle.cell(cell).invalidate('dom');
        });
    }).draw();
}

_reporte.fnInitResolucionDirectoral = function () {
    var chartResolucionDirectoralMensual_Resumen = null;

    //Activar Filtros
    _reporte.frm.find("#dvFiltroAnio").show();
    $("#dvResolucionDirectoralMensual").show();

    _reporte.rpt7InitDataTable();
    //Implementar eventos a ejecutar despúes de realizar una acción
    var fnLimpiarReporte = function () {
        _reporte.dtResolucionDirectoralMensual_Resumen.clear().draw();
        _reporte.dtResolucionDirectoralMensual_Detalle.clear().draw();
        _reporte.rowMes = "";
        var tb = $("#tbResolucionDirectoralMensual_Resumen");
        tb.find("#col3").text(0); tb.find("#col4").text(0); tb.find("#col5").text(0);

        if (chartResolucionDirectoralMensual_Resumen != null) {
            chartResolucionDirectoralMensual_Resumen.clear();
            $("#cnvResolucionDirectoralMensual_Resumen").hide();
        }
    }

    _reporte.filter_lstChkAnioId_change = function () {
        fnLimpiarReporte();
    }

    _reporte.fnSubmitForm = function () {
        _reporte.dtResolucionDirectoralMensual_Resumen.clear().draw();
        _reporte.dtResolucionDirectoralMensual_Detalle.clear().draw();
        if (_reporte.filterValidate()) {
            var datosReporte = _reporte.frm.serializeObject();
            var option = { url: _reporte.frm.attr("action"), datos: JSON.stringify(datosReporte), type: 'POST' };

            utilSigo.fnAjax(option, function (data) {
                if (data.success) {
                    _reporte.dtResolucionDirectoralMensual_Resumen.rows.add(data.data).draw();

                    var c3 = 0, c4 = 0, c5 = 0;
                    for (var i = 0; i < data.data.length; i++) {
                        c3 += parseInt(data.data[i]["SUPERVISADO"]); c4 += parseInt(data.data[i]["SUPERVISADO_CA"]);
                        c5 += parseInt(data.data[i]["SUPERVISADO_DOC"]);
                    }

                    var tb = $("#tbResolucionDirectoralMensual_Resumen");
                    tb.find("#col3").text(c3); tb.find("#col4").text(c4); tb.find("#col5").text(c5);

                    $("#cnvResolucionDirectoralMensual_Resumen").show();
                    chartResolucionDirectoralMensual_Resumen = customChart.LoadBarraSimple_DataTable(_reporte.dtResolucionDirectoralMensual_Resumen, "MES_NOMBRE", { colIndex: [2, 3, 4], data: ["SUPERVISADO", "SUPERVISADO_CA", "SUPERVISADO_DOC"], color: ["green", "blue", "red"] }, { title: "", canvas: "cnvResolucionDirectoralMensual_Resumen" });
                }
                else {
                    utilSigo.toastWarning("Aviso", "Sucedio un error, Comuníquese con el Administrador");
                    console.log(data.msj);
                }
            });
        }

        return false;
    }

    utilDt.fnEventColumn = function (obj, col) {
        var numMes = "";

        if (obj != "") {
            numMes = _reporte.dtResolucionDirectoralMensual_Resumen.row($(obj).parents('tr')).data()["MES_"];
            _reporte.rowMes = numMes;
        }

        if (_reporte.filterValidate()) {
            _reporte.dtResolucionDirectoralMensual_Detalle.ajax.reload();
        }

        return false;
    }
}
/******************Fin Reporte 7*****************/

/*REPORTE 8 - Seguimiento Informe Legal*/
_reporte.rpt8InitDataTable = function () {
    var columns_label = [], columns_data = [], columns_event = [], options = {};

    //Tabla Resumen
    columns_label = ["Mes", "N° Informe Legal registrados en SIGO - sfc", "N° Informe Legal con control de calidad conforme", "N° Informe Legal digitalizados"];
    columns_event = ["fn(c2)", "", "", ""];
    columns_data = ["MES_NOMBRE", "SUPERVISADO", "SUPERVISADO_CA", "SUPERVISADO_DOC"];
    options = {
        button_copy: true, button_csv: true, button_excel: true, button_pdf: true, button_print: true
        , export_title: $("#tbInfLegalMensual_Resumen").find("thead tr")[0].innerText.trim(), row_index: true
    };
    _reporte.dtInfLegalMensual_Resumen = utilDt.fnLoadDataTable_EventColumn($("#tbInfLegalMensual_Resumen"), columns_label, columns_data, columns_event, options);

    //Tabla Detalle
    columns_label = ["N°", "Mes", "N° Informe Legal", "Tipo", "Fecha de emisión", "Fecha registro SIGO", "Titular", "Título", "Con Control de Calidad Conforme",
        "Estado del Documento", "Fecha registro Control de calidad", "Digitalizado", "Doc"];
    var columns = [
        { "name": "ROW_INDE", "width": "2%", "orderable": false, "searchable": false, "defaultContent": "" },
        { "data": "MES_NOMBRE", "autoWidth": true },
        { "data": "NUMERO_RD", "autoWidth": true },
        { "data": "TIPO_RD", "autoWidth": true },
        { "data": "FECHA_EMISION", "autoWidth": true },
        { "data": "FECHA", "autoWidth": true },
        { "data": "TITULAR", "autoWidth": true },
        { "data": "TITULO", "autoWidth": true },
        { "data": "CONTROL_CALIDAD", "autoWidth": true },
        { "data": "ESTADO_PAU", "autoWidth": true },
        { "data": "FECHA_CCA", "autoWidth": true },
        { "data": "DIGITALIZADO", "autoWidth": true },
        {
            "data": "", "width": "2%", "orderable": false, "searchable": false, "mRender": function (data, type, row) {
                if (row.CODIGO.trim() != "")
                    return '<div><i class="fa fa-lg fa-download" style="cursor:pointer;color:dodgerblue;" onclick="_reporte.fnValidaDocSIADO(\'' + row.CODIGO.trim() + '\')"></i>';
                else return "";
            }
        }
    ];

    //**Cabecera**----
    var theadTable = "<tr>";
    for (var i = 0; i < columns_label.length; i++) {
        theadTable += '<th>' + columns_label[i] + '</th>';
    }
    theadTable += "</tr>";
    $("#tbInfLegalMensual_Detalle").find("thead").append(theadTable);
    //**Cuerpo**----
    var optDt = { iLength: 20, iStart: 0, aSort: [] };
    var columns_hide = [12];

    _reporte.dtInfLegalMensual_Detalle = $("#tbInfLegalMensual_Detalle").DataTable({
        processing: true,
        searching: false,
        ordering: true,
        paging: true,
        ajax: {
            "url": urlLocalSigo + "General/ReporteSeguimientoRegistro/DetalleReporte",
            "data": function (params) {
                params.lstChkMesId = _reporte.rowMes;
                params.lstChkAnioId = _reporte.frm.find("#lstChkAnioId").val();
                params.hdfTipoReporte = "ILEGAL_DETALLE";
            },
            "type": "POST",
            "error": function (jqXHR) {
                utilSigo.unblockUIGeneral();
                utilSigo.toastError("Error", initSigo.MessageError);
                console.log(jqXHR.responseText);
            }
        },
        columns: columns,
        bInfo: true,
        "lengthMenu": [[10, 20, 50, 100], [10, 20, 50, 100]],
        "aaSorting": optDt.aSort,
        "pageLength": optDt.iLength,
        "displayStart": optDt.iStart,
        "oLanguage": initSigo.oLanguage,
        "drawCallback": initSigo.showPagination,
        "dom": 'Bfrtip',
        "buttons": [{ extend: 'copyHtml5', footer: true, text: 'Copiar', title: _reporte.lblTituloCabecera, exportOptions: { columns: columns_hide }, messageTop: $("#tbInfLegalMensual_Detalle").find("thead tr")[0].innerText.trim() },
            { extend: 'csvHtml5', footer: true, text: 'CSV', title: _reporte.lblTituloCabecera, exportOptions: { columns: columns_hide }, messageTop: $("#tbInfLegalMensual_Detalle").find("thead tr")[0].innerText.trim() },
            { extend: 'excelHtml5', footer: true, text: 'Excel', title: _reporte.lblTituloCabecera, exportOptions: { columns: columns_hide }, messageTop: $("#tbInfLegalMensual_Detalle").find("thead tr")[0].innerText.trim() },
            { extend: 'pdfHtml5', footer: true, text: 'PDF', title: _reporte.lblTituloCabecera, orientation: 'landscape', pageSize: 'LEGAL', exportOptions: { columns: columns_hide }, messageTop: $("#tbInfLegalMensual_Detalle").find("thead tr")[0].innerText.trim() },
            { extend: 'print', footer: true, text: 'Imprimir', title: _reporte.lblTituloCabecera, exportOptions: { columns: columns_hide }, messageTop: $("#tbInfLegalMensual_Detalle").find("thead tr")[0].innerText.trim() }]
    });

    _reporte.dtInfLegalMensual_Detalle.on('order.dt search.dt', function () {
        _reporte.dtInfLegalMensual_Detalle.column(0, { search: 'applied', order: 'applied' }).nodes().each(function (cell, i) {
            cell.innerHTML = i + 1;
            _reporte.dtInfLegalMensual_Detalle.cell(cell).invalidate('dom');
        });
    }).draw();
}

_reporte.fnInitInfLegal = function () {
    var chartInfLegalMensual_Resumen = null;

    //Activar Filtros
    _reporte.frm.find("#dvFiltroAnio").show();
    $("#dvInfLegalMensual").show();

    _reporte.rpt8InitDataTable();
    //Implementar eventos a ejecutar despúes de realizar una acción
    var fnLimpiarReporte = function () {
        _reporte.dtInfLegalMensual_Resumen.clear().draw();
        _reporte.dtInfLegalMensual_Detalle.clear().draw();
        _reporte.rowMes = "";
        var tb = $("#tbInfLegalMensual_Resumen");
        tb.find("#col3").text(0); tb.find("#col4").text(0); tb.find("#col5").text(0);

        if (chartInfLegalMensual_Resumen != null) {
            chartInfLegalMensual_Resumen.clear();
            $("#cnvInfLegalMensual_Resumen").hide();
        }
    }

    _reporte.filter_lstChkAnioId_change = function () {
        fnLimpiarReporte();
    }

    _reporte.fnSubmitForm = function () {
        _reporte.dtInfLegalMensual_Resumen.clear().draw();
        _reporte.dtInfLegalMensual_Detalle.clear().draw();
        if (_reporte.filterValidate()) {
            var datosReporte = _reporte.frm.serializeObject();
            var option = { url: _reporte.frm.attr("action"), datos: JSON.stringify(datosReporte), type: 'POST' };

            utilSigo.fnAjax(option, function (data) {
                if (data.success) {
                    _reporte.dtInfLegalMensual_Resumen.rows.add(data.data).draw();

                    var c3 = 0, c4 = 0, c5 = 0;
                    for (var i = 0; i < data.data.length; i++) {
                        c3 += parseInt(data.data[i]["SUPERVISADO"]); c4 += parseInt(data.data[i]["SUPERVISADO_CA"]);
                        c5 += parseInt(data.data[i]["SUPERVISADO_DOC"]);
                    }

                    var tb = $("#tbInfLegalMensual_Resumen");
                    tb.find("#col3").text(c3); tb.find("#col4").text(c4); tb.find("#col5").text(c5);

                    $("#cnvInfLegalMensual_Resumen").show();
                    chartInfLegalMensual_Resumen = customChart.LoadBarraSimple_DataTable(_reporte.dtInfLegalMensual_Resumen, "MES_NOMBRE", { colIndex: [2, 3, 4], data: ["SUPERVISADO", "SUPERVISADO_CA", "SUPERVISADO_DOC"], color: ["green", "blue", "red"] }, { title: "", canvas: "cnvInfLegalMensual_Resumen" });
                }
                else {
                    utilSigo.toastWarning("Aviso", "Sucedio un error, Comuníquese con el Administrador");
                    console.log(data.msj);
                }
            });
        }

        return false;
    }

    utilDt.fnEventColumn = function (obj, col) {
        var numMes = "";

        if (obj != "") {
            numMes = _reporte.dtInfLegalMensual_Resumen.row($(obj).parents('tr')).data()["MES_"];
            _reporte.rowMes = numMes;
        }

        if (_reporte.filterValidate()) {
            _reporte.dtInfLegalMensual_Detalle.ajax.reload();
        }

        return false;
    }
}
/******************Fin Reporte 8*****************/

/*REPORTE 9 - Seguimiento Informe Instrucción Final*/
_reporte.rpt9InitDataTable = function () {
    var columns_label = [], columns_data = [], columns_event = [], options = {};

    //Tabla Resumen
    columns_label = ["Mes", "N° Informes de Instrucción final registrados en SIGO - sfc", "N° Informes de Instrucción final con control de calidad conforme", "N° Informes de Instrucción final digitalizados"];
    columns_event = ["fn(c2)", "", "", ""];
    columns_data = ["MES_NOMBRE", "SUPERVISADO", "SUPERVISADO_CA", "SUPERVISADO_DOC"];
    options = {
        button_copy: true, button_csv: true, button_excel: true, button_pdf: true, button_print: true
        , export_title: $("#tbInfInstruccionFinalMensual_Resumen").find("thead tr")[0].innerText.trim(), row_index: true
    };
    _reporte.dtInfInstruccionFinalMensual_Resumen = utilDt.fnLoadDataTable_EventColumn($("#tbInfInstruccionFinalMensual_Resumen"), columns_label, columns_data, columns_event, options);

    //Tabla Detalle
    columns_label = ["N°", "Mes", "N° Informe de instrucción final", "Tipo", "Fecha de emisión", "Fecha registro SIGO", "Titular", "Título", "Con Control de Calidad Conforme",
        "Estado del Documento", "Fecha registro Control de calidad", "Digitalizado", "Doc"];
    var columns = [
        { "name": "ROW_INDE", "width": "2%", "orderable": false, "searchable": false, "defaultContent": "" },
        { "data": "MES_NOMBRE", "autoWidth": true },
        { "data": "NUMERO_RD", "autoWidth": true },
        { "data": "TIPO_RD", "autoWidth": true },
        { "data": "FECHA_EMISION", "autoWidth": true },
        { "data": "FECHA", "autoWidth": true },
        { "data": "TITULAR", "autoWidth": true },
        { "data": "TITULO", "autoWidth": true },
        { "data": "CONTROL_CALIDAD", "autoWidth": true },
        { "data": "ESTADO_PAU", "autoWidth": true },
        { "data": "FECHA_CCA", "autoWidth": true },
        { "data": "DIGITALIZADO", "autoWidth": true },
        {
            "data": "", "width": "2%", "orderable": false, "searchable": false, "mRender": function (data, type, row) {
                if (row.CODIGO.trim() != "")
                    return '<div><i class="fa fa-lg fa-download" style="cursor:pointer;color:dodgerblue;" onclick="_reporte.fnValidaDocSIADO(\'' + row.CODIGO.trim() + '\')"></i>';
                else return "";
            }
        }
    ];

    //**Cabecera**----
    var theadTable = "<tr>";
    for (var i = 0; i < columns_label.length; i++) {
        theadTable += '<th>' + columns_label[i] + '</th>';
    }
    theadTable += "</tr>";
    $("#tbInfInstruccionFinalMensual_Detalle").find("thead").append(theadTable);
    //**Cuerpo**----
    var optDt = { iLength: 20, iStart: 0, aSort: [] };
    var columns_hide = [12];

    _reporte.dtInfInstruccionFinalMensual_Detalle = $("#tbInfInstruccionFinalMensual_Detalle").DataTable({
        processing: true,
        searching: false,
        ordering: true,
        paging: true,
        ajax: {
            "url": urlLocalSigo + "General/ReporteSeguimientoRegistro/DetalleReporte",
            "data": function (params) {
                params.lstChkMesId = _reporte.rowMes;
                params.lstChkAnioId = _reporte.frm.find("#lstChkAnioId").val();
                params.hdfTipoReporte = "INSTRUCCION_FINAL_DETALLE";
            },
            "type": "POST",
            "error": function (jqXHR) {
                utilSigo.unblockUIGeneral();
                utilSigo.toastError("Error", initSigo.MessageError);
                console.log(jqXHR.responseText);
            }
        },
        columns: columns,
        bInfo: true,
        "lengthMenu": [[10, 20, 50, 100], [10, 20, 50, 100]],
        "aaSorting": optDt.aSort,
        "pageLength": optDt.iLength,
        "displayStart": optDt.iStart,
        "oLanguage": initSigo.oLanguage,
        "drawCallback": initSigo.showPagination,
        "dom": 'Bfrtip',
        "buttons": [{ extend: 'copyHtml5', footer: true, text: 'Copiar', title: _reporte.lblTituloCabecera, exportOptions: { columns: columns_hide }, messageTop: $("#tbInfInstruccionFinalMensual_Detalle").find("thead tr")[0].innerText.trim() },
            { extend: 'csvHtml5', footer: true, text: 'CSV', title: _reporte.lblTituloCabecera, exportOptions: { columns: columns_hide }, messageTop: $("#tbInfInstruccionFinalMensual_Detalle").find("thead tr")[0].innerText.trim() },
            { extend: 'excelHtml5', footer: true, text: 'Excel', title: _reporte.lblTituloCabecera, exportOptions: { columns: columns_hide }, messageTop: $("#tbInfInstruccionFinalMensual_Detalle").find("thead tr")[0].innerText.trim() },
            { extend: 'pdfHtml5', footer: true, text: 'PDF', title: _reporte.lblTituloCabecera, orientation: 'landscape', pageSize: 'LEGAL', exportOptions: { columns: columns_hide }, messageTop: $("#tbInfInstruccionFinalMensual_Detalle").find("thead tr")[0].innerText.trim() },
            { extend: 'print', footer: true, text: 'Imprimir', title: _reporte.lblTituloCabecera, exportOptions: { columns: columns_hide }, messageTop: $("#tbInfInstruccionFinalMensual_Detalle").find("thead tr")[0].innerText.trim() }]
    });

    _reporte.dtInfInstruccionFinalMensual_Detalle.on('order.dt search.dt', function () {
        _reporte.dtInfInstruccionFinalMensual_Detalle.column(0, { search: 'applied', order: 'applied' }).nodes().each(function (cell, i) {
            cell.innerHTML = i + 1;
            _reporte.dtInfInstruccionFinalMensual_Detalle.cell(cell).invalidate('dom');
        });
    }).draw();
}

_reporte.fnInitInfInstruccionFinal = function () {
    var chartInfInstruccionFinalMensual_Resumen = null;

    //Activar Filtros
    _reporte.frm.find("#dvFiltroAnio").show();
    $("#dvInfInstruccionFinalMensual").show();

    _reporte.rpt9InitDataTable();
    //Implementar eventos a ejecutar despúes de realizar una acción
    var fnLimpiarReporte = function () {
        _reporte.dtInfInstruccionFinalMensual_Resumen.clear().draw();
        _reporte.dtInfInstruccionFinalMensual_Detalle.clear().draw();
        _reporte.rowMes = "";
        var tb = $("#tbInfInstruccionFinalMensual_Resumen");
        tb.find("#col3").text(0); tb.find("#col4").text(0); tb.find("#col5").text(0);

        if (chartInfInstruccionFinalMensual_Resumen != null) {
            chartInfInstruccionFinalMensual_Resumen.clear();
            $("#cnvInfInstruccionFinalMensual_Resumen").hide();
        }
    }

    _reporte.filter_lstChkAnioId_change = function () {
        fnLimpiarReporte();
    }

    _reporte.fnSubmitForm = function () {
        _reporte.dtInfInstruccionFinalMensual_Resumen.clear().draw();
        _reporte.dtInfInstruccionFinalMensual_Detalle.clear().draw();
        if (_reporte.filterValidate()) {
            var datosReporte = _reporte.frm.serializeObject();
            var option = { url: _reporte.frm.attr("action"), datos: JSON.stringify(datosReporte), type: 'POST' };

            utilSigo.fnAjax(option, function (data) {
                if (data.success) {
                    _reporte.dtInfInstruccionFinalMensual_Resumen.rows.add(data.data).draw();

                    var c3 = 0, c4 = 0, c5 = 0;
                    for (var i = 0; i < data.data.length; i++) {
                        c3 += parseInt(data.data[i]["SUPERVISADO"]); c4 += parseInt(data.data[i]["SUPERVISADO_CA"]);
                        c5 += parseInt(data.data[i]["SUPERVISADO_DOC"]);
                    }

                    var tb = $("#tbInfInstruccionFinalMensual_Resumen");
                    tb.find("#col3").text(c3); tb.find("#col4").text(c4); tb.find("#col5").text(c5);

                    $("#cnvInfInstruccionFinalMensual_Resumen").show();
                    chartInfInstruccionFinalMensual_Resumen = customChart.LoadBarraSimple_DataTable(_reporte.dtInfInstruccionFinalMensual_Resumen, "MES_NOMBRE", { colIndex: [2, 3, 4], data: ["SUPERVISADO", "SUPERVISADO_CA", "SUPERVISADO_DOC"], color: ["green", "blue", "red"] }, { title: "", canvas: "cnvInfInstruccionFinalMensual_Resumen" });
                }
                else {
                    utilSigo.toastWarning("Aviso", "Sucedio un error, Comuníquese con el Administrador");
                    console.log(data.msj);
                }
            });
        }

        return false;
    }

    utilDt.fnEventColumn = function (obj, col) {
        var numMes = "";

        if (obj != "") {
            numMes = _reporte.dtInfInstruccionFinalMensual_Resumen.row($(obj).parents('tr')).data()["MES_"];
            _reporte.rowMes = numMes;
        }

        if (_reporte.filterValidate()) {
            _reporte.dtInfInstruccionFinalMensual_Detalle.ajax.reload();
        }

        return false;
    }
}
/******************Fin Reporte 9*****************/

/*REPORTE 10 - Seguimiento Informe Técnico*/
_reporte.rpt10InitDataTable = function () {
    var columns_label = [], columns_data = [], columns_event = [], options = {};

    //Tabla Resumen
    columns_label = ["Mes", "N° Informe Técnico registrados en SIGO - sfc", "N° Informe Técnico con control de calidad conforme", "N° Informe Técnico digitalizados"];
    columns_event = ["fn(c2)", "", "", ""];
    columns_data = ["MES_NOMBRE", "SUPERVISADO", "SUPERVISADO_CA", "SUPERVISADO_DOC"];
    options = {
        button_copy: true, button_csv: true, button_excel: true, button_pdf: true, button_print: true
        , export_title: $("#tbInfTecnicoMensual_Resumen").find("thead tr")[0].innerText.trim(), row_index: true
    };
    _reporte.dtInfTecnicoMensual_Resumen = utilDt.fnLoadDataTable_EventColumn($("#tbInfTecnicoMensual_Resumen"), columns_label, columns_data, columns_event, options);

    //Tabla Detalle
    columns_label = ["N°", "Mes", "N° Informe Técnico", "Tipo", "Fecha de emisión", "Fecha registro SIGO", "Titular", "Título", "Con Control de Calidad Conforme",
        "Estado del Documento", "Fecha registro Control de calidad", "Digitalizado", "Doc"];
    var columns = [
        { "name": "ROW_INDE", "width": "2%", "orderable": false, "searchable": false, "defaultContent": "" },
        { "data": "MES_NOMBRE", "autoWidth": true },
        { "data": "NUMERO_RD", "autoWidth": true },
        { "data": "TIPO_RD", "autoWidth": true },
        { "data": "FECHA_EMISION", "autoWidth": true },
        { "data": "FECHA", "autoWidth": true },
        { "data": "TITULAR", "autoWidth": true },
        { "data": "TITULO", "autoWidth": true },
        { "data": "CONTROL_CALIDAD", "autoWidth": true },
        { "data": "ESTADO_PAU", "autoWidth": true },
        { "data": "FECHA_CCA", "autoWidth": true },
        { "data": "DIGITALIZADO", "autoWidth": true },
        {
            "data": "", "width": "2%", "orderable": false, "searchable": false, "mRender": function (data, type, row) {
                if (row.CODIGO.trim() != "")
                    return '<div><i class="fa fa-lg fa-download" style="cursor:pointer;color:dodgerblue;" onclick="_reporte.fnValidaDocSIADO(\'' + row.CODIGO.trim() + '\')"></i>';
                else return "";
            }
        }
    ];

    //**Cabecera**----
    var theadTable = "<tr>";
    for (var i = 0; i < columns_label.length; i++) {
        theadTable += '<th>' + columns_label[i] + '</th>';
    }
    theadTable += "</tr>";
    $("#tbInfTecnicoMensual_Detalle").find("thead").append(theadTable);
    //**Cuerpo**----
    var optDt = { iLength: 20, iStart: 0, aSort: [] };
    var columns_hide = [12];

    _reporte.dtInfTecnicoMensual_Detalle = $("#tbInfTecnicoMensual_Detalle").DataTable({
        processing: true,
        searching: false,
        ordering: true,
        paging: true,
        ajax: {
            "url": urlLocalSigo + "General/ReporteSeguimientoRegistro/DetalleReporte",
            "data": function (params) {
                params.lstChkMesId = _reporte.rowMes;
                params.lstChkAnioId = _reporte.frm.find("#lstChkAnioId").val();
                params.hdfTipoReporte = "INF_TECNICO_DETALLE";
            },
            "type": "POST",
            "error": function (jqXHR) {
                utilSigo.unblockUIGeneral();
                utilSigo.toastError("Error", initSigo.MessageError);
                console.log(jqXHR.responseText);
            }
        },
        columns: columns,
        bInfo: true,
        "lengthMenu": [[10, 20, 50, 100], [10, 20, 50, 100]],
        "aaSorting": optDt.aSort,
        "pageLength": optDt.iLength,
        "displayStart": optDt.iStart,
        "oLanguage": initSigo.oLanguage,
        "drawCallback": initSigo.showPagination,
        "dom": 'Bfrtip',
        "buttons": [{ extend: 'copyHtml5', footer: true, text: 'Copiar', title: _reporte.lblTituloCabecera, exportOptions: { columns: columns_hide }, messageTop: $("#tbInfTecnicoMensual_Detalle").find("thead tr")[0].innerText.trim() },
            { extend: 'csvHtml5', footer: true, text: 'CSV', title: _reporte.lblTituloCabecera, exportOptions: { columns: columns_hide }, messageTop: $("#tbInfTecnicoMensual_Detalle").find("thead tr")[0].innerText.trim() },
            { extend: 'excelHtml5', footer: true, text: 'Excel', title: _reporte.lblTituloCabecera, exportOptions: { columns: columns_hide }, messageTop: $("#tbInfTecnicoMensual_Detalle").find("thead tr")[0].innerText.trim() },
            { extend: 'pdfHtml5', footer: true, text: 'PDF', title: _reporte.lblTituloCabecera, orientation: 'landscape', pageSize: 'LEGAL', exportOptions: { columns: columns_hide }, messageTop: $("#tbInfTecnicoMensual_Detalle").find("thead tr")[0].innerText.trim() },
            { extend: 'print', footer: true, text: 'Imprimir', title: _reporte.lblTituloCabecera, exportOptions: { columns: columns_hide }, messageTop: $("#tbInfTecnicoMensual_Detalle").find("thead tr")[0].innerText.trim() }]
    });

    _reporte.dtInfTecnicoMensual_Detalle.on('order.dt search.dt', function () {
        _reporte.dtInfTecnicoMensual_Detalle.column(0, { search: 'applied', order: 'applied' }).nodes().each(function (cell, i) {
            cell.innerHTML = i + 1;
            _reporte.dtInfTecnicoMensual_Detalle.cell(cell).invalidate('dom');
        });
    }).draw();
}

_reporte.fnInitInfTecnico = function () {
    var chartInfTecnicoMensual_Resumen = null;

    //Activar Filtros
    _reporte.frm.find("#dvFiltroAnio").show();
    $("#dvInfTecnicoMensual").show();

    _reporte.rpt10InitDataTable();
    //Implementar eventos a ejecutar despúes de realizar una acción
    var fnLimpiarReporte = function () {
        _reporte.dtInfTecnicoMensual_Resumen.clear().draw();
        _reporte.dtInfTecnicoMensual_Detalle.clear().draw();
        _reporte.rowMes = "";
        var tb = $("#tbInfTecnicoMensual_Resumen");
        tb.find("#col3").text(0); tb.find("#col4").text(0); tb.find("#col5").text(0);

        if (chartInfTecnicoMensual_Resumen != null) {
            chartInfTecnicoMensual_Resumen.clear();
            $("#cnvInfTecnicoMensual_Resumen").hide();
        }
    }

    _reporte.filter_lstChkAnioId_change = function () {
        fnLimpiarReporte();
    }

    _reporte.fnSubmitForm = function () {
        _reporte.dtInfTecnicoMensual_Resumen.clear().draw();
        _reporte.dtInfTecnicoMensual_Detalle.clear().draw();
        if (_reporte.filterValidate()) {
            var datosReporte = _reporte.frm.serializeObject();
            var option = { url: _reporte.frm.attr("action"), datos: JSON.stringify(datosReporte), type: 'POST' };

            utilSigo.fnAjax(option, function (data) {
                if (data.success) {
                    _reporte.dtInfTecnicoMensual_Resumen.rows.add(data.data).draw();

                    var c3 = 0, c4 = 0, c5 = 0;
                    for (var i = 0; i < data.data.length; i++) {
                        c3 += parseInt(data.data[i]["SUPERVISADO"]); c4 += parseInt(data.data[i]["SUPERVISADO_CA"]);
                        c5 += parseInt(data.data[i]["SUPERVISADO_DOC"]);
                    }

                    var tb = $("#tbInfTecnicoMensual_Resumen");
                    tb.find("#col3").text(c3); tb.find("#col4").text(c4); tb.find("#col5").text(c5);

                    $("#cnvInfTecnicoMensual_Resumen").show();
                    chartInfTecnicoMensual_Resumen = customChart.LoadBarraSimple_DataTable(_reporte.dtInfTecnicoMensual_Resumen, "MES_NOMBRE", { colIndex: [2, 3, 4], data: ["SUPERVISADO", "SUPERVISADO_CA", "SUPERVISADO_DOC"], color: ["green", "blue", "red"] }, { title: "", canvas: "cnvInfTecnicoMensual_Resumen" });
                }
                else {
                    utilSigo.toastWarning("Aviso", "Sucedio un error, Comuníquese con el Administrador");
                    console.log(data.msj);
                }
            });
        }

        return false;
    }

    utilDt.fnEventColumn = function (obj, col) {
        var numMes = "";

        if (obj != "") {
            numMes = _reporte.dtInfTecnicoMensual_Resumen.row($(obj).parents('tr')).data()["MES_"];
            _reporte.rowMes = numMes;
        }

        if (_reporte.filterValidate()) {
            _reporte.dtInfTecnicoMensual_Detalle.ajax.reload();
        }

        return false;
    }
}
/******************Fin Reporte 10*****************/

/*REPORTE 11 - Seguimiento Notificaciones Fiscalización*/
_reporte.rpt11InitDataTable = function () {
    var columns_label = [], columns_data = [], columns_event = [], options = {};

    //Tabla Resumen
    columns_label = ["Mes", "N° Notificaciones registrados en SIGO - sfc", "N° Notificaciones con control de calidad conforme", "N° Notificaciones digitalizados"];
    columns_event = ["fn(c2)", "", "", ""];
    columns_data = ["MES_NOMBRE", "SUPERVISADO", "SUPERVISADO_CA", "SUPERVISADO_DOC"];
    options = {
        button_copy: true, button_csv: true, button_excel: true, button_pdf: true, button_print: true
        , export_title: $("#tbNotificacionesMensual_Resumen").find("thead tr")[0].innerText.trim(), row_index: true
    };
    _reporte.dtNotificacionesMensual_Resumen = utilDt.fnLoadDataTable_EventColumn($("#tbNotificacionesMensual_Resumen"), columns_label, columns_data, columns_event, options);

    //Tabla Detalle
    columns_label = ["N°", "Mes", "N° Notificaciones", "Tipo", "Fecha de emisión", "Fecha registro SIGO", "Titular", "Título", "Con Control de Calidad Conforme",
        "Estado del Documento", "Fecha registro Control de calidad", "Digitalizado", "Doc"];
    var columns = [
        { "name": "ROW_INDE", "width": "2%", "orderable": false, "searchable": false, "defaultContent": "" },
        { "data": "MES_NOMBRE", "autoWidth": true },
        { "data": "NUMERO_RD", "autoWidth": true },
        { "data": "TIPO_RD", "autoWidth": true },
        { "data": "FECHA_EMISION", "autoWidth": true },
        { "data": "FECHA", "autoWidth": true },
        { "data": "TITULAR", "autoWidth": true },
        { "data": "TITULO", "autoWidth": true },
        { "data": "CONTROL_CALIDAD", "autoWidth": true },
        { "data": "ESTADO_PAU", "autoWidth": true },
        { "data": "FECHA_CCA", "autoWidth": true },
        { "data": "DIGITALIZADO", "autoWidth": true },
        {
            "data": "", "width": "2%", "orderable": false, "searchable": false, "mRender": function (data, type, row) {
                if (row.CODIGO.trim() != "")
                    return '<div><i class="fa fa-lg fa-download" style="cursor:pointer;color:dodgerblue;" onclick="_reporte.fnValidaDocSIADO(\'' + row.CODIGO.trim() + '\')"></i>';
                else return "";
            }
        }
    ];

    //**Cabecera**----
    var theadTable = "<tr>";
    for (var i = 0; i < columns_label.length; i++) {
        theadTable += '<th>' + columns_label[i] + '</th>';
    }
    theadTable += "</tr>";
    $("#tbNotificacionesMensual_Detalle").find("thead").append(theadTable);
    //**Cuerpo**----
    var optDt = { iLength: 20, iStart: 0, aSort: [] };
    var columns_hide = [12];

    _reporte.dtNotificacionesMensual_Detalle = $("#tbNotificacionesMensual_Detalle").DataTable({
        processing: true,
        searching: false,
        ordering: true,
        paging: true,
        ajax: {
            "url": urlLocalSigo + "General/ReporteSeguimientoRegistro/DetalleReporte",
            "data": function (params) {
                params.lstChkMesId = _reporte.rowMes;
                params.lstChkAnioId = _reporte.frm.find("#lstChkAnioId").val();
                params.hdfTipoReporte = "NOTIFICACIONES_DETALLE";
            },
            "type": "POST",
            "error": function (jqXHR) {
                utilSigo.unblockUIGeneral();
                utilSigo.toastError("Error", initSigo.MessageError);
                console.log(jqXHR.responseText);
            }
        },
        columns: columns,
        bInfo: true,
        "lengthMenu": [[10, 20, 50, 100], [10, 20, 50, 100]],
        "aaSorting": optDt.aSort,
        "pageLength": optDt.iLength,
        "displayStart": optDt.iStart,
        "oLanguage": initSigo.oLanguage,
        "drawCallback": initSigo.showPagination,
        "dom": 'Bfrtip',
        "buttons": [{ extend: 'copyHtml5', footer: true, text: 'Copiar', title: _reporte.lblTituloCabecera, exportOptions: { columns: columns_hide }, messageTop: $("#tbNotificacionesMensual_Detalle").find("thead tr")[0].innerText.trim() },
            { extend: 'csvHtml5', footer: true, text: 'CSV', title: _reporte.lblTituloCabecera, exportOptions: { columns: columns_hide }, messageTop: $("#tbNotificacionesMensual_Detalle").find("thead tr")[0].innerText.trim() },
            { extend: 'excelHtml5', footer: true, text: 'Excel', title: _reporte.lblTituloCabecera, exportOptions: { columns: columns_hide }, messageTop: $("#tbNotificacionesMensual_Detalle").find("thead tr")[0].innerText.trim() },
            { extend: 'pdfHtml5', footer: true, text: 'PDF', title: _reporte.lblTituloCabecera, orientation: 'landscape', pageSize: 'LEGAL', exportOptions: { columns: columns_hide }, messageTop: $("#tbNotificacionesMensual_Detalle").find("thead tr")[0].innerText.trim() },
            { extend: 'print', footer: true, text: 'Imprimir', title: _reporte.lblTituloCabecera, exportOptions: { columns: columns_hide }, messageTop: $("#tbNotificacionesMensual_Detalle").find("thead tr")[0].innerText.trim() }]
    });

    _reporte.dtNotificacionesMensual_Detalle.on('order.dt search.dt', function () {
        _reporte.dtNotificacionesMensual_Detalle.column(0, { search: 'applied', order: 'applied' }).nodes().each(function (cell, i) {
            cell.innerHTML = i + 1;
            _reporte.dtNotificacionesMensual_Detalle.cell(cell).invalidate('dom');
        });
    }).draw();
}

_reporte.fnInitNotificaciones = function () {
    var chartNotificacionesMensual_Resumen = null;

    //Activar Filtros
    _reporte.frm.find("#dvFiltroAnio").show();
    $("#dvNotificacionesMensual").show();

    _reporte.rpt11InitDataTable();
    //Implementar eventos a ejecutar despúes de realizar una acción
    var fnLimpiarReporte = function () {
        _reporte.dtNotificacionesMensual_Resumen.clear().draw();
        _reporte.dtNotificacionesMensual_Detalle.clear().draw();
        _reporte.rowMes = "";
        var tb = $("#tbNotificacionesMensual_Resumen");
        tb.find("#col3").text(0); tb.find("#col4").text(0); tb.find("#col5").text(0);

        if (chartNotificacionesMensual_Resumen != null) {
            chartNotificacionesMensual_Resumen.clear();
            $("#cnvNotificacionesMensual_Resumen").hide();
        }
    }

    _reporte.filter_lstChkAnioId_change = function () {
        fnLimpiarReporte();
    }

    _reporte.fnSubmitForm = function () {
        _reporte.dtNotificacionesMensual_Resumen.clear().draw();
        _reporte.dtNotificacionesMensual_Detalle.clear().draw();
        if (_reporte.filterValidate()) {
            var datosReporte = _reporte.frm.serializeObject();
            var option = { url: _reporte.frm.attr("action"), datos: JSON.stringify(datosReporte), type: 'POST' };

            utilSigo.fnAjax(option, function (data) {
                if (data.success) {
                    _reporte.dtNotificacionesMensual_Resumen.rows.add(data.data).draw();

                    var c3 = 0, c4 = 0, c5 = 0;
                    for (var i = 0; i < data.data.length; i++) {
                        c3 += parseInt(data.data[i]["SUPERVISADO"]); c4 += parseInt(data.data[i]["SUPERVISADO_CA"]);
                        c5 += parseInt(data.data[i]["SUPERVISADO_DOC"]);
                    }

                    var tb = $("#tbNotificacionesMensual_Resumen");
                    tb.find("#col3").text(c3); tb.find("#col4").text(c4); tb.find("#col5").text(c5);

                    $("#cnvNotificacionesMensual_Resumen").show();
                    chartNotificacionesMensual_Resumen = customChart.LoadBarraSimple_DataTable(_reporte.dtNotificacionesMensual_Resumen, "MES_NOMBRE", { colIndex: [2, 3, 4], data: ["SUPERVISADO", "SUPERVISADO_CA", "SUPERVISADO_DOC"], color: ["green", "blue", "red"] }, { title: "", canvas: "cnvNotificacionesMensual_Resumen" });
                }
                else {
                    utilSigo.toastWarning("Aviso", "Sucedio un error, Comuníquese con el Administrador");
                    console.log(data.msj);
                }
            });
        }

        return false;
    }

    utilDt.fnEventColumn = function (obj, col) {
        var numMes = "";

        if (obj != "") {
            numMes = _reporte.dtNotificacionesMensual_Resumen.row($(obj).parents('tr')).data()["MES_"];
            _reporte.rowMes = numMes;
        }

        if (_reporte.filterValidate()) {
            _reporte.dtNotificacionesMensual_Detalle.ajax.reload();
        }

        return false;
    }
}
/******************Fin Reporte 11*****************/

/*REPORTE 12 - Seguimiento Documentos presentados por el Titular*/
_reporte.rpt12InitDataTable = function () {
    var columns_label = [], columns_data = [], columns_event = [], options = {};

    //Tabla Resumen
    columns_label = ["Mes", "N° de documentos presentados por el titular", "N° de documentos presentados por el titular con control de calidad conforme", "N° de documentos presentados por el titular digitalizados"];
    columns_event = ["fn(c2)", "", "", ""];
    columns_data = ["MES_NOMBRE", "SUPERVISADO", "SUPERVISADO_CA", "SUPERVISADO_DOC"];
    options = {
        button_copy: true, button_csv: true, button_excel: true, button_pdf: true, button_print: true
        , export_title: $("#tbInfTitularMensual_Resumen").find("thead tr")[0].innerText.trim(), row_index: true
    };
    _reporte.dtInfTitularMensual_Resumen = utilDt.fnLoadDataTable_EventColumn($("#tbInfTitularMensual_Resumen"), columns_label, columns_data, columns_event, options);

    //Tabla Detalle
    columns_label = ["N°", "Mes", "N° de documentos presentados por el titular", "Tipo", "Fecha de emisión", "Fecha registro SIGO", "Titular", "Título", "Con Control de Calidad Conforme",
        "Estado del Documento", "Fecha registro Control de calidad", "Digitalizado", "Doc"];
    var columns = [
        { "name": "ROW_INDE", "width": "2%", "orderable": false, "searchable": false, "defaultContent": "" },
        { "data": "MES_NOMBRE", "autoWidth": true },
        { "data": "NUMERO_RD", "autoWidth": true },
        { "data": "TIPO_RD", "autoWidth": true },
        { "data": "FECHA_EMISION", "autoWidth": true },
        { "data": "FECHA", "autoWidth": true },
        { "data": "TITULAR", "autoWidth": true },
        { "data": "TITULO", "autoWidth": true },
        { "data": "CONTROL_CALIDAD", "autoWidth": true },
        { "data": "ESTADO_PAU", "autoWidth": true },
        { "data": "FECHA_CCA", "autoWidth": true },
        { "data": "DIGITALIZADO", "autoWidth": true },
        {
            "data": "", "width": "2%", "orderable": false, "searchable": false, "mRender": function (data, type, row) {
                if (row.CODIGO.trim() != "")
                    return '<div><i class="fa fa-lg fa-download" style="cursor:pointer;color:dodgerblue;" onclick="_reporte.fnValidaDocSIADO(\'' + row.CODIGO.trim() + '\')"></i>';
                else return "";
            }
        }
    ];

    //**Cabecera**----
    var theadTable = "<tr>";
    for (var i = 0; i < columns_label.length; i++) {
        theadTable += '<th>' + columns_label[i] + '</th>';
    }
    theadTable += "</tr>";
    $("#tbInfTitularMensual_Detalle").find("thead").append(theadTable);
    //**Cuerpo**----
    var optDt = { iLength: 20, iStart: 0, aSort: [] };
    var columns_hide = [12];

    _reporte.dtInfTitularMensual_Detalle = $("#tbInfTitularMensual_Detalle").DataTable({
        processing: true,
        searching: false,
        ordering: true,
        paging: true,
        ajax: {
            "url": urlLocalSigo + "General/ReporteSeguimientoRegistro/DetalleReporte",
            "data": function (params) {
                params.lstChkMesId = _reporte.rowMes;
                params.lstChkAnioId = _reporte.frm.find("#lstChkAnioId").val();
                params.hdfTipoReporte = "INFTIT_DETALLE";
            },
            "type": "POST",
            "error": function (jqXHR) {
                utilSigo.unblockUIGeneral();
                utilSigo.toastError("Error", initSigo.MessageError);
                console.log(jqXHR.responseText);
            }
        },
        columns: columns,
        bInfo: true,
        "lengthMenu": [[10, 20, 50, 100], [10, 20, 50, 100]],
        "aaSorting": optDt.aSort,
        "pageLength": optDt.iLength,
        "displayStart": optDt.iStart,
        "oLanguage": initSigo.oLanguage,
        "drawCallback": initSigo.showPagination,
        "dom": 'Bfrtip',
        "buttons": [{ extend: 'copyHtml5', footer: true, text: 'Copiar', title: _reporte.lblTituloCabecera, exportOptions: { columns: columns_hide }, messageTop: $("#tbInfTitularMensual_Detalle").find("thead tr")[0].innerText.trim() },
            { extend: 'csvHtml5', footer: true, text: 'CSV', title: _reporte.lblTituloCabecera, exportOptions: { columns: columns_hide }, messageTop: $("#tbInfTitularMensual_Detalle").find("thead tr")[0].innerText.trim() },
            { extend: 'excelHtml5', footer: true, text: 'Excel', title: _reporte.lblTituloCabecera, exportOptions: { columns: columns_hide }, messageTop: $("#tbInfTitularMensual_Detalle").find("thead tr")[0].innerText.trim() },
            { extend: 'pdfHtml5', footer: true, text: 'PDF', title: _reporte.lblTituloCabecera, orientation: 'landscape', pageSize: 'LEGAL', exportOptions: { columns: columns_hide }, messageTop: $("#tbInfTitularMensual_Detalle").find("thead tr")[0].innerText.trim() },
            { extend: 'print', footer: true, text: 'Imprimir', title: _reporte.lblTituloCabecera, exportOptions: { columns: columns_hide }, messageTop: $("#tbInfTitularMensual_Detalle").find("thead tr")[0].innerText.trim() }]
    });

    _reporte.dtInfTitularMensual_Detalle.on('order.dt search.dt', function () {
        _reporte.dtInfTitularMensual_Detalle.column(0, { search: 'applied', order: 'applied' }).nodes().each(function (cell, i) {
            cell.innerHTML = i + 1;
            _reporte.dtInfTitularMensual_Detalle.cell(cell).invalidate('dom');
        });
    }).draw();
}

_reporte.fnInitInfTitular = function () {
    var chartInfTitularMensual_Resumen = null;

    //Activar Filtros
    _reporte.frm.find("#dvFiltroAnio").show();
    $("#dvInfTitularMensual").show();

    _reporte.rpt12InitDataTable();
    //Implementar eventos a ejecutar despúes de realizar una acción
    var fnLimpiarReporte = function () {
        _reporte.dtInfTitularMensual_Resumen.clear().draw();
        _reporte.dtInfTitularMensual_Detalle.clear().draw();
        _reporte.rowMes = "";
        var tb = $("#tbInfTitularMensual_Resumen");
        tb.find("#col3").text(0); tb.find("#col4").text(0); tb.find("#col5").text(0);

        if (chartInfTitularMensual_Resumen != null) {
            chartInfTitularMensual_Resumen.clear();
            $("#cnvInfTitularMensual_Resumen").hide();
        }
    }

    _reporte.filter_lstChkAnioId_change = function () {
        fnLimpiarReporte();
    }

    _reporte.fnSubmitForm = function () {
        _reporte.dtInfTitularMensual_Resumen.clear().draw();
        _reporte.dtInfTitularMensual_Detalle.clear().draw();
        if (_reporte.filterValidate()) {
            var datosReporte = _reporte.frm.serializeObject();
            var option = { url: _reporte.frm.attr("action"), datos: JSON.stringify(datosReporte), type: 'POST' };

            utilSigo.fnAjax(option, function (data) {
                if (data.success) {
                    _reporte.dtInfTitularMensual_Resumen.rows.add(data.data).draw();

                    var c3 = 0, c4 = 0, c5 = 0;
                    for (var i = 0; i < data.data.length; i++) {
                        c3 += parseInt(data.data[i]["SUPERVISADO"]); c4 += parseInt(data.data[i]["SUPERVISADO_CA"]);
                        c5 += parseInt(data.data[i]["SUPERVISADO_DOC"]);
                    }

                    var tb = $("#tbInfTitularMensual_Resumen");
                    tb.find("#col3").text(c3); tb.find("#col4").text(c4); tb.find("#col5").text(c5);

                    $("#cnvInfTitularMensual_Resumen").show();
                    chartInfTitularMensual_Resumen = customChart.LoadBarraSimple_DataTable(_reporte.dtInfTitularMensual_Resumen, "MES_NOMBRE", { colIndex: [2, 3, 4], data: ["SUPERVISADO", "SUPERVISADO_CA", "SUPERVISADO_DOC"], color: ["green", "blue", "red"] }, { title: "", canvas: "cnvInfTitularMensual_Resumen" });
                }
                else {
                    utilSigo.toastWarning("Aviso", "Sucedio un error, Comuníquese con el Administrador");
                    console.log(data.msj);
                }
            });
        }

        return false;
    }

    utilDt.fnEventColumn = function (obj, col) {
        var numMes = "";

        if (obj != "") {
            numMes = _reporte.dtInfTitularMensual_Resumen.row($(obj).parents('tr')).data()["MES_"];
            _reporte.rowMes = numMes;
        }

        if (_reporte.filterValidate()) {
            _reporte.dtInfTitularMensual_Detalle.ajax.reload();
        }

        return false;
    }
}
/******************Fin Reporte 12*****************/

/*REPORTE 13 - Seguimiento Capacitaciones registrados*/
_reporte.rpt13InitDataTable = function () {
    var columns_label = [], columns_data = [], columns_event = [], options = {};

    //Tabla Resumen
    columns_label = ["Mes", "N° Capacitaciones programadas", "N° Capacitaciones registrados en SIGO - sfc", "N° capacitaciones con control de calidad conforme", "N° memorias de capacitaciones digitalizados"];
    columns_event = ["fn(c2)", "", "", "", ""];
    columns_data = ["MES_NOMBRE", "PROGRAMADO", "SUPERVISADO", "SUPERVISADO_CA", "SUPERVISADO_DOC"];
    options = {
        button_copy: true, button_csv: true, button_excel: true, button_pdf: true, button_print: true
        , export_title: $("#tbCapacitacionesMensual_Resumen").find("thead tr")[0].innerText.trim(), row_index: true
    };
    _reporte.dtCapacitacionesMensual_Resumen = utilDt.fnLoadDataTable_EventColumn($("#tbCapacitacionesMensual_Resumen"), columns_label, columns_data, columns_event, options);

    //Tabla Detalle
    columns_label = ["N°", "Mes", "Nombre Taller", "Tipo Taller", "Fecha de ejecución", "Fecha registro SIGO", "O. D.", "Región", "Con Control de Calidad Conforme",
        "Estado del Documento", "Fecha registro Control de calidad", "Digitalizado", "Doc"];
    var columns = [
        { "name": "ROW_INDE", "width": "2%", "orderable": false, "searchable": false, "defaultContent": "" },
        { "data": "MES_NOMBRE", "autoWidth": true },
        { "data": "NUMERO_RD", "autoWidth": true },
        { "data": "TIPO_RD", "autoWidth": true },
        { "data": "FECHA_EMISION", "autoWidth": true },
        { "data": "FECHA", "autoWidth": true },
        { "data": "TITULAR", "autoWidth": true },
        { "data": "TITULO", "autoWidth": true },
        { "data": "CONTROL_CALIDAD", "autoWidth": true },
        { "data": "ESTADO_PAU", "autoWidth": true },
        { "data": "FECHA_CCA", "autoWidth": true },
        { "data": "DIGITALIZADO", "autoWidth": true },
        {
            "data": "", "width": "2%", "orderable": false, "searchable": false, "mRender": function (data, type, row) {
                if (row.CODIGO.trim() != "")
                    return '<div><i class="fa fa-lg fa-download" style="cursor:pointer;color:dodgerblue;" onclick="_reporte.fnValidaDocSIADO(\'' + row.CODIGO.trim() + '\')"></i>';
                else return "";
            }
        }
    ];

    //**Cabecera**----
    var theadTable = "<tr>";
    for (var i = 0; i < columns_label.length; i++) {
        theadTable += '<th>' + columns_label[i] + '</th>';
    }
    theadTable += "</tr>";
    $("#tbCapacitacionesMensual_Detalle").find("thead").append(theadTable);
    //**Cuerpo**----
    var optDt = { iLength: 20, iStart: 0, aSort: [] };
    var columns_hide = [12];

    _reporte.dtCapacitacionesMensual_Detalle = $("#tbCapacitacionesMensual_Detalle").DataTable({
        processing: true,
        searching: false,
        ordering: true,
        paging: true,
        ajax: {
            "url": urlLocalSigo + "General/ReporteSeguimientoRegistro/DetalleReporte",
            "data": function (params) {
                params.lstChkMesId = _reporte.rowMes;
                params.lstChkAnioId = _reporte.frm.find("#lstChkAnioId").val();
                params.hdfTipoReporte = "CAPACITACION_DETALLE";
            },
            "type": "POST",
            "error": function (jqXHR) {
                utilSigo.unblockUIGeneral();
                utilSigo.toastError("Error", initSigo.MessageError);
                console.log(jqXHR.responseText);
            }
        },
        columns: columns,
        bInfo: true,
        "lengthMenu": [[10, 20, 50, 100], [10, 20, 50, 100]],
        "aaSorting": optDt.aSort,
        "pageLength": optDt.iLength,
        "displayStart": optDt.iStart,
        "oLanguage": initSigo.oLanguage,
        "drawCallback": initSigo.showPagination,
        "dom": 'Bfrtip',
        "buttons": [{ extend: 'copyHtml5', footer: true, text: 'Copiar', title: _reporte.lblTituloCabecera, exportOptions: { columns: columns_hide }, messageTop: $("#tbCapacitacionesMensual_Detalle").find("thead tr")[0].innerText.trim() },
            { extend: 'csvHtml5', footer: true, text: 'CSV', title: _reporte.lblTituloCabecera, exportOptions: { columns: columns_hide }, messageTop: $("#tbCapacitacionesMensual_Detalle").find("thead tr")[0].innerText.trim() },
            { extend: 'excelHtml5', footer: true, text: 'Excel', title: _reporte.lblTituloCabecera, exportOptions: { columns: columns_hide }, messageTop: $("#tbCapacitacionesMensual_Detalle").find("thead tr")[0].innerText.trim() },
            { extend: 'pdfHtml5', footer: true, text: 'PDF', title: _reporte.lblTituloCabecera, orientation: 'landscape', pageSize: 'LEGAL', exportOptions: { columns: columns_hide }, messageTop: $("#tbCapacitacionesMensual_Detalle").find("thead tr")[0].innerText.trim() },
            { extend: 'print', footer: true, text: 'Imprimir', title: _reporte.lblTituloCabecera, exportOptions: { columns: columns_hide }, messageTop: $("#tbCapacitacionesMensual_Detalle").find("thead tr")[0].innerText.trim() }]
    });

    _reporte.dtCapacitacionesMensual_Detalle.on('order.dt search.dt', function () {
        _reporte.dtCapacitacionesMensual_Detalle.column(0, { search: 'applied', order: 'applied' }).nodes().each(function (cell, i) {
            cell.innerHTML = i + 1;
            _reporte.dtCapacitacionesMensual_Detalle.cell(cell).invalidate('dom');
        });
    }).draw();
}

_reporte.fnInitCapacitaciones = function () {
    var chartCapacitacionesMensual_Resumen = null;

    //Activar Filtros
    _reporte.frm.find("#dvFiltroAnio").show();
    $("#dvCapacitacionesMensual").show();

    _reporte.rpt13InitDataTable();
    //Implementar eventos a ejecutar despúes de realizar una acción
    var fnLimpiarReporte = function () {
        _reporte.dtCapacitacionesMensual_Resumen.clear().draw();
        _reporte.dtCapacitacionesMensual_Detalle.clear().draw();
        _reporte.rowMes = "";
        var tb = $("#tbCapacitacionesMensual_Resumen");
        tb.find("#col3").text(0); tb.find("#col4").text(0); tb.find("#col5").text(0); tb.find("#col6").text(0);

        if (chartCapacitacionesMensual_Resumen != null) {
            chartCapacitacionesMensual_Resumen.clear();
            $("#cnvCapacitacionesMensual_Resumen").hide();
        }
    }

    _reporte.filter_lstChkAnioId_change = function () {
        fnLimpiarReporte();
    }

    _reporte.fnSubmitForm = function () {
        _reporte.dtCapacitacionesMensual_Resumen.clear().draw();
        _reporte.dtCapacitacionesMensual_Detalle.clear().draw();
        if (_reporte.filterValidate()) {
            var datosReporte = _reporte.frm.serializeObject();
            var option = { url: _reporte.frm.attr("action"), datos: JSON.stringify(datosReporte), type: 'POST' };

            utilSigo.fnAjax(option, function (data) {
                if (data.success) {
                    _reporte.dtCapacitacionesMensual_Resumen.rows.add(data.data).draw();

                    var c3 = 0, c4 = 0, c5 = 0, c6 = 0;
                    for (var i = 0; i < data.data.length; i++) {
                        c3 += parseInt(data.data[i]["PROGRAMADO"]); c4 += parseInt(data.data[i]["SUPERVISADO"]);
                        c5 += parseInt(data.data[i]["SUPERVISADO_CA"]); c6 += parseInt(data.data[i]["SUPERVISADO_DOC"]);
                    }

                    var tb = $("#tbCapacitacionesMensual_Resumen");
                    tb.find("#col3").text(c3); tb.find("#col4").text(c4); tb.find("#col5").text(c5); tb.find("#col6").text(c6);

                    $("#cnvCapacitacionesMensual_Resumen").show();
                    chartCapacitacionesMensual_Resumen = customChart.LoadBarraSimple_DataTable(_reporte.dtCapacitacionesMensual_Resumen, "MES_NOMBRE", { colIndex: [2, 3, 4, 5], data: ["PROGRAMADO", "SUPERVISADO", "SUPERVISADO_CA", "SUPERVISADO_DOC"], color: ["green", "blue", "red", "yellow"] }, { title: "", canvas: "cnvCapacitacionesMensual_Resumen" });
                }
                else {
                    utilSigo.toastWarning("Aviso", "Sucedio un error, Comuníquese con el Administrador");
                    console.log(data.msj);
                }
            });
        }

        return false;
    }

    utilDt.fnEventColumn = function (obj, col) {
        var numMes = "";

        if (obj != "") {
            numMes = _reporte.dtCapacitacionesMensual_Resumen.row($(obj).parents('tr')).data()["MES_"];
            _reporte.rowMes = numMes;
        }

        if (_reporte.filterValidate()) {
            _reporte.dtCapacitacionesMensual_Detalle.ajax.reload();
        }

        return false;
    }
}
/******************Fin Reporte 13*****************/

_reporte.fnValidaDocSIADO = function (nomfile) {
    $.ajax({
        url: urlLocalSigo + "General/ReporteSeguimientoRegistro/ValidaDocSIADO",
        dataType: 'json',
        type: 'POST',
        data: { codigo: nomfile },
        success: function (response) {
            if (response.success) {
                _reporte.fnDownloadInfSIADO(response.msj);
            }
            else {
                utilSigo.toastWarning("Aviso", response.msj);
            }
            
        }
    });  
}
_reporte.fnDownloadInfSIADO = function (nomfile) {
    var iframe = document.createElement("iframe");
    iframe.src = urlLocalSigo + "General/ReporteSeguimientoRegistro/DescargarDocSIADO?nomarchivo=" + nomfile;
    iframe.style.display = "none";
    $("#divIframe").html(iframe);
}

$(document).ready(function () {
    _reporte.contenedor = "frmReporteSeguimientoRegistro";
    _reporte.frm = $("#" + _reporte.contenedor);

    _reporte.fnInitFiltro();

    switch (_reporte.frm.find("#hdfTipoReporte").val()) {
        case "INFSUPERVISION":
            _reporte.fnInitInfSupervision();
            break;
        case "INFSUSPENSION":
            _reporte.fnInitInfSuspension();
            break;
        case "INFQUINQUENAL":
            _reporte.fnInitInfQuinquenal();
            break;
        case "VMC":
            _reporte.fnInitInfVMC();
            break;
        case "TH":
            _reporte.fnInitTituloHabilitante();
            break;
        case "POA":
            _reporte.fnInitPOA();
            break;
        case "RD":
            _reporte.fnInitResolucionDirectoral();
            break;
        case "ILEGAL":
            _reporte.fnInitInfLegal();
            break;
        case "INSTRUCCION_FINAL":
            _reporte.fnInitInfInstruccionFinal();
            break;
        case "INF_TECNICO":
            _reporte.fnInitInfTecnico();
            break;
        case "NOTIFICACIONES":
            _reporte.fnInitNotificaciones();
            break;
        case "INFTIT":
            _reporte.fnInitInfTitular();
            break;
        case "CAPACITACION":
            _reporte.fnInitCapacitaciones();
            break;
    }
});