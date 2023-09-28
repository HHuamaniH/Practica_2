"use strict";
var controles_TH = {};

controles_TH.editarThabilitante = function (obj) {
    var fila = $(obj).closest('tr');
    var codThabilitante = fila.find("#hdCodThabilitante").val();
    var url = urlLocalSigo + "THabilitante/ManTHabilitante/Index";
    document.location = url + "?codTH=" + codThabilitante + "&dtoMod=" + "";
};

controles_TH.editarCertificadoPlanta = function (obj) {
    var fila = $(obj).closest('tr');
    var codCertificacionPlanta = fila.find("#hdCodCertifPlanta").val();
    var url = urlLocalSigo + "THabilitante/ManCertificadoPlanta/AddEdit";
    document.location = url + "?codCertificacionPlanta=" + codCertificacionPlanta;
};

controles_TH.editarPlanManejoGeneral = function (obj) {
    var fila = $(obj).closest('tr');
    var codThabilitante = fila.find("#hdCodPMF").val();
    var valEsPMFI = $("#contenedorGrilla").find("#hdEsPMFI").val();
    window.location = urlLocalSigo + "THabilitante/ManPlanManejoForestal/AddEdit?cod_PM=" + codThabilitante + "&opt=" + valEsPMFI;
};

controles_TH.eliminarPOA = function (obj) { };

controles_TH.editarPOA = function (obj) {
    var fila = $(obj).closest('tr');
    var CodigoDato = fila.find(".hdCodigoDato").val();
    var CodigoComplementario = fila.find(".hdCodigoComplementario").val();

    window.location = urlLocalSigo + "THabilitante/ManPOA/AddEdit" +
        "?codigo=" + encodeURIComponent(CodigoDato) +
        "&descripcion=" + encodeURIComponent(CodigoComplementario) +
        "&nuevo=0" +
        "&tipoFrmulario=" + controles_TH.frmManGrilla.find("#tipoFrmulario").val();
};

controles_TH.nuevoPlan = function (tipoPlan, indice, obj) {
    console.log('nuevo');
    var fila = $(obj).closest('tr');
    var CodigoDato = fila.find(".hdCodigoDato1").val();
    var CodigoComplementario = fila.find(".hdCodigoComplementario1").val();

    CodigoComplementario = CodigoComplementario.replace("hdftipoMuestra", tipoPlan);
    //console.log();
    window.location = urlLocalSigo + "THabilitante/ManPOA/AddEdit" +
        "?codigo=" + encodeURIComponent(CodigoDato) +
        "&descripcion=" + encodeURIComponent(CodigoComplementario) +
        "&nuevo=2" +
        "&tipoFrmulario=" + controles_TH.frmManGrilla.find("#tipoFrmulario").val();
};

controles_TH.newButtonPoa = function (id, PARAMETRO04, PARAMETRO08) {
    var opcionContext = "";

    if ((PARAMETRO08 == "PN" || PARAMETRO08 == "PMFI")
        && PARAMETRO04 != "0000008"
        && PARAMETRO04 != "0000009"
        && PARAMETRO04 != "0000018"
        && PARAMETRO04 != "0000022") {
        opcionContext = "" +
            "<div id = 'TitularBoton" + id + "' style = 'width: 18px; float: left;'" +
            "onmouseover = \"utilSigo.BotonMenuShow('TitularBoton" + id + "', 'TitularMenu" + id + "','RD');\"" +
            "onmouseout = \"utilSigo.BotonMenuHide('TitularMenu" + id + "')\" >" +
            "<i style='cursor:pointer' class='fa fa-lg fa-file-o'></i>" +
            "<div id = 'TitularMenu" + id + "' class='BotonMenuDiv' style='width: 160px; top: 157px; left: 305.953px; display: none;'>" +
            "<p><a class='ImagenNoBordeCursor' onclick=\"controles_TH.nuevoPlan('PCN'," + id + ",this)\" href='#' >P.Complementario No Maderable</a></p>" +
            "<p><a class='ImagenNoBordeCursor' onclick=\"controles_TH.nuevoPlan('FI'," + id + ",this)\" href='#' >P.Complementario Fauna</a></p>" +
            "<p><a class='ImagenNoBordeCursor' onclick=\"controles_TH.nuevoPlan('MS'," + id + ",this)\" href='#' >Movilización de Saldo</a></p>" +
            "<p><a class='ImagenNoBordeCursor' onclick=\"controles_TH.nuevoPlan('R'," + id + ",this)\" href='#' >Reingreso</a></p>" +
            "<p><a class='ImagenNoBordeCursor' onclick=\"controles_TH.nuevoPlan('REFOR'," + id + ",this)\" href='#' >Reformulación</a></p>" +
            "<p><a class='ImagenNoBordeCursor' onclick=\"controles_TH.nuevoPlan('REAJU'," + id + ",this)\" href='#' >Reajuste</a></p>" +
            "</div>";
    }
    else if (PARAMETRO08 == "PC" &&
        (PARAMETRO04 == "0000008"
            || PARAMETRO04 == "0000009"
            || PARAMETRO04 == "0000018"
            || PARAMETRO04 == "0000022")) {
        opcionContext = "" +
            "<div id = 'TitularBoton" + id + "' style = 'width: 18px; float: left;'" +
            "onmouseover = \"utilSigo.BotonMenuShow('TitularBoton" + id + "', 'TitularMenu" + id + "','RD');\"" +
            "onmouseout = \"utilSigo.BotonMenuHide('TitularMenu" + id + "')\" >" +
            "<i style='cursor:pointer' class='fa fa-lg fa-file-o'></i>" +
            "<div id = 'TitularMenu" + id + "' class='BotonMenuDiv' style='width: 160px; top: 157px; left: 305.953px; display: none;'>" +
            "<p><a class='ImagenNoBordeCursor' onclick=\"controles_TH.nuevoPlan('MS'," + id + ",this)\" href='#' >Movilización de Saldo</a></p>" +
            "<p><a class='ImagenNoBordeCursor' onclick=\"controles_TH.nuevoPlan('R'," + id + ",this)\" href='#' >Reingreso</a></p>" +
            "<p><a class='ImagenNoBordeCursor' onclick=\"controles_TH.nuevoPlan('REFOR'," + id + ",this)\" href='#' >Reformulación</a></p>" +
            "<p><a class='ImagenNoBordeCursor' onclick=\"controles_TH.nuevoPlan('REAJU'," + id + ",this)\" href='#' >Reajuste</a></p>" +
            "</div>";
    }
    else if (PARAMETRO08 == "PMFI" && PARAMETRO04 == "0000008") {
        opcionContext = "" +
            "<div id = 'TitularBoton" + id + "' style = 'width: 18px; float: left;'" +
            "onmouseover = \"utilSigo.BotonMenuShow('TitularBoton" + id + "', 'TitularMenu" + id + "','RD');\"" +
            "onmouseout = \"utilSigo.BotonMenuHide('TitularMenu" + id + "')\" >" +
            "<i style='cursor:pointer' class='fa fa-lg fa-file-o'></i>" +
            "<div id = 'TitularMenu" + id + "' class='BotonMenuDiv' style='width: 160px; top: 157px; left: 305.953px; display: none;'>" +
            "<p><a class='ImagenNoBordeCursor' onclick=\"controles_TH.nuevoPlan('PC'," + id + ",this)\" href='#' >P.Complementario Maderable</a></p>" +
            "<p><a class='ImagenNoBordeCursor' onclick=\"controles_TH.nuevoPlan('MS'," + id + ",this)\" href='#' >Movilización de Saldo</a></p>" +
            "<p><a class='ImagenNoBordeCursor' onclick=\"controles_TH.nuevoPlan('REFOR'," + id + ",this)\" href='#' >Reformulación</a></p>" +
            "<p><a class='ImagenNoBordeCursor' onclick=\"controles_TH.nuevoPlan('REAJU'," + id + ",this)\" href='#' >Reajuste</a></p>" +
            "<p><a class='ImagenNoBordeCursor' onclick=\"controles_TH.nuevoPlan('R'," + id + ",this)\" href='#' >Reingreso</a></p>" +
            "</div>";
    }
    else if ((PARAMETRO08 == "PN" || PARAMETRO08 == "PMFI") &&
        (PARAMETRO04 == "0000008"
            || PARAMETRO04 == "0000009"
            || PARAMETRO04 == "0000018"
            || PARAMETRO04 == "0000022")) {
        opcionContext = "" +
            "<div id = 'TitularBoton" + id + "' style = 'width: 18px; float: left;'" +
            "onmouseover = \"utilSigo.BotonMenuShow('TitularBoton" + id + "', 'TitularMenu" + id + "','RD');\"" +
            "onmouseout = \"utilSigo.BotonMenuHide('TitularMenu" + id + "')\" >" +
            "<i style='cursor:pointer' class='fa fa-lg fa-file-o'></i>" +
            "<div id = 'TitularMenu" + id + "' class='BotonMenuDiv' style='width: 160px; top: 157px; left: 305.953px; display: none;'>" +
            "<p><a class='ImagenNoBordeCursor' onclick=\"controles_TH.nuevoPlan('PC'," + id + ",this)\" href='#' >P.Complementario Maderable</a></p>" +
            "<p><a class='ImagenNoBordeCursor' onclick=\"controles_TH.nuevoPlan('MS'," + id + ",this)\" href='#' >Movilización de Saldo</a></p>" +
            "<p><a class='ImagenNoBordeCursor' onclick=\"controles_TH.nuevoPlan('REFOR'," + id + ",this)\" href='#' >Reformulación</a></p>" +
            "<p><a class='ImagenNoBordeCursor' onclick=\"controles_TH.nuevoPlan('REAJU'," + id + ",this)\" href='#' >Reajuste</a></p>" +
            "</div>";
    }
    else if (PARAMETRO08 == "REFOR" || PARAMETRO08 == "REAJU") {
        opcionContext = "" +
            "<div id = 'TitularBoton" + id + "' style = 'width: 18px; float: left;'" +
            "onmouseover = \"utilSigo.BotonMenuShow('TitularBoton" + id + "', 'TitularMenu" + id + "','RD');\"" +
            "onmouseout = \"utilSigo.BotonMenuHide('TitularMenu" + id + "')\" >" +
            "<i style='cursor:pointer' class='fa fa-lg fa-file-o'></i>" +
            "<div id = 'TitularMenu" + id + "' class='BotonMenuDiv' style='width: 160px; top: 157px; left: 305.953px; display: none;'>" +
            "<p><a class='ImagenNoBordeCursor' onclick=\"controles_TH.nuevoPlan('MS'," + id + ",this)\" href='#' >Movilización de Saldo</a></p>" +
            "<p><a class='ImagenNoBordeCursor' onclick=\"controles_TH.nuevoPlan('R'," + id + ",this)\" href='#' >Reingreso</a></p>" +
            "<p><a class='ImagenNoBordeCursor' onclick=\"controles_TH.nuevoPlan('PCN'," + id + ",this)\" href='#' >P.Complementario No Maderable</a></p>" +
            "<p><a class='ImagenNoBordeCursor' onclick=\"controles_TH.nuevoPlan('REFOR'," + id + ",this)\" href='#' >Reformulación</a></p>" +
            "<p><a class='ImagenNoBordeCursor' onclick=\"controles_TH.nuevoPlan('REAJU'," + id + ",this)\" href='#' >Reajuste</a></p>" +
            "</div>";
    }
    else if (PARAMETRO08 == "DEMA") {
        opcionContext = "" +
            "<div id = 'TitularBoton" + id + "' style = 'width: 18px; float: left;'" +
            "onmouseover = \"utilSigo.BotonMenuShow('TitularBoton" + id + "', 'TitularMenu" + id + "','RD');\"" +
            "onmouseout = \"utilSigo.BotonMenuHide('TitularMenu" + id + "')\" >" +
            "<i style='cursor:pointer' class='fa fa-lg fa-file-o'></i>" +
            "<div id = 'TitularMenu" + id + "' class='BotonMenuDiv' style='width: 160px; top: 157px; left: 305.953px; display: none;'>" +
            "<p><a class='ImagenNoBordeCursor' onclick=\"controles_TH.nuevoPlan('REFOR'," + id + ",this)\" href='#' >Reformulación</a></p>" +
            "</div>";
    }
    else if (PARAMETRO08 === "R") {
        opcionContext = "" +
            "<div id = 'TitularBoton" + id + "' style = 'width: 18px; float: left;'" +
            "onmouseover = \"utilSigo.BotonMenuShow('TitularBoton" + id + "', 'TitularMenu" + id + "','RD');\"" +
            "onmouseout = \"utilSigo.BotonMenuHide('TitularMenu" + id + "')\" >" +
            "<i style='cursor:pointer' class='fa fa-lg fa-file-o'></i>" +
            "<div id = 'TitularMenu" + id + "' class='BotonMenuDiv' style='width: 160px; top: 157px; left: 305.953px; display: none;'>" +
            "<p><a class='ImagenNoBordeCursor' onclick=\"controles_TH.nuevoPlan('MS'," + id + ",this)\" href='#' >Movilización de Saldo</a></p>" +
            "<p><a class='ImagenNoBordeCursor' onclick=\"controles_TH.nuevoPlan('REFOR'," + id + ",this)\" href='#' >Reformulación</a></p>" +
            "<p><a class='ImagenNoBordeCursor' onclick=\"controles_TH.nuevoPlan('REAJU'," + id + ",this)\" href='#' >Reajuste</a></p>" +
            "</div>";
    }

    return opcionContext;
}

controles_TH.listarBusqueda = function () {
    var datos = {
        formulario: controles_TH.frmManGrilla.find("#tipoFrmulario").val(),
        criterio: controles_TH.frmManGrilla.find("#busCriterio").val(),
        valor: controles_TH.frmManGrilla.find("#txtValor").val().trim()
    };
    $.ajax({
        url: controles_TH.frmManGrilla.attr("action"),
        type: 'GET',
        data: datos,
        dataType: 'json',
        contentType: 'application/json; charset=utf-8',
        success: function (resultado) {
            if (resultado.success) {
                var data = resultado.data;
                controles_TH.dtGrillaGeneral.clear().draw();
                //console.log("dd");

                var i = 0;

                switch (datos.formulario.trim()) {
                    case "TITULO_HABILITANTE":
                        var trsAdd = [];
                        for (i = 0; i < data.length; i++) {
                            var tr = ['<input type="hidden" id="hdCodThabilitante" value="' +
                                data[i][0] + '" /><i class="fa fa-lg fa-pencil-square-o" style="cursor:pointer;" onclick="controles_TH.editarThabilitante(this);"></i>',
                            (i + 1), data[i][1], data[i][2], data[i][3], data[i][4], data[i][5], data[i][6],
                            data[i][7], data[i][8], data[i][9]];
                            trsAdd.push(tr);
                            console.log(4);
                        }
                        controles_TH.dtGrillaGeneral.rows.add(trsAdd).draw();
                        break;
                    case "CERTIFICADO_PLANTA":
                        var trsAdd = [];
                        for (i = 0; i < data.length; i++) {
                            var tr = ['<input type="hidden" id="hdCodCertifPlanta" value="' +
                                data[i][0] + '" /><i class="fa fa-lg fa-pencil-square-o" style="cursor:pointer;" onclick="controles_TH.editarCertificadoPlanta(this);"></i>',
                            (i + 1), data[i][1], data[i][2], data[i][3], data[i][4], data[i][5], data[i][6],
                            data[i][7]];
                            trsAdd.push(tr);
                        }
                        controles_TH.dtGrillaGeneral.rows.add(trsAdd).draw();
                        break;
                    case "PLAN_GENERAL_MANEJO_FORESTAL":
                    case "PLAN_MANEJO_FORESTAL_INTERMEDIO":
                        var trsAdd = [];
                        for (i = 0; i < data.length; i++) {
                            var tr = ['<input type="hidden" id="hdCodPMF" value="' + data[i][0] + '" /><i class="fa fa-lg fa-pencil-square-o" style="cursor:pointer;" onclick="controles_TH.editarPlanManejoGeneral(this);"></i>',
                            (i + 1), data[i][1], data[i][2], data[i][3], data[i][4]];
                            trsAdd.push(tr);
                        }
                        controles_TH.dtGrillaGeneral.rows.add(trsAdd).draw();
                        break;
                    case "POA":
                        var trsAdd = [];
                        for (i = 0; i < data.length; i++) {
                            var hdCodigo = data[i][3];
                            var hdCodigoComplementario = data[i][11] + "|" + data[i][12] + "|" +
                                data[i][10] + "|" + data[i][6] + "|" +
                                data[i][8].replace(/[|]/g, ";") + "|" + data[i][7];


                            //Para multiples opciones
                            var hdCodigo1 = data[i][11];
                            var hdCodigoComplementario1 = data[i][12] +
                                "|hdftipoMuestra|" +
                                data[i][9] + "|" +
                                data[i][6] + "|" +
                                data[i][8].replace(/[|]/g, ";") + "|" +
                                data[i][7] + "|" +
                                data[i][13] + "|" +
                                data[i][3]
                                ;


                            trsAdd.push([
                                '<input type="hidden" class="hdCodigoDato" value="' + hdCodigo + '" />' +
                                '<input type="hidden" class="hdCodigoComplementario" value="' + hdCodigoComplementario + '" />' +
                                '<input type="hidden" class="hdCodigoDato1" value="' + hdCodigo1 + '" />' +
                                '<input type="hidden" class="hdCodigoComplementario1" value="' + hdCodigoComplementario1 + '" />' +
                                '<i class="fa fa-lg fa-pencil-square-o" data-toggle="tooltip" style="cursor:pointer;" title="Editar"  onclick="controles_TH.editarPOA(this);"></i>',
                                controles_TH.newButtonPoa((i + 1), data[i][9], data[i][10]),
                                (i + 1), data[i][2], data[i][3], data[i][4], data[i][5], data[i][6], data[i][7], data[i][8]]);



                        }
                        controles_TH.dtGrillaGeneral.rows.add(trsAdd).draw();
                        break;
                    case "DEMA":
                        var trsAdd = [];
                        for (i = 0; i < data.length; i++) {

                            var hdCodigo = data[i][3];
                            var hdCodigoComplementario = data[i][11] + "|" + data[i][12] + "|" +
                                data[i][10] + "|" + data[i][6] + "|" +
                                data[i][8].replace(/[|]/g, ";") + "|" + data[i][7];

                            //Para multiples opciones
                            var hdCodigo1 = data[i][11];
                            var hdCodigoComplementario1 = data[i][12] +
                                "|hdftipoMuestra|" +
                                data[i][9] + "|" +
                                data[i][6] + "|" +
                                data[i][8].replace(/[|]/g, ";") + "|" +
                                data[i][7] + "|" +
                                data[i][13] + "|" +
                                data[i][3]
                                ;

                            trsAdd.push([
                                '<input type="hidden" class="hdCodigoDato" value="' + hdCodigo + '" />' +
                                '<input type="hidden" class="hdCodigoComplementario" value="' + hdCodigoComplementario + '" />' +
                                '<input type="hidden" class="hdCodigoDato1" value="' + hdCodigo1 + '" />' +
                                '<input type="hidden" class="hdCodigoComplementario1" value="' + hdCodigoComplementario1 + '" />' +
                                '<i class="fa fa-lg fa-pencil-square-o" data-toggle="tooltip" style="cursor:pointer;" title="Editar"  onclick="controles_TH.editarPOA(this);"></i>',
                                controles_TH.newButtonPoa((i + 1), data[i][9], data[i][10]),
                                (i + 1), data[i][2], data[i][4], data[i][6], data[i][7], data[i][8]
                            ]);

                        }

                        controles_TH.dtGrillaGeneral.rows.add(trsAdd).draw();

                        break;
                    case "PMFI":
                        var trsAddPMFI = [];

                        $.each(data, function (index, value) {
                            var vacio = value[0];
                            var vacio1 = value[1];
                            var FECHA = value[2];
                            var POA = value[3];
                            var ARESOLUCION_NUM = value[4];
                            var MODALIDAD = value[5];
                            var TITULAR = value[6];
                            var NUM_THABILITANTE = value[7];
                            var COD_MTIPO = value[8];
                            var ESTADO_ORIGEN = value[9];
                            var COD_THABILITANTE = value[10];
                            var NUMERO = value[11];
                            var INDICADOR = value[12];


                            var hdCodigo = FECHA;
                            var hdCodigoComplementario = COD_THABILITANTE + "|" + NUMERO + "|" +
                                ESTADO_ORIGEN + "|" + MODALIDAD + "|" +
                                NUM_THABILITANTE.replace(/[|]/g, ";") + "|" + TITULAR;


                            //Para multiples opciones
                            var hdCodigo1 = COD_THABILITANTE;
                            var hdCodigoComplementario1 = NUMERO +
                                "|hdftipoMuestra|" +
                                COD_MTIPO + "|" +
                                MODALIDAD + "|" +
                                NUM_THABILITANTE.replace(/[|]/g, ";") + "|" +
                                TITULAR + "|" +
                                INDICADOR + "|" +
                                FECHA;

                            trsAddPMFI.push([
                                '<input type="hidden" class="hdCodigoDato" value="' + hdCodigo + '" />' +
                                '<input type="hidden" class="hdCodigoComplementario" value="' + hdCodigoComplementario + '" />' +
                                '<input type="hidden" class="hdCodigoDato1" value="' + hdCodigo1 + '" />' +
                                '<input type="hidden" class="hdCodigoComplementario1" value="' + hdCodigoComplementario1 + '" />' +
                                '<i class="fa fa-lg fa-pencil-square-o" data-toggle="tooltip" style="cursor:pointer;" title="Editar"  onclick="controles_TH.editarPOA(this);"></i>',
                                controles_TH.newButtonPoa(index + 1, COD_MTIPO, ESTADO_ORIGEN), index + 1,
                                FECHA,
                                POA,
                                ARESOLUCION_NUM,
                                MODALIDAD,
                                TITULAR,
                                NUM_THABILITANTE
                            ]);
                        });
                        controles_TH.dtGrillaGeneral.rows.add(trsAddPMFI).draw();

                        break;
                    default:
                        controles_TH.dtGrillaGeneral.fnAddData("");
                        break;
                }
                utilSigo.unblockUIElement(controles_TH.tbGrillaGeneral);
            }
            else {
                utilSigo.toastError("Aviso", resultado.msj);
                console.log(resultado.data);
            }

        },
        beforeSend: function () {
            utilSigo.blockUIElement(controles_TH.tbGrillaGeneral);
        },
        error: function (jqXHR, error, errorThrown) {
            utilSigo.unblockUIElement($("#tbGrillaGeneral"));
            utilSigo.toastError("Error", "Sucedio un Error Inesperado, Comuniquese con el Administrador");
            console.log(jqXHR.responseText);
        }
    });
};

controles_TH.realizarBusqueda = function () {
    var valorCboOpciones = controles_TH.frmManGrilla.find("#cboOpciones").val();
    var valorBusqueda = controles_TH.frmManGrilla.find("#txtValor").val().trim();

    if (valorBusqueda === "") {
        utilSigo.toastWarning("Aviso", "Ingrese Valor a Buscar");
        return false;
    }
    else {
        var cantCarateres = valorBusqueda.length;
        if (cantCarateres < 3) {
            utilSigo.toastWarning("Aviso", "Longitud del criterio de busqueda debe ser mayor a dos caracteres");
            return false;
        }
        controles_TH.frmManGrilla.find("#busCriterio").val(valorCboOpciones);
        controles_TH.listarBusqueda();
    }
};

controles_TH.exportarListadoExcel = function () {
    var varBusFormulario = controles_TH.frmManGrilla.find("#busFormulario").val();
    $.ajax({
        url: urlLocalSigo + "THabilitante/Controles/ExportarExcelListadoManGrilla",
        type: 'POST',
        data: { busFormulario: varBusFormulario },
        dataType: 'json',
        success: function (data) {
            utilSigo.unblockUIGeneral();
            if (data.success) {
                window.location.href = urlLocalSigo + "THabilitante/Controles/DownloadListadoManGrilla?file=" + data.values[0];
            }
            else utilSigo.toastWarning("Error", data.msj);
        },
        beforeSend: function () {
            utilSigo.blockUIGeneral();
        },
        error: function (jqXHR, error, errorThrown) {
            utilSigo.unblockUIGeneral();
            utilSigo.toastError("Error", "Sucedio un error, Comuniquese con el Administrador");
            console.log(jqXHR.responseText);
        }
    });
};

controles_TH.iniciarEventosManGrilla = function () {

    $('#btnManGrillaReload').click(function () {
        controles_TH.frmManGrilla.find('#busCriterio').val('TODOS');
        controles_TH.frmManGrilla.find('#txtValor').val('');
        controles_TH.listarBusqueda();
    });

    $('#btnManGrillaBuscar').click(function () {
        controles_TH.realizarBusqueda();
    });

    $('#btnManGrillaExportar').click(function () {
        if ($("#busFormulario").val() != "PLAN_GENERAL_MANEJO_FORESTAL")
            controles_TH.exportarListadoExcel();
    });

    $("#btnManGrillaNuevo").click(function () {
        var datos = {
            busFormulario: controles_TH.frmManGrilla.find("#tipoFrmulario").val(),
            hdfTipoFormulario: controles_TH.frmManGrilla.find("#hdfTipoFormulario").val(),
            hdfFormulario: controles_TH.frmManGrilla.find("#hdfFormulario").val(),
            idModal: "manModalidadModal"
        };
        var url = "";
        switch (datos.busFormulario) {
            case "TITULO_HABILITANTE":
                url = urlLocalSigo + "THabilitante/Controles/_ManModalidad";
                break;
            case "CERTIFICADO_PLANTA":
                url = urlLocalSigo + "THabilitante/Controles/_CertifPlanta";
                break;
            case "PLAN_GENERAL_MANEJO_FORESTAL":
            case "PLAN_MANEJO_FORESTAL_INTERMEDIO":
                var valEsPMFI = $("#contenedorGrilla").find("#hdEsPMFI").val();
                var codThabilitante = "";
                window.location = urlLocalSigo + "THabilitante/ManPlanManejoForestal/AddEdit?cod_PM=" + codThabilitante + "&opt=" + valEsPMFI;
                break;
            case "POA":
            case "DEMA":
            case "PMFI":
                url = urlLocalSigo + "THabilitante/Controles/_THabilitante";
                break;
            default:
                url = urlLocalSigo + "THabilitante/Controles/_ManModalidad";
                break;
        }
        var _hrModal = $.ajax({
            url: url,
            type: 'POST',
            data: datos,
            dataType: 'html',
            success: function (data) {
                utilSigo.unblockUIGeneral();
                if (_hrModal.status != 203) {
                    $("#" + datos.idModal).html(data);
                    utilSigo.modalDraggable($("#" + datos.idModal), '.modal-header');
                    $("#" + datos.idModal).modal({ keyboard: true, backdrop: 'static' });
                }

            },
            beforeSend: function () {
                utilSigo.blockUIGeneral();
            },
            error: function (jqXHR, error, errorThrown) {
                utilSigo.unblockUIGeneral();
                utilSigo.toastError("Error", "Sucedio un Error Inesperado, Comuniquese con el Administrador");
                console.log(jqXHR.responseText);
            },
            statusCode: {
                203: () => { utilSigo.unblockUIGeneral(); utilSigo.toastInfo("Aviso", "El usuario perdio la sesión. Vuelva ingresar al sistema"); }
            }
        });
    });
    $('#manModalidadModal').on('hidden.bs.modal', function (e) {
        $("#manModalidadModal").html('');
    });
};

$(document).ready(function () {
    // $.fn.select2.defaults.set("theme", "bootstrap4");  
    $('[data-toggle="tooltip"]').tooltip();
    controles_TH.frmManGrilla = $("#frmManGrilla");
    controles_TH.tbGrillaGeneral = $("#tbGrillaGeneral");
    controles_TH.dtGrillaGeneral = controles_TH.tbGrillaGeneral.DataTable({
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
        "oLanguage": initSigo.oLanguage,
        "drawCallback": initSigo.showPagination
    });
    controles_TH.listarBusqueda();
    controles_TH.frmManGrilla.submit(function (e) {
        e.preventDefault();
        controles_TH.realizarBusqueda();
    });
    controles_TH.iniciarEventosManGrilla();
});

