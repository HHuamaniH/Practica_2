var _EcotInforme = {};
_EcotInforme.fnAsignar = function (obj) {

}
_EcotInforme.fnModalPersona = function () {
    var url = urlLocalSigo + "General/Controles/_BuscarPersonaGeneral";
    var option = { url: url, type: 'GET', datos: { asBusGrupo: "PERSONA", asCodPTipo: "TODOS", asTipoPersona: "N" }, divId: "mdlBuscarPersona" };
    utilSigo.fnOpenModal(option, function () {
        _bPerGen.fnAsignarDatos = function (obj) {
            if (obj != null && obj != "") {
                var data = _bPerGen.dtBuscarPerona.row($(obj).parents('tr')).data();

                _EcotInforme.frm.find("#PROFESIONAL_NOMBRE").val(data["PERSONA"]);
                _EcotInforme.frm.find("#PROFESIONAL_DNI").val(data["N_DOCUMENTO"]);
                _EcotInforme.frm.find("#PROFESIONAL_CODIGO").val(data["COD_PERSONA"]);
                utilSigo.fnCloseModal("mdlBuscarPersona");
                _EcotInforme.validaAdicional();
            }
        };
        _bPerGen.fnInit();
    });
}
_EcotInforme.validaAdicional = function () {
    if (!utilSigo.fnValidateForm_HideControl(_EcotInforme.frm, _EcotInforme.frm.find("#PROFESIONAL_CODIGO"), _EcotInforme.frm.find("#iconProfesional"),false)) {
        return false;
    }
    return true;
}
_EcotInforme.fnConfigValidacion = function () {
    _EcotInforme.frm.validate(utilSigo.fnValidate({
        rules: {
            ANO_EJECUTADO: { required: true },
            FECHA_EMISION: { required: true }
        },
        messages: {
            ANO_EJECUTADO: { required: "Campo Requerido" },
            FECHA_EMISION: { required: "Campo Requerido" }            
        },
        fnSubmit: function (form) {           
            if (_EcotInforme.validaAdicional()) {
                utilSigo.dialogConfirm('', 'Desea continuar con la operacion?', function (r) {
                    if (r) {
                        _EcotInforme.fnSave();
                    }
                });
            }    
        }
    }));
}
_EcotInforme.fnSave = function () {
    var dataSave = _EcotInforme.frm.serializeObject();
    dataSave.PROFESIONAL_NOMBRE = _EcotInforme.frm.find("#PROFESIONAL_NOMBRE").val();
    dataSave.PROFESIONAL_DNI = _EcotInforme.frm.find("#PROFESIONAL_DNI").val();    
    _EcotInforme.fnAsignar(dataSave);
    if (dataSave.RegEstadoClient == RegEstadoSigo.NEW) {
        $(':input', _EcotInforme.frm).not(':button, :submit, :reset, :hidden').val('');         
        _EcotInforme.frm.find("#ANO_EJECUTADO").focus();
    }
}
_EcotInforme.fnInitData = function (obj) {
    //var keysFrom = Object.keys(ItemESituIAnual.objForm);
    var keysObj = Object.keys(obj);
    for (var i = 0; i < keysObj.length; i++) {
        _EcotInforme.frm.find("#" + keysObj[i]).val(obj[keysObj[i].trim()]);

    }
}
_EcotInforme.fnInitEventos = function () {
    _EcotInforme.fnConfigValidacion();
    _EcotInforme.cont.find("#btnGuardar").click(function () {
        _EcotInforme.frm.submit();
    });
    _EcotInforme.frm.find("#btnAddProfesional").click(function () {
        _EcotInforme.fnModalPersona();
    });
    $('.modal').on('shown.bs.modal', function () {
        _EcotInforme.frm.find("#ANO_EJECUTADO").focus();
    });
}
_EcotInforme.init = function (objInit) {
    _EcotInforme.frm = $("#frmEcoInforme");
    _EcotInforme.cont = $("#contenedorEcoInforme");
    if (typeof objInit.COD_SECUENCIAL != 'undefined') //para editar
    {
        _EcotInforme.cont.find("#h5Titulo").text("Modificando");
        _EcotInforme.fnInitData(objInit);
        _EcotInforme.frm.find("#RegEstadoClient").val("0");
    }
    _EcotInforme.fnInitEventos();    
    _EcotInforme.frm.find("#FECHA_EMISION").datepicker(initSigo.formatDatePicker);
} 