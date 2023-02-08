'use strict';
var _ItemDestinatarioCC = {};
(function () {
    this.urlController = urlLocalSigo + "THabilitante/ManPreviosAlerta/";
    this.nameObject = "_ItemDestinatarioCC";
    this.ListDESTINATARIOCC = [];
    this.ListEliTABLA = [];
    this.init = (data) => {
        this.frm = $("#frmItemDestinatarioCC");
        this.content = $("#divItemDestinatarioCC");
        this.initEvent();
    }
    this.initEvent = () => {
        this.configValidateForm();
        this.content.find("#btnGuardar").click(function () {
            this.save();
        }.bind(this));

        this.dtDestinatario = this.frm.find("#grvDestinatario").DataTable({
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
                { data: "OFICINA", width: '20%' },
                { data: "ACTIVO", visible: false },
                { data: "CARGO", visible: false },
                { data: "DOCUMENTO", visible: false },
                { data: "FECHA_DOCUMENTO", visible: false },
                { data: "COD_PERSONA", visible: false },
                { data: "OBSERVACION", visible: false },
                { data: "TIPO_FUNCIONARIO", visible: false }
            ]
        });
        this.dtDestinatarioCC = this.frm.find("#grvDestinatarioCC").DataTable({
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
                { data: "ACTIVO", visible: false },
                { data: "CARGO", visible: false },
                { data: "DOCUMENTO", visible: false },
                { data: "FECHA_DOCUMENTO", visible: false },
                { data: "COD_PERSONA", visible: false },
                { data: "OBSERVACION", visible: false },
                { data: "TIPO_FUNCIONARIO", visible: false },
                { data: "TIPO_CC", visible: false }
            ]
        });
    }
    this.cellSelDest = (data, type, row) => {
        return '<i class="cellCheck fa fa-lg fa-check" title="Agregar Destinatario" onclick="' + this.nameObject + '.selectDestinatario(this);"></i>';
    }
    this.cellDelDestSel = (data, type, row) => {
        return '<i class="cellDel fa fa-lg fa-window-close" title="Quitar Destinatario" onclick="' + this.nameObject + '.delete(this);"></i>';
    }
    this.selectDestinatario = (obj) => {
        
        var tr = $(obj).closest('tr');
        var row = this.dtDestinatario.row(tr).data();
        if (!utilDt.existValorSearch(this.dtDestinatarioCC, "COD_DESTINATARIO", row.COD_DESTINATARIO)) {
            row.TIPO_CC = 0;
            this.dtDestinatarioCC.row.add(row).draw(false);
            this.ListDESTINATARIOCC.push(row);
        }
        else
            utilSigo.toastError("Error", "El registro ya se encuentra agregado");
    }
    this.delete = (obj) => {        
        var tr = $(obj).closest('tr');
        var row = this.dtDestinatarioCC.row(tr).data();
        this.addListEliTABLA(row);
        this.dtDestinatarioCC.row(tr).remove().draw(false);
        for (var i = 0; i < this.ListDESTINATARIOCC.length ; i++)
        {
            if (this.ListDESTINATARIOCC[i].COD_DESTINATARIO == row.COD_DESTINATARIO) {                
                this.ListDESTINATARIOCC[i].TIPO_CC = 0;
                this.ListDESTINATARIOCC.splice(i, 1);
            }
        }        
    }
    this.addListEliTABLA = function (row) {
        if (row.TIPO_CC == 1) {
            this.ListEliTABLA.push(row);
        }
    }
    this.configValidateForm = () => {
        var objValida = {};
        this.frm.validate(utilSigo.fnValidate(objValida));
    }
    this.validAdditional = () => {
        if (this.dtDestinatarioCC.data().count() == 0) {
            utilSigo.toastWarning("Error", "Seleccion al menos un destinatario");
            return false;
        }
        return true;
    }
    this.save = () => {
        if (this.frm.valid()) {
            if (this.validAdditional()) {
                let datos = {};
                datos = this.frm.serializeObject();
                datos.ListDESTINATARIOCC = this.ListDESTINATARIOCC;
                datos.ListEliTABLA = this.ListEliTABLA;                

                $.ajax({
                    url: this.urlController + "/saveDestinatarioCC",
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
    this.afterSave = (data) => {

    }
    this.finallySave = () => {
        this.close();
    }
    this.close = () => {
        this.content.closest(".modal").modal("hide");
    }

}).apply(_ItemDestinatarioCC);
