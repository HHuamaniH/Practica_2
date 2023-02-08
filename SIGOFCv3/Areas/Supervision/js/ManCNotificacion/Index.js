"use strict";

var ManCNotificacion = {};

ManCNotificacion.fnShowListOptions = function () {
    utilSigo.modalDraggable($("#mdlManCNot_ListOpciones"), '.modal-header');
    $("#mdlManCNot_ListOpciones").modal({ keyboard: true, backdrop: 'static' });

    ManCNotificacion.fnNuevaCN = function () {
        if ($("#ddlManCNotListOpcionesId").val().length == 0) {
            utilSigo.toastWarning("Aviso", "Seleccione el tipo de carta de notificación"); return false;
        }
        _ManGrillaPaging.fnCreate("", $("#ddlManCNotListOpcionesId").val()[0]);
    }
}

ManCNotificacion.fnLoadManGrillaPaging1 = function () {
    var url = initSigo.urlControllerGeneral + "_ManGrillaPaging";
    var data = ManCNotificacion.frm.serializeObject();
    var option = { url: url, datos: JSON.stringify(data), type: 'POST', dataType: 'html' };

    var columns_label = [], columns_data = [], options = {}, data_extend = [];
    columns_label = ["Fecha Registro", "Carta Notificación", "Título Habilitante", "Titular", "Notificador", "Tipo Supervisión", "Tipo Carta"];
    columns_data = ["FECHA", "NUMERO", "NUM_THABILITANTE", "TITULAR", "PERSONA_NOTIFICADOR", "ESTADO_ORIGEN", "MAE_CNTIPO"];
    data_extend = [
        {
            "data": "M", "title": "M", "orderable": false, "searchable": false, "mRender": function (data, type, row, meta) {
                if (data != "" && data != "0" && (row["MAE_COD_CNTIPO"] == "0000001" || row["MAE_COD_CNTIPO"] == "0000004")) {
                    return '<i class="fa fa-lg fa-newspaper-o" style="cursor: pointer;color:dodgerblue;" title="Ir al detalle" onclick="_ManGrillaPaging.fnMuestra(this,\'M\')"></i>';
                } else { return ''; }
            }
        },
        {
            "data": "NM", "title": "NM", "orderable": false, "searchable": false, "mRender": function (data, type, row, meta) {
                if (data != "" && data != "0" && (row["MAE_COD_CNTIPO"] == "0000001" || row["MAE_COD_CNTIPO"] == "0000004")) {
                    return '<i class="fa fa-lg fa-newspaper-o" style="cursor: pointer;color:dodgerblue;" title="Ir al detalle" onclick="_ManGrillaPaging.fnMuestra(this,\'NM\')"></i>';
                } else { return ''; }
            }
        },
        {
            "data": "DTR", "title": "DTR", "orderable": false, "searchable": false, "mRender": function (data, type, row, meta) {
                if (data != "" && data != "0" && (row["MAE_COD_CNTIPO"] == "0000001" || row["MAE_COD_CNTIPO"] == "0000004")) {
                    return '<i class="fa fa-lg fa-newspaper-o" style="cursor: pointer;color:dodgerblue;" title="Ir al detalle" onclick="_ManGrillaPaging.fnMuestra(this,\'DTR\')"></i>';
                } else { return ''; }
            }
        },
        {
            "data": "DTO", "title": "DTO", "orderable": false, "searchable": false, "mRender": function (data, type, row, meta) {
                if (data != "" && data != "0" && (row["MAE_COD_CNTIPO"] == "0000001" || row["MAE_COD_CNTIPO"] == "0000004")) {
                    return '<i class="fa fa-lg fa-newspaper-o" style="cursor: pointer;color:dodgerblue;" title="Ir al detalle" onclick="_ManGrillaPaging.fnMuestra(this,\'DTO\')"></i>';
                } else { return ''; }
            }
        },
        {
            "data": "DAR", "title": "DAR", "orderable": false, "searchable": false, "mRender": function (data, type, row, meta) {
                if (data != "" && data != "0" && (row["MAE_COD_CNTIPO"] == "0000001" || row["MAE_COD_CNTIPO"] == "0000004")) {
                    return '<i class="fa fa-lg fa-newspaper-o" style="cursor: pointer;color:dodgerblue;" title="Ir al detalle" onclick="_ManGrillaPaging.fnMuestra(this,\'DAR\')"></i>';
                } else { return ''; }
            }
        }
    ];
    options = {
        page_paging: true, page_length: 20, row_index: true, row_edit: true, row_fnEdit: "_ManGrillaPaging.fnCreate(this)"
        , data_extend: data_extend
    };

    utilSigo.fnAjax(option, function (data) {
        ManCNotificacion.frm.find("#dvManCNotificacionContenedor").html(data);
        _ManGrillaPaging.fnInit(columns_label, columns_data, options);

        _ManGrillaPaging.fnExport = function () {
            var url = urlLocalSigo + "Supervision/ManCNotificacion/ExportarRegistroUsuario";
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

        _ManGrillaPaging.fnCreate = function (obj, codTipoCN) {
            codTipoCN = (typeof codTipoCN === 'undefined') ? '' : codTipoCN;

            if (obj != "" || codTipoCN != "") {
                var cod_cnotificacion = "";
                var url_crud = urlLocalSigo + "Supervision/ManCNotificacion/AddEdit";

                if (obj!="") {
                    var data = _ManGrillaPaging.dtManGrillaPaging.row($(obj).parents('tr')).data();
                    cod_cnotificacion = data["COD_CNOTIFICACION"];
                }

                _ManGrillaPaging.fnReadConfigManGrillaPaging();

                window.location = url_crud + "?asCodCNotificacion=" + cod_cnotificacion + "&asCodTipoCN=" + codTipoCN;
            } else {//Nuevo registro
                ManCNotificacion.fnShowListOptions();
            }
        }

        _ManGrillaPaging.fnMuestra = function (obj,tipoMuestra) {
            if (obj != "") {
                var cod_cnotificacion = "", cod_thabilitante = "";
                var url = urlLocalSigo + "Supervision/ManCNotificacion/Muestra";
                var data = _ManGrillaPaging.dtManGrillaPaging.row($(obj).parents('tr')).data();
                cod_cnotificacion = data["COD_CNOTIFICACION"];
                cod_thabilitante = data["COD_THABILITANTE"];

                _ManGrillaPaging.fnReadConfigManGrillaPaging();

                window.location = url + "?asCodCNotificacion=" + cod_cnotificacion + "&asTipoMuestra=" + tipoMuestra + "&asCodTHabilitante=" + cod_thabilitante;
            }
        }
    });
}

$(document).ready(function () {
    ManCNotificacion.frm = $("#frmManCNotificacion");

    var alertaInicial = ManCNotificacion.frm.find("#alertaFormulario").val();
    if (alertaInicial != "") {
        utilSigo.toastSuccess("Aviso", alertaInicial);
    }

    //ManCNotificacion.fnLoadManGrillaPaging();
    ManCNotificacion.fnLoadManGrillaPaging1();
});