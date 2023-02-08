var ManInfTitular_AddEdit = {};

ManInfTitular_AddEdit.DataPersona = [];
ManInfTitular_AddEdit.tbEliminaPersona = [];
//ManInfTitular_AddEdit.selectFile = null;

ManInfTitular_AddEdit.fnLoadData = function (obj, tipo) {
    switch (tipo) {
        case "DataPersona": ManInfTitular_AddEdit.DataPersona = obj; break;
    }
};

//para iniciar los eventos
ManInfTitular_AddEdit.iniciarEventos = function () {
    ManInfTitular_AddEdit.frm.find("#txtFechaEmision").datepicker({ format: "dd/mm/yyyy", autoclose: true, language: 'es' });
    ManInfTitular_AddEdit.frm.find("#txtFechaPresentacion").datepicker({ format: "dd/mm/yyyy", autoclose: true, language: 'es' });
    ManInfTitular_AddEdit.frm.find("#txtfecinipago").datepicker({ format: "dd/mm/yyyy", autoclose: true, language: 'es' });
    ManInfTitular_AddEdit.frm.find("#txtfecfinpago").datepicker({ format: "dd/mm/yyyy", autoclose: true, language: 'es' });
    ManInfTitular_AddEdit.frm.find("#txtFechaCarta").datepicker({ format: "dd/mm/yyyy", autoclose: true, language: 'es' });

    $("#divApelarMedCaut").hide();
    $("#pnlblVista1").hide();
    $("#pnVista1").hide();
    $("#panelFirmaLegalizada").hide();
    $("#pnlblVista2").hide();
    $("#pnVista2").hide();
    $("#pnlblVista3").hide();
    $("#pnVista3").hide();
    $("#pnlblVista4").hide();
    $("#pnVista4").hide();
    $("#pnlblVista5").hide();
    $("#pnVista5").hide();
    $("#pnlblVista6").hide();
    $("#pnVista6").hide();
    $("#pnlblVista7").hide();
    $("#pnVista7").hide();
    $("#pnlblVista8").hide();
    $("#pnVista8").hide();
    $("#pnlblVista9").hide();
    $("#pnVista9").hide();
    $("#pnlblVista10").hide();
    $("#pnVista10").hide();
    $("#pnlblVista11").hide();
    $("#pnVista11").hide();
    $("#pnlblVista12").hide();
    $("#pnVista12").hide();
    $("#dvFechaEmision").hide();
    $("#pnlblVista13").hide();
    $("#pnVista13").hide();
    $("#pnlblVista14").hide();
    $("#pnVista14").hide();
    $("#pnlblVista15").hide();
    $("#pnVista15").hide();
    $("#pnlblVista16").hide();
    $("#pnVista16").hide();
    $("#pnlblVista17").hide();
    $("#pnVista17").hide();

    var codTipoInfTitular = ManInfTitular_AddEdit.frm.find("#hdfCodTipoInfTitular").val();

    switch (codTipoInfTitular) {
        case "0000019":
            $("#pnlblVista1").show();
            $("#pnVista1").show();
            break;
        case "0000025":
            $("#pnlblVista2").show();
            $("#pnVista2").show();
            $("#pnlblVista17").show();
            $("#pnVista17").show();
            break;
        case "0000026":
            $("#pnlblVista3").show();
            $("#pnVista3").show();
            $("#pnlblVista17").show();
            $("#pnVista17").show();
            break;
        case "0000020":
            $("#pnlblVista4").show();
            $("#pnVista4").show();
            break;
        case "0000024":
            $("#pnlblVista5").show();
            $("#pnVista5").show();
            break;
        case "0000021":
            $("#pnlblVista6").hide();
            $("#pnVista6").hide();
            break;
        case "0000022":
            $("#pnlblVista7").hide();
            $("#pnVista7").hide();
            break;
        case "0000023":
            $("#pnlblVista8").show();
            $("#pnVista8").show();
            break;
        case "0000027":
            $("#pnlblVista9").show();
            $("#pnVista9").show();
            break;
        case "0000050":
            $("#pnlblVista10").show();
            $("#pnVista10").show();
            break;
        case "0000081":
            $("#pnlblVista11").show();
            $("#pnVista11").show();
            break;
        case "0000082":
            $("#pnlblVista12").show();
            $("#pnVista12").show();
            $("#dvFechaEmision").show();
            break;
        case "0000083":
            $("#pnlblVista13").show();
            $("#pnVista13").show();
            break;
        case "0000084":
            $("#pnlblVista14").show();
            $("#pnVista14").show();
            break;
        case "0000085":
            $("#pnlblVista15").show();
            $("#pnVista15").show();
            break;
        case "0000086":
            $("#pnlblVista16").show();
            $("#pnVista16").show();
            break;
        case "0000112":
            $("#pnlblVista1").show();
            $("#pnVista1").show();
            break;
    }

    if (ManInfTitular_AddEdit.frm.find("#chkApelarMedCaut").prop("checked") == true) $("#divApelarMedCaut").show();
    else $("#divApelarMedCaut").hide();

    ManInfTitular_AddEdit.fnMostrarFirmaLegalizada(ManInfTitular_AddEdit.frm.find("#ddlDescargoTipoId").val());
};

//vuelve a la vista principal del listado
ManInfTitular_AddEdit.regresar = function (appServer) {
    var url = "";
    url = urlLocalSigo + "Fiscalizacion/InformacionTitular/Index";
    window.location = url;

};

ManInfTitular_AddEdit.fnBuscarPersona = function (_dom, _tipoPersona) {
    var valCodPTipo;

    switch (_dom) {
        case "TI":
            valCodPTipo = "0000001"; break;
        default:
            valCodPTipo = "TODOS";
    }

    var url = urlLocalSigo + "General/Controles/_BuscarPersonaGeneral";
    var option = { url: url, type: 'GET', datos: { asBusGrupo: "PERSONA", asCodPTipo: valCodPTipo, asTipoPersona: _tipoPersona }, divId: "mdlBuscarPersona" };
    utilSigo.fnOpenModal(option, function () {
        _bPerGen.fnAsignarDatos = function (obj) {
            if (obj != null && obj != "") {
                var data = _bPerGen.dtBuscarPerona.row($(obj).parents('tr')).data();
                switch (_dom) {
                    case "TI":
                        ManInfTitular_AddEdit.frm.find("#hdfItemTprofesionalCodigo").val(data["COD_PERSONA"]);
                        ManInfTitular_AddEdit.frm.find("#txtItemTprofesional").val(data["PERSONA"]);
                        break;

                    case "OT":
                        ManInfTitular_AddEdit.frm.find("#hdfItemOtraPersonafirma").val(data["COD_PERSONA"]);
                        ManInfTitular_AddEdit.frm.find("#txtItemOtraPersonafirma").val(data["PERSONA"]);
                        break;
                }
                utilSigo.fnCloseModal("mdlBuscarPersona");
            }
        };
        _bPerGen.fnInit();
    });
};

ManInfTitular_AddEdit.fnBuscarUbigeo = function (_dom) {
    var url = urlLocalSigo + "General/Controles/_Ubigeo";
    var option = { url: url, type: 'POST', datos: {}, divId: "mdlBuscarUbigeo" };
    utilSigo.fnOpenModal(option, function () {
        _Ubigeo.fnSelectUbigeo = function (_ubigeoText, _ubigeoId) {
            switch (_dom) {
                case "EUbigeoTit":
                    ManInfTitular_AddEdit.frm.find("#hdfItemEstUbigeoLugarpresentacion").val(_ubigeoId);
                    ManInfTitular_AddEdit.frm.find("#txtItemEstUbigeoLugarpresentacion").val(_ubigeoText);
                    break;

                case "EUbigeo":
                    ManInfTitular_AddEdit.frm.find("#hdfItemEstUbigeoCodigo").val(_ubigeoId);
                    ManInfTitular_AddEdit.frm.find("#txtItemEstUbigeo").val(_ubigeoText);
                    break;

                case "EUbigeoNew":
                    ManInfTitular_AddEdit.frm.find("#hdfItemNewUbigeoTHCodigo").val(_ubigeoId);
                    ManInfTitular_AddEdit.frm.find("#txtItemNewUbigeoTH").val(_ubigeoText);
                    break;
            }
            $("#mdlBuscarUbigeo").modal('hide');
        }

        switch (_dom) {
            case "EUbigeoTit":
                _Ubigeo.fnLoadModalView(ManInfTitular_AddEdit.frm.find("#hdfItemEstUbigeoLugarpresentacion").val());
                break;

            case "EUbigeo":
                _Ubigeo.fnLoadModalView(ManInfTitular_AddEdit.frm.find("#hdfItemEstUbigeoCodigo").val());
                break;

            case "EUbigeoNew":
                _Ubigeo.fnLoadModalView(ManInfTitular_AddEdit.frm.find("#hdfItemNewUbigeoTHCodigo").val());
                break;     
        }

    }, ManInfTitular_AddEdit.fnCustomValidateForm);
};

ManInfTitular_AddEdit.fnSaveForm = function () {
    let hdfCodInfTitular = ManInfTitular_AddEdit.frm.find("#hdfCodInfTitular").val();
    let hdfCodTipoInfTitular = ManInfTitular_AddEdit.frm.find("#hdfCodTipoInfTitular").val();
    let RegEstado = ManInfTitular_AddEdit.frm.find("#RegEstado").val();
    let ddlOdId = ManInfTitular_AddEdit.frm.find("#ddlOdId").val();
    let txtTipoInfTitular = ManInfTitular_AddEdit.frm.find("#txtTipoInfTitular").val();
    let txtItemTprofesional = ManInfTitular_AddEdit.frm.find("#txtItemTprofesional").val();
    let hdfItemTprofesionalCodigo = ManInfTitular_AddEdit.frm.find("#hdfItemTprofesionalCodigo").val();
    let ddlTitularId = ManInfTitular_AddEdit.frm.find("#ddlTitularId").val();
    let txtFechaEmision = ManInfTitular_AddEdit.frm.find("#txtFechaEmision").val();
    let txtFechaPresentacion = ManInfTitular_AddEdit.frm.find("#txtFechaPresentacion").val();
    let txtItemEstUbigeoLugarpresentacion = ManInfTitular_AddEdit.frm.find("#txtItemEstUbigeoLugarpresentacion").val();
    let hdfItemEstUbigeoLugarpresentacion = ManInfTitular_AddEdit.frm.find("#hdfItemEstUbigeoLugarpresentacion").val();
    let txtItemEtiNContrato = ManInfTitular_AddEdit.frm.find("#txtItemEtiNContrato").val();
    let txtDomicilioProcesal = ManInfTitular_AddEdit.frm.find("#txtDomicilioProcesal").val();
    let chkApelarMedCaut = ManInfTitular_AddEdit.frm.find("#chkApelarMedCaut").prop("checked");
    let txtItemOtraPersonafirma = ManInfTitular_AddEdit.frm.find("#txtItemOtraPersonafirma").val();
    let hdfItemOtraPersonafirma = ManInfTitular_AddEdit.frm.find("#hdfItemOtraPersonafirma").val();
    let ddlTipoProfesionalId = ManInfTitular_AddEdit.frm.find("#ddlTipoProfesionalId").val();
    let txtItemEstUbigeo = ManInfTitular_AddEdit.frm.find("#txtItemEstUbigeo").val();
    let hdfItemEstUbigeoCodigo = ManInfTitular_AddEdit.frm.find("#hdfItemEstUbigeoCodigo").val();
    let txtDireccion = ManInfTitular_AddEdit.frm.find("#txtDireccion").val();
    let txttelefono = ManInfTitular_AddEdit.frm.find("#txttelefono").val();
    let txtcorreo = ManInfTitular_AddEdit.frm.find("#txtcorreo").val();
    let ddlDescargoTipoId = ManInfTitular_AddEdit.frm.find("#ddlDescargoTipoId").val();
    let chkfirmaLegalizada = ManInfTitular_AddEdit.frm.find("#chkfirmaLegalizada").prop("checked");
    let chkAudienciaOral = ManInfTitular_AddEdit.frm.find("#chkAudienciaOral").prop("checked");
    let txtdescripciondescargo = ManInfTitular_AddEdit.frm.find("#txtdescripciondescargo").val();
    let txtrecursorecon = ManInfTitular_AddEdit.frm.find("#txtrecursorecon").val();
    let txtrecursoapelacion = ManInfTitular_AddEdit.frm.find("#txtrecursoapelacion").val();
    let chkNulidad_RecApe = ManInfTitular_AddEdit.frm.find("#chkNulidad_RecApe").prop("checked");
    let txtObservNul_RecApe = ManInfTitular_AddEdit.frm.find("#txtObservNul_RecApe").val();
    let txtfunpresentadoscautelar = ManInfTitular_AddEdit.frm.find("#txtfunpresentadoscautelar").val();
    let txtnumcuotas = ManInfTitular_AddEdit.frm.find("#txtnumcuotas").val();
    let txtmontocuota = ManInfTitular_AddEdit.frm.find("#txtmontocuota").val();
    let txtfecinipago = ManInfTitular_AddEdit.frm.find("#txtfecinipago").val();
    let txtfecfinpago = ManInfTitular_AddEdit.frm.find("#txtfecfinpago").val();
    let txtfundamentosaudiencia = ManInfTitular_AddEdit.frm.find("#txtfundamentosaudiencia").val();
    let txtinspeccionoc = ManInfTitular_AddEdit.frm.find("#txtinspeccionoc").val();
    let txtampliaciondescargo = ManInfTitular_AddEdit.frm.find("#txtampliaciondescargo").val();
    let txtsolicitudfInfo = ManInfTitular_AddEdit.frm.find("#txtsolicitudfInfo").val();
    let txtotros = ManInfTitular_AddEdit.frm.find("#txtotros").val();
    let txtFundQueja_Queja = ManInfTitular_AddEdit.frm.find("#txtFundQueja_Queja").val();
    let txtObservMedidaCorrect = ManInfTitular_AddEdit.frm.find("#txtObservMedidaCorrect").val();
    let txtObservActividad = ManInfTitular_AddEdit.frm.find("#txtObservActividad").val();
    let txtMotivoDesistimiento = ManInfTitular_AddEdit.frm.find("#txtMotivoDesistimiento").val();
    let txtItemNewUbigeoTH = ManInfTitular_AddEdit.frm.find("#txtItemNewUbigeoTH").val();
    let hdfItemNewUbigeoTHCodigo = ManInfTitular_AddEdit.frm.find("#hdfItemNewUbigeoTHCodigo").val();
    let txtNewDireccionTH = ManInfTitular_AddEdit.frm.find("#txtNewDireccionTH").val();
    let txtNewReferenciaTH = ManInfTitular_AddEdit.frm.find("#txtNewReferenciaTH").val();
    let txtObservSubsanacion = ManInfTitular_AddEdit.frm.find("#txtObservSubsanacion").val();
    let chkEmitioCarta = ManInfTitular_AddEdit.frm.find("#chkEmitioCarta").prop("checked");
    let txtNroCarta = ManInfTitular_AddEdit.frm.find("#txtNroCarta").val();
    let txtFechaCarta = ManInfTitular_AddEdit.frm.find("#txtFechaCarta").val();
    let txtObservaciones = ManInfTitular_AddEdit.frm.find("#txtObservaciones").val();
    let hdfCodigoInfTitularAlerta = ManInfTitular_AddEdit.frm.find("#hdfCodigoInfTitularAlerta").val();

    let model = {
        hdfCodInfTitular, hdfCodTipoInfTitular, RegEstado, ddlOdId, txtTipoInfTitular, txtItemTprofesional, hdfItemTprofesionalCodigo, ddlTitularId, txtFechaEmision,
        txtFechaPresentacion, txtItemEstUbigeoLugarpresentacion, hdfItemEstUbigeoLugarpresentacion, txtItemEtiNContrato, txtDomicilioProcesal, chkApelarMedCaut,
        txtItemOtraPersonafirma, hdfItemOtraPersonafirma, ddlTipoProfesionalId, txtItemEstUbigeo, hdfItemEstUbigeoCodigo, txtDireccion, txttelefono, txtcorreo,
        ddlDescargoTipoId, chkfirmaLegalizada, chkAudienciaOral, txtdescripciondescargo, txtrecursorecon, txtrecursoapelacion, chkNulidad_RecApe, txtObservNul_RecApe,
        txtfunpresentadoscautelar, txtnumcuotas, txtmontocuota, txtfecinipago, txtfecfinpago, txtfundamentosaudiencia, txtinspeccionoc, txtampliaciondescargo,
        txtsolicitudfInfo, txtotros, txtFundQueja_Queja, txtObservMedidaCorrect, txtObservActividad, txtMotivoDesistimiento, txtItemNewUbigeoTH, hdfItemNewUbigeoTHCodigo,
        txtNewDireccionTH, txtNewReferenciaTH, txtObservSubsanacion, chkEmitioCarta, txtNroCarta, txtFechaCarta, txtObservaciones, hdfCodigoInfTitularAlerta
    };

    model.vmControlCalidad = _ControlCalidad.fnGetDatosControlCalidad();
    model.tbInforme = _renderListExpediente.fnGetList();
    model.tbPersonaFirma = ManInfTitular_AddEdit.fnGetListPersona();
    model.tbEliminaInforme = _renderListExpediente.fnGetListEliTABLA();
    model.tbEliminaPersona = ManInfTitular_AddEdit.fnGetListEliTABLA();

    var falta = ManInfTitular_AddEdit.fnValidarAtributos(model);

    if (falta != "") {
        utilSigo.toastWarning("Aviso", falta);
    }
    else {
        utilSigo.dialogConfirm("", "Está seguro registrar los datos?", function (r) {
            if (r) {
                let url = urlLocalSigo + "Fiscalizacion/InformacionTitular/Grabar";
                let option = { url: url, datos: JSON.stringify(model), type: 'POST' };
                utilSigo.fnAjax(option, function (data) {
                    if (data.success) {
                        window.location = `${urlLocalSigo}/Fiscalizacion/InformacionTitular/Index`;
                        utilSigo.toastSuccess("Éxito", "Datos actualizados correctamente");
                    }
                    else {
                        utilSigo.toastWarning("Aviso", data.msj);
                    }
                });
            }
        });
    }
};

ManInfTitular_AddEdit.fnValidarAtributos = function (obj) {
    var falta='';

    if (obj.vmControlCalidad.ddlIndicadorId == "0000000") {
        falta = "Debe seleccionar la situación actual de su registro";
        return falta;
    }
    if (obj.ddlOdId == '0000000') {
        falta = "Debe seleccionar la O.D. desde donde se registra la información";
        return falta;
    }
    if (obj.hdfItemTprofesionalCodigo == '') {
        falta = "Ingrese el Titular que presenta la documentación";
        return falta;
    }
    if (obj.txtItemEtiNContrato.trim() == '') {
        falta = "Ingrese Número de Informaión presentada por el Titular";
        return falta;
    }
    if (obj.hdfItemEstUbigeoLugarpresentacion == '') {
        falta = "Seleccione el Ubigeo del Lugar de presentacion";
        return falta;
    }
    if (obj.hdfCodTipoInfTitular == '0000019') {
        if (obj.hdfItemEstUbigeoCodigo == '') {
            falta = "Seleccione el Ubigeo del Domicilio Procesal Señalado";
            return falta;
        }
        if (obj.ddlDescargoTipoId == '0000000') {
            falta = "Debe seleccionar el tipo de descargo";
            return falta;
        }
    }

    return falta;
};

ManInfTitular_AddEdit.fnMostrarFirmaLegalizada = function (valor) {
    if (valor == "0000002") $("#panelFirmaLegalizada").show();
    else $("#panelFirmaLegalizada").hide();

};

ManInfTitular_AddEdit.fnAddPersonas = function (codTipoProfesional, descTipoProfesional) {
    var codPersona = ManInfTitular_AddEdit.frm.find("#hdfItemOtraPersonafirma").val();
    var nomPersona = ManInfTitular_AddEdit.frm.find("#txtItemOtraPersonafirma").val();
    var band = 0;

    if (codPersona != "") {
        ManInfTitular_AddEdit.dtRenderListPersona.rows().every(function (rowIdx, tableLoop, rowLoop) {
            var data = this.data();
            if (codPersona == data["COD_PERSONA"] && codTipoProfesional == data["COD_PTIPO"]) {
                band = 1;
            }
        });

        if (band == 0) {
            var obj = {};
            obj.COD_PERSONA = codPersona;
            obj.COD_PTIPO = codTipoProfesional;
            obj.PERSONAFIRMA = nomPersona;
            obj.PERSONATIPO = descTipoProfesional;
            obj.RegEstado = 1;

            ManInfTitular_AddEdit.dtRenderListPersona.rows.add([obj]).draw();
            ManInfTitular_AddEdit.dtRenderListPersona.page('last').draw('page');
            ManInfTitular_AddEdit.frm.find("#hdfItemOtraPersonafirma").val("");
            ManInfTitular_AddEdit.frm.find("#txtItemOtraPersonafirma").val("");
        }
        else utilSigo.toastWarning("Aviso", "Los datos ya se encuentran en la lista");
    }
    else utilSigo.toastInfo("Aviso", "Seleccione Persona que firma el documento");
};

ManInfTitular_AddEdit.fnGetListPersona = function () {
    let list = [], rows, countFilas, data;

    rows = ManInfTitular_AddEdit.dtRenderListPersona.$("tr");
    countFilas = rows.length;
    if (countFilas > 0) {
        $.each(rows, function (i, o) {
            data = ManInfTitular_AddEdit.dtRenderListPersona.row($(o)).data();
            list.push(utilSigo.fnConvertArrayToObject(data));
        });
    }
    return list;
};

ManInfTitular_AddEdit.fnDeletePersona = function (obj) {
    utilSigo.dialogConfirm("Confirmacion", "¿Está seguro de Eliminar el Registro Seleccionado?", function (r) {
        if (r) {
            var data = ManInfTitular_AddEdit.dtRenderListPersona.row($(obj).parents('tr')).data();

            if (data["RegEstado"] == "0" || data["RegEstado"] == "2") {

                ManInfTitular_AddEdit.tbEliminaPersona.push({
                    EliTABLA: "INFTIT_DET_PERSONAFIRMA",
                    EliVALOR01: data["COD_PERSONA"],
                    EliVALOR02: data["COD_SECUENCIAL"]

                });
            }
            ManInfTitular_AddEdit.dtRenderListPersona.row($(obj).parents('tr')).remove().draw(false);
            utilSigo.toastSuccess("Éxito", "El elemento ha sido eliminado correctamente");
        }
    });
};

ManInfTitular_AddEdit.fnGetListEliTABLA = function () { return ManInfTitular_AddEdit.tbEliminaPersona; };

ManInfTitular_AddEdit.fnInitDataTable_Detail = function () {
    var columns_label = [], columns_data = [], options = {};

    columns_label = ["Persona firma documento", "Tipo Profesional"];
    columns_data = ["PERSONAFIRMA", "PERSONATIPO"];
    options = {
        page_length: 10, row_index: true, row_delete: true, row_fnDelete: "ManInfTitular_AddEdit.fnDeletePersona(this)", page_sort: true
    };
    ManInfTitular_AddEdit.dtRenderListPersona = utilDt.fnLoadDataTable_Detail(ManInfTitular_AddEdit.frm.find("#tbPersonaFirma"), columns_label, columns_data, options);
    ManInfTitular_AddEdit.dtRenderListPersona.rows.add(JSON.parse(ManInfTitular_AddEdit.DataPersona)).draw();
};

$(document).ready(function () {
    ManInfTitular_AddEdit.frm = $("#frmInfTitularRegistro");
    ManInfTitular_AddEdit.iniciarEventos();
    ManInfTitular_AddEdit.fnInitDataTable_Detail();

    $("#btnAddPersonas").click(function () {
        ManInfTitular_AddEdit.fnAddPersonas(ManInfTitular_AddEdit.frm.find("#ddlTipoProfesionalId").val(),
                                            ManInfTitular_AddEdit.frm.find("#ddlTipoProfesionalId option:selected").text());
    });

    ManInfTitular_AddEdit.frm.find("#ddlDescargoTipoId").change(function () {
        ManInfTitular_AddEdit.fnMostrarFirmaLegalizada(ManInfTitular_AddEdit.frm.find(this).val());
    });
    
});
