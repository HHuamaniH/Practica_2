"use strict";
var ManProgramaCapacitacion = {};

ManProgramaCapacitacion.fnLoadManGrillaPaging = function () {
    var url = initSigo.urlControllerGeneral + "_ManGrillaPaging";
    var data = ManProgramaCapacitacion.frm.serializeObject();
    var option = { url: url, datos: JSON.stringify(data), type: 'POST', dataType: 'html' };

    var columns_label = [], columns_data = [], options = {};
    columns_label = ["Fecha Registro", "Cod. Capacitación", "Nombre", "Tipo Taller", "OD", "Fecha Inicio"];
    columns_data = ["FECHA", "COD_PCAPACITACION", "NOMBRE", "TIPO_TALLER", "OD", "FECHA_INICIO"];
    options = {
        page_paging: true, page_length: 20, row_index: true, row_edit: true, row_fnEdit: "_ManGrillaPaging.fnCreate(this)"
    };

    utilSigo.fnAjax(option, function (data) {
        ManProgramaCapacitacion.frm.find("#dvManProgramaCapacitacionContenedor").html(data);
        _ManGrillaPaging.fnInit(columns_label, columns_data, options);

        _ManGrillaPaging.fnExport = function () {
            var url = urlLocalSigo + "Capacitacion/ManProgramaCapacitacion/ExportarRegistroUsuario";
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
            var cod_pcapacitacion = "";
            var url_crud = urlLocalSigo + "Capacitacion/ManProgramaCapacitacion/AddEdit";

            if (obj != "") {//Modificar registro
                var data = _ManGrillaPaging.dtManGrillaPaging.row($(obj).parents('tr')).data();
                cod_pcapacitacion = data["COD_PCAPACITACION"];
            }

            _ManGrillaPaging.fnReadConfigManGrillaPaging();

            window.location = url_crud + "?asCodPCapacitacion=" + cod_pcapacitacion;
        }
    });
}

$(document).ready(function () {
    ManProgramaCapacitacion.frm = $("#frmManProgramaCapacitacion");

    var alertaInicial = ManProgramaCapacitacion.frm.find("#alertaFormulario").val();
    if (alertaInicial != "") {
        utilSigo.toastSuccess("Aviso", alertaInicial);
    }

    ManProgramaCapacitacion.fnLoadManGrillaPaging();
});