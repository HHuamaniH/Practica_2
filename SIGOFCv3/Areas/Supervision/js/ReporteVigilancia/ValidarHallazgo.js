var ValidarHallazgo = {};
ValidarHallazgo.idTipoHallazgo;
ValidarHallazgo.DataDetHallazgo = [];
ValidarHallazgo.DataTHabilitanteVinculado = [];
ValidarHallazgo.DataArchivo = [];
ValidarHallazgo.tbElimTHVinculado = [];

ValidarHallazgo.fnLoadData = function (obj, tipo) {
    switch (tipo) {
        case "DataDetHallazgo": ValidarHallazgo.DataDetHallazgo = obj; break;
        case "DataTHabilitanteVinculado": ValidarHallazgo.DataTHabilitanteVinculado = obj; break;
        case "DataArchivo": ValidarHallazgo.DataArchivo = obj; break;
    }
};

ValidarHallazgo.regresar = function () {
    var url = urlLocalSigo + "Supervision/ReporteVigilancia/Index";
    window.location = url;
};

ValidarHallazgo.fnAddEditDetHallazgo = function (obj) {
    var idEstado = ValidarHallazgo.frm.find("#idEstado").val();
    var coducuenta = ValidarHallazgo.frm.find("#hdfCodUCuenta").val();
    var coducontrol = ValidarHallazgo.frm.find("#hdfCodUsuarioControl").val();
    var row = null;
    var estadoDt = "";

    if (obj != null && obj != "") {
        row = ValidarHallazgo.dtDetHallazgo.row($(obj).parents('tr')).data();
        estadoDt = row.NU_ESTADO.toString();
    }

    var url = urlLocalSigo + "Supervision/ReporteVigilancia/_AddEditDetHallazgo";
    var option = { url: url, type: 'POST', datos: { asEstadoDt: estadoDt }, divId: "mdlAddEdit" };

    utilSigo.fnOpenModal(option, function () {
        if (obj != null && obj != "") {
            _AddEditDetHallazgo.fnInit(utilSigo.fnConvertArrayToObject(row), ValidarHallazgo.idTipoHallazgo, idEstado, coducuenta, coducontrol);
        } else {
            _AddEditDetHallazgo.fnInit("", ValidarHallazgo.idTipoHallazgo, idEstado, coducuenta, coducontrol);
        }

        _AddEditDetHallazgo.fnSaved = function (data) {
            if (obj != null && obj != "") {
                //console.log($("#tbDetHallazgo").dataTable().$("tr").index($(obj).parents('tr'))); Obtiene el índice de la fila
                row.COD_ESPECIES = (data.COD_ESPECIES == "-") ? null : data.COD_ESPECIES;
                row.NV_ESPECIES_VALIDADO = data.NV_ESPECIES_VALIDADO;

                if (data.NV_OBSERVACION_VALIDADO != null) {
                    if (data.NV_OBSERVACION_VALIDADO.trim() == "") data.NV_OBSERVACION_VALIDADO = null;
                }
                row.NV_OBSERVACION_VALIDADO = data.NV_OBSERVACION_VALIDADO;

                row.NU_ESTADO = data.NU_ESTADO;
                row.ESTADO = data.ESTADO;
                row.RegEstado = data.RegEstado;

                ValidarHallazgo.dtDetHallazgo.row($(obj).parents('tr')).data(row).draw(false);
                $("#mdlAddEdit").modal('hide');
            }
        };
    });
};

ValidarHallazgo.fnVincularTH = function (opc) {
    var url = urlLocalSigo + "Supervision/ReporteVigilancia/_VincularTHabilitante";
    var option = { url: url, type: 'POST', datos: {}, divId: "mdlVincularTH" };

    utilSigo.fnOpenModal(option, function () {
        _VincularTHabilitante.fnInit(opc);

        _VincularTHabilitante.fnSaved = function (data) {
            switch (opc) {
                case "TH":
                    ValidarHallazgo.frm.find("#hdfCodTHabilitante").val(data.COD_THABILITANTE);
                    ValidarHallazgo.frm.find("#txtTHabilitante_validado").val(data.THABILITANTE);
                    ValidarHallazgo.frm.find("#hdfCodTitular").val(data.COD_TITULAR);
                    ValidarHallazgo.frm.find("#txtTitular_validado").val(data.TITULAR);
                    break;

                case "THVinculado":
                    var fila = {
                        NV_REPORTEHALLAZGO: ValidarHallazgo.frm.find("#hdfCodHallazgo").val(),
                        COD_THABILITANTE: data.COD_THABILITANTE,
                        THABILITANTE: data.THABILITANTE,
                        MODALIDAD: data.MODALIDAD,
                        TITULAR: data.TITULAR,
                        RLEGAL: data.RLEGAL,
                        REGION: data.REGION,
                        COD_SECUENCIA: 0,
                        NU_ESTADO: 1,
                        RegEstado: 1
                    };

                    ValidarHallazgo.dtTHabilitanteVinculado.rows.add([fila]).draw();
                    ValidarHallazgo.dtTHabilitanteVinculado.page('last').draw('page');
                    break;
            }

            $("#mdlVincularTH").modal('hide');
        };
    });
};

ValidarHallazgo.fnDelete = function (obj, opc) {
    utilSigo.dialogConfirm("Confirmacion", "¿Está seguro de Eliminar el Registro Seleccionado?",
        function (r) {
            if (r) {
                var $tr = $(obj).parents('tr');
                var row;

                switch (opc) {
                    case 'THabilitante':
                        row = ValidarHallazgo.dtTHabilitanteVinculado.row($tr).data();

                        if (row.RegEstado == 0) {
                            ValidarHallazgo.tbElimTHVinculado.push({
                                NV_TH: row.NV_TH,
                                NV_REPORTEHALLAZGO: ValidarHallazgo.frm.find("#hdfCodHallazgo").val(),
                                COD_THABILITANTE: row.NV_TH,
                                NU_ESTADO: 0,
                                RegEstado: 2
                            });
                        }
                        ValidarHallazgo.dtTHabilitanteVinculado.row($tr).remove().draw(false);
                        utilSigo.enumTB(ValidarHallazgo.dtTHabilitanteVinculado, 1);
                        break;
                }
            }
        });
};

ValidarHallazgo.fnDownloadFile = function (obj) {
    var row = ValidarHallazgo.dtArchivo.row($(obj).parents('tr')).data();

    let url = urlLocalSigo + "Supervision/ReporteVigilancia/DownloadFile";
    let option = { url: url, datos: JSON.stringify({ ruta: row.RUTA }), type: 'POST' };

    utilSigo.fnAjax(option, function (data) {
        if (data.success) {
            ValidarHallazgo.fnGetFile(data.msj, row.NV_NOMBRE);
        }
        else {
            utilSigo.toastWarning("Aviso", "Sucedio un error, Comuníquese con el Administrador");
            console.log(data.msj);
        }
    });

};

ValidarHallazgo.fnGetFile = function (trama, nombre) {
    const byteCharacters = atob(trama);
    const byteArrays = [];

    for (let offset = 0; offset < byteCharacters.length; offset += 512) {
        const slice = byteCharacters.slice(offset, offset + 512);

        const byteNumbers = new Array(slice.length);
        for (let i = 0; i < slice.length; i++) {
            byteNumbers[i] = slice.charCodeAt(i);
        }

        const byteArray = new Uint8Array(byteNumbers);
        byteArrays.push(byteArray);
    }

    const blob = new Blob(byteArrays, { type: 'application/' + nombre.split('.').pop() });
    const blobUrl = URL.createObjectURL(blob);

    const link = document.createElement('a');
    link.href = blobUrl;
    link.download = nombre;
    link.click();
};

ValidarHallazgo.fnGetAllDetHallazgo = function () {
    var list = [], rows, countFilas, data;

    rows = ValidarHallazgo.dtDetHallazgo.$("tr");
    countFilas = rows.length;
    if (countFilas > 0) {
        $.each(rows, function (i, o) {
            data = ValidarHallazgo.dtDetHallazgo.row($(o)).data();
            list.push(utilSigo.fnConvertArrayToObject(data));
        });
    }
    return list;
};

ValidarHallazgo.fnGetListDetHallazgo = function () {
    var list = [], rows, countFilas, data;

    rows = ValidarHallazgo.dtDetHallazgo.$("tr");
    countFilas = rows.length;
    if (countFilas > 0) {
        $.each(rows, function (i, o) {
            data = ValidarHallazgo.dtDetHallazgo.row($(o)).data();
            if (data.RegEstado == 2) {
                list.push(utilSigo.fnConvertArrayToObject(data));
            }
        });
    }
    return list;
};

ValidarHallazgo.fnGetListTHVinculado = function () {
    var list = [], rows, countFilas, data;

    rows = ValidarHallazgo.dtTHabilitanteVinculado.$("tr");
    countFilas = rows.length;
    if (countFilas > 0) {
        $.each(rows, function (i, o) {
            data = ValidarHallazgo.dtTHabilitanteVinculado.row($(o)).data();
            if (data.RegEstado == 1) {
                list.push(utilSigo.fnConvertArrayToObject(data));
            }
        });
    }
    return list;
};

ValidarHallazgo.fnIniProceso = function () {
    let hdfCodHallazgo = ValidarHallazgo.frm.find("#hdfCodHallazgo").val();
    let ddlEstadoId = ValidarHallazgo.frm.find("#ddlEstadoId").val();
    let hdfRegEstado = (ddlEstadoId == "2") ? 3 : 5;

    let model = { hdfCodHallazgo, ddlEstadoId, hdfRegEstado };
    var cad = (ddlEstadoId == "2") ? "¿Está seguro de iniciar procesamiento?" : "¿Está seguro de procesar al registro como no conforme?";

    utilSigo.dialogConfirm("", cad, function (r) {
        if (r) {
            let url = urlLocalSigo + "Supervision/ReporteVigilancia/IniciaProceso";
            let option = { url: url, datos: JSON.stringify(model), type: 'POST' };
            utilSigo.fnAjax(option, function (data) {
                if (data.success) {
                    utilSigo.toastSuccess("Éxito", data.msj);

                    var cboestado = ValidarHallazgo.frm.find("#ddlEstadoId");
                    cboestado.empty();

                    if (ddlEstadoId == "2") {
                        $("#lblTitulo").text("Procesando Registro");
                        $("#btnGuardar").show();
                        ValidarHallazgo.frm.find("#txtnomempresa_validado").removeAttr("disabled");
                        $("#btnTHabilitante").removeAttr("style");
                        ValidarHallazgo.frm.find("#txtobservacion_validado").removeAttr("disabled");
                        $("#divVincularTH").show();
                        ValidarHallazgo.dtTHabilitanteVinculado.column(0).visible(true);

                        cboestado.append(new Option("PROCESAMIENTO INICIADO", "2"));
                        cboestado.append(new Option("PROCESAMIENTO TERMINADO", "3"));
                        ValidarHallazgo.frm.find("#ddlEstadoId").val("2");
                        ValidarHallazgo.frm.find("#idEstado").val("2");

                        if (ValidarHallazgo.idTipoHallazgo == "0000001"
                            || ValidarHallazgo.idTipoHallazgo == "0000002") {
                            var rows = ValidarHallazgo.dtDetHallazgo.$("tr");
                            if (rows.length > 0) {
                                $.each(rows, function (i, o) {
                                    $(o).find("td:first").html('<div><i class="fa fa-lg fa-pencil-square-o" style="color:blue;cursor:pointer;" title="Editar" onclick="ValidarHallazgo.fnAddEditDetHallazgo(this)"></i>');
                                });
                            }
                        }
                    }
                    else {
                        $("#lblTitulo").text("Registro procesado");

                        cboestado.append(new Option("REGISTRO NO CONFORME", "4"));
                        ValidarHallazgo.frm.find("#ddlEstadoId").val("4");
                        ValidarHallazgo.frm.find("#ddlEstadoId").attr("disabled", true);
                        ValidarHallazgo.frm.find("#idEstado").val("4");
                    }

                    $("#btnProcesar").hide();
                    ValidarHallazgo.frm.find("#hdfCodUsuarioControl").val(data.hdfCodUsuarioControl);
                    ValidarHallazgo.frm.find("#txtUsuarioControl").val(data.txtUsuarioControl);
                }
                else {
                    utilSigo.toastWarning("Aviso", "Sucedio un error, Comuníquese con el Administrador");
                    console.log(data.msjError);
                }
            });
        }
    });
};

ValidarHallazgo.fnSaveForm = function () {
    let txtnomempresa_validado = ValidarHallazgo.frm.find("#txtnomempresa_validado").val();
    let ddlTipoResponsableId = ValidarHallazgo.frm.find("#ddlTipoResponsableId").val();
    let hdfCodTHabilitante = ValidarHallazgo.frm.find("#hdfCodTHabilitante").val();

    switch (ValidarHallazgo.idTipoHallazgo) {
        case "0000003":
            if (ddlTipoResponsableId == "0000023") {
                if (txtnomempresa_validado == null ||
                    txtnomempresa_validado.length == 0 ||
                    /^\s+$/.test(txtnomempresa_validado)) {
                    utilSigo.dialogConfirm("", "No se ha validado el nombre del responsable, ¿Esta seguro de continuar?", function (r) {
                        if (r) {
                            ValidarHallazgo.fnGuardarHallazgo();
                        }
                        else return false;
                    });
                }
                else ValidarHallazgo.fnGuardarHallazgo();
            }
            else ValidarHallazgo.fnGuardarHallazgo();
            break;
        case "0000004":
            if (ddlTipoResponsableId == "0000026") {
                if (hdfCodTHabilitante == null || hdfCodTHabilitante == "") {
                    utilSigo.toastWarning("Aviso", "Seleccione al Título Habilitante");
                    return false;
                }
                else ValidarHallazgo.fnGuardarHallazgo();
            }
            else ValidarHallazgo.fnGuardarHallazgo();
            break;
        default:
            ValidarHallazgo.fnGuardarHallazgo();
    }
};

ValidarHallazgo.fnGuardarHallazgo = function () {
    let hdfCodHallazgo = ValidarHallazgo.frm.find("#hdfCodHallazgo").val();
    let hdfCodEquipo = ValidarHallazgo.frm.find("#hdfCodEquipo").val();
    let hdfCodIntegrante = ValidarHallazgo.frm.find("#hdfCodIntegrante").val();
    let hdfCodOrganizacion = ValidarHallazgo.frm.find("#hdfCodOrganizacion").val();
    let ddlTipoHallazgoId = ValidarHallazgo.idTipoHallazgo;
    let txtfecha = ValidarHallazgo.frm.find("#txtfecha").val();
    let txtsector = ValidarHallazgo.frm.find("#txtsector").val();
    let txtnomempresa_validado = ValidarHallazgo.frm.find("#txtnomempresa_validado").val();
    let hdfCodTHabilitante = ValidarHallazgo.frm.find("#hdfCodTHabilitante").val();
    let txtTHabilitante_validado = ValidarHallazgo.frm.find("#txtTHabilitante_validado").val();
    let hdfCodTitular = ValidarHallazgo.frm.find("#hdfCodTitular").val();
    let txtTitular_validado = ValidarHallazgo.frm.find("#txtTitular_validado").val();
    let txtobservacion_validado = ValidarHallazgo.frm.find("#txtobservacion_validado").val();
    let ddlEstadoId = ValidarHallazgo.frm.find("#ddlEstadoId").val();

    var cad = "";

    if (ddlEstadoId == "2") {
        ValidarHallazgo.frm.find("#hdfRegEstado").val(2);
        cad = "¿Está seguro de guardar los datos?";
    }
    else if (ddlEstadoId == "3") {
        ValidarHallazgo.frm.find("#hdfRegEstado").val(4);
        cad = "¿Está seguro de procesar los datos?";

        if (ValidarHallazgo.idTipoHallazgo == "0000001"
            || ValidarHallazgo.idTipoHallazgo == "0000002") {
            var list = ValidarHallazgo.fnGetAllDetHallazgo();
            var band = 0;

            for (let item of list) {
                if (item.NU_ESTADO == 1) {
                    band = 1;
                    break;
                }
            }

            if (band == 1) {
                utilSigo.toastWarning("Aviso", "No se han procesado todos los detalles");
                var idtab = $("#tbDetHallazgo").parents(".tab-pane").attr("id");
                $('a[href="#' + idtab + '"]').tab('show');
                return false;
            }
        }
    }

    let hdfRegEstado = ValidarHallazgo.frm.find("#hdfRegEstado").val();

    let model = {
        hdfCodHallazgo, hdfCodEquipo, hdfCodIntegrante, hdfCodOrganizacion, ddlTipoHallazgoId, txtfecha, txtsector,
        txtnomempresa_validado, hdfCodTHabilitante, txtTHabilitante_validado, hdfCodTitular,
        txtTitular_validado, txtobservacion_validado, ddlEstadoId, hdfRegEstado
    };

    if (ValidarHallazgo.idTipoHallazgo == "0000001"
        || ValidarHallazgo.idTipoHallazgo == "0000002") {
        model.listDetHallazgo = ValidarHallazgo.fnGetListDetHallazgo();
    }
    model.listTHabilitanteVinculado = ValidarHallazgo.fnGetListTHVinculado();
    model.listElimTHabilitanteVinculado = ValidarHallazgo.tbElimTHVinculado;

    utilSigo.dialogConfirm("", cad, function (r) {
        if (r) {
            let url = urlLocalSigo + "Supervision/ReporteVigilancia/Grabar";
            let option = { url: url, datos: JSON.stringify(model), type: 'POST' };
            utilSigo.fnAjax(option, function (data) {
                if (data.success) {
                    utilSigo.toastSuccess("Éxito", data.msj);
                    setTimeout(function () {
                        ValidarHallazgo.regresar();
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

ValidarHallazgo.fnInitDataTable_DetHallazgo = function () {
    var columns_label = [], columns_data = [];

    if (ValidarHallazgo.idTipoHallazgo == "0000001") {
        columns_label = ["", "N°", "Especie", "Volumen (m3)", "Observación", "Estado"];
        columns_data = [
            {
                "data": "", "width": "2%", "orderable": false, "searchable": false, "mRender": function (data, type, row) {
                    if (ValidarHallazgo.frm.find("#idEstado").val() == "1" || ValidarHallazgo.frm.find("#idEstado").val() == "3" || ValidarHallazgo.frm.find("#idEstado").val() == "4")
                        return '<div><i class="fa fa-lg fa-eye" style="color:black;cursor:pointer;" title="Observar" onclick="ValidarHallazgo.fnAddEditDetHallazgo(this)"></i>';
                    else {
                        if (ValidarHallazgo.frm.find("#hdfCodUCuenta").val() != ValidarHallazgo.frm.find("#hdfCodUsuarioControl").val())
                            return '<div><i class="fa fa-lg fa-eye" style="color:black;cursor:pointer;" title="Observar" onclick="ValidarHallazgo.fnAddEditDetHallazgo(this)"></i>';
                        else
                            return '<div><i class="fa fa-lg fa-pencil-square-o" style="color:blue;cursor:pointer;" title="Editar" onclick="ValidarHallazgo.fnAddEditDetHallazgo(this)"></i>';
                    }
                }
            },
            { "name": "ROW_INDE", "width": "2%", "orderable": false, "searchable": false, "defaultContent": "" },
            {
                "data": "", "autoWidth": true, "mRender": function (data, type, row) {
                    if (row.COD_ESPECIES != null)
                        return row.NV_ESPECIES_VALIDADO;
                    else return row.NV_ESPECIES;
                }
            },
            { "data": "NU_VOLUMEN", "autoWidth": true },
            {
                "data": "", "autoWidth": true, "mRender": function (data, type, row) {
                    if (row.NV_OBSERVACION_VALIDADO != null)
                        return row.NV_OBSERVACION_VALIDADO;
                    else return row.NV_OBSERVACION;
                }
            },
            { "data": "ESTADO", "autoWidth": true }
        ];
    }
    else if (ValidarHallazgo.idTipoHallazgo == "0000002") {
        columns_label = ["", "N°", "Especie", "Tipo", "Volumen (pt)", "Volumen (m3)", "Observación", "Estado"];
        columns_data = [
            {
                "data": "", "width": "2%", "orderable": false, "searchable": false, "mRender": function (data, type, row) {
                    if (ValidarHallazgo.frm.find("#idEstado").val() == "1" || ValidarHallazgo.frm.find("#idEstado").val() == "3" || ValidarHallazgo.frm.find("#idEstado").val() == "4")
                        return '<div><i class="fa fa-lg fa-eye" style="color:black;cursor:pointer;" title="Observar" onclick="ValidarHallazgo.fnAddEditDetHallazgo(this)"></i>';
                    else {
                        if (ValidarHallazgo.frm.find("#hdfCodUCuenta").val() != ValidarHallazgo.frm.find("#hdfCodUsuarioControl").val())
                            return '<div><i class="fa fa-lg fa-eye" style="color:black;cursor:pointer;" title="Observar" onclick="ValidarHallazgo.fnAddEditDetHallazgo(this)"></i>';
                        else
                            return '<div><i class="fa fa-lg fa-pencil-square-o" style="color:blue;cursor:pointer;" title="Editar" onclick="ValidarHallazgo.fnAddEditDetHallazgo(this)"></i>';
                    }
                }
            },
            { "name": "ROW_INDE", "width": "2%", "orderable": false, "searchable": false, "defaultContent": "" },
            {
                "data": "", "autoWidth": true, "mRender": function (data, type, row) {
                    if (row.COD_ESPECIES != null)
                        return row.NV_ESPECIES_VALIDADO;
                    else return row.NV_ESPECIES;
                }
            },
            { "data": "NV_DESCRIPCION", "autoWidth": true },
            {
                "data": "", "autoWidth": true, "mRender": function (data, type, row) {
                    if (row.NV_DESCRIPCION == "ASERRADO")
                        return row.NU_VOLUMEN;
                    else return "-";
                }
            },
            {
                "data": "", "autoWidth": true, "mRender": function (data, type, row) {
                    if (row.NV_DESCRIPCION == "ROLLIZA")
                        return row.NU_VOLUMEN;
                    else return "-";
                }
            },
            {
                "data": "", "autoWidth": true, "mRender": function (data, type, row) {
                    if (row.NV_OBSERVACION_VALIDADO != null)
                        return row.NV_OBSERVACION_VALIDADO;
                    else return row.NV_OBSERVACION;
                }
            },
            { "data": "ESTADO", "autoWidth": true }
        ];
    }

    //**Cabecera**----
    var theadTable = "<tr>";
    for (var i = 0; i < columns_label.length; i++) {
        theadTable += '<th>' + columns_label[i] + '</th>';
    }
    theadTable += "</tr>";
    $("#tbDetHallazgo").find("thead").append(theadTable);

    var optDt = { iLength: 20, aSort: [] };

    ValidarHallazgo.dtDetHallazgo = ValidarHallazgo.frm.find("#tbDetHallazgo").DataTable({
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

    ValidarHallazgo.dtDetHallazgo.rows.add(JSON.parse(ValidarHallazgo.DataDetHallazgo)).draw();
    utilSigo.enumTB(ValidarHallazgo.dtDetHallazgo, 1);
};

ValidarHallazgo.fnInitDataTable_THabilitante = function () {
    var columns_label = [], columns_data = [], options = {};
    var idEstado = ValidarHallazgo.frm.find("#idEstado").val();

    columns_label = ["Nro. THabilitante", "Modalidad", "Titular", "R. Legal", "Región"];
    columns_data = ["THABILITANTE", "MODALIDAD", "TITULAR", "RLEGAL", "REGION"];
    options = {
        page_length: 20, row_index: true, row_delete: true, row_fnDelete: "ValidarHallazgo.fnDelete(this,'THabilitante')", page_info: true, page_sort: true
    };
    ValidarHallazgo.dtTHabilitanteVinculado = utilDt.fnLoadDataTable_Detail(ValidarHallazgo.frm.find("#tbTHabilitanteVinculado"), columns_label, columns_data, options);
    ValidarHallazgo.dtTHabilitanteVinculado.rows.add(JSON.parse(ValidarHallazgo.DataTHabilitanteVinculado)).draw();

    if (idEstado == "1" || idEstado == "3" || idEstado == "4") {
        ValidarHallazgo.dtTHabilitanteVinculado.column(0).visible(false);
    }
    else {
        if (ValidarHallazgo.frm.find("#hdfCodUCuenta").val() != ValidarHallazgo.frm.find("#hdfCodUsuarioControl").val()) {
            ValidarHallazgo.dtTHabilitanteVinculado.column(0).visible(false);
        }
    }
};

ValidarHallazgo.fnInitDataTable_Archivo = function () {
    var columns_label = [], columns_data = [];

    columns_label = ["", "N°", "Nombre"];
    columns_data = [
        {
            "data": "", "width": "2%", "orderable": false, "searchable": false, "mRender": function (data, type, row) {
                return '<div><i class="fa fa-lg fa-download" style="color:black;cursor:pointer;" title="Descargar" onclick="ValidarHallazgo.fnDownloadFile(this)"></i>';
            }
        },
        { "name": "ROW_INDE", "width": "2%", "orderable": false, "searchable": false, "defaultContent": "" },
        { "data": "NV_NOMBRE", "autoWidth": true }
    ];

    //**Cabecera**----
    var theadTable = "<tr>";
    for (var i = 0; i < columns_label.length; i++) {
        theadTable += '<th>' + columns_label[i] + '</th>';
    }
    theadTable += "</tr>";
    $("#tbArchivo").find("thead").append(theadTable);

    var optDt = { iLength: 20, aSort: [] };

    ValidarHallazgo.dtArchivo = ValidarHallazgo.frm.find("#tbArchivo").DataTable({
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

    ValidarHallazgo.dtArchivo.rows.add(JSON.parse(ValidarHallazgo.DataArchivo)).draw();
    utilSigo.enumTB(ValidarHallazgo.dtArchivo, 1);
};

ValidarHallazgo.fnInitEventos = function () {
    ValidarHallazgo.frm.find("#txtfecha").datepicker({ format: "dd/mm/yyyy", autoclose: true, language: 'es' });
    ValidarHallazgo.frm.find("#idEstado").val(ValidarHallazgo.frm.find("#ddlEstadoId").val());

    var idTipoResponsable = ValidarHallazgo.frm.find("#ddlTipoResponsableId").val();
    var estado = ValidarHallazgo.frm.find("#ddlEstadoId").val();

    if (ValidarHallazgo.idTipoHallazgo != "0000001"
        && ValidarHallazgo.idTipoHallazgo != "0000002") {
        $("#idNavDetalles").hide();
        if (ValidarHallazgo.idTipoHallazgo == "0000003") {
            if (idTipoResponsable == "0000024") {
                $("#dvNombre").hide();
                $("#dvNombreValidado").hide();
            }
        }
    }

    if (idTipoResponsable == "0000026") {
        $("#dvTHabilitante").show();
        $("#dvTHabilitante_validado").show();
        $("#dvTitular").show();
    }

    if (estado == "1" || estado == "3" || estado == "4") {
        $("#btnGuardar").hide();
        ValidarHallazgo.frm.find("#txtnomempresa_validado").attr("disabled", true);
        $("#btnTHabilitante").attr("style", "pointer-events: none; cursor: default;");
        ValidarHallazgo.frm.find("#txtobservacion_validado").attr("disabled", true);
        $("#divVincularTH").hide();

        if (estado == "1") {
            $("#lblTitulo").text("Procesar Registro");
            $('a[href="#navEstado"]').tab('show');
        }
        else {
            $("#lblTitulo").text("Registro procesado");
            $('a[href="#navDatos"]').tab('show');
            ValidarHallazgo.frm.find("#ddlEstadoId").attr("disabled", true);
            $("#btnProcesar").hide();
        }
    }
    else {
        $('a[href="#navDatos"]').tab('show');
        $("#btnProcesar").hide();

        if (ValidarHallazgo.frm.find("#hdfCodUCuenta").val() != ValidarHallazgo.frm.find("#hdfCodUsuarioControl").val()) {
            $("#btnGuardar").hide();
            ValidarHallazgo.frm.find("#txtnomempresa_validado").attr("disabled", true);
            $("#btnTHabilitante").attr("style", "pointer-events: none; cursor: default;");
            ValidarHallazgo.frm.find("#txtobservacion_validado").attr("disabled", true);
            $("#divVincularTH").hide();
            ValidarHallazgo.frm.find("#ddlEstadoId").attr("disabled", true);
        }
    }

    ValidarHallazgo.frm.find("#btnTHabilitante").click(function () {
        ValidarHallazgo.fnVincularTH("TH");
    });

    if (ValidarHallazgo.frm.find("#idEstado").val() == estado) {
        $("#btnProcesar").attr("disabled", true);
    }

    ValidarHallazgo.frm.find("#ddlEstadoId").change(function () {
        if (ValidarHallazgo.frm.find("#idEstado").val() == ValidarHallazgo.frm.find("#ddlEstadoId").val()) {
            $("#btnProcesar").attr("disabled", true);
        }
        else {
            $("#btnProcesar").removeAttr("disabled");
        }
    });
};

$(document).ready(function () {
    ValidarHallazgo.frm = $("#frmValidarHallazgo");

    $('[data-toggle="tooltip"]').tooltip();

    ValidarHallazgo.idTipoHallazgo = ValidarHallazgo.frm.find("#ddlTipoHallazgoId").val();
    ValidarHallazgo.fnInitEventos();
    ValidarHallazgo.fnInitDataTable_THabilitante();
    ValidarHallazgo.fnInitDataTable_Archivo();

    if (ValidarHallazgo.idTipoHallazgo == "0000001"
        || ValidarHallazgo.idTipoHallazgo == "0000002") {
        ValidarHallazgo.fnInitDataTable_DetHallazgo();
    }
});