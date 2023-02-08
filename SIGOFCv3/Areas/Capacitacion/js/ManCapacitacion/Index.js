"use strict";
var ManCapacitacion = {};

ManCapacitacion.fnLoadManGrillaPaging = function () {
    var url = initSigo.urlControllerGeneral + "_ManGrillaPaging";
    var data = ManCapacitacion.frm.serializeObject();
    var option = { url: url, datos: JSON.stringify(data), type: 'POST', dataType: 'html' };

    var columns_label = [], columns_data = [], options = {};
    columns_label = ["Fecha Registro", "Cod. Capacitación", "Nombre", "OD", "Tipo Taller", "Fecha Inicio", "Nro. Participantes", "Nro. Registrados"];
    columns_data = ["FECHA", "COD_CAPACITACION", "NOMBRE", "OD", "TIPO_TALLER", "FECHA_INICIO", "PARTICIPANTES", "REGISTRADOS"];
    options = {
        page_paging: true, page_length: 20, row_index: true, row_edit: true, row_fnEdit: "_ManGrillaPaging.fnCreate(this)"
    };

    utilSigo.fnAjax(option, function (data) {
        ManCapacitacion.frm.find("#dvManCapacitacionContenedor").html(data);
        _ManGrillaPaging.fnInit(columns_label, columns_data, options);

        _ManGrillaPaging.fnExport = function () {
            var url = urlLocalSigo + "Capacitacion/ManCapacitacion/ExportarRegistroUsuario";
            var data = { "asFormulario": ManCapacitacion.frm.find("#tipoFormulario").val() };
            var option = { url: url, datos: JSON.stringify(data), type: 'POST' };

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
            var cod_capacitacion = "";
            var url_crud = urlLocalSigo + "Capacitacion/ManCapacitacion/AddEdit";

            if (obj != "") {//Modificar registro
                var data = _ManGrillaPaging.dtManGrillaPaging.row($(obj).parents('tr')).data();
                cod_capacitacion = data["COD_CAPACITACION"];
            }

            _ManGrillaPaging.fnReadConfigManGrillaPaging();

            window.location = url_crud + "?asCodCapacitacion=" + cod_capacitacion + "&asFormulario=" + ManCapacitacion.frm.find("#tipoFormulario").val();
        }
    });
}

$(document).ready(function () {
    ManCapacitacion.frm = $("#frmManCapacitacion");

    var alertaInicial = ManCapacitacion.frm.find("#alertaFormulario").val();
    if (alertaInicial != "") {
        utilSigo.toastSuccess("Aviso", alertaInicial);
    }

    ManCapacitacion.fnLoadManGrillaPaging();
});