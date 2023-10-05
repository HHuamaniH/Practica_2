using System;
using System.ComponentModel;

namespace CapaEntidad.DOC
{
    public class Ent_ResSubDirTabInforme
    {
        [Description("pVCodInformeDigital")]
        public string pVCodInformeDigital { get; set; }
        [Description("pVCodResSub")]
        public string pVCodResSub { get; set; }
        [Description("pVNumInformeSITD")]
        public string pVNumInformeSITD { get; set; }
        [Description("pNTramiteID")]
        public int? pNTramiteID { get; set; }
        [Description("pVCodProcedencia")]
        public string pVCodProcedencia { get; set; }
        [Description("pVCodMateria")]
        public string pVCodMateria { get; set; }
        [Description("pVCodModalidad")]
        public string pVCodModalidad { get; set; }
        [Description("pVNroReferencia")]
        public string pVNroReferencia { get; set; }
        [Description("pNNumPOA")]
        public int? pNNumPOA { get; set; }
        [Description("pVCodTHabilitante")]
        public string pVCodTHabilitante { get; set; }
        [Description("pVRucTitularEstado")]
        public string pVRucTitularEstado { get; set; }
        [Description("pVRucTitularCondicion")]
        public string pVRucTitularCondicion { get; set; }
        [Description("pNAnioResolucion")]
        public Int32? pNAnioResolucion { get; set; }
        [Description("pVCodUndOrganica")]
        public string pVCodUndOrganica { get; set; }
        [Description("pDFechaResolucion")]
        public DateTime? pDFechaResolucion { get; set; }        
        [Description("pNFlagCaducidadExtraccion")]
        public Int16 pNFlagCaducidadExtraccion { get; set; }
        [Description("pNFlagImputacionCargos")]
        public Int16 pNFlagImputacionCargos { get; set; }
        [Description("pNFlagMedidasCautelares")]
        public Int16 pNFlagMedidasCautelares { get; set; }
        [Description("pNFlagComunicacion")]
        public Int16 pNFlagComunicacion { get; set; }
        [Description("pNFlagHerramientasSubsanar")]
        public Int16 pNFlagHerramientasSubsanar { get; set; }
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
        public Ent_ResSubDirTabInforme()
        {
            this.pDFechaCreacion = DateTime.Now;
            this.pDFechaModificacion = DateTime.Now;
        }
    }
}
