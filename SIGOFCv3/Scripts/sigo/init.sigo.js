const initSigo = {};
(function () {
    this.redireccionarError = function (error) {
        window.location = urlLocalSigo + "Login/ErrorC?msjError=" + error;
    }
    this.MessageError = "Sucedio un Error Inesperado, Comuníquese con el Administrador";
    //almacena la url del controller general: /General/Controles
    this.urlControllerGeneral = "";
    //Formato DatePicker
    this.formatDatePicker = {
        format: "dd/mm/yyyy",
        autoclose: true,
        language: 'es'
    };
    //Configuracion Datatables
    this.oLanguage = {
        "sProcessing": '<i class="fa fa-coffee"></i>&nbsp;Cargando Datos...',
        "sLengthMenu": "Mostrar _MENU_ registros",
        "sZeroRecords": "No se encontraron resultados",
        "sEmptyTable": "No existen datos registrados",
        "sInfo": "Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros",
        "sInfoEmpty": "Mostrando registros del 0 al 0 de un total de 0 registros",
        "sInfoFiltered": "(filtrado de un total de _MAX_ registros)",
        "sInfoPostFix": "",
        "sSearch": "Buscar:",
        "sUrl": "",
        "sInfoThousands": ",",
        "sLoadingRecords": "Cargando...",
        "oPaginate": {
            "sFirst": "Primero",
            "sLast": "Último",
            "sNext": "Siguiente",
            "sPrevious": "Anterior"
        },
        "oAria": {
            "sSortAscending": ": Activar para ordenar la columna de manera ascendente",
            "sSortDescending": ": Activar para ordenar la columna de manera descendente"
        }
    };
    //Configuracion del idioma español de plugin jquery validate
    this.oLanguageValidate = {
        required: "Este campo es obligatorio.",
        remote: "Por favor, rellena este campo.",
        email: "Por favor, escribe una dirección de correo válida",
        url: "Por favor, escribe una URL válida.",
        date: "Por favor, escribe una fecha válida.",
        dateISO: "Por favor, escribe una fecha (ISO) válida.",
        number: "Por favor, escribe un número entero válido.",
        digits: "Por favor, escribe sólo dígitos.",
        creditcard: "Por favor, escribe un número de tarjeta válido.",
        equalTo: "Por favor, escribe el mismo valor de nuevo.",
        accept: "Por favor, escribe un valor con una extensión aceptada.",
        maxlength: jQuery.validator.format("Por favor, no escribas más de {0} caracteres."),
        minlength: jQuery.validator.format("Por favor, no escribas menos de {0} caracteres."),
        rangelength: jQuery.validator.format("Por favor, escribe un valor entre {0} y {1} caracteres."),
        range: jQuery.validator.format("Por favor, escribe un valor entre {0} y {1}."),
        max: jQuery.validator.format("Por favor, escribe un valor menor o igual a {0}."),
        min: jQuery.validator.format("Por favor, escribe un valor mayor o igual a {0}.")
    };

    //Para Numero de Paginacion
    this.pageLength = 20;
    this.pageLengthBuscar = 10;
    //Muestra el div paginacion si tiene mas 2 de pages
    this.showPagination = function (settings) {
        const api = new $.fn.dataTable.Api(settings);
        const pageCount = api.page.info().pages;

        var pagination = $(this).closest('.dataTables_wrapper').find('.dataTables_paginate');
        pagination.toggle(pageCount > 1);
        /*$('[data-toggle="tooltip"]').tooltip();
        $('[data-toggle="popover"]').popover();
        $('[data-toggle="popover"]').popover({
            html: true,
            trigger: 'manual'
        }).click(function (e) {
            $('[data-toggle="popover"]').not(this).popover('hide');
        });
        $('html').on('click', function (e) {
            $('[data-toggle="popover"]').each(function () {
                //the 'is' for buttons that trigger popups
                //the 'has' for icons within a button that triggers a popup
                if (!$(this).is(e.target) && $(this).has(e.target).length === 0 && $('.popover').has(e.target).length === 0) {
                    $(this).popover('hide');
                }
            });
        });
       */
    }
    this.configuracionCKEDITOR = [
        '/',
        { name: 'basicstyles', groups: ['basicstyles', 'cleanup'], items: ['Bold', 'Italic', 'Underline', 'Strike', 'Subscript', 'Superscript', '-', 'CopyFormatting', 'RemoveFormat'] },
        { name: 'paragraph', groups: ['list', 'indent', 'blocks', 'align', 'bidi'], items: ['NumberedList', 'BulletedList', '-', 'Outdent', 'Indent', '-', '-', 'JustifyLeft', 'JustifyCenter', 'JustifyRight', 'JustifyBlock', '-', 'Language'] },
        { name: 'insert', items: ['Image', 'Table', 'HorizontalRule', 'Smiley', 'SpecialChar', 'PageBreak'] },
        '/',
        { name: 'styles', items: ['Styles', 'Format', 'Font', 'FontSize'] },
        { name: 'colors', items: ['TextColor', 'BGColor'] },
        { name: 'tools', items: ['Maximize', 'ShowBlocks'] },
        { name: 'others', items: ['-'] },
        { name: 'about', items: ['About'] }
    ];


}).apply(initSigo);

const RegEstadoSigo = {
    INITIAL: 0,
    NEW: 1,
    UPDATE: 2,
    DELETE: 3
}
//Para cambiar los mensajes de jquery validate al español
$(document).ready(function () {
    jQuery.extend(jQuery.validator.messages, initSigo.oLanguageValidate);
});