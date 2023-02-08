
var _Balance = {};
_Balance.fnClose = function () {
    utilSigo.fnCloseModal("modalItemESituBalance");
} 
_Balance.fnAddEdit = function () {
    var datosFrm = _Balance.frm.serializeObject()    
    var url = urlLocalSigo + "THabilitante/ManPlanManejo/AddEditESituBalance";
    var option = { url: url, datos: JSON.stringify(datosFrm),type:'POST'};
    utilSigo.fnAjax(option, function (data) {        
        if (data.success) {
            utilSigo.toastSuccess("Aviso", data.msj);
            if (datosFrm.hdTipo.trim() == "I") {
                ExSitu.fnReloadTbEsituIngreso();
            } else {
                ExSitu.fnReloadTbEsituEgreso();
            }
            _Balance.fnClose();
        }
        else {
            utilSigo.toastWarning("Aviso", "Sucedio un error, Comuniquese con el Administrador");
            console.log(data.msjError);
        }
    });     
} 
_Balance.fnInitEventos = function () {    
    _Balance.contenedor.find("#btnCancelar").click(function () {
        _Balance.fnClose();
    });
    _Balance.contenedor.find("#btnGuardar").click(function () {       
        utilSigo.dialogConfirm('', 'Desea continuar con la operacion?', function (r) {
            if (r) {
                _Balance.fnAddEdit();
            }
        });
    });    
}
$(document).ready(function () {
    $.fn.select2.defaults.set("theme", "bootstrap4");
    _Balance.contenedor = $("#divItemESituBalance");
    _Balance.frm = $("#frmItemESituBalance"); 
    _Balance.frm.find("#txtbfs_femision").datepicker(initSigo.formatDatePicker);
    _Balance.frm.find("#txtbfs_frecepcion").datepicker(initSigo.formatDatePicker); 
    _Balance.frm.find("#ddlbfs_especieId").select2();
    _Balance.fnInitEventos(); 
     
});