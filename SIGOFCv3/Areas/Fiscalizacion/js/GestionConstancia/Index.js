"use strict";
var GestConstancia = {};
var DocGenerado = null;
GestConstancia.selectFile = null;

GestConstancia.fnSearch = function () {
    var valorBusqueda = GestConstancia.frm.find("#txtValor").val().trim();

    if (valorBusqueda == "") {
        utilSigo.toastWarning("Aviso", "Ingrese Valor a Buscar");
        GestConstancia.frm.find("#txtValor").focus();
        return false;
    }
    else {
        var cantCarateres = valorBusqueda.length;
        if (cantCarateres < 3) {
            utilSigo.toastWarning("Aviso", "La longitud del criterio de búsqueda debe ser mayor a dos caracteres");
            GestConstancia.frm.find("#txtValor").focus();
            return false;
        }

        GestConstancia.dtConstancia.ajax.reload();
    }
};

GestConstancia.fnConfig = function () {
    if (window.sessionStorage) {
        var config = {
            CboOpcionId: GestConstancia.frm.find("#ddlOpcionId").val(),
            txtValor: GestConstancia.frm.find("#txtValor").val(),
            PageLength: GestConstancia.dtConstancia.context[0]._iDisplayLength,
            RowStart: GestConstancia.dtConstancia.context[0]._iDisplayStart,
            ColumnOrder: GestConstancia.dtConstancia.context[0].aaSorting[0]
        };
        sessionStorage.setItem('configFrmListaConstancia', JSON.stringify(config));

    } else {
        utilSigo.toastWarning("Aviso", "Para que funcione bien el sistema, Por favor usar navegadores que soporten sessionStorage. Por ejemplo (Google Chrome, Mozilla Firefox)");
    }
};

GestConstancia.fnRefresh = function () {
    GestConstancia.frm.find("#ddlOpcionId").val($(GestConstancia.frm.find("#ddlOpcionId")[0].childNodes[0]).val());
    GestConstancia.frm.find("#txtValor").val("");
    GestConstancia.dtConstancia.ajax.reload();
};

GestConstancia.fnExport = function () {
    var url = urlLocalSigo + "Fiscalizacion/GestionConstancia/ExportarConstancia";
    var params = {
        opcion : GestConstancia.frm.find("#ddlOpcionId").val(),
        txtvalor : GestConstancia.frm.find("#txtValor").val()
    };
    var option = { url: url, datos: JSON.stringify(params), type: 'POST' };

    utilSigo.fnAjax(option, function (data) {
        if (data.success) {
            document.location = urlLocalSigo + "Fiscalizacion/GestionConstancia/Download?file=" + data.msj;
        }
        else {
            if (data.msj == "No se encontraron registros")
                utilSigo.toastInfo("Aviso", "No se encontraron registros");
            else {
                utilSigo.toastWarning("Aviso", "Sucedio un error, Comuníquese con el Administrador");
                console.log(data.msj);
            }
        }
    });
};
GestConstancia.fnDescargar = function (obj) {
    let itemData = GestConstancia.dtConstancia.row($(obj).parents('tr')).data();
    GestConstancia.fnVerDocumento(itemData.NV_CONSTANCIA);
   // document.location = urlLocalSigo + "Fiscalizacion/GestionConstancia/DescargarConstancia?identificador=" + identificador;
}
GestConstancia.fnIniciarFirma = function (obj) {
    let itemData = GestConstancia.dtConstancia.row($(obj).parents('tr')).data();
    let identificador = itemData.NV_CONSTANCIA;
    let modelConstancia = {
        identificador
    };
    let option = { url: `${urlLocalSigo}Fiscalizacion/GestionConstancia/ObtenerById`, datos: JSON.stringify(modelConstancia), type: 'POST' };
    utilSigo.fnAjax(option, function (data) {
        if (data.success) {
            let constancia = data.constancia;
            if (!constancia.ARCHIVO) {
                utilSigo.toastWarning("Aviso", "No existe el nombre del archivo. No se puede continuar con la operación");
                return false;
            }
            let nombreArchivo = constancia.ARCHIVO?.trim();
            let identificador = constancia.NV_CONSTANCIA.trim();
            //Configuracion de variables de firma digital
            _modalInvoker.urlDocument = `Archivos/Constancias/Generados/${nombreArchivo}`;
            _modalInvoker.outputFolder = `Archivos/Constancias/Firmados`;
            _modalInvoker.outputFile = nombreArchivo;
            _modalInvoker.invokerOk = function (e) {
                //Actualizando estado
                let url = urlLocalSigo + "Fiscalizacion/GestionConstancia/ActualizarEstado";
                let model = {
                    identificador,
                    estado: "FIRMADO"
                };
                let option = { url: url, datos: JSON.stringify(model), type: 'POST' };
                utilSigo.fnAjax(option, function (data) {
                    if (data.success) {
                        GestConstancia.dtConstancia.ajax.reload();
                        utilSigo.toastSuccess("Aviso", "La constancia se firmó correctamente");
                    }
                    else {
                        utilSigo.toastWarning("Aviso", "Error al actualizar el estado de la constancia luego de firmar el documento");
                    }
                });
            }
            _modalInvoker.VerDocumento = function () {
                GestConstancia.fnVerDocumento(identificador);
            }
            _modalInvoker.IniciarFirma();
        }
        else {
            utilSigo.toastWarning("Aviso", "Sucedió un error al iniciar al firma");
        }
    });     

}
GestConstancia.fnVerDocumento = function (identificador) {
    let urlFile = "";
    let model = {
        identificador
    };
    let option = { url: `${urlLocalSigo}Fiscalizacion/GestionConstancia/ObtenerValidarById`, datos: JSON.stringify(model), type: 'POST' };
    utilSigo.fnAjax(option, function (data) {
        if (data.success) {
            if (data.constancia) {
                let carpeta = "";
                let constancia = data.constancia;
                if (constancia.ESTADO_DOCUMENTO == "GENERADO") {
                    carpeta = "Archivos/Constancias/Generados/";
                } else if (constancia.ESTADO_DOCUMENTO == "FIRMADO") {
                    carpeta = "Archivos/Constancias/Firmados/";
                } else if (constancia.ESTADO_DOCUMENTO == "TRANSFERIDO") {
                    carpeta = "Ruta_SITD";
                }
                if (carpeta != "" && data.existeArchivo) {
                    urlFile = `${urlLocalSigo}${carpeta}/${constancia.ARCHIVO}`;
                    window.open(urlFile);
                } else {
                    utilSigo.toastWarning("Aviso", "No existe archivo");
                }
            } else {
                utilSigo.toastWarning("Aviso", "Constancia no existe");
            }

        }
        else {
            utilSigo.toastWarning("Aviso", "Sucedió un error al consultar el documento");
        }
    });
}
GestConstancia.fnGenerarWord = function (obj) {
    let itemData = GestConstancia.dtConstancia.row($(obj).parents('tr')).data();
    let urlFile = "";
    let carpeta = "";
    let identificador = itemData.NV_CONSTANCIA;
    let model = {
        identificador
    };
    utilSigo.dialogConfirm("", "Está seguro de generar documento?", function (r) {
        if (r) {
            let url = urlLocalSigo + "Fiscalizacion/GestionConstancia/GenerarWord";
            let option = { url: url, datos: JSON.stringify(model), type: 'POST' };
            utilSigo.fnAjax(option, function (data) {
                //console.log(data);
                if (data.success) {
                    //GestConstancia.dtConstancia.ajax.reload();
                    utilSigo.toastSuccess("Confirmación", data.message);
                    let constancia = data.constancia;
                    if (constancia.ESTADO_DOCUMENTO == "PENDIENTE") {
                        carpeta = "Archivos/Constancias/Generados/WordGenerado/";
                        if (carpeta != "" && data.existeArchivo) {
                            urlFile = `${urlLocalSigo}${carpeta}/${constancia.ARCHIVO}`;
                            window.location = urlFile;
                        }
                        else {
                            utilSigo.toastWarning("Aviso", "No existe archivo");
                        }
                    } else {
                        utilSigo.toastWarning("Aviso", "Documento no existe");
                    }
                }
                else {
                    utilSigo.toastWarning("Aviso", data.message);
                }
                
            });
        }
    });
}
GestConstancia.fnTransferir = function (obj) {
    let itemData = GestConstancia.dtConstancia.row($(obj).parents('tr')).data();
    let identificador = itemData.NV_CONSTANCIA;
    let numConstancia = itemData.NUMERO;
    let model = {
        identificador
    };
    utilSigo.dialogConfirm("", `Está seguro de transferir el archivo de la constancia número ${numConstancia} al SITD`, function (r) {
        if (r) {
            let url = urlLocalSigo + "Fiscalizacion/GestionConstancia/TransferirSITD";
            let option = { url: url, datos: JSON.stringify(model), type: 'POST' };
            utilSigo.fnAjax(option, function (data) {
                if (data.success) {
                    GestConstancia.dtConstancia.ajax.reload();
                    utilSigo.toastSuccess("Confirmación", data.message)
                }
                else {
                    utilSigo.toastWarning("Aviso", data.message);
                }
            });
        }
    });
}
GestConstancia.fnGenerar = function (obj) {
    let itemData = GestConstancia.dtConstancia.row($(obj).parents('tr')).data();
    let identificador = itemData.NV_CONSTANCIA;
    let model = {
        identificador
    };
    utilSigo.dialogConfirm("", "Está seguro de generar constancia?", function (r) {
        if (r) {
            let url = urlLocalSigo + "Fiscalizacion/GestionConstancia/GenerarConstancia";
            let option = { url: url, datos: JSON.stringify(model), type: 'POST' };
            utilSigo.fnAjax(option, function (data) {
                if (data.success) {                   
                    GestConstancia.dtConstancia.ajax.reload();
                    utilSigo.toastSuccess("Confirmación", data.message)
                }
                else {
                    utilSigo.toastWarning("Aviso", data.message);
                }
            });
        }
    });
}

/*Controles Datos Adjuntos*/
GestConstancia.fnSelectDocAdjunto = function (e, obj) {
    var idFile = $(obj).attr("id");
    var files = e.target.files || e.dataTransfer.files;

    if (files != undefined && files.length > 0) {
        //Validar extensión archivo seleccionado
        var extension = files[0].name.substr((files[0].name.lastIndexOf('.') + 1));
        var extensiones_no_permitidas = "exe,bin,bat,run,pdf,pif,src,py,PS2,PS2XML,PSC1,PSC2,ETC,VBS,rar,zip,xlsx,xlsm,xls,xll,xlam,sys,sldm,pub,pptx,ppt,ppsx,msi,mpeg,mp4,mp3,mov,jpg,jpeg,png,jar,iso";

        if (!extensiones_no_permitidas.includes(extension)) {
            //Validar el tamaño del archivo
            var fileSize = parseFloat(files[0].size);
            if ((fileSize / 1048576) > 8) //4MB permitido por foto
            {
                utilSigo.toastError("Error", "El tamaño del archivo supera los 4MB permitidos"); return false;
            } else {
                $("#" + idFile).next().text(files[0].name);
                GestConstancia.selectFile = files[0];
                GestConstancia.fnSaveDocumentoAdjunto(obj);
            }
        } else {
            utilSigo.toastError("Error", "La extensión ." + extension + " no esta permitida"); return false;
        }
    }
}
GestConstancia.fnSaveDocumentoAdjunto = function (obj) {
    let itemData = GestConstancia.dtConstancia.row($(obj).parents('tr')).data();

    if (GestConstancia.selectFile == null) {
        utilSigo.toastWarning("Aviso", "Seleccione el documento a adjuntar"); return false;
    }
    // Checking whether FormData is available in browser  
    if (window.FormData !== undefined) {
        var fileData = new FormData();
        var url = urlLocalSigo + "Fiscalizacion/GestionConstancia/GrabarDocumentoAdjunto";
        var data = {};

        data.NV_CONSTANCIA = itemData.NV_CONSTANCIA;

        fileData.append("data", JSON.stringify(data));
        fileData.append(GestConstancia.selectFile.name, GestConstancia.selectFile);

        $.ajax({
            url: url,
            type: "POST",
            contentType: false, // Not to set any content header  
            processData: false, // Not to process data  
            data: fileData,
            success: function (result) {
                if (result.success) {
                    
                    GestConstancia.selectFile = null;
                    utilSigo.toastSuccess("Éxito", result.msj);

                }
                else {
                    utilSigo.toastWarning("Aviso", result.msj);
                }
            },
            error: function (err) {
                utilSigo.toastWarning("Aviso", "Sucedio un error, Comuníquese con el Administrador");
                //console.log(err.statusText);
            }
        });
    } else {
        utilSigo.toastWarning("Aviso", "Sucedio un error, Comuníquese con el Administrador");
        //console.log("FormData is not available in your browser");
    }
};


GestConstancia.fnInitDataTable_Detail = function () {
    var columns_label = ["", "", "", "", "N°", "Creación", "Emisión", "Número de Constancia", "Fecha de Informe", "Número de Informe de Supervisión"
        , "Título Habilitante", "Titular", "Plan de Manejo Supervisado", "Parcela de Corta", "Estado"];
    var columns_data = [
        {
            "data": "", "width": "2%", "orderable": false, "searchable": false, "mRender": function (data, type, row) {
                
                if (row.ESTADO_DOCUMENTO == "PENDIENTE") {
                    return '<div><i class="fa fa-file-word-o" style="color:black;cursor:pointer;" title="Generar Word" onclick="GestConstancia.fnGenerarWord(this)"></i>';
                }
                else {
                    return '<div><i class="fa fa-file-word-o" style="color:black;cursor:pointer;" title="Generar Word" onclick=""></i>';
                }
            }
        },
        {
            "data": "", "width": "2%", "orderable": false, "searchable": false, "mRender": function (data, type, row) {

                if (row.ESTADO_DOCUMENTO == "PENDIENTE") {
                    //return '<div><input type="file" class="fa fa-upload" multiple="multiple" onchange="GestConstancia.fnSelectDocAdjunto(event, this)">';
                    return '<label style="cursor:pointer;" class="fa fa-upload" title="Importar Archivo" data-toggle="tooltip"><input type = "file" id = "fileselect" name = "fileselect" style = "display:none" size = "60" onchange = "GestConstancia.fnSelectDocAdjunto(event, this)" ></label >';
                }
                else {
                    return '<div><i class="fa fa-upload" style="color:black;cursor:pointer;" title="Subir Documento"></i>';
                }
            }
        },
        {
            "data": "", "width": "2%", "orderable": false, "searchable": false, "mRender": function (data, type, row) {
                
                if (row.ESTADO_DOCUMENTO == "PENDIENTE") {
                    return '<div><i class="fa fa fa-gears" style="color:black;cursor:pointer;" title="Generar constancia" onclick="GestConstancia.fnGenerar(this)"></i>';
                }
                else {
                    return '<div><i class="fa fa-lg fa-download" style="color:black;cursor:pointer;" title="Descargar constancia" onclick="GestConstancia.fnDescargar(this)"></i>';
                }                
            }
        },

        {
            "data": "", "width": "2%", "orderable": false, "searchable": false, "mRender": function (data, type, row) {
                if (row.ESTADO_DOCUMENTO == "GENERADO")
                    return '<div><i class="fa fa-lg fa-pencil" style="color:blue;cursor:pointer;" title="Firmar constancia" onclick="GestConstancia.fnIniciarFirma(this)"></i>';
                else if (row.ESTADO_DOCUMENTO == "FIRMADO")
                    return '<div><i class="fa fa-lg fa-sign-in" style="color:black;cursor:pointer;" title="Transferir al SITD" onclick="GestConstancia.fnTransferir(this)"></i>';
                else return '';
            }
        },
       /* {
            "data": "", "width": "2%", "orderable": false, "searchable": false, "mRender": function (data, type, row) {
                
                
            }
        },*/
        {
            "name": "ROW_INDE", "width": "2%", "orderable": false, "searchable": false, "mRender": function (data, type, row, meta) {
                return parseInt(meta.row) + 1 + meta.settings._iDisplayStart;
            }
        },
        { "data": "FE_CREACION", "autoWidth": true },
        { "data": "FECHA_EMISION", "autoWidth": true },
        { "data": "NUMERO", "autoWidth": true },
        { "data": "FECHA_INFORME", "autoWidth": true },
        { "data": "NUMERO_INFORME", "autoWidth": true },
        { "data": "NUMERO_TH", "autoWidth": true },
        { "data": "APELLIDOS_NOMBRES", "autoWidth": true },
        { "data": "TIPO_PLAN", "autoWidth": true },
        { "data": "PARCELA", "autoWidth": true },
        { "data": "ESTADO_DOCUMENTO", "autoWidth": true }
    ];

    //Cargar configuración
    var optDt = { iLength: 20, iStart: 0, aSort: [] };
    if (window.sessionStorage) {
        var config = JSON.parse(sessionStorage.getItem('configFrmListaConstancia'));

        if (config != null) {
            GestConstancia.frm.find("#ddlOpcionId").select2("val", [config.CboOpcionId]);
            GestConstancia.frm.find("#txtValor").val(config.txtValor);
            optDt.iLength = config.PageLength;
            optDt.iStart = config.RowStart;
            if ((typeof config.ColumnOrder !== 'undefined') && config.ColumnOrder.length > 0) {
                optDt.aSort.push([config.ColumnOrder[0], config.ColumnOrder[1]]);
            }
            sessionStorage.setItem('configFrmListaConstancia', null);
        }
    } else {
        utilSigo.toastWarning("Aviso", "Para que funcione bien el sistema, Por favor usar navegadores que soporten sessionStorage. Por ejemplo (Google Chrome, Mozilla Firefox)");
    }

    //**Cabecera**----
    var theadTable = "<tr>";
    for (var i = 0; i < columns_label.length; i++) {
        theadTable += '<th>' + columns_label[i] + '</th>';
    }
    theadTable += "</tr>";
    $("#tbConstancia").find("thead").append(theadTable);

    GestConstancia.dtConstancia = $("#tbConstancia").DataTable({
        processing: true,
        ServerSide: true,
        searching: false,
        ordering: false,
        paging: true,
        ajax: {
            url: urlLocalSigo + "Fiscalizacion/GestionConstancia/GetListaConstancia",
            data: function (params) {
                params.opcion = GestConstancia.frm.find("#ddlOpcionId").val();
                params.txtvalor = GestConstancia.frm.find("#txtValor").val();
            },
            type: "GET",
            datatype: "json"
        },
        columns: columns_data,
        bInfo: true,
        lengthMenu: [10, 20, 50, 100],
        aaSorting: optDt.aSort,
        pageLength: optDt.iLength,
        displayStart: optDt.iStart,
        oLanguage: initSigo.oLanguage,
        drawCallback: initSigo.showPagination
    });
};

$(document).ready(function () {
    GestConstancia.frm = $("#frmBuscarConstancia");

    GestConstancia.frm.submit(function (e) {
        e.preventDefault();
        GestConstancia.fnSearch();
    });

    GestConstancia.fnInitDataTable_Detail();
});