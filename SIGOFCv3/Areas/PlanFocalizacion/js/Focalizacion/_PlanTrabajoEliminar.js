"use strict";
var _manPlanTrabajoEliminar = {
    fnSave: () => {
        var url = urlLocalSigo + "PlanFocalizacion/Focalizacion/EliminarPlanTrabajo";
        var cod_paspeq_plan_trabajo = _manPlanTrabajoEliminar.frm.find("#cod_paspeq_plan_trabajo").val();
        var model = { cod_paspeq_plan_trabajo: cod_paspeq_plan_trabajo };
        var option = { url: url, datos: JSON.stringify(model), type: 'POST' };
        utilSigo.fnAjax(option, function (data) {
            if (data.success) {
                utilSigo.toastSuccess("Aviso", data.msj);
                _manPlanTrabajoEliminar.fnClose();
                ManPlanTrabajo.dtManGrillaPaging.ajax.reload();
            }
            else {
                utilSigo.toastWarning("Aviso", data.msj);
            }
        });
    },
    fnClose: () => {
        utilSigo.fnCloseModal("manPlanTrabajoModal");
    },
    fnInit: () => {
        _manPlanTrabajoEliminar.frm = $("#frmManPlanTrabajoEliminar");
    }
};
$(function () {
    _manPlanTrabajoEliminar.fnInit();
});