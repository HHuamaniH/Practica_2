"use strict";
var AddEdit = {};

AddEdit.fnGuardar = function () {
    var url = urlLocalSigo + "General/ManPEI/AddEdit";
    var model = AddEdit.frm.serializeObject();
    model.ddlAnioId = AddEdit.frm.find("#ddlAnioId").val();
    model.ddlTrimestreId = AddEdit.frm.find("#ddlTrimestreId").val();
    var option = { url: url, datos: JSON.stringify(model), type: 'POST' };
    utilSigo.fnAjax(option, function (data) {
        if (data.success) {
            utilSigo.toastSuccess("Aviso", data.msj);
            AddEdit.fnClose();
            ManPEI.fnSearch();
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
    AddEdit.frm = $("#frmAddEditPEI");
    AddEdit.cont = $("#divRegPEI");

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

    jQuery.validator.addMethod("invalidFrmPEI", function (value, element) {
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
            ddlAnioId: { invalidFrmPEI: true },
            ddlTrimestreId: { invalidFrmPEI: true },
            txtValorSupervision: { required: true },
            txtValorAuditoria: { required: true },
            txtValorMedida: { required: true }
        },
        messages: {
            ddlAnioId: { invalidFrmPEI: "Seleccione Año" },
            ddlTrimestreId: { invalidFrmPEI: "Seleccione Trimestre" },
            txtValorSupervision: { required: "Ingrese Valor de Supervisión" },
            txtValorAuditoria: { required: "Ingrese Valor Quinquenal" },
            txtValorMedida: { required: "Ingrese Valor de Medida" }
        },
        fnSubmit: function (form) {
            AddEdit.fnGuardar();
        }
    }));
});