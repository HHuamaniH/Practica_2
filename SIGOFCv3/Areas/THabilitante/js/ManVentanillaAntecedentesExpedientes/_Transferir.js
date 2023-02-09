"use strict";
var _transf = {
    StorageConfig: () => {
        //configurando almacenamiento temporal
        var lstConfig = [], config = {}, index = -1;
        if (JSON.parse(sessionStorage.getItem('configBusquedaEx')) == null) {
            sessionStorage.setItem('configBusquedaEx', JSON.stringify(lstConfig));
        }
        lstConfig = JSON.parse(sessionStorage.getItem('configBusquedaEx'));
        config = { rowTH: rowTransferir, TipoFormulario: "AEXPEDIENTE_SITD_ROW" };
        index = lstConfig.findIndex(m => m.TipoFormulario == "AEXPEDIENTE_SITD_ROW");
        if (index != -1) { lstConfig[index] = config; }
        else { lstConfig.push(config); }
        sessionStorage.setItem('configBusquedaEx', JSON.stringify(lstConfig));
    },
    TH_Sincronizar: (codigoTH, numeroTH) => {
        var url = urlLocalSigo + "THabilitante/ManVentanillaAntecedentesExpedientes/SincronizarSITD_TH";
        var model = { COD_AEXPEDIENTE_SITD: rowTransferir.COD_AEXPEDIENTE_SITD, COD_TRAMITE_SITD: rowTransferir.COD_TRAMITE_SITD, codTH: codigoTH, numTH: numeroTH, codRef: _transf.frm.find("#COD_DREFERENCIA").val() };
        var option = { url: url, datos: model, type: 'GET' };
        utilSigo.fnAjax(option, function (data) {
            if (data.success) {
                $("#transferirModal").modal('hide');
                anteExpedientes.dtManGrillaPaging.ajax.reload();
                anteExpedientes.fnTransferirModal(rowTransferir, 1);
                utilSigo.toastSuccess("Aviso", data.msj);
            } else {
                utilSigo.toastWarning("Aviso", data.msj);
            }
        });
    },
    Get_Estado_Origen: (codReferencia) => {
        var estadoOrigen = "";
        switch (codReferencia) {
            case "0204": estadoOrigen = "PN"; break;//POA/PO
            case "0402": estadoOrigen = "DEMA2"; break;//DEMA                
            case "0245": estadoOrigen = "PC"; break;//PCM   //PC
            case "0244": estadoOrigen = "PCN"; break;//PCNM  //PCN
            case "0202": estadoOrigen = "MS"; break;//MS    //MS
            case "0203": estadoOrigen = "R"; break;//REING //R
            case "0246": estadoOrigen = "REFOR"; break;//REFOR //REFOR
            case "0247": estadoOrigen = "REAJU"; break;//REAJUS//REAJU
            case "0301": estadoOrigen = "--"; break;//BEXT  //--
        }
        return estadoOrigen;
    },
    PM_Sincronizar: () => {
        var url = urlLocalSigo + "THabilitante/ManVentanillaAntecedentesExpedientes/SincronizarSITD_PLAN_MANEJO";
        var coddReferencia = _transf.frm.find("#COD_DREFERENCIA").val();
        var codigoPlanManejo = "";
        var numPoa = 0;
        switch (coddReferencia) {
            case "0401":
            case "0404":
                codigoPlanManejo = _transf.frm.find("#COD_PGMF").val().trim();
                break;
            case "0403":
                codigoPlanManejo = _transf.frm.find("#COD_PMANEJO").val().trim();
                break;
            case "0204"://POA/PO
            case "0402"://DEMA
                codigoPlanManejo = _transf.frm.find("#ItemCodTHabilitante").val().trim();
                numPoa = _transf.frm.find("#ItemNumPoa").val().trim();
                break;
        }
        var model = { COD_AEXPEDIENTE_SITD: rowTransferir.COD_AEXPEDIENTE_SITD, COD_TRAMITE_SITD: rowTransferir.COD_TRAMITE_SITD, COD_DREFERENCIA: coddReferencia, CODIGO: codigoPlanManejo, numPoa: numPoa };
        var option = { url: url, datos: model, type: 'GET' };
        utilSigo.fnAjax(option, function (data) {
            if (data.success) {
                $("#transferirModal").modal('hide');
                anteExpedientes.dtManGrillaPaging.ajax.reload();
                anteExpedientes.fnTransferirModal(rowTransferir, 1);
                utilSigo.toastSuccess("Aviso", data.msj);
            } else {
                utilSigo.toastWarning("Aviso", data.msj);
            }
        });
    },
    TH_Sincronizar_: () => {
        var url = urlLocalSigo + "THabilitante/ManVentanillaAntecedentesExpedientes/ValidarExisteTH";
        var option = { url: url, datos: { numTHabilitante: rowTransferir.NUM_THABILITANTE }, type: 'GET' };
        utilSigo.fnAjax(option, function (data) {
            if (data.success) {
                //cuando existe
                if (data.existe) {
                    _transf.TH_Sincronizar(data.item.CODIGO, data.item.NUMERO);
                }
            } else {
                utilSigo.toastWarning("Aviso", data.msj);
            }
        });
    },
    TH_EXISTE: () => {
        if (_transf.frm.find("#cboModalidadTransId").val() == "-") {
            _transf.frm.find("#cboModalidadTransId").focus();
            utilSigo.toastWarning("Aviso", "Seleccione la modalidad del Título Habilitante");
            return false;
        }
        //primero vemos si el titulo habilitante existe
        /*var url = urlLocalSigo + "THabilitante/ManVentanillaAntecedentesExpedientes/ValidarExisteTH";
        var option = { url: url, datos: { numTHabilitante: rowTransferir.NUM_THABILITANTE}, type: 'GET' };
        utilSigo.fnAjax(option, function (data) {
            if (data.success) {
                //cuando existe
                if (data.existe) {
                    bootbox.confirm({
                        message: "Existe el Título Habilitante. Desea sincronizar la información para poder continuar?",
                        buttons: {
                            confirm: {
                                label: 'SI',
                                className: 'btn-success'
                            },
                            cancel: {
                                label: 'NO',
                                className: 'btn-danger'
                            }
                        },
                        callback: function (result) {
                            if (result) {
                                _transf.TH_Sincronizar(data.item.CODIGO, data.item.NUMERO);
                            }
                        }
                    });
                } else {
                    _transf.TTH('TH');
                }
            }else{
                utilSigo.toastWarning("Aviso", data.msj);
            }
        });*/

        _transf.TTH('TH');
    },
    TTH: (tipo) => {
        var appClient = "SIGOsfc_VentanillaSITD|TRANSFERIR|" + tipo;
        var appData = rowTransferir.COD_AEXPEDIENTE_SITD        //[0]
            + "¬" + rowTransferir.COD_TRAMITE_SITD     //[1]
            + "¬" + rowTransferir.COD_DREFERENCIA;      //[2]

        if (tipo == "TH") {
            appData += "¬" + rowTransferir.NUM_THABILITANTE   //[3]
                + "¬" + rowTransferir.RESOLUCION_POA       //[4]
                + "¬" + _transf.frm.find("#txtItemObservacionTransferir").val().trim() //[5]
                + "¬" + _transf.frm.find("#cboModalidadTransId").val();    //[6-10]
        } else {//ADENDA
            if (_transf.frm.find("#ItemCodTHabilitante").val().trim() != "") {
                appData += "¬" + _transf.frm.find("#ItemCodTHabilitante").val().trim()   //[3]
                    + "¬" + _transf.frm.find("#txtItemObservacionTransferir").val().trim(); //[4
            }
            else {
                utilSigo.toastWarning("Aviso", "Primero debe transferir los datos del Título Habilitante");
                return false;
            }
        }

        var url = urlLocalSigo + "THabilitante/ManTHabilitante/Index";
        //guardando configuracion de la tabla
        anteExpedientes.fnConfig();
        _transf.StorageConfig();
        document.location = url + "?appClient=" + appClient + "&appData=" + appData;
    },
    ValidarTransferirPM: (params) => {
        var url = "";
        var bandera = 0;
        if (params.COD_THABILITANTE != "") {
            var appClient = "SIGOsfc_VentanillaSITD|TRANSFERIR|PLAN";
            switch (params.COD_DREFERENCIA) {
                case "0401"://PGMF
                    url = "THabilitante/ManPlanManejoForestal/AddEdit?appClient=" + appClient + "&opt=0";
                    break;
                /*case "0404"://PMFI
                    url = "THabilitante/ManPlanManejoForestal/AddEdit?appClient=" + appClient + "&opt=1";
                    break;*/
                case "0403"://Plan Manejo (Fauna)
                    url = "THabilitante/ManPlanManejo/AddEditPM?appClient=" + appClient;
                    break;
                case "0204"://POA/PO
                case "0402"://DEMA
                case "0404"://PMFI
                    //var lstManMenu = params.COD_DREFERENCIA == "0204" ? "1" : "2";
                    var lstManMenu = "";
                    switch (params.COD_DREFERENCIA) {
                        case "0204": lstManMenu = "1"; break;
                        case "0402": lstManMenu = "2"; break;
                        case "0404": lstManMenu = "3"; break;
                    }
                    url = "THabilitante/ManPOA/AddEdit?lstManMenu=" + lstManMenu + "&appClient=" + appClient;
                    break;
                case "0245"://PCM   //PC
                case "0244"://PCNM  //PCN
                case "0202"://MS    //MS
                case "0203"://REING //R
                case "0246"://REFOR //REFOR
                case "0247"://REAJUS//REAJU
                case "0301"://BEXT  //--
                    var cboPadre = _transf.frm.find("#ddlItemPoaPadreId").val();
                    if (cboPadre == "-") {
                        bandera = 1;
                        utilSigo.toastWarning("Aviso", "Seleccione el Plan de Manejo Padre");

                    }
                    if (cboPadre == "0") {
                        url = "THabilitante/ManPOA/AddEdit?lstManMenu=1" + "&appClient=" + appClient;
                    } else {
                        bandera = 1;
                    }
                    break;
            }
            url = urlLocalSigo + url + "&appData=" + params.appData;
            if (bandera == 0) {
                anteExpedientes.fnConfig();
                _transf.StorageConfig();
                document.location = url;
            }
        }
        else utilSigo.toastWarning("Aviso", "Primero debe transferir los datos del Título Habilitante");
    },
    PMAsociar: () => {

        var NUM_POA = _transf.frm.find("#ddlItemPoaPadreId").val();
        var NUM_POA2 = _transf.frm.find("#ItemNumPoa").val();
        var band = 0;

        var COD_AEXPEDIENTE_SITD = rowTransferir.COD_AEXPEDIENTE_SITD;
        var COD_TRAMITE_SITD = rowTransferir.COD_TRAMITE_SITD;
        var COD_DREFERENCIA = rowTransferir.COD_DREFERENCIA;
        var COD_THABILITANTE = _transf.frm.find("#ItemCodTHabilitante").val();
        var NUM_THABILITANTE = rowTransferir.NUM_THABILITANTE;
        var RESOLUCION_POA = rowTransferir.RESOLUCION_POA;
        var COD_PGMF = _transf.frm.find("#COD_PGMF").val();
        var COD_PMANEJO = _transf.frm.find("#COD_PMANEJO").val();
        if (NUM_POA2 != "") {
            NUM_POA = NUM_POA2;
        }

        var model = {
            NUM_POA,
            COD_AEXPEDIENTE_SITD,
            COD_TRAMITE_SITD,
            COD_DREFERENCIA,
            COD_THABILITANTE,
            NUM_THABILITANTE,
            RESOLUCION_POA,
            COD_PGMF,
            COD_PMANEJO
        }
        if (NUM_POA != null) {
            if (NUM_POA.trim() != '-' && NUM_POA != 0) {
                band = 1;
            }
        }
        if (COD_PGMF != null) {
            if (COD_PGMF.trim() != '') {
                band = 1;
            }
        }
        if (COD_PMANEJO != null) {
            if (COD_PMANEJO.trim() != '') {
                band = 1;
            }
        }

        if (band == 1) {
            let url = urlLocalSigo + "THabilitante/ManVentanillaAntecedentesExpedientes/asociarPM";
            let option = { url: url, datos: JSON.stringify(model), type: 'POST' };
            utilSigo.fnAjax(option, function (data) {
                if (data.success) {
                    // window.location = `${urlLocalSigo}/THabilitante/ManVentanillaAntecedentesExpedientes/Index`;
                    /*utilSigo.toastSuccess("Éxito", "Datos actualizados correctamente");*/

                    $("#transferirModal").modal('hide');
                    anteExpedientes.dtManGrillaPaging.ajax.reload();
                    utilSigo.toastSuccess("Aviso", data.msj);
                }
                else {
                    utilSigo.toastWarning("Aviso", data.msj);
                }
            });
        }
        else {
            utilSigo.toastWarning("Aviso", "Seleccionar Plan de Manejo o transferir la resolución de aprobación del plan de manejo");
        }

    },
    TPM: () => {
        var appData = rowTransferir.COD_AEXPEDIENTE_SITD //[0]
            + "¬" + rowTransferir.COD_TRAMITE_SITD       //[1]
            + "¬" + rowTransferir.COD_DREFERENCIA        //[2]
            + "¬" + _transf.frm.find("#ItemCodTHabilitante").val()//data.COD_TH                          //[3]
            + "¬" + rowTransferir.NUM_THABILITANTE       //[4]
            + "¬" + rowTransferir.RESOLUCION_POA         //[5]
            + "¬" + _transf.frm.find("#txtItemObservacionTransferir").val().trim() //[6]      
            + "¬" + _transf.frm.find("#COD_PGMF").val()//data.COD_PGMF                          //[7] 
            + "¬" + _transf.frm.find("#COD_PMANEJO").val();// data.COD_PMANEJO;                     //[8]
        var params = { appData: appData, COD_AEXPEDIENTE_SITD: rowTransferir.COD_AEXPEDIENTE_SITD, COD_TRAMITE_SITD: rowTransferir.COD_TRAMITE_SITD, COD_DREFERENCIA: rowTransferir.COD_DREFERENCIA, COD_THABILITANTE: _transf.frm.find("#ItemCodTHabilitante").val() };

        _transf.ValidarTransferirPM(params);
    },
    TPMACTO: () => {
        var codTH = _transf.frm.find("#ItemCodTHabilitante").val().trim();
        var cboPadre = _transf.frm.find("#ddlItemPoaPadreId").val();

        if (codTH != "") {
            if (cboPadre == "-" || cboPadre == "0") {
                utilSigo.toastWarning("Aviso", "Seleccione el Plan de Manejo Padre");
                return false;
            }
            var url = "";
            var bandera = 1;
            var appClient = "SIGOsfc_VentanillaSITD|TRANSFERIR|ACTO";
            var appData = rowTransferir.COD_AEXPEDIENTE_SITD    //[0]
                + "¬" + rowTransferir.COD_TRAMITE_SITD     //[1]
                + "¬" + rowTransferir.COD_DREFERENCIA      //[2]
                + "¬" + codTH                         //[3]
                + "¬" + rowTransferir.NUM_THABILITANTE     //[4]
                + "¬" + rowTransferir.RESOLUCION_POA       //[5]
                + "¬" + _transf.frm.find("#txtItemObservacionTransferir").val().trim()//[6]
                + "¬" + cboPadre;                          //[7]

            switch (rowTransferir.COD_DREFERENCIA) {
                case "0245"://PCM
                case "0244"://PCNM
                case "0202"://MS
                case "0203"://REING
                case "0246"://REFOR
                case "0247"://REAJUS  
                    var lstManMenu = "1";
                    if (_transf.frm.find("#ddlItemPoaPadreId option:selected").text().split('|')[2] == "PMFI") {
                        lstManMenu = "3";
                    }
                    url = "THabilitante/ManPOA/AddEdit?lstManMenu=" + lstManMenu + "&appClient=" + appClient + "&appData=" + appData;
                    bandera = 0;
                    break;
            }
            if (bandera == 0) {
                anteExpedientes.fnConfig();
                _transf.StorageConfig();
                document.location = urlLocalSigo + url;
            }
        } else {
            utilSigo.toastWarning("Aviso", "Primero debe transferir los datos del Título Habilitante");
        }
    },
    TBEXTRA: () => {
        var codTh = _transf.frm.find("#ItemCodTHabilitante").val().trim();
        var itemPoaPadre = _transf.frm.find("#ddlItemPoaPadreId").val();
        var fecha = _transf.frm.find("#txtItemFecEmiBExtraccion").val().trim();
        var obs = _transf.frm.find("#txtItemObservacionTransferir").val().trim();
        if (codTh == "") {
            utilSigo.toastWarning("Aviso", "Primero debe transferir los datos del Título Habilitante");
            return false;
        }
        if (fecha == "") {
            utilSigo.toastWarning("Aviso", "Seleccione la fecha de emisión del Balance de Extracción");
            return false;
        }
        if (itemPoaPadre == "-" || itemPoaPadre == "0") {
            utilSigo.toastWarning("Aviso", "Seleccione el Plan de Manejo Padre");
            return false;
        }
        var model = { COD_TH: codTh, COD_DREF: rowTransferir.COD_DREFERENCIA, COD_AEXP: rowTransferir.COD_AEXPEDIENTE_SITD, COD_TRAM: rowTransferir.COD_TRAMITE_SITD, cboPadre: itemPoaPadre, fecha: fecha, obs: obs };
        var url = urlLocalSigo + "THabilitante/ManVentanillaAntecedentesExpedientes/BExtraccionTransferir";
        var option = { url: url, datos: JSON.stringify(model), type: 'POST' };
        utilSigo.fnAjax(option, function (data) {
            if (data.success) {
                $("#transferirModal").modal('hide');
                anteExpedientes.dtManGrillaPaging.ajax.reload();
                utilSigo.toastSuccess("Aviso", data.msj);
            } else {
                anteExpedientes.fnTransferirModal(rowTransferir, 1);
                utilSigo.toastWarning("Aviso", data.msj);
            }
        });
    },
    Anular: () => {
        utilSigo.dialogConfirm('', 'Esta seguro de continuar con la anulación?', function (r) {
            if (r) {
                var url = urlLocalSigo + "THabilitante/ManVentanillaAntecedentesExpedientes/AnularDocumentoTramite";
                var option = { url: url, datos: { COD_AEXPEDIENTE_SITD: _transf.frm.find("#COD_AEXPEDIENTE_SITD").val(), COD_TRAMITE_SITD: _transf.frm.find("#COD_TRAMITE_SITD").val(), obs: _transf.frm.find("#txtItemObservacionTransferir").val(), codRef: _transf.frm.find("#COD_DREFERENCIA").val() }, type: 'GET' };
                utilSigo.fnAjax(option, function (data) {
                    if (data.success) {
                        $("#transferirModal").modal('hide');
                        anteExpedientes.dtManGrillaPaging.ajax.reload();
                        utilSigo.toastSuccess("Aviso", data.msj);
                    } else {
                        utilSigo.toastWarning("Aviso", data.msj);
                    }
                });
            }
        });
    },
    fnCloseModal: () => {
        utilSigo.fnCloseModal("transferirModal");
    }
};
$(function () {
    _transf.frm = $("#frmTransferir");
    _transf.frm.find("#ddlItemPoaPadreId").change(function () {
        if ($(this).val() == "0" || $(this).val() == "-") {
            $("#pnlItemPlanManejoTransferir").show();
            $("#pnlItemMsjPoaTransferir").hide();
        } else {
            $("#pnlItemPlanManejoTransferir").hide();
            $("#pnlItemMsjPoaTransferir").show();
        }
    });
    _transf.frm.find("#ItemResolucionPoa").val(rowTransferir.RESOLUCION_POA);
    _transf.frm.find("#ItemResolActoAdmin").val(rowTransferir.RESOLUCION_POA);
    utilSigo.fnFormatDate(_transf.frm.find("#txtItemFecEmiBExtraccion"));

});