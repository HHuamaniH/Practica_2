"use strict";
var ManRD_AddEdit = {};


//para iniciar los eventos
ManRD_AddEdit.iniciarEventos = function () {
    //ManRD_AddEdit.frm.find("#txtItemfecemi").datepicker({ format: "dd/mm/yyyy", autoclose: true, language: 'es' });
    ManRD_AddEdit.frm.find("#txtFechaPresentacion").datepicker({ format: "dd/mm/yyyy", autoclose: true, language: 'es' });
    ManRD_AddEdit.frm.find("#txtFechaEmision").datepicker({ format: "dd/mm/yyyy", autoclose: true, language: 'es' });
    var xx = ManRD_AddEdit.frm.find("#txtnomArchOriginal").val();
    console.log(xx);

    ManRD_AddEdit.tbEliTABLA = {};
    if (ManRD_AddEdit.frm.find("#txtnomArchOriginal").val().trim() == "") {
        $("#iconDownload").hide();
    }
    else {
        $("#iconDownload").show();
        ManRD_AddEdit.frm.find("label[for='lblnomArchOriginal']").text(ManRD_AddEdit.frm.find("#txtnomArchOriginal").val());
    }
}

//vuelve a la vista principal del listado
ManRD_AddEdit.regresar = function (appServer) {
    var url = "";
    url = urlLocalSigo + "Tribunal/ManTribunal/Index";
    window.location = url;

};

ManRD_AddEdit.fnBuscarPersona = function (_dom, _tipoPersona) {
    var url = urlLocalSigo + "General/Controles/_BuscarPersonaGeneral";
    var option = { url: url, type: 'GET', datos: { asBusGrupo: "PERSONA", asCodPTipo: "TODOS", asTipoPersona: _tipoPersona }, divId: "mdlBuscarPersona" };
    utilSigo.fnOpenModal(option, function () {
        _bPerGen.fnAsignarDatos = function (obj) {
            if (obj != null && obj != "") {
                var data = _bPerGen.dtBuscarPerona.row($(obj).parents('tr')).data();
                switch (_dom) {
                    case "PROFESIONAL":
                        ManRD_AddEdit.frm.find("#hdfCodProfesional").val(data["COD_PERSONA"]);
                        ManRD_AddEdit.frm.find("#txtProfesional").val(data["PERSONA"]);
                        ManRD_AddEdit.frm.find("#hdTipoProfesional").val(_tipoPersona);
                        break;

                }
                utilSigo.fnCloseModal("mdlBuscarPersona");
            }
        };
        _bPerGen.fnInit();
    });
};

//------------------------------------------------------------------------------------------------
ManRD_AddEdit.Tramite = {
    objDeuncia: {
        tra_M_Tramite: {
            cCodificacion: ''
        }
    },
    fnBuscar: function () {
        let cCodificacion = $("#inptExpediente").val();
        if (cCodificacion === '') {
            utilSigo.toastWarning("Aviso", "Ingrese N° Tramite STID");
            return;
        }
        let data = {
            cCodificacion: cCodificacion
        };
        var option = {
            url: urlLocalSigo + "Tribunal/ManTribunal/ConsultarExpediente",
            datos: JSON.stringify(data),
            type: 'POST'
        };
        if (ManRD_AddEdit.Tramite.objDeuncia.tra_M_Tramite.cCodificacion !== undefined) {
            if (ManRD_AddEdit.Tramite.objDeuncia.tra_M_Tramite.cCodificacion.trim() === cCodificacion) {
                utilSigo.toastWarning("Aviso", "N° Tramite STID Asignado en este proyecto");
            } else {
                utilSigo.fnAjax(option, function (response) {
                    if (response.iCodTramite != -1 && response.iCodTramite != 0) {
                        $("#txtFechaPresentacion").val(response.fFecDocumento);
                        utilSigo.toastSuccess("Aviso", "N° Tramite STID Encontrado")
                        ManRD_AddEdit.Tramite.objDeuncia.tra_M_Tramite = response;


                        $('.responseOk').show();
                        $('.responseError').hide();
                    }
                    else {
                        utilSigo.toastWarning("Aviso", "No Existe N° Tramite STID");
                        $("#txtFechaPresentacion").val(" ");
                        //$("#inptExpediente").val(" ");
                        $('.responseOk').hide();
                        $('.responseError').show();
                    }
                });
            }
        } else {
            utilSigo.fnAjax(option, function (response) {

                if (response.iCodTramite != -1) {


                    utilSigo.toastSuccess("Aviso", "N° Tramite STID Encontrado")
                    ManRD_AddEdit.Tramite.objDeuncia.tra_M_Tramite = response;
                    $('.responseOk').show();
                    $('.responseError').hide();
                }
                else {
                    utilSigo.toastWarning("Aviso", "No Existe N° Tramite STID");
                    $('.responseOk').hide();
                    $('.responseError').show();
                }
            });
        }
    },
    eliminarTramite: function () {
        if ($('#inptExpediente').val() === '') {
            $("#txtFechaPresentacion").val(" ");
            utilSigo.toastWarning("Aviso", "Ingrese N° Tramite STID");
            return;
        } else {
            $('.responseError').hide();
            $('.responseOk').hide();
            ManRD_AddEdit.Tramite.objDeuncia.tra_M_Tramite = {};
            $('#inptExpediente').val('');
            $("#txtFechaPresentacion").val(" ");
        }
    },
    obtenerDenuncia: function () {
        var option = {
            url: urlLocalSigo + "Supervision/Denuncias/obtenerDenunciaxInforme",
            datos: JSON.stringify({
                ENT_INFORME: {
                    COD_INFORME: $('#hdfCodInforme').val()
                }
            }),
            type: 'POST'
        };
        utilSigo.fnAjax(option, function (data) {
            if (data.tra_M_Tramite.iCodTramite !== -1 && data.tra_M_Tramite.iCodTramite !== 0) {
                ManRD_AddEdit.Tramite.objDeuncia.tra_M_Tramite = data.tra_M_Tramite;
                $('#inptExpediente').val(ManRD_AddEdit.Tramite.objDeuncia.tra_M_Tramite.cCodificacion);
                $('.responseOk').show();
                $('.responseError').hide();
            }
            ManRD_AddEdit.Tramite.objDeuncia.COD_IDENUNCIA = data.COD_IDENUNCIA;
            if (data.IATENDIDO == 1) {
                $('#rbtnAtendido1').prop('checked', true);
            } else if (data.IATENDIDO == 2) {
                $('#rbtnAtendido2').prop('checked', true);
            }
        });
    }
};
//------------------------------------------------------------------------------------------------------------------

ManRD_AddEdit.fnViewModalUbigeo = function () {
    var url = initSigo.urlControllerGeneral + "_Ubigeo";
    var option = { url: url, type: 'POST', datos: {}, divId: "mdlControles_Ubigeo" };
    utilSigo.fnOpenModal(option, function () {
        _Ubigeo.fnSelectUbigeo = function (_ubigeoText, _ubigeoId) {
            ManRD_AddEdit.frm.find("#hdfCodUbigeo").val(_ubigeoId);
            ManRD_AddEdit.frm.find("#txtUbigeo").val(_ubigeoText);
            $("#mdlControles_Ubigeo").modal('hide');
        }
        _Ubigeo.fnLoadModalView(ManRD_AddEdit.frm.find("#hdfCodUbigeo").val());
    }, function () {
        if (!utilSigo.fnValidateForm_HideControl(ManRD_AddEdit.frm, ManRD_AddEdit.frm.find("#hdfCodUbigeo"), ManRD_AddEdit.frm.find("#iconUbigeo"), false)) return false;
        return true;
    }
    );
}
ManRD_AddEdit.fnSelectDocAdjunto = function (e, obj) {
    var idFile = $(obj).attr("id");
    var files = e.target.files || e.dataTransfer.files;

    if (files != undefined && files.length > 0) {
        //Validar extensión archivo seleccionado
        var extension = files[0].name.substr((files[0].name.lastIndexOf('.') + 1));
        var extensiones_no_permitidas = "exe,bin,bat,run";

        if (!extensiones_no_permitidas.includes(extension)) {
            //Validar el tamaño del archivo
            var fileSize = parseFloat(files[0].size);
            if ((fileSize / 1048576) > 20) //20MB permitido por archivo
            {
                utilSigo.toastError("Error", "El tamaño del archivo supera los 20MB permitidos"); return false;
            } else {
                $("#" + idFile).next().text(files[0].name);
                ManRD_AddEdit.selectFile = files[0];
                ManRD_AddEdit.fnSaveDocumentoAdjunto();
            }
        } else {
            utilSigo.toastError("Error", "La extensión ." + extension + " no esta permitida"); return false;
        }
    }
}

ManRD_AddEdit.fnSaveDocumentoAdjunto = function () {
    if (ManRD_AddEdit.selectFile == null) {
        utilSigo.toastWarning("Aviso", "Seleccione el documento a adjuntar"); return false;
    }

    // Checking whether FormData is available in browser  
    if (window.FormData !== undefined) {
        var fileData = new FormData();
        //var url = urlLocalSigo + "Fiscalizacion/FiscalizacionNotificacion/";
        var url = urlLocalSigo + "Tribunal/ManTribunal/GrabarDocumentoAdjunto";
        var data = {};

        /*data.COD_CAPACITACION = ManCapacitacion_AddEdit.frm.find("#hdfCodCapacitacion").val();
        data.MAE_COD_TIPOADJUNTO = ManCapacitacion_AddEdit.frm.find("#ddlTipoAdjuntoId").val();
        data.OBSERVACION = ManCapacitacion_AddEdit.frm.find("#txtObservacionTAdjunto").val();*/

        fileData.append("data", JSON.stringify(data));
        fileData.append(ManRD_AddEdit.selectFile.name, ManRD_AddEdit.selectFile);

        $.ajax({
            url: url,
            type: "POST",
            contentType: false, // Not to set any content header  
            processData: false, // Not to process data  
            data: fileData,
            success: function (result) {
                if (result.success) {
                    ManRD_AddEdit.frm.find("#txtnomArchOriginal").val(result.data.NOMBRE_ARCHIVO);
                    ManRD_AddEdit.frm.find("#txtnomArchTemporal").val(result.data.NOMBRE_TEMPORAL_ARCHIVO);
                    ManRD_AddEdit.frm.find("#txtextArch").val(result.data.EXTENSION_ARCHIVO);
                    ManRD_AddEdit.frm.find("#txtestadoArch").val(result.data.ESTADO_ARCHIVO);
                    $("#iconDownload").show();
                    ManRD_AddEdit.frm.find("label[for='lblnomArchOriginal']").text(result.data.NOMBRE_ARCHIVO);

                    ManRD_AddEdit.frm.find("#txtArchivoAdjunto").next().text("Seleccionar Archivo");
                    ManRD_AddEdit.frm.find("#txtArchivoAdjunto").val("");
                    ManRD_AddEdit.selectFile = null;
                    utilSigo.toastSuccess("Éxito", result.msj);

                    console.log(ManRD_AddEdit.frm.find("#txtnomArchOriginal").val());
                    console.log(result.data);
                }
                else {
                    utilSigo.toastWarning("Aviso", result.msj);
                }
            },
            error: function (err) {
                utilSigo.toastWarning("Aviso", "Sucedio un error, Comuníquese con el Administrador");
            }
        });
    } else {
        utilSigo.toastWarning("Aviso", "Sucedio un error, Comuníquese con el Administrador");
    }
};

ManRD_AddEdit.fnDownloadDocumentoAdjunto = function () {
    var estado = ManRD_AddEdit.frm.find("#txtestadoArch").val();
    var nombreOriginal = ManRD_AddEdit.frm.find("#txtnomArchOriginal").val();
    var fname = ManRD_AddEdit.frm.find("#txtnomArchTemporal").val();
    var asCodTFFS = ManRD_AddEdit.frm.find("#hdfCodTFFS").val();
    console.log(asCodTFFS);
    var opcion = 5;
    if (parseInt(estado) != 0) {
        var iframe = document.createElement("iframe");
        //iframe.src = urlLocalSigo + "Fiscalizacion/FiscalizacionNotificacion/DescargarDocumentoAdjunto?nombreArchivo=" + fname + "&nombreOriginal=" + nombreOriginal;
        iframe.src = urlLocalSigo + "Tribunal/ManTribunal/DescargarDocumentoAdjunto?nombreArchivo=" + fname + "&nombreOriginal=" + nombreOriginal + "&hdfCodTFFS=" + asCodTFFS;
        iframe.style.display = "none";
        $("#divIframe").html(iframe);
    }
    else {
        var nroDocumento = nombreOriginal.trim();

        if (nroDocumento != "") {
            nroDocumento = nroDocumento.replace(" ", "%20").replace("°", "%B0");

            document.location = "http://api-appeventos-beta.osinfor.gob.pe:8089/SIGOsfc_Mejoras_Oracle" + nroDocumento;
        }
    }
};


ManRD_AddEdit.fnSaveForm = function () {
    //capturando las variables 
    //capturando variables 
    var listTFFSRectificadas = _renderListBuscarResol.fnGetList();
    var v_COD_RESOLUCION_TFFS_RECTIFICA = ' ';
    if (listTFFSRectificadas.length > 0) {
        v_COD_RESOLUCION_TFFS_RECTIFICA = listTFFSRectificadas[0].COD_RESOLUCION_TFFS;
    }
    let COD_RESOLUCION_TFFS_RECTIFICA = v_COD_RESOLUCION_TFFS_RECTIFICA;
    let hdfCodTFFS = ManRD_AddEdit.frm.find("#hdfCodTFFS").val();
    let hdfCodPersona = ManRD_AddEdit.frm.find("#hdfCodPersona").val();
    let RegEstado = ManRD_AddEdit.frm.find("#RegEstado").val();
    let hdfCodTitular = ManRD_AddEdit.frm.find("#hdfCodTitular").val();
    let hdfCodExTitulat = ManRD_AddEdit.frm.find("#hdfCodExTitulat").val();
    let hdfTipoDocumento = ManRD_AddEdit.frm.find("#hdfTipoDocumento").val();
    let txtnomArchOriginal = ManRD_AddEdit.frm.find("#txtnomArchOriginal").val();
    let txtnomArchTemporal = ManRD_AddEdit.frm.find("#txtnomArchTemporal").val();
    let txtextArch = ManRD_AddEdit.frm.find("#txtextArch").val();
    let txtestadoArch = ManRD_AddEdit.frm.find("#txtestadoArch").val();
    let txtcCodificacionSiTD = ManRD_AddEdit.frm.find("#txtcCodificacionSiTD").val();
    let inptExpediente = ManRD_AddEdit.frm.find("#inptExpediente").val();
    let txtFechaPresentacion = ManRD_AddEdit.frm.find("#txtFechaPresentacion").val();
    let txtItemNumero2 = ManRD_AddEdit.frm.find("#txtItemNumero2").val();
    let txtItemObservacion = ManRD_AddEdit.frm.find("#txtItemObservacion").val();
    let ddlItemIndicadorId = ManRD_AddEdit.frm.find("#ddlItemIndicadorId").val();
    let txtControlCalidadObservaciones = ManRD_AddEdit.frm.find("#txtControlCalidadObservaciones").val();
    let chkItemObsSubsanada = ManRD_AddEdit.frm.find("#chkItemObsSubsanada").is(':checked');
    let chkPublicar = ManRD_AddEdit.frm.find("#chkPublicar").is(':checked');
    let ddlTipoResolucionId = ManRD_AddEdit.frm.find("#ddlTipoResolucionId").val();
    let ddlResApelacionId = ManRD_AddEdit.frm.find("#ddlResApelacionId").val();
    let txtQueja = ManRD_AddEdit.frm.find("#txtQueja").val();
    let ddlResOtrosId = ManRD_AddEdit.frm.find("#ddlResOtrosId").val();
    let txtOtrosDes = ManRD_AddEdit.frm.find("#txtOtrosDes").val();
    let ddlResTFFSDFFSId = ManRD_AddEdit.frm.find("#ddlResTFFSDFFSId").val();
    let ddlSentidoResId = ManRD_AddEdit.frm.find("#ddlSentidoResId").val();
    let txtDetermina = ManRD_AddEdit.frm.find("#txtDetermina").val();
    let ddlImprocedenteId = ManRD_AddEdit.frm.find("#ddlImprocedenteId").val();
    let txtDetermina2 = ManRD_AddEdit.frm.find("#txtDetermina2").val();
    let ddlInadmisibleId = ManRD_AddEdit.frm.find("#ddlInadmisibleId").val();
    let chkConfirmar = ManRD_AddEdit.frm.find("#chkConfirmar").is(':checked');    
    let chkRevocar = ManRD_AddEdit.frm.find("#chkRevocar").is(':checked');
    let chkRevocarParte = ManRD_AddEdit.frm.find("#chkRevocarParte").is(':checked');
    let chkRetrotraer = ManRD_AddEdit.frm.find("#chkRetrotraer").is(':checked');
    let chkPrescribir = ManRD_AddEdit.frm.find("#chkPrescribir").is(':checked');
    let chkArchivar = ManRD_AddEdit.frm.find("#chkArchivar").is(':checked');
    let chkSuspension = ManRD_AddEdit.frm.find("#chkSuspension").is(':checked');
    let chkNulidad = ManRD_AddEdit.frm.find("#chkNulidad").is(':checked');
    let chkLevantar = ManRD_AddEdit.frm.find("#chkLevantar").is(':checked');
    let chkCarece = ManRD_AddEdit.frm.find("#chkCarece").is(':checked');
    let chkOtro = ManRD_AddEdit.frm.find("#chkOtro").is(':checked');
    let txtConfirmar = ManRD_AddEdit.frm.find("#txtConfirmar").val();
    let ddlNulidadId = ManRD_AddEdit.frm.find("#ddlNulidadId").val();
    let ddlNulidad_Id = ManRD_AddEdit.frm.find("#ddlNulidad_Id").val();
    let txtRetrotraer = ManRD_AddEdit.frm.find("#txtRetrotraer").val();
    let ddlRetrotraerId = ManRD_AddEdit.frm.find("#ddlRetrotraerId").val();
    let txtcajaretro = ManRD_AddEdit.frm.find("#txtcajaretro").val();
    let txtDescripcion = ManRD_AddEdit.frm.find("#txtDescripcion").val();
    let txtTitular = ManRD_AddEdit.frm.find("#txtTitular").val();
    let txtResponsable = ManRD_AddEdit.frm.find("#txtResponsable").val();
    let txtRegente = ManRD_AddEdit.frm.find("#txtRegente").val();
    let txtARFFS2 = ManRD_AddEdit.frm.find("#txtARFFS2").val();
    let txtATFFS = ManRD_AddEdit.frm.find("#txtATFFS").val();
    let txtMinPublico = ManRD_AddEdit.frm.find("#txtMinPublico").val();
    let txtMinEnergia = ManRD_AddEdit.frm.find("#txtMinEnergia").val();
    let txtColeInge = ManRD_AddEdit.frm.find("#txtColeInge").val();
    let txtOCI = ManRD_AddEdit.frm.find("#txtOCI").val();
    let txtOEFA = ManRD_AddEdit.frm.find("#txtOEFA").val();
    let txtSUNAT = ManRD_AddEdit.frm.find("#txtSUNAT").val();
    let txtSERFOR = ManRD_AddEdit.frm.find("#txtSERFOR").val();
    let txtDFFFS = ManRD_AddEdit.frm.find("#txtDFFFS").val();
    let txtDSFFS = ManRD_AddEdit.frm.find("#txtDSFFS").val();
    let txtURH = ManRD_AddEdit.frm.find("#txtURH").val();
    let txtOCI2 = ManRD_AddEdit.frm.find("#txtOCI2").val();
    let txtOtros = ManRD_AddEdit.frm.find("#txtOtros").val();
    let txtOtros2 = ManRD_AddEdit.frm.find("#txtOtros2").val();
    let txtDetermina_MedidaCorrectiva = ManRD_AddEdit.frm.find("#txtDetermina_MedidaCorrectiva").val();
    let txtDetermina_Multa = ManRD_AddEdit.frm.find("#txtDetermina_Multa").val();
    let ddlConfirmaResolId = ManRD_AddEdit.frm.find("#ddlConfirmaResolId").val();
    let ddlEstadoPAUId = ManRD_AddEdit.frm.find("#ddlEstadoPAUId").val();
    let hdfManRegEstado = ManRD_AddEdit.frm.find("#hdfManRegEstado").val();
    let txtDescripcionSentido = ManRD_AddEdit.frm.find("#txtDescripcionSentido").val();
    let txtDescripcionImprocedente = ManRD_AddEdit.frm.find("#txtDescripcionImprocedente").val();
    let txtDescripcionInadmisible = ManRD_AddEdit.frm.find("#txtDescripcionInadmisible").val();
    let txtDetermina3 = ManRD_AddEdit.frm.find("#txtDetermina3").val();
    let txtDescripcionInfundado = ManRD_AddEdit.frm.find("#txtDescripcionInfundado").val();
    let txtDescripcionFundado = ManRD_AddEdit.frm.find("#txtDescripcionFundado").val();
    let chkConfirmar2 = ManRD_AddEdit.frm.find("#chkConfirmar2").is(':checked');
    let chkRevocar2 = ManRD_AddEdit.frm.find("#chkRevocar2").is(':checked');
    let chkRevocarParte2 = ManRD_AddEdit.frm.find("#chkRevocarParte2").is(':checked');
    let chkRetrotraer2 = ManRD_AddEdit.frm.find("#chkRetrotraer2").is(':checked');
    let chkPrescribir2 = ManRD_AddEdit.frm.find("#chkPrescribir2").is(':checked');
    let chkArchivar2 = ManRD_AddEdit.frm.find("#chkArchivar2").is(':checked');
    let chkNulidad2 = ManRD_AddEdit.frm.find("#chkNulidad2").is(':checked');
    let chkLevantar2 = ManRD_AddEdit.frm.find("#chkLevantar2").is(':checked');
    let chkCarece2 = ManRD_AddEdit.frm.find("#chkCarece2").is(':checked');
    let chkOtro2 = ManRD_AddEdit.frm.find("#chkOtro2").is(':checked');
    let txtDescripcionFParte = ManRD_AddEdit.frm.find("#txtDescripcionFParte").val();
    let ddlDeterminaRetrotraerId = ManRD_AddEdit.frm.find("#ddlDeterminaRetrotraerId").val();
    let txtDescripcionOtros = ManRD_AddEdit.frm.find("#txtDescripcionOtros").val();
    let txtDescripcionRetrotraer = ManRD_AddEdit.frm.find("#txtDescripcionRetrotraer").val();
    let txtDescripcionSuspension = ManRD_AddEdit.frm.find("#txtDescripcionSuspension").val();
    let txtDescripcionCumplimiento = ManRD_AddEdit.frm.find("#txtDescripcionCumplimiento").val();
    let txtDescripcionDesestimiento = ManRD_AddEdit.frm.find("#txtDescripcionDesestimiento").val();
    let ddlLevantamientoId = ManRD_AddEdit.frm.find("#ddlLevantamientoId").val();
    let ddlMedCorrectId = ManRD_AddEdit.frm.find("#ddlMedCorrectId").val();
    let ddlCMultaId = ManRD_AddEdit.frm.find("#ddlCMultaId").val();
    let ddlAmonestacionId = ManRD_AddEdit.frm.find("#ddlAmonestacionId").val();
    var CArchivoAdjunto = ' ';
    var CArchivoAdjunto2 = ' ';
    if ($("#txtnomArchOriginal").val() == ManRD_AddEdit.frm.find("label[for='lblnomArchOriginal']").text()) {
        CArchivoAdjunto = ManRD_AddEdit.frm.find("#txtnomArchOriginal").val();
    }
    else {
        CArchivoAdjunto = ManRD_AddEdit.frm.find("#lblnomArchOriginal").val();
    }
    let txtArchivoAdjunto = CArchivoAdjunto;
    let txtFEmisionBExtraccion = ManRD_AddEdit.frm.find("#txtFEmisionBExtraccion").val();
    let ddlArticulosId = ManRD_AddEdit.frm.find("#ddlArticulosId").val();
    let txtDescInfrac = ManRD_AddEdit.frm.find("#txtDescInfrac").val();
    let ddlPOAId = ManRD_AddEdit.frm.find("#ddlPOAId").val();
    let ddlTipoAprovechamientoId = ManRD_AddEdit.frm.find("#ddlTipoAprovechamientoId").val();
    let txtFechaEmision = ManRD_AddEdit.frm.find("#txtFechaEmision").val();
    let ddlDeterminaRetrotraerId2 = ManRD_AddEdit.frm.find("#ddlDeterminaRetrotraerId2").val();
    let ddlRetrotraerId2 = ManRD_AddEdit.frm.find("#ddlRetrotraerId2").val();
    let txtDescripcionOtros2 = ManRD_AddEdit.frm.find("#txtDescripcionOtros2").val();
    let txtDescripcionRetrotraer2 = ManRD_AddEdit.frm.find("#txtDescripcionRetrotraer2").val();
    let chkTitular = ManRD_AddEdit.frm.find("#chkTitular").is(':checked');
    let chkResponsable = ManRD_AddEdit.frm.find("#chkResponsable").is(':checked');
    let chkRegente = ManRD_AddEdit.frm.find("#chkRegente").is(':checked');
    let chkARFFS = ManRD_AddEdit.frm.find("#chkARFFS").is(':checked');
    let chkATFFS = ManRD_AddEdit.frm.find("#chkATFFS").is(':checked');
    let chkMinPublico = ManRD_AddEdit.frm.find("#chkMinPublico").is(':checked');
    let chkMinEnergia = ManRD_AddEdit.frm.find("#chkMinEnergia").is(':checked');
    let chkColeInge = ManRD_AddEdit.frm.find("#chkColeInge").is(':checked');
    let chkOCI = ManRD_AddEdit.frm.find("#chkOCI").is(':checked');
    let chkOEFA = ManRD_AddEdit.frm.find("#chkOEFA").is(':checked');
    let chkSUNAT = ManRD_AddEdit.frm.find("#chkSUNAT").is(':checked');
    let chkSERFOR = ManRD_AddEdit.frm.find("#chkSERFOR").is(':checked');
    let chkOtros = ManRD_AddEdit.frm.find("#chkOtros").is(':checked');
    let chkDFFFS = ManRD_AddEdit.frm.find("#chkDFFFS").is(':checked');
    let chkDSFFS = ManRD_AddEdit.frm.find("#chkDSFFS").is(':checked');
    let chkURH = ManRD_AddEdit.frm.find("#chkURH").is(':checked');
    let chkOCI2 = ManRD_AddEdit.frm.find("#chkOCI2").is(':checked');
    let chkOtros2 = ManRD_AddEdit.frm.find("#chkOtros2").is(':checked');

    //resolucion Fundado y Fundado en Parte

    let radGrupoRevocar = ManRD_AddEdit.frm.find('input:radio[name="radGrupoRevocar"]:checked').val();
    let radNulidad = ManRD_AddEdit.frm.find('input:radio[name="radNulidad"]:checked').val();
    let radGrupoRevocarParte = ManRD_AddEdit.frm.find('input:radio[name="radGrupoRevocarParte"]:checked').val();
    let radGrupoRevocar2 = ManRD_AddEdit.frm.find('input:radio[name="radGrupoRevocar2"]:checked').val();
    let radNulidad2 = ManRD_AddEdit.frm.find('input:radio[name="radNulidad2"]:checked').val();
    let radGrupoRevocarParte2 = ManRD_AddEdit.frm.find('input:radio[name="radGrupoRevocarParte2"]:checked').val();
    let radRetrotraer = ManRD_AddEdit.frm.find('input:radio[name="radRetrotraer"]:checked').val();
    let radRetrotraer2 = ManRD_AddEdit.frm.find('input:radio[name="radRetrotraer2"]:checked').val();

    let modelRD = {
        hdfCodTFFS,
        hdfCodPersona,
        RegEstado,
        hdfCodTitular,
        hdfCodExTitulat,
        hdfTipoDocumento,
        txtnomArchOriginal,
        txtnomArchTemporal,
        txtextArch,
        txtestadoArch,
        txtcCodificacionSiTD,
        txtFechaPresentacion,
        txtItemNumero2,
        txtItemObservacion,
        ddlItemIndicadorId,
        txtControlCalidadObservaciones,
        chkItemObsSubsanada,
        chkPublicar,
        ddlTipoResolucionId,
        ddlResApelacionId,
        txtQueja,
        ddlResOtrosId,
        txtOtrosDes,
        ddlResTFFSDFFSId,
        ddlSentidoResId,
        txtDetermina,
        ddlImprocedenteId,
        txtDetermina2,
        ddlInadmisibleId,
        chkConfirmar,
        chkRevocar,
        chkRevocarParte,
        chkRetrotraer,
        chkPrescribir,
        chkArchivar,
        chkSuspension,
        chkNulidad,
        chkLevantar,
        chkCarece,
        //chkDesestimiento,
        chkOtro,
        txtConfirmar,
        ddlNulidadId,
        ddlNulidad_Id,
        txtRetrotraer,
        ddlRetrotraerId,
        txtcajaretro,
        txtDescripcion,
        txtTitular,
        txtResponsable,
        txtRegente,
        txtARFFS2,
        txtATFFS,
        txtMinPublico,
        txtMinEnergia,
        txtColeInge,
        txtOCI,
        txtOEFA,
        txtSUNAT,
        txtSERFOR,
        txtDFFFS,
        txtDSFFS,
        txtURH,
        txtOCI2,
        txtOtros,
        txtOtros2,
        txtDetermina_MedidaCorrectiva,
        txtDetermina_Multa,
        ddlConfirmaResolId,
        ddlEstadoPAUId,
        hdfManRegEstado,
        txtDescripcionSentido,
        txtDescripcionImprocedente,
        txtDescripcionInadmisible,
        txtDetermina3,
        txtDescripcionInfundado,
        txtDescripcionFundado,
        chkConfirmar2,
        chkRevocar2,
        chkRevocarParte2,
        chkRetrotraer2,
        chkPrescribir2,
        chkArchivar2,
        chkNulidad2,
        chkLevantar2,
        chkCarece2,
        chkOtro2,
        txtDescripcionFParte,
        ddlDeterminaRetrotraerId,
        txtDescripcionOtros,
        txtDescripcionRetrotraer,
        txtDescripcionSuspension,
        txtDescripcionCumplimiento,
        txtDescripcionDesestimiento,
        ddlLevantamientoId,
        ddlMedCorrectId,
        ddlCMultaId,
        ddlAmonestacionId,
        txtArchivoAdjunto,
        txtFEmisionBExtraccion,
        ddlArticulosId,
        txtDescInfrac,
        ddlPOAId,
        ddlTipoAprovechamientoId,
        txtFechaEmision,
        inptExpediente,
        ddlDeterminaRetrotraerId2,
        ddlRetrotraerId2,
        txtDescripcionOtros2,
        txtDescripcionRetrotraer2,
        COD_RESOLUCION_TFFS_RECTIFICA,
        chkTitular,
        chkResponsable,
        chkRegente,
        chkARFFS,
        chkATFFS,
        chkMinPublico,
        chkMinEnergia,
        chkColeInge,
        chkOCI,
        chkOEFA,
        chkSUNAT,
        chkSERFOR,
        chkOtros,
        chkDFFFS,
        chkDSFFS,
        chkURH,
        chkOCI2,
        chkOtros2,
        radGrupoRevocar,
        radNulidad,
        radGrupoRevocar2,
        radNulidad2,
        radGrupoRevocarParte,
        radGrupoRevocarParte2,
        radRetrotraer,
        radRetrotraer2
    }
    ///control de calidad
    modelRD.vmControlCalidad = _ControlCalidad.fnGetDatosControlCalidad();
    /// Listas
    modelRD.ListPersonaFirma = _renderListProf.fnGetList();
    modelRD.listELiPersonaFirma = _renderListProf.tbEliTABLA;


    modelRD.ListInfraccionRD = _renderInfracciones.fnGetList();
    modelRD.listEliInfracciones = _renderInfracciones.tbEliTABLA;

    modelRD.ListInformes = _renderListRS.fnGetList();
    modelRD.listEliInformes = _renderListRS.tbEliTABLA;

    //idlPOAObservatorio
    var listPObservatorio = [];
    $("[id*=idlPOA] input:checked").each(function () {
        listPObservatorio.push($(this).attr('value'));
    });
    
    modelRD.ListPOAChecked = listPObservatorio;

    utilSigo.dialogConfirm("", "Está seguro registrar los datos?", function (r) {
        if (r) {
            let url = urlLocalSigo + "Tribunal/ManTribunal/AddEditRD";
            let option = { url: url, datos: JSON.stringify(modelRD), type: 'POST' };
            utilSigo.fnAjax(option, function (data) {
                console.log(data.success);
                if (data.success) {

                    window.location = `${urlLocalSigo}/Tribunal/ManTribunal/Index`;
                    utilSigo.toastSuccess("Éxito", "Datos actualizados correctamente");
                }
                else {
                    utilSigo.toastWarning("Aviso", data.msj);
                }
            });
        }
    });


}
ManRD_AddEdit.fnSimular = function () {
    //alert('simular obserbatorio');
    var listPoa = [];
    let codigo = ManRD_AddEdit.frm.find("#hdfCodTFFS").val();
    let tipo = 'RESOLUCION TRIBUNAL FORESTAL';
    
    $("[id*=idlPOASimular] input:checked").each(function () {
        listPoa.push($(this).attr('value'));
    });
    //let option = { url: url, datos: listPoa, type: 'POST' };
    
    if (listPoa.length > 0) {
        $.ajax({
            url: urlLocalSigo + "Tribunal/ManTribunal/simularObservatorio",
            type: 'POST',
            datatype: "json",
            //contentType: "application/json; charset=utf-8",
            traditional: true,
            data: { 'listPoa': listPoa, 'codigo': codigo, 'tipo': tipo },
            success: function (data) {
                if (data.fileName != "") {
                    let url1 = urlLocalSigo + "Tribunal/ManTribunal/Download/?file=" + data.fileName;
                    window.open(url1, "_blank");
                }
                else {
                    utilSigo.toastWarning("Aviso", data.errorMessage);
                }
            },
            error: function (xhr, status, error) {
                alert("Error!" + xhr.status);
            },
        });
    }
    else {
        utilSigo.toastWarning("Aviso", 'Seleccione el POA a simular');
    }
}

$(document).ready(function () {
    ManRD_AddEdit.frm = $("#frmAddOrEditRD");
    ManRD_AddEdit.iniciarEventos();
    $("#inptExpediente").val();

});