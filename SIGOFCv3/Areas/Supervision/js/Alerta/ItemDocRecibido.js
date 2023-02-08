'use strict';
var _ItemDocRecibido = {};
(function () {
    
    this.urlController = urlLocalSigo + "Supervision/Alerta";
    this.RegEstado;
    this.init = (RegEstado, data) => {
        this.frm = $("#frmItemDocRecibido");
        this.content = $("#divItemDocRecibido");
        this.RegEstado = RegEstado;        
        if (RegEstado == RegEstadoSigo.UPDATE) {           
            this.initData(data);          
        }
            
        
        this.initEvent();
    }
    this.initData = (data) => {    
        
        this.frm.find("#hdCodDocRecibido").val(data.COD_DOCRECIBIDO);
        this.frm.find("#txtOficina").val(data.OFICINA);
        this.frm.find("#txtDocumento").val(data.DOCUMENTO);       
        this.frm.find("#txtExpediente").val(data.EXPEDIENTE);
        this.frm.find("#txtObservaciones").val(data.OBSERVACIONES);
        var fechaArray = data.FECHA_EXPEDIENTE.split("/");
        var fecha = "";
        if (fechaArray.length > 0)
            fecha = fechaArray[2] + "-" + fechaArray[1] + "-" + (fechaArray[0].length == 1 ? "0" + fechaArray[0].toString() : fechaArray[0].toString());
        this.frm.find("#txtfechaexpediente").val(fecha);

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
        return true;
    }
    this.save = () => {
        if (this.frm.valid()) {
            if (this.validAdditional()) {
                let datos = {};                

                let ListDocRecibido = [{
                    COD_DOCRECIBIDO: $("#hdCodDocRecibido").val(),
                    OFICINA: $("#txtOficina").val(),
                    DOCUMENTO: $("#txtDocumento").val(),
                    EXPEDIENTE: $("#txtExpediente").val(),
                    FECHA_EXPEDIENTE: $("#txtfechaexpediente").val(),
                    OBSERVACIONES: $("#txtObservaciones").val(),
                    ACTIVO : 1
                }];

                datos.codigoDato = $('#codigoDato').val();
                datos.codigoComplementario = $('#codigoComplementario').val();
                datos.ListDocRecibido = ListDocRecibido;
                datos.RegEstado = this.RegEstado;


                $.ajax({
                    url: this.urlController + "/saveDocRecibido",
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
                        this.content.closest(".modal").modal("hide");
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

}).apply(_ItemDocRecibido);



$(document).ready(function () {

    $("#frmItemRuta input[type=text]").keyup(function () {
        this.value = this.value.toUpperCase();
    });
    

});