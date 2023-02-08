"use strict";
var ManCorrecMandato_AddEdit = {};

ManCorrecMandato_AddEdit.DataMedidaCorrectiva = [];
ManCorrecMandato_AddEdit.DataMandato = [];

ManCorrecMandato_AddEdit.fnReturnIndex = function (alertaInicial) {
    var url = urlLocalSigo + "Supervision/manCorrecMandato/index";

    if (alertaInicial == null || alertaInicial == "") {
        window.location = url;
    } else {
        window.location = url + "?_alertaIncial=" + alertaInicial;
    }
};

ManCorrecMandato_AddEdit.fnLoadData = function (obj, tipo) {
    switch (tipo) {
        case "DataMedidaCorrectiva": ManCorrecMandato_AddEdit.DataMedidaCorrectiva = obj; break;
        case "DataMandato": ManCorrecMandato_AddEdit.DataMandato = obj; break;
    }
};

ManCorrecMandato_AddEdit.fnInitDataTable_Detail = function () {
    var columns_label = [], columns_data = [], options = {};

    //Cargar medidas correctivas
    columns_label = ["Resolución", "Medida", "Fecha Notificación", "Plazo Implementación"];
    columns_data = ["NUM_RESOLUCION_MEDIDA", "MEDIDA", "FECHA_NOTIFICACION", "PLAZO_IMPLEMENTACION"];
    options = {
        page_length: 10, row_index: true
    };
    ManCorrecMandato_AddEdit.dtMedidaCorrectiva = utilDt.fnLoadDataTable_Detail(ManCorrecMandato_AddEdit.frm.find("#grvMedidaCorrectivaDet"), columns_label, columns_data, options);
    ManCorrecMandato_AddEdit.dtMedidaCorrectiva.rows.add(JSON.parse(ManCorrecMandato_AddEdit.DataMedidaCorrectiva) || []).draw();

    //Cargar mandatos
    ManCorrecMandato_AddEdit.dtMandato = utilDt.fnLoadDataTable_Detail(ManCorrecMandato_AddEdit.frm.find("#grvMandatosDet"), columns_label, columns_data, options);
    ManCorrecMandato_AddEdit.dtMandato.rows.add(JSON.parse(ManCorrecMandato_AddEdit.DataMandato) || []).draw();
};

ManCorrecMandato_AddEdit.fnInit = function () {
    ManCorrecMandato_AddEdit.fnInitDataTable_Detail();
};

$(document).ready(function () {
    ManCorrecMandato_AddEdit.frm = $("#frmManCorrecMandato_AddEdit");

    ManCorrecMandato_AddEdit.fnInit();
});


var tablaExpedienteCab = null;
var tablaExpedienteDataCab = [];
var tablaExpedienteCabInf = null;
var tablaExpedienteDataCabInf = [];
var tablaMandatoCab = null;
var tablaMCCab = null;
var tablaMandatoDataCab = [];
var tablaMCDataCab = [];
var tablaExpedienteDetM = null;
var tablaExpedienteDataDetM = [];

var tablaExpedienteCabInfMa = null;
var tablaExpedienteDataCabInfMa = [];

var tablaExpedienteData = [];

//$(function () {
//    cargarMedidasCorrectivas();
//    cargaDocs();
//    cargaDocsInf(); // carga listado de supervisón del mc

//    cargarMandatos();
//    cargaDocsMa();
//    cargaDocsInfMa();
//    $("#panel").hide();
//});

var fnViewModalExpedientes = function () {
    var url = urlLocalSigo + "Supervision/ManCorrecMandato/_ItemNuevo";
    var option = {
        url: url,
        type: 'GET',
        datos: {},
        divId: "mdlManInforme_Expedientes"
    };
    utilSigo.fnOpenModal(option, function () {

    }, function () {
    });
};

var cargaDocs = function () {
    let COD_RESODIREC = $('#COD_RESODIREC').val();
    let iCodTramite = '0';
    let iTipo = '0';
    var option = {
        url: urlLocalSigo + "Supervision/ManCorrecMandato/selectExpedienteMC",
        datos: JSON.stringify({ COD_RESODIREC, iCodTramite, iTipo}),
        type: 'POST'
    };
    utilSigo.fnAjax(option, function (data) {
        if (data.iCodTramite != "") {
            tablaExpedienteDataCab = data;    
            $('#COD_INFORME').val('');
            cargarTablaCab();
        }
        else {
            utilSigo.toastWarning("Aviso", "No existen documentos vinculados.");
        }
    });
};

var cargaDocsDos = function () {
    let COD_RESODIREC = $('#COD_RESODIREC').val();
    let iCodTramite = '0';
    let iTipo = '0';
    var option = {
        url: urlLocalSigo + "Supervision/ManCorrecMandato/selectExpedienteMC",
        datos: JSON.stringify({ COD_RESODIREC, iCodTramite, iTipo }),
        type: 'POST'
    };
    utilSigo.fnAjax(option, function (data) {
        $('#COD_INFORME').val('');
        tablaExpedienteDataCab = data;
        tablaExpedienteCab.clear();
        $.each(tablaExpedienteDataCab, function (index, value) {
            tablaExpedienteCab.row.add(value);
        });
        tablaExpedienteCab.draw();
    });
};

function adjuntarArchivo(codExpediente) {
    $('#hiddentramite').val(codExpediente);
    var url = urlLocalSigo + "Supervision/ManCorrecMandato/_modalArchivo";
    var option = {
        url: url,
        type: 'GET',
        datos: {},
        divId: "modalAddArchivo"
    };
    utilSigo.fnOpenModal(option, function () { }, function () {
        cargaDocsDosInf();
        cargaDocsDosInfMa();
    });
};

var cargarTablaCab = function () {
    tablaExpedienteCab = $('#grvExpedientesDet').DataTable({
        oLanguage: initSigo.oLanguage,
        dom: 'rtip',
        bInfo: true,
        responsive: true,
        pageLength: initSigo.pageLengthBuscar,
        data: tablaExpedienteDataCab,
        columns: [
          
            { data: "fFecDocumento", name: "fFecDocumento", title: "Fecha Documento" },
            {
                render: function (data, type, row) {
                    return row.cDescTipoDoc + ' ' + row.cNroDocumento;
                }, title: "Documento"
            },
            {
                render: function (data, type, row) {
                    return '<a title="' + row.cAsunto + '" >' + row.cAsunto.substr(0, 100) + '...' + '</a>';
                }, title: "Asunto"
            },
            {
                render: function (data, type, row) {
                    return '<a href="' + row.sDescarga + '" target="_blank" title="Detalle del Trámite" rev="width: 970px; height: 550px; scrolling: auto; border:no">' + row.cNombreNuevo + '</a>';
                }, title: "Descargar"
            }
        ], columnDefs: [
            //{ responsivePriority: 1, targets: 0 },
            //{ responsivePriority: 2, targets: -1 },
            { className: "text-left", targets: "_all", orderable: false }
        ]
    });
    tablaExpedienteCab.columns.adjust();
};

//************************************************************
//************************************************************
//MEDIDAS CORRECTIVAS 
var cargarMedidasCorrectivas = function () {
    let COD_RESODIREC = $('#COD_RESODIREC').val();
    let iTipo = '0';
    var option = {
        url: urlLocalSigo + "Supervision/ManCorrecMandato/SP_SELECT_MEDIDAS_CORRECTIVAS",
        datos: JSON.stringify({ COD_RESODIREC, iTipo }),
        type: 'POST'
    };
    utilSigo.fnAjax(option, function (data) {
        if (data.iCodTramite != "") {
            tablaMCDataCab = data;
            $('#COD_INFORME').val('');
            cargarTablaCabMC();
        }
        else {
            utilSigo.toastWarning("Aviso", "No existen medidas correctivas.");
        }
    });
};

var cargarTablaCabMC = function () {
    tablaMCCab = $('#grvMedidaCorrectivaDet').DataTable({
        oLanguage: initSigo.oLanguage,
        dom: 'rtip',
        bInfo: true,
        responsive: true,
        pageLength: initSigo.pageLengthBuscar,
        data: tablaMCDataCab,
        columns: [
            {
                render: function (data, type, row) {
                    return row.DESCRIPCION_MED_CORRECTIVAS;
                }, title: "MEDIDA CORRECTIVA"
            },
            {
                render: function (data, type, row) {
                    return row.FECHA_INI;
                }, title: "DESDE"
            },
            {
                render: function (data, type, row) {
                    return row.FECHA_FIN;
                }, title: "HASTA"
            },
            {
                render: function (data, type, row) {
                    return row.FECHA_FIN2;
                }, title: "HASTA + 15"
            },
            {
                render: function (data, type, row) {
                    let strButton = '<button class="fa fa-check" style="font-size:11pt; padding:0; color:green;" title="Ver detalle" type="button" onClick="detalleMC(\'' + row.iCodMC + '\',1)"></button>';
                    return strButton;
                }, title: "RE"
            },

        ], columnDefs: [
            { responsivePriority: 1, targets: 0 },
            { responsivePriority: 2, targets: -1 },
            { className: "text-left", targets: "_all", orderable: false }
        ]
    });
    tablaMCCab.columns.adjust();
};

var detalleMC = function (iCodMC) {
    $('#hdfidCodMC').val(iCodMC);
    //cargaDocsDosInfMa(); //llena detalle de supervision del MC
    cargaDocsDosInf(iCodMC);
    $("#panel").show();
};


//***************************************************************
//***************************************************************
var fnViewModalInformes = function () {
    var url = urlLocalSigo + "Supervision/ManCorrecMandato/_modalInf";
    var option = {
        url: url,
        type: 'GET',
        datos: {},
        divId: "mdlManInforme_Expedientes"
    };
    utilSigo.fnOpenModal(option, function () {

    }, function () {
    });
};

var cargaDocsInf = function () {
    let COD_RESODIREC = $('#COD_RESODIREC').val();
    let iCodTramite = '0';
    let iTipo = '1';
    let iCodMandato = $('#hdfidCodMC').val();
    var option = {
        url: urlLocalSigo + "Supervision/ManCorrecMandato/selectExpedienteMC",
        datos: JSON.stringify({ COD_RESODIREC, iCodTramite, iTipo, iCodMandato }),
        type: 'POST'
    };
    utilSigo.fnAjax(option, function (data) {
        if (data.iCodTramite != "") {
            tablaExpedienteDataCabInf = data;
            $('#COD_INFORME').val('');
            cargarTablaCabInf();
        }
        else {
            utilSigo.toastWarning("Aviso", "No existen informes vinculados.");
        }
    });
};

var cargaDocsDosInf = function () {
    let COD_RESODIREC = $('#COD_RESODIREC').val();
    let iCodTramite = '0';
    let iTipo = '1';
    let iCodMandato = $('#hdfidCodMC').val();
    var option = {
        url: urlLocalSigo + "Supervision/ManCorrecMandato/selectExpedienteMC",
        datos: JSON.stringify({ COD_RESODIREC, iCodTramite, iTipo, iCodMandato }),
        type: 'POST'
    };
    utilSigo.fnAjax(option, function (data) {
        $('#COD_INFORME').val('');
        tablaExpedienteDataCabInf = data;
        tablaExpedienteCabInf.clear();
        $.each(tablaExpedienteDataCabInf, function (index, value) {
            tablaExpedienteCabInf.row.add(value);
        });
        tablaExpedienteCabInf.draw();
    });
};

var cargarTablaCabInf = function () {
    tablaExpedienteCabInf = $('#grvEvaluacionDet').DataTable({
        oLanguage: initSigo.oLanguage,
        dom: 'rtip',
        bInfo: true,
        responsive: true,
        pageLength: initSigo.pageLengthBuscar,
        data: tablaExpedienteDataCabInf,
        columns: [
            {
                render: function (data, type, row) {
                    return '<button class="btn btn-primary btn-xs btn-edit" type="button" ' +
                        'onClick="adjuntarArchivo(\'' + row.COD_EXPEDIENTE + '\')">Adjuntar Archivo</button> ';
                }, title: "Acciones"
            },
            { data: "fFecDocumento", name: "fFecDocumento", title: "Fecha Documento" },
            {
                render: function (data, type, row) {
                    return row.cDescTipoDoc + ' ' + row.cNroDocumento;
                }, title: "Documento"
            },
            {
                render: function (data, type, row) {
                    return '<a title="' + row.cAsunto + '" >' + row.cAsunto.substr(0, 100) + '...' + '</a>';
                }, title: "Asunto"
            },
            {
                render: function (data, type, row) {
                    return row.PLAZO_MES;
                }, title: "Meses"
            },
            {
                render: function (data, type, row) {
                    return row.PLAZO_DIA;
                }, title: "Días"
            },
            {
                render: function (data, type, row) {
                    return '<a href="#" onClick="descargar(\'' + row.sDescarga + '\',\'' + row.DESCARGA + '\',\'' + row.COD_RESODIREC + '\')" title="Detalle del Trámite" rev="width: 970px; height: 550px; scrolling: auto; border:no">' + row.DESCARGA + '</a>';
                 }, title: "Descargar"
            },
            {
                render: function (data, type, row) {
                    return row.nomEstado;
                }, title: "Estado"
            },
            //{
            //    render: function (data, type, row) {
            //        let strButton = '<button class="btn btn-link" style="font-size:8pt; padding:0;"  type="button" onClick="changeEstado(\'' + row.COD_EXPEDIENTE + '\')">' + row.nomEstado + '</button>';
            //        return strButton;
            //    }, title: "Agregar"
            //},
            //{
            //    render: function (data, type, row) {
            //        let strButton = '<button class="fa fa-check" style="font-size:11pt; padding:0; color:green;" title="Aprueba Plazos"  type="button" onClick="changeApruebaRechaza(\'' + row.COD_EXPEDIENTE + '\',2,\'' + row.iEstado + '\',\'' + row.PLAZO_MES + '\',\'' + row.PLAZO_DIA + '\')"></button>';
            //        return strButton;
            //    }, title: "AP"
            //},
            //{
            //    render: function (data, type, row) {
            //        let strButton = '<button class="fa fa-times" style="font-size:11pt; padding:0; color:red;" title="Rechaza Plazos" type="button" onClick="changeApruebaRechaza(\'' + row.COD_EXPEDIENTE + '\',3,\'' + row.iEstado + '\',\'' + row.PLAZO_MES + '\',\'' + row.PLAZO_DIA + '\')"></button>';
            //        return strButton;
            //    }, title: "RE"
            //},

        ], columnDefs: [
            { responsivePriority: 1, targets: 0 },
            { responsivePriority: 2, targets: -1 },
            { className: "text-left", targets: "_all", orderable: false }
        ]
    });
    tablaExpedienteCabInf.columns.adjust();
};

var descargar = function (url, NOMBRE_ARCHIVO, ARCHIVO_EXTENSION) {
    var url1 = urlLocalSigo + "Supervision/ManCorrecMandato/descargarArchivo?ruta=" + url + "&nombre=" + NOMBRE_ARCHIVO + "&mineType=" + ARCHIVO_EXTENSION;
    window.open(url1, "_blank");
};

var changeEstado = function (expediente) {
    var url = urlLocalSigo + "Supervision/ManCorrecMandato/_modalFisca?hdfidCodTramite=" + expediente;
    var option = {
        url: url,
        type: 'GET',
        datos: {},
        divId: "mdlManInforme_Expedientes"
    };
    utilSigo.fnOpenModal(option, function () {
    }, function () {
    });
};

var changeApruebaRechaza = function (iCodTramite, iEstado, estadoCod, mes, dia) {
    if (mes == "0" && dia == "0") {
        utilSigo.toastWarning("Solo para estado : PENDIENTE");
    }
    else {
        if (estadoCod == "0") {

            if (!confirm('¿Cambiar de estado de registro?')) {
                return false;
            }
            else {
                let USUARIO = '0';
                var option = {
                    url: urlLocalSigo + "Supervision/ManCorrecMandato/cambioEtadoTramite",
                    datos: JSON.stringify({ iCodTramite, USUARIO, iEstado }),
                    type: 'POST'
                };
                utilSigo.fnAjax(option, function (data) {
                    if (data.iCodTramite != -1) {
                        tablaExpedienteData.push(data);
                        $('#COD_INFORME').val('');
                        cargaDocsDosInf();
                    }
                });
            }
        }
        else {
            utilSigo.toastWarning("Solo para estado : PENDIENTE");
        }
    }
}

//************************************************************
//************************************************************
var cargarMandatos = function () {
    let COD_RESODIREC = $('#COD_RESODIREC').val();
    let iTipo = '0';
    var option = {
        url: urlLocalSigo + "Supervision/ManCorrecMandato/SP_SELECT_MANDATOS",
        datos: JSON.stringify({ COD_RESODIREC, iTipo }),
        type: 'POST'
    };
    utilSigo.fnAjax(option, function (data) {
        if (data.iCodTramite != "") {
            tablaMandatoDataCab = data;
            $('#COD_INFORME').val('');
            cargarTablaCabMandatos();
        }
        else {
            utilSigo.toastWarning("Aviso", "No existen mandatos.");
        }
    });
};

var cargarTablaCabMandatos = function () {
    tablaMandatoCab = $('#grvMandatosDet').DataTable({
        oLanguage: initSigo.oLanguage,
        dom: 'rtip',
        bInfo: true,
        responsive: true,
        pageLength: initSigo.pageLengthBuscar,
        data: tablaMandatoDataCab,
        columns: [
            {
                render: function (data, type, row) {
                    return row.MANDATO;
                }, title: "Mandato"
            },
            {
                render: function (data, type, row) {
                    return row.FECHA_INI;
                }, title: "DESDE"
            },
            {
                render: function (data, type, row) {
                    return row.FECHA_FIN;
                }, title: "HASTA"
            },
            {
                render: function (data, type, row) {
                    let strButton = '<button class="fa fa-check" style="font-size:11pt; padding:0; color:green;" title="Ver detalle" type="button" onClick="detalleMandato(\'' + row.ICODMANDATO + '\',3)"></button>';
                    return strButton;
                }, title: "RE"
            },

        ], columnDefs: [
            { responsivePriority: 1, targets: 0 },
            { responsivePriority: 2, targets: -1 },
            { className: "text-left", targets: "_all", orderable: false }
        ]
    });
    tablaMandatoCab.columns.adjust();
};


var detalleMandato = function (iCodMandato) {
    $('#hdfidCodMandato').val(iCodMandato);
    cargaDocsDosInfMa();
    $("#panel").show();
};
//************************************************************
//************************************************************

var fnViewModalMandatos = function () {
    var url = urlLocalSigo + "Supervision/ManCorrecMandato/_ItemExpMandato";
    var option = {
        url: url,
        type: 'GET',
        datos: {},
        divId: "mdlManInforme_Expedientes"
    };
    utilSigo.fnOpenModal(option, function () {

    }, function () {
    });
};

var cargaDocsMa = function () {
    let COD_RESODIREC = $('#COD_RESODIREC').val();
    let iCodTramite = '0';
    let iTipo = '2';
    var option = {
        url: urlLocalSigo + "Supervision/ManCorrecMandato/selectExpedienteMC",
        datos: JSON.stringify({ COD_RESODIREC, iCodTramite, iTipo }),
        type: 'POST'
    };
    utilSigo.fnAjax(option, function (data) {
        if (data.iCodTramite != "") {
            tablaExpedienteDataDetM = data;
            $('#COD_INFORME').val('');
            cargarTablaCabMa();
        }
        else {
            utilSigo.toastWarning("Aviso", "No existen documentos vinculados.");
        }
    });
};

var cargaDocsMaDos = function () {
    let COD_RESODIREC = $('#COD_RESODIREC').val();
    let iCodTramite = '0';
    let iTipo = '2';
    var option = {
        url: urlLocalSigo + "Supervision/ManCorrecMandato/selectExpedienteMC",
        datos: JSON.stringify({ COD_RESODIREC, iCodTramite, iTipo }),
        type: 'POST'
    };
    utilSigo.fnAjax(option, function (data) {
        $('#COD_INFORME').val('');
        tablaExpedienteDataDetM = data;
        tablaExpedienteDetM.clear();
        $.each(tablaExpedienteDataDetM, function (index, value) {
            tablaExpedienteDetM.row.add(value);
        });
        tablaExpedienteDetM.draw();
    });
};

var cargarTablaCabMa = function () {
    tablaExpedienteDetM = $('#grvExpedientesMandato').DataTable({
        oLanguage: initSigo.oLanguage,
        dom: 'rtip',
        bInfo: true,
        responsive: true,
        pageLength: initSigo.pageLengthBuscar,
        data: tablaExpedienteDataDetM,
        columns: [
            { data: "fFecDocumento", name: "fFecDocumento", title: "Fecha Documento" },
            {
                render: function (data, type, row) {
                    return row.cDescTipoDoc + ' ' + row.cNroDocumento;
                }, title: "Documento"
            },
            {
                render: function (data, type, row) {
                    return '<a title="' + row.cAsunto + '" >' + row.cAsunto.substr(0, 100) + '...' + '</a>';
                }, title: "Asunto"
            },
            {
                render: function (data, type, row) {
                    return '<a href="' + row.sDescarga + '" target="_blank" title="Detalle del Trámite" rev="width: 970px; height: 550px; scrolling: auto; border:no">' + row.cNombreNuevo + '</a>';
                }, title: "Descargar"
            },

        ], columnDefs: [
            { responsivePriority: 1, targets: 0 },
            { responsivePriority: 2, targets: -1 },
            { className: "text-left", targets: "_all", orderable: false }
        ]
    });
    tablaExpedienteDetM.columns.adjust();
};
//************************************************************
//************************************************************
var fnViewModalInformesMandato = function () {
    var url = urlLocalSigo + "Supervision/ManCorrecMandato/_modalInfMa";
    var option = {
        url: url,
        type: 'GET',
        datos: {},
        divId: "mdlManInforme_Expedientes"
    };
    utilSigo.fnOpenModal(option, function () {

    }, function () {
    });
};

var cargaDocsInfMa = function () {
    let COD_RESODIREC = $('#COD_RESODIREC').val();
    let iCodTramite = '0';
    let iTipo = '3';
    let iCodMandato = $('#hdfidCodMandato').val();
    var option = {
        url: urlLocalSigo + "Supervision/ManCorrecMandato/selectExpedienteMC",
        datos: JSON.stringify({ COD_RESODIREC, iCodTramite, iTipo, iCodMandato }),
        type: 'POST'
    };
    utilSigo.fnAjax(option, function (data) {
        if (data.iCodTramite != "") {
            tablaExpedienteDataCabInfMa = data;
            $('#COD_INFORME').val('');
            cargarTablaCabInfMa();
        }
        else {
            utilSigo.toastWarning("Aviso", "No existen informes vinculados.");
        }
    });
};

var cargaDocsDosInfMa = function () {
    let COD_RESODIREC = $('#COD_RESODIREC').val();
    let iCodTramite = '0';
    let iTipo = '3';
    let iCodMandato = $('#hdfidCodMandato').val();
    var option = {
        url: urlLocalSigo + "Supervision/ManCorrecMandato/selectExpedienteMC",
        datos: JSON.stringify({ COD_RESODIREC, iCodTramite, iTipo, iCodMandato }),
        type: 'POST'
    };
    utilSigo.fnAjax(option, function (data) {
        $('#COD_INFORME').val('');
        tablaExpedienteDataCabInfMa = data;
        tablaExpedienteCabInfMa.clear();
        $.each(tablaExpedienteDataCabInfMa, function (index, value) {
            tablaExpedienteCabInfMa.row.add(value);
        });
        tablaExpedienteCabInfMa.draw();
    });
};

var cargarTablaCabInfMa = function () {
    tablaExpedienteCabInfMa = $('#grvInformesMandato').DataTable({
        oLanguage: initSigo.oLanguage,
        dom: 'rtip',
        bInfo: true,
        responsive: true,
        pageLength: initSigo.pageLengthBuscar,
        data: tablaExpedienteDataCabInfMa,
        columns: [
            {
                render: function (data, type, row) {
                    return '<button class="btn btn-primary btn-xs btn-edit" type="button" ' +
                        'onClick="adjuntarArchivo(\'' + row.COD_EXPEDIENTE + '\')">Adjuntar Archivo</button> ';
                }, title: "Acciones"
            },
            { data: "fFecDocumento", name: "fFecDocumento", title: "Fecha Documento" },
            {
                render: function (data, type, row) {
                    return row.cDescTipoDoc + ' ' + row.cNroDocumento;
                }, title: "Documento"
            },
            {
                render: function (data, type, row) {
                    return '<a title="' + row.cAsunto + '" >' + row.cAsunto.substr(0, 100) + '...' + '</a>';
                }, title: "Asunto"
            },
            {
                render: function (data, type, row) {
                    return row.PLAZO_MES;
                }, title: "Meses"
            },
            {
                render: function (data, type, row) {
                    return row.PLAZO_DIA;
                }, title: "Días"
            },
            {
                render: function (data, type, row) {
                    return '<a href="#" onClick="descargar(\'' + row.sDescarga + '\',\'' + row.DESCARGA + '\',\'' + row.COD_RESODIREC + '\')" title="Detalle del Trámite" rev="width: 970px; height: 550px; scrolling: auto; border:no">' + row.DESCARGA + '</a>';
                }, title: "Descargar"
            },
            {
                render: function (data, type, row) {
                    return row.nomEstado;
                }, title: "Estado"
            },
            //{
            //    render: function (data, type, row) {
            //        let strButton = '<button class="fa fa-check" style="font-size:11pt; padding:0; color:green;" title="Aprueba Plazos"  type="button" onClick="changeApruebaRechaza(\'' + row.COD_EXPEDIENTE + '\',2)"></button>';
            //        return strButton;
            //    }, title: "AP"
            //},
            //{
            //    render: function (data, type, row) {
            //        let strButton = '<button class="fa fa-times" style="font-size:11pt; padding:0; color:red;" title="Rechaza Plazos" type="button" onClick="changeApruebaRechaza(\'' + row.COD_EXPEDIENTE + '\',3)"></button>';
            //        return strButton;
            //    }, title: "RE"
            //},

        ], columnDefs: [
            { responsivePriority: 1, targets: 0 },
            { responsivePriority: 2, targets: -1 },
            { className: "text-left", targets: "_all", orderable: false }
        ]
    });
    tablaExpedienteCabInfMa.columns.adjust();
};
