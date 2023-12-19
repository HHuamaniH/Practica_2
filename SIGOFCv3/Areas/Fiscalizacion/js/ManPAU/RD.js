"use strict";

let _informe = {};
let app,
    modal_referencias,
    modal_referencias_tipo,
    modal_notificar,
    modal_doc,
    modal_ifi,
    modal_sitd,
    modal_integrante;

const States = {
    INGRESADO: 1,
    EN_REVISION: 2,
    COMPLETADO: 3,
    VISADO: 4,
    FINALIZADO: 5
};

const regExpOSINFOR = /([^\s]+-OSINFOR\/[0-9]{1,}\.[0-9]{1,}(\.[0-9]{1,})?)/gi;

const data = {
    Modalidades: [
        { COD_MODALIDAD: '01', COD_MATERIA: '02', MODALIDAD: 'Concesiones', CONTRATO: 'contrato de concesión' },
        { COD_MODALIDAD: '02', COD_MATERIA: '02', MODALIDAD: 'Predios privados', CONTRATO: 'permiso forestal' },
        { COD_MODALIDAD: '03', COD_MATERIA: '02', MODALIDAD: 'Comunidades nativas', CONTRATO: 'permiso forestal' },
        { COD_MODALIDAD: '04', COD_MATERIA: '01', MODALIDAD: 'Fauna', CONTRATO: '' },
    ],
    //Causales_Caducidad: []
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
    documentName_ = documentName_ || _informe.fileName();

    _modalInvoker.urlDocument = `${urlBaseDocFirma}/${documentName_}`;
    _modalInvoker.outputFolder = urlBaseDocFirma;
    _modalInvoker.outputFile = documentName_;
    _modalInvoker.invokerOk = function (e) {
        _informe.FirmaVerificar();
    }

    _modalInvoker.VerDocumento = _informe.VerDocumento;

    _modalInvoker.IniciarFirma();
}

_informe.FirmaVerificar = function () {
    let user = _informe.signUser;
    _informe.CambiarEstado(States.VISADO);
    let register = app.Informe.PARTICIPANTES[user.index];
    if (register) {
        register.estado = 4; //FIRMADO
    }

    _informe.Guardar();
}

_informe.render = function (html) {
    if (html) {
        let ht = $("<div>" + html + "</div>");
        ht.find('table').css({ 'border': '1px solid #000', 'border-collapse': 'collapse' });

        ht.find('table').each(function (i, el) {
            if (!$(this).css('width')) $(this).css('width', '100%');
        });

        ht.find('td').css({ 'border': '1px solid #000', 'padding': '5.76px' });
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

_informe.NumeroALetra = function (numero) {
    if (numero <= 0 || typeof numero !== 'number' || !Number.isInteger(numero)) {
        return 'Número no válido';
    }

    let resultado = '';
    const alfabeto = 'abcdefghijklmnopqrstuvwxyz';

    while (numero > 0) {
        const indice = (numero - 1) % 26; // Restamos 1 para ajustar a 0-based index
        resultado = alfabeto[indice] + resultado;
        numero = Math.floor((numero - 1) / 26); // Restamos 1 para ajustar a 0-based index
    }

    return resultado;
}

_informe.tmpl = {
    get: function (html, tmplId, data) {
        const _dom = $("<div>", { html });
        const partial = _dom.find(tmplId);
        return $('<div>').append(partial.tmpl(data || {})).getUnformattedText();
    },
}

_informe.EnumerarCuadros = function (html) {
    let index = 0;
    return html.replace(/(Cuadro N°|NRO) XX/gi, function (m, p) {
        index++;
        return `${p} ${index}`;
    });
}

_informe.EnumerarListas = function (html) {
    let num = 1;
    var $html = $('<div />', { html: html });
    $html.find('ol.continue').each((index, el) => {
        $(el).attr('start', num);
        num += $(el).find('>li').length;
    });

    return $html.html();
}

_informe.EnumerarParrafos = function (html, MARGIN_LEFT_OL) {
    var $html = $('<div />', { html: html });
    $html.find('.enumeration').each((index, el) => {
        const html = $(el).html();
        $(el).html(`<ol style="margin-left: ${MARGIN_LEFT_OL};" start="${index + 1}"><li>${html}</li></ol>`);
    });

    return $html.html();
}

_informe.GenerarResolucion = function (template, informe) {
    let index = 0;
    informe.Inf_Supervision = app.Inf_Supervision[0];

    let html = _informe.tmpl.get(template, '#tmpl-resolucion', informe);
    html = html.replace(/<strong>Artículo.<\/strong>/gi, function (m) {
        index++;
        return `<strong>Artículo ${index}.</strong>`;
    });

    return html;
}

_informe.RevisarFootnotes = function (html) {
    var $html = $('<div />', { html: html });

    //Buscamos todos los elementos mso-element
    $html.find('.MsoFootnoteText').each((_, e) => {
        const element = $(e).parent();
        const id = element.attr("id");
        const a = $html.find('a[href="#_' + id + '"]:not([name])');
        if (!a.length) {
            element.remove();
        }
    });

    return $html.html();
}

_informe.Exportar = async function () {
    const informe = _informe.Estructura();

    Object.keys(informe).forEach(key => {
        if (typeof informe[key] !== 'boolean' && !informe[key]) informe[key] = '';
    });

    const [procedencias, materias, modalidades] = JSON.parse(JSON.stringify([app.Procedencias, app.Materias, data.Modalidades]));

    informe.URL_APLICACION = urlLocalSigo;
    informe.MODALIDAD = modalidades.find(function (x) { return x.COD_MODALIDAD === informe.COD_MODALIDAD })?.MODALIDAD;
    informe.PROCEDENCIA = procedencias.find(function (x) { return x.COD_PROCEDENCIA === informe.COD_PROCEDENCIA })?.PROCEDENCIA;
    informe.MATERIA = materias.find(function (x) { return x.COD_MATERIA === informe.COD_MATERIA })?.MATERIA;
    informe.TIPO_CONTRATO = modalidades.find(function (x) { return x.COD_MODALIDAD === informe.COD_MODALIDAD })?.CONTRATO || '';
    informe.FECHA = fnDate.text_long(document.querySelector('#txtFechaEmision').value.trim() || new Date());
    informe.SITD_PASSWORD = app.Tramite?.password || '';
    informe.SUBDIRECTOR = informe.PARTICIPANTES.find(function (x) { return x.funcion === 'Subdirector' })?.apellidosNombres || '[INDICAR SUBDIRECTOR]';
    informe.DIRECTOR = informe.PARTICIPANTES.find(function (x) { return x.funcion === 'Director' })?.apellidosNombres || '[INDICAR DIRECTOR]';
    informe.DENOMINACION_TITULAR = informe.COD_MODALIDAD == '01' ? 'concesionario' : 'administrado';

    //Configuracion de márgenes
    informe.MARGIN_LEFT = { ROOT: '30px', OL: '30px', LEVEL_3: '50px' };

    //EXPEDIENTES ADMINISTRATIVOS
    informe.EXPEDIENTE_ADM = informe.REFERENCIAS.filter(x => x.TIPO_DOCUMENTO?.indexOf('EXPEDIENTE') != -1).map(x => (x.NUMERO || x.CODIGO || 'S/N')).join(', ');
    if (!informe.EXPEDIENTE_ADM) {
        const row = _renderListExpediente.dtRenderListInforme.rows().data().toArray()[0] || {};
        informe.EXPEDIENTE_ADM = row.NUMERO?.match(regExpOSINFOR)[0] || null;
    }

    informe.NUM_INFORME_SITD = informe.NUM_INFORME_SITD || '';

    //Asociamos las infracciones a las RSD en los antecedentes
    for (let item of informe.ANTECEDENTES) {
        if (item.tipoDocumento == 'Resolución Sub Directoral') {
            item.INFRACCIONES = informe.INFRACCIONES
                .filter(x => x.codResolucion == item.codResolucion)
            /*.map(x => {
                x.titulo = x.titulo.replace(/(Respecto a la imputación)\s+(.*)/gi, (m, p1, p2) => {
                    return p2.charAt(0).toUpperCase() + p2.slice(1);
                });

                return x;
            });*/
        }
    }

    //DOCUMENTOS ANTECEDENTES
    informe.ANTECEDENTES_DOCS = {};
    informe.ANTECEDENTES_DOCS.Carta = informe.ANTECEDENTES.find(x => x.tipoDocumento == 'Carta') || {};
    informe.ANTECEDENTES_DOCS.Inf_Sup = informe.ANTECEDENTES.find(x => x.tipoDocumento == 'Informe de Supervisión') || {};
    informe.ANTECEDENTES_DOCS.RSD = informe.ANTECEDENTES.find(x => x.tipoDocumento == 'Resolución Sub Directoral') || {};
    informe.ANTECEDENTES_DOCS.ILEGAL = informe.ANTECEDENTES.find(x => x.tipoDocumento == 'Informe Final de Instrucción') || {};
    informe.ANTECEDENTES_DOCS.Ced_Noti = informe.ANTECEDENTES.find(x => x.tipoDocumento == 'Cédula de Notificación') || {};
    informe.ANTECEDENTES_DOCS.Escrito = informe.ANTECEDENTES.find(x => x.tipoDocumento == 'Escrito') || {};

    //Listar planes de manejo
    //const PLANES_MANEJO = await _informe.ListarPlanesManejo('D', null, informe.COD_THABILITANTE, informe.NUM_POA);
    //const plan = PLANES_MANEJO[0] || {};
    //plan.ARESOLUCION_FECHA = fnDate.text_long(plan.ARESOLUCION_FECHA);
    //plan.INICIO_VIGENCIA = fnDate.text_long(plan.INICIO_VIGENCIA);
    //plan.FIN_VIGENCIA = fnDate.text_long(plan.FIN_VIGENCIA);
    //informe.PLAN_MANEJO = plan;
    informe.PLAN_MANEJO = {};

    //OFICIO
    informe.DOC_REFERENCIAS = {};
    informe.DOC_REFERENCIAS.Oficio = informe.REFERENCIAS.find(x => x.TIPO_DOCUMENTO == 'OFICIO') || {};

    //RESUMEN INF. SUPERVISION
    console.log("Consultando volúmenes de especies ligados al informe de supervisión...");
    let volumenes = [], instituciones = [];

    //informe.ANUM_RESOLUCION = informe.ILEGAL[0].numAResolucion || '';
    //informe.NUM_POA = informe.ILEGAL[0].numPOA || '';
    //informe.NOMBRE_POA = informe.ILEGAL[0].nombrePOA || '';

    for (let item of informe.ILEGAL) {
        const codInformeSupervision = informe.ANTECEDENTES_DOCS.Inf_Sup;
        let INF_SUPERVISION = await _informe.RegResumenInfSupervision(codInformeSupervision);

        if (INF_SUPERVISION) {
            informe.ANTECEDENTES_DOCS.Inf_Sup.FECHA_SUPERVISION_INICIO = INF_SUPERVISION.FECHA_SUPERVISION_INICIO;
            informe.ANTECEDENTES_DOCS.Inf_Sup.FECHA_SUPERVISION_INICIO_TEXTO = fnDate.text_long(INF_SUPERVISION.FECHA_SUPERVISION_INICIO);

            informe.ANTECEDENTES_DOCS.Inf_Sup.FECHA_SUPERVISION_FIN = INF_SUPERVISION.FECHA_SUPERVISION_FIN;
            informe.ANTECEDENTES_DOCS.Inf_Sup.FECHA_SUPERVISION_FIN_TEXTO = fnDate.text_long(INF_SUPERVISION.FECHA_SUPERVISION_FIN);

            //VOLUMEN ANALIZADO
            const resumen = INF_SUPERVISION.VOL_ANALIZADO?.filter(x => !!x.VOLUMEN_INJUSTIFICADO) || [];
            volumenes = volumenes.concat(resumen);
        }

        //RESUMEN
        //const lstInstituciones = await _informe.InstitucionesResolucion(item.codResolucion);
        //instituciones = instituciones.concat(lstInstituciones);
    }

    informe.INSTITUCIONES = instituciones;

    informe.VOLUMENES_INJUSTIFICADOS = volumenes;
    informe.VOLUMENES_INJUSTIFICADOS_TOTAL = Math.round(volumenes.reduce((a, b) => a + b.VOLUMEN_INJUSTIFICADO, 0) * 1000) / 1000;
    //console.log(volumenes);

    //INFRACCIONES
    informe.INFRACCIONES = informe.INFRACCIONES.filter(item => item.flgSeleccionado);

    for (var i = 0; i < informe.INFRACCIONES.length; i++) {
        const infraccion = informe.INFRACCIONES[i];
        const parrafos = await _informe.ExtraerParrafoInfraccion(infraccion, informe);
        infraccion.parrafos = parrafos;
    }

    informe.IMG_SANCION = [];
    if ([2, 3].includes(informe.FLG_SANCION) && informe.SANCION_COD_CALCULO) {
        const images = await _informe.PDFToImgCalculoMulta();
        informe.IMG_SANCION = images;
    }

    const template = await _informe.ExtraerPlantilla();

    informe.VISTOS = _informe.tmpl.get(template, '#tmpl-vistos', informe);
    informe.COMPETENCIA = _informe.tmpl.get(template, '#tmpl-competencia', informe);

    //Plantilla de infracciones 
    informe.ANALISIS = _informe.tmpl.get(template, '#tmpl-analisis', informe);
    informe.RESPONSABLE_SOLIDARIO = _informe.tmpl.get(template, '#tmpl-responsable-solidario', informe);
    informe.GRAVEDAD_OCASIONADA = _informe.tmpl.get(template, '#tmpl-gravedad-ocasionada', informe);
    informe.ACREDITACION_IMPUTACIONES = _informe.tmpl.get(template, '#tmpl-acreditacion-imputaciones', informe);
    informe.MEDIDAS_COMPLEMENTARIAS = _informe.tmpl.get(template, '#tmpl-medidas-complementarias', informe);
    informe.MEDIDAS_CORRECTIVAS = _informe.tmpl.get(template, '#tmpl-medidas-correctivas', informe);
    informe.COMUNICACION_ENTIDADES = _informe.tmpl.get(template, '#tmpl-comunicacion-entidades', informe);
    informe.RESOLUCION = _informe.GenerarResolucion(template, informe);

    informe.PIE_PAGINA = _informe.tmpl.get(template, '#tmpl-pie-pagina', informe)?.replace(/PASSWORD/g, app.Tramite?.password || 'PASSWORD');

    console.log(informe);
    const header = _informe.tmpl.get(template, '#tmpl-encabezado', informe);

    let html = '';
    html += _informe.tmpl.get(template, '#tmpl-exportar', informe);
    html += _informe.tmpl.get(template, '#tmpl-pie-pagina-estructura', informe);

    html += _informe.tmpl.get(template, '#tmpl-footnotes', informe);
    html = _informe.RevisarFootnotes(html);

    //Enumeracion
    html = _informe.EnumerarCuadros(html);
    html = _informe.EnumerarParrafos(html, informe.MARGIN_LEFT.OL);

    $(document).googoose({ html, header });
}

_informe.RegResumenInfSupervision = function (COD_INFORME_SUPERVISION) {
    return new Promise(function (resolve, reject) {
        const params = {
            type: 'get',
            url: `${urlLocalSigo}Fiscalizacion/InformeLegalDigital/ObtenerInformeSupervision`,
            data: { COD_INFORME_SUPERVISION }
        };

        $.ajax(params).done((res) => resolve(res)).fail(() => resolve(null));
    });
}

_informe.ExtraerAntecedentes = function (COD_RESOLUCION) {
    //const COD_THABILITANTE = app.Informe.COD_THABILITANTE;

    const params = {
        type: 'get',
        url: `${urlLocalSigo}Fiscalizacion/ManPAURD/ObtenerAntecedentes`,
        data: { COD_RESOLUCION },
        global: false
    }

    return new Promise((resolve, reject) => {
        $.ajax(params).done(res => resolve(res)).fail(() => resolve([]));
    });
};

_informe.ExtraerPlantilla = function () {
    return new Promise(function (resolve, reject) {
        const params = {
            type: 'get',
            url: `${urlLocalSigo}Fiscalizacion/ManPAURD/PlantillaInforme`,
            dataType: 'html'
        };

        utilSigo.fnAjax(params, function (html) {
            html ? resolve(html) : reject(null);
        });
    });
}

_informe.ExtraerParrafoInfraccion = function (infraccion, informe) {
    return new Promise(function (resolve, reject) {
        const params = {
            type: 'get',
            url: `${urlLocalSigo}Fiscalizacion/ManPAURD/ObtenerInfraccion`,
            dataType: 'html',
            datos: {
                modalidad: informe.MODALIDAD,
                inciso: infraccion.inciso.replace(/\W+/gi, '')
            }
        };

        utilSigo.fnAjax(params, function (html) {
            if (html) {
                try {
                    const script_html = `<script id="template" type="text/x-jquery-tmpl">${html}</script>`;
                    //Template jquery                    
                    html = _informe.tmpl.get(script_html, '#template', { infraccion, informe });

                    resolve(html);
                } catch (e) {
                    const message = 'No se pudo construir los párrafos para la infracción';
                    resolve(`<h5>${message}</h5>`);
                    console.log(message, infraccion, e);
                }
            }
            else reject(null);
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
        url: `${urlLocalSigo}Fiscalizacion/ManPAURD/GuardarRD`,
        datos: JSON.stringify({ informeDigital: parametros }),
    }
    utilSigo.fnAjax(params, function (res) {
        //console.log(res);
        let objEN = res.data;
        if (res.success) {
            app.Informe.COD_INFORME_DIGITAL = objEN.COD_INFORME_DIGITAL;

            objEN.PARTICIPANTES.forEach(function (x) {
                x.flgAplica = !!x.estado;
                x.accion = 1;
            });

            objEN.DOCUMENTOS.forEach(function (x) { x.accion = 1; });
            objEN.ILEGAL.forEach(function (x) { x.accion = 1; });
            objEN.INFRACCIONES.forEach(function (x) { x.accion = 1; });
            objEN.ANTECEDENTES.forEach(function (x) { x.accion = 1; });
            app.Informe.REFERENCIAS.forEach(function (x) { x.RegEstado = 0; });

            app.Informe.PARTICIPANTES = objEN.PARTICIPANTES;
            app.Informe.DOCUMENTOS = objEN.DOCUMENTOS;
            app.Informe.ILEGAL = objEN.ILEGAL;
            app.Informe.INFRACCIONES = _informe.CombinarInfracciones(objEN.INFRACCIONES);
            app.Informe.ANTECEDENTES = objEN.ANTECEDENTES;
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

_informe.CombinarInfracciones = function (lstInfracciones) {
    let infracciones = [];

    for (const infraccion of lstInfracciones) {
        if (!infracciones.find(x => x.inciso == infraccion.inciso)) {
            infracciones.push(infraccion);
        }
    }

    //Ordenamos los incisos
    return infracciones.sort((a, b) => {
        return (isNaN(a.inciso) || isNaN(b.inciso)) ? -1 : (+a.inciso > +b.inciso ? 1 : -1);
    });
}

_informe.ValidarNumero = function (value) {
    return /^\d+$/.test(value);
}

_informe.Estructura = function () {
    let objEN = JSON.parse(JSON.stringify(app.Informe));

    objEN.PARTICIPANTES.forEach(function (x, i) {
        if (!x.flgAplica) x.estado = 0;
        else x.estado = x.estado || 1;
    });

    objEN.DOCUMENTOS.forEach(function (x, i) {
        if (x.estado === null) x.estado = 1;
    });

    objEN.INFRACCIONES.forEach(function (x, i) {
        if (x.estado === null) x.estado = 1;
        x.detalle = x.detalle?.trim();
    });

    objEN.ILEGAL.forEach(function (x, i) {
        if (x.estado === null) x.estado = 1;
    });

    objEN.ANTECEDENTES.forEach(function (x, i) {
        if (x.estado === null) x.estado = 1;
        x.fechaEmisionTexto = x.fechaEmision ? fnDate.text_long(x.fechaEmision) : '';
        x.fechaNotificacionTexto = x.fechaNotificacion ? fnDate.text_long(x.fechaNotificacion) : '';
    });    

    let parametros = {
        ...objEN,
        ELIMINAR: objEN.ELIMINAR
    };

    return parametros;
}

_informe.RutaDocumentoDescarga = function () {
    let name = `${app.Informe.ESTADO >= States.FINALIZADO ? 'RESOLUCION-SUBDIRECTORAL-' : ''}${_informe.fileName()}`;
    let base = app.Informe.ESTADO >= States.FINALIZADO ? urlBaseDocFirmaTrans : urlBaseDocFirma;
    return `${urlLocalSigo}${base}/${name}?v=${new Date().getTime()}`;
}

_informe.VerDocumento = function () {
    let url = _informe.RutaDocumentoDescarga();
    window.open(url);
}

_informe.CARGAR_ARCHIVO = function () {
    if (!app.Tramite) {
        utilSigo.toastWarning('', 'No se ha generado el Nro de Resolución Sub Directoral previamente');
        return;
    }

    const callback = function (_, fileName) {
        documentName_ = fileName;
    }

    modal_doc.accept = ['application/pdf'];
    modal_doc.show({ name: app.Tramite.cCodificacion, callback });
}

_informe.ENVIAR_CONTROL_CALIDAD = function () {
    const user = ManRD_AddEdit.userApp || {};
    const data = {
        NUM_INFORME_SITD: app.Informe.NUM_INFORME_SITD,
        URL_DESCARGA: _informe.RutaDocumentoDescarga(),
        USUARIO: user.PERSONA
    }

    const message = $('#tmpl-notificacion-calidad').tmpl(data).html();
    modal_notificar.form.Mensaje = message;
    modal_notificar.callback = function () {
        console.log('Notificado a control de calidad');
    }
    modal_notificar.Abrir([]);
}

_informe.BuscarPersonaNotificar = function () {
    if (!modal_notificar.form.Persona) {
        modal_notificar.form.Persona = {
            codPersona: null,
            apellidosNombres: null,
            estado: null
        };
    }

    app.BuscarPersona(modal_notificar.form.Persona);
}

_informe.TRANSFERIR = function () {
    let flgSignAll = app.Informe.PARTICIPANTES.filter(function (x) { return x.flgAplica && x.estado < 3 }).length === 0;
    if (!flgSignAll) {
        utilSigo.toastWarning('Firmas incompletas', 'Se deben completar todas las firmas antes de transferir el documento final');
        return;
    }

    utilSigo.dialogConfirm('Transferir', '¿Desea transferir al SITD el documento firmado?', function (r) {
        if (r) {
            utilSigo.fnAjax({
                type: 'post',
                url: `${urlLocalSigo}Fiscalizacion/ManPAURD/TransferirDocSITD`,
                datos: JSON.stringify({
                    tramiteId: app.Tramite.iCodTramite,
                    codInformeDigital: app.Informe.COD_INFORME_DIGITAL,
                    codInforme: app.Informe.COD_INFORME,
                    codificacion: _informe.fileName()
                })
            }, function (res) {
                if (res.success) {
                    _informe.CambiarEstado(States.FINALIZADO);
                    utilSigo.toastSuccess('Transferido', res.msj);
                } else {
                    utilSigo.toastError('Atención', res.msj);
                }
            });
        }
    });
};

_informe.ANULAR = function () {
    utilSigo.dialogConfirm('Eliminar firmas', 'Esta acción retornará al estado COMPLETADO y podrá cargar nuevamente el documento. ¿Desea continuar?', function (r) {
        if (r) {
            utilSigo.fnAjax({
                type: 'post',
                url: `${urlLocalSigo}Fiscalizacion/ManPAURD/AnularFirmaPorInforme`,
                datos: JSON.stringify({
                    codInforme: app.Informe.COD_INFORME_DIGITAL,
                    codificacion: _informe.fileName()
                })
            }, function (res) {
                if (res.success) {
                    _informe.CambiarEstado(States.COMPLETADO);

                    //Actualizar tabla de supervisores FLAG_FIRMA
                    app.Informe.PARTICIPANTES.forEach(function (item) {
                        if (item.flgAplica && item.estado > 3) item.estado = 3;
                    });

                    utilSigo.toastSuccess('Listo', res.msj);
                } else {
                    utilSigo.toastError('Error', res.msj);
                }
            });
        }
    });
}

_informe.ObtenerRutaResolucion = function (item) {
    return `${urlLocalSigo}Fiscalizacion/InformeLegal/CreateOrEdit?asCodInfLegal=${item.codILegal}&show_informe=true`;
}

_informe.DescargarDocumentoSITD = function (obj) {
    const row = $(obj).closest('tr');
    const item = $(obj).closest('table').DataTable().row(row).data();
    if (!item || !item.PDF_DOCUMENTO?.trim()) {
        utilSigo.toastWarning("No existe URL de descarga de archivo");
        return;
    }

    const data = JSON.parse(JSON.stringify(item));
    descargarTramite(data); //_finalInstruccion.cshtml
}

_informe.fnEliminarReferencia = function (obj) {
    const row = $(obj).closest('tr');
    const item = $(obj).closest('table').DataTable().row(row).data();
    if (!item) return;

    if (app.Informe.ESTADO == States.FINALIZADO) {
        utilSigo.toastWarning("No se puede eliminar el archivo en estado FINALIZADO");
        return;
    }

    const index = item.index;

    if (item.COD_ILACCION)
        app.Informe.ELIMINAR.push({ codInforme: app.Informe.COD_RESOLUCION, item: item.COD_ILACCION, origen: 'REFERENCIA' });

    if (item.SUBTIPO == '01') {
        const data = _renderTerminoPau.dtRenderListSTD1.rows().data().toArray();
        const i = data.findIndex(x => x.CODIGO == item.CODIGO && x.TIPO_DOCUMENTO == item.TIPO_DOCUMENTO);
        i != -1 && _renderTerminoPau.dtRenderListSTD1.row(i).remove().draw();
    } else if (item.SUBTIPO == '02') {
        const data = _renderTerminoPau.dtRenderListSTD02.rows().data().toArray();
        const i = data.findIndex(x => x.CODIGO == item.CODIGO && x.TIPO_DOCUMENTO == item.TIPO_DOCUMENTO);
        i != -1 && _renderTerminoPau.dtRenderListSTD02.row(i).remove().draw();
    } else {
        //const i = _renderTerminoPau.dtOtrosDocumentos.findIndex(x => x.CODIGO == item.CODIGO && x.TIPO_DOCUMENTO == item.TIPO_DOCUMENTO);
        //i != -1 && _renderTerminoPau.dtOtrosDocumentos.splice(i, 1);
    }

    app.Informe.REFERENCIAS.splice(index, 1);
}

_informe.EliminarResolucion = function (item, index) {
    if (item.codInformeDigital) {
        app.Informe.ELIMINAR.push({ codInforme: item.codInformeDigital, item: item.item, origen: 'ILEGAL' });

        app.Informe.INFRACCIONES
            .filter(x => x.codILegal == item.codILegal)
            .forEach(item => {
                app.Informe.ELIMINAR.push({ codInforme: item.codInformeDigital, item: item.item, origen: 'INFRACCION' });
            });

        app.Informe.DOCUMENTOS
            .filter(x => x.codILegal == item.codILegal)
            .forEach(item => {
                app.Informe.ELIMINAR.push({ codInforme: item.codInformeDigital, item: item.item, origen: 'DOCUMENTO' });
            });

        app.Informe.ANTECEDENTES
            .filter(x => x.codILegal == item.codILegal)
            .forEach(item => {
                app.Informe.ELIMINAR.push({ codInforme: item.codInformeDigital, item: item.item, origen: 'ANTECEDENTE' });
            });
    }

    app.Informe.INFRACCIONES = app.Informe.INFRACCIONES.filter(x => x.codILegal != item.codILegal);
    app.Informe.DOCUMENTOS = app.Informe.DOCUMENTOS.filter(x => x.codILegal != item.codILegal);
    app.Informe.ANTECEDENTES = app.Informe.ANTECEDENTES.filter(x => x.codILegal != item.codILegal);

    app.Informe.ILEGAL.splice(index, 1);
}

_informe.ResumenInforme = function () {
    const group = $('#group-analisis');

    $.ajax({
        type: 'get',
        url: urlLocalSigo + 'Supervision/ManInforme/_ResumenInforme',
        data: { asCodInforme: app.Informe.COD_INFORME },
        beforeSend: function () {
            group.html('Cargando información...');
        },
    }).done(function (html) {
        group.html(html);
    });
}

_informe.EXTRAER_RESUMEN_INFORME = function () {
    return new Promise((resolve, reject) => {
        const asCodInforme = app.Inf_Supervision[0].COD_INFORME;

        utilSigo.fnAjax({
            type: 'get',
            url: `${urlLocalSigo}Supervision/ManInforme/_DataResumenInforme`,
            datos: { asCodInforme: asCodInforme }
        }, res => resolve(res), () => resolve({ volumenes: [], especies: [] }));
    })
}

_informe.EXTRAER_PARRAFOS_INFRACCION = function (template, informe) {
    const infracciones = JSON.parse(JSON.stringify(informe.INFRACCIONES))
        //.filter(item => item.codModalidad == informe.COD_MODALIDAD && item.select)
        .map(function (item, index) {
            //item.numeration = _informe.NumeroALetra(index + 1);            
            item.html = _informe.tmpl.get(template, '#tmpl-' + item.codPlantilla, informe);
            return item;
        });

    return infracciones;
}

_informe.SITD_OPEN = function () {
    utilSigo.fnAjax({
        type: 'get',
        url: `${urlLocalSigo}Fiscalizacion/ManPAURD/TramiteGeneral`
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
            modal_sitd.form.cCodTipoDoc = datos.cCodTipoDoc || "25";
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

_informe.Extraer_Plantilla = function () {
    return new Promise(function (resolve, reject) {
        const params = {
            type: 'get',
            url: `${urlLocalSigo}Fiscalizacion/ManPAURD/PlantillaInforme`,
            dataType: 'html'
        };

        utilSigo.fnAjax(params, function (html) {
            html ? resolve(html) : reject(null);
        });
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
        url: `${urlLocalSigo}Fiscalizacion/ManPAURD/TramiteGeneralByCriterio`,
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
    obj.cod_Informe = app.Informe.COD_RESOLUCION;
    obj.fechaRegistro = fnDate.toDate(obj.fechaRegistro);

    if (!obj.trabajadorId) {
        utilSigo.toastWarning('Atención', 'Por favor especifique un trabajador');
        return;
    }

    let tb = data.trabajadores.find(function (x) { return x.trabajadorId == obj.trabajadorId });
    if (tb) {
        obj.perfilId = tb.perfilId;
    }

    obj.lstReferencias = app.Inf_Supervision.map(function (x) {
        return {
            //iCodTramiteRef: '',
            cReferencia: x.NUM_INFORME,
            cDesEstado: 'REGISTRADO',
            iCodTipo: 1
        }
    });

    let params = {
        type: 'post',
        url: `${urlLocalSigo}Fiscalizacion/ManPAURD/${obj.iCodTramite ? 'TramiteModificar' : 'TramiteGuardar'}`,
        datos: JSON.stringify({ tramite: obj }),
    };

    utilSigo.fnAjax(params, function (res) {
        if (res.success) {
            res.data = res.data || app.Tramite || obj;

            if (res.data) {
                let data = _informe.Estructura();
                data.TRAMITE_ID = res.data.iCodTramite || data.TRAMITE_ID;
                data.NUM_INFORME_SITD = res.data.cCodificacion || data.NUM_INFORME_SITD;
                data.SITD_FECHA_REGISTRO = fnDate.text(res.data.fechaRegistro);

                //Actualizamos las variables
                app.Informe.TRAMITE_ID = data.TRAMITE_ID;
                app.Informe.NUM_INFORME_SITD = data.NUM_INFORME_SITD;

                $('#txtNumeroResolucion').val(data.NUM_INFORME_SITD);
                $('#txtFechaEmision').val(data.SITD_FECHA_REGISTRO);

                //Asignamos la data a la variable
                app.Tramite = res.data;

                //Guardamos
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

        if (!window._manCalMul) {
            utilSigo.toastWarning('Atención', 'No se ha cargado correctamente el modal de cálculo de multa, intente de nuevo');
            return;
        };

        _manCalMul.fnGuardar = $.Deferred();

        if (!app.Informe.SANCION_COD_CALCULO) {
            _manCalMul.fnCrear();

            const administrado = {
                EXPEDIENTE: app.Informe.REFERENCIAS[0]?.CODIGO,
                ADMINISTRADO: app.Informe.R_LEGAL || app.Informe.TITULAR,
                TIPO_DOC: app.Informe.R_LEGAL_DOCUMENTO || app.Informe.R_LEGAL_RUC || app.Informe.TITULAR_DOCUMENTO || app.Informe.TITULAR_RUC,
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

_informe.ObtenerInformeLegal = function (COD_ILEGAL) {
    const params = {
        url: `${urlLocalSigo}Fiscalizacion/ManPAURD/ObtenerResumenInformeLegal`,
        type: 'GET',
        data: { COD_ILEGAL: COD_ILEGAL },
        beforeSend: function () {
            utilSigo.blockUIGeneral();
        },
        complete: function () {
            utilSigo.unblockUIGeneral();
        }
    };

    return new Promise((resolve, reject) => {
        $.ajax(params)
            .fail(function (xhr) {
                resolve(null);
                if (xhr.status == 200) {
                    utilSigo.toastWarning('Sin datos', 'No se encontró información de la resolución')
                }
            }).done(function (res) {
                resolve(res);
            })
    });
}

_informe.Agregar_Integrante = function () {
    modal_integrante.Abrir();
}

_informe.Agregar_Imputaciones = function () {
    utilSigo.dialogConfirm("", 'Para agregar imputaciones lo dirigiremos a la sección de "Infracciones imputadas Según Ley" en la pestaña de "Recomendaciones". Guarde los datos antes continuar.', function (r) {
        if (r) {
            $('#idnavRecomTermPAu > a').click();

            setTimeout(function () {
                $("#frmInfracciones").get(0).scrollIntoView();
            }, 500);
        }
    });
}

/*_informe.Establecer_Infracciones_Form = function () {
    let model = {
        COD_ILEGAL_ARTICULOS: null,
        COD_ILEGAL_ENCISOS: null,
        DESCRIPCION_ARTICULOS: null,
        DESCRIPCION_ENCISOS: null,
        COD_ESPECIES: null,
        DESCRIPCION_ESPECIE: null,
        VOLUMEN: null,
        AREA: null,
        NUMERO_INDIVIDUOS: null,
        DESCRIPCION_INFRACCIONES: null,
        COD_SECUENCIAL: null,
        NUM_POA: null,
        POA: null,
        PCA: null,
        TIPOMADERABLE: null,
        RegEstado: null
    }
}*/

_informe.Obtener_Infracciones_Form = function () {
    return _renderInfracciones.dtRenderListInforme.data().toArray().reduce((acc, item) => {
        if (!acc.some(x => x.codInciso == item.COD_ILEGAL_ENCISOS)) {
            return [
                ...acc,
                {
                    accion: 0,
                    area: item.AREA,
                    codEspecie: item.COD_ESPECIES,
                    codILegal: null,
                    codInciso: item.COD_ILEGAL_ENCISOS,
                    codInformeDigital: app.Informe.COD_INFORME_DIGITAL,
                    codResolucion: $('#hdfCodResodirec').val(),
                    detalle: item.DESCRIPCION,
                    especie: item.DESCRIPCION_ESPECIE,
                    estado: 1,
                    flgSeleccionado: true,
                    gravedad: item.GRAVEDAD,
                    inciso: item.DESCRIPCION_ENCISOS,
                    item: 9,
                    nroIndividuos: item.NUMERO_INDIVIDUOS,
                    numPOA: item.NUM_POA,
                    parrafos: null,
                    rangoSancion: null,
                    tipoInfraccion: item.TIPO,
                    tipoMaderable: item.TIPOMADERABLE,
                    titulo: item.TITULO,
                    volumen: item.VOLUMEN
                }
            ];
        }

        return acc;

    }, []);
}

$(function () {
    app = new Vue({
        el: '#frmInforme',
        data: {
            Informe: {
                COD_INFORME_DIGITAL: null,
                COD_RESOLUCION: null,
                NUM_INFORME_SITD: null,
                COD_PROCEDENCIA: null,
                PROCEDENCIA: null,
                COD_TIPO_INFORME: 1,
                COD_MATERIA: null,
                MATERIA: null,
                COD_MODALIDAD: null,
                MODALIDAD: null,

                COD_INFORME: null, //Informe de supervision (auxiliar, obtenemos de la cabecera)
                NRO_REFERENCIA: null,
                INF_FECHA: null,
                NUM_POA: null, // POA
                NOMBRE_POA: null,

                TITULAR_SUPERVISADO: null,
                DOCUMENTO_TITULAR: null,
                RUC_TITULAR: null,
                REPRESENTANTE_LEGAL: null,
                DOCUMENTO_RLEGAL: null,
                COD_THABILITANTE: null,
                NUM_THABILITANTE: null,
                TITULAR_ESTADO_RUC: null,
                TITULAR_CONDICION_RUC: null,
                DIRECCION_LEGAL: null,
                ILEGAL: [],
                REFERENCIAS: [],
                ANTECEDENTES: [],
                PARTICIPANTES: [],
                DOCUMENTOS: [],
                INFRACCIONES: [],
                ELIMINAR: [],

                FLG_RESPOSABLE_SOLIDARIO: true,
                FLG_GRAVEDAD_OCASIONADA: true,
                FLG_ACREDITACION_IMPUTACIONES: true,
                FLG_SANCION: 0,
                SANCION_UIT: 0,
                SANCION_COD_CALCULO: null,
                FLG_MEDIDAS_COMPLEMENTARIAS: true,
                FLG_MEDIDAS_CORRECTIVAS: true,
                FLG_COMUNICACION_ENTIDADES: true,

                RUTA_ARCHIVO_REVISION: null,
                FECHA_REGISTRO: new Date(),
                ESTADO: 1,
                FLG_ACTUALIZAR: false,
            },
            Inf_Supervision: [],
            oficinaDefault: null,
            Tramite: null,
            Procedencias: [
                { COD_PROCEDENCIA: 'DPSFFS', PROCEDENCIA: 'Dirección del Procedimiento Sancionador Forestal y de Fauna Silvestre' },
            ],
            Materias: [
                { COD_MATERIA: '01', MATERIA: 'Fauna Silvestre' },
                { COD_MATERIA: '02', MATERIA: 'Recursos Forestales' },
            ],
            Modalidades: []
        },
        methods: {
            init: async function () {
                const self = this;

                const datos = ManRD_AddEdit.frm.serializeObject();
                const user = ManRD_AddEdit.userApp;

                //Valores por defecto
                const values = {
                    COD_PROCEDENCIA: "DPSFFS",
                    COD_MATERIA: "02",
                    COD_RESOLUCION: datos.hdfCodResodirec,
                    NUM_INFORME_SITD: datos.txtNumeroExpediente,
                    COD_THABILITANTE: datos.hdfCodTitular,
                    RES_DIRECTORAL_FECHA: fnDate.text(new Date()),
                    REPRESENTANTE_LEGAL: document.getElementById('txtTitular')?.value,
                    PARTICIPANTES: [
                        { funcion: 'Especialista Legal', codPersona: user.COD_PERSONA, apellidosNombres: user.PERSONA, flgAplica: true, estado: 1 },
                        { funcion: 'Ingeniero Forestal', codPersona: null, apellidosNombres: null, flgAplica: true, estado: null },
                        { funcion: 'Coordinador', codPersona: null, apellidosNombres: null, flgAplica: true, estado: null },
                        { funcion: 'Subdirector', codPersona: null, apellidosNombres: null, flgAplica: true, estado: null },
                        { funcion: 'Director', codPersona: null, apellidosNombres: null, flgAplica: true, estado: null },
                    ],
                    DOCUMENTOS: [],
                };

                const infracciones = _informe.Obtener_Infracciones_Form();                
                values.INFRACCIONES = infracciones;

                self.Informe = { ...self.Informe, ...values };

                self.MateriaOnChange();

                //Verificamos si existe informacion registrada en la base de datos
                if (self.Informe.COD_RESOLUCION) {
                    const res_general = await self.Informacion(values);

                    const res_tramite = await self.TramiteByID();

                    if (res_tramite.success) {
                        self.Tramite = res_tramite.data;
                        //app.Informe.DESTINATARIO = res_tramite.data.trabajador;
                    }

                    //Recursos
                    if (!self.Informe.COD_INFORME_DIGITAL) {
                        //const res_files = await self.ObtenerArchivos();
                    }
                }
            },
            MateriaOnChange: function () {
                this.Modalidades = data.Modalidades.filter(x => x.COD_MATERIA === this.Informe.COD_MATERIA);
                this.Informe.COD_MODALIDAD = this.Modalidades[0].COD_MODALIDAD;
            },
            Informacion: function (values) {
                const self = this;

                return new Promise((resolve, reject) => {
                    let params = {
                        type: 'get',
                        url: `${urlLocalSigo}Fiscalizacion/ManPAURD/ObtenerRD`,
                        datos: { COD_RESOLUCION: self.Informe.COD_RESOLUCION }
                    };

                    utilSigo.fnAjax(params, async function (res) {
                        if (res.informe) {
                            res.informe.PARTICIPANTES.forEach(function (x) {
                                x.flgAplica = !!x.estado;
                            });

                            res.informe.INFRACCIONES = _informe.CombinarInfracciones([...res.informe.INFRACCIONES, ...app.Informe.INFRACCIONES]);

                            self.Informe = { ...self.Informe, ...res.informe };
                            self.MateriaOnChange();
                            //==========================================================
                            self.Informe.COD_PROCEDENCIA = res.informe.COD_PROCEDENCIA;
                            self.Informe.COD_MATERIA = res.informe.COD_MATERIA;
                            self.Informe.COD_MODALIDAD = res.informe.COD_MODALIDAD;
                            //==========================================================

                            self.Informe.COD_RESOLUCION = res.informe.COD_RESOLUCION || values.COD_RESOLUCION || null;
                            self.Informe.NUM_INFORME_SITD = res.informe.NUM_INFORME_SITD || values.NUM_INFORME_SITD || null;
                            self.Informe.R_LEGAL = res.informe.R_LEGAL || values.R_LEGAL || null;
                            self.Informe.TITULAR_DOCUMENTO = (res.informe.TITULAR_DOCUMENTO || '').trim();
                            self.Informe.TITULAR_RUC = (res.informe.TITULAR_RUC || '').trim();

                            //REFERENCIAS
                            const getReferences = (lst, SUBTIPO) => {
                                return lst.map(x => ({
                                    //COD_RDACCION: x.COD_RDACCION,
                                    COD_RESODIREC: self.Informe.COD_RESOLUCION,
                                    CODIGO: x.CODIGO,
                                    NUMERO: x.NUMERO,
                                    TIPO_DOCUMENTO: x.TIPO_DOCUMENTO,
                                    PDF_DOCUMENTO: x.PDF_DOCUMENTO,
                                    SUBTIPO: SUBTIPO,
                                    SUBTIPO_DETALLE: modal_referencias.subtipos.find(s => s.SUBTIPO == SUBTIPO)?.DESCRIPCION,
                                    RegEstado: 0
                                }));
                            }

                            const lstSITD01 = getReferences(_renderTerminoPau.dtRenderListSTD1.rows().data().toArray(), '01');
                            const lstSITD02 = getReferences(_renderTerminoPau.dtRenderListSTD02.rows().data().toArray(), '02');
                            //const lstSITD03 = getReferences(_renderTerminoPau.dtOtrosDocumentos, null);

                            //console.log(lstSITD01, lstSITD02);
                            self.Informe.REFERENCIAS = [...lstSITD01, ...lstSITD02];
                        }

                        if (!res.informe) {
                            //Expedientes del TAB Datos Generales
                            const expedientes = _renderListExpediente.dtRenderListInforme.rows().data().toArray()
                                .map(x => {
                                    const match = x.NUMERO.match(regExpOSINFOR);
                                    x.NUMERO = match ? match[0] : x.NUMERO;
                                    return x;
                                });

                            //console.log(expedientes);

                            if (expedientes.length > 0) {
                                const expediente = await self.ExtraerExpediente(expedientes[0].NUMERO);
                                app.Informe.REFERENCIAS.push(expediente);
                            }
                        }

                        resolve(res);
                    });
                });
            },
            ExtraerExpediente: function (NRO_DOCUMENTO) {
                return new Promise((resolve, reject) => {
                    const params = {
                        type: 'get',
                        url: `${urlLocalSigo}Fiscalizacion/InformeLegalDigital/ObtenerExpediente`,
                        data: { NRO_DOCUMENTO }
                    };

                    $.ajax(params)
                        .done(function (res) {
                            var model = {
                                COD_ILEGAL: app.Informe.COD_INFORME,
                                SUBTIPO: null,
                                SUBTIPO_DETALLE: 'Otro',
                                CODIGO: res.cCodificacion,
                                NUMERO: res.cNroDocumento,
                                TIPO_DOCUMENTO: res.cDescTipoDoc,
                                PDF_DOCUMENTO: res.PDF_TRAMITE_SITD,
                                RegEstado: 1
                            };

                            resolve(model);
                        }).fail(function (xhr) {
                            reject();
                        });
                })
            },
            TramiteByID: function (datos) {
                const self = this;
                datos = datos || JSON.parse(JSON.stringify(self.Informe));

                const promise = new Promise((resolve, reject) => {
                    if (!datos.TRAMITE_ID || !datos.COD_THABILITANTE || !datos.COD_RESOLUCION) {
                        resolve({ success: false, message: "Faltan datos para extraer información de trámite" });
                        return;
                    }

                    const params = {
                        url: `${urlLocalSigo}Fiscalizacion/ManPAURD/TramiteGetById`,
                        datos: { id: datos.TRAMITE_ID, codTHabilitante: datos.COD_THABILITANTE, codInforme: datos.COD_RESOLUCION }
                    };


                    utilSigo.fnAjax(params, function (res) {
                        resolve(res);
                    });
                });

                return promise;
            },
            ObtenerArchivos: function () {
                const self = this;

                const promise = new Promise((resolve, reject) => {
                    const params = {
                        type: 'get',
                        url: `${urlLocalSigo}General/Controles/buscarIntegracionSIADO`,
                        datos: {
                            asCriterio: 'SUBTIP_TITDOCSIGO',
                            asSubCriterio: '0006',
                            asValor: self.Informe.COD_INFORME //COD_INFORME
                        }
                    };

                    utilSigo.fnAjax(params, function (res) {
                        if (res.success) {
                            let files = res.data.map(function (item, index) {
                                return {
                                    tipo: item.ORIGEN,
                                    nombre: `${item.DETINV_DESCRIPCION}`,
                                    url: urlLocalSigo + "General/Controles/DescargarIntegracionSIADO?fileName=" + item.DETINV_CODDOC + "&origen=" + item.ORIGEN,
                                    estado: 1
                                }
                            });

                            self.Informe.DOCUMENTOS = files;
                            resolve(files);
                        }
                    });
                });

                return promise;
            },
            Eliminar_Archivo: function (item, index) {
                let self = this;
                utilSigo.dialogConfirm("", "¿Desea quitar el recurso como insumo para el análisis?", function (r) {
                    if (r) {
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
            AbrirModalPersona: function () {
                return new Promise((resolve, reject) => {
                    var option = {
                        url: `${urlLocalSigo}General/Controles/_BuscarPersonaGeneral`,
                        type: 'GET',
                        datos: { asBusGrupo: "PERSONA", asCodPTipo: "TODOS", asTipoPersona: "N" },
                        divId: "mdlBuscarPersona"
                    };
                    utilSigo.fnOpenModal(option, function () {
                        resolve();

                        _bPerGen.fnInit();
                    });
                })

            },
            BuscarPersona: function (item) {
                const self = this;

                self.AbrirModalPersona().then(data => {
                    _bPerGen.fnAsignarDatos = function (obj) {
                        if (obj) {
                            const data = _bPerGen.dtBuscarPerona.row($(obj).parents('tr')).data();
                            item.codPersona = data.COD_PERSONA;
                            item.apellidosNombres = data.PERSONA;
                            item.estado = 1;

                            self.Informe.FLG_ACTUALIZAR = true;
                            utilSigo.fnCloseModal("mdlBuscarPersona");
                        }
                    }
                });
            },
            AgregarIFI: function () {
                modal_ifi.Abrir();
            },
            Abrir_Notificar: async function (item) {
                const self = this;
                modal_notificar.form.Mensaje = 'Por favor revisar el informe para la continuidad del proceso.';
                modal_notificar.form.CC = '';

                let users = [];

                if (item) users = [item.codPersona];
                else users = this.Informe.PARTICIPANTES.filter(item => item.flgAplica).map(user => user.codPersona);

                const correos = await modal_notificar.ObtenerCorreos(users);

                //Actualizar los participantes despues de notificar
                modal_notificar.callback = function (enviado) {
                    const personas = self.Informe.PARTICIPANTES
                        .filter(item => enviado.find(x => x.codPersona == item.codPersona));

                    const participantes = personas.map(item => ({
                        ...item,
                        codInformeDigital: self.Informe.COD_INFORME_DIGITAL,
                        estado: item.estado > 2 ? item.estado : 2
                    }));

                    if (!participantes.length) {
                        return;
                    }

                    let params = {
                        type: 'post',
                        url: `${urlLocalSigo}Fiscalizacion/ManPAURD/ParticipanteActualizar`,
                        datos: JSON.stringify({ participantes })
                    };

                    utilSigo.fnAjax(params, function () {
                        self.Informe.PARTICIPANTES.forEach(x => {
                            const data = participantes.find(item => item.item == x.item);
                            if (data) {
                                x.estado = data.estado;
                            }
                        });
                    });
                }

                modal_notificar.Abrir(correos);
            },
            Revisar: function (item, index) {
                //let self = this;
                let user = ManRD_AddEdit.userApp || {};
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
                //Notificar al Especialista Legal
            },
            Firmar: function (item, index) {
                let user = ManRD_AddEdit.userApp || {};
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

    modal_ifi = new Vue({
        el: '#modal-ifi',
        data: {
            opciones: [],
            opcion: 'ILEGAL_NUMERO',
            texto: null,
            tabla: {}
        },
        methods: {
            Abrir: function () {
                const self = this;
                const params = {
                    url: `${urlLocalSigo}Fiscalizacion/InformeLegalDigital/ExtraerOpcionesBuscar`,
                    datos: { BusCriterio: 'INFORME_LEGAL' }
                };

                if (!self.opciones.length) {
                    utilSigo.fnAjax(params, function (res) {
                        self.opciones = res;

                        if (!window.dtb_ifi) {
                            window.dtb_ifi = $('#dt_ifi').DataTable({
                                processing: true,
                                serverSide: true,
                                searching: false,
                                ordering: false,
                                paging: true,
                                deferLoading: 0,
                                ajax: {
                                    url: initSigo.urlControllerGeneral + "/GetListaGeneralPaging_v3",
                                    data: function (d) {
                                        d.customSearchEnabled = true;
                                        d.customSearchForm = 'INFORME_LEGAL';
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
                                    { data: 'ILEGAL_NUMERO', title: 'N° INFORME LEGAL' },
                                    { data: 'NUMERO_INFORME', title: 'N° INFORME SUPERVISIÓN' },
                                    { data: 'NUMERO_RESOLUCION', title: 'N° RESOLUCIÓN' },
                                    { data: 'NUMERO_EXPEDIENTE', title: 'N° EXPEDIENTE' },
                                    {
                                        orderable: false,
                                        data: null,
                                        width: '20px',
                                        render: (data, type, row, meta) => {
                                            return `<i class="fa fa-lg fa-check text-success px-2" onclick="modal_ifi.Agregar(this)"></i>`;
                                        }
                                    }
                                ],
                                autoWidth: false,
                                lengthMenu: [[10, 20, 50, 100], [10, 20, 50, 100]],
                                //bLengthChange: false,
                                aaSorting: [],
                                pageLength: 10,
                                displayStart: 0,
                                drawCallback: initSigo.showPagination,
                            });
                        }

                        $('#modal-ifi').modal('show');
                    });
                } else {
                    $('#modal-ifi').modal('show');
                }
            },
            Buscar: function (e) {
                window.dtb_ifi?.draw();
            },
            Agregar: async function (obj) {
                const row = $(obj).closest('tr');
                const item = window.dtb_ifi?.row(row).data();
                if (!item) return;

                const existe = app.Informe.ILEGAL.find(x => x.codILegal == item.COD_ILEGAL);

                if (existe) {
                    utilSigo.toastWarning('Alerta', 'El informe ya está en la lista');
                    return;
                }

                const ILEGAL = await _informe.ObtenerInformeLegal(item.COD_ILEGAL);

                if (!ILEGAL) {
                    utilSigo.toastWarning('Atención', 'No se encontró información del documento seleccionado');
                    return;
                }

                //Las infracciones se van a obtener de la tabla de recomendaciones
                /*let infracciones = app.Informe.INFRACCIONES;

                for (const infraccion of ILEGAL.INFRACCIONES) {
                    if (!infracciones.find(x => x.inciso == infraccion.inciso)) {
                        const model = {
                            ...infraccion,
                            codInformeDigital: null,
                            codILegal: item.COD_ILEGAL,
                            parrafos: null,
                            estado: 1,
                            accion: 0,
                            flgSeleccionado: true
                        }

                        infracciones.push(model);
                    }
                }

                //Ordenamos los incisos
                infracciones = infracciones.sort((a, b) => {
                    return (isNaN(a.inciso) || isNaN(b.inciso)) ? -1 : (+a.inciso > +b.inciso ? 1 : -1);
                });*/

                const THAB = {
                    COD_THABILITANTE: ILEGAL.COD_THABILITANTE,
                    NUM_CONTRATO: ILEGAL.NUM_THABILITANTE,
                    COD_TITULAR: ILEGAL.COD_TITULAR,
                    TITULAR_DOCUMENTO: ILEGAL.TITULAR_DOCUMENTO,
                    TITULAR: ILEGAL.TITULAR,
                    //TITULAR_ESTADO_RUC: ILEGAL.TITULAR_ESTADO_RUC,
                    //TITULAR_CONDICION_RUC: ILEGAL.TITULAR_CONDICION_RUC,
                    TITULAR_RUC: ILEGAL.TITULAR_RUC,
                    R_LEGAL: ILEGAL.R_LEGAL,
                    R_LEGAL_DOCUMENTO: ILEGAL.R_LEGAL_DOCUMENTO,
                    R_LEGAL_RUC: ILEGAL.R_LEGAL_RUC,
                    DIRECCION_LEGAL: ILEGAL.DIRECCION_LEGAL,
                    UBIGEO_DEPARTAMENTO: ILEGAL.UBIGEO_DEPARTAMENTO,
                    UBIGEO_PROVINCIA: ILEGAL.UBIGEO_PROVINCIA,
                    UBIGEO_DISTRITO: ILEGAL.UBIGEO_DISTRITO,
                    //FLG_SANCION: ILEGAL.FLG_SANCION > 0 ? 1 : 0,
                    //SANCION_UIT: ILEGAL.SANCION_UIT,
                    //SANCION_COD_CALCULO: ILEGAL.SANCION_COD_CALCULO,
                };

                app.Informe = {
                    ...app.Informe,
                    ...THAB
                }

                const INFORME = {
                    codILegal: item.COD_ILEGAL,
                    nroILegal: item.ILEGAL_NUMERO,
                    estado: 1
                };

                app.Informe.ILEGAL.push(INFORME);
                //app.Informe.INFRACCIONES = infracciones;

                //Antecedentes                
                const ANTECEDENTES = await _informe.ExtraerAntecedentes(item.COD_ILEGAL);

                ANTECEDENTES.forEach(a => {
                    a.codILegal = item.COD_ILEGAL;
                    const n = a.numero?.match(regExpOSINFOR) || [];
                    a.numero = n[0];
                    a.estado = 1;
                });

                app.Informe.ANTECEDENTES = ANTECEDENTES;

                //Archivos relacionados
                //console.log(item, "Validar la extracción de archivos...");
                let files = await app.ObtenerArchivos(item.COD_ILEGAL);

                //console.log("LOAD FILES SIADO...", files);
                files = files.filter(function (file) {
                    return !app.Informe.DOCUMENTOS.find(x => x.codResolucion == file.codResolucion)
                });

                app.Informe.DOCUMENTOS = [...app.Informe.DOCUMENTOS, ...files];

                $('#modal-ifi').modal('hide');
            }
        }
    });

    modal_referencias = new Vue({
        el: '#modal-referencias',
        data: {
            categoria: 'DOC_GENERADOS',
            subtipo: '01',
            filtro: 'CNRODOCUMENTO',
            texto: '',
            subtipos: [
                { SUBTIPO: '01', DESCRIPCION: 'Allanamiento de responsabilidad' },
                { SUBTIPO: '02', DESCRIPCION: 'Subsanación voluntaria' },
                { SUBTIPO: null, DESCRIPCION: 'Otro' },
            ]
        },
        methods: {
            Abrir: function () {
                const self = this;
                const url = urlLocalSigo + "General/Controles/GetListaDocumentosSITDPaging";

                if (!window.dtbReferencias) {
                    window.dtbReferencias = $('#dtReferencias').DataTable({
                        processing: true,
                        serverSide: true,
                        searching: false,
                        ordering: false,
                        paging: true,
                        deferLoading: 0,
                        ajax: {
                            url,
                            data: function (d) {
                                d.customSearchEnabled = true;
                                d.customSearchForm = self.categoria;
                                d.customSearchType = self.filtro;
                                d.customSearchValue = self.texto;
                                for (var i = 0; i < d.order.length; i++) {
                                    d.order[i]["column_name"] = d.columns[d.order[i]["column"]]["data"];
                                }
                                d.columns = null;
                            },
                            error: function (jqXHR) {
                                utilSigo.unblockUIGeneral();
                                utilSigo.toastError("Error", initSigo.MessageError);
                            }
                        },
                        columns: [
                            { data: 'fFecDocumento', title: 'Fecha Doc' },
                            { data: 'cCodificacion', title: 'Codigo' },
                            { data: 'cNroDocumento', title: 'Nro Documento' },
                            { data: 'cDescTipoDoc', title: 'Tipo Doc' },
                        ],
                        columnDefs: [
                            {
                                targets: 4,
                                orderable: false,
                                data: null,
                                width: '30px',
                                render: (data, type, row, meta) => {
                                    return `<i class="fa fa-lg fa-check text-success px-2" onclick="modal_referencias.Seleccionar(this)"></i>`;
                                }
                            }
                        ],
                        autoWidth: false,
                        bInfo: true,
                        lengthMenu: [[10, 20, 50, 100], [10, 20, 50, 100]],
                        aaSorting: false,
                        pageLength: 10,
                        displayStart: 0,
                        oLanguage: initSigo.oLanguage,
                        drawCallback: initSigo.showPagination,
                    });

                    $('#modal-referencias').on('shown.bs.modal', function () {
                        $(this).find('input[type="text"]').focus();
                    });
                }

                $('#modal-referencias').modal('show');
            },
            Buscar: function () {
                window.dtbReferencias?.draw();
            },
            Seleccionar: function (obj) {
                const row = $(obj).closest('tr');
                const data = window.dtbReferencias?.row(row).data();
                if (!data) return;

                //Buscamos que no se repita
                const existe = app.Informe.REFERENCIAS.find(x => x.CODIGO == data.cCodificacion?.trim() && x.TIPO_DOCUMENTO == data.cDescTipoDoc?.trim());
                if (existe) {
                    utilSigo.toastWarning('Alerta', 'El documento ya existe en la lista');
                    return;
                }

                const oneExp = app.Informe.REFERENCIAS.find(x => x.TIPO_DOCUMENTO?.indexOf('EXPEDIENTE') != -1);
                if (oneExp && data.cDescTipoDoc?.trim().indexOf('EXPEDIENTE') != -1) {
                    utilSigo.toastWarning('Alerta', 'Ya existe un EXPEDIENTE en la lista, no se pueden agregar más');
                    return;
                }

                modal_referencias_tipo.Abrir(data);
            },
            Agregar: function (data, subSel) {
                const self = this;

                var model = {
                    COD_RESODIREC: app.Informe.COD_RESOLUCION,
                    CODIGO: data.cCodificacion?.trim() || '',
                    NUMERO: data.cNroDocumento?.trim() || '',
                    TIPO_DOCUMENTO: data.cDescTipoDoc?.trim(),
                    PDF_DOCUMENTO: data.PDF_TRAMITE_SITD?.trim(),
                    SUBTIPO: subSel.SUBTIPO,
                    SUBTIPO_DETALLE: subSel.DESCRIPCION,
                    RegEstado: 1
                };

                app.Informe.REFERENCIAS.push(model);

                if (model.SUBTIPO == '01') {
                    _renderTerminoPau.dtRenderListSTD1.rows.add([model]).draw();
                } else if (model.SUBTIPO == '02') {
                    _renderTerminoPau.dtRenderListSTD02.rows.add([model]).draw();
                } else {
                    //_renderTerminoPau.dtOtrosDocumentos.push(model);
                }

                utilSigo.toastSuccess('Agregado', 'Se agregó un documento a la lista');
            }
        }
    });

    modal_referencias_tipo = new Vue({
        el: '#modal-referencias-tipo',
        data: {
            subtipo: '01',
            subtipos: [
                { SUBTIPO: '01', DESCRIPCION: 'Allanamiento de responsabilidad' },
                { SUBTIPO: '02', DESCRIPCION: 'Subsanación voluntaria' },
                //{ SUBTIPO: null, DESCRIPCION: 'Otro' }, // Considerar la listSTD03, realizar cambios en back
            ]
        },
        methods: {
            Abrir: function (obj) {
                window.DOC_SEL_ITEM = obj;
                $('#modal-referencias-tipo').modal('show');
            },
            Aceptar: function () {
                const self = this;
                const obj = window.DOC_SEL_ITEM;
                const subtipo = self.subtipos.find(x => x.SUBTIPO == self.subtipo);
                modal_referencias.Agregar(obj, subtipo);
                $('#modal-referencias-tipo').modal('hide');
            }
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
                this.form.funcion = null;
                this.form.codPersona = null;
                this.form.apellidosNombres = null;
                $('#modal-integrante').modal('show');
            },
            Agregar: function () {
                const user = { ...this.form };
                app.Informe.PARTICIPANTES.push(user);
                app.Informe.FLG_ACTUALIZAR = true;

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
                delete this.callback;
                $('#modal-notificar').modal('hide');
            },
            ObtenerCorreos: function (codPersonas) {
                return new Promise((resolve, reject) => {
                    let params = {
                        type: 'post',
                        url: `${urlLocalSigo}General/ManPersonas/ObtenerCorreos`,
                        datos: JSON.stringify(codPersonas)
                    };

                    utilSigo.fnAjax(params, function (res) {
                        const correos = res
                            .filter(item => (item?.CORREO || '').indexOf('@') !== -1)
                            .reduce((acc, item) => {
                                if (!acc.some(obj => obj.email === item.CORREO)) {
                                    return [
                                        ...acc,
                                        {
                                            codPersona: item.COD_PERSONA,
                                            persona: `${item.NOMBRES} ${item.APE_PATERNO} ${item.APE_MATERNO}`,
                                            email: item.CORREO
                                        }
                                    ];
                                }

                                return acc;
                            }, []);

                        resolve(correos);
                    });
                });
            },
            Agregar: function () {
                const self = this;

                app.AbrirModalPersona().then(() => {
                    _bPerGen.fnAsignarDatos = function (obj) {
                        if (obj) {
                            const data = _bPerGen.dtBuscarPerona.row($(obj).parents('tr')).data();

                            const existe = self.form.Destinatarios.find(item => item.codPersona == data.COD_PERSONA);
                            if (existe) {
                                utilSigo.toastWarning('', `La persona ${data.PERSONA} ya existe en la lista`);
                                return;
                            }

                            self.ObtenerCorreos([data.COD_PERSONA]).then(res => {
                                if (res.length) {
                                    self.form.Destinatarios.push(res[0]);
                                    utilSigo.toastSuccess('', `Se agregó a ${data.PERSONA} a la lista`);
                                }
                                else utilSigo.toastWarning('', `No existe un correo asociado a ${data.PERSONA}`);
                            });
                        }
                    }
                });
            },
            Agregar_CC: function () {
                const self = this;

                app.AbrirModalPersona().then(() => {
                    _bPerGen.fnAsignarDatos = function (obj) {
                        if (obj) {
                            const data = _bPerGen.dtBuscarPerona.row($(obj).parents('tr')).data();

                            self.ObtenerCorreos([data.COD_PERSONA]).then(res => {
                                if (res.length) {
                                    self.form.CC += `${res[0].email};`;
                                    utilSigo.toastSuccess('', `Se agregó a ${data.PERSONA} a la lista`);
                                }
                                else utilSigo.toastWarning('', `No existe un correo asociado a ${data.PERSONA}`);
                            });
                        }
                    }
                });
            },
            Notificar: function () {
                const self = this;
                const user = ManRD_AddEdit.userApp;

                const seleccionados = JSON.parse(JSON.stringify(self.form.Seleccionados));
                const notificacion = {
                    TITULO: 'Resolución Directoral',
                    DESTINATARIOS: seleccionados.map(item => item.email).join(','),
                    CC_DESTINATARIOS: self.form.CC,
                    COD_INFORME: app.Informe.NUM_INFORME_SITD,
                    MENSAJE_ENVIO_ALERTA: `${_informe.render(self.form.Mensaje)}<br><br>Atentamente,<br>${user.PERSONA}`,
                    URL_LOCAL: window.location.href
                };

                let params = {
                    type: 'post',
                    url: `${urlLocalSigo}Fiscalizacion/ManPAURD/Notificar`,
                    datos: JSON.stringify({ notificacion })
                };

                utilSigo.fnAjax(params, function (res) {
                    if (res) {
                        //Para ejecutar cualquier acción despues de enviar un correo
                        if (typeof self.callback === 'function') self.callback(seleccionados);
                        utilSigo.toastSuccess('Enviado', res);
                    } else {
                        utilSigo.toastWarning('Atención', 'No se ha encontrado ningún correo asociado al usuario');
                    }

                    self.Cerrar();
                });
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
                    url: urlLocalSigo + 'Fiscalizacion/ManPAURD/CargarDocumento',
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