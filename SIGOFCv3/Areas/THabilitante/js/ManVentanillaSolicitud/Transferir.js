var transferirS = {};
transferirS.regresar = function () {
    window.location = urlLocalSigo + "THabilitante/ManVentanillaSolicitud/Index";
};
transferirS.AddEdit = function (obj) {
    let url = urlLocalSigo + "THabilitante/ManVentanillaSolicitud/_Transferir";
    let option = { url: url, type: 'GET', datos: {}, divId: "modalTransferir" };
    let dataRow = {};
    if (obj !== "") { //editar
        let trEdit = $(obj).closest('tr');
        dataRow = transferirS.dtTransferSol.row(trEdit).data();
    }
    utilSigo.fnOpenModal(option, function () {
       
        _transferirM.fnInit(dataRow);
    });
};
transferirS.fnGetDataDelete = function (obj, opcion) {
    let model = [];
    if (parseInt(opcion) === 1) { //1 - delet 1 , 2 delete all
        let trDelete = $(obj).closest('tr');
        let dataRow = transferirS.dtTransferSol.row(trDelete).data();
        model.push({
            cod_Tramite_Id: transferirS.frm.find("#tramiteId").val(),
            cod_secuencial: dataRow.COD_SECUENCIAL
        });
    } else if (parseInt(opcion) === 2) {
        
        transferirS.dtTransferSol.rows().every(function (rowIdx, tableLoop, rowLoop) {
            let row = this.data();
            model.push({
                cod_Tramite_Id: transferirS.frm.find("#tramiteId").val(),
                cod_secuencial: row.COD_SECUENCIAL
            });
        });
    }
    return model;
};
transferirS.Delete = function (obj,opcion) {
    let lstModel = transferirS.fnGetDataDelete(obj, opcion);
    if (lstModel.length > 0) {
        utilSigo.dialogConfirm("Confirmacion", "Está seguro de Eliminar el/los Registros?",
            function (r) {
                if (r) {
                    let url = urlLocalSigo + "THabilitante/ManVentanillaSolicitud/EliminarSolicitadosDetalle";
                    let option = { url: url, datos: JSON.stringify(lstModel), type: 'POST' };
                    utilSigo.fnAjax(option, function (data) {
                        if (data.success) {
                            transferirS.fnLoadTable();
                            utilSigo.toastSuccess("Aviso", data.msj);
                        }
                        else {
                            utilSigo.toastError("Error", "Sucedio un Error. Comunicarse con el administrador del sistema");
                        }
                    });
                }
            });
    }
    else {
        utilSigo.toastWarning("Aviso", "No existe items a eliminar");
    } 
};
transferirS.fnInitDatatable = function () {
    let columns_label = ["Título Habilitante", "Plan de Manejo", "Resolución de Aprobación del Plan de Manejo", "Supervisión OSINFOR", "Observación"];
    let columns_data = ["NUM_THABILITANTE", "NOMBRE_POA", "RESOLUCION_POA", "ESTADO_SUPERVISION", "OBSERVACION"];
    let options = {
        page_length: 10,
        row_edit: true, row_fnEdit: "transferirS.AddEdit(this)",
        row_delete: true, row_fnDelete: "transferirS.Delete(this,1)"
        , row_index: true
    };
    transferirS.dtTransferSol = utilDt.fnLoadDataTable_Detail(transferirS.frm.find("#tbTHSolicitados"), columns_label, columns_data, options);
};
transferirS.fnLoadTable = function () {
    let tramidetId = transferirS.frm.find("#tramiteId").val();    
    let url = urlLocalSigo + "THabilitante/ManVentanillaSolicitud/ObtenerTH_Solicitados?tramiteId=" + tramidetId;
    transferirS.dtTransferSol.ajax.url(url).load(function (data) {
        if (data.success === false) {
            utilSigo.toastError("Error", "Sucedio un Error al cargar registros");
            console.log(data.msjError);
        }
    });
};
transferirS.fnSaveCabecera = function () {
    let model = {
        tramideId: transferirS.frm.find("#tramiteId").val(),
        obsTransferencia: transferirS.frm.find("#txtObsTransferencia").val()
    };
    let url = urlLocalSigo + "THabilitante/ManVentanillaSolicitud/TransferirCabecera";
    let option = { url: url, datos: JSON.stringify(model), type: 'POST' };
    utilSigo.fnAjax(option, function (data) {
        if (data.success) {
            utilSigo.toastSuccess("Aviso", data.msj);  
            transferirS.frm.find("#divTabla").removeAttr('style');
        }
        else {
            utilSigo.toastError("Error", "Sucedio un Error. Comunicarse con el administrador del sistema");
        }
    });
};
$(document).ready(function () {
    transferirS.frm = $("#frmTransferirInformacion");
    transferirS.fnInitDatatable();
    transferirS.fnLoadTable();
    console.log(transferirS.frm.find("#nFlgTransferencia").val());
    if(parseInt(transferirS.frm.find("#nFlgTransferencia").val()) === 2) {
        transferirS.frm.find("#divTabla").removeAttr('style');
    }
});