$(function () {
    cargarData();

});
var fnViewModalPOASupervisado = function (obj) {
    //debugger
    let d = obj.split(',');
    var codInforme = d[0], numpoa = d[1], bpoa = d[2], codsecpoa = d[3], coditipo = d[4];
    var _origen = '';
    var bool = (bpoa==1 ? true : false);

    if ((typeof codInforme !== 'undefined' && codInforme != "")) {
       
        var url = urlLocalSigo;
        let datos = {};
        if (bool) {
            if (_origen !== 'undefined' && _origen == 'FAUNA') {
                url += "Supervision/ManInformeFauna/_POAFaunaSupervisado";
            } else {
                url += "Supervision/ManInforme/_POASupervisado";
            }
            datos = {
                asCodInforme: codInforme,
                aiNumPoa: numpoa,
                B_POA: bpoa
            }
        } else {
            url += "Supervision/ManInforme/_ArbolesSinPoa";
            datos = {
                asCodInforme: codInforme,
                B_POA: bpoa,
                CODIGO_SEC_NOPOA: codsecpoa,
                hdfCodMTipo: coditipo
            }
        }
        var option = {
            url: url, type: 'POST', datos: datos, divId: "mdlManInforme_POASupervisado"
        };
        utilSigo.fnOpenModal(option, function () {
            let a = $('.fa-save'); a.addClass('d-none');
            utilSigo.blockUIGeneral();
            setTimeout(function () {
                
                $('.fa-pencil-square-o').addClass('d-none');
                $('.fa-file-o').addClass('d-none');
                $('.fa-window-close').addClass('d-none');
                $('.fa-file-excel-o').addClass('d-none');
                $('.fa-window-close-o').addClass('d-none');
                utilSigo.unblockUIGeneral();
            }, 2500);
        });
    } else {
        utilSigo.toastWarning("Aviso", "Primero debe guardar el informe para luego poder registrar los datos del plan de manejo");
    }
}
var cargarData = function () {
    var option = {
        url: urlLocalSigo + "Supervision/Denuncias/ObtenerDataDenuncica",
        datos: JSON.stringify({
            Tra_M_Tramite: {
                cCodificacion: $('#cCodificacion').val(),
                iCodTramite: $('#iCodTramite').val(),
                iCodTupa: $('#iCodTupa').val(),
                iCodTupaClase: $('#iCodTupaClase').val()
            }
        }),
        type: 'POST'
    };
    //debugger
    utilSigo.fnAjax(option, function (data) {

        //$('#txtnum_informe').val(data.ENT_INFORME.NUMERO);
        //$('#txtNotificacion').val(data.ENT_INFORME.NUM_CNOTIFICACION);
        //$('#txtFechaInicio').val(utilSigo.convertirFecha(data.ENT_INFORME.FECHA_SUPERVISION_INICIO));
        //$('#txtFechaFin').val(utilSigo.convertirFecha(data.ENT_INFORME.FECHA_SUPERVISION_FIN));
        //$('#txtModalidad').val(data.ENT_INFORME.MODALIDAD_TIPO);
        //$('#txtDepartamento').val(data.ENT_INFORME.UBIGEO);
        //$('#txtTHablitante').val(data.ENT_INFORME.NUM_THABILITANTE);
        //$('#txtTitular').val(data.ENT_INFORME.TITULAR);
        //$('#txtDLinea').val(data.ENT_INFORME.COD_DLINEA);

        if (data.FLAG_THABILITANTE == 1) {
            $('#rbtnTHabilitanteSi').prop('checked', true);
            $('.isupervision').removeClass('d-none');
            $('.thabilitante').removeClass('d-none');
        }
        if (data.FLAG_THABILITANTE == 2) {
            $('#rbtnTHabilitanteNo').prop('checked', true);
            $('.isupervision').addClass('d-none');
            $('.thabilitante').addClass('d-none');


            $('#inptTramiteDenuncia').val('');
        }
        if (data.TIPO_REQUERIMIENTO != null) { 
            if (data.TIPO_REQUERIMIENTO.length > 0) $('#cboTipoRequerimiento').val(data.TIPO_REQUERIMIENTO);
            if (data.TIPO_REQUERIMIENTO_OTRO.length > 0) $('#txtOtros').val(data.TIPO_REQUERIMIENTO_OTRO);
            if (data.TIPO_TRASLADO.length > 0) $('#cboTipoTraslado').val(data.TIPO_TRASLADO);
        }

        $('#inptTramiteDenuncia').val(data.ENT_INFORME.NUMERO);
        if (!data.B_FLAG_COMPETENCIA) {
            $('#inptEntidad').val(data.NOMBRE_DEPENDENCIA);
        }
        if (data.IDenunciaDetDocumentosSITD !== null) {
            data.objInformeSITD = data.IDenunciaDetDocumentosSITD;
            let rptaStr = '';
            let cto = 1;
            let str = '';
            if (data.IDenunciaDetDocumentosSITD.length > 0) {
                //str += '<div class="card-body">';
                str += '<div class="table-responsive">';
                str += '<table class="table table-bordered">';
                str += '<thead><tr>';
                str += '<th scope="col">#</th>';
                str += '<th scope="col">Cod Tramite</th>';
                str += '<th scope="col">Codificación</th>';
                str += '<th scope="col">Descripción</th>';
                str += '<th scope="col">Asunto</th>';
                str += '<th scope="col">Descargar</th>';
                str += '</tr></thead><tbody>';
                data.IDenunciaDetDocumentosSITD.forEach(
                    (value) => {

                        rptaStr += value.VCODTRAMITE + ',';
                        str += "<tr>";
                        str += '<th scope="row">' + cto++ + '</th>';
                        str += '<td scope="col">' + value.VCODTRAMITE + '</td>';
                        str += '<td scope="col">' + value.VCODIFICACION + '</td>';
                        str += '<td scope="col">' + value.VDESCTIPODOC + '</td>';
                        str += '<td scope="col">' + value.VASUNTO + '</td>';
                        str += '<td scope="col"><a title="Descargar Documento" href=" https://sitd.osinfor.gob.pe:8443/std/cInterfaseUsuario_SITD/download.php?direccion=sitd-almacen&file=' + value.VPDF_TRAMITE_SITD + '">' + value.VPDF_TRAMITE_SITD + '</a></td>';
                        str += '</tr>';
                    });
                str += '</tbody></table>';
                str += '</div>';
                // str += '</div>';


            }
            $('#lblInformesSITD').html("Informe / Carta / Oficios(" + data.IDenunciaDetDocumentosSITD.length + ")");
            $('#htmlDocSITD').html(str);

        }

        $('#txtConclusionDenuncia').val(data.CONCLUSION);
        $('#txtRecomendacionDenuncia').val(data.RECOMENDACION);
        $('#htmlInformes').html(dibujarInformes(data.IDENUNCIA_ITECNICOS));
        $('#htmlCartasOficios').html(dibujarInformes(data.IDENUNCIA_CARTA_OFICIO));
        data.tra_M_Tramite = tramite;
        $('#htmlExpedientes').html(dibujarExpedientes(data));
        $('#htmlAuditoria').html(dibujarAuditoria(data));
        $('#htmlTHabilitante').html(dibujarThabilitante(data));
        data.IDenunciaDetInformeSupervision.forEach(
            (value) => {
                let lst = data.ENT_INFORME.ListPOAs;
                for (var i = 0; i < lst.length; i++) {
                    if (lst[0].COD_INFORME == value.VCODINFORME) {
                        value = lst[0]; break;
                    }
                }
            }
        );

        $('#htmlInformeSupervision').html(dibujarInformeSupervision(data.IDenunciaDetInformeSupervision));

        if (data.IATENDIDO === 1) {
            $('#rbtnAtendido1').prop('checked', true);
        } else if (data.IATENDIDO === 2) {
            $('#rbtnAtendido2').prop('checked', true);
        } else if (data.IATENDIDO === 3) {
            $('#rbtnAtendido3').prop('checked', true);
        }
    });
};

var returnIndex = function () {
    $.redirect(urlLocalSigo + "Supervision/Denuncias/IndexDenuncia", null);
};

var descargarArchivo = function (ruta) {
    var url = urlLocalSigo + "Supervision/Denuncias/descargarArchivo?ruta=" + ruta.URL_TECNICO + "&nombre=" + ruta.NOMBRE_ARCHIVO + "&mineType=" + ruta.ARCHIVO_EXTENSION;
    window.open(url, "_blank");
};

var descargarTramite = function (row) {
    window.open(row.DESCARGA, "_blank");
};

var dibujarInformes = function (data) {
    let str = '';
    if (data !== null) {
        str += '<div class="card-body accordion">';
        data.forEach(
            (value) => {
                str += '<div class="card" style="margin-bottom:0px !important;" >';
                str += '<div class="card-header" id="headingOne">';
                str += '<h2 class="col-md-0">';
                str += '<button class="btn btn-link" type="button" data-toggle="collapse" data-target="#collapse' + value.COD_IDENUNCIA_ITECNICO + '" aria-expanded="true" aria-controls="collapse' + value.COD_IDENUNCIA_ITECNICO + '">' + value.NOMBRE_INFORME + '(' + value.IDENUNCIA_ITECNICO_ARCHIVOS.length + ')</button>';
                str += '</h2>';
                str += '</div>';
                str += '<div id="collapse' + value.COD_IDENUNCIA_ITECNICO + '" class="collapse" aria-labelledby="heading' + value.COD_IDENUNCIA_ITECNICO + '" data-parent="#accordionExample">';
                str += '<div class="card-body">';
                str += '<div class="table-responsive">';
                let count = 1;
                str += '<table class="table table-bordered">';
                str += '<thead><tr><th scope="col">#</th><th scope="col">Documento</th><th scope="col">Descargar</th></tr></thead><tbody>';
                if (value.IDENUNCIA_ITECNICO_ARCHIVOS !== null) {
                    value.IDENUNCIA_ITECNICO_ARCHIVOS.forEach(
                        (value1) => {
                            str += "<tr><th scope='row'>" + count++ + "</th>" +
                                "<td>" + value1.NOMBRE_ARCHIVO + " </td>" +
                                "<td><i class='fa fa-lg fa-download' style='cursor:pointer;color:dodgerblue;' onClick='descargarArchivo(" + JSON.stringify(value1) + ")' title='Descargar Documento'></i></td>" +
                                "</tr> ";
                        });
                }
                str += '</tbody></table>';
                str += '</div>';
                str += '</div>';
                str += '</div>';
                str += '</div>';
            });
    }
    return str;
};

var dibujarExpedientes = function (data) {
    let str = '';
    //debugger
    if (data.tra_M_Tramite !== null) {
        str += '<div class="card-body">';
        str += '<div class="table-responsive">';
        str += '<table class="table table-bordered">';
        str += '<thead><tr>';
        str += '<th scope="col">#</th>';
        str += '<th scope="col">N° Tramite</th>';
        str += '<th scope="col">Tipo Doc.</th>';
        str += '<th scope="col">N° Documento</th>';
        str += '<th scope="col">Fecha Documento</th>';
        str += '<th scope="col">Asunto</th>';
        str += '<th scope="col">Clase de Tupa</th>';
        str += '<th scope="col">Tupa</th>';
        str += '<th scope="col">Descargar</th>';
        str += '</tr></thead><tbody>';
        str += "<tr>";
        str += '<th scope="row">' + 1 + '</th>';
        str += '<td scope="col">' + data.tra_M_Tramite.cCodificacion + '</td>';
        str += '<td scope="col">' + data.tra_M_Tramite.cDescTipoDoc + '</td>';
        str += '<td scope="col">' + data.tra_M_Tramite.cNroDocumento + '</td>';
        str += '<td scope="col">' + data.tra_M_Tramite.fFecDocumento + '</td>';
        str += '<td scope="col">' + data.tra_M_Tramite.cAsunto + '</td>';
        str += '<td scope="col">' + data.tra_M_Tramite.cNomTupaClase + '</td>';
        str += '<td scope="col">' + data.tra_M_Tramite.cNomTupa + '</td>';
        str += "<td scope='col'><i class='fa fa-lg fa-download' style='cursor:pointer;color:dodgerblue;' onClick='descargarTramite(" + JSON.stringify(data.tra_M_Tramite) + ")' title='Descargar Documento'></i></td>";
        str += '</tr>';
        str += '</tbody></table>';
        str += '</div>';
        str += '</div>';
    }
    return str;
};

var dibujarAuditoria = function (data) {
    let count = 1;
    let str = '';
    if (data.iDENUNCIA_AUDITORIA_ARCHIVO !== null) {
        str += '<div class="card-body">';
        str += '<div class="table-responsive">';
        str += '<table class="table table-bordered">';
        str += '<thead><tr>';
        str += '<th scope="col">#</th>';
        str += '<th scope="col"> Archivo Auditoria</th>';
        str += '<th scope="col"> Descargar</th>';
        str += '</tr></thead><tbody>';
        data.iDENUNCIA_AUDITORIA_ARCHIVO.forEach(
            (data) => {
                str += "<tr>";
                str += '<th scope="row">' + count++ + '</th>';
                str += '<td scope="col">' + data.NOMBRE_ARCHIVO + '</td>';
                str += "<td scope='col'><i class='fa fa-lg fa-download' style='cursor:pointer;color:dodgerblue;' onClick='descargarArchivo(" + JSON.stringify(data) + ")' title='Descargar Documento' ></i></td>";
                str += '</tr>';
            });
        str += '</tbody></table>';
        str += '</div>';
        str += '</div>';
    }
    return str;
};


var dibujarThabilitante = function (row) {
    let cto = 1;
    let str = '';
    if (row.iDENUNCIA_THABILITANTEs !== null) {
        if (row.iDENUNCIA_THABILITANTEs.length > 0) {
            str += '<div class="card-body">';
            str += '<div class="table-responsive">';
            str += '<table class="table table-bordered">';
            str += '<thead><tr>';
            str += '<th scope="col">#</th>';
            str += '<th scope="col">FECHA</th>';
            str += '<th scope="col">MODALIDAD</th>';
            str += '<th scope="col">NUMERO</th>';
            str += '<th scope="col">PERSONA TITULAR</th>';
            str += '</tr></thead><tbody>';
            row.iDENUNCIA_THABILITANTEs.forEach(
                (value) => {
                    str += "<tr>";
                    str += '<th scope="row">' + cto++ + '</th>';
                    str += '<td scope="col">' + value.ent_THABILITANTE.FECHA + '</td>';
                    str += '<td scope="col">' + value.ent_THABILITANTE.MODALIDAD + '</td>';
                    str += '<td scope="col">' + value.ent_THABILITANTE.NUMERO + '</td>';
                    str += '<td scope="col">' + value.ent_THABILITANTE.PERSONA_TITULAR + '</td>';
                    str += '</tr>';
                });
            str += '</tbody></table>';
            str += '</div>';
            str += '</div>';
        }
    }
    return str;
};
var dibujarInformeSupervision = function (data) {
    let str = '';
    if (data != null) {
        let index = 1;

        data.forEach(function (x) {
            //debugger
            //$('#txtnum_informe').val(data.ENT_INFORME.NUMERO);
            //$('#txtNotificacion').val(data.ENT_INFORME.NUM_CNOTIFICACION);
            //$('#txtFechaInicio').val(utilSigo.convertirFecha(data.ENT_INFORME.FECHA_SUPERVISION_INICIO));
            //$('#txtFechaFin').val(utilSigo.convertirFecha(data.ENT_INFORME.FECHA_SUPERVISION_FIN));
            //$('#txtModalidad').val(data.ENT_INFORME.MODALIDAD_TIPO);
            //$('#txtDepartamento').val(data.ENT_INFORME.UBIGEO);
            //$('#txtTHablitante').val(data.ENT_INFORME.NUM_THABILITANTE);
            //$('#txtTitular').val(data.ENT_INFORME.TITULAR);
            //$('#txtDLinea').val(data.ENT_INFORME.COD_DLINEA);
            let lugar = x.ent_INFORME.UBIGEO.split('||');
            str += '<div class="card-body"><div class="form-row" >' +
                '<div class="form-group col-md-12 mb-3"><label for="txtnum_informe" class="text-small">' + (index++) + ') N° Informe</label><input class="form-control form-control-sm text-box single-line" disabled="disabled"  value="' + x.ent_INFORME.NUMERO + '" type="text"></div></div>' +
                '<div class="form-row"><div class="form-group col-md-4"><label for="txtNotificacion" class="text-small">Notificacion</label><input value="' + x.ent_INFORME.NUM_CNOTIFICACION + '" class="form-control form-control-sm" disabled="disabled" type="text"></div>' +
                '<div class="form-group col-md-4"><label for="txtFechaInicio" class="text-small">Fecha de Supervision Inicio</label><input value="' + utilSigo.convertirFecha(x.ent_INFORME.FECHA_SUPERVISION_INICIO) + '" class="form-control form-control-sm" disabled="disabled"  type="text"></div>' +
                '<div class="form-group col-md-4"><label for="txtFechaFin" class="text-small">Fecha de Supervision Fin</label><input value="' + utilSigo.convertirFecha(x.ent_INFORME.FECHA_SUPERVISION_FIN) + '" class="form-control form-control-sm" disabled="disabled"  type="text"></div></div>' +
                '<div class="form-row"><div class="form-group col-md-4 mb-3"><label for="txtModalidad" class="text-small">Modalidad</label><input value="' + x.ent_INFORME.MODALIDAD_TIPO + '" class="form-control form-control-sm" disabled="disabled"  type="text"></div>' +
                '<div class="form-group col-md-4 mb-3"><label for="txtDepartamento" class="text-small">Departamento</label><input value="' + lugar[0] + '" class="form-control form-control-sm" disabled="disabled"  type="text"></div>' +
                '<div class="form-group col-md-4 mb-3"><label for="txtDepartamento" class="text-small">Provincia</label><input value="' + lugar[1] + '" class="form-control form-control-sm" disabled="disabled"  type="text"></div>' +
                '<div class="form-group col-md-4 mb-3"><label for="txtDepartamento" class="text-small">Distrito</label><input value="' + lugar[2] + '" class="form-control form-control-sm" disabled="disabled"  type="text"></div>'
                + '</div>' +
                '<div id="pndatos_InfAutOtros"><div class="form-row"><div class="form-group col-md-4 mb-3"><label for="txtTHablitante" class="text-small">T. Habilitante</label><input value="' + x.ent_INFORME.NUM_THABILITANTE + '" class="form-control form-control-sm" disabled="disabled" type="text"></div>' +
                '<div class="form-group col-md-4 mb-3"><label for="txtTitular" class="text-small">Titular</label><input class="form-control form-control-sm" disabled="disabled" value="' + x.ent_INFORME.TITULAR + '"  type="text"></div>' +
                '<div class="form-group col-md-4 mb-3"><label for="txtDLinea" class="text-small">D. Linea</label><input class="form-control form-control-sm" disabled="disabled" value="' + x.ent_INFORME.COD_DLINEA + '"  type="text"></div></div>';
            let i = 0;
            if (x.ent_INFORME.ListPOAs.length>0) {
                str += '<table  class="table table-hover table-bordered"><thead>' +
                    '<tr> <th colspan="4" class="text-sm-left"><div class="form-inline">Planes de Manejo Asociados a la Carta de Notificación</div></th></tr >' +
                    '<tr><th scope="col">N°</th><th scope="col">PLAN DE MANEJO</th><th scope="col">SUPERVISADO</th><th  scope="col">DATOS</th></tr>' +
                    '</thead > <tbody>';//debugger

                x.ent_INFORME.ListPOAs.forEach(function (z) {
                    i++;
                    //debugger
                    let d = x.VCODINFORME + ',' + z.NUM_POA + ',' + z.B_POA + ',' + z.CODIGO_SEC_NOPOA + ',' + z.COD_ITIPO;
                    str += '<tr >' + '<th scope="row">' + i + '</th><td>' + z.POA + '</td>';
                    str += "<td><i style='font-size: 0.9rem;' class=' fa fa-fw fa-check-square-o' ></i></td><td ><i style='font-size: 0.9rem;cursor:pointer;' class='fa fa-fw fa-edit ' onclick='fnViewModalPOASupervisado(" + JSON.stringify(d) + ")' ></i></td>";
                    str += '</tr>';

                });
                str += '</tbody></table >';
                
            }
            str += '</div ></div > ';

        });
        return str;
    };

}