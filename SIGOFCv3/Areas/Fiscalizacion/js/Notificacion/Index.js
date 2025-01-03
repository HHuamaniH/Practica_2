﻿"use strict";
var ManNotificacion = {};

ManNotificacion.fnLoadManGrillaPaging = function () {
    var url = initSigo.urlControllerGeneral + "_ManGrillaPaging";
    var data = ManNotificacion.frm.serializeObject();
    var option = { url: url, datos: JSON.stringify(data), type: 'POST', dataType: 'html' };

    var columns_label = [], columns_data = [], options = {};
    columns_label = ["Fecha Registro", "Número", "Tipo Documento", "Nro. Expediente", "Nro. Informe"];
    columns_data = ["FECHA_CREACION", "NUMERO", "TIPO_FISCALIZA", "NUMERO_EXPEDIENTE", "NUMERO_INFORME"];
    options = {
        page_paging: true, page_length: 20, row_index: true, row_edit: true, row_fnEdit: "_ManGrillaPaging.fnCreate(this)"
    };

    utilSigo.fnAjax(option, function (data) {
        ManNotificacion.frm.find("#dvManNotificacionContenedor").html(data);
        _ManGrillaPaging.fnInit(columns_label, columns_data, options);

        _ManGrillaPaging.fnExport = function () {
            var url = urlLocalSigo + "Fiscalizacion/InformeFundamentado/ExportarRegistroUsuario";
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

        _ManGrillaPaging.fnCreate = function (obj) {
            var cod_infFundamentado = "";
            var url_crud = urlLocalSigo + "Fiscalizacion/InformeFundamentado/AddEdit";

            if (obj != "") {//Modificar registro
                var data = _ManGrillaPaging.dtManGrillaPaging.row($(obj).parents('tr')).data();
                cod_infFundamentado = data["CODIGO"];
            }

            _ManGrillaPaging.fnReadConfigManGrillaPaging();

            window.location = url_crud + "?asCodInfFundamentado=" + cod_infFundamentado;
        }
    });
}

$(document).ready(function () {
    ManNotificacion.frm = $("#frmManNotificacion");

    var alertaInicial = ManNotificacion.frm.find("#alertaFormulario").val();
    if (alertaInicial != "") {
        utilSigo.toastSuccess("Aviso", alertaInicial);
    }

    ManNotificacion.fnLoadManGrillaPaging();
});