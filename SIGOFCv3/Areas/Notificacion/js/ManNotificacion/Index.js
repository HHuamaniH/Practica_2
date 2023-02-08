"use strict";

var ManNotificacion = {};

ManNotificacion.fnShowListOptions = function () {
    utilSigo.modalDraggable($("#mdlManNot_ListOpciones"), '.modal-header');
    $("#mdlManNot_ListOpciones").modal({ keyboard: true, backdrop: 'static' });

    ManNotificacion.fnNuevaCN = function () {
        if ($("#ddlManNotListOpcionesId").val().length == 0) {
            utilSigo.toastWarning("Aviso", "Seleccione el tipo de notificación"); return false;
        }
        _ManGrillaPaging.fnCreate("", $("#ddlManNotListOpcionesId").val()[0]);
    }
}

ManNotificacion.fnLoadManGrillaPaging = function () {
    var url = initSigo.urlControllerGeneral + "_ManGrillaPaging";
    var data = ManNotificacion.frm.serializeObject();
    var option = { url: url, datos: JSON.stringify(data), type: 'POST', dataType: 'html' };

    var columns_label = [], columns_data = [], options = {}, data_extend = [];
    columns_label = ["Fecha Registro", "Número", "Tipo Notificación", "Título Habilitante", "Titular", "Plan de Manejo"
        , "Informe", "Expediente", "Resolución Directoral", "Informe Legal", "Destino"];
    columns_data = ["FECHA", "NUM_FISNOTI", "TIPO", "NUM_THABILITANTE", "TITULAR", "PMANEJO"
        , "NUM_INFORME", "NUM_EXPEDIENTE", "NUM_RESOLUCION", "NUM_ILEGAL", "DESTINO"];
    data_extend = [
        {
            "data": "M", "title": "M", "orderable": false, "searchable": false, "mRender": function (data, type, row, meta) {
                if (data == 'True' && row["COD_FCTIPO"] == "0000172") {
                    return '<i class="fa fa-lg fa-newspaper-o" style="cursor: pointer;color:dodgerblue;" title="Ir al detalle" onclick="_ManGrillaPaging.fnMuestra(this,\'M\')"></i>';
                } else { return ''; }
            }
        },
        {
            "data": "NM", "title": "NM", "orderable": false, "searchable": false, "mRender": function (data, type, row, meta) {
                if (data == 'True' && row["COD_FCTIPO"] == "0000172") {
                    return '<i class="fa fa-lg fa-newspaper-o" style="cursor: pointer;color:dodgerblue;" title="Ir al detalle" onclick="_ManGrillaPaging.fnMuestra(this,\'NM\')"></i>';
                } else { return ''; }
            }
        },
        {
            "data": "DTR", "title": "DTR", "orderable": false, "searchable": false, "mRender": function (data, type, row, meta) {
                if (data == 'True' && row["COD_FCTIPO"] == "0000172") {
                    return '<i class="fa fa-lg fa-newspaper-o" style="cursor: pointer;color:dodgerblue;" title="Ir al detalle" onclick="_ManGrillaPaging.fnMuestra(this,\'DTR\')"></i>';
                } else { return ''; }
            }
        },
        {
            "data": "DTO", "title": "DTO", "orderable": false, "searchable": false, "mRender": function (data, type, row, meta) {
                if (data == 'True' && row["COD_FCTIPO"] == "0000172") {
                    return '<i class="fa fa-lg fa-newspaper-o" style="cursor: pointer;color:dodgerblue;" title="Ir al detalle" onclick="_ManGrillaPaging.fnMuestra(this,\'DTO\')"></i>';
                } else { return ''; }
            }
        },
        {
            "data": "DAR", "title": "DAR", "orderable": false, "searchable": false, "mRender": function (data, type, row, meta) {
                if (data == 'True' && row["COD_FCTIPO"] == "0000172") {
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
        ManNotificacion.frm.find("#dvManNotificacionContenedor").html(data);
        _ManGrillaPaging.fnInit(columns_label, columns_data, options);

        _ManGrillaPaging.fnExport = function () {
            var url = urlLocalSigo + "Notificacion/ManNotificacion/ExportarRegistroUsuario";
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

        _ManGrillaPaging.fnCreate = function (obj, codTipoNotif) {
            if (obj != "") {//Modificar registro
                var cod_notificacion = "";
                var url_crud = urlLocalSigo + "Notificacion/ManNotificacion/AddEdit";
                var data = _ManGrillaPaging.dtManGrillaPaging.row($(obj).parents('tr')).data();
                cod_notificacion = data["COD_FISNOTI"];

                _ManGrillaPaging.fnReadConfigManGrillaPaging();

                window.location = url_crud + "?asCodNotificacion=" + cod_notificacion;
            } else {//Nuevo registro
                //ManNotificacion.fnShowListOptions();
                utilSigo.toastWarning("Aviso", "Opción no disponible, por favor registre la notificación desde el sistema que corresponda");
            }
        }

        _ManGrillaPaging.fnMuestra = function (obj, tipoMuestra) {
            if (obj != "") {
                var cod_notificacion = "", cod_thabilitante = "";
                var url = urlLocalSigo + "Notificacion/ManNotificacion/Muestra";
                var data = _ManGrillaPaging.dtManGrillaPaging.row($(obj).parents('tr')).data();
                cod_notificacion = data["COD_FISNOTI"];
                cod_thabilitante = data["COD_THABILITANTE"];

                _ManGrillaPaging.fnReadConfigManGrillaPaging();

                window.location = url + "?asCodNotificacion=" + cod_notificacion + "&asTipoMuestra=" + tipoMuestra + "&asCodTHabilitante=" + cod_thabilitante;
            }
        }
    });
}

$(document).ready(function () {
    ManNotificacion.frm = $("#frmManNotificacion");

    var alertaInicial = ManNotificacion.frm.find("#alertaFormulario").val();
    if (alertaInicial != "") {
        utilSigo.toastSuccess("Aviso", alertaInicial);
    }

    $.fn.select2.defaults.set("theme", "bootstrap4");
    $("#ddlManNotListOpcionesId").select2();

    ManNotificacion.fnLoadManGrillaPaging();
});