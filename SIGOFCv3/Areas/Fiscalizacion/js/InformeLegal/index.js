"use strict";

var ManInfLegal = {};


ManInfLegal.fnShowListOptions = function () {
    utilSigo.modalDraggable($("#mdIL_ListOpciones"), '.modal-header');
    $("#mdIL_ListOpciones").modal({ keyboard: true, backdrop: 'static' });

    ManInfLegal.fnNuevaCN = function () {

        if ($("#ddlManInfLegalOpcionesId").val().length == 0) {
            utilSigo.toastWarning("Aviso", "Seleccione el tipo de informe legal"); return false;
        }
        if ($("#ddlManInfLegalOpcionesId").val() == "0000002" || $("#ddlManInfLegalOpcionesId").val() == "0000003") {
            utilSigo.toastWarning("Aviso", "No puede crear registros para tipos de informe legal historicos"); return false;
        }
        _ManGrillaPaging.fnNuevo($("#ddlManInfLegalOpcionesId").val());
    }
}


ManInfLegal.fnLoadManGrillaPaging = function () {
    //para cargar los datos en la vista
    var url = initSigo.urlControllerGeneral + "_ManGrillaPaging_v3";    
    var data = ManInfLegal.frm.serializeObject();
    var option = { url: url, datos: JSON.stringify(data), type: 'POST', dataType: 'html' };
    // para cargar las columnas y la data 
    var columns_label = [], columns_data = [], options = {}, data_extend = [];
    columns_label = ["Fecha Registro", "Número Informe Legal", "Tipo Informe", "Numero Informe", "Numero de Resolucion", "Numero de Expediente"];
    columns_data = ["FECHA", "ILEGAL_NUMERO", "TIPO_FISCALIZA", "NUMERO_INFORME", "NUMERO_RESOLUCION", "NUMERO_EXPEDIENTE"];

    options = {
        page_paging: true, page_length: 20, row_index: true, row_edit: true, row_fnEdit: "_ManGrillaPaging.fnCreate(this)"
        , data_extend: data_extend
    };
    //para descargar los registros del SIGO
    utilSigo.fnAjax(option, function (data) {
        ManInfLegal.frm.find("#dvManInfLegalContenedor").html(data);
        _ManGrillaPaging.fnInit(columns_label, columns_data, options);

        _ManGrillaPaging.fnExport = function () {
            var url = urlLocalSigo + "Fiscalizacion/InformeLegal/ExportarRegistroUsuario";
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

        _ManGrillaPaging.fnCreate = function (obj, cod_infLegal) {
            if (obj != "") {//Modificar registro
                var cod_infLegal = "";
                var url_crud = urlLocalSigo + "Fiscalizacion/InformeLegal/CreateOrEdit";
                var data = _ManGrillaPaging.dtManGrillaPaging.row($(obj).parents('tr')).data();
                cod_infLegal = data["COD_ILEGAL"];

                _ManGrillaPaging.fnReadConfigManGrillaPaging();

                window.location = url_crud + "?asCodInfLegal=" + cod_infLegal + "&asCodTipoIL=" + "";;
            } else {//Nuevo registro
                ManInfLegal.fnShowListOptions();
                //utilSigo.toastWarning("Aviso", "Opción no disponible, por favor registre la notificación desde el sistema que corresponda");
            }
        }
        _ManGrillaPaging.fnNuevo = function (CodTipoI) {
            var cod_infLegal = "";
            var url_crud = urlLocalSigo + "Fiscalizacion/InformeLegal/CreateOrEdit";
            _ManGrillaPaging.fnReadConfigManGrillaPaging();
            window.location = url_crud + "?asCodInfLegal=" + cod_infLegal + "&asCodTipoIL=" + CodTipoI;
    }

    });
}

$(document).ready(function () {
    ManInfLegal.frm = $("#frmManInfLegal");

    var alertaInicial = ManInfLegal.frm.find("#alertaFormulario").val();
    if (alertaInicial != "") {
        utilSigo.toastSuccess("Aviso", alertaInicial);
    }

    $.fn.select2.defaults.set("theme", "bootstrap4");
    $("#ddlManInfLegalOpcionesId").select2();

    ManInfLegal.fnLoadManGrillaPaging();
});