"use strict";
var _manPlanTrabajo = {
    fnSave: () => {
        var url = urlLocalSigo + "PlanFocalizacion/Focalizacion/CreatePlanTrabajo";
        var model = _manPlanTrabajo.frm.serializeObject();
        var option = { url: url, datos: JSON.stringify(model), type: 'POST' };
        utilSigo.fnAjax(option, function (data) {
            if (data.success) {
                utilSigo.toastSuccess("Aviso", data.msj);
                _manPlanTrabajo.fnClose();
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
        _manPlanTrabajo.frm = $("#frmManPlanTrabajo");
    }
};
$(function () {
    _manPlanTrabajo.fnInit();
});