"use strict";
var _reporteGeneral = {};

/*GENERAL*/
_reporteGeneral.fnSubmitForm = function () { /*Implementar de acuerdo al reporte consultado*/ }
/*******************Fin General********************/

/*FILTROS Reporte*/
_reporteGeneral.filter_lstChkAnioId_change = function () { /*Implementar de acuerdo al reporte consultado*/ }
_reporteGeneral.filter_lstChkMesId_change = function () { /*Implementar de acuerdo al reporte consultado*/ }
_reporteGeneral.filter_lstChkOdId_change = function () { /*Implementar de acuerdo al reporte consultado*/ }
_reporteGeneral.filter_lstChkTipoInformeId_change = function () { /*Implementar de acuerdo al reporte consultado*/ }
_reporteGeneral.filter_lstChkModalidadId_change = function () { /*Implementar de acuerdo al reporte consultado*/ }
_reporteGeneral.filter_lstChkDepartamentoId_change = function () { /*Implementar de acuerdo al reporte consultado*/ }
_reporteGeneral.filter_lstChkDLineaId_change = function () { /*Implementar de acuerdo al reporte consultado*/ }
_reporteGeneral.filter_lstChkTipoDocumentoSigoId_change = function () { /*Implementar de acuerdo al reporte consultado*/ }
_reporteGeneral.filter_lstChkEstadoDocumentoId_change = function () { /*Implementar de acuerdo al reporte consultado*/ }
_reporteGeneral.filter_lstChkTipoResolucionFiscalizacionId_change = function () { /*Implementar de acuerdo al reporte consultado*/ }

_reporteGeneral.filterAnioClearAllCheck = function () {
    for (var i = 1; i <= _reporteGeneral.frm.find("[id*=lstChkAnio]").length; i++) {
        if (i % 2 == 0)
            _reporteGeneral.frm.find("[id*=lstChkAnio]")[i - 1].checked = false;
    }
}
_reporteGeneral.filterAnioGetAllCheck = function () {
    var selectAnio = "";
    for (var i = 1; i <= _reporteGeneral.frm.find("[id*=lstChkAnio]").length; i++) {
        if (i % 2 == 0) {
            if (_reporteGeneral.frm.find("[id*=lstChkAnio]")[i - 1].checked) {
                selectAnio += selectAnio == "" ? "" : ",";
                selectAnio += _reporteGeneral.frm.find("[id*=lstChkAnio]")[i - 2].value;
            }
        }
    }
    _reporteGeneral.frm.find("#lstChkAnioId").val(selectAnio);
}
_reporteGeneral.filterMesClearAllCheck = function () {
    for (var i = 1; i <= _reporteGeneral.frm.find("[id*=lstChkMes]").length; i++) {
        if (i % 2 == 0)
            _reporteGeneral.frm.find("[id*=lstChkMes]")[i - 1].checked = false;
    }
}
_reporteGeneral.filterMesGetAllCheck = function () {
    var selectMes = "";
    for (var i = 1; i <= _reporteGeneral.frm.find("[id*=lstChkMes]").length; i++) {
        if (i % 2 == 0) {
            if (_reporteGeneral.frm.find("[id*=lstChkMes]")[i - 1].checked) {
                selectMes += selectMes == "" ? "" : ",";
                selectMes += _reporteGeneral.frm.find("[id*=lstChkMes]")[i - 2].value;
            }
        }
    }
    _reporteGeneral.frm.find("#lstChkMesId").val(selectMes);
}
_reporteGeneral.filterOdGetAllCheck = function () {
    var selectOd = "";
    for (var i = 1; i <= _reporteGeneral.frm.find("[id*=lstChkOd]").length; i++) {
        if (i % 2 == 0) {
            if (_reporteGeneral.frm.find("[id*=lstChkOd]")[i - 1].checked) {
                selectOd += selectOd == "" ? "" : ";";
                selectOd += _reporteGeneral.frm.find("[id*=lstChkOd]")[i - 2].value;
            }
        }
    }
    _reporteGeneral.frm.find("#lstChkOdId").val(selectOd);
}
_reporteGeneral.filterTipoInformeGetAllCheck = function () {
    var selectTipoInforme = "";
    for (var i = 1; i <= _reporteGeneral.frm.find("[id*=lstChkTipoInforme]").length; i++) {
        if (i % 2 == 0) {
            if (_reporteGeneral.frm.find("[id*=lstChkTipoInforme]")[i - 1].checked) {
                selectTipoInforme += selectTipoInforme == "" ? "" : ";";
                selectTipoInforme += _reporteGeneral.frm.find("[id*=lstChkTipoInforme]")[i - 2].value;
            }
        }
    }
    _reporteGeneral.frm.find("#lstChkTipoInformeId").val(selectTipoInforme);
}
_reporteGeneral.filterModalidadGetAllCheck = function () {
    var select = "";
    for (var i = 1; i <= _reporteGeneral.frm.find("[id*=lstChkModalidad]").length; i++) {
        if (i % 2 == 0) {
            if (_reporteGeneral.frm.find("[id*=lstChkModalidad]")[i - 1].checked) {
                select += select == "" ? "" : ",";
                select += _reporteGeneral.frm.find("[id*=lstChkModalidad]")[i - 2].value;
            }
        }
    }
    _reporteGeneral.frm.find("#lstChkModalidadId").val(select);
}
_reporteGeneral.filterDepartamentoGetAllCheck = function () {
    var select = "";
    for (var i = 1; i <= _reporteGeneral.frm.find("[id*=lstChkDepartamento]").length; i++) {
        if (i % 2 == 0) {
            if (_reporteGeneral.frm.find("[id*=lstChkDepartamento]")[i - 1].checked) {
                select += select == "" ? "" : ",";
                select += _reporteGeneral.frm.find("[id*=lstChkDepartamento]")[i - 2].value;
            }
        }
    }
    _reporteGeneral.frm.find("#lstChkDepartamentoId").val(select);
}
_reporteGeneral.filterDLineaGetAllCheck = function () {
    var select = "";
    for (var i = 1; i <= _reporteGeneral.frm.find("[id*=lstChkDLinea]").length; i++) {
        if (i % 2 == 0) {
            if (_reporteGeneral.frm.find("[id*=lstChkDLinea]")[i - 1].checked) {
                select += select == "" ? "" : ",";
                select += _reporteGeneral.frm.find("[id*=lstChkDLinea]")[i - 2].value;
            }
        }
    }
    _reporteGeneral.frm.find("#lstChkDLineaId").val(select);
}
_reporteGeneral.filterTipoDocumentoSigoGetAllCheck = function () {
    var select = "";
    for (var i = 1; i <= _reporteGeneral.frm.find("[id*=lstChkTipoDocumentoSigo]").length; i++) {
        if (i % 2 == 0) {
            if (_reporteGeneral.frm.find("[id*=lstChkTipoDocumentoSigo]")[i - 1].checked) {
                select += select == "" ? "" : ",";
                select += _reporteGeneral.frm.find("[id*=lstChkTipoDocumentoSigo]")[i - 2].value;
            }
        }
    }
    _reporteGeneral.frm.find("#lstChkTipoDocumentoSigoId").val(select);
}
_reporteGeneral.filterEstadoDocumentoGetAllCheck = function () {
    var select = "";
    for (var i = 1; i <= _reporteGeneral.frm.find("[id*=lstChkEstadoDocumento]").length; i++) {
        if (i % 2 == 0) {
            if (_reporteGeneral.frm.find("[id*=lstChkEstadoDocumento]")[i - 1].checked) {
                select += select == "" ? "" : ",";
                select += _reporteGeneral.frm.find("[id*=lstChkEstadoDocumento]")[i - 2].value;
            }
        }
    }
    _reporteGeneral.frm.find("#lstChkEstadoDocumentoId").val(select);
}
_reporteGeneral.filterTipoResolucionFiscalizacionGetAllCheck = function () {
    var select = "";
    for (var i = 1; i <= _reporteGeneral.frm.find("[id*=lstChkTipoResolucionFiscalizacion]").length; i++) {
        if (i % 2 == 0) {
            if (_reporteGeneral.frm.find("[id*=lstChkTipoResolucionFiscalizacion]")[i - 1].checked) {
                select += select == "" ? "" : ",";
                select += _reporteGeneral.frm.find("[id*=lstChkTipoResolucionFiscalizacion]")[i - 2].value;
            }
        }
    }
    _reporteGeneral.frm.find("#lstChkTipoResolucionFiscalizacionId").val(select);
}



_reporteGeneral.filterValidate = function () {
    var sShow = "none";

    sShow = _reporteGeneral.frm.find("#dvFiltroAnio")[0].style.display;
    if (sShow == "") {
        if (_reporteGeneral.frm.find("#lstChkAnioId").val() == "") {
            utilSigo.toastWarning("Aviso", "Seleccione los años a consultar"); return false;
        }
    }
    sShow = _reporteGeneral.frm.find("#dvFiltroMes")[0].style.display;
    if (sShow == "") {
        if (_reporteGeneral.frm.find("#lstChkMesId").val() == "") {
            utilSigo.toastWarning("Aviso", "Seleccione los meses a consultar"); return false;
        }
    }
    sShow = _reporteGeneral.frm.find("#dvFiltroOD")[0].style.display;
    if (sShow == "") {
        if (_reporteGeneral.frm.find("#lstChkOdId").val() == "") {
            utilSigo.toastWarning("Aviso", "Seleccione las oficinas desconcentradas a consultar"); return false;
        }
    }
    sShow = _reporteGeneral.frm.find("#dvFiltroTipoInforme")[0].style.display;
    if (sShow == "") {
        if (_reporteGeneral.frm.find("#lstChkTipoInformeId").val() == "") {
            utilSigo.toastWarning("Aviso", "Seleccione los Tipos de Informe a consultar"); return false;
        }
    }
    sShow = _reporteGeneral.frm.find("#dvFiltroModalidad")[0].style.display;
    if (sShow == "") {
        if (_reporteGeneral.frm.find("#lstChkModalidadId").val() == "") {
            utilSigo.toastWarning("Aviso", "Seleccione las modalidades a consultar"); return false;
        }
    }
    sShow = _reporteGeneral.frm.find("#dvFiltroDepartamento")[0].style.display;
    if (sShow == "") {
        if (_reporteGeneral.frm.find("#lstChkDepartamentoId").val() == "") {
            utilSigo.toastWarning("Aviso", "Seleccione los departamentos a consultar"); return false;
        }
    }
    sShow = _reporteGeneral.frm.find("#dvFiltroDLinea")[0].style.display;
    if (sShow == "") {
        if (_reporteGeneral.frm.find("#lstChkDLineaId").val() == "") {
            utilSigo.toastWarning("Aviso", "Seleccione las direcciones de línea a consultar"); return false;
        }
    }
    sShow = _reporteGeneral.frm.find("#dvFiltroTipoDocumentoSigo")[0].style.display;
    if (sShow == "") {
        if (_reporteGeneral.frm.find("#lstChkTipoDocumentoSigoId").val() == "") {
            utilSigo.toastWarning("Aviso", "Seleccione los tipos de documentos a consultar"); return false;
        }
    }
    sShow = _reporteGeneral.frm.find("#dvFiltroEstadoDocumento")[0].style.display;
    if (sShow == "") {
        if (_reporteGeneral.frm.find("#lstChkEstadoDocumentoId").val() == "") {
            utilSigo.toastWarning("Aviso", "Seleccione los Estados de Control de Calidad a consultar"); return false;
        }
    }
    sShow = _reporteGeneral.frm.find("#dvFiltroTipoResolucionFiscalizacion")[0].style.display;
    if (sShow == "") {
        if (_reporteGeneral.frm.find("#lstChkTipoResolucionFiscalizacionId").val() == "") {
            utilSigo.toastWarning("Aviso", "Seleccione los tipos de resolución de fiscalización a consultar"); return false;
        }
    }

    return true;
}
_reporteGeneral.filterEvent = function () {
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

    //Filtro: Año
    _reporteGeneral.frm.find("#chkAnioAll").change(function () {
        for (var i = 1; i <= _reporteGeneral.frm.find("[id*=lstChkAnio]").length; i++) {
            if (i % 2 == 0)
                _reporteGeneral.frm.find("[id*=lstChkAnio]")[i - 1].checked = $(this).is(":checked");
        }
        _reporteGeneral.filterAnioGetAllCheck();
        _reporteGeneral.filter_lstChkAnioId_change();
    });
    _reporteGeneral.frm.find("[id*=lstChkAnio]").change(function () {
        var isChecked = $(this).is(":checked");
        _reporteGeneral.filterAnioClearAllCheck();
        if (isChecked) {
            $(this).prop("checked", "checked");
        } else {
            $(this).prop("checked", "");
            _reporteGeneral.frm.find("#chkAnioAll").prop("checked", "");
        }

        _reporteGeneral.filterAnioGetAllCheck();
        _reporteGeneral.filter_lstChkAnioId_change();
    });
    //Filtro: Mes
    _reporteGeneral.frm.find("#chkMesAll").change(function () {
        for (var i = 1; i <= _reporteGeneral.frm.find("[id*=lstChkMes]").length; i++) {
            if (i % 2 == 0)
                _reporteGeneral.frm.find("[id*=lstChkMes]")[i - 1].checked = $(this).is(":checked");
        }
        _reporteGeneral.filterMesGetAllCheck();
        _reporteGeneral.filter_lstChkMesId_change();
    });
    /*
    _reporteGeneral.frm.find("[id*=lstChkMes]").change(function () {
        var isChecked = $(this).is(":checked");
        _reporteGeneral.filterMesClearAllCheck();
        if (isChecked) {
            $(this).prop("checked", "checked");
        } else {
            $(this).prop("checked", "");
            _reporteGeneral.frm.find("#chkMesAll").prop("checked", "");
        }

        _reporteGeneral.filterMesGetAllCheck();
        _reporteGeneral.filter_lstChkMesId_change();
    });*/
   
    _reporteGeneral.frm.find("[id*=lstChkMes]").change(function () {
        _reporteGeneral.filterMesGetAllCheck();
        _reporteGeneral.filter_lstChkMesId_change();

        if (!$(this).is(":checked")) _reporteGeneral.frm.find("#chkMesAll").prop("checked", "");
    });




    //Filtro: Tipo de Informe
    _reporteGeneral.frm.find("#chkTipoInformeAll").change(function () {
        for (var i = 1; i <= _reporteGeneral.frm.find("[id*=lstChkTipoInforme]").length; i++) {
            if (i % 2 == 0)
                _reporteGeneral.frm.find("[id*=lstChkTipoInforme]")[i - 1].checked = $(this).is(":checked");
        }
        _reporteGeneral.filterTipoInformeGetAllCheck();
        _reporteGeneral.filter_lstChkTipoInformeId_change();
    });
    _reporteGeneral.frm.find("[id*=lstChkTipoInforme]").change(function () {
        _reporteGeneral.filterTipoInformeGetAllCheck();
        _reporteGeneral.filter_lstChkTipoInformeId_change();

        if (!$(this).is(":checked")) _reporteGeneral.frm.find("#chkTipoInformeAll").prop("checked", "");
    });
    //Filtro: OD
    _reporteGeneral.frm.find("#chkOdAll").change(function () {
        for (var i = 1; i <= _reporteGeneral.frm.find("[id*=lstChkOd]").length; i++) {
            if (i % 2 == 0)
                _reporteGeneral.frm.find("[id*=lstChkOd]")[i - 1].checked = $(this).is(":checked");
        }
        _reporteGeneral.filterOdGetAllCheck();
        _reporteGeneral.filter_lstChkOdId_change();
    });
    _reporteGeneral.frm.find("[id*=lstChkOd]").change(function () {
        _reporteGeneral.filterOdGetAllCheck();
        _reporteGeneral.filter_lstChkOdId_change();

        if (!$(this).is(":checked")) _reporteGeneral.frm.find("#chkOdAll").prop("checked", "");
    });
    //Filtro: Modalidad
    _reporteGeneral.frm.find("#chkModalidadAll").change(function () {
        for (var i = 1; i <= _reporteGeneral.frm.find("[id*=lstChkModalidad]").length; i++) {
            if (i % 2 == 0)
                _reporteGeneral.frm.find("[id*=lstChkModalidad]")[i - 1].checked = $(this).is(":checked");
        }
        _reporteGeneral.filterModalidadGetAllCheck();
        _reporteGeneral.filter_lstChkModalidadId_change();
    });
    _reporteGeneral.frm.find("[id*=lstChkModalidad]").change(function () {
        _reporteGeneral.filterModalidadGetAllCheck();
        _reporteGeneral.filter_lstChkModalidadId_change();

        if (!$(this).is(":checked")) _reporteGeneral.frm.find("#chkModalidadAll").prop("checked", "");
    });
    //Filtro: Departamento
    _reporteGeneral.frm.find("#chkDepartamentoAll").change(function () {
        for (var i = 1; i <= _reporteGeneral.frm.find("[id*=lstChkDepartamento]").length; i++) {
            if (i % 2 == 0)
                _reporteGeneral.frm.find("[id*=lstChkDepartamento]")[i - 1].checked = $(this).is(":checked");
        }
        _reporteGeneral.filterDepartamentoGetAllCheck();
        _reporteGeneral.filter_lstChkDepartamentoId_change();
    });
    _reporteGeneral.frm.find("[id*=lstChkDepartamento]").change(function () {
        _reporteGeneral.filterDepartamentoGetAllCheck();
        _reporteGeneral.filter_lstChkDepartamentoId_change();

        if (!$(this).is(":checked")) _reporteGeneral.frm.find("#chkDepartamentoAll").prop("checked", "");
    });
    //Filtro: Dirección de Línea
    _reporteGeneral.frm.find("#chkDLineaAll").change(function () {
        for (var i = 1; i <= _reporteGeneral.frm.find("[id*=lstChkDLinea]").length; i++) {
            if (i % 2 == 0)
                _reporteGeneral.frm.find("[id*=lstChkDLinea]")[i - 1].checked = $(this).is(":checked");
        }
        _reporteGeneral.filterDLineaGetAllCheck();
        _reporteGeneral.filter_lstChkDLineaId_change();
    });
    _reporteGeneral.frm.find("[id*=lstChkDLinea]").change(function () {
        _reporteGeneral.filterDLineaGetAllCheck();
        _reporteGeneral.filter_lstChkDLineaId_change();

        if (!$(this).is(":checked")) _reporteGeneral.frm.find("#chkDLineaAll").prop("checked", "");
    });
    //Filtro: Tipo Documento SIGOsfc
    _reporteGeneral.frm.find("#chkTipoDocumentoSigoAll").change(function () {
        for (var i = 1; i <= _reporteGeneral.frm.find("[id*=lstChkTipoDocumentoSigo]").length; i++) {
            if (i % 2 == 0)
                _reporteGeneral.frm.find("[id*=lstChkTipoDocumentoSigo]")[i - 1].checked = $(this).is(":checked");
        }
        _reporteGeneral.filterTipoDocumentoSigoGetAllCheck();
        _reporteGeneral.filter_lstChkTipoDocumentoSigoId_change();
    });
    _reporteGeneral.frm.find("[id*=lstChkTipoDocumentoSigo]").change(function () {
        _reporteGeneral.filterTipoDocumentoSigoGetAllCheck();
        _reporteGeneral.filter_lstChkTipoDocumentoSigoId_change();

        if (!$(this).is(":checked")) _reporteGeneral.frm.find("#chkTipoDocumentoSigoAll").prop("checked", "");
    });
    //Filtro: Estado Control de Calidad
    _reporteGeneral.frm.find("#chkEstadoDocumentoAll").change(function () {
        for (var i = 1; i <= _reporteGeneral.frm.find("[id*=lstChkEstadoDocumento]").length; i++) {
            if (i % 2 == 0)
                _reporteGeneral.frm.find("[id*=lstChkEstadoDocumento]")[i - 1].checked = $(this).is(":checked");
        }
        _reporteGeneral.filterEstadoDocumentoGetAllCheck();
        _reporteGeneral.filter_lstChkEstadoDocumentoId_change();
    });
    _reporteGeneral.frm.find("[id*=lstChkEstadoDocumento]").change(function () {
        _reporteGeneral.filterEstadoDocumentoGetAllCheck();
        _reporteGeneral.filter_lstChkEstadoDocumentoId_change();

        if (!$(this).is(":checked")) _reporteGeneral.frm.find("#chkEstadoDocumentoAll").prop("checked", "");
    });
    //Filtro: Tipo de Resoluciones de Fiscalización
    _reporteGeneral.frm.find("#chkTipoResolucionFiscalizacionAll").change(function () {
        for (var i = 1; i <= _reporteGeneral.frm.find("[id*=lstChkTipoResolucionFiscalizacion]").length; i++) {
            if (i % 2 == 0)
                _reporteGeneral.frm.find("[id*=lstChkTipoResolucionFiscalizacion]")[i - 1].checked = $(this).is(":checked");
        }
        _reporteGeneral.filterTipoResolucionFiscalizacionGetAllCheck();
        _reporteGeneral.filter_lstChkTipoResolucionFiscalizacionId_change();
    });
    _reporteGeneral.frm.find("[id*=lstChkTipoResolucionFiscalizacion]").change(function () {
        _reporteGeneral.filterTipoResolucionFiscalizacionGetAllCheck();
        _reporteGeneral.filter_lstChkTipoResolucionFiscalizacionId_change();

        if (!$(this).is(":checked")) _reporteGeneral.frm.find("#chkTipoResolucionFiscalizacionAll").prop("checked", "");
    });
}

_reporteGeneral.fnInitFiltro = function () {
    $('[data-toggle="tooltip"]').tooltip();
    _reporteGeneral.frm.find("#txtFechaCorte").datepicker(initSigo.formatDatePicker);

    _reporteGeneral.filterEvent();
}
/******************Fin Filtros*******************/

/*REPORTE 1 - Sabana Informe*/
_reporteGeneral.rpt1InitDataTable = function () {
    var columns_label = [], columns_data = [], options = {};

    columns_label = ["Año del Informe", "Sub Dirección de Línea", "Oficina Desconcentrada", "Modalidad de Aprovechamiento"
        , "Ubigeo del TH: Departamento", "Ubigeo del TH: Provincia", "Ubigeo del TH: Distrito", "Título Habilitante", "Área del TH", "Titular Actual"
        , "Titular Sancionado", "Ubigeo del Titular: Departamento", "Ubigeo del Titular: Provincia", "Ubigeo del Titular: Distrito", "Dirección", "Fecha Inicio TH", "Fecha Térmnino TH"
        , "Informe", "Control de calidad Informe", "Tipo de Informe", "Supervisor(es)", "Área supervisada", "Fecha Informe (para Inf. Supervisión es Fecha Ini Super)", "Fecha Término Supervisión"
        , "Fecha Emisión Inf. Supervisión"
        , "Fecha salida a campo", "Fecha recepción del cheque", "Fecha cobro del cheque", "Fecha de regreso de campo", "FEcha de inicio de labores en la oficina"
        , "Planes de Manejo Supervisados", "Resoluciones de Planes de Manejo Supervisados"
        , "Tipo Plan de Manejo", "Volumen Injustificado (m3)", "Volumen Justificado (m3)", "Nro árboles muestra", "Nro árboles supervisados", "Nro árboles inexistentes", "Es Alerta"
        , "Fecha Derivación DFFFS (SIGOsfc)", "Nro Proveido Derivación (SITD)", "Fecha Registro Derivación (SITD)", "Fecha Recepción Derivación (SITD)", "Devuelto DFFFS->DSFFS"
        , "Nro Proveido DFFFS->SUBDIR (SITD)", "Fecha Registro Derivación DFFFS->SUBDIR (SITD)", "Fecha Recepción Derivación DFFFS->SUBDIR (SITD)", "DFFFS->SUBDIR Delegado a: (SITD)"
        , "Inf. Legal de Eval.", "Fecha Emision Inf Legal", "Recomendación Inf. Legal", "Nueva Supervisión", "Evidencia de irregularidades cuya sanción no es competencia de OSINFOR"
        , "Sin indicios de infracción", "Deficiente notificación", "Deficiencia técnica", "Fallecimiento Titular", "Otros"
        , "Res. Aplicaciones Medidas Cautelares", "Notificaciones Aplicaciones Medidas Cautelare","Fecha Notificación Aplicaciones Medidas Cautelare"
        , "Nro Res. Archivo", "Fecha Emisión Res. Archivo", "Notificaciones Res. Archivo", "Fecha Notificación Res. Archivo", "Nro Expediente Administrativo"
        , "Nro. Res. Inicio PAU", "Fecha Emisión Res. Inicio PAU", "Infracciones Res. Inicio", "Causal de Caducidad", "Medidas Cautelares", "Notificaciones Ini PAU", "Fecha de Notificación Ini PAU"
        , "Res. Ampliación PAU", "Fecha Emisión Res. Ampliación PAU", "Infracciones Res. Amp. PAU", "Notificaciones Amplicación de PAU", "Fecha Notificación Amplicación de PAU"
        , "Res. Variación Imputación de Cargos", "Fecha Emi. Variación Imputación de Cargos", "Infracciones Res. Variación Imp. Cargos"
        , "Notificaciones Var. Imputación de Cargos","Fecha Notificación Var. Imputación de Cargos", "Inf. Final de Instrucción", "Fecha Emi. Inf. Final de Instrucción"
        , "Notificaciones Inf. Final de Instrucción", "fecha Not. Inf. Final de Instrucción", "Días despúes de la notificación del IFI", "Fecha derivación Dirección"
        , "Res. de Término de PAU", "Fecha de Emisión de la Res. de Término de PAU", "Infracciones Res. Término PAU", "Determinación Res. Término PAU"
        , "¿Res. Término PAU dicta caducidad?", "Monto Multa U.I.T.", "Amonestación", "Medidas Provisorias", "RLFFS 27308 ART. 363: i) (m3)"
        , "RLFFS 27308 ART. 363: k) (m3)", "RLFFS 27308 ART. 363: n) (m3)", "RLFFS 27308 ART. 363: w) (m3)", "DS 018-2015-MINAGRI ART. 207.3: e) (m3)"
        , "DS 018-2015-MINAGRI ART. 207.3: l) (m3)", "DS 021-2015-MINAGRI ART. 137.3: e) (m3)", "DS 021-2015-MINAGRI ART. 137.3: l) (m3)"
        , "¿Se impusieron Med. Correctivas?", "Descripción Medida Correctiva", "Año Implement. Med. Correctiva", "Mes Implement. Med. Correctiva"
        , "Día Implement. Med. Correctiva", "Año Informe Med. Correctiva", "Mes Informe Med. Correctiva", "Día Informe Med. Correctiva", "Gravedad de Daño"
        , "Notificación de la Resolución de Término de PAU", "Mala notificación para la supervisión", "Nuevas pruebas presentadas"
        , "Muerte titular", "Otros", "Prescripción", "Evaluación técnica favorable", "Deficiencia técnica", "Titular distinto"
        , "Resolución Reconsideración", "Fecha emisión RD Reconsideración", "Determinación Reconsideración", "Notificación de la Resolución de Reconsideración"
        , "¿Levantar Caducidad Recons 1?", "Nro Resolución TFFS", "Fecha Emisión Res. TFFS", "Recurso de Apelación", "Determina", "Motivo", "¿Confirma Resolución?"
        , "Res. Inicio PAU por Nulidad Parcial o total 2", "Fecha Emisión Res. Ini. 2", "Infracciones Res. Inicio PAU 2"
        , "Res. de Término de PAU 2", "Fecha de Emisión de la Res. de Término de PAU 2", "Infracciones Res. Término PAU 2", "Determinación Res. Término PAU 2"
        , "¿Res. Término PAU 2 dicta caducidad", "Monto de la Multa U.I.T.", "Amonestación", "Medidas Provisorias", "¿Se impusieron Med. Correctivas?"
        , "Notificación de la Resolución de Término de PAU 2", "Resolución Reconsideración 2", "Fecha emisión RD Reconsideración 2"
        , "Determinación Reconsideración 2", "Notificación de la Resolución de Reconsideración 2", "¿Levantar Caducidad Recons 2?"
        , "Nro Resolución TFFS", "Fecha Emisión Res. TFFS", "Recurso de Apelación", "Determina", "Motivo", "¿Confirma Resolución?", "Recurso de Reconsideración presentado"
        , "Recurso de Apelación presentado", "Proveido Archivo del Informe de Supervisión", "Proveido Firmeza", "Estado PAU (Glosario RP 121-2017)"
        , "Estado PAU (Interno)", "Caducidad del T.H.", "Monto Multa Final U.I.T.", "Infracciones Confirmadas", "Obsevatorio OSINFOR"
        , "Archivo por no cumplir directiva DSFFS", "Tercero Supervisor"];

    columns_data = ["ANIO_INFORME", "DLINEA", "OD_AMBITO_TH", "MTIPO", "DEPARTAMENTO_TH", "PROVINCIA_TH", "DISTRITO_TH"
        , "NUM_THABILITANTE", "AREA_TH", "TITULAR", "TITULAR_SANCIONADO", "DEPARTAMENTO_TIT", "PROVINCIA_TIT", "DISTRITO_TIT", "DIRECCION_TIT", "CONTRATO_FECHA_INICIO", "CONTRATO_FECHA_FIN"
        , "NUM_INFORME", "ESTADO_DOCUMENTO", "TIPO_INFORME", "SUPERVISORES", "AREA_SUPERVISADA", "FECHA_INFORME", "FECFIN_SUPERV", "FECEMI_INFORME"
        , "FECHA_SALIDA_CAMPO", "FECHA_RECEPCION_CHEQUE", "FECHA_COBRO_CHEQUE", "FECHA_REGRESO_CAMPO", "FECHA_INICIO_LABORES"
        , "NOMPOA_INFORME"
        , "RESPOA_INFORME", "TIPPOA_INFORME", "VOLINJ_INFORME", "VOLJUS_INFORME", "ARBOLES_MUESTRA", "ARBOLES_SUPERVISADOS", "ARBOLES_INEXISTENTES", "ES_ALERTA"
        , "FECDER_FISCA", "NUM_PROVEIDO_DERIVA_DFFFS", "FECDERIVA_DFFFS_REGISTRO", "FECDERIVA_DFFFS_RECEPCION", "DEVUELTO_DFFFS_DSFFS"
        , "NUM_PROVEIDO_DERIVA_DFFFS_SUBDIR", "FECDERIVA_DFFFS_SUBDIR_REGISTRO", "FECDERIVA_DFFFS_SUBDIR_RECEPCION", "DERIVA_DFFFS_SUBDIR_DELEGADO"
        , "NUM_ILEGAL", "FECHA_IL", "DETER_IL", "ARCH_NUESUP_IL", "ARCH_EVIIRR_IL", "ARCH_BUEMAN_IL", "ARCH_DEFNOT_IL"
        , "ARCH_DEFTEC_IL", "ARCH_MUETIT_IL", "ARCH_OTROS_IL"
        , "RD_APLICACIONMEDCORR", "NUMNOT_APLICACIONMEDCORR","FECHA_NOTAPLICACIONMEDCORR"
        , "NUM_RDARCH", "FECEMI_RDARCH", "NUM_NOTARCHIVO", "FECHA_NOTARCHIVO", "NUMERO_EXPEDIENTE"
        , "NUM_RDINI", "FECEMI_RDINI", "INFRAC_RDINI", "CAUCAD_RDINI", "MEDCAU_RDINI", "NUM_FISNOTI_RDINI", "FECHA_FISNOTI_RDINI"
        , "NUM_RDAMP", "FECEMI_RDAMP", "INFRAC_RDAMP", "NUM_FISNOTI_RDAMP", "FECHA_FISNOTI_RDAMP", "NUM_RDVARIMP", "FECEMI_RDVARIMP", "INFRAC_RDVARIMP", "NUM_FISNOTI_RDVARIMP", "FECHA_FISNOTI_RDVARIMP"
        , "NUM_IFI", "FECEMI_IFI", "NUM_FISNOTI_IFI", "FECHA_NOTFINAL", "EXPEDITO_IFI", "FECDER_IFI", "NUM_RDTER", "FECEMI_RDTER", "DETER_RDTER"
        , "INFRAC_RDTER", "CADUCIDAD_RDTER", "MULTA_RDTER", "AMONESTA_RDTER", "MEDPRO_RDTER", "VOLUMEN_i_i_TER", "VOLUMEN_k_i_TER", "VOLUMEN_n_i_TER"
        , "VOLUMEN_e_i_1TER", "VOLUMEN_e_i_2TER", "VOLUMEN_w_w_TER", "VOLUMEN_l_w_1TER", "VOLUMEN_l_w_2TER", "MEDCOR_RDTER", "DESC_MEDCOR_RDTER"
        , "ANIOIMP_MEDCOR_RDTER", "MESIMP_MEDCOR_RDTER", "DIAIMP_MEDCOR_RDTER", "ANIOINF_MEDCOR_RDTER", "MESINF_MEDCOR_RDTER", "DIAINF_MEDCOR_RDTER", "GRAVEDAD_RDTER"
        , "NUM_FISNOTI_RDTER", "ARCH_MALNOT_RDTER", "ARCH_NUEPRU_RDTER", "ARCH_MUETIT_RDTER", "ARCH_OTROS_RDTER", "ARCH_PRESCR_RDTER"
        , "ARCH_EVATEC_RDTER", "ARCH_DEFTEC_RDTER", "ARCH_TITDIS_RDTER", "NUM_RDREC_1", "FECEMI_RDREC_1", "DETER_RDREC_1"
        , "NUM_FISNOTI_RDREC_1", "LEVCAD_RDREC_1", "NUM_RTFFS_1", "FECEMI_RTFFS_1", "RECAPE_RTFFS_1", "DETER_RTFFS_1", "MOTIVO_RTFFS_1", "CONFIRM_RTFFS_1"
        , "NUM_RDINITF_2", "FECEMI_RDINITF_2", "INFRAC_RDINITF_2", "NUM_RDTERTF_2", "FECEMI_RDTERTF_2", "INFRAC_RDTERTF_2"
        , "DETER_RDTERTF_2", "CADUCIDAD_RDTERTF_2", "MULTA_RDTERTF_2", "AMONESTA_RDTERTF_2", "MEDPRO_RDTERTF_2", "MEDCOR_RDTERTF_2"
        , "NUM_FISNOTI_RDTERTF_2", "NUM_RDRECTF_2", "FECEMI_RDRECTF_2", "DETER_RDRECTF_2", "NUM_FISNOTI_RDRECTF_2", "LEVCAD_RDRECTF_2"
        , "NUM_RTFFS_2", "FECEMI_RTFFS_2", "RECAPE_RTFFS_2", "DETER_RTFFS_2", "MOTIVO_RTFFS_2", "CONFIRM_RTFFS_2", "RECURSO_RECONSIDERACION"
        , "RECURSO_APELACION", "PROVEIDO_INFORME", "PROVEIDO_FIRMEZA", "ESTADO_PAU", "ESTADO_PAU_INTERNO", "CADUCADO_TH"
        , "MULTA_CONFIRM", "INFRAC_CONFIRM", "OBSERVATORIO"
        , "ARCHIVO_DSFFS_NO_DIRECTIVA", "ELAB_TERCERO"];
    options = {
        page_length: 50, button_excel: true, export_title: $("#tbSabanaInforme").find("thead tr")[0].innerText.trim()
        , page_search: true, page_info: true, row_index: true,row_data_index:"ROW_INDEX"
    };
    _reporteGeneral.dtSabanaInforme = utilDt.fnLoadDataTable_Detail($("#tbSabanaInforme"), columns_label, columns_data, options);
}

_reporteGeneral.fnInitSabanaInforme = function () {
    //Activar Filtros
    _reporteGeneral.frm.find("#dvFiltroAnio").show();
    _reporteGeneral.frm.find("#dvChkAnioAll").show();
    _reporteGeneral.filterAnioClearAllCheck = function () { /*Deshabilitar evento en este formulario*/ };
    _reporteGeneral.frm.find("#dvFiltroTipoInforme").show();
    _reporteGeneral.frm.find("#dvFiltroOD").show();
    _reporteGeneral.frm.find("#dvFiltroModalidad").show();
    _reporteGeneral.frm.find("#dvFiltroDepartamento").show();
    _reporteGeneral.frm.find("#dvFiltroDLinea").show();
    $("#dvSabanaInforme").show();

    _reporteGeneral.rpt1InitDataTable();
    //Implementar eventos a ejecutar despúes de realizar una acción
    _reporteGeneral.filter_lstChkAnioId_change = function () {
        _reporteGeneral.dtSabanaInforme.clear().draw();
    }
    _reporteGeneral.filter_lstChkTipoInformeId_change = function () {
        _reporteGeneral.dtSabanaInforme.clear().draw();
    }
    _reporteGeneral.filter_lstChkOdId_change = function () {
        _reporteGeneral.dtSabanaInforme.clear().draw();
    }
    _reporteGeneral.filter_lstChkModalidadId_change = function () {
        _reporteGeneral.dtSabanaInforme.clear().draw();
    }
    _reporteGeneral.filter_lstChkDepartamentoId_change = function () {
        _reporteGeneral.dtSabanaInforme.clear().draw();
    }
    _reporteGeneral.filter_lstChkDLineaId_change = function () {
        _reporteGeneral.dtSabanaInforme.clear().draw();
    }

    _reporteGeneral.fnSubmitForm = function () {
        _reporteGeneral.dtSabanaInforme.clear().draw();
        if (_reporteGeneral.filterValidate()) {
            var datosReporte = _reporteGeneral.frm.serializeObject();
            var option = { url: _reporteGeneral.frm.action, datos: JSON.stringify(datosReporte), type: 'POST' };

            utilSigo.fnAjax(option, function (data) {
                if (data.success) {
                    _reporteGeneral.dtSabanaInforme.rows.add(data.data).draw();
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

/*REPORTE 2 - Sabana Plan de Manejo*/
_reporteGeneral.rpt2InitDataTable = function () {
    var columns_label = [], columns_data = [], options = {};

    columns_label = ["Año del Informe", "Sub Dirección de Linea", "Oficina Desconcentrada", "Modalidad de Aprovechamiento", "Ubigeo del TH: Departamento"
                    , "Ubigeo del TH: Provincia", "Ubigeo del TH: Distrito", "Título Habilitante", "Titular Actual", "Titular Sancionado"
                    , "Ubigeo del Titular: Departamento", "Ubigeo del Titular: Provincia", "Ubigeo del Titular: Distrito", "Dirección"
                    , "Informe", "Tipo de Informe", "Fecha Informe (para Inf. Supervisión es Fecha Ini Super.", "Fecha Emisión Inf. Supervisión"
        , "Plan de Manejo Primigeneo", "Plan de Manejo Supervisado", "Resolución de Aprobación", "Fecha de Aprobación", "Fecha Inicio Vigencia", "Fecha Fin Vigencia", "Tipo Plan de Manejo"
        , "Nro árboles aprobados", "Cant. especies aprobadas", "Volumen aprobado (m3)", "Volumen movilizado (m3)"
        , "Notificación de supervisión al Titular", "Fecha de notificación de supervisión al titular"
        , "Notificación de supervisión al regente", "Fecha de notificación de supervisión al regente"
        , "Consultor que suscribe el PM", "Regente que implementa el PM", "Funcionario", "Oportunidad de Supervisión"
                    , "Acta de Inspección Ocular", "Inf. Técnico que Recomienda Aprobación", "Inf. Técnico Inspección Ocular", "Área TH"
        , "Área Plan de Manejo", "Muestra Seleccionada (Total)", "Muestra Supervisada", "Individuos Inexistentes"
        , "Muestra Seleccionada (Aprovechables)", "Muestra Seleccionada (Semilleros)"
        , "Num. semilleros talados (Tocón, tumbado y/o trozado)", "Num. individuos mal identificados", "Volumen Injustificado (m3)", "Volumen Justificado (m3)"
        , "Notificación Informe al Titular","Notificación Informe al Ministerio Público", "Notificación Informe al GORE","Notificación Informe a la ATFFS", "Notificación Informe al OCI-ARFFS", "Notificación Informe al SERFOR"
        , "Inf. Legal de Eval.", "Fecha Emision Inf Legal", "Recomendación Inf. Legal", "Nueva Supervision"
                    , "Evidencia de irregularidades cuya sanción no es competencia de OSINFOR", "Sin indicios de infracción", "Deficiente notificación"
        , "Deficiencia técnica", "Fallecimiento Titular", "Otros"

        ,"Archivo del Informe de Supervisión - Notificación Informe al Titular", "Archivo del Informe de Supervisión -Notificación Informe al Ministerio Público", "Archivo del Informe de Supervisión -Notificación Informe al GORE",
        "Archivo del Informe de Supervisión -Notificación Informe a la ATFFS", "Archivo del Informe de Supervisión -Notificación Informe al OCI-ARFFS", "Archivo del Informe de Supervisión -Notificación Informe al SERFOR"

        , "Nro Res. Archivo", "Fecha Emisión Res. Archivo", "Nro Expediente Administrativo"
                    , "Nro. Res. Inicio PAU", "Fecha Emisión Res. Inicio PAU", "Infracciones Res. Inicio", "Causal de Caducidad", "Medidas Cautelares"
        , "Notificaciones Ini PAU", "Notificación al Ministerio Público", "Notificación al GORE", "Notificación a la ATFFS", "Notificación OCI-ARFFS", "Notificación SERFOR"        
        , "Res. Ampliación PAU", "Fecha Emisión Res. Ampliación PAU", "Infracciones Res. Amp. PAU"
                    , "Notificaciones Amplicación de PAU", "Res. Variación Imputación de Cargos", "Fecha Emi. Variación Imputación de Cargos"
                    , "Infracciones Res. Variación Imp. Cargos", "Notificaciones Var. Imputación de Cargos", "Inf. Final de Instrucción"
                    , "Fecha Emi. Inf. Final de Instrucción", "Notificaciones Inf. Final de Instrucción", "Dias despues de la notificación del IFI"
                    , "Fecha derivación Dirección", "Res. de Término de PAU", "Fecha de Emisión de la Res. de Término de PAU", "Infracciones Res. Término PAU"
                    , "Determinación Res. Término PAU", "¿Res. Término PAU dicta caducidad?", "Monto Multa U.I.T.", "Amonestación", "Medidas Provisorias"
                    , "RLFFS 27308 ART. 363: i) (m3)", "RLFFS 27308 ART. 363: k) (m3)", "RLFFS 27308 ART. 363: n) (m3)", "RLFFS 27308 ART. 363: w) (m3)"
                    , "DS 018-2015-MINAGRI ART. 207.3: e) (m3)", "DS 018-2015-MINAGRI ART. 207.3: l) (m3)", "DS 021-2015-MINAGRI ART. 137.3: e) (m3)"
                    , "DS 021-2015-MINAGRI ART. 137.3: l) (m3)", "¿Se impusieron Med. Correctivas?", "Descripción Medida Correctiva"
                    , "Año Implement. Med. Correctiva", "Mes Implement. Med. Correctiva", "Día Implement. Med. Correctiva", "Año Informe Med. Correctiva"
        , "Mes Informe Med. Correctiva", "Día Informe Med. Correctiva", "Notificación de la Resolución de Término de PAU"
        , "Notificación al Ministerio Público", "Notificación al GORE", "Notificación a la ATFFS", "Notificación OCI-ARFFS", "Notificación SERFOR"
                    , "Mala notificación para la supervisión", "Nuevas pruebas presentadas", "Muerte titular", "Otros", "Prescripción"
                    , "Evaluación técnica favorable", "Deficiencia técnica", "Titular distinto", "Resolución Reconsideración", "Fecha emisión RD Reconsideración"
                    , "Determinación Reconsideración", "Notificación de la Resolución de Reconsideración", "¿Levantar Caducidad Recons 1?"
                    , "Nro Resolución TFFS", "Fecha Emisión Res. TFFS", "Recurso de Apelación", "Determina", "Motivo", "¿Confirma Resolución?"
                    , "Res. Inicio PAU por Nulidad Parcial o total 2", "Fecha Emisión Res. Ini. 2", "Infracciones Res. Inicio PAU 2"
                    , "Res. de Término de PAU 2", "Fecha de Emisión de la Res. de Término de PAU 2", "Infracciones Res. Término PAU 2"
                    , "Determinación Res. Término PAU 2", "¿Res. Término PAU 2 dicta caducidad", "Monto de la Multa U.I.T.", "Amonestación"
                    , "Medidas Provisorias", "¿Se impusieron Med. Correctivas?", "Notificación de la Resolución de Término de PAU 2"
                    , "Resolución Reconsideración 2", "Fecha emisión RD Reconsideración 2", "Determinación Reconsideración 2"
                    , "Notificación de la Resolución de Reconsideración 2", "¿Levantar Caducidad Recons 2?", "Nro Resolución TFFS"
                    , "Fecha Emisión Res. TFFS", "Recurso de Apelación", "Determina", "Motivo", "¿Confirma Resolución?", "Recurso de Reconsideración presentado"
                    , "Recurso de Apelación presentado", "Proveido Archivo del Informe de Supervisión", "Proveido Firmeza", "Estado PAU (Glosario RP 121-2017)"
        , "Estado PAU (Interno)", "Caducidad del T.H.", "Obsevatorio OSINFOR", "Fecha Ingreso Observatorio", "Es Alerta"];
    columns_data = ["ANIO_INFORME", "DLINEA", "OD_AMBITO_TH", "MTIPO", "DEPARTAMENTO_TH", "PROVINCIA_TH", "DISTRITO_TH", "NUM_THABILITANTE", "TITULAR"
                    , "TITULAR_SANCIONADO", "DEPARTAMENTO_TIT", "PROVINCIA_TIT", "DISTRITO_TIT", "DIRECCION_TIT", "NUM_INFORME", "TIPO_INFORME"
        , "FECHA_INFORME", "FECEMI_INFORME", "NOMBRE_POA_PADRE", "NOMBRE_POA", "RESOLUCION_POA", "FECHA_APROBACION_POA", "INICIO_VIGENCIA", "FIN_VIGENCIA", "TIPO_POA"
        , "NUM_ARBOLES", "CANT_ESPECIES", "VOL_APROBADO", "VOL_MOVILIZADO"
        , "NOTIF_SUPER_TIT", "FECHA_NOTIF_SUPER_TIT", "NOTIF_SUPER_REGENTE", "FECHA_NOTIF_SUPER_REGENTE"
        , "CONSULTOR_POA", "REGENTE_IMPLEMENTA", "FUNCIONARIO_POA", "OPORTUNIDAD_POA"
        , "ACTINSOCU_POA", "ITECAPR_POA", "ITECINSOCU_POA", "AREA_TH", "AREA_POA", "MUESEL_POA", "MUESUP_POA", "ARBINEX_POA"
        , "MUESEL_APROVECHA_POA", "MUESEL_SEMILL_POA", "NUM_SEMILL_TALADOS", "NUM_MAL_IDENTIFICADOS"
        , "VOLINJ_POA", "VOLJUS_POA", "FN_INF", "FN_INF_MINPUB", "FN_INF_GORE", "FN_INF_ATFFS", "FN_INF_OCI", "FN_INF_SERFOR", "NUM_ILEGAL"
        , "FECHA_IL", "DETER_IL", "ARCH_NUESUP_IL", "ARCH_EVIIRR_IL", "ARCH_BUEMAN_IL"
        , "ARCH_DEFNOT_IL", "ARCH_DEFTEC_IL", "ARCH_MUETIT_IL", "ARCH_OTROS_IL", "FN_INF_ILEGAL", "FN_INF_MINPUB_ILEGAL", "FN_INF_GORE_ILEGAL"
        , "FN_INF_ATFFS_ILEGAL", "FN_INF_OCI_ILEGAL", "FN_INF_SERFOR_ILEGAL"
                    , "NUM_RDARCH", "FECEMI_RDARCH", "NUMERO_EXPEDIENTE"
        , "NUM_RDINI", "FECEMI_RDINI", "INFRAC_RDINI", "CAUCAD_RDINI", "MEDCAU_RDINI", "NUM_FISNOTI_RDINI"        
        , "FN_INI_MINPUB", "FN_INI_GORE", "FN_INI_ATFFS", "FN_INI_OCI", "FN_INI_SERFOR", "NUM_RDAMP"
                    , "FECEMI_RDAMP", "INFRAC_RDAMP", "NUM_FISNOTI_RDAMP", "NUM_RDVARIMP", "FECEMI_RDVARIMP", "INFRAC_RDVARIMP", "NUM_FISNOTI_RDVARIMP"
                    , "NUM_IFI", "FECEMI_IFI", "NUM_FISNOTI_IFI", "EXPEDITO_IFI", "FECDER_IFI", "NUM_RDTER", "FECEMI_RDTER", "INFRAC_RDTER"
                    , "DETER_RDTER", "CADUCIDAD_RDTER", "MULTA_RDTER", "AMONESTA_RDTER", "MEDPRO_RDTER", "VOLUMEN_i_i_TER", "VOLUMEN_k_i_TER"
                    , "VOLUMEN_n_i_TER", "VOLUMEN_e_i_1TER", "VOLUMEN_e_i_2TER", "VOLUMEN_w_w_TER", "VOLUMEN_l_w_1TER", "VOLUMEN_l_w_2TER"
                    , "MEDCOR_RDTER", "DESC_MEDCOR_RDTER", "ANIOIMP_MEDCOR_RDTER", "MESIMP_MEDCOR_RDTER", "DIAIMP_MEDCOR_RDTER", "ANIOINF_MEDCOR_RDTER"
                    , "MESINF_MEDCOR_RDTER", "DIAINF_MEDCOR_RDTER", "NUM_FISNOTI_RDTER", "FN_TER_MINPUB", "FN_TER_GORE", "FN_TER_ATFFS", "FN_TER_OCI"
                    , "FN_TER_SERFOR", "ARCH_MALNOT_RDTER", "ARCH_NUEPRU_RDTER", "ARCH_MUETIT_RDTER"
                    , "ARCH_OTROS_RDTER", "ARCH_PRESCR_RDTER", "ARCH_EVATEC_RDTER", "ARCH_DEFTEC_RDTER", "ARCH_TITDIS_RDTER", "NUM_RDREC_1"
                    , "FECEMI_RDREC_1", "DETER_RDREC_1", "NUM_FISNOTI_RDREC_1", "LEVCAD_RDREC_1", "NUM_RTFFS_1", "FECEMI_RTFFS_1", "RECAPE_RTFFS_1"
                    , "DETER_RTFFS_1", "MOTIVO_RTFFS_1", "CONFIRM_RTFFS_1", "NUM_RDINITF_2", "FECEMI_RDINITF_2", "INFRAC_RDINITF_2", "NUM_RDTERTF_2"
                    , "FECEMI_RDTERTF_2", "INFRAC_RDTERTF_2", "DETER_RDTERTF_2", "CADUCIDAD_RDTERTF_2", "MULTA_RDTERTF_2", "AMONESTA_RDTERTF_2"
                    , "MEDPRO_RDTERTF_2", "MEDCOR_RDTERTF_2", "NUM_FISNOTI_RDTERTF_2", "NUM_RDRECTF_2", "FECEMI_RDRECTF_2", "DETER_RDRECTF_2"
                    , "NUM_FISNOTI_RDRECTF_2", "LEVCAD_RDRECTF_2", "NUM_RTFFS_2", "FECEMI_RTFFS_2", "RECAPE_RTFFS_2", "DETER_RTFFS_2", "MOTIVO_RTFFS_2"
                    , "CONFIRM_RTFFS_2", "RECURSO_RECONSIDERACION", "RECURSO_APELACION", "PROVEIDO_INFORME", "PROVEIDO_FIRMEZA", "ESTADO_PAU"
                    , "ESTADO_PAU_INTERNO", "CADUCADO_TH", "OBSERVATORIO","FECHA_INGRESO_OBSERVATORIO","ES_ALERTA"];
    options = {
        page_length: 50, button_excel: true, export_title: $("#tbSabanaPlanManejo").find("thead tr")[0].innerText.trim()
        , page_search: true, page_info: true, row_index: true, row_data_index: "ROW_INDEX"
    };
    _reporteGeneral.dtSabanaPlanManejo = utilDt.fnLoadDataTable_Detail($("#tbSabanaPlanManejo"), columns_label, columns_data, options);
}

_reporteGeneral.fnInitSabanaPlanManejo = function () {
    //Activar Filtros
    _reporteGeneral.frm.find("#dvFiltroAnio").show();
    _reporteGeneral.frm.find("#dvChkAnioAll").show();
    _reporteGeneral.filterAnioClearAllCheck = function () { /*Deshabilitar evento en este formulario*/ };
    _reporteGeneral.frm.find("#dvFiltroTipoInforme").show();
    _reporteGeneral.frm.find("#dvFiltroOD").show();
    _reporteGeneral.frm.find("#dvFiltroModalidad").show();
    _reporteGeneral.frm.find("#dvFiltroDepartamento").show();
    _reporteGeneral.frm.find("#dvFiltroDLinea").show();
    $("#dvSabanaPlanManejo").show();

    _reporteGeneral.rpt2InitDataTable();
    //Implementar eventos a ejecutar despúes de realizar una acción
    _reporteGeneral.filter_lstChkAnioId_change = function () {
        _reporteGeneral.dtSabanaPlanManejo.clear().draw();
    }
    _reporteGeneral.filter_lstChkTipoInformeId_change = function () {
        _reporteGeneral.dtSabanaPlanManejo.clear().draw();
    }
    _reporteGeneral.filter_lstChkOdId_change = function () {
        _reporteGeneral.dtSabanaPlanManejo.clear().draw();
    }
    _reporteGeneral.filter_lstChkModalidadId_change = function () {
        _reporteGeneral.dtSabanaPlanManejo.clear().draw();
    }
    _reporteGeneral.filter_lstChkDepartamentoId_change = function () {
        _reporteGeneral.dtSabanaPlanManejo.clear().draw();
    }
    _reporteGeneral.filter_lstChkDLineaId_change = function () {
        _reporteGeneral.dtSabanaPlanManejo.clear().draw();
    }

    _reporteGeneral.fnSubmitForm = function () {
        _reporteGeneral.dtSabanaPlanManejo.clear().draw();
        if (_reporteGeneral.filterValidate()) {
            var datosReporte = _reporteGeneral.frm.serializeObject();
            var option = { url: _reporteGeneral.frm.action, datos: JSON.stringify(datosReporte), type: 'POST' };

            utilSigo.fnAjax(option, function (data) {
                if (data.success) {
                    _reporteGeneral.dtSabanaPlanManejo.rows.add(data.data).draw();
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

/*REPORTE 3 - Sabana Seguimiento Alerta*/
_reporteGeneral.rpt3InitDataTable = function () {
    var columns_label = [], columns_data = [], options = {};
    var tb = $("#tbSabanaSeguimientoAlerta");
    columns_label = ["Ambito Geográfico OD", "Modalidad", "Departamento", "Provincia", "Distrito", "Título Habilitante", "Titular","Carta de Notificación de Supervisión" ,            
        "Plan de Manejo Supervisado", "Fecha Aprobacion", "Fecha Recepcion OSINFOR", "Nro Dias Calendario Transcurridos", "Nro  Dias Habiles Transcurridos", "Consultor(es)/Regente(s)", "Funcionario(s)",
        "Fecha Inicio Supervisión", "Fecha Término Supervisión", "Fecha Envio Alerta", "Asunto Mensaje Alerta","Volumen Injustificado de la Alerta (m3)", "Descripción de la Alerta sobre hechos ilegales",
        "Otros hechos relevantes", "Destinatarios Alerta OSINFOR", "Nro Informe Supervisión", "Fecha Entrega Informe","Fecha Ingreso Observatorio", "Notificación Informe al Titular", "Notificación Informe al GORE",
        "Notificación Informe a la ATFFS", "Notificación Informe al OCI-ARFFS", "Notificación Informe al SERFOR", "Informe Legal de evaluación del Inf. de Supervisión", "Fecha de Emisión", "Determinación",
        "Archivo del Informe de Supervisión - Notificación Informe al Titular", "Archivo del Informe de Supervisión -Notificación Informe al GORE",
        "Archivo del Informe de Supervisión -Notificación Informe a la ATFFS", "Archivo del Informe de Supervisión -Notificación Informe al OCI-ARFFS", "Archivo del Informe de Supervisión -Notificación Informe al SERFOR"
        , "Muestra Seleccionada", "Muestra Supervisada", "Árboles Inexistentes", "Volumen Injustificado del Informe (m3)",

        "Volumen Justificado del Informe (m3)", "Res. Medida Cautelar antes del PAU", "Fecha Emisión", "Notificación al Titular", "Notificación al GORE", "Notificación a la ATFFS",
        "Notificación OCI-ARFFS", "Notificación SERFOR", "Nro Expediente Adm.", "Res. Inicio PAU", "Fecha Emisión", "Notificación al Titular", "Notificaciónal GORE", "Notificación a la ATFFS",
        "Notificación OCI-ARFFS", "Notificación SERFOR", "DS 018-2015-MINAGRI ART. 207.3: l) (m3)", "DS 021-2015-MINAGRI ART. 137.3: e) (m3)", "DS 021-2015-MINAGRI ART. 137.3: l) (m3)", "Res. Ampliación PAU",
        "Fecha Emisión", "Res. Término PAU", "Fecha Emisión", "Determinación", "Notificación al Titular", "Notificaciónal GORE", "Notificación a la ATFFS", "Notificación OCI-ARFFS", "Notificación SERFOR",
        "DS 018-2015-MINAGRI ART. 207.3: l) (m3)", "DS 021-2015-MINAGRI ART. 137.3: e) (m3)", "DS 021-2015-MINAGRI ART. 137.3: l) (m3)", "Monto Multa (U.I.T.) según Res. Término PAU",

        "Res. Resolución Reconsideración", "Fecha Emisión", "Determinación", "Res. TFFS", "Fecha Emisión", "Datos de la Apelación", "Determinación de la Resolución del TFFS",
        "Motivo", "¿Se Confirma la Resolución?", "Estado PAU", "Resultado PAU (Interno)", "Medida Cautelar", "Medida Provisoria", "Monto Multa (U.I.T.) actualizado", "Título Habilitante Caducado"
        ,"Fecha de Salida de la oficina", "Fecha de Regreso a campo", "Fecha de Inicio de labores en la oficina"
    ];
    
    columns_data = ["OD_AMBITO", "MODALIDAD_TIPO", "DEPARTAMENTO", "PROVINCIA", "DISTRITO", "NUM_THABILITANTE", "TITULAR", "NUM_CNOTIFICACION",
        "PM_SUPERVISADO", "FECHA_APROB", "FECHA_RECEPCION", "DIF_DIAS_CALEND", "DIF_DIAS_HABIL", "CONSULTOR_REGENTE", "FUNCIONARIO",
        "FECHA_INI_SUP", "FECHA_TER_SUP", "FECHA_ENVIO_ALERTA", "ASUNTO_ENVIO_ALERTA","VOL_INJUS_ALERTA", "DESCRIPCION_ALERTA",
        "OTROS_HECHOS","DESTINO_ENVIO_ALERTA", "NUM_INFORME", "FECHA_ENTREGA_INF","FECHA_INGRESO_OBSERVATORIO", "FN_INF", "FN_INF_GORE",
        "FN_INF_ATFFS", "FN_INF_OCI", "FN_INF_SERFOR", "NUM_ILEGAL", "FECHA_ILEGAL", "DETER_ILEGAL",
        "FN_INF_ILEGAL", "FN_INF_GORE_ILEGAL", "FN_INF_ATFFS_ILEGAL", "FN_INF_OCI_ILEGAL", "FN_INF_SERFOR_ILEGAL",
        "MUESTRA_SELECT", "MUESTRA_SUPERVISADA", "INEX", "VOL_INUSTIFICADO",

        "VOL_JUSTIFICADO", "RES_MC_ANT_PAU", "FECHA_EMISION", "FN_MCAP", "FN_MCAP_GORE", "FN_MCAP_ATFFS", "FN_MCAP_OCI", "FN_MCAP_SERFOR",
        "NUMERO_EXPEDIENTE", "RD_INI", "FECHA_INI", "FN_INI", "FN_INI_GORE", "FN_INI_ATFFS",
        "FN_INI_OCI", "FN_INI_SERFOR", "VOLUMEN_w_w_INI", "VOLUMEN_l_w_1INI", "VOLUMEN_l_w_2INI", "RD_AMP",
        "FECHA_AMP", "RD_TER", "FECHA_TER", "DETER_TER", "FN_TER", "FN_TER_GORE", "FN_TER_ATFFS", "FN_TER_OCI", "FN_TER_SERFOR",
        "VOLUMEN_w_w_TER", "VOLUMEN_l_w_1TER", "VOLUMEN_l_w_2TER", "MONTO",

        "RD_REC", "FECHA_RECONS", "DETER_REC1", "NUM_TFFS", "FECHA_TFFS", "NOM_RECAPE", "NOM_TIPDET",
        "NOM_MOTDET", "CONFIRM_RESOL_1", "ESTADO_PAU_GLOSARIO", "ESTADO_PAU_INTERNO", "MEDIDA_CAUTELAR", "MEDIDA_PROVISORIA", "MONTO_MULTA_FINAL", "CADUCADO_TH"
        , "FECHA_SALIDA", "FECHA_RETORNO_CAMPO","FECHA_LLEGADA"
    ];

    options = {
        page_length: 50, button_excel: true, export_title: tb.find("thead tr")[0].innerText.trim()
        , page_search: true, page_info: true, row_index: true, row_data_index: "ROW_INDEX"
    };
    _reporteGeneral.dtSabanaSeguimientoAlerta = utilDt.fnLoadDataTable_Detail(tb, columns_label, columns_data, options);
}

_reporteGeneral.fnInitSabanaSeguimientoAlerta = function () {
    //Activar Filtros
   // _reporteGeneral.frm.find("#dvChkAnioAll").show();
    _reporteGeneral.filterAnioClearAllCheck = function () { /*Deshabilitar evento en este formulario*/ };
    _reporteGeneral.frm.find("#dvFiltroOD").show();
    _reporteGeneral.frm.find("#dvFiltroModalidad").show();
    _reporteGeneral.frm.find("#dvFiltroDepartamento").show(); 
    $("#dvSabanaSeguimientoAlerta").show();

    _reporteGeneral.rpt3InitDataTable();
    //Implementar eventos a ejecutar despúes de realizar una acción
  
    _reporteGeneral.filter_lstChkOdId_change = function () {
        _reporteGeneral.dtSabanaSeguimientoAlerta.clear().draw();
    }
    _reporteGeneral.filter_lstChkModalidadId_change = function () {
        _reporteGeneral.dtSabanaSeguimientoAlerta.clear().draw();
    }
    _reporteGeneral.filter_lstChkDepartamentoId_change = function () {
        _reporteGeneral.dtSabanaSeguimientoAlerta.clear().draw();
    }

    _reporteGeneral.fnSubmitForm = function () {
        _reporteGeneral.dtSabanaSeguimientoAlerta.clear().draw();
        if (_reporteGeneral.filterValidate()) {
            var datosReporte = _reporteGeneral.frm.serializeObject();
            var option = { url: _reporteGeneral.frm.action, datos: JSON.stringify(datosReporte), type: 'POST' };

            utilSigo.fnAjax(option, function (data) {
                if (data.success) {
                    _reporteGeneral.dtSabanaSeguimientoAlerta.rows.add(data.data).draw();
                }
                else {
                    utilSigo.toastWarning("Aviso", utilSigo.MessageError);
                    console.log(data.msj);
                }
            });
        }
        return false;
    }
}
/******************Fin Reporte 3*****************/

/*REPORTE 4 - Sabana Acervo Documentario*/
_reporteGeneral.rpt4InitDataTable = function () {
    var columns_label = [], columns_data = [], options = {};
    var tb = $("#tbSabanaAcervoDocumentario");

    columns_label = [      
        "Ambito Geográfico OD", "Modalidad", "Departamento", "Provincia", "Distrito",
        "Título Habilitante", "Titular", "Número de plan de manejo", " Número de la resolución de aprobación", "Fecha Ingreso SIGOsfc", "Acta Nro", "Fecha",
        "Especialista que verifico el Acervo Documentario", "Contrato de concesión", "Adenda", "Permiso", "Autorización","Resol. SERFOR (bosque local)",
        "De aprobación del plan de manejo", "Cargo de notificación de resol.", "De reingreso", "De movilización de saldos", "Reajuste/ reformulación de plan",
        "PGMF", "PMFI", "PO", "DEMA", "PMCA",
        "Balance de pagos por DA", "Refinanciamiento (resol.)", "Suspensión de obligaciones (resol.)", "Garantías de fiel cumplimiento (vigente)", "Informe de ejecución anual","Informe de ejecución final",
        "GTF al estado natural", "Libro de operación de bosque", "Kardex", "Forma 20", "Balance de extracción","Lista de trozas",
        "Acta de inspección ocular", "Informe de inspección ocular", "Informe que recomienda aprobación del plan", "Contrato con regente", "Contrato con tercero","Denuncias",
        "Incluye CD/DVD", "N° de tomos", "N° de folios", 
        "Concluido", "En Proceso", "Pendiente", "Observaciones" 
    ];

 
    columns_data = ["OD_AMBITO", "MODALIDAD_TIPO", "DEPARTAMENTO", "PROVINCIA", "DISTRITO",
        "NUM_THABILITANTE", "TITULAR", "NOMBRE_POA", "ARESOLUCION_NUM", "FECHA_CREACION", "AD_ACTA_NRO", "AD_FECHA",
        "VERIFICADOR_ACERVO_NOMBRES", "AD_THContrato", "AD_THAdenda", "AD_THPermiso", "AD_THAutorizacion", "AD_THResolucion",
        "AD_REAprobacion", "AD_RECargo", "AD_REReingreso", "AD_REMovilizacion", "AD_REReajuste",
        "AD_DGPGMF", "AD_DGPMFI", "AD_DGPO", "AD_DGDEMA", "AD_DGPMCA",
        "AD_ODBalance", "AD_ODRefinanciamiento", "AD_ODSuspension", "AD_ODGarantias", "AD_ODInfEjecucionAnual",
        "AD_ODInfEjecucionFinal", "AD_EIGTF", "AD_EILibro", "AD_EIKardex", "AD_EIForma20", "AD_EIBalance", "AD_EILista",
        "AD_OTActa", "AD_OTInfInspeccion", "AD_OTInfRecomienda", "AD_OTContratoRegente", "AD_OTContratoTercero", "AD_OTDenuncias",
        "AD_CAIncluyeCD", "AD_CANroTomos", "AD_CANroFolios",
        "AD_RSConcluido", "AD_RSProceso", "AD_RSPendiente", "AD_Observaciones" 
    ];

    options = {
        page_length: 50, button_excel: true, export_title: tb.find("thead tr")[0].innerText.trim()
        , page_search: true, page_info: true, row_index: true, row_data_index: "ROW_INDEX"
    };
    _reporteGeneral.dtSabanaAcervoDocumentario = utilDt.fnLoadDataTable_Detail(tb, columns_label, columns_data, options);

    

}

_reporteGeneral.fnInitSabanaAcervoDocumentario= function () {

    $("#lbTituloGeneral,#lbSubTituloGeneral").html("Reporte Checklist de Contenido Mínimo de Acervo Documentario");
    _reporteGeneral.frm.find("#dvFiltroOD").show();
    _reporteGeneral.frm.find("#dvFiltroModalidad").show();
    _reporteGeneral.frm.find("#dvFiltroDepartamento").show();
    $("#dvSabanaAcervoDocumentario").show();

    _reporteGeneral.rpt4InitDataTable();


    _reporteGeneral.filter_lstChkOdId_change = function () {
        _reporteGeneral.dtSabanaAcervoDocumentario.clear().draw();
    }
    _reporteGeneral.filter_lstChkModalidadId_change = function () {
        _reporteGeneral.dtSabanaAcervoDocumentario.clear().draw();
    }
    _reporteGeneral.filter_lstChkDepartamentoId_change = function () {
        _reporteGeneral.dtSabanaAcervoDocumentario.clear().draw();
    }

    _reporteGeneral.fnSubmitForm = function () {
        _reporteGeneral.dtSabanaAcervoDocumentario.clear().draw();
        if (_reporteGeneral.filterValidate()) {
            var datosReporte = _reporteGeneral.frm.serializeObject();
            var option = { url: _reporteGeneral.frm.action, datos: JSON.stringify(datosReporte), type: 'POST' };

            utilSigo.fnAjax(option, function (data) {
                if (data.success) {
                    _reporteGeneral.dtSabanaAcervoDocumentario.rows.add(data.data).draw();
                }
                else {
                    utilSigo.toastWarning("Aviso", utilSigo.MessageError);
                    console.log(data.msj);
                }
            });
        }
        return false;
    }
}
/******************Fin Reporte 4*****************/

/*REPORTE 5 - Cuadro 5 Paspeq */
//_reporteGeneral.rpt5InitDataTable = function () {
//    var columns_label = [], columns_data = [], options = {};
//    var tb = $("#tbCuadro5Paspeq");

//    columns_label = ["ABREVIADO SUBPER", "MODALIDAD", "AMAZONAS", "ANCASH", "APURIMAC", "AREQUIPA", "AYACUCHO",
//        "CAJAMARCA", "CALLAO", "CUSCO", "HUANUCO", "ICA", "JUNIN", "LA LIBERTAD", "LAMBAYEQUE", "LIMA",
//        "LORETO", "MADRE DE DIOS", "PASCO", "PIURA", "PUNO", "SAN MARTIN", "TACNA", "TUMBES", "UCAYALI", "TOTAL"];

//    columns_data = ["ABREVIADO_SUBPER", "MODALIDAD", "AMAZONAS", "ANCASH", "APURIMAC", "AREQUIPA", "AYACUCHO",
//        "CAJAMARCA", "CALLAO", "CUSCO", "HUANUCO", "ICA", "JUNIN", "LA_LIBERTAD", "LAMBAYEQUE", "LIMA",
//        "LORETO", "MADRE_DE_DIOS", "PASCO", "PIURA", "PUNO", "SAN_MARTIN", "TACNA", "TUMBES", "UCAYALI", "TOTAL"];

//    options = {
//        page_length: 50, button_excel: true, export_title: tb.find("thead tr")[0].innerText.trim()
//        , page_search: true, page_info: true, row_index: false, row_data_index: ""
//    };
//    _reporteGeneral.dtCuadro5Paspeq = utilDt.fnLoadDataTable_Detail(tb, columns_label, columns_data, options);



//}

//_reporteGeneral.fnInitCuadro5Paspeq = function () {

//    _reporteGeneral.frm.find("#dvFiltroFechaCorte").show();
//    _reporteGeneral.frm.find("#dvTxtFechaCorte").show();
//    _reporteGeneral.frm.find("#dvFiltroOD").hide();
//    _reporteGeneral.frm.find("#dvFiltroModalidad").hide();
//    _reporteGeneral.frm.find("#dvFiltroDepartamento").hide();
//    $("#dvCuadro5Paspeq").show();

//    _reporteGeneral.rpt5InitDataTable();

//    _reporteGeneral.fnSubmitForm = function () {
//        _reporteGeneral.dtCuadro5Paspeq.clear().draw();
//        if (_reporteGeneral.filterValidate()) {
//            var datosReporte = _reporteGeneral.frm.serializeObject();
//            var option = { url: _reporteGeneral.frm.action, datos: JSON.stringify(datosReporte), type: 'POST' };

//            utilSigo.fnAjax(option, function (data) {
//                if (data.success) {
//                    _reporteGeneral.dtCuadro5Paspeq.rows.add(data.data).draw();
//                }
//                else {
//                    utilSigo.toastWarning("Aviso", utilSigo.MessageError);
//                    console.log(data.msj);
//                }
//            });
//        }
//        return false;
//    }
//}

/*REPORTE 6 - Cuadro 6 Paspeq */
//_reporteGeneral.rpt6InitDataTable = function () {
//    var columns_label = [], columns_data = [], options = {};
//    var tb = $("#tbCuadro6Paspeq");

//    columns_label = ["ABREVIADO SUBPER", "MODALIDAD", "REGISTRADOS", "APROBADOS EN EL AÑO", "CADUCADOS"];

//    columns_data = ["ABREVIADO_SUBPER", "MODALIDAD", "CANT", "PERIODO", "CADUCADO"];

//    options = {
//        page_length: 50, button_excel: true, export_title: tb.find("thead tr")[0].innerText.trim()
//        , page_search: true, page_info: true, row_index: false, row_data_index: ""
//    };
//    _reporteGeneral.dtCuadro6Paspeq = utilDt.fnLoadDataTable_Detail(tb, columns_label, columns_data, options);

//}

//_reporteGeneral.fnInitCuadro6Paspeq = function () {

//    _reporteGeneral.frm.find("#dvFiltroFechaCorte").show();
//    _reporteGeneral.frm.find("#dvTxtFechaCorte").show();
//    _reporteGeneral.frm.find("#dvFiltroOD").hide();
//    _reporteGeneral.frm.find("#dvFiltroModalidad").hide();
//    _reporteGeneral.frm.find("#dvFiltroDepartamento").hide();
//    $("#dvCuadro6Paspeq").show();

//    _reporteGeneral.rpt6InitDataTable();

//    _reporteGeneral.fnSubmitForm = function () {
//        _reporteGeneral.dtCuadro6Paspeq.clear().draw();
//        if (_reporteGeneral.filterValidate()) {
//            var datosReporte = _reporteGeneral.frm.serializeObject();
//            var option = { url: _reporteGeneral.frm.action, datos: JSON.stringify(datosReporte), type: 'POST' };

//            utilSigo.fnAjax(option, function (data) {
//                if (data.success) {
//                    _reporteGeneral.dtCuadro6Paspeq.rows.add(data.data).draw();
//                }
//                else {
//                    utilSigo.toastWarning("Aviso", utilSigo.MessageError);
//                    console.log(data.msj);
//                }
//            });
//        }
//        return false;
//    }
//}

/*REPORTE 7 - Cuadro 7 Paspeq */
//_reporteGeneral.rpt7InitDataTable = function () {
//    var columns_label = [], columns_data = [], options = {};
//    var tb = $("#tbCuadro7Paspeq");
//    var fechaCorte = _reporteGeneral.frm.find("#txtFechaCorte").val();
//    var periodo1 = (parseInt(fechaCorte.substring(6)) - 3).toString();
//    var periodo2 = (parseInt(fechaCorte.substring(6)) - 2).toString();
//    var periodo3 = (parseInt(fechaCorte.substring(6)) - 1).toString();
//    var periodo4 = fechaCorte.substring(6);

//    columns_label = ["ABREVIADO SUBPER", "OD", "MODALIDAD", "TH", periodo1, periodo2, periodo3, periodo4];
    
//    columns_data = ["ABREVIADO_SUBPER", "OD_AMBITO", "MODALIDAD", "TH", periodo1, periodo2, periodo3, periodo4];

//    options = {
//        page_length: 50, button_excel: true, export_title: tb.find("thead tr")[0].innerText.trim()
//        , page_search: true, page_info: true, row_index: false, row_data_index: ""
//    };
//    _reporteGeneral.dtCuadro7Paspeq = utilDt.fnLoadDataTable_Detail(tb, columns_label, columns_data, options);

//}

//_reporteGeneral.resetCuadro7Paspeq = function () {
//    $("#dvCuadro7Paspeq").html('<div class="form - row"><table id=tbCuadro7Paspeq style=width:100% class="table table-hover table-bordered"><thead><tr><th colspan=53 class=text-sm-left><div class=form-inline><strong>Cuadro N° 7 - Número de títulos habilitantes y planes de manejo por modalidades de aprovechamiento</strong></div></th></tr></thead><tbody></tbody></table></div>');
//}

//_reporteGeneral.fnInitCuadro7Paspeq = function () {

//    _reporteGeneral.frm.find("#dvFiltroFechaCorte").show();
//    _reporteGeneral.frm.find("#dvTxtFechaCorte").show();
//    _reporteGeneral.frm.find("#dvFiltroOD").hide();
//    _reporteGeneral.frm.find("#dvFiltroModalidad").hide();
//    _reporteGeneral.frm.find("#dvFiltroDepartamento").hide();
//    $("#dvCuadro7Paspeq").show();

//    _reporteGeneral.fnSubmitForm = function () {
//        _reporteGeneral.resetCuadro7Paspeq();
//        _reporteGeneral.rpt7InitDataTable();
//        _reporteGeneral.dtCuadro7Paspeq.clear().draw();
//        if (_reporteGeneral.filterValidate()) {
//            var datosReporte = _reporteGeneral.frm.serializeObject();
//            var option = { url: _reporteGeneral.frm.action, datos: JSON.stringify(datosReporte), type: 'POST' };

//            utilSigo.fnAjax(option, function (data) {
//                if (data.success) {
//                    _reporteGeneral.dtCuadro7Paspeq.rows.add(data.data).draw();
//                }
//                else {
//                    utilSigo.toastWarning("Aviso", utilSigo.MessageError);
//                    console.log(data.msj);
//                }
//            });
//        }
//        return false;
//    }
//}

/*REPORTE 8 - Cuadro 8 Paspeq */
//_reporteGeneral.rpt8InitDataTable = function () {
//    var columns_label = [], columns_data = [], options = {};
//    var tb = $("#tbCuadro8Paspeq");
//    var fechaCorte = _reporteGeneral.frm.find("#txtFechaCorte").val();
//    var periodo1 = (parseInt(fechaCorte.substring(6)) - 3).toString();
//    var periodo2 = (parseInt(fechaCorte.substring(6)) - 2).toString();
//    var periodo3 = (parseInt(fechaCorte.substring(6)) - 1).toString();
//    var periodo4 = fechaCorte.substring(6);

//    columns_label = ["ABREVIADO SUBPER", "MODALIDAD", "TH", periodo1, periodo1 + "-PC", periodo2, periodo2 + "-PC", periodo3, periodo3 + "-PC", periodo4, periodo4 + "-PC"];

//    columns_data = ["ABREVIADO_SUBPER", "MODALIDAD", "TH", periodo1, periodo1 + "-PC", periodo2, periodo2 + "-PC", periodo3, periodo3 + "-PC", periodo4, periodo4 + "-PC"];

//    options = {
//        page_length: 50, button_excel: true, export_title: tb.find("thead tr")[0].innerText.trim()
//        , page_search: true, page_info: true, row_index: false, row_data_index: ""
//    };
//    _reporteGeneral.dtCuadro8Paspeq = utilDt.fnLoadDataTable_Detail(tb, columns_label, columns_data, options);

//}

//_reporteGeneral.resetCuadro8Paspeq = function () {
//    $("#dvCuadro8Paspeq").html('<div class="form - row"><table id=tbCuadro8Paspeq style=width:100% class="table table-hover table-bordered"><thead><tr><th colspan=53 class=text-sm-left><div class=form-inline><strong>Cuadro N° 8 - Consolidado de títulos habilitantes y planes de manejo según modalidad de aprovechamiento</strong></div></th></tr></thead><tbody></tbody></table></div>');
//}

//_reporteGeneral.fnInitCuadro8Paspeq = function () {

//    _reporteGeneral.frm.find("#dvFiltroFechaCorte").show();
//    _reporteGeneral.frm.find("#dvTxtFechaCorte").show();
//    _reporteGeneral.frm.find("#dvFiltroOD").hide();
//    _reporteGeneral.frm.find("#dvFiltroModalidad").hide();
//    _reporteGeneral.frm.find("#dvFiltroDepartamento").hide();
//    $("#dvCuadro8Paspeq").show();

//    _reporteGeneral.rpt8InitDataTable();

//    _reporteGeneral.fnSubmitForm = function () {
//        _reporteGeneral.resetCuadro8Paspeq();
//        _reporteGeneral.rpt8InitDataTable();
//        _reporteGeneral.dtCuadro8Paspeq.clear().draw();
//        if (_reporteGeneral.filterValidate()) {
//            var datosReporte = _reporteGeneral.frm.serializeObject();
//            var option = { url: _reporteGeneral.frm.action, datos: JSON.stringify(datosReporte), type: 'POST' };

//            utilSigo.fnAjax(option, function (data) {
//                if (data.success) {
//                    _reporteGeneral.dtCuadro8Paspeq.rows.add(data.data).draw();
//                }
//                else {
//                    utilSigo.toastWarning("Aviso", utilSigo.MessageError);
//                    console.log(data.msj);
//                }
//            });
//        }
//        return false;
//    }
//}


/***************Inicio Reporte 9*****************/
_reporteGeneral.rpt9InitDataTable = function () {
    var columns_label = [], columns_data = [], options = {};
    var tb = $("#tbSeguimientoMedCorrectivas");

    columns_label = [
        "OD Ambito Geográfico", "Modalidad", "Departamento", "Provincia", "Distrito", "Titular", "Título Habilitante", "Documento que dictó la medida correctiva" 
        , "Fecha de notificación", "Plazo para la implementación de MC", "Plazo para la presentación de informe", "Estado PAU", "Variación de MC", "RD Reconsideración"
        , "Resol. TFFS", "Presentó informe de implementación", "Fecha de presentación del informe", "Informe de verificación de MC del OSINFOR"
    ];


    columns_data = ["OD_AMBITO", "MODALIDAD", "DEPARTAMENTO", "PROVINCIA", "DISTRITO", "TITULAR", "NUM_THABILITANTE", "NUM_DOCUMENTO", "FECHA_NOTIFICACION", "PLAZO_IMPLEMENTACION"
        , "PLAZO_INFORME", "ESTADO_PAU", "VARIA_MCORRECTIVA", "NUM_RDREC", "NUM_RTFFS", "CUENTA_INFORME", "FECHA_INFORME", "INFORME_VERIFICACION"
    ];

    options = {
        page_length: 50, button_excel: true, export_title: tb.find("thead tr")[0].innerText.trim()
        , page_search: true, page_info: true, row_index: true, row_data_index: "ROW_INDEX"
    };
    _reporteGeneral.dtSeguimientoMedCorrectivas = utilDt.fnLoadDataTable_Detail(tb, columns_label, columns_data, options);
}

_reporteGeneral.fnInitSeguimientoMedCorrectivas = function () {

    $("#lbTituloGeneral,#lbSubTituloGeneral").html("Reporte de Seguimiento de Medidas Correctivas");
    _reporteGeneral.frm.find("#dvFiltroModalidad").show();
    _reporteGeneral.frm.find("#dvFiltroDepartamento").show();
    $("#dvSeguimientoMedCorrectivas").show();

    _reporteGeneral.rpt9InitDataTable();

    _reporteGeneral.filter_lstChkModalidadId_change = function () {
        _reporteGeneral.dtSeguimientoMedCorrectivas.clear().draw();
    }
    _reporteGeneral.filter_lstChkDepartamentoId_change = function () {
        _reporteGeneral.dtSeguimientoMedCorrectivas.clear().draw();
    }

    _reporteGeneral.fnSubmitForm = function () {
        _reporteGeneral.dtSeguimientoMedCorrectivas.clear().draw();
        if (_reporteGeneral.filterValidate()) {
            var datosReporte = _reporteGeneral.frm.serializeObject();
            var option = { url: _reporteGeneral.frm.action, datos: JSON.stringify(datosReporte), type: 'POST' };

            utilSigo.fnAjax(option, function (data) {
                if (data.success) {
                    _reporteGeneral.dtSeguimientoMedCorrectivas.rows.add(data.data).draw();
                }
                else {
                    utilSigo.toastWarning("Aviso", utilSigo.MessageError);
                    console.log(data.msj);
                }
            });
        }
        return false;
    }
}

/****************Fin Reporte 9*******************/

/***************Inicio Reporte 10*****************/

_reporteGeneral.rpt10InitDataTable = function () {
    var columns_label = [], columns_data = [], options = {};
    var tb = $("#tbObligacionesTitularesMaderables");

    columns_label = [
        "Departamento", "Modalidad", "N° Titulo Habilitante", "Titular", "N° Inf Supervision", "Fec. Inicio de Supervisión", "Oportunidad de la Supervision", "Obligacion 1 (2 pts.)",// "Obligacion 1_1 (2 pts.)", "Obligacion 1_2 (2 pts.)",
        "Obligacion 2 (1 pts.)", "Obligacion 3 (5 pts.)", "Obligacion 4 (3 pts.)", "Obligacion 5 (2 pts.)", "Obligacion 6 (2 pts.)", "Obligacion 7 (3 pts.)", "Obligacion 8 (2 pts.)", "Obligacion 9 (0 pts.)", "Obligacion 10 (1 pts.)", "Obligacion 11 (3 pts.)", "Obligacion 12 (0 pts.)",
        "Obligacion 13 (1 pts.)", "Obligacion 14 (2 pts.)", "Obligacion 15 (3 pts.)", "Obligacion 16 (2 pts.)", "Obligacion 17 (4 pts.)", "Obligacion 18 (2 pts.)", "Obligacion 19 (2 pts.)", "Obligacion 20 (3 pts.)", "Obligacion 21 (0 pts.)", "Obligacion 22 (0 pts.)",
        "Obligacion 23 (2 pts.)", "Obligacion 24 (3 pts.)","Resultado (Si)", "Denominador (Si y No)", "Indice", "Cumplimiento"
    ];


    columns_data = ["DEPARTAMENTO", "MODALIDAD_TIPO", "NUM_THABILITANTE", "TITULAR", "INFORME", "FECHA_SUPERVISION_INICIO", "OPORTUNIDAD_SUPERVISION", "OBLI_PRESENTOPLANMANEJO", //"OBLI_PRESENTOPLANMANEJO_01", "OBLI_PRESENTOPLANMANEJO_02",
        "OBLI_PRESENTOPLANMANEJOCONFORMIDAD", "OBLI_PAGOAPROVECHAMIENTO", "OBLI_MANTIENELIBROOPERACIONES", "OBLI_COMUNICOARFFSOSINFORSUSCRIPCION", "OBLI_REPORTOARFFSMINISTERIOAVISTAMIENTOS",
        "OBLI_REALIZOACCIONESCUSTODIO", "OBLI_FACILITODESARROLLO", "OBLI_ASUMIOCOSTOSUPERVISIONES", "OBLI_IMPLEMENTAMECANISMOTRAZA", "OBLI_RESPETASERVIDUMBRE", "OBLI_CUENTAREGENTE",
        "OBLI_ADOPTAMEDIDASEXTENSION", "OBLI_RESPETAVALORES", "OBLI_CUMPLEMEDIDAS", "OBLI_CUMPLENORMAS", "OBLI_MOVILIZAFRUTOPRODUCTOS", "OBLI_CUMPLEMARCADOTROZAS", "OBLI_ESTABLECELINDEROS",
        "OBLI_IMPLEMENTACIONMEDIDASCORRECTIVAS", "OBLI_PROMUEVENBUENASPRACTICAS", "OBLI_PROMUEVEEQUIDAD", "OBLI_MANTIENEVIGENTEGARANTIA", "OBLI_CUMPLECOMPROMISOINVERSION"
        , "RESULTADO", "DENOMINADOR", "INDICE", "CUMPLIMIENTO"
    ];

    options = {
        page_length: 10, button_excel: false, export_title: tb.find("thead tr")[0].innerText.trim()
        , page_search: true, page_info: true, row_index: true, row_data_index: "ROW_INDEX", length_Change: true
    };
    _reporteGeneral.dtObligacionesTitularesMaderables = utilDt.fnLoadDataTable_Detail(tb, columns_label, columns_data, options);
}
_reporteGeneral.rpt10InitDataTable_NEW = function () {
    var columns_label = [], columns_data = [], options = {};
    var tb = $("#tbObligacionesTitularesMaderables_new");

    columns_label = [
        "Departamento", "Modalidad", "N° Titulo Habilitante", "Titular", "N° Inf Supervision", "Fec. Inicio de Supervisión", "Oportunidad de la Supervision", "Obligacion 1 (2 pts.)","Obligacion 2 (2 pts.)",
        "Obligacion 3 (1 pts.)", "Obligacion 4 (1 pts.)", "Obligacion 5 (5 pts.)", "Obligacion 6 (2 pts.)", "Obligacion 7 (2 pts.)","Obligacion 8 (2 pts.)", "Obligacion 9 (0 pts.)", "Obligacion 10 (2 pts.)", "Obligacion 11 (3 pts.)", "Obligacion 12 (2 pts.)", "Obligacion 13 (0 pts.)", "Obligacion 14 (1 pts.)", "Obligacion 15 (3 pts.)",
        "Obligacion 16 (0 pts.)", "Obligacion 17 (0 pts.)", "Obligacion 18 (1 pts.)", "Obligacion 19 (2 pts.)", "Obligacion 20 (3 pts.)", "Obligacion 21 (2 pts.)", "Obligacion 22 (4 pts.)", "Obligacion 23 (2 pts.)", "Obligacion 24 (2 pts.)", "Obligacion 25 (3 pts.)",
        "Obligacion 26 (0 pts.)", "Obligacion 27 (0 pts.)", "Obligacion 28 (2 pts.)", "Obligacion 29 (3 pts.)", "Resultado (Si)", "Denominador (Si y No)", "Indice", "Cumplimiento"
    ];
    /*columns_label = [
        "Departamento", "Modalidad", "N° Titulo Habilitante", "Titular", "N° Inf Supervision", "Fec. Inicio de Supervisión", "Oportunidad de la Supervision", "Obligacion 1 (2 pts.)", "Obligacion 2 (2 pts.)",
        "Obligacion 3 (1 pts.)", "Obligacion 4 (1 pts.)", "Obligacion 5 (5 pts.)", "Obligacion 6 (2 pts.)", "Obligacion 7 (2 pts.)", "Obligacion 8 (2 pts.)", "Obligacion 9 (2 pts.)", "Obligacion 10 (3 pts.)", "Obligacion 11 (2 pts.)", "Obligacion 12 (0 pts.)", "Obligacion 13 (1 pts.)", "Obligacion 14 (3 pts.)", "Obligacion 15 (0 pts.)",
        "Obligacion 16 (1 pts.)", "Obligacion 17 (2 pts.)", "Obligacion 18 (3 pts.)", "Obligacion 19 (2 pts.)", "Obligacion 20 (4 pts.)", "Obligacion 21 (2 pts.)", "Obligacion 22 (2 pts.)", "Obligacion 23 (3 pts.)", "Obligacion 24 (0 pts.)", "Obligacion 25 (0 pts.)",
        "Obligacion 26 (2 pts.)", "Obligacion 27 (3 pts.)", "Resultado (Si)", "Denominador (Si y No)", "Indice", "Cumplimiento"
    ];*/


    columns_data = ["DEPARTAMENTO", "MODALIDAD_TIPO", "NUM_THABILITANTE", "TITULAR", "INFORME", "FECHA_SUPERVISION_INICIO", "OPORTUNIDAD_SUPERVISION", "OBLI_PRESENTOPLANMANEJO_01", "OBLI_PRESENTOPLANMANEJO_02",
        "OBLI_PRESENTOPLANMANEJOCONFORMIDAD_01", "OBLI_PRESENTOPLANMANEJOCONFORMIDAD_02", "OBLI_PAGOAPROVECHAMIENTO", "OBLI_MANTIENELIBROOPERACIONES_01", "OBLI_MANTIENELIBROOPERACIONES_02", "OBLI_COMUNICOARFFSOSINFORSUSCRIPCION",
        "OBLI_COMUNICOARFFSOSINFORSUSCRIPCION_2", "OBLI_REPORTOARFFSMINISTERIOAVISTAMIENTOS",
        "OBLI_REALIZOACCIONESCUSTODIO", "OBLI_FACILITODESARROLLO", "OBLI_ASUMIOCOSTOSUPERVISIONES", "OBLI_IMPLEMENTAMECANISMOTRAZA", "OBLI_RESPETASERVIDUMBRE", "OBLI_CUENTAREGENTE", "OBLI_CUENTAREGENTE_2",
        "OBLI_ADOPTAMEDIDASEXTENSION", "OBLI_RESPETAVALORES", "OBLI_CUMPLEMEDIDAS", "OBLI_CUMPLENORMAS", "OBLI_MOVILIZAFRUTOPRODUCTOS", "OBLI_CUMPLEMARCADOTROZAS", "OBLI_ESTABLECELINDEROS",
        "OBLI_IMPLEMENTACIONMEDIDASCORRECTIVAS", "OBLI_PROMUEVENBUENASPRACTICAS", "OBLI_PROMUEVEEQUIDAD", "OBLI_MANTIENEVIGENTEGARANTIA", "OBLI_CUMPLECOMPROMISOINVERSION"
        , "RESULTADO", "DENOMINADOR", "INDICE", "CUMPLIMIENTO"
    ];

    options = {
        page_length: 10, button_excel: false, export_title: tb.find("thead tr")[0].innerText.trim()
        , page_search: true, page_info: true, row_index: true, row_data_index: "ROW_INDEX", length_Change: true
    };
    _reporteGeneral.dtObligacionesTitularesMaderables_new = utilDt.fnLoadDataTable_Detail(tb, columns_label, columns_data, options);
}

_reporteGeneral.fnInitObligacionesTitularesMaderables = function () {

    var data_ini = _reporteGeneral.frm.serializeObject();
    $('.FechaCorte').text(data_ini.txtFechaCorte);
    /*Reporte individual
     $("#lbTituloGeneral,#lbSubTituloGeneral").html("Reporte de Obligaciones de los Titulares - Maderables");
    _reporteGeneral.frm.find("#dvFiltroModalidad").show();

    $("#dvObligacionesTitularesMaderables,dvObligacionesTitularesNoMaderables").show();
     _reporteGeneral.rpt11InitDataTable();
     _reporteGeneral.filter_lstChkModalidadId_change = function () {
    _reporteGeneral.dtObligacionesTitularesMaderables.clear().draw();
    }*/

    //******Fusionando las 2 consultas***////
    $("#lbTituloGeneral,#lbSubTituloGeneral").html("Reporte de Obligaciones de los Titulares ");
    _reporteGeneral.frm.find("#dvFiltroModalidad").show();
    _reporteGeneral.frm.find("#alerta-rptobl").show();

    
     _reporteGeneral.rpt10InitDataTable_NEW();
     _reporteGeneral.rpt10InitDataTable();
    _reporteGeneral.rpt11InitDataTable();
    _reporteGeneral.rpt11InitDataTable_NEW();
    _reporteGeneral.rptOTFInitDataTable();
    _reporteGeneral.rptOTFInitDataTable_new();

    _reporteGeneral.filter_lstChkModalidadId_change = function () {
        _reporteGeneral.dtObligacionesTitularesMaderables.clear().draw();
        _reporteGeneral.dtObligacionesTitularesMaderables_new.clear().draw();
        _reporteGeneral.dtObligacionesTitularesNoMaderables.clear().draw();
        _reporteGeneral.dtObligacionesTitularesNoMaderables_new.clear().draw();
        _reporteGeneral.dtObligacionesTitularesFauna.clear().draw();
        _reporteGeneral.dtObligacionesTitularesFauna_new.clear().draw();
    }
    _reporteGeneral.lstNM = [], _reporteGeneral.lstM = [], _reporteGeneral.lstFauna = [];
    _reporteGeneral.fnSubmitForm = function () {
       
        _reporteGeneral.dtObligacionesTitularesMaderables.clear().draw();
        _reporteGeneral.dtObligacionesTitularesMaderables_new.clear().draw();
        _reporteGeneral.dtObligacionesTitularesNoMaderables.clear().draw();
        _reporteGeneral.dtObligacionesTitularesNoMaderables_new.clear().draw();
        _reporteGeneral.dtObligacionesTitularesFauna.clear().draw();
        _reporteGeneral.dtObligacionesTitularesFauna_new.clear().draw();
        if (_reporteGeneral.filterValidate()) {
            var datosReporte = _reporteGeneral.frm.serializeObject();
            datosReporte.txtFechaCorte = null;
            

            if (!$('#chbNewRpt').is(":checked")) datosReporte.txtFechaCorte = '1';
            
            var option = { url: _reporteGeneral.frm.action, datos: JSON.stringify(datosReporte), type: 'POST' };
            
          
            utilSigo.fnAjax(option, function (data) {
                if (data.success) {
                    _reporteGeneral.lstM = data.data;
                    
                    if (!$('#chbNewRpt').is(":checked")) {
                    _reporteGeneral.dtObligacionesTitularesMaderables_new.rows.add(_reporteGeneral.lstM).draw();
                        $("#tbtbloblig").hide(); $("#tbtbloblig_new").show();
                    }
                    else {
                        _reporteGeneral.dtObligacionesTitularesMaderables.rows.add(_reporteGeneral.lstM).draw();
                        $("#tbtbloblig_new").hide(); $("#tbtbloblig").show();

                    }
                    
                    $("#dvObligacionesTitularesMaderables").show();
                }
                else {
                    utilSigo.toastWarning("Aviso", utilSigo.MessageError);
                    console.log(data.msj);
                }
            });
            var d = { hdfTipoReporte: 'OBLIGACIONES_TIT_NO_MADERABLE', lstChkModalidadId: datosReporte.lstChkModalidadId, txtFechaCorte: !$('#chbNewRpt').is(":checked")?'1':null };
            var optionNM = { url: _reporteGeneral.frm.action, datos: JSON.stringify(d), type: 'POST' };
             utilSigo.fnAjax(optionNM, function (data) {
                 if (data.success) {
                     _reporteGeneral.lstNM = data.data;
                     //_reporteGeneral.dtObligacionesTitularesNoMaderables.rows.add(_reporteGeneral.lstNM).draw();
                     if (!$('#chbNewRpt').is(":checked")) {
                         _reporteGeneral.dtObligacionesTitularesNoMaderables_new.rows.add(_reporteGeneral.lstNM).draw();
                         $("#tbtblobligNM").hide(); $("#tbtblobligNM_new").show();
                     }
                     else {
                         _reporteGeneral.dtObligacionesTitularesNoMaderables.rows.add(_reporteGeneral.lstNM).draw();
                         $("#tbtblobligNM_new").hide(); $("#tbtblobligNM").show();

                     }
                     $("#dvObligacionesTitularesNoMaderables").show();
                }
                else {
                    utilSigo.toastWarning("Aviso", utilSigo.MessageError);
                    console.log(data.msj);
                }
             });
             d = { hdfTipoReporte: 'OBLIGACIONES_TIT_FAUNA', lstChkModalidadId: datosReporte.lstChkModalidadId, txtFechaCorte: !$('#chbNewRpt').is(":checked") ? '1' : null };
            var optionfauna = { url: _reporteGeneral.frm.action, datos: JSON.stringify(d), type: 'POST' };
            utilSigo.fnAjax(optionfauna, function (data) {
                
                if (data.success) {
                    _reporteGeneral.lstFauna = data.data;
                    if (!$('#chbNewRpt').is(":checked")) {
                        _reporteGeneral.dtObligacionesTitularesFauna_new.rows.add(_reporteGeneral.lstFauna).draw();
                        $("#tbtblobligFauna").hide(); $("#tbtblobligFauna_new").show();
                    }
                    else {
                        _reporteGeneral.dtObligacionesTitularesFauna.rows.add(_reporteGeneral.lstFauna).draw();
                        $("#tbtblobligFauna_new").hide(); $("#tbtblobligFauna").show();
                    }
                    $("#dvObligacionesTitularesFauna").show();
                }
                else {
                    utilSigo.toastWarning("Aviso", utilSigo.MessageError);
                    console.log(data.msj);
                }
            });

           
        }
        return false;
    }

    _reporteGeneral.fnExportResumen = function (index) {
        var url = urlLocalSigo + "General/Reportes/RptObligacionesTitulares";
        if (index == 1) {
            if (_reporteGeneral.lstM.length == 0) {
                utilSigo.toastWarning("Aviso", "Por favor debe existir datos dentro de la tabla"); return;
            }
            
        }
        if (index == 2) {
            if (_reporteGeneral.lstNM.length == 0) {
                utilSigo.toastWarning("Aviso", "Por favor debe existir datos dentro de la tabla"); return;
            }
           
        }
        let params = {
            cabecera: {
                Titulo: "OBLIGACIONES_TITULARES"
            },
            resumen: index == 1 ? _reporteGeneral.lstM : _reporteGeneral.lstNM,
            opcion: index == 1 ? (!$('#chbNewRpt').is(":checked") ? '_new' : '') : (!$('#chbNewRpt').is(":checked") ? 'NM_new' : 'NM')
        };

        $.ajax({
            type: 'post',
            url: url,
            data: JSON.stringify(params),
            contentType: 'application/json',
            beforeSend: function () {utilSigo.beforeSendAjax();},
            dataType: 'binary',
            xhrFields: {
                'responseType': 'blob'
            },
        }).done(function (result) {
            var a = $("<a style='display: none;'/>");
            var url = window.URL.createObjectURL(new Blob([result]));
            a.attr("href", url);
            a.attr("download", 'Reporte de Obligaciones Titulares.xlsx');
            $("body").append(a);
            a[0].click();
            window.URL.revokeObjectURL(url);
            a.remove();
            utilSigo.unblockUIGeneral(); 
        });
    }
    _reporteGeneral.fnExportResumenFauna = function () {
        var url = urlLocalSigo + "General/Reportes/RptObligacionesTitularesFauna";
        if (_reporteGeneral.lstFauna.length == 0) {
            utilSigo.toastWarning("Aviso", "Por favor debe existir datos dentro de la tabla"); return;
        }
        let params = {
            cabecera: {
                Titulo: "OBLIGACIONES_TITULARES"
            },
            resumen: _reporteGeneral.lstFauna,
            opcion:  !$('#chbNewRpt').is(":checked") ? '_new' : ''
        };

        $.ajax({
            type: 'post',
            url: url,
            data: JSON.stringify(params),
            contentType: 'application/json',
            beforeSend: function () { utilSigo.beforeSendAjax(); },
            dataType: 'binary',
            xhrFields: {
                'responseType': 'blob'
            },
        }).done(function (result) {
            var a = $("<a style='display: none;'/>");
            var url = window.URL.createObjectURL(new Blob([result]));
            a.attr("href", url);
            a.attr("download", 'Reporte de Obligaciones Titulares Fauna.xlsx');
            $("body").append(a);
            a[0].click();
            window.URL.revokeObjectURL(url);
            a.remove();
            utilSigo.unblockUIGeneral();
        });
    }
}

/****************Fin Reporte 10*******************/

/***************Inicio Reporte 11*****************/

_reporteGeneral.rpt11InitDataTable = function () {
    var columns_label = [], columns_data = [], options = {};
    var tb = $("#tbObligacionesTitularesNoMaderables");

    columns_label = [
        "Departamento", "Modalidad", "N° Titulo Habilitante", "Titular", "N° Inf Supervision", "Fec. Inicio de Supervisión", "Oportunidad de la Supervision", "Obligacion 1 (2 pts.)",
        "Obligacion 2 (1 pts.)", "Obligacion 3 (5 pts.)", "Obligacion 4 (2 pts.)", "Obligacion 5 (2 pts.)", "Obligacion 6 (3 pts.)", "Obligacion 7 (2 pts.)", "Obligacion 8 (0 pts.)", "Obligacion 9 (1 pts.)", "Obligacion 10 (3 pts.)", "Obligacion 11 (1 pts.)", "Obligacion 12 (2 pts.)",
        "Obligacion 13 (3 pts.)", "Obligacion 14 (2 pts.)", "Obligacion 15 (4 pts.)", "Obligacion 16 (3 pts.)", "Obligacion 17 (3 pts.)", "Obligacion 18 (0 pts.)", "Obligacion 19 (0 pts.)"
        , "Resultado (Si)", "Denominador (Si y No)", "Indice (%)", "Cumplimiento"
    ];


    columns_data = ["DEPARTAMENTO", "MODALIDAD_TIPO", "NUM_THABILITANTE", "TITULAR", "INFORME", "FECHA_SUPERVISION_INICIO", "OPORTUNIDAD_SUPERVISION", "OBLI_NM_PRESENTOPMF", "OBLI_NM_PRESENTOINFORMEEJECUCION",
        "OBLI_NM_PAGOAPROVECHAMIENTO", "OBLI_NM_COMUNICOARFFSOSINFORSUSCRIPCION", "OBLI_NM_REPORTOARFFSMINISTERIOAVISTAMIENTOS", "OBLI_NM_REALIZOACCIONESCUSTODIO",
        "OBLI_NM_FACILITODESARROLLO", "OBLI_NM_ASUMIOCOSTOSUPERVISIONES", "OBLI_NM_IMPLEMENTAMECANISMOTRAZA", "OBLI_NM_RESPETASERVIDUMBRE", "OBLI_NM_ADOPTAMEDIDASEXTENSION",
        "OBLI_NM_RESPETAVALORES", "OBLI_NM_CUMPLEMEDIDAS", "OBLI_NM_CUMPLENORMAS", "OBLI_NM_MOVILIZAFRUTOPRODUCTOS", "OBLI_NM_IMPLEMENTACIONMEDIDASCORRECTIVAS",
        "OBLI_NM_IMPMEDCORRECRESULTADOACCIONES", "OBLI_NM_PROMUEVENBUENASPRACTICAS", "OBLI_NM_PROMUEVEEQUIDAD","RESULTADO","DENOMINADOR","INDICE","CUMPLIMIENTO"
    ];

    options = {
        page_length: 10, button_excel: false, export_title: tb.find("thead tr")[0].innerText.trim()
        , page_search: true, page_info: true, row_index: true, row_data_index: "ROW_INDEX", length_Change:true
    };

    _reporteGeneral.dtObligacionesTitularesNoMaderables = utilDt.fnLoadDataTable_Detail(tb, columns_label, columns_data, options);
}
_reporteGeneral.rpt11InitDataTable_NEW = function () {
    var columns_label = [], columns_data = [], options = {};
    var tb = $("#tbObligacionesTitularesNoMaderables_new");

    columns_label = [
        "Departamento", "Modalidad", "N° Titulo Habilitante", "Titular", "N° Inf Supervision", "Fec. Inicio de Supervisión", "Oportunidad de la Supervision", "Obligacion 1 (2 pts.)", "Obligacion 2 (0 pts.)",
        "Obligacion 3 (1 pts.)", "Obligacion 4 (0 pts.)", "Obligacion 5 (5 pts.)", "Obligacion 6 (0 pts.)", "Obligacion 7 (0 pts.)", "Obligacion 8 (2 pts.)", "Obligacion 9 (0 pts.)", "Obligacion 10 (2 pts.)",
        "Obligacion 11 (3 pts.)", "Obligacion 12 (2 pts.)", "Obligacion 13 (0 pts.)", "Obligacion 14 (1 pts.)", "Obligacion 15 (3 pts.)", "Obligacion 16 (0 pts.)", "Obligacion 17 (0 pts.)", "Obligacion 18 (1 pts.)",
        "Obligacion 19 (2 pts.)", "Obligacion 20 (3 pts.)", "Obligacion 21 (2 pts.)", "Obligacion 22 (4 pts.)", "Obligacion 23 (0 pts.)", "Obligacion 24 (0 pts.)", "Obligacion 25 (3 pts.)", "Obligacion 26 (0 pts.)",
        "Obligacion 27 (0 pts.)", "Obligacion 28 (3 pts.)", "Obligacion 29 (0 pts.)"
        , "Resultado (Si)", "Denominador (Si y No)", "Indice (%)", "Cumplimiento"
    ];
    /*
     columns_label = [
        "Departamento", "Modalidad", "N° Titulo Habilitante", "Titular", "N° Inf Supervision", "Fec. Inicio de Supervisión", "Oportunidad de la Supervision", "Obligacion 1 (2 pts.)",
        "Obligacion 2 (1 pts.)", "Obligacion 3 (5 pts.)", "Obligacion 4 (2 pts.)", "Obligacion 5 (2 pts.)", "Obligacion 6 (3 pts.)", "Obligacion 7 (2 pts.)", "Obligacion 8 (0 pts.)", "Obligacion 9 (1 pts.)", "Obligacion 10 (3 pts.)", "Obligacion 11 (1 pts.)", "Obligacion 12 (2 pts.)",
        "Obligacion 13 (3 pts.)", "Obligacion 14 (2 pts.)", "Obligacion 15 (4 pts.)", "Obligacion 16 (3 pts.)", "Obligacion 17 (3 pts.)", "Obligacion 18 (0 pts.)", "Obligacion 19 (0 pts.)", "Obligacion 20 (3 pts.)"
        , "Resultado (Si)", "Denominador (Si y No)", "Indice (%)", "Cumplimiento"
    ];
     */

    columns_data = ["DEPARTAMENTO", "MODALIDAD_TIPO", "NUM_THABILITANTE", "TITULAR", "INFORME", "FECHA_SUPERVISION_INICIO", "OPORTUNIDAD_SUPERVISION", "OBLI_NM_PRESENTOPMF", "OBLI_NM_PRESENTOPMF_2",
        "OBLI_NM_PRESENTOINFORMEEJECUCION", "OBLI_NM_PRESENTOINFORMEEJECUCION_2", "OBLI_NM_PAGOAPROVECHAMIENTO", "OBLI_NM_SERFOR_1", "OBLI_NM_SERFOR_2", "OBLI_NM_COMUNICOARFFSOSINFORSUSCRIPCION",
        "OBLI_NM_COMUNICOARFFSOSINFORSUSCRIPCION_2", "OBLI_NM_REPORTOARFFSMINISTERIOAVISTAMIENTOS", "OBLI_NM_REALIZOACCIONESCUSTODIO","OBLI_NM_FACILITODESARROLLO", "OBLI_NM_ASUMIOCOSTOSUPERVISIONES",
        "OBLI_NM_IMPLEMENTAMECANISMOTRAZA", "OBLI_NM_RESPETASERVIDUMBRE", "OBLI_NM_IMPLEMENTAPLAN", "OBLI_NM_REGENTE", "OBLI_NM_ADOPTAMEDIDASEXTENSION",
        "OBLI_NM_RESPETAVALORES", "OBLI_NM_CUMPLEMEDIDAS", "OBLI_NM_CUMPLENORMAS", "OBLI_NM_MOVILIZAFRUTOPRODUCTOS", "OBLI_NM_MARCADOTROZA", "OBLI_NM_MANTIENELINDERO",
        "OBLI_NM_IMPMEDCORRECRESULTADOACCIONES", "OBLI_NM_PROMUEVENBUENASPRACTICAS", "OBLI_NM_PROMUEVEEQUIDAD", "OBLI_NM_MANTIENEACTGRTIA", "OBLI_NM_COMPROMISOINVERSION", "RESULTADO", "DENOMINADOR", "INDICE", "CUMPLIMIENTO"
    ];

    options = {
        page_length: 10, button_excel: false, export_title: tb.find("thead tr")[0].innerText.trim()
        , page_search: true, page_info: true, row_index: true, row_data_index: "ROW_INDEX", length_Change: true
    };

    _reporteGeneral.dtObligacionesTitularesNoMaderables_new = utilDt.fnLoadDataTable_Detail(tb, columns_label, columns_data, options);
}

_reporteGeneral.fnInitObligacionesTitularesNoMaderables = function () {

    $("#lbTituloGeneral,#lbSubTituloGeneral").html("Reporte de Obligaciones de los Titulares - No Maderables");
    _reporteGeneral.frm.find("#dvFiltroModalidad").show();
    $("#dvObligacionesTitularesNoMaderables").show();

    _reporteGeneral.rpt11InitDataTable();

    _reporteGeneral.filter_lstChkModalidadId_change = function () {
        _reporteGeneral.dtObligacionesTitularesNoMaderables.clear().draw();
    }

    _reporteGeneral.fnSubmitForm = function () {
        _reporteGeneral.dtObligacionesTitularesNoMaderables.clear().draw();
        if (_reporteGeneral.filterValidate()) {
            var datosReporte = _reporteGeneral.frm.serializeObject();
            var option = { url: _reporteGeneral.frm.action, datos: JSON.stringify(datosReporte), type: 'POST' };

            utilSigo.fnAjax(option, function (data) {
                if (data.success) {
                    _reporteGeneral.dtObligacionesTitularesNoMaderables.rows.add(data.data).draw();
                }
                else {
                    utilSigo.toastWarning("Aviso", utilSigo.MessageError);
                    console.log(data.msj);
                }
            });
        }
        return false;
    }
}

/****************Fin Reporte 11*******************/


/*********REPORTE OBLIGACIONES TITULARES FAUNA */
_reporteGeneral.rptOTFInitDataTable_new = function () {
    var columns_label = [], columns_data = [], options = {};
    var tb = $("#tbObligacionesTitularesFauna_new");

    columns_label = [
        "Departamento", "Modalidad", "N° Titulo Habilitante", "Titular", "N° Inf Supervision", "Fec. Inicio de Supervisión", "Oportunidad de la Supervision", "Obligacion 1 (4 pts.)",
        "Obligacion 2 (0 pts.)", "Obligacion 3 (1 pts.)", "Obligacion 4 (0 pts.)",
        "Obligacion 5 (2 pts.)", "Obligacion 6 (4 pts.)", "Obligacion 7 (0 pts.)", "Obligacion 8 (3 pts.)", "Obligacion 9 (4 pts.)", "Obligacion 10 (3 pts.)", "Obligacion 11 (4 pts.)", "Obligacion 12 (3 pts.)",
        "Obligacion 13 (2 pts.)",
        "Obligacion 14 (3 pts.)", "Obligacion 15 (2 pts.)", "Obligacion 16 (2 pts.)", "Obligacion 17 (0 pts.)", "Obligacion 18 (2 pts.)", "Obligacion 19 (2 pts.)",
        "Obligacion 20 (4 pts.)", "Obligacion 21 (2 pts.)", "Obligacion 22 (3 pts.)", "Obligacion 23 (3 pts.)", "Obligacion 24 (4 pts.)", "Obligacion 25 (4 pts.)", "Obligacion 26 (5 pts.)",
        "Obligacion 27 (4 pts.)", "Obligacion 28 (3 pts.)", "Obligacion 29 (3 pts.)", "Obligacion 30 (3 pts.)", "Obligacion 31 (4 pts.)", "Obligacion 32 (3 pts.)",
        "Obligacion 33 (2 pts.)", "Obligacion 34 (3 pts.)", "Obligacion 35 (3 pts.)", "Obligacion 36 (3 pts.)", "Obligacion 37 (3 pts.)", "Obligacion 38 (3 pts.)",
        "Puntaje Total (Si)", "Total de Obligaciones  (Si y No)", "Indice", "Cumplimiento"
    ];


    columns_data = ["DEPARTAMENTO", "MODALIDAD_TIPO", "NUM_THABILITANTE", "TITULAR", "INFORME", "FECHA_SUPERVISION_INICIO", "OPORTUNIDAD_SUPERVISION",
        "OBLIG_01", "OBLIG_001", "OBLIG_02", "OBLIG_002", "OBLIG_03", "OBLIG_04", "OBLIG_004", "OBLIG_05", "OBLIG_06", "OBLIG_07", "OBLIG_08", "OBLIG_09", "OBLIG_10", "OBLIG_11", "OBLIG_12", "OBLIG_13", "OBLIG_013", "OBLIG_14",
        "OBLIG_15", "OBLIG_16", "OBLIG_17", "OBLIG_18", "OBLIG_19", "OBLIG_20", "OBLIG_21", "OBLIG_22", "OBLIG_23", "OBLIG_24", "OBLIG_25", "OBLIG_26", "OBLIG_27", "OBLIG_28",
        "OBLIG_29", "OBLIG_30", "OBLIG_31", "OBLIG_32", "OBLIG_33", "OBLIG_34"
        , "RESULTADO", "DENOMINADOR", "INDICE", "CUMPLIMIENTO"
    ];

    options = {
        page_length: 10, button_excel: false, export_title: tb.find("thead tr")[0].innerText.trim()
        , page_search: true, page_info: true, row_index: true, row_data_index: "ROW_INDEX", length_Change: true
    };
    _reporteGeneral.dtObligacionesTitularesFauna_new = utilDt.fnLoadDataTable_Detail(tb, columns_label, columns_data, options);
}
_reporteGeneral.rptOTFInitDataTable = function () {
    var columns_label = [], columns_data = [], options = {};
    var tb = $("#tbObligacionesTitularesFauna");

    columns_label = [
        "Departamento", "Modalidad", "N° Titulo Habilitante", "Titular", "N° Inf Supervision", "Fec. Inicio de Supervisión", "Oportunidad de la Supervision", "Obligacion 1 (4 pts.)", "Obligacion 2 (1 pts.)",
        "Obligacion 3 (2 pts.)", "Obligacion 4 (4 pts.)", "Obligacion 5 (3 pts.)", "Obligacion 6 (4 pts.)", "Obligacion 7 (3 pts.)", "Obligacion 8 (4 pts.)", "Obligacion 9 (3 pts.)", "Obligacion 10 (2 pts.)", "Obligacion 11 (3 pts.)", "Obligacion 12 (2 pts.)", "Obligacion 13 (2 pts.)", "Obligacion 14 (2 pts.)", "Obligacion 15 (2 pts.)",
        "Obligacion 16 (4 pts.)", "Obligacion 17 (2 pts.)", "Obligacion 18 (3 pts.)", "Obligacion 19 (3 pts.)", "Obligacion 20 (4 pts.)", "Obligacion 21 (4 pts.)", "Obligacion 22 (5 pts.)", "Obligacion 23 (4 pts.)", "Obligacion 24 (3 pts.)", "Obligacion 25 (3 pts.)", "Obligacion 26 (3 pts.)", "Obligacion 27 (4 pts.)", "Obligacion 28 (3 pts.)",
        "Obligacion 29 (2 pts.)", "Obligacion 30 (3 pts.)",
        "Puntaje Total (Si)", "Total de Obligaciones  (Si y No)", "Indice", "Cumplimiento"
    ];


    columns_data = ["DEPARTAMENTO", "MODALIDAD_TIPO", "NUM_THABILITANTE", "TITULAR", "INFORME", "FECHA_SUPERVISION_INICIO", "OPORTUNIDAD_SUPERVISION",
        "OBLIG_01", "OBLIG_02", "OBLIG_03", "OBLIG_04", "OBLIG_05", "OBLIG_06", "OBLIG_07", "OBLIG_08", "OBLIG_09", "OBLIG_10", "OBLIG_11", "OBLIG_12", "OBLIG_13", "OBLIG_14", "OBLIG_15", "OBLIG_16", "OBLIG_17", "OBLIG_18", "OBLIG_19", "OBLIG_20", "OBLIG_21", "OBLIG_22", "OBLIG_23", "OBLIG_24", "OBLIG_25", "OBLIG_26", "OBLIG_27", "OBLIG_28", "OBLIG_29", "OBLIG_30"
        , "RESULTADO", "DENOMINADOR", "INDICE", "CUMPLIMIENTO"
    ];

    options = {
        page_length: 10, button_excel: false, export_title: tb.find("thead tr")[0].innerText.trim()
        , page_search: true, page_info: true, row_index: true, row_data_index: "ROW_INDEX", length_Change: true
    };
    _reporteGeneral.dtObligacionesTitularesFauna = utilDt.fnLoadDataTable_Detail(tb, columns_label, columns_data, options);
}
/********FIN DE REPORTE OBLIGACIONES TITULARES FAUNA  */


/***************Inicio Reporte 12*****************/
_reporteGeneral.rpt12InitDataTable = function () {
    var columns_label = [], columns_data = [], options = {};
    var tb = $("#tbReporteControlCalidad");

    columns_label = [
        "Tipo Documento SIGOsfc","Oficina Desconcentrada", "Documento", "Fecha Registro", "Mes Registro", "Responsable Registro", "Fecha Control Calidad", "Responsable Control Calidad"
        , "Estado Documento", "Estado Observación", "Tipo Documento"        
    ];


    columns_data = ["TIPO_DOCUMENTO_SIGO","OD", "DOCUMENTO", "FECHA_REGISTRO", "MES_REGISTRO", "RESPONSABLE_REGISTRO", "FECHA_CONTROL", "RESPONSABLE_CONTROL", "ESTADO_DOCUMENTO"
        , "ESTADO_OBSERVACION", "TIPO_DOCUMENTO" 
    ];

    options = {
        page_length: 50, button_excel: true, export_title: tb.find("thead tr")[0].innerText.trim()
        , page_search: true, page_info: true, row_index: true, row_data_index: "ROW_INDEX"
    };
    _reporteGeneral.dtReporteControlCalidad = utilDt.fnLoadDataTable_Detail(tb, columns_label, columns_data, options);
}

_reporteGeneral.fnInitReporteControlCalidad = function () {

    $("#lbTituloGeneral,#lbSubTituloGeneral").html("Reporte de Control de Calidad de los Documentos");
    _reporteGeneral.frm.find("#dvFiltroAnio").show();
    _reporteGeneral.frm.find("#dvFiltroOD").show();
    _reporteGeneral.frm.find("#dvFiltroTipoDocumentoSigo").show();  
    _reporteGeneral.frm.find("#dvChkTipoDocumentoSigoAll").show();
    _reporteGeneral.frm.find("#dvFiltroEstadoDocumento").show();
    $("#dvReporteControlCalidad").show();

    _reporteGeneral.rpt12InitDataTable();

    _reporteGeneral.filter_lstChkModalidadId_change = function () {
        _reporteGeneral.dtReporteControlCalidad.clear().draw();
    }

    _reporteGeneral.fnSubmitForm = function () {
        _reporteGeneral.dtReporteControlCalidad.clear().draw();
        if (_reporteGeneral.filterValidate()) {
            var datosReporte = _reporteGeneral.frm.serializeObject();
            var option = { url: _reporteGeneral.frm.action, datos: JSON.stringify(datosReporte), type: 'POST' };

            utilSigo.fnAjax(option, function (data) {
                if (data.success) {
                    _reporteGeneral.dtReporteControlCalidad.rows.add(data.data).draw();
                }
                else {
                    utilSigo.toastWarning("Aviso", utilSigo.MessageError);
                    console.log(data.msj);
                }
            });
        }
        return false;
    }
}
/****************Fin Reporte 12*******************/
/***************Inicio Reporte 13*****************/
_reporteGeneral.rpt13InitDataTable = function () {
    var columns_label = [], columns_data = [], options = {};
    var tb = $("#tbRelacionInformesLegales");

    columns_label = ["Fecha de Regsitro", "Nro de Informe Legal", "Fecha de Emisión", "Titular", "Título Habilitante", "Nro Documento de Referencia", "Tipo Documento de Referencia"
        , "Recomendaciones del Informe Legal", "Tipo de Informe Legal", "profesionalNombre", "Estado Control de Calidad", "OD", "Modalidad de Aprovechamiento"
        , "Departamento", "Provincia", "Distrito"      
    ];


    columns_data = ["FECHA_REGISTRO", "NUMERO", "FECHA_EMISION", "TITULAR", "NUM_THABILITANTE", "NRO_INFORME", "TIPO_INFORME", "RECOMENDACION", "TIPO", "PROFESIONALNOMBRE"
        , "ESTADO", "OD", "MODALIDAD", "DEPARTAMENTO", "PROVINCIA", "DISTRITO"
    ];

    options = {
        page_length: 50, button_excel: true, export_title: tb.find("thead tr")[0].innerText.trim()
        , page_search: true, page_info: true, row_index: true, row_data_index: "ROW_INDEX"
    };
    _reporteGeneral.dtRelacionInformesLegales = utilDt.fnLoadDataTable_Detail(tb, columns_label, columns_data, options);
}

_reporteGeneral.fnInitRelacionInformesLegales = function () {

    $("#lbTituloGeneral,#lbSubTituloGeneral").html("Reporte de Relación de Informes Legales");
    _reporteGeneral.frm.find("#dvFiltroAnio").show();
    _reporteGeneral.frm.find("#dvFiltroMes").show();
    _reporteGeneral.frm.find("#dvChkMesAll").show();
    _reporteGeneral.frm.find("#dvFiltroDLinea").show();
    $("#dvRelacionInformesLegales").show();

    _reporteGeneral.rpt13InitDataTable();

    _reporteGeneral.filter_lstChkDLineaId_change = function () {
        _reporteGeneral.dtRelacionInformesLegales.clear().draw();
    }

    _reporteGeneral.fnSubmitForm = function () {
        _reporteGeneral.dtRelacionInformesLegales.clear().draw();
        if (_reporteGeneral.filterValidate()) {
            var datosReporte = _reporteGeneral.frm.serializeObject();
            var option = { url: _reporteGeneral.frm.action, datos: JSON.stringify(datosReporte), type: 'POST' };

            utilSigo.fnAjax(option, function (data) {
                if (data.success) {
                    _reporteGeneral.dtRelacionInformesLegales.rows.add(data.data).draw();
                }
                else {
                    utilSigo.toastWarning("Aviso", utilSigo.MessageError);
                    console.log(data.msj);
                }
            });
        }
        return false;
    }
}
/****************Fin Reporte 13*******************/

/***************Inicio Reporte 14*****************/
_reporteGeneral.rpt14InitDataTable = function () {
    var columns_label = [], columns_data = [], options = {};
    var tb = $("#tbRelacionInformesTecnicos");

    columns_label = ["Fecha de Registro","Nro Informe Técnico", "Fecha de Emisión", "Titular", "Título Habilitante", "Tipo Informe Técnico", "Profesional Responsable"
    ];


    columns_data = ["FECHA_REGISTRO","NUMERO_INFORME", "FECHA_EMISION", "TITULAR", "NUM_THABILITANTE", "TIPO", "SUPERVISOR"
    ];

    options = {
        page_length: 50, button_excel: true, export_title: tb.find("thead tr")[0].innerText.trim()
        , page_search: true, page_info: true, row_index: true, row_data_index: "ROW_INDEX"
    };
    _reporteGeneral.dtRelacionInformesTecnicos = utilDt.fnLoadDataTable_Detail(tb, columns_label, columns_data, options);
}

_reporteGeneral.fnInitRelacionInformesTecnicos = function () {

    $("#lbTituloGeneral,#lbSubTituloGeneral").html("Reporte de Relación de Informes Técnicos");
    _reporteGeneral.frm.find("#dvFiltroAnio").show();
    _reporteGeneral.frm.find("#dvFiltroMes").show();
    _reporteGeneral.frm.find("#dvChkMesAll").show();
    _reporteGeneral.frm.find("#dvFiltroDLinea").show();
    $("#dvRelacionInformesTecnicos").show();

    _reporteGeneral.rpt14InitDataTable();

    _reporteGeneral.filter_lstChkDLineaId_change = function () {
        _reporteGeneral.dtRelacionInformesTecnicos.clear().draw();
    }

    _reporteGeneral.fnSubmitForm = function () {
        _reporteGeneral.dtRelacionInformesTecnicos.clear().draw();
        if (_reporteGeneral.filterValidate()) {
            var datosReporte = _reporteGeneral.frm.serializeObject();
            var option = { url: _reporteGeneral.frm.action, datos: JSON.stringify(datosReporte), type: 'POST' };

            utilSigo.fnAjax(option, function (data) {
                if (data.success) {
                    _reporteGeneral.dtRelacionInformesTecnicos.rows.add(data.data).draw();
                }
                else {
                    utilSigo.toastWarning("Aviso", utilSigo.MessageError);
                    console.log(data.msj);
                }
            });
        }
        return false;
    }
}
/****************Fin Reporte 14*******************/

/***************Inicio Reporte 15*****************/
_reporteGeneral.rpt15InitDataTable = function () {
    var columns_label = [], columns_data = [], options = {};
    var tb = $("#tbRelacionResolucionesFiscalizacion");

    columns_label = ["Año del Informe de la DSFFS", "Informe de la DSFFS", "Fecha de Registro de Resolución", "Tipo de Resolución", "Nro Resolución", "Título Habilitante", "Titular"
        , "Modalidad de Aprovechamiento", "Fecha de Emisión de la Resolución", "Estado Control de Calidad", "Nro Expediente", "Persona Notificada", "Notificación a OCI", "Gravedad del daño"
        , "Inf. Falsa - Inexistencia", "Inf. Falsa - Diferencia de Especies", "Inf. Falsa - Diferencia Dasométrica", "Inf. Falsa (inciso t)", "Detalle inf. falsa"
        , "ATFFS", "DETALLE_ATFFS", "OCI", "DETALLE_OCI", "DGFFS", "DETALLE_DGFFS", "PROGRAMA_REGIONAL", "DETALLE_PROREG", "MINISTERIO_PUBLICO", "DETALLE_MINPUB"
        , "COLEGIO_INGENIEROS", "DETALLE_COLING", "OEFA", "DETALLE_OEFA", "SUNAT", "DETALLE_SUNAT", "SERFOR", "DETALLE_SERFOR", "OTROS", "DETALLE_OTROS"
        , "DEPARTAMENTO", "PROVINCIA", "DISTRITO", "Oficina Desconcentrada", "Monto Multa Impuesta (U.I.T.)", "Monto Multa Final (U.I.T.)", "Estado PAU", "Fecha Proveido Firmeza"
    ];


    columns_data = ["ANIO_INFORME_TEXT", "INFORME_SUPERVISION", "FECHA_REGISTRO", "DESCRIPCION", "NUMERO_RESOLUCION", "NUM_THABILITANTE", "TITULAR", "MODALIDAD", "FECHA_EMISION", "ESTADO"
        , "NUMERO_EXPEDIENTE", "PERSONA_NOTIFICADA", "NOTIFICACION_OCI", "GRAVEDAD"
        , "INFORMACION_FALSA_INEX", "INFORMACION_FALSA_DIF", "INFORMACION_FALSA_DAS", "INFORMACION_FALSA_T", "DESCRIPCION_INFORMACION_FALSA"
        , "ATFFS", "DETALLE_ATFFS", "OCI", "DETALLE_OCI", "DGFFS", "DETALLE_DGFFS", "PROGRAMA_REGIONAL", "DETALLE_PROREG", "MINISTERIO_PUBLICO", "DETALLE_MINPUB"
        , "COLEGIO_INGENIEROS", "DETALLE_COLING", "OEFA", "DETALLE_OEFA", "SUNAT", "DETALLE_SUNAT", "SERFOR", "DETALLE_SERFOR", "OTROS", "DETALLE_OTROS"
        , "DEPARTAMENTO", "PROVINCIA", "DISTRITO", "OD", "MONTO_MULTA_TEXT", "MONTO_MULTA_FINAL_TEXT", "ESTADO_PAU", "FECHA_PROVEIDO"
    ];

    options = {
        page_length: 50, button_excel: true, export_title: tb.find("thead tr")[0].innerText.trim()
        , page_search: true, page_info: true, row_index: true, row_data_index: "ROW_INDEX"
    };
    _reporteGeneral.dtRelacionResolucionesFiscalizacion = utilDt.fnLoadDataTable_Detail(tb, columns_label, columns_data, options);
}

_reporteGeneral.fnInitRelacionResolucionesFiscalizacion = function () {

    $("#lbTituloGeneral,#lbSubTituloGeneral").html("Reporte de Relación de Resoluciones Emitidas");
    _reporteGeneral.frm.find("#dvFiltroAnio").show();
    //_reporteGeneral.frm.find("#dvChkAnioAll").show();
    _reporteGeneral.frm.find("#dvFiltroMes").show();
    _reporteGeneral.frm.find("#dvChkMesAll").show();
    _reporteGeneral.frm.find("#dvFiltroModalidad").show();
    _reporteGeneral.frm.find("#dvFiltroDepartamento").show();
    _reporteGeneral.frm.find("#dvFiltroDLinea").show();
    _reporteGeneral.frm.find("#dvFiltroTipoResolucionFiscalizacion").show();
    $("#dvRelacionResolucionesFiscalizacion").show();

    _reporteGeneral.rpt15InitDataTable();

    _reporteGeneral.filter_lstChkDLineaId_change = function () {
        _reporteGeneral.dtRelacionResolucionesFiscalizacion.clear().draw();
    }

    _reporteGeneral.fnSubmitForm = function () {
        _reporteGeneral.dtRelacionResolucionesFiscalizacion.clear().draw();
        if (_reporteGeneral.filterValidate()) {
            var datosReporte = _reporteGeneral.frm.serializeObject();
            var option = { url: _reporteGeneral.frm.action, datos: JSON.stringify(datosReporte), type: 'POST' };

            utilSigo.fnAjax(option, function (data) {
                if (data.success) {
                    _reporteGeneral.dtRelacionResolucionesFiscalizacion.rows.add(data.data).draw();
                }
                else {
                    utilSigo.toastWarning("Aviso", utilSigo.MessageError);
                    console.log(data.msj);
                }
            });
        }
        return false;
    }
}
/****************Fin Reporte 15*******************/

/***************Inicio Reporte 16*****************/
_reporteGeneral.rpt16InitDataTable = function () {
    var columns_label = [], columns_data = [], options = {};
    var tb = $("#tbRelacionInformesSuspension");

    columns_label = ["Nro Informe","Supervisor","Titular","Titulo","Modalidad","Region","Motivo"
    ];


    columns_data = ["NUMERO", "SUPERVISOR", "TITULAR", "TITULO", "MODALIDAD", "DEPARTAMENTO","MOTIVO"
    ];

    options = {
        page_length: 50, button_excel: true, export_title: tb.find("thead tr")[0].innerText.trim()
        , page_search: true, page_info: true, row_index: true, row_data_index: "ROW_INDEX"
    };
    _reporteGeneral.dtRelacionInformesSuspension = utilDt.fnLoadDataTable_Detail(tb, columns_label, columns_data, options);
}

_reporteGeneral.fnInitRelacionInformesSuspension = function () {

    $("#lbTituloGeneral,#lbSubTituloGeneral").html("Reporte de Relación de Informes de Suspensión");
    _reporteGeneral.frm.find("#dvFiltroAnio").show();
    _reporteGeneral.frm.find("#dvChkAnioAll").show();
    //_reporteGeneral.frm.find("#dvFiltroMes").show();
    //_reporteGeneral.frm.find("#dvChkMesAll").show();    
    _reporteGeneral.frm.find("#dvFiltroDLinea").show();
    $("#dvRelacionInformesSuspension").show();

    _reporteGeneral.rpt16InitDataTable();

    _reporteGeneral.filter_lstChkDLineaId_change = function () {
        _reporteGeneral.dtRelacionInformesSuspension.clear().draw();
    }

    _reporteGeneral.fnSubmitForm = function () {
        _reporteGeneral.dtRelacionInformesSuspension.clear().draw();
        if (_reporteGeneral.filterValidate()) {
            var datosReporte = _reporteGeneral.frm.serializeObject();
            var option = { url: _reporteGeneral.frm.action, datos: JSON.stringify(datosReporte), type: 'POST' };

            utilSigo.fnAjax(option, function (data) {
                if (data.success) {
                    _reporteGeneral.dtRelacionInformesSuspension.rows.add(data.data).draw();
                }
                else {
                    utilSigo.toastWarning("Aviso", utilSigo.MessageError);
                    console.log(data.msj);
                }
            });
        }
        return false;
    }
}
/****************Fin Reporte 16*******************/
/***************Inicio Reporte 17*****************/
_reporteGeneral.rpt17InitDataTable = function () {
    var columns_label = [], columns_data = [], options = {};
    var tb = $("#tbRelacionInformesSupervision");

    columns_label = ["Año de Supervisión","Mes de la Supervisión", "Nro Informe", "Tipo Informe", "Supervisor", "Titular", "Titulo", "Modalidad", "Region", "Prov.", "Dist"
        , "OD Ámbito Geográfico", "Nro Muestra", "Nro Árboles Supervisados", "Nro Árboles Inexistentes", "Área TH", "Área POA Supervisado", "POA's Supervisado"
        , "RD's POA's Aprobación", "Publicado Observatorio", "Volumen Justificado", "Volumen Injustificado"


        , "PASPEQ"
        , "Cuenta con Carta de Notificación"
        , "Indicador"
        , "Fecha de Salida a Campo"
        , "Fecha de Recepción del Cheque"
        , "Fecha de cobro del cheque"
        , "Fecha de Regreso de campo"
        , "Fecha de Inicio de labores en la oficina"
        , "Se capacitó al personal que conforma la brigada sobre primero auxilios"
        , "Se capacitó al personal que conforma la brigada sobre el protocolo de respuesta frente a incidentes y accidentes durante el trabajo de campo"
        , "Fecha de entrega del informe al administrado"
        , "Lista Roja"
        , "Lista Verde"
        , "Motivo de la Supervisión"
        , "Tipo de Supervisión"
        , "Fecha Inicio Supervisión"
        , "Fecha Fin Supervisión"
        , "¿Qué geotecnología se ha utilizado en la supervisión?"
        , "Tipo de Requerimiento"
        , "Sub Estado"
        , "Tipo de Informe"
        , "Buen Desempeño"







        , "Oportunidad Supervisión"
    ];


    columns_data = ["ANIO", "MES_SUPERVISION", "NUMERO", "TIPO_INFORME", "SUPERVISOR", "TITULAR", "TITULO", "MODALIDAD", "DEPARTAMENTO", "PROVINCIA", "DISTRITO"
        , "OD_AMBITO", "MUESTRA", "CAMPOS", "INEXISTENTE", "AREA_TH", "AREA_POA", "POAS", "POAS_RD", "PUBLICAR_TEXT", "VOLUMEN_JUSTIFICADO", "VOLUMEN_INJUSTIFICADO"


        , "PASPEQ"
        , "CUENTA_CN"
        , "DESCRIPCION"
        , "FECHA_SALIDA_CAMPO"
        , "FECHA_RECEPCION_CHEQUE"
        , "FECHA_COBRO_CHEQUE"
        , "FECHA_REGRESO_CAMPO"
        , "FECHA_INICIO_LABORES"
        , "CAPACITO_AUXILIOS"
        , "CAPACITO_INCIDENTES"
        , "ENTREGA_IS_ADM"
        , "LISTA_ROJA"
        , "LISTA_VERDE"
        , "MOTIVO"
        , "TIPO_INFORME_IS"
        , "FECHA_SUPERVISION_INICIO", "FECHA_SUPERVISION_FIN"
        , "GEOTECNOLOGIA_USADO"
        , "TIPO_REQUERIMIENTO"
        , "SUB_ESTADO"
        , "TIPO_SUPERVISION"
        , "BUEN_COMPORTAMIENTO"


        , "OPORTUNIDAD"
    ];

    options = {
        page_length: 50, button_excel: true, export_title: tb.find("thead tr")[0].innerText.trim()
        , page_search: true, page_info: true, row_index: true, row_data_index: "ROW_INDEX"
    };
    _reporteGeneral.dtRelacionInformesSupervision = utilDt.fnLoadDataTable_Detail(tb, columns_label, columns_data, options);
}

_reporteGeneral.fnInitRelacionInformesSupervision = function () {

    $("#lbTituloGeneral,#lbSubTituloGeneral").html("Reporte de Relación de Informes de Supervisión");
    _reporteGeneral.frm.find("#dvFiltroAnio").show();
    _reporteGeneral.frm.find("#dvChkAnioAll").show();
    _reporteGeneral.frm.find("#dvFiltroMes").show();
    _reporteGeneral.frm.find("#dvChkMesAll").show();
    _reporteGeneral.frm.find("#dvFiltroOD").show();
    _reporteGeneral.frm.find("#dvFiltroDLinea").show();
    _reporteGeneral.frm.find("#dvFiltroModalidad").show();
    _reporteGeneral.frm.find("#dvFiltroDepartamento").show();
    $("#dvRelacionInformesSupervision").show();

    _reporteGeneral.rpt17InitDataTable();

    _reporteGeneral.filter_lstChkDLineaId_change = function () {
        _reporteGeneral.dtRelacionInformesSupervision.clear().draw();
    }

    _reporteGeneral.fnSubmitForm = function () {
        _reporteGeneral.dtRelacionInformesSupervision.clear().draw();
        if (_reporteGeneral.filterValidate()) {
            var datosReporte = _reporteGeneral.frm.serializeObject();
            var option = { url: _reporteGeneral.frm.action, datos: JSON.stringify(datosReporte), type: 'POST' };

            utilSigo.fnAjax(option, function (data) {
                if (data.success) {
                    _reporteGeneral.dtRelacionInformesSupervision.rows.add(data.data).draw();
                }
                else {
                    utilSigo.toastWarning("Aviso", utilSigo.MessageError);
                    console.log(data.msj);
                }
            });
        }
        return false;
    }
}
/****************Fin Reporte 17*******************/


/***************Inicio Reporte 18*****************/
/****************Fin Reporte 18*******************/
/***************Inicio Reporte 19*****************/

_reporteGeneral.rpt19InitDataTable = function () {
    var columns_label = [], columns_data = [], options = {};
    var tb = $("#tbReporteAntecedenteExpediente");

    columns_label = [""
    ];


    columns_data = [""
    ];

    options = {
        page_length: 50, button_excel: true, export_title: tb.find("thead tr")[0].innerText.trim()
        , page_search: true, page_info: true, row_index: true, row_data_index: "ROW_INDEX"
    };
    _reporteGeneral.dtReporteAntecedenteExpediente = utilDt.fnLoadDataTable_Detail(tb, columns_label, columns_data, options);
}

_reporteGeneral.fnInitReporteAntecedenteExpediente = function () {

    $("#lbTituloGeneral,#lbSubTituloGeneral").html("Número de PAU Concluidos 1ra y 2da Instancia");
    //_reporteGeneral.frm.find("#dvFiltroAnio").show();
    //_reporteGeneral.frm.find("#dvChkAnioAll").show();
    //_reporteGeneral.frm.find("#dvFiltroMes").show();
    //_reporteGeneral.frm.find("#dvChkMesAll").show();   
    //_reporteGeneral.frm.find("#dvFiltroDLinea").show();
    $("#dvReporteAntecedenteExpediente").show();

    _reporteGeneral.rpt19InitDataTable();

    //_reporteGeneral.filter_lstChkDLineaId_change = function () {
    //    _reporteGeneral.dtRelacionInformesSupervision.clear().draw();
    //}

    _reporteGeneral.fnSubmitForm = function () {
        _reporteGeneral.dtReporteAntecedenteExpediente.clear().draw();
        if (_reporteGeneral.filterValidate()) {
            var datosReporte = _reporteGeneral.frm.serializeObject();
            var option = { url: _reporteGeneral.frm.action, datos: JSON.stringify(datosReporte), type: 'POST' };

            utilSigo.fnAjax(option, function (data) {
                if (data.success) {
                    _reporteGeneral.dtReporteAntecedenteExpediente.rows.add(data.data).draw();
                }
                else {
                    utilSigo.toastWarning("Aviso", utilSigo.MessageError);
                    console.log(data.msj);
                }
            });
        }
        return false;
    }
}

/****************Fin Reporte 19*******************/
/***************Inicio Reporte 20*****************/

_reporteGeneral.rpt20InitDataTable = function () {
    var columns_label = [], columns_data = [], options = {};
    var tb = $("#tbReporteAntecedenteExpediente");

    columns_label = [""
    ];


    columns_data = [""
    ];

    options = {
        page_length: 50, button_excel: true, export_title: tb.find("thead tr")[0].innerText.trim()
        , page_search: true, page_info: true, row_index: true, row_data_index: "ROW_INDEX"
    };
    _reporteGeneral.dtReporteAntecedenteExpediente = utilDt.fnLoadDataTable_Detail(tb, columns_label, columns_data, options);
}

_reporteGeneral.fnInitReporteAntecedenteExpediente = function () {

    $("#lbTituloGeneral,#lbSubTituloGeneral").html("Número de PAU Concluidos Resumen 1ra Instancia");
    //_reporteGeneral.frm.find("#dvFiltroAnio").show();
    //_reporteGeneral.frm.find("#dvChkAnioAll").show();
    //_reporteGeneral.frm.find("#dvFiltroMes").show();
    //_reporteGeneral.frm.find("#dvChkMesAll").show();   
    //_reporteGeneral.frm.find("#dvFiltroDLinea").show();
    $("#dvReporteAntecedenteExpediente").show();

    _reporteGeneral.rpt20InitDataTable();

    //_reporteGeneral.filter_lstChkDLineaId_change = function () {
    //    _reporteGeneral.dtRelacionInformesSupervision.clear().draw();
    //}

    _reporteGeneral.fnSubmitForm = function () {
        _reporteGeneral.dtReporteAntecedenteExpediente.clear().draw();
        if (_reporteGeneral.filterValidate()) {
            var datosReporte = _reporteGeneral.frm.serializeObject();
            var option = { url: _reporteGeneral.frm.action, datos: JSON.stringify(datosReporte), type: 'POST' };

            utilSigo.fnAjax(option, function (data) {
                if (data.success) {
                    _reporteGeneral.dtReporteAntecedenteExpediente.rows.add(data.data).draw();
                }
                else {
                    utilSigo.toastWarning("Aviso", utilSigo.MessageError);
                    console.log(data.msj);
                }
            });
        }
        return false;
    }
}

/****************Fin Reporte 20*******************/
/***************Inicio Reporte 21*****************/

_reporteGeneral.rpt21InitDataTable = function () {
    var columns_label = [], columns_data = [], options = {};
    var tb = $("#tbReporteAntecedenteExpediente");

    columns_label = ["Documento de Referencia", "Título Habilitante", "Plan de Manejo", "Resolución de Aprobación del Plan de Manejo", "Fuente", "Fecha de Entrega al OSINFOR"
        , "Estado", "Estado SIGOsfc", "N° de Árboles Censo", "Supervisado"
    ];


    columns_data = ["DOC_REFERENCIA", "NUM_THABILITANTE", "NOMBRE_POA", "RESOLUCION_POA", "FUENTE", "FECHA", "ESTADO_AEXPEDIENTE", "ESTADO_SIGO", "CENSO", "SUPERVISADO"
    ];

    options = {
        page_length: 50, button_excel: true, export_title: tb.find("thead tr")[0].innerText.trim()
        , page_search: true, page_info: true, row_index: true, row_data_index: "ROW_INDEX"
    };
    _reporteGeneral.dtReporteAntecedenteExpediente = utilDt.fnLoadDataTable_Detail(tb, columns_label, columns_data, options);
}

_reporteGeneral.fnInitReporteAntecedenteExpediente = function () {

    $("#lbTituloGeneral,#lbSubTituloGeneral").html("Reporte de Antecedentes de Expedientes Remitidos por la AFFS");
    //_reporteGeneral.frm.find("#dvFiltroAnio").show();
    //_reporteGeneral.frm.find("#dvChkAnioAll").show();
    //_reporteGeneral.frm.find("#dvFiltroMes").show();
    //_reporteGeneral.frm.find("#dvChkMesAll").show();   
    //_reporteGeneral.frm.find("#dvFiltroDLinea").show();
    $("#dvReporteAntecedenteExpediente").show();

    _reporteGeneral.rpt21InitDataTable();

    //_reporteGeneral.filter_lstChkDLineaId_change = function () {
    //    _reporteGeneral.dtRelacionInformesSupervision.clear().draw();
    //}

    _reporteGeneral.fnSubmitForm = function () {
        _reporteGeneral.dtReporteAntecedenteExpediente.clear().draw();
        if (_reporteGeneral.filterValidate()) {
            var datosReporte = _reporteGeneral.frm.serializeObject();
            var option = { url: _reporteGeneral.frm.action, datos: JSON.stringify(datosReporte), type: 'POST' };

            utilSigo.fnAjax(option, function (data) {
                if (data.success) {
                    _reporteGeneral.dtReporteAntecedenteExpediente.rows.add(data.data).draw();
                }
                else {
                    utilSigo.toastWarning("Aviso", utilSigo.MessageError);
                    console.log(data.msj);
                }
            });
        }
        return false;
    }
}

/****************Fin Reporte 21*******************/
/***************Inicio Reporte 22*****************/
_reporteGeneral.rpt22InitDataTable = function () {
    var columns_label = [], columns_data = [], options = {};
    var tb = $("#tbReporteAutorizacionesFaunaSilvestre");

    columns_label = [
        "Modalidad", "Clase", "Departamento", "Provincia", "Distrito",
        "Título Habilitante", "Titular", "Código Número", "Resolución Titular", "Fecha Resolución", "Resolución Proyecto",
        "Fecha Res. Proy.", "Resolución Recategorización", "Fecha Recategorización", "Estado Funcionamiento", "Estado Situacional"
    ];


    columns_data = ["MODALIDAD_TIPO", "DESCRIPCION", "DEPARTAMENTO", "PROVINCIA", "DISTRITO",
        "NUM_THABILITANTE", "TITULAR", "CODIGO_NUMERO", "RES_TITULAR", "FECHA_RESOLUCION", "RES_PROYECTO", "FECHA_PROYECTO", "RES_RECAT",
        "FECHA_RECAT", "ESTADO_FUNCIONAMIENTO", "ESTADO_TH"];

    options = {
        page_length: 50, button_excel: true, export_title: tb.find("thead tr")[0].innerText.trim()
        , page_search: true, page_info: true, row_index: true, row_data_index: "ROW_INDEX"
    };
    _reporteGeneral.dtReporteAutorizacionesFaunaSilvestre = utilDt.fnLoadDataTable_Detail(tb, columns_label, columns_data, options);
}

_reporteGeneral.fnInitReporteAutorizacionesFaunaSilvestre = function () {

    $("#lbTituloGeneral,#lbSubTituloGeneral").html("Reporte Checklist de Autorizaciones de Fauna Silvestre");
    _reporteGeneral.frm.find("#dvFiltroOD").show();
    _reporteGeneral.frm.find("#dvFiltroModalidad").show();
    _reporteGeneral.frm.find("#dvFiltroDepartamento").show();
    $("#dvReporteAutorizacionesFaunaSilvestre").show();

    _reporteGeneral.rpt22InitDataTable();


    _reporteGeneral.filter_lstChkOdId_change = function () {
        _reporteGeneral.dtReporteAutorizacionesFaunaSilvestre.clear().draw();
    }
    _reporteGeneral.filter_lstChkModalidadId_change = function () {
        _reporteGeneral.dtReporteAutorizacionesFaunaSilvestre.clear().draw();
    }
    _reporteGeneral.filter_lstChkDepartamentoId_change = function () {
        _reporteGeneral.dtReporteAutorizacionesFaunaSilvestre.clear().draw();
    }

    _reporteGeneral.fnSubmitForm = function () {

        _reporteGeneral.dtReporteAutorizacionesFaunaSilvestre.clear().draw();
        if (_reporteGeneral.filterValidate()) {
            var datosReporte = _reporteGeneral.frm.serializeObject();
            var option = { url: _reporteGeneral.frm.action, datos: JSON.stringify(datosReporte), type: 'POST' };

            utilSigo.fnAjax(option, function (data) {
                if (data.success) {
                    _reporteGeneral.dtReporteAutorizacionesFaunaSilvestre.rows.add(data.data).draw();
                }
                else {
                    utilSigo.toastWarning("Aviso", utilSigo.MessageError);
                    console.log(data.msj);
                }
            });
        }
        return false;
    }
}
/****************Fin Reporte 22*******************/

/*REPORTE 23 - Reporte de la Dirección de Fiscalización*/
_reporteGeneral.rpt23InitDataTable = function () {
    var columns_label = [], columns_data = [], options = {};

    columns_label = ["Año del Informe", "Sub Dirección de Línea", "Oficina Desconcentrada", "Modalidad de Aprovechamiento", "Ubigeo del TH: Departamento",
        "Ubigeo del TH: Provincia", "Ubigeo del TH: Distrito", "Título Habilitante", "Titular Actual", "Titular Sancionado", "Informe", "Control de calidad Informe",
        "Tipo de Informe", "Fecha Emisión Inf. Supervisión", "Volumen Injustificado (m3)", "Volumen Justificado (m3)", "Es Alerta", "Fecha Derivación DFFFS (SIGOsfc)",
        "Devuelto DFFFS->DSFFS", "Fecha Recepción Derivación DFFFS->SUBDIR (SITD)", "DFFFS->SUBDIR Delegado a: (SITD)", "Inf. Legal de Eval.",
        "Fecha Emision Inf Legal", "Recomendación Inf. Legal", "Sin indicios de infracción", "Fallecimiento Titular", "Nro Res. Archivo",
        "Fecha Emisión Res. Archivo", "Nro Expediente Administrativo", "Nro. Res. Inicio PAU", "Inicio PAU", "Infracciones Res. Inicio",
        "Causal de Caducidad", "Medidas Cautelares", "Notificaciones Ini PAU", "Res. Ampliación PAU", "Fecha Emisión Res. Ampliación PAU",
        "Infracciones Res. Amp. PAU", "Notificaciones Amplicación de PAU", "Res. Variación Imputación de Cargos", "Fecha Emi. Variación Imputación de Cargos",
        "Infracciones Res. Variación Imp. Cargos", "Notificaciones Var. Imputación de Cargos", "Inf. Final de Instrucción", "Fecha Emi. Inf. Final de Instrucción",
        "Notificaciones Inf. Final de Instrucción", "Días despúes de la notificación del IFI", "Fecha derivación Dirección", "Res. de Término de PAU",
        "Fecha de Emisión de la Res. de Término de PAU", "Infracciones Res. Término PAU", "Determinación Res. Término PAU", "¿Res. Término PAU dicta caducidad?",
        "Monto Multa U.I.T.", "Amonestación", "Medidas Provisorias", "RLFFS 27308 ART. 363: i) (m3)", "RLFFS 27308 ART. 363: k) (m3)", "RLFFS 27308 ART. 363: n) (m3)",
        "RLFFS 27308 ART. 363: w) (m3)", "DS 018-2015-MINAGRI ART. 207.3: e) (m3)", "DS 018-2015-MINAGRI ART. 207.3: l) (m3)", "DS 021-2015-MINAGRI ART. 137.3: e) (m3)",
        "DS 021-2015-MINAGRI ART. 137.3: l) (m3)", "¿Se impusieron Med. Correctivas?", "Descripción Medida Correctiva", "Gravedad de Daño",
        "Notificación de la Resolución de Término de PAU", "Nuevas pruebas presentadas", "Resolución Reconsideración", "Fecha emisión RD Reconsideración",
        "Determinación Reconsideración", "Notificación de la Resolución de Reconsideración", "¿Levantar Caducidad Recons 1?", "Nro Resolución TFFS", "Fecha Emisión Res. TFFS",
        "Recurso de Apelación", "Determina", "¿Confirma Resolución?", "Res. Inicio PAU por Nulidad Parcial o total 2", "Fecha Emisión Res. Ini. 2",
        "Infracciones Res. Inicio PAU 2", "Res. de Término de PAU 2", "Fecha de Emisión de la Res. de Término de PAU 2", "Infracciones Res. Término PAU 2",
        "Determinación Res. Término PAU 2", "¿Res. Término PAU 2 dicta caducidad?", "Monto de la Multa U.I.T.", "Amonestación", "Proveido Archivo del Informe de Supervisión",
        "Proveido Firmeza", "Estado PAU (Glosario RP 121-2017)", "Estado PAU (Interno)", "Caducidad del T.H.", "Monto Multa Final U.I.T.", "Infracciones Confirmadas"];

    columns_data = ["ANIO_INFORME", "DLINEA", "OD_AMBITO_TH", "MTIPO", "DEPARTAMENTO_TH", "PROVINCIA_TH", "DISTRITO_TH", "NUM_THABILITANTE", "TITULAR", "TITULAR_SANCIONADO",
        "NUM_INFORME", "ESTADO_DOCUMENTO", "TIPO_INFORME", "FECEMI_INFORME", "VOLINJ_INFORME", "VOLJUS_INFORME", "ES_ALERTA", "FECDER_FISCA", "DEVUELTO_DFFFS_DSFFS",
        "FECDERIVA_DFFFS_SUBDIR_RECEPCION", "DERIVA_DFFFS_SUBDIR_DELEGADO", "NUM_ILEGAL", "FECHA_IL", "DETER_IL", "ARCH_BUEMAN_IL", "ARCH_MUETIT_IL", "NUM_RDARCH",
        "FECEMI_RDARCH", "NUMERO_EXPEDIENTE", "NUM_RDINI", "FECEMI_RDINI", "INFRAC_RDINI", "CAUCAD_RDINI", "MEDCAU_RDINI", "NUM_FISNOTI_RDINI", "NUM_RDAMP", "FECEMI_RDAMP",
        "INFRAC_RDAMP", "NUM_FISNOTI_RDAMP", "NUM_RDVARIMP", "FECEMI_RDVARIMP", "INFRAC_RDVARIMP", "NUM_FISNOTI_RDVARIMP", "NUM_IFI", "FECEMI_IFI", "NUM_FISNOTI_IFI",
        "EXPEDITO_IFI", "FECDER_IFI", "NUM_RDTER", "FECEMI_RDTER", "DETER_RDTER", "INFRAC_RDTER", "CADUCIDAD_RDTER", "MULTA_RDTER", "AMONESTA_RDTER", "MEDPRO_RDTER",
        "VOLUMEN_i_i_TER", "VOLUMEN_k_i_TER", "VOLUMEN_n_i_TER", "VOLUMEN_e_i_1TER", "VOLUMEN_e_i_2TER", "VOLUMEN_w_w_TER", "VOLUMEN_l_w_1TER", "VOLUMEN_l_w_2TER",
        "MEDCOR_RDTER", "DESC_MEDCOR_RDTER", "GRAVEDAD_RDTER", "NUM_FISNOTI_RDTER", "ARCH_NUEPRU_RDTER", "NUM_RDREC_1", "FECEMI_RDREC_1", "DETER_RDREC_1", "NUM_FISNOTI_RDREC_1",
        "LEVCAD_RDREC_1", "NUM_RTFFS_1", "FECEMI_RTFFS_1", "RECAPE_RTFFS_1", "DETER_RTFFS_1", "CONFIRM_RTFFS_1", "NUM_RDINITF_2", "FECEMI_RDINITF_2", "INFRAC_RDINITF_2",
        "NUM_RDTERTF_2", "FECEMI_RDTERTF_2", "INFRAC_RDTERTF_2", "DETER_RDTERTF_2", "CADUCIDAD_RDTERTF_2", "MULTA_RDTERTF_2", "AMONESTA_RDTERTF_2", "PROVEIDO_INFORME",
        "PROVEIDO_FIRMEZA", "ESTADO_PAU", "ESTADO_PAU_INTERNO", "CADUCADO_TH", "MULTA_CONFIRM", "INFRAC_CONFIRM"];
    options = {
        page_length: 50, button_excel: true, export_title: $("#tbReporteDirFiscalizacion").find("thead tr")[0].innerText.trim()
        , page_search: true, page_info: true, row_index: true, row_data_index: "ROW_INDEX"
    };
    _reporteGeneral.dtReporteDirFiscalizacion = utilDt.fnLoadDataTable_Detail($("#tbReporteDirFiscalizacion"), columns_label, columns_data, options);
}

_reporteGeneral.fnInitReporteDirFiscalizacion = function () {
    //Activar Filtros
    _reporteGeneral.frm.find("#dvFiltroAnio").show();
    _reporteGeneral.frm.find("#dvChkAnioAll").show();
    _reporteGeneral.filterAnioClearAllCheck = function () { /*Deshabilitar evento en este formulario*/ };
    _reporteGeneral.frm.find("#dvFiltroTipoInforme").show();
    _reporteGeneral.frm.find("#dvFiltroOD").show();
    _reporteGeneral.frm.find("#dvFiltroModalidad").show();
    _reporteGeneral.frm.find("#dvFiltroDepartamento").show();
    _reporteGeneral.frm.find("#dvFiltroDLinea").show();
    $("#dvReporteDirFiscalizacion").show();

    _reporteGeneral.rpt23InitDataTable();
    //Implementar eventos a ejecutar despúes de realizar una acción
    _reporteGeneral.filter_lstChkAnioId_change = function () {
        _reporteGeneral.dtReporteDirFiscalizacion.clear().draw();
    }
    _reporteGeneral.filter_lstChkTipoInformeId_change = function () {
        _reporteGeneral.dtReporteDirFiscalizacion.clear().draw();
    }
    _reporteGeneral.filter_lstChkOdId_change = function () {
        _reporteGeneral.dtReporteDirFiscalizacion.clear().draw();
    }
    _reporteGeneral.filter_lstChkModalidadId_change = function () {
        _reporteGeneral.dtReporteDirFiscalizacion.clear().draw();
    }
    _reporteGeneral.filter_lstChkDepartamentoId_change = function () {
        _reporteGeneral.dtReporteDirFiscalizacion.clear().draw();
    }
    _reporteGeneral.filter_lstChkDLineaId_change = function () {
        _reporteGeneral.dtReporteDirFiscalizacion.clear().draw();
    }

    _reporteGeneral.fnSubmitForm = function () {
        _reporteGeneral.dtReporteDirFiscalizacion.clear().draw();
        if (_reporteGeneral.filterValidate()) {
            var datosReporte = _reporteGeneral.frm.serializeObject();
            var option = { url: _reporteGeneral.frm.action, datos: JSON.stringify(datosReporte), type: 'POST' };

            utilSigo.fnAjax(option, function (data) {
                if (data.success) {
                    _reporteGeneral.dtReporteDirFiscalizacion.rows.add(data.data).draw();
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
/******************Fin Reporte 23*****************/

/***************Inicio Reporte 24*****************/
_reporteGeneral.rpt24InitDataTable = function () {
    var columns_label = [], columns_data = [], options = {};
    var tb = $("#tbdvReporteSolicitudFema");

    columns_label = ["Nro. Trámite", "Fecha Trámite", "Nro. Solicitud", "Carpeta Fiscal", "Tipo Solicitud", "Plazo Legal", "O.D."
        , "Fecha Oficio INFFUN", "Nro. Oficio INFFUN", "Nro. Informe", "Fecha Oficio PAU/Copia", "Nro. Oficio PAU/Copia", "Dias Transc.", "Dias Transc. 2"
        , "Dentro Plazo Legal", "FEMA", "Estado"
    ];


    columns_data = ["NUMERO_TRAMITE", "FECHA_TRAMITE", "NUMERO_SOLICITUD", "CARPETA_FISCAL", "TIPO_SOLICITUD", "PLAZO_LEGAL", "OD", "FECHA_OFICIO_INFFUN", "NUMERO_OFICIO_INFFUN", "NUMERO_INFORME"
        , "FECHA_OFICIO_PAU", "NUMERO_OFICIO_PAU", "DIAS_TRANS", "DIAS_TRANS2"
        , "FLAG_DENTRO_PLAZO", "FEMA", "ESTADO"
    ];

    options = {
        page_length: 50, button_excel: true, export_title: tb.find("thead tr")[0].innerText.trim()
        , page_search: true, page_info: true, row_index: true, row_data_index: "ROW_INDEX"
    };
    _reporteGeneral.tbdvReporteSolicitudFema = utilDt.fnLoadDataTable_Detail(tb, columns_label, columns_data, options);
}

_reporteGeneral.fnInitReporteSolicitudFema = function () {

    $("#lbTituloGeneral,#lbSubTituloGeneral").html("Consulta de Solicitud FEMA");
    _reporteGeneral.frm.find("#dvFiltroAnio").show();
    //_reporteGeneral.frm.find("#dvChkAnioAll").show();
    _reporteGeneral.frm.find("#dvFiltroMes").show();
    _reporteGeneral.frm.find("#dvChkMesAll").show();
    //_reporteGeneral.frm.find("#dvFiltroModalidad").show();
    //_reporteGeneral.frm.find("#dvFiltroDepartamento").show();
    //_reporteGeneral.frm.find("#dvFiltroDLinea").show();
    //_reporteGeneral.frm.find("#dvFiltroTipoResolucionFiscalizacion").show();
    $("#dvReporteSolicitudFema").show();

    _reporteGeneral.rpt24InitDataTable();

    _reporteGeneral.filter_lstChkDLineaId_change = function () {
        _reporteGeneral.tbdvReporteSolicitudFema.clear().draw();
    }

    _reporteGeneral.fnSubmitForm = function () {
        _reporteGeneral.tbdvReporteSolicitudFema.clear().draw();
        if (_reporteGeneral.filterValidate()) {
            var datosReporte = _reporteGeneral.frm.serializeObject();
            var option = { url: _reporteGeneral.frm.action, datos: JSON.stringify(datosReporte), type: 'POST' };

            utilSigo.fnAjax(option, function (data) {
                if (data.success) {
                    _reporteGeneral.tbdvReporteSolicitudFema.rows.add(data.data).draw();
                }
                else {
                    utilSigo.toastWarning("Aviso", utilSigo.MessageError);
                    console.log(data.msj);
                }
            });
        }
        return false;
    }
}
/****************Fin Reporte 24*******************/


$(document).ready(function () {
    _reporteGeneral.contenedor = "frmReporteGeneral";
    _reporteGeneral.frm = $("#" + _reporteGeneral.contenedor);

    _reporteGeneral.fnInitFiltro();


    switch (_reporteGeneral.frm.find("#hdfTipoReporte").val()) {
        case "SABANA_INFORME":
            _reporteGeneral.fnInitSabanaInforme();
            break;
        case "SABANA_PLAN_MANEJO":
            _reporteGeneral.fnInitSabanaPlanManejo();
            break;
        case "SABANA_SEGUIMIENTO_ALERTA":
            _reporteGeneral.fnInitSabanaSeguimientoAlerta();
            break;
        case "SABANA_ACERVO_DOCUMENTARIO":
            _reporteGeneral.fnInitSabanaAcervoDocumentario();
            break;
        //case "CUADRO_5_PASPEQ":
        //    _reporteGeneral.fnInitCuadro5Paspeq();
        //    break;
        //case "CUADRO_6_PASPEQ":
        //    _reporteGeneral.fnInitCuadro6Paspeq();
        //    break;
        //case "CUADRO_7_PASPEQ":
        //    _reporteGeneral.fnInitCuadro7Paspeq();
        //    break;
        //case "CUADRO_8_PASPEQ":
        //    _reporteGeneral.fnInitCuadro8Paspeq();
        //    break;
        case "SEGUIMIENTO_MED_CORRECTIVAS":
            _reporteGeneral.fnInitSeguimientoMedCorrectivas();
            break;
        case "OBLIGACIONES_TIT_MADERABLE":
            _reporteGeneral.fnInitObligacionesTitularesMaderables();
            break;
        case "OBLIGACIONES_TIT_NO_MADERABLE":
            _reporteGeneral.fnInitObligacionesTitularesNoMaderables();
            break;
        case "REPORTE_CONTROL_CALIDAD":
            _reporteGeneral.fnInitReporteControlCalidad();
            break;
        case "RELACION_INFORMES_LEGALES":
            _reporteGeneral.fnInitRelacionInformesLegales();
            break;
        case "RELACION_INFORMES_TECNICOS":
            _reporteGeneral.fnInitRelacionInformesTecnicos();
            break;
        case "RELACION_RESOLUCIONES_FISCALIZACION":
            _reporteGeneral.fnInitRelacionResolucionesFiscalizacion();
            break;
        case "RELACION_INFORMES_SUSPENSION":
            _reporteGeneral.fnInitRelacionInformesSuspension();
            break;
        case "RELACION_INFORMES_SUPERVISION":
            _reporteGeneral.fnInitRelacionInformesSupervision();
            break;
        case "REPORTE_ITINERARIO_SUPERVISION":
          
            break;
        case "PAU_CONCLUIDOS_1RA_2DA":
            _reporteGeneral.fnInitReportePauConcluido1ra2da();
            break;
        case "PAU_CONCLUIDOS_RESUMEN_1RA":
            _reporteGeneral.fnInitReportePauConcluidoResumen1ra();
            break;
        case "PAU_CONCLUIDOS_RESUMEN_1RA_2DA":
            _reporteGeneral.fnInitReportePauConcluidoResumen1ra2da();
            break;
        case "REPORTE_ANTECEDENTE_EXPEDIENTE":
            _reporteGeneral.fnInitReporteAntecedenteExpediente();
            break;
        case "REPORTE_AUTORIZACIONES_FAUNASILVESTRE":            
            _reporteGeneral.fnInitReporteAutorizacionesFaunaSilvestre();
            break;
        case "REPORTE_DIRECCION_FISCALIZACION":
            _reporteGeneral.fnInitReporteDirFiscalizacion();
            break;
        case "REPORTE_SOLICITUD_FEMA":
            _reporteGeneral.fnInitReporteSolicitudFema();
            break;
    }
});





//rama migración