
var ManInfFundamentado_AddEdit = {};

ManInfFundamentado_AddEdit.DataProfesional = [];
ManInfFundamentado_AddEdit.DataEntidad = [];
ManInfFundamentado_AddEdit.tbEliTABLA = [];

ManInfFundamentado_AddEdit.fnLoadData = function (obj, tipo) {
    switch (tipo) {
        case "DataProfesional": ManInfFundamentado_AddEdit.DataProfesional = obj; break;
        case "DataEntidad": ManInfFundamentado_AddEdit.DataEntidad = obj; break;
    }
}

//para iniciar los eventos
ManInfFundamentado_AddEdit.iniciarEventos = function () {
    ManInfFundamentado_AddEdit.frm.find("#txtFechaFundamentado").datepicker({ format: "dd/mm/yyyy", autoclose: true, language: 'es' });
    // Campos Nuevos
    ManInfFundamentado_AddEdit.frm.find("#dtpFechaIngresoSolicitud").datepicker({ format: "dd/mm/yyyy", autoclose: true, language: 'es' });
    ManInfFundamentado_AddEdit.frm.find("#dtpfechaFirmezaPAU").datepicker({ format: "dd/mm/yyyy", autoclose: true, language: 'es' });
    ManInfFundamentado_AddEdit.frm.find("#dtpFechaEmision1").datepicker({ format: "dd/mm/yyyy", autoclose: true, language: 'es' });
    ManInfFundamentado_AddEdit.frm.find("#dtpFechaEmision2").datepicker({ format: "dd/mm/yyyy", autoclose: true, language: 'es' });
    ManInfFundamentado_AddEdit.frm.find("#dtpfechaOficio1").datepicker({ format: "dd/mm/yyyy", autoclose: true, language: 'es' });
    ManInfFundamentado_AddEdit.frm.find("#dtpfechaOficio2").datepicker({ format: "dd/mm/yyyy", autoclose: true, language: 'es' });
    ManInfFundamentado_AddEdit.frm.find("#dtpFechaEmisionPau").datepicker({ format: "dd/mm/yyyy", autoclose: true, language: 'es' });
    ManInfFundamentado_AddEdit.frm.find("#dtpFechaNotificacion").datepicker({ format: "dd/mm/yyyy", autoclose: true, language: 'es' });
    ManInfFundamentado_AddEdit.frm.find("#dtpFechaFundamentado").datepicker({ format: "dd/mm/yyyy", autoclose: true, language: 'es' });

    ManInfFundamentado_AddEdit.tbEliTABLA = {};
}

//vuelve a la vista principal del listado
ManInfFundamentado_AddEdit.regresar = function (appServer) {
    var url = "";
    url = urlLocalSigo + "Fiscalizacion/InformeFundamentado/Index";
    window.location = url;

};

ManInfFundamentado_AddEdit.fnBuscarPersona = function (_dom, _tipoPersona) {
    debugger;
    switch (_dom) {
        case "TITULAR":
        case "TITULAR_ADENDA":
            valCodPTipo = "0000001"; break;
        case "RLEGAL":
            valCodPTipo = "0000002"; break;
        case "FUNC_APRUEBA_PROYECTO":
        case "FUNC_AUTORIZA_FUNCIONAMIENTO":
            valCodPTipo = "0000006"; break;
        default:
            valCodPTipo = "TODOS";
    }

    var url = urlLocalSigo + "General/Controles/_BuscarPersonaGeneral";
    var option = {
        url: url, type: 'GET',
        datos: { asBusGrupo: "INFORME_FUNDAMENTADO", asCodPTipo: valCodPTipo, asTipoPersona: _tipoPersona }, divId: "mdlBuscarPersona"
    };
    utilSigo.fnOpenModal(option, function () {
        _bPerGen.fnAsignarDatos = function (obj) {

            if (obj != null && obj != "") {
                var data = _bPerGen.dtBuscarPerona.row($(obj).parents('tr')).data();
                switch (_dom) {
                    case "PROFESIONAL":
                        var url = urlLocalSigo + "Fiscalizacion/InformeFundamentado/agregarProfesionales";
                        var params = {};
                        params.COD_PERSONA = data["COD_PERSONA"];
                        params.NUMERO = data["N_DOCUMENTO"];
                        params.APELLIDOS_NOMBRES = data["PERSONA"];
                        params.TIPO = data["PTIPO"];
                        var option = { url: url, datos: JSON.stringify(params), type: 'POST' };

                        utilSigo.fnAjax(option, function (ob) {
                            if (ob.success) {
                                if (ob.value) {
                                    ManInfFundamentado_AddEdit.DataProfesional = ob.result;
                                    ManInfFundamentado_AddEdit.dtRenderListProfesional.clear().draw();
                                    ManInfFundamentado_AddEdit.dtRenderListProfesional.rows.add(ManInfFundamentado_AddEdit.DataProfesional).draw();
                                }
                                else {
                                    utilSigo.toastWarning("Aviso", "El Profesional ya existe");
                                }
                            }
                            else {
                                utilSigo.toastWarning("Aviso", "Sucedio un error, Comuníquese con el Administrador");
                                console.log(ob.result);
                            }
                        });
                        break;
                    case "TITULAR":
                        ManInfFundamentado_AddEdit.frm.find("#hdtxtTitularTipo").val(data["COD_PERSONA"]);
                        ManInfFundamentado_AddEdit.frm.find("#txtTitularTipo").val(data["PERSONA"]);
                        //ManInfFundamentado_AddEdit.frm.find("#hdtipotxtTitularTipo").val(_tipoPersona);
                        break;

                }
                utilSigo.fnCloseModal("mdlBuscarPersona");
            }
        };
        _bPerGen.fnInit();
    });
};

ManInfFundamentado_AddEdit.cargarUbigeoModal = function (control) {
    var _hrModal = $.ajax({
        url: urlLocalSigo + "Fiscalizacion/Controles/_Ubigeo",
        type: 'POST',
        data: { formOrigen: "frmInformeFundamentado", controlOrigen: control },
        dataType: 'html',
        success: function (data) {
            utilSigo.unblockUIGeneral();
            if (_hrModal.status != 203) {
                $("#personaUbigeoModal").html(data);
                utilSigo.modalDraggable($("#personaUbigeoModal"), '.modal-header');
                $("#personaUbigeoModal").modal({ keyboard: true, backdrop: 'static' });
            }
        },
        beforeSend: function () {
            utilSigo.blockUIGeneral();
        },
        error: function (jqXHR, error, errorThrown) {
            utilSigo.unblockUIGeneral();
            utilSigo.toastError("Error", "Sucedio un Error Inesperado, Comuniquese con el Administrador");
            // console.log(jqXHR.responseText);
        },
        statusCode: {
            203: () => { utilSigo.unblockUIGeneral(); utilSigo.toastInfo("Aviso", "El usuario perdio la sesión. Vuelva ingresar al sistema"); }
        }
    });
};


ManInfFundamentado_AddEdit.fnSubmitForm = function () {
    var controls = ["ddlIndicadorId", "txtNumInfFundamentado", "txtFechaFundamentado"];
    /*if (!utilSigo.fnValidateForm(ManInfFundamentado_AddEdit.frm, controls)) {
        alert('error');
        return ManInfFundamentado_AddEdit.frm.valid();
    }*/
    ManInfFundamentado_AddEdit.frm.submit();
}

ManInfFundamentado_AddEdit.fnSaveForm = function () {
    let hdfCodInfFundamentado = ManInfFundamentado_AddEdit.frm.find("#hdfCodInfFundamentado").val();
    let hdfCodTipoInfFundamentado = ManInfFundamentado_AddEdit.frm.find("#hdfCodTipoInfFundamentado").val();
    let RegEstado = ManInfFundamentado_AddEdit.frm.find("#RegEstado").val();
    let ddlOdId = ManInfFundamentado_AddEdit.frm.find("#ddlOdId").val();
    let txtNumInfFundamentado = ManInfFundamentado_AddEdit.frm.find("#txtNumInfFundamentado").val();
    let txtFechaFundamentado = ManInfFundamentado_AddEdit.frm.find("#txtFechaFundamentado").val();
    let txtConclusiones = ManInfFundamentado_AddEdit.frm.find("#txtConclusiones").val();
    let txtObservaciones = ManInfFundamentado_AddEdit.frm.find("#txtObservaciones").val();
    let hdfCodigoInfFundamentadoAlerta = ManInfFundamentado_AddEdit.frm.find("#hdfCodigoInfFundamentadoAlerta").val();

    let model = {
        hdfCodInfFundamentado, hdfCodTipoInfFundamentado, RegEstado, ddlOdId, txtNumInfFundamentado,
        txtFechaFundamentado, txtConclusiones, txtObservaciones, hdfCodigoInfFundamentadoAlerta
    }
    model.vmControlCalidad = _ControlCalidad.fnGetDatosControlCalidad();
    model.listaProfesionales = ManInfFundamentado_AddEdit.DataProfesional;
    model.tbInforme = _renderListExpediente.fnGetList();
    model.tbEliTABLA = _renderListExpediente.tbEliTABLA;
    model.listaEntidades = ManInfFundamentado_AddEdit.DataEntidad;

    var falta = ManInfFundamentado_AddEdit.fnValidarAtributos(model);

    if (falta != "") {
        utilSigo.toastWarning("Aviso", falta);
    }
    else {
        utilSigo.dialogConfirm("", "Está seguro registrar los datos?", function (r) {
            if (r) {
                let url = urlLocalSigo + "Fiscalizacion/InformeFundamentado/Grabar";
                let option = { url: url, datos: JSON.stringify(model), type: 'POST' };
                utilSigo.fnAjax(option, function (data) {
                    if (data.success) {
                        window.location = `${urlLocalSigo}/Fiscalizacion/InformeFundamentado/Index`;
                        utilSigo.toastSuccess("Éxito", "Datos actualizados correctamente");
                    }
                    else {
                        utilSigo.toastWarning("Aviso", data.msj);
                    }
                });
            }
        });
    }
}

ManInfFundamentado_AddEdit.fnSaveFormV2 = function () {

    let hdfCodInfFundamentado = ManInfFundamentado_AddEdit.frm.find("#hdfCodInfFundamentado").val();
    let hdfCodTipoInfFundamentado = ManInfFundamentado_AddEdit.frm.find("#hdfCodTipoInfFundamentado").val();
    let RegEstado = ManInfFundamentado_AddEdit.frm.find("#RegEstado").val();

    let ddlEstadoSolicitudFemaId = ManInfFundamentado_AddEdit.frm.find("#ddlEstadoSolicitudFemaId").val();
    let txtRegistro = ManInfFundamentado_AddEdit.frm.find("#txtRegistro").val();
    let dtpFechaIngresoSolicitud = ManInfFundamentado_AddEdit.frm.find("#dtpFechaIngresoSolicitud").val();
    let txtNumeroOficioSolicitud = ManInfFundamentado_AddEdit.frm.find("#txtNumeroOficioSolicitud").val();
    let ddlTipoSolicitudId = ManInfFundamentado_AddEdit.frm.find("#ddlTipoSolicitud").val();
    let ddlVencimientoPlazoLegalId = ManInfFundamentado_AddEdit.frm.find("#ddlVencimientoPlazoLegal").val();
    let txtDetalle = ManInfFundamentado_AddEdit.frm.find("#txtDetalle").val();
    let ddlOdId = ManInfFundamentado_AddEdit.frm.find("#ddlOdId").val();
    let hdfItemEstUbigeoCodigo = ManInfFundamentado_AddEdit.frm.find("#hdfItemEstUbigeoCodigo").val();
    let hdtxtTitularTipo = ManInfFundamentado_AddEdit.frm.find("#hdtxtTitularTipo").val();

    let codigoTipoSolicitud = $("#ddlTipoSolicitud").val();

    // INFORME FUNDAMENTADO
    let chkEmitirInforme = false;
    let dtpfechaFirmezaPAU;
    let txtNumeroInformeFundamentado = "";
    let dtpfechaOficio1 = "";
    let txtNumeroOficio1 = "";
    let dtpFechaEmision2;
    let txtConclusiones = "";
    let txtObservaciones = "";
    let dtpFechaFundamentado = "";
    let chkEmitirOficio = false;
    let txtNumeroOficio2 = "";
    let txtObservacionesOficio = "";

    // PAU/Copia
    let chkEmitirOficioPau = "";
    let txtNumeroOficioPau = "";
    let dtpFechaEmisionPau = "";
    let dtpfechaOficio2 = "";

    switch (codigoTipoSolicitud) {
        case "000001":
            // INFORME FUNDAMENTADO
            chkEmitirInforme = (ManInfFundamentado_AddEdit.frm.find("#chkEmitirInforme").is(":checked") ? 1 : 0);
            dtpfechaFirmezaPAU = ManInfFundamentado_AddEdit.frm.find("#dtpfechaFirmezaPAU").val();
            txtNumeroInformeFundamentado = ManInfFundamentado_AddEdit.frm.find("#txtNumeroInformeFundamentado").val();
            dtpFechaFundamentado = ManInfFundamentado_AddEdit.frm.find("#dtpFechaFundamentado").val();
            //dtpFechaEmision1 = ManInfFundamentado_AddEdit.frm.find("#dtpFechaEmision1").val();
            txtNumeroOficio1 = ManInfFundamentado_AddEdit.frm.find("#txtNumeroOficio1").val();
            dtpfechaOficio1 = ManInfFundamentado_AddEdit.frm.find("#dtpfechaOficio1").val();
            txtConclusiones = ManInfFundamentado_AddEdit.frm.find("#txtConclusiones").val();
            txtObservaciones = ManInfFundamentado_AddEdit.frm.find("#txtObservaciones").val();

            chkEmitirOficio = (ManInfFundamentado_AddEdit.frm.find("#chkEmitirOficio").is(":checked") ? 1 : 0);
            txtNumeroOficio2 = ManInfFundamentado_AddEdit.frm.find("#txtNumeroOficio2").val();
            dtpfechaOficio2 = ManInfFundamentado_AddEdit.frm.find("#dtpfechaOficio2").val();
            txtObservacionesOficio = ManInfFundamentado_AddEdit.frm.find("#txtObservacionesOficio").val();
            break;
        case "000002":
        case "000003":
            // PAU/Copia
            chkEmitirOficioPau = (ManInfFundamentado_AddEdit.frm.find("#chkEmitirOficioPau").is(":checked") ? 1 : 0);
            txtNumeroOficioPau = ManInfFundamentado_AddEdit.frm.find("#txtNumeroOficioPau").val();
            dtpFechaEmisionPau = ManInfFundamentado_AddEdit.frm.find("#dtpFechaEmisionPau").val();

            break;
    }

    // Notificacion
    let chkNotificacion = (ManInfFundamentado_AddEdit.frm.find("#chkNotificacion").is(":checked") ? 1 : 0);
    let dtpFechaNotificacion = ManInfFundamentado_AddEdit.frm.find("#dtpFechaNotificacion").val();
    let txtAnotaciones = ManInfFundamentado_AddEdit.frm.find("#txtAnotaciones").val();

    let hdfCodigoInfFundamentadoAlerta = ManInfFundamentado_AddEdit.frm.find("#hdfCodigoInfFundamentadoAlerta").val();


    let model = {
        hdfCodInfFundamentado, hdfCodTipoInfFundamentado, RegEstado, ddlEstadoSolicitudFemaId, txtRegistro, dtpFechaIngresoSolicitud, txtNumeroOficioSolicitud,
        ddlTipoSolicitudId, ddlVencimientoPlazoLegalId, txtDetalle, ddlOdId, hdfItemEstUbigeoCodigo, hdtxtTitularTipo,
        chkEmitirInforme, dtpfechaFirmezaPAU, txtNumeroInformeFundamentado, dtpFechaFundamentado, txtNumeroOficio1, dtpfechaOficio1, txtConclusiones, txtObservaciones,
        chkEmitirOficio, txtNumeroOficio2, dtpfechaOficio2, txtObservacionesOficio,
        chkEmitirOficioPau, txtNumeroOficioPau, dtpFechaEmisionPau,
        chkNotificacion, dtpFechaNotificacion, txtAnotaciones,
        hdfCodigoInfFundamentadoAlerta
    }
    switch (codigoTipoSolicitud) {
        case "000001":
            model.tbInforme = _renderListExpediente.fnGetList();
            break;
        case "000002":
        case "000003":
            model.tbInforme = _renderListExpedienteSigo.fnGetList();
            break;
    }
    model.vmControlCalidad = _ControlCalidad.fnGetDatosControlCalidad();
    model.listaProfesionales = ManInfFundamentado_AddEdit.DataProfesional;
    //model.tbInforme = _renderListExpediente.fnGetList();
    model.tbEliTABLA = _renderListExpediente.tbEliTABLA;
    model.listaEntidades = ManInfFundamentado_AddEdit.DataEntidad;

    if (chkEmitirInforme || chkEmitirOficioPau) {
        _ControlCalidad.frm.find("#ddlEstadoSolicitudFemaId").val('000002');
        model.vmControlCalidad.ddlEstadoSolicitudFemaId = '000002';
    }


    var falta = ManInfFundamentado_AddEdit.fnValidarAtributosV2(model);

    if (falta != "") {
        utilSigo.toastWarning("Aviso", falta);
    }
    else {
        utilSigo.dialogConfirm("", "Está seguro registrar los datos?", function (r) {
            if (r) {
                let url = urlLocalSigo + "Fiscalizacion/InformeFundamentado/GrabarInFun";
                let option = { url: url, datos: JSON.stringify(model), type: 'POST' };
                utilSigo.fnAjax(option, function (data) {
                    if (data.success) {
                        window.location = `${urlLocalSigo}/Fiscalizacion/InformeFundamentado/Index`;
                        utilSigo.toastSuccess("Éxito", "Datos actualizados correctamente");
                    }
                    else {
                        utilSigo.toastWarning("Aviso", data.msj);
                    }
                });
            }
        });
    }
}

ManInfFundamentado_AddEdit.fnValidarAtributosV2 = function (obj) {
    var falta = "", band = 0;
    if (obj.vmControlCalidad.ddlIndicadorId == 0) {
        falta = "Debe seleccionar la situación actual de su registro";
        band = 1;
    }
    if (band == 0) {
        if (obj.RegEstado == "") {
            falta = "Debe seleccionar la O.D. desde donde se registra la información";
            band = 1;
        }
    }
    if (band == 0) {
        if (obj.txtRegistro == "") {
            falta = "Ingrese Número de Registro";
            band = 1;
        }
    }
    if (band == 0) {
        if (obj.dtpFechaIngresoSolicitud.trim() == "") {
            falta = "Ingrese Fecha de Ingreso de la Solicitud";
            band = 1;
        }
    }
    if (band == 0) {
        if (obj.txtNumeroOficioSolicitud.trim() == "") {
            falta = "Ingrese Número de Oficio(Solicitud)";
            band = 1;
        }
    }
    if (band == 0) {
        if (obj.ddlTipoSolicitudId == 0) {
            falta = "Debe seleccionar Tipo de Solicitud";
            band = 1;
        }
    }
    if (band == 0) {
        if (obj.ddlVencimientoPlazoLegalId == 0) {
            falta = "Debe seleccionar Vencimiento de Plazo Legal";
            band = 1;
        }
    }
    if (band == 0) {
        if (obj.ddlOdId == 0) {
            falta = "Debe seleccionar O.D. Competente";
            band = 1;
        }
    }

    if (band == 0) {
        if (obj.hdfItemEstUbigeoCodigo.trim() == "") {
            falta = "Debe seleccionar Región";
            band = 1;
        }
    }
    if (band == 0) {
        if (obj.hdtxtTitularTipo.trim() == "") {
            falta = "Debe seleccionar Usuario Asignado";
            band = 1;
        }
    }

    var codigoTipoSolicitud = obj.ddlTipoSolicitudId;
    switch (codigoTipoSolicitud) {
        case "000001":
            if (obj.chkEmitirInforme) {
                if (band == 0) {
                    if (obj.dtpfechaFirmezaPAU.trim() == "") {
                        falta = "Debe seleccionar Fecha de Firmeza del PAU";
                        band = 1;
                    }
                }
                if (band == 0) {
                    if (obj.txtNumeroInformeFundamentado.trim() == "") {
                        falta = "Ingrese Número de Informe Fundamentado";
                        band = 1;
                    }
                }
                if (band == 0) {
                    if (obj.dtpFechaFundamentado.trim() == "") {
                        falta = "Ingrese Fecha de Emisión";
                        band = 1;
                    }
                }
                if (band == 0) {
                    if (obj.txtNumeroOficio1.trim() == "") {
                        falta = "Ingrese Número de Oficio";
                        band = 1;
                    }
                }
                if (band == 0) {
                    if (obj.dtpfechaOficio1.trim() == "") {
                        falta = "Debe seleccionar Fecha de Oficio";
                        band = 1;
                    }
                }
            }
            if (obj.chkEmitirOficio) {
                if (band == 0) {
                    if (obj.txtNumeroOficio2.trim() == "") {
                        falta = "Ingrese Número de Oficio";
                        band = 1;
                    }
                }
                if (band == 0) {
                    if (obj.dtpfechaOficio2.trim() == "") {
                        falta = "Debe seleccionar Fecha de Oficio";
                        band = 1;
                    }
                }
            }
            break;
        case "000002":
        case "000003":
            if (obj.chkEmitirOficioPau) {
                if (band == 0) {
                    if (obj.txtNumeroOficioPau.trim() == "") {
                        falta = "Ingrese Número de Oficio";
                        band = 1;
                    }
                }
                if (band == 0) {
                    if (obj.dtpFechaEmisionPau.trim() == "") {
                        falta = "Debe seleccionar Fecha de Emisión";
                        band = 1;
                    }
                }
            }
            break;
    }

    if (obj.chkNotificacion) {
        if (band == 0) {
            if (obj.dtpFechaNotificacion.trim() == "") {
                falta = "Debe seleccionar Fecha de Notificación";
                band = 1;
            }
        }
    }

    return falta;
}

ManInfFundamentado_AddEdit.fnValidarAtributos = function (obj) {
    var falta = "", band = 0;

    if (obj.vmControlCalidad.ddlIndicadorId == 0) {
        falta = "Debe seleccionar la situación actual de su registro";
        band = 1;
    }
    if (band == 0) {
        if (obj.RegEstado == "") {
            falta = "Debe seleccionar la O.D. desde donde se registra la información";
            band = 1;
        }
    }
    if (band == 0) {
        if (obj.txtFechaFundamentado.trim() == "") {
            falta = "Ingrese Fecha de Emisión";
            band = 1;
        }
    }
    if (band == 0) {
        if (obj.txtNumInfFundamentado.trim() == "") {
            falta = "Ingrese Número de Informe Fundamentado";
            band = 1;
        }
    }
    if (band == 0) {
        if (obj.tbInforme.length == 0) {
            falta = "Ingresar el Informe de Supervisión o el Expediente";
            band = 1;
        }
    }

    return falta;

}

ManInfFundamentado_AddEdit.fnFiltrarSubEntidad = function (_codEntidad) {
    var url = urlLocalSigo + "Fiscalizacion/InformeFundamentado/FiltrarSubEntidad";
    var option = { url: url, type: 'POST', datos: JSON.stringify({ asCodEntidad: _codEntidad }) };

    utilSigo.fnAjax(option, function (data) {
        if (data.success) {
            var SubEntidad = ManInfFundamentado_AddEdit.frm.find("#ddlSubEntidadId");
            SubEntidad.empty();
            $.each(data.result, function (index, item) {
                var p = new Option(item.Text, item.Value);
                SubEntidad.append(p);
            });
        }
        else {
            utilSigo.toastWarning("Aviso", "Sucedio un error, Comuníquese con el Administrador");
            console.log(data.result);
        }
    });
}

ManInfFundamentado_AddEdit.fnAddEntidades = function (_codEntidad, _descEntidad, _codSubEntidad, _descSubEntidad) {
    var url = urlLocalSigo + "Fiscalizacion/InformeFundamentado/agregarEntidades";
    var params = {};
    params.COD_SENTIDAD = _codSubEntidad;
    params.DESCRIPCION_ENTIDAD = _descEntidad;
    params.DESCRIPCION_SUBENTIDAD = _descSubEntidad;
    var option = { url: url, datos: JSON.stringify(params), type: 'POST' };

    utilSigo.fnAjax(option, function (data) {
        if (data.success) {
            if (data.value) {
                ManInfFundamentado_AddEdit.DataEntidad = data.result;
                ManInfFundamentado_AddEdit.dtRenderListEntidad.clear().draw();
                ManInfFundamentado_AddEdit.dtRenderListEntidad.rows.add(ManInfFundamentado_AddEdit.DataEntidad).draw();
            }
            else {
                utilSigo.toastWarning("Aviso", "La Entidad ya existe");
            }
        }
        else {
            utilSigo.toastWarning("Aviso", "Sucedio un error, Comuníquese con el Administrador");
            console.log(data.result);
        }
    });
}

ManInfFundamentado_AddEdit.fnDelete = function (obj, _tabla) {
    var dt, data, url, params = {};

    switch (_tabla) {
        case "PROFESIONAL":
            url = urlLocalSigo + "Fiscalizacion/InformeFundamentado/quitarProfesional";
            dt = ManInfFundamentado_AddEdit.dtRenderListProfesional;
            data = dt.row($(obj).parents('tr')).data();
            params.COD_PERSONA = data["COD_PERSONA"];
            break;

        case "ENTIDAD":
            url = urlLocalSigo + "Fiscalizacion/InformeFundamentado/quitarEntidad";
            dt = ManInfFundamentado_AddEdit.dtRenderListEntidad;
            data = dt.row($(obj).parents('tr')).data();
            params.COD_SENTIDAD = data["COD_SENTIDAD"];
            params.COD_SUBENTIDAD = data["COD_SUBENTIDAD"];
            break;
    }

    utilSigo.dialogConfirm("Confirmacion", "¿ Está seguro de Eliminar el Registro Seleccionado ?", function (r) {
        if (r) {
            var option = { url: url, datos: JSON.stringify(params), type: 'POST' };

            utilSigo.fnAjax(option, function (result) {
                if (result.success) {
                    dt.row($(obj).parents('tr')).remove().draw(false);

                    switch (_tabla) {
                        case "PROFESIONAL":
                            ManInfFundamentado_AddEdit.DataProfesional = dt.data().toArray();
                            break;

                        case "ENTIDAD":
                            ManInfFundamentado_AddEdit.DataEntidad = dt.data().toArray();
                            break;
                    }

                    utilDt.enumColumn(dt);
                    utilSigo.toastSuccess("Éxito", result.msj);
                } else {
                    utilSigo.toastWarning("Aviso", "Sucedio un error, Comuníquese con el Administrador");
                    console.log(result.msj);
                }
            });
        }
    });
}

ManInfFundamentado_AddEdit.fnDeleteAll = function (_tabla) {
    var dt, url, opc;

    switch (_tabla) {
        case "PROFESIONAL":
            url = urlLocalSigo + "Fiscalizacion/InformeFundamentado/quitarAll";
            dt = ManInfFundamentado_AddEdit.dtRenderListProfesional;
            opc = _tabla;
            break;
    }

    utilSigo.dialogConfirm("Confirmacion", "¿Está seguro de eliminar todos los registros?", function (r) {
        if (r) {
            var option = { url: url, datos: JSON.stringify({ opc }), type: 'POST' };

            utilSigo.fnAjax(option, function (result) {
                if (result.success) {
                    switch (_tabla) {
                        case "PROFESIONAL":
                            ManInfFundamentado_AddEdit.DataProfesional = [];
                            dt.clear().draw();
                            break;
                    }

                    utilDt.enumColumn(dt);
                    utilSigo.toastSuccess("Éxito", result.msj);
                } else {
                    utilSigo.toastWarning("Aviso", "Sucedio un error, Comuníquese con el Administrador");
                    console.log(result.msj);
                }
            });
        }
    });
}

ManInfFundamentado_AddEdit.fnInitDataTable_Detail = function () {
    var columns_label = [], columns_data = [], options = {};

    //Cargar Profesionales
    columns_label = ["Nº DNI", "Apellidos y Nombres", "Tipo"];
    columns_data = ["NUMERO", "APELLIDOS_NOMBRES", "TIPO"];
    options = {
        page_length: 10, row_index: true, row_delete: true, row_fnDelete: "ManInfFundamentado_AddEdit.fnDelete(this,'PROFESIONAL')", page_sort: true
    };
    ManInfFundamentado_AddEdit.dtRenderListProfesional = utilDt.fnLoadDataTable_Detail(ManInfFundamentado_AddEdit.frm.find("#tbProfesionales"), columns_label, columns_data, options);
    ManInfFundamentado_AddEdit.dtRenderListProfesional.rows.add(JSON.parse(ManInfFundamentado_AddEdit.DataProfesional)).draw();

    //Cargar Entidades
    columns_label = ["Entidad", "Departamento"];
    columns_data = ["DESCRIPCION_ENTIDAD", "DESCRIPCION_SUBENTIDAD"];
    options = {
        page_length: 10, row_index: true, row_delete: true, row_fnDelete: "ManInfFundamentado_AddEdit.fnDelete(this,'ENTIDAD')", page_sort: true
    };
    ManInfFundamentado_AddEdit.dtRenderListEntidad = utilDt.fnLoadDataTable_Detail(ManInfFundamentado_AddEdit.frm.find("#tbEntidades"), columns_label, columns_data, options);
    ManInfFundamentado_AddEdit.dtRenderListEntidad.rows.add(JSON.parse(ManInfFundamentado_AddEdit.DataEntidad)).draw();

}

$(document).ready(function () {
    ManInfFundamentado_AddEdit.frm = $("#frmInfFundamentadoRegistro");
    ManInfFundamentado_AddEdit.iniciarEventos();

    ManInfFundamentado_AddEdit.frm.find("#ddlEntidadId").change(function () {
        ManInfFundamentado_AddEdit.fnFiltrarSubEntidad(ManInfFundamentado_AddEdit.frm.find("#ddlEntidadId").val());
    });

    ManInfFundamentado_AddEdit.fnInitDataTable_Detail();

    $("#btnAddEntidades").click(function () {
        ManInfFundamentado_AddEdit.fnAddEntidades(ManInfFundamentado_AddEdit.frm.find("#ddlEntidadId").val(),
            ManInfFundamentado_AddEdit.frm.find("#ddlEntidadId option:selected").text(),
            ManInfFundamentado_AddEdit.frm.find("#ddlSubEntidadId").val(),
            ManInfFundamentado_AddEdit.frm.find("#ddlSubEntidadId option:selected").text());
    });


    $("#ddlTipoSolicitud").on("change", function () {
        let codigoTipoSolicitud = $("#ddlTipoSolicitud").val();
        switch (codigoTipoSolicitud) {
            case "000001":
                //$('#inputId').prop('readonly', true);
                $("#idNavPauCopia").css("display", "none");
                $("#idNavInformeFundamentado").css("display", "block");
                break;
            case "000002":
            case "000003":
                $("#idNavPauCopia").css("display", "block");
                $("#idNavInformeFundamentado").css("display", "none");
                break;
        }

    }).trigger('change');

});
