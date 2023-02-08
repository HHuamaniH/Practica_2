var modalDocInforme = {
    tablaInformeData: [],
    tablaInforme: null,
    ui: function () {
        //debugger
        if (tramiteDenuncia.objInforme.length > 0) {
            

            modalDocInforme.tablaInformeData = tramiteDenuncia.objInforme;
        }
        iniciarTabla();
    },
    eventos: function () {
        $('#btnAgregar').click(function () {
            $("#mdlManInforme_DOCINFORME .close").click();
            
            tramiteDenuncia.objInforme = modalDocInforme.tablaInformeData;
            //let data = '';
            //let cto = 1;
            //let str = '';
            //if (modalDocInforme.tablaInformeData.length > 0) {
                
            //    str += '<div class="table-responsive">';
            //    str += '<table class="table table-bordered">';
            //    str += '<thead><tr>';
            //    str += '<th scope="col">#</th>';
            //    str += '<th scope="col">INFORME SUPERVISION</th>';
            //    str += '<th scope="col">POA</th>';
            //    str += '</tr></thead><tbody>';
            //    modalDocInforme.tablaInformeData.forEach(
            //        (value) => {
            //            //debugger
            //            data += value.ent_INFORME.NUMERO + ',';
            //            str += "<tr>";
            //            str += '<th scope="row">' + cto++ + '</th>';
            //            str += '<td scope="col">' + value.ent_INFORME.NUMERO + '</td>';
            //            str += '<td scope="col">' + value.ent_INFORME.NUMERO + '</td>';
            //            str += '</tr>';
            //        });
            //    str += '</tbody></table>';
            //    str += '</div>';
                

               
            //}
            //$('#inptTramiteDenuncia').val(utilSigo.recortarTextos(data.substring(0, data.length - 1), 40));
            //$('#lblTramiteDenuncia').html("Informe de Supervisión (" + modalDocInforme.tablaInformeData.length + ")");
            //$('#htmlSupervision').html(str);
        });
    },
    buscarInforme: function () {
        modalDocInforme.tablaInforme.ajax.reload();
    }
    //,
    //agregarInforme: function (row) {
    //    $("#mdlManInforme_DOCINFORME .close").click();
    //    tramiteDenuncia.objInforme = row;
    //    $('#inptTramiteDenuncia').val(row.NUMERO);
    //}
};

$(function () {
    modalDocInforme.ui();
    modalDocInforme.eventos();
});

var iniciarTabla = function () {
    //debugger
    modalDocInforme.tablaInforme = $('#grvInformes').DataTable({
        oLanguage: initSigo.oLanguage,
        dom: 'rtip',
        bInfo: true,
        responsive: true,
        processing: true,
        bServerSide: true,
        pageLength: initSigo.pageLengthBuscar,
        sAjaxSource: urlLocalSigo + "Supervision/Denuncias/ConsultarInforme",
        fnServerData: function (url, odata, callback) {
            let _INFORME = {};
            let PageSize = odata[4].value;
            let PrimerRegistro = odata[3].value;
            let CurrentPage = PrimerRegistro / PageSize;
            _INFORME.pagesize = PageSize;
            _INFORME.currentpage = CurrentPage + 1;
            _INFORME.NUMERO = $('#InptDtaBuscar').val();
            $.ajax({
                "url": url,
                "dataSrc": "",
                "data": _INFORME,
                "success": function (response) {
                    
                    callback({
                        data: response,
                        recordsTotal: response.length === 0 ? 0 : response[0].rowcount,
                        recordsFiltered: response.length === 0 ? 0 : response[0].rowcount
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
                   // debugger
                    obj.VCODINFORME = obj.COD_INFORME;
                    obj.ent_INFORME = { COD_INFORME: obj.COD_INFORME, NUMERO: obj.NUMERO };
                    modalDocInforme.tablaInformeData.push(obj);
                   // modalTHabilitante.tablaTHabilitanteData.push(obj);
                } else {
                    //debugger
                    modalDocInforme.tablaInformeData = modalDocInforme.tablaInformeData.filter(
                        DocInforme => { return DocInforme.ent_INFORME.COD_INFORME !== obj.COD_INFORME}
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
            { data: "NUMERO", name: "NUMERO", title: "N° INFORME" },
            { data: "NUM_CNOTIFICACION", name: "NUM_CNOTIFICACION", title: "N° NOTIFICACION" },
            { data: "UBIGEO", name: "UBIGEO", title: "UBIGEO" },
            { data: "TITULAR", name: "NUMERO", title: "TITULAR" },
            {
                render: function (data, type, row) {
                    let str = '';
                    //debugger
                    //var d = modalDocInforme.tablaInformeData;
                    var d = modalDocInforme.tablaInformeData
                        .find(
                            x => x.VCODINFORME
                                .toString() === row.COD_INFORME.toString()
                        );
                    if (d === undefined) {
                        str = "<input class='checkData' type='checkbox' data-objInforme='" + JSON.stringify(row) + "' >";
                    } else {
                        str = "<input class='checkData' type='checkbox' data-objInforme='" + JSON.stringify(row) + "' checked>";
                    }
                    return str;
                    //return "<button class='btn btn-primary btn-xs btn-edit' type='button' " +
                    //    "onClick='modalDocInforme.agregarInforme(" + JSON.stringify(row) + ")'>Agregar</button>";
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
