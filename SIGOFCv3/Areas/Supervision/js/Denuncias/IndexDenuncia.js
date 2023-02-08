var ManCNotificacion = {};

$(document).ready(function () {
    ManCNotificacion.frm = $("#frmManCNotificacion");
    ManCNotificacion.fnLoadManGrillaPaging();
});

ManCNotificacion.fnLoadManGrillaPaging = function () {
    var url = initSigo.urlControllerGeneral + "_ManGrillaPaging";
    var data = ManCNotificacion.frm.serializeObject();
    
    var option = {
        url: url,
        datos: JSON.stringify(data),
        type: 'POST',
        dataType: 'html'
    };
    var columns_label = [],
        columns_data = modalAddEditDenuncia
        options = {},
        data_extend = [];
    columns_label = ['N° de tramite', "Fecha Documento", "Registro", "Remitente"];
    columns_data = ['cCodificacion', "fFecDocumento", "vTrabajador", "cNombre"];
    data_extend = [
        {
            render: function (data, type, row) {
                return row.cDescTipoDoc + '</br>' + row.cNroDocumento;
            }, title: "Documento"
        },
        {
            render: function (data, type, row) {
                return '<a data-placement="botton" title="' + row.cAsunto + '" >' + utilSigo.recortarTextos(row.cAsunto, 40) + '</a>';
            }, title: "Asunto"
        },
        {
            render: function (data, type, row) {
                return row.DEPENDENCIA;
            }, title: "ENTIDAD A CARGO"
        },
        {
            render: function (data, type, row) {
                return row.NOMBRE_DEPENDENCIA;
            }, title: "ATENDIDO"
        },
        {
            render: function (data, type, row) {
                return row.NUMERO;
            }, title: "INFORME"
        },
        {
            render: function (data, type, row) {
                return `<a title='Detalle del Trámite' href="#" onClick="irTramite('${row.cCodificacion.trim()}','${row.cPassword.trim()}')">${row.cCodificacion.trim()}</a>`;
            }, title: "Cod. Tramite"
        },
        {
            render: function (data, type, row) {
                return "<a href='#' data-toggle='tooltip' data-placement='top'  onClick='descargarTramite(" + JSON.stringify(row) + ")' title='" + row.cNombreOriginal + "' >" + utilSigo.recortarTextos(row.cNombreOriginal, 40) + "</a>";
            }, title: "Documento"
        },
        {
            render: function (data, type, row) {
                return "<a href='#' data-toggle='tooltip' data-placement='top' onClick='verDetalle(" + JSON.stringify(row) +")'  >Ver Detalle</a>";
            }, title: "Detalle"
        }
    ];

    options = {
        page_paging: true,
        page_length: 10,
        row_index: true,
        row_edit: true,
        row_fnEdit: "_ManGrillaPaging.fnCreate(this)",
        data_extend: data_extend
    };

    utilSigo.fnAjax(option, function (data) {
        ManCNotificacion.frm.find("#dvManDenunciasContenedor").html(data);
        _ManGrillaPaging.fnInit(columns_label, columns_data, options);
        $('#btnAdd').hide();
        $(document)
            .find('#btnDownload')
            .parent()
            .append('<a id="btndescargar Manual" style="cursor:pointer;" data-toggle="tooltip" data-placement="top" title="" onclick="manualUsuario()" data-original-title="Manual de Usuario"><span class="fa mx-2 fa-lg fa-download"></span></a>');
        _ManGrillaPaging.fnExport = function () {
            var url = urlLocalSigo + "Supervision/Denuncias/ExportarTablaGrl";
            var option = { url: url, datos: JSON.stringify({}), type: 'POST' };

            utilSigo.fnAjax(option, function (data) {
                if (data.success) {
                    document.location = urlLocalSigo + "Archivos/Denuncia/" + data.msj;
                }
                else {
                    utilSigo.toastWarning("Aviso", "Sucedio un error, Comuníquese con el Administrador");
                    console.log(data.msj);
                }
            });
        };

        _ManGrillaPaging.fnCreate = function (obj) {
            var data = _ManGrillaPaging.dtManGrillaPaging.row($(obj).parents('tr')).data();
            //debugger
            $.redirect(urlLocalSigo + "Supervision/Denuncias/TramiteDenuncia", {
                iCodTramite: data.iCodTramite,
                cCodificacion: data.cCodificacion.trim(),
                iCodTupa: data.iCodTupa,
                iCodTupaClase: data.iCodTupaClase,
                Destino: data.Destino,
                tramite:data
            });
        };
    });
};

var descargarTramite = function (row) {

    window.open(row.DESCARGA, "_blank");
};
var verDetalle = function (obj) {
    //debugger
    //var data = _ManGrillaPaging.dtManGrillaPaging.row($(obj).parents('tr')).data();
    $.redirect(urlLocalSigo + "Supervision/Denuncias/VistaDenuncia", {
        id: obj.cCodificacion + "_____" + obj.iCodTramite + "_____" + obj.iCodTupa + "_____" + obj.iCodTupaClase,
        tramite:obj
    });
};

var manualUsuario = function () {
    window.open("/SIGOsfc_Calidad/Archivos/Documentos/guiaFormatoDenuncia.pdf", "_blank");
};

var irTramite = function (cCodificacion, contrasena) {
    var winName = 'Tramite SITD';
    var winURL = "http://sitd.osinfor.gob.pe:82/std/cInterfaseUsuario_SITD/usuario_net.php?a=0";
    var params = { 'cCodificacion': cCodificacion, 'contrasena': contrasena };
    var form = document.createElement("form");
    form.setAttribute("method", "post");
    form.setAttribute("action", winURL);
    form.setAttribute("target", winName);
    for (var i in params) {
        if (params.hasOwnProperty(i)) {
            var input = document.createElement('input');
            input.type = 'hidden';
            input.name = i;
            input.value = params[i];
            form.appendChild(input);
        }
    }
    document.body.appendChild(form);
    form.target = winName;
    form.submit();
    document.body.removeChild(form);
};