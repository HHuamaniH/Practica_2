"use strict";
var _renderPOI = {};
_renderPOI.chartPOI1Mensual_Resumen = null;
_renderPOI.chartPOI2Mensual_Resumen = null;
_renderPOI.chartPOI3Mensual_Resumen = null;
_renderPOI.chartPOI4Mensual_Resumen = null;

_renderPOI.filterValidate = function () {
    if (_renderPOI.frm.find("#ddlIndicadorPOIId").val() == "0000000") {
        utilSigo.toastWarning("Aviso", "Seleccione Indicador"); return false;
    }

    if (_renderPOI.frm.find("#ddlAnioPOIId").val() == "0000") {
        utilSigo.toastWarning("Aviso", "Seleccione Año"); return false;
    }

    if (_renderPOI.frm.find("#ddlIndicadorPOIId").val() == "0000012" ||
        _renderPOI.frm.find("#ddlIndicadorPOIId").val() == "0000013") {
        if (_renderPOI.frm.find("#ddlMesPOIId").val() == "0") {
            utilSigo.toastWarning("Aviso", "Seleccione Mes"); return false;
        }
    }

    return true;
}

_renderPOI.fnFiltrarAnio = function (_codIndicador) {
    var url = urlLocalSigo + "Supervision/Indicadores/FiltrarAnio";
    var params = { ddlIndicadorMAPROId: _codIndicador, tipo: "YEAR", idTab: Indicador.frm.find("#idTab").val()};
    var option = { url: url, type: 'POST', datos: JSON.stringify(params) };

    utilSigo.fnAjax(option, function (data) {
        if (data.success) {
            var anio = _renderPOI.frm.find("#ddlAnioPOIId");
            anio.empty();
            $.each(data.result, function (index, item) {
                var p = new Option(item.Text, item.Value);
                anio.append(p);
            });
            if (_renderPOI.frm.find("#ddlAnioPOIId").val() == "0000") {
                $("#dvMes").hide();
                _renderPOI.frm.find("#ddlMesPOIId").val("0");
            }
        }
        else {
            utilSigo.toastWarning("Aviso", "Sucedio un error, Comuníquese con el Administrador");
            console.log(data.msj);
        }
    });
}

/*Filtros*/
_renderPOI.fnInitFiltro = function () {
    //Mostrar y ocultar filtros
    $("#dvHideFiltroPOI").click(function () {
        $("#dvHideFiltroPOI").hide();
        $("#dvShowFiltroPOI").show();
        $("#dvFiltroPOI").hide();
    });
    $("#dvShowFiltroPOI").click(function () {
        $("#dvHideFiltroPOI").show();
        $("#dvShowFiltroPOI").hide();
        $("#dvFiltroPOI").show();
    });

    //Filtro: Indicador
    _renderPOI.frm.find("#ddlIndicadorPOIId").change(function () {
        _renderPOI.fnFiltrarAnio(this.value);

        switch (this.value) {
            case "0000011":
                $("#dvResultadoPOI1").show();
                $("#dvResultadoPOI2").hide();
                $("#dvResultadoPOI3").hide();
                $("#dvResultadoPOI4").hide();
                _renderPOI.fnLimpiarRpt1();
                break;
            case "0000012":
                $("#dvResultadoPOI1").hide();
                $("#dvResultadoPOI2").show();
                $("#dvResultadoPOI3").hide();
                $("#dvResultadoPOI4").hide();
                _renderPOI.fnLimpiarRpt2();
                break;
            case "0000013":
                $("#dvResultadoPOI1").hide();
                $("#dvResultadoPOI2").hide();
                $("#dvResultadoPOI3").show();
                $("#dvResultadoPOI4").hide();
                _renderPOI.fnLimpiarRpt3();
                break;
            case "0000015":
                $("#dvResultadoPOI1").hide();
                $("#dvResultadoPOI2").hide();
                $("#dvResultadoPOI3").hide();
                $("#dvResultadoPOI4").show();
                _renderPOI.fnLimpiarRpt4();
                break;
        }
    });

    //Filtro: Año
    _renderPOI.frm.find("#ddlAnioPOIId").change(function () {
        var indicador = _renderPOI.frm.find("#ddlIndicadorPOIId").val();

        if (indicador == "0000012" || indicador == "0000013") {
            if (this.value != "0000") $("#dvMes").show();
            else $("#dvMes").hide();
        }
        else $("#dvMes").hide();

        _renderPOI.frm.find("#ddlMesPOIId").val("0");
        
        _renderPOI.fnLimpiarDatos(this.value);
    });
}
/******************Fin Filtros*******************/

_renderPOI.fnLimpiarDatos = function (anio) {
    var indicador = _renderPOI.frm.find("#ddlIndicadorPOIId").val();

    switch (indicador) {
        case "0000011":
            _renderPOI.fnLimpiarRpt1();
            break;
        case "0000012":
            _renderPOI.fnLimpiarRpt2();
            break;
        case "0000013":
            _renderPOI.fnLimpiarRpt3();
            break;
        case "0000015":       
            _renderPOI.fnLimpiarRpt4();
            break;
    }
}

_renderPOI.fnSubmitForm = function () {
    _renderPOI.fnLimpiarDatos();

    if (_renderPOI.filterValidate()) {
        var datosReporte = _renderPOI.frm.serializeObject();
        datosReporte.idTab = Indicador.frm.find("#idTab").val();
        datosReporte.tipo = "CUADRO";
        var option = { url: _renderPOI.frm.attr("action"), datos: JSON.stringify(datosReporte), type: 'POST' };

        utilSigo.fnAjax(option, function (data) {
            if (data.success) {
                var indicador = _renderPOI.frm.find("#ddlIndicadorPOIId").val();
                var c3 = 0, c4 = 0, c5 = 0;
                var tb, i;

                switch (indicador) {
                    case "0000011":
                        for (i = 0; i < data.data.length; i++) {
                            c3 += parseInt(data.data[i]["TOTAL"]);
                        }
                        _renderPOI.dtPOI1Mensual_Resumen.rows.add(data.data).draw();

                        tb = $("#tbPOI1Mensual_Resumen");
                        tb.find("#col3").text(c3);

                        _renderPOI.chartPOI1Mensual_Resumen = customChart.LoadBarraSimple_DataTable(
                            _renderPOI.dtPOI1Mensual_Resumen,
                            "DESCRIPCION",
                            { colIndex: [2], data: ["TOTAL"], color: ["green"] },
                            { title: "NÚMERO DE HECTÁREAS DE TH AUDITADAS", canvas: "cnvPOI1Mensual_Resumen" },
                        );
                        break;

                    case "0000012":
                        for (i = 0; i < data.data.length; i++) {
                            c4 += parseFloat(data.data[i]["AREA_OTORGADA"]);
                            c5 += parseFloat(data.data[i]["AREA_SUPERVISADA"]);
                        }
                        _renderPOI.dtPOI2Mensual_Resumen.rows.add(data.data).draw();

                        tb = $("#tbPOI2Mensual_Resumen");
                        tb.find("#col5").text(_renderPOI.intlRound(c4, 2)); tb.find("#col6").text(_renderPOI.intlRound(c5, 2));

                        /*_renderPOI.chartPOI2Mensual_Resumen = customChart.LoadBarraHorizontal_DataTable(
                            _renderPOI.dtPOI2Mensual_Resumen,
                            "MODALIDAD",
                            "NOMBRE_MES",
                            { colIndex: [3, 4], data: ["AREA_OTORGADA","AREA_SUPERVISADA"], color: ["green","blue"] },
                            { title: "NÚMERO DE HECTÁREAS DE TH SUPERVISADAS EN CAMPO, POR MODALIDAD", canvas: "cnvPOI2Mensual_Resumen" },
                        );*/
                        _renderPOI.chartPOI2Mensual_Resumen = customChart.LoadBarraSimple_DataTable(
                            _renderPOI.dtPOI2Mensual_Resumen,
                            "COD_MODALIDAD",
                            { colIndex: [4, 5], data: ["AREA_OTORGADA", "AREA_SUPERVISADA"], color: ["green", "blue"] },
                            { title: "NÚMERO DE HECTÁREAS DE TH SUPERVISADAS EN CAMPO, POR MODALIDAD", canvas: "cnvPOI2Mensual_Resumen" },
                        );
                        break;

                    case "0000013":
                        for (i = 0; i < data.data.length; i++) {
                            c4 += parseFloat(data.data[i]["AREA_OTORGADA"]);
                            c5 += parseFloat(data.data[i]["AREA_SUPERVISADA"]);
                        }
                        _renderPOI.dtPOI3Mensual_Resumen.rows.add(data.data).draw();

                        tb = $("#tbPOI3Mensual_Resumen");
                        tb.find("#col5").text(_renderPOI.intlRound(c4, 2)); tb.find("#col6").text(_renderPOI.intlRound(c5, 2));

                        /*_renderPOI.chartPOI3Mensual_Resumen = customChart.LoadBarraHorizontal_DataTable(
                            _renderPOI.dtPOI3Mensual_Resumen,
                            "MODALIDAD",
                            "NOMBRE_MES",
                            { colIndex: [3, 4], data: ["AREA_OTORGADA", "AREA_SUPERVISADA"], color: ["green", "blue"] },
                            { title: "NÚMERO DE HECTÁREAS DE TH SUPERVISADAS EN GABINETE", canvas: "cnvPOI3Mensual_Resumen" },
                        );*/
                        _renderPOI.chartPOI3Mensual_Resumen = customChart.LoadBarraSimple_DataTable(
                            _renderPOI.dtPOI3Mensual_Resumen,
                            "COD_MODALIDAD",
                            { colIndex: [4, 5], data: ["AREA_OTORGADA", "AREA_SUPERVISADA"], color: ["green", "blue"] },
                            { title: "NÚMERO DE HECTÁREAS DE TH SUPERVISADAS EN GABINETE", canvas: "cnvPOI3Mensual_Resumen" },
                        );
                        break;

                    case "0000015":
                        for (i = 0; i < data.data.length; i++) {
                            c3 += parseInt(data.data[i]["TOTAL"]);
                        }
                        _renderPOI.dtPOI4Mensual_Resumen.rows.add(data.data).draw();

                        tb = $("#tbPOI4Mensual_Resumen");
                        tb.find("#col3").text(c3);

                        _renderPOI.chartPOI4Mensual_Resumen = customChart.LoadBarraSimple_DataTable(
                            _renderPOI.dtPOI4Mensual_Resumen,
                            "NOMBRE_MES",
                            { colIndex: [2], data: ["TOTAL"], color: ["green"] },
                            { title: "TOTAL DE TH DE FAUNA SUPERVISADOS", canvas: "cnvPOI4Mensual_Resumen" },
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

_renderPOI.intlRound = function (numero, decimales, usarComa = false) {
    var opciones = {
        maximumFractionDigits: decimales,
        useGrouping: false
    };
    usarComa = usarComa ? "es" : "en";
    return new Intl.NumberFormat(usarComa, opciones).format(numero);
}

_renderPOI.fnEventColumn = function (obj, col) {
    var indicador = _renderPOI.frm.find("#ddlIndicadorPOIId").val();
    var numMes = "";

    if (obj != "") {
        switch (indicador) {
            case "0000011":
                numMes = _renderPOI.dtPOI1Mensual_Resumen.row($(obj).parents('tr')).data()["NRO_TRIMESTRE"];
                break;
            case "0000012":
                numMes = _renderPOI.dtPOI2Mensual_Resumen.row($(obj).parents('tr')).data()["MES"];
                break;
            case "0000013":
                numMes = _renderPOI.dtPOI3Mensual_Resumen.row($(obj).parents('tr')).data()["MES"];
                break;
            case "0000015":
                numMes = _renderPOI.dtPOI4Mensual_Resumen.row($(obj).parents('tr')).data()["MES"];
                break;
        }
    }

    if (_renderPOI.filterValidate()) {
        switch (indicador) {
            case "0000011":
                _renderPOI.dtPOI1Mensual_Detalle.clear().draw();
                break;
            case "0000012":
                _renderPOI.dtPOI2Mensual_Detalle.clear().draw();
                break;
            case "0000013":
                _renderPOI.dtPOI3Mensual_Detalle.clear().draw();
                break;
            case "0000015":
                _renderPOI.dtPOI4Mensual_Detalle.clear().draw();
                break;
        }

        var datosReporte = _renderPOI.frm.serializeObject();
        datosReporte.idTab = Indicador.frm.find("#idTab").val();
        datosReporte.tipo = "LISTA";
        datosReporte.numero = numMes;

        var option = { url: _renderPOI.frm.attr("action"), datos: JSON.stringify(datosReporte), type: 'POST' };
        utilSigo.fnAjax(option, function (data) {
            if (data.success) {
                switch (indicador) {
                    case "0000011":
                        _renderPOI.dtPOI1Mensual_Detalle.rows.add(data.data).draw();
                        break;
                    case "0000012":
                        _renderPOI.dtPOI2Mensual_Detalle.rows.add(data.data).draw();
                        break;
                    case "0000013":
                        _renderPOI.dtPOI3Mensual_Detalle.rows.add(data.data).draw();
                        break;
                    case "0000015":
                        _renderPOI.dtPOI4Mensual_Detalle.rows.add(data.data).draw();
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

_renderPOI.fnEventTotal = function (valor) {
    var indicador = _renderPOI.frm.find("#ddlIndicadorPOIId").val();
    var cant = 0;

    switch (indicador) {
        case "0000011":
            cant = _renderPOI.dtPOI1Mensual_Resumen.$("tr").length;
            break;
        case "0000015":
            cant = _renderPOI.dtPOI4Mensual_Resumen.$("tr").length;
            break;
    }

    if (cant > 0) {
        switch (indicador) {
            case "0000011":
                _renderPOI.dtPOI1Mensual_Detalle.clear().draw();
                break;
            case "0000015":
                _renderPOI.dtPOI4Mensual_Detalle.clear().draw();
                break;
        }

        var datosReporte = _renderPOI.frm.serializeObject();
        datosReporte.idTab = Indicador.frm.find("#idTab").val();
        datosReporte.tipo = "LISTA";
        datosReporte.numero = valor;

        var option = { url: _renderPOI.frm.attr("action"), datos: JSON.stringify(datosReporte), type: 'POST' };
        utilSigo.fnAjax(option, function (data) {
            if (data.success) {
                switch (indicador) {
                    case "0000011":
                        _renderPOI.dtPOI1Mensual_Detalle.rows.add(data.data).draw();
                        break;
                    case "0000015":
                        _renderPOI.dtPOI4Mensual_Detalle.rows.add(data.data).draw();
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

/*Reporte 1: RF-017 NÚMERO DE HECTÁREAS DE TH AUDITADAS*/
_renderPOI.fnInitDatosRpt1 = function () {
    var columns_label = [], columns_data = [], columns_event = [], options = {};

    columns_label = ["Mes", "Número de hectáreas de TH auditadas"];
    columns_event = ["fn(c2)", ""];
    columns_data = ["DESCRIPCION", "TOTAL"];
    options = {
        button_excel: true, export_title: $("#tbPOI1Mensual_Resumen").find("thead tr")[0].innerText.trim(), row_index: true
    };
    _renderPOI.dtPOI1Mensual_Resumen = utilDt.fnLoadDataTable_EventColumn($("#tbPOI1Mensual_Resumen"), columns_label, columns_data, columns_event, options);

    columns_label = ["Fecha de Registro", "Fecha Inicio de auditoria", "N° Informe Quinquenal", "Tipo", "N° Documento Referencia"
        , "Título Habilitante", "Titular", "Area Otorgada(ha)"];
    columns_data = ["FECHA_REGISTRO", "FECHA_INICIO_AUDITORIA", "NRO_INFORME", "TIPO_INFORME", "DOC_REFERENCIA", "TITULO_HABILITANTE", "APELLIDOS_NOMBRES", "AREA_OTORGADA"];
    options = {
        button_excel: true, export_title: $("#tbPOI1Mensual_Detalle").find("thead tr")[0].innerText.trim(), page_length: 20,
        row_index: true, page_sort: true, page_info: true
    };
    _renderPOI.dtPOI1Mensual_Detalle = utilDt.fnLoadDataTable_Detail($("#tbPOI1Mensual_Detalle"), columns_label, columns_data, options);
}

_renderPOI.fnLimpiarRpt1 = function () {
    _renderPOI.dtPOI1Mensual_Resumen.clear().draw();
    _renderPOI.dtPOI1Mensual_Detalle.clear().draw();

    var tb = $("#tbPOI1Mensual_Resumen");
    tb.find("#col3").text(0);

    if (_renderPOI.chartPOI1Mensual_Resumen != null) {
        _renderPOI.chartPOI1Mensual_Resumen.destroy();
    }
}
/******************Fin Reporte 1*******************/

/*Reporte 2: RF-018 NÚMERO DE HECTÁREAS DE TH SUPERVISADAS EN CAMPO, POR MODALIDAD*/
_renderPOI.fnInitDatosRpt2 = function () {
    var columns_label = [], columns_data = [], columns_event = [], options = {};

    columns_label = ["Mes", "Código", "Modalidad", "Número de hectáreas de TH supervisados", "Número de hectáreas de POA supervisados"];
    columns_event = ["fn(c2)", "", "", "", ""];
    columns_data = ["NOMBRE_MES", "COD_MODALIDAD", "MODALIDAD", "AREA_OTORGADA", "AREA_SUPERVISADA"];
    options = {
        button_excel: true, export_title: $("#tbPOI2Mensual_Resumen").find("thead tr")[0].innerText.trim(), row_index: true
    };
    _renderPOI.dtPOI2Mensual_Resumen = utilDt.fnLoadDataTable_EventColumn($("#tbPOI2Mensual_Resumen"), columns_label, columns_data, columns_event, options);

    columns_label = ["Fecha Inicio Supervisión", "Nro. Informe", "Tipo Informe", "Título Habilitante"
        , "Titular", "Modalidad", "Area TH", "Area de POA Supervisado"];
    columns_data = ["FECHA_SUPERVISION", "NRO_INFORME", "TIPO_INFORME", "NUMERO", "APELLIDOS_NOMBRES", "MODALIDAD", "AREA_OTORGADA"
        , "AREA_SUPERVISADA"];
    options = {
        button_excel: true, export_title: $("#tbPOI2Mensual_Detalle").find("thead tr")[0].innerText.trim(), page_length: 20,
        row_index: true, page_sort: true, page_info: true
    };
    _renderPOI.dtPOI2Mensual_Detalle = utilDt.fnLoadDataTable_Detail($("#tbPOI2Mensual_Detalle"), columns_label, columns_data, options);
}

_renderPOI.fnLimpiarRpt2 = function () {
    _renderPOI.dtPOI2Mensual_Resumen.clear().draw();
    _renderPOI.dtPOI2Mensual_Detalle.clear().draw();

    var tb = $("#tbPOI2Mensual_Resumen");
    tb.find("#col5").text(0); tb.find("#col6").text(0);

    if (_renderPOI.chartPOI2Mensual_Resumen != null) {
        _renderPOI.chartPOI2Mensual_Resumen.destroy();
    }
}
/******************Fin Reporte 2*******************/

/*Reporte 3: RF-019 NÚMERO DE HECTÁREAS DE TH SUPERVISADAS EN GABINETE*/
_renderPOI.fnInitDatosRpt3 = function () {
    var columns_label = [], columns_data = [], columns_event = [], options = {};

    columns_label = ["Mes", "Código", "Modalidad", "Numero hectáreas de TH supervisados", "Numero hectáreas de POA supervisados"];
    columns_event = ["fn(c2)", "", "", "", ""];
    columns_data = ["NOMBRE_MES", "COD_MODALIDAD", "MODALIDAD", "AREA_OTORGADA", "AREA_SUPERVISADA"];
    options = {
        button_excel: true, export_title: $("#tbPOI3Mensual_Resumen").find("thead tr")[0].innerText.trim(), row_index: true
    };
    _renderPOI.dtPOI3Mensual_Resumen = utilDt.fnLoadDataTable_EventColumn($("#tbPOI3Mensual_Resumen"), columns_label, columns_data, columns_event, options);

    columns_label = ["Fecha Inicio Supervisión", "Nro. Informe", "Tipo Informe", "Título Habilitante", "Titular", "Modalidad", "Area TH"
        , "Area de POA Supervisado"];
    columns_data = ["FECHA_SUPERVISION", "NRO_INFORME", "TIPO_INFORME", "NUMERO", "TITULAR", "MODALIDAD", "AREA_OTORGADA"
        , "AREA_SUPERVISADA"];
    options = {
        button_excel: true, export_title: $("#tbPOI3Mensual_Detalle").find("thead tr")[0].innerText.trim(), page_length: 20,
        row_index: true, page_sort: true, page_info: true
    };
    _renderPOI.dtPOI3Mensual_Detalle = utilDt.fnLoadDataTable_Detail($("#tbPOI3Mensual_Detalle"), columns_label, columns_data, options);
}

_renderPOI.fnLimpiarRpt3 = function () {
    _renderPOI.dtPOI3Mensual_Resumen.clear().draw();
    _renderPOI.dtPOI3Mensual_Detalle.clear().draw();

    var tb = $("#tbPOI3Mensual_Resumen");
    tb.find("#col5").text(0); tb.find("#col6").text(0);

    if (_renderPOI.chartPOI3Mensual_Resumen != null) {
        _renderPOI.chartPOI3Mensual_Resumen.destroy();
    }
}
/******************Fin Reporte 3*******************/

/*Reporte 4: RF-021 TOTAL DE TH DE FAUNA SUPERVISADOS*/
_renderPOI.fnInitDatosRpt4 = function () {
    var columns_label = [], columns_data = [], columns_event = [], options = {};

    columns_label = ["Mes", "Total de TH Supervisados"];
    columns_event = ["fn(c2)", ""];
    columns_data = ["NOMBRE_MES", "TOTAL"];
    options = {
        button_excel: true, export_title: $("#tbPOI4Mensual_Resumen").find("thead tr")[0].innerText.trim(), row_index: true
    };
    _renderPOI.dtPOI4Mensual_Resumen = utilDt.fnLoadDataTable_EventColumn($("#tbPOI4Mensual_Resumen"), columns_label, columns_data, columns_event, options);

    columns_label = ["Fecha Inicio Supervisión", "Nro. Informe", "Tipo Informe", "Título Habilitante", "Titular", "Modalidad"];
    columns_data = ["FECHA_SUPERVISION", "NRO_INFORME", "TIPO_INFORME", "NUMERO", "TITULAR", "MODALIDAD"];
    options = {
        button_excel: true, export_title: $("#tbPOI4Mensual_Detalle").find("thead tr")[0].innerText.trim(), page_length: 20,
        row_index: true, page_sort: true, page_info: true
    };
    _renderPOI.dtPOI4Mensual_Detalle = utilDt.fnLoadDataTable_Detail($("#tbPOI4Mensual_Detalle"), columns_label, columns_data, options);
}

_renderPOI.fnLimpiarRpt4 = function () {
    _renderPOI.dtPOI4Mensual_Resumen.clear().draw();
    _renderPOI.dtPOI4Mensual_Detalle.clear().draw();

    var tb = $("#tbPOI4Mensual_Resumen");
    tb.find("#col3").text(0);

    if (_renderPOI.chartPOI4Mensual_Resumen != null) {
        _renderPOI.chartPOI4Mensual_Resumen.destroy();
    }
}
/******************Fin Reporte 4*******************/

$(document).ready(function () {
    _renderPOI.frm = $("#frmFiltroPOI");

    _renderPOI.fnInitFiltro();
    _renderPOI.fnInitDatosRpt1();
    _renderPOI.fnInitDatosRpt2();
    _renderPOI.fnInitDatosRpt3();
    _renderPOI.fnInitDatosRpt4();
});