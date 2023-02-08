using CapaEntidad.DOC;
using System.Collections.Generic;

namespace CapaEntidad.ViewModel
{
    public class VM_InformeFundamentado
    {
        public string lblTituloCabecera { get; set; }
        public string lblTituloEstado { get; set; }
        public VM_ControlCalidad_2 vmControlCalidad { get; set; }
        public string hdfCodInfFundamentado { get; set; }
        public string hdfCodTipoInfFundamentado { get; set; }
        public string txtTipoInfFundamentado { get; set; }
        public string txtNumInfFundamentado { get; set; }
        public string txtFechaFundamentado { get; set; }

        public IEnumerable<VM_Cbo> ddlOd { get; set; }
        public string ddlOdId { get; set; }
        public IEnumerable<VM_Cbo> ddlEntidad { get; set; }
        public string ddlEntidadId { get; set; }
        public IEnumerable<VM_Cbo> ddlSubEntidad { get; set; }
        public string ddlSubEntidadId { get; set; }

        public string txtConclusiones { get; set; }
        public string txtObservaciones { get; set; }
        public string txtTituloModal { get; set; }

        public int RegEstado { get; set; }
        public string hdfCodigoInfFundamentadoAlerta { get; set; }

        public List<Ent_INFFUN> tbInforme { get; set; }
        public List<Ent_SBusqueda> sBusqueda { get; set; }
        public List<Ent_INFFUN> listaProfesionales { get; set; }
        public List<Ent_INFFUN> listaEntidades { get; set; }
        public List<Ent_INFFUN> tbEliTABLA { get; set; }
    }
}
