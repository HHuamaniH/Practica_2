using System.Collections.Generic;

namespace CapaEntidad.ViewModel.DOC
{
    public class VM_Transferir
    {
        public string ItemCodAnteExpSitd { get; set; }
        public string ItemDocReferencia { get; set; }
        public string ItemCodTHabilitante { get; set; }
        public string ItemNumTHabilitante { get; set; }
        public List<VM_Cbo> cboModalidadTrans { get; set; }
        public string cboModalidadTransId { get; set; }
        public List<VM_Cbo> ddlItemPoaPadre { get; set; }
        public string ddlItemPoaPadreId { get; set; }
        public string ItemResolActoAdmin { get; set; }
        public string ItemActoAdmin { get; set; }
        public string ItemNombrePoa { get; set; }
        public string ItemNumPoa { get; set; }
        public string ItemResolucionPoa { get; set; }
        public string txtItemFecEmiBExtraccion { get; set; }
        public string txtItemObservacionTransferir { get; set; }
        public bool pnlItemTHabilitanteTransferir { get; set; }
        public bool pnlItemPlanManejo { get; set; }
        public bool pnlItemMsjTHTransferir { get; set; }
        public bool pnlItemPlanManejoDetalle { get; set; }
        public bool pnlItemPlanManejoPadreEnabled { get; set; }
        public bool pnlItemPlanManejoPadre { get; set; }
        public bool pnlItemMsjPoaTransferir { get; set; }
        public bool pnlItemPlanManejoTransferir { get; set; }
        public bool pnlItemActoAdministrativo { get; set; }
        public bool pnlItemMsjActoAdminTransferir { get; set; }
        public bool pnlItemActoAdminTransferir { get; set; }
        public bool pnlItemBExtraccion { get; set; }
        public bool pnlItemBExtraccionTransferir { get; set; }
        public bool pnlItemAdendaTransferir { get; set; }
        public bool EXISTE_TH { get; set; }
        public string COD_PGMF { get; set; }
        public string COD_PMANEJO { get; set; }
        public bool EXISTE_PGMF { get; set; }
        public bool EXISTE_PM { get; set; }
        public bool EXISTE_POA { get; set; }
        public string COD_DREFERENCIA { get; set; }
        public string COD_AEXPEDIENTE_SITD { get; set; }
        public string COD_TRAMITE_SITD { get; set; }
        public string tipo { get; set; }
        public string subtipo { get; set; }
    }
}
