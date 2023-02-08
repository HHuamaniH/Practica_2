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
    Mostrar Gráfico de Barras cuya fuente de datos es un arreglo multidimencional
    Params:
        - data              : [][]
        - colIndexBase    : Columna sobre el cual se realiza la comparación | value: {0,1,2,3,...}
        - colsCompare      : Datos a comparar  {colIndex:[0,1,...],color:['red','green','purple'],legend:['Ley1','Ley2',...]}
        - options           : Opciones para personalizar y/o configurar el gráfico de barras
            options.type    : Tipo de orientación | value: 'H':Horizontal, 'V': Vertical
            options.title   : Título de gráfico de barras
            options.legend  : Mostrar leyenda {true,false}
            options.xTitle  : Mostrar título en el eje X
            options.yTitle  : Mostrar título en el eje Y
            options.canvas  : Contenedor del gráfico
*/
customChart.LoadBarraSimple = function (data, colIndexBase, colsCompare, options) {
    var type = "", labels = [], datasets = [];

    if (typeof options.type === 'undefined' || options.type == 'V') {
        type="bar"
    } else if (options.type == 'H') {
        type = "horizontalBar";
    }
    
    if (data.length > 0) {
        //Valores base en los que se realiza la comparación
        for (var i = 0; i < data.length; i++) {
            labels.push(data[i][colIndexBase]);
        }
        //Obtener totales
        var totalBar = new Array();
        //Valores a comparar
        for (var i = 0; i < colsCompare.colIndex.length; i++) {
            var ds = {};
            ds.label = colsCompare.legend[i];
            ds.backgroundColor = customChart.chartColors[colsCompare.color[i]];
            ds.borderColor = customChart.colors[colsCompare.color[i]];
            ds.borderWidth = 1;
            ds.data = [];
            var totalBarItem = 0;
            for (var j = 0; j < data.length; j++) {
                ds.data.push(data[j][colsCompare.colIndex[i]]);
                totalBarItem += parseFloat(data[j][colsCompare.colIndex[i]]);
            }
            datasets.push(ds);
            totalBar.push(totalBarItem);
        }

        if (typeof options.labels !== 'undefined' && options.labels == true) {
            // Define a plugin to provide data labels
            Chart.plugins.register({
                id: 'labels',
                afterDatasetsDraw: function (chart) {
                    var ctx = chart.ctx;

                    chart.data.datasets.forEach(function (dataset, i) {
                        var meta = chart.getDatasetMeta(i);
                        if (!meta.hidden) {
                            meta.data.forEach(function (element, index) {
                                // Draw the text in black, with the specified font
                                ctx.fillStyle = 'rgb(0, 0, 0)';
                                var fontSize = 12;
                                var fontStyle = 'normal';
                                var fontFamily = 'Helvetica Neue';
                                ctx.font = Chart.helpers.fontString(fontSize, fontStyle, fontFamily);

                                // Calcular el procentaje
                                var porcentaje = (parseFloat(dataset.data[index]) * 100) / totalBar[i];
                                // Just naively convert to string for now
                                var dataString = (Math.round(porcentaje * 100) / 100).toString() + "%";

                                // Make sure alignment settings are correct
                                ctx.textAlign = 'center';
                                ctx.textBaseline = 'top';

                                var padding = 5;
                                var position = element.tooltipPosition();
                                ctx.fillText(dataString, position.x-20, position.y- (fontSize / 2)/* - padding*/);
                            });
                        }
                    });
                }
            });
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
                    display: typeof options.legend == 'undefined' ? true : options.legend,
                    position: 'top',
                },
                title: {
                    display: (typeof options.title === 'undefined') || options.title == "" ? false : true,
                    text: options.title
                },
                scales: {
                    xAxes: [{
                        ticks: {
                            beginAtZero: true
                        },
                        scaleLabel: {
                            display: (typeof options.xTitle === 'undefined') || options.xTitle == "" ? false : true,
                            labelString: options.xTitle
                        }
                    }],
                    yAxes: [{
                        ticks: {
                            beginAtZero: true
                        },
                        scaleLabel: {
                            display: (typeof options.yTitle === 'undefined') || options.yTitle == "" ? false : true,
                            labelString: options.yTitle
                        }
                    }]
                }
            }
        });
    }
}

//Configuración básica, falta adecuar para casos complejor
customChart.LoadBarraApilada = function (data, colIndexBase, colsCompare, options) {
    var type = "", labels = [], datasets = [];

    if (typeof options.type === 'undefined' || options.type == 'V') {
        type = "bar"
    } else if (options.type == 'H') {
        type = "horizontalBar";
    }
    
    if (data.length > 0) {
        //Valores base en los que se realiza la comparación
        for (var i = 0; i < data.length; i++) {
            labels.push(data[i][colIndexBase]);
        }
        
        //Valores a comparar
        for (var i = 0; i < colsCompare.colIndex.length; i++) {
            var ds = {};
            ds.label = colsCompare.legend[i];
            ds.backgroundColor = customChart.chartColors[colsCompare.color[i]];
            ds.borderColor = customChart.colors[colsCompare.color[i]];
            ds.borderWidth = 1;
            ds.data = [];
            for (var j = 0; j < data.length; j++) {
                ds.data.push(data[j][colsCompare.colIndex[i]]);
            }
            datasets.push(ds);
        }

        //Obtener totales
        var totalBar = new Array();
        for (var i = 0; i < data.length; i++) {
            var total = 0;
            for (var j = 0; j < colsCompare.colIndex.length; j++) {
                total += data[i][colsCompare.colIndex[j]];
            }
            totalBar.push(total);
        }

        if (typeof options.labels!=='undefined' && options.labels==true) {
            // Define a plugin to provide data labels
            Chart.plugins.register({
                id: 'labels',
                afterDatasetsDraw: function (chart) {
                    var ctx = chart.ctx;

                    chart.data.datasets.forEach(function (dataset, i) {
                        var meta = chart.getDatasetMeta(i);
                        if (!meta.hidden) {
                            meta.data.forEach(function (element, index) {
                                // Draw the text in black, with the specified font
                                ctx.fillStyle = 'rgb(0, 0, 0)';
                                var fontSize = 12;
                                var fontStyle = 'normal';
                                var fontFamily = 'Helvetica Neue';
                                ctx.font = Chart.helpers.fontString(fontSize, fontStyle, fontFamily);

                                // Calcular el procentaje
                                var porcentaje = (dataset.data[index] * 100) / totalBar[index];
                                // Just naively convert to string for now
                                var dataString = (Math.round(porcentaje * 100) / 100).toString() + "%";

                                // Make sure alignment settings are correct
                                ctx.textAlign = 'center';
                                ctx.textBaseline = 'top';

                                var padding = 5;
                                var position = element.tooltipPosition();
                                ctx.fillText(dataString, position.x, position.y/*- (fontSize / 2) - padding*/);
                            });
                        }
                    });
                }
            });
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
                    display: typeof options.legend == 'undefined' ? true : options.legend,
                    position: 'top',
                },
                title: {
                    display: (typeof options.title === 'undefined') || options.title == "" ? false : true,
                    text: options.title
                },
                scales: {
                    xAxes: [{
                        ticks: {
                            beginAtZero: true
                        },
                        scaleLabel: {
                            display: (typeof options.xTitle === 'undefined') || options.xTitle == "" ? false : true,
                            labelString: options.xTitle
                        },
                        stacked: true,
                    }],
                    yAxes: [{
                        ticks: {
                            beginAtZero: true
                        },
                        scaleLabel: {
                            display: (typeof options.yTitle === 'undefined') || options.yTitle == "" ? false : true,
                            labelString: options.yTitle
                        },
                        stacked: true,
                    }]
                }
            }
        });
    }
}