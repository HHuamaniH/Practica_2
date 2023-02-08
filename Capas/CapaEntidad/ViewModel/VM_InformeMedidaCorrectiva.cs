using CapaEntidad.DOC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad.ViewModel
{
    public class VM_InformeMedidaCorrectiva
    {
        public string lblTituloCabecera { get; set; }
        public string lblTituloEstado { get; set; }
        public VM_ControlCalidad_2 vmControlCalidad { get; set; }
        public string hdfCodInfMedidaCorrectiva { get; set; }
        public string hdfItemTInformeCodigo { get; set; }
        public string txtItemTInforme { get; set; }
        public string txtItemNumero { get; set; }
        public string txtItemMotivo { get; set; }
        public string hdfItemDirectorCodigo { get; set; }
        public string txtItemDirector { get; set; }
        public string txtItemFechaIni { get; set; }
        public string txtItemFechaFin { get; set; }
        public string txtItemFechaPresentaTitular { get; set; }
        public string txtItemFechaInstalacion { get; set; }
        public string txtItemConclusion { get; set; }
        public string txtItemRecomendacion { get; set; }

        public IEnumerable<VM_Cbo> ddlItemPresentaFechaPlazo { get; set; }
        public string ddlItemPresentaFechaPlazoId { get; set; }
        public IEnumerable<VM_Cbo> ddlItemInformeCompleto { get; set; }
        public string ddlItemInformeCompletoId { get; set; }
        public IEnumerable<VM_Cbo> ddlItemCuentaFirmaRegente { get; set; }
        public string ddlItemCuentaFirmaRegenteId { get; set; }
        public IEnumerable<VM_Cbo> ddlItemCumpleMCorrectiva { get; set; }
        public string ddlItemCumpleMCorrectivaId { get; set; }
        public IEnumerable<VM_Cbo> ddlItemRemitirDFFFS { get; set; }
        public string ddlItemRemitirDFFFSId { get; set; }
        public IEnumerable<VM_Cbo> ddlItemReponeDentro { get; set; }
        public string ddlItemReponeDentroId { get; set; }
        public IEnumerable<VM_Cbo> ddlItemReponeFuera { get; set; }
        public string ddlItemReponeFueraId { get; set; }
        public IEnumerable<VM_Cbo> ddlItemCumpleCantidadRepone { get; set; }
        public string ddlItemCumpleCantidadReponeId { get; set; }
        /*public IEnumerable<VM_Cbo> ddlItemEspecieRef { get; set; }
        public string ddlItemEspecieRefId { get; set; }*/

        public int RegEstado { get; set; }
        public string hdfCodigoInfMedidaCorrectivaAlerta { get; set; }
        public string txtTituloModal { get; set; }

        public List<Ent_IMEDIDA_RESPONSABLE> tbResponsable { get; set; }
        public List<Ent_IMEDIDA_EXPEDIENTE> tbExpediente { get; set; }
        public List<Ent_IMEDIDA_EXP_MEDIDA> tbMedida { get; set; }
        public List<Ent_IMEDIDA_EXP_MEDIDA> tbMedidaAsociada { get; set; }
        public List<Ent_IMEDIDA_ESPECIE> tbEspecie { get; set; }
        public List<Ent_IMEDIDA_VERTICE> tbVertice { get; set; }
        public List<Ent_SBusqueda> sBusqueda { get; set; }
        public List<Ent_IMEDIDA_EliTABLA> tbEliTABLA { get; set; }
        public List<Ent_IMEDIDA_EliTABLA> tbElimResponsable { get; set; }
        public List<Ent_IMEDIDA_EliTABLA> tbElimExpediente { get; set; }
        public List<Ent_IMEDIDA_EliTABLA> tbElimEspecie { get; set; }
        public List<Ent_IMEDIDA_EliTABLA> tbElimVertice { get; set; }
    }
}
