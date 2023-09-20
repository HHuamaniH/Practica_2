"use strict";

var ManTHabilitante = {};

ManTHabilitante.DataErrorMaterial_DGenereal = [];
ManTHabilitante.DataErrorMaterial_DAdicional = [];
ManTHabilitante.DataDivisionInterna = [];

ManTHabilitante.fnLoadData = function (obj, tipo) {
    switch (tipo) {
        case "DGenereal": ManTHabilitante.DataErrorMaterial_DGenereal = obj; break;
        case "DAdicional": ManTHabilitante.DataErrorMaterial_DAdicional = obj; break;
        case "DivisionInterna": ManTHabilitante.DataDivisionInterna = JSON.parse(obj); break;
    }
}

ManTHabilitante.validarP = function () {
    var url = urlLocalSigo + "General/Controles/_ValidarPlantilla";
    var option = { url: url, type: 'GET', datos: { origen: "" }, divId: "personaUbigeoModal" };
    utilSigo.fnOpenModal(option, function () {

    });
};

ManTHabilitante.ListTDTTITULARES = [];
ManTHabilitante.ListTDDVVERTICE = [];
ManTHabilitante.ListTDDVADEAREATemp = [];
ManTHabilitante.ListAdendas = [];
ManTHabilitante.ListEliTABLA = [];
ManTHabilitante.ListEliTABLATem = [];
ManTHabilitante.ListModalidadesTH = [];
ManTHabilitante.ListTHEstadoEsta = [];
//ManTHabilitante.codSecuencialAdendamod = 0; //para modificar vertice de adenda
ManTHabilitante.regresar = function (appServer) {
    var url = "";
    if (ManTHabilitante.frmTHabilitanteRegistro.find("#opRegresar").val() == 0) {
        url = urlLocalSigo + "THabilitante/ManTHabilitante/ManTHabilitanteV";
        window.location = url;
    } else {
        var appClient = ManTHabilitante.frmTHabilitanteRegistro.find("#appClient").val();
        var appData = ManTHabilitante.frmTHabilitanteRegistro.find("#appData").val();
        url = urlLocalSigo + "THabilitante/ManVentanillaAntecedentesExpedientes/Index?appClient=" + appClient + "&appData=" + appData + "&appServer=" + appServer;
        window.location = url;
    }
};
ManTHabilitante.valorIsFechaDia = function (valor) {
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
ManTHabilitante.ValidarFecha = function () {
    var valRetorno = true;

    if ($("#txtItemContFInicio").val() != "" & $("#txtItemContFFin").val() != "") {
        var fecha1 = $("#txtItemContFInicio").val().split("/");
        var fechaInicio = new Date(fecha1[2], fecha1[1], fecha1[0]);

        var fecha2 = $("#txtItemContFFin").val().split("/");
        var fechaFin = new Date(fecha2[2], fecha2[1], fecha2[0]);

        if (fechaFin < fechaInicio) {
            //ManTHabilitante.validarControles('txtItemContFFin', 'iconTitularTipo', 'Seleccione Titular');
            var idtab = $("#txtItemContFFin").parents(".tab-pane").attr("id");
            $('a[href="#' + idtab + '"]').tab('show');
            //iconValidar.removeAttr('style');
            //utilSigo.toastWarning("Aviso", msj);
            utilSigo.toastWarning("Aviso", "Fecha Fin tiene que ser mayor que la fecha de inicio.");
            $("#txtItemContFFin").focus();
            valRetorno = false;
        }
    }

    return valRetorno;
};
ManTHabilitante.validacionGeneral = function () {
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
            valRetorno = ManTHabilitante.ValidarFecha();
        band = 1;
    }

    if (($("#cod_Modalidad").val() == "0000005" || $("#cod_Modalidad").val() == "0000009") && band == 0) {
        valRetorno = ManTHabilitante.ValidarFecha();
    }

    return valRetorno;
};
ManTHabilitante.iniciarEventosGenerales = function () {
    ManTHabilitante.frmTHabilitanteRegistro.find("#chkItemPlanManejo").click(function () {
        var check = $(this);
        var state = check.is(":checked");
        if (state) {
            check.val(true);
        } else {
            check.val(false);
        }
    });
    ManTHabilitante.validarControles = function (control, icon, msj) {
        var valorValidar = ManTHabilitante.frmTHabilitanteRegistro.find("#" + control).val();
        var iconValidar = ManTHabilitante.frmTHabilitanteRegistro.find("#" + icon);
        if (valorValidar.trim() == '') {
            var idtab = $("#" + control).parents(".tab-pane").attr("id");
            $('a[href="#' + idtab + '"]').tab('show');
            iconValidar.removeAttr('style');
            utilSigo.toastWarning("Aviso", msj)
            return false;
        }
        else {
            iconValidar.attr('style', 'display:none;');
            return true;
        }
    };
    ManTHabilitante.validarDatosAdicionales = function () {
        if (!ManTHabilitante.validarControles('hdtxtTitularTipo', 'iconTitularTipo', 'Seleccione Titular')) return false;
        if (ManTHabilitante.frmTHabilitanteRegistro.find("#hdMostrarRL").val()) {
            if (ManTHabilitante.frmTHabilitanteRegistro.find("#hdtipotxtTitularTipo").val() == 'J') {
                if (!ManTHabilitante.validarControles('hdfItemRLegalCodigo', 'iconRLegalCodigo', 'Seleccione Representante Legal')) return false;
            }
            else { ManTHabilitante.frmTHabilitanteRegistro.find("#iconRLegalCodigo").attr('style', 'display:none;'); }
        }
        if (!ManTHabilitante.validarControles('hdfItemEstUbigeoCodigo', 'iconUbigeoTH', 'Seleccione Ubigeo')) return false;
        if (ManTHabilitante.frmTHabilitanteRegistro.find("#cod_Modalidad").val() == '0000002') {//validar datos de resolucion de proyecto
            if (!ManTHabilitante.validarControles('hdfItemRAPFuncionarioCodigo', 'iconRAPFuncionarioCodigo', 'Seleccione Funcionario')) return false;
            if (!ManTHabilitante.validarControles('hdfItemRAFFuncionarioCodigo', 'iconRAFFuncionarioCodigo', 'Seleccione Funcionario')) return false;
        }
        return true;
    };
    //validacion del formulario
    // Creamos una validacion personalizada
    jQuery.validator.addMethod("invalidFrmThabilitante", function (value, element) {
        switch ($(element).attr('id')) {
            case 'ddlIndicadorId': return value == '0000000' ? false : true;
            case 'ddlODRegistroId': return value == '0000000' ? false : true;
            case 'txtItemRAPFecha': return ManTHabilitante.valorIsFechaDia(value);
        }
    });
    ManTHabilitante.frmTHabilitanteRegistro.validate(utilSigo.fnValidate({
        rules: {
            ddlIndicadorId: { invalidFrmThabilitante: true },
            ddlODRegistroId: { invalidFrmThabilitante: true },
            txtItemNumero: { required: true },
            txtItemEstSector: { required: true },
            txtItemRAPNumero: { required: true },
            txtItemRAPFecha: { required: true, invalidFrmThabilitante: true },
            txtItemRAFNumero: { required: true },
            txtItemRAFFecha: { required: true },
            txtItemAOtorgada: { required: true },
            txtItemContFInicio: { required: true },
            txtItemContFFin: { required: true }
        },
        messages: {
            ddlIndicadorId: { invalidFrmThabilitante: "Debe seleccionar la situación actual de su registro" },
            ddlODRegistroId: { invalidFrmThabilitante: "Debe seleccionar la O.D. desde donde se registra la información" },
            txtItemNumero: { required: "Ingrese Número de Titulo Habilitante" },
            txtItemEstSector: { required: "Ingrese el Sector del Establecimiento" },
            txtItemRAPNumero: { required: "Ingrese el Número de resolución que aprueba el proyecto" },
            txtItemRAPFecha: { required: "Ingrese Fecha", invalidFrmThabilitante: "Ingrese Fecha en Formato Correcto" },
            txtItemRAFNumero: { required: "Ingrese el Número de resolución que autoriza el funcionamiento" },
            txtItemRAFFecha: { required: "Ingrese Fecha" },
            txtItemAOtorgada: { required: "Ingrese Area" },
            txtItemContFInicio: { required: "Ingrese Fecha Inicio" },
            txtItemContFFin: { required: "Ingrese Fecha Fin" }
        },
        fnSubmit: function (form) {
            if (ManTHabilitante.validarDatosAdicionales()) {
                utilSigo.dialogConfirm('', 'Desea continuar con la operacion?', function (r) {
                    if (r) {
                        ManTHabilitante.registrarThabilitante();
                    }
                });
            }
        }
    }));

    $("#btnRegistrarTH").click(function () {

        if (!ManTHabilitante.validacionGeneral()) {
            return ManTHabilitante.frmTHabilitanteRegistro.valid();
        }
        ManTHabilitante.frmTHabilitanteRegistro.submit();
    });

    ManTHabilitante.frmTHabilitanteRegistro.find("select.select2-hidden-accessible").on("change", function (e) {
        $(this).valid();
    });
};
ManTHabilitante.fnInit = function () {
    $.fn.select2.defaults.set("theme", "bootstrap4");
    ManTHabilitante.frmTHabilitanteRegistro.find("#ddlIndicadorId").select2();
    ManTHabilitante.frmTHabilitanteRegistro.find("#ddlODRegistroId").select2();
    ManTHabilitante.frmTHabilitanteRegistro.find("#ddTipoId").select2({ minimumResultsForSearch: -1 });
    ManTHabilitante.frmTHabilitanteRegistro.find("#ddlDependenciaId").select2({ minimumResultsForSearch: -1 });
    ManTHabilitante.frmTHabilitanteRegistro.find("#ddplZonaZooId").select2({ minimumResultsForSearch: -1 });
    ManTHabilitante.frmTHabilitanteRegistro.find("#ddlItemAdeMotivoId").select2();

    ManTHabilitante.fnInitDataTable_Detail();
    ManTHabilitante.fnInitDivisionInterna();

};

ManTHabilitante.fnGetDivisionInterna = function () {
    let tbody = document.getElementById('tbodyDivIntPreTot');
    ManTHabilitante.DataDivisionInterna = [];
    for (var i = 0; i < tbody.rows.length; i++) {
        let filas = tbody.getElementsByTagName('tr');
        for (var i = 0; i < filas.length; i++) {
            let celdas = filas[i].getElementsByTagName('td');

            let ids = celdas[celdas.length - 1].children[0].id.split('_');
            let textAreaDesc = "";
            let textArea = "";
            let textAreaD = "";
            switch (ids[2]) {
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '7':
                case '10':
                case '11':
                case '12':                   
                    textArea = $('#' + celdas[celdas.length - 1].children[0].id).val();
                    break;
                default:
                    ids = celdas[celdas.length - 1].children[0].children[0].id.split('_');
                    textAreaD = $('#' + celdas[celdas.length - 1].children[0].children[0].id).val();
                    textArea = $('#' + celdas[celdas.length - 1].children[0].children[1].id).val();
                    break;
            }
            if (ids[3] == "1") {
                textAreaDesc = celdas[celdas.length - 2].textContent
            }
            let obj = {
                tipoarea: ids[1],
                subtipoarea: ids[2],
                subtipoareadesc: textAreaDesc,
                area: textArea,
                descripcionarea: textAreaD
            };
            ManTHabilitante.DataDivisionInterna.push(obj);
        }
    }

    return (ManTHabilitante.DataDivisionInterna);

};

ManTHabilitante.fnCalcularDivisionInterna = function () {
    let obj = ManTHabilitante.fnGetDivisionInterna();
    let total = 0;
    for (var i = 0; i < obj.length; i++) {
        let valorArea = parseFloat(obj[i].area);
        if (!isNaN(valorArea)) total += valorArea;
    }
    $('#txtTotalDI').val(total.toFixed(4).toString());
}
ManTHabilitante.fnValidarArea = function (valor) {
    let returns = true;
    if (valor == "") {
        returns = false;
    } else if (!/^\d+(\.\d{1,4})?$/.test(valor)) {
        returns = false;
    }
    return returns;
};

ManTHabilitante.fnAgregarArea = function (input) {
    let idTxt = input.id;
    idTxt = idTxt.replace("i", "txt");
    let fila = parseInt((idTxt.split('_'))[3]);
    let stFila = parseInt((idTxt.split('_'))[2]);
    let valor = $('#' + idTxt).val();
    let valorTxt = $('#a' + idTxt).val();
    if (valorTxt == "" || valorTxt == null || valorTxt == undefined) {
        utilSigo.toastWarning("Aviso", "Para agregar el área la descripción no debe estar vacía.");
        $('#a' + idTxt).focus();
    } else if (!ManTHabilitante.fnValidarArea(valor)) {
        utilSigo.toastWarning("Aviso", "Para agregar el área no debe estar vacía o tener mas de 4 decimales.");
        $('#' + idTxt).focus();
    } else {
        $('#' + idTxt).attr("disabled", "true");
        $('#a' + idTxt).attr("disabled", "true");
        let tbody = document.getElementById('tbodyDivIntPreTot');
        let filas = tbody.getElementsByTagName('tr');
        //se retira el boton agregar/eliminar del área        
        let cantArea = $('.cl_2_' + stFila).length;

        const elemento1 = document.getElementById('spa_2_' + stFila + '_' + fila);
        elemento1.remove();
        if (cantArea > 1) {
            const elemento2 = document.getElementById('spd_2_' + stFila + '_' + fila);
            elemento2.remove();
        }
        let rowspan6 = $('.cl_2_6').length;
        let rowspan8 = $('.cl_2_8').length;
        let rowspan9 = $('.cl_2_9').length;

        let htmlCel = "";
        htmlCel += '<div class="input-group input-group-sm">';
        htmlCel += '   <input class="form-control form-control-sm cl_2_' + stFila + '" id="atxt_2_' + stFila + '_' + (fila + 1).toString() + '" maxlength="20" placeholder="Descripción" onkeypress = "return utilSigo.checkLetter(event);" >';
        htmlCel += '   <input class="form-control form-control-sm" id="txt_2_' + stFila + '_' + (fila + 1).toString() + '" maxlength="10" onkeypress="return utilSigo.onKeyDecimal(event, this);" >';
        htmlCel += '   <span class="input-group-text" id="spa_2_' + stFila + '_' + (fila + 1).toString() + '"><i class="fa fa-plus" style="cursor:pointer;" id="i_2_' + stFila + '_' + (fila + 1).toString() + '" onclick="ManTHabilitante.fnAgregarArea(this);" data-toggle="tooltip" data-placement="top" title="Agregar"></i></span>';
        htmlCel += '   <span class="input-group-text" id="spd_2_' + stFila + '_' + (fila + 1).toString() + '"><i class="fa fa-minus" style="cursor:pointer;" id="d_2_' + stFila + '_' + (fila + 1).toString() + '" onclick="ManTHabilitante.fnEliminarArea(this);" data-toggle="tooltip" data-placement="top" title="Eliminar"></i></span>';
        htmlCel += '</div>'

        let cantRow = 0;
        let filaRow = 0;
        let colRow = 0;
        switch (stFila) {
            case 6:
                cantRow = $('.cl_2_6').length - 1;
                filaRow = 5;
                colRow = 1;
                break;
            case 8:
                cantRow = $('.cl_2_6').length + $('.cl_2_8').length - 2;
                filaRow = 7 + $('.cl_2_6').length - 1;
                colRow = 0;
                break;
            case 9:
                cantRow = $('.cl_2_6').length + $('.cl_2_8').length + $('.cl_2_9').length - 3;
                filaRow = 8 + $('.cl_2_6').length + $('.cl_2_8').length - 2;
                colRow = 0;
                break;
        }
        const newRow = tbody.insertRow(stFila + cantRow);
        let cel1 = newRow.insertCell(0);
        cel1.innerHTML = htmlCel;

        filas[5].cells[0].rowSpan = tbody.rows.length - 5;
        filas[filaRow].cells[colRow].rowSpan = cantArea + 1;

    }
};

ManTHabilitante.fnEliminarArea = function (input) {
    let idTxt = input.id;
    idTxt = idTxt.replace("i", "txt");
    let fila = parseInt((idTxt.split('_'))[3]);
    let stFila = parseInt((idTxt.split('_'))[2]);
    let cantArea = $('.cl_2_' + stFila).length;


    let tbody = document.getElementById('tbodyDivIntPreTot');
    let filas = tbody.getElementsByTagName('tr');
    //se retira el boton agregar/eliminar del área

    $('#atxt_2_' + (stFila).toString() + '_' + (fila - 1).toString()).removeAttr("disabled");
    $('#txt_2_' + (stFila).toString() + '_' + (fila - 1).toString()).removeAttr("disabled");
    let vala = $('#atxt_2_' + (stFila).toString() + '_' + (fila - 1).toString()).val();
    let val = $('#txt_2_' + (stFila).toString() + '_' + (fila - 1).toString()).val();
    let htmlCel = "";
    if ((fila - 1) > 1) {
        htmlCel += '<div class="input-group input-group-sm">';
        htmlCel += '   <input class="form-control form-control-sm cl_2_' + stFila + '" id="atxt_2_' + stFila + '_' + (fila - 1).toString() + '" maxlength="20" placeholder="Descripción" onkeypress = "return utilSigo.checkLetter(event);"  value="' + vala + '" >';
        htmlCel += '   <input class="form-control form-control-sm" id="txt_2_' + stFila + '_' + (fila - 1).toString() + '" maxlength="10" onkeypress="return utilSigo.onKeyDecimal(event, this);" onblur="return utilSigo.onBlurFourDecimal(this,\'Área\');" value="' + val + '">';
        htmlCel += '   <span class="input-group-text" id="spa_2_' + stFila + '_' + (fila - 1).toString() + '"><i class="fa fa-plus" style="cursor:pointer;" id="i_2_' + stFila + '_' + (fila - 1).toString() + '" onclick="ManTHabilitante.fnAgregarArea(this);" data-toggle="tooltip" data-placement="top" title="Agregar"></i></span>';
        htmlCel += '   <span class="input-group-text" id="spd_2_' + stFila + '_' + (fila - 1).toString() + '"><i class="fa fa-minus" style="cursor:pointer;" id="d_2_' + stFila + '_' + (fila - 1).toString() + '" onclick="ManTHabilitante.fnEliminarArea(this);" data-toggle="tooltip" data-placement="top" title="Eliminar"></i></span>';
        htmlCel += '</div>'
    } else {
        htmlCel += '<div class="input-group input-group-sm">';
        htmlCel += '   <input class="form-control form-control-sm cl_2_' + stFila + '" id="atxt_2_' + stFila + '_' + (fila - 1).toString() + '" maxlength="20" placeholder="Descripción" onkeypress = "return utilSigo.checkLetter(event);" value="' + vala + '" >';
        htmlCel += '   <input class="form-control form-control-sm" id="txt_2_' + stFila + '_' + (fila - 1).toString() + '" maxlength="10" onkeypress="return utilSigo.onKeyDecimal(event, this);" onblur="return utilSigo.onBlurFourDecimal(this,\'Área\');" value="' + val + '" >';
        htmlCel += '   <span class="input-group-text" id="spa_2_' + stFila + '_' + (fila - 1).toString() + '"><i class="fa fa-plus" style="cursor:pointer;" id="i_2_' + stFila + '_' + (fila - 1).toString() + '" onclick="ManTHabilitante.fnAgregarArea(this);" data-toggle="tooltip" data-placement="top" title="Agregar"></i></span>';
        htmlCel += '</div>'
    }

    let cantRow = 0;
    let filaRow = 0;
    let colRow = 0;
    let cell = 0;
    switch (stFila) {
        case 6:
            cantRow = $('.cl_2_6').length - 1;
            filaRow = 5;
            colRow = $('.cl_2_6').length == 2 ? 2 : 0;
            cell = 1;
            break;
        case 8:
            cantRow = $('.cl_2_6').length + $('.cl_2_8').length - 2;
            filaRow = 7 + $('.cl_2_6').length - 1;
            colRow = $('.cl_2_8').length == 2 ? 1 : 0;
            cell = 0;
            break;
        case 9:
            cantRow = $('.cl_2_6').length + $('.cl_2_8').length + $('.cl_2_9').length - 3;
            filaRow = 8 + $('.cl_2_6').length + $('.cl_2_8').length - 2;
            colRow = $('.cl_2_9').length == 2 ? 1 : 0;
            cell = 0;
            break;
    }
    tbody.deleteRow(stFila + cantRow - 1);

    filas[stFila + cantRow - 2].getElementsByTagName('td')[colRow].innerHTML = htmlCel;
    filas[5].cells[0].rowSpan = tbody.rows.length - 5;
    filas[filaRow].cells[cell].rowSpan = cantArea - 1;
};

ManTHabilitante.fnInitDivisionInterna = function () {
    if ($('#hdfItemModalidadCodigo').val() == "0000030") {
        var htmlbody = '';
        if (ManTHabilitante.DataDivisionInterna.length == 0) {
            htmlbody += '<tr>';
            htmlbody += '   <td rowspan="5">ÁREA CON COBERTURA DE BOSQUES NATURALES</td>';
            htmlbody += '   <td>Bosque primario</td>';
            htmlbody += '   <td><input class="form-control form-control-sm" id="txt_1_1_1" maxlength="10" onkeypress = "return utilSigo.onKeyDecimal(event, this);" onblur="return utilSigo.onBlurFourDecimalDI(this,\'Área\');"></td>';
            htmlbody += '</tr>';
            htmlbody += '<tr>';
            htmlbody += '   <td>Bosque secundario</td>';
            htmlbody += '   <td><input class="form-control form-control-sm" id="txt_1_2_1" maxlength="10" onkeypress = "return utilSigo.onKeyDecimal(event, this);" onblur="return utilSigo.onBlurFourDecimalDI(this,\'Área\');"></td>';
            htmlbody += '</tr>';
            htmlbody += '<tr>';
            htmlbody += '   <td>Purma</td>';
            htmlbody += '   <td><input class="form-control form-control-sm" id="txt_1_3_1" maxlength="10" onkeypress = "return utilSigo.onKeyDecimal(event, this);" onblur="return utilSigo.onBlurFourDecimalDI(this,\'Área\');"></td>';
            htmlbody += '</tr>';
            htmlbody += '<tr>';
            htmlbody += '   <td>Áreas de protección</td>';
            htmlbody += '   <td><input class="form-control form-control-sm" id="txt_1_4_1" maxlength="10" onkeypress = "return utilSigo.onKeyDecimal(event, this);" onblur="return utilSigo.onBlurFourDecimalDI(this,\'Área\');"></td>';
            htmlbody += '</tr>';
            htmlbody += '<tr>';
            htmlbody += '   <td>Otros</td>';
            htmlbody += '   <td><input class="form-control form-control-sm" id="txt_1_5_1" maxlength="10" onkeypress = "return utilSigo.onKeyDecimal(event, this);" onblur="return utilSigo.onBlurFourDecimalDI(this,\'Área\');"></td>';
            htmlbody += '</tr>';

            htmlbody += '<tr>';
            htmlbody += '   <td rowspan="7">ÁREA SIN COBERTURA DE BOSQUES NATURALES</td>';
            htmlbody += '   <td>Cultivos agrícolas Puros</td>';
            htmlbody += '   <td>';
            htmlbody += '       <div class="input-group input-group-sm">';
            htmlbody += '           <input class="form-control form-control-sm cl_2_6" id="atxt_2_6_1" maxlength="20" placeholder="Descripción" onkeypress = "return utilSigo.checkLetter(event);" >';
            htmlbody += '           <input class="form-control form-control-sm" id="txt_2_6_1" maxlength="10" onkeypress="return utilSigo.onKeyDecimal(event, this);" >';
            htmlbody += '           <span class="input-group-text" id="spa_2_6_1"><i class="fa fa-plus" style="cursor:pointer;" id="i_2_6_1" onclick="ManTHabilitante.fnAgregarArea(this);" data-toggle="tooltip" data-placement="top" title="Agregar"></i></span>';
            htmlbody += '       </div> ';
            htmlbody += '   </td> ';
            htmlbody += '</tr>';
            htmlbody += '<tr>';
            htmlbody += '   <td>Pastizales puros</td>';
            htmlbody += '   <td><input class="form-control form-control-sm" id="txt_2_7_1" maxlength="10" onkeypress = "return utilSigo.onKeyDecimal(event, this);" onblur="return utilSigo.onBlurFourDecimalDI(this,\'Área\');"></td>';
            htmlbody += '</tr>';
            htmlbody += '<tr>';
            htmlbody += '   <td>Plantaciones forestales puras(Maciso)</td>';
            htmlbody += '   <td>';
            htmlbody += '       <div class="input-group input-group-sm">';
            htmlbody += '           <input class="form-control form-control-sm cl_2_8" id="atxt_2_8_1" maxlength="20" placeholder="Descripción" onkeypress = "return utilSigo.checkLetter(event);" >';
            htmlbody += '           <input class="form-control form-control-sm" id="txt_2_8_1" maxlength="10" onkeypress="return utilSigo.onKeyDecimal(event, this);" >';
            htmlbody += '           <span class="input-group-text" id="spa_2_8_1"><i class="fa fa-plus" style="cursor:pointer;" id="i_2_8_1" onclick="ManTHabilitante.fnAgregarArea(this);" data-toggle="tooltip" data-placement="top" title="Agregar"></i></span>';
            htmlbody += '       </div> ';
            htmlbody += '   </td> ';
            htmlbody += '</tr>';
            htmlbody += '<tr>';
            htmlbody += '   <td>Áreas que combina cultivos agrícolas y plantaciones forestales (Sistema Agroforestal)</td>';
            htmlbody += '   <td>';
            htmlbody += '       <div class="input-group input-group-sm">';
            htmlbody += '           <input class="form-control form-control-sm cl_2_9" id="atxt_2_9_1" maxlength="20" placeholder="Descripción" onkeypress = "return utilSigo.checkLetter(event);" >';
            htmlbody += '           <input class="form-control form-control-sm" id="txt_2_9_1" maxlength="10" onkeypress="return utilSigo.onKeyDecimal(event, this);" >';
            htmlbody += '           <span class="input-group-text" id="spa_2_9_1"><i class="fa fa-plus" style="cursor:pointer;" id="i_2_9_1" onclick="ManTHabilitante.fnAgregarArea(this);" data-toggle="tooltip" data-placement="top" title="Agregar"></i></span>';
            htmlbody += '       </div> ';
            htmlbody += '   </td> ';
            htmlbody += '</tr>';
            htmlbody += '<tr>';
            htmlbody += '   <td>Áreas destinadas para protección</td>';
            htmlbody += '   <td><input class="form-control form-control-sm" id="txt_2_10_1" maxlength="10" onkeypress = "return utilSigo.onKeyDecimal(event, this);" onblur="return utilSigo.onBlurFourDecimalDI(this,\'Área\');"></td>';
            htmlbody += '</tr>';
            htmlbody += '<tr>';
            htmlbody += '   <td>Áreas que combinan pastos con plantaciones Forestales(Silvopastoril)</td>';
            htmlbody += '   <td><input class="form-control form-control-sm" id="txt_2_11_1" maxlength="10" onkeypress = "return utilSigo.onKeyDecimal(event, this);" onblur="return utilSigo.onBlurFourDecimalDI(this,\'Área\');"></td>';
            htmlbody += '</tr>';
            htmlbody += '<tr>';
            htmlbody += '   <td>Otros usos</td>';
            htmlbody += '   <td><input class="form-control form-control-sm" id="txt_2_12_1" maxlength="10" onkeypress = "return utilSigo.onKeyDecimal(event, this);" onblur="return utilSigo.onBlurFourDecimal(this,\'Área\');"></td>';
            htmlbody += '</tr>';

        } else {
            let objPosSeis = [];
            let objPosOcho = [];
            let objPosNueve = [];
            for (var i = 0; i < ManTHabilitante.DataDivisionInterna.length; i++) {                
                let obj = ManTHabilitante.DataDivisionInterna[i];
                switch (obj.SUBTIPOAREA) {
                    case 1:
                        htmlbody += '<tr>';
                        htmlbody += '   <td rowspan="5">ÁREA CON COBERTURA DE BOSQUES NATURALES</td>';
                        htmlbody += '   <td>' + obj.SUBTIPOAREADESC + '</td>';
                        htmlbody += '   <td><input class="form-control form-control-sm" id="txt_' + obj.TIPOAREA + '_' + obj.SUBTIPOAREA + '_1" maxlength="10" onkeypress = "return utilSigo.onKeyDecimal(event, this);" onblur="return utilSigo.onBlurFourDecimalDI(this,\'Área\');" value="' + (obj.AREA == 0 ? '' : + obj.AREA) + '" ></td>';
                        htmlbody += '</tr>';
                        break;
                    case 2:
                    case 3:
                    case 4:
                    case 5:
                    case 7:
                    case 10:
                    case 11:
                    case 12:
                        htmlbody += '<tr>';
                        htmlbody += '   <td>' + obj.SUBTIPOAREADESC + '</td>';
                        htmlbody += '   <td><input class="form-control form-control-sm" id="txt_' + obj.TIPOAREA + '_' + obj.SUBTIPOAREA + '_1" maxlength="10" onkeypress = "return utilSigo.onKeyDecimal(event, this);" onblur="return utilSigo.onBlurFourDecimalDI(this,\'Área\');" value="' + (obj.AREA == 0 ? '' : + obj.AREA) + '" ></td>';
                        htmlbody += '</tr>';
                        break;
                    case 6:
                        objPosSeis = ManTHabilitante.DataDivisionInterna.filter((divInt) => divInt.SUBTIPOAREA == 6);
                        objPosOcho = ManTHabilitante.DataDivisionInterna.filter((divInt) => divInt.SUBTIPOAREA == 8);
                        objPosNueve = ManTHabilitante.DataDivisionInterna.filter((divInt) => divInt.SUBTIPOAREA == 9);
                        i += objPosSeis.length - 1;
                        for (var j = 0; j < objPosSeis.length; j++) {
                            let objseis = objPosSeis[j];

                            if (j == 0) {
                                htmlbody += '<tr>';
                                htmlbody += '   <td rowspan="' + (4 + objPosSeis.length + objPosOcho.length + objPosNueve.length).toString() + '">ÁREA SIN COBERTURA DE BOSQUES NATURALES</td>';
                                htmlbody += '   <td rowspan="' + (objPosSeis.length).toString() + '">' + objseis.SUBTIPOAREADESC + '</td>';
                                htmlbody += '   <td>';
                                htmlbody += '       <div class="input-group input-group-sm">';
                                if (objPosSeis.length == 1) {
                                    htmlbody += '           <input class="form-control form-control-sm cl_' + objseis.TIPOAREA + '_' + objseis.SUBTIPOAREA + '" id="atxt_' + objseis.TIPOAREA + '_' + objseis.SUBTIPOAREA + '_' + (j + 1).toString() + '" maxlength="20" placeholder="Descripción" onkeypress = "return utilSigo.checkLetter(event);" value="' + (objseis.DESCRIPCIONAREA) + '" >';
                                    htmlbody += '           <input class="form-control form-control-sm" id="txt_' + objseis.TIPOAREA + '_' + objseis.SUBTIPOAREA + '_' + (j + 1).toString() + '" maxlength="10" onkeypress="return utilSigo.onKeyDecimal(event, this);" value="' + (objseis.AREA == 0 ? '' : + objseis.AREA) + '" >';
                                    htmlbody += '           <span class="input-group-text" id="spa_' + objseis.TIPOAREA + '_' + objseis.SUBTIPOAREA + '_' + (j + 1).toString() + '"><i class="fa fa-plus" style="cursor:pointer;" id="i_' + objseis.TIPOAREA + '_' + objseis.SUBTIPOAREA + '_' + (j + 1).toString() + '" onclick="ManTHabilitante.fnAgregarArea(this);" data-toggle="tooltip" data-placement="top" title="Agregar"></i></span>';
                                } else {
                                    htmlbody += '           <input class="form-control form-control-sm cl_' + objseis.TIPOAREA + '_' + objseis.SUBTIPOAREA + '" id="atxt_' + objseis.TIPOAREA + '_' + objseis.SUBTIPOAREA + '_' + (j + 1).toString() + '" maxlength="20" placeholder="Descripción" onkeypress = "return utilSigo.checkLetter(event);" disabled="disabled" value="' + (objseis.DESCRIPCIONAREA) + '" >';
                                    htmlbody += '           <input class="form-control form-control-sm"  id="txt_' + objseis.TIPOAREA + '_' + objseis.SUBTIPOAREA + '_' + (j + 1).toString() + '" maxlength="10" onkeypress="return utilSigo.onKeyDecimal(event, this);" disabled="disabled" value="' + (objseis.AREA == 0 ? '' : + objseis.AREA) + '" >';
                                }
                                htmlbody += '       </div> ';
                                htmlbody += '   </td> ';
                                htmlbody += '</tr>';
                            } else if (objPosSeis.length == (j + 1)) {
                                htmlbody += '<tr>';
                                htmlbody += '   <td>';
                                htmlbody += '       <div class="input-group input-group-sm">';
                                htmlbody += '           <input class="form-control form-control-sm cl_' + objseis.TIPOAREA + '_' + objseis.SUBTIPOAREA + '" id="atxt_' + objseis.TIPOAREA + '_' + objseis.SUBTIPOAREA + '_' + (j + 1).toString() + '" maxlength="20" placeholder="Descripción" onkeypress = "return utilSigo.checkLetter(event);" value="' + (objseis.DESCRIPCIONAREA) + '" >';
                                htmlbody += '           <input class="form-control form-control-sm"  id="txt_' + objseis.TIPOAREA + '_' + objseis.SUBTIPOAREA + '_' + (j + 1).toString() + '" maxlength="10" onkeypress="return utilSigo.onKeyDecimal(event, this);" value="' + (objseis.AREA == 0 ? '' : + objseis.AREA) + '" >';
                                htmlbody += '           <span class="input-group-text" id="spa_' + objseis.TIPOAREA + '_' + objseis.SUBTIPOAREA + '_' + (j + 1).toString() + '"><i class="fa fa-plus" style="cursor:pointer;" id="i_' + objseis.TIPOAREA + '_' + objseis.SUBTIPOAREA + '_' + (j + 1).toString() + '" onclick="ManTHabilitante.fnAgregarArea(this);" data-toggle="tooltip" data-placement="top" title="Agregar"></i></span>';
                                htmlbody += '           <span class="input-group-text" id="spd_' + objseis.TIPOAREA + '_' + objseis.SUBTIPOAREA + '_' + (j + 1).toString() + '"><i class="fa fa-minus" style="cursor:pointer;" id="i_' + objseis.TIPOAREA + '_' + objseis.SUBTIPOAREA + '_' + (j + 1).toString() + '" onclick="ManTHabilitante.fnEliminarArea(this);" data-toggle="tooltip" data-placement="top" title="Eliminar"></i></span>';
                                htmlbody += '       </div> ';
                                htmlbody += '   </td> ';
                                htmlbody += '</tr>';
                            } else {
                                htmlbody += '<tr>';
                                htmlbody += '   <td>';
                                htmlbody += '       <div class="input-group input-group-sm">';
                                htmlbody += '           <input class="form-control form-control-sm cl_' + objseis.TIPOAREA + '_' + objseis.SUBTIPOAREA + '" id="atxt_' + objseis.TIPOAREA + '_' + objseis.SUBTIPOAREA + '_' + (j + 1).toString() + '" maxlength="20" placeholder="Descripción" onkeypress = "return utilSigo.checkLetter(event);" disabled="disabled" value="' + (objseis.DESCRIPCIONAREA) + '" >';
                                htmlbody += '           <input class="form-control form-control-sm" id="txt_' + objseis.TIPOAREA + '_' + objseis.SUBTIPOAREA + '_' + (j + 1).toString() + '" maxlength="10" onkeypress="return utilSigo.onKeyDecimal(event, this);" disabled="disabled" value="' + (objseis.AREA == 0 ? '' : + objseis.AREA) + '" >';
                                htmlbody += '       </div> ';
                                htmlbody += '   </td> ';
                                htmlbody += '</tr>';
                            }
                        }
                        break;
                    case 8:
                        i += objPosOcho.length - 1;
                        for (var j = 0; j < objPosOcho.length; j++) {
                            let objocho = objPosOcho[j];

                            if (j == 0) {
                                htmlbody += '<tr>';
                                htmlbody += '   <td rowspan="' + (objPosOcho.length).toString() + '">' + objocho.SUBTIPOAREADESC + '</td>';
                                htmlbody += '   <td>';
                                htmlbody += '       <div class="input-group input-group-sm">';
                                if (objPosOcho.length == 1) {
                                    htmlbody += '           <input class="form-control form-control-sm cl_' + objocho.TIPOAREA + '_' + objocho.SUBTIPOAREA + '" id="atxt_' + objocho.TIPOAREA + '_' + objocho.SUBTIPOAREA + '_' + (j + 1).toString() + '" maxlength="20" placeholder="Descripción" onkeypress = "return utilSigo.checkLetter(event);" value="' + (objocho.DESCRIPCIONAREA) + '" >';
                                    htmlbody += '           <input class="form-control form-control-sm"  id="txt_' + objocho.TIPOAREA + '_' + objocho.SUBTIPOAREA + '_' + (j + 1).toString() + '" maxlength="10" onkeypress="return utilSigo.onKeyDecimal(event, this);" value="' + (objocho.AREA == 0 ? '' : + objocho.AREA) + '" >';
                                    htmlbody += '           <span class="input-group-text" id="spa_' + objocho.TIPOAREA + '_' + objocho.SUBTIPOAREA + '_' + (j + 1).toString() + '"><i class="fa fa-plus" style="cursor:pointer;" id="i_' + objocho.TIPOAREA + '_' + objocho.SUBTIPOAREA + '_' + (j + 1).toString() + '" onclick="ManTHabilitante.fnAgregarArea(this);" data-toggle="tooltip" data-placement="top" title="Agregar"></i></span>';
                                } else {
                                    htmlbody += '           <input class="form-control form-control-sm cl_' + objocho.TIPOAREA + '_' + objocho.SUBTIPOAREA + '" id="atxt_' + objocho.TIPOAREA + '_' + objocho.SUBTIPOAREA + '_' + (j + 1).toString() + '" maxlength="20" placeholder="Descripción" onkeypress = "return utilSigo.checkLetter(event);" disabled="disabled" value="' + (objocho.DESCRIPCIONAREA) + '" >';
                                    htmlbody += '           <input class="form-control form-control-sm" id="txt_' + objocho.TIPOAREA + '_' + objocho.SUBTIPOAREA + '_' + (j + 1).toString() + '" maxlength="10" onkeypress="return utilSigo.onKeyDecimal(event, this);" disabled="disabled" value="' + (objocho.AREA == 0 ? '' : + objocho.AREA) + '" >';
                                }
                                htmlbody += '       </div> ';
                                htmlbody += '   </td> ';
                                htmlbody += '</tr>';
                            } else if (objPosOcho.length == (j + 1)) {
                                htmlbody += '<tr>';
                                htmlbody += '   <td>';
                                htmlbody += '       <div class="input-group input-group-sm">';
                                htmlbody += '           <input class="form-control form-control-sm cl_' + objocho.TIPOAREA + '_' + objocho.SUBTIPOAREA + '" id="atxt_' + objocho.TIPOAREA + '_' + objocho.SUBTIPOAREA + '_' + (j + 1).toString() + '" maxlength="20" placeholder="Descripción" onkeypress = "return utilSigo.checkLetter(event);" value="' + (objocho.DESCRIPCIONAREA) + '" >';
                                htmlbody += '           <input class="form-control form-control-sm" id="txt_' + objocho.TIPOAREA + '_' + objocho.SUBTIPOAREA + '_' + (j + 1).toString() + '" maxlength="10" onkeypress="return utilSigo.onKeyDecimal(event, this);" value="' + (objocho.AREA == 0 ? '' : + objocho.AREA) + '" >';
                                htmlbody += '           <span class="input-group-text" id="spa_' + objocho.TIPOAREA + '_' + objocho.SUBTIPOAREA + '_' + (j + 1).toString() + '"><i class="fa fa-plus" style="cursor:pointer;" id="i_' + objocho.TIPOAREA + '_' + objocho.SUBTIPOAREA + '_' + (j + 1).toString() + '" onclick="ManTHabilitante.fnAgregarArea(this);" data-toggle="tooltip" data-placement="top" title="Agregar"></i></span>';
                                htmlbody += '           <span class="input-group-text" id="spd_' + objocho.TIPOAREA + '_' + objocho.SUBTIPOAREA + '_' + (j + 1).toString() + '"><i class="fa fa-minus" style="cursor:pointer;" id="i_' + objocho.TIPOAREA + '_' + objocho.SUBTIPOAREA + '_' + (j + 1).toString() + '" onclick="ManTHabilitante.fnEliminarArea(this);" data-toggle="tooltip" data-placement="top" title="Eliminar"></i></span>';
                                htmlbody += '       </div> ';
                                htmlbody += '   </td> ';
                                htmlbody += '</tr>';
                            } else {
                                htmlbody += '<tr>';
                                htmlbody += '   <td>';
                                htmlbody += '       <div class="input-group input-group-sm">';
                                htmlbody += '           <input class="form-control form-control-sm cl_' + objocho.TIPOAREA + '_' + objocho.SUBTIPOAREA + '" id="atxt_' + objocho.TIPOAREA + '_' + objocho.SUBTIPOAREA + '_' + (j + 1).toString() + '" maxlength="20" placeholder="Descripción" onkeypress = "return utilSigo.checkLetter(event);" disabled="disabled" value="' + (objocho.DESCRIPCIONAREA) + '" >';
                                htmlbody += '           <input class="form-control form-control-sm" id="txt_' + objocho.TIPOAREA + '_' + objocho.SUBTIPOAREA + '_' + (j + 1).toString() + '" maxlength="10" onkeypress="return utilSigo.onKeyDecimal(event, this);" disabled="disabled" value="' + (objocho.AREA == 0 ? '' : + objocho.AREA) + '" >';
                                htmlbody += '       </div> ';
                                htmlbody += '   </td> ';
                                htmlbody += '</tr>';
                            }
                        }
                        break;
                    case 9:
                        i += objPosNueve.length - 1;                        
                        for (var j = 0; j < objPosNueve.length; j++) {
                            let objnueve = objPosNueve[j];
                            
                            if (j == 0) {
                                htmlbody += '<tr>';
                                htmlbody += '   <td rowspan="' + (objPosNueve.length).toString() + '">' + objnueve.SUBTIPOAREADESC + '</td>';
                                htmlbody += '   <td>';
                                htmlbody += '       <div class="input-group input-group-sm">';
                                if (objPosNueve.length == 1) {
                                    htmlbody += '           <input class="form-control form-control-sm cl_' + objnueve.TIPOAREA + '_' + objnueve.SUBTIPOAREA + '" id="atxt_' + objnueve.TIPOAREA + '_' + objnueve.SUBTIPOAREA + '_' + (j + 1).toString() + '" maxlength="20" placeholder="Descripción" onkeypress = "return utilSigo.checkLetter(event);" value="' + (objnueve.DESCRIPCIONAREA) + '" >';
                                    htmlbody += '           <input class="form-control form-control-sm" id="txt_' + objnueve.TIPOAREA + '_' + objnueve.SUBTIPOAREA + '_' + (j + 1).toString() + '" maxlength="10" onkeypress="return utilSigo.onKeyDecimal(event, this);" value="' + (objnueve.AREA == 0 ? '' : + objnueve.AREA) + '" >';
                                    htmlbody += '           <span class="input-group-text" id="spa_' + objnueve.TIPOAREA + '_' + objnueve.SUBTIPOAREA + '_' + (j + 1).toString() + '"><i class="fa fa-plus" style="cursor:pointer;" id="i_' + objnueve.TIPOAREA + '_' + objnueve.SUBTIPOAREA + '_' + (j + 1).toString() + '" onclick="ManTHabilitante.fnAgregarArea(this);" data-toggle="tooltip" data-placement="top" title="Agregar"></i></span>';
                                } else {
                                    htmlbody += '           <input class="form-control form-control-sm cl_' + objnueve.TIPOAREA + '_' + objnueve.SUBTIPOAREA + '" id="atxt_' + objnueve.TIPOAREA + '_' + objnueve.SUBTIPOAREA + '_' + (j + 1).toString() + '" maxlength="20" placeholder="Descripción" onkeypress = "return utilSigo.checkLetter(event);" disabled="disabled" value="' + (objnueve.DESCRIPCIONAREA) + '" >';
                                    htmlbody += '           <input class="form-control form-control-sm" id="txt_' + objnueve.TIPOAREA + '_' + objnueve.SUBTIPOAREA + '_' + (j + 1).toString() + '" maxlength="10" onkeypress="return utilSigo.onKeyDecimal(event, this);" disabled="disabled" value="' + (objnueve.AREA == 0 ? '' : + objnueve.AREA) + '" >';
                                }
                                htmlbody += '       </div> ';
                                htmlbody += '   </td> ';
                                htmlbody += '</tr>';
                            } else if (objPosNueve.length == (j + 1)) {
                                htmlbody += '<tr>';
                                htmlbody += '   <td>';
                                htmlbody += '       <div class="input-group input-group-sm">';
                                htmlbody += '           <input class="form-control form-control-sm cl_' + objnueve.TIPOAREA + '_' + objnueve.SUBTIPOAREA + '" id="atxt_' + objnueve.TIPOAREA + '_' + objnueve.SUBTIPOAREA + '_' + (j + 1).toString() + '" maxlength="20" placeholder="Descripción" onkeypress = "return utilSigo.checkLetter(event);" value="' + (objnueve.DESCRIPCIONAREA) + '" >';
                                htmlbody += '           <input class="form-control form-control-sm" id="txt_' + objnueve.TIPOAREA + '_' + objnueve.SUBTIPOAREA + '_' + (j + 1).toString() + '" maxlength="10" onkeypress="return utilSigo.onKeyDecimal(event, this);" value="' + (objnueve.AREA == 0 ? '' : + objnueve.AREA) + '" >';
                                htmlbody += '           <span class="input-group-text" id="spa_' + objnueve.TIPOAREA + '_' + objnueve.SUBTIPOAREA + '_' + (j + 1).toString() + '"><i class="fa fa-plus" style="cursor:pointer;" id="i_' + objnueve.TIPOAREA + '_' + objnueve.SUBTIPOAREA + '_' + (j + 1).toString() + '" onclick="ManTHabilitante.fnAgregarArea(this);" data-toggle="tooltip" data-placement="top" title="Agregar"></i></span>';
                                htmlbody += '           <span class="input-group-text" id="spd_' + objnueve.TIPOAREA + '_' + objnueve.SUBTIPOAREA + '_' + (j + 1).toString() + '"><i class="fa fa-minus" style="cursor:pointer;" id="i_' + objnueve.TIPOAREA + '_' + objnueve.SUBTIPOAREA + '_' + (j + 1).toString() + '" onclick="ManTHabilitante.fnEliminarArea(this);" data-toggle="tooltip" data-placement="top" title="Eliminar"></i></span>';
                                htmlbody += '       </div> ';
                                htmlbody += '   </td> ';
                                htmlbody += '</tr>';
                            } else {
                                htmlbody += '<tr>';
                                htmlbody += '   <td>';
                                htmlbody += '       <div class="input-group input-group-sm">';
                                htmlbody += '           <input class="form-control form-control-sm cl_' + objnueve.TIPOAREA + '_' + objnueve.SUBTIPOAREA + '" id="atxt_' + objnueve.TIPOAREA + '_' + objnueve.SUBTIPOAREA + '_' + (j + 1).toString() + '" maxlength="20" placeholder="Descripción" onkeypress = "return utilSigo.checkLetter(event);" disabled="disabled" value="' + (objnueve.DESCRIPCIONAREA) + '" >';
                                htmlbody += '           <input class="form-control form-control-sm" id="txt_' + objnueve.TIPOAREA + '_' + objnueve.SUBTIPOAREA + '_' + (j + 1).toString() + '" maxlength="10" onkeypress="return utilSigo.onKeyDecimal(event, this);" disabled="disabled" value="' + (objnueve.AREA == 0 ? '' : + objnueve.AREA) + '" >';
                                htmlbody += '       </div> ';
                                htmlbody += '   </td> ';
                                htmlbody += '</tr>';
                            }
                        }
                        break;


                }

            }
        }
        $('#tbodyDivIntPreTot').html(htmlbody);
        ManTHabilitante.fnCalcularDivisionInterna();
    }
};

ManTHabilitante.fnBuscarPersona = function (_dom, _tipoPersona) {
    var valCodPTipo;

    switch (_dom) {
        case "TITULAR":
        case "TITULAR_ADENDA":
            valCodPTipo = "0000001"; break;
        case "RLEGAL":
            valCodPTipo = "0000002"; break;
        case "FUNC_APRUEBA_PROYECTO":
        case "FUNC_AUTORIZA_FUNCIONAMIENTO":
            valCodPTipo = "0000006"; break;
        default:
            valCodPTipo = "TODOS";
    }

    var url = urlLocalSigo + "General/Controles/_BuscarPersonaGeneral";
    var option = {
        url: url,
        type: 'GET',
        datos: {
            asBusGrupo: "PERSONA", asCodPTipo: valCodPTipo, asTipoPersona: _tipoPersona,
            asFormulario: "THabilitante", asCodMod: ManTHabilitante.frmTHabilitanteRegistro.find("#hdfItemModalidadCodigo").val(), asTipoCargo: _dom
        },
        divId: "mdlBuscarPersona"
    };
    utilSigo.fnOpenModal(option, function () {
        _bPerGen.fnAsignarDatos = function (obj) {

            if (obj != null && obj != "") {
                var data = _bPerGen.dtBuscarPerona.row($(obj).parents('tr')).data();
                //console.log('datos', data);
                switch (_dom) {
                    case "TITULAR":
                        ManTHabilitante.frmTHabilitanteRegistro.find("#hdtxtTitularTipo").val(data["COD_PERSONA"]);
                        ManTHabilitante.frmTHabilitanteRegistro.find("#txtTitularTipo").val(data["PERSONA"]);
                        ManTHabilitante.frmTHabilitanteRegistro.find("#hdtipotxtTitularTipo").val(_tipoPersona);
                        ManTHabilitante.frmTHabilitanteRegistro.find("#txtUbigeo").val(data["UBIGEO"]);
                        ManTHabilitante.frmTHabilitanteRegistro.find("#txtDirecion").val(data["DIRECCION"]);
                        break;
                    case "RLEGAL":
                        ManTHabilitante.frmTHabilitanteRegistro.find("#hdfItemRLegalCodigo").val(data["COD_PERSONA"]);
                        ManTHabilitante.frmTHabilitanteRegistro.find("#fItemRLegalCodigo").val(data["PERSONA"]);
                        break;
                    case "TITULAR_ADENDA":
                        ManTHabilitante.frmTHabilitanteRegistro.find("#hdfItemCamTitularCodigo").val(data["COD_PERSONA"]);
                        ManTHabilitante.frmTHabilitanteRegistro.find("#fItemCamTitularCodigo").val(data["PERSONA"]);
                        break;
                    case "FUNC_APRUEBA_PROYECTO":
                        ManTHabilitante.frmTHabilitanteRegistro.find("#hdfItemRAPFuncionarioCodigo").val(data["COD_PERSONA"]);
                        ManTHabilitante.frmTHabilitanteRegistro.find("#fItemRAPFuncionarioCodigo").val(data["PERSONA"]);
                        break;
                    case "FUNC_AUTORIZA_FUNCIONAMIENTO":
                        ManTHabilitante.frmTHabilitanteRegistro.find("#hdfItemRAFFuncionarioCodigo").val(data["COD_PERSONA"]);
                        ManTHabilitante.frmTHabilitanteRegistro.find("#fItemRAFFuncionarioCodigo").val(data["PERSONA"]);
                        break;
                }
                utilSigo.fnCloseModal("mdlBuscarPersona");
            }
        };
        _bPerGen.fnInit();
    });
};

ManTHabilitante.cargarUbigeoModal = function (control) {
    var _hrModal = $.ajax({
        url: urlLocalSigo + "THabilitante/Controles/_Ubigeo",
        type: 'POST',
        data: { formOrigen: "frmTHabilitanteRegistro", controlOrigen: control },
        dataType: 'html',
        success: function (data) {
            utilSigo.unblockUIGeneral();
            if (_hrModal.status != 203) {
                $("#personaUbigeoModal").html(data);
                utilSigo.modalDraggable($("#personaUbigeoModal"), '.modal-header');
                $("#personaUbigeoModal").modal({ keyboard: true, backdrop: 'static' });
            }
        },
        beforeSend: function () {
            utilSigo.blockUIGeneral();
        },
        error: function (jqXHR, error, errorThrown) {
            utilSigo.unblockUIGeneral();
            utilSigo.toastError("Error", "Sucedio un Error Inesperado, Comuniquese con el Administrador");
            // console.log(jqXHR.responseText);
        },
        statusCode: {
            203: () => { utilSigo.unblockUIGeneral(); utilSigo.toastInfo("Aviso", "El usuario perdio la sesión. Vuelva ingresar al sistema"); }
        }
    });
};
//cuando es autorizacionde fauna silvestre Ex situ - Modlidad 0000002
ManTHabilitante.iniciarModalidadFauna = function () {
    ManTHabilitante.frmTHabilitanteRegistro.find("#txtItemRAPFecha").datepicker({ format: "dd/mm/yyyy", autoclose: true, language: 'es' });
    ManTHabilitante.frmTHabilitanteRegistro.find("#txtItemRAFFecha").datepicker({ format: "dd/mm/yyyy", autoclose: true, language: 'es' });

};
//PnlItemDGeneral
ManTHabilitante.DGeneral = {};
ManTHabilitante.DGeneral.descargarPlantilla = function () {
    window.location.href = urlLocalSigo + "THabilitante/ManTHabilitante/Download";
};
ManTHabilitante.DGeneral.filaEditarVertice = "";
ManTHabilitante.DGeneral.prepararDatosVer = function () {
    var $tbItemVertice = $('#tbItemVertice').dataTable();

    if ($tbItemVertice != undefined) {
        ManTHabilitante.ListTDDVVERTICE = [];//vaciando arreglo    
        var $rows = $tbItemVertice.$("tr");
        var countFilas = $rows.length;
        if (countFilas > 0) {
            $.each($rows, function (i, o) {
                var estadoItemReg = $(o).find(".hdEstadoItemGen").val();
                if (parseInt(estadoItemReg) == 1 || parseInt(estadoItemReg) == 2) { //solo envio los registros nuevos y modificados
                    var $columna = $(o).find('td');
                    ManTHabilitante.ListTDDVVERTICE.push({
                        VERTICE: $columna.eq(3).text().trim(),
                        ZONA: $(o).find(".hdDdlItemZona_UTM").val().trim(),
                        COORDENADA_ESTE: $columna.eq(5).text().trim(),
                        COORDENADA_NORTE: $columna.eq(6).text().trim(),
                        OBSERVACION: $columna.eq(7).text().trim(),
                        RegEstado: $(o).find(".hdEstadoItemGen").val(),
                        COD_SECUENCIAL: $(o).find(".hdCodSecuencial").val().trim(),
                        COD_SECUENCIAL_ADENDA: $(o).find(".hdfItemCodSecuencialAdenda").val().trim()
                    });
                }
            });
            return true;
        }
        else {
            return false;
        }
    }
    else {
        return false;
    }
};
ManTHabilitante.DGeneral.closeModalVert = function () {
    ManTHabilitante.DGeneral.limpiarControles();

    //limpiando estilos si lo tienen
    $(':input', ManTHabilitante.DGeneral.frmVertice)
        .removeClass('border-danger')
        .removeAttr('data-toggle')
        .removeAttr('data-placement')
        .removeAttr('data-original-title');
    $('#PDivItemVertice').modal('hide');
};
ManTHabilitante.DGeneral.limpiarControles = function () {
    ManTHabilitante.DGeneral.frmVertice.find("#txtItemVert_Vertice").val('');
    ManTHabilitante.DGeneral.frmVertice.find("#ddlItemZona_UTM").val('0000000').select2();
    ManTHabilitante.DGeneral.frmVertice.find("#txtItemVert_CEste").val('');
    ManTHabilitante.DGeneral.frmVertice.find("#txtItemVert_CNorte").val('');
    ManTHabilitante.DGeneral.frmVertice.find("#txtItemVert_Observacion").val('');
    ManTHabilitante.DGeneral.frmVertice.find("#hdfItemVert_RegEstado").val(1);
    ManTHabilitante.DGeneral.frmVertice.find("#hdOrigen").val('tbVertice');
    ManTHabilitante.DGeneral.frmVertice.find("#btnRegistrarVertice").text('Aceptar');
};
ManTHabilitante.DGeneral.mostrarModal = function (origen) {
    ManTHabilitante.DGeneral.frmVertice.find("#hdfItemVert_RegEstado").val(1);
    ManTHabilitante.DGeneral.frmVertice.find("#hdOrigen").val(origen);
    utilSigo.modalDraggable($("#PDivItemVertice"), '.modal-header');
    $("#PDivItemVertice").modal({ keyboard: true, backdrop: 'static' });
};
ManTHabilitante.DGeneral.editVertice = function (obj) {
    ManTHabilitante.DGeneral.frmVertice.find("#btnRegistrarVertice").text('Modificar');
    ManTHabilitante.DGeneral.filaEditarVertice = $(obj).closest('tr');
    var filaEdit = ManTHabilitante.DGeneral.filaEditarVertice;
    //asignando valor a modificar
    var columnasEdit = filaEdit.find('td');
    ManTHabilitante.DGeneral.frmVertice.find("#txtItemVert_Vertice").val(columnasEdit.eq(3).text().trim());
    ManTHabilitante.DGeneral.frmVertice.find("#ddlItemZona_UTM").val(filaEdit.find(".hdDdlItemZona_UTM").val()).select2();
    ManTHabilitante.DGeneral.frmVertice.find("#txtItemVert_CEste").val(columnasEdit.eq(5).text().trim());
    ManTHabilitante.DGeneral.frmVertice.find("#txtItemVert_CNorte").val(columnasEdit.eq(6).text().trim());
    ManTHabilitante.DGeneral.frmVertice.find("#txtItemVert_Observacion").val(columnasEdit.eq(7).text().trim());
    ManTHabilitante.DGeneral.frmVertice.find("#hdfItemVert_RegEstado").val(0);
    ManTHabilitante.DGeneral.frmVertice.find("#hdOrigen").val('tbVertice');
    // mostrando modal
    utilSigo.modalDraggable($("#PDivItemVertice"), '.modal-header');
    $("#PDivItemVertice").modal({ keyboard: true, backdrop: 'static' });
};
ManTHabilitante.DGeneral.eliminarVerticeTabla = function (obj) {
    utilSigo.dialogConfirm("Confirmacion", "¿ Está seguro de Eliminar el Registro Seleccionado ?", function (r) {
        if (r) {
            var $trEliminar = $(obj).closest('tr');
            var estadoRegisItemSelec = $trEliminar.find(".hdEstadoItemGen").val();
            if (parseInt(estadoRegisItemSelec) == 0 || parseInt(estadoRegisItemSelec) == 2) {//guardando filas que vinieron de la bd en un temporal
                var columnasFila = $trEliminar.find('td');
                ManTHabilitante.ListEliTABLA.push({
                    EliTABLA: "THABILITANTE_DGENERAL_DET_VERTICE",
                    EliVALOR01: columnasFila.eq(3).text().trim(),
                    EliVALOR02: $trEliminar.find(".hdCodSecuencial").val().trim(),
                    EliVALOR03: ""
                    , EliVALOR04: $trEliminar.find(".hdfItemCodSecuencialAdenda").val().trim()
                });
            }
            //eliminando
            ManTHabilitante.DGeneral.dtItemVertice.row($trEliminar).remove().draw();
            ManTHabilitante.DGeneral.enumTbVertice();
        }
    });
};
ManTHabilitante.DGeneral.eliminarVerticeTablaAll = function () {
    var $tbItemVertice = $('#tbItemVertice').dataTable();
    var $trsEliminar = $tbItemVertice.$("tr");
    if ($trsEliminar.length > 0) {
        utilSigo.dialogConfirm("", "Está seguro de Eliminar Todo los Registros?", function (r) {
            if (r) {
                $.each($trsEliminar, function (i, o) {
                    var estadoItemBD = $(o).find(".hdEstadoItemGen").val();
                    if (parseInt(estadoItemBD) == 0 || parseInt(estadoItemBD) == 2) {
                        var $columna = $(o).find('td');
                        ManTHabilitante.ListEliTABLA.push({
                            EliTABLA: "THABILITANTE_DGENERAL_DET_VERTICE",
                            EliVALOR01: $columna.eq(3).text().trim(),
                            EliVALOR02: $(o).find(".hdCodSecuencial").val().trim(),
                            EliVALOR03: ""
                            , EliVALOR04: $(o).find(".hdfItemCodSecuencialAdenda").val().trim()
                        });
                    }
                });
                ManTHabilitante.DGeneral.dtItemVertice.clear().draw();
            }
        });
    }
    else {
        utilSigo.toastWarning("Aviso", "No hay Registros a Eliminar");
    }
};
ManTHabilitante.DGeneral.enumTbVertice = function () {
    var tverticeNum = $('#tbItemVertice').DataTable();
    tverticeNum.on('order.dt', function () {
        tverticeNum.column(2, {}).nodes().each(function (cell, i) {
            cell.innerHTML = i + 1;
        });
    }).draw();
};
ManTHabilitante.DGeneral.exportarExcel = function () {
    ManTHabilitante.DGeneral.prepararDatosVer();
    var excel = "<html><head><meta charset='UTF-8'/></head><body style='background-color:yellow'><table style='background-color:gray'><thead><tr>";

    excel += '<th style="background-color:blue;color:white">VERTICE</th>';
    excel += '<th style="background-color:blue;color:white">ZONA</th>';
    excel += '<th style="background-color:blue;color:white">COORDENADA_ESTE</th>';
    excel += '<th style="background-color:blue;color:white">COORDENADA_NORTE</th>';
    excel += '<th style="background-color:blue;color:white">OBSERVACION</th>';
    excel += "</tr></thead><tbody>";

    for (var i = 0; i < ManTHabilitante.ListTDDVVERTICE.length; i++) {
        excel += '<tr>';
        excel += '<td>' + ManTHabilitante.ListTDDVVERTICE[i].VERTICE + '</td>';
        excel += '<td>' + ManTHabilitante.ListTDDVVERTICE[i].ZONA + '</td>';
        excel += '<td>' + ManTHabilitante.ListTDDVVERTICE[i].COORDENADA_ESTE + '</td>';
        excel += '<td>' + ManTHabilitante.ListTDDVVERTICE[i].COORDENADA_NORTE + '</td>';
        excel += '<td>' + ManTHabilitante.ListTDDVVERTICE[i].OBSERVACION + '</td>';
        excel += '</tr>';
    }
    excel += "</tbody></table></body></html>";
    var blob = new Blob([excel], { "type": "application/vnd.ms-excel" });

    this.href = (window.URL ? URL : webkitURL).createObjectURL(blob);// URL.createObjectURL(blob);
    this.download = "Vertices.xls";
};
ManTHabilitante.DGeneral.agregarVerticeExcel = function (data) {
    var trsAdd = [];
    for (var i = 0; i < data.length; i++) {
        var filaAdd = {
            "VERTICE": data[i].VERTICE,
            "ZONA": data[i].ZONA,
            "COORDENADA_ESTE": data[i].COORDENADA_ESTE,
            "COORDENADA_NORTE": data[i].COORDENADA_NORTE,
            "OBSERVACION": data[i].OBSERVACION,
            "COD_SECUENCIAL": 0,
            "COD_SECUENCIAL_ADENDA": data[i].COD_SECUENCIAL_ADENDA,
            "RegEstado": 1
        };
        trsAdd.push(filaAdd);
    }
    ManTHabilitante.DGeneral.dtItemVertice.rows.add(trsAdd).draw();
    ManTHabilitante.DGeneral.enumTbVertice();
    ManTHabilitante.DGeneral.dtItemVertice.page('last').draw('page');
};
ManTHabilitante.DGeneral.agregarVertice = function () {
    var valItemVert_Vertice = ManTHabilitante.DGeneral.frmVertice.find("#txtItemVert_Vertice").val().trim();
    var valItemZona_UTM = ManTHabilitante.DGeneral.frmVertice.find("#ddlItemZona_UTM").val();
    var textItemZona_UTM = ManTHabilitante.DGeneral.frmVertice.find("#ddlItemZona_UTM option:selected").text();
    var valItemVert_CEste = ManTHabilitante.DGeneral.frmVertice.find("#txtItemVert_CEste").val().trim();
    var valItemVert_CNorte = ManTHabilitante.DGeneral.frmVertice.find("#txtItemVert_CNorte").val().trim();
    var valItemVert_Observacion = ManTHabilitante.DGeneral.frmVertice.find("#txtItemVert_Observacion").val().trim().toUpperCase();
    var valEstadoOpcion = ManTHabilitante.DGeneral.frmVertice.find("#hdfItemVert_RegEstado").val();
    var estadoItemReg = 1;
    if (parseInt(valEstadoOpcion) == 1) { //agregar registro tabla  
        var filaAdd = {
            "VERTICE": valItemVert_Vertice,
            "ZONA": textItemZona_UTM,
            "COORDENADA_ESTE": valItemVert_CEste,
            "COORDENADA_NORTE": valItemVert_CNorte,
            "OBSERVACION": valItemVert_Observacion,
            "COD_SECUENCIAL": 0,
            "COD_SECUENCIAL_ADENDA": ManTHabilitante.frmTHabilitanteRegistro.find("#hdfCodSecuencialAdenda").val(),
            "RegEstado": estadoItemReg

        };
        ManTHabilitante.DGeneral.dtItemVertice.row.add(filaAdd).draw();
        ManTHabilitante.DGeneral.enumTbVertice();
        ManTHabilitante.DGeneral.dtItemVertice.page('last').draw('page');
    }
    else {//modificar registro tabla y verificar data origen bd
        if (ManTHabilitante.DGeneral.filaEditarVertice != "") {
            var estadoRegisItemSelec = ManTHabilitante.DGeneral.filaEditarVertice.find(".hdEstadoItemGen").val();
            if (parseInt(estadoRegisItemSelec) == 0) estadoItemReg = 2;
            //modificando
            ManTHabilitante.DGeneral.filaEditarVertice.find(".hdEstadoItemGen").val(estadoItemReg);
            ManTHabilitante.DGeneral.filaEditarVertice.find(".hdDdlItemZona_UTM").val(valItemZona_UTM);
            var columnasFila = ManTHabilitante.DGeneral.filaEditarVertice.find('td');
            columnasFila.eq(3).html(valItemVert_Vertice);
            columnasFila.eq(4).html(textItemZona_UTM);
            columnasFila.eq(5).html(valItemVert_CEste);
            columnasFila.eq(6).html(valItemVert_CNorte);
            columnasFila.eq(7).html(valItemVert_Observacion);
            ManTHabilitante.DGeneral.limpiarControles();
            ManTHabilitante.DGeneral.filaEditarVertice = ""; //limpiando fila temporal
            $('#PDivItemVertice').modal('hide');
        }
        else {
            utilSigo.toastWarning("Aviso", "No hay datos a modificar");
        }
    }
};
ManTHabilitante.DGeneral.iniciarEventos = function () {
    ManTHabilitante.frmTHabilitanteRegistro.find("#txtItemContFInicio").datepicker({ format: "dd/mm/yyyy", autoclose: true, language: 'es' });
    ManTHabilitante.frmTHabilitanteRegistro.find("#txtItemContFFin").datepicker({ format: "dd/mm/yyyy", autoclose: true, language: 'es' });
    ManTHabilitante.DGeneral.frmVertice.find("#ddlItemZona_UTM").select2({ minimumResultsForSearch: -1 });
    ManTHabilitante.frmTHabilitanteRegistro.find("#txtfechaExt").datepicker({ format: "dd/mm/yyyy", autoclose: true, language: 'es' });

    ManTHabilitante.frmTHabilitanteRegistro.find("#fileselect").change(function (e) {
        ManTHabilitante.uploadFile.fileSelectHandler(e, 'fileselect');
    });
    //validacion del formulario
    // Creamos una validacion personalizada
    jQuery.validator.addMethod("invalidVertices", function (value, element) {
        switch ($(element).attr('id')) {
            case 'ddlItemZona_UTM': return value == '0000000' ? false : true;
        }
    });
    ManTHabilitante.DGeneral.frmVertice.validate({
        focusInvalid: true,
        //ignore: '', hiden predeterminado
        rules: {
            txtItemVert_Vertice: { required: true },
            ddlItemZona_UTM: { invalidVertices: true },
            txtItemVert_CEste: { required: true },
            txtItemVert_CNorte: { required: true }
        },
        messages: {
            txtItemVert_Vertice: { required: "Ingrese Vertice" },
            ddlItemZona_UTM: { invalidVertices: "Campo Requerido" },
            txtItemVert_CEste: { required: "Ingrese Coordenada" },
            txtItemVert_CNorte: { required: "Ingrese Coordenada" }
        },
        invalidHandler: function (event, validator) {//display error alert on form submit   

        },
        errorPlacement: function (error, element) {// render error placement for each input type
            var lElement = $(element);
            lElement.addClass('border-danger');
            lElement.attr('data-toggle', 'tooltip');
            lElement.attr('data-placement', 'top');
            lElement.attr('data-original-title', error.text());
            $('[data-toggle="tooltip"]').tooltip();

        },
        highlight: function (element) {

        },
        unhighlight: function (element) {

        },
        success: function (label, element) {
            var lElement = $(element);
            lElement.removeClass('border-danger');
            lElement.removeAttr('data-toggle');
            lElement.removeAttr('data-placement');
            lElement.removeAttr('data-original-title');
        },
        submitHandler: function (form) {
            var opcionOrigern = ManTHabilitante.DGeneral.frmVertice.find("#hdOrigen").val();
            if (opcionOrigern == "tbVertice") ManTHabilitante.DGeneral.agregarVertice();
            else ManTHabilitante.adend.agregarVerticeMod();
        }
    });
    ManTHabilitante.DGeneral.frmVertice.find("#btnRegistrarVertice").click(function () {
        ManTHabilitante.DGeneral.frmVertice.submit();
    });
};
//Recategorizacion
ManTHabilitante.recat = {};
ManTHabilitante.recat.filaEditarRecategorizacion = ""; //variable global
ManTHabilitante.recat.limpiarControles = function () {
    ManTHabilitante.frmTHabilitanteRegistro.find("#hdfIten_RegEstadoRecat").val(1);
    ManTHabilitante.frmTHabilitanteRegistro.find("#ddComoboMotivoRecId").val('0000000');
    ManTHabilitante.frmTHabilitanteRegistro.find("#txtFechaRecat").val('');
    ManTHabilitante.frmTHabilitanteRegistro.find("#txtNumRDRect").val('');
    ManTHabilitante.frmTHabilitanteRegistro.find("#ddModalidadTHId").val('0000000');
    ManTHabilitante.frmTHabilitanteRegistro.find("#ddClaseZoologicoRECId").val('0');
    ManTHabilitante.frmTHabilitanteRegistro.find("#txtObsRecat").val('');
    ManTHabilitante.frmTHabilitanteRegistro.find("#btnAgregarRecat").text('Agregar');
    ManTHabilitante.recat.filaEditarRecategorizacion = "";
    ManTHabilitante.frmTHabilitanteRegistro.find("#btnCancelarRecat").attr('style', 'display:none');
    ManTHabilitante.frmTHabilitanteRegistro.find(".divCambioRect").slideUp();
};
ManTHabilitante.recat.agregarRecategorizacion = function () {
    var opcionRegistroRec = ManTHabilitante.frmTHabilitanteRegistro.find("#hdfIten_RegEstadoRecat").val();
    var motivoRecId = ManTHabilitante.frmTHabilitanteRegistro.find("#ddComoboMotivoRecId").val();
    var motivoRec = ManTHabilitante.frmTHabilitanteRegistro.find("#ddComoboMotivoRecId option:selected").text();
    var fechaRec = ManTHabilitante.frmTHabilitanteRegistro.find("#txtFechaRecat").val().trim();
    var resolucionRec = ManTHabilitante.frmTHabilitanteRegistro.find("#txtNumRDRect").val().trim();
    var nuevaModalidadRec = ManTHabilitante.frmTHabilitanteRegistro.find("#ddModalidadTHId option:selected").text();
    var nuevaModalidadRecId = ManTHabilitante.frmTHabilitanteRegistro.find("#ddModalidadTHId").val();
    var nuevaClaseZoologicoRECId = ManTHabilitante.frmTHabilitanteRegistro.find("#ddClaseZoologicoRECId").val();

    ManTHabilitante.frmTHabilitanteRegistro.find("#ddClaseZoologicoId").val(ManTHabilitante.frmTHabilitanteRegistro.find("#ddClaseZoologicoRECId").val());
    if (nuevaModalidadRecId == "0000000") {
        utilSigo.toastWarning("", "Seleccione una Nueva Modalidad diferente a Ninguno");
        return false;
    }
    var observacionRec = ManTHabilitante.frmTHabilitanteRegistro.find("#txtObsRecat").val().trim();

    if (parseInt(opcionRegistroRec) == 1) { //agregar registro tabla 
        ManTHabilitante.dtRecategorizar.fnAddData(
            ['<input type="hidden" class="hdCodSecuencial" value="-1" /><input type="hidden" class="hdEstadoTbRecat" value="1" /><input type="hidden" class="hdCOD_MADENDA" value="' + motivoRecId + '" /><input type="hidden" class="hdCOD_MTIPO" value="' + nuevaModalidadRecId + '" /><i class="fa fa-lg fa-pencil-square-o" style="cursor:pointer;" onclick="ManTHabilitante.recat.cargarEditRecat(this);"></i>'
                , ''
                , motivoRec
                , fechaRec
                , resolucionRec
                , nuevaModalidadRec
                , observacionRec]);
        ManTHabilitante.recat.limpiarControles();
        var tRecNum = $('#tbRecategorizar').DataTable();
        tRecNum.on('order.dt', function () {
            tRecNum.column(1, {}).nodes().each(function (cell, i) {
                cell.innerHTML = i + 1;
            });
        }).draw();
    }
    else {//modificar registro tabla y verificar data origen bd
        if (ManTHabilitante.recat.filaEditarRecategorizacion != "") {
            var estadoRegisItemSelec = ManTHabilitante.recat.filaEditarRecategorizacion.find(".hdEstadoTbRecat").val();
            if (parseInt(estadoRegisItemSelec) == 0) estadoRegisItemSelec = 2;
            //modificando

            ManTHabilitante.recat.filaEditarRecategorizacion.find(".hdEstadoTbRecat").val(estadoRegisItemSelec);
            ManTHabilitante.recat.filaEditarRecategorizacion.find(".hdCOD_MADENDA").val(motivoRecId);
            ManTHabilitante.recat.filaEditarRecategorizacion.find(".hdCOD_MTIPO").val(nuevaModalidadRecId);
            var columnasFila = ManTHabilitante.recat.filaEditarRecategorizacion.find('td');
            columnasFila.eq(2).html(motivoRec);
            columnasFila.eq(3).html(fechaRec);
            columnasFila.eq(4).html(resolucionRec);
            columnasFila.eq(5).html(nuevaModalidadRec);
            columnasFila.eq(6).html(observacionRec);
            //columnasFila.eq(7).html(nuevaClaseZoologicoRECId);
            ManTHabilitante.recat.limpiarControles(); //limpiando 
        }
    }
};
ManTHabilitante.recat.cargarEditRecat = function (obj) {

    ManTHabilitante.frmTHabilitanteRegistro.find(".divCambioRect").slideDown();
    ManTHabilitante.recat.filaEditarRecategorizacion = $(obj).closest('tr');
    var filaEdit = ManTHabilitante.recat.filaEditarRecategorizacion;
    ManTHabilitante.frmTHabilitanteRegistro.find("#hdfIten_RegEstadoRecat").val(0);
    ManTHabilitante.frmTHabilitanteRegistro.find("#btnCancelarRecat").removeAttr('style');
    ManTHabilitante.frmTHabilitanteRegistro.find("#btnAgregarRecat").text('Modificar');
    //asignando valores a modificar    
    var columnasEdit = filaEdit.find('td');
    ManTHabilitante.frmTHabilitanteRegistro.find("#ddComoboMotivoRecId").val(filaEdit.find(".hdCOD_MADENDA").val());
    ManTHabilitante.frmTHabilitanteRegistro.find("#txtFechaRecat").val(columnasEdit.eq(3).text().trim());
    ManTHabilitante.frmTHabilitanteRegistro.find("#txtNumRDRect").val(columnasEdit.eq(4).text().trim());
    ManTHabilitante.frmTHabilitanteRegistro.find("#ddModalidadTHId").val(filaEdit.find(".hdCOD_MTIPO").val().trim());
    ManTHabilitante.frmTHabilitanteRegistro.find("#txtObsRecat").val(columnasEdit.eq(6).text().trim());
};
ManTHabilitante.recat.prepararDatosReg = function () {
    ManTHabilitante.ListModalidadesTH = [];//vaciando arreglo
    var countFilas = ManTHabilitante.dtRecategorizar.fnGetData().length;
    if (countFilas > 0) {
        var lstTrs = ManTHabilitante.tbRecategorizar.children("tbody").find("tr");
        $.each(lstTrs, function (i, o) {
            var _columnaREcat = $(o).find('td');
            var _DataRecat = {
                COD_MADENDA: $(o).find('.hdCOD_MADENDA').val(),
                COD_SECUENCIAL: $(o).find('.hdCodSecuencial').val(),
                NUM_RESOLUCION_ADENDA: _columnaREcat.eq(4).text(),
                ADENDA_FECHA_INICIO: _columnaREcat.eq(3).text(),
                OBSERVACION: _columnaREcat.eq(6).text(),
                AREA_OTORGADA: 0,
                COD_MTIPO: $(o).find('.hdCOD_MTIPO').val(),
                RegEstado: $(o).find('.hdEstadoTbRecat').val()
            };
            ManTHabilitante.ListModalidadesTH.push(_DataRecat);
        });
    }
};
ManTHabilitante.recat.iniciarEventosRecategorizacion = function () {
    ManTHabilitante.frmTHabilitanteRegistro.find("#txtFechaRecat").datepicker({ format: "dd/mm/yyyy", autoclose: true, language: 'es' });
    ManTHabilitante.frmTHabilitanteRegistro.find("#ddComoboMotivoRecId").select2({ minimumResultsForSearch: -1 });
    ManTHabilitante.frmTHabilitanteRegistro.find("#ddModalidadTHId").select2({ minimumResultsForSearch: -1 });
    ManTHabilitante.frmTHabilitanteRegistro.find("#ddComoboMotivoRecId").change(function () {
        var idSelect = $(this).val();
        if (idSelect == '0000000') {
            ManTHabilitante.recat.limpiarControles();
        }
        else ManTHabilitante.frmTHabilitanteRegistro.find(".divCambioRect").slideDown();
    });
    ManTHabilitante.frmTHabilitanteRegistro.find("#ddModalidadTHId").change(function () {
        if (ManTHabilitante.frmTHabilitanteRegistro.find("#ddComoboMotivoRecId").val() == "0000007") {

            switch (ManTHabilitante.frmTHabilitanteRegistro.find("#hdfItemModalidadCodigo").val()) {
                case "0000002":
                case "0000003":
                case "0000004":
                case "0000023":

                    if (ManTHabilitante.frmTHabilitanteRegistro.find("#ddModalidadTHId").val() == "0000001") {
                        ManTHabilitante.frmTHabilitanteRegistro.find("#divClaseZoologico").removeAttr('hidden');
                    } else {
                        ManTHabilitante.frmTHabilitanteRegistro.find("#divClaseZoologico").attr('hidden', 'hidden');
                    }

                    //  ManTHabilitante.frmTHabilitanteRegistro.find("#ddClaseZoologicoId").val("0"); 
                    break;
                default:
                    ManTHabilitante.frmTHabilitanteRegistro.find("#divClaseZoologico").attr('hidden', 'hidden');
                    break;
            }
        }
    });

    //configurando tabla
    ManTHabilitante.tbRecategorizar = ManTHabilitante.frmTHabilitanteRegistro.find("#tbRecategorizar");
    ManTHabilitante.dtRecategorizar = ManTHabilitante.tbRecategorizar.dataTable({
        "bServerSide": false,
        "bAutoWidth": false,
        "bProcessing": true,
        "bJQueryUI": false,
        "bRetrieve": true,
        "bFilter": false,
        "aaSorting": [],
        "bPaginate": true,
        "bInfo": false,
        "bLengthChange": false,
        "pageLength": 20,
        "oLanguage": initSigo.oLanguage,
        "drawCallback": initSigo.showPagination
    });
    ManTHabilitante.frmTHabilitanteRegistro.find("#btnAgregarRecat").click(function () {
        ManTHabilitante.recat.agregarRecategorizacion();
    });
    ManTHabilitante.frmTHabilitanteRegistro.find("#btnCancelarRecat").click(function () {
        ManTHabilitante.recat.limpiarControles();
    });
};
//estado de establecimiento
ManTHabilitante.estab = {};
ManTHabilitante.estab.filaEditarEstab = "";
ManTHabilitante.estab.limpiarControles = function () {
    ManTHabilitante.frmTHabilitanteRegistro.find("#hdfIten_RegEstab").val(1);
    ManTHabilitante.frmTHabilitanteRegistro.find("#ddEstablecimientoTH").val('0000000');

    ManTHabilitante.frmTHabilitanteRegistro.find("#txtNumRDEstab").val('');
    ManTHabilitante.frmTHabilitanteRegistro.find("#txtFechaRDEstab").val('');
    ManTHabilitante.frmTHabilitanteRegistro.find("#txtAFFSRDEstab").val('');

    ManTHabilitante.frmTHabilitanteRegistro.find("#txtDocumentoEstab").val('');
    ManTHabilitante.frmTHabilitanteRegistro.find("#txtFechaEstab").val('');
    ManTHabilitante.frmTHabilitanteRegistro.find("#txtAFFSEstab").val('');

    ManTHabilitante.frmTHabilitanteRegistro.find("#txtObsEstab").val('');
    ManTHabilitante.frmTHabilitanteRegistro.find("#btnAgregarEstab").text('Agregar');
    ManTHabilitante.estab.filaEditarEstab = "";
    ManTHabilitante.frmTHabilitanteRegistro.find("#btnCancelarEstab").attr('style', 'display:none');
    ManTHabilitante.frmTHabilitanteRegistro.find(".divCambioEstab").slideUp();
    ManTHabilitante.frmTHabilitanteRegistro.find(".divCambioEstab1").slideUp();
};
ManTHabilitante.estab.agregarEstab = function () {
    var opcionRegistroEstab = ManTHabilitante.frmTHabilitanteRegistro.find("#hdfIten_RegEstab").val();
    var ddEstablecimientoTHId = ManTHabilitante.frmTHabilitanteRegistro.find("#ddEstablecimientoTHId").val();
    var ddEstablecimientoTH = ManTHabilitante.frmTHabilitanteRegistro.find("#ddEstablecimientoTHId option:selected").text();

    var txtNumRDEstab = ManTHabilitante.frmTHabilitanteRegistro.find("#txtNumRDEstab").val().trim();
    var txtFechaRDEstab = ManTHabilitante.frmTHabilitanteRegistro.find("#txtFechaRDEstab").val().trim();
    var txtAFFSRDEstab = ManTHabilitante.frmTHabilitanteRegistro.find("#txtAFFSRDEstab").val().trim();

    var txtDocumentoEstab = ManTHabilitante.frmTHabilitanteRegistro.find("#txtDocumentoEstab").val().trim();
    var txtFechaEstab = ManTHabilitante.frmTHabilitanteRegistro.find("#txtFechaEstab").val().trim();
    var txtAFFSEstab = ManTHabilitante.frmTHabilitanteRegistro.find("#txtAFFSEstab").val().trim();

    var txtObsEstab = ManTHabilitante.frmTHabilitanteRegistro.find("#txtObsEstab").val().trim();

    if (ddEstablecimientoTHId == "0000000") {
        utilSigo.toastWarning("", "Seleccione un Estado de Establecimiento");
        return false;
    }
    var observacionRec = ManTHabilitante.frmTHabilitanteRegistro.find("#txtObsRecat").val().trim();

    if (parseInt(opcionRegistroEstab) == 1) { //agregar registro tabla 
        ManTHabilitante.dtEstablecimiento.fnAddData(
            ['<input type="hidden" class="hdCodSecuencial" value="-1" /><input type="hidden" class="hdEstadoTbEstab" value="1" /><input type="hidden" class="hdddEstablecimientoTHId" value="' + ddEstablecimientoTHId +
                '" /><i class="fa fa-lg fa-pencil-square-o" style="cursor:pointer;" onclick="ManTHabilitante.estab.cargarEditEstab(this);"></i>'
                , ''
                , ddEstablecimientoTH
                , txtNumRDEstab
                , txtFechaRDEstab
                , txtAFFSRDEstab
                , txtDocumentoEstab
                , txtFechaEstab
                , txtAFFSEstab
                , txtObsEstab]);
        ManTHabilitante.estab.limpiarControles();
        var tRecNum = $('#tbEstablecimiento').DataTable();
        tRecNum.on('order.dt', function () {
            tRecNum.column(1, {}).nodes().each(function (cell, i) {
                cell.innerHTML = i + 1;
            });
        }).draw();
    }
    else {//modificar registro tabla y verificar data origen bd
        if (ManTHabilitante.estab.filaEditarEstab != "") {
            var estadoRegisItemSelec = ManTHabilitante.estab.filaEditarEstab.find(".hdEstadoTbEstab").val();
            if (parseInt(estadoRegisItemSelec) == 0) estadoRegisItemSelec = 2;
            //modificando

            ManTHabilitante.estab.filaEditarEstab.find(".hdEstadoTbEstab").val(estadoRegisItemSelec);
            ManTHabilitante.estab.filaEditarEstab.find(".ddEstablecimientoTHId").val(ddEstablecimientoTHId);
            var columnasFila = ManTHabilitante.estab.filaEditarEstab.find('td');
            columnasFila.eq(2).html(ddEstablecimientoTH);
            columnasFila.eq(3).html(txtNumRDEstab);
            columnasFila.eq(4).html(txtFechaRDEstab);
            columnasFila.eq(5).html(txtAFFSRDEstab);
            columnasFila.eq(6).html(txtDocumentoEstab);
            columnasFila.eq(7).html(txtFechaEstab);
            columnasFila.eq(8).html(txtAFFSEstab);
            columnasFila.eq(9).html(txtObsEstab);
            ManTHabilitante.estab.limpiarControles(); //limpiando 
        }
    }
};
ManTHabilitante.estab.cargarEditEstab = function (obj) {
    ManTHabilitante.frmTHabilitanteRegistro.find(".divCambioEstab").slideDown();
    ManTHabilitante.estab.filaEditarEstab = $(obj).closest('tr');
    var filaEdit = ManTHabilitante.estab.filaEditarEstab;
    ManTHabilitante.frmTHabilitanteRegistro.find("#hdfIten_RegEstab").val(0);
    ManTHabilitante.frmTHabilitanteRegistro.find("#btnCancelarEstab").removeAttr('style');
    ManTHabilitante.frmTHabilitanteRegistro.find("#btnAgregarEstab").text('Modificar');
    //asignando valores a modificar    
    var columnasEdit = filaEdit.find('td');
    let hdddEstablecimientoTHId = filaEdit.find(".hdddEstablecimientoTHId").val();
    //console.log(hdddEstablecimientoTHId);
    ManTHabilitante.frmTHabilitanteRegistro.find("#ddEstablecimientoTHId").val(hdddEstablecimientoTHId).trigger('change');
    ManTHabilitante.frmTHabilitanteRegistro.find("#txtNumRDEstab").val(columnasEdit.eq(3).text().trim());
    ManTHabilitante.frmTHabilitanteRegistro.find("#txtFechaRDEstab").val(columnasEdit.eq(4).text().trim());
    ManTHabilitante.frmTHabilitanteRegistro.find("#txtAFFSRDEstab").val(columnasEdit.eq(5).text().trim());
    ManTHabilitante.frmTHabilitanteRegistro.find("#txtDocumentoEstab").val(columnasEdit.eq(6).text().trim());
    ManTHabilitante.frmTHabilitanteRegistro.find("#txtFechaEstab").val(columnasEdit.eq(7).text().trim());
    ManTHabilitante.frmTHabilitanteRegistro.find("#txtAFFSEstab").val(columnasEdit.eq(8).text().trim());
    ManTHabilitante.frmTHabilitanteRegistro.find("#txtObsEstab").val(columnasEdit.eq(9).text().trim());

    if (hdddEstablecimientoTHId == '0000000') {
        ManTHabilitante.estab.limpiarControles();
    }
    else {
        if (hdddEstablecimientoTHId == '0000013' || hdddEstablecimientoTHId == '0000011') {
            ManTHabilitante.frmTHabilitanteRegistro.find(".divCambioEstab").slideDown();
            ManTHabilitante.frmTHabilitanteRegistro.find(".divCambioEstab1").slideUp();
        } else {
            ManTHabilitante.frmTHabilitanteRegistro.find(".divCambioEstab").slideDown();
            ManTHabilitante.frmTHabilitanteRegistro.find(".divCambioEstab1").slideDown();
        }

    }
};
ManTHabilitante.estab.prepararDatosReg = function () {

    var countFilas = ManTHabilitante.dtEstablecimiento.fnGetData().length;
    if (countFilas > 0) {
        var lstTrs = ManTHabilitante.tbEstablecimiento.children("tbody").find("tr");
        $.each(lstTrs, function (i, o) {
            var _columnaEstab = $(o).find('td');
            var _DataEstab = {
                COD_MOTIVO_EV: $(o).find('.hdddEstablecimientoTHId').val(),
                COD_THABILITANTE_EVALUACION_FAUNA: $(o).find('.hdCodTHEvaFauna').val(),
                NUMERO: _columnaEstab.eq(3).text(),
                FECHA_AFFS: _columnaEstab.eq(4).text(),
                NOMBRE_FIRMA_RES: _columnaEstab.eq(5).text(),
                N_DOCUMENTO: _columnaEstab.eq(6).text(),
                FECHA_DOC: _columnaEstab.eq(7).text(),
                NOMBRE_AFFS: _columnaEstab.eq(8).text(),
                OBSERVACION: _columnaEstab.eq(9).text(),
                RegEstado: $(o).find('.hdEstadoTbEstab').val()
            };
            ManTHabilitante.ListTHEstadoEsta.push(_DataEstab);
        });
    }
};
ManTHabilitante.estab.iniciarEventosEstablecimiento = function () {
    ManTHabilitante.frmTHabilitanteRegistro.find("#txtFechaRDEstab").datepicker({ format: "dd/mm/yyyy", autoclose: true, language: 'es' });
    ManTHabilitante.frmTHabilitanteRegistro.find("#txtFechaEstab").datepicker({ format: "dd/mm/yyyy", autoclose: true, language: 'es' });
    ManTHabilitante.frmTHabilitanteRegistro.find("#ddEstablecimientoTHId").select2({ minimumResultsForSearch: -1 });
    ManTHabilitante.frmTHabilitanteRegistro.find("#ddEstablecimientoTHId").change(function () {
        var idSelect = $(this).val();
        if (idSelect == '0000000') {
            ManTHabilitante.estab.limpiarControles();
        }
        else {
            if (idSelect == '0000013' || idSelect == '0000011') {
                ManTHabilitante.frmTHabilitanteRegistro.find(".divCambioEstab").slideDown();
                ManTHabilitante.frmTHabilitanteRegistro.find(".divCambioEstab1").slideUp();
            } else {
                ManTHabilitante.frmTHabilitanteRegistro.find(".divCambioEstab").slideDown();
                ManTHabilitante.frmTHabilitanteRegistro.find(".divCambioEstab1").slideDown();
            }

        }

    });
    //configurando tabla
    ManTHabilitante.tbEstablecimiento = ManTHabilitante.frmTHabilitanteRegistro.find("#tbEstablecimiento");
    ManTHabilitante.dtEstablecimiento = ManTHabilitante.tbEstablecimiento.dataTable({
        "bServerSide": false,
        "bAutoWidth": false,
        "bProcessing": true,
        "bJQueryUI": false,
        "bRetrieve": true,
        "bFilter": false,
        "aaSorting": [],
        "bPaginate": true,
        "bInfo": false,
        "bLengthChange": false,
        "pageLength": 20,
        "oLanguage": initSigo.oLanguage,
        "drawCallback": initSigo.showPagination
    });
    ManTHabilitante.frmTHabilitanteRegistro.find("#btnAgregarEstab").click(function () {
        ManTHabilitante.estab.agregarEstab();
    });
    ManTHabilitante.frmTHabilitanteRegistro.find("#btnCancelarEstab").click(function () {
        ManTHabilitante.estab.limpiarControles();
    });


}




//adenda
ManTHabilitante.adend = {};
ManTHabilitante.adend.indexAdenda = 0;
ManTHabilitante.adend.indexAdendaArea = 0;
ManTHabilitante.adend.filaEditarAdendTemp = "";
ManTHabilitante.adend.filaEditarVerticeMod = "";
ManTHabilitante.adend.eliminarAdenda = function (obj) {
    var $trEliminar = $(obj).closest('tr');
    var valCodMAdenda = $trEliminar.find(".hdCOD_MADENDA").val();
    if (valCodMAdenda === '0000000') {
        utilSigo.toastWarning("Aviso", "No puede eliminar estos datos desde la sección de Adendas, son datos históricos");
        return false;
    }
    utilSigo.dialogConfirm("Confirmacion", "¿ Está seguro de Eliminar el Registro Seleccionado ?", function (r) {
        if (r) {
            var valCodSecuencial = $trEliminar.find(".hdCodSecuencial").val();
            var estadoRegisItemSelec = $trEliminar.find(".hdEstadoItemAden").val();
            if (parseInt(estadoRegisItemSelec) == 0 || parseInt(estadoRegisItemSelec) == 2) {//guardando filas que vinieron de la bd en un temporal
                var columnasFila = $trEliminar.find('td');
                ManTHabilitante.ListEliTABLA.push({
                    EliTABLA: "THABILITANTE_DGENERAL_ADENDA",
                    EliVALOR01: valCodMAdenda,
                    EliVALOR02: valCodSecuencial
                });
            }
            //eliminando adenda
            var valIndexAdenda = $trEliminar.find(".hdIndexAdenda").val();
            ManTHabilitante.ListAdendas.splice(valIndexAdenda, 1);
            ManTHabilitante.adend.crearItemsTablaAdenda();
            ManTHabilitante.frmTHabilitanteRegistro.find("#btnAdendaCancelar").click();

        }
    });
};
ManTHabilitante.adend.eliminarVerticeAdenMod = function (obj) {
    utilSigo.dialogConfirm("Confirmacion", "¿ Está seguro de Eliminar el Registro Seleccionado ?", function (r) {
        if (r) {
            var $trEliminar = $(obj).closest('tr');
            var estadoRegisItemSelec = $trEliminar.find(".hdEstadoItem").val();
            if (parseInt(estadoRegisItemSelec) == 0 || parseInt(estadoRegisItemSelec) == 2) {//guardando filas que vinieron de la bd en un temporal
                var columnasFila = $trEliminar.find('td');
                ManTHabilitante.ListEliTABLATem.push({
                    EliTABLA: "THABILITANTE_DGENERAL_DET_VERTICE",
                    EliVALOR01: columnasFila.eq(3).text().trim(),
                    EliVALOR02: $trEliminar.find(".hdfItemCodSecuencial").val(),
                    EliVALOR03: "",//$trEliminar.find(".hdCOD_MADENDA").val(),
                    EliVALOR04: $trEliminar.find(".hdfItemCodSecuencialAdenda").val()
                });
            }
            //eliminando
            ManTHabilitante.adend.dtItemVerticeMod.row($trEliminar).remove().draw(false);
            ManTHabilitante.adend.numerarTbItemVertice();
        }
    });
};
ManTHabilitante.adend.eliminarVerticeAdenModAll = function () {
    var tbItemVerticeMod = $('#tbItemVerticeMod').dataTable();
    var rows = tbItemVerticeMod.$("tr");
    if (rows.length > 0) {
        utilSigo.dialogConfirm("", "Está seguro de Eliminar Todo los Registros?", function (r) {
            if (r) {
                $.each(rows, function (i, o) {
                    var estadoItemBD = $(o).find(".hdEstadoItem").val();
                    if (parseInt(estadoItemBD) == 0 || parseInt(estadoItemBD) == 2) {
                        var $columna = $(o).find('td');
                        ManTHabilitante.ListEliTABLATem.push({
                            EliTABLA: "THABILITANTE_DGENERAL_DET_VERTICE",
                            EliVALOR01: $columna.eq(3).text().trim(),
                            EliVALOR02: $(o).find(".hdfItemCodSecuencial").val(),
                            EliVALOR03: "",
                            EliVALOR04: $(o).find(".hdfItemCodSecuencialAdenda").val()
                        });
                    }
                });
                ManTHabilitante.adend.dtItemVerticeMod.clear().draw();
            }
        });
    }
    else {
        utilSigo.toastWarning("Aviso", "No hay Registros a Eliminar");
    }
};
ManTHabilitante.adend.numerarTbItemVertice = function () {
    var tverticeAdenNum = $('#tbItemVerticeMod').DataTable();
    tverticeAdenNum.on('order.dt', function () {
        tverticeAdenNum.column(2, {}).nodes().each(function (cell, i) {
            cell.innerHTML = i + 1;
        });
    }).draw();
};
ManTHabilitante.adend.editVerticeMod = function (obj) {
    ManTHabilitante.DGeneral.frmVertice.find("#btnRegistrarVertice").text('Modificar');
    ManTHabilitante.adend.filaEditarVerticeMod = $(obj).closest('tr');
    var filaEdit = ManTHabilitante.adend.filaEditarVerticeMod;
    //asignando valor a modificar
    var columnasEdit = filaEdit.find('td');
    ManTHabilitante.DGeneral.frmVertice.find("#txtItemVert_Vertice").val(columnasEdit.eq(3).text().trim());
    ManTHabilitante.DGeneral.frmVertice.find("#ddlItemZona_UTM").val(filaEdit.find(".hdDdlItemZona_UTM").val()).select2();
    ManTHabilitante.DGeneral.frmVertice.find("#txtItemVert_CEste").val(columnasEdit.eq(5).text().trim());
    ManTHabilitante.DGeneral.frmVertice.find("#txtItemVert_CNorte").val(columnasEdit.eq(6).text().trim());
    ManTHabilitante.DGeneral.frmVertice.find("#txtItemVert_Observacion").val(columnasEdit.eq(7).text().trim());
    ManTHabilitante.DGeneral.frmVertice.find("#hdfItemVert_RegEstado").val(0);
    ManTHabilitante.DGeneral.frmVertice.find("#hdOrigen").val('tbVerticeMod');
    // mostrando modal|
    utilSigo.modalDraggable($("#PDivItemVertice"), '.modal-header');
    $("#PDivItemVertice").modal({ keyboard: true, backdrop: 'static' });
};

ManTHabilitante.adend.agregarVerticeMod = function () {
    var valItemVert_Vertice = ManTHabilitante.DGeneral.frmVertice.find("#txtItemVert_Vertice").val().trim();
    var valItemZona_UTM = ManTHabilitante.DGeneral.frmVertice.find("#ddlItemZona_UTM").val();
    var textItemZona_UTM = ManTHabilitante.DGeneral.frmVertice.find("#ddlItemZona_UTM option:selected").text();
    var valItemVert_CEste = ManTHabilitante.DGeneral.frmVertice.find("#txtItemVert_CEste").val().trim();
    var valItemVert_CNorte = ManTHabilitante.DGeneral.frmVertice.find("#txtItemVert_CNorte").val().trim();
    var valItemVert_Observacion = ManTHabilitante.DGeneral.frmVertice.find("#txtItemVert_Observacion").val().trim().toUpperCase();
    var valEstadoOpcion = ManTHabilitante.DGeneral.frmVertice.find("#hdfItemVert_RegEstado").val();

    if (parseInt(valEstadoOpcion) == 1) { //agregar registro tabla      
        ManTHabilitante.adend.dtItemVerticeMod.row.add(
            ['<input type="hidden" class="hdIndexAdenda" value="0" /><input type="hidden" class="hdfItemCodSecuencialAdenda" value="0" /><input type="hidden" class="hdfItemCodSecuencial" value="0" /><input type="hidden" class="hdEstadoItem" value="1" /><input type="hidden" class="hdDdlItemZona_UTM" value="' + valItemZona_UTM + '" /><i class="fa mx-2 fa-lg fa-pencil-square-o" style="cursor:pointer;" title="Editar" onclick="ManTHabilitante.adend.editVerticeMod(this);"></i>'
                , '<input type="hidden" class="hdCOD_MADENDA" value="0" /><i class="fa fa-lg fa-window-close" style="color:red;cursor:pointer;" title="Eliminar" onclick="ManTHabilitante.adend.eliminarVerticeAdenMod(this);"></i>'
                , ''
                , valItemVert_Vertice
                , textItemZona_UTM
                , valItemVert_CEste
                , valItemVert_CNorte
                , valItemVert_Observacion]).draw();
        ManTHabilitante.adend.indexAdendaArea++;//conforme se agregan registros nuevos, incrementamos la variable identificador
        ManTHabilitante.adend.numerarTbItemVertice();
        ManTHabilitante.adend.dtItemVerticeMod.page('last').draw('page');
    }
    else {//modificar registro tabla y verificar data origen bd
        if (ManTHabilitante.adend.filaEditarVerticeMod != "") {
            var estadoRegisItemSelec = ManTHabilitante.adend.filaEditarVerticeMod.find(".hdEstadoItem").val();
            if (parseInt(estadoRegisItemSelec) == 0) estadoRegisItemSelec = 2;
            //modificando
            ManTHabilitante.adend.filaEditarVerticeMod.find(".hdEstadoItem").val(estadoRegisItemSelec);
            ManTHabilitante.adend.filaEditarVerticeMod.find(".hdDdlItemZona_UTM").val(valItemZona_UTM);
            var columnasFila = ManTHabilitante.adend.filaEditarVerticeMod.find('td');
            columnasFila.eq(3).html(valItemVert_Vertice);
            columnasFila.eq(4).html(textItemZona_UTM);
            columnasFila.eq(5).html(valItemVert_CEste);
            columnasFila.eq(6).html(valItemVert_CNorte);
            columnasFila.eq(7).html(valItemVert_Observacion);
            ManTHabilitante.DGeneral.limpiarControles();
            ManTHabilitante.adend.filaEditarVerticeMod = ""; //limpiando fila temporal
            $('#PDivItemVertice').modal('hide');
        }
        else {
            utilSigo.toastWarning("Aviso", "No hay datos a modificar");
        }
    }
};
ManTHabilitante.adend.crearItemsTablaAdendaVertice = function (indexPadre) {
    ManTHabilitante.adend.dtItemVerticeMod.clear().draw();
    var listAreaVer = ManTHabilitante.ListAdendas[indexPadre].ListTDDVADEAREA;
    var trsAdd = [];
    for (var i = 0; i < listAreaVer.length; i++) {
        var tr = ['<input type="hidden" class="hdIndexAdenda" value="' + indexPadre + '" /><input type="hidden" class="hdfItemCodSecuencialAdenda" value="' + listAreaVer[i].COD_SECUENCIAL_ADENDA + '" /><input type="hidden" class="hdfItemCodSecuencial" value="' + listAreaVer[i].COD_SECUENCIAL + '" /><input type="hidden" class="hdEstadoItem" value="' + listAreaVer[i].RegEstado + '" /><input type="hidden" class="hdDdlItemZona_UTM" value="' + listAreaVer[i].ZONA + '" /><i class="fa mx-2 fa-lg fa-pencil-square-o" style="cursor:pointer;" title="Editar" onclick="ManTHabilitante.adend.editVerticeMod(this);"></i>'
            , '<i class="fa fa-lg fa-window-close" style="color:red;cursor:pointer;" title="Eliminar" onclick="ManTHabilitante.adend.eliminarVerticeAdenMod(this);"></i>'
            , (i + 1)
            , listAreaVer[i].VERTICE
            , listAreaVer[i].ZONA
            , listAreaVer[i].COORDENADA_ESTE
            , listAreaVer[i].COORDENADA_NORTE
            , listAreaVer[i].OBSERVACION];
        trsAdd.push(tr);
    }
    ManTHabilitante.adend.dtItemVerticeMod.rows.add(trsAdd).draw();
};
ManTHabilitante.adend.agregarAdendVerticeExcel = function (data) {
    var trsAdd = [];
    for (var i = 0; i < data.length; i++) {
        var tr = ['<input type="hidden" class="hdIndexAdenda" value="0" /><input type="hidden" class="hdfItemCodSecuencialAdenda" value="' + data[i].COD_SECUENCIAL_ADENDA + '" /><input type="hidden" class="hdfItemCodSecuencial" value="0" /><input type="hidden" class="hdEstadoItem" value="1" /><input type="hidden" class="hdDdlItemZona_UTM" value="' + data[i].ZONA.trim() + '" /><i class="fa mx-2 fa-lg fa-pencil-square-o" style="cursor:pointer;" title="Editar" onclick="ManTHabilitante.adend.editVerticeMod(this);"></i>'
            , '<input type="hidden" class="hdCOD_MADENDA" value="0" /><i class="fa fa-lg fa-window-close" style="color:red;cursor:pointer;" title="Eliminar" onclick="ManTHabilitante.adend.eliminarVerticeAdenMod(this);"></i>'
            , ''
            , data[i].VERTICE.trim()
            , data[i].ZONA.trim()
            , data[i].COORDENADA_ESTE
            , data[i].COORDENADA_NORTE
            , data[i].OBSERVACION];
        trsAdd.push(tr);

    }
    ManTHabilitante.adend.dtItemVerticeMod.rows.add(trsAdd).draw();
    ManTHabilitante.adend.numerarTbItemVertice();
    ManTHabilitante.adend.dtItemVerticeMod.page('last').draw('page');
};
ManTHabilitante.adend.enumItemTablaAdenda = function () {
    var tAdenNum = $('#tbItemAdendas').DataTable();
    tAdenNum.on('order.dt', function () {
        tAdenNum.column(2, {}).nodes().each(function (cell, i) {
            cell.innerHTML = i + 1;
        });
    }).draw();
};
ManTHabilitante.adend.crearItemsTablaAdenda = function () {
    ManTHabilitante.adend.dtItemAdendas.fnClearTable();
    var listaAdenda = ManTHabilitante.ListAdendas;
    for (var i = 0; i < listaAdenda.length; i++) {
        ManTHabilitante.adend.dtItemAdendas.fnAddData(
            ['<input type="hidden" class="hdIndexAdenda" value="' + i + '" /><input type="hidden" class="hdCodSecuencial" value="' + listaAdenda[i].COD_SECUENCIAL + '" /><input type="hidden" class="hdEstadoItemAden" value="' + listaAdenda[i].RegEstado + '" /><input type="hidden" class="hdCOD_MADENDA" value="' + listaAdenda[i].COD_MADENDA + '" /><i class="fa mx-2 fa-lg fa-pencil-square-o" style="cursor:pointer;" title="Editar" onclick="ManTHabilitante.adend.editAdenda(this);"></i>'
                , '<input type="hidden" class="hdCODFUNCIONARIO" value="' + listaAdenda[i].COD_FUNCIONARIO_ADENDA + '" /><input type="hidden" class="hdCODTITULAR" value="' + listaAdenda[i].COD_TITULAR_ADENDA + '" /><input type="hidden" class="hdADENDAFECHATERMINO" value="' + listaAdenda[i].ADENDA_FECHA_TERMINO + '" /><i class="fa fa-lg fa-window-close" style="color:red;cursor:pointer;" title="Eliminar" onclick="ManTHabilitante.adend.eliminarAdenda(this);"></i>' +
                '<input type="hidden" class="hdTIPOPERSONA" value="' + listaAdenda[i].TIPO_PERSONA + '" /><input type="hidden" class="hdNDOCUMENTO" value="' + listaAdenda[i].N_DOCUMENTO + '" /><input type="hidden" class="hdNRUC" value="' + listaAdenda[i].N_RUC + '" />'
                , (i + 1)
                , listaAdenda[i].MOTIVO
                , listaAdenda[i].ADENDA_FECHA_INICIO
                , listaAdenda[i].TITULAR_ADENDA
                , listaAdenda[i].NUM_THABILITANTE_ADENDA
                , listaAdenda[i].NUM_RESOLUCION_ADENDA
                , listaAdenda[i].FUNCIONARIO
                , listaAdenda[i].CANT_VERTICES
                , listaAdenda[i].AREA_OTORGADA
                , listaAdenda[i].OBSERVACION
            ]);
    }
};
ManTHabilitante.adend.agregarAdend = function () {
    var opcionRegistroRec = ManTHabilitante.frmTHabilitanteRegistro.find("#hdEstadoRegAden").val();
    var valCodMAdenda = ManTHabilitante.frmTHabilitanteRegistro.find("#ddlItemAdeMotivoId").val();
    var valMotivoAdenda = ManTHabilitante.frmTHabilitanteRegistro.find("#ddlItemAdeMotivoId option:selected").text();
    var valFechaIniAden = ManTHabilitante.frmTHabilitanteRegistro.find("#txtItemAdeFInicio").val();
    var valFechaTermAden = ManTHabilitante.frmTHabilitanteRegistro.find("#txtItemAdeFecTer").val();
    var valNumTHabilitanteAden = ManTHabilitante.frmTHabilitanteRegistro.find("#txtItemAdeNumTH").val().trim();
    var valNroResolucion = ManTHabilitante.frmTHabilitanteRegistro.find("#txtItemAdeNumResol").val().trim();
    var valCodTitularAdend = ManTHabilitante.frmTHabilitanteRegistro.find("#hdfItemCamTitularCodigo").val();
    var valTitularAdenda = ManTHabilitante.frmTHabilitanteRegistro.find("#fItemCamTitularCodigo").val();
    var valObservacionAden = ManTHabilitante.frmTHabilitanteRegistro.find("#txtItemAdeObservacion").val().trim();
    var valAreaAd = ManTHabilitante.frmTHabilitanteRegistro.find("#txtArea").val().trim();

    if (valAreaAd.trim() == "") valAreaAd = 0;

    if (valCodMAdenda == "0000000") {
        utilSigo.toastWarning("", "Seleccione una Nueva Modalidad diferente a Ninguno");
        return false;
    }
    if (ManTHabilitante.frmTHabilitanteRegistro.find("#txtItemAdeFInicio").val() == null || ManTHabilitante.frmTHabilitanteRegistro.find("#txtItemAdeFInicio").val() == "") {
        utilSigo.toastWarning("", "Ingrese Fecha Inicio");
        return false;
    }

    if (valCodMAdenda == "0000006") {
        var fecha1, fecha2;
        var fechaInicio, fechaFin;

        if (valFechaTermAden != null && valFechaTermAden.trim() != "") {
            fecha1 = valFechaIniAden.split("/");
            fechaInicio = new Date(fecha1[2], fecha1[1], fecha1[0]);

            fecha2 = valFechaTermAden.split("/");
            fechaFin = new Date(fecha2[2], fecha2[1], fecha2[0]);

            if (fechaFin < fechaInicio) {
                utilSigo.toastWarning("Aviso", "Fecha Fin tiene que ser mayor que la fecha de inicio.");
                ManTHabilitante.frmTHabilitanteRegistro.find("#txtItemAdeFecTer").focus();
                return false;
            }
        }
        else {
            fecha1 = valFechaIniAden.split("/");
            fechaInicio = new Date(fecha1[2], fecha1[1], fecha1[0]);

            fecha2 = $("#txtItemContFFin").val().split("/");
            fechaFin = new Date(fecha2[2], fecha2[1], fecha2[0]);

            if (fechaFin < fechaInicio) {
                utilSigo.toastWarning("Aviso", "Fecha de inicio no puede ser mayor que fecha fin.");
                ManTHabilitante.frmTHabilitanteRegistro.find("#txtItemAdeFInicio").focus();
                return false;
            }
        }
    }
    //confirmando el registro de los vertices eliminados
    for (var i = 0; i < ManTHabilitante.ListEliTABLATem.length; i++) {
        ManTHabilitante.ListEliTABLA.push({
            EliTABLA: ManTHabilitante.ListEliTABLATem[i].EliTABLA,
            EliVALOR01: ManTHabilitante.ListEliTABLATem[i].EliVALOR01,
            EliVALOR02: ManTHabilitante.ListEliTABLATem[i].EliVALOR02,
            EliVALOR03: ManTHabilitante.ListEliTABLATem[i].EliVALOR03,
            EliVALOR04: ManTHabilitante.ListEliTABLATem[i].EliVALOR04
        });
    }
    ManTHabilitante.ListEliTABLATem = [];
    //verificando si motivo adenda es '0000003' o '0000001'
    var listaVerticeMod = [];
    if (valCodMAdenda == '0000003' || valCodMAdenda == '0000001') {
        var $tbItemVerticeMod = $('#tbItemVerticeMod').dataTable();
        var $rows = $tbItemVerticeMod.$("tr");
        var countFilas = $rows.length;
        if (countFilas > 0) {
            $.each($rows, function (i, o) {
                var estadoItemReg = $(o).find(".hdEstadoItem").val();
                var codSecuencialAdenda = $(o).find(".hdfItemCodSecuencialAdenda").val();
                var codSecuencial = $(o).find(".hdfItemCodSecuencial").val();
                var columnasFila = $(o).find('td');
                listaVerticeMod.push({
                    VERTICE: columnasFila.eq(3).text(),
                    ZONA: columnasFila.eq(4).text(),
                    COORDENADA_ESTE: columnasFila.eq(5).text(),
                    COORDENADA_NORTE: columnasFila.eq(6).text(),
                    OBSERVACION: columnasFila.eq(7).text(),
                    COD_SECUENCIAL_ADENDA: codSecuencialAdenda,
                    COD_SECUENCIAL: codSecuencial,
                    RegEstado: estadoItemReg
                });
            });
        }
    }
    if (parseInt(opcionRegistroRec) == 1) {//agregar registro nuevo a la tabla 
        ManTHabilitante.ListAdendas.push({
            COD_SECUENCIAL: 0,
            RegEstado: 1,
            COD_MADENDA: valCodMAdenda,
            COD_FUNCIONARIO_ADENDA: "",
            COD_TITULAR_ADENDA: valCodTitularAdend,
            ADENDA_FECHA_TERMINO: valFechaTermAden,
            TIPO_PERSONA: "",
            N_DOCUMENTO: "",
            N_RUC: "",
            MOTIVO: valMotivoAdenda,
            ADENDA_FECHA_INICIO: valFechaIniAden,
            TITULAR_ADENDA: valTitularAdenda,
            NUM_THABILITANTE_ADENDA: valNumTHabilitanteAden,
            NUM_RESOLUCION_ADENDA: valNroResolucion,
            FUNCIONARIO: '',
            CANT_VERTICES: listaVerticeMod.length,
            AREA_OTORGADA: valAreaAd,
            OBSERVACION: valObservacionAden,
            //indexAdenda: ManTHabilitante.adend.indexAdenda,
            ListTDDVADEAREA: listaVerticeMod
        });
        ManTHabilitante.adend.indexAdenda++;
        ManTHabilitante.adend.crearItemsTablaAdenda();
    }
    else {//modificar
        if (ManTHabilitante.adend.filaEditarAdendTemp != "") {
            var estadoRegisItemSelec = ManTHabilitante.adend.filaEditarAdendTemp.find(".hdEstadoItemAden").val();
            if (parseInt(estadoRegisItemSelec) == 0) estadoRegisItemSelec = 2;
            var indexAdenda = ManTHabilitante.adend.filaEditarAdendTemp.find(".hdIndexAdenda").val();
            var listaAdenda = ManTHabilitante.ListAdendas;
            for (var i = 0; i < listaAdenda.length; i++) {
                if (parseInt(i) == parseInt(indexAdenda)) { //modificamos                  
                    listaAdenda[i].RegEstado = estadoRegisItemSelec;
                    listaAdenda[i].COD_MADENDA = valCodMAdenda;
                    listaAdenda[i].COD_TITULAR_ADENDA = valCodTitularAdend;
                    listaAdenda[i].ADENDA_FECHA_TERMINO = valFechaTermAden;
                    listaAdenda[i].MOTIVO = valMotivoAdenda;
                    listaAdenda[i].ADENDA_FECHA_INICIO = valFechaIniAden;
                    listaAdenda[i].TITULAR_ADENDA = valTitularAdenda;
                    listaAdenda[i].NUM_THABILITANTE_ADENDA = valNumTHabilitanteAden;
                    listaAdenda[i].NUM_RESOLUCION_ADENDA = valNroResolucion;
                    listaAdenda[i].CANT_VERTICES = listaVerticeMod.length;
                    listaAdenda[i].AREA_OTORGADA = valAreaAd;
                    listaAdenda[i].OBSERVACION = valObservacionAden
                    listaAdenda[i].ListTDDVADEAREA = listaVerticeMod;

                }
            }
            ManTHabilitante.adend.crearItemsTablaAdenda();
        }
    }
    ManTHabilitante.frmTHabilitanteRegistro.find("#ddlItemAdeMotivoId").val('0000000').select2();
    ManTHabilitante.adend.limpiarControlAll();
    ManTHabilitante.adend.ocultarControlAll();
};
ManTHabilitante.adend.editAdenda = function (obj) {
    var filaEditAden = $(obj).closest('tr');
    ManTHabilitante.adend.filaEditarAdendTemp = filaEditAden;
    var valCodMAdenda = filaEditAden.find(".hdCOD_MADENDA").val().trim();
    var columnaTB = filaEditAden.find('td');
    if (valCodMAdenda == "0000000") {
        utilSigo.toastWarning("Aviso", "No puede modificar estos datos desde la sección de Adendas, son datos históricos");
        return false;
    }
    //mostrando y ocultando 
    ManTHabilitante.adend.configurarControles(valCodMAdenda);

    ManTHabilitante.frmTHabilitanteRegistro.find("#hdEstadoRegAden").val(0);
    ManTHabilitante.frmTHabilitanteRegistro.find("#ddlItemAdeMotivoId").val(valCodMAdenda).select2();
    ManTHabilitante.frmTHabilitanteRegistro.find("#ddlItemAdeMotivoId").attr('disabled', 'disabled');
    ManTHabilitante.frmTHabilitanteRegistro.find("#btnAdendaCancelar").removeAttr('style');
    ManTHabilitante.frmTHabilitanteRegistro.find("#btnAdendaAgregar").text('Modificar');
    ManTHabilitante.frmTHabilitanteRegistro.find("#txtItemAdeObservacion").val(columnaTB.eq(11).text().trim());
    ManTHabilitante.frmTHabilitanteRegistro.find("#txtItemAdeFInicio").val(columnaTB.eq(4).text().trim());
    ManTHabilitante.frmTHabilitanteRegistro.find("#txtArea").val(columnaTB.eq(10).text().trim());
    ManTHabilitante.frmTHabilitanteRegistro.find("#txtEstadoAdenda").val('Edición de Adenda');
    switch (valCodMAdenda) {
        case "0000001":
        case "0000003":
            ManTHabilitante.adend.crearItemsTablaAdendaVertice(filaEditAden.find(".hdIndexAdenda").val());
            break;
        case "0000002":
        case "0000004":
        case "0000008":
        case "0000009":
            var valCodTitularAdenda = filaEditAden.find(".hdCODTITULAR").val();
            var valTipoTitular = filaEditAden.find(".hdTIPOPERSONA").val();
            var valNroDoc = filaEditAden.find(".hdNDOCUMENTO").val();
            var valNroRuc = filaEditAden.find(".hdNRUC").val();
            var valTitularAde = columnaTB.eq(5).text().trim();
            ManTHabilitante.frmTHabilitanteRegistro.find("#hdfItemCamTitularCodigo").val(valCodTitularAdenda);
            var descripcionTitular = "";
            if (valTipoTitular == 'N') {
                descripcionTitular = '(Natural) ' + valTitularAde + ' (' + valNroDoc + ' - ' + valNroRuc + ')';
                ManTHabilitante.frmTHabilitanteRegistro.find("#fItemCamTitularCodigo").val(descripcionTitular);
            }
            if (valTipoTitular == 'J') {
                descripcionTitular = '(Juridico) ' + valTitularAde + ' (' + valNroRuc + ')';
                ManTHabilitante.frmTHabilitanteRegistro.find("#fItemCamTitularCodigo").val(descripcionTitular);
            }
            break;
        case "0000005":
            ManTHabilitante.frmTHabilitanteRegistro.find("#txtItemAdeNumTH").val(columnaTB.eq(6).text().trim());
            ManTHabilitante.frmTHabilitanteRegistro.find("#txtItemAdeNumResol").val(columnaTB.eq(7).text().trim());
            break;
        case "0000006":
            ManTHabilitante.frmTHabilitanteRegistro.find("#txtItemAdeFecTer").val(filaEditAden.find('.hdADENDAFECHATERMINO').val());
            break;
    }
};
ManTHabilitante.adend.configurarControles = function (id) {
    ManTHabilitante.adend.limpiarControlAll();
    ManTHabilitante.adend.ocultarControlAll();
    switch (id) {
        case "0000002":
        case "0000004":
        case "0000008":
        case "0000009":
            ManTHabilitante.frmTHabilitanteRegistro.find("#divadendathabilitante").slideDown();
            if (id == "0000002") { ManTHabilitante.frmTHabilitanteRegistro.find("#cambio_tit").text('Cambio Titular'); }
            else if (id == "0000004") { ManTHabilitante.frmTHabilitanteRegistro.find("#cambio_tit").text('Cambio Titular'); }
            else if (id == "0000008") { ManTHabilitante.frmTHabilitanteRegistro.find("#cambio_tit").text('Incluir Titular Bosque Local'); }
            else if (id == "0000009") { ManTHabilitante.frmTHabilitanteRegistro.find("#cambio_tit").text('Incluir Titular en Sociedad'); }
            break;
        case "0000003": ManTHabilitante.frmTHabilitanteRegistro.find("#divadendamodarea").slideDown();
            ManTHabilitante.frmTHabilitanteRegistro.find("#divArea").slideDown();
            break;
        case "0000005":
            ManTHabilitante.frmTHabilitanteRegistro.find("#divadendaNumTH1").slideDown();
            ManTHabilitante.frmTHabilitanteRegistro.find("#divadendaNumTH2").slideDown();
            break;
        case "0000006":
            ManTHabilitante.frmTHabilitanteRegistro.find("#divadendaFecVigencia").slideDown();
            break;
    }
};
ManTHabilitante.adend.iniciarEventos = function () {
    ManTHabilitante.frmTHabilitanteRegistro.find("#txtItemAdeFInicio").datepicker({
        format: "dd/mm/yyyy",
        autoclose: true,
        language: 'es'
    });
    ManTHabilitante.frmTHabilitanteRegistro.find("#txtItemAdeFecTer").datepicker({
        format: "dd/mm/yyyy",
        autoclose: true,
        language: 'es'
    });
    ManTHabilitante.adend.limpiarControlAll = function () {
        ManTHabilitante.frmTHabilitanteRegistro.find("#hdEstadoRegAden").val(1);
        ManTHabilitante.frmTHabilitanteRegistro.find("#txtItemAdeFInicio").val('');
        ManTHabilitante.frmTHabilitanteRegistro.find("#txtItemAdeFecTer").val('');
        ManTHabilitante.frmTHabilitanteRegistro.find("#fItemCamTitularCodigo").val('');
        ManTHabilitante.frmTHabilitanteRegistro.find("#hdfItemCamTitularCodigo").val('');
        ManTHabilitante.frmTHabilitanteRegistro.find("#txtItemAdeNumTH").val('');
        ManTHabilitante.frmTHabilitanteRegistro.find("#txtItemAdeNumResol").val('');
        ManTHabilitante.frmTHabilitanteRegistro.find("#txtArea").val('');
        ManTHabilitante.frmTHabilitanteRegistro.find("#txtItemAdeObservacion").val('');
        ManTHabilitante.frmTHabilitanteRegistro.find("#txtEstadoAdenda").val('Nueva Adenda');
        ManTHabilitante.frmTHabilitanteRegistro.find("#btnAdendaAgregar").text('Agregar');
        ManTHabilitante.frmTHabilitanteRegistro.find("#btnAdendaCancelar").attr('style', 'display:none;');
        ManTHabilitante.frmTHabilitanteRegistro.find("#ddlItemAdeMotivoId").removeAttr('disabled');
        ManTHabilitante.adend.dtItemVerticeMod.clear().draw();
    };
    ManTHabilitante.adend.ocultarControlAll = function () {
        ManTHabilitante.frmTHabilitanteRegistro.find("#divadendathabilitante").slideUp();
        ManTHabilitante.frmTHabilitanteRegistro.find("#divadendaFecVigencia").slideUp();
        ManTHabilitante.frmTHabilitanteRegistro.find("#divArea").slideUp();
        ManTHabilitante.frmTHabilitanteRegistro.find("#divadendamodarea").slideUp();
        ManTHabilitante.frmTHabilitanteRegistro.find("#divadendaNumTH1").slideUp();
        ManTHabilitante.frmTHabilitanteRegistro.find("#divadendaNumTH2").slideUp();
    };
    ManTHabilitante.frmTHabilitanteRegistro.find("#ddlItemAdeMotivoId").on("change", function () {
        ManTHabilitante.adend.configurarControles($(this).val());
    });
    ManTHabilitante.frmTHabilitanteRegistro.find("#btnAdendaAgregar").click(function () {
        ManTHabilitante.adend.agregarAdend();
    });
    ManTHabilitante.frmTHabilitanteRegistro.find("#btnAdendaCancelar").click(function () {
        ManTHabilitante.frmTHabilitanteRegistro.find("#ddlItemAdeMotivoId").val('0000000');
        ManTHabilitante.adend.limpiarControlAll();
        ManTHabilitante.adend.ocultarControlAll();
        //limpiando datos de la grilla a eliminar en caso que se cancele
        ManTHabilitante.ListEliTABLATem = [];
    });
    //configurando tabla
    ManTHabilitante.adend.tbItemVerticeMod = ManTHabilitante.frmTHabilitanteRegistro.find("#tbItemVerticeMod");
    ManTHabilitante.adend.dtItemVerticeMod = ManTHabilitante.adend.tbItemVerticeMod.DataTable({
        "bServerSide": false,
        "bAutoWidth": false,
        "bProcessing": true,
        "bJQueryUI": false,
        "bRetrieve": true,
        "bFilter": false,
        "aaSorting": [],
        "bPaginate": true,
        "bInfo": false,
        "bLengthChange": false,
        "pageLength": 20,
        "oLanguage": initSigo.oLanguage,
        "drawCallback": initSigo.showPagination
    });
    ManTHabilitante.adend.tbItemAdendas = ManTHabilitante.frmTHabilitanteRegistro.find("#tbItemAdendas");
    ManTHabilitante.adend.dtItemAdendas = ManTHabilitante.adend.tbItemAdendas.dataTable({
        "bServerSide": false,
        "bAutoWidth": false,
        "bProcessing": true,
        "bJQueryUI": false,
        "bRetrieve": true,
        "bFilter": false,
        "bSortable": false,
        "aaSorting": [],
        "bSearchable": true,
        "bPaginate": true,
        "bInfo": false,
        "bLengthChange": false,
        "pageLength": 20,
        "oLanguage": initSigo.oLanguage,
        "drawCallback": initSigo.showPagination
    });

    ManTHabilitante.frmTHabilitanteRegistro.find("#fileselectMod").change(function (e) {
        ManTHabilitante.uploadFile.fileSelectHandler(e, 'fileselectMod');
    });
};

ManTHabilitante.uploadFile = {};

ManTHabilitante.uploadFile.fileSelectHandler = function (e, control) {
    if (e.dataTransfer != undefined &&
        e.dataTransfer.files != undefined) {
        ManTHabilitante.uploadFile.resetFileSelect(control);
    }

    // fetch FileList object
    var files = e.target.files || e.dataTransfer.files;

    if (files != undefined && files.length > 0) {
        ManTHabilitante.uploadFile.uploadFileToServer(files[0], control);
    }
};
// file drag hover
ManTHabilitante.uploadFile.fileDragHover = function (e) {
    e.stopPropagation();
    e.preventDefault();
    e.target.className = (e.type == "dragover" ? "hover" : "");
};
//Resets File Select
ManTHabilitante.uploadFile.resetFileSelect = function (control) {
    $("#" + control).replaceWith('<input type="file" id="' + control + '" name="' + control + '" class="form-control" />');
    var fileselect = $("#" + control);
    fileselect.attr('style', 'display:none');

    fileselect.change(function (e) {
        ManTHabilitante.uploadFile.fileSelectHandler(e, control);
    });
};
ManTHabilitante.uploadFile.uploadFileToServer = function (file, control) {
    var formdata = new FormData();

    if (control == 'fileselect') {
        formdata.append("aiCodSecuencialAdenda", ManTHabilitante.frmTHabilitanteRegistro.find("#hdfCodSecuencialAdenda").val());
    } else { formdata.append("aiCodSecuencialAdenda", "0"); }
    formdata.append(file.name, file);
    $.ajax({
        url: urlLocalSigo + "THabilitante/ManTHabilitante/ImportarDataExcel",
        type: 'POST',
        data: formdata,
        contentType: false,
        dataType: 'json',
        processData: false,
        success: function (data) {
            ManTHabilitante.uploadFile.resetFileSelect(control);
            utilSigo.unblockUIGeneral();
            if (data.success) {
                //cargando data
                if (data.data.length > 0) {
                    if (control == 'fileselect') ManTHabilitante.DGeneral.agregarVerticeExcel(data.data);
                    else ManTHabilitante.adend.agregarAdendVerticeExcel(data.data);
                    utilSigo.toastSuccess("Aviso", "Se Subio Correctamente la Informacion");
                }
                else {
                    utilSigo.toastWarning("Aviso", "No hay registros en la plantilla");
                }
            }
            else utilSigo.toastWarning("Aviso", data.msj);
        },
        beforeSend: function () {
            ManTHabilitante.uploadFile.resetFileSelect(control);
            utilSigo.blockUIGeneral();
        },
        error: function (jqXHR, error, errorThrown) {
            utilSigo.unblockUIGeneral();
            utilSigo.toastError("Error", "Sucedio un error, Comuniquese con el Administrador");
            // console.log(jqXHR.responseText);
        }
    });
};
ManTHabilitante.adend.exportarVerticeExcel = function () {
    var codigoTH = ManTHabilitante.frmTHabilitanteRegistro.find("#hdCodigo_Thabilitante").val();
    $.ajax({
        url: urlLocalSigo + "THabilitante/ManTHabilitante/ExportarExcelVertices",
        type: 'POST',
        data: { COD_THABILITANTE: codigoTH },
        dataType: 'json',
        success: function (data) {
            utilSigo.unblockUIGeneral();
            if (data.success) {
                window.location.href = urlLocalSigo + "THabilitante/ManTHabilitante/DownloadVertices?file=" + data.values[0];
            }
            else utilSigo.toastWarning("Error", data.msj);
        },
        beforeSend: function () {
            utilSigo.blockUIGeneral();
        },
        error: function (jqXHR, error, errorThrown) {
            utilSigo.unblockUIGeneral();
            utilSigo.toastError("Error", "Sucedio un error, Comuniquese con el Administrador");
            // console.log(jqXHR.responseText);
        }
    });
};

ManTHabilitante.registrarThabilitante = function () {
    var datosThabilitante = ManTHabilitante.frmTHabilitanteRegistro.serializeObject();
    var check = $("#chkItemPlanManejo");
    var state = check.is(":checked");
    if (state) {
        datosThabilitante.chkItemPlanManejo = true;
    } else {
        datosThabilitante.chkItemPlanManejo = false;
    }
    check = $("#chkItemContCuenta");
    state = check.is(":checked");
    if (state) {
        datosThabilitante.chkItemContCuenta = true;
    } else {
        datosThabilitante.chkItemContCuenta = false;
    }
    //preparando datos de tabla
    //datos de recategorizacion
    if (ManTHabilitante.dtRecategorizar != undefined) {
        ManTHabilitante.recat.prepararDatosReg();
        datosThabilitante.ListModalidadesTH = ManTHabilitante.ListModalidadesTH;
    }
    //variable para la modalidad
    var codMTipo = ManTHabilitante.frmTHabilitanteRegistro.find("#hdfItemModalidadCodigo").val();
    datosThabilitante.hdfItemModalidadCodigo = codMTipo;
    if (codMTipo == "0000010") {
        //ManTHabilitante.recat.prepararDatosReg();
        datosThabilitante.ListModalidadesTH = Recategorizar.fnGetList();
    }
    //datos de Establecimiento
    if (ManTHabilitante.dtEstablecimiento != undefined) {
        ManTHabilitante.estab.prepararDatosReg();
        datosThabilitante.ListTHEstadoEsta = ManTHabilitante.ListTHEstadoEsta;
    }
    //si modalidad tipo 0000001 o 0000002 por defeco capturara valores de ListTDDVVERTICE
    datosThabilitante.ListTDDVVERTICE = ManTHabilitante.ListTDDVVERTICE;
    //datos de vertices    
    if (ManTHabilitante.DGeneral.prepararDatosVer()) {
        datosThabilitante.ListTDDVVERTICE = ManTHabilitante.ListTDDVVERTICE;
    }
    //datos adendas
    if (ManTHabilitante.adend.dtItemAdendas != undefined) {
        // ManTHabilitante.adend.prepararDatosAdenda();
        datosThabilitante.ListAdendas = ManTHabilitante.ListAdendas;
    }
    //datos a eliminar
    datosThabilitante.ListEliTABLA = ManTHabilitante.ListEliTABLA;
    //Datos control de calidad
    datosThabilitante.vmControlCalidad = _ControlCalidad.fnGetDatosControlCalidad();

    //Datos Error Material
    datosThabilitante.tbErrorMaterial_DGeneral = ManTHabilitante.fnGetListErrorMaterial('DG');
    datosThabilitante.tbErrorMaterial_DAdicional = ManTHabilitante.fnGetListErrorMaterial('DA');
    if (datosThabilitante.cod_Modalidad != "0000002") {
        datosThabilitante.ListTHExtincion = Extincion.fnGetList();
        datosThabilitante.ListEliTABLAExt = Extincion.tbEliTABLA
    }
    datosThabilitante.tbDivisionInterna = ManTHabilitante.fnGetDivisionInterna();
    //enviando datos al servidor
    $.ajax({
        url: urlLocalSigo + "THabilitante/ManTHabilitante/RegistrarThabilitante",
        type: 'POST',
        data: JSON.stringify(datosThabilitante),
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function (data) {
            utilSigo.unblockUIGeneral();
            if (data.success) {
                if (ManTHabilitante.frmTHabilitanteRegistro.find("#opRegresar").val() == 0) {
                    utilSigo.toastSuccess("Aviso", data.msj);
                    setTimeout(function () {
                        ManTHabilitante.regresar(data.appServer);
                    }, 2000);
                } else {
                    ManTHabilitante.regresar(data.appServer);
                }
            }
            else {
                if (ManTHabilitante.frmTHabilitanteRegistro.find("#opRegresar").val() == 0) {
                    utilSigo.toastWarning("Aviso", data.msj);
                } else {
                    ManTHabilitante.regresar(data.appServer);
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

ManTHabilitante.fnInitDataTable_Detail = function () {
    var columns_label = [], columns_data = [], options = {};

    //Cargar Error Material
    columns_label = ["Fecha de Resolución", "Resolución", "Nombre Campo", "Valor Anterior", "Valor Actual", "Observaciones"];
    columns_data = ["DA_FECRESOLUCION", "NV_RESOLUCION", "NV_NOMCAMPO", "NV_VALANTERIOR", "NV_VALACTUAL", "NV_OBSERVACION"];
    options = {
        page_length: 10, row_index: true, page_sort: true
    };
    ManTHabilitante.dtErrorMaterial_DGeneral = utilDt.fnLoadDataTable_Detail(ManTHabilitante.frmTHabilitanteRegistro.find("#tbErrorMaterial_DGeneral"), columns_label, columns_data, options);
    ManTHabilitante.dtErrorMaterial_DGeneral.rows.add(JSON.parse(ManTHabilitante.DataErrorMaterial_DGenereal)).draw();

    ManTHabilitante.dtErrorMaterial_DAdicional = utilDt.fnLoadDataTable_Detail(ManTHabilitante.frmTHabilitanteRegistro.find("#tbErrorMaterial_DAdicional"), columns_label, columns_data, options);
    ManTHabilitante.dtErrorMaterial_DAdicional.rows.add(JSON.parse(ManTHabilitante.DataErrorMaterial_DAdicional)).draw();
}

ManTHabilitante.fnAddErrorMaterial = function (tipo) {
    var url = urlLocalSigo + "THabilitante/ManTHabilitante/_ErrorMaterial";
    var option = { url: url, type: 'POST', datos: {}, divId: "modalAddErrorMaterial" };

    utilSigo.fnOpenModal(option, function () {
        _ErrorMaterial.fnCloseModal = function () {
            $("#modalAddErrorMaterial").modal('hide');
        };

        _ErrorMaterial.fnSaveForm = function (data) {
            if (data != null) {
                var dt;
                switch (tipo) {
                    case 'DG':
                        dt = ManTHabilitante.dtErrorMaterial_DGeneral;
                        break;
                    case 'DA':
                        dt = ManTHabilitante.dtErrorMaterial_DAdicional;
                        break;
                }

                dt.order([1, 'desc']).draw();
                dt.rows.add([data]).draw();
                dt.page('last').draw('page');
                $("#modalAddErrorMaterial").modal('hide');
            } else {
                utilSigo.toastSuccess("Error", "No se pudieron guardar los datos");
            }
        };

        _ErrorMaterial.fnInit(tipo);
    });
}

ManTHabilitante.fnGetListErrorMaterial = function (tipo) {
    var dt, list = [], rows, countFilas, data;

    switch (tipo) {
        case 'DG':
            dt = ManTHabilitante.dtErrorMaterial_DGeneral;
            break;
        case 'DA':
            dt = ManTHabilitante.dtErrorMaterial_DAdicional;
            break;
    }

    rows = dt.$("tr");
    countFilas = rows.length;
    if (countFilas > 0) {
        $.each(rows, function (i, o) {
            data = dt.row($(o)).data();
            list.push(utilSigo.fnConvertArrayToObject(data));
        });
    }

    return list;
}