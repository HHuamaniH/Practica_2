"use strict";
var ManRD_AddEdit = {};

//para iniciar los eventos
ManRD_AddEdit.iniciarEventos = function () {
	ManRD_AddEdit.frm.find("#txtFechaEmision").datepicker({ format: "dd/mm/yyyy", autoclose: true, language: 'es' });
	ManRD_AddEdit.frm.find("#txtFechaAnulacion").datepicker({ format: "dd/mm/yyyy", autoclose: true, language: 'es' });
	ManRD_AddEdit.frm.find("#txtFechaError").datepicker({ format: "dd/mm/yyyy", autoclose: true, language: 'es' });

	if (!ManRD_AddEdit.frm.find('#hdfCodResodirec').val()) {
		ManRD_AddEdit.frm.find('#ddlIndicadorId').val('0000001').trigger('change');
	}

    ManRD_AddEdit.tbEliTABLA = {};

    if (ManRD_AddEdit.frm.find("#hdfCodFCTipo").val() == "0000010") {
        ManRD_AddEdit.fnShowTerceroSolidario();
    } 

    ManRD_AddEdit.checkedResolucion();
}

ManRD_AddEdit.checkedResolucion = function () {  
    const chkResDir = ManRD_AddEdit.frm.find("#chkResDir");
    const chkResSubDir = ManRD_AddEdit.frm.find("#chkResSubDir");

    chkResDir.on('change', function () {
        chkResSubDir.prop("checked", false);
    });

    chkResSubDir.on('change', function () {
        chkResDir.prop("checked", false);
    });
}

//vuelve a la vista principal del listado
ManRD_AddEdit.regresar = function (appServer) {
	//var url = "";
	let chkResSubDir = ManRD_AddEdit.frm.find("#chkResSubDir").is(':checked');
	var url = window.location = `${urlLocalSigo}/Fiscalizacion/ManResolucion/Index?doc=${chkResSubDir ? 'rsd' : 'rd'}`;
	window.location = url;
	//window.history.back();
};

ManRD_AddEdit.fnBuscarPersona = function (_dom, _tipoPersona) {
	var url = urlLocalSigo + "General/Controles/_BuscarPersonaGeneral";
	var option = { url: url, type: 'GET', datos: { asBusGrupo: "PERSONA", asCodPTipo: "TODOS", asTipoPersona: _tipoPersona }, divId: "mdlBuscarPersona" };
	utilSigo.fnOpenModal(option, function () {
		_bPerGen.fnAsignarDatos = function (obj) {
			if (obj != null && obj != "") {
				var data = _bPerGen.dtBuscarPerona.row($(obj).parents('tr')).data();
				switch (_dom) {
					case "PROFESIONAL":
						ManRD_AddEdit.frm.find("#hdfCodPersona").val(data["COD_PERSONA"]);
						ManRD_AddEdit.frm.find("#txtApellidosNombres").val(data["PERSONA"]);
						ManRD_AddEdit.frm.find("#hdTipoProfesional").val(_tipoPersona);
						break;
					case "TITULAR":
						ManRD_AddEdit.frm.find("#hdfCodTitular").val(data["COD_PERSONA"]);
						ManRD_AddEdit.frm.find("#txtTitular").val(data["PERSONA"]);
						ManRD_AddEdit.frm.find("#hdTipoTitular").val(_tipoPersona);
						break;
					case "TITULARRDT":
						ManRD_AddEdit.frm.find("#hdfCodExTitulat").val(data["COD_PERSONA"]);
						ManRD_AddEdit.frm.find("#txtExtitular").val(data["PERSONA"]);
						ManRD_AddEdit.frm.find("#hdfTipoPersonaExTitular").val(_tipoPersona);
                        break;
                    case "TERCERO":
                        ManRD_AddEdit.frm.find("#hdfCodTerceroSolidario").val(data["COD_PERSONA"]);
                        ManRD_AddEdit.frm.find("#txtTerceroSolidario").val(data["PERSONA"]);
                        ManRD_AddEdit.frm.find("#hdTipoTercero").val(_tipoPersona);
                        break;
				}
				utilSigo.fnCloseModal("mdlBuscarPersona");
			}
		};
		_bPerGen.fnInit();
	});
};

ManRD_AddEdit.fnViewModalUbigeo = function () {
	var url = initSigo.urlControllerGeneral + "_Ubigeo";
	var option = { url: url, type: 'POST', datos: {}, divId: "mdlControles_Ubigeo" };
	utilSigo.fnOpenModal(option, function () {
		_Ubigeo.fnSelectUbigeo = function (_ubigeoText, _ubigeoId) {
			ManRD_AddEdit.frm.find("#hdfCodUbigeo").val(_ubigeoId);
			ManRD_AddEdit.frm.find("#txtUbigeo").val(_ubigeoText);
			$("#mdlControles_Ubigeo").modal('hide');
		}
		_Ubigeo.fnLoadModalView(ManRD_AddEdit.frm.find("#hdfCodUbigeo").val());
	}, function () {
		if (!utilSigo.fnValidateForm_HideControl(ManRD_AddEdit.frm, ManRD_AddEdit.frm.find("#hdfCodUbigeo"), ManRD_AddEdit.frm.find("#iconUbigeo"), false)) return false;
		return true;
	}
	);
}

ManRD_AddEdit.fnEstructura = function () {
	let hdfCodResodirec = ManRD_AddEdit.frm.find("#hdfCodResodirec").val();
	let hdfCodFCTipo = ManRD_AddEdit.frm.find("#hdfCodFCTipo").val();
	let hdfCodPersona = ManRD_AddEdit.frm.find("#hdfCodPersona").val();
	let RegEstado = ManRD_AddEdit.frm.find("#RegEstado").val();
	let txtObservacones = ManRD_AddEdit.frm.find("#txtObservacones").val();
	let txtApellidosNombres = ManRD_AddEdit.frm.find("#txtApellidosNombres").val();
	let txtNumeroResolucion = ManRD_AddEdit.frm.find("#txtNumeroResolucion").val();
	let txtFechaEmision = ManRD_AddEdit.frm.find("#txtFechaEmision").val();
	let txtFechaAnulacion = ManRD_AddEdit.frm.find("#txtFechaAnulacion").val();

	let chkPublicar = ManRD_AddEdit.frm.find("#chkPublicar").is(':checked');
	let chkResDir = ManRD_AddEdit.frm.find("#chkResDir").is(':checked');
	let chkResSubDir = ManRD_AddEdit.frm.find("#chkResSubDir").is(':checked');
	let hdfCodProfesional = ManRD_AddEdit.frm.find("#hdfCodProfesional").val();
	/// notificaciones
	let chkDGFFS = ManRD_AddEdit.frm.find("#chkDGFFS").is(':checked');
	let txtDescDGFFS = ManRD_AddEdit.frm.find("#txtDescDGFFS").val();
	let chkProgramaRegional = ManRD_AddEdit.frm.find("#chkProgramaRegional").is(':checked');
	let txtDescProgramaRegional = ManRD_AddEdit.frm.find("#txtDescProgramaRegional").val();
	let chkMinPublico = ManRD_AddEdit.frm.find("#chkMinPublico").is(':checked');
	let txtDescMinPublico = ManRD_AddEdit.frm.find("#txtDescMinPublico").val();
	let chkMINEMMIN = ManRD_AddEdit.frm.find("#chkMINEMMIN").is(':checked');
	let txtDescMINEMMIN = ManRD_AddEdit.frm.find("#txtDescMINEMMIN").val();
	let chkColegioIng = ManRD_AddEdit.frm.find("#chkColegioIng").is(':checked');
	let txtDescColegioIng = ManRD_AddEdit.frm.find("#txtDescColegioIng").val();
	let chkATFFS = ManRD_AddEdit.frm.find("#chkATFFS").is(':checked');
	let txtDescATFFS = ManRD_AddEdit.frm.find("#txtDescATFFS").val();
	let chkOCI = ManRD_AddEdit.frm.find("#chkOCI").is(':checked');
	let txtDescOCI = ManRD_AddEdit.frm.find("#txtDescOCI").val();
	let chkOEFA = ManRD_AddEdit.frm.find("#chkOEFA").is(':checked');
	let txtDescOEFA = ManRD_AddEdit.frm.find("#txtDescOEFA").val();
	let chkSUNAT = ManRD_AddEdit.frm.find("#chkSUNAT").is(':checked');
	let txtDescSUNAT = ManRD_AddEdit.frm.find("#txtDescSUNAT").val();
	let chkSERFOR = ManRD_AddEdit.frm.find("#chkSERFOR").is(':checked');
	let txtDescSERFOR = ManRD_AddEdit.frm.find("#txtDescSERFOR").val();
	let chkOTROS1 = ManRD_AddEdit.frm.find("#chkOTROS1").is(':checked');
	let txtDescOTROS1 = ManRD_AddEdit.frm.find("#txtDescOTROS1").val();

	///-- Inicio form Incio PAU
	let txtNumeroExpediente = ManRD_AddEdit.frm.find("#txtNumeroExpediente").val();
	let chkSolAntecedente = ManRD_AddEdit.frm.find("#chkSolAntecedente").is(':checked');
	// --> ex titular
	let chkSancionExTitular = ManRD_AddEdit.frm.find("#chkSancionExTitular").is(':checked');
	let txtTitular = ManRD_AddEdit.frm.find("#txtTitular").val();
	let hdfCodTitular = ManRD_AddEdit.frm.find("#hdfCodTitular").val();
	// --> Medidas cautelares 
	let chkMedCautelar = ManRD_AddEdit.frm.find("#chkMedCautelar").is(':checked');
	let chkMedGTF = ManRD_AddEdit.frm.find("#chkMedGTF").is(':checked');
	let chkMedLisTrozas = ManRD_AddEdit.frm.find("#chkMedLisTrozas").is(':checked');
	let chkMedPM = ManRD_AddEdit.frm.find("#chkMedPM").is(':checked');
	let chkMedPOA = ManRD_AddEdit.frm.find("#chkMedPOA").is(':checked');
	let chkMedEspecie = ManRD_AddEdit.frm.find("#chkMedEspecie").is(':checked');
	let txtDescMedidaCautelar = ManRD_AddEdit.frm.find("#txtDescMedidaCautelar").val();

	let chkSolBalance = ManRD_AddEdit.frm.find("#chkSolBalance").is(':checked');
	let chkCausalesCaducidad = ManRD_AddEdit.frm.find("#chkCausalesCaducidad").is(':checked');
	let chkInfFalsaInex = ManRD_AddEdit.frm.find("#chkInfFalsaInex").is(':checked');
	let chkInfFalsaDif = ManRD_AddEdit.frm.find("#chkInfFalsaDif").is(':checked');
	let chkInfFalsaDas = ManRD_AddEdit.frm.find("#chkInfFalsaDas").is(':checked');
	let txtDescInfFalsa = ManRD_AddEdit.frm.find("#txtDescInfFalsa").val();
	// --> Infracciones
	let txtBExtraccionFEmision = ManRD_AddEdit.frm.find("#txtBExtraccionFEmision").val();

    let chkNoExisteAprovechamiento = ManRD_AddEdit.frm.find("#chkNoExisteAprovechamiento").is(':checked');
    // --> Mandatos
    let chkMandatos = ManRD_AddEdit.frm.find("#chkMandatos").is(':checked');
    // Fin form Inicio PAU
    // RD Termino
    let txtIdDetermina = ManRD_AddEdit.frm.find("#ddDetermina").val();
    let chkCaducidadTH = ManRD_AddEdit.frm.find("#chkCaducidadTH").is(':checked');
    let chkSancionExTitular2 = ManRD_AddEdit.frm.find("#chkSancionExTitular2").is(':checked');
    let txtExtitular = ManRD_AddEdit.frm.find("#txtExtitular").val();
    let hdfCodExTitulat = ManRD_AddEdit.frm.find("#hdfCodExTitulat").val();
    let chkAmonestacion = ManRD_AddEdit.frm.find("#chkAmonestacion").is(':checked');
    let chkMulta = ManRD_AddEdit.frm.find("#chkMulta").is(':checked');
    let txtMonMulta = ManRD_AddEdit.frm.find("#txtMonMulta").val();
    let chkDesc30 = ManRD_AddEdit.frm.find("#chkDesc30").is(':checked');
    let txtIdGravedad = ManRD_AddEdit.frm.find("#ddlGravedad").val();
    let chkGTFMP = ManRD_AddEdit.frm.find("#chkGTFMP").is(':checked');
    let chkMedLisTrozasMP = ManRD_AddEdit.frm.find("#chkMedLisTrozasMP").is(':checked');
    let chkMedEspecieMP = ManRD_AddEdit.frm.find("#chkMedEspecieMP").is(':checked');
    let txtIdTipoMotivoArch = ManRD_AddEdit.frm.find("#txtIdTipoMotivoArch").val();
    let chkRectificacion = ManRD_AddEdit.frm.find("#chkRectificacion").is(':checked');
    let txtDesRectificacion = ManRD_AddEdit.frm.find("#txtDesRectificacion").val();
    let chkNoev_Aprov = ManRD_AddEdit.frm.find("#chkNoev_Aprov").is(':checked');
    let chkMCorrectivas = ManRD_AddEdit.frm.find("#chkMCorrectivas").is(':checked');
    //let chkSolBalance = ManRD_AddEdit.frm.find("#chkSolBalance").val();
    // Fin RD termino
    // rd de reconsideracion
    let chkInadmisible = ManRD_AddEdit.frm.find("#chkInadmisible").is(':checked');
    let chkImprocedente = ManRD_AddEdit.frm.find("#chkImprocedente").is(':checked');
    let chkFundada = ManRD_AddEdit.frm.find("#chkFundada").is(':checked');
    let chkFundadaParte = ManRD_AddEdit.frm.find("#chkFundadaParte").is(':checked');
    let chkInFundada = ManRD_AddEdit.frm.find("#chkInFundada").is(':checked');
    let chkLevantarCaducidad = ManRD_AddEdit.frm.find("#chkLevantarCaducidad").is(':checked');
    let chkCambioMulta = ManRD_AddEdit.frm.find("#chkCambioMulta").is(':checked');
    let txtMonMultaRecon = ManRD_AddEdit.frm.find("#txtMonMultaRecon").val();
    // fin rd reconsideracion
    //rd otros
    let txtDescOtrosRD = ManRD_AddEdit.frm.find("#txtDescOtrosRD").val();
    // rd archivo informe supervision
    let txtNumExpeAsignado = ManRD_AddEdit.frm.find("#txtNumExpeAsignado").val();
    let chkeviirre = ManRD_AddEdit.frm.find("#chkeviirre").is(':checked');
    let chkbueman = ManRD_AddEdit.frm.find("#chkbueman").is(':checked');
    let chkdefnot = ManRD_AddEdit.frm.find("#chkdefnot").is(':checked');
    let chkdeftec = ManRD_AddEdit.frm.find("#chkdeftec").is(':checked');
    let chksininf = ManRD_AddEdit.frm.find("#chksininf").is(':checked');
    let txtOtrosArchivo = ManRD_AddEdit.frm.find("#txtOtrosArchivo").val();
    // rd ampliacion de pau
    let chkmotamp_ampimp = ManRD_AddEdit.frm.find("#chkmotamp_ampimp").is(':checked');
    let chkmotamp_ampotrinf = ManRD_AddEdit.frm.find("#chkmotamp_ampotrinf").is(':checked');
    let chkmotamp_ampporpla = ManRD_AddEdit.frm.find("#chkmotamp_ampporpla").is(':checked');
    let txtmotamp_otros = ManRD_AddEdit.frm.find("#txtmotamp_otros").val();
    // rd acumulacion
    let txtDescAcumulacion = ManRD_AddEdit.frm.find("#txtDescAcumulacion").val();
    // rd variacion de medidas correctivas
    let txtMedidaCaut = ManRD_AddEdit.frm.find("#txtMedidaCaut").val();
    let chklevmed = ManRD_AddEdit.frm.find("#chklevmed").is(':checked');
    let chklevParmed = ManRD_AddEdit.frm.find("#chklevParmed").is(':checked');
    let chkNoLevmed = ManRD_AddEdit.frm.find("#chkNoLevmed").is(':checked');
    let chkmodmed = ManRD_AddEdit.frm.find("#chkmodmed").is(':checked');
    let txtdesmed = ManRD_AddEdit.frm.find("#txtdesmed").val();
    let txtMotConservActoAdm = ManRD_AddEdit.frm.find("#txtMotConservActoAdm").val();
    let txtAdecuMonto = ManRD_AddEdit.frm.find("#txtAdecuMonto").val();
    //rectificacion
    let chkErrorMaterial = ManRD_AddEdit.frm.find("#chkErrorMaterial").is(':checked');
    let chkNomTitError = ManRD_AddEdit.frm.find("#chkNomTitError").is(':checked');
    let chkNumTitError = ManRD_AddEdit.frm.find("#chkNumTitError").is(':checked');
    let txtNumtitError = ManRD_AddEdit.frm.find("#txtNumtitError").val();
    let chkNumExpdError = ManRD_AddEdit.frm.find("#chkNumExpdError").is(':checked');
    let txtNumExpdError = ManRD_AddEdit.frm.find("#txtNumExpdError").val();
    let chkFechaError = ManRD_AddEdit.frm.find("#chkFechaError").is(':checked');
    let txtFechaError = ManRD_AddEdit.frm.find("#txtFechaError").val();
    let chkEspeciesError = ManRD_AddEdit.frm.find("#chkEspeciesError").is(':checked');
    let chkRectifmonto = ManRD_AddEdit.frm.find("#chkRectifmonto").is(':checked');
    let txtRectifmonto = ManRD_AddEdit.frm.find("#txtRectifmonto").val();
    let chkotrosrec = ManRD_AddEdit.frm.find("#chkotrosrec").is(':checked');
    let txtotrosrec = ManRD_AddEdit.frm.find("#txtotrosrec").val();
    //se agrega los chk de acciones y medidas complementarias
    let chkAccion = ManRD_AddEdit.frm.find("#chkAccion").is(':checked');
    let chkAllanamiento = ManRD_AddEdit.frm.find("#chkAllanamiento").is(':checked');
    let chkSubsanacion = ManRD_AddEdit.frm.find("#chkSubsanacion").is(':checked');
    let chkMedidaCompl = ManRD_AddEdit.frm.find("#chkMedidaCompl").is(':checked');
    let chkDecomiso = ManRD_AddEdit.frm.find("#chkDecomiso").is(':checked');
    let chkPlanCierre = ManRD_AddEdit.frm.find("#chkPlanCierre").is(':checked');
    let chkDisposicionFauna = ManRD_AddEdit.frm.find("#chkDisposicionFauna").is(':checked');
    let chkParalizacion = ManRD_AddEdit.frm.find("#chkParalizacion").is(':checked');
    let chkClausuraTemporal = ManRD_AddEdit.frm.find("#chkClausuraTemporal").is(':checked');
    let chkClausuraDefinitiva = ManRD_AddEdit.frm.find("#chkClausuraDefinitiva").is(':checked');
    let chkInhabilitacionTemporal = ManRD_AddEdit.frm.find("#chkInhabilitacionTemporal").is(':checked');
    let chkInhabilitacionDefinitiva = ManRD_AddEdit.frm.find("#chkInhabilitacionDefinitiva").is(':checked');
    let chkInmovilizacion = ManRD_AddEdit.frm.find("#chkInmovilizacion").is(':checked');

    let modelRD = {
        hdfCodResodirec,
        hdfCodFCTipo,
        hdfCodPersona,
        RegEstado,
        txtObservacones,
        txtApellidosNombres,
        txtNumeroResolucion,
        hdfCodProfesional,
        txtFechaEmision,
        chkPublicar,
        chkResDir,
        chkResSubDir,
        txtNumeroExpediente,
        chkSolAntecedente,
        chkSancionExTitular,
        txtTitular,
        hdfCodTitular,
        chkMedCautelar,
        chkMedGTF,
        chkMedLisTrozas,
        chkMedPM,
        chkMedPOA,
        chkMedEspecie,
        txtDescMedidaCautelar, txtFechaAnulacion,
        chkSolBalance,
        chkCausalesCaducidad,
        chkInfFalsaInex,
        chkInfFalsaDif,
        chkInfFalsaDas,
        txtDescInfFalsa,
        txtBExtraccionFEmision,
        chkNoExisteAprovechamiento,
        chkDGFFS,
        txtDescDGFFS,
        chkProgramaRegional,
        txtDescProgramaRegional,
        chkMinPublico,
        txtDescMinPublico,
        chkMINEMMIN,
        txtDescMINEMMIN,
        chkColegioIng,
        txtDescColegioIng,
        chkATFFS, txtDescATFFS,
        chkOCI,
        txtDescOCI,
        chkOEFA,
        txtDescOEFA,
        chkSUNAT,
        txtDescSUNAT,
        chkSERFOR,
        txtDescSERFOR,
        chkOTROS1,
        txtDescOTROS1,
        chkMandatos,
        txtIdDetermina,
        chkCaducidadTH,
        chkSancionExTitular2,
        txtExtitular,
        hdfCodExTitulat,
        chkAmonestacion,
        chkMulta,
        txtMonMulta,
        chkDesc30,
        txtIdGravedad,
        chkGTFMP,
        chkMedLisTrozasMP,
        chkMedEspecieMP,
        txtIdTipoMotivoArch,
        chkRectificacion,
        txtDesRectificacion,
        chkNoev_Aprov,
        chkMCorrectivas,
        chkInadmisible,
        chkImprocedente,
        chkFundada,
        chkFundadaParte,
        chkInFundada,
        chkLevantarCaducidad,
        chkCambioMulta,
        txtMonMultaRecon,
        txtDescOtrosRD,
        txtNumExpeAsignado,
        chkeviirre,
        chkbueman,
        chkdefnot,
        chkdeftec,
        chksininf,
        txtOtrosArchivo,
        chkmotamp_ampimp,
        chkmotamp_ampotrinf,
        chkmotamp_ampporpla,
        txtmotamp_otros,
        txtDescAcumulacion,
        txtMedidaCaut,
        chklevmed,
        chklevParmed,
        chkNoLevmed,
        chkmodmed,
        txtdesmed,
        txtMotConservActoAdm,
        txtAdecuMonto,
        chkErrorMaterial,
        chkNomTitError,
        chkNumTitError,
        txtNumtitError,
        chkNumExpdError,
        txtNumExpdError,
        chkFechaError,
        txtFechaError,
        chkEspeciesError,
        chkRectifmonto,
        txtRectifmonto,
        chkotrosrec,
        txtotrosrec,
        chkAccion,
        chkAllanamiento,
        chkSubsanacion,
        chkMedidaCompl,
        chkDecomiso,
        chkPlanCierre,
        chkDisposicionFauna,
        chkParalizacion,
        chkClausuraTemporal,
        chkClausuraDefinitiva,
        chkInhabilitacionTemporal,
        chkInhabilitacionDefinitiva,
        chkInmovilizacion
    }
    ///control de calidad
    modelRD.vmControlCalidad = _ControlCalidad.fnGetDatosControlCalidad();
    /// Listas
    modelRD.listInformes = _renderListExpediente.fnGetList();

    if (hdfCodFCTipo == '0000008') {
        // --> lista de infracciones
        modelRD.chkSubsVoluntaria = ManRD_AddEdit.frm.find("#chkSubsVoluntaria").is(':checked');
        modelRD.listaInfracciones = _renderArchivoInfSup.fnGetList();
        modelRD.tbEliTABLAEnciso = _renderArchivoInfSup.fnGetListEliTABLA();
    }
	if (hdfCodFCTipo == '0000009') {
		// --> lista de mandatos 
		modelRD.ListMandato = _renderMandato.fnGetList();
		modelRD.listEliTablaMandatos = _renderMandato.tbEliTABLA;
		///--> listas de especies
		modelRD.ListEspeciesMC = _renderListaEspeciesMC.fnGetList();
		modelRD.listEliTablaEMC = _renderListaEspeciesMC.tbEliTABLA;
		// --> lista de infracciones
		modelRD.ListarIniPAU = _renderInfracciones.fnGetList();
		// modelRD.listEliTablaEMC = _renderListaEspeciesMC.tbEliTABLA;
        modelRD.listEliTablaInfracciones = _renderInfracciones.tbEliTABLA;

        //lista de expedientes de tramite documentario 20/09/2022 TGS
        modelRD.listSTD01 = _renderInicioPau.fnGetListAllanamiento();
        modelRD.listSTD02 = _renderInicioPau.fnGetListSubsanacion();
        modelRD.listEliTSTD01 = _renderInicioPau.tbEliTABLA;
        modelRD.hdfCodTerceroSolidario = ManRD_AddEdit.frm.find("#hdfCodTerceroSolidario").val();
        modelRD.txtTerceroSolidario = ManRD_AddEdit.frm.find("#txtTerceroSolidario").val();
        modelRD.listaInfracciones = _renderInicioPau.fnGetListInfraccion();
        modelRD.tbEliTABLAEnciso = _renderInicioPau.tbEliTABLAInfraccion;
	}
	if (hdfCodFCTipo == '0000010') {
		///--> listas de especies
		modelRD.ListEspeciesMC = _renderListaEspeciesMC.fnGetList();
		modelRD.listEliTablaEMC = _renderListaEspeciesMC.tbEliTABLA;
		modelRD.ListarIniPAU = _renderInfracciones.fnGetList();
        modelRD.listEliTablaInfracciones = _renderInfracciones.tbEliTABLA;

        //21.09.2022 TGS
        modelRD.chkTerceroSolidario = ManRD_AddEdit.frm.find("#chkTerceroSolidario").is(':checked');
        modelRD.hdfCodTerceroSolidario = ManRD_AddEdit.frm.find("#hdfCodTerceroSolidario").val();
        modelRD.txtTerceroSolidario = ManRD_AddEdit.frm.find("#txtTerceroSolidario").val();
	}
	if (hdfCodFCTipo == '0000011') {
		modelRD.ListMedCorrectiva = _renderMedCorrect.fnGetList();
		modelRD.listEliTablaMedidasCorrectivas = _renderMedCorrect.tbEliTABLA;
		modelRD.ListEspeciesMC = _renderListaEspeciesMP.fnGetList();
		modelRD.listEliTablaEMC = _renderListaEspeciesMP.tbEliTABLA;
		// --> lista de infracciones
		modelRD.ListarIniPAU = _renderInfracciones.fnGetList();
		// modelRD.listEliTablaEMC = _renderListaEspeciesMC.tbEliTABLA;
		modelRD.listEliTablaInfracciones = _renderInfracciones.tbEliTABLA;
		//motivo de archivo
		if (txtIdDetermina == '0000002') {
			modelRD.ListMotivoArchivo = _renderListaArchivoDetalle.fnGetList();
			modelRD.listEliTablaMotivo = _renderListaArchivoDetalle.tbEliTABLA;
		}

        modelRD.ListEspecieMedCorrectiva = _renderListaEspecies.fnGetList();
        modelRD.listEliTablEspeciesMC = _renderListaEspecies.tbEliTABLA;

        //lista de expedientes de tramite documentario 08/09/2021 CARR
        modelRD.listSTD01 = _renderTerminoPau.fnGetList01();
       
        modelRD.listSTD02 = _renderTerminoPau.fnGetList02();
        modelRD.listEliTSTD01 = _renderTerminoPau.tbEliTABLA;

        //21.09.2022 TGS
        modelRD.hdfCodTerceroSolidario = ManRD_AddEdit.frm.find("#hdfCodTerceroSolidario").val();
        modelRD.txtTerceroSolidario = ManRD_AddEdit.frm.find("#txtTerceroSolidario").val();
        modelRD.listaInfracciones = _renderTerminoPau.fnGetListInfraccion();
        modelRD.tbEliTABLAEnciso = _renderTerminoPau.tbEliTABLAInfraccion;
    }
    if (hdfCodFCTipo == '0000105') {
        // --> lista de infracciones
        modelRD.ListarIniPAU = _renderInfracciones.fnGetList();
        modelRD.listEliTablaInfracciones = _renderInfracciones.tbEliTABLA;
    }
    if (hdfCodFCTipo == '0000111') {
        ///--> listas de especies
        modelRD.ListEspeciesMC = _renderListaEspeciesMC.fnGetList();
        modelRD.listEliTablaEMC = _renderListaEspeciesMC.tbEliTABLA;
    }
    if (hdfCodFCTipo == '0000014') {
        // --> lista de infracciones
        modelRD.listInfracionReconsideracion = _renderInfraccionesRecon.fnGetList();
        modelRD.listEliTablaInfracciones = _renderInfraccionesRecon.tbEliTABLA;

        //lista de expedientes de tramite documentario 20/09/2022 TGS
        modelRD.listSTD02 = _renderReconsideracion.fnGetListSubsanacion();
        modelRD.listEliTSTD01 = _renderReconsideracion.tbEliTABLA;
        modelRD.listaInfracciones = _renderReconsideracion.fnGetListInfraccion();
        modelRD.tbEliTABLAEnciso = _renderReconsideracion.tbEliTABLAInfraccion;
    }
    // eliminar tabla
    modelRD.listEliTabla = _renderListExpediente.tbEliTABLA;
    //idlPOAObservatorio
    var listPObservatorio = [];
    $("[id*=idlPOAObservatorio] input:checked").each(function () {
        listPObservatorio.push($(this).attr('value'));
    });
    modelRD.ListPOAChecked = listPObservatorio;

	return modelRD;
}

ManRD_AddEdit.fnSaveForm = function () {
    if (ManRD_AddEdit.frm.find("#hdfCodFCTipo").val() == "0000008" && ManRD_AddEdit.frm.find("#chkSubsVoluntaria").is(':checked')) {
        if (_renderArchivoInfSup.fnGetList().length == 0) {
            utilSigo.toastError("Error", "Ingrese al menos una infracción subsanada");
            return false;
        }
    }

    if (ManRD_AddEdit.frm.find("#hdfCodFCTipo").val() == "0000010" && ManRD_AddEdit.frm.find("#chkTerceroSolidario").is(':checked')) {
        if (!utilSigo.ValidaTexto("hdfCodTerceroSolidario", "Ingrese un tercero solidario")) return false;
    }

	let modelRD = ManRD_AddEdit.fnEstructura();

	utilSigo.dialogConfirm("", "Está seguro registrar los datos?", function (r) {
		if (r) {
			let url = urlLocalSigo + "Fiscalizacion/ManResolucion/AddEditRD";
			let option = { url: url, datos: JSON.stringify(modelRD), type: 'POST' };
			utilSigo.fnAjax(option, function (data) {
				if (data.success) {
					console.log(data);
					var codigo = data.values[0]?.split('|')[0];
					window.location.href = `${window.location.href.split('?')[0]}?asCodRD=${codigo}`;
					//ManRD_AddEdit.frm.find("#hdfCodResodirec").val(codigo);
					//ManRD_AddEdit.frm.find("#RegEstado").val(0); //Modificar

					//window.location = `${urlLocalSigo}/Fiscalizacion/ManResolucion/Index?doc=${modelRD.chkResSubDir ? 'rsd' : 'rd'}`;
					utilSigo.toastSuccess("Éxito", "Datos actualizados correctamente");
				}
				else {
					utilSigo.toastWarning("Aviso", data.msj);
				}
			});
		}
	});
}

ManRD_AddEdit.fnSimular_old = function () {
	var listPoaS = [];
	let codigo = ManRD_AddEdit.frm.find("#hdfCodResodirec").val();
	let tipo = ManRD_AddEdit.frm.find("#hdfTipoDocumento").val();
	$("[id*=idlPOASimular] input:checked").each(function () {
		listPoaS.push($(this).attr('value'));
	});
	if (listPoaS.length > 0) {
		let url = `${urlLocalSigo}/Fiscalizacion/ManResolucion/simularObservatorio` + "?listPoa=" + listPoaS + "&codigo=" + codigo + "&tipo=" + tipo;

		window.open(url, "_blank");

	}
	else {
		utilSigo.toastWarning("Aviso", 'Seleccione el POA a simular');
	}
}

ManRD_AddEdit.fnSimular = function () {
    var listPoaS = [];
    let codigo = ManRD_AddEdit.frm.find("#hdfCodResodirec").val();
    let tipo = ManRD_AddEdit.frm.find("#hdfTipoDocumento").val();
    $("[id*=idlPOASimular] input:checked").each(function () {
        listPoaS.push($(this).attr('value'));
    });
    if (listPoaS.length > 0) {
        $.ajax({
            url: urlLocalSigo + "Fiscalizacion/ManResolucion/simularObservatorio",
            type: 'POST',
            datatype: "json",
            //contentType: "application/json; charset=utf-8",
            traditional: true,
            data: { 'listPoa': listPoaS, 'codigo': codigo, 'tipo': tipo },
            success: function (data) {
                if (data.fileName != "") {
                    let url1 = urlLocalSigo + "Fiscalizacion/ManResolucion/Download/?file=" + data.fileName;
                    window.open(url1, "_blank");
                }
                else {
                    utilSigo.toastWarning("Aviso", data.errorMessage);
                }
            },
            error: function (xhr, status, error) {
                alert("Error!" + xhr.status);
            },
        });
    }
    else {
        utilSigo.toastWarning("Aviso", 'Seleccione el POA a simular');
    }
}

ManRD_AddEdit.fnGenerarNumeracion = function () {
   
    let model = {};
    var codigoRD = ManRD_AddEdit.frm.find("#hdfCodResodirec").val();
    model = _renderListExpediente.fnGetList();
    let numExp = ManRD_AddEdit.frm.find("#txtNumeroExpediente").val();
    let url = urlLocalSigo + "Fiscalizacion/ManResolucion/generarNumeracion";
    let option = { url: url, datos: JSON.stringify(model), type: 'POST' };
    
    if (codigoRD != "") {
        if (model.length > 0) {
            if (numExp.trim() == "") {
                utilSigo.dialogConfirm("", "Está seguro de generar el número de expediente?", function (r) {
                    if (r) {
                        utilSigo.fnAjax(option, function (data) {
                            if (data.success) {
                                ManRD_AddEdit.frm.find("#txtNumeroExpediente").val(data.fileName);
                                utilSigo.toastSuccess("Éxito", "Datos actualizados correctamente");
                            }
                            else {
                                utilSigo.toastWarning("Aviso", "error pruebas" + data.fileName);
                            }
                        });
                    }
                });
            }
            else {
                utilSigo.dialogConfirm("", "Ya cuenta con un número de expediente asignado, Está seguro de generar nuevo número de expediente?", function (r) {
                    if (r) {
                        utilSigo.fnAjax(option, function (data) {
                            if (data.success) {
                                ManRD_AddEdit.frm.find("#txtNumeroExpediente").val(data.fileName);
                                utilSigo.toastSuccess("Éxito", "Datos actualizados correctamente");
                            }
                            else {
                                utilSigo.toastWarning("Aviso", "error pruebas" + data.fileName);
                            }
                        });
                    }
                });
            }
        }
        else {
            utilSigo.toastWarning("Aviso", 'seleccione un informe de supervision');
        }
    }
    else {
        utilSigo.toastWarning("Aviso", 'debe registrar primero la resolución');
    }

}

ManRD_AddEdit.fnGenerarNumeracionArchivo = function () {

    let model = {};
    var codigoRD = ManRD_AddEdit.frm.find("#hdfCodResodirec").val();
    model = _renderListExpediente.fnGetList();
    let numExp = ManRD_AddEdit.frm.find("#txtNumExpeAsignado").val();
    let url = urlLocalSigo + "Fiscalizacion/ManResolucion/generarNumeracion";
    let option = { url: url, datos: JSON.stringify(model), type: 'POST' };

    if (codigoRD != "") {
        if (model.length > 0) {
            if (numExp.trim() == "") {
                utilSigo.dialogConfirm("", "Está seguro de generar el número de expediente?", function (r) {
                    if (r) {
                        utilSigo.fnAjax(option, function (data) {
                            if (data.success) {
                                ManRD_AddEdit.frm.find("#txtNumExpeAsignado").val(data.fileName);
                                utilSigo.toastSuccess("Éxito", "Datos actualizados correctamente");
                            }
                            else {
                                utilSigo.toastWarning("Aviso", "error pruebas" + data.fileName);
                            }
                        });
                    }
                });
            }
            else {
                utilSigo.dialogConfirm("", "Ya cuenta con un número de expediente asignado, Está seguro de generar nuevo número de expediente?", function (r) {
                    if (r) {
                        utilSigo.fnAjax(option, function (data) {
                            if (data.success) {
                                ManRD_AddEdit.frm.find("#txtNumExpeAsignado").val(data.fileName);
                                utilSigo.toastSuccess("Éxito", "Datos actualizados correctamente");
                            }
                            else {
                                utilSigo.toastWarning("Aviso", "error pruebas" + data.fileName);
                            }
                        });
                    }
                });
            }
        }
        else {
            utilSigo.toastWarning("Aviso", 'seleccione un informe de supervision');
        }
    }
    else {
        utilSigo.toastWarning("Aviso", 'debe registrar primero la resolución');
    }

}

ManRD_AddEdit.fnShowTerceroSolidario = function () {
    if (ManRD_AddEdit.frm.find("#chkTerceroSolidario").is(':checked')) {
        ManRD_AddEdit.frm.find("#divTerceroSolidario").show();
    }
    else {
        ManRD_AddEdit.frm.find("#divTerceroSolidario").hide();
        ManRD_AddEdit.frm.find("#hdfCodTerceroSolidario").val(null);
        ManRD_AddEdit.frm.find("#txtTerceroSolidario").val(null);
        ManRD_AddEdit.frm.find("#hdTipoTercero").val(null);
    }
}

$(document).ready(function () {
	ManRD_AddEdit.frm = $("#frmAddOrEditRD");
	ManRD_AddEdit.iniciarEventos();

});