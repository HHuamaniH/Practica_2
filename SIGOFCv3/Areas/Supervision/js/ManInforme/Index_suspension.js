"use strict";
var ManInforme = {};

ManInforme.fnViewModalCNotificacion = function () {
    var url = "", sFormulario = "MODAL_CNOTIFICACION", sCriterio = "CN_NUMCN_ISUPERVISION", sValor = "", sControlInstancia = "ManInforme.fnViewModalCNotificacion";
    url = initSigo.urlControllerGeneral + "_CNotificacion";
    var option = {
        url: url, type: 'POST', datos: { asFormulario: sFormulario, asCriterio: sCriterio, asValor: sValor, asControlInstancia: sControlInstancia }
        , divId: "mdlManInforme_CNotificacion"
    };
    utilSigo.fnOpenModal(option, function () {
        _CNotificacion.fnAsignarDatos = function (obj) {
            if (obj != null && obj != "") {
                var data = _CNotificacion.dtCNotificacion.row($(obj).parents('tr')).data();
                _ManGrillaPaging.fnCreate("", data["COD_CNOTIFICACION"], data["COD_MTIPO"]);
                $("#mdlManInforme_CNotificacion").modal('hide');
            }
        }

        _CNotificacion.fnInit();
    });
}

ManInforme.fnLoadManGrillaPaging = function () {
    var url = initSigo.urlControllerGeneral + "_ManGrillaPaging";
    var data = ManInforme.frm.serializeObject();
    var option = { url: url, datos: JSON.stringify(data), type: 'POST', dataType: 'html' };

    var columns_label = [], columns_data = [], options = {};
    columns_label = ["Fecha Registro", "Informe", "Carta Notificación", "Modalidad", "Título Habilitante", "Supervisión Posterior"];
    columns_data = ["FECHA", "NUMERO", "CNOTIFICACION", "MODALIDAD_TIPO", "THABILITANTE", "SUPERVISION"];
    options = {
        page_paging: true, page_length: 20, row_index: true, row_edit: true, row_fnEdit: "_ManGrillaPaging.fnCreate(this)"
    };

    utilSigo.fnAjax(option, function (data) {
        ManInforme.frm.find("#dvManInformeContenedor").html(data);
        _ManGrillaPaging.fnInit(columns_label, columns_data, options);

        _ManGrillaPaging.fnExport = function () {
            var url = urlLocalSigo + "Supervision/ManInfSuspension/ExportarRegistroUsuario";
            var option = { url: url, datos: JSON.stringify({}), type: 'POST' };

            utilSigo.fnAjax(option, function (data) {
                if (data.success) {
                    document.location = urlLocalSigo + "Archivos/Plantilla/Reg_Usu/" + data.msj;
                }
                else {
                    utilSigo.toastWarning("Aviso", "Sucedio un error, Comuníquese con el Administrador");
                    console.log(data.msj);
                }
            });
        }

        _ManGrillaPaging.fnCreate = function (obj, codCNotificacion,codMTipo) {
            codCNotificacion = (typeof codCNotificacion === 'undefined') ? '' : codCNotificacion;

            if (obj != "" || codCNotificacion != "") {
                var cod_informe = "";
                var url_crud = urlLocalSigo + "Supervision/ManInfSuspension/AddEdit";

                if (obj != "") {
                    var data = _ManGrillaPaging.dtManGrillaPaging.row($(obj).parents('tr')).data();
                    cod_informe = data["COD_INFORME"];
                    codMTipo = data["COD_MTIPO"];
                }

                _ManGrillaPaging.fnReadConfigManGrillaPaging();

                window.location = url_crud + "?asCodMTipo="+codMTipo+"&asCodInforme=" + cod_informe + "&asCodCNotificacion=" + codCNotificacion;
            } else {//Nuevo registro
                ManInforme.fnViewModalCNotificacion();
            }
        }
    });
}

$(document).ready(function () {
    ManInforme.frm = $("#frmManInforme");

    var alertaInicial = ManInforme.frm.find("#alertaFormulario").val();
    if (alertaInicial != "") {
        utilSigo.toastSuccess("Aviso", alertaInicial);
    }

    ManInforme.fnLoadManGrillaPaging();
});