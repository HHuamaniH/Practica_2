"use strict";
var _ActualizaCargoPersona = {};

_ActualizaCargoPersona.url = initSigo.urlControllerGeneral + "/_ActualizaCargoPersona";
_ActualizaCargoPersona.tipoPersona = "";
_ActualizaCargoPersona.codPTipo = "";
_ActualizaCargoPersona.codPTipoSelected = "";
_ActualizaCargoPersona.DataTipoCargo = [];

_ActualizaCargoPersona.fnAsignarDatos = function (obj) { };

_ActualizaCargoPersona.fnLoadData = function (obj) {
    _ActualizaCargoPersona.DataTipoCargo = obj;
};

_ActualizaCargoPersona.save = function () {
    let datos;

    if (_ActualizaCargoPersona.tipoPersona == "N") {
        let txtItemPN_DINumero = _ActualizaCargoPersona.frm.find("#txtItemPN_DINumero").val();
        let txtItemPN_APaterno = _ActualizaCargoPersona.frm.find("#txtItemPN_APaterno").val().toUpperCase();
        let txtItemPN_AMaterno = _ActualizaCargoPersona.frm.find("#txtItemPN_AMaterno").val().toUpperCase();
        let txtItemPN_Nombres = _ActualizaCargoPersona.frm.find("#txtItemPN_Nombres").val().toUpperCase();

        datos = { txtItemPN_DINumero, txtItemPN_APaterno, txtItemPN_AMaterno, txtItemPN_Nombres };
    }
    else if (_ActualizaCargoPersona.tipoPersona == "J") {
        let txtItemPJ_RUC = _ActualizaCargoPersona.frm.find("#txtItemPJ_RUC").val();
        let txtItemPJ_RSocial = _ActualizaCargoPersona.frm.find("#txtItemPJ_RSocial").val();

        datos = { txtItemPJ_RUC, txtItemPJ_RSocial };
    }

    datos.codigoPersona = _ActualizaCargoPersona.content.find("#codigoPersona").val();
    datos.tipoPersona = _ActualizaCargoPersona.tipoPersona;
    datos.txtINumRegFfs = _ActualizaCargoPersona.frm.find("#txtINumRegFfs").val();
    datos.txtINumRegProf = _ActualizaCargoPersona.frm.find("#txtINumRegProf").val();
    datos.txtICargo = _ActualizaCargoPersona.frm.find("#txtICargo").val();
    datos.txtINumColegiatura = _ActualizaCargoPersona.frm.find("#txtINumColegiatura").val();
    datos.ddlINivelAcademicoId = _ActualizaCargoPersona.frm.find("#ddlINivelAcademicoId").val();
    datos.ddlIEspecialidadId = _ActualizaCargoPersona.frm.find("#ddlIEspecialidadId").val();

    if (!utilSigo.ValidaCombo("ddlITipoCargoId", "Seleccione tipo de cargo")) return false;

    let anio = "", codMencion = "";
    let tipoCargo = _ActualizaCargoPersona.frm.find("#ddlITipoCargoId").val();


    if (tipoCargo == "0000020") {
        anio = _ActualizaCargoPersona.frm.find("#ddlAnioId").val();

        if (!utilSigo.ValidaTexto("txtNroLicencia", "Ingrese Nro. Licencia")) return false;
        if (!utilSigo.ValidaTexto("txtFecLicencia", "Ingrese Fecha de Otorgamiento")) return false;
        if (!utilSigo.ValidaTexto("txtResolucion", "Ingrese Nro. Resolución Directoral")) return false;

        if (_ActualizaCargoPersona.frm.find("#ddlCategoriaId").val() == "0000000") {
            utilSigo.toastError("Error", "Seleccione Categoría");
            _ActualizaCargoPersona.frm.find("#ddlCategoriaId").focus();
            return false;
        }
        else {
            _ActualizaCargoPersona.frm.find("#ddlMencionRegenciaId option").each(function (index, item) {
                if ($(item).prop("selected") == true) {
                    codMencion += "," + $(item).val();
                }
            });

            if (codMencion == "") {
                utilSigo.toastError("Error", "Seleccione al menos una mención de regencia");
                _ActualizaCargoPersona.frm.find("#ddlMencionRegenciaId").focus();
                return false;
            }
        }

        if (!utilSigo.ValidaTexto("txtCIP", "Ingrese Nro. CIP")) return false;
        if (!utilSigo.ValidaCombo("ddlEstadoId", "Seleccione Estado")) return false;
    }
    else if (tipoCargo == "0000099") {
        if (!utilSigo.ValidaTexto("txtOtro", "Ingrese Otros: Descripción")) return false;
    }

    datos.ddlITipoCargoId = tipoCargo;
    datos.txtITipoCargo = _ActualizaCargoPersona.frm.find("#ddlITipoCargoId option:selected").text();
    datos.ddlAnioId = anio;
    datos.txtNroLicencia = _ActualizaCargoPersona.frm.find("#txtNroLicencia").val();
    datos.txtFecLicencia = _ActualizaCargoPersona.frm.find("#txtFecLicencia").val();
    datos.txtResolucion = _ActualizaCargoPersona.frm.find("#txtResolucion").val();
    datos.ddlCategoriaId = _ActualizaCargoPersona.frm.find("#ddlCategoriaId").val();
    datos.hdfMencionRegencia = codMencion;
    datos.txtCIP = _ActualizaCargoPersona.frm.find("#txtCIP").val();
    datos.ddlEstadoId = _ActualizaCargoPersona.frm.find("#ddlEstadoId").val();
    datos.txtOtro = _ActualizaCargoPersona.frm.find("#txtOtro").val();

    $.ajax({
        url: _ActualizaCargoPersona.url,
        type: 'POST',
        data: JSON.stringify(datos),
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        beforeSend: utilSigo.beforeSendAjax,
        complete: utilSigo.completeAjax,
        error: utilSigo.errorAjax,
        success: function (data) {
            if (data.success) {
                if (data.msj.split('|')[0] == "1") {
                    utilSigo.toastSuccess("Aviso", "Se guardo con exito");
                }

                _ActualizaCargoPersona.fnAsignarDatos(datos);
                _ActualizaCargoPersona.closeModal();
            }
            else utilSigo.toastWarning("Aviso", data.msjError);
        }
    });
};

_ActualizaCargoPersona.closeModal = function () {
    _ActualizaCargoPersona.content.closest(".modal").modal("hide");
};

_ActualizaCargoPersona.fnVistaTipoCargo = function () {
    $("#dvINumRegFfs").hide();
    $("#dvINumRegProf").hide();
    $("#dvICargo").hide();
    $("#dvINumColegiatura").hide();
    $("#dvINivelAcademico").hide();
    $("#dvIEspecialidad").hide();
    $("#dvRegente").hide();
    $("#dvOtro").hide();

    let ddlITipoCargoId = _ActualizaCargoPersona.frm.find("#ddlITipoCargoId").val();

    if (ddlITipoCargoId != undefined) {
        switch (ddlITipoCargoId) {
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
                break;
            case '0000099':
                $("#dvOtro").show();
                break;
        }

        let tipoCargo = _ActualizaCargoPersona.frm.find("#hdfITipoCargo").val().split(',');
        let band = 0;

        for (let i = 1; i < tipoCargo.length; i++) {
            if (tipoCargo[i] == ddlITipoCargoId) {
                band = 1;
                break;
            }
        }

        if (band == 1) {
            switch (ddlITipoCargoId) {
                case '0000003':
                    _ActualizaCargoPersona.frm.find("#txtINumRegFfs").prop("readonly", true);
                    _ActualizaCargoPersona.frm.find("#txtINumRegProf").prop("readonly", true);
                    break;
                case '0000007':
                    _ActualizaCargoPersona.frm.find("#txtINumColegiatura").prop("readonly", true);
                    _ActualizaCargoPersona.frm.find("#ddlINivelAcademicoId").prop("disabled", true);
                    _ActualizaCargoPersona.frm.find("#ddlIEspecialidadId").prop("disabled", true);
                    break;
                case '0000020':
                    _ActualizaCargoPersona.frm.find("#ddlAnioId").prop("disabled", true);
                    _ActualizaCargoPersona.frm.find("#txtNroLicencia").prop("readonly", true);
                    _ActualizaCargoPersona.frm.find("#txtFecLicencia").prop("readonly", true);
                    _ActualizaCargoPersona.frm.find("#txtResolucion").prop("readonly", true);
                    console.log("aqui");
                    _ActualizaCargoPersona.frm.find("#ddlCategoriaId").prop("disabled", true);
                    _ActualizaCargoPersona.fnListarMencionRegencia(_ActualizaCargoPersona.frm.find("#ddlCategoriaId").val());
                    _ActualizaCargoPersona.frm.find("#ddlMencionRegenciaId").prop("disabled", true);
                    _ActualizaCargoPersona.frm.find("#txtCIP").prop("readonly", true);
                    _ActualizaCargoPersona.frm.find("#ddlEstadoId").prop("disabled", true);
                    break;
                case '0000099':
                    _ActualizaCargoPersona.frm.find("#txtOtro").prop("readonly", true);
                    break;
            }
        }
        else {
            switch (ddlITipoCargoId) {
                case '0000003':
                    _ActualizaCargoPersona.frm.find("#txtINumRegFfs").val("");
                    _ActualizaCargoPersona.frm.find("#txtINumRegProf").val("");
                    break;
                case '0000007':
                    _ActualizaCargoPersona.frm.find("#txtINumColegiatura").val("");
                    _ActualizaCargoPersona.frm.find("#ddlINivelAcademicoId").val("0000000");
                    _ActualizaCargoPersona.frm.find("#ddlIEspecialidadId").val("0000000");
                    break;
                case '0000020':
                    _ActualizaCargoPersona.frm.find("#ddlAnioId").val($(_ActualizaCargoPersona.frm.find("#ddlAnioId")[0].childNodes[0]).val()).trigger('change');
                    _ActualizaCargoPersona.frm.find("#txtNroLicencia").val("");
                    _ActualizaCargoPersona.frm.find("#txtFecLicencia").val("");
                    _ActualizaCargoPersona.frm.find("#txtResolucion").val("");
                    _ActualizaCargoPersona.frm.find("#ddlCategoriaId").val($(_ActualizaCargoPersona.frm.find("#ddlCategoriaId")[0].childNodes[0]).val()).trigger('change');
                    _ActualizaCargoPersona.frm.find("#txtCIP").val("");
                    _ActualizaCargoPersona.frm.find("#ddlEstadoId").val($(_ActualizaCargoPersona.frm.find("#ddlEstadoId")[0].childNodes[0]).val()).trigger('change');
                    break;
                case '0000099':
                    _ActualizaCargoPersona.frm.find("#txtOtro").val("");
                    break;
            }
        }

        let sTiposCargos = "";

        for (let i = 1; i < tipoCargo.length; i++) {
            switch (tipoCargo[i]) {
                case '0000003':
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
            }
        }

        if (sTiposCargos != "") {
            _ActualizaCargoPersona.frm.find("#txtICargo").prop("readonly", true);
        }
        else {
            _ActualizaCargoPersona.frm.find("#txtICargo").val("");
        }
    }
};

_ActualizaCargoPersona.fnLoadSumoSelect = function () {
    //Tipo Cargo
    let sTipoCargo = _ActualizaCargoPersona.codPTipo;

    if (sTipoCargo != "TODOS" && sTipoCargo != "") {
        let tipoCargo = sTipoCargo.split(',');

        var data = JSON.parse(_ActualizaCargoPersona.DataTipoCargo);

        var cboTipoCargo = _ActualizaCargoPersona.frm.find("#ddlITipoCargoId");
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
    } else {
        _ActualizaCargoPersona.frm.find("#ddlITipoCargoId").val("");
    }

    $.fn.select2.defaults.set("theme", "bootstrap4");
    _ActualizaCargoPersona.frm.find("#ddlITipoCargoId").select2();

    //Mencion Regencia
    _ActualizaCargoPersona.frm.find("#ddlMencionRegenciaId").SumoSelect({
        csvDispCount: 10, placeholder: "Mención", search: true,
        searchText: "Buscar...", noMatch: 'No se encontraron resultados para "{0}"'
    });
};

_ActualizaCargoPersona.fnListarMencionRegencia = function (codcategoria) {
    if (codcategoria == "0000000") {
        $("#dvIMencionRegencia").hide();

        _ActualizaCargoPersona.frm.find("#ddlMencionRegenciaId").html("");
        _ActualizaCargoPersona.frm.find("#ddlMencionRegenciaId")[0].sumo.reload();
    }
    else {
        $("#dvIMencionRegencia").show();

        var url = urlLocalSigo + "General/Controles/ListarMencionRegencia";
        var option = { url: url, type: 'POST', datos: JSON.stringify({ idcategoria: codcategoria }) };

        utilSigo.fnAjax(option, function (data) {
            if (data.success) {
                var mencion = _ActualizaCargoPersona.frm.find("#ddlMencionRegenciaId");
                mencion.html("");
                $.each(data.result, function (index, item) {
                    var p = new Option(item.Text, item.Value);
                    mencion.append(p);
                });

                var sMencion = _ActualizaCargoPersona.frm.find("#hdfMencionRegencia").val();

                if (sMencion != undefined && sMencion != "") {
                    let mencionRegencia = sMencion.split(',');
                    let array = [];

                    for (let i = 1; i < mencionRegencia.length; i++) {
                        array.push(mencionRegencia[i]);
                    }
                    _ActualizaCargoPersona.frm.find("#ddlMencionRegenciaId").val(array);
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

_ActualizaCargoPersona.fnInit = function (codPTipo, codPTipoSelected) {
    _ActualizaCargoPersona.codPTipo = codPTipo;
    _ActualizaCargoPersona.codPTipoSelected = codPTipoSelected;

    $('[data-toggle="tooltip"]').tooltip();
    _ActualizaCargoPersona.content = $("#divActualizaCargo");
    _ActualizaCargoPersona.frm = $("#frmActualizaCargo");
    _ActualizaCargoPersona.tipoPersona = _ActualizaCargoPersona.content.find("#hdfTipoPersona").val();

    _ActualizaCargoPersona.fnLoadSumoSelect();
    _ActualizaCargoPersona.fnVistaTipoCargo();

    _ActualizaCargoPersona.frm.find("#txtFecLicencia").datepicker({ format: "dd/mm/yyyy", autoclose: true, language: 'es' });

    switch (_ActualizaCargoPersona.tipoPersona) {
        case "N":
            $("#dvTituloPNatural").show();
            $("#dvPNatural").show();
            break;
        case "J":
            $("#dvPJuridica").show();
            break;
    }

    _ActualizaCargoPersona.frm.find("#ddlItemPN_DITipoId").select2({ minimumResultsForSearch: -1 });
    //Validación de controles que usan Select2
    _ActualizaCargoPersona.frm.find("select.select2-hidden-accessible").on("change", function (e) {
        $(this).valid();
    });
    _ActualizaCargoPersona.frm.find("#ddlITipoCargoId").change(function () {
        _ActualizaCargoPersona.fnVistaTipoCargo();
    });
    _ActualizaCargoPersona.frm.find("#ddlCategoriaId").change(function () {
        _ActualizaCargoPersona.frm.find("#hdfMencionRegencia").val("");
        _ActualizaCargoPersona.fnListarMencionRegencia(this.value);
    });

    if (_ActualizaCargoPersona.codPTipoSelected != null && _ActualizaCargoPersona.codPTipoSelected.trim() != "") {
        _ActualizaCargoPersona.frm.find("#ddlITipoCargoId").val(_ActualizaCargoPersona.codPTipoSelected).trigger('change');
    }
};