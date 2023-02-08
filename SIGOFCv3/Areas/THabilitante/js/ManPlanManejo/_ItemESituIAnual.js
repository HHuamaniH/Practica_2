var ItemESituIAnual = {};
ItemESituIAnual.objForm = "";
ItemESituIAnual.fnClose = function () {
    utilSigo.fnCloseModal("modalItemESituIAnual");
} 
ItemESituIAnual.fnModalPersona = function () {
    var url = urlLocalSigo + "General/Controles/_BuscarPersonaGeneral";
    var option = { url: url, type: 'GET', datos: { fFormOrigen: "", cod_P_Tipo:"0000008"}, divId: "modalBuscarPersona" };
    utilSigo.fnOpenModal(option, function () {
        _bPerGen.fnAsignarDatos = function (obj) {
            if (obj != null && obj != "") {
               // console.log(obj);
                var data = _bPerGen.dtBuscarPerona.row($(obj).parents('tr')).data(); 
                console.log(data);
                //ItemESituIAnual.frm.find("#txtProfesional").val(data["desc"]);
                ItemESituIAnual.frm.find("#txtProfesional").val(data["PERSONA"]);
                ItemESituIAnual.frm.find("#txtDni").val(data["N_DOCUMENTO"]);
                
               // alert(data["NUM_REGISTRO_PROFESIONAL"]);
                var str = data["NUM_REGISTRO_PROFESIONAL"]; 
                var res = str.split("|");
                
                ItemESituIAnual.frm.find("#hdtxtProfesional").val(data["COD_PERSONA"]);
                ItemESituIAnual.frm.find("#txtItemESituIAnual_PNR").val(res[1]);
                ItemESituIAnual.frm.find("#lblItemESituIAnual_PNC").val(res[2]);
                
                utilSigo.fnCloseModal("modalBuscarPersona");
                ItemESituIAnual.validaAdicional();
            }
        }       
        _bPerGen.fnInit();
    });
}
ItemESituIAnual.fnAddEdit = function () {
    var datosFrm = ItemESituIAnual.frm.serializeObject()
    datosFrm.chkItemAcorde_Tdr_Vigente = utilSigo.fnGetValChk(ItemESituIAnual.frm.find("#chkItemAcorde_Tdr_Vigente"));
    $.ajax({
        url: urlLocalSigo + "THabilitante/ManPlanManejo/AddEditESituIAnual",
        type: 'POST',
        data: JSON.stringify(datosFrm),
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function (data) {
            utilSigo.unblockUIGeneral();
            if (data.success) {
                utilSigo.toastSuccess("Aviso", data.msj);
                ExSitu.fnReloadTbEsituAnual();
                ItemESituIAnual.fnClose();
            }
            else {
                utilSigo.toastWarning("Aviso","Sucedio un error, Comuniquese con el Administrador");
                console.log(data.msjError);
            } 
        },
        beforeSend: function () {
            utilSigo.blockUIGeneral();
        },
        error: function (jqXHR, error, errorThrown) {
            utilSigo.unblockUIGeneral();
            utilSigo.toastError("Error", "Sucedio un error, Comuniquese con el Administrador");
            console.log(jqXHR.responseText);
        }
    });
} 
ItemESituIAnual.validaAdicional = function () {
    if (!utilSigo.fnValidateForm_HideControl(ItemESituIAnual.frm, ItemESituIAnual.frm.find("#hdtxtProfesional"), ItemESituIAnual.frm.find("#iconProfesional"),false)) {
        return false;
    }        
  return true;
}
ItemESituIAnual.fnConfigValidacion = function () {
    ItemESituIAnual.frm.validate(utilSigo.fnValidate({
        rules: {
            txtItemESituIAnual_Ano: { required: true },
            txtItemESituIAnual_FEmision: { required: true },
            txtItemESituIAnual_FRecepcion: { required: true },
            txtItemESituIAnual_PNR: { required: true }
        },
        messages: {
            txtItemESituIAnual_Ano: { required: "Ingrese Año" },
            txtItemESituIAnual_FEmision: { required: "Ingrese Fecha" },
            txtItemESituIAnual_FRecepcion: { required: "Ingrese Fecha Recepción" },
            txtItemESituIAnual_PNR: { required: "Ingrese N° Registro" }
        },
        fnSubmit: function (form) {
            if (ItemESituIAnual.validaAdicional()) {
                utilSigo.dialogConfirm('', 'Desea continuar con la operacion?', function (r) {
                    if (r) {
                        ItemESituIAnual.fnAddEdit();
                    }
                });
            }    
        }
    }));
}
ItemESituIAnual.fnInitEventos = function () {       
    ItemESituIAnual.fnConfigValidacion();
    ItemESituIAnual.contenedor.find("#btnCancelar").click(function () {
        ItemESituIAnual.fnClose();
    });
    ItemESituIAnual.contenedor.find("#btnGuardar").click(function () {
        ItemESituIAnual.frm.submit();
    });
    ItemESituIAnual.contenedor.find("#btnAddProfesional").click(function () {
        ItemESituIAnual.fnModalPersona();
    });
    $('#modalBuscarPersona').on('hidden.bs.modal', function () {
        utilSigo.fnCloseModal("modalBuscarPersona");        
        ItemESituIAnual.validaAdicional();
    });
} 
$(document).ready(function () {
    ItemESituIAnual.contenedor = $("#divItemESituAnual");
    ItemESituIAnual.frm = $("#frmItemESituAnual"); //utilSigo.onKeyEntero
    ItemESituIAnual.frm.find("#txtItemESituIAnual_FEmision").datepicker(initSigo.formatDatePicker);
    ItemESituIAnual.frm.find("#txtItemESituIAnual_FRecepcion").datepicker(initSigo.formatDatePicker);
    ItemESituIAnual.fnInitEventos();
});