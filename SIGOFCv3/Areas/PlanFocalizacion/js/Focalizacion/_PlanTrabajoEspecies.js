/// <reference path="../../../../scripts/sigo/utility.sigo.js" />
/// <reference path="../../../../scripts/sigo/init.sigo.js" />

"use strict";
var _PlanTrabajoEspecies = {
    fnBuildTable: (data, tbName) => {

        var table = $('#' + tbName);
        var tabla = table.children('tbody');
        tabla.children('tr').remove();
        var rows = '';
        var numero = 0;
        $.each(data, (i, r) => {
                rows += '<tr>';
                rows += '<td>' + `${++numero}` + '</td>';
                rows += '<td>' + `${r.especie}` + '</td>';
                rows += '<td>' + `${r.cantidad_aprobada}` + '</td>';
                rows += '<td>' + `${r.volumen_aprobado}` + '</td>';
                rows += '<td>' + `${r.aprovechables_minimo}` + '</td>';
                rows += '<td>' + `${r.semilleros_minimo}` + '</td>';
                rows += '<td>' + `${r.aprovechables_supervisar}` + '</td>';
                rows += '<td>' + `${r.semilleros_supervisar}` + '</td>';
                rows += '<td>' + `${r.total}` + '</td>';
                rows += '<td><i class="fa fa-lg fa-pencil-square-o" style="color:red;cursor:pointer;" title="Edición" onclick="_PlanTrabajoEspecies.fnEspecieEdit(this)"></i></td>';
                rows += '</tr>';
        });
        tabla.append(rows);

    },
    fnBuildTableItems: () => {
        let columns = [
            {
                "name": "ROW_INDE", "width": "2%", "orderable": false, "mRender": function (data, type, row, meta) {
                    return parseInt(meta.row) + 1;
                }
            },
            { "data": "especie", "autoWidth": true },
            { "data": "cantidad_aprobada", "autoWidth": true },
            { "data": "volumen_aprobado", "autoWidth": true, "orderable": false },
            { "data": "aprovechables_minimo", "autoWidth": true, "orderable": false },
            { "data": "semilleros_minimo", "autoWidth": true, "orderable": false },
            { "data": "aprovechables_supervisar", "autoWidth": true, "orderable": false },
            { "data": "semilleros_supervisar", "autoWidth": true, "orderable": false },
            { "data": "total", "autoWidth": true, "orderable": false },
            {
                "data": "", "width": "2%", "orderable": false, "searchable": false, "mRender": function (data, type, row) {
                    return '<i class="fa fa-lg fa-pencil-square-o" style="color:red;cursor:pointer;" title="Edición" onclick="_PlanTrabajoEspecies.fnEspecieEdit(this)"></i>';
                }
            }
        ];
        return $("#tbListPlanTrabajoEspecies").DataTable({
            "bProcessing": true,
            "bServerSide": false,
            searching: false,
            ordering: false,
            paging:false,
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
        let cod_paspeq_detalle_mensual = _PlanTrabajoEspecies.fm.find("#cod_paspeq_detalle_mensual").val();
        let url = urlLocalSigo + "PlanFocalizacion/Focalizacion/GetListEspecies?";
        var urlB = url + "cod_paspeq_detalle_mensual=" + cod_paspeq_detalle_mensual;
        _PlanTrabajoEspecies.dt.ajax.url(urlB).load(function (data) {
            if (data.success === false) {
                utilSigo.toastError("Error", initSigo.MessageError);
                console.log(data.e);
            }
        });
    },
    fnEspecieEdit: (obj) => {
        var cod_paspeq_detalle_mensual = "";
        var cod_paspeq_plan_trabajo_especies = "";
        var especie = "";
        var cod_especies = "";
        var aprovechables_supervisar = "";
        var semilleros_supervisar = "";
        if (obj != null) {
            var itemRow = _PlanTrabajoEspecies.dt.row($(obj).parents('tr')).data();
            console.log(itemRow);
            cod_paspeq_plan_trabajo_especies = itemRow.cod_paspeq_plan_trabajo_especies;
            cod_paspeq_detalle_mensual = itemRow.cod_paspeq_detalle_mensual;
            especie = itemRow.especie;
            cod_especies = itemRow.cod_especies;
            aprovechables_supervisar = itemRow.aprovechables_supervisar;
            semilleros_supervisar = itemRow.semilleros_supervisar;
            var option = {
                url: urlLocalSigo + "PlanFocalizacion/Focalizacion/_PlanTrabajoEspeciesEdit",
                divId: "manEspecieModal",
                datos: { cod_especies: cod_especies, cod_paspeq_plan_trabajo_especies: cod_paspeq_plan_trabajo_especies, cod_paspeq_detalle_mensual: cod_paspeq_detalle_mensual, especie: especie, aprovechables_supervisar: aprovechables_supervisar, semilleros_supervisar: semilleros_supervisar }
            };
            utilSigo.fnOpenModal(option);
        }
    },
    GetListEspecies: (dataEnviar) => {
        var url = urlLocalSigo + "PlanFocalizacion/Focalizacion/GetListEspecies";
        var option = { url: url, datos: JSON.stringify(dataEnviar), type: 'GET' };
        utilSigo.fnAjax(option, function (data) {
            if (data.success) {
                _PlanTrabajoEspecies.lstEspecies = data.data;
                _PlanTrabajoEspecies.fnBuildTable(_PlanTrabajoEspecies.lstEspecies, "tbListPlanTrabajoEspecies");
            }
            else {
                utilSigo.toastWarning("Aviso", initSigo.MessageError);
                console.log(data.msjError);
            }
        });
    },
    fnEvent: () => {
        $("#btnRegresarPlanManejo").click(function () {
            _PlanTrabajoDetalle.fnShowHide(0);
        });
    },
    fnInit: () => {
        $.fn.select2.defaults.set("theme", "bootstrap4");
        _PlanTrabajoEspecies.fm = $("#frmPlanTrabajoEspecies");
        _PlanTrabajoEspecies.fnEvent();
        //iniciando tablas     
        //console.log(_PlanTrabajoEspecies.fm.find("#cod_paspeq_detalle_mensual").val());
        //_PlanTrabajoEspecies.GetListEspecies({ cod_paspeq_detalle_mensual: _PlanTrabajoEspecies.fm.find("#cod_paspeq_detalle_mensual").val() });
        _PlanTrabajoEspecies.dt = _PlanTrabajoEspecies.fnBuildTableItems();
        _PlanTrabajoEspecies.fnRefresh();
    }
};
$(function () {
    _PlanTrabajoEspecies.fnInit();
});