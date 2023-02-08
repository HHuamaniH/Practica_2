"use strict";

/*
<input type="file" id="fileItemEspDev" name="fileItemEspDev" style="display:none" size="60" onchange="ManDM.ImportarExcel(event, this, 'ESPDEV')" onclick="return ManDM.ValidaImportarExcel(event,this,'ESPDEV')">
e=evento del file
objeto=objeto file
url = urlLocalSigo + "/ManPOA/ImportarDataExcel";
data = {    TVentana: "VentanaPoa" };  
fnSuccess=la funcion despues de que se haya subido el archivo y retornado la data
llamada uploadFile.fileSelectHandler(e, objeto, url, data, function(data){//Hacer sus respectivo pintado de datos})
*/
var uploadFile = {};
(function () {

    this.fileSelectHandler = function (e, objeto, url, data, fnSuccess) {

        if (e.dataTransfer != undefined &&
            e.dataTransfer.files != undefined) {

            this.resetFileSelect(objeto);
        }
        var files = e.target.files || e.dataTransfer.files;
        if (files != undefined && files.length > 0) {
            this.uploadFileToServer(files[0], objeto, url, data, fnSuccess);
        }
    }
    this.resetFileSelect = function (objeto) {
        var idFile = $(objeto).attr("id");
        $("#" + idFile).replaceWith(objeto.outerHTML);
    }
    this.uploadFileToServer = function (file, objeto, url, data, fnSuccess) {
        var formdata = new FormData();
        formdata.append(file.name, file);
        //Agregamos los parametros opcionales
        for (var k in data) {
            if (data.hasOwnProperty(k)) {
                formdata.append(k, data[k]);
            }
        }
        $.ajax({
            url: url,
            type: 'POST',
            data: formdata,
            contentType: false,
            dataType: 'json',
            processData: false,
            success: function (data) {
                uploadFile.resetFileSelect(objeto);
                utilSigo.unblockUIGeneral();

                if (data.success) {
                    if (data.data.length > 0) {
                        if (fnSuccess)
                            fnSuccess(data.data);

                        utilSigo.toastSuccess("Aviso", "Se Subió Correctamente");
                    }
                    else {
                        utilSigo.toastWarning("Aviso", "No hay registros");
                    }
                }
                else utilSigo.toastWarning("Aviso", data.msj);
            },
            beforeSend: function () {
                uploadFile.resetFileSelect(objeto);
                utilSigo.blockUIGeneral();
            },
            error: function (jqXHR, error, errorThrown) {
                utilSigo.unblockUIGeneral();
                utilSigo.toastError("Error", initSigo.MessageError);                
            }
        });
    }
    this.fileSelectHandler_v1 = function (e, objeto, url, data, fnSuccess) {

        if (e.dataTransfer != undefined &&
            e.dataTransfer.files != undefined) {

            this.resetFileSelect(objeto);
        }
        var files = e.target.files || e.dataTransfer.files;
        if (files != undefined && files.length > 0) {
            this.uploadFileToServer_V1(files[0], objeto, url, data, fnSuccess);
        }
    }
    this.uploadFileToServer_V1 = function (file, objeto, url, data, fn) {
        var formdata = new FormData();
        formdata.append(file.name, file);
        console.log(file.name);
        //Agregamos los parametros opcionales
        for (var k in data) {
            if (data.hasOwnProperty(k)) {
                formdata.append(k, data[k]);
            }
        }
        $.ajax({
            url: url,
            type: 'POST',
            data: formdata,
            contentType: false,
            dataType: 'json',
            processData: false,
            success: function (data) {
                uploadFile.resetFileSelect(objeto);
                utilSigo.unblockUIGeneral();
                fn(data);
            },
            beforeSend: function () {
                uploadFile.resetFileSelect(objeto);
                utilSigo.blockUIGeneral();
            },
            error: function (jqXHR, error, errorThrown) {
                utilSigo.unblockUIGeneral();
                utilSigo.toastError("Error", initSigo.MessageError);
            }
        });
    }

}).apply(uploadFile);