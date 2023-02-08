using CapaEntidad.DOC;
using System;
using System.Collections.Generic;
namespace CapaEntidad.ViewModel
{
    public class VM_PlanManejoGeneral
    {
        public string lblTituloCabecera { get; set; }
        public string lblTituloEstado { get; set; }
        public string hdfManCOD_PGMF { get; set; }
        public string hdfManRegEstado { get; set; }
        public IEnumerable<VM_Cbo> ddlItemIndicador { get; set; }
        public string ddlItemIndicadorId { get; set; }
        public bool OBSERV_SUBSANAR { get; set; }
        public bool ddlItemIndicadorEnable { get; set; }
        public string txtControlCalidadObservaciones { get; set; }
        public string txtUsuarioRegistro { get; set; }
        public string txtUsuarioControl { get; set; }
        public IEnumerable<VM_Cbo> ddlODRegistro { get; set; }
        public string ddlODRegistroId { get; set; }
        public string txtNumInfAprob { get; set; }
        public string txtCHKEDITOR { get; set; }
        public string txtFechaAprobacionInf { get; set; }
        public string txtProfesionalRecomendo { get; set; }
        public string hdtxtProfesionalRecomendo { get; set; }
        public string txtConsultorElaboro { get; set; }
        public string hdtxtConsultorElaboro { get; set; }
        public string txtNumAFFS { get; set; }
        public string txtNumCIP { get; set; }
        //datos generales
        public string txtNumResolucion { get; set; }
        public string txtFechaAprobacion { get; set; }
        public string txtFuncionarioFirma { get; set; }
        public string hdtxtFuncionarioFirma { get; set; }
        public bool chckprimerQuinquenio { get; set; }
        public bool chckSegundoQuinquenio { get; set; }
        public bool chckTercerQuinquenio { get; set; }
        public bool chckCuartoQuinquenio { get; set; }

        public string txtBloques { get; set; }
        public string txtAreaPGMF { get; set; }
        public string txtPeriodo { get; set; }
        public string txtFechaIncioPeriodo { get; set; }
        public string txtFechaTerminoPeriodo { get; set; }
        public string rol { get; set; }
        //especies aprobadas

        //tablas
        public List<Ent_PLAN_MANEJO> ListEliTABLA { get; set; }
        public List<Ent_PLAN_MANEJO> ListEspecies { get; set; }
        public List<Ent_PLAN_MANEJO> ListCoordenadas { get; set; }
        public List<Ent_PLAN_MANEJO> ListEspeciesFauna { get; set; }
        public List<Ent_PLAN_MANEJO> ListTHabilitante { get; set; }

        public string tituloInformeRecomendacion { get; set; }
        public string tituloDatosGenerales { get; set; }
        public bool chckConsolidad { get; set; }
        public string txtNomConsolidad { get; set; }
        public string txtObservacion { get; set; }
        public int esPMFI { get; set; }
        public string codTipoPlan { get; set; }
        public List<VM_Cbo> ddlDependencia { get; set; }
        public string ddlDependenciaId { get; set; }

        //
        public string appClient { get; set; }
        public string appData { get; set; }
        public Int16 opRegresar { get; set; }
    }
    public class VM_ESPECIE_APROBADAS
    {
        public IEnumerable<VM_Cbo> cbespeciesinipauforest { get; set; }
        public string cbespeciesinipauforestId { get; set; }
        public IEnumerable<VM_Cbo> dlBloque { get; set; }
        public string dlBloqueId { get; set; }
        public string txtNumArb { get; set; }
        public string txtVolumen { get; set; }
        public int esPMFI { get; set; }
    }
    public class VM_ESPECIE_FS
    {
        public IEnumerable<VM_Cbo> dplEspecieFauna { get; set; }
        public string dplEspecieFaunaId { get; set; }
        public IEnumerable<VM_Cbo> dplGradoAmenazaEspecie { get; set; }
        public string dplGradoAmenazaEspecieId { get; set; }
        public string txtObservaFauna { get; set; }
    }
}
