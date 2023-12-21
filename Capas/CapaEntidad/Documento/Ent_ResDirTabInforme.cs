using System;
using System.ComponentModel;

namespace CapaEntidad.DOC
{
    public class Ent_ResDirTabInforme
    {
        [Description("pVCodInformeDigital")]
        public string pVCodInformeDigital { get; set; }
        [Description("pVCodResolucion")]
        public string pVCodResolucion { get; set; }
        [Description("pNTramiteID")]
        public int? pNTramiteID { get; set; }
        [Description("pVNumInformeSITD")]
        public string pVNumInformeSITD { get; set; }
        [Description("pVCodProcedencia")]
        public string pVCodProcedencia { get; set; }
        [Description("pVCodTipoInforme")]
        public string pVCodTipoInforme { get; set; }
        [Description("pVCodMateria")]
        public string pVCodMateria { get; set; }
        [Description("pVCodModalidad")]
        public string pVCodModalidad { get; set; }
        [Description("pVCodTHabilitante")]
        public string pVCodTHabilitante { get; set; }
        [Description("pVRucTitularEstado")]
        public string pVRucTitularEstado { get; set; }
        [Description("pVRucTitularCondicion")]
        public string pVRucTitularCondicion { get; set; }
        [Description("pDRucFechaConsulta")]
        public DateTime? pDRucFechaConsulta { get; set; }
        [Description("pVUbicacionCodDpto")]
        public string pVUbicacionCodDpto { get; set; }
        [Description("pVUbicacionCodProv")]
        public string pVUbicacionCodProv { get; set; }
        [Description("pVUbicacionCodDist")]
        public string pVUbicacionCodDist { get; set; }
        [Description("pVUbicacionSector")]
        public string pVUbicacionSector { get; set; }

        [Description("pNFlagResponsableSolidario")]
        public Int16 pNFlagResponsableSolidario { get; set; }
        [Description("pNFlagGravedadOcasionada")]
        public Int16 pNFlagGravedadOcasionada { get; set; }
        [Description("pNFlagAcreditacionImputaciones")]
        public Int16 pNFlagAcreditacionImputaciones { get; set; }
        [Description("pNFlagSancion")]
        public Int16 pNFlagSancion { get; set; }
        [Description("pNSancionUIT")]
        public decimal pNSancionUIT { get; set; }
        [Description("pvSancionCodCalculo")]
        public string pvSancionCodCalculo { get; set; }
        [Description("pNFlagMedidasComplementarias")]
        public Int16 pNFlagMedidasComplementarias { get; set; }
        [Description("pNFlagMedidasCorrectivas")]
        public Int16 pNFlagMedidasCorrectivas { get; set; }
        [Description("pNFlagComunicacionEntidades")]
        public Int16 pNFlagComunicacionEntidades { get; set; }

        [Description("pVRutaArchivoRevision")]
        public string pVRutaArchivoRevision { get; set; }
        [Description("pVCodUsuarioCreacion")]
        public string pVCodUsuarioCreacion { get; set; }
        [Description("pVCodUsuarioModificacion")]
        public string pVCodUsuarioModificacion { get; set; }
        [Description("pDFechaCreacion")]
        public DateTime pDFechaCreacion { get; set; }
        [Description("pDFechaModificacion")]
        public DateTime? pDFechaModificacion { get; set; }
        [Description("pNEstado")]
        public Int32 pNEstado { get; set; }
        [Category("OUTPUT"), Description("pVOUTPUTPARAM01")]
        public Object pVOUTPUTPARAM01 { get; set; }

        public Ent_ResDirTabInforme()
        {
            this.pDFechaCreacion = DateTime.Now;
            this.pDFechaModificacion = DateTime.Now;
        }
    }
}
