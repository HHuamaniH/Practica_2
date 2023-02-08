"use strict";
var _CNotificacion = {};

_CNotificacion.fnAsignarDatos = function (obj) { /*Se implementa en cada llamada*/ }

_CNotificacion.fnInitDataTable_Detail = function () {
    var columns_label = [], columns_data = [], options = {};

    columns_label = ["Tipo Carta", "Carta de Notificación","Título Habilitante","Modalidad", "Origen"];
    columns_data = ["MAE_CNTIPO", "NUMERO", "NUM_THABILITANTE", "MTIPO", "ESTADO_ORIGEN_TEXT"];
    /*columns_label = ["Tipo Notificación", "Notificación","Título Habilitante","Modalidad", "Plan de Manejo"];
    columns_data = ["FCTIPO", "NUM_NOTIFICACION", "NUM_THABILITANTE", "MTIPO", "NOMBRE_POA"];*/
    options = {
        page_length: initSigo.pageLengthBuscar, row_select: true, row_fnSelect: "_CNotificacion.fnAsignarDatos(this)", row_index: true
        , page_sort: true
    };
    _CNotificacion.dtCNotificacion = utilDt.fnLoadDataTable_Detail(_CNotificacion.frm.find("#tbCNotificacion"), columns_label, columns_data, options);
}

_CNotificacion.fnBuscarCNotificacion = function (bFiltroBusqueda) {
    var sFormulario = "", sCriterio = "", sValor = "", url = "";
    //var sFormulario = "", sCriterio = "", sValor = "", url = "", sTipo = "";

    sFormulario = _CNotificacion.frm.find("#hdfFormulario").val();
    //sTipo = _CNotificacion.frm.find("#hdfTipo").val();
    if (bFiltroBusqueda) {
        sCriterio = _CNotificacion.frm.find("#ddlCriterio").val();
        sValor = _CNotificacion.frm.find("#txtValor").val();
    } else {
        sCriterio = _CNotificacion.frm.find("#hdfCriterio").val();
        sValor = _CNotificacion.frm.find("#hdfValor").val();
    }

    if (sValor == "") {
        utilSigo.toastWarning("Aviso", "Ingrese Valor a Buscar");
        return false;
    }
    if (sValor.length < 3) {
        utilSigo.toastWarning("Aviso", "Ingrese el valor con más de dos caracteres");
        return false;
    }

    url = initSigo.urlControllerGeneral + "buscarCNotificacion?asFormulario=" + sFormulario + "&asCriterio=" + sCriterio + "&asValor=" + sValor;
    //url = initSigo.urlControllerGeneral + "buscarCNotificacion?asFormulario=" + sFormulario + "&asCriterio=" + sCriterio + "&asValor=" + sValor + "&asTipo=" + sTipo;

    _CNotificacion.dtCNotificacion.ajax.url(url).load(function (data) {
        if (data.success == false) {
            utilSigo.toastError("Error", data.msj);
            console.log(data.msj);
        }
    });
}

_CNotificacion.fnInit = function () {
    _CNotificacion.frm = $("#frmCNotificacion");

    _CNotificacion.frm.find("#ddlCriterio").select2({ minimumResultsForSearch: -1 });
    $('.modal').on('shown.bs.modal', function () {
        _CNotificacion.frm.find("#txtValor").focus();
    });

    _CNotificacion.frm.find("#ddlCriterio").change(function () {
        setTimeout(function () {
            $('.select2-container-active').removeClass('select2-container-active');
            _CNotificacion.frm.find("#txtValor").focus();
        }, 1);
    });

    _CNotificacion.frm.submit(function (e) {
        e.preventDefault();
        _CNotificacion.fnBuscarCNotificacion(true);
    });

    _CNotificacion.fnInitDataTable_Detail();

    _CNotificacion.frm.find("#dvFiltroBusqueda").hide();
    if (_CNotificacion.frm.find("#hdfControlInstancia").val()=="") {
        _CNotificacion.fnBuscarCNotificacion(false);
    } else {
        _CNotificacion.frm.find("#dvFiltroBusqueda").show();
    }
}