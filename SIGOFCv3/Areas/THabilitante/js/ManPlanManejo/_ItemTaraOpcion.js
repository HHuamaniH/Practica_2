"use strict";
var _ItemTaraOpcion = {};
_ItemTaraOpcion.fnAsignar = function (obj) {

}
_ItemTaraOpcion.fnSave = function () {
    _ItemTaraOpcion.frm.find("#COD_PMTOPCIONES").attr("disabled", false);
    var dataSave = _ItemTaraOpcion.frm.serializeObject();
    dataSave.DESCRIPCION = _ItemTaraOpcion.frm.find("#COD_PMTOPCIONES").select2('data')[0].text;
    console.log(dataSave);
    _ItemTaraOpcion.fnAsignar(dataSave);
    if (dataSave.RegEstadoClient == RegEstadoSigo.NEW) {
        _ItemTaraOpcion.frm.find("#OBSERVACION").val('');
        _ItemTaraOpcion.frm.find("#OBSERVACION").focus();
    }
}
_ItemTaraOpcion.fnInitData = function (obj) {    
    var keysObj = Object.keys(obj);
    for (var i = 0; i < keysObj.length; i++) {
        var controltype = _ItemTaraOpcion.frm.find("#" + keysObj[i]).prop("type");
        if (controltype == "select-one")
            _ItemTaraOpcion.frm.find("#" + keysObj[i]).val(obj[keysObj[i].trim()]).trigger('change');
        else _ItemTaraOpcion.frm.find("#" + keysObj[i]).val(obj[keysObj[i].trim()]);
      
    }
}
_ItemTaraOpcion.fnInitEventos = function () {     
    _ItemTaraOpcion.cont.find("#btnGuardar").click(function () {
        _ItemTaraOpcion.fnSave();
    });
    $('.modal').on('shown.bs.modal', function () {
        _ItemTaraOpcion.frm.find("#OBSERVACION").focus();
    });
}
_ItemTaraOpcion.init = function (objInit) {
    $.fn.select2.defaults.set("theme", "bootstrap4");
    _ItemTaraOpcion.frm = $("#frmTaraOpcion");
    _ItemTaraOpcion.cont = $("#contenedorTaraOpcion");
    _ItemTaraOpcion.frm.find("#COD_PMTOPCIONES").select2();
    if (typeof objInit.COD_SECUENCIAL != 'undefined') //para editar
    {
        _ItemTaraOpcion.cont.find("#h5Titulo").text("Modificando");
        _ItemTaraOpcion.fnInitData(objInit);
        _ItemTaraOpcion.frm.find("#COD_PMTOPCIONES").attr("disabled", true);
        _ItemTaraOpcion.frm.find("#RegEstadoClient").val("0");

    } 
    _ItemTaraOpcion.fnInitEventos();
     
} 