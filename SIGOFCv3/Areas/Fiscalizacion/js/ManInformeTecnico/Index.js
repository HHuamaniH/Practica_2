"use strict";

var ManInfTecnico = {};


ManInfTecnico.fnShowListOptions = function () {
    utilSigo.modalDraggable($("#mdlInfTecnico"), '.modal-header');
    $("#mdlInfTecnico").modal({ keyboard: true, backdrop: 'static' });

    ManInfTecnico.fnNuevaCN = function () {

        if ($("#ddlManInfTecOpcionesId").val().length == 0) {
            utilSigo.toastWarning("Aviso", "Seleccione el tipo de resolución directoral"); return false;
        }
        _ManGrillaPaging.fnNuevo($("#ddlManInfTecOpcionesId").val());
    }
}


ManInfTecnico.fnLoadManGrillaPaging = function () {
    //para cargar los datos en la vista
    var url = initSigo.urlControllerGeneral + "_ManGrillaPaging_v3";
    var data = ManInfTecnico.frm.serializeObject();
    var option = { url: url, datos: JSON.stringify(data), type: 'POST', dataType: 'html' };
    // para cargar las columnas y la data 
    var columns_label = [], columns_data = [], options = {}, data_extend = [];
    columns_label = ["Fecha Registro", " Nro. Inf. Técnico", "Tipo Inf. Técnico", "Nro Expediente Administrativo", "Nro Informe", "Nro. Título Habilitante", "Titular", "Modalidad"];
    columns_data = ["FECHA_CREACION", "NUMERO", "TIPO_FISCALIZA", "NUMERO_EXPEDIENTE", "NUMERO_INFORME", "NUM_THABILITANTE", "TITULAR", "MODALIDAD"];
    /*
    			
     */
    options = {
        page_paging: true, page_length: 20, row_index: true, row_edit: true, row_fnEdit: "_ManGrillaPaging.fnCreate(this)"
        , data_extend: data_extend
    };
    //para descargar los registros del SIGO
    utilSigo.fnAjax(option, function (data) {
        ManInfTecnico.frm.find("#dvManInfTecContenedor").html(data);
        _ManGrillaPaging.fnInit(columns_label, columns_data, options);

        _ManGrillaPaging.fnExport = function () {
            var url = urlLocalSigo + "Fiscalizacion/ManInformeTecnico/ExportarRegistroUsuario";
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
                var asCodigo = "";
                var url_crud = urlLocalSigo + "Fiscalizacion/ManInformeTecnico/CreateOrEdit";
                var data = _ManGrillaPaging.dtManGrillaPaging.row($(obj).parents('tr')).data();
                asCodigo = data["CODIGO"];

                _ManGrillaPaging.fnReadConfigManGrillaPaging();

                window.location = url_crud + "?asCodigo=" + asCodigo;
            } else {//Nuevo registro
                ManInfTecnico.fnShowListOptions();
                //utilSigo.toastWarning("Aviso", "Opción no disponible, por favor registre la notificación desde el sistema que corresponda");
            }
        }

        _ManGrillaPaging.fnNuevo = function (CodTipoI) {
            var cod_infLegal = "";
            var url_crud = urlLocalSigo + "Fiscalizacion/ManInformeTecnico/CreateOrEdit";
            _ManGrillaPaging.fnReadConfigManGrillaPaging();
            window.location = url_crud + "?asCodTipoIL=" + CodTipoI;
        }

    });
}

$(document).ready(function () {
    ManInfTecnico.frm = $("#frmManInfTecnico");

    var alertaInicial = ManInfTecnico.frm.find("#alertaFormulario").val();
    if (alertaInicial != "") {
        utilSigo.toastSuccess("Aviso", alertaInicial);
    }
    $.fn.select2.defaults.set("theme", "bootstrap4");
    $("#ddlManInfTecOpcionesId").select2();

    ManInfTecnico.fnLoadManGrillaPaging();
});