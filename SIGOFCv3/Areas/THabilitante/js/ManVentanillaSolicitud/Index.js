"use strict";
var ventanillaSol = {};
ventanillaSol.fnDownloadDocSITD = function (nombreArchivo) {
    document.location = "https://sitd.osinfor.gob.pe:8443/std/cInterfaseUsuario_SITD/download.php?direccion=//10.10.8.20/sitd-almacen/cAlmacenArchivos/&file=" + nombreArchivo;
};
ventanillaSol.fnAnular = function () {    
    utilSigo.dialogConfirm('', 'Desea continuar con la operacion?', function (r) {
        if (r) {
            let contenedor = $("#modalAnular");
            let model = {
                cod_Tramite_Id: contenedor.find("#tramiteId").val(),
                obs: contenedor.find("#txtObsTransferencia").val().trim()             
            };
            let url = urlLocalSigo + "THabilitante/ManVentanillaSolicitud/AnularSolicitud";
            let option = { url: url, datos: JSON.stringify(model), type: 'POST' };
            utilSigo.fnAjax(option, function (data) {
                if (data.success) {
                    utilSigo.toastSuccess("Aviso", data.msj);
                    $('#modalAnular').modal('hide');
                    ventanillaSol.dtManGrillaPaging.ajax.reload();
                }
                else {
                    utilSigo.toastError("Error", "Sucedio un Error. Comunicarse con el administrador del sistema");
                }
            });
        }
    });
};
ventanillaSol.fnCancelar = function () {   
    $('#modalAnular').modal('hide');
};
ventanillaSol.fnModalAnular = function (obj) {
    let $tr = $(obj).closest("tr");
    let dataRow = ventanillaSol.dtManGrillaPaging.row($tr).data();
    let contenedor = $("#modalAnular");
    contenedor.find("#tramiteId").val(dataRow.COD_TRAMITE_SITD);
    contenedor.find("#cod_Tramite_Id").val(dataRow.COD_TRAMITE_SITD);
    contenedor.find("#nro_Referencia").val(dataRow.NUM_DREFERENCIA);
    contenedor.find("#entidad").val(dataRow.ENTIDAD);
    contenedor.find("#asunto").val(dataRow.ASUNTO);
    contenedor.find("#txtObsTransferencia").val('');
    utilSigo.modalDraggable(contenedor, '.modal-header');
    contenedor.modal({ keyboard: true, backdrop: 'static' });
};
ventanillaSol.fnTransferir = function (obj,id) {
    let $tr = $(obj).closest("tr");
    let dataRow = ventanillaSol.dtManGrillaPaging.row($tr).data();
    ventanillaSol.fnConfig();
    window.location = urlLocalSigo + "THabilitante/ManVentanillaSolicitud/Transferir?tramiteId=" + dataRow.COD_TRAMITE_SITD;
};
ventanillaSol.fnConfig = function () {
    if (window.sessionStorage) {
        //Cargar las configuraciones existentes
        var lstConfig = [], config = {}, index = -1;
        if (JSON.parse(sessionStorage.getItem('configBusquedaEx')) == null) {
            sessionStorage.setItem('configBusquedaEx', JSON.stringify(lstConfig));
        }
        lstConfig = JSON.parse(sessionStorage.getItem('configBusquedaEx'));
        //Crear o actualizar la configuración del formulario consultado
        config = {
            TipoFormulario: ventanillaSol.frm.find("#tipoFormulario").val(),
            OpcionBuscar: ventanillaSol.frm.find("#ddlOpcionBuscarId1").val(),
            OpcionBuscar1: ventanillaSol.frm.find("#ddlOpcionBuscarId").val(),
            ValorBuscar: ventanillaSol.frm.find("#txtValorBuscar").val(),
            PageLength: ventanillaSol.dtManGrillaPaging.context[0]._iDisplayLength,
            RowStart: ventanillaSol.dtManGrillaPaging.context[0]._iDisplayStart,
            ColumnOrder: ventanillaSol.dtManGrillaPaging.context[0].aaSorting[0]
        };
        index = lstConfig.findIndex(m => m.TipoFormulario == ventanillaSol.frm.find("#tipoFormulario").val());
        if (index != -1) { lstConfig[index] = config; }
        else { lstConfig.push(config); }
        sessionStorage.setItem('configBusquedaEx', JSON.stringify(lstConfig));
    } else {
        utilSigo.toastWarning("Aviso", "Para que funcione bien el sistema, Por favor usar navegadores que soporten sessionStorage. Por ejemplo (Google Chrome, Mozilla Firefox)");
    }
};
ventanillaSol.fnBuildTable = function () {
    var columns_label = ["N°", "Nro. Doc Referencia", "Fecha de Entrega al OSINFOR",
        "Entidad Remitente", "Estado", "SITD", "T", "A", "Ir", "Obs"];
    var colums_title = ["", "", "", "", "", "Descargar documento Trámite SITD", "Transferir", "Anular",
        "Modificar detalle de la solicitud", "Observaciones"];
    var columns = [
        {
            "name": "ROW_INDE", "width": "2%", "orderable": false, "searchable": false, "mRender": function (data, type, row, meta) {
                return parseInt(meta.row) + 1 + meta.settings._iDisplayStart;
            }
        },
        { "data": "NUM_DREFERENCIA", "autoWidth": true },
        { "data": "FECHA_SITD", "autoWidth": true },
        { "data": "ENTIDAD", "autoWidth": true },
        { "data": "ESTADO_DREFERENCIA", "autoWidth": true },
        {
            "data": "", "width": "2%", "orderable": false, "searchable": false, "mRender": function (data, type, row) {
                if (row.PDF_TRAMITE_SITD.trim() !== "")
                    return '<div><i class="fa fa-lg fa-download" style="cursor:pointer;color:dodgerblue;" title="Descargar Documento Trámite SITD" onclick="ventanillaSol.fnDownloadDocSITD(\'' + row.PDF_TRAMITE_SITD + '\')"></i>';
                else return "";
            }
        },
        {
            "data": "", "width": "2%", "orderable": false, "searchable": false, "mRender": function (data, type, row) {
                if (row.ESTADO_DREFERENCIA === "Pendiente") {                 
                    return '<div><i class="fa fa-lg fa-sign-in" style="cursor:pointer;color:dodgerblue;" title="Transferir" onclick="ventanillaSol.fnTransferir(this,1)"></i>';
                } else {
                    return "";
                }

            }
        },
        {
            "data": "", "width": "2%", "orderable": false, "searchable": false, "mRender": function (data, type, row) {
                if (row.ESTADO_DREFERENCIA === "Pendiente") {
                    return '<div><i class="fa fa-lg fa-thumbs-down" style="cursor:pointer;color:dodgerblue;" title="Anular" onclick="ventanillaSol.fnModalAnular(this)"></i>';
                } else {
                    return "";
                }

            }
        },
         {
            "data": "", "width": "2%", "orderable": false, "searchable": false, "mRender": function (data, type, row) {
                if (row.ESTADO_DREFERENCIA === "Transferido") {
                    return '<div><i class="fa fa-lg fa-external-link" style="cursor:pointer;color:dodgerblue;" title="Modificar Detalle de la Solicitud" onclick="ventanillaSol.fnTransferir(this,1)"></i>';
                } else {
                    return "";
                }

            }
        },
        { "data": "OBSERVACION_TRANSFERENCIA", "autoWidth": true }
    ];
    //**Cabecera**----
    var theadTable = "<tr>";
    for (var i = 0; i < columns_label.length; i++) {
        var title = colums_title[i];
        if (title === "") theadTable += '<th>' + columns_label[i] + '</th>';
        else theadTable += '<th title="' + title + '">' + columns_label[i] + '</th>';

    }
    theadTable += "</tr>";
    $("#tbManGrillaPaging").find("thead").append(theadTable);
    var optDt = { iLength: 10, iStart: 0, aSort: [] };
    //Cargar Configuración  
    if (window.sessionStorage) {
        var lstConfig = [], index = -1;

        if (JSON.parse(sessionStorage.getItem('configBusquedaEx')) == null) {
            sessionStorage.setItem('configBusquedaEx', JSON.stringify(lstConfig));
        }
         
        lstConfig = JSON.parse(sessionStorage.getItem('configBusquedaEx'));
         
        index = lstConfig.findIndex(m => m.TipoFormulario === ventanillaSol.frm.find("#tipoFormulario").val());
        if (index != -1) {
            ventanillaSol.frm.find("#ddlOpcionBuscarId").select2("val", [lstConfig[index].OpcionBuscar1]);
            ventanillaSol.frm.find("#ddlOpcionBuscarId1").select2("val", [lstConfig[index].OpcionBuscar]);
            ventanillaSol.frm.find("#txtValorBuscar").val(lstConfig[index].ValorBuscar);
            optDt.iLength = lstConfig[index].PageLength;
            optDt.iStart = lstConfig[index].RowStart;
            if ((typeof lstConfig[index].ColumnOrder !== 'undefined') && lstConfig[index].ColumnOrder.length > 0) {
                optDt.aSort.push([lstConfig[index].ColumnOrder[0], lstConfig[index].ColumnOrder[1]]);
            }

            lstConfig.splice(index, 1);
            sessionStorage.setItem('configBusquedaEx', JSON.stringify(lstConfig));
        }
    }
    else {
        utilSigo.toastWarning("Aviso", "Para que funcione bien el sistema, Por favor usar navegadores que soporten sessionStorage. Por ejemplo (Google Chrome, Mozilla Firefox)");
    }
    return $("#tbManGrillaPaging").DataTable({
        processing: true,
        serverSide: true,
        searching: false,
        ordering: false,
        paging: true,
        ajax: {
            "url": initSigo.urlControllerGeneral + "/GetListaGeneralPaging",
            "data": function (d) {
                d.customSearchEnabled = true;
                d.customSearchForm = "SOLINF_THABILITANTE_SITD";
                d.customSearchType = ventanillaSol.frm.find("#ddlOpcionBuscarId1").val();
                d.customSearchType1 = ventanillaSol.frm.find("#ddlOpcionBuscarId").val();
                d.customSearchValue = ventanillaSol.frm.find("#txtValorBuscar").val().trim();

                for (var i = 0; i < d.order.length; i++) {
                    d.order[i]["column_name"] = d.columns[d.order[i]["column"]]["data"];
                }
                d.columns = null;
            },
            "error": function (jqXHR) {
                utilSigo.unblockUIGeneral();
                utilSigo.toastError("Error", initSigo.MessageError);
                console.log(jqXHR.responseText);
            },
            "statusCode": {
                203: () => { utilSigo.unblockUIGeneral(); utilSigo.toastInfo("Aviso", "El usuario perdio la sesión. Vuelva ingresar al sistema"); }
            }
        },
        columns: columns,
        bInfo: true,
        "lengthMenu": [[10, 20, 50, 100], [10, 20, 50, 100]],
        "aaSorting": optDt.aSort,
        "pageLength": optDt.iLength,
        "displayStart": optDt.iStart,
        "oLanguage": initSigo.oLanguage,
        "drawCallback": initSigo.showPagination,
    });
};
ventanillaSol.initEventos = function () {
    ventanillaSol.frm.find("#ddlOpcionBuscarId1").change(function () {
        if ($(this).val() == "Todos") {
            ventanillaSol.frm.find("#txtValorBuscar").val("");
            ventanillaSol.frm.find("#txtValorBuscar").attr("disabled", "disabled");
        }
        else {
            ventanillaSol.frm.find("#txtValorBuscar").val("");
            ventanillaSol.frm.find("#txtValorBuscar").removeAttr("disabled");
        }
        setTimeout(function () {
            $('.select2-container-active').removeClass('select2-container-active');
            ventanillaSol.frm.find("#txtValorBuscar").focus();
        }, 1);
    });
    ventanillaSol.frm.submit(function (e) {
        e.preventDefault();
        //ventanillaSol.fnSearch();
    });
};

ventanillaSol.fnSearch = function () {
    var valorBusqueda = ventanillaSol.frm.find("#txtValorBuscar").val().trim();
    var valorCboOpcion = ventanillaSol.frm.find("#ddlOpcionBuscarId1").val();
    if (valorCboOpcion != "Todos") {
        if (valorBusqueda.trim() == "") {
            utilSigo.toastWarning("Aviso", "Ingrese Valor a Buscar");
            ventanillaSol.frm.find("#txtValorBuscar").focus();
            return false;
        }
        else {
            var cantCarateres = valorBusqueda.length;
            if (cantCarateres < 3) {
                utilSigo.toastWarning("Aviso", "La longitud del criterio de búsqueda debe ser mayor a dos caracteres");
                ventanillaSol.frm.find("#txtValorBuscar").focus();
                return false;
            }
            ventanillaSol.dtManGrillaPaging.ajax.reload();
        }
    } else {
        ventanillaSol.dtManGrillaPaging.ajax.reload();
    }


};
ventanillaSol.fnRefresh = function () {
    ventanillaSol.frm.find("#txtValorBuscar").val("");
    ventanillaSol.frm.find("#txtValorBuscar").attr("disabled", "disabled");
    ventanillaSol.frm.find("#ddlOpcionBuscarId").val($(ventanillaSol.frm.find("#ddlOpcionBuscarId")[0].childNodes[0]).val()).trigger('change.select2');
    ventanillaSol.frm.find("#ddlOpcionBuscarId1").val($(ventanillaSol.frm.find("#ddlOpcionBuscarId1")[0].childNodes[0]).val()).trigger('change.select2');
    ventanillaSol.dtManGrillaPaging.ajax.reload();
}
$(document).ready(function () {
    $.fn.select2.defaults.set("theme", "bootstrap4");
    ventanillaSol.frm = $("#frmManGrillaPaging");
    ventanillaSol.frm.find("#ddlOpcionBuscarId").select2();
    ventanillaSol.frm.find("#ddlOpcionBuscarId1").select2(); 
    ventanillaSol.initEventos();
    ventanillaSol.dtManGrillaPaging = ventanillaSol.fnBuildTable();
    ventanillaSol.frm.submit(function (e) {
        e.preventDefault();
        ventanillaSol.fnSearch();
    });    
});