using CapaEntidad.DOC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad.ViewModel
{
    public class VM_InformacionTitular
    {
        public string lblTituloCabecera { get; set; }
        public string lblTituloEstado { get; set; }
        public VM_ControlCalidad_2 vmControlCalidad { get; set; }
        public string hdfCodInfTitular { get; set; }
        public string hdfCodTipoInfTitular { get; set; }
        public string txtTipoInfTitular { get; set; }
        public string hdfItemTprofesionalCodigo { get; set; }
        public string txtItemTprofesional { get; set; }
        public string txtItemEtiNContrato { get; set; }
        public string txtFechaEmision { get; set; }
        public string txtFechaPresentacion { get; set; }

        public IEnumerable<VM_Cbo> ddlOd { get; set; }
        public string ddlOdId { get; set; }
        public IEnumerable<VM_Cbo> ddlTipoProfesional { get; set; }
        public string ddlTipoProfesionalId { get; set; }
        public IEnumerable<VM_Cbo> ddlTitular { get; set; }
        public string ddlTitularId { get; set; }
        public IEnumerable<VM_Cbo> ddlDescargoTipo { get; set; }
        public string ddlDescargoTipoId { get; set; }

        public bool chkApelarMedCaut { get; set; }
        public string hdfItemOtraPersonafirma { get; set; }
        public string txtItemOtraPersonafirma { get; set; }
        public string txtItemEstUbigeoLugarpresentacion { get; set; }
        public string hdfItemEstUbigeoLugarpresentacion { get; set; }
        public string txtDomicilioProcesal { get; set; }
        public string txtItemEstUbigeo { get; set; }
        public string hdfItemEstUbigeoCodigo { get; set; }
        public string txtDireccion { get; set; }
        public string txttelefono { get; set; }
        public string txtcorreo { get; set; }
        public bool chkfirmaLegalizada { get; set; }
        public bool chkAudienciaOral { get; set; }
        public string txtrecursoapelacion { get; set; }
        public bool chkNulidad_RecApe { get; set; }
        public string txtObservNul_RecApe { get; set; }
        public string txtfunpresentadoscautelar { get; set; }
        public bool chkEmitioCarta { get; set; }
        public string txtNroCarta { get; set; }
        public string txtFechaCarta { get; set; }
        public string txtdescripciondescargo { get; set; }
        public string txtrecursorecon { get; set; }
        public string txtampliaciondescargo { get; set; }
        public string txtsolicitudfInfo { get; set; }
        public string txtObservMedidaCorrect { get; set; }
        public string txtotros { get; set; }
        public string txtFundQueja_Queja { get; set; }
        public string txtObservActividad { get; set; }
        public string txtMotivoDesistimiento { get; set; }
        public string txtnumcuotas { get; set; }
        public string txtmontocuota { get; set; }
        public string txtfecinipago { get; set; }
        public string txtfecfinpago { get; set; }
        public string txtfundamentosaudiencia { get; set; }
        public string txtinspeccionoc { get; set; }
        public string txtObservaciones { get; set; }
        public string txtItemNewUbigeoTH { get; set; }
        public string hdfItemNewUbigeoTHCodigo { get; set; }
        public string txtNewDireccionTH { get; set; }
        public string txtNewReferenciaTH { get; set; }
        public string txtObservSubsanacion { get; set; }


        public int RegEstado { get; set; }
        public string hdfCodigoInfTitularAlerta { get; set; }
        public string txtTituloDocumento { get; set; }
        public string lbldocumento { get; set; }
        public string txtTituloModal { get; set; }

        public List<Ent_INFTIT> tbInforme { get; set; }
        public List<Ent_INFTIT> tbPersonaFirma { get; set; }
        public List<Ent_SBusqueda> sBusqueda { get; set; }
        public List<Ent_INFTIT> tbEliTABLA { get; set; }
        public List<Ent_INFTIT> tbEliminaInforme { get; set; }
        public List<Ent_INFTIT> tbEliminaPersona { get; set; }
    }
}
