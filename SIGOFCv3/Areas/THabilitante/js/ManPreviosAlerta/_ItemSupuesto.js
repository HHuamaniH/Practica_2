'use strict';
var _ItemSupuesto = {};
(function () {
    this.urlController = urlLocalSigo + "THabilitante/ManPreviosAlerta";
    this.RegEstado;
    this.init = (RegEstado, data) => {
        this.frm = $("#frmItemSupuesto");
        this.content = $("#divItemSupuesto");
        this.RegEstado = RegEstado;
        if (RegEstado == RegEstadoSigo.UPDATE) {
            this.initData(data);
            $("#cambioArchivo").removeAttr('hidden');
            $("#customFile").attr('hidden', 'true'); 
            $("#file-input").removeAttr('required');    
            $("#txtAbrev_Supuesto").attr('disabled', 'true'); 
            $("#txtSupuesto").attr('disabled', 'true'); 
        }
            
        
        this.initEvent();
    }
    this.initData = (data) => {      
        var titulo = document.getElementById('h5Titulo');
        titulo.innerHTML = 'Editar';
        this.frm.find("#hdCodSupuesto").val(data.COD_SUPUESTO);
        this.frm.find("#txtAbrev_Supuesto").val(data.ABREV_SUPUESTO);
        this.frm.find("#txtSupuesto").val(data.DES_SUPUESTO);
        this.frm.find("#cbSupuestoEstado").val(data.ACTIVO);
        this.frm.find("#txtnomArchOriginal").val(data.NOMBRE_ARCHIVO);  
        this.frm.find("#txtnomArchTemporal").val(data.NOMBRE_ARCHIVO_REAL);
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
                let dataForm = this.frm.serializeObject();
                var fileUpload = $("#file-input").get(0);               
                var files = fileUpload.files;
              //  var hoy = new Date();
                //var nombrearchivorealC = hoy.getFullYear().toString() + (hoy.getMonth() + 1).toString() + hoy.getDate().toString() + hoy.getHours().toString() + hoy.getMinutes().toString() + hoy.getSeconds().toString();
                var nombreArchivo = files.length == 0 ? dataForm.txtnomArchOriginal : files[0].name;
            //    var extension = nombreArchivo.split('.');
           //     var nombrearchivoreal = dataForm.txtnomArchTemporal == "" ? nombrearchivorealC + '.' + extension[1] : dataForm.txtnomArchTemporal;
                
                let ListSUPUESTO = [{
                    COD_SUPUESTO: dataForm.hdCodSupuesto,
                    ABREV_SUPUESTO: dataForm.txtAbrev_Supuesto,
                    DES_SUPUESTO: dataForm.txtSupuesto,
                    ACTIVO: dataForm.cbSupuestoEstado,
                    NOMBRE_ARCHIVO: nombreArchivo,
                    NOMBRE_ARCHIVO_REAL: dataForm.txtnomArchTemporal,
                }];
                
                datos.RegEstado = this.RegEstado;
                datos.ListSUPUESTO = ListSUPUESTO;                
                

                var fdata = new FormData();               
                fdata.append("archivo", files[0]);
                fdata.append("data", JSON.stringify(datos));                          
                $.ajax({
                    url: this.urlController + "/saveSupuesto",
                    type: 'POST',
                    data: fdata,                    
                    dataType: 'json',
                    cache: false,
                    contentType: false,
                    processData: false,
                    beforeSend: function (xhr) {
                        xhr.setRequestHeader("XSRF-TOKEN",
                            $('input:hidden[name="__RequestVerificationToken"]').val());
                        utilSigo.beforeSendAjax;
                    },
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
    this.afterSave = (data) => {

    }
    this.finallySave = () => {
        this.frm[0].reset();
    }
    this.close = () => {
        this.content.closest(".modal").modal("hide");
    }

}).apply(_ItemSupuesto);



$(document).ready(function () {

    $("#frmItemRuta input[type=text]").keyup(function () {
        this.value = this.value.toUpperCase();
    });    

    $('.custom-file-input').on('change', function (event) {        
        var inputFile = event.currentTarget;
        console.log(inputFile.files.length);
        if (inputFile.files.length > 0) {
            $(inputFile).parent()
                .find('.custom-file-label')
                .html(inputFile.files[0].name);
        } else {
            $(inputFile).parent()
                .find('.custom-file-label')
                .html('');
        }
    });
    $('#chkcambioArchivo').on('click', function () {
        if ($(this).is(':checked')) {            
            $("#customFile").removeAttr('hidden');   
            $("#file-input").attr('required', 'true'); 
        } else {            
            $("#customFile").attr('hidden', 'true'); 
            $("#file-input").removeAttr('required'); 
        }
    });

});