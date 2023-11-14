"use strict";
var _ManGrillaPaging = {};

_ManGrillaPaging.fnCreate = function (obj) { /*A implementar en donde se instancia*/ }
_ManGrillaPaging.fnExport = function () { /*A implementar en donde se instancia*/ }

//Inicializar DataTable Paging (Paginación del lado del servidor)
_ManGrillaPaging.fnInitDataTablePaging = function (options) {
    var optDt = {};
    optDt.iLength = (typeof options.page_length === 'undefined') ? 20 : options.page_length;
    optDt.iStart = 0;
    optDt.bSearch = false;
    optDt.bInfo = true;
    optDt.bSort = true;
    optDt.aSort = [];
    
    //Cargar Configuración _ManGrillaPaging
    if (window.sessionStorage) {
        var lstConfig = [], index = -1;

        if (JSON.parse(sessionStorage.getItem('ListConfig_ManGrillaPaging')) == null) {
            sessionStorage.setItem('ListConfig_ManGrillaPaging', JSON.stringify(lstConfig));
        }

        lstConfig = JSON.parse(sessionStorage.getItem('ListConfig_ManGrillaPaging'));
        index = lstConfig.findIndex(m=>m.TipoFormulario == _ManGrillaPaging.frm.find("#tipoFormulario").val());
        if (index != -1) {
            _ManGrillaPaging.frm.find("#ddlOpcionBuscarId").select2("val", [lstConfig[index].OpcionBuscar]);
            _ManGrillaPaging.frm.find("#txtValorBuscar").val(lstConfig[index].ValorBuscar);
            optDt.iLength = lstConfig[index].PageLength;
            optDt.iStart = lstConfig[index].RowStart;
            if ((typeof lstConfig[index].ColumnOrder !== 'undefined') && lstConfig[index].ColumnOrder.length > 0) {
                optDt.aSort.push([lstConfig[index].ColumnOrder[0], lstConfig[index].ColumnOrder[1]]);
            }

            lstConfig.splice(index, 1);
            sessionStorage.setItem('ListConfig_ManGrillaPaging', JSON.stringify(lstConfig));
        }
    }

    return $("#tbManGrillaPaging").DataTable({
        processing: true,
        serverSide: true,
        searching: optDt.bSearch,
        ordering: optDt.bSort,
        paging: true,
        ajax: {
            "url": initSigo.urlControllerGeneral + "/GetListaGeneralPaging",
            "data": function (d) {
                d.customSearchEnabled = true;
                d.customSearchForm = _ManGrillaPaging.frm.find("#tipoFormulario").val();
                d.customSearchType = _ManGrillaPaging.frm.find("#ddlOpcionBuscarId").val();
                d.customSearchValue = _ManGrillaPaging.frm.find("#txtValorBuscar").val();

                for (var i = 0; i < d.order.length; i++) {
                    d.order[i]["column_name"] = d.columns[d.order[i]["column"]]["data"];
                }
                d.columns = null;
            },            
            "error": function (jqXHR) {
                utilSigo.unblockUIGeneral();
                utilSigo.toastError("Error", initSigo.MessageError);
                //console.log(jqXHR.responseText);
            },
            "statusCode": {
                203: () => { utilSigo.unblockUIGeneral(); utilSigo.toastInfo("Aviso", "El usuario perdio la sesión. Vuelva ingresar al sistema"); }
            }
        },
        columns: options.table_columns,
        bInfo: optDt.bInfo,
        "lengthMenu": [[10, 20, 50, 100], [10, 20, 50, 100]],
        "aaSorting": optDt.aSort,
        "pageLength": optDt.iLength,
        "displayStart": optDt.iStart,
        "oLanguage": initSigo.oLanguage,
        "drawCallback": initSigo.showPagination,
    });
}

//Búsqueda de registros
_ManGrillaPaging.fnSearch = function () {
    var valorBusqueda = _ManGrillaPaging.frm.find("#txtValorBuscar").val();
    
    var text = utilSigo.findWords(valorBusqueda);
    if (text != "") {
        utilSigo.toastWarning("Aviso", text);
        return false;
    }

    if (valorBusqueda.trim() == "") {
        utilSigo.toastWarning("Aviso", "Ingrese Valor a Buscar");
        _ManGrillaPaging.frm.find("#txtValorBuscar").focus();
        return false;
    }
    else {
        var cantCarateres = valorBusqueda.length;
        if (cantCarateres < 3) {
            utilSigo.toastWarning("Aviso", "La longitud del criterio de búsqueda debe ser mayor a dos caracteres");
            _ManGrillaPaging.frm.find("#txtValorBuscar").focus();
            return false;
        }

        _ManGrillaPaging.dtManGrillaPaging.ajax.reload();
    }
}
//Actualizar listado de registros
_ManGrillaPaging.fnRefresh = function () {
    _ManGrillaPaging.frm.find("#txtValorBuscar").val("");
    _ManGrillaPaging.frm.find("#ddlOpcionBuscarId").val($(_ManGrillaPaging.frm.find("#ddlOpcionBuscarId")[0].childNodes[0]).val()).trigger('change.select2');
    _ManGrillaPaging.dtManGrillaPaging.context[0].aaSorting = [];
    _ManGrillaPaging.dtManGrillaPaging.context[0].aLastSort = [];

    _ManGrillaPaging.dtManGrillaPaging.ajax.reload();
}

/***************************************
**Almacenar en la memoria local la configuración de los formularios respecto al _ManGrillaPaging
****************************************/
_ManGrillaPaging.fnReadConfigManGrillaPaging = function () {
    if (window.sessionStorage) {
        //Cargar las configuraciones existentes
        var lstConfig = [], config = {}, index = -1;
        if (JSON.parse(sessionStorage.getItem('ListConfig_ManGrillaPaging')) == null) {
            sessionStorage.setItem('ListConfig_ManGrillaPaging', JSON.stringify(lstConfig));
        }
        lstConfig = JSON.parse(sessionStorage.getItem('ListConfig_ManGrillaPaging'));
        //Crear o actualizar la configuración del formulario consultado
        config = {
            TipoFormulario: _ManGrillaPaging.frm.find("#tipoFormulario").val(),
            OpcionBuscar: _ManGrillaPaging.frm.find("#ddlOpcionBuscarId").val(),
            ValorBuscar: _ManGrillaPaging.frm.find("#txtValorBuscar").val(),
            PageLength: _ManGrillaPaging.dtManGrillaPaging.context[0]._iDisplayLength,
            RowStart: _ManGrillaPaging.dtManGrillaPaging.context[0]._iDisplayStart,
            ColumnOrder: _ManGrillaPaging.dtManGrillaPaging.context[0].aaSorting[0]
        };
        index = lstConfig.findIndex(m=>m.TipoFormulario == _ManGrillaPaging.frm.find("#tipoFormulario").val());
        if (index != -1) { lstConfig[index] = config; }
        else { lstConfig.push(config); }
        sessionStorage.setItem('ListConfig_ManGrillaPaging', JSON.stringify(lstConfig));
    }
}

/*------Inicializar y mostrar la Vista General del Formulario (listado de registros)-----------
--columns_label: ['lbl_1','lbl_2','lbl_3',..] Títulos de las columnas
--columns_event: ['fn_1()','fn_2()','fn_3()',..] Mostrar acceso al detalle del registro, pasar "" en caso no se trate de un acceso 
--columns_data: ['dat_1','dat_2','dat_3',...] Variables asociadas a las columnas;
--options:
    options: Configuraciones personalizadas del DataTable                       |   value: Object               | default: {}
    options.row_edit: Habilitar opción editar                                   |   value: {true, false}        | default: false
    options.row_fnEdit: Función editar                                          |   value: fn()                 | default: ''
    options.row_index: Muestra el índice de la fila                             |   value: {true, false}        | default: false
    options.row_data_index: En caso el valor se obtenga desde el servidor       |   value: [Column Data]        | default: ''
    options.row_name_index: En caso el valor se obtenga en el mismo cliente     |   value: [Column Name]        | default: 'ROW_INDEX'
    options.page_length: Número de filas a mostrar por página                   |   value: Int                  | default: 25
    options.data_extend: Columnas adicionales, formato DataTable                |   value: Object[]             | default: null
    options.page_paging: Paginación del lado del servidor                       |   value: {true, false}        | default: false
*/
_ManGrillaPaging.fnInit = function (columns_label, columns_data, options) {
    _ManGrillaPaging.frm = $("#frmManGrillaPaging");

    $.fn.select2.defaults.set("theme", "bootstrap4");
    _ManGrillaPaging.frm.find("#ddlOpcionBuscarId").select2({ minimumResultsForSearch: -1 });
    _ManGrillaPaging.frm.find("#txtValorBuscar").focus();
    $('[data-toggle="tooltip"]').tooltip();

    _ManGrillaPaging.frm.find("#ddlOpcionBuscarId").change(function () {
        setTimeout(function () {
            $('.select2-container-active').removeClass('select2-container-active');
            _ManGrillaPaging.frm.find("#txtValorBuscar").focus();
        }, 1);
    });

    _ManGrillaPaging.frm.submit(function (e) {
        e.preventDefault();
        _ManGrillaPaging.fnSearch();
    });

    utilDt.fnLoadDataTable_Detail($("#tbManGrillaPaging"), columns_label, columns_data, options);
    _ManGrillaPaging.dtManGrillaPaging = _ManGrillaPaging.fnInitDataTablePaging(options);
}