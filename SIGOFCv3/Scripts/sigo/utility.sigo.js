"use strict";
(function ($) {
    $.fn.serializeObject = function () {
        "use strict";
        var result = {};
        var extend = function (i, element) {
            var node = result[element.name];
            if ('undefined' !== typeof node && node !== null) {
                if ($.isArray(node)) {
                    node.push(element.value);
                } else {
                    result[element.name] = [node, element.value];
                }
            } else {
                //result[element.name] = element.value.trim();                    
                result[element.name] = element.value.trim().replace(/<script/g, 'XXXXXXX')
                    .replace(/script>/g, 'XXXXXXX');
            }
        };
        $.each(this.serializeArray(), extend);
        return result;
    };
})(jQuery);
var utilSigo = {};

utilSigo.unblockUIGeneral = function () {
    $.unblockUI();
}
utilSigo.blockUIGeneral = function () {
    $.blockUI({
        message: '<div class="loadmask-msg"><div>Procesando datos...</div></div>',
        css: {
            border: 'none',
            padding: '2px',
            backgroundColor: '#444444',
            '-webkit-border-radius': '10px',
            '-moz-border-radius': '10px',
            opacity: 1,
            color: '#fff',
            width: 150,
            top: ($(window).height() - 40) / 2 + 'px',
            left: ($(window).width() - 150) / 2 + 'px',
        },
        baseZ: 10060
    });
}

utilSigo.blockUIElement = function (el, centerY) {
    var el = jQuery(el);
    if (el.height() <= 400) {
        centerY = true;
    }
    el.block({
        message: '<div class="loadmask-msg"><div>Procesando datos...</div></div>',
        centerY: centerY != undefined ? centerY : true,
        css: {
            top: '10%',
            border: 'none',
            padding: '2px',
            backgroundColor: '#444444',
            '-webkit-border-radius': '10px',
            '-moz-border-radius': '10px',
            color: '#fff',
        },
        overlayCSS: {
            backgroundColor: '#444444',
            '-webkit-border-radius': '10px',
            '-moz-border-radius': '10px',
            color: '#fff',
            opacity: 0.5,
            cursor: 'wait'
        },
        baseZ: 10060
    });
}
utilSigo.unblockUIElement = function (el) {
    jQuery(el).unblock({
        onUnblock: function () {
            jQuery(el).removeAttr("style");
        }
    });
}
utilSigo.jBlockUIDefault = function () {
    utilSigo.restoreLoadMask();
    jBlockUI({
        message: $('.loadmask-msg'),
        css: {
            border: 'none',
            padding: '2px',
            backgroundColor: '#E15522',
            '-webkit-border-radius': '10px',
            '-moz-border-radius': '10px',
            opacity: 1,
            color: '#fff',
            width: 150,
            top: ($(window).height() - 40) / 2 + 'px',
            left: ($(window).width() - 150) / 2 + 'px',
        },
        baseZ: 10060
    });
}

utilSigo.toastSetup = function () {
    //probamos el toast
    toastr.options = {
        closeButton: true,
        debug: false,
        positionClass: "toast-bottom-right",//"toast-top-left",
        onclick: null,
        showDuration: 1000,
        hideDuration: 1000,
        timeOut: 5000,
        extendedTimeOut: 1000,
        showEasing: "swing",
        hideEasing: "linear",
        showMethod: "fadeIn",
        hideMethod: "fadeOut"
    }
}
utilSigo.toastSuccess = function (title, msg) {
    utilSigo.toastSetup();
    var $toast = toastr['success'](msg, title);
}
utilSigo.toastError = function (title, msg) {
    utilSigo.toastSetup();
    var $toast = toastr['error'](msg, title);
}
utilSigo.toastWarning = function (title, msg) {
    utilSigo.toastSetup();
    var $toast = toastr['warning'](msg, title);
}
utilSigo.toastInfo = function (title, msg) {
    utilSigo.toastSetup();
    var $toast = toastr['info'](msg, title);
}
utilSigo.modalDraggable = function ($modalNumeracionComprobante, htmlTitle) {
    /*var _handle = htmlTitle;
    if (!htmlTitle) {
        _handle = ".modal-header";
    }
    //$modalNumeracionComprobante.draggable({ handle: _handle });
    $modalNumeracionComprobante.on('hidden.bs.modal', function (e) {
        $modalNumeracionComprobante.removeAttr('style');
    });*/
}
utilSigo.check = function (e) {
    var tecla = (document.all) ? e.keyCode : e.which;

    if (tecla == 8 || tecla == 32) {
        return true;
    }
    var patron = "/[A-Za-z0-9]";
    var tecla_final = String.fromCharCode(tecla);
    return patron.test(tecla_final);

}
utilSigo.loadAjaxCombo = function (_url, combo, _data, itemDefault, isasync, fn) {
    $.ajax({
        type: 'POST',
        async: (!isasync) ? true : false,
        url: _url,
        data: _data,
        dataType: 'json',
        success: function (data) {
            //console.log(data);
            utilSigo.fillCombo(combo, data, itemDefault);
            if (fn) {
                fn();
            }
        },
        beforeSend: function () {
            utilSigo.blockUIElement(combo);
        },
        error: function (jqXHR, error, errorThrown) {
            utilSigo.unblockUIElement(combo);
            utilSigo.toastError("Error", initSigo.MessageError);
            console.log(jqXHR.responseText);
        }
    });
}
utilSigo.fillCombo = function (combo, data, itemSelect) {
    var itemsDefault = -1;
    combo.empty();
    var options = "";
    $.each(data, function (i, o) {
        options += "<option value='" + o.Value + "'>" + o.Text + "</option>";
        if (o.Selected) {
            itemsDefault = o.Value;
        }
    });
    combo.append(options);

    if (itemSelect) {
        combo.val(itemSelect);
    } else {
        if (itemsDefault != -1)
            combo.val(itemsDefault);
    }
}

utilSigo.fillComboSelect2 = function (combo, data, itemSelect, cadena) {
    var itemsDefault = -1;
    combo.select2('val', '');  //quitando la seleccion
    combo.html('');    //limpiando el combo
    $.each(data, function (i, o) {
        combo.append("<option value='" + o.Value + "'>" + o.Text + "</option>");
        if (o.Selected) {
            itemsDefault = o.Value;
        }
    });
    if (itemSelect) {
        combo.val(itemSelect);
    }
    else if (itemsDefault != -1) {
        combo.select2('val', itemsDefault);  //propio del plugin select2
    }
}
//tipo 0-cargar departamento,1-cargar provincia,2-cargar distrito
utilSigo.fillComboSelect2Ubigeo = function (combo, data, tipo, idSelect, itemSelect) {
    var itemsDefault = -1;
    combo.select2('val', '');  //quitando la seleccion
    combo.html('');    //limpiando el combo   
    if (tipo == 0) {
        $.each(data, function (i, o) {
            combo.append("<option value='" + o.COD_UBIDEPARTAMENTO + "'>" + o.DEPARTAMENTO + "</option>");
        });
    }
    else if (tipo == 1) {
        combo.append("<option value='-'>Seleccionar</option>");
        $.each(data, function (i, o) {
            if (o.COD_UBIDEPARTAMENTO == idSelect) {
                combo.append("<option value='" + o.COD_UBIPROVINCIA + "'>" + o.PROVINCIA + "</option>");
            }
        });
    }
    else if (tipo == 2) {
        combo.append("<option value='-'>Seleccionar</option>");
        $.each(data, function (i, o) {
            if (o.COD_UBIPROVINCIA == idSelect) {
                combo.append("<option value='" + o.COD_UBIGEO + "'>" + o.DISTRITO + "</option>");
            }
        });
    }
    if (itemSelect) {
        combo.val(itemSelect);
    }
    else if (itemsDefault != -1) {
        combo.select2('val', itemsDefault);  //propio del plugin select2
    }
}
//resetea un formulario, ids opcional array de string con los id de los hidden
utilSigo.FormReset = function ($form, ids) {
    $(':input', $form)
        .not(':button, :submit, :reset, :hidden')
        .val('')
        .removeAttr('checked');
    //$form.find("select").val();
    if (ids) {
        $.each(ids, function (i, o) {
            $("#" + o).val('');
        })
    }
}

/*DialogBootbox para confirm*/
utilSigo.dialogConfirm = function (_title, _msg, fnOk, fnCancel) {
    //var ventana_alto = $(window).height();
    var altNavegador = $(window).height();
    bootbox.dialog({
        title: "",
        message: _msg,
        buttons: {
            Ok: {
                label: 'Aceptar',
                className: 'btn-sm  btn-primary',
                iconFa: 'fa-check',
                callback: fnOk
            },
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
utilSigo.onKeyDecimal = function (e, thix) {

    var keynum = window.event ? window.event.keyCode : e.which;
    if (document.getElementById(thix.id).value.indexOf('.') != -1 && keynum == 46)
        return false;
    if ((keynum == 8 || keynum == 48 || keynum == 46))
        return true;
    if (keynum <= 47 || keynum >= 58) return false;
    return /\d/.test(String.fromCharCode(keynum));
}
utilSigo.onKeyEntero = function (e, thix) {

    var keynum = window.event ? window.event.keyCode : e.which;
    if ((keynum == 8 || keynum == 48))
        return true;
    if (keynum <= 47 || keynum >= 58) return false;
    return /\d/.test(String.fromCharCode(keynum));
}
utilSigo.BotonMenuShow = function (BotonTool, MenuDiv, Ubicacion) {
    try {
        var position = $("#" + BotonTool).offset();
        var MenWidth = $("#" + MenuDiv).outerWidth(true);
        var MenHeight = $("#" + MenuDiv).outerHeight(true) - 19;
        var BonWidth = $("#" + BotonTool).outerWidth(true);
        var ScrollTop = $(window).scrollTop();
        var ScrollLeft = $(window).scrollLeft();

        if (Ubicacion == 'LD') { //Izquierda Abajo
            //Menu Abajo
            $("#" + MenuDiv).css({ "top": position.top - 2, "left": position.left - MenWidth });
        }
        else if (Ubicacion == 'LU') { //Izquierda Arriba
            //Menu Arriba
            $("#" + MenuDiv).css({ "top": (position.top - MenHeight) + ScrollTop, "left": position.left - MenWidth });
        }
        else if (Ubicacion == 'RD') { //Derecha Abajo
            //Menu Abajo

            $("#" + MenuDiv).css({ "top": position.top - 2 - ScrollTop, "left": position.left + 10 - ScrollLeft });
        }
        else if (Ubicacion == 'RU') { //Derecha Arriba
            //Menu Arriba
            $("#" + MenuDiv).css({ "top": (position.top - MenHeight) - ScrollTop, "left": (position.left + BonWidth) - 2 });
        }
        //
        $("#" + MenuDiv).show();
    }
    catch (err) {
        $("#" + MenuDiv).show();
    }

}
utilSigo.BotonMenuHide = function (MenuDiv) {
    $("#" + MenuDiv).hide();
}
//data{modalId='idElement'}
//url la direccion del Ajax
utilSigo.openModal = function (url, datos) {

    var _hrModal = $.ajax({
        url: url,
        type: 'POST',
        data: datos,
        dataType: 'html',
        beforeSend: utilSigo.beforeSendAjax,
        error: utilSigo.errorAjax,
        complete: utilSigo.completeAjax,
        success: function (data) {
            if (_hrModal.status != 203) {
                $("#" + datos.modalId).html(data);
                utilSigo.modalDraggable($("#" + datos.modalId), '.modal-header');
                $("#" + datos.modalId).modal({ keyboard: true, backdrop: 'static' });
            }

        },
        statusCode: {
            203: () => { utilSigo.unblockUIGeneral(); utilSigo.toastInfo("Aviso", "El usuario perdio la sesión. Vuelva ingresar al sistema"); }
        }
    });

}
utilSigo.focusFirstControlModal = function (idModal) {

    $("#" + idModal).unbind("shown.bs.modal").on('shown.bs.modal', function () {
        var control = $("#" + idModal).find('input[type=text],input[type=password],input[type=radio],input[type=checkbox],textarea,select').filter(':visible:first');
        if (control != null)
            control.focus();
    });
}
utilSigo.closeCleanModal = function (idModal, fnClose) {
    $("#" + idModal).unbind("hidden.bs.modal").on('hidden.bs.modal', function () {
        if (fnClose)
            fnClose();

        if ($('.modal:visible').length) { // check whether parent modal is opend after child modal close
            $('body').addClass('modal-open'); // if open mean length is 1 then add a bootstrap css class to body of the page
        }

        $(this).hide();
        $(this).html("");
    });
}
utilSigo.fnOpenModal = function (option, fn, fnClose) {
    var _hrModal = $.ajax({
        url: option.url,
        type: (typeof option.type) === 'undefined' ? 'GET' : option.type,
        data: (typeof option.datos) === 'undefined' ? {} : option.datos,
        dataType: 'html',
        beforeSend: utilSigo.beforeSendAjax,
        error: utilSigo.errorAjax,
        complete: utilSigo.completeAjax,
        success: function (data) {
            if (_hrModal.status != 203) {
                $("#" + option.divId).html(data);
                utilSigo.modalDraggable($("#" + option.divId), '.modal-header');
                $("#" + option.divId).modal({ keyboard: option.keyboard ? true : false, backdrop: 'static' });
                if ((typeof option.focus) === 'undefined' || option.focus == true)
                    utilSigo.focusFirstControlModal(option.divId);

                utilSigo.closeCleanModal(option.divId, fnClose);
                if (fn)
                    fn();
            }

        },
        statusCode: {
            203: () => { utilSigo.unblockUIGeneral(); utilSigo.toastWarning("Aviso", "El usuario perdio la sesión. Vuelva ingresar al sistema"); }
        }
    });
}
//por defecto es get. funcion para eliminar, actualizar o guardar
utilSigo.fnAjax = function (option, fn) {
    $.ajax({
        url: option.url,
        type: (typeof option.type) === 'undefined' ? 'GET' : option.type,
        data: (typeof option.datos) === 'undefined' ? {} : option.datos,
        contentType: (typeof option.contentType) === 'undefined' ? 'application/json; charset=utf-8' : option.contentType,
        dataType: (typeof option.dataType) === 'undefined' ? 'json' : option.dataType,
        beforeSend: utilSigo.beforeSendAjax,
        error: utilSigo.errorAjax,
        complete: utilSigo.completeAjax,
        success: function (data) {
            if (fn) {
                fn(data);
            }
            else {
                if (data.success) {
                    utilSigo.toastSuccess("Aviso", data.msj);
                }
                else {
                    utilSigo.toastWarning("Aviso", initSigo.MessageError);
                    console.log(data.msjError);
                }
            }
        },
        statusCode: {
            203: () => { utilSigo.unblockUIGeneral(); utilSigo.toastInfo("Aviso", "El usuario perdio la sesión. Vuelva ingresar al sistema"); }
        }
    });
}
utilSigo.fnCloseModal = function (div) {
    $('#' + div).modal('hide');
    $('#' + div).html('');
}
////Utilidades plugin DataTable
//Busqueda de un valor en una columna de una tabla
//dataTable=Objeto del Datatable(), nameData=nombre de la columna a buscar, valorSearch=valor a buscar
utilSigo.existValorSearchDataTable = function (dataTable, nameData, valorSearch) {
    var result = false;
    dataTable.rows().every(function (rowIdx, tableLoop, rowLoop) {
        var data = this.data();
        if (valorSearch == data[nameData]) {
            result = true;
            return;
        }
    });
    return result;
}
//Agrega un contador a toda la tabla en la columna indexColumn
//dataTable=Objeto del Datatable,indexColumn=Indice   de la columna comienza en 0
utilSigo.enumTB = function (dataTable, indexColumn) {
    dataTable.on('order.dt', function () {
        dataTable.column(indexColumn, {}).nodes().each(function (cell, i) {
            cell.innerHTML = i + 1;
        });
    }).draw(false);
}

//Se usa para las validaciones de campos vacios
utilSigo.ValidaTexto = function (ControlTexto, Mensaje) {
    if ($("#" + ControlTexto).val().trim() == "") {
        utilSigo.toastError("Error", Mensaje);
        $("#" + ControlTexto).focus();
        return false;
    }
    return true;
}
utilSigo.ValidaCombo = function (ControlTexto, Mensaje) {
    if ($("#" + ControlTexto).val() == "-" || $("#" + ControlTexto).val() == "--" ||
        $("#" + ControlTexto).val() == "" || $("#" + ControlTexto).val() == null) {
        utilSigo.toastError("Error", Mensaje);
        $("#" + ControlTexto).focus();
        return false;
    }
    return true;
}
//Se usa para las sumatorias de los datatables
utilSigo.intVal = function (i) {
    return typeof i === 'string' ?
        i.replace(/[\$,]/g, '') * 1 :
        typeof i === 'number' ?
            i : 0;
}

utilSigo.fnFormatDate = function (domControl) {
    domControl.datepicker({
        format: "dd/mm/yyyy",
        autoclose: true,
        language: 'es'
    });
}

//Validar controles de un formulario (mostrar dato faltante y el tab en donde se encuentra el control)
//controls: ["control_1","control_2",...,"control_n"]
utilSigo.fnValidateForm = function (domForm, controls) {
    var idtab = "";
    var valRetorno = true;
    var idControlError = "";
    $.each(controls, function (i, o) {
        if (domForm.find("#" + o).val() == "" || domForm.find("#" + o).val() == "0000000") {
            idControlError = domForm.find("#" + o);
            idtab = domForm.find("#" + o).parents(".tab-pane").attr("id");
            valRetorno = false;
            return false;
        }
    })
    if (idtab != "") {
        domForm.find('a[href="#' + idtab + '"]').tab('show');
        idControlError.focus();
    }
    return valRetorno;
}

utilSigo.fnValidateForm_HideControl = function (domForm, domControl, domIcon, isTab) {
    $('[data-toggle="tooltip"]').tooltip();
    var valorValidar = domControl.val();
    var iconValidar = domIcon;
    if (valorValidar.trim() == '') {
        if (isTab) {
            var idtab = domControl.parents(".tab-pane").attr("id");
            domForm.find('a[href="#' + idtab + '"]').tab('show');
        }
        iconValidar.removeAttr('style');
        utilSigo.toastWarning("Aviso", iconValidar.attr("data-original-title"));
        return false;
    }
    else {
        iconValidar.attr('style', 'display:none;');
        return true;
    }
}
utilSigo.fnValidate = function (obj) {
    return {
        focusInvalid: true,
        ignore: [],// hiden predeterminado
        rules: obj.rules,
        messages: obj.messages,
        invalidHandler: function (event, validator) { },
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
        },
        submitHandler: obj.fnSubmit
    };
}
utilSigo.fnGetValChk = function (domControl) {
    return domControl.is(":checked");
}

/*
Convertir Array: [nombre:"Carlos",ape_paterno:"Huaroc",...,etc]
a un Objeto: {nombre: "Carlos",ape_paterno:"Huaroc",...,etc}
*/
utilSigo.fnConvertArrayToObject = function (dataArray) {
    var dataObject = {}, objEnt;

    //Evaluar si se trata de un Array, caso contrario devolver el objeto
    if (dataArray.constructor == Array) {
        objEnt = Object.entries(dataArray);

        for (var i = 0; i < objEnt.length; i++) {
            if (objEnt[i][1] == null) {
                dataObject[objEnt[i][0]] = "";
            } else {
                dataObject[objEnt[i][0]] = objEnt[i][1];
            }
        }
    } else {
        dataObject = dataArray;
    }

    return dataObject;
}

utilSigo.ValorIsFechaValue = function (Valor) {
    // regla con expresiones regulares.
    var Patron = /^([0][1-9]|[12][0-9]|3[01])(\.|-|\/)(0[1-9]|1[012])\2(\d{4})$/;
    // utilizamos test para comprobar si el parametro valor cumple la regla
    if (Patron.test(Valor)) {
        return utilSigo.ValorIsFechaDia(Valor);
    }
    else {
        return false;
    }
}
utilSigo.ValorIsFechaDia = function (valor) {
    var fecha = valor.split("/");
    var dia = parseInt(fecha[0], 10);
    var mes = parseInt(fecha[1], 10);
    var ano = parseInt(fecha[2], 10);
    var diaUltimo = (new Date(ano, mes, 0)).getDate();
    if (dia > diaUltimo) {
        return false;
    }
    return true;
}

utilSigo.errorAjax = function (jqXHR, error, errorThrown) {
    utilSigo.unblockUIGeneral();
    utilSigo.toastError("Error", initSigo.MessageError);
    //console.log(jqXHR.responseText);
}
utilSigo.beforeSendAjax = function () {
    utilSigo.blockUIGeneral();
}
utilSigo.completeAjax = function () {
    utilSigo.unblockUIGeneral();
}
//Configura los input text del contenedor(formulario,div)
//objContenedor del contenedor(formulario,div)
utilSigo.configContenedor = function (objContenedor) {
    objContenedor.find("input[type=text]")
        .css("text-transform", "uppercase")
        .keyup(function () {
            this.value = this.value.toUpperCase();
        });
}
utilSigo.validarFormato = function (opcion) {
    $("body").append('<div class="modal fade" id="validarFormatosModal" tabindex="-1" role="dialog"></div>');
    var option = { url: urlLocalSigo + "General/Controles/_ValidarPlantilla", type: 'GET', datos: { origen: opcion }, divId: "validarFormatosModal" };
    utilSigo.fnOpenModal(option, function () { });
}

// /Date(1386478800000)/ -> 2013-12-08
utilSigo.convertirFecha = function (strFecha) {
    if (strFecha != null) {
        var milliseconds = strFecha.replace(/\/Date\((-?\d+)\)\//, '$1');
        strFecha = new Date(parseInt(milliseconds));
        return strFecha.toISOString().substring(0, 10);
    } else {
        return '';
    }
};
utilSigo.elementOk = function (element) {
    element.removeClass('error border-danger');
    element.removeAttr('data-toggle');
    element.removeAttr('data-placement');
    element.removeAttr('data-original-title');
    $('[data-toggle="tooltip"]').tooltip();
};
utilSigo.elementERROR = function (element, string) {
    element.focus();
    element.addClass('error border-danger');
    element.attr('data-toggle', 'tooltip');
    element.attr('data-placement', 'top');
    element.attr('data-original-title', string);
    $('[data-toggle="tooltip"]').tooltip();
};
// return array[0] = 'YYYY-MM-DD' array[1] = HH:MM
utilSigo.obtenerFechaHora = function () {
    var date = new Date();
    var day = date.getDate(),
        month = date.getMonth() + 1,
        year = date.getFullYear(),
        hour = date.getHours(),
        min = date.getMinutes();
    month = (month < 10 ? "0" : "") + month;
    day = (day < 10 ? "0" : "") + day;
    hour = (hour < 10 ? "0" : "") + hour;
    min = (min < 10 ? "0" : "") + min;

    var today = year + "-" + month + "-" + day, displayTime = hour + ":" + min;
    var arrayReturn = [];
    arrayReturn[0] = today;
    arrayReturn[1] = displayTime;
    return arrayReturn;
};

utilSigo.convertirFechaHoraStandar = function (fecha) {
    var returns = '0';

    if (fecha != null && fecha != ' ' && fecha != '') {
        if (fecha.split('/').length == 3) {
            var arr = fecha.split('/');
            returns = arr[2] + '-' + arr[1] + '-' + arr[0];
        } else {
            returns = '1';
        }
    }



    return returns;
};

utilSigo.isFechaMayor = function (date1, date2) {
    let returns = false;
    if (date1 > date2) {
        returns = true;
    }
    return returns;
};

utilSigo.isFechaMenorDeHoy = function (fechaIngresada) {

    let dateIn = utilSigo.convertirFechaHoraStandar(fechaIngresada);

    if (utilSigo.isFechaMayor(dateIn, utilSigo.obtenerFechaHora()[0])) {
        return false;
    } else {
        return true;
    }
}

utilSigo.agregarSlashFecha = function (event) {
    var input = event.target;
    var valor = input.value.replace(/\D/g, '');
    var dia = valor.slice(0, 2);
    var mes = valor.slice(2, 4);
    var anio = valor.slice(4, 8);
    input.value = dia + '/' + mes + '/' + anio;
}

utilSigo.recortarTextos = function (str, lenght) {
    if (str.length > lenght) {
        return str.substr(0, lenght) + '...';
    } else {
        return str;
    }
};
utilSigo.file = {
    downloadBlob: (blob, fileName) => {
        let link = document.createElement('a');
        // create a blobURI pointing to our Blob
        link.href = URL.createObjectURL(blob);
        link.download = fileName;
        // some browser needs the anchor to be in the doc
        document.body.append(link);
        link.click();
        link.remove();
        // in case the Blob uses a lot of memory
        window.addEventListener('focus', e => URL.revokeObjectURL(link.href), { once: true });
    },
    getBinary: (filename, url) => {
        utilSigo.blockUIGeneral();
        fetch(url, {
            method: 'GET'
        }).then(function (resp) {
            switch (resp.status) {
                case 200: return resp.blob();
                case 404: throw Error(initSigo.MessageError);
                case 500: throw Error(initSigo.MessageError);
                case 401: throw Error(initSigo.MessageError);
                case 403: throw Error(initSigo.MessageError);
            }
        }).then(function (blob) {
            utilSigo.unblockUIGeneral();
            utilSigo.file.downloadBlob(blob, `${filename}`);
        }).catch(function (error) {
            utilSigo.unblockUIGeneral();
            utilSigo.toastError("Error", error.message);
        });
    }
}
//Validamos el formulario con el Rol asignado al usuario
//rol: Variable de la consulta por el nombre del menu
//idsave: Id del boton Guardar
//idIndicador: Id del Indicador del Estado  Situacional, de no existir para algunos formularios de registro debe ingresar 'Edit'
utilSigo.ValidaRol = function (rol, idSave, idIndicador) {
    console.log('datos:', rol, idSave, idIndicador);
    if (rol) {
        if (rol == "R2" || rol == "R1" || rol == "M") {
            if (idIndicador) {
                let read = false, msj = "", id = parseInt(idIndicador);
                switch (rol) {
                    case "R1":
                        if (id < 2 || id == 7) { msj = " hasta el estado <b>Registro Concluido</b>"; read = true; }
                        break;
                    case "R2":
                        if (id != 6) { msj = "hasta el estado <b> Control de Calidad Conforme</b>"; read = true; }
                        break;
                    default:
                        msj = " en su totalidad"; read = true;
                        break;
                }
                if (!read) {

                    utilSigo.toastWarning("Modo Lectura", "Usted solo podrá visualizar el formulario");
                    $('#' + idSave).remove(); utilSigo.disabledOpc();
                }
                else {
                    utilSigo.toastInfo("Formulario con acceso", "Tiene la opción de <b>Registrar y Modificar el formulario</b>." + msj);

                }
            } else {
                utilSigo.toastInfo("Formulario con acceso",
                    "Tiene la opción de <b>Registro y modificación</b>.");
            }
        }
        else if (rol == "C") {
            utilSigo.toastWarning("Modo Lectura", "Usted solo podrá visualizar el formulario");
            setTimeout(() => { $('#' + idSave).remove(); }, 50);
            if (idIndicador) utilSigo.disabledOpc();
        }
    } else {
        //window.location.href = urlLocalSigo +'Main/Principal/AccesoUsuario';
    }
}

utilSigo.disabledOpc = function () {
    $('input').prop("disabled", true); $('select').prop("disabled", true);
    $('textarea').prop("disabled", true);
    $('button').prop("disabled", true);
    setTimeout(() => {
        $('form i.fa-window-close').prop("onclick", false);
        $('form i.fa-file-o').prop("onclick", false);
        $('.dt-button').prop("disabled", false);


        $('.no-bloqueo-rol button').prop("disabled", false);
        $('.no-bloqueo-rol input').prop("disabled", false);
        $('.no-bloqueo-rol textarea').prop("disabled", false);
        $('.no-bloqueo-rol select').prop("disabled", false);
    }, 2000);
}

utilSigo.checkNum = function (e) {
    var tecla = (document.all) ? e.keyCode : e.which;

    if (tecla == 8 || tecla == 32) {
        return true;
    }

    var patron = /[0-9]/;
    var tecla_final = String.fromCharCode(tecla);
    return patron.test(tecla_final);
}

utilSigo.checkLetter = function (e) {
    var tecla = (document.all) ? e.keyCode : e.which;

    if (tecla === 13) {
        return true;
    }

    if (tecla == 8 || tecla == 32) {
        return true;
    }

    var patron = /[ ÁÉÍÓÚÑA-Záéíóúa-zñ0-9\-\/\.\,]/;
    var tecla_final = String.fromCharCode(tecla);
    return patron.test(tecla_final);
}

utilSigo.validarNumeroDecimal = function (numero, digitosEnteros, digitosDecimales) {
    const regex = new RegExp(`^[0-9]{1,${digitosEnteros}}(\\.[0-9]{1,${digitosDecimales}})?$`);
    return regex.test(numero);
}

utilSigo.onKeyTwoDecimal = function (e, thix) {
    let numero = document.getElementById(thix.id).value;
    var keynum = window.event ? window.event.keyCode : e.which;
    if (document.getElementById(thix.id).value.indexOf('.') != -1 && keynum == 46)
        return false;
    if ((keynum == 8 || keynum == 48 || keynum == 46))
        return true;
    if (keynum <= 47 || keynum >= 58) return false;
    if (numero == "") return true;
    if (numero.charAt(numero.length - 1) == ".") return true;
    return /^\d+(\.\d{1})?$/.test(numero);
}

utilSigo.onBlurTwoDecimal = function (thix, texto) {
    let numero = document.getElementById(thix.id).value;
    if (!/^\d+(\.\d{1,2})?$/.test(numero)) {
        document.getElementById(thix.id).value = 0;
        utilSigo.toastWarning("Aviso", "El " + texto + " sólo debe tener dos decimales");
        $("#" + thix.id).focus();
    }
}

utilSigo.onBlurTwoDecimalIS = function (thix, texto) {
    let numero = document.getElementById(thix.id).value;
    if (numero != "") {
        if (!/^\d+(\.\d{1,2})?$/.test(numero)) {
            document.getElementById(thix.id).value = "";
            utilSigo.toastWarning("Aviso", "El " + texto + " sólo debe tener dos decimales");
            $("#" + thix.id).focus();
        }
    }
}

utilSigo.onBlurThreeDecimal = function (thix, texto) {
    let numero = document.getElementById(thix.id).value;
    if (numero != "") {
        if (!/^\d+(\.\d{1,3})?$/.test(numero)) {
            document.getElementById(thix.id).value = "";
            utilSigo.toastWarning("Aviso", "El " + texto + " sólo debe tener tres decimales");
            $("#" + thix.id).focus();
        }
    }
}
utilSigo.onBlurFourDecimal = function (thix, texto) {
    let numero = document.getElementById(thix.id).value;
    if (numero != "") {
        if (!/^\d+(\.\d{1,4})?$/.test(numero)) {
            document.getElementById(thix.id).value = "";
            utilSigo.toastWarning("Aviso", "El " + texto + " sólo debe tener cuatro decimales");
            $("#" + thix.id).focus();
        }
    }
}

utilSigo.onBlurMail = function (thix, texto) {
    let numero = document.getElementById(thix.id).value;
    if (numero != "") {
        if (!/^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/.test(numero)) {
            document.getElementById(thix.id).value = "";
            utilSigo.toastWarning("Aviso", "El " + texto + " no es un correo válido");
            $("#" + thix.id).focus();
        }
    }
}
utilSigo.validateFechaRango = function (id, texto) {
    let fecha = $('#' + id).val();
    if (typeof fecha !== 'undefined') {
        if (fecha != '') {
            let campos = fecha.split('/');
            let date = new Date(campos[2] + "-" + campos[1] + "-" + campos[0]);
            let dateToday = new Date(utilSigo.obtenerFechaHora()[0]);
            let datePast = new Date(utilSigo.obtenerFechaHora()[0]);
            datePast.setFullYear(datePast.getFullYear() - 5);
            let dateTodayCampos = utilSigo.obtenerFechaHora()[0].split('-');
            let dateTodayStr = dateTodayCampos[2] + "/" + dateTodayCampos[1] + "/" + dateTodayCampos[0];

            if (utilSigo.isFechaMayor(date, dateToday)) {
                utilSigo.toastWarning("Aviso", "El campo " + texto + " no debe ser mayor a la fecha actual");
                document.getElementById(id).value = dateTodayStr;
                $("#" + id).focus();
                return false;
            } else if (utilSigo.isFechaMayor(datePast, date)) {
                utilSigo.toastWarning("Aviso", "El campo " + texto + " no debe ser menor a 5 años de la fecha actual");
                document.getElementById(id).value = dateTodayStr;
                $("#" + id).focus();
                return false;
            }
        }        
    }    
    return true;
}

utilSigo.findWords = function (text) {
    let msg = "La búsqueda no puede contener la(s) siguiente(s) palabra(s) : ";
    const lowerText = text.toLowerCase();

    const words = ["Connection", "oracle", "System", "Data", "SqlClient"];

    const foundWords = [];

    words.forEach(word => {
        // Convertir la palabra a minúsculas para hacer una búsqueda sin distinción de mayúsculas y minúsculas
        const lowerWord = word.toLowerCase();

        // Buscar la palabra en el texto
        if (lowerText.includes(lowerWord)) {
            foundWords.push(word);
            msg += " " + word;
        }
    });
    if (foundWords.length == 0) {
        msg = "";
    }

    return (msg);
}