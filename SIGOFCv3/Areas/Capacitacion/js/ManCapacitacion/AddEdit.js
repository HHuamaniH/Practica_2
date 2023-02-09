"use strict";
var ManCapacitacion_AddEdit = {};
/*Variables globales*/
ManCapacitacion_AddEdit.tbEliTABLA = [];
ManCapacitacion_AddEdit.selectFile = null;
ManCapacitacion_AddEdit.DataAsistente = [];
ManCapacitacion_AddEdit.DataEquipoApoyo = [];
ManCapacitacion_AddEdit.DataPonentes = [];
ManCapacitacion_AddEdit.DataAportes = [];
ManCapacitacion_AddEdit.DataEncuestas = [];
ManCapacitacion_AddEdit.DataExamenes = [];
ManCapacitacion_AddEdit.DataEvalInicial = [];
ManCapacitacion_AddEdit.DataEvalFinal = [];
ManCapacitacion_AddEdit.DocumentoAdjunto = [];
ManCapacitacion_AddEdit.DataProgramacion = [];
ManCapacitacion_AddEdit.DataCronograma = [];

ManCapacitacion_AddEdit.fnLoadData = function (obj, tipo) {
    switch (tipo) {
        case "DataAsistente": ManCapacitacion_AddEdit.DataAsistente = obj; break;
        case "DataEquipoApoyo": ManCapacitacion_AddEdit.DataEquipoApoyo = obj; break;
        case "DataPonentes": ManCapacitacion_AddEdit.DataPonentes = obj; break;
        case "DataAportes": ManCapacitacion_AddEdit.DataAportes = obj; break;
        case "DataEncuestas": ManCapacitacion_AddEdit.DataEncuestas = obj; break;
        case "DataExamenes": ManCapacitacion_AddEdit.DataExamenes = obj; break;
        case "DataEvalInicial": ManCapacitacion_AddEdit.DataEvalInicial = obj; break;
        case "DataEvalFinal": ManCapacitacion_AddEdit.DataEvalFinal = obj; break;
        case "DataDocumentoAdjunto": ManCapacitacion_AddEdit.DataDocumentoAdjunto = obj; break;
        case "DataProgramacion": ManCapacitacion_AddEdit.DataProgramacion = obj; break;
        case "DataCronograma": ManCapacitacion_AddEdit.DataCronograma = obj; break;
    }
}

ManCapacitacion_AddEdit.fnReturnIndex = function (alertaInicial) {
    var tipoFormulario = ManCapacitacion_AddEdit.frm.find("#hdfFormulario").val() == "CAPACITACION" ? "0" : "1";

    if (alertaInicial == null || alertaInicial == "") {
        window.location = ManCapacitacion_AddEdit.frm.data("request_url") + "?_tipoFormulario=" + tipoFormulario;
    } else {
        window.location = ManCapacitacion_AddEdit.frm.data("request_url") + "?_alertaIncial=" + alertaInicial + "&_tipoFormulario=" + tipoFormulario;
    }
}

ManCapacitacion_AddEdit.fnShowDetOrganizador = function () {
    ManCapacitacion_AddEdit.frm.find("#dvDetOrganizador").hide();
    if (ManCapacitacion_AddEdit.frm.find("#ddlOrganizadorId").val() == "0000013") {//Organizador: OTROS
        ManCapacitacion_AddEdit.frm.find("#dvDetOrganizador").show();
    }
}

ManCapacitacion_AddEdit.fnShowTabConvenios = function () {
    ManCapacitacion_AddEdit.frm.find("#tabConvenios").hide();
    if (ManCapacitacion_AddEdit.frm.find("#chkMarConvenio").is(":checked")) {
        ManCapacitacion_AddEdit.frm.find("#tabConvenios").show();
    }
}

ManCapacitacion_AddEdit.fnShowGrupoConvenio = function () {
    //Actualmente existen 3 grupos de convenios, posible error cuando esto cambie
    for (var i = 0; i < 3; i++) {
        ManCapacitacion_AddEdit.frm.find("#ddlConvenioOsinforId").find("optgroup")[i].style = "display:none";
        for (var iopt = 0; iopt < ManCapacitacion_AddEdit.frm.find("#ddlConvenioOsinforId").find("optgroup")[i].childNodes.length; iopt++) {
            if (ManCapacitacion_AddEdit.frm.find("#ddlConvenioOsinforId").find("optgroup")[i].childNodes[iopt].nodeName == "OPTION"
                && ManCapacitacion_AddEdit.frm.find("#ddlConvenioOsinforId").find("optgroup")[i].childNodes[iopt].style.display != "none") {
                ManCapacitacion_AddEdit.frm.find("#ddlConvenioOsinforId").find("optgroup")[i].style = "display:auto";
                break;
            }
        }

        ManCapacitacion_AddEdit.frm.find("#ddlConvenioCapacitacionId").find("optgroup")[i].style = "display:none";
        for (var iopt = 0; iopt < ManCapacitacion_AddEdit.frm.find("#ddlConvenioCapacitacionId").find("optgroup")[i].childNodes.length; iopt++) {
            if (ManCapacitacion_AddEdit.frm.find("#ddlConvenioCapacitacionId").find("optgroup")[i].childNodes[iopt].nodeName == "OPTION"
                && ManCapacitacion_AddEdit.frm.find("#ddlConvenioCapacitacionId").find("optgroup")[i].childNodes[iopt].style.display != "none") {
                ManCapacitacion_AddEdit.frm.find("#ddlConvenioCapacitacionId").find("optgroup")[i].style = "display:auto";
                break;
            }
        }
    }
}

ManCapacitacion_AddEdit.fnShowDescTema = function () {
    ManCapacitacion_AddEdit.fnGetTemaSelect();//Obtener los temas seleccionados
    ManCapacitacion_AddEdit.frm.find("#dvDescTema").hide();
    if (ManCapacitacion_AddEdit.frm.find("#lstChkTemaId").val().includes("0000032")) {//Otros temas
        ManCapacitacion_AddEdit.frm.find("#dvDescTema").show();
    }
}

ManCapacitacion_AddEdit.fnShowGrupoPublicoObjetivo = function () {
    //Actualmente existen 8 grupos de público objetivo, posible error cuando esto cambie
    for (var i = 0; i < 8; i++) {
        ManCapacitacion_AddEdit.frm.find("#ddlPObjetivoOsinforId").find("optgroup")[i].style = "display:none";
        for (var iopt = 0; iopt < ManCapacitacion_AddEdit.frm.find("#ddlPObjetivoOsinforId").find("optgroup")[i].childNodes.length; iopt++) {
            if (ManCapacitacion_AddEdit.frm.find("#ddlPObjetivoOsinforId").find("optgroup")[i].childNodes[iopt].nodeName == "OPTION"
                && ManCapacitacion_AddEdit.frm.find("#ddlPObjetivoOsinforId").find("optgroup")[i].childNodes[iopt].style.display != "none") {
                ManCapacitacion_AddEdit.frm.find("#ddlPObjetivoOsinforId").find("optgroup")[i].style = "display:auto";
                break;
            }
        }

        ManCapacitacion_AddEdit.frm.find("#ddlPObjetivoCapacitacionId").find("optgroup")[i].style = "display:none";
        for (var iopt = 0; iopt < ManCapacitacion_AddEdit.frm.find("#ddlPObjetivoCapacitacionId").find("optgroup")[i].childNodes.length; iopt++) {
            if (ManCapacitacion_AddEdit.frm.find("#ddlPObjetivoCapacitacionId").find("optgroup")[i].childNodes[iopt].nodeName == "OPTION"
                && ManCapacitacion_AddEdit.frm.find("#ddlPObjetivoCapacitacionId").find("optgroup")[i].childNodes[iopt].style.display != "none") {
                ManCapacitacion_AddEdit.frm.find("#ddlPObjetivoCapacitacionId").find("optgroup")[i].style = "display:auto";
                break;
            }
        }
    }
}

ManCapacitacion_AddEdit.fnShowEvaluacion = function () {
    ManCapacitacion_AddEdit.frm.find("#dvEvaluacion_Aportes").hide();
    ManCapacitacion_AddEdit.frm.find("#dvEvaluacion_Encuestas").hide();
    ManCapacitacion_AddEdit.frm.find("#dvEvaluacion_Examenes").hide();
    ManCapacitacion_AddEdit.frm.find("#dvEvaluacion_EvalInicial").hide();
    ManCapacitacion_AddEdit.frm.find("#dvEvaluacion_EvalFinal").hide();

    switch (ManCapacitacion_AddEdit.frm.find("#ddlTipCapacitacionId").val()) {
        case "0000001"://Taller de Difusión
        case "0000006"://Otros Eventos
            ManCapacitacion_AddEdit.frm.find("#dvEvaluacion_Encuestas").show();
            ManCapacitacion_AddEdit.frm.find("#dvEvaluacion_Examenes").show();
            break;
        case "0000002"://Taller de Socialización
            ManCapacitacion_AddEdit.frm.find("#dvEvaluacion_Aportes").show();
            break;
        case "0000003"://Curso de Formación de Capacidades
            ManCapacitacion_AddEdit.frm.find("#dvEvaluacion_EvalInicial").show();
            ManCapacitacion_AddEdit.frm.find("#dvEvaluacion_EvalFinal").show();
            break;
        case "0000005"://Pasantía
        case "0000004"://Taller de Fortalecimiento de Capacidades
            ManCapacitacion_AddEdit.frm.find("#dvEvaluacion_EvalInicial").show();
            ManCapacitacion_AddEdit.frm.find("#dvEvaluacion_EvalFinal").show();
            ManCapacitacion_AddEdit.frm.find("#dvEvaluacion_Examenes").show();
            ManCapacitacion_AddEdit.frm.find("#dvEvaluacion_Encuestas").show();
            break;
        case "0000007"://Curso de Especialización Profesional
            ManCapacitacion_AddEdit.frm.find("#dvEvaluacion_Examenes").show();
            break;
    }
}

ManCapacitacion_AddEdit.fnLoadListConvenios = function () {
    var lstConvenioSelect = ManCapacitacion_AddEdit.frm.find("#ddlConvenioId").val().split(',');

    if (lstConvenioSelect.length > 0 && lstConvenioSelect[0] != "") {
        for (var i = 0; i < ManCapacitacion_AddEdit.frm.find("#ddlConvenioOsinforId").find("option").length; i++) {
            if (lstConvenioSelect.includes(ManCapacitacion_AddEdit.frm.find("#ddlConvenioOsinforId").find("option")[i].value)) {
                ManCapacitacion_AddEdit.frm.find("#ddlConvenioOsinforId").find("option")[i].style = "display:none";
            }
        }
        for (var i = 0; i < ManCapacitacion_AddEdit.frm.find("#ddlConvenioCapacitacionId").find("option").length; i++) {
            if (!lstConvenioSelect.includes(ManCapacitacion_AddEdit.frm.find("#ddlConvenioCapacitacionId").find("option")[i].value)) {
                ManCapacitacion_AddEdit.frm.find("#ddlConvenioCapacitacionId").find("option")[i].style = "display:none";
            } else {
                ManCapacitacion_AddEdit.frm.find("#ddlConvenioCapacitacionId").find("option")[i].style = "display:auto";
            }
        }
    } else {
        for (var i = 0; i < ManCapacitacion_AddEdit.frm.find("#ddlConvenioCapacitacionId").find("option").length; i++) {
            ManCapacitacion_AddEdit.frm.find("#ddlConvenioCapacitacionId").find("option")[i].style = "display:none";
        }
    }

    ManCapacitacion_AddEdit.fnShowGrupoConvenio();
}

ManCapacitacion_AddEdit.fnLoadListPublicoObjetivo = function () {
    var lstConvenioSelect = ManCapacitacion_AddEdit.frm.find("#ddlPublicoObjetivoId").val().split(',');

    if (lstConvenioSelect.length > 0 && lstConvenioSelect[0] != "") {
        for (var i = 0; i < ManCapacitacion_AddEdit.frm.find("#ddlPObjetivoOsinforId").find("option").length; i++) {
            if (lstConvenioSelect.includes(ManCapacitacion_AddEdit.frm.find("#ddlPObjetivoOsinforId").find("option")[i].value)) {
                ManCapacitacion_AddEdit.frm.find("#ddlPObjetivoOsinforId").find("option")[i].style = "display:none";
            }
        }
        for (var i = 0; i < ManCapacitacion_AddEdit.frm.find("#ddlPObjetivoCapacitacionId").find("option").length; i++) {
            if (!lstConvenioSelect.includes(ManCapacitacion_AddEdit.frm.find("#ddlPObjetivoCapacitacionId").find("option")[i].value)) {
                ManCapacitacion_AddEdit.frm.find("#ddlPObjetivoCapacitacionId").find("option")[i].style = "display:none";
            } else {
                ManCapacitacion_AddEdit.frm.find("#ddlPObjetivoCapacitacionId").find("option")[i].style = "display:auto";
            }
        }
    } else {
        for (var i = 0; i < ManCapacitacion_AddEdit.frm.find("#ddlPObjetivoCapacitacionId").find("option").length; i++) {
            ManCapacitacion_AddEdit.frm.find("#ddlPObjetivoCapacitacionId").find("option")[i].style = "display:none";
        }
    }

    ManCapacitacion_AddEdit.fnShowGrupoPublicoObjetivo();

    //Mostrar Div Ocultos
    ManCapacitacion_AddEdit.frm.find("#dvDescPObjRepresentante").hide();
    if (ManCapacitacion_AddEdit.frm.find("#ddlPublicoObjetivoId").val().includes("0000032")) {
        ManCapacitacion_AddEdit.frm.find("#dvDescPObjRepresentante").show();
    }
    ManCapacitacion_AddEdit.frm.find("#dvDescPObjOtroActor").hide();
    if (ManCapacitacion_AddEdit.frm.find("#ddlPublicoObjetivoId").val().includes("0000039")) {
        ManCapacitacion_AddEdit.frm.find("#dvDescPObjOtroActor").show();
    }
}

ManCapacitacion_AddEdit.fnInit = function () {
    $.fn.select2.defaults.set("theme", "bootstrap4");
    ManCapacitacion_AddEdit.frm.find("#ddlOdId").select2();
    ManCapacitacion_AddEdit.frm.find("#ddlCapacitacionEjecutarId").select2();
    ManCapacitacion_AddEdit.frm.find("#ddlTipCapacitacionId").select2();
    ManCapacitacion_AddEdit.frm.find("#ddlSumMetPoiId").select2({ minimumResultsForSearch: -1 });
    ManCapacitacion_AddEdit.frm.find("#ddlMetodologiaId").select2({ minimumResultsForSearch: -1 });
    ManCapacitacion_AddEdit.frm.find("#ddlOrganizadorId").select2({ minimumResultsForSearch: -1 });
    ManCapacitacion_AddEdit.frm.find("#ddlApoyoCoorganizadorId").select2();
    ManCapacitacion_AddEdit.frm.find("#ddlZonaUtmId").select2({ minimumResultsForSearch: -1 });
    ManCapacitacion_AddEdit.frm.find("#ddlTipoAdjuntoId").select2({ minimumResultsForSearch: -1 });

    if (ManCapacitacion_AddEdit.frm.find("#hdfCodCapacitacion").val()!="") {
        ManCapacitacion_AddEdit.frm.find("#ddlOdId").prop("disabled", "disabled");
        ManCapacitacion_AddEdit.frm.find("#ddlCapacitacionEjecutarId").prop("disabled", "disabled");
    }

    utilSigo.fnFormatDate(ManCapacitacion_AddEdit.frm.find("#txtFecInicio"));
    utilSigo.fnFormatDate(ManCapacitacion_AddEdit.frm.find("#txtFecTermino"));

    if (ManCapacitacion_AddEdit.frm.find("#txtDuracion").val() == "0") {
        ManCapacitacion_AddEdit.frm.find("#txtDuracion").val("");
    }
    if (ManCapacitacion_AddEdit.frm.find("#txtTotalParticipante").val() == "0") {
        ManCapacitacion_AddEdit.frm.find("#txtTotalParticipante").val("");
    }
    if (ManCapacitacion_AddEdit.frm.find("#txtCEste").val() == "0") {
        ManCapacitacion_AddEdit.frm.find("#txtCEste").val("");
    }
    if (ManCapacitacion_AddEdit.frm.find("#txtCNorte").val() == "0") {
        ManCapacitacion_AddEdit.frm.find("#txtCNorte").val("");
    }

    ManCapacitacion_AddEdit.frm.find("#ddlApoyoCoorganizadorId").select2("val", [ManCapacitacion_AddEdit.frm.find("#hdfApoyoCoorganizadorId").val().split(',')]);
}

ManCapacitacion_AddEdit.fnLoadComboCapacitacionEjecutar=function(_codOd) {
    $.ajax({
        url: urlLocalSigo + "CAPACITACION/ManProgramaCapacitacion/GetListCapacitacionProgramadaOd",
        type: 'GET',
        data: { asCodOd: _codOd, asFormularioConsulta: ManCapacitacion_AddEdit.frm.find("#hdfFormulario").val() },
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (result) {
            utilSigo.unblockUIGeneral();
            var $option = $('<option>');
            $option.val("0000000");
            $option.html("Seleccionar");
            ManCapacitacion_AddEdit.frm.find("#ddlCapacitacionEjecutarId").html("");
            ManCapacitacion_AddEdit.frm.find("#ddlCapacitacionEjecutarId").append($option);

            $.each(result.data, function (i, row) {
                $option = $('<option>');
                $option.val(row.Value);
                $option.html(row.Text);
                ManCapacitacion_AddEdit.frm.find("#ddlCapacitacionEjecutarId").append($option);
            })
        },
        beforeSend: function () {
            utilSigo.blockUIGeneral();
        },
        error: function (jqXHR, error, errorThrown) {
            utilSigo.unblockUIGeneral();
            utilSigo.toastError("Error", "Sucedio un Error Inesperado, Comuniquese con el Administrador");
            console.log(jqXHR.responseText);
        }
    });
}

ManCapacitacion_AddEdit.fnLoadDataCapacitacionProgramada = function (_codPCapacitacion) {
    $.ajax({
        url: urlLocalSigo + "CAPACITACION/ManProgramaCapacitacion/GetCapacitacionProgramada",
        type: 'GET',
        data: { asCodPCapacitacion: _codPCapacitacion },
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (result) {
            utilSigo.unblockUIGeneral();

            ManCapacitacion_AddEdit.frm.find("#txtNomCapacitacion").val(result.data.txtNomPCapacitacion);
            ManCapacitacion_AddEdit.frm.find("#ddlTipCapacitacionId").select2("val",[result.data.ddlTipPCapacitacionId]);
            ManCapacitacion_AddEdit.frm.find("#ddlSumMetPoiId").select2("val",[result.data.ddlSumMetPoiId]);
            ManCapacitacion_AddEdit.frm.find("#chkMarConvenio").prop("checked", result.data.chkMarConvenio);
            ManCapacitacion_AddEdit.frm.find("#txtFecInicio").val(result.data.txtFecInicio);
            ManCapacitacion_AddEdit.frm.find("#lblUbigeo").val(result.data.lblUbigeo);
            ManCapacitacion_AddEdit.frm.find("#hdfUbigeo").val(result.data.hdfUbigeo);
            ManCapacitacion_AddEdit.frm.find("#ddlConvenioId").val(result.data.ddlConvenioId);

            ManCapacitacion_AddEdit.fnShowTabConvenios();
            ManCapacitacion_AddEdit.fnLoadListConvenios();
            ManCapacitacion_AddEdit.fnShowEvaluacion();
        },
        beforeSend: function () {
            utilSigo.blockUIGeneral();
        },
        error: function (jqXHR, error, errorThrown) {
            utilSigo.unblockUIGeneral();
            utilSigo.toastError("Error", "Sucedio un Error Inesperado, Comuniquese con el Administrador");
            console.log(jqXHR.responseText);
        }
    });
}

ManCapacitacion_AddEdit.fnSubmitForm = function () {
    var controls = ["ddlIndicadorId", "ddlOdId", "ddlCapacitacionEjecutarId", "txtNomCapacitacion", "ddlTipCapacitacionId", "ddlSumMetPoiId", "txtObjetivo", "ddlMetodologiaId"];

    if (!utilSigo.fnValidateForm(ManCapacitacion_AddEdit.frm, controls)) {
        return ManCapacitacion_AddEdit.frm.valid();
    }
    ManCapacitacion_AddEdit.frm.submit();
}

ManCapacitacion_AddEdit.fnGetTemaSelect = function () {
    var chkTema;
    var selectTema = "";
    for (var i = 1; i <= ManCapacitacion_AddEdit.frm.find("[id*=lstChkTema]").length; i++) {
        if (i % 2 == 0) {
            chkTema = ManCapacitacion_AddEdit.frm.find("[id*=lstChkTema]")[i - 1].checked;
            if (chkTema) {
                selectTema += selectTema == "" ? "" : ",";
                selectTema += ManCapacitacion_AddEdit.frm.find("[id*=lstChkTema]")[i - 2].value;
            }
        }
    }

    ManCapacitacion_AddEdit.frm.find("#lstChkTemaId").val(selectTema);
}

ManCapacitacion_AddEdit.fnSaveForm = function () {
    var datosCapacitacion = ManCapacitacion_AddEdit.frm.serializeObject();
    datosCapacitacion.ddlOdId = ManCapacitacion_AddEdit.frm.find("#ddlOdId").val();
    datosCapacitacion.ddlCapacitacionEjecutarId = ManCapacitacion_AddEdit.frm.find("#ddlCapacitacionEjecutarId").val();
    datosCapacitacion.txtNomCapacitacion = ManCapacitacion_AddEdit.frm.find("#txtNomCapacitacion").val();
    datosCapacitacion.ddlTipCapacitacionId = ManCapacitacion_AddEdit.frm.find("#ddlTipCapacitacionId").val();
    datosCapacitacion.ddlSumMetPoiId = ManCapacitacion_AddEdit.frm.find("#ddlSumMetPoiId").val();
    datosCapacitacion.chkMarConvenio = ManCapacitacion_AddEdit.frm.find("#chkMarConvenio").is(":checked");
    datosCapacitacion.ddlApoyoCoorganizadorId = ManCapacitacion_AddEdit.frm.find("#ddlApoyoCoorganizadorId").val().join();
    datosCapacitacion.vmControlCalidad = _ControlCalidad.fnGetDatosControlCalidad();

    datosCapacitacion.lstChkTema = null;
    ManCapacitacion_AddEdit.fnGetTemaSelect();//Obtener los temas seleccionados

    //Capturar los convenios seleccionados
    datosCapacitacion.ddlConvenioId = "";
    for (var i = 0; i < ManCapacitacion_AddEdit.frm.find("#ddlConvenioCapacitacionId").find("option").length; i++) {
        if (ManCapacitacion_AddEdit.frm.find("#ddlConvenioCapacitacionId").find("option")[i].style.display != "none") {
            if (datosCapacitacion.ddlConvenioId == "") {
                datosCapacitacion.ddlConvenioId = ManCapacitacion_AddEdit.frm.find("#ddlConvenioCapacitacionId").find("option")[i].value;
            } else {
                datosCapacitacion.ddlConvenioId += "," + ManCapacitacion_AddEdit.frm.find("#ddlConvenioCapacitacionId").find("option")[i].value;
            }
        }
    }
    //Capturar el Público Objetivo seleccionado
    datosCapacitacion.ddlPublicoObjetivoId = "";
    for (var i = 0; i < ManCapacitacion_AddEdit.frm.find("#ddlPObjetivoCapacitacionId").find("option").length; i++) {
        if (ManCapacitacion_AddEdit.frm.find("#ddlPObjetivoCapacitacionId").find("option")[i].style.display != "none") {
            if (datosCapacitacion.ddlPublicoObjetivoId == "") {
                datosCapacitacion.ddlPublicoObjetivoId = ManCapacitacion_AddEdit.frm.find("#ddlPObjetivoCapacitacionId").find("option")[i].value;
            } else {
                datosCapacitacion.ddlPublicoObjetivoId += "," + ManCapacitacion_AddEdit.frm.find("#ddlPObjetivoCapacitacionId").find("option")[i].value;
            }
        }
    }

    datosCapacitacion.tbParticipante_Asistentes = ManCapacitacion_AddEdit.fnGetListParticipante("ASISTENTE", true);
    datosCapacitacion.tbParticipante_EquipoApoyo = ManCapacitacion_AddEdit.fnGetListParticipante("EQUIPO", true);
    datosCapacitacion.tbParticipante_Ponentes = ManCapacitacion_AddEdit.fnGetListParticipante("PONENTE", true);
    datosCapacitacion.tbEvaluacion_Encuestas = ManCapacitacion_AddEdit.fnGetListEvaluacion("ENCUESTA");
    datosCapacitacion.tbEvaluacion_EvalInicial = ManCapacitacion_AddEdit.fnGetListEvaluacion("EVALINICIAL");
    datosCapacitacion.tbEvaluacion_EvalFinal = ManCapacitacion_AddEdit.fnGetListEvaluacion("EVALFINAL");
    datosCapacitacion.tbEvaluacion_Examenes = ManCapacitacion_AddEdit.fnGetListEvaluacion("EXAMEN");
    datosCapacitacion.tbProgramacion = ManCapacitacion_AddEdit.fnGetListProgramacion();
    datosCapacitacion.tbCronograma = ManCapacitacion_AddEdit.fnGetListCronograma();
    datosCapacitacion.tbEliTABLA = ManCapacitacion_AddEdit.tbEliTABLA;


    $.ajax({
        url: ManCapacitacion_AddEdit.frm.action,
        type: 'POST',
        data: JSON.stringify(datosCapacitacion),
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function (data) {
            utilSigo.unblockUIGeneral();
            if (data.success) {
                ManCapacitacion_AddEdit.fnReturnIndex(data.msj);
            }
            //else utilSigo.toastWarning("Aviso", data.msj);
            else utilSigo.toastWarning("Aviso", "Sucedio un error, Comuníquese con el Administrador");
        },
        beforeSend: function () {
            utilSigo.blockUIGeneral();
        },
        error: function (jqXHR, error, errorThrown) {
            utilSigo.unblockUIGeneral();
            utilSigo.toastError("Error", "Sucedio un error, Comuníquese con el Administrador");
            console.log(jqXHR.responseText);
        }
    });
}

ManCapacitacion_AddEdit.fnViewModalUbigeo = function () {
    var url = urlLocalSigo + "General/Controles/_Ubigeo";
    var option = { url: url, type: 'POST', datos: {}, divId: "mdlManCapacitacion_AddEdit_Ubigeo" };
    utilSigo.fnOpenModal(option, function () {
        _Ubigeo.fnSelectUbigeo = function (_ubigeoText,_ubigeoId) {
            ManCapacitacion_AddEdit.frm.find("#hdfUbigeo").val(_ubigeoId);
            ManCapacitacion_AddEdit.frm.find("#lblUbigeo").val(_ubigeoText);
            $("#mdlManCapacitacion_AddEdit_Ubigeo").modal('hide');
        }
        _Ubigeo.fnLoadModalView(ManCapacitacion_AddEdit.frm.find("#hdfUbigeo").val());
    }, ManCapacitacion_AddEdit.fnCustomValidateForm);
}

ManCapacitacion_AddEdit.fnCustomValidateForm = function () {
    if (!utilSigo.fnValidateForm_HideControl(ManCapacitacion_AddEdit.frm, ManCapacitacion_AddEdit.frm.find('#hdfUbigeo'), ManCapacitacion_AddEdit.frm.find('#iconUbigeo'), true)) return false;
    return true;
}

ManCapacitacion_AddEdit.fnInitDataTable_Detail = function () {
    var columns_label = [], columns_data = [], options = {};
    //Cargar Programacion
    columns_label = ["Dia", "Hora", "Tema", "Responsable"];
    columns_data = ["FECHA_PROGRAMA", "HORA", "TEMA", "RESPONSABLE"];
    options = {
        page_length: 10, row_index: true, button_copy: true, button_csv: true, button_excel: true, button_pdf: true, button_print: true
        , row_delete: true, row_fnDelete: "ManCapacitacion_AddEdit.fnDeleteProgramacion(this)"
        , export_title: $("#tbProgramacion").find("thead tr")[0].innerText.trim()
    };
    ManCapacitacion_AddEdit.dtProgramacion = utilDt.fnLoadDataTable_Detail(ManCapacitacion_AddEdit.frm.find("#tbProgramacion"), columns_label, columns_data, options);
    ManCapacitacion_AddEdit.dtProgramacion.rows.add(JSON.parse(ManCapacitacion_AddEdit.DataProgramacion)).draw();

    //Cargar Cronograma
    columns_label = ["Actividad", "Fecha Inicio", "Fecha fin"];
    columns_data = ["ACTIVIDAD", "FECHA_INICIO_CRONOGRAMA", "FECHA_FIN_CRONOGRAMA"];
    options = {
        page_length: 10, row_index: true, button_copy: true, button_csv: true, button_excel: true, button_pdf: true, button_print: true
        , row_delete: true, row_fnDelete: "ManCapacitacion_AddEdit.fnDeleteCronograma(this)"
        , export_title: $("#tbCronograma").find("thead tr")[0].innerText.trim()
    };
    ManCapacitacion_AddEdit.dtCronograma = utilDt.fnLoadDataTable_Detail(ManCapacitacion_AddEdit.frm.find("#tbCronograma"), columns_label, columns_data, options);
    ManCapacitacion_AddEdit.dtCronograma.rows.add(JSON.parse(ManCapacitacion_AddEdit.DataCronograma)).draw();
    
    

    //Cargar Participante - Asistentes
    columns_label = ["Apellidos y Nombres", "N° Documento", "Grupo Público", "Público", "Cargo", "Género", "Edad", "Título Habilitante"
                        ,"Comunidad Nativa","Etnia", "Teléfono", "Correo", "Constancia", "Observación"];
    columns_data = ["APELLIDOS_NOMBRES", "N_DOCUMENTO", "GRUPOPUBLICOPARTICIPANTE", "PUBLICOPARTICIPANTE", "CARGO", "GENERO", "EDAD", "NUM_THABILITANTE"
                        , "CCNN", "ETNIA", "TELEFONO", "CORREO", "COD_CONSTANCIA", "OBSERVACION"];
    options = {
        page_length: 10, row_edit: true, row_fnEdit: "ManCapacitacion_AddEdit.fnAddEditParticipante(this,'ASISTENTE')"
        , row_delete: true, row_fnDelete: "ManCapacitacion_AddEdit.fnDeleteParticipante(this,'ASISTENTE')"
        , row_index: true, button_copy: true, button_csv: true, button_excel: true, button_pdf: true, button_print: true
        , export_title: $("#tbParticipante_Asistentes").find("thead tr")[0].innerText.trim()
        , page_search: true, page_info: true, page_sort: true
    };
    ManCapacitacion_AddEdit.dtParticipante_Asistentes = utilDt.fnLoadDataTable_Detail(ManCapacitacion_AddEdit.frm.find("#tbParticipante_Asistentes"), columns_label, columns_data, options);
    ManCapacitacion_AddEdit.dtParticipante_Asistentes.rows.add(JSON.parse(ManCapacitacion_AddEdit.DataAsistente)).draw();
    
    //Cargar Participante - Equipo Apoyo
    columns_label = ["Apellidos y Nombres", "N° Documento", "Institución", "Cargo", "Función", "Observación"];
    columns_data = ["APELLIDOS_NOMBRES", "N_DOCUMENTO", "NOM_INSTITUCION", "CARGO", "FUNCION", "OBSERVACION"];
    options = {
        page_length: 10, row_edit: true, row_fnEdit: "ManCapacitacion_AddEdit.fnAddEditParticipante(this,'EQUIPO')"
        , row_delete: true, row_fnDelete: "ManCapacitacion_AddEdit.fnDeleteParticipante(this,'EQUIPO')"
        , row_index: true, button_copy: true, button_csv: true, button_excel: true, button_pdf: true, button_print: true
        , export_title: $("#tbParticipante_EquipoApoyo").find("thead tr")[0].innerText.trim(), page_sort: true
    };
    ManCapacitacion_AddEdit.dtParticipante_EquipoApoyo = utilDt.fnLoadDataTable_Detail(ManCapacitacion_AddEdit.frm.find("#tbParticipante_EquipoApoyo"), columns_label, columns_data, options);
    ManCapacitacion_AddEdit.dtParticipante_EquipoApoyo.rows.add(JSON.parse(ManCapacitacion_AddEdit.DataEquipoApoyo)).draw();

    //Cargar Participante - Ponentes
    columns_label = ["Apellidos y Nombres", "N° Documento", "Institución", "Cargo", "Tema Desarrollado", "Constancia", "Observación"];
    columns_data = ["APELLIDOS_NOMBRES", "N_DOCUMENTO", "NOM_INSTITUCION", "CARGO", "FUNCION", "COD_CONSTANCIA", "OBSERVACION"];
    options = {
        page_length: 10, row_edit: true, row_fnEdit: "ManCapacitacion_AddEdit.fnAddEditParticipante(this,'PONENTE')"
        , row_delete: true, row_fnDelete: "ManCapacitacion_AddEdit.fnDeleteParticipante(this,'PONENTE')"
        , row_index: true, button_copy: true, button_csv: true, button_excel: true, button_pdf: true, button_print: true
        , export_title: $("#tbParticipante_Ponentes").find("thead tr")[0].innerText.trim(), page_sort: true
    };
    ManCapacitacion_AddEdit.dtParticipante_Ponentes = utilDt.fnLoadDataTable_Detail(ManCapacitacion_AddEdit.frm.find("#tbParticipante_Ponentes"), columns_label, columns_data, options);
    ManCapacitacion_AddEdit.dtParticipante_Ponentes.rows.add(JSON.parse(ManCapacitacion_AddEdit.DataPonentes)).draw();

    //Cargar Evaluación - Aportes
    columns_label =["Apellidos y Nombres", "N° Documento", "Institución", "Aporte"];
    columns_data = ["APELLIDOS_NOMBRES", "N_DOCUMENTO", "NOM_INSTITUCION", "APORTE"];
    options = {
        page_length: 10, row_index: true, button_copy: true, button_csv: true, button_excel: true, button_pdf: true, button_print: true
        , export_title: $("#tbEvaluacion_Aportes").find("thead tr")[0].innerText.trim()
    };
    ManCapacitacion_AddEdit.dtEvaluacion_Aportes = utilDt.fnLoadDataTable_Detail(ManCapacitacion_AddEdit.frm.find("#tbEvaluacion_Aportes"), columns_label, columns_data, options);
    ManCapacitacion_AddEdit.dtEvaluacion_Aportes.rows.add(JSON.parse(ManCapacitacion_AddEdit.DataAportes)).draw();

    //Cargar Evaluación - Encuestas
    columns_label = ["Pregunta", "N° de participantes que marcaron Bueno", "% de participantes que marcaron Bueno"
                    ,"N° de participantes que marcaron Regular", "% de participantes que marcaron Regular", "N° de participantes que marcaron Malo"
                    , "% de participantes que marcaron Malo", "N° de participantes que NO marcaron", "% de participantes que NO marcaron", "Total participantes evaluados"];
    columns_data = ["DES_PREGUNTA", "N_CHECK_BUENO", "P_CHECK_BUENO", "N_CHECK_REGULAR", "P_CHECK_REGULAR"
                    , "N_CHECK_MALO", "P_CHECK_MALO", "N_NO_CHECK", "P_NO_CHECK", "N_PARTICIPANTES"];
    options = {
        page_length: 10, row_edit: true, row_fnEdit: "ManCapacitacion_AddEdit.fnAddEditPreguntaEncuesta(this,'ENCUESTA')"
        , row_delete: true, row_fnDelete: "ManCapacitacion_AddEdit.fnDeleteEvaluacion(this,'ENCUESTA')"
        , row_index: true, button_copy: true, button_csv: true, button_excel: true, button_pdf: true, button_print: true
        , export_title: $("#tbEvaluacion_Encuestas").find("thead tr")[0].innerText.trim()
    };
    ManCapacitacion_AddEdit.dtEvaluacion_Encuestas = utilDt.fnLoadDataTable_Detail(ManCapacitacion_AddEdit.frm.find("#tbEvaluacion_Encuestas"), columns_label, columns_data, options);
    ManCapacitacion_AddEdit.dtEvaluacion_Encuestas.rows.add(JSON.parse(ManCapacitacion_AddEdit.DataEncuestas)).draw();

    //Cargar Evaluación - Evaluación Inicial
    columns_label = ["Pregunta", "N° de participantes que marcaron Bueno", "% de participantes que marcaron Bueno"
                    , "N° de participantes que marcaron Regular", "% de participantes que marcaron Regular", "N° de participantes que marcaron Malo"
                    , "% de participantes que marcaron Malo", "N° de participantes que NO marcaron", "% de participantes que NO marcaron", "Total participantes evaluados"];
    columns_data = ["DES_PREGUNTA", "N_CHECK_BUENO", "P_CHECK_BUENO", "N_CHECK_REGULAR", "P_CHECK_REGULAR"
                    , "N_CHECK_MALO", "P_CHECK_MALO", "N_NO_CHECK", "P_NO_CHECK", "N_PARTICIPANTES"];
    options = {
        page_length: 10, row_edit: true, row_fnEdit: "ManCapacitacion_AddEdit.fnAddEditPreguntaEncuesta(this,'EVALINICIAL')"
        , row_delete: true, row_fnDelete: "ManCapacitacion_AddEdit.fnDeleteEvaluacion(this,'EVALINICIAL')"
        , row_index: true, button_copy: true, button_csv: true, button_excel: true, button_pdf: true, button_print: true
        , export_title: $("#tbEvaluacion_EvalInicial").find("thead tr")[0].innerText.trim()
    };
    ManCapacitacion_AddEdit.dtEvaluacion_EvalInicial = utilDt.fnLoadDataTable_Detail(ManCapacitacion_AddEdit.frm.find("#tbEvaluacion_EvalInicial"), columns_label, columns_data, options);
    ManCapacitacion_AddEdit.dtEvaluacion_EvalInicial.rows.add(JSON.parse(ManCapacitacion_AddEdit.DataEvalInicial)).draw();

    //Cargar Evaluación - Evaluación Final
    columns_label = ["Pregunta", "N° de participantes que marcaron Bueno", "% de participantes que marcaron Bueno"
                    , "N° de participantes que marcaron Regular", "% de participantes que marcaron Regular", "N° de participantes que marcaron Malo"
                    , "% de participantes que marcaron Malo", "N° de participantes que NO marcaron", "% de participantes que NO marcaron", "Total participantes evaluados"];
    columns_data = ["DES_PREGUNTA", "N_CHECK_BUENO", "P_CHECK_BUENO", "N_CHECK_REGULAR", "P_CHECK_REGULAR"
                    , "N_CHECK_MALO", "P_CHECK_MALO", "N_NO_CHECK", "P_NO_CHECK", "N_PARTICIPANTES"];
    options = {
        page_length: 10, row_edit: true, row_fnEdit: "ManCapacitacion_AddEdit.fnAddEditPreguntaEncuesta(this,'EVALFINAL')"
        , row_delete: true, row_fnDelete: "ManCapacitacion_AddEdit.fnDeleteEvaluacion(this,'EVALFINAL')"
        , row_index: true, button_copy: true, button_csv: true, button_excel: true, button_pdf: true, button_print: true
        , export_title: $("#tbEvaluacion_EvalFinal").find("thead tr")[0].innerText.trim()
    };
    ManCapacitacion_AddEdit.dtEvaluacion_EvalFinal = utilDt.fnLoadDataTable_Detail(ManCapacitacion_AddEdit.frm.find("#tbEvaluacion_EvalFinal"), columns_label, columns_data, options);
    ManCapacitacion_AddEdit.dtEvaluacion_EvalFinal.rows.add(JSON.parse(ManCapacitacion_AddEdit.DataEvalFinal)).draw();

    //Cargar Evaluación - Exámenes
    columns_label = ["Apellidos y Nombres", "N° Documento", "Institución", "Nota Examen Inicio", "Nota Examen Final"];
    columns_data = ["APELLIDOS_NOMBRES", "N_DOCUMENTO", "NOM_INSTITUCION", "NOTA_EXA_INICIO", "NOTA_EXA_FIN"];
    options = {
        page_length: 10, row_edit: true, row_fnEdit: "ManCapacitacion_AddEdit.fnAddEditNotaExamen(this)"
        , row_delete: true, row_fnDelete: "ManCapacitacion_AddEdit.fnDeleteEvaluacion(this,'EXAMEN')"
        , row_index: true, button_copy: true, button_csv: true, button_excel: true, button_pdf: true, button_print: true
        , export_title: $("#tbEvaluacion_Examenes").find("thead tr")[0].innerText.trim()
    };
    ManCapacitacion_AddEdit.dtEvaluacion_Examenes = utilDt.fnLoadDataTable_Detail(ManCapacitacion_AddEdit.frm.find("#tbEvaluacion_Examenes"), columns_label, columns_data, options);
    ManCapacitacion_AddEdit.dtEvaluacion_Examenes.rows.add(JSON.parse(ManCapacitacion_AddEdit.DataExamenes)).draw();

    //Cargar Documentos Adjuntos
    columns_label = ["Tipo","Archivo", "Extensión", "Observaciones"];
    columns_data = ["TIPO_ADJUNTO", "NOMBRE_ARCHIVO", "EXTENSION", "OBSERVACION"];
    options = {
        page_length: 10, row_delete: true, row_fnDelete: "ManCapacitacion_AddEdit.fnDeleteDocumentoAdjunto(this)"
        , row_download: true, row_fnDownload: "ManCapacitacion_AddEdit.fnDownloadDocumentoAdjunto(this)"
        , row_index: true, button_copy: true, button_csv: true, button_excel: true, button_pdf: true, button_print: true
        , export_title: $("#tbDocumentoAdjunto").find("thead tr")[0].innerText.trim()
    };
    ManCapacitacion_AddEdit.dtDocumentoAdjunto = utilDt.fnLoadDataTable_Detail(ManCapacitacion_AddEdit.frm.find("#tbDocumentoAdjunto"), columns_label, columns_data, options);
    ManCapacitacion_AddEdit.dtDocumentoAdjunto.rows.add(JSON.parse(ManCapacitacion_AddEdit.DataDocumentoAdjunto)).draw();
}

/*Controles PARTICIPANTES*/
ManCapacitacion_AddEdit.fnAddEditParticipante = function (obj,_tipoParticipante) {
    var url = urlLocalSigo + "Capacitacion/ManCapacitacion/_Participante";
    var option = { url: url, type: 'POST', datos: {}, divId: "mdlManCapacitacion_AddEdit_Participante" };
    utilSigo.fnOpenModal(option, function () {
        _Participante.fnCloseModal = function () { $("#mdlManCapacitacion_AddEdit_Participante").modal('hide'); }
        _Participante.fnSaveForm = function (data) {
            if (data != null) {
                var dt;
                switch (_tipoParticipante) {
                    case "ASISTENTE":
                        dt = ManCapacitacion_AddEdit.dtParticipante_Asistentes;
                        break;
                    case "PONENTE":
                        dt = ManCapacitacion_AddEdit.dtParticipante_Ponentes;
                        break;
                    case "EQUIPO":
                        dt = ManCapacitacion_AddEdit.dtParticipante_EquipoApoyo;
                        break;
                }

                if (data["RegEstado"] == "1") {//Nuevo Registro
                    dt.rows.add([data]).draw();
                    dt.page('last').draw('page');
                    utilSigo.toastSuccess("Exito", "Datos guardados correctamente");
                } else {//Modificar
                    var row = dt.row($(obj).parents('tr')).data();
                    row = data;
                    dt.row($(obj).parents('tr')).data(row).draw(false);
                    utilSigo.toastSuccess("Exito", "Datos actualizados correctamente");
                }
                $("#mdlManCapacitacion_AddEdit_Participante").modal('hide');
            } else {
                utilSigo.toastSuccess("Error", "No se pudieron guardar los datos");
            }
        }

        if (obj != null && obj != "") {
            var data;
            switch (_tipoParticipante) {
                case "ASISTENTE":
                    data = ManCapacitacion_AddEdit.dtParticipante_Asistentes.row($(obj).parents('tr')).data();
                    break;
                case "PONENTE":
                    data = ManCapacitacion_AddEdit.dtParticipante_Ponentes.row($(obj).parents('tr')).data();
                    break;
                case "EQUIPO":
                    data = ManCapacitacion_AddEdit.dtParticipante_EquipoApoyo.row($(obj).parents('tr')).data();
                    break;
            }
            _Participante.fnInit(_tipoParticipante, utilSigo.fnConvertArrayToObject(data));
        } else {
            _Participante.fnInit(_tipoParticipante, "");
        }
    });
}

ManCapacitacion_AddEdit.fnGetListParticipante = function (_tipoParticipante,isEventSave) {
    var dt, list = [], rows, countFilas, data;

    switch (_tipoParticipante) {
        case "ASISTENTE":
            dt = ManCapacitacion_AddEdit.dtParticipante_Asistentes;
            break;
        case "PONENTE":
            dt = ManCapacitacion_AddEdit.dtParticipante_Ponentes;
            break;
        case "EQUIPO":
            dt = ManCapacitacion_AddEdit.dtParticipante_EquipoApoyo;
            break;
    }

    rows = dt.$("tr");
    countFilas = rows.length;
    if (countFilas>0) {
        $.each(rows, function (i, o) {
            data = dt.row($(o)).data();
            if (data["RegEstado"] == "1" || data["RegEstado"] == "2" || isEventSave==false) {
                list.push(utilSigo.fnConvertArrayToObject(data));
            }
        });
    }

    return list;
}

ManCapacitacion_AddEdit.fnDeleteParticipante = function (obj, _tipoParticipante) {
    var dt, data;

    switch (_tipoParticipante) {
        case "ASISTENTE":
            dt = ManCapacitacion_AddEdit.dtParticipante_Asistentes;
            break;
        case "PONENTE":
            dt = ManCapacitacion_AddEdit.dtParticipante_Ponentes;
            break;
        case "EQUIPO":
            dt = ManCapacitacion_AddEdit.dtParticipante_EquipoApoyo;
            break;
    }

    data = dt.row($(obj).parents('tr')).data();
    if (data["RegEstado"] == "0" || data["RegEstado"] == "2") {
        ManCapacitacion_AddEdit.tbEliTABLA.push({
            EliTABLA: "CAPACITACION_PARTICIPANTES",
            EliVALOR01: data["COD_PERSONA"],
            EliVALOR03: data["MAE_COD_TIPOPARTICIPANTE"]
        });
    }
    dt.row($(obj).parents('tr')).remove().draw(false);
    //utilDt.enumColumn(dt, "ROW_INDEX");
}

ManCapacitacion_AddEdit.fnDeleteParticipanteAll = function (_tipoParticipante) {
    var dt, rows, countFilas,data;

    switch (_tipoParticipante) {
        case "ASISTENTE":
            dt = ManCapacitacion_AddEdit.dtParticipante_Asistentes;
            break;
        case "PONENTE":
            dt = ManCapacitacion_AddEdit.dtParticipante_Ponentes;
            break;
        case "EQUIPO":
            dt = ManCapacitacion_AddEdit.dtParticipante_EquipoApoyo;
            break;
    }

    rows = dt.$("tr");
    countFilas = rows.length;
    if (countFilas > 0) {
        utilSigo.dialogConfirm("", "Está seguro de Eliminar Todos los Registros?", function (r) {
            if (r) {
                $.each(rows, function (i, o) {
                    data = dt.row($(o)).data();
                    if (data["RegEstado"] == "0" || data["RegEstado"] == "2") {
                        ManCapacitacion_AddEdit.tbEliTABLA.push({
                            EliTABLA: "CAPACITACION_PARTICIPANTES",
                            EliVALOR01: data["COD_PERSONA"],
                            EliVALOR03: data["MAE_COD_TIPOPARTICIPANTE"]
                        });
                    }
                });
                dt.clear().draw();
            }
        });
    } else {
        utilSigo.toastWarning("Aviso", "No hay Registros a Eliminar");
    }
}
/*Fin Participante*/

/*Controles EVALUACION*/
ManCapacitacion_AddEdit.fnAddEditPreguntaEncuesta = function (obj,_tipoEncuesta) {
    var url = urlLocalSigo + "Capacitacion/ManCapacitacion/_PreguntaEncuesta";
    var option = { url: url, type: 'POST', datos: {}, divId: "mdlManCapacitacion_Evaluacion_Encuesta" };
    utilSigo.fnOpenModal(option, function () {
        _PreguntaEncuesta.fnCloseModal = function () { $("#mdlManCapacitacion_Evaluacion_Encuesta").modal('hide'); }
        _PreguntaEncuesta.fnSaveForm = function (data) {
            if (data != null) {
                var dt;
                switch (_tipoEncuesta) {
                    case "ENCUESTA":
                        dt = ManCapacitacion_AddEdit.dtEvaluacion_Encuestas;
                        break;
                    case "EVALINICIAL":
                        dt = ManCapacitacion_AddEdit.dtEvaluacion_EvalInicial;
                        break;
                    case "EVALFINAL":
                        dt = ManCapacitacion_AddEdit.dtEvaluacion_EvalFinal;
                        break;
                    
                }

                if (obj == null || obj == "") {//Nuevo Registro
                    dt.rows.add([data]).draw();
                    dt.page('last').draw('page');
                    utilSigo.toastSuccess("Exito", "Datos guardados correctamente");
                } else {//Modificar
                    var row = dt.row($(obj).parents('tr')).data();
                    row = data;
                    dt.row($(obj).parents('tr')).data(row).draw(false);
                    utilSigo.toastSuccess("Exito", "Datos actualizados correctamente");
                }
                $("#mdlManCapacitacion_Evaluacion_Encuesta").modal('hide');
            } else {
                utilSigo.toastSuccess("Error", "No se pudieron guardar los datos");
            }
        }

        if (obj != null && obj != "") {
            var data;
            switch (_tipoEncuesta) {
                case "ENCUESTA":
                    data = ManCapacitacion_AddEdit.dtEvaluacion_Encuestas.row($(obj).parents('tr')).data();
                    break;
                case "EVALINICIAL":
                    data = ManCapacitacion_AddEdit.dtEvaluacion_EvalInicial.row($(obj).parents('tr')).data();
                    break;
                case "EVALFINAL":
                    data = ManCapacitacion_AddEdit.dtEvaluacion_EvalFinal.row($(obj).parents('tr')).data();
                    break;
            }

            _PreguntaEncuesta.fnInit(_tipoEncuesta, utilSigo.fnConvertArrayToObject(data));
        } else { _PreguntaEncuesta.fnInit(_tipoEncuesta, ""); }
        
    });
}

ManCapacitacion_AddEdit.fnAddEditNotaExamen = function (obj) {
    var url = urlLocalSigo + "Capacitacion/ManCapacitacion/_NotaExamen";
    var option = { url: url, type: 'POST', datos: {}, divId: "mdlManCapacitacion_Evaluacion_Examen" };
    utilSigo.fnOpenModal(option, function () {
        _NotaExamen.fnCloseModal = function () { $("#mdlManCapacitacion_Evaluacion_Examen").modal('hide'); }
        _NotaExamen.fnSaveForm = function (data) {
            if (data != null) {
                var dt = ManCapacitacion_AddEdit.dtEvaluacion_Examenes;

                if (obj == null || obj == "") {//Nuevo Registro
                    dt.rows.add([data]).draw();
                    dt.page('last').draw('page');
                    utilSigo.toastSuccess("Exito", "Datos guardados correctamente");
                } else {//Modificar
                    var row = dt.row($(obj).parents('tr')).data();
                    row = data;
                    dt.row($(obj).parents('tr')).data(row).draw(false);
                    utilSigo.toastSuccess("Exito", "Datos actualizados correctamente");
                }
                $("#mdlManCapacitacion_Evaluacion_Examen").modal('hide');
            } else {
                utilSigo.toastSuccess("Error", "No se pudieron guardar los datos");
            }
        }

        if (obj != null && obj != "") {
            var data=ManCapacitacion_AddEdit.dtEvaluacion_Examenes.row($(obj).parents('tr')).data();
            _NotaExamen.fnInit(utilSigo.fnConvertArrayToObject(data));
        } else { _NotaExamen.fnInit(""); }
    });
}

ManCapacitacion_AddEdit.fnGetListEvaluacion = function (_tipoEvaluacion) {
    var dt, list = [], rows, countFilas, data;

    switch (_tipoEvaluacion) {
        case "ENCUESTA":
            dt = ManCapacitacion_AddEdit.dtEvaluacion_Encuestas;
            break;
        case "EVALINICIAL":
            dt = ManCapacitacion_AddEdit.dtEvaluacion_EvalInicial;
            break;
        case "EVALFINAL":
            dt = ManCapacitacion_AddEdit.dtEvaluacion_EvalFinal;
            break;
        case "EXAMEN":
            dt = ManCapacitacion_AddEdit.dtEvaluacion_Examenes;
            break;
    }

    rows = dt.$("tr");
    countFilas = rows.length;
    if (countFilas > 0) {
        $.each(rows, function (i, o) {
            data = dt.row($(o)).data();
            list.push(utilSigo.fnConvertArrayToObject(data));
        });
    }
    return list;
}

ManCapacitacion_AddEdit.fnDeleteEvaluacion = function (obj, _tipoEvaluacion) {
    var dt;

    switch (_tipoEvaluacion) {
        case "ENCUESTA":
            dt = ManCapacitacion_AddEdit.dtEvaluacion_Encuestas;
            break;
        case "EVALINICIAL":
            dt = ManCapacitacion_AddEdit.dtEvaluacion_EvalInicial;
            break;
        case "EVALFINAL":
            dt = ManCapacitacion_AddEdit.dtEvaluacion_EvalFinal;
            break;
        case "EXAMEN":
            dt = ManCapacitacion_AddEdit.dtEvaluacion_Examenes;
            break;
    }

    var data = dt.row($(obj).parents('tr')).data();
    if (_tipoEvaluacion == "ENCUESTA" || _tipoEvaluacion == "EVALINICIAL" || _tipoEvaluacion == "EVALFINAL") {
        ManCapacitacion_AddEdit.tbEliTABLA.push({
            EliTABLA: "CAPACITACION_ENCUESTA",
            EliVALOR01: data["COD_PREGUNTA"]
        });
    } else {
        ManCapacitacion_AddEdit.tbEliTABLA.push({
            EliTABLA: "CAPACITACION_EVALUACION",
            EliVALOR01: data["COD_PERSONA"]
        });
    }

    dt.row($(obj).parents('tr')).remove().draw();
    utilDt.enumColumn(dt);
}

ManCapacitacion_AddEdit.fnDeleteEvaluacionAll = function (_tipoEvaluacion) {
    var dt, rows, countFilas, data;

    switch (_tipoEvaluacion) {
        case "ENCUESTA":
            dt = ManCapacitacion_AddEdit.dtEvaluacion_Encuestas;
            break;
        case "EVALINICIAL":
            dt = ManCapacitacion_AddEdit.dtEvaluacion_EvalInicial;
            break;
        case "EVALFINAL":
            dt = ManCapacitacion_AddEdit.dtEvaluacion_EvalFinal;
            break;
        case "EXAMEN":
            dt = ManCapacitacion_AddEdit.dtEvaluacion_Examenes;
            break;
    }

    rows = dt.$("tr");
    countFilas = rows.length;
    if (countFilas > 0) {
        utilSigo.dialogConfirm("", "Está seguro de Eliminar Todo los Registros?", function (r) {
            if (r) {
                $.each(rows, function (i, o) {
                    data = dt.row($(o)).data();

                    if (_tipoEvaluacion == "ENCUESTA" || _tipoEvaluacion == "EVALINICIAL" || _tipoEvaluacion == "EVALFINAL") {
                        ManCapacitacion_AddEdit.tbEliTABLA.push({
                            EliTABLA: "CAPACITACION_ENCUESTA",
                            EliVALOR01: data["COD_PREGUNTA"]
                        });
                    } else {
                        ManCapacitacion_AddEdit.tbEliTABLA.push({
                            EliTABLA: "CAPACITACION_EVALUACION",
                            EliVALOR01: data["COD_PERSONA"]
                        });
                    }
                });
                dt.clear().draw();
            }
        });
    } else {
        utilSigo.toastWarning("Aviso", "No hay Registros a Eliminar");
    }
}
/*Fin Evaluación*/

/*Controles Nota Conceptual Programacion / cronograma */
ManCapacitacion_AddEdit.fnGetListProgramacion = function () {
    var dt, list = [], rows, countFilas, data;
    dt = ManCapacitacion_AddEdit.dtProgramacion;   

    rows = dt.$("tr");
    countFilas = rows.length;
    if (countFilas > 0) {
        $.each(rows, function (i, o) {
            data = dt.row($(o)).data();
            list.push(utilSigo.fnConvertArrayToObject(data));
        });
    }
    return list;
}

ManCapacitacion_AddEdit.fnDeleteProgramacion = function (obj) {
    var dt, data;
   
    dt = ManCapacitacion_AddEdit.dtProgramacion;
    data = dt.row($(obj).parents('tr')).data();
    if (data["RegEstado"] == "0" || data["RegEstado"] == "2") {
        ManCapacitacion_AddEdit.tbEliTABLA.push({
            EliTABLA: "CAPACITACION_PROGRAMA",
            EliVALOR02: data["COD_SECUENCIAL"],
            
        });
    }
    dt.row($(obj).parents('tr')).remove().draw(false);
    //utilDt.enumColumn(dt, "ROW_INDEX");
}

ManCapacitacion_AddEdit.fnDeleteProgramacionALL = function () {
    var dt, rows, countFilas, data;

    dt = ManCapacitacion_AddEdit.dtProgramacion;

    rows = dt.$("tr");
    countFilas = rows.length;
    if (countFilas > 0) {
        utilSigo.dialogConfirm("", "Está seguro de Eliminar Todos los Registros?", function (r) {
            if (r) {
                $.each(rows, function (i, o) {
                    data = dt.row($(o)).data();
                    if (data["RegEstado"] == "0" || data["RegEstado"] == "2") {
                        ManCapacitacion_AddEdit.tbEliTABLA.push({
                            EliTABLA: "CAPACITACION_PROGRAMA",
                            EliVALOR02: data["COD_SECUENCIAL"],
                            
                        });
                    }
                });
                dt.clear().draw();
            }
        });
    } else {
        utilSigo.toastWarning("Aviso", "No hay Registros a Eliminar");
    }
}

ManCapacitacion_AddEdit.fnGetListCronograma = function () {
    var dt, list = [], rows, countFilas, data;
    dt = ManCapacitacion_AddEdit.dtCronograma;

    rows = dt.$("tr");
    countFilas = rows.length;
    if (countFilas > 0) {
        $.each(rows, function (i, o) {
            data = dt.row($(o)).data();
            list.push(utilSigo.fnConvertArrayToObject(data));
        });
    }
    return list;
}
ManCapacitacion_AddEdit.fnDeleteCronograma = function (obj) {
    var dt, data;

    dt = ManCapacitacion_AddEdit.dtCronograma;
    data = dt.row($(obj).parents('tr')).data();

    if (data["RegEstado"] == "0" || data["RegEstado"] == "2") {
        ManCapacitacion_AddEdit.tbEliTABLA.push({
            EliTABLA: "CAPACITACION_CRONOGRAMA",
            EliVALOR02: data["COD_SECUENCIAL"]
        });
    }
    dt.row($(obj).parents('tr')).remove().draw(false);
    //utilDt.enumColumn(dt, "ROW_INDEX");
}

ManCapacitacion_AddEdit.fnDeleteCronogramaALL = function () {
    var dt, rows, countFilas, data;

    dt = ManCapacitacion_AddEdit.dtCronograma;

    rows = dt.$("tr");
    countFilas = rows.length;
    if (countFilas > 0) {
        utilSigo.dialogConfirm("", "Está seguro de Eliminar Todos los Registros?", function (r) {
            if (r) {
                $.each(rows, function (i, o) {
                    data = dt.row($(o)).data();
                    if (data["RegEstado"] == "0" || data["RegEstado"] == "2") {
                        ManCapacitacion_AddEdit.tbEliTABLA.push({
                            EliTABLA: "CAPACITACION_CRONOGRAMA",
                            EliVALOR02: data["COD_SECUENCIAL"]
                        });
                    }
                });
                dt.clear().draw();
            }
        });
    } else {
        utilSigo.toastWarning("Aviso", "No hay Registros a Eliminar");
    }
}

/*Fin Programacion*/

ManCapacitacion_AddEdit.fnImportarDatosCapacitacion = function (_tipoRegistro, e, obj) {
    var url = urlLocalSigo + "Capacitacion/ManCapacitacion/ImportarDatosCapacitacion";
    uploadFile.fileSelectHandler(e, obj, url, { hdfTipo: _tipoRegistro }, function (data) {
        var dt;

        switch (_tipoRegistro) {
            case "PARTICIPANTE_ASISTENTE":
                dt = ManCapacitacion_AddEdit.dtParticipante_Asistentes;
                break;
            case "PARTICIPANTE_PONENTE":
                dt = ManCapacitacion_AddEdit.dtParticipante_Ponentes;
                break;
            case "PARTICIPANTE_EQUIPO":
                dt = ManCapacitacion_AddEdit.dtParticipante_EquipoApoyo;
                break;
            case "EVALUACION_ENCUESTA":
                dt = ManCapacitacion_AddEdit.dtEvaluacion_Encuestas;
                break;
            case "EVALUACION_EVALINICIAL":
                dt = ManCapacitacion_AddEdit.dtEvaluacion_EvalInicial;
                break;
            case "EVALUACION_EVALFINAL":
                dt = ManCapacitacion_AddEdit.dtEvaluacion_EvalFinal;
                break;
            case "EVALUACION_EXAMEN":
                dt = ManCapacitacion_AddEdit.dtEvaluacion_Examenes;
                break;
            case "PROGRAMACION":
                dt = ManCapacitacion_AddEdit.dtProgramacion;
                break
            case "CRONOGRAMA":
                dt = ManCapacitacion_AddEdit.dtCronograma;
                break;
        }

        dt.rows.add(data).draw();
        dt.page('last').draw('page');
    });
}


/*Controles Datos Adjuntos*/
ManCapacitacion_AddEdit.fnSelectDocAdjunto = function (e, obj) {
    var idFile = $(obj).attr("id");
    var files = e.target.files || e.dataTransfer.files;

    if (files != undefined && files.length > 0) {
        //Validar extensión archivo seleccionado
        var extension = files[0].name.substr((files[0].name.lastIndexOf('.') + 1));
        var extensiones_no_permitidas = "exe,bin,bat,run";

        if (!extensiones_no_permitidas.includes(extension)) {
            //Validar el tamaño del archivo
            var fileSize = parseFloat(files[0].size);
            if ((fileSize / 1048576) > 8) //4MB permitido por foto
            {
                utilSigo.toastError("Error", "El tamaño del archivo supera los 4MB permitidos"); return false;
            } else {
                $("#" + idFile).next().text(files[0].name);
                ManCapacitacion_AddEdit.selectFile = files[0];
            }
        } else {
            utilSigo.toastError("Error", "La extensión ." + extension + " no esta permitida"); return false;
        }
    }
}

ManCapacitacion_AddEdit.fnSaveDocumentoAdjunto = function () {
    var cod_capacitacion = ManCapacitacion_AddEdit.frm.find("#hdfCodCapacitacion").val();
    if ((typeof cod_capacitacion==='undefined' || cod_capacitacion=="")) {
        utilSigo.toastWarning("Aviso", "Primero debe registrar la capacitación para luego poder agregar documento"); return false;
    }
    if (ManCapacitacion_AddEdit.selectFile==null) {
        utilSigo.toastWarning("Aviso", "Seleccione el documento a adjuntar"); return false;
    }

    // Checking whether FormData is available in browser  
    if (window.FormData !== undefined) {
        var fileData = new FormData();
        var url = urlLocalSigo + "Capacitacion/ManCapacitacion/GrabarDocumentoAdjunto";
        var data = {};
        data.COD_CAPACITACION = ManCapacitacion_AddEdit.frm.find("#hdfCodCapacitacion").val();
        data.MAE_COD_TIPOADJUNTO = ManCapacitacion_AddEdit.frm.find("#ddlTipoAdjuntoId").val();
        data.OBSERVACION = ManCapacitacion_AddEdit.frm.find("#txtObservacionTAdjunto").val();

        fileData.append("data", JSON.stringify(data));
        fileData.append(ManCapacitacion_AddEdit.selectFile.name, ManCapacitacion_AddEdit.selectFile);

        $.ajax({
            url: url,
            type: "POST",
            contentType: false, // Not to set any content header  
            processData: false, // Not to process data  
            data: fileData,
            success: function (result) {
                if (result.success) {
                    result.data.TIPO_ADJUNTO = ManCapacitacion_AddEdit.frm.find("#ddlTipoAdjuntoId").select2("data")[0].text;
                    ManCapacitacion_AddEdit.dtDocumentoAdjunto.rows.add([result.data]).draw();
                    ManCapacitacion_AddEdit.dtDocumentoAdjunto.page('last').draw('page');

                    ManCapacitacion_AddEdit.frm.find("#txtArchivoAdjunto").next().text("Seleccionar Archivo");
                    ManCapacitacion_AddEdit.frm.find("#txtArchivoAdjunto").val("");
                    ManCapacitacion_AddEdit.frm.find("#txtObservacionTAdjunto").val("");
                    ManCapacitacion_AddEdit.selectFile = null;
                    utilSigo.toastSuccess("Éxito", result.msj);
                }
                else {
                    utilSigo.toastWarning("Aviso", result.msj);
                }
            },
            error: function (err) {
                utilSigo.toastWarning("Aviso", "Sucedio un error, Comuníquese con el Administrador");
                console.log(err.statusText);
            }
        });
    } else {
        utilSigo.toastWarning("Aviso", "Sucedio un error, Comuníquese con el Administrador");
        console.log("FormData is not available in your browser");
    }
}

ManCapacitacion_AddEdit.fnDeleteDocumentoAdjunto = function (obj) {
    var dt = ManCapacitacion_AddEdit.dtDocumentoAdjunto;
    var data = dt.row($(obj).parents('tr')).data();

    utilSigo.dialogConfirm("", "Está seguro de eliminar el documento adjunto?", function (r) {
        if (r) {
            if (data["COD_SECUENCIAL"] != "") {
                var url = urlLocalSigo + "Capacitacion/ManCapacitacion/EliminarDocumentoAdjunto";
                var params = {};
                params.COD_CAPACITACION = ManCapacitacion_AddEdit.frm.find("#hdfCodCapacitacion").val();
                params.COD_SECUENCIAL = data["COD_SECUENCIAL"];
                params.NOMBRE_ARCHIVO = data["NOMBRE_ARCHIVO"];
                params.EXTENSION = data["EXTENSION"];
                var option = { url: url, datos: JSON.stringify(params), type: 'POST' };

                utilSigo.fnAjax(option, function (data) {
                    if (data.success) {
                        dt.row($(obj).parents('tr')).remove().draw();
                        utilDt.enumColumn(dt);
                        utilSigo.toastSuccess("Éxito", data.msj);
                    } else {
                        utilSigo.toastWarning("Aviso", "Sucedio un error, Comuníquese con el Administrador");
                        console.log(data.msj);
                    }
                });
            } else {
                dt.row($(obj).parents('tr')).remove().draw();
                utilDt.enumColumn(dt);
            }
        }
    });
}

ManCapacitacion_AddEdit.fnDownloadDocumentoAdjunto = function (obj) {
    var dt = ManCapacitacion_AddEdit.dtDocumentoAdjunto;
    var data = dt.row($(obj).parents('tr')).data();

    if (data["COD_SECUENCIAL"] != "") {
        window.open(urlLocalSigo + "Archivos/Archivo_Capacitacion/" + ManCapacitacion_AddEdit.frm.find("#hdfCodCapacitacion").val() + data["COD_SECUENCIAL"] + data["EXTENSION"],'_blank');
    } else {
        window.open(urlLocalSigo + "Archivos/Archivo_Capacitacion/Temp/" + data["URL"], "_blank");
    }
}
/*Fin datos adjuntos*/



/* FIN REGISTRO DE PROGRAMACION */

$(document).ready(function () {
    ManCapacitacion_AddEdit.contenedor = "frmCapacitacion";
    ManCapacitacion_AddEdit.frm = $("#" + ManCapacitacion_AddEdit.contenedor);

    ManCapacitacion_AddEdit.fnInit();

    ManCapacitacion_AddEdit.fnInitDataTable_Detail();

    ManCapacitacion_AddEdit.frm.find("#ddlOdId").change(function () {
        ManCapacitacion_AddEdit.fnLoadComboCapacitacionEjecutar($(this).val());
    });

    ManCapacitacion_AddEdit.frm.find("#ddlCapacitacionEjecutarId").change(function () {
        ManCapacitacion_AddEdit.fnLoadDataCapacitacionProgramada($(this).val());
    });

    ManCapacitacion_AddEdit.fnShowDetOrganizador();
    ManCapacitacion_AddEdit.frm.find("#ddlOrganizadorId").change(function () {
        ManCapacitacion_AddEdit.fnShowDetOrganizador();
    });

    ManCapacitacion_AddEdit.fnShowTabConvenios();
    ManCapacitacion_AddEdit.frm.find("#chkMarConvenio").click(function () {
        ManCapacitacion_AddEdit.fnShowTabConvenios();
    });

    ManCapacitacion_AddEdit.fnLoadListConvenios();
    ManCapacitacion_AddEdit.frm.find('#ddlConvenioOsinforId').dblclick(function () {
        ManCapacitacion_AddEdit.frm.find("#ddlConvenioCapacitacionId").find("option[value='" + $(this).val() + "']").show();
        ManCapacitacion_AddEdit.frm.find("#ddlConvenioOsinforId").find("option[value='" + $(this).val() + "']").hide();

        ManCapacitacion_AddEdit.fnShowGrupoConvenio();
    });

    ManCapacitacion_AddEdit.frm.find('#ddlConvenioCapacitacionId').dblclick(function () {
        ManCapacitacion_AddEdit.frm.find("#ddlConvenioOsinforId").find("option[value='" + $(this).val() + "']").show();
        ManCapacitacion_AddEdit.frm.find("#ddlConvenioCapacitacionId").find("option[value='" + $(this).val() + "']").hide();
        //Cambiar estado BD del registro quitado
        ManCapacitacion_AddEdit.tbEliTABLA.push({
            EliTABLA: "CAPACITACION_MARCO_CONVENIO",
            EliVALOR01: $(this).val()[0]
        });

        ManCapacitacion_AddEdit.fnShowGrupoConvenio();
    });

    ManCapacitacion_AddEdit.fnShowDescTema();
    ManCapacitacion_AddEdit.frm.find("[id*=lstChkTema]").change(function () {
        //Cambiar estado BD del registro quitado
        if (!$(this).is(":checked")) {
            ManCapacitacion_AddEdit.tbEliTABLA.push({
                EliTABLA: "CAPACITACION_TEMATICA",
                EliVALOR01: $(this).prev().val()
            });
        }

        ManCapacitacion_AddEdit.fnShowDescTema();
    });

    ManCapacitacion_AddEdit.fnShowEvaluacion();
    ManCapacitacion_AddEdit.frm.find("#ddlTipPCapacitacionId").change(function () {
        ManCapacitacion_AddEdit.fnShowEvaluacion();
    });

    ManCapacitacion_AddEdit.fnLoadListPublicoObjetivo();
    ManCapacitacion_AddEdit.frm.find('#ddlPObjetivoOsinforId').dblclick(function () {
        ManCapacitacion_AddEdit.frm.find("#ddlPObjetivoCapacitacionId").find("option[value='" + $(this).val() + "']").show();
        ManCapacitacion_AddEdit.frm.find("#ddlPObjetivoOsinforId").find("option[value='" + $(this).val() + "']").hide();

        ManCapacitacion_AddEdit.fnShowGrupoPublicoObjetivo();

        if ($(this).val() == "0000032") {
            ManCapacitacion_AddEdit.frm.find("#dvDescPObjRepresentante").show();
        }
        if ($(this).val() == "0000039") {
            ManCapacitacion_AddEdit.frm.find("#dvDescPObjOtroActor").show();
        }
    });

    ManCapacitacion_AddEdit.frm.find('#ddlPObjetivoCapacitacionId').dblclick(function () {
        ManCapacitacion_AddEdit.frm.find("#ddlPObjetivoOsinforId").find("option[value='" + $(this).val() + "']").show();
        ManCapacitacion_AddEdit.frm.find("#ddlPObjetivoCapacitacionId").find("option[value='" + $(this).val() + "']").hide();
        //Cambiar estado BD del registro quitado
        ManCapacitacion_AddEdit.tbEliTABLA.push({
            EliTABLA: "CAPACITACION_PUBLICO_OBJETIVO",
            EliVALOR01: $(this).val()[0]
        });

        ManCapacitacion_AddEdit.fnShowGrupoPublicoObjetivo();

        if ($(this).val() == "0000032") {
            ManCapacitacion_AddEdit.frm.find("#dvDescPObjRepresentante").hide();
        }
        if ($(this).val() == "0000039") {
            ManCapacitacion_AddEdit.frm.find("#dvDescPObjOtroActor").hide();
        }
    });

    $('[data-toggle="tooltip"]').tooltip();

    //=====-----Para el registro de datos del formulario-----=====
    //Validación personalizada
    jQuery.validator.addMethod("invalidFrmCapacitacion", function (value, element) {
        switch ($(element).attr('id')) {
            case 'ddlIndicadorId':
            case 'ddlOdId':
            case 'ddlCapacitacionEjecutarId':
            case 'ddlTipCapacitacionId':
            case 'ddlSumMetPoiId':
            case 'ddlMetodologiaId':
            case 'ddlOrganizadorId':
                return value == '0000000' ? false : true;
        }
    });

    ManCapacitacion_AddEdit.frm.validate(utilSigo.fnValidate({
        rules: {
            ddlIndicadorId: { invalidFrmCapacitacion: true },
            ddlOdId: { invalidFrmCapacitacion: true },
            ddlCapacitacionEjecutarId: { invalidFrmCapacitacion: true },
            txtNomCapacitacion: { required: true },
            ddlTipCapacitacionId: { invalidFrmCapacitacion: true },
            ddlSumMetPoiId: { invalidFrmCapacitacion: true },
            txtObjetivo: { required: true },
            ddlMetodologiaId: { invalidFrmCapacitacion: true },
            txtFecInicio: { required: true },
            txtFecTermino: { required: true },
            txtDuracion: { required: true },
            txtTotalParticipante: { required: true },
            ddlOrganizadorId: { invalidFrmCapacitacion: true },
            txtLugar: { required: true }
        },
        messages: {
            ddlIndicadorId: { invalidFrmCapacitacion: "Seleccione el estado actual del registro" },
            ddlOdId: { invalidFrmCapacitacion: "Seleccione la oficina desconcentrada" },
            ddlCapacitacionEjecutarId: { invalidFrmCapacitacion: "Seleccione la capacitación ejecutada" },
            txtNomCapacitacion: { required: "Ingrese el nombre de la capacitación" },
            ddlTipCapacitacionId: { invalidFrmCapacitacion: "Seleccione el tipo de capacitación" },
            ddlSumMetPoiId: { invalidFrmCapacitacion: "Seleccione una opción" },
            txtObjetivo: { required: "Ingrese el objetivo de la capacitación" },
            ddlMetodologiaId: { invalidFrmCapacitacion: "Seleccione la metodología de la capacitación" },
            txtFecInicio: { required: "Seleccione la fecha de inicio de la capacitación" },
            txtFecTermino: { required: "Seleccione la fecha de término de la capacitación" },
            txtDuracion: { required: "Ingrese la duración en horas de la capacitación" },
            txtTotalParticipante: { required: "Ingrese número de participantes de la capacitación" },
            ddlOrganizadorId: { invalidFrmCapacitacion: "Seleccione el organizador de la capacitación" },
            txtLugar: { required: "Ingrese el lugar donde se llevó a cabo la capacitación" }
        },
        fnSubmit: function (form) {
            if (ManCapacitacion_AddEdit.fnCustomValidateForm()) {
                utilSigo.dialogConfirm('', 'Desea continuar con el registro?', function (r) {
                    if (r) {
                        ManCapacitacion_AddEdit.fnSaveForm();
                    }
                });
            }
        }
    }));
    //Validación de controles que usan Select2
    ManCapacitacion_AddEdit.frm.find("select.select2-hidden-accessible").on("change", function (e) {
        $(this).valid();
    });
});