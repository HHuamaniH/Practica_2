using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CapaEntidad.DOC
{
    public class Ent_InfQuinquenal_QUINQUENIO
    {
        public string COD_INFORME { get; set; }
        public List<Ent_InfQuinquenal> verificadores { get; set; }
        public Ent_IQUINQUENAL_DET_CONCLUSION entConclusion { get; set; }
    }
    public class Ent_InfQuinquenal
    {
        #region Entidades y Propiedades
        [Description("COD_PERSONA")]
        public String COD_PERSONA { get; set; }
        [Description("APELLIDOS_NOMBRE")]
        public String APELLIDOS_NOMBRE { get; set; }
        [Description("CARGO")]
        public String CARGO { get; set; }
        [Description("DNI")]
        public String DNI { get; set; }
        [Description("MODALIDAD")]
        public String MODALIDAD { get; set; }
        [Description("ENTIDAD")]
        public String ENTIDAD { get; set; }
        [Description("RegEstado")]
        public Int32 RegEstado { get; set; }

        [Description("NUM_POA")]
        public Int32 NUM_POA { get; set; }
        [Description("POA")]
        public String POA { get; set; }

        [Description("COD_RESODIREC")]
        public String COD_RESODIREC { get; set; }
        [Description("COD_THABILITANTE")]
        public String COD_THABILITANTE { get; set; }
        [Description("NUMERO_RESOLUCION")]
        public String NUMERO_RESOLUCION { get; set; }

        [Description("TIPO_FISCALIZA")]
        public String TIPO_FISCALIZA { get; set; }
        [Description("FECHA_EMISION")]
        public Object FECHA_EMISION { get; set; }
        [Description("TITULO_TH")]
        public String TITULO_TH { get; set; }

        [Description("COD_INFO_DOCUMENTARIO")]
        public String COD_INFO_DOCUMENTARIO { get; set; }

        [Description("COD_INFORME")]
        public String COD_INFORME { get; set; }
        [Description("NUM_INFORME")]
        public String NUM_INFORME { get; set; }
        [Description("COD_FCTIPO")]
        public String COD_FCTIPO { get; set; }

        [Description("COD_DIRECTOR")]
        public String COD_DIRECTOR { get; set; }
        [Description("COD_PROFESIONAL")]
        public String COD_PROFESIONAL { get; set; }
        [Description("CONCLUSIONES")]
        public String CONCLUSIONES { get; set; }
        [Description("DESCRIPCION")]
        public String DESCRIPCION { get; set; }

        //para la busqueda
        [Description("BusValor")]
        public string BusValor { get; set; }
        [Description("BusFormulario")]
        public string BusFormulario { get; set; }
        [Description("BusCriterio")]
        public string BusCriterio { get; set; }
        //para eliminar registros
        [Description("EliTABLA")]
        public string EliTABLA { get; set; }
        [Description("EliVALOR01")]
        public string EliVALOR01 { get; set; }
        [Description("EliVALOR02")]
        public int EliVALOR02 { get; set; }

        // para control de calidad
        [Description("COD_ESTADO_DOC")]
        public String COD_ESTADO_DOC { get; set; }
        [Description("OBSERVACIONES_CONTROL")]
        public Object OBSERVACIONES_CONTROL { get; set; }
        [Description("OBSERV_SUBSANAR")]
        public Object OBSERV_SUBSANAR { get; set; }

        [Description("COD_UCUENTA")]
        public String COD_UCUENTA { get; set; }

        [Category("OUTPUT"), Description("OUTPUTPARAM01")]
        public Object OUTPUTPARAM01 { get; set; }

        [Description("CODIGO")]
        public String CODIGO { get; set; }


        [Description("Este")]
        public String Este { get; set; }
        [Description("Norte")]
        public String Norte { get; set; }
        [Description("PCA")]
        public String PCA { get; set; }
        [Description("Infraestructura")]
        public String Infraestructura { get; set; }
        [Description("POAPendiente")]
        public String POAPendiente { get; set; }
        [Description("CampoPendiente")]
        public Int32 CampoPendiente { get; set; }
        [Description("ObservacionPendiente")]
        public String ObservacionPendiente { get; set; }
        [Description("POACalzada")]
        public Int32 POACalzada { get; set; }
        [Description("CampoCalzada")]
        public Int32 CampoCalzada { get; set; }
        [Description("Observacioncalzada")]
        public String Observacioncalzada { get; set; }
        [Description("COD_INFRAESTRUCTURA")]
        public String COD_INFRAESTRUCTURA { get; set; }

        [Description("DERECHO_APROVECHAMIENTO")]
        public String DERECHO_APROVECHAMIENTO { get; set; }
        [Description("DISPOCISION_DE_DO")]
        public String DISPOCISION_DE_DO { get; set; }
        [Description("ORDENAMIENTO_MF")]
        public String ORDENAMIENTO_MF { get; set; }
        [Description("SISTEMA_MARCADO")]
        public String SISTEMA_MARCADO { get; set; }
        [Description("ARBOLES_VOLUMENES")]
        public String ARBOLES_VOLUMENES { get; set; }
        [Description("PROTECCION_CONCESION")]
        public String PROTECCION_CONCESION { get; set; }
        [Description("RELACION_PUEBLOS")]
        public String RELACION_PUEBLOS { get; set; }
        [Description("OTRAS_DISPOCISIONES")]
        public String OTRAS_DISPOCISIONES { get; set; }
        [Description("REQUERIMIENTOS_CONCESIONARIO")]
        public String REQUERIMIENTOS_CONCESIONARIO { get; set; }
        [Description("OTROS_CONCLUSION_DOCUMENTARIA")]
        public String OTROS_CONCLUSION_DOCUMENTARIA { get; set; }
        [Description("CATEGORIA_ORDENAMIENTO")]
        public String CATEGORIA_ORDENAMIENTO { get; set; }
        [Description("PLANIFICACION_APROVECHAMIENTO")]
        public String PLANIFICACION_APROVECHAMIENTO { get; set; }
        [Description("APROVECHAMIENTO_FORESTAL")]
        public String APROVECHAMIENTO_FORESTAL { get; set; }
        [Description("APLICACION_SILVICULTURAL")]
        public String APLICACION_SILVICULTURAL { get; set; }
        [Description("PROTECCION_CONCESION2")]
        public String PROTECCION_CONCESION2 { get; set; }
        [Description("OTROS_CONCLUSION_CAMPO")]
        public String OTROS_CONCLUSION_CAMPO { get; set; }
        [Description("RECOMENDACION_GENERAL")]
        public String RECOMENDACION_GENERAL { get; set; }

        [Description("NUMERO_FILA")]
        public Int32 NUMERO_FILA { get; set; }
        [Description("NUMERO")]
        public String NUMERO { get; set; }
        [Description("VOLUMEN")]
        public Decimal VOLUMEN { get; set; }

        [Description("DOCUMENTACION")]
        public string DOCUMENTACION { get; set; }

        [Description("ASUNTO")]
        public String ASUNTO { get; set; }

        [Description("OBSERVACION1")]
        public string OBSERVACION1 { get; set; }
        #region Informe de resultados quinquenales
        [Category("FECHA"), Description("FEC_PRESENT_PM")]
        public Object FEC_PRESENT_PM { get; set; }
        [Category("FECHA"), Description("FEC_APROB_PM")]
        public Object FEC_APROB_PM { get; set; }
        [Description("CUMPLE_PM_PGMF")]
        public Object CUMPLE_PM_PGMF { get; set; }
        [Description("OBSERV_PM_PGMF")]
        public String OBSERV_PM_PGMF { get; set; }
        [Description("APROB_NORMAVIGENTE_PM")]
        public Object APROB_NORMAVIGENTE_PM { get; set; }
        [Description("OBSERV_NORMAVIGENTE_PM")]
        public String OBSERV_NORMAVIGENTE_PM { get; set; }
        [Description("CUENTA_INFOEJECPO")]
        public Object CUENTA_INFOEJECPO { get; set; }
        [Category("FECHA"), Description("FEC_PRESENT_INFOEJECPO")]
        public Object FEC_PRESENT_INFOEJECPO { get; set; }
        [Category("FECHA"), Description("FEC_COMUNIC_INFOEJECPO")]
        public Object FEC_COMUNIC_INFOEJECPO { get; set; }
        [Description("CUMPLE_LINEA_INFOEJECPO")]
        public Object CUMPLE_LINEA_INFOEJECPO { get; set; }
        [Description("OBSERV_LINEA_INFOEJECPO")]
        public String OBSERV_LINEA_INFOEJECPO { get; set; }
        [Description("INDICIO_APROV")]
        public Object INDICIO_APROV { get; set; }
        [Description("OBSERV_APROV")]
        public String OBSERV_APROV { get; set; }
        [Description("LINDERAMIENTO_AREA")]
        public String LINDERAMIENTO_AREA { get; set; }
        [Description("CUMPLE_VIAL_PLANMAN")]
        public Object CUMPLE_VIAL_PLANMAN { get; set; }
        [Description("CUMPLE_PAGO_APROV")]
        public Object CUMPLE_PAGO_APROV { get; set; }
        [Description("OBSERV_PAGO_APROV")]
        public String OBSERV_PAGO_APROV { get; set; }
        [Description("COD_RESODIREC_GRAVEDAD")]
        public String COD_RESODIREC_GRAVEDAD { get; set; }
        [Description("INEX_AGUAJAL")]
        public Object INEX_AGUAJAL { get; set; }
        [Description("INEX_PASTIZAL")]
        public Object INEX_PASTIZAL { get; set; }
        [Description("INEX_INACCESIBLE")]
        public Object INEX_INACCESIBLE { get; set; }
        [Description("INEX_OTROS")]
        public Object INEX_OTROS { get; set; }
        [Description("INEX_AGUAJAL_PORC")]
        public Decimal INEX_AGUAJAL_PORC { get; set; }
        [Description("INEX_PASTIZAL_PORC")]
        public Decimal INEX_PASTIZAL_PORC { get; set; }
        [Description("INEX_INACCESIBLE_PORC")]
        public Decimal INEX_INACCESIBLE_PORC { get; set; }
        [Description("INEX_OTROS_PORC")]
        public Decimal INEX_OTROS_PORC { get; set; }
        [Description("INEX_AGUAJAL_NOUB")]
        public Int32 INEX_AGUAJAL_NOUB { get; set; }
        [Description("INEX_PASTIZAL_NOUB")]
        public Int32 INEX_PASTIZAL_NOUB { get; set; }
        [Description("INEX_INACCESIBLE_NOUB")]
        public Int32 INEX_INACCESIBLE_NOUB { get; set; }
        [Description("INEX_OTROS_NOUB")]
        public Int32 INEX_OTROS_NOUB { get; set; }
        [Description("INEX_AGUAJAL_OBS")]
        public String INEX_AGUAJAL_OBS { get; set; }
        [Description("INEX_PASTIZAL_OBS")]
        public String INEX_PASTIZAL_OBS { get; set; }
        [Description("INEX_INACCESIBLE_OBS")]
        public String INEX_INACCESIBLE_OBS { get; set; }
        [Description("INEX_OTROS_OBS")]
        public String INEX_OTROS_OBS { get; set; }
        [Description("CUENTA_AREPOSICION")]
        public String CUENTA_AREPOSICION { get; set; }
        [Description("AREA_DEMARCACION")]
        public String AREA_DEMARCACION { get; set; }
        [Description("AREA_LINDERAMIENTO")]
        public String AREA_LINDERAMIENTO { get; set; }
        [Description("TIPO_SAPROVECHAMIENTO")]
        public String TIPO_SAPROVECHAMIENTO { get; set; }
        [Description("DESC_ESPECIES")]
        public String DESC_ESPECIES { get; set; }
        [Description("COD_SECUENCIAL")]
        public Int32 COD_SECUENCIAL { get; set; }

        [Description("VERTICE")]
        public String VERTICE { get; set; }
        [Description("ZONA")]
        public String ZONA { get; set; }
        [Description("COORDENADA_NORTE")]
        public Int32 COORDENADA_NORTE { get; set; }
        [Description("COORDENADA_ESTE")]
        public Int32 COORDENADA_ESTE { get; set; }
        [Description("OBSERVACION")]
        public String OBSERVACION { get; set; }

        [Category("FK"), Description("COD_ESPECIES")]
        public String COD_ESPECIES { get; set; }
        [Description("BLOQUE")]
        public String BLOQUE { get; set; }
        [Description("FAJA")]
        public String FAJA { get; set; }
        [Description("DAP")]
        public Decimal DAP { get; set; }
        [Description("AC")]
        public Decimal AC { get; set; }
        [Description("COD_ACATEGORIA")]
        public String COD_ACATEGORIA { get; set; }
        [Description("COD_EESTADO")]
        public String COD_EESTADO { get; set; }
        [Category("FK"), Description("DESC_EESTADO")]
        public String DESC_EESTADO { get; set; }
        [Description("DESC_ACATEGORIA")]
        public String DESC_ACATEGORIA { get; set; }
        [Description("MAE_TIP_MADERABLE")]
        public String MAE_TIP_MADERABLE { get; set; }

        //entidades para Silviculturales
        [Description("CUMPLIMIENTO_ACTIVIDADES")]
        public Object CUMPLIMIENTO_ACTIVIDADES { get; set; }
        [Description("DESC_SILVICULTURALES")]
        public String DESC_SILVICULTURALES { get; set; }
        [Description("COD_ASILVICULTURALES")]
        public String COD_ASILVICULTURALES { get; set; }
        [Description("NUM_PLANTULAS")]
        public Int32 NUM_PLANTULAS { get; set; }
        [Description("UBICACION")]
        public String UBICACION { get; set; }
        [Description("TIEMPO")]
        public Int32 TIEMPO { get; set; }

        [Description("COD_ENCIENTIFICO")]
        public String COD_ENCIENTIFICO { get; set; }
        [Description("NOMBRE_COMUN")]
        public String NOMBRE_COMUN { get; set; }
        [Description("NOMBRE_CIENTIFICO")]
        public String NOMBRE_CIENTIFICO { get; set; }

        [Description("USUARIO_REGISTRO")]
        public String USUARIO_REGISTRO { get; set; }
        [Description("USUARIO_CONTROL")]
        public String USUARIO_CONTROL { get; set; }

        [Category("LIST"), Description("ListVolInjustificado")]
        public List<Ent_InfQuinquenal> ListVolInjustificado { get; set; }
        [Category("LIST"), Description("ListISupervLindAreaVertice")]
        public List<Ent_InfQuinquenal> ListISupervLindAreaVertice { get; set; }
        [Category("LIST"), Description("ListISupervCambioUso")]
        public List<Ent_InfQuinquenal> ListISupervCambioUso { get; set; }
        [Category("LIST"), Description("ListISupervMaderableNoAutorizado")]
        public List<Ent_InfQuinquenal> ListISupervMaderableNoAutorizado { get; set; }
        [Category("LIST"), Description("ListISupervMaderableAdicional")]
        public List<Ent_InfQuinquenal> ListISupervMaderableAdicional { get; set; }
        [Category("LIST"), Description("ListISDSilvicultutal")]
        public List<Ent_InfQuinquenal> ListISDSilvicultutal { get; set; }
        [Category("LIST"), Description("ListHuayronas")]
        public List<Ent_InfQuinquenal> ListHuayronas { get; set; }
        [Category("LIST"), Description("ListINFORMEItemsDetalle")]
        public List<Ent_InfQuinquenal> ListINFORMEItemsDetalle { get; set; }

        //Cambio de Uso
        [Description("AREA")]
        public Decimal AREA { get; set; }
        [Description("MAE_TIP_CAMBIOUSO")]
        public String MAE_TIP_CAMBIOUSO { get; set; }
        [Description("NOM_TIP_CAMBIOUSO")]
        public String NOM_TIP_CAMBIOUSO { get; set; }
        [Category("LIST"), Description("ListTipoCambioUso")]
        public List<Ent_INFORME> ListTipoCambioUso { get; set; }
        #endregion

        [Description("HALLAZGO")]
        public String HALLAZGO { get; set; }
        [Description("AUDITORIA_OK")]
        public Object AUDITORIA_OK { get; set; }
        [Description("AMPLIAR_CONTRATO")]
        public Object AMPLIAR_CONTRATO { get; set; }

        //01/10/2019: CLHC
        [Description("COD_ITIPO")]
        public String COD_ITIPO { get; set; }

        //26/11/2019 VERIFICADORES
        [Description("COD_VERIFICADOR")]
        public String COD_VERIFICADOR { get; set; }
        [Description("VERIFICADOR")]
        public String VERIFICADOR { get; set; }
        [Description("OBSERVACIONES")]
        public String OBSERVACIONES { get; set; }
        [Description("QUINQUENIO")]
        public Int32 QUINQUENIO { get; set; }

        //26/11/2019 BOTONES QUINQUENALES
        [Description("PRIM_QUIN")]
        public Object PRIM_QUIN { get; set; }
        [Description("SEC_QUIN")]
        public Object SEC_QUIN { get; set; }
        [Description("TER_QUIN")]
        public Object TER_QUIN { get; set; }
        [Description("CUART_QUIN")]
        public Object CUART_QUIN { get; set; }
        [Description("VALUE_VERIFICADOR")]
        public String VALUE_VERIFICADOR { get; set; }
        //[Description("ESTADO")]
        //public String ESTADO { get; set; }

        //22/07/2021 FECHAS DE AUDITORIA
        [Description("FECHA_INICIO_AUDITORIA")]
        public Object FECHA_INICIO_AUDITORIA { get; set; }
        [Description("FECHA_FIN_AUDITORIA")]
        public Object FECHA_FIN_AUDITORIA { get; set; }
        #endregion

        #region Listas
        [Category("LIST"), Description("ListProfesionales")]
        public List<Ent_InfQuinquenal> ListProfesionales { get; set; }
        [Category("LIST"), Description("ListRDQuinquenal")]
        public List<Ent_InfQuinquenal> ListRDQuinquenal { get; set; }
        [Category("LIST"), Description("ListEliTABLA")]
        public List<Ent_InfQuinquenal> ListEliTABLA { get; set; }
        [Category("LIST"), Description("ListParticipantes")]
        public List<Ent_InfQuinquenal> ListParticipantes { get; set; }
        [Category("LIST"), Description("ListInfraestructura")]
        public List<Ent_InfQuinquenal> ListInfraestructura { get; set; }
        [Category("LIST"), Description("ListPOAs")]
        public List<Ent_InfQuinquenal> ListPOAs { get; set; }
        [Category("LIST"), Description("ListInformeQuinquenales")]
        public List<Ent_InfQuinquenal> ListInformeQuinquenales { get; set; }
        [Category("LIST"), Description("ListVertices")]
        public List<Ent_InfQuinquenal> ListVertices { get; set; }
        [Category("LIST"), Description("ListISupervInfoDocument")]
        public List<Ent_InfQuinquenal> ListISupervInfoDocument { get; set; }
        [Category("LIST"), Description("ListISupervMadeNoMade")]
        public List<Ent_InfQuinquenal> ListISupervMadeNoMade { get; set; }
        [Category("LIST"), Description("listVerificadores1")]
        public List<Ent_InfQuinquenal> listVerificadores1 { get; set; }
        [Category("LIST"), Description("listVerificadores2")]
        public List<Ent_InfQuinquenal> listVerificadores2 { get; set; }
        [Category("LIST"), Description("listVerificadores3")]
        public List<Ent_InfQuinquenal> listVerificadores3 { get; set; }
        [Category("LIST"), Description("listVerificadores4")]
        public List<Ent_InfQuinquenal> listVerificadores4 { get; set; }
        [Category("LIST"), Description("ListHallazgos")]
        public List<Ent_InfQuinquenal> ListHallazgos { get; set; }
        [Category("LIST"), Description("ListVerificadores")]
        public List<Ent_InfQuinquenal> ListVerificadores { get; set; }
        [Category("LIST"), Description("ListConclusiones")]
        public List<Ent_IQUINQUENAL_DET_CONCLUSION> ListConclusiones { get; set; }
        #endregion

        #region Constructor
        public Ent_InfQuinquenal()
        {
            RegEstado = -1;
            EliVALOR02 = -1;
            POACalzada = -1;
            CampoCalzada = -1;
            CampoPendiente = -1;
            NUM_POA = -1;
            COORDENADA_ESTE = -1;
            COORDENADA_NORTE = -1;
            COD_SECUENCIAL = -1;
            AC = -1;
            NUMERO_FILA = -1;
            VOLUMEN = -1;
            NUM_PLANTULAS = -1;
            TIEMPO = -1;
            AREA = -1;
            INEX_AGUAJAL_PORC = -1;
            INEX_PASTIZAL_PORC = -1;
            INEX_INACCESIBLE_PORC = -1;
            INEX_OTROS_PORC = -1;
            INEX_AGUAJAL_NOUB = -1;
            INEX_PASTIZAL_NOUB = -1;
            INEX_INACCESIBLE_NOUB = -1;
            INEX_OTROS_NOUB = -1;
            DAP = -1;
            QUINQUENIO = -1;
            PRIM_QUIN = -1;
            SEC_QUIN = -1;
            TER_QUIN = -1;
            CUART_QUIN = -1;
        }
        #endregion
    }
    public class Ent_IQUINQUENAL_DET_CONCLUSION
    {
        [Description("COD_INFORME")]
        public String COD_INFORME { get; set; }
        [Description("QUINQUENIO")]
        public int QUINQUENIO { get; set; }
        [Description("CRITERIO_EVALUACION")]
        public String CRITERIO_EVALUACION { get; set; }
        [Description("ACLARACION_TITULAR")]
        public String ACLARACION_TITULAR { get; set; }
        [Description("IMPL_PMANEJO")]
        public String IMPL_PMANEJO { get; set; }
        [Description("CUMPL_OBLIGACION")]
        public String CUMPL_OBLIGACION { get; set; }
        [Description("CALIDAD_IMPL")]
        public String CALIDAD_IMPL { get; set; }
        [Description("OPINION_FAVORABLE")]
        public String OPINION_FAVORABLE { get; set; }
        [Description("DEMORA_NEGLIGENCIA")]
        public String DEMORA_NEGLIGENCIA { get; set; }
        [Description("ADVERTENCIA_CAUSAL")]
        public String ADVERTENCIA_CAUSAL { get; set; }
        [Description("AUDITORIA_OK")]
        public int AUDITORIA_OK { get; set; }
        [Description("AMPLIAR_CONTRATO")]
        public int AMPLIAR_CONTRATO { get; set; }
        [Description("COD_UCUENTA")]
        public String COD_UCUENTA { get; set; }

        public Ent_IQUINQUENAL_DET_CONCLUSION()
        {
            QUINQUENIO = -1;
            AUDITORIA_OK = -1;
            AMPLIAR_CONTRATO = -1;
        }
    }

    public class Parcela
    {

        [Description("CodParcela")]
        public int CodParcela { get; set; }
        [Description("CoordenadaPo1")]
        public string CoordenadaPo1 { get; set; }
        [Description("CoordenadaPo2")]
        public string CoordenadaPo2 { get; set; }
        [Description("CoordenadaCampo1")]
        public string CoordenadaCampo1 { get; set; }
        [Description("CoordenadaCampo2")]
        public string CoordenadaCampo2 { get; set; }
        [Description("coincidencia")]
        public string coincidencia { get; set; }
        [Description("senalizado")]
        public string senalizado { get; set; }
        [Description("quinquenal")]
        public int quinquenal { get; set; }
        [Description("codInforme")]
        public string codInforme { get; set; }

        public Parcela()
        {
            CodParcela = -1;
            quinquenal = -1;
        }
    }
    public class Trozas
    {
        [Description("CodTroza")]
        public int CodTroza { get; set; }
        [Description("Troza")]
        public string Troza { get; set; }
        [Description("CodigoToco")]
        public string CodigoToco { get; set; }
        [Description("CodigoTro")]
        public string CodigoTro { get; set; }
        [Description("XPO")]
        public string XPO { get; set; }
        [Description("YPO")]
        public string YPO { get; set; }
        [Description("XCAMPO")]
        public string XCAMPO { get; set; }
        [Description("YCAMPO")]
        public string YCAMPO { get; set; }
        [Description("Coincidencia")]
        public string Coincidencia { get; set; }
        [Description("quinquenal")]
        public int quinquenal { get; set; }
        [Description("codInforme")]
        public string codInforme { get; set; }
        public Trozas()
        {
            CodTroza = -1;
            quinquenal = -1;
        }
    }
}
