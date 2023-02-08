var AddEditPM = {};
"use strict";
AddEditPM.trEdit = "";
AddEditPM.ListEliTABLA = [];
AddEditPM.banderaCKEDITOR = 0;
AddEditPM.banderaCKEDITORBD = 0;

AddEditPM.regresar = function (msj, appServer) { 
    if (AddEditPM.frm.find("#opRegresar").val() == 0) {
        var url = urlLocalSigo + "THabilitante/ManPlanManejo/Index?_alertaIncial=" + msj;
        window.location = url;
    } else {
        var appClient = AddEditPM.frm.find("#appClient").val();
        var appData = AddEditPM.frm.find("#appData").val();
        var url = urlLocalSigo + "THabilitante/ManVentanillaAntecedentesExpedientes/Index?appClient=" + appClient + "&appData=" + appData + "&appServer=" + appServer;
        window.location = url;
    }
}
AddEditPM.fnGetObject = function (dt) {
    var list = [];
    dt.rows().every(function (rowIdx, tableLoop, rowLoop) {
        var row = this.data();
        if (row.RegEstado == RegEstadoSigo.NEW || row.RegEstado == RegEstadoSigo.UPDATE) {
            list.push(row);
        }
    });
    return list;
}
AddEditPM.fnExistData = function (dt, key, value, msj) {
    var bandera = false;
    dt.rows().every(function (rowIdx, tableLoop, rowLoop) {
        var row = this.data();
        if (row[key].trim() == value.trim()) {
            utilSigo.toastWarning("Aviso", msj);
            bandera = true;
        }
    });
    return bandera;
}
AddEditPM.fnGetRowId = function (dt, key, value) {
    var index = -1;
    dt.rows().every(function (rowIdx, tableLoop, rowLoop) {
        var row = this.data();
        if (row[key].trim() == value.trim()) {
            index = rowIdx;
        }
    });
    return index;
}
AddEditPM.fnAddEliTabla = function (_EliTABLA, _EliVALOR01, _EliVALOR02) {
    AddEditPM.ListEliTABLA.push({
        EliTABLA: _EliTABLA,
        EliVALOR01: _EliVALOR01,
        EliVALOR02: _EliVALOR02
    });
}
AddEditPM.fnDeleteAllCArea = function () {
    var $trsEliminar = AddEditPM.dtItemISituCArea.$("tr");
    if ($trsEliminar.length <= 0) return false;
    utilSigo.dialogConfirm("Confirmacion", "Está seguro de Eliminar Todos los Registros?",
        function (r) {
            if (r) {
                AddEditPM.dtItemISituCArea.rows().every(function (rowIdx, tableLoop, rowLoop) {
                    var row = this.data();
                    if (row.RegEstado == RegEstadoSigo.INITIAL || row.RegEstado == RegEstadoSigo.UPDATE) {
                        AddEditPM.fnAddEliTabla("PLAN_MANEJO_INSITU_CAREA", row.COD_CAREA, 0);
                    }
                });
                AddEditPM.dtItemISituCArea.clear().draw();
            }
        });
}
AddEditPM.fnDeleteAllTaraCUTM = function () {
    var $trsEliminar = AddEditPM.dtItemTaraCUTM.$("tr");
    if ($trsEliminar.length <= 0) return false;
    utilSigo.dialogConfirm("Confirmacion", "Está seguro de Eliminar Todos los Registros?",
        function (r) {
            if (r) {
                AddEditPM.dtItemTaraCUTM.rows().every(function (rowIdx, tableLoop, rowLoop) {
                    var row = this.data();
                    if (row.RegEstado == RegEstadoSigo.INITIAL || row.RegEstado == RegEstadoSigo.UPDATE) {
                        AddEditPM.fnAddEliTabla("PLAN_MANEJO_TARA_DET_COORDENADAUTM", "", row.COD_SECUENCIAL);
                    }
                });
                AddEditPM.dtItemTaraCUTM.clear().draw();
            }
        });
}
AddEditPM.fnDeleteAllTaraInventario = function () {
    var $trsEliminar = AddEditPM.dtItemTaraInventario.$("tr");
    if ($trsEliminar.length <= 0) return false;
    utilSigo.dialogConfirm("Confirmacion", "Está seguro de Eliminar Todos los Registros?",
        function (r) {
            if (r) {
                AddEditPM.dtItemTaraInventario.rows().every(function (rowIdx, tableLoop, rowLoop) {
                    var row = this.data();
                    if (row.RegEstado == RegEstadoSigo.INITIAL || row.RegEstado == RegEstadoSigo.UPDATE) {
                        AddEditPM.fnAddEliTabla("PLAN_MANEJO_TARA_DET_INVENTARIO", "", row.COD_SECUENCIAL);
                    }
                });
                AddEditPM.dtItemTaraInventario.clear().draw();

            }
        });
}
AddEditPM.fnDeleteAllInventarioFauna = function () {
    var $trsEliminar = AddEditPM.dtItemISituInvFauna.$("tr");
    if ($trsEliminar.length <= 0) return false;
    utilSigo.dialogConfirm("Confirmacion", "Está seguro de Eliminar Todos los Registros?",
        function (r) {
            if (r) {
                AddEditPM.dtItemISituInvFauna.rows().every(function (rowIdx, tableLoop, rowLoop) {
                    var row = this.data();
                    if (row.RegEstado == RegEstadoSigo.INITIAL || row.RegEstado == RegEstadoSigo.UPDATE) {
                        AddEditPM.fnAddEliTabla("PLAN_MANEJO_INSITU_DET_INV_FAUNA", row.COD_ESPECIES, row.COD_SECUENCIAL);
                    }
                });
                AddEditPM.dtItemISituInvFauna.clear().draw();

            }
        });
}
AddEditPM.fnDeleteAllInventarioFlora = function () {
    var $trsEliminar = AddEditPM.dtItemISituInvFlora.$("tr");
    if ($trsEliminar.length <= 0) return false;
    utilSigo.dialogConfirm("Confirmacion", "Está seguro de Eliminar Todos los Registros?",
        function (r) {
            if (r) {
                AddEditPM.dtItemISituInvFlora.rows().every(function (rowIdx, tableLoop, rowLoop) {
                    var row = this.data();
                    if (row.RegEstado == RegEstadoSigo.INITIAL || row.RegEstado == RegEstadoSigo.UPDATE) {
                        AddEditPM.fnAddEliTabla("PLAN_MANEJO_INSITU_DET_INV_FLORA", row.COD_ESPECIES, row.COD_SECUENCIAL);
                    }
                });
                AddEditPM.dtItemISituInvFlora.clear().draw();

            }
        });
}
AddEditPM.fnDelete = function (obj, opcion) {
    utilSigo.dialogConfirm("Confirmacion", "¿Está seguro de Eliminar el Registro Seleccionado?",
        function (r) {
            if (r) {
                //grvItemTaraCUTM - 0,grvItemTRAprobacion - 1,grvItemIOcular - 2,grvItemTaraAutoExtraer - 7
                var $tr = $(obj).closest('tr');
                switch (parseInt(opcion)) {
                    case 0:
                        var row = AddEditPM.dtItemTaraCUTM.row($tr).data();
                        AddEditPM.dtItemTaraCUTM.row($tr).remove().draw(false);
                        utilDt.enumColumn(AddEditPM.dtItemTaraCUTM, "IND");
                        if (row.RegEstado == RegEstadoSigo.INITIAL || row.RegEstado == RegEstadoSigo.UPDATE) {
                            AddEditPM.fnAddEliTabla("PLAN_MANEJO_TARA_DET_COORDENADAUTM", "", row.COD_SECUENCIAL);
                        }
                        break;
                    case 1:
                        var row = AddEditPM.dtItemTRAprobacion.row($tr).data();
                        AddEditPM.dtItemTRAprobacion.row($tr).remove().draw(false);
                        utilDt.enumColumn(AddEditPM.dtItemTRAprobacion, "IND");
                        if (row.RegEstado == RegEstadoSigo.INITIAL || row.RegEstado == RegEstadoSigo.UPDATE) {
                            AddEditPM.fnAddEliTabla("PLAN_MANEJO_DET_TRAPROBACION", row.COD_PERSONA, 0);
                        }
                        break;
                    case 2:
                        var row = AddEditPM.dtItemIOcular.row($tr).data();
                        AddEditPM.dtItemIOcular.row($tr).remove().draw(false);
                        utilDt.enumColumn(AddEditPM.dtItemIOcular, "IND");
                        if (row.RegEstado == RegEstadoSigo.INITIAL || row.RegEstado == RegEstadoSigo.UPDATE) {
                            AddEditPM.fnAddEliTabla("PLAN_MANEJO_DET_TIOCULAR", row.COD_PERSONA, 0);
                        }
                        break;
                    case 3:
                        var row = AddEditPM.dtItemTaraAEAprov.row($tr).data();
                        AddEditPM.dtItemTaraAEAprov.row($tr).remove().draw(false);
                        utilDt.enumColumn(AddEditPM.dtItemTaraAEAprov, "IND");
                        if (row.RegEstado == RegEstadoSigo.INITIAL || row.RegEstado == RegEstadoSigo.UPDATE) {
                            AddEditPM.fnAddEliTabla("PLAN_MANEJO_TARA_DET_AAPROVECHAMIENTO", "", row.COD_SECUENCIAL);
                        }
                        break;
                    case 4:
                        var row = AddEditPM.dtItemTaraPApro.row($tr).data();
                        AddEditPM.dtItemTaraPApro.row($tr).remove().draw(false);
                        utilDt.enumColumn(AddEditPM.dtItemTaraPApro, "IND");
                        if (row.RegEstado == RegEstadoSigo.INITIAL || row.RegEstado == RegEstadoSigo.UPDATE) {
                            AddEditPM.fnAddEliTabla("PLAN_MANEJO_TARA_DET_PAPROVECHAMIENTO", "", row.COD_SECUENCIAL);
                        }
                        break;
                    case 5:
                        var row = AddEditPM.dtItemTaraESistemaA.row($tr).data();
                        AddEditPM.dtItemTaraESistemaA.row($tr).remove().draw(false);
                        utilDt.enumColumn(AddEditPM.dtItemTaraESistemaA, "IND");
                        if (row.RegEstado == RegEstadoSigo.INITIAL || row.RegEstado == RegEstadoSigo.UPDATE) {
                            AddEditPM.fnAddEliTabla("PLAN_MANEJO_TARA_DET_OPCIONES", row.COD_PMTOPCIONES, 0);
                        }
                        break;
                    case 6:
                        var row = AddEditPM.dtItemTaraPSilvicultural.row($tr).data();
                        AddEditPM.dtItemTaraPSilvicultural.row($tr).remove().draw(false);
                        utilDt.enumColumn(AddEditPM.dtItemTaraPSilvicultural, "IND");
                        if (row.RegEstado == RegEstadoSigo.INITIAL || row.RegEstado == RegEstadoSigo.UPDATE) {
                            AddEditPM.fnAddEliTabla("PLAN_MANEJO_TARA_DET_OPCIONES", row.COD_PMTOPCIONES, 0);
                        }
                        break;
                    case 7:
                        var row = AddEditPM.dtItemTaraAutoExtraer.row($tr).data();
                        AddEditPM.dtItemTaraAutoExtraer.row($tr).remove().draw(false);
                        utilDt.enumColumn(AddEditPM.dtItemTaraAutoExtraer, "IND");
                        if (row.RegEstado == RegEstadoSigo.INITIAL || row.RegEstado == RegEstadoSigo.UPDATE) {
                            AddEditPM.fnAddEliTabla("PLAN_MANEJO_TARA_DET_CAUTO_EXTRAER", "", row.COD_SECUENCIAL);
                        }
                        break;
                    case 8:
                        var row = AddEditPM.dtItemTaraInventario.row($tr).data();
                        AddEditPM.dtItemTaraInventario.row($tr).remove().draw(false);
                        utilDt.enumColumn(AddEditPM.dtItemTaraInventario, "IND");
                        if (row.RegEstado == RegEstadoSigo.INITIAL || row.RegEstado == RegEstadoSigo.UPDATE) {
                            AddEditPM.fnAddEliTabla("PLAN_MANEJO_TARA_DET_INVENTARIO", "", row.COD_SECUENCIAL);
                        }
                        break;
                    case 9:
                        var row = AddEditPM.dtItemEcotPImplementar.row($tr).data();
                        AddEditPM.dtItemEcotPImplementar.row($tr).remove().draw(false);
                        utilDt.enumColumn(AddEditPM.dtItemEcotPImplementar, "IND");
                        if (row.RegEstado == RegEstadoSigo.INITIAL || row.RegEstado == RegEstadoSigo.UPDATE) {
                            AddEditPM.fnAddEliTabla("PLAN_MANEJO_TARA_DET_OPCIONES", row.COD_PMTOPCIONES, 0);
                        }
                        break;
                    case 10:
                        var row = AddEditPM.dtItemEcotInformeAnual.row($tr).data();
                        AddEditPM.dtItemEcotInformeAnual.row($tr).remove().draw(false);
                        utilDt.enumColumn(AddEditPM.dtItemEcotInformeAnual, "IND");
                        if (row.RegEstado == RegEstadoSigo.INITIAL || row.RegEstado == RegEstadoSigo.UPDATE) {
                            AddEditPM.fnAddEliTabla("PLAN_MANEJO_EXSITU_DET_IANUAL", "", row.COD_SECUENCIAL);
                        }
                        break;
                    case 11:
                        var row = AddEditPM.dtItemISituCArea.row($tr).data();
                        AddEditPM.dtItemISituCArea.row($tr).remove().draw(false);
                        utilDt.enumColumn(AddEditPM.dtItemISituCArea, "IND");
                        if (row.RegEstado == RegEstadoSigo.INITIAL || row.RegEstado == RegEstadoSigo.UPDATE) {
                            AddEditPM.fnAddEliTabla("PLAN_MANEJO_INSITU_CAREA", row.COD_CAREA, 0);
                        }
                        break;
                    case 12:
                        var row = AddEditPM.dtItemISituInvFauna.row($tr).data();
                        AddEditPM.dtItemISituInvFauna.row($tr).remove().draw(false);
                        utilDt.enumColumn(AddEditPM.dtItemISituInvFauna, "IND");
                        if (row.RegEstado == RegEstadoSigo.INITIAL || row.RegEstado == RegEstadoSigo.UPDATE) {
                            AddEditPM.fnAddEliTabla("PLAN_MANEJO_INSITU_DET_INV_FAUNA", row.COD_ESPECIES, row.COD_SECUENCIAL);
                        }
                        break;
                    case 13:
                        var row = AddEditPM.dtItemISituInvFlora.row($tr).data();
                        AddEditPM.dtItemISituInvFlora.row($tr).remove().draw(false);
                        utilDt.enumColumn(AddEditPM.dtItemISituInvFlora, "IND");
                        if (row.RegEstado == RegEstadoSigo.INITIAL || row.RegEstado == RegEstadoSigo.UPDATE) {
                            AddEditPM.fnAddEliTabla("PLAN_MANEJO_INSITU_DET_INV_FLORA", row.COD_ESPECIES, row.COD_SECUENCIAL);
                        }
                        break;

                }
            }
        });

}
AddEditPM.fnDownloadPlantilla = function (opcion) {
    switch (opcion) {
        case "TaraCUTM":
            window.location.href = urlLocalSigo + "/Archivos/Plantilla/PManejoTaraVertice.xlsx";
            break;
        case "TaraInventario":
            window.location.href = urlLocalSigo + "/Archivos/Plantilla/PManejoTaraInventario.xlsx";
            break;
    }
}
AddEditPM.fnImportarExcel = function (e, objeto, opcion) {
    switch (opcion) {
        case "TaraCUTM":
            var ruta = urlLocalSigo + "THabilitante/ManPlanManejo/ImportarExcelCUTM";
            uploadFile.fileSelectHandler(e, objeto, ruta, {}, function (data) {
                AddEditPM.dtItemTaraCUTM.rows.add(data).draw();
                AddEditPM.dtItemTaraCUTM.page('last').draw('page');
            });
            break;
        case "TaraInventario":
            var ruta = urlLocalSigo + "THabilitante/ManPlanManejo/ImportarExcelInventario";
            uploadFile.fileSelectHandler(e, objeto, ruta, {}, function (data) {
                AddEditPM.dtItemTaraInventario.rows.add(data).draw();
                AddEditPM.dtItemTaraInventario.page('last').draw('page');
            });
            break;
    }
}

AddEditPM.fnBuscarPersona = function (_dom, _tipoPersonaSIGOsfc) {
    var url = urlLocalSigo + "General/Controles/_BuscarPersonaGeneral";
    var option = { url: url, type: 'GET', datos: { asBusGrupo: "PERSONA", asCodPTipo: _tipoPersonaSIGOsfc, asTipoPersona: "N" }, divId: "mdlBuscarPersona" };
    utilSigo.fnOpenModal(option, function () {
        _bPerGen.fnAsignarDatos = function (obj) {
            if (obj != null && obj != "") {
                var data = _bPerGen.dtBuscarPerona.row($(obj).parents('tr')).data();
                switch (_dom) {
                    case "REGENTE":
                        debugger
                        AddEditPM.fnSetPersonaCompleto(_dom, data["COD_PERSONA"]);
                        AddEditPM.frm.find("#txtCodUbigeo").val(data["COD_UBIGEO"]);
                        AddEditPM.frm.find("#txtUbigeo").val(data["UBIGEO"]);
                        AddEditPM.frm.find("#txtDirecion").val(data["DIRECCION"]);
                        break;
                   // case "CONSULTOR":
                    case "FRAPRUEBA":
                    case "FRAPRUEBA_FIRMA":
                        AddEditPM.fnSetPersonaCompleto(_dom, data["COD_PERSONA"]); break;
                    case "IOCULAR":
                        if (!AddEditPM.fnExistData(AddEditPM.dtItemIOcular, "COD_PERSONA", data["COD_PERSONA"], "El Técnico de Inspección Ocular ya Existe")) {
                            AddEditPM.fnSetPersonaCompleto(_dom, data["COD_PERSONA"]);
                        }
                        break;
                    case "ITAPROBACION":
                        if (!AddEditPM.fnExistData(AddEditPM.dtItemTRAprobacion, "COD_PERSONA", data["COD_PERSONA"], "El Técnico que Recomienda la Aprobación ya Existe")) {
                            AddEditPM.fnSetPersonaCompleto(_dom, data["COD_PERSONA"]);
                        }
                        break;
                }
                utilSigo.fnCloseModal("mdlBuscarPersona");
            }
        }
        _bPerGen.fnInit();
    });
}
AddEditPM.fnSetPersonaCompleto = function (_dom, codPersona) {
    $.ajax({
        url: urlLocalSigo + "General/Controles/GetPersona",
        type: 'POST',
        data: { asCodPersona: codPersona },
        dataType: 'json',
        beforeSend: utilSigo.beforeSendAjax,
        complete: utilSigo.completeAjax,
        error: utilSigo.errorAjax,
        success: function (data) {
            if (data.success) {
                switch (_dom) {
                    case "REGENTE":
                  // case "CONSULTOR":
                        AddEditPM.frm.find("#lblItemConsultorNombre").val(data.data["APELLIDOS_NOMBRES"]);
                        AddEditPM.frm.find("#hdlblItemConsultorNombre").val(data.data["COD_PERSONA"]);
                        AddEditPM.frm.find("#lblItemConsultorDNI").val(data.data["N_DOCUMENTO"]);
                        AddEditPM.frm.find("#txtItemConsultorNRConsultor").val(data.data["NUM_REGISTRO_FFS"]);
                        AddEditPM.frm.find("#lblItemConsultorNRProfesional").val(data.data["NUM_REGISTRO_PROFESIONAL"]);
                       
                        AddEditPM.validaAdicional();
                        break;
                    case "IOCULAR":
                        var item = { CARGO: data.data["CARGO"], COD_PERSONA: data.data["COD_PERSONA"], N_DOCUMENTO: data.data["N_DOCUMENTO"], PERSONA: data.data["APELLIDOS_NOMBRES"], RegEstado: "1" };
                        AddEditPM.dtItemIOcular.row.add(item).draw();
                        AddEditPM.dtItemIOcular.page('last').draw('page');
                        break;
                    case "ITAPROBACION":
                        var item = { CARGO: data.data["CARGO"], COD_PERSONA: data.data["COD_PERSONA"], N_DOCUMENTO: data.data["N_DOCUMENTO"], PERSONA: data.data["APELLIDOS_NOMBRES"], RegEstado: "1" };
                        AddEditPM.dtItemTRAprobacion.row.add(item).draw();
                        AddEditPM.dtItemTRAprobacion.page('last').draw('page');
                        break;
                    case "FRAPRUEBA":
                        var datosP = `${data.data["APELLIDOS_NOMBRES"].trim()} ( ${data.data["N_DOCUMENTO"].trim()} - ${data.data["CARGO"].trim()} )`;
                        AddEditPM.frm.find("#lblItemARFuncionario").val(datosP);
                        AddEditPM.frm.find("#hdlblItemARFuncionario").val(data.data["COD_PERSONA"]);
                        break;
                    case "FRAPRUEBA_FIRMA":
                        var datosP = `${data.data["APELLIDOS_NOMBRES"].trim()} ( ${data.data["N_DOCUMENTO"].trim()} - ${data.data["CARGO"].trim()} )`;
                        AddEditPM.frm.find("#lblAPROB_ACTIVIDAD_NOM_FUNCIONARIO").val(datosP);
                        AddEditPM.frm.find("#hdlblAPROB_ACTIVIDAD_NOM_FUNCIONARIO").val(data.data["COD_PERSONA"]);
                        break;
                }
                utilSigo.fnCloseModal("modalBuscarPersona");
            } else {
                utilSigo.toastError("Error", "No se pudo consultar los datos de la persona");
                //console.log(data.msj);
                return false;
            }
        }
    });
}

AddEditPM.fnAddEditTaraCUTM = function (obj) {
    var url = urlLocalSigo + "THabilitante/ManPlanManejo/_CoordenadaUTM";
    var option = { url: url, type: 'GET', datos: {}, divId: "modalAddEdit" };
    var dataRow = {};
    if (obj != "") { //editar
        AddEditPM.trEdit = $(obj).closest('tr');
        dataRow = AddEditPM.dtItemTaraCUTM.row(AddEditPM.trEdit).data();
    }
    utilSigo.fnOpenModal(option, function () {
        _CoorUTM.fnAsignar = function (rowObj) {
            if (parseInt(rowObj.RegEstadoClient) == RegEstadoSigo.NEW) {
                AddEditPM.dtItemTaraCUTM.row.add(rowObj).draw();
                AddEditPM.dtItemTaraCUTM.page('last').draw('page');
                utilSigo.toastSuccess("Aviso", "Se adiciono con éxito");
            }
            else {
                if (rowObj.RegEstado == RegEstadoSigo.INITIAL)
                    rowObj.RegEstado = RegEstadoSigo.UPDATE;
                AddEditPM.dtItemTaraCUTM.row(AddEditPM.trEdit).data(rowObj).draw(false);
                AddEditPM.trEdit = "";
                utilSigo.toastSuccess("Aviso", "Se modifico con éxito");
                utilSigo.fnCloseModal("modalAddEdit");
            }
        }
        _CoorUTM.init(dataRow);

    });
}
AddEditPM.fnAddEditTaraAEAprov = function (obj) {
    var url = urlLocalSigo + "THabilitante/ManPlanManejo/_ItemTaraAEAprov";
    var option = { url: url, type: 'GET', datos: {}, divId: "modalAddEdit" };
    var dataRow = {};
    if (obj != "") { //editar
        AddEditPM.trEdit = $(obj).closest('tr');
        dataRow = AddEditPM.dtItemTaraAEAprov.row(AddEditPM.trEdit).data();
    }
    utilSigo.fnOpenModal(option, function () {
        _ItemTaraAEAprov.fnAsignar = function (rowObj) {
            if (parseInt(rowObj.RegEstadoClient) == RegEstadoSigo.NEW) {
                AddEditPM.dtItemTaraAEAprov.row.add(rowObj).draw();
                AddEditPM.dtItemTaraAEAprov.page('last').draw('page');
                utilSigo.toastSuccess("Aviso", "Se adiciono con éxito");
            }
            else {
                if (rowObj.RegEstado == RegEstadoSigo.INITIAL)
                    rowObj.RegEstado = RegEstadoSigo.UPDATE;
                AddEditPM.dtItemTaraAEAprov.row(AddEditPM.trEdit).data(rowObj).draw(false);
                AddEditPM.trEdit = "";
                utilSigo.toastSuccess("Aviso", "Se modifico con éxito");
                utilSigo.fnCloseModal("modalAddEdit");
            }
        }
        _ItemTaraAEAprov.init(dataRow);

    });
}
AddEditPM.fnAddEditTaraPApro = function (obj) {
    var url = urlLocalSigo + "THabilitante/ManPlanManejo/_ItemTaraPApro";
    var option = { url: url, type: 'GET', datos: {}, divId: "modalAddEdit" };
    var dataRow = {};
    if (obj != "") { //editar
        AddEditPM.trEdit = $(obj).closest('tr');
        dataRow = AddEditPM.dtItemTaraPApro.row(AddEditPM.trEdit).data();
    }
    utilSigo.fnOpenModal(option, function () {
        _ItemTaraPApro.fnAsignar = function (rowObj) {
            if (parseInt(rowObj.RegEstadoClient) == RegEstadoSigo.NEW) {
                AddEditPM.dtItemTaraPApro.row.add(rowObj).draw();
                AddEditPM.dtItemTaraPApro.page('last').draw('page');
                utilSigo.toastSuccess("Aviso", "Se adiciono con éxito");
            }
            else {
                if (rowObj.RegEstado == RegEstadoSigo.INITIAL)
                    rowObj.RegEstado = RegEstadoSigo.UPDATE;
                AddEditPM.dtItemTaraPApro.row(AddEditPM.trEdit).data(rowObj).draw(false);
                AddEditPM.trEdit = "";
                utilSigo.toastSuccess("Aviso", "Se modifico con éxito");
                utilSigo.fnCloseModal("modalAddEdit");
            }
        }
        _ItemTaraPApro.init(dataRow);

    });
}

AddEditPM.fnAddEditTaraOpcion = function (obj, opcion) {
    //hdfItemIndicador si indicador es "CS", por defecto entrara la opcion "CS"
    //0=SA,1=PS,2=PI
    var opcionVentana = "";
    var dtOpcion = "";
    switch (parseInt(opcion)) {
        case 0: opcionVentana = "SA"; dtOpcion = AddEditPM.dtItemTaraESistemaA; break;
        case 1: opcionVentana = "PS"; dtOpcion = AddEditPM.dtItemTaraPSilvicultural; break;
        case 2: opcionVentana = "PI"; dtOpcion = AddEditPM.dtItemEcotPImplementar; break;
    }
    if (AddEditPM.frm.find("#hdfItemIndicador").val().trim() == "CS") {
        opcionVentana = "CS"
    }
    var url = urlLocalSigo + "THabilitante/ManPlanManejo/_ItemTaraOpcion";
    var option = { url: url, type: 'GET', datos: { hdTaraOpionVentana: opcionVentana }, divId: "modalAddEditSelect2" };
    var dataRow = {};
    if (obj != "") { //editar
        AddEditPM.trEdit = $(obj).closest('tr');
        dataRow = dtOpcion.row(AddEditPM.trEdit).data();
    }
    utilSigo.fnOpenModal(option, function () {
        _ItemTaraOpcion.fnAsignar = function (rowObj) {
            if (parseInt(rowObj.RegEstadoClient) == RegEstadoSigo.NEW) {
                if (AddEditPM.fnExistData(dtOpcion, "COD_PMTOPCIONES", rowObj.COD_PMTOPCIONES, "La Opción Seleccionada ya Existe")) {
                    return false;
                }
                dtOpcion.row.add(rowObj).draw();
                dtOpcion.page('last').draw('page');
                utilSigo.toastSuccess("Aviso", "Se adiciono con éxito");
            }
            else {
                if (rowObj.RegEstado == RegEstadoSigo.INITIAL)
                    rowObj.RegEstado = RegEstadoSigo.UPDATE;
                dtOpcion.row(AddEditPM.trEdit).data(rowObj).draw(false);
                AddEditPM.trEdit = "";
                utilSigo.toastSuccess("Aviso", "Se modifico con éxito");
                utilSigo.fnCloseModal("modalAddEditSelect2");
            }
        }
        _ItemTaraOpcion.init(dataRow);
        // //console.log(AddEditPM.fnGetObject(dtOpcion));
    });
}
AddEditPM.fnAddEditTaraAutoExtraer = function (obj) {
    var url = urlLocalSigo + "THabilitante/ManPlanManejo/_ItemTaraAutoExtraer";
    var option = { url: url, type: 'GET', datos: {}, divId: "modalAddEditSelect2" };
    var dataRow = {};
    if (obj != "") { //editar
        AddEditPM.trEdit = $(obj).closest('tr');
        dataRow = AddEditPM.dtItemTaraAutoExtraer.row(AddEditPM.trEdit).data();
    }
    utilSigo.fnOpenModal(option, function () {
        _TaraAutoExtraer.fnAsignar = function (rowObj) {
            if (parseInt(rowObj.RegEstadoClient) == RegEstadoSigo.NEW) {
                AddEditPM.dtItemTaraAutoExtraer.row.add(rowObj).draw();
                AddEditPM.dtItemTaraAutoExtraer.page('last').draw('page');
                utilSigo.toastSuccess("Aviso", "Se adiciono con éxito");
            }
            else {
                if (rowObj.RegEstado == RegEstadoSigo.INITIAL)
                    rowObj.RegEstado = RegEstadoSigo.UPDATE;
                AddEditPM.dtItemTaraAutoExtraer.row(AddEditPM.trEdit).data(rowObj).draw(false);
                AddEditPM.trEdit = "";
                utilSigo.toastSuccess("Aviso", "Se modifico con éxito");
                utilSigo.fnCloseModal("modalAddEditSelect2");
            }
        }
        _TaraAutoExtraer.init(dataRow);

    });
}
AddEditPM.fnAddEditTaraInventario = function (obj) {
    var url = urlLocalSigo + "THabilitante/ManPlanManejo/_ItemTaraInventario";
    var option = { url: url, type: 'GET', datos: {}, divId: "modalAddEditSelect2" };
    var dataRow = {};
    if (obj != "") { //editar
        AddEditPM.trEdit = $(obj).closest('tr');
        dataRow = AddEditPM.dtItemTaraInventario.row(AddEditPM.trEdit).data();
    }
    utilSigo.fnOpenModal(option, function () {
        _TaraInventario.fnAsignar = function (rowObj) {
            if (parseInt(rowObj.RegEstadoClient) == RegEstadoSigo.NEW) {
                AddEditPM.dtItemTaraInventario.row.add(rowObj).draw();
                AddEditPM.dtItemTaraInventario.page('last').draw('page');
                utilSigo.toastSuccess("Aviso", "Se adiciono con éxito");
            }
            else {
                if (rowObj.RegEstado == RegEstadoSigo.INITIAL)
                    rowObj.RegEstado = RegEstadoSigo.UPDATE;
                AddEditPM.dtItemTaraInventario.row(AddEditPM.trEdit).data(rowObj).draw(false);
                AddEditPM.trEdit = "";
                utilSigo.toastSuccess("Aviso", "Se modifico con éxito");
                utilSigo.fnCloseModal("modalAddEditSelect2");
            }
        }
        _TaraInventario.init(dataRow);

    });
}
AddEditPM.fnAddEditEcoInforme = function (obj) {
    var url = urlLocalSigo + "THabilitante/ManPlanManejo/_ItemEcotInforme";
    var option = { url: url, type: 'GET', datos: {}, divId: "modalAddEditSelect2" };
    var dataRow = {};
    if (obj != "") { //editar
        AddEditPM.trEdit = $(obj).closest('tr');
        dataRow = AddEditPM.dtItemEcotInformeAnual.row(AddEditPM.trEdit).data();
    }
    utilSigo.fnOpenModal(option, function () {
        _EcotInforme.fnAsignar = function (rowObj) {
            if (parseInt(rowObj.RegEstadoClient) == RegEstadoSigo.NEW) {
                AddEditPM.dtItemEcotInformeAnual.row.add(rowObj).draw();
                AddEditPM.dtItemEcotInformeAnual.page('last').draw('page');
                utilSigo.toastSuccess("Aviso", "Se adiciono con éxito");
            }
            else {
                if (rowObj.RegEstado == RegEstadoSigo.INITIAL)
                    rowObj.RegEstado = RegEstadoSigo.UPDATE;
                AddEditPM.dtItemEcotInformeAnual.row(AddEditPM.trEdit).data(rowObj).draw(false);
                AddEditPM.trEdit = "";
                utilSigo.toastSuccess("Aviso", "Se modifico con éxito");
                utilSigo.fnCloseModal("modalAddEditSelect2");
            }
        }
        _EcotInforme.init(dataRow);

    });
}
AddEditPM.fnAddCArea = function (obj) {
    var url = urlLocalSigo + "THabilitante/ManPlanManejo/_ItemISituCArea";
    var option = { url: url, type: 'GET', datos: {}, divId: "modalAddEditSelect2" };
    utilSigo.fnOpenModal(option, function () {
        IsituCarea.fnInit();
    });
}
AddEditPM.fnAddInvFauna = function (obj) {
    var url = urlLocalSigo + "THabilitante/ManPlanManejo/_InventarioFauna";
    var option = { url: url, type: 'GET', datos: {}, divId: "modalAddEditSelect2" };
    utilSigo.fnOpenModal(option, function () {
        _InventarioFauna.fnInit();
    });
}
AddEditPM.fnAddInvFlora = function (obj) {
    var url = urlLocalSigo + "THabilitante/ManPlanManejo/_InventarioFlora";
    var option = { url: url, type: 'GET', datos: {}, divId: "modalAddEditSelect2" };
    var dataRow = {};
    if (obj != "") { //editar
        AddEditPM.trEdit = $(obj).closest('tr');
        dataRow = AddEditPM.dtItemISituInvFlora.row(AddEditPM.trEdit).data();
    }
    utilSigo.fnOpenModal(option, function () {
        _InventarioFlora.fnAsignar = function (rowObj) {
            if (parseInt(rowObj.RegEstadoClient) == RegEstadoSigo.NEW) {
                AddEditPM.dtItemISituInvFlora.row.add(rowObj).draw();
                AddEditPM.dtItemISituInvFlora.page('last').draw('page');
                utilSigo.toastSuccess("Aviso", "Se adiciono con éxito");
            }
            else {
                if (rowObj.RegEstado == RegEstadoSigo.INITIAL)
                    rowObj.RegEstado = RegEstadoSigo.UPDATE;
                AddEditPM.dtItemISituInvFlora.row(AddEditPM.trEdit).data(rowObj).draw(false);
                AddEditPM.trEdit = "";
                utilSigo.toastSuccess("Aviso", "Se modifico con éxito");
                utilSigo.fnCloseModal("modalAddEditSelect2");
            }
        }
        _InventarioFlora.fnInit(dataRow);
    });
}
AddEditPM.fnConfigTable = function () {
    var columns_label = [], columns_data = [], options = {};
    //Inspección Ocular
    columns_label = ["Apellidos y Nombres", "N° Documento", "Cargo"];
    columns_data = ["PERSONA", "N_DOCUMENTO", "CARGO"];
    options = {
        row_delete: true, row_fnDelete: "AddEditPM.fnDelete(this,2)", row_index: true, row_name_index: "IND"
    };
    AddEditPM.dtItemIOcular = utilDt.fnLoadDataTable_Detail(AddEditPM.frm.find("#grvItemIOcular"), columns_label, columns_data, options);
    //PLAN_MANEJO_DET_TRAPROBACION
    columns_label = ["Apellidos y Nombres", "N° Documento", "Cargo"];
    columns_data = ["PERSONA", "N_DOCUMENTO", "CARGO"];
    options = {
        row_delete: true, row_fnDelete: "AddEditPM.fnDelete(this,1)", row_index: true, row_name_index: "IND"
    };
    AddEditPM.dtItemTRAprobacion = utilDt.fnLoadDataTable_Detail(AddEditPM.frm.find("#grvItemTRAprobacion"), columns_label, columns_data, options);
    //TARA
    columns_label = ["Parcelas", "Puntos", "Este", "Norte", "Referencia"];
    columns_data = ["NUM_PARCELA", "NUM_PUNTOS", "COORDENADA_ESTE", "COORDENADA_NORTE", "OBSERVACION"];
    options = {
        row_edit: true, row_fnEdit: "AddEditPM.fnAddEditTaraCUTM(this)", row_delete: true, row_fnDelete: "AddEditPM.fnDelete(this,0)"
        , row_index: true, row_name_index: "IND"
    };
    AddEditPM.dtItemTaraCUTM = utilDt.fnLoadDataTable_Detail(AddEditPM.frm.find("#grvItemTaraCUTM"), columns_label, columns_data, options);  //
    //PLAN_MANEJO_TARA_DET_AAPROVECHAMIENTO
    columns_label = ["Parcela", "N° Arboles", "N° árboles que no están en edad aprovechamiento", "Producción anual promedio por árbol", "Peso estimado vainas"];
    columns_data = ["NUM_PARCELA", "NUM_ARBOLES_APROVE", "NUM_ARBOLES_NO_APROVE", "PRODUCCION_ANUAL_PROMEDIO", "PESO_ESTIMADO_VAINAS"];
    options = {
        row_edit: true, row_fnEdit: "AddEditPM.fnAddEditTaraAEAprov(this)", row_delete: true, row_fnDelete: "AddEditPM.fnDelete(this,3)"
        , row_index: true, row_name_index: "IND"
    };
    AddEditPM.dtItemTaraAEAprov = utilDt.fnLoadDataTable_Detail(AddEditPM.frm.find("#grvItemTaraAEAprov"), columns_label, columns_data, options);
    //PLAN_MANEJO_TARA_DET_PAPROVECHAMIENTO
    columns_label = ["Año", "N° Arboles", "Peso Vainas", "N° Cosechas", "N° Quintales", "Observación"];
    columns_data = ["ANO", "NUM_ARBOLES", "PESO_VAINAS", "NUM_COSECHA", "NUM_QUINTALES", "OBSERVACION"];
    options = {
        row_edit: true, row_fnEdit: "AddEditPM.fnAddEditTaraPApro(this)", row_delete: true, row_fnDelete: "AddEditPM.fnDelete(this,4)"
        , row_index: true, row_name_index: "IND"
    };
    AddEditPM.dtItemTaraPApro = utilDt.fnLoadDataTable_Detail(AddEditPM.frm.find("#grvItemTaraPApro"), columns_label, columns_data, options);
    //PLAN_MANEJO_TARA_DET_OPCIONES
    columns_label = ["Descripción", "Observación"];
    columns_data = ["DESCRIPCION", "OBSERVACION"];
    options = {
        row_edit: true, row_fnEdit: "AddEditPM.fnAddEditTaraOpcion(this,0)", row_delete: true, row_fnDelete: "AddEditPM.fnDelete(this,5)"
        , row_index: true, row_name_index: "IND"
    };
    AddEditPM.dtItemTaraESistemaA = utilDt.fnLoadDataTable_Detail(AddEditPM.frm.find("#grvItemTaraESistemaA"), columns_label, columns_data, options);
    columns_label = ["Descripción", "Observación"];
    columns_data = ["DESCRIPCION", "OBSERVACION"];
    options = {
        row_edit: true, row_fnEdit: "AddEditPM.fnAddEditTaraOpcion(this,1)", row_delete: true, row_fnDelete: "AddEditPM.fnDelete(this,6)"
        , row_index: true, row_name_index: "IND"
    };
    AddEditPM.dtItemTaraPSilvicultural = utilDt.fnLoadDataTable_Detail(AddEditPM.frm.find("#grvItemTaraPSilvicultural"), columns_label, columns_data, options);
    //PLAN_MANEJO_TARA_DET_CAUTO_EXTRAER
    columns_label = ["Nombre Cientifico", "Superficie HA", "Total PGMF", "1 año", "2 año", "3 año", "4 año", "5 año", "Der. Aprov. / quintal/Unitario", "Der. Aprov. / quintal/Total"];
    columns_data = ["ESPCIES", "SUPERFICIE_HA", "TOTAL_PGMF", "ANO_1", "ANO_2", "ANO_3", "ANO_4", "ANO_5", "DERECHO_APROVE_QUINTAL", "DERECHO_APROVE_QTOTAL"];
    options = {
        row_edit: true, row_fnEdit: "AddEditPM.fnAddEditTaraAutoExtraer(this)", row_delete: true, row_fnDelete: "AddEditPM.fnDelete(this,7)"
        , row_index: true, row_name_index: "IND"
    };
    AddEditPM.dtItemTaraAutoExtraer = utilDt.fnLoadDataTable_Detail(AddEditPM.frm.find("#grvItemTaraAutoExtraer"), columns_label, columns_data, options);
    //PLAN_MANEJO_TARA_DET_INVENTARIO
    columns_label = ["Nº Árbol", "Condición", "E. Fitosan.", "Alt. Estimada", "Peso Vainas KG", "Coord. Este", "Coord. Norte", "Observación"];
    columns_data = ["N_ARBOL", "CONDICION", "ESTADO_FITOSAN", "ALTURA_ESTIMADO", "PESO_VAINAS_KILOGRAMOS", "COORDENADA_ESTE", "COORDENADA_NORTE", "OBSERVACION"];
    options = {
        row_edit: true, row_fnEdit: "AddEditPM.fnAddEditTaraInventario(this)", row_delete: true, row_fnDelete: "AddEditPM.fnDelete(this,8)"
        , row_index: true, row_name_index: "IND"
    };
    AddEditPM.dtItemTaraInventario = utilDt.fnLoadDataTable_Detail(AddEditPM.frm.find("#grvItemTaraInventario"), columns_label, columns_data, options); //
    //DIV trItemEcoturismo
    columns_label = ["Descripción", "Observación"];
    columns_data = ["DESCRIPCION", "OBSERVACION"];
    options = {
        row_edit: true, row_fnEdit: "AddEditPM.fnAddEditTaraOpcion(this,2)", row_delete: true, row_fnDelete: "AddEditPM.fnDelete(this,9)"
        , row_index: true, row_name_index: "IND"
    };
    AddEditPM.dtItemEcotPImplementar = utilDt.fnLoadDataTable_Detail(AddEditPM.frm.find("#grvItemEcotPImplementar"), columns_label, columns_data, options);
    //PLAN_MANEJO_EXSITU_DET_IANUAL
    columns_label = ["Fecha Presentación", "Periodo Informado", "Persona que Firma", "Principales acciones a desarrollar", "Observación"];
    columns_data = ["FECHA_EMISION", "ANO_EJECUTADO", "PROFESIONAL_NOMBRE", "PRINCIPAL_ACCION_DESARROLLA", "OBSERVACION"];
    options = {
        row_edit: true, row_fnEdit: "AddEditPM.fnAddEditEcoInforme(this)", row_delete: true, row_fnDelete: "AddEditPM.fnDelete(this,10)"
        , row_index: true, row_name_index: "IND"
    };
    AddEditPM.dtItemEcotInformeAnual = utilDt.fnLoadDataTable_Detail(AddEditPM.frm.find("#grvItemEcotInformeAnual"), columns_label, columns_data, options);
    //DIV _pnlItemInSitu
    //Insitu Condicion Area
    columns_label = ["Área"];
    columns_data = ["DESCRIPCION"];
    options = {
        row_delete: true, row_fnDelete: "AddEditPM.fnDelete(this,11)", row_index: true, row_name_index: "IND"
    };
    AddEditPM.dtItemISituCArea = utilDt.fnLoadDataTable_Detail(AddEditPM.frm.find("#grvItemISituCArea"), columns_label, columns_data, options);
    //PLAN_MANEJO_INSITU_DET_INV_FAUNA
    columns_label = ["Especie"];
    columns_data = ["ESPECIES"];
    options = {
        row_delete: true, row_fnDelete: "AddEditPM.fnDelete(this,12)", row_index: true, row_name_index: "IND"
    };
    AddEditPM.dtItemISituInvFauna = utilDt.fnLoadDataTable_Detail(AddEditPM.frm.find("#grvItemISituInvFauna"), columns_label, columns_data, options);
    //PLAN_MANEJO_INSITU_DET_INV_FLORA
    columns_label = ["Especie", "Caracteristicas Generales", "Relación entre las asociaciones y la fauna", "Observación"];
    columns_data = ["ESPECIES", "CARACTERISTICAS", "RASOCIACIONES_FAUNA", "OBSERVACION"];
    options = {
        row_edit: true, row_fnEdit: "AddEditPM.fnAddInvFlora(this)", row_delete: true, row_fnDelete: "AddEditPM.fnDelete(this,13)"
        , row_index: true, row_name_index: "IND"
    };
    AddEditPM.dtItemISituInvFlora = utilDt.fnLoadDataTable_Detail(AddEditPM.frm.find("#grvItemISituInvFlora"), columns_label, columns_data, options); 
    //ERROR MATERIAL
    columns_label = ["Fecha de Resolución", "Resolución", "Nombre Campo", "Valor Anterior", "Valor Actual", "Observaciones"];
    columns_data = ["DA_FECRESOLUCION", "NV_RESOLUCION", "NV_NOMCAMPO", "NV_VALANTERIOR", "NV_VALACTUAL", "NV_OBSERVACION"];
    options = {
        page_length: 10, row_index: true, page_sort: true
    };
    AddEditPM.dtErrorMaterial_DGeneral = utilDt.fnLoadDataTable_Detail(AddEditPM.frm.find("#tbErrorMaterial_DGeneral"), columns_label, columns_data, options);

    AddEditPM.dtErrorMaterial_DAdicional = utilDt.fnLoadDataTable_Detail(AddEditPM.frm.find("#tbErrorMaterial_DAdicional"), columns_label, columns_data, options);
}
AddEditPM.fnInitTable = function () {
    AddEditPM.fnConfigTable();
    //cargando datos iniciales
    var url = urlLocalSigo + "THabilitante/ManPlanManejo/GetAllItemsPlanManejo";
    var valCodPM = AddEditPM.frm.find("#hdfItemCOD_PMANEJO").val();
    var option = { url: url, datos: { codPM: valCodPM } };
    utilSigo.fnAjax(option, function (data) {
        var data = data.data;
        AddEditPM.dtItemIOcular.rows.add(data.ListPMDTTIOCULAR).draw();
        AddEditPM.dtItemTRAprobacion.rows.add(data.ListPMDTTRAPROBACION).draw();
        AddEditPM.dtItemTaraCUTM.rows.add(data.ListPMTCOORDENADAUTM).draw();
        AddEditPM.dtItemTaraAEAprov.rows.add(data.ListPMTAAPROVECHAMIENTO).draw();
        AddEditPM.dtItemTaraPApro.rows.add(data.ListPMTDPPAPROVECHAMIENTO).draw();
        AddEditPM.dtItemTaraESistemaA.rows.add(data.ListPMTDOOPCIONESEAPROVE).draw();
        AddEditPM.dtItemTaraPSilvicultural.rows.add(data.ListPMTDOOPCIONESPSILVI).draw();
        AddEditPM.dtItemTaraAutoExtraer.rows.add(data.ListPMTAUTORIZADAEXTRA).draw();
        AddEditPM.dtItemTaraInventario.rows.add(data.ListPMTINVENTARIO).draw();
        //cambiando titulo ListPMTINVENTARIO
        var cantInventario = 0;
        cantInventario = data.ListPMTINVENTARIO.length;
        var textoIntentario = `Ir Inventario ( ${cantInventario} )`;
        AddEditPM.frm.find("#lbtItemTaraInventarioSelec").text(textoIntentario);


        //DIV trItemEcoturismo
        AddEditPM.dtItemEcotPImplementar.rows.add(data.ListPMECOTPROGIMPLEMENTAR).draw();
        AddEditPM.dtItemEcotInformeAnual.rows.add(data.ListPMINFORME_ANUAL).draw();


        //DIV _pnlItemInSitu
        AddEditPM.dtItemISituCArea.rows.add(data.ListPMDISITUCAREA).draw();
        AddEditPM.dtItemISituInvFauna.rows.add(data.ListPMDISITUFAUNA).draw();
        AddEditPM.dtItemISituInvFlora.rows.add(data.ListPMDISITUFLORA).draw();

        //Error Material
        AddEditPM.dtErrorMaterial_DGeneral.rows.add(data.ListPMErrorMaterialG).draw();
        AddEditPM.dtErrorMaterial_DAdicional.rows.add(data.ListPMErrorMaterialA).draw();
    });
}
AddEditPM.fnShowInventario = function () {
    $("#navDatosTab").hide();
    $("#navEstadoTab").hide();
    $("#navDatosAdicTab").hide();
    $("#divTitle").hide();
    $("#divTInventario").show();
    $("#navDatosInventarioTab").show();
    $('.nav-tabs a[href="#navDatosInventario"]').tab('show');
}
AddEditPM.fnHideInventario = function () {
    $("#navDatosTab").show();
    $("#navEstadoTab").show();
    $("#navDatosAdicTab").show();
    $("#divTitle").show();
    $("#divTInventario").hide();
    $("#navDatosInventarioTab").hide();
    $('.nav-tabs a[href="#navDatos"]').tab('show');
}
AddEditPM.fnInitEventos = function () {
    AddEditPM.frm.find("#btnAddItemIOcular").click(function () {
        AddEditPM.fnBuscarPersona("IOCULAR", "0000005");
    });
    AddEditPM.frm.find("#btnAddItemTRAprobacion").click(function () {
        AddEditPM.fnBuscarPersona("ITAPROBACION", "0000004");
    });
    AddEditPM.frm.find("#btnConsultor").click(function () {
        AddEditPM.fnBuscarPersona("REGENTE", "0000020");
    });
    AddEditPM.frm.find("#btnFuncionario").click(function () {
        AddEditPM.fnBuscarPersona("FRAPRUEBA", "0000006");
    });
    AddEditPM.frm.find("#btnFuncionarioFR").click(function () {
        AddEditPM.fnBuscarPersona("FRAPRUEBA_FIRMA", "0000006");
    });
    //CUTM
    AddEditPM.frm.find("#btnAddItemTaraCUTM").click(function () {
        AddEditPM.fnAddEditTaraCUTM("");
    });
    AddEditPM.frm.find("#btnDownloadCUTM").click(function () {
        AddEditPM.fnDownloadPlantilla("TaraCUTM");
    });
    AddEditPM.frm.find("#btnDeleteAllCUTM").click(function () {
        AddEditPM.fnDeleteAllTaraCUTM();
    });
    //
    AddEditPM.frm.find("#btnAddTaraAEAprov").click(function () {
        AddEditPM.fnAddEditTaraAEAprov("");
    });
    //
    AddEditPM.frm.find("#btnAddTaraPApro").click(function () {
        AddEditPM.fnAddEditTaraPApro("");
    });
    AddEditPM.frm.find("#btnAddTaraESistemaA").click(function () {
        AddEditPM.fnAddEditTaraOpcion("", 0);
    });
    AddEditPM.frm.find("#btnAddTaraPSilvicultural").click(function () {
        AddEditPM.fnAddEditTaraOpcion("", 1);
    });
    AddEditPM.frm.find("#btnAddItemTaraAutoExtraer").click(function () {
        AddEditPM.fnAddEditTaraAutoExtraer("");
    });
    AddEditPM.frm.find("#btnInventario").click(function () {
        AddEditPM.fnShowInventario();
    });
    AddEditPM.frm.find("#btnAddInventario").click(function () {
        AddEditPM.fnAddEditTaraInventario("");
    });
    $("#btnRInventario").click(function () {
        AddEditPM.fnHideInventario();
    });
    AddEditPM.frm.find("#btnDownloadInv").click(function () {
        AddEditPM.fnDownloadPlantilla("TaraInventario");
    });
    AddEditPM.frm.find("#btnDeleteAllInventario").click(function () {
        AddEditPM.fnDeleteAllTaraInventario();
    });

    //DIV trItemEcoturismo - Indicador "CS"
    AddEditPM.frm.find("#btnAddEcotPImplementar").click(function () {
        AddEditPM.fnAddEditTaraOpcion("", 2);
    });
    AddEditPM.frm.find("#btnAddEcotInformeAnual").click(function () {
        AddEditPM.fnAddEditEcoInforme("");
    });

    //DIV    _pnlItemInSitu
    AddEditPM.frm.find("#btnAddCArea").click(function () {
        AddEditPM.fnAddCArea();
    });
    AddEditPM.frm.find("#btnDeleteAllCArea").click(function () {
        AddEditPM.fnDeleteAllCArea();
    });
    AddEditPM.frm.find("#btnAddInvFauna").click(function () {
        AddEditPM.fnAddInvFauna();
    });
    AddEditPM.frm.find("#btnDeleteAllInvFauna").click(function () {
        AddEditPM.fnDeleteAllInventarioFauna();
    });
    AddEditPM.frm.find("#btnAddISituInvFlora").click(function () {
        AddEditPM.fnAddInvFlora("");
    });
    AddEditPM.frm.find("#btnDeleteAllISituInvFlora").click(function () {
        AddEditPM.fnDeleteAllInventarioFlora();
    });

    //eventos modales
    var modales = ["modalBuscarPersona", "modalAddEdit", "modalAddEditSelect2"];
    for (var i = 0; i < modales.length; i++) {
        $('#' + modales[i]).on('hidden.bs.modal', function () {
            utilSigo.fnCloseModal($(this).attr("id"));
        });
    }
    //calidad
    AddEditPM.frm.find("#ddlItemIndicadorId").change(function () {

        var cboVal = $(this).val();
        if (cboVal == "0000007") {

            AddEditPM.frm.find("#divCKEDITOR").removeAttr("style");
            if (AddEditPM.banderaCKEDITOR == 0)
                AddEditPM.iniciarCKEDITOR("PLAN_MANEJO", AddEditPM.frm.find("#hdfItemCOD_PMANEJO").val());
            AddEditPM.banderaCKEDITOR = 1;
            AddEditPM.banderaCKEDITORBD = 1;
        }
        else {
            AddEditPM.frm.find("#divCKEDITOR").attr("style", "display:none;");
            AddEditPM.banderaCKEDITORBD = 0;
        }

    });

    //eventos principales
    $("#btnRegistrarPM").click(function () {
        if (!AddEditPM.validacionGeneral()) {
            return AddEditPM.frm.valid();
        }
        AddEditPM.frm.submit();
    });
    $("#btnRegresarPM").click(function () {
        AddEditPM.regresar('', '');
    });

    //Error Material
    AddEditPM.frm.find("#btnAddItemErrorMaterialG").click(function () {
        AddEditPM.fnAddErrorMaterial('DG');
    });
    AddEditPM.frm.find("#btnAddItemErrorMaterialA").click(function () {
        AddEditPM.fnAddErrorMaterial('DA');
    });
    
}
AddEditPM.validacionGeneral = function () {
    var ids = ["ddlItemIndicadorId", "ddlODRegistroId", "txtItemAresolucion_Num"];
    var idtab = "";
    var valRetorno = true;
    var idControlError = "";
    $.each(ids, function (i, o) {
        if ($("#" + o).val() == "" || $("#" + o).val() == "0000000") {
            idControlError = $("#" + o);
            idtab = $("#" + o).parents(".tab-pane").attr("id");
            valRetorno = false;
            return false;
        }
    })
    if (idtab != "") {
        $('a[href="#' + idtab + '"]').tab('show');
        idControlError.focus();
    }
    return valRetorno
}
AddEditPM.validaAdicional = function () {
    if (!utilSigo.fnValidateForm_HideControl(AddEditPM.frm, AddEditPM.frm.find("#hdlblItemConsultorNombre"), AddEditPM.frm.find("#iconConsultor"), false)) {
        $('a[href="#navDatos"]').tab('show');
        return false;
    }
    return true;
}
AddEditPM.fnConfigValidate = function () {

    jQuery.validator.addMethod("invalidfrmPlanManejo", function (value, element) {
        switch ($(element).attr('id')) {
            case 'ddlItemIndicadorId':
                return (value == '0000000') ? false : true;
                break;
            case 'ddlODRegistroId':
                return (value == '0000000') ? false : true;
                break
        }
    });
    AddEditPM.frm.validate(utilSigo.fnValidate({
        rules: {
            ddlItemIndicadorId: { invalidfrmPlanManejo: true },
            ddlODRegistroId: { invalidfrmPlanManejo: true },
            txtItemAresolucion_Num: { required: true }
        },
        messages: {
            ddlItemIndicadorId: { invalidfrmPlanManejo: "Debe seleccionar la situación actual de su registro" },
            ddlODRegistroId: { invalidfrmPlanManejo: "Debe seleccionar la O.D. desde donde se registra la información" },
            txtItemAresolucion_Num: { required: "Ingrese Número de Resolución de Aprobación" }
        },
        fnSubmit: function (form) {
            if (AddEditPM.validaAdicional()) {
                utilSigo.dialogConfirm('', 'Desea continuar con la operación?', function (r) {
                    if (r) {
                        AddEditPM.fnRegistrarPlanManjo();
                    }
                });
            }
        }
    }));
}
AddEditPM.iniciarCKEDITOR = function (form, codigo) {
    AddEditPM.banderaCKEDITORBD = 1;
    $.ajax({
        url: urlLocalSigo + "THabilitante/Controles/_VPCKEDITOR",
        type: 'GET',
        data: { formulario: form, codigo: codigo },
        dataType: 'html',
        success: function (data) {
            // utilSigo.unblockUIGeneral();
            utilSigo.unblockUIElement("#divCKEDITOR");
            AddEditPM.frm.find("#divCKEDITOR").html(data);
            if (AddEditPM.frm.find("#ddlItemIndicadorEnable").val() == "False") {
                AddEditPM.frm.find("#OBSERVACIONES_CONTROL").attr('disabled', 'disabled');
            }
        },
        beforeSend: function () {
            //utilSigo.blockUIGeneral();
            utilSigo.blockUIElement("#divCKEDITOR");
        },
        error: function (jqXHR, error, errorThrown) {
            //utilSigo.unblockUIGeneral();
            utilSigo.unblockUIElement("#divCKEDITOR");
            utilSigo.toastError("Error", "Sucedio un Error Inesperado al cargar datos de control de calidad, Comuniquese con el Administrador");
            initSigo.redireccionarError("Sucedio un Error Inesperado al cargar datos de control de calidad. Si sigue persistiendo el error, comuniquese con el administrador");
            //console.log(jqXHR.responseText);
        },
        statusCode: {
            203: () => { utilSigo.unblockUIGeneral(); utilSigo.toastInfo("Aviso", "El usuario perdio la sesión. Vuelva ingresar al sistema"); }
        }
    });
}
AddEditPM.fnRegistrarPlanManjo = function () {
    var datosPM = AddEditPM.frm.serializeObject();
    datosPM.chkItemAcorde_Tdr_Vigente = AddEditPM.obtenerValorCheck("chkItemAcorde_Tdr_Vigente");
    datosPM.chkItemActividadPrioritaria = AddEditPM.obtenerValorCheck("chkItemActividadPrioritaria");
    if (AddEditPM.banderaCKEDITORBD == 1)
        datosPM.txtControlCalidadObservaciones = CKEDITOR.instances["OBSERVACIONES_CONTROL"].getData();
    //datos de tabla    
    datosPM.ListPMDTTIOCULAR = AddEditPM.fnGetObject(AddEditPM.dtItemIOcular);
    datosPM.ListPMDTTRAPROBACION = AddEditPM.fnGetObject(AddEditPM.dtItemTRAprobacion);
    datosPM.ListPMTCOORDENADAUTM = AddEditPM.fnGetObject(AddEditPM.dtItemTaraCUTM);
    datosPM.ListPMTAAPROVECHAMIENTO = AddEditPM.fnGetObject(AddEditPM.dtItemTaraAEAprov);
    datosPM.ListPMTDPPAPROVECHAMIENTO = AddEditPM.fnGetObject(AddEditPM.dtItemTaraPApro);
    datosPM.ListPMTDOOPCIONESEAPROVE = AddEditPM.fnGetObject(AddEditPM.dtItemTaraESistemaA);
    datosPM.ListPMTDOOPCIONESPSILVI = AddEditPM.fnGetObject(AddEditPM.dtItemTaraPSilvicultural);
    datosPM.ListPMTAUTORIZADAEXTRA = AddEditPM.fnGetObject(AddEditPM.dtItemTaraAutoExtraer);
    datosPM.ListPMTINVENTARIO = AddEditPM.fnGetObject(AddEditPM.dtItemTaraInventario);
    //DIV trItemEcoturismo     
    datosPM.ListPMECOTPROGIMPLEMENTAR = AddEditPM.fnGetObject(AddEditPM.dtItemEcotPImplementar);
    datosPM.ListPMINFORME_ANUAL = AddEditPM.fnGetObject(AddEditPM.dtItemEcotInformeAnual);

    //DIV _pnlItemInSitu    
    datosPM.ListPMDISITUCAREA = AddEditPM.fnGetObject(AddEditPM.dtItemISituCArea);
    datosPM.ListPMDISITUFAUNA = AddEditPM.fnGetObject(AddEditPM.dtItemISituInvFauna);
    datosPM.ListPMDISITUFLORA = AddEditPM.fnGetObject(AddEditPM.dtItemISituInvFlora);
    //
    datosPM.ListEliTABLA = AddEditPM.ListEliTABLA;

    //Datos Error Material
    datosPM.ListPMErrorMaterialG = AddEditPM.fnGetListErrorMaterial('DG');
    datosPM.ListPMErrorMaterialA = AddEditPM.fnGetListErrorMaterial('DA');

    datosPM.txtCodUbigeo = $("#txtCodUbigeo").val();
    datosPM.txtDirecion = $("#txtDirecion").val();
    //enviando datos al servidor
    $.ajax({
        url: urlLocalSigo + "THabilitante/ManPlanManejo/AddEditPM",
        type: 'POST',
        data: JSON.stringify(datosPM),
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function (data) {
            utilSigo.unblockUIGeneral();
            if (data.success) {
                if (AddEditPM.frm.find("#opRegresar").val() == 0) {
                    AddEditPM.regresar(data.msj, '');
                } else {
                    AddEditPM.regresar('', data.appServer);
                }
            }
            else {
                if (AddEditPM.frm.find("#opRegresar").val() == 0) {
                    utilSigo.toastWarning("Aviso", data.msj);
                } else {
                    AddEditPM.regresar('', data.appServer);
                }
            }
        },
        beforeSend: function () {
            utilSigo.blockUIGeneral();
        },
        error: function (jqXHR, error, errorThrown) {
            utilSigo.unblockUIGeneral();
            utilSigo.toastError("Error", "Sucedio un error, Comuniquese con el Administrador");
            //console.log(jqXHR.responseText);
        }
    });
}
AddEditPM.obtenerValorCheck = function (control) {
    var check = AddEditPM.frm.find("#" + control);
    var state = check.is(":checked");
    if (state) return true
    else return false;
}

AddEditPM.fnAddErrorMaterial = function (tipo) {
    var url = urlLocalSigo + "THabilitante/ManPlanManejo/_ErrorMaterial";
    var option = { url: url, type: 'POST', datos: {}, divId: "modalAddErrorMaterial" };

    utilSigo.fnOpenModal(option, function () {
        _ErrorMaterial.fnCloseModal = function () {
            $("#modalAddErrorMaterial").modal('hide');
        };

        _ErrorMaterial.fnSaveForm = function (data) {
            if (data != null) {
                var dt;
                switch (tipo) {
                    case 'DG':
                        dt = AddEditPM.dtErrorMaterial_DGeneral;
                        break;
                    case 'DA':
                        dt = AddEditPM.dtErrorMaterial_DAdicional;
                        break;
                }

                dt.order([1, 'desc']).draw();
                dt.rows.add([data]).draw();
                dt.page('last').draw('page');
                $("#modalAddErrorMaterial").modal('hide');
            } else {
                utilSigo.toastSuccess("Error", "No se pudieron guardar los datos");
            }
        };

        _ErrorMaterial.fnInit(tipo);
    });
}

AddEditPM.fnGetListErrorMaterial = function (tipo) {
    var dt, list = [], rows, countFilas, data;

    switch (tipo) {
        case 'DG':
            dt = AddEditPM.dtErrorMaterial_DGeneral;
            break;
        case 'DA':
            dt = AddEditPM.dtErrorMaterial_DAdicional;
            break;
    }

    rows = dt.$("tr");
    countFilas = rows.length;
    if (countFilas > 0) {
        $.each(rows, function (i, o) {
            data = dt.row($(o)).data();
            list.push(utilSigo.fnConvertArrayToObject(data));
        });
    }

    return list;
}

AddEditPM.fnInit = function () {
    AddEditPM.frm = $("#frmPlanManejo");
    AddEditPM.fnConfigValidate();
    //fechas 
    AddEditPM.frm.find("#txtItemFechaPresentacion").datepicker(initSigo.formatDatePicker);
    AddEditPM.frm.find("#txtItemISDuracionFInicio").datepicker(initSigo.formatDatePicker);
    AddEditPM.frm.find("#txtItemISDuracionFFin").datepicker(initSigo.formatDatePicker);
    AddEditPM.frm.find("#txtItemItecnico_Iocular_Fecha").datepicker(initSigo.formatDatePicker);
    AddEditPM.frm.find("#txtItemItecnico_Raprobacion_Fecha").datepicker(initSigo.formatDatePicker);
    AddEditPM.frm.find("#txtItemAresolucion_Fecha").datepicker(initSigo.formatDatePicker);
    //
    $.fn.select2.defaults.set("theme", "bootstrap4");
    AddEditPM.frm.find("#ddlItemIndicadorId").select2();
    AddEditPM.frm.find("#ddlODRegistroId").select2();
    AddEditPM.frm.find("#ddlDependenciaId").select2({ minimumResultsForSearch: -1 });
}
$(document).ready(function () {
    $('[data-toggle="tooltip"]').tooltip();
    AddEditPM.fnInit();
    AddEditPM.fnInitEventos();
    AddEditPM.fnInitTable();
    if (AddEditPM.frm.find("#ddlItemIndicadorId").val() == "0000007") {
        AddEditPM.frm.find("#divCKEDITOR").removeAttr("style");
        AddEditPM.frm.find("#divObsSubsanado").removeAttr("style");
        if (AddEditPM.banderaCKEDITOR == 0)
            AddEditPM.iniciarCKEDITOR("PLAN_MANEJO", AddEditPM.frm.find("#hdfItemCOD_PMANEJO").val());
        AddEditPM.banderaCKEDITOR = 1;
        AddEditPM.banderaCKEDITORBD = 1;
    }
});