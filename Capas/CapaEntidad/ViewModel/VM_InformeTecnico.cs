using CapaEntidad.DOC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad.ViewModel
{
    public class VM_InformeTecnico
    {
        public string txtRecomendacion { get; set; }

        public string lblTituloCabecera { get; set; }
        public VM_ControlCalidad_2 vmControlCalidad { get; set; }
        public string hdfCodigoInfTec { get; set; }
        public int RegEstado { get; set; }
        public string hdfCodFCTipo { get; set; }
        public string txtNumInforme { get; set; }
        public string hdfCodPersona { get; set; }
        public string txtPersona { get; set; }
        public string txtTipoFisca { get; set; }
        public string txtFechaEmision { get; set; }
        public string txtDescripMulta { get; set; }
        public string txtDescripMultaAnt { get; set; }
        public string txtDescripInforme { get; set; }
        public decimal txtMultaRecomendSol { get; set; }
        public decimal txtMultaRecomendUIt { get; set; }
        public string txtMotivMulta { get; set; }
        public string txtInfAclaracion { get; set; }
        public string txtDocumentosAdj { get; set; }
        public string txtConclusion { get; set; }
        public string txtInfComplemento { get; set; }
        public string txtReferencia { get; set; }
        public string txtFechaInicio { get; set; }
        public string txtFechaFin { get; set; }
        public string txtPrincipalesResultados { get; set; }
        public string txtComentarios { get; set; }
        public string txtIdCodOD { get; set; }
        public string txtNumInfAct { get; set; }
        public string txtConclusionAct { get; set; }
        public string txtRecomendacionAct { get; set; }
        public string txtConclusionR { get; set; }
        public bool chkCambiaVol { get; set; }
        public bool chkCambiaEstado { get; set; }

        public List<Ent_INFTEC> listEliTabla { get; set; }
        public List<Ent_INFTEC> listEliTablaED { get; set; }
        public List<Ent_INFTEC> listEliTablaVolumen { get; set; }
        public List<Ent_INFTEC> listEliTablaMulta { get; set; }

        public string txtObservacion { get; set; }

        public List<Ent_INFTEC> ListInformes { get; set; }
        public List<Ent_INFTEC> Listarmultaantiguo { get; set; }
        public List<Ent_INFTEC> Listarmulta { get; set; }
        public List<Ent_INFTEC> Listardetdescargo { get; set; }
        public List<Ent_INFTEC> Listarlffs { get; set; }
        public List<Ent_INFTEC> ListVolumen { get; set; }
        public List<Ent_INFORME> ListEMaderable { get; set; }
        public List<Ent_INFTEC> ListEMaderableSemillero { get; set; }
        public List<Ent_INFTEC> ListPManejo { get; set; }
        public List<Ent_INFTEC> ListODS { get; set; }
        public List<Ent_INFTEC> ListComboEspecies { get; set; }
        public List<Ent_INFTEC> ListComboInciso { get; set; }

        
        public string txtTituloModal { get; set; }
        public List<Ent_SBusqueda> sBusqueda { get; set; }

        public string txtIdEspecie { get; set; }
        public string txtIdInfraccion { get; set; }

        public bool chkMaderable { get; set; }
        public bool chkSemillero { get; set; }

    }
}
