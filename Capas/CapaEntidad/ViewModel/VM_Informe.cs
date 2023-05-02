using CapaEntidad.DOC;
using System;
using System.Collections.Generic;

namespace CapaEntidad.ViewModel
{
    public class VM_SupervisorCalidad
    {
        public String Nombre_Supervisor_Calidad { get; set; }
        public String hdSupervisor_Calidad { get; set; }
    }
    public class VM_Informe
    {
        public String Nombre_Supervisor_Calidad { get; set; }
        public String hdSupervisor_Calidad { get; set; }
        public string lblTituloCabecera { get; set; }
        public string lblTituloEstado { get; set; }

        public VM_ControlCalidad_2 vmControlCalidad { get; set; }
        public VM_Informe_CNotificacion vmInfCNotificacion { get; set; }

        public string hdfCodInforme { get; set; }
        public Ent_INFORME ent_INFORME { get; set; }
        public int hdfRegEstado { get; set; }
        public bool chkPublicar { get; set; }
        public bool chkDenuncia { get; set; }
        public string txtNumInforme { get; set; }
        public IEnumerable<VM_Cbo> ddlOd { get; set; }
        public string ddlOdId { get; set; }
        public bool chkPlanAmazonas { get; set; }
        public bool chkPlanAmazonas2014 { get; set; }
        public bool chkPlanAmazonas2015 { get; set; }
        public bool chkPlanAmazonas2016 { get; set; }

        public VM_Informe_DatoSuperv vmDatoSupervision { get; set; }
        public IDENUNCIA ent_Denuncias { get; set; }
        public string txtFechaEntrega { get; set; }
        public string hdfCodDirector { get; set; }
        public string txtDirector { get; set; }
        public List<Ent_GENEPERSONA> tbSupervisor { get; set; }
        public string txtAsunto { get; set; }
        public string txtContenido { get; set; }
        public IEnumerable<VM_Cbo> ddlRealizadoVeedor { get; set; }
        public string ddlRealizadoVeedorId { get; set; }
        public string hdfCodUbigeo { get; set; }
        public string txtUbigeo { get; set; }
        public string txtSector { get; set; }
        public List<Ent_INFORME> tbVerticeTHCampo { get; set; }
        public string txtObservacion { get; set; }
        public string txtConclusion { get; set; }
        public List<Ent_INFORME> tbEliTABLA { get; set; }
        public string hdfCodMTipo { get; set; }
        public String hdfCodDLinea { get; set; }
        public List<Ent_INFORME> tbAvistamientoFauna { get; set; }
        public List<Ent_INFORME> tbFotoSupervision { get; set; }
        public string hdfEstadoOrigen { get; set; }
        public List<Ent_INFORME_OBLIGTITULAR> tbObligTitular { get; set; }
        public List<Ent_INFORME> tbObligacion { get; set; }
        public List<Ent_INFORME> tbDesplazamiento { get; set; }
        public string hdSitd { get; set; }

        //TGS:27/08/2021
        public string ddlBuenDesempenioId { get; set; }
        public IEnumerable<VM_Cbo> ddlBuenDesempenio { get; set; }
        //TGS:25/09/2021
        public string ddlArchivaInformeId { get; set; }
        public IEnumerable<VM_Cbo> ddlArchivaInforme { get; set; }
        public string hdfPerfil { get; set; }
        public List<Ent_MANDATOS> tbMandatos { get; set; }
        public List<Ent_MANDATOS> ListMandatos { get; set; }
        public VM_Informe()
        {
            vmControlCalidad = new VM_ControlCalidad_2();
            vmInfCNotificacion = new VM_Informe_CNotificacion();

            hdfRegEstado = 1;//Nuevo registro
            ddlOdId = "0000000";
            vmDatoSupervision = new VM_Informe_DatoSuperv();
            tbSupervisor = new List<Ent_GENEPERSONA>();
            ddlRealizadoVeedor = new List<VM_Cbo>()
            {
                new VM_Cbo() { Value="0000000",Text="Seleccionar" },
                new VM_Cbo() { Value="SI",Text="SI" },
                new VM_Cbo() { Value="NO",Text="NO" }
            };
            ddlRealizadoVeedorId = "0000000";
            tbVerticeTHCampo = new List<Ent_INFORME>();
            tbEliTABLA = new List<Ent_INFORME>();
            tbAvistamientoFauna = new List<Ent_INFORME>();
            tbFotoSupervision = new List<Ent_INFORME>();
            tbObligTitular = new List<Ent_INFORME_OBLIGTITULAR>();
            tbObligacion = new List<Ent_INFORME>();
            tbDesplazamiento = new List<Ent_INFORME>();
            tbMandatos = new List<Ent_MANDATOS>();
        }
    }

    public class VM_Informe_CNotificacion
    {
        public string txtCNotificacion { get; set; }
        public string hdfCodCNotificacion { get; set; }
        public string txtTHabilitante { get; set; }

        public List<Ent_INFORME> tbCNotificacion { get; set; }
        public List<Ent_INFORME> tbPoa { get; set; }

        public VM_Informe_CNotificacion()
        {
            tbCNotificacion = new List<Ent_INFORME>();
            tbPoa = new List<Ent_INFORME>();
        }
    }

    public class VM_Informe_Foto
    {
        public string hdfCodInformeFoto { get; set; }
        public string hdfCodInforme { get; set; }
        public string hdfNumInforme { get; set; }
        public string txtNumTHabilitante { get; set; }
        public string txtUsuarioRegistro { get; set; }
        public string txtFechaRegistro { get; set; }
        public string txtDescripcion { get; set; }
        public string txtFuente { get; set; }
        public string txtDispositivo { get; set; }
        public string txtUrlFoto { get; set; }
    }

    public class VM_Informe_POASupervisado
    {
        public string lblTituloEstado { get; set; }
        public string hdfCodInforme { get; set; }
        public Int32 hdfNumPoa { get; set; }
        public string hdfCodNoPoa { get; set; }
        public string hdfCodMTipo { get; set; }
        public string hdfLinderamientoArea { get; set; }
        public string hdfAreaDemarcacion { get; set; }
        public string hdfAreaLinderamiento { get; set; }
        public IEnumerable<VM_Cbo> ddlIndicioAprovecha { get; set; }
        public string ddlIndicioAprovechaId { get; set; }
        public string txtObsAprovecha { get; set; }
        public string hdfTipoSisAprovecha { get; set; }
        public string hdfPresenciaHuayrona { get; set; }
        public IEnumerable<VM_Cbo> ddlCumpleVial { get; set; }
        public string ddlCumpleVialId { get; set; }
        public string hdfAreaReposicion { get; set; }
        public string txtFecPresentaPlan { get; set; }
        public string txtFecApruebaPlan { get; set; }
        public string txtFecEntregaAcervo { get; set; }
        public IEnumerable<VM_Cbo> ddlPlanConcuerdaPgmf { get; set; }
        public string ddlPlanConcuerdaPgmfId { get; set; }
        public string txtObsPlanConcuerdaPgmf { get; set; }
        public IEnumerable<VM_Cbo> ddlPlanApruebaNorma { get; set; }
        public string ddlPlanApruebaNormaId { get; set; }
        public string txtObsPlanApruebaNorma { get; set; }
        public IEnumerable<VM_Cbo> ddlInformeEjecutaPlan { get; set; }
        public string ddlInformeEjecutaPlanId { get; set; }
        public IEnumerable<VM_Cbo> ddlTipoInformeEjecuta { get; set; }
        public string ddlTipoInformeEjecutaId { get; set; }
        public string txtFecPresentaAutoridad { get; set; }
        //public string txtFecCumplimientoOsinfor { get; set; }
        public string txtFecComunicaOsinfor { get; set; }
        public IEnumerable<VM_Cbo> ddlCumpleLineamiento { get; set; }
        public string ddlCumpleLineamientoId { get; set; }
        public string txtObsCumpleLineamiento { get; set; }
        public IEnumerable<VM_Cbo> ddlCumplePagoAprov { get; set; }
        public string ddlCumplePagoAprovId { get; set; }
        public string txtObsCumplePagoAprov { get; set; }
        public IEnumerable<VM_Cbo> ddlImpactoDanio { get; set; }
        public string ddlImpactoDanioId { get; set; }
        public IEnumerable<VM_Cbo> ddlOportunidadAprov { get; set; }
        public string ddlOportunidadAprovId { get; set; }
        public bool chkRecReformulaPlan { get; set; }
        public string txtDescOtraRec { get; set; }
        public string hdfCodTitularEjecuta { get; set; }
        public string txtTitularEjecuta { get; set; }
        public string hdfCodRegenteImplementa { get; set; }
        public string txtRegenteImplementa { get; set; }
        public bool hdfMaderable { get; set; }
        public bool hdfNoMaderable { get; set; }
        //DIRECCION  UBIGEO DE REGENTE
        public string txtCodUbigeo { get; set; }
        public string txtUbigeo { get; set; }
        public string txtDirecion { get; set; }

        public List<Ent_INFORME> tbEliTABLA { get; set; }
        public List<Ent_INFORME_CONDICION_AREA> tbCondicionArea { get; set; }
        public List<Ent_INFORME_VERTICE_AREA> tbVerticeArea { get; set; }
        public List<Ent_INFORME_EVAL_ARBOL> tbEvalArbolAdicional { get; set; }
        public List<Ent_INFORME_EVAL_ARBOL> tbEvalArbolNoAutorizado { get; set; }
        public List<Ent_INFORME_HUAYRONA> tbHuayrona { get; set; }
        public List<Ent_INFORME_ACT_SILVICULTURAL> tbActividadSilvicultural { get; set; }
        public List<Ent_INFORME_CAMBIO_USO> tbCambioUso { get; set; }
        public List<Ent_INFORME_EVAL_OTRO> tbEvalOtro { get; set; }
        public List<Ent_INFORME_VOL_ANALIZADO> tbVolumenAnalizado { get; set; }
        //llanos
        public List<Ent_INFORME_ANALISIS> tbAnalisis { get; set; }
        public List<Ent_INFORME_CONSOLIDADO> tbConsolidado { get; set; }
        public List<Ent_INFORME_CONSOLIDADO> tbConsolidadoNN { get; set; }
        public List<Ent_INFORME_MADERABLE_A> tbMaderable { get; set; }
        //Parcelas de corta
        public IEnumerable<VM_Chk> lstChkParcelaCorta { get; set; }
        public string lstChkParcelaCortaId { get; set; }

        //Tercero solidario 21.09.2022 TGS
        public string hdfCodTerceroSolidario { get; set; }
        public string txtTerceroSolidario { get; set; }

        public VM_Informe_POASupervisado()
        {
            tbEliTABLA = new List<Ent_INFORME>();
            tbCondicionArea = new List<Ent_INFORME_CONDICION_AREA>();
            tbVerticeArea = new List<Ent_INFORME_VERTICE_AREA>();
            tbEvalArbolAdicional = new List<Ent_INFORME_EVAL_ARBOL>();
            tbEvalArbolNoAutorizado = new List<Ent_INFORME_EVAL_ARBOL>();
            tbHuayrona = new List<Ent_INFORME_HUAYRONA>();
            ddlIndicioAprovecha = new List<VM_Cbo>() { new VM_Cbo() { Value = "NO", Text = "NO" }, new VM_Cbo() { Value = "SI", Text = "SI" } };
            ddlIndicioAprovechaId = "NO";
            ddlCumpleVial = new List<VM_Cbo>() { new VM_Cbo() { Value = "NO", Text = "NO" }, new VM_Cbo() { Value = "SI", Text = "SI" } };
            ddlCumpleVialId = "NO";
            tbActividadSilvicultural = new List<Ent_INFORME_ACT_SILVICULTURAL>();
            tbCambioUso = new List<Ent_INFORME_CAMBIO_USO>();
            tbEvalOtro = new List<Ent_INFORME_EVAL_OTRO>();
            ddlPlanConcuerdaPgmf = new List<VM_Cbo>() { new VM_Cbo() { Value = "NO", Text = "NO" }, new VM_Cbo() { Value = "SI", Text = "SI" } };
            ddlPlanConcuerdaPgmfId = "NO";
            ddlPlanApruebaNorma = new List<VM_Cbo>() { new VM_Cbo() { Value = "NO", Text = "NO" }, new VM_Cbo() { Value = "SI", Text = "SI" } };
            ddlPlanApruebaNormaId = "NO";
            ddlInformeEjecutaPlan = new List<VM_Cbo>() {
                new VM_Cbo() { Value = "0000000", Text = "Seleccionar" }, new VM_Cbo() { Value = "NO", Text = "NO" }
                , new VM_Cbo() { Value = "SI", Text = "SI" }, new VM_Cbo() { Value = "No amerita por encontrase vigente", Text = "No amerita por encontrase vigente" } };
            ddlInformeEjecutaPlanId = "0000000";
            ddlTipoInformeEjecutaId = "0000000";
            ddlCumpleLineamiento = new List<VM_Cbo>() { new VM_Cbo() { Value = "NO", Text = "NO" }, new VM_Cbo() { Value = "SI", Text = "SI" } };
            ddlCumpleLineamientoId = "NO";
            ddlCumplePagoAprov = new List<VM_Cbo>() { new VM_Cbo() { Value = "NO", Text = "NO" }, new VM_Cbo() { Value = "SI", Text = "SI" } };
            ddlCumplePagoAprovId = "NO";
            ddlImpactoDanioId = "0000000";
            ddlOportunidadAprovId = "0000000";
            tbVolumenAnalizado = new List<Ent_INFORME_VOL_ANALIZADO>();
            tbConsolidadoNN = new List<Ent_INFORME_CONSOLIDADO>();
        }
    }

    public class VM_Informe_ExSitu
    {
        public string lblTituloCabecera { get; set; }
        public string lblTituloEstado { get; set; }
        public String Nombre_Supervisor_Calidad { get; set; }
        public String hdSupervisor_Calidad { get; set; }
        public VM_ControlCalidad_2 vmControlCalidad { get; set; }

        public string hdfCodInforme { get; set; }
        public int hdfRegEstado { get; set; }
        public string hdfCodMTipo { get; set; }
        public bool chkPublicar { get; set; }
        public string txtObsPublicar { get; set; }
        public VM_Informe_CNotificacion vmInfCNotificacion { get; set; }
        public IEnumerable<VM_Cbo> ddlOd { get; set; }
        public string ddlOdId { get; set; }
        public bool chkTodos { get; set; }
        public bool chkHechos { get; set; }
        public bool chkMandatos { get; set; }
        public bool chkobjMandatos { get; set; }
        public string txtobjDescripcionMandato { get; set; }
        public string txtobjDiasImpl { get; set; }
        public string txtobjDiasPostImpl { get; set; }
        public string txtobjDiasInf { get; set; }
        public bool chkMedidas { get; set; }
        public string txtNumInforme { get; set; }
        public string txtFechaEntrega { get; set; }
        public bool chkFFPropia { get; set; }
        public bool chkFFDonaciones { get; set; }
        public bool chkFFCredito { get; set; }
        public bool chkFFInversionista { get; set; }
        public bool chkFFApoyo { get; set; }
        public bool chkFFVoluntario { get; set; }
        public string txtFFOtro { get; set; }
        public VM_Informe_DatoSuperv vmDatoSupervision { get; set; }
        public bool chkLicFuncionamiento { get; set; }
        public string txtLicFuncionamiento { get; set; }
        public string txtAsunto { get; set; }
        public string txtContenido { get; set; }
        public string hdfCodUbigeo { get; set; }
        public string txtUbigeo { get; set; }
        public string txtSector { get; set; }
        public bool chkRegente { get; set; }
        public string hdfCodRegente { get; set; }
        public string txtRegente { get; set; }
        public string txtCodigoRegente { get; set; }
        public string txtFecIniRegencia { get; set; }
        public string txtObjetivoActual { get; set; }
        public string txtObjetivoPrincipal { get; set; }
        public bool chkRecibeVisita { get; set; }
        public bool chkReproduceEspCautiverio { get; set; }
        public List<Ent_GENEPERSONA> tbSupervisor { get; set; }
        public List<Ent_GENEPERSONA> tbPersonalTecProf { get; set; }
        public string txtObservacion { get; set; }
        public string txtConclusion { get; set; }
        public string txtRecomendacion { get; set; }
        public bool chkRecomendar { get; set; }
        public string txtMandatos { get; set; }
        //Datos Infraestructura
        public bool chkCroquis { get; set; }
        public bool chkViaSenalizada { get; set; }
        public bool chkCartelAreaAdmin { get; set; }
        public bool chkCartelSSHH { get; set; }
        public string txtDescOtroAmbiente { get; set; }
        public List<Ent_ISUPERVISION_EXSITU_INFRA_AREA> tbAreaExSitu { get; set; }
        //Cautiverio
        public string hdfCodResponsable { get; set; }
        public string txtResponsable { get; set; }
        public bool chkProgAlimentacion { get; set; }
        public bool chkProtAlimentacion { get; set; }
        public IEnumerable<VM_Cbo> ddlOpcionSiNo { get; set; }
        public string ddlProgContencionId { get; set; }
        public string ddlProgBioseguridadId { get; set; }
        public bool chkProtLimpieza { get; set; }
        public IEnumerable<VM_Cbo> ddlFrecFecha { get; set; }
        public string ddlFrecLimpiezaId { get; set; }
        public string txtFrecLimpieza { get; set; }
        public bool chkPediluvio { get; set; }
        public bool chkManejoResiduo { get; set; }
        public IEnumerable<VM_Cbo> ddlDispResiduoOrg { get; set; }
        public string ddlDispResiduoOrgId { get; set; }
        public IEnumerable<VM_Cbo> ddlDispResiduoInorg { get; set; }
        public string ddlDispResiduoInorgId { get; set; }
        public IEnumerable<VM_Cbo> ddlDispResiduoCadaver { get; set; }
        public string ddlDispResiduoCadaverId { get; set; }
        public string ddlFrecDesinfeccionId { get; set; }
        public string txtFrecDesinfeccion { get; set; }
        public string ddlProgEnriquecimientoId { get; set; }
        public string ddlProgGeneticoId { get; set; }
        public string ddlProgEducacionId { get; set; }
        public string ddlProgInvetigacionId { get; set; }
        public string ddlProgCapturaId { get; set; }
        public string ddlProgCapacitacionId { get; set; }
        public string txtHoraRepAlimento { get; set; }
        public string txtDiaAbastecimiento { get; set; }
        public string ddlProtContingenciaId { get; set; }
        public string ddlProtAccionId { get; set; }
        public IEnumerable<VM_Cbo> ddlProtAccion { get; set; }
        public string ddlCuentaVetMedId { get; set; }
        public IEnumerable<VM_Cbo> ddlCuentaVetMed { get; set; }
        public string ddlTipoVisMedId { get; set; }
        public IEnumerable<VM_Cbo> ddlTipoVisMed { get; set; }
        public string txtObsProtAccion { get; set; }
        public string txtVisitaporMes { get; set; }
        public string txtObsMedVet { get; set; }
        public string ddlPresentInfEjecPMId { get; set; }
        public string txtAnioPresentInfEjec { get; set; }

        //TGS:27/08/2021
        public string ddlBuenDesempenioId { get; set; }
        public IEnumerable<VM_Cbo> ddlBuenDesempenio { get; set; }
        //TGS:25/09/2021
        public string ddlArchivaInformeId { get; set; }
        public IEnumerable<VM_Cbo> ddlArchivaInforme { get; set; }
        public string hdfPerfil { get; set; }

        public List<Ent_ISUPERVISION_EXSITU_INFRA_AREA> tbGrupoTaxonomico { get; set; }
        public List<Ent_ISUPERVISION_EXSITU_INFRA_AREA> tbEquipoContFisico { get; set; }
        public List<Ent_ISUPERVISION_EXSITU_INFRA_AREA> tbEquipoContQuimico { get; set; }
        public List<Ent_ISUPERVISION_EXSITU_INFRA_AREA> tbEquipoLimpieza { get; set; }
        public List<Ent_ISUPERVISION_EXSITU_INFRA_AREA> tbMaterialDesinfeccion { get; set; }
        public List<Ent_ISUPERVISION_EXSITU_INFRA_AREA> tbEquipoDesinfeccion { get; set; }
        public List<Ent_ISUPERVISION_EXSITU_INFRA_AREA> tbControlPlaga { get; set; }
        public List<Ent_ISUPERVISION_EXSITU_INFRA_AREA> tbManejoRegistro { get; set; }
        public List<Ent_ISUPERVISION_EXSITU_INFRA_AREA> tbEnriquecimientoAmb { get; set; }
        public List<Ent_ISUPERVISION_EXSITU_INFRA_AREA> tbEspecieReproducida { get; set; }
        public List<Ent_ISUPERVISION_EXSITU_INFRA_AREA> tbEspecieCapturada { get; set; }
        public List<Ent_ISUPERVISION_EXSITU_INFRA_AREA> tbCapacitacion { get; set; }
        public List<Ent_ISUPERVISION_EXSITU_INFRA_AREA> tbEspecieNacimiento { get; set; }
        public List<Ent_ISUPERVISION_EXSITU_INFRA_AREA> tbEspecieEgreso { get; set; }
        public List<Ent_ISUPERVISION_EXSITU_INFRA_AREA> tbEspecieCenso { get; set; }
        public List<Ent_ISUPERVISION_EXSITU_INFRA_AREA> tbActividadEducacion { get; set; }
        public List<Ent_ISUPERVISION_EXSITU_INFRA_AREA> tbActividadInvestigacion { get; set; }
        public List<Ent_INFORME_OBLIGTITULAR> tbObligacionTitular { get; set; }
        public List<Ent_MANDATOS> tbMandatos { get; set; }
        public List<Ent_INFORME_ENFERMEDAD> tbEnfermedad { get; set; }

        public List<Ent_INFORME> tbFotoSupervision { get; set; }
        public double txtCalificacionZoo { get; set; }
        public List<Ent_ISUPERVISION_EXSITU_CAUTI_EVALZOO> tbEvalZoObservatorio { get; set; }
        public List<Ent_INFORME> tbEliTABLA { get; set; }
        public List<Ent_INFORME> tbDesplazamiento { get; set; }

        public List<Ent_ISUPERVISION_EXSITU_INFRA_AREA> tbBalanceIngEgr { get; set; }

        public List<Ent_GENEPERSONA> tbRelPelCentroCria { get; set; }
        public Ent_MANDATOS oMandatos { get; set; }
        public List<Ent_MANDATOS> ListMandatos { get; set; }        

        public VM_Informe_ExSitu()
        {
            vmControlCalidad = new VM_ControlCalidad_2();
            hdfRegEstado = 1;//Nuevo registro
            vmInfCNotificacion = new VM_Informe_CNotificacion();
            ddlOdId = "0000000";
            vmDatoSupervision = new VM_Informe_DatoSuperv();
            tbSupervisor = new List<Ent_GENEPERSONA>();
            ddlOpcionSiNo = new List<VM_Cbo>() { new VM_Cbo() { Value = "0000000", Text = "Seleccionar" }, new VM_Cbo() { Value = "SI", Text = "SI" }, new VM_Cbo() { Value = "NO", Text = "NO" } };
            ddlProgContencionId = "0000000";
            ddlProgBioseguridadId = "0000000";
            ddlFrecLimpiezaId = "0000000";
            ddlDispResiduoOrgId = "0000000";
            ddlDispResiduoInorgId = "0000000";
            ddlDispResiduoCadaverId = "0000000";
            ddlFrecDesinfeccionId = "0000000";
            ddlProgEnriquecimientoId = "0000000";
            ddlProgGeneticoId = "0000000";
            ddlProgEducacionId = "0000000";
            ddlProgInvetigacionId = "0000000";
            ddlProgCapturaId = "0000000";
            ddlProgCapacitacionId = "0000000";
            tbAreaExSitu = new List<Ent_ISUPERVISION_EXSITU_INFRA_AREA>();
            tbGrupoTaxonomico = new List<Ent_ISUPERVISION_EXSITU_INFRA_AREA>();
            tbEquipoContFisico = new List<Ent_ISUPERVISION_EXSITU_INFRA_AREA>();
            tbEquipoContQuimico = new List<Ent_ISUPERVISION_EXSITU_INFRA_AREA>();
            tbEquipoLimpieza = new List<Ent_ISUPERVISION_EXSITU_INFRA_AREA>();
            tbMaterialDesinfeccion = new List<Ent_ISUPERVISION_EXSITU_INFRA_AREA>();
            tbEquipoDesinfeccion = new List<Ent_ISUPERVISION_EXSITU_INFRA_AREA>();
            tbControlPlaga = new List<Ent_ISUPERVISION_EXSITU_INFRA_AREA>();
            tbManejoRegistro = new List<Ent_ISUPERVISION_EXSITU_INFRA_AREA>();
            tbEnriquecimientoAmb = new List<Ent_ISUPERVISION_EXSITU_INFRA_AREA>();
            tbEspecieReproducida = new List<Ent_ISUPERVISION_EXSITU_INFRA_AREA>();
            tbEspecieCapturada = new List<Ent_ISUPERVISION_EXSITU_INFRA_AREA>();
            tbCapacitacion = new List<Ent_ISUPERVISION_EXSITU_INFRA_AREA>();
            tbEspecieNacimiento = new List<Ent_ISUPERVISION_EXSITU_INFRA_AREA>();
            tbEspecieEgreso = new List<Ent_ISUPERVISION_EXSITU_INFRA_AREA>();
            tbEspecieCenso = new List<Ent_ISUPERVISION_EXSITU_INFRA_AREA>();
            tbActividadEducacion = new List<Ent_ISUPERVISION_EXSITU_INFRA_AREA>();
            tbActividadInvestigacion = new List<Ent_ISUPERVISION_EXSITU_INFRA_AREA>();
            txtCalificacionZoo = 0;
            tbEvalZoObservatorio = new List<Ent_ISUPERVISION_EXSITU_CAUTI_EVALZOO>();
            tbObligacionTitular = new List<Ent_INFORME_OBLIGTITULAR>();

            tbFotoSupervision = new List<Ent_INFORME>();
            tbEliTABLA = new List<Ent_INFORME>();
            tbDesplazamiento = new List<Ent_INFORME>();
            tbBalanceIngEgr = new List<Ent_ISUPERVISION_EXSITU_INFRA_AREA>();
            tbMandatos = new List<Ent_MANDATOS>();
            tbEnfermedad = new List<Ent_INFORME_ENFERMEDAD>();
        }
    }

    public class VM_Informe_DatoSuperv
    {
        public string txtFechaInicio { get; set; }
        public string txtFechaFin { get; set; }
        public IEnumerable<VM_Cbo> ddlMotivoSupervision { get; set; }
        public IEnumerable<VM_Cbo> ddlTipoSupervision { get; set; }
        public IEnumerable<VM_Cbo> ddlTipoInforme { get; set; }
        public string ddlMotivoSupervisionId { get; set; }
        public string txtMotivoSupervision { get; set; }
        public string ddlTipoSupervisionId { get; set; }
        public string ddlTipoInformeId { get; set; }
        public string txtTipoSupervision { get; set; }
        public IEnumerable<VM_Cbo> ddlTipoPeticionMotivada { get; set; }



        public string ddlTipoPeticionMotivadaId { get; set; }
        public string hdfCodDocDenunciaSITD { get; set; }
        public string txtDocDenunciaSITD { get; set; }
        public bool chkGeoTecDron { get; set; }
        public bool chkGeoTecGeoSupervisor { get; set; }
        public bool chkGeoTecOtro { get; set; }
        public bool chkGeoTecNinguno { get; set; }
        public string txtGeoTecOtro { get; set; }

        public VM_Informe_DatoSuperv()
        {
            ddlMotivoSupervisionId = "0000000";
            ddlTipoPeticionMotivadaId = "0000000";
        }
    }

    public class VM_Informe_Conservacion
    {
        public string lblTituloCabecera { get; set; }
        public string lblTituloEstado { get; set; }
        public String Nombre_Supervisor_Calidad { get; set; }
        public String hdSupervisor_Calidad { get; set; }
        public VM_ControlCalidad_2 vmControlCalidad { get; set; }

        public string hdfCodInforme { get; set; }
        public int hdfRegEstado { get; set; }
        public VM_Informe_CNotificacion vmInfCNotificacion { get; set; }
        public IEnumerable<VM_Cbo> ddlOd { get; set; }
        public string ddlOdId { get; set; }
        public string txtNumInforme { get; set; }
        public string txtFechaEntrega { get; set; }
        public List<Ent_GENEPERSONA> tbSupervisor { get; set; }
        public VM_Informe_DatoSuperv vmDatoSupervision { get; set; }
        public string hdfCodUbigeo { get; set; }
        public string txtUbigeo { get; set; }
        public string txtSector { get; set; }
        public string hdfCodTitularEjecutaPgmf { get; set; }
        public string txtTitularEjecutaPgmf { get; set; }
        public string hdfCodRegenteImplPgmf { get; set; }
        public string txtRegenteImplPgmf { get; set; }
        public List<VM_Cbo> ddlOpcionSiNo { get; set; }
        public string ddlCuentaCroquisId { get; set; }
        public string ddlCuentaSenderoId { get; set; }
        public string ddlSenalizacionSenderoId { get; set; }
        public string txtObservacion { get; set; }
        public string txtConclusion { get; set; }
        public string txtAsunto { get; set; }
        public string txtContenido { get; set; }
        public string hdfPerfil { get; set; }
        public List<Ent_INFORME_VERTICE> tbCoordenadaUTM { get; set; }
        public List<Ent_INFORME> tbEliTABLA { get; set; }
        public List<Ent_INFORME_PROGRAMA> tbPrograma { get; set; }
        public List<Ent_INFORME> tbInfraestructura { get; set; }
        public List<Ent_INFORME> tbActividadPrograma { get; set; }
        public List<Ent_INFORME> tbManejoImpacto { get; set; }
        public List<Ent_INFORME> tbRegFauna { get; set; }
        public List<Ent_INFORME_REGFLORA> tbRegFlora { get; set; }
        public List<Ent_INFORME_REGPAISAJE> tbRegPaisaje { get; set; }
        public string hdfCodMTipo { get; set; }
        public List<Ent_INFORME> tbZonificacion { get; set; }
        public List<Ent_INFORME> tbEquipamiento { get; set; }
        public List<Ent_INFORME> tbObligacion { get; set; }
        public List<Ent_INFORME_OBLIGTITULAR> tbObligTitular { get; set; }
        public List<Ent_INFORME> tbDesplazamiento { get; set; }
        public List<Ent_INFORME> tbActTuristica { get; set; }
        public List<Ent_INFORME> tbActIntAmbiental { get; set; }
        public List<Ent_INFORME> tbActInvestigacion { get; set; }
        public List<Ent_INFORME> tbActVisitas { get; set; }
        public List<Ent_INFORME> tbActOtroPrograma { get; set; }
        //30.04.2021
        public List<Ent_INFORME_IMPACTO> tbImpacto { get; set; }
        public List<Ent_INFORME> tbEliTABLAImpacto { get; set; }
        public List<Ent_INFORME_IMPACTO> tbAfectacion { get; set; }
        public List<Ent_INFORME> tbEliTABLAfectacion { get; set; }

        public List<VM_Cbo> ddlZona { get; set; }
        public String ddlZonaId { get; set; }
        public List<VM_Cbo> ddlAutorizado { get; set; }
        public String ddlAutorizadoId { get; set; }

        //TGS:27/08/2021
        public string ddlBuenDesempenioId { get; set; }
        public IEnumerable<VM_Cbo> ddlBuenDesempenio { get; set; }
        //TGS:25/09/2021
        public string ddlArchivaInformeId { get; set; }
        public IEnumerable<VM_Cbo> ddlArchivaInforme { get; set; }
        public string ddlTipoInformeId { get; set; }
        public List<Ent_MANDATOS> tbMandatos { get; set; }
        public List<Ent_MANDATOS> ListMandatos { get; set; }

        public VM_Informe_Conservacion()
        {
            vmControlCalidad = new VM_ControlCalidad_2();
            hdfRegEstado = 1;//Nuevo registro
            vmInfCNotificacion = new VM_Informe_CNotificacion();
            ddlOdId = "0000000";
            tbSupervisor = new List<Ent_GENEPERSONA>();
            vmDatoSupervision = new VM_Informe_DatoSuperv();
            tbCoordenadaUTM = new List<Ent_INFORME_VERTICE>();
            tbEliTABLA = new List<Ent_INFORME>();
            tbPrograma = new List<Ent_INFORME_PROGRAMA>();
            ddlOpcionSiNo = new List<VM_Cbo>() {
                new VM_Cbo() { Value="0000000",Text="Seleccionar"},new VM_Cbo() { Value="SI",Text="SI"},new VM_Cbo() { Value="NO",Text="NO"}
            };
            ddlCuentaCroquisId = "0000000";
            ddlCuentaSenderoId = "0000000";
            ddlSenalizacionSenderoId = "0000000";
            tbInfraestructura = new List<Ent_INFORME>();
            tbActividadPrograma = new List<Ent_INFORME>();
            tbManejoImpacto = new List<Ent_INFORME>();
            tbRegFauna = new List<Ent_INFORME>();
            tbRegFlora = new List<Ent_INFORME_REGFLORA>();
            tbRegPaisaje = new List<Ent_INFORME_REGPAISAJE>();
            tbZonificacion = new List<Ent_INFORME>();
            tbEquipamiento = new List<Ent_INFORME>();
            tbObligacion = new List<Ent_INFORME>();
            tbObligTitular = new List<Ent_INFORME_OBLIGTITULAR>();
            tbDesplazamiento = new List<Ent_INFORME>();
            tbActTuristica = new List<Ent_INFORME>();
            tbActIntAmbiental = new List<Ent_INFORME>();
            tbActInvestigacion = new List<Ent_INFORME>();
            tbActVisitas = new List<Ent_INFORME>();
            tbActOtroPrograma = new List<Ent_INFORME>();
            tbImpacto = new List<Ent_INFORME_IMPACTO>();
            tbEliTABLAImpacto = new List<Ent_INFORME>();
            tbAfectacion = new List<Ent_INFORME_IMPACTO>();
            tbEliTABLAfectacion = new List<Ent_INFORME>();
            tbMandatos = new List<Ent_MANDATOS>();
        }
    }

    public class VM_Informe_Fauna
    {

        public string lblTituloCabecera { get; set; }
        public string lblTituloEstado { get; set; }
        public String Nombre_Supervisor_Calidad { get; set; }
        public String hdSupervisor_Calidad { get; set; }
        public VM_ControlCalidad_2 vmControlCalidad { get; set; }

        public string hdfCodInforme { get; set; }
        public int hdfRegEstado { get; set; }
        public bool chkPublicar { get; set; }

        public VM_Informe_CNotificacion vmInfCNotificacion { get; set; }
        public IEnumerable<VM_Cbo> ddlOd { get; set; }
        public string ddlOdId { get; set; }
        public string txtNumInforme { get; set; }
        public string txtFechaEntrega { get; set; }
        public string hdfCodDirector { get; set; }
        public string txtDirector { get; set; }
        public List<Ent_GENEPERSONA> tbSupervisor { get; set; }
        public string txtAsunto { get; set; }
        public string txtContenido { get; set; }
        public VM_Informe_DatoSuperv vmDatoSupervision { get; set; }
        public IEnumerable<VM_Cbo> ddlRealizadoVeedor { get; set; }
        public string ddlRealizadoVeedorId { get; set; }
        public string hdfCodResponsable { get; set; }
        public string txtResponsable { get; set; }
        public string hdfCodTitularEjecutaPgmf { get; set; }
        public string txtTitularEjecutaPgmf { get; set; }
        public string hdfCodRegenteImplPgmf { get; set; }
        public string txtRegenteImplPgmf { get; set; }
        public string hdfCodUbigeo { get; set; }
        public string txtUbigeo { get; set; }
        public string txtSector { get; set; }
        public string txtObservacion { get; set; }
        public string txtConclusion { get; set; }
        public string hdfPerfil { get; set; }
        public List<Ent_INFORME> tbFotoSupervision { get; set; }
        public List<Ent_INFORME_PROGRAMA> tbPrograma { get; set; }
        public List<Ent_INFORME_ENFERMEDAD> tbEnfermedad { get; set; }
        public List<Ent_INFORME> tbManejoImpacto { get; set; }
        public List<Ent_INFORME> tbResponsabilidadSocial { get; set; }
        public List<Ent_INFORME> tbObligacionContrac { get; set; }
        public List<Ent_INFORME> tbEliTABLA { get; set; }
        public List<Ent_INFORME> tbDesplazamiento { get; set; }

        //TGS:27/08/2021
        public string ddlBuenDesempenioId { get; set; }
        public IEnumerable<VM_Cbo> ddlBuenDesempenio { get; set; }
        //TGS:25/09/2021
        public string ddlArchivaInformeId { get; set; }
        public IEnumerable<VM_Cbo> ddlArchivaInforme { get; set; }

        public string hdfCodMTipo { get; set; }
        public string ddlTipoInformeId { get; set; }
        public List<Ent_MANDATOS> tbMandatos { get; set; }
        public List<Ent_MANDATOS> ListMandatos { get; set; }
        public List<Ent_INFORME> tbVerticeTHCampo { get; set; }
        public List<Ent_INFORME> tbCoberturaBoscosa { get; set; }
        public List<Ent_INFORME> tbOtrosPtosEval { get; set; }
        public List<Ent_INFORME> tbInfraestructura { get; set; }
        public List<Ent_INFORME> tbZonifDistribEspecie { get; set; }
        public List<Ent_INFORME> tbAprovSostenible { get; set; }
        public List<Ent_INFORME> tbRegFauna { get; set; }
        public List<Ent_INFORME_OBLIGTITULAR> tbObligacionTitular { get; set; }
        public VM_Informe_Fauna()
        {
            vmControlCalidad = new VM_ControlCalidad_2();
            hdfRegEstado = 1;
            vmInfCNotificacion = new VM_Informe_CNotificacion();
            ddlOdId = "0000000";
            tbSupervisor = new List<Ent_GENEPERSONA>();
            vmDatoSupervision = new VM_Informe_DatoSuperv();
            ddlRealizadoVeedor = new List<VM_Cbo>()
            {
                new VM_Cbo() { Value="0000000",Text="Seleccionar" },
                new VM_Cbo() { Value="SI",Text="SI" },
                new VM_Cbo() { Value="NO",Text="NO" }
            };
            ddlRealizadoVeedorId = "0000000";
            tbFotoSupervision = new List<Ent_INFORME>();
            tbPrograma = new List<Ent_INFORME_PROGRAMA>();
            tbManejoImpacto = new List<Ent_INFORME>();
            tbEliTABLA = new List<Ent_INFORME>();
            tbResponsabilidadSocial = new List<Ent_INFORME>();
            tbObligacionContrac = new List<Ent_INFORME>();
            tbDesplazamiento = new List<Ent_INFORME>();
            tbMandatos = new List<Ent_MANDATOS>();
            tbVerticeTHCampo = new List<Ent_INFORME>();
            tbCoberturaBoscosa = new List<Ent_INFORME>();
            tbOtrosPtosEval = new List<Ent_INFORME>();
            tbInfraestructura = new List<Ent_INFORME>();
            tbZonifDistribEspecie = new List<Ent_INFORME>();
            tbAprovSostenible = new List<Ent_INFORME>();
            tbObligacionTitular = new List<Ent_INFORME_OBLIGTITULAR>();
            tbRegFauna = new List<Ent_INFORME>();
            tbEnfermedad = new List<Ent_INFORME_ENFERMEDAD>();
    }
    }

    public class VM_Informe_POAFaunaSupervisado
    {
        public string lblTituloEstado { get; set; }
        public string hdfCodInforme { get; set; }
        public Int32 hdfNumPoa { get; set; }
        public string hdfCodNoPoa { get; set; }
        public List<Ent_INFORME> tbAvistamientoFauna { get; set; }
        public List<Ent_INFORME_VERTICE> tbCoordenadaUTM { get; set; }
        public List<Ent_INFORME> tbInfraestructuraImpl { get; set; }
        public List<Ent_INFORME> tbZonificacion { get; set; }
        public List<Ent_INFORME> tbAprovSostenible { get; set; }
        public List<Ent_INFORME> tbEliTABLA { get; set; }

        public VM_Informe_POAFaunaSupervisado()
        {
            tbAvistamientoFauna = new List<Ent_INFORME>();
            tbCoordenadaUTM = new List<Ent_INFORME_VERTICE>();
            tbInfraestructuraImpl = new List<Ent_INFORME>();
            tbZonificacion = new List<Ent_INFORME>();
            tbAprovSostenible = new List<Ent_INFORME>();
            tbEliTABLA = new List<Ent_INFORME>();
        }
    }

    public class VM_Informe_Tara
    {
        public string lblTituloCabecera { get; set; }
        public string lblTituloEstado { get; set; }
        public String Nombre_Supervisor_Calidad { get; set; }
        public String hdSupervisor_Calidad { get; set; }
        public VM_ControlCalidad_2 vmControlCalidad { get; set; }

        public string hdfCodInforme { get; set; }
        public int hdfRegEstado { get; set; }
        public VM_Informe_CNotificacion vmInfCNotificacion { get; set; }
        public IEnumerable<VM_Cbo> ddlOd { get; set; }
        public string ddlOdId { get; set; }
        public string txtNumInforme { get; set; }
        public string txtFechaEntrega { get; set; }
        public string hdfCodDirector { get; set; }
        public string txtDirector { get; set; }
        public string txtFechaEmision { get; set; }
        public List<Ent_GENEPERSONA> tbSupervisor { get; set; }
        public VM_Informe_DatoSuperv vmDatoSupervision { get; set; }
        public string hdfCodUbigeo { get; set; }
        public string txtUbigeo { get; set; }
        public string txtSector { get; set; }
        public bool chkLineamientoMapa { get; set; }
        public string txtLineamientoMapa { get; set; }
        public string txtAreaManejo { get; set; }
        public string txtPlantacion { get; set; }
        public bool chkForestacion { get; set; }
        public string txtForestacion { get; set; }
        public IEnumerable<VM_Cbo> ddlPlanton { get; set; }
        public string ddlPlantonId { get; set; }
        public string txtPlanton { get; set; }
        public string txtComercializacion { get; set; }
        public string txtRevAcervo { get; set; }
        public string hdfPerfil { get; set; }
        public List<Ent_INFORME_TCONCEPTO> tbTaraConcepto { get; set; }
        public List<Ent_INFORME_TCONCEPTO> tbManPlantacion { get; set; }
        public List<Ent_INFORME> tbAprovechamiento { get; set; }
        public List<Ent_INFORME> tbCapacitacion { get; set; }
        public List<Ent_INFORME> tbProduccionFruto { get; set; }
        public List<Ent_INFORME> tbAprovechaForestal { get; set; }
        public List<Ent_INFORME_TCENSO> tbCenso { get; set; }
        public List<Ent_INFORME> tbKardex { get; set; }
        public List<Ent_INFORME> tbEliTABLA { get; set; }
        public List<Ent_INFORME_OBLIGTITULAR> tbObligTitular { get; set; }
        public List<Ent_INFORME> tbDesplazamiento { get; set; }
        public string txtObservacion { get; set; }
        public string txtConclusion { get; set; }

        //TGS:27/08/2021
        public string ddlBuenDesempenioId { get; set; }
        public IEnumerable<VM_Cbo> ddlBuenDesempenio { get; set; }
        //TGS:25/09/2021
        public string ddlArchivaInformeId { get; set; }
        public IEnumerable<VM_Cbo> ddlArchivaInforme { get; set; }
        public List<Ent_MANDATOS> tbMandatos { get; set; }
        public List<Ent_MANDATOS> ListMandatos { get; set; }

        public VM_Informe_Tara()
        {
            vmControlCalidad = new VM_ControlCalidad_2();
            vmInfCNotificacion = new VM_Informe_CNotificacion();
            ddlOdId = "0000000";
            tbSupervisor = new List<Ent_GENEPERSONA>();
            vmDatoSupervision = new VM_Informe_DatoSuperv();
            ddlPlantonId = "0";
            tbTaraConcepto = new List<Ent_INFORME_TCONCEPTO>();
            tbManPlantacion = new List<Ent_INFORME_TCONCEPTO>();
            tbAprovechamiento = new List<Ent_INFORME>();
            tbCapacitacion = new List<Ent_INFORME>();
            tbProduccionFruto = new List<Ent_INFORME>();
            tbAprovechaForestal = new List<Ent_INFORME>();
            tbCenso = new List<Ent_INFORME_TCENSO>();
            tbKardex = new List<Ent_INFORME>();
            tbEliTABLA = new List<Ent_INFORME>();
            tbObligTitular = new List<Ent_INFORME_OBLIGTITULAR>();
            tbDesplazamiento = new List<Ent_INFORME>();
            ListMandatos = new List<Ent_MANDATOS>();
        }
    }

}