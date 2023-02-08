'use strict';
var _ItemDestinatarioRuta = {};
(function () {
    this.urlController = urlLocalSigo + "THabilitante/ManPreviosAlerta/";
    this.RegEstado;
    this.nameObject = "_ItemDestinatarioRuta";
    this.ListEliTABLA = [];
    this.init=(RegEstado,data)=> {
        this.frm = $("#frmItemDestinatarioRuta");
        this.content = $("#divItemDestinatarioRuta");
        this.RegEstado = RegEstado;
        if (RegEstado == RegEstadoSigo.UPDATE) {
            this.initData();
         
        }
        this.initEvent();
    }
    this.initData=(data)=> {
       
        $("#ddlDestinatarioRutaRutaId").attr("disabled", "disabled");
    }
    this.initEvent=()=> {
        this.configValidateForm();
        this.content.find("#btnGuardar").click(function () {
            this.save();
        }.bind(this));
      
        this.dtDestinatario = this.frm.find("#grvDestinatarioRutaDestinatario").DataTable({
            bProcessing: true,
            bRetrieve: true,
            bLengthChange: false,
            scrollCollapse: true,
            aaSorting: [],
            pageLength: 15,
            oLanguage: initSigo.oLanguage,
            drawCallback: initSigo.showPagination,     
            columns: [
                { bSortable: false, mRender: this.cellSelDest, width: '5%' }, 
                { data: "COD_DESTINATARIO", width: '5%' },
                { data: "DESCRIPCION", width: '50%' },
                { data: "CORREO", width: '20%' },
                { data: "OFICINA", width: '20%' }
       
            ]
        });
        this.dtDestinatarioRuta = this.frm.find("#grvDestinatarioRutaDestinatarioSeleccion").DataTable({
            bProcessing: true,
            bRetrieve: true,
            bLengthChange: false,
            scrollCollapse: true,
            aaSorting: [],
            pageLength: 15,
            oLanguage: initSigo.oLanguage,
            drawCallback: initSigo.showPagination,
            columns: [
                { bSortable: false, mRender: this.cellDelDestSel, width: '5%' },
                { data: "COD_DESTINATARIO", width: '5%' },
                { data: "DESCRIPCION", width: '50%' },
                { data: "CORREO", width: '20%' }, 
                { data: "OFICINA", width: '20%' }, 
                { data: "COD_RUTA", visible: false },
                { data: "COD_DESTINATARIO_RUTA", visible: false },                   
                { data: "RegEstado", visible: false }

            ]
        });
    }
    this.cellSelDest=(data, type, row)=>{        
        return '<i class="cellCheck fa fa-lg fa-check" title="Agregar Destinatario" onclick="' + this.nameObject + '.selectDestinatario(this);"></i>';
    }
    this.cellDelDestSel = (data, type, row) => {
        return '<i class="cellDel fa fa-lg fa-window-close" title="Quitar Destinatario" onclick="' + this.nameObject + '.deleteDestinatario(this);"></i>';
    }
    this.selectDestinatario = (obj) => {
        var tr = $(obj).closest('tr');
        var row = this.dtDestinatario.row(tr).data();
        if (!utilDt.existValorSearch(this.dtDestinatarioRuta, "COD_DESTINATARIO", row.COD_DESTINATARIO)) {
            row.RegEstado = RegEstadoSigo.NEW;
            row.COD_DESTINATARIO_RUTA = 0;
            row.COD_RUTA = 0;
            this.dtDestinatarioRuta.row.add(row).draw(false);
        }
        else
            utilSigo.toastError("Error", "El registro ya se encuentra agregado");
    }
    this.deleteDestinatario = (obj) => {
        var tr = $(obj).closest('tr');         
        var row = this.dtDestinatarioRuta.row(tr).data();
        this.addListEliTABLA(row);
        this.dtDestinatarioRuta.row(tr).remove().draw(false);
       
    }
    this.addListEliTABLA = function (row) {
        if (row.RegEstado == RegEstadoSigo.INITIAL || row.RegEstado == RegEstadoSigo.UPDATE) {
            this.ListEliTABLA.push({
                EliTABLA: "DESTINATARIO_RUTA",               
                EliVALOR01: row.COD_DESTINATARIO_RUTA,
                EliVALOR02: row.COD_DESTINATARIO,
                EliVALOR03: row.COD_RUTA
            });
        }
    }
    this.getListDt = function () {
        var list = [];
        this.dtDestinatarioRuta.rows().every(function (rowIdx, tableLoop, rowLoop) {
            var row = this.data();
            
            if (row.RegEstado == RegEstadoSigo.NEW || row.RegEstado == RegEstadoSigo.UPDATE) {
                var rowTemp = {
                    RegEstado: row.RegEstado,
                    COD_DESTINATARIO: row.COD_DESTINATARIO,
                    COD_RUTA: $("#ddlDestinatarioRutaRutaId").val(),
                    COD_DESTINATARIO_RUTA:row.COD_DESTINATARIO_RUTA
                }
                list.push(rowTemp);
            }
        });
        return list;
    }
    this.configValidateForm=()=> {
        var objValida = {};
        this.frm.validate(utilSigo.fnValidate(objValida));

    }
    this.validAdditional = () => {

        if (this.dtDestinatarioRuta.data().count() == 0) {
            utilSigo.toastWarning("Error", "Seleccion al menos un destinatario");
            return false;
        }
        return true;
    }
    this.save=()=> {
        if (this.frm.valid()) {
            if (this.validAdditional()) {
                let datos = {};                
                datos = this.frm.serializeObject();
                datos.ListDESTINATARIO_RUTA = this.getListDt();
                datos.RegEstado = this.RegEstado;
                datos.ListEliTABLA = this.ListEliTABLA;

                $.ajax({
                    url: this.urlController + "/saveDestinatarioRuta",
                    type: 'POST',
                    data: JSON.stringify(datos),
                    contentType: 'application/json;charset=utf-8',
                    dataType: 'json',
                    beforeSend: utilSigo.beforeSendAjax,
                    complete: utilSigo.completeAjax,
                    error: utilSigo.errorAjax,
                    success: function (data) {
                        if (data.success) {
                            this.afterSave(data);
                            this.finallySave();
                            utilSigo.toastSuccess("Exito", data.msj);                         
                        }
                        else utilSigo.toastWarning("Error", data.msj);
                    }.bind(this)
                });               
            }
        }
        else
            this.frm.validate().focusInvalid();
    }
    this.afterSave=(data)=> {

    }
    this.finallySave = () => {
        if (this.RegEstado == RegEstadoSigo.NEW)
            this.frm[0].reset();
        else
            this.close();
    }
    this.close = () => {       
        this.content.closest(".modal").modal("hide");
    }

}).apply(_ItemDestinatarioRuta);


 
