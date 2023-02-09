"use strict";
var _Participante = {};
_Participante.GrupoPublicoNoDetalle = "0000000|0000052|0000053|0000054|0000055";//Grupos de público participante que no tienen público (detalle)

_Participante.fnCloseModal = function () { /*implementado desde donde se instancia*/ }
_Participante.fnSaveForm = function (data) { /*implementado desde donde se instancia*/ }

_Participante.fnShowTHabilitante = function () {
    _Participante.frm.find("#dvItemPart_THabilitante").hide();
    _Participante.frm.find("#dvItemPart_Publico").hide();
    var grupoPublicoId = _Participante.frm.find("#ddlItemPart_GrupoPublicoId").val();

    if (_Participante.frm.find("#hdfItemPart_TipoParticipante").val() == "ASISTENTE") {
        if (grupoPublicoId == "0000049") {//Grupo público participante: Títulos Habilitantes
            _Participante.frm.find("#dvItemPart_THabilitante").show();
        }

        if (!_Participante.GrupoPublicoNoDetalle.includes(grupoPublicoId)) {
            _Participante.frm.find("#dvItemPart_Publico").show();
        }
    }
}
_Participante.fnShowDatosParticipante = function () {
    _Participante.frm.find(".dvItemPart_DatosAsistente").hide();
    _Participante.frm.find("#dvItemPart_Constancia").hide();
    _Participante.frm.find("#dvItemPart_Funcion").hide();
    _Participante.frm.find("#dvItemPart_Tema").hide();
    _Participante.frm.find("#dvItemPart_Institucion").hide();
    if (_Participante.frm.find("#hdfItemPart_TipoParticipante").val() == "ASISTENTE") {
        _Participante.frm.find(".dvItemPart_DatosAsistente").show();
        _Participante.frm.find("#dvItemPart_Constancia").show();
    } else if (_Participante.frm.find("#hdfItemPart_TipoParticipante").val() == "PONENTE") {
        _Participante.frm.find("#dvItemPart_Constancia").show();
        _Participante.frm.find("#dvItemPart_Tema").show();
        _Participante.frm.find("#dvItemPart_Institucion").show();
    } else if (_Participante.frm.find("#hdfItemPart_TipoParticipante").val() == "EQUIPO") {
        _Participante.frm.find("#dvItemPart_Funcion").show();
        _Participante.frm.find("#dvItemPart_Institucion").show();
    }
}

_Participante.fnViewModalTHabilitante = function () {
    var url = urlLocalSigo + "General/Controles/_THabilitante";
    var option = { url: url, type: 'GET', datos: { hdfFormulario: "TITULO_HABILITANTE" }, divId: "mdlManCapacitacion_Participante_THabilitante" };
    utilSigo.fnOpenModal(option, function () {
        vpTHabilitante.fnAsignarDatos = function (obj) {
            if (obj!=null && obj != "") {
                var data = vpTHabilitante.dtTituloHabilitante.row($(obj).parents('tr')).data();
                _Participante.frm.find("#hdfItemPart_THabilitante").val(data["CODIGO"]);
                _Participante.frm.find("#lblItemPart_THabilitante").val(data["NUMERO"]);

                //Set Público Participante
                var publico = "0000000";
                switch (data["PARAMETRO01"]) {//Modalidad TH
                    case "Zoológicos": case "Zoocriaderos": case "Centros de Rescate":
                    case "Centros de Custodia Temporal": case "Centro de Conservación": publico = "0000067"; break;
                    case "Bosques Secos": publico = "0000068"; break;
                    case "Comunidad Nativa": publico = "0000069"; break;
                    case "Comunidad Campesina": publico = "0000070"; break;
                    case "Bosques Locales": publico = "0000071"; break;
                    case "Conservación": publico = "0000072"; break;
                    case "Ecoturismo": publico = "0000073"; break;
                    case "Maderables": publico = "0000074"; break;
                    case "No Maderables Castaña": publico = "0000075"; break;
                    case "No Maderables Shiringa": publico = "0000076"; break;
                    case "Predio Privado": publico = "0000077"; break;
                    case "Forestación y/o Reforestación": publico = "0000078"; break;
                    case "No Maderables Aguaje": publico = "0000079"; break;
                }
                _Participante.frm.find("#ddlItemPart_PublicoId").select2('val',[publico]);

                $("#mdlManCapacitacion_Participante_THabilitante").modal('hide');
            }
        }

        vpTHabilitante.fnInit_v2();
    });
}

_Participante.fnBuscarPersona = function () {
    var url = urlLocalSigo + "General/Controles/_BuscarPersonaGeneral";
    var option = { url: url, type: 'GET', datos: { asBusGrupo: "PERSONA", asCodPTipo: "TODOS", asTipoPersona: "N" }, divId: "mdlBuscarPersona" };
    utilSigo.fnOpenModal(option, function () {
        _bPerGen.fnAsignarDatos = function (obj) {
            if (obj != null && obj != "") {
                var data = _bPerGen.dtBuscarPerona.row($(obj).parents('tr')).data();
                _Participante.fnSetPersonaCompleto(data["COD_PERSONA"]);
                utilSigo.fnCloseModal("mdlBuscarPersona");
            }
        }
        _bPerGen.fnInit();
    });
}
_Participante.fnSetPersonaCompleto = function (codPersona) {
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
                _Participante.frm.find("#hdfItemPart_Participante").val(data.data["COD_PERSONA"]);
                _Participante.frm.find("#lblItemPart_Participante").val(data.data["APELLIDOS_NOMBRES"]);
                _Participante.frm.find("#hdfItemPart_Documento").val(data.data["N_DOCUMENTO"]);
                _Participante.frm.find("#hdfItemPart_Genero").val(data.data["COD_SEXO"]);
                if (data.data["ListCorreo"].length > 0) {
                    _Participante.frm.find("#txtItemPart_Correo").val(data.data["ListCorreo"][0]["CORREO"]);
                }
            } else {
                utilSigo.toastError("Error", "No se pudo consultar los datos de la persona");
                console.log(data.msj);
                return false;
            }
        }
    });
}

_Participante.fnEvents = function () {
    _Participante.fnShowTHabilitante();
    _Participante.frm.find("#ddlItemPart_GrupoPublicoId").change(function () {
        _Participante.fnCargarPublicoParticipante($(this).val());
        _Participante.fnShowTHabilitante()
    });
}
_Participante.fnCargarPublicoParticipante = function (codGrupoPublico,fn) {
    var urlPublico = urlLocalSigo + "Capacitacion/ManCapacitacion/GetPublicoParticipante";
    utilSigo.loadAjaxCombo(urlPublico, _Participante.frm.find("#ddlItemPart_PublicoId"), { codGrupoPublico: codGrupoPublico }, null, false, fn);
}

_Participante.fnLoadDatosParticipante = function (data) {
    if (data != null && data != "") {
        _Participante.frm.find("#hdfItemPart_RegEstado").val(data["RegEstado"]);
        var codInstitucion = data["COD_INSTITUCION"];
        codInstitucion = codInstitucion == null || codInstitucion == "" ? "0000000" : codInstitucion;
        _Participante.frm.find("#hdfItemPart_FechaRegistro").val(data["FECHA_CREACION"]);
        _Participante.frm.find("#ddlItemPart_InstitucionId").select2("val", [codInstitucion]);
        _Participante.frm.find("#lblItemPart_THabilitante").val(data["NUM_THABILITANTE"]);
        _Participante.frm.find("#hdfItemPart_THabilitante").val(data["COD_THABILITANTE"]);
        _Participante.frm.find("#lblItemPart_Participante").val(data["APELLIDOS_NOMBRES"]);
        _Participante.frm.find("#hdfItemPart_Participante").val(data["COD_PERSONA"]);
        _Participante.frm.find("#hdfItemPart_Genero").val(data["GENERO"]);
        _Participante.frm.find("#hdfItemPart_Documento").val(data["N_DOCUMENTO"]);
        if (_Participante.fnIsAnio2021()) {
            _Participante.frm.find("#txtItemPart_Cargo").select2("val", [data["CARGO"]]);
        } else {
            _Participante.frm.find("#txtItemPart_Cargo").val(data["CARGO"]);
        }
        
        _Participante.frm.find("#txtItemPart_Telefono").val(data["TELEFONO"]);
        _Participante.frm.find("#txtItemPart_Edad").val(data["EDAD"]);
        _Participante.frm.find("#ddlItemPart_ComunidadId").select2("val", [data["COD_CCNN"]]);
        var etnia = data["ETNIA"] == "" ? "0000000" : data["ETNIA"];
        _Participante.frm.find("#ddlItemPart_EtniaId").select2("val",[etnia]);
        _Participante.frm.find("#txtItemPart_Correo").val(data["CORREO"]);
        _Participante.frm.find("#txtItemPart_Funcion").val(data["FUNCION"]);
        _Participante.frm.find("#txtItemPart_Tema").val(data["FUNCION"]);
        _Participante.frm.find("#txtItemPart_Constancia").val(data["COD_CONSTANCIA"]);
        _Participante.frm.find("#txtItemPart_Observacion").val(data["OBSERVACION"]);
        _Participante.frm.find("#ddlItemPart_GrupoPublicoId").select2("val", [data["MAE_COD_GRUPOPUBLICOPARTICIPANTE"]]);
        _Participante.fnCargarPublicoParticipante(data["MAE_COD_GRUPOPUBLICOPARTICIPANTE"], function () {
            _Participante.frm.find("#ddlItemPart_PublicoId").select2("val", [data["MAE_COD_PUBLICOPARTICIPANTE"]]);
        });
    } else {
        _Participante.frm.find("#hdfItemPart_RegEstado").val("1");
        _Participante.frm.find("#hdfItemPart_Participante").val("");
    }
}

_Participante.fnSetDatosParticipante = function () {
    var data = [];
    var regEstado = _Participante.frm.find("#hdfItemPart_RegEstado").val();
    data["RegEstado"] = regEstado == "0" ? "2" : regEstado;
    data["COD_INSTITUCION"] = _Participante.frm.find("#ddlItemPart_InstitucionId").val();
    data["NOM_INSTITUCION"] = data["COD_INSTITUCION"] == "0000000" ? "" : _Participante.frm.find("#ddlItemPart_InstitucionId").select2("data")[0].text;
    data["NUM_THABILITANTE"]=_Participante.frm.find("#lblItemPart_THabilitante").val();
    data["COD_THABILITANTE"]=_Participante.frm.find("#hdfItemPart_THabilitante").val();
    data["APELLIDOS_NOMBRES"]=_Participante.frm.find("#lblItemPart_Participante").val();
    data["COD_PERSONA"]=_Participante.frm.find("#hdfItemPart_Participante").val();
    data["GENERO"] = _Participante.frm.find("#hdfItemPart_Genero").val();
    data["N_DOCUMENTO"] = _Participante.frm.find("#hdfItemPart_Documento").val();
    if (_Participante.fnIsAnio2021()) {
        data["CARGO"] = _Participante.frm.find("#txtItemPart_Cargo").select2("val");
    } else {
        data["CARGO"] = _Participante.frm.find("#txtItemPart_Cargo").val();
    }
    data["TELEFONO"]=_Participante.frm.find("#txtItemPart_Telefono").val();
    data["EDAD"]=_Participante.frm.find("#txtItemPart_Edad").val();
    data["COD_CCNN"] = _Participante.frm.find("#ddlItemPart_ComunidadId").val();
    data["CCNN"] = data["COD_CCNN"] == "0000000" ? "" : _Participante.frm.find("#ddlItemPart_ComunidadId").select2("data")[0].text;
    data["ETNIA"] = _Participante.frm.find("#ddlItemPart_EtniaId").val();
    data["ETNIA"] = data["ETNIA"] == "0000000" ? "" : data["ETNIA"];
    data["CORREO"] = _Participante.frm.find("#txtItemPart_Correo").val();
    data["FUNCION"] = _Participante.frm.find("#txtItemPart_Funcion").val();
    if (_Participante.frm.find("#hdfItemPart_TipoParticipante").val() == "PONENTE") {
        data["FUNCION"] = _Participante.frm.find("#txtItemPart_Tema").val();
    }
    data["COD_CONSTANCIA"]=_Participante.frm.find("#txtItemPart_Constancia").val();
    data["OBSERVACION"] = _Participante.frm.find("#txtItemPart_Observacion").val();
    data["MAE_COD_GRUPOPUBLICOPARTICIPANTE"] = _Participante.frm.find("#ddlItemPart_GrupoPublicoId").val();
    data["GRUPOPUBLICOPARTICIPANTE"] = data["MAE_COD_GRUPOPUBLICOPARTICIPANTE"] == "0000000" ? "" : _Participante.frm.find("#ddlItemPart_GrupoPublicoId").select2("data")[0].text;
    switch (data["MAE_COD_GRUPOPUBLICOPARTICIPANTE"]) {
        case "0000052": _Participante.frm.find("#ddlItemPart_PublicoId").select2("val", ["0000102"]); break;
        case "0000053": _Participante.frm.find("#ddlItemPart_PublicoId").select2("val", ["0000103"]); break;
        case "0000054": _Participante.frm.find("#ddlItemPart_PublicoId").select2("val", ["0000104"]); break;
        case "0000055": _Participante.frm.find("#ddlItemPart_PublicoId").select2("val", ["0000105"]); break;
    }
    data["MAE_COD_PUBLICOPARTICIPANTE"] = _Participante.frm.find("#ddlItemPart_PublicoId").val();
    data["PUBLICOPARTICIPANTE"] = data["MAE_COD_PUBLICOPARTICIPANTE"] == "0000000" ? "" : _Participante.frm.find("#ddlItemPart_PublicoId").select2("data")[0].text;
    data["FECHA_CREACION"] = _Participante.frm.find("#hdfItemPart_FechaRegistro").val();
    return data;
}

_Participante.fnCustomValidateForm = function () {
    if (!utilSigo.fnValidateForm_HideControl(_Participante.frm, _Participante.frm.find("#hdfItemPart_Participante"), _Participante.frm.find("#iconPersona"), false)) return false;
    return true;
}
_Participante.fnShowIsAnio2021 = function (fecha) {
    var isMoreAnio2021 = _Participante.fnIsAnio2021(fecha);
    if (isMoreAnio2021) {
        _Participante.fnShowSelectCargo();
    }
}
_Participante.fnIsAnio2021 = function (fechaCreacion) {
    var fecha = fechaCreacion ? fechaCreacion : _Participante.frm.find("#hdfItemPart_FechaRegistro").val();
    var isMoreAnio2021 = false;
    if (fecha) {
        var arrFecha = fecha.split('/');
        if (arrFecha.length > 1) {
            if (parseFloat(arrFecha[2]) > 2020) {
                isMoreAnio2021 = true;
            }
        }
    } else {
        isMoreAnio2021 = true;
    }
    return isMoreAnio2021;
}
_Participante.fnShowSelectCargo = function () {
    var cssSelectCargo= _Participante.frm.find(".cssSelectCargo");
    _Participante.frm.find(".cssTxtCargo").remove();
    cssSelectCargo.attr('id', 'txtItemPart_Cargo');
    cssSelectCargo.attr('name', 'txtItemPart_Cargo');
    cssSelectCargo.show();
    _Participante.frm.find("#txtItemPart_Cargo").select2();
}
_Participante.fnEliminarCargoSelect = function () {
    _Participante.frm.find(".cssSelectCargo").remove();
}
_Participante.fnSubmitForm = function () {
    _Participante.frm.submit();
}

//_tipoParticipante: [ASISTENTE,APOYO,PONENTE]
_Participante.fnInit = function (_tipoParticipante, data) {
    _Participante.frm = $("#frmItemParticipante");
    _Participante.fnShowIsAnio2021(data.FECHA_CREACION);
    _Participante.frm.find("#hdfItemPart_TipoParticipante").val(_tipoParticipante);
    $("#lblItemPart_Titulo").text("Datos del " + _tipoParticipante);

    $.fn.select2.defaults.set("theme", "bootstrap4");
    _Participante.frm.find("#ddlItemPart_InstitucionId").select2();
    _Participante.frm.find("#ddlItemPart_ComunidadId").select2();
    _Participante.frm.find("#ddlItemPart_EtniaId").select2();
    _Participante.frm.find("#ddlItemPart_GrupoPublicoId").select2();
    _Participante.frm.find("#ddlItemPart_PublicoId").select2();

    _Participante.fnShowDatosParticipante();
    _Participante.fnLoadDatosParticipante(data);

    _Participante.fnEvents();

    //=====-----Para el registro de datos del formulario-----=====
    //Validación personalizada
    jQuery.validator.addMethod("invalidFrmParticipante", function (value, element) {
        switch ($(element).attr('id')) {
            case 'ddlItemPart_InstitucionId':
                if (_Participante.frm.find("#dvItemPart_Institucion")[0].style.display=="none") {
                    return true;
                }
                return (value == '0000000') ? false : true;
                break
        }
    });
    _Participante.frm.validate(utilSigo.fnValidate({
        rules: {
            ddlItemPart_InstitucionId: { invalidFrmParticipante: true },
            txtItemPart_Cargo: { required: true }
        },
        messages: {
            ddlItemPart_InstitucionId: { invalidFrmParticipante: "Seleccione la procedencia/institución" },
            txtItemPart_Cargo: { required: "Ingrese el cargo" }
        },
        fnSubmit: function (form) {
            if (_Participante.fnCustomValidateForm()) {
                _Participante.fnSaveForm(_Participante.fnSetDatosParticipante());
            }
        }
    }));
    //Validación de controles que usan Select2
    _Participante.frm.find("select.select2-hidden-accessible").on("change", function (e) {
        $(this).valid();
    });
}