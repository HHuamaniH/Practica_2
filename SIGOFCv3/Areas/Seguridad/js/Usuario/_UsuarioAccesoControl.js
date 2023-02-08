"use strict";
var ManUsuarioAccesoControl_AddEdit = {
    fnSubmit: () => {
        ManUsuarioAccesoControl_AddEdit.frm.submit();
    },
    fnSave: () => {
        var url = urlLocalSigo + "Seguridad/Usuario/SaveUsuarioAccesoControl";
        var model = ManUsuarioAccesoControl_AddEdit.frm.serializeObject();   
        model.accesoNoCaduca = utilSigo.fnGetValChk(ManUsuarioAccesoControl_AddEdit.frm.find("#accesoNoCaduca"));
        model.fecha_solicitud = ManUsuarioAccesoControl_AddEdit.frm.find("#fecha_solicitud").val();
        model.fecha_desde = ManUsuarioAccesoControl_AddEdit.frm.find("#fecha_desde").val();
        model.fecha_hasta = ManUsuarioAccesoControl_AddEdit.frm.find("#fecha_hasta").val();
        var option = { url: url, datos: JSON.stringify(model), type: 'POST' };
        utilSigo.fnAjax(option, function (data) {
            if (data.success) {
                utilSigo.toastSuccess("Aviso", data.msj);
                ManUsuarioAccesoControl_AddEdit.fnClose();
                _UsuarioAcceso.GetListUsuarioAcceso({ codUsuario: model.codUsuario });
            }
            else {
                utilSigo.toastWarning("Aviso", data.msj);
            }
        });
    },
    fnClose: () => {
        utilSigo.fnCloseModal("manAccesoModal");
    },
    fnInit: () => {
        ManUsuarioAccesoControl_AddEdit.frm = $("#frmManUsuarioAccesoControl_AddEdit");
        utilSigo.fnFormatDate(ManUsuarioAccesoControl_AddEdit.frm.find("#fecha_solicitud"));
        utilSigo.fnFormatDate(ManUsuarioAccesoControl_AddEdit.frm.find("#fecha_desde"));
        utilSigo.fnFormatDate(ManUsuarioAccesoControl_AddEdit.frm.find("#fecha_hasta"));
    }
};
$(function () {
    ManUsuarioAccesoControl_AddEdit.fnInit();

    ManUsuarioAccesoControl_AddEdit.frm.validate(utilSigo.fnValidate({
        rules: {
            fecha_solicitud: { required: true },
            fecha_desde: { required: true },
            fecha_hasta: { required: true }
        },
        messages: {
            fecha_solicitud: { required: "Ingrese la fecha de la solicitud" },
            fecha_desde: { required: "Ingrese la fecha de inicio" },
            fecha_hasta: { required: "Ingrese la fecha de finalización" }
        },
        fnSubmit: function (form) {
            utilSigo.dialogConfirm('', 'Desea continuar con la operación?', function (r) {
                if (r) {
                    ManUsuarioAccesoControl_AddEdit.fnSave();
                }
            });
        }
    }));
});

