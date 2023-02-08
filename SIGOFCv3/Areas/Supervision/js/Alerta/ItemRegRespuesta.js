'use strict';

//import { Alert } from "../../../../Scripts/bootstrap.bundle";

var _ItemRegRespuesta = {};
(function () {
    

    this.urlController = urlLocalSigo;
    this.RegEstado;
    this.init = (RegEstado, data) => {
        this.frm = $("#frmItemRegRespuesta");
        //  this.content = $("#divItemRegRespuesta");
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
    this.confirmarRegistro = () => {
        debugger;
        if (this.valid()) {
            let datos = {};

            let ListRptaEnlace = [{
                COD_RPTAENLACE: 0,                
                TOKEN: $("#hddTOKEN").val(),
                COD_BITACORA: $("#hddCOD_BITACORA").val(),
                COD_THABILITANTE: $("#hddCOD_THABILITANTE").val(),
                COD_SECUENCIAL: $("#hddCOD_SECUENCIAL").val(),
                DOCUMENTO: $("#txtDocumento").val(),
                FECHA_EXPEDIENTE: $("#txtFecha").val(),
                PROCEDIMIENTO: $("#cbProcedimiento").val(),
                RECOMENDACION: $("#txtRecomendacion").val(),             
                ACTIVO: 1
            }];
            
            datos.ListRptaEnlace = ListRptaEnlace;
            datos.RegEstado = 1;

            console.log(this.urlController + "/saveRptaEnlace");
            $.ajax({
                url: this.urlController + "/saveRptaEnlace",
                type: 'POST',
                data: JSON.stringify(datos),
                contentType: 'application/json;charset=utf-8',
                dataType: 'json',
                beforeSend: utilSigo.beforeSendAjax,
                complete: utilSigo.completeAjax,
                error: utilSigo.errorAjax,
                success: function (data) {
                    debugger;
                    if (data.success) { 
                        
                        utilSigo.toastSuccess("Aviso", data.msj);
                        $('#divRegistrado').removeAttr('hidden');
                        $('#itemRegRespuesta').attr('hidden', 'hidden');                        
                    }
                    else utilSigo.toastWarning("Aviso", data.msj);                   
                }.bind(this)
            });
        }        
    }   
    this.valid = () => {
        debugger;

        if ($('#txtDocumento').val() == '') {
            utilSigo.toastWarning('Formulario incompleto', 'Ingrese el Documento');
            return false;
        } else if ($('#txtFecha').val() == '') {
            utilSigo.toastWarning('Formulario incompleto', 'Seleccione la Fecha');
            return false;
        } else if ($('#cbProcedimiento').val() == '') {
            utilSigo.toastWarning('Formulario incompleto', 'Seleccione el Procedimiento');
            return false;
        } else if ($('#txtRecomendacion').val() == '') {
            utilSigo.toastWarning('Formulario incompleto', 'Ingrese la Recomendacion');
            return false;
        }
        return true;

    }

    this.validaToken = () => {

        if ($('#hddCOD_BITACORA').val() == '' || $('#hddCOD_BITACORA').val() == null || $('#hddCOD_BITACORA').val() == undefined) {
            $('#divCaduco').removeAttr('hidden');
            $('#itemRegRespuesta').attr('hidden', 'hidden');
        }
    }

}).apply(_ItemRegRespuesta);



$(document).ready(function () {

    //$("#frmItemRuta input[type=text]").keyup(function () {
    //    this.value = this.value.toUpperCase();
    //});

    _ItemRegRespuesta.validaToken();

});