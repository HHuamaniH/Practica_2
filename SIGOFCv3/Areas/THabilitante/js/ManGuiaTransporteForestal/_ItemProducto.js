'use strict';
var _ItemProducto = {};
(function () {
    this.urlController = urlLocalSigo + "THabilitante/ManGuiaTransporteForestal/";
    this.RegEstado;
    this.init=(RegEstado,data)=> {
        this.frm = $("#frmItemProducto");
        this.content = $("#divItemProducto");
        this.RegEstado = RegEstado;
        if (RegEstado == RegEstadoSigo.UPDATE) {
            this.initData(data);
 
        }
        this.initEvent();
 
    }
    this.initData = (data) => {
  
        this.frm.find("#hdCodidoProducto").val(data.CODIGO_PRODUCTO);
        this.frm.find("#txtCodProdProducto").val(data.NUMERO_PRODUCTO);
        this.frm.find("#ddlEspeciesProducto").val(data.COD_ESPECIES).trigger("change");
        this.frm.find("#txtTipoProducto").val(data.TIPO_PRODUCTO);
        this.frm.find("#txtDescripcionProducto").val(data.DESCRIPCION_PRODUCTO);
        this.frm.find("#txtCantidadProducto").val(data.CANTIDAD_PRODUCTO);
        this.frm.find("#ddlUnidadMedidaProducto").val(data.UNIDAD_MEDIDA_PROD);
        this.frm.find("#txtTotalProducto").val(data.TOTAL_PRODUCTO);
        this.frm.find("#txtObservacionProducto").val(data.OBSERVACIONES_PROD_DETALLE);

   
    }
    this.initEvent = () => {
      
        this.configValidateForm();
        this.content.find("#btnGuardarProducto").click(function () {   this.save(); }.bind(this));
        this.frm.find("#ddlEspeciesProducto").select2();
     

    }
    this.configValidateForm = () => {
 
        var objValida = {};
        this.frm.validate(utilSigo.fnValidate(objValida));
    
    }
    this.validAdditional=()=> {
        return true;
    }
    this.save=()=> {
        if (this.frm.valid()) {
            if (this.validAdditional()) {
                let datos = {};
                let dataForm = this.frm.serializeObject();                               
                dataForm.ddlEspeciesProductoDesc = this.frm.find("#ddlEspeciesProducto").select2('data')[0].text;              
                this.afterSave(dataForm);               
            }
        }
        else
            this.frm.validate().focusInvalid();
    }
    this.afterSave=(data)=> {}
    this.finallySave = () => {
        if (this.RegEstado == RegEstadoSigo.NEW)
            this.frm[0].reset();
        else
            this.close();
    }
    this.close = () => {       
        this.content.closest(".modal").modal("hide");
    }

}).apply(_ItemProducto);
