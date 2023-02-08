var EsituPGenetico = {};
EsituPGenetico.fnClose = function () {
    utilSigo.fnCloseModal("modalItemESituPgenetico");
} 
EsituPGenetico.validaAdicional = function () {
    if (!utilSigo.fnValidateForm_HideControl(EsituPGenetico.frm, EsituPGenetico.frm.find("#hdfItemPGenetico_PCodigo"), EsituPGenetico.frm.find("#iconProfesional"),false)) {
        return false;
    }
    return true;
}
EsituPGenetico.fnConfigValidacion = function () {
    EsituPGenetico.frm.validate(utilSigo.fnValidate({
        rules: {
            txtnum_resolucion: { required: true },
            txtfecha_emision_resolucion: { required: true }           
        },
        messages: {
            txtnum_resolucion: { required: "Ingrese N° Resolució" },
            txtfecha_emision_resolucion: { required: "Ingrese Fecha" }
        },
        fnSubmit: function (form) {
            if (EsituPGenetico.validaAdicional()) {
                utilSigo.dialogConfirm('', 'Desea continuar con la operacion?', function (r) {
                    if (r) {
                        EsituPGenetico.fnAddEdit();
                    }
                });
            }
        }
    }));
}
EsituPGenetico.fnModalPersona = function () {
    var url = urlLocalSigo + "General/Controles/_BuscarPersonaGeneral";
    var option = { url: url, type: 'GET', datos: { fFormOrigen: "", cod_P_Tipo: "0000006" }, divId: "modalBuscarPersona" };
    utilSigo.fnOpenModal(option, function () {
        _bPerGen.fnAsignarDatos = function (obj) {
            console.log(obj);
            if (obj != null && obj != "") {
                //alert("aqui");
                var data = _bPerGen.dtBuscarPerona.row($(obj).parents('tr')).data();
                EsituPGenetico.frm.find("#lblItemPGenetico_PNombre").val(data["PERSONA"]);
                EsituPGenetico.frm.find("#lblItemPGenetico_PDNI").val(data["N_DOCUMENTO"]);

                var str = data["NUM_REGISTRO_PROFESIONAL"];
                var res = str.split("|");

               
                EsituPGenetico.frm.find("#hdfItemPGenetico_PCodigo").val(data["COD_PERSONA"]);
                EsituPGenetico.frm.find("#lblItemESituIAnual_PNC").val(res[2]);
                EsituPGenetico.frm.find("#lblItemPGenetico_PCargo").val(res[3]);
                utilSigo.fnCloseModal("modalBuscarPersona");
                EsituPGenetico.validaAdicional();
            }
        }
        _bPerGen.fnInit();
    });
}
EsituPGenetico.fnAddEdit = function () {
    var datosFrm = EsituPGenetico.frm.serializeObject()    
    $.ajax({
        url: urlLocalSigo + "THabilitante/ManPlanManejo/AddEditESituPGenetico",
        type: 'POST',
        data: JSON.stringify(datosFrm),
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function (data) {
            utilSigo.unblockUIGeneral();
            if (data.success) {
                utilSigo.toastSuccess("Aviso", data.msj);
                ExSitu.fnReloadTbEsituGenetico();
                EsituPGenetico.fnClose();
            }
            else {
                utilSigo.toastWarning("Aviso", "Sucedio un error, Comuniquese con el Administrador");
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
EsituPGenetico.fnInitEventos = function () {
    EsituPGenetico.frm.find("#txtfecha_emision_resolucion").datepicker(initSigo.formatDatePicker);
    EsituPGenetico.contenedor.find("#btnAddProfesional").click(function () {
        EsituPGenetico.fnModalPersona();
    });
    EsituPGenetico.contenedor.find("#btnGuardar").click(function () {        
        EsituPGenetico.frm.submit();
    });
    EsituPGenetico.contenedor.find("#btnCancelar").click(function () {
        EsituPGenetico.fnClose();
    });
    
    $('#modalBuscarPersona').on('hidden.bs.modal', function () {
        utilSigo.fnCloseModal("modalBuscarPersona");
        EsituPGenetico.validaAdicional();
    });
}
$(document).ready(function () {
    EsituPGenetico.contenedor = $("#divItemESituPGenetico");
    EsituPGenetico.frm = $("#frmItemESituPGenetico");
    EsituPGenetico.fnConfigValidacion();
    EsituPGenetico.fnInitEventos();
});