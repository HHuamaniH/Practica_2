/// <reference path="../../../../scripts/sigo/utility.sigo.js" />
/// <reference path="../../../../scripts/sigo/init.sigo.js" />

"use strict";
class GuiaTransporte {
    constructor() {
        this.frm;
        this.tWindow;
        this.selectFile = null;
        this.ListEliTABLA = [];
        this.urlController = urlLocalSigo + "THabilitante/ManGuiaTransporteForestal";
    }
    init() {
        this.frm = $("#frmGuiaTransporte");
        this.configValidateForm();
        this.frm.find("#txtItemFechaExp,#txtItemFechaVen").datepicker(initSigo.formatDatePicker);          
        this.frm.find("[name=rdbListTH]").change(function () {
            ManGuiaTransporte.changeTHabilitante(this);
        });
    }
 
    configValidateForm() {
      
        var objValida = { };
        this.frm.validate(utilSigo.fnValidate(objValida));    
    }
    validarControles(control, icon, msj) {
        /*var valorValidar = this.frm.find("#" + control).val();
        var iconValidar = this.frm.find("#" + icon);
        if (valorValidar.trim() == '') {  
            iconValidar.removeAttr('style');
            utilSigo.toastError("Aviso", msj)
            return false;
        }
        else {
            iconValidar.attr('style', 'display:none;');
            return true;
        }*/
    }
    validaForm() {
        var codUGrupo = this.frm.find("#codUGrupo").val();
        if (utilSigo.ValidaTexto("hdfItemEstUbigeoCodigo", "Ingrese el ubigeo del Título Habilitante") == false) return false;
        if (utilSigo.ValidaTexto("hdfCodTitularHab", "Ingrese el Titular") == false) return false;
        if (codUGrupo != "0000014") {
         
            /*if (utilSigo.ValidaTexto("hdfCodPropietario", "Ingrese el propietario") == false) return false;*/
            /*if (utilSigo.ValidaTexto("hdfCodDestinatario", "Ingrese el destinatario") == false) return false;*/
        }
        return true;
    }
    save() {
        if (this.frm.valid()) {
            if (this.validaForm()) {
                var datos = this.frm.serializeObject();

                if (ItemProducto.dt != undefined)
                    datos.ListProducto = ItemProducto.getListDt();

                if (this.ListEliTABLA != undefined)
                    datos.ListEliTABLA = this.ListEliTABLA;

                datos.chkOrigenConc = $("#chkOrigenConc").is(":checked");
                datos.chkOrigenPerm = $("#chkOrigenPerm").is(":checked");
                datos.chkOrigenAut = $("#chkOrigenAut").is(":checked");
                datos.chkOrigenBL = $("#chkOrigenBL").is(":checked");
                datos.chkOrigenDesbloque = $("#chkOrigenDesbloque").is(":checked");
                datos.chkOrigenCambUso = $("#chkOrigenCambUso").is(":checked");
                datos.chkOrigenPlant = $("#chkOrigenPlant").is(":checked");
                datos.chkOrigenPMConsolidado = $("#chkOrigenPMConsolidado").is(":checked");
                datos.chkOrigenOtros = $("#chkOrigenOtros").is(":checked");
                datos.chkPlanAmazonas = $("#chkPlanAmazonas").is(":checked");


                $.ajax({
                    url: this.urlController + "/Registrar",
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
                                window.location = ManGuiaTransporte.urlController;
                            }, 2000);
                        }
                        else utilSigo.toastWarning("Aviso", data.msj);
                    }

                });
            }

        }else
            this.frm.validate().focusInvalid();
    }
    changeTHabilitante(obj) {
        var value = $(obj).val();

        this.frm.find("#txtItemTituloHabilitante").val("");
        this.frm.find("#txtItemNombreTitularh").val("");
        this.frm.find("#txtDireccionHabilitante").val("");
        this.frm.find("#txtDNIHab").val("");
        this.frm.find("#txtRucHab").val("");
        this.frm.find("#hdfItemCodTHabilitante").val("");
        this.frm.find("#hdfCodTitularHab").val("");
        this.frm.find("#hdfItemEstUbigeoCodigo").val("");
        this.frm.find("#lblItemEstUbigeo").val("");
  
  
        if (value == "1") {
            this.frm.find("#txtItemTituloHabilitante,#txtItemNombreTitularh,#txtDireccionHabilitante,#txtDNIHab,#txtRucHab").attr("disabled","disabled");     
        }
        if (value == "2") {        
            this.frm.find("#txtItemTituloHabilitante").attr("disabled", false);
        }

    }

    /*
    showModalPersona( tWindow) {
        var option = {
            url: initSigo.urlControllerGeneral + "/_BuscarPersonaGeneral",
            divId: "modalBuscarPersona"
        };
        this.tWindow = tWindow;
        utilSigo.fnOpenModal(option, this.configModalPersona.bind(this));
    }
 
    configModalPersona() {

        _bPerGen.fnAsignarDatos = this.fnAsignarDatosPersona.bind(this);
        _bPerGen.fnInit('T');
    }
    fnAsignarDatosPersona(obj) {
        var tr = $(obj).closest('tr');
        var row = _bPerGen.dtBuscarPerona.row(tr).data();

        switch (this.tWindow) {
            case "THab":             

                this.frm.find("#hdfCodTitularHab").val(row.cod);
                this.frm.find("#txtItemNombreTitularh").val(row.desc);
                this.frm.find("#txtDireccionHabilitante").val(row.dir);
                this.frm.find("#txtDNIHab").val(row.nd);
                this.frm.find("#txtRucHab").val(row.ruc);
                break;
            case "RLeg":
                this.frm.find("#hdfCodRLegalHab").val(row.cod);
                this.frm.find("#txtItemNombreRLegalh").val(row.desc);
                break;
            case "Pro":
                this.frm.find("#hdfCodPropietario").val(row.cod);
                this.frm.find("#txtNomProp").val(row.desc);
                this.frm.find("#txtDireccProp").val(row.dir);
                this.frm.find("#txtDNIProp").val(row.nd);
                this.frm.find("#txtRucProp").val(row.ruc);              
                break;
            case "Dest":
                this.frm.find("#hdfCodDestinatario").val(row.cod);
                this.frm.find("#txtNomDest").val(row.desc);
                this.frm.find("#txtDirecDest").val(row.dir);
                this.frm.find("#txtDNIDest").val(row.nd);
                this.frm.find("#txtRucDest").val(row.ruc);
                this.frm.find("#hdfItemEstUbigeoCodigo1").val(row.codubi );
                this.frm.find("#lblItemEstUbigeo1").val(row.ubi );
                break;
            case "Cond":
                this.frm.find("#hdfCodConductor").val(row.cod);
                this.frm.find("#txtNomCondTransp").val(row.desc);
                break;
            case "Desp":
                this.frm.find("#hdfCodDespachante").val(row.cod);
                this.frm.find("#txtDespachado").val(row.desc);
                break;
            case "Auto":
                this.frm.find("#hdfCodAutorizante").val(row.cod);
                this.frm.find("#txtAutorizado").val(row.desc);
                break;
            default: break;
        }
        utilSigo.toastSuccess("Exito", "Se selecciono con exito");
      
    } 
    */

    fnBuscarPersona(_dom, _tipoPersona, _tipoPersonaSIGOsfc) {
        var url = urlLocalSigo + "General/Controles/_BuscarPersonaGeneral";
        var option = { url: url, type: 'GET', datos: { asBusGrupo: "PERSONA", asCodPTipo: _tipoPersonaSIGOsfc, asTipoPersona: _tipoPersona, asFormulario: "GTF" }, divId: "mdlBuscarPersona" };
        utilSigo.fnOpenModal(option, function () {
            _bPerGen.fnAsignarDatos = function (obj) {
                if (obj != null && obj != "") {
                    var data = _bPerGen.dtBuscarPerona.row($(obj).parents('tr')).data();
                    switch (_dom) {
                        case "TITULAR":
                        case "PROPIETARIO":
                        case "DESTINATARIO":
                            ManGuiaTransporte.fnSetPersonaCompleto(_dom, data["COD_PERSONA"]);
                            break;
                        case "RLEGAL":
                            ManGuiaTransporte.frm.find("#hdfCodRLegalHab").val(data["COD_PERSONA"]);
                            ManGuiaTransporte.frm.find("#txtItemNombreRLegalh").val(data["PERSONA"]);
                            break;
                        case "CONDUCTOR":
                            ManGuiaTransporte.frm.find("#hdfCodConductor").val(data["COD_PERSONA"]);
                            ManGuiaTransporte.frm.find("#txtNomCondTransp").val(data["PERSONA"]);
                            break;
                        case "DESPACHO":
                            ManGuiaTransporte.frm.find("#hdfCodDespachante").val(data["COD_PERSONA"]);
                            ManGuiaTransporte.frm.find("#txtDespachado").val(data["PERSONA"]);
                            break;
                        case "EMISOR":
                            ManGuiaTransporte.frm.find("#hdfCodAutorizante").val(data["COD_PERSONA"]);
                            ManGuiaTransporte.frm.find("#txtAutorizado").val(data["PERSONA"]);
                            break;
                    }
                    utilSigo.fnCloseModal("mdlBuscarPersona");
                }
            }
            _bPerGen.fnInit();
        });
    }
    fnSetPersonaCompleto(_dom, codPersona) {
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
                        case "TITULAR":
                            ManGuiaTransporte.frm.find("#hdfCodTitularHab").val(data.data["COD_PERSONA"]);
                            ManGuiaTransporte.frm.find("#txtItemNombreTitularh").val(data.data["APELLIDOS_NOMBRES"]);
                            if (data.data["COD_DIDENTIDAD"] == "0000006") {//RUC
                                ManGuiaTransporte.frm.find("#txtRucHab").val(data.data["N_DOCUMENTO"]);
                            } else { ManGuiaTransporte.frm.find("#txtDNIHab").val(data.data["N_DOCUMENTO"]); }
                            if (data.data["ListDomicilio"].length>0) {
                                ManGuiaTransporte.frm.find("#txtDireccionHabilitante").val(data.data["ListDomicilio"][0]["DIRECCION"]);
                                ManGuiaTransporte.frm.find("#lblItemEstUbigeo").val(data.data["ListDomicilio"][0]["UBIGEO"]);
                                ManGuiaTransporte.frm.find("#hdfItemEstUbigeoCodigo").val(data.data["ListDomicilio"][0]["COD_UBIGEO"]);
                            }
                            break;
                        case "PROPIETARIO":
                            ManGuiaTransporte.frm.find("#hdfCodPropietario").val(data.data["COD_PERSONA"]);
                            ManGuiaTransporte.frm.find("#txtNomProp").val(data.data["APELLIDOS_NOMBRES"]);
                            if (data.data["COD_DIDENTIDAD"] == "0000006") {//RUC
                                ManGuiaTransporte.frm.find("#txtRucProp").val(data.data["N_DOCUMENTO"]);
                            } else { ManGuiaTransporte.frm.find("#txtDNIProp").val(data.data["N_DOCUMENTO"]); }
                            if (data.data["ListDomicilio"].length > 0) {
                                ManGuiaTransporte.frm.find("#txtDireccProp").val(data.data["ListDomicilio"][0]["DIRECCION"]);
                            }
                            break;
                        case "DESTINATARIO":
                            ManGuiaTransporte.frm.find("#hdfCodDestinatario").val(data.data["COD_PERSONA"]);
                            ManGuiaTransporte.frm.find("#txtNomDest").val(data.data["APELLIDOS_NOMBRES"]);
                            if (data.data["COD_DIDENTIDAD"] == "0000006") {//RUC
                                ManGuiaTransporte.frm.find("#txtRucDest").val(data.data["N_DOCUMENTO"]);
                            } else { ManGuiaTransporte.frm.find("#txtDNIDest").val(data.data["N_DOCUMENTO"]); }
                            if (data.data["ListDomicilio"].length > 0) {
                                ManGuiaTransporte.frm.find("#txtDirecDest").val(data.data["ListDomicilio"][0]["DIRECCION"]);
                                ManGuiaTransporte.frm.find("#lblItemEstUbigeo1").val(data.data["ListDomicilio"][0]["UBIGEO"]);
                                ManGuiaTransporte.frm.find("#hdfItemEstUbigeoCodigo1").val(data.data["ListDomicilio"][0]["COD_UBIGEO"]);
                            }
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

    cargarUbigeoModal(tWindow) {
        var url = initSigo.urlControllerGeneral + "/_Ubigeo";
        var option = { url: url, type: 'POST', datos: {}, divId: "personaUbigeoModal" };

        utilSigo.fnOpenModal(option, function () {
            _Ubigeo.fnSelectUbigeo = function (_ubigeoText, _ubigeoId) {
                if (tWindow == "T") {
                    this.frm.find("#hdfItemEstUbigeoCodigo").val(_ubigeoId);
                    this.frm.find("#lblItemEstUbigeo").val(_ubigeoText);
                }
                if (tWindow == "D") {
                    this.frm.find("#hdfItemEstUbigeoCodigo1").val(_ubigeoId);
                    this.frm.find("#lblItemEstUbigeo1").val(_ubigeoText);
                }
                $("#personaUbigeoModal").modal('hide');
            }.bind(this);
            var codUbigeo = "";
            if (tWindow == "T")
                codUbigeo = this.frm.find("#hdfItemEstUbigeoCodigo").val();

            if (tWindow == "D")
                codUbigeo = this.frm.find("#hdfItemEstUbigeoCodigo1").val();

            _Ubigeo.fnLoadModalView(codUbigeo);

        }.bind(this) );

    }

    
    importarExcel(e, objeto) {
        const urlImportExcel = this.urlController + "/UploadFiles";
        uploadFile.fileSelectHandler(e, objeto, urlImportExcel, { }, this.successImpExcel.bind(this));
    }
    successImpExcel(data1) {
        var data = data1[0];
        //console.log(data);
        this.frm.find("#GTF_ARCHIVO").val(data.GTF_ARCHIVO);
        this.frm.find("#archivoSubido").val("1");
        this.frm.find("#GTF_ARCHIVO_TEXT").val(data.GTF_ARCHIVO_TEXT);
        this.frm.find("#lblArchivoSeleccionado").attr("href", "../../Archivos/Archivo_GTF/Temp/" + data.GTF_ARCHIVO);
        this.frm.find("#lblArchivoSeleccionado").text( data.GTF_ARCHIVO_TEXT);
    }
}



class THabilitante {
    constructor() {        
    }
    showModal() {       
        var option = {
            url: initSigo.urlControllerGeneral + "/_THabilitante",
            divId: "modalBuscarTitular",
            datos: { hdfFormulario: ManGuiaTransporte.frm.find("#TipoFormulario").val() }
        };      
        utilSigo.fnOpenModal(option, this.configModal);
    }
    configModal() {
      

        vpTHabilitante.fnAsignarDatos = function (obj) {
           var tr = $(obj).closest('tr');
            var row = vpTHabilitante.dtTituloHabilitante.row(tr).data();

            ManGuiaTransporte.frm.find("#hdfItemCodTHabilitante").val(row.CODIGO);
            ManGuiaTransporte.frm.find("#txtItemTituloHabilitante").val(row.NUMERO);
            ManGuiaTransporte.frm.find("#txtItemNombreTitularh").val(row.PARAMETRO02);
            ManGuiaTransporte.frm.find("#hdfItemEstUbigeoCodigo").val(row.PARAMETRO07);
            ManGuiaTransporte.frm.find("#lblItemEstUbigeo").val(row.PARAMETRO08);
            ManGuiaTransporte.frm.find("#txtDireccionHabilitante").val(row.PARAMETRO05);
            ManGuiaTransporte.frm.find("#txtDNIHab").val(row.PARAMETRO03);
            ManGuiaTransporte.frm.find("#txtRucHab").val(row.PARAMETRO04);
            ManGuiaTransporte.frm.find("#hdfCodTitularHab").val(row.PARAMETRO01);
            ManGuiaTransporte.frm.find("#hdfCodRLegalHab").val(row.PARAMETRO09);
            ManGuiaTransporte.frm.find("#txtItemNombreRLegalh").val(row.PARAMETRO10);
            utilSigo.toastSuccess("Exito", "Se Selecciono con exito");

           

        }
        vpTHabilitante.columns_label_v2 = ["Título Habilitante", "Titular" ];
        vpTHabilitante.columns_data_v2 = ["NUMERO", "PARAMETRO02" ];
        vpTHabilitante.fnInit_v2();


    }

}

//ItemProducto
class Producto {
   
    constructor(nameObject, tipoVentana) {
        
        this.nameObject = nameObject;
        this.tipoVentana = tipoVentana;       
        this.dt;
        this.tr;
        this.RegEstado;
 
    }
    init(){
      
        this.dt = ManGuiaTransporte.frm.find("#grvItemProducto").DataTable({
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
                { bSortable: false, mRender: this.cellEdit.bind(this), width: "5%" },
                { bSortable: false, mRender: this.cellDel.bind(this), width: "5%" },
                { name: "NRO", bSortable: true, mRender: utilDt.countRowDT, width: "5%" },
                //{ data: "NUMERO_PRODUCTO",width:"10%" },
                { data: "NOMBRE_PRODUCTO", width: "35%" },
                { data: "TIPO_PRODUCTO", width: "10%" },
                { data: "DESCRIPCION_PRODUCTO", width: "10%" },
                { data: "CANTIDAD_PRODUCTO", width: "10%" },
                { data: "UNIDAD_MEDIDA_PROD", width: "10%" },
                { data: "TOTAL_PRODUCTO", width: "10%" }//,              
                //{ data: "CODIGO_PRODUCTO", visible: false },
                //{ data: "COD_ESPECIES", visible: false },
                //{ data: "OBSERVACIONES_PROD_DETALLE", visible: false },
                //{ data: "RegEstado", visible: false },
               
            ]
        });
    }  
    cellDel(data, type, row) {       
        return '<i class="cellDel fa fa-lg fa-window-close" title="Eliminar" onclick="'+this.nameObject +'.delete(this);"></i>';
    }
    cellEdit(data, type, row) {  
        return '<i class="cellEdit fa fa-lg fa-pencil-square-o" title="Editar" onclick="' + this.nameObject + '.showModal(2,this);"></i>';
    }
      
    showModal(RegEstado, obj) {
        var option = {
            url: ManGuiaTransporte.urlController + "/_ItemProducto",
            divId: "modalAddEditProducto"
        };
        this.RegEstado = RegEstado;
        this.tr = $(obj).closest('tr');
        utilSigo.fnOpenModal(option, this.configModal.bind(this));
    }
    afterSave(row) {
       
        if (this.RegEstado == RegEstadoSigo.NEW) {
            var dtTemp = this.dt;
      
                var rowNew = {
                    NUMERO_PRODUCTO: row.txtCodProdProducto,
                    NOMBRE_PRODUCTO: row.ddlEspeciesProductoDesc,
                    TIPO_PRODUCTO: row.txtTipoProducto,
                    DESCRIPCION_PRODUCTO: row.txtDescripcionProducto,
                    CANTIDAD_PRODUCTO: row.txtCantidadProducto,
                    UNIDAD_MEDIDA_PROD: row.ddlUnidadMedidaProducto,
                    TOTAL_PRODUCTO: row.txtTotalProducto,
                    CODIGO_PRODUCTO: row.hdCodidoProducto,
                    OBSERVACIONES_PROD_DETALLE: row.txtObservacionProducto,
                    COD_ESPECIES: row.ddlEspeciesProducto,
                    RegEstado: RegEstadoSigo.NEW
                };
                dtTemp.row.add(rowNew).draw(false);
                dtTemp.page('last').draw('page');
                utilSigo.toastSuccess("Exito", "Se adiciono con exito");
          
        } else {
            var rowTemp = this.dt.row(this.tr).data();
         
            rowTemp.NUMERO_PRODUCTO = row.txtCodProdProducto;
            rowTemp.NOMBRE_PRODUCTO = row.ddlEspeciesProductoDesc;
            rowTemp.TIPO_PRODUCTO = row.txtTipoProducto;
            rowTemp.DESCRIPCION_PRODUCTO = row.txtDescripcionProducto;
            rowTemp.CANTIDAD_PRODUCTO = row.txtCantidadProducto;
            rowTemp.UNIDAD_MEDIDA_PROD = row.ddlUnidadMedidaProducto;
            rowTemp.TOTAL_PRODUCTO = row.txtTotalProducto;
            rowTemp.CODIGO_PRODUCTO = row.hdCodidoProducto;
            rowTemp.OBSERVACIONES_PROD_DETALLE = row.txtObservacionProducto;
            rowTemp.COD_ESPECIES = row.ddlEspeciesProducto;

            if (rowTemp.RegEstado == RegEstadoSigo.INITIAL)
                rowTemp.RegEstado = RegEstadoSigo.UPDATE;

            this.dt.row(this.tr).data(rowTemp).draw(false);
            utilSigo.toastSuccess("Exito", "Se modifico con exito");
            _ItemProducto.close();
            this.tr = null;
        }

    }
    configModal() {
        _ItemProducto.afterSave = this.afterSave.bind(this);
        var row;
        if (this.RegEstado == RegEstadoSigo.UPDATE)
            row = this.dt.row(this.tr).data();
        _ItemProducto.init(this.RegEstado, row);
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
            ManGuiaTransporte.ListEliTABLA.push({
                EliTABLA: "GTRANSPORTE_DET_PRODUCTO",
                CODIGO_PRODUCTO: row.CODIGO_PRODUCTO
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

   
}




