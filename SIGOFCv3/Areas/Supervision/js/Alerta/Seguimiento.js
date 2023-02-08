"use strict";
class Seguimiento {
    constructor() {
        this.frm;
        this.ListEliTABLA = [];
        this.urlController = urlLocalSigo + "Supervision/Alerta";
    }
    init() {
        this.frm = $("#fmrSeguimiento");
    }
}

class DocRecibido {
    constructor(nameObject, tipoVentana) {
        
        this.nameObject = nameObject;
        this.tipoVentana = tipoVentana;
        this.dt; 
        this.tr;
        this.RegEstado;
    }
    init() {
         
        this.dt = ManSeguimiento.frm.find("#grvDocRecibido").DataTable({
            bProcessing: true,
            bRetrieve: true,
            dom: 'Bfrtip',
            bLengthChange: false,
            scrollCollapse: true,
            aaSorting: [],
            pageLength: initSigo.pageLength,
            oLanguage: initSigo.oLanguage,
            drawCallback: initSigo.showPagination,
            buttons: [],
            columns: [
                { bSortable: false, mRender: this.cellEdit.bind(this), width: '2%' },
                { bSortable: false, mRender: this.cellDel.bind(this), width: '2%' },
                { data: "COD_DOCRECIBIDO", visible: false },
                { data: "EXPEDIENTE", width: '30%' },
                { data: "FECHA_EXPEDIENTE", width: '20%' },
                { data: "DOCUMENTO", width: '26%' },
                { data: "OFICINA", width: '20%' },
                { data: "OBSERVACIONES", visible: false }               
            ]
        });    

    }
    cellDel(data, type, row) {
        
        return '<i class="cellDel fa fa-lg fa-window-close" title="Eliminar" onclick="' + this.nameObject + '.delete(this);"></i>';
    }
    cellEdit(data, type, row) {
        
        return '<i class="cellEdit fa fa-lg fa-pencil-square-o" title="Editar" onclick="' + this.nameObject + '.showModal(2,this);"></i>';

    }
    fnReturnIndex() {
        let url = `${urlLocalSigo}/Supervision/Alerta/MainAlerta`;
        window.location = url;
    } 
    showModal(RegEstado, obj) {        
        var option = {
            url: ManSeguimiento.urlController + "/_ItemDocRecibido",
            divId: "modalAddDocRecibido"
        };

        this.RegEstado = RegEstado;
        this.tr = $(obj).closest('tr');
        utilSigo.fnOpenModal(option, this.configModal.bind(this));
    }
    configModal() {
        _ItemDocRecibido.afterSave = this.afterSave.bind(this);
        var row;
        if (this.RegEstado == RegEstadoSigo.UPDATE)
            row = this.dt.row(this.tr).data();
        _ItemDocRecibido.init(this.RegEstado, row);

    }

    afterSave(data) {
        $("#modalAddDocRecibido").modal('hide');       
        var codigoDato = $('#codigoDato').val();
        var codigoComplementario = $('#codigoComplementario').val();
        var url = ManSeguimiento.urlController + `/GetAllDocRecibidoByAlerta?codigoDato=${codigoDato}&codigoComplementario=${codigoComplementario}`;
        this.dt.ajax.url(url).load();


    }
    delete(obj) {
        utilSigo.dialogConfirm("Confirmacion", "¿Está seguro de Eliminar el Registro Seleccionado?",
            function (r) {
                
                var row = this.dt.row($(obj).closest('tr')).data();
                var rowTem = {
                    COD_DOCRECIBIDO: row.COD_DOCRECIBIDO
                };
                var datos = {};
                datos.ListDocRecibido = [rowTem];
                datos.RegEstado = RegEstadoSigo.DELETE;
                datos.codigoDato = $('#codigoDato').val();
                datos.codigoComplementario = $('#codigoComplementario').val();
                this.saveAjax(datos);

            }.bind(this));
    }
    saveAjax(datos) {
        
        $.ajax({
            url: ManSeguimiento.urlController + "/saveDocRecibido",
            type: 'POST',
            data: JSON.stringify(datos),
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            beforeSend: utilSigo.beforeSendAjax,
            complete: utilSigo.completeAjax,
            error: utilSigo.errorAjax,
            success: function (data) {
                if (data.success) {
                    this.afterSave();
                    if (datos.RegEstado == RegEstadoSigo.DELETE)
                        utilSigo.toastSuccess("Exito", "Se elimino con exito");

                    if (datos.RegEstado == RegEstadoSigo.UPDATE)
                        utilSigo.toastSuccess("Exito", "Se cambio de estado con exito");

                    $("#modalAddDocRecibido").modal('hide');   

                }
                else
                    utilSigo.toastWarning("Aviso", data.msj);
            }.bind(this)
        });
    } 
}

class RptaEnlace {
    constructor(nameObject, tipoVentana) {

        this.nameObject = nameObject;
        this.tipoVentana = tipoVentana;
        this.dt;
        this.tr;
        this.RegEstado;
    }
    init() {

        this.dt = ManSeguimiento.frm.find("#grvRptaEnlace").DataTable({
            bProcessing: true,
            bRetrieve: true,
            dom: 'Bfrtip',
            bLengthChange: false,
            scrollCollapse: true,
            aaSorting: [],
            pageLength: initSigo.pageLength,
            oLanguage: initSigo.oLanguage,
            drawCallback: initSigo.showPagination,
            buttons: [],
            columns: [
                //{ bSortable: false, mRender: this.cellEdit.bind(this), width: '2%' },                
                { data: "COD_RPTAENLACE", width: '15%' },
                { data: "FECHA_RESPUESTA", width: '15%' },
                { data: "DOCUMENTO", width: '20%' },                
                { data: "PROCEDIMIENTO", width: '10%' },
                { data: "RECOMENDACION", width: '40%' }                
            ]
        });

    }
    cellDel(data, type, row) {

        return '<i class="cellDel fa fa-lg fa-window-close" title="Eliminar" onclick="' + this.nameObject + '.delete(this);"></i>';
    }
    cellEdit(data, type, row) {

        return '<i class="cellEdit fa fa-lg fa-pencil-square-o" title="Editar" onclick="' + this.nameObject + '.showModal(2,this);"></i>';

    }
    fnReturnIndex() {
        let url = `${urlLocalSigo}/Supervision/Alerta/MainAlerta`;
        window.location = url;
    }
    showModal(RegEstado, obj) {
        var option = {
            url: ManSeguimiento.urlController + "/_ItemDocRecibido",
            divId: "modalAddDocRecibido"
        };

        this.RegEstado = RegEstado;
        this.tr = $(obj).closest('tr');
        utilSigo.fnOpenModal(option, this.configModal.bind(this));
    }
    configModal() {
        _ItemDocRecibido.afterSave = this.afterSave.bind(this);
        var row;
        if (this.RegEstado == RegEstadoSigo.UPDATE)
            row = this.dt.row(this.tr).data();
        _ItemDocRecibido.init(this.RegEstado, row);

    }

    afterSave(data) {
        $("#modalAddDocRecibido").modal('hide');
        var codigoDato = $('#codigoDato').val();
        var codigoComplementario = $('#codigoComplementario').val();
        var url = ManSeguimiento.urlController + `/GetAllDocRecibidoByAlerta?codigoDato=${codigoDato}&codigoComplementario=${codigoComplementario}`;
        this.dt.ajax.url(url).load();


    }
    delete(obj) {
        utilSigo.dialogConfirm("Confirmacion", "¿Está seguro de Eliminar el Registro Seleccionado?",
            function (r) {

                var row = this.dt.row($(obj).closest('tr')).data();
                var rowTem = {
                    COD_DOCRECIBIDO: row.COD_DOCRECIBIDO
                };
                var datos = {};
                datos.ListDocRecibido = [rowTem];
                datos.RegEstado = RegEstadoSigo.DELETE;
                datos.codigoDato = $('#codigoDato').val();
                datos.codigoComplementario = $('#codigoComplementario').val();
                this.saveAjax(datos);

            }.bind(this));
    }
    saveAjax(datos) {

        $.ajax({
            url: ManSeguimiento.urlController + "/saveDocRecibido",
            type: 'POST',
            data: JSON.stringify(datos),
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            beforeSend: utilSigo.beforeSendAjax,
            complete: utilSigo.completeAjax,
            error: utilSigo.errorAjax,
            success: function (data) {
                if (data.success) {
                    this.afterSave();
                    if (datos.RegEstado == RegEstadoSigo.DELETE)
                        utilSigo.toastSuccess("Exito", "Se elimino con exito");

                    if (datos.RegEstado == RegEstadoSigo.UPDATE)
                        utilSigo.toastSuccess("Exito", "Se cambio de estado con exito");

                    $("#modalAddDocRecibido").modal('hide');

                }
                else
                    utilSigo.toastWarning("Aviso", data.msj);
            }.bind(this)
        });
    }
}