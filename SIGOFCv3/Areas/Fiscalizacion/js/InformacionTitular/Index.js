"use strict";
var ManInfTitular = {};

ManInfTitular.fnShowListOptions = function () {
    utilSigo.modalDraggable($("#mdN_ListOpciones"), '.modal-header');
    $("#mdN_ListOpciones").modal({ keyboard: true, backdrop: 'static' });

    ManInfTitular.fnNuevaCN = function () {

        if ($("#ddlManInfTitularOpcionesId").val().length == 0) {
            utilSigo.toastWarning("Aviso", "Seleccione una Modalidad antes de continuar"); return false;
        }
        if ($("#ddlManInfTitularOpcionesId").val() == "0000002" || $("#ddlManInfTitularOpcionesId").val() == "0000003" || $("#ddlManInfTitularOpcionesId").val() == "0000029") {
            utilSigo.toastWarning("Aviso", "No puede Generar este tipo de documento"); return false;
        }
        _ManGrillaPaging.fnNuevo($("#ddlManInfTitularOpcionesId").val(), $("#ddlManInfTitularOpcionesId option:selected").text());
    }
}

ManInfTitular.fnLoadManGrillaPaging = function () {
    var url = initSigo.urlControllerGeneral + "_ManGrillaPaging";
    var data = ManInfTitular.frm.serializeObject();
    var option = { url: url, datos: JSON.stringify(data), type: 'POST', dataType: 'html' };

    var columns_label = [], columns_data = [], options = {};
    columns_label = ["Fecha de registro", "Nro Documento", "Tipo Documento", "Nro Resolución Directoral", "Nro Expediente", "Nro Informe", "Remitente", "Titular"];
    columns_data = ["FECHA", "NUMERO", "TIPO_FISCALIZA", "NUMERO_RESOLUCION", "NUMERO_EXPEDIENTE", "NUMERO_INFORME", "REMITENTE", "TITULAR"];
    options = {
        page_paging: true, page_length: 20, row_index: true, row_edit: true, row_fnEdit: "_ManGrillaPaging.fnCreate(this)"
    };

    utilSigo.fnAjax(option, function (data) {
        ManInfTitular.frm.find("#dvManInfTitularContenedor").html(data);
        _ManGrillaPaging.fnInit(columns_label, columns_data, options);

        _ManGrillaPaging.fnExport = function () {
            var url = urlLocalSigo + "Fiscalizacion/InformacionTitular/ExportarRegistroUsuario";
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
            var cod_inftitular = "";
            var url_crud = urlLocalSigo + "Fiscalizacion/InformacionTitular/AddEdit";

            if (obj != "") {//Modificar registro
                var data = _ManGrillaPaging.dtManGrillaPaging.row($(obj).parents('tr')).data();
                cod_inftitular = data["CODIGO"];

                _ManGrillaPaging.fnReadConfigManGrillaPaging();

                window.location = url_crud + "?asCodInfTitular=" + cod_inftitular + "&asCodTipoIT=" + "" + "&asTextTipoIT=" + "";
            } else {//Nuevo registro
                ManInfTitular.fnShowListOptions();
            }
        }

        _ManGrillaPaging.fnNuevo = function (CodTipoIT, TextTipoIT) {
            var cod_inftitular = "";
            var url_crud = urlLocalSigo + "Fiscalizacion/InformacionTitular/AddEdit";
            _ManGrillaPaging.fnReadConfigManGrillaPaging();
            window.location = url_crud + "?asCodInfTitular=" + cod_inftitular + "&asCodTipoIT=" + CodTipoIT + "&asTextTipoIT=" + TextTipoIT;
        }
    });
}

$(document).ready(function () {
    ManInfTitular.frm = $("#frmManInfTitular");

    var alertaInicial = ManInfTitular.frm.find("#alertaFormulario").val();
    if (alertaInicial != "") {
        utilSigo.toastSuccess("Aviso", alertaInicial);
    }

    $.fn.select2.defaults.set("theme", "bootstrap4");
    $("#ddlManInfTitularOpcionesId").select2();

    ManInfTitular.fnLoadManGrillaPaging();
});