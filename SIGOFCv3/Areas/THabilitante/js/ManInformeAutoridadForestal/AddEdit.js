/// <reference path="../../../../scripts/sigo/utility.sigo.js" />
/// <reference path="../../../../scripts/sigo/init.sigo.js" />

"use strict";
class InfAutForestal {
    constructor() {
        this.frm;
        this.ListEliTABLA = [];
        this.controller = urlLocalSigo + "THabilitante/ManInformeAutoridadForestal";
    }
    init() {
        this.frm = $("#frmInfAutForestal");
        this.configValidateForm();
        this.frm.find("#txtfecha_emision,#txtfecha_recepcion,#txtFecha_DocAutRenuncia").datepicker(initSigo.formatDatePicker);
        CKEDITOR.replace('txtControlCalidadObservaciones', { toolbar: initSigo.configuracionCKEDITOR });
        this.seleccionar();               
    }
    seleccionar() {        
        var valor = $("#ddlItemIndicadorId option:selected").text();
        if (valor == "Control de Calidad con Observaciones")
            this.frm.find("#divCalidad").show("slow");
        else
            this.frm.find("#divCalidad").hide("slow");
    }
    configValidateForm() {

        jQuery.validator.addMethod("invalidFrm", function (value, element) { 
            switch ($(element).attr('id')) {
                case 'ddlItemIndicadorId':               
                    return (value == '0000000') ? false : true;
                    break;
                case 'ddlODRegistroId':                 
                    return (value == '0000000') ? false : true;
                    break;
                case 'txtfecha_emision':
                    if ($(element).val() == "") return true;
                    return utilSigo.ValorIsFechaValue($(element).val());
                    break;
                case 'txtfecha_recepcion':
                    
                    if ($(element).val() == "") return true;
                    return utilSigo.ValorIsFechaValue($(element).val());
                    break;
            }
        });

        var objValida = {
            rules: {
                ddlItemIndicadorId: { invalidFrm: true },
                ddlODRegistroId: { invalidFrm: true },
                txtnum_informe: { required: true },
                txtfecha_emision: { required: true, invalidFrm:true }, 
                txtnum_poa: { required: true },
                txtfecha_recepcion: { invalidFrm: true }
            },
            messages: {
                ddlItemIndicadorId: { invalidFrm: "Debe seleccionar la situación actual de su registro" },
                ddlODRegistroId: { invalidFrm: "Debe seleccionar la O.D. desde donde se registra la información" },
                txtnum_informe: { required: "Ingrese el Nro. de informe" },
                txtfecha_emision: { required: "Ingrese la fecha de emisión del informe", invalidFrm: "Formato Fecha Incorrecto" },
            
                txtnum_poa: { required: "Ingrese el Nro. del POA" },
                txtfecha_recepcion: { invalidFrm: "Formato Fecha Incorrecto" }
            }
        };
        this.frm.validate(utilSigo.fnValidate(objValida)); 
    
    }
    validarControles(control, icon, msj) {
        var valorValidar = this.frm.find("#" + control).val();
        var iconValidar = this.frm.find("#" + icon);
        if (valorValidar.trim() == '') {  
            iconValidar.removeAttr('style');
            utilSigo.toastError("Aviso", msj)
            return false;
        }
        else {
            iconValidar.attr('style', 'display:none;');
            return true;
        }
    }
    validaForm() {
        var respuesta;
        respuesta = this.validarControles("lblnum_Thabilitante", "lblnum_Thabilitante_error", "Ingrese el Titulo de Habilitante");
        return respuesta;
    }
    save() {
        if (this.frm.valid()) {
            if (this.validaForm()) {
                var datos = this.frm.serializeObject();

                if (ItemProfesional.dt != undefined)
                    datos.ListProfesionales = ItemProfesional.getListDt();

                if (ItemVolInjustificado.dt != undefined)
                    datos.ListVolInjustificado = ItemVolInjustificado.getListDt();

                if (this.ListEliTABLA != undefined)
                    datos.ListEliTABLA = this.ListEliTABLA;

                if (this.frm.find("#ddlItemIndicadorId").val() == "0000007")
                    datos.txtControlCalidadObservaciones = CKEDITOR.instances["txtControlCalidadObservaciones"].getData();

                datos.chkItemObsSubsanada = $("#chkItemObsSubsanada").is(":checked");
                datos.chkPublicar = $("#chkPublicar").is(":checked");

                $.ajax({
                    url: this.controller + "/Registrar",
                    type: 'POST',
                    data: JSON.stringify(datos),
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'json',
                    beforeSend: utilSigo.beforeSendAjax,
                    complete: utilSigo.completeAjax,
                    error: utilSigo.errorAjax,
                    success: function (data) {
                        if (data.success) {
                            utilSigo.toastSuccess("Aviso", data.msj);
                            setTimeout(function () {
                                window.location = ManInfAutForestal.controller + "?lstManMenu=" + ManInfAutForestal.frm.find("#TipoFormularioId").val();
                            }, 2000);
                        }
                        else utilSigo.toastWarning("Aviso", data.msj);
                    }

                });
            }

        }else
            this.frm.validate().focusInvalid();
    }
}



class THabilitante {
    constructor() {        
    }
    showModal() {       
        var option = {
            url: initSigo.urlControllerGeneral + "/_THabilitante",
            divId: "modalBuscarTitular",
            datos: { hdfFormulario: ManInfAutForestal.frm.find("#TipoFormulario").val() }
        };      
        utilSigo.fnOpenModal(option, this.configModal);
    }
    configModal() {
        vpTHabilitante.fnAsignarDatos = function (obj) {
            var tr = $(obj).closest('tr');
            var row = vpTHabilitante.dtTituloHabilitante.row(tr).data();
            ManInfAutForestal.frm.find("#hdfItemCod_THabilitante").val(row.cod);
            ManInfAutForestal.frm.find("#lblnum_Thabilitante").val(row.nt);
            ManInfAutForestal.frm.find("#lblnom_Titular").val(row.pt);
            utilSigo.toastSuccess("Exito", "Se Modifico con exito");
        }
        vpTHabilitante.fnInit();
 
    }

}

class Profesional {
 
    constructor() {
        this.dt;
        this.tr;
        this.RegEstado;
       
    }
 
    init() {
        this.dt = ManInfAutForestal.frm.find("#grvItemProfesional").DataTable({         
            bProcessing: true,          
            bRetrieve: true,
            bFilter: false,                  
            bLengthChange: false,
            scrollCollapse: true,
            aaSorting: [],
            pageLength: initSigo.pageLength,
            oLanguage: initSigo.oLanguage,
            drawCallback: initSigo.showPagination,
            columns: [
                { bSortable: false, mRender: this.cellDel,width:"5%" },
                { name: "NRO", bSortable: true, mRender: utilDt.countRowDT, width: "5%"  },
                { data: "PERSONA", width: "90%"  },
                { data: "COD_PERSONA", visible: false },
                //{ data: "DESCRIPCION", visible: false },
                //{ data: "N_DOCUMENTO", visible: false },
                //{ data: "COD_DIDENTIDAD", visible: false },
                //{ data: "CARGO", visible: false },
                //{ data: "COLEGIATURA_NUM", visible: false },
                //{ data: "COD_DPESPECIALIDAD", visible: false },
                //{ data: "COD_NACADEMICO", visible: false },
                //{ data: "APE_PATERNO", visible: false },
                //{ data: "APE_MATERNO", visible: false },
                //{ data: "NOMBRES", visible: false },           
                { data: "RegEstado", visible: false }
            ]
        });
      
    }
    cellDel(data, type, row) {       
        return '<i class="cellDel fa fa-lg fa-window-close" title="Eliminar" onclick="ItemProfesional.delete(this);"></i>';
    }   
    //showModal(RegEstado, obj) {
    //    var option = {
    //        url: initSigo.urlControllerGeneral + "/_BuscarPersonaGeneral",
    //        divId: "modalBuscarPersona"
    //    };
    //    utilSigo.fnOpenModal(option, this.configModal);
    //}
    //configModal() {        
   
    //    _bPerGen.fnAsignarDatos = function (obj) {
    //        var tr = $(obj).closest('tr');
    //        var row = _bPerGen.dtBuscarPerona.row(tr).data();
    //        var dtTemp = ItemProfesional.dt;
    //        if (!utilDt.existValorSearch(dtTemp, "PERSONA", row.desc)) {
        
    //            var rowNew = {                  
    //                PERSONA: row.desc,
    //                COD_PERSONA: row.cod,
    //                DESCRIPCION: row.desc,
    //                N_DOCUMENTO: row.nd,
    //                COD_DIDENTIDAD: row.cdi,
    //                CARGO: row.car,
    //                COLEGIATURA_NUM: row.cnum,
    //                COD_DPESPECIALIDAD: row.cesp,
    //                COD_NACADEMICO: row.codaca,
    //                APE_PATERNO: row.apep,
    //                APE_MATERNO: row.apem,
    //                NOMBRES: row.nombres,
    //                RegEstado: RegEstadoSigo.NEW                 
    //            };
    //            dtTemp.row.add(rowNew).draw(false);
    //            dtTemp.page('last').draw('page');
    //            utilSigo.toastSuccess("Exito", "Se adiciono con exito");
    //        } else
    //            utilSigo.toastError("Error", "El registro ya existe");


    //    }
    //    _bPerGen.fnInit();
    //}

    fnBuscarPersona(_dom,_tipoPersonaSIGOsfc) {
        var url = urlLocalSigo + "General/Controles/_BuscarPersonaGeneral";
        var option = { url: url, type: 'GET', datos: { asBusGrupo: "PERSONA", asCodPTipo: _tipoPersonaSIGOsfc, asTipoPersona: "N" }, divId: "mdlBuscarPersona" };
        utilSigo.fnOpenModal(option, function () {
            _bPerGen.fnAsignarDatos = function (obj) {
                if (obj != null && obj != "") {
                    var data = _bPerGen.dtBuscarPerona.row($(obj).parents('tr')).data();
                    switch (_dom) {
                        case "PROF_SUSC_INF":
                            if (!utilDt.existValorSearch(ItemProfesional.dt, "COD_PERSONA", data["COD_PERSONA"])) {
                                var item = { COD_PERSONA: data["COD_PERSONA"], PERSONA: data["PERSONA"], RegEstado: "1" };
                                ItemProfesional.dt.row.add(item).draw();
                                ItemProfesional.dt.page('last').draw('page');
                            } else { utilSigo.toastWarning("Aviso", "El profesional que suscribe el informe ya se encuentra registrado"); }
                            break;
                    }
                    utilSigo.fnCloseModal("mdlBuscarPersona");
                }
            }
            _bPerGen.fnInit();
        });
    }

    delete(obj) {
      
        var objItem = this;      
        utilSigo.dialogConfirm("Confirmacion", "¿Está seguro de Eliminar el Registro Seleccionado?",
            function (r) {
                if (r) {
                    var $tr = $(obj).closest('tr');
                    var row = objItem.dt.row($tr).data();
                    objItem.addListEliTABLA(row);
                    objItem.dt.row($tr).remove().draw(false);
                    utilDt.enumColumn(objItem.dt, "NRO");
                }
            });
    }
    addListEliTABLA(row) {
        if (row.RegEstado == RegEstadoSigo.INITIAL || row.RegEstado == RegEstadoSigo.UPDATE) {
            ManInfAutForestal.ListEliTABLA.push({
                EliTABLA: "SUPERVISOR",
                COD_PERSONA: row.COD_PERSONA,
                COD_INFORME: ManInfAutForestal.frm.find("#hdfcod_informe").val()
            });
        }
    }
    getListDt() {
        var list = [];
        this.dt.rows().every(function (rowIdx, tableLoop, rowLoop) {
            var row = this.data();
            if (row.RegEstado == RegEstadoSigo.NEW || row.RegEstado == RegEstadoSigo.UPDATE) {
                list.push(row);
            }
        });
        return list;
    }
   

}

//ItemVolInjustificado
class VolInjustificado {   
    constructor(nameObject, tipoVentana) {
        
        this.nameObject = nameObject;
        this.tipoVentana = tipoVentana;       
        this.dt;
        this.divModal;
        this.tr;
        this.frm;
        this.RegEstado;
 
    }
    init(){
      

        this.dt = ManInfAutForestal.frm.find("#grvVolInjustificado").DataTable({
            bProcessing: true,
            bRetrieve: true,
            bFilter: false,
            bLengthChange: false,
            scrollCollapse: true,
            aaSorting: [],
            pageLength: initSigo.pageLength,
            oLanguage: initSigo.oLanguage,
            drawCallback: initSigo.showPagination,
            footerCallback: this.cellSummary,
            columns: [
                { bSortable: false, mRender: this.cellEdit.bind(this),width:"5%" },
                { bSortable: false, mRender: this.cellDel.bind(this), width: "5%"  },
                { name: "NRO", bSortable: true, mRender: utilDt.countRowDT, width: "5%"  },
                { data: "ESPECIES", width: "30%"  },
                { data: "VOLUMEN_APROBADO", width: "10%"  },
                { data: "VOLUMEN_MOVILIZADO", width: "10%"  },
                { data: "VOLUMEN_INJUSTIFICADO", width: "10%"  },
                { data: "VOLUMEN_JUSTIFICADO", width: "10%" },
                { data: "OBSERVACION", width: "15%"  },
                { data: "COD_ESPECIES", visible: false },
                { data: "COD_SECUENCIAL", visible: false },
                { data: "RegEstado", visible: false }
            ]
        });
    }
    cellSummary(row, data, start, end, display) {
        var api = this.api(), data;
        var columnas = [4, 5, 6, 7];
        for (var j in columnas) {
            var total = api.column(columnas[j]).data().reduce(function (a, b) {
                return utilSigo.intVal(a) + utilSigo.intVal(b);
            }, 0);

            $(api.column(columnas[j]).footer()).html(total.toFixed(3));
        }
        $(api.column(3).footer()).html("Total");
    }
    cellDel(data, type, row) {       
        return '<i class="cellDel fa fa-lg fa-window-close" title="Eliminar" onclick="'+this.nameObject +'.delete(this);"></i>';
    }
    cellEdit(data, type, row) {
  
        return '<i class="cellEdit fa fa-lg fa-pencil-square-o" title="Editar" onclick="' + this.nameObject + '.showModal(2,this);"></i>';
    }
    showModal(RegEstado, obj) {

        if (this.divModal == undefined) {
            this.divModal = $("#PDivItemVolInjustificado");
            this.frm = $("#frmVolInjustificado");
            this.frm.find('#ddlInjustEspecies').select2();
            this.configValidateForm();

        }

        var PDivTitulo = '';
        if (RegEstado == RegEstadoSigo.NEW) {
            PDivTitulo = "Nuevo Registro - Volumen Injustificado";

        } else {
            if (RegEstado == RegEstadoSigo.UPDATE) {
                PDivTitulo = "Modificando Registro - Volumen Injustificado";
                this.tr = $(obj).closest('tr');
                var row = this.dt.row(this.tr).data();
                this.frm.find("#txtInjustVolAprobado").val(row.VOLUMEN_APROBADO);
                this.frm.find("#txtInjustVolMovilizado").val(row.VOLUMEN_MOVILIZADO);
                this.frm.find("#txtInjustVolInjustificado").val(row.VOLUMEN_INJUSTIFICADO);
                this.frm.find("#txtInjustVolJustificado").val(row.VOLUMEN_JUSTIFICADO);
                this.frm.find("#txtInjustObservacion").val(row.OBSERVACION);
                this.frm.find("#ddlInjustEspecies").val(row.COD_ESPECIES).trigger("change");

            }
        }
        this.RegEstado = RegEstado;
        this.divModal.find(".spTitulo").html(PDivTitulo);
        utilSigo.modalDraggable(this.divModal, '.modal-header');
        this.divModal.modal({ keyboard: true, backdrop: 'static' });


    }
    cleanModal() {
        this.frm.find("#ddlInjustEspecies").val("-").trigger("change");        
        this.frm[0].reset();
    }
    closeModal() {
        this.cleanModal();
        //limpiando estilos si lo tienen
        $(':input', this.frm)
            .removeClass('border-danger')
            .removeAttr('data-toggle')
            .removeAttr('data-placement')
            .removeAttr('data-original-title')       
        ;    
        $('.select2-hidden-accessible', this.frm)
         .parents(".form-group")
         .removeClass('has-error')
         .removeAttr('data-toggle')
         .removeAttr('data-placement')
         .removeAttr('data-original-title') ;
        this.frm.validate().resetForm();
        this.divModal.modal('hide');
    }
    configValidateForm() {

     
        jQuery.validator.addMethod("invalidFrm1", function (value, element) {
            switch ($(element).attr('id')) {
                case 'ddlInjustEspecies':
                    return (value == '-') ? false : true;
                    break;         
            }
        });

        var objValida = {
            rules: {
                ddlInjustEspecies: { invalidFrm1: true },
                txtInjustVolAprobado: { required: true },
                txtInjustVolMovilizado: { required: true },
                txtInjustVolInjustificado: { required: true },
                txtInjustVolJustificado: { required: true }
            },
            messages: {
                ddlInjustEspecies: { invalidFrm1: "Debe seleccionar una especie" },
                txtInjustVolAprobado: { required: "Ingrese el volumen aprobado analizado" },
                txtInjustVolMovilizado: { required: "Ingrese el volumen movilizado analizado" },
                txtInjustVolInjustificado: { required: "Ingrese el volumen injustificado" },
                txtInjustVolJustificado: { required: "Ingrese el volumen justificado" },

            }
        };      
        this.frm.validate(utilSigo.fnValidate(objValida));
        //Para cuando cambia el combo para select2
        this.frm.find("select.select2-hidden-accessible").change(function () {
            if (!$.isEmptyObject(this.frm.validate().submitted)) {
                this.frm.validate().form();
            }
        }.bind(this));

   
    }
    validaSaveModal() {
        return true;
    }
    saveModal() {                
  
        if (this.frm.valid()) {
            if (this.validaSaveModal()) {

                if (this.RegEstado == RegEstadoSigo.NEW) {
                    var fila = {
                        COD_SECUENCIAL: 0,
                        COD_ESPECIES: this.frm.find("#ddlInjustEspecies").val(),
                        ESPECIES: this.frm.find("#ddlInjustEspecies").select2('data')[0].text,
                        VOLUMEN_APROBADO: this.frm.find("#txtInjustVolAprobado").val().trim() == "" ? 0 : this.frm.find("#txtInjustVolAprobado").val().trim(),
                        VOLUMEN_MOVILIZADO: this.frm.find("#txtInjustVolMovilizado").val().trim() == "" ? 0 : this.frm.find("#txtInjustVolMovilizado").val().trim(),
                        VOLUMEN_INJUSTIFICADO: this.frm.find("#txtInjustVolInjustificado").val().trim() == "" ? 0 : this.frm.find("#txtInjustVolInjustificado").val().trim(),
                        VOLUMEN_JUSTIFICADO: this.frm.find("#txtInjustVolJustificado").val().trim() == "" ? 0 : this.frm.find("#txtInjustVolJustificado").val().trim(),
                        OBSERVACION: this.frm.find("#txtInjustObservacion").val().trim(),
                        RegEstado: RegEstadoSigo.NEW
                    };
                    this.dt.row.add(fila).draw();
                    this.dt.page('last').draw('page');
                    utilSigo.toastSuccess("Exito", "Se Adiciono con exito");
                }
                else {
                    var row = this.dt.row(this.tr).data();
                    row.COD_ESPECIES = this.frm.find("#ddlInjustEspecies").val();
                    row.ESPECIES = this.frm.find("#ddlInjustEspecies").select2('data')[0].text;
                    row.VOLUMEN_APROBADO = this.frm.find("#txtInjustVolAprobado").val().trim() == "" ? 0 : this.frm.find("#txtInjustVolAprobado").val().trim();
                    row.VOLUMEN_MOVILIZADO = this.frm.find("#txtInjustVolMovilizado").val().trim() == "" ? 0 : this.frm.find("#txtInjustVolMovilizado").val().trim();
                    row.VOLUMEN_INJUSTIFICADO = this.frm.find("#txtInjustVolInjustificado").val().trim() == "" ? 0 : this.frm.find("#txtInjustVolInjustificado").val().trim();
                    row.VOLUMEN_JUSTIFICADO = this.frm.find("#txtInjustVolJustificado").val().trim() == "" ? 0 : this.frm.find("#txtInjustVolJustificado").val().trim();
                    row.OBSERVACION = this.frm.find("#txtInjustObservacion").val().trim();


                    if (row.RegEstado == RegEstadoSigo.INITIAL)
                        row.RegEstado = RegEstadoSigo.UPDATE;

                    this.dt.row(this.tr).data(row).draw(false);
                    utilSigo.toastSuccess("Exito", "Se modifico con exito");
                    this.closeModal();
                }
            }
        }
       
    }
    delete(obj) {      
        utilSigo.dialogConfirm("Confirmacion", "¿Está seguro de Eliminar el Registro Seleccionado?",
            function (r) {
                if (r) {
                    var $tr = $(obj).closest('tr');
                    var row = this.dt.row($tr).data();
                    this.addListEliTABLA(row);
                    this.dt.row($tr).remove().draw(false);
                    utilDt.enumColumn(this.dt, "NRO");
                }
            }.bind(this));
    }
    deleteAll() { 
        if (this.dt.$("tr").length > 0) {
            var objTemp = this;
            utilSigo.dialogConfirm("Confirmacion", "Está seguro de Eliminar Todo los Registros?", function (r) {
                if (r) {
                    objTemp.dt.rows().every(function (rowIdx, tableLoop, rowLoop) {                       
                        objTemp.addListEliTABLA(this.data());
                    });
                    objTemp.dt.clear().draw();
                }
            });
        }
        else {
            utilSigo.toastWarning("Aviso", "No hay Registros a Eliminar");
        }
    }
    addListEliTABLA(row) {
        if (row.RegEstado == RegEstadoSigo.INITIAL || row.RegEstado == RegEstadoSigo.UPDATE) {
            ManInfAutForestal.ListEliTABLA.push({
                EliTABLA: "ISUPERVISION_DET_VOLUMEN",
                COD_SECUENCIAL: row.COD_SECUENCIAL
              //  EliVALOR02: row.COD_SECUENCIAL
            });
        }
    }
    getListDt() {
        var list = [];
        this.dt.rows().every(function (rowIdx, tableLoop, rowLoop) {
            var row = this.data();
            if (row.RegEstado == RegEstadoSigo.NEW || row.RegEstado == RegEstadoSigo.UPDATE) {
                list.push(row);
            }
        });
        return list;
    }
    validaImportarExcel(e, objeto) {
        return true;
    }
    importarExcel(e, objeto) {
        const urlImportExcel = ManInfAutForestal.controller + "/ImportarDataExcel";
        uploadFile.fileSelectHandler(e, objeto, urlImportExcel, { TVentana: this.tipoVentana }, this.successImpExcel.bind(this));
    }
    successImpExcel(data) {
        this.dt.rows.add(data).draw();
        this.dt.page('last').draw('page');
    }
    exportarExcel(TVentana) {
        var datos = {};
        datos.ListVolInjustificado = this.dt.rows().data().toArray();;
        datos.TVentana = this.tipoVentana; 
        $.ajax({
            url: ManInfAutForestal.controller + "/ExportarExcel",
            type: 'POST',
            data: JSON.stringify(datos),
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            beforeSend: utilSigo.beforeSendAjax,
            complete: utilSigo.completeAjax,
            error: utilSigo.errorAjax,
            success: function (data) {
             
                if (data.success) {
                    window.location.href = ManInfAutForestal.controller + "/Download?file=" + data.values[0];
                }
                else utilSigo.toastWarning("Error", data.msj);
            }
        });

    }
}
    



