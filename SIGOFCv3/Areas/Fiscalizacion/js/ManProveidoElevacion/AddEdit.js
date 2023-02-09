"use strict";
var ManProvElev_AddEdit = {};

ManProvElev_AddEdit.iniciarEventos = function () {
    ManProvElev_AddEdit.frm.find("#txtFechaDerivacion").datepicker({ format: "dd/mm/yyyy", autoclose: true, language: 'es' });
    ManProvElev_AddEdit.tbEliTABLA = {};
}

ManProvElev_AddEdit.fnBuscarPersona = function (_dom, _tipoPersona) {
    var url = urlLocalSigo + "General/Controles/_BuscarPersonaGeneral";
    var option = { url: url, type: 'GET', datos: { asBusGrupo: "PERSONA", asCodPTipo: "TODOS", asTipoPersona: _tipoPersona }, divId: "mdlBuscarPersona" };
    utilSigo.fnOpenModal(option, function () {
        _bPerGen.fnAsignarDatos = function (obj) {
            if (obj != null && obj != "") {
                var data = _bPerGen.dtBuscarPerona.row($(obj).parents('tr')).data();
                switch (_dom) {
                    case "PROFESIONAL":
                        ManProvElev_AddEdit.frm.find("#hsfProfesionalCodigo").val(data["COD_PERSONA"]);
                        ManProvElev_AddEdit.frm.find("#txtProfesional").val(data["PERSONA"]);
                        break;
                    case "FUNCIONARIO":
                        ManProvElev_AddEdit.frm.find("#hdfFuncionarioCodigo").val(data["COD_PERSONA"]);
                        ManProvElev_AddEdit.frm.find("#txtFuncionario").val(data["PERSONA"]);
                        break;
                }
                utilSigo.fnCloseModal("mdlBuscarPersona");
            }
        };
        _bPerGen.fnInit();
    });
};

ManProvElev_AddEdit.fnViewModalUbigeo = function () {
    var url = initSigo.urlControllerGeneral + "_Ubigeo";
    var option = { url: url, type: 'POST', datos: {}, divId: "mdlControles_Ubigeo" };
    utilSigo.fnOpenModal(option, function () {
        _Ubigeo.fnSelectUbigeo = function (_ubigeoText, _ubigeoId) {
            ManProvElev_AddEdit.frm.find("#hdfCodUbigeo").val(_ubigeoId);
            ManProvElev_AddEdit.frm.find("#txtUbigeo").val(_ubigeoText);
            $("#mdlControles_Ubigeo").modal('hide');
        }
        _Ubigeo.fnLoadModalView(ManProvElev_AddEdit.frm.find("#hdfCodUbigeo").val());
    }, function () {
        if (!utilSigo.fnValidateForm_HideControl(ManProvElev_AddEdit.frm, ManProvElev_AddEdit.frm.find("#hdfCodUbigeo"), ManProvElev_AddEdit.frm.find("#iconUbigeo"), false)) return false;
        return true;
    }
    );
}

ManProvElev_AddEdit.regresar = function (appServer) {
    var url = "";
    url = urlLocalSigo + "Fiscalizacion/ManProveidoElevacion/Index";
    window.location = url;

};

ManProvElev_AddEdit.fnSaveForm = function () {
    //alert('ingreso aqui' + ManProvElev_AddEdit.frm.find("#ddlDirecionLinea").val());
    let hdcodigo = ManProvElev_AddEdit.frm.find("#hdcodigo").val();
    let RegEstado = ManProvElev_AddEdit.frm.find("#RegEstado").val();
    let lblItemTitulo = ManProvElev_AddEdit.frm.find("#lblItemTitulo").val();
    let txtIdOficina = ManProvElev_AddEdit.frm.find("#ddlDirecionLinea").val();
    let hdfFuncionarioCodigo = ManProvElev_AddEdit.frm.find("#hdfFuncionarioCodigo").val();
    let txtFuncionario = ManProvElev_AddEdit.frm.find("#txtFuncionario").val();
    let hsfProfesionalCodigo = ManProvElev_AddEdit.frm.find("#hsfProfesionalCodigo").val();
    let txtProfesional = ManProvElev_AddEdit.frm.find("#txtProfesional").val();
    let txtFechaDerivacion = ManProvElev_AddEdit.frm.find("#txtFechaDerivacion").val();
    let txtObservacion = ManProvElev_AddEdit.frm.find("#txtObservacion").val();
    let txtIdOD = ManProvElev_AddEdit.frm.find("#ddlOds").val();
    let txtIdDerivadoPara = ManProvElev_AddEdit.frm.find("#ddlDerivadopara").val();
    let txtDerivadopara = ManProvElev_AddEdit.frm.find("#ddlDerivadopara").val();

    let modelProv = {
        hdcodigo,
        RegEstado,
        lblItemTitulo,
        txtIdOficina,
        hdfFuncionarioCodigo,
        txtFuncionario,
        hsfProfesionalCodigo,
        txtProfesional,
        txtFechaDerivacion,
        txtObservacion,
        txtIdOD,
        txtIdDerivadoPara,
        txtDerivadopara
    }

    ///control de calidad
    modelProv.vmControlCalidad = _ControlCalidad.fnGetDatosControlCalidad();
    // Listas
    modelProv.ListInformes = _renderListExpediente.fnGetList();
    modelProv.listEliTabla = _renderListExpediente.tbEliTABLA;

    utilSigo.dialogConfirm("", "Está seguro registrar los datos?", function (r) {
        if (r) {
            let url = urlLocalSigo + "Fiscalizacion/ManProveidoElevacion/AddEditRD";
            let option = { url: url, datos: JSON.stringify(modelProv), type: 'POST' };
            utilSigo.fnAjax(option, function (data) {
                if (data.success) {
                    window.location = `${urlLocalSigo}/Fiscalizacion/ManProveidoElevacion/Index`;
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
    ManProvElev_AddEdit.frm = $("#frmAddOrEditProvElevacion");
    ManProvElev_AddEdit.iniciarEventos();

});