using System.Collections.Generic;
using CEntidad = CapaEntidad.DOC.Ent_InformeAutoridadForestal;
using CEntidadPersona = CapaEntidad.DOC.Ent_GENEPERSONA;
namespace CapaEntidad.ViewModel
{
    public class VM_InformeAutoridadForestal
    {
        public string Titulo { get; set; }
        public string SubTitulo { get; set; }

        public string TipoFormulario { get; set; }
        public string TipoFormularioId { get; set; }
        public string hdfManRegEstado { get; set; }


        public VM_Cbo_Propiedad ddlItemIndicador { get; set; }
        public string ddlItemIndicadorId { get; set; }
        public bool chkItemObsSubsanada { get; set; }


        public string txtUsuarioRegistro { get; set; }
        public string txtUsuarioControl { get; set; }
        public bool chkPublicar { get; set; }
        public string txtControlCalidadObservaciones { get; set; }
        // Datos del Informe
        public string ddlODRegistroId { get; set; }
        public IEnumerable<VM_Cbo> ddlODRegistro { get; set; }
        public string ddlEntidadId { get; set; }
        public IEnumerable<VM_Cbo> ddlEntidad { get; set; }
        public string lblcampo_numero { get; set; }
        public string txtnum_informe { get; set; }

        public string ddlTipoInformeId { get; set; }
        public IEnumerable<VM_Cbo> ddlTipoInforme { get; set; }
        public string txtfecha_emision { get; set; }
        public string lblfecha_recepcion { get; set; }
        public string txtfecha_recepcion { get; set; }
        public string lblnum_Thabilitante { get; set; }
        public string lblnom_Titular { get; set; }

        public string txtMotivo_Renuncia { get; set; }
        public string txtNumDocumento_AutSolRenuncia { get; set; }
        public string txtFecha_DocAutRenuncia { get; set; }
        public string txtnum_poa { get; set; }


        public string txtconclusiones { get; set; }
        public string txtdocAdjuntos { get; set; }
        public string lblTituloObs { get; set; }
        public string txtObservacion { get; set; }
        public string hdfcod_informe { get; set; }
        public string hdfItemCod_THabilitante { get; set; }

        public IEnumerable<VM_Cbo> ddlItemPN_DITipo { get; set; }
        public IEnumerable<VM_Cbo> ddlespecialidad { get; set; }
        public IEnumerable<VM_Cbo> ddlprofesional { get; set; }
        public IEnumerable<VM_Cbo> ddlInjustEspecies { get; set; }

        public List<CEntidadPersona> ListProfesionales { get; set; }
        public List<CEntidad> ListVolInjustificado { get; set; }
        public List<CEntidad> ListEliTABLA { get; set; }
        public string TVentana { get; set; }
        public string rol { get; set; }
    }

}
