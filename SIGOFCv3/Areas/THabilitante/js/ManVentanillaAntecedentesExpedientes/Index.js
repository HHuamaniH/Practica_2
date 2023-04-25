"use strict";
var anteExpedientes = {};

var rowTransferir = null;

$("#mdEdit").unbind("hidden.bs.modal").on('hidden.bs.modal', function () {
    anteExpedientes.frmMod.find("#COD_DREFERENCIA").val($(anteExpedientes.frmMod.find("#COD_DREFERENCIA")[0].childNodes[0]).val()).trigger('change.select2');
    anteExpedientes.frmMod.find("#NUM_THABILITANTE").val('');
    anteExpedientes.frmMod.find("#RESOLUCION_POA").val('');
    anteExpedientes.frmMod.find("#OBSERVACION").val('');
    $(this).hide();
});

anteExpedientes.fnConfig = function () {
    if (window.sessionStorage) {
        //Cargar las configuraciones existentes
        var lstConfig = [], config = {}, index = -1;
        if (JSON.parse(sessionStorage.getItem('configBusquedaEx')) == null) {
            sessionStorage.setItem('configBusquedaEx', JSON.stringify(lstConfig));
        }
        lstConfig = JSON.parse(sessionStorage.getItem('configBusquedaEx'));
        //Crear o actualizar la configuración del formulario consultado
        config = {
            TipoFormulario: anteExpedientes.frm.find("#tipoFormulario").val(),
            OpcionEstado: anteExpedientes.frm.find("#ddlOptBustarEstadoVentanillaId").val(),
            OpcionBuscar: anteExpedientes.frm.find("#ddlOpcionBuscarVentanillaId").val(),
            ValorBuscar: anteExpedientes.frm.find("#txtValorBuscar").val(),
            PageLength: anteExpedientes.dtManGrillaPaging.context[0]._iDisplayLength,
            RowStart: anteExpedientes.dtManGrillaPaging.context[0]._iDisplayStart,
            ColumnOrder: anteExpedientes.dtManGrillaPaging.context[0].aaSorting[0]
        };
        index = lstConfig.findIndex(m => m.TipoFormulario == anteExpedientes.frm.find("#tipoFormulario").val());
        if (index != -1) { lstConfig[index] = config; }
        else { lstConfig.push(config); }
        sessionStorage.setItem('configBusquedaEx', JSON.stringify(lstConfig));
    } else {
        utilSigo.toastWarning("Aviso", "Para que funcione bien el sistema, Por favor usar navegadores que soporten sessionStorage. Por ejemplo (Google Chrome, Mozilla Firefox)");
    }
};

anteExpedientes.fnSearch = function () {
    var valorCboOpcion = anteExpedientes.frm.find("#ddlOpcionBuscarVentanillaId").val();
    var valorBusqueda = anteExpedientes.frm.find("#txtValorBuscar").val().trim();

    if (valorCboOpcion != "TODOS") {
        if (valorBusqueda.trim() == "") {
            utilSigo.toastWarning("Aviso", "Ingrese Valor a Buscar");
            anteExpedientes.frm.find("#txtValorBuscar").focus();
            return false;
        }
        else {
            var cantCarateres = valorBusqueda.length;
            if (cantCarateres < 3) {
                utilSigo.toastWarning("Aviso", "La longitud del criterio de búsqueda debe ser mayor a dos caracteres");
                anteExpedientes.frm.find("#txtValorBuscar").focus();
                return false;
            }
            anteExpedientes.dtManGrillaPaging.ajax.reload();
        }
    } else {
        anteExpedientes.dtManGrillaPaging.ajax.reload();
    }
};

anteExpedientes.fnRefresh = function () {
    anteExpedientes.frm.find("#txtValorBuscar").val("");
    anteExpedientes.frm.find("#txtValorBuscar").attr("disabled", "disabled");
    anteExpedientes.frm.find("#ddlOptBustarEstadoVentanillaId").val($(anteExpedientes.frm.find("#ddlOptBustarEstadoVentanillaId")[0].childNodes[0]).val()).trigger('change.select2');
    anteExpedientes.frm.find("#ddlOpcionBuscarVentanillaId").val($(anteExpedientes.frm.find("#ddlOpcionBuscarVentanillaId")[0].childNodes[0]).val()).trigger('change.select2');
    anteExpedientes.dtManGrillaPaging.context[0].aaSorting = [];
    anteExpedientes.dtManGrillaPaging.context[0].aLastSort = [];
    anteExpedientes.dtManGrillaPaging.ajax.reload();
};

anteExpedientes.fnLoadManGrillaPaging = function () {
    var columns_label = ["N°", "E", "Tipo Doc Referencia", "N° Trámite", "Documento Trámite ", "Fecha de Entrega al OSINFOR",
        "Oficina Desconcentrada", "N° Título Habilitante", "Resolución de Aprobación del Plan de Manejo", "Observaciones", "Estado", "SITD",
        "SIADO", "T", "A", "Ir TH", "Ir PM", "Ir AD", "Obs"];
    var colums_title = ["", "Editar Datos SITD", "", "", "", "", "", "", "", "", "", "Descargar Documento Trámite SITD", "Descargar Documento del SIADO", "Transferir", "Anular",
        "Modificar Datos del Título Habilitante", "Modificar Datos del Plan de Manejo", "Modificar Datos del Acto Administrativo", ""];
    var columns = [
        {
            "name": "ROW_INDE", "width": "2%", "orderable": false, "searchable": false, "mRender": function (data, type, row, meta) {
                return parseInt(meta.row) + 1 + meta.settings._iDisplayStart;
            }
        },
        {
            "data": "", "width": "2%", "orderable": false, "searchable": false, "mRender": function (data, type, row) {
                if (row.ESTADO_AEXPEDIENTE == "Pendiente")
                    return '<div><i class="fa fa-lg fa-pencil-square-o" style="color:blue;cursor:pointer;" title="Editar Datos SITD" onclick="anteExpedientes.fnEdit(this)"></i>';
                else return "";
            }
        },
        { "data": "DOC_REFERENCIA", "autoWidth": true },
        { "data": "CCODIFICACION", "autoWidth": true },
        { "data": "CNRODOCUMENTO", "autoWidth": true },
        { "data": "FECHA_SITD", "autoWidth": true },
        { "data": "CNOMOFICINA", "autoWidth": true },
        { "data": "NUM_THABILITANTE", "autoWidth": true },
        { "data": "RESOLUCION_POA", "autoWidth": true },
        { "data": "OBSERVACION", "autoWidth": true },
        { "data": "ESTADO_AEXPEDIENTE", "autoWidth": true },
        {
            "data": "", "width": "2%", "orderable": false, "searchable": false, "mRender": function (data, type, row) {
                if (row.PDF_TRAMITE_SITD.trim() != "")
                    return '<div><i class="fa fa-lg fa-download" style="cursor:pointer;color:dodgerblue;" title="Descargar Documento Trámite SITD" onclick="anteExpedientes.fnDownloadDocSITD(\'' + row.PDF_TRAMITE_SITD + '\')"></i>';
                else return "";
            }
        },
        {
            "data": "", "width": "2%", "orderable": false, "searchable": false, "mRender": function (data, type, row) {
                if (row.CCODDOC.trim() != "")
                    return '<div><i class="fa fa-lg fa-download" style="cursor:pointer;color:dodgerblue;" title="Descargar Documento del SIADO" onclick="anteExpedientes.fnDownloadDocSIADO(\'' + row.CCODDOC.trim() + '\')"></i>';
                else return "";
            }
        },
        {
            "data": "", "width": "2%", "orderable": false, "searchable": false, "mRender": function (data, type, row) {
                if (row.COD_DREFERENCIA == "0301" || row.COD_DREFERENCIA == "0102") {// "0301":BEXT    0102: Adenda                
                    if (row.ESTADO_AEXPEDIENTE == "Pendiente")
                        return '<div><i class="fa fa-lg fa-sign-in" style="cursor:pointer;color:dodgerblue;" title="Transferir" onclick="anteExpedientes.fnTransferir(this,1)"></i>';
                    else return "";
                } else {
                    if (row.ESTADO_AEXPEDIENTE == "Pendiente") {
                        if (row.SUBTIPO == 2) {
                            return '<div><i class="fa fa-lg fa-sign-in" style="cursor:pointer;color:dodgerblue;" title="Transferir" onclick="anteExpedientes.fnTransferir(this,2)"></i>';

                        }
                        else {
                            return '<div><i class="fa fa-lg fa-sign-in" style="cursor:pointer;color:dodgerblue;" title="Transferir" onclick="anteExpedientes.fnTransferir(this,1)"></i>';
                        }
                    }
                    else
                        return "";
                        //return '<div><i class="fa fa-lg fa-sign-in" style="cursor:pointer;color:dodgerblue;" title="Transferir" onclick="anteExpedientes.fnTransferir(this,1)"></i>';

                }
            }
        },
        {
            "data": "", "width": "2%", "orderable": false, "searchable": false, "mRender": function (data, type, row) {
                if (row.ESTADO_AEXPEDIENTE == "Pendiente") {
                    if (row.COD_THABILITANTE != "" || row.NUM_POA != 0 || row.COD_PGMF != "" || row.COD_PMANEJO != "")
                        return "";
                    else return '<div><i class="fa fa-lg fa-thumbs-down" style="cursor:pointer;color:red;" title="Anular" onclick="anteExpedientes.fnTransferir(this,0)"></i>';
                }
                else { return ""; }
            }
        },
        {
            "data": "", "width": "2%", "orderable": false, "searchable": false, "mRender": function (data, type, row) {
                if (row.ESTADO_AEXPEDIENTE == "Pendiente" || row.ESTADO_AEXPEDIENTE == "Transferido") {
                    if (row.COD_THABILITANTE == "") return "";
                    else return '<div><i class="fa fa-lg fa-external-link " style="cursor:pointer;color:blue;" title="Modificar Datos del Título Habilitante" onclick="anteExpedientes.fnModTH(this)"></i>';
                }
                else { return ""; }
            }
        },
        {
            "data": "", "width": "2%", "orderable": false, "searchable": false, "mRender": function (data, type, row) {
                if (row.ESTADO_AEXPEDIENTE == "Pendiente" || row.ESTADO_AEXPEDIENTE == "Transferido") {
                    if (row.NUM_POA == 0 && row.COD_PGMF == "" && row.COD_PMANEJO == "") return "";
                    else return '<div><i class="fa fa-lg fa-external-link " style="cursor:pointer;color:blue;" title="Modificar Datos del Plan de Manejo" onclick="anteExpedientes.fnMod(this)"></i>';
                }
                else { return ""; }
            }
        },
        {
            "data": "", "width": "2%", "orderable": false, "searchable": false, "mRender": function (data, type, row) {
                if (row.ESTADO_AEXPEDIENTE == "Pendiente" || row.ESTADO_AEXPEDIENTE == "Transferido") {
                    if (row.NUM_ACTO == 0) return "";
                    else return '<div><i class="fa fa-lg fa-external-link " style="cursor:pointer;color:blue;" title="Modificar Datos del Acto Administrativo" onclick="anteExpedientes.fnModActoAdm(this)"></i>';
                }
                else { return ""; }
            }
        },
        {
            "data": "", "width": "2%", "orderable": false, "searchable": false, "mRender": function (data, type, row) {
                return row.OBSERVACION_TRANSFERENCIA;
            }
        }
    ];
    //**Cabecera**----
    var theadTable = "<tr>";
    for (var i = 0; i < columns_label.length; i++) {
        var title = colums_title[i];
        if (title == "") theadTable += '<th>' + columns_label[i] + '</th>';
        else theadTable += '<th title="' + title + '">' + columns_label[i] + '</th>';

    }
    theadTable += "</tr>";
    $("#tbManGrillaPaging").find("thead").append(theadTable);

    var optDt = { iLength: 20, iStart: 0, aSort: [] };
    //Cargar Configuración  
    if (window.sessionStorage) {
        var lstConfig = [], index = -1;

        if (JSON.parse(sessionStorage.getItem('configBusquedaEx')) == null) {
            sessionStorage.setItem('configBusquedaEx', JSON.stringify(lstConfig));
        }

        lstConfig = JSON.parse(sessionStorage.getItem('configBusquedaEx'));
        index = lstConfig.findIndex(m => m.TipoFormulario == anteExpedientes.frm.find("#tipoFormulario").val());
        if (index != -1) {
            anteExpedientes.frm.find("#ddlOptBustarEstadoVentanillaId").select2("val", [lstConfig[index].OpcionEstado]);
            anteExpedientes.frm.find("#ddlOpcionBuscarVentanillaId").select2("val", [lstConfig[index].OpcionBuscar]);
            anteExpedientes.frm.find("#txtValorBuscar").val(lstConfig[index].ValorBuscar);
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
        ordering: true,
        paging: true,
        ajax: {
            "url": initSigo.urlControllerGeneral + "/GetListaGeneralPaging",
            "data": function (d) {
                d.customSearchEnabled = true;
                d.customSearchForm = "AEXPEDIENTE_SITD";
                d.customSearchType1 = anteExpedientes.frm.find("#ddlOptBustarEstadoVentanillaId").val();
                d.customSearchType = anteExpedientes.frm.find("#ddlOpcionBuscarVentanillaId").val();
                d.customSearchValue = anteExpedientes.frm.find("#txtValorBuscar").val().trim();

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

anteExpedientes.initEventos = function () {
    anteExpedientes.frm.find("#ddlOpcionBuscarVentanillaId").change(function () {
        if ($(this).val() == "Todos") {
            anteExpedientes.frm.find("#txtValorBuscar").val("");
            anteExpedientes.frm.find("#txtValorBuscar").attr("disabled", "disabled");
        }
        else {
            anteExpedientes.frm.find("#txtValorBuscar").val("");
            anteExpedientes.frm.find("#txtValorBuscar").removeAttr("disabled");
        }
        setTimeout(function () {
            $('.select2-container-active').removeClass('select2-container-active');
            anteExpedientes.frm.find("#txtValorBuscar").focus();
        }, 1);
    });

    anteExpedientes.frm.submit(function (e) {
        e.preventDefault();
        anteExpedientes.fnSearch();
    });
};

anteExpedientes.fnExport = function () {
    var url = urlLocalSigo + "THabilitante/ManVentanillaAntecedentesExpedientes/ExportarRegistroUsuario";
    var option = { url: url, datos: JSON.stringify({}), type: 'POST' };

    utilSigo.fnAjax(option, function (data) {
        if (data.success) {
            document.location = urlLocalSigo + "Archivos/Plantilla/" + data.msj;
        }
        else {
            utilSigo.toastWarning("Aviso", "Sucedio un error, Comuníquese con el Administrador");
            console.log(data.msj);
        }
    });
};

anteExpedientes.fnEdit = function (obj) {
    var $tr = $(obj).closest('tr');
    var row = anteExpedientes.dtManGrillaPaging.row($tr).data();
    anteExpedientes.frmMod.find("#txtExpediente_SITD").val(row.COD_TRAMITE_SITD + "|" + row.COD_AEXPEDIENTE_SITD);
    anteExpedientes.frmMod.find("#COD_DREFERENCIA").val(row.COD_DREFERENCIA).trigger('change.select2');
    anteExpedientes.frmMod.find("#NUM_THABILITANTE").val(row.NUM_THABILITANTE);
    anteExpedientes.frmMod.find("#RESOLUCION_POA").val(row.RESOLUCION_POA);
    anteExpedientes.frmMod.find("#OBSERVACION").val(row.OBSERVACION);
    anteExpedientes.frmMod.find("#COD_AEXPEDIENTE_SITD").val(row.COD_AEXPEDIENTE_SITD);
    anteExpedientes.frmMod.find("#COD_TRAMITE_SITD").val(row.COD_TRAMITE_SITD);
    utilSigo.modalDraggable($("#mdEdit"), '.modal-header');
    $("#mdEdit").modal();
};

anteExpedientes.fnCloseModalSITD = function () {
    $("#mdEdit").modal('hide');
};

anteExpedientes.fnGuardarDatosSITD = function () {
    if (anteExpedientes.frmMod.find("#NUM_THABILITANTE").val().trim() == "") {
        anteExpedientes.frmMod.find("#NUM_THABILITANTE").val('');
        anteExpedientes.frmMod.find("#NUM_THABILITANTE").focus();
        utilSigo.toastWarning("Aviso", "Ingrese Nro. THabilitante");
        return false;
    }
    if (anteExpedientes.frmMod.find("#RESOLUCION_POA").val().trim() == "") {
        anteExpedientes.frmMod.find("#RESOLUCION_POA").val('');
        anteExpedientes.frmMod.find("#RESOLUCION_POA").focus();
        utilSigo.toastWarning("Aviso", "Ingrese Resolución de Aprobación del Plan de Manejo");
        return false;
    }
    if (anteExpedientes.frmMod.find("#COD_DREFERENCIA").val() == "-") {
        anteExpedientes.frmMod.find("#COD_DREFERENCIA").focus();
        utilSigo.toastWarning("Aviso", "Seleccione el Documento de Referencia");
        return false;
    }
    utilSigo.dialogConfirm("Confirmacion", "Está seguro de actualizar los datos?",
        function (r) {
            if (r) {
                var url = urlLocalSigo + "THabilitante/ManVentanillaAntecedentesExpedientes/UpdateDatosSITD";
                var model = anteExpedientes.frmMod.serializeObject();
                var option = { url: url, datos: JSON.stringify(model), type: 'POST' };
                utilSigo.fnAjax(option, function (data) {
                    if (data.success) {
                        utilSigo.toastSuccess("Aviso", data.msj);
                        $("#mdEdit").modal('hide');
                        anteExpedientes.dtManGrillaPaging.ajax.reload();
                    }
                    else {
                        utilSigo.toastWarning("Aviso", data.msj);
                    }
                });
            }
        });
};

anteExpedientes.fnDownloadDocSITD = function (nombreArchivo) {
    document.location = "https://sitd.osinfor.gob.pe:8443/std/cInterfaseUsuario_SITD/download.php?direccion=sitd-almacen&file=" + nombreArchivo;
};

anteExpedientes.fnDownloadDocSIADO = function (obj) {
    var $tr = $(obj).closest('tr');
    var row = anteExpedientes.dtManGrillaPaging.row($tr).data();
    console.log('row',row)
    switch (row.OBSERVACION) {
        case 'CENSO':
            //JL
            window.open("https://siadoregion.osinfor.gob.pe/PDF-GORE/" + row.CCODDOC.trim() +"."+ row.EXTENSION, '_blank'); break;
            //var url = urlLocalSigo + "THabilitante/ManVentanillaAntecedentesExpedientes/DownloadCenso";//ExportarRegistroUsuario
            //var option = { url: url, datos: JSON.stringify({ coddoc: row.CCODDOC }), type: 'POST' };

            ////utilSigo.fnAjax(option, function (data) {
            ////    if (data.success) {
            ////        document.location = urlLocalSigo + "Archivos/Plantilla/" + data.msj;
            ////    }
            ////    else {
            ////        utilSigo.toastWarning("Aviso", "Sucedio un error, Comuníquese con el Administrador");
            ////        console.log(data.msj);
            ////    }
            ////});
            //$.ajax({
            //    url: url,
            //    type: 'POST',
            //    data: { coddoc: row.CCODDOC},
            //    dataType: 'json',
            //    success: function (data) {
            //        //utilSigo.unblockUIGeneral();
            //       utilSigo.unblockUIGeneral();
            //        if (data.success) {
            //            window.location.href = urlLocalSigo + "THabilitante/ManVentanillaAntecedentesExpedientes" + "/Download?file=" + data.values[0];
            //        }
            //        else utilSigo.toastWarning("Error", data.msj);
            //    },
            //    beforeSend: function () {
            //        utilSigo.blockUIGeneral();
            //    },
            //    error: function (jqXHR, error, errorThrown) {
            //        utilSigo.unblockUIGeneral();
            //        utilSigo.toastError("Error", "Sucedio un error, Comuniquese con el Administrador");
            //        console.log(jqXHR.responseText);
            //    }
            //});



            //break;
        default: window.open("https://siadoregion.osinfor.gob.pe/PDF-GORE/" + row.CCODDOC.trim() + "." + row.EXTENSION, '_blank'); break;
    }

};
anteExpedientes.fnDownloadDocCenso = function () {
    var url = urlLocalSigo + "THabilitante/ManVentanillaAntecedentesExpedientes/DownloadCenso";//ExportarRegistroUsuario
    switch (rowTransferir.OBSERVACION) {
        case 'CENSO':
            //JL
            $.ajax({
                url: url,
                type: 'POST',
                data: { coddoc: rowTransferir.CCODDOC },
                dataType: 'json',
                success: function (data) {
                    //utilSigo.unblockUIGeneral();
                    utilSigo.unblockUIGeneral();
                    if (data.success) {
                        window.location.href = urlLocalSigo + "THabilitante/ManVentanillaAntecedentesExpedientes" + "/Download?file=" + data.values[0];
                    }
                    else utilSigo.toastWarning("Error", data.msj);
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



            break;
        default: window.open("https://siadoregion.osinfor.gob.pe/PDF-GORE/" + row.CCODDOC.trim() + ".pdf", '_blank'); break;
    }

};

anteExpedientes.fnDownloadSiado = function (nombreArchivo) {
    window.open("https://siadoregion.osinfor.gob.pe/PDF-GORE/" + nombreArchivo + ".pdf", '_blank');
};

anteExpedientes.fnTransferir = function (obj, opcion) {
    var $tr = $(obj).closest('tr');
    var row = anteExpedientes.dtManGrillaPaging.row($tr).data();
    anteExpedientes.fnTransferirModal(row, opcion);
};

anteExpedientes.fnTransferirModal = function (row, opcion) { //0 anular, 1 transferir

    var tipoOpcion = opcion == 0 ? 'ANULAR' : 'TRANSFERIR';
    rowTransferir = row;
    if (row.COD_DREFERENCIA == "0302" || row.COD_DREFERENCIA == "0609") //Forma 20, otros, documento no soportado
    {
        utilSigo.toastWarning("Aviso", "Documento no soportado por el SIGOsfc");
        return false;
    }
    var model = { tipo: tipoOpcion, COD_DREFERENCIA: row.COD_DREFERENCIA, DOC_REFERENCIA: row.DOC_REFERENCIA, COD_AEXPEDIENTE_SITD: row.COD_AEXPEDIENTE_SITD, COD_TRAMITE_SITD: row.COD_TRAMITE_SITD, SUBTIPO: row.SUBTIPO };
    var url = urlLocalSigo + "THabilitante/ManVentanillaAntecedentesExpedientes/_Transferir";
    var option = { url: url, type: 'GET', datos: model, divId: "transferirModal" };
    utilSigo.fnOpenModal(option, function () {
        var frm = $("#frmTransferir");
        frm.find("#ItemNumTHabilitante").val(row.NUM_THABILITANTE);
        frm.find("#txtItemObservacionTransferir").val(row.OBSERVACION_TRANSFERENCIA);
    });
};

anteExpedientes.fnModTH = function (obj) {
    var $tr = $(obj).closest('tr');
    var row = anteExpedientes.dtManGrillaPaging.row($tr).data();
    var appClient = "SIGOsfc_VentanillaSITD|VISUALIZAR|TH";
    var appData = row.COD_AEXPEDIENTE_SITD        //[0]
        + "¬" + row.COD_TRAMITE_SITD     //[1]
        + "¬" + row.COD_DREFERENCIA     //[2]
        + "¬" + row.COD_THABILITANTE;      //[3]
    var url = urlLocalSigo + "THabilitante/ManTHabilitante/Index?appClient=" + appClient + "&appData=" + appData;
    //guardando configuracion de la tabla
    anteExpedientes.fnConfig();
    document.location = url;
};

anteExpedientes.fnMod = function (obj) {
    var $tr = $(obj).closest('tr');
    var row = anteExpedientes.dtManGrillaPaging.row($tr).data();

    var appClient = "SIGOsfc_VentanillaSITD|VISUALIZAR|TH";
    var appData = row.COD_AEXPEDIENTE_SITD        //[0]
        + "¬" + row.COD_TRAMITE_SITD     //[1]
        + "¬" + row.COD_DREFERENCIA;      //[2]
    var url = "";
    switch (row.COD_DREFERENCIA) {
        case "0401": appData += "¬" + row.COD_PGMF;
            url = urlLocalSigo + "THabilitante/ManPlanManejoForestal/AddEdit?appClient=" + appClient + "&opt=0" + "&appData=" + appData;
            break; //PGMF
        /*case "0404": appData += "¬" + row.COD_PGMF;
            url = urlLocalSigo + "THabilitante/ManPlanManejoForestal/AddEdit?appClient=" + appClient + "&opt=1" + "&appData=" + appData;
            break; //PMFI*/
        case "0403": appData += "¬" + row.COD_PMANEJO;
            url = urlLocalSigo + "THabilitante/ManPlanManejo/AddEditPM?appClient=" + appClient + "&appData=" + appData;
            break; //Plan Manejo (Fauna)
        //case "0204"://POA/PO
        //case "0402"://DEMA
        default:
            //var lstManMenu = row.COD_DREFERENCIA == "0402" ? "2" : "1";
            var lstManMenu = "";
            switch (row.COD_DREFERENCIA) {
                case "0204":
                case "0301": lstManMenu = "1"; break;
                case "0402": lstManMenu = "2"; break;
                case "0404": lstManMenu = "3"; break;
            }
            var urlVal = urlLocalSigo + "THabilitante/ManVentanillaAntecedentesExpedientes/ValidarIrPM";
            var option = { url: urlVal, datos: { COD_AEXPEDIENTE_SITD: row.COD_AEXPEDIENTE_SITD, COD_TRAMITE_SITD: row.COD_TRAMITE_SITD }, type: 'GET' };
            utilSigo.fnAjax(option, function (data) {
                if (data.success) {
                    appData += "¬" + data.COD_TH;//[3]
                    appData += "¬" + row.NUM_POA;//[4]
                    url = urlLocalSigo + "THabilitante/ManPOA/AddEdit?lstManMenu=" + lstManMenu + "&appClient=" + appClient + "&appData=" + appData;
                    anteExpedientes.fnConfig();
                    document.location = url;
                } else {
                    utilSigo.toastWarning("Aviso", data.msj);
                    return false;
                }
            });
            break;
    }
    //guardando configuracion de la tabla
    anteExpedientes.fnConfig();
    document.location = url;
};

anteExpedientes.fnModActoAdm = function (obj) {
    var $tr = $(obj).closest('tr');
    var row = anteExpedientes.dtManGrillaPaging.row($tr).data();
    var appClient = "SIGOsfc_VentanillaSITD|VISUALIZAR|ACTO";
    var url = "";
    var appData = row.COD_AEXPEDIENTE_SITD  //[0]
        + "¬" + row.COD_TRAMITE_SITD     //[1]
        + "¬" + row.COD_DREFERENCIA;      //[2]   
    //
    //var lstManMenu = row.COD_DREFERENCIA == "0402" ? "2" : "1";
    var urlVal = urlLocalSigo + "THabilitante/ManVentanillaAntecedentesExpedientes/ValidarIrPM";
    var option = { url: urlVal, datos: { COD_AEXPEDIENTE_SITD: row.COD_AEXPEDIENTE_SITD, COD_TRAMITE_SITD: row.COD_TRAMITE_SITD }, type: 'GET' };
    utilSigo.fnAjax(option, function (data) {
        if (data.success) {
            appData += "¬" + data.COD_TH;//[3]
            appData += "¬" + row.NUM_ACTO;//[4]

            var lstManMenu = "1";
            if (row.ESTADO_ORIGEN_PADRE == "PMFI") {
                lstManMenu = "3";
            }

            url = urlLocalSigo + "THabilitante/ManPOA/AddEdit?lstManMenu=" + lstManMenu + "&appClient=" + appClient + "&appData=" + appData;
            anteExpedientes.fnConfig();
            document.location = url;
        } else {
            utilSigo.toastWarning("Aviso", data.msj);
            return false;
        }
    });
}

$(document).ready(function () {
    anteExpedientes.frm = $("#frmManGrillaPaging");
    anteExpedientes.frmMod = $("#frmESITD");

    var alertaInicial = anteExpedientes.frm.find("#alertaFormulario").val();
    if (alertaInicial != "") {
        utilSigo.toastSuccess("Aviso", alertaInicial);
    }

    $.fn.select2.defaults.set("theme", "bootstrap4");
    anteExpedientes.frm.find("#ddlOptBustarEstadoVentanillaId").select2();
    anteExpedientes.frm.find("#ddlOpcionBuscarVentanillaId").select2();
    anteExpedientes.frm.find("#txtValorBuscar").focus();
    anteExpedientes.frmMod.find("#COD_DREFERENCIA").select2();

    anteExpedientes.initEventos();

    anteExpedientes.dtManGrillaPaging = anteExpedientes.fnLoadManGrillaPaging();

    ///
    if (window.sessionStorage) {
        if (anteExpedientes.frm.find("#hdOrigen").val() == "TRANSFERIR") {
            var lstConfig = [], index = -1;
            if (JSON.parse(sessionStorage.getItem('configBusquedaEx')) == null) {
                sessionStorage.setItem('configBusquedaEx', JSON.stringify(lstConfig));
            }
            lstConfig = JSON.parse(sessionStorage.getItem('configBusquedaEx'));
            index = lstConfig.findIndex(m => m.TipoFormulario == "AEXPEDIENTE_SITD_ROW");
            if (index != -1) {
                anteExpedientes.fnTransferirModal(lstConfig[index].rowTH, 1);
                lstConfig.splice(index, 1);
                sessionStorage.setItem('configBusquedaEx', JSON.stringify(lstConfig));
            }
        }
    }
    var msjTransfer = anteExpedientes.frm.find("#hdMsjTransfer").val();
    if (msjTransfer != "") {
        if (msjTransfer.split('¬')[1] == "0") utilSigo.toastWarning("Aviso", msjTransfer.split('¬')[0]);
        else utilSigo.toastSuccess("Aviso", msjTransfer.split('¬')[0]);
    }
});