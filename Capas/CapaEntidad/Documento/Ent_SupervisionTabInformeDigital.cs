using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad.DOC
{
   public  class Ent_SupervisionTabInformeDigital
    {
        [Description("pVInformeDigital")]
        public string pVInformeDigital { get; set; }
        [Description("pVCodInformeDigital")]
        public string pVCodInformeDigital { get; set; }
        [Description("pVCodInforme")]
        public string pVCodInforme { get; set; }
        [Description("pVNumInformeSITD")]
        public string pVNumInformeSITD { get; set; }
        [Description("pNTramiteId")]
        public int pNTramiteId { get; set; }
        [Description("pVCodDestinatario")]
        public string pVCodDestinatario { get; set; }
        [Description("pDFechaRegistro")]
        public DateTime pDFechaRegistro { get; set; }
        [Description("pVRucTitularEstado")]
        public string pVRucTitularEstado { get; set; }
        [Description("pVRucTitularCondicion")]
        public string pVRucTitularCondicion { get; set; }
        [Description("pVRucTitularDireccion")]
        public string pVRucTitularDireccion { get; set; }
        [Description("pVNumTelefonoTitular")]
        public string pVNumTelefonoTitular { get; set; }
        [Description("pVAntecedentes")]
        public string pVAntecedentes { get; set; }
        [Description("pVTipoBosque")]
        public string pVTipoBosque { get; set; }
        [Description("pVDiligenciaCronograma")]
        public string pVDiligenciaCronograma { get; set; }
        [Description("pVMetodologia")]
        public string pVMetodologia { get; set; }
        [Description("pVAnalisis")]
        public string pVAnalisis { get; set; }
        [Description("pVResultados")]
        public string pVResultados { get; set; }
        [Description("pVConclusiones")]
        public string pVConclusiones { get; set; }
        [Description("pVRecomendaciones")]
        public string pVRecomendaciones { get; set; }
        [Description("pVCodUsuarioCreacion")]
        public string pVCodUsuarioCreacion { get; set; }
        [Description("pVCodUsuarioModificacion")]
        public string pVCodUsuarioModificacion { get; set; }
        [Description("pDFechaCreacion")]
        public DateTime pDFechaCreacion { get; set; }
        [Description("pDFechaModificacion")]
        public DateTime? pDFechaModificacion { get; set; }
        [Description("pNRegEstado")]
        public Int32 pNRegEstado { get; set; }
        [Category("OUTPUT"), Description("pVOUTPUTPARAM01")]
        public Object pVOUTPUTPARAM01 { get; set; }
        public Ent_SupervisionTabInformeDigital()
        {
            this.pDFechaCreacion = DateTime.Now;
            this.pDFechaModificacion = DateTime.Now;
            this.pNTramiteId = 0;
        }
    }
}
