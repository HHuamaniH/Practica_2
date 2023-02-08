/// <reference path="../../../../scripts/sigo/utility.sigo.js" />
/// <reference path="../../../../scripts/sigo/init.sigo.js" />

"use strict";
var ManDM = {};
(function () {
    this.frm;
    this.ListEliTABLA = [];
    this.controller = urlLocalSigo + "THabilitante/ManDevolucionMadera";
    this.init = function () {
        
        this.frm = $("#frmDMaderaRegistro");
        this.frm.find("#txtItemFechaResol,#txtItemEjecucionInicio,#txtItemEjecucionFin,#txtItemItecnico_Raprobacion_Fecha,#txtItemFEmisionBExtracion").datepicker(initSigo.formatDatePicker);
        CKEDITOR.replace('txtControlCalidadObservaciones', { toolbar: initSigo.configuracionCKEDITOR });

        $.fn.select2.defaults.set("theme", "bootstrap4");

        var valor = $("#ddlItemIndicadorId option:selected").text();
        if (valor == "Control de Calidad con Observaciones")
            this.frm.find("#divCalidad").show("slow");
        else
            this.frm.find("#divCalidad").hide("slow");


        jQuery.validator.addMethod("invalidFrm", function (value, element) {
            switch ($(element).attr('id')) {
                case 'ddlItemIndicadorId':
                    return (value == '0000000') ? false : true;
                    break;
                case 'ddlODRegistroId':
                    return (value == '0000000') ? false : true;
                    break;

            }
        });
        this.frm.validate({
            focusInvalid: true,
            ignore: [],
            rules: {
                ddlItemIndicadorId: { invalidFrm: true },
                ddlODRegistroId: { invalidFrm: true },
             //   hdfItemFunFirmaCodigo: { required: true },
                txtItemNumResolucion: { required: true },
                txtItemFechaResol: { required: true }
            },
            messages: {
                ddlItemIndicadorId: { invalidFrm: "Debe seleccionar la situación actual de su registro" },
                ddlODRegistroId: { invalidFrm: "Debe seleccionar la O.D. desde donde se registra la información" },
               // hdfItemFunFirmaCodigo: { required: "Ingrese el Funcionario que firma la resolucion" },
                txtItemNumResolucion: { required: "Ingrese Número de Resolucion" },
                txtItemFechaResol: { required: "Ingrese Fecha de Resolucion" }
            },
            errorPlacement: function (error, element) {
                var lElement = $(element);
                lElement.addClass('border-danger');
                lElement.attr('data-toggle', 'tooltip');
                lElement.attr('data-placement', 'top');
                lElement.attr('data-original-title', error.text());
                $('[data-toggle="tooltip"]').tooltip();
            },
            success: function (label, element) {
                var lElement = $(element);
                lElement.removeClass('border-danger');
                lElement.removeAttr('data-toggle');
                lElement.removeAttr('data-placement');
                lElement.removeAttr('data-original-title');
            },
            submitHandler: function (form) {
              
                if (ManDM.validaSave()) {
                    utilSigo.dialogConfirm('', 'Desea continuar con la operacion?', function (r) {
                        if (r) {

                            ManDM.save();
                        }
                    });
                }
            }
        });

        $("#btnSaveDevMadera").click(function () {
            if (!ManDM.validacionGeneral()) {
              
                return ManDM.frm.valid();
            }

            ManDM.frm.submit();
        });
    }
    this.Seleccionar = function (combo) {
        var valor = combo.options[combo.selectedIndex].text;
        if (valor == "Control de Calidad con Observaciones")
            this.frm.find("#divCalidad").show("slow");
        else
            this.frm.find("#divCalidad").hide("slow");

    }
    this.validacionGeneral = function () {
        var ids = ["ddlItemIndicadorId", "ddlODRegistroId"];
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
        return valRetorno;
    }
    this.validaSave = function () {

        if (this.frm.find("#ddlItemIndicador").val() == '0000000') {
            utilSigo.toastError("Error", "Debe seleccionar la situación actual de su registro");
            return false;
        }
        if (this.frm.find("#ddlODRegistro").val() == '0000000') {
            utilSigo.toastError("Error", "Debe seleccionar la O.D. desde donde se registra la información");
            return false;
        }
        if (this.frm.find("#hdfItemFunFirmaCodigo").val() == '') {
            utilSigo.toastError("Error", "Ingrese el Funcionario que firma la resolucion");
            return false;
        }
        
       
        return true;
    }
    this.save = function () {
     
        var datos = ManDM.frm.serializeObject();
    
        if (ItemPoa.dt != undefined) 
            datos.ListNUM_POA = ItemPoa.getListDt();
        if (ItemEspDev.dt != undefined)
            datos.ListESPDEVUELTAS = ItemEspDev.getListDt();

        if (ItemEspHalladas.dt != undefined)
            datos.ListESPHALLADAS = ItemEspHalladas.getListDt();
        if (ItemBExtMaderable.dt != undefined)
            datos.ListBEXTRACCION = ItemBExtMaderable.getListDt();
        if (ItemVertice.dt != undefined)
            datos.ListVERTICE = ItemVertice.getListDt();
        if (ItemCTroza.dt != undefined)
            datos.ListDEVOLCENSOTROZA = ItemCTroza.getListDt();
        if (ItemCTocon.dt != undefined)
            datos.ListDEVOLCENSOTOCON = ItemCTocon.getListDt();
        if (ItemCArbol.dt != undefined)
            datos.ListDEVOLCENSOARBOL = ItemCArbol.getListDt();
        if (ItemTRAprobacion.dt != undefined)
            datos.ListPINFTEC = ItemTRAprobacion.getListDt();
        if (ManDM.ListEliTABLA != undefined) 
            datos.ListEliTABLA = ManDM.ListEliTABLA;


        if (ManDM.frm.find("#ddlItemIndicadorId").val() == "0000007") 
            datos.txtControlCalidadObservaciones = CKEDITOR.instances["txtControlCalidadObservaciones"].getData();

        if ($("#chkItemObsSubsanada") != undefined) 
            datos.chkItemObsSubsanada = $("#chkItemObsSubsanada").is(":checked");

        datos.TIENE_POA = ItemPoa.dt.data().count()>0?true:false;
 

        $.ajax({
            url: ManDM.controller + "/RegistrarDM",
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
                        window.location = ManDM.controller;
                    }, 2000);
                }
                else utilSigo.toastWarning("Aviso", data.msj);
            }
        });
    }



}).apply(ManDM);



//ItemPoa
var ItemPoa = {};
(function () {
    this.dt;
    this.ListEliTABLA = [];

    this.init = function () {
        this.dt = ManDM.frm.find("#grvLista_Poa").DataTable({
            bServerSide: false,
            bProcessing: true,
            bJQueryUI: false,
            bRetrieve: true,
            bFilter: false,
            aaSorting: [],
            bPaginate: true,
            bLengthChange: false,
            scrollCollapse: true,
            pageLength: initSigo.pageLength,
            oLanguage: initSigo.oLanguage,
            drawCallback: initSigo.showPagination,
            columns: [
                { bSortable: false, mRender: ItemPoa.cellDel },
                { name: "NRO", bSortable: false, mRender: utilDt.countRowDT },
                { data: "NUM_POA" },
                { data: "ESTADO_ORIGEN" },
                { data: "RegEstado", visible: false }

            ]
        });
    }
    this.cellDel = function (data, type, row) {
        return '<i class="cellDel fa fa-lg fa-window-close" title="Eliminar" onclick="ItemPoa.delete(this);"></i>';
    }
    this.showModal = function (RegEstado, obj) {
        var url = "", sFormulario = "TITULO_HABILITANTE", sCriterio = "CN_DEV_POA_PMANEJO", sValor = ManDM.frm.find("#hdfItemCod_THabilitante").val();
        url = initSigo.urlControllerGeneral + "_POA";
        var option = { url: url, type: 'POST', datos: { asFormulario: sFormulario, asCriterio: sCriterio, asValor: sValor }, divId: "modalBuscarPOA" };
        utilSigo.fnOpenModal(option, ItemPoa.configModal);
    }
    this.configModal = function () {
        _POA.fnAsignarDatos = function (obj) {
            if (obj != null && obj != "") {
                var data = _POA.dtPOA.row($(obj).parents('tr')).data();

                if (!utilDt.existValorSearch(ItemPoa.dt, "NUM_POA", data["NUM_POA"])) {
                    data["RegEstado"] = 1;
                    ItemPoa.dt.rows.add([data]).draw(false);
                    ItemPoa.dt.page('last').draw('page');
                    utilSigo.toastSuccess("Exito", "Se adiciono con exito");
                    $("#modalBuscarPOA").modal('hide');
                } else {
                    utilSigo.toastError("Error", "El registro ya existe");
                }
            }
        }

        _POA.fnInit();
    }
    this.delete = function (obj) {
        utilSigo.dialogConfirm("Confirmacion", "¿Está seguro de Eliminar el Registro Seleccionado?",
            function (r) {
                if (r) {
                    var $tr = $(obj).closest('tr');

                    var row = ItemPoa.dt.row($tr).data();
                    if (row.RegEstado == 0 || row.RegEstado == 2) {
                        ManDM.ListEliTABLA.push({
                            EliTABLA: "DEVOLUCION_VS_POA",
                            EliVALOR01: "",
                            EliVALOR02: 0
                        });
                    }
                    ItemPoa.dt.row($tr).remove().draw(false);
                    // utilSigo.enumTB(ItemPoa.dt, 1);
                    utilDt.enumColumn(ItemPoa.dt, "NRO");
                }
            });
    }
    this.getListDt = function () {
        var list = [];
        this.dt.rows().every(function (rowIdx, tableLoop, rowLoop) {
            var row = this.data();
            if (row.RegEstado == 1) {
                list.push({
                    NUM_POA: row.NUM_POA,
                    ESTADO_ORIGEN: row.ESTADO_ORIGEN,
                    RegEstado: row.RegEstado
                });
            }

        });
        return list;
    }


}).apply(ItemPoa);

//ItemEspDev
var ItemEspDev = {};
(function () {
    this.dt;
    this.tipoVentana = "ESPDEV";
    this.divModal;
    this.tr;
    this.frm;
    this.init = function () {
     
        this.dt = ManDM.frm.find("#grvItemEspDev").DataTable({
            bServerSide: false,
            bProcessing: true,
            bJQueryUI: false,
            bRetrieve: true,
            bFilter: false,
            aaSorting: [],
            bPaginate: true,
            bLengthChange: false,
            scrollCollapse: true,   
            pageLength: initSigo.pageLength,
            oLanguage: initSigo.oLanguage,
            drawCallback: initSigo.showPagination,
            columns: [
                { bSortable: false, mRender: ItemEspDev.cellEdit },
                { bSortable: false, mRender: ItemEspDev.cellDel },
                { name: "NRO", bSortable: true, mRender: utilDt.countRowDT, width: "5%" },
                { data: "ESPECIES", width: "40%" },
                { data: "NUM_TROZAS", width: "10%" },
                { data: "VOLUMEN", width: "10%" },
                { data: "COORDENADA_ESTE", width: "10%" },
                { data: "COORDENADA_NORTE", width: "10%" },
                { data: "OBSERVACION", width: "15%" },
                { data: "COD_SECUENCIAL", visible: false },
                { data: "COD_ESPECIES", visible: false },
                { data: "RegEstado", visible: false }
            ]
        });
    }
    this.cellDel = function (data, type, row) {
        return '<i class="cellDel fa fa-lg fa-window-close" title="Eliminar" onclick="ItemEspDev.delete(this);"></i>';
    }
    this.cellEdit = function (data, type, row) {
        return '<i class="cellEdit fa fa-lg fa-pencil-square-o" title="Editar" onclick="ItemEspDev.showModal(0,this);"></i>';

    }

    this.showModal = function (RegEstado, obj) {

        if (this.divModal == undefined || this.frm == undefined) {
            this.divModal = $("#PDivItemEspDevContenedor");
            this.frm = $("#frmEspDev");
            this.frm.find('#ddlItemEspDevEspecies').select2();
            this.configValidateForm();
        }

        var PDivTitulo = '';
        if (RegEstado == 1) {
            PDivTitulo = "Nuevo Registro";
            this.frm.find("#ddlItemEspDevEspecies").attr("disabled", false);
      
        } else {
            if (RegEstado == 0) {
           
                PDivTitulo = "Modificando Registro";
                this.tr = $(obj).closest('tr');
                var row = this.dt.row(this.tr).data();
              
                this.frm.find("#ddlItemEspDevEspecies").val(row.COD_ESPECIES).trigger("change");
                this.frm.find("#txtItemEspDevNumTrozas").val(row.NUM_TROZAS);
                this.frm.find("#txtItemEspDevVolumen").val(row.VOLUMEN);
                this.frm.find("#txtItemEspDevCoordenada_Este").val(row.COORDENADA_ESTE);
                this.frm.find("#txtItemEspDevCoordenada_Norte").val(row.COORDENADA_NORTE);
                this.frm.find("#txtItemEspDevObservacion").val(row.OBSERVACION);
                this.frm.find("#ddlItemEspDevEspecies").attr("disabled", true);
             
            }
        }

        this.divModal.find(".spTitulo").html(PDivTitulo);
        this.frm.find("#hdfItemEspDev_RegEstado").val(RegEstado);
        utilSigo.modalDraggable(this.divModal, '.modal-header');
        this.divModal.modal({ keyboard: true, backdrop: 'static' });
 

    }
    this.cleanModal = function () {
        this.frm[0].reset();
        this.frm.find("#ddlItemEspDevEspecies").val("-").trigger("change");
    }

    this.closeModal = function () {
        this.cleanModal();
        //limpiando estilos si lo tienen
        $(':input', this.frm)
            .removeClass('border-danger')
            .removeAttr('data-toggle')
            .removeAttr('data-placement')
            .removeAttr('data-original-title');

        $('.select2-hidden-accessible', this.frm)
            .parents(".form-group")
            .removeClass('has-error')
            .removeAttr('data-toggle')
            .removeAttr('data-placement')
            .removeAttr('data-original-title');
        this.divModal.modal('hide');
    }
    this.validaSaveModal = function () {
        return true;
    }
    this.configValidateForm =function(){
        jQuery.validator.addMethod("invalidFrmDev", function (value, element) {
            switch ($(element).attr('id')) {
                case 'ddlItemEspDevEspecies':
                    return (value == '-') ? false : true;
                    break;
              
            }
        });

        var objValida = {
            rules: {
                ddlItemEspDevEspecies: { invalidFrmDev: true }
            },
            messages: {
                ddlItemEspDevEspecies: { invalidFrmDev: "Debe seleccionar una especie" }
            }
        };
        this.frm.validate(utilSigo.fnValidate(objValida));
        
        //Para cuando cambia el combo para select2
        this.frm.find("select.select2-hidden-accessible").change(function () {
            if (!$.isEmptyObject(this.frm.validate().submitted) && this.divModal.is(":visible")) {
                this.frm.validate().form();
            }
        }.bind(this));

    }
    this.saveModal = function () {
       
        if (this.frm.valid()) {

            if (this.validaSaveModal()) {

                var estado = this.frm.find("#hdfItemEspDev_RegEstado").val();

                if (estado == "1") {

                    var fila = {
                        COD_SECUENCIAL: 0,
                        COD_ESPECIES: this.frm.find("#ddlItemEspDevEspecies").val(),
                        NUM_TROZAS: this.frm.find("#txtItemEspDevNumTrozas").val().trim(),
                        VOLUMEN: this.frm.find("#txtItemEspDevVolumen").val().trim(),
                        COORDENADA_ESTE: this.frm.find("#txtItemEspDevCoordenada_Este").val().trim(),
                        COORDENADA_NORTE: this.frm.find("#txtItemEspDevCoordenada_Norte").val().trim(),
                        OBSERVACION: this.frm.find("#txtItemEspDevObservacion").val().trim(),
                        ESPECIES: this.frm.find("#ddlItemEspDevEspecies").select2('data')[0].text,
                        RegEstado: 1
                    };

                    this.dt.row.add(fila).draw();
                    this.dt.page('last').draw('page');
                    utilSigo.toastSuccess("Exito", "Se Adiciono con exito");
                }
                else {

                    var row = this.dt.row(this.tr).data();


                    row.NUM_TROZAS = this.frm.find("#txtItemEspDevNumTrozas").val().trim();
                    row.VOLUMEN = this.frm.find("#txtItemEspDevVolumen").val().trim();
                    row.COORDENADA_ESTE = this.frm.find("#txtItemEspDevCoordenada_Este").val().trim();
                    row.COORDENADA_NORTE = this.frm.find("#txtItemEspDevCoordenada_Norte").val().trim();
                    row.OBSERVACION = this.frm.find("#txtItemEspDevObservacion").val().trim();

                    if (row.RegEstado == 0)
                        row.RegEstado = 2;

                    this.dt.row(this.tr).data(row).draw(false);

                    utilSigo.toastSuccess("Exito", "Se modifico con exito");
                    this.closeModal();
                }
            }
        }  
    }

    this.delete = function (obj) {
        utilSigo.dialogConfirm("Confirmacion", "¿Está seguro de Eliminar el Registro Seleccionado?",
            function (r) {
                if (r) {
                    var $tr = $(obj).closest('tr');
                    var row = ItemEspDev.dt.row($tr).data();
                    if (row.RegEstado == 0 || row.RegEstado == 2) {
                        ManDM.ListEliTABLA.push({
                            EliTABLA: "DEV_MAD_DET_ESP_DEVUELTAS",
                            EliVALOR01: row.COD_ESPECIES,
                            EliVALOR02: row.COD_SECUENCIAL
                        });
                    }
                    ItemEspDev.dt.row($tr).remove().draw(false);
                    utilDt.enumColumn(ItemEspDev.dt, "NRO");

                }
            });
     
    }
    this.deleteAll = function () {

        var $trsEliminar = ItemEspDev.dt.$("tr");
        if ($trsEliminar.length > 0) {
            utilSigo.dialogConfirm("", "Está seguro de Eliminar Todo los Registros?", function (r) {
                if (r) {

                    ItemEspDev.dt.rows().every(function (rowIdx, tableLoop, rowLoop) {
                        var row = this.data();
                        if (row.RegEstado == 0 || row.RegEstado == 2) {
                            ManDM.ListEliTABLA.push({
                                EliTABLA: "DEV_MAD_DET_ESP_DEVUELTAS",
                                EliVALOR01: row.COD_ESPECIES,
                                EliVALOR02: row.COD_SECUENCIAL
                            });
                        }
                    });
                    ItemEspDev.dt.clear().draw();
                }
            });
        }
        else {
            utilSigo.toastWarning("Aviso", "No hay Registros a Eliminar");
        }
    }
    this.getListDt = function () {
        var list = [];
        this.dt.rows().every(function (rowIdx, tableLoop, rowLoop) {
            var row = this.data();
            if (row.RegEstado == 1 || row.RegEstado == 2) {

                list.push({
                    ESPECIES: row.ESPECIES,
                    NUM_TROZAS: row.NUM_TROZAS,
                    VOLUMEN: row.VOLUMEN,
                    COORDENADA_ESTE: row.COORDENADA_ESTE,
                    COORDENADA_NORTE: row.COORDENADA_NORTE,
                    OBSERVACION: row.OBSERVACION,
                    COD_SECUENCIAL: row.COD_SECUENCIAL,
                    COD_ESPECIES: row.COD_ESPECIES,
                    RegEstado: row.RegEstado
                });

            }


        });
        return list;
    }
    this.validaImportarExcel = function (e, objeto) {
        return true;
    }
    this.importarExcel = function (e, objeto) {
        var ruta = ManDM.controller + "/ImportarDataExcel";
        uploadFile.fileSelectHandler(e, objeto, ruta, { TVentana: this.tipoVentana }, this.successImpExcel);
    }
    this.successImpExcel = function (data) {
        ItemEspDev.dt.rows.add(data).draw();
        ItemEspDev.dt.page('last').draw('page');
    }

}).apply(ItemEspDev);

//ItemEspHalladas
var ItemEspHalladas = {};
(function () {
    this.dt;
    this.tipoVentana = "ESPHAL";
    this.divModal;
    this.tr;
    this.frm;
    this.regEstado;
    this.init = function () {

        this.dt = ManDM.frm.find("#grvItemEspHalladas").DataTable({
            bServerSide: false,
            bProcessing: true,
            bJQueryUI: false,
            bRetrieve: true,
            bFilter: false,
            aaSorting: [],
            bPaginate: true,
            bLengthChange: false,
            scrollCollapse: true,  
            pageLength: initSigo.pageLength,
            oLanguage: initSigo.oLanguage,
            drawCallback: initSigo.showPagination,
            columns: [
                { bSortable: false, mRender: this.cellEdit },
                { bSortable: false, mRender: this.cellDel },
                { name: "NRO", bSortable: true, mRender: utilDt.countRowDT, width: "5%" },
                { data: "ESPECIES", width: "40%" },
                { data: "NUM_TROZAS", width: "10%" },
                { data: "VOLUMEN",   width: "10%"  },
                { data: "COORDENADA_ESTE", width: "10%" },
                { data: "COORDENADA_NORTE", width: "10%" },
                { data: "OBSERVACION", width: "15%" },
                { data: "COD_SECUENCIAL", visible: false },
                { data: "COD_ESPECIES", visible: false },
                { data: "RegEstado", visible: false }
            ]
        });
    }
    this.cellDel = function (data, type, row) {
        return '<i class="cellDel fa fa-lg fa-window-close" title="Eliminar" onclick="ItemEspHalladas.delete(this);"></i>';
    }
    this.cellEdit = function (data, type, row) {
        return '<i class="cellEdit fa fa-lg fa-pencil-square-o" title="Editar" onclick="ItemEspHalladas.showModal(0,this);"></i>';

    }

    this.showModal = function (RegEstado, obj) {

        if (this.divModal == undefined || this.frm == undefined) {
            this.divModal = $("#PDivItemEspHalladas");
            this.frm = $("#frmEspHalladas");
            this.frm.find('#ddlItemEspHalladasEspecies').select2();
            this.configValidateForm();
        }

        var PDivTitulo = '';
        if (RegEstado == 1) {
            PDivTitulo = "Nuevo Registro";
            this.frm.find("#ddlItemEspHalladasEspecies").attr("disabled", false);
        } else {
            if (RegEstado == 0) {
                PDivTitulo = "Modificando Registro";
                this.tr = $(obj).closest('tr');
                var row = this.dt.row(this.tr).data();

                this.frm.find("#ddlItemEspHalladasEspecies").val(row.COD_ESPECIES).trigger("change");
                this.frm.find("#txtItemEspHalladasNumTrozas").val(row.NUM_TROZAS);
                this.frm.find("#txtItemEspHalladasVolumen").val(row.VOLUMEN);
                this.frm.find("#txtItemEspHalladasCoordenada_Este").val(row.COORDENADA_ESTE);
                this.frm.find("#txtItemEspHalladasCoordenada_Norte").val(row.COORDENADA_NORTE);
                this.frm.find("#txtItemEspHalladasObservacion").val(row.OBSERVACION);
                this.frm.find("#ddlItemEspHalladasEspecies").attr("disabled", true);
            }
        }

        this.divModal.find(".spTitulo").html(PDivTitulo);
        this.regEstado = RegEstado;
        utilSigo.modalDraggable(this.divModal, '.modal-header');
        this.divModal.modal({ keyboard: true, backdrop: 'static' });


    }
    this.cleanModal = function () {
        this.frm[0].reset();
        this.frm.find("#ddlItemEspHalladasEspecies").val("-").trigger("change");
    }

    this.closeModal = function () {
        this.cleanModal();
        //limpiando estilos si lo tienen
        $(':input', this.frm)
            .removeClass('border-danger')
            .removeAttr('data-toggle')
            .removeAttr('data-placement')
            .removeAttr('data-original-title');

        $('.select2-hidden-accessible', this.frm)
        .parents(".form-group")
        .removeClass('has-error')
        .removeAttr('data-toggle')
        .removeAttr('data-placement')
        .removeAttr('data-original-title');
        this.divModal.modal('hide');
    }
    this.validaSaveModal = function () {
        return true;
    }
    this.saveModal = function () {
        if (this.frm.valid()) {
            if (this.validaSaveModal()) {

                if (this.regEstado == 1) {

                    var fila = {
                        COD_SECUENCIAL: 0,
                        COD_ESPECIES: this.frm.find("#ddlItemEspHalladasEspecies").val(),
                        NUM_TROZAS: this.frm.find("#txtItemEspHalladasNumTrozas").val().trim(),
                        VOLUMEN: this.frm.find("#txtItemEspHalladasVolumen").val().trim(),
                        COORDENADA_ESTE: this.frm.find("#txtItemEspHalladasCoordenada_Este").val().trim(),
                        COORDENADA_NORTE: this.frm.find("#txtItemEspHalladasCoordenada_Norte").val().trim(),
                        OBSERVACION: this.frm.find("#txtItemEspHalladasObservacion").val().trim(),
                        ESPECIES: this.frm.find("#ddlItemEspHalladasEspecies").select2('data')[0].text,
                        RegEstado: 1
                    };

                    this.dt.row.add(fila).draw();
                    this.dt.page('last').draw('page');
                    utilSigo.toastSuccess("Exito", "Se Adiciono con exito");
                }
                else {

                    var row = this.dt.row(this.tr).data();


                    row.NUM_TROZAS = this.frm.find("#txtItemEspHalladasNumTrozas").val().trim();
                    row.VOLUMEN = this.frm.find("#txtItemEspHalladasVolumen").val().trim();
                    row.COORDENADA_ESTE = this.frm.find("#txtItemEspHalladasCoordenada_Este").val().trim();
                    row.COORDENADA_NORTE = this.frm.find("#txtItemEspHalladasCoordenada_Norte").val().trim();
                    row.OBSERVACION = this.frm.find("#txtItemEspHalladasObservacion").val().trim();

                    if (row.RegEstado == 0)
                        row.RegEstado = 2;

                    this.dt.row(this.tr).data(row).draw(false);

                    utilSigo.toastSuccess("Exito", "Se modifico con exito");
                    this.closeModal();
                }
            }
        }
    }
    this.configValidateForm = function () {
        jQuery.validator.addMethod("invalidFrmHalladas", function (value, element) {
            switch ($(element).attr('id')) {
                case 'ddlItemEspHalladasEspecies':
                    return (value == '-') ? false : true;
                    break;
            }
        });

        var objValida = {
            rules: {
                ddlItemEspHalladasEspecies: { invalidFrmHalladas: true }
            },
            messages: {
                ddlItemEspHalladasEspecies: { invalidFrmHalladas: "Debe seleccionar una especie" }
            }
        };
        this.frm.validate(utilSigo.fnValidate(objValida));

        //Para cuando cambia el combo para select2
        this.frm.find("select.select2-hidden-accessible").change(function () {
            if (!$.isEmptyObject(this.frm.validate().submitted) && this.divModal.is(":visible")) {
                this.frm.validate().form();
            }
        }.bind(this));

    }
    this.delete = function (obj) {
        utilSigo.dialogConfirm("Confirmacion", "¿Está seguro de Eliminar el Registro Seleccionado?",function (r) {
                if (r) {
                    var $tr = $(obj).closest('tr');
                    var row = ItemEspHalladas.dt.row($tr).data();
                
                    if (row.RegEstado == 0 || row.RegEstado == 2) {
                        ManDM.ListEliTABLA.push({
                            EliTABLA: "DEV_MAD_DET_ESP_HALLADAS",
                            EliVALOR01: row.COD_ESPECIES,
                            EliVALOR02: row.COD_SECUENCIAL
                        });
                    }
                    ItemEspHalladas.dt.row($tr).remove().draw(false);
                    utilDt.enumColumn(ItemEspHalladas.dt, "NRO");

                }
            });
    }
    this.deleteAll = function () {

        var $trsEliminar = ItemEspHalladas.dt.$("tr");
        if ($trsEliminar.length > 0) {
            utilSigo.dialogConfirm("", "Está seguro de Eliminar Todo los Registros?", function (r) {
                if (r) {

                    ItemEspHalladas.dt.rows().every(function (rowIdx, tableLoop, rowLoop) {
                        var row = this.data();
                        if (row.RegEstado == 0 || row.RegEstado == 2) {
                            ManDM.ListEliTABLA.push({
                                EliTABLA: "DEV_MAD_DET_ESP_HALLADAS",
                                EliVALOR01: row.COD_ESPECIES,
                                EliVALOR02: row.COD_SECUENCIAL
                            });
                        }
                    });
                    ItemEspHalladas.dt.clear().draw();
                }
            });
        }
        else {
            utilSigo.toastWarning("Aviso", "No hay Registros a Eliminar");
        }
    }
    this.getListDt = function () {
        var list = [];
        this.dt.rows().every(function (rowIdx, tableLoop, rowLoop) {
            var row = this.data();
            if (row.RegEstado == 1 || row.RegEstado == 2) {
                list.push({
                    ESPECIES: row.ESPECIES,
                    NUM_TROZAS: row.NUM_TROZAS,
                    VOLUMEN: row.VOLUMEN,
                    COORDENADA_ESTE: row.COORDENADA_ESTE,
                    COORDENADA_NORTE: row.COORDENADA_NORTE,
                    OBSERVACION: row.OBSERVACION,
                    COD_SECUENCIAL: row.COD_SECUENCIAL,
                    COD_ESPECIES: row.COD_ESPECIES,
                    RegEstado: row.RegEstado
                });
            }

        });
        return list;
    }
    this.validaImportarExcel = function (e, objeto) {
        return true;
    }
    this.importarExcel = function (e, objeto) {
        var ruta = ManDM.controller + "/ImportarDataExcel";
        uploadFile.fileSelectHandler(e, objeto, ruta, { TVentana: this.tipoVentana }, this.successImpExcel);
    }
    this.successImpExcel = function (data) {
        ItemEspHalladas.dt.rows.add(data).draw();
        ItemEspHalladas.dt.page('last').draw('page');
    }

}).apply(ItemEspHalladas);

//ItemBExtMaderable
var ItemBExtMaderable = {};
(function () {
    this.dt;
    this.tipoVentana = "BEMADE";
    this.divModal;
    this.tr;
    this.frm;
    this.RegEstado;
    this.init = function () {

        this.dt = ManDM.frm.find("#grvItemBExtMaderable").DataTable({
            bServerSide: false,
            bProcessing: true,
            bJQueryUI: false,
            bRetrieve: true,
            bFilter: false,
            aaSorting: [],
            bPaginate: true,
            scrollX: true,
            bLengthChange: false,
            scrollCollapse: true,
            pageLength: initSigo.pageLength,
            oLanguage: initSigo.oLanguage,
            drawCallback: initSigo.showPagination,
            columns: [
                { bSortable: false, mRender: ItemBExtMaderable.cellEdit },
                { bSortable: false, mRender: ItemBExtMaderable.cellDel },
                { name: "NRO", bSortable: true, mRender: utilDt.countRowDT, width: "5%" },
                { data: "ESPECIES", width: "40%" },
                { data: "VOLUMEN_AUTORIZADO", width: "10%" },
                { data: "VOLUMEN_MOVILIZADO", width: "10%" },
                { data: "SALDO", width: "10%" },
                { data: "OBSERVACION", width: "25%" },
                { data: "COD_SECUENCIAL", visible: false },
                { data: "COD_ESPECIES", visible: false },
                { data: "RegEstado", visible: false }
            ]
        });
    }
    this.cellDel = function (data, type, row) {
        return '<i class="cellDel fa fa-lg fa-window-close" title="Eliminar" onclick="ItemBExtMaderable.delete(this);"></i>';
    }
    this.cellEdit = function (data, type, row) {
        return '<i class="cellEdit fa fa-lg fa-pencil-square-o" title="Editar" onclick="ItemBExtMaderable.showModal(2,this);"></i>';

    }
    this.configValidateForm = function () {
        jQuery.validator.addMethod("invalidFrmExtraccion", function (value, element) {
            switch ($(element).attr('id')) {
                case 'ddlItemBExtMaderableEspecies':
                    return (value == '-') ? false : true;
                    break;
            }
        });

        var objValida = {
            rules: {
                ddlItemBExtMaderableEspecies: { invalidFrmExtraccion: true }
            },
            messages: {
                ddlItemBExtMaderableEspecies: { invalidFrmExtraccion: "Debe seleccionar una especie" }
            }
        };
        this.frm.validate(utilSigo.fnValidate(objValida));

        //Para cuando cambia el combo para select2
 
        this.frm.find("select.select2-hidden-accessible").change(function () {
            if (!$.isEmptyObject(this.frm.validate().submitted) && this.divModal.is(":visible")) {
                this.frm.validate().form();
            }
        }.bind(this));

    }
    this.showModal = function (RegEstado, obj) {

        if (this.divModal == undefined || this.frm == undefined) {
            this.divModal = $("#PDivItemBExtMaderable");
            this.frm = $("#frmBExtMaderable");
            this.frm.find('#ddlItemBExtMaderableEspecies').select2();
            this.configValidateForm();
        }

        var PDivTitulo = '';
        if (RegEstado == RegEstadoSigo.NEW) {
            PDivTitulo = "Nuevo Registro";
            this.frm.find("#ddlItemBExtMaderableEspecies").attr("disabled", false);
        } else {
            if (RegEstado == RegEstadoSigo.UPDATE) {
                PDivTitulo = "Modificando Registro";
                this.tr = $(obj).closest('tr');
                var row = this.dt.row(this.tr).data();

                this.frm.find("#ddlItemBExtMaderableEspecies").val(row.COD_ESPECIES).trigger("change");
                this.frm.find("#txtItemBExtMaderableVolumen_Autorizado").val(row.VOLUMEN_AUTORIZADO);
                this.frm.find("#txtItemBExtMaderableVolumen_Movilizado").val(row.VOLUMEN_MOVILIZADO);
                this.frm.find("#txtItemBExtMaderableSaldo").val(row.SALDO);
                this.frm.find("#txtItemBExtMaderableObservacion").val(row.OBSERVACION);
                this.frm.find("#ddlItemBExtMaderableEspecies").attr("disabled", true);
            }
        }
        this.divModal.find(".spTitulo").html(PDivTitulo);
        this.RegEstado = RegEstado;
        utilSigo.modalDraggable(this.divModal, '.modal-header');
        this.divModal.modal({ keyboard: true, backdrop: 'static' });


    }
    this.cleanModal = function () {
        this.frm[0].reset();
        this.frm.find("#ddlItemBExtMaderableEspecies").val("-").trigger("change");
    }

    this.closeModal = function () {
        this.cleanModal();
        //limpiando estilos si lo tienen
        $(':input', this.frm)
            .removeClass('border-danger')
            .removeAttr('data-toggle')
            .removeAttr('data-placement')
            .removeAttr('data-original-title');

        $('.select2-hidden-accessible', this.frm)
            .parents(".form-group")
            .removeClass('has-error')
            .removeAttr('data-toggle')
            .removeAttr('data-placement')
            .removeAttr('data-original-title');
        this.divModal.modal('hide');
    }
    this.validaSaveModal = function () {
        return true;
    }
    this.saveModal = function () {

        if (this.frm.valid()) {
            if (this.validaSaveModal()) {
                if (this.RegEstado == RegEstadoSigo.NEW) {
                    var fila = {
                        COD_SECUENCIAL: 0,
                        COD_ESPECIES: this.frm.find("#ddlItemBExtMaderableEspecies").val(),
                        VOLUMEN_AUTORIZADO: this.frm.find("#txtItemBExtMaderableVolumen_Autorizado").val().trim(),
                        VOLUMEN_MOVILIZADO: this.frm.find("#txtItemBExtMaderableVolumen_Movilizado").val().trim(),
                        SALDO: this.frm.find("#txtItemBExtMaderableSaldo").val().trim(),
                        OBSERVACION: this.frm.find("#txtItemBExtMaderableObservacion").val().trim(),
                        ESPECIES: this.frm.find("#ddlItemBExtMaderableEspecies").select2('data')[0].text,
                        RegEstado: RegEstadoSigo.NEW
                    };
                    this.dt.row.add(fila).draw();
                    this.dt.page('last').draw('page');
                    utilSigo.toastSuccess("Exito", "Se Adiciono con exito");
                }
                else {
                    var row = this.dt.row(this.tr).data();
                    row.VOLUMEN_AUTORIZADO = this.frm.find("#txtItemBExtMaderableVolumen_Autorizado").val().trim();
                    row.VOLUMEN_MOVILIZADO = this.frm.find("#txtItemBExtMaderableVolumen_Movilizado").val().trim();
                    row.SALDO = this.frm.find("#txtItemBExtMaderableSaldo").val().trim();
                    row.OBSERVACION = this.frm.find("#txtItemBExtMaderableObservacion").val().trim();

                    if (row.RegEstado == RegEstadoSigo.INITIAL)
                        row.RegEstado = RegEstadoSigo.UPDATE;

                    this.dt.row(this.tr).data(row).draw(false);
                    utilSigo.toastSuccess("Exito", "Se modifico con exito");
                    this.closeModal();
                }
            }
        }
    }
    this.delete = function (obj) {
        utilSigo.dialogConfirm("Confirmacion", "¿Está seguro de Eliminar el Registro Seleccionado?",
            function (r) {
                if (r) {
                    var $tr = $(obj).closest('tr');
                    var row = ItemBExtMaderable.dt.row($tr).data();
                    ItemBExtMaderable.addListEliTABLA(row);
                    ItemBExtMaderable.dt.row($tr).remove().draw(false);
                    utilDt.enumColumn(ItemBExtMaderable.dt, "NRO");
                }
            });
    }
    this.deleteAll = function () {

        var $trsEliminar = ItemBExtMaderable.dt.$("tr");
        if ($trsEliminar.length > 0) {
            utilSigo.dialogConfirm("Confirmacion", "Está seguro de Eliminar Todo los Registros?", function (r) {
                if (r) {
                    ItemBExtMaderable.dt.rows().every(function (rowIdx, tableLoop, rowLoop) {
                        var row = this.data();
                        ItemBExtMaderable.addListEliTABLA(row);
                    });
                    ItemBExtMaderable.dt.clear().draw();
                }
            });
        }
        else {
            utilSigo.toastWarning("Aviso", "No hay Registros a Eliminar");
        }
    }
    this.addListEliTABLA = function (row) {
        if (row.RegEstado == RegEstadoSigo.INITIAL || row.RegEstado == RegEstadoSigo.UPDATE) {
            ManDM.ListEliTABLA.push({
                EliTABLA: "DEV_MAD_DET_BEXTRACCION",
                EliVALOR01: row.COD_ESPECIES,
                EliVALOR02: row.COD_SECUENCIAL
            });
        }
    }
    this.getListDt = function () {
        var list = [];
        this.dt.rows().every(function (rowIdx, tableLoop, rowLoop) {
            var row = this.data();
            if (row.RegEstado == RegEstadoSigo.NEW || row.RegEstado == RegEstadoSigo.UPDATE) {
                list.push(row);
            }
        });
        return list;
    }
    this.validaImportarExcel = function (e, objeto) {
        return true;
    }
    this.importarExcel = function (e, objeto) {
        var ruta = ManDM.controller + "/ImportarDataExcel";
        uploadFile.fileSelectHandler(e, objeto, ruta, { TVentana: this.tipoVentana }, this.successImpExcel);
    }
    this.successImpExcel = function (data) {
        ItemBExtMaderable.dt.rows.add(data).draw();
        ItemBExtMaderable.dt.page('last').draw('page');
    }

}).apply(ItemBExtMaderable);

//ItemVertice
var ItemVertice = {};
(function () {
    this.dt;
    this.tipoVentana = "VERTICE";
    this.divModal;
    this.tr;
    this.frm;
    this.RegEstado;
    this.init = function () {

        this.dt = ManDM.frm.find("#grvItemVertice").DataTable({
            bServerSide: false,
            bProcessing: true,
            bJQueryUI: false,
            bRetrieve: true,
            bFilter: false,
            aaSorting: [],
            bPaginate: true,
            bLengthChange: false,
            scrollCollapse: true, 
            pageLength: initSigo.pageLength,
            oLanguage: initSigo.oLanguage,
            drawCallback: initSigo.showPagination,
            columns: [
                { bSortable: false, mRender: this.cellEdit },
                { bSortable: false, mRender: this.cellDel },
                { name: "NRO", bSortable: true, mRender: utilDt.countRowDT, width: "5%" },
                { data: "VERTICE", width: "15%" },
                { data: "COORDENADA_ESTE", width: "20%" },
                { data: "COORDENADA_NORTE", width: "20%" },
                { data: "OBSERVACION", width: "40%" },
                { data: "COD_SECUENCIAL", visible: false },
                { data: "RegEstado", visible: false }
            ]
        });
    }
    this.cellDel = function (data, type, row) {
        return '<i class="cellDel fa fa-lg fa-window-close" title="Eliminar" onclick="ItemVertice.delete(this);"></i>';
    }
    this.cellEdit = function (data, type, row) {
        return '<i class="cellEdit fa fa-lg fa-pencil-square-o" title="Editar" onclick="ItemVertice.showModal(2,this);"></i>';

    }
    this.configValidateForm = function () {  

        var objValida = {
          
        };
        this.frm.validate(utilSigo.fnValidate(objValida));

    

    }
    this.showModal = function (RegEstado, obj) {

        if (this.divModal == undefined) {
            this.divModal = $("#PDivItemVertice");
            this.frm = $("#frmVertice");
            this.configValidateForm();
        }

        var PDivTitulo = '';
        if (RegEstado == RegEstadoSigo.NEW) {
            PDivTitulo = "Nuevo Registro";

        } else {
            if (RegEstado == RegEstadoSigo.UPDATE) {
                PDivTitulo = "Modificando Registro";
                this.tr = $(obj).closest('tr');
                var row = this.dt.row(this.tr).data();
                this.frm.find("#txtItemVert_Vertice").val(row.VERTICE);
                this.frm.find("#txtItemVert_CEste").val(row.COORDENADA_ESTE);
                this.frm.find("#txtItemVert_CNorte").val(row.COORDENADA_NORTE);
                this.frm.find("#txtItemVert_Observacion").val(row.OBSERVACION);

            }
        }
        this.RegEstado = RegEstado;
        this.divModal.find(".spTitulo").html(PDivTitulo);
        utilSigo.modalDraggable(this.divModal, '.modal-header');
        this.divModal.modal({ keyboard: true, backdrop: 'static' });


    }
    this.cleanModal = function () {
        this.frm[0].reset();
    }

    this.closeModal = function () {
        this.cleanModal();
        //limpiando estilos si lo tienen
        $(':input', this.frm)
            .removeClass('border-danger')
            .removeAttr('data-toggle')
            .removeAttr('data-placement')
            .removeAttr('data-original-title');

        this.divModal.modal('hide');
    }
    this.validaSaveModal = function () {     
        return true;
    }
    this.saveModal = function () {
        if (this.frm.valid()) {
            if (this.validaSaveModal()) {

                if (this.RegEstado == RegEstadoSigo.NEW) {

                    var fila = {
                        COD_SECUENCIAL: 0,
                        VERTICE: this.frm.find("#txtItemVert_Vertice").val().trim(),
                        COORDENADA_ESTE: this.frm.find("#txtItemVert_CEste").val().trim(),
                        COORDENADA_NORTE: this.frm.find("#txtItemVert_CNorte").val().trim(),
                        OBSERVACION: this.frm.find("#txtItemVert_Observacion").val().trim(),
                        RegEstado: RegEstadoSigo.NEW
                    };
                    this.dt.row.add(fila).draw();
                    this.dt.page('last').draw('page');
                    utilSigo.toastSuccess("Exito", "Se Adiciono con exito");
                }
                else {
                    var row = this.dt.row(this.tr).data();
                    row.VERTICE = this.frm.find("#txtItemVert_Vertice").val().trim();
                    row.COORDENADA_ESTE = this.frm.find("#txtItemVert_CEste").val().trim();
                    row.COORDENADA_NORTE = this.frm.find("#txtItemVert_CNorte").val().trim();
                    row.OBSERVACION = this.frm.find("#txtItemVert_Observacion").val().trim();

                    if (row.RegEstado == RegEstadoSigo.INITIAL)
                        row.RegEstado = RegEstadoSigo.UPDATE;

                    this.dt.row(this.tr).data(row).draw(false);
                    utilSigo.toastSuccess("Exito", "Se modifico con exito");
                    this.closeModal();
                }
            }
        }
    }
    this.delete = function (obj) {
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
    this.deleteAll = function () {
        var objItem = this;
        var $trsEliminar = objItem.dt.$("tr");
        if ($trsEliminar.length > 0) {
            utilSigo.dialogConfirm("Confirmacion", "Está seguro de Eliminar Todo los Registros?", function (r) {
                if (r) {
                    objItem.dt.rows().every(function (rowIdx, tableLoop, rowLoop) {
                        var row = this.data();
                        objItem.addListEliTABLA(row);
                    });
                    objItem.dt.clear().draw();
                }
            });
        }
        else {
            utilSigo.toastWarning("Aviso", "No hay Registros a Eliminar");
        }
    }
    this.addListEliTABLA = function (row) {
        if (row.RegEstado == RegEstadoSigo.INITIAL || row.RegEstado == RegEstadoSigo.UPDATE) {
            ManDM.ListEliTABLA.push({
                EliTABLA: "DEV_MAD_DET_VERTICE",
                EliVALOR01: row.VERTICE,
                EliVALOR02: row.COD_SECUENCIAL
            });
        }
    }
    this.getListDt = function () {
        var list = [];
        this.dt.rows().every(function (rowIdx, tableLoop, rowLoop) {
            var row = this.data();
            if (row.RegEstado == RegEstadoSigo.NEW || row.RegEstado == RegEstadoSigo.UPDATE) {
                list.push(row);
            }
        });
        return list;
    }
    this.validaImportarExcel = function (e, objeto) {
        return true;
    }
    this.importarExcel = function (e, objeto) {
        var ruta = ManDM.controller + "/ImportarDataExcel";
        uploadFile.fileSelectHandler(e, objeto, ruta, { TVentana: this.tipoVentana }, this.successImpExcel);
    }
    this.successImpExcel = function (data) {
        ItemVertice.dt.rows.add(data).draw();
        ItemVertice.dt.page('last').draw('page');
    }

}).apply(ItemVertice);


//ItemCTroza
var ItemCTroza = {};
(function () {
    this.dt;
    this.tipoVentana = "CTROZA";
    this.divModal;
    this.tr;
    this.frm;
    this.RegEstado;
    this.init = function () {

        this.dt = ManDM.frm.find("#grvItemCTroza").DataTable({
            bServerSide: false,
            ajax: { url: ManDM.controller + "/GetAllCTroza", "type": "GET", "datatype": "json" },
            bProcessing: true,
            bJQueryUI: false,
            bRetrieve: true,
            bFilter: false,
            aaSorting: [],
            bPaginate: true,
            bLengthChange: false,
            scrollCollapse: true,
            deferRender: true,     
            pageLength: initSigo.pageLength,
            oLanguage: initSigo.oLanguage,
            drawCallback: initSigo.showPagination,
            columns: [
                { bSortable: false, mRender: ItemCTroza.cellEdit },
                { bSortable: false, mRender: ItemCTroza.cellDel },
                { name: "NRO", bSortable: true, mRender: utilDt.countRowDT },
                { data: "ESPECIES" },
                { data: "CODIGO" },
                { data: "DAP" },
                { data: "ALTURA" },
                { data: "VOLUMEN" },
                { data: "COORDENADA_ESTE" },
                { data: "COORDENADA_NORTE" },
                { data: "NUM_TROZAS" },
                { data: "DESCRIPCION" },
                { data: "OBSERVACION" },
                { data: "COD_SECUENCIAL", visible: false },
                { data: "COD_ESPECIES", visible: false },
                { data: "RegEstado", visible: false }
            ]
        });
    }
    this.cellDel = function (data, type, row) {
        return '<i class="cellDel fa fa-lg fa-window-close" title="Eliminar" onclick="ItemCTroza.delete(this);"></i>';
    }
    this.cellEdit = function (data, type, row) {
        return '<i class="cellEdit fa fa-lg fa-pencil-square-o" title="Editar" onclick="ItemCTroza.showModal(2,this);"></i>';

    }

    this.showModal = function (RegEstado, obj) {

        if (this.divModal == undefined || this.frm == undefined) {
            this.divModal = $("#PDivItemCTroza");
            this.frm = $("#frmCTroza");
            this.frm.find('#ddlItemCTrozaEspecies').select2();
            this.configValidateForm();
        }

        var PDivTitulo = '';
        if (RegEstado == RegEstadoSigo.NEW) {
            PDivTitulo = "Nuevo Registro";
            this.frm.find("#ddlItemCTrozaEspecies").attr("disabled", false);
        } else {
            if (RegEstado == RegEstadoSigo.UPDATE) {
                PDivTitulo = "Modificando Registro";
                this.tr = $(obj).closest('tr');
                var row = this.dt.row(this.tr).data();

                this.frm.find("#ddlItemCTrozaEspecies").val(row.COD_ESPECIES).trigger("change");
                this.frm.find("#txtItemCTrozaCodigo").val(row.CODIGO);
                this.frm.find("#txtItemCTrozaDAP").val(row.DAP);
                this.frm.find("#txtItemCTrozaAltura").val(row.ALTURA);
                this.frm.find("#txtItemCTrozaVolumen").val(row.VOLUMEN);
                this.frm.find("#txtItemCTrozaCoordenada_Este").val(row.COORDENADA_ESTE);
                this.frm.find("#txtItemCTrozaCoordenada_Norte").val(row.COORDENADA_NORTE);
                this.frm.find("#txtItemCTrozaNum_Trozas").val(row.NUM_TROZAS);
                this.frm.find("#txtItemCTrozaDescripcion").val(row.DESCRIPCION);
                this.frm.find("#txtItemCTrozaObservacion").val(row.OBSERVACION);
                this.frm.find("#ddlItemCTrozaEspecies").attr("disabled", true);
            }
        }
        this.divModal.find(".spTitulo").html(PDivTitulo);
        this.RegEstado = RegEstado;
        utilSigo.modalDraggable(this.divModal, '.modal-header');
        this.divModal.modal({ keyboard: true, backdrop: 'static' });


    }
    this.cleanModal = function () {
        this.frm[0].reset();
        this.frm.find("#ddlItemCTrozaEspecies").val("-").trigger("change");
    }

    this.closeModal = function () {
        this.cleanModal();
        //limpiando estilos si lo tienen
        $(':input', this.frm)
            .removeClass('border-danger')
            .removeAttr('data-toggle')
            .removeAttr('data-placement')
            .removeAttr('data-original-title');
        $('.select2-hidden-accessible', this.frm)
       .parents(".form-group")
       .removeClass('has-error')
       .removeAttr('data-toggle')
       .removeAttr('data-placement')
       .removeAttr('data-original-title');
        this.divModal.modal('hide');
    }
    this.validaSaveModal = function () {
 
        return true;
    }
    this.configValidateForm = function () {
        jQuery.validator.addMethod("invalidFrmCTroza", function (value, element) {
            switch ($(element).attr('id')) {
                case 'ddlItemCTrozaEspecies':
                    return (value == '-') ? false : true;
                    break;
            }
        });

        var objValida = {
            rules: {
                ddlItemCTrozaEspecies: { invalidFrmCTroza: true }
            },
            messages: {
                ddlItemCTrozaEspecies: { invalidFrmCTroza: "Debe seleccionar una especie" }
            }
        };
        this.frm.validate(utilSigo.fnValidate(objValida));

        //Para cuando cambia el combo para select2
        this.frm.find("select.select2-hidden-accessible").change(function () {
            if (!$.isEmptyObject(this.frm.validate().submitted) && this.divModal.is(":visible")) {
                this.frm.validate().form();
            }
        }.bind(this));

    }
    this.saveModal = function () {
        if (this.frm.valid()) {
            if (this.validaSaveModal()) {
                if (this.RegEstado == RegEstadoSigo.NEW) {
                    var fila = {
                        COD_SECUENCIAL: 0,
                        COD_ESPECIES: this.frm.find("#ddlItemCTrozaEspecies").val(),
                        CODIGO: this.frm.find("#txtItemCTrozaCodigo").val().trim(),
                        DAP: this.frm.find("#txtItemCTrozaDAP").val().trim(),
                        ALTURA: this.frm.find("#txtItemCTrozaAltura").val().trim(),
                        VOLUMEN: this.frm.find("#txtItemCTrozaVolumen").val().trim(),
                        NUM_TROZAS: this.frm.find("#txtItemCTrozaNum_Trozas").val().trim(),
                        COORDENADA_ESTE: this.frm.find("#txtItemCTrozaCoordenada_Este").val().trim(),
                        COORDENADA_NORTE: this.frm.find("#txtItemCTrozaCoordenada_Norte").val().trim(),
                        DESCRIPCION: this.frm.find("#txtItemCTrozaDescripcion").val().trim(),
                        OBSERVACION: this.frm.find("#txtItemCTrozaObservacion").val().trim(),
                        ESPECIES: this.frm.find("#ddlItemCTrozaEspecies").select2('data')[0].text,
                        RegEstado: RegEstadoSigo.NEW
                    };
                    this.dt.row.add(fila).draw();
                    this.dt.page('last').draw('page');
                    utilSigo.toastSuccess("Exito", "Se Adiciono con exito");
                }
                else {
                    var row = this.dt.row(this.tr).data();
                    row.CODIGO = this.frm.find("#txtItemCTrozaCodigo").val().trim();
                    row.DAP = this.frm.find("#txtItemCTrozaDAP").val().trim();
                    row.ALTURA = this.frm.find("#txtItemCTrozaAltura").val().trim();
                    row.VOLUMEN = this.frm.find("#txtItemCTrozaVolumen").val().trim();
                    row.NUM_TROZAS = this.frm.find("#txtItemCTrozaNum_Trozas").val().trim();
                    row.COORDENADA_ESTE = this.frm.find("#txtItemCTrozaCoordenada_Este").val().trim();
                    row.COORDENADA_NORTE = this.frm.find("#txtItemCTrozaCoordenada_Norte").val().trim();
                    row.DESCRIPCION = this.frm.find("#txtItemCTrozaDescripcion").val().trim();
                    row.OBSERVACION = this.frm.find("#txtItemCTrozaObservacion").val().trim();

                    if (row.RegEstado == RegEstadoSigo.INITIAL)
                        row.RegEstado = RegEstadoSigo.UPDATE;

                    this.dt.row(this.tr).data(row).draw(false);
                    utilSigo.toastSuccess("Exito", "Se modifico con exito");
                    this.closeModal();
                }
            }
        }
    }
    this.delete = function (obj) {
        utilSigo.dialogConfirm("Confirmacion", "¿Está seguro de Eliminar el Registro Seleccionado?",
            function (r) {
                if (r) {
                    var $tr = $(obj).closest('tr');
                    var row = ItemCTroza.dt.row($tr).data();
                    ItemCTroza.addListEliTABLA(row);
                    ItemCTroza.dt.row($tr).remove().draw(false);
                    utilDt.enumColumn(ItemCTroza.dt, "NRO");
                }
            });
    }
    this.deleteAll = function () {

        var $trsEliminar = ItemCTroza.dt.$("tr");
        if ($trsEliminar.length > 0) {
            utilSigo.dialogConfirm("Confirmacion", "Está seguro de Eliminar Todo los Registros?", function (r) {
                if (r) {
                    ItemCTroza.dt.rows().every(function (rowIdx, tableLoop, rowLoop) {
                        var row = this.data();
                        ItemCTroza.addListEliTABLA(row);
                    });
                    ItemCTroza.dt.clear().draw();
                }
            });
        }
        else {
            utilSigo.toastWarning("Aviso", "No hay Registros a Eliminar");
        }
    }
    this.addListEliTABLA = function (row) {
        if (row.RegEstado == RegEstadoSigo.INITIAL || row.RegEstado == RegEstadoSigo.UPDATE) {
            ManDM.ListEliTABLA.push({
                EliTABLA: "DEV_MAD_DET_CENSO_TROZA",
                EliVALOR01: row.COD_ESPECIES,
                EliVALOR02: row.COD_SECUENCIAL
            });
        }
    }
    this.getListDt = function () {
        var list = [];
        this.dt.rows().every(function (rowIdx, tableLoop, rowLoop) {
            var row = this.data();
            if (row.RegEstado == RegEstadoSigo.NEW ||
                row.RegEstado == RegEstadoSigo.UPDATE) {
                list.push(row);
            }
        });
        return list;
    }
    this.validaImportarExcel = function (e, objeto) {
        return true;
    }
    this.importarExcel = function (e, objeto) {
        var ruta = ManDM.controller + "/ImportarDataExcel";
        uploadFile.fileSelectHandler(e, objeto, ruta, { TVentana: this.tipoVentana }, this.successImpExcel);
    }
    this.successImpExcel = function (data) {
        ItemCTroza.dt.rows.add(data).draw();
        ItemCTroza.dt.page('last').draw('page');
    }

    this.tabsActive = function () {
        $("#navDatosTab").hide();
        $("#divTitle").hide();
        $("#navDevolCensoTrozaTab").show();
        $('.nav-tabs a[href="#navDevolCensoTroza"]').tab('show');
    }
    this.tabsInactive = function () {
        $("#divTitle").show();
        $("#navDatosTab").show();
        $("#navDevolCensoTrozaTab").hide();

        ManDM.frm.find("#lbtMaderableItemCensoTrozaSelec").html("Total de Trozas ( " + ItemCTroza.dt.data().count() + " )");
        $('.nav-tabs a[href="#navDatos"]').tab('show');
    }

}).apply(ItemCTroza);

//ItemCTocon
var ItemCTocon = {};
(function () {
    this.dt;
    this.tipoVentana = "CTOCON";
    this.divModal;
    this.tr;
    this.frm;
    this.RegEstado;
    this.init = function () {

        this.dt = ManDM.frm.find("#grvItemCTocon").DataTable({
            bServerSide: false,
            ajax: { url: ManDM.controller + "/GetAllCTocon", "type": "GET", "datatype": "json" },
            bProcessing: true,
            bJQueryUI: false,
            bRetrieve: true,
            bFilter: false,
            aaSorting: [],
            bPaginate: true,
            bLengthChange: false,
            scrollCollapse: true,
            deferRender: true, 
            pageLength: initSigo.pageLength,
            oLanguage: initSigo.oLanguage,
            drawCallback: initSigo.showPagination,
            columns: [
                { bSortable: false, mRender: ItemCTocon.cellEdit },
                { bSortable: false, mRender: ItemCTocon.cellDel },
                { name: "NRO", bSortable: true, mRender: utilDt.countRowDT },
                { data: "ESPECIES" },
                { data: "CODIGO" },
                { data: "DIAMETRO" },
                { data: "LARGO" },
                { data: "VOLUMEN" },
                { data: "COORDENADA_ESTE" },
                { data: "COORDENADA_NORTE" },
                { data: "CANTIDAD" },
                { data: "DESCRIPCION" },
                { data: "OBSERVACION" },
                { data: "COD_SECUENCIAL", visible: false },
                { data: "COD_ESPECIES", visible: false },
                { data: "RegEstado", visible: false }
            ]
        });
    }
    this.cellDel = function (data, type, row) {
        return '<i class="cellDel fa fa-lg fa-window-close" title="Eliminar" onclick="ItemCTocon.delete(this);"></i>';
    }
    this.cellEdit = function (data, type, row) {
        return '<i class="cellEdit fa fa-lg fa-pencil-square-o" title="Editar" onclick="ItemCTocon.showModal(2,this);"></i>';

    }

    this.showModal = function (RegEstado, obj) {

        if (this.divModal == undefined || this.frm == undefined) {
            this.divModal = $("#PDivItemCTocon");
            this.frm = $("#frmCTocon");
            this.frm.find('#ddlItemCToconEspecies').select2();
            this.configValidateForm();
        }

        var PDivTitulo = '';
        if (RegEstado == RegEstadoSigo.NEW) {
            PDivTitulo = "Nuevo Registro";
            this.frm.find("#ddlItemCToconEspecies").attr("disabled", false);
        } else {
            if (RegEstado == RegEstadoSigo.UPDATE) {
                PDivTitulo = "Modificando Registro";
                this.tr = $(obj).closest('tr');
                var row = this.dt.row(this.tr).data();

                this.frm.find("#ddlItemCToconEspecies").val(row.COD_ESPECIES).trigger("change");
                this.frm.find("#txtItemCToconCodigo").val(row.CODIGO);
                this.frm.find("#txtItemCToconDiametro").val(row.DIAMETRO);
                this.frm.find("#txtItemCToconLargo").val(row.LARGO);
                this.frm.find("#txtItemCToconVolumen").val(row.VOLUMEN);
                this.frm.find("#txtItemCToconCoordenada_Este").val(row.COORDENADA_ESTE);
                this.frm.find("#txtItemCToconCoordenada_Norte").val(row.COORDENADA_NORTE);
                this.frm.find("#txtItemCToconCantidad").val(row.CANTIDAD);
                this.frm.find("#txtItemCToconDescripcion").val(row.DESCRIPCION);
                this.frm.find("#txtItemCToconObservacion").val(row.OBSERVACION);
                this.frm.find("#ddlItemCToconEspecies").attr("disabled", true);
            }
        }
        this.divModal.find(".spTitulo").html(PDivTitulo);
        this.RegEstado = RegEstado;
        utilSigo.modalDraggable(this.divModal, '.modal-header');
        this.divModal.modal({ keyboard: true, backdrop: 'static' });


    }
    this.cleanModal = function () {
        this.frm[0].reset();
        this.frm.find("#ddlItemCToconEspecies").val("-").trigger("change");
    }

    this.closeModal = function () {
        this.cleanModal();
        //limpiando estilos si lo tienen
        $(':input', this.frm)
            .removeClass('border-danger')
            .removeAttr('data-toggle')
            .removeAttr('data-placement')
            .removeAttr('data-original-title');
        $('.select2-hidden-accessible', this.frm)
           .parents(".form-group")
           .removeClass('has-error')
           .removeAttr('data-toggle')
           .removeAttr('data-placement')
           .removeAttr('data-original-title');
        this.divModal.modal('hide');
    }
    this.validaSaveModal = function () {         
        return true;
    }
    this.configValidateForm = function () {
        jQuery.validator.addMethod("invalidFrmCTocon", function (value, element) {
            switch ($(element).attr('id')) {
                case 'ddlItemCToconEspecies':
                    return (value == '-') ? false : true;
                    break;
            }
        });

        var objValida = {
            rules: {
                ddlItemCToconEspecies: { invalidFrmCTocon: true }
            },
            messages: {
                ddlItemCToconEspecies: { invalidFrmCTocon: "Debe seleccionar una especie" }
            }
        };
        this.frm.validate(utilSigo.fnValidate(objValida)); 
        this.frm.find("select.select2-hidden-accessible").change(function () {
            if (!$.isEmptyObject(this.frm.validate().submitted) && this.divModal.is(":visible")) {
                this.frm.validate().form();
            }
        }.bind(this));

    }
    this.saveModal = function () {
        if (this.frm.valid()) {
            if (this.validaSaveModal()) {

                if (this.RegEstado == RegEstadoSigo.NEW) {

                    var fila = {
                        COD_SECUENCIAL: 0,
                        COD_ESPECIES: this.frm.find("#ddlItemCToconEspecies").val(),
                        CODIGO: this.frm.find("#txtItemCToconCodigo").val().trim(),
                        DIAMETRO: this.frm.find("#txtItemCToconDiametro").val().trim(),
                        LARGO: this.frm.find("#txtItemCToconLargo").val().trim(),
                        VOLUMEN: this.frm.find("#txtItemCToconVolumen").val().trim(),
                        CANTIDAD: this.frm.find("#txtItemCToconCantidad").val().trim(),
                        COORDENADA_ESTE: this.frm.find("#txtItemCToconCoordenada_Este").val().trim(),
                        COORDENADA_NORTE: this.frm.find("#txtItemCToconCoordenada_Norte").val().trim(),
                        DESCRIPCION: this.frm.find("#txtItemCToconDescripcion").val().trim(),
                        OBSERVACION: this.frm.find("#txtItemCToconObservacion").val().trim(),
                        ESPECIES: this.frm.find("#ddlItemCToconEspecies").select2('data')[0].text,
                        RegEstado: RegEstadoSigo.NEW
                    };
                    this.dt.row.add(fila).draw();
                    this.dt.page('last').draw('page');
                    utilSigo.toastSuccess("Exito", "Se Adiciono con exito");
                }
                else {
                    var row = this.dt.row(this.tr).data();
                    row.CODIGO = this.frm.find("#txtItemCToconCodigo").val().trim();
                    row.DIAMETRO = this.frm.find("#txtItemCToconDiametro").val().trim();
                    row.LARGO = this.frm.find("#txtItemCToconLargo").val().trim();
                    row.VOLUMEN = this.frm.find("#txtItemCToconVolumen").val().trim();
                    row.CANTIDAD = this.frm.find("#txtItemCToconCantidad").val().trim();
                    row.COORDENADA_ESTE = this.frm.find("#txtItemCToconCoordenada_Este").val().trim();
                    row.COORDENADA_NORTE = this.frm.find("#txtItemCToconCoordenada_Norte").val().trim();
                    row.DESCRIPCION = this.frm.find("#txtItemCToconDescripcion").val().trim();
                    row.OBSERVACION = this.frm.find("#txtItemCToconObservacion").val().trim();

                    if (row.RegEstado == RegEstadoSigo.INITIAL)
                        row.RegEstado = RegEstadoSigo.UPDATE;

                    this.dt.row(this.tr).data(row).draw(false);
                    utilSigo.toastSuccess("Exito", "Se modifico con exito");
                    this.closeModal();
                }
            }
        }
    }
    
    this.delete = function (obj) {
        utilSigo.dialogConfirm("Confirmacion", "¿Está seguro de Eliminar el Registro Seleccionado?",
            function (r) {
                if (r) {
                    var $tr = $(obj).closest('tr');
                    var row = ItemCTocon.dt.row($tr).data();
                    ItemCTocon.addListEliTABLA(row);
                    ItemCTocon.dt.row($tr).remove().draw(false);
                    utilDt.enumColumn(ItemCTocon.dt, "NRO");
                }
            });
    }
    this.deleteAll = function () {

        var $trsEliminar = ItemCTocon.dt.$("tr");
        if ($trsEliminar.length > 0) {
            utilSigo.dialogConfirm("Confirmacion", "Está seguro de Eliminar Todo los Registros?", function (r) {
                if (r) {
                    ItemCTocon.dt.rows().every(function (rowIdx, tableLoop, rowLoop) {
                        var row = this.data();
                        ItemCTocon.addListEliTABLA(row);
                    });
                    ItemCTocon.dt.clear().draw();
                }
            });
        }
        else {
            utilSigo.toastWarning("Aviso", "No hay Registros a Eliminar");
        }
    }
    this.addListEliTABLA = function (row) {
        if (row.RegEstado == RegEstadoSigo.INITIAL || row.RegEstado == RegEstadoSigo.UPDATE) {
            ManDM.ListEliTABLA.push({
                EliTABLA: "DEV_MAD_DET_CENSO_TOCON",
                EliVALOR01: row.COD_ESPECIES,
                EliVALOR02: row.COD_SECUENCIAL
            });
        }
    }
    this.getListDt = function () {
        var list = [];
        this.dt.rows().every(function (rowIdx, tableLoop, rowLoop) {
            var row = this.data();
            if (row.RegEstado == RegEstadoSigo.NEW ||
                row.RegEstado == RegEstadoSigo.UPDATE) {
                list.push(row);
            }
        });
        return list;
    }
    this.validaImportarExcel = function (e, objeto) {
        return true;
    }
    this.importarExcel = function (e, objeto) {
        var ruta = ManDM.controller + "/ImportarDataExcel";
        uploadFile.fileSelectHandler(e, objeto, ruta, { TVentana: this.tipoVentana }, this.successImpExcel);
    }
    this.successImpExcel = function (data) {
        ItemCTocon.dt.rows.add(data).draw();
        ItemCTocon.dt.page('last').draw('page');
    }

    this.tabsActive = function () {
        $("#navDatosTab").hide();
        $("#divTitle").hide();
        $("#navDevolCensoToconTab").show();
        $('.nav-tabs a[href="#navDevolCensoTocon"]').tab('show');
    }
    this.tabsInactive = function () {
        $("#divTitle").show();
        $("#navDatosTab").show();
        $("#navDevolCensoToconTab").hide();

        ManDM.frm.find("#lbtMaderableItemCensoToconSelec").html("Total de Tocones ( " + ItemCTocon.dt.data().count() + " )");
        $('.nav-tabs a[href="#navDatos"]').tab('show');
    }

}).apply(ItemCTocon);

//ItemCArbol
var ItemCArbol = {};
(function () {
    this.dt;
    this.tipoVentana = "CARBOL";
    this.divModal;
    this.tr;
    this.frm;
    this.RegEstado;
    this.init = function () {

        this.dt = ManDM.frm.find("#grvItemCArbol").DataTable({
            bServerSide: false,
            ajax: { url: ManDM.controller + "/GetAllCArbol", "type": "GET", "datatype": "json" },
            bProcessing: true,
            bJQueryUI: false,
            bRetrieve: true,
            bFilter: false,
            aaSorting: [],
            bPaginate: true,
            bLengthChange: false,
            scrollCollapse: true,
            deferRender: true,        
            pageLength: initSigo.pageLength,
            oLanguage: initSigo.oLanguage,
            drawCallback: initSigo.showPagination,
            columns: [
                { bSortable: false, mRender: ItemCArbol.cellEdit },
                { bSortable: false, mRender: ItemCArbol.cellDel },
                { name: "NRO", bSortable: true, mRender: utilDt.countRowDT },
                { data: "ESPECIES" },
                { data: "NUM_PCA" },
                { data: "CODIGO" },
                { data: "DAP" },
                { data: "ALTURA" },
                { data: "VOLUMEN" },
                { data: "COORDENADA_ESTE" },
                { data: "COORDENADA_NORTE" },
                { data: "CONDICION" },
                { data: "ESTADO" },
                { data: "OBSERVACION" },
                { data: "COD_SECUENCIAL", visible: false },
                { data: "COD_ESPECIES", visible: false },
                { data: "COD_ECONDICION", visible: false },
                { data: "COD_EESTADO", visible: false },
                { data: "RegEstado", visible: false }
            ]
        });
    }
    this.cellDel = function (data, type, row) {
        return '<i class="cellDel fa fa-lg fa-window-close" title="Eliminar" onclick="ItemCArbol.delete(this);"></i>';
    }
    this.cellEdit = function (data, type, row) {
        return '<i class="cellEdit fa fa-lg fa-pencil-square-o" title="Editar" onclick="ItemCArbol.showModal(2,this);"></i>';

    }

    this.showModal = function (RegEstado, obj) {

        if (this.divModal == undefined) {
            this.divModal = $("#PDivItemCArbol");
            this.frm = $("#frmCArbol");
            this.frm.find('#ddlItemCArbolEspecies').select2();
            this.configValidateForm();
        }

        var PDivTitulo = '';
        if (RegEstado == RegEstadoSigo.NEW) {
            PDivTitulo = "Nuevo Registro";
            this.frm.find("#ddlItemCArbolEspecies").attr("disabled", false);
        } else {
            if (RegEstado == RegEstadoSigo.UPDATE) {
                PDivTitulo = "Modificando Registro";
                this.tr = $(obj).closest('tr');
                var row = this.dt.row(this.tr).data();

                this.frm.find("#ddlItemCArbolEspecies").val(row.COD_ESPECIES).trigger("change");
                this.frm.find("#ddlItemCArbolEspecies").attr("disabled", true);

                this.frm.find("#txtItemCArbolDAP").val(row.DAP);
                this.frm.find("#txtItemCArbolNum_PCA").val(row.NUM_PCA);
                this.frm.find("#txtItemCArbolCodigo").val(row.CODIGO);
                this.frm.find("#txtItemCArbolAltura").val(row.ALTURA);
                this.frm.find("#txtItemCArbolVolumen").val(row.VOLUMEN);
                this.frm.find("#txtItemCArbolCoordenada_Este").val(row.COORDENADA_ESTE);
                this.frm.find("#txtItemCArbolCoordenada_Norte").val(row.COORDENADA_NORTE);
                this.frm.find("#ddlItemCArbolCod_Econdicion").val(row.COD_ECONDICION);
                this.frm.find("#ddlItemCArbolCod_Eestado").val(row.COD_EESTADO);
                this.frm.find("#txtItemCArbolObservacion").val(row.OBSERVACION);

            }
        }
        this.RegEstado = RegEstado;
        this.divModal.find(".spTitulo").html(PDivTitulo);
        utilSigo.modalDraggable(this.divModal, '.modal-header');
        this.divModal.modal({ keyboard: true, backdrop: 'static' });


    }
    this.cleanModal = function () {
        this.frm[0].reset();
        this.frm.find("#ddlItemCArbolEspecies").val("-").trigger("change");
    }

    this.closeModal = function () {
        this.cleanModal();
 
        $(':input', this.frm)
            .removeClass('border-danger')
            .removeAttr('data-toggle')
            .removeAttr('data-placement')
            .removeAttr('data-original-title');
        $('.select2-hidden-accessible', this.frm)
          .parents(".form-group")
          .removeClass('has-error')
          .removeAttr('data-toggle')
          .removeAttr('data-placement')
          .removeAttr('data-original-title');
        this.divModal.modal('hide');
    }
    this.configValidateForm = function () {
        jQuery.validator.addMethod("invalidFrmCArboles", function (value, element) {
            switch ($(element).attr('id')) {
                case 'ddlItemCArbolEspecies':
                    return (value == '-') ? false : true;
                    break;
                case 'ddlItemCArbolCod_Econdicion':
                    return (value == '-') ? false : true;
                    break;
                case 'ddlItemCArbolCod_Eestado':
                    return (value == '-') ? false : true;
                    break;
            }
        });

        var objValida = {
            rules: {
                ddlItemCArbolEspecies: { invalidFrmCArboles: true },
                ddlItemCArbolCod_Econdicion: { invalidFrmCArboles: true },
                ddlItemCArbolCod_Eestado: { invalidFrmCArboles: true }
            },
            messages: {
                ddlItemCArbolEspecies: { invalidFrmCArboles: "Debe seleccionar una especie" },
                ddlItemCArbolCod_Econdicion: { invalidFrmCArboles: "Debe seleccionar condicion" },
                ddlItemCArbolCod_Eestado: { invalidFrmCArboles: "Debe seleccionar estado" }
            }
        };
        this.frm.validate(utilSigo.fnValidate(objValida));

        //Para cuando cambia el combo para select2
        this.frm.find("select.select2-hidden-accessible").change(function () {
            if (!$.isEmptyObject(this.frm.validate().submitted) && this.divModal.is(":visible")) {
                this.frm.validate().form();
            }
        }.bind(this));

    }
    this.validaSaveModal = function () {
      
        return true;
    }
    this.saveModal = function () {
        if(this.frm.valid()){
            if (this.validaSaveModal()) {
                if (this.RegEstado == RegEstadoSigo.NEW) {
                    var fila = {
                        COD_SECUENCIAL: 0,
                        COD_ESPECIES: this.frm.find("#ddlItemCArbolEspecies").val(),
                        NUM_PCA: this.frm.find("#txtItemCArbolNum_PCA").val().trim(),
                        CODIGO: this.frm.find("#txtItemCArbolCodigo").val().trim(),
                        DAP: this.frm.find("#txtItemCArbolDAP").val().trim(),
                        ALTURA: this.frm.find("#txtItemCArbolAltura").val().trim(),
                        VOLUMEN: this.frm.find("#txtItemCArbolVolumen").val().trim(),
                        COORDENADA_ESTE: this.frm.find("#txtItemCArbolCoordenada_Este").val().trim(),
                        COORDENADA_NORTE: this.frm.find("#txtItemCArbolCoordenada_Norte").val().trim(),
                        COD_ECONDICION: this.frm.find("#ddlItemCArbolCod_Econdicion").val(),
                        COD_EESTADO: this.frm.find("#ddlItemCArbolCod_Eestado").val(),
                        CONDICION: this.frm.find("#ddlItemCArbolCod_Econdicion option:selected").text(),
                        ESTADO: this.frm.find("#ddlItemCArbolCod_Eestado option:selected").text(),
                        OBSERVACION: this.frm.find("#txtItemCArbolObservacion").val().trim(),
                        ESPECIES: this.frm.find("#ddlItemCArbolEspecies").select2('data')[0].text,
                        RegEstado: RegEstadoSigo.NEW
                    };
                    this.dt.row.add(fila).draw();
                    this.dt.page('last').draw('page');
                    utilSigo.toastSuccess("Exito", "Se Adiciono con exito");
                }
                else {
                    var row = this.dt.row(this.tr).data();
                    row.NUM_PCA = this.frm.find("#txtItemCArbolNum_PCA").val().trim();
                    row.CODIGO = this.frm.find("#txtItemCArbolCodigo").val().trim();
                    row.DAP = this.frm.find("#txtItemCArbolDAP").val().trim();
                    row.ALTURA = this.frm.find("#txtItemCArbolAltura").val().trim();
                    row.VOLUMEN = this.frm.find("#txtItemCArbolVolumen").val().trim();
                    row.COORDENADA_ESTE = this.frm.find("#txtItemCArbolCoordenada_Este").val().trim();
                    row.COORDENADA_NORTE = this.frm.find("#txtItemCArbolCoordenada_Norte").val().trim();
                    row.COD_ECONDICION = this.frm.find("#ddlItemCArbolCod_Econdicion").val();
                    row.COD_EESTADO = this.frm.find("#ddlItemCArbolCod_Eestado").val();
                    row.CONDICION = this.frm.find("#ddlItemCArbolCod_Econdicion option:selected").text();
                    row.ESTADO = this.frm.find("#ddlItemCArbolCod_Eestado option:selected").text();
                    row.OBSERVACION = this.frm.find("#txtItemCArbolObservacion").val().trim();

                    if (row.RegEstado == RegEstadoSigo.INITIAL)
                        row.RegEstado = RegEstadoSigo.UPDATE;

                    this.dt.row(this.tr).data(row).draw(false);
                    utilSigo.toastSuccess("Exito", "Se modifico con exito");
                    this.closeModal();
                }
            }
        }
    }
    this.delete = function (obj) {
        utilSigo.dialogConfirm("Confirmacion", "¿Está seguro de Eliminar el Registro Seleccionado?",
            function (r) {
                if (r) {
                    var $tr = $(obj).closest('tr');
                    var row = ItemCArbol.dt.row($tr).data();
                    ItemCArbol.addListEliTABLA(row);
                    ItemCArbol.dt.row($tr).remove().draw(false);
                    utilDt.enumColumn(ItemCArbol.dt, "NRO");
                }
            });
    }
    this.deleteAll = function () {

        var $trsEliminar = ItemCArbol.dt.$("tr");
        if ($trsEliminar.length > 0) {
            utilSigo.dialogConfirm("Confirmacion", "Está seguro de Eliminar Todo los Registros?", function (r) {
                if (r) {
                    ItemCArbol.dt.rows().every(function (rowIdx, tableLoop, rowLoop) {
                        var row = this.data();
                        ItemCArbol.addListEliTABLA(row);
                    });
                    ItemCArbol.dt.clear().draw();
                }
            });
        }
        else {
            utilSigo.toastWarning("Aviso", "No hay Registros a Eliminar");
        }
    }
    this.addListEliTABLA = function (row) {
        if (row.RegEstado == RegEstadoSigo.INITIAL || row.RegEstado == RegEstadoSigo.UPDATE) {
            ManDM.ListEliTABLA.push({
                EliTABLA: "DEV_MAD_DET_CENSO_ARBOL",
                EliVALOR01: row.COD_ESPECIES,
                EliVALOR02: row.COD_SECUENCIAL
            });
        }
    }
    this.getListDt = function () {
        var list = [];
        this.dt.rows().every(function (rowIdx, tableLoop, rowLoop) {
            var row = this.data();
            if (row.RegEstado == RegEstadoSigo.NEW ||
                row.RegEstado == RegEstadoSigo.UPDATE) {
                list.push(row);
            }
        });
        return list;
    }
    this.validaImportarExcel = function (e, objeto) {
        return true;
    }
    this.importarExcel = function (e, objeto) {
        var ruta = ManDM.controller + "/ImportarDataExcel";
        uploadFile.fileSelectHandler(e, objeto, ruta, { TVentana: this.tipoVentana }, this.successImpExcel);
    }
    this.successImpExcel = function (data) {
        ItemCArbol.dt.rows.add(data).draw();
        ItemCArbol.dt.page('last').draw('page');
    }

    this.tabsActive = function () {
        $("#navDatosTab").hide();
        $("#divTitle").hide();
        $("#navDevolCensoArbolesTab").show();
        $('.nav-tabs a[href="#navDevolCensoArboles"]').tab('show');
    }
    this.tabsInactive = function () {
        $("#divTitle").show();
        $("#navDatosTab").show();
        $("#navDevolCensoArbolesTab").hide();

        ManDM.frm.find("#lbtMaderableItemCensoArbolSelec").html("Total de Arboles ( " + ItemCArbol.dt.data().count() + " )");
        $('.nav-tabs a[href="#navDatos"]').tab('show');
    }

}).apply(ItemCArbol);


//ItemTRAprobacion
var ItemTRAprobacion = {};
(function () {
    this.dt;
    this.init = function () {
        this.dt = ManDM.frm.find("#grvItemTRAprobacion").DataTable({
            bServerSide: false,
            bProcessing: true,
            bJQueryUI: false,
            bRetrieve: true,
            bFilter: false,
            aaSorting: [],
            bPaginate: true,
            bLengthChange: false,
            scrollCollapse: true, 
            pageLength: initSigo.pageLength,
            oLanguage: initSigo.oLanguage,
            drawCallback: initSigo.showPagination,
            columns: [

                { bSortable: false, mRender: this.cellDel },
                { name: "NRO", bSortable: true, mRender: utilDt.countRowDT, width: "5%" },
              //  { data: "NUM_INFORME", width: "25%" },
               // { data: "FECHA_INFORME", width: "10%" },
                { data: "PERSONA", width: "50%" },
                { data: "N_DOCUMENTO", width: "10%" },
                { data: "CARGO", width: "35%" },
                { data: "COD_PERSONA", visible: false },
                { data: "COD_SECUENCIAL", visible: false },
                { data: "RegEstado", visible: false }
            ]
        });

    }
    this.cellDel = function (data, type, row) {
        return '<i class="cellDel fa fa-lg fa-window-close" title="Eliminar" onclick="ItemTRAprobacion.delete(this);"></i>';
    }

    //this.showModal = function (RegEstado, obj) {
    //    var option = {
    //        url: initSigo.urlControllerGeneral + "/_BuscarPersonaGeneral",
    //        divId: "modalBuscarPersona",
    //        datos: {
    //            "fFormOrigen": $("#TipoFormulario").val(),
    //            "cod_P_Tipo": "0000006"
    //        }
    //    };
     

    //    utilSigo.fnOpenModal(option, ItemTRAprobacion.configModal);
    //}
    //this.configModal = function () {
    //    _bPerGen.fnAsignarDatos = function (obj) {
    //        var tr = $(obj).closest('tr');
    //        var row = _bPerGen.dtBuscarPerona.row(tr).data();
    //        if (!utilDt.existValorSearch(ItemTRAprobacion.dt, "N_DOCUMENTO", row.nd)) {

    //            var rowNew = {
    //               // NUM_INFORME: ManDM.frm.find("#txtItemItecnico_Raprobacion_Num").val().trim(),
    //              //  FECHA_INFORME: ManDM.frm.find("#txtItemItecnico_Raprobacion_Fecha").val().trim(),
    //                PERSONA: row.desc,
    //                N_DOCUMENTO: row.nd,
    //                CARGO: row.car,
    //                COD_PERSONA: row.cod,
    //                RegEstado: RegEstadoSigo.NEW,
    //                COD_SECUENCIAL:0
    //            };
    //            ItemTRAprobacion.dt.row.add(rowNew).draw(false);
    //            ItemTRAprobacion.dt.page('last').draw('page');
    //            utilSigo.toastSuccess("Exito", "Se adiciono con exito");
    //        } else
    //            utilSigo.toastError("Error", "El registro ya existe");


    //    }
    //    _bPerGen.fnInit();
    //}
    this.delete = function (obj) {
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

    this.addListEliTABLA = function (row) {
        if (row.RegEstado == RegEstadoSigo.INITIAL || row.RegEstado == RegEstadoSigo.UPDATE) {
            ManDM.ListEliTABLA.push({
                EliTABLA: "DEV_MAD_DET_PINFTEC",
                EliVALOR01: row.COD_SECUENCIAL,
                EliVALOR02: 0
     
            });
        }
    }
    this.getListDt = function () {
        var list = [];
        this.dt.rows().every(function (rowIdx, tableLoop, rowLoop) {
            var row = this.data();
            if (row.RegEstado == RegEstadoSigo.NEW || row.RegEstado == RegEstadoSigo.UPDATE) {
                list.push(row);
            }
        });
        return list;
    }


}).apply(ItemTRAprobacion);

/*
//ItemFuncionarioFirma
var ItemFuncionarioFirma = {};
(function () {   
    this.init = function () {

    }
    this.showModal = function (RegEstado, obj) {
        var option = {
            url: initSigo.urlControllerGeneral + "/_BuscarPersonaGeneral",
            divId: "modalBuscarPersona",
            datos: {
                "fFormOrigen": $("#TipoFormulario").val(),
                "cod_P_Tipo": ""
            }
        };
        utilSigo.fnOpenModal(option, ItemFuncionarioFirma.configModal);
    }
    this.configModal = function () {
        _bPerGen.fnAsignarDatos = function (obj) {
            var tr = $(obj).closest('tr');
            var row = _bPerGen.dtBuscarPerona.row(tr).data();
            ManDM.frm.find("#lblItemFunFirma").val(row.desc);
            ManDM.frm.find("#hdfItemFunFirmaCodigo").val(row.cod);
            utilSigo.toastSuccess("Exito", "Se Modifico con exito");

        }
        _bPerGen.fnInit();
    }

}).apply(ItemFuncionarioFirma);
*/

ManDM.fnBuscarPersona = function (_dom, _tipoPersonaSIGOsfc) {
    var url = urlLocalSigo + "General/Controles/_BuscarPersonaGeneral";
    var option = { url: url, type: 'GET', datos: { asBusGrupo: "PERSONA", asCodPTipo: _tipoPersonaSIGOsfc, asTipoPersona: "N" }, divId: "mdlBuscarPersona" };
    utilSigo.fnOpenModal(option, function () {
        _bPerGen.fnAsignarDatos = function (obj) {
            if (obj != null && obj != "") {
                var data = _bPerGen.dtBuscarPerona.row($(obj).parents('tr')).data();
                switch (_dom) {
                    case "FRESOLUCION_FIRMA":
                        ManDM.frm.find("#lblItemFunFirma").val(data["PERSONA"]);
                        ManDM.frm.find("#hdfItemFunFirmaCodigo").val(data["COD_PERSONA"]);
                        break;
                    case "ITRAPROBACION":
                        if (!utilDt.existValorSearch(ItemTRAprobacion.dt, "COD_PERSONA", data["COD_PERSONA"])) {
                            ManDM.fnSetPersonaCompleto(_dom, data["COD_PERSONA"]);
                        } else { utilSigo.toastWarning("Aviso", "El técnico que recomienda la aprobación ya se encuentra registrado"); }
                        break;
                }
                utilSigo.fnCloseModal("mdlBuscarPersona");
            }
        }
        _bPerGen.fnInit();
    });
}
ManDM.fnSetPersonaCompleto = function (_dom, codPersona) {
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
                    case "ITRAPROBACION":
                        var dt = null;
                        switch (_dom) {
                            case "ITRAPROBACION": dt = ItemTRAprobacion.dt; break;
                            default: return false;
                        }
                        var item = { CARGO: data.data["CARGO"], COD_PERSONA: data.data["COD_PERSONA"], N_DOCUMENTO: data.data["N_DOCUMENTO"], PERSONA: data.data["APELLIDOS_NOMBRES"], RegEstado: "1", COD_SECUENCIAL: 0 };
                        dt.row.add(item).draw(); dt.page('last').draw('page');
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