using CapaEntidad.DOC;
using System.Collections.Generic;

namespace CapaEntidad.ViewModel
{
    public class VM_InformeSuspension
    {
        public string lblTituloCabecera { get; set; }
        public string lblTituloEstado { get; set; }

        public VM_ControlCalidad_2 vmControlCalidad { get; set; }
        public VM_Informe_CNotificacion vmInfCNotificacion { get; set; }

        public string hdfCodInforme { get; set; }
        public int hdfRegEstado { get; set; }
        public bool chkPublicar { get; set; }
        public string txtNumInforme { get; set; }
        public string hdfCodNotificacion { get; set; }
        public string txtTHabilitante { get; set; }
        public string txtCNotificacion { get; set; }

        
        public IEnumerable<VM_Cbo> ddlOd { get; set; }
        public string ddlOdId { get; set; }

        public string codRequerimiento { get; set; }

        public IEnumerable<VM_Cbo> ddlMotivo { get; set; }
        public string ddlMotivoId { get; set; }

        public string txtFechaEmision { get; set; }
        public string txtFechaActa { get; set; }

        public string txtObservacion { get; set; }
        public string hdfEstadoOrigen { get; set; }
        public string txtIDOD { get; set; }
        public string txtIdMotivo { get; set; }
        public string hdfCodThabilitante { get; set; }
        
        public VM_Informe_DatoSuperv vmDatoSupervision { get; set; }
        public List<Ent_GENEPERSONA> tbSupervisor { get; set; }
        public List<Ent_ISUSPENSION> tbEliTABLA { get; set; }

        public List<Ent_ISUSPENSION> ListOD { get; set; }
        public List<Ent_ISUSPENSION> ListMotivo { get; set; }

        public VM_InformeSuspension()
        {
            vmControlCalidad = new VM_ControlCalidad_2();
            vmInfCNotificacion = new VM_Informe_CNotificacion();

            hdfRegEstado = 1;//Nuevo registro
            ddlOdId = "0000000";
            vmDatoSupervision = new VM_Informe_DatoSuperv();
            tbSupervisor = new List<Ent_GENEPERSONA>();


            tbEliTABLA = new List<Ent_ISUSPENSION>();
        }
    }
}
