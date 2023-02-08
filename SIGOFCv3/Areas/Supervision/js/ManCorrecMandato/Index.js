"use strict";

var ManCorrecMandato = {};

$(document).ready(function () {
    ManCorrecMandato.frm = $("#frmManCorrecMandato");

    var alertaInicial = ManCorrecMandato.frm.find("#alertaFormulario").val();
    if (alertaInicial != "") {
        utilSigo.toastSuccess("Aviso", alertaInicial);
    }
    ManCorrecMandato.fnLoadManGrillaPaging();
});

ManCorrecMandato.fnLoadManGrillaPaging = function () {
    var url = initSigo.urlControllerGeneral + "_ManGrillaPaging";
    var data = ManCorrecMandato.frm.serializeObject();
    var option = { url: url, datos: JSON.stringify(data), type: 'POST', dataType: 'html' };

    var columns_label = [], columns_data = [], options = {}, data_extend = [];
    columns_label = ["Titular", "Título Habilitante", "Modalidad", "Nro. Resolución", "Nro. Expediente"];
    columns_data = ["TITULAR", "NUM_THABILITANTE", "MODALIDAD", "NUM_RESOLUCION", "NUM_EXPEDIENTE"];

    options = {
        page_paging: true, page_length: 20, row_index: true, row_edit: true, row_fnEdit: "_ManGrillaPaging.fnCreate(this)"
        , data_extend: data_extend
    };

    utilSigo.fnAjax(option, function (data) {
        ManCorrecMandato.frm.find("#dvManCorrecMandatoContenedor").html(data);
        _ManGrillaPaging.fnInit(columns_label, columns_data, options);

        _ManGrillaPaging.fnExport = function () {
            var url = urlLocalSigo + "Supervision/ManCorrecMandato/ExportarTabla";
            var option = { url: url, datos: JSON.stringify({}), type: 'POST' };

            utilSigo.fnAjax(option, function (data) {
                if (data.success) {
                    document.location = urlLocalSigo + "Archivos/Plantilla/Reg_Usu/Temp/" + data.msj;
                }
                else {
                    utilSigo.toastWarning("Aviso", "Ocurrió un error, por favor comuníquese con el administrador");
                }
            });
        };

        _ManGrillaPaging.fnCreate = function (obj) {
            if (obj != "") {
                var cod_resodirec = "";
                var url_crud = urlLocalSigo + "Supervision/ManCorrecMandato/AddEdit";
                var data = _ManGrillaPaging.dtManGrillaPaging.row($(obj).parents('tr')).data();

                cod_resodirec = data["COD_RESODIREC"];

                _ManGrillaPaging.fnReadConfigManGrillaPaging();

                window.location = url_crud + "?asCodResodirec=" + cod_resodirec;
            }
            else {
                utilSigo.toastWarning("Aviso", "La opción seleccionada no se encuentra disponible");
            }
        };
    });
}
