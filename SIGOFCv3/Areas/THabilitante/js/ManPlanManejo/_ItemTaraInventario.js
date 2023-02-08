"use strict";
var _TaraInventario = {};
_TaraInventario.fnAsignar = function (obj) {

}
_TaraInventario.fnConfigValidacion = function () {
    _TaraInventario.frm.validate(utilSigo.fnValidate({
        rules: {
            N_ARBOL: { required: true },
            CONDICION: { required: true },
            ESTADO_FITOSAN: { required: true },
            ALTURA_ESTIMADO: { required: true },
            PESO_VAINAS_KILOGRAMOS: { required: true },
            COORDENADA_ESTE: { required: true },
            COORDENADA_NORTE: { required: true }           
        },
        messages: {
            N_ARBOL: { required: "Ingrese N° de Árbol" },
            CONDICION: { required: "Ingrese la Condición" },
            ESTADO_FITOSAN: { required: "Ingrese el Estado Fitosanitario" },
            ALTURA_ESTIMADO: { required: "Ingrese la Altura Estimada" },
            PESO_VAINAS_KILOGRAMOS: { required: "Ingrese Peso Vainas" },
            COORDENADA_ESTE: { required: "Ingrese Coordenada Este" },
            COORDENADA_NORTE: { required: "Ingrese Coordenada Norte" }            
        },
        fnSubmit: function (form) {
            _TaraInventario.fnSave();             
        }
    }));
}
_TaraInventario.fnSave = function () {
    var dataSave = _TaraInventario.frm.serializeObject();   
    console.log(dataSave);
    _TaraInventario.fnAsignar(dataSave);
    if (dataSave.RegEstadoClient == RegEstadoSigo.NEW) {
        $(':input', _TaraInventario.frm).not(':button, :submit, :reset, :hidden').val('');
        _TaraInventario.frm.find("#N_ARBOL").focus();
    }
}
_TaraInventario.fnInitData = function (obj) {
    var keysObj = Object.keys(obj);
    for (var i = 0; i < keysObj.length; i++) {
        _TaraInventario.frm.find("#" + keysObj[i]).val(obj[keysObj[i].trim()]);
    }
}
_TaraInventario.fnInitEventos = function () {
    _TaraInventario.fnConfigValidacion();
    _TaraInventario.cont.find("#btnGuardar").click(function () {
        _TaraInventario.frm.submit();
    });
    $('.modal').on('shown.bs.modal', function () {
        _TaraInventario.frm.find("#N_ARBOL").focus();
    });
}
_TaraInventario.init = function (objInit) {   
    _TaraInventario.frm = $("#frmTaraInventario");
    _TaraInventario.cont = $("#contenedorTaraInventario");     
    if (typeof objInit.COD_SECUENCIAL != 'undefined') //para editar
    {
        _TaraInventario.cont.find("#h5Titulo").text("Modificando");
        _TaraInventario.fnInitData(objInit);
        _TaraInventario.frm.find("#RegEstadoClient").val("0");

    }
    _TaraInventario.fnInitEventos();

} 