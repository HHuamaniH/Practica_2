"use strict";
var RptVigilancia = {};

RptVigilancia.fnConfig = function () {
    if (window.sessionStorage) {
        var config = {
            txtComunidad: RptVigilancia.frm.find("#txtComunidad").val(),
            CboTipoHallazgoId: RptVigilancia.frm.find("#ddlTipoHallazgoId").val(),
            TxtFechaIni: RptVigilancia.frm.find("#txtFechaInicio").val(),
            TxtFechaFin: RptVigilancia.frm.find("#txtFechaFin").val(),
            PageLength: RptVigilancia.dtHallazgo.context[0]._iDisplayLength,
            RowStart: RptVigilancia.dtHallazgo.context[0]._iDisplayStart,
            ColumnOrder: RptVigilancia.dtHallazgo.context[0].aaSorting[0]
        };
        sessionStorage.setItem('configRptVigilancia', JSON.stringify(config));
    } else {
        utilSigo.toastWarning("Aviso", "Para que funcione bien el sistema, Por favor usar navegadores que soporten sessionStorage. Por ejemplo (Google Chrome, Mozilla Firefox)");
    }
};

RptVigilancia.ValidarFecha = function () {
    var valRetorno = true;
    var valfechaini = RptVigilancia.frm.find("#txtFechaInicio").val();
    var valfechafin = RptVigilancia.frm.find("#txtFechaFin").val();

    var fecha1, fecha2;
    var fechaInicio, fechaFin;

    fecha1 = valfechaini.split("/");
    fechaInicio = new Date(fecha1[2], fecha1[1], fecha1[0]);

    fecha2 = valfechafin.split("/");
    fechaFin = new Date(fecha2[2], fecha2[1], fecha2[0]);

    if (fechaFin < fechaInicio) {
        valRetorno = false;
    }

    return valRetorno;
};

RptVigilancia.fnSearch = function () {
    if (utilSigo.ValidaTexto("txtFechaInicio", "Ingrese Fecha Inicio") == false) return false;
    if (utilSigo.ValidaTexto("txtFechaFin", "Ingrese Fecha Fin") == false) return false;

    if (RptVigilancia.ValidarFecha()) {
        RptVigilancia.dtHallazgo.ajax.reload();
    }
    else {
        utilSigo.toastWarning("Aviso", "Fecha Fin tiene que ser mayor que Fecha de Inicio.");
        RptVigilancia.frm.find("#txtFechaFin").focus();
    }
};

RptVigilancia.fnRefresh = function () {
    RptVigilancia.frm.find("#txtComunidad").val("");
    RptVigilancia.frm.find("#ddlTipoHallazgoId").val($(RptVigilancia.frm.find("#ddlTipoHallazgoId")[0].childNodes[0]).val()).trigger('change.select2');
    RptVigilancia.frm.find("#txtFechaInicio").val(new Date().toJSON().slice(0, 10).split('-').reverse().join('/'));
    RptVigilancia.frm.find("#txtFechaFin").datepicker({ format: "dd/mm/yyyy", autoclose: true, language: 'es' });
    RptVigilancia.fnSearch();
};

RptVigilancia.fnExport = function () {
    if (utilSigo.ValidaTexto("txtFechaInicio", "Ingrese Fecha Inicio") == false) return false;
    if (utilSigo.ValidaTexto("txtFechaFin", "Ingrese Fecha Fin") == false) return false;

    if (RptVigilancia.ValidarFecha()) {
        var url = urlLocalSigo + "Supervision/ReporteVigilancia/ExportarRptHallazgo";
        var params = {
            txtComunidad: RptVigilancia.frm.find("#txtComunidad").val(),
            idtipohallazgo: RptVigilancia.frm.find("#ddlTipoHallazgoId").val(),
            txtfechaini: RptVigilancia.frm.find("#txtFechaInicio").val(),
            txtfechafin: RptVigilancia.frm.find("#txtFechaFin").val()
        };
        var option = { url: url, datos: JSON.stringify(params), type: 'POST' };

        utilSigo.fnAjax(option, function (data) {
            if (data.success) {
                document.location = urlLocalSigo + "Supervision/ReporteVigilancia/Download?file=" + data.msj;
            }
            else {
                if (data.msj == "No se encontraron registros")
                    utilSigo.toastInfo("Aviso", "No se encontraron registros");
                else {
                    utilSigo.toastWarning("Aviso", "Sucedio un error, Comuníquese con el Administrador");
                    console.log(data.msj);
                }
            }
        });
    }
    else {
        utilSigo.toastWarning("Aviso", "Fecha Fin tiene que ser mayor que Fecha de Inicio.");
        RptVigilancia.frm.find("#txtFechaFin").focus();
    }
};

RptVigilancia.fnValidar = function (obj) {
    var $tr = $(obj).closest('tr');
    var row = RptVigilancia.dtHallazgo.row($tr).data();
    let url = urlLocalSigo + "Supervision/ReporteVigilancia/ValidarHallazgo";

    RptVigilancia.fnConfig();

    window.location = url + "?idhallazgo=" + row.NV_REPORTEHALLAZGO +
        "&txtComunidad=" + row.COMUNIDAD;
};

RptVigilancia.fnComunicar = function (obj) {
    var $tr = $(obj).closest('tr');
    var row = RptVigilancia.dtHallazgo.row($tr).data();

    if (row.ESTADO == "PROCESAMIENTO TERMINADO") {
        let url = urlLocalSigo + "Supervision/ReporteVigilancia/ComunicarHallazgo";

        RptVigilancia.fnConfig();

        window.location = url + "?idhallazgo=" + row.NV_REPORTEHALLAZGO +
            "&txtComunidad=" + row.COMUNIDAD;
    }
    else {
        utilSigo.toastInfo("Aviso", 'Solo se permiten comunicar los registros cuyos estados sean "PROCESAMIENTO TERMINADO"');
    }
};

RptVigilancia.fnInitDataTable_Detail = function () {
    var columns_label = ["", "", "N°", "F. Emisión", "Tipo del Reporte", "Comunidad", "Usuario", "Sector", "Organización Interna", "¿Ha sido comunicado?", "Estado"];
    var columns_data = [
        {
            "data": "", "width": "2%", "orderable": false, "searchable": false, "mRender": function (data, type, row) {
                if (row.ESTADO == "PROCESAMIENTO TERMINADO" || row.ESTADO == "REGISTRO NO CONFORME")
                    return '<div><i class="fa fa-lg fa-eye" style="color:black;cursor:pointer;" title="Observar" onclick="RptVigilancia.fnValidar(this)"></i>';
                else
                    return '<div><i class="cellCheck fa fa-lg fa-check-square-o" style="cursor:pointer;color:green;" title="Procesar" onclick="RptVigilancia.fnValidar(this)"></i>';
            }
        },
        {
            "data": "", "width": "2%", "orderable": false, "searchable": false, "mRender": function (data, type, row) {
                return '<div><i class="fa fa-lg far fa-paper-plane" style="cursor:pointer;color:#21897A;" title="Comunicar" onclick="RptVigilancia.fnComunicar(this)"></i>';
                //return '<div><i class="fa fa-lg far fa-paper-plane" style="cursor:pointer;color:#21897A;" title="Comunicar" disabled="' + ((row.ESTADO != "PROCESAMIENTO TERMINADO") ? true : false) + '" onclick="RptVigilancia.fnComunicar(this)"></i>';
            }
        },
        //{ "name": "ROW_INDE", "width": "2%", "orderable": false, "searchable": false, "defaultContent": "" },
        {
            "name": "ROW_INDE", "width": "2%", "orderable": false, "searchable": false, "mRender": function (data, type, row, meta) {
                return parseInt(meta.row) + 1 + meta.settings._iDisplayStart;
            }
        },
        { "data": "EMISION", "autoWidth": true },
        { "data": "TIPO_REPORTE", "autoWidth": true },
        { "data": "COMUNIDAD", "autoWidth": true },
        { "data": "INTEGRANTE", "autoWidth": true },
        { "data": "SECTOR", "autoWidth": true },
        { "data": "ORGANIZACION", "autoWidth": true },
        { "data": "COMUNICADO", "autoWidth": true },
        { "data": "ESTADO", "autoWidth": true }
    ];

    //Cargar configuración
    var optDt = { iLength: 20, iStart: 0, aSort: [] };
    if (window.sessionStorage) {
        var config = JSON.parse(sessionStorage.getItem('configRptVigilancia'));

        if (config != null) {
            RptVigilancia.frm.find("#txtComunidad").val(config.txtComunidad);
            RptVigilancia.frm.find("#ddlTipoHallazgoId").select2("val", [config.CboTipoHallazgoId]);
            RptVigilancia.frm.find("#txtFechaInicio").val(config.TxtFechaIni);
            RptVigilancia.frm.find("#txtFechaFin").val(config.TxtFechaFin);
            optDt.iLength = config.PageLength;
            optDt.iStart = config.RowStart;
            if ((typeof config.ColumnOrder !== 'undefined') && config.ColumnOrder.length > 0) {
                optDt.aSort.push([config.ColumnOrder[0], config.ColumnOrder[1]]);
            }
            sessionStorage.setItem('configRptVigilancia', null);
        }
    } else {
        utilSigo.toastWarning("Aviso", "Para que funcione bien el sistema, Por favor usar navegadores que soporten sessionStorage. Por ejemplo (Google Chrome, Mozilla Firefox)");
    }

    //**Cabecera**----
    var theadTable = "<tr>";
    for (var i = 0; i < columns_label.length; i++) {
        theadTable += '<th>' + columns_label[i] + '</th>';
    }
    theadTable += "</tr>";
    $("#tbRptVigilancia").find("thead").append(theadTable);

    RptVigilancia.dtHallazgo = $("#tbRptVigilancia").DataTable({
        processing: true,
        ServerSide: true,
        searching: false,
        //ordering: true,
        ordering: false,
        paging: true,
        ajax: {
            url: urlLocalSigo + "Supervision/ReporteVigilancia/GetRptHallazgo",
            data: function (params) {
                params.txtComunidad = RptVigilancia.frm.find("#txtComunidad").val();
                params.idtipohallazgo = RptVigilancia.frm.find("#ddlTipoHallazgoId").val();
                params.txtfechaini = RptVigilancia.frm.find("#txtFechaInicio").val();
                params.txtfechafin = RptVigilancia.frm.find("#txtFechaFin").val();
            },
            type: "GET",
            datatype: "json"
        },
        columns: columns_data,
        bInfo: true,
        lengthMenu: [10, 20, 50, 100],
        aaSorting: optDt.aSort,
        pageLength: optDt.iLength,
        displayStart: optDt.iStart,
        oLanguage: initSigo.oLanguage,
        drawCallback: initSigo.showPagination
    });

    /*RptVigilancia.dtHallazgo.on('order.dt search.dt', function () {
        RptVigilancia.dtHallazgo.column(2, { search: 'applied', order: 'applied' }).nodes().each(function (cell, i) {
            cell.innerHTML = i + 1;
        });
    }).draw();*/
};

RptVigilancia.fnInitEventos = function () {
    RptVigilancia.frm.find("#txtFechaInicio").datepicker({ format: "dd/mm/yyyy", autoclose: true, language: 'es' });
    RptVigilancia.frm.find("#txtFechaInicio").val(new Date().toJSON().slice(0, 10).split('-').reverse().join('/'));
    //RptVigilancia.frm.find("#txtFechaInicio").val("01/01/2021");
    RptVigilancia.frm.find("#txtFechaFin").val(new Date().toJSON().slice(0, 10).split('-').reverse().join('/'));
    RptVigilancia.frm.find("#txtFechaFin").datepicker({ format: "dd/mm/yyyy", autoclose: true, language: 'es' });

    RptVigilancia.frm.submit(function (e) {
        e.preventDefault();
        RptVigilancia.fnSearch();
    });
};

$(document).ready(function () {
    RptVigilancia.frm = $("#frmBuscarRpt");

    $('[data-toggle="tooltip"]').tooltip();
    $.fn.select2.defaults.set("theme", "bootstrap4");
    RptVigilancia.frm.find("#ddlTipoHallazgoId").select2();

    RptVigilancia.fnInitEventos();
    RptVigilancia.fnInitDataTable_Detail();
});