"use strict";
var _manPaspeqEliminar = {
    fnSave: () => {
        var url = urlLocalSigo + "PlanFocalizacion/Paspeq/EliminarPaspeq";
        var num_paspeq = _manPaspeqEliminar.frm.find("#num_paspeq").val();
        var periodo = _manPaspeqEliminar.frm.find("#periodo").val();
        var model = { num_paspeq: num_paspeq, periodo: periodo };
        var option = { url: url, datos: JSON.stringify(model), type: 'POST' };
        utilSigo.fnAjax(option, function (data) {
            if (data.success) {
                utilSigo.toastSuccess("Aviso", data.msj);
                _manPaspeqEliminar.fnClose();
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
        _manPaspeqEliminar.frm = $("#frmManPaspeqEliminar");
    }
};
$(function () {
    _manPaspeqEliminar.fnInit();
});