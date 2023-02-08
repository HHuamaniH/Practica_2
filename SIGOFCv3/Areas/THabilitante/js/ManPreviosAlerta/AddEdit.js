"use strict";
class PreviosAlerta {
    constructor() {
        this.frm;
        this.ListEliTABLA = [];
        this.urlController = urlLocalSigo + "THabilitante/ManPreviosAlerta";
    }
    init() {
        this.frm = $("#frmPreviosAlerta"); 
    }
}
 
class Destinatarios {
    constructor(nameObject, tipoVentana) {
        this.nameObject = nameObject;
        this.tipoVentana = tipoVentana;
        this.dt; 
        this.tr;  
        this.RegEstado;
    }
    init() {
 
        this.dt = ManPreviosAlerta.frm.find("#grvDestinatarios").DataTable({
            bProcessing: true,
            bRetrieve: true,
            dom: 'Bfrtip',       
            bLengthChange: false,
            scrollCollapse: true,
            aaSorting: [],
            pageLength: initSigo.pageLength,
            oLanguage: initSigo.oLanguage,
            drawCallback: initSigo.showPagination,
            buttons: [{
                extend: 'excelHtml5',                              
                messageTop: 'Destinatarios',
                exportOptions: {
                    columns: [0, ':visible'],
                    columns: [1, ':visible'],
                    //columns: [2, ':visible'],
                    //columns: [3, ':visible']
                }
            }],
         
            columns: [
                { bSortable: false, mRender: this.cellEdit.bind(this), width: '2%' },
                { bSortable: false, mRender: this.cellDel.bind(this), width: '2%' },       
                //{ data: "COD_DESTINATARIO", width: '2%' },
                { data: "DESCRIPCION", width: '30%' },
                { data: "CORREO", width: '10%' },
                { data: "OFICINA", width: '10%' }, 
                { data: "DOCUMENTO", width: '10%' },
                { data: "FECHA_DOCUMENTO", width: '10%' },
                { data: "CARGO", width: '10%' },
                { data: "OBSERVACION", width: '10%' },   
                //{ mRender: this.cellActive, width: '2%' },
                { data: "TIPO_FUNCIONARIO", visible: false }, 
                //{ data: "SUPUESTOS_DESTINATARIO", visible: false },               
                { data: "COD_ENTIDAD", visible: false }     
            ]
        });
 
    }
    cellDel(data, type, row) {
        
        return '<i class="cellDel fa fa-lg fa-window-close" title="Eliminar" onclick="' + this.nameObject + '.delete(this);"></i>';
    }
    cellEdit(data, type, row) {
        return '<i class="cellEdit fa fa-lg fa-pencil-square-o" title="Editar" onclick="' + this.nameObject + '.showModal(2,this);"></i>';

    }
    cellActive(data, type, row) {
        
       // if (type === 'export') {            
            if (row.ACTIVO == 1)
                return 'Activo';
            else
                return 'Desactivo';
       /* } else {
            if (row.ACTIVO == 1)
                return '<i class="cellCheck fa fa-lg fa-check-square-o" title="Click para Desactivar" onclick="' + this.nameObject + '.changeActivo(this);"></i>';
            else
                return '<i class="cellUnCheck fa fa-lg fa-square-o" title="click para Activar" onclick="' + this.nameObject + '.changeActivo(this);"></i>';
        }*/

    }
    changeActivo(obj) {
        var row = this.dt.row($(obj).closest('tr')).data();
        row.ACTIVO = row.ACTIVO == 1 ? 0 : 1;
        var datos = {};
        datos.ListDESTINATARIO =[ row];
        datos.RegEstado = RegEstadoSigo.UPDATE;
        this.saveAjax(datos);
    }
    showModal(RegEstado, obj) { 
        var option = {
            url: ManPreviosAlerta.urlController + "/_ItemDestinatario",
            divId: "modalAddEditDestinatario"
        };
        
        this.RegEstado = RegEstado;
        this.tr = $(obj).closest('tr');
        utilSigo.fnOpenModal(option, this.configModal.bind(this));
    }
    afterSave(data) {
        var url = ManPreviosAlerta.urlController + "/GetAllDestinatario";
       this.dt.ajax.url( url ).load();

    }
    configModal() {
        vpItemDestinatario.afterSave =this.afterSave.bind(this);      
        var row;
        if (this.RegEstado==RegEstadoSigo.UPDATE)
            row = this.dt.row(this.tr).data(); 
        vpItemDestinatario.init(this.RegEstado, row);     
    }   

    delete (obj) {
        utilSigo.dialogConfirm("Confirmacion", "¿Está seguro de Eliminar el Registro Seleccionado?",
            function (r) {
               
                var row = this.dt.row($(obj).closest('tr')).data();             
                var datos = {};
                console.log(row);
                datos.ListDESTINATARIO = [row];
                datos.RegEstado = RegEstadoSigo.DELETE;
                this.saveAjax(datos);

            }.bind(this));
    }
    saveAjax(datos) {
        $.ajax({
            url: ManPreviosAlerta.urlController + "/saveDestinatario",
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
                    if(datos.RegEstado==RegEstadoSigo.DELETE )
                        utilSigo.toastSuccess("Exito", "Se elimino con exito");

                    if (datos.RegEstado == RegEstadoSigo.UPDATE)
                        utilSigo.toastSuccess("Exito", "Se cambio de estado con exito");


                }
                else
                    utilSigo.toastWarning("Aviso", data.msj);
            }.bind(this)

        });

    }
    deleteAll() {
        if (this.dt.$("tr").length > 0) {
            var objTemp = this;
            utilSigo.dialogConfirm("Confirmacion", "Está seguro de Eliminar Todo los Registros?", function (r) {
                if (r) {
                
                    var datos = {};
                    datos.ListDESTINATARIO = this.dt.rows().data().toArray();
                    datos.RegEstado = RegEstadoSigo.DELETE;
                    this.saveAjax(datos);
                  
                }
            }.bind(this));
        }
        else {
            utilSigo.toastWarning("Aviso", "No hay Registros a Eliminar");
        }
    }   
    
  
}

class Ruta {
    constructor(nameObject, tipoVentana) {
        this.nameObject = nameObject;
        this.tipoVentana = tipoVentana;
        this.dt; 
        this.tr;  
        this.RegEstado;
    }
    init() {
 
        this.dt = ManPreviosAlerta.frm.find("#grvRutas").DataTable({
            bProcessing: true,
            bRetrieve: true,
            dom: 'Bfrtip', 
            bLengthChange: false,
            scrollCollapse: true,
            aaSorting: [],
            pageLength: initSigo.pageLength,
            oLanguage: initSigo.oLanguage,
            drawCallback: initSigo.showPagination,
            buttons: [{
                extend: 'excelHtml5',
                exportOptions: { orthogonal: 'export' },
                messageTop: 'Ruta',                
                exportOptions: {
                    columns: [0, ':visible']
                }
            }],

            columns: [
                { bSortable: false, mRender: this.cellDel.bind(this),width:'5%' },
              //  { name: "NRO", bSortable: true, mRender: utilDt.countRowDT, width: '5%' },
                { data: "COD_RUTA", width: '5%' },
                { data: "DEPARTAMENTO", width: '15%' },
                { data: "TRAMO", width: '50%' },
                { data: "ORIGEN_DESTINO", width: '20%' },
                { mRender: this.cellActive.bind(this), width: '5%' }/*,
                { data: "ACTIVO", visible: false },       
                { data: "COD_UBIDEPARTAMENTO", visible: false },
                
                */
            ]
        });
 
    }
    cellDel(data, type, row) {        
        return '<i class="cellDel fa fa-lg fa-window-close" title="Eliminar" onclick="' + this.nameObject + '.delete(this);"></i>';
    }
    cellActive(data, type, row) {

        if (type === 'export') {            
            if (row.ACTIVO == 1)
                return 'Activo';
            else
                return 'Desactivo';
        } else {
            if (row.ACTIVO == 1)
                return '<i class="cellCheck fa fa-lg fa-check-square-o" title="Click para Desactivar" onclick="' + this.nameObject + '.changeActivo(this);"></i>';
            else
                return '<i class="cellUnCheck fa fa-lg fa-square-o" title="click para Activar" onclick="' + this.nameObject + '.changeActivo(this);"></i>';
        }

    }
    changeActivo(obj) {
        var row = this.dt.row($(obj).closest('tr')).data();
        row.ACTIVO = row.ACTIVO == 1 ? 0 : 1;
        var datos = {};
        datos.ListRUTA =[ row];
        datos.RegEstado = RegEstadoSigo.UPDATE;
        this.saveAjax(datos);
    }
    showModal(RegEstado, obj) {
 
        var option = {
            url: ManPreviosAlerta.urlController + "/_ItemRuta",
            divId: "modalAddEditDestinatario"
        };
        this.RegEstado = RegEstado;
        this.tr = $(obj).closest('tr');
        utilSigo.fnOpenModal(option, this.configModal.bind(this));
    }
    configModal() {
        vpItemRuta.afterSave =this.afterSave.bind(this);
      
        var row;
        if (this.RegEstado==RegEstadoSigo.UPDATE)
            row = this.dt.row(this.tr).data();
        vpItemRuta.init(this.RegEstado, row);
     
    }   
    afterSave(data) {
        var url = ManPreviosAlerta.urlController + "/GetAllRuta";
        this.dt.ajax.url( url ).load();

    }  
    delete (obj) {
        utilSigo.dialogConfirm("Confirmacion", "¿Está seguro de Eliminar el Registro Seleccionado?",
            function (r) {
               
                var row = this.dt.row($(obj).closest('tr')).data();             
                var datos = {};
                datos.ListRUTA = [row];
                datos.RegEstado = RegEstadoSigo.DELETE;
                this.saveAjax(datos);

            }.bind(this));
    }
    saveAjax(datos) {
        $.ajax({
            url: ManPreviosAlerta.urlController + "/saveRuta",
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
                    if(datos.RegEstado==RegEstadoSigo.DELETE )
                        utilSigo.toastSuccess("Exito", "Se elimino con exito");

                    if (datos.RegEstado == RegEstadoSigo.UPDATE)
                        utilSigo.toastSuccess("Exito", "Se cambio de estado con exito");


                }
                else
                    utilSigo.toastWarning("Aviso", data.msj);
            }.bind(this)

        });

    }
    deleteAll() {
        if (this.dt.$("tr").length > 0) {
            var objTemp = this;
            utilSigo.dialogConfirm("Confirmacion", "Está seguro de Eliminar Todo los Registros?", function (r) {
                if (r) {
                
                    var datos = {};
                    datos.ListRUTA = this.dt.rows().data().toArray();
                    datos.RegEstado = RegEstadoSigo.DELETE;
                    this.saveAjax(datos);
                  
                }
            }.bind(this));
        }
        else {
            utilSigo.toastWarning("Aviso", "No hay Registros a Eliminar");
        }
    }   
    
  
}

class DestinatarioRuta {
    constructor(nameObject, tipoVentana) {
        this.nameObject = nameObject;
        this.tipoVentana = tipoVentana;
        this.dt; 
        this.tr;  
        this.RegEstado;
    }
    init() {
 
        this.dt = ManPreviosAlerta.frm.find("#grvDestinatarioRuta").DataTable({
            bProcessing: true,
            bRetrieve: true,
            dom: 'Bfrtip', 
            bLengthChange: false,
            scrollCollapse: true,
            aaSorting: [],
            pageLength: initSigo.pageLength,
            oLanguage: initSigo.oLanguage,
            drawCallback: initSigo.showPagination,
            buttons: [{
                extend: 'excelHtml5',
                exportOptions: { orthogonal: 'export' },
                messageTop: 'Destinatario Ruta'
            }],
            columns: [
                { bSortable: false, mRender: this.cellEdit.bind(this), width: '5%' },
                { bSortable: false, mRender: this.cellDel.bind(this),width:'5%' },      
                { data: "COD_RUTA", width: '5%' },
                { data: "DEPARTAMENTO", width: '10%' },
                { data: "ORIGEN_DESTINO", width: '10%' },
                { data: "TRAMO", width: '20%' },
                {
                    data: "DESCRIPCION", width: '50%', mRender: function (data, type, row) {
                        return data.replace(/,/g, ',<br />') ;
                    }
                } /*,
                { mRender: this.cellActive.bind(this), width: '5%' },
                { data: "ACTIVO", visible: false },       
                { data: "COD_DESTINATARIO", visible: false },
                { data: "COD_RUTA", visible: false },
                */
            ]
        });
 
    }
    cellEdit(data, type, row) {
        return '<i class="cellEdit fa fa-lg fa-pencil-square-o" title="Editar" onclick="' + this.nameObject + '.showModal(2,this);"></i>';

    }
    cellDel(data, type, row) {        
        return '<i class="cellDel fa fa-lg fa-window-close" title="Eliminar" onclick="' + this.nameObject + '.delete(this);"></i>';
    }
    cellActive(data, type, row) {

        if (type === 'export') {            
            if (row.ACTIVO == 1)
                return 'Activo';
            else
                return 'Desactivo';
        } else {
            if (row.ACTIVO == 1)
                return '<i class="cellCheck fa fa-lg fa-check-square-o" title="Click para Desactivar" onclick="' + this.nameObject + '.changeActivo(this);"></i>';
            else
                return '<i class="cellUnCheck fa fa-lg fa-square-o" title="click para Activar" onclick="' + this.nameObject + '.changeActivo(this);"></i>';
        }

    }
    changeActivo(obj) {
        var row = this.dt.row($(obj).closest('tr')).data();
        row.ACTIVO = row.ACTIVO == 1 ? 0 : 1;
        var datos = {};
        datos.ListRUTA =[ row];
        datos.RegEstado = RegEstadoSigo.UPDATE;
        this.saveAjax(datos);
    }
    showModal(RegEstado, obj) {
        this.RegEstado = RegEstado;

        var codRuta=0;
        if (this.RegEstado == RegEstadoSigo.UPDATE) {
            this.tr = $(obj).closest('tr');
            var row = this.dt.row(this.tr).data();
            codRuta = row.COD_RUTA;
        }
       
        var option = {
            url: ManPreviosAlerta.urlController + "/_ItemDestinatarioRuta",
            divId: "modalAddEditDestinatario",
            datos: { "RegEstado": this.RegEstado, "CodRuta": codRuta }
        };
        
     
        utilSigo.fnOpenModal(option, this.configModal.bind(this));
    }
    configModal() {
        _ItemDestinatarioRuta.afterSave =this.afterSave.bind(this);
      
 
        _ItemDestinatarioRuta.init(this.RegEstado);
     
    }   
    afterSave(data) {
        var url = ManPreviosAlerta.urlController + "/GetAllDestinatarioRuta";
        this.dt.ajax.url( url ).load();

    } 
    delete (obj) {
        utilSigo.dialogConfirm("Confirmacion", "¿Está seguro de Eliminar el Registro Seleccionado?",
            function (r) {
               
                var row = this.dt.row($(obj).closest('tr')).data();
                var rowTem = {
                    COD_DESTINATARIO:0,
                    COD_RUTA:row.COD_RUTA , 
                    COD_DESTINATARIO_RUTA:0
                };
                var datos = {};
                datos.ListDESTINATARIO_RUTA = [rowTem];
                datos.RegEstado = RegEstadoSigo.DELETE;            
                this.saveAjax(datos);

            }.bind(this));
    }
    saveAjax(datos) {
        $.ajax({
            url: ManPreviosAlerta.urlController + "/saveDestinatarioRuta",
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
                    if(datos.RegEstado==RegEstadoSigo.DELETE )
                        utilSigo.toastSuccess("Exito", "Se elimino con exito");

                    if (datos.RegEstado == RegEstadoSigo.UPDATE)
                        utilSigo.toastSuccess("Exito", "Se cambio de estado con exito");


                }
                else
                    utilSigo.toastWarning("Aviso", data.msj);
            }.bind(this)

        });

    }
    deleteAll() {
        if (this.dt.$("tr").length > 0) {
            var objTemp = this;
            utilSigo.dialogConfirm("Confirmacion", "Está seguro de Eliminar Todo los Registros?", function (r) {
                if (r) {
                
                    var datos = {};
                   
                    datos.ListDESTINATARIO_RUTA = [];
                    this.dt.rows().every(function (rowIdx, tableLoop, rowLoop) {
                        var row = this.data();
                        
                        datos.ListDESTINATARIO_RUTA.push({
                            COD_DESTINATARIO: 0,
                            COD_RUTA: row.COD_RUTA,
                            COD_DESTINATARIO_RUTA: 0
                        });
                        
                    });                   
                    datos.RegEstado = RegEstadoSigo.DELETE;
                    this.saveAjax(datos);
                  
                }
            }.bind(this));
        }
        else {
            utilSigo.toastWarning("Aviso", "No hay Registros a Eliminar");
        }
    }   
    
  
}

class Supuestos {
    constructor(nameObject, tipoVentana) {
        this.nameObject = nameObject;
        this.tipoVentana = tipoVentana;
        this.dt;
        this.tr;
        this.RegEstado;
    }
    init() {

        this.dt = ManPreviosAlerta.frm.find("#grvSupuestos").DataTable({
            bProcessing: true,
            bRetrieve: true,
            dom: 'Bfrtip',
            bLengthChange: false,
            scrollCollapse: true,
            aaSorting: [],
            pageLength: initSigo.pageLength,
            oLanguage: initSigo.oLanguage,
            drawCallback: initSigo.showPagination,
            buttons: [{
                extend: 'excelHtml5',
                exportOptions: { orthogonal: 'export' },
                messageTop: 'Supuestos'
            }],
            columns: [
                { bSortable: false, mRender: this.cellEdit.bind(this), width: '2%' },
                { bSortable: false, mRender: this.cellDel.bind(this), width: '2%' },
                { data: "COD_SUPUESTO", width: '5%' },
                { data: "ABREV_SUPUESTO", width: '10%' },
                { data: "DES_SUPUESTO", width: '51%' },
                { data: "ACTIVO_DESC", width: '5%' },
                { data: "NOMBRE_ARCHIVO", width: '25%' }
            ]
        });

    }
    cellEdit(data, type, row) {
        return '<i class="cellEdit fa fa-lg fa-pencil-square-o" title="Editar" onclick="' + this.nameObject + '.showModal(2,this);"></i>';

    }
    cellDel(data, type, row) {
        return '<i class="cellDel fa fa-lg fa-window-close" title="Eliminar" onclick="' + this.nameObject + '.delete(this);"></i>';
    }
    cellActive(data, type, row) {

        if (type === 'export') {
            if (row.ACTIVO == 1)
                return 'Activo';
            else
                return 'Desactivo';
        } else {
            if (row.ACTIVO == 1)
                return '<i class="cellCheck fa fa-lg fa-check-square-o" title="Click para Desactivar" onclick="' + this.nameObject + '.changeActivo(this);"></i>';
            else
                return '<i class="cellUnCheck fa fa-lg fa-square-o" title="click para Activar" onclick="' + this.nameObject + '.changeActivo(this);"></i>';
        }

    }
    changeActivo(obj) {
        var row = this.dt.row($(obj).closest('tr')).data();
        row.ACTIVO = row.ACTIVO == 1 ? 0 : 1;
        var datos = {};
        datos.ListRUTA = [row];
        datos.RegEstado = RegEstadoSigo.UPDATE;
        this.saveAjax(datos);
    }
    showModal(RegEstado, obj) { 
        var option = {
            url: ManPreviosAlerta.urlController + "/_ItemSupuesto",
            divId: "modalAddEditSupuesto"
        };        
        this.RegEstado = RegEstado;
        this.tr = $(obj).closest('tr');
        utilSigo.fnOpenModal(option, this.configModal.bind(this));
    }
    configModal() {
        _ItemSupuesto.afterSave = this.afterSave.bind(this);
        var row;
        if (this.RegEstado == RegEstadoSigo.UPDATE)
            row = this.dt.row(this.tr).data();        
        _ItemSupuesto.init(this.RegEstado, row);

    }
    afterSave(data) {
        $("#modalAddEditSupuesto").modal('hide');
        var url = ManPreviosAlerta.urlController + "/GetAllSupuesto";
        this.dt.ajax.url(url).load();

    }
  
    delete(obj) {
        utilSigo.dialogConfirm("Confirmacion", "¿Está seguro de Eliminar el Registro Seleccionado?",
            function (r) {

                var row = this.dt.row($(obj).closest('tr')).data();
                var rowTem = {
                    COD_SUPUESTO: row.COD_SUPUESTO,
                    NOMBRE_ARCHIVO_REAL: row.NOMBRE_ARCHIVO_REAL,
                };
                var datos = {};
                datos.ListSUPUESTO = [rowTem];
                datos.RegEstado = RegEstadoSigo.DELETE;
                this.saveAjax(datos);

            }.bind(this));
    }
    saveAjax(datos) {
        $.ajax({
            url: ManPreviosAlerta.urlController + "/saveSupuesto",
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

                    $("#modalAddEditSupuesto").modal('hide');

                }
                else
                    utilSigo.toastWarning("Aviso", data.msj);
            }.bind(this)

        });

    }
    deleteAll() {
        if (this.dt.$("tr").length > 0) {
            var objTemp = this;
            utilSigo.dialogConfirm("Confirmacion", "Está seguro de Eliminar Todo los Registros?", function (r) {
                if (r) {

                    var datos = {};

                    datos.ListSUPUESTO = [];
                    this.dt.rows().every(function (rowIdx, tableLoop, rowLoop) {
                        var row = this.data();

                        datos.ListSUPUESTO.push({
                            COD_SUPUESTO: row.COD_SUPUESTO
                        });

                    });
                    datos.RegEstado = RegEstadoSigo.DELETE;
                    this.saveAjax(datos);

                }
            }.bind(this));
        }
        else {
            utilSigo.toastWarning("Aviso", "No hay Registros a Eliminar");
        }
    }


}

class DestinatariosCC {
    constructor(nameObject, tipoVentana) {
        this.nameObject = nameObject;
        this.tipoVentana = tipoVentana;
        this.dt;
        this.tr;
        this.RegEstado;
    }
    init() {

        this.dt = ManPreviosAlerta.frm.find("#grvDestinatariosCC").DataTable({
            bProcessing: true,
            bRetrieve: true,
            dom: 'Bfrtip',
            bLengthChange: false,
            scrollCollapse: true,
            aaSorting: [],
            pageLength: initSigo.pageLength,
            oLanguage: initSigo.oLanguage,
            drawCallback: initSigo.showPagination,
            buttons: [{
                extend: 'excelHtml5',
                exportOptions: { orthogonal: 'export' },
                messageTop: 'Destinatarios con Copia'
            }],
            columns: [
                { bSortable: false, mRender: this.cellDel.bind(this), width: '2%' },
                { data: "COD_DESTINATARIO", width: '2%' },
                { data: "DESCRIPCION", width: '30%' },
                { data: "CORREO", width: '10%' },
                { data: "OFICINA", width: '10%' },
                { data: "DOCUMENTO", width: '10%' },
                { data: "FECHA_DOCUMENTO", width: '10%' },
                { data: "CARGO", width: '10%' },
                { data: "OBSERVACION", width: '10%' },
                { mRender: this.cellActive, width: '2%' }
            ]
        });

    }
    cellDel(data, type, row) {

        return '<i class="cellDel fa fa-lg fa-window-close" title="Eliminar" onclick="' + this.nameObject + '.delete(this);"></i>';
    }
    cellActive(data, type, row) {          
        if (row.ACTIVO == 1)
            return 'Activo';
        else
            return 'Desactivo';
    }
    changeActivo(obj) {
        var row = this.dt.row($(obj).closest('tr')).data();
        row.ACTIVO = row.ACTIVO == 1 ? 0 : 1;
        var datos = {};
        datos.ListDESTINATARIOCC = [row];
        datos.RegEstado = RegEstadoSigo.UPDATE;
        this.saveAjax(datos);
    }
    showModal() {
        var option = {
            url: ManPreviosAlerta.urlController + "/_ItemDestinatarioCC",
            divId: "modalAddEditDestinatarioCC"
        };

        utilSigo.fnOpenModal(option, this.configModal.bind(this));
    }
    configModal() {
        _ItemDestinatarioCC.afterSave = this.afterSave.bind(this);
        _ItemDestinatarioCC.init(this.RegEstado);

    }
    afterSave(data) {
        var url = ManPreviosAlerta.urlController + "/GetAllDestinatarioCC";
        this.dt.ajax.url(url).load();
    }
    delete(obj) {
        utilSigo.dialogConfirm("Confirmacion", "¿Está seguro de Eliminar el Registro Seleccionado?",
            function (r) {
               var row = this.dt.row($(obj).closest('tr')).data();
               var datos = {};
               datos.ListEliTABLA = [row];
               this.saveAjax(datos);
            }.bind(this));
    }
    saveAjax(datos) {
        $.ajax({
            url: ManPreviosAlerta.urlController + "/saveDestinatarioCC",
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
                    utilSigo.toastSuccess("Exito", "Se elimino con exito");
                }
                else
                    utilSigo.toastWarning("Aviso", data.msj);
            }.bind(this)

        });

    }
    deleteAll() {
        if (this.dt.$("tr").length > 0) {
            var objTemp = this;
            utilSigo.dialogConfirm("Confirmacion", "Está seguro de Eliminar Todo los Registros?", function (r) {
                if (r) {

                    var datos = {};

                    datos.ListEliTABLA = [];
                    this.dt.rows().every(function (rowIdx, tableLoop, rowLoop) {
                        var row = this.data();

                        datos.ListEliTABLA.push(row);

                    });
                    this.saveAjax(datos);

                }
            }.bind(this));
        }
        else {
            utilSigo.toastWarning("Aviso", "No hay Registros a Eliminar");
        }
    }
}

class COAdministrador {
    constructor(nameObject, tipoVentana) {
        this.nameObject = nameObject;
        this.tipoVentana = tipoVentana;
        this.dt;
        this.tr;
        this.RegEstado;
    }
    init() {

        this.dt = ManPreviosAlerta.frm.find("#grvCOAdministrador").DataTable({
            bProcessing: true,
            bRetrieve: true,
            dom: 'Bfrtip',
            bLengthChange: false,
            scrollCollapse: true,
            aaSorting: [],
            pageLength: initSigo.pageLength,
            oLanguage: initSigo.oLanguage,
            drawCallback: initSigo.showPagination,
            buttons: [{
                extend: 'excelHtml5',                
                messageTop: 'CoAdministrador',
                exportOptions: {      
                    columns: [0, ':visible'],
                    columns: [1, ':visible'],
                    columns: [2, ':visible'],
                    columns: [3, ':visible'],
                    columns: [4, ':visible'],
                    columns: [5, ':visible']                    
                }
            }],
            columns: [
                { bSortable: false, mRender: this.cellEdit.bind(this), width: '2%' },
                //{ bSortable: false, mRender: this.cellDel.bind(this), width: '2%' },                
                { data: "FECHA_REGISTRO", width: '20%' },
                { data: "USUARIO", width: '20%' },
                { data: "DESCRIPCION", width: '36%' },                
                { data: "ACTIVO_DESC", width: '20%' },                
                { data: "COD_PERSONA", visible: false },
                { data: "COD_UCUENTA", visible: false },
                { data: "CARGO", visible: false },
                { data: "CORREO", visible: false },
                { data: "ACTIVO", visible: false },
                { data: "DOCUMENTO", visible: false },
                { data: "FECHA_DOCUMENTO", visible: false },
                { data: "OFICINA", visible: false },
                { data: "OBSERVACION", visible: false }
            ]
        });

    }
    cellDel(data, type, row) {
        return '<i class="cellDel fa fa-lg fa-window-close" title="Eliminar" onclick="' + this.nameObject + '.delete(this);"></i>';
    }
    cellEdit(data, type, row) {
        return '<i class="cellEdit fa fa-lg fa-pencil-square-o" title="Editar" onclick="' + this.nameObject + '.showModal(0,this);"></i>';
    }
    cellActive(data, type, row) {
        if (row.ACTIVO == 1)
            return 'Activo';
        else
            return 'Desactivo';
    }
    changeActivo(obj) {
        var row = this.dt.row($(obj).closest('tr')).data();
        row.ACTIVO = row.ACTIVO == 1 ? 0 : 1;
        var datos = {};
        datos.ListDESTINATARIOCC = [row];
        datos.RegEstado = RegEstadoSigo.UPDATE;
        this.saveAjax(datos);
    }
    showModal(RegEstado, obj) {
        var option = {
            url: ManPreviosAlerta.urlController + "/_ItemCOAdministrador",
            divId: "modalAddEditCOAdministrador"
        };
        this.RegEstado = RegEstado;
        this.tr = $(obj).closest('tr');
        utilSigo.fnOpenModal(option, this.configModal.bind(this));
    }
    configModal() {
        _ItemCOAdministrador.afterSave = this.afterSave.bind(this);
        var row;
        if (this.RegEstado == RegEstadoSigo.INITIAL)
            row = this.dt.row(this.tr).data();
        _ItemCOAdministrador.init(this.RegEstado, row);

    }
    afterSave(data) {
        $("#modalAddEditCOAdministrador").modal('hide');
        var url = ManPreviosAlerta.urlController + "/GetAllCOAdministrador";
        this.dt.ajax.url(url).load();
    }  

    delete(obj) {
        utilSigo.dialogConfirm("Confirmacion", "¿Está seguro de Eliminar el Registro Seleccionado?",
            function (r) {
                var row = this.dt.row($(obj).closest('tr')).data();
                var datos = {};
                datos.ListEliTABLA = [row];
                this.saveAjax(datos);
            }.bind(this));
    }
    saveAjax(datos) {
        $.ajax({
            url: ManPreviosAlerta.urlController + "/saveDestinatarioCC",
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
                    utilSigo.toastSuccess("Exito", "Se elimino con exito");
                }
                else
                    utilSigo.toastWarning("Aviso", data.msj);
            }.bind(this)

        });

    }
    deleteAll() {
        if (this.dt.$("tr").length > 0) {
            var objTemp = this;
            utilSigo.dialogConfirm("Confirmacion", "Está seguro de Eliminar Todo los Registros?", function (r) {
                if (r) {

                    var datos = {};

                    datos.ListEliTABLA = [];
                    this.dt.rows().every(function (rowIdx, tableLoop, rowLoop) {
                        var row = this.data();

                        datos.ListEliTABLA.push(row);

                    });
                    this.saveAjax(datos);

                }
            }.bind(this));
        }
        else {
            utilSigo.toastWarning("Aviso", "No hay Registros a Eliminar");
        }
    }
}


