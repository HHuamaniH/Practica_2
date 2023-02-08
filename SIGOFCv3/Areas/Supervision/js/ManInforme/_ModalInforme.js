"use strict";

$(function () {
    ui();
    cargarTablaInforme();
});

var ui = function () {
    $("#idArchivoInforme").change(function () {
        $('#lblArchivos').html(obtenerFilesNombres(this.files).substr(0, 40) + '...');
    });
};

var insertarInforme = function () {
    let archivo = $("#idArchivoInforme").get(0);
    let nombreInforme = $("#inputInforme").val().trim();
    let archivosInput = $("#lblArchivos");
    let nombreLblArchivo = archivosInput.text();
    let lenghtArchivo = archivo.files.length;
    if (lenghtArchivo === 0) {
        utilSigo.toastWarning("Aviso", "Seleccione un Archivo");
        return;
    }
    if (nombreLblArchivo === 'Sin Archivos') {
        utilSigo.toastWarning("Aviso", "Seleccione un Archivo");
        return;
    }
    if (nombreInforme === '') {
        utilSigo.toastWarning("Aviso", "Ingrese Nombre Informe");
        return;
    }
    let IDENUNCIA_ITECNICO = {
        id_falso: tramiteDenuncia.tablaInformeData.length + 1,
        COD_IDENUNCIA_ITECNICO: obtenrId(),
        NOMBRE_INFORME: nombreInforme,
        IDENUNCIA_ITECNICO_ARCHIVOS: archivo.files,
        B_FLAG: false,
        Tipo: 'I'
    };
    tramiteDenuncia.tablaInformeData.push(IDENUNCIA_ITECNICO);
    $("#inputInforme").val('');
    archivosInput.html('Sin Archivos');
    reCargarTabla();
};

var obtenrId = function () {
    let count = 1;
    tramiteDenuncia.tablaInformeData.forEach(
        (value) => {
            if (!value.B_FLAG) { count++; }
        });
    return count;
};

var obtenerFilesNombres = function (archivos) {
    let concatNombres = '';
    for (let i = 0; i < archivos.length; i++) {
        concatNombres += archivos[i].name +', ';
    }
    return concatNombres.substring(0, concatNombres.length - 2); 
};

var obtenerArchivosNombres = function (row) {
    let concatNombres = '';
    if (row.B_FLAG) {
        $.each(row.IDENUNCIA_ITECNICO_ARCHIVOS, function (index, value) {
            concatNombres += value.NOMBRE_ARCHIVO + ', ';
        });
    } else {
        $.each(row.IDENUNCIA_ITECNICO_ARCHIVOS, function (index, value) {
            concatNombres += value.name + ', ';
        });
    }
    return concatNombres.substring(0, concatNombres.length - 2);
};

var reCargarTabla = function () {
    tramiteDenuncia.tablaInforme.clear();
    $.each(tramiteDenuncia.tablaInformeData, function (index, value) {
        tramiteDenuncia.tablaInforme.row.add(value);
    });
    tramiteDenuncia.tablaInforme.draw();
};

var cargarTablaInforme = function () {
    tramiteDenuncia.tablaInforme = $('#grvInforme').DataTable({
        oLanguage: initSigo.oLanguage,
        dom: 'rtip',
        bInfo: true,
        responsive: true,
        pageLength: initSigo.pageLengthBuscar,
        data: tramiteDenuncia.tablaInformeData,
        drawCallback: function (settings) {
            $('[data-toggle="tooltip"]').tooltip();
        },
        columns: [
            { data: "id_falso", name: "id_falso", title: "#" },
            { data: "COD_IDENUNCIA_ITECNICO", name: "COD_IDENUNCIA_ITECNICO", title: "Codigo", visible: false },
            { data: "NOMBRE_INFORME", name: "NOMBRE_INFORME", title: "Nombre informe" },
            {
                render: function (data, type, row) {
                    let info = obtenerArchivosNombres(row);
                    return '<a data-toggle="tooltip" data-placement="top" title="' + info + '">' + utilSigo.recortarTextos(info, 40) + '</a>';
                }, title: "Archivos"
            },
            {
                render: function (data, type, row) {
                    return '<button class="btn btn-danger btn-xs btn-edit" type="button" ' +
                        'onClick="EliminarInforme(\'' + row.COD_IDENUNCIA_ITECNICO + '\')">Eliminar</button> ';
                }, title: "Acciones"
            }
        ],
        columnDefs: [
            { responsivePriority: 1, targets: 0 },
            { responsivePriority: 2, targets: -2 },
            { className: "text-center", targets: "_all", orderable: false }
        ]
    });
};

var EliminarInforme = function (ID) {
    tramiteDenuncia.tablaInformeData =
        tramiteDenuncia.tablaInformeData.filter(
            tramite => {
                return tramite.COD_IDENUNCIA_ITECNICO.toString() !== ID.toString();
            });
    let count = 1;
    let countFalso = 1;
    tramiteDenuncia.tablaInformeData.forEach(
        (value) => {
            value.id_falso = countFalso++
            if (!value.B_FLAG) {
                value.COD_IDENUNCIA_ITECNICO = count++;
            }
        });
    reCargarTabla();
};