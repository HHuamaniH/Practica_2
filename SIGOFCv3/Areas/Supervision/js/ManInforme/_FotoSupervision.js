"use strict";
var _FotoSupervision = {};
_FotoSupervision.imgFotoSupervision = null;
_FotoSupervision.fnSaveForm = function (data) { /*implementado desde donde se instancia*/ }

_FotoSupervision.fnSelectFile = function (e, obj) {
    var idFile = $(obj).attr("id");
    var files = e.target.files || e.dataTransfer.files;

    if (files != undefined && files.length > 0) {
        //Validar extensión archivo seleccionado
        var extension = files[0].name.substr((files[0].name.lastIndexOf('.') + 1));
        var extensiones_permitidas= "jpg,jpeg,bmp,png,gif";

        if (extensiones_permitidas.includes(extension.toLowerCase())) {
            //Validar el tamaño del archivo
            var fileSize = parseFloat(files[0].size);
            if ((fileSize / 1048576) > 10) //10MB permitido por foto
            {
                utilSigo.toastError("Error", "El tamaño del archivo supera los 10MB permitidos"); return false;
            } else {
                $("#" + idFile).next().text(files[0].name);
                _FotoSupervision.imgFotoSupervision = files[0];
            }
        } else {
            utilSigo.toastError("Error", "La extensión ." + extension + " no esta permitida"); return false;
        }
    }
}

_FotoSupervision.fnSubmitForm = function () {
    _FotoSupervision.frm.submit();
}

_FotoSupervision.fnCustomValidateForm = function () {
    if (_FotoSupervision.imgFotoSupervision==null) {
        utilSigo.toastError("Error", "Seleccione la foto a subir"); return false;
    }
    return true;
}

_FotoSupervision.fnSetDatos = function (result) {
    var data = [];
    data["COD_INFORME_FOTOS"] = result["hdfCodInformeFoto"];
    data["COD_INFORME"] = result["hdfCodInforme"];
    data["URL_FOTO"] = result["txtUrlFoto"];
    data["DESC_FOTO"] = result["txtDescripcion"];
    data["FUENTE_FOTO"] = result["txtFuente"];
    data["DISP_FOTO"] = result["txtDispositivo"];
    data["FECHA"] = result["txtFechaRegistro"];
    data["USUARIO_REGISTRO"] = result["txtUsuarioRegistro"];
    return data;
}

_FotoSupervision.fnSave = function () {
    if (_FotoSupervision.imgFotoSupervision == null) {
        utilSigo.toastWarning("Aviso", "Seleccione la foto a subir"); return false;
    }

    // Checking whether FormData is available in browser  
    if (window.FormData !== undefined) {
        var fileData = new FormData();
        var url = urlLocalSigo + "Supervision/ManInforme/GrabarFotoSupervision";
        var data = _FotoSupervision.frm.serializeObject();
        data.txtNumTHabilitante = _FotoSupervision.frm.find("#txtNumTHabilitante").val();
        data.txtUsuarioRegistro = _FotoSupervision.frm.find("#txtUsuarioRegistro").val();
        data.txtFechaRegistro = _FotoSupervision.frm.find("#txtFechaRegistro").val();

        fileData.append("data", JSON.stringify(data));
        fileData.append(_FotoSupervision.imgFotoSupervision.name, _FotoSupervision.imgFotoSupervision);

        $.ajax({
            url: url,
            type: "POST",
            contentType: false, // Not to set any content header  
            processData: false, // Not to process data  
            data: fileData,
            success: function (result) {
                if (result.success) {
                    _FotoSupervision.fnSaveForm(_FotoSupervision.fnSetDatos(result.data));
                }
                else {
                    utilSigo.toastWarning("Aviso", result.msj);
                }
            },
            error: function (err) {
                utilSigo.toastWarning("Aviso", "Sucedio un error, Comuníquese con el Administrador");
                console.log(err.statusText);
            }
        });
    } else {
        utilSigo.toastWarning("Aviso", "Sucedio un error, Comuníquese con el Administrador");
        console.log("FormData is not available in your browser");
    }
}

_FotoSupervision.fnInit = function () {
    _FotoSupervision.frm = $("#frmItemAvistamientoFauna");

    //=====-----Para el registro de datos del formulario-----=====
    _FotoSupervision.frm.validate(utilSigo.fnValidate({
        rules: {
            txtDescripcion: { required: true },
            txtFuente: { required: true },
            txtDispositivo: { required: true }
        },
        messages: {
            txtDescripcion: { required: "Ingrese la descripción de la foto" },
            txtFuente: { required: "Ingrese la fuente de la foto" },
            txtDispositivo: { required: "Ingrese el dispositivo con el que se tomó la foto" }
        },
        fnSubmit: function (form) {
            if (_FotoSupervision.fnCustomValidateForm()) {
                _FotoSupervision.fnSave();
            }
        }
    }));
    //Validación de controles que usan Select2
    _FotoSupervision.frm.find("select.select2-hidden-accessible").on("change", function (e) {
        $(this).valid();
    });
}