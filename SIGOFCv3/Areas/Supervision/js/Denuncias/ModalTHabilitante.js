/*
.     .       .  .   . .   .   . .    +  .
  .     .  :     .    .. :. .___---------___.
       .  .   .    .  :.:. _".^ .^ ^.  '.. :"-_. .
    .  :       .  .  .:../:            . .^  :.:\.
        .   . :: +. :.:/: .   .    .        . . .:\
 .  :    .     . _ :::/:               .  ^ .  . .:\
  .. . .   . - : :.:./.                        .  .:\
  .      .     . :..|:                    .  .  ^. .:|
    .       . : : ..||        .                . . !:|
  .     . . . ::. ::\(                           . :)/
 .   .     : . : .:.|. ######              .#######::|
  :.. .  :-  : .:  ::|.#######           ..########:|
 .  .  .  ..  .  .. :\ ########          :######## :/
  .        .+ :: : -.:\ ########       . ########.:/
    .  .+   . . . . :.:\. #######       #######..:/
      :: . . . . ::.:..:.\           .   .   ..:/
   .   .   .  .. :  -::::.\.       | |     . .:/
      .  :  .  .  .-:.":.::.\             ..:/
 .      -.   . . . .: .:::.:.\.           .:/
.   .   .  :      : ....::_:..:\   ___.  :/
   .   .  .   .:. .. .  .: :.:.:\       :/
     +   .   .   : . ::. :.:. .:.|\  .:/|
     .         +   .  .  ...:: ..|  --.:|
.      . . .   .  .  . ... :..:.."(  ..)"
 .   .       .      :  .   .: ::/  .  .::\
*/


var modalTHabilitante = {
    tablaTHabilitanteData: [],
    tablaTHabilitante: null,
    ui: function () {
        if (tramiteDenuncia.objTHabilitante.length > 0) {
            modalTHabilitante.tablaTHabilitanteData = tramiteDenuncia.objTHabilitante;
        }
        inicarTabla();
    },
    eventos: function () {
        $('#btnAgregar').click(function () {
            $("#mdlManInforme_THabilitante .close").click();
            tramiteDenuncia.objTHabilitante = modalTHabilitante.tablaTHabilitanteData; 
            let data = '';
            let cto = 1;
            let str = '';
            if (modalTHabilitante.tablaTHabilitanteData.length > 0) {
                //str += '<div class="card-body">';
                str += '<div class="table-responsive">';
                str += '<table class="table table-bordered">';
                str += '<thead><tr>';
                str += '<th scope="col">#</th>';
                str += '<th scope="col">FECHA</th>';
                str += '<th scope="col">MODALIDAD</th>';
                str += '<th scope="col">NUMERO</th>';
                str += '<th scope="col">PERSONA TITULAR</th>';
                str += '</tr></thead><tbody>';
                modalTHabilitante.tablaTHabilitanteData.forEach(
                    (value) => {
                        data += value.ent_THABILITANTE.NUMERO + ',';
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
                //str += '</div>';
            }
            $('#inptTHabilitante').val(utilSigo.recortarTextos(data.substring(0, data.length - 1), 40));
            $('#lblTHabilitante').html("T. Habilitante (" + modalTHabilitante.tablaTHabilitanteData.length + ")");
            $('#htmlTHabilitante').html(str);
        });
    },
    buscarTHabilitante: function () {
        modalTHabilitante.tablaTHabilitante.ajax.reload();
    }
};

$(function () {
    modalTHabilitante.ui();
    modalTHabilitante.eventos();
});

var inicarTabla = function () {
    modalTHabilitante.tablaTHabilitante = $('#grvInformes').DataTable({
        oLanguage: initSigo.oLanguage,
        dom: 'rtip',
        bInfo: true,
        responsive: true,
        processing: true,
        bServerSide: true,
        pageLength: initSigo.pageLengthBuscar,
        sAjaxSource: urlLocalSigo + "Supervision/Denuncias/ConsultarTHabilitante",
        fnServerData: function (url, odata, callback) {
            let _INFORME = {};
            let PageSize = odata[4].value;
            let PrimerRegistro = odata[3].value;
            let CurrentPage = PrimerRegistro / PageSize;
            _INFORME.pagesize = PageSize;
            _INFORME.currentpage = CurrentPage + 1;
            _INFORME.ent_THABILITANTE = {
                NUMERO : $('#InptDtaBuscar').val()
            };
            $.ajax({
                "url": url,
                "dataSrc": "",
                "data": _INFORME,
                "success": function (response) {
                    callback({
                        data: response,
                        recordsTotal: response.length === 0 ? 0 : response[0].rowCount,
                        recordsFiltered: response.length === 0 ? 0 : response[0].rowCount
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
                var obj = $(this).data("objthabilitante");
               
                if ($(this).is(':checked')) {
                    modalTHabilitante.tablaTHabilitanteData.push(obj);
                } else {
                    modalTHabilitante.tablaTHabilitanteData =
                        modalTHabilitante.tablaTHabilitanteData.filter(
                            THabilitante => {
                                return THabilitante.ent_THABILITANTE.COD_THABILITANTE.toString() !== obj.ent_THABILITANTE.COD_THABILITANTE.toString();
                            });
                }
            });
        },
        columns: [
            { data: "ent_THABILITANTE.FECHA", title: "FECHA" },
            { data: "ent_THABILITANTE.MODALIDAD", title: "MODALIDAD" },
            { data: "ent_THABILITANTE.NUMERO", title: "NUMERO" },
            { data: "ent_THABILITANTE.PERSONA_TITULAR", title: "PERSONA TITULAR" },
            {
                render: function (data, type, row) {
                    let str = '';
                    var d = modalTHabilitante.tablaTHabilitanteData
                        .find(
                            x => x.ent_THABILITANTE.COD_THABILITANTE.toString() === row.ent_THABILITANTE.COD_THABILITANTE.toString()
                    );
                    if (d === undefined) {
                        str = "<input class='checkData' type='checkbox' data-objThabilitante='" + JSON.stringify(row) + "' >";
                    } else {
                        str = "<input class='checkData' type='checkbox' data-objThabilitante='" + JSON.stringify(row) + "' checked>";
                    }
                    return str;
                    //return "<input class='checkData' type='checkbox' id='defaultCheck1' onClick='modalTHabilitante.agregarTHabilitante(" + JSON.stringify(row) + ")>";
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