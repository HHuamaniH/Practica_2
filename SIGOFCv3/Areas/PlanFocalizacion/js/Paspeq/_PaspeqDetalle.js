/// <reference path="../../../../scripts/sigo/utility.sigo.js" />
/// <reference path="../../../../scripts/sigo/init.sigo.js" />

"use strict";
var PaspeqEdit = {};
(function () {
    this.controller = urlLocalSigo + "PlanFocalizacion/Paspeq";
    this.fileSelectHandler = function (e, control, url, TVentana) {

        if (e.dataTransfer != undefined &&
            e.dataTransfer.files != undefined) {

            this.resetFileSelect(control, url, TVentana);
        }
        // fetch FileList object
        var files = e.target.files || e.dataTransfer.files;

        if (files != undefined && files.length > 0) {
            this.uploadFileToServer(files[0], control, url, TVentana);
        }
    }
    this.resetFileSelect = function (control, url, TVentana) {
        $("#" + control).replaceWith('<input type="file" id="' + control + '" name="' + control + '" class="form-control" style="display:none;"  onchange="PaspeqEdit.ItemExcelImportarVentana(event,this,\'' + TVentana + '\')"  onclick="return true" />');

    }
    this.uploadFileToServer = function (file, control, url, TVentana) {
        var formdata = new FormData();
        formdata.append(file.name, file);
        formdata.append("TVentana", TVentana);
        formdata.append("hdfItemNum_Paspeq", _PaspeqDetalle.fm.find("#num_paspeq").val());
        formdata.append("hdfItemPeriodo", _PaspeqDetalle.fm.find("#periodo").val());

        $.ajax({
            url: url,
            type: 'POST',
            data: formdata,
            contentType: false,
            dataType: 'json',
            processData: false,
            success: function (data) {
                PaspeqEdit.resetFileSelect(control, url, TVentana);
                utilSigo.unblockUIGeneral();
                if (data.success) {
                    //cargando data
                    if (data.data.length > 0) {
                        if (TVentana == "LISTAPASPEQ")
                            _PaspeqDetalle.fnBuildTable(data.data, "tbListPaspeq", "tbListErroresImportacion");

                        utilSigo.toastSuccess("Aviso", "Se Subio Correctamente la Informacion");
                    }
                    else {
                        utilSigo.toastWarning("Aviso", "No hay registros en la plantilla");
                    }
                }
                else utilSigo.toastWarning("Aviso", data.msj);
            },
            beforeSend: function () {
                PaspeqEdit.resetFileSelect(control, url, TVentana);
                utilSigo.blockUIGeneral();
            },
            error: function (jqXHR, error, errorThrown) {
                utilSigo.unblockUIGeneral();
                utilSigo.toastError("Error", initSigo.MessageError);
                console.log(jqXHR.responseText);
            }
        });
    }
    this.ItemExcelImportarVentana = function (e, objeto, TVentana) {

        var idFile = $(objeto).attr("id");
        var ruta = PaspeqEdit.controller + "/ImportarDataExcel";
        PaspeqEdit.fileSelectHandler(e, idFile, ruta, TVentana);
    }
}).apply(PaspeqEdit);

var _PaspeqDetalle = {
    fnBuildTable: (data, tbName, tbErrores) => {
        if (tbErrores != '')
        {
            $('#divErroresImportacion').show();
            var errores = $('#' + tbErrores);
            var tablaErrores = errores.children('tbody');
            tablaErrores.children('tr').remove();
        }
        var table = $('#' + tbName);
        var tabla = table.children('tbody');
        tabla.children('tr').remove();
        var rows = '';
        var numero = 0;
        var rowsErr = '';
        var numeroErr = 0;
        $.each(data, (i, r) => {
            if (r.resultado == 1) {
                rows += '<tr>';
                rows += '<td>' + `${++numero}` + '</td>';
                rows += '<td>' + `${r.thabilitante}` + '</td>';
                rows += '<td>' + `${r.ubicacion}` + '</td>';
                rows += '<td>' + `${r.oficina}` + '</td>';
                rows += '<td>' + `${r.plan_manejo}` + '</td>';
                rows += '<td>' + `${r.resolucion_aprobacion}` + '</td>';
                rows += '</tr>';
            }
            else if(r.resultado == 0)
            {
                rowsErr += '<tr>';
                rowsErr += '<td>' + `${++numeroErr}` + '</td>';
                rowsErr += '<td>' + `${r.thabilitante}` + '</td>';
                rowsErr += '<td>' + `${r.ubicacion}` + '</td>';
                rowsErr += '<td>' + `${r.oficina}` + '</td>';
                rowsErr += '<td>' + `${r.plan_manejo}` + '</td>';
                rowsErr += '<td>' + `${r.resolucion_aprobacion}` + '</td>';
                rowsErr += '</tr>';
            }
        });
        tabla.append(rows);
        if (tbErrores != '')
        {
            tablaErrores.append(rowsErr);
        }
        
    },
    GetListPaspeq: (dataEnviar) => {
        var url = urlLocalSigo + "PlanFocalizacion/Paspeq/GetListPaspeq";
        var option = { url: url, datos: JSON.stringify(dataEnviar), type: 'POST' };
        utilSigo.fnAjax(option, function (data) {
            if (data.success) {
                _PaspeqDetalle.lstPaspeq = data.data;
                _PaspeqDetalle.fnBuildTable(_PaspeqDetalle.lstPaspeq, "tbListPaspeq", "");
            }
            else {
                utilSigo.toastWarning("Aviso", initSigo.MessageError);
                console.log(data.msjError);
            }
        });
    },
    fnEvent: () => {
        $("#btnRegresarPaspeq").click(function () {
            ManPaspeq.fnShowHide(0);
        });
    },
    fnInit: () => {
        $.fn.select2.defaults.set("theme", "bootstrap4");
        _PaspeqDetalle.fm = $("#frmPaspeqDetalle");
        _PaspeqDetalle.fnEvent();
        //iniciando tablas                
        _PaspeqDetalle.GetListPaspeq({ num_paspeq: _PaspeqDetalle.fm.find("#num_paspeq").val(), periodo: _PaspeqDetalle.fm.find("#periodo").val() });
    }
};
$(function () {
    _PaspeqDetalle.fnInit();
});