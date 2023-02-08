"use strict";
var ManPaspeq = {};
ManPaspeq.fnLoadManGrillaPaging = function () {
    var url = initSigo.urlControllerGeneral + "_ManGrillaPaging";
    var data = ManPaspeq.frm.serializeObject();
    var option = { url: url, datos: JSON.stringify(data), type: 'POST', dataType: 'html' };
    var columns_label = [], columns_data = [], options = {};
    var data_extend = [
        {
            "data": "codigo", "title": "Descargar", "orderable": false, "searchable": false, "mRender": function (data, type, row, meta) {
                return '<i class="fa fa-lg fa-file-excel-o" style="cursor: pointer;color:dodgerblue;" title="Descargar excel" onclick="ManPaspeq.fnExport(this);"></i>';
            }
        },
        {
            "data": "codigo", "title": "Seleccionar", "orderable": false, "searchable": false, "mRender": function (data, type, row, meta) {
                return '<i class="fa fa-lg fa-tasks" style="cursor: pointer;color:dodgerblue;" title="Seleccionar Paspeq" onclick="ManPaspeq.fnSelectPaspeq(this);"></i>';
            }
        }
    ];
    columns_label = ["N°","Fecha de registro", "Periodo", "Selección"];
    columns_data = ["num_paspeq","fecha_creacion", "periodo", "seleccion"];
    options = {
        page_paging: true, page_length: 20, row_delete: true, row_fnDelete: "ManPaspeq.fnDelete(this)", row_index: false, row_edit: true,
        row_fnEdit: "ManPaspeq.fnAddEdit(this)", data_extend: data_extend
    };
    utilSigo.fnAjax(option, function (data) {
        ManPaspeq.frm.find("#dvListPaspeq").html(data);
        _ManGrillaPaging.fnInit(columns_label, columns_data, options);
        _ManGrillaPaging.fnCreate = function (obj, codTipoCN) {
            _ManGrillaPaging.fnReadConfigManGrillaPaging();
            ManPaspeq.fnAddEdit(null);
        }
        $("#btnDownload").hide();
    });
    
}

ManPaspeq.fnDelete = function (obj) {
    if (obj != null) {
        var itemRow = _ManGrillaPaging.dtManGrillaPaging.row($(obj).parents('tr')).data();
        var numPaspeq = itemRow.num_paspeq;
        var periodo = itemRow.periodo;
        var option = {
            url: urlLocalSigo + "PlanFocalizacion/Paspeq/_PaspeqEliminar",
            divId: "manPaspeqModal",
            datos: { num_paspeq: numPaspeq, periodo: periodo }
        };
        utilSigo.fnOpenModal(option);
    }     
}

ManPaspeq.fnAddEdit = function (obj) {
    var numPaspeq = "";
    var periodo = "";
    if (obj != null) {
        var itemRow = _ManGrillaPaging.dtManGrillaPaging.row($(obj).parents('tr')).data();
        numPaspeq = itemRow.num_paspeq;
        periodo = itemRow.periodo;
        ManPaspeq.fnLoadPaspeqDetalle(numPaspeq, periodo);
    }
    else
    {
        var option = {
            url: urlLocalSigo + "PlanFocalizacion/Paspeq/_Paspeq",
            divId: "manPaspeqModal",
            datos: {}
        };
        utilSigo.fnOpenModal(option);
    }

}
ManPaspeq.fnSelectPaspeq = function (obj) {
    if (obj != null) {
        var itemRow = _ManGrillaPaging.dtManGrillaPaging.row($(obj).parents('tr')).data();
        var numPaspeq = itemRow.num_paspeq;
        var periodo = itemRow.periodo;
        var seleccion = itemRow.seleccion;
        if (seleccion != 'Seleccionado')
        {
            var option = {
                url: urlLocalSigo + "PlanFocalizacion/Paspeq/_PaspeqSeleccion",
                divId: "manPaspeqModal",
                datos: { num_paspeq: numPaspeq, periodo: periodo }
            };
            utilSigo.fnOpenModal(option);
        }
    }
}
ManPaspeq.fnExport = function (obj) {
    var itemRow = _ManGrillaPaging.dtManGrillaPaging.row($(obj).parents('tr')).data();
    $.ajax({
        url: urlLocalSigo + "PlanFocalizacion/Paspeq/ExportarPaspeq",
        type: 'POST',
        data: { num_paspeq: itemRow.num_paspeq, periodo: itemRow.periodo },
        dataType: 'json',
        success: function (data) {
            utilSigo.unblockUIGeneral();
            if (data.success) {
                window.location.href = urlLocalSigo + "PlanFocalizacion/Paspeq/DownloadPaspeq?file=" + data.values[0];
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
ManPaspeq.fnLoadPaspeqDetalle = function (numPaspeq, periodo) {
    var url = urlLocalSigo + "PlanFocalizacion/Paspeq/_PaspeqDetalle";
    var option = { url: url, datos: { num_paspeq: numPaspeq, periodo: periodo }, dataType: 'html' };
    utilSigo.fnAjax(option, function (data) {
        $("#divPaspeqDetalle").html(data);
        ManPaspeq.fnShowHide(1);
    });
}
ManPaspeq.fnShowHide = function (opcion) {
    if (opcion == 1) {
        $("#divPaspeqDetalle").slideDown();
        $("#divPaspeq").slideUp();
    }
    else {
        $("#divPaspeq").slideDown();
        $("#divPaspeqDetalle").slideUp();
    }
}
$(document).ready(function () {
    ManPaspeq.frm = $("#frmListPaspeq");
    ManPaspeq.fnLoadManGrillaPaging();
});