"use strict";
var vpTHabilitante = {};
vpTHabilitante.direccionar = function (codigoNuevo, descripcionNuevo) {
 
     var tipoFormulario = vpTHabilitante.frmHabilitante.find("#busFormulario").val();

    console.log(descripcionNuevo);
    switch (tipoFormulario) {
        case "POA":
        case "DEMA":
        case "PMFI":                
            window.location = urlLocalSigo + "THabilitante/ManPOA/AddEdit?" +
                "codigo=" + codigoNuevo +
                "&descripcion=" + descripcionNuevo +
                "&tipoFrmulario=" + vpTHabilitante.frmHabilitante.find("#hdfTipoFormulario").val() +
                "&nuevo=1";
            break;
        case "CERTIFICADO_PLANTA":
            window.location = urlLocalSigo + "THabilitante/ManCertificadoPlanta/AddEdit?" +
                "codigo=" + codigoNuevo +
                "&descripcion=" + descripcionNuevo +
                "&tipoFrmulario=" + vpTHabilitante.frmHabilitante.find("#hdfTipoFormulario").val() +
                "&nuevo=1";
            break;
        default: break;
    } 
}
vpTHabilitante.agregarTHabilitantePM = function (obj) {
    var $tr = $(obj).closest('tr');
    var valCodigo = $tr.find(".hdCodigo").val();
    var columnasTr = $tr.find('td');
    var valDescripcion = $tr.find('.hdDesc').text().trim();
    var valModalidad = columnasTr.eq(1).text();
    var valTitular = columnasTr.eq(3).text();
    var valRegistro = columnasTr.eq(4).text();
    var valDlinea = $tr.find(".hdDl").val();    
    ManPM.agregarThabilitante(valCodigo, valDescripcion, valModalidad, valTitular, valRegistro, valDlinea);
    
}
vpTHabilitante.buscarTHabilitantePMGF = function () {
    var valorBuscar = vpTHabilitante.frmHabilitante.find("#txtValor").val().trim();
    var valTipoFormulario = vpTHabilitante.frmHabilitante.find("#hdfTipoFormulario").val();
    var valtOpcion = vpTHabilitante.frmHabilitante.find("#ddlManNueCondicion").val();    
    var url = urlLocalSigo + "THabilitante/ManPlanManejoForestal/buscarTHabilitante?hdfFormulario=" + valTipoFormulario + "&busCriterio=" + valtOpcion + "&busValor=" + valorBuscar;
    vpTHabilitante.dtFuncionario.ajax.url(url).load(function (data) {
        if (data.s == false) {
            utilSigo.toastError("Error", "Sucedio un Error al cargar registros en la tabla, Comuniquese con el Administrador");
            console.log(data.e);
        }
    });
}
vpTHabilitante.buscarCertifPlanta = function () {
    var valorBuscar = vpTHabilitante.frmHabilitante.find("#txtValor").val().trim();
    var valTipoFormulario = vpTHabilitante.frmHabilitante.find("#hdfTipoFormulario").val();
    var valtOpcion = vpTHabilitante.frmHabilitante.find("#ddlManNueCondicion").val();
    var url = urlLocalSigo + "THabilitante/ManPlanManejoForestal/buscarTHabilitante?hdfFormulario=" + valTipoFormulario + "&busCriterio=" + valtOpcion + "&busValor=" + valorBuscar;
    vpTHabilitante.dtFuncionario.ajax.url(url).load(function (data) {
        if (data.s == false) {
            utilSigo.toastError("Error", "Sucedio un Error al cargar registros en la tabla, Comuniquese con el Administrador");
            console.log(data.e);
        }
    });
}
vpTHabilitante.buscarThabilitante = function () {
    var valorBuscar = vpTHabilitante.frmHabilitante.find("#txtValor").val().trim();
    if (valorBuscar == "") {
        utilSigo.toastWarning("Aviso", "Ingrese Valor a Buscar");
        return false;
    }
    if (valorBuscar.length < 3) {
        utilSigo.toastWarning("Aviso", "Ingrese mayor a dos caracteres");
        return false;
    }
    var datos = {
        hdfFormulario: vpTHabilitante.frmHabilitante.find("#hdfTipoFormulario").val(),
        busCriterio: vpTHabilitante.frmHabilitante.find("#ddlManNueCondicion").val(),
        busValor: valorBuscar
    };
    $.ajax({
        url: urlLocalSigo + "THabilitante/Controles/buscarTHabilitante",
        type: 'POST',
        data: JSON.stringify(datos),
        dataType: 'json',
        contentType: 'application/json; charset=utf-8',
        success: function (data) {
            utilSigo.unblockUIElement(vpTHabilitante.tbHabilitante);
            vpTHabilitante.dtFuncionario.fnClearTable();
            var codigoNuevo = "";
            var descripcionNuevo = "";
            if (data.success) {
                //hay que mejorar la consulta para obtener solo los datos requeridos
                for (var i = 0; i < data.r.length; i++) {
                    codigoNuevo = data.r[i].CODIGO;
                    descripcionNuevo = data.r[i].PARAMETRO01 + "|" +
                        data.r[i].NUMERO + "|" +
                        data.r[i].PARAMETRO02.replace(/[|]/g, ";") + "|" +
                        data.r[i].PARAMETRO03 + "|" +
                        data.r[i].PARAMETRO04 + "|" +
                        data.r[i].PARAMETRO05 + "|" +
                        data.r[i].PARAMETRO06 + "|" +
                        data.r[i].PARAMETRO11;

              

                    vpTHabilitante.dtFuncionario.fnAddData([
                        '<div>' + (i + 1) + '</div>',
                        data.r[i].PARAMETRO01,
                        data.r[i].NUMERO,
                        data.r[i].PARAMETRO02,
                        "<i class='fa fa-lg fa-check' style='cursor:pointer;' onclick='vpTHabilitante.direccionar(\"" + encodeURIComponent(codigoNuevo) + "\",\"" + encodeURIComponent(descripcionNuevo) + "\");'></i>"
                    ]);
                }
            }
            else {
                utilSigo.toastInfo("Aviso", data.msj);
            }
        },
        beforeSend: function () {
            utilSigo.blockUIElement(vpTHabilitante.tbHabilitante);
        },
        error: function (jqXHR, error, errorThrown) {
            utilSigo.unblockUIElement(vpTHabilitante.tbHabilitante);
            utilSigo.toastError("Error", "Sucedio un Error Inesperado, Comuniquese con el Administrador");
            console.log(jqXHR.responseText);
        }
    });
}
vpTHabilitante.iniciarEventos = function () {
    vpTHabilitante.frmHabilitante.find("#btnFuncionarioBuscar").click(function () {
        var valOpcion = vpTHabilitante.frmHabilitante.find("#hdfTipoFormulario").val();
        console.log(valOpcion);
        switch (valOpcion) {
            case "POA":
            case "DEMA":
            case "PMFI":
            case "CERTIFICADO_PLANTA":
                vpTHabilitante.buscarThabilitante(); break;
            case "TITULO_HABILITANTE": vpTHabilitante.buscarTHabilitantePMGF(); break;
        }  
    });
}
vpTHabilitante.closeModal = function () {
    var divModal = vpTHabilitante.frmHabilitante.find("#idModal").val();
    $("#" + divModal).modal('hide');
    $("#" + divModal).html('');
}
vpTHabilitante.iniciarTabla = function (opcion) {
    vpTHabilitante.tbHabilitante = vpTHabilitante.frmHabilitante.find("#tbHabilitante");
    switch (opcion) {
        case "POA": 
        case "DEMA":
        case "PMFI":
        case "CERTIFICADO_PLANTA":
                    vpTHabilitante.dtFuncionario = vpTHabilitante.tbHabilitante.dataTable({
                        "bServerSide": false,
                        "bAutoWidth": false,
                        "bProcessing": true,
                        "bJQueryUI": false,
                        "bRetrieve": true,
                        //"sPaginationType": "bootstrap",
                        "bFilter": false,
                        "aaSorting": [],
                        "bPaginate": true,
                        "bInfo": false,
                        "bLengthChange": false,
                        "pageLength": 20,
                        // "scrollX": true,
                        "oLanguage": {
                            "sProcessing": '<i class="fa fa-coffee"></i>&nbsp;Cargando Datos...',
                            "sEmptyTable": "No existen datos registrados",
                            "sInfo": "Mostrando desde _START_ hasta _END_ de _TOTAL_ registros"
                        }
                    });
                    break;
        case "TITULO_HABILITANTE":           
            vpTHabilitante.dtFuncionario = vpTHabilitante.tbHabilitante.DataTable({
                "bServerSide": false,                
                "deferLoading": 0,
                "bAutoWidth": false,
                "bProcessing": true,
                "bJQueryUI": false,
                //"bRetrieve": true,
                "bFilter": false,
                "aaSorting": [],
                "bPaginate": true,
                "bInfo": false,
                "bLengthChange": false,
                "scrollY":"50vh",
                "scrollCollapse":true,
                "pageLength": initSigo.pageLength,
                "oLanguage": initSigo.oLanguage,
                "columns":
                    [
                         
                        { "data": "ind", "autoWidth": true },                        
                        { "data": "mod", "autoWidth": true },
                        {
                            "autoWidth": true, "bSortable": false, "data": "desc",
                            "mRender": function (data, type, row) {
                                var cell = '<input type="hidden" class="hdDl" value="' + row.dl + '" /><input type="hidden" class="hdCodigo" value="' + row.cod + '" /><a class="hdDesc" style="cursor:pointer;color:blue;" onclick="vpTHabilitante.agregarTHabilitantePM(this);">' + data + '</a>';
                                return cell;
                            }
                        },                       
                        { "data": "pt", "autoWidth": true },
                        { "data": "codOr", "autoWidth": true }                        

                    ]    
            });
            break;
    }
}
$(document).ready(function () {
    $('[data-toggle="tooltip"]').tooltip();
    vpTHabilitante.frmHabilitante = $("#frmHabilitante");
    vpTHabilitante.iniciarTabla(vpTHabilitante.frmHabilitante.find("#hdfTipoFormulario").val());
    vpTHabilitante.iniciarEventos();
    vpTHabilitante.frmHabilitante.find("#txtValor").keypress(function (e) {
        var code = e.which;
        if (code == 13) {
            var valOpcion = vpTHabilitante.frmHabilitante.find("#hdfTipoFormulario").val();
            switch (valOpcion) {
                case "POA":
                case "DEMA":
                case "PMFI":
                case "CERTIFICADO_PLANTA":
                    vpTHabilitante.buscarThabilitante(); break;
                case "TITULO_HABILITANTE": vpTHabilitante.buscarTHabilitantePMGF(); break;
                //case "CERTIFICADO_PLANTA": vpTHabilitante.buscarCertifPlanta(); break;
            }           
            return false;
        }
    });
});