"use strict";
var _PersonalTecProf = {};

_PersonalTecProf.fnSaveForm = function (data) { /*implementado desde donde se instancia*/ }

_PersonalTecProf.fnLoadDatos = function (data) {
    if (data != null && data != "") {
        _PersonalTecProf.frm.find("#hdfRegEstado").val(data["RegEstado"]);
        _PersonalTecProf.frm.find("#hdfCodPersonalTECPROF").val(data["COD_PERSONALTECPROF"]);
        _PersonalTecProf.frm.find("#ddlTipoPersonalTECPROFId").select2("val", [data["TIPO"] == "" ? "0000000" : data["TIPO"]]);
        _PersonalTecProf.frm.find("#txtNombres").val(data["NOMBRES"]);              
        _PersonalTecProf.frm.find("#txtOtro").val(data["OTRO"]);
    } else {
        _PersonalTecProf.frm.find("#hdfRegEstado").val("1");
        _PersonalTecProf.frm.find("#hdfCodPersonalTECPROF").val("0");
    }
}

_PersonalTecProf.fnSetDatos = function () {
    var data = [];
    var regEstado = _PersonalTecProf.frm.find("#hdfRegEstado").val();
    data["RegEstado"] = regEstado == "0" ? "2" : regEstado;
    data["COD_PERSONALTECPROF"] = _PersonalTecProf.frm.find("#hdfCodPersonalTECPROF").val();
    data["NOMBRES"] = _PersonalTecProf.frm.find("#txtNombres").val();
    data["TIPO"] = _PersonalTecProf.frm.find("#ddlTipoPersonalTECPROFId").val();
    data["OTRO"] = _PersonalTecProf.frm.find("#txtOtro").val();    
    return data;
}

_PersonalTecProf.fnSubmitForm = function () {
    _PersonalTecProf.frm.submit();
}

_PersonalTecProf.fnInit = function (data) {
    _PersonalTecProf.frm = $("#frmItemPersonalTecProf");

    $.fn.select2.defaults.set("theme", "bootstrap4");
    _PersonalTecProf.frm.find("#ddlTipoPersonalTECPROFId").select2({ minimumResultsForSearch: -1 });
    

    _PersonalTecProf.fnLoadDatos(data);

    //=====-----Para el registro de datos del formulario-----=====
    //Validación personalizada
    jQuery.validator.addMethod("invalidFrmDespl", function (value, element) {
        switch ($(element).attr('id')) {
            case 'ddlTipoPersonalTECPROFId':
                return (value == '0000000') ? false : true;
                break
        }
    });
    _PersonalTecProf.frm.validate(utilSigo.fnValidate({
        rules: {
            ddlTipoPersonalTECPROFId: { invalidFrmDespl: true },
            txtNombres: { required: true },
            txtOtro: { required: true },            
        },
        messages: {
            ddlTipoPersonalTECPROFId: { invalidFrmDespl: "Seleccione el Tipo" },
            txtNombres: { required: "Ingrese el nombre completo" },
            txtOtro: { required: "Ingrese la descripción de otro" }
        },
        fnSubmit: function (form) {
            _PersonalTecProf.fnSaveForm(_PersonalTecProf.fnSetDatos());
        }
    }));
    //Validación de controles que usan Select2
    _PersonalTecProf.frm.find("select.select2-hidden-accessible").on("change", function (e) {
        $(this).valid();
    });
}