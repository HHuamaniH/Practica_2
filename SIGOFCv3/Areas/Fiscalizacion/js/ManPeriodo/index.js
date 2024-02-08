"use strict";
var ManPeriodo = {};
ManPeriodo.addNewPersona = true;
ManPeriodo.url = urlLocalSigo + "Fiscalizacion/ManPeriodo/GetListPeriodo?";
ManPeriodo.fnBuscarPeriodo = function () {

    var valorBuscar = ManPeriodo.frm.find("#txtValor").val().trim();
    var valCriterio = ManPeriodo.frm.find("#cboCriterio").val();

    if (valCriterio == undefined) valCriterio = 'TODOS';
    var url = ManPeriodo.url + "criterio=" + valCriterio + "&valor=" + valorBuscar;

    ManPeriodo.dtPerfil.ajax.url(url).load(function (data) {
        if (data.success == false) {
            utilSigo.toastError("Error", "Sucedio un Error al listar los perfiles, Comuniquese con el Administrador");
            console.log(data.msjError);
        }
    });

}
ManPeriodo.fnInitEventos = function () {
    ManPeriodo.frm.find("#btnBuscar").click(function () {
        ManPeriodo.fnBuscarPeriodo();
    });
    ManPeriodo.frm.submit(function (e) {
        ManPeriodo.fnBuscarPeriodo();
        e.preventDefault();
    });
    ManPeriodo.frm.find("#btnNuevo").click(function () {
        ManPeriodo.fnAddEditPersona(null);
    });

}
ManPeriodo.fnInitDataTable_Detail = function () {
    var columns_label = ["Día Feriado", "Motivo Feriado"];
    var columns_data = ["DIA_FERIADO", "MOTIVO"];
    var data_extend = [];
    var options = {
        page_length: 20,
        row_delete: true, row_fnDelete: "ManPeriodo.fnAddDelete(this)",
        row_edit: true, row_fnEdit: "ManPeriodo.fnAddEditPersona(this)"
        , row_index: true, data_extend: data_extend
    };
    ManPeriodo.dtPerfil = utilDt.fnLoadDataTable_Detail($("#tbListPerfil"), columns_label, columns_data, options);
    ManPeriodo.fnBuscarPeriodo();
}
ManPeriodo.fnAddDelete = function (obj) {
    var itemRow = ManPeriodo.dtPerfil.row($(obj).parents('tr')).data();
    utilSigo.dialogConfirm('', 'Esta seguro de eliminar el periodo: ' + itemRow.ID + '?', function (r) {
        if (r) {
            var url = urlLocalSigo + "Fiscalizacion/ManPeriodo/_DeletePeriodo";
            var option = { url: url, datos: JSON.stringify({ id: itemRow.ID }), type: 'POST' };
            utilSigo.fnAjax(option, function (data) {
                if (data.success) {
                    utilSigo.toastSuccess("Aviso", data.msj);
                    ManPeriodo.fnBuscarPeriodo();
                }
                else {
                    utilSigo.toastWarning("Aviso", initSigo.MessageError);
                    console.log(data.msj);
                }
            });
        }
    });
}
ManPeriodo.fnAddEditPersona = function (obj) {
    var codigo = "";
    if (obj != null) {
        var itemRow = ManPeriodo.dtPerfil.row($(obj).parents('tr')).data();
        codigo = itemRow.ID;
    }
    var option = {
        url: urlLocalSigo + "Fiscalizacion/ManPeriodo/_AddEdit",
        divId: "manPerfilModal",
        datos: { cod: codigo }
    };
    utilSigo.fnOpenModal(option);
}
ManPeriodo.fnPerfilMenu = function (obj) {
    //console.log('Perfil', obj);
    var itemRow = ManPeriodo.dtPerfil.row($(obj).parents('tr')).data();
    ManPeriodo.fnLoadPErfilMenu(itemRow.id);
}
ManPeriodo.fnInit = function () {
    $('[data-toggle="tooltip"]').tooltip();
    ManPeriodo.frm = $("#frmListadoPerfil");
    ManPeriodo.frm.find("#txtValor").focus();
    ManPeriodo.fnInitEventos();
    ManPeriodo.fnInitDataTable_Detail();
}
ManPeriodo.fnLoadPErfilMenu = function (codPerfil) {
    var url = urlLocalSigo + "Seguridad/Perfil/_MenuPerfil";
    var option = { url: url, datos: { cod: codPerfil }, dataType: 'html' };
    utilSigo.fnAjax(option, function (data) {
        $("#divPerfilMenu").html(data);
        ManPeriodo.fnShowHide(1);
    });
}
ManPeriodo.fnShowHide = function (opcion) {
    if (opcion == 1) {
        $("#divPerfilMenu").slideDown();
        $("#divPerfil").slideUp();
    }
    else {
        $("#divPerfil").slideDown();
        $("#divPerfilMenu").slideUp();
    }
}
$(document).ready(function () {
    ManPeriodo.fnInit();
});