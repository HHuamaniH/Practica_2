"use strict";
var ManInforme_AddEditTara = {};
var ManInforme_AddEdit = {};
/*Variables globales*/
ManInforme_AddEditTara.tbEliTABLA = [];
ManInforme_AddEditTara.DataTaraConcepto = [];
ManInforme_AddEditTara.DataManPlantacion = [];
ManInforme_AddEditTara.DataAprovechamiento = [];
ManInforme_AddEditTara.DataCapacitacion = [];
ManInforme_AddEditTara.DataProduccionFruto = [];
ManInforme_AddEditTara.DataAprovechaForestal = [];
ManInforme_AddEditTara.DataCenso = [];
ManInforme_AddEditTara.DataKardex = [];
ManInforme_AddEdit.Denuncia = {
    objDeuncia: {
        tra_M_Tramite: {
            cCodificacion: ''
        },
        COD_IDENUNCIA: '',
        ENT_INFORME: {
            COD_INFORME: ''
        }
    },
    buscarTramite: function () {
        let cCodificacion = $('#inptExpediente').val().trim();
        if (cCodificacion === '') {
            utilSigo.toastWarning("Aviso", "Ingrese N° Tramite STID");
            return;
        }
        let data = {
            tra_M_Tramite: {
                cCodificacion: cCodificacion
            },
            ENT_INFORME: {
                COD_INFORME: $('#hdfCodInforme').val()
            }
        };
        var option = {
            url: urlLocalSigo + "Supervision/ManInforme/ConsultarExpediente",
            datos: JSON.stringify(data),
            type: 'POST'
        };
        if (ManInforme_AddEdit.Denuncia.objDeuncia.tra_M_Tramite.cCodificacion !== undefined) {
            if (ManInforme_AddEdit.Denuncia.objDeuncia.tra_M_Tramite.cCodificacion.trim() === cCodificacion) {
                utilSigo.toastWarning("Aviso", "N° Tramite STID Asignado en este proyecto");
            } else {
                utilSigo.fnAjax(option, function (response) {
                    if (response.iCodTramite != -1) {
                        utilSigo.toastSuccess("Aviso", "N° Tramite STID Encontrado")
                        ManInforme_AddEdit.Denuncia.objDeuncia.tra_M_Tramite = response;
                        $('.responseOk').show();
                        $('.responseError').hide();
                    }
                    else {
                        utilSigo.toastWarning("Aviso", "No Existe N° Tramite STID");
                        $('.responseOk').hide();
                        $('.responseError').show();
                    }
                });
            }
        } else {
            utilSigo.fnAjax(option, function (response) {
                if (response.iCodTramite != -1) {
                    utilSigo.toastSuccess("Aviso", "N° Tramite STID Encontrado")
                    ManInforme_AddEdit.Denuncia.objDeuncia.tra_M_Tramite = response;
                    $('.responseOk').show();
                    $('.responseError').hide();
                }
                else {
                    utilSigo.toastWarning("Aviso", "No Existe N° Tramite STID");
                    $('.responseOk').hide();
                    $('.responseError').show();
                }
            });
        }
    },
    eliminarTramite: function () {
        if ($('#inptExpediente').val() === '') {
            utilSigo.toastWarning("Aviso", "Ingrese N° Tramite STID");
            return;
        } else {
            $('.responseError').hide();
            $('.responseOk').hide();
            ManInforme_AddEdit.Denuncia.objDeuncia.tra_M_Tramite = {};
            $('#inptExpediente').val('');
        }
    },
    obtenerDenuncia: function () {
        var option = {
            url: urlLocalSigo + "Supervision/Denuncias/obtenerDenunciaxInforme",
            datos: JSON.stringify({
                ENT_INFORME: {
                    COD_INFORME: $('#hdfCodInforme').val()
                }
            }),
            type: 'POST'
        };
        utilSigo.fnAjax(option, function (data) {
            if (data.tra_M_Tramite.iCodTramite !== -1 && data.tra_M_Tramite.iCodTramite !== 0) {
                ManInforme_AddEdit.Denuncia.objDeuncia.tra_M_Tramite = data.tra_M_Tramite;
                $('#inptExpediente').val(ManInforme_AddEdit.Denuncia.objDeuncia.tra_M_Tramite.cCodificacion);
                $('.responseOk').show();
                $('.responseError').hide();
            }
            ManInforme_AddEdit.Denuncia.objDeuncia.COD_IDENUNCIA = data.COD_IDENUNCIA;
            if (data.IATENDIDO == 1) {
                $('#rbtnAtendido1').prop('checked', true);
            } else if (data.IATENDIDO == 2) {
                $('#rbtnAtendido2').prop('checked', true);
            }
        });
    }
};

ManInforme_AddEdit.Incidencia = {
    tablaIncidencia: null,
    limpiar: function () {
        $('#COD_IINCIDENCIA').val('0');
        $('#txt_FECHA_SUCESO').val('');
        $('#txt_HORA_SUCESO').val('');
        $('#cboRIESGO').val('00');
        $('#cboPROCESO').val('00');
        $('#cboCIRCUNSTANCIA').val('00');
        $('#txt_UBICACION').val('');
        $('#cboEFECTO').val('00');
        $('#NIVEL_1').val('00');
        $('#NIVEL_2').val('00');
        $('#txt_DSCRP_INCIDENCIA').val('');
        $('#txt_OBSERVACIONES').val('');
        $('#h1').val('');
        $('#h2').val('');
        $('#BtnGuardar').text('GUARDAR');
    },
    Eliminar: function (id) {
        utilSigo.dialogConfirm('', 'Desea continuar con la Eliminacion?', function (r) {
            if (r) {
                utilSigo.fnAjax({
                    url: urlLocalSigo + "Supervision/Denuncias/crud_Incidencia",
                    datos: JSON.stringify({
                        ITipo: 3,
                        COD_IINCIDENCIA: id
                    }),
                    type: 'POST'
                }, function (data) {
                    if (data.COD_IINCIDENCIA != '0') {
                        ManInforme_AddEdit.Incidencia.tablaIncidencia.ajax.reload();
                        ManInforme_AddEdit.Incidencia.limpiar();
                    };
                });
            }
        });
    },
    Editar: function (row) {
        let date = new Date(row.FECHA_SUCESO.split('/')[2], row.FECHA_SUCESO.split('/')[1], row.FECHA_SUCESO.split('/')[0]);
        $('#h1').val(row.OBJCOD_IINCIDENCIA_PROTOCOLOS_NIVEL_1.COD_IINCIDENCIA_PROTOCOLOS);
        $('#h2').val(row.OBJCOD_IINCIDENCIA_PROTOCOLOS_NIVEL_2.COD_IINCIDENCIA_PROTOCOLOS);

        $('#COD_IINCIDENCIA').val(row.COD_IINCIDENCIA);
        $('#txt_FECHA_SUCESO').val(row.FECHA_SUCESO.split('/')[2] + '-' + row.FECHA_SUCESO.split('/')[1] + '-' + row.FECHA_SUCESO.split('/')[0]);
        $('#txt_HORA_SUCESO').val(row.HORA_SUCESO);
        $('#cboRIESGO').val(row.OBJCOD_IINCIDENCIA_PROTOCOLOS_RIESGO.COD_IINCIDENCIA_PROTOCOLOS);
        $('#cboPROCESO').val(row.OBJCOD_IINCIDENCIA_PROTOCOLOS_PROCESO.COD_IINCIDENCIA_PROTOCOLOS);
        $('#cboCIRCUNSTANCIA').val(row.OBJCOD_IINCIDENCIA_PROTOCOLOS_CIRCUNSTANCIA.COD_IINCIDENCIA_PROTOCOLOS);
        $('#txt_UBICACION').val(row.UBICACION);
        $('#cboEFECTO').val(row.OBJCOD_IINCIDENCIA_PROTOCOLOS_EFECTO.COD_IINCIDENCIA_PROTOCOLOS);

        $('#txt_DSCRP_INCIDENCIA').val(row.DSCRP_INCIDENCIA);
        $('#txt_OBSERVACIONES').val(row.OBSERVACIONES);
        $('#BtnGuardar').text('EDITAR');
        $('#cboRIESGO').change();
    },
    cargarData: function (str, select, padre) {
        let data = {
            iINCIDENCIA_TIPO_PROTOCOLO: {
                NOMBRE_TIPO_PROTOCOLO: str
            },
            OBJPROTOCOLO_PADRE: {
                COD_IINCIDENCIA_PROTOCOLOS: padre
            }
        };
        var optionDenuncia = {
            url: urlLocalSigo + "Supervision/ManInforme/listarProtocolos",
            datos: JSON.stringify(data),
            type: 'POST'
        };
        $.ajax({
            url: optionDenuncia.url,
            type: optionDenuncia.type,
            data: optionDenuncia.datos,
            contentType: (typeof optionDenuncia.contentType) === 'undefined' ? 'application/json; charset=utf-8' : optionDenuncia.contentType,
            dataType: (typeof optionDenuncia.dataType) === 'undefined' ? 'json' : optionDenuncia.dataType,
            error: utilSigo.errorAjax,
            success: function (data) {
                $('#' + select).empty();
                $('#' + select).append('<option  value="00">-- Seleccionar --</option>');
                $.each(data, function (i, item) {
                    let x = '';
                    if (i === 0) x = 'selected';
                    $('#' + select).append('<option ' + x + 'title="' + item.NOMBRE_PROTOCOLO + '"  value="' + item.COD_IINCIDENCIA_PROTOCOLOS + '">' + utilSigo.recortarTextos(item.NOMBRE_PROTOCOLO, 40) + '</option>');
                });

            },
            complete: function () {
                let h1 = $('#h1').val();
                $('#NIVEL_1').val((h1 == '' ? '00' : h1));
                let h2 = $('#h2').val();
                $('#NIVEL_2').val((h2 == '' ? '00' : h2));

                //if (str === 'NIVEL 1') {
                //    $('#h1').val('00');
                //}
                //if (str === 'NIVEL 1') {
                //    $('#h2').val('00');
                //}
                $('[data-toggle="tooltip"]').tooltip();
            },
            statusCode: { 203: () => { utilSigo.unblockUIGeneral(); } }
        });
    },
    ui: function () {
        ManInforme_AddEdit.Incidencia.cargarData('RIESGO', 'cboRIESGO');
        ManInforme_AddEdit.Incidencia.cargarData('PROCESO', 'cboPROCESO');
        ManInforme_AddEdit.Incidencia.cargarData('CIRCUNSTANCIA', 'cboCIRCUNSTANCIA');
        ManInforme_AddEdit.Incidencia.cargarData('EFECTO', 'cboEFECTO');
        $('#NIVEL_1').val('00');
        $('#NIVEL_2').val('00');
    },
    eventos: function () {
        $('#cboRIESGO').change(function () {
            ManInforme_AddEdit.Incidencia.cargarData('NIVEL 2', 'NIVEL_2', $(this).val());
            ManInforme_AddEdit.Incidencia.cargarData('NIVEL 1', 'NIVEL_1', $(this).val());
        });
    }
}

ManInforme_AddEditTara.fnLoadData = function (obj, tipo) {
    switch (tipo) {
        case "DataTaraConcepto": ManInforme_AddEditTara.DataTaraConcepto = JSON.parse(obj) || []; break;
        case "DataManPlantacion": ManInforme_AddEditTara.DataManPlantacion = JSON.parse(obj) || []; break;
        case "DataAprovechamiento": ManInforme_AddEditTara.DataAprovechamiento = JSON.parse(obj) || []; break;
        case "DataCapacitacion": ManInforme_AddEditTara.DataCapacitacion = JSON.parse(obj) || []; break;
        case "DataProduccionFruto": ManInforme_AddEditTara.DataProduccionFruto = JSON.parse(obj) || []; break;
        case "DataAprovechaForestal": ManInforme_AddEditTara.DataAprovechaForestal = JSON.parse(obj) || []; break;
        case "DataCenso": ManInforme_AddEditTara.DataCenso = JSON.parse(obj) || []; break;
        case "DataKardex": ManInforme_AddEditTara.DataKardex = JSON.parse(obj) || []; break;
    }
}

ManInforme_AddEditTara.fnReturnIndex = function (alertaInicial) {
    var url = urlLocalSigo + "Supervision/ManInforme/Index";

    if (alertaInicial == null || alertaInicial == "") {
        window.location = url;
    } else {
        window.location = url + "?_alertaIncial=" + alertaInicial;
    }
}

ManInforme_AddEditTara.fnBuscarPersona = function (_dom, _tipoPersonaSIGOsfc) {
    var url = urlLocalSigo + "General/Controles/_BuscarPersonaGeneral";
    var option = { url: url, type: 'GET', datos: { asBusGrupo: "PERSONA", asCodPTipo: _tipoPersonaSIGOsfc, asTipoPersona: "N" }, divId: "mdlBuscarPersona" };
    utilSigo.fnOpenModal(option, function () {
        _bPerGen.fnAsignarDatos = function (obj) {
            if (obj != null && obj != "") {
                var data = _bPerGen.dtBuscarPerona.row($(obj).parents('tr')).data();
                switch (_dom) {
                    case "DIRECTOR":
                        ManInforme_AddEditTara.frm.find("#hdfCodDirector").val(data["COD_PERSONA"]);
                        ManInforme_AddEditTara.frm.find("#txtDirector").val(data["PERSONA"]);
                        break;
                }
                utilSigo.fnCloseModal("mdlBuscarPersona");
            }
        }
        _bPerGen.fnInit();
    });
}

ManInforme_AddEditTara.fnViewModalUbigeo = function () {
    var url = initSigo.urlControllerGeneral + "_Ubigeo";
    var option = { url: url, type: 'POST', datos: {}, divId: "mdlControles_Ubigeo" };
    utilSigo.fnOpenModal(option, function () {
        _Ubigeo.fnSelectUbigeo = function (_ubigeoText, _ubigeoId) {
            ManInforme_AddEditTara.frm.find("#hdfCodUbigeo").val(_ubigeoId);
            ManInforme_AddEditTara.frm.find("#txtUbigeo").val(_ubigeoText);
            $("#mdlControles_Ubigeo").modal('hide');
        }
        _Ubigeo.fnLoadModalView(ManInforme_AddEditTara.frm.find("#hdfCodUbigeo").val());
    });
}

ManInforme_AddEditTara.fnInit = function () {
    $.fn.select2.defaults.set("theme", "bootstrap4");
    ManInforme_AddEditTara.frm.find("#ddlOdId").select2();

    utilSigo.fnFormatDate(ManInforme_AddEditTara.frm.find("#txtFechaEntrega"));
    utilSigo.fnFormatDate(ManInforme_AddEditTara.frm.find("#txtFechaEmision"));

    //CKEDITOR.replace('txtConclusion', {
    //    toolbar: initSigo.configuracionCKEDITOR
    //});

    if (window.ckeditorConfig) {
        console.log('init ckeditorConfig');
        DecoupledDocumentEditor.create($('#txtConclusion .editor')[0], ckeditorConfig).then(function (editor) {
            window.editor_txtConclusion = editor;
            $("#txtConclusion .toolbar-container").append(editor.ui.view.toolbar.element);
        });
    }
}

ManInforme_AddEditTara.fnSubmitForm = function () {
    var controls = ["ddlIndicadorId", "ddlOdId", "txtNumInforme", "txtFechaInicio", "txtFechaFin"];
    if (!utilSigo.fnValidateForm(ManInforme_AddEditTara.frm, controls)) {
        return ManInforme_AddEditTara.frm.valid();
    }
    ManInforme_AddEditTara.frm.submit();
}

ManInforme_AddEditTara.fnInitDataTable_Detail = function () {
    var columns_label = [], columns_data = [], options = {}, data_extend = [];

    //Tara Concepto Censo Comercial
    columns_label = ["Descripción"]; columns_data = ["DESCRIPCION"];
    data_extend = [
        {
            "data": "ESTADO_MPLANTACION", "title": "", "width": "3%", "orderable": false, "searchable": false, "mRender": function (data, type, row, meta) {
                var checked = (data == true) ? "checked" : "";
                return '<div class="custom-control custom-checkbox"><input type="checkbox" class="custom-control-input" id="chkTConceptoCenso_' + meta.row + '" ' + checked + '><label class="custom-control-label" for="chkTConceptoCenso_' + meta.row + '"></label></div>';
            }
        },
        {
            "data": "OBSERVACION", "title": "Observaciones", "width": "80%", "orderable": false, "searchable": false, "mRender": function (data, type, row, meta) {
                return '<textarea class="form-control form-control-sm" type="text" style="width:100%;" rows="3">' + data + '</textarea>';
            }
        }
    ];
    options = {
        page_length: 15, row_index: true, data_extend: data_extend, page_autowidth: false
    };
    ManInforme_AddEditTara.dtTConceptoCenso = utilDt.fnLoadDataTable_Detail(ManInforme_AddEditTara.frm.find("#tbTConceptoCenso"), columns_label, columns_data, options);
    ManInforme_AddEditTara.dtTConceptoCenso.rows.add(ManInforme_AddEditTara.DataTaraConcepto.filter(m=>m.TIPO == "CC")).draw();
    //Tara Concepto Del Aprovechamiento
    columns_label = ["Descripción"]; columns_data = ["DESCRIPCION"];
    data_extend = [
        {
            "data": "ESTADO_MPLANTACION", "title": "", "width": "3%", "orderable": false, "searchable": false, "mRender": function (data, type, row, meta) {
                var checked = (data == true) ? "checked" : "";
                return '<div class="custom-control custom-checkbox"><input type="checkbox" class="custom-control-input" id="chkTConceptoAprovecha_' + meta.row + '" ' + checked + '><label class="custom-control-label" for="chkTConceptoAprovecha_' + meta.row + '"></label></div>';
            }
        },
        {
            "data": "OBSERVACION", "title": "Observaciones", "width": "80%", "orderable": false, "searchable": false, "mRender": function (data, type, row, meta) {
                return '<textarea class="form-control form-control-sm" type="text" style="width:100%;" rows="3">' + data + '</textarea>';
            }
        }
    ];
    options = {
        page_length: 15, row_index: true, data_extend: data_extend, page_autowidth: false
    };
    ManInforme_AddEditTara.dtTConceptoAprovecha = utilDt.fnLoadDataTable_Detail(ManInforme_AddEditTara.frm.find("#tbTConceptoAprovecha"), columns_label, columns_data, options);
    ManInforme_AddEditTara.dtTConceptoAprovecha.rows.add(ManInforme_AddEditTara.DataTaraConcepto.filter(m=>m.TIPO == "AP")).draw();
    //Tara Concepto De los Impactos
    columns_label = ["Descripción"]; columns_data = ["DESCRIPCION"];
    data_extend = [
        {
            "data": "ESTADO_MPLANTACION", "title": "", "width": "3%", "orderable": false, "searchable": false, "mRender": function (data, type, row, meta) {
                var checked = (data == true) ? "checked" : "";
                return '<div class="custom-control custom-checkbox"><input type="checkbox" class="custom-control-input" id="chkTConceptoImpacto_' + meta.row + '" ' + checked + '><label class="custom-control-label" for="chkTConceptoImpacto_' + meta.row + '"></label></div>';
            }
        },
        {
            "data": "OBSERVACION", "title": "Observaciones", "width": "80%", "orderable": false, "searchable": false, "mRender": function (data, type, row, meta) {
                return '<textarea class="form-control form-control-sm" type="text" style="width:100%;" rows="3">' + data + '</textarea>';
            }
        }
    ];
    options = {
        page_length: 15, row_index: true, data_extend: data_extend, page_autowidth: false
    };
    ManInforme_AddEditTara.dtTConceptoImpacto = utilDt.fnLoadDataTable_Detail(ManInforme_AddEditTara.frm.find("#tbTConceptoImpacto"), columns_label, columns_data, options);
    ManInforme_AddEditTara.dtTConceptoImpacto.rows.add(ManInforme_AddEditTara.DataTaraConcepto.filter(m=>m.TIPO == "IP")).draw();
    //Tara Concepto Análisis
    columns_label = ["Descripción"]; columns_data = ["DESCRIPCION"];
    data_extend = [
        {
            "data": "OBSERVACION", "title": "Observaciones", "width": "80%", "orderable": false, "searchable": false, "mRender": function (data, type, row, meta) {
                return '<textarea class="form-control form-control-sm" type="text" style="width:100%;" rows="3">' + data + '</textarea>';
            }
        }
    ];
    options = {
        page_length: 15, row_index: true, data_extend: data_extend, page_autowidth: false
    };
    ManInforme_AddEditTara.dtTConceptoAnalisis = utilDt.fnLoadDataTable_Detail(ManInforme_AddEditTara.frm.find("#tbTConceptoAnalisis"), columns_label, columns_data, options);
    ManInforme_AddEditTara.dtTConceptoAnalisis.rows.add(ManInforme_AddEditTara.DataTaraConcepto.filter(m=>m.TIPO == "AN")).draw();
    //Tara Mantenimiento de la Plantación
    columns_label = ["Actividad"]; columns_data = ["DESCRIPCION"];
    data_extend = [
        {
            "data": "ESTADO_MPLANTACION", "title": "Existe", "width": "3%", "orderable": false, "searchable": false, "mRender": function (data, type, row, meta) {
                if (data) {
                    return "SI";
                }
                return "NO";
            }
        },
        {
            "data": "OBSERVACION", "title": "Observaciones", "width": "80%", "orderable": false, "searchable": false, "mRender": function (data, type, row, meta) {
                return data;
            }
        }
    ];
    options = {
        page_length: 15, row_edit: true, row_fnEdit: "ManInforme_AddEditTara.fnAddEditTara(this,'MAN_PLANTACION')"
        , row_delete: true, row_fnDelete: "ManInforme_AddEditTara.fnDeleteTara('MAN_PLANTACION',this)", row_index: true, data_extend: data_extend
    };
    ManInforme_AddEditTara.dtManPlantacion = utilDt.fnLoadDataTable_Detail(ManInforme_AddEditTara.frm.find("#tbManPlantacion"), columns_label, columns_data, options);
    ManInforme_AddEditTara.dtManPlantacion.rows.add(ManInforme_AddEditTara.DataManPlantacion).draw();
    //Tara Aprovechamiento
    columns_label = ["Predio/Área", "Árboles Supervisados", "Árboles con Fruto Verde", "Árboles con Fruto Verde y Maduro"
        , "Árboles con Flores", "Árboles sin Fruto, pero con evidencia de producción", "Observación"];
    columns_data = ["PREDIO_AREA", "N_ARBOL_SUPERVISADO", "N_ARBOL_FVERDE", "N_ARBOL_FVERDE_MADURO", "N_ARBOL_FLOR", "N_ARBOL_NOFRUTO", "OBSERVACION"];
    options = {
        page_length: 10, row_edit: true, row_fnEdit: "ManInforme_AddEditTara.fnAddEditTara(this,'APROVECHAMIENTO')"
        , row_delete: true, row_fnDelete: "ManInforme_AddEditTara.fnDeleteTara('APROVECHAMIENTO',this)", row_index: true, page_sort: true
    };
    ManInforme_AddEditTara.dtAprovechamiento = utilDt.fnLoadDataTable_Detail(ManInforme_AddEditTara.frm.find("#tbAprovechamiento"), columns_label, columns_data, options);
    ManInforme_AddEditTara.dtAprovechamiento.rows.add(ManInforme_AddEditTara.DataAprovechamiento).draw();
    //Tara Capacitación
    columns_label = ["Nombre", "Nro. Personas", "Descripción"];
    columns_data = ["NOMBRES", "NUM_PERSONA", "DESCRIPCION"];
    options = {
        page_length: 10, row_edit: true, row_fnEdit: "ManInforme_AddEditTara.fnAddEditTara(this,'CAPACITACION')"
        , row_delete: true, row_fnDelete: "ManInforme_AddEditTara.fnDeleteTara('CAPACITACION',this)", row_index: true, page_sort: true
    };
    ManInforme_AddEditTara.dtCapacitacion = utilDt.fnLoadDataTable_Detail(ManInforme_AddEditTara.frm.find("#tbCapacitacion"), columns_label, columns_data, options);
    ManInforme_AddEditTara.dtCapacitacion.rows.add(ManInforme_AddEditTara.DataCapacitacion).draw();
    //Producción Promedio de Frutos
    columns_label = ["Predio/Área", "1ra Cosecha (Kg)", "2da Cosecha (Kg)","Total Producción Anual (Kg)"];
    columns_data = ["PREDIO_AREA", "PRIMERA_COSECHA", "SEGUNDA_COSECHA", "TOTAL_PROD_ANUAL"];
    options = {
        page_length: 10, row_edit: true, row_fnEdit: "ManInforme_AddEditTara.fnAddEditTara(this,'PRODUCCION_FRUTO')"
        , row_delete: true, row_fnDelete: "ManInforme_AddEditTara.fnDeleteTara('PRODUCCION_FRUTO',this)", row_index: true, page_sort: true
    };
    ManInforme_AddEditTara.dtProduccionFruto = utilDt.fnLoadDataTable_Detail(ManInforme_AddEditTara.frm.find("#tbProduccionFruto"), columns_label, columns_data, options);
    ManInforme_AddEditTara.dtProduccionFruto.rows.add(ManInforme_AddEditTara.DataProduccionFruto).draw();
    //Del Aprovechamiento Forestal
    columns_label = ["Predio/Área","Zafra", "Prod. Árbol Productivo (Qq)", "Prod. Árbol No Productivo (Qq)", "Prod. Árbol Plantado (Qq)"
        , "Cant. Autorizada a Extraer (Qq)", "Cant. Extraída (Qq)", "Árboles Supervisados", "Cantidad Supervisado (Kg)", "Cantidad Injustificada (Kg)"];
    columns_data = ["PREDIO_AREA", "ZAFRA", "P_ARBOL_PRODUCTIVO", "P_ARBOL_NOPRODUCTIVO", "P_ARBOL_PLANTADO"
        , "CANTIDAD_AEXTRAER", "CANTIDAD_EXTRAIDA", "N_ARBOL_SUPERVISADO", "CANTIDAD_SUPERVISADO", "CANTIDAD_INJUSTIFICADA"];
    options = {
        page_length: 10, row_edit: true, row_fnEdit: "ManInforme_AddEditTara.fnAddEditTara(this,'APROVECHA_FORESTAL')"
        , row_delete: true, row_fnDelete: "ManInforme_AddEditTara.fnDeleteTara('APROVECHA_FORESTAL',this)", row_index: true, page_sort: true
    };
    ManInforme_AddEditTara.dtAprovechaForestal = utilDt.fnLoadDataTable_Detail(ManInforme_AddEditTara.frm.find("#tbAprovechaForestal"), columns_label, columns_data, options);
    ManInforme_AddEditTara.dtAprovechaForestal.rows.add(ManInforme_AddEditTara.DataAprovechaForestal).draw();
    //Registro de Árboles Supervisados (Censo)
    columns_label = ["Predio/Área", "Código Árbol", "Presencia Vainas", "Presencia Flores", "Presencia Plagas/Enfermedades"
        , "Presencia de Plantas Parasitarias", "Zona UTM", "Coordenada Este", "Coordenada Norte", "Altura Total","Observación"];
    columns_data = ["PREDIO_AREA", "CODIGO_ARBOL", "DESCRIPCION", "PRES_FLORES_TEXT", "PRES_PLAGA_ENFERMEDA"
        , "PRES_PLANTA_PARASITARIA", "ZONA", "COORDENADA_NORTE", "COORDENADA_ESTE", "ALTURA_TOTAL", "OBSERVACION"];
    options = {
        page_length: 20, row_edit: true, row_fnEdit: "ManInforme_AddEditTara.fnAddEditTara(this,'ARBOL_SUPERVISADO')"
        , row_delete: true, row_fnDelete: "ManInforme_AddEditTara.fnDeleteTara('ARBOL_SUPERVISADO',this)", row_index: true, page_sort: true
    };
    ManInforme_AddEditTara.dtCenso = utilDt.fnLoadDataTable_Detail(ManInforme_AddEditTara.frm.find("#tbCenso"), columns_label, columns_data, options);
    ManInforme_AddEditTara.dtCenso.rows.add(ManInforme_AddEditTara.DataCenso).draw();
    //Kardex de productos Forestales Diferentes a la Madera
    columns_label = ["Guía de Transporte", "Fecha Emisión", "Zafra", "Cantidad Autorizada (Qq)", "Total Sacos (Qq)"
        , "Saldo (Qq)", "Saldo (m3)", "Ubigeo Destino"];
    columns_data = ["N_GUIA_TRANSPORTE", "FECHA_EMISION", "ZAFRA", "CANTIDAD_AQUINTAL", "TOTAL_SQUINTAL"
        , "SALDO_QUINTAL", "SALDO_MTRES", "UBIGEO"];
    options = {
        page_length: 10, row_edit: true, row_fnEdit: "ManInforme_AddEditTara.fnAddEditTara(this,'KARDEX')"
        , row_delete: true, row_fnDelete: "ManInforme_AddEditTara.fnDeleteTara('KARDEX',this)", row_index: true, page_sort: true
    };
    ManInforme_AddEditTara.dtKardex = utilDt.fnLoadDataTable_Detail(ManInforme_AddEditTara.frm.find("#tbKardex"), columns_label, columns_data, options);
    ManInforme_AddEditTara.dtKardex.rows.add(ManInforme_AddEditTara.DataKardex).draw();
}

ManInforme_AddEditTara.fnAddEditTara = function (obj, _tipo) {
    var url = urlLocalSigo, dt = null, _funcModal = {}, oParams = "", columnaUnica = "";

    switch (_tipo) {
        case "MAN_PLANTACION":
            url += "Supervision/ManInformeTara/_ManPlantacion";
            dt = ManInforme_AddEditTara.dtManPlantacion; columnaUnica = "COD_TCONCEPTO"; break;
        case "APROVECHAMIENTO":
            url += "Supervision/ManInformeTara/_Aprovechamiento";
            dt = ManInforme_AddEditTara.dtAprovechamiento; break;
        case "CAPACITACION":
            url += "Supervision/ManInformeTara/_Capacitacion";
            dt = ManInforme_AddEditTara.dtCapacitacion; break;
        case "PRODUCCION_FRUTO":
            url += "Supervision/ManInformeTara/_ProduccionFruto";
            dt = ManInforme_AddEditTara.dtProduccionFruto; break;
        case "APROVECHA_FORESTAL":
            url += "Supervision/ManInformeTara/_AprovechaForestal";
            dt = ManInforme_AddEditTara.dtAprovechaForestal; break;
        case "ARBOL_SUPERVISADO":
            url += "Supervision/ManInformeTara/_ArbolSupervisado";
            dt = ManInforme_AddEditTara.dtCenso; break;
        case "KARDEX":
            url += "Supervision/ManInformeTara/_Kardex";
            dt = ManInforme_AddEditTara.dtKardex; break;
    }

    var option = { url: url, type: 'POST', datos: {}, divId: "mdlManInformeTara" };
    utilSigo.fnOpenModal(option, function () {
        switch (_tipo) {
            case "MAN_PLANTACION": _funcModal = _ManPlantacion; break;
            case "APROVECHAMIENTO": _funcModal = _Aprovechamiento; break;
            case "CAPACITACION": _funcModal = _Capacitacion; break;
            case "PRODUCCION_FRUTO": _funcModal = _ProduccionFruto; break;
            case "APROVECHA_FORESTAL": _funcModal = _AprovechaForestal; break;
            case "ARBOL_SUPERVISADO": _funcModal = _ArbolSupervisado; break;
            case "KARDEX": _funcModal = _Kardex; break;
        }

        _funcModal.fnSaveForm = function (data) {
            if (data != null) {
                if (obj == null || obj == "") {//Nuevo Registro
                    if (columnaUnica=="") {
                        dt.rows.add([data]).draw();
                        dt.page('last').draw('page');
                        utilSigo.toastSuccess("Exito", "Datos guardados correctamente");
                    } else {
                        if (!utilDt.existValorSearch(dt, columnaUnica, data[columnaUnica])) {
                            dt.rows.add([data]).draw();
                            dt.page('last').draw('page');
                            utilSigo.toastSuccess("Exito", "Datos guardados correctamente");
                        } else {
                            utilSigo.toastWarning("Aviso", "El tipo ya se encuentra registrado");
                        }
                    }
                } else {//Modificar
                    var row = dt.row($(obj).parents('tr')).data();
                    row = data;
                    dt.row($(obj).parents('tr')).data(row).draw(false);
                    utilSigo.toastSuccess("Exito", "Datos actualizados correctamente");
                }
                $("#mdlManInformeTara").modal('hide');
            } else {
                utilSigo.toastError("Error", "No se pudieron guardar los datos");
            }
        }

        if (obj != null && obj != "") {
            var data = dt.row($(obj).parents('tr')).data();
            _funcModal.fnInit(utilSigo.fnConvertArrayToObject(data), oParams);
        } else { _funcModal.fnInit("", oParams); }
    });
}
ManInforme_AddEditTara.fnDeleteTara = function (_tipo, obj, objData) {
    var dt, data;
    switch (_tipo) {
        case "MAN_PLANTACION": dt = ManInforme_AddEditTara.dtManPlantacion; break;
        case "APROVECHAMIENTO": dt = ManInforme_AddEditTara.dtAprovechamiento; break;
        case "CAPACITACION": dt = ManInforme_AddEditTara.dtCapacitacion; break;
        case "PRODUCCION_FRUTO": dt = ManInforme_AddEditTara.dtProduccionFruto; break;
        case "APROVECHA_FORESTAL": dt = ManInforme_AddEditTara.dtAprovechaForestal; break;
        case "ARBOL_SUPERVISADO": dt = ManInforme_AddEditTara.dtCenso; break;
        case "KARDEX": dt = ManInforme_AddEditTara.dtKardex; break;
    }

    data = typeof objData !== 'undefined' ? objData : dt.row($(obj).parents('tr')).data();

    if (data["RegEstado"] == "0" || data["RegEstado"] == "2") {
        switch (_tipo) {
            case "MAN_PLANTACION":
                ManInforme_AddEditTara.tbEliTABLA.push({
                    EliTABLA: "ISUPERVISION_TARA_DET_CONCEPTO",
                    COD_SECUENCIAL: data["COD_TCONCEPTO"]
                });
                break;
            case "APROVECHAMIENTO":
                ManInforme_AddEditTara.tbEliTABLA.push({
                    EliTABLA: "ISUPERVISION_TARA_DET_APROV",
                    COD_SECUENCIAL: data["COD_SECUENCIAL"]
                });
                break;
            case "CAPACITACION":
                ManInforme_AddEditTara.tbEliTABLA.push({
                    EliTABLA: "ISUPERVISION_TARA_DET_CAPACITACION",
                    COD_SECUENCIAL: data["COD_SECUENCIAL"]
                });
                break;
            case "PRODUCCION_FRUTO":
                ManInforme_AddEditTara.tbEliTABLA.push({
                    EliTABLA: "ISUPERVISION_TARA_DET_PFRUTOS",
                    COD_SECUENCIAL: data["COD_SECUENCIAL"]
                });
                break;
            case "APROVECHA_FORESTAL":
                ManInforme_AddEditTara.tbEliTABLA.push({
                    EliTABLA: "ISUPERVISION_TARA_DET_APFORESTAL",
                    COD_SECUENCIAL: data["COD_SECUENCIAL"]
                });
                break;
            case "ARBOL_SUPERVISADO":
                ManInforme_AddEditTara.tbEliTABLA.push({
                    EliTABLA: "ISUPERVISION_TARA_DET_CENSO",
                    COD_SECUENCIAL: data["COD_SECUENCIAL"]
                });
                break;
            case "KARDEX":
                ManInforme_AddEditTara.tbEliTABLA.push({
                    EliTABLA: "ISUPERVISION_TARA_DET_KARDEX",
                    COD_SECUENCIAL: data["COD_SECUENCIAL"]
                });
                break;
        }
    }
    if (typeof objData === 'undefined') {
        dt.row($(obj).parents('tr')).remove().draw(false);
    }
}
ManInforme_AddEditTara.fnDeleteAllTara = function (_tipo) {
    var dt, data;
    switch (_tipo) {
        case "MAN_PLANTACION": dt = ManInforme_AddEditTara.dtManPlantacion; break;
        case "APROVECHAMIENTO": dt = ManInforme_AddEditTara.dtAprovechamiento; break;
        case "CAPACITACION": dt = ManInforme_AddEditTara.dtCapacitacion; break;
        case "PRODUCCION_FRUTO": dt = ManInforme_AddEditTara.dtProduccionFruto; break;
        case "APROVECHA_FORESTAL": dt = ManInforme_AddEditTara.dtAprovechaForestal; break;
        case "ARBOL_SUPERVISADO": dt = ManInforme_AddEditTara.dtCenso; break;
        case "KARDEX": dt = ManInforme_AddEditTara.dtKardex; break;
    }
    if (dt.$("tr").length > 0) {
        utilSigo.dialogConfirm("", "Está seguro de Eliminar Todos los Registros?", function (r) {
            if (r) {
                $.each(dt.$("tr"), function (i, o) {
                    data = dt.row($(o)).data();
                    ManInforme_AddEditTara.fnDeleteTara(_tipo, "", data);
                });
                dt.clear().draw();
            }
        });
    } else {
        utilSigo.toastWarning("Aviso", "No se encontraron registros a eliminar");
    }
}
ManInforme_AddEditTara.fnGetListTara = function (_tipo) {
    var dt, list = [], data;
    switch (_tipo) {
        case "MAN_PLANTACION": dt = ManInforme_AddEditTara.dtManPlantacion; break;
        case "APROVECHAMIENTO": dt = ManInforme_AddEditTara.dtAprovechamiento; break;
        case "CAPACITACION": dt = ManInforme_AddEditTara.dtCapacitacion; break;
        case "PRODUCCION_FRUTO": dt = ManInforme_AddEditTara.dtProduccionFruto; break;
        case "APROVECHA_FORESTAL": dt = ManInforme_AddEditTara.dtAprovechaForestal; break;
        case "ARBOL_SUPERVISADO": dt = ManInforme_AddEditTara.dtCenso; break;
        case "KARDEX": dt = ManInforme_AddEditTara.dtKardex; break;
    }

    if (dt.$("tr").length > 0) {
        $.each(dt.$("tr"), function (i, o) {
            data = dt.row($(o)).data();
            if (data["RegEstado"] == "1" || data["RegEstado"] == "2") {
                list.push(utilSigo.fnConvertArrayToObject(data));
            }
        });
    }
    return list;
}
ManInforme_AddEditTara.fnGetListTaraConcepto = function (tipo) {
    var list = [], rows, countFilas, data, dataHtml, dt;

    switch (tipo) {
        case "TCONCEPTO_CENSO": dt = ManInforme_AddEditTara.dtTConceptoCenso; break;
        case "TCONCEPTO_APROVECHA": dt = ManInforme_AddEditTara.dtTConceptoAprovecha; break;
        case "TCONCEPTO_IMPACTO": dt = ManInforme_AddEditTara.dtTConceptoImpacto; break;
        case "TCONCEPTO_ANALISIS": dt = ManInforme_AddEditTara.dtTConceptoAnalisis; break;
    }

    rows = dt.$("tr");
    countFilas = rows.length;
    if (countFilas > 0) {
        $.each(rows, function (i, o) {
            data = dt.row($(o)).data();
            dataHtml = $(o)[0];
            if (tipo != "TCONCEPTO_ANALISIS") {
                data["ESTADO_MPLANTACION"] = $($($(dataHtml).find("td")[2]).find("input")[0]).is(":checked");
                data["OBSERVACION"] = $($($(dataHtml).find("td")[3]).find("textarea")[0]).val();
            } else {
                data["OBSERVACION"] = $($($(dataHtml).find("td")[2]).find("textarea")[0]).val();
            }
            
            list.push(utilSigo.fnConvertArrayToObject(data));
        });
    }
    return list;
}

ManInforme_AddEditTara.fnImport = function (e, obj,tipo) {
    var url = urlLocalSigo + "Supervision/ManInformeTara/ImportarDatosInformeSimpleTara";
    var dt = null;

    switch (tipo) {
        case "CENSO": dt = ManInforme_AddEditTara.dtCenso; break;
        case "KARDEX": dt = ManInforme_AddEditTara.dtKardex; break;
    }

    uploadFile.fileSelectHandler(e, obj, url, { asTipo: tipo }, function (data) {
        for (var i = 0; i < data.length; i++) {
            dt.rows.add([data[i]]).draw();
            dt.page('last').draw('page');
        }
    });
}

ManInforme_AddEditTara.fnSaveForm = function () {
    utilSigo.blockUIGeneral();
    let data = ManInforme_AddEdit.Denuncia.objDeuncia;
    var optionDenuncia = {
        url: urlLocalSigo + "Supervision/Denuncias/insertarTramiteDenuncia",
        datos: JSON.stringify(data),
        type: 'POST'
    };
    $.ajax({
        url: optionDenuncia.url,
        type: optionDenuncia.type,
        data: optionDenuncia.datos,
        contentType: (typeof optionDenuncia.contentType) === 'undefined' ? 'application/json; charset=utf-8' : optionDenuncia.contentType,
        dataType: (typeof optionDenuncia.dataType) === 'undefined' ? 'json' : optionDenuncia.dataType,
        error: utilSigo.errorAjax,
        success: function (data) { },
        complete: function () {
            var datosInforme = ManInforme_AddEditTara.frm.serializeObject();
            datosInforme.vmControlCalidad = _ControlCalidad.fnGetDatosControlCalidad();
            datosInforme.vmInfCNotificacion = _renderCNotificacion.fnGetDatosCNotificacion();
            datosInforme.vmDatoSupervision = _renderDatosSupervision.fnGetDatosSupervision();
            datosInforme.tbSupervisor = _renderSupervisor.fnGetList();
            datosInforme.tbEliTABLA = ManInforme_AddEditTara.tbEliTABLA;
            datosInforme.tbEliTABLA = datosInforme.tbEliTABLA.concat(_renderSupervisor.fnGetListEliTABLA());
            datosInforme.chkLineamientoMapa = utilSigo.fnGetValChk(ManInforme_AddEditTara.frm.find("#chkLineamientoMapa"));
            datosInforme.chkForestacion = utilSigo.fnGetValChk(ManInforme_AddEditTara.frm.find("#chkForestacion"));
            datosInforme.tbTaraConcepto = ManInforme_AddEditTara.fnGetListTaraConcepto("TCONCEPTO_CENSO");
            datosInforme.tbTaraConcepto = datosInforme.tbTaraConcepto.concat(ManInforme_AddEditTara.fnGetListTaraConcepto("TCONCEPTO_APROVECHA"));
            datosInforme.tbTaraConcepto = datosInforme.tbTaraConcepto.concat(ManInforme_AddEditTara.fnGetListTaraConcepto("TCONCEPTO_IMPACTO"));
            datosInforme.tbTaraConcepto = datosInforme.tbTaraConcepto.concat(ManInforme_AddEditTara.fnGetListTaraConcepto("TCONCEPTO_ANALISIS"));
            datosInforme.tbTaraConcepto = datosInforme.tbTaraConcepto.concat(ManInforme_AddEditTara.fnGetListTara("MAN_PLANTACION"));
            datosInforme.tbAprovechamiento = ManInforme_AddEditTara.fnGetListTara("APROVECHAMIENTO");
            datosInforme.tbCapacitacion = ManInforme_AddEditTara.fnGetListTara("CAPACITACION");
            datosInforme.tbProduccionFruto = ManInforme_AddEditTara.fnGetListTara("PRODUCCION_FRUTO");
            datosInforme.tbAprovechaForestal = ManInforme_AddEditTara.fnGetListTara("APROVECHA_FORESTAL");
            datosInforme.tbCenso = ManInforme_AddEditTara.fnGetListTara("ARBOL_SUPERVISADO");
            datosInforme.tbKardex = ManInforme_AddEditTara.fnGetListTara("KARDEX");
            datosInforme.tbObligTitular = _renderObligacionTitular.fnGetList();
            datosInforme.tbDesplazamiento = _renderDesplazamiento.fnGetList();
            datosInforme.tbEliTABLA = datosInforme.tbEliTABLA.concat(_renderDesplazamiento.fnGetListEliTABLA());
            //datosInforme.txtConclusion = CKEDITOR.instances["txtConclusion"].getData();
            datosInforme.txtConclusion = window.editor_txtConclusion.getData();

            var option = { url: ManInforme_AddEditTara.frm[0].action, datos: JSON.stringify(datosInforme), type: 'POST' };
            $.ajax({
                url: option.url,
                type: (typeof option.type) === 'undefined' ? 'GET' : option.type,
                data: (typeof option.datos) === 'undefined' ? {} : option.datos,
                contentType: (typeof option.contentType) === 'undefined' ? 'application/json; charset=utf-8' : option.contentType,
                dataType: (typeof option.dataType) === 'undefined' ? 'json' : option.dataType,
                error: utilSigo.errorAjax,
                success: function (data) {
                    if (data.success) {
                        ManInforme_AddEditTara.fnReturnIndex(data.msj);
                    }
                    else {
                        utilSigo.toastWarning("Aviso", data.msj);
                    } utilSigo.unblockUIGeneral();
                },
                statusCode: {
                    203: () => { utilSigo.unblockUIGeneral(); }
                }
            });
        },
        statusCode: { 203: () => { utilSigo.unblockUIGeneral(); } }
    });
}

ManInforme_AddEdit.validarIncidencia = function () {
    utilSigo.elementOk($('#txt_FECHA_SUCESO'));
    utilSigo.elementOk($('#txt_HORA_SUCESO'));
    utilSigo.elementOk($('#cboRIESGO'));
    utilSigo.elementOk($('#cboPROCESO'));
    utilSigo.elementOk($('#cboCIRCUNSTANCIA'));
    utilSigo.elementOk($('#txt_UBICACION'));
    utilSigo.elementOk($('#cboEFECTO'));
    utilSigo.elementOk($('#NIVEL_1'));
    utilSigo.elementOk($('#NIVEL_2'));
    utilSigo.elementOk($('#txt_DSCRP_INCIDENCIA'));
    utilSigo.elementOk($('#txt_OBSERVACIONES'));
    if ($('#txt_FECHA_SUCESO').val() === '') {
        $('.nav-tabs a[href="#navIncidencias"]').tab('show');
        utilSigo.elementERROR($('#txt_FECHA_SUCESO'), 'Ingrese Fecha Suceso');
        return false;
    }
    if ($('#txt_HORA_SUCESO').val() === '') {
        $('.nav-tabs a[href="#navIncidencias"]').tab('show');
        utilSigo.elementERROR($('#txt_HORA_SUCESO'), 'Ingrese Hora Suceso');
        return false;
    }
    if ($('#cboRIESGO').val() === '00') {
        $('.nav-tabs a[href="#navIncidencias"]').tab('show');
        utilSigo.elementERROR($('#cboRIESGO'), 'Ingrese Riesgo');
        return false;
    }
    if ($('#cboPROCESO').val() === '00') {
        $('.nav-tabs a[href="#navIncidencias"]').tab('show');
        utilSigo.elementERROR($('#cboPROCESO'), 'Ingrese Proceso');
        return false;
    }
    if ($('#cboCIRCUNSTANCIA').val() === '00') {
        $('.nav-tabs a[href="#navIncidencias"]').tab('show');
        utilSigo.elementERROR($('#cboCIRCUNSTANCIA'), 'Ingrese Circunstancia');
        return false;
    }
    if ($('#txt_UBICACION').val() === '') {
        $('.nav-tabs a[href="#navIncidencias"]').tab('show');
        utilSigo.elementERROR($('#txt_UBICACION'), 'Ingrese Ubicacion');
        return false;
    }
    if ($('#cboEFECTO').val() === '00') {
        $('.nav-tabs a[href="#navIncidencias"]').tab('show');
        utilSigo.elementERROR($('#cboEFECTO'), 'Ingrese Efecto');
        return false;
    }
    if ($('#NIVEL_1').val() === '00') {
        $('.nav-tabs a[href="#navIncidencias"]').tab('show');
        utilSigo.elementERROR($('#NIVEL_1'), 'Ingrese Nivel 1');
        return false;
    }
    if ($('#NIVEL_2').val() === '00') {
        $('.nav-tabs a[href="#navIncidencias"]').tab('show');
        utilSigo.elementERROR($('#NIVEL_2'), 'Ingrese Nivel 2');
        return false;
    }
    if ($('#txt_DSCRP_INCIDENCIA').val() === '') {
        $('.nav-tabs a[href="#navIncidencias"]').tab('show');
        utilSigo.elementERROR($('#txt_DSCRP_INCIDENCIA'), 'Ingrese Descripcion Incidencia');
        return false;
    }
    if ($('#txt_OBSERVACIONES').val() === '') {
        $('.nav-tabs a[href="#navIncidencias"]').tab('show');
        utilSigo.elementERROR($('#txt_OBSERVACIONES'), 'Ingrese Observacion');
        return false;
    }
    return true;
}

ManInforme_AddEdit.cargarIncidencias = function () {
    ManInforme_AddEdit.Incidencia.tablaIncidencia =
        $('#GridIINCIDENCIA').DataTable({
            oLanguage: initSigo.oLanguage,
            dom: 'rtip',
            bInfo: true,
            responsive: true,
            processing: true,
            bServerSide: true,
            pageLength: initSigo.pageLengthBuscar,
            sAjaxSource: urlLocalSigo + "Supervision/Denuncias/crud_Incidencia",
            "fnServerData": function (url, odata, callback) {
                let Data = {};
                let PageSize = odata[4].value;
                let PrimerRegistro = odata[3].value;
                let CurrentPage = PrimerRegistro / PageSize;
                Data.PageSize = PageSize;
                Data.CurrentPage = CurrentPage + 1;
                Data.ITipo = 4;
                Data.COD_INFORME = $('#hdfCodInforme').val();
                $.ajax({
                    "url": url,
                    "dataSrc": "",
                    "data": Data,
                    "success": function (response) {
                        callback({
                            data: response,
                            recordsTotal: response.length === 0 ? 0 : response[0].rowCount,
                            recordsFiltered: response.length === 0 ? 0 : response[0].rowCount
                        });
                    },
                    "contentType": "application/x-www-form-urlencoded; charset=utf-8",
                    "dataType": "json",
                    "type": "POST",
                    "cache": false,
                    "error": function (resultado) {
                        alert("DataTables warning: JSON data from server failed to load or be parsed. " +
                            "This is most likely to be caused by a JSON formatting error.");
                    }
                });
            },
            drawCallback: function (settings) {
                $('[data-toggle="tooltip"]').tooltip();
            },
            columns: [
                {
                    render: function (data, type, row) {
                        return row.FECHA_SUCESO + ' ' + row.HORA_SUCESO;
                    }, title: "Fecha"
                },
                {
                    render: function (data, type, row) {
                        let rpta = row.OBJCOD_IINCIDENCIA_PROTOCOLOS_RIESGO.NOMBRE_PROTOCOLO;
                        return '<a data-toggle="tooltip" data-placement="top" title="' + rpta + '">' + utilSigo.recortarTextos(rpta, 40) + '</a>';
                    }, title: "Riesgo"
                },
                {
                    render: function (data, type, row) {
                        let rpta = row.OBJCOD_IINCIDENCIA_PROTOCOLOS_PROCESO.NOMBRE_PROTOCOLO;
                        return '<a data-toggle="tooltip" data-placement="top" title="' + rpta + '">' + utilSigo.recortarTextos(rpta, 40) + '</a>';
                    }, title: "Proceso"
                },
                {
                    render: function (data, type, row) {
                        let rpta = row.OBJCOD_IINCIDENCIA_PROTOCOLOS_CIRCUNSTANCIA.NOMBRE_PROTOCOLO;
                        return '<a data-toggle="tooltip" data-placement="top" title="' + rpta + '">' + utilSigo.recortarTextos(rpta, 40) + '</a>';
                    }, title: "Circunstancia"
                }, {
                    render: function (data, type, row) {
                        let rpta = row.OBJCOD_IINCIDENCIA_PROTOCOLOS_EFECTO.NOMBRE_PROTOCOLO;
                        return '<a data-toggle="tooltip" data-placement="top" title="' + rpta + '">' + utilSigo.recortarTextos(rpta, 40) + '</a>';
                    }, title: "Efecto"
                },
                {
                    render: function (data, type, row) {
                        return '<a data-toggle="tooltip" data-placement="top" title="' + row.DSCRP_INCIDENCIA + '">' + utilSigo.recortarTextos(row.DSCRP_INCIDENCIA, 40) + '</a>';
                    }, title: "Descripcion"
                },
                {
                    render: function (data, type, row) {
                        return '<a data-toggle="tooltip" data-placement="top" title="' + row.OBSERVACIONES + '">' + utilSigo.recortarTextos(row.OBSERVACIONES, 40) + '</a>';
                    }, title: "Observacion"
                },
                {
                    render: function (data, type, row) {
                        let str = "<button class='btn btn-primary btn-xs btn-edit' type='button' " +
                            "onClick='ManInforme_AddEdit.Incidencia.Editar(" + JSON.stringify(row) + ")'>Editar</button>";
                        str += '<button class="btn btn-danger btn-xs btn-edit" type="button" ' +
                            'onClick="ManInforme_AddEdit.Incidencia.Eliminar(\'' + row.COD_IINCIDENCIA + '\')">Eliminar</button> ';

                        return str;
                    }, title: "Acciones"
                }
            ],
            columnDefs: [
                { responsivePriority: 1, targets: 0 },
                { responsivePriority: 2, targets: -2 },
                { className: "text-center", targets: "_all", orderable: false }
            ]
        });
}

ManInforme_AddEdit.fnCustomValidateForm = function () {
    ManInforme_AddEdit.Denuncia.objDeuncia.IATENDIDO = $('input[name="rbtnAtendido"]:checked').val();
    utilSigo.elementOk($('#inptExpediente'));
    if (ManInforme_AddEdit.Denuncia.objDeuncia.IATENDIDO === '1') {
        if ($('#inptExpediente').val() === '') {
            $('.nav-tabs a[href="#navDatos"]').tab('show');
            utilSigo.elementERROR($('#inptExpediente'), 'Ingrese Expediente');
            return false;
        }
        if ($.isEmptyObject(ManInforme_AddEdit.Denuncia.objDeuncia.tra_M_Tramite)) {
            $('.nav-tabs a[href="#navDatos"]').tab('show');
            utilSigo.elementERROR($('#inptExpediente'), 'Ingrese Expediente');
            return false;
        }
        if (ManInforme_AddEdit.Denuncia.objDeuncia.tra_M_Tramite.cCodificacion === '') {
            $('.nav-tabs a[href="#navDatos"]').tab('show');
            utilSigo.elementERROR($('#inptExpediente'), 'Ingrese Expediente');
            return false;
        }
    }
    if ($('#inptExpediente').val() !== '') {
        if ($.isEmptyObject(ManInforme_AddEdit.Denuncia.objDeuncia.tra_M_Tramite)) {
            $('.nav-tabs a[href="#navDatos"]').tab('show');
            utilSigo.elementERROR($('#inptExpediente'), 'Busque Expediente');
            return false;
        }
        if (ManInforme_AddEdit.Denuncia.objDeuncia.tra_M_Tramite.cCodificacion === '') {
            $('.nav-tabs a[href="#navDatos"]').tab('show');
            utilSigo.elementERROR($('#inptExpediente'), 'Busque Expediente');
            return false;
        }
    }
    return true;
}

$(document).ready(function () {
    ManInforme_AddEditTara.frm = $("#frmManInforme_AddEditTara");

    ManInforme_AddEditTara.fnInit();
    ManInforme_AddEditTara.fnInitDataTable_Detail();

    //=====-----Para el registro de datos del formulario-----=====
    //Validación personalizada
    jQuery.validator.addMethod("invalidManInf_AddEditTara", function (value, element) {
        switch ($(element).attr('id')) {
            case 'ddlIndicadorId':
            case 'ddlOdId':
                return (value == '0000000') ? false : true;
                break
        }
    });
    ManInforme_AddEditTara.frm.validate(utilSigo.fnValidate({
        rules: {
            ddlIndicadorId: { invalidManInf_AddEditTara: true },
            ddlOdId: { invalidManInf_AddEditTara: true },
            txtNumInforme: { required: true },
            txtFechaInicio: { required: true },
            txtFechaFin: { required: true }
        },
        messages: {
            ddlIndicadorId: { invalidManInf_AddEditTara: "Seleccione el estado actual del registro" },
            ddlOdId: { invalidManInf_AddEditTara: "Seleccione la oficina desconcentrada" },
            txtNumInforme: { required: "Ingrese el número del informe de supervisión" },
            txtFechaInicio: { required: "Seleccione la fecha de inicio de la supervisión" },
            txtFechaFin: { required: "Seleccione la fecha fin de la supervisión" }
        },
        fnSubmit: function (form) {
            if (ManInforme_AddEdit.fnCustomValidateForm()) {
                utilSigo.dialogConfirm('', 'Desea continuar con el registro?', function (r) {
                    if (r) {
                        ManInforme_AddEditTara.fnSaveForm();
                    }
                });
            }
        }
    }));
    //Validación de controles que usan Select2
    ManInforme_AddEditTara.frm.find("select.select2-hidden-accessible").on("change", function (e) {
        $(this).valid();
    });
    ManInforme_AddEdit.cargarIncidencias();
    ManInforme_AddEdit.Denuncia.obtenerDenuncia();
    //eventos
    $('#BtnGuardar').click(function () {
        if (ManInforme_AddEdit.validarIncidencia()) {
            let obj = {
                ITipo: $('#COD_IINCIDENCIA').val() === '0' ? 1 : 2,
                COD_IINCIDENCIA: $('#COD_IINCIDENCIA').val(),
                COD_INFORME: $('#hdfCodInforme').val(),
                FECHA_SUCESO: $('#txt_FECHA_SUCESO').val(),
                HORA_SUCESO: $('#txt_HORA_SUCESO').val(),
                COD_IINCIDENCIA_PROTOCOLOS_RIESGO: $('#cboRIESGO').val(),
                COD_IINCIDENCIA_PROTOCOLOS_PROCESO: $('#cboPROCESO').val(),
                COD_IINCIDENCIA_PROTOCOLOS_CIRCUNSTANCIA: $('#cboCIRCUNSTANCIA').val(),
                UBICACION: $('#txt_UBICACION').val(),
                COD_IINCIDENCIA_PROTOCOLOS_EFECTO: $('#cboEFECTO').val(),
                COD_IINCIDENCIA_PROTOCOLOS_NIVEL_1: $('#NIVEL_1').val(),
                COD_IINCIDENCIA_PROTOCOLOS_NIVEL_2: $('#NIVEL_2').val(),
                DSCRP_INCIDENCIA: $('#txt_DSCRP_INCIDENCIA').val(),
                OBSERVACIONES: $('#txt_OBSERVACIONES').val()
            }
            var option = {
                url: urlLocalSigo + "Supervision/Denuncias/crud_Incidencia",
                datos: JSON.stringify(obj),
                type: 'POST'
            };
            utilSigo.fnAjax(option, function (data) {
                if (data.COD_IINCIDENCIA != '0') {
                    ManInforme_AddEdit.Incidencia.tablaIncidencia.ajax.reload();
                    ManInforme_AddEdit.Incidencia.limpiar();
                    $('#BtnGuardar').text('GUARDAR');
                };
            });
        }
    });
    $('#BtnLimpiar').click(function () {
        ManInforme_AddEdit.Incidencia.limpiar();
    });
    $('#BtnExportar').click(function () {
        var url = urlLocalSigo + "Supervision/Denuncias/ExportarTablaIncidencia";
        var option = {
            url: url,
            datos: JSON.stringify({
                ITipo: 5,
                COD_INFORME: $('#hdfCodInforme').val()
            }),
            type: 'POST'
        };

        utilSigo.fnAjax(option, function (data) {
            if (data.success) {
                document.location = urlLocalSigo + "Archivos/Incidencia/" + data.msj;
            }
            else {
                utilSigo.toastWarning("Aviso", "Sucedio un error, Comuníquese con el Administrador");
                console.log(data.msj);
            }
        });
    });
    ManInforme_AddEdit.Denuncia.objDeuncia.ENT_INFORME.COD_INFORME = $('#hdfCodInforme').val().trim();
    ManInforme_AddEdit.Incidencia.ui();
    ManInforme_AddEdit.Incidencia.eventos();
});