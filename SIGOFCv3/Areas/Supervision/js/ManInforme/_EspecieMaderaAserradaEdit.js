"use strict";
var _EspecieMaderaAserradaEdit = {};

_EspecieMaderaAserradaEdit.fnSaveForm = function (data) { /*implementado desde donde se instancia*/ }

_EspecieMaderaAserradaEdit.fnLoadDatos = function (data) {
    var regEstado = "1";
    _EspecieMaderaAserradaEdit.frm = $("#frmItemMaderaAserradaEdit");
    if (data != null && data != "") {
        if (data.data[0]["CODIGO"] != "") {
            regEstado = "0";
        }   
        _EspecieMaderaAserradaEdit.frm.find("#hdfRegEstado").val(regEstado);
        _EspecieMaderaAserradaEdit.frm.find("#hdfCodSecuencial").val(data.data[0]["COD_SECUENCIAL"]);
        _EspecieMaderaAserradaEdit.frm.find("#hdfCodTHabilitante").val(data.data[0]["COD_THABILITANTE"]);
        _EspecieMaderaAserradaEdit.frm.find("#txtCodigo").val(data.data[0]["CODIGO"]);
        _EspecieMaderaAserradaEdit.frm.find("#txtPieza").val(data.data[0]["PIEZAS"]);
        _EspecieMaderaAserradaEdit.frm.find("#ddlZonaId").val(data.data[0]["ZONA"]);
        _EspecieMaderaAserradaEdit.frm.find("#txtCEste").val(data.data[0]["COORDENADA_ESTE"]);
        _EspecieMaderaAserradaEdit.frm.find("#txtCNorte").val(data.data[0]["COORDENADA_NORTE"]);
        _EspecieMaderaAserradaEdit.frm.find("#txtEspesor").val(data.data[0]["ESPESOR"]);
        _EspecieMaderaAserradaEdit.frm.find("#txtAncho").val(data.data[0]["ANCHO"]);
        _EspecieMaderaAserradaEdit.frm.find("#txtLargo").val(data.data[0]["LARGO"]);
        _EspecieMaderaAserradaEdit.frm.find("#txtObservacion").val(data.data[0]["OBSERVACION"]);
        _renderComboEspecie.fnInit("FORESTAL", data.data[0]["COD_ESPECIES"], data.data[0]["ESPECIES"]);
    } else {
        _EspecieMaderaAserradaEdit.frm.find("#hdfRegEstado").val("1");
        _EspecieMaderaAserradaEdit.frm.find("#hdfCodSecuencial").val("0");
        _renderComboEspecie.fnInit("FORESTAL", "", "");
    }
}

_EspecieMaderaAserradaEdit.fnSetDatos = function () {

    var data = [];
    var regEstado = _EspecieMaderaAserradaEdit.frm.find("#hdfRegEstado").val();
    data["RegEstado"] = regEstado == "0" ? "2" : regEstado;
    data["COD_INFORME"] = _EspecieMaderaAserradaEdit.frm.find("#hdfCodInforme").val();
    data["NUM_POA"] = _EspecieMaderaAserradaEdit.frm.find("#hdfNumPoa").val();
    data["COD_SECUENCIAL"] = _EspecieMaderaAserradaEdit.frm.find("#hdfCodSecuencial").val();
    data["COD_THABILITANTE"] = _EspecieMaderaAserradaEdit.frm.find("#hdfCodTHabilitante").val();
    data["CODIGO"] = _EspecieMaderaAserradaEdit.frm.find("#txtCodigo").val();
    data["COD_ESPECIES"] = _renderComboEspecie.fnGetCodEspecie();
    data["ESPECIES"] = _renderComboEspecie.fnGetEspecie();
    data["PIEZAS"] = _EspecieMaderaAserradaEdit.frm.find("#txtPieza").val();
    data["ZONA"] = _EspecieMaderaAserradaEdit.frm.find("#ddlZonaId").val();
    data["COORDENADA_ESTE"] = _EspecieMaderaAserradaEdit.frm.find("#txtCEste").val();
    data["COORDENADA_NORTE"] = _EspecieMaderaAserradaEdit.frm.find("#txtCNorte").val();
    data["ESPESOR"] = _EspecieMaderaAserradaEdit.frm.find("#txtEspesor").val();
    data["ANCHO"] = _EspecieMaderaAserradaEdit.frm.find("#txtAncho").val();
    data["LARGO"] = _EspecieMaderaAserradaEdit.frm.find("#txtLargo").val();
    data["OBSERVACION"] = _EspecieMaderaAserradaEdit.frm.find("#txtObservacion").val();
    return data;
}

_EspecieMaderaAserradaEdit.fnCustomValidateForm = function () {
    if (_renderComboEspecie.fnGetCodEspecie() == null) {
        utilSigo.toastWarning("Aviso", "Seleccione la especie a registrar"); return false;
    }
    return true;
}

_EspecieMaderaAserradaEdit.fnSubmitForm = function () {
    _EspecieMaderaAserradaEdit.frm.submit();
}

_EspecieMaderaAserradaEdit.fnInit = function (data) {

    _EspecieMaderaAserradaEdit.frm = $("#frmItemMaderaAserradaEdit");

    _renderComboEspecie.fnInit("FORESTAL", '', '');
    
    _EspecieMaderaAserradaEdit.frm.find("#hdfCodSecuencial").val("0");

    $.fn.select2.defaults.set("theme", "bootstrap4");
    _EspecieMaderaAserradaEdit.frm.find("#ddlZonaId").select2({ minimumResultsForSearch: -1 });

    _EspecieMaderaAserradaEdit.fnLoadDatos(data);

    //=====-----Para el registro de datos del formulario-----=====
    //Validación personalizada
    jQuery.validator.addMethod("invalidFrmTroza", function (value, element) {
        switch ($(element).attr('id')) {
            case 'ddlZonaId':
                return (value == '0000000') ? false : true;
                break
        }
    });

    _EspecieMaderaAserradaEdit.frm.validate(utilSigo.fnValidate({
        rules: {
            txtCodigo: { required: true },
            txtPieza: { required: true },
            ddlZonaId: { invalidFrmTroza: true },
            txtCEste: { required: true },
            txtCNorte: { required: true },
            txtEspesor: { required: true },
            txtAncho: { required: true },
            txtLargo: { required: true }
        },
        messages: {
            txtCodigo: { required: "Ingrese el código de la troza" },
            txtPieza: { required: "Ingrese el nro. de piezas o partes" },
            ddlZonaId: { invalidFrmTroza: "Seleccione la zona UTM" },
            txtCEste: { required: "Ingrese la coordenada este" },
            txtCNorte: { required: "Ingrese la coordenada norte" },
            txtEspesor: { required: "Ingrese el espesor (m)" },
            txtAncho: { required: "Ingrese el ancho (m)" },
            txtLargo: { required: "Ingrese el largo (m)" }
        },
        fnSubmit: function (form) {
            if (_EspecieMaderaAserradaEdit.fnCustomValidateForm()) {
                var oEspecie = utilSigo.fnConvertArrayToObject(_EspecieMaderaAserradaEdit.fnSetDatos());
                var url = urlLocalSigo + "Supervision/ManInforme/GrabarEspecieMaderaAserrada";
                var option = { url: url, datos: JSON.stringify(oEspecie), type: 'POST' };
                utilSigo.fnAjax(option, function (data) {
                    if (data.success) {
                        oEspecie["RegEstado"] = 0;
                        _EspecieMaderaAserradaEdit.fnSaveForm(oEspecie);
                        utilSigo.toastSuccess("Aviso", "Datos guardados correctamente");
                        Limpiar();
                    }
                    else {
                        utilSigo.toastWarning("Aviso", data.msj);
                    }
                });
            }
        }
    }));
    //Validación de controles que usan Select2
    _EspecieMaderaAserradaEdit.frm.find("select.select2-hidden-accessible").on("change", function (e) {
        $(this).valid();
    });
    
}

_EspecieMaderaAserradaEdit.fnSearch = function () {

    var codInforme = $("#hdfCodInforme").val();
    var numPoa = $("#hdfNumPoa").val();
    var codigo = $("#txtCodigoB").val();

    $("#txtCodigo").val(codigo);

    var url = urlLocalSigo + "Supervision/ManInforme/GetDatosMaderaAserrada";
    var option = {
        url: url,
        datos: JSON.stringify({
            asCodInforme: codInforme,
            asNumPoa: numPoa,
            asCodigo: codigo
        }),
        type: 'POST'
    };

    utilSigo.fnAjax(option, function (data) {
        if (data.success) {
            if (data.data.length == 1) {
                Limpiar();
                _EspecieMaderaAserradaEdit.fnLoadDatos(data);
            }
            else {
                if (data.data.length == 0) {
                    Limpiar();
                    utilSigo.toastWarning("Aviso", "No se encontraron resultados");
                }
                else {
                    var mensaje = "";
                    for (var i = 0; i < data.data.length; i++) {
                        var pri = 'Bloque:\u00A0';
                        var seg = ',\u00A0Faja:\u00A0';
                        var este = data.data[i].COORDENADA_ESTE;
                        var norte = data.data[i].COORDENADA_NORTE;

                        var aviso = pri + bloque + seg + faja + '\u00A0y\u00A0Coordenadas:\u00A0' + este + ',' + norte;

                        mensaje += "<a href='#' onclick=AbrirOpciones('" + i + "'); data-dismiss='modal'>" + aviso + "</a>" + "<br/>";
                    }
                    utilSigo.dialogConfirma("Se encontro mas de un registro:", mensaje, function (r) {
                        if (r) {
                            return false;
                        }
                    });
                }
            }
        }
        else {
            utilSigo.toastWarning("Aviso", data.msj);

            setTimeout(function () {
                $('#dvAlerta').fadeOut('fast');
            }, 1000);
        }
    })
}

utilSigo.dialogConfirma = function (_title, _msg, fnOk, fnCancel) {
    //var ventana_alto = $(window).height();
    var altNavegador = $(window).height();
    bootbox.dialog({
        title: "",
        message: _title + "<br/>" + "<br/>" + _msg,
        buttons: {
            Cancel: {
                label: 'Cancelar',
                className: "btn-sm",
                iconFa: 'fa-times',
                callback: fnCancel
            }
        }
    }).css({ top: altNavegador / 5 });

    //Poner el enfoque en el modal que se encuentra abierto (problema con el scroll)
    $(document).unbind("bootbox.modal").on('hidden.bs.modal', function () {
        if ($('.modal:visible').length) { // check whether parent modal is opend after child modal close
            $('body').addClass('modal-open'); // if open mean length is 1 then add a bootstrap css class to body of the page
        }
    });
};

function AbrirOpciones(valores) {
    var separador = "#",
        arreglo = valores.split(separador);
    var a = arreglo[0];
    var b = arreglo[1];

    $("#txtBloqueB").val(a);
    $("#txtFajaB").val(b);

    Limpiar();

    _EspecieMaderaAserradaEdit.fnSearch();

}

function Limpiar() {

    var sel = document.getElementById("ddlRenderComboEspecieId");
    sel.remove(sel.selectedIndex);

    _EspecieMaderaAserradaEdit.frm = $("#frmItemMaderaAserradaEdit");    
    var regEstado = "1"; // Nuevo

    _EspecieMaderaAserradaEdit.frm.find("#hdfRegEstado").val(regEstado);
    _EspecieMaderaAserradaEdit.frm.find("#hdfCodSecuencial").val("0");
    _EspecieMaderaAserradaEdit.frm.find("#hdfCodEspecie").val("");
    _EspecieMaderaAserradaEdit.frm.find("#txtEspecie").val("");
    _EspecieMaderaAserradaEdit.frm.find("#txtCodigo").val("");
    _EspecieMaderaAserradaEdit.frm.find("#txtPieza").val("");
    _EspecieMaderaAserradaEdit.frm.find("#txtEspesor").val("");
    _EspecieMaderaAserradaEdit.frm.find("#ddlZonaId").val("0000000");
    _EspecieMaderaAserradaEdit.frm.find("#txtCEste").val("");
    _EspecieMaderaAserradaEdit.frm.find("#txtAncho").val("");
    _EspecieMaderaAserradaEdit.frm.find("#txtCNorte").val("");
    _EspecieMaderaAserradaEdit.frm.find("#txtLargo").val("");
    _EspecieMaderaAserradaEdit.frm.find("#txtObservacion").val("");
    _renderComboEspecie.fnInit("FORESTAL", '', '');

}