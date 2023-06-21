"use strict";
var ManInforme_AddEditConservacion = {};
/*Variables globales*/
ManInforme_AddEditConservacion.tbEliTABLA = [];
ManInforme_AddEditConservacion.DataCoordenadaUTM = [];
ManInforme_AddEditConservacion.DataPrograma = [];
ManInforme_AddEditConservacion.DataInfraestructura = [];
ManInforme_AddEditConservacion.DataActividadPrograma = [];
ManInforme_AddEditConservacion.DataManejoImpacto = [];
ManInforme_AddEditConservacion.DataRegFlora = [];
ManInforme_AddEditConservacion.DataRegPaisaje = [];
ManInforme_AddEditConservacion.DataZonificacion = [];
ManInforme_AddEditConservacion.DataEquipamiento = [];
ManInforme_AddEditConservacion.DataActTuristica = [];
ManInforme_AddEditConservacion.DataIntAmbiental = [];
ManInforme_AddEditConservacion.DataActInvestigacion = [];
ManInforme_AddEditConservacion.DataActVisitas = [];
ManInforme_AddEditConservacion.DataActOtroPrograma = [];
//30.04.2021
ManInforme_AddEditConservacion.tbImpacto = [];

ManInforme_AddEditConservacion.Denuncia = {
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
		if (ManInforme_AddEditConservacion.Denuncia.objDeuncia.tra_M_Tramite.cCodificacion !== undefined) {
			if (ManInforme_AddEditConservacion.Denuncia.objDeuncia.tra_M_Tramite.cCodificacion.trim() === cCodificacion) {
				utilSigo.toastWarning("Aviso", "N° Tramite STID Asignado en este proyecto");
			} else {
				utilSigo.fnAjax(option, function (response) {
					if (response.iCodTramite !== -1) {
						utilSigo.toastSuccess("Aviso", "N° Tramite STID Encontrado")
						ManInforme_AddEditConservacion.Denuncia.objDeuncia.tra_M_Tramite = response;
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
				if (response.iCodTramite !== -1) {
					utilSigo.toastSuccess("Aviso", "N° Tramite STID Encontrado")
					ManInforme_AddEditConservacion.Denuncia.objDeuncia.tra_M_Tramite = response;
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
			ManInforme_AddEditConservacion.Denuncia.objDeuncia.tra_M_Tramite = {};
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
				ManInforme_AddEditConservacion.Denuncia.objDeuncia.tra_M_Tramite = data.tra_M_Tramite;
				$('#inptExpediente').val(ManInforme_AddEditConservacion.Denuncia.objDeuncia.tra_M_Tramite.cCodificacion);
				$('.responseOk').show();
				$('.responseError').hide();
			}
			ManInforme_AddEditConservacion.Denuncia.objDeuncia.COD_IDENUNCIA = data.COD_IDENUNCIA;
			if (data.IATENDIDO === 1) {
				$('#rbtnAtendido1').prop('checked', true);
			} else if (data.IATENDIDO === 2) {
				$('#rbtnAtendido2').prop('checked', true);
			}
		});
	}
};

ManInforme_AddEditConservacion.Incidencia = {
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
						ManInforme_AddEditConservacion.Incidencia.tablaIncidencia.ajax.reload();
						ManInforme_AddEditConservacion.Incidencia.limpiar();
					}
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
			contentType: typeof optionDenuncia.contentType === 'undefined' ? 'application/json; charset=utf-8' : optionDenuncia.contentType,
			dataType: typeof optionDenuncia.dataType === 'undefined' ? 'json' : optionDenuncia.dataType,
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
				$('#NIVEL_1').val((h1 === '' ? '00' : h1));
				let h2 = $('#h2').val();
				$('#NIVEL_2').val((h2 === '' ? '00' : h2));

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
		ManInforme_AddEditConservacion.Incidencia.cargarData('RIESGO', 'cboRIESGO');
		ManInforme_AddEditConservacion.Incidencia.cargarData('PROCESO', 'cboPROCESO');
		ManInforme_AddEditConservacion.Incidencia.cargarData('CIRCUNSTANCIA', 'cboCIRCUNSTANCIA');
		ManInforme_AddEditConservacion.Incidencia.cargarData('EFECTO', 'cboEFECTO');
		$('#NIVEL_1').val('00');
		$('#NIVEL_2').val('00');
	},
	eventos: function () {

		$('#cboRIESGO').change(function () {
			ManInforme_AddEditConservacion.Incidencia.cargarData('NIVEL 2', 'NIVEL_2', $(this).val());
			ManInforme_AddEditConservacion.Incidencia.cargarData('NIVEL 1', 'NIVEL_1', $(this).val());
		});

		$('#BtnGuardar').click(function () {
			if (ManInforme_AddEditConservacion.Incidencia.validarIncidencia()) {
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
				};
				var option = {
					url: urlLocalSigo + "Supervision/Denuncias/crud_Incidencia",
					datos: JSON.stringify(obj),
					type: 'POST'
				};
				utilSigo.fnAjax(option, function (data) {
					if (data.COD_IINCIDENCIA != '0') {
						ManInforme_AddEditConservacion.Incidencia.tablaIncidencia.ajax.reload();
						ManInforme_AddEditConservacion.Incidencia.limpiar();
						$('#BtnGuardar').text('GUARDAR');
					};
				});
			}
		});

		$('#BtnLimpiar').click(function () {
			ManInforme_AddEditConservacion.Incidencia.limpiar();
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
	},
	cargarIncidencias: function () {
		ManInforme_AddEditConservacion.Incidencia.tablaIncidencia =
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
							console.log(resultado);
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
								"onClick='ManInforme_AddEditConservacion.Incidencia.Editar(" + JSON.stringify(row) + ")'>Editar</button>";
							str += '<button class="btn btn-danger btn-xs btn-edit" type="button" ' +
								'onClick="ManInforme_AddEditConservacion.Incidencia.Eliminar(\'' + row.COD_IINCIDENCIA + '\')">Eliminar</button> ';

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
	},
	validarIncidencia: function () {
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
};

ManInforme_AddEditConservacion.fnLoadData = function (obj, tipo) {
	switch (tipo) {
		case "DataCoordenadaUTM": ManInforme_AddEditConservacion.DataCoordenadaUTM = JSON.parse(obj); break;
		case "DataPrograma": ManInforme_AddEditConservacion.DataPrograma = JSON.parse(obj); break;
		case "DataInfraestructura": ManInforme_AddEditConservacion.DataInfraestructura = JSON.parse(obj); break;
		case "DataActividadPrograma": ManInforme_AddEditConservacion.DataActividadPrograma = JSON.parse(obj); break;
		case "DataManejoImpacto": ManInforme_AddEditConservacion.DataManejoImpacto = JSON.parse(obj); break;
		case "DataRegFlora": ManInforme_AddEditConservacion.DataRegFlora = JSON.parse(obj); break;
		case "DataRegPaisaje": ManInforme_AddEditConservacion.DataRegPaisaje = JSON.parse(obj); break;
		case "DataZonificacion": ManInforme_AddEditConservacion.DataZonificacion = JSON.parse(obj); break;
		case "DataEquipamiento": ManInforme_AddEditConservacion.DataEquipamiento = JSON.parse(obj); break;
		case "DataActTuristica": ManInforme_AddEditConservacion.DataActTuristica = JSON.parse(obj); break;
		case "DataIntAmbiental": ManInforme_AddEditConservacion.DataIntAmbiental = JSON.parse(obj); break;
		case "DataActInvestigacion": ManInforme_AddEditConservacion.DataActInvestigacion = JSON.parse(obj); break;
		case "DataActVisitas": ManInforme_AddEditConservacion.DataActVisitas = JSON.parse(obj); break;
		case "DataActOtroPrograma": ManInforme_AddEditConservacion.DataActOtroPrograma = JSON.parse(obj); break;
	}
};

ManInforme_AddEditConservacion.fnReturnIndex = function (alertaInicial) {
	var url = urlLocalSigo + "Supervision/ManInforme/Index";

	if (alertaInicial == null || alertaInicial == "") {
		window.location = url;
	} else {
		window.location = url + "?_alertaIncial=" + alertaInicial;
	}
};

ManInforme_AddEditConservacion.fnBuscarPersona = function (_dom, _tipoPersonaSIGOsfc) {
	var url = urlLocalSigo + "General/Controles/_BuscarPersonaGeneral";
	var option = { url: url, type: 'GET', datos: { asBusGrupo: "PERSONA", asCodPTipo: _tipoPersonaSIGOsfc, asTipoPersona: "N" }, divId: "mdlBuscarPersona" };
	utilSigo.fnOpenModal(option, function () {
		_bPerGen.fnAsignarDatos = function (obj) {
			if (obj != null && obj != "") {
				var data = _bPerGen.dtBuscarPerona.row($(obj).parents('tr')).data();
				switch (_dom) {
					case "TITULAR_EJECUTA":
						ManInforme_AddEditConservacion.frm.find("#hdfCodTitularEjecutaPgmf").val(data["COD_PERSONA"]);
						ManInforme_AddEditConservacion.frm.find("#txtTitularEjecutaPgmf").val(data["PERSONA"]);
						break;
					case "REGENTE_IMPLEMENTA":
						ManInforme_AddEditConservacion.frm.find("#hdfCodRegenteImplPgmf").val(data["COD_PERSONA"]);
						ManInforme_AddEditConservacion.frm.find("#txtRegenteImplPgmf").val(data["PERSONA"]);
						break;
				}
				utilSigo.fnCloseModal("mdlBuscarPersona");
			}
		};
		_bPerGen.fnInit();
	});
};

ManInforme_AddEditConservacion.fnViewModalUbigeo = function () {
	var url = initSigo.urlControllerGeneral + "_Ubigeo";
	var option = { url: url, type: 'POST', datos: {}, divId: "mdlControles_Ubigeo" };
	utilSigo.fnOpenModal(option, function () {
		_Ubigeo.fnSelectUbigeo = function (_ubigeoText, _ubigeoId) {
			ManInforme_AddEditConservacion.frm.find("#hdfCodUbigeo").val(_ubigeoId);
			ManInforme_AddEditConservacion.frm.find("#txtUbigeo").val(_ubigeoText);
			$("#mdlControles_Ubigeo").modal('hide');
		};
		_Ubigeo.fnLoadModalView(ManInforme_AddEditConservacion.frm.find("#hdfCodUbigeo").val());
	});
};

ManInforme_AddEditConservacion.fnInitDataTable_Detail = function () {
	var columns_label = [], columns_data = [], options = {}, data_extend = [];

	//Cargar las coordenadas UTM
	columns_label = ["Vértice", "Zona UTM", "Zona UTM Campo", "Coordenada Este", "Coordenada Este Campo", "Coordenada Norte", "Coordenada Norte Campo"];
	columns_data = ["VERTICE", "ZONA", "ZONA_CAMPO", "COORDENADA_ESTE", "COORDENADA_ESTE_CAMPO", "COORDENADA_NORTE", "COORDENADA_NORTE_CAMPO"];
	options = {
		page_length: 10, row_edit: true, row_fnEdit: "ManInforme_AddEditConservacion.fnAddEditConservacion(this,'COORDENADA_UTM')"
		, row_delete: true, row_fnDelete: "ManInforme_AddEditConservacion.fnDeleteConservacion('COORDENADA_UTM',this)", row_index: true, page_sort: true
	};
	ManInforme_AddEditConservacion.dtCoordenadaUTM = utilDt.fnLoadDataTable_Detail(ManInforme_AddEditConservacion.frm.find("#tbCoordenadaUTM"), columns_label, columns_data, options);
	ManInforme_AddEditConservacion.dtCoordenadaUTM.rows.add(ManInforme_AddEditConservacion.DataCoordenadaUTM).draw();
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
			"data": "OBSERVACION", "title": "Observación", "width": "50%", "orderable": false, "searchable": false, "mRender": function (data, type, row, meta) {
				return '<input class="form-control form-control-sm" type="text" value="' + data + '" style="width:100%;">';
			}
		}
	];
	options = { page_length: 10, row_index: true, data_extend: data_extend, page_autowidth: false };
	ManInforme_AddEditConservacion.dtDelimitacion = utilDt.fnLoadDataTable_Detail(ManInforme_AddEditConservacion.frm.find("#tbDelimitacion"), columns_label, columns_data, options);
	ManInforme_AddEditConservacion.dtDelimitacion.rows.add(ManInforme_AddEditConservacion.DataPrograma.filter(m => m.TIPO_PROGRAMA == "DC")).draw();
	//Cargar Programa de protección del área y seguridad del visitante
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
			"data": "COD_PROGRAMA", "title": "Observación", "width": "65%", "orderable": false, "searchable": false, "mRender": function (data, type, row, meta) {
				var txtTipo = 'Tipo<input id="txtItemTipo" class="form-control form-control-sm" type="text" value="' + row.TIPO + '" style="width:50%;">';
				var txtFrecuencia = 'Frecuencia<input id="txtItemFrecuencia" class="form-control form-control-sm" type="text" value="' + row.FRECUENCIA + '" style="width:50%;">';
				var txtObservacion = '<input id="txtItemObservacion" class="form-control form-control-sm" type="text" value="' + row.OBSERVACION + '" style="width:100%;">';
				var txtValor = txtObservacion;
				switch (data) {
					case 9: txtValor = txtTipo + txtFrecuencia; break;
					case 11:
					case 12:
					case 13: txtValor = txtTipo; break;
				}
				return txtValor;
			}
		}
	];
	options = { page_length: 15, row_index: true, data_extend: data_extend, page_autowidth: false };
	ManInforme_AddEditConservacion.dtProgramaProteccion = utilDt.fnLoadDataTable_Detail(ManInforme_AddEditConservacion.frm.find("#tbProgramaProteccion"), columns_label, columns_data, options);

	//Cargar Programa de Seguridad del Turista
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
			"data": "COD_PROGRAMA", "title": "Observación", "width": "65%", "orderable": false, "searchable": false, "mRender": function (data, type, row, meta) {
				var txtTipo = 'Tipo<input id="txtItemTipo" class="form-control form-control-sm" type="text" value="' + row.TIPO + '" style="width:50%;">';
				var txtFrecuencia = 'Frecuencia<input id="txtItemFrecuencia" class="form-control form-control-sm" type="text" value="' + row.FRECUENCIA + '" style="width:50%;">';
				var txtObservacion = '<input id="txtItemObservacion" class="form-control form-control-sm" type="text" value="' + row.OBSERVACION + '" style="width:100%;">';
				var txtValor = txtObservacion;
				switch (data) {
					case 9: txtValor = txtTipo + txtFrecuencia; break;
					case 11:
					case 12:
					case 13: txtValor = txtTipo; break;
				}
				return txtValor;
			}
		}
	];
	options = { page_length: 15, row_index: true, data_extend: data_extend, page_autowidth: false };
	ManInforme_AddEditConservacion.dtProgramaSegTurista = utilDt.fnLoadDataTable_Detail(ManInforme_AddEditConservacion.frm.find("#tbProgramaSegTurista"), columns_label, columns_data, options);

	//Cargar Programa de Informacion Adicional
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
			"data": "COD_PROGRAMA", "title": "Observación", "width": "65%", "orderable": false, "searchable": false, "mRender": function (data, type, row, meta) {
				var txtTipo = 'Tipo<input id="txtItemTipo" class="form-control form-control-sm" type="text" value="' + row.TIPO + '" style="width:50%;">';
				var txtFrecuencia = 'Frecuencia<input id="txtItemFrecuencia" class="form-control form-control-sm" type="text" value="' + row.FRECUENCIA + '" style="width:50%;">';
				var txtObservacion = '<input id="txtItemObservacion" class="form-control form-control-sm" type="text" value="' + row.OBSERVACION + '" style="width:100%;">';
				var txtValor = txtObservacion;
				switch (data) {
					case 9: txtValor = txtTipo + txtFrecuencia; break;
					case 11:
					case 12:
					case 13: txtValor = txtTipo; break;
				}
				return txtValor;
			}
		}
	];
	options = { page_length: 15, row_index: true, data_extend: data_extend, page_autowidth: false };
	ManInforme_AddEditConservacion.dtInfoAdicional = utilDt.fnLoadDataTable_Detail(ManInforme_AddEditConservacion.frm.find("#tbInfoAdicional"), columns_label, columns_data, options);


	//Cargar Programa Monitoreo y Evaluación - Evaluar actividades
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
			"data": "OBSERVACION", "title": "Observación", "width": "50%", "orderable": false, "searchable": false, "mRender": function (data, type, row, meta) {
				return '<input class="form-control form-control-sm" type="text" value="' + data + '" style="width:100%;">';
			}
		}
	];
	options = { page_length: 10, row_index: true, data_extend: data_extend, page_autowidth: false };
	ManInforme_AddEditConservacion.dtEvaluacionActividad = utilDt.fnLoadDataTable_Detail(ManInforme_AddEditConservacion.frm.find("#tbEvaluacionActividad"), columns_label, columns_data, options);
	//Cargar la Actividad de turística
	columns_label = ["DESCRIPCION", "ZONA UTM", "COORDENADA ESTE", "COORDENADA NORTE"];
	columns_data = ["VDESCRIPCION", "VZONAUTM", "VCOORDENADAESTE", "VCOORDENADANORTE"];
	options = {
		page_length: 10, row_edit: true, row_fnEdit: "ManInforme_AddEditConservacion.fnAddEditConservacion(this,'ACT_TURISTICA')"
		, row_delete: true, row_fnDelete: "ManInforme_AddEditConservacion.fnDeleteConservacion('ACT_TURISTICA',this)", row_index: true, page_sort: true
	};
	ManInforme_AddEditConservacion.dtActTuristica = utilDt.fnLoadDataTable_Detail(ManInforme_AddEditConservacion.frm.find("#tbActTuristica"), columns_label, columns_data, options);

	//Cargar Interpretacion AMbiental
	columns_label = ["DESCRIPCION", "ZONA UTM", "COORDENADA ESTE", "COORDENADA NORTE", "OBSERVACION"];
	columns_data = ["VDESCRIPCION", "VZONAUTM", "VCOORDENADAESTE", "VCOORDENADANORTE", "VOBSERVACION"];
	options = {
		page_length: 10, row_edit: true, row_fnEdit: "ManInforme_AddEditConservacion.fnAddEditConservacion(this,'INTERP_AMBIENTAL')"
		, row_delete: true, row_fnDelete: "ManInforme_AddEditConservacion.fnDeleteConservacion('INTERP_AMBIENTAL',this)", row_index: true, page_sort: true
	};
	ManInforme_AddEditConservacion.dtIntAmbiental = utilDt.fnLoadDataTable_Detail(ManInforme_AddEditConservacion.frm.find("#tbIntAmbiental"), columns_label, columns_data, options);

	//Cargar la Actividad de Investigacion
	columns_label = ["DESCRIPCION", "OBJETIVO", "AVANCE", "ZONA UTM", "COORDENADA ESTE", "COORDENADA NORTE", "OBSERVACION"];
	columns_data = ["VDESCRIPCION", "VOBJETIVO", "VAVANCE", "VZONAUTM", "VCOORDENADAESTE", "VCOORDENADANORTE", "VOBSERVACION"];
	options = {
		page_length: 10, row_edit: true, row_fnEdit: "ManInforme_AddEditConservacion.fnAddEditConservacion(this,'ACT_INVESTIGACION')"
		, row_delete: true, row_fnDelete: "ManInforme_AddEditConservacion.fnDeleteConservacion('ACT_INVESTIGACION',this)", row_index: true, page_sort: true
	};
	ManInforme_AddEditConservacion.dtInvestigacion = utilDt.fnLoadDataTable_Detail(ManInforme_AddEditConservacion.frm.find("#tbActInvestigacion"), columns_label, columns_data, options);

	//Cargar Visitas
	columns_label = ["DESCRIPCION", "PERFIL"];
	columns_data = ["VDESCRIPCION", "VPERFIL"];
	options = {
		page_length: 10, row_edit: true, row_fnEdit: "ManInforme_AddEditConservacion.fnAddEditConservacion(this,'ACT_VISITAS')"
		, row_delete: true, row_fnDelete: "ManInforme_AddEditConservacion.fnDeleteConservacion('ACT_VISITAS',this)", row_index: true, page_sort: true
	};
	ManInforme_AddEditConservacion.dtVisitas = utilDt.fnLoadDataTable_Detail(ManInforme_AddEditConservacion.frm.find("#tbActVisitas"), columns_label, columns_data, options);

	//Cargar Otros Programas
	columns_label = ["DESCRIPCION"];
	columns_data = ["VDESCRIPCION"];
	options = {
		page_length: 10, row_edit: true, row_fnEdit: "ManInforme_AddEditConservacion.fnAddEditConservacion(this,'ACT_OTROS_PROGRAMAS')"
		, row_delete: true, row_fnDelete: "ManInforme_AddEditConservacion.fnDeleteConservacion('ACT_OTROS_PROGRAMAS',this)", row_index: true, page_sort: true
	};
	ManInforme_AddEditConservacion.dtOtrosProgramas = utilDt.fnLoadDataTable_Detail(ManInforme_AddEditConservacion.frm.find("#tbActOtroPrograma"), columns_label, columns_data, options);

	//Cargar la Infraestructura Implementada
	columns_label = ["Tipo de Ambiente", "Nro de Ambiente", "Área", "Capacidad", "Material de Construcción"];
	columns_data = ["TIPO_AMBIENTE", "NUM_AMBIENTE", "AREA", "CAPACIDAD", "MATERIAL_CONSTRUCCION"];
	options = {
		page_length: 10, row_edit: true, row_fnEdit: "ManInforme_AddEditConservacion.fnAddEditConservacion(this,'INFRAESTRUCTURA_ECOT')"
		, row_delete: true, row_fnDelete: "ManInforme_AddEditConservacion.fnDeleteConservacion('INFRAESTRUCTURA_ECOT',this)", row_index: true, page_sort: true
	};
	ManInforme_AddEditConservacion.dtInfraestructura = utilDt.fnLoadDataTable_Detail(ManInforme_AddEditConservacion.frm.find("#tbInfraestructura"), columns_label, columns_data, options);
	//Infraestructura 2
	columns_label = ["Tipo de Ambiente", "Nro de Ambiente", "Área", "Uso", "Material de Construcción", "Estado Conservación", "Objetivo"];
	columns_data = ["TIPO_AMBIENTE", "NUM_AMBIENTE", "AREA", "USO", "MATERIAL_CONSTRUCCION", "ESTADO_CONSERVACION", "OBJETIVO"];
	options = {
		page_length: 10, row_edit: true, row_fnEdit: "ManInforme_AddEditConservacion.fnAddEditConservacion(this,'INFRAESTRUCTURA_CONS')"
		, row_delete: true, row_fnDelete: "ManInforme_AddEditConservacion.fnDeleteConservacion('INFRAESTRUCTURA_CONS',this)", row_index: true, page_sort: true
	};
	ManInforme_AddEditConservacion.dtInfraestructuraCons = utilDt.fnLoadDataTable_Detail(ManInforme_AddEditConservacion.frm.find("#tbInfraestructuraCons"), columns_label, columns_data, options);
	//Cargar Programa de Participación Local
	columns_label = ["Actividad", "Fecha de Realización", "Nro. de Participantes"];
	columns_data = ["ACTIVIDAD_REALIZADA", "FECHA_REALIZADA", "NUM_PERSONA"];
	options = {
		page_length: 10, row_edit: true, row_fnEdit: "ManInforme_AddEditConservacion.fnAddEditConservacion(this,'PROGRAMA_PARTICIPACION')"
		, row_delete: true, row_fnDelete: "ManInforme_AddEditConservacion.fnDeleteConservacion('PROGRAMA_PARTICIPACION',this)", row_index: true, page_sort: true
	};
	ManInforme_AddEditConservacion.dtProgParticipacion = utilDt.fnLoadDataTable_Detail(ManInforme_AddEditConservacion.frm.find("#tbProgParticipacion"), columns_label, columns_data, options);
	//Cargar Programa de Capacitación
	columns_label = ["Actividad", "Fecha de Realización", "Nro. de Participantes", "Tipo de Registro"];
	columns_data = ["ACTIVIDAD_REALIZADA", "FECHA_REALIZADA", "NUM_PERSONA", "DESC_TIPO_REGISTRO"];
	data_extend = [
		{
			"data": "ESTADO_DOCUMENTO", "title": "Se Encuentra Documentado", "width": "5%", "orderable": false, "searchable": false, "mRender": function (data, type, row, meta) {
				return data == true ? "SI" : "NO";
			}
		}
	];
	options = {
		page_length: 10, row_edit: true, row_fnEdit: "ManInforme_AddEditConservacion.fnAddEditConservacion(this,'PROGRAMA_CAPACITACION')"
		, row_delete: true, row_fnDelete: "ManInforme_AddEditConservacion.fnDeleteConservacion('PROGRAMA_CAPACITACION',this)", row_index: true, page_sort: true, data_extend: data_extend
	};
	ManInforme_AddEditConservacion.dtProgCapacitacion = utilDt.fnLoadDataTable_Detail(ManInforme_AddEditConservacion.frm.find("#tbProgCapacitacion"), columns_label, columns_data, options);
	//Cargar Programa de Investigación
	columns_label = ["Actividad", "Objetivo", "Avance y Resultados"];
	columns_data = ["ACTIVIDAD_REALIZADA", "OBJETIVO", "AVANCE_RESULTADO"];
	options = {
		page_length: 10, row_edit: true, row_fnEdit: "ManInforme_AddEditConservacion.fnAddEditConservacion(this,'PROGRAMA_INVESTIGACION')"
		, row_delete: true, row_fnDelete: "ManInforme_AddEditConservacion.fnDeleteConservacion('PROGRAMA_INVESTIGACION',this)", row_index: true, page_sort: true
	};
	ManInforme_AddEditConservacion.dtProgInvestigacion = utilDt.fnLoadDataTable_Detail(ManInforme_AddEditConservacion.frm.find("#tbProgInvestigacion"), columns_label, columns_data, options);
	//Cargar Programa de Interpretación Ambiental
	columns_label = ["Actividad", "Avance y Resultados"];
	columns_data = ["ACTIVIDAD_REALIZADA", "AVANCE_RESULTADO"];
	options = {
		page_length: 10, row_edit: true, row_fnEdit: "ManInforme_AddEditConservacion.fnAddEditConservacion(this,'PROGRAMA_INTERPRETACION')"
		, row_delete: true, row_fnDelete: "ManInforme_AddEditConservacion.fnDeleteConservacion('PROGRAMA_INTERPRETACION',this)", row_index: true, page_sort: true
	};
	ManInforme_AddEditConservacion.dtProgInterpretacion = utilDt.fnLoadDataTable_Detail(ManInforme_AddEditConservacion.frm.find("#tbProgInterpretacion"), columns_label, columns_data, options);

	//Cargar Programa de Promoción y Marketing
	columns_label = ["Actividad", "Avance y Resultados"];
	columns_data = ["ACTIVIDAD_REALIZADA", "AVANCE_RESULTADO"];
	options = {
		page_length: 10, row_edit: true, row_fnEdit: "ManInforme_AddEditConservacion.fnAddEditConservacion(this,'PROGRAMA_PROMOCION')"
		, row_delete: true, row_fnDelete: "ManInforme_AddEditConservacion.fnDeleteConservacion('PROGRAMA_PROMOCION',this)", row_index: true, page_sort: true
	};
	ManInforme_AddEditConservacion.dtProgPromocion = utilDt.fnLoadDataTable_Detail(ManInforme_AddEditConservacion.frm.find("#tbProgPromocion"), columns_label, columns_data, options);
	//Cargar Programa de Monitoreo y Evaluación
	columns_label = ["Actividad", "Avance y Resultados"];
	columns_data = ["ACTIVIDAD_REALIZADA", "AVANCE_RESULTADO"];
	options = {
		page_length: 10, row_edit: true, row_fnEdit: "ManInforme_AddEditConservacion.fnAddEditConservacion(this,'PROGRAMA_MONITOREO')"
		, row_delete: true, row_fnDelete: "ManInforme_AddEditConservacion.fnDeleteConservacion('PROGRAMA_MONITOREO',this)", row_index: true, page_sort: true
	};
	ManInforme_AddEditConservacion.dtProgMonitoreo = utilDt.fnLoadDataTable_Detail(ManInforme_AddEditConservacion.frm.find("#tbProgMonitoreo"), columns_label, columns_data, options);
	//Cargar Programa de Identificación y Manejo de Impactos
	columns_label = ["Tipo de Impacto", "Riesgo Potencial", "Actividades Preventivas/Correctivas", "Resultados"];
	columns_data = ["TIPO_IMPACTO", "RIESGO_POTENCIAL", "ACTIVIDAD", "AVANCE_RESULTADO"];
	options = {
		page_length: 10, row_edit: true, row_fnEdit: "ManInforme_AddEditConservacion.fnAddEditConservacion(this,'PROGRAMA_IDENTIFICACION')"
		, row_delete: true, row_fnDelete: "ManInforme_AddEditConservacion.fnDeleteConservacion('PROGRAMA_IDENTIFICACION',this)", row_index: true, page_sort: true
	};
	ManInforme_AddEditConservacion.dtProgIdentificacion = utilDt.fnLoadDataTable_Detail(ManInforme_AddEditConservacion.frm.find("#tbProgIdentificacion"), columns_label, columns_data, options);
	//Cargar Registro Flora
	columns_label = ["Especie", "DAP", "Altura Total", "Zona UTM", "Coordenada Este", "Coordenada Norte", "Estado", "Observación"];
	columns_data = ["ESPECIES", "DAP", "ALTURA_TOTAL", "ZONA", "COORDENADA_ESTE", "COORDENADA_NORTE", "ESTADO_ESPECIE", "OBSERVACION"];
	options = {
		page_length: 10, row_edit: true, row_fnEdit: "ManInforme_AddEditConservacion.fnAddEditConservacion(this,'REGISTRO_FLORA')"
		, row_delete: true, row_fnDelete: "ManInforme_AddEditConservacion.fnDeleteConservacion('REGISTRO_FLORA',this)", row_index: true, page_sort: true
	};
	ManInforme_AddEditConservacion.dtRegFlora = utilDt.fnLoadDataTable_Detail(ManInforme_AddEditConservacion.frm.find("#tbRegFlora"), columns_label, columns_data, options);
	ManInforme_AddEditConservacion.dtRegFlora.rows.add(ManInforme_AddEditConservacion.DataRegFlora).draw();
	//Cargar Registro Paisajes
	columns_label = ["Paisaje/Tipo", "Estado", "Nro. Visitantes/Mes", "Zona UTM", "Coordenada Este", "Coordenada Norte", "Observación"];
	columns_data = ["TIPO", "ESTADO_PAISAJE", "NUM_VISITANTE", "ZONA", "COORDENADA_ESTE", "COORDENADA_NORTE", "OBSERVACION"];
	options = {
		page_length: 10, row_edit: true, row_fnEdit: "ManInforme_AddEditConservacion.fnAddEditConservacion(this,'REGISTRO_PAISAJE')"
		, row_delete: true, row_fnDelete: "ManInforme_AddEditConservacion.fnDeleteConservacion('REGISTRO_PAISAJE',this)", row_index: true, page_sort: true
	};
	ManInforme_AddEditConservacion.dtRegPaisaje = utilDt.fnLoadDataTable_Detail(ManInforme_AddEditConservacion.frm.find("#tbRegPaisaje"), columns_label, columns_data, options);
	ManInforme_AddEditConservacion.dtRegPaisaje.rows.add(ManInforme_AddEditConservacion.DataRegPaisaje).draw();
	//Cargar Zonificación Concesión
	columns_label = ["Nombre Zona", "Característica", "Zona UTM", "Coordenada Este", "Coordenada Norte", "Tipo Señalización", "Tipo Delimitación"];
	columns_data = ["NOMBRE_ZONA", "CARACTERISTICA", "ZONA", "COORDENADA_ESTE", "COORDENADA_NORTE", "TIPO_SENALIZACION", "TIPO_DELIMITACION"];
	options = {
		page_length: 10, row_edit: true, row_fnEdit: "ManInforme_AddEditConservacion.fnAddEditConservacion(this,'ZONIFICACION_CONS')"
		, row_delete: true, row_fnDelete: "ManInforme_AddEditConservacion.fnDeleteConservacion('ZONIFICACION_CONS',this)", row_index: true, page_sort: true
	};
	ManInforme_AddEditConservacion.dtZonificacionCons = utilDt.fnLoadDataTable_Detail(ManInforme_AddEditConservacion.frm.find("#tbZonificacionCons"), columns_label, columns_data, options);
	//Cargar Equipamiento Concesión
	columns_label = ["Descripción", "Número", "Uso", "Estado Conservación", "Objetivo", "Observación"];
	columns_data = ["DESCRIPCION", "NUM_AMBIENTE", "USO", "ESTADO_CONSERVACION", "OBJETIVO", "OBSERVACION"];
	options = {
		page_length: 10, row_edit: true, row_fnEdit: "ManInforme_AddEditConservacion.fnAddEditConservacion(this,'EQUIPAMIENTO_CONS')"
		, row_delete: true, row_fnDelete: "ManInforme_AddEditConservacion.fnDeleteConservacion('EQUIPAMIENTO_CONS',this)", row_index: true, page_sort: true
	};
	ManInforme_AddEditConservacion.dtEquipamientoCons = utilDt.fnLoadDataTable_Detail(ManInforme_AddEditConservacion.frm.find("#tbEquipamientoCons"), columns_label, columns_data, options);
	//Cargar Capacitaciones Efectuadas
	columns_label = ["Capacitación", "Nro. Participantes", "Lugar de Capacitación", "Objetivo", "Observación"];
	columns_data = ["ACTIVIDAD_REALIZADA", "NUM_PERSONA", "LUGAR_CAPACITACION", "OBJETIVO", "OBSERVACION"];
	options = {
		page_length: 10, row_edit: true, row_fnEdit: "ManInforme_AddEditConservacion.fnAddEditConservacion(this,'CAPACITACION_CONS')"
		, row_delete: true, row_fnDelete: "ManInforme_AddEditConservacion.fnDeleteConservacion('CAPACITACION_CONS',this)", row_index: true, page_sort: true
	};
	ManInforme_AddEditConservacion.dtCapacitacionCons = utilDt.fnLoadDataTable_Detail(ManInforme_AddEditConservacion.frm.find("#tbCapacitacionCons"), columns_label, columns_data, options);
	//Cargar Actividades desarrolladas con la Poblacion Local
	columns_label = ["Actividad", "Nro. Participantes", "Nombre de la Comunidad", "Objetivo", "Observación"];
	columns_data = ["ACTIVIDAD_REALIZADA", "NUM_PERSONA", "NOMBRE_COMUNIDAD_SECTOR", "OBJETIVO", "OBSERVACION"];
	options = {
		page_length: 10, row_edit: true, row_fnEdit: "ManInforme_AddEditConservacion.fnAddEditConservacion(this,'ACTIVIDAD_CONS')"
		, row_delete: true, row_fnDelete: "ManInforme_AddEditConservacion.fnDeleteConservacion('ACTIVIDAD_CONS',this)", row_index: true, page_sort: true
	};
	ManInforme_AddEditConservacion.dtActividadCons = utilDt.fnLoadDataTable_Detail(ManInforme_AddEditConservacion.frm.find("#tbActividadCons"), columns_label, columns_data, options);
	//Cargar Otros documentos de Gestión de la Concesión
	columns_label = ["Documentos Elaborados/Acuerdos", "Fecha Elaboración", "Objetivo", "Observación"];
	columns_data = ["ACTIVIDAD_REALIZADA", "FECHA_REALIZADA", "OBJETIVO", "OBSERVACION"];
	options = {
		page_length: 10, row_edit: true, row_fnEdit: "ManInforme_AddEditConservacion.fnAddEditConservacion(this,'DOSGESTION_CONS')"
		, row_delete: true, row_fnDelete: "ManInforme_AddEditConservacion.fnDeleteConservacion('DOSGESTION_CONS',this)", row_index: true, page_sort: true
	};
	ManInforme_AddEditConservacion.dtDocGestionCons = utilDt.fnLoadDataTable_Detail(ManInforme_AddEditConservacion.frm.find("#tbDocGestionCons"), columns_label, columns_data, options);

	if (ManInforme_AddEditConservacion.frm.find("#hdfCodMTipo").val() == "0000011") {//Ecoturismo
		ManInforme_AddEditConservacion.dtProgramaProteccion.rows.add(ManInforme_AddEditConservacion.DataPrograma.filter(m => m.TIPO_PROGRAMA == "PAS")).draw();
		ManInforme_AddEditConservacion.dtEvaluacionActividad.rows.add(ManInforme_AddEditConservacion.DataPrograma.filter(m => m.TIPO_PROGRAMA == "PME")).draw();
		ManInforme_AddEditConservacion.dtInfraestructura.rows.add(ManInforme_AddEditConservacion.DataInfraestructura).draw();
		ManInforme_AddEditConservacion.dtProgParticipacion.rows.add(ManInforme_AddEditConservacion.DataActividadPrograma.filter(m => m.COD_PROGRAMA == 19)).draw();
		ManInforme_AddEditConservacion.dtProgCapacitacion.rows.add(ManInforme_AddEditConservacion.DataActividadPrograma.filter(m => m.COD_PROGRAMA == 20)).draw();
		ManInforme_AddEditConservacion.dtProgInvestigacion.rows.add(ManInforme_AddEditConservacion.DataActividadPrograma.filter(m => m.COD_PROGRAMA == 21)).draw();
		ManInforme_AddEditConservacion.dtProgInterpretacion.rows.add(ManInforme_AddEditConservacion.DataActividadPrograma.filter(m => m.COD_PROGRAMA == 22)).draw();
		ManInforme_AddEditConservacion.dtProgPromocion.rows.add(ManInforme_AddEditConservacion.DataActividadPrograma.filter(m => m.COD_PROGRAMA == 23)).draw();
		ManInforme_AddEditConservacion.dtProgMonitoreo.rows.add(ManInforme_AddEditConservacion.DataActividadPrograma.filter(m => m.COD_PROGRAMA == 24)).draw();
		ManInforme_AddEditConservacion.dtProgIdentificacion.rows.add(ManInforme_AddEditConservacion.DataManejoImpacto).draw();
	} else {//Conservación
		ManInforme_AddEditConservacion.dtInfraestructuraCons.rows.add(ManInforme_AddEditConservacion.DataInfraestructura).draw();
		ManInforme_AddEditConservacion.dtZonificacionCons.rows.add(ManInforme_AddEditConservacion.DataZonificacion).draw();
		ManInforme_AddEditConservacion.dtEquipamientoCons.rows.add(ManInforme_AddEditConservacion.DataEquipamiento).draw();
		ManInforme_AddEditConservacion.dtCapacitacionCons.rows.add(ManInforme_AddEditConservacion.DataActividadPrograma.filter(m => m.COD_PROGRAMA == 26)).draw();
		ManInforme_AddEditConservacion.dtActividadCons.rows.add(ManInforme_AddEditConservacion.DataActividadPrograma.filter(m => m.COD_PROGRAMA == 27)).draw();
		ManInforme_AddEditConservacion.dtDocGestionCons.rows.add(ManInforme_AddEditConservacion.DataActividadPrograma.filter(m => m.COD_PROGRAMA == 28)).draw();
	}
	ManInforme_AddEditConservacion.dtActTuristica.rows.add(ManInforme_AddEditConservacion.DataActTuristica).draw();
	ManInforme_AddEditConservacion.dtProgramaSegTurista.rows.add(ManInforme_AddEditConservacion.DataPrograma.filter(m => m.TIPO_PROGRAMA == "PST")).draw();
	ManInforme_AddEditConservacion.dtIntAmbiental.rows.add(ManInforme_AddEditConservacion.DataIntAmbiental).draw();
	ManInforme_AddEditConservacion.dtInfoAdicional.rows.add(ManInforme_AddEditConservacion.DataPrograma.filter(m => m.TIPO_PROGRAMA == "IA")).draw();
	ManInforme_AddEditConservacion.dtInvestigacion.rows.add(ManInforme_AddEditConservacion.DataActInvestigacion).draw();
	ManInforme_AddEditConservacion.dtVisitas.rows.add(ManInforme_AddEditConservacion.DataActVisitas).draw();
	ManInforme_AddEditConservacion.dtOtrosProgramas.rows.add(ManInforme_AddEditConservacion.DataActOtroPrograma).draw();
}

ManInforme_AddEditConservacion.fnInit = function () {
	$.fn.select2.defaults.set("theme", "bootstrap4");
	ManInforme_AddEditConservacion.frm.find("#ddlOdId").select2();
	ManInforme_AddEditConservacion.frm.find("#ddlCuentaCroquisId").select2({ minimumResultsForSearch: -1 });
	ManInforme_AddEditConservacion.frm.find("#ddlCuentaSenderoId").select2({ minimumResultsForSearch: -1 });
	ManInforme_AddEditConservacion.frm.find("#ddlSenalizacionSenderoId").select2({ minimumResultsForSearch: -1 });
	ManInforme_AddEditConservacion.frm.find("#ddlProgParticipacionDocId").select2({ minimumResultsForSearch: -1 });
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
	//CKEDITOR.replace('txtContenido', {
	//	toolbar: initSigo.configuracionCKEDITOR
	//});
	if (window.ckeditorConfig) {
		console.log('init ckeditorConfig');
		DecoupledDocumentEditor.create($('#txtContenido .editor')[0], ckeditorConfig).then(function (editor) {
			window.editor_txtContenido = editor;
			$("#txtContenido .toolbar-container").append(editor.ui.view.toolbar.element);
		});
	}
	utilSigo.fnFormatDate(ManInforme_AddEditConservacion.frm.find("#txtFechaEntrega"));
};

ManInforme_AddEditConservacion.fnAddEditConservacion = function (obj, _tipo) {
	var url = urlLocalSigo, dt = null, _funcModal = {}, oParams = "";

	switch (_tipo) {
		case "COORDENADA_UTM":
			url += "Supervision/ManInformeConservacion/_CoordenadaUTM";
			dt = ManInforme_AddEditConservacion.dtCoordenadaUTM; break;
		case "INFRAESTRUCTURA_ECOT":
			url += "Supervision/ManInformeConservacion/_InfraestructuraImpl";
			dt = ManInforme_AddEditConservacion.dtInfraestructura; oParams = "0000011"; break;
		case "INFRAESTRUCTURA_CONS":
			url += "Supervision/ManInformeConservacion/_InfraestructuraImpl";
			dt = ManInforme_AddEditConservacion.dtInfraestructuraCons; oParams = "0000012"; break;
		case "PROGRAMA_PARTICIPACION":
			url += "Supervision/ManInformeConservacion/_ActividadCapacitacion";
			dt = ManInforme_AddEditConservacion.dtProgParticipacion; oParams = "19"; break;
		case "PROGRAMA_CAPACITACION":
			url += "Supervision/ManInformeConservacion/_ActividadCapacitacion";
			dt = ManInforme_AddEditConservacion.dtProgCapacitacion; oParams = "20"; break;
		case "PROGRAMA_INVESTIGACION":
			url += "Supervision/ManInformeConservacion/_ActividadInvestigacion";
			dt = ManInforme_AddEditConservacion.dtProgInvestigacion; oParams = "21"; break;
		case "PROGRAMA_INTERPRETACION":
			url += "Supervision/ManInformeConservacion/_ActividadInvestigacion";
			dt = ManInforme_AddEditConservacion.dtProgInterpretacion; oParams = "22"; break;
		case "PROGRAMA_PROMOCION":
			url += "Supervision/ManInformeConservacion/_ActividadInvestigacion";
			dt = ManInforme_AddEditConservacion.dtProgPromocion; oParams = "23"; break;
		case "PROGRAMA_MONITOREO":
			url += "Supervision/ManInformeConservacion/_ActividadInvestigacion";
			dt = ManInforme_AddEditConservacion.dtProgMonitoreo; oParams = "24"; break;
		case "PROGRAMA_IDENTIFICACION":
			url += "Supervision/ManInformeConservacion/_ManejoImpacto";
			dt = ManInforme_AddEditConservacion.dtProgIdentificacion; break;
		case "REGISTRO_FLORA":
			url += "Supervision/ManInformeConservacion/_RegistroFlora";
			dt = ManInforme_AddEditConservacion.dtRegFlora; break;
		case "REGISTRO_PAISAJE":
			url += "Supervision/ManInformeConservacion/_RegistroPaisaje";
			dt = ManInforme_AddEditConservacion.dtRegPaisaje; break;
		case "ZONIFICACION_CONS":
			url += "Supervision/ManInformeFauna/_Zonificacion";
			dt = ManInforme_AddEditConservacion.dtZonificacionCons; break;
		case "EQUIPAMIENTO_CONS":
			url += "Supervision/ManInformeConservacion/_EquipamientoCons";
			dt = ManInforme_AddEditConservacion.dtEquipamientoCons; break;
		case "CAPACITACION_CONS":
			url += "Supervision/ManInformeConservacion/_CapacitacionEfectuadaCons";
			dt = ManInforme_AddEditConservacion.dtCapacitacionCons; oParams = "26"; break;
		case "ACTIVIDAD_CONS":
			url += "Supervision/ManInformeConservacion/_ActividadLocalCons";
			dt = ManInforme_AddEditConservacion.dtActividadCons; oParams = "27"; break;
		case "DOSGESTION_CONS":
			url += "Supervision/ManInformeConservacion/_DocumentoGestionCons";
			dt = ManInforme_AddEditConservacion.dtDocGestionCons; oParams = "28"; break;
		case "ACT_TURISTICA":
			url += "Supervision/ManInformeConservacion/_ActTuristica";
			dt = ManInforme_AddEditConservacion.dtActTuristica; oParams = "0000011"; break;
		case "INTERP_AMBIENTAL":
			url += "Supervision/ManInformeConservacion/_InterpretacionAmbiental";
			dt = ManInforme_AddEditConservacion.dtIntAmbiental; oParams = "0000011"; break;
		case "ACT_INVESTIGACION":
			url += "Supervision/ManInformeConservacion/_ActInvestigacion";
			dt = ManInforme_AddEditConservacion.dtInvestigacion; oParams = "0000011"; break;
		case "ACT_VISITAS":
			url += "Supervision/ManInformeConservacion/_ActVisitas";
			dt = ManInforme_AddEditConservacion.dtVisitas; oParams = "0000011"; break;
		case "ACT_OTROS_PROGRAMAS":
			url += "Supervision/ManInformeConservacion/_ActOtrosProgramas";
			dt = ManInforme_AddEditConservacion.dtOtrosProgramas; oParams = "0000011"; break;
	}

	var option = { url: url, type: 'POST', datos: {}, divId: "mdlManInformeConservacion" };
	utilSigo.fnOpenModal(option, function () {
		switch (_tipo) {
			case "COORDENADA_UTM": _funcModal = _CoordenadaUTM; break;
			case "INFRAESTRUCTURA_ECOT":
			case "INFRAESTRUCTURA_CONS": _funcModal = _InfraestructuraImpl; break;
			case "PROGRAMA_PARTICIPACION":
			case "PROGRAMA_CAPACITACION": _funcModal = _ActividadCapacitacion; break;
			case "PROGRAMA_INVESTIGACION":
			case "PROGRAMA_INTERPRETACION":
			case "PROGRAMA_PROMOCION":
			case "PROGRAMA_MONITOREO": _funcModal = _ActividadInvestigacion; break;
			case "PROGRAMA_IDENTIFICACION": _funcModal = _ManejoImpacto; break;
			case "REGISTRO_FLORA": _funcModal = _RegistroFlora; break;
			case "REGISTRO_PAISAJE": _funcModal = _RegistroPaisaje; break;
			case "ZONIFICACION_CONS": _funcModal = _Zonificacion; break;
			case "EQUIPAMIENTO_CONS": _funcModal = _EquipamientoCons; break;
			case "CAPACITACION_CONS": _funcModal = _CapacitacionEfectuadaCons; break;
			case "ACTIVIDAD_CONS": _funcModal = _ActividadLocalCons; break;
			case "DOSGESTION_CONS": _funcModal = _DocumentoGestionCons; break;
			case "ACT_TURISTICA": _funcModal = _ActTuristica; break;
			case "INTERP_AMBIENTAL": _funcModal = _InterpretacionAmbiental; break;
			case "ACT_INVESTIGACION": _funcModal = _ActInvestigacion; break;
			case "ACT_VISITAS": _funcModal = _ActVisitas; break;
			case "ACT_OTROS_PROGRAMAS": _funcModal = _ActOtrosProgramas; break;
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
				$("#mdlManInformeConservacion").modal('hide');
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
ManInforme_AddEditConservacion.fnDeleteConservacion = function (_tipo, obj, objData) {
	var dt, data;
	switch (_tipo) {
		case "COORDENADA_UTM": dt = ManInforme_AddEditConservacion.dtCoordenadaUTM; break;
		case "INFRAESTRUCTURA_ECOT": dt = ManInforme_AddEditConservacion.dtInfraestructura; break;
		case "INFRAESTRUCTURA_CONS": dt = ManInforme_AddEditConservacion.dtInfraestructuraCons; break;
		case "PROGRAMA_PARTICIPACION": dt = ManInforme_AddEditConservacion.dtProgParticipacion; break;
		case "PROGRAMA_CAPACITACION": dt = ManInforme_AddEditConservacion.dtProgCapacitacion; break;
		case "PROGRAMA_INVESTIGACION": dt = ManInforme_AddEditConservacion.dtProgInvestigacion; break;
		case "PROGRAMA_INTERPRETACION": dt = ManInforme_AddEditConservacion.dtProgInterpretacion; break;
		case "PROGRAMA_PROMOCION": dt = ManInforme_AddEditConservacion.dtProgPromocion; break;
		case "PROGRAMA_MONITOREO": dt = ManInforme_AddEditConservacion.dtProgMonitoreo; break;
		case "PROGRAMA_IDENTIFICACION": dt = ManInforme_AddEditConservacion.dtProgIdentificacion; break;
		case "REGISTRO_FLORA": dt = ManInforme_AddEditConservacion.dtRegFlora; break;
		case "REGISTRO_PAISAJE": dt = ManInforme_AddEditConservacion.dtRegPaisaje; break;
		case "ZONIFICACION_CONS": dt = ManInforme_AddEditConservacion.dtZonificacionCons; break;
		case "EQUIPAMIENTO_CONS": dt = ManInforme_AddEditConservacion.dtEquipamientoCons; break;
		case "CAPACITACION_CONS": dt = ManInforme_AddEditConservacion.dtCapacitacionCons; break;
		case "ACTIVIDAD_CONS": dt = ManInforme_AddEditConservacion.dtActividadCons; break;
		case "DOSGESTION_CONS": dt = ManInforme_AddEditConservacion.dtDocGestionCons; break;
		case "ACT_TURISTICA": dt = ManInforme_AddEditConservacion.dtActTuristica; break;
		case "INTERP_AMBIENTAL": dt = ManInforme_AddEditConservacion.dtIntAmbiental; break;
		case "ACT_INVESTIGACION": dt = ManInforme_AddEditConservacion.dtInvestigacion; break;
		case "ACT_VISITAS": dt = ManInforme_AddEditConservacion.dtVisitas; break;
		case "ACT_OTROS_PROGRAMAS": dt = ManInforme_AddEditConservacion.dtOtrosProgramas; break;

	}

	data = typeof objData !== 'undefined' ? objData : dt.row($(obj).parents('tr')).data();

	if (data["RegEstado"] == "0" || data["RegEstado"] == "2") {

		switch (_tipo) {
			case "COORDENADA_UTM":
				ManInforme_AddEditConservacion.tbEliTABLA.push({
					EliTABLA: "ISUPERVISION_DET_COORDENADAUTM",
					EliVALOR02: data["COD_SECUENCIAL"]
				});
				break;
			case "INFRAESTRUCTURA_ECOT":
			case "INFRAESTRUCTURA_CONS":
				ManInforme_AddEditConservacion.tbEliTABLA.push({
					EliTABLA: "ListISUPERVISION_INFRAESTRUCTURA",
					EliVALOR01: "IFE",
					EliVALOR02: data["COD_SECUENCIAL"]
				});
				break;
			case "PROGRAMA_PARTICIPACION":
			case "PROGRAMA_CAPACITACION":
			case "PROGRAMA_INVESTIGACION":
			case "PROGRAMA_INTERPRETACION":
			case "PROGRAMA_PROMOCION":
			case "PROGRAMA_MONITOREO":
			case "CAPACITACION_CONS":
			case "ACTIVIDAD_CONS":
			case "DOSGESTION_CONS":
				ManInforme_AddEditConservacion.tbEliTABLA.push({
					EliTABLA: "ListISUPERVISION_DET_CAPACITACION_LOCAL",
					EliVALOR01: data["COD_PROGRAMA"],
					EliVALOR02: data["COD_SECUENCIAL"]
				});
				break;
			case "PROGRAMA_IDENTIFICACION":
				ManInforme_AddEditConservacion.tbEliTABLA.push({
					EliTABLA: "ListISUPERVISION_IDENTMANEJOIMPACTO",
					EliVALOR02: data["COD_SECUENCIAL"]
				});
				break;
			case "REGISTRO_FLORA":
				ManInforme_AddEditConservacion.tbEliTABLA.push({
					EliTABLA: "ListISUPERVISION_FLORA_SILVESTRE",
					EliVALOR02: data["COD_SECUENCIAL"]
				});
				break;
			case "REGISTRO_PAISAJE":
				ManInforme_AddEditConservacion.tbEliTABLA.push({
					EliTABLA: "ListISUPERVISION_REC_PAISAJE_CULTURAL",
					EliVALOR02: data["COD_SECUENCIAL"]
				});
				break;
			case "ZONIFICACION_CONS":
				ManInforme_AddEditConservacion.tbEliTABLA.push({
					EliTABLA: "ListISUPERVISION_DET_ZONIFICACION",
					EliVALOR02: data["COD_SECUENCIAL"]
				});
				break;
			case "EQUIPAMIENTO_CONS":
				ManInforme_AddEditConservacion.tbEliTABLA.push({
					EliTABLA: "ListISUPERVISION_DET_EQUIPACONSECION",
					EliVALOR02: data["COD_SECUENCIAL"]
				});
				break;
			case "ACT_TURISTICA":
				ManInforme_AddEditConservacion.tbEliTABLA.push({
					EliTABLA: "ListISDetConservActTuristica",
					EliVALOR02: data["NINDICE"]
				});
				break;
			case "INTERP_AMBIENTAL":
				ManInforme_AddEditConservacion.tbEliTABLA.push({
					EliTABLA: "ListISDetConservActIntAmbiental",
					EliVALOR02: data["NINDICE"]
				});
				break;
			case "ACT_INVESTIGACION":
				ManInforme_AddEditConservacion.tbEliTABLA.push({
					EliTABLA: "ListISDetConservActInvestigacion",
					EliVALOR02: data["NINDICE"]
				});
				break;
			case "ACT_VISITAS":
				ManInforme_AddEditConservacion.tbEliTABLA.push({
					EliTABLA: "ListISDetConservActVisitas",
					EliVALOR02: data["NINDICE"]
				});
				break;
			case "ACT_OTROS_PROGRAMAS":
				ManInforme_AddEditConservacion.tbEliTABLA.push({
					EliTABLA: "ListISDetConservActOtroPrograma",
					EliVALOR02: data["NINDICE"]
				});
				break;
		}
	}
	if (typeof objData === 'undefined') {
		dt.row($(obj).parents('tr')).remove().draw(false);
	}
}
ManInforme_AddEditConservacion.fnDeleteAllConservacion = function (_tipo) {
	var dt, data;
	switch (_tipo) {
		case "COORDENADA_UTM": dt = ManInforme_AddEditConservacion.dtCoordenadaUTM; break;
		case "INFRAESTRUCTURA_ECOT": dt = ManInforme_AddEditConservacion.dtInfraestructura; break;
		case "INFRAESTRUCTURA_CONS": dt = ManInforme_AddEditConservacion.dtInfraestructuraCons; break;
		case "PROGRAMA_PARTICIPACION": dt = ManInforme_AddEditConservacion.dtProgParticipacion; break;
		case "PROGRAMA_CAPACITACION": dt = ManInforme_AddEditConservacion.dtProgCapacitacion; break;
		case "PROGRAMA_INVESTIGACION": dt = ManInforme_AddEditConservacion.dtProgInvestigacion; break;
		case "PROGRAMA_INTERPRETACION": dt = ManInforme_AddEditConservacion.dtProgInterpretacion; break;
		case "PROGRAMA_PROMOCION": dt = ManInforme_AddEditConservacion.dtProgPromocion; break;
		case "PROGRAMA_MONITOREO": dt = ManInforme_AddEditConservacion.dtProgMonitoreo; break;
		case "PROGRAMA_IDENTIFICACION": dt = ManInforme_AddEditConservacion.dtProgIdentificacion; break;
		case "REGISTRO_FLORA": dt = ManInforme_AddEditConservacion.dtRegFlora; break;
		case "REGISTRO_PAISAJE": dt = ManInforme_AddEditConservacion.dtRegPaisaje; break;
		case "ZONIFICACION_CONS": dt = ManInforme_AddEditConservacion.dtZonificacionCons; break;
		case "EQUIPAMIENTO_CONS": dt = ManInforme_AddEditConservacion.dtEquipamientoCons; break;
		case "CAPACITACION_CONS": dt = ManInforme_AddEditConservacion.dtCapacitacionCons; break;
		case "ACTIVIDAD_CONS": dt = ManInforme_AddEditConservacion.dtActividadCons; break;
		case "DOSGESTION_CONS": dt = ManInforme_AddEditConservacion.dtDocGestionCons; break;
		case "ACT_TURISTICA": dt = ManInforme_AddEditConservacion.dtActTuristica; break;
		case "INTERP_AMBIENTAL": dt = ManInforme_AddEditConservacion.dtIntAmbiental; break;
		case "ACT_INVESTIGACION": dt = ManInforme_AddEditConservacion.dtInvestigacion; break;
		case "ACT_VISITAS": dt = ManInforme_AddEditConservacion.dtVisitas; break;
		case "ACT_OTROS_PROGRAMAS": dt = ManInforme_AddEditConservacion.dtOtrosProgramas; break;
	}
	if (dt.$("tr").length > 0) {
		utilSigo.dialogConfirm("", "Está seguro de Eliminar Todos los Registros?", function (r) {
			if (r) {
				$.each(dt.$("tr"), function (i, o) {
					data = dt.row($(o)).data();
					ManInforme_AddEditConservacion.fnDeleteConservacion(_tipo, "", data);
				});
				dt.clear().draw();
			}
		});
	} else {
		utilSigo.toastWarning("Aviso", "No se encontraron registros a eliminar");
	}
}
ManInforme_AddEditConservacion.fnGetListConservacion = function (_tipo) {
	var dt, list = [], data;
	switch (_tipo) {
		case "COORDENADA_UTM": dt = ManInforme_AddEditConservacion.dtCoordenadaUTM; break;
		case "INFRAESTRUCTURA_ECOT": dt = ManInforme_AddEditConservacion.dtInfraestructura; break;
		case "INFRAESTRUCTURA_CONS": dt = ManInforme_AddEditConservacion.dtInfraestructuraCons; break;
		case "PROGRAMA_PARTICIPACION": dt = ManInforme_AddEditConservacion.dtProgParticipacion; break;
		case "PROGRAMA_CAPACITACION": dt = ManInforme_AddEditConservacion.dtProgCapacitacion; break;
		case "PROGRAMA_INVESTIGACION": dt = ManInforme_AddEditConservacion.dtProgInvestigacion; break;
		case "PROGRAMA_INTERPRETACION": dt = ManInforme_AddEditConservacion.dtProgInterpretacion; break;
		case "PROGRAMA_PROMOCION": dt = ManInforme_AddEditConservacion.dtProgPromocion; break;
		case "PROGRAMA_MONITOREO": dt = ManInforme_AddEditConservacion.dtProgMonitoreo; break;
		case "PROGRAMA_IDENTIFICACION": dt = ManInforme_AddEditConservacion.dtProgIdentificacion; break;
		case "REGISTRO_FLORA": dt = ManInforme_AddEditConservacion.dtRegFlora; break;
		case "REGISTRO_PAISAJE": dt = ManInforme_AddEditConservacion.dtRegPaisaje; break;
		case "ZONIFICACION_CONS": dt = ManInforme_AddEditConservacion.dtZonificacionCons; break;
		case "EQUIPAMIENTO_CONS": dt = ManInforme_AddEditConservacion.dtEquipamientoCons; break;
		case "CAPACITACION_CONS": dt = ManInforme_AddEditConservacion.dtCapacitacionCons; break;
		case "ACTIVIDAD_CONS": dt = ManInforme_AddEditConservacion.dtActividadCons; break;
		case "DOSGESTION_CONS": dt = ManInforme_AddEditConservacion.dtDocGestionCons; break;
		case "ACT_TURISTICA": dt = ManInforme_AddEditConservacion.dtActTuristica; break;
		case "INTERP_AMBIENTAL": dt = ManInforme_AddEditConservacion.dtIntAmbiental; break;
		case "ACT_INVESTIGACION": dt = ManInforme_AddEditConservacion.dtInvestigacion; break;
		case "ACT_VISITAS": dt = ManInforme_AddEditConservacion.dtVisitas; break;
		case "ACT_OTROS_PROGRAMAS": dt = ManInforme_AddEditConservacion.dtOtrosProgramas; break;
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
ManInforme_AddEditConservacion.fnGetListPrograma = function (_tipo) {
	var list = [], data, dataHtml, dt;

	switch (_tipo) {
		case "DELIMITACION_CONCESION": dt = ManInforme_AddEditConservacion.dtDelimitacion; break;
		case "PROGRAMA_PROTECCION": dt = ManInforme_AddEditConservacion.dtProgramaProteccion; break;
		case "EVALUACION_ACTIVIDAD": dt = ManInforme_AddEditConservacion.dtEvaluacionActividad; break;
		case "PROGR_SEGTURISTA": dt = ManInforme_AddEditConservacion.dtProgramaSegTurista; break;
		case "INF_ADICIONAL": dt = ManInforme_AddEditConservacion.dtInfoAdicional; break;
	}

	if (dt.$("tr").length > 0) {
		$.each(dt.$("tr"), function (i, o) {
			data = dt.row($(o)).data();
			dataHtml = $(o)[0];

			data.RegEstado = data.RegEstado == "0" || data.RegEstado == "2" ? "2" : "1";
			data.ESTADO_PROGRAMA = $($($(dataHtml).find("td")[2]).find('select')[0]).val() == "SI" ? true : false;
			data["OBSERVACION"] = $($($(dataHtml).find("td")[3]).find("input")[0]).val();

			if (_tipo == "PROGRAMA_PROTECCION") {
				data["TIPO"] = $($(dataHtml).find("td")[3]).find("#txtItemTipo").val();
				data["FRECUENCIA"] = $($(dataHtml).find("td")[3]).find("#txtItemFrecuencia").val();
				data["OBSERVACION"] = $($(dataHtml).find("td")[3]).find("#txtItemObservacion").val();
			}

			list.push(utilSigo.fnConvertArrayToObject(data));
		});
	}
	return list;
}

ManInforme_AddEditConservacion.fnSubmitForm = function () {
	var controls = ["ddlIndicadorId", "ddlOdId", "txtNumInforme", "txtFechaInicio", "txtFechaFin"];
	if (!utilSigo.fnValidateForm(ManInforme_AddEditConservacion.frm, controls)) {
		return ManInforme_AddEditConservacion.frm.valid();
	}
	if (!_renderObligacionMandatos.fnValidate()) {
		return false;
	}
	ManInforme_AddEditConservacion.frm.submit();
};

ManInforme_AddEditConservacion.fnSaveForm = function () {
	utilSigo.blockUIGeneral();
	let data = ManInforme_AddEditConservacion.Denuncia.objDeuncia;
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
			var datosInforme = ManInforme_AddEditConservacion.frm.serializeObject();
			datosInforme.vmControlCalidad = _ControlCalidad.fnGetDatosControlCalidad();
			datosInforme.vmInfCNotificacion = _renderCNotificacion.fnGetDatosCNotificacion();
			datosInforme.vmDatoSupervision = _renderDatosSupervision.fnGetDatosSupervision();
			datosInforme.tbSupervisor = _renderSupervisor.fnGetList();
			datosInforme.tbEliTABLA = ManInforme_AddEditConservacion.tbEliTABLA;
			datosInforme.tbEliTABLA = datosInforme.tbEliTABLA.concat(_renderSupervisor.fnGetListEliTABLA());
			datosInforme.tbCoordenadaUTM = ManInforme_AddEditConservacion.fnGetListConservacion("COORDENADA_UTM");
			datosInforme.tbPrograma = ManInforme_AddEditConservacion.fnGetListPrograma("DELIMITACION_CONCESION");
			datosInforme.tbPrograma = datosInforme.tbPrograma.concat(ManInforme_AddEditConservacion.fnGetListPrograma("PROGRAMA_PROTECCION"));
			datosInforme.tbPrograma = datosInforme.tbPrograma.concat(ManInforme_AddEditConservacion.fnGetListPrograma("EVALUACION_ACTIVIDAD"));
			datosInforme.tbPrograma = datosInforme.tbPrograma.concat([{ COD_PROGRAMA: 3, ESTADO_PROGRAMA: ManInforme_AddEditConservacion.frm.find("#ddlProgParticipacionDocId").val() == "SI" ? true : false, RegEstado: ManInforme_AddEditConservacion.frm.find("#hdfRegEstado").val() == 0 ? 2 : 1 }]);
			datosInforme.tbPrograma = datosInforme.tbPrograma.concat(ManInforme_AddEditConservacion.fnGetListPrograma("PROGR_SEGTURISTA"));
			datosInforme.tbPrograma = datosInforme.tbPrograma.concat(ManInforme_AddEditConservacion.fnGetListPrograma("INF_ADICIONAL"));

			datosInforme.tbInfraestructura = ManInforme_AddEditConservacion.fnGetListConservacion("INFRAESTRUCTURA_ECOT");
			datosInforme.tbInfraestructura = datosInforme.tbInfraestructura.concat(ManInforme_AddEditConservacion.fnGetListConservacion("INFRAESTRUCTURA_CONS"));

			datosInforme.tbActividadPrograma = ManInforme_AddEditConservacion.fnGetListConservacion("PROGRAMA_PARTICIPACION");
			datosInforme.tbActividadPrograma = datosInforme.tbActividadPrograma.concat(ManInforme_AddEditConservacion.fnGetListConservacion("PROGRAMA_CAPACITACION"));
			datosInforme.tbActividadPrograma = datosInforme.tbActividadPrograma.concat(ManInforme_AddEditConservacion.fnGetListConservacion("PROGRAMA_INVESTIGACION"));
			datosInforme.tbActividadPrograma = datosInforme.tbActividadPrograma.concat(ManInforme_AddEditConservacion.fnGetListConservacion("PROGRAMA_INTERPRETACION"));
			datosInforme.tbActividadPrograma = datosInforme.tbActividadPrograma.concat(ManInforme_AddEditConservacion.fnGetListConservacion("PROGRAMA_PROMOCION"));
			datosInforme.tbActividadPrograma = datosInforme.tbActividadPrograma.concat(ManInforme_AddEditConservacion.fnGetListConservacion("PROGRAMA_MONITOREO"));
			datosInforme.tbManejoImpacto = ManInforme_AddEditConservacion.fnGetListConservacion("PROGRAMA_IDENTIFICACION");
			datosInforme.tbRegFauna = _renderAvistamientoFauna.fnGetList();
			datosInforme.tbEliTABLA = datosInforme.tbEliTABLA.concat(_renderAvistamientoFauna.fnGetListEliTABLA());
			datosInforme.tbRegFlora = ManInforme_AddEditConservacion.fnGetListConservacion("REGISTRO_FLORA");
			datosInforme.tbRegPaisaje = ManInforme_AddEditConservacion.fnGetListConservacion("REGISTRO_PAISAJE");
			datosInforme.tbZonificacion = ManInforme_AddEditConservacion.fnGetListConservacion("ZONIFICACION_CONS");
			datosInforme.tbEquipamiento = ManInforme_AddEditConservacion.fnGetListConservacion("EQUIPAMIENTO_CONS");
			datosInforme.tbActividadPrograma = datosInforme.tbActividadPrograma.concat(ManInforme_AddEditConservacion.fnGetListConservacion("CAPACITACION_CONS"));
			datosInforme.tbActividadPrograma = datosInforme.tbActividadPrograma.concat(ManInforme_AddEditConservacion.fnGetListConservacion("ACTIVIDAD_CONS"));
			datosInforme.tbActividadPrograma = datosInforme.tbActividadPrograma.concat(ManInforme_AddEditConservacion.fnGetListConservacion("DOSGESTION_CONS"));
			datosInforme.tbObligacion = _renderObligContractual.fnGetList();
			datosInforme.tbEliTABLA = datosInforme.tbEliTABLA.concat(_renderObligContractual.fnGetListEliTABLA());
			datosInforme.tbObligTitular = _renderObligacionTitular.fnGetList();
			datosInforme.tbDesplazamiento = _renderDesplazamiento.fnGetList();
			datosInforme.tbEliTABLA = datosInforme.tbEliTABLA.concat(_renderDesplazamiento.fnGetListEliTABLA());
			//datosInforme.txtConclusion = CKEDITOR.instances["txtConclusion"].getData();
			datosInforme.txtConclusion = window.editor_txtConclusion.getData();
			//datosInforme.txtContenido = CKEDITOR.instances["txtContenido"].getData();
			datosInforme.txtContenido = window.editor_txtContenido.getData();
			datosInforme.tbActTuristica = ManInforme_AddEditConservacion.fnGetListConservacion("ACT_TURISTICA");
			datosInforme.tbImpacto = _frmImpacto.fnGetList();
			datosInforme.tbAfectacion = _frmImpacto.fnGetListAfectacion();
			datosInforme.tbEliTABLAImpacto = _frmImpacto.tbEliTABLA;

			datosInforme.tbActIntAmbiental = ManInforme_AddEditConservacion.fnGetListConservacion("INTERP_AMBIENTAL");
			datosInforme.tbActInvestigacion = ManInforme_AddEditConservacion.fnGetListConservacion("ACT_INVESTIGACION");
			datosInforme.tbActVisitas = ManInforme_AddEditConservacion.fnGetListConservacion("ACT_VISITAS");
			datosInforme.tbActOtroPrograma = ManInforme_AddEditConservacion.fnGetListConservacion("ACT_OTROS_PROGRAMAS");

			//datosInforme.tbEliTABLA = datosInforme.tbEliTABLA.concat(.fnGetListEliTABLA());
			// datosInforme.tbActTuristica = datosInforme.tbActTuristica.concat(ManInforme_AddEditConservacion.fnGetListConservacion("ACT_TURISTICA"));
			datosInforme.hdfRegEstado = datosInforme.hdfRegEstado[0];
			datosInforme.ddlTipoInformeId = _renderDatosSupervision.frm.find("#ddlTipoInformeId").val();

			datosInforme.tbMandatos = _renderMandatos.fnGetList();
			datosInforme.tbMandatos = datosInforme.tbMandatos.concat(_renderMandatos.fnGetListEliTABLA());
			datosInforme.tbObligMandatos = _renderObligacionMandatos.fnGetList();
			datosInforme.tbObligMandatos = datosInforme.tbObligMandatos.concat(_renderObligacionMandatos.fnGetListEliTABLA());

			var option = { url: ManInforme_AddEditConservacion.frm[0].action, datos: JSON.stringify({ dto: datosInforme }), type: 'POST' };
			utilSigo.fnAjax(option, function (data) {
				if (data.success) {
					ManInforme_AddEditConservacion.fnReturnIndex(data.msj);
				}
				else {
					utilSigo.toastWarning("Aviso", data.msj);
				}
			});
		},
		statusCode: { 203: () => { utilSigo.unblockUIGeneral(); } }
	});
};

$(document).ready(function () {
	ManInforme_AddEditConservacion.frm = $("#frmManInforme_AddEditConservacion");

	ManInforme_AddEditConservacion.fnInit();
	ManInforme_AddEditConservacion.fnInitDataTable_Detail();
	if (ManInforme_AddEditConservacion.DataPrograma.filter(m => m.COD_PROGRAMA == 3).length > 0) {
		ManInforme_AddEditConservacion.frm.find("#ddlProgParticipacionDocId").select2("val", [ManInforme_AddEditConservacion.DataPrograma.filter(m => m.COD_PROGRAMA == 3)[0].ESTADO_PROGRAMA == true ? "SI" : "NO"]);
	}

	if (ManInforme_AddEditConservacion.frm.find("#hdfCodMTipo").val() == "0000011") {//Ecoturismo
		ManInforme_AddEditConservacion.frm.find(".dvDatosCons").hide();
	} else {
		ManInforme_AddEditConservacion.frm.find(".dvDatosEcot").hide();
	}

	//=====-----Para el registro de datos del formulario-----=====
	//Validación personalizada
	jQuery.validator.addMethod("invalidManInf_AddEditConservacion", function (value, element) {
		switch ($(element).attr('id')) {
			case 'ddlIndicadorId':
			case 'ddlOdId':
				return value === '0000000' ? false : true;
				break;
		}
	});
	ManInforme_AddEditConservacion.frm.validate(utilSigo.fnValidate({
		rules: {
			ddlIndicadorId: { invalidManInf_AddEditConservacion: true },
			ddlOdId: { invalidManInf_AddEditConservacion: true },
			txtNumInforme: { required: true },
			txtFechaInicio: { required: true },
			txtFechaFin: { required: true }
		},
		messages: {
			ddlIndicadorId: { invalidManInf_AddEditConservacion: "Seleccione el estado actual del registro" },
			ddlOdId: { invalidManInf_AddEditConservacion: "Seleccione la oficina desconcentrada" },
			txtNumInforme: { required: "Ingrese el número del informe de supervisión" },
			txtFechaInicio: { required: "Seleccione la fecha de inicio de la supervisión" },
			txtFechaFin: { required: "Seleccione la fecha fin de la supervisión" }
		},
		fnSubmit: function (form) {
			utilSigo.dialogConfirm('', 'Desea continuar con el registro?', function (r) {
				if (r) {
					ManInforme_AddEditConservacion.fnSaveForm();
				}
			});
		}
	}));
	//Validación de controles que usan Select2
	ManInforme_AddEditConservacion.frm.find("select.select2-hidden-accessible").on("change", function (e) {
		$(this).valid();
	});
	ManInforme_AddEditConservacion.Denuncia.objDeuncia.ENT_INFORME.COD_INFORME = $('#hdfCodInforme').val().trim();
	ManInforme_AddEditConservacion.Denuncia.obtenerDenuncia();
	ManInforme_AddEditConservacion.Incidencia.cargarIncidencias();
	ManInforme_AddEditConservacion.Incidencia.ui();
	ManInforme_AddEditConservacion.Incidencia.eventos();
});