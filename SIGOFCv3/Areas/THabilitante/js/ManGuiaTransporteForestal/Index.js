"use strict";
var indexManGuiaTransForestal = {};
indexManGuiaTransForestal.contenedor = "divManGuiaTransForestal";
indexManGuiaTransForestal.urlController = urlLocalSigo + "THabilitante/ManGuiaTransporteForestal";

 
_manGrilla.fnCreateNew = function () {
 
  
    window.location = indexManGuiaTransForestal.urlController + "/AddEdit" +
      "?codigoDato=" +
      "&codigoComplementario=" +
      "&tipoFrmulario=" + indexManGuiaTransForestal.frm.find("#hdFormulario").val() +
      "&nuevo=1";
}
 

 
//RENUNCIA_CONCESION
indexManGuiaTransForestal.editar = function (obj) {
    var tr = $(obj).closest('tr');
    var row = _manGrilla.dtGrillaGeneral.row(tr).data();

    window.location = indexManGuiaTransForestal.urlController + "/AddEdit" +
        "?codigoDato=" + encodeURIComponent(row.CODIGO) +    
        "&codigoComplementario="+
        "&tipoFrmulario=" + indexManGuiaTransForestal.frm.find("#hdFormulario").val() +
        "&nuevo=0";
}
 
indexManGuiaTransForestal.cellEdit = function () {
    return '<i class="fa fa-lg fa-pencil-square-o" style="cursor:pointer;" onclick="indexManGuiaTransForestal.editar(this);"></i>'
}

$(document).ready(function () {

    indexManGuiaTransForestal.frm = $("#frmIndexManGuiaTransForestal");
    _manGrilla.columns_label = ["", "N°", "Fecha de registro", "Número Guía", "Nombre Guía", "N° T. Habilitante",
            "Titular", "Fecha Expedición", "POA", "Zafra", "Destinatario"];
    /* case "GUIA_TRANSPORTE":
                  
 */
        _manGrilla.columns_data = [
            { autoWidth: true, bSortable: false, mRender: indexManGuiaTransForestal.cellEdit },
            { data: "NRO", mRender: utilDt.countRowDT },
            { data: "PARAMETRO10" },
            { data: "NUMERO" },
            { data: "PARAMETRO01"},          
            { data: "PARAMETRO03"},
            { data: "PARAMETRO04"},
            { data: "PARAMETRO02"},
            { data: "PARAMETRO06"},
            { data: "PARAMETRO07"},
            { data: "PARAMETRO05"}
 
        ];
  
    _manGrilla.url = initSigo.urlControllerGeneral + "/listarBusqueda";
    _manGrilla.paramInit = { busFormulario: indexManGuiaTransForestal.frm.find("#hdFormulario").val(), busCriterio: "TODOS", busValor: "" };
    _manGrilla.isPaging = false;
    _manGrilla.fnLoadViewGeneral(indexManGuiaTransForestal.contenedor);
});