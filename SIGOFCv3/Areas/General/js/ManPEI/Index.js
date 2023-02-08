"use strict";
var ManPEI = {};

ManPEI.fnAddEdit = function (obj) {
    var codTHPOA = "";
    if (obj != null) {
        var itemRow = ManPEI.dtPEI.row($(obj).parents('tr')).data();
        codTHPOA = itemRow.NV_CODIGO;
    }
    var option = {
        url: urlLocalSigo + "General/ManPEI/AddEdit",
        divId: "addEditModal",
        datos: { cod: codTHPOA }
    };
    utilSigo.fnOpenModal(option);
}

ManPEI.fnSearch = function () {
    var valorCboOpcion = ManPEI.frm.find("#ddlOptBuscarId").val();
    var valorBusqueda = ManPEI.frm.find("#txtValorBuscar").val().trim();

    if (valorCboOpcion != "Todos") {
        if (valorBusqueda.trim() == "") {
            utilSigo.toastWarning("Aviso", "Ingrese Valor a Buscar");
            ManPEI.frm.find("#txtValorBuscar").focus();
            return false;
        }
    }

    var url = urlLocalSigo + "General/ManPEI/GetListPEI?" + "opc=" + valorCboOpcion + "&valor=" + valorBusqueda;
    ManPEI.dtPEI.ajax.url(url).load(function (data) {
        if (data.success == false) {
            utilSigo.toastError("Error", "Sucedio un Error al listar los perfiles, Comuniquese con el Administrador");
            console.log(data.msjError);
        }
    });
};

ManPEI.fnRefresh = function () {
    ManPEI.frm.find("#ddlOptBuscarId").val($(ManPEI.frm.find("#ddlOptBuscarId")[0].childNodes[0]).val()).trigger('change.select2');
    ManPEI.frm.find("#txtValorBuscar").val("");
    ManPEI.frm.find("#txtValorBuscar").attr("disabled", true);
    ManPEI.fnSearch();
};

ManPEI.fnInitDataTable_Detail = function () {
    var columns_label = ["Año", "Semestre", "Valor de Supervisión", "Valor Quinquenal", "Valor de Medida", "Última Modificación"];
    var columns_data = ["NU_ANIO", "NU_TRIMESTRE", "NU_VALOR_SUPERVISION", "NU_VALOR_AUDITORIA", "NU_VALOR_MEDIDA", "FECHA_ULTIMA_MODIFICACION"];
    var options = {
        page_length: 20, row_edit: true, row_fnEdit: "ManPEI.fnAddEdit(this)", row_index: true
    };
    ManPEI.dtPEI = utilDt.fnLoadDataTable_Detail($("#tbListPEI"), columns_label, columns_data, options);
    ManPEI.fnSearch();
}

ManPEI.fnInitEventos = function () {
    ManPEI.frm.find("#ddlOptBuscarId").change(function () {
        if ($(this).val() == "Todos") {
            ManPEI.frm.find("#txtValorBuscar").val("");
            ManPEI.frm.find("#txtValorBuscar").attr("disabled", true);
        }
        else {
            ManPEI.frm.find("#txtValorBuscar").val("");
            ManPEI.frm.find("#txtValorBuscar").removeAttr("disabled");
            if ($(this).val() == "Anio") {
                ManPEI.frm.find("#txtValorBuscar").attr("pattern", "[0-9]{1,6}");
                ManPEI.frm.find("#txtValorBuscar").attr("title", "Solo debe ingresar números enteros");
                ManPEI.frm.find("#txtValorBuscar").attr("maxlength", 4);
                ManPEI.frm.find("#txtValorBuscar").attr("onkeypress", "return utilSigo.onKeyEntero(event, this);");
            }
            else {
                ManPEI.frm.find("#txtValorBuscar").removeAttr("pattern");
                ManPEI.frm.find("#txtValorBuscar").removeAttr("title");
                ManPEI.frm.find("#txtValorBuscar").removeAttr("maxlength");
                ManPEI.frm.find("#txtValorBuscar").removeAttr("onkeypress");
            }
        }
        setTimeout(function () {
            $('.select2-container-active').removeClass('select2-container-active');
            ManPEI.frm.find("#txtValorBuscar").focus();
        }, 1);
    });

    ManPEI.frm.submit(function (e) {
        ManPEI.fnSearch();
        e.preventDefault();
    });
};

$(document).ready(function () {
    ManPEI.frm = $("#frmManPEI");

    $('[data-toggle="tooltip"]').tooltip();
    $.fn.select2.defaults.set("theme", "bootstrap4");
    ManPEI.frm.find("#ddlOptBuscarId").select2();

    ManPEI.fnInitEventos();
    ManPEI.fnInitDataTable_Detail();
});