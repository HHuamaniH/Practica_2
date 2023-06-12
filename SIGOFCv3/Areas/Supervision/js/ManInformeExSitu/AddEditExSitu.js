"use strict";

var ManInforme_AddEditExSitu = {};
/*Variables globales*/
ManInforme_AddEditExSitu.tbEliTABLA = [];
ManInforme_AddEditExSitu.DataInfraestructuraArea = [];
ManInforme_AddEditExSitu.DataGrupoTaxonomico = [];
ManInforme_AddEditExSitu.DataRelPerCentroCria = [];
ManInforme_AddEditExSitu.DataEquipoContFisico = [];
ManInforme_AddEditExSitu.DataEquipoContQuimico = [];
ManInforme_AddEditExSitu.DataEquipoLimpieza = [];
ManInforme_AddEditExSitu.DataMaterialDesinfeccion = [];
ManInforme_AddEditExSitu.DataEquipoDesinfeccion = [];
ManInforme_AddEditExSitu.DataControlPlaga = [];
ManInforme_AddEditExSitu.DataManejoRegistro = [];
ManInforme_AddEditExSitu.DataEnriquecimientoAmb = [];
ManInforme_AddEditExSitu.DataEspecieReprod = [];
ManInforme_AddEditExSitu.DataEspecieCapturada = [];
ManInforme_AddEditExSitu.DataTraslocEspec = [];
ManInforme_AddEditExSitu.DataCapacitacion = [];
ManInforme_AddEditExSitu.DataEspecieNacimiento = [];
ManInforme_AddEditExSitu.DataEspecieEgreso = [];
ManInforme_AddEditExSitu.DataEspecieCenso = [];
ManInforme_AddEditExSitu.DataActEducacion = [];
ManInforme_AddEditExSitu.DataActInvestigacion = [];
ManInforme_AddEditExSitu.DataEvalZoObservatorio = [];
ManInforme_AddEditExSitu.DataBalanceIngEgr = [];

ManInforme_AddEditExSitu.Denuncia = {
    objDeuncia: {
        tra_M_Tramite: {
            cCodificacion: ''
        },
        COD_IDENUNCIA: '',
        ENT_INFORME: {
            COD_INFORME: ''            
        },        
        IATENDIDO: ''
        
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
        if (ManInforme_AddEditExSitu.Denuncia.objDeuncia.tra_M_Tramite.cCodificacion !== undefined) {
            if (ManInforme_AddEditExSitu.Denuncia.objDeuncia.tra_M_Tramite.cCodificacion.trim() === cCodificacion) {
                utilSigo.toastWarning("Aviso", "N° Tramite STID Asignado en este proyecto");
            } else {
                utilSigo.fnAjax(option, function (response) {
                    if (response.iCodTramite !== -1) {
                        utilSigo.toastSuccess("Aviso", "N° Tramite STID Encontrado")
                        ManInforme_AddEditExSitu.Denuncia.objDeuncia.tra_M_Tramite = response;
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
                if (response.iCodTramite !== -1) {
                    utilSigo.toastSuccess("Aviso", "N° Tramite STID Encontrado")
                    ManInforme_AddEditExSitu.Denuncia.objDeuncia.tra_M_Tramite = response;
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
            $('#rbtnAtendido1').prop('checked', false);
            $('#rbtnAtendido2').prop('checked', false);
            $('#rbtnAtendido3').prop('checked', false);
            $('.responseError').hide();
            $('.responseOk').hide();
            ManInforme_AddEditExSitu.Denuncia.objDeuncia.tra_M_Tramite = {};
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
                ManInforme_AddEditExSitu.Denuncia.objDeuncia.tra_M_Tramite = data.tra_M_Tramite;
                $('#inptExpediente').val(ManInforme_AddEditExSitu.Denuncia.objDeuncia.tra_M_Tramite.cCodificacion);
                $('.responseOk').show();
                $('.responseError').hide();
            }
            ManInforme_AddEditExSitu.Denuncia.objDeuncia.COD_IDENUNCIA = data.COD_IDENUNCIA;
            
            if (data.IATENDIDO === 1) {
                $('#rbtnAtendido1').prop('checked', true);
            } else if (data.IATENDIDO === 2) {
                $('#rbtnAtendido2').prop('checked', true);
            } else if (data.IATENDIDO === 3) {
                $('#rbtnAtendido3').prop('checked', true);
            }
        });
    }
};

ManInforme_AddEditExSitu.Incidencia = {
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
                        ManInforme_AddEditExSitu.Incidencia.tablaIncidencia.ajax.reload();
                        ManInforme_AddEditExSitu.Incidencia.limpiar();
                    }
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
                $('#NIVEL_1').val((h1 === '' ? '00' : h1));
                let h2 = $('#h2').val();
                $('#NIVEL_2').val((h2 === '' ? '00' : h2));

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
        ManInforme_AddEditExSitu.Incidencia.cargarData('RIESGO', 'cboRIESGO');
        ManInforme_AddEditExSitu.Incidencia.cargarData('PROCESO', 'cboPROCESO');
        ManInforme_AddEditExSitu.Incidencia.cargarData('CIRCUNSTANCIA', 'cboCIRCUNSTANCIA');
        ManInforme_AddEditExSitu.Incidencia.cargarData('EFECTO', 'cboEFECTO');
        $('#NIVEL_1').val('00');
        $('#NIVEL_2').val('00');
    },
    eventos: function () {

        $('#cboRIESGO').change(function () {
            ManInforme_AddEditExSitu.Incidencia.cargarData('NIVEL 2', 'NIVEL_2', $(this).val());
            ManInforme_AddEditExSitu.Incidencia.cargarData('NIVEL 1', 'NIVEL_1', $(this).val());
        });

        $('#BtnGuardar').click(function () {
            if (ManInforme_AddEditExSitu.Incidencia.validarIncidencia()) {
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
                };
                var option = {
                    url: urlLocalSigo + "Supervision/Denuncias/crud_Incidencia",
                    datos: JSON.stringify(obj),
                    type: 'POST'
                };
                utilSigo.fnAjax(option, function (data) {
                    if (data.COD_IINCIDENCIA != '0') {
                        ManInforme_AddEditExSitu.Incidencia.tablaIncidencia.ajax.reload();
                        ManInforme_AddEditExSitu.Incidencia.limpiar();
                        $('#BtnGuardar').text('GUARDAR');
                    };
                });
            }
        });

        $('#BtnLimpiar').click(function () {
            ManInforme_AddEditExSitu.Incidencia.limpiar();
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
    cargarIncidencias: function () {
        ManInforme_AddEditExSitu.Incidencia.tablaIncidencia =
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
                                "onClick='ManInforme_AddEditExSitu.Incidencia.Editar(" + JSON.stringify(row) + ")'>Editar</button>";
                            str += '<button class="btn btn-danger btn-xs btn-edit" type="button" ' +
                                'onClick="ManInforme_AddEditExSitu.Incidencia.Eliminar(\'' + row.COD_IINCIDENCIA + '\')">Eliminar</button> ';

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
    validarIncidencia: function () {
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
};

ManInforme_AddEditExSitu.fnLoadData = function (obj, tipo) {
    switch (tipo) {
        case "DataInfrArea": ManInforme_AddEditExSitu.DataInfraestructuraArea = JSON.parse(obj) || []; break;
        case "DataCautGrupoTaxo": ManInforme_AddEditExSitu.DataGrupoTaxonomico = JSON.parse(obj) || []; break;
        case "DataCautEqContFisica": ManInforme_AddEditExSitu.DataEquipoContFisico = JSON.parse(obj) || []; break;
        case "DataCautEqContQuimica": ManInforme_AddEditExSitu.DataEquipoContQuimico = JSON.parse(obj) || []; break;
        case "DataCautEqLimpieza": ManInforme_AddEditExSitu.DataEquipoLimpieza = JSON.parse(obj) || []; break;
        case "DataCautMatDesinfeccion": ManInforme_AddEditExSitu.DataMaterialDesinfeccion = JSON.parse(obj) || []; break;
        case "DataCautEqDesinfeccion": ManInforme_AddEditExSitu.DataEquipoDesinfeccion = JSON.parse(obj) || []; break;
        case "DataCautControlPlaga": ManInforme_AddEditExSitu.DataControlPlaga = JSON.parse(obj) || []; break;
        case "DataCautManRegistro": ManInforme_AddEditExSitu.DataManejoRegistro = JSON.parse(obj) || []; break;
        case "DataCautEnriquecimientoAmb": ManInforme_AddEditExSitu.DataEnriquecimientoAmb = JSON.parse(obj) || []; break;
        case "DataCautEspecieReprod": ManInforme_AddEditExSitu.DataEspecieReprod = JSON.parse(obj) || []; break;
        case "DataCautTraslocEspec": ManInforme_AddEditExSitu.DataTraslocEspec = JSON.parse(obj) || []; break;
        case "DataCautEspecieCapturada": ManInforme_AddEditExSitu.DataEspecieCapturada = JSON.parse(obj) || []; break;
        case "DataCautCapacitacion": ManInforme_AddEditExSitu.DataCapacitacion = JSON.parse(obj) || []; break;
        case "DataCautEspecieNacimiento": ManInforme_AddEditExSitu.DataEspecieNacimiento = JSON.parse(obj) || []; break;
        case "DataCautEspecieEgreso": ManInforme_AddEditExSitu.DataEspecieEgreso = JSON.parse(obj) || []; break;
        case "DataCautEspecieCenso": ManInforme_AddEditExSitu.DataEspecieCenso = JSON.parse(obj) || []; break;
        case "DataCautActEducacion": ManInforme_AddEditExSitu.DataActEducacion = JSON.parse(obj) || []; break;
        case "DataCautActInvestigacion": ManInforme_AddEditExSitu.DataActInvestigacion = JSON.parse(obj) || []; break;
        case "DataEvalZoObservatorio": ManInforme_AddEditExSitu.DataEvalZoObservatorio = JSON.parse(obj) || []; break;
        case "DataCautBalanceIngEgr": ManInforme_AddEditExSitu.DataBalanceIngEgr = JSON.parse(obj) || []; break;
        case "DataRelPelCentroCria": ManInforme_AddEditExSitu.DataRelPerCentroCria = JSON.parse(obj) || []; break;        
    }
}

ManInforme_AddEditExSitu.fnReturnIndex = function (alertaInicial) {
    var url = urlLocalSigo + "Supervision/ManInforme/Index";

    if (alertaInicial == null || alertaInicial == "") {
        window.location = url;
    } else {
        window.location = url + "?_alertaIncial=" + alertaInicial;
    }
}

ManInforme_AddEditExSitu.fnShowObsPublicar = function () {
    ManInforme_AddEditExSitu.frm.find("#dvObsPublicar").hide();
    if (!Boolean(parseInt(ManInforme_AddEditExSitu.frm.find('input[name="chkPublicar"]:checked').val()))) {
        ManInforme_AddEditExSitu.frm.find("#dvObsPublicar").show();
    }
}
ManInforme_AddEditExSitu.fnShowDatosLicFuncionamiento = function () {
    ManInforme_AddEditExSitu.frm.find("#dvDatosLicFuncionamiento").hide();
    if (ManInforme_AddEditExSitu.frm.find("#chkLicFuncionamiento").is(":checked")) {
        ManInforme_AddEditExSitu.frm.find("#dvDatosLicFuncionamiento").show();
    }
}
ManInforme_AddEditExSitu.fnShowDatosRegente = function () {
    ManInforme_AddEditExSitu.frm.find(".dvDatosRegente").hide();
    if (ManInforme_AddEditExSitu.frm.find("#chkRegente").is(":checked")) {
        ManInforme_AddEditExSitu.frm.find(".dvDatosRegente").show();
    }
}

ManInforme_AddEditExSitu.fnViewModalUbigeo = function () {
    var url = initSigo.urlControllerGeneral + "_Ubigeo";
    var option = { url: url, type: 'POST', datos: {}, divId: "mdlControles_Ubigeo" };
    utilSigo.fnOpenModal(option, function () {
        _Ubigeo.fnSelectUbigeo = function (_ubigeoText, _ubigeoId) {
            ManInforme_AddEditExSitu.frm.find("#hdfCodUbigeo").val(_ubigeoId);
            ManInforme_AddEditExSitu.frm.find("#txtUbigeo").val(_ubigeoText);
            $("#mdlControles_Ubigeo").modal('hide');
        }
        _Ubigeo.fnLoadModalView(ManInforme_AddEditExSitu.frm.find("#hdfCodUbigeo").val());
    }
    );
}

ManInforme_AddEditExSitu.fnBuscarPersona = function (_dom, _tipoPersonaSIGOsfc) {
    var url = urlLocalSigo + "General/Controles/_BuscarPersonaGeneral";
    var option = { url: url, type: 'GET', datos: { asBusGrupo: "PERSONA", asCodPTipo: _tipoPersonaSIGOsfc, asTipoPersona: "N" }, divId: "mdlBuscarPersona" };
    utilSigo.fnOpenModal(option, function () {
        _bPerGen.fnAsignarDatos = function (obj) {
            if (obj != null && obj != "") {
                var data = _bPerGen.dtBuscarPerona.row($(obj).parents('tr')).data();
                switch (_dom) {
                    case "REGENTE":
                        ManInforme_AddEditExSitu.frm.find("#hdfCodRegente").val(data["COD_PERSONA"]);
                        ManInforme_AddEditExSitu.frm.find("#txtRegente").val(data["PERSONA"]);
                        break;
                    case "RESPONSABLE":
                        ManInforme_AddEditExSitu.frm.find("#hdfCodResponsable").val(data["COD_PERSONA"]);
                        ManInforme_AddEditExSitu.frm.find("#txtResponsable").val(data["PERSONA"]);
                        break;
                }
                utilSigo.fnCloseModal("mdlBuscarPersona");
            }
        }
        _bPerGen.fnInit();
    });
}

/*SECCIÓN Infraestructura - Área*/
ManInforme_AddEditExSitu.fnAddEditArea = function (asCodArea, obj) {
    var url = urlLocalSigo + "Supervision/ManInformeExSitu/_AreaExSitu";
    var option = { url: url, type: 'POST', datos: {}, divId: "mdlManInforme_AreaExSitu" };
    var dt;
    switch (asCodArea) {
        case "0000001": dt = ManInforme_AddEditExSitu.dtInfrArea_Exhibicion; break;
        case "0000002": dt = ManInforme_AddEditExSitu.dtInfrArea_Crianza; break;
        case "0000003": dt = ManInforme_AddEditExSitu.dtInfrArea_Preparacion; break;
        case "0000004": dt = ManInforme_AddEditExSitu.dtInfrArea_Almacen; break;
        case "0000005": dt = ManInforme_AddEditExSitu.dtInfrArea_Topico; break;
        case "0000006": dt = ManInforme_AddEditExSitu.dtInfrArea_Cuarentena; break;
    }

    utilSigo.fnOpenModal(option, function () {
        _AreaExSitu.fnSaveForm = function (data, data_eli) {
            if (data != null) {
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
                ManInforme_AddEditExSitu.tbEliTABLA = ManInforme_AddEditExSitu.tbEliTABLA.concat(data_eli);
                $("#mdlManInforme_AreaExSitu").modal('hide');
            } else {
                utilSigo.toastError("Error", "No se pudieron guardar los datos");
            }
        }

        if (obj != null && obj != "") {
            var data = dt.row($(obj).parents('tr')).data();

            _AreaExSitu.fnInit(asCodArea, utilSigo.fnConvertArrayToObject(data));
        } else { _AreaExSitu.fnInit(asCodArea, ""); }
    });
}
ManInforme_AddEditExSitu.fnDeleteAllArea = function (asCodArea) {
    var dt, data;
    switch (asCodArea) {
        case "0000001": dt = ManInforme_AddEditExSitu.dtInfrArea_Exhibicion; break;
        case "0000002": dt = ManInforme_AddEditExSitu.dtInfrArea_Crianza; break;
        case "0000003": dt = ManInforme_AddEditExSitu.dtInfrArea_Preparacion; break;
        case "0000004": dt = ManInforme_AddEditExSitu.dtInfrArea_Almacen; break;
        case "0000005": dt = ManInforme_AddEditExSitu.dtInfrArea_Topico; break;
        case "0000006": dt = ManInforme_AddEditExSitu.dtInfrArea_Cuarentena; break;
    }
    if (dt.$("tr").length > 0) {
        utilSigo.dialogConfirm("", "Está seguro de Eliminar Todos los Registros?", function (r) {
            if (r) {
                $.each(dt.$("tr"), function (i, o) {
                    data = dt.row($(o)).data();
                    if (data["RegEstado"] == "0" || data["RegEstado"] == "2") {
                        ManInforme_AddEditExSitu.tbEliTABLA.push({
                            EliTABLA: "AREA_RECINTO",
                            COD_PERSONA: data["COD_AREA"],
                            COD_SECUENCIAL: data["COD_SECUENCIAL"]
                        });
                    }
                });
                dt.clear().draw();
            }
        });
    } else {
        utilSigo.toastWarning("Aviso", "No se encontraron registros a eliminar");
    }
}
ManInforme_AddEditExSitu.fnDeleteArea = function (asCodArea, obj) {
    var dt, data;
    switch (asCodArea) {
        case "0000001": dt = ManInforme_AddEditExSitu.dtInfrArea_Exhibicion; break;
        case "0000002": dt = ManInforme_AddEditExSitu.dtInfrArea_Crianza; break;
        case "0000003": dt = ManInforme_AddEditExSitu.dtInfrArea_Preparacion; break;
        case "0000004": dt = ManInforme_AddEditExSitu.dtInfrArea_Almacen; break;
        case "0000005": dt = ManInforme_AddEditExSitu.dtInfrArea_Topico; break;
        case "0000006": dt = ManInforme_AddEditExSitu.dtInfrArea_Cuarentena; break;
    }
    data = dt.row($(obj).parents('tr')).data();

    if (data["RegEstado"] == "0" || data["RegEstado"] == "2") {
        ManInforme_AddEditExSitu.tbEliTABLA.push({
            EliTABLA: "AREA_RECINTO",
            COD_PERSONA: data["COD_AREA"],
            COD_SECUENCIAL: data["COD_SECUENCIAL"]
        });
    }
    dt.row($(obj).parents('tr')).remove().draw(false);
}
ManInforme_AddEditExSitu.fnImportArea = function (asCodArea, e, obj) {
    var url = urlLocalSigo + "Supervision/ManInformeExSitu/ImportarDatosAreaExSitu";
    uploadFile.fileSelectHandler(e, obj, url, { asCodArea: asCodArea }, function (data) {
        var dt;
        switch (asCodArea) {
            case "0000001": dt = ManInforme_AddEditExSitu.dtInfrArea_Exhibicion; break;
            case "0000002": dt = ManInforme_AddEditExSitu.dtInfrArea_Crianza; break;
            case "0000003": dt = ManInforme_AddEditExSitu.dtInfrArea_Preparacion; break;
            case "0000004": dt = ManInforme_AddEditExSitu.dtInfrArea_Almacen; break;
            case "0000005": dt = ManInforme_AddEditExSitu.dtInfrArea_Topico; break;
            case "0000006": dt = ManInforme_AddEditExSitu.dtInfrArea_Cuarentena; break;
        }

        for (var i = 0; i < data.length; i++) {
            dt.rows.add([data[i]]).draw();
            dt.page('last').draw('page');
        }
    });
}
ManInforme_AddEditExSitu.fnGetListArea = function (asCodArea) {
    var dt, list = [], data;
    switch (asCodArea) {
        case "0000001": dt = ManInforme_AddEditExSitu.dtInfrArea_Exhibicion; break;
        case "0000002": dt = ManInforme_AddEditExSitu.dtInfrArea_Crianza; break;
        case "0000003": dt = ManInforme_AddEditExSitu.dtInfrArea_Preparacion; break;
        case "0000004": dt = ManInforme_AddEditExSitu.dtInfrArea_Almacen; break;
        case "0000005": dt = ManInforme_AddEditExSitu.dtInfrArea_Topico; break;
        case "0000006": dt = ManInforme_AddEditExSitu.dtInfrArea_Cuarentena; break;
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
/*Fin Infraestructura - Área*/
/*SECCIÓN Cautiverio*/
//Relación del Personal del centro de cría
ManInforme_AddEditExSitu.fnAddEditRelPerCentroCria = function (_tipo, obj) {
    var dt, url;
    switch (_tipo) {
        case "RELPER_CENTROCRIA": dt = ManInforme_AddEditExSitu.dtRelPerCentroCria; break;
    }
    url = urlLocalSigo + "Supervision/ManInformeExSitu/_RelPerCentroCria";
    var option = { url: url, type: 'POST', datos: {}, divId: "mdlManInforme_Global" };

    utilSigo.fnOpenModal(option, function () {
        _RelPerCentroCria.fnSaveForm = function (data) {
            console.log(data);
            if (data != null) {
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
                $("#mdlManInforme_Global").modal('hide');
            } else {
                utilSigo.toastError("Error", "No se pudieron guardar los datos");
            }
        }

        if (obj != null && obj != "") {
            var data = dt.row($(obj).parents('tr')).data();
            _RelPerCentroCria.fnInit(utilSigo.fnConvertArrayToObject(data));
        } else {
            _RelPerCentroCria.fnInit("");
        }
    });
}

ManInforme_AddEditExSitu.fnAddEditGrupoTaxonomico = function (_tipo, obj) {
    var dt, url;
    switch (_tipo) {
        case "GRUPO_TAXONOMICO": dt = ManInforme_AddEditExSitu.dtCauti_GrupoTaxonomico; break;
    }
    url = urlLocalSigo + "Supervision/ManInformeExSitu/_GrupoTaxonomico";
    var option = { url: url, type: 'POST', datos: {}, divId: "mdlManInformeExSitu_Cautiverio" };

    utilSigo.fnOpenModal(option, function () {
        _GrupoTaxonomico.fnSaveForm = function (data) {
            console.log(data);
            if (data != null) {
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
                $("#mdlManInformeExSitu_Cautiverio").modal('hide');
            } else {
                utilSigo.toastError("Error", "No se pudieron guardar los datos");
            }
        }

        if (obj != null && obj != "") {
            var data = dt.row($(obj).parents('tr')).data();
            _GrupoTaxonomico.fnInit(utilSigo.fnConvertArrayToObject(data));
        } else {
            _GrupoTaxonomico.fnInit("");
        }
    });
}
ManInforme_AddEditExSitu.fnAddEditEquipoContencion = function (_tipo, obj) {
    var dt, url;
    switch (_tipo) {
        case "CONTENCION_FISICA": dt = ManInforme_AddEditExSitu.dtCauti_EquipoContFisico; break;
        case "CONTENCION_QUIMICA": dt = ManInforme_AddEditExSitu.dtCauti_EquipoContQuimico; break;
        case "EQUIPO_DESINFECCION": dt = ManInforme_AddEditExSitu.dtCauti_EquipoDesinfeccion; break;
    }
    url = urlLocalSigo + "Supervision/ManInformeExSitu/_EquipoContencion";
    var option = { url: url, type: 'POST', datos: { asTipo: _tipo }, divId: "mdlManInformeExSitu_Cautiverio" };

    utilSigo.fnOpenModal(option, function () {
        _EquipoContencion.fnSaveForm = function (data) {
            if (data != null) {
                if (obj == null || obj == "") {//Nuevo Registro
                    if (!utilDt.existValorSearch(dt, "COD_TDESCRIPTIVA", data["COD_TDESCRIPTIVA"])) {
                        dt.rows.add([data]).draw();
                        dt.page('last').draw('page');
                        utilSigo.toastSuccess("Exito", "Datos guardados correctamente");
                    } else {
                        utilSigo.toastWarning("Aviso", "El tipo ya se encuentra registrado");
                    }
                } else {//Modificar
                    var row = dt.row($(obj).parents('tr')).data();
                    row = data;
                    dt.row($(obj).parents('tr')).data(row).draw(false);
                    utilSigo.toastSuccess("Exito", "Datos actualizados correctamente");
                }
                $("#mdlManInformeExSitu_Cautiverio").modal('hide');
            } else {
                utilSigo.toastError("Error", "No se pudieron guardar los datos");
            }
        }

        if (obj != null && obj != "") {
            var data = dt.row($(obj).parents('tr')).data();
            _EquipoContencion.fnInit(utilSigo.fnConvertArrayToObject(data));
        } else { _EquipoContencion.fnInit(""); }
    });
}
ManInforme_AddEditExSitu.fnAddEquipoLimpieza = function (_tipo) {
    var dt, combo, data = {};
    switch (_tipo) {
        case "EQUIPO_LIMPIEZA":
            dt = ManInforme_AddEditExSitu.dtCauti_EquipoLimpieza;
            combo = ManInforme_AddEditExSitu.frm.find("#ddlEquipoLimpiezaId");
            break;
        case "MATERIAL_DESINFECCION":
            dt = ManInforme_AddEditExSitu.dtCauti_MaterialDesinfeccion;
            combo = ManInforme_AddEditExSitu.frm.find("#ddlMaterialDesinfeccionId");
            break;
    }

    if (!utilDt.existValorSearch(dt, "COD_TDESCRIPTIVA", combo.val())) {
        data.COD_TDESCRIPTIVA = combo.val();
        data.DESCRIPCION = combo.select2("data")[0].text;
        data.RegEstado = 1;
        dt.rows.add([data]).draw();
    } else {
        utilSigo.toastWarning("Aviso", "El registro ya existe");
    }
}
ManInforme_AddEditExSitu.fnAddEditControlPlaga = function (_tipo, obj) {
    var dt, url;
    switch (_tipo) {
        case "CONTROL_PLAGA": dt = ManInforme_AddEditExSitu.dtCauti_ControlPlaga; break;
    }
    url = urlLocalSigo + "Supervision/ManInformeExSitu/_ControlPlaga";
    var option = { url: url, type: 'POST', datos: { asTipo: _tipo }, divId: "mdlManInformeExSitu_Cautiverio" };

    utilSigo.fnOpenModal(option, function () {
        _ControlPlaga.fnSaveForm = function (data) {
            if (data != null) {
                if (obj == null || obj == "") {//Nuevo Registro
                    if (!utilDt.existValorSearch(dt, "COD_TDESCRIPTIVA", data["COD_TDESCRIPTIVA"])) {
                        dt.rows.add([data]).draw();
                        dt.page('last').draw('page');
                        utilSigo.toastSuccess("Exito", "Datos guardados correctamente");
                    } else {
                        utilSigo.toastWarning("Aviso", "El tipo ya se encuentra registrado");
                    }
                } else {//Modificar
                    var row = dt.row($(obj).parents('tr')).data();
                    row = data;
                    dt.row($(obj).parents('tr')).data(row).draw(false);
                    utilSigo.toastSuccess("Exito", "Datos actualizados correctamente");
                }
                $("#mdlManInformeExSitu_Cautiverio").modal('hide');
            } else {
                utilSigo.toastError("Error", "No se pudieron guardar los datos");
            }
        }

        if (obj != null && obj != "") {
            var data = dt.row($(obj).parents('tr')).data();
            _ControlPlaga.fnInit(utilSigo.fnConvertArrayToObject(data));
        } else { _ControlPlaga.fnInit(""); }
    });
}
ManInforme_AddEditExSitu.fnAddEditManejoRegistro = function (_tipo, obj) {
    var dt, url;
    switch (_tipo) {
        case "MANEJO_REGISTRO": dt = ManInforme_AddEditExSitu.dtCauti_ManejoRegistro; break;
    }
    url = urlLocalSigo + "Supervision/ManInformeExSitu/_ManejoRegistro";
    var option = { url: url, type: 'POST', datos: { asTipo: _tipo }, divId: "mdlManInformeExSitu_Cautiverio" };

    utilSigo.fnOpenModal(option, function () {
        _ManejoRegistro.fnSaveForm = function (data) {
            if (data != null) {
                if (obj == null || obj == "") {//Nuevo Registro
                    if (!utilDt.existValorSearch(dt, "COD_TDESCRIPTIVA", data["COD_TDESCRIPTIVA"])) {
                        dt.rows.add([data]).draw();
                        dt.page('last').draw('page');
                        utilSigo.toastSuccess("Exito", "Datos guardados correctamente");
                    } else {
                        utilSigo.toastWarning("Aviso", "El tipo ya se encuentra registrado");
                    }
                } else {//Modificar
                    var row = dt.row($(obj).parents('tr')).data();
                    row = data;
                    dt.row($(obj).parents('tr')).data(row).draw(false);
                    utilSigo.toastSuccess("Exito", "Datos actualizados correctamente");
                }
                $("#mdlManInformeExSitu_Cautiverio").modal('hide');
            } else {
                utilSigo.toastError("Error", "No se pudieron guardar los datos");
            }
        }

        if (obj != null && obj != "") {
            var data = dt.row($(obj).parents('tr')).data();
            _ManejoRegistro.fnInit(utilSigo.fnConvertArrayToObject(data));
        } else { _ManejoRegistro.fnInit(""); }
    });
}
ManInforme_AddEditExSitu.fnAddEditEnriquecimientoAmb = function (_tipo, obj) {
    var dt, url;
    switch (_tipo) {
        case "ENRIQUECIMIENTO_AMBIENTAL": dt = ManInforme_AddEditExSitu.dtCauti_EnriquecimientoAmb; break;
    }
    url = urlLocalSigo + "Supervision/ManInformeExSitu/_EnriquecimientoAmb";
    var option = { url: url, type: 'POST', datos: { asTipo: _tipo }, divId: "mdlManInformeExSitu_Cautiverio" };

    utilSigo.fnOpenModal(option, function () {
        _EnriquecimientoAmb.fnSaveForm = function (data) {
            if (data != null) {
                if (obj == null || obj == "") {//Nuevo Registro
                    if (!utilDt.existValorSearch(dt, "COD_TDESCRIPTIVA", data["COD_TDESCRIPTIVA"])) {
                        dt.rows.add([data]).draw();
                        dt.page('last').draw('page');
                        utilSigo.toastSuccess("Exito", "Datos guardados correctamente");
                    } else {
                        utilSigo.toastWarning("Aviso", "El tipo ya se encuentra registrado");
                    }
                } else {//Modificar
                    var row = dt.row($(obj).parents('tr')).data();
                    row = data;
                    dt.row($(obj).parents('tr')).data(row).draw(false);
                    utilSigo.toastSuccess("Exito", "Datos actualizados correctamente");
                }
                $("#mdlManInformeExSitu_Cautiverio").modal('hide');
            } else {
                utilSigo.toastError("Error", "No se pudieron guardar los datos");
            }
        }

        if (obj != null && obj != "") {
            var data = dt.row($(obj).parents('tr')).data();
            _EnriquecimientoAmb.fnInit(utilSigo.fnConvertArrayToObject(data));
        } else { _EnriquecimientoAmb.fnInit(""); }
    });
}

ManInforme_AddEditExSitu.fnAddEditExportarExcelManejo = function (dt, nombreexcel) {

    if (dt.rows().data().length == 0) {
        utilSigo.toastWarning("Aviso", "La tabla no tiene información");
        return false;
    }

    var listArea_Exhibicion = dt;
    var data = listArea_Exhibicion.rows().data();



    let nombrecomun = [];
    var lista = [];
    data.each(function (item) {
        let obj = {};
        switch (nombreexcel) {
            case "NACIMIENTO_ESPECIE":
                nombrecomun = item.NOMBRE_COMUN.split('|');
                obj = {
                    NOMBRE_CIENTIFICO: nombrecomun[0],
                    NOMBRE_COMUN: nombrecomun[1],
                    CENSO_INICIAL: "",
                    CANT_INGRESO: item.NUMERO,
                    FECHA_INGRESO: item.FECHA_PUBLICACION,
                    DOCUMENTO_INGRESO: item.DESCRIPCION,
                    NOTIVO_INGESO: "NACIMIENTO",
                    PROGRAMA_REPRODUCCION_INGRESO: "",
                    OBSERVACION_INGRESO: item.OBSERVACION,
                    CANT_EGRESO: "",
                    FECHA_EGRESO: "",
                    DOCUMENTO_EGRESO: "",
                    MOTIVO_EGRESO: "",
                    EDAD_EGRESO: "",
                    SEXO_EGRESO: item.SEXO,
                    CODIGO_EGRESO: "",
                    DIAGNOSTICO_EGRESO: "",
                    OBSERVACION_EGRESO: "",
                    BALANCE_PREVIO: "",
                    CENSO_FINAL: ""
                }; break;
            case "EGRESO_ESPECIE":
                nombrecomun = item.NOMBRE_COMUN.split('|');
                obj = {
                    NOMBRE_CIENTIFICO: nombrecomun[0],
                    NOMBRE_COMUN: nombrecomun[1],
                    CENSO_INICIAL: "",
                    CANT_INGRESO: "",
                    FECHA_INGRESO: "",
                    DOCUMENTO_INGRESO: "",
                    NOTIVO_INGESO: "",
                    PROGRAMA_REPRODUCCION_INGRESO: "",
                    OBSERVACION_INGRESO: "",
                    CANT_EGRESO: "",
                    FECHA_EGRESO: item.FECHA_PUBLICACION,
                    DOCUMENTO_EGRESO: item.DOCUMENTO,
                    MOTIVO_EGRESO: item.MOTIVO,
                    EDAD_EGRESO: item.EDAD,
                    SEXO_EGRESO: item.SEXO,
                    CODIGO_EGRESO: item.CODIGO_NOMBRE,
                    NECROPSIA_EGRESO: "",
                    DIAGNOSTICO_EGRESO: "",
                    OBSERVACION_EGRESO: item.OBSERVACION,
                    BALANCE_PREVIO: "",
                    CENSO_FINAL: ""
                }; break;
            case "ESPECIE_VERTEBRADO":
                nombrecomun = item.DESCRIPCION.split('|');
                obj = {
                    NOMBRE_CIENTIFICO: nombrecomun[0],
                    NOMBRE_COMUN: nombrecomun[1],
                    PROCEDENCIA: item.DESC_PROCEDENCIA,
                    N_INDIVIDUOS: item.PROCEDENCIA_NUM_INDIVIDUOS,
                    TIPO_IDENTIFICACION: item.DESC_TIDENTIFICACION,
                    CODIGO_NOMBRE: item.CODIGO_NOMBRE,
                    SEXO: item.SEXO,
                    GRADO_AMENAZA: item.DESC_ACATEGORIA,
                    OBSERVACION: item.OBSERVACION
                }; break;
            case "ESPECIE_INVERTEBRADO":
                nombrecomun = item.DESCRIPCION.split('|');
                obj = {
                    NOMBRE_CIENTIFICO: nombrecomun[0],
                    NOMBRE_COMUN: nombrecomun[1],
                    PROCEDENCIA: item.DESC_PROCEDENCIA,
                    N_INDIVIDUOS: item.PROCEDENCIA_NUM_INDIVIDUOS,
                    GRADO_AMENAZA: item.DESC_ACATEGORIA,
                    DOCUMENTO_INGRESO: item.DESCRIPCION,
                    OBSERVACION: item.OBSERVACION
                }; break;
            case "BALANCE_ING_EGR":
                nombrecomun = item.NOMBRE_COMUN.split('|');
                obj = {
                    NOMBRE_CIENTIFICO: nombrecomun[0],
                    NOMBRE_COMUN: nombrecomun[1],
                    CENSO_INICIAL: "",
                    CANT_INGRESO: item.CANT_INGRESO,
                    FECHA_INGRESO: item.FECHA_INGRESO,
                    DOCUMENTO_INGRESO: item.DOCUMENTO_INGRESO,
                    NOTIVO_INGESO: item.MOTIVO_INGRESO,
                    PROGRAMA_REPRODUCCION_INGRESO: "",
                    OBSERVACION_INGRESO: item.OBSERV_INGRESO,
                    CANT_EGRESO: item.CANT_EGRESO,
                    FECHA_EGRESO: item.FECHA_EGRESO,
                    DOCUMENTO_EGRESO: item.DOCUMENTO_EGRESO,
                    MOTIVO_EGRESO: item.MOTIVO_EGRESO,
                    EDAD_EGRESO: "",
                    SEXO_EGRESO: "",
                    CODIGO_EGRESO: "",
                    NECROPSIA_EGRESO: "",
                    DIAGNOSTICO_EGRESO: "",
                    OBSERVACION_EGRESO: item.OBSERV_EGRESO,
                    BALANCE_PREVIO: item.BALANCE_PREVIO,
                    CENSO_FINAL: item.CENSO_FINAL
                }; break;
        }
        //let obj = { NUMERO: item.NUMERO, LARGO: item.LARGO, ANCHO: item.ANCHO, ALTURA: item.ALTURA, AREA: item.AREA };



        lista.push(obj);
    });

    let keys = [], a = 0;
    lista.forEach(function (row) {
        let m = Object.keys(row).length;
        if (m > a) {
            a = m;
            keys = Object.keys(row);
        }
    });

    let props = keys.map(function (key) { return { th: key, td: key } });

    let html = ManInforme_AddEditExSitu.CreateTableHtml(lista, props);
    ManInforme_AddEditExSitu.ExportToExcel(html, nombreexcel);
}

ManInforme_AddEditExSitu.fnAddEditEspecieReprod = function (_tipo, obj) {
    var dt, url;
    switch (_tipo) {
        case "ESPECIE_REPRODUCIDA": dt = ManInforme_AddEditExSitu.dtCauti_EspecieReproducida; break;
    }
    url = urlLocalSigo + "Supervision/ManInformeExSitu/_EspecieReproducida";
    var option = { url: url, type: 'POST', datos: { asTipo: _tipo }, divId: "mdlManInformeExSitu_Cautiverio" };

    utilSigo.fnOpenModal(option, function () {
        _EspecieReproducida.fnSaveForm = function (data) {
            if (data != null) {
                if (obj == null || obj == "") {//Nuevo Registro
                    if (!utilDt.existValorSearch(dt, "COD_ESPECIES", data["COD_ESPECIES"])) {
                        dt.rows.add([data]).draw();
                        dt.page('last').draw('page');
                        utilSigo.toastSuccess("Exito", "Datos guardados correctamente");
                    } else {
                        utilSigo.toastWarning("Aviso", "El tipo ya se encuentra registrado");
                    }
                } else {//Modificar
                    var row = dt.row($(obj).parents('tr')).data();
                    row = data;
                    dt.row($(obj).parents('tr')).data(row).draw(false);
                    utilSigo.toastSuccess("Exito", "Datos actualizados correctamente");
                }
                $("#mdlManInformeExSitu_Cautiverio").modal('hide');
            } else {
                utilSigo.toastError("Error", "No se pudieron guardar los datos");
            }
        }

        if (obj != null && obj != "") {
            var data = dt.row($(obj).parents('tr')).data();
            _EspecieReproducida.fnInit(utilSigo.fnConvertArrayToObject(data));
        } else { _EspecieReproducida.fnInit(""); }
    });
}
ManInforme_AddEditExSitu.fnAddEditEspecieCapturada = function (_tipo, obj) {
    var dt, url;
    switch (_tipo) {
        case "ESPECIE_CAPTURADA": dt = ManInforme_AddEditExSitu.dtCauti_EspecieCapturada; break;
    }
    url = urlLocalSigo + "Supervision/ManInformeExSitu/_EspecieCapturada";
    var option = { url: url, type: 'POST', datos: { asTipo: _tipo }, divId: "mdlManInformeExSitu_Cautiverio" };

    utilSigo.fnOpenModal(option, function () {
        _EspecieCapturada.fnSaveForm = function (data) {
            if (data != null) {
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
                $("#mdlManInformeExSitu_Cautiverio").modal('hide');
            } else {
                utilSigo.toastError("Error", "No se pudieron guardar los datos");
            }
        }

        if (obj != null && obj != "") {
            var data = dt.row($(obj).parents('tr')).data();
            _EspecieCapturada.fnInit(utilSigo.fnConvertArrayToObject(data));
        } else { _EspecieCapturada.fnInit(""); }
    });
}
ManInforme_AddEditExSitu.fnAddEditTraslocEspec = function (_tipo, obj) {
    var dt, url;
    switch (_tipo) {
        case "TRASLOC_ESPECIMENES": dt = ManInforme_AddEditExSitu.dtCauti_TraslocEspec; break;
    }
    url = urlLocalSigo + "Supervision/ManInformeExSitu/_TraslocEspec";
    var option = { url: url, type: 'POST', datos: { asTipo: _tipo }, divId: "mdlManInformeExSitu_Cautiverio" };

    utilSigo.fnOpenModal(option, function () {
        _TraslocEspec.fnSaveForm = function (data) {            
            if (data != null) {                
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
                $("#mdlManInformeExSitu_Cautiverio").modal('hide');
            } else {
                utilSigo.toastError("Error", "No se pudieron guardar los datos");
            }
        }

        if (obj != null && obj != "") {
            var data = dt.row($(obj).parents('tr')).data();
            _TraslocEspec.fnInit(utilSigo.fnConvertArrayToObject(data));
        } else { _TraslocEspec.fnInit(""); }
    });
}
ManInforme_AddEditExSitu.fnAddEditCapacitacion = function (obj) {
    var dt = ManInforme_AddEditExSitu.dtCauti_Capacitacion;
    var url = urlLocalSigo + "Supervision/ManInformeExSitu/_ActividadCapacitacion";
    var option = { url: url, type: 'POST', datos: {}, divId: "mdlManInformeExSitu_Cautiverio" };

    utilSigo.fnOpenModal(option, function () {
        _ActividadCapacitacion.fnSaveForm = function (data) {
            if (data != null) {
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
                $("#mdlManInformeExSitu_Cautiverio").modal('hide');
            } else {
                utilSigo.toastError("Error", "No se pudieron guardar los datos");
            }
        }

        if (obj != null && obj != "") {
            var data = dt.row($(obj).parents('tr')).data();
            _ActividadCapacitacion.fnInit(utilSigo.fnConvertArrayToObject(data));
        } else { _ActividadCapacitacion.fnInit(""); }
    });
}
ManInforme_AddEditExSitu.fnAddEditEspecieNacimiento = function (_tipo, obj) {
    var dt, url;
    switch (_tipo) {
        case "NACIMIENTO_ESPECIE": dt = ManInforme_AddEditExSitu.dtCauti_EspecieNacimiento; break;
        case "EGRESO_ESPECIE": dt = ManInforme_AddEditExSitu.dtCauti_EspecieEgreso; break;
    }
    url = urlLocalSigo + "Supervision/ManInformeExSitu/_EspecieNacimiento";
    var option = { url: url, type: 'POST', datos: { asTipo: _tipo }, divId: "mdlManInformeExSitu_Cautiverio" };

    utilSigo.fnOpenModal(option, function () {
        _EspecieNacimiento.fnSaveForm = function (data) {
            if (data != null) {

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
                $("#mdlManInformeExSitu_Cautiverio").modal('hide');
            } else {
                utilSigo.toastError("Error", "No se pudieron guardar los datos");
            }
        }

        if (obj != null && obj != "") {

            var data = dt.row($(obj).parents('tr')).data();
            _EspecieNacimiento.fnInit(utilSigo.fnConvertArrayToObject(data));
        } else { _EspecieNacimiento.fnInit(""); }
    });
}
ManInforme_AddEditExSitu.fnAddEditEspecieCenso = function (_tipo, obj) {
    var dt, url;
    switch (_tipo) {
        case "ESPECIE_VERTEBRADO": dt = ManInforme_AddEditExSitu.dtCauti_EspecieVertebrado; break;
        case "ESPECIE_INVERTEBRADO": dt = ManInforme_AddEditExSitu.dtCauti_EspecieInvertebrado; break;
    }
    url = urlLocalSigo + "Supervision/ManInformeExSitu/_EspecieCenso";
    var option = { url: url, type: 'POST', datos: { asTipo: _tipo }, divId: "mdlManInformeExSitu_Cautiverio" };

    utilSigo.fnOpenModal(option, function () {
        _EspecieCenso.fnSaveForm = function (data) {
            if (data != null) {
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
                $("#mdlManInformeExSitu_Cautiverio").modal('hide');
            } else {
                utilSigo.toastError("Error", "No se pudieron guardar los datos");
            }
        }

        if (obj != null && obj != "") {
            var data = dt.row($(obj).parents('tr')).data();
            _EspecieCenso.fnInit(utilSigo.fnConvertArrayToObject(data));
        } else { _EspecieCenso.fnInit(""); }
    });
}
ManInforme_AddEditExSitu.fnAddEditActEducacion = function (obj) {
    var url = urlLocalSigo + "Supervision/ManInformeExSitu/_ActividadEducacion";
    var option = { url: url, type: 'POST', datos: {}, divId: "mdlManInformeExSitu_Cautiverio" };
    var dt = ManInforme_AddEditExSitu.dtCauti_ActEducacion;

    utilSigo.fnOpenModal(option, function () {
        _ActividadEducacion.fnSaveForm = function (data, data_eli) {
            if (data != null) {
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
                ManInforme_AddEditExSitu.tbEliTABLA = ManInforme_AddEditExSitu.tbEliTABLA.concat(data_eli);
                $("#mdlManInformeExSitu_Cautiverio").modal('hide');
            } else {
                utilSigo.toastError("Error", "No se pudieron guardar los datos");
            }
        }

        if (obj != null && obj != "") {
            var data = dt.row($(obj).parents('tr')).data();
            _ActividadEducacion.fnInit(utilSigo.fnConvertArrayToObject(data));
        } else { _ActividadEducacion.fnInit(""); }
    });
}
ManInforme_AddEditExSitu.fnAddEditActInvestigacion = function (obj) {
    var url = urlLocalSigo + "Supervision/ManInformeExSitu/_ActividadInvestigacion";
    var option = { url: url, type: 'POST', datos: {}, divId: "mdlManInformeExSitu_Cautiverio" };
    var dt = ManInforme_AddEditExSitu.dtCauti_ActInvestigacion;

    utilSigo.fnOpenModal(option, function () {
        _ActividadInvestigacion.fnSaveForm = function (data) {
            if (data != null) {
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
                $("#mdlManInformeExSitu_Cautiverio").modal('hide');
            } else {
                utilSigo.toastError("Error", "No se pudieron guardar los datos");
            }
        }

        if (obj != null && obj != "") {
            var data = dt.row($(obj).parents('tr')).data();
            _ActividadInvestigacion.fnInit(utilSigo.fnConvertArrayToObject(data));
        } else { _ActividadInvestigacion.fnInit(""); }
    });
}
ManInforme_AddEditExSitu.fnDeleteCautiverio = function (_tipo, obj) {
    var dt, data;
    switch (_tipo) {
        case "GRUPO_TAXONOMICO": dt = ManInforme_AddEditExSitu.dtCauti_GrupoTaxonomico; break;
        case "CONTENCION_FISICA": dt = ManInforme_AddEditExSitu.dtCauti_EquipoContFisico; break;
        case "CONTENCION_QUIMICA": dt = ManInforme_AddEditExSitu.dtCauti_EquipoContQuimico; break;
        case "EQUIPO_LIMPIEZA": dt = ManInforme_AddEditExSitu.dtCauti_EquipoLimpieza; break;
        case "MATERIAL_DESINFECCION": dt = ManInforme_AddEditExSitu.dtCauti_MaterialDesinfeccion; break;
        case "EQUIPO_DESINFECCION": dt = ManInforme_AddEditExSitu.dtCauti_EquipoDesinfeccion; break;
        case "CONTROL_PLAGA": dt = ManInforme_AddEditExSitu.dtCauti_ControlPlaga; break;
        case "MANEJO_REGISTRO": dt = ManInforme_AddEditExSitu.dtCauti_ManejoRegistro; break;
        case "ENRIQUECIMIENTO_AMBIENTAL": dt = ManInforme_AddEditExSitu.dtCauti_EnriquecimientoAmb; break;
        case "ESPECIE_REPRODUCIDA": dt = ManInforme_AddEditExSitu.dtCauti_EspecieReproducida; break;
        case "ESPECIE_CAPTURADA": dt = ManInforme_AddEditExSitu.dtCauti_EspecieCapturada; break;
        case "TRASLOC_ESPEC": dt = ManInforme_AddEditExSitu.dtCauti_TraslocEspec; break;
        case "CAPACITACION": dt = ManInforme_AddEditExSitu.dtCauti_Capacitacion; break;
        case "NACIMIENTO_ESPECIE": dt = ManInforme_AddEditExSitu.dtCauti_EspecieNacimiento; break;
        case "EGRESO_ESPECIE": dt = ManInforme_AddEditExSitu.dtCauti_EspecieEgreso; break;
        case "ESPECIE_VERTEBRADO": dt = ManInforme_AddEditExSitu.dtCauti_EspecieVertebrado; break;
        case "ESPECIE_INVERTEBRADO": dt = ManInforme_AddEditExSitu.dtCauti_EspecieInvertebrado; break;
        case "ACTIVIDAD_EDUCACION": dt = ManInforme_AddEditExSitu.dtCauti_ActEducacion; break;
        case "ACTIVIDAD_INVESTIGACION": dt = ManInforme_AddEditExSitu.dtCauti_ActInvestigacion; break;
        case "BALANCE_ING_EGR": dt = ManInforme_AddEditExSitu.dtCauti_BalanceIngEgr; break;
        case "RELPER_CENTROCRIA": dt = ManInforme_AddEditExSitu.dtRelPerCentroCria; break;
    }
    data = dt.row($(obj).parents('tr')).data();

    if (data["RegEstado"] == "0" || data["RegEstado"] == "2") {
        switch (_tipo) {
            case "GRUPO_TAXONOMICO":
                ManInforme_AddEditExSitu.tbEliTABLA.push({
                    EliTABLA: "EXSITU_CAUTI_PALIMENTACION",
                    COD_ESPECIES: data["COD_TDESCRIPTIVA"],
                    COD_SECUENCIAL: data["COD_SECUENCIAL"]
                });
                break;
            case "CONTENCION_FISICA":
                ManInforme_AddEditExSitu.tbEliTABLA.push({
                    EliTABLA: "PCONTENCION_MFISICO",
                    COD_ESPECIES: data["COD_TDESCRIPTIVA"]
                });
                break;
            case "CONTENCION_QUIMICA":
                ManInforme_AddEditExSitu.tbEliTABLA.push({
                    EliTABLA: "PCONTENCION_MQUIMICO",
                    COD_ESPECIES: data["COD_TDESCRIPTIVA"]
                });
                break;
            case "EQUIPO_LIMPIEZA":
                ManInforme_AddEditExSitu.tbEliTABLA.push({
                    EliTABLA: "CAUTI_PBIO_DET_MLIMPIEZA",
                    COD_ESPECIES: data["COD_TDESCRIPTIVA"]
                });
                break;
            case "MATERIAL_DESINFECCION":
                ManInforme_AddEditExSitu.tbEliTABLA.push({
                    EliTABLA: "CAUTI_PBIO_DET_MDESINFECCION",
                    COD_ESPECIES: data["COD_TDESCRIPTIVA"]
                });
                break;
            case "EQUIPO_DESINFECCION":
                ManInforme_AddEditExSitu.tbEliTABLA.push({
                    EliTABLA: "CAUTI_PBIO_DET_EDESINFECCION",
                    COD_ESPECIES: data["COD_TDESCRIPTIVA"]
                });
                break;
            case "CONTROL_PLAGA":
                ManInforme_AddEditExSitu.tbEliTABLA.push({
                    EliTABLA: "CAUTI_PBIO_DET_CPLAGAS",
                    COD_ESPECIES: data["COD_TDESCRIPTIVA"]
                });
                break;
            case "MANEJO_REGISTRO":
                ManInforme_AddEditExSitu.tbEliTABLA.push({
                    EliTABLA: "CAUTI_MREGISTRO",
                    COD_ESPECIES: data["COD_TDESCRIPTIVA"]
                });
                break;
            case "ENRIQUECIMIENTO_AMBIENTAL":
                ManInforme_AddEditExSitu.tbEliTABLA.push({
                    EliTABLA: "CAUTI_PEAMBIENTAL",
                    COD_ESPECIES: data["COD_TDESCRIPTIVA"]
                });
                break;
            case "ESPECIE_REPRODUCIDA":
                ManInforme_AddEditExSitu.tbEliTABLA.push({
                    EliTABLA: "CAUTI_PMGENETICO",
                    COD_ESPECIES: data["COD_ESPECIES"]
                });
                break;
            case "ESPECIE_CAPTURADA":
                ManInforme_AddEditExSitu.tbEliTABLA.push({
                    EliTABLA: "CAUTI_PCOLECTA",
                    COD_SECUENCIAL: data["COD_SECUENCIAL"]
                });
                break;
            case "TRASLOC_ESPEC":
                ManInforme_AddEditExSitu.tbEliTABLA.push({
                    EliTABLA: "CAUTI_TESPEC",
                    COD_SECUENCIAL: data["COD_SECUENCIAL"]
                });
                break;
            case "CAPACITACION":
                ManInforme_AddEditExSitu.tbEliTABLA.push({
                    EliTABLA: "CAUTI_PCAPACITACION",
                    EliVALOR01: data["COD_EXSITUCAPACITACION"]
                });
                break;
            case "NACIMIENTO_ESPECIE":
                ManInforme_AddEditExSitu.tbEliTABLA.push({
                    EliTABLA: "CAUTI_NACIMIENTO",
                    COD_SECUENCIAL: data["COD_SECUENCIAL"]
                });
                break;
            case "EGRESO_ESPECIE":
                ManInforme_AddEditExSitu.tbEliTABLA.push({
                    EliTABLA: "CAUTI_EGRESO",
                    COD_SECUENCIAL: data["COD_SECUENCIAL"]
                });
                break;
            case "ESPECIE_VERTEBRADO":
            case "ESPECIE_INVERTEBRADO":
                ManInforme_AddEditExSitu.tbEliTABLA.push({
                    EliTABLA: "CAUTI_CENSO",
                    COD_SECUENCIAL: data["COD_SECUENCIAL"]
                });
                break;
            case "ACTIVIDAD_EDUCACION":
                ManInforme_AddEditExSitu.tbEliTABLA.push({
                    EliTABLA: "CAUTI_PEAMBI_ACTIVIDAD",
                    COD_ESPECIES: data["COD_TDESCRIPTIVA"],
                    COD_SECUENCIAL: data["COD_SECUENCIAL"]
                });
                break;
            case "ACTIVIDAD_INVESTIGACION":
                ManInforme_AddEditExSitu.tbEliTABLA.push({
                    EliTABLA: "CAUTI_ICIENTIFICA",
                    COD_SECUENCIAL: data["COD_SECUENCIAL"]
                });
                break;
            case "BALANCE_ING_EGR":
                ManInforme_AddEditExSitu.tbEliTABLA.push({
                    EliTABLA: "CAUTI_BALANCE",
                    EliVALOR01: data["COD_BALANCE"]
                });
                break;
            case "RELPER_CENTROCRIA":
                ManInforme_AddEditExSitu.tbEliTABLA.push({
                    EliTABLA: "INFORME_DET_RELPELCENTROCRIA",
                    EliVALOR01: data["COD_RELPELCENTROCRIA"]
                });
                break;
        }
    }
    dt.row($(obj).parents('tr')).remove().draw(false);
}
ManInforme_AddEditExSitu.fnDeleteAllCautiverio = function (_tipo) {
    var dt, data;
    switch (_tipo) {
        case "NACIMIENTO_ESPECIE": dt = ManInforme_AddEditExSitu.dtCauti_EspecieNacimiento; break;
        case "EGRESO_ESPECIE": dt = ManInforme_AddEditExSitu.dtCauti_EspecieEgreso; break;
        case "ESPECIE_VERTEBRADO": dt = ManInforme_AddEditExSitu.dtCauti_EspecieVertebrado; break;
        case "ESPECIE_INVERTEBRADO": dt = ManInforme_AddEditExSitu.dtCauti_EspecieInvertebrado; break;
        case "BALANCE_ING_EGR": dt = ManInforme_AddEditExSitu.dtCauti_BalanceIngEgr; break;
    }
    if (dt.$("tr").length > 0) {
        utilSigo.dialogConfirm("", "Está seguro de Eliminar Todos los Registros?", function (r) {
            if (r) {
                $.each(dt.$("tr"), function (i, o) {
                    data = dt.row($(o)).data();
                    if (data["RegEstado"] == "0" || data["RegEstado"] == "2") {
                        switch (_tipo) {
                            case "NACIMIENTO_ESPECIE":
                                ManInforme_AddEditExSitu.tbEliTABLA.push({
                                    EliTABLA: "CAUTI_NACIMIENTO",
                                    COD_SECUENCIAL: data["COD_SECUENCIAL"]
                                });
                                break;
                            case "EGRESO_ESPECIE":
                                ManInforme_AddEditExSitu.tbEliTABLA.push({
                                    EliTABLA: "CAUTI_EGRESO",
                                    COD_SECUENCIAL: data["COD_SECUENCIAL"]
                                });
                                break;
                            case "ESPECIE_VERTEBRADO":
                            case "ESPECIE_INVERTEBRADO":
                                ManInforme_AddEditExSitu.tbEliTABLA.push({
                                    EliTABLA: "CAUTI_CENSO",
                                    COD_SECUENCIAL: data["COD_SECUENCIAL"]
                                });
                                break;
                            case "BALANCE_ING_EGR":
                                ManInforme_AddEditExSitu.tbEliTABLA.push({
                                    EliTABLA: "CAUTI_BALANCE",
                                    EliVALOR01: data["COD_BALANCE"]
                                });
                                break;
                        }
                    }
                });
                dt.clear().draw();
            }
        });
    } else {
        utilSigo.toastWarning("Aviso", "No se encontraron registros a eliminar");
    }
}
ManInforme_AddEditExSitu.fnImportCautiverio = function (_tipo, e, obj) {
    var url = urlLocalSigo + "Supervision/ManInformeExSitu/ImportarDatosInformeSimpleExSitu";
    var dt;
    switch (_tipo) {
        case "NACIMIENTO_ESPECIE": dt = ManInforme_AddEditExSitu.dtCauti_EspecieNacimiento; break;
        case "EGRESO_ESPECIE": dt = ManInforme_AddEditExSitu.dtCauti_EspecieEgreso; break;
        case "ESPECIE_VERTEBRADO": dt = ManInforme_AddEditExSitu.dtCauti_EspecieVertebrado; break;
        case "ESPECIE_INVERTEBRADO": dt = ManInforme_AddEditExSitu.dtCauti_EspecieInvertebrado; break;
        case "BALANCE_ING_EGR": dt = ManInforme_AddEditExSitu.dtCauti_BalanceIngEgr; break;
    }

    uploadFile.fileSelectHandler(e, obj, url, { asTipo: _tipo }, function (data) {
        for (var i = 0; i < data.length; i++) {
            dt.rows.add([data[i]]).draw();
            dt.page('last').draw('page');
        }
    });
}
ManInforme_AddEditExSitu.fnGetListCautiverio = function (_tipo) {
    var dt, list = [], data;
    switch (_tipo) {
        case "GRUPO_TAXONOMICO": dt = ManInforme_AddEditExSitu.dtCauti_GrupoTaxonomico; break;
        case "CONTENCION_FISICA": dt = ManInforme_AddEditExSitu.dtCauti_EquipoContFisico; break;
        case "CONTENCION_QUIMICA": dt = ManInforme_AddEditExSitu.dtCauti_EquipoContQuimico; break;
        case "EQUIPO_LIMPIEZA": dt = ManInforme_AddEditExSitu.dtCauti_EquipoLimpieza; break;
        case "MATERIAL_DESINFECCION": dt = ManInforme_AddEditExSitu.dtCauti_MaterialDesinfeccion; break;
        case "EQUIPO_DESINFECCION": dt = ManInforme_AddEditExSitu.dtCauti_EquipoDesinfeccion; break;
        case "CONTROL_PLAGA": dt = ManInforme_AddEditExSitu.dtCauti_ControlPlaga; break;
        case "MANEJO_REGISTRO": dt = ManInforme_AddEditExSitu.dtCauti_ManejoRegistro; break;
        case "ENRIQUECIMIENTO_AMBIENTAL": dt = ManInforme_AddEditExSitu.dtCauti_EnriquecimientoAmb; break;
        case "ESPECIE_REPRODUCIDA": dt = ManInforme_AddEditExSitu.dtCauti_EspecieReproducida; break;
        case "ESPECIE_CAPTURADA": dt = ManInforme_AddEditExSitu.dtCauti_EspecieCapturada; break;
        case "TRASLOC_ESPEC": dt = ManInforme_AddEditExSitu.dtCauti_TraslocEspec; break;
        case "CAPACITACION": dt = ManInforme_AddEditExSitu.dtCauti_Capacitacion; break;
        case "NACIMIENTO_ESPECIE": dt = ManInforme_AddEditExSitu.dtCauti_EspecieNacimiento; break;
        case "EGRESO_ESPECIE": dt = ManInforme_AddEditExSitu.dtCauti_EspecieEgreso; break;
        case "ESPECIE_VERTEBRADO": dt = ManInforme_AddEditExSitu.dtCauti_EspecieVertebrado; break;
        case "ESPECIE_INVERTEBRADO": dt = ManInforme_AddEditExSitu.dtCauti_EspecieInvertebrado; break;
        case "ACTIVIDAD_EDUCACION": dt = ManInforme_AddEditExSitu.dtCauti_ActEducacion; break;
        case "ACTIVIDAD_INVESTIGACION": dt = ManInforme_AddEditExSitu.dtCauti_ActInvestigacion; break;
        case "BALANCE_ING_EGR": dt = ManInforme_AddEditExSitu.dtCauti_BalanceIngEgr; break;
        case "RELPER_CENTROCRIA": dt = ManInforme_AddEditExSitu.dtRelPerCentroCria; break;
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
/*Fin Cautiverio*/
/*SECCIÓN Evaluación ZoObservatorio*/
ManInforme_AddEditExSitu.fnGetListEvalZoo = function () {
    var list = [], data, dataHtml, puntaje = "0";

    if (ManInforme_AddEditExSitu.dtZoo_Evaluacion.$("tr").length > 0) {
        $.each(ManInforme_AddEditExSitu.dtZoo_Evaluacion.$("tr"), function (i, o) {
            data = ManInforme_AddEditExSitu.dtZoo_Evaluacion.row($(o)).data();
            dataHtml = $(o)[0];
            puntaje = "0";
            data.RegEstado = data.RegEstado == "0" || data.RegEstado == "2" ? "2" : "1";
            puntaje = $($($(dataHtml).find("td")[2]).find('input')[0]).is(":checked") ? $($($(dataHtml).find("td")[2]).find('input')[0]).val() : puntaje;
            puntaje = $($($(dataHtml).find("td")[3]).find('input')[0]).is(":checked") ? $($($(dataHtml).find("td")[3]).find('input')[0]).val() : puntaje;
            puntaje = $($($(dataHtml).find("td")[4]).find('input')[0]).is(":checked") ? $($($(dataHtml).find("td")[4]).find('input')[0]).val() : puntaje;

            data["CALIFICACION"] = puntaje;
            data["OBSERVACION"] = $($($(dataHtml).find("td")[5]).find("input")[0]).val();
            list.push(utilSigo.fnConvertArrayToObject(data));
        });
    }
    return list;
}
ManInforme_AddEditExSitu.fnCalcCalificacionZoo = function () {
    var list = ManInforme_AddEditExSitu.fnGetListEvalZoo();
    var puntuacion = 0, calificacion = 0.0;
    $.each(list, function (i, o) {
        puntuacion += parseInt(o.CALIFICACION);
    });
    calificacion = puntuacion == 0 ? 0 : (puntuacion / 2);
    ManInforme_AddEditExSitu.frm.find("#lblCalificacionZoo").text(calificacion);
}
/*Fin ZoObservatorio*/

ManInforme_AddEditExSitu.ExportToExcel = function (sHtmlFinal, name) {
    var template = '<html xmlns:o="urn:schemas-microsoft-com:office:office" xmlns:x="urn:schemas-microsoft-com:office:excel" xmlns="http://www.w3.org/TR/REC-html40">' +
        '<head><!--[if gte mso 9]><xml><x:ExcelWorkbook><x:ExcelWorksheets><x:ExcelWorksheet><x:Name>{{worksheet}}</x:Name><x:WorksheetOptions><x:DisplayGridlines/></x:WorksheetOptions></x:ExcelWorksheet></x:ExcelWorksheets></x:ExcelWorkbook></xml><![endif]--><style type="text/css">{{css}}</style></head>' +
        '<body>{{table}}</body>' +
        '</html>';
    template = template.replace('{{css}}', '.center { text-align: center; } .single-line { white-space:nowrap; width:auto; } .text { mso-number-format:"\@" } .date {mso-number-format:"Short Date";} .decimal { mso-number-format:"\#\,\#\#0\.00"; }');
    template = template.replace('{{worksheet}}', 'Hoja1');
    template = template.replace('{{table}}', sHtmlFinal);

    var ua = window.navigator.userAgent;
    var msie = ua.indexOf("MSIE ");

    if (msie > 0 || !!navigator.userAgent.match(/Trident.*rv\:11\./))      // Si es Internet Explorer
    {
        //XportArea es un iframe creado en el html de la pagina
        $('#XportArea').remove();
        var xa = document.createElement('iframe');
        xa.id = 'XportArea';
        xa.style.display = 'none';
        document.body.appendChild(xa);
        XportArea.document.open("txt/html", "replace");
        XportArea.document.write(template);
        XportArea.document.close();
        XportArea.focus();
        sa = XportArea.document.execCommand("SaveAs", true, name + ".xls");
        return sa;
    }
    else { //Otro explorador
        var formBlob = new Blob(["\ufeff", template], { type: 'application/vnd.ms-excel' });
        var link = document.createElement("a");
        link.download = name + ".xls";
        link.href = window.URL.createObjectURL(formBlob);
        document.body.appendChild(link);
        link.click();
        document.body.removeChild(link);
    }
}

ManInforme_AddEditExSitu.CreateTableHtml = function (data, params) {
    var html = '';
    html += '<table>';
    html += '<thead>';
    html += '<tr>';
    for (var i = 0; i < params.length; i++) {
        html += '<th>' + (params[i].th || '') + '</th>';
    }
    html += '</tr>';
    html += '<thead>';
    html += '<tbody>';
    for (var i = 0; i < data.length; i++) {
        html += '<tr>';
        for (var j = 0; j < params.length; j++) {
            html += '<td class="' + (params[j].type || '') + '">' + (data[i][params[j].td] == null ? '' : data[i][params[j].td]) + '</td>';
        }
        html += '</tr>';
    }
    html += '</tbody>';
    html += '</table>';
    return html;
}

ManInforme_AddEditExSitu.fnAddEditExportarExcel = function (dt, nombreexcel, tipo) {

    if (dt.rows().data().length == 0) {
        utilSigo.toastWarning("Aviso", "La tabla no tiene información");
        return false;
    }
    //var listArea_Exhibicion = ManInforme_AddEditExSitu.dtInfrArea_Exhibicion;
    var listArea_Exhibicion = dt;
    var data = listArea_Exhibicion.rows().data();// console.log(data);
    //ListISupervision_exsitu_recinto_equipo
    //var keys = Object.keys(data.ListISupervision_exsitu_recinto_equipo[0]);
    var lista = [];
    data.each(function (item) {
        let obj = {};
        switch (tipo) {
            case 1: obj = { NUMERO: item.NUMERO, LARGO: item.LARGO, ANCHO: item.ANCHO, ALTURA: item.ALTURA, AREA: item.AREA, COORDENADA_ESTE: item.COORDENADA_ESTE, COORDENADA_NORTE: item.COORDENADA_NORTE}; break;
            case 2: obj = { LARGO: item.LARGO, ANCHO: item.ANCHO, ALTURA: item.ALTURA, AREA: item.AREA, COORDENADA_ESTE: item.COORDENADA_ESTE, COORDENADA_NORTE: item.COORDENADA_NORTE }; break;
        }
        //let obj = { NUMERO: item.NUMERO, LARGO: item.LARGO, ANCHO: item.ANCHO, ALTURA: item.ALTURA, AREA: item.AREA };

        let i = 1, j = 1, k = 1;

        item.ListISupervision_exsitu_recinto_equipo.forEach(function (row, index) {
            switch (row.TIPO) {
                case 'IM': obj['MAT_CONS_' + i] = row.DESCRIPCION; i++; break;
                case 'IC': obj['TIENE_CARTEL_' + j] = row.DESCRIPCION; j++; break;
                case 'IE': obj['EQUI_ACCESORIOS_' + k] = row.DESCRIPCION; k++; break;
            }
        });

        lista.push(obj);
    });

    let keys = [], a = 0;
    lista.forEach(function (row) {
        let m = Object.keys(row).length;
        if (m > a) {
            a = m;
            keys = Object.keys(row);
        }
    });

    let props = keys.map(function (key) { return { th: key, td: key } });

    let html = ManInforme_AddEditExSitu.CreateTableHtml(lista, props);
    ManInforme_AddEditExSitu.ExportToExcel(html, nombreexcel);
}

ManInforme_AddEditExSitu.fnInitDataTable_Detail = function () {
    var columns_label = [], columns_data = [], options = {};

    //Cargar Infraestructura Area - Exhibición
    columns_label = ["Número", "Largo", "Ancho", "Altura", "Área", "Coordenada Este", "Coordenada Norte"];
    columns_data = ["NUMERO", "LARGO", "ANCHO", "ALTURA", "AREA", "COORDENADA_ESTE", "COORDENADA_NORTE"];
    options = {
        page_length: 10, row_edit: true, row_fnEdit: "ManInforme_AddEditExSitu.fnAddEditArea('0000001',this)"
        , row_delete: true, row_fnDelete: "ManInforme_AddEditExSitu.fnDeleteArea('0000001',this)", row_index: true, page_sort: true
    };
    ManInforme_AddEditExSitu.dtInfrArea_Exhibicion = utilDt.fnLoadDataTable_Detail(ManInforme_AddEditExSitu.frm.find("#tbInfrArea_Exhibicion"), columns_label, columns_data, options);
    ManInforme_AddEditExSitu.dtInfrArea_Exhibicion.rows.add(ManInforme_AddEditExSitu.DataInfraestructuraArea.filter(m => m.COD_AREA == "0000001")).draw();
    options = {
        page_length: 10, row_edit: true, row_fnEdit: "ManInforme_AddEditExSitu.fnAddEditArea('0000002',this)"
        , row_delete: true, row_fnDelete: "ManInforme_AddEditExSitu.fnDeleteArea('0000002',this)", row_index: true, page_sort: true
    };
    ManInforme_AddEditExSitu.dtInfrArea_Crianza = utilDt.fnLoadDataTable_Detail(ManInforme_AddEditExSitu.frm.find("#tbInfrArea_Crianza"), columns_label, columns_data, options);
    ManInforme_AddEditExSitu.dtInfrArea_Crianza.rows.add(ManInforme_AddEditExSitu.DataInfraestructuraArea.filter(m => m.COD_AREA == "0000002")).draw();
    options = {
        page_length: 10, row_edit: true, row_fnEdit: "ManInforme_AddEditExSitu.fnAddEditArea('0000006',this)"
        , row_delete: true, row_fnDelete: "ManInforme_AddEditExSitu.fnDeleteArea('0000006',this)", row_index: true, page_sort: true
    };
    ManInforme_AddEditExSitu.dtInfrArea_Cuarentena = utilDt.fnLoadDataTable_Detail(ManInforme_AddEditExSitu.frm.find("#tbInfrArea_Cuarentena"), columns_label, columns_data, options);
    ManInforme_AddEditExSitu.dtInfrArea_Cuarentena.rows.add(ManInforme_AddEditExSitu.DataInfraestructuraArea.filter(m => m.COD_AREA == "0000006")).draw();

    columns_label = ["Largo", "Ancho", "Altura", "Área", "Coordenada Este", "Coordenada Norte"];
    columns_data = ["LARGO", "ANCHO", "ALTURA", "AREA", "COORDENADA_ESTE", "COORDENADA_NORTE"];
    options = {
        page_length: 10, row_edit: true, row_fnEdit: "ManInforme_AddEditExSitu.fnAddEditArea('0000003',this)"
        , row_delete: true, row_fnDelete: "ManInforme_AddEditExSitu.fnDeleteArea('0000003',this)", row_index: true, page_sort: true
    };
    ManInforme_AddEditExSitu.dtInfrArea_Preparacion = utilDt.fnLoadDataTable_Detail(ManInforme_AddEditExSitu.frm.find("#tbInfrArea_Preparacion"), columns_label, columns_data, options);
    ManInforme_AddEditExSitu.dtInfrArea_Preparacion.rows.add(ManInforme_AddEditExSitu.DataInfraestructuraArea.filter(m => m.COD_AREA == "0000003")).draw();
    options = {
        page_length: 10, row_edit: true, row_fnEdit: "ManInforme_AddEditExSitu.fnAddEditArea('0000004',this)"
        , row_delete: true, row_fnDelete: "ManInforme_AddEditExSitu.fnDeleteArea('0000004',this)", row_index: true, page_sort: true
    };
    ManInforme_AddEditExSitu.dtInfrArea_Almacen = utilDt.fnLoadDataTable_Detail(ManInforme_AddEditExSitu.frm.find("#tbInfrArea_Almacen"), columns_label, columns_data, options);
    ManInforme_AddEditExSitu.dtInfrArea_Almacen.rows.add(ManInforme_AddEditExSitu.DataInfraestructuraArea.filter(m => m.COD_AREA == "0000004")).draw();
    options = {
        page_length: 10, row_edit: true, row_fnEdit: "ManInforme_AddEditExSitu.fnAddEditArea('0000005',this)"
        , row_delete: true, row_fnDelete: "ManInforme_AddEditExSitu.fnDeleteArea('0000005',this)", row_index: true, page_sort: true
    };
    ManInforme_AddEditExSitu.dtInfrArea_Topico = utilDt.fnLoadDataTable_Detail(ManInforme_AddEditExSitu.frm.find("#tbInfrArea_Topico"), columns_label, columns_data, options);
    ManInforme_AddEditExSitu.dtInfrArea_Topico.rows.add(ManInforme_AddEditExSitu.DataInfraestructuraArea.filter(m => m.COD_AREA == "0000005")).draw();

    //Cargar cautiverio

    //Relación del Personal del centro de cría    
    columns_label = ["Nombres", "Cargo"];
    columns_data = ["NOMBRES", "CARGO"];
    options = {
        page_length: 10, row_delete: true, row_fnDelete: "ManInforme_AddEditExSitu.fnDeleteCautiverio('RELPER_CENTROCRIA',this)", row_index: true, page_sort: true
    };
    ManInforme_AddEditExSitu.dtRelPerCentroCria = utilDt.fnLoadDataTable_Detail(ManInforme_AddEditExSitu.frm.find("#tbRelPerCentroCria"), columns_label, columns_data, options);
    console.log(ManInforme_AddEditExSitu.DataRelPerCentroCria);
    ManInforme_AddEditExSitu.dtRelPerCentroCria.rows.add(ManInforme_AddEditExSitu.DataRelPerCentroCria).draw();
    //Grupo taxonómico
    columns_label = ["Grupo Taxonómico", "Grupo/Especie", "Tipo Alimentación", "Frecuencia Ración", "Observación"];
    columns_data = ["DESCRIPCION", "GRUPOESPECIE", "TIPO_ALIMENTACION", "FRECUENCIA_RACION", "OBSERVACION"];
    options = {
        page_length: 10, row_edit: true, row_fnEdit: "ManInforme_AddEditExSitu.fnAddEditGrupoTaxonomico('GRUPO_TAXONOMICO',this)"
        , row_delete: true, row_fnDelete: "ManInforme_AddEditExSitu.fnDeleteCautiverio('GRUPO_TAXONOMICO',this)", row_index: true, page_sort: true
    };
    ManInforme_AddEditExSitu.dtCauti_GrupoTaxonomico = utilDt.fnLoadDataTable_Detail(ManInforme_AddEditExSitu.frm.find("#tbCauti_GrupoTaxonomico"), columns_label, columns_data, options);
    ManInforme_AddEditExSitu.dtCauti_GrupoTaxonomico.rows.add(ManInforme_AddEditExSitu.DataGrupoTaxonomico).draw();
    //Contención físico
    columns_label = ["Descripción", "Observación"];
    columns_data = ["DESCRIPCION", "OBSERVACION"];
    options = {
        page_length: 10, row_edit: true, row_fnEdit: "ManInforme_AddEditExSitu.fnAddEditEquipoContencion('CONTENCION_FISICA',this)"
        , row_delete: true, row_fnDelete: "ManInforme_AddEditExSitu.fnDeleteCautiverio('CONTENCION_FISICA',this)", row_index: true, page_sort: true
    };
    ManInforme_AddEditExSitu.dtCauti_EquipoContFisico = utilDt.fnLoadDataTable_Detail(ManInforme_AddEditExSitu.frm.find("#tbCauti_EquipoContFisico"), columns_label, columns_data, options);
    ManInforme_AddEditExSitu.dtCauti_EquipoContFisico.rows.add(ManInforme_AddEditExSitu.DataEquipoContFisico).draw();
    //Contención química
    options = {
        page_length: 10, row_edit: true, row_fnEdit: "ManInforme_AddEditExSitu.fnAddEditEquipoContencion('CONTENCION_QUIMICA',this)"
        , row_delete: true, row_fnDelete: "ManInforme_AddEditExSitu.fnDeleteCautiverio('CONTENCION_QUIMICA',this)", row_index: true, page_sort: true
    };
    ManInforme_AddEditExSitu.dtCauti_EquipoContQuimico = utilDt.fnLoadDataTable_Detail(ManInforme_AddEditExSitu.frm.find("#tbCauti_EquipoContQuimico"), columns_label, columns_data, options);
    ManInforme_AddEditExSitu.dtCauti_EquipoContQuimico.rows.add(ManInforme_AddEditExSitu.DataEquipoContQuimico).draw();
    //Materiales y equipos de limpieza
    columns_label = ["Descripción"];
    columns_data = ["DESCRIPCION"];
    options = {
        page_length: 10, row_delete: true, row_fnDelete: "ManInforme_AddEditExSitu.fnDeleteCautiverio('EQUIPO_LIMPIEZA',this)", row_index: true, page_sort: true
    };
    ManInforme_AddEditExSitu.dtCauti_EquipoLimpieza = utilDt.fnLoadDataTable_Detail(ManInforme_AddEditExSitu.frm.find("#tbCauti_EquipoLimpieza"), columns_label, columns_data, options);
    ManInforme_AddEditExSitu.dtCauti_EquipoLimpieza.rows.add(ManInforme_AddEditExSitu.DataEquipoLimpieza).draw();
    //Material de desinfección
    options = {
        page_length: 10, row_delete: true, row_fnDelete: "ManInforme_AddEditExSitu.fnDeleteCautiverio('MATERIAL_DESINFECCION',this)", row_index: true, page_sort: true
    };
    ManInforme_AddEditExSitu.dtCauti_MaterialDesinfeccion = utilDt.fnLoadDataTable_Detail(ManInforme_AddEditExSitu.frm.find("#tbCauti_MaterialDesinfeccion"), columns_label, columns_data, options);
    ManInforme_AddEditExSitu.dtCauti_MaterialDesinfeccion.rows.add(ManInforme_AddEditExSitu.DataMaterialDesinfeccion).draw();
    //Equipos de desinfección
    columns_label = ["Descripción", "Observación"];
    columns_data = ["DESCRIPCION", "OBSERVACION"];
    options = {
        page_length: 10, row_edit: true, row_fnEdit: "ManInforme_AddEditExSitu.fnAddEditEquipoContencion('EQUIPO_DESINFECCION',this)"
        , row_delete: true, row_fnDelete: "ManInforme_AddEditExSitu.fnDeleteCautiverio('EQUIPO_DESINFECCION',this)", row_index: true, page_sort: true
    };
    ManInforme_AddEditExSitu.dtCauti_EquipoDesinfeccion = utilDt.fnLoadDataTable_Detail(ManInforme_AddEditExSitu.frm.find("#tbCauti_EquipoDesinfeccion"), columns_label, columns_data, options);
    ManInforme_AddEditExSitu.dtCauti_EquipoDesinfeccion.rows.add(ManInforme_AddEditExSitu.DataEquipoDesinfeccion).draw();
    //Control de plagas
    columns_label = ["Plagas", "Frecuencia", "Método Físico", "Método Químico", "Observación"];
    columns_data = ["DESCRIPCION", "FRECUENCIA", "METODO_FISICO", "METODO_QUIMICO", "OBSERVACION"];
    options = {
        page_length: 10, row_edit: true, row_fnEdit: "ManInforme_AddEditExSitu.fnAddEditControlPlaga('CONTROL_PLAGA',this)"
        , row_delete: true, row_fnDelete: "ManInforme_AddEditExSitu.fnDeleteCautiverio('CONTROL_PLAGA',this)", row_index: true, page_sort: true
    };
    ManInforme_AddEditExSitu.dtCauti_ControlPlaga = utilDt.fnLoadDataTable_Detail(ManInforme_AddEditExSitu.frm.find("#tbCauti_ControlPlaga"), columns_label, columns_data, options);
    ManInforme_AddEditExSitu.dtCauti_ControlPlaga.rows.add(ManInforme_AddEditExSitu.DataControlPlaga).draw();
    //Manejo de registros
    columns_label = ["Descripción", "Fecha de Actualización", "Observación"];
    columns_data = ["DESCRIPCION", "FECHA_ACTUALIZACION", "OBSERVACION"];
    options = {
        page_length: 10, row_edit: true, row_fnEdit: "ManInforme_AddEditExSitu.fnAddEditManejoRegistro('MANEJO_REGISTRO',this)"
        , row_delete: true, row_fnDelete: "ManInforme_AddEditExSitu.fnDeleteCautiverio('MANEJO_REGISTRO',this)", row_index: true, page_sort: true
    };
    ManInforme_AddEditExSitu.dtCauti_ManejoRegistro = utilDt.fnLoadDataTable_Detail(ManInforme_AddEditExSitu.frm.find("#tbCauti_ManejoRegistro"), columns_label, columns_data, options);
    ManInforme_AddEditExSitu.dtCauti_ManejoRegistro.rows.add(ManInforme_AddEditExSitu.DataManejoRegistro).draw();
    //Enriquecimiento ambiental
    columns_label = ["Descripción", "Actividades Implementadas", "Material Usado", "Observación"];
    columns_data = ["DESCRIPCION", "ACTIVIDAD_IMPLEMENTADA", "MATERIAL_USADO", "OBSERVACION"];
    options = {
        page_length: 10, row_edit: true, row_fnEdit: "ManInforme_AddEditExSitu.fnAddEditEnriquecimientoAmb('ENRIQUECIMIENTO_AMBIENTAL',this)"
        , row_delete: true, row_fnDelete: "ManInforme_AddEditExSitu.fnDeleteCautiverio('ENRIQUECIMIENTO_AMBIENTAL',this)", row_index: true, page_sort: true
    };
    ManInforme_AddEditExSitu.dtCauti_EnriquecimientoAmb = utilDt.fnLoadDataTable_Detail(ManInforme_AddEditExSitu.frm.find("#tbCauti_EnriquecimientoAmb"), columns_label, columns_data, options);
    ManInforme_AddEditExSitu.dtCauti_EnriquecimientoAmb.rows.add(ManInforme_AddEditExSitu.DataEnriquecimientoAmb).draw();
    //Especies reproducidas
    columns_label = ["Origen", "Especie", "N° Crías", "N° Crías Viable", "N° Crías Muertas", "Frecuencia de Reproducción", "Época de Reproducción", "Observación"];
    columns_data = ["DESC_EORIGEN", "DESCRIPCION", "NUM_CRIAS_ANO", "NUM_CRIAS_VIABLES", "NUM_CRIAS_MUERTAS", "FRECUENCIA_DESCRIPCION", "REPRODUCCION_EPOCA", "OBSERVACION"];
    options = {
        page_length: 10, row_edit: true, row_fnEdit: "ManInforme_AddEditExSitu.fnAddEditEspecieReprod('ESPECIE_REPRODUCIDA',this)"
        , row_delete: true, row_fnDelete: "ManInforme_AddEditExSitu.fnDeleteCautiverio('ESPECIE_REPRODUCIDA',this)", row_index: true, page_sort: true
    };
    ManInforme_AddEditExSitu.dtCauti_EspecieReproducida = utilDt.fnLoadDataTable_Detail(ManInforme_AddEditExSitu.frm.find("#tbCauti_EspecieReproducida"), columns_label, columns_data, options);
    ManInforme_AddEditExSitu.dtCauti_EspecieReproducida.rows.add(ManInforme_AddEditExSitu.DataEspecieReprod).draw();
    //Traslocación de Especímenes
    columns_label = ["Especie", "N° Individuos", "Año", "Zona de Liberación", "Registro de Seguimiento"];
    columns_data = ["DESCRIPCION", "NUM_INDIVIDUOS", "ANIO", "ZONA_LIBERACION", "REGISTRO_SEG"];
    options = {
        page_length: 10, row_edit: true, row_fnEdit: "ManInforme_AddEditExSitu.fnAddEditTraslocEspec('TRASLOC_ESPECIMENES',this)"
        , row_delete: true, row_fnDelete: "ManInforme_AddEditExSitu.fnDeleteCautiverio('TRASLOC_ESPEC',this)", row_index: true, page_sort: true
    };
    ManInforme_AddEditExSitu.dtCauti_TraslocEspec = utilDt.fnLoadDataTable_Detail(ManInforme_AddEditExSitu.frm.find("#tbCauti_TraslocEspec"), columns_label, columns_data, options);
    ManInforme_AddEditExSitu.dtCauti_TraslocEspec.rows.add(ManInforme_AddEditExSitu.DataTraslocEspec).draw();
    //Especies Capturadas
    columns_label = ["Especie", "N° Individuos Capturados", "Zona de Captura", "Observación"];
    columns_data = ["DESCRIPCION", "NUM_ICAPTURADOS", "ZONA_CAPTURA", "OBSERVACION"];
    options = {
        page_length: 10, row_edit: true, row_fnEdit: "ManInforme_AddEditExSitu.fnAddEditEspecieCapturada('ESPECIE_CAPTURADA',this)"
        , row_delete: true, row_fnDelete: "ManInforme_AddEditExSitu.fnDeleteCautiverio('ESPECIE_CAPTURADA',this)", row_index: true, page_sort: true
    };
    ManInforme_AddEditExSitu.dtCauti_EspecieCapturada = utilDt.fnLoadDataTable_Detail(ManInforme_AddEditExSitu.frm.find("#tbCauti_EspecieCapturada"), columns_label, columns_data, options);
    ManInforme_AddEditExSitu.dtCauti_EspecieCapturada.rows.add(ManInforme_AddEditExSitu.DataEspecieCapturada).draw();
    //Capacitaciones
    columns_label = ["Tema", "N° Personal Beneficiado", "Entidad o Profesional Capacitador"];
    columns_data = ["TEMA", "NUM_BENEFICIADOS", "CAPACITADOR"];
    options = {
        page_length: 10, row_edit: true, row_fnEdit: "ManInforme_AddEditExSitu.fnAddEditCapacitacion(this)"
        , row_delete: true, row_fnDelete: "ManInforme_AddEditExSitu.fnDeleteCautiverio('CAPACITACION',this)", row_index: true, page_sort: true
    };
    ManInforme_AddEditExSitu.dtCauti_Capacitacion = utilDt.fnLoadDataTable_Detail(ManInforme_AddEditExSitu.frm.find("#tbCauti_Capacitacion"), columns_label, columns_data, options);
    ManInforme_AddEditExSitu.dtCauti_Capacitacion.rows.add(ManInforme_AddEditExSitu.DataCapacitacion).draw();
    //Nacimientos
    columns_label = ["Especie", "Sexo", "Cantidad", "Fecha", "Documento", "Programa", "Observación"];
    columns_data = ["NOMBRE_COMUN", "SEXO", "NUMERO", "FECHA_PUBLICACION", "DESCRIPCION", "OBJETIVO", "OBSERVACION"];
    options = {
        page_length: 10, row_edit: true, row_fnEdit: "ManInforme_AddEditExSitu.fnAddEditEspecieNacimiento('NACIMIENTO_ESPECIE',this)"
        , row_delete: true, row_fnDelete: "ManInforme_AddEditExSitu.fnDeleteCautiverio('NACIMIENTO_ESPECIE',this)", row_index: true, page_sort: true
    };
    ManInforme_AddEditExSitu.dtCauti_EspecieNacimiento = utilDt.fnLoadDataTable_Detail(ManInforme_AddEditExSitu.frm.find("#tbCauti_EspecieNacimiento"), columns_label, columns_data, options);
    ManInforme_AddEditExSitu.dtCauti_EspecieNacimiento.rows.add(ManInforme_AddEditExSitu.DataEspecieNacimiento).draw();
    //Egresos
    columns_label = ["Especie", "Sexo", "Cantidad", "Fecha", "Documento", "Motivo", "Necropsia", "Diagnóstico", "Edad", "Código/ID", "Observación"];
    columns_data = ["NOMBRE_COMUN", "SEXO", "NUMERO", "FECHA_PUBLICACION", "DOCUMENTO", "MOTIVO", "NECROPSIA", "DIAGNOSTICO", "EDAD", "CODIGO_NOMBRE", "OBSERVACION"];
    options = {
        page_length: 10, row_edit: true, row_fnEdit: "ManInforme_AddEditExSitu.fnAddEditEspecieNacimiento('EGRESO_ESPECIE',this)"
        , row_delete: true, row_fnDelete: "ManInforme_AddEditExSitu.fnDeleteCautiverio('EGRESO_ESPECIE',this)", row_index: true, page_sort: true
    };
    ManInforme_AddEditExSitu.dtCauti_EspecieEgreso = utilDt.fnLoadDataTable_Detail(ManInforme_AddEditExSitu.frm.find("#tbCauti_EspecieEgreso"), columns_label, columns_data, options);
    ManInforme_AddEditExSitu.dtCauti_EspecieEgreso.rows.add(ManInforme_AddEditExSitu.DataEspecieEgreso).draw();
    //Vertebrados Mayores
    columns_label = ["Especie", "Procedencia", "Nro. Individuos", "Tipo Identificación", "Código y/o Nombre", "Sexo", "Grado Amenaza", "Observación"];
    columns_data = ["DESCRIPCION", "DESC_PROCEDENCIA", "PROCEDENCIA_NUM_INDIVIDUOS", "DESC_TIDENTIFICACION", "CODIGO_NOMBRE", "SEXO", "DESC_ACATEGORIA", "OBSERVACION"];
    options = {
        page_length: 10, row_edit: true, row_fnEdit: "ManInforme_AddEditExSitu.fnAddEditEspecieCenso('ESPECIE_VERTEBRADO',this)"
        , row_delete: true, row_fnDelete: "ManInforme_AddEditExSitu.fnDeleteCautiverio('ESPECIE_VERTEBRADO',this)", row_index: true, page_sort: true
    };
    ManInforme_AddEditExSitu.dtCauti_EspecieVertebrado = utilDt.fnLoadDataTable_Detail(ManInforme_AddEditExSitu.frm.find("#tbCauti_EspecieVertebrado"), columns_label, columns_data, options);
    ManInforme_AddEditExSitu.dtCauti_EspecieVertebrado.rows.add(ManInforme_AddEditExSitu.DataEspecieCenso.filter(m => m.TIPO_VERTEBRADO == "MA")).draw();
    //Vertebrados Menores e Invertebrados
    columns_label = ["Especie", "Procedencia", "Nro. Individuos", "Grado Amenaza", "Observación"];
    columns_data = ["DESCRIPCION", "DESC_PROCEDENCIA", "PROCEDENCIA_NUM_INDIVIDUOS", "DESC_ACATEGORIA", "OBSERVACION"];
    options = {
        page_length: 10, row_edit: true, row_fnEdit: "ManInforme_AddEditExSitu.fnAddEditEspecieCenso('ESPECIE_INVERTEBRADO',this)"
        , row_delete: true, row_fnDelete: "ManInforme_AddEditExSitu.fnDeleteCautiverio('ESPECIE_INVERTEBRADO',this)", row_index: true, page_sort: true
    };
    ManInforme_AddEditExSitu.dtCauti_EspecieInvertebrado = utilDt.fnLoadDataTable_Detail(ManInforme_AddEditExSitu.frm.find("#tbCauti_EspecieInvertebrado"), columns_label, columns_data, options);
    ManInforme_AddEditExSitu.dtCauti_EspecieInvertebrado.rows.add(ManInforme_AddEditExSitu.DataEspecieCenso.filter(m => m.TIPO_VERTEBRADO == "MI")).draw();
    //Balance de Ingresos y Egresos de Especímenes
    columns_label = ["Especie", "Censo incial", "Cantidad ingreso", "Fecha ingreso", "Documento ingreso", "Motivo ingreso", "Observación ingreso", "Cantidad egreso", "Fecha egreso", "Documento egreso", "Motivo egreso", "Observación egreso", "Balance previo", "Censo final"];
    columns_data = ["NOMBRE_COMUN", "CENSO_INICIAL", "CANT_INGRESO", "FECHA_INGRESO", "DOCUMENTO_INGRESO", "MOTIVO_INGRESO", "OBSERV_INGRESO", "CANT_EGRESO", "FECHA_EGRESO", "DOCUMENTO_EGRESO", "MOTIVO_EGRESO", "OBSERV_EGRESO", "BALANCE_PREVIO", "CENSO_FINAL"];
    options = {
        page_length: 10, row_edit: false, row_delete: true, row_fnDelete: "ManInforme_AddEditExSitu.fnDeleteCautiverio('BALANCE_ING_EGR',this)", row_index: true, page_sort: true
    };
    ManInforme_AddEditExSitu.dtCauti_BalanceIngEgr = utilDt.fnLoadDataTable_Detail(ManInforme_AddEditExSitu.frm.find("#tbCauti_BalanceIngEgr"), columns_label, columns_data, options);
    ManInforme_AddEditExSitu.dtCauti_BalanceIngEgr.rows.add(ManInforme_AddEditExSitu.DataBalanceIngEgr).draw();
    //Educación Ambiental
    columns_label = ["Tema", "Fecha del Evento", "Observación"];
    columns_data = ["DESCRIPCION", "FECHA_EVENTO", "OBSERVACION"];
    options = {
        page_length: 10, row_edit: true, row_fnEdit: "ManInforme_AddEditExSitu.fnAddEditActEducacion(this)"
        , row_delete: true, row_fnDelete: "ManInforme_AddEditExSitu.fnDeleteCautiverio('ACTIVIDAD_EDUCACION',this)", row_index: true, page_sort: true
    };
    ManInforme_AddEditExSitu.dtCauti_ActEducacion = utilDt.fnLoadDataTable_Detail(ManInforme_AddEditExSitu.frm.find("#tbCauti_ActEducacion"), columns_label, columns_data, options);
    ManInforme_AddEditExSitu.dtCauti_ActEducacion.rows.add(ManInforme_AddEditExSitu.DataActEducacion).draw();
    //Investigación Científica
    columns_label = ["Investigación", "Fecha de Publicación", "Objetivo"];
    columns_data = ["INVESTIGACION_REALIZADA", "FECHA_PUBLICACION", "OBJETIVO"];
    var data_extend = [
        {
            "data": "PUBLICADO", "title": "Publicado", "orderable": false, "searchable": false, "mRender": function (data, type, row, meta) {
                if (data == true) { return '<i class="fa fa-lg fa-check-circle-o" title="Publicado"></i>'; }
                else { return '<i class="fa fa-lg fa-circle-o" title="No Publicado"></i>'; }
            }
        }
    ];
    options = {
        page_length: 10, row_edit: true, row_fnEdit: "ManInforme_AddEditExSitu.fnAddEditActInvestigacion(this)"
        , row_delete: true, row_fnDelete: "ManInforme_AddEditExSitu.fnDeleteCautiverio('ACTIVIDAD_INVESTIGACION',this)", row_index: true, page_sort: true
        , data_extend: data_extend
    };
    ManInforme_AddEditExSitu.dtCauti_ActInvestigacion = utilDt.fnLoadDataTable_Detail(ManInforme_AddEditExSitu.frm.find("#tbCauti_ActInvestigacion"), columns_label, columns_data, options);
    ManInforme_AddEditExSitu.dtCauti_ActInvestigacion.rows.add(ManInforme_AddEditExSitu.DataActInvestigacion).draw();
    //Evaluación ZoObservatorio
    columns_label = ["Indicadores"];
    columns_data = ["CRITERIO_EVALZOO"];
    var data_extend = [
        {
            "data": "CALIFICACION", "title": "Todos", "width": "3%", "orderable": false, "searchable": false, "mRender": function (data, type, row, meta) {
                var checked = (data == "2") ? "checked" : "";
                return '<div class="custom-control custom-radio custom-control-inline"><input type="radio" class="custom-control-input" name="chkEvalIndicador_' + meta.row + '" id="chkEvalIndicador2_' + meta.row + '" ' + checked + ' value="2" onchange="ManInforme_AddEditExSitu.fnCalcCalificacionZoo()"><label class="custom-control-label" for="chkEvalIndicador2_' + meta.row + '"></label></div>';
            }
        },
        {
            "data": "CALIFICACION", "title": "Algunos", "width": "3%", "orderable": false, "searchable": false, "mRender": function (data, type, row, meta) {
                var checked = (data == "1") ? "checked" : "";
                return '<div class="custom-control custom-radio custom-control-inline"><input type="radio" class="custom-control-input" name="chkEvalIndicador_' + meta.row + '" id="chkEvalIndicador1_' + meta.row + '" ' + checked + ' value="1" onchange="ManInforme_AddEditExSitu.fnCalcCalificacionZoo()"><label class="custom-control-label" for="chkEvalIndicador1_' + meta.row + '"></label></div>';
            }
        },
        {
            "data": "CALIFICACION", "title": "Ninguno", "width": "3%", "orderable": false, "searchable": false, "mRender": function (data, type, row, meta) {
                var checked = (data == "0") ? "checked" : "";
                return '<div class="custom-control custom-radio custom-control-inline"><input type="radio" class="custom-control-input" name="chkEvalIndicador_' + meta.row + '" id="chkEvalIndicador0_' + meta.row + '" ' + checked + ' value="0" onchange="ManInforme_AddEditExSitu.fnCalcCalificacionZoo()"><label class="custom-control-label" for="chkEvalIndicador0_' + meta.row + '"></label></div>';
            }
        },
        {
            "data": "OBSERVACION", "title": "Observaciones", "width": "50%", "orderable": false, "searchable": false, "mRender": function (data, type, row, meta) {
                return '<input class="form-control form-control-sm" type="text" value="' + data + '" style="width:100%;">';
            }
        }
    ];
    options = {
        page_length: 15, row_index: true, data_extend: data_extend, page_autowidth: false
    };
    ManInforme_AddEditExSitu.dtZoo_Evaluacion = utilDt.fnLoadDataTable_Detail(ManInforme_AddEditExSitu.frm.find("#tbZoo_Evaluacion"), columns_label, columns_data, options);
    ManInforme_AddEditExSitu.dtZoo_Evaluacion.rows.add(ManInforme_AddEditExSitu.DataEvalZoObservatorio).draw();
}

ManInforme_AddEditExSitu.fnInit = function () {
    $.fn.select2.defaults.set("theme", "bootstrap4");
    ManInforme_AddEditExSitu.frm.find("#ddlOdId").select2();
    ManInforme_AddEditExSitu.frm.find("#ddlProgContencionId").select2({ minimumResultsForSearch: -1 });
    ManInforme_AddEditExSitu.frm.find("#ddlProgBioseguridadId").select2({ minimumResultsForSearch: -1 });
    ManInforme_AddEditExSitu.frm.find("#ddlFrecLimpiezaId").select2({ minimumResultsForSearch: -1 });
    ManInforme_AddEditExSitu.frm.find("#ddlDispResiduoOrgId").select2({ minimumResultsForSearch: -1 });
    ManInforme_AddEditExSitu.frm.find("#ddlDispResiduoInorgId").select2({ minimumResultsForSearch: -1 });
    ManInforme_AddEditExSitu.frm.find("#ddlDispResiduoCadaverId").select2({ minimumResultsForSearch: -1 });
    ManInforme_AddEditExSitu.frm.find("#ddlFrecDesinfeccionId").select2({ minimumResultsForSearch: -1 });
    ManInforme_AddEditExSitu.frm.find("#ddlProgEnriquecimientoId").select2({ minimumResultsForSearch: -1 });
    ManInforme_AddEditExSitu.frm.find("#ddlProgGeneticoId").select2({ minimumResultsForSearch: -1 });
    ManInforme_AddEditExSitu.frm.find("#ddlProgEducacionId").select2({ minimumResultsForSearch: -1 });
    ManInforme_AddEditExSitu.frm.find("#ddlProgInvetigacionId").select2({ minimumResultsForSearch: -1 });
    ManInforme_AddEditExSitu.frm.find("#ddlProgCapturaId").select2({ minimumResultsForSearch: -1 });
    ManInforme_AddEditExSitu.frm.find("#ddlProgCapacitacionId").select2({ minimumResultsForSearch: -1 });
    ManInforme_AddEditExSitu.frm.find("#ddlEquipoLimpiezaId").select2({ minimumResultsForSearch: -1 });
    ManInforme_AddEditExSitu.frm.find("#ddlMaterialDesinfeccionId").select2({ minimumResultsForSearch: -1 });
    ManInforme_AddEditExSitu.frm.find("#ddlProtContingenciaId").select2({ minimumResultsForSearch: -1 });
    ManInforme_AddEditExSitu.frm.find("#ddlProtAccionId").select2({ minimumResultsForSearch: -1 });
    ManInforme_AddEditExSitu.frm.find("#ddlPresentInfEjecPMId").select2({ minimumResultsForSearch: -1 });

    utilSigo.fnFormatDate(ManInforme_AddEditExSitu.frm.find("#txtFechaEntrega"));
    utilSigo.fnFormatDate(ManInforme_AddEditExSitu.frm.find("#txtFecIniRegencia"));

    //CKEDITOR.replace('txtConclusion', {
    //    toolbar: initSigo.configuracionCKEDITOR
    //});
    if (window.ckeditorConfig) {
        DecoupledDocumentEditor.create($('#txtConclusion .editor')[0], ckeditorConfig).then(function (editor) {
            window.editor_txtConclusion = editor;
            $("#txtConclusion .toolbar-container").append(editor.ui.view.toolbar.element);
        });
    }

    //Descripción frecuencia limpieza: Otros
    ManInforme_AddEditExSitu.fnShowFrecLimpieza();
    ManInforme_AddEditExSitu.frm.find("#ddlFrecLimpiezaId").change(function () {
        ManInforme_AddEditExSitu.fnShowFrecLimpieza();
    });
    //Descripción frecuencia desinfección: Otros
    ManInforme_AddEditExSitu.fnShowFrecDesinfeccion();
    ManInforme_AddEditExSitu.frm.find("#ddlFrecDesinfeccionId").change(function () {
        ManInforme_AddEditExSitu.fnShowFrecDesinfeccion();
    });
};

ManInforme_AddEditExSitu.fnShowFrecLimpieza = function () {
    ManInforme_AddEditExSitu.frm.find("#dvFrecLimpieza").hide();
    if (ManInforme_AddEditExSitu.frm.find("#ddlFrecLimpiezaId").val() == "0000188") {
        ManInforme_AddEditExSitu.frm.find("#dvFrecLimpieza").show();
    }
}
ManInforme_AddEditExSitu.fnShowFrecDesinfeccion = function () {
    ManInforme_AddEditExSitu.frm.find("#dvFrecDesinfeccion").hide();
    if (ManInforme_AddEditExSitu.frm.find("#ddlFrecDesinfeccionId").val() == "0000188") {
        ManInforme_AddEditExSitu.frm.find("#dvFrecDesinfeccion").show();
    }
}

ManInforme_AddEditExSitu.fnSubmitForm = function () {


    var checkbox = $('#divAspectosEvaluados input[type=checkbox]:checked');
    console.log(checkbox);
    if (checkbox.length == 0) {
        utilSigo.toastWarning("Aviso", "Debe Seleccionar como mínimo un Aspecto Evaluado");
        return false;
    }


    var controls = ["ddlIndicadorId", "ddlOdId", "txtNumInforme", "txtFechaInicio", "txtFechaFin", "txtFechaEntrega"];
    if (!utilSigo.fnValidateForm(ManInforme_AddEditExSitu.frm, controls)) {
        return ManInforme_AddEditExSitu.frm.valid();
    }
    if (!_renderObligacionMandatos.fnValidate()) {
        return false;
    }
    ManInforme_AddEditExSitu.frm.submit();
};

ManInforme_AddEditExSitu.fnSaveForm = function () {

    
    utilSigo.blockUIGeneral();
    let data = ManInforme_AddEditExSitu.Denuncia.objDeuncia;
    data.IATENDIDO = $('input[name="rbtnAtendido"]:checked').val();
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

            var datosInforme = ManInforme_AddEditExSitu.frm.serializeObject();
            datosInforme.vmInfCNotificacion = {};
            datosInforme.vmControlCalidad = _ControlCalidad.fnGetDatosControlCalidad();
            datosInforme.chkPublicar = Boolean(parseInt(ManInforme_AddEditExSitu.frm.find('input[name="chkPublicar"]:checked').val()));
            datosInforme.chkRecomendar = Boolean(parseInt(ManInforme_AddEditExSitu.frm.find('input[name="chkRecomendar"]:checked').val()));
           // datosInforme.txtConclusion = CKEDITOR.instances["txtConclusion"].getData();
            datosInforme.txtConclusion = window.editor_txtConclusion.getData();
            datosInforme.vmInfCNotificacion = _renderCNotificacion.fnGetDatosCNotificacion();
            datosInforme.chkLicFuncionamiento = utilSigo.fnGetValChk(ManInforme_AddEditExSitu.frm.find("#chkLicFuncionamiento"));
            datosInforme.chkTodos = utilSigo.fnGetValChk(ManInforme_AddEditExSitu.frm.find("#chkTodos"));
            datosInforme.chkHechos = utilSigo.fnGetValChk(ManInforme_AddEditExSitu.frm.find("#chkHechos"));
            datosInforme.chkMandatos = utilSigo.fnGetValChk(ManInforme_AddEditExSitu.frm.find("#chkMandatos"));
            datosInforme.chkMedidas = utilSigo.fnGetValChk(ManInforme_AddEditExSitu.frm.find("#chkMedidas"));
            datosInforme.chkFFPropia = utilSigo.fnGetValChk(ManInforme_AddEditExSitu.frm.find("#chkFFPropia"));
            datosInforme.chkFFDonaciones = utilSigo.fnGetValChk(ManInforme_AddEditExSitu.frm.find("#chkFFDonaciones"));
            datosInforme.chkFFCredito = utilSigo.fnGetValChk(ManInforme_AddEditExSitu.frm.find("#chkFFCredito"));
            datosInforme.chkFFInversionista = utilSigo.fnGetValChk(ManInforme_AddEditExSitu.frm.find("#chkFFInversionista"));
            datosInforme.chkFFApoyo = utilSigo.fnGetValChk(ManInforme_AddEditExSitu.frm.find("#chkFFApoyo"));
            datosInforme.chkFFVoluntario = utilSigo.fnGetValChk(ManInforme_AddEditExSitu.frm.find("#chkFFVoluntario"));
            datosInforme.chkRegente = utilSigo.fnGetValChk(ManInforme_AddEditExSitu.frm.find("#chkRegente"));
            datosInforme.chkRecibeVisita = utilSigo.fnGetValChk(ManInforme_AddEditExSitu.frm.find("#chkRecibeVisita"));
            datosInforme.chkReproduceEspCautiverio = utilSigo.fnGetValChk(ManInforme_AddEditExSitu.frm.find("#chkReproduceEspCautiverio"));
            datosInforme.vmDatoSupervision = _renderDatosSupervision.fnGetDatosSupervision();
            datosInforme.tbSupervisor = _renderSupervisor.fnGetList();
             
            //Infraestructura
            datosInforme.chkCroquis = utilSigo.fnGetValChk(ManInforme_AddEditExSitu.frm.find("#chkCroquis"));
            datosInforme.chkViaSenalizada = utilSigo.fnGetValChk(ManInforme_AddEditExSitu.frm.find("#chkViaSenalizada"));
            datosInforme.chkCartelAreaAdmin = utilSigo.fnGetValChk(ManInforme_AddEditExSitu.frm.find("#chkCartelAreaAdmin"));
            datosInforme.chkCartelSSHH = utilSigo.fnGetValChk(ManInforme_AddEditExSitu.frm.find("#chkCartelSSHH"));
            var listArea = ManInforme_AddEditExSitu.fnGetListArea("0000001");
            listArea = listArea.concat(ManInforme_AddEditExSitu.fnGetListArea("0000002"));
            listArea = listArea.concat(ManInforme_AddEditExSitu.fnGetListArea("0000003"));
            listArea = listArea.concat(ManInforme_AddEditExSitu.fnGetListArea("0000004"));
            listArea = listArea.concat(ManInforme_AddEditExSitu.fnGetListArea("0000005"));
            listArea = listArea.concat(ManInforme_AddEditExSitu.fnGetListArea("0000006"));
            datosInforme.tbAreaExSitu = listArea;
            //Cautiverio
            datosInforme.chkProgAlimentacion = utilSigo.fnGetValChk(ManInforme_AddEditExSitu.frm.find("#chkProgAlimentacion"));
            datosInforme.chkProtAlimentacion = utilSigo.fnGetValChk(ManInforme_AddEditExSitu.frm.find("#chkProtAlimentacion"));
            datosInforme.chkProtLimpieza = utilSigo.fnGetValChk(ManInforme_AddEditExSitu.frm.find("#chkProtLimpieza"));
            datosInforme.chkPediluvio = utilSigo.fnGetValChk(ManInforme_AddEditExSitu.frm.find("#chkPediluvio"));
            datosInforme.chkManejoResiduo = utilSigo.fnGetValChk(ManInforme_AddEditExSitu.frm.find("#chkManejoResiduo"));
            datosInforme.tbGrupoTaxonomico = ManInforme_AddEditExSitu.fnGetListCautiverio("GRUPO_TAXONOMICO");
            datosInforme.tbEquipoContFisico = ManInforme_AddEditExSitu.fnGetListCautiverio("CONTENCION_FISICA");
            datosInforme.tbEquipoContQuimico = ManInforme_AddEditExSitu.fnGetListCautiverio("CONTENCION_QUIMICA");
            datosInforme.tbEquipoLimpieza = ManInforme_AddEditExSitu.fnGetListCautiverio("EQUIPO_LIMPIEZA");
            datosInforme.tbMaterialDesinfeccion = ManInforme_AddEditExSitu.fnGetListCautiverio("MATERIAL_DESINFECCION");
            datosInforme.tbEquipoDesinfeccion = ManInforme_AddEditExSitu.fnGetListCautiverio("EQUIPO_DESINFECCION");
            datosInforme.tbControlPlaga = ManInforme_AddEditExSitu.fnGetListCautiverio("CONTROL_PLAGA");
            datosInforme.tbManejoRegistro = ManInforme_AddEditExSitu.fnGetListCautiverio("MANEJO_REGISTRO");
            datosInforme.tbEnriquecimientoAmb = ManInforme_AddEditExSitu.fnGetListCautiverio("ENRIQUECIMIENTO_AMBIENTAL");
            datosInforme.tbEspecieReproducida = ManInforme_AddEditExSitu.fnGetListCautiverio("ESPECIE_REPRODUCIDA");
            datosInforme.tbEspecieCapturada = ManInforme_AddEditExSitu.fnGetListCautiverio("ESPECIE_CAPTURADA");
            datosInforme.tbTraslocEspec = ManInforme_AddEditExSitu.fnGetListCautiverio("TRASLOC_ESPEC");
            datosInforme.tbCapacitacion = ManInforme_AddEditExSitu.fnGetListCautiverio("CAPACITACION");
            datosInforme.tbEspecieNacimiento = ManInforme_AddEditExSitu.fnGetListCautiverio("NACIMIENTO_ESPECIE");
            datosInforme.tbEspecieEgreso = ManInforme_AddEditExSitu.fnGetListCautiverio("EGRESO_ESPECIE");
            datosInforme.tbEspecieCenso = ManInforme_AddEditExSitu.fnGetListCautiverio("ESPECIE_VERTEBRADO");
            datosInforme.tbRelPelCentroCria = ManInforme_AddEditExSitu.fnGetListCautiverio("RELPER_CENTROCRIA");
            datosInforme.tbEspecieCenso = datosInforme.tbEspecieCenso.concat(ManInforme_AddEditExSitu.fnGetListCautiverio("ESPECIE_INVERTEBRADO"));
            datosInforme.tbActividadEducacion = ManInforme_AddEditExSitu.fnGetListCautiverio("ACTIVIDAD_EDUCACION");
            datosInforme.tbActividadInvestigacion = ManInforme_AddEditExSitu.fnGetListCautiverio("ACTIVIDAD_INVESTIGACION");
            datosInforme.tbEvalZoObservatorio = ManInforme_AddEditExSitu.fnGetListEvalZoo();
            datosInforme.tbEliTABLA = ManInforme_AddEditExSitu.tbEliTABLA;
            datosInforme.tbDesplazamiento = _renderDesplazamiento.fnGetList();
            datosInforme.tbEliTABLA = datosInforme.tbEliTABLA.concat(_renderDesplazamiento.fnGetListEliTABLA());
            datosInforme.tbPersonalTecProf = _renderPersonalTecProf.fnGetList();
            datosInforme.tbEliTABLA = datosInforme.tbEliTABLA.concat(_renderPersonalTecProf.fnGetListEliTABLA());
            datosInforme.tbEliTABLA = datosInforme.tbEliTABLA.concat(_renderSupervisor.fnGetListEliTABLA());
            datosInforme.tbBalanceIngEgr = ManInforme_AddEditExSitu.fnGetListCautiverio("BALANCE_ING_EGR");
            datosInforme.tbObligacionTitular = _renderObligacionTitular.fnGetList();
            datosInforme.ddlTipoInformeId = _renderDatosSupervision.frm.find("#ddlTipoInformeId").val();            
            datosInforme.tbMandatos = _renderMandatos.fnGetList();
            datosInforme.tbMandatos = datosInforme.tbMandatos.concat(_renderMandatos.fnGetListEliTABLA());
            datosInforme.tbEnfermedad = ManInforme_Enfermedad.fnGetEnfermedad();
            datosInforme.tbObligMandatos = _renderObligacionMandatos.fnGetList();
            datosInforme.tbObligMandatos = datosInforme.tbObligMandatos.concat(_renderObligacionMandatos.fnGetListEliTABLA());

            
            var option = { url: ManInforme_AddEditExSitu.frm[0].action, datos: JSON.stringify({ dto: datosInforme }), type: 'POST' };
            utilSigo.fnAjax(option, function (data) {
                if (data.success) {
                    ManInforme_AddEditExSitu.fnReturnIndex(data.msj);
                }
                else {
                    utilSigo.toastWarning("Aviso", data.msj);
                }
            });
        },
        statusCode: { 203: () => { utilSigo.unblockUIGeneral(); } }
    });
};

$(document).ready(function () {
    ManInforme_AddEditExSitu.frm = $("#frmManInforme_AddEditExSitu");

    ManInforme_AddEditExSitu.fnInit();
    ManInforme_AddEditExSitu.fnInitDataTable_Detail();

    ManInforme_AddEditExSitu.fnShowObsPublicar();
    ManInforme_AddEditExSitu.frm.find('input[name="chkPublicar"]').click(function () {
        ManInforme_AddEditExSitu.fnShowObsPublicar();
    });
    ManInforme_AddEditExSitu.frm.find('input[name="chkRecomendar"]').click(function () {
        //ManInforme_AddEditExSitu.fnShowObsPublicar();
    });
    ManInforme_AddEditExSitu.fnShowDatosLicFuncionamiento();
    ManInforme_AddEditExSitu.frm.find("#chkLicFuncionamiento").click(function () {
        ManInforme_AddEditExSitu.fnShowDatosLicFuncionamiento();
    });
    ManInforme_AddEditExSitu.fnShowDatosRegente();
    ManInforme_AddEditExSitu.frm.find("#chkRegente").click(function () {
        ManInforme_AddEditExSitu.fnShowDatosRegente();
    });

    ManInforme_AddEditExSitu.frm.find("#ddlEquipoLimpiezaId").change(function () {
        if ($(this).val() != "0000000") {
            ManInforme_AddEditExSitu.fnAddEquipoLimpieza("EQUIPO_LIMPIEZA");
            ManInforme_AddEditExSitu.frm.find("#ddlEquipoLimpiezaId").select2('val', ["0000000"]);
        }
    });
    ManInforme_AddEditExSitu.frm.find("#ddlMaterialDesinfeccionId").change(function () {
        if ($(this).val() != "0000000") {
            ManInforme_AddEditExSitu.fnAddEquipoLimpieza("MATERIAL_DESINFECCION");
            ManInforme_AddEditExSitu.frm.find("#ddlMaterialDesinfeccionId").select2('val', ["0000000"]);
        }
    });
    ManInforme_AddEditExSitu.frm.find("#ddlCuentaVetMedId").change(function () {
        if ($(this).val() == "0000002") {
            ManInforme_AddEditExSitu.frm.find("#divTipoMedVet").removeAttr('hidden');
            ManInforme_AddEditExSitu.frm.find("#divVisitaMedVet").removeAttr('hidden');
            ManInforme_AddEditExSitu.frm.find("#ddlTipoVisMedId").val("0000001");
            ManInforme_AddEditExSitu.frm.find("#txtVisitaporMes").val("");
            ManInforme_AddEditExSitu.frm.find("#txtObsMedVet").val("");
        } else {
            ManInforme_AddEditExSitu.frm.find("#divTipoMedVet").attr('hidden', 'hidden');
            ManInforme_AddEditExSitu.frm.find("#divVisitaMedVet").attr('hidden', 'hidden');
        }
    });

    //=====-----Para el registro de datos del formulario-----=====
    //Validación personalizada
    jQuery.validator.addMethod("invalidManInf_AddEditExSitu", function (value, element) {
        switch ($(element).attr('id')) {
            case 'ddlIndicadorId':
            case 'ddlOdId':
                return (value == '0000000') ? false : true;
                break
        }
    });
    ManInforme_AddEditExSitu.frm.validate(utilSigo.fnValidate({
        rules: {
            ddlIndicadorId: { invalidManInf_AddEditExSitu: true },
            ddlOdId: { invalidManInf_AddEditExSitu: true },
            txtNumInforme: { required: true },
            txtFechaInicio: { required: true },
            txtFechaFin: { required: true },
            txtFechaEntrega: { required: true }
        },
        messages: {
            ddlIndicadorId: { invalidManInf_AddEditExSitu: "Seleccione el estado actual del registro" },
            ddlOdId: { invalidManInf_AddEditExSitu: "Seleccione la oficina desconcentrada" },
            txtNumInforme: { required: "Ingrese el número del informe de supervisión" },
            txtFechaInicio: { required: "Seleccione la fecha de inicio de la supervisión" },
            txtFechaFin: { required: "Seleccione la fecha fin de la supervisión" },
            txtFechaEntrega: { required: "Seleccione la fecha de entrega del informe" }
        },
        fnSubmit: function (form) {
            utilSigo.dialogConfirm('', 'Desea continuar con el registro?', function (r) {
                if (r) {
                    ManInforme_AddEditExSitu.fnSaveForm();
                }
            });
        }
    }));
    //Validación de controles que usan Select2
    ManInforme_AddEditExSitu.frm.find("select.select2-hidden-accessible").on("change", function (e) {
        $(this).valid();
    });

    ManInforme_AddEditExSitu.Denuncia.objDeuncia.ENT_INFORME.COD_INFORME = $('#hdfCodInforme').val().trim();
    ManInforme_AddEditExSitu.Denuncia.obtenerDenuncia();
    ManInforme_AddEditExSitu.Incidencia.cargarIncidencias();
    ManInforme_AddEditExSitu.Incidencia.ui();
    ManInforme_AddEditExSitu.Incidencia.eventos();
});
