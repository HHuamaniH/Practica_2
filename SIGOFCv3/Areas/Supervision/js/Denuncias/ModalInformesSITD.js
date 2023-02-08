var modalDocInformeSITD = {
    tablaInformeData: [],
    tablaInforme: null,
    ui: function () {
        
        if (tramiteDenuncia.objInformeSITD.length > 0) {
            modalDocInformeSITD.tablaInformeData = tramiteDenuncia.objInformeSITD;
        }
        iniciarTabla();
    },
    eventos: function () {
        $('#btnAgregar').click(function () {
            $("#mdlManInforme_DOCSITD .close").click();
           
            tramiteDenuncia.objInformeSITD = modalDocInformeSITD.tablaInformeData;
            let data = '';
            let cto = 1;
            let str = '';
            if (modalDocInformeSITD.tablaInformeData.length > 0) {
                //str += '<div class="card-body">';
                str += '<div class="table-responsive">';
                str += '<table class="table table-bordered">';
                str += '<thead><tr>';
                str += '<th scope="col">#</th>';
                str += '<th scope="col">Cod Tramite</th>';
                str += '<th scope="col">Codificación</th>';
                str += '<th scope="col">Descripción</th>';
                str += '<th scope="col">Asunto</th>';
                str += '<th scope="col">#</th>';
                str += '</tr></thead><tbody>';
                modalDocInformeSITD.tablaInformeData.forEach(
                    (value) => {
                        
                        data += value.VCODTRAMITE + ',';
                        str += "<tr>";
                        str += '<th scope="row">' + cto++ + '</th>';
                        str += '<td scope="col">' + value.VCODTRAMITE + '</td>';
                        str += '<td scope="col">' + value.VCODIFICACION + '</td>';
                        str += '<td scope="col">' + value.VDESCTIPODOC + '</td>';
                        str += '<td scope="col">' + value.VASUNTO + '</td>';
                        str += '<td scope="col">';
                        if (value.VPDF_TRAMITE_SITD.length > 1) str += '<a title="Descargar Documento" href=" https://sitd.osinfor.gob.pe:8443/std/cInterfaseUsuario_SITD/download.php?direccion=sitd-almacen&file=' + value.VPDF_TRAMITE_SITD + '"><i class="fa fa-lg fa-download" style="cursor: pointer; color: dodgerblue; " title="Descargar Documento"></i></a>';
                        str += '</td>';
                        str += '</tr>';
                    });
                str += '</tbody></table>';
                str += '</div>';
               // str += '</div>';

               
            }
            $('#inptInformesSITD').val(utilSigo.recortarTextos(data.substring(0, data.length - 1), 40));
            $('#lblInformesSITD').html("Informe / Carta / Oficios(" + modalDocInformeSITD.tablaInformeData.length + ")");
            $('#htmlDocSITD').html(str);
        });
    },
    buscarInforme: function () {
        modalDocInformeSITD.tablaInforme.ajax.reload();
    }
    //,
    //agregarInforme: function (row) {
    //    $("#mdlManInforme_DOCINFORME .close").click();
    //    tramiteDenuncia.objInforme = row;
    //    $('#inptTramiteDenuncia').val(row.NUMERO);
    //}
};

$(function () {
    modalDocInformeSITD.ui();
    modalDocInformeSITD.eventos();
});

var iniciarTabla = function () {
    //debugger

    modalDocInformeSITD.tablaInforme = $('#grvInformesSITD').DataTable({
        oLanguage: initSigo.oLanguage,
        dom: 'rtip',
        bInfo: true,
        responsive: true,
        processing: true,
        bServerSide: true,
        pageLength: initSigo.pageLengthBuscar,
        sAjaxSource: urlLocalSigo + "Supervision/Denuncias/GetListaDocumentosSITD",
        fnServerData: function (url, odata, callback) {
            //debugger
            let _INFORME = {};
            let PageSize = odata[4].value;
            let PrimerRegistro = odata[3].value;
            let CurrentPage = PrimerRegistro / PageSize;
            _INFORME.pagesize = PageSize;
            _INFORME.PageSize = PageSize;
            _INFORME.CurrentPage = CurrentPage + 1;
            _INFORME.currentpage = CurrentPage + 1;
            _INFORME = { iCodTramite: $('#InptDtaBuscar').val()}
            _INFORME.BusFormulario = 'DOC_GENERADOS';
            _INFORME.BusCriterio = 'CCODIFICACION';
            _INFORME.BusValor = tramiteDenuncia.tra_M_Tramite.cCodificacion;
          
            $.ajax({
                "url": url,
                "dataSrc": "",
                "data": { paramsBus: _INFORME },
                "success": function (response) {
                    //debugger
                    callback({
                        data: response,
                        recordsTotal: response.length === 0 ? 0 : response.length,
                        recordsFiltered: response.length === 0 ? 0 : response.length
                    });
                },
                "contentType": "application/x-www-form-urlencoded; charset=utf-8",
                "dataType": "json",
                "type": "POST",
                "cache": false,
                "error": function (resultado) {
                    console.log(resultado);
                }
            });
        },
        drawCallback: function (settings) {
            
            $('[data-toggle="tooltip"]').tooltip();
            $('.checkData').click(function () {
                var obj = $(this).data("objinforme");
                if ($(this).is(':checked')) {
                    //debugger
                    //obj.VCODINFORME = obj.COD_INFORME;
                    obj = {
                        VCODTRAMITE: obj.iCodTramite, VDESCTIPODOC: obj.cDescTipoDoc.trim(), VASUNTO: obj.cAsunto.trim(), VCODIFICACION: obj.cCodificacion.trim(),
                        VNRODOCUMENTO: obj.cNroDocumento.trim()||" ", VFECDOCUMENTO: obj.fFecDocumento, VPDF_TRAMITE_SITD: obj.PDF_TRAMITE_SITD||" "};
                    modalDocInformeSITD.tablaInformeData.push(obj);
                   // modalTHabilitante.tablaTHabilitanteData.push(obj);
                } else {
                    //debugger
                    modalDocInformeSITD.tablaInformeData = modalDocInformeSITD.tablaInformeData.filter(
                        DocInforme => { return DocInforme.VCODTRAMITE !== obj.iCodTramite}
                    );
                    //modalTHabilitante.tablaTHabilitanteData =
                    //    modalTHabilitante.tablaTHabilitanteData.filter(
                    //        THabilitante => {
                    //            return THabilitante.ent_THABILITANTE.COD_THABILITANTE.toString() !== obj.ent_THABILITANTE.COD_THABILITANTE.toString();
                    //        });
                }
            });

        },
        columns: [
            { data: "iCodTramite", title: "COD TRAMITE" },
            { data: "cCodificacion", title: "CODIFICACION" },
            { data: "fFecDocumento",  title: "FECHA DOCUMENTO" },
            { data: "cDescTipoDoc", title: "TIPO DOCUMENTO" },
            { data: "cAsunto", title: "ASUNTO" },
            {
                render: function (data, type, row) {
                    let str = '';
                    //debugger
                    //var d = modalDocInformeSITD.tablaInformeData;
                    var d = modalDocInformeSITD.tablaInformeData
                        .find(
                            x => x.VCODTRAMITE
                                .toString() === row.iCodTramite.toString()
                        );
                    if (d === undefined) {
                        str = "<input class='checkData' type='checkbox' data-objInforme='" + JSON.stringify(row) + "' >";
                    } else {
                        str = "<input class='checkData' type='checkbox' data-objInforme='" + JSON.stringify(row) + "' checked>";
                    }
                    return str;
                    //return "<button class='btn btn-primary btn-xs btn-edit' type='button' " +
                    //    "onClick='modalDocInformeSITD.agregarInforme(" + JSON.stringify(row) + ")'>Agregar</button>";
                }, title: "Acciones"
            }
        ],
        columnDefs: [
            { responsivePriority: 1, targets: 0 },
            { responsivePriority: 2, targets: -2 },
            { className: "text-center", targets: "_all", orderable: false }
        ]
    });
};
