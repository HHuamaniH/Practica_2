"use strict";
var indexManIAF = {};
indexManIAF.contenedor = "contenedorManInfAutForestal";
indexManIAF.urlController = urlLocalSigo + "THabilitante/ManInformeAutoridadForestal";



 
_manGrilla.fnCreateNew = function () {
 
  
    window.location = indexManIAF.urlController + "/AddEdit" +
      "?codigoDato=" +
      "&codigoComplementario=" +
      "&tipoFrmulario=" + indexManIAF.frm.find("#hdFormulario").val() +
      "&nuevo=1";
}
 

 
//RENUNCIA_CONCESION
indexManIAF.editar = function (obj) {
    var tr = $(obj).closest('tr');
    var row = _manGrilla.dtGrillaGeneral.row(tr).data();

    window.location = indexManIAF.urlController + "/AddEdit" +
        "?codigoDato=" + encodeURIComponent(row.CODIGO) +    
        "&codigoComplementario="+
        "&tipoFrmulario=" + indexManIAF.frm.find("#hdFormulario").val() +
        "&nuevo=0";
}
 
indexManIAF.cellEdit = function () {
    return '<i class="fa fa-lg fa-pencil-square-o" style="cursor:pointer;" onclick="indexManIAF.editar(this);"></i>'
}
indexManIAF.cellContador = function (data, type, row, meta) {
    return meta.row + 1;
}
$(document).ready(function () {


    indexManIAF.frm = $("#frmAddEditManIAF");
    
    _manGrilla.columns_label = ["", "N°", "Fecha de registro", "Nro de documento de renuncia", "N° de documento de la Autoridad", "Nro THabilitante",
            "Modalidad","Titular"];
        _manGrilla.columns_data = [
            { autoWidth: true, bSortable: false, mRender: indexManIAF.cellEdit },
            { data: "NRO", visible: true, mRender: indexManIAF.cellContador },
            { data: "PARAMETRO10", visible: true },
            { data: "NUMERO", visible: true },
            { data: "PARAMETRO01", visible: true },
            { data: "PARAMETRO02", visible: true },
            { data: "PARAMETRO03", visible: true },
            { data: "PARAMETRO04", visible: true },
            { data: "CODIGO", visible: false }
        ];
  
    _manGrilla.url = initSigo.urlControllerGeneral + "/listarBusqueda";
    _manGrilla.paramInit = { busFormulario: indexManIAF.frm.find("#hdFormulario").val(), busCriterio: "TODOS", busValor: "" };
    _manGrilla.isPaging = false;
    _manGrilla.fnLoadViewGeneral(indexManIAF.contenedor);
});