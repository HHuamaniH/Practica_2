var _VincularTHabilitante = {};
_VincularTHabilitante.opc;

_VincularTHabilitante.fnSaved = function (obj) { /*Implementar en donde se instancia*/ };

_VincularTHabilitante.fnBuscarTH = function () {
    var valorBusqueda = _VincularTHabilitante.frm.find("#txtValor").val().trim();

    if (valorBusqueda == "") {
        utilSigo.toastWarning("Aviso", "Ingrese Valor a Buscar");
        return false;
    }
    else {
        var cantCarateres = valorBusqueda.length;
        if (cantCarateres < 3) {
            utilSigo.toastWarning("Aviso", "Longitud del criterio de busqueda debe ser mayor a dos caracteres");
            return false;
        }

        var url = urlLocalSigo + "Supervision/ReporteVigilancia/GetTHabilitante";
        var params = { codbuscar: _VincularTHabilitante.frm.find("#ddlOpcId").val(), txtvalor: valorBusqueda };
        var option = { url: url, datos: JSON.stringify(params), type: 'POST' };

        utilSigo.fnAjax(option, function (data) {
            if (data.success) {
                _VincularTHabilitante.dtTHabilitante.clear().draw();
                _VincularTHabilitante.dtTHabilitante.rows.add(data.data).draw();
            }
            else {
                utilSigo.toastWarning("Aviso", "Sucedio un error, Comuníquese con el Administrador");
                console.log(data.msjError);
            }
        });
    }
};

_VincularTHabilitante.fnGetListTHVinculado = function () {
    var list = [], rows, countFilas, data;

    rows = ValidarHallazgo.dtTHabilitanteVinculado.$("tr");
    countFilas = rows.length;
    if (countFilas > 0) {
        $.each(rows, function (i, o) {
            data = ValidarHallazgo.dtTHabilitanteVinculado.row($(o)).data();
            list.push(utilSigo.fnConvertArrayToObject(data));
        });
    }
    return list;
};

_VincularTHabilitante.fnSelecionar = function (obj) {
    var row = _VincularTHabilitante.dtTHabilitante.row($(obj).parents('tr')).data();

    if (_VincularTHabilitante.opc == "THVinculado") {
        var listTHVinculado = _VincularTHabilitante.fnGetListTHVinculado();

        var band = 0;

        for (let item of listTHVinculado) {
            if (item.COD_THABILITANTE == row.COD_THABILITANTE) {
                band = 1;
                break;
            }
        }

        if (band == 1) {
            utilSigo.toastWarning("Aviso", "El Título Habilitante ya existe en la lista de vinculados");
            return false;
        }
    }

    _VincularTHabilitante.fnSaved(row);
};

_VincularTHabilitante.fnInitDataTable_Detail = function () {
    var columns_label = ["N°", "Modalidad", "Nro. THabilitante", "Titular", "R. Legal", "Región", ""];
    var columns_data = [
        {
            "name": "ROW_INDE", "width": "2%", "orderable": false, "searchable": false, "mRender": function (data, type, row, meta) {
                return parseInt(meta.row) + 1 + meta.settings._iDisplayStart;
            }
        },
        { "data": "MODALIDAD", "autoWidth": true },
        { "data": "THABILITANTE", "autoWidth": true },
        { "data": "TITULAR", "autoWidth": true },
        { "data": "RLEGAL", "autoWidth": true },
        { "data": "REGION", "autoWidth": true },
        {
            "data": "", "width": "2%", "orderable": false, "searchable": false, "mRender": function (data, type, row) {
                return '<div><i class="fa fa-lg fa-check" style="cursor:pointer;color:green;" onclick="_VincularTHabilitante.fnSelecionar(this)"></i>';
            }
        }
    ];

    var optDt = { iLength: 10, iStart: 0, aSort: [] };
    //**Cabecera**----
    var theadTable = "<tr>";
    for (var i = 0; i < columns_label.length; i++) {
        theadTable += '<th>' + columns_label[i] + '</th>';
    }
    theadTable += "</tr>";
    $("#tbTHabilitante").find("thead").append(theadTable);

    _VincularTHabilitante.dtTHabilitante = $("#tbTHabilitante").DataTable({
        processing: true,
        ServerSide: true,
        searching: false,
        bLengthChange: false,
        ordering: false,
        paging: true,
        bInfo: true,
        aaSorting: optDt.aSort,
        pageLength: optDt.iLength,
        displayStart: optDt.iStart,
        oLanguage: initSigo.oLanguage,
        drawCallback: initSigo.showPagination,
        columns: columns_data
    });
};

_VincularTHabilitante.fnInitEventos = function () {
    //_VincularTHabilitante.frm.find("#ddlOpcId").val(_VincularTHabilitante.frm.find("#ddlOpcId option:first").val());

    _VincularTHabilitante.frm.submit(function (e) {
        e.preventDefault();
        _VincularTHabilitante.fnBuscarTH();
    });
};

_VincularTHabilitante.fnInit = function (opc) {
    _VincularTHabilitante.frm = $("#frmBuscarTH");
    _VincularTHabilitante.opc = opc;

    //_VincularTHabilitante.fnInitEventos();
    _VincularTHabilitante.fnInitDataTable_Detail();
};