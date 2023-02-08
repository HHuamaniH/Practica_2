using CapaEntidad.DOC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad.ViewModel
{
    public class VM_Resodirec
    {
        public string lblTituloCabecera { get; set; }
        public VM_ControlCalidad_2 vmControlCalidad { get; set; }

        public string hdfCodResodirec { get; set; }
        public string hdfCodFCTipo { get; set; }
        public string hdfCodPersona { get; set; }
        public string hdfCodProfesional { get; set; }
        public string hdfTipoDocumento { get; set; }

        public string hdfCodEnciso { get; set; }
        //variables de la view
        public string txtTipoFiscaliza { get; set; }
        public string txtNumeroResolucion { get; set; }
        public string txtApellidosNombres { get; set; }
        public string txtFechaEmision { get; set; }
        public string txtFechaAnulacion { get; set; }
        public string txtNumeroExpediente { get; set; }
        public bool chkSolAntecedente { get; set; }
        /// <summary>
        /// variables para medidas cautelares
        /// </summary>
        public bool chkMedCautelar { get; set; }
        public bool chkMedGTF { get; set; }
        public bool chkMedLisTrozas { get; set; }
        public bool chkMedPM { get; set; }
        public bool chkMedPOA { get; set; }
        public string txtDescMedidaCautelar { get; set; }

        public bool chkSolBalance { get; set; }
        public Int32 txtMulta { get; set; }
        public decimal txtMonto { get; set; }
        public bool chkCaducidad { get; set; }
        public bool chkMedCorrectivas { get; set; }
        public string txtDescMedCorrectivas { get; set; }
        public string hdfCodResodirecGravedad { get; set; }
        public bool chkCausalesCaducidad { get; set; }
        public bool chkDGFFS { get; set; }
        public string txtDescDGFFS { get; set; }
        public bool chkProgramaRegional { get; set; }
        public string txtDescProgramaRegional { get; set; }
        public bool chkMinPublico { get; set; }
        public string txtDescMinPublico { get; set; }
        public bool chkColegioIng { get; set; }
        public string txtDescColegioIng { get; set; }
        public bool chkATFFS { get; set; }
        public string txtDescATFFS { get; set; }
        public bool chkOCI { get; set; }
        public string txtDescOCI { get; set; }
        public bool chkOEFA { get; set; }
        public string txtDescOEFA { get; set; }
        public bool chkSUNAT { get; set; }
        public string txtDescSUNAT { get; set; }
        public bool chkSERFOR { get; set; }
        public string txtDescSERFOR { get; set; }
        public bool chkOTROS1 { get; set; }
        public string txtDescOTROS1 { get; set; }
        public bool chkMINEMMIN { get; set; }
        public string txtDescMINEMMIN { get; set; }
        public string txtDescripcion { get; set; }
        public string hdfCodResodirecPAUFinTipo { get; set; }

        public string txtExpedienteAdmAsig { get; set; }
        public bool chkEvidenciaIrregularidad { get; set; }
        public bool chkBuenManejo { get; set; }
        public bool chkSinInfraccion { get; set; }
        public bool chkDeficienteNotificacion { get; set; }
        public bool chkDeficienteTecnica { get; set; }
        public string txtOtrosArch { get; set; }

        public bool chkOtrosRectificacion { get; set; }
        public string txtDescOtrosRectificacion { get; set; }
        public bool chkNomTitular { get; set; }
        public string txtNomTitular { get; set; }
        public bool chkNumTitulo { get; set; }
        public string txtNumTitulo { get; set; }
        public bool chkNumExp { get; set; }
        public bool txtNumExp { get; set; }
        public bool chkFechaEmision { get; set; }
        public string txtDescFechaEmision { get; set; }
        public bool chkEspecies { get; set; }

        public bool chkImprocedente { get; set; }
        public bool chkFundada { get; set; }
        public bool chkFundadaParte { get; set; }
        public bool chkInFundada { get; set; }
        public bool chkInadmisible { get; set; }
        public bool chkLevantarCaducidad { get; set; }

        public bool chkMedImprocedente { get; set; }
        public bool chkMedFundada { get; set; }
        public bool chkMedFundadaParte { get; set; }
        public bool chkMedInfundada { get; set; }
        public bool chkLevantamientoMedCautelar { get; set; }
        public bool chkModMedCautelar { get; set; }
        public string txtDescMedCautelar2 { get; set; }
        public bool chkLevantarMedCaut { get; set; }
        public bool chkNoLevantarMedCaut { get; set; }
        public bool chkNoExisteAprovechamiento { get; set; }

        public string txtDescMandato { get; set; }
        public string txtDescOtros { get; set; }
        public bool chkMotampAmpl { get; set; }
        public bool chkMotampAmppotrinf { get; set; }
        public bool chkMotampAmpporpla { get; set; }
        public bool chkMotampOtros { get; set; }

        public bool chkInfFalsaInex { get; set; }
        public bool chkInfFalsaDif { get; set; }
        public bool chkInfFalsaDas { get; set; }
        public string txtDescInfFalsa { get; set; }
        public string hdfCodOdRegistro { get; set; }
        public bool chkCambioMulta { get; set; }
        public bool chkReconsCambioMulta { get; set; }
       // public decimal txtRectifMonto { get; set; }
        public decimal txtReconsMonto { get; set; }
        public bool chkPublicar { get; set; }
        public string hdfCodTitular { get; set; }
        public string txtTitular { get; set; }
        public string txtFechaCampo { get; set; }
        public bool chkPrimerQuinquenio { get; set; }
        public bool chkSegundoQuinquenio { get; set; }
        public bool chkTercerQuinquenio { get; set; }
        public bool chkCuartoQuinquenio { get; set; }
        public Int32 txtBloqQuinquenio { get; set; }
        public bool chkResDir { get; set; }
        public bool chkResSubDir { get; set; }
        public string txtBExtraccionFEmision { get; set; }
        public string txtUsuarioRegistro { get; set; }
        /// <summary>
        /// variables para rectificacion
        /// 
        /// </summary>
        public bool chkRectificacion { get; set; }
        public string txtDesRectificacion { get; set; }
        public bool chkMedCautXEspecie { get; set; }
        public bool chkMandatos { get; set; }
        public Int32 RegEstado { get; set; }
        public string txtObservacones { get; set; }

        public bool chkMedEspecie { get; set; }

        public List<CapaEntidad.DOC.Ent_RESODIREC> listInformes { get; set; }
        public List<CapaEntidad.DOC.Ent_RESODIREC> listInfracionReconsideracion { get; set; }

        public string txtTituloModal { get; set; }

        public string txtCodEspecie { get; set; }
        public string txtDescInfraacion { get; set; }
        public string txtNumIndv { get; set; }
        /// <summary>
        /// variables para mandatos
        /// </summary>
        public string txtDescripcionMandato { get; set; }
        public string txtDiasImpl { get; set; }
        public string txtMesesImpl { get; set; }
        public string txtDiasInf { get; set; }
        public string txtMeseInf { get; set; }
        public string txtAnioImpl { get; set; }
        public string txtAnioInf { get; set; }
        public string txtDiasPostImpl { get; set; }
        public string txtMesePostImpl { get; set; }
        public string txtAnioPostImpl { get; set; }
        ///para mandatos
        public Ent_RESODIREC_MEDIDA oMandato { get; set; }
        public List<Ent_RESODIREC_MEDIDA> ListMandato { get; set; }
        /// <summary>
        /// variables para medida correctiva
        /// </summary>
        public Ent_RESODIREC_MEDIDA oMedCorrectiva { get; set; }
        public List<Ent_RESODIREC_MEDIDA> ListMedCorrectiva { get; set; }
        public List<Ent_RESODIREC_MEDIDA_ESPECIE> ListEspecieMedCorrectiva { get; set; }

        public List<Ent_RESODIREC> ListPOA { get; set; }
        public List<Ent_RESODIREC> ListParcela { get; set; }

        public List<Ent_RESODIREC> ListRecomendacion { get; set; }
        public List<Ent_RESODIREC> ListPOAOBSERVATORIO { get; set; }
        public List<string> ListPOAChecked { get; set; }

        /// <summary>
        /// para las infracciones
        /// </summary>
        public string txtIdArticulo { get; set; }
        public string txtDescripcionArticulo { get; set; }
        public string txtIdEnciso { get; set; }
        public string txtDescEnciso { get; set; }
        public string txtIdPOA { get; set; }
        public string txtDescPOA { get; set; }
        public string txtAreaInfrac { get; set; }
        public string txtDescInfrac { get; set; }
        public string txtVolumenInf { get; set; }
        public string txtIdTipoAprov { get; set; }
        public List<Ent_RESODIREC> ListArticulo { get; set; }
        public List<Ent_RESODIREC> ListEspeciesMC { get; set; }

        public List<Ent_SBusqueda> ListIncisos { get; set; }
        public List<Ent_SBusqueda> ListTipo { get; set; }
        ///lista de infracciones
        public List<Ent_RESODIREC> ListarIniPAU { get; set; }
        /// <summary>
        /// variable para la busqueda
        /// </summary>
        public List<Ent_SBusqueda> sBusqueda { get; set; }

        /// sub listas de resoluciona
        /// para la lista de especies 
        public List<Ent_RESODIREC> listaEspeciesFloraCombo { get; set; }
        public List<Ent_RESODIREC> listaEspeciesFaunaCombo { get; set; }


        public List<Ent_RESODIREC> listEliTabla { get; set; }
        /// <summary>
        /// lista para eliminar especies medidas correctivas
        /// </summary>
        public List<Ent_RESODIREC> listEliTablaEMC { get; set; }
        public List<Ent_RESODIREC> listEliTablaInfracciones { get; set; }
        public List<Ent_RESODIREC> listEliTablaMandatos { get; set; }
        public List<Ent_RESODIREC> listEliTablaMedidasCorrectivas { get; set; }
        public List<Ent_RESODIREC> listEliTablaMotivo { get; set; }
        public List<Ent_RESODIREC> listEliTablEspeciesMC { get; set; }

        public List<Ent_RESODIREC> listComboGravedad { get; set; }
        public List<Ent_RESODIREC> listComboTipoArchivo { get; set; }
        ///termino de pau
        public string txtIdDetermina { get; set; }
        public bool chkCaducidadTH { get; set; }
        public bool chkSancionExTitular { get; set; }
        public bool chkSancionExTitular2 { get; set; }

        public string txtExtitular { get; set; }
        public string hdfCodExTitulat { get; set; }
        public bool chkAmonestacion { get; set; }
        public bool chkMulta { get; set; }
        public string txtMonMulta { get; set; }
        public bool chkDesc30 { get; set; }
        public string txtIdGravedad { get; set; }
        public bool chkGTFMP { get; set; }
        public bool chkMedLisTrozasMP { get; set; }
        public bool chkMedEspecieMP { get; set; }
        public bool chkNoev_Aprov { get; set; }
        public bool chkMCorrectivas { get; set; }
        //archivo
        public string txtIdTipoMotivoArch { get; set; }
        public string txtDescTipoMotivoArch { get; set; }
        public string txtDescArchivo { get; set; }
        public string txtIdSubTipoMotivoArch { get; set; }
        public string txtDescSubTipoMotivoArch { get; set; }
        public List<Ent_SBusqueda> ListSubTipoArchivo { get; set; }
        public List<Ent_RESODIREC> ListMotivoArchivo { get; set; }
        //reconsideracion
        public string txtMonMultaRecon { get; set; }
        //otros
        public string txtDescOtrosRD { get; set; }
        // rd archivo informe supervision
        public string txtNumExpeAsignado { get; set; }
        public bool chkeviirre { get; set; }
        public bool chkbueman { get; set; }
        public bool chkdefnot { get; set; }
        public bool chkdeftec { get; set; }
        public bool chksininf { get; set; }
        public string txtOtrosArchivo { get; set; }

        // rd ampliacion
        public bool chkmotamp_ampimp { get; set; }
        public bool chkmotamp_ampotrinf { get; set; }
        public bool chkmotamp_ampporpla { get; set; }
        public string txtmotamp_otros { get; set; }
        //RD Acumulacion
        public string txtDescAcumulacion { get; set; }
        // rd recomendaciones
        public string txtMedidaCaut { get; set; }
        public bool chklevmed { get; set; }
        public bool chklevParmed { get; set; }
        public bool chkNoLevmed { get; set; }
        public bool chkmodmed { get; set; }
        public string txtdesmed { get; set; }
        public string txtMotConservActoAdm { get; set; }
        public string txtAdecuMonto { get; set; }
        // rd rectificacion
        public bool chkErrorMaterial { get; set; }
        public bool chkNomTitError { get; set; }
        public bool chkNumTitError { get; set; }
        public string txtNumtitError { get; set; }
        public bool chkNumExpdError { get; set; }
        public string txtNumExpdError { get; set; }
        public bool chkFechaError { get; set; }
        public string txtFechaError { get; set; }
        public bool chkEspeciesError { get; set; }
        public bool chkRectifmonto { get; set; }
        public string txtRectifmonto { get; set; }
        public bool chkotrosrec { get; set; }
        public string txtotrosrec { get; set; }
        public string txtTituloInfraccion { get; set; }

        //23.08.2021 - CARR se agregan para acciones y medidas complementarias
        public bool chkAccion { get; set; }
        public bool chkAllanamiento { get; set; }
        public bool chkSubsanacion { get; set; }
        public bool chkMedidaCompl { get; set; }
        public bool chkDecomiso { get; set; }
        public bool chkPlanCierre { get; set; }
        public bool chkDisposicionFauna { get; set; }

        //07.09.2021
        public List<Ent_RESODIREC> ListSTD01 { get; set; }
        public List<Ent_RESODIREC> ListSTD02 { get; set; }

        public List<Ent_RESODIREC> ListEliTSTD01 { get; set; }
        public List<Ent_RESODIREC> ListEliTSTD02 { get; set; }

        //TGS 07.10.2022
        public bool chkTerceroSolidario { get; set; }
        public string hdfCodTerceroSolidario { get; set; }
        public string txtTerceroSolidario { get; set; }
        public bool chkSubsVoluntaria { get; set; }
        public string ddlArticuloId{ get; set; }
        public string txtArticulo { get; set; }
        public List<Ent_SBusqueda> listaArticulos { get; set; }
        public List<Ent_SBusqueda> listaIncisos { get; set; }
        public List<Ent_RESODIREC> listaInfracciones { get; set; }
        public List<Ent_RESODIREC> tbEliTABLAEnciso { get; set; }
    }
}
