"use strict";
var ManMeta = {};

ManMeta.fnAddEdit = function (obj) {
    var codMeta = "";
    if (obj != null) {
        var itemRow = ManMeta.dtMeta.row($(obj).parents('tr')).data();
        codMeta = itemRow.NV_CODIGO;
    }
    var option = {
        url: urlLocalSigo + "General/ManMeta/AddEdit",
        divId: "addEditModal",
        datos: { cod: codMeta }
    };
    utilSigo.fnOpenModal(option);
}

ManMeta.fnSearch = function () {
    var valorCboOpcion = ManMeta.frm.find("#ddlOptBuscarId").val();
    var valorBusqueda = ManMeta.frm.find("#txtValorBuscar").val().trim();

    if (valorCboOpcion != "Todos") {
        if (valorBusqueda == "") {
            utilSigo.toastWarning("Aviso", "Ingrese Valor a Buscar");
            ManMeta.frm.find("#txtValorBuscar").focus();
            return false;
        }
    }

    var url = urlLocalSigo + "General/ManMeta/GetListMeta?" + "opc=" + valorCboOpcion + "&valor=" + valorBusqueda;
    ManMeta.dtMeta.ajax.url(url).load(function (data) {
        if (data.success == false) {
            utilSigo.toastError("Error", "Sucedio un error, Comuníquese con el Administrador");
            console.log(data.msjError);
        }
    });
};

ManMeta.fnRefresh = function () {
    ManMeta.frm.find("#ddlOptBuscarId").val($(ManMeta.frm.find("#ddlOptBuscarId")[0].childNodes[0]).val()).trigger('change.select2');
    ManMeta.frm.find("#txtValorBuscar").val("");
    ManMeta.frm.find("#txtValorBuscar").attr("disabled", true);
    ManMeta.fnSearch();
};

ManMeta.fnInitDataTable_Detail = function () {
    var columns_label = ["Tipo de Indicador", "Nombre del Indicador", "Año", "Periodo", "Meta", "Última Modificación"];
    var columns_data = ["NV_TIPO", "NV_INDICADOR", "NU_ANIO", "NV_PERIODO", "NU_META", "FECHA_ULTIMA_MODIFICACION"];
    var options = {
        page_length: 20, row_edit: true, row_fnEdit: "ManMeta.fnAddEdit(this)", row_index: true
    };
    ManMeta.dtMeta = utilDt.fnLoadDataTable_Detail($("#tbMeta"), columns_label, columns_data, options);
    ManMeta.fnSearch();
};

ManMeta.fnInitEventos = function () {
    ManMeta.frm.find("#ddlOptBuscarId").change(function () {
        if ($(this).val() == "Todos") {
            ManMeta.frm.find("#txtValorBuscar").val("");
            ManMeta.frm.find("#txtValorBuscar").attr("disabled", true);
        }
        else {
            ManMeta.frm.find("#txtValorBuscar").val("");
            ManMeta.frm.find("#txtValorBuscar").removeAttr("disabled");
            if ($(this).val() == "Anio") {
                ManMeta.frm.find("#txtValorBuscar").attr("pattern", "[0-9]{1,6}");
                ManMeta.frm.find("#txtValorBuscar").attr("title", "Solo debe ingresar números enteros");
                ManMeta.frm.find("#txtValorBuscar").attr("maxlength", 4);
                ManMeta.frm.find("#txtValorBuscar").attr("onkeypress", "return utilSigo.onKeyEntero(event, this);");
            }
            else {
                ManMeta.frm.find("#txtValorBuscar").removeAttr("pattern");
                ManMeta.frm.find("#txtValorBuscar").removeAttr("title");
                ManMeta.frm.find("#txtValorBuscar").removeAttr("maxlength");
                ManMeta.frm.find("#txtValorBuscar").removeAttr("onkeypress");
            }
        }
        setTimeout(function () {
            $('.select2-container-active').removeClass('select2-container-active');
            ManMeta.frm.find("#txtValorBuscar").focus();
        }, 1);
    });

    ManMeta.frm.submit(function (e) {
        e.preventDefault();
        ManMeta.fnSearch();
    });
};

$(document).ready(function () {
    ManMeta.frm = $("#frmBuscarMeta");

    $('[data-toggle="tooltip"]').tooltip();
    $.fn.select2.defaults.set("theme", "bootstrap4");
    ManMeta.frm.find("#ddlOptBuscarId").select2();

    ManMeta.fnInitEventos();
    ManMeta.fnInitDataTable_Detail();
});