"use strict";
var _EspecieTrozaCampoEdit = {};

_EspecieTrozaCampoEdit.fnSaveForm = function (data) { /*implementado desde donde se instancia*/ }

_EspecieTrozaCampoEdit.fnLoadDatos = function (data) {
    var regEstado = "1";
    _EspecieTrozaCampoEdit.frm = $("#frmItemTrozaCampoEdit");
    if (data != null && data != "") {
        if (data.data[0]["CODIGO"] != "") {
            regEstado = "0";
        }   
        _EspecieTrozaCampoEdit.frm.find("#hdfRegEstado").val(regEstado);
        _EspecieTrozaCampoEdit.frm.find("#hdfCodSecuencial").val(data.data[0]["COD_SECUENCIAL"]);
        _EspecieTrozaCampoEdit.frm.find("#hdfCodTHabilitante").val(data.data[0]["COD_THABILITANTE"]);
        _EspecieTrozaCampoEdit.frm.find("#txtCodigo").val(data.data[0]["CODIGO"]);
        _EspecieTrozaCampoEdit.frm.find("#ddlZonaId").val(data.data[0]["ZONA"]);
        _EspecieTrozaCampoEdit.frm.find("#txtCEste").val(data.data[0]["COORDENADA_ESTE"]);
        _EspecieTrozaCampoEdit.frm.find("#txtCNorte").val(data.data[0]["COORDENADA_NORTE"]);
        _EspecieTrozaCampoEdit.frm.find("#txtDap1").val(data.data[0]["DAP1"]);
        _EspecieTrozaCampoEdit.frm.find("#txtDap2").val(data.data[0]["DAP2"]);
        _EspecieTrozaCampoEdit.frm.find("#txtLc").val(data.data[0]["LC"]);
        _EspecieTrozaCampoEdit.frm.find("#txtObservacion").val(data.data[0]["OBSERVACION"]);
        _renderComboEspecie.fnInit("FORESTAL", data.data[0]["COD_ESPECIES"], data.data[0]["ESPECIES"]);
    } else {
        _EspecieTrozaCampoEdit.frm.find("#hdfRegEstado").val("1");
        _EspecieTrozaCampoEdit.frm.find("#hdfCodSecuencial").val("0");
        _renderComboEspecie.fnInit("FORESTAL", "", "");
    }
}

_EspecieTrozaCampoEdit.fnSetDatos = function () {
    var data = [];
    var regEstado = _EspecieTrozaCampoEdit.frm.find("#hdfRegEstado").val();
    data["RegEstado"] = regEstado == "0" ? "2" : regEstado;
    data["COD_INFORME"] = _EspecieTrozaCampoEdit.frm.find("#hdfCodInforme").val();
    data["NUM_POA"] = _EspecieTrozaCampoEdit.frm.find("#hdfNumPoa").val();
    data["COD_SECUENCIAL"] = _EspecieTrozaCampoEdit.frm.find("#hdfCodSecuencial").val();
    data["COD_THABILITANTE"]=_EspecieTrozaCampoEdit.frm.find("#hdfCodTHabilitante").val();
    data["CODIGO"] = _EspecieTrozaCampoEdit.frm.find("#txtCodigo").val();
    data["COD_ESPECIES"] = _renderComboEspecie.fnGetCodEspecie();
    data["ESPECIES"] = _renderComboEspecie.fnGetEspecie();
    data["ZONA"] = _EspecieTrozaCampoEdit.frm.find("#ddlZonaId").val();
    data["COORDENADA_ESTE"] = _EspecieTrozaCampoEdit.frm.find("#txtCEste").val();
    data["COORDENADA_NORTE"] = _EspecieTrozaCampoEdit.frm.find("#txtCNorte").val();
    data["DAP1"] = _EspecieTrozaCampoEdit.frm.find("#txtDap1").val();
    data["DAP2"] = _EspecieTrozaCampoEdit.frm.find("#txtDap2").val();
    data["LC"] = _EspecieTrozaCampoEdit.frm.find("#txtLc").val();
    data["OBSERVACION"] = _EspecieTrozaCampoEdit.frm.find("#txtObservacion").val();
    return data;
}

_EspecieTrozaCampoEdit.fnCustomValidateForm = function () {
    if (_renderComboEspecie.fnGetCodEspecie() == null) {
        utilSigo.toastWarning("Aviso", "Seleccione la especie a registrar"); return false;
    }
    return true;
}

_EspecieTrozaCampoEdit.fnSubmitForm = function () {
    _EspecieTrozaCampoEdit.frm.submit();
}

_EspecieTrozaCampoEdit.fnInit = function (data) {
    
    _EspecieTrozaCampoEdit.frm = $("#frmItemTrozaCampoEdit");

    _renderComboEspecie.fnInit("FORESTAL", '', '');

    var regEstado = "1"; // Nuevo

    _EspecieTrozaCampoEdit.frm.find("#hdfRegEstado").val(regEstado);
    _EspecieTrozaCampoEdit.frm.find("#hdfCodSecuencial").val("0");

    $.fn.select2.defaults.set("theme", "bootstrap4");
    _EspecieTrozaCampoEdit.frm.find("#ddlZonaId").select2({ minimumResultsForSearch: -1 });

    _EspecieTrozaCampoEdit.fnLoadDatos(data);

    //=====-----Para el registro de datos del formulario-----=====
    //Validación personalizada
    jQuery.validator.addMethod("invalidFrmTroza", function (value, element) {
        switch ($(element).attr('id')) {
            case 'ddlZonaId':
                return (value == '0000000') ? false : true;
                break
        }
    });
    _EspecieTrozaCampoEdit.frm.validate(utilSigo.fnValidate({
        rules: {
            txtCodigo: { required: true },
            ddlZonaId: { invalidFrmTroza: true },
            txtCEste: { required: true },
            txtCNorte: { required: true },
            txtDap1: { required: true },
            txtDap2: { required: true },
            txtLc: { required: true }
        },
        messages: {
            txtCodigo: { required: "Ingrese el código de la troza" },
            ddlZonaId: { invalidFrmTroza: "Seleccione la zona UTM" },
            txtCEste: { required: "Ingrese la coordenada este" },
            txtCNorte: { required: "Ingrese la coordenada norte" },
            txtDap1: { required: "Ingrese el DAP 1 (cm)" },
            txtDap2: { required: "Ingrese el DAP 2 (cm)" },
            txtLc: { required: "Ingrese el LC (m)" }
        },
        fnSubmit: function (form) {
            if (_EspecieTrozaCampoEdit.fnCustomValidateForm()) {
                var oEspecie = utilSigo.fnConvertArrayToObject(_EspecieTrozaCampoEdit.fnSetDatos());
                var url = urlLocalSigo + "Supervision/ManInforme/GrabarEspecieTrozaCampo";
                var option = { url: url, datos: JSON.stringify(oEspecie), type: 'POST' };
                utilSigo.fnAjax(option, function (data) {
                    if (data.success) {
                        _EspecieTrozaCampoEdit.fnSaveForm(oEspecie);
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
    _EspecieTrozaCampoEdit.frm.find("select.select2-hidden-accessible").on("change", function (e) {
        $(this).valid();
    });

}

_EspecieTrozaCampoEdit.fnSearch = function () {

    var codInforme = $("#hdfCodInforme").val();
    var codTHabilitante = $("#hdfCodTHabilitante").val();
    var numPoa = $("#hdfNumPoa").val();
    var codigo = $("#txtCodigoB").val();

    $("#txtCodigo").val(codigo);

    var url = urlLocalSigo + "Supervision/ManInforme/GetDatosTrozaCampo";
    var option = {
        url: url,
        datos: JSON.stringify({
            asCodInforme: codInforme,
            asCodTHabilitante: codTHabilitante,
            asNumPoa: numPoa,
            asCodigo: codigo
        }),
        type: 'POST'
    };

    utilSigo.fnAjax(option, function (data) {
        if (data.success) {
            if (data.data.length == 1) {
                Limpiar();
                _EspecieTrozaCampoEdit.fnLoadDatos(data);
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
            //Ok: {
            //    label: 'Aceptar',
            //    className: 'btn-sm  btn-primary',
            //    iconFa: 'fa-check',
            //    callback: fnOk
            //},
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

    _EspecieTrozaCampoEdit.fnSearch();

}

function Limpiar() {
    var sel = document.getElementById("ddlRenderComboEspecieId");
    sel.remove(sel.selectedIndex);

    _EspecieTrozaCampoEdit.frm = $("#frmItemTrozaCampoEdit");
    var regEstado = "1"; // Nuevo

    _EspecieTrozaCampoEdit.frm.find("#hdfRegEstado").val(regEstado);
    _EspecieTrozaCampoEdit.frm.find("#hdfCodSecuencial").val("0");
    _EspecieTrozaCampoEdit.frm.find("#hdfCodEspecie").val("");
    _EspecieTrozaCampoEdit.frm.find("#txtEspecie").val("");
    _EspecieTrozaCampoEdit.frm.find("#ddlCoincideEspecieId").val("-");
    _EspecieTrozaCampoEdit.frm.find("#txtBloque").val("");
    _EspecieTrozaCampoEdit.frm.find("#txtBloqueCampo").val("");
    _EspecieTrozaCampoEdit.frm.find("#txtFaja").val("");
    _EspecieTrozaCampoEdit.frm.find("#txtFajaCampo").val("");
    _EspecieTrozaCampoEdit.frm.find("#txtCodigo").val("");
    _EspecieTrozaCampoEdit.frm.find("#txtCodigoCampo").val("");
    _EspecieTrozaCampoEdit.frm.find("#txtDap").val("");
    _EspecieTrozaCampoEdit.frm.find("#txtDapCampo").val("");
    _EspecieTrozaCampoEdit.frm.find("#txtDapCampo1").val("");
    _EspecieTrozaCampoEdit.frm.find("#txtDapCampo2").val("");
    _EspecieTrozaCampoEdit.frm.find("#ddlMetodoMedirDapId").val("0000000");
    _EspecieTrozaCampoEdit.frm.find("#txtAc").val("");
    _EspecieTrozaCampoEdit.frm.find("#txtAcCampo").val("");
    _EspecieTrozaCampoEdit.frm.find("#txtZona").val("");
    _EspecieTrozaCampoEdit.frm.find("#ddlZonaCampoId").val("0000000");
    _EspecieTrozaCampoEdit.frm.find("#txtCEste").val("");
    _EspecieTrozaCampoEdit.frm.find("#txtCEsteCampo").val("");
    _EspecieTrozaCampoEdit.frm.find("#txtCNorte").val("");
    _EspecieTrozaCampoEdit.frm.find("#txtCNorteCampo").val("");
    _EspecieTrozaCampoEdit.frm.find("#txtEstado").val("");
    _EspecieTrozaCampoEdit.frm.find("#ddlEstadoCampoId").val("0000000");
    _EspecieTrozaCampoEdit.frm.find("#txtCondicion").val("");
    _EspecieTrozaCampoEdit.frm.find("#ddlCondicionEspCampoId").val("0000000");
    _EspecieTrozaCampoEdit.frm.find("#ddlFenologiaId").val("0000001");
    _EspecieTrozaCampoEdit.frm.find("#ddlCFusteId").val("0000000");
    _EspecieTrozaCampoEdit.frm.find("#ddlFCopaId").val("0000000");
    _EspecieTrozaCampoEdit.frm.find("#ddlPCopaId").val("0000000");
    _EspecieTrozaCampoEdit.frm.find("#ddlEstadoFitoId").val("0000000");
    _EspecieTrozaCampoEdit.frm.find("#ddlGradoInfestId").val("0000000");
    _EspecieTrozaCampoEdit.frm.find("#txtCantSobreEst").val("");
    _EspecieTrozaCampoEdit.frm.find("#txtPorcSobreEst").val("");
    _EspecieTrozaCampoEdit.frm.find("#txtCantSubEst").val("");
    _EspecieTrozaCampoEdit.frm.find("#txtPorcSubEst").val("");
    _EspecieTrozaCampoEdit.frm.find("#txtObservacion").val("");
    _renderComboEspecie.fnInit("FORESTAL", '', '');

}
