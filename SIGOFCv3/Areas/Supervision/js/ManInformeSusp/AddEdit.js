"use strict";
var ManInfSup_AddEdit = {};

ManInfSup_AddEdit.iniciarEventos = function () {
    ManInfSup_AddEdit.frm.find("#txtFechaEmision").datepicker({ format: "dd/mm/yyyy", autoclose: true, language: 'es' });
    ManInfSup_AddEdit.frm.find("#txtFechaActa").datepicker({ format: "dd/mm/yyyy", autoclose: true, language: 'es' });
    ManInfSup_AddEdit.tbEliTABLA = {};
}

ManInfSup_AddEdit.fnBuscarPersona = function (_dom, _tipoPersona) {
    var url = urlLocalSigo + "General/Controles/_BuscarPersonaGeneral";
    var option = { url: url, type: 'GET', datos: { asBusGrupo: "PERSONA", asCodPTipo: "TODOS", asTipoPersona: _tipoPersona }, divId: "mdlBuscarPersona" };
    utilSigo.fnOpenModal(option, function () {
        _bPerGen.fnAsignarDatos = function (obj) {
            if (obj != null && obj != "") {
                var data = _bPerGen.dtBuscarPerona.row($(obj).parents('tr')).data();
                switch (_dom) {
                    case "PROFESIONAL":
                        ManInfSup_AddEdit.frm.find("#hdfCodProfesional").val(data["COD_PERSONA"]);
                        ManInfSup_AddEdit.frm.find("#txtProfesional").val(data["PERSONA"]);
                        break;

                }
                utilSigo.fnCloseModal("mdlBuscarPersona");
            }
        };
        _bPerGen.fnInit();
    });
};

ManInfSup_AddEdit.fnViewModalUbigeo = function () {
    var url = initSigo.urlControllerGeneral + "_Ubigeo";
    var option = { url: url, type: 'POST', datos: {}, divId: "mdlControles_Ubigeo" };
    utilSigo.fnOpenModal(option, function () {
        _Ubigeo.fnSelectUbigeo = function (_ubigeoText, _ubigeoId) {
            ManInfSup_AddEdit.frm.find("#hdfCodUbigeo").val(_ubigeoId);
            ManInfSup_AddEdit.frm.find("#txtUbigeo").val(_ubigeoText);
            $("#mdlControles_Ubigeo").modal('hide');
        }
        _Ubigeo.fnLoadModalView(ManInfSup_AddEdit.frm.find("#hdfCodUbigeo").val());
    }, function () {
        if (!utilSigo.fnValidateForm_HideControl(ManInfSup_AddEdit.frm, ManInfSup_AddEdit.frm.find("#hdfCodUbigeo"), ManInfSup_AddEdit.frm.find("#iconUbigeo"), false)) return false;
        return true;
    }
    );
}

ManInfSup_AddEdit.regresar = function (appServer) {
    var url = "";
    url = urlLocalSigo + "Supervision/ManInfSuspension/Index";
    window.location = url;

};

ManInfSup_AddEdit.fnSaveForm = function () {
    let hdfCodInforme = ManInfSup_AddEdit.frm.find("#hdfCodInforme").val();
    let hdfRegEstado = ManInfSup_AddEdit.frm.find("#hdfRegEstado").val();
    let hdfCodNotificacion = ManInfSup_AddEdit.frm.find("#hdfCodNotificacion").val();
    let chkPublicar = ManInfSup_AddEdit.frm.find("#chkPublicar").is(':checked');
    let txtTHabilitante = ManInfSup_AddEdit.frm.find("#txtTHabilitante").val();
    let txtCNotificacion = ManInfSup_AddEdit.frm.find("#txtCNotificacion").val();
    let txtIDOD = ManInfSup_AddEdit.frm.find("#ddODs").val();
    let txtNumInforme = ManInfSup_AddEdit.frm.find("#txtNumInforme").val();
    let txtIdMotivo = ManInfSup_AddEdit.frm.find("#ddMotivo").val();
    let txtFechaEmision = ManInfSup_AddEdit.frm.find("#txtFechaEmision").val();
    let txtFechaActa = ManInfSup_AddEdit.frm.find("#txtFechaActa").val();
    let txtObservacion = ManInfSup_AddEdit.frm.find("#txtObservacion").val();
    let hdfCodThabilitante = ManInfSup_AddEdit.frm.find("#hdfCodThabilitante").val();
    let model = {
        hdfCodInforme,
        hdfRegEstado,
        hdfRegEstado,
        hdfCodNotificacion,
        chkPublicar,
        txtTHabilitante,
        txtCNotificacion,
        txtIDOD,
        txtNumInforme,
        txtIdMotivo,
        txtFechaEmision,
        txtFechaActa,
        txtObservacion,
        hdfCodThabilitante
    }

    ///control de calidad
    model.vmControlCalidad = _ControlCalidad.fnGetDatosControlCalidad();

    /// Listas
    model.tbSupervisor = _renderSupervisor.fnGetList();
    model.tbEliTABLA = _renderSupervisor.tbEliTABLA;

    utilSigo.dialogConfirm("", "Está seguro registrar los datos?", function (r) {
        if (r) {
            let url = urlLocalSigo + "Supervision/ManInfSuspension/SaveOrUpdate";
            let option = { url: url, datos: JSON.stringify(model), type: 'POST' };
            utilSigo.fnAjax(option, function (data) {
                if (data.success) {
                    window.location = `${urlLocalSigo}/Supervision/ManInfSuspension/Index`;
                        utilSigo.toastSuccess("Éxito", "Datos actualizados correctamente");
                }
                else {
                    utilSigo.toastWarning("Aviso", data.msj);
                }
            });
        }
    });
};

$(document).ready(function () {
    ManInfSup_AddEdit.frm = $("#frmManInformeSusp_AddEdit");
    ManInfSup_AddEdit.iniciarEventos();

});