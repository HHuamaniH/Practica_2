"use strict";
var ManPM = {};
ManPM.banderaCKEDITOR = 0;
ManPM.banderaCKEDITORBD = 0;
ManPM.ListEspecies = [];
ManPM.ListCoordenadas = [];
ManPM.ListEspeciesFauna = [];
ManPM.ListTHabilitante = [];
ManPM.ListEliTABLA = [];
ManPM.opcRegItem;
ManPM.dataEditar;

ManPM.mostrarModal = function (div, urlModal, datos) {
    $.ajax({
        url: urlModal,
        type: 'POST',
        data: datos,
        dataType: 'html',
        success: function (data) {
            utilSigo.unblockUIGeneral();
            $("#" + div).html(data);             
            utilSigo.modalDraggable($("#" + div), '.modal-header');
            $("#" + div).modal({ keyboard: true, backdrop: 'static' });
        },
        beforeSend: function () {
            utilSigo.blockUIGeneral();
        },
        error: function (jqXHR, error, errorThrown) {
            utilSigo.unblockUIGeneral();
            utilSigo.toastError("Error", "Sucedio un Error Inesperado, Comuniquese con el Administrador");
            console.log(jqXHR.responseText);
        }
    });
}

ManPM.exportarExcel = function (TVentana) {
    var COD_PGMF = ManPM.frm.find("#hdfManCOD_PGMF").val();
    var urlc = urlLocalSigo + "THabilitante/ManPlanManejoForestal/ExportarExcel";

    $.ajax({
        url: urlc,
        type: 'POST',
        data: { TVentana: TVentana, COD_PGMF: COD_PGMF},
        dataType: 'json',
        beforeSend: utilSigo.beforeSendAjax,
        complete: utilSigo.completeAjax,
        error: utilSigo.errorAjax,
        success: function (data) {
            if (data.success) {
                window.location.href = urlLocalSigo + "THabilitante/ManPlanManejoForestal/Download?file=" + data.values[0];
            } else {
                utilSigo.toastError("Error", "No se pudo consultar los datos de la persona");
                console.log(data.msj);
                return false;
            }
        }
    });
}

ManPM.enumTB = function (tb) {
    var tbEnum = ManPM.frm.find('#' + tb).DataTable();
    tbEnum.on('order.dt', function () {
        tbEnum.column(1, {}).nodes().each(function (cell, i) {
            cell.innerHTML = i + 1;
        });
    }).draw();
}
ManPM.agregarEspecies = function (codEspecie, desEspecie, bloque, narboles, volumen, codSecuencial, estado) {
    var $tbEspecies = ManPM.frm.find('#tbEspecies').dataTable();

    if (ManPM.opcRegItem == 'NUE') {
        var $rows = $tbEspecies.$("tr");
        var countFilas = $rows.length;
        var codSecE = parseInt(countFilas) + 1;
        var filaE = [{
            itemE: 1, codSec: codSecE, codEsp: codEspecie, des: desEspecie, numArb: narboles,
            vol: volumen, numB: bloque
        }];
        ManPM.frm.find('#tbEspecies').dataTable().fnAddData(filaE);
        ManPM.enumTB('tbEspecies');
        ManPM.frm.find('#tbEspecies').DataTable().page('last').draw('page');
    }
    else {
        var $trs = $tbEspecies.$("tr");
        var index = $trs.index(ManPM.dataEditar);
        var regEstado = (estado != 1) ? 2 : estado;

        var fila = {
            itemE: regEstado, codSec: codSecuencial, codEsp: codEspecie, des: desEspecie, numArb: narboles,
            vol: volumen, numB: bloque
        };

        ManPM.frm.find('#tbEspecies').dataTable().fnUpdate(fila, index, undefined, false);
        //ManPM.frm.find('#tbEspecies').dataTable().fnUpdate(fila, index);
        ManPM.enumTB('tbEspecies');
        ManPM.frm.find('#tbEspecies').DataTable().page('last').draw('page');
    }
}
ManPM.agregarCoordenadas = function (vertice, coordE, coordN, obs, codSecuencial, estado) {
    var $tbCoordenadas = ManPM.frm.find('#tbCoordenadas').dataTable();

    if (ManPM.opcRegItem == 'NUE') {
        var $rows = $tbCoordenadas.$("tr");
        var countFilas = $rows.length;
        var codSecC = parseInt(countFilas) + 1;
        var filaC = [{ itemE: 1, codSec: codSecC, vert: vertice, coE: coordE, coN: coordN, obs: obs }];
        ManPM.frm.find('#tbCoordenadas').dataTable().fnAddData(filaC);
        ManPM.enumTB('tbCoordenadas');
        ManPM.frm.find('#tbCoordenadas').DataTable().page('last').draw('page');
    }
    else {
        var $trs = $tbCoordenadas.$("tr");
        var index = $trs.index(ManPM.dataEditar);
        var regEstado = (estado != 1) ? 2 : estado;

        var fila = { itemE: regEstado, codSec: codSecuencial, vert: vertice, coE: coordE, coN: coordN, obs: obs};

        ManPM.frm.find('#tbCoordenadas').dataTable().fnUpdate(fila, index, undefined, false);
        ManPM.enumTB('tbCoordenadas');
        ManPM.frm.find('#tbCoordenadas').DataTable().page('last').draw('page');
    }
}
ManPM.agregarEspeciesFS = function (especie, codEspecie, amenaza, codAmenaza, obs, codSecuencial, estado) {
    var $tbEspeciesFauna = ManPM.frm.find('#tbEspeciesFauna').dataTable();

    if (ManPM.opcRegItem == 'NUE') {
        var $rows = $tbEspeciesFauna.$("tr");
        var countFilas = $rows.length;
        var codSecEF = parseInt(countFilas) + 1;
        var filaEF = [{ itemE: 1, codSec: codSecEF, codE: codEspecie, codA: codAmenaza, desc: especie, desAm: amenaza, obs: obs }];
        ManPM.frm.find('#tbEspeciesFauna').dataTable().fnAddData(filaEF);
        ManPM.enumTB('tbEspeciesFauna');
        ManPM.frm.find('#tbEspeciesFauna').DataTable().page('last').draw('page');
    }
    else {
        var $trs = $tbEspeciesFauna.$("tr");
        var index = $trs.index(ManPM.dataEditar);
        var regEstado = (estado != 1) ? 2 : estado;

        var fila = { itemE: regEstado, codSec: codSecuencial, codE: codEspecie, codA: codAmenaza, desc: especie, desAm: amenaza, obs: obs };

        ManPM.frm.find('#tbEspeciesFauna').dataTable().fnUpdate(fila, index, undefined, false);
        ManPM.enumTB('tbEspeciesFauna');
        ManPM.frm.find('#tbEspeciesFauna').DataTable().page('last').draw('page');
    }
}
ManPM.existeTH = function (codVerificarTH) {    
    var $tablaTH = ManPM.frm.find("#tbThabilitante").dataTable();
    var $rows = $tablaTH.$("tr");
    var countFilas = $rows.length;
    var bandera = false;
    if (countFilas > 0) {
        $.each($rows, function (i, o) {
            if($(o).find('.hdCodTH').val() == codVerificarTH)
            {
                bandera = true;
                return false;
            }            
        });
    }
    return bandera;
}
ManPM.agregarThabilitante = function (codigo, descripcion, modalidad, pTitular, lugarRegistro, dLinea) {
    if (!ManPM.existeTH(codigo))
    {
        var $tbTHabilitante = ManPM.frm.find('#tbThabilitante').dataTable();
        var $rows = $tbTHabilitante.$("tr");
        var filaTH = [{ itemE: 1, cod: codigo, mod: modalidad, desc: descripcion, pt: pTitular, codOr: lugarRegistro, dl: dLinea, ind: 0 }];
        ManPM.frm.find('#tbThabilitante').dataTable().fnAddData(filaTH);
        ManPM.updateComboDependencia();

        utilSigo.toastSuccess("Aviso", "Se agrego el registro");
        ManPM.enumTB('tbThabilitante');
    }
    else {
        utilSigo.toastWarning("Aviso", "Existe el Titulo Habilitante. No se puede agregar");
    }
    
}
ManPM.updateComboDependencia = function () {
    var codTHabilitante = utilDt.unionRows(ManPM.frm.find('#tbThabilitante').DataTable(), "cod", "|");
    utilSigo.loadAjaxCombo(initSigo.urlControllerGeneral + "/getDependenciasxCodTHabilitantes", $("#ddlDependenciaId"), { codThabilitantes: codTHabilitante }, null, false, null);

}
ManPM.editarCoordenadas = function (obj) {
    ManPM.opcRegItem = "MOD";
    ManPM.dataEditar = $(obj).closest('tr');
    var urlC = urlLocalSigo + "THabilitante/ManPlanManejoForestal/_Coordenadas";
    var datosC = {};
    ManPM.mostrarModal("modalCoordenadaPM", urlC, datosC);
}
ManPM.eliminarCoordenadas = function (obj) {
    utilSigo.dialogConfirm("Confirmacion", "¿ Está seguro de Eliminar el Registro Seleccionado ?", function (r) {
        if (r) {
            var $trEliminar = $(obj).closest('tr');
            var estadoItemSelec = $trEliminar.find(".hdEstadoItem").val();
            if (parseInt(estadoItemSelec) == 0 || parseInt(estadoItemSelec) == 2) {
                var hdCOD_PGMF = ManPM.frm.find("#hdfManCOD_PGMF").val();
                var columnasFila = $trEliminar.find('td');
                ManPM.ListEliTABLA.push({
                    EliTABLA: "PLAN_GENERALMANEJOFORESTAL_VERTICES",
                    COD_PGMF: hdCOD_PGMF,
                    VERTICE: $trEliminar.find(".hdVertice").val(),
                    COD_SECUENCIAL: $trEliminar.find(".hdCodSecuencial").val()
                });
            }
            //eliminando
            var $tbCoordenadas = ManPM.frm.find('#tbCoordenadas').dataTable();
            var $trs = $tbCoordenadas.$("tr");
            var index = $trs.index($trEliminar);
            ManPM.frm.find('#tbCoordenadas').dataTable().fnDeleteRow(index);
            ManPM.enumTB('tbCoordenadas');
            utilSigo.toastSuccess("Aviso", "Se elimino el registro");
        }
    });
}
ManPM.fnDeleteCoordenadaAll = function () {
    var $tablaCoord = ManPM.frm.find("#tbCoordenadas").dataTable();
    var $rows = $tablaCoord.$("tr");
    var countFilas = $rows.length;

    if (countFilas > 0) {
        utilSigo.dialogConfirm("", "Está seguro de Eliminar Todos los Registros?", function (r) {
            if (r) {
                var hdCOD_PGMF = ManPM.frm.find("#hdfManCOD_PGMF").val();
                var $trEliminar;
                $.each($rows, function (i, o) {
                    $trEliminar = $(o).closest('tr');
                    var estadoItemReg = $trEliminar.find(".hdEstadoItem").val();
                    if (parseInt(estadoItemReg) == 0 || parseInt(estadoItemReg) == 2) {
                        ManPM.ListEliTABLA.push({
                            EliTABLA: "PLAN_GENERALMANEJOFORESTAL_VERTICES",
                            COD_PGMF: hdCOD_PGMF,
                            VERTICE: $trEliminar.find('.hdVertice').val(),
                            COD_SECUENCIAL: $trEliminar.find('.hdCodSecuencial').val()
                        });
                    }
                });
                ManPM.frm.find('#tbCoordenadas').dataTable().fnClearTable();
                utilSigo.toastSuccess("Aviso", "Se eliminaron todos los registros");
            }
        });
    } else {
        utilSigo.toastWarning("Aviso", "No hay Registros a Eliminar");
    }
}
ManPM.TraerDataEspecieAprobada = function () {
    var urlE = urlLocalSigo + "THabilitante/ManPlanManejoForestal/_EspeciesAprobadas";
    var valNumBloque = 0;
    var valEsPMFI = ManPM.frm.find("#esPMFI").val();
    if (parseInt(valEsPMFI) == 0) {
        valNumBloque = ManPM.frm.find("#txtBloques").val().trim();
        if (valNumBloque == "") {
            utilSigo.toastWarning("Aviso", "Ingrese número de bloques");
            ManPM.frm.find("#txtBloques").focus();
            return false;
        }
        if (parseInt(valNumBloque) <= 0) {
            utilSigo.toastWarning("Aviso", "Ingrese número de bloques mayor a cero");
            ManPM.frm.find("#txtBloques").focus();
            return false;
        }
    }
    var datosE = { numBloque: valNumBloque, esPMFI: valEsPMFI };
    ManPM.mostrarModal("modalEspeciePM", urlE, datosE);
}
ManPM.editarEspecies = function (obj) {
    ManPM.opcRegItem = "MOD";
    ManPM.dataEditar = $(obj).closest('tr');
    ManPM.TraerDataEspecieAprobada();
}
ManPM.eliminarEspecies = function (obj) {
    utilSigo.dialogConfirm("Confirmacion", "¿ Está seguro de Eliminar el Registro Seleccionado ?", function (r) {
        if (r) {
            var $trEliminar = $(obj).closest('tr');
            var estadoItemSelec = $trEliminar.find(".hdEstadoItem").val();
            if (parseInt(estadoItemSelec) == 0 || parseInt(estadoItemSelec) == 2) {
                var hdCOD_PGMF = ManPM.frm.find("#hdfManCOD_PGMF").val();
                var columnasFila = $trEliminar.find('td');
                ManPM.ListEliTABLA.push({
                    EliTABLA: "PLAN_GENERALMANEJOFORESTAL_ESPECIES",
                    COD_PGMF: hdCOD_PGMF,
                    COD_ESPECIES: $trEliminar.find(".hdCodEspecie").val(),
                    COD_SECUENCIAL: $trEliminar.find(".hdCodSecuencial").val()
                });
            }
            //eliminando
            var $tbEspecies = ManPM.frm.find('#tbEspecies').dataTable();
            var $trs = $tbEspecies.$("tr");
            var index = $trs.index($trEliminar);
            ManPM.frm.find('#tbEspecies').dataTable().fnDeleteRow(index);
            ManPM.enumTB('tbEspecies');
            utilSigo.toastSuccess("Aviso", "Se elimino el registro");
        }
    });
}
ManPM.fnDeleteEspecieAprobadaAll = function () {
    var $tablaEsp = ManPM.frm.find("#tbEspecies").dataTable();
    var $rows = $tablaEsp.$("tr");
    var countFilas = $rows.length;

    if (countFilas > 0) {
        utilSigo.dialogConfirm("", "Está seguro de Eliminar Todos los Registros?", function (r) {
            if (r) {
                var hdCOD_PGMF = ManPM.frm.find("#hdfManCOD_PGMF").val();
                var $trEliminar;
                $.each($rows, function (i, o) {
                    $trEliminar = $(o).closest('tr');
                    var estadoItemReg = $trEliminar.find(".hdEstadoItem").val();
                    if (parseInt(estadoItemReg) == 0 || parseInt(estadoItemReg) == 2) {
                        ManPM.ListEliTABLA.push({
                            EliTABLA: "PLAN_GENERALMANEJOFORESTAL_ESPECIES",
                            COD_PGMF: hdCOD_PGMF,
                            COD_ESPECIES: $trEliminar.find('.hdCodEspecie').val(),
                            COD_SECUENCIAL: $trEliminar.find('.hdCodSecuencial').val()
                        });
                    }
                });
                ManPM.frm.find('#tbEspecies').dataTable().fnClearTable();
                utilSigo.toastSuccess("Aviso", "Se eliminaron todos los registros");
            }
        });
    } else {
        utilSigo.toastWarning("Aviso", "No hay Registros a Eliminar");
    }
}
ManPM.editarEspeciesFS = function (obj) {
    ManPM.opcRegItem = "MOD";
    ManPM.dataEditar = $(obj).closest('tr');
    var urlC = urlLocalSigo + "THabilitante/ManPlanManejoForestal/_EspeciesFaunaS";
    var datosC = {};
    ManPM.mostrarModal("modalEspecieFSPM", urlC, datosC);
}
ManPM.eliminarEspeciesFS = function (obj) {
    utilSigo.dialogConfirm("Confirmacion", "¿ Está seguro de Eliminar el Registro Seleccionado ?", function (r) {
        if (r) {
            var $trEliminar = $(obj).closest('tr');
            var estadoItemSelec = $trEliminar.find(".hdEstadoItem").val();
            if (parseInt(estadoItemSelec) == 0 || parseInt(estadoItemSelec) == 2) {
                var hdCOD_PGMF = ManPM.frm.find("#hdfManCOD_PGMF").val();
                var columnasFila = $trEliminar.find('td');
                ManPM.ListEliTABLA.push({
                    EliTABLA: "PLAN_GENERALMANEJOFORESTAL_ESPECIES_FAUNA",
                    COD_PGMF: hdCOD_PGMF,
                    COD_ESPECIES: $trEliminar.find(".hdCodEspecie").val(),
                    COD_AMENAZA: $trEliminar.find(".hdCodAmenaza").val(),
                    COD_SECUENCIAL: $trEliminar.find(".hdCodSecuencial").val()
                });
            }
            //eliminando
            var $tbEspeciesFS = ManPM.frm.find('#tbEspeciesFauna').dataTable();
            var $trs = $tbEspeciesFS.$("tr");
            var index = $trs.index($trEliminar);
            ManPM.frm.find('#tbEspeciesFauna').dataTable().fnDeleteRow(index);
            ManPM.enumTB('tbEspeciesFauna');
            utilSigo.toastSuccess("Aviso", "Se elimino el registro");
        }
    });
}
ManPM.fnDeleteEspecieFSAll = function () {
    var $tablaEspFS = ManPM.frm.find("#tbEspeciesFauna").dataTable();
    var $rows = $tablaEspFS.$("tr");
    var countFilas = $rows.length;

    if (countFilas > 0) {
        utilSigo.dialogConfirm("", "Está seguro de Eliminar Todos los Registros?", function (r) {
            if (r) {
                var hdCOD_PGMF = ManPM.frm.find("#hdfManCOD_PGMF").val();
                var $trEliminar;
                $.each($rows, function (i, o) {
                    $trEliminar = $(o).closest('tr');
                    var estadoItemReg = $trEliminar.find(".hdEstadoItem").val();
                    if (parseInt(estadoItemReg) == 0 || parseInt(estadoItemReg) == 2) {
                        ManPM.ListEliTABLA.push({
                            EliTABLA: "PLAN_GENERALMANEJOFORESTAL_ESPECIES_FAUNA",
                            COD_PGMF: hdCOD_PGMF,
                            COD_ESPECIES: $trEliminar.find('.hdCodEspecie').val(),
                            COD_AMENAZA: $trEliminar.find(".hdCodAmenaza").val(),
                            COD_SECUENCIAL: $trEliminar.find('.hdCodSecuencial').val()
                        });
                    }
                });
                ManPM.frm.find('#tbEspeciesFauna').dataTable().fnClearTable();
                utilSigo.toastSuccess("Aviso", "Se eliminaron todos los registros");
            }
        });
    } else {
        utilSigo.toastWarning("Aviso", "No hay Registros a Eliminar");
    }
}
ManPM.eliminarTHabilitante = function (obj) {
    utilSigo.dialogConfirm("Confirmacion", "¿ Está seguro de Eliminar el Registro Seleccionado ?", function (r) {
        if (r) {
            var $trEliminar = $(obj).closest('tr');
            var estadoItemSelec = $trEliminar.find(".hdEstadoItem").val();
            if (parseInt(estadoItemSelec) == 0 || parseInt(estadoItemSelec) == 2) {
                var hdCOD_PGMF = ManPM.frm.find("#hdfManCOD_PGMF").val();
                var columnasFila = $trEliminar.find('td');
                ManPM.ListEliTABLA.push({
                    EliTABLA: "PLAN_GENERALMANEJOFORESTAL_THABILITANTE",
                    COD_PGMF: hdCOD_PGMF,
                    COD_THABILITANTE: $trEliminar.find(".hdCodTH").val()
                });
            }
            //eliminando
            var $tbThabilitante = ManPM.frm.find('#tbThabilitante').dataTable();
            var $trs = $tbThabilitante.$("tr");
            var index = $trs.index($trEliminar);
            ManPM.frm.find('#tbThabilitante').dataTable().fnDeleteRow(index);
            ManPM.enumTB('tbThabilitante');
            ManPM.updateComboDependencia();
            utilSigo.toastSuccess("Aviso", "Se elimino el registro");
        }
    });
}
ManPM.iniciarFechas = function (id) {
    ManPM.frm.find("#"+id).datepicker({
        format: "dd/mm/yyyy",
        autoclose: true,
        language: 'es'
    });
}
ManPM.iniciarTituloLabel = function () {
    if (parseInt(ManPM.frm.find("#esPMFI").val()) != 0)
    {
        ManPM.frm.find("#lblNumInfAprob").text('Número de Informe que recomendó la aprobación del PMFI');
        ManPM.frm.find("#lblProfesional").text('Profesional que recomendó la aprobación del PMFI');
        ManPM.frm.find("#lblConsultor").text('Consultor/Regente que elaboró del PMFI');
    }    
}

ManPM.fnBuscarPersona = function (_dom, _tipoPersonaSIGOsfc) {
    var url = urlLocalSigo + "General/Controles/_BuscarPersonaGeneral";
    var option = { url: url, type: 'GET', datos: { asBusGrupo: "PERSONA", asCodPTipo: _tipoPersonaSIGOsfc, asTipoPersona: "N" }, divId: "mdlBuscarPersona" };
    utilSigo.fnOpenModal(option, function () {
        _bPerGen.fnAsignarDatos = function (obj) {
            if (obj != null && obj != "") {
                var data = _bPerGen.dtBuscarPerona.row($(obj).parents('tr')).data();
                switch (_dom) {
                    case "RAPROBACION":
                        ManPM.frm.find("#hdtxtProfesionalRecomendo").val(data["COD_PERSONA"]);
                        ManPM.frm.find("#txtProfesionalRecomendo").val(data["PERSONA"]);
                        break;
                    case "CONSULTOR":
                        ManPM.fnSetPersonaCompleto(_dom,data["COD_PERSONA"]);
                        break;
                    case "FRAPRUEBA_FIRMA":
                        ManPM.frm.find("#hdtxtFuncionarioFirma").val(data["COD_PERSONA"]);
                        ManPM.frm.find("#txtFuncionarioFirma").val(data["PERSONA"]);
                        break;
                }
                utilSigo.fnCloseModal("mdlBuscarPersona");
            }
        }
        _bPerGen.fnInit();
    });
}
ManPM.fnSetPersonaCompleto = function (_dom, codPersona) {
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
                    case "CONSULTOR":
                        ManPM.frm.find("#hdtxtConsultorElaboro").val(data.data["COD_PERSONA"]);
                        ManPM.frm.find("#txtConsultorElaboro").val(data.data["APELLIDOS_NOMBRES"]);
                        ManPM.frm.find("#txtNumAFFS").val(data.data["NUM_REGISTRO_FFS"]);
                        ManPM.frm.find("#txtNumCIP").val(data.data["NUM_REGISTRO_PROFESIONAL"]);
                        break;
                }
            } else {
                utilSigo.toastError("Error", "No se pudo consultar los datos de la persona");
                console.log(data.msj);
                return false;
            }
        }
    });
}

ManPM.validacionGeneral = function () {
    var ids = ["ddlItemIndicadorId", "ddlODRegistroId", "txtNumInfAprob", "txtFechaAprobacionInf", "txtNumResolucion", "txtFechaAprobacion", "txtBloques", "txtAreaPGMF", "txtPeriodo", "txtFechaIncioPeriodo", "txtFechaTerminoPeriodo"];
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

ManPM.iniciarEventos = function () {
    ManPM.frm.find("#btnNuevoEspecie").click(function () {
        ManPM.opcRegItem = "NUE";
        ManPM.TraerDataEspecieAprobada();
    });
    ManPM.frm.find("#btnNuevoCoordenada").click(function () {
        var urlC = urlLocalSigo + "THabilitante/ManPlanManejoForestal/_Coordenadas";
        var datosC = {};
        ManPM.opcRegItem = "NUE";
        ManPM.mostrarModal("modalCoordenadaPM", urlC, datosC);
    });
    ManPM.frm.find("#btnNuevoEspecieFS").click(function () {
        var urlC = urlLocalSigo + "THabilitante/ManPlanManejoForestal/_EspeciesFaunaS";
        var datosC = {};
        ManPM.opcRegItem = "NUE";
        ManPM.mostrarModal("modalEspecieFSPM", urlC, datosC);
    });
    ManPM.frm.find("#btnAgregarTH").click(function () {
        var urlC = urlLocalSigo + "THabilitante/Controles/_THabilitante";
        var datosC = { hdfFormulario: "TITULO_HABILITANTE", idModal: "modalTHabilitantePM" };
        ManPM.mostrarModal("modalTHabilitantePM", urlC, datosC);
    });
    ManPM.frm.find("#btnProfesional").click(function () {
        ManPM.fnBuscarPersona("RAPROBACION", "0000006");//Profesional que recomendó la aprobación del PGMF
    });
    ManPM.frm.find("#btnConsultor").click(function () {
        ManPM.fnBuscarPersona("CONSULTOR", "0000003");//Consultor/Regente que elaboró del PGMF
    });
    ManPM.frm.find("#btnFuncionarioFirma").click(function () {
        ManPM.fnBuscarPersona("FRAPRUEBA_FIRMA", "0000006");//Funcionario que firma la resolución
    });
    $("#btnRegresarPM").click(function () {
            ManPM.regresar("");
    });
    $("#btnRegistrarPM").click(function () {
        if (!ManPM.validacionGeneral()) {
            return ManPM.frm.valid();
        }        
        ManPM.frm.submit();
    });
    ManPM.frm.find("#ddlItemIndicadorId").change(function () {
        var cboVal = $(this).val();        
        if (cboVal == "0000007") {
           
            ManPM.frm.find("#divCKEDITOR").removeAttr("style");
            if (ManPM.banderaCKEDITOR==0)
               ManPM.iniciarCKEDITOR("PLAN_GENERAL_MANEJO_FORESTAL", ManPM.frm.find("#hdfManCOD_PGMF").val());
            ManPM.banderaCKEDITOR = 1;
            ManPM.banderaCKEDITORBD = 1;
        }
        else {                       
            //ManPM.frm.find("#divCKEDITOR").html('');
            //if (ManPM.banderaCKEDITOR==1)
            //{               
            //    CKEDITOR.remove(CKEDITOR.instances["OBSERVACIONES_CONTROL"]);
            //}               
            ManPM.frm.find("#divCKEDITOR").attr("style", "display:none;");           
            ManPM.banderaCKEDITORBD = 0;
        }

    });
}

ManPM.fnValidarBloque = function () {
    var valNumBloque = 0;
    var valesPMFI = ManPM.frm.find("#esPMFI").val();

    if (parseInt(valesPMFI) == 0) {
        valNumBloque = ManPM.frm.find("#txtBloques").val().trim();
        if (valNumBloque == "") {
            utilSigo.toastWarning("Aviso", "Ingrese número de bloques");
            ManPM.frm.find("#txtBloques").focus();
            ManPM.frm.find("#fileEspecieAprobada").attr('disabled', true);
            return false;
        }
        if (parseInt(valNumBloque) <= 0) {
            utilSigo.toastWarning("Aviso", "Ingrese número de bloques mayor a cero");
            ManPM.frm.find("#txtBloques").focus();
            ManPM.frm.find("#fileEspecieAprobada").attr('disabled', true);
            return false;
        }
    }
}

ManPM.fnImportarEspecieAprobada = function (e, obj) {
    var url = urlLocalSigo + "THabilitante/ManPlanManejoForestal/ImportarEspecieAprobada";
    var valesPMFI = ManPM.frm.find("#esPMFI").val();
    var valNumBloque = parseInt(ManPM.frm.find("#txtBloques").val().trim());

    uploadFile.fileSelectHandler(e, obj, url, { esPMFI: valesPMFI, numBloque: valNumBloque}, function (data) {
        if (data.length > 0) {
            $.each(data, function (i, o) {
                var $tbEspecies = ManPM.frm.find('#tbEspecies').dataTable();
                var $rows = $tbEspecies.$("tr");
                var countFilas = $rows.length;
                var codSecE = parseInt(countFilas) + 1;
                /*var filaE = [{
                    itemE: 1, codSec: codSecE, des: o.DESCRIPCION, numArb: o.NUM_ARBOLES,
                    vol: o.VOLUMEN, numB: parseInt(o.DESC_BLOQUE.substr(9, o.DESC_BLOQUE.length)), descB: o.DESC_BLOQUE
                }];*/
                var filaE = [{
                    itemE: 1, codSec: codSecE, codEsp: o.COD_ESPECIES, des: o.DESCRIPCION, numArb: o.NUM_ARBOLES,
                    vol: o.VOLUMEN, numB: o.NUM_BLOQUES
                }];
                ManPM.frm.find('#tbEspecies').dataTable().fnAddData(filaE);
                ManPM.enumTB('tbEspecies');
                ManPM.frm.find('#tbEspecies').DataTable().page('last').draw('page');
            });

            ManPM.frm.find("#fileEspecieAprobada").val(null);
        }
    });
}

ManPM.fnImportarCoordenada = function (e, obj) {
    var url = urlLocalSigo + "THabilitante/ManPlanManejoForestal/ImportarCoordenada";

    uploadFile.fileSelectHandler(e, obj, url, { }, function (data) {
        if (data.length > 0) {
            $.each(data, function (i, o) {
                var $tbCoordenadas = ManPM.frm.find('#tbCoordenadas').dataTable();
                var $rows = $tbCoordenadas.$("tr");
                var countFilas = $rows.length;
                var codSecC = parseInt(countFilas) + 1;
                var filaC = [{ itemE: 1, codSec: codSecC, vert: o.VERTICE, coE: o.COORDENADA_ESTE, coN: o.COORDENADA_NORTE, obs: o.OBSERVACIONES }];
                ManPM.frm.find('#tbCoordenadas').dataTable().fnAddData(filaC);
                ManPM.enumTB('tbCoordenadas');
                ManPM.frm.find('#tbCoordenadas').DataTable().page('last').draw('page');
            });

            ManPM.frm.find("#fileCoordenada").val(null);
        }
    });
}

ManPM.fnImportarEspecieFS = function (e, obj) {
    var url = urlLocalSigo + "THabilitante/ManPlanManejoForestal/ImportarEspecieFS";

    uploadFile.fileSelectHandler(e, obj, url, { }, function (data) {
        if (data.length > 0) {
            $.each(data, function (i, o) {
                var $tbEspeciesFauna = ManPM.frm.find('#tbEspeciesFauna').dataTable();
                var $rows = $tbEspeciesFauna.$("tr");
                var countFilas = $rows.length;
                var codSecEF = parseInt(countFilas) + 1;
                var filaEF = [{ itemE: 1, codSec: codSecEF, codE: o.COD_ESPECIES, codA: o.COD_AMENAZA, desc: o.DESCRIPCION, desAm: o.DESC_AMENAZA, obs: o.OBSERVACIONES }];
                ManPM.frm.find('#tbEspeciesFauna').dataTable().fnAddData(filaEF);
                ManPM.enumTB('tbEspeciesFauna');
                ManPM.frm.find('#tbEspeciesFauna').DataTable().page('last').draw('page');
            });

            ManPM.frm.find("#fileEspecieFS").val(null);
        }
    });
}

ManPM.fnImportarCoordenada = function (e, obj) {
    var url = urlLocalSigo + "THabilitante/ManPlanManejoForestal/ImportarCoordenada";

    uploadFile.fileSelectHandler(e, obj, url, { }, function (data) {
        if (data.length > 0) {
            $.each(data, function (i, o) {
                var $tbCoordenadas = ManPM.frm.find('#tbCoordenadas').dataTable();
                var $rows = $tbCoordenadas.$("tr");
                var countFilas = $rows.length;
                var codSecC = parseInt(countFilas) + 1;
                var filaC = [{ itemE: 1, codSec: codSecC, vert: o.VERTICE, coE: o.COORDENADA_ESTE, coN: o.COORDENADA_NORTE, obs: o.OBSERVACIONES }];
                ManPM.frm.find('#tbCoordenadas').dataTable().fnAddData(filaC);
                ManPM.enumTB('tbCoordenadas');
                ManPM.frm.find('#tbCoordenadas').DataTable().page('last').draw('page');
            });

            ManPM.frm.find("#fileCoordenada").val(null);
        }
    });
}

ManPM.fnImportarEspecieFS = function (e, obj) {
    var url = urlLocalSigo + "THabilitante/ManPlanManejoForestal/ImportarEspecieFS";

    uploadFile.fileSelectHandler(e, obj, url, { }, function (data) {
        if (data.length > 0) {
            $.each(data, function (i, o) {
                var $tbEspeciesFauna = ManPM.frm.find('#tbEspeciesFauna').dataTable();
                var $rows = $tbEspeciesFauna.$("tr");
                var countFilas = $rows.length;
                var codSecEF = parseInt(countFilas) + 1;
                var filaEF = [{ itemE: 1, codSec: codSecEF, codE: o.COD_ESPECIES, codA: o.COD_AMENAZA, desc: o.DESCRIPCION, desAm: o.DESC_AMENAZA, obs: o.OBSERVACIONES }];
                ManPM.frm.find('#tbEspeciesFauna').dataTable().fnAddData(filaEF);
                ManPM.enumTB('tbEspeciesFauna');
                ManPM.frm.find('#tbEspeciesFauna').DataTable().page('last').draw('page');
            });

            ManPM.frm.find("#fileEspecieFS").val(null);
        }
    });
}

ManPM.iniciarTablas = function () {       
    ManPM.frm.find("#tbThabilitante").DataTable({
        "bServerSide": false,
        "ajax": { "url": urlLocalSigo + "THabilitante/ManPlanManejoForestal/GetAllTHabilitantePM", "type": "GET", "datatype": "json" },
        "bAutoWidth": false,
        "bProcessing": true,
        "bJQueryUI": false,
        //"bRetrieve": true,
        "bFilter": false,
        "aaSorting": [],
        //"bPaginate": true,
        // "bLengthChange": false,       
        //"scrollY": "50vh",
        //"scrollCollapse": true,
        "pageLength": initSigo.pageLength,
        "oLanguage": initSigo.oLanguage,
        "drawCallback": initSigo.showPagination,
        "columns":
            [
                {
                    "autoWidth": true, "bSortable": false, "sClass": "tdIcoconCenter", "data": "ind",
                    "mRender": function (data, type, row) {
                        var cell = '<input type="hidden" class="hdLinea" value="' + row.dl + '" /><input type="hidden" class="hdEstadoItem" value="' + row.itemE + '" /><input type="hidden" class="hdCodTH" value="' + row.cod + '" /><i class="fa fa-lg fa-window-close" style="color:red;cursor:pointer;" title="Eliminar" onclick="ManPM.eliminarTHabilitante(this);"></i>';
                        return cell;
                    }
                },
                { "data": "ind", "autoWidth": true },
                { "data": "mod", "autoWidth": true },
                { "data": "desc", "autoWidth": true },
                { "data": "pt", "autoWidth": true },
                { "data": "codOr", "autoWidth": true }

            ]
    });
    var contEspecies = 1;
    ManPM.frm.find("#tbEspecies").DataTable({
        "bServerSide": false,
        "ajax": { "url": urlLocalSigo + "THabilitante/ManPlanManejoForestal/GetAllEpeciesPM", "type": "GET", "datatype": "json" },
        "bAutoWidth": false,
        "bProcessing": true,
        "bJQueryUI": false,
        //"bRetrieve": true,
        //"bFilter": true,
        "aaSorting": [],
        "bPaginate": true,
        // "bLengthChange": false,  
        "pageLength": initSigo.pageLength,
        "oLanguage": initSigo.oLanguage,
        "drawCallback": initSigo.showPagination,
        "columns":
            [
                {
                    "autoWidth": true, "bSortable": false, "sClass": "tdIcoconCenter", "data": "codSec",
                    "mRender": function (data, type, row) {
                        var cell = '<input type="hidden" class="hdEstadoItem" value="' + row.itemE + '" /><input type="hidden" class="hdCodSecuencial" value="' + row.codSec + '" /><input type="hidden" class="hdCodEspecie" value="' + row.codEsp + '" />' +
                            '<i class="fa fa-lg fa-pencil-square-o" style="color:blue;cursor:pointer;margin-right:20px;" title="Editar" onclick="ManPM.editarEspecies(this);"></i>'+
                            '<i class="fa fa-lg fa-window-close" style="color:red;cursor:pointer;" title="Eliminar" onclick="ManPM.eliminarEspecies(this);"></i>';
                        return cell;
                    }
                },
                {
                    "autoWidth": true, "bSortable": false, "data": "codEsp",
                    "mRender": function (data, type, row) {
                        var cell = contEspecies;
                        contEspecies++;
                        return cell;
                    }
                },
                {
                    "data": "des", "autoWidth": true,
                    "mRender": function (data, type, row) {
                        var cell = '<input type="hidden" class="hdDescEspecie" value="' + row.des + '" />' + row.des;
                        return cell;
                    }
                },
                {
                    "data": "numArb", "autoWidth": true,
                    "mRender": function (data, type, row) {
                        var cell = '<input type="hidden" class="hdNumArbol" value="' + row.numArb + '" />' + row.numArb;
                        return cell;
                    }
                },
                {
                    "data": "vol", "autoWidth": true,
                    "mRender": function (data, type, row) {
                        var cell = '<input type="hidden" class="hdVolumen" value="' + row.vol + '" />' + row.vol;
                        return cell;
                    }
                },
                {
                    "data": "numB", "autoWidth": true,
                    "mRender": function (data, type, row) {
                        var cell = '<input type="hidden" class="hdNumBloque" value="' + row.numB + '" />' + row.numB;
                        return cell;
                    }
                },
                {
                    "data": "descB", "visible": false,
                    "mRender": function (data, type, row) {
                        var cell = '<input type="hidden" class="hdDescBloque" value="' + row.descB + '" />' + row.descB;
                        return cell;
                    }
                }
            ]
    });
    var contCoordenadas = 1;
    ManPM.frm.find("#tbCoordenadas").DataTable({
        "bServerSide": false,
        "ajax": { "url": urlLocalSigo + "THabilitante/ManPlanManejoForestal/GetAllCoordenadasPM", "type": "GET", "datatype": "json" },
        "bAutoWidth": false,
        "bProcessing": true,
        "bJQueryUI": false,
        //"bRetrieve": true,
        //"bFilter": true,
        "aaSorting": [],
        "bPaginate": true,
        // "bLengthChange": false, 
        "pageLength": initSigo.pageLength,
        "oLanguage": initSigo.oLanguage,
        "drawCallback": initSigo.showPagination,
        "columns":
            [
                {
                    "autoWidth": true, "bSortable": false, "sClass": "tdIcoconCenter", "data": "codSec",
                    "mRender": function (data, type, row) {
                        var cell = '<input type="hidden" class="hdVertice" value="' + row.vert + '" /><input type="hidden" class="hdEstadoItem" value="' + row.itemE + '" /><input type="hidden" class="hdCodSecuencial" value="' + row.codSec + '" />' +
                            '<i class="fa fa-lg fa-pencil-square-o" style="color:blue;cursor:pointer;margin-right:20px;" title="Editar" onclick="ManPM.editarCoordenadas(this);"></i>' +
                            '<i class="fa fa-lg fa-window-close" style="color:red;cursor:pointer;" title="Eliminar" onclick="ManPM.eliminarCoordenadas(this);"></i>';
                        return cell;
                    }
                },
                {
                    "autoWidth": true, "bSortable": false, "data": "codSec",
                    "mRender": function (data, type, row) {
                        var cell = contCoordenadas;
                        contCoordenadas++;
                        return cell;
                    }
                },
                {
                    "data": "vert", "autoWidth": true,
                    "mRender": function (data, type, row) {
                        var cell = '<input type="hidden" class="hdNombreVertice" value="' + row.vert + '" />' + row.vert;
                        return cell;
                    }
                },
                {
                    "data": "coE", "autoWidth": true,
                    "mRender": function (data, type, row) {
                        var cell = '<input type="hidden" class="hdCoordenadaEste" value="' + row.coE + '" />' + row.coE;
                        return cell;
                    }
                },
                {
                    "data": "coN", "autoWidth": true,
                    "mRender": function (data, type, row) {
                        var cell = '<input type="hidden" class="hdCoordenadaNorte" value="' + row.coN + '" />' + row.coN;
                        return cell;
                    }
                },
                {
                    "data": "obs", "autoWidth": true,
                    "mRender": function (data, type, row) {
                        var cell = '<input type="hidden" class="hdObservacion" value="' + row.obs + '" />' + row.obs;
                        return cell;
                    }
                }
            ]
    });
    var contEspeciesFauna = 1;
    ManPM.frm.find("#tbEspeciesFauna").DataTable({
        "bServerSide": false,
        "ajax": { "url": urlLocalSigo + "THabilitante/ManPlanManejoForestal/GetAllEspeciesFaunaPM", "type": "GET", "datatype": "json" },
        "bAutoWidth": false,
        "bProcessing": true,
        "bJQueryUI": false,
        //"bRetrieve": true,
        //"bFilter": true,
        "aaSorting": [],
        "bPaginate": true,
        // "bLengthChange": false,  
        "pageLength": initSigo.pageLength,
        "oLanguage": initSigo.oLanguage,
        "drawCallback": initSigo.showPagination,
        "columns":
            [
                {
                    "autoWidth": true, "bSortable": false, "sClass": "tdIcoconCenter", "data": "codSec",
                    "mRender": function (data, type, row) {
                        var cell = '<input type="hidden" class="hdCodAmenaza" value="' + row.codA + '" /><input type="hidden" class="hdCodEspecie" value="' + row.codE + '" /><input type="hidden" class="hdEstadoItem" value="' + row.itemE + '" /><input type="hidden" class="hdCodSecuencial" value="' + row.codSec + '" />' +
                            '<i class="fa fa-lg fa-pencil-square-o" style="color:blue;cursor:pointer;margin-right:20px;" title="Editar" onclick="ManPM.editarEspeciesFS(this);"></i>' +
                            '<i class="fa fa-lg fa-window-close" style="color:red;cursor:pointer;" title="Eliminar" onclick="ManPM.eliminarEspeciesFS(this);"></i>';
                        return cell;
                    }
                },
                {
                    "autoWidth": true, "bSortable": false, "data": "codSec",
                    "mRender": function (data, type, row) {
                        var cell = contEspeciesFauna;
                        contEspeciesFauna++;
                        return cell;
                    }
                },
                {
                    "data": "desc", "autoWidth": true,
                    "mRender": function (data, type, row) {
                        var cell = '<input type="hidden" class="hdDescEspecie" value="' + row.desc + '" />' + row.desc;
                        return cell;
                    }
                },
                {
                    "data": "desAm", "autoWidth": true,
                    "mRender": function (data, type, row) {
                        var cell = '<input type="hidden" class="hdDescAmenaza" value="' + row.desAm + '" />' + row.desAm;
                        return cell;
                    }
                },
                {
                    "data": "obs", "autoWidth": true,
                    "mRender": function (data, type, row) {
                        var cell = '<input type="hidden" class="hdObservacion" value="' + row.obs + '" />' + row.obs;
                        return cell;
                    }
                }
            ]
    });
}
ManPM.obtenerValorCheck = function (control) {
    var check =ManPM.frm.find("#" + control);
    var state = check.is(":checked");
    if (state) {
        return true;
    } else {
        return false;
    }
}
ManPM.validarDatosAdicionales = function () {
    //validando titulo habilitante
    var countFilasTH = ManPM.frm.find("#tbThabilitante").DataTable().rows().count();    
    if (countFilasTH < 1) {
        $('a[href="#navDatos"]').tab('show');
        utilSigo.toastWarning("Aviso", "Selecione el/los título(s) habilitante(s)");
        return false;
    }
    return true;
}
ManPM.prepararDatosTH = function () {
    ManPM.ListTHabilitante = [];
    var $tablaTH = ManPM.frm.find("#tbThabilitante").dataTable();
    var $rows = $tablaTH.$("tr");
    var countFilas = $rows.length;
    if(countFilas>0){
        $.each($rows, function (i, o) {
            var estadoItemReg = $(o).find(".hdEstadoItem").val();
            if (parseInt(estadoItemReg) == 1 || parseInt(estadoItemReg) == 2 || parseInt(estadoItemReg) == 0) { //solo envio los registros nuevos                
                ManPM.ListTHabilitante.push({
                                                COD_THABILITANTE: $(o).find('.hdCodTH').val(),
                                                RegEstado: $(o).find('.hdEstadoItem').val()
                                           });
            }
        });
    }
}


ManPM.prepararDatosEspecies = function () {
    ManPM.ListEspecies = [];
    var $tablaEsp = ManPM.frm.find("#tbEspecies").dataTable();
    var $rows = $tablaEsp.$("tr");
    var countFilas = $rows.length;
    if (countFilas > 0) {
        $.each($rows, function (i, o) {
            var estadoItemReg = $(o).find(".hdEstadoItem").val();
            if (parseInt(estadoItemReg) == 1 || parseInt(estadoItemReg) == 2) { //solo envio los registros nuevos 
                var $columna = $(o).find('td');
                ManPM.ListEspecies.push({
                    COD_ESPECIES: $(o).find('.hdCodEspecie').val(),
                    NUM_BLOQUES: $columna.eq(5).text().trim(),
                    NUM_ARBOLES: $columna.eq(3).text().trim(),
                    VOLUMEN: $columna.eq(4).text().trim(),
                    COD_SECUENCIAL: $(o).find('.hdCodSecuencial').val(),
                    RegEstado: $(o).find(".hdEstadoItem").val()
                });
            }
        });
    }
}
ManPM.prepararDatosCoordenadas = function () {
    ManPM.ListCoordenadas = [];
    var $tablaCoord = ManPM.frm.find("#tbCoordenadas").dataTable();
    var $rows = $tablaCoord.$("tr");
    var countFilas = $rows.length;
    if (countFilas > 0) {
        $.each($rows, function (i, o) {
            var estadoItemReg = $(o).find(".hdEstadoItem").val();
            if (parseInt(estadoItemReg) == 1 || parseInt(estadoItemReg) == 2) { //solo envio los registros nuevos 
                var $columna = $(o).find('td');
                ManPM.ListCoordenadas.push({
                    VERTICE: $columna.eq(2).text().trim(),
                    COORDENADA_ESTE: $columna.eq(3).text().trim(),
                    COORDENADA_NORTE: $columna.eq(4).text().trim(),
                    OBSERVACIONES: $columna.eq(5).text().trim(),
                    COD_SECUENCIAL: $(o).find('.hdCodSecuencial').val(),
                    RegEstado: $(o).find(".hdEstadoItem").val()
                });
            }
        });
    }
}
ManPM.prepararDatosEspFS = function () {
    ManPM.ListEspeciesFauna = [];
    var $tablaEspFS = ManPM.frm.find("#tbEspeciesFauna").dataTable();
    var $rows = $tablaEspFS.$("tr");
    var countFilas = $rows.length;
    if (countFilas > 0) {
        $.each($rows, function (i, o) {
            var estadoItemReg = $(o).find(".hdEstadoItem").val();
            if (parseInt(estadoItemReg) == 1 || parseInt(estadoItemReg) == 2) { //solo envio los registros nuevos 
                var $columna = $(o).find('td');
                ManPM.ListEspeciesFauna.push({
                    COD_ESPECIES: $(o).find('.hdCodEspecie').val(),
                    COD_AMENAZA: $(o).find('.hdCodAmenaza').val(),
                    OBSERVACIONES: $columna.eq(4).text().trim(),                   
                    COD_SECUENCIAL: $(o).find('.hdCodSecuencial').val(),
                    RegEstado: $(o).find(".hdEstadoItem").val()
                });
            }
        });
    }
} 
ManPM.iniciarCKEDITOR = function (form, codigo) {
    ManPM.banderaCKEDITORBD = 1;
    $.ajax({
        url: urlLocalSigo + "THabilitante/Controles/_VPCKEDITOR",
        type: 'GET',
        data: { formulario: form, codigo:codigo},
        dataType: 'html',
        success: function (data) {
           // utilSigo.unblockUIGeneral();
            utilSigo.unblockUIElement("#divCKEDITOR");
            ManPM.frm.find("#divCKEDITOR").html(data);
            if (ManPM.frm.find("#ddlItemIndicadorEnable").val() == "False") {
                ManPM.frm.find("#OBSERVACIONES_CONTROL").attr('disabled', 'disabled');
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
            console.log(jqXHR.responseText);
        }
    });
}
ManPM.regresar = function (appServer) {  
    if (ManPM.frm.find("#opRegresar").val() == 0) {
        var valesPMFI = ManPM.frm.find("#esPMFI").val();
        var url = urlLocalSigo + "THabilitante/ManPlanManejoForestal/Index?opt=" + valesPMFI;
        window.location = url;
    } else {
        var appClient = ManPM.frm.find("#appClient").val();
        var appData = ManPM.frm.find("#appData").val();
        var url = urlLocalSigo + "THabilitante/ManVentanillaAntecedentesExpedientes/Index?appClient=" + appClient + "&appData=" + appData + "&appServer=" + appServer;
        window.location = url;
    }
}
ManPM.registrarPlanManejoForestal = function () {     
    var datosPMF = ManPM.frm.serializeObject();
    datosPMF.txtNumResolucion = ManPM.frm.find("#txtNumResolucion").val().trim();
    datosPMF.chckprimerQuinquenio = ManPM.obtenerValorCheck("chckprimerQuinquenio");
    datosPMF.chckSegundoQuinquenio = ManPM.obtenerValorCheck("chckSegundoQuinquenio");
    datosPMF.chckTercerQuinquenio = ManPM.obtenerValorCheck("chckTercerQuinquenio");
    datosPMF.chckCuartoQuinquenio = ManPM.obtenerValorCheck("chckCuartoQuinquenio");
    datosPMF.chckConsolidad = ManPM.obtenerValorCheck("chckConsolidad");
    datosPMF.OBSERV_SUBSANAR = ManPM.obtenerValorCheck("OBSERV_SUBSANAR");
    datosPMF.ddlItemIndicadorId = ManPM.frm.find("#ddlItemIndicadorId").val();    
    if( ManPM.banderaCKEDITORBD == 1)
        datosPMF.txtControlCalidadObservaciones =CKEDITOR.instances["OBSERVACIONES_CONTROL"].getData();
    ManPM.prepararDatosTH();
    datosPMF.ListTHabilitante = ManPM.ListTHabilitante;
    ManPM.prepararDatosEspecies();
    datosPMF.ListEspecies = ManPM.ListEspecies;
    ManPM.prepararDatosCoordenadas();
    datosPMF.ListCoordenadas = ManPM.ListCoordenadas;
    ManPM.prepararDatosEspFS();
    datosPMF.ListEspeciesFauna = ManPM.ListEspeciesFauna;
    datosPMF.ListEliTABLA = ManPM.ListEliTABLA;
    //enviando datos al servidor
    $.ajax({
        url: urlLocalSigo + "THabilitante/ManPlanManejoForestal/AddEdit",
        type: 'POST',
        data: JSON.stringify(datosPMF),
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function (data) {
            utilSigo.unblockUIGeneral();
            if (data.success) {
                if (ManPM.frm.find("#opRegresar").val() == 0) {
                    utilSigo.toastSuccess("Aviso", data.msj);
                    setTimeout(function () {
                        ManPM.regresar("");
                    }, 2000);
                } else {
                    ManPM.regresar(data.appServer);
                }
            }
            else {
                if (ManPM.frm.find("#opRegresar").val() == 0) {
                    utilSigo.toastWarning("Aviso", data.msj);
                } else {
                    ManPM.regresar(data.appServer);
                }
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

$(document).ready(function () {

    ManPM.frm = $("#frmPlanManejoGeneral");
    if (ManPM.frm.find("#ddlItemIndicadorId").val() == "0000007") {
        ManPM.frm.find("#divCKEDITOR").removeAttr("style");
        ManPM.frm.find("#divObsSubsanado").removeAttr("style");
        if (ManPM.banderaCKEDITOR == 0)
            ManPM.iniciarCKEDITOR("PLAN_GENERAL_MANEJO_FORESTAL", ManPM.frm.find("#hdfManCOD_PGMF").val());
        ManPM.banderaCKEDITOR = 1;
        ManPM.banderaCKEDITORBD = 1;
    }
    ManPM.iniciarTituloLabel();
    //fechas
    ManPM.iniciarFechas('txtFechaAprobacionInf');
    ManPM.iniciarFechas('txtFechaAprobacion');
    ManPM.iniciarFechas('txtFechaIncioPeriodo');
    ManPM.iniciarFechas('txtFechaTerminoPeriodo');
    ManPM.iniciarEventos();
    //iniciando tablas
    ManPM.iniciarTablas();

    $.fn.select2.defaults.set("theme", "bootstrap4");

    ManPM.frm.find("#txtBloques").keyup(function () {
        ManPM.frm.find("#fileEspecieAprobada").attr('disabled', false);
    });

    //registrando datos
    // Creamos una validacion personalizada
    jQuery.validator.addMethod("invalidFrmPlanManejo", function (value, element) {
        switch ($(element).attr('id')) {
            case 'ddlItemIndicadorId':
                return (value == '0000000') ? false : true;
                break;
            case 'ddlODRegistroId':
                return (value == '0000000') ? false : true;
                break
        }
    });
    ManPM.frm.validate({
        focusInvalid: true,
        ignore: [],// hiden predeterminado
        rules: {
            ddlItemIndicadorId: { invalidFrmPlanManejo: true },
            ddlODRegistroId: { invalidFrmPlanManejo: true },
            txtNumInfAprob: { required: true },
            txtFechaAprobacionInf: { required: true },
            txtNumResolucion: { required: true },
            txtFechaAprobacion: { required: true },
            txtBloques: { required: true },
            txtAreaPGMF: { required: true },
            txtPeriodo: { required: true },
            txtFechaIncioPeriodo: { required: true },
            txtFechaTerminoPeriodo: { required: true }
        },
        messages: {
            ddlItemIndicadorId: { invalidFrmPlanManejo: "Debe seleccionar la situación actual de su registro" },
            ddlODRegistroId: { invalidFrmPlanManejo: "Debe seleccionar la O.D. desde donde se registra la información" },
            txtNumInfAprob: { required: "Ingrese el Número de Informe que recomendó la aprobación" },
            txtFechaAprobacionInf: { required: "Ingrese Fecha" },
            txtNumResolucion: { required: "Ingrese el Número de resolución de aprobación" },
            txtFechaAprobacion: { required: "Ingrese Fecha" },
            txtBloques: { required: "Ingrese el Número de bloques quinquenales" },
            txtAreaPGMF: { required: "Ingrese el Área del PGMF" },
            txtPeriodo: { required: "Ingrese el Periodo del PGMF" },
            txtFechaIncioPeriodo: { required: "Ingrese Fecha Inicio" },
            txtFechaTerminoPeriodo: { required: "Ingrese Fecha Fin" }
        },
        invalidHandler: function (event, validator) {
        },
        errorPlacement: function (error, element) {
            var lElement = $(element);
            lElement.addClass('border-danger');
            lElement.attr('data-toggle', 'tooltip');
            lElement.attr('data-placement', 'top');
            lElement.attr('data-original-title', error.text());
            $('[data-toggle="tooltip"]').tooltip();
        },
        highlight: function (element) {
            // console.log(element);
        },
        unhighlight: function (element) {
        },
        success: function (label, element) {
            var lElement = $(element);
            lElement.removeClass('border-danger');
            lElement.removeAttr('data-toggle');
            lElement.removeAttr('data-placement');
            lElement.removeAttr('data-original-title');
        },
        submitHandler: function (form) {
            if (ManPM.validarDatosAdicionales()) {
                if (chkEsMenor(ManPM.frm.find("#txtFechaTerminoPeriodo").val(), ManPM.frm.find("#txtFechaIncioPeriodo").val())) {
                    $('a[href="#navDatosAdic"]').tab('show');
                    utilSigo.toastWarning("Aviso", "Fecha de término tiene que ser mayor que la fecha de inicio.");
                    ManPM.frm.find("#txtFechaTerminoPeriodo").focus();
                    return false;
                }
                else {
                    utilSigo.dialogConfirm('', 'Desea continuar con la operación?', function (r) {
                        if (r) {
                            //validando si el numero de resolucion esta en otro registro
                            var url = urlLocalSigo + "THabilitante/ManPlanManejoForestal/ValidarResolucionPGMF";
                            var option = { url: url, datos: { COD_PGMF: ManPM.frm.find("#hdfManCOD_PGMF").val().trim(), NUMERO_PGMF: ManPM.frm.find("#txtNumResolucion").val().trim(), estado: ManPM.frm.find("#hdfManRegEstado").val().trim() }, type: 'GET' };
                            utilSigo.fnAjax(option, function (data) {
                                if (data.success) {
                                    //cuando existe
                                    if (data.paramReturn == 0 || data.paramReturn == 1) {
                                        bootbox.confirm({
                                            message: "El Número PGMF Existe en otro Registro. Desea continuar con la operación?",
                                            buttons: {
                                                confirm: {
                                                    label: 'SI',
                                                    className: 'btn-success'
                                                },
                                                cancel: {
                                                    label: 'NO',
                                                    className: 'btn-danger'
                                                }
                                            },
                                            callback: function (result) {
                                                if (result) {
                                                    ManPM.registrarPlanManejoForestal();
                                                }
                                            }
                                        });
                                    } else {
                                        ManPM.registrarPlanManejoForestal();
                                    }
                                } else {
                                    utilSigo.toastWarning("Aviso", data.msj);
                                }
                            });
                        }
                    });
                }
            }
        }
    });
});