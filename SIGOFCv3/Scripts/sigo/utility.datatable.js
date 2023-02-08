
"use strict";
//Extensión para ordenar fechas
jQuery.extend(jQuery.fn.dataTableExt.oSort, {
    "date-pe-pre": function (a) {
        var ukDatea = a.split('/');
        return (ukDatea[2] + ukDatea[1] + ukDatea[0]) * 1;
    },
    "date-pe-asc": function (a, b) {
        return ((a < b) ? -1 : ((a > b) ? 1 : 0));
    },
    "date-pe-desc": function (a, b) {
        return ((a < b) ? 1 : ((a > b) ? -1 : 0));
    }
});

var utilDt = {};

////Utilidades plugin DataTable
//Busqueda de un valor en una columna de una tabla
//dataTable=Objeto del Datatable(), nameData=nombre de la columna a buscar, valorSearch=valor a buscar
utilDt.existValorSearch = function (dataTable, nameData, valorSearch) {
    var result = false;
    dataTable.rows().every(function (rowIdx, tableLoop, rowLoop) {
        var data = this.data();
        if (valorSearch == data[nameData]) {
            result = true;
            return result;
        }
    });

    return result;
}
utilDt.unionRows = function (dataTable, nameData, characterUnion) {
    var character = "";
    dataTable.rows().every(function (rowIdx, tableLoop, rowLoop) {
        var data = this.data();
        character = character + data["cod"] + characterUnion;
    });
    if (character.length > 0)
        character = character.slice(0, -1)
    return character;
}
//Agrega un contador a toda la tabla en la columna indexColumn
//dataTable=Objeto del Datatable,indexColumn=Indice   de la columna comienza en 0
utilDt.enumTB = function (dataTable, indexColumn) {
    dataTable.on('order.dt', function () {
        dataTable.column(indexColumn, {}).nodes().each(function (cell, i) {
            cell.innerHTML = i + 1;
            dataTable.cell(cell).invalidate('dom');
        });
    }).draw(false);
}

/*
    La propiedad del DataTable: "deferRender": true permite cargar solo el HTML de las filas a mostrar
    por lo que solo enumera las filas mostradas al inicio y las otras no. Esta función enumera las filas
    según se vayana mostrando; no funciona en combinación con la propiedad Sort (ordenar)
*/
utilDt.enumTB_DeferRender = function (dataTable, indexColumn) {
    dataTable.on('draw.dt', function () {
        console.log(dataTable.context[0]._iDisplayStart);
        var index = 1;
        dataTable.column(indexColumn, {}).nodes().each(function (cell, i) {
            if (index == 11) {
                index = 1;
            }
            cell.innerHTML = (index++) + dataTable.context[0]._iDisplayStart;
            dataTable.cell(cell).invalidate('dom');
        });
    }).draw(false);
}

//Agrega un contador en la columna nameComun
//dataTable=Objeto del Datatable,nameColumn=nombre de columna   de la columna comienza en 0
utilDt.enumColumn = function (dataTable, nameColumn) {
    nameColumn = (typeof nameColumn === 'undefined') ? "ROW_INDEX" : nameColumn;

    dataTable.rows().every(function (rowIdx, tableLoop, rowLoop) {
        var data = this.data();
        data[nameColumn] = parseInt(rowIdx) + 1;
        this.data(data);
    });
}
//Enumerar 1,2,3 al momento de agregar una fila para una columna datatable
//Se agrega en mRender
utilDt.countRowDT = function (data, type, row, meta) {
    return parseInt(meta.row) + 1;
}

//Inicializar DataTable Base
utilDt.fnInitDataTable = function (options) {
    var optDt = {};
    optDt.iLength = (typeof options.page_length === 'undefined') ? 25 : options.page_length;
    optDt.bSearch = (typeof options.page_search === 'undefined') ? false : options.page_search;
    optDt.bInfo = (typeof options.page_info === 'undefined') ? false : options.page_info;
    optDt.bSort = (typeof options.page_sort === 'undefined') ? false : options.page_sort;
    optDt.sExpTit = (typeof options.export_title === 'undefined') ? "" : options.export_title;
    optDt.bRender = (typeof options.page_render === 'undefined') ? false : options.page_render;
    optDt.bAutoWidth = (typeof options.page_autowidth === 'undefined') ? true : options.page_autowidth;
    optDt.bLengthChange = (typeof options.length_Change === 'undefined') ? false : options.length_Change;
    //Cargar botones
    optDt.buttons = [];
    options.columns_export_hide = (typeof options.columns_export_hide === 'undefined') ? [] : options.columns_export_hide;
    options.columns_export_hide = options.columns_export_hide.length == 0 ? "" : options.columns_export_hide;

    if ((typeof options.button_copy !== 'undefined') && options.button_copy == true) {
        optDt.buttons.push({ extend: 'copyHtml5', footer: true, text: "Copiar", exportOptions: { columns: options.columns_export_hide }, messageTop: optDt.sExpTit });
    }
    if ((typeof options.button_csv !== 'undefined') && options.button_csv == true) {
        optDt.buttons.push({ extend: 'csvHtml5', footer: true, exportOptions: { columns: options.columns_export_hide }, messageTop: optDt.sExpTit });
    }
    if ((typeof options.button_excel !== 'undefined') && options.button_excel == true) {
        optDt.buttons.push({
            extend: 'excelHtml5', footer: true, exportOptions: { columns: options.columns_export_hide }, messageTop: optDt.sExpTit/*,
            customize: function (xlsx) {
                var sheet = xlsx.xl.worksheets['sheet1.xml'];

            }*/
        });
    }
    if ((typeof options.button_pdf !== 'undefined') && options.button_pdf == true) {
        optDt.buttons.push({ extend: 'pdfHtml5', footer: true, orientation: 'landscape', pageSize: 'LEGAL', exportOptions: { columns: options.columns_export_hide }, messageTop: optDt.sExpTit });
    }
    if ((typeof options.button_print !== 'undefined') && options.button_print == true) {
        optDt.buttons.push({ extend: 'print', footer: true, text: "Imprimir", exportOptions: { columns: options.columns_export_hide }, messageTop: optDt.sExpTit });
    }

    var dt = null;
    if (optDt.buttons.length == 0) {
        dt = $(options.table).DataTable({
            "bServerSide": false,
            "deferLoading": 0,
            "bAutoWidth": optDt.bAutoWidth,
            "bProcessing": true,
            "bJQueryUI": false,
            "bFilter": optDt.bSearch,
            "aaSorting": [],
            "pageLength": optDt.iLength,
            "oLanguage": initSigo.oLanguage,
            "drawCallback": initSigo.showPagination,
            bInfo: optDt.bInfo,
            bLengthChange: optDt.bLengthChange,
            columns: options.table_columns
            , ordering: optDt.bSort
            , "deferRender": optDt.bRender
        });
    } else {

        dt = $(options.table).DataTable({
            "bServerSide": false,
            "deferLoading": 0,
            "bAutoWidth": optDt.bAutoWidth,
            "bProcessing": true,
            "bJQueryUI": false,
            "bFilter": optDt.bSearch,
            "aaSorting": [],
            "pageLength": optDt.iLength,
            "oLanguage": initSigo.oLanguage,
            "drawCallback": initSigo.showPagination,
            bInfo: optDt.bInfo,
            bLengthChange: optDt.bLengthChange,
            columns: options.table_columns
            , dom: "Bfrtip"
            , buttons: optDt.buttons
            , ordering: optDt.bSort
            , "deferRender": optDt.bRender
        });
    }

    if (options.row_pos_index != null) {
        if (optDt.bRender) {
            utilDt.enumTB_DeferRender(dt, options.row_pos_index);
        } else {
            utilDt.enumTB(dt, options.row_pos_index);
        }
    }

    return dt;
}

/*-------------------Inicializar DataTable Detalle-------------------
--objTableDetail: DOM de la tabla definida en un formulario
--columns_label: ['lbl_1','lbl_2','lbl_3',..] Títulos de las columnas
--columns_data: ['dat_1','dat_2','dat_3',...] Variables asociadas a las columnas;
--options:
    options: Configuraciones personalizadas del DataTable                       |   value: Object               | default: {}
    options.row_edit: Habilitar opción editar                                   |   value: {true, false}        | default: false
    options.row_fnEdit: Función editar                                          |   value: fn()                 | default: ''
    options.row_delete: Habilitar opción eliminar                               |   value: {true, false}        | default: false
    options.row_fnDelete: Función eliminar                                      |   value: fn()                 | default: ''
    options.row_select: Habilitar opción seleccionar                            |   value: {true, false}        | default: false
    options.row_fnSelect: Función seleccionar                                   |   value: fn()                 | default: ''
    options.row_download: Habilitar opción descargar                            |   value: {true, false}        | default: false
    options.row_fnDownload: Función descargar                                   |   value: fn()                 | default: ''
    options.row_index: Muestra el índice de la fila                             |   value: {true, false}        | default: false
    options.row_data_index: En caso el valor se obtenga desde el servidor       |   value: [Column Data]        | default: ''
    options.row_name_index: En caso el valor se obtenga en el mismo cliente     |   value: [Column Name]        | default: 'ROW_INDEX'
    options.page_length: Número de filas a mostrar por página                   |   value: Int                  | default: 25
    options.page_search: Mostrar campo de búsqueda                              |   value: {true, false}        | default: false
    options.page_info: Mostrar información de los registros                     |   value: {true, false}        | default: false
    options.page_sort: Habiltar ordenar por columnas                            |   value: {true, false}        | default: false
    options.button_copy: Mostrar botón copiar datos DataTable                   |   value: {true, false}        | default: false
    options.button_csv: Mostrar botón exportar datos DataTable a CSV            |   value: {true, false}        | default: false
    options.button_excel: Mostrar botón exportar datos DataTable a Excel        |   value: {true, false}        | default: false
    options.button_pdf: Mostrar botón exportar datos DataTable a PDF            |   value: {true, false}        | default: false
    options.button_print: Mostrar botón imprimir datos DataTable                |   value: {true, false}        | default: false
    options.export_title: Título a mostrar cuando se exporte los datos          |   value: String               | default: ''
    options.data_extend: Columnas adicionales, formato DataTable                |   value: Object[]             | default: null
    options.page_paging: Flag que indica uso paginación del lado del servidor   |   value: {true, false}        | default: false
    options.page_render: Flag que indica cargar solo el HTML de las filas       |   value: {true, false}        | default: false
                    a mostrar; usar en casos que se tenga muchos registros
    options.page_autowidth: Flag que indica habilita el ajuste automatico de    |   value: {true, false}        | default: true
                    de columnas, usar false para ajuste personalizado (width=20%)
    options.row_view: Habilitar opción ver, observar                            |   value: {true, false}        | default: false
    options.row_fnView: Función observar                                        |   value: fn()                 | default: ''
    options.row_change: Habilitar opción revisar                                |   value: {true, false}        | default: false
    options.row_fnChange: Función revisar                                       |   value: fn()                 | default: ''
*/
utilDt.fnLoadDataTable_Detail = function (objTableDetail, columns_label, columns_data, options) {
    //Validar datos a mostrar
    if (columns_label.length != columns_data.length || columns_data.length == 0) {
        utilSigo.toastError("Error", "Sucedio un error, Comuníquese con el Administrador");
        console.log("El tamaño de columnas de: columns_label y columns_data no coinciden.");
        return false;
    }
    //Set default options
    if (typeof options === 'undefined') options = {};
    options.row_pos_index = null;
    options.page_paging = (typeof options.page_paging === 'undefined') ? false : options.page_paging;
    //Construir thead y tbody DataTable
    var theadTable = "<tr>", tbodyTable = [], colExpHide = [], colPos = 0;
    //Add selecionar al inicio
    if ((typeof options.firstSelect !== 'undefined') && options.firstSelect == true) {
        theadTable += "<th></th>";
        tbodyTable.push({
            "data": "", "orderable": false, "searchable": false,
            "defaultContent": '<i class="fa fa-lg fa-check" style="cursor: pointer;color:forestgreen;" title="Seleccionar" onclick="' + options.row_fnSelect + '"></i>'
        });
        colExpHide.push(columns_label.length + colPos);
        colPos++;
    } 
    // opción descargar
    if ((typeof options.button_excel !== 'undefined') && options.button_excel == true) {
        theadTable += "<th></th>";
        tbodyTable.push({
            "data": "", "width": "1%", "orderable": false, "searchable": false, "visible": true,
            "defaultContent": ""
        });
        colExpHide.push(colPos++);
    }
    //Opción Editar
    if ((typeof options.row_edit !== 'undefined') && options.row_edit == true && (typeof options.row_fnEdit !== 'undefined')) {
        theadTable += "<th></th>";
        tbodyTable.push({
            "data": "", "width": "2%", "orderable": false, "searchable": false,
            "defaultContent": '<div><i class="fa fa-lg fa-pencil-square-o" style="color:blue;cursor:pointer;" title="Editar" onclick="' + options.row_fnEdit + '"></i>'
        });
        colExpHide.push(colPos++);
    }
    //Opción Eliminar
    if ((typeof options.row_delete !== 'undefined') && options.row_delete == true && (typeof options.row_fnDelete !== 'undefined')) {
        theadTable += "<th></th>";
        tbodyTable.push({
            "data": "", "width": "2%", "orderable": false, "searchable": false,
            "defaultContent": '<i class="fa fa-lg fa-window-close" style="color:red;cursor:pointer;" title="Eliminar" onclick="' + options.row_fnDelete + '"></i>'
        });
        colExpHide.push(colPos++);
    }
    //Opción Observar, ver u otro
    if ((typeof options.row_view !== 'undefined') && options.row_view == true && (typeof options.row_fnView !== 'undefined')) {
        theadTable += "<th></th>";
        tbodyTable.push({
            "data": "", "width": "2%", "orderable": false, "searchable": false,
            "defaultContent": '<i class="fa fa-lg fa-eye" style="color:black;cursor:pointer;" title="Observar" onclick="' + options.row_fnView + '"></i>'
        });
        colExpHide.push(colPos++);
    }
    //Opción Cambiar
    if ((typeof options.row_change !== 'undefined') && options.row_change == true && (typeof options.row_fnChange !== 'undefined')) {
        theadTable += "<th></th>";
        tbodyTable.push({
            "data": "", "width": "2%", "orderable": false, "searchable": false,
            "defaultContent": '<i class="fa fa-lg fa-exchange" style="color:black;cursor:pointer;" title="Cambiar" onclick="' + options.row_fnChange + '"></i>'
        });
        colExpHide.push(colPos++);
    }
    //Opción Check
    if ((typeof options.row_check !== 'undefined') && options.row_check == true && (typeof options.row_fnCheck !== 'undefined')) {
        theadTable += "<th></th>";
        tbodyTable.push({
            "data": "", "width": "2%", "orderable": false, "searchable": false,

            "defaultContent": '<i class="cellCheck fa fa-lg fa-check-square-o" title="Click para Desactivar" onclick="' + options.row_fnCheck + '"></i>'
        });
        colExpHide.push(colPos++);
    }
    //Opción NoCheck
    if ((typeof options.row_nocheck !== 'undefined') && options.row_nocheck == true && (typeof options.row_fnNoCheck !== 'undefined')) {
        theadTable += "<th></th>";
        tbodyTable.push({
            "data": "", "width": "2%", "orderable": false, "searchable": false,

            "defaultContent": '<i class="cellUnCheck fa fa-lg fa-square-o" title="Click para activar" onclick="' + options.row_fnNoCheck + '"></i>'
        });
        colExpHide.push(colPos++);
    }
    //Índice
    if ((typeof options.row_index !== 'undefined') && options.row_index == true) {
        theadTable += "<th>N°</th>";
        if ((typeof options.row_data_index !== 'undefined')) {
            tbodyTable.push({
                "data": options.row_data_index, "orderable": false, "searchable": false
            });
        } else {
            options.row_name_index = (typeof options.row_name_index === 'undefined') ? "ROW_INDE" : options.row_name_index;

            if (options.page_paging) {
                tbodyTable.push({
                    "name": options.row_name_index, "width": "2%", "orderable": false, "searchable": false, "mRender": function (data, type, row, meta) {
                        return parseInt(meta.row) + 1 + meta.settings._iDisplayStart;
                    }
                });
            } else {
                if (typeof options.page_sort === 'undefined' || options.page_sort == false) {
                    tbodyTable.push({
                        "name": options.row_name_index, "width": "2%", "orderable": false, "searchable": false, "mRender": function (data, type, row, meta) {
                            return parseInt(meta.row) + 1;
                        }
                    });
                } else {
                    tbodyTable.push({
                        "name": options.row_name_index, "width": "2%", "orderable": false, "searchable": false, "defaultContent": ''
                    });
                    options.row_pos_index = colPos;
                }
            }
        }
        colPos++;
    }
    /*--------DATA--------*/
    for (var i = 0; i < columns_label.length; i++) {
        theadTable += "<th>" + columns_label[i] + "</th>";

        if (columns_data[i].includes("FECHA")) {
            tbodyTable.push({
                "data": columns_data[i], "sType": "date-pe"
            });
        } else {
            tbodyTable.push({
                "data": columns_data[i]
            });
        }
    }
    /*--------------------*/
    //Opción Seleccionar
    if ((typeof options.firstSelect == 'undefined')) {
        if ((typeof options.row_select !== 'undefined') && options.row_select == true && (typeof options.row_fnSelect !== 'undefined')) {
            theadTable += "<th></th>";
            tbodyTable.push({
                "data": "", "orderable": false, "searchable": false,
                "defaultContent": '<i class="fa fa-lg fa-check" style="cursor: pointer;color:forestgreen;" title="Seleccionar" onclick="' + options.row_fnSelect + '"></i>'
            });
            colExpHide.push(columns_label.length + colPos);
            colPos++;
        }
    }
    //Opción Descargar
    if ((typeof options.row_download !== 'undefined') && options.row_download == true && (typeof options.row_fnDownload !== 'undefined')) {
        theadTable += "<th></th>";
        tbodyTable.push({
            "data": "", "orderable": false, "searchable": false,
            "defaultContent": '<i class="fa fa-lg fa-download" style="cursor: pointer;color:dodgerblue;" title="Descargar" onclick="' + options.row_fnDownload + '"></i>'
        });
        colExpHide.push(columns_label.length + colPos);
        colPos++;
    }
    //Columnas Adicionales (data extend)
    if (typeof options.data_extend !== 'undefined') {
        for (var i = 0; i < options.data_extend.length; i++) {
            theadTable += "<th>" + options.data_extend[i].title + "</th>";
            tbodyTable.push(options.data_extend[i]);
        }
    }

    theadTable += "</tr>";
    $(objTableDetail).find("thead").append(theadTable);
    //Set tbody DataTable
    options.table = objTableDetail;
    options.table_columns = tbodyTable;
    options.columns_export_hide = colExpHide;

    if (options.page_paging) {
        return null;
    } else {
        return utilDt.fnInitDataTable(options);
    }
}
/*-------------------Fin DataTable Detalle-------------------*/

/*-------------------Inicializar DataTable con Evento en la(s) Columna(s)-------------------
--objTable: DOM de la tabla definida en un formulario
--columns_label: ['lbl_1','lbl_2','lbl_3',..] Títulos de las columnas
--columns_data: ['dat_1','dat_2','dat_3',...] Variables asociadas a las columnas
--columns_event: ['flg_1','flg_2','flg_3',...] Flags que indican si una columna contiene un evento o no
--options:
    options: Configuraciones personalizadas del DataTable                       |   value: Object               | default: {}
    options.row_index: Muestra el índice de la columna                          |   value: {true, false}        | default: false
    options.row_data_index: En caso el valor se obtenga desde el servidor       |   value: [Column Data]        | default: ''
    options.row_name_index: En caso el valor se obtenga en el mismo cliente     |   value: [Column Name]        | default: 'ROW_INDEX'
    options.page_length: Número de filas a mostrar por página                   |   value: Int                  | default: 25
    options.page_search: Mostrar campo de búsqueda                              |   value: {true, false}        | default: false
    options.page_info: Mostrar información de los registros                     |   value: {true, false}        | default: false
    options.page_sort: Habiltar ordenar por columnas                            |   value: {true, false}        | default: false
    options.button_copy: Mostrar botón copiar datos DataTable                   |   value: {true, false}        | default: false
    options.button_csv: Mostrar botón exportar datos DataTable a CSV            |   value: {true, false}        | default: false
    options.button_excel: Mostrar botón exportar datos DataTable a Excel        |   value: {true, false}        | default: false
    options.button_pdf: Mostrar botón exportar datos DataTable a PDF            |   value: {true, false}        | default: false
    options.button_print: Mostrar botón imprimir datos DataTable                |   value: {true, false}        | default: false
    options.export_title: Título a mostrar cuando se exporte los datos          |   value: String               | default: ''
    options.page_autowidth: Flag que indica habilita el ajuste automatico de    |   value: {true, false}        | default: true
                    de columnas, usar false para ajuste personalizado (width=20%)
*/
utilDt.fnLoadDataTable_EventColumn = function (objTable, columns_label, columns_data, columns_event, options) {
    //Validar datos a mostrar
    if ((columns_label.length != columns_data.length) || (columns_label.length != columns_event.length)
        || (columns_event.length != columns_data.length) || columns_data.length == 0) {
        utilSigo.toastError("Error", "Sucedio un error, Comuníquese con el Administrador");
        console.log("El tamaño de columnas de: columns_label, columns_data y columns_event no coinciden.");
        return false;
    }
    //Set default options
    if (typeof options === 'undefined') options = {};
    options.row_pos_index = null;
    //Construir thead y tbody DataTable
    var theadTable = "<tr>", tbodyTable = [];
    //Índice
    if ((typeof options.row_index !== 'undefined') && options.row_index == true) {
        theadTable += "<th>N°</th>";
        if ((typeof options.row_data_index !== 'undefined')) {
            tbodyTable.push({
                "data": options.row_data_index, "orderable": false, "searchable": false
            });
        } else {
            options.row_name_index = (typeof options.row_name_index === 'undefined') ? "ROW_INDEX" : options.row_name_index;

            if (typeof options.page_sort === 'undefined' || options.page_sort == false) {
                tbodyTable.push({
                    "name": options.row_name_index, "orderable": false, "searchable": false, "mRender": utilDt.countRowDT
                });
            } else {
                tbodyTable.push({
                    "name": options.row_name_index, "orderable": false, "searchable": false, "defaultContent": ''
                });
                options.row_pos_index = 0;
            }
        }
    }

    /*--------DATA--------*/
    for (var i = 0; i < columns_label.length; i++) {
        theadTable += "<th>" + columns_label[i] + "</th>";
        if (columns_event[i] != "") {
            tbodyTable.push({
                "data": columns_data[i],
                "render": function (data, type, full, meta) {
                    return '<a href="javascript:void(0)" style="cursor: pointer;" title="Ver detalle" onclick="utilDt.fnEventColumn(this,' + (meta.col + 1) + ')">' + data + '</a>';
                }
            });
        } else {
            if (columns_data[i].includes("FECHA")) {
                tbodyTable.push({
                    "data": columns_data[i], "sType": "date-pe"
                });
            } else {
                tbodyTable.push({
                    "data": columns_data[i]
                });
            }
        }
    }
    /*--------------------*/
    theadTable += "</tr>";
    $(objTable).find("thead").append(theadTable);

    //Set tbody DataTable
    options.table = objTable;
    options.table_columns = tbodyTable;

    return utilDt.fnInitDataTable(options);
}
//Evento a ejecutar en una celda en específico
utilDt.fnEventColumn = function (obj, col) { /*A implementar en donde se instancia*/ };