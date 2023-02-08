"use strict";
var ManPriorizacion = {};

ManPriorizacion.fnConfig = function () {
    if (window.sessionStorage) {
        //Cargar las configuraciones existentes
        var lstConfig = [], config = {}, index = -1;
        if (JSON.parse(sessionStorage.getItem('configBusquedaEx')) == null) {
            sessionStorage.setItem('configBusquedaEx', JSON.stringify(lstConfig));
        }
        lstConfig = JSON.parse(sessionStorage.getItem('configBusquedaEx'));
        //Crear o actualizar la configuración del formulario consultado
        config = {
            TipoFormulario: ManPriorizacion.frm.find("#tipoFormulario").val(),
            OpcionBuscar: ManPriorizacion.frm.find("#ddlOpcionBuscarPeriodo").val(),
            OpcionBuscar1: ManPriorizacion.frm.find("#ddlOpcionBuscarOD").val(),
            ValorBuscar: ManPriorizacion.frm.find("#txtValorBuscar").val(),
            PageLength: ManPriorizacion.dtManGrillaPaging.context[0]._iDisplayLength,
            RowStart: ManPriorizacion.dtManGrillaPaging.context[0]._iDisplayStart,
            ColumnOrder: ManPriorizacion.dtManGrillaPaging.context[0].aaSorting[0]
        };
        index = lstConfig.findIndex(m => m.TipoFormulario == ManPriorizacion.frm.find("#tipoFormulario").val());
        if (index != -1) { lstConfig[index] = config; }
        else { lstConfig.push(config); }
        sessionStorage.setItem('configBusquedaEx', JSON.stringify(lstConfig));
    } else {
        utilSigo.toastWarning("Aviso", "Para que funcione bien el sistema, Por favor usar navegadores que soporten sessionStorage. Por ejemplo (Google Chrome, Mozilla Firefox)");
    }
}
ManPriorizacion.fnBuildTable = function () {
    var columns_label = ["N°", "N° de título habilitante", "Nombre de POA", "A.1", "A.2", "A.3", "A.4", "A.5", "A.6", "A.7", "A.8", "B.1", "B.2", "B.3", "B.4", "B.5", "B.6", "Total"];
    var colums_title  = ["N°", "N° de título habilitante", "Nombre de POA", "A.1", "A.2", "A.3", "A.4", "A.5", "A.6", "A.7", "A.8", "B.1", "B.2", "B.3", "B.4", "B.5", "B.6", "Total"];
    var columns = [
        {
            "name": "ROW_INDE", "width": "2%", "orderable": false, "searchable": false, "mRender": function (data, type, row, meta) {
                return parseInt(meta.row) + 1 + meta.settings._iDisplayStart;
            }
        },
        { "data": "NUM_THABILITANTE", "autoWidth": true },
        { "data": "NOMBRE_POA", "autoWidth": true },
        { "data": "A1", "autoWidth": true },
        { "data": "A2", "autoWidth": true },
        { "data": "A3", "autoWidth": true },
        { "data": "A4", "autoWidth": true },
        { "data": "A5", "autoWidth": true },
        { "data": "A6", "autoWidth": true },
        { "data": "A7", "autoWidth": true },
        { "data": "A8", "autoWidth": true },
        { "data": "B1", "autoWidth": true },
        { "data": "B2", "autoWidth": true },
        { "data": "B3", "autoWidth": true },
        { "data": "B4", "autoWidth": true },
        { "data": "B5", "autoWidth": true },
        { "data": "B6", "autoWidth": true },
        { "data": "TOTAL", "autoWidth": true },
    ];
    //**Cabecera**----
    var theadTable = "<tr>";
    for (var i = 0; i < columns_label.length; i++) {
        var title = colums_title[i];
        if (title == "") theadTable += '<th>' + columns_label[i] + '</th>';
        else theadTable += '<th title="' + title + '">' + columns_label[i] + '</th>';

    }
    theadTable += "</tr>";
    $("#tbManGrillaPaging").find("thead").append(theadTable);

    var optDt = { iLength: 10, iStart: 0, aSort: [] };
    //Cargar Configuración  
    if (window.sessionStorage) {
        var lstConfig = [], index = -1;

        if (JSON.parse(sessionStorage.getItem('configBusquedaEx')) == null) {
            sessionStorage.setItem('configBusquedaEx', JSON.stringify(lstConfig));
        }

        lstConfig = JSON.parse(sessionStorage.getItem('configBusquedaEx'));
        index = lstConfig.findIndex(m => m.TipoFormulario == ManPriorizacion.frm.find("#tipoFormulario").val());
        if (index != -1) {
            ManPriorizacion.frm.find("#ddlOpcionBuscarOD").select2("val", [lstConfig[index].OpcionBuscar1]);
            ManPriorizacion.frm.find("#ddlOpcionBuscarPeriodo").select2("val", [lstConfig[index].OpcionBuscar]);
            ManPriorizacion.frm.find("#txtValorBuscar").val(lstConfig[index].ValorBuscar);
            optDt.iLength = lstConfig[index].PageLength;
            optDt.iStart = lstConfig[index].RowStart;
            if ((typeof lstConfig[index].ColumnOrder !== 'undefined') && lstConfig[index].ColumnOrder.length > 0) {
                optDt.aSort.push([lstConfig[index].ColumnOrder[0], lstConfig[index].ColumnOrder[1]]);
            }

            lstConfig.splice(index, 1);
            sessionStorage.setItem('configBusquedaEx', JSON.stringify(lstConfig));
        }
    }
    else {
        utilSigo.toastWarning("Aviso", "Para que funcione bien el sistema, Por favor usar navegadores que soporten sessionStorage. Por ejemplo (Google Chrome, Mozilla Firefox)");
    }

    return $("#tbManGrillaPaging").DataTable({
        processing: true,
        serverSide: true,
        searching: false,
        ordering: false,
        paging: false,
        ajax: {
            "url": initSigo.urlControllerGeneral + "/GetListaGeneralPaging",
            "data": function (d) {
                d.customSearchEnabled = true;
                d.customSearchForm = "PRIORIZACION";
                d.customSearchType = ManPriorizacion.frm.find("#ddlOpcionBuscarOD").val();
                d.customSearchType1 = ManPriorizacion.frm.find("#ddlOpcionBuscarPeriodo").val();
                d.customSearchValue = ManPriorizacion.frm.find("#txtValorBuscar").val().trim();

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
        columns: columns,
        bInfo: false,
        "lengthMenu": [[10, 20, 50, 100], [10, 20, 50, 100]],
        "aaSorting": optDt.aSort,
        "pageLength": optDt.iLength,
        "displayStart": optDt.iStart,
        "oLanguage": initSigo.oLanguage,
        "drawCallback": initSigo.showPagination,
    });
}

ManPriorizacion.fnExport = function (obj) {
    var valorBusqueda = ManPriorizacion.frm.find("#txtValorBuscar").val().trim();
    var valorCboOpcion = ManPriorizacion.frm.find("#ddlOpcionBuscarOD").val();
    $.ajax({
        url: urlLocalSigo + "PlanFocalizacion/Priorizacion/ExportarPriorizacion",
        type: 'POST',
        data: { cod_od: valorCboOpcion, periodo: valorBusqueda },
        dataType: 'json',
        success: function (data) {
            utilSigo.unblockUIGeneral();
            if (data.success) {
                window.location.href = urlLocalSigo + "PlanFocalizacion/Priorizacion/DownloadPriorizacion?file=" + data.values[0];
            }
            else utilSigo.toastWarning("Error", data.msj);
        },
        beforeSend: function () {
            utilSigo.blockUIGeneral();
        },
        error: function (jqXHR, error, errorThrown) {
            utilSigo.unblockUIGeneral();
            utilSigo.toastError("Error", "Sucedio un error, Comuniquese con el Administrador");
            console.log(jqXHR.responseText);
        }
    });
}

ManPriorizacion.fnBuildTableSupervisados = function (data, tbName) {

    var table = $('#' + tbName);
    var tabla = table.children('tbody');
    tabla.children('tr').remove();
    var rows = '';
    var numero = 0;
    $.each(data, (i, r) => {
        rows += '<tr>';
        rows += '<td>' + `${r.NUM_THABILITANTE}` + '</td>';
        rows += '<td>' + `${r.NOMBRE_POA}` + '</td>';
        rows += '<td>' + `${r.MODALIDAD}` + '</td>';
        rows += '</tr>';
    });
    tabla.append(rows);

}

ManPriorizacion.fnBuildTableLeyenda = function (data, tbName) {

    var table = $('#' + tbName);
    var tabla = table.children('tbody');
    tabla.children('tr').remove();
    var rows = '';
    var numero = 0;
    $.each(data, (i, r) => {
        rows += '<tr>';
        rows += '<td>' + `${r.CODIGO}` + '</td>';
        rows += '<td>' + `${r.DESCRIPCION}` + '</td>';
        rows += '<td>' + `${r.PUNTAJE}` + '</td>';
        rows += '</tr>';
    });
    tabla.append(rows);

}

ManPriorizacion.GetListCriterios = function () {
    var url = urlLocalSigo + "PlanFocalizacion/Priorizacion/GetListCriterios";
    var option = { url: url, datos: JSON.stringify(), type: 'GET' };
    utilSigo.fnAjax(option, function (data) {
        if (data.success) {
            ManPriorizacion.fnBuildTableLeyenda(data.data, "tbManGrillaLeyenda");
        }
        else {
            utilSigo.toastWarning("Aviso", initSigo.MessageError);
            console.log(data.msjError);
        }
    });
}

ManPriorizacion.GetListPlanManejoSupervisado = function () {
    var valorBusqueda = ManPriorizacion.frm.find("#txtValorBuscar").val().trim();
    var valorCboOpcion = ManPriorizacion.frm.find("#ddlOpcionBuscarOD").val();
    var url = urlLocalSigo + "PlanFocalizacion/Priorizacion/GetListPlanManejoSupervisado?cod_od=" + valorCboOpcion + "&periodo=" + valorBusqueda;
    //var dataEnviar = { cod_od: valorCboOpcion, periodo: valorBusqueda };
    var option = { url: url, datos: JSON.stringify(), type: 'GET' };
    utilSigo.fnAjax(option, function (data) {
        if (data.success) {
            ManPriorizacion.fnBuildTableSupervisados(data.data, "tbManGrillaSupervisados");
        }
        else {
            utilSigo.toastWarning("Aviso", initSigo.MessageError);
            console.log(data.msjError);
        }
    });
}

ManPriorizacion.fnSearch = function () {
    var valorBusqueda = ManPriorizacion.frm.find("#txtValorBuscar").val().trim();
    var valorCboOpcion = ManPriorizacion.frm.find("#ddlOpcionBuscarOD").val();
    if (valorBusqueda.trim() == "") {
        utilSigo.toastWarning("Aviso", "Ingrese un periodo a buscar");
        ManPriorizacion.frm.find("#txtValorBuscar").focus();
        return false;
    }
    else {
        var cantCaracteres = valorBusqueda.length;
        if (cantCaracteres != 4) {
            utilSigo.toastWarning("Aviso", "Debe ingresar un año en cuatro dígitos");
            ManPriorizacion.frm.find("#txtValorBuscar").focus();
            return false;
        }
        ManPriorizacion.dtManGrillaPaging.ajax.reload();
        ManPriorizacion.GetListCriterios();
        ManPriorizacion.GetListPlanManejoSupervisado();
    }
}
ManPriorizacion.initEventos = function () {
    ManPriorizacion.frm.submit(function (e) {
        e.preventDefault();
        ManPriorizacion.fnSearch();
    });
}
$(document).ready(function () {
    $.fn.select2.defaults.set("theme", "bootstrap4");
    ManPriorizacion.frm = $("#frmManGrillaPaging");
    ManPriorizacion.frm.find("#ddlOpcionBuscarOD").select2();
    ManPriorizacion.frm.find("#ddlOpcionBuscarPeriodo").select2();
    ManPriorizacion.initEventos();
    ManPriorizacion.dtManGrillaPaging = ManPriorizacion.fnBuildTable();
    ManPriorizacion.GetListCriterios();
    var valorBusqueda = ManPriorizacion.frm.find("#txtValorBuscar").val().trim();
    if ((valorBusqueda.trim() != "") && (valorBusqueda.length == 4)) {
        ManPriorizacion.GetListPlanManejoSupervisado();
    }
});

var Priorizacion = {};
(function () {
    this.controller = urlLocalSigo + "PlanFocalizacion/Priorizacion";
    this.fileSelectHandler = function (e, control, url, TVentana) {

        if (e.dataTransfer != undefined &&
            e.dataTransfer.files != undefined) {

            this.resetFileSelect(control, url, TVentana);
        }
        // fetch FileList object
        var files = e.target.files || e.dataTransfer.files;

        if (files != undefined && files.length > 0) {
            this.uploadFileToServer(files[0], control, url, TVentana);
        }
    }
    this.resetFileSelect = function (control, url, TVentana) {
        $("#" + control).replaceWith('<input type="file" id="' + control + '" name="' + control + '" class="form-control" style="display:none;"  onchange="Priorizacion.ItemExcelImportarVentana(event,this,\'' + TVentana + '\')"  onclick="return true" />');

    }
    this.uploadFileToServer = function (file, control, url, TVentana) {
        var formdata = new FormData();
        formdata.append(file.name, file);
        formdata.append("TVentana", TVentana);
        formdata.append("hdfPeriodo", ManPriorizacion.frm.find("#txtValorBuscar").val().trim());
        formdata.append("hdfCod_OD", ManPriorizacion.frm.find("#ddlOpcionBuscarOD").val());

        $.ajax({
            url: url,
            type: 'POST',
            data: formdata,
            contentType: false,
            dataType: 'json',
            processData: false,
            success: function (data) {
                Priorizacion.resetFileSelect(control, url, TVentana);
                utilSigo.unblockUIGeneral();
                if (data.success) {
                    //cargando data
                    ManPriorizacion.dtManGrillaPaging.ajax.reload();
                    utilSigo.toastSuccess("Aviso", "Se Subio Correctamente la Informacion");
                }
                else utilSigo.toastWarning("Aviso", data.msj);
            },
            beforeSend: function () {
                Priorizacion.resetFileSelect(control, url, TVentana);
                utilSigo.blockUIGeneral();
            },
            error: function (jqXHR, error, errorThrown) {
                utilSigo.unblockUIGeneral();
                utilSigo.toastError("Error", initSigo.MessageError);
                console.log(jqXHR.responseText);
            }
        });
    }
    this.ItemExcelImportarVentana = function (e, objeto, TVentana) {

        var idFile = $(objeto).attr("id");
        var ruta = Priorizacion.controller + "/ImportarDataExcel";
        Priorizacion.fileSelectHandler(e, idFile, ruta, TVentana);
    }
}).apply(Priorizacion);
