function loader() {
    $("#UProgDivMascara").css(
            {
                "display": "block",
                "opacity": "0.90",
                "top": "0"
            });
    //$("#UProgDivMascara").css("display", "none");
}
function unloader() {
    $("#UProgDivMascara").css("display", "none");
}
function agregarSeparador(valor, separador, pasaSep) {
    var decPosicion = -1;
    var separaDec = '';
    pasaSep = typeof (pasaSep) != 'undefined' ? pasaSep : 0;
    if (separador == ',' || separador == '.') {
        if (separador == ',') { separaDec = '.'; }
        else if (separador == '.') { separaDec = ','; }
        if ((valor.indexOf(separador) == valor.lastIndexOf(separador)) && (pasaSep == 0)) {
            if (valor.indexOf(separaDec) >= 0) { decPosicion = valor.indexOf(separaDec); }
            if (decPosicion >= 0) {
                if ((decPosicion - 4 >= 0) || (decPosicion + 4 < valor.length)) {
                    if (decPosicion - 4 >= 0) { valor = valor.substring(0, decPosicion - 3) + separador + valor.substring(decPosicion - 3); decPosicion++; }
                    if (decPosicion + 4 < valor.length) { valor = valor.substring(0, decPosicion + 5) + separador + valor.substring(decPosicion + 5); }
                    valor = agregarSeparador(valor, separador, 1);
                }
            }
            else {
                if (valor.indexOf(separador) > -1) {
                    if (valor.indexOf(separador) - 4 >= 0) {
                        valor = valor.substring(0, valor.indexOf(separador) - 3) + separador + valor.substring(valor.indexOf(separador) - 3); decPosicion++;
                        valor = agregarSeparador(valor, separador, 1);
                    }
                }
                else if (valor.length>3) {
                    valor = valor.substring(0, valor.length - 3) + separador + valor.substring(valor.length - 3);
                    valor = agregarSeparador(valor, separador, 1);
                }
            }
        }
        else {
            if (valor.indexOf(separador) - 4 >= 0) {
                if (valor.indexOf(separador) - 4 >= 0) { valor = valor.substring(0, valor.indexOf(separador) - 3) + separador + valor.substring(valor.indexOf(separador) - 3); decPosicion++; }
                valor = agregarSeparador(valor, separador, 1);
            }
            if (valor.lastIndexOf(separador) + 4 < valor.length && valor.lastIndexOf(separador) + 4 > valor.indexOf(separaDec) && valor.indexOf(separaDec) >= 0) {
                valor = valor.substring(0, valor.lastIndexOf(separador) + 5) + separador + valor.substring(valor.lastIndexOf(separador) + 5); 
                valor = agregarSeparador(valor, separador, 1);
            }
        }

    }
    else {
        if ((valor.indexOf(separador) == valor.lastIndexOf(separador)) && (pasaSep == 0)) {
            if (valor.indexOf('.') >= 0) { decPosicion = valor.indexOf('.'); }
            else if (valor.indexOf(',') >= 0) { decPosicion = valor.indexOf(','); }
            if (decPosicion >= 0) {
                if ((decPosicion - 4 >= 0) || (decPosicion + 4 <= valor.length)) {
                    if (decPosicion - 4 > 0) { valor = valor.substring(0, decPosicion - 3) + separador + valor.substring(decPosicion - 3); decPosicion++; }
                    if (decPosicion + 4 < valor.length) { valor = valor.substring(0, decPosicion + 5) + separador + valor.substring(decPosicion + 5);  }
                    valor = agregarSeparador(valor, separador, 1);
                }
            }
            else {
                if (valor.indexOf(separador) > -1) {
                    if (valor.indexOf(separador) - 4 >= 0) {
                        valor = valor.substring(0, valor.indexOf(separador) - 3) + separador + valor.substring(valor.indexOf(separador) - 3); decPosicion++;
                        valor = agregarSeparador(valor, separador, 1);
                    }
                }
            }
        }
        else {
            if (valor.indexOf(separador) - 4 >= 0) {
                if (valor.indexOf(separador) - 4 >= 0) { valor = valor.substring(0, valor.indexOf(separador) - 3) + separador + valor.substring(valor.indexOf(separador) - 3); decPosicion++; }
                valor = agregarSeparador(valor, separador, 1);
            }
            if (valor.lastIndexOf(separador) + 4 <= valor.length &&
                ((valor.lastIndexOf(separador) + 4 > valor.indexOf('.') && valor.indexOf('.') >= 0) ||
                (valor.lastIndexOf(separador) + 4 > valor.indexOf(',') && valor.indexOf(',') >= 0))) {
                if ((valor.lastIndexOf(separador) + 4 <= valor.length))
                { valor = valor.substring(0, valor.lastIndexOf(separador) + 4) + separador + valor.substring(valor.lastIndexOf(separador) + 4); }
                valor = agregarSeparador(valor, separador, 1);
            }
        }
    }
    return valor;
}
function reemplazaAll(cadena, busqueda, reemplazo) {
    if (cadena.indexOf(busqueda) > -1)
    {
        cadena = cadena.replace(busqueda, reemplazo);
        cadena=reemplazaAll(cadena, busqueda, reemplazo);
    }
    return cadena;
}
function ventanaMensaje(tipoMensaje, titulo, contenido, array_botones, mensaje_alerta) {

    switch (tipoMensaje) {
        case "info":
            $.msgBox({
                title: titulo,
                content: contenido,
                type: "info"
            });
            break;
            //case "confirm":
            //    $.msgBox({
            //        title: titulo,
            //        content: contenido,
            //        type: "confirm",
            //        buttons: [{ value: "Si" }, { value: "No" }],
            //        success: function (result) {
            //            if (result == "Si") { retorno = "Si"; }
            //            else { retorno = "No"; }
            //            return retorno;
            //        }
            //    });
            //    break;
        case "error":
            if (array_botones != null && mensaje_alerta != null) {
                $.msgBox({
                    title: titulo,
                    content: contenido,
                    type: "error",
                    afterShow: function (result) { alert("Message has been shown!"); },
                    opacity: 0.9
                });
            }
            else if (array_botones == null && mensaje_alerta == null) {
                $.msgBox({
                    title: titulo,
                    content: contenido,
                    type: "error",
                    showButtons: false,
                    opacity: 0.9,
                    autoClose: true
                });
            }
            else if (array_botones == null) {
                $.msgBox({
                    title: titulo,
                    content: contenido,
                    type: "error",
                    beforeClose: function () { alert(mensaje_alerta); },
                    showButtons: false,
                    opacity: 0.9
                });
            }
            else if (mensaje_alerta == null) {
                $.msgBox({
                    title: titulo,
                    content: contenido,
                    type: "error",
                    buttons: array_botones
                });
            }

            break;
        case "prompt":
            break;
        default:
            $.msgBox({
                title: titulo,
                content: contenido
            });
            break;
    }
}
/*Procedimiento para dibujar grafico de barras*/
function dibujarBarrasYX(titulo, valores, divGrafico, columnasYX, leyenda) {
        var data = new google.visualization.DataTable();
        var muestraLeyenda = 'right';
        if (!leyenda) { muestraLeyenda = 'none'; }
    data.addColumn(columnasYX[0][0], columnasYX[0][1]);
    data.addColumn(columnasYX[1][0], columnasYX[1][1]);
    data.addColumn({ type: 'string', role: 'annotation' });
    data.addColumn({ type: 'string', role: 'style' });
    $(valores).each(function () {
        data.addRow([$(this)[0], $(this)[1], agregarSeparador(parseFloat($(this)[1].toFixed(3)).toString(), ','), $(this)[2]]);
    });
    var options = {
        title: titulo,
        displayAnnotations: true,
        chartArea: { width: '60%', height: '70%' },
        vAxis: {
            title: columnasYX[0][1],
            textStyle: { italic: columnasYX[0][2] }
        },
        hAxis: {
            title: columnasYX[1][1],
            minValue: 0,
            textStyle: { italic: columnasYX[1][2] }
        },
        legend: { position: muestraLeyenda }
    };

    var chart = new google.visualization.BarChart(document.getElementById(divGrafico));
    chart.draw(data, options);
}
/*Procedimiento para dibujar grafico de columnas*/
    function dibujarBarrasXY(titulo, valores, divGrafico, columnasYX, leyenda) {
        var data = new google.visualization.DataTable();
        var muestraLeyenda = 'right';
        if (!leyenda) { muestraLeyenda = 'none'; }  
    data.addColumn(columnasYX[0][0], columnasYX[0][1]);
    data.addColumn(columnasYX[1][0], columnasYX[1][1]);
    data.addColumn({ type: 'string', role: 'annotation' });
    data.addColumn({ type: 'string', role: 'style' });
    $(valores).each(function () {
        data.addRow([$(this)[0], $(this)[1], agregarSeparador(parseFloat($(this)[1].toFixed(3)).toString(), ','), $(this)[2]]);
    });
    var options = {
        title: titulo,
        displayAnnotations: true,
        chartArea: { width: '60%', height: '70%' },
        hAxis: {
            title: columnasYX[0][1],
            textStyle: { italic: columnasYX[0][2] }
        },
        vAxis: {
            title: columnasYX[1][1],
            minValue: 0,
            textStyle: { italic: columnasYX[1][2] }
        },
        legend: { position: muestraLeyenda }
    };

    var chart = new google.visualization.ColumnChart(document.getElementById(divGrafico));
    chart.draw(data, options);
    }

/*Procedimiento para dibujar gráfico de columnas multiples*/
    function dibujarBarrasXYMultiple(titulo, valores, divGrafico, columnasYX, leyenda) {
        var data = new google.visualization.DataTable();
        var muestraLeyenda = 'right';
        if (!leyenda) { muestraLeyenda = 'none'; }
        $(columnasYX).each(function () {
            data.addColumn($(this)[0], $(this)[1]);
        });

        $(valores).each(function () {
            data.addRow([$(this)[0], $(this)[1], $(this)[2], $(this)[3]]);
        });
        var options = {
            title: titulo,
            displayAnnotations: true,
            chartArea: { width: '60%', height: '70%' },
            hAxis: {
                          
            },
            vAxis: {    
                minValue: 0,
                title: columnasYX[0][1]
            },
            legend: { position: muestraLeyenda }
        };

        var chart = new google.visualization.ColumnChart(document.getElementById(divGrafico));
        chart.draw(data, options);
    }

/*Procedimiento para dibujar gráfico de "X" columnas multiples*/
    function dibujarBarraXYMultiple_NColumn(titulo, valores, divGrafico, columnasYX, leyenda) {
        var data = new google.visualization.DataTable();
        var muestraLeyenda = 'right';
        var ncolumn = 0;
        if (!leyenda) { muestraLeyenda = 'none'; }
        $(columnasYX).each(function () {
            data.addColumn($(this)[0], $(this)[1]);
            ncolumn++;
        });

        $(valores).each(function () {
            var rowTemp = [];
            for (var i = 0; i < ncolumn; i++) {
                rowTemp[i] = $(this)[i];
            }
            //data.addRow([$(this)[0], $(this)[1], $(this)[2], $(this)[3]]);
            data.addRow(rowTemp);
        });
        var options = {
            title: titulo,
            displayAnnotations: true,
            chartArea: { width: '60%', height: '70%' },
            hAxis: {

            },
            vAxis: {
                minValue: 0,
                title: columnasYX[0][1]
            },
            legend: { position: muestraLeyenda }
        };

        var chart = new google.visualization.ColumnChart(document.getElementById(divGrafico));
        chart.draw(data, options);
    }

function PrimerCaracterMayuscula(cadena) {
    return cadena.charAt(0).toUpperCase() + cadena.slice(1);
}