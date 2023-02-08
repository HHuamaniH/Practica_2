"use strict";
var _renderPEI = {};
_renderPEI.meta = 0;
_renderPEI.chartPEI1Semestral_Resumen = null;
_renderPEI.chartPEI2Semestral_Resumen = null;
_renderPEI.chartPEI3Semestral_Resumen = null;
_renderPEI.chartPEI4Semestral_Resumen = null;

_renderPEI.filterValidate = function () {
    if (_renderPEI.frm.find("#ddlIndicadorPEIId").val() == "0000000") {
        utilSigo.toastWarning("Aviso", "Seleccione Indicador"); return false;
    }

    if (_renderPEI.frm.find("#ddlAnioPEIId").val() == "0000") {
        utilSigo.toastWarning("Aviso", "Seleccione Año"); return false;
    }

    return true;
}

_renderPEI.fnFiltrarAnio = function (_codIndicador) {
    var url = urlLocalSigo + "Supervision/Indicadores/FiltrarAnio";
    var params = { ddlIndicadorMAPROId: _codIndicador, tipo: "YEAR", idTab: Indicador.frm.find("#idTab").val()};
    var option = { url: url, type: 'POST', datos: JSON.stringify(params) };

    utilSigo.fnAjax(option, function (data) {
        if (data.success) {
            var anio = _renderPEI.frm.find("#ddlAnioPEIId");
            anio.empty();
            $.each(data.result, function (index, item) {
                var p = new Option(item.Text, item.Value);
                anio.append(p);
            });
        }
        else {
            utilSigo.toastWarning("Aviso", "Sucedio un error, Comuníquese con el Administrador");
            console.log(data.msj);
        }
    });
}

/*Filtros*/
_renderPEI.fnInitFiltro = function () {
    //Mostrar y ocultar filtros
    $("#dvHideFiltroPEI").click(function () {
        $("#dvHideFiltroPEI").hide();
        $("#dvShowFiltroPEI").show();
        $("#dvFiltroPEI").hide();
    });
    $("#dvShowFiltroPEI").click(function () {
        $("#dvHideFiltroPEI").show();
        $("#dvShowFiltroPEI").hide();
        $("#dvFiltroPEI").show();
    });

    //Filtro: Indicador
    _renderPEI.frm.find("#ddlIndicadorPEIId").change(function () {
        _renderPEI.fnFiltrarAnio(this.value);

        switch (this.value) {
            case "0000016":
                $("#dvResultadoPEI1").show();
                $("#dvResultadoPEI2").hide();
                $("#dvResultadoPEI3").hide();
                $("#dvResultadoPEI4").hide();
                _renderPEI.fnLimpiarRpt1();
                break;
            case "0000017":
                $("#dvResultadoPEI1").hide();
                $("#dvResultadoPEI2").show();
                $("#dvResultadoPEI3").hide();
                $("#dvResultadoPEI4").hide();
                _renderPEI.fnLimpiarRpt2();
                break;
            case "0000019":
                $("#dvResultadoPEI1").hide();
                $("#dvResultadoPEI2").hide();
                $("#dvResultadoPEI3").show();
                $("#dvResultadoPEI4").hide();
                _renderPEI.fnLimpiarRpt3();
                break;
            case "0000020":
                $("#dvResultadoPEI1").hide();
                $("#dvResultadoPEI2").hide();
                $("#dvResultadoPEI3").hide();
                $("#dvResultadoPEI4").show();
                _renderPEI.fnLimpiarRpt4();
                break;
        }
    });

    //Filtro: Año
    _renderPEI.frm.find("#ddlAnioPEIId").change(function () {
        _renderPEI.fnLimpiarDatos();
    });
}
/******************Fin Filtros*******************/

_renderPEI.fnLimpiarDatos = function () {
    var indicador = _renderPEI.frm.find("#ddlIndicadorPEIId").val();

    switch (indicador) {
        case "0000016":
            _renderPEI.fnLimpiarRpt1();
            break;
        case "0000017":
            _renderPEI.fnLimpiarRpt2();
            break;
        case "0000019":
            _renderPEI.fnLimpiarRpt3();
            break;
        case "0000020":
            _renderPEI.fnLimpiarRpt4();
            break;
    }
}

_renderPEI.fnSubmitForm = function () {
    _renderPEI.fnLimpiarDatos();

    if (_renderPEI.filterValidate()) {
        var datosReporte = _renderPEI.frm.serializeObject();
        datosReporte.idTab = Indicador.frm.find("#idTab").val();
        datosReporte.tipo = "CUADRO";
        var option = { url: _renderPEI.frm.attr("action"), datos: JSON.stringify(datosReporte), type: 'POST' };

        utilSigo.fnAjax(option, function (data) {
            if (data.success) {
                var indicador = _renderPEI.frm.find("#ddlIndicadorPEIId").val();
                var c3 = 0, c4 = 0, c5 = 0;
                var data_meta, tb, i;
   
                switch (indicador) {
                    case "0000016":
                        for (i = 0; i < data.data.length; i++) {
                            data.data[i]["PORCENTAJE"] = data.data[i]["PORCENTAJE"].replace(",", ".");
                            c3 += parseInt(data.data[i]["TOTAL"]); c4 += parseInt(data.data[i]["PARTE"]);
                        }
                        c5 = (c4 / c3) * 100;
                        _renderPEI.dtPEI1Semestral_Resumen.rows.add(data.data).draw();

                        tb = $("#tbPEI1Semestral_Resumen");
                        tb.find("#col3").text(c3); tb.find("#col4").text(c4); tb.find("#col5").text(_renderPEI.intlRound(c5, 2));

                        _renderPEI.chartPEI1Semestral_Resumen = customChart.LoadBarraSimple_DataTable(
                            _renderPEI.dtPEI1Semestral_Resumen,
                            "DESCRIPCION",
                            { colIndex: [4], data: ["PORCENTAJE"], color: ["green"] },
                            { title: "PORCENTAJE DE PLANES DE MANEJO CON BUEN DESEMPEÑO", canvas: "cnvPEI1Semestral_Resumen" },
                        );
                        break;

                    case "0000017":
                        data_meta = [];
                        _renderPEI.meta = data.obj.NU_META;

                        for (i = 0; i < data.data.length; i++) {
                            data.data[i]["PORCENTAJE"] = data.data[i]["PORCENTAJE"].replace(",", ".");
                            c3 += parseInt(data.data[i]["TOTAL"]); c4 += parseInt(data.data[i]["PARTE"]);

                            data_meta.push(_renderPEI.meta);
                        }
                        c5 = (c4 / c3) * 100;
                        _renderPEI.dtPEI2Semestral_Resumen.rows.add(data.data).draw();

                        tb = $("#tbPEI2Semestral_Resumen");
                        tb.find("#col3").text(c3); tb.find("#col4").text(c4); tb.find("#col5").text(_renderPEI.intlRound(c5, 2));

                        if (_renderPEI.meta > 0) {
                            _renderPEI.chartPEI2Semestral_Resumen = customChart.LoadBarraMixedMeta_DataTable(
                                _renderPEI.dtPEI2Semestral_Resumen,
                                "DESCRIPCION",
                                { colIndex: [4], data: ["PORCENTAJE"], color: ["green"] },
                                { title: "PORCENTAJE DE PLANES DE MANEJO SUPERVISADOS", canvas: "cnvPEI2Semestral_Resumen" },
                                { data: data_meta, color: "red", title: "Meta (" + _renderPEI.meta + "%)" }
                            );
                        }
                        else {
                            _renderPEI.chartPEI2Semestral_Resumen = customChart.LoadBarraSimple_DataTable(
                                _renderPEI.dtPEI2Semestral_Resumen,
                                "DESCRIPCION",
                                { colIndex: [4], data: ["PORCENTAJE"], color: ["green"] },
                                { title: "PORCENTAJE DE PLANES DE MANEJO SUPERVISADOS", canvas: "cnvPEI2Semestral_Resumen" }
                            );
                        }
                        break;

                    case "0000019":
                        data_meta = [];
                        _renderPEI.meta = data.obj.NU_META;

                        for (i = 0; i < data.data.length; i++) {
                            data.data[i]["PORCENTAJE"] = data.data[i]["PORCENTAJE"].replace(",", ".");
                            c3 += parseInt(data.data[i]["TOTAL"]); c4 += parseInt(data.data[i]["PARTE"]);

                            data_meta.push(_renderPEI.meta);
                        }
                        c5 = (c4 / c3) * 100;
                        _renderPEI.dtPEI3Semestral_Resumen.rows.add(data.data).draw();

                        tb = $("#tbPEI3Semestral_Resumen");
                        tb.find("#col3").text(c3); tb.find("#col4").text(c4); tb.find("#col5").text(_renderPEI.intlRound(c5, 2));

                        if (_renderPEI.meta > 0) {
                            _renderPEI.chartPEI3Semestral_Resumen = customChart.LoadBarraMixedMeta_DataTable(
                                _renderPEI.dtPEI3Semestral_Resumen,
                                "DESCRIPCION",
                                { colIndex: [4], data: ["PORCENTAJE"], color: ["green"] },
                                { title: "PORCENTAJE DE AUDITORÍAS QUINQUENALES CON RESULTADOS FAVORABLES", canvas: "cnvPEI3Semestral_Resumen" },
                                { data: data_meta, color: "red", title: "Meta (" + _renderPEI.meta + "%)" }
                            );
                        }
                        else {
                            _renderPEI.chartPEI3Semestral_Resumen = customChart.LoadBarraSimple_DataTable(
                                _renderPEI.dtPEI3Semestral_Resumen,
                                "DESCRIPCION",
                                { colIndex: [4], data: ["PORCENTAJE"], color: ["green"] },
                                { title: "PORCENTAJE DE AUDITORÍAS QUINQUENALES CON RESULTADOS FAVORABLES", canvas: "cnvPEI3Semestral_Resumen" }
                            );
                        }
                        break;

                    case "0000020":
                        for (i = 0; i < data.data.length; i++) {
                            data.data[i]["PORCENTAJE"] = data.data[i]["PORCENTAJE"].replace(",", ".");
                            c3 += parseInt(data.data[i]["TOTAL"]); c4 += parseInt(data.data[i]["PARTE"]);
                        }
                        c5 = (c4 / c3) * 100;
                        _renderPEI.dtPEI4Semestral_Resumen.rows.add(data.data).draw();

                        tb = $("#tbPEI4Semestral_Resumen");
                        tb.find("#col3").text(c3); tb.find("#col4").text(c4); tb.find("#col5").text(_renderPEI.intlRound(c5, 2));

                        _renderPEI.chartPEI4Semestral_Resumen = customChart.LoadBarraSimple_DataTable(
                            _renderPEI.dtPEI4Semestral_Resumen,
                            "DESCRIPCION",
                            { colIndex: [4], data: ["PORCENTAJE"], color: ["green"] },
                            { title: "PORCENTAJE DE MEDIDAS CORRECTIVAS IMPLEMENTADAS", canvas: "cnvPEI4Semestral_Resumen" },
                        );
                        break;
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

_renderPEI.intlRound = function (numero, decimales, usarComa = false) {
    var opciones = {
        maximumFractionDigits: decimales,
        useGrouping: false
    };
    usarComa = usarComa ? "es" : "en";
    return new Intl.NumberFormat(usarComa, opciones).format(numero);
}

utilDt.fnEventColumn = function (obj, col) {
    switch (Indicador.frm.find("#idTab").val()) {
        case "0":
            _renderMAPRO.fnEventColumn(obj, col);
            break;
        case "1":
            _renderPOI.fnEventColumn(obj, col);
            break;
        case "2":
            _renderPEI.fnEventColumn(obj, col);
            break;
    }
}

_renderPEI.fnEventColumn = function (obj, col) {
    var indicador = _renderPEI.frm.find("#ddlIndicadorPEIId").val();
    var numMes = "";

    if (obj != "") {
        switch (indicador) {
            case "0000016":
                numMes = _renderPEI.dtPEI1Semestral_Resumen.row($(obj).parents('tr')).data()["NRO_TRIMESTRE"];
                break;
            case "0000017":
                numMes = _renderPEI.dtPEI2Semestral_Resumen.row($(obj).parents('tr')).data()["NRO_TRIMESTRE"];
                break;
            case "0000019":
                numMes = _renderPEI.dtPEI3Semestral_Resumen.row($(obj).parents('tr')).data()["NRO_TRIMESTRE"];
                break;
            case "0000020":
                numMes = _renderPEI.dtPEI4Semestral_Resumen.row($(obj).parents('tr')).data()["NRO_TRIMESTRE"];
                break;
        }
    }

    if (_renderPEI.filterValidate()) {
        switch (indicador) {
            case "0000016":
                _renderPEI.dtPEI1Semestral_Detalle.clear().draw();
                break;
            case "0000017":
                _renderPEI.dtPEI2Semestral_Detalle.clear().draw();
                break;
            case "0000019":
                _renderPEI.dtPEI3Semestral_Detalle.clear().draw();
                break;
            case "0000020":
                _renderPEI.dtPEI4Semestral_Detalle.clear().draw();
                break;
        }

        var datosReporte = _renderPEI.frm.serializeObject();
        datosReporte.idTab = Indicador.frm.find("#idTab").val();
        datosReporte.tipo = "LISTA";
        datosReporte.numero = numMes;

        var option = { url: _renderPEI.frm.attr("action"), datos: JSON.stringify(datosReporte), type: 'POST' };
        utilSigo.fnAjax(option, function (data) {
            if (data.success) {
                switch (indicador) {
                    case "0000016":
                        _renderPEI.dtPEI1Semestral_Detalle.rows.add(data.data).draw();
                        break;
                    case "0000017":
                        for (var i = 0; i < data.data.length; i++) {
                            data.data[i]["INICIO_VIGENCIA"] = data.data[i]["INICIO_VIGENCIA"] + " - " + data.data[i]["FIN_VIGENCIA"];
                        }

                        _renderPEI.dtPEI2Semestral_Detalle.rows.add(data.data).draw();
                        break;
                    case "0000019":
                        _renderPEI.dtPEI3Semestral_Detalle.rows.add(data.data).draw();
                        break;
                    case "0000020":
                        _renderPEI.dtPEI4Semestral_Detalle.rows.add(data.data).draw();
                        break;
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

/*Reporte 1: RF-024 PORCENTAJE DE PLANES DE MANEJO CON BUEN DESEMPEÑO*/
_renderPEI.fnInitDatosRpt1 = function () {
    var columns_label = [], columns_data = [], columns_event = [], options = {};

    columns_label = ["Semestre", "Número de Planes de manejo supervisados", "Número Planes de manejo con buen desempeño", "Indicador (%)"];
    columns_event = ["fn(c2)", "", "", ""];
    columns_data = ["DESCRIPCION", "TOTAL", "PARTE", "PORCENTAJE"];
    options = {
        button_excel: true, export_title: $("#tbPEI1Semestral_Resumen").find("thead tr")[0].innerText.trim(), row_index: true
    };
    _renderPEI.dtPEI1Semestral_Resumen = utilDt.fnLoadDataTable_EventColumn($("#tbPEI1Semestral_Resumen"), columns_label, columns_data, columns_event, options);

    columns_label = ["Año de Informe", "Sub Dirección de Línea", "Modalidad de Aprovechamiento", "Título Habilitante", "Titular Actual"
        , "Informe", "Tipo de Informe", "Area Supervisada", "Fecha Informe", "Fecha Término Supervisión", "Planes de Manejo Supervisados"
        , "Buen Desempeño"];
    columns_data = ["ANIO_INFORME", "DLINEA", "MODALIDAD", "TITULO", "TITULAR", "INFORME", "TIPO_INFORME", "AREA_SUPERVISADA"
        , "FECHA_INFORME", "FECHA_SUPERVISION_FIN", "NOMBRE_POA", "BUEN_DESEMPENIO"];
    options = {
        button_excel: true, export_title: $("#tbPEI1Semestral_Detalle").find("thead tr")[0].innerText.trim(), page_length: 20,
        row_index: true, page_sort: true, page_info: true
    };
    _renderPEI.dtPEI1Semestral_Detalle = utilDt.fnLoadDataTable_Detail($("#tbPEI1Semestral_Detalle"), columns_label, columns_data, options);
}

_renderPEI.fnLimpiarRpt1 = function () {
    _renderPEI.dtPEI1Semestral_Resumen.clear().draw();
    _renderPEI.dtPEI1Semestral_Detalle.clear().draw();

    var tb = $("#tbPEI1Semestral_Resumen");
    tb.find("#col3").text(0); tb.find("#col4").text(0); tb.find("#col5").text(0);

    if (_renderPEI.chartPEI1Semestral_Resumen != null) {
        _renderPEI.chartPEI1Semestral_Resumen.destroy();
    }
}
/******************Fin Reporte 1*******************/

/*Reporte 2: RF-025 PORCENTAJE DE PLANES DE MANEJO SUPERVISADOS*/
_renderPEI.fnInitDatosRpt2 = function () {
    var columns_label = [], columns_data = [], columns_event = [], options = {};

    columns_label = ["Semestre", "Número de Planes de manejo supervisables (PEI)", "Número Planes de manejo supervisados", "Indicador (%)"];
    columns_event = ["fn(c2)", "", "", ""];
    columns_data = ["DESCRIPCION", "TOTAL", "PARTE", "PORCENTAJE"];
    options = {
        button_excel: true, export_title: $("#tbPEI2Semestral_Resumen").find("thead tr")[0].innerText.trim(), row_index: true
    };
    _renderPEI.dtPEI2Semestral_Resumen = utilDt.fnLoadDataTable_EventColumn($("#tbPEI2Semestral_Resumen"), columns_label, columns_data, columns_event, options);

    columns_label = ["Mes", "Nro. Plan de Manejo", "Fecha de Inicio y término de vigencia", "Fecha de Registro de Sigo"
        , "Titular", "TÍtulo", "Modalidad", "Con control de Calidad Conforme", "Estado del documento", "Fecha registro control de calidad"
        , "Tipo de plan de manejo"];
    columns_data = ["MES", "NOMBRE_POA", "INICIO_VIGENCIA", "FECHA_SIGO", "TITULAR", "TITULO", "MODALIDAD"
        , "CONTROL_CALIDAD", "ESTADO_DOC", "FECHA_CCA", "TIPO_PLAN"];
    options = {
        button_excel: true, export_title: $("#tbPEI2Semestral_Detalle").find("thead tr")[0].innerText.trim(), page_length: 20,
        row_index: true, page_sort: true, page_info: true
    };
    _renderPEI.dtPEI2Semestral_Detalle = utilDt.fnLoadDataTable_Detail($("#tbPEI2Semestral_Detalle"), columns_label, columns_data, options);
}

_renderPEI.fnLimpiarRpt2 = function () {
    _renderPEI.dtPEI2Semestral_Resumen.clear().draw();
    _renderPEI.dtPEI2Semestral_Detalle.clear().draw();

    var tb = $("#tbPEI2Semestral_Resumen");
    tb.find("#col3").text(0); tb.find("#col4").text(0); tb.find("#col5").text(0);

    if (_renderPEI.chartPEI2Semestral_Resumen != null) {
        _renderPEI.chartPEI2Semestral_Resumen.destroy();
    }
}
/******************Fin Reporte 2*******************/

/*Reporte 3: RF-027 PORCENTAJE DE AUDITORÍAS QUINQUENALES CON RESULTADOS FAVORABLES*/
_renderPEI.fnInitDatosRpt3 = function () {
    var columns_label = [], columns_data = [], columns_event = [], options = {};

    columns_label = ["Semestre", "Número de auditorías quinquenales programadas en el PEI", "Número de auditorías quinquenales con resultados favorables", "Indicador (%)"];
    columns_event = ["fn(c2)", "", "", ""];
    columns_data = ["DESCRIPCION", "TOTAL", "PARTE", "PORCENTAJE"];
    options = {
        button_excel: true, export_title: $("#tbPEI3Semestral_Resumen").find("thead tr")[0].innerText.trim(), row_index: true
    };
    _renderPEI.dtPEI3Semestral_Resumen = utilDt.fnLoadDataTable_EventColumn($("#tbPEI3Semestral_Resumen"), columns_label, columns_data, columns_event, options);

    columns_label = ["Año de Informe", "Mes de Auditoria", "Sub Dirección de Línea", "Oficina Desconcentrada", "Modalidad de Aprovechamiento"
        , "Ubigeo del TH: Departamento", "Ubigeo del TH: Provincia", "Ubigeo del TH: Distrito", "Título Habilitante", "Titular Actual"
        , "N° de Informe de auditoría", "Área supervisada en el PM", "Estado del Control de calidad", "Fecha Informe", "Fecha Emisión Inf. Auditoria"
        , "Observatorio OSINFOR", "Quinquenio 1 - Pasa Auditoria", "Quinquenio 2 - Pasa Auditoria", "Quinquenio 3 - Pasa Auditoria"
        , "Quinquenio 4 - Pasa Auditoria", "Quinquenio 5 - Pasa Auditoria", "Quinquenio 6 - Pasa Auditoria", "Quinquenio 7 - Pasa Auditoria"
        , "Quinquenio 8 - Pasa Auditoria"];
    columns_data = ["ANIO", "MES", "DLINEA", "OFI_DESCONCENTRADA", "MODALIDAD", "DEPARTAMENTO_TH", "PROVINCIA_TH", "DISTRITO_TH", "THABILITANTE"
        , "APELLIDOS_NOMBRES", "INFORME", "AREA_SUPERVISADA", "ESTADO_CONTROL_CALIDAD", "FECHA_INICIO_AUDITORIA", "FECHA_REFERENCIA"
        , "OBSERVATORIO_OSINFOR", "A1", "A2", "A3", "A4", "A5", "A6", "A7", "A8"];
    options = {
        button_excel: true, export_title: $("#tbPEI3Semestral_Detalle").find("thead tr")[0].innerText.trim(), page_length: 20,
        row_index: true, page_sort: true, page_info: true
    };
    _renderPEI.dtPEI3Semestral_Detalle = utilDt.fnLoadDataTable_Detail($("#tbPEI3Semestral_Detalle"), columns_label, columns_data, options);
}

_renderPEI.fnLimpiarRpt3 = function () {
    _renderPEI.dtPEI3Semestral_Resumen.clear().draw();
    _renderPEI.dtPEI3Semestral_Detalle.clear().draw();

    var tb = $("#tbPEI3Semestral_Resumen");
    tb.find("#col3").text(0); tb.find("#col4").text(0); tb.find("#col5").text(0);

    if (_renderPEI.chartPEI3Semestral_Resumen != null) {
        _renderPEI.chartPEI3Semestral_Resumen.destroy();
    }
}

/*Reporte 4: RF-028 PORCENTAJE DE MEDIDAS CORRECTIVAS IMPLEMENTADAS*/
_renderPEI.fnInitDatosRpt4 = function () {
    var columns_label = [], columns_data = [], columns_event = [], options = {};

    columns_label = ["Semestre", "Numero de medidas correctivas programadas", "Número de medidas implementadas en el año", "Indicador (%)"];
    columns_event = ["fn(c2)", "", "", ""];
    columns_data = ["DESCRIPCION", "TOTAL", "PARTE", "PORCENTAJE"];
    options = {
        button_excel: true, export_title: $("#tbPEI4Semestral_Resumen").find("thead tr")[0].innerText.trim(), row_index: true
    };
    _renderPEI.dtPEI4Semestral_Resumen = utilDt.fnLoadDataTable_EventColumn($("#tbPEI4Semestral_Resumen"), columns_label, columns_data, columns_event, options);

    columns_label = ["Fecha Registro", "Año Registro", "Mes Registro", "Informe Técnico", "Tipo de Informe"
        , "Título Habilitante", "Titular", "Modalidad", "Expediente", "Usuario"];
    columns_data = ["FECHA_REGISTRO", "ANIO", "MES", "INFORME", "ITIPO", "THABILITANTE", "TITULAR", "MODALIDAD", "NUM_EXPEDIENTE"
        , "USUARIO"];
    options = {
        button_excel: true, export_title: $("#tbPEI4Semestral_Detalle").find("thead tr")[0].innerText.trim(), page_length: 20,
        row_index: true, page_sort: true, page_info: true
    };
    _renderPEI.dtPEI4Semestral_Detalle = utilDt.fnLoadDataTable_Detail($("#tbPEI4Semestral_Detalle"), columns_label, columns_data, options);
}

_renderPEI.fnLimpiarRpt4 = function () {
    _renderPEI.dtPEI4Semestral_Resumen.clear().draw();
    _renderPEI.dtPEI4Semestral_Detalle.clear().draw();

    var tb = $("#tbPEI4Semestral_Resumen");
    tb.find("#col3").text(0); tb.find("#col4").text(0); tb.find("#col5").text(0);

    if (_renderPEI.chartPEI4Semestral_Resumen != null) {
        _renderPEI.chartPEI4Semestral_Resumen.destroy();
    }
}
/******************Fin Reporte 4*******************/

$(document).ready(function () {
    _renderPEI.frm = $("#frmFiltroPEI");

    _renderPEI.fnInitFiltro();
    _renderPEI.fnInitDatosRpt1();
    _renderPEI.fnInitDatosRpt2();
    _renderPEI.fnInitDatosRpt3();
    _renderPEI.fnInitDatosRpt4();
});