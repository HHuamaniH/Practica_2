"use strict";

var ManResolucion = {};
var ManResolucion_Type = '';

ManResolucion.fnShowListOptions = function () {
	utilSigo.modalDraggable($("#mdIL_ListOpciones"), '.modal-header');
	$("#mdIL_ListOpciones").modal({ keyboard: true, backdrop: 'static' });

	ManResolucion.fnNuevaCN = function () {

		if ($("#ddlManResolucionOpcionesId").val().length == 0) {
			utilSigo.toastWarning("Aviso", "Seleccione el tipo de resolución directoral"); return false;
		}
		_ManGrillaPaging.fnNuevo($("#ddlManResolucionOpcionesId").val());
	}
}


ManResolucion.fnLoadManGrillaPaging = function () {
	//para cargar los datos en la vista
	var url = initSigo.urlControllerGeneral + "_ManGrillaPaging_v3";
	var data = ManResolucion.frm.serializeObject();
	var option = { url: url, datos: JSON.stringify(data), type: 'POST', dataType: 'html' };
	// para cargar las columnas y la data 
	var columns_label = [], columns_data = [], options = {}, data_extend = [];

	if (ManResolucion_Type === 'rd') {
		columns_label = ["Fecha Registro", "Número Resolución", "Tipo Resolución", "Nro. Expediente Administrativo", "Numero Informe"];
		columns_data = ["FECHA", "NUMERO_RESOLUCION", "TIPO_FISCALIZA", "NUMERO_EXPEDIENTE", "NUMERO_INFORME"];
	} else {
		columns_label = ["Fecha Registro", "N° Expediente", "Procedencia", "Materia", "Administrado", "Título Habilitante", "Referencia"];
		columns_data = ["FECHA", "NUMERO_RESOLUCION", "PROCEDENCIA", "MATERIA", "ADMINISTRADO", "TITULO_HABILITANTE", "NRO_REFERENCIA"];
	}

	options = {
		page_paging: true, page_length: 20, row_index: true, row_edit: true, row_fnEdit: "_ManGrillaPaging.fnCreate(this)"
		, data_extend: data_extend
	};
	//para descargar los registros del SIGO
	utilSigo.fnAjax(option, function (data) {
		ManResolucion.frm.find("#dvManResolucionContenedor").html(data);
		_ManGrillaPaging.fnInit(columns_label, columns_data, options);

		_ManGrillaPaging.fnExport = function () {
			var url = urlLocalSigo + "Fiscalizacion/ManResolucion/ExportarRegistroUsuario";
			var option = { url: url, datos: JSON.stringify({}), type: 'POST' };

			utilSigo.fnAjax(option, function (data) {
				if (data.success) {
					document.location = urlLocalSigo + "Archivos/Plantilla/Reg_Usu/" + data.msj;
				}
				else {
					utilSigo.toastWarning("Aviso", "Sucedio un error, Comuníquese con el Administrador");
					console.log(data.msj);
				}
			});
		}

		_ManGrillaPaging.fnCreate = function (obj, cod_infLegal) {
			if (obj != "") {//Modificar registro
				var asCodRD = "";
				var url_crud = urlLocalSigo + "Fiscalizacion/ManResolucion/CreateOrEdit";
				var data = _ManGrillaPaging.dtManGrillaPaging.row($(obj).parents('tr')).data();
				asCodRD = data["COD_RESODIREC"];

				_ManGrillaPaging.fnReadConfigManGrillaPaging();

				window.location = url_crud + "?asCodRD=" + asCodRD;
			} else {//Nuevo registro
				ManResolucion.fnShowListOptions();
				//utilSigo.toastWarning("Aviso", "Opción no disponible, por favor registre la notificación desde el sistema que corresponda");
			}
		}

		_ManGrillaPaging.fnNuevo = function (CodTipoI) {
			var cod_infLegal = "";
			var url_crud = urlLocalSigo + "Fiscalizacion/ManResolucion/CreateOrEdit";
			_ManGrillaPaging.fnReadConfigManGrillaPaging();
			window.location = url_crud + "?asCodTipoIL=" + CodTipoI + '&type=' + ManResolucion_Type;
		}

	});
}

$(document).ready(function () {
	ManResolucion_Type = window.location.search.split('=')[1];

	ManResolucion.frm = $("#frmManResodirec");

	var alertaInicial = ManResolucion.frm.find("#alertaFormulario").val();
	if (alertaInicial != "") {
		utilSigo.toastSuccess("Aviso", alertaInicial);
	}
	$.fn.select2.defaults.set("theme", "bootstrap4");
	$("#ddlManResolucionOpcionesId").select2();

	ManResolucion.fnLoadManGrillaPaging();
});