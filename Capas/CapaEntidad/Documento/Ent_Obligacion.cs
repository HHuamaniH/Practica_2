using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad.DOC
{
    public class Ent_Obligacion
    {
        [Description("nV_ID")]
        public string nV_ID { get; set; }
        [Description("nU_TIPO_OBLIGACION")]
        public string nU_TIPO_OBLIGACION { get; set; }
        [Description("fE_PRESENTACION")]
        public string fE_PRESENTACION { get; set; }
        [Description("nV_OBLIGACION")]
        public string nV_OBLIGACION { get; set; }
        [Description("nV_THABILITANTE")]
        public string nV_THABILITANTE { get; set; }
        [Description("nV_PLAN_MANEJO")]
        public string nV_PLAN_MANEJO { get; set; }
        [Description("nV_TITULAR")]
        public string nV_TITULAR { get; set; }
        [Description("nV_ESTADO")]
        public string nV_ESTADO { get; set; }
        [Description("txNroRegistro")]
        public string txNroRegistro { get; set; }
        [Description("nV_OBSERVACION")]
        public string nV_OBSERVACION { get; set; }
        [Description("nU_ESTADO")]
        public Int32 nU_ESTADO { get; set; }
        [Description("nU_OBLIGACION_BUSQUEDA")]
        public Int32 nU_OBLIGACION_BUSQUEDA { get; set; }
        [Description("nU_ESTADO_BUSQUEDA")]
        public Int32 nU_ESTADO_BUSQUEDA { get; set; }
        [Description("nV_CODIGO_BUSQUEDA")]
        public string nV_CODIGO_BUSQUEDA { get; set; }
        [Description("nV_CODUCUENTA")]
        public string nV_CODUCUENTA { get; set; }

        //Atributos compartidos de las obligaciones
        [Description("id")]
        public string id { get; set; }
        [Description("inIdTituloHabilitante")]
        public string inIdTituloHabilitante { get; set; }
        [Description("inIdPlanManejo")]
        public string inIdPlanManejo { get; set; }
        [Description("inIdObligacion")]
        public string inIdObligacion { get; set; }
        [Description("vaEstado")]
        public string vaEstado { get; set; }
        [Description("vaComentario")]
        public string vaComentario { get; set; }
        [Description("faFechaRegistro")]
        public string faFechaRegistro { get; set; }
        [Description("faFechaActualizacion")]
        public string faFechaActualizacion { get; set; }
        [Description("faFechaEliminacion")]
        public string faFechaEliminacion { get; set; }
        [Description("vaUsuarioRegistro")]
        public string vaUsuarioRegistro { get; set; }
        [Description("vaUsuarioActualizacion")]
        public string vaUsuarioActualizacion { get; set; }
        [Description("vaUsuarioEliminacion")]
        public string vaUsuarioEliminacion { get; set; }
        [Description("vaUsuRegistra")]
        public string vaUsuRegistra { get; set; }
        [Description("vaUsuActualiza")]
        public string vaUsuActualiza { get; set; }
        [Description("vaInformacionObligacion")]
        public string vaInformacionObligacion { get; set; }

        //Informe de ejecución     
        [Description("inIdInformeEjecucion")]
        public Int32 inIdInformeEjecucion { get; set; }   
        [Description("vaarffsNroRegistro")]
        public string vaarffsNroRegistro { get; set; }
        [Description("faarffsFecha")]
        public string faarffsFecha { get; set; }
        [Description("vaarffsAdjunto")]
        public string vaarffsAdjunto { get; set; }
        [Description("vaosinforNroRegistro")]
        public string vaosinforNroRegistro { get; set; }
        [Description("faosinforFecha")]
        public string faosinforFecha { get; set; }

        //Regente Forestal   
        [Description("inIdRegenteForestal")]
        public Int32 inIdRegenteForestal { get; set; }
        [Description("vaAdjunto")]
        public string vaAdjunto { get; set; }
        [Description("vaCategoria")]
        public string vaCategoria { get; set; }
        [Description("vaNombreRegente")]
        public string vaNombreRegente { get; set; }
        [Description("faFechaInicio")]
        public string faFechaInicio { get; set; }//También en contrato y actos adm.
        [Description("faFechaFin")]
        public string faFechaFin { get; set; }//También en contrato y actos adm.
        [Description("vaObservaciones")]
        public string vaObservaciones { get; set; }
        [Description("chElaboracion")]
        public string chElaboracion { get; set; }
        [Description("chSuscripcion")]
        public string chSuscripcion { get; set; }
        [Description("chImplementacion")]
        public string chImplementacion { get; set; }
        [Description("chCese")]
        public string chCese { get; set; }//También en contrato
        [Description("faFechaCese")]
        public string faFechaCese { get; set; }//También en contrato
        [Description("vaMotivoCese")]
        public string vaMotivoCese { get; set; }//También en contrato
        [Description("chMencionComunidades")]
        public string chMencionComunidades { get; set; }
        [Description("chMencionTaxonomico")]
        public string chMencionTaxonomico { get; set; }

        //Libro de Operación
        [Description("inIdLibro")]
        public Int32 inIdLibro { get; set; }
        [Description("vaIdFormaRegistro")]
        public string vaIdFormaRegistro { get; set; }
        [Description("vaNroRegistro")]
        public string vaNroRegistro { get; set; }
        [Description("vaOtroSistema")]
        public string vaOtroSistema { get; set; }

        //Custodio Forestal
        [Description("inIdCustodioForestal")]
        public Int32 inIdCustodioForestal { get; set; }
        [Description("chActividadProgramPatrullaje")]
        public string chActividadProgramPatrullaje { get; set; }
        [Description("chAlertaTemprana")]
        public string chAlertaTemprana { get; set; }
        [Description("chVerificacionZonasVulnerables")]
        public string chVerificacionZonasVulnerables { get; set; }
        [Description("chAlertaDesorestacion")]
        public string chAlertaDesorestacion { get; set; }
        [Description("vaOtroMotivo")]
        public string vaOtroMotivo { get; set; }//También en marcado
        [Description("chMineriaIlegal")]
        public string chMineriaIlegal { get; set; }
        [Description("chTalaIlegal")]
        public string chTalaIlegal { get; set; }
        [Description("chCambioUso")]
        public string chCambioUso { get; set; }
        [Description("chNinguno")]
        public string chNinguno { get; set; }
        [Description("vaOtroResultado")]
        public string vaOtroResultado { get; set; }
        [Description("vaAreaAfectada")]
        public string vaAreaAfectada { get; set; }
        [Description("vaCoordenadasReferencia")]
        public string vaCoordenadasReferencia { get; set; }
        [Description("vaDescripcion")]
        public string vaDescripcion { get; set; }//También en medidas
        [Description("faFechaPatrullaje")]
        public string faFechaPatrullaje { get; set; }

        //Contrato con tercero
        [Description("inIdContrato")]
        public Int32 inIdContrato { get; set; }
        [Description("vaNombre")]
        public string vaNombre { get; set; }
        [Description("vaRucEmpresa")]
        public string vaRucEmpresa { get; set; }

        //Linderos, hitos u Otros
        [Description("inIdRegistroHitoLindero")]
        public Int32 inIdRegistroHitoLindero { get; set; }

        //Garantía de fiel cumplimiento
        [Description("inIdRegistroFielCumplimiento")]
        public Int32 inIdRegistroFielCumplimiento { get; set; }
        [Description("faVigenciaInicio")]
        public string faVigenciaInicio { get; set; }
        [Description("faVigenciaFin")]
        public string faVigenciaFin { get; set; }

        //Movilización de frutos, productos y sub productos
        [Description("inIdFrutosProductosSubProductos")]
        public Int32 inIdFrutosProductosSubProductos { get; set; }
        [Description("vaPrimeraSerieNumGTF")]
        public string vaPrimeraSerieNumGTF { get; set; }
        [Description("faPrimeraSerieFechaEmision")]
        public string faPrimeraSerieFechaEmision { get; set; }
        [Description("vaPrimeraSeriePrimerNumListasTrozas")]
        public string vaPrimeraSeriePrimerNumListasTrozas { get; set; }
        [Description("vaPrimeraSerieUltimoNumListasTrozas")]
        public string vaPrimeraSerieUltimoNumListasTrozas { get; set; }
        [Description("vaUltimaSerieNumGTF")]
        public string vaUltimaSerieNumGTF { get; set; }
        [Description("faUltimaSerieFechaEmision")]
        public string faUltimaSerieFechaEmision { get; set; }
        [Description("vaUltimaSeriePrimerNumListasTrozas")]
        public string vaUltimaSeriePrimerNumListasTrozas { get; set; }
        [Description("vaUltimaSerieUltimoNumListasTrozas")]
        public string vaUltimaSerieUltimoNumListasTrozas { get; set; }

        //Marcados de Trozas y Tocones
        [Description("inIdRegistroMarcadoTrozas")]
        public Int32 inIdRegistroMarcadoTrozas { get; set; }
        [Description("chCodificacionTrozas")]
        public string chCodificacionTrozas { get; set; }
        [Description("chMatCodPlacas")]
        public string chMatCodPlacas { get; set; }
        [Description("chMatCodCodBarras")]
        public string chMatCodCodBarras { get; set; }
        [Description("chMatCodTroquelado")]
        public string chMatCodTroquelado { get; set; }
        [Description("chMatCodChips")]
        public string chMatCodChips { get; set; }
        [Description("chMatCodPintura")]
        public string chMatCodPintura { get; set; }
        [Description("chMatCodOtros")]
        public string chMatCodOtros { get; set; }
        [Description("vaOtroMaterial")]
        public string vaOtroMaterial { get; set; }

        //Medidas Correctivas
        [Description("inIdMovRegistroMedidaCorrectiva")]
        public Int32 inIdMovRegistroMedidaCorrectiva { get; set; }
        [Description("chTipo")]
        public string chTipo { get; set; }
        [Description("vaNumResolucion")]
        public string vaNumResolucion { get; set; }//También en actos adm.
        [Description("inPlazo")]
        public Int32 inPlazo { get; set; }
        [Description("faPresentacion")]
        public string faPresentacion { get; set; }

        //Actos Administrativos
        [Description("inIdMovRegistroPlanAdministrativo")]
        public Int32 inIdMovRegistroPlanAdministrativo { get; set; }
        [Description("vaTipoGestion")]
        public string vaTipoGestion { get; set; }
        [Description("vaOtrasNroDocumento")]
        public string vaOtrasNroDocumento { get; set; }
        [Description("vaOtrasNroRegistro")]
        public string vaOtrasNroRegistro { get; set; }
        [Description("faOtrasFecha")]
        public string faOtrasFecha { get; set; }
        [Description("vaOtrasDescripcion")]
        public string vaOtrasDescripcion { get; set; }

        //Título Habilitante
        [Description("currentPage")]
        public Int32 currentPage { get; set; }
        [Description("totalPages")]
        public Int32 totalPages { get; set; }
        [Description("totalItems")]
        public Int32 totalItems { get; set; }
        [Description("inIdTitular")]
        public string inIdTitular { get; set; }
        [Description("inIdRegente")]
        public string inIdRegente { get; set; }
        [Description("inCodigo")]
        public Int32 inCodigo { get; set; }
        [Description("vaCodigo")]
        public string vaCodigo { get; set; }
        [Description("vaDepartamento")]
        public string vaDepartamento { get; set; }
        [Description("vaProvincia")]
        public string vaProvincia { get; set; }
        [Description("vaDistrito")]
        public string vaDistrito { get; set; }

        //Plan de Manejo
        [Description("vaCodPlanManejo")]
        public string vaCodPlanManejo { get; set; }
        [Description("vaNumTituloHabilitante")]
        public string vaNumTituloHabilitante { get; set; }
        [Description("vaTitularActual")]
        public string vaTitularActual { get; set; }
        [Description("varLegal")]
        public string varLegal { get; set; }
        [Description("vaModalidad")]
        public string vaModalidad { get; set; }
        [Description("vaodAmbito")]
        public string vaodAmbito { get; set; }
        [Description("inAreaTh")]
        public Decimal inAreaTh { get; set; }
        [Description("vaCaducidad")]
        public string vaCaducidad { get; set; }
        [Description("vaTipoPlan")]
        public string vaTipoPlan { get; set; }
        [Description("vaNombrePOA")]
        public string vaNombrePOA { get; set; }
        [Description("vaResolucionAprueba")]
        public string vaResolucionAprueba { get; set; }
        [Description("faFechaAprobacion")]
        public string faFechaAprobacion { get; set; }
        [Description("inAreaPOA")]
        public Decimal inAreaPOA { get; set; }
        [Description("inConsultorCodigo")]
        public string inConsultorCodigo { get; set; }

        //Archivo
        [Description("inTipoObligacion")]
        public Int32 inTipoObligacion { get; set; }
        [Description("vaNombreCategoria")]
        public string vaNombreCategoria { get; set; }
        [Description("inIdElemento")]
        public Int32 inIdElemento { get; set; }
        [Description("vaNombreArchivo")]
        public string vaNombreArchivo { get; set; }
        [Description("inTipoArchivo")]
        public Int32 inTipoArchivo { get; set; }
        [Description("vaRutaArchivo")]
        public string vaRutaArchivo { get; set; }
        [Description("objArchivo")]
        public Ent_Obligacion objArchivo { get; set; }

        //Hallazgo
        [Description("vaZonaUTM")]
        public string vaZonaUTM { get; set; }
        [Description("inCoordenadaEste")]
        public Int32 inCoordenadaEste { get; set; }
        [Description("inCoordenadaNorte")]
        public Int32 inCoordenadaNorte { get; set; }

        //Listas
        [Category("LIST"), Description("result")]
        public List<Ent_Obligacion> result { get; set; }

        public Ent_Obligacion()
        {
            nU_ESTADO = -1;
            inIdInformeEjecucion = -1;
            inIdRegenteForestal = -1;
            inIdLibro = -1;
            inIdCustodioForestal = -1;
            inIdContrato = -1;
            inIdRegistroHitoLindero = -1;
            inIdRegistroFielCumplimiento = -1;
            inIdFrutosProductosSubProductos = -1;
            inIdRegistroMarcadoTrozas = -1;
            inIdMovRegistroMedidaCorrectiva = -1;
            inPlazo = -1;
            inIdMovRegistroPlanAdministrativo = -1;
            currentPage = -1;
            totalPages = -1;
            totalItems = -1;
            inCodigo = -1;
            inAreaTh = -1;
            inAreaPOA = -1;
            inTipoObligacion = -1;
            inIdElemento = -1;
            inTipoArchivo = -1;
        }
    }
}
