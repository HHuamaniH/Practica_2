"use strict";
let _BalExtra = {
    ListEliTABLA: [],
    gotoSISFORTH: () => {
       
        window.open("https://sisfor.osinfor.gob.pe/visor/sisforv4/geoTH/" + $("#codigoComplementario").val().split("|")[0], "_blank");
    },
    fnDelete: (obj) => {
        let itemData = _BalExtra.dt.row($(obj).parents('tr')).data();
        utilSigo.dialogConfirm("", "Está seguro de eliminar el item?", function (r) {
            if (r) {                 
                if (parseInt(itemData.RegEstado) != 1) {
                    _BalExtra.ListEliTABLA.push({
                        EliTABLA: "BITACORA_BALANCE",
                        COD_BITACORA: itemData.COD_BITACORA,
                        COD_THABILITANTE: itemData.COD_THABILITANTE,
                        NUM_POA: itemData.NUM_POA,
                        COD_ESPECIES: itemData.COD_ESPECIES,
                        COD_SECUENCIAL: itemData.COD_SECUENCIAL,
                        COD_CNOTIFICACION: itemData.COD_CNOTIFICACION,
                        RegEstado: 0
                    });
                }
                _BalExtra.dt.row($(obj).parents('tr')).remove().draw();
                console.log(_BalExtra.ListEliTABLA);
            }
        });
    },
    fnGetDataBalanceExtra: () => {
        let list = [];
        _BalExtra.dt.rows().every(function (rowIdx, tableLoop, rowLoop) {
            var data = this.data();
            if (parseInt(data.RegEstado) == 1) {
                list.push(data);
            }
        });
        return list;
    },
    fnBuildTable: () => {
        let columns = [
            {
                "name": "ROW_INDE", "width": "2%", "orderable": false, "mRender": function (data, type, row, meta) {
                    return parseInt(meta.row) + 1;
                }
            },          
            { "data": "ESPECIES", "width": "20%", "orderable": false },
            { "data": "TOTAL_ARBOLES", "autoWidth": true, "orderable": false },
            { "data": "VOLUMEN_AUTORIZADO", "autoWidth": true, "orderable": false },
            { "data": "VOLUMEN_MOVILIZADO", "autoWidth": true, "orderable": false },
            { "data": "SALDO", "autoWidth": true, "orderable": false },
            { "data": "NOMBRE_POA", "autoWidth": true, "orderable": false },
            {
                "data": "", "width": "2%", "orderable": false, "searchable": false, "mRender": function (data, type, row) {
                    return '<i class="cellDel fa fa-lg fa-window-close" style="color:red;cursor:pointer;" title="Eliminar" onclick="_BalExtra.fnDelete(this)"></i>';
                }
            }
        ];
        _BalExtra.dt = $("#grvEspeciesSD").DataTable({
            processing: true,
            serverSide: false,
            searching: false,
            ordering: false,
            paging: true,
            //"bPaginate": true,
            ajax: {
                "url": urlLocalSigo + "Supervision/Alerta/GetAllEspecieBExt",
                "data": function (d) {
                    
                },
                "error": function (jqXHR) {
                    utilSigo.unblockUIGeneral();
                    utilSigo.toastError("Error", "Sucedio un error");
                },
                "statusCode": {
                    203: () => { utilSigo.unblockUIGeneral(); utilSigo.toastInfo("Aviso", "El usuario perdio la sesión. Vuelva ingresar al sistema"); }
                }
            },
            columns: columns,
            bInfo: true,
            bLengthChange: false,
            // "lengthMenu": [[10, 20, 50, 100], [10, 20, 50, 100]],
            "aaSorting": [],
            "pageLength": 20,
            // "displayStart": optDt.iStart,
            "oLanguage": initSigo.oLanguage,
            "drawCallback": initSigo.showPagination
        });
       
    }
};
class AddEdit {
    constructor() {
        this.frm;
        this.dt;
        this.envioAlerta = 0;
        this.rutasSeleccionadaText = "";
    }
    init() {
        this.frm = $("#frmAddEdit");       
        this.seleccionarSupuesto();
        this.dt = this.frm.find("#tbListArchivos").DataTable({
            bProcessing: true,
            bRetrieve: true,
            //dom: 'Bfrtip',
            bLengthChange: false,
            scrollCollapse: true,
            orderCellsTop: true,
            searching: false,
            ordering: false,
            info: false,
            aaSorting: [],
            pageLength: initSigo.pageLength,
            oLanguage: initSigo.oLanguage,
            drawCallback: initSigo.showPagination,
            //buttons: [{
            //    extend: 'excelHtml5',
            //    exportOptions: { orthogonal: 'export' },
            //    messageTop: 'Destinatarios'
            //}],
            columns: [
                { bSortable: false, mRender: this.cellDel.bind(this), width: '2%' },
                { data: "NUMERO", width: '2%' },
                { data: "FECHA_SALIDA", width: '10%' },
                { data: "FECHA_LLEGADA", width: '30%' },
                { data: "OD", width: '10%' },
                //{ mRender: this.cellActive, width: '2%' }
                /*,
                { data: "ACTIVO", visible: false }
                  { data: "COD_PERSONA", visible: false }
                */
            ]
        });


    }
    cellDel(data, type, row) {
        
        return '<i class="cellDel fa fa-lg fa-window-close" title="Eliminar" onclick="' + this.nameObject + '.delete(this);"></i>';
    }
    fnReturnIndex() {
        let url = `${urlLocalSigo}/Supervision/Alerta/MainAlerta`;
        window.location = url;
    }
    descargarPlantillaTipo() {
        let url = urlLocalSigo;       
        url = url + "Archivos/Plantilla/" + $('#ddlItemSupuesto').val();     
        window.open(url, "_blank");
    }
    seleccionarSupuesto() {
        var supuesto = this.frm.find("#ddlItemSupuesto option:selected").text();
        let url = urlLocalSigo;
        url = urlLocalSigo + "Supervision/Alerta/GetDestinatariosCC";
    
        $.ajax({
            url: url,
            type: 'POST',
            data: { supuesto: supuesto },//JSON.stringify(supuesto),
            //contentType: 'application/json; charset=utf-8',
            //dataType: 'json',
            beforeSend: utilSigo.beforeSendAjax,
            complete: utilSigo.completeAjax,
            error: utilSigo.errorAjax,
            success: function (data) {               
                let response = data.data;
                let destinatario;                
                //if (response.ListDestinatario.length > 0) {
                //    destinatario = '';
                //    for (var i = 0; i < response.ListDestinatario.length; i++) {
                //        destinatario += response.ListDestinatario[i].DESTINATARIO + "; ";
                //    }
                //    destinatario = destinatario.substring(destinatario.length - 2, 0);
                //    $('#DESTINO_ENVIO_ALERTA').val(destinatario);
                //} else {
                //    $('#DESTINO_ENVIO_ALERTA').val('');
                //    utilSigo.toastInfo("Aviso", "No se encontró destinatario");
                //}

                if (response.ListDestinatarioCC.length > 0) {
                    destinatario = '';
                    for (var i = 0; i < response.ListDestinatarioCC.length; i++) {
                        destinatario += response.ListDestinatarioCC[i].DESTINATARIO +"; ";
                    }
                    destinatario = destinatario.substring(destinatario.length - 2, 0);
                    $('#CONCOPIA_ENVIO_ALERTA').val(destinatario);
                } else {
                    $('#CONCOPIA_ENVIO_ALERTA').val('');
                    utilSigo.toastInfo("Aviso", "No se encontró destinatario con copia");
                }
               
            }.bind(this)

        });

        this.fnSelectChk();
    }
    fnDownloadOficio() {
        
        let url = urlLocalSigo;
        if (parseInt($("#hdOficioEstado").val()) == 0) {
            url = url + "Archivos/Modulo/Supervision/Oficio/" + $("#hdOficioName").val();
        } else if (parseInt($("#hdOficioEstado").val()) == 1){
            url = url + "Archivos/Modulo/Supervision/Oficio/Temp/" + $("#hdOficioName").val();
        }
        window.open(url, "_blank");
    }
    fnImportarExcel(e, objeto) {
        let url = urlLocalSigo + "Supervision/Alerta/UploadFileOficio";
        uploadFile.fileSelectHandler_v1(e, objeto, url, {}, function (data) {
            let dataFile = data.data;
            if (data.success) {
                var archivoSubido = dataFile.nombreOriginal + "." + dataFile.extension;              
                $("#lblOficio").text(archivoSubido);
                $("#hdOficioName").val(dataFile.nombreGenerado);
                $("#hdOficioEstado").val(dataFile.estado);
                $("#imgOficio").attr("style", "cursor:pointer;display:block;");  
                utilSigo.toastSuccess("Aviso", data.msj);
            }
            else {
                $("#lblOficio").text("");
                utilSigo.toastWarning("Aviso", data.msj);
            }
        });
    }
    GetEspecieBExt() {
        var option = {
            url: urlLocalSigo + "Supervision/Alerta/_BalanceExtra",
            divId: "mdlAddBalanceExtra",
            datos: {}
        };
        utilSigo.fnOpenModal(option);
    }
    cargarDatosActa(opcion) {
        var dataEnviar = "";
        var url = "";
        /*if (opcion == 0) {
            var indexPadre = $("#cphPrincipal_hdfIndexItemBitacora").val();
            dataEnviar = { index: indexPadre };
            url = "ManBitacoraSuper.aspx/GetAllItemActa";
        }
        else {*/
        dataEnviar = {
            codigoDato: this.frm.find("#codigoDato").val(),
            codigoComplementario: this.frm.find("#codigoComplementario").val()
        };
        url = urlLocalSigo + "Supervision/Alerta/GetAllItemActaAlerta";
        /*}*/
        $.ajax({
            url: url,
            type: 'POST',
            data: JSON.stringify(dataEnviar),
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            beforeSend: utilSigo.beforeSendAjax,
            complete: utilSigo.completeAjax,
            error: utilSigo.errorAjax,
            success: function (data) {
                if (data.success) {
                    this.crearTablaActa(data.fileInfo, opcion);
                }
                else {
                    if (opcion == 0)
                        utilSigo.toastWarning("Error","Hubo Error al mostrar archivos de acta");
                    else utilSigo.toastWarning("Error","Hubo Error al mostrar archivos de acta - Supervision");

                    ///$("#DivMensaje").fadeOut(8000); //Ocultando Div
                }
            }.bind(this)

        });
       /* fnAjax(url, dataEnviar, function (data) {
            
        });*/
    }
    fnGetOpion(nombreGenerado, nombreBDAntiguo) {
        var opcion = 0;
        if (nombreGenerado == "null" || nombreGenerado == null || nombreGenerado == "") {
            //cuando biene de base de datos
            if (nombreBDAntiguo.trim() != '') { //cuando biene de origen antiguo                   
                opcion = 2;
            }
            else {
                //origen nuevo de BD
                opcion = 0;
            }

        } else {
            //cuando todavia no se registra en la BD   
            opcion = 1;
        }
        return opcion;
    }
    fnDownloadacta(obj) {
        
        var tr = $(obj).closest("tr");
        var nombreGenerado = tr.find(".hdNombreGenerado").val();
        var nombreBD = tr.find(".hdNombreBD").val();
        var nombreBDAntiguo = tr.find(".hdNombreAntiguo").val();
        var nombreOriginal = tr.find(".hdNombreOriginal").val() + "." + tr.find(".hdExtension").val();
        var opcionFile = this.fnGetOpion(nombreGenerado, nombreBDAntiguo);
        switch (opcionFile) {
            case 0: break;
            case 1: nombreBD = nombreGenerado; break;
            case 2: nombreBD = nombreBDAntiguo; break;

        }
        var codSecActa = tr.find(".hdCod_Sec_Acta").val();
        let url = urlLocalSigo + "Supervision/Alerta/ExistFileDownload";
        let model = {
            nombreArchivo: nombreBD,
            opcion: opcionFile
        };
        let option = { url: url, datos: model, type: 'GET' };
        utilSigo.fnAjax(option, function (data) {
            if (data.success) {    
                if (data.existe) {
                    let url = `${urlLocalSigo}/Supervision/Alerta/Downloadfile?nombreArchivo=${nombreBD}&nombreOriginal=${nombreBD}&opcion=${opcionFile}`;
                    window.open(url, "_blank");
                }
                else {
                    utilSigo.toastWarning("Aviso", "No existe el archivo a descargar");
                }
            }
            else {
                utilSigo.toastWarning("Aviso", "No Existe el archivo a descargar");
            }
        });
    }
    crearTablaActa(datos, origen) {
        var tbAdd = "";
        tbAdd += '<table class="table table-hover table-bordered"  style="width:70%;border:1px;border-spacing:0px;" id="tbDetalleActa">'
        tbAdd += '<thead>';
        tbAdd += '<tr>';
        tbAdd += '<th></th>';
        tbAdd += '<th>N°</th>';
        tbAdd += '<th>Nombre Archivo</th>';
        tbAdd += '<th>Extensión Archivo</th>';
        tbAdd += '<th></th>';
        tbAdd += '</tr>';
        tbAdd += '</thead>';
        tbAdd += '<tbody>';
        //console.log(datos);
        for (var i = 0; i < datos.length; i++) {
            tbAdd += '<tr>';
           // tbAdd += '<td>' + '<img src="' + urlLocalSigo +'Imagenes/BonMan/Eliminar4.png" alt="Eliminar" title="Eliminar"  height="15px" width="15px" onclick="addEdit.fnDeleteArchivoActa(this);"></img>';
            tbAdd   +=' <td>'
            tbAdd += '<input type="hidden" class="hdCodGuiId" value="' + datos[i].codGuiId + '" />';
            tbAdd += '<input type="hidden" class="hdNombreGenerado" value="' + datos[i].nombreGenerado + '" />';
            tbAdd += '<input type="hidden" class="hdNombreBD" value="' + datos[i].nombreBD + '" />';
            tbAdd += '<input type="hidden" class="hdNombreOriginal" value="' + datos[i].nombreOriginal + '" />';
            tbAdd += '<input type="hidden" class="hdExtension" value="' + datos[i].extension + '" />';
            tbAdd += '<input type="hidden" class="hdIndexPadre" value="' + datos[i].indexPadre + '" />';
            tbAdd += '<input type="hidden" class="hdIndexHijo" value="' + datos[i].index + '" />';
            tbAdd += '<input type="hidden" class="hdCod_Sec_Acta" value="' + datos[i].cod_Sec_Acta + '" />';
            tbAdd += '<input type="hidden" class="hdNombreAntiguo" value="' + datos[i].nombreBDAntiguo + '" />';
            tbAdd += '</td>';
            tbAdd += '<td>' + (i + 1) + '</td>';
            tbAdd += '<td>' + datos[i].nombreOriginal + '</td>';
            tbAdd += '<td>' + datos[i].extension + '</td>';
            tbAdd += '<td><img src="' + urlLocalSigo +'Imagenes/BonMan/download.png" alt="Descargar" title="Descargar" style="cursor:pointer;"  height="15px" width="15px" onclick="addEdit.fnDownloadacta(this);"></img></td>';
            tbAdd += '</tr>';
        }
        tbAdd += '<tbody>';
        tbAdd += '</table>';
        //if (origen == 0) {
        //    $("#divArchivosActa").html(tbAdd);
        //} else {
        //    $("#divArchivosActaMostrar").html(tbAdd);
        //}
        $("#divArchivosActaMostrar").html(tbAdd);
    }
    confirmarRegistro() {
        if (this.envioAlerta == 0) {
            var chkAlerta = this.frm.find("#ENVIAR_ALERTA");
            if (chkAlerta.is(":checked")) {
                if (this.frm.find("#DESTINO_ENVIO_ALERTA").val().trim().length <= 0) {
                    utilSigo.toastWarning("Aviso", "Seleccione al menos un tramo para enviar la alerta");
                    return false;
                }
            }
        }
        var varMensaje = '¿ Está seguro de enviar el correo de Alerta?';
        $("#DESTINO_ENVIO_TEXT").val(this.rutasSeleccionadaText);
        $("#DESTINO_ENVIO_ALERTA").removeAttr("readonly");
        var $mthis = this.frm;
        utilSigo.dialogConfirm("Confirmacion", varMensaje, function (r) {
            if (r) {
                var dataEnviar = $mthis.serializeObject();
                dataEnviar.ENVIAR_ALERTA = $mthis.find("#ENVIAR_ALERTA").is(":checked");
                dataEnviar.MENSAJE_ENVIO_ALERTA = CKEDITOR.instances.MENSAJE_ENVIO_ALERTA.getData();
                dataEnviar.CONCOPIA_ENVIO_ALERTA = $mthis.find("#CONCOPIA_ENVIO_ALERTA").val();
                dataEnviar.DESTINO_ENVIO_ALERTA = $mthis.find("#DESTINO_ENVIO_ALERTA").val();
                dataEnviar.ListEliTABLA = _BalExtra.ListEliTABLA;
                dataEnviar.ListBEXT = _BalExtra.fnGetDataBalanceExtra();
                var url = urlLocalSigo + "Supervision/Alerta/btnItemConfirmar_Click";
                $.ajax({
                    url: url,
                    type: 'POST',
                    data: JSON.stringify(dataEnviar),
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'json',
                    beforeSend: utilSigo.beforeSendAjax,
                    complete: utilSigo.completeAjax,
                    error: utilSigo.errorAjax,
                    success: function (datos) {
                        if (datos.success) {
                            utilSigo.toastSuccess("Confirmacion", datos.msj);
                            let url = `${urlLocalSigo}/Supervision/Alerta/MainAlerta`;
                            window.location = url;
                        } else {
                            utilSigo.toastWarning("Aviso", datos.msj);
                        }
                    }
                });
                
                //console.log($mthis.serializeObject());//.serialize());
            }
        });
    }
    chkDepartamento(obj, codigo) {

        if (codigo != "") {
            var lstCodDepartamentosChecked = [];
            var lstCodDepartamentosUnChecked = [];
            if ($(obj).is(":checked")) {
                lstCodDepartamentosChecked.push(codigo);
            }else {
                lstCodDepartamentosUnChecked.push(codigo);
            }
            if (lstCodDepartamentosChecked.length > 0) {
                var strCodDepartamentos = lstCodDepartamentosChecked.join("|");
                this.cargarDatosRuta(strCodDepartamentos);
            }
            if (lstCodDepartamentosUnChecked.length > 0) {

                this.fnEliminarRutas(lstCodDepartamentosUnChecked);
            }
            this.fnSelectChk();
        }

    }
    cargarDatosRuta(strCodDepartamentos) {
        var dataEnviar = "";
        var url = "";
        dataEnviar = {
            busCriterio: "TRAMO",
            cod_departamentos: strCodDepartamentos
        }
        url = urlLocalSigo + "Supervision/Alerta/GetAllRutaDestino"; 
        $.ajax({
            url: url,
            type: 'POST',
            data: JSON.stringify(dataEnviar),
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            beforeSend: utilSigo.beforeSendAjax,
            complete: utilSigo.completeAjax,
            error: utilSigo.errorAjax,
            success: function (datos) {
                if (datos.length <= 0) {
                    utilSigo.toastWarning("Error", "El departamento seleccionado no tiene tramos asignados");
                }
                this.crearTablaRutas(datos);
                
            }.bind(this)
        });
    }

    crearTablaRutas(datos) {
        var tbAdd = "";
        for (var i = 0; i < datos.length; i++) {
            tbAdd += '<tr>';
            tbAdd += '<td><input type="checkbox" class="chkItem" onclick="addEdit.fnSelectChk();" />';
            tbAdd += '<input type="hidden" class="hdCodRuta" value="' + datos[i].COD_RUTA + '" />';
            tbAdd += '<input type="hidden" class="hdCOD_UBIDEPARTAMENTO" value="' + datos[i].COD_UBIDEPARTAMENTO + '" />';
            tbAdd += '</td > ';
            tbAdd += '<td>' + (i + 1) + '</td>';
            tbAdd += '<td>' + datos[i].DEPARTAMENTO + '</td>';
            tbAdd += '<td>' + datos[i].TRAMO + '</td>';
            tbAdd += '<td>' + datos[i].ORIGEN_DESTINO + '</td>';
            //tbAdd += '<td><img src="../Imagenes/BonMan/download.png" alt="Descargar" title="Descargar"  height="15px" width="15px" onclick="fnDownloadacta(this);"></img></td>';
            tbAdd += '</tr>';
        }
        $("#tbTramo tbody").append(tbAdd);
    }

    fnEliminarRutas(lstCodDepartamentosUnChecked) {
        var $mthis = function(codDepartamento, lstCodDepartamentosUnChecked) {
            var existe = false;
            for (var i = 0; i < lstCodDepartamentosUnChecked.length; i++) {
                if (codDepartamento.trim() == lstCodDepartamentosUnChecked[i].trim()) {
                    existe = true;
                    break;
                }
            }
            return existe;
        };
        this.frm.find("#tbTramo tbody").find('tr').each(function () {
            var codDepartamento = $(this).find(".hdCOD_UBIDEPARTAMENTO").val();

            if ($mthis(codDepartamento, lstCodDepartamentosUnChecked)) {
                $(this).remove();
            }
        });
    }

    fnGetCheckSelect() {
    var codRutas = [];
    var $trs = $('#tbTramo > tbody').find("tr");
        $.each($trs, function (i, o) {
            var check = $(o).find(".chkItem");
            if (check.is(":checked")) {
                var codRuta = $(o).find(".hdCodRuta").val();
                codRutas.push(codRuta);
            }
        });
        return codRutas;
    }

    fnSelectChk() {
        var dataEnviar = "";
        var url = "";
        
        var lstCodRutas = this.fnGetCheckSelect();
        var abrev_supuesto = this.frm.find("#ddlItemSupuesto option:selected").text();

        if (lstCodRutas.length > 0) {
            var strRutas = lstCodRutas.join("|");
            dataEnviar = {
                busCriterio: "TRAMO_DESTINO",
                cod_departamentos: strRutas,
                supuesto: abrev_supuesto
            }
            url = urlLocalSigo + "Supervision/Alerta/GetAllRutaDestino";
            $.ajax({
                url: url,
                type: 'POST',
                data: JSON.stringify(dataEnviar),
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                beforeSend: utilSigo.beforeSendAjax,
                complete: utilSigo.completeAjax,
                error: utilSigo.errorAjax,
                success: function (datos) {
                    this.crearTablaRutasSelecionadas(datos);
                    this.rutasSeleccionadaText = JSON.stringify(datos);
                }.bind(this)
            });
        }
        else {
            $("#tbTramoSelecionado tbody").find('tr').each(function () {
                $(this).remove();
            });
            $("#DESTINO_ENVIO_ALERTA").val("");
        } 
    }

    crearTablaRutasSelecionadas(datos) {
       
        var lstCorreosDestinos = [];
        var tbAdd = "";
        tbAdd += '<table  class="Grilla"  style="width:100%;border-collapse:collapse;" id="tbTramoSelecionado">'
        tbAdd += '<thead>';
        tbAdd += '<tr>';
        tbAdd += '<th>N°</th>';
        tbAdd += '<th>Departamento</th>';
        tbAdd += '<th>Tramo</th>';
        tbAdd += '<th>Origen-Destino</th>';
        tbAdd += '<th>Destinatario</th>';
        tbAdd += '<th>Oficina</th>';
        tbAdd += '<th>Cargo</th>';
        tbAdd += '<th>Correo</th>';
        tbAdd += '</tr>';
        tbAdd += '</thead>';
        tbAdd += '<tbody>';
        var tbTrs = "";
        for (var i = 0; i < datos.length; i++) {
            tbTrs += '<tr>';
            tbTrs += '<td>' + (i + 1) + '</td>';
            tbTrs += '<td>' + datos[i].DEPARTAMENTO + '</td>';
            tbTrs += '<td>' + datos[i].TRAMO + '</td>';
            tbTrs += '<td>' + datos[i].ORIGEN_DESTINO + '</td>';
            tbTrs += '<td>' + datos[i].DESCRIPCION + '</td>';
            tbTrs += '<td>' + datos[i].OFICINA + '</td>';
            tbTrs += '<td>' + datos[i].CARGO + '</td>';
            tbTrs += '<td>' + datos[i].CORREO + '</td>';
            tbTrs += '</tr>';
            lstCorreosDestinos.push(datos[i].CORREO.trim());
        }
        tbAdd += tbTrs;
        tbAdd += '<tbody>';
        tbAdd += '</table>';

        $("#divTramoSelecionado").html(tbAdd);
        //asignando correos
        $("#DESTINO_ENVIO_ALERTA").val(lstCorreosDestinos.join(";"));
    }

    fnDeleteArchivoActa(obj) {

        var url = "";
        utilSigo.dialogConfirm("Confirmacion", "¿ Está seguro de eliminar el registro ?", function (r) {
            if (r) {
                let tr = $(obj).closest("tr");
                let indexPadre = tr.find(".hdIndexPadre").val();
                let indexHijo = tr.find(".hdIndexHijo").val();               
                let codGuiId = tr.find(".hdCodGuiId").val();
                console.log(codGuiId);
            }
        });
    }
}

class TablaVertice {
    constructor() {
        this.frm;
        this.dt;
    }
    init() {
        this.frm = $("#frmAddEdit");
        this.dt = this.frm.find("#grvItemVertice").DataTable({
            bProcessing: true,
            bRetrieve: true,
            //dom: 'Bfrtip',
            bLengthChange: false,
            scrollCollapse: true,
            orderCellsTop: true,
            searching: false,
            ordering: false,
            info: false,
            aaSorting: [],
            pageLength: initSigo.pageLength,
            oLanguage: initSigo.oLanguage,
            drawCallback: initSigo.showPagination,
            //buttons: [{
            //    extend: 'excelHtml5',
            //    exportOptions: { orthogonal: 'export' },
            //    messageTop: 'Destinatarios'
            //}],

            columns: [
                { data: "NUMERO", width: '2%' },
                { data: "VERTICE", width: '10%' },
                { data: "ZONA", width: '30%' },
                { data: "COORDENADA_ESTE", width: '10%' },
                { data: "COORDENADA_NORTE", width: '10%' },
                { data: "OBSERVACIONES", width: '10%' },
            ]
        });
    }
}

class TablaEspecies {
    constructor(nameObject) {
        this.frm;
        this.dt;
        this.nameObject = nameObject;
    }
    init() {
        this.frm = $("#frmAddEdit");
        this.dt = this.frm.find("#grvEspeciesSD").DataTable({
            bProcessing: true,
            bRetrieve: true,
            //dom: 'Bfrtip',
            bLengthChange: false,
            scrollCollapse: true,
            orderCellsTop: true,
            searching: false,
            ordering: false,
            info: false,
            aaSorting: [],
            pageLength: initSigo.pageLength,
            oLanguage: initSigo.oLanguage,
            drawCallback: initSigo.showPagination,
            //buttons: [{
            //    extend: 'excelHtml5',
            //    exportOptions: { orthogonal: 'export' },
            //    messageTop: 'Destinatarios'
            //}],

            columns: [
                { data: "NUMERO", width: '2%' },
                { data: "ESPECIES", width: '10%' },
                { data: "TOTAL_ARBOLES", width: '30%' },
                { data: "VOLUMEN_AUTORIZADO", width: '10%' },
                { data: "VOLUMEN_MOVILIZADO", width: '10%' },
                { data: "SALDO", width: '10%' },
                { data: "NOMBRE_POA", width: '10%' },
                { bSortable: false, mRender: this.cellDel.bind(this), width: '2%' },
            ]
        });
    }
    cellDel(data, type, row) {
       
        return '<i class="cellDel fa fa-lg fa-window-close" title="Eliminar" onclick="' + this.nameObject + '.delete(this);"></i>';
    }
    delete(obj) {
        var $trEliminar = $(obj).closest('tr');
        var indice = this.dt.row($(obj).closest('tr')).index();
        var dt = this.dt;
        utilSigo.dialogConfirm("Confirmacion", "¿ Está seguro de Eliminar el Registro Seleccionado ?", function (r) {
            if (r) {
                var url = urlLocalSigo + "Supervision/Alerta/btngrvInfraccionesEliSD_Click";
                var dataEnviar = {
                    ListIndex: indice
                };
                $.ajax({
                    url: url,
                    type: 'POST',
                    data: JSON.stringify(dataEnviar),
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'json',
                    beforeSend: utilSigo.beforeSendAjax,
                    complete: utilSigo.completeAjax,
                    error: utilSigo.errorAjax,
                    success: function (data) {
                        if (data.success) {
                            dt.row($trEliminar).remove().draw();
                        }
                        else {
                            utilSigo.toastWarning("Error", data.msj);

                            ///$("#DivMensaje").fadeOut(8000); //Ocultando Div
                        }
                    }.bind(this)

                });
            }
        });
    }
}