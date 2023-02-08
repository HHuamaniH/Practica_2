"use strict";
var _renderMAPRO = {};
_renderMAPRO.DataIndicador = [];
_renderMAPRO.meta = 0;
_renderMAPRO.chartMAPRO1Trimestral_Resumen = null;
_renderMAPRO.chartMAPRO2Trimestral_Resumen = null;
_renderMAPRO.chartMAPRO3Trimestral_Resumen = null;
_renderMAPRO.chartMAPRO4Trimestral_Resumen = null;
_renderMAPRO.chartMAPRO5Trimestral_Resumen = null;
_renderMAPRO.chartMAPRO6Trimestral_Resumen = null;
_renderMAPRO.chartMAPRO7Trimestral_Resumen = null;
_renderMAPRO.chartMAPRO8Trimestral_Resumen = null;
_renderMAPRO.chartMAPRO9Trimestral_Resumen = null;
_renderMAPRO.chartMAPRO10Trimestral_Resumen = null;

_renderMAPRO.fnLoadIndicador = function (obj) {
    _renderMAPRO.DataIndicador = JSON.parse(obj);
}

_renderMAPRO.filterValidate = function () {
    if (_renderMAPRO.frm.find("#ddlIndicadorMAPROId").val() == "0000000") {
        utilSigo.toastWarning("Aviso", "Seleccione Indicador"); return false;
    }

    if (_renderMAPRO.frm.find("#ddlAnioMAPROId").val() == "0000") {
        utilSigo.toastWarning("Aviso", "Seleccione Año"); return false;
    }

    return true;
}

_renderMAPRO.fnFiltrarAnio = function (_codIndicador) {
    var url = urlLocalSigo + "Supervision/Indicadores/FiltrarAnio";
    var params = { ddlIndicadorMAPROId: _codIndicador, tipo: "YEAR", idTab:Indicador.frm.find("#idTab").val()};
    var option = { url: url, type: 'POST', datos: JSON.stringify(params) };

    utilSigo.fnAjax(option, function (data) {
        if (data.success) {
            var anio = _renderMAPRO.frm.find("#ddlAnioMAPROId");
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
_renderMAPRO.fnInitFiltro = function () {
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

    //Filtro: Indicador
    _renderMAPRO.frm.find("#ddlIndicadorMAPROId").change(function () {

        /*for (var i = 0; i < _renderMAPRO.DataIndicador.length; i++) {
            if (this.value != "0000000") {
                if (this.value == _renderMAPRO.DataIndicador[i].Value)
                    _renderMAPRO.meta = parseFloat(_renderMAPRO.DataIndicador[i].Tipo.replace(",", "."));
            }
            else _renderMAPRO.meta = 0;
        }*/

        _renderMAPRO.fnFiltrarAnio(this.value);

        switch (this.value) {
            case "0000001":
                $("#dvResultadoMAPRO1").show();
                $("#dvResultadoMAPRO2").hide();
                $("#dvResultadoMAPRO3").hide();
                $("#dvResultadoMAPRO4").hide();
                $("#dvResultadoMAPRO5").hide();
                $("#dvResultadoMAPRO6").hide();
                $("#dvResultadoMAPRO7").hide();
                $("#dvResultadoMAPRO8").hide();
                $("#dvResultadoMAPRO9").hide();
                $("#dvResultadoMAPRO10").hide();
                _renderMAPRO.fnLimpiarRpt1();
                break;
            case "0000002":
                $("#dvResultadoMAPRO1").hide();
                $("#dvResultadoMAPRO2").show();
                $("#dvResultadoMAPRO3").hide();
                $("#dvResultadoMAPRO4").hide();
                $("#dvResultadoMAPRO5").hide();
                $("#dvResultadoMAPRO6").hide();
                $("#dvResultadoMAPRO7").hide();
                $("#dvResultadoMAPRO8").hide();
                $("#dvResultadoMAPRO9").hide();
                $("#dvResultadoMAPRO10").hide();
                _renderMAPRO.fnLimpiarRpt2();
                break;
            case "0000003":
                $("#dvResultadoMAPRO1").hide();
                $("#dvResultadoMAPRO2").hide();
                $("#dvResultadoMAPRO3").show();
                $("#dvResultadoMAPRO4").hide();
                $("#dvResultadoMAPRO5").hide();
                $("#dvResultadoMAPRO6").hide();
                $("#dvResultadoMAPRO7").hide();
                $("#dvResultadoMAPRO8").hide();
                $("#dvResultadoMAPRO9").hide();
                $("#dvResultadoMAPRO10").hide();
                _renderMAPRO.fnLimpiarRpt3();
                break;
            case "0000004":
                $("#dvResultadoMAPRO1").hide();
                $("#dvResultadoMAPRO2").hide();
                $("#dvResultadoMAPRO3").hide();
                $("#dvResultadoMAPRO4").show();
                $("#dvResultadoMAPRO5").hide();
                $("#dvResultadoMAPRO6").hide();
                $("#dvResultadoMAPRO7").hide();
                $("#dvResultadoMAPRO8").hide();
                $("#dvResultadoMAPRO9").hide();
                $("#dvResultadoMAPRO10").hide();
                _renderMAPRO.fnLimpiarRpt4();
                break;
            case "0000005":
                $("#dvResultadoMAPRO1").hide();
                $("#dvResultadoMAPRO2").hide();
                $("#dvResultadoMAPRO3").hide();
                $("#dvResultadoMAPRO4").hide();
                $("#dvResultadoMAPRO5").show();
                $("#dvResultadoMAPRO6").hide();
                $("#dvResultadoMAPRO7").hide();
                $("#dvResultadoMAPRO8").hide();
                $("#dvResultadoMAPRO9").hide();
                $("#dvResultadoMAPRO10").hide();
                _renderMAPRO.fnLimpiarRpt5();
                break;
            case "0000006":
                $("#dvResultadoMAPRO1").hide();
                $("#dvResultadoMAPRO2").hide();
                $("#dvResultadoMAPRO3").hide();
                $("#dvResultadoMAPRO4").hide();
                $("#dvResultadoMAPRO5").hide();
                $("#dvResultadoMAPRO6").show();
                $("#dvResultadoMAPRO7").hide();
                $("#dvResultadoMAPRO8").hide();
                $("#dvResultadoMAPRO9").hide();
                $("#dvResultadoMAPRO10").hide();
                _renderMAPRO.fnLimpiarRpt6();
                break;
            case "0000007":
                $("#dvResultadoMAPRO1").hide();
                $("#dvResultadoMAPRO2").hide();
                $("#dvResultadoMAPRO3").hide();
                $("#dvResultadoMAPRO4").hide();
                $("#dvResultadoMAPRO5").hide();
                $("#dvResultadoMAPRO6").hide();
                $("#dvResultadoMAPRO7").show();
                $("#dvResultadoMAPRO8").hide();
                $("#dvResultadoMAPRO9").hide();
                $("#dvResultadoMAPRO10").hide();
                _renderMAPRO.fnLimpiarRpt7();
                break;
            case "0000008":
                $("#dvResultadoMAPRO1").hide();
                $("#dvResultadoMAPRO2").hide();
                $("#dvResultadoMAPRO3").hide();
                $("#dvResultadoMAPRO4").hide();
                $("#dvResultadoMAPRO5").hide();
                $("#dvResultadoMAPRO6").hide();
                $("#dvResultadoMAPRO7").hide();
                $("#dvResultadoMAPRO8").show();
                $("#dvResultadoMAPRO9").hide();
                $("#dvResultadoMAPRO10").hide();
                _renderMAPRO.fnLimpiarRpt8();
                break;
            case "0000009":
                $("#dvResultadoMAPRO1").hide();
                $("#dvResultadoMAPRO2").hide();
                $("#dvResultadoMAPRO3").hide();
                $("#dvResultadoMAPRO4").hide();
                $("#dvResultadoMAPRO5").hide();
                $("#dvResultadoMAPRO6").hide();
                $("#dvResultadoMAPRO7").hide();
                $("#dvResultadoMAPRO8").hide();
                $("#dvResultadoMAPRO9").show();
                $("#dvResultadoMAPRO10").hide();
                _renderMAPRO.fnLimpiarRpt9();
                break;
            case "0000010":
                $("#dvResultadoMAPRO1").hide();
                $("#dvResultadoMAPRO2").hide();
                $("#dvResultadoMAPRO3").hide();
                $("#dvResultadoMAPRO4").hide();
                $("#dvResultadoMAPRO5").hide();
                $("#dvResultadoMAPRO6").hide();
                $("#dvResultadoMAPRO7").hide();
                $("#dvResultadoMAPRO8").hide();
                $("#dvResultadoMAPRO9").hide();
                $("#dvResultadoMAPRO10").show();
                _renderMAPRO.fnLimpiarRpt10();
                break;
        }
    });

    //Filtro: Año
    _renderMAPRO.frm.find("#ddlAnioMAPROId").change(function () {
        _renderMAPRO.fnLimpiarDatos();
    });
}
/******************Fin Filtros*******************/

_renderMAPRO.fnLimpiarDatos = function () {
    var indicador = _renderMAPRO.frm.find("#ddlIndicadorMAPROId").val();

    switch (indicador) {
        case "0000001":
            _renderMAPRO.fnLimpiarRpt1();
            break;
        case "0000002":
            _renderMAPRO.fnLimpiarRpt2();
            break;
        case "0000003":
            _renderMAPRO.fnLimpiarRpt3();
            break;
        case "0000004":
            _renderMAPRO.fnLimpiarRpt4();
            break;
        case "0000005":
            _renderMAPRO.fnLimpiarRpt5();
            break;
        case "0000006":
            _renderMAPRO.fnLimpiarRpt6();
            break;
        case "0000007":
            _renderMAPRO.fnLimpiarRpt7();
            break;
        case "0000008":
            _renderMAPRO.fnLimpiarRpt8();
            break;
        case "0000009":
            _renderMAPRO.fnLimpiarRpt9();
            break;
        case "0000010":
            _renderMAPRO.fnLimpiarRpt10();
            break;
    }
}

_renderMAPRO.fnSubmitForm = function () {
    _renderMAPRO.fnLimpiarDatos();

    if (_renderMAPRO.filterValidate()) {
        var datosReporte = _renderMAPRO.frm.serializeObject();
        datosReporte.idTab = Indicador.frm.find("#idTab").val();
        datosReporte.tipo = "CUADRO";
        var option = { url: _renderMAPRO.frm.attr("action"), datos: JSON.stringify(datosReporte), type: 'POST' };

        utilSigo.fnAjax(option, function (data) {
            if (data.success) {
                var indicador = _renderMAPRO.frm.find("#ddlIndicadorMAPROId").val();
                var c3 = 0, c4 = 0, c5 = 0;
                var data_meta, tb, i;
                _renderMAPRO.meta = data.obj.NU_META;

                switch (indicador) {
                    case "0000001":
                        data_meta = [];

                        for (i = 0; i < data.data.length; i++) {
                            data.data[i]["PORCENTAJE"] = data.data[i]["PORCENTAJE"].replace(",", ".");
                            c3 += parseInt(data.data[i]["TOTAL"]); c4 += parseInt(data.data[i]["PARTE"]);
                            //c5 += parseFloat(data.data[i]["PORCENTAJE"]);

                            data_meta.push(_renderMAPRO.meta);
                        }
                        c5 = (c4 / c3) * 100;
                        _renderMAPRO.dtMAPRO1Trimestral_Resumen.rows.add(data.data).draw();

                        tb = $("#tbMAPRO1Trimestral_Resumen");
                        tb.find("#col3").text(c3); tb.find("#col4").text(c4); tb.find("#col5").text(_renderMAPRO.intlRound(c5, 2));

                        if (_renderMAPRO.meta > 0) {
                            _renderMAPRO.chartMAPRO1Trimestral_Resumen = customChart.LoadBarraMixedMeta_DataTable(
                                _renderMAPRO.dtMAPRO1Trimestral_Resumen,
                                "DESCRIPCION",
                                { colIndex: [4], data: ["PORCENTAJE"], color: ["green"] },
                                { title: "PORCENTAJE DE PLANES DE MANEJO CON CONTROL DE CALIDAD CONFORME", canvas: "cnvMAPRO1Trimestral_Resumen" },
                                { data: data_meta, color: "red", title: "Meta (" + _renderMAPRO.meta + "%)" }
                            );
                        }
                        else {
                            _renderMAPRO.chartMAPRO1Trimestral_Resumen = customChart.LoadBarraSimple_DataTable(
                                _renderMAPRO.dtMAPRO1Trimestral_Resumen,
                                "DESCRIPCION",
                                { colIndex: [4], data: ["PORCENTAJE"], color: ["green"] },
                                { title: "PORCENTAJE DE PLANES DE MANEJO CON CONTROL DE CALIDAD CONFORME", canvas: "cnvMAPRO1Trimestral_Resumen" }
                            );
                        }

                        break;
                    case "0000002":
                        data_meta = [];
                        var mayorc4 = 0;
                        var mayorc5 = 0;

                        for (i = 0; i < data.data.length; i++) {
                            data.data[i]["PORCENTAJE"] = data.data[i]["PORCENTAJE"].replace(",", ".");
                            //c3 += parseInt(data.data[i]["TOTAL"]); c4 += parseInt(data.data[i]["PARTE"]);
                            if (parseInt(data.data[i]["PARTE"])>mayorc4) {
                                mayorc4 = parseInt(data.data[i]["PARTE"]);
                            }
                            if (parseInt(data.data[i]["PORCENTAJE"]) > mayorc5) {
                                mayorc5 = parseFloat(data.data[i]["PORCENTAJE"]);
                            }

                            data_meta.push(_renderMAPRO.meta);
                        }
                        c3 = parseInt(data.data[0]["TOTAL"]);
                        c4 = mayorc4;
                        c5 = mayorc5;
                        //c5 = (c4 / c3) * 100;
                        _renderMAPRO.dtMAPRO2Trimestral_Resumen.rows.add(data.data).draw();

                        tb = $("#tbMAPRO2Trimestral_Resumen");
                        tb.find("#col3").text(c3); tb.find("#col4").text(c4); tb.find("#col5").text(_renderMAPRO.intlRound(c5, 2));

                        if (_renderMAPRO.meta > 0) {
                            _renderMAPRO.chartMAPRO2Trimestral_Resumen = customChart.LoadBarraMixedMeta_DataTable(
                                _renderMAPRO.dtMAPRO2Trimestral_Resumen,
                                "DESCRIPCION",
                                { colIndex: [4], data: ["PORCENTAJE"], color: ["green"] },
                                { title: "PORCENTAJE DE TÍTULOS HABILITANTES SUPERVISADOS SEGÚN PASPEQ", canvas: "cnvMAPRO2Trimestral_Resumen" },
                                { data: data_meta, color: "red", title: "Meta (" + _renderMAPRO.meta + "%)" }
                            );
                        }
                        else {
                            _renderMAPRO.chartMAPRO2Trimestral_Resumen = customChart.LoadBarraSimple_DataTable(
                                _renderMAPRO.dtMAPRO2Trimestral_Resumen,
                                "DESCRIPCION",
                                { colIndex: [4], data: ["PORCENTAJE"], color: ["green"] },
                                { title: "PORCENTAJE DE TÍTULOS HABILITANTES SUPERVISADOS SEGÚN PASPEQ", canvas: "cnvMAPRO2Trimestral_Resumen" }
                            );
                        }

                        break;
                    case "0000003":
                        data_meta = [];

                        for (i = 0; i < data.data.length; i++) {
                            data.data[i]["PORCENTAJE"] = data.data[i]["PORCENTAJE"].replace(",", ".");
                            c3 += parseInt(data.data[i]["TOTAL"]); c4 += parseInt(data.data[i]["PARTE"]);

                            data_meta.push(_renderMAPRO.meta);
                        }
                        c5 = (c4 / c3) * 100;
                        _renderMAPRO.dtMAPRO3Trimestral_Resumen.rows.add(data.data).draw();

                        tb = $("#tbMAPRO3Trimestral_Resumen");
                        tb.find("#col3").text(c3); tb.find("#col4").text(c4); tb.find("#col5").text(_renderMAPRO.intlRound(c5, 2));

                        if (_renderMAPRO.meta > 0) {
                            _renderMAPRO.chartMAPRO3Trimestral_Resumen = customChart.LoadBarraMixedMeta_DataTable(
                                _renderMAPRO.dtMAPRO3Trimestral_Resumen,
                                "DESCRIPCION",
                                { colIndex: [4], data: ["PORCENTAJE"], color: ["green"] },
                                { title: "PORCENTAJE DE TÍTULOS HABILITANTES AUDITADOS SEGÚN POI", canvas: "cnvMAPRO3Trimestral_Resumen" },
                                { data: data_meta, color: "red", title: "Meta (" + _renderMAPRO.meta + "%)" }
                            );
                        }
                        else {
                            _renderMAPRO.chartMAPRO3Trimestral_Resumen = customChart.LoadBarraSimple_DataTable(
                                _renderMAPRO.dtMAPRO3Trimestral_Resumen,
                                "DESCRIPCION",
                                { colIndex: [4], data: ["PORCENTAJE"], color: ["green"] },
                                { title: "PORCENTAJE DE TÍTULOS HABILITANTES AUDITADOS SEGÚN POI", canvas: "cnvMAPRO3Trimestral_Resumen" }
                            );
                        }

                        break;
                    case "0000004":
                        data_meta = [];

                        for (i = 0; i < data.data.length; i++) {
                            data.data[i]["PORCENTAJE"] = data.data[i]["PORCENTAJE"].replace(",", ".");
                            c3 += parseInt(data.data[i]["TOTAL"]); c4 += parseInt(data.data[i]["PARTE"]);

                            data_meta.push(_renderMAPRO.meta);
                        }
                        c5 = (c4 / c3) * 100;
                        _renderMAPRO.dtMAPRO4Trimestral_Resumen.rows.add(data.data).draw();

                        tb = $("#tbMAPRO4Trimestral_Resumen");
                        tb.find("#col3").text(c3); tb.find("#col4").text(c4); tb.find("#col5").text(_renderMAPRO.intlRound(c5, 2));

                        if (_renderMAPRO.meta > 0) {
                            _renderMAPRO.chartMAPRO4Trimestral_Resumen = customChart.LoadBarraMixedMeta_DataTable(
                                _renderMAPRO.dtMAPRO4Trimestral_Resumen,
                                "DESCRIPCION",
                                { colIndex: [4], data: ["PORCENTAJE"], color: ["green"] },
                                { title: "PORCENTAJE DE TÍTULOS HABILITANTES SUPERVISADOS SEGÚN POI", canvas: "cnvMAPRO4Trimestral_Resumen" },
                                { data: data_meta, color: "red", title: "Meta (" + _renderMAPRO.meta + "%)" }
                            );
                        }
                        else {
                            _renderMAPRO.chartMAPRO4Trimestral_Resumen = customChart.LoadBarraSimple_DataTable(
                                _renderMAPRO.dtMAPRO4Trimestral_Resumen,
                                "DESCRIPCION",
                                { colIndex: [4], data: ["PORCENTAJE"], color: ["green"] },
                                { title: "PORCENTAJE DE TÍTULOS HABILITANTES SUPERVISADOS SEGÚN POI", canvas: "cnvMAPRO4Trimestral_Resumen" }
                            );
                        }

                        break;
                    case "0000005":
                        data_meta = [];

                        for (i = 0; i < data.data.length; i++) {
                            data.data[i]["PORCENTAJE"] = data.data[i]["PORCENTAJE"].replace(",", ".");
                            c3 += parseInt(data.data[i]["TOTAL"]); c4 += parseInt(data.data[i]["PARTE"]);

                            data_meta.push(_renderMAPRO.meta);
                        }
                        c5 = (c4 / c3) * 100;
                        _renderMAPRO.dtMAPRO5Trimestral_Resumen.rows.add(data.data).draw();

                        tb = $("#tbMAPRO5Trimestral_Resumen");
                        tb.find("#col3").text(c3); tb.find("#col4").text(c4); tb.find("#col5").text(_renderMAPRO.intlRound(c5, 2));

                        if (_renderMAPRO.meta > 0) {
                            _renderMAPRO.chartMAPRO5Trimestral_Resumen = customChart.LoadBarraMixedMeta_DataTable(
                                _renderMAPRO.dtMAPRO5Trimestral_Resumen,
                                "DESCRIPCION",
                                { colIndex: [4], data: ["PORCENTAJE"], color: ["green"] },
                                //{ colIndex: [2, 3], data: ["TOTAL", "PARTE"], color: ["green", "blue"] },
                                { title: "PORCENTAJE DE NOTIFICACIONES CORRECTAMENTE DILIGENCIADAS", canvas: "cnvMAPRO5Trimestral_Resumen" },
                                { data: data_meta, color: "red", title: "Meta (" + _renderMAPRO.meta + "%)" }
                            );
                        }
                        else {
                            _renderMAPRO.chartMAPRO5Trimestral_Resumen = customChart.LoadBarraSimple_DataTable(
                                _renderMAPRO.dtMAPRO5Trimestral_Resumen,
                                "DESCRIPCION",
                                { colIndex: [4], data: ["PORCENTAJE"], color: ["green"] },
                                //{ colIndex: [2, 3], data: ["TOTAL", "PARTE"], color: ["green", "blue"] },
                                { title: "PORCENTAJE DE NOTIFICACIONES CORRECTAMENTE DILIGENCIADAS", canvas: "cnvMAPRO5Trimestral_Resumen" }
                            );
                        }

                        break;
                    case "0000006":
                        data_meta = [];

                        for (i = 0; i < data.data.length; i++) {
                            data.data[i]["PORCENTAJE"] = data.data[i]["PORCENTAJE"].replace(",", ".");
                            c3 += parseInt(data.data[i]["TOTAL"]); c4 += parseInt(data.data[i]["PARTE"]);

                            data_meta.push(_renderMAPRO.meta);
                        }
                        c5 = (c4 / c3) * 100;
                        _renderMAPRO.dtMAPRO6Trimestral_Resumen.rows.add(data.data).draw();

                        tb = $("#tbMAPRO6Trimestral_Resumen");
                        tb.find("#col3").text(c3); tb.find("#col4").text(c4); tb.find("#col5").text(_renderMAPRO.intlRound(c5, 2));

                        if (_renderMAPRO.meta > 0) {
                            _renderMAPRO.chartMAPRO6Trimestral_Resumen = customChart.LoadBarraMixedMeta_DataTable(
                                _renderMAPRO.dtMAPRO6Trimestral_Resumen,
                                "DESCRIPCION",
                                { colIndex: [4], data: ["PORCENTAJE"], color: ["green"] },
                                { title: "PORCENTAJE DE ATENCIÓN DE FONDOS POR ENCARGO EN EL PLAZO ESTABLECIDO", canvas: "cnvMAPRO6Trimestral_Resumen" },
                                { data: data_meta, color: "red", title: "Meta (" + _renderMAPRO.meta + "%)" }
                            );
                        }
                        else {
                            _renderMAPRO.chartMAPRO6Trimestral_Resumen = customChart.LoadBarraSimple_DataTable(
                                _renderMAPRO.dtMAPRO6Trimestral_Resumen,
                                "DESCRIPCION",
                                { colIndex: [4], data: ["PORCENTAJE"], color: ["green"] },
                                { title: "PORCENTAJE DE ATENCIÓN DE FONDOS POR ENCARGO EN EL PLAZO ESTABLECIDO", canvas: "cnvMAPRO6Trimestral_Resumen" }
                            );
                        }

                        break;
                    case "0000007":
                        data_meta = [];

                        for (i = 0; i < data.data.length; i++) {
                            data.data[i]["PORCENTAJE"] = data.data[i]["PORCENTAJE"].replace(",", ".");
                            c3 += parseInt(data.data[i]["TOTAL"]); c4 += parseInt(data.data[i]["PARTE"]);

                            data_meta.push(_renderMAPRO.meta);
                        }
                        c5 = (c4 / c3) * 100;
                        _renderMAPRO.dtMAPRO7Trimestral_Resumen.rows.add(data.data).draw();

                        tb = $("#tbMAPRO7Trimestral_Resumen");
                        tb.find("#col3").text(c3); tb.find("#col4").text(c4); tb.find("#col5").text(_renderMAPRO.intlRound(c5, 2));

                        if (_renderMAPRO.meta > 0) {
                            _renderMAPRO.chartMAPRO7Trimestral_Resumen = customChart.LoadBarraMixedMeta_DataTable(
                                _renderMAPRO.dtMAPRO7Trimestral_Resumen,
                                "DESCRIPCION",
                                { colIndex: [4], data: ["PORCENTAJE"], color: ["green"] },
                                { title: "PROMEDIO DE SUPERVISIONES QUE CUMPLEN CON LA NORMATIVA", canvas: "cnvMAPRO7Trimestral_Resumen" },
                                { data: data_meta, color: "red", title: "Meta (" + _renderMAPRO.meta + ")" }
                            );
                        }
                        else {
                            _renderMAPRO.chartMAPRO7Trimestral_Resumen = customChart.LoadBarraSimple_DataTable(
                                _renderMAPRO.dtMAPRO7Trimestral_Resumen,
                                "DESCRIPCION",
                                { colIndex: [4], data: ["PORCENTAJE"], color: ["green"] },
                                { title: "PROMEDIO DE SUPERVISIONES QUE CUMPLEN CON LA NORMATIVA", canvas: "cnvMAPRO7Trimestral_Resumen" }
                            );
                        }
                        
                        break;
                    case "0000008":
                        data_meta = [];

                        for (i = 0; i < data.data.length; i++) {
                            data.data[i]["PORCENTAJE"] = data.data[i]["PORCENTAJE"].replace(",", ".");
                            c3 += parseInt(data.data[i]["TOTAL"]); c4 += parseInt(data.data[i]["PARTE"]);

                            data_meta.push(_renderMAPRO.meta);
                        }
                        c5 = (c4 / c3);
                        _renderMAPRO.dtMAPRO8Trimestral_Resumen.rows.add(data.data).draw();

                        tb = $("#tbMAPRO8Trimestral_Resumen");
                        tb.find("#col3").text(c3); tb.find("#col4").text(c4); tb.find("#col5").text(_renderMAPRO.intlRound(c5, 2));

                        if (_renderMAPRO.meta > 0) {
                            _renderMAPRO.chartMAPRO8Trimestral_Resumen = customChart.LoadBarraMixedMeta_DataTable(
                                _renderMAPRO.dtMAPRO8Trimestral_Resumen,
                                "DESCRIPCION",
                                { colIndex: [4], data: ["PORCENTAJE"], color: ["green"] },
                                { title: "PROMEDIO DE DÍAS PARA LA EJECUCIÓN DE LA SUPERVISIÓN", canvas: "cnvMAPRO8Trimestral_Resumen" },
                                { data: data_meta, color: "red", title: "Meta (" + _renderMAPRO.meta + ")" }
                            );
                        }
                        else {
                            _renderMAPRO.chartMAPRO8Trimestral_Resumen = customChart.LoadBarraSimple_DataTable(
                                _renderMAPRO.dtMAPRO8Trimestral_Resumen,
                                "DESCRIPCION",
                                { colIndex: [4], data: ["PORCENTAJE"], color: ["green"] },
                                { title: "PROMEDIO DE DÍAS PARA LA EJECUCIÓN DE LA SUPERVISIÓN", canvas: "cnvMAPRO8Trimestral_Resumen" }
                            );
                        }
                        
                        break;
                    case "0000009":
                        data_meta = [];

                        for (i = 0; i < data.data.length; i++) {
                            data.data[i]["PORCENTAJE"] = data.data[i]["PORCENTAJE"].replace(",", ".");
                            c3 += parseInt(data.data[i]["TOTAL"]); c4 += parseInt(data.data[i]["PARTE"]);

                            data_meta.push(_renderMAPRO.meta);
                        }
                        c5 = (c4 / c3) * 100;
                        _renderMAPRO.dtMAPRO9Trimestral_Resumen.rows.add(data.data).draw();

                        tb = $("#tbMAPRO9Trimestral_Resumen");
                        tb.find("#col3").text(c3); tb.find("#col4").text(c4); tb.find("#col5").text(_renderMAPRO.intlRound(c5, 2));

                        if (_renderMAPRO.meta > 0) {
                            _renderMAPRO.chartMAPRO9Trimestral_Resumen = customChart.LoadBarraMixedMeta_DataTable(
                                _renderMAPRO.dtMAPRO9Trimestral_Resumen,
                                "DESCRIPCION",
                                { colIndex: [4], data: ["PORCENTAJE"], color: ["green"] },
                                { title: "PORCENTAJE DE AUDITORÍAS QUE CUMPLEN CON LA NORMATIVA", canvas: "cnvMAPRO9Trimestral_Resumen" },
                                { data: data_meta, color: "red", title: "Meta (" + _renderMAPRO.meta + "%)" }
                            );
                        }
                        else {
                            _renderMAPRO.chartMAPRO9Trimestral_Resumen = customChart.LoadBarraSimple_DataTable(
                                _renderMAPRO.dtMAPRO9Trimestral_Resumen,
                                "DESCRIPCION",
                                { colIndex: [4], data: ["PORCENTAJE"], color: ["green"] },
                                { title: "PORCENTAJE DE AUDITORÍAS QUE CUMPLEN CON LA NORMATIVA", canvas: "cnvMAPRO9Trimestral_Resumen" }
                            );
                        }
                        
                        break;
                    case "0000010":
                        data_meta = [];

                        for (i = 0; i < data.data.length; i++) {
                            data.data[i]["PORCENTAJE"] = data.data[i]["PORCENTAJE"].replace(",", ".");
                            c3 += parseInt(data.data[i]["TOTAL"]); c4 += parseInt(data.data[i]["PARTE"]);

                            data_meta.push(_renderMAPRO.meta);
                        }
                        c5 = (c4 / c3);
                        _renderMAPRO.dtMAPRO10Trimestral_Resumen.rows.add(data.data).draw();

                        tb = $("#tbMAPRO10Trimestral_Resumen");
                        tb.find("#col3").text(c3); tb.find("#col4").text(c4); tb.find("#col5").text(_renderMAPRO.intlRound(c5, 2));

                        if (_renderMAPRO.meta > 0) {
                            _renderMAPRO.chartMAPRO10Trimestral_Resumen = customChart.LoadBarraMixedMeta_DataTable(
                                _renderMAPRO.dtMAPRO10Trimestral_Resumen,
                                "DESCRIPCION",
                                { colIndex: [4], data: ["PORCENTAJE"], color: ["green"] },
                                { title: "PROMEDIO DE DÍAS DEL PROCESO DE AUDITORÍA", canvas: "cnvMAPRO10Trimestral_Resumen" },
                                { data: data_meta, color: "red", title: "Meta (" + _renderMAPRO.meta + ")" }
                            );
                        }
                        else {
                            _renderMAPRO.chartMAPRO10Trimestral_Resumen = customChart.LoadBarraSimple_DataTable(
                                _renderMAPRO.dtMAPRO10Trimestral_Resumen,
                                "DESCRIPCION",
                                { colIndex: [4], data: ["PORCENTAJE"], color: ["green"] },
                                { title: "PROMEDIO DE DÍAS DEL PROCESO DE AUDITORÍA", canvas: "cnvMAPRO10Trimestral_Resumen" }
                            );
                        }
                        
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

_renderMAPRO.intlRound = function (numero, decimales, usarComa = false) {
    var opciones = {
        maximumFractionDigits: decimales,
        useGrouping: false
    };
    usarComa = usarComa ? "es" : "en";
    return new Intl.NumberFormat(usarComa, opciones).format(numero);
}

_renderMAPRO.fnEventColumn = function (obj, col) {
    var indicador = _renderMAPRO.frm.find("#ddlIndicadorMAPROId").val();
    var numTrimestre = "";

    if (obj != "") {
        switch (indicador) {
            case "0000001":
                numTrimestre = _renderMAPRO.dtMAPRO1Trimestral_Resumen.row($(obj).parents('tr')).data()["NRO_TRIMESTRE"];
                break;
            case "0000002":
                numTrimestre = _renderMAPRO.dtMAPRO2Trimestral_Resumen.row($(obj).parents('tr')).data()["NRO_TRIMESTRE"];
                break;
            case "0000003":
                numTrimestre = _renderMAPRO.dtMAPRO3Trimestral_Resumen.row($(obj).parents('tr')).data()["NRO_TRIMESTRE"];
                break;
            case "0000004":
                numTrimestre = _renderMAPRO.dtMAPRO4Trimestral_Resumen.row($(obj).parents('tr')).data()["NRO_TRIMESTRE"];
                break;
            case "0000005":
                numTrimestre = _renderMAPRO.dtMAPRO5Trimestral_Resumen.row($(obj).parents('tr')).data()["NRO_TRIMESTRE"];
                break;
            case "0000006":
                numTrimestre = _renderMAPRO.dtMAPRO6Trimestral_Resumen.row($(obj).parents('tr')).data()["NRO_TRIMESTRE"];
                break;
            case "0000007":
                numTrimestre = _renderMAPRO.dtMAPRO7Trimestral_Resumen.row($(obj).parents('tr')).data()["NRO_TRIMESTRE"];
                break;
            case "0000008":
                numTrimestre = _renderMAPRO.dtMAPRO8Trimestral_Resumen.row($(obj).parents('tr')).data()["NRO_TRIMESTRE"];
                break;
            case "0000009":
                numTrimestre = _renderMAPRO.dtMAPRO9Trimestral_Resumen.row($(obj).parents('tr')).data()["NRO_TRIMESTRE"];
                break;
            case "0000010":
                numTrimestre = _renderMAPRO.dtMAPRO10Trimestral_Resumen.row($(obj).parents('tr')).data()["NRO_TRIMESTRE"];
                break;
        }
    }

    if (_renderMAPRO.filterValidate()) {
        switch (indicador) {
            case "0000001":
                _renderMAPRO.dtMAPRO1Trimestral_Detalle.clear().draw();
                break;
            case "0000002":
                _renderMAPRO.dtMAPRO2Trimestral_Detalle.clear().draw();
                break;
            case "0000003":
                _renderMAPRO.dtMAPRO3Trimestral_Detalle.clear().draw();
                break;
            case "0000004":
                _renderMAPRO.dtMAPRO4Trimestral_Detalle.clear().draw();
                break;
            case "0000005":
                _renderMAPRO.dtMAPRO5Trimestral_Detalle.clear().draw();
                break;
            case "0000006":
                _renderMAPRO.dtMAPRO6Trimestral_Detalle.clear().draw();
                break;
            case "0000007":
                _renderMAPRO.dtMAPRO7Trimestral_Detalle.clear().draw();
                break;
            case "0000008":
                _renderMAPRO.dtMAPRO8Trimestral_Detalle.clear().draw();
                break;
            case "0000009":
                _renderMAPRO.dtMAPRO9Trimestral_Detalle.clear().draw();
                break;
            case "0000010":
                _renderMAPRO.dtMAPRO10Trimestral_Detalle.clear().draw();
                break;
        }
        
        var datosReporte = _renderMAPRO.frm.serializeObject();
        datosReporte.idTab = Indicador.frm.find("#idTab").val();
        datosReporte.tipo = "LISTA";
        datosReporte.numero = numTrimestre;

        var option = { url: _renderMAPRO.frm.attr("action"), datos: JSON.stringify(datosReporte), type: 'POST' };
        utilSigo.fnAjax(option, function (data) {
            if (data.success) {
                switch (indicador) {
                    case "0000001":
                        _renderMAPRO.dtMAPRO1Trimestral_Detalle.rows.add(data.data).draw();
                        break;
                    case "0000002":
                        _renderMAPRO.dtMAPRO2Trimestral_Detalle.rows.add(data.data).draw();
                        break;
                    case "0000003":
                        _renderMAPRO.dtMAPRO3Trimestral_Detalle.rows.add(data.data).draw();
                        break;
                    case "0000004":
                        _renderMAPRO.dtMAPRO4Trimestral_Detalle.rows.add(data.data).draw();
                        break;
                    case "0000005":
                        for (var i = 0; i < data.data.length; i++) {
                            data.data[i]["DIR_COINCIDE_DTITULAR"] = (data.data[i]["DIR_COINCIDE_DTITULAR"] == "1") ? "SI" : "NO";
                        }

                        _renderMAPRO.dtMAPRO5Trimestral_Detalle.rows.add(data.data).draw();

                        break;
                    case "0000006":
                        _renderMAPRO.dtMAPRO6Trimestral_Detalle.rows.add(data.data).draw();
                        break;
                    case "0000007":
                        for (var i = 0; i < data.data.length; i++) {
                            data.data[i]["FECHA_INICIO"] = data.data[i]["FECHA_INICIO"] + " - " + data.data[i]["FECHA_FIN"];
                        }
                        _renderMAPRO.dtMAPRO7Trimestral_Detalle.rows.add(data.data).draw();
                        break;
                    case "0000008":
                        _renderMAPRO.dtMAPRO8Trimestral_Detalle.rows.add(data.data).draw();
                        break;
                    case "0000009":
                        _renderMAPRO.dtMAPRO9Trimestral_Detalle.rows.add(data.data).draw();
                        break;
                    case "0000010":
                        _renderMAPRO.dtMAPRO10Trimestral_Detalle.rows.add(data.data).draw();
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

/*Reporte 1: M1.1 PORCENTAJE DE PLANES DE MANEJO CON CONTROL DE CALIDAD CONFORME*/
_renderMAPRO.fnInitDatosRpt1 = function () {
    var columns_label = [], columns_data = [], columns_event = [], options = {};

    columns_label = ["Trimestre", "Número de Planes de manejo registrados en el SIGO – SFC", "Número Planes de manejo con control de calidad conforme", "Indicador (%)"];
    columns_event = ["fn(c2)", "", "", ""];
    columns_data = ["DESCRIPCION", "TOTAL", "PARTE", "PORCENTAJE"];
    options = {
        button_excel: true, export_title: $("#tbMAPRO1Trimestral_Resumen").find("thead tr")[0].innerText.trim(), row_index: true
    };
    _renderMAPRO.dtMAPRO1Trimestral_Resumen = utilDt.fnLoadDataTable_EventColumn($("#tbMAPRO1Trimestral_Resumen"), columns_label, columns_data, columns_event, options);

    columns_label = ["Mes", "Nro. Plan de Manejo", "Fecha de Inicio y término de vigencia", "Fecha de Registro de Sigo", "Titular", "Título", "Modalidad"
        , "Con control de Calidad Conforme", "Estado del documento", "Fecha registro control de calidad"];
    columns_data = ["MES_NOMBRE", "NOMBRE", "FECHA", "FECHA_SIGO", "TITULAR", "TITULO", "NUMERO", "CONTROL_CALIDAD", "ESTADO_DOC", "FECHA_CCA"];
    options = {
        button_excel: true, export_title: $("#tbMAPRO1Trimestral_Detalle").find("thead tr")[0].innerText.trim(), page_length: 20,
        row_index: true, page_sort: true, page_info: true
    };
    _renderMAPRO.dtMAPRO1Trimestral_Detalle = utilDt.fnLoadDataTable_Detail($("#tbMAPRO1Trimestral_Detalle"), columns_label, columns_data, options);
}

_renderMAPRO.fnLimpiarRpt1 = function () {
    _renderMAPRO.dtMAPRO1Trimestral_Resumen.clear().draw();
    _renderMAPRO.dtMAPRO1Trimestral_Detalle.clear().draw();

    var tb = $("#tbMAPRO1Trimestral_Resumen");
    tb.find("#col3").text(0); tb.find("#col4").text(0); tb.find("#col5").text(0);

    if (_renderMAPRO.chartMAPRO1Trimestral_Resumen != null) {
        _renderMAPRO.chartMAPRO1Trimestral_Resumen.destroy();
    }
}
/******************Fin Reporte 1*******************/

/*Reporte 2: M1.2-2 PORCENTAJE DE TÍTULOS HABILITANTES SUPERVISADOS SEGÚN PASPEQ*/
_renderMAPRO.fnInitDatosRpt2 = function () {
    var columns_label = [], columns_data = [], columns_event = [], options = {};

    columns_label = ["Trimestre", "Número de Títulos Habilitantes planificados según PASPEQ", "Número de Títulos Habilitantes supervisados", "Indicador (%)"];
    columns_event = ["fn(c2)", "", "", ""];
    columns_data = ["DESCRIPCION", "TOTAL", "PARTE", "PORCENTAJE"];
    options = {
        button_excel: true, export_title: $("#tbMAPRO2Trimestral_Resumen").find("thead tr")[0].innerText.trim(), row_index: true
    };
    _renderMAPRO.dtMAPRO2Trimestral_Resumen = utilDt.fnLoadDataTable_EventColumn($("#tbMAPRO2Trimestral_Resumen"), columns_label, columns_data, columns_event, options);

    columns_label = ["Año del Informe", "Mes de Supervisión", "Sub Dirección de Línea", "Tipo de Supervisión"
        , "Paspeq", "Oficina Desconcentrada", "Modalidad", "Título Habilitante", "Titular", "Informe"
        , "Fecha de Emisión"];
    columns_data = ["ANIO_INFORME", "MES_SUPERVISION", "DLINEA", "TIPO_INFORME", "PASPEQ", "OD_AMBITO_TH", "MTIPO"
        , "NUM_THABILITANTE", "TITULAR", "NUM_INFORME", "FECEMI_INFORME"];
    options = {
        button_excel: true, export_title: $("#tbMAPRO2Trimestral_Detalle").find("thead tr")[0].innerText.trim(), page_length: 20,
        row_index: true, page_sort: true, page_info: true
    };
    _renderMAPRO.dtMAPRO2Trimestral_Detalle = utilDt.fnLoadDataTable_Detail($("#tbMAPRO2Trimestral_Detalle"), columns_label, columns_data, options);
}

_renderMAPRO.fnLimpiarRpt2 = function () {
    _renderMAPRO.dtMAPRO2Trimestral_Resumen.clear().draw();
    _renderMAPRO.dtMAPRO2Trimestral_Detalle.clear().draw();

    var tb = $("#tbMAPRO2Trimestral_Resumen");
    tb.find("#col3").text(0); tb.find("#col4").text(0); tb.find("#col5").text(0);

    if (_renderMAPRO.chartMAPRO2Trimestral_Resumen != null) {
        _renderMAPRO.chartMAPRO2Trimestral_Resumen.destroy();
    }
}
/******************Fin Reporte 2*******************/

/*Reporte 3: M1.2-4 PORCENTAJE DE TÍTULOS HABILITANTES AUDITADOS SEGÚN POI*/
_renderMAPRO.fnInitDatosRpt3 = function () {
    var columns_label = [], columns_data = [], columns_event = [], options = {};

    columns_label = ["Trimestre", "Número de TH programados para auditoria", "Número de Títulos Habilitantes Auditados", "Indicador (%)"];
    columns_event = ["fn(c2)", "", "", ""];
    columns_data = ["DESCRIPCION", "TOTAL", "PARTE", "PORCENTAJE"];
    options = {
        button_excel: true, export_title: $("#tbMAPRO3Trimestral_Resumen").find("thead tr")[0].innerText.trim(), row_index: true
    };
    _renderMAPRO.dtMAPRO3Trimestral_Resumen = utilDt.fnLoadDataTable_EventColumn($("#tbMAPRO3Trimestral_Resumen"), columns_label, columns_data, columns_event, options);

    columns_label = ["Año de Informe", "Mes de Auditoria", "Sub Dirección de Línea", "Título Habilitante", "Informe", "Fecha Inicio Auditoria", "Fecha Fin de Auditoria"
        , "Quinquenio 1 - Pasa Auditoria", "Quinquenio 2 - Pasa Auditoria", "Quinquenio 3 - Pasa Auditoria", "Quinquenio 4 - Pasa Auditoria", "Quinquenio 5 - Pasa Auditoria"
        , "Quinquenio 6 - Pasa Auditoria", "Quinquenio 7 - Pasa Auditoria", "Quinquenio 8 - Pasa Auditoria", "Área Otorgada"];
    columns_data = ["ANIO", "MES", "DLINEA", "THBILITANTE", "INFORME", "FECHA_INICIO_AUDITORIA", "FECHA_FIN_AUDITORIA"
        , "A1", "A2", "A3", "A4", "A5", "A6", "A7", "A8", "AREA"];
    options = {
        button_excel: true, export_title: $("#tbMAPRO3Trimestral_Detalle").find("thead tr")[0].innerText.trim(), page_length: 20,
        row_index: true, page_sort: true, page_info: true
    };
    _renderMAPRO.dtMAPRO3Trimestral_Detalle = utilDt.fnLoadDataTable_Detail($("#tbMAPRO3Trimestral_Detalle"), columns_label, columns_data, options);
}

_renderMAPRO.fnLimpiarRpt3 = function () {
    _renderMAPRO.dtMAPRO3Trimestral_Resumen.clear().draw();
    _renderMAPRO.dtMAPRO3Trimestral_Detalle.clear().draw();

    var tb = $("#tbMAPRO3Trimestral_Resumen");
    tb.find("#col3").text(0); tb.find("#col4").text(0); tb.find("#col5").text(0);

    if (_renderMAPRO.chartMAPRO3Trimestral_Resumen != null) {
        _renderMAPRO.chartMAPRO3Trimestral_Resumen.destroy();
    }
}
/******************Fin Reporte 3*******************/

/*Reporte 4: M.1.2 PORCENTAJE DE TÍTULOS HABILITANTES SUPERVISADOS SEGÚN POI*/
_renderMAPRO.fnInitDatosRpt4 = function () {
    var columns_label = [], columns_data = [], columns_event = [], options = {};

    columns_label = ["Trimestre", "Número de Títulos Habilitantes programados según POI", "Número de Títulos Habilitantes supervisados", "Indicador (%)"];
    columns_event = ["fn(c2)", "", "", ""];
    columns_data = ["DESCRIPCION", "TOTAL", "PARTE", "PORCENTAJE"];
    options = {
        button_excel: true, export_title: $("#tbMAPRO4Trimestral_Resumen").find("thead tr")[0].innerText.trim(), row_index: true
    };
    _renderMAPRO.dtMAPRO4Trimestral_Resumen = utilDt.fnLoadDataTable_EventColumn($("#tbMAPRO4Trimestral_Resumen"), columns_label, columns_data, columns_event, options);

    columns_label = ["Año del Informe", "Mes de Supervisión", "Sub Dirección de Línea", "Fecha Inicio Supervisión", "Fecha Fin Supervisión", "Motivo de la Supervisión", "ÁREA DEL PM"
        , "Cuenta con Incidente", "Tipo de Informe", "Oficina Desconcentrada", "Modalidad de Aprovechamiento", "Ubigeo del TH: Departamento", "Ubigeo del TH: Provincia"
        , "Ubigeo del TH: Distrito", "Título Habilitante", "Titular Actual", "Titular Sancionado", "Informe", "Tipo de Informe", "Fecha Emisión"
        /*, "Inf. Supervisión"*/, "Plan de Manejo Supervisado", "Tipo Plan de Manejo"];
    columns_data = ["ANIO_INFORME", "MES_NOMBRE", "DLINEA", "FECHA_SUPERVISION_INICIO", "FECHA_SUPERVISION_FIN", "MOTIVO_SUPERVISION", "AREA_TH"
        , "INCIDENTES", "TIPO_INFORME", "OD_AMBITO_TH", "MTIPO", "DEPARTAMENTO_TH", "PROVINCIA_TH"
        , "DISTRITO_TH", "NUM_THABILITANTE", "TITULAR", "TITULAR_SANCIONADO", "NUM_INFORME", "TIPO_INFORME", "FECEMI_INFORME"
        , "NOMBRE_POA", "TIPO_POA"];
    options = {
        button_excel: true, export_title: $("#tbMAPRO4Trimestral_Detalle").find("thead tr")[0].innerText.trim(), page_length: 20,
        row_index: true, page_sort: true, page_info: true
    };
    _renderMAPRO.dtMAPRO4Trimestral_Detalle = utilDt.fnLoadDataTable_Detail($("#tbMAPRO4Trimestral_Detalle"), columns_label, columns_data, options);
}

_renderMAPRO.fnLimpiarRpt4 = function () {
    _renderMAPRO.dtMAPRO4Trimestral_Resumen.clear().draw();
    _renderMAPRO.dtMAPRO4Trimestral_Detalle.clear().draw();

    var tb = $("#tbMAPRO4Trimestral_Resumen");
    tb.find("#col3").text(0); tb.find("#col4").text(0); tb.find("#col5").text(0);

    if (_renderMAPRO.chartMAPRO4Trimestral_Resumen != null) {
        _renderMAPRO.chartMAPRO4Trimestral_Resumen.destroy();
    }
}
/******************Fin Reporte 4*******************/

/*Reporte 5: M1.4-2 PORCENTAJE DE NOTIFICACIONES CORRECTAMENTE DILIGENCIADAS*/
_renderMAPRO.fnInitDatosRpt5 = function () {
    var columns_label = [], columns_data = [], columns_event = [], options = {};
        
    columns_label = ["Trimestre", "Número de Notificaciones emitidas", "Número de notificaciones entregadas correctamente", "Indicador (%)"];
    columns_event = ["fn(c2)", "", "", ""];
    columns_data = ["DESCRIPCION", "TOTAL", "PARTE", "PORCENTAJE"];
    options = {
        button_excel: true, export_title: $("#tbMAPRO5Trimestral_Resumen").find("thead tr")[0].innerText.trim(), row_index: true
    };
    _renderMAPRO.dtMAPRO5Trimestral_Resumen = utilDt.fnLoadDataTable_EventColumn($("#tbMAPRO5Trimestral_Resumen"), columns_label, columns_data, columns_event, options);

    columns_label = ["Fecha Registro", "Año Registro", "Mes Registro", "Carta Notificación", "Titular", "Notificador", "Tipo Carta"
        , "Usuario", "N° Informe Supervisión", "N° Informe de Auditoria", "Control de Calidad de Carta Notificación", "Tipo Supervisión"
        , "OD. Registro", "Fecha de Notificación", "¿Coincide con la Dirección del Título Habilitante?"];
    columns_data = ["FECHA", "ANIO_REGISTRO", "MES_REGISTRO", "NUMERO", "TITULAR", "PERSONA_NOTIFICADOR", "MAE_CNTIPO"
        ,"USUARIO", "INF_SUPERVISION", "INF_AUDITORIA", "CONTRO_CALIDAD", "TIPO_SUPERVISION", "OD", "FECHA_NOTIFICACION", "DIR_COINCIDE_DTITULAR"];
    options = {
        button_excel: true, export_title: $("#tbMAPRO5Trimestral_Detalle").find("thead tr")[0].innerText.trim(), page_length: 20,
        row_index: true, page_sort: true, page_info: true
    };
    _renderMAPRO.dtMAPRO5Trimestral_Detalle = utilDt.fnLoadDataTable_Detail($("#tbMAPRO5Trimestral_Detalle"), columns_label, columns_data, options);
}

_renderMAPRO.fnLimpiarRpt5 = function () {
    _renderMAPRO.dtMAPRO5Trimestral_Resumen.clear().draw();
    _renderMAPRO.dtMAPRO5Trimestral_Detalle.clear().draw();

    var tb = $("#tbMAPRO5Trimestral_Resumen");
    tb.find("#col3").text(0); tb.find("#col4").text(0); tb.find("#col5").text(0);

    if (_renderMAPRO.chartMAPRO5Trimestral_Resumen != null) {
        _renderMAPRO.chartMAPRO5Trimestral_Resumen.destroy();
    }
}
/******************Fin Reporte 5*******************/

/*Reporte 6: M1.4-2 PORCENTAJE DE NOTIFICACIONES CORRECTAMENTE DILIGENCIADAS*/
_renderMAPRO.fnInitDatosRpt6 = function () {
    var columns_label = [], columns_data = [], columns_event = [], options = {};

    columns_label = ["Trimestre", "Número de supervisiones programadas"
        , "Número de supervisiones con fondos por encargos entregados como mínimo 2 días antes de la supervisión", "Indicador (%)"];
    columns_event = ["fn(c2)", "", "", ""];
    columns_data = ["DESCRIPCION", "TOTAL", "PARTE", "PORCENTAJE"];
    options = {
        button_excel: true, export_title: $("#tbMAPRO6Trimestral_Resumen").find("thead tr")[0].innerText.trim(), row_index: true
    };
    _renderMAPRO.dtMAPRO6Trimestral_Resumen = utilDt.fnLoadDataTable_EventColumn($("#tbMAPRO6Trimestral_Resumen"), columns_label, columns_data, columns_event, options);

    columns_label = ["N°","Fecha Hora Registro", "Año Registro", "Mes Registro", "OD", "N° Notificación", "N° Título Habilitante", "Supervisor", "Supervisado"
        , "Tipo Informe", "Usuario", "Salida a Campo", "Recepción Cheque", "Cobro Cheque"];
    columns_data = ["SUPERVISION", "FECHA", "ANIO", "MES_REGISTRADO", "OD", "CARTA_NOTIFICACION", "NUM_THABILITANTE", "SUPERVISOR", "SUPERVISADO"
        , "TIPO_INFORME", "USUARIO", "SALIDA_CAMPO", "FECHA_RECEPCION_CHEQUE", "FECHA_COBRO_CHEQUE"];
    options = {
        button_excel: true, export_title: $("#tbMAPRO6Trimestral_Detalle").find("thead tr")[0].innerText.trim(), page_length: 20,
        page_sort: true, page_info: true
    };
    _renderMAPRO.dtMAPRO6Trimestral_Detalle = utilDt.fnLoadDataTable_Detail($("#tbMAPRO6Trimestral_Detalle"), columns_label, columns_data, options);
}

_renderMAPRO.fnLimpiarRpt6 = function () {
    _renderMAPRO.dtMAPRO6Trimestral_Resumen.clear().draw();
    _renderMAPRO.dtMAPRO6Trimestral_Detalle.clear().draw();

    var tb = $("#tbMAPRO6Trimestral_Resumen");
    tb.find("#col3").text(0); tb.find("#col4").text(0); tb.find("#col5").text(0);

    if (_renderMAPRO.chartMAPRO6Trimestral_Resumen != null) {
        _renderMAPRO.chartMAPRO6Trimestral_Resumen.destroy();
    }
}
/******************Fin Reporte 6*******************/

/*Reporte 7: M1.5.1-3 PROMEDIO DE SUPERVISIONES QUE CUMPLEN CON LA NORMATIVA*/
_renderMAPRO.fnInitDatosRpt7 = function () {
    var columns_label = [], columns_data = [], columns_event = [], options = {};

    columns_label = ["Trimestre", "Número de supervisiones ejecutadas"
        , "Número de supervisiones que cumplen con la normativa del proceso de supervisión en campo", "Indicador (Promedio)"];
    columns_event = ["fn(c2)", "", "", ""];
    columns_data = ["DESCRIPCION", "TOTAL", "PARTE", "PORCENTAJE"];
    options = {
        button_excel: true, export_title: $("#tbMAPRO7Trimestral_Resumen").find("thead tr")[0].innerText.trim(), row_index: true
    };
    _renderMAPRO.dtMAPRO7Trimestral_Resumen = utilDt.fnLoadDataTable_EventColumn($("#tbMAPRO7Trimestral_Resumen"), columns_label, columns_data, columns_event, options);

    columns_label = ["Año del Informe", "Informe de Supervisión", "Sub Dirección de Línea", "Oficina Desconcentrada", "Modalidad de Aprovechamiento"
        , "Ubigeo del TH: Departamento", "Ubigeo del TH: Provincia", "Ubigeo del TH: Distrito", "Título Habilitante", "Titular Actual"
        , "Informe mes de la supervisión", "Área supervisada en el PM", "Estado del Control de calidad", "Fecha Informe", "Fecha Emisión Inf. Supervisión"
        , "Observatorio OSINFOR"];
    columns_data = ["ANIO_INFORME", "NUMERO", "DLINEA", "OFI_DESCONCENTRADA", "MODALIDAD", "DEPARTAMENTO_TH", "PROVINCIA_TH", "DISTRITO_TH", "TITULO"
        , "TITULAR", "MES_SUPERVISION", "AREA_SUPERVISADA", "ESTADO_CONTROL_CALIDAD", "FECHA_INICIO", "FECHA_FIN", "OBSERVATORIO"];
    options = {
        button_excel: true, export_title: $("#tbMAPRO7Trimestral_Detalle").find("thead tr")[0].innerText.trim(), page_length: 20,
        row_index: true, page_sort: true, page_info: true
    };
    _renderMAPRO.dtMAPRO7Trimestral_Detalle = utilDt.fnLoadDataTable_Detail($("#tbMAPRO7Trimestral_Detalle"), columns_label, columns_data, options);
}

_renderMAPRO.fnLimpiarRpt7 = function () {
    _renderMAPRO.dtMAPRO7Trimestral_Resumen.clear().draw();
    _renderMAPRO.dtMAPRO7Trimestral_Detalle.clear().draw();

    var tb = $("#tbMAPRO7Trimestral_Resumen");
    tb.find("#col3").text(0); tb.find("#col4").text(0); tb.find("#col5").text(0);

    if (_renderMAPRO.chartMAPRO7Trimestral_Resumen != null) {
        _renderMAPRO.chartMAPRO7Trimestral_Resumen.destroy();
    }
}
/******************Fin Reporte 7*******************/

/*Reporte 8: M1.5.1 PROMEDIO DE DÍAS PARA LA EJECUCIÓN DE LA SUPERVISIÓN*/
_renderMAPRO.fnInitDatosRpt8 = function () {
    var columns_label = [], columns_data = [], columns_event = [], options = {};

    columns_label = ["Trimestre", "Número de supervisiones realizadas", "Sumatoria Días", "Indicador (Promedio de Días)"];
    columns_event = ["fn(c2)", "", "", ""];
    columns_data = ["DESCRIPCION", "TOTAL", "PARTE", "PORCENTAJE"];
    options = {
        button_excel: true, export_title: $("#tbMAPRO8Trimestral_Resumen").find("thead tr")[0].innerText.trim(), row_index: true
    };
    _renderMAPRO.dtMAPRO8Trimestral_Resumen = utilDt.fnLoadDataTable_EventColumn($("#tbMAPRO8Trimestral_Resumen"), columns_label, columns_data, columns_event, options);

    columns_label = ["Fecha de entrega del informe al administrado", "Fecha de salida a campo", "Mes", "Titular", "Título", "Modalidad", "Supervisor", "N° Informe"
        , "Fecha de Supervisión", "Fecha de emisión", "Fecha registro SIGO", "Con Control de Calidad Conforme", "Fecha registro Control de calidad"
        , "Estado del Documento", "Informe de supervisión digitalizado", "Fecha de remisión a la DFFFS"];
    columns_data = ["FECHA_NOTIFICACION_TITULAR", "FECHA_SALIDA_CAMPO", "MES_NOMBRE", "TITULAR", "TITULO", "TIPO", "SUPERVISOR", "NUMERO", "FECHA_INICIO", "FECHA_ENTREGA"
        , "FECHA_SIGO", "CONTROL_CALIDAD", "FECHA_CCA", "ESTADO_DOC", "DIGITALIZADO", "FECHA_DERIVACION"];
    options = {
        button_excel: true, export_title: $("#tbMAPRO8Trimestral_Detalle").find("thead tr")[0].innerText.trim(), page_length: 20,
        row_index: true, page_sort: true, page_info: true
    };
    _renderMAPRO.dtMAPRO8Trimestral_Detalle = utilDt.fnLoadDataTable_Detail($("#tbMAPRO8Trimestral_Detalle"), columns_label, columns_data, options);
}
    
_renderMAPRO.fnLimpiarRpt8 = function () {
    _renderMAPRO.dtMAPRO8Trimestral_Resumen.clear().draw();
    _renderMAPRO.dtMAPRO8Trimestral_Detalle.clear().draw();

    var tb = $("#tbMAPRO8Trimestral_Resumen");
    tb.find("#col3").text(0); tb.find("#col4").text(0); tb.find("#col5").text(0);

    if (_renderMAPRO.chartMAPRO8Trimestral_Resumen != null) {
        _renderMAPRO.chartMAPRO8Trimestral_Resumen.destroy();
    }
}
/******************Fin Reporte 8*******************/

/*Reporte 9: M1.5.2-3 PORCENTAJE DE AUDITORÍAS QUE CUMPLEN CON LA NORMATIVA*/
_renderMAPRO.fnInitDatosRpt9 = function () {
    var columns_label = [], columns_data = [], columns_event = [], options = {};

    columns_label = ["Trimestre", "Numero de auditorías ejecutadas", "Número de auditorías que cumplen con la normativa del proceso de auditoria ", "Indicador (%)"];
    columns_event = ["fn(c2)", "", "", ""];
    columns_data = ["DESCRIPCION", "TOTAL", "PARTE", "PORCENTAJE"];
    options = {
        button_excel: true, export_title: $("#tbMAPRO9Trimestral_Resumen").find("thead tr")[0].innerText.trim(), row_index: true
    };
    _renderMAPRO.dtMAPRO9Trimestral_Resumen = utilDt.fnLoadDataTable_EventColumn($("#tbMAPRO9Trimestral_Resumen"), columns_label, columns_data, columns_event, options);

    columns_label = ["Año de Informe", "Mes de Auditoria", "Sub Dirección de Línea", "Oficina Desconcentrada", "Modalidad de Aprovechamiento"
        , "Ubigeo del TH: Departamento", "Ubigeo del TH: Provincia", "Ubigeo del TH: Distrito", "Título Habilitante"
        , "Titular Actual", "N° de Informe de auditoría", "Área supervisada en el PM", "Estado del Control de calidad"
        , "Fecha Informe (Fecha Ini auditoria)", "Fecha Emisión Inf. Auditoria", "Observatorio OSINFOR", "Quinquenio 1 - Pasa Auditoria"
        , "Quinquenio 2 - Pasa Auditoria", "Quinquenio 3 - Pasa Auditoria", "Quinquenio 4 - Pasa Auditoria", "Quinquenio 5 - Pasa Auditoria"
        , "Quinquenio 6 - Pasa Auditoria", "Quinquenio 7 - Pasa Auditoria", "Quinquenio 8 - Pasa Auditoria", "Quinquenio 1 - Amplia Vigencia"
        , "Quinquenio 2 - Amplia Vigencia", "Quinquenio 3 - Amplia Vigencia", "Quinquenio 4 - Amplia Vigencia", "Quinquenio 5 - Amplia Vigencia"
        , "Quinquenio 6 - Amplia Vigencia", "Quinquenio 7 - Amplia Vigencia", "Quinquenio 8 - Amplia Vigencia"];
    columns_data = ["ANIO", "MES_NOMBRE", "DLINEA", "OD_AMBITO_TH", "MTIPO", "DEPARTAMENTO_TH", "PROVINCIA_TH", "DISTRITO_TH"
        , "NUM_THABILITANTE", "TITULAR", "NUM_INFORME", "AREA_TH", "ESTADO_CONTROL_CALIDAD", "FECHA_INFORME", "FECEMI_INFORME"
        , "OBSERVATORIO_OSINFOR", "A1", "A2", "A3", "A4", "A5", "A6", "A7", "A8", "AP1", "AP2", "AP3", "AP4", "AP5", "AP6", "AP7", "AP8"];
    options = {
        button_excel: true, export_title: $("#tbMAPRO9Trimestral_Detalle").find("thead tr")[0].innerText.trim(), page_length: 20,
        row_index: true, page_sort: true, page_info: true
    };
    _renderMAPRO.dtMAPRO9Trimestral_Detalle = utilDt.fnLoadDataTable_Detail($("#tbMAPRO9Trimestral_Detalle"), columns_label, columns_data, options);
}

_renderMAPRO.fnLimpiarRpt9 = function () {
    _renderMAPRO.dtMAPRO9Trimestral_Resumen.clear().draw();
    _renderMAPRO.dtMAPRO9Trimestral_Detalle.clear().draw();

    var tb = $("#tbMAPRO9Trimestral_Resumen");
    tb.find("#col3").text(0); tb.find("#col4").text(0); tb.find("#col5").text(0);

    if (_renderMAPRO.chartMAPRO9Trimestral_Resumen != null) {
        _renderMAPRO.chartMAPRO9Trimestral_Resumen.destroy();
    }
}
/******************Fin Reporte 9*******************/

/*Reporte 10: M1.5.2 PROMEDIO DE DÍAS DEL PROCESO DE AUDITORÍA*/
_renderMAPRO.fnInitDatosRpt10 = function () {
    var columns_label = [], columns_data = [], columns_event = [], options = {};

    columns_label = ["Trimestre", "Total de auditorías realizadas", "Sumatoria Días", "Indicador (Promedio de Días)"];
    columns_event = ["fn(c2)", "", "", ""];
    columns_data = ["DESCRIPCION", "TOTAL", "PARTE", "PORCENTAJE"];
    options = {
        button_excel: true, export_title: $("#tbMAPRO10Trimestral_Resumen").find("thead tr")[0].innerText.trim(), row_index: true
    };
    _renderMAPRO.dtMAPRO10Trimestral_Resumen = utilDt.fnLoadDataTable_EventColumn($("#tbMAPRO10Trimestral_Resumen"), columns_label, columns_data, columns_event, options);

    columns_label = ["Fecha de entrega del informe de auditoría al administrado", "Fecha de fin del proceso de auditoria", "Fecha de inicio	Mes"
        , "Titular", "Título", "Modalidad", "Auditor", "N° Informe", "Fecha registro SIGO", "Con Control de Calidad Conforme", "Fecha registro Control de calidad"];
    columns_data = ["FECHA_ENTREGA", "FECHA_FIN", "FECHA_INICIO", "TITULAR", "TITULO", "TIPO", "SUPERVISOR", "NUMERO"
        , "FECHA_SIGO", "CONTROL_CALIDAD", "FECHA_CCA"];
    options = {
        button_excel: true, export_title: $("#tbMAPRO10Trimestral_Detalle").find("thead tr")[0].innerText.trim(), page_length: 20,
        row_index: true, page_sort: true, page_info: true
    };
    _renderMAPRO.dtMAPRO10Trimestral_Detalle = utilDt.fnLoadDataTable_Detail($("#tbMAPRO10Trimestral_Detalle"), columns_label, columns_data, options);
}

_renderMAPRO.fnLimpiarRpt10 = function () {
    _renderMAPRO.dtMAPRO10Trimestral_Resumen.clear().draw();
    _renderMAPRO.dtMAPRO10Trimestral_Detalle.clear().draw();

    var tb = $("#tbMAPRO10Trimestral_Resumen");
    tb.find("#col3").text(0); tb.find("#col4").text(0); tb.find("#col5").text(0);

    if (_renderMAPRO.chartMAPRO10Trimestral_Resumen != null) {
        _renderMAPRO.chartMAPRO10Trimestral_Resumen.destroy();
    }
}
/******************Fin Reporte 10*******************/

$(document).ready(function () {
    _renderMAPRO.frm = $("#frmFiltroMAPRO");

    _renderMAPRO.fnInitFiltro();
    _renderMAPRO.fnInitDatosRpt1();
    _renderMAPRO.fnInitDatosRpt2();
    _renderMAPRO.fnInitDatosRpt3();
    _renderMAPRO.fnInitDatosRpt4();
    _renderMAPRO.fnInitDatosRpt5();
    _renderMAPRO.fnInitDatosRpt6();
    _renderMAPRO.fnInitDatosRpt7();
    _renderMAPRO.fnInitDatosRpt8();
    _renderMAPRO.fnInitDatosRpt9();
    _renderMAPRO.fnInitDatosRpt10();
});