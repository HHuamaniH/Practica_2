"use strict";
var MancambiarPass = {

    fnSubmit: () => {
        MancambiarPass.frm.submit();
    },
    fnSave: () => {
        var url = urlLocalSigo + "Seguridad/Usuario/SaveUsuariocambiarPass";
        var model = MancambiarPass.frm.serializeObject();      
        var option = { url: url, datos: JSON.stringify(model), type: 'POST' };
        utilSigo.fnAjax(option, function (data) {
            if (data.success) {
                utilSigo.toastSuccess("Aviso", data.msj);
                MancambiarPass.fnClose();          
            }
            else {
                utilSigo.toastWarning("Aviso", data.msj);
            }
        });
    },
    fnClose: () => {
        utilSigo.fnCloseModal("manModalHeader");
    },
    fnInit: () => {
        MancambiarPass.frm = $("#frmcambiarPass");

    },
    fnCustomValid: () => {
        //if (!utilSigo.fnValidateForm_HideControl(ManUsuario_AddEdit.frm, ManUsuario_AddEdit.frm.find("#codPersona"), ManUsuario_AddEdit.frm.find("#iconPersona"), false)) {
        //    return false;
        //}
        return true;
    },
    fnvalidar_clave: (contrasenna) => {

        if ($("#passwordN").val() != $("#passwordR").val()) {
            utilSigo.toastWarning("Aviso", "Las contraseñas nuevas ingresadas no coinciden");
            return false;
        }

        if (contrasenna.length >= 8) {
            var mayuscula = false;
            var minuscula = false;
            var numero = false;

            for (var i = 0; i < contrasenna.length; i++) {
                if (contrasenna.charCodeAt(i) >= 65 && contrasenna.charCodeAt(i) <= 90) {
                    mayuscula = true;
                }
                else if (contrasenna.charCodeAt(i) >= 97 && contrasenna.charCodeAt(i) <= 122) {
                    minuscula = true;
                }
                else if (contrasenna.charCodeAt(i) >= 48 && contrasenna.charCodeAt(i) <= 57) {
                    numero = true;
                }
            }
            if (contrasenna.length < 8) {
                utilSigo.toastWarning("Aviso", "La contraseña debe ser mayor o igual a 8 carácteres");
                return false;;
            } else if (mayuscula == false) {
                utilSigo.toastWarning("Aviso", "La contraseña no contiene mayúscula");
                return false;;
            } else if (minuscula == false) {
                utilSigo.toastWarning("Aviso", "La contraseña no contiene minúscula");
                return false;;
            } else if (numero == false) {
                utilSigo.toastWarning("Aviso", "La contraseña no contiene número");
                return false;;
            }
            return true;
        } else {
            utilSigo.toastWarning("Aviso", "La longitud es menor a 8 caracteres");
            return false;
        }

    }
};
$(function () {
    MancambiarPass.fnInit();
    MancambiarPass.frm.validate(utilSigo.fnValidate({

        fnSubmit: function (form) {
            if (!MancambiarPass.fnCustomValid()) return false;
            if (!MancambiarPass.fnvalidar_clave($('#passwordN').val())) return false;
            utilSigo.dialogConfirm('', 'Desea continuar con la operación?', function (r) {
                if (r) {
                    MancambiarPass.fnSave();
                }
            });
        }
    }));
});

