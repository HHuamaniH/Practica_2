"use strict";
var _ZonifDistribEspecie = {};

_ZonifDistribEspecie.fnSaveForm = function (data) { /*implementado desde donde se instancia*/ }

_ZonifDistribEspecie.fnLoadDatos = function (data) {    
    if (data != null && data != "") {
        _ZonifDistribEspecie.frm.find("#hdfRegEstadoZDE").val(data["RegEstado"]); 
        _ZonifDistribEspecie.frm.find("#hdfCodSecuencialZDE").val(data["COD_SECUENCIAL"]);
        _ZonifDistribEspecie.frm.find("#txtZona").val(data["ZONA"]);
        _ZonifDistribEspecie.frm.find("#txtCaracteristicas").val(data["CARACTERISTICAS"]);                
        _ZonifDistribEspecie.frm.find("#txtCoordEste").val(data["COORDENADA_ESTE"]);
        _ZonifDistribEspecie.frm.find("#txtCoordNorte").val(data["COORDENADA_NORTE"]);
        _ZonifDistribEspecie.frm.find("#txtTipoSenial").val(data["TIPO_SENIAL"]);
    } else {
        _ZonifDistribEspecie.frm.find("#hdfRegEstadoZDE").val("1");
        _ZonifDistribEspecie.frm.find("#hdfCodSecuencialZDE").val("0");
    }
}

_ZonifDistribEspecie.fnSetDatos = function () {
    var data = [];    
    var regEstado = _ZonifDistribEspecie.frm.find("#hdfRegEstadoZDE").val();
    data["RegEstado"] = regEstado == "0" ? "2" : regEstado;
    data["COD_SECUENCIAL"] = _ZonifDistribEspecie.frm.find("#hdfCodSecuencialZDE").val();
    data["ZONA"] = _ZonifDistribEspecie.frm.find("#txtZona").val();
    data["CARACTERISTICAS"] = _ZonifDistribEspecie.frm.find("#txtCaracteristicas").val();   
    data["COORDENADA_ESTE"] = _ZonifDistribEspecie.frm.find("#txtCoordEste").val();
    data["COORDENADA_NORTE"] = _ZonifDistribEspecie.frm.find("#txtCoordNorte").val();
    data["TIPO_SENIAL"] = _ZonifDistribEspecie.frm.find("#txtTipoSenial").val();
    return data;
}

_ZonifDistribEspecie.fnSubmitForm = function () {
    _ZonifDistribEspecie.frm.submit();
}

_ZonifDistribEspecie.fnInit = function (data) {
    _ZonifDistribEspecie.frm = $("#frmItemZonifDistribEspecie");

    $.fn.select2.defaults.set("theme", "bootstrap4");   

    _ZonifDistribEspecie.fnLoadDatos(data);

    //_ZonifDistribEspecie.fnEvents();

    //=====-----Para el registro de datos del formulario-----=====
    //Validación personalizada
    
    _ZonifDistribEspecie.frm.validate(utilSigo.fnValidate({
        rules: {           
            txtZona: { required: true },
            txtCaracteristicas: { required: true },            
            txtCoordEste: { required: true },
            txtCoordNorte: { required: true },
            txtTipoSenial: { required: true }
        },
        messages: {
            txtZona: { required: "Ingrese la Zona" },
            txtCaracteristicas: { required: "Ingrese carácteristica" },
            txtCoordEste: { required: "Ingrese la coordenada este" },
            txtCoordNorte: { required: "Ingrese la coordenada norte" },
            txtTipoSenial: { required: "Ingrese tipo de señalización" }
        },
        fnSubmit: function (form) {
            _ZonifDistribEspecie.fnSaveForm(_ZonifDistribEspecie.fnSetDatos());
        }
    }));
}


