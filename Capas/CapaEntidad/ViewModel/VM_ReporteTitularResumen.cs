using System.Collections.Generic;

namespace CapaEntidad.ViewModel
{
    public class VM_ReporteTitularResumen
    {
        public IEnumerable<VM_Chk> lstChkUbicacion { get; set; }
        public string lstChkUbicacionId { get; set; }
        public IEnumerable<VM_Chk> lstChkDepartamento { get; set; }
        public string lstChkDepartamentoId { get; set; }
        public IEnumerable<VM_Chk> lstChkDLinea { get; set; }
        public string lstChkDLineaId { get; set; }
        public IEnumerable<VM_Chk> lstChkModalidad { get; set; }
        public string lstChkModalidadId { get; set; }
        public IEnumerable<VM_Chk> lstChkAnioSuperv { get; set; }
        public string lstChkAnioSupervId { get; set; }
        public IEnumerable<VM_Chk> lstChkAnioRDTermino { get; set; }
        public string lstChkAnioRDTerminoId { get; set; }
        public IEnumerable<VM_Chk> lstChkMesRDTermino { get; set; }
        public string lstChkMesRDTerminoId { get; set; }
        public IEnumerable<VM_Chk> lstChkAnioProveido { get; set; }
        public string lstChkAnioProveidoId { get; set; }
        public IEnumerable<VM_Chk> lstChkAnioFirmeza { get; set; }
        public string lstChkAnioFirmezaId { get; set; }
        public IEnumerable<VM_Cbo> ddlFiltroAdicional { get; set; }
        public string ddlFiltroAdiconalId { get; set; }
        public string txtValorFiltro { get; set; }
        public bool chkMulta { get; set; }

        public VM_ReporteTitularResumen()
        {
            lstChkUbicacionId = "";
            lstChkDepartamentoId = "";
            lstChkDLineaId = "";
            lstChkModalidadId = "";
            lstChkAnioSupervId = "";
            lstChkAnioRDTerminoId = "";
            lstChkMesRDTerminoId = "";
            lstChkAnioProveidoId = "";
            lstChkAnioFirmezaId = "";
            ddlFiltroAdiconalId = "";
            txtValorFiltro = "";
            chkMulta = false;
        }
    }
}
