"use strict";
var ManTH = {};

ManTH.fnAddEdit = function (obj) {
    var codTHPOA = "";
    if (obj != null) {
        var itemRow = ManTH.dtTHPOA.row($(obj).parents('tr')).data();
        codTHPOA = itemRow.NV_CODIGO;
    }
    var option = {
        url: urlLocalSigo + "General/ManTHAuditar/AddEdit",
        divId: "addEditModal",
        datos: { cod: codTHPOA }
    };
    utilSigo.fnOpenModal(option);
}

ManTH.fnSearch = function () {
    var valorCboOpcion = ManTH.frm.find("#ddlOptBuscarId").val();
    var valorBusqueda = ManTH.frm.find("#txtValorBuscar").val().trim();

    if (valorCboOpcion != "Todos") {
        if (valorBusqueda.trim() == "") {
            utilSigo.toastWarning("Aviso", "Ingrese Valor a Buscar");
            ManTH.frm.find("#txtValorBuscar").focus();
            return false;
        }
    }

    var url = urlLocalSigo + "General/ManTHAuditar/GetListTHabilitantePOI?" + "opc=" + valorCboOpcion + "&valor=" + valorBusqueda;
    ManTH.dtTHPOA.ajax.url(url).load(function (data) {
        if (data.success == false) {
            utilSigo.toastError("Error", "Sucedio un Error al listar los perfiles, Comuniquese con el Administrador");
            console.log(data.msjError);
        }
    });
};

ManTH.fnRefresh = function () {
    ManTH.frm.find("#ddlOptBuscarId").val($(ManTH.frm.find("#ddlOptBuscarId")[0].childNodes[0]).val()).trigger('change.select2');
    ManTH.frm.find("#txtValorBuscar").val("");
    ManTH.frm.find("#txtValorBuscar").attr("disabled", true);
    ManTH.fnSearch();
};

ManTH.fnInitDataTable_Detail = function () {
    var columns_label = ["Año", "Trimestre", "Valor de Auditoría", "Valor de Supervisión", "Última Modificación"];
    var columns_data = ["NU_ANIO", "NU_TRIMESTRE", "NU_VALOR_AUDITORIA", "NU_VALOR_SUPERVISION", "FECHA_ULTIMA_MODIFICACION"];
    var options = {
        page_length: 20, row_edit: true, row_fnEdit: "ManTH.fnAddEdit(this)",row_index: true
    };
    ManTH.dtTHPOA = utilDt.fnLoadDataTable_Detail($("#tbListTH"), columns_label, columns_data, options);
    ManTH.fnSearch();
}

ManTH.fnInitEventos = function () {
    ManTH.frm.find("#ddlOptBuscarId").change(function () {
        if ($(this).val() == "Todos") {
            ManTH.frm.find("#txtValorBuscar").val("");
            ManTH.frm.find("#txtValorBuscar").attr("disabled", true);
        }
        else {
            ManTH.frm.find("#txtValorBuscar").val("");
            ManTH.frm.find("#txtValorBuscar").removeAttr("disabled");
            if ($(this).val() == "Anio") {
                ManTH.frm.find("#txtValorBuscar").attr("pattern", "[0-9]{1,6}");
                ManTH.frm.find("#txtValorBuscar").attr("title", "Solo debe ingresar números enteros");
                ManTH.frm.find("#txtValorBuscar").attr("maxlength", 4);
                ManTH.frm.find("#txtValorBuscar").attr("onkeypress", "return utilSigo.onKeyEntero(event, this);");
            }
            else {
                ManTH.frm.find("#txtValorBuscar").removeAttr("pattern");
                ManTH.frm.find("#txtValorBuscar").removeAttr("title");
                ManTH.frm.find("#txtValorBuscar").removeAttr("maxlength");
                ManTH.frm.find("#txtValorBuscar").removeAttr("onkeypress");
            }
        }
        setTimeout(function () {
            $('.select2-container-active').removeClass('select2-container-active');
            ManTH.frm.find("#txtValorBuscar").focus();
        }, 1);
    });

    ManTH.frm.submit(function (e) {       
        ManTH.fnSearch();
        e.preventDefault();
    });
};

$(document).ready(function () {
    ManTH.frm = $("#frmManTHAuditar");

    $('[data-toggle="tooltip"]').tooltip();
    $.fn.select2.defaults.set("theme", "bootstrap4");
    ManTH.frm.find("#ddlOptBuscarId").select2();

    ManTH.fnInitEventos();
    ManTH.fnInitDataTable_Detail();
});