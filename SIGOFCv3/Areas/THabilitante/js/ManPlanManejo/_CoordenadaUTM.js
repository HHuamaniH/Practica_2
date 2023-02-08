var _CoorUTM = {};
_CoorUTM.fnAsignar = function (obj) {

}
_CoorUTM.fnConfigValidacion = function () {
    _CoorUTM.frm.validate(utilSigo.fnValidate({
        rules: {
            NUM_PARCELA: { required: true },
            NUM_PUNTOS: { required: true },
            COORDENADA_ESTE: { required: true },
            COORDENADA_NORTE: { required: true }
        },
        messages: {
            NUM_PARCELA: { required: "Campo Requerido" },
            NUM_PUNTOS: { required: "Campo Requerido" },
            COORDENADA_ESTE: { required: "Ingrese Coord. Este" },
            COORDENADA_NORTE: { required: "Ingrese Coord. Norte" }
        },
        fnSubmit: function (form) {
            _CoorUTM.fnSave();
        }
    }));
}
_CoorUTM.fnSave = function () {
    var dataSave = _CoorUTM.frm.serializeObject();
    console.log(dataSave);
    _CoorUTM.fnAsignar(dataSave);
    if (dataSave.RegEstadoClient == RegEstadoSigo.NEW) {
        $(':input', _CoorUTM.frm).not(':button, :submit, :reset, :hidden').val('');
        _CoorUTM.frm.find("#NUM_PARCELA").focus();
    }
}
_CoorUTM.fnInitData = function (obj) {
    //var keysFrom = Object.keys(ItemESituIAnual.objForm);
    var keysObj = Object.keys(obj);
    for (var i = 0; i < keysObj.length; i++) {
        _CoorUTM.frm.find("#" + keysObj[i]).val(obj[keysObj[i].trim()]);

    }
}
_CoorUTM.fnInitEventos = function () {
    _CoorUTM.fnConfigValidacion();
    _CoorUTM.cont.find("#btnGuardarCoordenada").click(function () {
        _CoorUTM.frm.submit();
    });
    $('.modal').on('shown.bs.modal', function () {
        _CoorUTM.frm.find("#NUM_PARCELA").focus();
    });
}
_CoorUTM.init = function (objInit) {
    _CoorUTM.frm = $("#frmCoordenadaUTM");
    _CoorUTM.cont = $("#contenedorCoordenadaUTM");
    if (typeof objInit.COD_SECUENCIAL != 'undefined') //para editar
    {
        _CoorUTM.cont.find("#h5Titulo").text("Modificando");
        _CoorUTM.fnInitData(objInit);
        _CoorUTM.frm.find("#RegEstadoClient").val("0");
    }
    _CoorUTM.fnInitEventos();
} 