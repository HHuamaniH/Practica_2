using System;
using System.ComponentModel;

namespace CapaEntidad.Documento
{
    public class Ent_InformeLegalPAUDigital
    {
        [Description("pVCodInformeDigital")]
        public string pVCodInformeDigital { get; set; }
        [Description("pVCodInforme")]
        public string pVCodInforme { get; set; }
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
        //[Description("pVRucTitularDireccion")]
        //public string pVRucTitularDireccion { get; set; }
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

        [Description("pNFlagCuestionPrevia")]
        public Int16 pNFlagCuestionPrevia { get; set; }
        [Description("pNFlagRecResponsabilidad")]
        public Int16 pNFlagRecResponsabilidad { get; set; }
        [Description("pNFlagGravedadRiesgo")]
        public Int16 pNFlagGravedadRiesgo { get; set; }
        [Description("pNFlagSancion")]
        public Int16 pNFlagSancion { get; set; }
        [Description("pNSancionUIT")]
        public decimal pNSancionUIT { get; set; }
        [Description("pvSancionCodCalculo")]
        public string pvSancionCodCalculo { get; set; }
        [Description("pNFlagMedidaCorrectiva")]
        public Int16 pNFlagMedidaCorrectiva { get; set; }
        [Description("pNFlagMedidaComplementaria")]
        public Int16 pNFlagMedidaComplementaria { get; set; }
        [Description("pNFlagResponsableSolidario")]
        public Int16 pNFlagResponsableSolidario { get; set; }
        [Description("pNFlagComunicacionGORE")]
        public Int16 pNFlagComunicacionGORE { get; set; }

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

        public Ent_InformeLegalPAUDigital()
        {
            this.pDFechaCreacion = DateTime.Now;
            this.pDFechaModificacion = DateTime.Now;
        }
    }
}
