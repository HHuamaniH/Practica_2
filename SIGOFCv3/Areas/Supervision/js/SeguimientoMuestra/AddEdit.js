"use strict";
var addEditSD = {};
addEditSD.fnRegresar = function () {
    var url = urlLocalSigo + "Supervision/SeguimientoMuestra/Index";
    window.location.href = url;  
}
addEditSD.fnAsignarInforme = function (data) {
    addEditSD.frm.find("#desSupervision").val(data.NUMERO);
    addEditSD.frm.find("#codSupervision").val(data.COD_INF);
    addEditSD.frm.find("#desNotificacion").val(data.NUM_CNOTIF);
    addEditSD.frm.find("#desTHabilitante").val(data.NUM_TH);
    addEditSD.frm.find("#codTH").val(data.COD_TH); 
    utilSigo.toastSuccess("", "Se selecciono correctamente el informe");
    utilSigo.fnCloseModal("modalBuscarInformSupervision");    
}
addEditSD.fnAsignarSTID = function (data,op) {
    if (op == "DOC_SALIDA") {
        addEditSD.frm.find("#desTramEnvio").val(data.cCodificacion);
        addEditSD.frm.find("#codTramiteEnvio").val(data.iCodTramite);
        addEditSD.frm.find("#nroSITDEnvio").val(data.cNroDocumento);
        addEditSD.frm.find("#fechaSITDEnvio").val(data.fFecDocumento);
       // addEditSD.frm.find("#desSITDEnvio").val(data.cDescTipoDoc);
        addEditSD.frm.find("#asuntoSITDEnvio").val(data.cAsunto);
        addEditSD.frm.find("#pdf_id_tram_envio").val(data.PDF_TRAMITE_SITD);
    }
    else {
        addEditSD.frm.find("#desTramRespuesta").val(data.cCodificacion);
        addEditSD.frm.find("#codTramiteRespuesta").val(data.iCodTramite);
        addEditSD.frm.find("#nroSITDRes").val(data.cNroDocumento);
        addEditSD.frm.find("#fechaSITDERes").val(data.fFecDocumento);
       // addEditSD.frm.find("#desSITDRes").val(data.cDescTipoDoc);
        addEditSD.frm.find("#asuntoSITDRes").val(data.cAsunto);
        addEditSD.frm.find("#pdf_id_tram_respuesta").val(data.PDF_TRAMITE_SITD);
    }
    utilSigo.toastSuccess("", "Se selecciono correctamente el documento");
    utilSigo.fnCloseModal("modalBuscarDocSITD");
}
addEditSD.fnDownloadDocSITD = function (idControl) {
    var idArchivo = addEditSD.frm.find("#" + idControl).val().trim();
    if (idArchivo != "" && idArchivo != null) {        
        document.location = "https://sitd.osinfor.gob.pe:8443/std/cInterfaseUsuario_SITD/download.php?direccion=//10.10.8.20/sitd-almacen/cAlmacenArchivos/&file=" + idArchivo;
    }
    else {
        utilSigo.toastWarning("Aviso", "No existe archivo a descargar");
    }   
}
addEditSD.fnAddEditMuestra = function (secuencial, obj) {
    var urlModal = urlLocalSigo + "Supervision/SeguimientoMuestra/_AddEditMuestra";
    var seguimientoId = addEditSD.frm.find("#id").val(); 
    //nos aseguramos de que exista la cabecera
    if (seguimientoId.trim() != "" && seguimientoId.trim().length == 15) {
        
        if (secuencial != 0) { //editar
            var $tr = $(obj).closest('tr');
            var dataRow = addEditSD.dtMuestra.row($tr).data(); 
            var option = { url: urlModal, type: 'GET', datos: { cod: seguimientoId.trim(), sec: dataRow.COD_SECUENCIAL}, divId: "modalAddMuestraDen", keyboard: false };
            utilSigo.fnOpenModal(option); 
        }
        else {
            //nuevo
            var option = { url: urlModal, type: 'GET', datos: { cod: seguimientoId.trim(), sec: secuencial}, divId: "modalAddMuestraDen", keyboard: false };
            utilSigo.fnOpenModal(option);     
                      
        }
    }
    else {
        utilSigo.toastWarning("Aviso","No se pruede agregar la muestra. para poder continuar primero registre (Estado Situacional / Datos de Informe) ");
    }    
}
addEditSD.fnInitEventos = function () {
    addEditSD.frm.find("#btnBusInformeSup").click(function () {
        var url = urlLocalSigo + "Supervision/SeguimientoMuestra/_BuscarInformeSupervision"; 
        var option = { url: url, datos: {}, type: 'GET', divId: 'modalBuscarInformSupervision' };        
        utilSigo.fnOpenModal(option, function () {
            _bInformeMuestra.fnAsignarDatos = function (obj) {               
                if (obj != null && obj != "") {
                    var data = _bInformeMuestra.dt.row($(obj).parents('tr')).data();   
                    addEditSD.frm.find("#iconInforme").attr('style', 'display:none;');                    
                    addEditSD.fnAsignarInforme(data);
                }
            }
            _bInformeMuestra.fnInit();
        });
    });
    addEditSD.frm.find("#btnBusDocEnv").click(function () {
        var url = urlLocalSigo + "General/Controles/_ConsultaSITD";
        var option = { url: url, datos: { op: "DOC_SALIDA" }, type: 'GET', divId: 'modalBuscarDocSITD' };
        utilSigo.fnOpenModal(option, function () {
            _cSITD.fnAsignarDatos = function (obj) {
                if (obj != null && obj != "") {
                    var data = _cSITD.dt.row($(obj).parents('tr')).data();     
                    addEditSD.frm.find("#iconOficioEnv").attr('style', 'display:none;');  
                    addEditSD.fnAsignarSTID(data,"DOC_SALIDA");
                }
            }
            _cSITD.fnInit();
        });
    });
    addEditSD.frm.find("#btnBusDocRes").click(function () {
        var url = urlLocalSigo + "General/Controles/_ConsultaSITD";
        var option = { url: url, datos: { op: "DOC_ENTRADA" }, type: 'GET', divId: 'modalBuscarDocSITD' };
        utilSigo.fnOpenModal(option, function () {
            _cSITD.fnAsignarDatos = function (obj) {
                if (obj != null && obj != "") {
                    var data = _cSITD.dt.row($(obj).parents('tr')).data();                    
                    addEditSD.fnAsignarSTID(data, "DOC_ENTRADA");
                }
            }
            _cSITD.fnInit();
        });
    });
    addEditSD.frm.find("#btnAddMuestra").click(function () {
        addEditSD.fnAddEditMuestra(0, "");
    });
    addEditSD.frm.find("#btnDeleteAll").click(function () {
        addEditSD.fnDeleteMuestra(1, "");
    });    
    $("#btnRegistrarMuestraD").click(function () {
        if (addEditSD.fnValDatObligatorios()) {
            utilSigo.dialogConfirm('', 'Desea continuar con la operacion?', function (r) {
                if (r) {
                    addEditSD.fnguardarSeguimiento();
                }
            }); 
        }        
    });
}
addEditSD.fnguardarSeguimiento = function () {
    var datosSeguimiento = addEditSD.frm.serializeObject();
    //enviando datos al servidor
    $.ajax({
        url: urlLocalSigo + "Supervision/SeguimientoMuestra/AddEdit",
        type: 'POST',
        data: JSON.stringify(datosSeguimiento),
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function (data) {
            utilSigo.unblockUIGeneral();
            if (data.success) {
                var seguimientoId = addEditSD.frm.find("#id").val();
                if (seguimientoId.trim() != "" && seguimientoId.trim().length == 15) {
                    utilSigo.toastSuccess("Aviso", data.msj);
                }
                else {
                    var url = urlLocalSigo + "Supervision/SeguimientoMuestra/AddEdit?codSegMuestra=" + data.values[0];
                    window.location.href = url;
                }
            }
            else {
                utilSigo.toastWarning("Error", "Sucedio un error, Comuniquese con el Administrador");
                console.log(data.msj);
            }  
        },
        beforeSend: function () {
            utilSigo.blockUIGeneral();
        },
        error: function (jqXHR, error, errorThrown) {
            utilSigo.unblockUIGeneral();
            utilSigo.toastError("Error", "Sucedio un error, Comuniquese con el Administrador");
            console.log(jqXHR.responseText);
        }
    });
}
addEditSD.fnValDatObligatorios = function () {
    var valddlItemIndicadorId = addEditSD.frm.find("#ddlItemIndicadorId").val();   
    var valddlODRegistroId = addEditSD.frm.find("#ddlODRegistroId").val();    
    if (valddlItemIndicadorId == "0000000") {
        $('a[href="#navEstado"]').tab('show');
        addEditSD.frm.find("#ddlItemIndicadorId").focus();
        utilSigo.toastWarning("Aviso", "Debe seleccionar la situación actual de su registro");        
        return false;
    }
    if (!utilSigo.fnValidateForm_HideControl(addEditSD.frm, addEditSD.frm.find("#codSupervision"), addEditSD.frm.find("#iconInforme"), false)) {
        $('a[href="#navEstado"]').tab('show');        
        return false;
    }
    /*if (!utilSigo.fnValidateForm_HideControl(addEditSD.frm, addEditSD.frm.find("#codTramiteEnvio"), addEditSD.frm.find("#iconOficioEnv"), false)) {
        $('a[href="#navEstado"]').tab('show');
        return false;
    }*/
    if (valddlODRegistroId == "0000000") {        
        utilSigo.toastWarning("Aviso", "Debe seleccionar la O.D. desde donde se registra la información");        
        $('a[href="#navEstado"]').tab('show');
        addEditSD.frm.find("#ddlODRegistroId").focus();
        return false;
    }
    return true;
}
addEditSD.fnLoadTable = function () {
    var valCodSeguimiento = addEditSD.frm.find("#id").val();
    var url = urlLocalSigo + "Supervision/SeguimientoMuestra/GetAllMuestra?" + "codSeguimiento=" + valCodSeguimiento;
    addEditSD.dtMuestra.ajax.url(url).load(function (data) {
        if (data.success == false) {
            utilSigo.toastError("Error", "Sucedio un Error al cargar registros en la tabla muestras dendrológicas");
            console.log(data.msjError);
        }
    });
}
addEditSD.fnGetItemDelete = function (opcion, obj) {
    var lstMuestra = [];
    if (opcion == 1) {
        addEditSD.dtMuestra.rows().every(function (rowIdx, tableLoop, rowLoop) {
            var row = this.data();
            lstMuestra.push({ codSeguimiento: row.COD_SEG_MUESTRA, secuencial: row.COD_SECUENCIAL });
        });
    }
    else {
        var $tr = $(obj).closest('tr');
        var row = addEditSD.dtMuestra.row($tr).data();
        lstMuestra.push({ codSeguimiento: row.COD_SEG_MUESTRA, secuencial: row.COD_SECUENCIAL });
    }
    return lstMuestra;   
}
addEditSD.fnDeleteMuestra = function (opcion, obj) {
    var mensajeEli = "¿Está seguro de Eliminar el Registro Seleccionado?";
    if (opcion == 1) {
        mensajeEli = "¿Está seguro de Eliminar todas las muestras?";
        var $trsEliminar = addEditSD.dtMuestra.$("tr");
        if ($trsEliminar.length <= 0) return false;
    }
    utilSigo.dialogConfirm("Confirmacion", mensajeEli,
        function (r) {
            if (r) {               
                var url = urlLocalSigo + "Supervision/SeguimientoMuestra/DeleteMuestra";
                var lstMuestra = addEditSD.fnGetItemDelete(opcion,obj);              
                var optionData = { url: url, datos: JSON.stringify(lstMuestra), type:'POST' };
                utilSigo.fnAjax(optionData, function (data) {
                    if (data.success) {
                        addEditSD.fnLoadTable();
                        utilSigo.toastSuccess("Aviso", data.msj);
                    }
                    else {
                        utilSigo.toastWarning("Aviso", data.msj);
                        console.log(data.msjError);
                    }     
                });                           
            }
        });
}
addEditSD.fnInitDatatable = function () {
    var columns_label = ["Fecha Registro", "Muestra", "Fecha Colecion", "Zona UTM", "Coor. Este", "Coor. Norte","Estado"];
    var columns_data = ["F_CREACION", "COD_MUESTRA", "F_COLECCION", "UTM", "C_ESTE", "C_NORTE","E_IDENTIFICADO"];
    var options = {
        page_length: 20,
        row_edit: true, row_fnEdit: "addEditSD.fnAddEditMuestra(1,this)",
        row_delete: true, row_fnDelete: "addEditSD.fnDeleteMuestra(0,this)"
        , row_index: true
    };
    addEditSD.dtMuestra = utilDt.fnLoadDataTable_Detail(addEditSD.frm.find("#tbItemMuestra"), columns_label, columns_data, options);
}
$(document).ready(function () {
    $('[data-toggle="tooltip"]').tooltip();
    addEditSD.frm = $("#frmSeguimientoMuestraAddEdit");
    var msjInicio = addEditSD.frm.find("#hdMsj").val();
    if (msjInicio.trim() != "") {
        utilSigo.toastSuccess("Aviso", msjInicio);
    }
    addEditSD.fnInitEventos();
    addEditSD.fnInitDatatable();
    var valSeguimientoId = addEditSD.frm.find("#id").val();     
    if (valSeguimientoId.trim() != "" && valSeguimientoId.trim().length == 15) {
        $("#tabMuestras").show();
       // $('.nav-tabs a[href="#navDatosInventario"]').tab('show');
        addEditSD.fnLoadTable();
    }
});