"use strict";
var ExSitu = {};
ExSitu.BA = {};
ExSitu.BB = {}; 
ExSitu.fnMostrarModal = function (div, urlModal, datos) {     
    var option = { url: urlModal, type: 'GET', datos: datos, divId: div, keyboard: false };    
    utilSigo.fnOpenModal(option);    
}
ExSitu.fnReloadTbEsituAnual = function () {
    var codPManejo = ExSitu.contenedor.find("#codPm").val();     
    var url = urlLocalSigo + "THabilitante/ManPlanManejo/GetAllExSituOpcion" + "?codPM=" + codPManejo +"&busCriterio=1";
    ExSitu.dtEsituAnual.ajax.url(url).load(function (data) {
        if (data.success == false) {
            utilSigo.toastError("Error", initSigo.MessageError);
            console.log(data.msjError);
        }
    });
}
ExSitu.fnReloadTbEsituGenetico = function () {
    var codPManejo = ExSitu.contenedor.find("#codPm").val();
    var url = urlLocalSigo + "THabilitante/ManPlanManejo/GetAllExSituOpcion" + "?codPM=" + codPManejo + "&busCriterio=2";
    ExSitu.dtEsituGenetico.ajax.url(url).load(function (data) {
        if (data.success == false) {
            utilSigo.toastError("Error", initSigo.MessageError);
            console.log(data.msjError);
        }
    });
}
ExSitu.fnReloadTbEsituIngreso = function () {
    var codPManejo = ExSitu.contenedor.find("#codPm").val();
    var url = urlLocalSigo + "THabilitante/ManPlanManejo/GetAllExSituOpcion" + "?codPM=" + codPManejo + "&busCriterio=3";
    ExSitu.dtEsituIngreso.ajax.url(url).load(function (data) {
        if (data.success == false) {
            utilSigo.toastError("Error", initSigo.MessageError);
            console.log(data.msjError);
        }
    });
}
ExSitu.fnReloadTbEsituEgreso = function () {
    var codPManejo = ExSitu.contenedor.find("#codPm").val();
    var url = urlLocalSigo + "THabilitante/ManPlanManejo/GetAllExSituOpcion" + "?codPM=" + codPManejo + "&busCriterio=4";
    ExSitu.dtEsituEgreso.ajax.url(url).load(function (data) {
        if (data.success == false) {
            utilSigo.toastError("Error", initSigo.MessageError);
            console.log(data.msjError);
        }
    });
}
ExSitu.fnConfigTabla = function (columns) {
    return {
        "bServerSide": false,
        "deferLoading": 0,
        "bAutoWidth": false,
        "bProcessing": true,
        "bJQueryUI": false,
        "bFilter": false,
        "aaSorting": [],
        "bPaginate": true,
        "bInfo": false,
        "bLengthChange": false,
        "pageLength": initSigo.pageLength,
        "oLanguage": initSigo.oLanguage,
        "drawCallback": initSigo.showPagination,
        "columns": columns
    }
}
ExSitu.regresar = function () {
    var url = urlLocalSigo + "THabilitante/ManPlanManejo/Index";
    window.location = url;
}
ExSitu.fnAddEditSituANual = function (estado, codSec) {
    var url = urlLocalSigo + "THabilitante/ManPlanManejo/_ItemESituIAnual";
    var codPManejo = ExSitu.contenedor.find("#codPm").val();
  
    ExSitu.fnMostrarModal("modalItemESituIAnual", url, { es: estado, codPM: codPManejo, codSec: codSec });
}
ExSitu.fnAddEditSituPgenetico = function (estado, codSec) {
    var url = urlLocalSigo + "THabilitante/ManPlanManejo/_ItemESituPGenetico";
    var codPManejo = ExSitu.contenedor.find("#codPm").val();

    ExSitu.fnMostrarModal("modalItemESituPgenetico", url, { es: estado, codPM: codPManejo, codSec: codSec });
}

ExSitu.fnAddEditSituBalance = function (estado, codSec,tipo) {
    var url = urlLocalSigo + "THabilitante/ManPlanManejo/_Balance";
    var codPManejo = ExSitu.contenedor.find("#codPm").val();
    ExSitu.fnMostrarModal("modalItemESituBalance", url, { es: estado, codPM: codPManejo, codSec: codSec,tipo:tipo });
}
ExSitu.fnAddEditSituBalanceG = function (obj) {
    var tr = $(obj).closest('tr');
    var estado = tr.find(".hdEstado").val();
    var codSec = tr.find(".hdSec").val();
    var tipo = tr.find(".hdTipo").val().trim();    
    ExSitu.fnAddEditSituBalance(estado, codSec, tipo);
}
ExSitu.fnDeleteExsitu = function (opcion, obj) {
    var $tr = $(obj).closest('tr');
    var row = ""; 
    var tipo = "";
    var codEs = "";
    switch (parseInt(opcion)) {
        case 1: row = ExSitu.dtEsituAnual.row($tr).data(); tipo = "A"; break;
        case 2: row = ExSitu.dtEsituGenetico.row($tr).data(); tipo = "G"; break;
        case 3: row = ExSitu.dtEsituIngreso.row($tr).data(); tipo = row.TIPO; codEs = row.COD_ESPECIES; break;
        case 4: row = ExSitu.dtEsituEgreso.row($tr).data(); tipo = row.TIPO; codEs = row.COD_ESPECIES;break;
    }
    var codPM = ExSitu.contenedor.find("#codPm").val();
    var codSecuencial = row.COD_SECUENCIAL;  
    if (row != "") {
        utilSigo.dialogConfirm('', 'Esta seguro de eliminar el item seleccionado?', function (r) {
            if (r) {
                var url = urlLocalSigo + "THabilitante/ManPlanManejo/DeleteExsitu";
                var dataEnviar = { codPM: codPM, codS: codSecuencial, tipo: tipo, codE: codEs };
                var option = { datos: dataEnviar, url: url };
                utilSigo.fnAjax(option, function (data) {
                    if (data.success) {
                        utilSigo.toastSuccess("Aviso", data.msj);
                        switch (parseInt(opcion)) {
                            case 1: ExSitu.fnReloadTbEsituAnual(); break;
                            case 2: ExSitu.fnReloadTbEsituGenetico(); break;
                            case 3: ExSitu.fnReloadTbEsituIngreso(); break;
                            case 4: ExSitu.fnReloadTbEsituEgreso(); break;
                        }
                    }
                    else {
                        utilSigo.toastWarning("Aviso", initSigo.MessageError);
                        console.log(data.msjError);      
                    }
                });
            }
        });       
    }     
}
ExSitu.fnIniciarTablas = function () {
    var columnTB = [
        {
            "autoWidth": true, "bSortable": false, "data": "ind",
            "mRender": function (data, type, row) {
                var cell = '<i class="fa mx-2 fa-lg fa-pencil-square-o cellEdit" title="Editar" onclick="ExSitu.fnAddEditSituANual(' + row.RegEstado + ',' + row.COD_SECUENCIAL+')"></i>';
                return cell;
            }
        },
        {
            "autoWidth": true, "bSortable": false, "data": "ind",
            "mRender": function (data, type, row) {
                var cell = '<i class="fa fa-lg fa-window-close cellDel" title="Eliminar" onclick="ExSitu.fnDeleteExsitu(1,this)" ></i > ';

                return cell;
            }
        },
        { "data": "ind", "autoWidth": true },
        { "data": "ANO_EJECUTADO", "autoWidth": true },
        { "data": "FECHA_EMISION", "autoWidth": true },
        { "data": "FECHA_RECEPCION", "autoWidth": true },
        { "data": "PROFESIONAL_NOMBRE", "autoWidth": true },
        { "data": "PROFESIONAL_NUM_REGISTRO_FFS", "autoWidth": true },
        { "data": "PROFESIONAL_NUM_REGISTRO_PROFESIONAL", "autoWidth": true },
        { "data": "ACORDE_TDR_VIGENTE", "autoWidth": true },
        { "data": "OBSERVACION", "autoWidth": true }
    ];
    ExSitu.dtEsituAnual = ExSitu.contenedor.find("#grvItemESituIAnual").DataTable(ExSitu.fnConfigTabla(columnTB));
    columnTB = [
        {
            "autoWidth": true, "bSortable": false, "sClass": "tdIcoconCenter", "data": "ind",
            "mRender": function (data, type, row) {
                var cell = '<i class="fa mx-2 fa-lg fa-pencil-square-o cellEdit" title="Editar" onclick="ExSitu.fnAddEditSituPgenetico(' + row.RegEstado + ',' + row.COD_SECUENCIAL + ')"></i>';
                return cell;
            }
        },
        {
            "autoWidth": true, "bSortable": false, "data": "ind",
            "mRender": function (data, type, row) {
                var cell = '<i class="fa fa-lg fa-window-close cellDel" title="Eliminar" onclick="ExSitu.fnDeleteExsitu(2,this)" ></i > ';

                return cell;
            }
        },
        { "data": "ind", "autoWidth": true },
        { "data": "ARESOLUCION_NUM", "autoWidth": true },
        { "data": "ARESOLUCION_FECHA", "autoWidth": true },
        { "data": "ARESOLUCION_FUNCIONARIO_NOMBRE", "autoWidth": true },
        { "data": "CARGO", "autoWidth": true },
        { "data": "OBSERVACION", "autoWidth": true }
         
    ];    
    ExSitu.dtEsituGenetico = ExSitu.contenedor.find("#grvItemPGeneticoFESitu").DataTable(ExSitu.fnConfigTabla(columnTB));
    columnTB = [
        {
            "autoWidth": true, "bSortable": false, "data": "ind",
            "mRender": function (data, type, row) {
                var cell = '<input type="hidden" class="hdEstado" value="' + row.RegEstado + '" />' +
                            '<input type="hidden" class="hdSec" value="' + row.COD_SECUENCIAL + '" />' +
                            '<input type="hidden" class="hdTipo" value="' + row.TIPO + '" />' +
                            '<i class="fa mx-2 fa-lg fa-pencil-square-o cellEdit" title = "Editar" onclick = "ExSitu.fnAddEditSituBalanceG(this)" ></i > ';
                return cell;
            }
        },
        {
            "autoWidth": true, "bSortable": false, "data": "ind",
            "mRender": function (data, type, row) {
                var cell = '<i class="fa fa-lg fa-window-close cellDel" title="Eliminar" onclick="ExSitu.fnDeleteExsitu(3,this)" ></i > ';

                return cell;
            }
        },
        { "data": "ind", "autoWidth": true },
        { "data": "ESPECIES", "autoWidth": true },
        { "data": "NUM_DOCUMENTO", "autoWidth": true },
        { "data": "MOTIVO", "autoWidth": true },
        { "data": "DOCUMENTO", "autoWidth": true },
        { "data": "NUM_SDOCUMENTO", "autoWidth": true },
        { "data": "FECHA_EMISION", "autoWidth": true },
        { "data": "FECHA_RECEPCION", "autoWidth": true },
        { "data": "OBSERVACION", "autoWidth": true }
    ];    
    ExSitu.dtEsituIngreso = ExSitu.contenedor.find("#grvbalance_ingreso").DataTable(ExSitu.fnConfigTabla(columnTB));
    columnTB = [
        {
            "autoWidth": true, "bSortable": false, "data": "ind",
            "mRender": function (data, type, row) {
                var cell = '<input type="hidden" class="hdEstado" value="' + row.RegEstado + '" />' +
                    '<input type="hidden" class="hdSec" value="' + row.COD_SECUENCIAL + '" />' +
                    '<input type="hidden" class="hdTipo" value="' + row.TIPO + '" />' +
                    '<i class="fa mx-2 fa-lg fa-pencil-square-o cellEdit" title = "Editar" onclick = "ExSitu.fnAddEditSituBalanceG(this)" ></i > ';
                return cell;
            }
        },
        {
            "autoWidth": true, "bSortable": false, "data": "ind",
            "mRender": function (data, type, row) {
                var cell = '<i class="fa fa-lg fa-window-close cellDel" title="Eliminar" onclick="ExSitu.fnDeleteExsitu(4,this)" ></i > ';

                return cell;
            }
        },
        { "data": "ind", "autoWidth": true },
        { "data": "ESPECIES", "autoWidth": true },
        { "data": "NUM_DOCUMENTO", "autoWidth": true },
        { "data": "MOTIVO", "autoWidth": true },
        { "data": "NUM_SDOCUMENTO", "autoWidth": true },
        { "data": "FECHA_EMISION", "autoWidth": true },
        { "data": "FECHA_RECEPCION", "autoWidth": true },
        { "data": "OBSERVACION", "autoWidth": true }
    ];    
    ExSitu.dtEsituEgreso = ExSitu.contenedor.find("#grvbalance_egreso").DataTable(ExSitu.fnConfigTabla(columnTB));
    ExSitu.fnReloadTbEsituAnual();
    ExSitu.fnReloadTbEsituGenetico();
    ExSitu.fnReloadTbEsituIngreso();
    ExSitu.fnReloadTbEsituEgreso();
}

ExSitu.fnIniciarEventos = function () {
    ExSitu.contenedor.find("#btnSituAnual").click(function () {
        ExSitu.fnAddEditSituANual(1, 0);
    });
    ExSitu.contenedor.find("#btnSituIngreso").click(function () {
        ExSitu.fnAddEditSituBalance(1, 0,"I");
    });
    ExSitu.contenedor.find("#btnSituEgreso").click(function () {
       
        ExSitu.fnAddEditSituBalance(1, 0, "E");
    });
    ExSitu.contenedor.find("#btnRegresarPME").click(function () {
        ExSitu.regresar();
    });
    ExSitu.contenedor.find("#btnSituPAgente").click(function () {
        ExSitu.fnAddEditSituPgenetico(1,0);
    });
}

ExSitu.fnSetTituloTablaInfPlanManejo = function () {
    var mod = ExSitu.contenedor.find("#thM").val();

    switch (mod) {
        case "Autorizaciones Fauna Silvestre Ex Situ – Zoológicos":
        case "Autorizaciones Fauna Silvestre Ex Situ - Zoocriaderos":
        case "Autorizaciones Fauna Silvestre Ex Situ – Centro de Rescate":
        case "Autorizaciones Fauna Silvestre Ex Situ – Centro de Custodia Temporal":
        case "Autorizaciones Fauna Silvestre Ex Situ – Centro de Conservación":
            $("#tituloInfPlanManejo").html("Presentación de informes de ejecución de plan de manejo");
            break;
        default: $("#tituloInfPlanManejo").html("Presentación de informes anuales");
            break;
    }
}

$(document).ready(function () {    
    ExSitu.contenedor = $("#divEditExSitu");
    ExSitu.fnSetTituloTablaInfPlanManejo();
    ExSitu.fnIniciarTablas();
    ExSitu.fnIniciarEventos();     
})