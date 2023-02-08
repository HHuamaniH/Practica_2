"use strict";
var ManInfTecnico_AddEdit = {};

//para iniciar los eventos
ManInfTecnico_AddEdit.iniciarEventos = function () {
    ManInfTecnico_AddEdit.frm.find("#txtFechaEmision").datepicker({ format: "dd/mm/yyyy", autoclose: true, language: 'es' });
    ManInfTecnico_AddEdit.frm.find("#txtFechaInicio").datepicker({ format: "dd/mm/yyyy", autoclose: true, language: 'es' });
    ManInfTecnico_AddEdit.frm.find("#txtFechaFin").datepicker({ format: "dd/mm/yyyy", autoclose: true, language: 'es' });
    
    ManInfTecnico_AddEdit.tbEliTABLA = {};
}

//vuelve a la vista principal del listado
ManInfTecnico_AddEdit.regresar = function (appServer) {
    var url = "";
    url = urlLocalSigo + "Fiscalizacion/ManInformeTecnico/Index";
    window.location = url;

};

ManInfTecnico_AddEdit.fnBuscarPersona = function (_dom, _tipoPersona) {
    var url = urlLocalSigo + "General/Controles/_BuscarPersonaGeneral";
    var option = { url: url, type: 'GET', datos: { asBusGrupo: "PERSONA", asCodPTipo: "TODOS", asTipoPersona: _tipoPersona }, divId: "mdlBuscarPersona" };
    utilSigo.fnOpenModal(option, function () {
        _bPerGen.fnAsignarDatos = function (obj) {
            if (obj != null && obj != "") {
                var data = _bPerGen.dtBuscarPerona.row($(obj).parents('tr')).data();
                switch (_dom) {
                    case "PROFESIONAL":
                        ManInfTecnico_AddEdit.frm.find("#hdfCodPersona").val(data["COD_PERSONA"]);
                        ManInfTecnico_AddEdit.frm.find("#txtPersona").val(data["PERSONA"]);
                        break;
                    
                }
                utilSigo.fnCloseModal("mdlBuscarPersona");
            }
        };
        _bPerGen.fnInit();
    });
};

ManInfTecnico_AddEdit.fnViewModalUbigeo = function () {
    var url = initSigo.urlControllerGeneral + "_Ubigeo";
    var option = { url: url, type: 'POST', datos: {}, divId: "mdlControles_Ubigeo" };
    utilSigo.fnOpenModal(option, function () {
        _Ubigeo.fnSelectUbigeo = function (_ubigeoText, _ubigeoId) {
            ManInfTecnico_AddEdit.frm.find("#hdfCodUbigeo").val(_ubigeoId);
            ManInfTecnico_AddEdit.frm.find("#txtUbigeo").val(_ubigeoText);
            $("#mdlControles_Ubigeo").modal('hide');
        }
        _Ubigeo.fnLoadModalView(ManInfTecnico_AddEdit.frm.find("#hdfCodUbigeo").val());
    }, function () {
        if (!utilSigo.fnValidateForm_HideControl(ManInfTecnico_AddEdit.frm, ManInfTecnico_AddEdit.frm.find("#hdfCodUbigeo"), ManInfTecnico_AddEdit.frm.find("#iconUbigeo"), false)) return false;
        return true;
    }
    );
}

ManInfTecnico_AddEdit.fnSaveForm = function () {
    //capturando las variables 
    //capturando variables 
    let hdfCodFCTipo = ManInfTecnico_AddEdit.frm.find("#hdfCodFCTipo").val();
    let RegEstado = ManInfTecnico_AddEdit.frm.find("#RegEstado").val();
    let hdfCodigoInfTec = ManInfTecnico_AddEdit.frm.find("#hdfCodigoInfTec").val();
    let txtRecomendacion = ManInfTecnico_AddEdit.frm.find("#txtRecomendacion").val();
    let txtNumInforme = ManInfTecnico_AddEdit.frm.find("#txtNumInforme").val(); 
    let hdfCodPersona = ManInfTecnico_AddEdit.frm.find("#hdfCodPersona").val(); 
    let txtPersona = ManInfTecnico_AddEdit.frm.find("#txtPersona").val(); 
    let txtFechaEmision = ManInfTecnico_AddEdit.frm.find("#txtFechaEmision").val(); 
    let txtDescripMulta = ManInfTecnico_AddEdit.frm.find("#txtDescripMulta").val(); 
    let txtDescripMultaAnt = ManInfTecnico_AddEdit.frm.find("#txtDescripMultaAnt").val(); 
    let txtDescripInforme = ManInfTecnico_AddEdit.frm.find("#txtDescripInforme").val();
    let txtMultaRecomendSol = ManInfTecnico_AddEdit.frm.find("#txtMultaRecomendSol").val();
    let txtMultaRecomendUIt = ManInfTecnico_AddEdit.frm.find("#txtMultaRecomendUIt").val();
    let txtMotivMulta = ManInfTecnico_AddEdit.frm.find("#txtMotivMulta").val();
    let txtInfAclaracion = ManInfTecnico_AddEdit.frm.find("#txtInfAclaracion").val();
    let txtDocumentosAdj = ManInfTecnico_AddEdit.frm.find("#txtDocumentosAdj").val();
    let txtConclusion = ManInfTecnico_AddEdit.frm.find("#txtConclusion").val();
    let txtInfComplemento = ManInfTecnico_AddEdit.frm.find("#txtInfComplemento").val();
    let txtReferencia = ManInfTecnico_AddEdit.frm.find("#txtReferencia").val();
    let txtFechaInicio = ManInfTecnico_AddEdit.frm.find("#txtFechaInicio").val();
    let txtFechaFin = ManInfTecnico_AddEdit.frm.find("#txtFechaFin").val();
    let txtPrincipalesResultados = ManInfTecnico_AddEdit.frm.find("#txtPrincipalesResultados").val();
    let txtComentarios = ManInfTecnico_AddEdit.frm.find("#txtComentarios").val();
    let txtIdCodOD = ManInfTecnico_AddEdit.frm.find("#ddlOds").val();
    let txtNumInfAct = ManInfTecnico_AddEdit.frm.find("#txtNumInfAct").val();
    let txtConclusionAct = ManInfTecnico_AddEdit.frm.find("#txtConclusionAct").val();
    let txtRecomendacionAct = ManInfTecnico_AddEdit.frm.find("#txtRecomendacionAct").val();
    let txtObservacion = ManInfTecnico_AddEdit.frm.find("#txtObservacion").val();
    let chkCambiaVol = ManInfTecnico_AddEdit.frm.find("#chkCambiaVol").is(':checked');
    let chkCambiaEstado = ManInfTecnico_AddEdit.frm.find("#chkCambiaEstado").is(':checked');
    /*let txtMultaRecomendUIt = ManInfTecnico_AddEdit.frm.find("#txtMultaRecomendUIt").val();
    let txtMultaRecomendSol = ManInfTecnico_AddEdit.frm.find("#txtMultaRecomendSol").val();*/
    let txtConclusionR = ManInfTecnico_AddEdit.frm.find("#txtConclusionR").val();

    let model = {
        hdfCodFCTipo,
        RegEstado,
        hdfCodigoInfTec,
        txtRecomendacion,
        txtNumInforme,
        hdfCodPersona,
        txtPersona,
        txtFechaEmision,
        txtDescripMulta,
        txtDescripMultaAnt,
        txtDescripInforme,
        txtMultaRecomendSol,
        txtMultaRecomendUIt,
        txtMotivMulta,
        txtInfAclaracion,
        txtDocumentosAdj,
        txtConclusion,
        txtInfComplemento,
        txtReferencia,
        txtFechaInicio,
        txtFechaFin,
        txtPrincipalesResultados,
        txtComentarios,
        txtIdCodOD,
        txtNumInfAct,
        txtConclusionAct,
        txtRecomendacionAct,
        txtObservacion,
        chkCambiaVol,
        chkCambiaEstado,
        txtConclusionR

    }
    ///control de calidad
    model.vmControlCalidad = _ControlCalidad.fnGetDatosControlCalidad();
    /// Listas
    model.ListInformes = _renderListExpediente.fnGetList();
    if (hdfCodFCTipo == "0000038") {
        model.Listardetdescargo = _renderEvaluacion.fnGetList();
        model.listEliTablaED = _renderEvaluacion.tbEliTABLA;
        model.Listarlffs = _renderEvaluacion.fnGetList2();
        model.ListVolumen = _renderListVolumen.fnGetList();
        model.listEliTablaVolumen = _renderListVolumen.tbEliTABLA;
    }
    if (hdfCodFCTipo == "0000039") {
        model.ListVolumen = _renderListVolumen.fnGetList();
        model.listEliTablaVolumen = _renderListVolumen.tbEliTABLA;
    }
    if (hdfCodFCTipo == "0000040") {
        model.Listarmulta = _renderFormatoMulta.fnGetList2();
        model.Listarmultaantiguo = _renderFormatoMulta.fnGetList();
        model.listEliTablaMulta = _renderFormatoMulta.tbEliTABLA;
    }
    if (hdfCodFCTipo == "0000041" || hdfCodFCTipo == "0000042" || hdfCodFCTipo == "0000043" || hdfCodFCTipo == "0000044" || hdfCodFCTipo =="0000120") {
        model.ListVolumen = _renderListVolumen.fnGetList();
        model.listEliTablaVolumen = _renderListVolumen.tbEliTABLA;
    }
    
/**
*

public List<Ent_INFTEC> ListInformes { get; set; }
public List<Ent_INFTEC> Listarmultaantiguo { get; set; }
public List<Ent_INFTEC> Listarmulta { get; set; }
public List<Ent_INFTEC> Listardetdescargo { get; set; }
public List<Ent_INFTEC> Listarlffs { get; set; }
public List<Ent_INFTEC> ListVolumen { get; set; }
public List<Ent_INFORME> ListEMaderable { get; set; }
public List<Ent_INFTEC> ListEMaderableSemillero { get; set; }
public List<Ent_INFTEC> ListPManejo { get; set; }
public List<Ent_INFTEC> ListODS { get; set; }
public List<Ent_INFTEC> ListComboEspecies { get; set; }
public List<Ent_INFTEC> ListComboInciso { get; set; }
*/
    // eliminar tabla
    model.listEliTabla = _renderListExpediente.tbEliTABLA;


    utilSigo.dialogConfirm("", "Está seguro registrar los datos?", function (r) {
        if (r) {
            let url = urlLocalSigo + "Fiscalizacion/ManInformeTecnico/AddEditRD";
            let option = { url: url, datos: JSON.stringify(model), type: 'POST' };
            utilSigo.fnAjax(option, function (data) {
                if (data.success) {

                    window.location = `${urlLocalSigo}/Fiscalizacion/ManInformeTecnico/Index`;
                    utilSigo.toastSuccess("Éxito", "Datos actualizados correctamente");
                }
                else {
                    utilSigo.toastWarning("Aviso", data.msj);
                }
            });
        }
    });
}

$(document).ready(function () {
    ManInfTecnico_AddEdit.frm = $("#frmAddOrEditInformeTecnico");
    ManInfTecnico_AddEdit.iniciarEventos();

});