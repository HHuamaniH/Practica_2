"use strict";
var ventanillaDen = {};
ventanillaDen.fnDownloadDocSITD = function (nombreArchivo) {
    document.location = "https://sitd.osinfor.gob.pe:8443/std/cInterfaseUsuario_SITD/download.php?direccion=//10.10.8.20/sitd-almacen/cAlmacenArchivos/&file=" + nombreArchivo;
};
ventanillaDen.fnAnular = function () {
    utilSigo.dialogConfirm('', 'Desea continuar con la operacion?', function (r) {
        if (r) {
            let contenedor = $("#modalAnular");
            let model = {
                cod_Tramite_Id: contenedor.find("#tramiteId").val(),
                obs: contenedor.find("#txtObsTransferencia").val().trim()
            };
            let url = urlLocalSigo + "THabilitante/ManVentanillaDenuncia/AnularDenuncia";
            let option = { url: url, datos: JSON.stringify(model), type: 'POST' };
            utilSigo.fnAjax(option, function (data) {
                if (data.success) {
                    utilSigo.toastSuccess("Aviso", data.msj);
                    $('#modalAnular').modal('hide');
                    ventanillaDen.dtManGrillaPaging.ajax.reload();
                }
                else {
                    utilSigo.toastError("Error", "Sucedio un Error. Comunicarse con el administrador del sistema");
                }
            });
        }
    });
};
ventanillaDen.fnCancelar = function () {
    $('#modalAnular').modal('hide');
};
ventanillaDen.fnModalAnular = function (obj) {
    let $tr = $(obj).closest("tr");
    let dataRow = ventanillaDen.dtManGrillaPaging.row($tr).data();
    let contenedor = $("#modalAnular");
    contenedor.find("#tramiteId").val(dataRow.COD_TRAMITE_SITD);
    contenedor.find("#cod_Tramite_Id").val(dataRow.COD_TRAMITE_SITD);
    contenedor.find("#nro_Referencia").val(dataRow.NUM_DREFERENCIA);    
    contenedor.find("#asunto").val(dataRow.ASUNTO);
    contenedor.find("#txtObsTransferencia").val('');
    utilSigo.modalDraggable(contenedor, '.modal-header');
    contenedor.modal({ keyboard: true, backdrop: 'static' });
};
ventanillaDen.fnTransferir = function (obj, id) {
    let $tr = $(obj).closest("tr");
    let dataRow = ventanillaDen.dtManGrillaPaging.row($tr).data();
    ventanillaDen.fnConfig();
    window.location = urlLocalSigo + "THabilitante/ManVentanillaDenuncia/RevisarDenuncia?tramiteId=" + dataRow.COD_TRAMITE_SITD;
};
ventanillaDen.fnConfig = function () {
    if (window.sessionStorage) {
        //Cargar las configuraciones existentes
        var lstConfig = [], config = {}, index = -1;
        if (JSON.parse(sessionStorage.getItem('configBusquedaEx')) === null) {
            sessionStorage.setItem('configBusquedaEx', JSON.stringify(lstConfig));
        }
        lstConfig = JSON.parse(sessionStorage.getItem('configBusquedaEx'));
        //Crear o actualizar la configuración del formulario consultado
        config = {
            TipoFormulario: ventanillaDen.frm.find("#tipoFormulario").val(),
            OpcionBuscar: ventanillaDen.frm.find("#ddlOpcionBuscarId1").val(),
            OpcionBuscar1: ventanillaDen.frm.find("#ddlOpcionBuscarId").val(),
            ValorBuscar: ventanillaDen.frm.find("#txtValorBuscar").val(),
            PageLength: ventanillaDen.dtManGrillaPaging.context[0]._iDisplayLength,
            RowStart: ventanillaDen.dtManGrillaPaging.context[0]._iDisplayStart,
            ColumnOrder: ventanillaDen.dtManGrillaPaging.context[0].aaSorting[0]
        };
        index = lstConfig.findIndex(m => m.TipoFormulario == ventanillaDen.frm.find("#tipoFormulario").val());
        if (index != -1) { lstConfig[index] = config; }
        else { lstConfig.push(config); }
        sessionStorage.setItem('configBusquedaEx', JSON.stringify(lstConfig));
    } else {
        utilSigo.toastWarning("Aviso", "Para que funcione bien el sistema, Por favor usar navegadores que soporten sessionStorage. Por ejemplo (Google Chrome, Mozilla Firefox)");
    }
};
ventanillaDen.fnBuildTable = function () {
    var columns_label = ["N°", "Nro. Doc Referencia", "Fecha de Entrega al OSINFOR",
        "Asunto", "Estado", "SITD", "R", "A", "Ir", "Obs"];
    var colums_title = ["", "", "", "", "", "Descargar documento Trámite SITD", "Revisar", "Anular",
        "Modificar detalle Denuncia", "Observaciones"];
    var columns = [
        {
            "name": "ROW_INDE", "width": "2%", "orderable": false, "searchable": false, "mRender": function (data, type, row, meta) {
                return parseInt(meta.row) + 1 + meta.settings._iDisplayStart;
            }
        },
        { "data": "NUM_DREFERENCIA", "autoWidth": true },
        { "data": "FECHA_SITD", "autoWidth": true },
        { "data": "ASUNTO", "autoWidth": true },
        { "data": "ESTADO_DREFERENCIA", "autoWidth": true },
        {
            "data": "", "width": "2%", "orderable": false, "searchable": false, "mRender": function (data, type, row) {
                if (row.PDF_TRAMITE_SITD.trim() !== "")
                    return '<div><i class="fa fa-lg fa-download" style="cursor:pointer;color:dodgerblue;" title="Descargar Documento Trámite SITD" onclick="ventanillaDen.fnDownloadDocSITD(\'' + row.PDF_TRAMITE_SITD + '\')"></i>';
                else return "";
            }
        },
        {
            "data": "", "width": "2%", "orderable": false, "searchable": false, "mRender": function (data, type, row) {
                if (row.ESTADO_DREFERENCIA === "Pendiente") {
                    return '<div><i class="fa fa-lg fa-sign-in" style="cursor:pointer;color:dodgerblue;" title="Revisar" onclick="ventanillaDen.fnTransferir(this,1)"></i>';
                } else {
                    return "";
                }

            }
        },
        {
            "data": "", "width": "2%", "orderable": false, "searchable": false, "mRender": function (data, type, row) {
                if (row.ESTADO_DREFERENCIA === "Pendiente") {
                    return '<div><i class="fa fa-lg fa-thumbs-down" style="cursor:pointer;color:dodgerblue;" title="Anular" onclick="ventanillaDen.fnModalAnular(this)"></i>';
                } else {
                    return "";
                }

            }
        },
        {
            "data": "", "width": "2%", "orderable": false, "searchable": false, "mRender": function (data, type, row) {
                if (row.ESTADO_DREFERENCIA === "Revisado") {
                    return '<div><i class="fa fa-lg fa-external-link" style="cursor:pointer;color:dodgerblue;" title="Modificar Detalle de la Denuncia" onclick="ventanillaDen.fnTransferir(this,1)"></i>';
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

        if (JSON.parse(sessionStorage.getItem('configBusquedaEx')) === null) {
            sessionStorage.setItem('configBusquedaEx', JSON.stringify(lstConfig));
        }

        lstConfig = JSON.parse(sessionStorage.getItem('configBusquedaEx'));

        index = lstConfig.findIndex(m => m.TipoFormulario === ventanillaDen.frm.find("#tipoFormulario").val());
        if (index != -1) {
            ventanillaDen.frm.find("#ddlOpcionBuscarId").select2("val", [lstConfig[index].OpcionBuscar1]);
            ventanillaDen.frm.find("#ddlOpcionBuscarId1").select2("val", [lstConfig[index].OpcionBuscar]);
            ventanillaDen.frm.find("#txtValorBuscar").val(lstConfig[index].ValorBuscar);
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
                d.customSearchForm = "DENUNCIA_SITD";
                d.customSearchType = ventanillaDen.frm.find("#ddlOpcionBuscarId1").val();
                d.customSearchType1 = ventanillaDen.frm.find("#ddlOpcionBuscarId").val();
                d.customSearchValue = ventanillaDen.frm.find("#txtValorBuscar").val().trim();

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
ventanillaDen.initEventos = function () {
    ventanillaDen.frm.find("#ddlOpcionBuscarId1").change(function () {
        if ($(this).val() == "Todos") {
            ventanillaDen.frm.find("#txtValorBuscar").val("");
            ventanillaDen.frm.find("#txtValorBuscar").attr("disabled", "disabled");
        }
        else {
            ventanillaDen.frm.find("#txtValorBuscar").val("");
            ventanillaDen.frm.find("#txtValorBuscar").removeAttr("disabled");
        }
        setTimeout(function () {
            $('.select2-container-active').removeClass('select2-container-active');
            ventanillaDen.frm.find("#txtValorBuscar").focus();
        }, 1);
    });
    ventanillaDen.frm.submit(function (e) {
        e.preventDefault();
        //ventanillaDen.fnSearch();
    });
};

ventanillaDen.fnSearch = function () {
    var valorBusqueda = ventanillaDen.frm.find("#txtValorBuscar").val().trim();
    var valorCboOpcion = ventanillaDen.frm.find("#ddlOpcionBuscarId1").val();
    if (valorCboOpcion !== "Todos") {
        if (valorBusqueda.trim() == "") {
            utilSigo.toastWarning("Aviso", "Ingrese Valor a Buscar");
            ventanillaDen.frm.find("#txtValorBuscar").focus();
            return false;
        }
        else {
            var cantCarateres = valorBusqueda.length;
            if (cantCarateres < 3) {
                utilSigo.toastWarning("Aviso", "La longitud del criterio de búsqueda debe ser mayor a dos caracteres");
                ventanillaDen.frm.find("#txtValorBuscar").focus();
                return false;
            }
            ventanillaDen.dtManGrillaPaging.ajax.reload();
        }
    } else {
        ventanillaDen.dtManGrillaPaging.ajax.reload();
    }


};
ventanillaDen.fnRefresh = function () {
    ventanillaDen.frm.find("#txtValorBuscar").val("");
    ventanillaDen.frm.find("#txtValorBuscar").attr("disabled", "disabled");
    ventanillaDen.frm.find("#ddlOpcionBuscarId").val($(ventanillaDen.frm.find("#ddlOpcionBuscarId")[0].childNodes[0]).val()).trigger('change.select2');
    ventanillaDen.frm.find("#ddlOpcionBuscarId1").val($(ventanillaDen.frm.find("#ddlOpcionBuscarId1")[0].childNodes[0]).val()).trigger('change.select2');
    ventanillaDen.dtManGrillaPaging.ajax.reload();
}
$(document).ready(function () {
    $.fn.select2.defaults.set("theme", "bootstrap4");
    ventanillaDen.frm = $("#frmManGrillaPaging");
    ventanillaDen.frm.find("#ddlOpcionBuscarId").select2();
    ventanillaDen.frm.find("#ddlOpcionBuscarId1").select2();
    ventanillaDen.initEventos();
    ventanillaDen.dtManGrillaPaging = ventanillaDen.fnBuildTable();
    ventanillaDen.frm.submit(function (e) {
        e.preventDefault();
        ventanillaDen.fnSearch();
    });     
});