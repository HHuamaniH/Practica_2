"use strict";
var _TaraAutoExtraer = {};
_TaraAutoExtraer.fnAsignar = function (obj) {
    
}
_TaraAutoExtraer.fnConfigValidacion = function () {
    _TaraAutoExtraer.frm.validate(utilSigo.fnValidate({
        rules: {
            SUPERFICIE_HA: { required: true },
            TOTAL_PGMF: { required: true },
            ANO_1: { required: true },
            ANO_2: { required: true },
            ANO_3: { required: true },
            ANO_4: { required: true },
            ANO_5: { required: true },
            DERECHO_APROVE_QUINTAL: { required: true },
            DERECHO_APROVE_QTOTAL: { required: true }
        },
        messages: {
            SUPERFICIE_HA: { required: "Campo requerido" },
            TOTAL_PGMF: { required: "Campo requerido" },
            ANO_1: { required: "Campo requerido" },
            ANO_2: { required: "Campo requerido" },
            ANO_3: { required: "Campo requerido" },
            ANO_4: { required: "Campo requerido" },
            ANO_5: { required: "Campo requerido" },
            DERECHO_APROVE_QUINTAL: { required: "Campo requerido" },
            DERECHO_APROVE_QTOTAL: { required: "Campo requerido" }
        },
        fnSubmit: function (form) {
            _TaraAutoExtraer.fnSave();            
        }
    }));
}
_TaraAutoExtraer.fnSave = function () {    
    var dataSave = _TaraAutoExtraer.frm.serializeObject();   
    dataSave.ESPCIES = _TaraAutoExtraer.frm.find("#COD_ESPECIES").select2('data')[0].text;
    console.log(dataSave);
    _TaraAutoExtraer.fnAsignar(dataSave);
    if (dataSave.RegEstadoClient == RegEstadoSigo.NEW) {
        _TaraAutoExtraer.frm.find("#SUPERFICIE_HA").val('');
        _TaraAutoExtraer.frm.find("#TOTAL_PGMF").val('');
        _TaraAutoExtraer.frm.find("#ANO_1").val('');
        _TaraAutoExtraer.frm.find("#ANO_2").val('');
        _TaraAutoExtraer.frm.find("#ANO_3").val('');
        _TaraAutoExtraer.frm.find("#ANO_4").val('');
        _TaraAutoExtraer.frm.find("#ANO_5").val('');
        _TaraAutoExtraer.frm.find("#DERECHO_APROVE_QUINTAL").val('');
        _TaraAutoExtraer.frm.find("#DERECHO_APROVE_QTOTAL").val('');
        _TaraAutoExtraer.frm.find("#SUPERFICIE_HA").focus();
    }
}
_TaraAutoExtraer.fnInitData = function (obj) {
    var keysObj = Object.keys(obj);
    for (var i = 0; i < keysObj.length; i++) {
        var controltype = _TaraAutoExtraer.frm.find("#" + keysObj[i]).prop("type");
        if (controltype == "select-one")
            _TaraAutoExtraer.frm.find("#" + keysObj[i]).val(obj[keysObj[i].trim()]).trigger('change');
        else _TaraAutoExtraer.frm.find("#" + keysObj[i]).val(obj[keysObj[i].trim()]);

    }
}
_TaraAutoExtraer.fnInitEventos = function () {
    _TaraAutoExtraer.fnConfigValidacion();
    _TaraAutoExtraer.cont.find("#btnGuardar").click(function () {
        _TaraAutoExtraer.frm.submit();
    });
    $('.modal').on('shown.bs.modal', function () {
        _TaraAutoExtraer.frm.find("#SUPERFICIE_HA").focus();
    });
}
_TaraAutoExtraer.init = function (objInit) {
    $.fn.select2.defaults.set("theme", "bootstrap4");
    _TaraAutoExtraer.frm = $("#frmTaraAutoExtraer");
    _TaraAutoExtraer.cont = $("#contenedorTaraAutoExtraer");
    _TaraAutoExtraer.frm.find("#COD_ESPECIES").select2();
    if (typeof objInit.COD_SECUENCIAL != 'undefined') //para editar
    {
        _TaraAutoExtraer.cont.find("#h5Titulo").text("Modificando");
        _TaraAutoExtraer.fnInitData(objInit);         
        _TaraAutoExtraer.frm.find("#RegEstadoClient").val("0");

    }
    _TaraAutoExtraer.fnInitEventos();

} 