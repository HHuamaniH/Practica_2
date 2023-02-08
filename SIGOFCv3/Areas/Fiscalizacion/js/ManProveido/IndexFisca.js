
"use strict";

var ManProveido = {};


ManProveido.fnShowListOptions = function () {
    utilSigo.modalDraggable($("#mdProveidos"), '.modal-header');
    $("#mdProveidos").modal({ keyboard: true, backdrop: 'static' });

    ManProveido.fnNuevaCN = function () {

        if ($("#ddlManProveidoOpcionesId").val().length == 0) {
            utilSigo.toastWarning("Aviso", "Seleccione el tipo de proveído"); return false;
        }
        _ManGrillaPaging.fnNuevo($("#ddlManProveidoOpcionesId").val());
    }
}


ManProveido.fnLoadManGrillaPaging = function () {
    //para cargar los datos en la vista
    var url = initSigo.urlControllerGeneral + "_ManGrillaPaging_v3";
    var data = ManProveido.frm.serializeObject();
    var option = { url: url, datos: JSON.stringify(data), type: 'POST', dataType: 'html' };
    // para cargar las columnas y la data 
    var columns_label = [], columns_data = [], options = {}, data_extend = [];
    columns_label = ["Fecha Registro", "Código SIGO", "Nro Informe", "Nro. Expediente Administrativo", "Nro THabilitante", "Titular", "Tipo Documento"];
    columns_data = ["FECHA", "CODIGO", "NUMERO_INFORME", "NUMERO_EXPEDIENTE", "NUM_THABILITANTE", "TITULAR", "TIPO_FISCALIZA"];

    options = {
        page_paging: true, page_length: 20, row_index: true, row_edit: true, row_fnEdit: "_ManGrillaPaging.fnCreate(this)"
        , data_extend: data_extend
    };
    //para descargar los registros del SIGO
    utilSigo.fnAjax(option, function (data) {
        ManProveido.frm.find("#dvManProvedioContenedor").html(data);
        _ManGrillaPaging.fnInit(columns_label, columns_data, options);

        _ManGrillaPaging.fnExport = function () {
            var url = urlLocalSigo + "Fiscalizacion/ManProveido/ExportarRegistroUsuario";
            var option = { url: url, datos: JSON.stringify({}), type: 'POST' };

            utilSigo.fnAjax(option, function (data) {
                if (data.success) {
                    console.log(data);
                    document.location = urlLocalSigo + "General/Controles/DownloadListadoManGrilla?file=" + data.values[0];
                }
                else {
                    utilSigo.toastWarning("Aviso", "Sucedio un error, Comuníquese con el Administrador");
                    console.log(data.msj);
                }
            });
        }

        _ManGrillaPaging.fnCreate = function (obj, cod_infLegal) {
            if (obj != "") {//Modificar registro
                var asCodRD = "";
                var url_crud = urlLocalSigo + "Fiscalizacion/ManProveido/CreateOrEdit";
                var data = _ManGrillaPaging.dtManGrillaPaging.row($(obj).parents('tr')).data();
                asCodRD = data["CODIGO"];

                _ManGrillaPaging.fnReadConfigManGrillaPaging();

                window.location = url_crud + "?asCodRD=" + asCodRD;
            } else {//Nuevo registro
                ManProveido.fnShowListOptions();
                //utilSigo.toastWarning("Aviso", "Opción no disponible, por favor registre la notificación desde el sistema que corresponda");
            }
        }

        _ManGrillaPaging.fnNuevo = function (CodTipoI) {
            var cod_infLegal = "";
            var url_crud = urlLocalSigo + "Fiscalizacion/ManProveido/CreateOrEdit";
            _ManGrillaPaging.fnReadConfigManGrillaPaging();
            window.location = url_crud + "?asCodTipoIL=" + CodTipoI;
        }

    });
}

$(document).ready(function () {
    ManProveido.frm = $("#frmManProveido");

    var alertaInicial = ManProveido.frm.find("#alertaFormulario").val();
    if (alertaInicial != "") {
        utilSigo.toastSuccess("Aviso", alertaInicial);
    }
    $.fn.select2.defaults.set("theme", "bootstrap4");
    $("#ddlManProveidoOpcionesId").select2();

    ManProveido.fnLoadManGrillaPaging();
});