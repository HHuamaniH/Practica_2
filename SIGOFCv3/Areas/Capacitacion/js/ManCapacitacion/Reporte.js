
"use strict";
var _reporte = {};

/*GENERAL*/
_reporte.fnSubmitForm = function () { /*Implementar de acuerdo al reporte consultado*/ }
/*******************Fin General********************/

/*MODAL's de Consulta*/
_reporte.modal_persona_change = function () { /*Implementar de acuerdo al reporte consultado*/ }
_reporte.modal_thabilitante_change = function () { /*Implementar de acuerdo al reporte consultado*/ }

_reporte.fnBuscarPersona = function () {
    var url = urlLocalSigo + "General/Controles/_BuscarPersonaGeneral";
    var option = { url: url, type: 'GET', datos: { asBusGrupo: "PERSONA", asCodPTipo: "TODOS", asTipoPersona: "N" }, divId: "mdlBuscarPersona" };
    utilSigo.fnOpenModal(option, function () {
        _bPerGen.fnAsignarDatos = function (obj) {
            if (obj != null && obj != "") {
                var data = _bPerGen.dtBuscarPerona.row($(obj).parents('tr')).data();
                _reporte.frm.find("#hdfCodPersona").val(data["COD_PERSONA"]);
                _reporte.frm.find("#lblFiltroPersona").val(data["PERSONA"]);
                utilSigo.fnCloseModal("mdlBuscarPersona");
                _reporte.modal_persona_change();
            }
        }
        _bPerGen.fnInit();
    }, function () { if (!utilSigo.fnValidateForm_HideControl(_reporte.frm, _reporte.frm.find('#hdfCodPersona'), _reporte.frm.find('#iconFiltroPersona'), false)) return false; });
}

_reporte.modaViewTHabilitante = function () {
    var url = urlLocalSigo + "General/Controles/_THabilitante";
    var option = { url: url, type: 'GET', datos: { hdfFormulario: "TITULO_HABILITANTE" }, divId: "mdlParticipanteTHabilitante" };
    utilSigo.fnOpenModal(option, function () {
        vpTHabilitante.fnAsignarDatos = function (obj) {
            if (obj != null && obj != "") {
                var data = vpTHabilitante.dtTituloHabilitante.row($(obj).parents('tr')).data();
                _reporte.frm.find("#hdfCodTHabilitante").val(data["CODIGO"]);
                _reporte.frm.find("#lblFiltroTHabilitante").val(data["NUMERO"]);
                $("#mdlParticipanteTHabilitante").modal('hide');
                _reporte.modal_thabilitante_change();
            }
        }

        vpTHabilitante.fnInit_v2();
    }, function () { if (!utilSigo.fnValidateForm_HideControl(_reporte.frm, _reporte.frm.find('#hdfCodTHabilitante'), _reporte.frm.find('#iconFiltroTHabilitante'), false)) return false; });
}
/*******************Fin Modal**********************/

/*FILTROS Reporte*/
_reporte.filter_ddlTipoFiltroId_change = function () { /*Implementar de acuerdo al reporte consultado*/ }
_reporte.filter_lstChkAnioId_change = function () { /*Implementar de acuerdo al reporte consultado*/ }
_reporte.filter_lstChkMesId_change = function () { /*Implementar de acuerdo al reporte consultado*/ }
_reporte.filter_lstChkOdId_change = function () { /*Implementar de acuerdo al reporte consultado*/ }
_reporte.filter_lstChkTipCapacitacionId_change = function () { /*Implementar de acuerdo al reporte consultado*/ }
_reporte.filter_ddlOtrosEventosId_change = function () { /*Implementar de acuerdo al reporte consultado*/ }
_reporte.filter_ddlTHCapacitadosId_change = function () { /*Implementar de acuerdo al reporte consultado*/ }
_reporte.filter_ddlSumMetPoiId_change = function () { /*Implementar de acuerdo al reporte consultado*/ }
_reporte.filter_ddlEntFinanciaId_change = function () { /*Implementar de acuerdo al reporte consultado*/ }
_reporte.filter_ddlComunidadNativaId_change = function () { /*Implementar de acuerdo al reporte consultado*/ }
_reporte.filter_ddlEtniaId_change = function () { /*Implementar de acuerdo al reporte consultado*/ }
_reporte.filter_lstChkPublicoObjetivoId_change = function () { /*Implementar de acuerdo al reporte consultado*/ }
_reporte.filter_lstChkDepartamentoId_change = function () { /*Implementar de acuerdo al reporte consultado*/ }
_reporte.filter_lstChkInstitucionId_change = function () { /*Implementar de acuerdo al reporte consultado*/ }

_reporte.filterShowControlTipoFiltro = function () {
    _reporte.frm.find("#dvTipoFiltro_Persona").hide();
    _reporte.frm.find("#dvTipoFiltro_THabilitante").hide();
    _reporte.frm.find("#dvTipoFiltro_ComunidadNativa").hide();
    _reporte.frm.find("#dvTipoFiltro_Etnia").hide();
    _reporte.frm.find("#dvTipoFiltro_ChkInstitucion").hide();
    _reporte.filterInstitucionClearAllCheck();

    switch (_reporte.frm.find("#ddlTipoFiltroId").val()) {
        case "PERSONA":
            _reporte.frm.find("#lblFiltroTHabilitante").val("");
            _reporte.frm.find("#hdfCodTHabilitante").val("");
            _reporte.frm.find("#ddlComunidadNativaId").select2("val", ["0000000"]);
            _reporte.frm.find("#ddlEtniaId").select2("val", ["0000000"]);
            _reporte.frm.find("#dvTipoFiltro_Persona").show();
            break;
        case "THABILITANTE":
            _reporte.frm.find("#lblFiltroPersona").val("");
            _reporte.frm.find("#hdfCodPersona").val("");
            _reporte.frm.find("#ddlComunidadNativaId").select2("val", ["0000000"]);
            _reporte.frm.find("#ddlEtniaId").select2("val", ["0000000"]);
            _reporte.frm.find("#dvTipoFiltro_THabilitante").show();
            break;
        case "CCNN":
            _reporte.frm.find("#lblFiltroTHabilitante").val("");
            _reporte.frm.find("#hdfCodTHabilitante").val("");
            _reporte.frm.find("#lblFiltroPersona").val("");
            _reporte.frm.find("#hdfCodPersona").val("");
            _reporte.frm.find("#ddlEtniaId").select2("val", ["0000000"]);
            _reporte.frm.find("#dvTipoFiltro_ComunidadNativa").show();
            break;
        case "ETNIA":
            _reporte.frm.find("#lblFiltroTHabilitante").val("");
            _reporte.frm.find("#hdfCodTHabilitante").val("");
            _reporte.frm.find("#lblFiltroPersona").val("");
            _reporte.frm.find("#hdfCodPersona").val("");
            _reporte.frm.find("#ddlComunidadNativaId").select2("val", ["0000000"]);
            _reporte.frm.find("#dvTipoFiltro_Etnia").show();
            break;
        case "INSTITUCION":
            _reporte.frm.find("#lblFiltroTHabilitante").val("");
            _reporte.frm.find("#hdfCodTHabilitante").val("");
            _reporte.frm.find("#lblFiltroPersona").val("");
            _reporte.frm.find("#hdfCodPersona").val("");
            _reporte.frm.find("#ddlComunidadNativaId").select2("val", ["0000000"]);
            _reporte.frm.find("#dvTipoFiltro_ChkInstitucion").show();
            break;
    }
}
_reporte.filterAnioClearAllCheck = function () {
    for (var i = 1; i <= _reporte.frm.find("[id*=lstChkAnio]").length; i++) {
        if (i % 2 == 0)
            _reporte.frm.find("[id*=lstChkAnio]")[i - 1].checked = false;
    }
}
_reporte.filterAnioGetAllCheck = function () {
    var selectAnio = "";
    for (var i = 1; i <= _reporte.frm.find("[id*=lstChkAnio]").length; i++) {
        if (i % 2 == 0) {
            if (_reporte.frm.find("[id*=lstChkAnio]")[i - 1].checked) {
                selectAnio += selectAnio == "" ? "" : ",";
                selectAnio += _reporte.frm.find("[id*=lstChkAnio]")[i - 2].value;
            }
        }
    }
    _reporte.frm.find("#lstChkAnioId").val(selectAnio);
}
_reporte.filterInstitucionClearAllCheck = function () {
    for (var i = 1; i <= _reporte.frm.find("[id*=lstChkInstitucion]").length; i++) {
        if (i % 2 == 0)
            _reporte.frm.find("[id*=lstChkInstitucion]")[i - 1].checked = false;
    }
}
_reporte.filterInstitucionGetAllCheck = function () {
    var selectAnio = "";
    for (var i = 1; i <= _reporte.frm.find("[id*=lstChkInstitucion]").length; i++) {
        if (i % 2 == 0) {
            if (_reporte.frm.find("[id*=lstChkInstitucion]")[i - 1].checked) {
                selectAnio += selectAnio == "" ? "" : ",";
                selectAnio += _reporte.frm.find("[id*=lstChkInstitucion]")[i - 2].value;
            }
        }
    }
    _reporte.frm.find("#lstChkInstitucionId").val(selectAnio);
}
_reporte.filterMesGetAllCheck = function () {
    var selectMes = "";
    for (var i = 1; i <= _reporte.frm.find("[id*=lstChkMes]").length; i++) {
        if (i % 2 == 0) {
            if (_reporte.frm.find("[id*=lstChkMes]")[i - 1].checked) {
                selectMes += selectMes == "" ? "" : ",";
                selectMes += _reporte.frm.find("[id*=lstChkMes]")[i - 2].value;
            }
        }
    }
    _reporte.frm.find("#lstChkMesId").val(selectMes);
}
_reporte.filterOdGetAllCheck = function () {
    var selectOd = "";
    for (var i = 1; i <= _reporte.frm.find("[id*=lstChkOd]").length; i++) {
        if (i % 2 == 0) {
            if (_reporte.frm.find("[id*=lstChkOd]")[i - 1].checked) {
                selectOd += selectOd == "" ? "" : ",";
                selectOd += _reporte.frm.find("[id*=lstChkOd]")[i - 2].value;
            }
        }
    }
    _reporte.frm.find("#lstChkOdId").val(selectOd);
}
_reporte.filterPObjetivoGetAllCheck = function () {
    var selectPo = "";
    for (var i = 1; i <= _reporte.frm.find("[id*=lstChkPObjetivoGroup]").length; i++) {
        if (i % 2 == 0) {
            if (_reporte.frm.find("[id*=lstChkPObjetivoGroup]")[i - 1].checked) {
                selectPo += selectPo == "" ? "" : ",";
                selectPo += _reporte.frm.find("[id*=lstChkPObjetivoGroup]")[i - 2].value;
            }
        }
    }
    _reporte.frm.find("#lstChkPublicoObjetivoId").val(selectPo);
}
_reporte.filterTipoCapacitacionGetAllCheck = function () {
    var selectTipCap = "";
    for (var i = 1; i <= _reporte.frm.find("[id*=lstChkTipCapacitacion]").length; i++) {
        if (i % 2 == 0) {
            if (_reporte.frm.find("[id*=lstChkTipCapacitacion]")[i - 1].checked) {
                selectTipCap += selectTipCap == "" ? "" : ",";
                selectTipCap += _reporte.frm.find("[id*=lstChkTipCapacitacion]")[i - 2].value;
            }
        }
    }
    _reporte.frm.find("#lstChkTipCapacitacionId").val(selectTipCap);
}
_reporte.filterDepartamentoGetAllCheck = function () {
    var select = "";
    for (var i = 1; i <= _reporte.frm.find("[id*=lstChkDepartamento]").length; i++) {
        if (i % 2 == 0) {
            if (_reporte.frm.find("[id*=lstChkDepartamento]")[i - 1].checked) {
                select += select == "" ? "" : ",";
                select += _reporte.frm.find("[id*=lstChkDepartamento]")[i - 2].value;
            }
        }
    }
    _reporte.frm.find("#lstChkDepartamentoId").val(select);
}
_reporte.filterValidate = function () {
    var sShow = "none";

    sShow = _reporte.frm.find("#dvTipoFiltro")[0].style.display;
    if (sShow == "") {
        if (_reporte.frm.find("#ddlTipoFiltroId").val()=="0000000") {
            utilSigo.toastWarning("Aviso", "Seleccione el filtro a aplicar"); return false;
        }
    }
    sShow = _reporte.frm.find("#dvTipoFiltro_Persona")[0].style.display;
    if (sShow=="") {
        if (!utilSigo.fnValidateForm_HideControl(_reporte.frm, _reporte.frm.find('#hdfCodPersona'), _reporte.frm.find('#iconFiltroPersona'), false)) return false;
    }
    sShow = _reporte.frm.find("#dvTipoFiltro_THabilitante")[0].style.display;
    if (sShow=="") {
        if (!utilSigo.fnValidateForm_HideControl(_reporte.frm, _reporte.frm.find('#hdfCodTHabilitante'), _reporte.frm.find('#iconFiltroTHabilitante'), false)) return false;
    }
    sShow = _reporte.frm.find("#dvTipoFiltro_ComunidadNativa")[0].style.display;
    if (sShow == "") {
        if (_reporte.frm.find("#ddlComunidadNativaId").val()=="0000000") {
            utilSigo.toastWarning("Aviso", "Seleccione la comunidad nativa a consultar"); return false;
        }
    }
    sShow = _reporte.frm.find("#dvTipoFiltro_Etnia")[0].style.display;
    if (sShow == "") {
        if (_reporte.frm.find("#ddlEtniaId").val() == "0000000") {
            utilSigo.toastWarning("Aviso", "Seleccione la etnia a consultar"); return false;
        }
    }
    sShow = _reporte.frm.find("#dvFiltroAnio")[0].style.display;
    if (sShow == "") {
        if (_reporte.frm.find("#lstChkAnioId").val() == "") {
            utilSigo.toastWarning("Aviso", "Seleccione el año a consultar"); return false;
        }
    }
    sShow = _reporte.frm.find("#dvFiltroMes")[0].style.display;
    if (sShow == "") {
        if (_reporte.frm.find("#lstChkMesId").val() == "") {
            utilSigo.toastWarning("Aviso", "Seleccione los meses a consultar"); return false;
        }
    }
    sShow = _reporte.frm.find("#dvFiltroOD")[0].style.display;
    if (sShow == "") {
        if (_reporte.frm.find("#lstChkOdId").val() == "") {
            utilSigo.toastWarning("Aviso", "Seleccione las oficinas desconcentradas a consultar"); return false;
        }
    }
    sShow = _reporte.frm.find("#dvFiltroTipoCapacitacion")[0].style.display;
    if (sShow == "") {
        if (_reporte.frm.find("#lstChkTipCapacitacionId").val() == "") {
            utilSigo.toastWarning("Aviso", "Seleccione los tipos de capacitación a consultar"); return false;
        }
    }
    sShow = _reporte.frm.find("#dvFiltroPublicoObjectivo")[0].style.display;
    if (sShow == "") {
        if (_reporte.frm.find("#lstChkPublicoObjetivoId").val() == "") {
            utilSigo.toastWarning("Aviso", "Seleccione el público objetivo a consultar"); return false;
        }
    }
    sShow = _reporte.frm.find("#dvFiltroDepartamento")[0].style.display;
    if (sShow == "") {
        if (_reporte.frm.find("#lstChkDepartamentoId").val() == "") {
            utilSigo.toastWarning("Aviso", "Seleccione los departamentos a consultar"); return false;
        }
    }

    return true;
}
_reporte.filterEvent = function () {
    //Mostrar y ocultar filtros
    $("#dvHideFiltro").click(function () {
        $("#dvHideFiltro").hide();
        $("#dvShowFiltro").show();
        $("#dvFiltro").hide();
    });
    $("#dvShowFiltro").click(function () {
        $("#dvHideFiltro").show();
        $("#dvShowFiltro").hide();
        $("#dvFiltro").show();
    });
    //Filtro: Tipo Filtro
    _reporte.filterShowControlTipoFiltro();
    _reporte.frm.find("#ddlTipoFiltroId").change(function () {
        _reporte.filter_ddlTipoFiltroId_change();
        _reporte.filterShowControlTipoFiltro();
    });
    //Filtro: Comunidad Nativa
    _reporte.frm.find("#ddlComunidadNativaId").change(function () {
        _reporte.filter_ddlComunidadNativaId_change();
    });
    //Filtro: Etnia
    _reporte.frm.find("#ddlEtniaId").change(function () {
        _reporte.filter_ddlEtniaId_change();
    });
    //Filtro: Institución
    _reporte.frm.find("#chkInstitucionAll").change(function () {
        for (var i = 1; i <= _reporte.frm.find("[id*=lstChkInstitucion]").length; i++) {
            if (i % 2 == 0)
                _reporte.frm.find("[id*=lstChkInstitucion]")[i - 1].checked = $(this).is(":checked");
        }
        _reporte.filterInstitucionGetAllCheck();
        _reporte.filter_lstChkInstitucionId_change();
    });
    _reporte.frm.find("[id*=lstChkInstitucion]").change(function () {
        var isChecked = $(this).is(":checked");
        _reporte.filterInstitucionClearAllCheck();
        if (isChecked) {
            $(this).prop("checked", "checked");
        } else {
            $(this).prop("checked", "");
            _reporte.frm.find("#chkInstitucionAll").prop("checked", "");
        }

        _reporte.filterInstitucionGetAllCheck();
        _reporte.filter_lstChkInstitucionId_change();
    });
    //Filtro: Año
    _reporte.frm.find("#chkAnioAll").change(function () {
        for (var i = 1; i <= _reporte.frm.find("[id*=lstChkAnio]").length; i++) {
            if (i % 2 == 0)
                _reporte.frm.find("[id*=lstChkAnio]")[i - 1].checked = $(this).is(":checked");
        }
        _reporte.filterAnioGetAllCheck();
        _reporte.filter_lstChkAnioId_change();
    });
    _reporte.frm.find("[id*=lstChkAnio]").change(function () {
        var isChecked = $(this).is(":checked");
        _reporte.filterAnioClearAllCheck();
        if (isChecked) {
            $(this).prop("checked", "checked");
        } else {
            $(this).prop("checked", "");
            _reporte.frm.find("#chkAnioAll").prop("checked", "");
        }

        _reporte.filterAnioGetAllCheck();
        _reporte.filter_lstChkAnioId_change();
    });
    //Filtro: Mes
    _reporte.frm.find("#chkMesAll").change(function () {
        for (var i = 1; i <= _reporte.frm.find("[id*=lstChkMes]").length; i++) {
            if (i % 2 == 0)
                _reporte.frm.find("[id*=lstChkMes]")[i - 1].checked = $(this).is(":checked");
        }
        _reporte.filterMesGetAllCheck();
        _reporte.filter_lstChkMesId_change();
    });
    _reporte.frm.find("[id*=lstChkMes]").change(function () {
        _reporte.filterMesGetAllCheck();
        _reporte.filter_lstChkMesId_change();
        
        if (!$(this).is(":checked")) _reporte.frm.find("#chkMesAll").prop("checked", "");
    });
    //Filtro: OD
    _reporte.frm.find("#chkOdAll").change(function () {
        for (var i = 1; i <= _reporte.frm.find("[id*=lstChkOd]").length; i++) {
            if (i % 2 == 0)
                _reporte.frm.find("[id*=lstChkOd]")[i - 1].checked = $(this).is(":checked");
        }
        _reporte.filterOdGetAllCheck();
        _reporte.filter_lstChkOdId_change();
    });
    _reporte.frm.find("[id*=lstChkOd]").change(function () {
        _reporte.filterOdGetAllCheck();
        _reporte.filter_lstChkOdId_change();

        if (!$(this).is(":checked")) _reporte.frm.find("#chkOdAll").prop("checked", "");
    });
    //Filtro: Tipo Capacitación
    _reporte.frm.find("#chkTipCapacitacionAll").change(function () {
        for (var i = 1; i <= _reporte.frm.find("[id*=lstChkTipCapacitacion]").length; i++) {
            if (i % 2 == 0)
                _reporte.frm.find("[id*=lstChkTipCapacitacion]")[i - 1].checked = $(this).is(":checked");
        }
        _reporte.filterTipoCapacitacionGetAllCheck();
        _reporte.filter_lstChkTipCapacitacionId_change();
    });
    _reporte.frm.find("[id*=lstChkTipCapacitacion]").change(function () {
        _reporte.filterTipoCapacitacionGetAllCheck();
        _reporte.filter_lstChkTipCapacitacionId_change();

        if (!$(this).is(":checked")) _reporte.frm.find("#chkTipCapacitacionAll").prop("checked", "");
    });
    //Filtro: Otros Eventos
    _reporte.frm.find("#ddlOtrosEventosId").change(function () {
        _reporte.filter_ddlOtrosEventosId_change();
    });
    //Filtro: TH Capacitados
    _reporte.frm.find("#ddlTHCapacitadosId").change(function () {
        _reporte.filter_ddlTHCapacitadosId_change();
    });
    //Filtro: Suma POI
    _reporte.frm.find("#ddlSumMetPoiId").change(function () {
        _reporte.filter_ddlSumMetPoiId_change();
    });
    //Filtro: Entidad Financia
    _reporte.frm.find("#ddlEntFinanciaId").change(function () {
        _reporte.filter_ddlEntFinanciaId_change();
    });
    //Filtro: Público Objetivo
    _reporte.frm.find("#chkPObjetivoAll").change(function () {
        for (var i = 1; i <= _reporte.frm.find("[id*=lstChkPObjetivoGroup]").length; i++) {
            if (i % 2 == 0)
                _reporte.frm.find("[id*=lstChkPObjetivoGroup]")[i - 1].checked = $(this).is(":checked");
        }
        _reporte.filterPObjetivoGetAllCheck();
        _reporte.filter_lstChkPublicoObjetivoId_change();
    });
    _reporte.frm.find("[id*=lstChkPObjetivoGroup]").change(function () {
        var isChecked = $(this).is(":checked");
        if (isChecked) {
            $(this).prop("checked", "checked");
        } else {
            $(this).prop("checked", "");
            _reporte.frm.find("#chkPObjetivoAll").prop("checked", "");
        }
        _reporte.filterPObjetivoGetAllCheck();
        _reporte.filter_lstChkPublicoObjetivoId_change();
    });
    //Filtro: Departamento
    _reporte.frm.find("#chkDepartamentoAll").change(function () {
        for (var i = 1; i <= _reporte.frm.find("[id*=lstChkDepartamento]").length; i++) {
            if (i % 2 == 0)
                _reporte.frm.find("[id*=lstChkDepartamento]")[i - 1].checked = $(this).is(":checked");
        }
        _reporte.filterDepartamentoGetAllCheck();
        _reporte.filter_lstChkDepartamentoId_change();
    });
    _reporte.frm.find("[id*=lstChkDepartamento]").change(function () {
        _reporte.filterDepartamentoGetAllCheck();
        _reporte.filter_lstChkDepartamentoId_change();

        if (!$(this).is(":checked")) _reporte.frm.find("#chkDepartamentoAll").prop("checked", "");
    });
}

_reporte.fnInitFiltro = function () {
    $.fn.select2.defaults.set("theme", "bootstrap4");
    _reporte.frm.find("#ddlTipoFiltroId").select2();
    _reporte.frm.find("#ddlOtrosEventosId").select2({ minimumResultsForSearch: -1 });
    _reporte.frm.find("#ddlTHCapacitadosId").select2({ minimumResultsForSearch: -1 });
    _reporte.frm.find("#ddlSumMetPoiId").select2({ minimumResultsForSearch: -1 });
    _reporte.frm.find("#ddlEntFinanciaId").select2({ minimumResultsForSearch: -1 });
    _reporte.frm.find("#ddlComunidadNativaId").select2();
    _reporte.frm.find("#ddlEtniaId").select2();
    $('[data-toggle="tooltip"]').tooltip();

    _reporte.filterEvent();
}
/******************Fin Filtros*******************/

/*REPORTE 1 - Consulta Capacitación Participante*/
_reporte.rpt1InitDataTable = function () {
    var columns_label = [], columns_data = [], options = {};

    columns_label = ["Código", "Capacitación", "Tipo", "Fecha Inicio", "Fecha Término", "N° Participantes", "N° Registrados", "N° Varones", "N° Mujeres"
        , "OD", "Departamento", "Provincia", "Distrito", "Público Objetivo", "Grupo Público Participante", "Entidad que Financia"
        , "Convenio", "Temas", "Otros Temas", "Comunidad Nativa", "Etnia", "Participante", "Tipo Participante", "Relación TH"];
    columns_data = ["COD_CAPACITACION", "NOMBRE", "TIPO", "FECHA_INICIO", "FECHA_FIN", "N_PARTICIPANTES", "N_REGISTRADOS", "NUM_HOMBRES", "NUM_MUJERES"
        , "OD", "DEPARTAMENTO", "PROVINCIA", "DISTRITO", "PUBLICO_OBJETIVO", "GRUPO_PUBLICO_PARTICIPANTE", "FINANCIA"
        , "CONVENIO", "TEMAS", "OTROS_TEMAS", "CCNN", "ETNIA", "PARTICIPANTE", "TIPO_PARTICIPANTE", "RELACION"];

    options = {
        page_length: 10, button_copy: true, button_csv: true, button_excel: true, button_pdf: true, button_print: true
        , export_title: $("#tbConsultaParticipante").find("thead tr")[0].innerText.trim(), row_index: true, page_sort: true,page_info:true
    };
    _reporte.dtConsultaParticipante = utilDt.fnLoadDataTable_Detail($("#tbConsultaParticipante"), columns_label, columns_data, options);
}

_reporte.fnInitConsultaParticipante = function () {
    //Activar Filtros
    _reporte.frm.find("#dvTipoFiltro").show();
    _reporte.frm.find("#dvChkInstitucionAll").show();
    _reporte.filterInstitucionClearAllCheck = function () { /*Deshabilitar evento en este formulario*/ };
    $("#dvConsultaParticipante").show();

    _reporte.rpt1InitDataTable();
    //Implementar eventos a ejecutar despúes de realizar una acción
    _reporte.filter_ddlTipoFiltroId_change = function () {
        _reporte.dtConsultaParticipante.clear().draw();
    }
    _reporte.modal_persona_change = function () {
        _reporte.fnSubmitForm();
    }
    _reporte.modal_thabilitante_change = function () {
        _reporte.fnSubmitForm();
    }
    _reporte.filter_ddlComunidadNativaId_change = function () {
        if (_reporte.frm.find("#ddlComunidadNativaId").val() == "0000000") {
            _reporte.dtConsultaParticipante.clear().draw();
        } else {
            _reporte.fnSubmitForm();
        }
    }
    _reporte.filter_ddlEtniaId_change = function () {
        if (_reporte.frm.find("#ddlEtniaId").val() == "0000000") {
            _reporte.dtConsultaParticipante.clear().draw();
        } else {
            _reporte.fnSubmitForm();
        }
    }
    _reporte.filter_lstChkInstitucionId_change = function () {
        _reporte.dtConsultaParticipante.clear().draw();
    }
    _reporte.fnSubmitForm = function () {
        _reporte.dtConsultaParticipante.clear().draw();
        if (_reporte.filterValidate()) {
            var datosReporte = _reporte.frm.serializeObject();
            var option = { url: _reporte.frm.action, datos: JSON.stringify(datosReporte), type: 'POST' };

            utilSigo.fnAjax(option, function (data) {
                if (data.success) {
                    _reporte.dtConsultaParticipante.rows.add(data.data).draw();
                }
                else {
                    utilSigo.toastWarning("Aviso", "Sucedio un error, Comuníquese con el Administrador");
                    console.log(data.msj);
                }
            });
        }

        return false;
    }
}
/******************Fin Reporte 1*****************/

/*REPORTE 2 - Programación y Ejecucíon de Capacitaciones*/
_reporte.rpt2InitDataTable = function () {
    var columns_label = [], columns_data = [], columns_event = [], options = {};

    columns_label = ["Oficina Desconcentrada", "Prog", "Ejec", "Prog", "Ejec", "Prog", "Ejec", "Prog", "Ejec", "Prog", "Ejec"
                            , "Prog", "Ejec", "Prog", "Ejec", "Prog", "Ejec"];
    columns_event = ["fn(c2)", "fn(c3)", "", "fn(c5)", "", "fn(c7)", "", "fn(c9)", "", "fn(c11)", "", "fn(c13)", "", "fn(c15)", "", "fn(c17)", ""]
    columns_data = ["OD", "TP0000001", "TE0000001", "TP0000002", "TE0000002", "TP0000003", "TE0000003", "TP0000004", "TE0000004", "TP0000005"
                    , "TE0000005", "TP0000007", "TE0000007", "TP0000006", "TE0000006", "TPTOTAL", "TETOTAL"];
    options = {
        button_copy: true, button_csv: true, button_excel: true, button_pdf: true, button_print: true
        , export_title: $("#tbProgramaVSEjecucion_Resumen").find("thead tr")[0].innerText.trim()
        , row_index: true
    };
    _reporte.dtProgramaVSEjecucion_Resumen = utilDt.fnLoadDataTable_EventColumn($("#tbProgramaVSEjecucion_Resumen"), columns_label, columns_data, columns_event, options);

    columns_label = ["Código", "Capacitación", "OD", "Mes", "Tipo", "Fecha Inicio Programada", "Departamento", "Ejecutado", "N° Participantes", "N° Registrados"
        , "N° Varones", "N° Mujeres", "Público Objetivo", "Grupo Público Participante", "Entidad que Financia"
        , "Convenio", "Temas", "Otros Temas", "Comunidad Nativa", "Etnia"];
    columns_data = ["COD_CAPACITACION", "NOMBRE", "OD", "MES", "TIPO", "FECHA_INICIO", "DEPARTAMENTO", "EJECUTADO", "N_PARTICIPANTES", "N_REGISTRADOS"
        , "NUM_HOMBRES", "NUM_MUJERES", "PUBLICO_OBJETIVO", "GRUPO_PUBLICO_PARTICIPANTE", "FINANCIA"
        , "CONVENIO", "TEMAS", "OTROS_TEMAS", "CCNN", "ETNIA"];
    options = {
        button_copy: true, button_csv: true, button_excel: true, button_pdf: true, button_print: true
        , export_title: $("#tbProgramaVSEjecucion_Detalle").find("thead tr")[0].innerText.trim()
        , page_length: 20, row_index: true, page_sort: true
    };
    _reporte.dtProgramaVSEjecucion_Detalle = utilDt.fnLoadDataTable_Detail($("#tbProgramaVSEjecucion_Detalle"), columns_label, columns_data, options);
}

_reporte.fnInitProgramaVsEjecucion = function () {
    //Activar Filtros
    _reporte.frm.find("#dvFiltroAnio").show();
    _reporte.frm.find("#dvFiltroMes").show();
    $("#dvProgramaVSEjecucion").show();

    _reporte.rpt2InitDataTable();
    //Implementar eventos a ejecutar despúes de realizar una acción
    var fnLimpiarReporte = function () {
        _reporte.dtProgramaVSEjecucion_Resumen.clear().draw();
        _reporte.dtProgramaVSEjecucion_Detalle.clear().draw();
        var tb = $("#tbProgramaVSEjecucion_Resumen");
        tb.find("#col3").text(0); tb.find("#col4").text(0); tb.find("#col5").text(0); tb.find("#col6").text(0);
        tb.find("#col7").text(0); tb.find("#col8").text(0); tb.find("#col9").text(0); tb.find("#col10").text(0);
        tb.find("#col11").text(0); tb.find("#col12").text(0); tb.find("#col13").text(0); tb.find("#col14").text(0);
        tb.find("#col15").text(0); tb.find("#col16").text(0); tb.find("#col17").text(0); tb.find("#col18").text(0);
    }

    _reporte.filter_lstChkAnioId_change = function () {
        fnLimpiarReporte();
    }
    _reporte.filter_lstChkMesId_change = function () {
        fnLimpiarReporte();
    }

    _reporte.fnSubmitForm = function () {
        _reporte.dtProgramaVSEjecucion_Resumen.clear().draw();
        _reporte.dtProgramaVSEjecucion_Detalle.clear().draw();
        if (_reporte.filterValidate()) {
            var datosReporte = _reporte.frm.serializeObject();
            var option = { url: _reporte.frm.action, datos: JSON.stringify(datosReporte), type: 'POST' };

            utilSigo.fnAjax(option, function (data) {
                if (data.success) {
                    _reporte.dtProgramaVSEjecucion_Resumen.rows.add(data.data).draw();

                    var c3 = 0, c4 = 0, c5 = 0, c6 = 0, c7 = 0, c8 = 0, c9 = 0, c10 = 0, c11 = 0, c12 = 0, c13 = 0, c14 = 0, c15 = 0, c16 = 0, c17 = 0, c18 = 0;
                    for (var i = 0; i < data.data.length; i++) {
                        c3 += parseInt(data.data[i]["TP0000001"]); c4 += parseInt(data.data[i]["TE0000001"]);
                        c5 += parseInt(data.data[i]["TP0000002"]); c6 += parseInt(data.data[i]["TE0000002"]);
                        c7 += parseInt(data.data[i]["TP0000003"]); c8 += parseInt(data.data[i]["TE0000003"]);
                        c9 += parseInt(data.data[i]["TP0000004"]); c10 += parseInt(data.data[i]["TE0000004"]);
                        c11 += parseInt(data.data[i]["TP0000005"]); c12 += parseInt(data.data[i]["TE0000005"]);
                        c13 += parseInt(data.data[i]["TP0000007"]); c14 += parseInt(data.data[i]["TE0000007"]);
                        c15 += parseInt(data.data[i]["TP0000006"]); c16 += parseInt(data.data[i]["TE0000006"]);
                        c17 += parseInt(data.data[i]["TPTOTAL"]); c18 += parseInt(data.data[i]["TETOTAL"]);
                    }

                    var tb = $("#tbProgramaVSEjecucion_Resumen");
                    tb.find("#col3").text(c3); tb.find("#col4").text(c4); tb.find("#col5").text(c5); tb.find("#col6").text(c6);
                    tb.find("#col7").text(c7); tb.find("#col8").text(c8); tb.find("#col9").text(c9); tb.find("#col10").text(c10);
                    tb.find("#col11").text(c11); tb.find("#col12").text(c12); tb.find("#col13").text(c13); tb.find("#col14").text(c14);
                    tb.find("#col15").text(c15); tb.find("#col16").text(c16); tb.find("#col17").text(c17); tb.find("#col18").text(c18);
                }
                else {
                    utilSigo.toastWarning("Aviso", "Sucedio un error, Comuníquese con el Administrador");
                    console.log(data.msj);
                }
            });
        }

        return false;
    }

    utilDt.fnEventColumn = function (obj, col) {
        var codOd = "", codTipoCapacitacion = "";
        switch (col) {
            case 3: codTipoCapacitacion = "0000001"; break;
            case 5: codTipoCapacitacion = "0000002"; break;
            case 7: codTipoCapacitacion = "0000003"; break;
            case 9: codTipoCapacitacion = "0000004"; break;
            case 11: codTipoCapacitacion = "0000005"; break;
            case 13: codTipoCapacitacion = "0000007"; break;
            case 15: codTipoCapacitacion = "0000006"; break;
        }

        if (obj != "") {
            codOd = _reporte.dtProgramaVSEjecucion_Resumen.row($(obj).parents('tr')).data()["COD_OD"];
        }

        if (_reporte.filterValidate()) {
            _reporte.dtProgramaVSEjecucion_Detalle.clear().draw();

            var datosReporte = _reporte.frm.serializeObject();
            datosReporte.hdfTipoReporte = "PROGRAMA_VS_EJECUCION_DETALLE";
            datosReporte.lstChkOdId = codOd;
            datosReporte.lstChkTipCapacitacionId = codTipoCapacitacion;

            var option = { url: _reporte.frm.action, datos: JSON.stringify(datosReporte), type: 'POST' };
            utilSigo.fnAjax(option, function (data) {
                if (data.success) {
                    _reporte.dtProgramaVSEjecucion_Detalle.rows.add(data.data).draw();
                }
                else {
                    utilSigo.toastWarning("Aviso", "Sucedio un error, Comuníquese con el Administrador");
                    console.log(data.msj);
                }
            });
        }

        return false;
    }
}
/******************Fin Reporte 2*****************/

/*REPORTE 3 - Total de Capacitaciones*/
_reporte.rpt3InitDataTable = function () {
    var columns_label = [], columns_data = [], columns_event=[], options = {};

    columns_label = ["Año", "N° Capacitaciones", "N° Personas Capacitadas", "N° Varones", "N° Mujeres"];
    columns_event = ["", "fn(c3)", "", "", ""]
    columns_data = ["ANIO", "NUM_CAPACITACIONES", "NUM_PARTICIPANTES", "NUM_HOMBRES", "NUM_MUJERES"];
    options = {
        button_copy: true, button_csv: true, button_excel: true, button_pdf: true, button_print: true
        , export_title: $("#tbTotalCapacitacion_Resumen").find("thead tr")[0].innerText.trim()
        , row_index: true
    };
    _reporte.dtTotalCapacitacion_Resumen = utilDt.fnLoadDataTable_EventColumn($("#tbTotalCapacitacion_Resumen"), columns_label, columns_data, columns_event, options);

    columns_label = ["Código", "Capacitación", "Tipo", "Fecha Inicio", "Fecha Término", "N° Participantes", "N° Registrados", "N° Varones", "N° Mujeres"
        , "OD", "Departamento", "Provincia", "Distrito", "Público Objetivo", "Grupo Público Participante", "Entidad que Financia"
        , "Convenio","Temas", "Otros Temas", "Comunidad Nativa", "Etnia"];
    columns_data = ["COD_CAPACITACION", "NOMBRE", "TIPO", "FECHA_INICIO", "FECHA_FIN", "N_PARTICIPANTES", "N_REGISTRADOS", "NUM_HOMBRES", "NUM_MUJERES"
        , "OD", "DEPARTAMENTO", "PROVINCIA", "DISTRITO", "PUBLICO_OBJETIVO", "GRUPO_PUBLICO_PARTICIPANTE", "FINANCIA"
        ,"CONVENIO","TEMAS","OTROS_TEMAS","CCNN","ETNIA"];
    options = {
        button_copy: true, button_csv: true, button_excel: true, button_pdf: true, button_print: true
        , export_title: $("#tbTotalCapacitacion_Detalle").find("thead tr")[0].innerText.trim(), page_length: 20
        , row_index: true, page_sort: true
    };
    _reporte.dtTotalCapacitacion_Detalle = utilDt.fnLoadDataTable_Detail($("#tbTotalCapacitacion_Detalle"), columns_label, columns_data, options);
}

_reporte.fnInitTotalCapacitacion = function () {
    var chartTotalCapacitacion_Resumen=null;
    //Activar Filtros
    _reporte.frm.find("#dvFiltroOD").show();
    _reporte.frm.find("#dvFiltroOtrosEventos").show();
    _reporte.frm.find("#dvFiltroMetaPoi").show();
    _reporte.frm.find("#dvFiltroTipoCapacitacion").show();
    _reporte.frm.find("#dvFiltroEntFinancia").show();
    $("#dvTotalCapacitacion").show();

    _reporte.rpt3InitDataTable();
    //Implementar eventos a ejecutar despúes de realizar una acción
    var fnLimpiarReporte = function () {
        _reporte.dtTotalCapacitacion_Resumen.clear().draw();
        _reporte.dtTotalCapacitacion_Detalle.clear().draw();
        var tb = $("#tbTotalCapacitacion_Resumen");
        tb.find("#col3").text(0); tb.find("#col4").text(0); tb.find("#col5").text(0); tb.find("#col6").text(0);

        if (chartTotalCapacitacion_Resumen!=null) {
            chartTotalCapacitacion_Resumen.clear();
        }
    }

    _reporte.filter_lstChkOdId_change = function () {
        fnLimpiarReporte();
    }
    _reporte.filter_lstChkTipCapacitacionId_change = function () {
        fnLimpiarReporte();
    }
    _reporte.filter_ddlOtrosEventosId_change = function () {
        fnLimpiarReporte();
    }
    _reporte.filter_ddlSumMetPoiId_change = function () {
        fnLimpiarReporte();
    }
    _reporte.filter_ddlEntFinanciaId_change = function () {
        fnLimpiarReporte();
    }

    _reporte.fnSubmitForm = function () {
        _reporte.dtTotalCapacitacion_Resumen.clear().draw();
        _reporte.dtTotalCapacitacion_Detalle.clear().draw();
        if (_reporte.filterValidate()) {
            var datosReporte = _reporte.frm.serializeObject();
            var option = { url: _reporte.frm.action, datos: JSON.stringify(datosReporte), type: 'POST' };

            utilSigo.fnAjax(option, function (data) {
                if (data.success) {
                    _reporte.dtTotalCapacitacion_Resumen.rows.add(data.data).draw();

                    var c3 = 0, c4 = 0, c5 = 0, c6 = 0;
                    for (var i = 0; i < data.data.length; i++) {
                        c3 += parseInt(data.data[i]["NUM_CAPACITACIONES"]); c4 += parseInt(data.data[i]["NUM_PARTICIPANTES"]);
                        c5 += parseInt(data.data[i]["NUM_HOMBRES"]); c6 += parseInt(data.data[i]["NUM_MUJERES"]);
                    }

                    var tb = $("#tbTotalCapacitacion_Resumen");
                    tb.find("#col3").text(c3); tb.find("#col4").text(c4); tb.find("#col5").text(c5); tb.find("#col6").text(c6);

                    chartTotalCapacitacion_Resumen = customChart.LoadBarraSimple_DataTable(_reporte.dtTotalCapacitacion_Resumen, "ANIO", { colIndex: [3, 4, 5], data: ["NUM_PARTICIPANTES", "NUM_HOMBRES", "NUM_MUJERES"], color: ["green", "blue", "red"] }, { title: "Personas Capacitadas por Año", canvas: "cnvTotalCapacitacion_Resumen" });
                }
                else {
                    utilSigo.toastWarning("Aviso", "Sucedio un error, Comuníquese con el Administrador");
                    console.log(data.msj);
                }
            });
        }

        return false;
    }

    utilDt.fnEventColumn = function (obj, col) {
        var anio = "";

        if (obj != "") {
            anio = _reporte.dtTotalCapacitacion_Resumen.row($(obj).parents('tr')).data()["ANIO"];
        }

        if (_reporte.filterValidate()) {
            _reporte.dtTotalCapacitacion_Detalle.clear().draw();

            var datosReporte = _reporte.frm.serializeObject();
            datosReporte.hdfTipoReporte = "TOTAL_CAPACITACION_DETALLE";
            datosReporte.lstChkAnioId = anio;

            var option = { url: _reporte.frm.action, datos: JSON.stringify(datosReporte), type: 'POST' };
            utilSigo.fnAjax(option, function (data) {
                if (data.success) {
                    _reporte.dtTotalCapacitacion_Detalle.rows.add(data.data).draw();
                }
                else {
                    utilSigo.toastWarning("Aviso", "Sucedio un error, Comuníquese con el Administrador");
                    console.log(data.msj);
                }
            });
        }

        return false;
    }
}
/******************Fin Reporte 3*****************/

/*REPORTE 4 - Capacitaciones Mensuales*/
_reporte.rpt4InitDataTable = function () {
    var columns_label = [], columns_data = [], columns_event = [], options = {};

    columns_label = ["Mes", "N° Capacitaciones", "N° Personas Capacitadas", "N° Varones", "N° Mujeres"];
    columns_event = ["", "fn(c3)", "", "", ""];
    columns_data = ["MES", "NUM_CAPACITACIONES", "NUM_PARTICIPANTES", "NUM_HOMBRES", "NUM_MUJERES"];
    options = {
        button_copy: true, button_csv: true, button_excel: true, button_pdf: true, button_print: true
        , export_title: $("#tbCapacitacionMensual_Resumen").find("thead tr")[0].innerText.trim(), row_index: true
    };
    _reporte.dtCapacitacionMensual_Resumen = utilDt.fnLoadDataTable_EventColumn($("#tbCapacitacionMensual_Resumen"), columns_label, columns_data, columns_event, options);

    columns_label = ["Código", "Capacitación", "Tipo", "Fecha Inicio", "Fecha Término", "N° Participantes", "N° Registrados", "N° Varones", "N° Mujeres"
        , "OD", "Departamento", "Provincia", "Distrito", "Público Objetivo", "Grupo Público Participante", "Entidad que Financia"
        , "Convenio", "Temas", "Otros Temas", "Comunidad Nativa", "Etnia"];
    columns_data = ["COD_CAPACITACION", "NOMBRE", "TIPO", "FECHA_INICIO", "FECHA_FIN", "N_PARTICIPANTES", "N_REGISTRADOS", "NUM_HOMBRES", "NUM_MUJERES"
        , "OD", "DEPARTAMENTO", "PROVINCIA", "DISTRITO", "PUBLICO_OBJETIVO", "GRUPO_PUBLICO_PARTICIPANTE", "FINANCIA"
        , "CONVENIO", "TEMAS", "OTROS_TEMAS", "CCNN", "ETNIA"];
    options = {
        button_copy: true, button_csv: true, button_excel: true, button_pdf: true, button_print: true
        , export_title: $("#tbCapacitacionMensual_Detalle").find("thead tr")[0].innerText.trim(), page_length: 20
        , row_index: true, page_sort: true
    };
    _reporte.dtCapacitacionMensual_Detalle = utilDt.fnLoadDataTable_Detail($("#tbCapacitacionMensual_Detalle"), columns_label, columns_data, options);
}

_reporte.fnInitCapacitacionMensual = function () {
    var chartCapacitacionMensual_Resumen = null;

    //Activar Filtros
    _reporte.frm.find("#dvFiltroAnio").show();
    _reporte.frm.find("#dvFiltroOtrosEventos").show();
    _reporte.frm.find("#dvFiltroMetaPoi").show();
    _reporte.frm.find("#dvFiltroTipoCapacitacion").show();
    _reporte.frm.find("#dvFiltroEntFinancia").show();
    $("#dvCapacitacionMensual").show();

    _reporte.rpt4InitDataTable();
    //Implementar eventos a ejecutar despúes de realizar una acción
    var fnLimpiarReporte = function () {
        _reporte.dtCapacitacionMensual_Resumen.clear().draw();
        _reporte.dtCapacitacionMensual_Detalle.clear().draw();
        var tb = $("#tbCapacitacionMensual_Resumen");
        tb.find("#col3").text(0); tb.find("#col4").text(0); tb.find("#col5").text(0); tb.find("#col6").text(0);

        if (chartCapacitacionMensual_Resumen!=null) {
            chartCapacitacionMensual_Resumen.clear();
        }
    }

    _reporte.filter_lstChkAnioId_change = function () {
        fnLimpiarReporte();
    }
    _reporte.filter_lstChkTipCapacitacionId_change = function () {
        fnLimpiarReporte();
    }
    _reporte.filter_ddlOtrosEventosId_change = function () {
        fnLimpiarReporte();
    }
     _reporte.filter_ddlSumMetPoiId_change = function () {
        fnLimpiarReporte();
    }
    _reporte.filter_ddlEntFinanciaId_change = function () {
        fnLimpiarReporte();
    }

    _reporte.fnSubmitForm = function () {
        _reporte.dtCapacitacionMensual_Resumen.clear().draw();
        _reporte.dtCapacitacionMensual_Detalle.clear().draw();
        if (_reporte.filterValidate()) {
            var datosReporte = _reporte.frm.serializeObject();
            var option = { url: _reporte.frm.action, datos: JSON.stringify(datosReporte), type: 'POST' };

            utilSigo.fnAjax(option, function (data) {
                if (data.success) {
                    _reporte.dtCapacitacionMensual_Resumen.rows.add(data.data).draw();

                    var c3 = 0, c4 = 0, c5 = 0, c6 = 0;
                    for (var i = 0; i < data.data.length; i++) {
                        c3 += parseInt(data.data[i]["NUM_CAPACITACIONES"]); c4 += parseInt(data.data[i]["NUM_PARTICIPANTES"]);
                        c5 += parseInt(data.data[i]["NUM_HOMBRES"]); c6 += parseInt(data.data[i]["NUM_MUJERES"]);
                    }

                    var tb = $("#tbCapacitacionMensual_Resumen");
                    tb.find("#col3").text(c3); tb.find("#col4").text(c4); tb.find("#col5").text(c5); tb.find("#col6").text(c6);

                    chartCapacitacionMensual_Resumen = customChart.LoadBarraSimple_DataTable(_reporte.dtCapacitacionMensual_Resumen, "MES", { colIndex: [3, 4, 5], data: ["NUM_PARTICIPANTES", "NUM_HOMBRES", "NUM_MUJERES"], color: ["green", "blue", "red"] }, { title: "Personas Capacitadas por Mes", canvas: "cnvCapacitacionMensual_Resumen" });
                }
                else {
                    utilSigo.toastWarning("Aviso", "Sucedio un error, Comuníquese con el Administrador");
                    console.log(data.msj);
                }
            });
        }

        return false;
    }

    utilDt.fnEventColumn = function (obj, col) {
        var numMes = "";

        if (obj != "") {
            numMes = _reporte.dtCapacitacionMensual_Resumen.row($(obj).parents('tr')).data()["NUM_MES"];
        }

        if (_reporte.filterValidate()) {
            _reporte.dtCapacitacionMensual_Detalle.clear().draw();

            var datosReporte = _reporte.frm.serializeObject();
            datosReporte.hdfTipoReporte = "CAPACITACION_MENSUAL_DETALLE";
            datosReporte.lstChkMesId = numMes;

            var option = { url: _reporte.frm.action, datos: JSON.stringify(datosReporte), type: 'POST' };
            utilSigo.fnAjax(option, function (data) {
                if (data.success) {
                    _reporte.dtCapacitacionMensual_Detalle.rows.add(data.data).draw();
                }
                else {
                    utilSigo.toastWarning("Aviso", "Sucedio un error, Comuníquese con el Administrador");
                    console.log(data.msj);
                }
            });
        }

        return false;
    }
}
/******************Fin Reporte 4*****************/

/*REPORTE 5 - Relación de Capacitaciones*/
_reporte.rpt5InitDataTable = function () {
    var columns_label = [], columns_data = [], options = {};

    columns_label = ["Código", "Capacitación", "Tipo", "Fecha Inicio", "N° Participantes", "N° Registrados"
        , "Oficina Desconcentrada", "Ubicación", "Público Objetivo", "Entidad que Financia"];
    columns_data = ["COD_CAPACITACION", "NOMBRE", "TIPO", "FECHA_INICIO", "N_PARTICIPANTES", "N_REGISTRADOS"
                    , "OD", "UBIGEO", "PUBLICO_OBJETIVO","FINANCIA"];
    options = { 
        page_length: 20, button_copy: true, button_csv: true, button_excel: true, button_pdf: true, button_print: true
        , export_title: $("#tbRelacionCapacitacion").find("thead tr")[0].innerText.trim(), row_index: true, page_sort: true
    };
    _reporte.dtRelacionCapacitacion = utilDt.fnLoadDataTable_Detail($("#tbRelacionCapacitacion"), columns_label, columns_data, options);
}

_reporte.fnInitRelacionCapacitacion = function () {
    //Activar Filtros
    _reporte.frm.find("#dvFiltroAnio").show();
    _reporte.frm.find("#dvChkAnioAll").show();
    _reporte.filterAnioClearAllCheck = function () { /*Deshabilitar evento en este formulario*/ };
    _reporte.frm.find("#dvFiltroOD").show();
    $("#dvRelacionCapacitacion").show();

    _reporte.rpt5InitDataTable();
    //Implementar eventos a ejecutar despúes de realizar una acción
    _reporte.filter_lstChkAnioId_change = function () {
        _reporte.dtRelacionCapacitacion.clear().draw();
    }
    _reporte.filter_lstChkOdId_change = function () {
        _reporte.dtRelacionCapacitacion.clear().draw();
    }

    _reporte.fnSubmitForm = function () {
        _reporte.dtRelacionCapacitacion.clear().draw();
        if (_reporte.filterValidate()) {
            var datosReporte = _reporte.frm.serializeObject();
            var option = { url: _reporte.frm.action, datos: JSON.stringify(datosReporte), type: 'POST' };

            utilSigo.fnAjax(option, function (data) {
                if (data.success) {
                    _reporte.dtRelacionCapacitacion.rows.add(data.data).draw();
                }
                else {
                    utilSigo.toastWarning("Aviso", "Sucedio un error, Comuníquese con el Administrador");
                    console.log(data.msj);
                }
            });
        }

        return false;
    }
}
/******************Fin Reporte 5*****************/

/*REPORTE 6 - Grupo Público Objetivo*/
_reporte.rpt6InitDataTable = function () {
    var columns_label = [], columns_data = [], columns_event = [], options = {};

    columns_label = ["Año", "Capacitaciones", "Participantes Registrados","N° Varones","N° Mujeres"];
    columns_event = ["", "fn()", "","",""];
    columns_data = ["ANIO", "CTOTAL", "PTOTAL", "PTOTALHOMBRE", "PTOTALMUJER"];
    options = { row_index: true };
    _reporte.dtPublicoObjetivoResumen = utilDt.fnLoadDataTable_EventColumn($("#tbPublicoObjetivoResumen"), columns_label, columns_data, columns_event, options);

    columns_label = ["Grupo Público Objetivo", "# Cap", "# Parti", "# Cap", "# Parti", "# Cap", "# Parti", "# Cap", "# Parti"
                    , "# Cap", "# Parti", "# Cap", "# Parti", "# Cap", "# Parti", "# Cap", "# Parti", "# Cap", "# Parti"];
    columns_data = ["GRUPO_PUBLICO", "C2012", "P2012", "C2013", "P2013", "C2014", "P2014", "C2015", "P2015", "C2016", "P2016"
                    , "C2017", "P2017", "C2018", "P2018", "C2019", "P2019", "CTOTAL", "PTOTAL"];
    options = {
        button_copy: true, button_csv: true, button_excel: true, button_pdf: true, button_print: true
        , export_title: $("#tbGrupoPublicoObjetivo").find("thead tr")[0].innerText.trim(), row_index: true
    };
    _reporte.dtGrupoPublicoObjetivo = utilDt.fnLoadDataTable_Detail($("#tbGrupoPublicoObjetivo"), columns_label, columns_data, options);

    columns_label = ["Público Objetivo", "# Cap", "# Parti", "# Cap", "# Parti", "# Cap", "# Parti", "# Cap", "# Parti"
                    , "# Cap", "# Parti", "# Cap", "# Parti", "# Cap", "# Parti", "# Cap", "# Parti", "# Cap", "# Parti"];
    columns_data = ["PUBLICO_OBJETIVO", "C2012", "P2012", "C2013", "P2013", "C2014", "P2014", "C2015", "P2015", "C2016", "P2016"
                    , "C2017", "P2017", "C2018", "P2018", "C2019", "P2019", "CTOTAL", "PTOTAL"];
    options = {
        button_copy: true, button_csv: true, button_excel: true, button_pdf: true, button_print: true
        , export_title: $("#tbPublicoObjetivo").find("thead tr")[0].innerText.trim(), row_index: true, page_length: 10, page_sort: true
    };
    _reporte.dtPublicoObjetivo = utilDt.fnLoadDataTable_Detail($("#tbPublicoObjetivo"), columns_label, columns_data, options);

    columns_label = ["Público Objetivo","Código", "Capacitación", "Tipo", "Fecha Inicio", "Fecha Término", "N° Participantes", "N° Registrados", "N° Varones", "N° Mujeres"
        , "OD", "Departamento", "Provincia", "Distrito", "Público Objetivo", "Grupo Público Participante", "Entidad que Financia"
        , "Convenio", "Temas", "Otros Temas", "Comunidad Nativa", "Etnia"];
    columns_data = ["PUBLICO_OBJETIVO","COD_CAPACITACION", "NOMBRE", "TIPO", "FECHA_INICIO", "FECHA_FIN", "N_PARTICIPANTES", "N_REGISTRADOS", "NUM_HOMBRES", "NUM_MUJERES"
        , "OD", "DEPARTAMENTO", "PROVINCIA", "DISTRITO", "PUBLICO_OBJETIVO", "GRUPO_PUBLICO_PARTICIPANTE", "FINANCIA"
        , "CONVENIO", "TEMAS", "OTROS_TEMAS", "CCNN", "ETNIA"];


    options = {
        page_length: 20, button_copy: true, button_csv: true, button_excel: true, button_pdf: true, button_print: true
        , export_title: $("#tbCapacitacionPublicoObjetivo").find("thead tr")[0].innerText.trim(), row_index: true, page_sort: true
    };
    _reporte.dtCapacitacionPublicoObjetivo = utilDt.fnLoadDataTable_Detail($("#tbCapacitacionPublicoObjetivo"), columns_label, columns_data, options);
}

_reporte.fnInitGrupoPublicoObjetivo = function () {
    //Activar Filtros
    _reporte.frm.find("#dvFiltroOD").show();
    _reporte.frm.find("#dvFiltroPublicoObjectivo").show();
    $("#dvGrupoPublicoObjetivo").show();

    var ind = 0;
    for (var i = 1; i <= _reporte.frm.find("[id*=lstChkPObjetivoGroup]").length; i++) {
        if (i % 2 != 0) {
            _reporte.frm.find("[id*=lstChkPObjetivoGroup]")[i-1].id = "lstChkPObjetivoGroup_" + (ind) + "__Value";
        } else {
            _reporte.frm.find("[id*=lstChkPObjetivoGroup]")[i - 1].id = "lstChkPObjetivoGroup_" + (ind++) + "__Checked";
        }
    }
    for (var i = 0; i < _reporte.frm.find("[for*=lstChkPObjetivoGroup]").length; i++) {
        _reporte.frm.find("[for*=lstChkPObjetivoGroup]")[i].htmlFor = "lstChkPObjetivoGroup_"+i+"__Checked";
    }

    _reporte.rpt6InitDataTable();
    //Implementar eventos a ejecutar despúes de realizar una acción
    var fnLimpiarReporte = function () {
        _reporte.dtPublicoObjetivoResumen.clear().draw();
        _reporte.dtGrupoPublicoObjetivo.clear().draw();
        _reporte.dtPublicoObjetivo.clear().draw();
        _reporte.dtCapacitacionPublicoObjetivo.clear().draw();

        var tb = $("#tbPublicoObjetivoResumen");
        tb.find("#col3").text(0); tb.find("#col4").text(0);
        tb.find("#col5").text(0); tb.find("#col6").text(0);
    }

    _reporte.filter_lstChkOdId_change = function () {
        fnLimpiarReporte();
    }
    _reporte.filter_lstChkPublicoObjetivoId_change = function () {
        fnLimpiarReporte();
    }

    _reporte.fnSubmitForm = function () {
        fnLimpiarReporte();

        if (_reporte.filterValidate()) {
            var datosReporte = _reporte.frm.serializeObject();
            var option = { url: _reporte.frm.action, datos: JSON.stringify(datosReporte), type: 'POST' };

            utilSigo.fnAjax(option, function (data) {
                if (data.success) {
                    _reporte.dtPublicoObjetivoResumen.rows.add(data.data3).draw();
                    _reporte.dtGrupoPublicoObjetivo.rows.add(data.data).draw();
                    _reporte.dtPublicoObjetivo.rows.add(data.data2).draw();

                    var c3 = 0, c4 = 0, c5 = 0, c6 = 0;
                    for (var i = 0; i < data.data3.length; i++) {
                        c3 += parseInt(data.data3[i]["CTOTAL"]); c4 += parseInt(data.data3[i]["PTOTAL"]);
                        c5 += parseInt(data.data3[i]["PTOTALHOMBRE"]); c6 += parseInt(data.data3[i]["PTOTALMUJER"]);
                    }

                    var tb = $("#tbPublicoObjetivoResumen");
                    tb.find("#col3").text(c3); tb.find("#col4").text(c4);
                    tb.find("#col5").text(c5); tb.find("#col6").text(c6);
                }
                else {
                    utilSigo.toastWarning("Aviso", "Sucedio un error, Comuníquese con el Administrador");
                    console.log(data.msj);
                }
            });
        }

        return false;
    }

    utilDt.fnEventColumn = function (obj, col) {
        _reporte.dtCapacitacionPublicoObjetivo.clear().draw();
        var anio = "";
        if (obj!=null && obj!="") {
            anio = _reporte.dtPublicoObjetivoResumen.row($(obj).parents('tr')).data()["ANIO"];
        }

        if (_reporte.filterValidate()) {
            var datosReporte = _reporte.frm.serializeObject();
            datosReporte.hdfTipoReporte = "CAPACITACION_PUBLICO_OBJETIVO";
            datosReporte.lstChkAnioId = anio;

            var option = { url: _reporte.frm.action, datos: JSON.stringify(datosReporte), type: 'POST' };
            utilSigo.fnAjax(option, function (data) {
                if (data.success) {
                    _reporte.dtCapacitacionPublicoObjetivo.rows.add(data.data).draw();
                }
                else {
                    utilSigo.toastWarning("Aviso", "Sucedio un error, Comuníquese con el Administrador");
                    console.log(data.msj);
                }
            });
        }

        return false;
    }
}
/******************Fin Reporte 6*****************/

/*REPORTE 7 - # Capacitaciones por Departamento y Año*/
_reporte.rpt7InitDataTable = function () {
    var columns_label = [], columns_data = [], options = {};

    columns_label = ["Departamento", "2012", "2013", "2014", "2015", "2016", "2017", "2018", "Total"];
    columns_data = ["DEPARTAMENTO", "C2012", "C2013", "C2014", "C2015", "C2016", "C2017", "C2018", "CTOTAL"];
    options = {
        button_copy: true, button_csv: true, button_excel: true, button_pdf: true, button_print: true
        , export_title: $("#tbCapacitacionDptoAnio").find("thead tr")[0].innerText.trim(), row_index: true
    };
    _reporte.dtCapacitacionDptoAnio = utilDt.fnLoadDataTable_Detail($("#tbCapacitacionDptoAnio"), columns_label, columns_data, options);

    columns_label = ["Año", "N° Capacitaciones", "N° Participantes", "N° Registrados", "N° Varones", "N° Mujeres"];
    columns_data = ["ANIO", "NUM_CAPACITACIONES", "N_PARTICIPANTES", "N_REGISTRADOS", "NUM_HOMBRES", "NUM_MUJERES"];
    options = {
        button_copy: true, button_csv: true, button_excel: true, button_pdf: true, button_print: true
        , export_title: $("#tbCapacitacionParticipanteAnio").find("thead tr")[0].innerText.trim(), row_index: true
    };
    _reporte.dtCapacitacionParticipanteAnio = utilDt.fnLoadDataTable_Detail($("#tbCapacitacionParticipanteAnio"), columns_label, columns_data, options);
}

_reporte.fnInitCapacitacionDptoAnio = function () {
    //Activar Filtros
    $("#dvContenedorFiltro").hide();
    $("#dvCapacitacionDptoAnio").show();

    _reporte.rpt7InitDataTable();

    //Cargar datos
    var datosReporte = _reporte.frm.serializeObject();
    var option = { url: _reporte.frm.action, datos: JSON.stringify(datosReporte), type: 'POST' };

    utilSigo.fnAjax(option, function (data) {
        if (data.success) {
            _reporte.dtCapacitacionDptoAnio.rows.add(data.data).draw();

            var c3 = 0, c4 = 0, c5 = 0, c6 = 0, c7 = 0, c8 = 0, c9 = 0, c10 = 0;
            for (var i = 0; i < data.data.length; i++) {
                c3 += parseInt(data.data[i]["C2012"]); c4 += parseInt(data.data[i]["C2013"]);
                c5 += parseInt(data.data[i]["C2014"]); c6 += parseInt(data.data[i]["C2015"]);
                c7 += parseInt(data.data[i]["C2016"]); c8 += parseInt(data.data[i]["C2017"]);
                c9 += parseInt(data.data[i]["C2018"]); c10 += parseInt(data.data[i]["CTOTAL"]);
            }
            var tb = $("#tbCapacitacionDptoAnio");
            tb.find("#col3").text(c3); tb.find("#col4").text(c4); tb.find("#col5").text(c5); tb.find("#col6").text(c6);
            tb.find("#col7").text(c7); tb.find("#col8").text(c8); tb.find("#col9").text(c9); tb.find("#col10").text(c10);

            customChart.LoadBarraSimple_DataTable(_reporte.dtCapacitacionDptoAnio, "DEPARTAMENTO", { colIndex: [9], data: ["CTOTAL"], color: ["green"] }, { type: "H", title: "Número de Capacitaciones por Departamento", canvas: "cnvCapacitacionDpto" });
        }
        else {
            utilSigo.toastWarning("Aviso", "Sucedio un error, Comuníquese con el Administrador");
            console.log(data.msj);
        }
    });

    datosReporte.hdfTipoReporte = "CAPACITACION_PARTICIPANTE_ANIO";
    option = { url: _reporte.frm.action, datos: JSON.stringify(datosReporte), type: 'POST' };

    utilSigo.fnAjax(option, function (data) {
        if (data.success) {
            _reporte.dtCapacitacionParticipanteAnio.rows.add(data.data).draw();

            var c3 = 0, c4 = 0, c5 = 0, c6 = 0, c7 = 0;
            for (var i = 0; i < data.data.length; i++) {
                c3 += parseInt(data.data[i]["NUM_CAPACITACIONES"]); c4 += parseInt(data.data[i]["N_PARTICIPANTES"]);
                c5 += parseInt(data.data[i]["N_REGISTRADOS"]); c6 += parseInt(data.data[i]["NUM_HOMBRES"]);
                c7 += parseInt(data.data[i]["NUM_MUJERES"]);
            }
            var tb = $("#tbCapacitacionParticipanteAnio");
            tb.find("#col3").text(c3); tb.find("#col4").text(c4); tb.find("#col5").text(c5); tb.find("#col6").text(c6);
            tb.find("#col7").text(c7);

            customChart.LoadBarraSimple_DataTable(_reporte.dtCapacitacionParticipanteAnio, "ANIO", { colIndex: [2], data: ["NUM_CAPACITACIONES"], color: ["purple"] }, { title: "Número de Capacitaciones por Año", canvas: "cnvCapacitacionAnio" });
        }
        else {
            utilSigo.toastWarning("Aviso", "Sucedio un error, Comuníquese con el Administrador");
            console.log(data.msj);
        }
    });
}
/******************Fin Reporte 7*****************/

/*REPORTE 8 - # Capacitación THabilitante*/
_reporte.rpt8InitDataTable = function () {
    var columns_label = [], columns_data = [],columns_event=[], options = {};

    columns_label = ["Modalidad", "Cantidad","Coincidencias"];
    columns_event = ["", "fn(c2)",""];
    columns_data = ["MODALIDAD", "CTOTAL","COINCIDENCIA"];
    options = {
        button_copy: true, button_csv: true, button_excel: true, button_pdf: true, button_print: true
        , export_title: $("#tbCapacitacionTHabilitante").find("thead tr")[0].innerText.trim(), row_index: true
    };
    _reporte.dtCapacitacionTHabilitante = utilDt.fnLoadDataTable_EventColumn($("#tbCapacitacionTHabilitante"), columns_label, columns_data, columns_event, options);

    columns_label = ["Título Habilitante", "Titular", "Ubicación TH", "Área del TH"/*, "Departamento TH", "Provincia TH", "Distrito TH"*/, "Modalidad", "Vigencia TH", "Se encuentra vigente el TH"/*, "Fecha Inicio TH", "Fecha Fin TH"*/, "Lista Roja", "Lista Verde"
        , "Fecha 1ra supervisión", "Fecha última supervisión", "Cant. supervisiones"
        , "Res. Sanción", "Infración", "Monto multa impuesta (UIT)", "Estado del PAU"
        , "Estado Multa", "Modalidad de pago", "Resolución Compensación"/*, "Res. de adm. que aprueba la solicitud de compensación"*//*, "Fecha res. de adm. que aprueba la solicitud de compensación"*/
        /*, "Res. de adm. que aprueba la compensación anual"*//*, "Fecha res. de adm. que aprueba la compensación anual"*/
        /*, "Res. de adm. que declara la pérdida de compensación"*//*, "Fecha res. de adm. que declara la pérdida de compensación"*/
        , "Cuota Inicial (UIT)", "Monto Multa Compensar (UIT)", "Monto Multa Compensar (S/)"/*, "Oportunidad capacitación - Acogimiento mod. de pago"*/
        , "Código Capacitación", "Capacitación", "Tipo", "Inicio y Término Capacitación"/*, "Fecha Inicio", "Fecha Término"*/
        , "N° Registrados", "OD", "Ubicación Cap."/*, "Departamento Capacitación", "Provincia Capacitación", "Distrito Capacitación"*/, "Temas", "Oportunidad capacitación - vigencia del TH"
        , "PMF en la Lista Roja aprobados post. a la capacitación", "Asistente", "DNI"
        , "Grupo público participante", "Público participante", "Cargo", "Telefono", "Edad", "Comunidad Nativa", "Etnia", "email", "Cod. constancia"//, "Observaciones Participante"
        , "CRITERIO"];
    //, "1:Cod-Asist = Cod-Tit", "2:Cod-Asist = Cod-RL", "3:DNI-Asist = DNI-Tit", "4:DNI-Asist = DNI-RL", "5:APEyN-Asist = APEyN-Tit", "6:APEyN-Asist = APEyN-RL"        
    //, "7:NyAPE-Asist = APEyN-Tit", "8:NyAPE-Asist = APEyN RL", "9:APEyN-Asist = NyAPE-Tit", "10:APEyN-Asist = NyAPE-RL", "11:TH-Asist = TH-SIGOsfc", "12:NomCCNN-Asist = NomTitCCNN-CCCC"];
    columns_data = ["NUM_THABILITANTE", "TITULAR", "TH_UBIGEO", "AREA_TH"/*, "DEPARTAMENTO_TH", "PROVINCIA_TH", "DISTRITO_TH"*/, "MODALIDAD", "VIGENCIA_TH", "TH_VIGENTE"/*, "CONTRATO_FECHA_INICIO", "CONTRATO_FECHA_FIN"*/, "LISTA_ROJA", "LISTA_VERDE"
        , "FECHA_PRIMERA_SUPERVISION", "FECHA_ULTIMA_SUPERVISION", "CANT_SUPERVISIONES"
        , "RES_SANCION", "INFRACCION", "MULTA_UIT", "ESTADO_PAU"
        , "ESTADO_PAGO", "MODALIDAD_PAGO", "RESOL_COMPENSACION"//, "NUM_RESOL_APRUEBA_SOL", "FECHA_RESOL_APRUEBA_SOL", "NUM_RESOL_APRUEBA_COMP", "FECHA_RESOL_APRUEBA_COMP", "NUM_RESOL_PERDIDA", "FECHA_RESOL_PERDIDA"
        , "UIT_INICIAL", "UIT_MULTA_COMP", "MONTO_MULTA_COMP"/*, "OPORTUNIDAD_ACOGIMIENTO"*/
        , "COD_CAPACITACION", "NOMBRE_CAPACITACION", "TIPO_CAPACITACION", "DURACION_CAP"/*, "FECHA_INICIO", "FECHA_FIN"*/
        , "N_REGISTRADOS", "OD", "UBIGEO"/*, "DEPARTAMENTO_CAP", "PROVINCIA_CAP", "DISTRITO_CAP"*/, "TEMA", "OPORTUNIDAD_TH", "ROJO_OBS", "ASISTENTE", "N_DOCUMENTO"
        , "GRUPO_PUBLICO_PARTICIPANTE", "PUBLICO_PARTICIPANTE", "CARGO", "TELEFONO", "EDAD", "CCNN", "ETNIA", "EMAIL", "COD_CONSTANCIA"//, "OBSERVACION_PARTICIPANTE"
        , "CRITERIO"];
        //, "CRITERIO_1", "CRITERIO_2", "CRITERIO_3", "CRITERIO_4", "CRITERIO_5", "CRITERIO_6", "CRITERIO_7", "CRITERIO_8", "CRITERIO_9", "CRITERIO_10", "CRITERIO_11", "CRITERIO_12"];
    options = {
        button_copy: true, button_csv: true, button_excel: true, button_pdf: true, button_print: true
        , export_title: $("#tbCapacitacionTHabilitanteDetalle").find("thead tr")[0].innerText.trim(), page_length: 20
        , row_index: true, page_sort: true
    };
    _reporte.dtCapacitacionTHabilitante_Detalle = utilDt.fnLoadDataTable_Detail($("#tbCapacitacionTHabilitanteDetalle"), columns_label, columns_data, options);
}

_reporte.fnInitCapacitacionTHabilitante = function () {
    //Activar Filtros
    _reporte.frm.find("#dvFiltroOD").show();
    _reporte.frm.find("#dvFiltroAnio").show();
    _reporte.frm.find("#dvChkAnioAll").show();
    _reporte.filterAnioClearAllCheck = function () { /*Deshabilitar evento en este formulario*/ };
    //_reporte.frm.find("#dvFiltroDepartamento").show();
    _reporte.frm.find("#dvFiltroOtrosEventos").show();
    _reporte.frm.find("#dvFiltroTHCapacitados").show();
    _reporte.frm.find("#dvFiltroMetaPoi").show();
    _reporte.frm.find("#dvFiltroEntFinancia").show();
    $("#dvCapacitacionTHabilitante").show();

    _reporte.rpt8InitDataTable();
    //Implementar eventos a ejecutar despúes de realizar una acción
    var fnLimpiarReporte = function () {
        _reporte.dtCapacitacionTHabilitante.clear().draw();
        _reporte.dtCapacitacionTHabilitante_Detalle.clear().draw();
        var tb = $("#tbCapacitacionTHabilitante");
        tb.find("#col3").text(0);        
        tb.find("#col4").text(0);
    }

    _reporte.filter_lstChkOdId_change = function () {
        fnLimpiarReporte();
    }
    _reporte.filter_lstChkAnioId_change = function () {
        fnLimpiarReporte();
    }
    //_reporte.filter_lstChkDepartamentoId_change = function () {
    //    fnLimpiarReporte();
    //}
    _reporte.filter_ddlOtrosEventosId_change = function () {
        fnLimpiarReporte();
    }
    _reporte.filter_ddlTHCapacitadosId_change = function () {
        fnLimpiarReporte();
        if (_reporte.frm.find("#ddlTHCapacitadosId").val() == "SI") {
            //_reporte.frm.find("#dvFiltroOD").show();
            _reporte.frm.find("#dvFiltroOtrosEventos").show();
            _reporte.frm.find("#dvFiltroMetaPoi").show();
            _reporte.frm.find("#dvFiltroEntFinancia").show();
            _reporte.frm.find("#dvFiltroAnio").show();
            _reporte.frm.find("#dvFiltroDepartamento").hide();
        }
        else {
            //_reporte.frm.find("#dvFiltroOD").hide();
            _reporte.frm.find("#dvFiltroOtrosEventos").hide();
            _reporte.frm.find("#dvFiltroMetaPoi").hide();
            _reporte.frm.find("#dvFiltroEntFinancia").hide();
            _reporte.frm.find("#dvFiltroAnio").hide();
            _reporte.frm.find("#dvFiltroDepartamento").show();
        }   
    }
    _reporte.filter_ddlSumMetPoiId_change = function () {
        fnLimpiarReporte();
    }
    _reporte.filter_ddlEntFinanciaId_change = function () {
        fnLimpiarReporte();
    }

    _reporte.fnSubmitForm = function () {
        fnLimpiarReporte();

        if (_reporte.filterValidate()) {
            var datosReporte = _reporte.frm.serializeObject();
            var option = { url: _reporte.frm.action, datos: JSON.stringify(datosReporte), type: 'POST' };

            utilSigo.fnAjax(option, function (data) {
                if (data.success) {
                    _reporte.dtCapacitacionTHabilitante.rows.add(data.data).draw();

                    var c3 = 0;
                    var c4 = 0;
                    for (var i = 0; i < data.data.length; i++) {
                        c3 += parseInt(data.data[i]["CTOTAL"]);
                        c4 += parseInt(data.data[i]["COINCIDENCIA"]);
                    }

                    var tb = $("#tbCapacitacionTHabilitante");
                    tb.find("#col3").text(c3);                   
                    tb.find("#col4").text(c4);
                }
                else {
                    utilSigo.toastWarning("Aviso", "Sucedio un error, Comuníquese con el Administrador");
                    console.log(data.msj);
                }
            });
        }
        return false;
    }

    utilDt.fnEventColumn = function (obj, col) {
        var codMTipo = "";

        if (obj != "") {
            codMTipo = _reporte.dtCapacitacionTHabilitante.row($(obj).parents('tr')).data()["COD_MTIPO"];
        }

        if (_reporte.dtCapacitacionTHabilitante.rows()[0].length>0) {
            if (_reporte.filterValidate()) {
                _reporte.dtCapacitacionTHabilitante_Detalle.clear().draw();

                var datosReporte = _reporte.frm.serializeObject();
                datosReporte.hdfTipoReporte = "CAPACITACION_THABILITANTE_DETALLE";
                datosReporte.hdfCodMTipo = codMTipo;

                var option = { url: _reporte.frm.action, datos: JSON.stringify(datosReporte), type: 'POST' };
                utilSigo.fnAjax(option, function (data) {
                    if (data.success) {
                        _reporte.dtCapacitacionTHabilitante_Detalle.rows.add(data.data).draw();
                    }
                    else {
                        utilSigo.toastWarning("Aviso", "Sucedio un error, Comuníquese con el Administrador");
                        console.log(data.msj);
                    }
                });
            }
        }
        return false;
    }
}
/******************Fin Reporte 8*****************/

/*REPORTE 9 - Grupo Público Participante*/
_reporte.rpt9InitDataTable = function () {
    var columns_label = [], columns_data = [], columns_event = [], options = {};

    columns_label = ["Año", "Capacitaciones", "Participantes Registrados", "N° Varones", "N° Mujeres"];
    columns_event = ["", "fn()", "", "", ""];
    columns_data = ["ANIO", "CTOTAL", "PTOTAL", "PTOTALHOMBRE", "PTOTALMUJER"];
    options = { row_index: true };
    _reporte.dtPublicoObjetivoResumen = utilDt.fnLoadDataTable_EventColumn($("#tbPublicoObjetivoResumen"), columns_label, columns_data, columns_event, options);

    columns_label = ["Grupo Público Participante", "# Cap", "# Parti", "# Cap", "# Parti", "# Cap", "# Parti", "# Cap", "# Parti"
        , "# Cap", "# Parti", "# Cap", "# Parti", "# Cap", "# Parti", "# Cap", "# Parti", "# Cap", "# Parti", "# Cap", "# Parti", "# Cap", "# Parti", "# Cap", "# Parti"];
    columns_data = ["GRUPO_PUBLICO", "C2012", "P2012", "C2013", "P2013", "C2014", "P2014", "C2015", "P2015", "C2016", "P2016"
        , "C2017", "P2017", "C2018", "P2018", "C2019", "P2019", "C2020", "P2020", "C2021", "P2021", "C2022", "P2022", "CTOTAL", "PTOTAL"];
    options = {
        button_copy: true, button_csv: true, button_excel: true, button_pdf: true, button_print: true
        , export_title: $("#tbGrupoPublicoObjetivo").find("thead tr")[0].innerText.trim(), row_index: true
    };
    _reporte.dtGrupoPublicoObjetivo = utilDt.fnLoadDataTable_Detail($("#tbGrupoPublicoObjetivo"), columns_label, columns_data, options);

    columns_label = ["Público Participante", "# Cap", "# Parti", "# Cap", "# Parti", "# Cap", "# Parti", "# Cap", "# Parti"
        , "# Cap", "# Parti", "# Cap", "# Parti", "# Cap", "# Parti", "# Cap", "# Parti", "# Cap", "# Parti", "# Cap", "# Parti", "# Cap", "# Parti", "# Cap", "# Parti"];
    columns_data = ["PUBLICO_PARTICIPANTE", "C2012", "P2012", "C2013", "P2013", "C2014", "P2014", "C2015", "P2015", "C2016", "P2016"
        , "C2017", "P2017", "C2018", "P2018", "C2019", "P2019", "C2020", "P2020", "C2021", "P2021", "C2022", "P2022", "CTOTAL", "PTOTAL"];
    options = {
        button_copy: true, button_csv: true, button_excel: true, button_pdf: true, button_print: true
        , export_title: $("#tbPublicoObjetivo").find("thead tr")[0].innerText.trim(), row_index: true, page_length: 10, page_sort: true
    };
    _reporte.dtPublicoObjetivo = utilDt.fnLoadDataTable_Detail($("#tbPublicoObjetivo"), columns_label, columns_data, options);

    columns_label = ["Público Participante", "Código", "Capacitación", "Tipo", "Fecha Inicio", "Fecha Término", "N° Participantes", "N° Registrados", "N° Varones", "N° Mujeres"
        , "OD", "Departamento", "Provincia", "Distrito", "Público Objetivo", "Grupo Público Participante", "Entidad que Financia"
        , "Convenio", "Temas", "Otros Temas", "Comunidad Nativa", "Etnia"];
    columns_data = ["PUBLICO_PARTICIPANTE", "COD_CAPACITACION", "NOMBRE", "TIPO", "FECHA_INICIO", "FECHA_FIN", "N_PARTICIPANTES", "N_REGISTRADOS", "NUM_HOMBRES", "NUM_MUJERES"
        , "OD", "DEPARTAMENTO", "PROVINCIA", "DISTRITO", "PUBLICO_OBJETIVO", "GRUPO_PUBLICO_PARTICIPANTE", "FINANCIA"
        , "CONVENIO", "TEMAS", "OTROS_TEMAS", "CCNN", "ETNIA"];

    options = {
        page_length: 20, button_copy: true, button_csv: true, button_excel: true, button_pdf: true, button_print: true
        , export_title: $("#tbCapacitacionPublicoObjetivo").find("thead tr")[0].innerText.trim(), row_index: true, page_sort: true
    };
    _reporte.dtCapacitacionPublicoObjetivo = utilDt.fnLoadDataTable_Detail($("#tbCapacitacionPublicoObjetivo"), columns_label, columns_data, options);
}

_reporte.fnInitGrupoPublicoParticipante = function () {
    //Activar Filtros
    _reporte.frm.find("#dvFiltroOD").show();
    _reporte.frm.find("#dvFiltroTipoCapacitacion").show();
    _reporte.frm.find("#dvFiltroOtrosEventos").show();
    _reporte.frm.find("#dvFiltroPublicoObjectivo").show();
    $("#dvGrupoPublicoObjetivo").show();

    var ind = 0;
    for (var i = 1; i <= _reporte.frm.find("[id*=lstChkPObjetivoGroup]").length; i++) {
        if (i % 2 != 0) {
            _reporte.frm.find("[id*=lstChkPObjetivoGroup]")[i - 1].id = "lstChkPObjetivoGroup_" + (ind) + "__Value";
        } else {
            _reporte.frm.find("[id*=lstChkPObjetivoGroup]")[i - 1].id = "lstChkPObjetivoGroup_" + (ind++) + "__Checked";
        }
    }
    for (var i = 0; i < _reporte.frm.find("[for*=lstChkPObjetivoGroup]").length; i++) {
        _reporte.frm.find("[for*=lstChkPObjetivoGroup]")[i].htmlFor = "lstChkPObjetivoGroup_" + i + "__Checked";
    }

    _reporte.rpt9InitDataTable();
    //Implementar eventos a ejecutar despúes de realizar una acción
    var fnLimpiarReporte = function () {
        _reporte.dtPublicoObjetivoResumen.clear().draw();
        _reporte.dtGrupoPublicoObjetivo.clear().draw();
        _reporte.dtPublicoObjetivo.clear().draw();
        _reporte.dtCapacitacionPublicoObjetivo.clear().draw();

        var tb = $("#tbPublicoObjetivoResumen");
        tb.find("#col3").text(0); tb.find("#col4").text(0);
        tb.find("#col5").text(0); tb.find("#col6").text(0);
    }

    _reporte.filter_lstChkOdId_change = function () {
        fnLimpiarReporte();
    }
    _reporte.filter_lstChkTipCapacitacionId_change = function () {
        fnLimpiarReporte();
    }
    _reporte.filter_ddlOtrosEventosId_change = function () {
        fnLimpiarReporte();
    }
    _reporte.filter_lstChkPublicoObjetivoId_change = function () {
        fnLimpiarReporte();
    }

    _reporte.fnSubmitForm = function () {
        fnLimpiarReporte();

        if (_reporte.filterValidate()) {
            var datosReporte = _reporte.frm.serializeObject();
            var option = { url: _reporte.frm.action, datos: JSON.stringify(datosReporte), type: 'POST' };

            utilSigo.fnAjax(option, function (data) {
                if (data.success) {                    
                    _reporte.dtPublicoObjetivoResumen.rows.add(data.data3).draw();                    
                    _reporte.dtGrupoPublicoObjetivo.rows.add(data.data).draw();
                    _reporte.dtPublicoObjetivo.rows.add(data.data2).draw();

                    var c3 = 0, c4 = 0, c5 = 0, c6 = 0;
                    for (var i = 0; i < data.data3.length; i++) {
                        c3 += parseInt(data.data3[i]["CTOTAL"]); c4 += parseInt(data.data3[i]["PTOTAL"]);
                        c5 += parseInt(data.data3[i]["PTOTALHOMBRE"]); c6 += parseInt(data.data3[i]["PTOTALMUJER"]);
                    }

                    var tb = $("#tbPublicoObjetivoResumen");
                    tb.find("#col3").text(c3); tb.find("#col4").text(c4);
                    tb.find("#col5").text(c5); tb.find("#col6").text(c6);
                }
                else {
                    utilSigo.toastWarning("Aviso", "Sucedio un error, Comuníquese con el Administrador");
                    console.log(data.msj);
                }
            });
        }

        return false;
    }

    utilDt.fnEventColumn = function (obj, col) {
        _reporte.dtCapacitacionPublicoObjetivo.clear().draw();
        var anio = "";
        if (obj != null && obj != "") {
            anio = _reporte.dtPublicoObjetivoResumen.row($(obj).parents('tr')).data()["ANIO"];
        }

        if (_reporte.filterValidate()) {
            var datosReporte = _reporte.frm.serializeObject();
            datosReporte.hdfTipoReporte = "CAPACITACION_PUBLICO_PARTICIPANTE";
            datosReporte.lstChkAnioId = anio;

            var option = { url: _reporte.frm.action, datos: JSON.stringify(datosReporte), type: 'POST' };
            utilSigo.fnAjax(option, function (data) {
                if (data.success) {
                    _reporte.dtCapacitacionPublicoObjetivo.rows.add(data.data).draw();
                }
                else {
                    utilSigo.toastWarning("Aviso", "Sucedio un error, Comuníquese con el Administrador");
                    console.log(data.msj);
                }
            });
        }

        return false;
    }
}
/******************Fin Reporte 9*****************/

$(document).ready(function () {
    _reporte.contenedor = "frmReporteCapacitacion";
    _reporte.frm = $("#" + _reporte.contenedor);

    _reporte.fnInitFiltro();

    switch (_reporte.frm.find("#hdfTipoReporte").val()) {
        case "CONSULTA_PARTICIPANTE":
            _reporte.fnInitConsultaParticipante();
            break;
        case "PROGRAMA_VS_EJECUCION":
            _reporte.fnInitProgramaVsEjecucion();
            break;
        case "TOTAL_CAPACITACION":
            _reporte.fnInitTotalCapacitacion();
            break;
        case "CAPACITACION_MENSUAL":
            _reporte.fnInitCapacitacionMensual();
            break;
        case "RELACION_CAPACITACION":
            _reporte.fnInitRelacionCapacitacion();
            break;
        case "GRUPO_PUBLICO_OBJETIVO":
            _reporte.fnInitGrupoPublicoObjetivo();
            break;
        case "CAPACITACION_DEPARTAMENTO_ANIO":
            _reporte.fnInitCapacitacionDptoAnio();
            break;
        case "CAPACITACION_THABILITANTE":
            _reporte.fnInitCapacitacionTHabilitante();
            break;
        case "GRUPO_PUBLICO_PARTICIPANTE":
            _reporte.fnInitGrupoPublicoParticipante();
            break;
    }
});