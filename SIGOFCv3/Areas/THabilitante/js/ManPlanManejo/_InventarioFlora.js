"use strict";
var _InventarioFlora = {};
_InventarioFlora.fnAsignar = function (obj) {

}
_InventarioFlora.fnConfigValidacion = function () {
    jQuery.validator.addMethod("invalidFrmInvFlora", function (value, element) {
        switch ($(element).attr('id')) {
            case 'COD_ESPECIES':
                return (value == '-') ? false : true;
                break;          
        }
    });
    _InventarioFlora.frm.validate(utilSigo.fnValidate({
        rules: {
            COD_ESPECIES: { invalidFrmInvFlora: true },
            CARACTERISTICAS: { required: true },
            RASOCIACIONES_FAUNA: { required: true }
        },
        messages: {
            COD_ESPECIES: { invalidFrmInvFlora: "Seleccione Especie" },
            CARACTERISTICAS: { required: "Campo Requerido" },
            RASOCIACIONES_FAUNA: { required: "Campo Requerido" }
        },
        fnSubmit: function (form) {            
                utilSigo.dialogConfirm('', 'Desea continuar con la operacion?', function (r) {
                    if (r) {
                        _InventarioFlora.fnSave();
                    }
                });            
        }
    }));
}
_InventarioFlora.fnSave = function () {
    _InventarioFlora.frm.find("#COD_ESPECIES").attr("disabled", false);
    var dataSave = _InventarioFlora.frm.serializeObject();
    dataSave.ESPECIES = _InventarioFlora.frm.find("#COD_ESPECIES").select2('data')[0].text;
    console.log(dataSave);
    _InventarioFlora.fnAsignar(dataSave);
    if (dataSave.RegEstadoClient == RegEstadoSigo.NEW) {
        _InventarioFlora.frm.find("#CARACTERISTICAS").val('');
        _InventarioFlora.frm.find("#RASOCIACIONES_FAUNA").val('');
        _InventarioFlora.frm.find("#OBSERVACION").val('');
        _InventarioFlora.frm.find("#CARACTERISTICAS").focus();        
    }
}
_InventarioFlora.fnInitData = function (obj) {
    var keysObj = Object.keys(obj);
    for (var i = 0; i < keysObj.length; i++) {
        var controltype = _InventarioFlora.frm.find("#" + keysObj[i]).prop("type");
        if (controltype == "select-one")
            _InventarioFlora.frm.find("#" + keysObj[i]).val(obj[keysObj[i].trim()]).trigger('change');
        else _InventarioFlora.frm.find("#" + keysObj[i]).val(obj[keysObj[i].trim()]);

    }
}
_InventarioFlora.fnInitEventos = function () {   
    _InventarioFlora.fnConfigValidacion();
    _InventarioFlora.cont.find("#btnGuardar").click(function () {
        _InventarioFlora.frm.submit();
    });
    $('.modal').on('shown.bs.modal', function () {
        _InventarioFlora.frm.find("#CARACTERISTICAS").focus();
    });
    //Para cuando cambia el combo para select2
    _InventarioFlora.frm.find("select.select2-hidden-accessible").change(function () {
        if (!$.isEmptyObject(_InventarioFlora.frm.validate().submitted)) {
            _InventarioFlora.frm.validate().form();
        }
    });
}
_InventarioFlora.fnInit = function (objInit) {
    $.fn.select2.defaults.set("theme", "bootstrap4");
    _InventarioFlora.frm = $("#frmFlora");
    _InventarioFlora.cont = $("#contenedorFlora");
    _InventarioFlora.frm.find("#COD_ESPECIES").select2();
    if (typeof objInit.COD_SECUENCIAL != 'undefined') //para editar
    {
        _InventarioFlora.cont.find("#h5Titulo").text("Modificando");
        _InventarioFlora.fnInitData(objInit);
        _InventarioFlora.frm.find("#COD_ESPECIES").attr("disabled", true);
        _InventarioFlora.frm.find("#RegEstadoClient").val("0");

    }
    _InventarioFlora.fnInitEventos();

} 