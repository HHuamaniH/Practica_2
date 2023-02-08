"use strict";

var ManInforme_AddEdit = {};
/*Variables globales*/
ManInforme_AddEdit.tbEliTABLA = [];

ManInforme_AddEdit.Denuncia =  {
    objDeuncia: {
        tra_M_Tramite: {
            cCodificacion:''
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
        $('#txt_FECHA_SUCESO').val(row.FECHA_SUCESO.split('/')[2] + '-' + row.FECHA_SUCESO.split('/')[1] + '-' +row.FECHA_SUCESO.split('/')[0]);
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
    cargarData: function (str,select,padre) {
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
                    $('#' + select).append('<option '+x+'title="' + item.NOMBRE_PROTOCOLO + '"  value="' + item.COD_IINCIDENCIA_PROTOCOLOS + '">' + utilSigo.recortarTextos(item.NOMBRE_PROTOCOLO,40) + '</option>');
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
        ManInforme_AddEdit.Incidencia.cargarData('RIESGO','cboRIESGO');
        ManInforme_AddEdit.Incidencia.cargarData('PROCESO', 'cboPROCESO');
        ManInforme_AddEdit.Incidencia.cargarData('CIRCUNSTANCIA', 'cboCIRCUNSTANCIA');
        ManInforme_AddEdit.Incidencia.cargarData('EFECTO', 'cboEFECTO');
        $('#NIVEL_1').val('00');
        $('#NIVEL_2').val('00');
    },
    eventos: function () {

        $('#cboRIESGO').change(function () {
            ManInforme_AddEdit.Incidencia.cargarData('NIVEL 2', 'NIVEL_2',$(this).val());
            ManInforme_AddEdit.Incidencia.cargarData('NIVEL 1', 'NIVEL_1', $(this).val());
        });

        $('#BtnGuardar').click(function () {
            if (ManInforme_AddEdit.Incidencia.validarIncidencia()) {
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
    },
    cargarIncidencias : function () {
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
                            console.log(resultado);
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
    },
    validarIncidencia : function () {
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
}

ManInforme_AddEdit.fnReturnIndex = function (alertaInicial) {
    var url = urlLocalSigo + "Supervision/ManInforme/Index";

    if (alertaInicial == null || alertaInicial == "") {
        window.location = url;
    } else {
        window.location = url + "?_alertaIncial=" + alertaInicial;
    }
}

ManInforme_AddEdit.fnDownloadDatosInforme = function () {
    var url = urlLocalSigo + "Supervision/ManInforme/DescargarDatosInforme?asCodInforme="+ManInforme_AddEdit.frm.find("#hdfCodInforme").val();
    //window.open(url, "_blank");
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
                        ManInforme_AddEdit.frm.find("#txtDirector").val(data["PERSONA"]);
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

ManInforme_AddEdit.fnViewModalUbigeo = function () {
    var url = initSigo.urlControllerGeneral + "_Ubigeo";
    var option = { url: url, type: 'POST', datos: {}, divId: "mdlControles_Ubigeo" };
    utilSigo.fnOpenModal(option, function () {
        _Ubigeo.fnSelectUbigeo = function (_ubigeoText, _ubigeoId) {
            ManInforme_AddEdit.frm.find("#hdfCodUbigeo").val(_ubigeoId);
            ManInforme_AddEdit.frm.find("#txtUbigeo").val(_ubigeoText);
            $("#mdlControles_Ubigeo").modal('hide');
        }
        _Ubigeo.fnLoadModalView(ManInforme_AddEdit.frm.find("#hdfCodUbigeo").val());
    }, function () {
        if (!utilSigo.fnValidateForm_HideControl(ManInforme_AddEdit.frm, ManInforme_AddEdit.frm.find("#hdfCodUbigeo"), ManInforme_AddEdit.frm.find("#iconUbigeo"), false)) return false;
        return true;
    }
);}

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
    if (!utilSigo.fnValidateForm_HideControl(ManInforme_AddEdit.frm, ManInforme_AddEdit.frm.find("#hdfCodUbigeo"), ManInforme_AddEdit.frm.find("#iconUbigeo"), false)) return false;
    return true;
}

ManInforme_AddEdit.fnInit = function () {
    $.fn.select2.defaults.set("theme", "bootstrap4");
    ManInforme_AddEdit.frm.find("#ddlOdId").select2();
    ManInforme_AddEdit.frm.find("#ddlRealizadoVeedorId").select2({ minimumResultsForSearch: -1 });

    utilSigo.fnFormatDate(ManInforme_AddEdit.frm.find("#txtFechaEntrega"));

    //CKEDITOR.replace('txtConclusion', {
    //    toolbar: initSigo.configuracionCKEDITOR
    //});
    //ckeditorConfig esta definido en _InformeDigital.cshtml
    if (window.ckeditorConfig) {
        DecoupledDocumentEditor.create($('#txtConclusion .editor')[0], ckeditorConfig).then(function (editor) {
            window.editor_txtConclusion = editor;
            $("#txtConclusion .toolbar-container").append(editor.ui.view.toolbar.element);
        });
    }

    ManInforme_AddEdit.frm.find("#dvRealizaVeedorForest").hide();
    if (ManInforme_AddEdit.frm.find("#hdfCodMTipo").val() == "0000015") {//Mostrar solo en CCNN
        ManInforme_AddEdit.frm.find("#dvRealizaVeedorForest").show();
    }
}

ManInforme_AddEdit.fnSubmitForm = function () {
    var controls = ["ddlIndicadorId", "ddlOdId", "txtNumInforme", "txtFechaInicio", "txtFechaFin"];
    if (!utilSigo.fnValidateForm(ManInforme_AddEdit.frm, controls)) {
        return ManInforme_AddEdit.frm.valid();
    }

    ManInforme_AddEdit.frm.submit();
}

ManInforme_AddEdit.fnSaveForm = function () {
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
        contentType: typeof optionDenuncia.contentType === 'undefined' ? 'application/json; charset=utf-8' : optionDenuncia.contentType,
        dataType: typeof optionDenuncia.dataType === 'undefined' ? 'json' : optionDenuncia.dataType,
        error: utilSigo.errorAjax,
        success: function (data) { },
        complete: function () {
            var datosInforme = ManInforme_AddEdit.frm.serializeObject();
            datosInforme.vmInfCNotificacion = {};
            datosInforme.vmControlCalidad = _ControlCalidad.fnGetDatosControlCalidad();
            datosInforme.chkPublicar = utilSigo.fnGetValChk(ManInforme_AddEdit.frm.find("#chkPublicar"));
            datosInforme.vmInfCNotificacion = _renderCNotificacion.fnGetDatosCNotificacion();
            datosInforme.chkPlanAmazonas = utilSigo.fnGetValChk(ManInforme_AddEdit.frm.find("#chkPlanAmazonas"));
            datosInforme.chkPlanAmazonas2014 = utilSigo.fnGetValChk(ManInforme_AddEdit.frm.find("#chkPlanAmazonas2014"));
            datosInforme.chkPlanAmazonas2015 = utilSigo.fnGetValChk(ManInforme_AddEdit.frm.find("#chkPlanAmazonas2015"));
            datosInforme.chkPlanAmazonas2016 = utilSigo.fnGetValChk(ManInforme_AddEdit.frm.find("#chkPlanAmazonas2016"));            
			datosInforme.txtConclusion = window.editor_txtConclusion.getData();//CKEDITOR.instances["txtConclusion"].getData();
            datosInforme.vmDatoSupervision = _renderDatosSupervision.fnGetDatosSupervision();
            datosInforme.ddlBuenDesempenioId = (datosInforme.ddlBuenDesempenioId == "Seleccionar") ? "1" : datosInforme.ddlBuenDesempenioId;
            datosInforme.ddlArchivaInformeId = (datosInforme.ddlArchivaInformeId == "Seleccionar") ? "-1" : datosInforme.ddlArchivaInformeId;

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
            
            var option = { url: ManInforme_AddEdit.frm.action, datos: JSON.stringify({ dto: datosInforme }), type: 'POST' };
            $.ajax({
                url: option.url,
                type: typeof option.type === 'undefined' ? 'GET' : option.type,
                data: typeof option.datos === 'undefined' ? {} : option.datos,
                contentType: typeof option.contentType === 'undefined' ? 'application/json; charset=utf-8' : option.contentType,
                dataType: typeof option.dataType === 'undefined' ? 'json' : option.dataType,
                error: utilSigo.errorAjax,
                success: function (data) {
                    if (data.success) {
                        ManInforme_AddEdit.fnReturnIndex('');
                        utilSigo.toastSuccess("Aviso", data.msj);
                    }
                    else {
                        utilSigo.toastWarning("Aviso", data.msj);
                        console.log(data.msjError);
                    } utilSigo.unblockUIGeneral();
                },
                statusCode: {
                    203: () => { utilSigo.unblockUIGeneral(); }
                }
            });
        },
        statusCode: { 203: () => { utilSigo.unblockUIGeneral(); } }
    });
};

ManInforme_AddEdit.fnViewModalExpedientes = function () {
    var url = urlLocalSigo + "Supervision/ManInforme/modalExpediente";
    var option = {
        url: url,
        type: 'GET',
        datos: {},
        divId: "mdlManInforme_Expedientes"
    };
    utilSigo.fnOpenModal(option, function () {

    }, function () {
    });
};

$(document).ready(function () {

    ManInforme_AddEdit.frm = $("#frmManInforme_AddEdit");
    ManInforme_AddEdit.fnInit();
    $('[data-toggle="tooltip"]').tooltip();
   

    ManInforme_AddEdit.frm.find("#dvObligacionContractual").hide();
    if (ManInforme_AddEdit.frm.find("#hdfCodDLinea").val() == "0000005") {//CONCESIONES
        ManInforme_AddEdit.frm.find("#dvObligacionContractual").show();
    }

    //=====-----Para el registro de datos del formulario-----=====
    //Validación personalizada
    jQuery.validator.addMethod("invalidManInf_AddEdit", function (value, element) {
        switch ($(element).attr('id')) {
            case 'ddlIndicadorId':
            case 'ddlOdId':
                return (value === '0000000') ? false : true;
            // break;
        }
    });

    ManInforme_AddEdit.frm.validate(utilSigo.fnValidate({
        rules: {
            ddlIndicadorId: { invalidManInf_AddEdit: true },
            ddlOdId: { invalidManInf_AddEdit: true },
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
    }));

    //Validación de controles que usan Select2
    ManInforme_AddEdit.frm.find("select.select2-hidden-accessible").on("change", function (e) {
        $(this).valid();
    });

    // $("#ddlIndicadorId").prop("disabled", "disabled");

    // DENUNCIAS E INCIDENCIAS
    ManInforme_AddEdit.Denuncia.objDeuncia.ENT_INFORME.COD_INFORME = $('#hdfCodInforme').val().trim();
    ManInforme_AddEdit.Denuncia.obtenerDenuncia();
    ManInforme_AddEdit.Incidencia.cargarIncidencias();
    ManInforme_AddEdit.Incidencia.ui();
    ManInforme_AddEdit.Incidencia.eventos();
});

