"use strict";
var ManPersonas = {};

ManPersonas.fnLoadManGrillaPaging = function () {
    var url = initSigo.urlControllerGeneral + "_ManGrillaPaging";
    var data = ManPersonas.frm.serializeObject();
    var option = { url: url, datos: JSON.stringify(data), type: 'POST', dataType: 'html' };

    var columns_label = [], columns_data = [], options = {};
    columns_label = ["Nombres", "Tipo Documento", "Nro. Documento", "Tipo Persona", "Sexo"];
    columns_data = ["APELLIDOS_NOMBRES", "TIPO_DOCUMENTO", "N_DOCUMENTO", "TIPO_PERSONA", "SEXO"];
    options = {
        page_paging: true, page_length: 20, row_index: true, row_edit: true, row_fnEdit: "_ManGrillaPaging.fnCreate(this)"
    };

    utilSigo.fnAjax(option, function (data) {
        ManPersonas.frm.find("#dvManPersonasContenedor").html(data);
        _ManGrillaPaging.fnInit(columns_label, columns_data, options);

        _ManGrillaPaging.fnExport = function () {
            /*var url = urlLocalSigo + "General/ManPersonas/ExportarRegistroUsuario";
            var option = { url: url, datos: JSON.stringify({}), type: 'POST' };

            utilSigo.fnAjax(option, function (data) {
                if (data.success) {
                    document.location = urlLocalSigo + "Archivos/Plantilla/Reg_Usu/" + data.msj;
                }
                else {
                    utilSigo.toastWarning("Aviso", "Sucedio un error, Comuníquese con el Administrador");
                    console.log(data.msj);
                }
            });*/

            utilSigo.toastInfo("Aviso", "El número de registros supera capacidad");
        }

        _ManGrillaPaging.fnCreate = function (obj) {
            var codpersona = "";
            let be = ManPersonas.frm.serializeObject();
            var url_crud = urlLocalSigo + "General/ManPersonas/AddEdit";

            if (obj != "") {//Modificar registro
                var data = _ManGrillaPaging.dtManGrillaPaging.row($(obj).parents('tr')).data();
                codpersona = data["COD_PERSONA"];
            }

            _ManGrillaPaging.fnReadConfigManGrillaPaging();

            //window.location = url_crud + "?asCodPersona=" + codpersona + '&' + 'tipo=' + be.titleMenu.substring(0, 1);
            window.location = url_crud + "?asCodPersona=" + codpersona;
        }
    });
}

$(document).ready(function () {
    ManPersonas.frm = $("#frmManPersonas");

    var alertaInicial = ManPersonas.frm.find("#alertaFormulario").val();
    if (alertaInicial != "") {
        utilSigo.toastSuccess("Aviso", alertaInicial);
    }

    ManPersonas.fnLoadManGrillaPaging();
});