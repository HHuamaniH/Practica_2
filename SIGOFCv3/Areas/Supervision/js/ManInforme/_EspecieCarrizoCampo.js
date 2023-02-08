"use strict";
var _EspecieCarrizoCampo = {};

_EspecieCarrizoCampo.fnSaveForm = function (data) { /*implementado desde donde se instancia*/ }

_EspecieCarrizoCampo.fnLoadDatos = function (data) {
    if (data != null && data != "") {
        _EspecieCarrizoCampo.frm.find("#hdfRegEstado").val(data["RegEstado"]);
        _EspecieCarrizoCampo.frm.find("#hdfCodTHabilitante").val(data["COD_THABILITANTE"]);
        _EspecieCarrizoCampo.frm.find("#hdfCodMuestra").val(data["COD_MUESTRA_SUPERVISION"]);
        _EspecieCarrizoCampo.frm.find("#txtTotalMuestra").val(data["TOTAL_UNIDAD_MUEST"]);
        _EspecieCarrizoCampo.frm.find("#txtTotalMuestraAprov").val(data["TOTAL_UNIDADES_APROV"]);
        //_EspecieCarrizoCampo.frm.find("#txtUnidadMedida").val(data["UNIDAD_MEDIDA"]);
        //_EspecieCarrizoCampo.frm.find("#txtNumIndividuo").val(data["NUM_INDIVIDUOS"]);
        _EspecieCarrizoCampo.frm.find("#ddlZonaId").select2("val", [data["ZONA"] == "" ? "0000000" : data["ZONA"]]);
        _EspecieCarrizoCampo.frm.find("#txtCEste").val(data["COORDENADA_ESTE"]);
        _EspecieCarrizoCampo.frm.find("#txtCNorte").val(data["COORDENADA_NORTE"]);
        _EspecieCarrizoCampo.frm.find("#ddlProductoId").select2("val", [data["PRODUCTO_EXTRAER"] == "" ? "0000000" : data["PRODUCTO_EXTRAER"]]);
        _EspecieCarrizoCampo.frm.find("#txtObservacion").val(data["OBSERVACION"]);
        _renderComboEspecie.fnInit("FORESTAL", data["COD_ESPECIES"], data["ESPECIES"]);
    } else {
        _EspecieCarrizoCampo.frm.find("#hdfRegEstado").val("1");
        _renderComboEspecie.fnInit("FORESTAL", "", "");
    }
}

_EspecieCarrizoCampo.fnSetDatos = function () {
    var data = [];
    var regEstado = _EspecieCarrizoCampo.frm.find("#hdfRegEstado").val();
    data["RegEstado"] = regEstado == "0" ? "2" : regEstado;
    data["COD_INFORME"] = _EspecieCarrizoCampo.frm.find("#hdfCodInforme").val();
    data["NUM_POA"] = _EspecieCarrizoCampo.frm.find("#hdfNumPoa").val();
    data["COD_MUESTRA_SUPERVISION"] = _EspecieCarrizoCampo.frm.find("#hdfCodMuestra").val();
    data["COD_THABILITANTE"] = _EspecieCarrizoCampo.frm.find("#hdfCodTHabilitante").val();
    data["COD_ESPECIES"] = _renderComboEspecie.fnGetCodEspecie();
    data["ESPECIES"] = _renderComboEspecie.fnGetEspecie();
    data["TOTAL_UNIDAD_MUEST"]=_EspecieCarrizoCampo.frm.find("#txtTotalMuestra").val();
    data["TOTAL_UNIDADES_APROV"]=_EspecieCarrizoCampo.frm.find("#txtTotalMuestraAprov").val();
    //data["UNIDAD_MEDIDA"]=_EspecieCarrizoCampo.frm.find("#txtUnidadMedida").val();
    //data["NUM_INDIVIDUOS"]=_EspecieCarrizoCampo.frm.find("#txtNumIndividuo").val();
    data["ZONA"] = _EspecieCarrizoCampo.frm.find("#ddlZonaId").val();
    data["COORDENADA_ESTE"] = _EspecieCarrizoCampo.frm.find("#txtCEste").val();
    data["COORDENADA_NORTE"] = _EspecieCarrizoCampo.frm.find("#txtCNorte").val();
    data["PRODUCTO_EXTRAER"] = _EspecieCarrizoCampo.frm.find("#ddlProductoId").val();
    data["OBSERVACION"] = _EspecieCarrizoCampo.frm.find("#txtObservacion").val();
    return data;
}

_EspecieCarrizoCampo.fnCustomValidateForm = function () {
    if (_renderComboEspecie.fnGetCodEspecie() == null) {
        utilSigo.toastWarning("Aviso", "Seleccione la especie a registrar"); return false;
    }
    return true;
}

_EspecieCarrizoCampo.fnSubmitForm = function () {
    _EspecieCarrizoCampo.frm.submit();
}

_EspecieCarrizoCampo.fnInit = function (data) {
    _EspecieCarrizoCampo.frm = $("#frmItemCarrizoCampo");

    $.fn.select2.defaults.set("theme", "bootstrap4");
    _EspecieCarrizoCampo.frm.find("#ddlZonaId").select2({ minimumResultsForSearch: -1 });
    _EspecieCarrizoCampo.frm.find("#ddlProductoId").select2({ minimumResultsForSearch: -1 });

    _EspecieCarrizoCampo.fnLoadDatos(data);

    _EspecieCarrizoCampo.frm.find(".dvDatosCarrizo").hide();
    _EspecieCarrizoCampo.frm.find(".dvDatosPlantaMedicinal").hide();
    if (_EspecieCarrizoCampo.frm.find("#hdfCodMTipo").val()=="0000020") {
        _EspecieCarrizoCampo.frm.find(".dvDatosCarrizo").show();
    } else {
        _EspecieCarrizoCampo.frm.find(".dvDatosPlantaMedicinal").show();
    }

    //=====-----Para el registro de datos del formulario-----=====
    //Validación personalizada
    jQuery.validator.addMethod("invalidFrmCarrizo", function (value, element) {
        switch ($(element).attr('id')) {
            case 'ddlProductoId':
            case 'ddlZonaId':
                return (value == '0000000') ? false : true;
                break
        }
    });

    if (_EspecieCarrizoCampo.frm.find("#hdfCodMTipo").val() == "0000020") {
        _EspecieCarrizoCampo.frm.validate(utilSigo.fnValidate({
            rules: {
                txtTotalMuestra: { required: true },
                txtTotalMuestraAprov: { required: true },
                ddlZonaId: { invalidFrmCarrizo: true },
                txtCEste: { required: true },
                txtCNorte: { required: true },
                ddlProductoId: { invalidFrmCarrizo: true }
            },
            messages: {
                txtTotalMuestra: { required: "Ingrese el total unidades por muestra" },
                txtTotalMuestraAprov: { required: "Ingrese el total unidades aprovechables por muestra" },
                ddlZonaId: { invalidFrmCarrizo: "Seleccione la zona UTM" },
                txtCEste: { required: "Ingrese la coordenada este" },
                txtCNorte: { required: "Ingrese la coordenada norte" },
                ddlProductoId: { invalidFrmCarrizo: "Ingrese el producto a extraer" }
            },
            fnSubmit: function (form) {
                if (_EspecieCarrizoCampo.fnCustomValidateForm()) {
                    var oEspecie = utilSigo.fnConvertArrayToObject(_EspecieCarrizoCampo.fnSetDatos());
                    var url = urlLocalSigo + "Supervision/ManInforme/GrabarEspecieCarrizoCampo";
                    var option = { url: url, datos: JSON.stringify(oEspecie), type: 'POST' };
                    utilSigo.fnAjax(option, function (data) {
                        if (data.success) {
                            oEspecie["RegEstado"] = 0;
                            _EspecieCarrizoCampo.fnSaveForm(oEspecie);
                        }
                        else {
                            utilSigo.toastWarning("Aviso", data.msj);
                        }
                    });
                }
            }
        }));
    } else {
        _EspecieCarrizoCampo.frm.validate(utilSigo.fnValidate({
            rules: {
                //txtUnidadMedida: { required: true },
                txtNumIndividuo: { required: true },
                ddlZonaId: { invalidFrmCarrizo: true },
                txtCEste: { required: true },
                txtCNorte: { required: true },
                ddlProductoId: { invalidFrmCarrizo: true }
            },
            messages: {
                //txtUnidadMedida: { required: "Ingrese la unidad de medida" },
                txtNumIndividuo: { required: "Ingrese el número de individuos" },
                ddlZonaId: { invalidFrmCarrizo: "Seleccione la zona UTM" },
                txtCEste: { required: "Ingrese la coordenada este" },
                txtCNorte: { required: "Ingrese la coordenada norte" },
                ddlProductoId: { invalidFrmCarrizo: "Seleccione el producto a extraer" }
            },
            fnSubmit: function (form) {
                if (_EspecieCarrizoCampo.fnCustomValidateForm()) {
                    var oEspecie = utilSigo.fnConvertArrayToObject(_EspecieCarrizoCampo.fnSetDatos());
                    var url = urlLocalSigo + "Supervision/ManInforme/GrabarEspecieCarrizoCampo";
                    var option = { url: url, datos: JSON.stringify(oEspecie), type: 'POST' };
                    utilSigo.fnAjax(option, function (data) {
                        if (data.success) {
                            oEspecie["RegEstado"] = 0;
                            _EspecieCarrizoCampo.fnSaveForm(oEspecie);
                        }
                        else {
                            utilSigo.toastWarning("Aviso", data.msj);
                        }
                    });
                }
            }
        }));
    }

    
    //Validación de controles que usan Select2
    _EspecieCarrizoCampo.frm.find("select.select2-hidden-accessible").on("change", function (e) {
        $(this).valid();
    });
}