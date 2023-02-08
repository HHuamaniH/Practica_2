
"use strict";
var _reporte = {};

_reporte.lblTituloCabecera = "";
_reporte.columns_label;
_reporte.columns_data;

_reporte.fnLoadTituloCabecera = function (titulo) {
    _reporte.lblTituloCabecera = titulo;
};

/*GENERAL*/
_reporte.fnSubmitForm = function () { /*Implementar de acuerdo al reporte consultado*/ }
/*******************Fin General********************/

/*FILTROS Reporte*/
_reporte.filter_lstChkModalidadId_change = function () { /*Implementar de acuerdo al reporte consultado*/ }
_reporte.filter_lstChkRegionId_change = function () { /*Implementar de acuerdo al reporte consultado*/ }
/*******************Fin Filtros Reportes********************/

_reporte.filterModalidadGetAllCheck = function () {
    var selectModalidad = "";
    for (var i = 1; i <= _reporte.frm.find("[id*=lstChkModalidad]").length; i++) {
        if (i % 2 == 0) {
            if (_reporte.frm.find("[id*=lstChkModalidad]")[i - 1].checked) {
                selectModalidad += selectModalidad == "" ? "" : ",";
                selectModalidad += _reporte.frm.find("[id*=lstChkModalidad]")[i - 2].value;
            }
        }
    }
    _reporte.frm.find("#lstChkModalidadId").val(selectModalidad);
}
_reporte.filterRegionGetAllCheck = function () {
    var selectRegion = "";
    for (var i = 1; i <= _reporte.frm.find("[id*=lstChkRegion]").length; i++) {
        if (i % 2 == 0) {
            if (_reporte.frm.find("[id*=lstChkRegion]")[i - 1].checked) {
                selectRegion += selectRegion == "" ? "" : ",";
                selectRegion += _reporte.frm.find("[id*=lstChkRegion]")[i - 2].value;
            }
        }
    }
    _reporte.frm.find("#lstChkRegionId").val(selectRegion);
}
_reporte.filterValidate = function () {
    var sShow = "none";

    sShow = _reporte.frm.find("#dvFiltroModalidad")[0].style.display;
    if (sShow == "") {
        if (_reporte.frm.find("#lstChkModalidadId").val() == "") {
            utilSigo.toastWarning("Aviso", "Seleccione una o más Modalidades de Aprovechamiento a Consultar"); return false;
        }
    }
    sShow = _reporte.frm.find("#dvFiltroRegion")[0].style.display;
    if (sShow == "") {
        if (_reporte.frm.find("#lstChkRegionId").val() == "") {
            utilSigo.toastWarning("Aviso", "Seleccione una o más Regiones a Consultar"); return false;
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

    //Filtro: Modalidad
    _reporte.frm.find("#chkModalidadAll").change(function () {
        for (var i = 1; i <= _reporte.frm.find("[id*=lstChkModalidad]").length; i++) {
            if (i % 2 == 0)
                _reporte.frm.find("[id*=lstChkModalidad]")[i - 1].checked = $(this).is(":checked");
        }
        _reporte.filterModalidadGetAllCheck();
        _reporte.filter_lstChkModalidadId_change();
    });
    _reporte.frm.find("[id*=lstChkModalidad]").change(function () {
        _reporte.filterModalidadGetAllCheck();
        _reporte.filter_lstChkModalidadId_change();

        if (!$(this).is(":checked")) _reporte.frm.find("#chkModalidadAll").prop("checked", "");
    });
    //Filtro: Región
    _reporte.frm.find("#chkRegionAll").change(function () {
        for (var i = 1; i <= _reporte.frm.find("[id*=lstChkRegion]").length; i++) {
            if (i % 2 == 0)
                _reporte.frm.find("[id*=lstChkRegion]")[i - 1].checked = $(this).is(":checked");
        }
        _reporte.filterRegionGetAllCheck();
        _reporte.filter_lstChkRegionId_change();
    });
    _reporte.frm.find("[id*=lstChkRegion]").change(function () {
        _reporte.filterRegionGetAllCheck();
        _reporte.filter_lstChkRegionId_change();

        if (!$(this).is(":checked")) _reporte.frm.find("#chkRegionAll").prop("checked", "");
    });
}

_reporte.fnInitFiltro = function () {
    _reporte.filterEvent();
}
/******************Fin Filtros*******************/

/*REPORTE 12 - Reporte de Archivo*/
_reporte.rpt12InitDataTable = function () {
    var columns_label = [], columns_data = [], columns_event = [], options = {};

    //Tabla Resumen
    columns_label = ["Año del Informe", "Archivos Preliminares", "PAU Archivados en Primera Instancia", "PAU Archivados en Segunda Instancia", "Total"];
    columns_event = ["", "fn(c3)", "fn(c4)", "fn(c5)", "fn(c6)"];
    columns_data = ["ANIO", "NARCHIVO_INFORME", "NARCHIVO_PRIMERA", "NARCHIVO_SEGUNDA", "TOTAL"];
    options = {
        button_copy: true, button_csv: true, button_excel: true, button_pdf: true, button_print: true
        , export_title: $("#tbArchivadosAnual_Resumen").find("thead tr")[0].innerText.trim(), row_index: true
    };
    _reporte.dtArchivadosAnual_Resumen = utilDt.fnLoadDataTable_EventColumn($("#tbArchivadosAnual_Resumen"), columns_label, columns_data, columns_event, options);

    //Tabla Detalle1
    columns_label = ["Titular", "Título Habilitante", "Modalidad", "Región", "Provincia", "Distrito", "Número Informe", "Tipo Informe", "Motivo Archivo"];
    columns_data = ["TITULAR", "THABILITANTE", "MODALIDAD", "DEPARTAMENTO", "PROVINCIA", "DISTRITO", "Numero_Inform", "Tipo_Informe", "MOTIVO"];
    options = {
        button_copy: true, button_csv: true, button_excel: true, button_pdf: true, button_print: true
        , export_title: $("#tbArchivadosAnual_Detalle1").find("thead tr")[0].innerText.trim(), page_length: 20
        , row_index: true, page_sort: true
    };
    _reporte.dtArchivadosAnual_Detalle1 = utilDt.fnLoadDataTable_Detail($("#tbArchivadosAnual_Detalle1"), columns_label, columns_data, options);

    //Tabla Detalle2
    columns_label = ["Titular", "Título Habilitante", "Modalidad", "Región", "Provincia", "Distrito", "Número Expediente", "Resolución de Término", "Motivo Archivo"];
    columns_data = ["TITULAR", "THABILITANTE", "MODALIDAD", "DEPARTAMENTO", "PROVINCIA", "DISTRITO", "NUMERO_EXPEDIENTE", "NUMERO_RD", "MOTIVO"];
    options = {
        button_copy: true, button_csv: true, button_excel: true, button_pdf: true, button_print: true
        , export_title: $("#tbArchivadosAnual_Detalle2").find("thead tr")[0].innerText.trim(), page_length: 20
        , row_index: true, page_sort: true
    };
    _reporte.dtArchivadosAnual_Detalle2 = utilDt.fnLoadDataTable_Detail($("#tbArchivadosAnual_Detalle2"), columns_label, columns_data, options);

    //Tabla Detalle3
    columns_label = ["Titular", "Título Habilitante", "Modalidad", "Región", "Provincia", "Distrito", "Número Expediente", "Resolución de Término", "Resolución TFFS", "Motivo Archivo"];
    columns_data = ["TITULAR", "THABILITANTE", "MODALIDAD", "DEPARTAMENTO", "PROVINCIA", "DISTRITO", "NUMERO_EXPEDIENTE", "NUMERO_RD", "RTFFS", "MOTIVO"];
    options = {
        button_copy: true, button_csv: true, button_excel: true, button_pdf: true, button_print: true
        , export_title: $("#tbArchivadosAnual_Detalle3").find("thead tr")[0].innerText.trim(), page_length: 20
        , row_index: true, page_sort: true
    };
    _reporte.dtArchivadosAnual_Detalle3 = utilDt.fnLoadDataTable_Detail($("#tbArchivadosAnual_Detalle3"), columns_label, columns_data, options);

    //Tabla Detalle4
    columns_label = ["Titular", "Título Habilitante", "Modalidad", "Región", "Provincia", "Distrito", "Motivo Archivo", "Tipo Archivado"];
    columns_data = ["TITULAR", "THABILITANTE", "MODALIDAD", "DEPARTAMENTO", "PROVINCIA", "DISTRITO", "MOTIVO", "TIPO_ARCHIVADO"];
    options = {
        button_copy: true, button_csv: true, button_excel: true, button_pdf: true, button_print: true
        , export_title: $("#tbArchivadosAnual_Detalle4").find("thead tr")[0].innerText.trim(), page_length: 20
        , row_index: true, page_sort: true
    };
    _reporte.dtArchivadosAnual_Detalle4 = utilDt.fnLoadDataTable_Detail($("#tbArchivadosAnual_Detalle4"), columns_label, columns_data, options);
}

_reporte.fnInitArchivados = function () {
    var chartArchivadosAnual_Resumen = null;

    //Activar Filtros
    _reporte.frm.find("#dvFiltroModalidad").show();
    _reporte.frm.find("#dvFiltroRegion").show();
    $("#dvArchivadosAnual").show();

    _reporte.rpt12InitDataTable();

    //Se activan todos los checks
    _reporte.frm.find("#chkModalidadAll").prop("checked", true);
    for (var i = 1; i <= _reporte.frm.find("[id*=lstChkModalidad]").length; i++) {
        if (i % 2 == 0)
            _reporte.frm.find("[id*=lstChkModalidad]")[i - 1].checked = true;
    }
    _reporte.filterModalidadGetAllCheck();

    _reporte.frm.find("#chkRegionAll").prop("checked",true);
    for (var i = 1; i <= _reporte.frm.find("[id*=lstChkRegion]").length; i++) {
        if (i % 2 == 0)
            _reporte.frm.find("[id*=lstChkRegion]")[i - 1].checked = true;
    }
    _reporte.filterRegionGetAllCheck();

    //Implementar eventos a ejecutar despúes de realizar una acción
    var fnLimpiarReporte = function () {
        _reporte.dtArchivadosAnual_Resumen.clear().draw();
        _reporte.dtArchivadosAnual_Detalle1.clear().draw();
        _reporte.dtArchivadosAnual_Detalle2.clear().draw();
        _reporte.dtArchivadosAnual_Detalle3.clear().draw();
        _reporte.dtArchivadosAnual_Detalle4.clear().draw();
        var tb = $("#tbArchivadosAnual_Resumen");
        tb.find("#col3").text(0); tb.find("#col4").text(0); tb.find("#col5").text(0); tb.find("#col6").text(0);

        if (chartArchivadosAnual_Resumen != null) {
            chartArchivadosAnual_Resumen.clear();
            $("#cnvArchivadosAnual_Resumen").hide();
        }
    }

    _reporte.filter_lstChkAnioId_change = function () {
        fnLimpiarReporte();
    }

    _reporte.fnSubmitForm = function () {
        _reporte.dtArchivadosAnual_Resumen.clear().draw();
        _reporte.dtArchivadosAnual_Detalle1.clear().draw();
        _reporte.dtArchivadosAnual_Detalle2.clear().draw();
        _reporte.dtArchivadosAnual_Detalle3.clear().draw();
        _reporte.dtArchivadosAnual_Detalle4.clear().draw();
        $("#dvArchivadosAnual_Detalle1").hide();
        $("#dvArchivadosAnual_Detalle2").hide();
        $("#dvArchivadosAnual_Detalle3").hide();
        $("#dvArchivadosAnual_Detalle4").hide();
        if (_reporte.filterValidate()) {
            var datosReporte = _reporte.frm.serializeObject();
            var option = { url: _reporte.frm.attr("action"), datos: JSON.stringify(datosReporte), type: 'POST' };

            utilSigo.fnAjax(option, function (data) {
                if (data.success) {
                    _reporte.dtArchivadosAnual_Resumen.rows.add(data.data).draw();

                    var c3 = 0, c4 = 0, c5 = 0, c6 = 0;
                    for (var i = 0; i < data.data.length; i++) {
                        c3 += parseInt(data.data[i]["NARCHIVO_INFORME"]); c4 += parseInt(data.data[i]["NARCHIVO_PRIMERA"]);
                        c5 += parseInt(data.data[i]["NARCHIVO_SEGUNDA"]); c6 += parseInt(data.data[i]["TOTAL"]);
                    }

                    var tb = $("#tbArchivadosAnual_Resumen");
                    tb.find("#col3").text(c3); tb.find("#col4").text(c4); tb.find("#col5").text(c5); tb.find("#col6").text(c6);

                    $("#cnvArchivadosAnual_Resumen").show();
                    chartArchivadosAnual_Resumen = customChart.LoadBarraSimple_DataTable(_reporte.dtArchivadosAnual_Resumen, "ANIO", { colIndex: [2, 3, 4, 5], data: ["NARCHIVO_INFORME", "NARCHIVO_PRIMERA", "NARCHIVO_SEGUNDA", "TOTAL"], color: ["green", "blue", "red", "yellow"] }, { title: "", canvas: "cnvArchivadosAnual_Resumen" });
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

        var anio = "";

        if (obj != "") {
            anio = _reporte.dtArchivadosAnual_Resumen.row($(obj).parents('tr')).data()["ANIO"];
            $("#txtanio").val(anio);

            switch (col) {
                case 3:
                    $("label[for='lblSubTituloArchivados1']").text("Listado de Archivos Preliminares en el año [" + anio + "]");
                    $("#hdfTipoArchivados").val("NARCHIVO_INFORME");
                    break;
                case 4:
                    $("label[for='lblSubTituloArchivados2']").text("Listado de PAU Archivados en Primera Instancia en el año [" + anio + "]");
                    $("#hdfTipoArchivados").val("NARCHIVO_PRIMERA");
                    break;
                case 5:
                    $("label[for='lblSubTituloArchivados3']").text("Listado de PAU Archivados en Segunda Instancia en el año [" + anio + "]");
                    $("#hdfTipoArchivados").val("NARCHIVO_SEGUNDA");
                    break;
                case 6:
                    $("label[for='lblSubTituloArchivados4']").text("Listado de Archivados en el año [" + anio + "]");
                    $("#hdfTipoArchivados").val("");
                    break;
            }
        }

        if (_reporte.filterValidate()) {
            _reporte.dtArchivadosAnual_Detalle1.clear().draw();
            _reporte.dtArchivadosAnual_Detalle2.clear().draw();
            _reporte.dtArchivadosAnual_Detalle3.clear().draw();
            _reporte.dtArchivadosAnual_Detalle4.clear().draw();
            $("#dvArchivadosAnual_Detalle1").hide();
            $("#dvArchivadosAnual_Detalle2").hide();
            $("#dvArchivadosAnual_Detalle3").hide();
            $("#dvArchivadosAnual_Detalle4").hide();

            var params = {
                hdfTipoReporte: "ARCHIVADOS_DETALLE",
                lstChkModalidadId: _reporte.frm.find("#lstChkModalidadId").val(),
                lstChkRegionId: _reporte.frm.find("#lstChkRegionId").val(),
                txtanio: $("#txtanio").val(),
                hdfTipoArchivados: $("#hdfTipoArchivados").val()
            };

            var option = { url: urlLocalSigo + "Fiscalizacion/ReporteFiscalizacion/DetalleReporte", datos: JSON.stringify(params), type: 'POST' };
            utilSigo.fnAjax(option, function (data) {
                if (data.success) {
                    if ($("#hdfTipoArchivados").val() == "NARCHIVO_INFORME") {
                        _reporte.dtArchivadosAnual_Detalle1.rows.add(data.data).draw();
                        $("#dvArchivadosAnual_Detalle1").show();
                    }
                    else if ($("#hdfTipoArchivados").val() == "NARCHIVO_PRIMERA") {
                        _reporte.dtArchivadosAnual_Detalle2.rows.add(data.data).draw();
                        $("#dvArchivadosAnual_Detalle2").show();
                    }
                    else if ($("#hdfTipoArchivados").val() == "NARCHIVO_SEGUNDA") {
                        _reporte.dtArchivadosAnual_Detalle3.rows.add(data.data).draw();
                        $("#dvArchivadosAnual_Detalle3").show();
                    }
                    else {
                        _reporte.dtArchivadosAnual_Detalle4.rows.add(data.data).draw();
                        $("#dvArchivadosAnual_Detalle4").show();
                    }                
                }
                else {
                    utilSigo.toastWarning("Aviso", "Sucedio un error, Comuníquese con el Administrador");
                    console.log(data.msj);
                }
            });
        }

        return false;
    }
}
/******************Fin Reporte 12*****************/

$(document).ready(function () {
    _reporte.contenedor = "frmReporteFiscalizacion";
    _reporte.frm = $("#" + _reporte.contenedor);

    _reporte.fnInitFiltro();

    switch (_reporte.frm.find("#hdfTipoReporte").val()) {
        case "ARCHIVADOS":
            _reporte.fnInitArchivados();
            break;
    }
});