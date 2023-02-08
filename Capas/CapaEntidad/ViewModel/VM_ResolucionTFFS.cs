using CapaEntidad.DOC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad.ViewModel
{
    public class VM_ResolucionTFFS
    {
        public string lblTituloCabecera { get; set; }//
        public VM_ControlCalidad_2 vmControlCalidad { get; set; }

        public string hdfCodTFFS { get; set; }
        public string hdfCodEnciso { get; set; }
        public string hdfTramite { get; set; }//
        public string hdfCodFCTipo { get; set; }
        public string hdfCodPersona { get; set; }
        public string hdfCodProfesional { get; set; }
        public string hdfTipoDocumento { get; set; }        
        public string hdcodigo { get; set; }
        public string hdfTabsId01 { get; set; }
        public string hdfManRegEstado { get; set; }
        public string txtnomArchOriginal { get; set; }
        public string txtnomArchTemporal { get; set; }
        public string txtextArch { get; set; }
        public string txtestadoArch { get; set; }
        public string txtcCodificacionSiTD { get; set; }
        public int RegEstado { get; set; }
        public string hdfCodTitular { get; set; }
        public string hdfCodExTitulat { get; set; }

        /// --------------------- RESOLUCION TFFS --------------------------
        public string ddlItemIndicador { get; set; } //*
        public string lblUsuarioRegistro { get; set; }
        public string lblUsuarioControl { get; set; }
        public bool chkPublicar { get; set; }        
        public string radGrupoRevocar { get; set; }
        public string radNulidad { get; set; }
        public string radGrupoRevocarParte { get; set; }
        public string radGrupoRevocar2 { get; set; }
        public string radNulidad2 { get; set; }
        public string radRetrotraer { get; set; }
        public string radRetrotraer2 { get; set; }
        public string radGrupoRevocarParte2 { get; set; }
        public string lbldocumento { get; set; }
        public IEnumerable<VM_Cbo> ddlTipoResolucion { get; set; } //*
        public string ddlTipoResolucionId { get; set; }
        public IEnumerable<VM_Cbo> ddlResApelacion { get; set; } //*
        public string ddlResApelacionId { get; set; }
        public string txtQueja { get; set; }
        public IEnumerable<VM_Cbo> ddlResOtros { get; set; } //*
        public string ddlResOtrosId { get; set; }
        public string txtOtrosDes { get; set; }
        public IEnumerable<VM_Cbo> ddlResTFFSDFFS { get; set; } //*
        public string ddlResTFFSDFFSId { get; set; }
        public string txtItemNumero1 { get; set; }
        public string txtItemNumero2 { get; set; }

        public string TextBox4 { get; set; }
        public string txtItemfecemi { get; set; }
        public IEnumerable<VM_Cbo> ddlUbigeoDepartamento { get; set; } //*
        public string ddlUbigeoDepartamentoId { get; set; }
        public string lblItemPersonaFirma { get; set; }
        public string hdfItemPersonaFirma { get; set; }
        public string txtItemCargoPersonaFirma { get; set; }
        public string lblTituloPersonasFirma { get; set; }
        public IEnumerable<VM_Cbo> ddlSentidoRes { get; set; } //*
        public string ddlSentidoResId { get; set; }
        public bool chkConfirmar { get; set; }
        public bool chkRevocar { get; set; }
        public bool chkRevocarParte { get; set; }
        public IEnumerable<VM_Cbo> ddlRetrotraer { get; set; } //*
        public string ddlRetrotraerId { get; set; }
        public bool chkRetrotraer { get; set; }
        public bool chkPrescribir { get; set; }
        public bool chkArchivar { get; set; }
        public bool chkSuspension { get; set; }
        public bool chkNulidad { get; set; }
        public bool chkLevantar { get; set; }
        public bool chkCarece { get; set; }
        public bool chkDesestimiento { get; set; }
        public bool chkOtro { get; set; }
        public bool chkConfirmar2 { get; set; }
        public bool chkRevocar2 { get; set; }
        public bool chkRevocarParte2 { get; set; }
        public bool chkRetrotraer2 { get; set; }
        public bool chkPrescribir2 { get; set; }
        public bool chkArchivar2 { get; set; }
        public bool chkSuspension2 { get; set; }
        public bool chkNulidad2 { get; set; }
        public bool chkLevantar2 { get; set; }
        public bool chkCarece2 { get; set; }
        public bool chkDesestimiento2 { get; set; }
        public bool chkOtro2 { get; set; }
        public string txtDetermina { get; set; }
        public IEnumerable<VM_Cbo> ddlImprocedente { get; set; } //*
        public string ddlImprocedenteId { get; set; }
        public string txtConfirmar { get; set; }
        public string txtDetermina2 { get; set; }
        public string txtDetermina3 { get; set; }
        public IEnumerable<VM_Cbo> ddlInadmisible { get; set; } //*
        public string ddlInadmisibleId { get; set; }
        public IEnumerable<VM_Cbo> ddlNulidad { get; set; } //*
        public string ddlNulidadId { get; set; }
        public string ddlNulidad_Id { get; set; }
        public string txtRetrotraer { get; set; }
        public string txtcajaretro { get; set; }
        public bool chkDescripcion { get; set; }
        public bool chkDescripcionImprocedente { get; set; }
        public bool chkDescripcionInadmisible { get; set; }
        public bool chkDescripcionInfundado { get; set; }
        public bool chkDescripcionFundado { get; set; }
        public bool chkDescripcionFParte { get; set; }
        public bool chkDescripcionRetrotraer { get; set; }
        public bool chkDescripcionSuspension { get; set; } //chkDescripcionOtro
        public bool chkDescripcionCumplimiento { get; set; }
        public bool chkDescripcionDesestimiento { get; set; }
        public string txtDescripcion { get; set; }
        public string txtDescripcionMJ { get; set; }
        public string txtDescripcionImprocedente { get; set; }
        public string txtDescripcionInadmisible { get; set; }
        public string txtDescripcionInfundado { get; set; }
        public string txtDescripcionFundado { get; set; }
        public string txtDescripcionFParte { get; set; }
        public string txtDescripcionRetrotraer { get; set; }
        public string txtDescripcionSuspension { get; set; } //txtDescripcionOtro
        public string txtDescripcionCumplimiento { get; set; }
        public string txtDescripcionDesestimiento { get; set; }
        public string txtDescripcionSentido { get; set; }
        public IEnumerable<VM_Cbo> ddlDetermina_Motivo { get; set; }
        public string ddlDetermina_MotivoId { get; set; }
        public string txtDetermina_DesMotivo { get; set; }
        public bool chkDetermina_CambioMulta { get; set; }
        public string txtDetermina_Multa { get; set; }
        public bool chkDetermina_Caducidad { get; set; }
        public bool chkDetermina_MedidaCorrectiva { get; set; }
        public string txtDetermina_MedidaCorrectiva { get; set; }
        public IEnumerable<VM_Cbo> ddlConfirmaResol { get; set; } //*
        public string ddlConfirmaResolId { get; set; }
        public bool chkNoCambioMulta { get; set; }
        public bool chkSiCambioMulta { get; set; }
        public IEnumerable<VM_Cbo> ddlConfirmaResol_EstDeterminaCaducidad { get; set; } //*
        public string ddlConfirmaResol_EstDeterminaCaducidadId { get; set; }
        public IEnumerable<VM_Cbo> ddlConfirmaResol_EstDeterminaMulta { get; set; } //*
        public string ddlConfirmaResol_EstDeterminaMultaId { get; set; }
        public IEnumerable<VM_Cbo> ddlConfirmaResol_EstDeterminaMCorrectiva { get; set; } //*
        public string ddlConfirmaResol_EstDeterminaMCorrectivaId { get; set; }
        public bool lstChkProveidoGenerar { get; set; }
        public bool lstChkProveidoGenerar2 { get; set; }
        public bool lstChkProveidoGenerar3 { get; set; }
        public IEnumerable<VM_Cbo> ddlEstadoPAU { get; set; } //*
        public string ddlEstadoPAUId { get; set; } //*
        public string txtAdjuntar { get; set; }
        public string txtMuestraRes { get; set; }
        public string txtResTFFS { get; set; }
        public string txtARFFS { get; set; }
        public bool chkCambiaEstEspecieISuperv { get; set; }
        public string txtItemObservacion { get; set; }
        public bool chkTitular { get; set; }
        public string txtTitular { get; set; }
        public bool chkResponsable { get; set; }
        public string txtResponsable { get; set; }
        public bool chkRegente { get; set; }
        public string txtRegente { get; set; }
        public bool chkARFFS { get; set; }
        public string txtARFFS2 { get; set; }
        public bool chkATFFS { get; set; }
        public string txtATFFS { get; set; }
        public bool chkMinPublico { get; set; }
        public string txtMinPublico { get; set; }
        public bool chkMinEnergia { get; set; }
        public string txtMinEnergia { get; set; }
        public bool chkColeInge { get; set; }
        public string txtColeInge { get; set; }
        public bool chkOCI { get; set; }
        public string txtOCI { get; set; }
        public bool chkOEFA { get; set; }
        public string txtOEFA { get; set; }
        public bool chkSUNAT { get; set; }
        public string txtSUNAT { get; set; }
        public bool chkSERFOR { get; set; }
        public string txtSERFOR { get; set; }
        public bool chkOtros { get; set; }
        public string txtOtros { get; set; }
        public bool chkDFFFS { get; set; }
        public string txtDFFFS { get; set; }
        public bool chkDSFFS { get; set; }
        public string txtDSFFS { get; set; }
        public bool chkURH { get; set; }
        public string txtURH { get; set; }
        public bool chkOCI2 { get; set; }
        public string txtOCI2 { get; set; }
        public bool chkOtros2 { get; set; }
        public string txtOtros2 { get; set; }
        public string txtNotificacion { get; set; }
        public bool chk { get; set; }
        public string txtControlCalidadObservaciones { get; set; }
        public bool chkItemObsSubsanada { get; set; }
        public string lbtnMaderable { get; set; }
        public string lbtnSemilleroMaderable { get; set; }
        public string ddlDetermina_DocRetrotrae { get; set; } //*
        public string txtDetermina_DesDocRetrotrae { get; set; }
        public IEnumerable<VM_Cbo> ddlDetermina_ItemArticulo { get; set; }
        public string ddlDetermina_ItemArticuloId { get; set; }
        public IEnumerable<VM_Cbo> ddlDeterminaRetrotraer { get; set; }
        public string ddlDeterminaRetrotraerId { get; set; }
        public string txtDescripcionOtros { get; set; }
        public string txtDescripcionOtro { get; set; }
        public string TextBox11 { get; set; }
        public string TextTramite { get; set; }
        public string txtFechaPresentacion { get; set; }
        public string txtBExtraccionFEmision { get; set; } //*
        public string txtFechaEmision { get; set; }
        public string TextBox12 { get; set; }
        public bool cbl { get; set; }
        public IEnumerable<VM_Cbo> ddlLevantamiento { get; set; } //*
        public string ddlLevantamientoId { get; set; }
        public IEnumerable<VM_Cbo> ddlMedCorrect { get; set; } //*
        public string ddlMedCorrectId { get; set; }
        public IEnumerable<VM_Cbo> ddlCMulta { get; set; } //*
        public string ddlCMultaId { get; set; }
        public IEnumerable<VM_Cbo> ddlAmonestacion { get; set; }
        public string ddlAmonestacionId { get; set; }
        public bool CheckBoxList1 { get; set; }
        public string MuestraCamposDetermina_Motivo { get; set; }
        public string MuestraCamposDetermina_DocRetrotrae { get; set; }
        public IEnumerable<VM_Cbo> ddlItemPN_DITipo { get; set; }
        public IEnumerable<VM_Cbo> ddlODRegistro { get; set; }
        public IEnumerable<VM_Cbo> cbparentesco { get; set; }
        public IEnumerable<VM_Cbo> cbentidad { get; set; }
        public IEnumerable<VM_Cbo> ddlArticulos { get; set; }
        public string ddlArticulosId { get; set; }
        public IEnumerable<VM_Cbo> ddlArticulo { get; set; }
        public string ddlArticuloId { get; set; }
        public IEnumerable<VM_Cbo> ddlPOA { get; set; }
        public string ddlPOAId { get; set; }
        public IEnumerable<VM_Cbo> ddlTipoAprovechamiento { get; set; }
        public string ddlTipoAprovechamientoId { get; set; }
        public string txtArchivoAdjunto { get; set; }
        public string txtNumeroIndividuo { get; set; }
        public string txtNumeroIndividuos { get; set; }
        public IEnumerable<VM_Cbo> ddlEspeciesFauna { get; set; }
        public string ddlEspeciesFaunaId { get; set; }
        public IEnumerable<VM_Cbo> ddlEspeciesFlora { get; set; }
        public string ddlEspeciesFloraId { get; set; }
        public string inptExpediente { get; set; }
        public IEnumerable<VM_Cbo> ddlDeterminaRetrotraer2 { get; set; }
        public string ddlDeterminaRetrotraerId2 { get; set; }
        public IEnumerable<VM_Cbo> ddlRetrotraer2 { get; set; }
        public string ddlRetrotraerId2 { get; set; }
        public string txtDescripcionOtros2 { get; set; }
        public bool chkDescripcionRetrotraer2 { get; set; }
        public string txtDescripcionRetrotraer2 { get; set; }
        public string txtNumeroTHabilitante { get; set; }
        public string txtNTitularAd { get; set; }


        // ------------------------------------------------------------

        public string txtIdArticulo { get; set; }
        public string txtDescripcionArticulo { get; set; }
        public string txtIdEnciso { get; set; }
        public string txtDescEnciso { get; set; }
        public string txtIdPOA { get; set; }
        public string txtDescPOA { get; set; }
        public string txtAreaInfrac { get; set; }
        public string txtCodEspecie { get; set; }
        public string txtNumIndv { get; set; }

        public string txtDescInfrac { get; set; }
        public string txtVolumenInf { get; set; }
        public string txtIdTipoAprov { get; set; }
        public List<Ent_TFFS> ListArticulo { get; set; }
        public List<Ent_TFFS> ListEspeciesMC { get; set; }
        public List<Ent_TFFS> listaEspeciesFloraCombo { get; set; }
        public List<Ent_TFFS> listaEspeciesFaunaCombo { get; set; }
        public List<Ent_SBusqueda> ListIncisos { get; set; }
        public List<Ent_SBusqueda> ListTipoAprovechamiento { get; set; }
        public List<Ent_TFFS> ListarIniPAU { get; set; }
        public string txtIdTipoMotivoArch { get; set; }
        public string txtDescTipoMotivoArch { get; set; }
        public string txtDescArchivo { get; set; }
        public string txtIdSubTipoMotivoArch { get; set; }
        public string txtDescSubTipoMotivoArch { get; set; }
        public List<Ent_SBusqueda> ListSubTipoArchivo { get; set; }
        public List<Ent_TFFS> ListMotivoArchivo { get; set; }
        public string txtProfesional { get; set; }
        public string txtCargo { get; set; }
        public string COD_RESOLUCION_TFFS_RECTIFICA { get; set; }

        // -----------------------------------------------------

        public List<Ent_TFFS> ListInformes { get; set; }
        public List<Ent_RESODIREC> ListInfraccionRD { get; set; }
        public List<Ent_TFFS> ListPOAOBSERVATORIO { get; set; }
        public List<Ent_TFFS> ListLiteralRD { get; set; }
        public List<Ent_TFFS> ListProveidoGenerar { get; set; }
        public List<Ent_TFFS> ListEMaderable { get; set; }
        public List<Ent_TFFS> ListEMaderableSemillero { get; set; }
        public List<Ent_TFFS> ListEliTABLA { get; set; }
        public List<Ent_TFFS> listEliInformes { get; set; }
        public List<Ent_TFFS> listELiPersonaFirma { get; set; }
        public List<Ent_TFFS> listEliInfracciones { get; set; }
        public List<Ent_TFFS> ListPersonaFirma { get; set; }
        public List<Ent_TFFS> ListRecomendacion { get; set; }
        public List<Ent_TFFS> ListPOA { get; set; }
        public IEnumerable<VM_Cbo> ListMComboDIdentidad { get; set; }
        public List<Ent_TFFS> ListARFFS { get; set; }

        public List<string> ListPOAChecked { get; set; }
        //-------------------------------------------------------------------

        public List<Ent_TFFS> ListRecomendacion2 { get; set; }
        public List<Ent_TFFS> ListResolucion { get; set; }
        public List<Ent_TFFS> ListTipoResolucion { get; set; }
        public List<Ent_TFFS> ListApelacion { get; set; }
        public List<Ent_TFFS> ListIndicador { get; set; } //*
        public List<Ent_TFFS> ListOtros { get; set; }
        public List<Ent_TFFS> ListaNulidadOficio { get; set; }
        public List<Ent_TFFS> ListMedCorrect { get; set; }
        public List<Ent_TFFS> ListaUbigeoDepartamento { get; set; }
        public List<Ent_TFFS> ListaConfirmaResol { get; set; }
        public List<Ent_TFFS> ListEstadoPAU { get; set; }
        public List<Ent_TFFS> ListImpro { get; set; }
        public List<Ent_TFFS> ListInadm { get; set; }
        public List<Ent_TFFS> ListNulidad { get; set; }
        public List<Ent_TFFS> ListNulidadOficio { get; set; }
        public List<Ent_TFFS> ListNulidad2 { get; set; }
        public List<Ent_TFFS> ListNulidad3 { get; set; }
        public List<Ent_TFFS> ListCboSentidoRes { get; set; }
        public List<Ent_TFFS> ListComboDeterminaRes { get; set; }
        public List<Ent_TFFS> ListCboRetrotraer { get; set; }
        public List<Ent_TFFS> ListDetermina_DocRetrotrae { get; set; }
        public List<Ent_TFFS> ListConfirmaResol_EstDeterminaCaducidad { get; set; }
        public List<Ent_TFFS> ListConfirmaResol_EstDeterminaMulta { get; set; }
        public List<Ent_TFFS> ListConfirmaResol_EstDeterminaMCorrectiva { get; set; }


        // -------- GRILLAS DENTRO DE LA EDICION ------------
        public List<Ent_TFFS> grvItemInforme { get; set; }
        public List<Ent_TFFS> grvPersonasFirma { get; set; }
        public List<Ent_TFFS> grvLiteralesRDTermino { get; set; }
        public List<Ent_SBusqueda> sBusquedaApelada { get; set; }
        public List<Ent_SBusqueda> sBusquedaTFFSApel { get; set; }
        public List<Ent_SBusqueda> sBusquedaPersona { get; set; }
        public List<Ent_TFFS> tbApeladas { get; set; }
        public List<Ent_RESODIREC> tbInfracciones { get; set; }
        public List<Ent_TFFS> tbNoti { get; set; }
        public List<Ent_TFFS> tbBuscarTFFS { get; set; }
        public List<Ent_TFFS> tbPersonas { get; set; }
        public List<Ent_TFFS> tbARFFS { get; set; }
        public string txtNumeroDocumento { get; set; }
        public string txtTituloModal { get; set; }
        public string txtManGrillaBuscar1 { get; set; }

    }
}
