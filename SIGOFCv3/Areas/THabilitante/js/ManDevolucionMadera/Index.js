"use strict";
var indexDM = {};
indexDM.contenedor = "contenedorDevolucionMadera";
indexDM.urlController = urlLocalSigo + "THabilitante/ManDevolucionMadera";

 
_manGrilla.setParameterTH = function () {
    vpTHabilitante.url = initSigo.urlControllerGeneral + "/buscarTH?";

    vpTHabilitante.columns = [
    {
        autoWidth: true, bSortable: false, data: "num", mRender: function (data, type, row) {
            return '<i class="fa fa-lg fa-check" style="cursor: pointer;color:forestgreen;" onclick="vpTHabilitante.fnAsignarDatos(this);"></i>';
        }
    },
    {
            autoWidth: true, mRender: function (data, type, row, meta) {
            return meta.row + 1;
        }
    },
    { data: "PARAMETRO01", autoWidth: true },
    { data: "NUMERO", autoWidth: true },
    { data: "PARAMETRO02", autoWidth: true },  
    { data: "CODIGO", visible: false },
    { data: "PARAMETRO03", visible: false },
    { data: "PARAMETRO04", visible: false },
    { data: "PARAMETRO05", visible: false },
    { data: "PARAMETRO06", visible: false }
    ];
    vpTHabilitante.fnAsignarDatos = function (obj) {
        var tr = $(obj).closest("tr");
        var row = vpTHabilitante.dtTituloHabilitante.row(tr).data();
        console.log(row);
        var codigoComplementario = row.PARAMETRO01 + "|" +
            row.NUMERO + "|" +
            row.PARAMETRO02.replace(/[|]/g, ";") + "|" +
            row.PARAMETRO03 + "|" +
            row.PARAMETRO04 + "|" +
            row.PARAMETRO05 + "|" +
            row.PARAMETRO06;

        window.location = indexDM.urlController + "/AddEdit" +
            "?codigoDato=" + encodeURIComponent(row.CODIGO) +
            "&codigoComplementario=" + encodeURIComponent(codigoComplementario) +
            "&tipoFrmulario=" + indexDM.contenedorDevolucionMadera.find("#hdFormulario").val() +
            "&nuevo=1";
    }
    vpTHabilitante.columns_label = [ "","N°", "Modalidad", "Número", "Titular (Apellidos y Nombres)"];

}
_manGrilla.fnCreateNew = function () {
 
    $.ajax({
        url: initSigo.urlControllerGeneral + "/_THabilitante",
        type: 'GET',
        data: { hdfFormulario: indexDM.contenedorDevolucionMadera.find("#hdFormulario").val() },
        dataType: 'html',
        success: function (data) {
            utilSigo.unblockUIGeneral();
            var modalContenedor = $("#contenedorBuscarModalDM");
            modalContenedor.html(data);
            utilSigo.modalDraggable(modalContenedor, '.modal-header');
            modalContenedor.modal({ keyboard: true, backdrop: 'static' });

            _manGrilla.setParameterTH();
            vpTHabilitante.fnInit();
        },
        beforeSend: function () {
            utilSigo.blockUIGeneral();
        },
        error: function (jqXHR, error, errorThrown) {
            utilSigo.unblockUIGeneral();
            utilSigo.toastError("Error", initSigo.MessageError);
            console.log(jqXHR.responseText);
        }
    });
}
 

indexDM.editar = function (obj) {
    var tr = $(obj).closest('tr');
    var row = _manGrilla.dtGrillaGeneral.row(tr).data();
    window.location = indexDM.urlController + "/AddEdit" +
        "?codigoDato=" + encodeURIComponent(row.CODIGO) +
        "&codigoComplementario=" + encodeURIComponent(row.PARAMETRO01) +
        "&tipoFrmulario=" + indexDM.contenedorDevolucionMadera.find("#hdFormulario").val() +
        "&nuevo=0";
}
/**RENUNCIA_CONCESION
 indexRC.editar = function (obj) {
    var tr = $(obj).closest('tr');
    var row = _manGrilla.dtGrillaGeneral.row(tr).data();
    window.location = indexDM.urlController + "/AddEdit" +
        "?codigoDato=" + encodeURIComponent(row.CODIGO) +    
        "&tipoFrmulario=" + indexDM.contenedorDevolucionMadera.find("#hdFormulario").val() +
        "&nuevo=0";
}
 */
indexDM.cellEdit = function () {
    return '<i class="fa fa-lg fa-pencil-square-o" style="cursor:pointer;" onclick="indexDM.editar(this);"></i>'
}
indexDM.cellContador = function (data, type, row, meta) {
    return meta.row + 1;
}
$(document).ready(function () {

    // indexPM.fnIniciarEventos();
     

    indexDM.contenedorDevolucionMadera = $("#frmAddEditDM");
    _manGrilla.columns_label = ["", "N°", "Fecha de registro", "Nro Resolución", "Titular", "Nro THabilitante"];
    _manGrilla.columns_data = [
        { autoWidth: true, bSortable: false, mRender: indexDM.cellEdit },
        { data: "NRO", visible: true, mRender: indexDM.cellContador },
        { data: "PARAMETRO10", visible: true },
        { data: "NUMERO", visible: true },
        { data: "PARAMETRO07", visible: true },
        { data: "PARAMETRO06", visible: true },
        { data: "CODIGO", visible: false },
    ];




    /*RENUNCIA_CONCESION
          _manGrilla.columns_label = ["", "N°", "Fecha de registro", "Nro de documento de renuncia", "N° de documento de la Autoridad", "Nro THabilitante",
            "Modalidad","Titular"];
        _manGrilla.columns_data = [
            { autoWidth: true, bSortable: false, mRender: indexDM.cellEdit },
            { data: "NRO", visible: true, mRender: indexDM.cellContador },
            { data: "PARAMETRO10", visible: true },
            { data: "NUMERO", visible: true },
            { data: "PARAMETRO01", visible: true },
            { data: "PARAMETRO02", visible: true },
            { data: "PARAMETRO03", visible: true },
            { data: "PARAMETRO04", visible: true }
        ];
     */
    _manGrilla.url = initSigo.urlControllerGeneral + "/listarBusqueda";
    _manGrilla.paramInit = { busFormulario: indexDM.contenedorDevolucionMadera.find("#hdFormulario").val(), busCriterio: "TODOS", busValor: "" };
    _manGrilla.isPaging = false;
    _manGrilla.fnLoadViewGeneral(indexDM.contenedor);
});