"use strict";
var ManterminosUso = {

    fnSubmit: () => {
        ManterminosUso.frm.submit();
    },
    fnSave: () => {
        var url = urlLocalSigo + "Seguridad/Usuario/SaveUsuarioterminosUso";
        var model = ManterminosUso.frm.serializeObject();
        var option = { url: url, datos: JSON.stringify(model), type: 'POST' };
        utilSigo.fnAjax(option, function (data) {
            if (data.success) {
        //        utilSigo.toastSuccess("Aviso", data.msj);
                ManterminosUso.fnClose();
            }
        //    else {
        //        utilSigo.toastWarning("Aviso", data.msj);
        //    }
        });
    },
    fnClose: () => {
        utilSigo.fnCloseModal("manterminosUsoHeader");
    },
    fnInit: () => {
        ManterminosUso.frm = $("#frmterminosUso");

    },
    fnCustomValid: () => {
        //if (!utilSigo.fnValidateForm_HideControl(ManUsuario_AddEdit.frm, ManUsuario_AddEdit.frm.find("#codPersona"), ManUsuario_AddEdit.frm.find("#iconPersona"), false)) {
        //    return false;
        //}
        return true;
    }
};
$(function () {
    ManterminosUso.fnInit();
    ManterminosUso.frm.validate(utilSigo.fnValidate({

        fnSubmit: function (form) {
            if (!ManterminosUso.fnCustomValid()) return false;
            ManterminosUso.fnSave();
        }
    }));
});
