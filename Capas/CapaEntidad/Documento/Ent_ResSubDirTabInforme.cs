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
        [Description("pVNroReferencia")]
        public string pVNroReferencia { get; set; }
        [Description("pVCodTitular")]
        public string pVCodTitular { get; set; }
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
        [Description("pVVistos")]
        public string pVVistos { get; set; }
        [Description("pVAntecedentes")]
        public string pVAntecedentes { get; set; }
        [Description("pVCompetencia")]
        public string pVCompetencia { get; set; }
        [Description("pVAnalisis")]
        public string pVAnalisis { get; set; }
        [Description("pVImputacion")]
        public string pVImputacion { get; set; }
        [Description("pVComunicacionExterna")]
        public string pVComunicacionExterna { get; set; }
        [Description("pVParrafosCliche")]
        public string pVParrafosCliche { get; set; }
        [Description("pVPiePagina")]
        public string pVPiePagina { get; set; }
        [Description("pVResolucion")]
        public string pVResolucion { get; set; }
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
