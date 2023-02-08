var _transferirM = {};
_transferirM.fnShowModalPoa = function () {
    let url = "", sFormulario = "TITULO_HABILITANTE", sCriterio = "CN_DEV_POA_PMANEJO", sValor = _transferirM.frm.find("#COD_THABILITANTE").val();
    url = initSigo.urlControllerGeneral + "_POA";
    if (sValor === 0 || sValor === "") {
        utilSigo.toastWarning("Aviso", "Falta seleccionar Título Habilitante");
        return false;
    }
    let option = { url: url, type: 'POST', datos: { asFormulario: sFormulario, asCriterio: sCriterio, asValor: sValor }, divId: "modalAddPlan" };
    utilSigo.fnOpenModal(option, function () {
        _POA.fnAsignarDatos = function (obj) {
            if (obj !== null && obj !== "") {                
                let data = _POA.dtPOA.row($(obj).parents('tr')).data();
                _transferirM.frm.find("#NOMBRE_POA").val(data.ESTADO_ORIGEN);
                _transferirM.frm.find("#NUM_POA").val(data.NUM_POA);
                _transferirM.frm.find("#res_poa").val(data.NUM_RESOLUCION);
               
                utilSigo.fnCloseModal("modalAddPlan");
            }
        };
        _POA.fnInit();
    });
};
_transferirM.fnShowModalTH = function () {
    let url = urlLocalSigo + "General/Controles/_THabilitante";
    let option = { url: url, type: 'GET', datos: { hdfFormulario: "TITULO_HABILITANTE" }, divId: "modalAddTH" };
    utilSigo.fnOpenModal(option, function () {
        vpTHabilitante.fnAsignarDatos = function (obj) {
            if (obj !== null && obj !== "") {
                let data = vpTHabilitante.dtTituloHabilitante.row($(obj).parents('tr')).data();
                _transferirM.frm.find("#COD_THABILITANTE").val(data["CODIGO"]);
                _transferirM.frm.find("#NUM_THABILITANTE").val(data["NUMERO"]);
                utilSigo.fnCloseModal("modalAddTH");
                //limpiando datos de plan de manejo
                _transferirM.frm.find("#NOMBRE_POA").val('');
                _transferirM.frm.find("#NUM_POA").val('');
                _transferirM.frm.find("#res_poa").val('');
            }
        };
        vpTHabilitante.fnInit_v2();
    });
};
 
_transferirM.close = function () {
    utilSigo.fnCloseModal("modalTransferir");
};
_transferirM.fnSave = function () {
    let codSecuencial =parseInt(_transferirM.frm.find("#COD_SECUENCIAL").val());
    let codTH = _transferirM.frm.find("#COD_THABILITANTE").val();
    let numPOA = _transferirM.frm.find("#NUM_POA").val();
    if (codTH === "") {
        utilSigo.toastWarning("Aviso","Falta seleccionar Título Habilitante");
        return false;
    }
    if (numPOA === "") {
        utilSigo.toastWarning("Aviso", "Falta seleccionar Plan de Manejo");
        return false;
    }
    utilSigo.dialogConfirm('', 'Desea continuar con la operacion?', function (r) {
        if (r) {
            let model = {
                cod_Tramite_Id: transferirS.frm.find("#tramiteId").val(),
                cod_secuencial: codSecuencial,
                cod_TH: codTH.trim(),
                num_TH: _transferirM.frm.find("#NUM_THABILITANTE").val().trim(),
                num_poa: _transferirM.frm.find("#NUM_POA").val(),
                nombre_poa: _transferirM.frm.find("#NOMBRE_POA").val(),
                res_poa: _transferirM.frm.find("#res_poa").val(),
                estado_supervision: _transferirM.frm.find("#cboSupervision").val(),
                obs: _transferirM.frm.find("#OBSERVACION").val(),
                estado:codSecuencial === 0 ? 1 : 2
            };
            
            let url = urlLocalSigo + "THabilitante/ManVentanillaSolicitud/TransferirDetalle";
            let option = { url: url, datos:JSON.stringify(model), type: 'POST' };
            utilSigo.fnAjax(option, function (data) {
                if (data.success) {
                    utilSigo.toastSuccess("Aviso", data.msj);                    
                    utilSigo.fnCloseModal("modalTransferir");
                    transferirS.fnLoadTable();
                }
                else {
                    utilSigo.toastError("Error", "Sucedio un Error. Comunicarse con el administrador del sistema");
                }
            });
        }
    });    
};
_transferirM.fnInit = function (objInit) {
    $.fn.select2.defaults.set("theme", "bootstrap4");
    _transferirM.frm = $("#frmAddTHS");
    _transferirM.cont = $("#contenedorTransferir");
    _transferirM.frm.find("#cboSupervision").select2();
    if (typeof objInit.COD_SECUENCIAL !== 'undefined') //para editar
    {
        _transferirM.cont.find("#h5Titulo").text("Modificando");
        _transferirM.frm.find("#COD_SECUENCIAL").val(objInit.COD_SECUENCIAL);
        _transferirM.frm.find("#NUM_THABILITANTE").val(objInit.NUM_THABILITANTE);
        _transferirM.frm.find("#COD_THABILITANTE").val(objInit.COD_THABILITANTE);
        _transferirM.frm.find("#NOMBRE_POA").val(objInit.NOMBRE_POA);
        _transferirM.frm.find("#NUM_POA").val(objInit.NUM_POA);
        _transferirM.frm.find("#res_poa").val(objInit.RESOLUCION_POA);
        _transferirM.frm.find("#cboSupervision").val(objInit.ESTADO_SUPERVISION);
        _transferirM.frm.find("#OBSERVACION").val(objInit.OBSERVACION);

    }
    else {
        _transferirM.frm.find("#COD_SECUENCIAL").val(0);
    }
    $('.modal').on('shown.bs.modal', function () {
        _transferirM.frm.find("#OBSERVACION").focus();
    });

}; 