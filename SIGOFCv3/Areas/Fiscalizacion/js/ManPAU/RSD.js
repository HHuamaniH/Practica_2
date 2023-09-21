"use strict";

let _informe = {};
let app,
    modal_notificar,
    modal_doc,
    //modal_analisis,
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
        { COD_MODALIDAD: '01', COD_MATERIA: '02', MODALIDAD: 'Concesiones', CONTRATO: 'contrato de concesión' },
        { COD_MODALIDAD: '02', COD_MATERIA: '02', MODALIDAD: 'Predios privados', CONTRATO: 'permiso forestal' },
        { COD_MODALIDAD: '03', COD_MATERIA: '02', MODALIDAD: 'Comunidades nativas', CONTRATO: 'permiso forestal' },
        { COD_MODALIDAD: '04', COD_MATERIA: '01', MODALIDAD: 'Fauna', CONTRATO: '' },
    ],
    Infracciones: [],
    Causales_Caducidad: []
    /*Infracciones: [
        {
            COD_MODALIDAD: '01',
            DETALLE: [
                {
                    titulo: 'Con relación a la obligación de establecer y mantener los linderos, hitos u otras señales',
                    conducta: 'No se estableció letreros, señalización de vértices, hitos que permitan identificar el área del título habilitante.',
                    tipo_infractor: 'No establecer o no mantener los linderos, hitos u otras señales que permitan identificar el área del título habilitante.',
                    numeral: 'Numeral 1 del Cuadro de Infracciones y Sanciones en Materia Forestal del Anexo 1 del RISMFFS',
                    sancion: 'Desde una amonestación hasta una sanción pecuniaria (en caso de reincidencia)',
                    subsanar: 'Sí/Establecer los linderos, hitos u otras señales.',
                    select: false, codPlantilla: 'concesiones-1'
                },
                {
                    titulo: 'Con relación a la presentación del informe de ejecución forestal',
                    conducta: 'No presentar el Informe de Ejecución Anual del plan de manejo - PC 01, 02 y 03, correspondiente al periodo 2021-2022.',
                    tipo_infractor: 'No entregar o presentar información o documentación legalmente exigible en el plazo previsto, o cuando la autoridad competente lo requiera.',
                    numeral: 'Numeral 2 del Cuadro de Infracciones y Sanciones en Materia Forestal del Anexo 1 del RISMFFS',
                    sancion: 'Desde una amonestación hasta una sanción pecuniaria (en caso de reincidencia).',
                    subsanar: 'Sí /Presentar el Informe de Ejecución Anual del PMFI xx, correspondiente al periodo xx',
                    select: false, codPlantilla: 'concesiones-2'
                },
                {
                    titulo: 'Con relación al aprovechamiento del recurso forestal no autorizado (extracción de individuos de procedencia identificada - volumen no autorizado)',
                    conducta: 'Talar, extraer y/o aprovechar recursos forestales no autorizados en el área del título habilitante, en un volumen de xxx  m3, correspondiente a 2 árboles semilleros/no censados de las especies xxx',
                    tipo_infractor: 'Talar, extraer y/o aprovechar recursos forestales no autorizados en el área del título habilitante, cuando sea imputable al administrado en su condición de titular del título habilitante',
                    numeral: 'Numeral 10 del Cuadro de Infracciones y Sanciones en Materia Forestal del Anexo 1 del RISMFFS',
                    sancion: 'Sanción monetaria mayor a 3 hasta 10 UIT',
                    subsanar: 'Sí/ Reponer con otro(s) individuo(s) declarado(s) dentro de la parcela de corta del plan de manejo supervisado. Asimismo, el infractor debe Acreditar la reposición del individuo. Justificar que fue producto de un error propio del manejo forestal. Registrar la información en el libro de operaciones de títulos habilitantes y/ o informes de ejecución.',
                    select: false, codPlantilla: 'concesiones-3'
                },
                {
                    titulo: 'Con relación a la obligación de tener y mantener actualizado el libro de operaciones',
                    conducta: 'No registrar la información en el Libro de Operaciones, de acuerdo a las disposiciones establecidas.',
                    tipo_infractor: 'No tener libro de operaciones o no registrar la información en dicho libro, de acuerdo a las disposiciones establecidas.',
                    numeral: 'Numeral 11 del Cuadro de Infracciones y Sanciones en Materia Forestal del Anexo 1 del RISMFFS',
                    sancion: 'Sanción monetaria mayor a 3 hasta 10 UIT',
                    subsanar: 'Si, sólo en caso de no haber registrado la información, pero se cuente con la documentación que acredite la procedencia legal del recurso / Actualizar el libro de operaciones.',
                    select: false, codPlantilla: 'concesiones-4'
                },
                {
                    titulo: 'Con relación al aprovechamiento del recurso forestal no autorizado (extracción de individuos de procedencia no identificada - volumen injustificado).',
                    conducta: 'Talar, extraer y/o aprovechar recursos forestales sin la correspondiente autorización por un volumen de xx m3, correspondiente a las especies xx',
                    tipo_infractor: 'Talar, extraer y/o aprovechar recursos forestales, sin autorización, en su condición o no de titular del título habilitante, a excepción de los aprovechados por subsistencia.',
                    numeral: 'Numeral 21 del Cuadro de Infracciones y Sanciones en Materia Forestal del Anexo 1 del RISMFFS',
                    sancion: 'Sanción monetaria mayor a 10 UIT hasta 5000 UIT.',
                    subsanar: 'No aplica',
                    select: false, codPlantilla: 'concesiones-5'
                },
                {
                    titulo: 'Con relación al incumplimiento de movilizar productos forestales no autorizados con documentos aprobados por la autoridad competente',
                    conducta: 'Utilizar indebidamente documentación otorgada por la Autoridad Regional Forestal para amparar el transporte de recursos forestales provenientes de una extracción no autorizada de un volumen de xx m3 , correspondiente a las especies xx; pues habría utilizado su contrato de concesión/permiso forestal, su Plan de Manejo, así como el Balance de Extracción para dar apariencia de legalidad al volumen de madera que provendría de individuos sobre los cuales no tenía autorización para extraer.',
                    tipo_infractor: 'Utilizar indebidamente o facilitar la guía de transporte forestal, así como la documentación otorgada o aprobada por la autoridad competente, para amparar la extracción, transporte, transformación, almacenamiento o comercialización de los especímenes, productos o sub productos forestales obtenidos ilegalmente.',
                    numeral: 'Numeral 26 del Cuadro de Infracciones y Sanciones en Materia Forestal del Anexo 1 del RISMFFS',
                    sancion: 'Sanción monetaria mayor a 10 UIT hasta 5000 UIT.',
                    subsanar: 'No aplica',
                    select: false, codPlantilla: 'concesiones-6'
                },
                {
                    titulo: 'Con relación al incumplimiento de contar con regente forestal',
                    conducta: 'El/la titular no cuenta con regente forestal para la implementación del Plan de Manejo N° xx, periodo xx',
                    tipo_infractor: 'No contar con un regente para la implementación del plan de manejo, en caso corresponda',
                    numeral: 'Numeral 29 del Cuadro de Infracciones y Sanciones en Materia Forestal del Anexo 1 del RISMFFS',
                    sancion: 'Sanción monetaria mayor a 10 UIT hasta 5000 UIT.',
                    subsanar: 'No aplica',
                    select: false, codPlantilla: 'concesiones-7'
                },
            ]
        },
        {
            COD_MODALIDAD: '02',
            DETALLE: [
                {
                    titulo: 'Con relación a la obligación de establecer y mantener los linderos, hitos u otras señales',
                    conducta: 'No se estableció letreros, señalización de vértices, hitos que permitan identificar el área del título habilitante.',
                    tipo_infractor: 'No establecer o no mantener los linderos, hitos u otras señales que permitan identificar el área del título habilitante.',
                    numeral: 'Numeral 1 del Cuadro de Infracciones y Sanciones en Materia Forestal del Anexo 1 del RISMFFS',
                    sancion: 'Desde una amonestación hasta una sanción pecuniaria (en caso de reincidencia)',
                    subsanar: 'Sí/Establecer los linderos, hitos u otras señales.',
                    select: false, codPlantilla: 'concesiones-1'
                },
                {
                    titulo: 'Con relación a la presentación del informe de ejecución forestal',
                    conducta: 'No presentar el Informe de Ejecución Anual del plan de manejo - PC 01, 02 y 03, correspondiente al periodo 2021-2022.',
                    tipo_infractor: 'No entregar o presentar información o documentación legalmente exigible en el plazo previsto, o cuando la autoridad competente lo requiera.',
                    numeral: 'Numeral 2 del Cuadro de Infracciones y Sanciones en Materia Forestal del Anexo 1 del RISMFFS',
                    sancion: 'Desde una amonestación hasta una sanción pecuniaria (en caso de reincidencia).',
                    subsanar: 'Sí /Presentar el Informe de Ejecución Anual del PMFI xx, correspondiente al periodo xx',
                    select: false, codPlantilla: 'concesiones-2'
                },
                {
                    titulo: 'Con relación al aprovechamiento del recurso forestal no autorizado (extracción de individuos de procedencia identificada - volumen no autorizado)',
                    conducta: 'Talar, extraer y/o aprovechar recursos forestales no autorizados en el área del título habilitante, en un volumen de xxx  m3, correspondiente a 2 árboles semilleros/no censados de las especies xxx',
                    tipo_infractor: 'Talar, extraer y/o aprovechar recursos forestales no autorizados en el área del título habilitante, cuando sea imputable al administrado en su condición de titular del título habilitante',
                    numeral: 'Numeral 10 del Cuadro de Infracciones y Sanciones en Materia Forestal del Anexo 1 del RISMFFS',
                    sancion: 'Sanción monetaria mayor a 3 hasta 10 UIT',
                    subsanar: 'Sí/ Reponer con otro(s) individuo(s) declarado(s) dentro de la parcela de corta del plan de manejo supervisado. Asimismo, el infractor debe Acreditar la reposición del individuo. Justificar que fue producto de un error propio del manejo forestal. Registrar la información en el libro de operaciones de títulos habilitantes y/ o informes de ejecución.',
                    select: false, codPlantilla: 'concesiones-3'
                },
                {
                    titulo: 'Con relación a la obligación de tener y mantener actualizado el libro de operaciones',
                    conducta: 'No registrar la información en el Libro de Operaciones, de acuerdo a las disposiciones establecidas.',
                    tipo_infractor: 'No tener libro de operaciones o no registrar la información en dicho libro, de acuerdo a las disposiciones establecidas.',
                    numeral: 'Numeral 11 del Cuadro de Infracciones y Sanciones en Materia Forestal del Anexo 1 del RISMFFS',
                    sancion: 'Sanción monetaria mayor a 3 hasta 10 UIT',
                    subsanar: 'Si, sólo en caso de no haber registrado la información, pero se cuente con la documentación que acredite la procedencia legal del recurso / Actualizar el libro de operaciones.',
                    select: false, codPlantilla: 'concesiones-4'
                },
                {
                    titulo: 'Con relación al aprovechamiento del recurso forestal no autorizado (extracción de individuos de procedencia no identificada - volumen injustificado).',
                    conducta: 'Talar, extraer y/o aprovechar recursos forestales sin la correspondiente autorización por un volumen de xx m3, correspondiente a las especies xx',
                    tipo_infractor: 'Talar, extraer y/o aprovechar recursos forestales, sin autorización, en su condición o no de titular del título habilitante, a excepción de los aprovechados por subsistencia.',
                    numeral: 'Numeral 21 del Cuadro de Infracciones y Sanciones en Materia Forestal del Anexo 1 del RISMFFS',
                    sancion: 'Sanción monetaria mayor a 10 UIT hasta 5000 UIT.',
                    subsanar: 'No aplica',
                    select: false, codPlantilla: 'concesiones-5'
                },
                {
                    titulo: 'Con relación al incumplimiento de movilizar productos forestales no autorizados con documentos aprobados por la autoridad competente',
                    conducta: 'Utilizar indebidamente documentación otorgada por la Autoridad Regional Forestal para amparar el transporte de recursos forestales provenientes de una extracción no autorizada de un volumen de xx m3 , correspondiente a las especies xx; pues habría utilizado su contrato de concesión/permiso forestal, su Plan de Manejo, así como el Balance de Extracción para dar apariencia de legalidad al volumen de madera que provendría de individuos sobre los cuales no tenía autorización para extraer.',
                    tipo_infractor: 'Utilizar indebidamente o facilitar la guía de transporte forestal, así como la documentación otorgada o aprobada por la autoridad competente, para amparar la extracción, transporte, transformación, almacenamiento o comercialización de los especímenes, productos o sub productos forestales obtenidos ilegalmente.',
                    numeral: 'Numeral 26 del Cuadro de Infracciones y Sanciones en Materia Forestal del Anexo 1 del RISMFFS',
                    sancion: 'Sanción monetaria mayor a 10 UIT hasta 5000 UIT.',
                    subsanar: 'No aplica',
                    select: false, codPlantilla: 'concesiones-6'
                },
                {
                    titulo: 'Con relación al incumplimiento de contar con regente forestal',
                    conducta: 'El/la titular no cuenta con regente forestal para la implementación del Plan de Manejo N° xx, periodo xx',
                    tipo_infractor: 'No contar con un regente para la implementación del plan de manejo, en caso corresponda',
                    numeral: 'Numeral 29 del Cuadro de Infracciones y Sanciones en Materia Forestal del Anexo 1 del RISMFFS',
                    sancion: 'Sanción monetaria mayor a 10 UIT hasta 5000 UIT.',
                    subsanar: 'No aplica',
                    select: false, codPlantilla: 'concesiones-7'
                },
            ]
        },
        {
            COD_MODALIDAD: '03',
            DETALLE: [
                {
                    titulo: 'Con relación a la presentación del informe de ejecución forestal',
                    conducta: 'No presentar el Informe de Ejecución Anual del plan de manejo - PC 01, 02 y 03, correspondiente al periodo 2021-2022.',
                    tipo_infractor: 'No entregar o presentar información o documentación legalmente exigible en el plazo previsto, o cuando la autoridad competente lo requiera',
                    numeral: 'Numeral 2 del Cuadro de Infracciones y Sanciones en Materia Forestal del Anexo 1 del RISMFFS',
                    sancion: 'Desde una amonestación hasta una sanción pecuniaria (en caso de reincidencia).',
                    subsanar: 'Sí /Presentar el Informe de Ejecución Anual del PMFI xx, correspondiente al periodo xx',
                    select: false, codPlantilla: 'ccnn-1'
                },
                {
                    titulo: 'Con relación al aprovechamiento del recurso forestal no autorizado (extracción de individuos de procedencia identificada - volumen no autorizado)',
                    conducta: 'Talar, extraer y/o aprovechar recursos forestales no autorizados en el área del título habilitante, en un volumen de xxx  m3, correspondiente a 2 árboles semilleros/no censados de las especies xxx',
                    tipo_infractor: 'Talar, extraer y/o aprovechar recursos forestales no autorizados en el área del título habilitante, cuando sea imputable al administrado en su condición de titular del título habilitante',
                    numeral: 'Numeral 10 del Cuadro de Infracciones y Sanciones en Materia Forestal del Anexo 1 del RISMFFS',
                    sancion: 'Sanción monetaria mayor a 3 hasta 10 UIT',
                    subsanar: 'Sí/ Reponer con otro(s) individuo(s) declarado(s) dentro de la parcela de corta del plan de manejo supervisado. Asimismo, el infractor debe Acreditar la reposición del individuo. Justificar que fue producto de un error propio del manejo forestal. Registrar la información en el libro de operaciones de títulos habilitantes y/o informes de ejecución.',
                    select: false, codPlantilla: 'ccnn-2'
                },
                {
                    titulo: 'Con relación a la obligación de tener y mantener actualizado el libro de operaciones',
                    conducta: 'No registrar la información en el Libro de Operaciones, de acuerdo a las disposiciones establecidas.',
                    tipo_infractor: 'No tener libro de operaciones o no registrar la información en dicho libro, de acuerdo a las disposiciones establecidas.',
                    numeral: 'Numeral 11 del Cuadro de Infracciones y Sanciones en Materia Forestal del Anexo 1 del RISMFFS',
                    sancion: 'Sanción monetaria mayor a 3 hasta 10 UIT',
                    subsanar: 'Si, sólo en caso de no haber registrado la información, pero se cuente con la documentación que acredite la procedencia legal del recurso / Actualizar el libro de operaciones.',
                    select: false, codPlantilla: 'ccnn-3'
                },
                {
                    titulo: 'Con relación al aprovechamiento del recurso forestal no autorizado (extracción de individuos de procedencia no identificada - volumen injustificado)',
                    conducta: 'Talar, extraer y/o aprovechar recursos forestales sin la correspondiente autorización por un volumen de xx m3, correspondiente a las especies xx',
                    tipo_infractor: 'Talar, extraer y/o aprovechar recursos forestales, sin autorización, en su condición o no de titular del título habilitante, a excepción de los aprovechados por subsistencia.',
                    numeral: 'Numeral 21 del Cuadro de Infracciones y Sanciones en Materia Forestal del Anexo 1 del RISMFFS',
                    sancion: 'Sanción monetaria mayor a 10 UIT hasta 5000 UIT.',
                    subsanar: 'No aplica',
                    select: false, codPlantilla: 'ccnn-4'
                },
                {
                    titulo: 'Con relación al incumplimiento de movilizar productos forestales no autorizados con documentos aprobados por la autoridad competente',
                    conducta: 'Utilizar indebidamente documentación otorgada por la Autoridad Regional Forestal para amparar el transporte de recursos forestales provenientes de una extracción no autorizada de un volumen de xx m3 , correspondiente a las especies xx; pues habría utilizado su contrato de concesión/permiso forestal, su Plan de Manejo, así como el Balance de Extracción para dar apariencia de legalidad al volumen de madera que provendría de individuos sobre los cuales no tenía autorización para extraer.',
                    tipo_infractor: 'Utilizar indebidamente o facilitar la guía de transporte forestal, así como la documentación otorgada o aprobada por la autoridad competente, para amparar la extracción, transporte, transformación, almacenamiento o comercialización de los especímenes, productos o sub productos forestales obtenidos ilegalmente.',
                    numeral: 'Numeral 26 del Cuadro de Infracciones y Sanciones en Materia Forestal del Anexo 1 del RISMFFS',
                    sancion: 'Sanción monetaria mayor a 10 UIT hasta 5000 UIT.',
                    subsanar: 'No aplica',
                    select: false, codPlantilla: 'ccnn-5'
                },
                {
                    titulo: 'Con relación al incumplimiento de contar con regente forestal',
                    conducta: 'El/la titular no cuenta con regente forestal para la implementación del Plan de Manejo N° xx, periodo xx',
                    tipo_infractor: 'No contar con un regente para la implementación del plan de manejo, en caso corresponda',
                    numeral: 'Numeral 29 del Cuadro de Infracciones y Sanciones en Materia Forestal del Anexo 1 del RISMFFS',
                    sancion: 'Sanción monetaria mayor a 10 UIT hasta 5000 UIT.',
                    subsanar: 'No aplica',
                    select: false, codPlantilla: 'ccnn-6'
                },
            ]
        },
        {
            COD_MODALIDAD: '04',
            DETALLE: [
                {
                    titulo: 'Con relación a la presentación del informe de ejecución forestal',
                    conducta: 'No presentar el Informe de Ejecución Anual del plan de manejo - PC xx, xx y xx, correspondiente al periodo 202x-202x.',
                    tipo_infractor: 'No entregar o presentar información o documentación legalmente exigible en el plazo previsto, o cuando la autoridad competente lo requiera',
                    numeral: 'Numeral 2 del Cuadro de Infracciones y Sanciones en Materia de Fauna Silvestre del Anexo 2 del Reglamento de Infracciones y Sanciones',
                    sancion: '',
                    subsanar: '',
                    select: false, codPlantilla: 'fauna-1'
                },
                {
                    titulo: 'Con relación a la obligación de tener y mantener actualizado el libro de operaciones',
                    conducta: 'La administrada no cuenta con información equivalente al libro de operaciones.',
                    tipo_infractor: 'No tener libro de operaciones o no registrar la información en dicho libro, de acuerdo a las disposiciones establecidas',
                    numeral: 'Numeral 12 del Anexo 2 del Cuadro de Infracciones y Sanciones en Materia de Fauna Silvestre del Anexo 2 del Reglamento de Infracciones y Sanciones',
                    sancion: '',
                    subsanar: '',
                    select: false, codPlantilla: 'fauna-2'
                },
                {
                    titulo: 'Con relación al incumplimiento de contar con regente forestal',
                    conducta: 'No contar con regente de fauna silvestre para la implementación del plan de manejo de fauna silvestre.',
                    tipo_infractor: 'No contar con un regente para la implementación del plan de manejo, en caso corresponda',
                    numeral: '',
                    sancion: '',
                    subsanar: '',
                    select: false, codPlantilla: 'fauna-3'
                },
            ]
        }
    ],
    Causales_Caducidad: [
        { titulo: 'La presentación de información falsa en los planes de manejo a la ARFFS, siempre que esté en ejecución o haya sido ejecutado.', select: false },
        { titulo: 'La extracción o movilización de recursos forestales y de fauna silvestre no autorizadas.', select: false },
        { titulo: 'El cambio no autorizado del uso de las tierras.', select: false },
        { titulo: 'Causar severos perjuicios que pongan en grave riesgo al ambiente y la biodiversidad, de acuerdo con la normativa vigente.', select: false },
        { titulo: 'El no pago por derecho de aprovechamiento al cual se encuentra sujeto, dentro de los plazos establecidos en el Reglamento o en el título respectivo, salvo que exista refinanciamiento, fraccionamiento o suspensión de obligaciones aprobados por la ARFFS.', select: false },
        { titulo: 'La realización de actividades distintas a las otorgadas en virtud del título habilitante.', select: false },
        { titulo: 'El incumplimiento de los compromisos de inversión acordados para el otorgamiento del título habilitante, en los casos que corresponda, salvo que se demuestre que fue causado por hechos fortuitos o de fuerza mayor.', select: false },
    ]*/
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

            /*const notificaciones_pendientes = app.Informe.FIRMAS.filter(function (x) { return x.flgAplica && x.estado == 1 });
            if (notificaciones_pendientes.length) {
                app.Informe.FIRMAS.forEach(function (item) {
                    if (item.flgAplica && item.estado == 1)
                        app.Notificar(item);
                });
            }*/

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
    let register = app.Informe.FIRMAS[user.index];
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
    return html.replace(/<strong>Cuadro.<\/strong>/gi, function (m) {
        index++;
        return `<strong>Cuadro ${index}.</strong>`;
    });
}

/*_informe.EnumerarListas = function (html) {
    let num = 1;
    var $html = $('<div />', { html: html });
    $html.find('ol.continue').each((index, el) => {
        $(el).attr('start', num);
        num += $(el).find('>li').length;
    });

    return $html.html();
}*/

/*_informe.EnumerarTitulos = function (html) {
    var $html = $('<div />', { html: html });
    $html.find('.upper-roman').each((index, el) => {
        const html = $(el).html();
        $(el).html(`<ol style="margin-left: -50px; list-style: upper-roman;" start="${index + 1}"><li>${html}</li></ol>`);
    });

    return $html.html();
}*/

_informe.EnumerarParrafos = function (html) {
    var $html = $('<div />', { html: html });
    $html.find('.enumeration').each((index, el) => {
        const html = $(el).html();
        $(el).html(`<ol style="margin-left: -50px;" start="${index + 1}"><li>${html}</li></ol>`);
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
        const a = $html.find('a[href*="#_' + id + '"]:not([name])');
        if (!a.length) {
            element.remove();
        }
    });

    return $html.html();
}

_informe.Exportar = async function () {
    const informe = _informe.Estructura();
    const [procedencias, materias] = JSON.parse(JSON.stringify([app.Procedencias, app.Materias]));

    informe.EXPEDIENTE_ADM = $('#txtNumeroExpediente').val();
    informe.PROCEDENCIA = procedencias.find(function (x) { return x.COD_PROCEDENCIA === informe.COD_PROCEDENCIA })?.PROCEDENCIA;
    informe.MATERIA = materias.find(function (x) { return x.COD_MATERIA === informe.COD_MATERIA })?.MATERIA;
    informe.FECHA = fnDate.text_long(informe.RES_DIRECTORAL_FECHA || new Date());
    //informe.VISTOS = _informe.render(informe.VISTOS);
    //informe.ANTECEDENTES = _informe.render(informe.ANTECEDENTES);
    //informe.COMPETENCIA = _informe.render(informe.COMPETENCIA);
    //informe.ANALISIS = _informe.render(informe.ANALISIS);
    //informe.IMPUTACION = _informe.render(informe.IMPUTACION);
    //informe.PARRAFOS_CLICHE = _informe.render(informe.PARRAFOS_CLICHE);
    //informe.PIE_PAGINA = _informe.render(informe.PIE_PAGINA);
    //informe.COMUNICACION_EXTERNA = _informe.render(informe.COMUNICACION_EXTERNA);
    //informe.RESOLUCION = _informe.render(informe.RESOLUCION);
    //informe.PROCEDENCIA_FOOTER = (informe.PROCEDENCIA || '').split('Forestales').join('<br>Forestales');
    informe.SUBDIRECTOR = informe.FIRMAS.find(function (x) { return x.funcion === 'Subdirector' })?.apellidosNombres;
    //console.log(informe); //return;

    const header = `<p style="text-align:center;"><img height="200" width="200" alt="" src="${urlLocalSigo}content/images/logo/escudo-peruano.jpg"></p>`;
    //let footer = `<table style="width: 100%;"><tr><td style="text-align: right;">#CURRENTPAGE#</td></tr></table>`;

    //Plantilla general
    const template = await _informe.Extraer_Plantilla();

    informe.VISTOS = _informe.tmpl.get(template, '#tmpl-vistos', informe);
    informe.COMPETENCIA = _informe.tmpl.get(template, '#tmpl-competencia', informe);

    //Plantilla de infracciones
    const tmplInfracciones = await _informe.Extraer_Infracciones();
    informe.INFRACCIONES = _informe.EXTRAER_PARRAFOS_INFRACCION(tmplInfracciones);
    informe.ANALISIS = _informe.tmpl.get(template, '#tmpl-analisis', informe);

    if (informe.FLG_CADUCIDAD_EXTRACCION) {
        informe.CAUSALES_CADUCIDAD = data.Causales_Caducidad.filter(item => item.select);
    }

    informe.IMPUTACION = _informe.tmpl.get(template, '#tmpl-imputacion', informe);
    informe.MEDIDAS_CAUTELARES = _informe.tmpl.get(template, '#tmpl-medidas-cautelares', informe);
    informe.COMUNICACION_EXTERNA = _informe.tmpl.get(template, '#tmpl-comunicacion-externa', informe);
    informe.HERRAMIENTAS_SUBSANAR = _informe.tmpl.get(template, '#tmpl-herramientas-subsanar', informe);
    informe.RESOLUCION = _informe.GenerarResolucion(template, informe);
    informe.PIE_PAGINA = _informe.tmpl.get(template, '#tmpl-pie-pagina', { informe, urlLocalSigo });

    let html = '';
    html += _informe.tmpl.get(template, '#tmpl-exportar', informe);
    html += _informe.tmpl.get(template, '#tmpl-pie-pagina-estructura', informe);

    html += _informe.tmpl.get(template, '#tmpl-footnotes', informe);
    html = _informe.RevisarFootnotes(html);

    //Enumeracion
    html = _informe.EnumerarCuadros(html);
    html = _informe.EnumerarParrafos(html);

    $(document).googoose({ html, header });
    //$(document).googoose({ html, header, footeridfirst: 'ff1' });
}

_informe.Registro = function () {
    const parametros = _informe.Estructura();
    const errores = [];

    if (!parametros.COD_PROCEDENCIA) errores.push('Procedencia');
    if (!parametros.COD_MATERIA) errores.push('Materia');

    const validacion = parametros.FIRMAS.some(function (x) { return x.flgAplica && !x.codPersona });
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
        url: `${urlLocalSigo}Fiscalizacion/ManPAU/GuardarRSD`,
        datos: JSON.stringify({ informeDigital: parametros }),
    }
    utilSigo.fnAjax(params, function (res) {
        //console.log(res);
        let data = res.data;
        if (res.success) {
            app.Informe.COD_INFORME_DIGITAL = data.COD_INFORME_DIGITAL;

            data.FIRMAS.forEach(function (x) {
                x.flgAplica = !!x.estado;
                x.accion = 1;
            });
            data.RECURSOS.forEach(function (x) { x.accion = 1; });

            app.Informe.FIRMAS = data.FIRMAS;
            app.Informe.RECURSOS = data.RECURSOS;

            _informe.CambiarEstado(app.Informe.ESTADO || States.INGRESADO);
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
    let objEN = JSON.parse(JSON.stringify(app.Informe));

    objEN.FIRMAS.forEach(function (x, i) {
        if (!x.flgAplica) x.estado = 0;
        else x.estado = x.estado || 1;
        x.item = i + 1;
    });

    objEN.RECURSOS.forEach(function (x, i) {
        if (x.estado === null) x.estado = 1;
        x.item = i + 1;
    });

    objEN.INFRACCIONES = JSON.parse(JSON.stringify(app.Infracciones))
        .filter(item => item.select);

    objEN.CAUSALES_CADUCIDAD = JSON.parse(JSON.stringify(data.Causales_Caducidad))
        .filter(item => item.select);

    let parametros = {
        ...objEN,
        //FIRMAS: objEN.FIRMAS,
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
    let flgSignAll = app.Informe.FIRMAS.filter(function (x) { return x.flgAplica && x.estado < 3 }).length === 0;
    if (!flgSignAll) {
        utilSigo.toastWarning('Firmas incompletas', 'Se deben completar todas las firmas antes de transferir el documento final');
        return;
    }

    utilSigo.dialogConfirm('Transferir', '¿Desea transferir al SITD el documento firmado?', function (r) {
        if (r) {
            utilSigo.fnAjax({
                type: 'post',
                url: `${urlLocalSigo}Fiscalizacion/ManPAU/TransferirDocSITD`,
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
                url: `${urlLocalSigo}Fiscalizacion/ManPAU/AnularFirmaPorInforme`,
                datos: JSON.stringify({
                    codInforme: app.Informe.COD_INFORME_DIGITAL,
                    codificacion: _informe.fileName()
                })
            }, function (res) {
                if (res.success) {
                    _informe.CambiarEstado(States.COMPLETADO);

                    //Actualizar tabla de supervisores FLAG_FIRMA
                    app.Informe.FIRMAS.forEach(function (item) {
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

_informe.DATA_INFORMES = {};

/*_informe.Mostrar_Analisis = function () {
    utilSigo.blockUIGeneral();

    //Regularizar para varios informes
    const asCodInforme = app.Inf_Supervision[0].COD_INFORME;
    let xhr_informes = $.getJSON(urlLocalSigo + 'Supervision/ManInforme/_DataResumenInforme', { asCodInforme: asCodInforme });
    let xhr_templates = $.get(urlLocalSigo + 'Fiscalizacion/ManPAU/TemplateRSDObligaciones');

    $.when(xhr_informes, xhr_templates).then(function (res_inf, res_tmpl) {
        _informe.DATA_INFORMES = res_inf[0]; //volumenes, especies	

        //Template
        let html = res_tmpl[0];

        if (!$('#partial-templates').length) $('<div>', { id: 'partial-templates' }).appendTo('body');
        $('#partial-templates').html(html);

        utilSigo.unblockUIGeneral();
        $('#modal-analisis').modal('show');
    });
}
*/

_informe.Extraer_Infracciones = function () {
    /*return new Promise((resolve, reject) => {
        const params = {
            type: 'get',
            url: `${urlLocalSigo}Fiscalizacion/ManPAU/TemplateRSDObligaciones`,
            dataType: 'html'
        };

        utilSigo.fnAjax(params, function (html) {
            html ? resolve(html) : reject(null);
        });
    });*/

    return new Promise((resolve, reject) => {
        utilSigo.blockUIGeneral();

        //Regularizar para varios informes
        const asCodInforme = app.Inf_Supervision[0].COD_INFORME;
        let xhr_informes = $.getJSON(urlLocalSigo + 'Supervision/ManInforme/_DataResumenInforme', { asCodInforme: asCodInforme });
        let xhr_templates = $.get(urlLocalSigo + 'Fiscalizacion/ManPAU/TemplateRSDObligaciones');

        $.when(xhr_informes, xhr_templates).then(function (res_inf, res_tmpl) {
            _informe.DATA_INFORMES = res_inf[0]; //volumenes, especies	

            //Template
            let html = res_tmpl[0];

            //if (!$('#partial-templates').length) $('<div>', { id: 'partial-templates' }).appendTo('body');
            //$('#partial-templates').html(html);

            utilSigo.unblockUIGeneral();
            resolve(html);
        }).fail(() => reject(null));
    })
}

_informe.EXTRAER_INFRACCIONES_POR_MODALIDAD = function () {
    app.Infracciones = data.Infracciones.filter(x => x.codModalidad == app.Informe.COD_MODALIDAD);
}

_informe.EXTRAER_PARRAFOS_INFRACCION = function (template) {
    let informe = JSON.parse(JSON.stringify(app.Informe));
    informe.TABLAS_INFORME = _informe.DATA_INFORMES;

    const infracciones = JSON.parse(JSON.stringify(data.Infracciones))
        .filter(item => item.codModalidad == informe.COD_MODALIDAD && item.select)
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
            modal_sitd.form.cCodTipoDoc = datos.cCodTipoDoc || "2106"; //(res.tipoDocumento[0] || {}).Value;
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
            url: `${urlLocalSigo}Fiscalizacion/ManPAU/PlantillaInforme`,
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
    obj.cod_Informe = app.Informe.COD_RES_SUB;
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
        url: `${urlLocalSigo}Fiscalizacion/ManPAU/${obj.iCodTramite ? 'TramiteModificar' : 'TramiteGuardar'}`,
        datos: JSON.stringify({ tramite: obj }),
    };

    utilSigo.fnAjax(params, function (res) {
        if (res.success) {
            res.data = res.data || app.Tramite || obj;

            if (res.data) {
                let data = _informe.Estructura();
                data.TRAMITE_ID = res.data.iCodTramite || data.TRAMITE_ID;
                data.NUM_INFORME_SITD = res.data.cCodificacion || data.NUM_INFORME_SITD;

                //Actualizamos las variables
                app.Informe.TRAMITE_ID = data.TRAMITE_ID;
                app.Informe.NUM_INFORME_SITD = data.NUM_INFORME_SITD;

                app.Informe.PIE_PAGINA = app.Informe.PIE_PAGINA.replace(/PASSWORD/g, res.data.password);
                $('#txtNumeroResolucion').val(app.Informe.NUM_INFORME_SITD);

                /*if (tb) {
                    //app.Informe.COD_DESTINATARIO = tb.trabajadorId;
                    app.Informe.DESTINATARIO = `${tb.nombres} ${tb.apellidos}`;
                }*/

                app.Tramite = res.data;

                _informe.Guardar(data);
            }

            $('#modal-sitd').modal('hide');
        } else {
            //if (res.iCodTramite) {
            //	modal_sitd.form.iCodTramite = res.iCodTramite;
            //	app.Informe.TRAMITE_ID = res.iCodTramite;
            //}

            utilSigo.toastError('Atención', res.msj);
        }

    });
};

_informe.Agregar_Integrante = function () {
    modal_integrante.Abrir();
}

_informe.ObtenerRutaInformeSup = function (item) {
    return `${urlLocalSigo}Supervision/ManInforme/AddEdit?asCodMTipo=${item.COD_MTIPO}&asCodInforme=${item.COD_INFORME}`;
}

_informe.AsociarInforme = function () {
    $('#myTab a.nav-link[href="#navDatos"]').tab("show");
    _renderListExpediente.fnViewModalConsulta();
    //_renderListExpediente.fnCallback = function (data) {
    //	ManRD_AddEdit.fnSaveForm();
    //	delete _renderListExpediente.fnCallback;
    //}
}

_informe.DOMEvents = function () {
    $('body').on('click', '.prevent .dropdown-menu', function (e) {
        e.stopPropagation();
    });
}

$(function () {
    app = new Vue({
        el: '#frmInforme',
        data: {
            Informe: {
                COD_INFORME_DIGITAL: null,
                COD_RES_SUB: null,
                NUM_INFORME_SITD: null,
                COD_PROCEDENCIA: null,
                PROCEDENCIA: null,
                COD_MATERIA: null,
                MATERIA: null,
                COD_MODALIDAD: null,
                MODALIDAD: null,
                COD_INFORME: null, //Informe de supervision (auxiliar, obtenemos de la cabecera)
                NRO_REFERENCIA: null,
                INF_FECHA: null,
                //INF_ANTECEDENTES: null,
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
                RES_DIRECTORAL_ANIO: null,
                RES_DIRECTORAL_UND_ORGANICA: null,
                RES_DIRECTORAL_FECHA: null,
                FIRMAS: [],
                RECURSOS: [],
                INFRACCIONES: [],
                CAUSALES_CADUCIDAD: [],
                //VISTOS: null,
                //ANTECEDENTES: null,
                //COMPETENCIA: null,
                //ANALISIS: null,
                //IMPUTACION: null,
                //COMUNICACION_EXTERNA: null,
                //PARRAFOS_CLICHE: null,
                //PIE_PAGINA: null,
                //RESOLUCION: null,

                /** Nuevos campos */
                FLG_CADUCIDAD_EXTRACCION: true,
                FLG_IMPUTACION_CARGOS: true,
                FLG_MEDIDAS_CAUTELARES: true,
                FLG_COMUNICACION: true,
                FLG_HERRAMIENTAS_SUBSANAR: true,

                RUTA_ARCHIVO_REVISION: null,
                FECHA_REGISTRO: new Date(),
                ESTADO: 1
            },
            Inf_Supervision: [],
            oficinaDefault: null,
            Tramite: null,
            Procedencias: [
                { COD_PROCEDENCIA: 'SDI', PROCEDENCIA: 'Subdirección de Instrucción' },
            ],
            Materias: [
                { COD_MATERIA: '01', MATERIA: 'Fauna Silvestre' },
                { COD_MATERIA: '02', MATERIA: 'Recursos Forestales' },
            ],
            Modalidades: [],
            Infracciones: []
        },
        methods: {
            init: async function () {
                const self = this;

                const datos = ManRD_AddEdit.frm.serializeObject();
                const user = ManRD_AddEdit.userApp;

                //Valores por defecto
                const values = {
                    COD_PROCEDENCIA: "SDI",
                    COD_MATERIA: "02",
                    COD_RES_SUB: datos.hdfCodResodirec,
                    NUM_INFORME_SITD: datos.txtNumeroExpediente,
                    COD_THABILITANTE: datos.hdfCodTitular,
                    RES_DIRECTORAL_FECHA: fnDate.text(new Date()),
                    REPRESENTANTE_LEGAL: document.getElementById('txtTitular')?.value,
                    FIRMAS: [
                        { funcion: 'Especialista Legal', codPersona: user.COD_PERSONA, apellidosNombres: user.PERSONA, flgAplica: true, estado: 1 },
                        { funcion: 'Ingeniero Forestal', codPersona: null, apellidosNombres: null, flgAplica: true, estado: null },
                        { funcion: 'Coordinador', codPersona: null, apellidosNombres: null, flgAplica: true, estado: null },
                        { funcion: 'Subdirector', codPersona: null, apellidosNombres: null, flgAplica: true, estado: null },
                    ],
                    RECURSOS: [],
                };

                self.Informe = { ...self.Informe, ...values };

                //Valores por defecto infracciones, causales
                const configuracion = await self.Configuracion();
                
                //Causales_Caducidad
                data.Infracciones = configuracion.infracciones;
                data.Causales_Caducidad = configuracion.causales_caducidad;

                self.MateriaOnChange();

                //Verificamos si existe informacion registrada en la base de datos
                if (self.Informe.COD_RES_SUB) {
                    const res_general = await self.Informacion(values);

                    const res_tramite = await self.TramiteByID();

                    if (res_tramite.success) {
                        self.Tramite = res_tramite.data;
                        //app.Informe.DESTINATARIO = res_tramite.data.trabajador;
                    }

                    //Recursos
                    if (!self.Informe.COD_INFORME_DIGITAL) {
                        const res_files = await self.ObtenerArchivos();
                    }
                }
            },
            MateriaOnChange: function () {
                this.Modalidades = data.Modalidades.filter(x => x.COD_MATERIA === this.Informe.COD_MATERIA);
                this.Informe.COD_MODALIDAD = this.Modalidades[0].COD_MODALIDAD;

                _informe.EXTRAER_INFRACCIONES_POR_MODALIDAD();
            },
            Configuracion: function () {
                return new Promise((resolve, reject) => {
                    let params = {
                        type: 'get',
                        url: `${urlLocalSigo}Fiscalizacion/ManPAU/ObtenerConfiguracion`
                    };

                    utilSigo.fnAjax(params, function (res) {
                        resolve(res);
                    }, function () {
                        reject();
                    });
                });
            },
            Informacion: function (values) {
                const self = this;

                const promise = new Promise((resolve, reject) => {
                    let params = {
                        type: 'post',
                        url: `${urlLocalSigo}Fiscalizacion/ManPAU/ObtenerRSD`,
                        datos: JSON.stringify({ COD_RESOLUCION: self.Informe.COD_RES_SUB })
                    };

                    utilSigo.fnAjax(params, function (res) {
                        //console.log(res);							
                        if (res.informe) {
                            res.informe.RES_DIRECTORAL_FECHA = fnDate.text(res.informe.RES_DIRECTORAL_FECHA);
                            res.informe.FIRMAS.forEach(function (x) {
                                x.flgAplica = !!x.estado;
                            });

                            self.Informe = { ...self.Informe, ...res.informe };

                            //=====================================================
                            self.Informe.COD_PROCEDENCIA = res.informe.COD_PROCEDENCIA;
                            self.Informe.COD_MATERIA = res.informe.COD_MATERIA;
                            //=====================================================

                            self.Informe.COD_RES_SUB = res.informe.COD_RES_SUB || values.COD_RES_SUB;
                            self.Informe.NUM_INFORME_SITD = res.informe.NUM_INFORME_SITD || values.NUM_INFORME_SITD;
                            self.Informe.REPRESENTANTE_LEGAL = res.informe.REPRESENTANTE_LEGAL || values.REPRESENTANTE_LEGAL;

                            //Seleccionamos las infracciones y causales de caducidad
                            data.Infracciones.forEach(item => {
                                item.select = !!res.informe.INFRACCIONES.find(x => x.codInfraccion == item.codInfraccion);
                            });

                            data.Causales_Caducidad.forEach(item => {
                                item.select = !!res.informe.CAUSALES_CADUCIDAD.find(x => x.codCausalCaducidad == item.codCausalCaducidad);
                            });
                        }

                        //CABECERA
                        //Asociacion con el informe de supervision
                        self.Inf_Supervision = res.inf_supervision;
                        const cab = res.inf_supervision[0];

                        if (cab) {
                            self.Informe.COD_INFORME = cab.COD_INFORME;
                            self.Informe.NRO_REFERENCIA = res.inf_supervision.map(function (x) { return x.NUM_INFORME }).join(', ');

                            self.Informe.INF_FECHA = fnDate.text_long(cab.INF_FECHA);
                            //self.Informe.INF_ANTECEDENTES = cab.INF_ANTECEDENTES;

                            self.Informe.TITULAR_SUPERVISADO = cab.TITULAR_SUPERVISADO;
                            self.Informe.DOCUMENTO_TITULAR = cab.DOCUMENTO_TITULAR;
                            self.Informe.REPRESENTANTE_LEGAL = cab.REPRESENTANTE_LEGAL || cab.TITULAR_SUPERVISADO;
                            self.Informe.DOCUMENTO_RLEGAL = cab.DOCUMENTO_RLEGAL;
                            self.Informe.COD_THABILITANTE = cab.COD_THABILITANTE;
                            self.Informe.NUM_THABILITANTE = cab.NUM_THABILITANTE;
                            self.Informe.RUC_TITULAR = cab.RUC_TITULAR;

                            if (cab.UBIGEO_THABILITANTE) {
                                [self.Informe.UBIGEO_DEPARTAMENTO, self.Informe.UBIGEO_PROVINCIA, self.Informe.UBIGEO_DISTRITO] = cab.UBIGEO_THABILITANTE.split('-');
                            }
                        }

                        // Si no está guardado aun el informe, cargamos los datos por defecto
                        /*if (!res.informe) {
                            const data = JSON.parse(JSON.stringify(self.Informe));
                            data.Inf_Supervision = cab || {};

                            self.Informe.VISTOS = _informe.tmpl.Vistos(data);
                            self.Informe.ANTECEDENTES = data.INF_ANTECEDENTES || _informe.tmpl.Antecedentes(data);
                            self.Informe.COMPETENCIA = _informe.tmpl.Competencia(data);
                            self.Informe.IMPUTACION = _informe.tmpl.Imputacion(data);
                            self.Informe.COMUNICACION_EXTERNA = _informe.tmpl.Comunicacion_Externa(data);
                            self.Informe.PARRAFOS_CLICHE = _informe.tmpl.Cliche(data);
                            self.Informe.PIE_PAGINA = _informe.tmpl.Pie_Pagina(data);
                            self.Informe.RESOLUCION = _informe.tmpl.Resolucion(data);
                        }*/

                        resolve(res);
                    });
                });

                return promise;
            },
            TramiteByID: function (datos) {
                const self = this;
                datos = datos || JSON.parse(JSON.stringify(self.Informe));

                const promise = new Promise((resolve, reject) => {
                    if (!datos.TRAMITE_ID || !datos.COD_THABILITANTE || !datos.COD_RES_SUB) {
                        reject("Faltan datos para extraer información de trámite");
                        return;
                    }

                    const params = {
                        url: `${urlLocalSigo}Fiscalizacion/ManPAU/TramiteGetById`,
                        datos: { id: datos.TRAMITE_ID, codTHabilitante: datos.COD_THABILITANTE, codInforme: datos.COD_RES_SUB }
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

                            self.Informe.RECURSOS = files;
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
                        self.Informe.RECURSOS.splice(index, 1);
                    }
                });
            },
            ConsultaRUC: function () {
                let self = this;
                let RUC = self.Informe.RUC_TITULAR;
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
                let self = this;

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

                            //if (self.Informe.COD_INFORME_DIGITAL) {
                            //	item.estado = 2; //MODIFICAR
                            //}

                            utilSigo.fnCloseModal("mdlBuscarPersona");
                        }
                    }
                    _bPerGen.fnInit();
                });
            },
            Abrir_Notificar: async function (item) {
                const self = this;
                modal_notificar.form.Mensaje = 'Por favor revisar el informe para la continuidad del proceso.';

                let users = [];

                if (item) users = [item.codPersona];
                else users = this.Informe.FIRMAS.map(user => user.codPersona);

                const res = await modal_notificar.ObtenerCorreos(users);

                //Actualizar los participantes despues de notificar
                modal_notificar.callback = function () {
                    const personas = self.Informe.FIRMAS
                        .filter(item => res.find(x => x.codPersona == item.codPersona));

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
                        url: `${urlLocalSigo}Fiscalizacion/ManPAU/RSDFirmaActualizar`,
                        datos: JSON.stringify({ participantes })
                    };

                    utilSigo.fnAjax(params, function () {
                        self.Informe.FIRMAS.forEach(x => {
                            const data = participantes.find(item => item.item == x.item);
                            if (data) {
                                x.estado = data.estado;
                            }
                        });
                    });
                }

                modal_notificar.Abrir(res);
            },
            Notificar: function (item, mensaje) {
                let notificacion = {
                    COD_PERSONA: item.codPersona,
                    COD_INFORME: this.Informe.COD_RES_SUB,
                    MENSAJE_ENVIO_ALERTA: mensaje,
                    URL_LOCAL: window.location.href
                };

                let objEN;
                if (this.Informe.COD_INFORME_DIGITAL) {
                    objEN = {
                        codInformeDigital: this.Informe.COD_INFORME_DIGITAL,
                        item: item.item,
                        estado: item.estado > 2 ? item.estado : 2
                    }
                }

                let params = {
                    type: 'post',
                    url: `${urlLocalSigo}Fiscalizacion/ManPAU/NotificarRSD`,
                    datos: JSON.stringify({ notificacion, objEN })
                };

                utilSigo.fnAjax(params, function (res) {
                    if (res) {
                        item.estado = objEN?.estado || 2;
                        utilSigo.toastSuccess('Enviado', res);
                    } else {
                        utilSigo.toastWarning('Atención', 'No se ha encontrado ningún correo asociado al usuario');
                    }
                });
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
                this.Informe.FIRMAS.splice(index, 1);
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
                app.Informe.FIRMAS.push(user);

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
                            .filter(item => (item?.CORREO || '').indexOf('@') != -1)
                            .map(item => ({
                                codPersona: item.COD_PERSONA,
                                persona: `${item.NOMBRES} ${item.APE_PATERNO} ${item.APE_MATERNO}`,
                                email: item.CORREO
                            }));

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
                const notificacion = {
                    DESTINATARIOS: self.form.Seleccionados.map(item => item.email).join(','),
                    CC_DESTINATARIOS: self.form.CC,
                    COD_INFORME: app.Informe.NUM_INFORME_SITD,
                    MENSAJE_ENVIO_ALERTA: _informe.render(self.form.Mensaje),
                    URL_LOCAL: window.location.href
                };

                let params = {
                    type: 'post',
                    url: `${urlLocalSigo}Fiscalizacion/ManPAU/Notificar`,
                    datos: JSON.stringify({ notificacion })
                };

                utilSigo.fnAjax(params, function (res) {
                    if (res) {
                        //Para ejecutar cualquier acción despues de enviar un correo
                        if (typeof self.callback === 'function') self.callback(res);
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

    _informe.DOMEvents();
});