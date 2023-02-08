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
    Mostrar Gráfico de Barras cuya fuente de datos es un DataTable
    Params:
        - dt                : DataTable
        - horizontalData    : Opción sobre el cual se realiza la comparación | value: 'DATA'
        - verticalData      : Datos a comparar  {colIndex:[1,3,5],data:['DATA_1','DATA_3','DATA_5'],color:['red','green','purple']}
        - options           : Opciones para personalizar y/o configurar el gráfico de barras
            options.type    : Tipo de orientación | value: 'H':Horizontal, 'V': Vertical
            options.title   : Título de gráfico de barras
            options.canvas  : Contenedor del gráfico
*/
customChart.LoadBarraSimple_DataTable = function (dt,horizontalData,verticalData,options) {
    var rows, countFilas, data, labels = [], datasets = [], type = "";

    if (typeof options.type==='undefined' || options.type=='V') {
        type = "bar";
    } else if (options.type=='H') {
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
                    position: 'top',
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
