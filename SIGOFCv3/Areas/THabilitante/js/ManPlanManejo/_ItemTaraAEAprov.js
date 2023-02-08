var _ItemTaraAEAprov = {};
_ItemTaraAEAprov.fnAsignar = function (obj) {

}
_ItemTaraAEAprov.fnConfigValidacion = function () {
    _ItemTaraAEAprov.frm.validate(utilSigo.fnValidate({
        rules: {
            NUM_PARCELA: { required: true },
            NUM_ARBOLES_APROVE: { required: true },
            NUM_ARBOLES_NO_APROVE: { required: true },
            PRODUCCION_ANUAL_PROMEDIO: { required: true },
            PESO_ESTIMADO_VAINAS: { required: true }
        },
        messages: {
            NUM_PARCELA: { required: "Ingrese la Parcela" },
            NUM_ARBOLES_APROVE: { required: "Ingrese el N° de árboles en edad de aprovechamiento" },
            NUM_ARBOLES_NO_APROVE: { required: "Ingrese el N° de árboles que no estan en edad de aprovechamiento" },
            PRODUCCION_ANUAL_PROMEDIO: { required: "Ingrese la producción anual promedio" },
            PESO_ESTIMADO_VAINAS: { required: "Ingrese peso estimado" }
        },
        fnSubmit: function (form) {
            _ItemTaraAEAprov.fnSave();
        }
    }));
}
_ItemTaraAEAprov.fnSave = function () {
    var dataSave = _ItemTaraAEAprov.frm.serializeObject();
    console.log(dataSave);
    _ItemTaraAEAprov.fnAsignar(dataSave);
    if (dataSave.RegEstadoClient == RegEstadoSigo.NEW) {
        $(':input', _ItemTaraAEAprov.frm).not(':button, :submit, :reset, :hidden').val('');
        _ItemTaraAEAprov.frm.find("#NUM_PARCELA").focus();
    }
}
_ItemTaraAEAprov.fnInitData = function (obj) {
    //var keysFrom = Object.keys(ItemESituIAnual.objForm);
    var keysObj = Object.keys(obj);
    for (var i = 0; i < keysObj.length; i++) {
        _ItemTaraAEAprov.frm.find("#" + keysObj[i]).val(obj[keysObj[i].trim()]);

    }
}
_ItemTaraAEAprov.fnInitEventos = function () {
    _ItemTaraAEAprov.fnConfigValidacion();
    _ItemTaraAEAprov.cont.find("#btnGuardar").click(function () {
        _ItemTaraAEAprov.frm.submit();
    });
    $('.modal').on('shown.bs.modal', function () {
        _ItemTaraAEAprov.frm.find("#NUM_PARCELA").focus();
    });
}
_ItemTaraAEAprov.init = function (objInit) {
    _ItemTaraAEAprov.frm = $("#frmTaraAEAprov");
    _ItemTaraAEAprov.cont = $("#contenedorTaraAEAprov");
    if (typeof objInit.COD_SECUENCIAL != 'undefined') //para editar
    {
        _ItemTaraAEAprov.cont.find("#h5Titulo").text("Modificando");
        _ItemTaraAEAprov.fnInitData(objInit);
        _ItemTaraAEAprov.frm.find("#RegEstadoClient").val("0");
    }
    _ItemTaraAEAprov.fnInitEventos();
} 