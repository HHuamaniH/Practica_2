"use strict";
var _addEditMuestra = {};
_addEditMuestra.selectFile = [];
_addEditMuestra.lstdelete = [];
/*Controles Datos Adjuntos*/
_addEditMuestra.fnValidaExtension = function (filename) {
    var extension = filename.substr((filename.lastIndexOf('.') + 1));
    var extensiones_permitidas = ["exe", "bin", "bat", "run"];
    var permitido = true;
    for (var i = 0; i < extensiones_permitidas.length; i++) {
        if (extensiones_permitidas[i] == extension) {
            permitido = false;
            break;
        }
    }
    return permitido;
}
_addEditMuestra.fnSelectFile = function (e, obj) {      
    _addEditMuestra.selectFile = [];
    var idFile = $(obj).attr("id");
    var files = e.target.files || e.dataTransfer.files;
    if (files != undefined && files.length > 0) {
        if (files.length > 8) {
            utilSigo.toastWarning("Error", "Seleccione 8 archivos como maximo");            
            return false;
        }        
        var obj = new Object();
        obj.success = true;
        var fileSize = 0;
        var fileNames = [];
        for (var i = 0; i < files.length; i++) {           
            //validando extension
            if (_addEditMuestra.fnValidaExtension(files[i].name) == false) {
               
                obj.nombre = files[i].name;
                obj.success = false;
                obj.msj = "La extension del archivo  : " + obj.nombre + " no es permitido";
                break;
            }
            //validando tamaño
            fileSize = parseFloat(files[i].size);
            if ((fileSize / 1048576) > 12) //7168
            {
                obj.nombre = files[i].name;
                obj.success = false;
                obj.msj = "El tamaño del archivo : " + obj.nombre + " no debe exceder 12MB";
                break;
            }
            //formData.append(files[i].name, files[i]);
           // $("#" + idFile).next().text(files[i].name);
            _addEditMuestra.selectFile.push(files[i]);
            fileNames.push(files[i].name);
         
        }
        if (!obj.success) {
            utilSigo.toastWarning("Error", obj.msj);       
            return false;
        }
        //if (fileNames.length >= 3) {
        //    _addEditMuestra.frm.find("#lblFotos").text(fileNames.join(","));
        //}
       // else {
            $("#" + idFile).next().text(fileNames.join(","));     
       // }
         
    }
}
_addEditMuestra.fnImportFile = function () {
    if (_addEditMuestra.selectFile != null) {
        // Checking whether FormData is available in browser  
        if (window.FormData !== undefined) {
            var url = urlLocalSigo + "Supervision/SeguimientoMuestra/UploadFiles"; 
            var fileData = new FormData();
            for (var i = 0; i < _addEditMuestra.selectFile.length; i++) {
                fileData.append(_addEditMuestra.selectFile[i].name, _addEditMuestra.selectFile[i]);
            }
            $.ajax({
                url: url,
                type: "POST",
                contentType: false, // Not to set any content header  
                processData: false, // Not to process data  
                data: fileData,
                success: function (result) {
                    utilSigo.unblockUIGeneral();
                    if (result.success) {
                        _addEditMuestra.dtFotos.rows.add(result.data).draw();  
                        _addEditMuestra.dtFotos.page('last').draw('page');
                        _addEditMuestra.selectFile = null;                       
                        _addEditMuestra.frm.find("#txtArchivoAdjunto").next().text("Seleccionar Archivo");
                        utilSigo.toastSuccess("Aviso", result.msj);
                    }
                    else {
                        utilSigo.toastWarning("Aviso", result.msj);
                    }
                },
                beforeSend: function () {                    
                    utilSigo.blockUIGeneral();
                },
                error: function (err) {
                    utilSigo.unblockUIGeneral();
                    utilSigo.toastWarning("Aviso", "Sucedio un error, Comuníquese con el Administrador");
                    console.log(err.statusText);
                }
            });
        } else {
            utilSigo.toastWarning("Aviso", "Sucedio un error, Comuníquese con el Administrador");
            console.log("FormData is not available in your browser");
        }
    } else {
        utilSigo.toastWarning("Aviso", "Seleccione un archivo a subir");
    }
}
_addEditMuestra.fnDeleteFoto = function (obj) {
    utilSigo.dialogConfirm("Confirmacion", "¿Está seguro de Eliminar el Registro Seleccionado?",
        function (r) {
            if (r) {
                var $tr = $(obj).closest('tr');
                var row = _addEditMuestra.dtFotos.row($tr).data();
                if (parseInt(row.secuencial) == 0) { //si es un archivo temporal, secuencial es 0
                    var url = urlLocalSigo + "Supervision/SeguimientoMuestra/EliminarArchivo";
                    var option = { url: url, datos:{ name:row.generado}};
                    utilSigo.fnAjax(option, function (data) {
                        if (data.success) {
                            utilSigo.toastSuccess("", "Se elimino correctamente el archivo");
                            _addEditMuestra.dtFotos.row($tr).remove().draw(false);
                        }
                        else {
                            utilSigo.toastWarning("Aviso", "Sucedio un error al eliminar, Comuníquese con el Administrador");
                            console.log(data.msj);
                        }
                    });
                } else {
                    _addEditMuestra.lstdelete.push(row);
                    _addEditMuestra.dtFotos.row($tr).remove().draw(false);
                }          
            }
        });
}
_addEditMuestra.fnDownloadFoto = function (obj) {
    var dt = _addEditMuestra.dtFotos;
    var data = dt.row($(obj).parents('tr')).data();
    if (parseInt(data["secuencial"]) != 0) {
        window.open(urlLocalSigo + "Archivos/Modulo/Supervision/MuestraDendrologica/" + data["generado"], '_blank');
    } else {
        window.open(urlLocalSigo + "Archivos/Modulo/Supervision/MuestraDendrologica/Temp/" + data["generado"], "_blank");
    }
}
_addEditMuestra.fnInitDataTable = function () {
    //Cargar fotos Adjuntas
   var url = urlLocalSigo + "Supervision/SeguimientoMuestra/GetAllFotos";
   var columns_label = ["Foto", "Extensión"];
   var columns_data = ["archivo", "ext"];
   var options = {
        page_length: 5, row_delete: true, row_fnDelete: "_addEditMuestra.fnDeleteFoto(this)"
        , row_download: true, row_fnDownload: "_addEditMuestra.fnDownloadFoto(this)"
        , row_index: true
    };
    _addEditMuestra.dtFotos = utilDt.fnLoadDataTable_Detail(_addEditMuestra.frm.find("#tbFotos"), columns_label, columns_data, options);

    _addEditMuestra.dtFotos.ajax.url(url).load(function (data) {
        if (data.success == false) {
            utilSigo.toastError("Error", "Sucedio un Error Inesperado al Mostrar las Imagenes, Comuníquese con el Administrador");
            console.log(data.msjError);
        }
    });
}
_addEditMuestra.fnShowModalPoa = function () {
    var url = "", sFormulario = "TITULO_HABILITANTE", sCriterio = "CN_DEV_POA_PMANEJO", sValor = addEditSD.frm.find("#codTH").val();
    url = initSigo.urlControllerGeneral + "_POA";
    var option = { url: url, type: 'POST', datos: { asFormulario: sFormulario, asCriterio: sCriterio, asValor: sValor }, divId: "modalBuscarPOA" };
    utilSigo.fnOpenModal(option, function () {
        _POA.fnAsignarDatos = function (obj) {
            if (obj != null && obj != "") {
                //delete data censo
                _addEditMuestra.frm.find('#ddlCensoId').val(null).trigger('change');
                _addEditMuestra.frm.find("#txtCensoAntiguo").val('');
                _addEditMuestra.frm.find("#txtCensoEstado").val('');
                _addEditMuestra.frm.find("#txtCensoCondicion").val('');
                _addEditMuestra.frm.find("#hdcodCenso").val('');
                _addEditMuestra.frm.find("#esMaderable").val(0);
                _addEditMuestra.frm.find("#codSecuencialCenso").val(0);
                var data = _POA.dtPOA.row($(obj).parents('tr')).data();   
                _addEditMuestra.frm.find("#idPoa").val(data.NUM_POA);
                _addEditMuestra.frm.find("#poa").val(data.ESTADO_ORIGEN);
                utilSigo.fnCloseModal("modalBuscarPOA");
            }
        }
        _POA.fnInit();
    });
}

_addEditMuestra.fnAddPersona = function (_dom) {
    var url = urlLocalSigo + "General/Controles/_BuscarPersonaGeneral";
    var option = { url: url, type: 'GET', datos: { asBusGrupo: "PERSONA", asCodPTipo: "TODOS", asTipoPersona: "N" }, divId: "mdlBuscarPersona" };
    utilSigo.fnOpenModal(option, function () {
        _bPerGen.fnAsignarDatos = function (obj) {
            if (obj != null && obj != "") {
                var data = _bPerGen.dtBuscarPerona.row($(obj).parents('tr')).data();
                if (_dom == 1) {
                    _addEditMuestra.frm.find("#colectorDes").val(data.PERSONA);
                    _addEditMuestra.frm.find("#colectorId").val(data.COD_PERSONA);
                } else {
                    _addEditMuestra.frm.find("#supervisoDes").val(data.PERSONA);
                    _addEditMuestra.frm.find("#supervisorId").val(data.COD_PERSONA);
                }
                utilSigo.fnCloseModal("mdlBuscarPersona");
            }
        }
        _bPerGen.fnInit();
    });
}

/*
_addEditMuestra.fnAddPersona = function (opcion) {
    _addEditMuestra.fnModalPersona(opcion, { fFormOrigen: "", cod_P_Tipo: "" });
}
_addEditMuestra.fnModalPersona = function (opcion, datos) {
    var url = urlLocalSigo + "General/Controles/_BuscarPersonaGeneral";
    var option = { url: url, type: 'GET', datos: datos, divId: "modalBuscarPersona" };
    utilSigo.fnOpenModal(option, function () {
        _bPerGen.fnAsignarDatos = function (obj) {
            if (obj != null && obj != "") {
                var data = _bPerGen.dtBuscarPerona.row($(obj).parents('tr')).data();
                if (opcion == 1) {
                    _addEditMuestra.frm.find("#colectorDes").val(data.desc);
                    _addEditMuestra.frm.find("#colectorId").val(data.cod);
                } else {
                    _addEditMuestra.frm.find("#supervisoDes").val(data.desc);
                    _addEditMuestra.frm.find("#supervisorId").val(data.cod);
                }
                utilSigo.fnCloseModal("modalBuscarPersona");
            }
        }
        _bPerGen.fnInit();
    });
}
*/
_addEditMuestra.fnInitEventos = function () {     
    _addEditMuestra.frm.find("#fColeccion").datepicker(initSigo.formatDatePicker);
    _addEditMuestra.frm.validate(utilSigo.fnValidate({
        rules: {
            codMuestra: { required: true },
            fColeccion: { required: true },
            C_ESTE: { required: true },
            C_NORTE: { required: true }
        },
        messages: {
            codMuestra: { required: "Ingrese Codigo" },
            fColeccion: { required: "Ingrese Fecha" },
            C_ESTE: { required: "Ingrese Coord. Este" },
            C_NORTE: { required: "Ingrese Coord. Norte" }
        },
        fnSubmit: function (form) {
            utilSigo.dialogConfirm('', 'Desea continuar con la operacion?', function (r) {
                if (r) {
                    _addEditMuestra.guardar();
                }
            });
        }
    }));
    _addEditMuestra.contenedor.find("#btnGuardar").click(function () {
        _addEditMuestra.frm.submit();
    });
    _addEditMuestra.contenedor.find("#btnCancelar").click(function () {
        _addEditMuestra.fnClose();
    });    
    _addEditMuestra.frm.find("#btnAddPoa").click(function () {       
        _addEditMuestra.fnShowModalPoa();
    });    
    _addEditMuestra.frm.find("#codEspecie").select2({
        placeholder: "Seleccione Especie",
        minimumInputLength: 2,
        allowClear: true,
        ajax: {
            url: urlLocalSigo + "Supervision/SeguimientoMuestra/GetListEspeciePaging",
            dataType: 'json',           
            delay: 250,
            data: function (params) { 
                var term = params.term.trim();
                return {
                    pageSize: 10,
                    pageNum: params.page || 1,
                    searchTerm: term
                };
            },
            processResults: function (data, params) {
                params.page = params.page || 1;
                return {
                    results: data.Results,
                    pagination: {
                        more: (params.page * 10) < data.Total
                    }
                };
            },
            transport: function (params, success, failure) {
                var $request = $.ajax(params);
                $request.then(success);
                $request.fail(failure);
                return $request;
            },
            statusCode: {
                203: () => { utilSigo.unblockUIGeneral(); utilSigo.toastWarning("Aviso", "El usuario perdio la sesión. Vuelva ingresar al sistema"); }
            }
        }
    });
    _addEditMuestra.frm.find("#ddlCensoId").select2({
        placeholder: "Seleccione Censo",
        minimumInputLength: 1,
        allowClear: true,
        ajax: {
            url: initSigo.urlControllerGeneral + "GetComboCensoPaging",
            dataType: 'json',
            delay: 250,
            data: function (params) {
                var term = params.term.trim();
                var IdPoaVerificar = _addEditMuestra.frm.find("#idPoa").val();
                if (IdPoaVerificar == "0" || IdPoaVerificar == "") {
                    utilSigo.toastWarning("Aviso", "Sucedio un error, Falta seleccionar el Nro de Poa");
                    return false;
                } 
                return {
                    pageSize: 10,
                    pageNum: params.page || 1,
                    searchTerm: term,
                    codTH: addEditSD.frm.find("#codTH").val(),
                    poa: _addEditMuestra.frm.find("#idPoa").val()
                };
            },
            processResults: function (data, params) {
                params.page = params.page || 1;
                return {
                    results: data.Results,
                    pagination: {
                        more: (params.page * 10) < data.Total
                    }
                };
            },
            transport: function (params, success, failure) {
                var $request = $.ajax(params);
                $request.then(success);
                $request.fail(failure);
                return $request;
            },
            statusCode: {
                203: () => { utilSigo.unblockUIGeneral(); utilSigo.toastWarning("Aviso", "El usuario perdio la sesión. Vuelva ingresar al sistema"); }
            }
        }
    });
    //
    $('#ddlCensoId').on('select2:select', function (e) {         
        var dataId = e.params.data.id;
        if (dataId != "") {
            var resultado = dataId.split('¬');
            _addEditMuestra.frm.find("#txtCensoAntiguo").val(resultado[3]);
            _addEditMuestra.frm.find("#txtCensoEstado").val(resultado[5]);
            _addEditMuestra.frm.find("#txtCensoCondicion").val(resultado[6]);
            _addEditMuestra.frm.find("#hdcodCenso").val(resultado[7]);
            _addEditMuestra.frm.find("#esMaderable").val(resultado[8]);
            _addEditMuestra.frm.find("#codSecuencialCenso").val(resultado[4]);
        }        
    });
    $('#ddlCensoId').on('select2:unselecting', function (e) {
        _addEditMuestra.frm.find("#txtCensoAntiguo").val('');
        _addEditMuestra.frm.find("#txtCensoEstado").val('');
        _addEditMuestra.frm.find("#txtCensoCondicion").val('');
        _addEditMuestra.frm.find("#hdcodCenso").val('');
        _addEditMuestra.frm.find("#esMaderable").val(0);
        _addEditMuestra.frm.find("#codSecuencialCenso").val(0);
    });
    if (_addEditMuestra.frm.find("#hdcodEspecie").val() != "00000") {
        var codEspecie = _addEditMuestra.frm.find("#hdcodEspecie").val();
        var desEspecie = _addEditMuestra.frm.find("#hdEspecie").val();     
        var $newOption = $("<option></option>").val(codEspecie).text(desEspecie);
        _addEditMuestra.frm.find("#codEspecie").append($newOption).trigger('change');        
    }
    if (_addEditMuestra.frm.find("#hdcodCenso").val().trim() != "") {
        var codEspecieCenso = _addEditMuestra.frm.find("#hdcodCenso").val();  
        var esMaderable = _addEditMuestra.frm.find("#esMaderable").val(); 
        if (esMaderable == 1) codEspecieCenso = codEspecieCenso + ' (M)'; else codEspecieCenso = codEspecieCenso + ' (NM)';
        var $newOption = $("<option></option>").val(codEspecieCenso).text(codEspecieCenso);
        _addEditMuestra.frm.find("#ddlCensoId").append($newOption).trigger('change');
    }    
}
_addEditMuestra.fnGetDataTable = function (dt) {
    var list = [];
    dt.rows().every(function (rowIdx, tableLoop, rowLoop) {
        var row = this.data();
        if (parseInt(row.secuencial) == 0) {
            list.push(row);
        }
    });
    return list;
}
_addEditMuestra.fnClose = function () {
    utilSigo.fnCloseModal("modalAddMuestraDen");
}
_addEditMuestra.guardar = function () {
    var datosMuestra = _addEditMuestra.frm.serializeObject();
    datosMuestra.fotos = _addEditMuestra.fnGetDataTable(_addEditMuestra.dtFotos);
    datosMuestra.codEspecie = _addEditMuestra.frm.find("#codEspecie").val();
    datosMuestra.ddlCensoId = _addEditMuestra.frm.find("#hdcodCenso").val();//$('#ddlCensoId').find(':selected').text(); 
    datosMuestra.chkHSimple = utilSigo.fnGetValChk(_addEditMuestra.frm.find("#chkHSimple"));
    datosMuestra.chkHCompuesta = utilSigo.fnGetValChk(_addEditMuestra.frm.find("#chkHCompuesta"));
    datosMuestra.chkFSimple = utilSigo.fnGetValChk(_addEditMuestra.frm.find("#chkFSimple"));
    datosMuestra.chkFInflorescencia = utilSigo.fnGetValChk(_addEditMuestra.frm.find("#chkFInflorescencia"));
    if (datosMuestra.codEspecie == null) datosMuestra.especieIdent = false;
    else datosMuestra.especieIdent = true;
    datosMuestra.fotosDelete = _addEditMuestra.lstdelete;   
    $.ajax({
        url: urlLocalSigo + "Supervision/SeguimientoMuestra/AddEditMuestra",
        type: 'POST',
        data: JSON.stringify(datosMuestra),
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function (data) {
            utilSigo.unblockUIGeneral();
            if (data.success) {
                _addEditMuestra.fnClose();
                addEditSD.fnLoadTable();
                utilSigo.toastSuccess("Aviso", data.msj);
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
$(document).ready(function () { 
    $.fn.select2.defaults.set("theme", "bootstrap4");
    _addEditMuestra.contenedor = $("#divItemMuestra");
    _addEditMuestra.frm = $("#frmMuestraDendrologica");
    _addEditMuestra.fnInitEventos();
    _addEditMuestra.fnInitDataTable();
    
});