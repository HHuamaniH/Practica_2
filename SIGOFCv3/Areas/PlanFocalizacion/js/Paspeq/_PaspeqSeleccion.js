"use strict";
var _manPaspeqSeleccion = {
    fnSave: () => {
        var url = urlLocalSigo + "PlanFocalizacion/Paspeq/SeleccionarPaspeq";
        var num_paspeq = _manPaspeqSeleccion.frm.find("#num_paspeq").val();
        var periodo = _manPaspeqSeleccion.frm.find("#periodo").val();
        var model = { num_paspeq: num_paspeq, periodo: periodo };
        var option = { url: url, datos: JSON.stringify(model), type: 'POST' };
        utilSigo.fnAjax(option, function (data) {
            if (data.success) {
                utilSigo.toastSuccess("Aviso", data.msj);
                _manPaspeqSeleccion.fnClose();
                _ManGrillaPaging.fnRefresh();
            }
            else {
                utilSigo.toastWarning("Aviso", data.msj);
            }
        });
    },
    fnClose: () => {
        utilSigo.fnCloseModal("manPaspeqModal");
    },
    fnInit: () => {
        _manPaspeqSeleccion.frm = $("#frmManPaspeqSeleccion");
    }
};
$(function () {
    _manPaspeqSeleccion.fnInit();
});