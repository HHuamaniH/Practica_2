"use strict";
var ManInfMedidaCorrectiva = {};

ManInfMedidaCorrectiva.fnShowListOptions = function () {
    utilSigo.modalDraggable($("#mdN_ListOpciones"), '.modal-header');
    $("#mdN_ListOpciones").modal({ keyboard: true, backdrop: 'static' });

    ManInfMedidaCorrectiva.fnNuevaCN = function () {

        if ($("#ddlManInfMedidaCorrectivaOpcionesId").val().length == 0) {
            utilSigo.toastWarning("Aviso", "Seleccione una Modalidad antes de continuar"); return false;
        }

        _ManGrillaPaging.fnNuevo($("#ddlManInfMedidaCorrectivaOpcionesId").val(), $("#ddlManInfMedidaCorrectivaOpcionesId option:selected").text());
    }
}

ManInfMedidaCorrectiva.fnLoadManGrillaPaging = function () {
    var url = initSigo.urlControllerGeneral + "_ManGrillaPaging";
    var data = ManInfMedidaCorrectiva.frm.serializeObject();
    var option = { url: url, datos: JSON.stringify(data), type: 'POST', dataType: 'html' };

    var columns_label = [], columns_data = [], options = {};
    columns_label = ["Fecha Registro", "Número", "Tipo Informe", "Título Habilitante", "Titular", "Modalidad", "Número Expediente"];
    columns_data = ["FECHA_CREACION", "NUM_INFORME", "TIPO_INFORME", "NUM_THABILITANTE", "TITULAR", "MODALIDAD", "NUM_EXPEDIENTE"];
    options = {
        page_paging: true, page_length: 20, row_index: true, row_edit: true, row_fnEdit: "_ManGrillaPaging.fnCreate(this)"
    };

    utilSigo.fnAjax(option, function (data) {
        ManInfMedidaCorrectiva.frm.find("#dvManInfMedidaCorrectivaContenedor").html(data);
        _ManGrillaPaging.fnInit(columns_label, columns_data, options);

        _ManGrillaPaging.fnExport = function () {
            var url = urlLocalSigo + "Supervision/ManInformeMedidaCorrectiva/ExportarRegistroUsuario";
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
            var cod_infmedidac = "";
            var url_crud = urlLocalSigo + "Supervision/ManInformeMedidaCorrectiva/AddEdit";

            if (obj != "") {//Modificar registro
                var data = _ManGrillaPaging.dtManGrillaPaging.row($(obj).parents('tr')).data();
                cod_infmedidac = data["COD_INFORME"];

                _ManGrillaPaging.fnReadConfigManGrillaPaging();

                window.location = url_crud + "?asCodInfMedidaCorrectiva=" + cod_infmedidac + "&asCodTipoIMC=" + "" + "&asTextTipoIMC=" + "";
            } else {//Nuevo registro
                ManInfMedidaCorrectiva.fnShowListOptions();
            }
        }

        _ManGrillaPaging.fnNuevo = function (CodTipoIMC, TextTipoIMC) {
            var cod_infmedidac = "";
            var url_crud = urlLocalSigo + "Supervision/ManInformeMedidaCorrectiva/AddEdit";
            _ManGrillaPaging.fnReadConfigManGrillaPaging();
            window.location = url_crud + "?asCodInfMedidaCorrectiva=" + cod_infmedidac + "&asCodTipoIMC=" + CodTipoIMC + "&asTextTipoIMC=" + TextTipoIMC;
        }
    });
}

$(document).ready(function () {
    ManInfMedidaCorrectiva.frm = $("#frmManInfMedidaCorrectiva");

    var alertaInicial = ManInfMedidaCorrectiva.frm.find("#alertaFormulario").val();
    if (alertaInicial != "") {
        utilSigo.toastSuccess("Aviso", alertaInicial);
    }

    $.fn.select2.defaults.set("theme", "bootstrap4");
    $("#ddlManInfMedidaCorrectivaOpcionesId").select2();

    ManInfMedidaCorrectiva.fnLoadManGrillaPaging();
});