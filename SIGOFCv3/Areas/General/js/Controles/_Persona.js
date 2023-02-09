"use strict";
var _bPerAddEdit = {};

_bPerAddEdit.url = initSigo.urlControllerGeneral + "/_Persona";
_bPerAddEdit.tipoPersona = divBuscarPN
_bPerAddEdit.codPTipo = "";
_bPerAddEdit.fnAsignarDatos = function (obj) { }

_bPerAddEdit.fnInitEventos = function () {
    _bPerAddEdit.content.find("#btnRegistrarPersonaN").hide();
    _bPerAddEdit.content.find("#btnRegistrarPersonaJ").hide();

	_bPerAddEdit.content.find("[name=rdTipoPersona]").change(function () {
		var tipoPersona = $(this).val();
		if (tipoPersona == "N") {
			_bPerAddEdit.content.find("#frmPersonaJuridica").hide();
			_bPerAddEdit.content.find("#frmPersonaNatural").show();
			_bPerAddEdit.tipoPersona = "N";
			_bPerAddEdit.content.find("#btnRegistrarPersonaN").show();
			_bPerAddEdit.content.find("#btnRegistrarPersonaJ").hide();
		} else {
			_bPerAddEdit.content.find("#frmPersonaNatural").hide();
			_bPerAddEdit.content.find("#frmPersonaJuridica").show();
			_bPerAddEdit.tipoPersona = "J";
			_bPerAddEdit.content.find("#btnRegistrarPersonaN").hide();
			_bPerAddEdit.content.find("#btnRegistrarPersonaJ").show();
		}
	});
	_bPerAddEdit.content.find("[name=chkNoconsignaDNIPN]").change(function () {
		if ($(this).is(":checked")) {
			_bPerAddEdit.content.find("#txtItemPN_DINumero").val('00000000');
			_bPerAddEdit.content.find("#txtItemPN_DINumero").prop("readonly", true);
		}
		else {
			_bPerAddEdit.content.find("#txtItemPN_DINumero").val('');
			_bPerAddEdit.content.find("#txtItemPN_DINumero").prop("readonly", false);
		}
	});

	_bPerAddEdit.content.find("[name=chkNoconsignaRUCPN]").change(function () {
		if ($(this).is(":checked")) {
			_bPerAddEdit.content.find("#txtItemPN_DIRUC").val('00000000000');
			_bPerAddEdit.content.find("#txtItemPN_DIRUC").prop("readonly", true);
		}
		else {
			_bPerAddEdit.content.find("#txtItemPN_DIRUC").val('');
			_bPerAddEdit.content.find("#txtItemPN_DIRUC").prop("readonly", false);
		}
	});

	_bPerAddEdit.content.find("[name=chkNoconsignaRUCPJ]").change(function () {
		if ($(this).is(":checked")) {
			_bPerAddEdit.content.find("#txtItemPJ_RUC").val('00000000000');
			_bPerAddEdit.content.find("#txtItemPJ_RUC").prop("readonly", true);
		}
		else {
			_bPerAddEdit.content.find("#txtItemPJ_RUC").val('');
			_bPerAddEdit.content.find("#txtItemPJ_RUC").prop("readonly", false);
		}
	});

}
_bPerAddEdit.cargarUbigeoModal = function () {
    var url = urlLocalSigo + "General/Controles/_Ubigeo";
    var option = { url: url, type: 'POST', datos: {}, divId: "personaUbigeoModal" };
    utilSigo.fnOpenModal(option, function () {
        _Ubigeo.fnSelectUbigeo = function (_ubigeoText, _ubigeoId) {
            if (_bPerAddEdit.tipoPersona == "N") {
                _bPerAddEdit.frmN.find("#hdfItemPN_DLUbigeo").val(_ubigeoId);
                _bPerAddEdit.frmN.find("#lblItemPN_DLUbigeo").val(_ubigeoText);
            }
            if (_bPerAddEdit.tipoPersona == "J") {
                _bPerAddEdit.frmJ.find("#hdfItemPJ_DLUbigeo").val(_ubigeoId);
                _bPerAddEdit.frmJ.find("#lblItemPJ_DLUbigeo").val(_ubigeoText);
            }
            $("#personaUbigeoModal").modal('hide');
        }
        var codUbigeo = "";
        if (_bPerAddEdit.tipoPersona == "N")
            codUbigeo = _bPerAddEdit.frmN.find("#hdfItemPN_DLUbigeo").val();
        if (_bPerAddEdit.tipoPersona == "J")
            codUbigeo = _bPerAddEdit.frmN.find("#hdfItemPJ_DLUbigeo").val();

        _Ubigeo.fnLoadModalView(codUbigeo);
    });
}

//*****************PERSONA JURIDICA*************
_bPerAddEdit.fnInitEventosJ = function () {
    _bPerAddEdit.frmJ.find("#divBuscarPJ").click(function () {
        _bPerAddEdit.buscarPersonaNJ();
    });
    _bPerAddEdit.frmJ.find("#btnUbigeoJ").click(function () {
        _bPerAddEdit.cargarUbigeoModal();
    });
}
_bPerAddEdit.configValidateFormJ = function () {
    var objValida = {};
    _bPerAddEdit.frmJ.validate(utilSigo.fnValidate(objValida));
}

//*****************PERSONA NATURAL*************
_bPerAddEdit.configValidateFormN = function () {
    jQuery.validator.addMethod("invalidFrmPerAddEditN", function (value, element) {
        switch ($(element).attr('id')) {
            case 'ddlItemPN_DITipoId': return (value == '0000000') ? false : true;
        }
    });
    var objValida = {
        rules: {
            ddlItemPN_DITipoId: { invalidFrmPerAddEditN: true }

        },
        messages: {
            ddlItemPN_DITipoId: { invalidFrmPerAddEditN: "Seleccione el tipo de documento" }
        }
    };
    _bPerAddEdit.frmN.validate(utilSigo.fnValidate(objValida));
}

_bPerAddEdit.save = function () {
	var datos;
	if (_bPerAddEdit.tipoPersona == "N") {
		if (_bPerAddEdit.frmN.valid()) {
			datos = _bPerAddEdit.frmN.serializeObject();
			datos.txtItemPN_APaterno = (datos.txtItemPN_APaterno || '').toUpperCase();
			datos.txtItemPN_AMaterno = (datos.txtItemPN_AMaterno || '').toUpperCase();
			datos.txtItemPN_Nombres = (datos.txtItemPN_Nombres || '').toUpperCase();
			datos.txtICargo = (datos.txtICargo || '').toUpperCase();
		} else return;
	}
	if (_bPerAddEdit.tipoPersona == "J") {
		if (_bPerAddEdit.frmJ.valid()) {
			datos = _bPerAddEdit.frmJ.serializeObject();
		} else return;
	}
	datos.tipoPersona = _bPerAddEdit.tipoPersona;
	datos.COD_PTIPO = _bPerAddEdit.codPTipo.length > 7 ? _bPerAddEdit.codPTipo.substring(0, 7) : _bPerAddEdit.codPTipo;

	console.log(_bPerAddEdit.url);

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
				_bPerAddEdit.fnAsignarDatos(data, datos);
				_bPerAddEdit.closeModal();
			}
			else utilSigo.toastWarning("Aviso", data.msjError);
		}
	});
}

_bPerAddEdit.fnInitEventosN = function () {
    _bPerAddEdit.frmN.find("#ddlItemPN_DITipoId").change(function () {
        var valSelect = $(this).val();
        _bPerAddEdit.frmN[0].reset();

        _bPerAddEdit.frmN.find("#ddlItemPN_DITipoId").val(valSelect);
        _bPerAddEdit.frmN.find("#txtItemPN_DINumero").val("");
        _bPerAddEdit.frmN.find("#txtItemPN_DINumero").focus();
        switch (valSelect) {
            case '0000000': _bPerAddEdit.frmN.find("#txtItemPN_DINumero").attr("maxlength", 8); break;
            case '0000001': _bPerAddEdit.frmN.find("#txtItemPN_DINumero").attr("maxlength", 8); break;
            case '0000002': _bPerAddEdit.frmN.find("#txtItemPN_DINumero").attr("maxlength", 12); break;
            case '0000006': _bPerAddEdit.frmN.find("#txtItemPN_DINumero").attr("maxlength", 11); break;
        }
        _bPerAddEdit.frmN.find("#dvItemPN_RazonSocial").hide();
    });
    _bPerAddEdit.frmN.find("#divBuscarPN").click(function () { _bPerAddEdit.buscarPersonaNJ(); });

    _bPerAddEdit.frmN.find("#btnUbigeoN").click(function () {
        _bPerAddEdit.cargarUbigeoModal();
    });
}

_bPerAddEdit.closeModal = function () {
    _bPerAddEdit.content.closest(".modal").modal("hide");
}

_bPerAddEdit.buscarPersonaNJ = function () {
	var buspCriterio = "", buspValor = "", buspFormulario = _bPerAddEdit.content.find("#hdfFormulario").val();

    if (_bPerAddEdit.tipoPersona == "N") {
        buspValor = _bPerAddEdit.frmN.find("#txtItemPN_DINumero").val();

        switch (_bPerAddEdit.frmN.find("#ddlItemPN_DITipoId").val()) {
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
        buspValor = _bPerAddEdit.frmJ.find("#txtItemPJ_RUC").val();
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
			var tipo_doc = _bPerAddEdit.frmN.find("#ddlItemPN_DITipoId").val();
			_bPerAddEdit.limpiarFormulario();
			if (data.success)
				_bPerAddEdit.cargarDatosBusqueda(data.values, tipo_doc);
			else utilSigo.toastWarning("Aviso", data.msj);
		}
	});
}

_bPerAddEdit.limpiarFormulario = function () {
    _bPerAddEdit.frmN[0].reset();
    _bPerAddEdit.frmJ[0].reset();

}

_bPerAddEdit.cargarDatosBusqueda = function (data, tipo_documento) {
    if (_bPerAddEdit.tipoPersona == 'N') {
        var paterno = "", materno = "", nombres = "", num_dni = "", num_ruc = "", direccion = "", ubigeo = "", cod_ubigeo = "", raz_soc;
        _bPerAddEdit.frmN.find("#dvItemPN_RazonSocial").hide();

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
                _bPerAddEdit.frmN.find("#dvItemPN_RazonSocial").show();
                break;
        }

        _bPerAddEdit.frmN.find("#ddlItemPN_DITipoId").val(tipo_documento).trigger('change');
        _bPerAddEdit.frmN.find("#txtItemPN_APaterno").val(paterno);
        _bPerAddEdit.frmN.find("#txtItemPN_AMaterno").val(materno);
        _bPerAddEdit.frmN.find("#txtItemPN_Nombres").val(nombres);
        _bPerAddEdit.frmN.find("#txtItemPN_DINumero").val(num_dni);
        _bPerAddEdit.frmN.find("#txtItemPN_DIRUC").val(num_ruc);
        _bPerAddEdit.frmN.find("#txtItemPN_DLDireccion").val(direccion);
        _bPerAddEdit.frmN.find("#lblItemPN_DLUbigeo").val(ubigeo);
        _bPerAddEdit.frmN.find("#hdlblItemPN_DLUbigeo").val(ubigeo);
        _bPerAddEdit.frmN.find("#hdfItemPN_DLUbigeo").val(cod_ubigeo);
        _bPerAddEdit.frmN.find("#lblItemPN_RazonSocial").text("Razón Social: " + raz_soc);
    } else {
        _bPerAddEdit.frmJ.find("#txtItemPJ_RSocial").val(data[0]);
        _bPerAddEdit.frmJ.find("#txtItemPJ_RUC").val(data[1]);
        _bPerAddEdit.frmJ.find("#txtItemPJ_DLDireccion").val(data[4]);
        _bPerAddEdit.frmJ.find("#hdfItemPJ_DLUbigeo").val(data[2]);
        _bPerAddEdit.frmJ.find("#lblItemPJ_DLUbigeo").val(data[3]);
        _bPerAddEdit.frmJ.find("#hdlblItemPJ_DLUbigeo").val(data[3]);
    }
}

_bPerAddEdit.cargarDatosEdit = function (data) {
    let ubigeo = data.ListDomicilio[0] || {};
    if (_bPerAddEdit.tipoPersona == 'N') {
        //_bPerAddEdit.frmN.find("#codigoPersona").val(data.COD_PERSONA);
        _bPerAddEdit.frmN.find("#ddlItemPN_DITipoId").val(data.COD_DIDENTIDAD).trigger('change');
        _bPerAddEdit.frmN.find("#txtItemPN_APaterno").val(data.APE_PATERNO);
        _bPerAddEdit.frmN.find("#txtItemPN_AMaterno").val(data.APE_MATERNO);
        _bPerAddEdit.frmN.find("#txtItemPN_Nombres").val(data.NOMBRES);
        _bPerAddEdit.frmN.find("#txtItemPN_DINumero").val(data.N_DOCUMENTO);
        _bPerAddEdit.frmN.find("#txtItemPN_DIRUC").val(data.N_RUC);
        //_bPerAddEdit.frmN.find("#txtItemPN_DLDireccion").val(ubigeo.DIRECCION);
        //_bPerAddEdit.frmN.find("#lblItemPN_DLUbigeo").val(ubigeo.UBIGEO);
        //_bPerAddEdit.frmN.find("#hdlblItemPN_DLUbigeo").val(ubigeo.UBIGEO);
        //_bPerAddEdit.frmN.find("#hdfItemPN_DLUbigeo").val(ubigeo.COD_UBIGEO);
        _bPerAddEdit.frmN.find("#lblItemPN_RazonSocial").text("Razón Social: " + data.RAZON_SOCIAL);
        _bPerAddEdit.frmN.find("#txtICargo").val(data.CARGO);

        //_bPerAddEdit.frmN.find("#ItemBUbigeo").hide();
    } else if (_bPerAddEdit.tipoPersona == 'J') {
        _bPerAddEdit.frmJ.find("#txtItemPJ_RSocial").val(data.RAZON_SOCIAL);
        _bPerAddEdit.frmJ.find("#txtItemPJ_RUC").val(data.N_DOCUMENTO);
        //_bPerAddEdit.frmJ.find("#txtItemPJ_DLDireccion").val(ubigeo.DIRECCION);
        //_bPerAddEdit.frmJ.find("#hdfItemPJ_DLUbigeo").val(ubigeo.COD_UBIGEO);
        //_bPerAddEdit.frmJ.find("#lblItemPJ_DLUbigeo").val(ubigeo.UBIGEO);
        //_bPerAddEdit.frmJ.find("#hdlblItemPJ_DLUbigeo").val(ubigeo.UBIGEO);

		//_bPerAddEdit.frmJ.find("#ItemBUbigeo").hide();
	}
}

//Tipo Persona N=Natural J=Juridica T=todos(la persona podra seleccionar si es que va ingresar persona natural o juridica)
_bPerAddEdit.fnInit = function (tipoPersona, codPTipo) {
    _bPerAddEdit.tipoPersona = tipoPersona;
    _bPerAddEdit.codPTipo = codPTipo;

    $('[data-toggle="tooltip"]').tooltip();
    _bPerAddEdit.content = $("#divPersonaAddEdit");
    _bPerAddEdit.frmN = $("#frmPersonaNatural");
    _bPerAddEdit.frmJ = $("#frmPersonaJuridica");
    _bPerAddEdit.content.find("#btnRegistrarPersonaN").hide();
    _bPerAddEdit.content.find("#btnRegistrarPersonaJ").hide();

	if (_bPerAddEdit.content.find("#hdfFormulario").val() == "THabilitante" && _bPerAddEdit.content.find("#hdfCodMod").val() == "0000015") {
		if (tipoPersona == "N") _bPerAddEdit.frmN.find("#txtItemPN_DIRUC").attr("required", true);
		if (tipoPersona == "J") {
			_bPerAddEdit.frmJ.find("#txtItemPJ_RUC").attr("required", true);
			//_bPerAddEdit.frmJ.find("#txtItemPJ_FichaRegistral").attr("required", true);
			_bPerAddEdit.frmJ.find("#divFichaRegistral").show();
		}
	}

	switch (tipoPersona) {
		case "N":
			_bPerAddEdit.configValidateFormN();
			_bPerAddEdit.frmN.show();
			_bPerAddEdit.fnInitEventosN();
			_bPerAddEdit.content.find("#btnRegistrarPersonaN").show();
			break;
		case "J":
			_bPerAddEdit.frmJ.show();
			_bPerAddEdit.configValidateFormJ();
			_bPerAddEdit.fnInitEventosJ();
			_bPerAddEdit.content.find("#btnRegistrarPersonaJ").show();
			break;
		default:
			_bPerAddEdit.content.find("#divOpcionTPersona").show();
			_bPerAddEdit.configValidateFormN();
			_bPerAddEdit.configValidateFormJ();
			_bPerAddEdit.fnInitEventosN();
			_bPerAddEdit.fnInitEventosJ();
			_bPerAddEdit.fnInitEventos();
			break;
	}

    _bPerAddEdit.frmN.find("#ddlItemPN_DITipoId").select2({ minimumResultsForSearch: -1 });
    //Validación de controles que usan Select2
    _bPerAddEdit.frmN.find("select.select2-hidden-accessible").on("change", function (e) {
        $(this).valid();
    });
}