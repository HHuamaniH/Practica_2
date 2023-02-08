
"use strict";
var ManCNotificacion_Muestra = {};
/*Variables globales*/
ManCNotificacion_Muestra.tbEliTABLA = [];

ManCNotificacion_Muestra.DATA = [];

ManCNotificacion_Muestra.fnReturnIndex = function (alertaInicial) {
	var url = urlLocalSigo + "Supervision/ManCNotificacion/Index";

	//sessionStorage.removeItem("ListCNotificacionCenso");

	if (alertaInicial == null || alertaInicial == "") {
		window.location = url;
	} else {
		window.location = url + "?_alertaIncial=" + alertaInicial;
	}
}

ManCNotificacion_Muestra.fnViewModalMuestra = function () {
	utilSigo.modalDraggable($("#mdlManCNot_Muestra_Muestra"), '.modal-header');
	$("#mdlManCNot_Muestra_Muestra").modal({ keyboard: true, backdrop: 'static' });
}

ManCNotificacion_Muestra.fnInitDataTable_Detail = function () {
	var columns_label = [], columns_data = [], options = {}, data_extend = [];

    var tipoMuestra = ManCNotificacion_Muestra.frm.find("#hdfTipoMuestra").val();
    switch (tipoMuestra) {
        case "M":
        case "NM":
            if (tipoMuestra=="M") {
                columns_label = ["POA", "Especie Censo", "Especie Resolución", "Bloque PCA", "Faja", "Código", "Volumen", "DAP", "AC", "DMC"
                    , "Condición", "Estado", "Zona UTM", "Coord. Este", "Coord. Norte", "PC"];
                columns_data = ["Poa", "EspCenso", "EspResol", "Bloq", "Faja", "Cod", "Vol", "Dap", "Ac", "Dmc"
                    , "EspCond", "EspEst", "Zona", "CEste", "CNorte", "PCA"];
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
							return '<i class="fa fa-lg fa-ban" style="cursor:pointer;color:red;font-size:18px;" title="Quitar especie de la muestra" onclick="ManCNotificacion_Muestra.fnRemoveEspecieMuestra(this,\'NO_MUESTRA\');"></i>';
						} else {
							return '<i class="fa fa-lg fa-check" style="cursor:pointer;color:limegreen;font-size:18px;" title="Seleccionar especie a la muestra" onclick="ManCNotificacion_Muestra.fnSelectEspecieMuestra(this);"></i>';
						}
					}
				}
			];
			options = {
				page_length: 50, page_info: true, row_index: true, data_extend: data_extend, page_render: true
			};
			ManCNotificacion_Muestra.dtNoMuestra = utilDt.fnLoadDataTable_Detail($("#tbManCNot_Muestra_NoMuestra"), columns_label, columns_data, options);

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
				page_length: 50, page_info: true, row_index: true, row_delete: true, row_fnDelete: "ManCNotificacion_Muestra.fnRemoveEspecieMuestra(this,\'MUESTRA\')"
				, data_extend: data_extend, page_search: true, page_render: true
			};
			ManCNotificacion_Muestra.dtMuestra = utilDt.fnLoadDataTable_Detail($("#tbManCNot_Muestra_Muestra"), columns_label, columns_data, options);
			break;
		case "DTR":
		case "DTO":
		case "DAR":
			if (tipoMuestra == "DTR") {
				columns_label = ["Especie", "Código", "DAP", "Altura", "Volumen", "Coord. Este", "Coord. Norte"
					, "N° Trozas", "Descripción", "Observación"];
				columns_data = ["Esp", "Cod", "Dap", "Alt", "Vol", "CEste", "CNorte", "NumTro", "Desc", "Obs"];
			} else if (tipoMuestra == "DTO") {
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
							return '<i class="fa fa-lg fa-ban" style="cursor:pointer;color:red;font-size:18px;" title="Quitar especie de la muestra" onclick="ManCNotificacion_Muestra.fnRemoveEspecieMuestra(this,\'NO_MUESTRA\');"></i>';
						} else {
							return '<i class="fa fa-lg fa-check" style="cursor:pointer;color:limegreen;font-size:18px;" title="Seleccionar especie a la muestra" onclick="ManCNotificacion_Muestra.fnSelectEspecieMuestra(this);"></i>';
						}
					}
				}
			];
			options = {
				page_length: 50, page_info: true, row_index: true, data_extend: data_extend, page_render: true
			};
			ManCNotificacion_Muestra.dtNoMuestra = utilDt.fnLoadDataTable_Detail($("#tbManCNot_Muestra_NoMuestra"), columns_label, columns_data, options);

			options = {
				page_length: 50, page_info: true, row_index: true, row_delete: true, row_fnDelete: "ManCNotificacion_Muestra.fnRemoveEspecieMuestra(this,\'MUESTRA\')"
				, page_search: true, page_render: true
			};
			ManCNotificacion_Muestra.dtMuestra = utilDt.fnLoadDataTable_Detail($("#tbManCNot_Muestra_Muestra"), columns_label, columns_data, options);
			break;
	}
}

/*Obtener todo el CENSO asociado a la Carta de Notificación*/
ManCNotificacion_Muestra.fnGetCenso = function () {
	//sessionStorage.removeItem("ListCNotificacionCenso");
	var url = urlLocalSigo + "Supervision/ManCNotificacion/GetCenso";
	var option = { url: url + "?asCodCNotificacion=" + ManCNotificacion_Muestra.frm.find("#hdfCodCNotificacion").val() + "&asTipoMuestra=" + ManCNotificacion_Muestra.frm.find("#hdfTipoMuestra").val() };
	utilSigo.fnAjax(option, function (data) {
		if (data.success) {
			/*Guardar todo el CENSO en local*/
			if (window.sessionStorage) {
				//sessionStorage.setItem('ListCNotificacionCenso', JSON.stringify(data.data));
				ManCNotificacion_Muestra.DATA = data.data;

				var lstNoMuestra = [], lstMuestra = [];
				lstNoMuestra = ManCNotificacion_Muestra.fnSearchCenso("NO_MUESTRA", "", "");
				lstMuestra = ManCNotificacion_Muestra.fnSearchCenso("MUESTRA", "", "");

				ManCNotificacion_Muestra.dtMuestra.rows.add(lstMuestra).draw();
				ManCNotificacion_Muestra.dtNoMuestra.rows.add(lstNoMuestra).draw();
				ManCNotificacion_Muestra.frm.find("#lblNumEspecieSelect").text(lstMuestra.length);
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
ManCNotificacion_Muestra.fnSearchCenso = function (_filtro, _criterio, _valor) {
	var lstBusFiltro = [], lstBusCriterio = [];
	var lstCenso = ManCNotificacion_Muestra.DATA; //JSON.parse(sessionStorage.getItem('ListCNotificacionCenso'));
	/*Cada filtro se puede poner en una función --probar*/
	switch (ManCNotificacion_Muestra.frm.find("#hdfTipoMuestra").val()) {
		case "M":
		case "NM":
			switch (_filtro) {
				case "MUESTRA":
					lstBusFiltro = lstCenso.filter(m => (m.NumM == 1 && m.EstM1 == true) || (m.NumM == 2 && m.EstM2 == true) || (m.NumM == 3 && m.EstM3 == true));
					break;
				case "NO_MUESTRA":
					lstBusFiltro = lstCenso.filter(m => (m.NumM == 1 && m.EstM1 == false) || (m.NumM == 2 && m.EstM2 == false) || (m.NumM == 3 && m.EstM3 == false));
					break;
				case "COND_APROVECHABLE": lstBusFiltro = lstCenso.filter(m => m.EspCond == "Aprovechable"); break;
				case "COND_SEMILLERO": lstBusFiltro = lstCenso.filter(m => m.EspCond == "Semillero"); break;
				case "COND_PRODUCTIVO": lstBusFiltro = lstCenso.filter(m => m.EspCond == "Productivo"); break;
				case "COND_NO_PRODUCTIVO": lstBusFiltro = lstCenso.filter(m => m.EspCond == "No Productivo"); break;
				default: lstBusFiltro = lstCenso; break;
			}
			if (_valor == "") {
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
				case "MUESTRA": lstBusFiltro = lstCenso.filter(m => m.EstM == true); break;
				case "NO_MUESTRA": lstBusFiltro = lstCenso.filter(m => m.EstM == false); break;
				default: lstBusFiltro = lstCenso; break;
			}
			if (_valor == "") {
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
ManCNotificacion_Muestra.fnSetCensoEspecieMuestra = function (data) {
	var lstCenso = ManCNotificacion_Muestra.DATA; //JSON.parse(sessionStorage.getItem('ListCNotificacionCenso'));
	var index = -1;

	switch (ManCNotificacion_Muestra.frm.find("#hdfTipoMuestra").val()) {
		case "M":
		case "NM":
			index = lstCenso.findIndex(m => m.CodTh == data["CodTh"] && m.NumPoa == data["NumPoa"] && m.CodEsp == data["CodEsp"] && m.CodSec == data["CodSec"]);
			if (index != -1) {
				lstCenso[index] = data;
			}
			break;
		case "DTR":
		case "DTO":
		case "DAR":
			index = lstCenso.findIndex(m => m.CodDev == data["CodDev"] && m.CodEsp == data["CodEsp"] && m.CodSec == data["CodSec"]);
			if (index != -1) {
				lstCenso[index] = data;
			}
			break;
	}

	ManCNotificacion_Muestra.DATA = lstCenso;
	//sessionStorage.setItem('ListCNotificacionCenso', JSON.stringify(lstCenso));
}
/*Quitar la especie del censo de la muestra*/
ManCNotificacion_Muestra.fnSetCensoEspecieNoMuestra = function (data) {
	var lstCenso = ManCNotificacion_Muestra.DATA; //JSON.parse(sessionStorage.getItem('ListCNotificacionCenso'));
	var index = -1;

	switch (ManCNotificacion_Muestra.frm.find("#hdfTipoMuestra").val()) {
		case "M":
		case "NM":
			index = lstCenso.findIndex(m => m.CodTh == data["CodTh"] && m.NumPoa == data["NumPoa"] && m.CodEsp == data["CodEsp"] && m.CodSec == data["CodSec"]);
			if (index != -1) {
				lstCenso[index] = data;
			}
			break;
		case "DTR":
		case "DTO":
		case "DAR":
			index = lstCenso.findIndex(m => m.CodDev == data["CodDev"] && m.CodEsp == data["CodEsp"] && m.CodSec == data["CodSec"]);
			if (index != -1) {
				lstCenso[index] = data;
			}
			break;
	}

	ManCNotificacion_Muestra.DATA = lstCenso;
	//sessionStorage.setItem('ListCNotificacionCenso', JSON.stringify(lstCenso));
}

/*Seleccionar todo el censo como muestra y grabar*/
ManCNotificacion_Muestra.fnSaveCensoAsMuestra = function () {
	utilSigo.dialogConfirm('', 'Está seguro de seleccionar todo el censo como la muestra?', function (r) {
		if (r) {
			var url = urlLocalSigo + "SUPERVISION/ManCNotificacion/SaveCensoAsMuestra";
			var datos = {
				asCodCNotificacion: ManCNotificacion_Muestra.frm.find("#hdfCodCNotificacion").val(),
				asTipoMuestra: ManCNotificacion_Muestra.frm.find("#hdfTipoMuestra").val()
			};
			var option = { url: url, datos: JSON.stringify(datos), type: 'POST' };
			utilSigo.fnAjax(option, function (data) {
				if (data.success) {
					ManCNotificacion_Muestra.fnReturnIndex(data.msj);
				}
				else {
					utilSigo.toastWarning("Aviso", data.msj);
				}
			});
		}
	});
}
/*Quilar toda la muestra seleccionada*/
ManCNotificacion_Muestra.fnRemoveMuestra = function () {
	utilSigo.dialogConfirm('', 'Está seguro de eliminar toda la muestra seleccionada?', function (r) {
		if (r) {
			var lstCenso = ManCNotificacion_Muestra.DATA; //JSON.parse(sessionStorage.getItem('ListCNotificacionCenso'));

			switch (ManCNotificacion_Muestra.frm.find("#hdfTipoMuestra").val()) {
				case "M":
				case "NM":
					lstCenso = lstCenso.map(function (m) {
						switch (m.NumM) {
							case 1: m.EstM1 = false; break;
							//case 1: m.EstM1 = false; break;
							//case 1: m.EstM1 = false; break;
						}
						return m;
					});
					break;
				case "DTR":
				case "DTO":
				case "DAR":
					lstCenso = lstCenso.map(function (m) { m.EstM = false; return m; }); break;
			}

			ManCNotificacion_Muestra.DATA = lstCenso;
			//sessionStorage.setItem('ListCNotificacionCenso', JSON.stringify(lstCenso));
			ManCNotificacion_Muestra.frm.find("#hdfRemoveAllMuestraSelect").val(true);
			ManCNotificacion_Muestra.dtNoMuestra.clear();
			ManCNotificacion_Muestra.dtNoMuestra.rows.add(ManCNotificacion_Muestra.fnSearchCenso("NO_MUESTRA", "", "")).draw();
			ManCNotificacion_Muestra.dtMuestra.clear().draw();
			ManCNotificacion_Muestra.frm.find("#lblNumEspecieSelect").text(0);
		}
	});
}
/*Seleccionar una especie como parte de la muestra*/
ManCNotificacion_Muestra.fnSelectEspecieMuestra = function (obj) {
	var data = ManCNotificacion_Muestra.dtNoMuestra.row($(obj).parents('tr')).data();

	switch (ManCNotificacion_Muestra.frm.find("#hdfTipoMuestra").val()) {
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

	ManCNotificacion_Muestra.dtNoMuestra.row($(obj).parents('tr')).data(data).draw(false);
	ManCNotificacion_Muestra.dtMuestra.rows.add([data]).draw();
	ManCNotificacion_Muestra.fnSetCensoEspecieMuestra(data);

	var numEspecies = parseInt(ManCNotificacion_Muestra.frm.find("#lblNumEspecieSelect").text()) + 1;
	ManCNotificacion_Muestra.frm.find("#lblNumEspecieSelect").text(numEspecies);
}
/*Quitar una especie de la muestra*/
ManCNotificacion_Muestra.fnRemoveEspecieMuestra = function (obj, origen) {
	var index = -1;

	if (origen == "NO_MUESTRA") {
		var data = ManCNotificacion_Muestra.dtNoMuestra.row($(obj).parents('tr')).data();
		var lstMuestra = [];
		ManCNotificacion_Muestra.dtMuestra.rows().every(function () { lstMuestra.push(this.data()) })

		switch (ManCNotificacion_Muestra.frm.find("#hdfTipoMuestra").val()) {
			case "M":
			case "NM":
				switch (data["NumM"]) {
					case 1: data["EstM1"] = false; break;
					case 2: data["EstM2"] = false; break;
					case 3: data["EstM3"] = false; break;
				}

				index = lstMuestra.findIndex(m => m.CodTh == data["CodTh"] && m.NumPoa == data["NumPoa"] && m.CodEsp == data["CodEsp"] && m.CodSec == data["CodSec"]);
				if (index != -1) {
					var rowRemove = ManCNotificacion_Muestra.dtMuestra.row(index).data();
					if (rowRemove["RegEst"] == 0) {
						ManCNotificacion_Muestra.tbEliTABLA.push({
							COD_CNOTIFICACION: rowRemove["CodCn"],
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

				index = lstMuestra.findIndex(m => m.CodDev == data["CodDev"] && m.CodEsp == data["CodEsp"] && m.CodSec == data["CodSec"]);
				if (index != -1) {
					var rowRemove = ManCNotificacion_Muestra.dtMuestra.row(index).data();

					if (rowRemove["RegEst"] == 0) {
						ManCNotificacion_Muestra.tbEliTABLA.push({
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
			ManCNotificacion_Muestra.dtMuestra.row(index).remove().draw(false);
			ManCNotificacion_Muestra.dtNoMuestra.row($(obj).parents('tr')).data(data).draw(false);
			ManCNotificacion_Muestra.fnSetCensoEspecieNoMuestra(data);

			var numEspecies = parseInt(ManCNotificacion_Muestra.frm.find("#lblNumEspecieSelect").text()) - 1;
			ManCNotificacion_Muestra.frm.find("#lblNumEspecieSelect").text(numEspecies);
		}
	} else if (origen == "MUESTRA") {
		var data = ManCNotificacion_Muestra.dtMuestra.row($(obj).parents('tr')).data();
		var lstEspecie = [];
		ManCNotificacion_Muestra.dtNoMuestra.rows().every(function () { lstEspecie.push(this.data()) })

		switch (ManCNotificacion_Muestra.frm.find("#hdfTipoMuestra").val()) {
			case "M":
			case "NM":
				index = lstEspecie.findIndex(m => m.CodTh == data["CodTh"] && m.NumPoa == data["NumPoa"] && m.CodEsp == data["CodEsp"] && m.CodSec == data["CodSec"]);

				if (index != -1) {
					var rowRemove = ManCNotificacion_Muestra.dtNoMuestra.row(index).data();
					switch (rowRemove["NumM"]) {
						case 1: rowRemove["EstM1"] = false; break;
						case 2: rowRemove["EstM2"] = false; break;
						case 3: rowRemove["EstM3"] = false; break;
					}
					ManCNotificacion_Muestra.dtNoMuestra.row(index).data(rowRemove).draw(false);
				}

				if (data["RegEst"] == 0) {
					ManCNotificacion_Muestra.tbEliTABLA.push({
						COD_CNOTIFICACION: data["CodCn"],
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
				index = lstEspecie.findIndex(m => m.CodDev == data["CodDev"] && m.CodEsp == data["CodEsp"] && m.CodSec == data["CodSec"]);

				if (index != -1) {
					var rowRemove = ManCNotificacion_Muestra.dtNoMuestra.row(index).data();
					rowRemove["EstM"] = false;
					ManCNotificacion_Muestra.dtNoMuestra.row(index).data(rowRemove).draw(false);
				}

				if (data["RegEst"] == 0) {
					ManCNotificacion_Muestra.tbEliTABLA.push({
						COD_THABILITANTE: data["CodTh"],
						COD_DEVOLUCION: data["CodDev"],
						COD_ESPECIES: data["CodEsp"],
						COD_SECUENCIAL: data["CodSec"]
					});
				}
				data["EstM"] = false;
				break;
		}

		ManCNotificacion_Muestra.dtMuestra.row($(obj).parents('tr')).remove().draw(false);
		ManCNotificacion_Muestra.fnSetCensoEspecieNoMuestra(data);
		var numEspecies = parseInt(ManCNotificacion_Muestra.frm.find("#lblNumEspecieSelect").text()) - 1;
		ManCNotificacion_Muestra.frm.find("#lblNumEspecieSelect").text(numEspecies);
	}
}

/*Buscar especies en el censo según los filtros de la UI*/
ManCNotificacion_Muestra.fnSearchEspecieCenso = function () {
	var filtro = ManCNotificacion_Muestra.frm.find("#ddlFiltroBusquedaId").val();
	var criterio = ManCNotificacion_Muestra.frm.find("#ddlCriterioBusquedaId").val();
	var valor = ManCNotificacion_Muestra.frm.find("#txtValorBusqueda").val();

	ManCNotificacion_Muestra.dtNoMuestra.clear();
	ManCNotificacion_Muestra.dtNoMuestra.rows.add(ManCNotificacion_Muestra.fnSearchCenso(filtro, criterio, valor)).draw();
}
/*Recargar el listado del censo*/
ManCNotificacion_Muestra.fnRefreshEspecieCenso = function () {
	ManCNotificacion_Muestra.frm.find("#ddlFiltroBusquedaId").select2('val', ["TODOS"]);
	ManCNotificacion_Muestra.frm.find("#ddlCriterioBusquedaId").select2('val', ["ESPECIE"]);
	ManCNotificacion_Muestra.frm.find("#txtValorBusqueda").val("");

	ManCNotificacion_Muestra.fnSearchEspecieCenso();
}
/*Seleccionar todas las especies mostradas en la tabla "LISTADO DE ESPECIES DEL CENSO" como parte de la muestra*/
ManCNotificacion_Muestra.fnSelectAllListaEspecieMuestra = function () {
	var lstCenso = ManCNotificacion_Muestra.DATA; //JSON.parse(sessionStorage.getItem('ListCNotificacionCenso'));
	var lstCensoFiltro = [], index = -1;
	var filtro = ManCNotificacion_Muestra.frm.find("#ddlFiltroBusquedaId").val();
	var criterio = ManCNotificacion_Muestra.frm.find("#ddlCriterioBusquedaId").val();
	var valor = ManCNotificacion_Muestra.frm.find("#txtValorBusqueda").val();

	lstCensoFiltro = ManCNotificacion_Muestra.fnSearchCenso(filtro, criterio, valor);

	if (lstCensoFiltro.length > 0) {
		switch (ManCNotificacion_Muestra.frm.find("#hdfTipoMuestra").val()) {
			case "M":
			case "NM":
				$.each(lstCensoFiltro, function (i, o) {
					index = lstCenso.findIndex(m => m.CodTh == o["CodTh"] && m.NumPoa == o["NumPoa"] && m.CodEsp == o["CodEsp"] && m.CodSec == o["CodSec"]
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
					index = lstCenso.findIndex(m => m.CodDev == o["CodDev"] && m.CodEsp == o["CodEsp"] && m.CodSec == o["CodSec"] && m.EstM == false);
					if (index != -1) {
						lstCenso[index]["EstM"] = true;
						lstCenso[index]["RegEst"] = 1;
					}
				});
				break;
		}

		ManCNotificacion_Muestra.DATA = lstCenso;
		//sessionStorage.setItem('ListCNotificacionCenso', JSON.stringify(lstCenso));

		//Cargar los datos
		var lstNoMuestra = [], lstMuestra = [];
		lstNoMuestra = ManCNotificacion_Muestra.fnSearchCenso(filtro, criterio, valor);
		lstMuestra = ManCNotificacion_Muestra.fnSearchCenso("MUESTRA", "", "");
		ManCNotificacion_Muestra.dtMuestra.clear();
		ManCNotificacion_Muestra.dtMuestra.rows.add(lstMuestra).draw();
		ManCNotificacion_Muestra.dtNoMuestra.clear();
		ManCNotificacion_Muestra.dtNoMuestra.rows.add(lstNoMuestra).draw();
		ManCNotificacion_Muestra.frm.find("#lblNumEspecieSelect").text(lstMuestra.length);
	}
}
/*Quitar todas las especies mostradas en la tabla "LISTADO DE ESPECIES DEL CENSO" de la muestra*/
ManCNotificacion_Muestra.fnRemoveAllListaEspecieMuestra = function () {
	var lstCenso = ManCNotificacion_Muestra.DATA; //JSON.parse(sessionStorage.getItem('ListCNotificacionCenso'));
	var lstCensoFiltro = [], index = -1;
	var filtro = ManCNotificacion_Muestra.frm.find("#ddlFiltroBusquedaId").val();
	var criterio = ManCNotificacion_Muestra.frm.find("#ddlCriterioBusquedaId").val();
	var valor = ManCNotificacion_Muestra.frm.find("#txtValorBusqueda").val();

	lstCensoFiltro = ManCNotificacion_Muestra.fnSearchCenso(filtro, criterio, valor);

	if (lstCensoFiltro.length > 0) {
		switch (ManCNotificacion_Muestra.frm.find("#hdfTipoMuestra").val()) {
			case "M":
			case "NM":
				$.each(lstCensoFiltro, function (i, o) {
					index = lstCenso.findIndex(m => m.CodTh == o["CodTh"] && m.NumPoa == o["NumPoa"] && m.CodEsp == o["CodEsp"] && m.CodSec == o["CodSec"]
						&& ((m.NumM == 1 && m.EstM1 == true) || (m.NumM == 2 && m.EstM2 == true) || (m.NumM == 3 && m.EstM3 == true)));

					if (index != -1) {
						switch (lstCenso[index]["NumM"]) {
							case 1: lstCenso[index]["EstM1"] = false; break;
							case 2: lstCenso[index]["EstM2"] = false; break;
							case 3: lstCenso[index]["EstM3"] = false; break;
						}
						if (lstCenso[index]["RegEst"] == 0) {
							ManCNotificacion_Muestra.tbEliTABLA.push({
								COD_CNOTIFICACION: o["CodCn"],
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
					index = lstCenso.findIndex(m => m.CodDev == o["CodDev"] && m.CodEsp == o["CodEsp"] && m.CodSec == o["CodSec"] && m.EstM == true);
					if (index != -1) {
						lstCenso[index]["EstM"] = false;

						if (lstCenso[index]["RegEst"] == 0) {
							ManCNotificacion_Muestra.tbEliTABLA.push({
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

		ManCNotificacion_Muestra.DATA = lstCenso;
		//sessionStorage.setItem('ListCNotificacionCenso', JSON.stringify(lstCenso));
		//Cargar los datos
		var lstNoMuestra = [], lstMuestra = [];
		lstNoMuestra = ManCNotificacion_Muestra.fnSearchCenso(filtro, criterio, valor);
		lstMuestra = ManCNotificacion_Muestra.fnSearchCenso("MUESTRA", "", "");
		ManCNotificacion_Muestra.dtMuestra.clear();
		ManCNotificacion_Muestra.dtMuestra.rows.add(lstMuestra).draw();
		ManCNotificacion_Muestra.dtNoMuestra.clear();
		ManCNotificacion_Muestra.dtNoMuestra.rows.add(lstNoMuestra).draw();
		ManCNotificacion_Muestra.frm.find("#lblNumEspecieSelect").text(lstMuestra.length);
	}
}
/*Obtener las especies seleccionadas como parte de la muestra y que no estan registradas*/
ManCNotificacion_Muestra.fnGetListEspecieSelect = function () {
	var list = [], lstMuestra = [];

	lstMuestra = ManCNotificacion_Muestra.fnSearchCenso("MUESTRA", "", "");

	if (lstMuestra.length > 0) {
		switch (ManCNotificacion_Muestra.frm.find("#hdfTipoMuestra").val()) {
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
							COD_CNOTIFICACION: o["CodCn"]
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

ManCNotificacion_Muestra.fnSubmitForm = function () {
	utilSigo.dialogConfirm('', 'Desea continuar con el registro?', function (r) {
		if (r) {
			ManCNotificacion_Muestra.fnSaveForm();
		}
	});
}

ManCNotificacion_Muestra.fnSaveForm = function () {
	var datosMuestra = ManCNotificacion_Muestra.frm.serializeObject();

	switch (ManCNotificacion_Muestra.frm.find("#hdfTipoMuestra").val()) {
		case "M":
		case "NM": datosMuestra.tbMuestra = ManCNotificacion_Muestra.fnGetListEspecieSelect(); break;
		case "DTR":
		case "DTO":
		case "DAR": datosMuestra.tbMuestraDevolucion = ManCNotificacion_Muestra.fnGetListEspecieSelect(); break;
	}

	datosMuestra.tbEliTABLA = ManCNotificacion_Muestra.tbEliTABLA;

	var option = { url: ManCNotificacion_Muestra.frm.action, datos: JSON.stringify(datosMuestra), type: 'POST' };
	utilSigo.fnAjax(option, function (data) {
		if (data.success) {
			ManCNotificacion_Muestra.fnReturnIndex(data.msj);
		}
		else {
			utilSigo.toastWarning("Aviso", data.msj);
		}
	});
}

ManCNotificacion_Muestra.fnExportMuestra = function () {
	var rows, countFilas, data, numPendiente = 0;

	rows = ManCNotificacion_Muestra.dtMuestra.$("tr");

	if (rows.length > 0) {
		$.each(rows, function (i, o) {
			data = ManCNotificacion_Muestra.dtMuestra.row($(o)).data();
			if (data["RegEst"] == 1) {
				numPendiente++;
			}
		});

		if (numPendiente > 0) {
			utilSigo.toastWarning("Aviso", "Hay cambios sin guardar, por favor guarde la muestra seleccionada para poder descargarla");
		} else {
			var url = urlLocalSigo + "Supervision/ManCNotificacion/ExportMuestra";
			var data = {
				asCodCNotificacion: ManCNotificacion_Muestra.frm.find("#hdfCodCNotificacion").val(),
				asTipoMuestra: ManCNotificacion_Muestra.frm.find("#hdfTipoMuestra").val()
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
	}
}

ManCNotificacion_Muestra.fnExportDatosGenerales = function () {
	var url = urlLocalSigo + "Supervision/ManCNotificacion/ExportDatosGenerales";
	var data = {
		asCodCNotificacion: ManCNotificacion_Muestra.frm.find("#hdfCodCNotificacion").val()
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

ManCNotificacion_Muestra.fnGoToSISFOR = function () {
	switch (ManCNotificacion_Muestra.frm.find("#hdfTipoMuestra").val()) {
		case "M":
			window.open("https://sisfor.osinfor.gob.pe/visor/geoCNMAD/" + ManCNotificacion_Muestra.frm.find("#hdfCodCNotificacion").val(), "_blank");
			break;
	}
}

ManCNotificacion_Muestra.fnImportMuestra = function (e, obj) {
	var url = urlLocalSigo + "Supervision/ManCNotificacion/ImportMuestra";
	uploadFile.fileSelectHandler(e, obj, url, {
		asCodCNotificacion: ManCNotificacion_Muestra.frm.find("#hdfCodCNotificacion").val(),
		asTipoMuestra: ManCNotificacion_Muestra.frm.find("#hdfTipoMuestra").val()
	}, function (data) {
		ManCNotificacion_Muestra.DATA = data;
		//sessionStorage.setItem('ListCNotificacionCenso', JSON.stringify(data));

		var lstNoMuestra = [], lstMuestra = [];
		lstNoMuestra = ManCNotificacion_Muestra.fnSearchCenso("NO_MUESTRA", "", "");
		lstMuestra = ManCNotificacion_Muestra.fnSearchCenso("MUESTRA", "", "");

		ManCNotificacion_Muestra.dtMuestra.clear();
		ManCNotificacion_Muestra.dtMuestra.rows.add(lstMuestra).draw();
		ManCNotificacion_Muestra.dtNoMuestra.clear();
		ManCNotificacion_Muestra.dtNoMuestra.rows.add(lstNoMuestra).draw();
		ManCNotificacion_Muestra.frm.find("#lblNumEspecieSelect").text(lstMuestra.length);
	});
}

$(document).ready(function () {
	ManCNotificacion_Muestra.frm = $("#frmManCNotificacion_Muestra");

	$.fn.select2.defaults.set("theme", "bootstrap4");
	ManCNotificacion_Muestra.frm.find("#ddlFiltroBusquedaId").select2({ minimumResultsForSearch: -1 });
	ManCNotificacion_Muestra.frm.find("#ddlCriterioBusquedaId").select2({ minimumResultsForSearch: -1 });

	ManCNotificacion_Muestra.frm.find("#ddlFiltroBusquedaId").select2("val", ["NO_MUESTRA"]);

	switch (ManCNotificacion_Muestra.frm.find("#hdfTipoMuestra").val()) {
		case "DTR":
		case "DTO":
		case "DAR":
			$("#dvManCNot_Muestra_Import").hide();
			$("#dvManCNot_Muestra_Export").hide();
			$("#dvManCNot_Muestra_Remove").hide();
			break;
	}

	$('[data-toggle="tooltip"]').tooltip();

	ManCNotificacion_Muestra.fnInitDataTable_Detail();

	ManCNotificacion_Muestra.fnGetCenso();

	ManCNotificacion_Muestra.frm.submit(function (e) {
		ManCNotificacion_Muestra.fnSearchEspecieCenso();
		e.preventDefault();
	});
});