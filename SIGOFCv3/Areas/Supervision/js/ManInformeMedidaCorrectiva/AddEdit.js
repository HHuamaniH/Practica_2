var ManInfMedidaCorrectiva_AddEdit = {};

//para iniciar los eventos
ManInfMedidaCorrectiva_AddEdit.iniciarEventos = function () {
    ManInfMedidaCorrectiva_AddEdit.frm.find("#txtItemFechaIni").datepicker({ format: "dd/mm/yyyy", autoclose: true, language: 'es' });
    ManInfMedidaCorrectiva_AddEdit.frm.find("#txtItemFechaFin").datepicker({ format: "dd/mm/yyyy", autoclose: true, language: 'es' });
    ManInfMedidaCorrectiva_AddEdit.frm.find("#txtItemFechaPresentaTitular").datepicker({ format: "dd/mm/yyyy", autoclose: true, language: 'es' });
    ManInfMedidaCorrectiva_AddEdit.frm.find("#txtItemFechaInstalacion").datepicker({ format: "dd/mm/yyyy", autoclose: true, language: 'es' });

    if (ManInfMedidaCorrectiva_AddEdit.frm.find("#hdfItemTInformeCodigo").val() == "0000011" ||
        ManInfMedidaCorrectiva_AddEdit.frm.find("#hdfItemTInformeCodigo").val() == "0000016" ||
        ManInfMedidaCorrectiva_AddEdit.frm.find("#hdfItemTInformeCodigo").val() == "0000017") {
        $("#pnlItemFechaVerificacion").hide();
        $("#liEvaluacion").show();
        $("#liVerificacion").hide();
        $("#pnlItemConclusion").show();
        $("#pnlItemCumpleMCorrectiva").hide();
    }
    else {
        $("#pnlItemFechaVerificacion").show();
        $("#liEvaluacion").hide();
        $("#liVerificacion").show();
        $("#pnlItemConclusion").hide();
        $("#pnlItemCumpleMCorrectiva").show();
    }
};

//vuelve a la vista principal del listado
ManInfMedidaCorrectiva_AddEdit.regresar = function (appServer) {
    var url = "";
    url = urlLocalSigo + "Supervision/ManInformeMedidaCorrectiva/Index";
    window.location = url;

};

ManInfMedidaCorrectiva_AddEdit.fnBuscarPersona = function (_dom, _tipoPersona) {
    var url = urlLocalSigo + "General/Controles/_BuscarPersonaGeneral";
    var option = { url: url, type: 'GET', datos: { asBusGrupo: "PERSONA", asCodPTipo: "TODOS", asTipoPersona: _tipoPersona }, divId: "mdlBuscarPersona" };
    utilSigo.fnOpenModal(option, function () {
        _bPerGen.fnAsignarDatos = function (obj) {
            if (obj != null && obj != "") {
                var data = _bPerGen.dtBuscarPerona.row($(obj).parents('tr')).data();
                switch (_dom) {
                    case "DIR":
                        ManInfMedidaCorrectiva_AddEdit.frm.find("#hdfItemDirectorCodigo").val(data["COD_PERSONA"]);
                        ManInfMedidaCorrectiva_AddEdit.frm.find("#txtItemDirector").val(data["PERSONA"]);
                        break;
                }
                utilSigo.fnCloseModal("mdlBuscarPersona");
            }
        };
        _bPerGen.fnInit();
    });
};

ManInfMedidaCorrectiva_AddEdit.fnSaveForm = function () {
    let hdfCodInfMedidaCorrectiva = ManInfMedidaCorrectiva_AddEdit.frm.find("#hdfCodInfMedidaCorrectiva").val();
    let hdfItemTInformeCodigo = ManInfMedidaCorrectiva_AddEdit.frm.find("#hdfItemTInformeCodigo").val();
    let RegEstado = ManInfMedidaCorrectiva_AddEdit.frm.find("#RegEstado").val();
    let txtItemTInforme = ManInfMedidaCorrectiva_AddEdit.frm.find("#txtItemTInforme").val();
    let txtItemNumero = ManInfMedidaCorrectiva_AddEdit.frm.find("#txtItemNumero").val();
    let txtItemMotivo = ManInfMedidaCorrectiva_AddEdit.frm.find("#txtItemMotivo").val();
    let txtItemDirector = ManInfMedidaCorrectiva_AddEdit.frm.find("#txtItemDirector").val();
    let hdfItemDirectorCodigo = ManInfMedidaCorrectiva_AddEdit.frm.find("#hdfItemDirectorCodigo").val();
    let txtItemFechaIni = ManInfMedidaCorrectiva_AddEdit.frm.find("#txtItemFechaIni").val();
    let txtItemFechaFin = ManInfMedidaCorrectiva_AddEdit.frm.find("#txtItemFechaFin").val();
    let ddlItemPresentaFechaPlazoId = ManInfMedidaCorrectiva_AddEdit.frm.find("#ddlItemPresentaFechaPlazoId").val();
    let txtItemFechaPresentaTitular = ManInfMedidaCorrectiva_AddEdit.frm.find("#txtItemFechaPresentaTitular").val();
    let ddlItemInformeCompletoId = ManInfMedidaCorrectiva_AddEdit.frm.find("#ddlItemInformeCompletoId").val();
    let ddlItemCuentaFirmaRegenteId = ManInfMedidaCorrectiva_AddEdit.frm.find("#ddlItemCuentaFirmaRegenteId").val();
    let txtItemFechaInstalacion = ManInfMedidaCorrectiva_AddEdit.frm.find("#txtItemFechaInstalacion").val();
    let ddlItemReponeDentroId = ManInfMedidaCorrectiva_AddEdit.frm.find("#ddlItemReponeDentroId").val();
    let ddlItemReponeFueraId = ManInfMedidaCorrectiva_AddEdit.frm.find("#ddlItemReponeFueraId").val();                                                                         
    let ddlItemCumpleCantidadReponeId = ManInfMedidaCorrectiva_AddEdit.frm.find("#ddlItemCumpleCantidadReponeId").val();
    let txtItemConclusion = ManInfMedidaCorrectiva_AddEdit.frm.find("#txtItemConclusion").val();
    let ddlItemCumpleMCorrectivaId = ManInfMedidaCorrectiva_AddEdit.frm.find("#ddlItemCumpleMCorrectivaId").val();
    let ddlItemRemitirDFFFSId = ManInfMedidaCorrectiva_AddEdit.frm.find("#ddlItemRemitirDFFFSId").val();
    let txtItemRecomendacion = ManInfMedidaCorrectiva_AddEdit.frm.find("#txtItemRecomendacion").val();
    let hdfCodigoInfMedidaCorrectivaAlerta = ManInfMedidaCorrectiva_AddEdit.frm.find("#hdfCodigoInfMedidaCorrectivaAlerta").val();
    
    let model = {
        hdfCodInfMedidaCorrectiva, hdfItemTInformeCodigo, RegEstado, txtItemTInforme, txtItemNumero, txtItemMotivo, txtItemDirector, hdfItemDirectorCodigo,
        txtItemFechaIni, txtItemFechaFin, ddlItemPresentaFechaPlazoId, txtItemFechaPresentaTitular, ddlItemInformeCompletoId, ddlItemCuentaFirmaRegenteId, 
        txtItemFechaInstalacion, ddlItemReponeDentroId, ddlItemReponeFueraId, ddlItemCumpleCantidadReponeId, txtItemConclusion, ddlItemCumpleMCorrectivaId,
        ddlItemRemitirDFFFSId, txtItemRecomendacion, hdfCodigoInfMedidaCorrectivaAlerta
    };

    model.vmControlCalidad = _ControlCalidad.fnGetDatosControlCalidad();
    model.tbResponsable = _renderListResponsable.fnGetListResponsable();
    model.tbExpediente = _renderListExpediente.fnGetListExpediente();
    model.tbEspecie = _renderListEspecie.fnGetListEspecie();
    model.tbVertice = _renderListVertice.fnGetListVertice();
    model.tbElimResponsable = _renderListResponsable.fnGetListElimResponsable();
    model.tbElimExpediente = _renderListExpediente.fnGetListElimExpediente();
    model.tbElimEspecie = _renderListEspecie.fnGetListElimEspecie();
    model.tbElimVertice = _renderListVertice.fnGetListElimVertice();
    model.tbMedidaAsociada = _renderListExpediente.fnGetListMedidaAsociada();

    utilSigo.dialogConfirm("", "Está seguro registrar los datos?", function (r) {
        if (r) {
            let url = urlLocalSigo + "Supervision/ManInformeMedidaCorrectiva/Grabar";
            let option = { url: url, datos: JSON.stringify(model), type: 'POST' };
            utilSigo.fnAjax(option, function (data) {
                if (data.success) {
                    window.location = `${urlLocalSigo}/Supervision/ManInformeMedidaCorrectiva/Index`;
                    utilSigo.toastSuccess("Éxito", "Datos actualizados correctamente");
                }
                else {
                    utilSigo.toastWarning("Aviso", data.msj);
                }
            });
        }
    });
};

ManInfMedidaCorrectiva_AddEdit.fnSubmitForm = function () {
    if (_ControlCalidad.fnGetDatosControlCalidad().ddlIndicadorId == '0000000') {
        utilSigo.toastWarning("Aviso", "Debe seleccionar la situación actual de su registro"); return false;
    }
    if (ManInfMedidaCorrectiva_AddEdit.frm.find("#txtItemNumero").val().trim() == '') {
        utilSigo.toastWarning("Aviso", "Ingrese el número de informe"); return false;
    }
    if (ManInfMedidaCorrectiva_AddEdit.frm.find("#txtItemMotivo").val().trim() == '') {
        utilSigo.toastWarning("Aviso", "Ingrese el motivo de la verificación"); return false;
    }
    if (ManInfMedidaCorrectiva_AddEdit.frm.find("#hdfItemDirectorCodigo").val() == '') {
        utilSigo.toastWarning("Aviso", "Seleccione el director de línea"); return false;
    }

    ManInfMedidaCorrectiva_AddEdit.fnSaveForm();
};

$(document).ready(function () {
    ManInfMedidaCorrectiva_AddEdit.frm = $("#frmInfMedidaCorrectivaRegistro");
    ManInfMedidaCorrectiva_AddEdit.iniciarEventos();
});
