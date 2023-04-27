using CapaEntidad.DOC;
using System;
using System.Collections.Generic;
namespace CapaEntidad.ViewModel
{
    public class VM_POA
    {
        public string ItemTitulo { get; set; }
        public string hdfPostBackTemp { get; set; }
        public string hdfManRegEstado { get; set; }
        public string hdfTabsId01 { get; set; }
        public string TipoFormulario { get; set; }
        public string hdfAppClient { get; set; }
        public string hdfAppData { get; set; }
        public IEnumerable<VM_Cbo> ddlItemIndicador { get; set; }
        public string ddlItemIndicadorId { get; set; }
        public bool chkItemObsSubsanada { get; set; }
        public string txtControlCalidadObservaciones { get; set; }
        public string txtUsuarioRegistro { get; set; }
        public string txtUsuarioControl { get; set; }

        public string lblItemTHModalidad { get; set; }
        public string hdfItemCod_THabilitante { get; set; }
        public string hdfItemNum_POAPadre { get; set; }
        public string hdfItemIndicador { get; set; }
        public string hdfItemCod_MTipo { get; set; }
        public string hdfItemEstadoOrigen { get; set; }

        public string lblItemTHNumero { get; set; }
        public string lblItemTHTitular { get; set; }

        public IEnumerable<VM_Cbo> ddlODRegistro { get; set; }
        public string ddlODRegistroId { get; set; }
        public string txtNombrePOA { get; set; }
        public string txtItemNumPOA { get; set; }
        public bool chkNPNumPOA { get; set; }
        public bool chkPOAPO { get; set; }

        public string txtItemNumPComplementario { get; set; }
        public string txtItemArea { get; set; }
        public string txtItemPca { get; set; }
        public string txtItemZafra_Pca { get; set; }


        public string txtItemInicio_Vigencia { get; set; }
        public string txtItemFin_Vigencia { get; set; }

        //Consultor regente
        public string hdfItemConsultorCodigo { get; set; }
        public string lblItemConsultorNombre { get; set; }
        public string lblItemConsultorDNI { get; set; }
        public string txtItemNRConsultor { get; set; }
        public string txtItemNRRegente { get; set; }
        public string lblItemConsultorNRProfesional { get; set; }
        public string txtItemNRNroLicencia { get; set; }
        public string txtItemNREmail { get; set; }
        public string txtCodUbigeo { get; set; }
        public string txtUbigeo { get; set; }
        public string txtDirecion { get; set; }

        //Acta de Inspeccion Ocular

        public bool chckSinInspOcu { get; set; }
        public string txtItemacta_Iocular_Num { get; set; }
        public string txtItemActa_Iocular_Fe { get; set; }

        public List<Ent_POA> ListAOCULAR { get; set; }
        //Informe Tecnico de inspeccion ocular
        public string txtItemItecnico_Iocular_Num { get; set; }
        public string txtItemItecnico_Iocular_Fecha { get; set; }
        public List<Ent_POA> ListTIOCULAR { get; set; }

        //Informe Técnico que Recomienda la Aprobación del PO
        public string lbltextrecoaprob { get; set; }
        public string txtItemItecnico_Raprobacion_Num { get; set; }
        public string txtItemItecnico_Raprobacion_Fecha { get; set; }
        public List<Ent_POA> ListTRAPROBACION { get; set; }
        public List<Ent_POA> ListMadeCENSO { get; set; }
        public List<Ent_POA> ListNoMadeCENSO { get; set; }
        public List<Ent_POA> ListEliTABLA { get; set; }

        //Resolución que Aprueba el POA
        public string lbltextapru { get; set; }
        public string txtItemAresolucion_Num { get; set; }
        public string txtItemAresolucion_Fecha { get; set; }
        public string hdfItemARFuncionarioCodigo { get; set; }
        public string lblItemARFuncionario { get; set; }
        public string lblItemARFuncionarioODatos { get; set; }

        //Especies Aprobadas de la Resolución de Aprobación del POA
        public string lbltextEspeciesApru { get; set; }
        public List<Ent_POA> ListRAprueba { get; set; }
        public List<Ent_POA> ListRApruebaISitu { get; set; }

        //Datos Adicionales
        //pnlISituDGenerales
        public string txtItemTmetodo_Epoblacional { get; set; }
        public string txtItemManejo_Habitat { get; set; }
        public List<Ent_POA> ListACTIVIDADES_AMBIENTALES { get; set; }
        public string txtItemComercio { get; set; }
        public List<Ent_POA> ListBIOSEGURIDAD { get; set; }

        public string txtItemControl_Impacto { get; set; }
        public string txtItemInvestigacion { get; set; }
        public string txtItemCapacitacion { get; set; }
        //Balance de Extracción del POA
        public string txtItemFEmisionBExtracion { get; set; }
        public string hdfItemBExtPOA_Index { get; set; }
        public string hdfItemBExtPOA_RegEstado { get; set; }
        public string hdfSelectBExtPOA_Index { get; set; }

        public List<Ent_POA> ListBExtPOA { get; set; }

        //BALANCE DE EXTRACCIÓN MADERABLE - NO MADERABLE
        public List<Ent_POA> ListMadeBEXTRACCION { get; set; }
        public List<Ent_POA> ListNoMadeBEXTRACCION { get; set; }
        //Balance de Extracción I Situ
        public List<Ent_POA> ListISituBEXTRACCION { get; set; }
        public List<Ent_POA> ListKARDEX { get; set; }
        public List<Ent_POA> ListVERTICE { get; set; }

        public bool chkItemCuentaFinZafra { get; set; }
        public string txtItemObservacion { get; set; }
        public string ltrItemEtiNPoa { get; set; }
        public bool ddlItemIndicadorEnable { get; set; }

        public string lbtMaderableItemCensoSelec { get; set; }
        public string lbtNoMaderableItemCensoSelec { get; set; }
        public IEnumerable<VM_Cbo> ddlItemRAPoaEspecies { get; set; }
        public string ddlItemRAPoaEspeciesId { get; set; }
        public IEnumerable<VM_Cbo> ddlItemRAPoaEspecies_Serfor { get; set; }
        public string ddlItemRAPoaEspecies_SerforId { get; set; }
        public IEnumerable<VM_Cbo> ddlUnMed { get; set; }
        public IEnumerable<VM_Cbo> ddlTipoMaderables_RAprob { get; set; }


        public IEnumerable<VM_Cbo> ddlItemCMaderableCod_Econdicion { get; set; }
        public IEnumerable<VM_Cbo> ddlItemCNoMaderableCod_Econdicion { get; set; }
        public IEnumerable<VM_Cbo> ddlItemCMaderableCod_Eestado { get; set; }
        public string lbtn_listadoPOACensoMaderable { get; set; }
        public string lbtn_listadoPOACensoNoMaderable { get; set; }

        public bool hdELIM_TOTAL_CENSO { get; set; }
        public string hdfNumPoa { get; set; }
        public IEnumerable<VM_Cbo> ddlItemkeardexProducto { get; set; }
        public IEnumerable<VM_Cbo> ddlItemkeardexDescripcion { get; set; }
        public string TVentana { get; set; }

        public IEnumerable<VM_Cbo> ddlDependencia { get; set; }
        public string ddlDependenciaId { get; set; }
        public string lblItemRepresentanteLegal { get; set; }
        //Acervo documentario
        public string txtActaNro { get; set; }
        public string txtFechaAcervo { get; set; }
        public string hdEspAcervo { get; set; }
        public string lbEspecialistaAcervo { get; set; }

        public IEnumerable<VM_Chk> lstChkDETitulo { get; set; }
        public string lstChkDETituloId { get; set; }

        public IEnumerable<VM_Chk> lstDEResoluciones { get; set; }
        public string lstDEResolucionesId { get; set; }

        public IEnumerable<VM_Chk> lstDEDocumentoGestion { get; set; }
        public string lstDEDocumentoGestionId { get; set; }

        public IEnumerable<VM_Chk> lstDEObligaciones { get; set; }
        public string lstDEObligacionesId { get; set; }

        public IEnumerable<VM_Chk> lstDEEjecucion { get; set; }
        public string lstDEEjecucionId { get; set; }

        public IEnumerable<VM_Chk> lstDEOtros { get; set; }
        public string lstDEOtrosId { get; set; }


        public bool chkIncluyeCD { get; set; }
        public string txtNroTomos { get; set; }
        public string txtNroFolios { get; set; }

        public bool chkConcluido { get; set; }
        public bool chkProceso { get; set; }
        public bool chkPendiente { get; set; }
        public string txtObservacionesAcervo { get; set; }

        public string appClient { get; set; }
        public string appData { get; set; }
        public Int16 opRegresar { get; set; }
        //05/05/2021
        public List<Ent_POA> ListParcela { get; set; }
        public List<Ent_POA> ListEliTABLAParcela { get; set; }
        public string rol { get; set; }

        //Error Material
        public List<Ent_ERRORMATERIAL> ListPOAErrorMaterialG { get; set; }
        public List<Ent_ERRORMATERIAL> ListPOAErrorMaterialA { get; set; }
        public List<Ent_ERRORMATERIAL> ListPOARegenteImplementa { get; set; }
    }

}
