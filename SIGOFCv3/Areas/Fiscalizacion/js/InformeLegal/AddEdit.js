"use strict";
var ManInfLegal_AddEdit = {};

//para iniciar los eventos
ManInfLegal_AddEdit.iniciarEventos = function () {
    ManInfLegal_AddEdit.frm.find("#txtFechaLegal").datepicker({ format: "dd/mm/yyyy", autoclose: true, language: 'es' });
    ManInfLegal_AddEdit.tbEliTABLA = {};
}

//vuelve a la vista principal del listado
ManInfLegal_AddEdit.regresar = function (appServer) {
    var url = "";
    url = urlLocalSigo + "Fiscalizacion/InformeLegal/Index";
    window.location = url;

};

ManInfLegal_AddEdit.fnBuscarPersona = function (_dom, _tipoPersona) {
    var url = urlLocalSigo + "General/Controles/_BuscarPersonaGeneral";
    var option = { url: url, type: 'GET', datos: { asBusGrupo: "PERSONA", asCodPTipo: "TODOS", asTipoPersona: _tipoPersona }, divId: "mdlBuscarPersona" };
    utilSigo.fnOpenModal(option, function () {
        _bPerGen.fnAsignarDatos = function (obj) {
            if (obj != null && obj != "") {
                var data = _bPerGen.dtBuscarPerona.row($(obj).parents('tr')).data();
                switch (_dom) {
                    case "PROFESIONAL":
                        ManInfLegal_AddEdit.frm.find("#hdfCodProfesional").val(data["COD_PERSONA"]);
                        ManInfLegal_AddEdit.frm.find("#txtProfesional").val(data["PERSONA"]);
                        ManInfLegal_AddEdit.frm.find("#hdTipoProfesional").val(_tipoPersona);
                        break;
                    case "TERCERO":
                        _renderFinalInstruccion.frm.find("#hdfCodTerceroSolidario").val(data["COD_PERSONA"]);
                        _renderFinalInstruccion.frm.find("#txtTerceroSolidario").val(data["PERSONA"]);
                        break;
                }
                utilSigo.fnCloseModal("mdlBuscarPersona");
            }
        };
        _bPerGen.fnInit();
    });
};

ManInfLegal_AddEdit.fnViewModalUbigeo = function () {
    var url = initSigo.urlControllerGeneral + "_Ubigeo";
    var option = { url: url, type: 'POST', datos: {}, divId: "mdlControles_Ubigeo" };
    utilSigo.fnOpenModal(option, function () {
        _Ubigeo.fnSelectUbigeo = function (_ubigeoText, _ubigeoId) {
            ManInfLegal_AddEdit.frm.find("#hdfCodUbigeo").val(_ubigeoId);
            ManInfLegal_AddEdit.frm.find("#txtUbigeo").val(_ubigeoText);
            $("#mdlControles_Ubigeo").modal('hide');
        }
        _Ubigeo.fnLoadModalView(ManInfLegal_AddEdit.frm.find("#hdfCodUbigeo").val());
    }, function () {
            if (!utilSigo.fnValidateForm_HideControl(ManInfLegal_AddEdit.frm, ManInfLegal_AddEdit.frm.find("#hdfCodUbigeo"), ManInfLegal_AddEdit.frm.find("#iconUbigeo"), false)) return false;
        return true;
    }
    );
}


ManInfLegal_AddEdit.fnSubmitForm = function () {
    var controls = ["ddlIndicadorId", "txtNumIlegal", "txtFechaLegal"];
    /*if (!utilSigo.fnValidateForm(ManInfLegal_AddEdit.frm, controls)) {
        alert('error');
        return ManInfLegal_AddEdit.frm.valid();
    }*/
    ManInfLegal_AddEdit.frm.submit();
}

ManInfLegal_AddEdit.fnSaveForm = function () {
    //capturando las variables 
    let hdfCodInfLegal = ManInfLegal_AddEdit.frm.find("#hdfCodInfLegal").val();
    let hdfCodTipoIlegal = ManInfLegal_AddEdit.frm.find("#hdfCodTipoIlegal").val();
    let hdfCodProfesional = ManInfLegal_AddEdit.frm.find("#hdfCodProfesional").val();
    let RegEstado = ManInfLegal_AddEdit.frm.find("#RegEstado").val();

    //datos generales
    let txtProfesional = ManInfLegal_AddEdit.frm.find("#txtProfesional").val();
    let txtNumIlegal = ManInfLegal_AddEdit.frm.find("#txtNumIlegal").val();
    let txtFechaLegal = ManInfLegal_AddEdit.frm.find("#txtFechaLegal").val();
    let txtPresentoProyecto = ManInfLegal_AddEdit.frm.find("#txtPresentoProyecto").is(':checked');
    let txtInfDirectoral = ManInfLegal_AddEdit.frm.find("#txtInfDirectoral").is(':checked');
    let txtInfSubDirectoral = ManInfLegal_AddEdit.frm.find("#txtInfSubDirectoral").is(':checked');
    let txtObservaciones = ManInfLegal_AddEdit.frm.find("#txtObservaciones").val();
    let chkPublicar = ManInfLegal_AddEdit.frm.find("#chkPublicar").is(':checked');

    //Evaluación del Informe de Supervisión/Suspensión 0000001
    // Recomendacion inicio PAU
    let txtIdRecomendacion = "";
    if (hdfCodTipoIlegal == "0000001") {
        txtIdRecomendacion = _renderRecomendaciones.frm.find("#ddlRecomendaciones").val();
    }
    //inicio pau
    let chkInexEspecie = ManInfLegal_AddEdit.frm.find("#chkInexEspecie").is(':checked');
    let chkDifEspecie = ManInfLegal_AddEdit.frm.find("#chkDifEspecie").is(':checked');
    let chkSobreEstimacion = ManInfLegal_AddEdit.frm.find("#chkSobreEstimacion").is(':checked');

    // Archivo y nueva supervision
    let chkNuevaSupervision = ManInfLegal_AddEdit.frm.find("#chkNuevaSupervision").is(':checked');
    let chkEvidencia = ManInfLegal_AddEdit.frm.find("#chkEvidencia").is(':checked');
    let chkSinIndicios = ManInfLegal_AddEdit.frm.find("#chkSinIndicios").is(':checked');
    let chkDeficienciaNot = ManInfLegal_AddEdit.frm.find("#chkDeficienciaNot").is(':checked');
    let chkDeficienciaTec = ManInfLegal_AddEdit.frm.find("#chkDeficienciaTec").is(':checked');
    let chkFallecimientoTitular = ManInfLegal_AddEdit.frm.find("#chkFallecimientoTitular").is(':checked');
    let txtOtros = ManInfLegal_AddEdit.frm.find("#txtOtros").val();
    let chkMedidasCorrectivas = ManInfLegal_AddEdit.frm.find("#chkMedidasCorrectivas").is(':checked');
    let txtDescMedidadCorrectivas = ManInfLegal_AddEdit.frm.find("#txtDescMedidadCorrectivas").val();
    let txtImplMCDias = ManInfLegal_AddEdit.frm.find("#txtImplMCDias").val();
    let txtImplMCMeses = ManInfLegal_AddEdit.frm.find("#txtImplMCMeses").val();
    let txtImplMCAnio = ManInfLegal_AddEdit.frm.find("#txtImplMCAnio").val();
    let txtInfMCDia = ManInfLegal_AddEdit.frm.find("#txtInfMCDia").val();
    let txtInfMCMeses = ManInfLegal_AddEdit.frm.find("#txtInfMCMeses").val();
    let txtInfMCAnio = ManInfLegal_AddEdit.frm.find("#txtInfMCAnio").val();
    //lista especies MC 
    let chkMandato = ManInfLegal_AddEdit.frm.find("#chkMandato").is(':checked');
    let txtDescMandato = ManInfLegal_AddEdit.frm.find("#txtDescMandato").val();


    //Aplicación de Medidas Cautelares (Antes del PAU) 0000129
    let chkGTF = ManInfLegal_AddEdit.frm.find("#chkGTF").is(':checked');
    let chkLTrozas = ManInfLegal_AddEdit.frm.find("#chkLTrozas").is(':checked');
    let chkPlanManejo = ManInfLegal_AddEdit.frm.find("#chkPlanManejo").is(':checked');
    let chkPOA = ManInfLegal_AddEdit.frm.find("#chkPOA").is(':checked');
    let chkPorEspecie = ManInfLegal_AddEdit.frm.find("#chkPorEspecie").is(':checked');
    // en sesion del controlador lista de especies antes del PAU
    let txtDescMedidasCautelaresAP = ManInfLegal_AddEdit.frm.find("#txtDescMedidasCautelaresAP").val();
    let txtRecomendacionesAP = ManInfLegal_AddEdit.frm.find("#txtRecomendacionesAP").val();
    let hdfCodigoIlegalAlerta = ManInfLegal_AddEdit.frm.find("#hdfCodigoIlegalAlerta").val();

    //Evaluación del Recurso de Reconsideración 0000004
    let chkMedCautelarRR = ManInfLegal_AddEdit.frm.find("#chkMedCautelarRR").is(':checked');
    let chkFinPauRR = ManInfLegal_AddEdit.frm.find("#chkFinPauRR").is(':checked');
    let chkImprocedenteRR = ManInfLegal_AddEdit.frm.find("#chkImprocedenteRR").is(':checked');
    let chkFueraPlazoRR = ManInfLegal_AddEdit.frm.find("#chkFueraPlazoRR").is(':checked');
    let chkFaltaPruebasRR = ManInfLegal_AddEdit.frm.find("#chkFaltaPruebasRR").is(':checked');
    let chkProcedenteRR = ManInfLegal_AddEdit.frm.find("#chkProcedenteRR").is(':checked');
    let chkFundadoRR = ManInfLegal_AddEdit.frm.find("#chkFundadoRR").is(':checked');
    let chkFundadoParteRR = ManInfLegal_AddEdit.frm.find("#chkFundadoParteRR").is(':checked');
    let chkInfundadoRR = ManInfLegal_AddEdit.frm.find("#chkInfundadoRR").is(':checked');
    let txtInfundadoObsRR = ManInfLegal_AddEdit.frm.find("#txtInfundadoObsRR").val();
    let txtPruebasPresentadasRR = ManInfLegal_AddEdit.frm.find("#txtPruebasPresentadasRR").val();

    //Evaluación de la Etapa Instructiva(inactivo) 0000002
    //Final de Instrucción 0000107
    //De fase decisora 0000108
    let chkInspeccionOcularFI = ManInfLegal_AddEdit.frm.find("#chkInspeccionOcularFI").is(':checked');
    let chkEmitirRDFI = ManInfLegal_AddEdit.frm.find("#chkEmitirRDFI").is(':checked');
    let chkSancionFI = ManInfLegal_AddEdit.frm.find("#chkSancionFI").is(':checked');
    let chkAmonestacionesFI = ManInfLegal_AddEdit.frm.find("#chkAmonestacionesFI").is(':checked');
    let chkArchivoFI = ManInfLegal_AddEdit.frm.find("#chkArchivoFI").is(':checked');
    let chkMedidasProvisoriasFI = ManInfLegal_AddEdit.frm.find("#chkMedidasProvisoriasFI").is(':checked');
    let txtMedidasProvisoriasFI = ManInfLegal_AddEdit.frm.find("#txtMedidasProvisoriasFI").val();
    let chkCaducidadRDFI = ManInfLegal_AddEdit.frm.find("#chkCaducidadRDFI").is(':checked');
    let chkAmpliacionFI = ManInfLegal_AddEdit.frm.find("#chkAmpliacionFI").is(':checked');
    let chkAcumulacionFI = ManInfLegal_AddEdit.frm.find("#chkAcumulacionFI").is(':checked');
    let chkMedidaCorrectivaRDFI = ManInfLegal_AddEdit.frm.find("#chkMedidaCorrectivaRDFI").is(':checked');
    let chkNuevaSupervisionFI = ManInfLegal_AddEdit.frm.find("#chkNuevaSupervisionFI").is(':checked');
    let chkNuevaNotificacionFI = ManInfLegal_AddEdit.frm.find("#chkNuevaNotificacionFI").is(':checked');
    let chkRectificacionFI = ManInfLegal_AddEdit.frm.find("#chkRectificacionFI").is(':checked');
    let txtVariarMedCaut = ManInfLegal_AddEdit.frm.find("#txtVariarMedCaut").val();
    let txtOtrosFI = ManInfLegal_AddEdit.frm.find("#txtOtrosFI").val();

    //Otros 0000005
    let txtMotivoOtros = ManInfLegal_AddEdit.frm.find("#txtMotivoOtros").val()
    let txtRecomendacionOtros = ManInfLegal_AddEdit.frm.find("#txtRecomendacionOtros").val();

    if (txtFechaLegal == "") {
        utilSigo.toastWarning("Validación", "Ingrese la fecha del informe legal");
        frm.find("#txtFechaLegal").focus();
        return false;
    }
    let model = {
        hdfCodInfLegal, RegEstado, hdfCodTipoIlegal, hdfCodProfesional, txtProfesional, txtNumIlegal, txtFechaLegal, txtPresentoProyecto, txtInfDirectoral, txtInfSubDirectoral,
        txtObservaciones, txtIdRecomendacion, chkInexEspecie, chkDifEspecie, chkSobreEstimacion, chkNuevaSupervision, chkEvidencia, chkSinIndicios, chkDeficienciaNot,
        chkDeficienciaTec, chkFallecimientoTitular, txtOtros, chkMedidasCorrectivas, txtDescMedidadCorrectivas, txtImplMCDias, txtImplMCMeses, txtImplMCAnio, txtInfMCDia,
        txtInfMCMeses, txtInfMCAnio, chkMandato, txtDescMandato, chkGTF, chkLTrozas, chkPlanManejo, chkPOA, chkPorEspecie, txtDescMedidasCautelaresAP, txtRecomendacionesAP,
        chkMedCautelarRR, chkFinPauRR, chkImprocedenteRR, chkFueraPlazoRR, chkFaltaPruebasRR, chkProcedenteRR, chkFundadoRR, chkFundadoParteRR, chkInfundadoRR,
        txtInfundadoObsRR, txtPruebasPresentadasRR, chkInspeccionOcularFI, chkEmitirRDFI, chkSancionFI, chkAmonestacionesFI, chkArchivoFI, chkMedidasProvisoriasFI,
        txtMedidasProvisoriasFI, chkCaducidadRDFI, chkAmpliacionFI, chkAcumulacionFI, chkMedidaCorrectivaRDFI, chkNuevaSupervisionFI, chkNuevaNotificacionFI,
        chkRectificacionFI, txtVariarMedCaut, txtOtrosFI, txtMotivoOtros, txtRecomendacionOtros, chkPublicar, hdfCodigoIlegalAlerta
    }
    model.vmControlCalidad = _ControlCalidad.fnGetDatosControlCalidad();
    model.tbInforme = _renderListExpediente.fnGetList();
    model.tbEliTABLA = _renderListExpediente.tbEliTABLA;
    if (hdfCodTipoIlegal == "0000001") {
        model.tbEliTABLAEnciso = _rederListaIncisos.tbEliTABLA;
        model.tbEliTABLAEspecie = _renderListaEspecies.tbEliTABLA;
        model.listaInfracciones = _rederListaIncisos.fnGetList();
        model.listaEspeciesMC = _renderListaEspecies.fnGetList();

    }
    if (hdfCodTipoIlegal == "0000129") {
        model.tbEliTABLAEspecieAP = _renderListaEspeciesA.tbEliTABLA;
        model.listaEspeciesAP = _renderListaEspeciesA.fnGetList();
    }

    if ( hdfCodTipoIlegal == "0000107" || hdfCodTipoIlegal == "0000108") {
        model.tbEliTABLAEnciso = _rederListaIncisos.tbEliTABLA;
        model.listaInfracciones = _rederListaIncisos.fnGetList();

        //lista de expedientes de tramite documentario 20/09/2022 TGS
        model.listSTD01 = _renderFinalInstruccion.fnGetListAllanamiento();
        model.listSTD02 = _renderFinalInstruccion.fnGetListSubsanacion();
        model.listEliTSTD01 = _renderFinalInstruccion.tbEliTABLA;
        model.chkTerceroSolidario = _renderFinalInstruccion.frm.find("#chkTerceroSolidario").is(':checked');
        model.hdfCodTerceroSolidario = _renderFinalInstruccion.frm.find("#hdfCodTerceroSolidario").val();
        model.txtTerceroSolidario = _renderFinalInstruccion.frm.find("#txtTerceroSolidario").val();

        if (_renderFinalInstruccion.frm.find("#chkTerceroSolidario").is(':checked')) {
            if (!utilSigo.ValidaTexto("hdfCodTerceroSolidario", "Ingrese un tercero solidario")) return false;
        }

        model.listaInfraccionesSubsanadas = _renderFinalInstruccion.fnGetListInfraccionSubsanada();
        model.tbEliTABLAEncisoSubsanado = _renderFinalInstruccion.tbEliTABLAInfraccionSubsanada;
    }
   

    if (hdfCodTipoIlegal != "0000002" || hdfCodTipoIlegal != "0000003") {

        utilSigo.dialogConfirm("", "Está seguro registrar los datos?", function (r) {
            if (r) {
                let url = urlLocalSigo + "Fiscalizacion/InformeLegal/AddEdit";
                let option = { url: url, datos: JSON.stringify(model), type: 'POST' };
                utilSigo.fnAjax(option, function (data) {
                    if (data.success) { 
                        utilSigo.toastSuccess("Éxito", "Datos actualizados correctamente");

                        var codigo = data.values[0]?.split('|')[0];
                        window.location.href = `${window.location.href.split('?')[0]}?asCodInfLegal=${codigo}&asCodTipoIL=`;
                        //window.location = `${urlLocalSigo}/Fiscalizacion/InformeLegal/Index`;                        
                    }
                    else {
                        utilSigo.toastWarning("Aviso", data.msj);
                    }
                });
            }
        });
    }
    else {
        utilSigo.toastWarning("Aviso", "no puede modificar registros historicos");
    }
}



$(document).ready(function () {
    ManInfLegal_AddEdit.frm = $("#frmInfLegalRegistro");
    ManInfLegal_AddEdit.iniciarEventos();

});
