"use strict";
var ManInforme_AddEdit = {};
/*Variables globales*/
ManInforme_AddEdit.tbEliTABLA = [];

ManInforme_AddEdit.fnReturnIndex = function (alertaInicial) {
    var url = urlLocalSigo + "Supervision/ManInformeQuinquenal/Index";
    if (alertaInicial!="") localStorage.setItem("mensajeRegQuinquenal", alertaInicial);
    window.location = url;
     
}



ManInforme_AddEdit.fnBuscarPersona = function (_dom) {
    var url = urlLocalSigo + "General/Controles/_BuscarPersonaGeneral";
    var option = { url: url, type: 'GET', datos: { asBusGrupo: "PERSONA", asCodPTipo: "TODOS", asTipoPersona: "N" }, divId: "mdlBuscarPersona" };
    utilSigo.fnOpenModal(option, function () {
        _bPerGen.fnAsignarDatos = function (obj) {
            if (obj != null && obj != "") {
                var data = _bPerGen.dtBuscarPerona.row($(obj).parents('tr')).data();
                switch (_dom) {
                    case "DIRECTOR":
                        ManInforme_AddEdit.frm.find("#hdfCodDirector").val(data["COD_PERSONA"]);
                        ManInforme_AddEdit.frm.find("#lblDirector").val(data["PERSONA"]);
                        break;
                }
                utilSigo.fnCloseModal("mdlBuscarPersona");
            }
        }
        _bPerGen.fnInit();
    }, function () {
        if (!utilSigo.fnValidateForm_HideControl(ManInforme_AddEdit.frm, ManInforme_AddEdit.frm.find("#hdfCodDirector"), ManInforme_AddEdit.frm.find("#iconDirector"), false)) return false;
        return true;
    });
}
ManInforme_AddEdit.fnOpenQuinquenio = function (quinquenio) {
    var url = urlLocalSigo + "Supervision/ManInformeQuinquenal/_renderQuinquenio";
    var option = { url: url, type: 'GET', datos: { asCodInforme: $("#hdfManCodTInforme").val(), quinquenio: quinquenio}, divId: "mdlQuinquenio" };
    utilSigo.fnOpenModal(option, function () {
         
    });
}
ManInforme_AddEdit.fnSaveForm = function () {
    /*
    var datosInforme = ManInforme_AddEdit.frm.serializeObject();
    datosInforme.vmInfCNotificacion = {};
    datosInforme.vmControlCalidad = _ControlCalidad.fnGetDatosControlCalidad();
    datosInforme.chkPublicar = utilSigo.fnGetValChk(ManInforme_AddEdit.frm.find("#chkPublicar"));
    datosInforme.vmInfCNotificacion = _renderCNotificacion.fnGetDatosCNotificacion();
    datosInforme.chkPlanAmazonas = utilSigo.fnGetValChk(ManInforme_AddEdit.frm.find("#chkPlanAmazonas"));
    datosInforme.chkPlanAmazonas2014 = utilSigo.fnGetValChk(ManInforme_AddEdit.frm.find("#chkPlanAmazonas2014"));
    datosInforme.chkPlanAmazonas2015 = utilSigo.fnGetValChk(ManInforme_AddEdit.frm.find("#chkPlanAmazonas2015"));
    datosInforme.chkPlanAmazonas2016 = utilSigo.fnGetValChk(ManInforme_AddEdit.frm.find("#chkPlanAmazonas2016"));
    datosInforme.txtConclusion = CKEDITOR.instances["txtConclusion"].getData();
    datosInforme.vmDatoSupervision = _renderDatosSupervision.fnGetDatosSupervision();

    datosInforme.tbEliTABLA = ManInforme_AddEdit.tbEliTABLA;
    datosInforme.tbEliTABLA = datosInforme.tbEliTABLA.concat(_renderCNotificacion.fnGetListEliTABLA());
    datosInforme.tbSupervisor = _renderSupervisor.fnGetList();
    datosInforme.tbEliTABLA = datosInforme.tbEliTABLA.concat(_renderSupervisor.fnGetListEliTABLA());
    datosInforme.tbVerticeTHCampo = _renderVerticeTHCampo.fnGetList();
    datosInforme.tbEliTABLA = datosInforme.tbEliTABLA.concat(_renderVerticeTHCampo.fnGetListEliTABLA());
    datosInforme.tbAvistamientoFauna = _renderAvistamientoFauna.fnGetList();
    datosInforme.tbEliTABLA = datosInforme.tbEliTABLA.concat(_renderAvistamientoFauna.fnGetListEliTABLA());
    datosInforme.tbObligTitular = _renderObligacionTitular.fnGetList();
    datosInforme.tbObligacion = _renderObligContractual.fnGetList();
    datosInforme.tbEliTABLA = datosInforme.tbEliTABLA.concat(_renderObligContractual.fnGetListEliTABLA());
    datosInforme.tbDesplazamiento = _renderDesplazamiento.fnGetList();
    datosInforme.tbEliTABLA = datosInforme.tbEliTABLA.concat(_renderDesplazamiento.fnGetListEliTABLA());

    var option = { url: ManInforme_AddEdit.frm.action, datos: JSON.stringify(datosInforme), type: 'POST' };
    utilSigo.fnAjax(option, function (data) {
        if (data.success) {
            ManInforme_AddEdit.fnReturnIndex(data.msj);
        }
        else {
            utilSigo.toastWarning("Aviso", data.msj);
        }
    });*/
    let frm = ManInforme_AddEdit.frm;
    let COD_ITIPO = "";
    let COD_DIRECTOR = "";
    let FECHA_EMISION = "";
    let NUM_INFORME = "";
    let ASUNTO = $("#txtAsunto").val();//cuando es qunquenal
   
    let hdfManCodTInforme = "";
    let hdfRegEstado = "0";
    let calidad = _ControlCalidad.fnGetDatosControlCalidad();
    let COD_ESTADO_DOC = calidad.ddlIndicadorId;
    let OBSERVACIONES_CONTROL = (typeof calidad.txtControlCalidadObservaciones) === 'undefined' ? '' : calidad.txtControlCalidadObservaciones.trim();
    let OBSERV_SUBSANAR = calidad.chkObsSubsanada;

    //Hallazgos
    let DOCUMENTACION = frm.find("#txtDocumentacionRevisada").val().trim();
    let OBSERVACION = frm.find("#txtRecomendaciones").val().trim();

    hdfManCodTInforme = frm.find("#hdfManCodTInforme").val();
    hdfRegEstado = frm.find("#hdfRegEstado").val();
    COD_ITIPO = frm.find("#ddlTipoInformeId").val();
    COD_DIRECTOR = frm.find("#hdfCodDirector").val();
    FECHA_EMISION = frm.find("#txtFechaEmision").val();
    NUM_INFORME = frm.find("#txtNumInform").val().trim();
    let FECHA_INICIO_AUDITORIA = frm.find("#txtFechaInicioAuditoria").val();
    let FECHA_FIN_AUDITORIA = frm.find("#txtFechaFinAuditoria").val();
    let tbListRDQuinquenal = _renderRDQuinquenal.fnGetList();
    let tbListProfesionales = _renderSupervisor.fnGetList();

    if (COD_ESTADO_DOC == "0000000") {
        utilSigo.toastWarning("Aviso", "Seleccione estado situacional");
        return false;
    }
    

    if (COD_ITIPO == "0000000") {
        utilSigo.toastWarning("Aviso", "Seleccione el tipo de informe");
        return false;
    }
    if (COD_DIRECTOR == "") {
        utilSigo.toastWarning("Aviso", "Seleccione director");
        return false;
    }
    if (FECHA_EMISION == "" || FECHA_EMISION == null) {
        utilSigo.toastWarning("Aviso", "Ingrese la fecha de emisión");
        return false;
    }
    if (NUM_INFORME == "") {
        utilSigo.toastWarning("Aviso", "Ingrese el número de informe");
        return false;
    }
    if (COD_ITIPO == "0000010") {
        if (FECHA_INICIO_AUDITORIA != null && FECHA_INICIO_AUDITORIA != "") {
            if (FECHA_FIN_AUDITORIA == null || FECHA_FIN_AUDITORIA == "") {
                utilSigo.toastWarning("Aviso", "Ingrese Fecha de Fin de Auditoría");
                return false;
            }
            else {
                var fecha1 = FECHA_INICIO_AUDITORIA.split("/");
                var fechaInicio = new Date(fecha1[2], fecha1[1], fecha1[0]);

                var fecha2 = FECHA_FIN_AUDITORIA.split("/");
                var fechaFin = new Date(fecha2[2], fecha2[1], fecha2[0]);

                if (fechaFin < fechaInicio) {
                    utilSigo.toastWarning("Aviso", "Fecha de Fin de Auditoría tiene que ser mayor que la Fecha de Inicio de Auditoría.");
                    return false;
                }
            }
        }
        else {
            if (FECHA_FIN_AUDITORIA != null && FECHA_FIN_AUDITORIA != "") {
                utilSigo.toastWarning("Aviso", "Ingrese Fecha de Inicio de Auditoría");
                return false;
            }
        }
    }
    if (_renderRDQuinquenal.fnCount() <= 0) {
        utilSigo.toastWarning("Aviso", "Seleccione carta de notificación");
        return false;
    }
    
    if (_renderSupervisor.fnCount() <= 0) {
        utilSigo.toastWarning("Aviso", "Seleccione Profesional(es)");
        return false;
    }
    let model = {
        COD_INFORME: hdfManCodTInforme,
        COD_ESTADO_DOC: COD_ESTADO_DOC,
        OBSERVACIONES_CONTROL: OBSERVACIONES_CONTROL,
        OBSERV_SUBSANAR: OBSERV_SUBSANAR,
        RegEstado:  hdfRegEstado,
        COD_ITIPO: COD_ITIPO,
        COD_DIRECTOR: COD_DIRECTOR,
        FECHA_EMISION: FECHA_EMISION,
        NUM_INFORME: NUM_INFORME,
        ASUNTO: ASUNTO,
        DOCUMENTACION: DOCUMENTACION,
        OBSERVACION: OBSERVACION,
        FECHA_INICIO_AUDITORIA: FECHA_INICIO_AUDITORIA,
        FECHA_FIN_AUDITORIA: FECHA_FIN_AUDITORIA
    };
    model.vmControlCalidad = _ControlCalidad.fnGetDatosControlCalidad();
    model.ListRDQuinquenal = tbListRDQuinquenal;
    model.ListProfesionales = tbListProfesionales;
    model.ListEliTABLA = ManInforme_AddEdit.tbEliTABLA;// _renderSupervisor.tbEliTABLA;

    //hallazgos
    model.ListHallazgos = _renderHallazgo.fnGetList();
   /* let tbEliTablaHallazgo = _renderHallazgo.fnGetListEliTABLA();
    if (tbEliTablaHallazgo.length > 0) {
        model.ListEliTABLA.push(tbEliTablaHallazgo);
    }*/

   // console.log(tbEliTablaHallazgo);
    //console.log(model.ListEliTABLA);

     
   
    var option = { url: ManInforme_AddEdit.frm.action, datos: JSON.stringify(model), type: 'POST' };
    utilSigo.fnAjax(option, function (data) {
        if (data.success) {
            if (hdfManCodTInforme == "") {                
                window.location = `${urlLocalSigo}/Supervision/ManInformeQuinquenal/AddEdit?asCodInforme=${data.codInforme}`;
                sessionStorage.setItem('mensajeRegQuinquenal', 'Datos registrados correctamente');
            } else {
                ManInforme_AddEdit.fnReturnIndex(data.msj);
            }           
        }
        else {
            utilSigo.toastWarning("Aviso", data.msj);
        }
    });
}

$(document).ready(function () {
    if (sessionStorage.getItem('mensajeRegQuinquenal') != null) {
        if (sessionStorage.getItem('mensajeRegQuinquenal') != "") utilSigo.toastSuccess("Éxito", "Datos registrados correctamente");
        sessionStorage.removeItem("mensajeRegQuinquenal");
    }

   // ManInforme_AddEdit.fnOpenQuinquenio();
    if ($("#hdfManCodTInforme").val().trim() != "") {
        $("#ddlTipoInformeId").attr("disabled",true);
    }
    ManInforme_AddEdit.frm = $("#frmManInforme_AddEdit");
    ManInforme_AddEdit.frm.find("#txtFechaEmision").datepicker(initSigo.formatDatePicker);
    ManInforme_AddEdit.frm.find("#txtFechaInicioAuditoria").datepicker(initSigo.formatDatePicker);
    ManInforme_AddEdit.frm.find("#txtFechaFinAuditoria").datepicker(initSigo.formatDatePicker);
   
    $('[data-toggle="tooltip"]').tooltip();
    /*
    ManInforme_AddEdit.frm.validate(utilSigo.fnValidate({
        rules: {
       
            txtNumInforme: { required: true },
            txtFechaInicio: { required: true },
            txtFechaFin: { required: true },
            txtSector: { required: true }
        },
        messages: {
            ddlIndicadorId: { invalidManInf_AddEdit: "Seleccione el estado actual del registro" },
            ddlOdId: { invalidManInf_AddEdit: "Seleccione la oficina desconcentrada" },
            txtNumInforme: { required: "Ingrese el número del informe de supervisión" },
            txtFechaInicio: { required: "Seleccione la fecha de inicio de la supervisión" },
            txtFechaFin: { required: "Seleccione la fecha fin de la supervisión" },
            txtSector: { required: "Ingrese el sector del área supervisada" }
        },
        fnSubmit: function (form) {
            if (ManInforme_AddEdit.fnCustomValidateForm()) {
                utilSigo.dialogConfirm('', 'Desea continuar con el registro?', function (r) {
                    if (r) {
                        ManInforme_AddEdit.fnSaveForm();
                    }
                });
            }
        }
    }));*/
    //Validación de controles que usan Select2
    ManInforme_AddEdit.frm.find("select.select2-hidden-accessible").on("change", function (e) {
        $(this).valid();
    });  
    ManInforme_AddEdit.frm.find("#ddlTipoInformeId").on("change", function (e) {
        if ($(this).val() == "0000014") {
            $("#divHallazgos").removeAttr("style");
            $("#divOtros").attr("style", "display:none");
            $("#dvFechaAuditoria").attr("style", "display:none");
        }
        else if ($(this).val() == "0000010") {
            $("#divHallazgos").attr("style", "display:none");
            $("#divOtros").removeAttr("style");
            $("#dvFechaAuditoria").removeAttr("style");
        }
        else if ($(this).val() == "0000000") {
            $("#divHallazgos").attr("style", "display:none");
            $("#divOtros").attr("style", "display:none");
            $("#dvFechaAuditoria").attr("style", "display:none");
        }
    });  
    if (ManInforme_AddEdit.frm.find("#ddlTipoInformeId").val() == "0000014") {
        $("#divHallazgos").removeAttr("style");
    }
    if (ManInforme_AddEdit.frm.find("#ddlTipoInformeId").val() == "0000010") {
        $("#divOtros").removeAttr("style");
        $("#dvFechaAuditoria").removeAttr("style");
    }
   // $("#ddlIndicadorId").prop("disabled", "disabled");
    
});