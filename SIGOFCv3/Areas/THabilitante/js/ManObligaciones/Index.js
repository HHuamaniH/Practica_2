"use strict";
var ManObligacion = {};

ManObligacion.fnSearch = function () {
    ManObligacion.dtObligacion.ajax.reload();
};

ManObligacion.fnConfig = function () {
    if (window.sessionStorage) {
        var config = {
            CboTipoObligacionId: ManObligacion.frm.find("#ddlTipoObligacionId").val(),
            CboEstadoId: ManObligacion.frm.find("#ddlEstadoId").val(),
            PageLength: ManObligacion.dtObligacion.context[0]._iDisplayLength,
            RowStart: ManObligacion.dtObligacion.context[0]._iDisplayStart,
            ColumnOrder: ManObligacion.dtObligacion.context[0].aaSorting[0]
        };
        sessionStorage.setItem('configFrmManObligacion', JSON.stringify(config));

    } else {
        utilSigo.toastWarning("Aviso", "Para que funcione bien el sistema, Por favor usar navegadores que soporten sessionStorage. Por ejemplo (Google Chrome, Mozilla Firefox)");
    }
};

ManObligacion.fnRefresh = function () {
    ManObligacion.frm.find("#ddlTipoObligacionId").val($(ManObligacion.frm.find("#ddlTipoObligacionId")[0].childNodes[0]).val()).trigger('change.select2');
    ManObligacion.frm.find("#ddlEstadoId").val($(ManObligacion.frm.find("#ddlEstadoId")[0].childNodes[0]).val()).trigger('change');
    ManObligacion.fnSearch();
};

ManObligacion.fnValidar = function (obj) {
    var $tr = $(obj).closest('tr');
    var row = ManObligacion.dtObligacion.row($tr).data();
    let url = urlLocalSigo + "THabilitante/ManObligaciones/ValidarObligacion";

    ManObligacion.fnConfig();

    window.location = url + "?idobligacion=" + row.nV_ID +
        "&tipo_obligacion=" + row.nU_TIPO_OBLIGACION +
        "&desc_obligacion=" + row.nV_OBLIGACION +
        "&desc_estado=" + row.nV_ESTADO;
};

ManObligacion.fnInitDataTable_Detail = function () {
    var columns_label = ["", "N°", "Código de referencia", "Última Actualización", "Obligación", "Título Habilitante", "Plan de manejo", "Titular", "Estado"];
    var columns_data = [
        {
            "data": "", "width": "2%", "orderable": false, "searchable": false, "mRender": function (data, type, row) {
                if (row.nU_ESTADO == 3 || row.nU_ESTADO == 4)
                    return '<div><i class="fa fa-lg fa-eye" style="color:black;cursor:pointer;" title="Observar" onclick="ManObligacion.fnValidar(this)"></i>';
                else
                    return '<div><i class="fa fa-lg fa-pencil-square-o" style="color:blue;cursor:pointer;" title="Modificar Registro" onclick="ManObligacion.fnValidar(this)"></i>';
            }
        },
        { "name": "ROW_INDEX", "width": "2%", "orderable": false, "searchable": false, "defaultContent": "" },
        { "data": "txNroRegistro", "autoWidth": true },
        { "data": "fE_PRESENTACION", "autoWidth": true },
        { "data": "nV_OBLIGACION", "autoWidth": true },
        { "data": "nV_THABILITANTE", "autoWidth": true },
        { "data": "nV_PLAN_MANEJO", "autoWidth": true },
        { "data": "nV_TITULAR", "autoWidth": true },
        { "data": "nV_ESTADO", "autoWidth": true }
    ];

    //Cargar configuración
    var optDt = { iLength: 20, iStart: 0, aSort: [] };
    if (window.sessionStorage) {
        var config = JSON.parse(sessionStorage.getItem('configFrmManObligacion'));

        if (config != null) {
            ManObligacion.frm.find("#ddlTipoObligacionId").select2("val", [config.CboTipoObligacionId]);
            ManObligacion.frm.find("#ddlEstadoId").val(config.CboEstadoId);
            optDt.iLength = config.PageLength;
            optDt.iStart = config.RowStart;
            if ((typeof config.ColumnOrder !== 'undefined') && config.ColumnOrder.length > 0) {
                optDt.aSort.push([config.ColumnOrder[0], config.ColumnOrder[1]]);
            }
            sessionStorage.setItem('configFrmManObligacion', null);
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
    $("#tbObligacion").find("thead").append(theadTable);

    ManObligacion.dtObligacion = $("#tbObligacion").DataTable({
        processing: true,
        ServerSide: true,
        searching: false,
        ordering: true,
        paging: true,
        ajax: {
            url: urlLocalSigo + "THabilitante/ManObligaciones/GetListaObligacion",
            data: function (params) {
                params.tipo_obligacion = parseInt(ManObligacion.frm.find("#ddlTipoObligacionId").val());
                params.estado = parseInt(ManObligacion.frm.find("#ddlEstadoId").val());
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

    utilSigo.enumTB(ManObligacion.dtObligacion, 1);
};

ManObligacion.fnInitEventos = function () {
    ManObligacion.frm.submit(function (e) {
        e.preventDefault();
        ManObligacion.fnSearch();
    });
};

$(document).ready(function () {
    ManObligacion.frm = $("#frmBuscarObligacion");

    $('[data-toggle="tooltip"]').tooltip();
    $.fn.select2.defaults.set("theme", "bootstrap4");
    ManObligacion.frm.find("#ddlTipoObligacionId").select2();

    ManObligacion.fnInitEventos();
    ManObligacion.fnInitDataTable_Detail();
});