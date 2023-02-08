var ComunicarHallazgo = {};
ComunicarHallazgo.DataEnviado = [];

ComunicarHallazgo.fnLoadData = function (obj) {
    ComunicarHallazgo.DataEnviado = obj;
};

ComunicarHallazgo.regresar = function () {
    var url = urlLocalSigo + "Supervision/ReporteVigilancia/Index";
    window.location = url;
};

ComunicarHallazgo.fnNuevo = function () {
    //utilSigo.modalDraggable($("#mdlEnviarCorreo"), '.modal-header');
    //$("#mdlEnviarCorreo").modal({ keyboard: true, backdrop: 'static' });
    var url = urlLocalSigo + "Supervision/ReporteVigilancia/_EnviarCorreo";
    var option = { url: url, type: 'POST', datos: {}, divId: "mdlEnviarCorreo" };

    utilSigo.fnOpenModal(option, function () {
        _EnviarCorreo.fnInit(ComunicarHallazgo.frm.find("#hdfCodHallazgo").val());

        _EnviarCorreo.fnRefreshTable = function () {
            url = urlLocalSigo + "Supervision/ReporteVigilancia/GetListaEnviados";
            option = { url: url, datos: JSON.stringify({ idhallazgo: ComunicarHallazgo.frm.find("#hdfCodHallazgo").val() }), type: 'POST' };

            utilSigo.fnAjax(option, function (data) {
                if (data.success) {
                    ComunicarHallazgo.dtEnviado.clear().draw();
                    ComunicarHallazgo.dtEnviado.rows.add(data.data).draw();
                }
                else {
                    utilSigo.toastWarning("Aviso", "Sucedio un error, Comuníquese con el Administrador");
                    console.log(data.msjError);
                }
            });

            $("#mdlEnviarCorreo").modal('hide');
        };
    });
};

ComunicarHallazgo.fnInitDataTableDetail = function () {
    var columns_label = ["Destinatarios", "Destinatarios con Copia", "Fecha Envío"];
    var columns_data = ["NV_PARA", "NV_CC", "FE_CREACION"];
    var options = {
        page_length: 20, row_index: true, page_info: true, page_sort: true
    };
    ComunicarHallazgo.dtEnviado = utilDt.fnLoadDataTable_Detail(ComunicarHallazgo.frm.find("#tbEnviado"), columns_label, columns_data, options);
    ComunicarHallazgo.dtEnviado.rows.add(JSON.parse(ComunicarHallazgo.DataEnviado)).draw();
};

$(document).ready(function () {
    ComunicarHallazgo.frm = $("#frmComunicarHallazgo");

    $('[data-toggle="tooltip"]').tooltip();

    ComunicarHallazgo.fnInitDataTableDetail();
});