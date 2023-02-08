
"use strict";
var ManNotificacion_Muestra = {};
/*Variables globales*/
ManNotificacion_Muestra.tbEliTABLA = [];

ManNotificacion_Muestra.fnReturnIndex = function (alertaInicial) {
    var url = urlLocalSigo + "Notificacion/ManNotificacion/Index";

    sessionStorage.removeItem("ListCNotificacionCenso");

    if (alertaInicial == null || alertaInicial == "") {
        window.location = url;
    } else {
        window.location = url + "?_alertaIncial=" + alertaInicial;
    }
}

ManNotificacion_Muestra.fnViewModalMuestra = function () {
    utilSigo.modalDraggable($("#mdlManCNot_Muestra_Muestra"), '.modal-header');
    $("#mdlManCNot_Muestra_Muestra").modal({ keyboard: true, backdrop: 'static' });
}

ManNotificacion_Muestra.fnInitDataTable_Detail = function () {
    var columns_label = [], columns_data = [], options = {}, data_extend = [];

    var tipoMuestra = ManNotificacion_Muestra.frm.find("#hdfTipoMuestra").val();
    switch (tipoMuestra) {
        case "M":
        case "NM":
            if (tipoMuestra=="M") {
                columns_label = ["POA", "Especie Censo", "Especie Resolución", "Bloque PCA", "Faja", "Código", "Volumen", "DAP", "AC", "DMC"
                    , "Condición", "Estado", "Zona UTM", "Coord. Este", "Coord. Norte"];
                columns_data = ["Poa", "EspCenso", "EspResol", "Bloq", "Faja", "Cod", "Vol", "Dap", "Ac", "Dmc"
                    , "EspCond", "EspEst", "Zona", "CEste", "CNorte"];
            } else {
                columns_label = ["POA", "Especie Censo", "Especie Resolución", "Estrada", "Código", "Diámetro", "Altura", "Prod. Latas"
                    , "Condición", "Zona UTM", "Coord. Este", "Coord. Norte"];
                columns_data = ["Poa", "EspCenso", "EspResol", "NumEst", "Cod", "Diam", "Alt", "ProLat"
                    , "EspCond", "Zona", "CEste", "CNorte"];
            }
            
            data_extend = [
                {
                    "data": "NumM", "title": "", "orderable": false, "searchable": false, "mRender": function (data, type, row, meta) {
                        var muestraSelect = false;
                        switch (data) {
                            case 1: muestraSelect = row["EstM1"]; break;
                            case 2: muestraSelect = row["EstM2"]; break;
                            case 3: muestraSelect = row["EstM3"]; break;
                        }

                        if (muestraSelect == true) {
                            return '<i class="fa fa-lg fa-ban" style="cursor:pointer;color:red;font-size:18px;" title="Quitar especie de la muestra" onclick="ManNotificacion_Muestra.fnRemoveEspecieMuestra(this,\'NO_MUESTRA\');"></i>';
                        } else {
                            return '<i class="fa fa-lg fa-check" style="cursor:pointer;color:limegreen;font-size:18px;" title="Seleccionar especie a la muestra" onclick="ManNotificacion_Muestra.fnSelectEspecieMuestra(this);"></i>';
                        }
                    }
                }
            ];
            options = {
                page_length: 50, page_info: true, row_index: true, data_extend: data_extend, page_render: true
            };
            ManNotificacion_Muestra.dtNoMuestra = utilDt.fnLoadDataTable_Detail($("#tbManCNot_Muestra_NoMuestra"), columns_label, columns_data, options);

            data_extend = [
                {
                    "data": "NumM", "title": "M1", "orderable": false, "searchable": false, "mRender": function (data, type, row, meta) {
                        if (data == 1 && row["EstM1"] == true) { return '<i class="fa fa-lg fa-check-circle-o"></i>'; }
                        else { return '<i class="fa fa-lg fa-circle-o"></i>'; }
                    }
                },
                {
                    "data": "NumM", "title": "M2", "orderable": false, "searchable": false, "mRender": function (data, type, row, meta) {
                        if (data == 2 && row["EstM2"] == true) { return '<i class="fa fa-lg fa-check-circle-o"></i>'; }
                        else { return '<i class="fa fa-lg fa-circle-o"></i>'; }
                    }
                },
                {
                    "data": "NumM", "title": "M3", "orderable": false, "searchable": false, "mRender": function (data, type, row, meta) {
                        if (data == 3 && row["EstM3"] == true) { return '<i class="fa fa-lg fa-check-circle-o"></i>'; }
                        else { return '<i class="fa fa-lg fa-circle-o"></i>'; }
                    }
                }
            ];
            options = {
                page_length: 50, page_info: true, row_index: true, row_delete: true, row_fnDelete: "ManNotificacion_Muestra.fnRemoveEspecieMuestra(this,\'MUESTRA\')"
                , data_extend: data_extend, page_search: true, page_render: true
            };
            ManNotificacion_Muestra.dtMuestra = utilDt.fnLoadDataTable_Detail($("#tbManCNot_Muestra_Muestra"), columns_label, columns_data, options);
            break;
        case "DTR":
        case "DTO":
        case "DAR":
            if (tipoMuestra=="DTR") {
                columns_label = ["Especie", "Código", "DAP", "Altura", "Volumen", "Coord. Este", "Coord. Norte"
                    , "N° Trozas", "Descripción", "Observación"];
                columns_data = ["Esp", "Cod", "Dap", "Alt", "Vol", "CEste", "CNorte", "NumTro", "Desc", "Obs"];
            } else if (tipoMuestra=="DTO") {
                columns_label = ["Especie", "Código", "Diámetro", "Largo", "Volumen", "Coord. Este", "Coord. Norte"
                    , "Cantidad", "Descripción", "Observación"];
                columns_data = ["Esp", "Cod", "Diam", "Lar", "Vol", "CEste", "CNorte", "Cant", "Desc", "Obs"];
            } else {
                columns_label = ["Especie", "N° PCA", "Código", "DAP", "Altura", "Volumen", "Coord. Este", "Coord. Norte"
                    , "Condición", "Estado", "Observación"];
                columns_data = ["Esp", "Pca", "Cod", "Dap", "Alt", "Vol", "CEste", "CNorte", "EspCond", "EspEst", "Obs"];
            }
            
            data_extend = [
                {
                    "data": "EstM", "title": "", "orderable": false, "searchable": false, "mRender": function (data, type, row, meta) {
                        if (data) {
                            return '<i class="fa fa-lg fa-ban" style="cursor:pointer;color:red;font-size:18px;" title="Quitar especie de la muestra" onclick="ManNotificacion_Muestra.fnRemoveEspecieMuestra(this,\'NO_MUESTRA\');"></i>';
                        } else {
                            return '<i class="fa fa-lg fa-check" style="cursor:pointer;color:limegreen;font-size:18px;" title="Seleccionar especie a la muestra" onclick="ManNotificacion_Muestra.fnSelectEspecieMuestra(this);"></i>';
                        }
                    }
                }
            ];
            options = {
                page_length: 50, page_info: true, row_index: true, data_extend: data_extend, page_render: true
            };
            ManNotificacion_Muestra.dtNoMuestra = utilDt.fnLoadDataTable_Detail($("#tbManCNot_Muestra_NoMuestra"), columns_label, columns_data, options);

            options = {
                page_length: 50, page_info: true, row_index: true, row_delete: true, row_fnDelete: "ManNotificacion_Muestra.fnRemoveEspecieMuestra(this,\'MUESTRA\')"
                , page_search: true, page_render: true
            };
            ManNotificacion_Muestra.dtMuestra = utilDt.fnLoadDataTable_Detail($("#tbManCNot_Muestra_Muestra"), columns_label, columns_data, options);
            break;
    }
}

/*Obtener todo el CENSO asociado a la Carta de Notificación*/
ManNotificacion_Muestra.fnGetCenso = function () {
    sessionStorage.removeItem("ListCNotificacionCenso");
    var url = urlLocalSigo + "Notificacion/ManNotificacion/GetCenso";
    var option = { url: url + "?asCodNotificacion=" + ManNotificacion_Muestra.frm.find("#hdfCodCNotificacion").val() + "&asTipoMuestra=" + ManNotificacion_Muestra.frm.find("#hdfTipoMuestra").val() };
    utilSigo.fnAjax(option, function (data) {
        if (data.success) {
            /*Guardar todo el CENSO en local*/
            if (window.sessionStorage) {
                sessionStorage.setItem('ListCNotificacionCenso', JSON.stringify(data.data));

                var lstNoMuestra = [], lstMuestra = [];
                lstNoMuestra = ManNotificacion_Muestra.fnSearchCenso("NO_MUESTRA", "", "");
                lstMuestra = ManNotificacion_Muestra.fnSearchCenso("MUESTRA", "", "");

                ManNotificacion_Muestra.dtMuestra.rows.add(lstMuestra).draw();
                ManNotificacion_Muestra.dtNoMuestra.rows.add(lstNoMuestra).draw();
                ManNotificacion_Muestra.frm.find("#lblNumEspecieSelect").text(lstMuestra.length);
            } else {
                utilSigo.toastWarning("Aviso", "Se identificaron problemas con el navegador; por favor comuníquese con el Administrador.");
                console.log("El navegador no soporta sessionStorage de HTML5");
            }
        }
        else {
            utilSigo.toastWarning("Aviso", initSigo.MessageError);
            console.log(data.msjError);
        }
    });
}
/*Buscar especies dentro del censo según algunos filtros*/
ManNotificacion_Muestra.fnSearchCenso = function (_filtro, _criterio, _valor) {
    var lstBusFiltro = [], lstBusCriterio = [];
    var lstCenso = JSON.parse(sessionStorage.getItem('ListCNotificacionCenso'));
    /*Cada filtro se puede poner en una función --probar*/
    switch (ManNotificacion_Muestra.frm.find("#hdfTipoMuestra").val()) {
        case "M":
        case "NM":
            switch (_filtro) {
                case "MUESTRA":
                    lstBusFiltro = lstCenso.filter((m=>m.NumM == 1 && m.EstM1 == true) || (m=>m.NumM == 2 && m.EstM2 == true) || (m=>m.NumM == 3 && m.EstM3 == true));
                    break;
                case "NO_MUESTRA":
                    lstBusFiltro = lstCenso.filter((m=>m.NumM == 1 && m.EstM1 == false) || (m=>m.NumM == 2 && m.EstM2 == false) || (m=>m.NumM == 3 && m.EstM3 == false));
                    break;
                case "COND_APROVECHABLE": lstBusFiltro = lstCenso.filter(m=>m.EspCond == "Aprovechable"); break;
                case "COND_SEMILLERO": lstBusFiltro = lstCenso.filter(m=>m.EspCond == "Semillero"); break;
                case "COND_PRODUCTIVO": lstBusFiltro = lstCenso.filter(m=>m.EspCond == "Productivo"); break;
                case "COND_NO_PRODUCTIVO": lstBusFiltro = lstCenso.filter(m=>m.EspCond == "No Productivo"); break; break;
                default: lstBusFiltro = lstCenso; break;
            }
            if (_valor=="") {
                lstBusCriterio = lstBusFiltro;
            } else {
                for (var i = 0; i < lstBusFiltro.length; i++) {
                    if ((_criterio == "ESPECIE" && lstBusFiltro[i]["EspCenso"].toUpperCase().includes(_valor.toUpperCase()))
                        || (_criterio == "CESTE" && lstBusFiltro[i]["CEste"].toString().includes(_valor))
                        || (_criterio == "CNORTE" && lstBusFiltro[i]["CNorte"].toString().includes(_valor))
                        || (_criterio == "BLOQUE" && lstBusFiltro[i]["Bloq"].toUpperCase().includes(_valor.toUpperCase()))
                        || (_criterio == "FAJA" && lstBusFiltro[i]["Faja"].toUpperCase().includes(_valor.toUpperCase()))
                        || (_criterio == "CODIGO" && lstBusFiltro[i]["Cod"].toUpperCase().includes(_valor.toUpperCase()))
                        || (_criterio == "POA" && lstBusFiltro[i]["Poa"].toUpperCase().includes(_valor.toUpperCase()))
                        || (_criterio == "ESTRADA" && lstBusFiltro[i]["NumEst"].toUpperCase().includes(_valor.toUpperCase()))) {

                        lstBusCriterio.push(lstBusFiltro[i]);
                    }
                }
            }
            break;
        case "DTR":
        case "DTO":
        case "DAR":
            switch (_filtro) {
                case "MUESTRA": lstBusFiltro = lstCenso.filter(m=>m.EstM == true); break;
                case "NO_MUESTRA": lstBusFiltro = lstCenso.filter(m=>m.EstM == false); break;
                default: lstBusFiltro = lstCenso; break;
            }
            if (_valor=="") {
                lstBusCriterio = lstBusFiltro;
            } else {
                for (var i = 0; i < lstBusFiltro.length; i++) {
                    if ((_criterio == "ESPECIE" && lstBusFiltro[i]["Esp"].toUpperCase().includes(_valor.toUpperCase()))
                        || (_criterio == "CESTE" && lstBusFiltro[i]["CEste"].toString().includes(_valor))
                        || (_criterio == "CNORTE" && lstBusFiltro[i]["CNorte"].toString().includes(_valor))
                        || (_criterio == "CODIGO" && lstBusFiltro[i]["Cod"].toUpperCase().includes(_valor.toUpperCase()))) {

                        lstBusCriterio.push(lstBusFiltro[i]);
                    }
                }
            }
            break;
    }

    return lstBusCriterio;
}
/*Establecer especie del censo como parte de la muestra*/
ManNotificacion_Muestra.fnSetCensoEspecieMuestra = function (data) {
    var lstCenso = JSON.parse(sessionStorage.getItem('ListCNotificacionCenso'));
    var index = -1;

    switch (ManNotificacion_Muestra.frm.find("#hdfTipoMuestra").val()) {
        case "M":
        case "NM":
            index = lstCenso.findIndex(m=>m.CodTh == data["CodTh"] && m.NumPoa == data["NumPoa"] && m.CodEsp == data["CodEsp"] && m.CodSec == data["CodSec"]);
            if (index!=-1) {
                lstCenso[index] = data;
            }
            break;
        case "DTR":
        case "DTO":
        case "DAR":
            index = lstCenso.findIndex(m=>m.CodDev == data["CodDev"] && m.CodEsp == data["CodEsp"] && m.CodSec == data["CodSec"]);
            if (index != -1) {
                lstCenso[index] = data;
            }
            break;
    }
    sessionStorage.setItem('ListCNotificacionCenso', JSON.stringify(lstCenso));
}
/*Quitar la especie del censo de la muestra*/
ManNotificacion_Muestra.fnSetCensoEspecieNoMuestra = function (data) {
    var lstCenso = JSON.parse(sessionStorage.getItem('ListCNotificacionCenso'));
    var index = -1;

    switch (ManNotificacion_Muestra.frm.find("#hdfTipoMuestra").val()) {
        case "M":
        case "NM":
            index = lstCenso.findIndex(m=>m.CodTh == data["CodTh"] && m.NumPoa == data["NumPoa"] && m.CodEsp == data["CodEsp"] && m.CodSec == data["CodSec"]);
            if (index != -1) {
                lstCenso[index] = data;
            }
            break;
        case "DTR":
        case "DTO":
        case "DAR":
            index = lstCenso.findIndex(m=>m.CodDev == data["CodDev"] && m.CodEsp == data["CodEsp"] && m.CodSec == data["CodSec"]);
            if (index != -1) {
                lstCenso[index] = data;
            }
            break;
    }
    sessionStorage.setItem('ListCNotificacionCenso', JSON.stringify(lstCenso));
}

/*Seleccionar todo el censo como muestra y grabar*/
ManNotificacion_Muestra.fnSaveCensoAsMuestra = function () {
    utilSigo.dialogConfirm('', 'Está seguro de seleccionar todo el censo como la muestra?', function (r) {
        if (r) {
            var url = urlLocalSigo + "Notificacion/ManNotificacion/SaveCensoAsMuestra";
            var datos = {
                asCodNotificacion: ManNotificacion_Muestra.frm.find("#hdfCodCNotificacion").val(),
                asTipoMuestra: ManNotificacion_Muestra.frm.find("#hdfTipoMuestra").val()
            };
            var option = { url: url, datos: JSON.stringify(datos), type: 'POST' };
            utilSigo.fnAjax(option, function (data) {
                if (data.success) {
                    ManNotificacion_Muestra.fnReturnIndex(data.msj);
                }
                else {
                    utilSigo.toastWarning("Aviso", data.msj);
                }
            });
        }
    });
}
/*Quilar toda la muestra seleccionada*/
ManNotificacion_Muestra.fnRemoveMuestra = function () {
    utilSigo.dialogConfirm('', 'Está seguro de eliminar toda la muestra seleccionada?', function (r) {
        if (r) {
            var lstCenso = JSON.parse(sessionStorage.getItem('ListCNotificacionCenso'));

            switch (ManNotificacion_Muestra.frm.find("#hdfTipoMuestra").val()) {
                case "M":
                case "NM":
                    lstCenso = lstCenso.map(function (m) {
                        switch (m.NumM) {
                            case 1: m.EstM1 = false; break;
                            case 1: m.EstM1 = false; break;
                            case 1: m.EstM1 = false; break;
                        }
                        return m;
                    });
                    break;
                case "DTR":
                case "DTO":
                case "DAR":
                    lstCenso = lstCenso.map(function (m) { m.EstM = false; return m; }); break;
            }

            sessionStorage.setItem('ListCNotificacionCenso', JSON.stringify(lstCenso));
            ManNotificacion_Muestra.frm.find("#hdfRemoveAllMuestraSelect").val(true);
            ManNotificacion_Muestra.dtNoMuestra.clear();
            ManNotificacion_Muestra.dtNoMuestra.rows.add(ManNotificacion_Muestra.fnSearchCenso("NO_MUESTRA", "", "")).draw();
            ManNotificacion_Muestra.dtMuestra.clear().draw();
            ManNotificacion_Muestra.frm.find("#lblNumEspecieSelect").text(0);
        }
    });
}
/*Seleccionar una especie como parte de la muestra*/
ManNotificacion_Muestra.fnSelectEspecieMuestra = function (obj) {
    var data = ManNotificacion_Muestra.dtNoMuestra.row($(obj).parents('tr')).data();

    switch (ManNotificacion_Muestra.frm.find("#hdfTipoMuestra").val()) {
        case "M":
        case "NM":
            switch (data["NumM"]) {
                case 1: data["EstM1"] = true; break;
                case 2: data["EstM2"] = true; break;
                case 3: data["EstM3"] = true; break;
            }
            data["RegEst"] = 1;
            break;
        case "DTR":
        case "DTO":
        case "DAR":
            data["EstM"] = true;
            data["RegEst"] = 1;
            break;
    }

    ManNotificacion_Muestra.dtNoMuestra.row($(obj).parents('tr')).data(data).draw(false);
    ManNotificacion_Muestra.dtMuestra.rows.add([data]).draw();
    ManNotificacion_Muestra.fnSetCensoEspecieMuestra(data);

    var numEspecies = parseInt(ManNotificacion_Muestra.frm.find("#lblNumEspecieSelect").text()) + 1;
    ManNotificacion_Muestra.frm.find("#lblNumEspecieSelect").text(numEspecies);
}
/*Quitar una especie de la muestra*/
ManNotificacion_Muestra.fnRemoveEspecieMuestra = function (obj, origen) {
    var index = -1;

    if (origen == "NO_MUESTRA") {
        var data = ManNotificacion_Muestra.dtNoMuestra.row($(obj).parents('tr')).data();
        var lstMuestra = [];
        ManNotificacion_Muestra.dtMuestra.rows().every(function () { lstMuestra.push(this.data()) })

        switch (ManNotificacion_Muestra.frm.find("#hdfTipoMuestra").val()) {
            case "M":
            case "NM":
                switch (data["NumM"]) {
                    case 1: data["EstM1"] = false; break;
                    case 2: data["EstM2"] = false; break;
                    case 3: data["EstM3"] = false; break;
                }

                index = lstMuestra.findIndex(m=>m.CodTh == data["CodTh"] && m.NumPoa == data["NumPoa"] && m.CodEsp == data["CodEsp"] && m.CodSec == data["CodSec"]);
                if (index!=-1) {
                    var rowRemove = ManNotificacion_Muestra.dtMuestra.row(index).data();
                    if (rowRemove["RegEst"] == 0) {
                        ManNotificacion_Muestra.tbEliTABLA.push({
                            COD_FISNOTI: rowRemove["CodCn"],
                            COD_THABILITANTE: rowRemove["CodTh"],
                            NUM_POA: rowRemove["NumPoa"],
                            COD_ESPECIES: rowRemove["CodEsp"],
                            COD_SECUENCIAL: rowRemove["CodSec"]
                        });
                    }
                }
                break;
            case "DTR":
            case "DTO":
            case "DAR":
                data["EstM"] = false;

                index = lstMuestra.findIndex(m=>m.CodDev == data["CodDev"] && m.CodEsp == data["CodEsp"] && m.CodSec == data["CodSec"]);
                if (index != -1) {
                    var rowRemove = ManNotificacion_Muestra.dtMuestra.row(index).data();

                    if (rowRemove["RegEst"] == 0) {
                        ManNotificacion_Muestra.tbEliTABLA.push({
                            COD_THABILITANTE: rowRemove["CodTh"],
                            COD_DEVOLUCION: rowRemove["CodDev"],
                            COD_ESPECIES: rowRemove["CodEsp"],
                            COD_SECUENCIAL: rowRemove["CodSec"]
                        });
                    }
                }
                break;
        }

        if (index != -1) {
            ManNotificacion_Muestra.dtMuestra.row(index).remove().draw(false);
            ManNotificacion_Muestra.dtNoMuestra.row($(obj).parents('tr')).data(data).draw(false);
            ManNotificacion_Muestra.fnSetCensoEspecieNoMuestra(data);

            var numEspecies = parseInt(ManNotificacion_Muestra.frm.find("#lblNumEspecieSelect").text()) - 1;
            ManNotificacion_Muestra.frm.find("#lblNumEspecieSelect").text(numEspecies);
        }
    } else if (origen == "MUESTRA") {
        var data = ManNotificacion_Muestra.dtMuestra.row($(obj).parents('tr')).data();
        var lstEspecie = [];
        ManNotificacion_Muestra.dtNoMuestra.rows().every(function () { lstEspecie.push(this.data()) })

        switch (ManNotificacion_Muestra.frm.find("#hdfTipoMuestra").val()) {
            case "M":
            case "NM":
                index = lstEspecie.findIndex(m=>m.CodTh == data["CodTh"] && m.NumPoa == data["NumPoa"] && m.CodEsp == data["CodEsp"] && m.CodSec == data["CodSec"]);

                if (index != -1) {
                    var rowRemove = ManNotificacion_Muestra.dtNoMuestra.row(index).data();
                    switch (rowRemove["NumM"]) {
                        case 1: rowRemove["EstM1"] = false; break;
                        case 2: rowRemove["EstM2"] = false; break;
                        case 3: rowRemove["EstM3"] = false; break;
                    }
                    ManNotificacion_Muestra.dtNoMuestra.row(index).data(rowRemove).draw(false);
                }

                if (data["RegEst"] == 0) {
                    ManNotificacion_Muestra.tbEliTABLA.push({
                        COD_FISNOTI: data["CodCn"],
                        COD_THABILITANTE: data["CodTh"],
                        NUM_POA: data["NumPoa"],
                        COD_ESPECIES: data["CodEsp"],
                        COD_SECUENCIAL: data["CodSec"]
                    });
                }
                switch (data["NumM"]) {
                    case 1: data["EstM1"] = false; break;
                    case 2: data["EstM2"] = false; break;
                    case 3: data["EstM3"] = false; break;
                }
                break;
            case "DTR":
            case "DTO":
            case "DAR":
                index = lstEspecie.findIndex(m=>m.CodDev == data["CodDev"] && m.CodEsp == data["CodEsp"] && m.CodSec == data["CodSec"]);

                if (index != -1) {
                    var rowRemove = ManNotificacion_Muestra.dtNoMuestra.row(index).data();
                    rowRemove["EstM"] = false;
                    ManNotificacion_Muestra.dtNoMuestra.row(index).data(rowRemove).draw(false);
                }

                if (data["RegEst"] == 0) {
                    ManNotificacion_Muestra.tbEliTABLA.push({
                        COD_THABILITANTE: data["CodTh"],
                        COD_DEVOLUCION: data["CodDev"],
                        COD_ESPECIES: data["CodEsp"],
                        COD_SECUENCIAL: data["CodSec"]
                    });
                }
                data["EstM"] = false;
                break;
        }

        ManNotificacion_Muestra.dtMuestra.row($(obj).parents('tr')).remove().draw(false);
        ManNotificacion_Muestra.fnSetCensoEspecieNoMuestra(data);
        var numEspecies = parseInt(ManNotificacion_Muestra.frm.find("#lblNumEspecieSelect").text()) - 1;
        ManNotificacion_Muestra.frm.find("#lblNumEspecieSelect").text(numEspecies);
    }
}

/*Buscar especies en el censo según los filtros de la UI*/
ManNotificacion_Muestra.fnSearchEspecieCenso = function () {
    var filtro = ManNotificacion_Muestra.frm.find("#ddlFiltroBusquedaId").val();
    var criterio = ManNotificacion_Muestra.frm.find("#ddlCriterioBusquedaId").val();
    var valor = ManNotificacion_Muestra.frm.find("#txtValorBusqueda").val();

    ManNotificacion_Muestra.dtNoMuestra.clear();
    ManNotificacion_Muestra.dtNoMuestra.rows.add(ManNotificacion_Muestra.fnSearchCenso(filtro, criterio, valor)).draw();
}
/*Recargar el listado del censo*/
ManNotificacion_Muestra.fnRefreshEspecieCenso = function () {
    ManNotificacion_Muestra.frm.find("#ddlFiltroBusquedaId").select2('val', ["TODOS"]);
    ManNotificacion_Muestra.frm.find("#ddlCriterioBusquedaId").select2('val', ["ESPECIE"]);
    ManNotificacion_Muestra.frm.find("#txtValorBusqueda").val("");

    ManNotificacion_Muestra.fnSearchEspecieCenso();
}
/*Seleccionar todas las especies mostradas en la tabla "LISTADO DE ESPECIES DEL CENSO" como parte de la muestra*/
ManNotificacion_Muestra.fnSelectAllListaEspecieMuestra = function () {
    var lstCenso = JSON.parse(sessionStorage.getItem('ListCNotificacionCenso'));
    var lstCensoFiltro = [], index = -1;
    var filtro = ManNotificacion_Muestra.frm.find("#ddlFiltroBusquedaId").val();
    var criterio = ManNotificacion_Muestra.frm.find("#ddlCriterioBusquedaId").val();
    var valor = ManNotificacion_Muestra.frm.find("#txtValorBusqueda").val();

    lstCensoFiltro = ManNotificacion_Muestra.fnSearchCenso(filtro, criterio, valor);

    if (lstCensoFiltro.length > 0) {
        switch (ManNotificacion_Muestra.frm.find("#hdfTipoMuestra").val()) {
            case "M":
            case "NM":
                $.each(lstCensoFiltro, function (i, o) {
                    index = lstCenso.findIndex(m=>m.CodTh == o["CodTh"] && m.NumPoa == o["NumPoa"] && m.CodEsp == o["CodEsp"] && m.CodSec == o["CodSec"]
                                                && ((m.NumM == 1 && m.EstM1 == false) || (m.NumM == 2 && m.EstM2 == false) || (m.NumM == 3 && m.EstM3 == false)));
                    if (index != -1) {
                        switch (lstCenso[index]["NumM"]) {
                            case 1: lstCenso[index]["EstM1"] = true; break;
                            case 2: lstCenso[index]["EstM2"] = true; break;
                            case 3: lstCenso[index]["EstM3"] = true; break;
                        }
                        lstCenso[index]["RegEst"] = 1;
                    }
                });
                break;
            case "DTR":
            case "DTO":
            case "DAR":
                $.each(lstCensoFiltro, function (i, o) {
                    index = lstCenso.findIndex(m=>m.CodDev == o["CodDev"] && m.CodEsp == o["CodEsp"] && m.CodSec == o["CodSec"] && m.EstM == false);
                    if (index != -1) {
                        lstCenso[index]["EstM"] = true;
                        lstCenso[index]["RegEst"] = 1;
                    }
                });
                break;
        }

        sessionStorage.setItem('ListCNotificacionCenso', JSON.stringify(lstCenso));
        
        //Cargar los datos
        var lstNoMuestra = [], lstMuestra = [];
        lstNoMuestra = ManNotificacion_Muestra.fnSearchCenso(filtro, criterio, valor);
        lstMuestra = ManNotificacion_Muestra.fnSearchCenso("MUESTRA", "", "");
        ManNotificacion_Muestra.dtMuestra.clear();
        ManNotificacion_Muestra.dtMuestra.rows.add(lstMuestra).draw();
        ManNotificacion_Muestra.dtNoMuestra.clear();
        ManNotificacion_Muestra.dtNoMuestra.rows.add(lstNoMuestra).draw();
        ManNotificacion_Muestra.frm.find("#lblNumEspecieSelect").text(lstMuestra.length);
    }
}
/*Quitar todas las especies mostradas en la tabla "LISTADO DE ESPECIES DEL CENSO" de la muestra*/
ManNotificacion_Muestra.fnRemoveAllListaEspecieMuestra = function () {
    var lstCenso = JSON.parse(sessionStorage.getItem('ListCNotificacionCenso'));
    var lstCensoFiltro = [], index = -1;
    var filtro = ManNotificacion_Muestra.frm.find("#ddlFiltroBusquedaId").val();
    var criterio = ManNotificacion_Muestra.frm.find("#ddlCriterioBusquedaId").val();
    var valor = ManNotificacion_Muestra.frm.find("#txtValorBusqueda").val();

    lstCensoFiltro = ManNotificacion_Muestra.fnSearchCenso(filtro, criterio, valor);

    if (lstCensoFiltro.length > 0) {
        switch (ManNotificacion_Muestra.frm.find("#hdfTipoMuestra").val()) {
            case "M":
            case "NM":
                $.each(lstCensoFiltro, function (i, o) {
                    index = lstCenso.findIndex(m=>m.CodTh == o["CodTh"] && m.NumPoa == o["NumPoa"] && m.CodEsp == o["CodEsp"] && m.CodSec == o["CodSec"]
                                                && ((m.NumM == 1 && m.EstM1 == true) || (m.NumM == 2 && m.EstM2 == true) || (m.NumM == 3 && m.EstM3 == true)));

                    if (index != -1) {
                        switch (lstCenso[index]["NumM"]) {
                            case 1: lstCenso[index]["EstM1"] = false; break;
                            case 2: lstCenso[index]["EstM2"] = false; break;
                            case 3: lstCenso[index]["EstM3"] = false; break;
                        }
                        if (lstCenso[index]["RegEst"] == 0) {
                            ManNotificacion_Muestra.tbEliTABLA.push({
                                COD_FISNOTI: o["CodCn"],
                                COD_THABILITANTE: o["CodTh"],
                                NUM_POA: o["NumPoa"],
                                COD_ESPECIES: o["CodEsp"],
                                COD_SECUENCIAL: o["CodSec"]
                            });
                        }
                    }
                });
                break;
            case "DTR":
            case "DTO":
            case "DAR":
                $.each(lstCensoFiltro, function (i, o) {
                    index = lstCenso.findIndex(m=>m.CodDev == o["CodDev"] && m.CodEsp == o["CodEsp"] && m.CodSec == o["CodSec"] && m.EstM == true);
                    if (index != -1) {
                        lstCenso[index]["EstM"] = false;

                        if (lstCenso[index]["RegEst"] == 0) {
                            ManNotificacion_Muestra.tbEliTABLA.push({
                                COD_THABILITANTE: o["CodTh"],
                                COD_DEVOLUCION: o["CodDev"],
                                COD_ESPECIES: o["CodEsp"],
                                COD_SECUENCIAL: o["CodSec"]
                            });
                        }
                    }
                });
                break;
        }

        sessionStorage.setItem('ListCNotificacionCenso', JSON.stringify(lstCenso));
        //Cargar los datos
        var lstNoMuestra = [], lstMuestra = [];
        lstNoMuestra = ManNotificacion_Muestra.fnSearchCenso(filtro, criterio, valor);
        lstMuestra = ManNotificacion_Muestra.fnSearchCenso("MUESTRA", "", "");
        ManNotificacion_Muestra.dtMuestra.clear();
        ManNotificacion_Muestra.dtMuestra.rows.add(lstMuestra).draw();
        ManNotificacion_Muestra.dtNoMuestra.clear();
        ManNotificacion_Muestra.dtNoMuestra.rows.add(lstNoMuestra).draw();
        ManNotificacion_Muestra.frm.find("#lblNumEspecieSelect").text(lstMuestra.length);
    }
}
/*Obtener las especies seleccionadas como parte de la muestra y que no estan registradas*/
ManNotificacion_Muestra.fnGetListEspecieSelect = function () {
    var list = [], lstMuestra = [];

    lstMuestra = ManNotificacion_Muestra.fnSearchCenso("MUESTRA", "", "");

    if (lstMuestra.length > 0) {
        switch (ManNotificacion_Muestra.frm.find("#hdfTipoMuestra").val()) {
            case "M":
            case "NM":
                $.each(lstMuestra, function (i, o) {
                    if (o["RegEst"] == 1) {
                        list.push({
                            RegEstado: o["RegEst"],
                            COD_THABILITANTE: o["CodTh"],
                            NUM_POA: o["NumPoa"],
                            COD_ESPECIES: o["CodEsp"],
                            COD_SECUENCIAL: o["CodSec"],
                            COD_FISNOTI: o["CodCn"]
                        });
                    }
                });
                break;
            case "DTR":
            case "DTO":
            case "DAR":
                $.each(lstMuestra, function (i, o) {
                    if (o["RegEst"] == 1) {
                        list.push({
                            RegEstado: o["RegEst"],
                            COD_THABILITANTE: o["CodTh"],
                            COD_DEVOLUCION: o["CodDev"],
                            COD_ESPECIES: o["CodEsp"],
                            COD_SECUENCIAL: o["CodSec"]
                        });
                    }
                });
                break;
        }
    }

    return list;
}

ManNotificacion_Muestra.fnSubmitForm = function () {
    utilSigo.dialogConfirm('', 'Desea continuar con el registro?', function (r) {
        if (r) {
            ManNotificacion_Muestra.fnSaveForm();
        }
    });
}

ManNotificacion_Muestra.fnSaveForm = function () {
    var datosMuestra = ManNotificacion_Muestra.frm.serializeObject();

    switch (ManNotificacion_Muestra.frm.find("#hdfTipoMuestra").val()) {
        case "M":
        case "NM": datosMuestra.tbMuestra = ManNotificacion_Muestra.fnGetListEspecieSelect(); break;
        case "DTR":
        case "DTO":
        case "DAR": datosMuestra.tbMuestraDevolucion = ManNotificacion_Muestra.fnGetListEspecieSelect(); break;
    }
    
    datosMuestra.tbEliTABLA = ManNotificacion_Muestra.tbEliTABLA;

    var option = { url: ManNotificacion_Muestra.frm.action, datos: JSON.stringify(datosMuestra), type: 'POST' };
    utilSigo.fnAjax(option, function (data) {
        if (data.success) {
            ManNotificacion_Muestra.fnReturnIndex(data.msj);
        }
        else {
            utilSigo.toastWarning("Aviso", data.msj);
        }
    });
}

ManNotificacion_Muestra.fnExportMuestra = function () {
    var rows, countFilas, data, numPendiente = 0;

    rows = ManNotificacion_Muestra.dtMuestra.$("tr");

    if (rows.length > 0) {
        $.each(rows, function (i, o) {
            data = ManNotificacion_Muestra.dtMuestra.row($(o)).data();
            if (data["RegEst"] == 1) {
                numPendiente++;
            }
        });

        if (numPendiente>0) {
            utilSigo.toastWarning("Aviso", "Hay cambios sin guardar, por favor guarde la muestra seleccionada para poder descargarla");
        } else {
            var url = urlLocalSigo + "Notificacion/ManNotificacion/ExportMuestra";
            var data = {
                asCodNotificacion: ManNotificacion_Muestra.frm.find("#hdfCodCNotificacion").val(),
                asTipoMuestra: ManNotificacion_Muestra.frm.find("#hdfTipoMuestra").val()
            };
            var option = { url: url, datos: JSON.stringify(data), type: 'POST' };

            utilSigo.fnAjax(option, function (data) {
                if (data.success) {
                    document.location = urlLocalSigo + "Archivos/Plantilla/" + data.msj;
                }
                else {
                    utilSigo.toastWarning("Aviso", "Sucedio un error, Comuníquese con el Administrador");
                    console.log(data.msj);
                }
            });
        }
    } else {
        utilSigo.toastWarning("Aviso","No existen especies del censo registrados en la muestra");
    }
}

ManNotificacion_Muestra.fnExportDatosGenerales = function () {
    var url = urlLocalSigo + "Notificacion/ManNotificacion/ExportDatosGenerales";
    var data = {
        asCodNotificacion: ManNotificacion_Muestra.frm.find("#hdfCodCNotificacion").val()
    };
    var option = { url: url, datos: JSON.stringify(data), type: 'POST' };

    utilSigo.fnAjax(option, function (data) {
        if (data.success) {
            document.location = urlLocalSigo + "Archivos/Plantilla/" + data.msj;
        }
        else {
            utilSigo.toastWarning("Aviso", "Sucedio un error, Comuníquese con el Administrador");
            console.log(data.msj);
        }
    });
}

ManNotificacion_Muestra.fnGoToSISFOR = function () {
    switch (ManNotificacion_Muestra.frm.find("#hdfTipoMuestra").val()) {
        case "M":
            window.open("https://sisfor.osinfor.gob.pe/visor/geoFNMAD/" + ManNotificacion_Muestra.frm.find("#hdfCodCNotificacion").val(), "_blank");
            break;
    }
}

ManNotificacion_Muestra.fnImportMuestra = function (e, obj) {
    var url = urlLocalSigo + "Notificacion/ManNotificacion/ImportMuestra";
    uploadFile.fileSelectHandler(e, obj, url, {
        asCodNotificacion: ManNotificacion_Muestra.frm.find("#hdfCodCNotificacion").val(),
        asTipoMuestra:ManNotificacion_Muestra.frm.find("#hdfTipoMuestra").val()
    }, function (data) {
        sessionStorage.setItem('ListCNotificacionCenso', JSON.stringify(data));

        var lstNoMuestra = [], lstMuestra = [];
        lstNoMuestra = ManNotificacion_Muestra.fnSearchCenso("NO_MUESTRA", "", "");
        lstMuestra = ManNotificacion_Muestra.fnSearchCenso("MUESTRA", "", "");

        ManNotificacion_Muestra.dtMuestra.clear();
        ManNotificacion_Muestra.dtMuestra.rows.add(lstMuestra).draw();
        ManNotificacion_Muestra.dtNoMuestra.clear();
        ManNotificacion_Muestra.dtNoMuestra.rows.add(lstNoMuestra).draw();
        ManNotificacion_Muestra.frm.find("#lblNumEspecieSelect").text(lstMuestra.length);
    });
}

$(document).ready(function () {
    ManNotificacion_Muestra.frm = $("#frmManNotificacion_Muestra");

    $.fn.select2.defaults.set("theme", "bootstrap4");
    ManNotificacion_Muestra.frm.find("#ddlFiltroBusquedaId").select2({ minimumResultsForSearch: -1 });
    ManNotificacion_Muestra.frm.find("#ddlCriterioBusquedaId").select2({ minimumResultsForSearch: -1 });

    ManNotificacion_Muestra.frm.find("#ddlFiltroBusquedaId").select2("val", ["NO_MUESTRA"]);

    switch(ManNotificacion_Muestra.frm.find("#hdfTipoMuestra").val()) {
        case "DTR":
        case "DTO":
        case "DAR":
            $("#dvManCNot_Muestra_Import").hide();
            $("#dvManCNot_Muestra_Export").hide();
            $("#dvManCNot_Muestra_Remove").hide();
            break;
    }

    $('[data-toggle="tooltip"]').tooltip();

    ManNotificacion_Muestra.fnInitDataTable_Detail();

    ManNotificacion_Muestra.fnGetCenso();

    ManNotificacion_Muestra.frm.submit(function (e) {
        ManNotificacion_Muestra.fnSearchEspecieCenso();
        e.preventDefault();
    });
});