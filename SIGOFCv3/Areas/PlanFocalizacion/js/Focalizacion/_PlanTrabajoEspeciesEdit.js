"use strict";
var _PlanTrabajoEspeciesEdit = {
    fnSave: () => {
        var url = urlLocalSigo + "PlanFocalizacion/Focalizacion/EspecieEdicion";
        var cod_paspeq_plan_trabajo_especies = _PlanTrabajoEspeciesEdit.frm.find("#cod_paspeq_plan_trabajo_especies").val();
        var cod_paspeq_detalle_mensual = _PlanTrabajoEspeciesEdit.frm.find("#cod_paspeq_detalle_mensual").val();
        var aprovechables_supervisar = _PlanTrabajoEspeciesEdit.frm.find("#aprovechables_supervisar").val();
        var semilleros_supervisar = _PlanTrabajoEspeciesEdit.frm.find("#semilleros_supervisar").val();
        var cod_especies = _PlanTrabajoEspeciesEdit.frm.find("#cod_especies").val();
        var model = { cod_especies: cod_especies, cod_paspeq_detalle_mensual: cod_paspeq_detalle_mensual, cod_paspeq_plan_trabajo_especies: cod_paspeq_plan_trabajo_especies, aprovechables_supervisar: aprovechables_supervisar, semilleros_supervisar: semilleros_supervisar };
        var option = { url: url, datos: JSON.stringify(model), type: 'POST' };
        utilSigo.fnAjax(option, function (data) {
            if (data.success) {
                utilSigo.toastSuccess("Aviso", data.msj);
                _PlanTrabajoEspeciesEdit.fnClose();
                _PlanTrabajoEspecies.fnRefresh();
                //_PlanTrabajoEspecies.GetListEspecies({ cod_paspeq_detalle_mensual: cod_paspeq_detalle_mensual });
            }
            else {
                utilSigo.toastWarning("Aviso", data.msj);
            }
        });
    },
    fnClose: () => {
        utilSigo.fnCloseModal("manEspecieModal");
    },
    fnInit: () => {
        _PlanTrabajoEspeciesEdit.frm = $("#frmManPlanTrabajoEspecie");
    }
};
$(function () {
    _PlanTrabajoEspeciesEdit.fnInit();
});