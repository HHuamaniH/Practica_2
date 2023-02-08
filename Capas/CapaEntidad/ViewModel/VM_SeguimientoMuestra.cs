using System.Collections.Generic;

namespace CapaEntidad.ViewModel
{
    public class VM_SeguimientoMuestra
    {
        public string id { get; set; }
        public int hdEstado { get; set; }
        public IEnumerable<VM_Cbo> ddlItemIndicador { get; set; }
        public string ddlItemIndicadorId { get; set; }
        public IEnumerable<VM_Cbo> ddlODRegistro { get; set; }
        public string ddlODRegistroId { get; set; }
        public string lblUsuarioRegistro { get; set; }
        public string lblUsuarioControl { get; set; }
        public string lblTituloEstado { get; set; }
        public string desSupervision { get; set; }
        public string codSupervision { get; set; }
        public string desTHabilitante { get; set; }
        public string codTH { get; set; }
        public string desNotificacion { get; set; }
        public string desTramEnvio { get; set; }
        public string codTramiteEnvio { get; set; }
        public string desTramRespuesta { get; set; }
        public string codTramiteRespuesta { get; set; }
        public string obsCalidad { get; set; }
        public string obsSubsanar { get; set; }
        public string observacion { get; set; }
        //otros datos
        public string cNroDocumentoE { get; set; }
        public string fFecDocumentoE { get; set; }
        public string cAsuntoE { get; set; }
        public string cNroDocumentoR { get; set; }
        public string fFecDocumentoR { get; set; }
        public string cAsuntoR { get; set; }
        public string pdf_id_tram_envio { get; set; }
        public string pdf_id_tram_respuesta { get; set; }

        public string msjR { get; set; }
        public string modalidad { get; set; }
        public string supervisor { get; set; }
        public string titular { get; set; }
        public string poa { get; set; }
        public string fecha { get; set; }
        public int anio { get; set; }
        public List<VM_SeguimientoMuestraDetalle> detalle { get; set; }

        public VM_SeguimientoMuestra()
        {
            detalle = new List<VM_SeguimientoMuestraDetalle>();
        }
    }
    public class VM_SeguimientoMuestraDetalle
    {
        public string codSeguimiento { get; set; }
        public int secuencial { get; set; }
        public int estado { get; set; }
        public string codMuestra { get; set; }
        public string Z_UTMId { get; set; }
        public string C_ESTE { get; set; }
        public string C_NORTE { get; set; }
        public string SECTOR { get; set; }
        public string fColeccion { get; set; }
        public string obs { get; set; }
        public string poa { get; set; }
        public int? idPoa { get; set; }
        public string ddlCensoId { get; set; }
        public string codEspecie { get; set; }
        public string especie { get; set; }
        public bool especieIdent { get; set; }
        public string titulo { get; set; }
        //datos de especie      
        public string especieCensoDes { get; set; }
        public string estadoEspecieCenso { get; set; }
        public string condicionEspecieCenso { get; set; }
        public int esMaderable { get; set; }
        public int codSecuencialCenso { get; set; }
        //De la corteza interna
        public string cortezaiColor { get; set; }
        public string cortezaiOlor { get; set; }
        public string cortezaiExuOlor { get; set; }
        //De la corteza interna - Otra caracteristica
        public string otrasCaracteristica { get; set; }
        //De las inclusiones en el fuste-Otras estructuras
        public string otrasEstructuras { get; set; }
        //De las flores - tamaño
        public string floresTamaño { get; set; }
        //De las flores - otras caracteriticas
        public string floresOtrasCaract { get; set; }
        //De las frutos - tamaño
        public string frutosTamanio { get; set; }
        //De las frutos - otras caracteriticas
        public string frutosOtrasCaract { get; set; }

        //Del hábito del árbol
        public string habitoArbol { get; set; }

        //
        public bool chkFSimple { get; set; }
        public bool chkFInflorescencia { get; set; }

        public bool chkHSimple { get; set; }
        public bool chkHCompuesta { get; set; }

        public List<VM_ArchivoMuestra> fotos { get; set; }
        public List<VM_ArchivoMuestra> fotosDelete { get; set; }
        //De la forma del fuste
        public List<VM_Cbo> cboFFuste { get; set; }
        public string cboFFusteId { get; set; }
        //--Del tipo de ramificación
        public List<VM_Cbo> cboTRamificacion { get; set; }
        public string cboTRamificacionId { get; set; }
        //Del tipo de raices
        public List<VM_Cbo> cboTRaices { get; set; }
        public string cboTRaicesId { get; set; }
        //De la corteza externa-Color
        public List<VM_Cbo> cboCEColor { get; set; }
        public string cboCEColorId { get; set; }
        //De la corteza externa-De las lenticelas
        public List<VM_Cbo> cboCELenticelas { get; set; }
        public string cboCELenticelasId { get; set; }
        //De la corteza externa-Del ritidoma
        public List<VM_Cbo> cboCERitidoma { get; set; }
        public string cboCERitidomaId { get; set; }
        //De la corteza externa-Otras estructuras
        public List<VM_Cbo> cboCEOExtructura { get; set; }
        public string cboCEOExtructuraId { get; set; }
        //De la corteza interna-Del exudado-Tipo
        public List<VM_Cbo> cboCIETipo { get; set; }
        public string cboCIETipoId { get; set; }
        //De la corteza interna-Del exudado-Color
        public List<VM_Cbo> cboCIEColor { get; set; }
        public string cboCIEColorId { get; set; }
        //De la corteza interna-Del exudado-Sabor
        public List<VM_Cbo> cboCIESabor { get; set; }
        public string cboCIESaborId { get; set; }
        //De la corteza interna-Del exudado-Abundancia
        public List<VM_Cbo> cboCIEAbundancia { get; set; }
        public string cboCIEAbundanciaId { get; set; }
        //De la corteza interna-Tipo
        public List<VM_Cbo> cboCITipo { get; set; }
        public string cboCITipoId { get; set; }
        //De las inclusiones en el fuste-Espinas
        public List<VM_Cbo> cboIFEspinas { get; set; }
        public string cboIFEspinasId { get; set; }
        //De las inclusiones en el fuste- Aguijones
        public List<VM_Cbo> cboIFAguijones { get; set; }
        public string cboIFAguijonesId { get; set; }
        //De las hojas- Por su forma
        public List<VM_Cbo> cboHojaForma { get; set; }
        public string cboHojaFormaId { get; set; }
        //De las hojas- Tipo de borde
        public List<VM_Cbo> cboHojaBorde { get; set; }
        public string cboHojaBordeId { get; set; }
        //De las hojas- Disposición de la lamina
        public List<VM_Cbo> cboHojaLamina { get; set; }
        public string cboHojaLaminaId { get; set; }
        //De las flores- color
        public List<VM_Cbo> cboFloresColor { get; set; }
        public string cboFloresColorId { get; set; }
        //De los frutos-tipo
        public List<VM_Cbo> cboFrutosTipo { get; set; }
        public string cboFrutosTipoId { get; set; }
        //De los frutos-color
        public List<VM_Cbo> cboFrutosColor { get; set; }
        public string cboFrutosColorId { get; set; }
        public string colectorId { get; set; }
        public string colectorDes { get; set; }
        public string supervisorId { get; set; }
        public string supervisoDes { get; set; }
        public string descripcion { get; set; }
        public string codCenso { get; set; }
    }
    public class VM_ArchivoMuestra
    {
        public int secuencial { get; set; }
        public string archivo { get; set; }
        public string ext { get; set; }
        public string generado { get; set; }
    }
}
