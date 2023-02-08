    "use strict";

 

    var ManInformeQuinquenal = {};


 ManInformeQuinquenal.fnBuscarCarta = function (_dom) {
     let url = urlLocalSigo + "Supervision/ManInformeQuinquenal/_BuscarCartaNotificacion";
        let option = { url: url, type: 'GET', datos: {}, divId: "mdlBuscarCarta" };
        utilSigo.fnOpenModal(option, function () {
            _BuscarCN.fnAsignarDatos = function (obj) {
                if (obj != null && obj != "") {
                    let data = _BuscarCN.dtBuscarCarta.row($(obj).parents('tr')).data();
                    console.log(data);
                    localStorage.setItem("localCartaNotificacion", JSON.stringify(data));
                    var url_crud = urlLocalSigo + "Supervision/ManInformeQuinquenal/AddEdit";
                    window.location = url_crud ;// + "&asCodCNotificacion=" + codCNotificacion;
                }
            }
            _BuscarCN.fnInit();
        });
    }

    ManInformeQuinquenal.fnLoadManGrillaPaging = function () {
        var url = initSigo.urlControllerGeneral + "_ManGrillaPaging";
        var data = ManInformeQuinquenal.frm.serializeObject();
        var option = { url: url, datos: JSON.stringify(data), type: 'POST', dataType: 'html' };

        var columns_label = [], columns_data = [], options = {};
        columns_label = ["Fecha Registro", "N° Informe Quinquenal", "Tipo", "N° R.D. Quinquenal", "Título Habilitante", "Titular"];
        columns_data = ["FECHA_CREACION", "NUM_INFORME", "TIPO", "RD_QUINQUENAL", "NUM_THABILITANTE", "TITULAR"];
        
        options = {
            page_paging: true, page_length: 20, row_index: true, row_edit: true, row_fnEdit: "_ManGrillaPaging.fnCreate(this)"
        };

        utilSigo.fnAjax(option, function (data) {
            ManInformeQuinquenal.frm.find("#dvManInformeQuinquenalContenedor").html(data);
            _ManGrillaPaging.fnInit(columns_label, columns_data, options);

            _ManGrillaPaging.fnExport = function () {

                const url = `${urlLocalSigo}/Supervision/ManInformeQuinquenal/DownloadRPT?valor=${$("#txtValorBuscar").val().trim()}`;
                utilSigo.file.getBinary("RPT_InformeQuinquenal.xlsx", url);
            }

            _ManGrillaPaging.fnCreate = function (obj) {

                
                    var cod_informe = "";
                    var url_crud = urlLocalSigo + "Supervision/ManInformeQuinquenal/AddEdit";

                if (obj != "") {
                    var data = _ManGrillaPaging.dtManGrillaPaging.row($(obj).parents('tr')).data();
                    cod_informe = data["COD_INFORME"];
                    //codMTipo = data["COD_FCTIPO"];
                    _ManGrillaPaging.fnReadConfigManGrillaPaging();

                    window.location = url_crud + "?asCodInforme=" + cod_informe;// + "&asCodCNotificacion=" + codCNotificacion;

                } else {
                    ManInformeQuinquenal.fnBuscarCarta();
                }
                                 
            }
        });
    }

$(document).ready(function () {
            let mensajeRegQuinquenal = localStorage.getItem("mensajeRegQuinquenal");
            if (mensajeRegQuinquenal != null) {
                if (mensajeRegQuinquenal != "") {
                    utilSigo.toastSuccess("Aviso", mensajeRegQuinquenal);
                    localStorage.removeItem("mensajeRegQuinquenal");
                }
            }
    
        ManInformeQuinquenal.frm = $("#frmManInforme");
       
        ManInformeQuinquenal.fnLoadManGrillaPaging();
    });