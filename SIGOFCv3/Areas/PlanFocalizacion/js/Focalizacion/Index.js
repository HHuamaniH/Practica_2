"use strict";
var ManPlanTrabajo = {};

ManPlanTrabajo.fnConfig = function () {
    if (window.sessionStorage) {
        //Cargar las configuraciones existentes
        var lstConfig = [], config = {}, index = -1;
        if (JSON.parse(sessionStorage.getItem('configBusquedaEx')) == null) {
            sessionStorage.setItem('configBusquedaEx', JSON.stringify(lstConfig));
        }
        lstConfig = JSON.parse(sessionStorage.getItem('configBusquedaEx'));
        //Crear o actualizar la configuración del formulario consultado
        config = {
            TipoFormulario: ManPlanTrabajo.frm.find("#tipoFormulario").val(),
            OpcionBuscar: ManPlanTrabajo.frm.find("#ddlOpcionBuscarPeriodo").val(),
            OpcionBuscar1: ManPlanTrabajo.frm.find("#ddlOpcionBuscarOD").val(),
            ValorBuscar: ManPlanTrabajo.frm.find("#txtValorBuscar").val(),
            PageLength: ManPlanTrabajo.dtManGrillaPaging.context[0]._iDisplayLength,
            RowStart: ManPlanTrabajo.dtManGrillaPaging.context[0]._iDisplayStart,
            ColumnOrder: ManPlanTrabajo.dtManGrillaPaging.context[0].aaSorting[0]
        };
        index = lstConfig.findIndex(m => m.TipoFormulario == ManPlanTrabajo.frm.find("#tipoFormulario").val());
        if (index != -1) { lstConfig[index] = config; }
        else { lstConfig.push(config); }
        sessionStorage.setItem('configBusquedaEx', JSON.stringify(lstConfig));
    } else {
        utilSigo.toastWarning("Aviso", "Para que funcione bien el sistema, Por favor usar navegadores que soporten sessionStorage. Por ejemplo (Google Chrome, Mozilla Firefox)");
    }
}
ManPlanTrabajo.fnBuildTable = function () {
    var columns_label = ["", "", "Oficina","Periodo", "Fecha de registro", "Mes", "Aprobado","",""];
    var colums_title = ["", "", "Oficina","Periodo", "Fecha de registro", "Mes", "Aprobado","","Control de Calidad"];
    var columns = [
        {
            "data": "", "width": "2%", "orderable": false, "searchable": false, "mRender": function (data, type, row) {
                return '<div><i class="fa fa-lg fa-pencil-square-o" style="color:blue;cursor:pointer;" title="Editar" onclick="ManPlanTrabajo.fnAddEdit(this)"></i>';
            }
        },
        {
            "data": "", "width": "2%", "orderable": false, "searchable": false, "mRender": function (data, type, row) {
                return '<div><i class="fa fa-lg fa-window-close" style="color:red;cursor:pointer;" title="Eliminar" onclick="ManPlanTrabajo.fnDelete(this)"></i>';
            }
        },
        { "data": "OD", "autoWidth": true },
        { "data": "periodo", "autoWidth": true },
        { "data": "fecha_creacion", "autoWidth": true },
        { "data": "mes", "autoWidth": true },
        { "data": "aprobado", "autoWidth": true },
        {
            "data": "", "width": "2%", "orderable": false, "searchable": false, "mRender": function (data, type, row) {
                return '<div><i class="fa fa-lg fa-check" style="cursor: pointer;color:dodgerblue;" title="Aprobar plan de trabajo" onclick="ManPlanTrabajo.fnAprobarPlanTrabajo(this)"></i>';
                
            }
        },
        {
            "data": "", "width": "2%", "orderable": false, "searchable": false, "mRender": function (data, type, row) {
                return '<div><i class="fa fa-lg fa-tasks" style="cursor: pointer;color:dodgerblue;" title="Control Calidad" onclick="ManPlanTrabajo.fnControlCalidad(this)"></i>';

            }
        }
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
        index = lstConfig.findIndex(m => m.TipoFormulario == ManPlanTrabajo.frm.find("#tipoFormulario").val());
        if (index != -1) {
            ManPlanTrabajo.frm.find("#ddlOpcionBuscarOD").select2("val", [lstConfig[index].OpcionBuscar1]);
            ManPlanTrabajo.frm.find("#ddlOpcionBuscarPeriodo").select2("val", [lstConfig[index].OpcionBuscar]);
            ManPlanTrabajo.frm.find("#txtValorBuscar").val(lstConfig[index].ValorBuscar);
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
        paging: true,
        ajax: {
            "url": initSigo.urlControllerGeneral + "/GetListaGeneralPaging",
            "data": function (d) {
                d.customSearchEnabled = true;
                d.customSearchForm = "FOCALIZACION";
                d.customSearchType = ManPlanTrabajo.frm.find("#ddlOpcionBuscarOD").val();
                d.customSearchType1 = ManPlanTrabajo.frm.find("#ddlOpcionBuscarPeriodo").val();
                d.customSearchValue = ManPlanTrabajo.frm.find("#txtValorBuscar").val().trim();

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
        bInfo: true,
        "lengthMenu": [[10, 20, 50, 100], [10, 20, 50, 100]],
        "aaSorting": optDt.aSort,
        "pageLength": optDt.iLength,
        "displayStart": optDt.iStart,
        "oLanguage": initSigo.oLanguage,
        "drawCallback": initSigo.showPagination,
    });
}
ManPlanTrabajo.fnDelete = function (obj) {
    if (obj != null) {
        var itemRow = ManPlanTrabajo.dtManGrillaPaging.row($(obj).parents('tr')).data();
        var cod_paspeq_plan_trabajo = itemRow.cod_paspeq_plan_trabajo;
        var mes_focalizacion = itemRow.mes_focalizacion;
        var periodo = itemRow.periodo;
        var option = {
            url: urlLocalSigo + "PlanFocalizacion/Focalizacion/_PlanTrabajoEliminar",
            divId: "manPlanTrabajoModal",
            datos: { cod_paspeq_plan_trabajo: cod_paspeq_plan_trabajo, mes_focalizacion: mes_focalizacion , periodo: periodo }
        };
        utilSigo.fnOpenModal(option);
    }
}

ManPlanTrabajo.fnAddEdit = function (obj) {
    var cod_paspeq_plan_trabajo = "";
    var periodo = "";
    var mes_focalizacion = "";
    var cod_od = "";
    let od = "";
    if (obj != null) {
        var itemRow = ManPlanTrabajo.dtManGrillaPaging.row($(obj).parents('tr')).data();
        cod_paspeq_plan_trabajo = itemRow.cod_paspeq_plan_trabajo;
        mes_focalizacion = itemRow.mes_focalizacion;
        periodo = itemRow.periodo;
        od = itemRow.OD;
        ManPlanTrabajo.fnLoadPlanTrabajoDetalle(cod_paspeq_plan_trabajo, periodo, mes_focalizacion,od);
    }
    else {
        cod_od = ManPlanTrabajo.frm.find("#ddlOpcionBuscarOD").val();
        periodo = ManPlanTrabajo.frm.find("#txtValorBuscar").val();
        var option = {
            url: urlLocalSigo + "PlanFocalizacion/Focalizacion/_PlanTrabajo",
            divId: "manPlanTrabajoModal",
            datos: { periodo: periodo, cod_od: cod_od }
        };
        utilSigo.fnOpenModal(option);
    }

}
ManPlanTrabajo.fnExport = function (obj) {
    var itemRow = ManPlanTrabajo.dtManGrillaPaging.row($(obj).parents('tr')).data();
    $.ajax({
        url: urlLocalSigo + "PlanFocalizacion/Focalizacion/ExportarPlanTrabajo",
        type: 'POST',
        data: { cod_paspeq_plan_trabajo: cod_paspeq_plan_trabajo },
        dataType: 'json',
        success: function (data) {
            utilSigo.unblockUIGeneral();
            if (data.success) {
                window.location.href = urlLocalSigo + "PlanFocalizacion/Focalizacion/DownloadPlanTrabajo?file=" + data.values[0];
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
ManPlanTrabajo.fnAprobarPlanTrabajo = function (obj) {
    if (obj != null) {
        var itemRow = ManPlanTrabajo.dtManGrillaPaging.row($(obj).parents('tr')).data();
        var cod_paspeq_plan_trabajo = itemRow.cod_paspeq_plan_trabajo;
        var mes_focalizacion = itemRow.mes_focalizacion;
        var periodo = itemRow.periodo;
        var aprobado = itemRow.aprobado;
        if (aprobado != 'Sí') {
            var option = {
                url: urlLocalSigo + "PlanFocalizacion/Focalizacion/_PlanTrabajoAprobar",
                divId: "manPlanTrabajoModal",
                datos: { cod_paspeq_plan_trabajo: cod_paspeq_plan_trabajo, mes_focalizacion: mes_focalizacion, periodo: periodo }
            };
            utilSigo.fnOpenModal(option);
        }
    }
}
ManPlanTrabajo.fnControlCalidad = function (obj) {
    if (obj !== null) {
        let itemRow = ManPlanTrabajo.dtManGrillaPaging.row($(obj).parents('tr')).data();
        let cod_paspeq_plan_trabajo = itemRow.cod_paspeq_plan_trabajo;
        let option = {
            url: urlLocalSigo + "PlanFocalizacion/Focalizacion/_Calidad",
            divId: "manControlCalidadModal",
            datos: { cod_paspeq_plan_trabajo: cod_paspeq_plan_trabajo }
        };
        utilSigo.fnOpenModal(option);
    }
};
ManPlanTrabajo.fnLoadPlanTrabajoDetalle = function (cod_paspeq_plan_trabajo, periodo, mes_focalizacion,od) {
    var url = urlLocalSigo + "PlanFocalizacion/Focalizacion/_PlanTrabajoDetalle";
    var option = { url: url, datos: { cod_paspeq_plan_trabajo: cod_paspeq_plan_trabajo, periodo: periodo, mes_focalizacion: mes_focalizacion,od:od }, dataType: 'html' };
    utilSigo.fnAjax(option, function (data) {
        $("#divPlanTrabajoDetalle").html(data);
        ManPlanTrabajo.fnShowHide(1);
    });
}
ManPlanTrabajo.fnShowHide = function (opcion) {
    if (opcion == 1) {
        $("#divPlanTrabajoDetalle").slideDown();
        $("#divPlanTrabajo").slideUp();
    }
    else {
        $("#divPlanTrabajo").slideDown();
        $("#divPlanTrabajoDetalle").slideUp();
    }
}
ManPlanTrabajo.fnSearch = function () {
    var valorBusqueda = ManPlanTrabajo.frm.find("#txtValorBuscar").val().trim();
    var valorCboOpcion = ManPlanTrabajo.frm.find("#ddlOpcionBuscarPeriodo").val();
    if (valorBusqueda.trim() == "") {
        utilSigo.toastWarning("Aviso", "Ingrese un periodo a buscar");
        ManPlanTrabajo.frm.find("#txtValorBuscar").focus();
        return false;
    }
    else {
        var cantCarateres = valorBusqueda.length;
        if (cantCarateres != 4) {
            utilSigo.toastWarning("Aviso", "Debe ingresar un año en cuatro dígitos");
            ManPlanTrabajo.frm.find("#txtValorBuscar").focus();
            return false;
        }
        ManPlanTrabajo.dtManGrillaPaging.ajax.reload();
    }
}
ManPlanTrabajo.initEventos = function () {
    ManPlanTrabajo.frm.submit(function (e) {
        e.preventDefault();
        ManPlanTrabajo.fnSearch();
    });
}
$(document).ready(function () {
    //ManPlanTrabajo.fnLoadManGrillaPaging();
    $.fn.select2.defaults.set("theme", "bootstrap4");
    ManPlanTrabajo.frm = $("#frmManGrillaPaging");
    ManPlanTrabajo.frm.find("#ddlOpcionBuscarOD").select2();
    ManPlanTrabajo.frm.find("#ddlOpcionBuscarPeriodo").select2();
    ManPlanTrabajo.initEventos();
    ManPlanTrabajo.dtManGrillaPaging = ManPlanTrabajo.fnBuildTable();

});