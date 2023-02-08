"use strict";

var _manGrilla = {};

_manGrilla.fnExportar = function () {/*Implementar en donde se instancia*/ };

/*Default Config ManGrilla*/
_manGrilla.isPaging = false;
_manGrilla.columns_label = [];
_manGrilla.columns_filter = [];
_manGrilla.columns_data = [];
//_manGrilla.createTrs = null; //para implementar las columnas de acuerdo a la logica de sus formularios
_manGrilla.url = "";
_manGrilla.paramInit = {};
_manGrilla.fnLoadViewGeneral = function (_contenedor) {
    if ($("#" + _contenedor).length == 0) {
        //utilSigo.unblockUIGeneral();
        utilSigo.toastError("Error", initSigo.MessageError);
        console.log("El contenedor de la vista consultada no existe.");
        return false;
    }
    var url = $("#" + _contenedor).data('request_url');
    var formulario = $("#" + _contenedor).data('request_formulario');
    var tituloFormulario = $("#" + _contenedor).data('request_titulo');

    var datos = {
        tipoFormulario: formulario,
        titleMenu: tituloFormulario,
    };
    $.ajax({
        url: url,
        type: 'POST',
        data: datos,
        dataType: 'html',
        success: function (vista) {
            utilSigo.unblockUIGeneral();
            $("#" + _contenedor).html(vista);
            $('[data-toggle="tooltip"]').tooltip();

            /*Controls ManGrilla*/
            _manGrilla.frmManGrilla = $("#frmManGrilla");
            _manGrilla.tbGrillaGeneral = $("#tbGrillaGeneral");

            //Cargar columnas de la vista general (ManGrilla)
            var trManGrilla = "<tr>";
            for (var i = 0; i < _manGrilla.columns_label.length; i++) {
                trManGrilla += "<th>" + _manGrilla.columns_label[i] + "</th>";
            }
            trManGrilla += "</tr>";
            _manGrilla.tbGrillaGeneral.find("thead").append(trManGrilla);

            if (_manGrilla.isPaging) {
                _manGrilla.fnLoadDataTable_Paging();
            } else {
                _manGrilla.fnLoadDataTable();
                _manGrilla.fnSearch(_manGrilla.paramInit);
            }
            //Event submit
            _manGrilla.frmManGrilla.submit(function (e) {
                e.preventDefault();
                _manGrilla.fnSearchDataTable();
            });
        },
        beforeSend: function () {
            utilSigo.blockUIGeneral();
        },
        error: function (jqXHR, error, errorThrown) {
            utilSigo.unblockUIGeneral();
            utilSigo.toastError("Error", initSigo.MessageError);
            console.log(jqXHR.responseText);
        },
        statusCode: {
            203: () => { utilSigo.unblockUIGeneral(); utilSigo.toastInfo("Aviso", "El usuario perdio la sesión. Vuelva ingresar al sistema"); }
        }
    });

    //Captura el contenedor de la vista consultada
    _manGrilla.contenedor = _contenedor;
}
_manGrilla.fnSearch = function (datos) {
    $.ajax({
        url: _manGrilla.url,
        type: 'GET',
        data: datos,
        dataType: 'json',
        contentType: 'application/json; charset=utf-8',
        success: function (resultado) {
            if (resultado.success) {
                _manGrilla.dtGrillaGeneral.clear().draw();
                utilSigo.unblockUIElement(_manGrilla.tbGrillaGeneral);
                var totalTrs = _manGrilla.createTrs(resultado.data);
                _manGrilla.dtGrillaGeneral.rows.add(totalTrs).draw();
            }
            else {
                utilSigo.toastError("Aviso", initSigo.MessageError);
                console.log(resultado);
            }
        },
        beforeSend: function () {
            utilSigo.blockUIElement(_manGrilla.tbGrillaGeneral);
        },
        error: function (jqXHR, error, errorThrown) {
            utilSigo.unblockUIElement(_manGrilla.tbGrillaGeneral);
            utilSigo.toastError("Error", initSigo.MessageError);
            console.log(jqXHR.responseText);
        },
        statusCode: {
            203: () => { utilSigo.unblockUIGeneral(); utilSigo.toastInfo("Aviso", "El usuario perdio la sesión. Vuelva ingresar al sistema"); }
        }
    });
}
_manGrilla.fnLoadDataTable = function () {

    //console.log(_manGrilla.columns_data);
    if (_manGrilla.columns_data.length == 0) {
        _manGrilla.dtGrillaGeneral = _manGrilla.tbGrillaGeneral.DataTable({
            "bServerSide": false,
            "bAutoWidth": false,
            "bProcessing": true,
            "bJQueryUI": false,
            "bRetrieve": true,
            "bFilter": false,
            "aaSorting": [],
            "bPaginate": true,
            "bInfo": false,
            "bLengthChange": false,
            "pageLength": 20,
            "oLanguage": initSigo.oLanguage,
            "drawCallback": initSigo.showPagination

        });
    } else {
        _manGrilla.dtGrillaGeneral = _manGrilla.tbGrillaGeneral.DataTable({
            "bServerSide": false,
            "bAutoWidth": false,
            "bProcessing": true,
            "bJQueryUI": false,
            "bRetrieve": true,
            "bFilter": false,
            "aaSorting": [],
            "bPaginate": true,
            "bInfo": false,
            "bLengthChange": false,
            "pageLength": 20,
            "oLanguage": initSigo.oLanguage,
            "drawCallback": initSigo.showPagination,
            columns: _manGrilla.columns_data
        });


    }

}
_manGrilla.fnLoadDataTable_Paging = function () {
    _manGrilla.dtGrillaGeneral = _manGrilla.tbGrillaGeneral.DataTable({
        processing: true,
        serverSide: true,
        searching: false,
        ordering: true,
        paging: true,
        ajax: {
            "url": _manGrilla.tbGrillaGeneral.data('request_url'),
            "data": function (d) {
                d.customSearchEnabled = true;
                d.customSearchForm = _manGrilla.frmManGrilla.find("#tipoFormulario").val();
                d.customSearchType = _manGrilla.frmManGrilla.find("#cboOpciones").val();
                d.customSearchValue = _manGrilla.frmManGrilla.find("#txtValor").val();

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
            "statusCode": {
                203: () => { utilSigo.unblockUIGeneral(); utilSigo.toastInfo("Aviso", "El usuario perdio la sesión. Vuelva ingresar al sistema"); }
            }
        },
        columns: _manGrilla.columns_data,

        "lengthMenu": [[10, 20, 50, 100], [10, 20, 50, 100]],
        "aaSorting": [],
        "pageLength": initSigo.pageLength,
        "oLanguage": initSigo.oLanguage,
        "drawCallback": initSigo.showPagination,
    });
}

_manGrilla.fnSearchDataTable = function () {
    var valorTipoObligacion = _manGrilla.frmManGrilla.find("#cboOpciones").val();
    var valorEstado = _manGrilla.frmManGrilla.find("#cboOpciones2").val();

    if (valorEstado.trim() == "") {
        utilSigo.toastWarning("Aviso", "Seleccione un estado.");
        _manGrilla.frmManGrilla.find("#cboOpciones2").focus();
        return false;
    }
    else {
        if (_manGrilla.isPaging) {
            _manGrilla.dtGrillaGeneral.ajax.reload();
        } else {
            _manGrilla.fnSearch({
                obligacion: valorTipoObligacion,
                estado: valorEstado
            });
        }
    }
}

_manGrilla.fnRefreshDataTable = function () {
    _manGrilla.frmManGrilla.find("#cboOpciones").val("0");
    _manGrilla.frmManGrilla.find("#cboOpciones2").val("2");
    if (_manGrilla.isPaging) {
        _manGrilla.dtGrillaGeneral.ajax.reload();
    } else {
        _manGrilla.fnSearch(_manGrilla.paramInit);
    }
}

_manGrilla.fnCreateNew = function () {
    $("#" + _manGrilla.contenedor + "_Control").find("#btnCreateNew").click();
}
_manGrilla.fnExportar = function () {

    $.ajax({
        url: urlLocalSigo + "General/Controles/ExportarExcelListadoManGrilla",
        type: 'POST',
        data: { busFormulario: _manGrilla.frmManGrilla.find("#tipoFormulario").val() },
        dataType: 'json',
        success: function (data) {
            utilSigo.unblockUIGeneral();
            if (data.success) {


                window.location = urlLocalSigo + "General/Controles/DownloadListadoManGrilla?file=" + data.values[0];
            }
            else utilSigo.toastWarning("Error", data.msj);
        },
        beforeSend: function () {
            utilSigo.blockUIGeneral();
        },
        error: function (jqXHR, error, errorThrown) {
            utilSigo.unblockUIGeneral();
            utilSigo.toastError("Error", initSigo.MessageError);
            console.log(jqXHR.responseText);
        },
        statusCode: {
            203: () => { utilSigo.unblockUIGeneral(); utilSigo.toastInfo("Aviso", "El usuario perdio la sesión. Vuelva ingresar al sistema"); }
        }
    });
}

_manGrilla.createTrs = function (data) {
    return data;
}