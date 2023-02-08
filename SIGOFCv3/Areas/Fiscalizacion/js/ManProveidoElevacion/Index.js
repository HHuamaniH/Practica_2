
"use strict";

var ManProveido = {};

ManProveido.fnLoadManGrillaPaging = function () {
    //para cargar los datos en la vista
    var url = initSigo.urlControllerGeneral + "_ManGrillaPaging_v3";
    var data = ManProveido.frm.serializeObject();
    var option = { url: url, datos: JSON.stringify(data), type: 'POST', dataType: 'html' };
    // para cargar las columnas y la data 
    var columns_label = [], columns_data = [], options = {}, data_extend = [];
    columns_label = ["Fecha Derivación", "Dirección de Linea", "Funcionario", "Profesional", "Documento", "Informe de Referencia", "Derivado para"];
    columns_data = ["FECHA_DERIVACION", "DIRECCION_LINEA", "FUNCIONARIO", "PROFESIONAL", "DOCUMENTO", "INFORME", "TIPO_DERIVACION"];
    options = {
        page_paging: true, page_length: 20, row_index: true, row_edit: true, row_fnEdit: "_ManGrillaPaging.fnCreate(this)"
        , data_extend: data_extend
    };
    //para descargar los registros del SIGO
    utilSigo.fnAjax(option, function (data) {
        ManProveido.frm.find("#dvManProvedioContenedor").html(data);
        _ManGrillaPaging.fnInit(columns_label, columns_data, options);

        _ManGrillaPaging.fnExport = function () {
            var url = urlLocalSigo + "Fiscalizacion/ManProveidoElevacion/ExportarRegistroUsuario";
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
                var url_crud = urlLocalSigo + "Fiscalizacion/ManProveidoElevacion/CreateOrEdit";
                var data = _ManGrillaPaging.dtManGrillaPaging.row($(obj).parents('tr')).data();
                asCodigo = data["CODIGO"];
                _ManGrillaPaging.fnReadConfigManGrillaPaging();
                window.location = url_crud + "?asCodigo=" + asCodigo;
            } else {//Nuevo registro
                var asCodigo = "";
                var url_crud = urlLocalSigo + "Fiscalizacion/ManProveidoElevacion/CreateOrEdit";
                _ManGrillaPaging.fnReadConfigManGrillaPaging();
                window.location = url_crud + "?asCodigo=" + asCodigo;
            }
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