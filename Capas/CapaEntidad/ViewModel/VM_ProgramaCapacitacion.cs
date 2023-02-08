using System.Collections.Generic;

namespace CapaEntidad.ViewModel
{
    public class VM_ProgramaCapacitacion
    {
        public string lblTituloCabecera { get; set; }
        public string lblTituloEstado { get; set; }

        public string hdfCodPCapacitacion { get; set; }
        public string txtNomPCapacitacion { get; set; }
        public IEnumerable<VM_Cbo> ddlTipPCapacitacion { get; set; }
        public string ddlTipPCapacitacionId { get; set; }
        public IEnumerable<VM_Cbo> ddlSumMetPoi { get; set; }
        public string ddlSumMetPoiId { get; set; }
        public IEnumerable<VM_Cbo> ddlOd { get; set; }
        public string ddlOdId { get; set; }
        public string txtFecInicio { get; set; }
        public string txtDirigido { get; set; }
        public IEnumerable<VM_Cbo> ddlEntFinancia { get; set; }
        public string ddlEntFinanciaId { get; set; }
        public string txtFueCooperante { get; set; }
        public string lblUbigeo { get; set; }
        public string hdfUbigeo { get; set; }
        public string txtLugar { get; set; }
        public bool chkMarConvenio { get; set; }
        public int hdfRegEstado { get; set; }
        public IEnumerable<VM_Cbo> ddlConvenio { get; set; }
        public string ddlConvenioId { get; set; }

        public VM_ProgramaCapacitacion()
        {
            List<VM_Cbo> lstSumMetPoi = new List<VM_Cbo>();
            VM_Cbo opt = new VM_Cbo() { Selected = true, Value = "0000000", Text = "Seleccionar" }; lstSumMetPoi.Add(opt);
            opt = new VM_Cbo() { Selected = false, Value = "1", Text = "SI" }; lstSumMetPoi.Add(opt);
            opt = new VM_Cbo() { Selected = false, Value = "0", Text = "NO" }; lstSumMetPoi.Add(opt);
            this.ddlSumMetPoi = lstSumMetPoi;

            this.ddlTipPCapacitacionId = "0000000";
            this.ddlOdId = "0000000";
            this.ddlSumMetPoiId = "0000000";
            this.ddlEntFinanciaId = "0000000";
            this.chkMarConvenio = false;
            this.hdfRegEstado = 1;//Nuevo registro
        }
    }
}
