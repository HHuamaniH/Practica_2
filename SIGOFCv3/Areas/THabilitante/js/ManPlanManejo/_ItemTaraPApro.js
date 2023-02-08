"use strict";
var _ItemTaraPApro = {};
_ItemTaraPApro.fnAsignar = function (obj) {

}
_ItemTaraPApro.fnConfigValidacion = function () {
    _ItemTaraPApro.frm.validate(utilSigo.fnValidate({
        rules: {
            ANO: { required: true },
            NUM_ARBOLES: { required: true },
            PESO_VAINAS: { required: true },
            NUM_COSECHA: { required: true },
            NUM_QUINTALES: { required: true }
        },
        messages: {
            ANO: { required: "Ingrese Año" },
            NUM_ARBOLES: { required: "Ingrese número de árboles" },
            PESO_VAINAS: { required: "Ingrese peso de las vainas" },
            NUM_COSECHA: { required: "Ingrese número de cosechas" },
            NUM_QUINTALES: { required: "Ingrese quintales" }
        },
        fnSubmit: function (form) {
            _ItemTaraPApro.fnSave();
        }
    }));
}
_ItemTaraPApro.fnSave = function () {
    var dataSave = _ItemTaraPApro.frm.serializeObject();
    console.log(dataSave);
    _ItemTaraPApro.fnAsignar(dataSave);
    if (dataSave.RegEstadoClient == RegEstadoSigo.NEW) {
        $(':input', _ItemTaraPApro.frm).not(':button, :submit, :reset, :hidden').val('');
        _ItemTaraPApro.frm.find("#ANO").focus();
    }
}
_ItemTaraPApro.fnInitData = function (obj) {
    //var keysFrom = Object.keys(ItemESituIAnual.objForm);
    var keysObj = Object.keys(obj);
    for (var i = 0; i < keysObj.length; i++) {
        _ItemTaraPApro.frm.find("#" + keysObj[i]).val(obj[keysObj[i].trim()]);

    }
}
_ItemTaraPApro.fnInitEventos = function () {
    _ItemTaraPApro.fnConfigValidacion();
    _ItemTaraPApro.cont.find("#btnGuardar").click(function () {
        _ItemTaraPApro.frm.submit();
    });
    $('.modal').on('shown.bs.modal', function () {
        _ItemTaraPApro.frm.find("#ANO").focus();
    });
}
_ItemTaraPApro.init = function (objInit) {
    _ItemTaraPApro.frm = $("#frmTaraPApro");
    _ItemTaraPApro.cont = $("#contenedorTaraPApro");
    if (typeof objInit.COD_SECUENCIAL != 'undefined') //para editar
    {
        _ItemTaraPApro.cont.find("#h5Titulo").text("Modificando");
        _ItemTaraPApro.fnInitData(objInit);
        _ItemTaraPApro.frm.find("#RegEstadoClient").val("0");
    }
    _ItemTaraPApro.fnInitEventos();
} 