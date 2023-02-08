"use strict";
var _DenunciaSITD = {};

_DenunciaSITD.fnAsignarDatos = function (obj) { /*Se implementa en cada llamada*/ }

_DenunciaSITD.fnInitDataTable_Detail = function () {
    var columns_label = [], columns_data = [], options = {};

    columns_label = ["Documento Denuncia", "Profesional Responsable"];
    columns_data = ["NUM_DREFERENCIA", "PROFESIONAL_ITECNICO"];
    options = {
        page_length: initSigo.pageLengthBuscar, row_select: true, row_fnSelect: "_DenunciaSITD.fnAsignarDatos(this)", row_index: true
        , page_sort: true
    };
    _DenunciaSITD.dtDenunciaSITD = utilDt.fnLoadDataTable_Detail(_DenunciaSITD.frm.find("#tbDenunciaSITD"), columns_label, columns_data, options);
}

_DenunciaSITD.fnBuscarDenunciaSITD = function () {
    var sCriterio = "", sValor = "", url = "";

    sCriterio = _DenunciaSITD.frm.find("#ddlCriterio").val();
    sValor = _DenunciaSITD.frm.find("#txtValor").val();

    if (sValor == "") {
        utilSigo.toastWarning("Aviso", "Ingrese Valor a Buscar");
        return false;
    }
    if (sValor.length < 3) {
        utilSigo.toastWarning("Aviso", "Ingrese el valor con más de dos caracteres");
        return false;
    }

    url = initSigo.urlControllerGeneral + "buscarDenunciaSITD?asCriterio=" + sCriterio + "&asValor=" + sValor;

    _DenunciaSITD.dtDenunciaSITD.ajax.url(url).load(function (data) {
        if (data.success == false) {
            utilSigo.toastError("Error", data.msj);
            console.log(data.msj);
        }
    });
}

_DenunciaSITD.fnInit = function () {
    _DenunciaSITD.frm = $("#frmDenunciaSITD");

    _DenunciaSITD.frm.find("#ddlCriterio").select2({ minimumResultsForSearch: -1 });
    $('.modal').on('shown.bs.modal', function () {
        _DenunciaSITD.frm.find("#txtValor").focus();
    });

    _DenunciaSITD.frm.find("#ddlCriterio").change(function () {
        setTimeout(function () {
            $('.select2-container-active').removeClass('select2-container-active');
            _DenunciaSITD.frm.find("#txtValor").focus();
        }, 1);
    });

    _DenunciaSITD.frm.submit(function (e) {
        e.preventDefault();
        _DenunciaSITD.fnBuscarDenunciaSITD(true);
    });

    _DenunciaSITD.fnInitDataTable_Detail();
}