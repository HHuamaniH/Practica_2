"use strict";
var _manPlanTrabajoAprobar = {
    fnSave: () => {
        var url = urlLocalSigo + "PlanFocalizacion/Focalizacion/AprobarPlanTrabajo";
        var cod_paspeq_plan_trabajo = _manPlanTrabajoAprobar.frm.find("#cod_paspeq_plan_trabajo").val();
        var model = { cod_paspeq_plan_trabajo: cod_paspeq_plan_trabajo };
        var option = { url: url, datos: JSON.stringify(model), type: 'POST' };
        utilSigo.fnAjax(option, function (data) {
            if (data.success) {
                utilSigo.toastSuccess("Aviso", data.msj);
                _manPlanTrabajoAprobar.fnClose();
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
        _manPlanTrabajoAprobar.frm = $("#frmManPlanTrabajoAprobar");
    }
};
$(function () {
    _manPlanTrabajoAprobar.fnInit();
});