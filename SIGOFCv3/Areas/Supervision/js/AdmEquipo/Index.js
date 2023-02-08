"use strict";
var AdmEquipo = {};

AdmEquipo.fnSearch = function () {
    var valorCboOpcion = AdmEquipo.frm.find("#ddlOpcionId").val();
    var valorBusqueda = AdmEquipo.frm.find("#txtValor").val().trim();

    if (valorCboOpcion != "100") {
        if (valorBusqueda.trim() == "") {
            utilSigo.toastWarning("Aviso", "Ingrese Valor a Buscar");
            AdmEquipo.frm.find("#txtValor").focus();
            return false;
        }
        else {
            AdmEquipo.dtEquipo.ajax.reload();
        }
    } else {
        AdmEquipo.dtEquipo.ajax.reload();
    }
};

AdmEquipo.fnConfig = function () {
    if (window.sessionStorage) {
        var config = {
            CboOrganizacionId: AdmEquipo.frm.find("#ddlOpcionId").val(),
            txtValor: AdmEquipo.frm.find("#txtValor").val(),
            PageLength: AdmEquipo.dtEquipo.context[0]._iDisplayLength,
            RowStart: AdmEquipo.dtEquipo.context[0]._iDisplayStart,
            ColumnOrder: AdmEquipo.dtEquipo.context[0].aaSorting[0]
        };
        sessionStorage.setItem('configFrmListaEquipo', JSON.stringify(config));

    } else {
        utilSigo.toastWarning("Aviso", "Para que funcione bien el sistema, Por favor usar navegadores que soporten sessionStorage. Por ejemplo (Google Chrome, Mozilla Firefox)");
    }
};

AdmEquipo.fnRefresh = function () {
    AdmEquipo.frm.find("#ddlOpcionId").val($(AdmEquipo.frm.find("#ddlOpcionId")[0].childNodes[0]).val()).trigger('change.select2');
    AdmEquipo.frm.find("#txtValor").val("");
    AdmEquipo.frm.find("#txtValor").attr("disabled", true);
    AdmEquipo.fnSearch();
};

AdmEquipo.fnView = function (obj) {
    var $tr = $(obj).closest('tr');
    var row = AdmEquipo.dtEquipo.row($tr).data();
    let url = urlLocalSigo + "Supervision/AdmEquipo/DetalleEquipo";

    AdmEquipo.fnConfig();

    window.location = url + "?iddetalle=" + row.NV_EQUIPO_INTEGRANTE_ORGANIZACION;
};

AdmEquipo.fnChangeStatus = function (obj, estado) {
    var $tr = $(obj).closest('tr');
    var row = AdmEquipo.dtEquipo.row($tr).data();
    var params = { idequipo: row.NV_EQUIPO, estado };
    var numestado = (row.ESTADO == "ACTIVO") ? 1 : 0;
    var txtestado = (estado == 1) ? "activar" : "inactivar";


    if (numestado == estado) {
        utilSigo.toastInfo("Aviso", "El registro ya se encuentra " + ((estado == 1) ? "activo" : "inactivo"));
        return false;
    }

    utilSigo.dialogConfirm("", "¿Está seguro de " + txtestado + " al registro?", function (r) {
        if (r) {
            let url = urlLocalSigo + "Supervision/AdmEquipo/CambiarEstado";
            let option = { url: url, datos: JSON.stringify(params), type: 'POST' };
            utilSigo.fnAjax(option, function (data) {
                if (data.success) {
                    utilSigo.toastSuccess("Éxito", data.msj);
                    AdmEquipo.fnSearch();
                }
                else {
                    utilSigo.toastWarning("Aviso", "Sucedio un error, Comuníquese con el Administrador");
                    console.log(data.msj);
                }
            });
        }
    });
};

AdmEquipo.fnInitDataTable_Detail = function () {
    var columns_label = ["", "", "", "N°", "Comunidad", "Tipo Organización", "Organización Regional", "Ubigeo", "Sector", "Fecha de Creación", "Última Actualización", "Estado"];
    var columns_data = [
        {
            "data": "", "width": "2%", "orderable": false, "searchable": false, "mRender": function (data, type, row) {
                return '<div><i class="fa fa-lg fa-eye" style="color:black;cursor:pointer;" title="Observar" onclick="AdmEquipo.fnView(this)"></i>';
            }
        },
        {
            "data": "", "width": "2%", "orderable": false, "searchable": false, "mRender": function (data, type, row) {
                return '<div><i class="cellCheck fa fa-lg fa-check-square-o" style="cursor:pointer;color:green;" title="Activar" onclick="AdmEquipo.fnChangeStatus(this,1)"></i>';
                //return '<div><i class="fa fa-lg fa-check-circle" style="cursor:pointer;color:green;" title="Activar" onclick="AdmEquipo.fnChangeStatus(this,1)"></i>';
            }
        },
        {
            "data": "", "width": "2%", "orderable": false, "searchable": false, "mRender": function (data, type, row) {
                return '<div><i class="fa fa-lg fa-window-close" style="cursor:pointer;color:red;" title="Inactivar" onclick="AdmEquipo.fnChangeStatus(this,0)"></i>';
                //return '<div><i class="fa fa-lg fa-times-circle" style="cursor:pointer;color:red;" title="Inactivar" onclick="AdmEquipo.fnChangeStatus(this,0)"></i>';
            }
        },
        {
            "name": "ROW_INDE", "width": "2%", "orderable": false, "searchable": false, "mRender": function (data, type, row, meta) {
                return parseInt(meta.row) + 1 + meta.settings._iDisplayStart;
            }
        },
        { "data": "COMUNIDAD", "autoWidth": true },
        { "data": "TIPO", "autoWidth": true },
        { "data": "NV_ORGREGIONAL", "autoWidth": true },
        { "data": "UBIGEO", "autoWidth": true },
        { "data": "NV_LUGAR", "autoWidth": true },
        { "data": "ACTIVACION", "autoWidth": true },
        { "data": "INACTIVACION", "autoWidth": true },
        { "data": "ESTADO", "autoWidth": true }
    ];

    //Cargar configuración
    var optDt = { iLength: 20, iStart: 0, aSort: [] };
    if (window.sessionStorage) {
        var config = JSON.parse(sessionStorage.getItem('configFrmListaEquipo'));

        if (config != null) {
            AdmEquipo.frm.find("#ddlOpcionId").select2("val", [config.CboOrganizacionId]);
            AdmEquipo.frm.find("#txtValor").val(config.txtValor);
            optDt.iLength = config.PageLength;
            optDt.iStart = config.RowStart;
            if ((typeof config.ColumnOrder !== 'undefined') && config.ColumnOrder.length > 0) {
                optDt.aSort.push([config.ColumnOrder[0], config.ColumnOrder[1]]);
            }
            //sessionStorage.setItem('configFrmListaEquipo', JSON.stringify(config));
            sessionStorage.setItem('configFrmListaEquipo', null);
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
    $("#tbListEquipo").find("thead").append(theadTable);

    AdmEquipo.dtEquipo = $("#tbListEquipo").DataTable({
        processing: true,
        ServerSide: true,
        searching: false,
        ordering: false,
        paging: true,
        ajax: {
            url: urlLocalSigo + "Supervision/AdmEquipo/GetListaEquipo",
            data: function (params) {
                params.opcion = parseInt(AdmEquipo.frm.find("#ddlOpcionId").val());
                params.txtvalor = AdmEquipo.frm.find("#txtValor").val();
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
};

AdmEquipo.fnInitEventos = function () {
    AdmEquipo.frm.find("#ddlOpcionId").change(function () {
        if ($(this).val() == "100") {
            AdmEquipo.frm.find("#txtValor").val("");
            AdmEquipo.frm.find("#txtValor").attr("disabled", true);
        }
        else {
            AdmEquipo.frm.find("#txtValor").val("");
            AdmEquipo.frm.find("#txtValor").removeAttr("disabled");
        }
        setTimeout(function () {
            $('.select2-container-active').removeClass('select2-container-active');
            AdmEquipo.frm.find("#txtValor").focus();
        }, 1);
    });

    AdmEquipo.frm.submit(function (e) {
        e.preventDefault();
        AdmEquipo.fnSearch();
    });
};

$(document).ready(function () {
    AdmEquipo.frm = $("#frmBuscarEquipo");

    $('[data-toggle="tooltip"]').tooltip();
    $.fn.select2.defaults.set("theme", "bootstrap4");
    AdmEquipo.frm.find("#ddlOpcionId").select2();

    AdmEquipo.fnInitEventos();
    AdmEquipo.fnInitDataTable_Detail();
});