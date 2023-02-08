"use strict";
var tablaExpediente = null;
var tablaExpedienteData = [];
var ManCorrecMandato_AddEdit = null;
var urlSubirArchivo = urlLocalSigo + "Supervision/ManCorrecMandato/SubirArchivo";

$(function () {
    //$('#REQUIEREPLAZO').value = false;
    $('#PLAZO_DIA').hide();
    $('#PLAZO_MES').hide();
    $('#diasLB').hide();
    $('#mesesLB').hide();
    cargarTabla();
    ManCorrecMandato_AddEdit = $("#frmManNotificacion_AddEdit");
    ui();
});

var ui = function () {
    $("#idArchivoInforme").change(function () {
        $('#lblArchivos').html(obtenerFilesNombres(this.files).substr(0, 40) + '...');
    });
}

var obtenerFilesNombres = function (archivos) {
    let concatNombres = '';
    for (let i = 0; i < archivos.length; i++) {
        concatNombres += archivos[i].name + ', ';
    }
    return concatNombres.substring(0, concatNombres.length - 2);
};


var buscarInforme = function () {
    let cCodificacion = $('#COD_INFORME').val().trim();
    let iCodTupaClase = '0';
    let iCodTupa = '0';
    let iCodTramite = '0';
    if (cCodificacion === '') {
        utilSigo.toastWarning("Aviso", "Ingrese Exepediente");
        return;
    }
    let repeat = tablaExpedienteData.find(val => val.cCodificacion.trim() === cCodificacion.trim());
    if (repeat !== undefined) {
        utilSigo.toastWarning("Aviso", "Ya se ingreso el Expediente");
        return;
    }
    var option = {
        url: urlLocalSigo + "Supervision/ManCorrecMandato/ConsultarExpediente",
        datos: JSON.stringify({ iCodTupa, iCodTupaClase, cCodificacion, iCodTramite }),
        type: 'POST'
    };
    utilSigo.fnAjax(option, function (data) {
        if (data.iCodTramite != "") {
            tablaExpedienteData.push(data);
            $('#COD_INFORME').val('');
            reCargarTabla();
        }
        else {
            utilSigo.toastWarning("Aviso", "No Existe Expediente");
        }
    });
}

var reCargarTabla = function () {
    var expediente = '';
    tablaExpediente.clear();
    $.each(tablaExpedienteData, function (index, value) {
        tablaExpediente.row.add(value);
        expediente += value.cCodificacion.trim() + ",";
    });
    $('#inptExpediente').val(expediente.substring(0, expediente.length - 1));
    $('#lblExpediente').html('Expedientes (' + tablaExpedienteData.length + ')');
    tablaExpediente.draw();
}

var cargarTabla = function () {
    tablaExpediente = $('#grvInformes').DataTable({
        oLanguage: initSigo.oLanguage,
        dom: 'rtip',
        bInfo: true,
        responsive: true,
        pageLength: initSigo.pageLengthBuscar,
        data: tablaExpedienteData,
        columns: [
            {
                render: function (data, type, row) {
                    return '<a href="https://sitd.osinfor.gob.pe:8443/std/cInterfaseUsuario_SITD/registroDetalles.php?iCodTramite=' + row.iCodTramite + '" target="_blank" title="Detalle del Trámite" rev="width: 970px; height: 550px; scrolling: auto; border:no">' + row.cCodificacion + '</a>';
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
                    return '<a title="' + row.cAsunto + '" >' + row.cAsunto.substr(0, 40) + '...' + '</a>';
                }, title: "Asunto"
            },
            {
                render: function (data, type, row) {
                    let strButton = '<button class="btn btn-danger btn-sm btn-edit" type="button" onClick="EliminarExpediente(\'' + row.iCodTramite + '\')">Eliminar</button>';
                    return strButton;
                }, title: "Eliminar"
            },
            {
                render: function (data, type, row) {
                    let strButton = '<button class="btn btn-success btn-sm btn-edit" type="button" onClick="guardaExpediente(\'' + row.iCodTramite + '\')">Agregar</button>';
                    return strButton;
                }, title: "Agregar"
            },
        ], columnDefs: [
            { responsivePriority: 1, targets: 0 },
            { responsivePriority: 2, targets: -1 },
            { className: "text-center", targets: "_all", orderable: false }
        ]
    });
    tablaExpediente.columns.adjust();
}

var EliminarExpediente = function (iCodTramite) {
    tablaExpedienteData =
        tablaExpedienteData.filter(
            tramite => {
                return tramite.iCodTramite.toString() !== iCodTramite.toString();
            });
    reCargarTabla();
}

var guardaExpediente = function (iCodTramite) {
    let archivo = $("#idArchivoInforme").get(0);
    var fileData = new FormData(); 
    $.each(archivo.files, function (indexArray, fileArray) {
        fileData.append(fileArray.name, fileArray, fileArray.name);
    });
    
    $.ajax({
        url: urlSubirArchivo,
        data: fileData,
        dataType: "json",
        type: "POST",
        contentType: false,
        processData: false,
        success: function (data) {
            console.log(data)
            
            let USUARIO = '0';
            let COD_RESODIREC = $('#COD_RESODIREC').val();
            let iTipo = '3';
            let iEstado = '0';
            let PLAZO_DIA = $('#PLAZO_DIA').val();
            let PLAZO_MES = $('#PLAZO_MES').val();
            let iCodMandato = $('#hdfidCodMandato').val();
            let URLNOMBRE = data.Archivos[0].URLNOMBRE;
            let URLDIGITAL = data.Archivos[0].URLDIGITAL;
            let ARCHIVO_EXTENSION = data.Archivos[0].ARCHIVO_EXTENSION;
            let ADJMANDATO = { URLNOMBRE, URLDIGITAL, ARCHIVO_EXTENSION };
            var option = {
                url: urlLocalSigo + "Supervision/ManCorrecMandato/guardarTramite",
                datos: JSON.stringify({ COD_RESODIREC, iCodTramite, USUARIO, iTipo, iEstado, PLAZO_DIA, PLAZO_MES, iCodMandato, ADJMANDATO}),
                type: 'POST'
            };
            EliminarExpediente(iCodTramite);
            utilSigo.fnAjax(option, function (data) {
                if (data.iCodTramite != -1) {
                    tablaExpedienteData.push(data);
                    $('#COD_INFORME').val('');
                    cargaDocsDosInfMa();
                }
            });
        }
    })

    //let USUARIO = '0';
    //let COD_RESODIREC = $('#COD_RESODIREC').val();
    //let iTipo = '3';
    //let iEstado = '0';
    //let PLAZO_DIA = $('#PLAZO_DIA').val();
    //let PLAZO_MES = $('#PLAZO_MES').val();
    //let iCodMandato = $('#hdfidCodMandato').val();
    //var option = {
    //    url: urlLocalSigo + "Supervision/ManCorrecMandato/guardarTramite",
    //    datos: JSON.stringify({ COD_RESODIREC, iCodTramite, USUARIO, iTipo, iEstado, PLAZO_DIA, PLAZO_MES, iCodMandato}),
    //    type: 'POST'
    //};
    //EliminarExpediente(iCodTramite);
    //utilSigo.fnAjax(option, function (data) {
    //    if (data.iCodTramite != -1) {
    //        tablaExpedienteData.push(data);
    //        $('#COD_INFORME').val('');
    //        cargaDocsDosInfMa();
    //    }
    //});
}


var fnREQUIEREPLAZO = function () {
    if ($('#REQUIEREPLAZO').is(":checked")) {
        $('#PLAZO_DIA').show();
        $('#PLAZO_MES').show();
        $('#diasLB').show();
        $('#mesesLB').show();
    }
    else {

        $('#PLAZO_DIA').hide();
        $('#PLAZO_MES').hide();
        $('#diasLB').hide();
        $('#mesesLB').hide();
    };
};
