/// <reference path="../../../../scripts/sigo/utility.sigo.js" />
/// <reference path="../../../../scripts/sigo/init.sigo.js" />

"use strict";
var _PlanTrabajoDetalle = {
    fnBuildTable: (data, tbName) => {

        var table = $('#' + tbName);
        var tabla = table.children('tbody');
        tabla.children('tr').remove();
        var rows = '';
        var numero = 0;
        $.each(data, (i, r) => {
            if (r.resultado == 1) {
                rows += '<tr>';
                rows += '<td>' + `${++numero}` + '</td>';
                rows += '<td>' + `${r.titular}` + '</td>';
                rows += '<td>' + `${r.titulo_habilitante}` + '</td>';
                rows += '<td>' + `${r.modalidad}` + '</td>';
                rows += '<td>' + `${r.plan_manejo}` + '</td>';
                rows += '<td>' + `${r.departamento}` + '</td>';
                rows += '<td>' + `${r.provincia}` + '</td>';
                rows += '<td>' + `${r.distrito}` + '</td>';
                rows += '<td>' + `${r.tipo_supervision}` + '</td>';
                rows += '<td>' + `${r.criterios_focalizacion}` + '</td>';
                rows += '<td>' + `${r.oportunidad}` + '</td>';
                rows += '<td></td>';
                rows += '</tr>';
            }
        });
        tabla.append(rows);

    },
    GetListPlanTrabajo: (dataEnviar) => {
        var url = urlLocalSigo + "PlanFocalizacion/Focalizacion/GetListPlanTrabajo";
        var option = { url: url, datos: JSON.stringify(dataEnviar), type: 'POST' };
        utilSigo.fnAjax(option, function (data) {
            if (data.success) {
                _PlanTrabajoDetalle.lstPlanManejo = data.data; 
                _PlanTrabajoDetalle.fnBuildTable(_PlanTrabajoDetalle.lstPlanManejo, "tbListPlanManejo");
            }
            else {
                utilSigo.toastWarning("Aviso", initSigo.MessageError);
                console.log(data.msjError);
            }
        });
    },
    fnEspeciesEdit: (obj) => {
        var cod_paspeq_detalle_mensual = "";
        var num_thabilitante = "";
        var nombre_poa = "";
        if (obj != null) {
            var itemRow = _PlanTrabajoDetalle.dt.row($(obj).parents('tr')).data();
            console.log(itemRow);
            cod_paspeq_detalle_mensual = itemRow.COD_PASPEQ_DETALLE_MENSUAL;
            num_thabilitante = itemRow.TITULO_HABILITANTE;
            nombre_poa = itemRow.PLAN_MANEJO;
            _PlanTrabajoDetalle.fnLoadPlanTrabajoEspecies(cod_paspeq_detalle_mensual, num_thabilitante, nombre_poa);
        }
    },
    fnLoadPlanTrabajoEspecies: (cod_paspeq_detalle_mensual, num_thabilitante, nombre_poa) => {
        var url = urlLocalSigo + "PlanFocalizacion/Focalizacion/_PlanTrabajoEspecies";
        var option = { url: url, datos: { cod_paspeq_detalle_mensual: cod_paspeq_detalle_mensual, num_thabilitante: num_thabilitante, nombre_poa: nombre_poa }, dataType: 'html' };
        utilSigo.fnAjax(option, function (data) {
            $("#divPlanTrabajoEspecies").html(data);
            _PlanTrabajoDetalle.fnShowHide(1);
        });
    },
    fnBuildTableItems: () => {
        let columns = [    
            {
                "data": "", "width": "2%", "orderable": false, "searchable": false, "mRender": function (data, type, row) {
                    if (row.MADERABLE == "M") {
                        return '<i class="fa fa-lg fa-pencil-square-o" style="color:red;cursor:pointer;" title="Detalle de Especies" onclick="_PlanTrabajoDetalle.fnEspeciesEdit(this)"></i>';
                    }
                    else
                    {
                        return "";
                    }
                }
            },
            {
                "name": "ROW_INDE", "width": "2%", "orderable": false, "mRender": function (data, type, row, meta) {
                    return parseInt(meta.row) + 1;
                }
            },             
            { "data": "TITULAR", "autoWidth": true },
            { "data": "TITULO_HABILITANTE", "autoWidth": true },
            { "data": "MODALIDAD", "autoWidth": true, "orderable": false },
            { "data": "PLAN_MANEJO", "autoWidth": true, "orderable": false },
            { "data": "DEPARTAMENTO", "autoWidth": true, "orderable": false },
            { "data": "PROVINCIA", "autoWidth": true, "orderable": false },
            { "data": "DISTRITO", "autoWidth": true, "orderable": false },
            { "data": "TIPO_SUPERVISION", "autoWidth": true, "orderable": false },
            {
                "data": "", "width": "2%", "autoWidth": false,"orderable": false, "searchable": false, "mRender": function (data, type, row) {
                    return row.CRITERIOS_FOCALIZACION;
                }
            }, 
            { "data": "OPORTUNIDAD", "autoWidth": true, "orderable": false },
            {
                "data": "", "width": "2%", "orderable": false, "searchable": false, "mRender": function (data, type, row) {
                    return '<i class="fa fa-lg fa-window-close" style="color:red;cursor:pointer;" title="Eliminar Item" onclick="_PlanTrabajoDetalle.fnDeleteItem(this)"></i>';
                }
            }             
        ];
        return $("#tbListPlanTrabajo").DataTable({
            "bProcessing": true,
            "bServerSide": false,
            searching: true,
            ordering: false,
            "deferLoading": 0,
            //"bAutoWidth": false,
            
           // "bJQueryUI": false,
            //"bFilter": false,
            "columns": columns,
            "bInfo": true,
            "lengthMenu": [[10, 20, 50, 100], [10, 20, 50, 100]],
            "aaSorting": [],
            //"bPaginate": true, 
            "pageLength": 10,
           // "bLengthChange": false,             
            "oLanguage": initSigo.oLanguage,            
            "drawCallback": initSigo.showPagination
        });
    },
    fnRefresh: () => {
        let COD_PASPEQ_PLAN_TRABAJO_ID = _PlanTrabajoDetalle.fm.find("#cod_paspeq_plan_trabajo").val();
        let url = urlLocalSigo + "PlanFocalizacion/Focalizacion/planTrabajoItemsListar?";
        var urlB = url + "cod_paspeq_plan_trabajo=" + COD_PASPEQ_PLAN_TRABAJO_ID;
        _PlanTrabajoDetalle.dt.ajax.url(urlB).load(function (data) {
            if (data.success === false) {
                utilSigo.toastError("Error", initSigo.MessageError);
                console.log(data.e);
            }            
        });
    },
    fnShowHide: (opcion) => {
        if (opcion == 1) {
            $("#divPlanTrabajoEspecies").slideDown();
            $("#divPlanTrabajoDetalle").slideUp();
        }
        else {
            $("#divPlanTrabajoDetalle").slideDown();
            $("#divPlanTrabajoEspecies").slideUp();
        }
    },
    fnEvent: () => {
        $("#btnRegresarPlanTrabajo").click(function () {
            ManPlanTrabajo.fnShowHide(0);
        });
    },
    fnInit: () => {
        $.fn.select2.defaults.set("theme", "bootstrap4");
        _PlanTrabajoDetalle.fm = $("#frmPlanTrabajoDetalle");
        _PlanTrabajoDetalle.fnEvent();
        //iniciando tablas                
        //_PlanTrabajoDetalle.GetListPlanTrabajo({ cod_paspeq_plan_trabajo: _PlanTrabajoDetalle.fm.find("#cod_paspeq_plan_trabajo").val() });
        _PlanTrabajoDetalle.dt = _PlanTrabajoDetalle.fnBuildTableItems();
        _PlanTrabajoDetalle.fnRefresh();
    },
    fnOpenPlan: () => {
        let option = {
            url: urlLocalSigo + "PlanFocalizacion/Focalizacion/_PlanManejoAdd",
            divId: "manAddPlanManejoModal",
            datos: {}
        };
        utilSigo.fnOpenModal(option);
    },
    fnOpenPlanExtra: () => {
        let option = {
            url: urlLocalSigo + "PlanFocalizacion/Focalizacion/_PlanManejoAddExtra",
            divId: "manAddPlanManejoModal",
            datos: {}
        };
        utilSigo.fnOpenModal(option);
    },
    fnDeleteItem: (obj) => {
        var itemRow = _PlanTrabajoDetalle.dt.row($(obj).parents('tr')).data();
        //console.log(itemRow);
        utilSigo.dialogConfirm('', 'Esta seguro de eliminar el Items ?', function (r) {
            if (r) {
                var url = urlLocalSigo + "PlanFocalizacion/Focalizacion/deletePlanTrabajoItem";
                var option = { url: url, datos: JSON.stringify({ cod_paspeq_detalle_mensual: itemRow.COD_PASPEQ_DETALLE_MENSUAL }), type: 'POST' };
                utilSigo.fnAjax(option, function (data) {
                    if (data.success) {
                        utilSigo.toastSuccess("Aviso", data.msj);
                        _PlanTrabajoDetalle.fnRefresh();
                    }
                    else {
                        utilSigo.toastWarning("Aviso", data.msj);                        
                    }
                });
            }
        });   
    },
    fnDownload: (obj) => {
        let id = _PlanTrabajoDetalle.fm.find("#cod_paspeq_plan_trabajo").val();
        let od = _PlanTrabajoDetalle.fm.find("#hdSede").val();
        let mes = _PlanTrabajoDetalle.fm.find("#hdMes").val() + " - " + _PlanTrabajoDetalle.fm.find("#hdPeriodo").val();
        let url = urlLocalSigo + "PlanFocalizacion/Focalizacion/DownloadPlanTrabajoItems?cod_paspeq_plan_trabajo="+id+"&od="+od+"&mes="+mes;
        var xhr = new XMLHttpRequest();
        xhr.onload = function () {
            if (xhr.readyState === 4 && xhr.status === 200) {
                window.location.href = url;
            }
            else if (xhr.status === 404) {
                utilSigo.toastWarning("Aviso", "Sucedio un error, No existe la direccion de descarga");
            }
            else if (xhr.status === 0) {
                utilSigo.toastWarning("Aviso", "Sucedio un error, No existe el archivo");
            }
            else {
                utilSigo.toastWarning("Aviso", "Sucedio un error al descargar el archivo, Comuníquese con el Administrador");
            }
        };
        xhr.open('head', url);
        xhr.send(null);    
    },
    fnDownloadMuestra: (obj) => {
        let id = _PlanTrabajoDetalle.fm.find("#cod_paspeq_plan_trabajo").val();
        let od = _PlanTrabajoDetalle.fm.find("#hdSede").val();
        let mes = _PlanTrabajoDetalle.fm.find("#hdMes").val() + " - " + _PlanTrabajoDetalle.fm.find("#hdPeriodo").val();
        let url = urlLocalSigo + "PlanFocalizacion/Focalizacion/DownloadPlanTrabajoEspecies?cod_paspeq_plan_trabajo=" + id + "&od=" + od + "&mes=" + mes;
        var xhr = new XMLHttpRequest();
        xhr.onload = function () {
            if (xhr.readyState === 4 && xhr.status === 200) {
                window.location.href = url;
            }
            else if (xhr.status === 404) {
                utilSigo.toastWarning("Aviso", "Sucedio un error, No existe la direccion de descarga");
            }
            else if (xhr.status === 0) {
                utilSigo.toastWarning("Aviso", "Sucedio un error, No existe el archivo");
            }
            else {
                utilSigo.toastWarning("Aviso", "Sucedio un error al descargar el archivo, Comuníquese con el Administrador");
            }
        };
        xhr.open('head', url);
        xhr.send(null);
    }    
};
$(function () {
    _PlanTrabajoDetalle.fnInit();
});