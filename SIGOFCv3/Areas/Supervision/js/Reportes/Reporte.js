"use strict";
var _reporteGeneral = {};

/*GENERAL*/
_reporteGeneral.fnSubmitForm = function () { /*Implementar de acuerdo al reporte consultado*/ }
/*******************Fin General********************/

/*FILTROS Reporte*/
_reporteGeneral.filter_lstChkAnioId_change = function () { /*Implementar de acuerdo al reporte consultado*/ }
_reporteGeneral.filter_lstChkOdId_change = function () { /*Implementar de acuerdo al reporte consultado*/ }
_reporteGeneral.filter_lstChkModalidadId_change = function () { /*Implementar de acuerdo al reporte consultado*/ }
_reporteGeneral.filter_lstChkDepartamentoId_change = function () { /*Implementar de acuerdo al reporte consultado*/ }
_reporteGeneral.filter_lstChkDLineaId_change = function () { /*Implementar de acuerdo al reporte consultado*/ }

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
_reporteGeneral.filterValidate = function () {
    var sShow = "none";

    sShow = _reporteGeneral.frm.find("#dvFiltroAnio")[0].style.display;
    if (sShow == "") {
        if (_reporteGeneral.frm.find("#lstChkAnioId").val() == "") {
            utilSigo.toastWarning("Aviso", "Seleccione los años a consultar"); return false;
        }
    }
    sShow = _reporteGeneral.frm.find("#dvFiltroOD")[0].style.display;
    if (sShow == "") {
        if (_reporteGeneral.frm.find("#lstChkOdId").val() == "") {
            utilSigo.toastWarning("Aviso", "Seleccione las oficinas desconcentradas a consultar"); return false;
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
}

_reporteGeneral.fnInitFiltro = function () {
    $('[data-toggle="tooltip"]').tooltip();

    _reporteGeneral.filterEvent();
}
/******************Fin Filtros*******************/

/*REPORTE 1 - Sabana Informe*/
_reporteGeneral.rpt1InitDataTable = function () {
    var columns_label = [], columns_data = [], options = {};

    columns_label = ["Año del Informe", "Sub Dirección de Línea", "Oficina Desconcentrada", "Modalidad de Aprovechamiento"
                    , "Ubigeo del TH: Departamento", "Ubigeo del TH: Provincia", "Ubigeo del TH: Distrito", "Título Habilitante", "Titular Actual"
                    , "Titular Sancionado", "Ubigeo del Titular: Departamento", "Ubigeo del Titular: Provincia", "Ubigeo del Titular: Distrito", "Dirección"
                    , "Informe", "Tipo de Informe", "Fecha Informe (para Inf. Supervisión es Fecha Ini Super)"
                    , "Fecha Emisión Inf. Supervisión", "Planes de Manejo Supervisados", "Resoluciones de Planes de Manejo Supervisados"
                    , "Tipo Plan de Manejo", "Volumen Injustificado (m3)", "Volumen Justificado (m3)"
                    , "Inf. Legal de Eval.", "Fecha Emision Inf Legal", "Recomendación Inf. Legal", "Nueva Supervisión", "Evidencia de irregularidades cuya sanción no es competencia de OSINFOR"
                    , "Sin indicios de infracción", "Deficiente notificación", "Deficiencia técnica", "Fallecimiento Titular", "Otros"
                    , "Nro Res. Archivo", "Fecha Emisión Res. Archivo", "Nro Expediente Administrativo", "Nro. Res. Inicio PAU"
                    , "Fecha Emisión Res. Inicio PAU", "Infracciones Res. Inicio", "Causal de Caducidad", "Medidas Cautelares", "Notificaciones Ini PAU"
                    , "Res. Ampliación PAU", "Fecha Emisión Res. Ampliación PAU", "Infracciones Res. Amp. PAU", "Notificaciones Amplicación de PAU"
                    , "Res. Variación Imputación de Cargos", "Fecha Emi. Variación Imputación de Cargos", "Infracciones Res. Variación Imp. Cargos"
                    , "Notificaciones Var. Imputación de Cargos", "Inf. Final de Instrucción", "Fecha Emi. Inf. Final de Instrucción"
                    , "Notificaciones Inf. Final de Instrucción", "Días despúes de la notificación del IFI", "Fecha derivación Dirección"
                    , "Res. de Término de PAU", "Fecha de Emisión de la Res. de Término de PAU", "Infracciones Res. Término PAU", "Determinación Res. Término PAU"
                    , "¿Res. Término PAU dicta caducidad?", "Monto Multa U.I.T.", "Amonestación", "Medidas Provisorias", "RLFFS 27308 ART. 363: i) (m3)"
                    , "RLFFS 27308 ART. 363: k) (m3)", "RLFFS 27308 ART. 363: n) (m3)", "RLFFS 27308 ART. 363: w) (m3)", "DS 018-2015-MINAGRI ART. 207.3: e) (m3)"
                    , "DS 018-2015-MINAGRI ART. 207.3: l) (m3)", "DS 021-2015-MINAGRI ART. 137.3: e) (m3)", "DS 021-2015-MINAGRI ART. 137.3: l) (m3)"
                    , "¿Se impusieron Med. Correctivas?", "Descripción Medida Correctiva", "Año Implement. Med. Correctiva", "Mes Implement. Med. Correctiva"
                    , "Día Implement. Med. Correctiva", "Año Informe Med. Correctiva", "Mes Informe Med. Correctiva", "Día Informe Med. Correctiva"
                    , "Notificación de la Resolución de Término de PAU", "Mala notificación para la supervisión", "Nuevas pruebas presentadas"
                    , "Muerte titular", "Otros", "Prescripción", "Evaluación técnica favorable", "Deficiencia técnica", "Titular distinto"
                    , "Resolución Reconsideración", "Fecha emisión RD Reconsideración", "Determinación Reconsideración", "Notificación de la Resolución de Reconsideración"
                    , "¿Levantar Caducidad Recons 1?", "Nro Resolución TFFS", "Fecha Emisión Res. TFFS", "Recurso de Apelación", "Determina", "Motivo","¿Confirma Resolución?"
                    , "Res. Inicio PAU por Nulidad Parcial o total 2", "Fecha Emisión Res. Ini. 2", "Infracciones Res. Inicio PAU 2"
                    , "Res. de Término de PAU 2", "Fecha de Emisión de la Res. de Término de PAU 2", "Infracciones Res. Término PAU 2", "Determinación Res. Término PAU 2"
                    , "¿Res. Término PAU 2 dicta caducidad", "Monto de la Multa U.I.T.", "Amonestación", "Medidas Provisorias", "¿Se impusieron Med. Correctivas?"
                    , "Notificación de la Resolución de Término de PAU 2", "Resolución Reconsideración 2", "Fecha emisión RD Reconsideración 2"
                    , "Determinación Reconsideración 2", "Notificación de la Resolución de Reconsideración 2", "¿Levantar Caducidad Recons 2?"
                    , "Nro Resolución TFFS", "Fecha Emisión Res. TFFS", "Recurso de Apelación", "Determina", "Motivo", "¿Confirma Resolución?", "Recurso de Reconsideración presentado"
                    , "Recurso de Apelación presentado", "Proveido Archivo del Informe de Supervisión", "Proveido Firmeza", "Estado PAU (Glosario RP 121-2017)"
                    , "Estado PAU (Interno)", "Caducidad del T.H.", "Obsevatorio OSINFOR"];
    columns_data = ["ANIO_INFORME", "DLINEA", "OD_AMBITO_TH", "MTIPO", "DEPARTAMENTO_TH", "PROVINCIA_TH", "DISTRITO_TH"
                    , "NUM_THABILITANTE", "TITULAR", "TITULAR_SANCIONADO", "DEPARTAMENTO_TIT", "PROVINCIA_TIT", "DISTRITO_TIT", "DIRECCION_TIT"
                    , "NUM_INFORME", "TIPO_INFORME", "FECHA_INFORME", "FECEMI_INFORME", "NOMPOA_INFORME"
                    , "RESPOA_INFORME", "TIPPOA_INFORME", "VOLINJ_INFORME", "VOLJUS_INFORME"
                    , "NUM_ILEGAL", "FECHA_IL", "DETER_IL", "ARCH_NUESUP_IL", "ARCH_EVIIRR_IL", "ARCH_BUEMAN_IL", "ARCH_DEFNOT_IL"
                    , "ARCH_DEFTEC_IL", "ARCH_MUETIT_IL", "ARCH_OTROS_IL", "NUM_RDARCH", "FECEMI_RDARCH", "NUMERO_EXPEDIENTE"
                    , "NUM_RDINI", "FECEMI_RDINI", "INFRAC_RDINI", "CAUCAD_RDINI", "MEDCAU_RDINI", "NUM_FISNOTI_RDINI"
                    , "NUM_RDAMP", "FECEMI_RDAMP", "INFRAC_RDAMP", "NUM_FISNOTI_RDAMP", "NUM_RDVARIMP", "FECEMI_RDVARIMP", "INFRAC_RDVARIMP", "NUM_FISNOTI_RDVARIMP"
                    , "NUM_IFI", "FECEMI_IFI", "NUM_FISNOTI_IFI", "EXPEDITO_IFI", "FECDER_IFI", "NUM_RDTER", "FECEMI_RDTER", "DETER_RDTER"
                    , "INFRAC_RDTER", "CADUCIDAD_RDTER", "MULTA_RDTER", "AMONESTA_RDTER", "MEDPRO_RDTER", "VOLUMEN_i_i_TER", "VOLUMEN_k_i_TER", "VOLUMEN_n_i_TER"
                    , "VOLUMEN_e_i_1TER", "VOLUMEN_e_i_2TER", "VOLUMEN_w_w_TER", "VOLUMEN_l_w_1TER", "VOLUMEN_l_w_2TER", "MEDCOR_RDTER", "DESC_MEDCOR_RDTER"
                    , "ANIOIMP_MEDCOR_RDTER", "MESIMP_MEDCOR_RDTER", "DIAIMP_MEDCOR_RDTER", "ANIOINF_MEDCOR_RDTER", "MESINF_MEDCOR_RDTER", "DIAINF_MEDCOR_RDTER"
                    , "NUM_FISNOTI_RDTER", "ARCH_MALNOT_RDTER", "ARCH_NUEPRU_RDTER", "ARCH_MUETIT_RDTER", "ARCH_OTROS_RDTER", "ARCH_PRESCR_RDTER"
                    , "ARCH_EVATEC_RDTER", "ARCH_DEFTEC_RDTER", "ARCH_TITDIS_RDTER", "NUM_RDREC_1", "FECEMI_RDREC_1", "DETER_RDREC_1"
                    , "NUM_FISNOTI_RDREC_1", "LEVCAD_RDREC_1", "NUM_RTFFS_1", "FECEMI_RTFFS_1", "RECAPE_RTFFS_1", "DETER_RTFFS_1", "MOTIVO_RTFFS_1","CONFIRM_RTFFS_1"
                    , "NUM_RDINITF_2", "FECEMI_RDINITF_2", "INFRAC_RDINITF_2", "NUM_RDTERTF_2", "FECEMI_RDTERTF_2", "INFRAC_RDTERTF_2"
                    , "DETER_RDTERTF_2", "CADUCIDAD_RDTERTF_2", "MULTA_RDTERTF_2", "AMONESTA_RDTERTF_2", "MEDPRO_RDTERTF_2", "MEDCOR_RDTERTF_2"
                    , "NUM_FISNOTI_RDTERTF_2", "NUM_RDRECTF_2", "FECEMI_RDRECTF_2", "DETER_RDRECTF_2", "NUM_FISNOTI_RDRECTF_2", "LEVCAD_RDRECTF_2"
                    , "NUM_RTFFS_2", "FECEMI_RTFFS_2", "RECAPE_RTFFS_2", "DETER_RTFFS_2", "MOTIVO_RTFFS_2", "CONFIRM_RTFFS_2", "RECURSO_RECONSIDERACION"
                    , "RECURSO_APELACION", "PROVEIDO_INFORME", "PROVEIDO_FIRMEZA", "ESTADO_PAU", "ESTADO_PAU_INTERNO", "CADUCADO_TH", "OBSERVATORIO"];
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
                    , "Plan de Manejo", "Resolución de Aprobación", "Tipo Plan de Manejo", "Consultor", "Oportunidad de Supervisión"
                    , "Acta de Inspección Ocular", "Inf. Técnico que Recomienda Aprobación", "Inf. Técnico Inspección Ocular", "Área TH"
                    , "Área Plan de Manejo", "Muestra Seleccionada", "Muestra Supervisada", "Individuos Inexistentes", "Volumen Injustificado (m3)"
                    , "Volumen Justificado (m3)", "Inf. Legal de Eval.", "Fecha Emision Inf Legal", "Recomendación Inf. Legal", "Nueva Supervision"
                    , "Evidencia de irregularidades cuya sanción no es competencia de OSINFOR", "Sin indicios de infracción", "Deficiente notificación"
                    , "Deficiencia técnica", "Fallecimiento Titular", "Otros", "Nro Res. Archivo", "Fecha Emisión Res. Archivo", "Nro Expediente Administrativo"
                    , "Nro. Res. Inicio PAU", "Fecha Emisión Res. Inicio PAU", "Infracciones Res. Inicio", "Causal de Caducidad", "Medidas Cautelares"
                    , "Notificaciones Ini PAU", "Res. Ampliación PAU", "Fecha Emisión Res. Ampliación PAU", "Infracciones Res. Amp. PAU"
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
                    , "Estado PAU (Interno)", "Caducidad del T.H.", "Obsevatorio OSINFOR"];
    columns_data = ["ANIO_INFORME", "DLINEA", "OD_AMBITO_TH", "MTIPO", "DEPARTAMENTO_TH", "PROVINCIA_TH", "DISTRITO_TH", "NUM_THABILITANTE", "TITULAR"
                    , "TITULAR_SANCIONADO", "DEPARTAMENTO_TIT", "PROVINCIA_TIT", "DISTRITO_TIT", "DIRECCION_TIT", "NUM_INFORME", "TIPO_INFORME"
                    , "FECHA_INFORME", "FECEMI_INFORME", "NOMBRE_POA", "RESOLUCION_POA", "TIPO_POA", "CONSULTOR_POA", "OPORTUNIDAD_POA"
                    , "ACTINSOCU_POA", "ITECAPR_POA", "ITECINSOCU_POA", "AREA_TH", "AREA_POA", "MUESEL_POA", "MUESUP_POA", "ARBINEX_POA"
                    , "VOLINJ_POA", "VOLJUS_POA", "NUM_ILEGAL", "FECHA_IL", "DETER_IL", "ARCH_NUESUP_IL", "ARCH_EVIIRR_IL", "ARCH_BUEMAN_IL"
                    , "ARCH_DEFNOT_IL", "ARCH_DEFTEC_IL", "ARCH_MUETIT_IL", "ARCH_OTROS_IL", "NUM_RDARCH", "FECEMI_RDARCH", "NUMERO_EXPEDIENTE"
                    , "NUM_RDINI", "FECEMI_RDINI", "INFRAC_RDINI", "CAUCAD_RDINI", "MEDCAU_RDINI", "NUM_FISNOTI_RDINI", "NUM_RDAMP"
                    , "FECEMI_RDAMP", "INFRAC_RDAMP", "NUM_FISNOTI_RDAMP", "NUM_RDVARIMP", "FECEMI_RDVARIMP", "INFRAC_RDVARIMP", "NUM_FISNOTI_RDVARIMP"
                    , "NUM_IFI", "FECEMI_IFI", "NUM_FISNOTI_IFI", "EXPEDITO_IFI", "FECDER_IFI", "NUM_RDTER", "FECEMI_RDTER", "INFRAC_RDTER"
                    , "DETER_RDTER", "CADUCIDAD_RDTER", "MULTA_RDTER", "AMONESTA_RDTER", "MEDPRO_RDTER", "VOLUMEN_i_i_TER", "VOLUMEN_k_i_TER"
                    , "VOLUMEN_n_i_TER", "VOLUMEN_e_i_1TER", "VOLUMEN_e_i_2TER", "VOLUMEN_w_w_TER", "VOLUMEN_l_w_1TER", "VOLUMEN_l_w_2TER"
                    , "MEDCOR_RDTER", "DESC_MEDCOR_RDTER", "ANIOIMP_MEDCOR_RDTER", "MESIMP_MEDCOR_RDTER", "DIAIMP_MEDCOR_RDTER", "ANIOINF_MEDCOR_RDTER"
                    , "MESINF_MEDCOR_RDTER", "DIAINF_MEDCOR_RDTER", "NUM_FISNOTI_RDTER", "ARCH_MALNOT_RDTER", "ARCH_NUEPRU_RDTER", "ARCH_MUETIT_RDTER"
                    , "ARCH_OTROS_RDTER", "ARCH_PRESCR_RDTER", "ARCH_EVATEC_RDTER", "ARCH_DEFTEC_RDTER", "ARCH_TITDIS_RDTER", "NUM_RDREC_1"
                    , "FECEMI_RDREC_1", "DETER_RDREC_1", "NUM_FISNOTI_RDREC_1", "LEVCAD_RDREC_1", "NUM_RTFFS_1", "FECEMI_RTFFS_1", "RECAPE_RTFFS_1"
                    , "DETER_RTFFS_1", "MOTIVO_RTFFS_1", "CONFIRM_RTFFS_1", "NUM_RDINITF_2", "FECEMI_RDINITF_2", "INFRAC_RDINITF_2", "NUM_RDTERTF_2"
                    , "FECEMI_RDTERTF_2", "INFRAC_RDTERTF_2", "DETER_RDTERTF_2", "CADUCIDAD_RDTERTF_2", "MULTA_RDTERTF_2", "AMONESTA_RDTERTF_2"
                    , "MEDPRO_RDTERTF_2", "MEDCOR_RDTERTF_2", "NUM_FISNOTI_RDTERTF_2", "NUM_RDRECTF_2", "FECEMI_RDRECTF_2", "DETER_RDRECTF_2"
                    , "NUM_FISNOTI_RDRECTF_2", "LEVCAD_RDRECTF_2", "NUM_RTFFS_2", "FECEMI_RTFFS_2", "RECAPE_RTFFS_2", "DETER_RTFFS_2", "MOTIVO_RTFFS_2"
                    , "CONFIRM_RTFFS_2", "RECURSO_RECONSIDERACION", "RECURSO_APELACION", "PROVEIDO_INFORME", "PROVEIDO_FIRMEZA", "ESTADO_PAU"
                    , "ESTADO_PAU_INTERNO", "CADUCADO_TH", "OBSERVATORIO"];
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
    }
});