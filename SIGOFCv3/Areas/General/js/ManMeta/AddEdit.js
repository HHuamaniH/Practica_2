"use strict";
var AddEdit = {};

AddEdit.fnGuardar = function () {
    var url = urlLocalSigo + "General/ManMeta/AddEdit";
    var model = AddEdit.frm.serializeObject();
    model.ddlTipoIndicadorId = AddEdit.frm.find("#ddlTipoIndicadorId").val();
    model.ddlIndicadorId = AddEdit.frm.find("#ddlIndicadorId").val();
    model.ddlAnioId = AddEdit.frm.find("#ddlAnioId").val();
    model.ddlPeriodoId = AddEdit.frm.find("#ddlPeriodoId").val();
    var option = { url: url, datos: JSON.stringify(model), type: 'POST' };
    utilSigo.fnAjax(option, function (data) {
        if (data.success) {
            utilSigo.toastSuccess("Aviso", data.msj);
            AddEdit.fnClose();
            ManMeta.fnSearch();
        }
        else {
            utilSigo.toastWarning("Aviso", data.msj);
        }
    });
};

AddEdit.fnClose = function () {
    utilSigo.fnCloseModal("addEditModal");
};

AddEdit.fnCantidadDecimal = function (thix) {
    var element = document.getElementById(thix.id);

    if (element.value !== null) {
        var parts = element.value.toString().split('.');
        var uno = parts[0];
        var dos = parts[1];

        if (dos !== undefined) {
            if (dos.length > 2) {
                element.value=parseFloat(element.value.toString().slice(0, (uno.length + 3)));
            }
        }
    }
};

AddEdit.fnFiltrarIndicador = function (_tipo) {
    var url = urlLocalSigo + "General/ManMeta/FiltrarIndicador";
    var option = { url: url, type: 'POST', datos: JSON.stringify({ tipo: _tipo }) };

    utilSigo.fnAjax(option, function (data) {
        if (data.success) {
            var indicador = AddEdit.frm.find("#ddlIndicadorId");
            indicador.empty();
            $.each(data.result, function (index, item) {
                var p = new Option(item.Text, item.Value);
                indicador.append(p);
            });
        }
        else {
            utilSigo.toastWarning("Aviso", "Sucedio un error, Comuníquese con el Administrador");
            console.log(data.msj);
        }
    });
};

AddEdit.fnFiltrarAnio = function (_codindicador) {
    var url = urlLocalSigo + "General/ManMeta/FiltrarAnio";
    var params = { codindicador: _codindicador, tipo: "YEAR" };
    var option = { url: url, type: 'POST', datos: JSON.stringify(params) };

    utilSigo.fnAjax(option, function (data) {
        if (data.success) {
            var anio = AddEdit.frm.find("#ddlAnioId");
            anio.empty();
            $.each(data.result, function (index, item) {
                var p = new Option(item.Text, item.Value);
                anio.append(p);
            });
        }
        else {
            utilSigo.toastWarning("Aviso", "Sucedio un error, Comuníquese con el Administrador");
            console.log(data.msj);
        }
    });
};

AddEdit.fnInit = function () {
    AddEdit.frm = $("#frmAddEditMeta");
    AddEdit.cont = $("#divRegMeta");

    if (AddEdit.frm.find("#hdfCodMeta").val() != null &&
        AddEdit.frm.find("#hdfCodMeta").val() != "") {
        AddEdit.cont.find("#btnGuardar").text("Guardar");
        AddEdit.frm.find("#ddlTipoIndicadorId").attr("disabled", true);
        AddEdit.frm.find("#ddlIndicadorId").attr("disabled", true);
        AddEdit.frm.find("#ddlAnioId").attr("disabled", true);
        AddEdit.frm.find("#ddlPeriodoId").attr("disabled", true);
    }
    else {
        AddEdit.frm.find("#ddlTipoIndicadorId").removeAttr("disabled");
        AddEdit.frm.find("#ddlIndicadorId").removeAttr("disabled");
        AddEdit.frm.find("#ddlAnioId").removeAttr("disabled");
        AddEdit.frm.find("#ddlPeriodoId").removeAttr("disabled");
    }

    AddEdit.frm.find("#ddlTipoIndicadorId").change(function () {
        AddEdit.fnFiltrarIndicador(this.value);
    });

    AddEdit.frm.find("#ddlIndicadorId").change(function () {
        AddEdit.fnFiltrarAnio(this.value);
    });

    AddEdit.cont.find("#btnGuardar").click(function () {
        AddEdit.frm.submit();
    });
};

$(document).ready(function () {
    AddEdit.fnInit();

    jQuery.validator.addMethod("invalidFrmMeta", function (value, element) {
        switch ($(element).attr("id")) {
            case "ddlTipoIndicadorId":
                return (value == "-") ? false : true;
                break;
            case "ddlIndicadorId":
                return (value == "-") ? false : true;
                break;
            case "ddlAnioId":
                return (value == "-") ? false : true;
                break;
            case "ddlPeriodoId":
                return (value == "-") ? false : true;
                break;
        }
    });
    AddEdit.frm.validate(utilSigo.fnValidate({
        rules: {
            ddlTipoIndicadorId: { invalidFrmMeta: true },
            ddlIndicadorId: { invalidFrmMeta: true },
            ddlAnioId: { invalidFrmMeta: true },
            ddlPeriodoId: { invalidFrmMeta: true },
            txtValorMeta: { required: true }
        },
        messages: {
            ddlTipoIndicadorId: { invalidFrmMeta: "Seleccione Tipo de Indicador" },
            ddlIndicadorId: { invalidFrmMeta: "Seleccione Indicador" },
            ddlAnioId: { invalidFrmMeta: "Seleccione Año" },
            ddlPeriodoId: { invalidFrmMeta: "Seleccione Periodo" },
            txtValorMeta: { required: "Ingrese Valor de Meta" }
        },
        fnSubmit: function (form) {
            AddEdit.fnGuardar();
        }
    }));
});