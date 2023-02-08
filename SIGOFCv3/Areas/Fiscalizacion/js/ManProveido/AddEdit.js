"use strict";
var ManProv_AddEdit = {};

ManProv_AddEdit.iniciarEventos = function () {
    ManProv_AddEdit.frm.find("#txtFechaEmision").datepicker({ format: "dd/mm/yyyy", autoclose: true, language: 'es' });
    ManProv_AddEdit.frm.find("#txtFechaFirmezaF").datepicker({ format: "dd/mm/yyyy", autoclose: true, language: 'es' });
    ManProv_AddEdit.frm.find("#txtFechaCumpleMCorrectiva").datepicker({ format: "dd/mm/yyyy", autoclose: true, language: 'es' });
    ManProv_AddEdit.frm.find("#txtFechaJud").datepicker({ format: "dd/mm/yyyy", autoclose: true, language: 'es' });

    ManProv_AddEdit.tbEliTABLA = {};    

}

ManProv_AddEdit.fnAsignarSTID = function (data, op) {
    
    if (op == "DOC_SALIDA") {
        ManProv_AddEdit.frm.find("#txtDocumentoSITD").val(data.cCodificacion);
        ManProv_AddEdit.frm.find("#txtCodDocumentoSITD").val(data.iCodTramite);
        ManProv_AddEdit.frm.find("#txtNroDocumentoSITD").val(data.cNroDocumento);
        ManProv_AddEdit.frm.find("#txtFechaDocumentoSITD").val(data.fFecDocumento);        
        ManProv_AddEdit.frm.find("#txtAsuntoSITD").val(data.cAsunto);
        ManProv_AddEdit.frm.find("#pdf_id_tram_envioSITD").val(data.PDF_TRAMITE_SITD);
    }
    else {
        ManProv_AddEdit.frm.find("#txtDocumentoSITD").val(data.cCodificacion);
        ManProv_AddEdit.frm.find("#txtCodDocumentoSITD").val(data.iCodTramite);
        ManProv_AddEdit.frm.find("#txtNroDocumentoSITD").val(data.cNroDocumento);
        ManProv_AddEdit.frm.find("#txtFechaDocumentoSITD").val(data.fFecDocumento);
        ManProv_AddEdit.frm.find("#txtAsuntoSITD").val(data.cAsunto);
        ManProv_AddEdit.frm.find("#pdf_id_tram_envioSITD").val(data.PDF_TRAMITE_SITD);
    }
    utilSigo.toastSuccess("", "Se selecciono correctamente el documento");
    utilSigo.fnCloseModal("modalBuscarDocSITD");
}

ManProv_AddEdit.fnDownloadDocSITD = function (idControl) {
    var idArchivo = ManProv_AddEdit.frm.find("#" + idControl).val().trim();
    if (idArchivo != "" && idArchivo != null) {
        let carpeta = "";
        carpeta = "Ruta_SITD";
        document.location = `${urlLocalSigo}${carpeta}` + idArchivo;
    }
    else {
        utilSigo.toastWarning("Aviso", "No existe archivo a descargar");
    }
}

ManProv_AddEdit.fnBusDocEnv = function() {    
    var url = urlLocalSigo + "General/Controles/_MemConsultaSITD";
    var option = { url: url, datos: { op: "DOC_SALIDA_MEM" }, type: 'GET', divId: 'modalBuscarDocSITD' };
    utilSigo.fnOpenModal(option, function () {        
        _cMemSITD.fnAsignarDatos = function (obj) {            
            if (obj != null && obj != "") {
                var data = _cMemSITD.dt.row($(obj).parents('tr')).data();
                ManProv_AddEdit.frm.find("#iconOficioEnv").attr('style', 'display:none;');
                ManProv_AddEdit.fnAsignarSTID(data, "DOC_SALIDA");
            }
        }
        _cMemSITD.fnInit();
    });
};

ManProv_AddEdit.fnBuscarPersona = function (_dom, _tipoPersona) {
    var url = urlLocalSigo + "General/Controles/_BuscarPersonaGeneral";
    var option = { url: url, type: 'GET', datos: { asBusGrupo: "PERSONA", asCodPTipo: "TODOS", asTipoPersona: _tipoPersona }, divId: "mdlBuscarPersona" };
    utilSigo.fnOpenModal(option, function () {
        _bPerGen.fnAsignarDatos = function (obj) {
            if (obj != null && obj != "") {
                var data = _bPerGen.dtBuscarPerona.row($(obj).parents('tr')).data();
                switch (_dom) {
                    case "PROFESIONAL":
                        ManProv_AddEdit.frm.find("#hdfCodProfesional").val(data["COD_PERSONA"]);
                        ManProv_AddEdit.frm.find("#txtProfesional").val(data["PERSONA"]);
                        break;

                }
                utilSigo.fnCloseModal("mdlBuscarPersona");
            }
        };
        _bPerGen.fnInit();
    });
};

ManProv_AddEdit.fnViewModalUbigeo = function () {
    var url = initSigo.urlControllerGeneral + "_Ubigeo";
    var option = { url: url, type: 'POST', datos: {}, divId: "mdlControles_Ubigeo" };
    utilSigo.fnOpenModal(option, function () {
        _Ubigeo.fnSelectUbigeo = function (_ubigeoText, _ubigeoId) {
            ManProv_AddEdit.frm.find("#hdfCodUbigeo").val(_ubigeoId);
            ManProv_AddEdit.frm.find("#txtUbigeo").val(_ubigeoText);
            $("#mdlControles_Ubigeo").modal('hide');
        }
        _Ubigeo.fnLoadModalView(ManProv_AddEdit.frm.find("#hdfCodUbigeo").val());
    }, function () {
        if (!utilSigo.fnValidateForm_HideControl(ManProv_AddEdit.frm, ManProv_AddEdit.frm.find("#hdfCodUbigeo"), ManProv_AddEdit.frm.find("#iconUbigeo"), false)) return false;
        return true;
    }
    );
}

ManProv_AddEdit.regresar = function (appServer) {
    var url = "";
    var tipo = ManProv_AddEdit.frm.find("#hdfTipoProveido").val();
    if (tipo == "0000006") {
        url = urlLocalSigo + "Fiscalizacion/ManProveido/IndexSup";
    }
    else {
        url = urlLocalSigo + "Fiscalizacion/ManProveido/IndexFisca";
    }
   
    window.location = url;

};

ManProv_AddEdit.fnSaveForm = function () {
    let hdfCodProvedio = ManProv_AddEdit.frm.find("#hdfCodProvedio").val();
    let hdfCodTipoProve = ManProv_AddEdit.frm.find("#hdfCodTipoProve").val();
    let RegEstado = ManProv_AddEdit.frm.find("#RegEstado").val();
    let txtTipoProveido = ManProv_AddEdit.frm.find("#txtTipoProveido").val();
    let txtIdODs = ManProv_AddEdit.frm.find("#ddODs").val();
    let txtFechaEmision = ManProv_AddEdit.frm.find("#txtFechaEmision").val();
    let txtReferencia = ManProv_AddEdit.frm.find("#txtReferencia").val();
    let txtObservaciones = ManProv_AddEdit.frm.find("#txtObservaciones").val();
    let hdfTipoProveido = ManProv_AddEdit.frm.find("#hdfTipoProveido").val();
    let txtResolucionDirectoral = ManProv_AddEdit.frm.find("#txtResolucionDirectoral").val();
    let txtResolucionTribunal = ManProv_AddEdit.frm.find("#txtResolucionTribunal").val();
    let txtCodDocumentoSITD = ManProv_AddEdit.frm.find("#txtCodDocumentoSITD").val();
    
    ///Mandatos

    let txtSeDispone = ManProv_AddEdit.frm.find("#txtSeDispone").val();
    let chkMandato = ManProv_AddEdit.frm.find("#chkMandato").is(':checked');
    ///Agregar lista de mandatos

    ///Archivo inf Supervision
    let txtIdSobArchivo = ManProv_AddEdit.frm.find("#ddlSobArchivo").val();

    let txtIdEmiteConst = ManProv_AddEdit.frm.find("#ddlEmiteConst").val();

    let txtSobreArchivo = ManProv_AddEdit.frm.find("#txtSobreArchivo").val();
    let txtIdMedida = ManProv_AddEdit.frm.find("#ddlMedida").val();
    let txtDictaMedida = ManProv_AddEdit.frm.find("#txtDictaMedida").val();

    let chkNuevSuperv = ManProv_AddEdit.frm.find("#chkNuevSuperv").is(':checked');
    let chkEvidIrregular = ManProv_AddEdit.frm.find("#chkEvidIrregular").is(':checked');
    let chkSinIndicios = ManProv_AddEdit.frm.find("#chkSinIndicios").is(':checked');
    let chkDefNot = ManProv_AddEdit.frm.find("#chkDefNot").is(':checked');
    let chkDefTec = ManProv_AddEdit.frm.find("#chkDefTec").is(':checked');
    let chkFallTit = ManProv_AddEdit.frm.find("#chkFallTit").is(':checked');
    let chkArchTemp = ManProv_AddEdit.frm.find("#chkArchTemp").is(':checked');
    let chkSubsVoluntaria = ManProv_AddEdit.frm.find("#chkSubsVoluntaria").is(':checked');
    let txtSubsVoluntaria = ManProv_AddEdit.frm.find("#txtSubsVoluntaria").val();
    let txtOtros = ManProv_AddEdit.frm.find("#txtOtros").val();
    ///Firme Acto administrativo
    let txtIdTipoFirmeza = ManProv_AddEdit.frm.find("#ddlTipoFirmez").val();
    let txtIdCaducidaF = ManProv_AddEdit.frm.find("#ddlCaducidadF").val();
    let txtIdArt363IF = ManProv_AddEdit.frm.find("#ddlArticuloF").val();
    let txtIdMultaF = ManProv_AddEdit.frm.find("#ddlMultaF").val();
    let txtIdMedcorrectivaF = ManProv_AddEdit.frm.find("#ddlMedCorrectivaF").val();
    let txtFechaFirmezaF = ManProv_AddEdit.frm.find("#txtFechaFirmezaF").val();
    ///
    let txtResuelve = ManProv_AddEdit.frm.find("#txtResuelve").val();
    /// Agotada la via administrativa
    let txtIdTipoAgotada = ManProv_AddEdit.frm.find("#ddlTipoAgotada").val();
    let txtIdConfirRD = ManProv_AddEdit.frm.find("#ddlConfirmRDAV").val();
    /// Disposicion Judicial
    let txtRecomienda = ManProv_AddEdit.frm.find("#txtRecomienda").val();
    /// admisibilidad
    let chkConceder = ManProv_AddEdit.frm.find("#chkConceder").is(':checked');
    let chkImprocedente = ManProv_AddEdit.frm.find("#chkImprocedente").is(':checked');
    let chkInadmisible = ManProv_AddEdit.frm.find("#chkInadmisible").is(':checked');
    let chkTFFS = ManProv_AddEdit.frm.find("#chkTFFS").is(':checked');
    let txtDesTFFS = ManProv_AddEdit.frm.find("#txtDesTFFS").val();

    ///cumplimiento
    let txtFechaCumpleMCorrectiva = ManProv_AddEdit.frm.find("#txtFechaCumpleMCorrectiva").val();
    let chkCumpleMCorrectiva = ManProv_AddEdit.frm.find("#chkCumpleMCorrectiva").is(':checked');
    let CumpleMCorrectivaDetalle = ManProv_AddEdit.frm.find("#CumpleMCorrectivaDetalle").val();
    /// Disposicion PJ
    let chkMedCaut = ManProv_AddEdit.frm.find("#chkMedCaut").is(':checked');

    let chckCaducidad = ManProv_AddEdit.frm.find("#chckCaducidad").is(':checked');
    let chkInfraccion = ManProv_AddEdit.frm.find("#chkInfraccion").is(':checked');
    let chkPM = ManProv_AddEdit.frm.find("#chkPM").is(':checked');
    let chkGTF = ManProv_AddEdit.frm.find("#chkGTF").is(':checked');
    let chkTrozas = ManProv_AddEdit.frm.find("#chkTrozas").is(':checked');

    let txtExpedientePJ = ManProv_AddEdit.frm.find("#txtExpedientePJ").val();
    let txtJuzagdo = ManProv_AddEdit.frm.find("#txtJuzagdo").val();
    let txtFechaJud = ManProv_AddEdit.frm.find("#txtFechaJud").val();
    let txtIdNotPJ = ManProv_AddEdit.frm.find("#ddlCaducidadF").val();
    let txtPlazoJud = ManProv_AddEdit.frm.find("#txtPlazoJud").val();
    let txtMandatoJudicial = ManProv_AddEdit.frm.find("#txtMandatoJudicial").val();

    let txtObservacionesTSC = ManProv_AddEdit.frm.find("#txtObservacionesTSC").val();
    let chkCaducidadParte = ManProv_AddEdit.frm.find("#chkCaducidadParte").is(':checked');

    ///notificacion
    let chkTitular = ManProv_AddEdit.frm.find("#chkTitular").is(':checked');
    let txtTitular = ManProv_AddEdit.frm.find("#txtTitular").val();
    let chkResFundado = ManProv_AddEdit.frm.find("#chkResFundado").is(':checked');
    let chkResInfundado = ManProv_AddEdit.frm.find("#chkResInfundado").is(':checked');
    let chkResImprocedente = ManProv_AddEdit.frm.find("#chkResImprocedente").is(':checked');
    let chkDGFFS = ManProv_AddEdit.frm.find("#chkDGFFS").is(':checked');
    let txtDescDGFFS = ManProv_AddEdit.frm.find("#txtDescDGFFS").val();
    let chkProgramaRegional = ManProv_AddEdit.frm.find("#chkProgramaRegional").is(':checked');
    let txtDescProgramaRegional = ManProv_AddEdit.frm.find("#txtDescProgramaRegional").val();
    let chkMinPublico = ManProv_AddEdit.frm.find("#chkMinPublico").is(':checked');
    let txtDescMinPublico = ManProv_AddEdit.frm.find("#txtDescMinPublico").val();
    let chkMINEMMIN = ManProv_AddEdit.frm.find("#chkMINEMMIN").is(':checked');
    let txtDescMINEMMIN = ManProv_AddEdit.frm.find("#txtDescMINEMMIN").val();
    let chkColegioIng = ManProv_AddEdit.frm.find("#chkColegioIng").is(':checked');
    let txtDescColegioIng = ManProv_AddEdit.frm.find("#txtDescColegioIng").val();

    let chkATFFS = ManProv_AddEdit.frm.find("#chkATFFS").is(':checked');
    let txtDescATFFS = ManProv_AddEdit.frm.find("#txtDescATFFS").val();
    let chkOCI = ManProv_AddEdit.frm.find("#chkOCI").is(':checked');
    let txtDescOCI = ManProv_AddEdit.frm.find("#txtDescOCI").val();
    let chkOEFA = ManProv_AddEdit.frm.find("#chkOEFA").is(':checked');
    let txtDescOEFA = ManProv_AddEdit.frm.find("#txtDescOEFA").val();

    let chkSUNAT = ManProv_AddEdit.frm.find("#chkSUNAT").is(':checked');
    let txtDescSUNAT = ManProv_AddEdit.frm.find("#txtDescSUNAT").val();
    let chkSERFOR = ManProv_AddEdit.frm.find("#chkSERFOR").is(':checked');
    let txtDescSERFOR = ManProv_AddEdit.frm.find("#txtDescSERFOR").val();
    let chkConta = ManProv_AddEdit.frm.find("#chkConta").is(':checked');
    let txtContaDetalle = ManProv_AddEdit.frm.find("#txtContaDetalle").val();
    let chktesoreria = ManProv_AddEdit.frm.find("#chktesoreria").is(':checked');
    let txtTesoreriaOsinfor = ManProv_AddEdit.frm.find("#txtTesoreriaOsinfor").val();
    let chkOTROS = ManProv_AddEdit.frm.find("#chkOTROS").is(':checked');
    let txtDescOTROS = ManProv_AddEdit.frm.find("#txtDescOTROS").val();
    let chkIncumpleDirectiva = ManProv_AddEdit.frm.find("#chkIncumpleDirectiva").is(':checked');
    let modelProv = {
        hdfCodProvedio,
        hdfCodTipoProve,
        RegEstado,
        txtTipoProveido,
        txtIdODs,
        txtFechaEmision,
        txtReferencia,
        txtObservaciones,
        txtSeDispone,
        chkMandato,
        txtIdSobArchivo,
        txtIdEmiteConst,
        txtSobreArchivo,
        txtIdMedida,
        txtDictaMedida,
        chkNuevSuperv,
        chkEvidIrregular,
        chkSinIndicios,
        chkDefNot,
        chkDefTec,
        chkFallTit,
        chkArchTemp,
        chkSubsVoluntaria,
        txtSubsVoluntaria,
        txtOtros,
        txtIdTipoFirmeza,
        txtIdCaducidaF,
        txtIdArt363IF,
        txtIdMultaF,
        txtIdMedcorrectivaF,
        txtFechaFirmezaF,
        txtResuelve,
        txtIdTipoAgotada,
        txtIdConfirRD,
        txtRecomienda,
        chkConceder,
        chkImprocedente,
        chkInadmisible,
        chkTFFS,
        txtDesTFFS,
        txtFechaCumpleMCorrectiva,
        chkCumpleMCorrectiva,
        CumpleMCorrectivaDetalle,
        chkMedCaut,
        chckCaducidad,
        chkInfraccion,
        chkPM,
        chkGTF,
        chkTrozas,
        txtExpedientePJ,
        txtJuzagdo,
        txtFechaJud,
        txtIdNotPJ,
        txtPlazoJud,
        txtMandatoJudicial,
        txtObservacionesTSC,
        chkCaducidadParte,
        chkTitular,
        txtTitular,
        chkDGFFS,
        txtDescDGFFS,
        chkProgramaRegional,
        txtDescProgramaRegional,
        chkMinPublico,
        txtDescMinPublico,
        chkMINEMMIN,
        txtDescMINEMMIN,
        chkColegioIng,
        txtDescColegioIng,
        chkATFFS,
        txtDescATFFS,
        chkOCI,
        txtDescOCI,
        chkOEFA,
        txtDescOEFA,
        chkSUNAT,
        txtDescSUNAT,
        chkSERFOR,
        txtDescSERFOR,
        chkConta,
        txtContaDetalle,
        chktesoreria,
        txtTesoreriaOsinfor,
        chkOTROS,
        txtDescOTROS,
        hdfTipoProveido,
        chkIncumpleDirectiva,
        txtResolucionDirectoral,
        txtCodDocumentoSITD,
        txtResolucionTribunal,
        chkResFundado,
        chkResInfundado,
        chkResImprocedente
    }

    ///control de calidad
    modelProv.vmControlCalidad = _ControlCalidad.fnGetDatosControlCalidad();
    /// Listas
    modelProv.ListInfOrExp = _renderListExpediente.fnGetList();
    modelProv.listEliTabla = _renderListExpediente.tbEliTABLA;

    modelProv.ListFuncionario = _renderListProf.fnGetList();
    modelProv.listEliTablaProf = _renderListProf.tbEliTABLA;

    if (ManProv_AddEdit.frm.find("#hdfCodTipoProve").val() == "0000061") {
        if (ManProv_AddEdit.frm.find("#chkSubsVoluntaria").is(':checked')) {
            if (!utilSigo.ValidaTexto("txtSubsVoluntaria", "Ingrese un tercero solidario")) return false;
        }
    }

    utilSigo.dialogConfirm("", "Está seguro registrar los datos?", function (r) {
        if (r) {
            let url = urlLocalSigo + "Fiscalizacion/ManProveido/AddEditRD";
            let option = { url: url, datos: JSON.stringify(modelProv), type: 'POST' };
            utilSigo.fnAjax(option, function (data) {
                if (data.success) {
                    if (hdfTipoProveido == "0000006") {
                        window.location = `${urlLocalSigo}/Fiscalizacion/ManProveido/IndexSup`;
                        utilSigo.toastSuccess("Éxito", "Datos actualizados correctamente");
                    }
                    else {
                        window.location = `${urlLocalSigo}/Fiscalizacion/ManProveido/IndexFisca`;
                        utilSigo.toastSuccess("Éxito", "Datos actualizados correctamente");
                    }
                }
                else {
                    utilSigo.toastWarning("Aviso", data.msj);
                }
            });
        }
    });
};

$(document).ready(function () {
    ManProv_AddEdit.frm = $("#frmAddOrEditProv");
    ManProv_AddEdit.iniciarEventos();

});