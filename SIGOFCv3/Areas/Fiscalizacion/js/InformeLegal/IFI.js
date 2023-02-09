"use strict";

let _informe = {};
let app,
    modal_notificar,
    modal_doc,
    modal_rsd,
    modal_sitd,
    modal_integrante;

const States = {
    INGRESADO: 1,
    EN_REVISION: 2,
    COMPLETADO: 3,
    VISADO: 4,
    FINALIZADO: 5
};

const data = {
    Modalidades: [
        { COD_MODALIDAD: '01', COD_MATERIA: '02', MODALIDAD: 'Concesiones' },
        { COD_MODALIDAD: '02', COD_MATERIA: '02', MODALIDAD: 'Predios privados' },
        { COD_MODALIDAD: '03', COD_MATERIA: '02', MODALIDAD: 'Comunidades nativas' },
        { COD_MODALIDAD: '04', COD_MATERIA: '01', MODALIDAD: 'Fauna' },
    ]
};

_informe.CambiarEstado = function (state) {
    app.Informe.ESTADO = state;

    let state_form;
    switch (state) {
        case States.INGRESADO: state_form = '0000001'; break;
        case States.EN_REVISION: state_form = '0000003'; break;
        default: state_form = '0000008'; break;
    }

    $('#ddlIndicadorId').val(state_form).trigger('change');
}

_informe.ENVIAR_REVISION = function () {
    console.log('Modal para cargar el documento word');

    _informe.REVISION_CARGAR_ARCHIVO();
}

_informe.REVISION_CARGAR_ARCHIVO = function () {
    modal_doc.accept = ['.doc', '.docx', 'application/msword'];
    var callback = function (info, fileName) {
        app.Informe.RUTA_ARCHIVO_REVISION = fileName;
        _informe.CambiarEstado(States.EN_REVISION);

        //Actualizamos el informe
        _informe.Guardar();

        $('#modal-cargar-documento').modal('hide');
    }

    modal_doc.show({ name: app.Informe.COD_INFORME_DIGITAL, callback });
}

_informe.DESCARGAR_ARCHIVO_REVISION = function () {
    const url = `${urlLocalSigo}${urlBaseDocFirma}/${app.Informe.RUTA_ARCHIVO_REVISION}`;
    window.open(url);
}

_informe.CERRAR = function () {
    utilSigo.dialogConfirm("", "Se CERRARÁ la edición del informe para proceder con la carga del archivo. ¿Está seguro de continuar?", function (r) {
        if (r) {
            let params = _informe.Estructura();
            params.ESTADO = States.COMPLETADO;

            _informe.Guardar(params).then(function (res) {
                _informe.CambiarEstado(States.COMPLETADO);

                //Abrimos el modal de carga de archivo
                _informe.CARGAR_ARCHIVO();
            }).catch(function () {
                utilSigo.toastError('Error', 'Ha ocurrido un error al intentar cerrar el informe');
            });
        }
    });
}

_informe.fileName = function () {
    return app.Tramite ? `${app.Tramite.cCodificacion?.replace('/', '-')}.pdf` : null;
}

_informe.IniciarFirma = function () {
    utilSigo.fnAjax({
        url: `${urlLocalSigo}General/FirmaDigital/getModal`,
        dataType: false
    }, (res) => {
        $("#partialviews").html(res);
        documentName_ = documentName_ || _informe.fileName();

        _modalInvoker.urlDocument = `${urlBaseDocFirma}/${documentName_}`;
        _modalInvoker.outputFolder = urlBaseDocFirma;
        _modalInvoker.outputFile = documentName_;
        _modalInvoker.invokerOk = function (e) {
            _informe.FirmaVerificar();
        }

        _modalInvoker.VerDocumento = _informe.VerDocumento;

        _modalInvoker.IniciarFirma();
    });
}

_informe.FirmaVerificar = function () {
    const user = _informe.signUser;
    _informe.CambiarEstado(States.VISADO);
    const register = app.Informe.PARTICIPANTES[user.index];
    if (register) {
        register.estado = 4; //FIRMADO
    }

    _informe.Guardar();
}

_informe.RutaDocumentoDescarga = function () {
    let name = `${app.Informe.ESTADO >= States.FINALIZADO ? 'INFORME-LEGAL-' : ''}${_informe.fileName()}`;
    let base = app.Informe.ESTADO >= States.FINALIZADO ? urlBaseDocFirmaTrans : urlBaseDocFirma;
    return `${urlLocalSigo}${base}/${name}?v=${new Date().getTime()}`;
}

_informe.VerDocumento = function () {
    let url = _informe.RutaDocumentoDescarga();
    window.open(url);
}

_informe.render = function (html) {
    if (html) {
        let ht = $("<div>" + html + "</div>");
        ht.find('table').css({ 'border': '1px solid #ccc', 'border-collapse': 'collapse' });

        ht.find('table').each(function (i, el) {
            if (!$(this).css('width')) $(this).css('width', '100%');
        });

        ht.find('td').css({ 'border': '1px solid #ccc', 'padding': '5.76px' });
        ht.find('.table-small td').css({ 'padding': '0' });

        ht.find('img').each(function (i, el) {
            let figure = $(el).closest('figure'), align = 'center';
            if (figure.hasClass('image-style-align-left')) align = 'left';
            else if (figure.hasClass('image-style-align-right')) align = 'right';

            let percent = figure.css('width').replace(/[%|px]/g, ''); //console.log(percent);
            figure.css({ 'text-align': align });

            let maxW = 550, w = el.naturalWidth, h = el.naturalHeight; //console.log(w, h);
            if (percent > 0) {
                maxW = Math.round(maxW * (percent / 100));
            }

            if (w > maxW) {
                let r = w / maxW;
                let maxH = Math.round(h / r);
                $(el).attr({ 'width': maxW, 'height': maxH });
            }

            //figure.replaceWith(function () {
            //    return $('<p>').append($(this).contents()).css({ 'text-align': align });
            //});
        });

        ht.find('.marker-yellow').css({ 'background-color': 'yellow' });

        html = ht.appendTo('<div>').html().replace(/figure/gi, 'p').replace(/mark/gi, 'span');
        //console.log(html);
    }

    return html;
};

_informe.tmpl = {
    //General: function (data) {
    //    return $("<div>").append($("#tmpl-exportar").tmpl(data || {})).getUnformattedText();
    //},
    get: function (html, tmplId, data) {
        const _dom = $("<div>", { html });
        const partial = _dom.find(tmplId);

        return $('<div>').append(partial.tmpl(data || {})).getUnformattedText();
    },
}

_informe.EnumerarCuadros = function (html) {
    let index = 0;
    return html.replace(/<strong>Cuadro.<\/strong>/gi, function (m) {
        index++;
        return `<strong>Cuadro ${index}.</strong>`;
    });
}

_informe.Exportar = async function () {
    const informe = _informe.Estructura();
    const [procedencias, materias] = JSON.parse(JSON.stringify([app.Procedencias, app.Materias]));

    //informe.EXPEDIENTE_ADM = $('#txtNumeroExpediente').val();
    informe.PROCEDENCIA = procedencias.find(function (x) { return x.COD_PROCEDENCIA === informe.COD_PROCEDENCIA })?.PROCEDENCIA;
    informe.MATERIA = materias.find(function (x) { return x.COD_MATERIA === informe.COD_MATERIA })?.MATERIA;
    informe.FECHA = fnDate.text_long(informe.RES_DIRECTORAL_FECHA || new Date());
    //informe.VISTOS = _informe.render(informe.VISTOS);
    //informe.ANTECEDENTES = _informe.render(informe.ANTECEDENTES);
    //informe.COMPETENCIA = _informe.render(informe.COMPETENCIA);
    //informe.ANALISIS = _informe.render(informe.ANALISIS);
    //informe.PIE_PAGINA = _informe.render(informe.PIE_PAGINA);
    informe.SITD_PASSWORD = app.Tramite?.password || '';
    informe.SUBDIRECTOR = informe.PARTICIPANTES.find(function (x) { return x.funcion === 'Subdirector' })?.apellidosNombres;
    //console.log(informe); //return;

    //EXPEDIENTES
    informe.EXPEDIENTES_ADM = informe.EXPEDIENTES.map(x => x.NUM_INFORME).join(', ');

    //INFRACCIONES
    for (var i = 0; i < informe.INFRACCIONES.length; i++) {
        const infraccion = informe.INFRACCIONES[i];
        const parrafos = await _informe.ExtraerParrafoInfraccion(infraccion, informe);
        infraccion.parrafos = parrafos;
    }

    const header = `<p style="text-align:center;"><img width="550" alt="" src="${urlLocalSigo}content/images/logo/osinfor-header-3.png"></p>`;
    //let footer = `<table style="width: 100%;"><tr><td style="text-align: right;">#CURRENTPAGE#</td></tr></table>`;

    informe.IMG_SANCION = [];
    if (informe.FLG_SANCION && informe.SANCION_COD_CALCULO) {
        const images = await _informe.PDFToImgCalculoMulta();
        informe.IMG_SANCION = images;
    }

    const template = await _informe.ExtraerPlantilla();
    informe.PIE_PAGINA = _informe.tmpl.get(template, '#tmpl-pie-pagina', informe);

    //let html = _informe.tmpl.General(informe);
    let html = '';
    html += _informe.tmpl.get(template, '#tmpl-exportar', informe);
    html += _informe.tmpl.get(template, '#tmpl-pie-pagina-estructura', informe);
    html += _informe.tmpl.get(template, '#tmpl-footnotes', informe);

    //Enumeracion de cuadros
    html = _informe.EnumerarCuadros(html);
    $(document).googoose({ html, header, footeridfirst: 'googoose-footer' });
}

_informe.PDFToImgCalculoMulta = function () {
    const url = _informe.UrlDescargarArchivoSancion();

    return new Promise(function (resolve, reject) {
        $.ajax({
            url: url,
            xhrFields: {
                responseType: 'arraybuffer'
            },
            success: function (arrayBuffer) {
                pdfjsLib.getDocument({ data: arrayBuffer }).promise.then(function (pdf) {
                    let allPagesPromises = [];

                    // Obtenemos todas las páginas del pdf
                    for (let i = 1; i <= pdf.numPages; i++) {
                        allPagesPromises.push(pdf.getPage(i));
                    }

                    Promise.all(allPagesPromises).then(async function (allPages) {
                        let pages = [];
                        let canvas, context;

                        for (let i = 0; i < allPages.length; i++) {
                            const page = allPages[i];

                            const viewport = page.getViewport({ scale: 1.0 });

                            // Prepare canvas using PDF page dimensions
                            canvas = document.createElement('canvas');
                            context = canvas.getContext('2d');
                            canvas.height = viewport.height;
                            canvas.width = viewport.width;

                            // Render PDF page into canvas context
                            const renderContext = {
                                canvasContext: context,
                                viewport: viewport
                            };
                            let renderTask = page.render(renderContext);
                            await renderTask.promise;

                            const base64 = canvas.toDataURL("image/jpeg");
                            pages.push(base64);
                        }

                        resolve(pages);
                    });

                });
            },
            error: function () {
                reject();
            }
        });
    });
}

_informe.Registro = function () {
    const parametros = _informe.Estructura();
    const errores = [];

    if (!parametros.COD_PROCEDENCIA) errores.push('Procedencia');
    if (!parametros.COD_MATERIA) errores.push('Materia');

    const validacion = parametros.PARTICIPANTES.some(function (x) { return x.flgAplica && !x.codPersona });
    if (validacion) errores.push('Personal para el flujo de control de vistos');

    if (errores.length) {
        const text = errores.map(item => `<li>${item}</li>`).join('');
        utilSigo.toastWarning('Por favor complete', '<ul>' + text + '</ul>');
        return;
    }

    _informe.Guardar(parametros);
}

_informe.Guardar = function (parametros) {
    let deferred = $.Deferred();
    parametros = parametros || _informe.Estructura();

    let params = {
        type: 'post',
        url: `${urlLocalSigo}Fiscalizacion/InformeLegalDigital/GuardarIFI`,
        datos: JSON.stringify({ informeDigital: parametros }),
    }
    utilSigo.fnAjax(params, function (res) {
        //console.log(res);
        let data = res.data;
        if (res.success) {
            app.Informe.COD_INFORME_DIGITAL = data.COD_INFORME_DIGITAL;

            data.PARTICIPANTES.forEach(function (x) {
                x.flgAplica = !!x.estado;
                x.accion = 1;
            });

            data.DOCUMENTOS.forEach(function (x) { x.accion = 1; });
            data.RSD.forEach(function (x) { x.accion = 1; });
            data.INFRACCIONES.forEach(function (x) { x.accion = 1; });

            app.Informe.PARTICIPANTES = data.PARTICIPANTES;
            app.Informe.DOCUMENTOS = data.DOCUMENTOS;
            app.Informe.RSD = data.RSD;
            app.Informe.INFRACCIONES = data.INFRACCIONES;
            app.Informe.ELIMINAR = [];

            _informe.CambiarEstado(app.Informe.ESTADO || States.INGRESADO);
            app.Informe.FLG_ACTUALIZAR = false;

            utilSigo.toastSuccess('Guardado', 'Se ha guardado el informe digital');
            deferred.resolve(res);
        } else {
            deferred.reject(res.msj);
            utilSigo.toastError(null, res.msj);
        }
    });

    return deferred.promise();
}

_informe.Estructura = function () {
    let data = JSON.parse(JSON.stringify(app.Informe));

    data.PARTICIPANTES.forEach(function (x, i) {
        if (!x.flgAplica) x.estado = 0;
        else x.estado = x.estado || 1;
        //x.item = i + 1;
    });

    data.DOCUMENTOS.forEach(function (x, i) {
        if (x.estado === null) x.estado = 1;
        //x.item = i + 1;
    });

    data.INFRACCIONES.forEach(function (x, i) {
        if (x.estado === null) x.estado = 1;
        //x.item = i + 1;
    });

    data.RSD.forEach(function (x, i) {
        if (x.estado === null) x.estado = 1;
        //x.item = i + 1;
    });

    let parametros = {
        ...data,
        //PARTICIPANTES: data.PARTICIPANTES,
        ELIMINAR: data.ELIMINAR
    };

    return parametros;
}

_informe.CARGAR_ARCHIVO = function () {
    if (!app.Tramite) {
        utilSigo.toastWarning('', 'No se ha generado el Nro de Informe Final de Instrucción previamente');
        return;
    }

    const callback = function (_, fileName) {
        documentName_ = fileName;
    }

    modal_doc.accept = ['application/pdf'];
    modal_doc.show({ name: app.Tramite.cCodificacion, callback });
}

_informe.ObtenerRutaResolucion = function (item) {
    return `${urlLocalSigo}Fiscalizacion/ManResolucion/CreateOrEdit?asCodRD=${item.codResolucion}&show_informe=true`;
}

_informe.EliminarResolucion = function (item, index) {
    //console.log(item)

    app.Informe = {
        ...app.Informe,
        COD_THABILITANTE: null,
        NUM_CONTRATO: null,
        COD_TITULAR: null,
        TITULAR: null,
        TITULAR_DOCUMENTO: null,
        TITULAR_ESTADO_RUC: null,
        TITULAR_CONDICION_RUC: null,
        TITULAR_RUC: null,
        R_LEGAL: null,
        R_LEGAL_DOCUMENTO: null,
        R_LEGAL_RUC: null,
        DIRECCION_LEGAL: null,
        UBIGEO_DEPARTAMENTO: null,
        UBIGEO_PROVINCIA: null,
        UBIGEO_DISTRITO: null,
    }

    if (item.codInformeDigital) {
        app.Informe.ELIMINAR.push({ codInformeDigital: item.codInformeDigital, item: item.item, origen: 'RSD' });

        app.Informe.INFRACCIONES
            .filter(x => x.codResolucion == item.codResolucion)
            .forEach(item => {
                app.Informe.ELIMINAR.push({ codInformeDigital: item.codInformeDigital, item: item.item, origen: 'INFRACCION' });
            });

        app.Informe.DOCUMENTOS
            .filter(x => x.codResolucion == item.codResolucion)
            .forEach(item => {
                app.Informe.ELIMINAR.push({ codInformeDigital: item.codInformeDigital, item: item.item, origen: 'DOCUMENTO' });
            });
    }

    app.Informe.INFRACCIONES = app.Informe.INFRACCIONES.filter(x => x.codResolucion != item.codResolucion);
    app.Informe.DOCUMENTOS = app.Informe.DOCUMENTOS.filter(x => x.codResolucion != item.codResolucion);

    app.Informe.RSD.splice(index, 1);
}

_informe.Agregar_Integrante = function () {
    modal_integrante.Abrir();
}

_informe.ExtraerPlantilla = function () {
    return new Promise(function (resolve, reject) {
        const params = {
            type: 'get',
            url: `${urlLocalSigo}Fiscalizacion/InformeLegalDigital/PlantillaInforme`,
            dataType: 'html'
        };

        utilSigo.fnAjax(params, function (html) {
            html ? resolve(html) : reject(null);
        });
    });
}

/*_informe.ExtraerInfracciones = function () {
    return new Promise(function (resolve, reject) {
        resolve(data.Infracciones);
    });
}*/

_informe.ExtraerParrafoInfraccion = function (infraccion, informe) {
    return new Promise(function (resolve, reject) {
        const params = {
            type: 'get',
            url: `${urlLocalSigo}Fiscalizacion/InformeLegalDigital/ObtenerInfraccion`,
            dataType: 'html',
            datos: { inciso: infraccion.inciso.replace(/\W+/gi, '') }
        };

        utilSigo.fnAjax(params, function (html) {
            if (html) {
                const _dom = $('<div>', { html });

                //Template jquery
                html = $("<div>").append(_dom.tmpl({ infraccion, informe })).getUnformattedText();

                resolve(html);
            }
            else reject(null);
        });
    });
}

_informe.SITD_OPEN = function () {
    utilSigo.fnAjax({
        type: 'get',
        url: `${urlLocalSigo}Fiscalizacion/ManPAU/TramiteGeneral`
    }, function (res) {
        if (res.success) {
            modal_sitd.oficinas = res.oficina;
            //modal_sitd.trabajadores = [];
            modal_sitd.documentos = res.tipoDocumento;
            modal_sitd.indicaciones = res.indicacion;
            modal_sitd.prioridades = res.prioridad;

            let datos = app.Tramite || {};
            modal_sitd.form.iCodTramite = datos.iCodTramite;
            modal_sitd.form.iCodOficina = datos.iCodOficina ||
                app.oficinaDefault?.id ||
                modal_sitd.oficinas.find(function (x) { return x.Text.trim() === app.Informe.COD_PROCEDENCIA })?.Value ||
                (res.oficina[0] || {}).Value;

            modal_sitd.form.trabajadorId = datos.trabajadorId;
            //modal_sitd.form.perfilId = datos.perfilId;
            modal_sitd.form.cCodTipoDoc = datos.cCodTipoDoc || "2102"; //(res.tipoDocumento[0] || {}).Value;
            modal_sitd.form.fechaRegistro = fnDate.text(datos.fechaRegistro || new Date());
            modal_sitd.form.cAsunto = datos.cAsunto || app.Informe.ASUNTO;
            modal_sitd.form.cObservaciones = datos.cObservaciones;
            modal_sitd.form.cnNumFolio = datos.cnNumFolio || 1;
            modal_sitd.form.indicacionId = datos.indicacionId || "23";
            modal_sitd.form.prioridad = datos.prioridad || "Alta";

            //console.log(app.oficinaDefault.id);

            _informe.SITD_TrabajadoresXOficina();

            $('#modal-sitd').modal('show');
        }
    });
}

_informe.SITD_TrabajadoresXOficina = function () {
    let iCodOficina = modal_sitd.form.iCodOficina;

    if (!iCodOficina) {
        modal_sitd.trabajadores = [];
        return;
    }

    utilSigo.fnAjax({
        type: 'get',
        url: `${urlLocalSigo}Fiscalizacion/ManPAU/TramiteGeneralByCriterio`,
        datos: { criterio: 'TRABAJADOR_X_OFICINA', valor: iCodOficina }
    }, function (res) {
        if (res.success) {
            modal_sitd.trabajadores = res.data;

            let id = modal_sitd.form.trabajadorId;
            if (!id) {
                let def = res.data.filter(function (x) { return x.flagJefe == "1" })[0] || {};
                modal_sitd.form.trabajadorId = def.trabajadorId;
            }
        }
    });
}

_informe.SITD_Registro = function () {
    let data = JSON.parse(JSON.stringify(modal_sitd._data));
    let obj = data.form;

    obj.cod_THabilitante = app.Informe.COD_THABILITANTE;
    obj.cod_Informe = app.Informe.COD_INFORME;
    obj.fechaRegistro = fnDate.toDate(obj.fechaRegistro);

    if (!obj.trabajadorId) {
        utilSigo.toastWarning('Atención', 'Por favor especifique un trabajador');
        return;
    }

    let tb = data.trabajadores.find(function (x) { return x.trabajadorId == obj.trabajadorId });
    if (tb) {
        obj.perfilId = tb.perfilId;
    }

    obj.lstReferencias = app.Informe.RSD.map(function (x) {
        return {
            //iCodTramiteRef: '',
            cReferencia: x.numInforme,
            cDesEstado: 'REGISTRADO',
            iCodTipo: 1
        }
    });

    let params = {
        type: 'post',
        url: `${urlLocalSigo}Fiscalizacion/InformeLegalDigital/${obj.iCodTramite ? 'TramiteModificar' : 'TramiteGuardar'}`,
        datos: JSON.stringify({ tramite: obj }),
    };

    utilSigo.fnAjax(params, function (res) {
        if (res.success) {
            res.data = res.data || app.Tramite || obj;
            console.log(res);

            if (res.data) {
                let data = _informe.Estructura();
                data.TRAMITE_ID = res.iCodTramite || data.TRAMITE_ID;
                data.NUM_INFORME_SITD = res.data.cCodificacion || data.NUM_INFORME_SITD;

                //Actualizamos las variables
                app.Informe.TRAMITE_ID = data.TRAMITE_ID;
                app.Informe.NUM_INFORME_SITD = data.NUM_INFORME_SITD;
                $('#txtNumIlegal').val(app.Informe.NUM_INFORME_SITD);

                app.Tramite = res.data;

                _informe.Guardar(data);
            }

            $('#modal-sitd').modal('hide');
        } else {
            utilSigo.toastError('Atención', res.msj);
        }

    });
};

_informe.AbrirCalculoMulta = function () {
    utilSigo.fnAjax({
        url: `${urlLocalSigo}Fiscalizacion/ManCalculoMulta/ModalCalculo`,
        dataType: false
    }, (res) => {
        $("#partialviews").html(res);

        _manCalMul.fnGuardar = $.Deferred();

        if (!app.Informe.SANCION_COD_CALCULO) {
            _manCalMul.fnCrear();

            const administrado = {
                EXPEDIENTE: app.Informe.EXPEDIENTES[0]?.NUM_INFORME,
                ADMINISTRADO: app.Informe.R_LEGAL,
                TIPO_DOC: app.Informe.R_LEGAL_DOCUMENTO || app.Informe.R_LEGAL_RUC,
                THABILITANTE: app.Informe.NUM_CONTRATO,
            };

            _manCalMul.fnAsignarDatosExpediente(administrado);
        } else {
            const datarow = {
                CODCALCULOMULTA: app.Informe.SANCION_COD_CALCULO
            }
            _manCalMul.fnEdit(datarow);
        }

        _manCalMul.fnGuardar.promise().then(data => {
            app.Informe.SANCION_UIT = data.total_uit;
            app.Informe.SANCION_COD_CALCULO = data.msj;
            app.Informe.FLG_ACTUALIZAR = true;

            utilSigo.toastSuccess('', 'No olvides GUARDAR la información después de hacer cambios');
            //console.log(data);
        });

    });
}

_informe.UrlDescargarArchivoSancion = function () {
    return `${urlLocalSigo}General/ManCalculoMulta/ExportPDF?codCalculoMulta=${app.Informe.SANCION_COD_CALCULO}`;
}

_informe.EliminarArchivoSancion = function () {
    utilSigo.dialogConfirm("", "¿Desea desafiliar el actual cálculo de multa?", function (r) {
        if (r) {
            app.Informe.SANCION_COD_CALCULO = null;
            app.Informe.FLG_ACTUALIZAR = true;
        }
    });
}

$(function () {
    app = new Vue({
        el: '#frmInforme',
        data: {
            Informe: {
                COD_INFORME_DIGITAL: null,
                COD_INFORME: null, // Codigo de Informe Legal
                TRAMITE_ID: null,
                NUM_INFORME_SITD: null,
                COD_PROCEDENCIA: null,
                PROCEDENCIA: null,
                COD_TIPO_INFORME: 1,
                COD_MATERIA: null,
                MATERIA: null,
                COD_MODALIDAD: null,
                INF_FECHA: null,
                INF_ANTECEDENTES: null,
                COD_THABILITANTE: null,
                NUM_CONTRATO: null,
                COD_TITULAR: null,
                TITULAR_DOCUMENTO: null,
                TITULAR: null,
                TITULAR_RUC: null,
                TITULAR_ESTADO_RUC: null,
                TITULAR_CONDICION_RUC: null,
                R_LEGAL: null,
                R_LEGAL_DOCUMENTO: null,
                R_LEGAL_RUC: null,
                DIRECCION_LEGAL: null,
                UBIGEO_DEPARTAMENTO: null,
                UBIGEO_PROVINCIA: null,
                UBIGEO_DISTRITO: null,
                UBIGEO_SECTOR: null,
                FLG_CUESTION_PREVIA: true,
                FLG_REC_RESPONSABILIDAD: true,
                FLG_GRAVEDAD_RIESGO: true,
                FLG_SANCION: true,
                SANCION_UIT: 0,
                SANCION_COD_CALCULO: null,
                FLG_MEDIDA_CORRECTIVA: true,
                FLG_MEDIDA_COMPLEMENTARIA: true,
                FLG_RESP_SOLIDARIO: true,
                FLG_COMUNICACION_GORE: true,
                RSD: [],
                EXPEDIENTES: [],
                PARTICIPANTES: [],
                DOCUMENTOS: [],
                INFRACCIONES: [],
                ELIMINAR: [],
                RUTA_ARCHIVO_REVISION: null,
                FECHA_REGISTRO: new Date(),
                ESTADO: 1,
                FLG_ACTUALIZAR: false,
            },
            oficinaDefault: null,
            Tramite: null,
            Procedencias: [
                //{ COD_PROCEDENCIA: 'SDFPAFFS', PROCEDENCIA: 'Sub Dirección de Fiscalización de Permisos y Autorizaciones Forestales y de Fauna Silvestre' },
                //{ COD_PROCEDENCIA: 'SDFCFFS', PROCEDENCIA: 'Sub Dirección de Fiscalización de Concesiones Forestales y de Fauna Silvestre' },
                { COD_PROCEDENCIA: 'SDI', PROCEDENCIA: 'Sub Dirección de Instrucción' },
            ],
            Materias: [
                { COD_MATERIA: '01', MATERIA: 'Fauna Silvestre' },
                { COD_MATERIA: '02', MATERIA: 'Recursos Forestales' },
            ],
            Modalidades: []
        },
        methods: {
            init: function () {
                const self = this;

                const datos = ManInfLegal_AddEdit.frm.serializeObject();
                const user = ManInfLegal_AddEdit.userApp;

                const values = {
                    COD_INFORME: datos.hdfCodInfLegal,
                    COD_PROCEDENCIA: "SDI",
                    COD_MATERIA: "02",
                    PARTICIPANTES: [
                        { funcion: 'Especialista Legal', codPersona: user.COD_PERSONA, apellidosNombres: user.PERSONA, flgAplica: true, estado: 1 },
                        { funcion: 'Ingeniero Forestal', codPersona: null, apellidosNombres: null, flgAplica: true, estado: null },
                        { funcion: 'Coordinador', codPersona: null, apellidosNombres: null, flgAplica: true, estado: null },
                        { funcion: 'Subdirector', codPersona: null, apellidosNombres: null, flgAplica: true, estado: null },
                    ],
                    // Ejemplos
                    DOCUMENTOS: [],
                    INFRACCIONES: []
                };

                self.Informe = { ...self.Informe, ...values };
                this.MateriaOnChange();

                if (self.Informe.COD_INFORME) {
                    self.Informacion(values).then(function (res_general) {
                        //console.log(res_general)
                        self.TramiteByID().then(function (res_tramite) {
                            if (res_tramite.success) {
                                self.Tramite = res_tramite.data;
                                //app.Informe.DESTINATARIO = res_tramite.data.trabajador;
                            }
                        }).catch(() => { });
                    });
                }
            },
            MateriaOnChange: function () {
                this.Modalidades = data.Modalidades.filter(x => x.COD_MATERIA === this.Informe.COD_MATERIA);
                this.Informe.COD_MODALIDAD = this.Modalidades[0].COD_MODALIDAD;
            },
            Informacion: function (values) {
                const self = this;

                //Expedientes
                self.Informe.EXPEDIENTES = _renderListExpediente.dtRenderListInforme.rows().data().toArray();
                self.Informe.EXPEDIENTES.forEach(x => {
                    x.NUM_INFORME = x.NUM_INFORME.replace('(Exp. Adm.)', '').trim();
                });

                return new Promise((resolve, reject) => {
                    let params = {
                        type: 'post',
                        url: `${urlLocalSigo}Fiscalizacion/InformeLegalDigital/ObtenerIFI`,
                        datos: JSON.stringify({ COD_RESOLUCION: self.Informe.COD_INFORME })
                    };

                    utilSigo.fnAjax(params, function (res) {
                        if (res.informe) {
                            res.informe.PARTICIPANTES.forEach(function (x) {
                                x.flgAplica = !!x.estado;
                            });

                            self.Informe = { ...self.Informe, ...res.informe };
                            self.MateriaOnChange();
                            //==========================================================
                            self.Informe.COD_PROCEDENCIA = res.informe.COD_PROCEDENCIA;
                            self.Informe.COD_MATERIA = res.informe.COD_MATERIA;
                            self.Informe.COD_MODALIDAD = res.informe.COD_MODALIDAD;
                            //==========================================================

                            self.Informe.COD_INFORME = res.informe.COD_INFORME || values.COD_INFORME || null;
                            self.Informe.NUM_INFORME_SITD = res.informe.NUM_INFORME_SITD || values.NUM_INFORME_SITD || null;
                            self.Informe.R_LEGAL = res.informe.R_LEGAL || values.R_LEGAL || null;
                        }

                        if (!res.informe) {
                            //************ */
                        }

                        resolve(res);
                    });
                });

                //const data = JSON.parse(JSON.stringify(self.Informe));
                //self.Informe.PIE_PAGINA = _informe.tmpl.get('#tmpl-pie-pagina', data);
            },
            TramiteByID: function (datos) {
                const self = this;
                datos = datos || JSON.parse(JSON.stringify(self.Informe));

                const promise = new Promise((resolve, reject) => {
                    if (!datos.TRAMITE_ID || !datos.COD_THABILITANTE || !datos.COD_INFORME) {
                        reject("Faltan datos para extraer información de trámite");
                        return;
                    }

                    const params = {
                        url: `${urlLocalSigo}Fiscalizacion/ManPAU/TramiteGetById`,
                        datos: { id: datos.TRAMITE_ID, codTHabilitante: datos.COD_THABILITANTE, codInforme: datos.COD_INFORME }
                    };


                    utilSigo.fnAjax(params, function (res) {
                        resolve(res);
                    });
                });

                return promise;
            },
            ObtenerArchivos: function (COD_RESODIREC) {
                const self = this;

                const promise = new Promise((resolve, reject) => {
                    const params = {
                        type: 'get',
                        url: `${urlLocalSigo}General/Controles/buscarIntegracionSIADO`,
                        datos: {
                            asCriterio: 'SUBTIP_TITDOCSIGO',
                            asSubCriterio: '0005,0006,0010', //CARTAS, INFORMES DE SUPERVISION, RESOLUCIONES SUB DIRECTORALES
                            asValor: COD_RESODIREC
                        }
                    };

                    utilSigo.fnAjax(params, function (res) {
                        if (res.success) {
                            let files = res.data.map(function (item, index) {
                                return {
                                    codInformeDigital: app.Informe.COD_INFORME,
                                    codResolucion: COD_RESODIREC,
                                    tipo: item.ORIGEN,
                                    nombre: `${item.DETINV_DESCRIPCION}`,
                                    url: urlLocalSigo + "General/Controles/DescargarIntegracionSIADO?fileName=" + item.DETINV_CODDOC + "&origen=" + item.ORIGEN,
                                    estado: 1
                                }
                            });

                            //self.Informe.DOCUMENTOS = [...self.Informe.DOCUMENTOS, ...files];
                            resolve(files);
                        }
                    });
                });

                return promise;
            },
            Eliminar_Archivo: function (item, index) {
                let self = this;
                utilSigo.dialogConfirm("", "¿Desea quitar el documento como insumo para el análisis?", function (r) {
                    if (r) {
                        self.Informe.ELIMINAR.push({ codInformeDigital: item.codInformeDigital, item: item.item, origen: 'DOCUMENTO' });
                        self.Informe.DOCUMENTOS.splice(index, 1);
                    }
                });
            },
            ConsultaRUC: function () {
                let self = this;
                let RUC = self.Informe.TITULAR_RUC;
                if (!RUC) {
                    return;
                }

                let params = {
                    type: 'post',
                    url: `${urlLocalSigo}General/Controles/buscarPersonaNJ_OSINFOR_PIDE`,
                    datos: JSON.stringify({ asBusCriterio: 'RUC', asBusValor: RUC })
                };

                utilSigo.fnAjax(params, function (res) {
                    if (res.success) {
                        self.Informe.TITULAR_CONDICION_RUC = res.values[5];
                        self.Informe.TITULAR_ESTADO_RUC = res.values[6];
                        self.Informe.DIRECCION_LEGAL = res.values[4];
                    } else {
                        utilSigo.toastWarning(res.msj);
                    }
                });
            },
            BuscarPersona: function (item) {
                const self = this;

                var option = {
                    url: `${urlLocalSigo}General/Controles/_BuscarPersonaGeneral`,
                    type: 'GET',
                    datos: { asBusGrupo: "PERSONA", asCodPTipo: "TODOS", asTipoPersona: "N" },
                    divId: "mdlBuscarPersona"
                };
                utilSigo.fnOpenModal(option, function () {
                    _bPerGen.fnAsignarDatos = function (obj) {
                        if (obj) {
                            var data = _bPerGen.dtBuscarPerona.row($(obj).parents('tr')).data();
                            console.log(data);

                            item.codPersona = data.COD_PERSONA;
                            item.apellidosNombres = data.PERSONA;
                            item.estado = 1;

                            self.Informe.FLG_ACTUALIZAR = true;

                            utilSigo.fnCloseModal("mdlBuscarPersona");
                        }
                    }
                    _bPerGen.fnInit();
                });
            },
            AgregarRSD: function () {
                modal_rsd.Abrir();
            },
            Abrir_Notificar: function (item) {
                modal_notificar.form.Mensaje = 'Por favor revisar el informe para la continuidad del proceso.';

                let users = [];

                if (item) users = [item.codPersona];
                else users = this.Informe.PARTICIPANTES.map(user => user.codPersona);

                let params = {
                    type: 'post',
                    url: `${urlLocalSigo}Fiscalizacion/InformeLegalDigital/ObtenerCorreos`,
                    datos: JSON.stringify(users)
                };

                utilSigo.fnAjax(params, function (res) {
                    var destinatarios = res
                        .filter(item => (item?.CORREO || '').indexOf('@') != -1)
                        .map(item => ({ codPersona: item.COD_PERSONA, email: item.CORREO }));

                    modal_notificar.Abrir(destinatarios);
                });
            },
            Notificar: function (destinatarios, cc, mensaje) {
                const self = this;

                const notificacion = {
                    DESTINATARIOS: destinatarios.map(item => item.email).join(','),
                    CC_DESTINATARIOS: cc,
                    COD_INFORME: self.Informe.NUM_INFORME_SITD,
                    MENSAJE_ENVIO_ALERTA: mensaje,
                    URL_LOCAL: window.location.href
                };

                const personas = self.Informe.PARTICIPANTES
                    .filter(item => destinatarios.find(x => x.codPersona == item.codPersona));

                const participantes = personas.map(item => ({
                    ...item,
                    codInformeDigital: self.Informe.COD_INFORME_DIGITAL,
                    estado: item.estado > 2 ? item.estado : 2
                }));

                //console.log(notificacion, participantes); return;

                let params = {
                    type: 'post',
                    url: `${urlLocalSigo}Fiscalizacion/InformeLegalDigital/Notificar`,
                    datos: JSON.stringify({ notificacion, participantes })
                };

                utilSigo.fnAjax(params, function (res) {
                    if (res) {
                        //Actualizamos en la vista
                        self.Informe.PARTICIPANTES.forEach(x => {
                            const data = participantes.find(item => item.item == x.item);
                            if (data) {
                                x.estado = data.estado;
                            }
                        });

                        utilSigo.toastSuccess('Enviado', res);
                    } else {
                        utilSigo.toastWarning('Atención', 'No se ha encontrado ningún correo asociado al usuario');
                    }
                });
            },
            Revisar: function (item, index) {
                //let self = this;
                const user = ManInfLegal_AddEdit.userApp || {};
                if (this.Informe.ESTADO !== States.EN_REVISION) {
                    utilSigo.toastWarning('Información', 'El informe tiene que estar en revisión para ejecutar esta acción');
                    return;
                }

                if (user.COD_PERSONA !== item.codPersona) {
                    utilSigo.toastWarning('No autorizado', 'Ud no está autorizado para revisar con este usuario');
                    return;
                }

                item.estado = 3;
                _informe.Guardar();
            },
            Firmar: function (item, index) {
                const user = ManInfLegal_AddEdit.userApp || {};
                if (this.Informe.ESTADO < States.COMPLETADO) {
                    utilSigo.toastWarning('Información', 'Tiene que cerrar la edición del informe para empezar con la firma digital');
                    return;
                }

                if (user.COD_PERSONA !== item.codPersona) {
                    utilSigo.toastWarning('No autorizado', 'Ud no está autorizado para firmar con este usuario');
                    return;
                }

                if (item.estado === 4) {
                    utilSigo.toastWarning('Firmado', 'El documento ya fue firmado');
                    return;
                }

                _informe.signUser = { ...item, index };
                _informe.IniciarFirma();
            },
            Eliminar_Integrante: function (item, index) {
                this.Informe.ELIMINAR.push({ codInformeDigital: item.codInformeDigital, item: item.item, origen: 'PARTICIPANTE' });
                this.Informe.PARTICIPANTES.splice(index, 1);
                utilSigo.toastSuccess('Listo', 'Se ha eliminado el integrante');
            }
        },
        mounted: function () {
            document.getElementById('frmInforme').classList.remove('loading');

            let self = this;
            //self.init();

            //Para cargar los datos una sola vez, una vez que nos posicionamos en el tab de Informe Digital
            let loaded_info = false;

            $('#myTab a[data-toggle="tab"]').on('shown.bs.tab', function (e) {
                let href = $(e.target).attr('href');
                if (href === '#navInformeDigital') {
                    if (!loaded_info) {
                        self.init();
                        loaded_info = true;
                    }
                }
            });

            if (window.location.href.match(/show_informe=true/gi)) {
                $('#myTab a[href="#navInformeDigital"]').tab('show');
            }
        }
    });

    modal_rsd = new Vue({
        el: '#modal-rsd',
        data: {
            opciones: [],
            opcion: 'RD_NUMERO',
            texto: null,
            tabla: {}
        },
        methods: {
            Abrir: function () {
                //this.texto = '00171-2022-OSINFOR/08.2.1'; //'00165-2022-OSINFOR/08.2.1';
                //this.Buscar();
                const self = this;
                const params = {
                    url: `${urlLocalSigo}Fiscalizacion/InformeLegalDigital/ExtraerOpcionesBuscarRSD`,
                };

                if (!self.opciones.length) {
                    utilSigo.fnAjax(params, function (res) {
                        self.opciones = res;
                        $('#modal-rsd').modal('show');
                    });
                } else {
                    $('#modal-rsd').modal('show');
                }
            },
            Buscar: function () {
                const self = this;

                if (window.dtb_rsd) window.dtb_rsd.destroy();

                window.dtb_rsd = $('#dt_rsd').DataTable({
                    processing: true,
                    serverSide: true,
                    searching: false,
                    ajax: {
                        url: initSigo.urlControllerGeneral + "/GetListaGeneralPaging_v3",
                        data: function (d) {
                            d.customSearchEnabled = true;
                            d.customSearchForm = 'RESOLUCION_SUBDIRECTORAL';
                            d.customSearchType = self.opcion;
                            d.customSearchValue = self.texto?.toUpperCase();

                            for (var i = 0; i < d.order.length; i++) {
                                d.order[i]["column_name"] = d.columns[d.order[i]["column"]]["data"];
                            }
                            d.columns = null;
                        },
                    },
                    columns: [
                        { data: 'FECHA', title: 'FECHA' },
                        { data: 'NUMERO_RESOLUCION', title: 'N° RESOLUCIÓN' },
                        { data: 'PROCEDENCIA', title: 'PROCEDENCIA' },
                        { data: 'MATERIA', title: 'MATERIA' },
                        { data: 'ADMINISTRADO', title: 'ADMINISTRADO' },
                        { data: 'TITULO_HABILITANTE', title: 'TITULO HABILITANTE' },
                        { data: 'NRO_REFERENCIA', title: 'REFERENCIA' },
                    ],
                    columnDefs: [
                        {
                            targets: 7,
                            orderable: false,
                            data: null,
                            render: (data, type, row, meta) => {
                                return `<i class="fa fa-lg fa-check text-success px-2" onclick="modal_rsd.Agregar(this)"></i>`;
                            }
                        }
                    ],
                    lengthMenu: [[10, 20, 50, 100], [10, 20, 50, 100]],
                    //bLengthChange: false,
                    aaSorting: [],
                    pageLength: 10,
                    displayStart: 0,
                    drawCallback: initSigo.showPagination,
                });
            },
            Agregar: function (obj) {
                const row = $(obj).closest('tr');
                const item = window.dtb_rsd?.row(row).data();
                if (!item) return;

                const existe = app.Informe.RSD.find(x => x.codResolucion == item.COD_RESODIREC);

                if (existe) {
                    utilSigo.toastWarning('Alerta', 'La resolución ya está en la lista');
                    return;
                }

                var params = {
                    url: `${urlLocalSigo}Fiscalizacion/ManResolucion/ObtenerResolucion`,
                    type: 'GET',
                    datos: { asCodRD: item.COD_RESODIREC, asCodTipoIL: "" },
                };

                utilSigo.fnAjax(params, async function (res) {
                    console.log(res);

                    //Extraemos los parrafos de las infracciones
                    //const ìnfracciones = await _informe.ExtraerInfracciones();

                    const RESOLUCION = {
                        codResolucion: item.COD_RESODIREC,
                        numInforme: item.NUMERO_RESOLUCION,
                        estado: 1
                    };

                    //console.log(app.Informe.INFRACCIONES.map(x => x.inciso), res.LIST_INFRACCIONES.map(x => x.DESCRIPCION_ENCISOS))

                    const INFRACCIONES = res.LIST_INFRACCIONES
                        .filter(function (infraccion) {
                            //return !app.Informe.INFRACCIONES.find(x => x.codInciso == infraccion.COD_ILEGAL_ENCISOS)
                            return !app.Informe.INFRACCIONES.find(x => x.inciso == infraccion.DESCRIPCION_ENCISOS)
                        })
                        .map(function (infraccion) {
                            //const inciso = infraccion.DESCRIPCION_ENCISOS.replace(/\W+/gi, '');
                            //const infraccion = infracciones.find(inf => inf.INCISO == inciso) || {};
                            const titulo = `Respecto a la imputación ${infraccion.TEXTO_ENCISO[0].toLowerCase() + infraccion.TEXTO_ENCISO.slice(1)}`;

                            return {
                                codResolucion: item.COD_RESODIREC,
                                codInciso: infraccion.COD_ILEGAL_ENCISOS,
                                inciso: infraccion.DESCRIPCION_ENCISOS,
                                titulo,
                                detalle: infraccion.DESCRIPCION_INFRACCIONES,
                                flgDesvirtua: false,
                                flgSubsana: false,
                                parrafos: null,
                                estado: 1
                            }
                        });

                    app.Informe = {
                        ...app.Informe,
                        COD_THABILITANTE: res.COD_THABILITANTE,
                        NUM_CONTRATO: res.NUM_THABILITANTE,
                        COD_TITULAR: res.COD_TITULAR,
                        TITULAR_DOCUMENTO: res.TITULAR_DOCUMENTO,
                        TITULAR: res.TITULAR,
                        TITULAR_ESTADO_RUC: '',
                        TITULAR_CONDICION_RUC: '',
                        TITULAR_RUC: res.TITULAR_RUC,
                        R_LEGAL: res.R_LEGAL,
                        R_LEGAL_DOCUMENTO: res.R_LEGAL_DOCUMENTO,
                        R_LEGAL_RUC: res.R_LEGAL_RUC,

                        DIRECCION_LEGAL: '',
                        UBIGEO_DEPARTAMENTO: res.UBIGEO_DEPARTAMENTO,
                        UBIGEO_PROVINCIA: res.UBIGEO_PROVINCIA,
                        UBIGEO_DISTRITO: res.UBIGEO_DISTRITO,
                        RSD: [...app.Informe.RSD, RESOLUCION],
                        INFRACCIONES: [...app.Informe.INFRACCIONES, ...INFRACCIONES]
                    }

                    app.ObtenerArchivos(item.COD_RESODIREC).then(function (files) {
                        //console.log("LOAD FILES SIADO...", files);
                        files = files.filter(function (file) {
                            return !app.Informe.DOCUMENTOS.find(x => x.codResolucion == file.codResolucion)
                        });

                        app.Informe.DOCUMENTOS = [...app.Informe.DOCUMENTOS, ...files];
                    });

                    $('#modal-rsd').modal('hide');
                });
            }
        },
        mounted: function () {
            /*const self = this;
            $('#modal-rsd').on('click', 'table tr', function (e) {
                const row = dtb_rsd.row(this).data();
                self.Agregar(row);
            });*/
        }
    });

    modal_sitd = new Vue({
        el: '#modal-sitd',
        data: {
            form: {
                iCodTramite: null,
                iCodOficina: null,
                trabajadorId: null,
                perfilId: null,
                cCodTipoDoc: null,
                fechaRegistro: null,
                cAsunto: null,
                cObservaciones: null,
                cnNumFolio: null,
                indicacionId: null,
                prioridad: null,
                lstReferencias: []
            },
            oficinas: [],
            trabajadores: [],
            documentos: [],
            indicaciones: [],
            prioridades: [],
        }
    });

    modal_integrante = new Vue({
        el: '#modal-integrante',
        data: {
            form: {
                funcion: null,
                codPersona: null,
                apellidosNombres: null,
                estado: null,
                flgAplica: true
            }
        },
        methods: {
            Abrir: function () {
                $('#modal-integrante').modal('show');
            },
            Agregar: function () {
                const user = { ...this.form };
                app.Informe.PARTICIPANTES.push(user);

                utilSigo.toastSuccess('Agregado', 'Se ha agregado el integrante a la lista');
                $('#modal-integrante').modal('hide');
            }
        }
    });

    modal_notificar = new Vue({
        el: '#modal-notificar',
        data: {
            form: {
                Destinatarios: [],
                Seleccionados: [],
                CC: '',
                Mensaje: null
            }
        },
        methods: {
            Abrir: function (items) {
                this.form.Destinatarios = items;
                this.form.Seleccionados = items;
                $('#modal-notificar').modal('show');
            },
            Cerrar: function () {
                $('#modal-notificar').modal('hide');
            },
            Notificar: function () {
                const correos = this.form.Seleccionados;
                app.Notificar(correos, this.form.CC, _informe.render(this.form.Mensaje));

                this.Cerrar();
            }
        }
    });

    modal_doc = new Vue({
        el: '#modal-cargar-documento',
        data: {
            context: null,
            loading: false,
            error: false,
            percent: 0,
            file: null,
            accept: ['application/pdf'],
            info: {},
            options: null
        },
        methods: {
            show: function (options) {
                if (!options || !options.name) {
                    console.log('No se ha especificado las opciones de carga');
                    return;
                }

                this.percent = 0;
                this.error = false;
                this.file = null;

                this.options = options;
                this.options.name = options.name.replace(/\//gi, '-');
                $('#modal-cargar-documento').modal('show');
            },
            dragOver: function (e) {
                e.preventDefault();
                e.stopPropagation();
            },
            dragLeave: function (e) {
                e.preventDefault();
                e.stopPropagation();
            },
            drop: function (e) {
                let dataTransfer = e.dataTransfer;
                if (dataTransfer && dataTransfer.files.length) {
                    e.preventDefault();
                    e.stopPropagation();

                    let files = dataTransfer.files;
                    this.setInfo(files[0]);
                }
            },
            fileChange: function (e) {
                let files = e.target.files;
                if (files.length) {
                    this.setInfo(files[0]);
                    setTimeout(function () { e.target.value = ""; }, 100);
                }
            },
            fileSearch: function (e) {
                $(e.target).closest('.modal-body').find('input[type=file]').click();
            },
            setInfo: function (f) {
                const ext = f.name.split('.').reverse()[0];

                if (this.accept.indexOf(f.type) === -1 && this.accept.indexOf('.' + ext) === -1) {
                    console.log(ext, f.type, 'Permitidos ===>', this.accept);
                    utilSigo.toastWarning('Atención', 'El tipo de archivo que intenta subir no está permitido');
                    return;
                }

                if (f.size > 100 * 1024 * 1024) {
                    utilSigo.toastWarning('Atención', 'El archivo no debe ser mayor a 100MB');
                    return;
                }

                this.file = f;
                this.error = false;
                this.percent = 0;

                let bytesToSize = function (x) {
                    const units = ['bytes', 'KB', 'MB', 'GB', 'TB', 'PB', 'EB', 'ZB', 'YB'];
                    let l = 0, n = parseInt(x, 10) || 0;
                    while (n >= 1024 && ++l) {
                        n = n / 1024;
                    }
                    return (n.toFixed(n < 10 && l > 0 ? 1 : 0) + ' ' + units[l]);
                }

                this.info = {
                    name: f.name,
                    size: f.size,
                    sizeFormat: bytesToSize(f.size),
                    type: f.type,
                    extension: ext
                }
            },
            upload: function () {
                let self = this;
                self.error = false;
                self.percent = 0;

                if (!self.options) {
                    console.log('No se han especificado opciones para la carga');
                    return;
                }

                let formData = new FormData();

                const fileName = `${self.options.name}.${self.info.extension}`;
                formData.append('documentName', fileName);
                formData.append('myFile', self.file);

                self.context = $.ajax({
                    xhr: function () {
                        let xhr = new window.XMLHttpRequest();
                        //Upload progress
                        xhr.upload.addEventListener("progress", function (evt) {
                            if (evt.lengthComputable) {
                                var percentComplete = Math.round((evt.loaded / evt.total) * 100);
                                //console.log(percentComplete);
                                self.percent = percentComplete;
                                if (percentComplete === 100) {
                                    //Carga completa
                                }
                            }
                        }, false);

                        return xhr;
                    },
                    type: 'post',
                    url: urlLocalSigo + 'Fiscalizacion/ManPAU/CargarDocumento',
                    data: formData,
                    cache: false,
                    contentType: false,
                    processData: false,
                    beforeSend: function () { self.loading = true; },
                    complete: function () { self.loading = false; },
                    success: function (res) {
                        if (res.success) {
                            //app.Informe.ESTADO = ?; //ARCHIVO CARGADO
                            //$(self.$el).modal('hide');
                            if (typeof self.options.callback === 'function') self.options.callback(res, fileName);
                            utilSigo.toastSuccess('Listo', res.msj);
                        } else {
                            self.error = true;
                        }
                    },
                    error: function (xhr, textStatus) {
                        if (textStatus != 'abort') self.error = true;
                        self.percent = 0;
                    }
                });
            },
            cancel: function () {
                if (this.context) {
                    this.context.abort();
                }
            }
        }
    });
});