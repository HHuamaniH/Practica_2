"use strict";

var ManResolucion = {};


ManResolucion.fnShowListOptions = function () {
    var cod_infLegal = "";
    //var url_crud = urlLocalSigo + "Fiscalizacion/ManResolucion/CreateOrEdit";
    var url_crud = urlLocalSigo + "Tribunal/ManTribunal/CreateOrEdit";
    _ManGrillaPaging.fnReadConfigManGrillaPaging();
    window.location = url_crud;
}


ManResolucion.fnLoadManGrillaPaging = function () {
    //para cargar los datos en la vista
    var url = initSigo.urlControllerGeneral + "_ManGrillaPaging";
    var data = ManResolucion.frm.serializeObject();
    var option = { url: url, datos: JSON.stringify(data), type: 'POST', dataType: 'html' };
    // para cargar las columnas y la data 
    console.log("mensaje 1");
    var columns_label = [], columns_data = [], options = {}, data_extend = [];
    //columns_label = ["Fecha Registro", "Número TFFS", "Tipo Resolución", "Nro. Expediente Administrativo", "Numero Informe"];
    //columns_data = ["FECHA", "NUMERO_RESOLUCION", "TIPO_FISCALIZA", "NUMERO_EXPEDIENTE", "NUMERO_INFORME"];

    columns_label = ["Fecha Registro", "Nro Resolucion Tribunal", "Nro Resolucion", "Nro. Expediente Administrativo", "Nro. Titulo Habilitante", "Titular", "Modalidad"];
    console.log("mensaje 2");
    columns_data = ["FECHA", "NUM_RESOLUCION_TFFS", "NUM_RESOLUCION", "NUMERO_EXPEDIENTE", "NUM_THABILITANTE", "TITULAR", "MODALIDAD"];

    options = {
        page_paging: true, page_length: 20, row_index: true, row_edit: true, row_fnEdit: "_ManGrillaPaging.fnCreate(this)"
        , data_extend: data_extend
    };
    //para descargar los registros del SIGO
    utilSigo.fnAjax(option, function (data) {
        ManResolucion.frm.find("#dvManResolucionContenedor").html(data);
        _ManGrillaPaging.fnInit(columns_label, columns_data, options);

        _ManGrillaPaging.fnExport = function () {
            //var url = urlLocalSigo + "Fiscalizacion/ManResolucion/ExportarRegistroUsuario";
            var url = urlLocalSigo + "Tribunal/ManTribunal/ExportarRegistroUsuario";
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
                var asCodRD = "";
                //var url_crud = urlLocalSigo + "Fiscalizacion/ManResolucion/CreateOrEdit";
                var url_crud = urlLocalSigo + "Tribunal/ManTribunal/CreateOrEdit";
                var data = _ManGrillaPaging.dtManGrillaPaging.row($(obj).parents('tr')).data();
                /*asCodRD = data["COD_RESODIREC"];*/
                asCodRD = data["COD_RESOLUCION_TFFS"];
                _ManGrillaPaging.fnReadConfigManGrillaPaging();
                console.log(url_crud);

                window.location = url_crud + "?asCodRD=" + asCodRD;
            } else {//Nuevo registro
                console.log("aqui es el error");
                ManResolucion.fnShowListOptions();
                //utilSigo.toastWarning("Aviso", "Opción no disponible, por favor registre la notificación desde el sistema que corresponda");
            }
        }

        _ManGrillaPaging.fnNuevo = function (CodTipoI) {
            var cod_infLegal = "";
            //var url_crud = urlLocalSigo + "Fiscalizacion/ManResolucion/CreateOrEdit";
            var url_crud = urlLocalSigo + "Tribunal/ManTribunal/CreateOrEdit";
            _ManGrillaPaging.fnReadConfigManGrillaPaging();
            window.location = url_crud + "?asCodTipoIL=" + CodTipoI;
        }

    });
}

$(document).ready(function () {
    ManResolucion.frm = $("#frmManResodirec");

    var alertaInicial = ManResolucion.frm.find("#alertaFormulario").val();
    if (alertaInicial != "") {
        utilSigo.toastSuccess("Aviso", alertaInicial);
    }
    $.fn.select2.defaults.set("theme", "bootstrap4");
    $("#ddlManResolucionOpcionesId").select2();

    ManResolucion.fnLoadManGrillaPaging();
});