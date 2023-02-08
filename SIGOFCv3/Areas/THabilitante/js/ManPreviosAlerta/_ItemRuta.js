'use strict';
var vpItemRuta = {};
(function () {
    this.urlController = urlLocalSigo + "THabilitante/ManPreviosAlerta/";
    this.RegEstado;
    this.init=(RegEstado,data)=> {
        this.frm = $("#frmItemRuta");
        this.content = $("#divItemRuta");
        this.RegEstado = RegEstado;
        if(RegEstado==RegEstadoSigo.UPDATE)
            this.initData(data);
        
        this.initEvent();
    }
    this.initData=(data)=> {
         
    }
    this.initEvent=()=> {
        this.configValidateForm();
        this.content.find("#btnGuardar").click(function () {
            this.save();
        }.bind(this));
      
    }
    this.configValidateForm=()=> {
        var objValida = {
       
        };
        this.frm.validate(utilSigo.fnValidate(objValida));

    }
    this.validAdditional=()=> {
        return true;
    }
    this.save=()=> {
        if (this.frm.valid()) {
            if (this.validAdditional()) {
                let datos = {};
                let dataForm = this.frm.serializeObject();                               
                let ListRUTA = [{
                    COD_RUTA: dataForm.hdRutaCodRuta,
                    ACTIVO: dataForm.cbRutaEstado,
                    TRAMO: dataForm.txtRutaTramo,
                    ORIGEN_DESTINO: dataForm.txtRutaOrigenDestino,
                    COD_UBIDEPARTAMENTO: dataForm.ddlRutaCodUbiDepartamentoId,
                }];
                datos.ListRUTA = ListRUTA;                          
                datos.RegEstado = this.RegEstado;


                $.ajax({
                    url: this.urlController + "/saveRuta",
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
                            utilSigo.toastSuccess("Exito", data.msj);                         
                        }
                        else utilSigo.toastWarning("Error", data.msj);
                    }.bind(this)
                });

               
            }
        }
        else
            this.frm.validate().focusInvalid();
    }
    this.afterSave=(data)=> {

    }
    this.finallySave=()=> {
        this.frm[0].reset();
    }
    this.close = () => {       
        this.content.closest(".modal").modal("hide");
    }

}).apply(vpItemRuta);


 
$(document).ready(function () {
    
    $("#frmItemRuta input[type=text]").keyup(function () {
        this.value = this.value.toUpperCase();
    });

});