'use strict';
var vpItemDestinatario = {};
(function () {
    this.urlController = urlLocalSigo + "THabilitante/ManPreviosAlerta/";
    this.RegEstado;
    this.init = (RegEstado, data) => {
        this.frm = $("#frmItemDestinatario");
        this.content = $("#divItemDestinatario");
        this.RegEstado = RegEstado;
        if (RegEstado == RegEstadoSigo.UPDATE) {
            this.initData(data);
            this.frm.find("#txtDestinatarioCorreo").attr("disabled", "disabled");
        }
        this.initEvent();
    }
    this.initData = (data) => {

        if (data.TIPO_FUNCIONARIO==2) {
            //$('#divsupuesto').removeAttr('hidden');
            $('#divEntidad').removeAttr('hidden');
        }
        var titulo = document.getElementById('h5Titulo');
        titulo.innerHTML = 'Editar';
        vpItemDestinatario.inicializarSupuestos(data.SUPUESTOS_DESTINATARIO);       
        this.frm.find("#cbDestTipoFuncionario").val(data.TIPO_FUNCIONARIO);
        this.frm.find("#cbEntidad").val(data.COD_ENTIDAD);
        this.frm.find("#hdCodDestinatario").val(data.COD_DESTINATARIO);
        this.frm.find("#lbDestinatarioPersona").val(data.DESCRIPCION);
        this.frm.find("#hdDestinatarioCod_Persona").val(data.COD_PERSONA);
        this.frm.find("#txtDestinatarioCargo").val(data.CARGO);
        this.frm.find("#txtDestinatarioCorreo").val(data.CORREO);
        this.frm.find("#txtDestinatarioDocumento").val(data.DOCUMENTO);
        this.frm.find("#txtObservacion").val(data.OBSERVACION);
        var fechaArray = data.FECHA_DOCUMENTO.split("/");
        
        var fecha = "";
        if (fechaArray.length > 0)
            fecha = fechaArray[2] + "-" + fechaArray[1] + "-" + (fechaArray[0].length == 1 ? "0" + fechaArray[0].toString() : fechaArray[0].toString());
        this.frm.find("#txtDestinatarioFechaDocumento").val(fecha);
        
        this.frm.find("#txtDestinatarioOficina").val(data.OFICINA);
        this.frm.find("#cbDestinatarioEstado").val(data.ACTIVO);
    }
    this.initEvent = () => {
        this.configValidateForm();
        this.content.find("#btnGuardar").click(function () {
            this.save();
        }.bind(this));

    }
    this.configValidateForm = () => {
        var objValida = {};
        this.frm.validate(utilSigo.fnValidate(objValida));

    }
    this.validAdditional = () => {

        if (utilSigo.ValidaTexto("hdDestinatarioCod_Persona", "Ingrese Funcionario") == false) return false;

        //if (vpItemDestinatario.obtenerSupuestos() == "" && $('#cbDestTipoFuncionario').val()==2) {
        //    utilSigo.toastWarning('Supuestos', 'Debe Seleccionar Supuesto');
        //    return false;
        //}

        return true;
    }
    this.save = () => {
        if (this.frm.valid()) {
            if (this.validAdditional()) {
                let datos = {};

                //var supuestos = vpItemDestinatario.obtenerSupuestos();                

                let ListDESTINATARIO = [{
                    COD_DESTINATARIO: $("#hdCodDestinatario").val(),
                    DESCRIPCION: $("#txtDestinatarioDescripcion").val(),
                    CORREO: $("#txtDestinatarioCorreo").val(),
                    COD_PERSONA: $("#hdDestinatarioCod_Persona").val(),
                    CARGO: $("#txtDestinatarioCargo").val(),
                    DOCUMENTO: $("#txtDestinatarioDocumento").val(),
                    FECHA_DOCUMENTO: $("#txtDestinatarioFechaDocumento").val(),
                    OFICINA: $("#txtDestinatarioOficina").val(),
                    ACTIVO: $("#cbDestinatarioEstado").val(),
                    OBSERVACION: $("#txtObservacion").val(),
                    SUPUESTOS_DESTINATARIO: vpItemDestinatario.obtenerSupuestos(),
                    TIPO_FUNCIONARIO: $("#cbDestTipoFuncionario").val(),
                    COD_ENTIDAD: $("#cbEntidad").val()
                }];



                datos.ListDESTINATARIO = ListDESTINATARIO;
                datos.RegEstado = this.RegEstado;


                $.ajax({
                    url: this.urlController + "/saveDestinatario",
                    type: 'POST',
                    data: JSON.stringify(datos),
                    contentType: 'application/json;charset=utf-8',
                    dataType: 'json',
                    beforeSend: utilSigo.beforeSendAjax,
                    complete: utilSigo.completeAjax,
                    error: utilSigo.errorAjax,
                    success: function (data) {
                        if (data.success) {
                            this.afterSave(datos);
                            this.finallySave();
                            utilSigo.toastSuccess("Aviso", data.msj);
                        }
                        else utilSigo.toastWarning("Aviso", data.msj);
                    }.bind(this)
                });


            }
        }
        else
            this.frm.validate().focusInvalid();
    }
    this.afterSave = (data) => {

    }
    this.finallySave = () => {
        if (this.RegEstado == RegEstadoSigo.NEW)
            this.frm[0].reset();
        else
            this.close();
    }
    this.close = () => {
        this.content.closest(".modal").modal("hide");
    }

    this.fnBuscarPersona = (_dom, _tipoPersonaSIGOsfc) => {
        var url = urlLocalSigo + "General/Controles/_BuscarPersonaGeneral";
        var option = { url: url, type: 'GET', datos: { asBusGrupo: "PERSONA", asCodPTipo: _tipoPersonaSIGOsfc, asTipoPersona: "N" }, divId: "mdlBuscarPersona" };
        utilSigo.fnOpenModal(option, function () {
            _bPerGen.fnAsignarDatos = function (obj) {
                if (obj != null && obj != "") {
                    var data = _bPerGen.dtBuscarPerona.row($(obj).parents('tr')).data();
                    switch (_dom) {
                        case "FUNCIONARIO": vpItemDestinatario.fnSetPersonaCompleto(_dom, data["COD_PERSONA"]); break;
                    }
                    utilSigo.fnCloseModal("mdlBuscarPersona");
                }
            }
            _bPerGen.fnInit();
        });
    }
    this.fnSetPersonaCompleto = (_dom, codPersona) => {
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
                    switch (_dom) {
                        case "FUNCIONARIO":
                            vpItemDestinatario.frm.find("#txtDestinatarioCargo").val(data.data["CARGO"]);
                            vpItemDestinatario.frm.find("#hdDestinatarioCod_Persona").val(data.data["COD_PERSONA"]);
                            vpItemDestinatario.frm.find("#lbDestinatarioPersona").val(data.data["APELLIDOS_NOMBRES"]);
                            if (data.data["ListCorreo"].length > 0) {
                                vpItemDestinatario.frm.find("#txtDestinatarioCorreo").val(data.data["ListCorreo"][0]["CORREO"]);
                            }
                            break;
                    }
                } else {
                    utilSigo.toastError("Error", "No se pudo consultar los datos de la persona");
                    console.log(data.msj);
                    return false;
                }
            }
        });
    }
    this.seleccionar = (COD_SUPUESTO) => {

        var tbodyseleccionar = document.getElementById('tbodySeleccionarSupuesto');
        var tbodyseleccionado = document.getElementById('tbodySupuestoSeleccionado');
        var fila = "";
        for (var i = 0; i < tbodyseleccionar.rows.length; i++) {
            if (tbodyseleccionar.rows[i].id == COD_SUPUESTO) {
                fila = "<tr id='" + COD_SUPUESTO + "'>" +
                    " <td style='width:5%;' class='text-center'> " +
                    "<i class='fa fa-arrow-circle-left fa-2x c-pointer' role='button' aria-hidden='true' onclick ='vpItemDestinatario.eliminarseleccion(" + COD_SUPUESTO + ")'></i>" +
                    "</td>" +
                    "<td style='width:95%;'>" + tbodyseleccionar.rows[i].cells[0].innerHTML + "</td></tr>";
                tbodyseleccionado.innerHTML += fila;
                $(tbodyseleccionar.rows[i]).remove();
            }
        }
    }
    this.eliminarseleccion = (COD_SUPUESTO) => {

        var tbodyseleccionar = document.getElementById('tbodySeleccionarSupuesto');
        var tbodyseleccionado = document.getElementById('tbodySupuestoSeleccionado');
        var fila = "";
        for (var i = 0; i < tbodyseleccionado.rows.length; i++) {
            if (tbodyseleccionado.rows[i].id == COD_SUPUESTO) {
                fila = "<tr id='" + COD_SUPUESTO + "'>" +
                    "<td style='width:95%;'>" + tbodyseleccionado.rows[i].cells[1].innerHTML + "</td>" +
                    " <td style='width:5%;' class='text-center'> " +
                    "<i class='fa fa-arrow-circle-right fa-2x c-pointer' role='button' aria-hidden='true' onclick ='vpItemDestinatario.seleccionar(" + COD_SUPUESTO + ")'></i>" +
                    "</td></tr>";
                tbodyseleccionar.innerHTML += fila;
                $(tbodyseleccionado.rows[i]).remove();
            }
        }
    }

    this.limpiarSupuesto = () => {
        
        var tbodyseleccionar = document.getElementById('tbodySeleccionarSupuesto');
        var tbodyseleccionado = document.getElementById('tbodySupuestoSeleccionado');
        var fila = "";
        for (var i = 0; i < tbodyseleccionado.rows.length; i++) {

            fila = "<tr id='" + tbodyseleccionado.firstElementChild.id+ "'>" +
                "<td style='width:95%;'>" + tbodyseleccionado.rows[i].cells[1].innerHTML + "</td>" +
                " <td style='width:5%;' class='text-center'> " +
                "<i class='fa fa-arrow-circle-right fa-2x c-pointer' role='button' aria-hidden='true' onclick ='vpItemDestinatario.seleccionar(" + tbodyseleccionado.firstElementChild.id + ")'></i>" +
                "</td></tr>";
            tbodyseleccionar.innerHTML += fila;
            $(tbodyseleccionado.rows[i]).remove();
            i--;       
        }
    }

    this.obtenerSupuestos = () => {
        var supuestos = "";
        var tbodyseleccionado = document.getElementById('tbodySupuestoSeleccionado');
        for (var i = 0; i < tbodyseleccionado.rows.length; i++) {
            supuestos += tbodyseleccionado.rows[i].id + "|";
        }
        supuestos = supuestos.length > 0 ? supuestos.substring(0, supuestos.length - 1) : "";
        return supuestos;
    }

    this.inicializarSupuestos = (supuestos) => {        
        var supuesto = supuestos.length > 0 ? supuestos.split('|') : "";
        for (var i = 0; i < supuesto.length; i++) {
            vpItemDestinatario.seleccionar(supuesto[i]);
        }
    }

}).apply(vpItemDestinatario);

$(document).ready(function () {

    $("#frmItemDestinatario input[type=text]").keyup(function () {
        this.value = this.value.toUpperCase();
    });

    $('#cbDestTipoFuncionario').change(function () {       
        vpItemDestinatario.RegEstado;
        if ($('#cbDestTipoFuncionario').val() == 2) {
            //$('#divsupuesto').removeAttr('hidden');
            $('#divEntidad').removeAttr('hidden');            
        } else {
            $('#divsupuesto').attr('hidden', 'hidden');
            $('#divEntidad').attr('hidden', 'hidden');
            if (vpItemDestinatario.RegEstado == 1) {
                vpItemDestinatario.limpiarSupuesto();
            }            
        }
    });

});