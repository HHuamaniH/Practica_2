"use strict";

var ManCertificadoPlanta = {};

ManCertificadoPlanta.DataDivisionInterna = [];

ManCertificadoPlanta.fnLoadData = function (obj, tipo) {
    switch (tipo) {
        case "DivisionInterna": ManCertificadoPlanta.DataDivisionInterna = JSON.parse(obj); break;
    }
}

ManCertificadoPlanta.validarP = function () {
    var url = urlLocalSigo + "General/Controles/_ValidarPlantilla";
    var option = { url: url, type: 'GET', datos: { origen: "" }, divId: "personaUbigeoModal" };
    utilSigo.fnOpenModal(option, function () {

    });
};

ManCertificadoPlanta.ListEliTABLA = [];
ManCertificadoPlanta.ListModalidadesTH = [];

//ManCertificadoPlanta.codSecuencialAdendamod = 0; //para modificar vertice de adenda
ManCertificadoPlanta.regresar = function (appServer) {
    var url = "";
    if (ManCertificadoPlanta.frmCertificadoPlantaRegistro.find("#opRegresar").val() == 0) {
        url = urlLocalSigo + "THabilitante/ManCertificadoPlanta/Index";
        window.location = url;
    }
};

ManCertificadoPlanta.valorIsFechaDia = function (valor) {
    var fecha = valor.split("/");
    var dia = parseInt(fecha[0], 10);
    var mes = parseInt(fecha[1], 10);
    var ano = parseInt(fecha[2], 10);
    var diaUltimo = (new Date(ano, mes, 0)).getDate();
    if (dia > diaUltimo) {
        return false;
    }
    return true;
};

ManCertificadoPlanta.validarDatosAdicionales = function () {
    if (!utilSigo.isFechaMenorDeHoy(ManCertificadoPlanta.frmCertificadoPlantaRegistro.find("#txtItemFechaInscripcion").val())) {
        utilSigo.toastWarning("Aviso", "La Fecha de Inscripción no debe ser mayor a la fecha actual");
        ManCertificadoPlanta.frmCertificadoPlantaRegistro.find("#txtItemFechaInscripcion").focus()
        return false;
    }
    if (ManCertificadoPlanta.frmCertificadoPlantaRegistro.find("#txtItemFechaEstablecimiento").val()!="") {
        if (!utilSigo.isFechaMenorDeHoy(ManCertificadoPlanta.frmCertificadoPlantaRegistro.find("#txtItemFechaEstablecimiento").val())) {
            utilSigo.toastWarning("Aviso", "La Fecha de Establecimiento no debe ser mayor a la fecha actual");
            ManCertificadoPlanta.frmCertificadoPlantaRegistro.find("#txtItemFechaEstablecimiento").focus()
            return false;
        }
    }
    return true;
};

ManCertificadoPlanta.validacionGeneral = function () {
    var ids = ["ddlIndicadorId", "ddlODRegistroId", "txtItemNumero", "txtItemEstSector", "txtItemRAPNumero", "txtItemRAPFecha", "txtItemRAFNumero", "txtItemRAFFecha", "txtItemAOtorgada", "txtItemContFInicio", "txtItemContFFin"];
    var idtab = "";
    var valRetorno = true;
    var idControlError = "";
    var band = 0;
    $.each(ids, function (i, o) {
        if ($("#" + o).val() == "" || $("#" + o).val() == "0000000") {
            idControlError = $("#" + o);
            idtab = $("#" + o).parents(".tab-pane").attr("id");
            valRetorno = false;
            return false;
        }
    })
    if (idtab != "") {
        $('a[href="#' + idtab + '"]').tab('show');
        idControlError.focus();
    }
    if ($("#ddlIndicadorId").val() != "0000002") {

        if ($("#txtItemAOtorgada").val() != null) {

            if ($("#txtItemAOtorgada").val() != "") {
                if ($("#txtItemAOtorgada").val().length > 20) {
                    var idtab = $("#txtItemAOtorgada").parents(".tab-pane").attr("id");
                    $('a[href="#' + idtab + '"]').tab('show');
                    utilSigo.toastWarning("Aviso", "El Área Otorgada (ha) tiene mas de 20 caracteres.");
                    $("#txtItemAOtorgada").focus();
                    return false;
                }
            }
        }

        if ($("#txtItemContFInicio").val() != null & $("#txtItemContFFin").val() != null)
            valRetorno = ManCertificadoPlanta.ValidarFecha();
        band = 1;
    }

    if (($("#cod_Modalidad").val() == "0000005" || $("#cod_Modalidad").val() == "0000009") && band == 0) {
        valRetorno = ManCertificadoPlanta.ValidarFecha();
    }

    return valRetorno;
};

ManCertificadoPlanta.iniciarEventosGenerales = function () {
       
    //validacion del formulario
    // Creamos una validacion personalizada
    jQuery.validator.addMethod("invalidFrmCertificadoPlanta", function (value, element) {
        switch ($(element).attr('id')) {
            case 'ddlIndicadorId': return value == '0000000' ? false : true;
            case 'txtItemFechaInscripcion': return ManCertificadoPlanta.valorIsFechaDia(value);
        }
    });
    ManCertificadoPlanta.frmCertificadoPlantaRegistro.validate(utilSigo.fnValidate({
        rules: {
            ddlIndicadorId: { invalidFrmCertificadoPlanta: true },            
            txtItemNumeroInscripcion: { required: true },
            txtItemFechaInscripcion: { required: true },
           
        },
        messages: {
            ddlIndicadorId: { invalidFrmCertificadoPlanta: "Debe seleccionar la situación actual de su registro" },            
            txtItemNumeroInscripcion: { required: "Ingrese Número de Inscripción" },
            txtItemFechaInscripcion: { required: "Ingrese Fecha de inscripción", invalidFrmCertificadoPlanta: "Ingrese Fecha de Inscripción en el formato correcto no mayor al día de hoy." }
        },
        fnSubmit: function (form) {
            if (ManCertificadoPlanta.validarDatosAdicionales()) {
                utilSigo.dialogConfirm('', 'Desea continuar con la operacion?', function (r) {
                    if (r) {
                        ManCertificadoPlanta.registrarCertificadoPlanta();
                    }
                });
            }
        }
    }));

    $("#btnRegistrarTH").click(function () {

        if (!ManCertificadoPlanta.validacionGeneral()) {
            return ManCertificadoPlanta.frmCertificadoPlantaRegistro.valid();
        }
        ManCertificadoPlanta.frmCertificadoPlantaRegistro.submit();
    });

    ManCertificadoPlanta.frmCertificadoPlantaRegistro.find("select.select2-hidden-accessible").on("change", function (e) {
        $(this).valid();
    });
};
ManCertificadoPlanta.fnInit = function () {
    $.fn.select2.defaults.set("theme", "bootstrap4");
    ManCertificadoPlanta.frmCertificadoPlantaRegistro.find("#ddlIndicadorId").select2();;

    if (ManCertificadoPlanta.frmCertificadoPlantaRegistro.find("#hdfManRegEstado").val() == 0) {
        $('#txtItemNumeroInscripcion').attr("disabled", "disabled")
    }
    //ManCertificadoPlanta.fnInitDataTable_Detail();
    //ManCertificadoPlanta.fnInitDivisionInterna();

    ManCertificadoPlanta.frmCertificadoPlantaRegistro.find("#txtItemFechaInscripcion").datepicker({ format: "dd/mm/yyyy", autoclose: true, language: 'es' });
    ManCertificadoPlanta.frmCertificadoPlantaRegistro.find("#txtItemFechaEstablecimiento").datepicker({ format: "dd/mm/yyyy", autoclose: true, language: 'es' });

};

ManCertificadoPlanta.registrarCertificadoPlanta = function () {
    var datosCertificadoPlanta = ManCertificadoPlanta.frmCertificadoPlantaRegistro.serializeObject();
    
    //datos a eliminar
    //datosCertificadoPlanta.ListEliTABLA = ManCertificadoPlanta.ListEliTABLA;
    //Datos control de calidad
    datosCertificadoPlanta.vmControlCalidad = _ControlCalidad.fnGetDatosControlCalidad();

    datosCertificadoPlanta.tbEspeciesEstablecidas = _renderEspeciesEstablecidas.fnGetList();
    datosCertificadoPlanta.tbEliTABLA = _renderEspeciesEstablecidas.fnGetListEliTABLA();
   
    
    //enviando datos al servidor
    $.ajax({
        url: urlLocalSigo + "THabilitante/ManCertificadoPlanta/RegistrarCertificadoPlanta",
        type: 'POST',
        data: JSON.stringify(datosCertificadoPlanta),
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function (data) {
            utilSigo.unblockUIGeneral();
            if (data.success) {
                if (ManCertificadoPlanta.frmCertificadoPlantaRegistro.find("#opRegresar").val() == 0) {
                    utilSigo.toastSuccess("Aviso", data.msj);
                    setTimeout(function () {
                        ManCertificadoPlanta.regresar(data.appServer);
                    }, 2000);
                } else {
                    ManCertificadoPlanta.regresar(data.appServer);
                }
            }
            else {
                if (ManCertificadoPlanta.frmCertificadoPlantaRegistro.find("#opRegresar").val() == 0) {
                    utilSigo.toastWarning("Aviso", data.msj);
                } else {
                    ManCertificadoPlanta.regresar(data.appServer);
                }
            }
        },
        beforeSend: function () {
            utilSigo.blockUIGeneral();
        },
        error: function (jqXHR, error, errorThrown) {
            utilSigo.unblockUIGeneral();
            utilSigo.toastError("Error", "Sucedio un error, Comuniquese con el Administrador");
            //console.log(jqXHR.responseText);
        }
    });
};

ManCertificadoPlanta.fnInitDataTable_Detail = function () {
    var columns_label = [], columns_data = [], options = {};

    //Cargar Error Material
    columns_label = ["Fecha de Resolución", "Resolución", "Nombre Campo", "Valor Anterior", "Valor Actual", "Observaciones"];
    columns_data = ["DA_FECRESOLUCION", "NV_RESOLUCION", "NV_NOMCAMPO", "NV_VALANTERIOR", "NV_VALACTUAL", "NV_OBSERVACION"];
    options = {
        page_length: 10, row_index: true, page_sort: true
    };
    ManCertificadoPlanta.dtErrorMaterial_DGeneral = utilDt.fnLoadDataTable_Detail(ManCertificadoPlanta.frmCertificadoPlantaRegistro.find("#tbErrorMaterial_DGeneral"), columns_label, columns_data, options);
    ManCertificadoPlanta.dtErrorMaterial_DGeneral.rows.add(JSON.parse(ManCertificadoPlanta.DataErrorMaterial_DGenereal)).draw();

    ManCertificadoPlanta.dtErrorMaterial_DAdicional = utilDt.fnLoadDataTable_Detail(ManCertificadoPlanta.frmCertificadoPlantaRegistro.find("#tbErrorMaterial_DAdicional"), columns_label, columns_data, options);
    ManCertificadoPlanta.dtErrorMaterial_DAdicional.rows.add(JSON.parse(ManCertificadoPlanta.DataErrorMaterial_DAdicional)).draw();
}

