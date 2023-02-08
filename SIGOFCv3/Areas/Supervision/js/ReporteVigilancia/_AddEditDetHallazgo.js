var _AddEditDetHallazgo = {};
_AddEditDetHallazgo.idTipoHallazgo;
_AddEditDetHallazgo.estadoHallazgo;
_AddEditDetHallazgo.coducuenta;
_AddEditDetHallazgo.coducontrol;

_AddEditDetHallazgo.fnSaved = function (obj) { /*Implementar en donde se instancia*/ };

_AddEditDetHallazgo.fnSave = function () {
    if (_AddEditDetHallazgo.frm.find("#ddlEstadoDtId").val() == "1") {
        utilSigo.toastWarning("Aviso", 'Cambiar a estado "CONFORME" o "NO CONFORME"');
    }
    else {
        if (_AddEditDetHallazgo.frm.find("#ddlEstadoDtId").val() == "2") {
            if (_AddEditDetHallazgo.frm.find("#ddlEspecieId").val() == null || _AddEditDetHallazgo.frm.find("#ddlEspecieId").val() == "-") {
                utilSigo.toastWarning("Aviso", "Seleccione la Especie");
                return false;
            }
        }

        var fila = {
            COD_ESPECIES: _AddEditDetHallazgo.frm.find("#ddlEspecieId").val(),
            NV_OBSERVACION_VALIDADO: _AddEditDetHallazgo.frm.find("#txtObservacion_validado").val(),
            NU_ESTADO: parseInt(_AddEditDetHallazgo.frm.find("#ddlEstadoDtId").val()),
            ESTADO: _AddEditDetHallazgo.frm.find("#ddlEstadoDtId option:selected").text(),
            RegEstado: (_AddEditDetHallazgo.frm.find("#hdfRegEstado").val() == 0) ? 2 : _AddEditDetHallazgo.frm.find("#hdfRegEstado").val()
        };

        fila.NV_ESPECIES_VALIDADO = (fila.COD_ESPECIES != "-") ? _AddEditDetHallazgo.frm.find("#ddlEspecieId").select2('data')[0].text : null;

        _AddEditDetHallazgo.fnSaved(fila);
    }
};

_AddEditDetHallazgo.fnInitEventos = function (data) {
    $("#lbldiamayor").text("Diámetro mayor (cm)");
    $("#lbldiamenor").text("Diámetro menor (cm)");
    $("#lbllongitud").text("Longitud (m)");
    $("#lblvolumen1").text("Volumen (m3)");

    if (_AddEditDetHallazgo.idTipoHallazgo == "0000002") {
        $("#dvTipoDet").show();
        if (data.NV_TIPO == "0000031") {
            $("#lbldiamayor").text("Espesor (pulg.)");
            $("#lbldiamenor").text("Ancho (pulg.)");
            $("#lbllongitud").text("Longitud (pies)");
            $("#lblvolumen1").text("Volumen (pt)");
        }
    }

    if (data == "") { //Nuevo registro
        _AddEditDetHallazgo.frm.find("#ddlEstadoDtId").val("1");
    } else { //Modificar registro
        _AddEditDetHallazgo.frm.find("#ddlEstadoDtId").val(data.NU_ESTADO.toString());
        _AddEditDetHallazgo.frm.find("#ddlZonaId").val((data.NV_ZONA != "17" && data.NV_ZONA != "18" && data.NV_ZONA != "19") ? "-" : data.NV_ZONA);
        _AddEditDetHallazgo.frm.find("#txtcoordenadaEste").val(data.NU_COORDENADA_ESTE);
        _AddEditDetHallazgo.frm.find("#txtcoordenadaNorte").val(data.NU_COORDENADA_NORTE);
        _AddEditDetHallazgo.frm.find("#ddlTipoDtId").val(data.NV_TIPO);
        _AddEditDetHallazgo.frm.find("#txtespecie").val(data.NV_ESPECIES);
        _AddEditDetHallazgo.frm.find("#ddlEspecieId").val((data.COD_ESPECIES == null) ? "-" : data.COD_ESPECIES).trigger("change");
        _AddEditDetHallazgo.frm.find("#txtdiamayor").val(data.NU_DIAMAYOR_ESPESOR);
        _AddEditDetHallazgo.frm.find("#txtdiamenor").val(data.NU_DIAMENOR_ANCHO);
        _AddEditDetHallazgo.frm.find("#txtlongitud").val(data.NU_LONGITUD);
        _AddEditDetHallazgo.frm.find("#txtvolumen").val(data.NU_VOLUMEN);
        _AddEditDetHallazgo.frm.find("#txtObservacion").val(data.NV_OBSERVACION);
        _AddEditDetHallazgo.frm.find("#txtObservacion_validado").val(data.NV_OBSERVACION_VALIDADO);
        _AddEditDetHallazgo.frm.find("#hdfRegEstado").val(data.RegEstado);
    }

    if (_AddEditDetHallazgo.estadoHallazgo == "1" || _AddEditDetHallazgo.estadoHallazgo == "3" || _AddEditDetHallazgo.estadoHallazgo == "4") {
        _AddEditDetHallazgo.frm.find("#ddlEstadoDtId").attr("disabled", true);
        _AddEditDetHallazgo.frm.find("#ddlEspecieId").attr("disabled", true);
        _AddEditDetHallazgo.frm.find("#txtObservacion_validado").attr("disabled", true);
        $("#btnGrabar").hide();
    }
    else {
        if (_AddEditDetHallazgo.coducuenta != _AddEditDetHallazgo.coducontrol) {
            _AddEditDetHallazgo.frm.find("#ddlEstadoDtId").attr("disabled", true);
            _AddEditDetHallazgo.frm.find("#ddlEspecieId").attr("disabled", true);
            _AddEditDetHallazgo.frm.find("#txtObservacion_validado").attr("disabled", true);
            $("#btnGrabar").hide();
        }
    }
};

_AddEditDetHallazgo.fnInit = function (data, codtipohallazgo, estado, coducuenta, coducontrol) {
    _AddEditDetHallazgo.frm = $("#frmDetHallazgo");
    _AddEditDetHallazgo.idTipoHallazgo = codtipohallazgo;
    _AddEditDetHallazgo.estadoHallazgo = estado;
    _AddEditDetHallazgo.coducuenta = coducuenta;
    _AddEditDetHallazgo.coducontrol = coducontrol;

    $.fn.select2.defaults.set("theme", "bootstrap4");
    _AddEditDetHallazgo.frm.find("#ddlEspecieId").select2();

    _AddEditDetHallazgo.fnInitEventos(data);
};