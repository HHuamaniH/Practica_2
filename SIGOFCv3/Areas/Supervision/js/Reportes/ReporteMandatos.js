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
    var columns_label = [], columns_data = [], options = {};

    columns_label = ['Nro. Resolución', 'Nro. Expediente', 'Título Habilitante', 'Titular', 'Modalidad', 'Medida'
        , 'Impl. Días', 'Impl. Meses', 'Inf. Días', 'Inf. Meses'];
    columns_data = ['NUM_RESOLUCION', 'NUM_EXPEDIENTE', 'NUM_THABILITANTE', 'TITULAR', 'MODALIDAD', 'MEDIDA'
        , 'PLAZO_IMPL_DIA', 'PLAZO_IMPL_MES', 'PLAZO_INF_DIA', 'PLAZO_INF_MES'];

    options = { page_paging: true, page_length: 10, row_index: true, row_edit: true };
    
    utilSigo.fnAjax(option, function (data) {
        ManCNotificacion.frm.find("#dvManContenedor").html(data);
        _ManGrillaPaging.fnInit(columns_label, columns_data, options);
        $('#btnAdd').hide();
        _ManGrillaPaging.fnExport = function () {            
            var busValor = $('#txtValorBuscar').val();
            var busCriterio = $('#ddlOpcionBuscarId').val();

            let url = `${urlLocalSigo}/Supervision/Reportes/DownloadMandato?asCriterio=${busCriterio}&asValor=${busValor}`;
            ManCNotificacion.getBinary("RPT_Mandatos", url);
        };
    });
};
ManCNotificacion.downloadBlob = function (blob, fileName) {
    let link = document.createElement('a');
    link.href = URL.createObjectURL(blob);
    link.download = fileName;
    document.body.append(link);
    link.click();
    link.remove();
    window.addEventListener('focus', e => URL.revokeObjectURL(link.href), { once: true });
};
ManCNotificacion.getBinary = function (filename, url) {
    //$(".preloader").show();
    fetch(url, {
        method: 'GET'
    }).then(function (resp) {
        switch (resp.status) {
            case 200: return resp.blob(); 
            case 404: throw Error('Recurso no encontrado'); break;
            case 500: throw Error('Sucedio error en el servidor'); break;
            case 401: throw Error('El usuario perdió la sesión. Vuelva ingresar al sistema'); break;
            case 403: throw Error("No tiene permiso"); break;
            default: throw Error("Error no identificado");
        }
    }).then(function (blob) {
        ManCNotificacion.downloadBlob(blob, `${filename}.xlsx`);
        //$(".preloader").fadeOut();
    }).catch(function (error) {
        //$(".preloader").fadeOut();
        utilSigo.toastError("Error", error.message);        
    });
}