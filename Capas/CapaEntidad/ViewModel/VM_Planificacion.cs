using System.Collections.Generic;

namespace CapaEntidad.ViewModel
{
    public class VM_Plan
    {
        public string lblTituloCabecera { get; set; }
        public string lblTituloEstado { get; set; }
        public string hdfCodPlan { get; set; }
        public int txtAnioPlan { get; set; }
        public string txtFechaCorte { get; set; }
        public string txtNumResolucion { get; set; }
        public string txtFechaEmision { get; set; }
        public string hdfCodFuncionario { get; set; }
        public string txtFuncionario { get; set; }
        public string txtObservacion { get; set; }

        public VM_ControlCalidad_2 vmControlCalidad { get; set; }

        public VM_Plan()
        {
            vmControlCalidad = new VM_ControlCalidad_2();
        }
    }

    public class VM_PlanUniverso
    {
        public string lblTituloCabecera { get; set; }
        public string lblTituloEstado { get; set; }
        public string hdfCodPlan { get; set; }
        public int txtAnioPlan { get; set; }
        public string txtFechaCorte { get; set; }
        public string txtHoraCorte { get; set; }
        public bool hdfPlanCompleto { get; set; }
    }

    public class VM_PlanCriterio
    {
        public string lblTituloCabecera { get; set; }
        public string lblTituloEstado { get; set; }
        public string hdfCodCriterio { get; set; }
        public string hdfCodPlan { get; set; }
        public string ddlTipoCriterioId { get; set; }
        public IEnumerable<VM_Cbo> ddlTipoCriterio { get; set; }
        public string txtCodigo { get; set; }
        public string txtCriterio { get; set; }
        public string ddlTipoAplicacionId { get; set; }
        public IEnumerable<VM_Cbo> ddlTipoAplicacion { get; set; }
        public string ddlColumnaId { get; set; }
        public IEnumerable<VM_Cbo> ddlColumna { get; set; }
        public string txtDescripcion { get; set; }
        public bool hdfActivo { get; set; }

        public VM_PlanCriterio()
        {
            ddlTipoCriterioId = "0000000";
            ddlTipoAplicacionId = "0000000";
            ddlColumnaId = "0000000";
            hdfActivo = false;
        }
    }

    public class VM_PlanCriterioValor
    {
        public string hdfCodPCriterio { get; set; }
        public int hdfCodSecuencial { get; set; }
        public string txtOpcionTexto_1 { get; set; }
        public decimal txtOpcionNumero_1 { get; set; }
        public decimal txtOpcionNumero_2 { get; set; }
        public string txtOpcionFecha_1 { get; set; }
        public string txtOpcionFecha_2 { get; set; }
        public decimal txtValor { get; set; }
        public decimal txtRiesgo { get; set; }
        public IEnumerable<VM_Cbo> ddlOpcionTexto_1 { get; set; }
        public IEnumerable<VM_Cbo> ddlValorRiesgo { get; set; }
        public string hdfCodTAplicacion { get; set; }
        public string hdfCodPColumna { get; set; }
        public string hdfTipoDato { get; set; }
    }

    public class VM_PlanCasuistica
    {
        public string hdfCodCasuistica { get; set; }
        public string hdfCodPlan { get; set; }
        public string txtCasuistica { get; set; }
        public string ddlTipoCriterioId { get; set; }
        public IEnumerable<VM_Cbo> ddlTipoCriterio { get; set; }
        public string txtDescripcion { get; set; }
        public string txtDescripcionFiltro { get; set; }
    }

    public class VM_PlanCasuisticaUniverso
    {
        public string hdfCodPCasuistica { get; set; }
        public string hdfCodPlan { get; set; }
        public int hdfCodSecuencial { get; set; }
        public bool hdfObservar { get; set; }
        public string txtObservacion { get; set; }
        public string txtUsuario { get; set; }
        public bool chkRevisar { get; set; }
        public string txtRevision { get; set; }
        public string hdfTipo { get; set; }
    }
}
