'use strict';

var customChart = {};

customChart.colors = {
    red: 'rgb(255, 99, 132)',
    orange: 'rgb(255, 159, 64)',
    yellow: 'rgb(255, 205, 86)',
    green: 'rgb(75, 192, 192)',
    blue: 'rgb(54, 162, 235)',
    purple: 'rgb(153, 102, 255)',
    grey: 'rgb(201, 203, 207)'
};
customChart.chartColors = {
    red: Chart.helpers.color(customChart.colors.red).alpha(0.5).rgbString(),
    orange: Chart.helpers.color(customChart.colors.orange).alpha(0.5).rgbString(),
    yellow: Chart.helpers.color(customChart.colors.yellow).alpha(0.5).rgbString(),
    green: Chart.helpers.color(customChart.colors.green).alpha(0.5).rgbString(),
    blue: Chart.helpers.color(customChart.colors.blue).alpha(0.5).rgbString(),
    purple: Chart.helpers.color(customChart.colors.purple).alpha(0.5).rgbString(),
    grey: Chart.helpers.color(customChart.colors.grey).alpha(0.5).rgbString()
};

/*
    Mostrar Gráfico de Barras cuya fuente de datos es un DataTable, con una línea de meta propuesta
    Params:
        - dt                : DataTable
        - horizontalData    : Opción sobre el cual se realiza la comparación | value: 'DATA'
        - verticalData      : Datos a comparar  {colIndex:[1,3,5],data:['DATA_1','DATA_3','DATA_5'],color:['red','green','purple']}
        - options           : Opciones para personalizar y/o configurar el gráfico de barras
            options.type    : Tipo de orientación | value: 'H':Horizontal, 'V': Vertical
            options.title   : Título de gráfico de barras
            options.canvas  : Contenedor del gráfico
        - meta              : Línea de meta propuesta
            meta.data       : Elementos del gráfico
            meta.color      : Color de la línea
            meta.title      : Título del gráfico
*/

customChart.LoadBarraSimple_DataTable = function (dt, horizontalData, verticalData, options) {
    var rows, countFilas, data, labels = [], datasets = [], type = "";

    if (typeof options.type === 'undefined' || options.type == 'V') {
        type = "bar";
    } else if (options.type == 'H') {
        type = "horizontalBar";
    }

    rows = dt.$("tr");
    countFilas = rows.length;
    if (countFilas > 0) {
        //Obtener los valores de la parte horizontal
        $.each(rows, function (i, o) {
            data = dt.row($(o)).data();
            labels.push(data[horizontalData]);
        });
        //Obtener los valores de la parte vertical
        for (var j = 0; j < verticalData.data.length; j++) {
            var ds = {};
            ds.label = dt.table().header().childNodes[dt.table().header().childNodes.length - 1].childNodes[verticalData.colIndex[j]].innerText;
            ds.backgroundColor = customChart.chartColors[verticalData.color[j]];
            ds.borderColor = customChart.colors[verticalData.color[j]];
            ds.borderWidth = 1;
            ds.data = [];

            $.each(rows, function (i, o) {
                data = dt.row($(o)).data();
                ds.data.push(data[verticalData.data[j]]);
            });

            datasets.push(ds);
        }

        //Contruir el Gráfico de Barras
        var ctx = document.getElementById(options.canvas).getContext('2d');
        return new Chart(ctx, {
            type: type,
            data: {
                labels: labels, datasets: datasets
            },
            options: {
                responsive: true,
                legend: {
                    position: 'top'
                },
                title: {
                    display: true,
                    text: options.title
                },
                scales: {
                    yAxes: [{
                        ticks: {
                            beginAtZero: true
                        }
                    }]
                }
            }
        });
    }
}

customChart.LoadBarraMixedMeta_DataTable = function (dt, horizontalData, verticalData, options, meta) {
    var rows, countFilas, data, labels = [], datasets = [], type = "";

    if (typeof options.type === 'undefined' || options.type == 'V') {
        type = "bar";
    } else if (options.type == 'H') {
        type = "horizontalBar";
    }

    rows = dt.$("tr");
    countFilas = rows.length;
    if (countFilas > 0) {
        //Obtener los valores de la parte horizontal
        $.each(rows, function (i, o) {
            data = dt.row($(o)).data();
            labels.push(data[horizontalData]);
        });
        //Obtener los valores de la parte vertical
        for (var j = 0; j < verticalData.data.length; j++) {
            var ds = {};
            ds.label = dt.table().header().childNodes[dt.table().header().childNodes.length - 1].childNodes[verticalData.colIndex[j]].innerText;
            ds.backgroundColor = customChart.chartColors[verticalData.color[j]];
            ds.borderColor = customChart.colors[verticalData.color[j]];
            ds.borderWidth = 1;
            ds.data = [];

            $.each(rows, function (i, o) {
                data = dt.row($(o)).data();
                ds.data.push(data[verticalData.data[j]]);
            });

            datasets.push(ds);
        }

        datasets.push({
            label: meta.title,
            type: "line",
            borderColor: meta.color,
            data: meta.data,
            fill: false
        });

        //Contruir el Gráfico
        var ctx = document.getElementById(options.canvas).getContext('2d');
        return new Chart(ctx, {
            type: type,
            data: {
                labels: labels, datasets: datasets
            },
            options: {
                responsive: true,
                legend: {
                    position: 'top'
                },
                title: {
                    display: true,
                    text: options.title
                },
                scales: {
                    yAxes: [{
                        ticks: {
                            beginAtZero: true
                        }
                    }]
                }
            }
        });
    }
}

customChart.LoadBarraHorizontal_DataTable = function (dt, horizontalData1, horizontalData2, verticalData, options) {
    var rows, countFilas, data, labels = [], datasets = [], type = "";
    var countEnero = 0, countFebrero = 0, countMarzo = 0, countAbril = 0, countMayo = 0, countJunio = 0;
    var countJulio = 0, countAgosto = 0, countSeptiembre = 0, countOctubre = 0, countNoviembre = 0, countDiciembre = 0;
    var posEnero = 0, posFebrero = 0, posMarzo = 0, posAbril = 0, posMayo = 0, posJunio = 0;
    var posJulio = 0, posAgosto = 0, posSeptiembre = 0, posOctubre = 0, posNoviembre = 0, posDiciembre = 0;

    if (typeof options.type === 'undefined' || options.type == 'V') {
        type = "bar";
    } else if (options.type == 'H') {
        type = "horizontalBar";
    }

    rows = dt.$("tr");
    countFilas = rows.length;
    if (countFilas > 0) {
        //Obtener los valores de la parte horizontal
        $.each(rows, function (i, o) {
            data = dt.row($(o)).data();
            labels.push(data[horizontalData1] + ";" + data[horizontalData2]);
            if (data[horizontalData2] == "ENERO") countEnero++;
            else if (data[horizontalData2] == "FEBRERO") countFebrero++;
            else if (data[horizontalData2] == "MARZO") countMarzo++;
            else if (data[horizontalData2] == "ABRIL") countAbril++;
            else if (data[horizontalData2] == "MAYO") countMayo++;
            else if (data[horizontalData2] == "JUNIO") countJunio++;
            else if (data[horizontalData2] == "JULIO") countJulio++;
            else if (data[horizontalData2] == "AGOSTO") countAgosto++;
            else if (data[horizontalData2] == "SEPTIEMBRE") countSeptiembre++;
            else if (data[horizontalData2] == "OCTUBRE") countOctubre++;
            else if (data[horizontalData2] == "NOVIEMBRE") countNoviembre++;
            else if (data[horizontalData2] == "DICIEMBRE") countDiciembre++;
        });

        posEnero = Math.round(countEnero / 2);
        posFebrero = Math.round(countFebrero / 2);
        posMarzo = Math.round(countMarzo / 2);
        posAbril = Math.round(countAbril / 2);
        posMayo = Math.round(countMayo / 2);
        posJunio = Math.round(countJunio / 2);
        posJulio = Math.round(countJulio / 2);
        posAgosto = Math.round(countAgosto / 2);
        posSeptiembre = Math.round(countSeptiembre / 2);
        posOctubre = Math.round(countOctubre / 2);
        posNoviembre = Math.round(countNoviembre / 2);
        posDiciembre = Math.round(countDiciembre / 2);
        countEnero = countFebrero = countMarzo = countAbril = countMayo = countJunio = 0;
        countJulio = countAgosto = countSeptiembre = countOctubre = countNoviembre = countDiciembre = 0;

        var intersectaEnero, intersectaFebrero, intersectaMarzo, intersectaAbril, intersectaMayo, intersectaJunio;
        var intersectaJulio, intersectaAgosto, intersectaSeptiembre, intersectaOctubre, intersectaNoviembre, intersectaDiciembre;

        $.each(rows, function (i, o) {
            data = dt.row($(o)).data();
            if (data[horizontalData2] == "ENERO") {
                countEnero++;
                if (countEnero == posEnero) {
                    intersectaEnero = data[horizontalData1];
                }
            }
            else if (data[horizontalData2] == "FEBRERO") {
                countFebrero++;
                if (countFebrero == posFebrero) {
                    intersectaFebrero = data[horizontalData1];
                }
            }
            else if (data[horizontalData2] == "MARZO") {
                countMarzo++;
                if (countMarzo == posMarzo) {
                    intersectaMarzo = data[horizontalData1];
                }
            }
            else if (data[horizontalData2] == "ABRIL") {
                countAbril++;
                if (countAbril == posAbril) {
                    intersectaAbril = data[horizontalData1];
                }
            }
            else if (data[horizontalData2] == "MAYO") {
                countMayo++;
                if (countMayo == posMayo) {
                    intersectaMayo = data[horizontalData1];
                }
            }
            else if (data[horizontalData2] == "JUNIO") {
                countJunio++;
                if (countJunio == posJunio) {
                    intersectaJunio = data[horizontalData1];
                }
            }
            else if (data[horizontalData2] == "JULIO") {
                countJulio++;
                if (countJulio == posJulio) {
                    intersectaJulio = data[horizontalData1];
                }
            }
            else if (data[horizontalData2] == "AGOSTO") {
                countAgosto++;
                if (countAgosto == posAgosto) {
                    intersectaAgosto = data[horizontalData1];
                }
            }
            else if (data[horizontalData2] == "SEPTIEMBRE") {
                countSeptiembre++;
                if (countSeptiembre == posSeptiembre) {
                    intersectaSeptiembre = data[horizontalData1];
                }
            }
            else if (data[horizontalData2] == "OCTUBRE") {
                countOctubre++;
                if (countOctubre == posOctubre) {
                    intersectaOctubre = data[horizontalData1];
                }
            }
            else if (data[horizontalData2] == "NOVIEMBRE") {
                countNoviembre++;
                if (countNoviembre == posNoviembre) {
                    intersectaNoviembre = data[horizontalData1];
                }
            }
            else if (data[horizontalData2] == "DICIEMBRE") {
                countDiciembre++;
                if (countDiciembre == posDiciembre) {
                    intersectaDiciembre = data[horizontalData1];
                }
            }
        });
        
        //Obtener los valores de la parte vertical
        for (var j = 0; j < verticalData.data.length; j++) {
            var ds = {};
            ds.label = dt.table().header().childNodes[dt.table().header().childNodes.length - 1].childNodes[verticalData.colIndex[j]].innerText;
            ds.backgroundColor = customChart.chartColors[verticalData.color[j]];
            ds.borderColor = customChart.colors[verticalData.color[j]];
            ds.borderWidth = 1;
            ds.data = [];

            $.each(rows, function (i, o) {
                data = dt.row($(o)).data();
                ds.data.push(data[verticalData.data[j]]);
            });

            datasets.push(ds);
        }

        //Contruir el Gráfico de Barras
        var ctx = document.getElementById(options.canvas);
        return new Chart(ctx, {
            type: type,
            data: {
                labels: labels, datasets: datasets
            },
            options: {
                responsive: true,
                legend: {
                    position: 'top'
                },
                title: {
                    display: true,
                    text: options.title
                },
                scales: {
                    xAxes: [{
                        id: 'xAxis1',
                        type: "category",
                        ticks: {
                            callback: function (label) {
                                var modalidad = label.split(";")[0];
                                return modalidad;
                            }
                        }
                    },
                    {
                        id: 'xAxis2',
                        type: "category",
                        gridLines: {
                            drawOnChartArea: false
                        },
                        ticks: {
                            callback: function (label) {
                                var modalidad = label.split(";")[0];
                                var mes = label.split(";")[1];
                                var valor = "";

                                if (mes == "ENERO") {
                                    if (modalidad == intersectaEnero)
                                        valor = mes;
                                    else valor = "";
                                }
                                else if (mes == "FEBRERO") {
                                    if (modalidad == intersectaFebrero)
                                        valor = mes;
                                    else valor = "";
                                }
                                else if (mes == "MARZO") {
                                    if (modalidad == intersectaMarzo)
                                        valor = mes;
                                    else valor = "";
                                }
                                else if (mes == "ABRIL") {
                                    if (modalidad == intersectaAbril)
                                        valor = mes;
                                    else valor = "";
                                }
                                else if (mes == "MAYO") {
                                    if (modalidad == intersectaMayo)
                                        valor = mes;
                                    else valor = "";
                                }
                                else if (mes == "JUNIO") {
                                    if (modalidad == intersectaJunio)
                                        valor = mes;
                                    else valor = "";
                                }
                                else if (mes == "JULIO") {
                                    if (modalidad == intersectaJulio)
                                        valor = mes;
                                    else valor = "";
                                }
                                else if (mes == "AGOSTO") {
                                    if (modalidad == intersectaAgosto)
                                        valor = mes;
                                    else valor = "";
                                }
                                else if (mes == "SEPTIEMBRE") {
                                    if (modalidad == intersectaSeptiembre)
                                        valor = mes;
                                    else valor = "";
                                }
                                else if (mes == "OCTUBRE") {
                                    if (modalidad == intersectaOctubre)
                                        valor = mes;
                                    else valor = "";
                                }
                                else if (mes == "NOVIEMBRE") {
                                    if (modalidad == intersectaNoviembre)
                                        valor = mes;
                                    else valor = "";
                                }
                                else if (mes == "DICIEMBRE") {
                                    if (modalidad == intersectaDiciembre)
                                        valor = mes;
                                    else valor = "";
                                }

                                return valor;

                            }
                        }
                    }],
                    yAxes: [{
                        ticks: {
                            beginAtZero: true
                        }
                    }]
                }
            }
        });
    }
}

