"use strict";
var _bPerAddEdit = {};

_bPerAddEdit.url = initSigo.urlControllerGeneral + "/_Persona";
_bPerAddEdit.tipoPersona = divBuscarPN;
_bPerAddEdit.codPTipo = "";
_bPerAddEdit.DataTipoCargo = [];

_bPerAddEdit.fnAsignarDatos = function (value) { };

_bPerAddEdit.fnLoadData = function (obj) {
    _bPerAddEdit.DataTipoCargo = obj;
};

_bPerAddEdit.fnInitEventos = function () {
    _bPerAddEdit.content.find("[name=rdTipoPersona]").change(function () {
        var tipoPersona = $(this).val();
        if (tipoPersona == "N") {
            $("#dvPJuridica").hide();
            $("#dvTituloPNatural").show();
            $("#dvPNatural").show();
            _bPerAddEdit.tipoPersona = "N";
            _bPerAddEdit.configValidateFormN();
            _bPerAddEdit.frm.find("#ddlItemPN_DITipoId").val($(_bPerAddEdit.frm.find("#ddlItemPN_DITipoId")[0].childNodes[0]).val());
            _bPerAddEdit.limpiarFormularioPN();
            _bPerAddEdit.frm.find("#txtTelefono").val("");
            _bPerAddEdit.frm.find("#txtCorreo").val("");
            _bPerAddEdit.fnInitEventosN();
        } else {
            $("#dvPNatural").hide();
            $("#dvTituloPNatural").hide();
            $("#dvPJuridica").show();
            _bPerAddEdit.tipoPersona = "J";
            _bPerAddEdit.configValidateFormJ();
            _bPerAddEdit.limpiarFormularioPJ();
            _bPerAddEdit.frm.find("#txtTelefono").val("");
            _bPerAddEdit.frm.find("#txtCorreo").val("");
            _bPerAddEdit.fnInitEventosJ();
        }
        $("#frmPersona").show();
    });

    /*_bPerAddEdit.frm.find("[name=chkNoconsignaDNIPN]").change(function () {
        if ($(this).is(":checked")) {
            _bPerAddEdit.frm.find("#txtItemPN_DINumero").val('00000000');
            _bPerAddEdit.frm.find("#txtItemPN_DINumero").prop("readonly", true);
        }
        else {
            _bPerAddEdit.frm.find("#txtItemPN_DINumero").val('');
            _bPerAddEdit.frm.find("#txtItemPN_DINumero").prop("readonly", false);
        }
    });

    _bPerAddEdit.frm.find("[name=chkNoconsignaRUCPN]").change(function () {
        if ($(this).is(":checked")) {
            _bPerAddEdit.frm.find("#txtItemPN_DIRUC").val('00000000000');
            _bPerAddEdit.frm.find("#txtItemPN_DIRUC").prop("readonly", true);
        }
        else {
            _bPerAddEdit.frm.find("#txtItemPN_DIRUC").val('');
            _bPerAddEdit.frm.find("#txtItemPN_DIRUC").prop("readonly", false);
        }
    });

    _bPerAddEdit.frm.find("[name=chkNoconsignaRUCPJ]").change(function () {
        if ($(this).is(":checked")) {
            _bPerAddEdit.frm.find("#txtItemPJ_RUC").val('00000000000');
            _bPerAddEdit.frm.find("#txtItemPJ_RUC").prop("readonly", true);
        }
        else {
            _bPerAddEdit.frm.find("#txtItemPJ_RUC").val('');
            _bPerAddEdit.frm.find("#txtItemPJ_RUC").prop("readonly", false);
        }
    });*/
};

_bPerAddEdit.cargarUbigeoModal = function () {
    var url = urlLocalSigo + "General/Controles/_Ubigeo";
    var option = { url: url, type: 'POST', datos: {}, divId: "personaUbigeoModal" };
    utilSigo.fnOpenModal(option, function () {
        _Ubigeo.fnSelectUbigeo = function (_ubigeoText, _ubigeoId) {
            if (_bPerAddEdit.tipoPersona == "N") {
                _bPerAddEdit.frm.find("#hdfItemPN_DLUbigeo").val(_ubigeoId);
                _bPerAddEdit.frm.find("#lblItemPN_DLUbigeo").val(_ubigeoText);
            }
            if (_bPerAddEdit.tipoPersona == "J") {
                _bPerAddEdit.frm.find("#hdfItemPJ_DLUbigeo").val(_ubigeoId);
                _bPerAddEdit.frm.find("#lblItemPJ_DLUbigeo").val(_ubigeoText);
            }
            $("#personaUbigeoModal").modal('hide');
        };

        var codUbigeo = "";
        if (_bPerAddEdit.tipoPersona == "N")
            codUbigeo = _bPerAddEdit.frm.find("#hdfItemPN_DLUbigeo").val();
        if (_bPerAddEdit.tipoPersona == "J")
            codUbigeo = _bPerAddEdit.frm.find("#hdfItemPJ_DLUbigeo").val();

        _Ubigeo.fnLoadModalView(codUbigeo);
    });
};

//*****************PERSONA JURIDICA*************
_bPerAddEdit.fnInitEventosJ = function () {
    _bPerAddEdit.frm.find("#divBuscarPJ").click(function () {
        if (_bPerAddEdit.content.find("#codigoPersona").val() == "") {
            _bPerAddEdit.buscarPersonaNJ();
        }
    });
    _bPerAddEdit.frm.find("#btnUbigeoJ").click(function () {
        _bPerAddEdit.cargarUbigeoModal();
    });

    if (_bPerAddEdit.content.find("#codigoPersona").val() != "") {
        $("#divBuscarPJ").hide();
        $("#dvItemPJ_Noconsigna").hide();

        _bPerAddEdit.frm.find("#txtItemPJ_RUC").attr("readOnly", true);

        //if (_bPerAddEdit.content.find("#hdfOpc").val() == 1) {
        $("#dvItemPJ_Ubigeo").hide();
        $("#dvItemTelefonoCorreo").hide();

        _bPerAddEdit.frm.find("#txtItemPJ_RSocial").attr("readOnly", true);
        //}
    }
};

_bPerAddEdit.limpiarFormularioPJ = function () {
    _bPerAddEdit.frm.find("#txtItemPJ_RUC").val("");
    _bPerAddEdit.frm.find("#txtItemPJ_RUC").focus();
    _bPerAddEdit.frm.find("#txtItemPJ_RSocial").val("");
    //_bPerAddEdit.frm.find("#chkNoconsignaRUCPJ").prop("checked", false);
    _bPerAddEdit.frm.find("#lblItemPJ_DLUbigeo").val("");
    _bPerAddEdit.frm.find("#hdfItemPJ_DLUbigeo").val("");
    _bPerAddEdit.frm.find("#hdlblItemPJ_DLUbigeo").val("");
    _bPerAddEdit.frm.find("#txtItemPJ_DLDireccion").val("");
};

_bPerAddEdit.configValidateFormJ = function () {
    jQuery.validator.addMethod("invalidFrmPerAddEditJ", function (value, element) {
        switch ($(element).attr('id')) {
            case 'ddlITipoCargoId': return (value == '' || value == []) ? false : true;
        }
    });
    var objValida = {
        focusInvalid: true,
        rules: {
            txtItemPJ_RUC: { required: true },
            txtItemPJ_RSocial: { required: true },
            txtItemPJ_DLDireccion: { required: true },
            ddlITipoCargoId: { invalidFrmPerAddEditJ: true }
        },
        messages: {
            txtItemPJ_RUC: { required: "Ingrese RUC" },
            txtItemPJ_RSocial: { required: "Ingrese razón social" },
            txtItemPJ_DLDireccion: { required: "Ingrese dirección" },
            ddlITipoCargoId: { invalidFrmPerAddEditJ: "Seleccione el tipo de cargo" }
        },
        errorPlacement: function (error, element) {
            var lElement = $(element);
            var lElementTipo;
            //Para combobox tipo select2
            if (lElement.hasClass("select2-hidden-accessible")) {
                lElementTipo = lElement.closest('.form-group');
                lElementTipo.addClass('has-error');
            } else {
                lElementTipo = lElement;
                lElementTipo.addClass('border-danger');
            }
            lElementTipo.attr('data-toggle', 'tooltip');
            lElementTipo.attr('data-placement', 'top');
            lElementTipo.attr('data-original-title', error.text());
            $('[data-toggle="tooltip"]').tooltip();
        },
        success: function (label, element) {
            var lElement = $(element);
            var lElementTipo;
            if (lElement.hasClass("select2-hidden-accessible")) {
                lElementTipo = lElement.closest('.form-group');
                lElementTipo.removeClass('has-error');
            }
            else {
                lElementTipo = lElement;
                lElementTipo.removeClass('border-danger');
            }

            lElementTipo.removeAttr('data-toggle');
            lElementTipo.removeAttr('data-placement');
            lElementTipo.removeAttr('data-original-title');
        }
    };
    _bPerAddEdit.frm.validate(objValida);
};

//*****************PERSONA NATURAL*************
_bPerAddEdit.configValidateFormN = function () {
    jQuery.validator.addMethod("invalidFrmPerAddEditN", function (value, element) {
        switch ($(element).attr('id')) {
            case 'ddlItemPN_DITipoId': return (value == '0000000') ? false : true;
            case 'ddlITipoCargoId': return (value == '' || value == []) ? false : true;
            case 'txtItemPN_DIRUC':
                if (_bPerAddEdit.content.find("#hdfFormulario").val() == "THabilitante" && _bPerAddEdit.content.find("#hdfCodMod").val() == "0000015") {
                    return (value.trim() == "") ? false : true;
                }
                else return true;
            case 'txtItemPN_DLDireccion':
                if (_bPerAddEdit.frm.find("#lblItemPN_DLUbigeo").val() != null && _bPerAddEdit.frm.find("#lblItemPN_DLUbigeo").val().trim() != "") {
                    return (value.trim() == "") ? false : true;
                }
                else return true;
        }
    });
    var objValida = {
        focusInvalid: true,
        rules: {
            ddlItemPN_DITipoId: { invalidFrmPerAddEditN: true },
            txtItemPN_DINumero: { required: true },
            txtItemPN_DIRUC: { invalidFrmPerAddEditN: true },
            txtItemPN_APaterno: { required: true },
            txtItemPN_AMaterno: { required: true },
            txtItemPN_Nombres: { required: true },
            ddlITipoCargoId: { invalidFrmPerAddEditN: true },
            txtItemPN_DLDireccion: { invalidFrmPerAddEditN: true }
        },
        messages: {
            ddlItemPN_DITipoId: { invalidFrmPerAddEditN: "Seleccione el tipo de documento" },
            txtItemPN_DINumero: { required: "Ingrese número de documento" },
            txtItemPN_DIRUC: { invalidFrmPerAddEditN: "Ingrese RUC" },
            txtItemPN_APaterno: { required: "Ingrese Apellido Paterno" },
            txtItemPN_AMaterno: { required: "Ingrese Apellido Materno" },
            txtItemPN_Nombres: { required: "Ingrese Nombres" },
            ddlITipoCargoId: { invalidFrmPerAddEditN: "Seleccione el tipo de cargo" },
            txtItemPN_DLDireccion: { invalidFrmPerAddEditN: "Ingrese dirección" }
        },
        errorPlacement: function (error, element) {
            var lElement = $(element);
            var lElementTipo;
            //Para combobox tipo select2
            if (lElement.hasClass("select2-hidden-accessible")) {
                lElementTipo = lElement.closest('.form-group');
                lElementTipo.addClass('has-error');
            } else {
                lElementTipo = lElement;
                lElementTipo.addClass('border-danger');
            }
            lElementTipo.attr('data-toggle', 'tooltip');
            lElementTipo.attr('data-placement', 'top');
            lElementTipo.attr('data-original-title', error.text());
            $('[data-toggle="tooltip"]').tooltip();
        },
        success: function (label, element) {
            var lElement = $(element);
            var lElementTipo;
            if (lElement.hasClass("select2-hidden-accessible")) {
                lElementTipo = lElement.closest('.form-group');
                lElementTipo.removeClass('has-error');
            }
            else {
                lElementTipo = lElement;
                lElementTipo.removeClass('border-danger');
            }

            lElementTipo.removeAttr('data-toggle');
            lElementTipo.removeAttr('data-placement');
            lElementTipo.removeAttr('data-original-title');
        }
    };
    _bPerAddEdit.frm.validate(objValida);
};

_bPerAddEdit.ValidarEmail = function (valor) {
    var resp = true;
    var re = /^[-\w.%+]{1,64}@(?:[A-Z0-9-]{1,63}\.){1,125}[A-Z]{2,63}$/i;

    if (!re.test(valor)) {
        resp = false;
    }

    return resp;
};

_bPerAddEdit.save = function () {
    let datos;
    let next = true;

    if (_bPerAddEdit.tipoPersona == "TODOS") {
        utilSigo.toastError("Error", "Seleccione el tipo de persona a registrar");
        return false;
    }

    if (_bPerAddEdit.content.find("#codigoPersona").val() == "") {
        next = _bPerAddEdit.frm.valid();
    }

    if (next) {
        if (_bPerAddEdit.tipoPersona == "N") {
            let ddlItemPN_DITipoId = _bPerAddEdit.frm.find("#ddlItemPN_DITipoId").val();
            let txtItemPN_DINumero = _bPerAddEdit.frm.find("#txtItemPN_DINumero").val();
            let txtItemPN_DIRUC = _bPerAddEdit.frm.find("#txtItemPN_DIRUC").val();
            let txtItemPN_APaterno = _bPerAddEdit.frm.find("#txtItemPN_APaterno").val().toUpperCase();
            let txtItemPN_AMaterno = _bPerAddEdit.frm.find("#txtItemPN_AMaterno").val().toUpperCase();
            let txtItemPN_Nombres = _bPerAddEdit.frm.find("#txtItemPN_Nombres").val().toUpperCase();

            if (_bPerAddEdit.content.find("#codigoPersona").val() == "") {
                if (_bPerAddEdit.frm.find("#txtItemPN_DLDireccion").val() != null && _bPerAddEdit.frm.find("#txtItemPN_DLDireccion").val().trim() != "") {
                    if (!utilSigo.ValidaTexto("lblItemPN_DLUbigeo", "Seleccione Ubigeo")) return false;
                }
            }

            let hdfItemPN_DLUbigeo = _bPerAddEdit.frm.find("#hdfItemPN_DLUbigeo").val();
            let hdlblItemPN_DLUbigeo = _bPerAddEdit.frm.find("#hdlblItemPN_DLUbigeo").val();
            let txtItemPN_DLDireccion = _bPerAddEdit.frm.find("#txtItemPN_DLDireccion").val();

            datos = {
                ddlItemPN_DITipoId, txtItemPN_DINumero, txtItemPN_DIRUC, txtItemPN_APaterno, txtItemPN_AMaterno, txtItemPN_Nombres,
                hdfItemPN_DLUbigeo, hdlblItemPN_DLUbigeo, txtItemPN_DLDireccion
            };
        }
        else if (_bPerAddEdit.tipoPersona == "J") {
            let txtItemPJ_RUC = _bPerAddEdit.frm.find("#txtItemPJ_RUC").val();
            let txtItemPJ_RSocial = _bPerAddEdit.frm.find("#txtItemPJ_RSocial").val();
            let txtItemPJ_FichaRegistral = _bPerAddEdit.frm.find("#txtItemPJ_FichaRegistral").val();
            let txtItemPJ_DLDireccion = _bPerAddEdit.frm.find("#txtItemPJ_DLDireccion").val();

            if (_bPerAddEdit.content.find("#codigoPersona").val() == "") {
                if (!utilSigo.ValidaTexto("lblItemPJ_DLUbigeo", "Seleccione Ubigeo")) return false;
            }

            let hdfItemPJ_DLUbigeo = _bPerAddEdit.frm.find("#hdfItemPJ_DLUbigeo").val();
            let hdlblItemPJ_DLUbigeo = _bPerAddEdit.frm.find("#hdlblItemPJ_DLUbigeo").val();


            datos = { txtItemPJ_RUC, txtItemPJ_RSocial, txtItemPJ_FichaRegistral, hdfItemPJ_DLUbigeo, hdlblItemPJ_DLUbigeo, txtItemPJ_DLDireccion };
        }

        datos.codigoPersona = _bPerAddEdit.content.find("#codigoPersona").val();
        datos.tipoPersona = _bPerAddEdit.tipoPersona;

        if (_bPerAddEdit.content.find("#codigoPersona").val() == "") {
            if (_bPerAddEdit.frm.find("#txtCorreo").val() != null && _bPerAddEdit.frm.find("#txtCorreo").val().trim() != "") {
                if (!_bPerAddEdit.ValidarEmail(_bPerAddEdit.frm.find("#txtCorreo").val().trim())) {
                    utilSigo.toastError("Error", "El formato del correo ingresado es incorrecto");
                    _bPerAddEdit.frm.find("#txtCorreo").focus();
                    return false;
                }
            }
        }

        datos.txtTelefono = _bPerAddEdit.frm.find("#txtTelefono").val();
        datos.txtCorreo = _bPerAddEdit.frm.find("#txtCorreo").val();

        datos.txtINumRegFfs = _bPerAddEdit.frm.find("#txtINumRegFfs").val();
        datos.txtINumRegProf = _bPerAddEdit.frm.find("#txtINumRegProf").val();
        datos.txtICargo = _bPerAddEdit.frm.find("#txtICargo").val();
        datos.txtINumColegiatura = _bPerAddEdit.frm.find("#txtINumColegiatura").val();
        datos.ddlINivelAcademicoId = _bPerAddEdit.frm.find("#ddlINivelAcademicoId").val();
        datos.ddlIEspecialidadId = _bPerAddEdit.frm.find("#ddlIEspecialidadId").val();

        let codTipoCargo = "";

        _bPerAddEdit.frm.find("#ddlITipoCargoId option").each(function (index, item) {
            if ($(item).prop("selected") == true) {
                codTipoCargo += "," + $(item).val();
            }
        });
        _bPerAddEdit.frm.find("#hdfITipoCargo").val(codTipoCargo);
        datos.hdfITipoCargo = _bPerAddEdit.frm.find("#hdfITipoCargo").val();

        let anio = "", codMencion = "";

        if (codTipoCargo == "") {
            utilSigo.toastError("Error", "Seleccione al menos un tipo de cargo");
            _bPerAddEdit.frm.find("#ddlITipoCargoId").focus();
            return false;
        }
        else {
            let tipoCargo = codTipoCargo.split(',');

            for (let i = 1; i < tipoCargo.length; i++) {
                if (tipoCargo[i] == "0000020") {
                    anio = _bPerAddEdit.frm.find("#ddlAnioId").val();

                    if (!utilSigo.ValidaTexto("txtNroLicencia", "Ingrese Nro. Licencia")) return false;
                    if (!utilSigo.ValidaTexto("txtFecLicencia", "Ingrese Fecha de Otorgamiento")) return false;
                    if (!utilSigo.ValidaTexto("txtResolucion", "Ingrese Nro. Resolución Directoral")) return false;

                    if (_bPerAddEdit.frm.find("#ddlCategoriaId").val() == "0000000") {
                        utilSigo.toastError("Error", "Seleccione Categoría");
                        _bPerAddEdit.frm.find("#ddlCategoriaId").focus();
                        return false;
                    }
                    else {
                        _bPerAddEdit.frm.find("#ddlMencionRegenciaId option").each(function (index, item) {
                            if ($(item).prop("selected") == true) {
                                codMencion += "," + $(item).val();
                            }
                        });

                        if (codMencion == "") {
                            utilSigo.toastError("Error", "Seleccione al menos una mención de regencia");
                            _bPerAddEdit.frm.find("#ddlMencionRegenciaId").focus();
                            return false;
                        }
                    }

                    if (!utilSigo.ValidaTexto("txtCIP", "Ingrese Nro. CIP")) return false;
                    if (!utilSigo.ValidaCombo("ddlEstadoId", "Seleccione Estado")) return false;
                }
                else if (tipoCargo[i] == "0000099") {
                    if (!utilSigo.ValidaTexto("txtOtro", "Ingrese Otros: Descripción")) return false;
                }
            }
        }

        datos.ddlAnioId = anio;
        datos.txtNroLicencia = _bPerAddEdit.frm.find("#txtNroLicencia").val();
        datos.txtFecLicencia = _bPerAddEdit.frm.find("#txtFecLicencia").val();
        datos.txtResolucion = _bPerAddEdit.frm.find("#txtResolucion").val();
        datos.ddlCategoriaId = _bPerAddEdit.frm.find("#ddlCategoriaId").val();
        datos.hdfMencionRegencia = codMencion;
        datos.txtCIP = _bPerAddEdit.frm.find("#txtCIP").val();
        datos.ddlEstadoId = _bPerAddEdit.frm.find("#ddlEstadoId").val();
        datos.txtOtro = _bPerAddEdit.frm.find("#txtOtro").val();
        datos.RegEstadoPersona = _bPerAddEdit.content.find("#RegEstadoPersona").val();

        $.ajax({
            url: _bPerAddEdit.url,
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
                    _bPerAddEdit.fnAsignarDatos(_bPerAddEdit.content.find("#RegEstadoPersona").val());
                    _bPerAddEdit.closeModal();
                }
                else utilSigo.toastWarning("Aviso", data.msjError);
            }
        });
    }
};

_bPerAddEdit.fnInitEventosN = function () {
    _bPerAddEdit.frm.find("#ddlItemPN_DITipoId").change(function () {
        _bPerAddEdit.limpiarFormularioPN();
        _bPerAddEdit.frm.find("#txtTelefono").val("");
        _bPerAddEdit.frm.find("#txtCorreo").val("");
    });
    _bPerAddEdit.frm.find("#divBuscarPN").click(function () {
        if (_bPerAddEdit.content.find("#codigoPersona").val() == "") {
            _bPerAddEdit.buscarPersonaNJ();
        }
    });

    _bPerAddEdit.frm.find("#btnUbigeoN").click(function () {
        _bPerAddEdit.cargarUbigeoModal();
    });

    if (_bPerAddEdit.content.find("#codigoPersona").val() != "") {
        $("#divBuscarPN").hide();
        $("#dvItemPN_Noconsigna").hide();

        _bPerAddEdit.frm.find("#ddlItemPN_DITipoId").attr("disabled", true);
        _bPerAddEdit.frm.find("#txtItemPN_DINumero").attr("readOnly", true);

        //if (_bPerAddEdit.content.find("#hdfOpc").val() == 1) {
        $("#dvItemPN_Ubigeo").hide();
        $("#dvItemTelefonoCorreo").hide();

        _bPerAddEdit.frm.find("#txtItemPN_DIRUC").attr("readOnly", true);
        _bPerAddEdit.frm.find("#txtItemPN_APaterno").attr("readOnly", true);
        _bPerAddEdit.frm.find("#txtItemPN_AMaterno").attr("readOnly", true);
        _bPerAddEdit.frm.find("#txtItemPN_Nombres").attr("readOnly", true);
        //}
    }
};

_bPerAddEdit.limpiarFormularioPN = function () {
    _bPerAddEdit.frm.find("#txtItemPN_DINumero").val("");
    _bPerAddEdit.frm.find("#txtItemPN_DINumero").focus();
    _bPerAddEdit.frm.find("#txtItemPN_DIRUC").val("");
    //_bPerAddEdit.frm.find("#chkNoconsignaDNIPN").prop("checked", false);
    //_bPerAddEdit.frm.find("#chkNoconsignaRUCPN").prop("checked", false);
    _bPerAddEdit.frm.find("#txtItemPN_APaterno").val("");
    _bPerAddEdit.frm.find("#txtItemPN_AMaterno").val("");
    _bPerAddEdit.frm.find("#txtItemPN_Nombres").val("");
    _bPerAddEdit.frm.find("#lblItemPN_DLUbigeo").val("");
    _bPerAddEdit.frm.find("#hdfItemPN_DLUbigeo").val("");
    _bPerAddEdit.frm.find("#hdlblItemPN_DLUbigeo").val("");
    _bPerAddEdit.frm.find("#txtItemPN_DLDireccion").val("");

    switch (_bPerAddEdit.frm.find("#ddlItemPN_DITipoId").val()) {
        case '0000000': _bPerAddEdit.frm.find("#txtItemPN_DINumero").attr("maxlength", 8); break;
        case '0000001': _bPerAddEdit.frm.find("#txtItemPN_DINumero").attr("maxlength", 8); break;
        case '0000002': _bPerAddEdit.frm.find("#txtItemPN_DINumero").attr("maxlength", 12); break;
        case '0000006': _bPerAddEdit.frm.find("#txtItemPN_DINumero").attr("maxlength", 11); break;
    }
    _bPerAddEdit.frm.find("#dvItemPN_RazonSocial").hide();
};

_bPerAddEdit.closeModal = function () {
    _bPerAddEdit.content.closest(".modal").modal("hide");
};

_bPerAddEdit.buscarPersonaNJ = function () {
    var buspCriterio = "", buspValor = "", buspFormulario = _bPerAddEdit.content.find("#hdfFormulario").val();

    if (_bPerAddEdit.tipoPersona == "N") {
        buspValor = _bPerAddEdit.frm.find("#txtItemPN_DINumero").val();

        switch (_bPerAddEdit.frm.find("#ddlItemPN_DITipoId").val()) {
            case "0000001":
                buspCriterio = "DNI";
                if (buspValor.trim() == "" || buspValor == null) {
                    utilSigo.toastWarning("Aviso", "Ingrese el número de DNI a buscar");
                    return false;
                }
                if (buspValor.trim().length < 8) {
                    utilSigo.toastWarning("Aviso", "Ingrese los 8 caracteres del DNI a buscar");
                    return false;
                }
                break;
            case "0000006":
                buspCriterio = "RUC";
                if (buspValor.trim() == "" || buspValor == null) {
                    utilSigo.toastWarning("Aviso", "Ingrese el número de RUC a buscar");
                    return false;
                }
                if (buspValor.trim().length < 11) {
                    utilSigo.toastWarning("Aviso", "Ingrese los 11 caracteres del RUC a buscar");
                    return false;
                }
                break;
            default:
                utilSigo.toastWarning("Aviso", "La consulta para el tipo de documento no se encuentra disponible");
        }

    }
    else if (_bPerAddEdit.tipoPersona == "J") {
        buspCriterio = "RUC";
        buspValor = _bPerAddEdit.frm.find("#txtItemPJ_RUC").val();
        if (buspValor.trim() == "" || buspValor == null) {
            utilSigo.toastWarning("Aviso", "Ingrese el número de RUC a buscar");
            return false;
        }
        if (buspValor.trim().length < 11) {
            utilSigo.toastWarning("Aviso", "Ingrese los 11 caracteres del RUC a buscar");
            return false;
        }
    }

    $.ajax({
        url: urlLocalSigo + "General/Controles/buscarPersonaNJ_OSINFOR_PIDE",
        type: 'POST',
        data: { asBusCriterio: buspCriterio.trim(), asBusValor: buspValor.trim(), asFormulario: buspFormulario.trim() },
        dataType: 'json',
        beforeSend: utilSigo.beforeSendAjax,
        complete: utilSigo.completeAjax,
        error: utilSigo.errorAjax,
        success: function (data) {
            if (data.success)
                _bPerAddEdit.cargarDatosBusqueda(data.values);
            else utilSigo.toastWarning("Aviso", data.msj);
        }
    });
};

_bPerAddEdit.cargarDatosBusqueda = function (data) {
    if (_bPerAddEdit.tipoPersona == 'N') {
        var paterno = "", materno = "", nombres = "", num_dni = "", num_ruc = "", direccion = "", ubigeo = "", cod_ubigeo = "", raz_soc;
        var tipo_documento = _bPerAddEdit.frm.find("#ddlItemPN_DITipoId").val();
        _bPerAddEdit.frm.find("#dvItemPN_RazonSocial").hide();

        switch (tipo_documento) {
            case "0000001":
                paterno = data[2]; materno = data[3]; nombres = data[4]; num_dni = data[5];
                num_ruc = data[6]; direccion = data[9]; ubigeo = data[8]; cod_ubigeo = data[7];
                break;
            case "0000006":
                var razonSocial = data[0].split(' ');
                raz_soc = data[0];
                paterno = razonSocial.length > 0 ? razonSocial[0] : "";
                materno = razonSocial.length > 1 ? razonSocial[1] : "";
                nombres = razonSocial.length > 2 ? razonSocial[2] : "";
                nombres += razonSocial.length > 3 ? " " + razonSocial[3] : "";
                nombres += razonSocial.length > 4 ? " " + razonSocial[4] : "";
                nombres += razonSocial.length > 5 ? " " + razonSocial[5] : "";
                nombres += razonSocial.length > 6 ? " " + razonSocial[6] : "";
                num_dni = data[1]; num_ruc = data[1];
                direccion = data[4]; ubigeo = data[3]; cod_ubigeo = data[2];
                _bPerAddEdit.frm.find("#dvItemPN_RazonSocial").show();
                break;
        }

        _bPerAddEdit.limpiarFormularioPN();

        _bPerAddEdit.frm.find("#txtItemPN_APaterno").val(paterno);
        _bPerAddEdit.frm.find("#txtItemPN_AMaterno").val(materno);
        _bPerAddEdit.frm.find("#txtItemPN_Nombres").val(nombres);
        _bPerAddEdit.frm.find("#txtItemPN_DINumero").val(num_dni);
        _bPerAddEdit.frm.find("#txtItemPN_DIRUC").val(num_ruc);
        _bPerAddEdit.frm.find("#txtItemPN_DLDireccion").val(direccion);
        _bPerAddEdit.frm.find("#lblItemPN_DLUbigeo").val(ubigeo);
        _bPerAddEdit.frm.find("#hdlblItemPN_DLUbigeo").val(ubigeo);
        _bPerAddEdit.frm.find("#hdfItemPN_DLUbigeo").val(cod_ubigeo);
        _bPerAddEdit.frm.find("#lblItemPN_RazonSocial").text("Razón Social: " + raz_soc);
    } else {
        _bPerAddEdit.limpiarFormularioPJ();

        _bPerAddEdit.frm.find("#txtItemPJ_RSocial").val(data[0]);
        _bPerAddEdit.frm.find("#txtItemPJ_RUC").val(data[1]);
        _bPerAddEdit.frm.find("#txtItemPJ_DLDireccion").val(data[4]);
        _bPerAddEdit.frm.find("#hdfItemPJ_DLUbigeo").val(data[2]);
        _bPerAddEdit.frm.find("#lblItemPJ_DLUbigeo").val(data[3]);
        _bPerAddEdit.frm.find("#hdlblItemPJ_DLUbigeo").val(data[3]);
    }
};

_bPerAddEdit.fnVistaTipoCargo = function () {
    $("#dvINumRegFfs").hide();
    $("#dvINumRegProf").hide();
    $("#dvICargo").hide();
    $("#dvINumColegiatura").hide();
    $("#dvINivelAcademico").hide();
    $("#dvIEspecialidad").hide();
    $("#dvRegente").hide();
    $("#dvOtro").hide();

    if (_bPerAddEdit.frm.find("#ddlITipoCargoId").val() != undefined) {
        let sTiposCargos = "";
        _bPerAddEdit.frm.find("#ddlITipoCargoId option").each(function (index, item) {
            if ($(item).prop("selected") == true) {
                switch ($(item).val()) {
                    case '0000003':
                        $("#dvINumRegFfs").show();
                        $("#dvINumRegProf").show();
                        $("#dvICargo").show();
                        break;
                    case '0000004':
                    case '0000005':
                    case '0000006':
                        $("#dvICargo").show();
                        break;
                    case '0000007':
                        $("#dvINumColegiatura").show();
                        $("#dvINivelAcademico").show();
                        $("#dvIEspecialidad").show();
                        break;
                    case '0000020':
                        $("#dvRegente").show();

                        var sMencion = _bPerAddEdit.frm.find("#hdfMencionRegencia").val();
                        if (sMencion != undefined && sMencion != "") {
                            _bPerAddEdit.fnListarMencionRegencia(_bPerAddEdit.frm.find("#ddlCategoriaId").val());
                        }
                        break;
                    case '0000099':
                        $("#dvOtro").show();
                        break;
                }
            }
            else {
                switch ($(item).val()) {
                    case '0000003':
                        _bPerAddEdit.frm.find("#txtINumRegFfs").val("");
                        _bPerAddEdit.frm.find("#txtINumRegProf").val("");
                        sTiposCargos += "a";
                        break;
                    case '0000004':
                        sTiposCargos += "b";
                        break;
                    case '0000005':
                        sTiposCargos += "c";
                        break;
                    case '0000006':
                        sTiposCargos += "d";
                        break;
                    case '0000007':
                        _bPerAddEdit.frm.find("#txtINumColegiatura").val("");
                        _bPerAddEdit.frm.find("#ddlINivelAcademicoId").val("0000000");
                        _bPerAddEdit.frm.find("#ddlIEspecialidadId").val("0000000");
                        break;
                    case '0000020':
                        _bPerAddEdit.frm.find("#ddlAnioId").val($(_bPerAddEdit.frm.find("#ddlAnioId")[0].childNodes[0]).val()).trigger('change');
                        _bPerAddEdit.frm.find("#txtNroLicencia").val("");
                        _bPerAddEdit.frm.find("#txtFecLicencia").val("");
                        _bPerAddEdit.frm.find("#txtResolucion").val("");
                        _bPerAddEdit.frm.find("#ddlCategoriaId").val($(_bPerAddEdit.frm.find("#ddlCategoriaId")[0].childNodes[0]).val()).trigger('change');
                        _bPerAddEdit.frm.find("#txtCIP").val("");
                        _bPerAddEdit.frm.find("#ddlEstadoId").val($(_bPerAddEdit.frm.find("#ddlEstadoId")[0].childNodes[0]).val()).trigger('change');
                        break;
                    case '0000099':
                        _bPerAddEdit.frm.find("#txtOtro").val("");
                        break;
                }
            }
        });

        if (sTiposCargos == "abcd") {
            _bPerAddEdit.frm.find("#txtICargo").val("");
        }
    }
};

_bPerAddEdit.fnLoadSumoSelect = function () {
    //Tipo Cargo
    let sTipoCargo = _bPerAddEdit.codPTipo;

    if (sTipoCargo != "TODOS" && sTipoCargo != "") {
        let tipoCargo = sTipoCargo.split(',');

        if (tipoCargo.length > 1) {
            var data = JSON.parse(_bPerAddEdit.DataTipoCargo);

            var cboTipoCargo = _bPerAddEdit.frm.find("#ddlITipoCargoId");
            cboTipoCargo.html('');

            for (let i = 0; i < tipoCargo.length; i++) {
                for (let item of data) {
                    if (tipoCargo[i] == item.Value) {
                        var p = new Option(item.Text, item.Value);
                        cboTipoCargo.append(p);
                        break;
                    }
                }
            }
        }
        else {
            _bPerAddEdit.frm.find("#ddlITipoCargoId").val(sTipoCargo);
            _bPerAddEdit.frm.find("#ddlITipoCargoId").attr("disabled", true);
        }
    } else {
        _bPerAddEdit.frm.find("#ddlITipoCargoId").val("");
    }

    _bPerAddEdit.frm.find("#ddlITipoCargoId").SumoSelect({
        csvDispCount: 10, placeholder: "Tipo Cargo", search: true,
        searchText: "Buscar...", noMatch: 'No se encontraron resultados para "{0}"'
    });

    //Mencion Regencia
    _bPerAddEdit.frm.find("#ddlMencionRegenciaId").SumoSelect({
        csvDispCount: 10, placeholder: "Mención", search: true,
        searchText: "Buscar...", noMatch: 'No se encontraron resultados para "{0}"'
    });
};

_bPerAddEdit.fnListarMencionRegencia = function (codcategoria) {
    if (codcategoria == "0000000") {
        $("#dvIMencionRegencia").hide();

        _bPerAddEdit.frm.find("#ddlMencionRegenciaId").html("");
        _bPerAddEdit.frm.find("#ddlMencionRegenciaId")[0].sumo.reload();
    }
    else {
        $("#dvIMencionRegencia").show();

        var url = urlLocalSigo + "General/Controles/ListarMencionRegencia";
        var option = { url: url, type: 'POST', datos: JSON.stringify({ idcategoria: codcategoria }) };

        utilSigo.fnAjax(option, function (data) {
            if (data.success) {
                var mencion = _bPerAddEdit.frm.find("#ddlMencionRegenciaId");
                mencion.html("");
                $.each(data.result, function (index, item) {
                    var p = new Option(item.Text, item.Value);
                    mencion.append(p);
                });

                var sMencion = _bPerAddEdit.frm.find("#hdfMencionRegencia").val();

                if (sMencion != undefined && sMencion != "") {
                    let mencionRegencia = sMencion.split(',');
                    let array = [];

                    for (let i = 1; i < mencionRegencia.length; i++) {
                        array.push(mencionRegencia[i]);
                    }
                    _bPerAddEdit.frm.find("#ddlMencionRegenciaId").val(array);
                }

                mencion[0].sumo.reload();
            }
            else {
                utilSigo.toastWarning("Aviso", "Sucedio un error, Comuníquese con el Administrador");
                console.log(data.result);
            }
        });
    }
};

_bPerAddEdit.fnInit = function (tipoPersona, codPTipo) {
    _bPerAddEdit.tipoPersona = tipoPersona;
    _bPerAddEdit.codPTipo = codPTipo;
    /*console.log("tipoPersona");
    console.log(tipoPersona);
    console.log("codPTipo");
    console.log(codPTipo);*/

    $('[data-toggle="tooltip"]').tooltip();
    _bPerAddEdit.content = $("#divPersonaAddEdit");
    _bPerAddEdit.frm = $("#frmPersona");
    _bPerAddEdit.fnLoadSumoSelect();
    _bPerAddEdit.fnVistaTipoCargo();

    _bPerAddEdit.frm.find("#txtFecLicencia").datepicker({ format: "dd/mm/yyyy", autoclose: true, language: 'es' });

    if (_bPerAddEdit.content.find("#hdfFormulario").val() == "THabilitante" && _bPerAddEdit.content.find("#hdfCodMod").val() == "0000015") {
        if (tipoPersona == "J") {
            _bPerAddEdit.frm.find("#divFichaRegistral").show();
        }
    }

    if (_bPerAddEdit.content.find("#codigoPersona").val() != "") {
        if (_bPerAddEdit.content.find("#hdfOpc").val() == 1) {
            $("#btnRegistrarPersona").html("Agregar");
        }
        else {
            $("#btnRegistrarPersona").html("Guardar");
        }
    }

    switch (tipoPersona) {
        case "N":
            $("#dvTituloPNatural").show();
            $("#dvPNatural").show();
            _bPerAddEdit.configValidateFormN();
            _bPerAddEdit.fnInitEventosN();
            break;
        case "J":
            $("#dvPJuridica").show();
            _bPerAddEdit.configValidateFormJ();
            _bPerAddEdit.fnInitEventosJ();
            break;
        default:
            _bPerAddEdit.content.find("#divOpcionTPersona").show();
            $("#frmPersona").hide();
            _bPerAddEdit.fnInitEventos();
            break;
    }

    _bPerAddEdit.frm.find("#ddlItemPN_DITipoId").select2({ minimumResultsForSearch: -1 });
    //Validación de controles que usan Select2
    _bPerAddEdit.frm.find("select.select2-hidden-accessible").on("change", function (e) {
        $(this).valid();
    });
    _bPerAddEdit.frm.find("#ddlITipoCargoId").change(function () {
        _bPerAddEdit.fnVistaTipoCargo();
    });
    _bPerAddEdit.frm.find("#ddlCategoriaId").change(function () {
        _bPerAddEdit.frm.find("#hdfMencionRegencia").val("");
        _bPerAddEdit.fnListarMencionRegencia(this.value);
    });

    $($("#divPersonaAddEdit").parent()[0]).css("z-index", 1051);
};