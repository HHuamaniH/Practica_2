"use strict";
var _manPaspeq = {
    fnSave: () => {
        var url = urlLocalSigo + "PlanFocalizacion/Paspeq/CreatePaspeq";
        var option = { url: url, datos: {}, type: 'GET' };
        utilSigo.fnAjax(option, function (data) {
            if (data.success) {
                utilSigo.toastSuccess("Aviso", data.msj);
                _manPaspeq.fnClose();
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
        _manPaspeq.frm = $("#frmManPaspeq");
    }
};
$(function () {
    _manPaspeq.fnInit();
});