var ValidarObligacion = {};
ValidarObligacion.idTipoObligacion;
ValidarObligacion.DataSenial = [];
ValidarObligacion.DataHallazgo = [];
ValidarObligacion.DataArchivoDenuncia = [];
ValidarObligacion.DataArchivoOtros = [];
ValidarObligacion.DataArchivo = [];

ValidarObligacion.fnLoadData = function (obj, tipo) {
    switch (tipo) {
        case "DataSenial": ValidarObligacion.DataSenial = obj; break;
        case "DataHallazgo": ValidarObligacion.DataHallazgo = obj; break;
        case "DataArchivoDenuncia": ValidarObligacion.DataArchivoDenuncia = obj; break;
        case "DataArchivoOtros": ValidarObligacion.DataArchivoOtros = obj; break;
        case "DataArchivo": ValidarObligacion.DataArchivo = obj; break;
    }
};

ValidarObligacion.regresar = function () {
    var url = urlLocalSigo + "THabilitante/ManObligaciones/Index";
    window.location = url;
};

ValidarObligacion.fnSaveForm = function () {
    let nU_OBLIGACION_BUSQUEDA = parseInt(ValidarObligacion.frm.find("#hdfTipoObligacionId").val());
    let nU_ESTADO_BUSQUEDA = parseInt(ValidarObligacion.frm.find("#ddlEstadoId").val());
    let nV_CODIGO_BUSQUEDA = ValidarObligacion.frm.find("#hdfCodObligacion").val();
    let nV_OBSERVACION = ValidarObligacion.frm.find("#txtobservacion").val();

    if (nU_ESTADO_BUSQUEDA == 2) {
        $('a[href="#navEstado"]').tab('show');
        utilSigo.toastError("Aviso", "Seleccione el estado del registro");
        ValidarObligacion.frm.find("#ddlEstadoId").focus();
        return false;
    }
    else if (nU_ESTADO_BUSQUEDA == 4) {
        if (utilSigo.ValidaTexto("txtobservacion", "Ingrese observación") == false) {
            $('a[href="#navEstado"]').tab('show');
            ValidarObligacion.frm.find("#txtobservacion").focus();
            return false;
        }
    }

    let model = { nU_OBLIGACION_BUSQUEDA, nU_ESTADO_BUSQUEDA, nV_CODIGO_BUSQUEDA, nV_OBSERVACION };

    utilSigo.dialogConfirm("", "¿Está seguro de procesar los datos?", function (r) {
        if (r) {
            let url = urlLocalSigo + "THabilitante/ManObligaciones/Procesar";
            let option = { url: url, datos: JSON.stringify(model), type: 'POST' };
            utilSigo.fnAjax(option, function (data) {
                if (data.success) {
                    utilSigo.toastSuccess("Éxito", data.msj);
                    setTimeout(function () {
                        ValidarObligacion.regresar();
                    }, 1500);
                }
                else {
                    utilSigo.toastWarning("Aviso", "Sucedio un error, Comuníquese con el Administrador");
                    console.log(data.msj);
                }
            });
        }
    });
};

ValidarObligacion.fnDownload = function (obj, opc) {
    var row;

    switch (opc) {
        case "Senial":
            row = ValidarObligacion.dtSenial.row($(obj).parents('tr')).data().objArchivo;
            break;

        case "Hallazgo":
            row = ValidarObligacion.dtHallazgo.row($(obj).parents('tr')).data().objArchivo;
            break;

        case "ArchivoDenuncia":
            row = ValidarObligacion.dtArchivoDenuncia.row($(obj).parents('tr')).data();
            break;

        case "ArchivoOtros":
            row = ValidarObligacion.dtArchivoOtros.row($(obj).parents('tr')).data();
            break;

        case "Archivo":
            row = ValidarObligacion.dtArchivo.row($(obj).parents('tr')).data();
            break;
    }

    let url = urlLocalSigo + "THabilitante/ManObligaciones/isExistFile";
    let option = { url: url, datos: JSON.stringify({ nombreArchivo: row.id + "_" + row.vaNombreArchivo }), type: 'POST' };

    utilSigo.fnAjax(option, function (data) {
        if (data.success) {
            fetch(data.msj)
                .then(res => res.blob())
                .then(blob => {
                    const filtePath = window.URL.createObjectURL(blob);
                    const downloadLink = document.createElement('a');
                    downloadLink.href = filtePath;
                    downloadLink.setAttribute('download', row.vaNombreArchivo);
                    document.body.appendChild(downloadLink);
                    downloadLink.click();
                });
        }
        else {
            utilSigo.toastWarning("Aviso", "Sucedio un error, Comuníquese con el Administrador");
            console.log(data.msj);
        }
    });
};

ValidarObligacion.fnGetTipoSenial = function (tipo) {
    var result="";

    switch (tipo) {
        case "1":
            result = "Lindero";
            break;

        case "2":
            result = "Hito";
            break;

        case "3":
            result = "Vértice";
            break;

        case "4":
            result = "Letrero";
            break;

        case "5":
            result = "Otros";
            break;
    }

    return result;
};

ValidarObligacion.fnInitDataTable_Senial = function () {
    var columns_label = [], columns_data = [];

    columns_label = ["", "N°", "Tipo de señal", "Zona", "Coordenada Este", "Coordenada Norte", "Descripción"];
    columns_data = [
        {
            "data": "", "width": "2%", "orderable": false, "searchable": false, "mRender": function (data, type, row) {
                if (row.objArchivo != null) {
                    return '<div><i class="fa fa-lg fa-download" style="cursor: pointer;color:dodgerblue;" title="Descargar" onclick="ValidarObligacion.fnDownload(this,\'Senial\')"></i>';
                }
                else {
                    return '';
                }
            }
        },
        { "name": "ROW_INDEX", "width": "2%", "orderable": false, "searchable": false, "defaultContent": "" },
        {
            "data": "", "autoWidth": true, "mRender": function (data, type, row) {
                return ValidarObligacion.fnGetTipoSenial(row.vaNombreCategoria);
            }
        },
        { "data": "vaZonaUTM", "autoWidth": true },
        { "data": "inCoordenadaEste", "autoWidth": true },
        { "data": "inCoordenadaNorte", "autoWidth": true },
        { "data": "vaDescripcion", "autoWidth": true }
    ];

    //**Cabecera**----
    var theadTable = "<tr>";
    for (var i = 0; i < columns_label.length; i++) {
        theadTable += '<th>' + columns_label[i] + '</th>';
    }
    theadTable += "</tr>";
    $("#tbSenial").find("thead").append(theadTable);

    var optDt = { iLength: 20, aSort: [] };

    ValidarObligacion.dtSenial = ValidarObligacion.frm.find("#tbSenial").DataTable({
        processing: true,
        ServerSide: false,
        bFilter: false,
        bLengthChange: false,
        ordering: true,
        paging: true,
        bInfo: true,
        aaSorting: optDt.aSort,
        pageLength: optDt.iLength,
        oLanguage: initSigo.oLanguage,
        drawCallback: initSigo.showPagination,
        columns: columns_data
    });

    ValidarObligacion.dtSenial.rows.add(JSON.parse(ValidarObligacion.DataSenial)).draw();
    utilSigo.enumTB(ValidarObligacion.dtSenial, 1);
};

ValidarObligacion.fnInitDataTable_Hallazgo = function () {
    var columns_label = [], columns_data = [];

    columns_label = ["", "N°", "Tipo de afectación o nombre de especie forestal", "Zona", "Coordenada Este", "Coordenada Norte"];
    columns_data = [
        {
            "data": "", "width": "2%", "orderable": false, "searchable": false, "mRender": function (data, type, row) {
                if (row.objArchivo != null) {
                    return '<div><i class="fa fa-lg fa-download" style="cursor: pointer;color:dodgerblue;" title="Descargar" onclick="ValidarObligacion.fnDownload(this,\'Hallazgo\')"></i>';
                }
                else {
                    return '';
                }
            }
        },
        { "name": "ROW_INDEX", "width": "2%", "orderable": false, "searchable": false, "defaultContent": "" },
        { "data": "vaDescripcion", "autoWidth": true },
        { "data": "vaZonaUTM", "autoWidth": true },
        { "data": "inCoordenadaEste", "autoWidth": true },
        { "data": "inCoordenadaNorte", "autoWidth": true }
    ];

    //**Cabecera**----
    var theadTable = "<tr>";
    for (var i = 0; i < columns_label.length; i++) {
        theadTable += '<th>' + columns_label[i] + '</th>';
    }
    theadTable += "</tr>";
    $("#tbHallazgo").find("thead").append(theadTable);

    var optDt = { iLength: 20, aSort: [] };

    ValidarObligacion.dtHallazgo = ValidarObligacion.frm.find("#tbHallazgo").DataTable({
        processing: true,
        ServerSide: false,
        bFilter: false,
        bLengthChange: false,
        ordering: true,
        paging: true,
        bInfo: true,
        aaSorting: optDt.aSort,
        pageLength: optDt.iLength,
        oLanguage: initSigo.oLanguage,
        drawCallback: initSigo.showPagination,
        columns: columns_data
    });

    ValidarObligacion.dtHallazgo.rows.add(JSON.parse(ValidarObligacion.DataHallazgo)).draw();
    utilSigo.enumTB(ValidarObligacion.dtHallazgo, 1);
};

ValidarObligacion.fnInitDataTable_ArchivoDenuncia = function () {
    var columns_label = [], columns_data = [];

    columns_label = ["", "N°", "Tipo de archivo", "Nombre"];
    columns_data = [
        {
            "data": "", "width": "2%", "orderable": false, "searchable": false, "mRender": function (data, type, row) {
                return '<div><i class="fa fa-lg fa-download" style="cursor: pointer;color:dodgerblue;" title="Descargar" onclick="ValidarObligacion.fnDownload(this,\'ArchivoDenuncia\')"></i>';
            }
        },
        { "name": "ROW_INDEX", "width": "2%", "orderable": false, "searchable": false, "defaultContent": "" },
        {
            "data": "", "autoWidth": true, "mRender": function (data, type, row) {
                return row.vaNombreArchivo.split('.').pop();
            }
        },
        { "data": "vaNombreArchivo", "autoWidth": true }
    ];

    //**Cabecera**----
    var theadTable = "<tr>";
    for (var i = 0; i < columns_label.length; i++) {
        theadTable += '<th>' + columns_label[i] + '</th>';
    }
    theadTable += "</tr>";
    $("#tbArchivoDenuncia").find("thead").append(theadTable);

    var optDt = { iLength: 20, aSort: [] };

    ValidarObligacion.dtArchivoDenuncia = ValidarObligacion.frm.find("#tbArchivoDenuncia").DataTable({
        processing: true,
        ServerSide: false,
        bFilter: false,
        bLengthChange: false,
        ordering: true,
        paging: true,
        bInfo: true,
        aaSorting: optDt.aSort,
        pageLength: optDt.iLength,
        oLanguage: initSigo.oLanguage,
        drawCallback: initSigo.showPagination,
        columns: columns_data
    });

    ValidarObligacion.dtArchivoDenuncia.rows.add(JSON.parse(ValidarObligacion.DataArchivoDenuncia)).draw();
    utilSigo.enumTB(ValidarObligacion.dtArchivoDenuncia, 1);
};

ValidarObligacion.fnInitDataTable_ArchivoOtros = function () {
    var columns_label = [], columns_data = [];

    columns_label = ["", "N°", "Tipo de archivo", "Nombre"];
    columns_data = [
        {
            "data": "", "width": "2%", "orderable": false, "searchable": false, "mRender": function (data, type, row) {
                return '<div><i class="fa fa-lg fa-download" style="cursor: pointer;color:dodgerblue;" title="Descargar" onclick="ValidarObligacion.fnDownload(this,\'ArchivoOtros\')"></i>';
            }
        },
        { "name": "ROW_INDEX", "width": "2%", "orderable": false, "searchable": false, "defaultContent": "" },
        {
            "data": "", "autoWidth": true, "mRender": function (data, type, row) {
                return row.vaNombreArchivo.split('.').pop();
            }
        },
        { "data": "vaNombreArchivo", "autoWidth": true }
    ];

    //**Cabecera**----
    var theadTable = "<tr>";
    for (var i = 0; i < columns_label.length; i++) {
        theadTable += '<th>' + columns_label[i] + '</th>';
    }
    theadTable += "</tr>";
    $("#tbArchivoOtros").find("thead").append(theadTable);

    var optDt = { iLength: 20, aSort: [] };

    ValidarObligacion.dtArchivoOtros = ValidarObligacion.frm.find("#tbArchivoOtros").DataTable({
        processing: true,
        ServerSide: false,
        bFilter: false,
        bLengthChange: false,
        ordering: true,
        paging: true,
        bInfo: true,
        aaSorting: optDt.aSort,
        pageLength: optDt.iLength,
        oLanguage: initSigo.oLanguage,
        drawCallback: initSigo.showPagination,
        columns: columns_data
    });

    ValidarObligacion.dtArchivoOtros.rows.add(JSON.parse(ValidarObligacion.DataArchivoOtros)).draw();
    utilSigo.enumTB(ValidarObligacion.dtArchivoOtros, 1);
};

ValidarObligacion.fnInitDataTable_Archivo = function () {
    var columns_label = [], columns_data = [];

    columns_label = ["", "N°", "Tipo de foto", "Breve descripción o código", "Tipo de archivo", "Nombre"];
    columns_data = [
        {
            "data": "", "width": "2%", "orderable": false, "searchable": false, "mRender": function (data, type, row) {
                return '<div><i class="fa fa-lg fa-download" style="cursor: pointer;color:dodgerblue;" title="Descargar" onclick="ValidarObligacion.fnDownload(this,\'Archivo\')"></i>';
            }
        },
        { "name": "ROW_INDEX", "width": "2%", "orderable": false, "searchable": false, "defaultContent": "" },
        {
            "data": "vaNombreCategoria", "autoWidth": true, "visible": (ValidarObligacion.idTipoObligacion == "3") ? true : false },
        { "data": "vaDescripcion", "autoWidth": true, "visible": (ValidarObligacion.idTipoObligacion == "3") ? true : false},
        {
            "data": "", "autoWidth": true, "mRender": function (data, type, row) {
                return row.vaNombreArchivo.split('.').pop();
            }
        },
        { "data": "vaNombreArchivo", "autoWidth": true }
    ];

    //**Cabecera**----
    var theadTable = "<tr>";
    for (var i = 0; i < columns_label.length; i++) {
        theadTable += '<th>' + columns_label[i] + '</th>';
    }
    theadTable += "</tr>";
    $("#tbArchivo").find("thead").append(theadTable);

    var optDt = { iLength: 20, aSort: [] };

    ValidarObligacion.dtArchivo = ValidarObligacion.frm.find("#tbArchivo").DataTable({
        processing: true,
        ServerSide: false,
        bFilter: false,
        bLengthChange: false,
        ordering: true,
        paging: true,
        bInfo: true,
        aaSorting: optDt.aSort,
        pageLength: optDt.iLength,
        oLanguage: initSigo.oLanguage,
        drawCallback: initSigo.showPagination,
        columns: columns_data
    });

    ValidarObligacion.dtArchivo.rows.add(JSON.parse(ValidarObligacion.DataArchivo)).draw();
    utilSigo.enumTB(ValidarObligacion.dtArchivo, 1);
};

ValidarObligacion.fnFiltrarEstado = function (value) {
    if (value == "4") {
        $("#dvObservacion").show();
    }
    else {
        $("#dvObservacion").hide();
        ValidarObligacion.frm.find("#txtobservacion").val("");
    }
};

ValidarObligacion.fnInitEventos = function () {
    ValidarObligacion.frm.find("#txtfechaenviado").datepicker({ format: "dd/mm/yyyy", autoclose: true, language: 'es' });

    var estado = ValidarObligacion.frm.find("#ddlEstadoId").val();
    ValidarObligacion.fnFiltrarEstado(estado);

    if (estado == "2") {
        $('a[href="#navEstado"]').tab('show');
    }
    else {
        $("#lblTitulo").text("Registro procesado");
        $('a[href="#navDatos"]').tab('show');
        ValidarObligacion.frm.find("#ddlEstadoId").attr("disabled", true);
        ValidarObligacion.frm.find("#txtobservacion").attr("disabled", true);
        $("#btnGuardar").hide();
    }

    switch (ValidarObligacion.idTipoObligacion) {
        case "1":/** Informe de ejecución **/
            ValidarObligacion.frm.find("#txtfechaARFFS").datepicker({ format: "dd/mm/yyyy", autoclose: true, language: 'es' });
            ValidarObligacion.frm.find("#txtfechaOSINFOR").datepicker({ format: "dd/mm/yyyy", autoclose: true, language: 'es' });
            break;

        case "2":/** Regente Forestal **/
            ValidarObligacion.frm.find("#txtfechaini").datepicker({ format: "dd/mm/yyyy", autoclose: true, language: 'es' });
            ValidarObligacion.frm.find("#txtfechafin").datepicker({ format: "dd/mm/yyyy", autoclose: true, language: 'es' });
            ValidarObligacion.frm.find("#txtfechacese").datepicker({ format: "dd/mm/yyyy", autoclose: true, language: 'es' });

            if (ValidarObligacion.frm.find("#hdfCese").val() == "0") {
                $("#dvCese").hide();
            }
            break;

        case "3":/** Libro de Operación **/
            if (ValidarObligacion.frm.find("#ddlFormaRegistroId").val() != "4") {
                $("#dvOtroSistema").hide();
            }

            $("#dvTbArchivo").attr("class", "col-md-12");
            break;
    
        case "4":/** Custodio Forestal **/
            $("#idNavHallazgo").show();
            $("#idNavDenuncia").show();
            ValidarObligacion.frm.find("#txtfechapatrullaje").datepicker({ format: "dd/mm/yyyy", autoclose: true, language: 'es' });
            break;

        case "5":/** Contrato con tercero **/
            ValidarObligacion.frm.find("#txtfechaini").datepicker({ format: "dd/mm/yyyy", autoclose: true, language: 'es' });
            ValidarObligacion.frm.find("#txtfechafin").datepicker({ format: "dd/mm/yyyy", autoclose: true, language: 'es' });
            ValidarObligacion.frm.find("#txtfechacese").datepicker({ format: "dd/mm/yyyy", autoclose: true, language: 'es' });

            if (ValidarObligacion.frm.find("#hdfCese").val() == "0") {
                $("#dvCese").hide();
            }
            break;

        case "6":/** Linderos, hitos u Otros **/
            $("#idNavArchivos").hide();
            break;

        case "7":/** Garantía de fiel cumplimiento **/
            ValidarObligacion.frm.find("#txtfechaini").datepicker({ format: "dd/mm/yyyy", autoclose: true, language: 'es' });
            ValidarObligacion.frm.find("#txtfechafin").datepicker({ format: "dd/mm/yyyy", autoclose: true, language: 'es' });
            break;

        case "8":/** Movilización de frutos, productos y sub productos **/
            ValidarObligacion.frm.find("#txtfechagtfprimera").datepicker({ format: "dd/mm/yyyy", autoclose: true, language: 'es' });
            ValidarObligacion.frm.find("#txtfechagtfultima").datepicker({ format: "dd/mm/yyyy", autoclose: true, language: 'es' });
            break;

        case "9":/** Marcados de Trozas y Tocones **/
            if (ValidarObligacion.frm.find("#hdfCodificacionTrozas").val() == "1") {
                $("#dvNoCodificado").hide();

                if (ValidarObligacion.frm.find("#hdfOtroTipoMaterial").val() == "0") {
                    $("#dvOtroTipoMadera").hide();
                }
            }
            else {
                $("#dvCodificado").hide();
                $("#dvOtroTipoMadera").hide();
                $("#idNavArchivos").hide();
            } 
            break;

        case "10":/** Medidas Correctivas **/
            ValidarObligacion.frm.find("#txtfechaplazo").datepicker({ format: "dd/mm/yyyy", autoclose: true, language: 'es' });

            if (ValidarObligacion.frm.find("#hdfTipoMedida").val() == "1") {
                $("#dvDescripcion").hide();
            }
            else {
                $("#dvNumResolucion").hide();
                $("#dvFechaPlazo").hide();
            }
            break;

        case "11":/** Actos Administrativos **/
            $("#idNavOtros").show();
            ValidarObligacion.frm.find("#txtfechaini").datepicker({ format: "dd/mm/yyyy", autoclose: true, language: 'es' });
            ValidarObligacion.frm.find("#txtfechafin").datepicker({ format: "dd/mm/yyyy", autoclose: true, language: 'es' });
            ValidarObligacion.frm.find("#txtfechaactadmin").datepicker({ format: "dd/mm/yyyy", autoclose: true, language: 'es' });
            break;
    }

    ValidarObligacion.frm.find("#ddlEstadoId").change(function () {
        ValidarObligacion.fnFiltrarEstado($(this).val());
    });
};

$(document).ready(function () {
    ValidarObligacion.frm = $("#frmValidarObligacion");

    $('[data-toggle="tooltip"]').tooltip();

    ValidarObligacion.idTipoObligacion = ValidarObligacion.frm.find("#hdfTipoObligacionId").val();
    ValidarObligacion.fnInitEventos();
    
    if (ValidarObligacion.idTipoObligacion != "6") {
        ValidarObligacion.fnInitDataTable_Archivo();
    }

    switch (ValidarObligacion.idTipoObligacion) {
        case "4":
            ValidarObligacion.fnInitDataTable_Hallazgo();
            ValidarObligacion.fnInitDataTable_ArchivoDenuncia();
            break;

        case "6":
            ValidarObligacion.fnInitDataTable_Senial();
            break;

        case "11":
            ValidarObligacion.fnInitDataTable_ArchivoOtros();
            break;
    }

    //console.log(ValidarObligacion.frm.find("#hdfCodObligacion").val());
});