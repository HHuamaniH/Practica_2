"use strict";
var ManNotificacion = {};

ManNotificacion.fnShowListOptions = function () {
    utilSigo.modalDraggable($("#mdN_ListOpciones"), '.modal-header');
    $("#mdN_ListOpciones").modal({ keyboard: true, backdrop: 'static' });

    ManNotificacion.fnNuevaCN = function () {

        if ($("#ddlManNotificacionOpcionesId").val().length == 0) {
            utilSigo.toastWarning("Aviso", "Seleccione una Modalidad antes de continuar"); return false;
        }
        if ($("#ddlManNotificacionOpcionesId").val() == "0000002" || $("#ddlManNotificacionOpcionesId").val() == "0000003" || $("#ddlManNotificacionOpcionesId").val() == "0000029") {
            utilSigo.toastWarning("Aviso", "No puede Generar este tipo de documento"); return false;
        }
        _ManGrillaPaging.fnNuevo($("#ddlManNotificacionOpcionesId").val(), $("#ddlManNotificacionOpcionesId option:selected").text());
    }
}

ManNotificacion.fnLoadManGrillaPaging = function () {
    var url = initSigo.urlControllerGeneral + "_ManGrillaPaging";
    console.log(url);
    var data = ManNotificacion.frm.serializeObject();
    console.log("aca es");
    console.log(data);
    var option = { url: url, datos: JSON.stringify(data), type: 'POST', dataType: 'html' };
    console.log("aquiiiii");

    var columns_label = [], columns_data = [], options = {};
    columns_label = ["Resolución TFFS", "Fecha de registro", "Número", "Tipo Notificación", "Nro. Expediente", "Resolución Directoral", "Nro Informe", "Destino Notif.", "Fecha Notificación"];
    columns_data = ["RESOLUCION_TFFS", "FECHA", "NUMERO", "TIPO_FISCALIZA", "NUMERO_EXPEDIENTE", "NUMERO_RESOLUCION", "NUMERO_INFORME", "DESTINATARIO", "FECHA_NOTIFICACION"];    //FECHA_CREACION
    options = {
        page_paging: true, page_length: 20, row_index: true, row_edit: true, row_fnEdit: "_ManGrillaPaging.fnCreate(this)"
    };

    utilSigo.fnAjax(option, function (data) {
        ManNotificacion.frm.find("#dvManNotificacionContenedor").html(data);
        _ManGrillaPaging.fnInit(columns_label, columns_data, options);
        console.log("LISTA DE GRILLA 1");

        _ManGrillaPaging.fnExport = function () {
            //var url = urlLocalSigo + "Fiscalizacion/FiscalizacionNotificacion/ExportarRegistroUsuario";
            var url = urlLocalSigo + "Tribunal/TribunalNotificacion2da/ExportarRegistroUsuario";
            var option = { url: url, datos: JSON.stringify({}), type: 'POST' };
            console.log("punto de entrada");

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

        _ManGrillaPaging.fnCreate = function (obj) {
            var cod_notificacion = "";
            //var url_crud = urlLocalSigo + "Fiscalizacion/FiscalizacionNotificacion/AddEdit";
            var url_crud = urlLocalSigo + "Tribunal/TribunalNotificacion2da/AddEdit";
            console.log("mensaje de prueba" + url_crud);

            if (obj != "") {//Modificar registro
                var data = _ManGrillaPaging.dtManGrillaPaging.row($(obj).parents('tr')).data();
                cod_notificacion = data["CODIGO"];

                _ManGrillaPaging.fnReadConfigManGrillaPaging();

                window.location = url_crud + "?asCodNotificacion=" + cod_notificacion + "&asCodTipoN=" + "" + "&asTextTipoN=" + "";
            } else {//Nuevo registro
                utilSigo.toastInfo("Aviso", "La operación no está permitida");
                //ManNotificacion.fnShowListOptions();
            }
        }

        //_ManGrillaPaging.fnNuevo = function (CodTipoN,TextTipoN) {
        //    var cod_notificacion = "";
        //    //var url_crud = urlLocalSigo + "Fiscalizacion/FiscalizacionNotificacion/AddEdit";
        //    var url_crud = urlLocalSigo + "Tribunal/TribunalNotificacion2da/AddEdit";
        //    _ManGrillaPaging.fnReadConfigManGrillaPaging();
        //    window.location = url_crud + "?asCodNotificacion=" + cod_notificacion + "&asCodTipoN=" + CodTipoN + "&asTextTipoN=" + TextTipoN;
        //}
    });
}

$(document).ready(function () {
    ManNotificacion.frm = $("#frmManNotificacion");

    var alertaInicial = ManNotificacion.frm.find("#alertaFormulario").val();
    if (alertaInicial != "") {
        utilSigo.toastSuccess("Aviso", alertaInicial);
    }

    $.fn.select2.defaults.set("theme", "bootstrap4");
    $("#ddlManNotificacionOpcionesId").select2();

    ManNotificacion.fnLoadManGrillaPaging();
});