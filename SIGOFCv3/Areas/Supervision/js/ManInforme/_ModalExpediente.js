"use strict";

$(function () {
    cargarTabla();
});


var buscarExpediente = function () {
    let cCodificacion = $('#COD_INFORME').val().trim();
    if (cCodificacion === '') {
        utilSigo.toastWarning("Aviso", "Ingrese Exepediente");
        return;
    }
    let repeat = ManInforme_AddEdit.Denuncia.tablaExpedienteData.find(val => val.cCodificacion.trim() === cCodificacion.trim());
    if (repeat !== undefined) {
        utilSigo.toastWarning("Aviso", "Ya se ingreso el Expediente");
        return;
    }
    var option = {
        url: urlLocalSigo + "Supervision/ManInforme/ConsultarExpediente",
        datos: JSON.stringify({ cCodificacion }),
        type: 'POST'
    };
    utilSigo.fnAjax(option, function (data) {
        if (data.iCodTramite !== -1) {
            ManInforme_AddEdit.Denuncia.tablaExpedienteData.push(data);
            $('#COD_INFORME').val('');
            reCargarTabla();
        }
        else {
            utilSigo.toastWarning("Aviso", "No Existe Expediente");
        }
    });
};

var reCargarTabla = function () {
    var expediente = '';
    ManInforme_AddEdit.Denuncia.tablaExpediente.clear();
    $.each(ManInforme_AddEdit.Denuncia.tablaExpedienteData, function (index, value) {
        ManInforme_AddEdit.Denuncia.tablaExpediente.row.add(value);
        expediente += value.cCodificacion.trim() + ",";
    });
    $('#inptExpediente').val(expediente.substring(0, expediente.length - 1));
    $('#lblExpediente').html('Expedientes (' + ManInforme_AddEdit.Denuncia.tablaExpedienteData.length + ')');
    ManInforme_AddEdit.Denuncia.tablaExpediente.draw();
};

var cargarTabla = function () {
    ManInforme_AddEdit.Denuncia.tablaExpediente = $('#grvExpedientes').DataTable({
        oLanguage: initSigo.oLanguage,
        dom: 'rtip',
        bInfo: true,
        responsive: true,
        pageLength: initSigo.pageLengthBuscar,
        data: ManInforme_AddEdit.Denuncia.tablaExpedienteData,
        drawCallback: function (settings) {
            $('[data-toggle="tooltip"]').tooltip();
        },
        columns: [
            {
                render: function (data, type, row) {
                    return '<a href="https://sitd.osinfor.gob.pe:8443/std/cInterfaseUsuario_SITD/registroDetalles.php?iCodTramite=' + row.iCodTramite + '" target="_blank" title="Detalle del Trámite" rev="width: 970px; height: 550px; scrolling: auto; border:no">' + row.cCodificacion.trim() + '</a>';
                }, title: "Nº Trámite"
            },
            { data: "fFecDocumento", name: "fFecDocumento", title: "Fecha Documento" },
            {
                render: function (data, type, row) {
                    return row.cDescTipoDoc + '</br>' + row.cNroDocumento;
                }, title: "Documento"
            },
            {
                render: function (data, type, row) {
                    return '<a data-toggle="tooltip" data-placement="top" title="' + row.cAsunto + '" >' + row.cAsunto.substr(0, 40) + '...' + '</a>';
                }, title: "Asunto"
            },
            {
                render: function (data, type, row) {
                    let strButton = '<button class="btn btn-danger btn-xs btn-edit" type="button" onClick="EliminarExpediente(\'' + row.iCodTramite + '\')">Eliminar</button>';
                    return strButton;
                }, title: "Acciones"
            },
        ], columnDefs: [
            { responsivePriority: 1, targets: 0 },
            { responsivePriority: 2, targets: -1 },
            { className: "text-center", targets: "_all", orderable: false }
        ]
    });
    ManInforme_AddEdit.Denuncia.tablaExpediente.columns.adjust();
};


var EliminarExpediente = function (iCodTramite) {
    ManInforme_AddEdit.Denuncia.tablaExpedienteData =
        ManInforme_AddEdit.Denuncia.tablaExpedienteData.filter(
            tramite => {
                return tramite.iCodTramite.toString() !== iCodTramite.toString();
            });
    reCargarTabla();
};

