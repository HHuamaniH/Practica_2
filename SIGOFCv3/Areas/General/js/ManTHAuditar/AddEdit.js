"use strict";
var AddEdit = {};

AddEdit.fnGuardar = function () {
    var url = urlLocalSigo + "General/ManTHAuditar/AddEdit";
    var model = AddEdit.frm.serializeObject();
    model.ddlAnioId = AddEdit.frm.find("#ddlAnioId").val();
    model.ddlTrimestreId = AddEdit.frm.find("#ddlTrimestreId").val();
    var option = { url: url, datos: JSON.stringify(model), type: 'POST' };
    utilSigo.fnAjax(option, function (data) {
        if (data.success) {
            utilSigo.toastSuccess("Aviso", data.msj);
            AddEdit.fnClose();
            ManTH.fnSearch();
        }
        else {
            utilSigo.toastWarning("Aviso", data.msj);
        }
    });
}

AddEdit.fnClose = function () {
    utilSigo.fnCloseModal("addEditModal");
}

AddEdit.fnInit = function () {
    AddEdit.frm = $("#frmAddEditTHPOI");
    AddEdit.cont = $("#divRegTHPOA");

    if (AddEdit.frm.find("#hdfCodTHPOI").val() != null &&
        AddEdit.frm.find("#hdfCodTHPOI").val() != "") {
        AddEdit.cont.find("#btnGuardar").text("Guardar");
        AddEdit.frm.find("#ddlAnioId").attr("disabled", true);
        AddEdit.frm.find("#ddlTrimestreId").attr("disabled", true);
    }
    else {
        AddEdit.frm.find("#ddlAnioId").removeAttr("disabled");
        AddEdit.frm.find("#ddlTrimestreId").removeAttr("disabled");
    }

    AddEdit.cont.find("#btnGuardar").click(function () {
        AddEdit.frm.submit();
    });
}

$(document).ready(function () {
    AddEdit.fnInit();

    jQuery.validator.addMethod("invalidFrmTHPOI", function (value, element) {
        switch ($(element).attr("id")) {
            case "ddlAnioId":
                return (value == "0000") ? false : true;
                break;
            case "ddlTrimestreId":
                return (value == "0") ? false : true;
                break;
        }
    });
    AddEdit.frm.validate(utilSigo.fnValidate({
        rules: {
            ddlAnioId: { invalidFrmTHPOI: true },
            ddlTrimestreId: { invalidFrmTHPOI: true },
            txtValorAuditoria: { required: true },
            txtValorSupervision: { required: true }
        },
        messages: {
            ddlAnioId: { invalidFrmTHPOI: "Seleccione Año" },
            ddlTrimestreId: { invalidFrmTHPOI: "Seleccione Trimestre" },
            txtValorAuditoria: { required: "Ingrese Valor de Auditoría" },
            txtValorSupervision: { required: "Ingrese Valor de Supervisión" }
        },
        fnSubmit: function (form) {
            AddEdit.fnGuardar();
        }
    }));
});