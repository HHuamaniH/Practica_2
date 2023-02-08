"use strict";
var ManUsuario_AddEdit = {
    fnBuscarPersona: () => {
        var url = urlLocalSigo + "General/Controles/_BuscarPersonaGeneral";
        var option = { url: url, type: 'GET', datos: { asBusGrupo: "PERSONA", asCodPTipo: "TODOS", asTipoPersona: "N" }, divId: "mdlBuscarPersona" };
        utilSigo.fnOpenModal(option, function () {
            _bPerGen.fnAsignarDatos = function (obj) {
                if (obj != null && obj != "") {                   
                    var data = _bPerGen.dtBuscarPerona.row($(obj).parents('tr')).data();
                    ManUsuario_AddEdit.frm.find("#codPersona").val(data["COD_PERSONA"]);
                    ManUsuario_AddEdit.frm.find("#desPersona").val(data["PERSONA"]);
                    utilSigo.fnCloseModal("mdlBuscarPersona");
                    ManUsuario_AddEdit.fnCustomValid();
                }
            }
            _bPerGen.fnInit();
        });
    },
    fnSubmit: () => {
        ManUsuario_AddEdit.frm.submit();
    },
    fnSave: () => {
        var url = urlLocalSigo + "Seguridad/Usuario/SaveUsuario";
        var model = ManUsuario_AddEdit.frm.serializeObject();        
        model.activo = utilSigo.fnGetValChk(ManUsuario_AddEdit.frm.find("#activo"));
        model.esPublico = utilSigo.fnGetValChk(ManUsuario_AddEdit.frm.find("#esPublico"));        
        model.modPassword = utilSigo.fnGetValChk(ManUsuario_AddEdit.frm.find("#modPassword"));
        model.remPassword = utilSigo.fnGetValChk(ManUsuario_AddEdit.frm.find("#remPassword"));        
        var option = { url: url, datos: JSON.stringify(model), type: 'POST' };
        utilSigo.fnAjax(option, function (data) {
            if (data.success) {
                 utilSigo.toastSuccess("Aviso", data.msj);
                ManUsuario_AddEdit.fnClose();
                _ManGrillaPaging.fnRefresh();
            }
            else {
                utilSigo.toastWarning("Aviso", data.msj);
            }
        });
    },
    fnClose: () => {
        utilSigo.fnCloseModal("mdlManUsuario_Global");
    },
    fnInit: () => {
        ManUsuario_AddEdit.frm = $("#frmManUsuario_AddEdit");
        if (!utilSigo.fnGetValChk(ManUsuario_AddEdit.frm.find("#activo"))) ManUsuario_AddEdit.frm.find("#lblCheckActtivo").text("Inactivo");
        var id = ManUsuario_AddEdit.frm.find("#id").val().trim();
        if (id != "") {
            ManUsuario_AddEdit.frm.find("#divMod").show();
            ManUsuario_AddEdit.frm.find("#divP1").hide();
            ManUsuario_AddEdit.frm.find("#divP2").hide();
            ManUsuario_AddEdit.frm.find("#divRem").hide();
        }
        ManUsuario_AddEdit.frm.find("#activo").click(function () {
            if ($(this).is(":checked")) {
                ManUsuario_AddEdit.frm.find("#lblCheckActivo").text("Activo");
            }
            else {
                ManUsuario_AddEdit.frm.find("#lblCheckActivo").text("Inactivo");
            }
        });
        ManUsuario_AddEdit.frm.find("#modPassword").click(function () {
            ManUsuario_AddEdit.frm.find("#password").val('');
            ManUsuario_AddEdit.frm.find("#passwordR").val('');
            ManUsuario_AddEdit.frm.find("#remPassword").prop("checked", false)
            if ($(this).is(":checked")) {
                ManUsuario_AddEdit.frm.find("#divP1").show();
                ManUsuario_AddEdit.frm.find("#divP2").show();
                ManUsuario_AddEdit.frm.find("#divRem").show();
            }
            else {
                ManUsuario_AddEdit.frm.find("#divP1").hide();
                ManUsuario_AddEdit.frm.find("#divP2").hide();
                ManUsuario_AddEdit.frm.find("#divRem").hide();
            }
        });
    },
    fnCustomValid: () => {
        if (!utilSigo.fnValidateForm_HideControl(ManUsuario_AddEdit.frm, ManUsuario_AddEdit.frm.find("#codPersona"), ManUsuario_AddEdit.frm.find("#iconPersona"), false)) {
            return false;
        }
        return true;
    }
};
$(function () {
    ManUsuario_AddEdit.fnInit();
    jQuery.validator.addMethod("invalidfrmUsuario", function (value, element) {
        var idUsuario = ManUsuario_AddEdit.frm.find("#id").val().trim();
        switch ($(element).attr('id')) {
            case 'password':
                if (idUsuario == "") { return (value.trim() == '') ? false : true; }
                else {
                    if (utilSigo.fnGetValChk(ManUsuario_AddEdit.frm.find("#modPassword"))) {
                        return (value.trim() == '') ? false : true;
                    }
                    else {
                        return true;
                    }
                }
                break;
            case 'passwordR':
                if (idUsuario == "") { return (value.trim() == '') ? false : true; }
                else {
                    if (utilSigo.fnGetValChk(ManUsuario_AddEdit.frm.find("#modPassword"))) {
                        return (value.trim() == '') ? false : true;
                    }
                    else {
                        return true;
                    }
                }
                break
        }
    });
    jQuery.validator.addMethod("minlenfrmUsuario", function (value, element) {
        var idUsuario = ManUsuario_AddEdit.frm.find("#id").val().trim();
        switch ($(element).attr('id')) {
            case 'usuario':
                  return (value.trim().length < 4) ? false : true;                 
                  break;
            case 'password':
                if (idUsuario == "") { return (value.trim().length < 4) ? false : true; }
                else {
                    if (utilSigo.fnGetValChk(ManUsuario_AddEdit.frm.find("#modPassword"))) {
                        return (value.trim().length <4) ? false : true;
                    }
                    else {
                        return true;
                    }
                }
                break;
            case 'passwordR':
                if (idUsuario == "") { return (value.trim().length < 4) ? false : true; }
                else {
                    if (utilSigo.fnGetValChk(ManUsuario_AddEdit.frm.find("#modPassword"))) {
                        return (value.trim().length<4) ? false : true;
                    }
                    else {
                        return true;
                    }
                }
                break
        }
    });
    ManUsuario_AddEdit.frm.validate(utilSigo.fnValidate({
        rules: {
            usuario: { required: true, minlenfrmUsuario:true },
            password: { invalidfrmUsuario: true, minlenfrmUsuario:true },
            passwordR: { invalidfrmUsuario: true, minlenfrmUsuario: true }
        },
        messages: {
            usuario: { required: "Ingrese Usuario", minlenfrmUsuario: "Ingrese usuario mayor a 3 caracteres"},
            password: { invalidfrmUsuario: "Ingrese Clave", minlenfrmUsuario:"Ingrese clave mayor a 3 caracteres" },
            passwordR: { invalidfrmUsuario: "Ingrese Clave", minlenfrmUsuario:"Ingrese clave mayor a 3 caracteres"}
        },
        fnSubmit: function (form) {
            if (!ManUsuario_AddEdit.fnCustomValid()) return false;
            utilSigo.dialogConfirm('', 'Desea continuar con la operación?', function (r) {
                if (r) {
                    ManUsuario_AddEdit.fnSave();
                }
            });
        }
    }));
});