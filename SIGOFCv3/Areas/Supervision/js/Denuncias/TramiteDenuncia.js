var tramiteDenuncia = {
    tra_M_Tramite: null,
    tablaInforme: null,
    tablaInformeData: [],
    tablaCartaOficioData: [],
    objInforme: [],
    objInformeSITD: [],
    objInformeBackup: null,
    objAuditoria: [],
    objTHabilitante: [],
    B_FLAG_AUDITORIA: false,
    ui: function () {
        $('.osinforDenun').hide();
        $('.otroDenun').hide();
        $('.oosDenun').hide();
        utilSigo.blockUIGeneral();

        var option = {
            url: urlLocalSigo + "Supervision/Denuncias/ObtenerDataDenuncica",
            datos: JSON.stringify({
                tra_M_Tramite: {
                    cCodificacion: $('#cCodificacion').val(),
                    iCodTramite: $('#iCodTramite').val(),
                    iCodTupa: $('#iCodTupa').val(),
                    iCodTupaClase: $('#iCodTupaClase').val()
                }
            }),
            type: 'POST'
        };
        $.ajax({
            url: option.url,
            type: typeof option.type === 'undefined' ? 'GET' : option.type,
            data: typeof option.datos === 'undefined' ? {} : option.datos,
            contentType: typeof option.contentType === 'undefined' ? 'application/json; charset=utf-8' : option.contentType,
            dataType: typeof option.dataType === 'undefined' ? 'json' : option.dataType,
            error: utilSigo.errorAjax,
            success: function (data) {

                if (data.COD_IDENUNCIA !== null) {
                    $('#COD_IDENUNCIA').val(data.COD_IDENUNCIA);
                    //if (data.ICOMPETENCIA === 1) {
                    //    $('#cboAtencion').val('01');
                    //} else if (data.ICOMPETENCIA === 2) {
                    //    $('#cboAtencion').val('02');
                    //}
                    // 
                    //tramiteDenuncia.tra_M_Tramite = tramite;

                    if (data.FLAG_THABILITANTE == 1) {
                        $('#rbtnTHabilitanteSi').prop('checked', true);
                        $('.isupervision').removeClass('d-none');
                        $('.thabilitante').removeClass('d-none');
                    }
                    if (data.FLAG_THABILITANTE == 2) {
                        $('#rbtnTHabilitanteNo').prop('checked', true);
                        $('.isupervision').addClass('d-none');
                        $('.thabilitante').addClass('d-none');

                        tramiteDenuncia.objInformeSITD = {};
                        $('#inptTramiteDenuncia').val('');
                    }
                    if (data.TIPO_REQUERIMIENTO.length > 0) $('#cboTipoRequerimiento').val(data.TIPO_REQUERIMIENTO);
                    if (data.TIPO_REQUERIMIENTO_OTRO.length > 0) $('#txtOtros').val(data.TIPO_REQUERIMIENTO_OTRO);
                    if (data.TIPO_TRASLADO.length > 0) $('#cboSubEstado').val(data.TIPO_TRASLADO);
                    if (data.TIPO_REQUERIMIENTO == 'Otros') {
                        $('.txtOtros').removeClass('d-none');
                    }
                    tramiteDenuncia.objInforme = data.IDenunciaDetInformeSupervision;
                    tramiteDenuncia.objInformeBackup = data.IDenunciaDetInformeSupervision;
                    //IDenunciaDetInformeSupervision

                    //$('#inptTramiteDenuncia').val(tramiteDenuncia.objInforme.NUMERO);
                    if (data.ICOMPETENCIA === 2) {
                        $('#inptEntidad').val(data.NOMBRE_DEPENDENCIA);
                    }
                    if (data.iDENUNCIA_THABILITANTEs !== null) {
                        tramiteDenuncia.objTHabilitante = data.iDENUNCIA_THABILITANTEs;
                        let rptaStr = '';
                        let cto = 1;
                        let str = '';

                        if (data.iDENUNCIA_THABILITANTEs.length > 0) {

                            str += '<div class="table-responsive">';
                            str += '<table class="table table-bordered">';
                            str += '<thead><tr>';
                            str += '<th scope="col">#</th>';
                            str += '<th scope="col">FECHA</th>';
                            str += '<th scope="col">MODALIDAD</th>';
                            str += '<th scope="col">NUMERO</th>';
                            str += '<th scope="col">PERSONA TITULAR</th>';
                            str += '</tr></thead><tbody>';
                            data.iDENUNCIA_THABILITANTEs.forEach(
                                (value) => {
                                    rptaStr += value.ent_THABILITANTE.NUMERO + ',';
                                    str += "<tr>";
                                    str += '<th scope="row">' + cto++ + '</th>';
                                    str += '<td scope="col">' + value.ent_THABILITANTE.FECHA + '</td>';
                                    str += '<td scope="col">' + value.ent_THABILITANTE.MODALIDAD + '</td>';
                                    str += '<td scope="col">' + value.ent_THABILITANTE.NUMERO + '</td>';
                                    str += '<td scope="col">' + value.ent_THABILITANTE.PERSONA_TITULAR + '</td>';
                                    str += '</tr>';
                                });
                            str += '</tbody></table>';
                            str += '</div>';

                        }
                        $('#htmlTHabilitante').html(str);
                        $('#inptTHabilitante').val(utilSigo.recortarTextos(rptaStr.substring(0, rptaStr.length - 1), 40));
                        $('#lblTHabilitante').html("T. Habilitante (" + data.iDENUNCIA_THABILITANTEs.length + ")");

                    }
                    if (data.IDenunciaDetInformeSupervision !== null) {
                        tramiteDenuncia.objInforme = data.IDenunciaDetInformeSupervision;
                        let rptaStr = '';
                        let cto = 1;
                        let str = '';

                        if (data.IDenunciaDetInformeSupervision.length > 0) {
                            str += '<div class="card-body">';
                            str += '<div class="table-responsive">';
                            str += '<table class="table table-bordered">';
                            str += '<thead><tr>';
                            str += '<th scope="col">#</th>';
                            str += '<th scope="col">INFORME SUPERVISION</th>';
                            str += '<th scope="col">POA</th>';
                            str += '</tr></thead><tbody>';
                            data.IDenunciaDetInformeSupervision.forEach(
                                (value) => {

                                    rptaStr += value.ent_INFORME.NUMERO + ',';
                                    str += "<tr>";
                                    str += '<th scope="row">' + cto++ + '</th>';
                                    str += '<td scope="col">' + value.ent_INFORME.NUMERO + '</td>';
                                    str += '<td scope="col">';

                                    if (value.ent_INFORME.ListPOAs.length > 0) {
                                        value.ent_INFORME.ListPOAs.forEach(
                                            (poa) => {
                                                str += ' <div class="custom-control custom-checkbox ">';
                                                str += '   <input type="checkbox" class="custom-control-input poas " name="' + value.VCODINFORME + '" id="' + poa.NUM_POA + '">';
                                                str += '   <label class="custom-control-label" for="' + poa.NUM_POA + '">' + poa.POA + '</label>';
                                                str += '</div>';
                                            }
                                        );
                                    }
                                    str += '</td>';
                                    str += '</tr>';
                                });
                            str += '</tbody></table>';
                            str += '</div>';
                            str += '</div>';
                        }
                        $('#htmlSupervision').html(str);
                        $('#inptTramiteDenuncia').val(utilSigo.recortarTextos(rptaStr.substring(0, rptaStr.length - 1), 40));
                        $('#lblTramiteDenuncia').html("Informes de Supervisión (" + data.IDenunciaDetInformeSupervision.length + ")");
                        // 
                        if (data.ENT_INFORME) {
                            let lst = data.ENT_INFORME.ListPOAs;
                            $.each($('.poas'), function (i, x) {
                                for (var i = 0; i < lst.length; i++) {
                                    if (lst[i].NUM_POA == x.id) {
                                        x.checked = true; break;
                                    }
                                }

                            });
                        }

                    }
                    if (data.IDenunciaDetDocumentosSITD !== null) {
                        tramiteDenuncia.objInformeSITD = data.IDenunciaDetDocumentosSITD;
                        let rptaStr = '';
                        let cto = 1;
                        let str = '';
                        if (data.IDenunciaDetDocumentosSITD.length > 0) {
                            //str += '<div class="card-body">';
                            str += '<div class="table-responsive">';
                            str += '<table class="table table-bordered">';
                            str += '<thead><tr>';
                            str += '<th scope="col">#</th>';
                            str += '<th scope="col">Cod Tramite</th>';
                            str += '<th scope="col">Codificación</th>';
                            str += '<th scope="col">Descripción</th>';
                            str += '<th scope="col">Asunto</th>';
                            str += '<th scope="col">#</th>';
                            str += '</tr></thead><tbody>';
                            data.IDenunciaDetDocumentosSITD.forEach(
                                (value) => {

                                    rptaStr += value.VCODTRAMITE + ',';
                                    str += "<tr>";
                                    str += '<th scope="row">' + cto++ + '</th>';
                                    str += '<td scope="col">' + value.VCODTRAMITE + '</td>';
                                    str += '<td scope="col">' + value.VCODIFICACION + '</td>';

                                    str += '<td scope="col">' + value.VDESCTIPODOC + '</td>';
                                    str += '<td scope="col">' + value.VASUNTO + '</td>';
                                    str += '<td scope="col">';
                                    if (value.VPDF_TRAMITE_SITD.length > 1) str += '<a title="Descargar Documento" href=" https://sitd.osinfor.gob.pe:8443/std/cInterfaseUsuario_SITD/download.php?direccion=sitd-almacen&file=' + value.VPDF_TRAMITE_SITD + '"><i class="fa fa-lg fa-download" style="cursor: pointer; color: dodgerblue; " title="Descargar Documento"></i></a>';
                                    str += '</td>';
                                    str += '</tr>';
                                });
                            str += '</tbody></table>';
                            str += '</div>';
                            // str += '</div>';


                        }
                        $('#inptInformesSITD').val(utilSigo.recortarTextos(rptaStr.substring(0, rptaStr.length - 1), 40));
                        $('#lblInformesSITD').html("Informe / Carta / Oficios(" + data.IDenunciaDetDocumentosSITD.length + ")");
                        $('#htmlDocSITD').html(str);

                    }

                    if (data.IDENUNCIA_ITECNICOS !== null) {
                        tramiteDenuncia.tablaInformeData = data.IDENUNCIA_ITECNICOS;
                        let rptaStr = '';
                        let cto = 1;
                        let str = '';

                        if (data.IDENUNCIA_ITECNICOS.length > 0) {

                            str += '<div class="table-responsive">';
                            str += '<table class="table table-bordered">';
                            str += '<thead><tr>';
                            str += '<th scope="col">#</th>';
                            str += '<th scope="col">INFORME SUPERVISION</th>';
                            str += '</tr></thead><tbody>';
                            data.IDENUNCIA_ITECNICOS.forEach(
                                (value) => {
                                    rptaStr += value.NOMBRE_INFORME.trim() + ",";
                                    str += "<tr>";
                                    str += '<th scope="row">' + cto++ + '</th>';
                                    str += '<td scope="col">' + value.NOMBRE_INFORME.trim() + '</td>';
                                    str += '</tr>';

                                });
                            str += '</tbody></table>';
                            str += '</div>';

                        }
                        $('#inptInformeTecnico').val(rptaStr.substring(0, rptaStr.length - 1));
                        $('#lblInformeTecnico').html('Archivos adicionales  (' + data.IDENUNCIA_ITECNICOS.length + ')');
                        $('#htmlArchivos').html(str);

                    }
                    tramiteDenuncia.tablaCartaOficioData = data.IDENUNCIA_CARTA_OFICIO;
                    if (data.iDENUNCIA_AUDITORIA_ARCHIVO !== null) {
                        tramiteDenuncia.objAuditoria = data.iDENUNCIA_AUDITORIA_ARCHIVO;
                        let str = '';
                        $.each(data.iDENUNCIA_AUDITORIA_ARCHIVO, function (index, value) {
                            str += value.NOMBRE_ARCHIVO.trim() + ",";
                        });
                        $('#lblArchivoAuditoria').html(utilSigo.recortarTextos(str.substring(0, str.length - 1), 40));
                        tramiteDenuncia.B_FLAG_AUDITORIA = true;
                    } else {
                        tramiteDenuncia.objAuditoria = [];
                        tramiteDenuncia.B_FLAG_AUDITORIA = false;
                    }
                    let countFalso = 1;
                    var informe = '';
                    $.each(tramiteDenuncia.tablaInformeData, function (index, value) {
                        value.id_falso = countFalso++;
                        informe += value.NOMBRE_INFORME.trim() + ",";
                    });
                    $('#inptInformeTecnico').val(informe.substring(0, informe.length - 1));
                    $('#lblInformeTecnico').html('Archivos adicionales  (' + tramiteDenuncia.tablaInformeData.length + ')');

                    countFalso = 1;
                    informe = '';
                    $.each(tramiteDenuncia.tablaCartaOficioData, function (index, value) {
                        value.id_falso = countFalso++;
                        informe += value.NOMBRE_INFORME.trim() + ",";
                    });
                    $('#inptCartaOficios').val(informe.substring(0, informe.length - 1));
                    $('#lblCartaOficios').html('Carta y Oficios(' + tramiteDenuncia.tablaCartaOficioData.length + ')');


                    $('#txtConclusionDenuncia').val(data.CONCLUSION);
                    $('#txtRecomendacionDenuncia').val(data.RECOMENDACION);

                    if (data.IATENDIDO === 1) {
                        $('#rbtnAtendido1').prop('checked', true);
                        $('.cboSubEstado').removeClass('d-none');
                    } else if (data.IATENDIDO === 2) {

                        $('#rbtnAtendido2').prop('checked', true);

                    }

                } else $('#rbtnAtendido2').prop('checked', true);
            },
            complete: function () {
                utilSigo.unblockUIGeneral();
            },
            statusCode: {
                203: () => { utilSigo.unblockUIGeneral(); }
            }
        });

    },
    eventos: function () {

        $('input[name=rbtnTHabilitante]').on('change', function () {
            $('#inptEntidad').val('');
            tramiteDenuncia.tablaInformeData = [];
            tramiteDenuncia.tablaCartaOficioData = [];
            $('#inptInformeTecnico').val('');
            $('#lblInformeTecnico').html('Archivos adicionales  (0)');

            $('#inptCartaOficios').val('');
            $('#lblCartaOficios').html('Carta y Oficios (0)');

            $('#txtConclusionDenuncia').val('');
            $('#txtRecomendacionDenuncia').val('');
            $('#lblArchivoAuditoria').html('Sin Archivos');
            tramiteDenuncia.objAuditoria = [];
            tramiteDenuncia.B_FLAG_AUDITORIA = false;
            if ($(this).val() == 1) {
                $('.isupervision').removeClass('d-none');
                $('.thabilitante').removeClass('d-none');
                //if (tramiteDenuncia.objInformeBackup !== null) {
                //    tramiteDenuncia.objInforme = tramiteDenuncia.objInformeBackup;
                //   // $('#inptTramiteDenuncia').val(tramiteDenuncia.objInforme.NUMERO);
                //}


            } else if ($(this).val() == 2) {
                $('.isupervision').addClass('d-none');
                $('.thabilitante').addClass('d-none');
                tramiteDenuncia.objTHabilitante = [];
                tramiteDenuncia.objInforme = [];
                $('#inptTHabilitante').val('');
                $('#inptTramiteDenuncia').val('');
                $('#htmlTHabilitante').html('');
            }

        });
        $('input[name=rbtnAtendido]').on('change', function () {
            if ($(this).val() == 2) {
                $('.cboSubEstado').addClass('d-none');
                $('#cboSubEstado').val('');
            } else { $('.cboSubEstado').removeClass('d-none'); }
        })
        $("#idArchivoAuditoria").change(function () {
            tramiteDenuncia.objAuditoria = [];
            $('#lblArchivoAuditoria').html(utilSigo.recortarTextos(obtenerFilesNombres(this.files), 40));
            tramiteDenuncia.B_FLAG_AUDITORIA = false;
        });
        $('#cboTipoRequerimiento').on('change', function () {
            if ($(this).val() == 'Otros') {
                $('.txtOtros').removeClass('d-none');
            } else { $('.txtOtros').addClass('d-none'); $('#txtOtros').val(''); }
        });
    },
    fnReturnIndex: function () {
        var url = urlLocalSigo + "Supervision/Denuncias/IndexDenuncia";
        window.location = url;
    },
    modalInformes: function () {
        var url = urlLocalSigo + "Supervision/ManInforme/modalInforme";
        var option = {
            url: url,
            type: 'GET',
            datos: {},
            divId: "mdlManInforme_Informes"
        };
        utilSigo.fnOpenModal(option, function () { }, function () {
            var informe = '';
            let cto = 1;
            let str = '';
            //str += '<div class="card-body">';
            str += '<div class="table-responsive">';
            str += '<table class="table table-bordered">';
            str += '<thead><tr>';
            str += '<th scope="col">#</th>';
            str += '<th scope="col">Archivos</th>';
            str += '</tr></thead><tbody>';
            $.each(tramiteDenuncia.tablaInformeData, function (index, value) {
                informe += value.NOMBRE_INFORME.trim() + ",";
                str += "<tr>";
                str += '<th scope="row">' + cto++ + '</th>';
                str += '<td scope="col">' + value.NOMBRE_INFORME.trim() + '</td>';
                str += '</tr>';
            });
            if (tramiteDenuncia.tablaInformeData.length == 0) {
                str += "<tr>";
                str += '<td  colspan="2" style="text-align: center;" >Sin datos</td>';
                str += '</tr>';
            }
            str += '</tbody></table>';
            str += '</div>';
            //str += '</div>';

            $('#inptInformeTecnico').val(informe.substring(0, informe.length - 1));
            $('#lblInformeTecnico').html('Archivos adicionales  (' + tramiteDenuncia.tablaInformeData.length + ')');
            $('#htmlArchivos').html(str);

        });
    },
    modalCartasOficios: function () {
        var url = urlLocalSigo + "Supervision/ManInforme/modalCartaOficios";
        var option = {
            url: url,
            type: 'GET',
            datos: {},
            divId: "mdlManInforme_CartaOficio"
        };
        utilSigo.fnOpenModal(option, function () { }, function () {
            var informe = '';

            $.each(tramiteDenuncia.tablaCartaOficioData, function (index, value) {
                informe += value.NOMBRE_INFORME.trim() + ",";
            });
            $('#inptCartaOficios').val(informe.substring(0, informe.length - 1));
            $('#lblCartaOficios').html('Carta y Oficios (' + tramiteDenuncia.tablaCartaOficioData.length + ')');

        });
    },
    modalTitulohabilitante: function () {
        //      
        var url = urlLocalSigo + "Supervision/Denuncias/modalTHabilitante";
        var option = {
            url: url,
            type: 'GET',
            datos: {},
            divId: "mdlManInforme_THabilitante"
        };
        utilSigo.fnOpenModal(option, function () { }, function () {

        });
    },
    //informes de supervision
    modalDocInformes: function () {
        //  
        var url = urlLocalSigo + "Supervision/Denuncias/modalDocInforme";
        var option = {
            url: url,
            type: 'GET',
            datos: {},
            divId: "mdlManInforme_DOCINFORME"
        };
        utilSigo.fnOpenModal(option, function () { }, function () {
            $.ajax({
                url: urlLocalSigo + 'Supervision/Denuncias/ConsultarPoas',
                type: 'POST',
                data: JSON.stringify({ IDenunciaDetInformeSupervision: tramiteDenuncia.objInforme }),
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                error: utilSigo.errorAjax,
                success: function (d) {
                    console.log('result', d);
                    tramiteDenuncia.objInforme = d;
                    let data = '';
                    let cto = 1;
                    let str = '';
                    if (tramiteDenuncia.objInforme.length > 0) {

                        str += '<div class="table-responsive">';
                        str += '<table class="table table-bordered">';
                        str += '<thead><tr>';
                        str += '<th scope="col">#</th>';
                        str += '<th scope="col">INFORME SUPERVISION</th>';
                        str += '<th scope="col">POA</th>';
                        str += '</tr></thead><tbody>';
                        tramiteDenuncia.objInforme.forEach(
                            (value) => {
                                // 
                                data += value.ent_INFORME.NUMERO + ',';
                                str += "<tr>";
                                str += '<th scope="row">' + cto++ + '</th>';
                                str += '<td scope="col">' + value.ent_INFORME.NUMERO + '</td>';
                                str += '<td scope="col">';

                                if (value.ent_INFORME.ListPOAs.length > 0) {
                                    value.ent_INFORME.ListPOAs.forEach(
                                        (poa) => {
                                            str += ' <div class="custom-control custom-checkbox ">';
                                            str += '   <input type="checkbox" class="custom-control-input poas " name="'+ value.VCODINFORME+'" id="' + poa.NUM_POA+'">';
                                            str += '   <label class="custom-control-label" for="' + poa.NUM_POA+'">' + poa.POA+'</label>';
                                            str += '</div>';
                                        }
                                    );
                                }
                                str += '</td>';
                                str += '</tr>';
                            });
                        str += '</tbody></table>';
                        str += '</div>';



                    }
                    $('#inptTramiteDenuncia').val(utilSigo.recortarTextos(data.substring(0, data.length - 1), 200));
                    $('#lblTramiteDenuncia').html("Informe de Supervisión (" + tramiteDenuncia.objInforme.length + ")");
                    $('#htmlSupervision').html(str);

                }
            });
        });
    },
    modalInformesSITD: function () {
        //  
        var url = urlLocalSigo + "Supervision/Denuncias/modalInformesSITD";
        var option = {
            url: url,
            type: 'GET',
            datos: {},
            divId: "mdlManInforme_DOCSITD"
        };
        utilSigo.fnOpenModal(option, function () { }, function () {

        });
    },
    returnIndex: function () {
        $.redirect(urlLocalSigo + "Supervision/Denuncias/IndexDenuncia", null);
    },
    eliminarObj: function () {
        tramiteDenuncia.objInforme = [];
        $('#inptTramiteDenuncia').val('');
    },
    guaradarEditar: function () {
        if (tramiteDenuncia.validarDenuncia()) {
            utilSigo.dialogConfirm('', 'Desea continuar con el registro?', function (r) {
                if (r) {
                    let baseUrl = urlLocalSigo + "Supervision/Denuncias/";
                    let rptaCombo = 0;
                    if ($('#cboAtencion').val() === '01') rptaCombo = 1;
                    else if ($('#cboAtencion').val() === '02') rptaCombo = 2;

                    let fileDataAuditoria = new FormData();
                    let archivoAuditoria = $("#idArchivoAuditoria").get(0);
                    if (!tramiteDenuncia.B_FLAG_AUDITORIA) {
                        $.each(archivoAuditoria.files, function (index, value) {
                            fileDataAuditoria.append(value.name, value);
                        });
                    }
                    // 

                    $.ajax({
                        url: urlLocalSigo + "Supervision/Denuncias/SubirArchivoAuditoria",
                        data: fileDataAuditoria,
                        dataType: "json",
                        type: "POST",
                        contentType: false,
                        processData: false,
                        success: function (data) {
                            if (!tramiteDenuncia.B_FLAG_AUDITORIA) {
                                tramiteDenuncia.objAuditoria = [];
                                $.each(data, function (index, value) {
                                    tramiteDenuncia.objAuditoria.push({
                                        URL_TECNICO: value.path,
                                        NOMBRE_ARCHIVO: value.mensaje,
                                        ARCHIVO_EXTENSION: value.mineType
                                    });
                                });
                            }
                        },
                        complete: function () {
                            //   
                            let ListPOAs_ = [];
                            $.each($('.poas'), function (i, x) {
                               //  
                                if (x.checked) {
                                    ListPOAs_.push({ NUM_POA: x.id, COD_INFORME: x.name })
                                }
                                
                            });
                            let objToSend = {
                                COD_IDENUNCIA: $('#COD_IDENUNCIA').val(),
                                ICOMPETENCIA: rptaCombo,
                                NOMBRE_DEPENDENCIA: $('#inptEntidad').val(),
                                CONCLUSION: $('#txtConclusionDenuncia').val(),
                                RECOMENDACION: $('#txtRecomendacionDenuncia').val(),
                                tra_M_Tramite: tramite,
                                IDENUNCIA_ITECNICOS: tramiteDenuncia.tablaInformeData.filter(archivos => {
                                    return archivos.B_FLAG;
                                }),
                                IDENUNCIA_CARTA_OFICIO: tramiteDenuncia.tablaCartaOficioData.filter(archivos => {
                                    return archivos.B_FLAG;
                                }),
                                //ENT_INFORME: tramiteDenuncia.objInforme,
                                IATENDIDO: $('input[name="rbtnAtendido"]:checked').val(),
                                iDENUNCIA_AUDITORIA_ARCHIVO: tramiteDenuncia.objAuditoria,
                                iDENUNCIA_THABILITANTEs: tramiteDenuncia.objTHabilitante,
                                IDenunciaDetInformeSupervision: tramiteDenuncia.objInforme,
                                FLAG_THABILITANTE: ($('#rbtnTHabilitanteSi').is(':checked') ? 1 : ($('#rbtnTHabilitanteNo').is(':checked') ? 2 : 0)),
                                TIPO_REQUERIMIENTO: ($('#cboTipoRequerimiento').val() != "00" ? $('#cboTipoRequerimiento').val() : null),
                                TIPO_REQUERIMIENTO_OTRO: $('#txtOtros').val(),
                                TIPO_TRASLADO: ($('#cboSubEstado').val() != "00" ? $('#cboSubEstado').val() : null),
                                IDenunciaDetDocumentosSITD: tramiteDenuncia.objInformeSITD,
                                ENT_INFORME: {
                                    ListPOAs: ListPOAs_
                                }
                            };
                            var urlInsertarDenuncia = baseUrl + 'RegistrarDenuncia';
                            //var urlSubirArchivo = baseUrl + "SubirArchivosDenuncia";
                            var urlSubirArchivo = baseUrl + "SubirArchivosDenuncia";
                            var fileData;
                            var ajaxArray = Array();
                            var indice = 1;
                            fileData = new FormData();
                            var lista = tramiteDenuncia.tablaInformeData.concat(tramiteDenuncia.tablaCartaOficioData).filter(archivos => {

                                if (!archivos.B_FLAG) {
                                    archivos.COD_IDENUNCIA_ITECNICO = indice;
                                    $.each(archivos.IDENUNCIA_ITECNICO_ARCHIVOS, function (indexArray, fileArray) {
                                        fileData.append(fileArray.name, fileArray, indice + "__" + fileArray.name);
                                    }); indice++;
                                }
                                return !archivos.B_FLAG;
                            });

                            if (lista.length >= 1) {

                                 
                                $.ajax({
                                    url: urlSubirArchivo,
                                    data: fileData,
                                    dataType: "json",
                                    type: "POST",
                                    contentType: false,
                                    processData: false,
                                    success: function (data) {
                                        if (data === undefined) return;
                                        lista.forEach(function (x) {
                                            x.COD_IDENUNCIA_ITECNICO;
                                            var item = data.Archivos.find(
                                                val => val.COD_COD_IDENUNCIA_ITECNICO.toString() === x.COD_IDENUNCIA_ITECNICO.toString()
                                            );
                                            if (x.Tipo == "I") {
                                                objToSend.IDENUNCIA_ITECNICOS.push({
                                                    COD_IDENUNCIA_ITECNICO: x.COD_IDENUNCIA_ITECNICO,
                                                    NOMBRE_INFORME: x.NOMBRE_INFORME,
                                                    IDENUNCIA_ITECNICO_ARCHIVOS: [item]
                                                });
                                            } else {
                                                objToSend.IDENUNCIA_CARTA_OFICIO.push({
                                                    COD_IDENUNCIA_ITECNICO: x.COD_IDENUNCIA_ITECNICO,
                                                    NOMBRE_INFORME: x.NOMBRE_INFORME,
                                                    IDENUNCIA_ITECNICO_ARCHIVOS: [item]
                                                });
                                            }

                                        })


                                        //informes
                                        
                                        var option = {
                                            url: urlInsertarDenuncia,
                                            datos: JSON.stringify(objToSend),
                                            type: 'POST'
                                        };
                                        utilSigo.fnAjax(option, function (data) {
                                            tramiteDenuncia.fnReturnIndex();
                                        });

                                    }
                                });
                            }
                            else {
                                var option = {
                                    url: urlInsertarDenuncia,
                                    datos: JSON.stringify(objToSend),
                                    type: 'POST'
                                };
                                utilSigo.fnAjax(option, function (data) {
                                    tramiteDenuncia.fnReturnIndex();
                                });
                            }
                        }
                    });

                }
            });
        }
    },
    limpiar: function () {
        tramiteDenuncia.objInforme = {};
        $('#inptTramiteDenuncia').val('');
        $('#inptEntidad').val('');
        tramiteDenuncia.tablaInformeData = [];
        $('#inptInformeTecnico').val('');
        $('#lblInformeTecnico').html('Archivos adicionales  (0)');
        $('#txtConclusionDenuncia').val('');
        $('#txtRecomendacionDenuncia').val('');
    },
    validarDenuncia: function () {
        utilSigo.elementOk($('#cboAtencion'));
        return true;
    }
};

var obtenerFilesNombres = function (archivos) {
    let concatNombres = '';
    for (let i = 0; i < archivos.length; i++) {
        concatNombres += archivos[i].name + ', ';
    }
    return concatNombres.substring(0, concatNombres.length - 2);
};

$(function () {
    tramiteDenuncia.eventos();
    tramiteDenuncia.ui();

});



