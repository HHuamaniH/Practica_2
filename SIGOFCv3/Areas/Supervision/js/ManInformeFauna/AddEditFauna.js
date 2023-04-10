"use strict";
var ManInforme_AddEditFauna = {};
var ManInforme_AddEdit = {};
/*Variables globales*/
ManInforme_AddEditFauna.tbEliTABLA = [];
ManInforme_AddEditFauna.DataPrograma = [];
ManInforme_AddEditFauna.DataManejoImpacto = [];
ManInforme_AddEditFauna.DataResponsabilidadSocial = [];
ManInforme_AddEditFauna.DataObligacionContrac = [];

ManInforme_AddEdit.Denuncia = {
	objDeuncia: {
		tra_M_Tramite: {
			cCodificacion: ''
		},
		COD_IDENUNCIA: '',
		ENT_INFORME: {
			COD_INFORME: ''
		}
	},
	buscarTramite: function () {
		let cCodificacion = $('#inptExpediente').val().trim();
		if (cCodificacion === '') {
			utilSigo.toastWarning("Aviso", "Ingrese N° Tramite STID");
			return;
		}
		let data = {
			tra_M_Tramite: {
				cCodificacion: cCodificacion
			},
			ENT_INFORME: {
				COD_INFORME: $('#hdfCodInforme').val()
			}
		};
		var option = {
			url: urlLocalSigo + "Supervision/ManInforme/ConsultarExpediente",
			datos: JSON.stringify(data),
			type: 'POST'
		};
		if (ManInforme_AddEdit.Denuncia.objDeuncia.tra_M_Tramite.cCodificacion !== undefined) {
			if (ManInforme_AddEdit.Denuncia.objDeuncia.tra_M_Tramite.cCodificacion.trim() === cCodificacion) {
				utilSigo.toastWarning("Aviso", "N° Tramite STID Asignado en este proyecto");
			} else {
				utilSigo.fnAjax(option, function (response) {
					if (response.iCodTramite != -1) {
						utilSigo.toastSuccess("Aviso", "N° Tramite STID Encontrado")
						ManInforme_AddEdit.Denuncia.objDeuncia.tra_M_Tramite = response;
						$('.responseOk').show();
						$('.responseError').hide();
					}
					else {
						utilSigo.toastWarning("Aviso", "No Existe N° Tramite STID");
						$('.responseOk').hide();
						$('.responseError').show();
					}
				});
			}
		} else {
			utilSigo.fnAjax(option, function (response) {
				if (response.iCodTramite != -1) {
					utilSigo.toastSuccess("Aviso", "N° Tramite STID Encontrado")
					ManInforme_AddEdit.Denuncia.objDeuncia.tra_M_Tramite = response;
					$('.responseOk').show();
					$('.responseError').hide();
				}
				else {
					utilSigo.toastWarning("Aviso", "No Existe N° Tramite STID");
					$('.responseOk').hide();
					$('.responseError').show();
				}
			});
		}
	},
	eliminarTramite: function () {
		if ($('#inptExpediente').val() === '') {
			utilSigo.toastWarning("Aviso", "Ingrese N° Tramite STID");
			return;
		} else {
			$('.responseError').hide();
			$('.responseOk').hide();
			ManInforme_AddEdit.Denuncia.objDeuncia.tra_M_Tramite = {};
			$('#inptExpediente').val('');
		}
	},
	obtenerDenuncia: function () {
		var option = {
			url: urlLocalSigo + "Supervision/Denuncias/obtenerDenunciaxInforme",
			datos: JSON.stringify({
				ENT_INFORME: {
					COD_INFORME: $('#hdfCodInforme').val()
				}
			}),
			type: 'POST'
		};
		utilSigo.fnAjax(option, function (data) {
			if (data.tra_M_Tramite.iCodTramite !== -1 && data.tra_M_Tramite.iCodTramite !== 0) {
				ManInforme_AddEdit.Denuncia.objDeuncia.tra_M_Tramite = data.tra_M_Tramite;
				$('#inptExpediente').val(ManInforme_AddEdit.Denuncia.objDeuncia.tra_M_Tramite.cCodificacion);
				$('.responseOk').show();
				$('.responseError').hide();
			}
			ManInforme_AddEdit.Denuncia.objDeuncia.COD_IDENUNCIA = data.COD_IDENUNCIA;
			if (data.IATENDIDO == 1) {
				$('#rbtnAtendido1').prop('checked', true);
			} else if (data.IATENDIDO == 2) {
				$('#rbtnAtendido2').prop('checked', true);
			}
		});
	}
};
ManInforme_AddEdit.Incidencia = {
	tablaIncidencia: null,
	limpiar: function () {
		$('#COD_IINCIDENCIA').val('0');
		$('#txt_FECHA_SUCESO').val('');
		$('#txt_HORA_SUCESO').val('');
		$('#cboRIESGO').val('00');
		$('#cboPROCESO').val('00');
		$('#cboCIRCUNSTANCIA').val('00');
		$('#txt_UBICACION').val('');
		$('#cboEFECTO').val('00');
		$('#NIVEL_1').val('00');
		$('#NIVEL_2').val('00');
		$('#txt_DSCRP_INCIDENCIA').val('');
		$('#txt_OBSERVACIONES').val('');
		$('#h1').val('');
		$('#h2').val('');
		$('#BtnGuardar').text('GUARDAR');
	},
	Eliminar: function (id) {
		utilSigo.dialogConfirm('', 'Desea continuar con la Eliminacion?', function (r) {
			if (r) {
				utilSigo.fnAjax({
					url: urlLocalSigo + "Supervision/Denuncias/crud_Incidencia",
					datos: JSON.stringify({
						ITipo: 3,
						COD_IINCIDENCIA: id
					}),
					type: 'POST'
				}, function (data) {
					if (data.COD_IINCIDENCIA != '0') {
						ManInforme_AddEdit.Incidencia.tablaIncidencia.ajax.reload();
						ManInforme_AddEdit.Incidencia.limpiar();
					};
				});
			}
		});
	},
	Editar: function (row) {
		let date = new Date(row.FECHA_SUCESO.split('/')[2], row.FECHA_SUCESO.split('/')[1], row.FECHA_SUCESO.split('/')[0]);
		$('#h1').val(row.OBJCOD_IINCIDENCIA_PROTOCOLOS_NIVEL_1.COD_IINCIDENCIA_PROTOCOLOS);
		$('#h2').val(row.OBJCOD_IINCIDENCIA_PROTOCOLOS_NIVEL_2.COD_IINCIDENCIA_PROTOCOLOS);

		$('#COD_IINCIDENCIA').val(row.COD_IINCIDENCIA);
		$('#txt_FECHA_SUCESO').val(row.FECHA_SUCESO.split('/')[2] + '-' + row.FECHA_SUCESO.split('/')[1] + '-' + row.FECHA_SUCESO.split('/')[0]);
		$('#txt_HORA_SUCESO').val(row.HORA_SUCESO);
		$('#cboRIESGO').val(row.OBJCOD_IINCIDENCIA_PROTOCOLOS_RIESGO.COD_IINCIDENCIA_PROTOCOLOS);
		$('#cboPROCESO').val(row.OBJCOD_IINCIDENCIA_PROTOCOLOS_PROCESO.COD_IINCIDENCIA_PROTOCOLOS);
		$('#cboCIRCUNSTANCIA').val(row.OBJCOD_IINCIDENCIA_PROTOCOLOS_CIRCUNSTANCIA.COD_IINCIDENCIA_PROTOCOLOS);
		$('#txt_UBICACION').val(row.UBICACION);
		$('#cboEFECTO').val(row.OBJCOD_IINCIDENCIA_PROTOCOLOS_EFECTO.COD_IINCIDENCIA_PROTOCOLOS);

		$('#txt_DSCRP_INCIDENCIA').val(row.DSCRP_INCIDENCIA);
		$('#txt_OBSERVACIONES').val(row.OBSERVACIONES);
		$('#BtnGuardar').text('EDITAR');
		$('#cboRIESGO').change();
	},
	cargarData: function (str, select, padre) {
		let data = {
			iINCIDENCIA_TIPO_PROTOCOLO: {
				NOMBRE_TIPO_PROTOCOLO: str
			},
			OBJPROTOCOLO_PADRE: {
				COD_IINCIDENCIA_PROTOCOLOS: padre
			}
		};
		var optionDenuncia = {
			url: urlLocalSigo + "Supervision/ManInforme/listarProtocolos",
			datos: JSON.stringify(data),
			type: 'POST'
		};
		$.ajax({
			url: optionDenuncia.url,
			type: optionDenuncia.type,
			data: optionDenuncia.datos,
			contentType: (typeof optionDenuncia.contentType) === 'undefined' ? 'application/json; charset=utf-8' : optionDenuncia.contentType,
			dataType: (typeof optionDenuncia.dataType) === 'undefined' ? 'json' : optionDenuncia.dataType,
			error: utilSigo.errorAjax,
			success: function (data) {
				$('#' + select).empty();
				$('#' + select).append('<option  value="00">-- Seleccionar --</option>');
				$.each(data, function (i, item) {
					let x = '';
					if (i === 0) x = 'selected';
					$('#' + select).append('<option ' + x + 'title="' + item.NOMBRE_PROTOCOLO + '"  value="' + item.COD_IINCIDENCIA_PROTOCOLOS + '">' + utilSigo.recortarTextos(item.NOMBRE_PROTOCOLO, 40) + '</option>');
				});

			},
			complete: function () {
				let h1 = $('#h1').val();
				$('#NIVEL_1').val((h1 == '' ? '00' : h1));
				let h2 = $('#h2').val();
				$('#NIVEL_2').val((h2 == '' ? '00' : h2));

				//if (str === 'NIVEL 1') {
				//    $('#h1').val('00');
				//}
				//if (str === 'NIVEL 1') {
				//    $('#h2').val('00');
				//}
				$('[data-toggle="tooltip"]').tooltip();
			},
			statusCode: { 203: () => { utilSigo.unblockUIGeneral(); } }
		});
	},
	ui: function () {
		ManInforme_AddEdit.Incidencia.cargarData('RIESGO', 'cboRIESGO');
		ManInforme_AddEdit.Incidencia.cargarData('PROCESO', 'cboPROCESO');
		ManInforme_AddEdit.Incidencia.cargarData('CIRCUNSTANCIA', 'cboCIRCUNSTANCIA');
		ManInforme_AddEdit.Incidencia.cargarData('EFECTO', 'cboEFECTO');
		$('#NIVEL_1').val('00');
		$('#NIVEL_2').val('00');
	},
	eventos: function () {
		$('#cboRIESGO').change(function () {
			ManInforme_AddEdit.Incidencia.cargarData('NIVEL 2', 'NIVEL_2', $(this).val());
			ManInforme_AddEdit.Incidencia.cargarData('NIVEL 1', 'NIVEL_1', $(this).val());
		});
	}
}

ManInforme_AddEditFauna.fnLoadData = function (obj, tipo) {
	switch (tipo) {
		case "DataPrograma": ManInforme_AddEditFauna.DataPrograma = JSON.parse(obj) || []; break;
		case "DataManejoImpacto": ManInforme_AddEditFauna.DataManejoImpacto = JSON.parse(obj) || []; break;
		case "DataResponsabilidadSocial": ManInforme_AddEditFauna.DataResponsabilidadSocial = JSON.parse(obj) || []; break;
		case "DataObligacionContrac": ManInforme_AddEditFauna.DataObligacionContrac = JSON.parse(obj) || []; break;
	}
}

ManInforme_AddEditFauna.fnReturnIndex = function (alertaInicial) {
	var url = urlLocalSigo + "Supervision/ManInforme/Index";

	if (alertaInicial == null || alertaInicial == "") {
		window.location = url;
	} else {
		window.location = url + "?_alertaIncial=" + alertaInicial;
	}
}

ManInforme_AddEditFauna.fnBuscarPersona = function (_dom, _tipoPersonaSIGOsfc) {
	var url = urlLocalSigo + "General/Controles/_BuscarPersonaGeneral";
	var option = { url: url, type: 'GET', datos: { asBusGrupo: "PERSONA", asCodPTipo: _tipoPersonaSIGOsfc, asTipoPersona: "N" }, divId: "mdlBuscarPersona" };
	utilSigo.fnOpenModal(option, function () {
		_bPerGen.fnAsignarDatos = function (obj) {
			if (obj != null && obj != "") {
				var data = _bPerGen.dtBuscarPerona.row($(obj).parents('tr')).data();
				switch (_dom) {
					case "DIRECTOR":
						ManInforme_AddEditFauna.frm.find("#hdfCodDirector").val(data["COD_PERSONA"]);
						ManInforme_AddEditFauna.frm.find("#txtDirector").val(data["PERSONA"]);
						break;
					case "RESPONSABLE":
						ManInforme_AddEditFauna.frm.find("#hdfCodResponsable").val(data["COD_PERSONA"]);
						ManInforme_AddEditFauna.frm.find("#txtResponsable").val(data["PERSONA"]);
						break;
					case "TITULAR_EJECUTA":
						ManInforme_AddEditFauna.frm.find("#hdfCodTitularEjecutaPgmf").val(data["COD_PERSONA"]);
						ManInforme_AddEditFauna.frm.find("#txtTitularEjecutaPgmf").val(data["PERSONA"]);
						break;
					case "REGENTE_IMPLEMENTA":
						ManInforme_AddEditFauna.frm.find("#hdfCodRegenteImplPgmf").val(data["COD_PERSONA"]);
						ManInforme_AddEditFauna.frm.find("#txtRegenteImplPgmf").val(data["PERSONA"]);
						break;
				}
				utilSigo.fnCloseModal("mdlBuscarPersona");
			}
		}
		_bPerGen.fnInit();
	}, function () {
		if (_dom == "DIRECTOR") {
			if (!utilSigo.fnValidateForm_HideControl(ManInforme_AddEditFauna.frm, ManInforme_AddEditFauna.frm.find("#hdfCodDirector"), ManInforme_AddEditFauna.frm.find("#iconDirector"), false)) return false;
			return true;
		}
	});
}

ManInforme_AddEditFauna.fnInitDataTable_Detail = function () {
	var columns_label = [], columns_data = [], options = {}, data_extend = [];

	//Cargar la delimitación de la concesión
	columns_label = ["Criterio"];
	columns_data = ["DESCRIPCION"];
	data_extend = [
		{
			"data": "ESTADO_PROGRAMA", "title": "Opción", "width": "7%", "orderable": false, "searchable": false, "mRender": function (data, type, row, meta) {
				var selectNo = (data == true) ? "" : "selected";
				var selectSi = (data == true) ? "selected" : "";
				return '<select class="form-control form-control-sm"><option value="SI" ' + selectSi + '>SI</option><option value="NO" ' + selectNo + '>NO</option></select>';
			}
		},
		{
			"data": "OBSERVACION", "title": "Observación", "width": "65%", "orderable": false, "searchable": false, "mRender": function (data, type, row, meta) {
				return '<input class="form-control form-control-sm" type="text" value="' + data + '" style="width:100%;">';
			}
		}
	];
	options = { page_length: 10, row_index: true, data_extend: data_extend, page_autowidth: false };
	ManInforme_AddEditFauna.dtDelimitacion = utilDt.fnLoadDataTable_Detail(ManInforme_AddEditFauna.frm.find("#tbDelimitacion"), columns_label, columns_data, options);
	ManInforme_AddEditFauna.dtDelimitacion.rows.add(ManInforme_AddEditFauna.DataPrograma.filter(m => m.TIPO_PROGRAMA == "FAUNA_DELIMIT")).draw();
	//Cargar las medidas de conservación
	columns_label = ["Criterio"];
	columns_data = ["DESCRIPCION"];
	data_extend = [
		{
			"data": "ESTADO_PROGRAMA", "title": "Opción", "width": "7%", "orderable": false, "searchable": false, "mRender": function (data, type, row, meta) {
				var selectNo = (data == true) ? "" : "selected";
				var selectSi = (data == true) ? "selected" : "";
				return '<select class="form-control form-control-sm"><option value="SI" ' + selectSi + '>SI</option><option value="NO" ' + selectNo + '>NO</option></select>';
			}
		},
		{
			"data": "OBSERVACION", "title": "Actividades", "width": "65%", "orderable": false, "searchable": false, "mRender": function (data, type, row, meta) {
				return '<input class="form-control form-control-sm" type="text" value="' + data + '" style="width:100%;">';
			}
		}
	];
	options = { page_length: 10, row_index: true, data_extend: data_extend, page_autowidth: false };
	ManInforme_AddEditFauna.dtMedidaConservacion = utilDt.fnLoadDataTable_Detail(ManInforme_AddEditFauna.frm.find("#tbMedidaConservacion"), columns_label, columns_data, options);
	ManInforme_AddEditFauna.dtMedidaConservacion.rows.add(ManInforme_AddEditFauna.DataPrograma.filter(m => m.TIPO_PROGRAMA == "FAUNA_MEDCONSER")).draw();
	//Cargar los criterios Zonificacion de la Distribución de Especies
	columns_label = ["Criterio"];
	columns_data = ["DESCRIPCION"];
	data_extend = [
		{
			"data": "ESTADO_PROGRAMA", "title": "Opción", "width": "7%", "orderable": false, "searchable": false, "mRender": function (data, type, row, meta) {
				var selectNo = (data == true) ? "" : "selected";
				var selectSi = (data == true) ? "selected" : "";
				return '<select class="form-control form-control-sm"><option value="SI" ' + selectSi + '>SI</option><option value="NO" ' + selectNo + '>NO</option></select>';
			}
		},
		{
			"data": "OBSERVACION", "title": "", "width": "65%", "orderable": false, "searchable": false, "mRender": function (data, type, row, meta) {
				return '<input class="form-control form-control-sm" type="text" value="' + data + '" style="width:100%;">';
			}
		}
	];
	options = { page_length: 10, row_index: true, data_extend: data_extend, page_autowidth: false };
	ManInforme_AddEditFauna.dtCritZonifDistribEspecie = utilDt.fnLoadDataTable_Detail(ManInforme_AddEditFauna.frm.find("#tbCritZonifDistribEspecie"), columns_label, columns_data, options);
	ManInforme_AddEditFauna.dtCritZonifDistribEspecie.rows.add(ManInforme_AddEditFauna.DataPrograma.filter(m => m.TIPO_PROGRAMA == "FAUNA_ZONDISESP")).draw();
	//Cargar Actividades de Manejo
	columns_label = ["Criterio"];
	columns_data = ["DESCRIPCION"];
	data_extend = [
		{
			"data": "ESTADO_PROGRAMA", "title": "Opción", "width": "7%", "orderable": false, "searchable": false, "mRender": function (data, type, row, meta) {
				var selectNo = (data == true) ? "" : "selected";
				var selectSi = (data == true) ? "selected" : "";
				return '<select class="form-control form-control-sm"><option value="SI" ' + selectSi + '>SI</option><option value="NO" ' + selectNo + '>NO</option></select>';
			}
		},
		{
			"data": "COD_PROGRAMA", "title": "", "width": "65%", "orderable": false, "searchable": false, "mRender": function (data, type, row, meta) {
				var txtTipo = '<input id="txtItemTipo" class="form-control form-control-sm" type="text" value="' + row.TIPO + '" style="width:50%;">';
				var txtObservacion = '<input id="txtItemObservacion" class="form-control form-control-sm" type="text" value="' + row.OBSERVACION + '" style="width:100%;">';
				var txtValor = "";
				switch (data) {
					case 32:
					case 33: txtValor = "Actividades" + txtObservacion;
						break;
					case 34: txtValor = "Observaciones" + txtObservacion; break;
					case 35: txtValor = "Método" + txtTipo + "Éxito Reproductivo" + txtObservacion; break;
					case 36: txtValor = "Actividad" + txtTipo + "Materiales y Equipos" + txtObservacion; break;
					case 37: txtValor = "Método" + txtTipo; break;
					case 38: txtValor = "Condiciones" + txtObservacion; break;
				}
				return txtValor;
			}
		}
	];
	options = { page_length: 15, row_index: true, data_extend: data_extend, page_autowidth: false };
	ManInforme_AddEditFauna.dtActividadManejo = utilDt.fnLoadDataTable_Detail(ManInforme_AddEditFauna.frm.find("#tbActividadManejo"), columns_label, columns_data, options);
	ManInforme_AddEditFauna.dtActividadManejo.rows.add(ManInforme_AddEditFauna.DataPrograma.filter(m => m.TIPO_PROGRAMA == "FAUNA_MANHABIT")).draw();
	//Cargar Medidas de Prevención y Mitigación de Impactos Ambientales
	columns_label = ["Tipo de Impacto", "Riesgo Potencial", "Actividades Preventivas/Correctivas", "Resultados"];
	columns_data = ["TIPO_IMPACTO", "RIESGO_POTENCIAL", "ACTIVIDAD", "AVANCE_RESULTADO"];
	options = {
		page_length: 10, row_edit: true, row_fnEdit: "ManInforme_AddEditFauna.fnAddEditFauna(this,'MANEJO_IMPACTO')"
		, row_delete: true, row_fnDelete: "ManInforme_AddEditFauna.fnDeleteFauna('MANEJO_IMPACTO',this)", row_index: true, page_sort: true
	};
	ManInforme_AddEditFauna.dtImpactoAmb = utilDt.fnLoadDataTable_Detail(ManInforme_AddEditFauna.frm.find("#tbImpactoAmb"), columns_label, columns_data, options);
	ManInforme_AddEditFauna.dtImpactoAmb.rows.add(ManInforme_AddEditFauna.DataManejoImpacto).draw();
	//Cargar Medidas de Responsabilidad Social
	columns_label = ["Actividad", "Nro. de Participantes", "Lugar de Realización", "Objetivo", "Observación"];
	columns_data = ["ACTIVIDAD_REALIZADA", "NUM_PERSONA", "LUGAR_CAPACITACION", "OBJETIVO", "OBSERVACION"];
	options = {
		page_length: 10, row_edit: true, row_fnEdit: "ManInforme_AddEditFauna.fnAddEditFauna(this,'RESPONSABILIDAD_SOCIAL')"
		, row_delete: true, row_fnDelete: "ManInforme_AddEditFauna.fnDeleteFauna('RESPONSABILIDAD_SOCIAL',this)", row_index: true, page_sort: true
	};
	ManInforme_AddEditFauna.dtResponsabilidadSocial = utilDt.fnLoadDataTable_Detail(ManInforme_AddEditFauna.frm.find("#tbResponsabilidadSocial"), columns_label, columns_data, options);
	ManInforme_AddEditFauna.dtResponsabilidadSocial.rows.add(ManInforme_AddEditFauna.DataResponsabilidadSocial).draw();
	//Cargar Actos Obligacion Contractual
	columns_label = ["Acto", "Documentos que ponenen de conocimiento a las autoridades"];
	columns_data = ["ACTIVIDAD_ACTOS", "DOCUMENTOS_AFORESTAL"];
	options = {
		page_length: 10, row_edit: true, row_fnEdit: "ManInforme_AddEditFauna.fnAddEditFauna(this,'OBLIGACION_ACTO')"
		, row_delete: true, row_fnDelete: "ManInforme_AddEditFauna.fnDeleteFauna('OBLIGACION_ACTO',this)", row_index: true, page_sort: true
	};
	ManInforme_AddEditFauna.dtObligacionActo = utilDt.fnLoadDataTable_Detail(ManInforme_AddEditFauna.frm.find("#tbObligacionActo"), columns_label, columns_data, options);
	ManInforme_AddEditFauna.dtObligacionActo.rows.add(ManInforme_AddEditFauna.DataObligacionContrac.filter(m => m.COD_OCONTRACTUAL == "01")).draw();
	//Cargar Actos Obligacion Contractual Terceros
	columns_label = ["Acto", "Documentos que ponenen de conocimiento a las autoridades"];
	columns_data = ["ACTIVIDAD_ACTOS", "DOCUMENTOS_AFORESTAL"];
	options = {
		page_length: 10, row_edit: true, row_fnEdit: "ManInforme_AddEditFauna.fnAddEditFauna(this,'OBLIGACION_ACTO_TERCERO')"
		, row_delete: true, row_fnDelete: "ManInforme_AddEditFauna.fnDeleteFauna('OBLIGACION_ACTO_TERCERO',this)", row_index: true, page_sort: true
	};
	ManInforme_AddEditFauna.dtObligacionActoTercero = utilDt.fnLoadDataTable_Detail(ManInforme_AddEditFauna.frm.find("#tbObligacionActoTercero"), columns_label, columns_data, options);
	ManInforme_AddEditFauna.dtObligacionActoTercero.rows.add(ManInforme_AddEditFauna.DataObligacionContrac.filter(m => m.COD_OCONTRACTUAL == "03")).draw();
}

ManInforme_AddEditFauna.fnViewModalUbigeo = function () {
	var url = initSigo.urlControllerGeneral + "_Ubigeo";
	var option = { url: url, type: 'POST', datos: {}, divId: "mdlControles_Ubigeo" };
	utilSigo.fnOpenModal(option, function () {
		_Ubigeo.fnSelectUbigeo = function (_ubigeoText, _ubigeoId) {
			ManInforme_AddEditFauna.frm.find("#hdfCodUbigeo").val(_ubigeoId);
			ManInforme_AddEditFauna.frm.find("#txtUbigeo").val(_ubigeoText);
			$("#mdlControles_Ubigeo").modal('hide');
		}
		_Ubigeo.fnLoadModalView(ManInforme_AddEditFauna.frm.find("#hdfCodUbigeo").val());
	}, function () {
		if (!utilSigo.fnValidateForm_HideControl(ManInforme_AddEditFauna.frm, ManInforme_AddEditFauna.frm.find("#hdfCodUbigeo"), ManInforme_AddEditFauna.frm.find("#iconUbigeo"), false)) return false;
		return true;
	}
	);
}

ManInforme_AddEditFauna.fnInit = function () {
	$.fn.select2.defaults.set("theme", "bootstrap4");
	ManInforme_AddEditFauna.frm.find("#ddlOdId").select2();
	ManInforme_AddEditFauna.frm.find("#ddlRealizadoVeedorId").select2({ minimumResultsForSearch: -1 });

	utilSigo.fnFormatDate(ManInforme_AddEditFauna.frm.find("#txtFechaEntrega"));

	//CKEDITOR.replace('txtConclusion', {
	//	toolbar: initSigo.configuracionCKEDITOR
	//});
	if (window.ckeditorConfig) {
		console.log('init ckeditorConfig');
		DecoupledDocumentEditor.create($('#txtConclusion .editor')[0], ckeditorConfig).then(function (editor) {
			window.editor_txtConclusion = editor;
			$("#txtConclusion .toolbar-container").append(editor.ui.view.toolbar.element);
		});
	}
	let cod_mtipo = ManInforme_AddEditFauna.frm.find("#hdfCodMTipo").val();

	if (cod_mtipo == "0000013") {//Concesión - Fauna
		ManInforme_AddEditFauna.frm.find("#dvObligacionContractual").show();
	}
}

ManInforme_AddEditFauna.fnAddEditFauna = function (obj, _tipo) {
	var url = urlLocalSigo, dt = null, _funcModal = {}, oParams = "";

	switch (_tipo) {
		case "MANEJO_IMPACTO":
			url += "Supervision/ManInformeConservacion/_ManejoImpacto";
			dt = ManInforme_AddEditFauna.dtImpactoAmb;
			break;
		case "RESPONSABILIDAD_SOCIAL":
			url += "Supervision/ManInformeFauna/_ResponsabilidadSocial";
			dt = ManInforme_AddEditFauna.dtResponsabilidadSocial;
			break;
		case "OBLIGACION_ACTO":
			url += "Supervision/ManInformeFauna/_ActoObligacion";
			dt = ManInforme_AddEditFauna.dtObligacionActo;
			oParams = "01";
			break;
		case "OBLIGACION_ACTO_TERCERO":
			url += "Supervision/ManInformeFauna/_ActoObligacion";
			dt = ManInforme_AddEditFauna.dtObligacionActoTercero;
			oParams = "03";
			break;
	}

	var option = { url: url, type: 'POST', datos: {}, divId: "mdlManInformeFauna" };
	utilSigo.fnOpenModal(option, function () {
		switch (_tipo) {
			case "MANEJO_IMPACTO": _funcModal = _ManejoImpacto; break;
			case "RESPONSABILIDAD_SOCIAL": _funcModal = _ResponsabilidadSocial; break;
			case "OBLIGACION_ACTO": _funcModal = _ActoObligacion; break;
			case "OBLIGACION_ACTO_TERCERO": _funcModal = _ActoObligacion; break;
		}

		_funcModal.fnSaveForm = function (data) {
			if (data != null) {
				if (obj == null || obj == "") {//Nuevo Registro
					dt.rows.add([data]).draw();
					dt.page('last').draw('page');
					utilSigo.toastSuccess("Exito", "Datos guardados correctamente");
				} else {//Modificar
					var row = dt.row($(obj).parents('tr')).data();
					row = data;
					dt.row($(obj).parents('tr')).data(row).draw(false);
					utilSigo.toastSuccess("Exito", "Datos actualizados correctamente");
				}
				$("#mdlManInformeFauna").modal('hide');
			} else {
				utilSigo.toastError("Error", "No se pudieron guardar los datos");
			}
		}

		if (obj != null && obj != "") {
			var data = dt.row($(obj).parents('tr')).data();
			_funcModal.fnInit(utilSigo.fnConvertArrayToObject(data), oParams);
		} else { _funcModal.fnInit("", oParams); }
	});
}

ManInforme_AddEditFauna.fnDeleteFauna = function (_tipo, obj, objData) {
	var dt, data;
	switch (_tipo) {
		case "MANEJO_IMPACTO": dt = ManInforme_AddEditFauna.dtImpactoAmb; break;
		case "RESPONSABILIDAD_SOCIAL": dt = ManInforme_AddEditFauna.dtResponsabilidadSocial; break;
		case "OBLIGACION_ACTO": dt = ManInforme_AddEditFauna.dtObligacionActo; break;
		case "OBLIGACION_ACTO_TERCERO": dt = ManInforme_AddEditFauna.dtObligacionActoTercero; break;
	}

	data = typeof objData !== 'undefined' ? objData : dt.row($(obj).parents('tr')).data();

	if (data["RegEstado"] == "0" || data["RegEstado"] == "2") {
		switch (_tipo) {
			case "MANEJO_IMPACTO":
				ManInforme_AddEditFauna.tbEliTABLA.push({
					EliTABLA: "ListISUPERVISION_IDENTMANEJOIMPACTO",
					COD_SECUENCIAL: data["COD_SECUENCIAL"]
				});
				break;
			case "RESPONSABILIDAD_SOCIAL":
				ManInforme_AddEditFauna.tbEliTABLA.push({
					EliTABLA: "ListISUPERVISION_DET_CAPACITACION_LOCAL",
					COD_PROGRAMA: data["COD_PROGRAMA"],
					COD_SECUENCIAL: data["COD_SECUENCIAL"]
				});
				break;
			case "OBLIGACION_ACTO":
			case "OBLIGACION_ACTO_TERCERO":
				ManInforme_AddEditFauna.tbEliTABLA.push({
					EliTABLA: "ISUPERVISION_DET_OCONTRACTUAL",
					EliVALOR01: data["COD_OCONTRACTUAL"],
					COD_SECUENCIAL: data["COD_SECUENCIAL"]
				});
				break;
		}
	}
	if (typeof objData === 'undefined') {
		dt.row($(obj).parents('tr')).remove().draw(false);
	}
}
ManInforme_AddEditFauna.fnDeleteAllFauna = function (_tipo) {
	var dt, data;
	switch (_tipo) {
		case "MANEJO_IMPACTO": dt = ManInforme_AddEditFauna.dtImpactoAmb; break;
		case "RESPONSABILIDAD_SOCIAL": dt = ManInforme_AddEditFauna.dtResponsabilidadSocial; break;
		case "OBLIGACION_ACTO": dt = ManInforme_AddEditFauna.dtObligacionActo; break;
		case "OBLIGACION_ACTO_TERCERO": dt = ManInforme_AddEditFauna.dtObligacionActoTercero; break;
	}
	if (dt.$("tr").length > 0) {
		utilSigo.dialogConfirm("", "Está seguro de Eliminar Todos los Registros?", function (r) {
			if (r) {
				$.each(dt.$("tr"), function (i, o) {
					data = dt.row($(o)).data();
					ManInforme_AddEditFauna.fnDeleteFauna(_tipo, "", data);
				});
				dt.clear().draw();
			}
		});
	} else {
		utilSigo.toastWarning("Aviso", "No se encontraron registros a eliminar");
	}
}
ManInforme_AddEditFauna.fnGetListFauna = function (_tipo) {
	var dt, list = [], data;
	switch (_tipo) {
		case "MANEJO_IMPACTO": dt = ManInforme_AddEditFauna.dtImpactoAmb; break;
		case "RESPONSABILIDAD_SOCIAL": dt = ManInforme_AddEditFauna.dtResponsabilidadSocial; break;
		case "OBLIGACION_ACTO": dt = ManInforme_AddEditFauna.dtObligacionActo; break;
		case "OBLIGACION_ACTO_TERCERO": dt = ManInforme_AddEditFauna.dtObligacionActoTercero; break;
	}

	if (dt.$("tr").length > 0) {
		$.each(dt.$("tr"), function (i, o) {
			data = dt.row($(o)).data();
			if (data["RegEstado"] == "1" || data["RegEstado"] == "2") {
				list.push(utilSigo.fnConvertArrayToObject(data));
			}
		});
	}
	return list;
}
ManInforme_AddEditFauna.fnGetListPrograma = function (_tipo) {
	var list = [], data, dataHtml, dt;

	switch (_tipo) {
		case "DELIMITACION_CONCESION": dt = ManInforme_AddEditFauna.dtDelimitacion; break;
		case "ACTIVIDAD_MANEJO": dt = ManInforme_AddEditFauna.dtActividadManejo; break;
		case "MEDIDA_CONSERVACION": dt = ManInforme_AddEditFauna.dtMedidaConservacion; break;
		case "ZONIFICACION_ESPECIE": dt = ManInforme_AddEditFauna.dtCritZonifDistribEspecie; break;
	}

	if (dt.$("tr").length > 0) {
		$.each(dt.$("tr"), function (i, o) {
			data = dt.row($(o)).data();
			dataHtml = $(o)[0];

			data.RegEstado = data.RegEstado == "0" || data.RegEstado == "2" ? "2" : "1";
			data.ESTADO_PROGRAMA = $($($(dataHtml).find("td")[2]).find('select')[0]).val() == "SI" ? true : false;
			data["OBSERVACION"] = $($($(dataHtml).find("td")[3]).find("input")[0]).val();

			if (_tipo == "ACTIVIDAD_MANEJO") {
				data["TIPO"] = $($(dataHtml).find("td")[3]).find("#txtItemTipo").val();
				data["OBSERVACION"] = $($(dataHtml).find("td")[3]).find("#txtItemObservacion").val();
			}

			list.push(utilSigo.fnConvertArrayToObject(data));
		});
	}
	return list;
}

ManInforme_AddEditFauna.fnCustomValidateForm = function () {
	ManInforme_AddEdit.Denuncia.objDeuncia.IATENDIDO = $('input[name="rbtnAtendido"]:checked').val();
	utilSigo.elementOk($('#inptExpediente'));
	if (ManInforme_AddEdit.Denuncia.objDeuncia.IATENDIDO === '1') {
		if ($('#inptExpediente').val() === '') {
			$('.nav-tabs a[href="#navDatos"]').tab('show');
			utilSigo.elementERROR($('#inptExpediente'), 'Ingrese Expediente');
			return false;
		}
		if ($.isEmptyObject(ManInforme_AddEdit.Denuncia.objDeuncia.tra_M_Tramite)) {
			$('.nav-tabs a[href="#navDatos"]').tab('show');
			utilSigo.elementERROR($('#inptExpediente'), 'Ingrese Expediente');
			return false;
		}
		if (ManInforme_AddEdit.Denuncia.objDeuncia.tra_M_Tramite.cCodificacion === '') {
			$('.nav-tabs a[href="#navDatos"]').tab('show');
			utilSigo.elementERROR($('#inptExpediente'), 'Ingrese Expediente');
			return false;
		}
	}
	if ($('#inptExpediente').val() !== '') {
		if ($.isEmptyObject(ManInforme_AddEdit.Denuncia.objDeuncia.tra_M_Tramite)) {
			$('.nav-tabs a[href="#navDatos"]').tab('show');
			utilSigo.elementERROR($('#inptExpediente'), 'Busque Expediente');
			return false;
		}
		if (ManInforme_AddEdit.Denuncia.objDeuncia.tra_M_Tramite.cCodificacion === '') {
			$('.nav-tabs a[href="#navDatos"]').tab('show');
			utilSigo.elementERROR($('#inptExpediente'), 'Busque Expediente');
			return false;
		}
	}
	if (!utilSigo.fnValidateForm_HideControl(ManInforme_AddEditFauna.frm, ManInforme_AddEditFauna.frm.find("#hdfCodUbigeo"), ManInforme_AddEditFauna.frm.find("#iconUbigeo"), false)) return false;
	return true;
}

ManInforme_AddEditFauna.fnSubmitForm = function () {
	var controls = ["ddlIndicadorId", "ddlOdId", "txtNumInforme", "txtFechaInicio", "txtFechaFin", "txtSector"];
	if (!utilSigo.fnValidateForm(ManInforme_AddEditFauna.frm, controls)) {
		return ManInforme_AddEditFauna.frm.valid();
	}
	ManInforme_AddEditFauna.frm.submit();
}

ManInforme_AddEditFauna.fnSaveForm = function () {
	utilSigo.blockUIGeneral();
	let data = ManInforme_AddEdit.Denuncia.objDeuncia;
	var optionDenuncia = {
		url: urlLocalSigo + "Supervision/Denuncias/insertarTramiteDenuncia",
		datos: JSON.stringify(data),
		type: 'POST'
	};
	$.ajax({
		url: optionDenuncia.url,
		type: optionDenuncia.type,
		data: optionDenuncia.datos,
		contentType: (typeof optionDenuncia.contentType) === 'undefined' ? 'application/json; charset=utf-8' : optionDenuncia.contentType,
		dataType: (typeof optionDenuncia.dataType) === 'undefined' ? 'json' : optionDenuncia.dataType,
		error: utilSigo.errorAjax,
		success: function (data) { },
		complete: function () {
			var datosInforme = ManInforme_AddEditFauna.frm.serializeObject();
			datosInforme.vmControlCalidad = _ControlCalidad.fnGetDatosControlCalidad();
			datosInforme.chkPublicar = utilSigo.fnGetValChk(ManInforme_AddEditFauna.frm.find("#chkPublicar"));
			datosInforme.vmInfCNotificacion = _renderCNotificacion.fnGetDatosCNotificacion();
			//datosInforme.txtConclusion = CKEDITOR.instances["txtConclusion"].getData();
			datosInforme.txtConclusion = window.editor_txtConclusion.getData();
			datosInforme.vmDatoSupervision = _renderDatosSupervision.fnGetDatosSupervision();
			datosInforme.tbSupervisor = _renderSupervisor.fnGetList();
			datosInforme.tbEliTABLA = ManInforme_AddEditFauna.tbEliTABLA;
			datosInforme.tbEliTABLA = datosInforme.tbEliTABLA.concat(_renderCNotificacion.fnGetListEliTABLA());
			datosInforme.tbEliTABLA = datosInforme.tbEliTABLA.concat(_renderSupervisor.fnGetListEliTABLA());
			datosInforme.tbPrograma = ManInforme_AddEditFauna.fnGetListPrograma("DELIMITACION_CONCESION");
			datosInforme.tbPrograma = datosInforme.tbPrograma.concat(ManInforme_AddEditFauna.fnGetListPrograma("ACTIVIDAD_MANEJO"));
			datosInforme.tbPrograma = datosInforme.tbPrograma.concat(ManInforme_AddEditFauna.fnGetListPrograma("MEDIDA_CONSERVACION"));
			datosInforme.tbPrograma = datosInforme.tbPrograma.concat(ManInforme_AddEditFauna.fnGetListPrograma("ZONIFICACION_ESPECIE"));
			datosInforme.tbManejoImpacto = ManInforme_AddEditFauna.fnGetListFauna("MANEJO_IMPACTO");
			datosInforme.tbResponsabilidadSocial = ManInforme_AddEditFauna.fnGetListFauna("RESPONSABILIDAD_SOCIAL");
			datosInforme.tbObligacionContrac = ManInforme_AddEditFauna.fnGetListFauna("OBLIGACION_ACTO");
			datosInforme.tbObligacionContrac = datosInforme.tbObligacionContrac.concat(ManInforme_AddEditFauna.fnGetListFauna("OBLIGACION_ACTO_TERCERO"));
			datosInforme.tbDesplazamiento = _renderDesplazamiento.fnGetList();
			datosInforme.tbEliTABLA = datosInforme.tbEliTABLA.concat(_renderDesplazamiento.fnGetListEliTABLA());

			datosInforme.tbMandatos = _renderMandatos.fnGetList();
			datosInforme.tbMandatos = datosInforme.tbMandatos.concat(_renderMandatos.fnGetListEliTABLA());
			datosInforme.tbVerticeTHCampo = _renderVerticeTHCampo.fnGetList();
			datosInforme.tbEliTABLA = datosInforme.tbEliTABLA.concat(_renderVerticeTHCampo.fnGetListEliTABLA());

			datosInforme.tbCoberturaBoscosa = _renderCoberturaBoscosa.fnGetList();
			datosInforme.tbEliTABLA = datosInforme.tbEliTABLA.concat(_renderCoberturaBoscosa.fnGetListEliTABLA());
			datosInforme.tbOtrosPtosEval = _renderOtrosPuntosEval.fnGetList();
			datosInforme.tbEliTABLA = datosInforme.tbEliTABLA.concat(_renderOtrosPuntosEval.fnGetListEliTABLA());
			datosInforme.tbInfraestructura = _renderInfraestructura.fnGetList();
			datosInforme.tbEliTABLA = datosInforme.tbEliTABLA.concat(_renderInfraestructura.fnGetListEliTABLA());
			datosInforme.tbZonifDistribEspecie = _renderZonifDistribEspecie.fnGetList();
			datosInforme.tbEliTABLA = datosInforme.tbEliTABLA.concat(_renderZonifDistribEspecie.fnGetListEliTABLA());

			var option = { url: ManInforme_AddEditFauna.frm[0].action, datos: JSON.stringify({ dto: datosInforme }), type: 'POST' };
			$.ajax({
				url: option.url,
				type: (typeof option.type) === 'undefined' ? 'GET' : option.type,
				data: (typeof option.datos) === 'undefined' ? {} : option.datos,
				contentType: (typeof option.contentType) === 'undefined' ? 'application/json; charset=utf-8' : option.contentType,
				dataType: (typeof option.dataType) === 'undefined' ? 'json' : option.dataType,
				error: utilSigo.errorAjax,
				success: function (data) {
					if (data.success) {
						ManInforme_AddEditFauna.fnReturnIndex(data.msj);
					}
					else {
						utilSigo.toastWarning("Aviso", data.msj);
					}
					utilSigo.unblockUIGeneral();
				},
				statusCode: {
					203: () => { utilSigo.unblockUIGeneral(); }
				}
			});
		},
		statusCode: { 203: () => { utilSigo.unblockUIGeneral(); } }
	});
}
ManInforme_AddEdit.validarIncidencia = function () {
	utilSigo.elementOk($('#txt_FECHA_SUCESO'));
	utilSigo.elementOk($('#txt_HORA_SUCESO'));
	utilSigo.elementOk($('#cboRIESGO'));
	utilSigo.elementOk($('#cboPROCESO'));
	utilSigo.elementOk($('#cboCIRCUNSTANCIA'));
	utilSigo.elementOk($('#txt_UBICACION'));
	utilSigo.elementOk($('#cboEFECTO'));
	utilSigo.elementOk($('#NIVEL_1'));
	utilSigo.elementOk($('#NIVEL_2'));
	utilSigo.elementOk($('#txt_DSCRP_INCIDENCIA'));
	utilSigo.elementOk($('#txt_OBSERVACIONES'));
	if ($('#txt_FECHA_SUCESO').val() === '') {
		$('.nav-tabs a[href="#navIncidencias"]').tab('show');
		utilSigo.elementERROR($('#txt_FECHA_SUCESO'), 'Ingrese Fecha Suceso');
		return false;
	}
	if ($('#txt_HORA_SUCESO').val() === '') {
		$('.nav-tabs a[href="#navIncidencias"]').tab('show');
		utilSigo.elementERROR($('#txt_HORA_SUCESO'), 'Ingrese Hora Suceso');
		return false;
	}
	if ($('#cboRIESGO').val() === '00') {
		$('.nav-tabs a[href="#navIncidencias"]').tab('show');
		utilSigo.elementERROR($('#cboRIESGO'), 'Ingrese Riesgo');
		return false;
	}
	if ($('#cboPROCESO').val() === '00') {
		$('.nav-tabs a[href="#navIncidencias"]').tab('show');
		utilSigo.elementERROR($('#cboPROCESO'), 'Ingrese Proceso');
		return false;
	}
	if ($('#cboCIRCUNSTANCIA').val() === '00') {
		$('.nav-tabs a[href="#navIncidencias"]').tab('show');
		utilSigo.elementERROR($('#cboCIRCUNSTANCIA'), 'Ingrese Circunstancia');
		return false;
	}
	if ($('#txt_UBICACION').val() === '') {
		$('.nav-tabs a[href="#navIncidencias"]').tab('show');
		utilSigo.elementERROR($('#txt_UBICACION'), 'Ingrese Ubicacion');
		return false;
	}
	if ($('#cboEFECTO').val() === '00') {
		$('.nav-tabs a[href="#navIncidencias"]').tab('show');
		utilSigo.elementERROR($('#cboEFECTO'), 'Ingrese Efecto');
		return false;
	}
	if ($('#NIVEL_1').val() === '00') {
		$('.nav-tabs a[href="#navIncidencias"]').tab('show');
		utilSigo.elementERROR($('#NIVEL_1'), 'Ingrese Nivel 1');
		return false;
	}
	if ($('#NIVEL_2').val() === '00') {
		$('.nav-tabs a[href="#navIncidencias"]').tab('show');
		utilSigo.elementERROR($('#NIVEL_2'), 'Ingrese Nivel 2');
		return false;
	}
	if ($('#txt_DSCRP_INCIDENCIA').val() === '') {
		$('.nav-tabs a[href="#navIncidencias"]').tab('show');
		utilSigo.elementERROR($('#txt_DSCRP_INCIDENCIA'), 'Ingrese Descripcion Incidencia');
		return false;
	}
	if ($('#txt_OBSERVACIONES').val() === '') {
		$('.nav-tabs a[href="#navIncidencias"]').tab('show');
		utilSigo.elementERROR($('#txt_OBSERVACIONES'), 'Ingrese Observacion');
		return false;
	}
	return true;
}
ManInforme_AddEdit.cargarIncidencias = function () {
	ManInforme_AddEdit.Incidencia.tablaIncidencia =
		$('#GridIINCIDENCIA').DataTable({
			oLanguage: initSigo.oLanguage,
			dom: 'rtip',
			bInfo: true,
			responsive: true,
			processing: true,
			bServerSide: true,
			pageLength: initSigo.pageLengthBuscar,
			sAjaxSource: urlLocalSigo + "Supervision/Denuncias/crud_Incidencia",
			"fnServerData": function (url, odata, callback) {
				let Data = {};
				let PageSize = odata[4].value;
				let PrimerRegistro = odata[3].value;
				let CurrentPage = PrimerRegistro / PageSize;
				Data.PageSize = PageSize;
				Data.CurrentPage = CurrentPage + 1;
				Data.ITipo = 4;
				Data.COD_INFORME = $('#hdfCodInforme').val();
				$.ajax({
					"url": url,
					"dataSrc": "",
					"data": Data,
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
						alert("DataTables warning: JSON data from server failed to load or be parsed. " +
							"This is most likely to be caused by a JSON formatting error.");
					}
				});
			},
			drawCallback: function (settings) {
				$('[data-toggle="tooltip"]').tooltip();
			},
			columns: [
				{
					render: function (data, type, row) {
						return row.FECHA_SUCESO + ' ' + row.HORA_SUCESO;
					}, title: "Fecha"
				},
				{
					render: function (data, type, row) {
						let rpta = row.OBJCOD_IINCIDENCIA_PROTOCOLOS_RIESGO.NOMBRE_PROTOCOLO;
						return '<a data-toggle="tooltip" data-placement="top" title="' + rpta + '">' + utilSigo.recortarTextos(rpta, 40) + '</a>';
					}, title: "Riesgo"
				},
				{
					render: function (data, type, row) {
						let rpta = row.OBJCOD_IINCIDENCIA_PROTOCOLOS_PROCESO.NOMBRE_PROTOCOLO;
						return '<a data-toggle="tooltip" data-placement="top" title="' + rpta + '">' + utilSigo.recortarTextos(rpta, 40) + '</a>';
					}, title: "Proceso"
				},
				{
					render: function (data, type, row) {
						let rpta = row.OBJCOD_IINCIDENCIA_PROTOCOLOS_CIRCUNSTANCIA.NOMBRE_PROTOCOLO;
						return '<a data-toggle="tooltip" data-placement="top" title="' + rpta + '">' + utilSigo.recortarTextos(rpta, 40) + '</a>';
					}, title: "Circunstancia"
				}, {
					render: function (data, type, row) {
						let rpta = row.OBJCOD_IINCIDENCIA_PROTOCOLOS_EFECTO.NOMBRE_PROTOCOLO;
						return '<a data-toggle="tooltip" data-placement="top" title="' + rpta + '">' + utilSigo.recortarTextos(rpta, 40) + '</a>';
					}, title: "Efecto"
				},
				{
					render: function (data, type, row) {
						return '<a data-toggle="tooltip" data-placement="top" title="' + row.DSCRP_INCIDENCIA + '">' + utilSigo.recortarTextos(row.DSCRP_INCIDENCIA, 40) + '</a>';
					}, title: "Descripcion"
				},
				{
					render: function (data, type, row) {
						return '<a data-toggle="tooltip" data-placement="top" title="' + row.OBSERVACIONES + '">' + utilSigo.recortarTextos(row.OBSERVACIONES, 40) + '</a>';
					}, title: "Observacion"
				},
				{
					render: function (data, type, row) {
						let str = "<button class='btn btn-primary btn-xs btn-edit' type='button' " +
							"onClick='ManInforme_AddEdit.Incidencia.Editar(" + JSON.stringify(row) + ")'>Editar</button>";
						str += '<button class="btn btn-danger btn-xs btn-edit" type="button" ' +
							'onClick="ManInforme_AddEdit.Incidencia.Eliminar(\'' + row.COD_IINCIDENCIA + '\')">Eliminar</button> ';

						return str;
					}, title: "Acciones"
				}
			],
			columnDefs: [
				{ responsivePriority: 1, targets: 0 },
				{ responsivePriority: 2, targets: -2 },
				{ className: "text-center", targets: "_all", orderable: false }
			]
		});
}

$(document).ready(function () {
	ManInforme_AddEditFauna.frm = $("#frmManInforme_AddEditFauna");

	ManInforme_AddEditFauna.fnInit();
	ManInforme_AddEditFauna.fnInitDataTable_Detail();

	$('[data-toggle="tooltip"]').tooltip();

	//=====-----Para el registro de datos del formulario-----=====
	//Validación personalizada
	jQuery.validator.addMethod("invalidManInf_AddEditFauna", function (value, element) {
		switch ($(element).attr('id')) {
			case 'ddlIndicadorId':
			case 'ddlOdId':
				return (value == '0000000') ? false : true;
				break
		}
	});
	ManInforme_AddEditFauna.frm.validate(utilSigo.fnValidate({
		rules: {
			ddlIndicadorId: { invalidManInf_AddEditFauna: true },
			ddlOdId: { invalidManInf_AddEditFauna: true },
			txtNumInforme: { required: true },
			txtFechaInicio: { required: true },
			txtFechaFin: { required: true },
			txtSector: { required: true }
		},
		messages: {
			ddlIndicadorId: { invalidManInf_AddEditFauna: "Seleccione el estado actual del registro" },
			ddlOdId: { invalidManInf_AddEditFauna: "Seleccione la oficina desconcentrada" },
			txtNumInforme: { required: "Ingrese el número del informe de supervisión" },
			txtFechaInicio: { required: "Seleccione la fecha de inicio de la supervisión" },
			txtFechaFin: { required: "Seleccione la fecha fin de la supervisión" },
			txtSector: { required: "Ingrese el sector del área supervisada" }
		},
		fnSubmit: function (form) {
			if (ManInforme_AddEditFauna.fnCustomValidateForm()) {
				utilSigo.dialogConfirm('', 'Desea continuar con el registro?', function (r) {
					if (r) {
						ManInforme_AddEditFauna.fnSaveForm();
					}
				});
			}
		}
	}));
	//Validación de controles que usan Select2
	ManInforme_AddEditFauna.frm.find("select.select2-hidden-accessible").on("change", function (e) {
		$(this).valid();
	});
	ManInforme_AddEdit.cargarIncidencias();
	ManInforme_AddEdit.Denuncia.obtenerDenuncia();
	$('#BtnGuardar').click(function () {
		if (ManInforme_AddEdit.validarIncidencia()) {
			let obj = {
				ITipo: $('#COD_IINCIDENCIA').val() === '0' ? 1 : 2,
				COD_IINCIDENCIA: $('#COD_IINCIDENCIA').val(),
				COD_INFORME: $('#hdfCodInforme').val(),
				FECHA_SUCESO: $('#txt_FECHA_SUCESO').val(),
				HORA_SUCESO: $('#txt_HORA_SUCESO').val(),
				COD_IINCIDENCIA_PROTOCOLOS_RIESGO: $('#cboRIESGO').val(),
				COD_IINCIDENCIA_PROTOCOLOS_PROCESO: $('#cboPROCESO').val(),
				COD_IINCIDENCIA_PROTOCOLOS_CIRCUNSTANCIA: $('#cboCIRCUNSTANCIA').val(),
				UBICACION: $('#txt_UBICACION').val(),
				COD_IINCIDENCIA_PROTOCOLOS_EFECTO: $('#cboEFECTO').val(),
				COD_IINCIDENCIA_PROTOCOLOS_NIVEL_1: $('#NIVEL_1').val(),
				COD_IINCIDENCIA_PROTOCOLOS_NIVEL_2: $('#NIVEL_2').val(),
				DSCRP_INCIDENCIA: $('#txt_DSCRP_INCIDENCIA').val(),
				OBSERVACIONES: $('#txt_OBSERVACIONES').val()
			}
			var option = {
				url: urlLocalSigo + "Supervision/Denuncias/crud_Incidencia",
				datos: JSON.stringify(obj),
				type: 'POST'
			};
			utilSigo.fnAjax(option, function (data) {
				if (data.COD_IINCIDENCIA != '0') {
					ManInforme_AddEdit.Incidencia.tablaIncidencia.ajax.reload();
					ManInforme_AddEdit.Incidencia.limpiar();
					$('#BtnGuardar').text('GUARDAR');
				};
			});
		}
	});
	$('#BtnLimpiar').click(function () {
		ManInforme_AddEdit.Incidencia.limpiar();
	});
	$('#BtnExportar').click(function () {
		var url = urlLocalSigo + "Supervision/Denuncias/ExportarTablaIncidencia";
		var option = {
			url: url,
			datos: JSON.stringify({
				ITipo: 5,
				COD_INFORME: $('#hdfCodInforme').val()
			}),
			type: 'POST'
		};

		utilSigo.fnAjax(option, function (data) {
			if (data.success) {
				document.location = urlLocalSigo + "Archivos/Incidencia/" + data.msj;
			}
			else {
				utilSigo.toastWarning("Aviso", "Sucedio un error, Comuníquese con el Administrador");
				console.log(data.msj);
			}
		});
	});
	ManInforme_AddEdit.Denuncia.objDeuncia.ENT_INFORME.COD_INFORME = $('#hdfCodInforme').val().trim();
	ManInforme_AddEdit.Incidencia.ui();
	ManInforme_AddEdit.Incidencia.eventos();
});