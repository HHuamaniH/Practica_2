"use strict";
var _RDQuinquenal = {};
_RDQuinquenal.url = urlLocalSigo + "Supervision/ManInformeQuinquenal/buscarRDQuinquenal?"; 
_RDQuinquenal.fnAsignarDatos = function (obj) { /*se implementa en cada llamada*/ }

_RDQuinquenal.fnBuscarRDQuinquenal = function ()
{
    var valBuscar = _RDQuinquenal.frm.find("#txtbusRDQ").val().trim();
    var url_ = _RDQuinquenal.url + "asBusValor=" + valBuscar;
    if (valBuscar == "") {
        utilSigo.toastWarning("Aviso", "Ingrese el dato a buscar");
        return false;
    }
    if (valBuscar.length < 3) {
        utilSigo.toastWarning("Aviso", "El dato a buscar debe ser mayor a dos caracteres");
        return false;
    }
    //url = initSigo.urlControllerGeneral + "buscarRDQuinquenal?asBusValor=" + valBuscar;
    //url = initSigo.urlControllerGeneral + "buscarCNotificacion?asFormulario=" + sFormulario + "&asCriterio=" + sCriterio + "&asValor=" + sValor + "&asTipo=" + sTipo;

    _RDQuinquenal.dtRDQuinquenal.ajax.url(url_).load(function (data) {
        if (data.success == false) {
            utilSigo.toastError("Error", data.msj);
            console.log(data.msj);
        }
    });

}

_RDQuinquenal.fnInitEventos = function () {
    _RDQuinquenal.frm.find("#btnItemBuscarRD").click(function () {
        _RDQuinquenal.fnBuscarRDQuinquenal();
    });
    _RDQuinquenal.frm.submit(function (e) {
        _RDQuinquenal.fnBuscarRDQuinquenal();
        e.preventDefault();        
    });
}

_RDQuinquenal.fnInitDataTable_Detail = function () {
    var columns_label = ["Nro de R.D. Quinquenal", "Tipo Documento", "Nro_THabilitante"];
    var columns_data = ["NUM_RESOLUCION", "TIP_FISCALIZA", "TITULO"];
    var options = { page_length: initSigo.pageLengthBuscar, row_select: true, row_fnSelect: "_RDQuinquenal.fnAsignarDatos(this)", row_index: true };
    _RDQuinquenal.dtRDQuinquenal = utilDt.fnLoadDataTable_Detail(_RDQuinquenal.frm.find("#tbBuscarRDQuinquenal"), columns_label, columns_data, options);
}


_RDQuinquenal.fnInit = function () {   

    $('[data-toggle="tooltip"]').tooltip();
    _RDQuinquenal.frm = $("#frmBuscarRDQuinquenal");

    _RDQuinquenal.frm.find("#cboCriterio").select2({ minimumResultsForSearch: -1 });
    $('.modal').on('shown.bs.modal', function () {
        _RDQuinquenal.frm.find("#txtbusRDQ").focus();
    });
    _RDQuinquenal.fnInitDataTable_Detail();
    _RDQuinquenal.fnInitEventos();
}