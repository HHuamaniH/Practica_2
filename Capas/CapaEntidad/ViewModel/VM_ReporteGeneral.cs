using CapaEntidad.DOC;
using System.Collections.Generic;

namespace CapaEntidad.ViewModel
{
    public class VM_ReporteGeneral
    {
        public string lblTituloCabecera { get; set; }
        public string hdfTipoReporte { get; set; }
        public string txtFechaCorte { get; set; }
        public IEnumerable<VM_Chk> lstChkAnio { get; set; }
        public string lstChkAnioId { get; set; }
        public IEnumerable<VM_Chk> lstChkMes { get; set; }
        public string lstChkMesId { get; set; }
        public IEnumerable<VM_Chk> lstChkOd { get; set; }
        public string lstChkOdId { get; set; }
        public IEnumerable<VM_Chk> lstChkTipoInforme { get; set; }
        public string lstChkTipoInformeId { get; set; }
        public IEnumerable<VM_Chk> lstChkModalidad { get; set; }
        public string lstChkModalidadId { get; set; }
        public IEnumerable<VM_Chk> lstChkDepartamento { get; set; }
        public string lstChkDepartamentoId { get; set; }
        public IEnumerable<VM_Chk> lstChkDLinea { get; set; }
        public string lstChkDLineaId { get; set; }
        public IEnumerable<VM_Chk> lstChkTipoDocumentoSigo { get; set; }
        public string lstChkTipoDocumentoSigoId { get; set; }
        public IEnumerable<VM_Chk> lstChkEstadoDocumento { get; set; }
        public string lstChkEstadoDocumentoId { get; set; }
        public IEnumerable<VM_Chk> lstChkTipoResolucionFiscalizacion { get; set; }
        public string lstChkTipoResolucionFiscalizacionId { get; set; }
        public List<CapaEntidad.DOC.Ent_ControlCalidad> listTipoDocumento { get; set; }
        public List<CapaEntidad.DOC.Ent_ControlCalidad> listDireccionLinea { get; set; }
        public List<CapaEntidad.DOC.Ent_ControlCalidad> listDepartamento { get; set; }
        public List<Ent_Reporte_ProduccionXDigitadores> listProduccionU { get; set; }
        public List<Ent_Reporte_ProduccionXDigitadores> listProduccionUDetalle { get; set; }
        public List<Ent_REPORTE_SUPERVISION_GENERAL> listSupModResumen { get; set; }
        public List<Ent_REPORTE_SUPERVISION_GENERAL> listSupModDetalle { get; set; }
        public List<Ent_REPORTE_FISCALIZACION> listResumenEL { get; set; }
        public List<Ent_REPORTE_FISCALIZACION> listDetalleEL1 { get; set; }
        public List<Ent_REPORTE_FISCALIZACION> listDetalleEL2 { get; set; }
        public List<Ent_Reporte_PAU_CONCLUIDO> listPauConcluido { get; set; }
        public List<Ent_Reporte_ProduccionXDigitadores> listProduccionEL { get; set; }
        public List<Ent_MasterFiltro> listDireccionLineaSupervision { get; set; }
        public List<Ent_MasterFiltro> listDireccionLineaFiscalizacion { get; set; }
        public List<Ent_MasterFiltro> listDepartamentoPAU { get; set; }
        public List<Ent_MasterFiltro> listModalidadPAU { get; set; }
        public List<List<Ent_Reporte_PAU_CONCLUIDO>> listTotalModalidadPAU { get; set; }
        public string txtPersona { get; set; }
        public string txtIdTipo { get; set; }
        public string tipoReporte { get; set; }
        public string tituloReporteDetalle { get; set; }
        public string tituloReporte { get; set; }
        public string subTEvaluacion { get; set; }
        public string subTInstructiva { get; set; }
        public string subTReconsideracion { get; set; }
        public string subTOtros { get; set; }
        public string subTFinal { get; set; }
        public string subT01 { get; set; }
        public string subT02 { get; set; }
        public string subT03 { get; set; }
        public string subT04 { get; set; }
        public string subT05 { get; set; }
        public string subT06 { get; set; }
        public string subT07 { get; set; }
        public string subT08 { get; set; }
        public string subT09 { get; set; }
        public string subT10 { get; set; }
        public string subT11 { get; set; }
        public string subT12 { get; set; }
        public string subT13 { get; set; }
        public VM_ReporteGeneral()
        {
            txtFechaCorte = "";
            lstChkAnioId = "";
            lstChkTipoInformeId = "";
            lstChkOdId = "";
            lstChkModalidadId = "";
            lstChkDepartamentoId = "";
            lstChkDLineaId = "";
            lstChkTipoDocumentoSigoId = "";
            lstChkEstadoDocumentoId = "";
            lstChkTipoResolucionFiscalizacionId = "";
        }
    }
}
