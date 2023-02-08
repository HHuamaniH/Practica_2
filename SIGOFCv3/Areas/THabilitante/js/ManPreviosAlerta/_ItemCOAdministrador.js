'use strict';
var _ItemCOAdministrador = {};
(function () {
    this.urlController = urlLocalSigo + "THabilitante/ManPreviosAlerta/";
    this.RegEstado;
    this.init = (RegEstado, data) => {
        this.frm = $("#frmItemCOAdministrador");
        this.content = $("#divItemCOAdministrador");
        this.RegEstado = RegEstado;
        if (RegEstado == RegEstadoSigo.INITIAL) {
            this.initData(data);
        }


        this.initEvent();
    }
    this.initData = (data) => {
        $('#divMod').removeAttr('hidden');
        $('#divP1').attr('hidden', 'hidden');        
        $("#password").removeAttr('required');
        $("#passwordR").removeAttr('required');
        var titulo = document.getElementById('h5Titulo');
        titulo.innerHTML = 'Editar';
        this.frm.find("#lbDestinatarioPersona").val(data.DESCRIPCION);
        this.frm.find("#hdDestinatarioCod_Persona").val(data.COD_PERSONA);
        this.frm.find("#hdCodCOAdministrador").val(data.COD_UCUENTA);
        this.frm.find("#txtDestinatarioCargo").val(data.CARGO);
        this.frm.find("#txtDestinatarioCorreo").val(data.CORREO);
        this.frm.find("#txtDestinatarioDocumento").val(data.DOCUMENTO);
        this.frm.find("#txtDestinatarioOficina").val(data.OFICINA);
        this.frm.find("#cbDestinatarioEstado").val(data.ESTADO_ACTIVO);
        this.frm.find("#txtObservacion").val(data.OBSERVACION);
        this.frm.find("#usuario").val(data.USUARIO);
        this.frm.find("#password").val("");
        this.frm.find("#passwordR").val("");

        var fechaArray = data.FECHA_DOCUMENTO.split("/");
        var fecha = "";
        if (fechaArray.length > 0)
            fecha = fechaArray[2] + "-" + fechaArray[1] + "-" + (fechaArray[0].length == 1 ? "0" + fechaArray[0].toString() : fechaArray[0].toString());
      
        this.frm.find("#txtDestinatarioFechaDocumento").val(fecha);
    }
    this.initEvent = () => {
        this.configValidateForm();
        this.content.find("#btnGuardar").click(function () {
            this.save();
        }.bind(this));

    }
    this.configValidateForm = () => {
        var objValida = {

        };
        this.frm.validate(utilSigo.fnValidate(objValida));

    }
    this.validAdditional = () => {

        if ($("#hdDestinatarioCod_Persona").val() == "") {
            utilSigo.toastWarning("Aviso", "Seleccione a un funcionario");
            return false;
        }

        if ($("#password").val() != $("#passwordR").val()) {
            utilSigo.toastWarning("Aviso", "Las contraseñas ingresadas no coinciden");
            return false;
        }

        return this.validar_clave($("#password").val());

        return true;
    }

    this.validar_clave = (contrasenna) => {
        
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

    this.fnBuscarPersona = (_dom, _tipoPersonaSIGOsfc) => {
        var url = urlLocalSigo + "General/Controles/_BuscarPersonaGeneral";
        var option = { url: url, type: 'GET', datos: { asBusGrupo: "PERSONA", asCodPTipo: _tipoPersonaSIGOsfc, asTipoPersona: "N" }, divId: "mdlBuscarPersona" };
        utilSigo.fnOpenModal(option, function () {
            _bPerGen.fnAsignarDatos = function (obj) {
                if (obj != null && obj != "") {
                    var data = _bPerGen.dtBuscarPerona.row($(obj).parents('tr')).data();
                    _ItemCOAdministrador.frm.find("#codPersona").val(data["COD_PERSONA"]);
                    _ItemCOAdministrador.frm.find("#desPersona").val(data["PERSONA"]);
                    switch (_dom) {
                        case "FUNCIONARIO": _ItemCOAdministrador.fnSetPersonaCompleto(_dom, data["COD_PERSONA"]); break;
                    }
                    utilSigo.fnCloseModal("mdlBuscarPersona");
                }
            }
            _bPerGen.fnInit();
        });
    }
    this.fnSetPersonaCompleto = (_dom, codPersona) => {
        $.ajax({
            url: urlLocalSigo + "General/Controles/GetPersona",
            type: 'POST',
            data: { asCodPersona: codPersona },
            dataType: 'json',
            beforeSend: utilSigo.beforeSendAjax,
            complete: utilSigo.completeAjax,
            error: utilSigo.errorAjax,
            success: function (data) {
                if (data.success) {
                    switch (_dom) {
                        case "FUNCIONARIO":
                            _ItemCOAdministrador.frm.find("#txtDestinatarioCargo").val(data.data["CARGO"]);
                            _ItemCOAdministrador.frm.find("#hdDestinatarioCod_Persona").val(data.data["COD_PERSONA"]);
                            _ItemCOAdministrador.frm.find("#lbDestinatarioPersona").val(data.data["APELLIDOS_NOMBRES"]);
                            if (data.data["ListCorreo"].length > 0) {
                                _ItemCOAdministrador.frm.find("#txtDestinatarioCorreo").val(data.data["ListCorreo"][0]["CORREO"]);
                            }
                            break;
                    }
                } else {
                    utilSigo.toastError("Error", "No se pudo consultar los datos de la persona");
                    console.log(data.msj);
                    return false;
                }
            }
        });
    }
    this.save = () => {
        if (this.frm.valid()) {
            if (this.validAdditional()) {
                let datos = {};

                let ListCOADMINISTRADOR = [{
                    COD_UCUENTA: $("#hdCodCOAdministrador").val(),
                    COD_PERSONA: $("#hdDestinatarioCod_Persona").val(),
                    USUARIO_LOGIN: $("#usuario").val(),
                    ESTADO_ACTIVO: $("#cbEstado").val(),
                    COADMIN: 1,
                    CARGO: $("#txtDestinatarioCargo").val(),
                    CORREO: $("#txtDestinatarioCorreo").val(),
                    DOCUMENTO: $("#txtDestinatarioDocumento").val(),
                    FECHA_DOCUMENTO: $("#txtDestinatarioFechaDocumento").val(),
                    OFICINA: $("#txtDestinatarioOficina").val(),
                    OBSERVACION: $("#txtObservacion").val(),
                    USUARIO_CONTRASENA: $("#password").val()
                }];

                datos.ListCOADMINISTRADOR = ListCOADMINISTRADOR;
                datos.RegEstado = this.RegEstado;

                $.ajax({
                    url: this.urlController + "/SaveCOAdministrador",
                    type: 'POST',
                    data: JSON.stringify(datos),
                    contentType: 'application/json;charset=utf-8',
                    dataType: 'json',
                    beforeSend: utilSigo.beforeSendAjax,
                    complete: utilSigo.completeAjax,
                    error: utilSigo.errorAjax,
                    success: function (data) {
                        if (data.success) {                            
                            this.afterSave(datos);
                            this.finallySave();
                            utilSigo.toastSuccess("Aviso", data.msj);
                        }
                        else utilSigo.toastWarning("Aviso", data.msj);
                    }.bind(this)
                });


            }
        }
        else
            this.frm.validate().focusInvalid();
    }
    this.afterSave = (data) => {

    }
    this.finallySave = () => {
        this.frm[0].reset();
    }
    this.close = () => {
        this.content.closest(".modal").modal("hide");
    }
}).apply(_ItemCOAdministrador);



$(document).ready(function () {

    $("#frmItemRuta input[type=text]").keyup(function () {
        this.value = this.value.toUpperCase();
    });

    $('.custom-file-input').on('change', function (event) {
        var inputFile = event.currentTarget;
        $(inputFile).parent()
            .find('.custom-file-label')
            .html(inputFile.files[0].name);
    });

    $("#modPassword").click(function () {
        if ($(this).is(":checked")) {
            $("#divP1").removeAttr('hidden');   
            $("#password").attr('required', 'required');
            $("#passwordR").attr('required', 'required');
        }
        else {
            $("#divP1").attr('hidden', 'hidden');
            $("#password").removeAttr('required');
            $("#passwordR").removeAttr('required');
        }
    });

});