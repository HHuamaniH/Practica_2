using CapaEntidad.ViewModel.DOC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
//using CapaEntISEXSITU = CapaEntidad.DOC.Ent_ISUPERVISION_EXSITU_INFRA_AREA;
namespace CapaEntidad.DOC
{
    public class Ent_INFORME
    {
        #region "Entidades y Propiedades"
        //EPB   01/04/2020
        [Description("AREA_TH")]
        public Decimal AREA_TH { get; set; }
        [Description("AREA_POA")]
        public Decimal AREA_POA { get; set; }
        [Category("FECHA"), Description("FECHA_SALIDA_CAMPO")]
        public Object FECHA_SALIDA_CAMPO { get; set; }
        [Category("FECHA"), Description("FECHA_RECEPCION_CHEQUE")]
        public Object FECHA_RECEPCION_CHEQUE { get; set; }
        [Category("FECHA"), Description("FECHA_COBRO_CHEQUE")]
        public Object FECHA_COBRO_CHEQUE { get; set; }
        [Category("FECHA"), Description("FECHA_REGRESO_CAMPO")]
        public Object FECHA_REGRESO_CAMPO { get; set; }
        [Category("FECHA"), Description("FECHA_INICIO_LABORES")]
        public Object FECHA_INICIO_LABORES { get; set; }
        [Description("ELAB_TERCERO")]
        public String ELAB_TERCERO { get; set; }
        //
        [Description("CUENTA_SENDERO_RUTA")]
        public Object CUENTA_SENDERO_RUTA { get; set; }
        [Description("NOMBRE_COMUNIDAD_SECTOR")]
        public String NOMBRE_COMUNIDAD_SECTOR { get; set; }
        [Description("COD_ESTADO_DOC")]
        public String COD_ESTADO_DOC { get; set; }
        [Description("OBSERVACIONES_CONTROL")]
        public Object OBSERVACIONES_CONTROL { get; set; }
        [Description("OBSERV_SUBSANAR")]
        public Object OBSERV_SUBSANAR { get; set; }
        [Description("PUBLICAR")]
        public Object PUBLICAR { get; set; }
        [Description("RECOMENDARC")]
        public Object RECOMENDARC { get; set; }
        [Description("MANDATOC")]
        public String MANDATOC { get; set; }
        [Description("CONCLUSIONC")]
        public String CONCLUSIONC { get; set; }
        [Description("RECOMENDACIONC")]
        public String RECOMENDACIONC { get; set; }
        [Description("TODOSINDICADORES")]
        public Object TODOSINDICADORES { get; set; }
        [Description("HECHOSDENUNCIADOS")]
        public Object HECHOSDENUNCIADOS { get; set; }
        [Description("MANDATOS")]
        public Object MANDATOS { get; set; }
        [Description("MEDIDASCORRECTIVAS")]
        public Object MEDIDASCORRECTIVAS { get; set; }
        [Description("FFPROPIAS")]
        public Object FFPROPIAS { get; set; }
        [Description("FFDONACIONES")]
        public Object FFDONACIONES { get; set; }
        [Description("FFCREDITO")]
        public Object FFCREDITO { get; set; }
        [Description("FFINVERSIONISTA")]
        public Object FFINVERSIONISTA { get; set; }
        [Description("FFAPOYO")]
        public Object FFAPOYO { get; set; }
        [Description("FFVOLUNTARIO")]
        public Object FFVOLUNTARIO { get; set; }
        [Description("FFOTRO")]
        public String FFOTRO { get; set; }
        //
        [Description("TIPO")]
        public String TIPO { get; set; }
        [Description("TIPO_PROGRAMA")]
        public String TIPO_PROGRAMA { get; set; }
        [Description("COD_DLINEA")]
        public String COD_DLINEA { get; set; }
        [Description("ANTECEDENTE")]
        public String ANTECEDENTE { get; set; }
        [Description("OBJETIVO")]
        public String OBJETIVO { get; set; }
        [Description("EQUIPOS_MATERIALES")]
        public String EQUIPOS_MATERIALES { get; set; }
        [Description("METODOLOGIA")]
        public String METODOLOGIA { get; set; }
        [Description("ESTADO_MAPAS_CINFORMACION")]
        public Object ESTADO_MAPAS_CINFORMACION { get; set; }
        [Description("EXISTEN_FOREST_REFOREST")]
        public Object EXISTEN_FOREST_REFOREST { get; set; }
        [Description("MAPAS_CINFORMACION")]
        public String MAPAS_CINFORMACION { get; set; }
        [Description("ESTAB_AREA_MANEJO")]
        public String ESTAB_AREA_MANEJO { get; set; }
        [Description("ESTAB_PLANTACION")]
        public String ESTAB_PLANTACION { get; set; }
        [Description("OBSERV_FOREST_REFOREST")]
        public String OBSERV_FOREST_REFOREST { get; set; }

        [Description("CAPACITACION_NOMBRE")]
        public String CAPACITACION_NOMBRE { get; set; }
        [Description("CAPACITACION_DESCRIPCION")]
        public String CAPACITACION_DESCRIPCION { get; set; }
        [Description("COMERCIALIZACION")]
        public String COMERCIALIZACION { get; set; }
        [Description("ANALISIS_RACERVO")]
        public String ANALISIS_RACERVO { get; set; }
        [Description("CONCLUSION")]
        public String CONCLUSION { get; set; }
        [Description("RECOMENDACION")]
        public String RECOMENDACION { get; set; }

        [Description("COD_PPLANTON")]
        public Int32 COD_PPLANTON { get; set; }
        [Description("OBSERV_PROD_PLANTONES")]
        public String OBSERV_PROD_PLANTONES { get; set; }
        [Description("COD_TCONCEPTO")]
        public Int32 COD_TCONCEPTO { get; set; }
        [Description("ESTADO_MPLANTACION")]
        public Object ESTADO_MPLANTACION { get; set; }

        [Description("PREDIO_AREA")]
        public Decimal PREDIO_AREA { get; set; }
        [Description("NUM_MUESTRA")]
        public String NUM_MUESTRA { get; set; }
        [Description("N_ARBOL_SUPERVISADO")]
        public Int32 N_ARBOL_SUPERVISADO { get; set; }
        [Description("N_ARBOL_PRODUCTIVO")]
        public Int32 N_ARBOL_PRODUCTIVO { get; set; }
        [Description("N_ARBOL_NOPRODUCTIVO")]
        public Int32 N_ARBOL_NOPRODUCTIVO { get; set; }
        [Description("N_ARBOL_PLANTADO")]
        public Int32 N_ARBOL_PLANTADO { get; set; }
        [Description("N_ARBOL_NOENCONTRADO")]
        public Int32 N_ARBOL_NOENCONTRADO { get; set; }
        //ARBOLES SUPERVISADO
        [Description("CODIGO_ARBOL")]
        public String CODIGO_ARBOL { get; set; }
        [Description("VAINAS_COD_PRESENCIA")]
        public Int32 VAINAS_COD_PRESENCIA { get; set; }
        [Description("PRES_FLORES")]
        public Object PRES_FLORES { get; set; }
        [Description("PRES_PLAGA_ENFERMEDA")]
        public String PRES_PLAGA_ENFERMEDA { get; set; }
        [Description("PRES_PLANTA_PARASITARIA")]
        public String PRES_PLANTA_PARASITARIA { get; set; }
        [Description("ALTURA_TOTAL")]
        public Decimal ALTURA_TOTAL { get; set; }
        [Description("COORDENADA_NORTE")]
        public Int32 COORDENADA_NORTE { get; set; }
        [Description("COORDENADA_ESTE")]
        public Int32 COORDENADA_ESTE { get; set; }

        //informe_campo


        [Description("B_POA")]
        public Int32 B_POA { get; set; }

        [Description("CODIGO_SEC_NOPOA")]
        public String CODIGO_SEC_NOPOA { get; set; }
        [Description("BLOQUE_CAMPO")]
        public String BLOQUE_CAMPO { get; set; }
        [Description("FAJA_CAMPO")]
        public String FAJA_CAMPO { get; set; }
        [Description("CODIGO_CAMPO")]
        public String CODIGO_CAMPO { get; set; }
        [Description("DAP_CAMPO")]
        public Decimal DAP_CAMPO { get; set; }
        [Description("AC_CAMPO")]
        public Decimal AC_CAMPO { get; set; }
        //[Description("CODIGO_SISTEMA")]
        //public String CODIGO_SISTEMA { get; set; }
        [Description("ESTADO_CAMPO")]
        public String ESTADO_CAMPO { get; set; }
        [Description("CONDICION_CAMPO")]
        public String CONDICION_CAMPO { get; set; }
        [Description("COD_EESTADO")]
        public String COD_EESTADO { get; set; }

        [Description("COORDENADA_ESTE_CAMPO")]
        public Int32 COORDENADA_ESTE_CAMPO { get; set; }
        [Description("COORDENADA_NORTE_CAMPO")]
        public Int32 COORDENADA_NORTE_CAMPO { get; set; }
        [Category("LIST"), Description("ListISUPERVISION_INFRAESTRUCTURA")]
        public List<Ent_INFORME> ListISUPERVISION_INFRAESTRUCTURA { get; set; }
        //[Description("GRADO_AMENAZA")]
        //public String GRADO_AMENAZA { get; set; }
        [Description("OBSERVACION_CAMPO")]
        public String OBSERVACION_CAMPO { get; set; }
        [Description("COD_SISTEMA")]
        public String COD_SISTEMA { get; set; }
        //[Description("COD_ACATEGORIA")]
        //public String COD_ACATEGORIA { get; set; }
        [Description("COD_ESPECIES_CAMPO")]
        public String COD_ESPECIES_CAMPO { get; set; }

        [Description("TIPOMADERABLE")]
        public String TIPOMADERABLE { get; set; }

        // No Maderable
        [Description("NUM_ESTRADA")]
        public String NUM_ESTRADA { get; set; }
        [Description("NUM_ESTRADA_CAMPO")]
        public String NUM_ESTRADA_CAMPO { get; set; }
        [Description("DIAMETRO_CAMPO")]
        public decimal DIAMETRO_CAMPO { get; set; }
        [Description("ALTURA_CAMPO")]
        public decimal ALTURA_CAMPO { get; set; }
        [Description("PRODUCCION_LATAS_CAMPO")]
        public decimal PRODUCCION_LATAS_CAMPO { get; set; }

        [Description("BS_ALTURA_TOTAL")]
        public decimal BS_ALTURA_TOTAL { get; set; }
        [Description("BS_DIAMETRO_RAMA_1")]
        public decimal BS_DIAMETRO_RAMA_1 { get; set; }
        [Description("BS_DIAMETRO_RAMA_2")]
        public decimal BS_DIAMETRO_RAMA_2 { get; set; }
        [Description("BS_DIAMETRO_RAMA_3")]
        public decimal BS_DIAMETRO_RAMA_3 { get; set; }
        [Description("BS_DIAMETRO_RAMA_4")]
        public decimal BS_DIAMETRO_RAMA_4 { get; set; }
        [Description("BS_DIAMETRO_RAMA_5")]
        public decimal BS_DIAMETRO_RAMA_5 { get; set; }
        [Description("BS_DIAMETRO_RAMA_6")]
        public decimal BS_DIAMETRO_RAMA_6 { get; set; }
        [Description("BS_DIAMETRO_RAMA_7")]
        public decimal BS_DIAMETRO_RAMA_7 { get; set; }
        [Description("BS_LONGITUD_RAMA_1")]
        public decimal BS_LONGITUD_RAMA_1 { get; set; }
        [Description("BS_LONGITUD_RAMA_2")]
        public decimal BS_LONGITUD_RAMA_2 { get; set; }
        [Description("BS_LONGITUD_RAMA_3")]
        public decimal BS_LONGITUD_RAMA_3 { get; set; }
        [Description("BS_LONGITUD_RAMA_4")]
        public decimal BS_LONGITUD_RAMA_4 { get; set; }
        [Description("BS_LONGITUD_RAMA_5")]
        public decimal BS_LONGITUD_RAMA_5 { get; set; }
        [Description("BS_LONGITUD_RAMA_6")]
        public decimal BS_LONGITUD_RAMA_6 { get; set; }
        [Description("BS_LONGITUD_RAMA_7")]
        public decimal BS_LONGITUD_RAMA_7 { get; set; }
        [Description("COD_TIPO_SUPER")]
        public string COD_TIPO_SUPER { get; set; }
        //TGS:19/08/2021
        [Description("TIPO_INFORME")]
        public string TIPO_INFORME { get; set; }

        // [Description("C_ABIERTO")]
        //public Int32 C_ABIERTO { get; set; }
        // [Description("C_CERRADO")]
        // public Int32 C_CERRADO { get; set; }




        //Aprovechamiento
        [Description("N_ARBOL_FVERDE")]
        public Int32 N_ARBOL_FVERDE { get; set; }
        [Description("N_ARBOL_FVERDE_MADURO")]
        public Int32 N_ARBOL_FVERDE_MADURO { get; set; }
        [Description("N_ARBOL_FLOR")]
        public Int32 N_ARBOL_FLOR { get; set; }
        [Description("N_ARBOL_NOFRUTO")]
        public Int32 N_ARBOL_NOFRUTO { get; set; }
        [Description("NUM_PERSONA")]
        public Int32 NUM_PERSONA { get; set; }

        [Description("ID_TRAMITE_SITD")]
        public Int32 ID_TRAMITE_SITD { get; set; }
        [Description("PROMOVIDO")]
        public Object PROMOVIDO { get; set; }

        [Category("LIST"), Description("ListISUPERVISION_DET_TARA_CONCEPTO_OTROS")]
        public List<Ent_INFORME> ListISUPERVISION_DET_TARA_CONCEPTO_OTROS { get; set; }

        [Category("LIST"), Description("ListISUPERVISION_DET_TARA_CONCEPTO")]
        public List<Ent_INFORME> ListISUPERVISION_DET_TARA_CONCEPTO { get; set; }
        [Category("LIST"), Description("ListISUPERVISION_DET_TARA_CENSO")]
        public List<Ent_INFORME> ListISUPERVISION_DET_TARA_CENSO { get; set; }
        [Category("LIST"), Description("ListISUPERVISION_DET_TARA_APROV")]
        public List<Ent_INFORME> ListISUPERVISION_DET_TARA_APROV { get; set; }
        [Category("LIST"), Description("ListISUPERVISION_DET_TARA_KARDEX")]
        public List<Ent_INFORME> ListISUPERVISION_DET_TARA_KARDEX { get; set; }
        [Category("LIST"), Description("ListISUPERVISION_DET_TARA_PFRUTOS")]
        public List<Ent_INFORME> ListISUPERVISION_DET_TARA_PFRUTOS { get; set; }
        [Category("LIST"), Description("ListISUPERVISION_DET_TARA_APFORESTAL")]
        public List<Ent_INFORME> ListISUPERVISION_DET_TARA_APFORESTAL { get; set; }
        [Category("LIST"), Description("ListISUPERVISION_DET_TARA_CAPACITACION")]
        public List<Ent_INFORME> ListISUPERVISION_DET_TARA_CAPACITACION { get; set; }
        [Category("LIST"), Description("ListIndicador")]
        public List<Ent_INFORME> ListIndicador { get; set; }
        [Category("LIST"), Description("ListODs")]
        public List<Ent_INFORME> ListODs { get; set; }
        [Category("LIST"), Description("ListModEgreso")]
        public List<Ent_INFORME> ListModEgreso { get; set; }
        [Category("LIST"), Description("ListButtonParcelaCorta")]
        public List<Ent_SBusqueda> ListButtonParcelaCorta { get; set; }
        //Kardex FECHA_EMISION_DLINEA
        //[Category("FECHA"), Description("FECHA_EMISION_DLINEA")]
        //public Object FECHA_EMISION_DLINEA { get; set; }
        [Category("FECHA"), Description("FECHA_SUPERVISION_INICIO")]
        public Object FECHA_SUPERVISION_INICIO { get; set; }
        [Category("FECHA"), Description("FECHA_SUPERVISION_FIN")]
        public Object FECHA_SUPERVISION_FIN { get; set; }
        [Description("N_GUIA_TRANSPORTE")]
        public String N_GUIA_TRANSPORTE { get; set; }
        [Category("FECHA"), Description("FECHA_EMISION")]
        public Object FECHA_EMISION { get; set; }
        [Description("CANTIDAD_AQUINTAL")]
        public Int32 CANTIDAD_AQUINTAL { get; set; }
        [Description("TOTAL_SQUINTAL")]
        public Decimal TOTAL_SQUINTAL { get; set; }
        [Description("SALDO_QUINTAL")]
        public Decimal SALDO_QUINTAL { get; set; }
        [Description("SALDO_MTRES")]
        public Decimal SALDO_MTRES { get; set; }
        [Description("ZAFRA")]
        public String ZAFRA { get; set; }
        [Category("FK"), Description("DESTINO_COD_UBIGEO")]
        public String DESTINO_COD_UBIGEO { get; set; }
        [Description("ESTADO_DOCUMENTO")]
        public Object ESTADO_DOCUMENTO { get; set; }
        [Category("FECHA"), Description("FECHA_REALIZADA")]
        public Object FECHA_REALIZADA { get; set; }
        [Category("FECHA"), Description("HORA")]
        public Object HORA { get; set; }
        [Description("ACTIVIDAD")]
        public String ACTIVIDAD { get; set; }
        [Description("ACTIVIDAD_REALIZADA")]
        public String ACTIVIDAD_REALIZADA { get; set; }
        [Description("COD_PROGRAMA")]
        public Int32 COD_PROGRAMA { get; set; }
        [Description("VERTICE")]
        public String VERTICE { get; set; }
        //
        [Description("AVANCE_RESULTADO")]
        public String AVANCE_RESULTADO { get; set; }
        [Description("PRIMERA_COSECHA")]
        public Decimal PRIMERA_COSECHA { get; set; }
        [Description("SEGUNDA_COSECHA")]
        public Decimal SEGUNDA_COSECHA { get; set; }
        [Description("TOTAL_PROD_ANUAL")]
        public Decimal TOTAL_PROD_ANUAL { get; set; }
        //APROVECHAMIENTO FORESTAL
        [Description("P_ARBOL_PRODUCTIVO")]
        public Decimal P_ARBOL_PRODUCTIVO { get; set; }
        [Description("P_ARBOL_NOPRODUCTIVO")]
        public Decimal P_ARBOL_NOPRODUCTIVO { get; set; }
        [Description("P_ARBOL_PLANTADO")]
        public Decimal P_ARBOL_PLANTADO { get; set; }
        [Description("CANTIDAD_AEXTRAER")]
        public Decimal CANTIDAD_AEXTRAER { get; set; }
        [Description("CANTIDAD_EXTRAIDA")]
        public Decimal CANTIDAD_EXTRAIDA { get; set; }
        [Description("CANTIDAD_SUPERVISADO")]
        public Decimal CANTIDAD_SUPERVISADO { get; set; }
        [Description("CANTIDAD_INJUSTIFICADA")]
        public Decimal CANTIDAD_INJUSTIFICADA { get; set; }

        //Volumen Justificado
        [Description("JUSTIFICADO")]
        public Object JUSTIFICADO { get; set; }

        [Category("LIST"), Description("ListISUPERVISION_DET_CAPACITACION_LOCAL")]
        public List<Ent_INFORME> ListISUPERVISION_DET_CAPACITACION_LOCAL { get; set; }
        [Category("LIST"), Description("ListISUPERVISION_COORDENADAUTM")]
        public List<Ent_INFORME> ListISUPERVISION_COORDENADAUTM { get; set; }
        [Category("LIST"), Description("ListISUPERVISION_INVESTIGACION")]
        public List<Ent_INFORME> ListISUPERVISION_INVESTIGACION { get; set; }
        [Category("LIST"), Description("ListISUPERVISION_INTERAMBIENTAL")]
        public List<Ent_INFORME> ListISUPERVISION_INTERAMBIENTAL { get; set; }
        [Category("LIST"), Description("ListISUPERVISION_PROMOMARKETING")]
        public List<Ent_INFORME> ListISUPERVISION_PROMOMARKETING { get; set; }
        [Category("LIST"), Description("ListISUPERVISION_MONITOEVALUACION")]
        public List<Ent_INFORME> ListISUPERVISION_MONITOEVALUACION { get; set; }
        [Category("LIST"), Description("ListISUPERVISION_IDENTMANEJOIMPACTO")]
        public List<Ent_INFORME> ListISUPERVISION_IDENTMANEJOIMPACTO { get; set; }
        [Category("LIST"), Description("ListISUPERVISION_DET_PROGRAMA")]
        public List<Ent_INFORME> ListISUPERVISION_DET_PROGRAMA { get; set; }

        [Category("OUTPUT"), Description("OUTPUTPARAM01")]
        public Object OUTPUTPARAM01 { get; set; }

        [Description("ASUNTO")]
        public String ASUNTO { get; set; }

        [Description("B_DENUNCIA")]
        public int B_DENUNCIA { get; set; }

        [Description("ESTADO_OCONTRACTUAL")]
        public Object ESTADO_OCONTRACTUAL { get; set; }

        [Description("COD_OCONTRACTUAL")]
        public String COD_OCONTRACTUAL { get; set; }

        [Description("ACTIVIDAD_ACTOS")]
        public String ACTIVIDAD_ACTOS { get; set; }

        [Description("DOCUMENTOS_AFORESTAL")]
        public String DOCUMENTOS_AFORESTAL { get; set; }

        [Description("ESTA_AUTORIZADO")]
        public Object ESTA_AUTORIZADO { get; set; }

        [Description("CONTENIDO")]
        public Object CONTENIDO { get; set; }

        //[Category("FK"), Description("COD_PSUPERVISION")]
        //public String COD_PSUPERVISION { get; set; }

        [Description("COD_INFORME")]
        public String COD_INFORME { get; set; }
         
        [Description("COD_SECUENCIAL_POA")]
        public Int32 COD_SECUENCIAL_POA { get; set; }

        [Description("NUMERO")]
        public String NUMERO { get; set; }

        [Category("FK"), Description("COD_ITIPO")]
        public String COD_ITIPO { get; set; }

        [Description("UBIGEO")]
        public String UBIGEO { get; set; }

        [Category("FK"), Description("COD_IMOTIVO")]
        public String COD_IMOTIVO { get; set; }
        [Description("IMOTIVO")]
        public String IMOTIVO { get; set; }
        [Description("CUENTAMEDVET")]
        public String CUENTAMEDVET { get; set; }
        [Description("TIPOVISMED")]
        public String TIPOVISMED { get; set; }
        [Description("VISITAMES")]
        public String VISITAMES { get; set; }
        [Description("OBSMEDVET")]
        public String OBSMEDVET { get; set; }

        [Category("FECHA"), Description("FECHA_ENTREGA")]
        public Object FECHA_ENTREGA { get; set; }

        //[Category("FECHA"), Description("FECHA_CREACION")]
        //public Object FECHA_CREACION { get; set; }

        [Category("FECHA"), Description("FECHA_RECEPCION_OD")]
        public Object FECHA_RECEPCION_OD { get; set; }

        [Category("FECHA"), Description("FECHA_RECEPCION_SCENTRAL")]
        public Object FECHA_RECEPCION_SCENTRAL { get; set; }

        //[Category("FECHA"), Description("FECHA_EMISION_DIRECCION")]
        //public Object FECHA_EMISION_DIRECCION { get; set; }

        [Category("FK"), Description("THABILITANTE_COD_UBIGEO")]
        public String THABILITANTE_COD_UBIGEO { get; set; }

        [Description("THABILITANTE_SECTOR")]
        public String THABILITANTE_SECTOR { get; set; }

        [Description("AREA_RECORRIDA")]
        public Decimal AREA_RECORRIDA { get; set; }

        [Description("COD_UCUENTA")]
        public String COD_UCUENTA { get; set; }
        [Description("ESTADO_ORIGEN")]
        public String ESTADO_ORIGEN { get; set; }
        [Description("OBSERVACION")]
        public String OBSERVACION { get; set; }
        [Description("CUENTA_AREPOSICION")]
        public String CUENTA_AREPOSICION { get; set; }
        [Description("AREA_DEMARCACION")]
        public String AREA_DEMARCACION { get; set; }
        [Description("AREA_LINDERAMIENTO")]
        public String AREA_LINDERAMIENTO { get; set; }
        [Description("USO_LCALONGITUDINAL")]
        public Object USO_LCALONGITUDINAL { get; set; }
        [Description("TIPO_SAPROVECHAMIENTO")]
        public String TIPO_SAPROVECHAMIENTO { get; set; }
        [Description("PHUAYRONA_ESTADO")]
        public String PHUAYRONA_ESTADO { get; set; }
        [Description("RECORRIDO_SUPERVISION")]
        public String RECORRIDO_SUPERVISION { get; set; }
        [Category("FK"), Description("COD_DIRECTOR")]
        public String COD_DIRECTOR { get; set; }
        [Description("NOMBRE_DIRECTOR")]
        public String NOMBRE_DIRECTOR { get; set; }
        [Description("CODIGO")]
        public String CODIGO { get; set; }
        [Category("FK"), Description("COD_MTIPO")]
        public String COD_MTIPO { get; set; }
        [Description("MODALIDAD_TIPO")]
        public String MODALIDAD_TIPO { get; set; }
        [Description("DESCRIPCION")]
        public String DESCRIPCION { get; set; }

        [Description("MADERABLE")]
        public Object MADERABLE { get; set; }

        [Description("NO_MADERABLE")]
        public Object NO_MADERABLE { get; set; }

        [Description("ADICIONAL")]
        public Object ADICIONAL { get; set; }

        [Description("BusFormulario")]
        public String BusFormulario { get; set; }
        [Description("BusCriterio")]
        public String BusCriterio { get; set; }
        [Description("BusValor")]
        public String BusValor { get; set; }

        [Description("RegEstado")]
        public Int32 RegEstado { get; set; }
        [Description("COD_OD_REGISTRO")]
        public String COD_OD_REGISTRO { get; set; }

        [Description("COD_THABILITANTE")]
        public String COD_THABILITANTE { get; set; }

        [Description("NUM_THABILITANTE")]
        public String NUM_THABILITANTE { get; set; }

        [Description("NUM_POA")]
        public Int32 NUM_POA { get; set; }

        [Description("COD_PARCELA")]
        public String COD_PARCELA { get; set; }

        [Description("POA")]
        public String POA { get; set; }
        [Description("NOMBRE_POA")]
        public String NOMBRE_POA { get; set; }
        [Description("FCTIPO")]
        public String FCTIPO { get; set; }

        [Description("COD_CNOTIFICACION")]
        public String COD_CNOTIFICACION { get; set; }
        [Description("COD_FISNOTI")]
        public String COD_FISNOTI { get; set; }

        [Description("NUM_CNOTIFICACION")]
        public String NUM_CNOTIFICACION { get; set; }
        [Description("NUM_NOTIFICACION")]
        public String NUM_NOTIFICACION { get; set; }

        [Description("ANO")]
        public Int32 ANO { get; set; }


        [Description("COD_PERSONA")]
        public String COD_PERSONA { get; set; }
        [Description("COD_SECUENCIAL")]
        public Int32 COD_SECUENCIAL { get; set; }
       
        [Category("FK"), Description("COD_ESPECIES")]
        public String COD_ESPECIES { get; set; }
        [Description("ESPECIES")]
        public String ESPECIES { get; set; }

        [Description("NOMBRES")]
        public String NOMBRES { get; set; }

        //INFORME EX SITU

        [Description("LICENCIA_ESTADO")]
        public Object LICENCIA_ESTADO { get; set; }
        [Description("LICENCIA_NUMERO")]
        public String LICENCIA_NUMERO { get; set; }
        [Description("CUENTA_CROQUIS")]
        public Object CUENTA_CROQUIS { get; set; }
        [Description("TIENE_VIAS")]
        public Object TIENE_VIAS { get; set; }
        [Category("FK"), Description("RESPONSABLE_COD_PERSONA")]
        public String RESPONSABLE_COD_PERSONA { get; set; }
        [Description("RESPONSABLE_NOMBRE")]
        public String RESPONSABLE_NOMBRE { get; set; }
        [Description("PROGRAMA_ALIMENTACION")]
        public Object PROGRAMA_ALIMENTACION { get; set; }
        [Description("PICIENTIFICA_IREALIZADA")]
        public Object PICIENTIFICA_IREALIZADA { get; set; }
        [Description("PICIENTIFICA_PUBLICADA")]
        public Object PICIENTIFICA_PUBLICADA { get; set; }

        [Category("FK"), Description("FLIMPIEZA_COD_TDESCRIPTIVA")]
        public String FLIMPIEZA_COD_TDESCRIPTIVA { get; set; }

        [Description("PROTOCOLO_LIMPIEZA")]
        public Object PROTOCOLO_LIMPIEZA { get; set; }

        [Description("PEDILUVIOS")]
        public Object PEDILUVIOS { get; set; }

        [Description("MANEJO_RESIDUOS_SOLIDOS")]
        public Object MANEJO_RESIDUOS_SOLIDOS { get; set; }

        [Category("FK"), Description("FDESINFECCION_COD_TDESCRIPTIVA")]
        public String FDESINFECCION_COD_TDESCRIPTIVA { get; set; }

        [Category("FK"), Description("DRINORGANICO_COD_TDESCRIPTIVA")]
        public String DRINORGANICO_COD_TDESCRIPTIVA { get; set; }

        [Category("FK"), Description("DRORGANICO_COD_TDESCRIPTIVA")]
        public String DRORGANICO_COD_TDESCRIPTIVA { get; set; }

        [Category("FK"), Description("DCADAVERES_COD_TDESCRIPTIVA")]
        public String DCADAVERES_COD_TDESCRIPTIVA { get; set; }

        [Description("CONTROL_PLAGAS")]
        public Object CONTROL_PLAGAS { get; set; }

        [Description("LUGAR_CAPACITACION")]
        public String LUGAR_CAPACITACION { get; set; }

        [Description("NOMBRE_ZONA")]
        public String NOMBRE_ZONA { get; set; }

        [Description("CARACTERISTICA")]
        public String CARACTERISTICA { get; set; }

        [Description("TIPO_SENALIZACION")]
        public String TIPO_SENALIZACION { get; set; }

        [Description("TIPO_DELIMITACION")]
        public String TIPO_DELIMITACION { get; set; }

        [Description("AREA_CUARENTENA_ALEJADO")]
        public Object AREA_CUARENTENA_ALEJADO { get; set; }

        [Description("AREA_ADMINISTRATIVA_TCARTEL")]
        public Object AREA_ADMINISTRATIVA_TCARTEL { get; set; }

        [Description("AREA_SHIGIENICO_TCARTEL")]
        public Object AREA_SHIGIENICO_TCARTEL { get; set; }

        [Description("AREA_OTROS_OBSERVACION")]
        public String AREA_OTROS_OBSERVACION { get; set; }

        /// <summary>
        /// ISUPERVISION_DET_EMADERABLE
        /// </summary>       

        [Description("COD_ENCIENTIFICO")]
        public String COD_ENCIENTIFICO { get; set; }
        [Description("NOMBRE_CIENTIFICO")]
        public String NOMBRE_CIENTIFICO { get; set; }


        [Description("BLOQUE")]
        public String BLOQUE { get; set; }

        [Description("DMC")]
        public Int32 DMC { get; set; }
        [Description("VOLUMEN")]
        public Decimal VOLUMEN { get; set; }
        [Description("FAJA")]
        public String FAJA { get; set; }

        [Category("FK"), Description("COD_EFITOSANITARIO")]
        public String COD_EFITOSANITARIO { get; set; }
        [Category("FK"), Description("DESC_EFITOSANITARIO")]
        public String DESC_EFITOSANITARIO { get; set; }
        [Description("ESTADO_SUPERVISION")]
        public Object ESTADO_SUPERVISION { get; set; }

        [Description("DIAMETRO")]
        public Decimal DIAMETRO { get; set; }

        [Description("ALTURA")]
        public Decimal ALTURA { get; set; }

        [Description("AC")]
        public Decimal AC { get; set; }

        [Description("PRODUCCION_LATAS")]
        public Decimal PRODUCCION_LATAS { get; set; }

        [Description("NUM_COCOS_ABIERTOS")]
        public Int32 NUM_COCOS_ABIERTOS { get; set; }
        [Description("NUM_COCOS_CERRADOS")]
        public Int32 NUM_COCOS_CERRADOS { get; set; }
        [Description("ESTADO_MUESTRA")]
        public Object ESTADO_MUESTRA { get; set; }
        [Category("FK"), Description("COD_ECONDICION")]
        public String COD_ECONDICION { get; set; }
        [Description("COD_ECONDICION_CAMPO")]
        public String COD_ECONDICION_CAMPO { get; set; }
        [Description("DESC_ECONDICION")]
        public String DESC_ECONDICION { get; set; }
        [Category("FK"), Description("DESC_ECONDICION_CAMPO")]
        public String DESC_ECONDICION_CAMPO { get; set; }
        [Category("FK"), Description("DESC_EESTADO")]
        public String DESC_EESTADO { get; set; }
        [Category("FK"), Description("DESC_EESTADO_CAMPO")]
        public String DESC_EESTADO_CAMPO { get; set; }

        [Description("DESC_ACATEGORIA_CITE")]
        public String DESC_ACATEGORIA_CITE { get; set; }
        [Description("DESC_ACATEGORIA_DS")]
        public String DESC_ACATEGORIA_DS { get; set; }
        [Category("FK"), Description("COD_CFUSTE")]
        public String COD_CFUSTE { get; set; }
        [Category("FK"), Description("COD_FCOPA")]
        public String COD_FCOPA { get; set; }
        [Category("FK"), Description("COD_PCOPA")]
        public String COD_PCOPA { get; set; }
        [Category("FK"), Description("COD_EFENOLOGICO")]
        public String COD_EFENOLOGICO { get; set; }
        [Category("FK"), Description("COD_ESANITARIO")]
        public String COD_ESANITARIO { get; set; }
        [Category("FK"), Description("COD_ILIANAS")]
        public String COD_ILIANAS { get; set; }
        [Category("FK"), Description("DESC_CFUSTE")]
        public String DESC_CFUSTE { get; set; }
        [Category("FK"), Description("DESC_FCOPA")]
        public String DESC_FCOPA { get; set; }
        [Category("FK"), Description("DESC_PCOPA")]
        public String DESC_PCOPA { get; set; }
        [Category("FK"), Description("DESC_EFENOLOGICO")]
        public String DESC_EFENOLOGICO { get; set; }
        [Category("FK"), Description("DESC_ESANITARIO")]
        public String DESC_ESANITARIO { get; set; }
        [Category("FK"), Description("DESC_ILIANAS")]
        public String DESC_ILIANAS { get; set; }
        [Description("ESTADO_FILA")]
        public Int32 ESTADO_FILA { get; set; }
        [Description("NUMERO_FILA")]
        public Int32 NUMERO_FILA { get; set; }
        //[Category("LIST"), Description("oListSupervision_Rama")]
        //public List<Ent_INFORME> oListSupervision_Rama { get; set; }
        [Description("VIGENCIA")]
        public String VIGENCIA { get; set; }
        /// <summary>
        /// ISUPERVISION_DET_EMADERABLE
        /// </summary>


        //Supervisiones Fauna
        [Description("REALIZA_PCONTENCION")]
        public String REALIZA_PCONTENCION { get; set; }
        [Description("REALIZA_PBIOSEGURIDAD")]
        public String REALIZA_PBIOSEGURIDAD { get; set; }
        [Description("REALIZA_PENRIQUECIMIENTO")]
        public String REALIZA_PENRIQUECIMIENTO { get; set; }
        [Description("REALIZA_PMANEJOGEN")]
        public String REALIZA_PMANEJOGEN { get; set; }
        [Description("REALIZA_PEDUCAMB")]
        public String REALIZA_PEDUCAMB { get; set; }
        [Description("REALIZA_PINVCIENT")]
        public String REALIZA_PINVCIENT { get; set; }
        [Description("REALIZA_PCOLECTA")]
        public String REALIZA_PCOLECTA { get; set; }




        /// <summary>
        /// Entidad ASILVICULTURALES
        /// </summary>


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

        /// <summary>
        /// Entidad ASILVICULTURALES
        /// </summary>






        [Category("LIST"), Description("ListISupervision_Motivo")]
        public List<Ent_INFORME> ListISupervision_Motivo { get; set; }
        [Category("LIST"), Description("ListMComboDIdentidad")]
        public List<Ent_INFORME> ListMComboDIdentidad { get; set; }
        [Category("LIST"), Description("ListMComboPSuperConcepto")]
        public List<Ent_INFORME> ListMComboPSuperConcepto { get; set; }
        [Category("LIST"), Description("ListComboPresenciaVaina")]
        public List<Ent_INFORME> ListComboPresenciaVaina { get; set; }
        [Category("LIST"), Description("ListEspeciesCondicion")]
        public List<Ent_INFORME> ListEspeciesCondicion { get; set; }
        [Category("LIST"), Description("ListEspeciesDetFauna")]
        public List<Ent_INFORME> ListEspeciesDetFauna { get; set; }
        [Category("LIST"), Description("ListEspeciesDetFlora")]
        public List<Ent_INFORME> ListEspeciesDetFlora { get; set; }
        [Category("LIST"), Description("ListEspeciesDetDatos")]
        public List<Ent_INFORME> ListEspeciesDetDatos { get; set; }
        [Category("LIST"), Description("ListEspeciesEstado")]
        public List<Ent_INFORME> ListEspeciesEstado { get; set; }
        [Category("LIST"), Description("ListPersEspecialidad")]
        public List<Ent_INFORME> ListPersEspecialidad { get; set; }
        [Category("LIST"), Description("ListEspecies_Origen")]
        public List<Ent_INFORME> ListEspecies_Origen { get; set; }
        [Category("LIST"), Description("ListNivelAcademico")]
        public List<Ent_INFORME> ListNivelAcademico { get; set; }
        //[Category("LIST"), Description("ListISupervisionGradoCateg")]
        //public List<Ent_INFORME> ListISupervisionGradoCateg { get; set; }
        [Category("LIST"), Description("ListISupvervisionSexo")]
        public List<Ent_INFORME> ListISupvervisionSexo { get; set; }
        [Category("LIST"), Description("ListISupervisionASCfuster")]
        public List<Ent_INFORME> ListISupervisionASCfuster { get; set; }
        [Category("LIST"), Description("ListISupervisionASCFCopa")]
        public List<Ent_INFORME> ListISupervisionASCFCopa { get; set; }
        [Category("LIST"), Description("ListISupervisionASPCopa")]
        public List<Ent_INFORME> ListISupervisionASPCopa { get; set; }
        [Category("LIST"), Description("ListISupervisionASEFenolog")]
        public List<Ent_INFORME> ListISupervisionASEFenolog { get; set; }
        [Category("LIST"), Description("ListISupervisionASESanit")]
        public List<Ent_INFORME> ListISupervisionASESanit { get; set; }
        [Category("LIST"), Description("ListISupervisionASEILianas")]
        public List<Ent_INFORME> ListISupervisionASEILianas { get; set; }
        [Category("LIST"), Description("ListISupervisionASilvicult")]
        public List<Ent_INFORME> ListISupervisionASilvicult { get; set; }
        [Category("LIST"), Description("ListISupervisionFitosanitario")]
        public List<Ent_INFORME> ListISupervisionFitosanitario { get; set; }
        [Category("LIST"), Description("ListIEspecieMaderable")]
        public List<Ent_INFORME> ListIEspecieMaderable { get; set; }
        [Category("LIST"), Description("ListIEspecieNoMaderable")]
        public List<Ent_INFORME> ListIEspecieNoMaderable { get; set; }
        [Category("LIST"), Description("ListOCEjecucionActividad")]
        public List<Ent_INFORME> ListOCEjecucionActividad { get; set; }
        [Category("LIST"), Description("ListOCEspeciesExoticas")]
        public List<Ent_INFORME> ListOCEspeciesExoticas { get; set; }
        [Category("LIST"), Description("ListOCActosTercero")]
        public List<Ent_INFORME> ListOCActosTercero { get; set; }
        [Category("LIST"), Description("ListOCAprovechamientoDirecto")]
        public List<Ent_INFORME> ListOCAprovechamientoDirecto { get; set; }

        [Category("LIST"), Description("ListISupervMaderableAprov")]
        public List<Ent_INFORME> ListISupervMaderableAprov { get; set; }
        [Category("LIST"), Description("ListISupervMaderableSemillero")]
        public List<Ent_INFORME> ListISupervMaderableSemillero { get; set; }
        [Category("LIST"), Description("ListISupervBosqueSeco")]
        public List<Ent_INFORME> ListISupervBosqueSeco { get; set; }
        [Category("LIST"), Description("ListISupervNoMaderableAprov")]
        public List<Ent_INFORME> ListISupervNoMaderableAprov { get; set; }
        [Category("LIST"), Description("ListISupervNoMaderableSemillero")]
        public List<Ent_INFORME> ListISupervNoMaderableSemillero { get; set; }
        [Category("LIST"), Description("ListISupervMaderableAdicional")]
        public List<Ent_INFORME> ListISupervMaderableAdicional { get; set; }


        [Category("LIST"), Description("ListISupervDevolTroza")]
        public List<Ent_INFORME> ListISupervDevolTroza { get; set; }
        [Category("LIST"), Description("ListISupervDevolTocon")]
        public List<Ent_INFORME> ListISupervDevolTocon { get; set; }
        [Category("LIST"), Description("ListISupervDevolarbol")]
        public List<Ent_INFORME> ListISupervDevolArbol { get; set; }
        [Category("LIST"), Description("ListInformeDetSupervisor")]
        public List<Ent_GENEPERSONA> ListInformeDetSupervisor { get; set; }        //
        [Category("LIST"), Description("ListPersonalTecProf")]
        public List<Ent_GENEPERSONA> ListPersonalTecProf { get; set; }

        [Category("LIST"), Description("ListISDSilvicultutal")]
        public List<Ent_INFORME> ListISDSilvicultutal { get; set; }        //

        [Category("LIST"), Description("ListHuayronas")]
        public List<Ent_INFORME> ListHuayronas { get; set; }

        [Category("LIST"), Description("ListISUPERVISION_DET_GESTION")]
        public List<Ent_INFORME> ListISUPERVISION_DET_GESTION { get; set; }


        //Avistamiento de fauna
        [Description("NUM_INDIVIDUOS")]
        public Int32 NUM_INDIVIDUOS { get; set; }
        [Description("COD_TIPO_REGISTRO")]
        public String COD_TIPO_REGISTRO { get; set; }
        [Description("DESC_TIPO_REGISTRO")]
        public String DESC_TIPO_REGISTRO { get; set; }
        [Description("COD_ESTRATO")]
        public String COD_ESTRATO { get; set; }
        [Description("DESC_ESTRATO")]
        public String DESC_ESTRATO { get; set; }
        [Description("DESC_ESPECIES")]
        public String DESC_ESPECIES { get; set; }
        [Description("DESC_ESPECIES_CAMPO")]
        public String DESC_ESPECIES_CAMPO { get; set; }
        [Category("FECHA"), Description("FECHA_AVISTAMIENTO")]
        public Object FECHA_AVISTAMIENTO { get; set; }
        [Category("HORA"), Description("HORA_AVISTAMIENTO")]
        public Object HORA_AVISTAMIENTO { get; set; }
        [Description("NOMBRE_COMUN")]
        public String NOMBRE_COMUN { get; set; }

        //Avistamiento de fauna



        //TemEliiminar
        [Description("EliTABLA")]
        public String EliTABLA { get; set; }
        [Description("EliVALOR01")]
        public String EliVALOR01 { get; set; }
        [Description("USO")]
        public String USO { get; set; }
        [Description("ESTADO_CONSERVACION")]
        public String ESTADO_CONSERVACION { get; set; }

        //ACT TURISTICA
        [Description("VCOD_INFORME")]
        public String VCOD_INFORME { get; set; }
        [Description("NINDICE")]
        public int NINDICE { get; set; }
        [Description("VDESCRIPCION")]
        public String VDESCRIPCION { get; set; }
        [Description("VZONAUTM")]
        public String VZONAUTM { get; set; }
        [Description("VCOORDENADAESTE")]
        public String VCOORDENADAESTE { get; set; }
        [Description("VCOORDENADANORTE")]
        public String VCOORDENADANORTE { get; set; }
        [Description("VAVANCE")]
        public String VAVANCE { get; set; }
        [Description("VPERFIL")]
        public String VPERFIL { get; set; }
        [Description("VOBSERVACION")]
        public String VOBSERVACION { get; set; }
        [Description("VOBJETIVO")]
        public String VOBJETIVO { get; set; }

        [Category("LIST"), Description("ListISDetConservActTuristica")]
        public List<Ent_INFORME> ListISDetConservActTuristica { get; set; }
        [Category("LIST"), Description("ListISDetConservActIntAmbiental")]
        public List<Ent_INFORME> ListISDetConservActIntAmbiental { get; set; }
        [Category("LIST"), Description("ListISDetConservActInvestigacion")]
        public List<Ent_INFORME> ListISDetConservActInvestigacion { get; set; }
        [Category("LIST"), Description("ListISDetConservActVisitas")]
        public List<Ent_INFORME> ListISDetConservActVisitas { get; set; }
        [Category("LIST"), Description("ListISDetConservActOtroPrograma")]
        public List<Ent_INFORME> ListISDetConservActOtroPrograma { get; set; }

        [Category("LIST"), Description("ListEliTABLA")]
        public List<Ent_INFORME> ListEliTABLA { get; set; }
        [Category("LIST"), Description("ListComboISEXSITU")]
        public List<Ent_ISUPERVISION_EXSITU_INFRA_AREA> ListComboISEXSITU { get; set; }
        [Category("LIST"), Description("ListAreaExsitu")]
        public List<Ent_ISUPERVISION_EXSITU_INFRA_AREA> ListAreaExsitu { get; set; }
        [Category("LIST"), Description("ListGrupoToxonomico")]
        public List<Ent_ISUPERVISION_EXSITU_INFRA_AREA> ListGrupoToxonomico { get; set; }
        [Category("LIST"), Description("ListProgManejoSanitarioFisico")]
        public List<Ent_ISUPERVISION_EXSITU_INFRA_AREA> ListProgManejoSanitarioFisico { get; set; }
        [Category("LIST"), Description("ListProgManejoSanitarioQuimico")]
        public List<Ent_ISUPERVISION_EXSITU_INFRA_AREA> ListProgManejoSanitarioQuimico { get; set; }
        [Category("LIST"), Description("ListProgBioFrecuenciaLimpieza")]
        public List<Ent_ISUPERVISION_EXSITU_INFRA_AREA> ListProgBioFrecuenciaLimpieza { get; set; }
        [Category("LIST"), Description("ListMaterialDesinfeccion")]
        public List<Ent_ISUPERVISION_EXSITU_INFRA_AREA> ListMaterialDesinfeccion { get; set; }
        [Category("LIST"), Description("ListEquipoDesinfeccion")]
        public List<Ent_ISUPERVISION_EXSITU_INFRA_AREA> ListEquipoDesinfeccion { get; set; }
        [Category("LIST"), Description("ListCautiverioControlPlagas")]
        public List<Ent_ISUPERVISION_EXSITU_INFRA_AREA> ListCautiverioControlPlaga { get; set; }
        [Category("LIST"), Description("LisCautiveriotManejoRegistro")]
        public List<Ent_ISUPERVISION_EXSITU_INFRA_AREA> LisCautiveriotManejoRegistro { get; set; }
        [Category("LIST"), Description("LisCautiverioEnriquecAmbiental")]
        public List<Ent_ISUPERVISION_EXSITU_INFRA_AREA> LisCautiverioEnriquecAmbiental { get; set; }
        [Category("LIST"), Description("LisCautiverioEspecieReproducida")]
        public List<Ent_ISUPERVISION_EXSITU_INFRA_AREA> LisCautiverioEspecieReproducida { get; set; }
        [Category("LIST"), Description("LisCautiverioActividadRealizada")]
        public List<Ent_ISUPERVISION_EXSITU_INFRA_AREA> LisCautiverioActividadRealizada { get; set; }
        [Category("LIST"), Description("LisCautiverioPublicoObjetivo")]
        public List<Ent_ISUPERVISION_EXSITU_INFRA_AREA> LisCautiverioPublicoObjetivo { get; set; }
        [Category("LIST"), Description("LisCautiverioECapturado")]
        public List<Ent_ISUPERVISION_EXSITU_INFRA_AREA> LisCautiverioECapturado { get; set; }
        //06/12/2018 LISTA DE CAPACITACIONES FAUNA
        [Category("LIST"), Description("LisCapacitacionFauna")]
        public List<Ent_ISUPERVISION_EXSITU_INFRA_AREA> LisCapacitacionFauna { get; set; }

        [Category("LIST"), Description("LisCautiverioCensoVertebrado")]
        public List<Ent_ISUPERVISION_EXSITU_INFRA_AREA> LisCautiverioCensoVertebrado { get; set; }
        [Category("LIST"), Description("LisCautiverioCensoVertebrado")]
        public List<Ent_ISUPERVISION_EXSITU_INFRA_AREA> LisCautiverioCensoICientifica { get; set; }
        //Reemplazado por la lista de avistamiento de fauna silvestre
        [Category("LIST"), Description("ListISUPERVISION_FLORA_SILVESTRE")]
        public List<Ent_INFORME> ListISUPERVISION_FLORA_SILVESTRE { get; set; }
        [Category("LIST"), Description("ListISUPERVISION_REC_PAISAJE_CULTURAL")]
        public List<Ent_INFORME> ListISUPERVISION_REC_PAISAJE_CULTURAL { get; set; }
        [Category("LIST"), Description("ListISUPERVISION_OCARACTE_AMB01")]
        public List<Ent_INFORME> ListISUPERVISION_OCARACTE_AMB01 { get; set; }
        [Category("LIST"), Description("ListISUPERVISION_OCARACTE_AMB02")]
        public List<Ent_INFORME> ListISUPERVISION_OCARACTE_AMB02 { get; set; }
        [Category("LIST"), Description("ListISUPERVISION_CARACTESOCIAL")]
        public List<Ent_INFORME> ListISUPERVISION_CARACTESOCIAL { get; set; }
        [Category("LIST"), Description("ListISUPERVISION_CARACTE_ECOLOG")]
        public List<Ent_INFORME> ListISUPERVISION_CARACTE_ECOLOG { get; set; }
        [Category("LIST"), Description("ListISUPERVISION_INFRAESTRUCTURA_CONS")]
        public List<Ent_INFORME> ListISUPERVISION_INFRAESTRUCTURA_CONS { get; set; }
        [Category("LIST"), Description("ListISUPERVISION_DET_EQUIPACONSECION")]
        public List<Ent_INFORME> ListISUPERVISION_DET_EQUIPACONSECION { get; set; }
        [Category("LIST"), Description("ListISUPERVISION_DET_ZONIFICACION")]
        public List<Ent_INFORME> ListISUPERVISION_DET_ZONIFICACION { get; set; }
        [Category("LIST"), Description("ListISUPERVISION_DET_CAPACITACION_EFECT")]
        public List<Ent_INFORME> ListISUPERVISION_DET_CAPACITACION_EFECT { get; set; }
        [Category("LIST"), Description("ListISUPERVISION_DET_CAPACITACION_ACTDES")]
        public List<Ent_INFORME> ListISUPERVISION_DET_CAPACITACION_ACTDES { get; set; }
        [Category("LIST"), Description("ListINFORMEItemsDetalle")]
        public List<Ent_INFORME> ListINFORMEItemsDetalle { get; set; }
        [Category("LIST"), Description("ListEspeciesCientifico")]
        public List<Ent_INFORME> ListEspeciesCientifico { get; set; }
        [Category("LIST"), Description("ListAvistamientoFauna")]
        public List<Ent_INFORME> ListAvistamientoFauna { get; set; }

        //[Category("LIST"), Description("ListVolInjustificado")]
        //public List<Ent_INFORME> ListVolInjustificado { get; set; }
        //[Category("LIST"), Description("ListVolJustificado")]
        //public List<Ent_INFORME> ListVolJustificado { get; set; }

        [Category("LIST"), Description("ListTipoRegistro")]
        public List<Ent_INFORME> ListTipoRegistro { get; set; }
        [Category("LIST"), Description("ListEstrato")]
        public List<Ent_INFORME> ListEstrato { get; set; }
        [Category("LIST"), Description("ListCNotificaciones")]
        public List<Ent_INFORME> ListCNotificaciones { get; set; }
        [Category("LIST"), Description("ListFotos")]
        public List<Ent_INFORME> ListFotos { get; set; }
        [Category("LIST"), Description("ListPOAs")]
        public List<Ent_INFORME> ListPOAs { get; set; }

        [Description("CUENTA_AREA_ADMIN")]
        public Object CUENTA_AREA_ADMIN { get; set; }
        [Description("CUENTA_MILEGAL")]
        public Object CUENTA_MILEGAL { get; set; }

        [Description("AREA_MILEGAL")]
        public Decimal AREA_MILEGAL { get; set; }
        [Description("TIPO_IMPACTO")]
        public String TIPO_IMPACTO { get; set; }

        [Description("OBSERVACION_MILEGAL")]
        public String OBSERVACION_MILEGAL { get; set; }
        [Description("ESTADO")]
        public String ESTADO { get; set; }
        [Description("NUM_VISITANTE")]
        public String NUM_VISITANTE { get; set; }
        [Description("DAP")]
        public Decimal DAP { get; set; }
        [Description("DAP1")]
        public Decimal DAP1 { get; set; }
        [Description("DAP2")]
        public Decimal DAP2 { get; set; }
        [Description("DAP_CAMPO2")]
        public Decimal DAP_CAMPO2 { get; set; }
        [Description("DAP_CAMPO1")]
        public Decimal DAP_CAMPO1 { get; set; }
        [Description("COINCIDE_ESPECIES")]
        public String COINCIDE_ESPECIES { get; set; }
        [Description("DESC_COINCIDE_ESPECIES")]
        public String DESC_COINCIDE_ESPECIES { get; set; }
        [Description("MAE_TIP_MMEDIRDAP")]
        public String MAE_TIP_MMEDIRDAP { get; set; }
        [Description("MMEDIR_DAP")]
        public String MMEDIR_DAP { get; set; }

        [Description("AREA_ADMINISTRATIVA")]
        public Object AREA_ADMINISTRATIVA { get; set; }
        [Description("AREA_SHIGIENICO")]
        public Object AREA_SHIGIENICO { get; set; }
        [Description("AREA_OTROS")]
        public Object AREA_OTROS { get; set; }
        [Description("TIPO_ALIMENTACION")]
        public String TIPO_ALIMENTACION { get; set; }

        [Description("FRECUENCIA_RACION")]
        public String FRECUENCIA_RACION { get; set; }
        [Description("FRECUENCIA")]
        public String FRECUENCIA { get; set; }

        [Description("RIESGO_POTENCIAL")]
        public String RIESGO_POTENCIAL { get; set; }
        [Description("COORDENADA_SUR_CAMPO")]
        public Int32 COORDENADA_SUR_CAMPO { get; set; }
        [Description("TIPO_AMBIENTE")]
        public String TIPO_AMBIENTE { get; set; }
        [Description("NUM_AMBIENTE")]
        public Int32 NUM_AMBIENTE { get; set; }
        [Description("AREA")]
        public Decimal AREA { get; set; }
        [Description("MATERIAL_CONSTRUCCION")]
        public String MATERIAL_CONSTRUCCION { get; set; }
        [Description("CAPACIDAD")]
        public String CAPACIDAD { get; set; }
        [Description("NUM_INDICE")]
        public Int32 NUM_INDICE { get; set; }

        [Category("FECHA"), Description("FECHA")]
        public Object FECHA { get; set; }
        [Description("ALTITUD")]
        public Decimal ALTITUD { get; set; }
        [Description("ESTADO_PROGRAMA")]
        public Object ESTADO_PROGRAMA { get; set; }
        [Description("EliVALOR02")]
        public Int32 EliVALOR02 { get; set; }
        #endregion

        [Description("NOMBRE_SUP_CALIDAD")]
        public String NOMBRE_SUP_CALIDAD { get; set; }
        [Description("COD_SUP_CALIDAD")]
        public String COD_SUP_CALIDAD { get; set; }


        [Description("pagesize")]
        public int pagesize { get; set; }
        [Description("currentpage")]
        public int currentpage { get; set; }
        [Description("PLAN_AMAZONAS")]
        public Object PLAN_AMAZONAS { get; set; }
        [Description("ANIO_PLAN_AMAZONAS")]
        public String ANIO_PLAN_AMAZONAS { get; set; }

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

        [Description("COD_REQUE")]
        public Int32 COD_REQUE { get; set; }

        [Description("COD_DEVOLUCION")]
        public String COD_DEVOLUCION { get; set; }
        [Description("NUM_TROZAS")]
        public Int32 NUM_TROZAS { get; set; }
        [Description("NUM_TROZAS_CAMPO")]
        public Int32 NUM_TROZAS_CAMPO { get; set; }
        [Description("LARGO")]
        public Decimal LARGO { get; set; }
        [Description("LARGO_CAMPO")]
        public Decimal LARGO_CAMPO { get; set; }
        [Description("CANTIDAD")]
        public Int32 CANTIDAD { get; set; }
        [Description("CANTIDAD_CAMPO")]
        public Int32 CANTIDAD_CAMPO { get; set; }
        [Description("NUM_PCA")]
        public String NUM_PCA { get; set; }
        [Description("NUM_PCA_CAMPO")]
        public String NUM_PCA_CAMPO { get; set; }
        [Description("VOLUMEN_CAMPO")]
        public Decimal VOLUMEN_CAMPO { get; set; }

        [Description("TIPO_DOCUMENTO_REPORT")]
        public String TIPO_DOCUMENTO_REPORT { get; set; }
        [Description("COD_DOCUMENTO_REPORT")]
        public String COD_DOCUMENTO_REPORT { get; set; }
        [Description("NUM_POA_REPORT")]
        public Int32 NUM_POA_REPORT { get; set; }
        // CARRIZOS
        [Description("TOTAL_UNIDADES")]
        public Int32 TOTAL_UNIDADES { get; set; }
        [Description("TOTAL_UNIDADES_APROVECHABLES")]
        public Int32 TOTAL_UNIDADES_APROVECHABLES { get; set; }
        [Description("COD_MUESTRA_SUPERVISION")]
        public String COD_MUESTRA_SUPERVISION { get; set; }
        [Description("ALTURA_PROMEDIO")]
        public Decimal ALTURA_PROMEDIO { get; set; }
        [Category("LIST"), Description("ListMuestraNoMadeCarrizos")]
        public List<Ent_INFORME> ListMuestraNoMadeCarrizos { get; set; }

        [Category("LIST"), Description("ListMuestraNoMadePMed")]
        public List<Ent_INFORME> ListMuestraNoMadePMed { get; set; }

        [Description("UNIDAD_MEDIDA")]
        public String UNIDAD_MEDIDA { get; set; }
        #region Fotos informe
        [Description("COD_INFORME_FOTOS")]
        public String COD_INFORME_FOTOS { get; set; }
        [Description("DESC_FOTO")]
        public String DESC_FOTO { get; set; }
        [Description("FUENTE_FOTO")]
        public String FUENTE_FOTO { get; set; }
        [Description("DISP_FOTO")]
        public String DISP_FOTO { get; set; }
        [Description("URL_FOTO")]
        public String URL_FOTO { get; set; }
        #endregion



        //VERTICES
        [Description("VERTICE_POA")]
        public String VERTICE_POA { get; set; }
        [Description("VERTICE_CAMPO")]
        public String VERTICE_CAMPO { get; set; }
        [Category("LIST"), Description("ListVerticesVerificar")]
        public List<Ent_INFORME> ListVerticesVerificar { get; set; }
        [Description("COD_INFORME_VERTICE")]
        public String COD_INFORME_VERTICE { get; set; }

        //Actualización 21/11/2016 - Nuevos campos
        [Description("REALIZADO_VEEDORFORESTAL")]
        public Object REALIZADO_VEEDORFORESTAL { get; set; }
        [Description("CUMPLE_VIAL_PLANMAN")]
        public Object CUMPLE_VIAL_PLANMAN { get; set; }
        [Description("INDICIO_APROV")]
        public Object INDICIO_APROV { get; set; }
        [Description("OBSERV_APROV")]
        public String OBSERV_APROV { get; set; }
        [Description("CUMPLE_PAGO_APROV")]
        public Object CUMPLE_PAGO_APROV { get; set; }
        [Description("OBSERV_PAGO_APROV")]
        public String OBSERV_PAGO_APROV { get; set; }
        [Description("COD_RESODIREC_GRAVEDAD")]
        public String COD_RESODIREC_GRAVEDAD { get; set; }
        [Description("LINDERAMIENTO_AREA")]
        public String LINDERAMIENTO_AREA { get; set; }

        [Description("USUARIO_REGISTRO")]
        public String USUARIO_REGISTRO { get; set; }
        [Description("USUARIO_CONTROL")]
        public String USUARIO_CONTROL { get; set; }

        [Description("MAE_TIP_MADERABLE")]
        public String MAE_TIP_MADERABLE { get; set; }
        [Category("LIST"), Description("ListGravedadDanio")]
        public List<Ent_INFORME> ListGravedadDanio { get; set; }
        [Category("LIST"), Description("ListISupervMaderableNoAutorizado")]
        public List<Ent_INFORME> ListISupervMaderableNoAutorizado { get; set; }
        //Cambio de Uso
        [Description("MAE_TIP_CAMBIOUSO")]
        public String MAE_TIP_CAMBIOUSO { get; set; }
        [Description("NOM_TIP_CAMBIOUSO")]
        public String NOM_TIP_CAMBIOUSO { get; set; }
        [Category("LIST"), Description("ListISupervCambioUso")]
        public List<Ent_INFORME> ListISupervCambioUso { get; set; }
        [Category("LIST"), Description("ListTipoCambioUso")]
        public List<Ent_INFORME> ListTipoCambioUso { get; set; }
        //VERTICES LINDERAMIENTO AREA TITULO HABILITANTE
        [Description("ZONA")]
        public String ZONA { get; set; }
        [Description("AUTORIZADO")]
        public String AUTORIZADO { get; set; }
        [Description("ZONA_CAMPO")]
        public String ZONA_CAMPO { get; set; }
        [Category("LIST"), Description("ListISupervLindAreaVertice")]
        public List<Ent_INFORME> ListISupervLindAreaVertice { get; set; }
        //INFORMACIÓN DOCUMENTARIA DE LOS POA's
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
        public string CUENTA_INFOEJECPO { get; set; }
        [Category("FECHA"), Description("FEC_PRESENT_INFOEJECPO")]
        public Object FEC_PRESENT_INFOEJECPO { get; set; }
        [Category("FECHA"), Description("FEC_COMUNIC_INFOEJECPO")]
        public Object FEC_COMUNIC_INFOEJECPO { get; set; }
        [Description("CUMPLE_LINEA_INFOEJECPO")]
        public Object CUMPLE_LINEA_INFOEJECPO { get; set; }
        [Description("OBSERV_LINEA_INFOEJECPO")]
        public String OBSERV_LINEA_INFOEJECPO { get; set; }
        [Category("LIST"), Description("ListISupervInfoDocument")]
        public List<Ent_INFORME> ListISupervInfoDocument { get; set; }
        [Category("LIST"), Description("ListISupervMadeNoMade")]
        public List<Ent_INFORME> ListISupervMadeNoMade { get; set; }
        [Category("LIST"), Description("ListISupervFaunaAprov")]
        public List<Ent_INFORME> ListISupervFaunaAprov { get; set; }
        [Description("PERIODO")]
        public String PERIODO { get; set; }
        [Description("CUOTA_SACA")]
        public Int32 CUOTA_SACA { get; set; }
        [Description("PERSONAL")]
        public String PERSONAL { get; set; }
        [Description("METODO_CAZA")]
        public String METODO_CAZA { get; set; }
        [Description("SISTEMA_MARCAJE")]
        public String SISTEMA_MARCAJE { get; set; }
        [Description("APROVECHAR")]
        public String APROVECHAR { get; set; }
        [Description("COD_TECNICO")]
        public String COD_TECNICO { get; set; }
        [Description("NOMBRE_TECNICO")]
        public String NOMBRE_TECNICO { get; set; }
        [Category("LIST"), Description("ListNacimientosEspecies")]
        public List<Ent_ISUPERVISION_EXSITU_INFRA_AREA> ListNacimientosEspecies { get; set; }
        [Category("LIST"), Description("ListEgresosEspecies")]
        public List<Ent_ISUPERVISION_EXSITU_INFRA_AREA> ListEgresosEspecies { get; set; }
        [Category("LIST"), Description("ListISuperExsituBalance")]
        public List<Ent_ISUPERVISION_EXSITU_INFRA_AREA> ListISuperExsituBalance { get; set; }
        [Category("LIST"), Description("ListRelPelCentroCria")]
        public List<Ent_GENEPERSONA> ListRelPelCentroCria { get; set; }


        [Category("LIST"), Description("ListISuperExsituOBLIGF")]
        public List<Ent_ISUPERVISION_EXSITU_INFRA_AREA> ListISuperExsituOBLIGF { get; set; }

        //14/08/2017
        [Description("MAE_EST_APROVECHA")]
        public String MAE_EST_APROVECHA { get; set; }
        [Description("MAE_TIP_IEJECFOREST")]
        public String MAE_TIP_IEJECFOREST { get; set; }
        [Category("FECHA"), Description("FEC_ENTREGA_ACERVO")]
        public Object FEC_ENTREGA_ACERVO { get; set; }
        [Category("LIST"), Description("ListMComboEstadoAprovecha")]
        public List<Ent_INFORME> ListMComboEstadoAprovecha { get; set; }
        [Category("LIST"), Description("ListMComboTipoInfoEjecForestal")]
        public List<Ent_INFORME> ListMComboTipoInfoEjecForestal { get; set; }
        [Category("LIST"), Description("ListMComboTipoMMedirDap")]
        public List<Ent_INFORME> ListMComboTipoMMedirDap { get; set; }
        [Category("LIST"), Description("ListMComboCondicionCampo")]
        public List<Ent_INFORME> ListMComboCondicionCampo { get; set; }

        //12/09/2017 - Registro de Trozas, Madera aserrada
        [Category("LIST"), Description("ListTrozaCampo")]
        public List<Ent_INFORME> ListTrozaCampo { get; set; }
        [Category("LIST"), Description("ListMadeAserradaCampo")]
        public List<Ent_INFORME> ListMadeAserradaCampo { get; set; }
        [Category("LIST"), Description("ListTHVerticeCampo")]
        public List<Ent_INFORME> ListTHVerticeCampo { get; set; }
        [Category("LIST"), Description("ListTHVertice")]
        public List<Ent_INFORME> ListTHVertice { get; set; }
        [Category("LIST"), Description("ListEvaluacionOtros")]
        public List<Ent_INFORME> ListEvaluacionOtros { get; set; }
        [Description("LC")]
        public Decimal LC { get; set; }
        [Description("ANCHO")]
        public Decimal ANCHO { get; set; }
        [Description("ESPESOR")]
        public Decimal ESPESOR { get; set; }
        [Description("PIEZAS")]
        public Int32 PIEZAS { get; set; }
        [Description("EVALUACION")]
        public String EVALUACION { get; set; }

        //Unificación volumen justificado e injustificado 22/09/2017
        [Category("LIST"), Description("ListVolumen")]
        public List<Ent_INFORME> ListVolumen { get; set; }
        [Description("VOLUMEN_APROBADO")]
        public Decimal VOLUMEN_APROBADO { get; set; }
        [Description("VOLUMEN_MOVILIZADO")]
        public Decimal VOLUMEN_MOVILIZADO { get; set; }
        [Description("VOLUMEN_INJUSTIFICADO")]
        public Decimal VOLUMEN_INJUSTIFICADO { get; set; }
        [Description("VOLUMEN_JUSTIFICADO")]
        public Decimal VOLUMEN_JUSTIFICADO { get; set; }

        //Titular ejecución POA y regente implementa 25/09/2017
        [Description("COD_REGENTE_IMPLEMENTA")]
        public String COD_REGENTE_IMPLEMENTA { get; set; }
        [Description("REGENTE_IMPLEMENTA")]
        public String REGENTE_IMPLEMENTA { get; set; }
        [Description("COD_TITULAR_EJECUTA")]
        public String COD_TITULAR_EJECUTA { get; set; }
        [Description("TITULAR_EJECUTA")]
        public String TITULAR_EJECUTA { get; set; }
        [Description("COD_RESODIREC")]
        public String COD_RESODIREC { get; set; }
        
        //DIRECCION UBIGEO REGRENTE
        [Description("DIRECCION_REGENTE")]
        public String DIRECCION_REGENTE { get; set; }
        [Description("COD_UBIGEO_REGENTE")]
        public String COD_UBIGEO_REGENTE { get; set; }
        [Description("UBIGEO_REGENTE")]
        public String UBIGEO_REGENTE { get; set; }

        [Category("LIST"), Description("ListEMaderable")]
        public List<Ent_INFORME> ListEMaderable { get; set; }
        [Category("LIST"), Description("ListEMaderableSemillero")]
        public List<Ent_INFORME> ListEMaderableSemillero { get; set; }

        //Geotecnologías 07/12/2017
        [Description("GEOTEC_DRON")]
        public Object GEOTEC_DRON { get; set; }
        [Description("GEOTEC_GEOSUPERVISOR")]
        public Object GEOTEC_GEOSUPERVISOR { get; set; }
        [Description("GEOTEC_NINGUNO")]
        public Object GEOTEC_NINGUNO { get; set; }
        [Description("GEOTEC_OTROS")]
        public Object GEOTEC_OTROS { get; set; }
        [Description("GEOTEC_DESCRIPCION")]
        public String GEOTEC_DESCRIPCION { get; set; }
        [Description("RECOMEND_REFORMULA")]
        public Object RECOMEND_REFORMULA { get; set; }
        [Description("RECOMEND_DESCRIPCION")]
        public String RECOMEND_DESCRIPCION { get; set; }
        [Description("CANT_SOBRE_ESTIMA_DIAMETRO")]
        public Int32 CANT_SOBRE_ESTIMA_DIAMETRO { get; set; }
        [Description("PORC_SOBRE_ESTIMA_DIAMETRO")]
        public Decimal PORC_SOBRE_ESTIMA_DIAMETRO { get; set; }
        [Description("CANT_SUB_ESTIMA_DIAMETRO")]
        public Int32 CANT_SUB_ESTIMA_DIAMETRO { get; set; }
        [Description("PORC_SUB_ESTIMA_DIAMETRO")]
        public Decimal PORC_SUB_ESTIMA_DIAMETRO { get; set; }

        [Description("CUENTA_REGENTE")]
        public Object CUENTA_REGENTE { get; set; }
        [Description("NOMBRE_REGENTE")]
        public String NOMBRE_REGENTE { get; set; }
        [Description("CODIGO_REGENTE")]
        public String CODIGO_REGENTE { get; set; }
        [Description("FECHA_REGENTE")]
        public Object FECHA_REGENTE { get; set; }

        [Description("FINES_CREACION")]
        public String FINES_CREACION { get; set; }
        [Description("OBJETIVOS_PRINCIPALES")]
        public String OBJETIVOS_PRINCIPALES { get; set; }
        [Description("COND_ADECUADAS")]
        public String COND_ADECUADAS { get; set; }
        [Description("DOC_LEGAL")]
        public String DOC_LEGAL { get; set; }
        [Description("PROG_ESTABLECIDOPM")]
        public String PROG_ESTABLECIDOPM { get; set; }
        [Description("INF_RESPALDO")]
        public String INF_RESPALDO { get; set; }
        [Description("EGRE_ANIMALES")]
        public String EGRE_ANIMALES { get; set; }
        [Description("BD_ESPECIMENES")]
        public String BD_ESPECIMENES { get; set; }
        [Description("PRESENT_INFORMES")]
        public String PRESENT_INFORMES { get; set; }
        [Description("LIBRO_OPERAC")]
        public String LIBRO_OPERAC { get; set; }
        [Description("Evaluacion_Informe")]
        public Double Evaluacion_Informe { get; set; }
        [Description("COD_ISU_EVALUACION")]
        public String COD_ISU_EVALUACION { get; set; }

        [Description("OBJ_ACTUAL")]
        public String OBJ_ACTUAL { get; set; }
        [Description("OBJ_PRINCIP")]
        public String OBJ_PRINCIP { get; set; }
        [Description("VISITA")]
        public Object VISITA { get; set; }
        [Description("REPRODUCE")]
        public Object REPRODUCE { get; set; }
        [Description("OBSERVACION_PUBLICAR")]
        public String OBSERVACION_PUBLICAR { get; set; }

        [Description("OB_FINES_CREACION")]
        public String OB_FINES_CREACION { get; set; }
        [Description("OB_OBJETIVOS_PRINCIPALES")]
        public String OB_OBJETIVOS_PRINCIPALES { get; set; }
        [Description("OB_COND_ADECUADAS")]
        public String OB_COND_ADECUADAS { get; set; }
        [Description("OB_DOC_LEGAL")]
        public String OB_DOC_LEGAL { get; set; }
        [Description("OB_PROG_ESTABLECIDOPM")]
        public String OB_PROG_ESTABLECIDOPM { get; set; }
        [Description("OB_INF_RESPALDO")]
        public String OB_INF_RESPALDO { get; set; }
        [Description("OB_EGRE_ANIMALES")]
        public String OB_EGRE_ANIMALES { get; set; }
        [Description("OB_BD_ESPECIMENES")]
        public String OB_BD_ESPECIMENES { get; set; }
        [Description("OB_PRESENT_INFORMES")]
        public String OB_PRESENT_INFORMES { get; set; }
        [Description("OB_LIBRO_OPERAC")]
        public String OB_LIBRO_OPERAC { get; set; }

        //Supervisión motivada - tipo y Documento denuncia SITD - 22/03/2018
        [Description("MAE_TIP_MOTMOTIVADA")]
        public String MAE_TIP_MOTMOTIVADA { get; set; }
        [Description("COD_TRAMITE_SITD")]
        public Int32 COD_TRAMITE_SITD { get; set; }
        [Description("NUM_DREFERENCIA")]
        public String NUM_DREFERENCIA { get; set; }
        [Category("LIST"), Description("ListMComboMotMotivada")]
        public List<Ent_INFORME> ListMComboMotMotivada { get; set; }

        [Category("LIST"), Description("ListPOAsCampo")]
        public List<Ent_INFORME> ListPOAsCampo { get; set; }
        [Category("LIST"), Description("ListCastaña")]
        public List<Ent_INFORME> ListCastaña { get; set; }

        //18/05/2018
        [Description("CONDICION")]
        public String CONDICION { get; set; }
        [Description("FENOLOGICO")]
        public String FENOLOGICO { get; set; }
        [Description("ESTADO_FITOSANITARIO")]
        public String ESTADO_FITOSANITARIO { get; set; }
        [Description("GRADO_INFESTACION")]
        public String GRADO_INFESTACION { get; set; }

        //11/06/2018
        [Description("SUPERVISADO")]
        public Object SUPERVISADO { get; set; }
        //10/07/2018
        [Description("TITULAR")]
        public Object TITULAR { get; set; }
        [Description("SUPERVISOR")]
        public Object SUPERVISOR { get; set; }
        [Description("COORDENADA_NORTE_POA")]
        public Int32 COORDENADA_NORTE_POA { get; set; }
        [Description("COORDENADA_ESTE_POA")]
        public Int32 COORDENADA_ESTE_POA { get; set; }

        [Description("TOTAL_UNIDAD_MUEST")]
        public Int32 TOTAL_UNIDAD_MUEST { get; set; }
        [Description("TOTAL_UNIDADES_APROV")]
        public Int32 TOTAL_UNIDADES_APROV { get; set; }
        //----
        [Description("TIPO_REPORTE")]
        public String TIPO_REPORTE { get; set; }
        [Description("ESTADO_ORIGEN_TEXT")]
        public String ESTADO_ORIGEN_TEXT { get; set; }
        [Description("MAE_CNTIPO")]
        public String MAE_CNTIPO { get; set; }
        [Description("MTIPO")]
        public String MTIPO { get; set; }
        [Description("BIOSEGURIDADOTROS")]
        public String BIOSEGURIDADOTROS { get; set; }
        [Description("chkOtrosMateriales")]
        public Object chkOtrosMateriales { get; set; }
        [Description("txtOtrosMateriales")]
        public String txtOtrosMateriales { get; set; }
        [Description("chkOtrosMaterialesDesinf")]
        public Object chkOtrosMaterialesDesinf { get; set; }
        [Description("txtOtrosMaterialesDesinf")]
        public String txtOtrosMaterialesDesinf { get; set; }

        [Description("OBSERVACION_FRECUENCIA")]
        public String OBSERVACION_FRECUENCIA { get; set; }

        [Description("HORARIO_RALIMENTO")]
        public String HORARIO_RALIMENTO { get; set; }
        [Description("DIAS_ABASTECIMIENTO")]
        public String DIAS_ABASTECIMIENTO { get; set; }

        [Description("PROTOCOL_CONTINGENCIA")]
        public String PROTOCOL_CONTINGENCIA { get; set; }
        [Description("PROTOCOL_ACCION")]
        public String PROTOCOL_ACCION { get; set; }
        [Description("OBSERVACION_CONTENCION")]
        public String OBSERVACION_CONTENCION { get; set; }
        [Description("RESIDUOS_PELIGROSOS")]
        public String RESIDUOS_PELIGROSOS { get; set; }

        [Description("INFORME_EJECUCIONPM")]
        public String INFORME_EJECUCIONPM { get; set; }
        [Description("ANIOS_EJECUCIONPM")]
        public String ANIOS_EJECUCIONPM { get; set; }
        [Description("REALIZA_CAPCITAC")]
        public String REALIZA_CAPCITAC { get; set; }

        #region  14/08/2018 Disposiciones Administrativas
        //1
        [Description("DISADM_APROBPMF")]
        public String DISADM_APROBPMF { get; set; }
        [Description("DISADM_APROBPMF_DESCRIPCION")]
        public String DISADM_APROBPMF_DESCRIPCION { get; set; }
        //2
        [Description("DISADM_IODESARROLLOLINEAMIENTOS")]
        public String DISADM_IODESARROLLOLINEAMIENTOS { get; set; }
        [Description("DISADM_IODESARROLLOLINEAMIENTOS_DESCRIPCION")]
        public String DISADM_IODESARROLLOLINEAMIENTOS_DESCRIPCION { get; set; }
        //3
        [Description("DISADM_AUTORIDADAPROBOPMF")]
        public String DISADM_AUTORIDADAPROBOPMF { get; set; }
        [Description("DISADM_AUTORIDADAPROBOPMF_DESCRIPCION")]
        public String DISADM_AUTORIDADAPROBOPMF_DESCRIPCION { get; set; }
        //4
        [Description("DISADM_ESPECIESCORRESPONDEPMF")]
        public String DISADM_ESPECIESCORRESPONDEPMF { get; set; }
        [Description("DISADM_ESPECIESCORRESPONDEPMF_DESCRIPCION")]
        public String DISADM_ESPECIESCORRESPONDEPMF_DESCRIPCION { get; set; }
        //5
        [Description("DISADM_AUTORIDADNOTIFICOTITULAR")]
        public String DISADM_AUTORIDADNOTIFICOTITULAR { get; set; }
        [Description("DISADM_AUTORIDADNOTIFICOTITULAR_DESCRIPCION")]
        public String DISADM_AUTORIDADNOTIFICOTITULAR_DESCRIPCION { get; set; }
        //6
        [Description("DISADM_AUTORIDAREMITIOCOPIA")]
        public String DISADM_AUTORIDAREMITIOCOPIA { get; set; }
        [Description("DISADM_AUTORIDAREMITIOCOPIA_DESCRIPCION")]
        public String DISADM_AUTORIDAREMITIOCOPIA_DESCRIPCION { get; set; }
        //7
        [Description("DISADM_TITULARENTREGOINFORMACION")]
        public String DISADM_TITULARENTREGOINFORMACION { get; set; }
        [Description("DISADM_TITULARENTREGOINFORMACION_DESCRIPCION")]
        public String DISADM_TITULARENTREGOINFORMACION_DESCRIPCION { get; set; }
        //8
        [Description("DISADM_MAPACONTIENEINFORMACION")]
        public String DISADM_MAPACONTIENEINFORMACION { get; set; }
        [Description("DISADM_MAPACONTIENEINFORMACION_DESCRIPCION")]
        public String DISADM_MAPACONTIENEINFORMACION_DESCRIPCION { get; set; }
        //9
        [Description("DISADM_ARFFSATENDIOSOLICITUD")]
        public String DISADM_ARFFSATENDIOSOLICITUD { get; set; }
        [Description("DISADM_ARFFSATENDIOSOLICITUD_DESCRIPCION")]
        public String DISADM_ARFFSATENDIOSOLICITUD_DESCRIPCION { get; set; }
        //10
        [Description("DISADM_VIGENTEGARANTIA")]
        public String DISADM_VIGENTEGARANTIA { get; set; }
        [Description("DISADM_VIGENTEGARANTIA_DESCRIPCION")]
        public String DISADM_VIGENTEGARANTIA_DESCRIPCION { get; set; }
        #endregion


        #region 14/08/2018 Obligacion Titulares TH Maderable
        //1
        [Description("OBLI_PRESENTOPLANMANEJO")]
        public String OBLI_PRESENTOPLANMANEJO { get; set; }
        [Description("OBLI_PRESENTOPLANMANEJO_DESCRIPCION")]
        public String OBLI_PRESENTOPLANMANEJO_DESCRIPCION { get; set; }
        //2
        [Description("OBLI_PRESENTOPLANMANEJOCONFORMIDAD")]
        public String OBLI_PRESENTOPLANMANEJOCONFORMIDAD { get; set; }
        [Description("OBLI_PRESENTOPLANMANEJOCONFORMIDAD_DESCRIPCION")]
        public String OBLI_PRESENTOPLANMANEJOCONFORMIDAD_DESCRIPCION { get; set; }
        //3
        [Description("OBLI_PAGOAPROVECHAMIENTO")]
        public String OBLI_PAGOAPROVECHAMIENTO { get; set; }
        [Description("OBLI_PAGOAPROVECHAMIENTO_DESCRIPCION")]
        public String OBLI_PAGOAPROVECHAMIENTO_DESCRIPCION { get; set; }
        //4
        [Description("OBLI_MANTIENELIBROOPERACIONES")]
        public String OBLI_MANTIENELIBROOPERACIONES { get; set; }
        [Description("OBLI_MANTIENELIBROOPERACIONES_DESCRIPCION")]
        public String OBLI_MANTIENELIBROOPERACIONES_DESCRIPCION { get; set; }
        //5
        [Description("OBLI_COMUNICOARFFSOSINFORSUSCRIPCION")]
        public String OBLI_COMUNICOARFFSOSINFORSUSCRIPCION { get; set; }
        [Description("OBLI_COMUNICOARFFSOSINFORSUSCRIPCION_DESCRIPCION")]
        public String OBLI_COMUNICOARFFSOSINFORSUSCRIPCION_DESCRIPCION { get; set; }

        //6
        [Description("OBLI_REPORTOARFFSMINISTERIOAVISTAMIENTOS")]
        public String OBLI_REPORTOARFFSMINISTERIOAVISTAMIENTOS { get; set; }
        [Description("OBLI_REPORTOARFFSMINISTERIOAVISTAMIENTOS_DESCRIPCION")]
        public String OBLI_REPORTOARFFSMINISTERIOAVISTAMIENTOS_DESCRIPCION { get; set; }
        //7
        [Description("OBLI_REALIZOACCIONESCUSTODIO")]
        public String OBLI_REALIZOACCIONESCUSTODIO { get; set; }
        [Description("OBLI_REALIZOACCIONESCUSTODIO_DESCRIPCION")]
        public String OBLI_REALIZOACCIONESCUSTODIO_DESCRIPCION { get; set; }
        //8
        [Description("OBLI_FACILITODESARROLLO")]
        public String OBLI_FACILITODESARROLLO { get; set; }
        [Description("OBLI_FACILITODESARROLLO_DESCRIPCION")]
        public String OBLI_FACILITODESARROLLO_DESCRIPCION { get; set; }
        //9
        [Description("OBLI_ASUMIOCOSTOSUPERVISIONES")]
        public String OBLI_ASUMIOCOSTOSUPERVISIONES { get; set; }
        [Description("OBLI_ASUMIOCOSTOSUPERVISIONES_DESCRIPCION")]
        public String OBLI_ASUMIOCOSTOSUPERVISIONES_DESCRIPCION { get; set; }
        //10
        [Description("OBLI_IMPLEMENTAMECANISMOTRAZA")]
        public String OBLI_IMPLEMENTAMECANISMOTRAZA { get; set; }
        [Description("OBLI_IMPLEMENTAMECANISMOTRAZA_DESCRIPCION")]
        public String OBLI_IMPLEMENTAMECANISMOTRAZA_DESCRIPCION { get; set; }
        //11
        [Description("OBLI_RESPETASERVIDUMBRE")]
        public String OBLI_RESPETASERVIDUMBRE { get; set; }
        [Description("OBLI_RESPETASERVIDUMBRE_DESCRIPCION")]
        public String OBLI_RESPETASERVIDUMBRE_DESCRIPCION { get; set; }
        //12
        [Description("OBLI_CUENTAREGENTE")]
        public String OBLI_CUENTAREGENTE { get; set; }
        [Description("OBLI_CUENTAREGENTE_DESCRIPCION")]
        public String OBLI_CUENTAREGENTE_DESCRIPCION { get; set; }
        //13
        [Description("OBLI_ADOPTAMEDIDASEXTENSION")]
        public String OBLI_ADOPTAMEDIDASEXTENSION { get; set; }
        [Description("OBLI_ADOPTAMEDIDASEXTENSION_DESCRIPCION")]
        public String OBLI_ADOPTAMEDIDASEXTENSION_DESCRIPCION { get; set; }
        //14
        [Description("OBLI_RESPETAVALORES")]
        public String OBLI_RESPETAVALORES { get; set; }
        [Description("OBLI_RESPETAVALORES_DESCRIPCION")]
        public String OBLI_RESPETAVALORES_DESCRIPCION { get; set; }
        //15
        [Description("OBLI_CUMPLEMEDIDAS")]
        public String OBLI_CUMPLEMEDIDAS { get; set; }
        [Description("OBLI_CUMPLEMEDIDAS_DESCRIPCION")]
        public String OBLI_CUMPLEMEDIDAS_DESCRIPCION { get; set; }
        //16
        [Description("OBLI_CUMPLENORMAS")]
        public String OBLI_CUMPLENORMAS { get; set; }
        [Description("OBLI_CUMPLENORMAS_DESCRIPCION")]
        public String OBLI_CUMPLENORMAS_DESCRIPCION { get; set; }
        //17
        [Description("OBLI_MOVILIZAFRUTOPRODUCTOS")]
        public String OBLI_MOVILIZAFRUTOPRODUCTOS { get; set; }
        [Description("OBLI_MOVILIZAFRUTOPRODUCTOS_DESCRIPCION")]
        public String OBLI_MOVILIZAFRUTOPRODUCTOS_DESCRIPCION { get; set; }
        //18
        [Description("OBLI_CUMPLEMARCADOTROZAS")]
        public String OBLI_CUMPLEMARCADOTROZAS { get; set; }
        [Description("OBLI_CUMPLEMARCADOTROZAS_DESCRIPCION")]
        public String OBLI_CUMPLEMARCADOTROZAS_DESCRIPCION { get; set; }
        //19
        [Description("OBLI_ESTABLECELINDEROS")]
        public String OBLI_ESTABLECELINDEROS { get; set; }
        [Description("OBLI_ESTABLECELINDEROS_DESCRIPCION")]
        public String OBLI_ESTABLECELINDEROS_DESCRIPCION { get; set; }
        //20
        [Description("OBLI_IMPLEMENTACIONMEDIDASCORRECTIVAS")]
        public String OBLI_IMPLEMENTACIONMEDIDASCORRECTIVAS { get; set; }
        [Description("OBLI_IMPLEMENTACIONMEDIDASCORRECTIVAS_DESCRIPCION")]
        public String OBLI_IMPLEMENTACIONMEDIDASCORRECTIVAS_DESCRIPCION { get; set; }
        //21
        [Description("OBLI_PROMUEVENBUENASPRACTICAS")]
        public String OBLI_PROMUEVENBUENASPRACTICAS { get; set; }
        [Description("OBLI_PROMUEVENBUENASPRACTICAS_DESCRIPCION")]
        public String OBLI_PROMUEVENBUENASPRACTICAS_DESCRIPCION { get; set; }
        //22
        [Description("OBLI_PROMUEVEEQUIDAD")]
        public String OBLI_PROMUEVEEQUIDAD { get; set; }
        [Description("OBLI_PROMUEVEEQUIDAD_DESCRIPCION")]
        public String OBLI_PROMUEVEEQUIDAD_DESCRIPCION { get; set; }
        //23
        [Description("OBLI_MANTIENEVIGENTEGARANTIA")]
        public String OBLI_MANTIENEVIGENTEGARANTIA { get; set; }
        [Description("OBLI_MANTIENEVIGENTEGARANTIA_DESCRIPCION")]
        public String OBLI_MANTIENEVIGENTEGARANTIA_DESCRIPCION { get; set; }
        //24
        [Description("OBLI_CUMPLECOMPROMISOINVERSION")]
        public String OBLI_CUMPLECOMPROMISOINVERSION { get; set; }
        [Description("OBLI_CUMPLECOMPROMISOINVERSION_DESCRIPCION")]
        public String OBLI_CUMPLECOMPROMISOINVERSION_DESCRIPCION { get; set; }
        #endregion

        #region 14/08/2018 Obligacion Titulares TH No Maderable
        //1
        [Description("OBLI_NM_PRESENTOPMF")]
        public String OBLI_NM_PRESENTOPMF { get; set; }
        [Description("OBLI_NM_PRESENTOPMF_DESCRIPCION")]
        public String OBLI_NM_PRESENTOPMF_DESCRIPCION { get; set; }
        //2
        [Description("OBLI_NM_PRESENTOINFORMEEJECUCION")]
        public String OBLI_NM_PRESENTOINFORMEEJECUCION { get; set; }
        [Description("OBLI_NM_PRESENTOINFORMEEJECUCION_DESCRIPCION")]
        public String OBLI_NM_PRESENTOINFORMEEJECUCION_DESCRIPCION { get; set; }
        //3
        [Description("OBLI_NM_PAGOAPROVECHAMIENTO")]
        public String OBLI_NM_PAGOAPROVECHAMIENTO { get; set; }
        [Description("OBLI_NM_PAGOAPROVECHAMIENTO_DESCRIPCION")]
        public String OBLI_NM_PAGOAPROVECHAMIENTO_DESCRIPCION { get; set; }
        //4
        [Description("OBLI_NM_COMUNICOARFFSOSINFORSUSCRIPCION")]
        public String OBLI_NM_COMUNICOARFFSOSINFORSUSCRIPCION { get; set; }
        [Description("OBLI_NM_COMUNICOARFFSOSINFORSUSCRIPCION_DESCRIPCION")]
        public String OBLI_NM_COMUNICOARFFSOSINFORSUSCRIPCION_DESCRIPCION { get; set; }
        //5
        [Description("OBLI_NM_REPORTOARFFSMINISTERIOAVISTAMIENTOS")]
        public String OBLI_NM_REPORTOARFFSMINISTERIOAVISTAMIENTOS { get; set; }
        [Description("OBLI_NM_REPORTOARFFSMINISTERIOAVISTAMIENTOS_DESCRIPCION")]
        public String OBLI_NM_REPORTOARFFSMINISTERIOAVISTAMIENTOS_DESCRIPCION { get; set; }
        //6
        [Description("OBLI_NM_REALIZOACCIONESCUSTODIO")]
        public String OBLI_NM_REALIZOACCIONESCUSTODIO { get; set; }
        [Description("OBLI_NM_REALIZOACCIONESCUSTODIO_DESCRIPCION")]
        public String OBLI_NM_REALIZOACCIONESCUSTODIO_DESCRIPCION { get; set; }
        //7
        [Description("OBLI_NM_FACILITODESARROLLO")]
        public String OBLI_NM_FACILITODESARROLLO { get; set; }
        [Description("OBLI_NM_FACILITODESARROLLO_DESCRIPCION")]
        public String OBLI_NM_FACILITODESARROLLO_DESCRIPCION { get; set; }
        //8
        [Description("OBLI_NM_ASUMIOCOSTOSUPERVISIONES")]
        public String OBLI_NM_ASUMIOCOSTOSUPERVISIONES { get; set; }
        [Description("OBLI_NM_ASUMIOCOSTOSUPERVISIONES_DESCRIPCION")]
        public String OBLI_NM_ASUMIOCOSTOSUPERVISIONES_DESCRIPCION { get; set; }
        //9
        [Description("OBLI_NM_IMPLEMENTAMECANISMOTRAZA")]
        public String OBLI_NM_IMPLEMENTAMECANISMOTRAZA { get; set; }
        [Description("OBLI_NM_IMPLEMENTAMECANISMOTRAZA_DESCRIPCION")]
        public String OBLI_NM_IMPLEMENTAMECANISMOTRAZA_DESCRIPCION { get; set; }
        //10
        [Description("OBLI_NM_RESPETASERVIDUMBRE")]
        public String OBLI_NM_RESPETASERVIDUMBRE { get; set; }
        [Description("OBLI_NM_RESPETASERVIDUMBRE_DESCRIPCION")]
        public String OBLI_NM_RESPETASERVIDUMBRE_DESCRIPCION { get; set; }
        //11
        [Description("OBLI_NM_ADOPTAMEDIDASEXTENSION")]
        public String OBLI_NM_ADOPTAMEDIDASEXTENSION { get; set; }
        [Description("OBLI_NM_ADOPTAMEDIDASEXTENSION_DESCRIPCION")]
        public String OBLI_NM_ADOPTAMEDIDASEXTENSION_DESCRIPCION { get; set; }
        //12
        [Description("OBLI_NM_RESPETAVALORES")]
        public String OBLI_NM_RESPETAVALORES { get; set; }
        [Description("OBLI_NM_RESPETAVALORES_DESCRIPCION")]
        public String OBLI_NM_RESPETAVALORES_DESCRIPCION { get; set; }
        //13
        [Description("OBLI_NM_CUMPLEMEDIDAS")]
        public String OBLI_NM_CUMPLEMEDIDAS { get; set; }
        [Description("OBLI_NM_CUMPLEMEDIDAS_DESCRIPCION")]
        public String OBLI_NM_CUMPLEMEDIDAS_DESCRIPCION { get; set; }
        //14
        [Description("OBLI_NM_CUMPLENORMAS")]
        public String OBLI_NM_CUMPLENORMAS { get; set; }
        [Description("OBLI_NM_CUMPLENORMAS_DESCRIPCION")]
        public String OBLI_NM_CUMPLENORMAS_DESCRIPCION { get; set; }
        //15
        [Description("OBLI_NM_MOVILIZAFRUTOPRODUCTOS")]
        public String OBLI_NM_MOVILIZAFRUTOPRODUCTOS { get; set; }
        [Description("OBLI_NM_MOVILIZAFRUTOPRODUCTOS_DESCRIPCION")]
        public String OBLI_NM_MOVILIZAFRUTOPRODUCTOS_DESCRIPCION { get; set; }
        //16
        [Description("OBLI_NM_IMPLEMENTACIONMEDIDASCORRECTIVAS")]
        public String OBLI_NM_IMPLEMENTACIONMEDIDASCORRECTIVAS { get; set; }
        [Description("OBLI_NM_IMPLEMENTACIONMEDIDASCORRECTIVAS_DESCRIPCION")]
        public String OBLI_NM_IMPLEMENTACIONMEDIDASCORRECTIVAS_DESCRIPCION { get; set; }
        //17
        [Description("OBLI_NM_IMPMEDCORRECRESULTADOACCIONES")]
        public String OBLI_NM_IMPMEDCORRECRESULTADOACCIONES { get; set; }
        [Description("OBLI_NM_IMPMEDCORRECRESULTADOACCIONES_DESCRIPCION")]
        public String OBLI_NM_IMPMEDCORRECRESULTADOACCIONES_DESCRIPCION { get; set; }
        //18
        [Description("OBLI_NM_PROMUEVENBUENASPRACTICAS")]
        public String OBLI_NM_PROMUEVENBUENASPRACTICAS { get; set; }
        [Description("OBLI_NM_PROMUEVENBUENASPRACTICAS_DESCRIPCION")]
        public String OBLI_NM_PROMUEVENBUENASPRACTICAS_DESCRIPCION { get; set; }
        //19
        [Description("OBLI_NM_PROMUEVEEQUIDAD")]
        public String OBLI_NM_PROMUEVEEQUIDAD { get; set; }
        [Description("OBLI_NM_PROMUEVEEQUIDAD_DESCRIPCION")]
        public String OBLI_NM_PROMUEVEEQUIDAD_DESCRIPCION { get; set; }

        #endregion

        /*SIGOsfc v3*/
        [Category("LIST"), Description("ListCondicionArea")]
        public List<Ent_INFORME_CONDICION_AREA> ListCondicionArea { get; set; }
        [Category("LIST"), Description("ListEvalArbolAdicional")]
        public List<Ent_INFORME_EVAL_ARBOL> ListEvalArbolAdicional { get; set; }
        [Category("LIST"), Description("ListEvalArbolNoAutorizado")]
        public List<Ent_INFORME_EVAL_ARBOL> ListEvalArbolNoAutorizado { get; set; }
        [Category("LIST"), Description("ListHuayrona_v3")]
        public List<Ent_INFORME_HUAYRONA> ListHuayrona_v3 { get; set; }
        [Category("LIST"), Description("ListActividadSilvicultural")]
        public List<Ent_INFORME_ACT_SILVICULTURAL> ListActividadSilvicultural { get; set; }
        [Category("LIST"), Description("ListCambioUso")]
        public List<Ent_INFORME_CAMBIO_USO> ListCambioUso { get; set; }
        [Category("LIST"), Description("ListVerticeArea")]
        public List<Ent_INFORME_VERTICE_AREA> ListVerticeArea { get; set; }
        [Category("LIST"), Description("ListEvaluacionOtro_v3")]
        public List<Ent_INFORME_EVAL_OTRO> ListEvaluacionOtro_v3 { get; set; }
        [Category("LIST"), Description("ListVolumenAnalizado")]
        public List<Ent_INFORME_VOL_ANALIZADO> ListVolumenAnalizado { get; set; }
        //llanos
        [Category("LIST"), Description("ListAnalisis")]
        public List<Ent_INFORME_ANALISIS> ListAnalisis { get; set; }
        [Category("LIST"), Description("ListConsolidado")]
        public List<Ent_INFORME_CONSOLIDADO> ListConsolidado { get; set; }
        [Category("LIST"), Description("ListConsolidadoNN")]
        public List<Ent_INFORME_CONSOLIDADO> ListConsolidadoNN { get; set; }
        [Category("LIST"), Description("ListMaderable")]
        public List<Ent_INFORME_MADERABLE_A> ListMaderable { get; set; }

        [Category("LIST"), Description("ListDesplazamientoInforme")]
        public List<Ent_INFORME> ListDesplazamientoInforme { get; set; }
        [Description("TipoVia")]
        public String TipoVia { get; set; }
        [Description("COD_DESPLAZAMIENTO")]
        public String COD_DESPLAZAMIENTO { get; set; }

        [Description("PTOI_COORDENADA_ESTE")]
        public Int32 PTOI_COORDENADA_ESTE { get; set; }
        [Description("PTOI_COORDENADA_NORTE")]
        public Int32 PTOI_COORDENADA_NORTE { get; set; }
        [Description("PTOF_COORDENADA_ESTE")]
        public Int32 PTOF_COORDENADA_ESTE { get; set; }
        [Description("PTOF_COORDENADA_NORTE")]
        public Int32 PTOF_COORDENADA_NORTE { get; set; }
        //Cambios vertice TH (ahora se enlaza a una adenda)
        [Description("COD_SECUENCIAL_ADENDA")]
        public Int32 COD_SECUENCIAL_ADENDA { get; set; }
        //Evaluación ZoObservatorio
        [Category("LIST"), Description("ListEvalZoObservatorio")]
        public List<Ent_ISUPERVISION_EXSITU_CAUTI_EVALZOO> ListEvalZoObservatorio { get; set; }
        [Description("CALIFICACION_EVALZOO")]
        public double CALIFICACION_EVALZOO { get; set; }

        //TGS:27/08/2021
        [Description("BUEN_DESEMPENIO")]
        public Int32 BUEN_DESEMPENIO { get; set; }
        //TGS:25/09/2021
        [Description("ARCHIVA_INFORME")]
        public Int32 ARCHIVA_INFORME { get; set; }

        //Objetos de clases para el formulario de Conservación y Ecoturismo
        public List<Ent_INFORME_VERTICE> ListVertice { get; set; }
        public List<Ent_INFORME_PROGRAMA> ListPrograma { get; set; }
        public List<Ent_INFORME_REGFLORA> ListRegistroFlora { get; set; }
        public List<Ent_INFORME_REGPAISAJE> ListRegistroPaisaje { get; set; }
        [Description("ESTADO_ESPECIE")]
        public String ESTADO_ESPECIE { get; set; }
        [Description("ESTADO_PAISAJE")]
        public String ESTADO_PAISAJE { get; set; }

        [Description("PCA")]
        public String PCA { get; set; }
        [Description("PCA_CAMPO")]
        public String PCA_CAMPO { get; set; }

        public List<Ent_INFORME_TCONCEPTO> ListTaraConcepto { get; set; }
        public List<Ent_INFORME_TCONCEPTO> ListTaraManPlantacion { get; set; }
        public List<Ent_INFORME_TCENSO> ListTaraCenso { get; set; }
        public List<Ent_INFORME_OBLIGTITULAR> ListObligacionTitular { get; set; }
        public int rowcount { get; set; }
        public List<Ent_INFORME> ListMComboTipoInforme { get; set; }


        //26.04.2021
        [Category("LIST"), Description("ListImpacto")]
        public List<Ent_INFORME_IMPACTO> ListImpacto { get; set; }

        [Category("LIST"), Description("ListEliTABLAImpacto")]
        public List<Ent_INFORME> ListEliTABLAImpacto { get; set; }

        [Category("LIST"), Description("ListAfectacion")]
        public List<Ent_INFORME_IMPACTO> ListAfectacion { get; set; }

        [Category("LIST"), Description("ListEliTABLAfectacion")]
        public List<Ent_INFORME> ListEliTABLAfectacion { get; set; }

        //21.09.2022 TGS
        [Description("COD_TERCERO_SOLIDARIO")]
        public String COD_TERCERO_SOLIDARIO { get; set; }
        [Description("TERCERO_SOLIDARIO")]
        public String TERCERO_SOLIDARIO { get; set; }

        [Category("LIST"), Description("ListMandato")]
        public List<Ent_MANDATOS> ListMandatos { get; set; }

        #region "Constructor"
        public Ent_INFORME()
        {
            AREA_TH = -1;
            AREA_POA = -1;
            B_POA = -1;
            rowcount = -1;
            pagesize = -1;
            currentpage = -1;
            B_DENUNCIA = -1;
            TOTAL_UNIDAD_MUEST = -1;
            TOTAL_UNIDADES_APROV = -1;
            VISITA = -1;
            REPRODUCE = -1;
            Evaluacion_Informe = -1;
            CUENTA_REGENTE = -1;
            CUOTA_SACA = -1;
            TOTAL_UNIDADES = -1;
            TOTAL_UNIDADES_APROVECHABLES = -1;
            ALTURA_PROMEDIO = -1;
            EliVALOR02 = -1;
            ALTITUD = -1;
            NUM_INDICE = -1;
            COD_PROGRAMA = -1;
            NUM_AMBIENTE = -1;
            COORDENADA_SUR_CAMPO = -1;
            NUM_PERSONA = -1;
            AREA_MILEGAL = -1;
            AREA_RECORRIDA = -1;
            NUM_POA = -1;
            RegEstado = -1;
            ANO = -1;
            COD_SECUENCIAL = -1;
            COD_SECUENCIAL_POA = -1;
            N_ARBOL_SUPERVISADO = -1;
            N_ARBOL_PRODUCTIVO = -1;
            N_ARBOL_NOPRODUCTIVO = -1;
            N_ARBOL_PLANTADO = -1;
            N_ARBOL_NOENCONTRADO = -1;
            COORDENADA_ESTE = -1;
            COORDENADA_NORTE = -1;
            COORDENADA_ESTE_POA = -1;
            COORDENADA_NORTE_POA = -1;
            ALTURA_TOTAL = -1;
            PREDIO_AREA = -1;
            N_ARBOL_FVERDE = -1;
            N_ARBOL_FVERDE_MADURO = -1;
            N_ARBOL_FLOR = -1;
            N_ARBOL_NOFRUTO = -1;
            CANTIDAD_AQUINTAL = -1;
            TOTAL_SQUINTAL = -1;
            SALDO_QUINTAL = -1;
            SALDO_MTRES = -1;
            PRIMERA_COSECHA = -1;
            SEGUNDA_COSECHA = -1;
            TOTAL_PROD_ANUAL = -1;
            P_ARBOL_PRODUCTIVO = -1;
            P_ARBOL_NOPRODUCTIVO = -1;
            P_ARBOL_PLANTADO = -1;
            CANTIDAD_AEXTRAER = -1;
            CANTIDAD_EXTRAIDA = -1;
            CANTIDAD_SUPERVISADO = -1;
            CANTIDAD_INJUSTIFICADA = -1;
            COD_PPLANTON = -1;
            COD_TCONCEPTO = -1;
            VAINAS_COD_PRESENCIA = -1;

            DAP_CAMPO = -1;
            AC_CAMPO = -1;
            COORDENADA_ESTE_CAMPO = -1;
            COORDENADA_NORTE_CAMPO = -1;
            DIAMETRO_CAMPO = -1;
            ALTURA_CAMPO = -1;
            PRODUCCION_LATAS_CAMPO = -1;
            DAP = -1;
            AREA = -1;
            BS_ALTURA_TOTAL = -1;
            BS_DIAMETRO_RAMA_1 = -1;
            BS_DIAMETRO_RAMA_2 = -1;
            BS_DIAMETRO_RAMA_3 = -1;
            BS_DIAMETRO_RAMA_4 = -1;
            BS_DIAMETRO_RAMA_5 = -1;
            BS_DIAMETRO_RAMA_6 = -1;
            BS_DIAMETRO_RAMA_7 = -1;
            BS_LONGITUD_RAMA_1 = -1;
            BS_LONGITUD_RAMA_2 = -1;
            BS_LONGITUD_RAMA_3 = -1;
            BS_LONGITUD_RAMA_4 = -1;
            BS_LONGITUD_RAMA_5 = -1;
            BS_LONGITUD_RAMA_6 = -1;
            BS_LONGITUD_RAMA_7 = -1;
            NUM_INDIVIDUOS = -1;

            INEX_AGUAJAL_PORC = -1;
            INEX_PASTIZAL_PORC = -1;
            INEX_INACCESIBLE_PORC = -1;
            INEX_OTROS_PORC = -1;
            INEX_AGUAJAL_NOUB = -1;
            INEX_PASTIZAL_NOUB = -1;
            INEX_INACCESIBLE_NOUB = -1;
            INEX_OTROS_NOUB = -1;
            chkOtrosMateriales = -1;
            chkOtrosMaterialesDesinf = -1;
            ID_TRAMITE_SITD = -1;
            COD_REQUE = -1;

            TIEMPO = -1;
            NUM_PLANTULAS = -1;

            DMC = -1;
            VOLUMEN = -1;
            DIAMETRO = -1;
            ALTURA = -1;
            AC = -1;
            PRODUCCION_LATAS = -1;
            NUM_COCOS_ABIERTOS = -1;
            NUM_COCOS_CERRADOS = -1;
            ESTADO_FILA = -1;
            NUMERO_FILA = -1;

            NUM_TROZAS = -1;
            LARGO = -1;
            LARGO_CAMPO = -1;
            CANTIDAD = -1;
            CANTIDAD_CAMPO = -1;
            NUM_TROZAS_CAMPO = -1;
            VOLUMEN_CAMPO = -1;

            NUM_POA_REPORT = -1;

            DAP2 = -1;
            DAP_CAMPO2 = -1;
            DAP_CAMPO1 = -1;
            LC = -1;
            DAP1 = -1;
            ANCHO = -1;
            ESPESOR = -1;
            PIEZAS = -1;

            VOLUMEN_APROBADO = -1;
            VOLUMEN_MOVILIZADO = -1;
            VOLUMEN_INJUSTIFICADO = -1;
            VOLUMEN_JUSTIFICADO = -1;

            CANT_SOBRE_ESTIMA_DIAMETRO = -1;
            PORC_SOBRE_ESTIMA_DIAMETRO = -1;
            CANT_SUB_ESTIMA_DIAMETRO = -1;
            PORC_SUB_ESTIMA_DIAMETRO = -1;

            COD_TRAMITE_SITD = -1;

            PTOI_COORDENADA_ESTE = -1;
            PTOI_COORDENADA_NORTE = -1;
            PTOF_COORDENADA_ESTE = -1;
            PTOF_COORDENADA_NORTE = -1;

            COD_SECUENCIAL_ADENDA = -1;
            CALIFICACION_EVALZOO = -1;

            NINDICE = -1;

            BUEN_DESEMPENIO = -1;
            ARCHIVA_INFORME = -1;

            COD_SECUENCIAL_POA = -1;
        }
        #endregion
    }

    /// <summary>
    /// 26.04.2021 clase para el imapcto
    /// </summary>
    public class Ent_INFORME_IMPACTO
    {
        [Description("COD_ISUPERVISION_IMPACTO")]
        public string COD_ISUPERVISION_IMPACTO { get; set; }

        [Description("COD_INFORME")]
        public string COD_INFORME { get; set; }

        [Description("COD_ESPECIE")]
        public string COD_ESPECIE { get; set; }

        [Description("NOM_COMUN")]
        public string NOM_COMUN { get; set; }

        [Description("NOM_CIENTIFICO")]
        public string NOM_CIENTIFICO { get; set; }

        [Description("COD_SECUENCIAL")]
        public decimal COD_SECUENCIAL { get; set; }

        [Description("DIAMETRO1")]
        public decimal DIAMETRO1 { get; set; }

        [Description("DIAMETRO2")]
        public decimal DIAMETRO2 { get; set; }

        [Description("LONGITUD")]
        public decimal LONGITUD { get; set; }

        [Description("ESTADO")]
        public string ESTADO { get; set; }

        [Description("OBSERVACIONES")]
        public string OBSERVACIONES { get; set; }

        [Description("COORDENADA_ESTE")]
        public decimal COORDENADA_ESTE { get; set; }

        [Description("COORDENADA_NORTE")]
        public decimal COORDENADA_NORTE { get; set; }

        [Description("ZONA")]
        public string ZONA { get; set; }

        [Description("ACTIVIDAD")]
        public string ACTIVIDAD { get; set; }

        [Description("AREA")]
        public decimal AREA { get; set; }

        [Description("TIPO")]
        public int TIPO { get; set; }

        [Description("RegEstado")]
        public Int32 RegEstado { get; set; }

        public Ent_INFORME_IMPACTO()
        {
            RegEstado = -1;
            TIPO = -1;
            AREA = -1;
            COORDENADA_NORTE = -1;
            COORDENADA_ESTE = -1;
            LONGITUD = -1;
            DIAMETRO2 = -1;
            DIAMETRO1 = -1;
            COD_SECUENCIAL = -1;
        }
    }
    public class Ent_INFORME_CONDICION_AREA
    {
        [Description("COD_INFORME")]
        public string COD_INFORME { get; set; }
        [Description("NUM_POA")]
        public int NUM_POA { get; set; }
        [Description("COD_AREA")]
        public string COD_AREA { get; set; }
        [Description("DESC_AREA")]
        public String DESC_AREA { get; set; }
        [Description("EXISTE_CONDICION")]
        public object EXISTE_CONDICION { get; set; }
        [Description("PORCENTAJE_AREA")]
        public Decimal PORCENTAJE_AREA { get; set; }
        [Description("ARBOL_INEX")]
        public int ARBOL_INEX { get; set; }
        [Description("OBSERVACION_INEX")]
        public string OBSERVACION_INEX { get; set; }

        public Ent_INFORME_CONDICION_AREA()
        {
            PORCENTAJE_AREA = -1;
            ARBOL_INEX = -1;
            NUM_POA = -1;
        }
    }

    public class Ent_INFORME_EVAL_ARBOL
    {
        [Description("COD_ESPECIES")]
        public String COD_ESPECIES { get; set; }
        [Description("DESC_ESPECIES")]
        public String DESC_ESPECIES { get; set; }
        [Description("COD_SECUENCIAL")]
        public Int32 COD_SECUENCIAL { get; set; }
        [Description("BLOQUE")]
        public String BLOQUE { get; set; }
        [Description("FAJA")]
        public String FAJA { get; set; }
        [Description("CODIGO")]
        public String CODIGO { get; set; }
        [Description("DAP")]
        public Decimal DAP { get; set; }
        [Description("DAP1")]
        public Decimal DAP1 { get; set; }
        [Description("DAP2")]
        public Decimal DAP2 { get; set; }
        [Description("MAE_TIP_MMEDIRDAP")]
        public String MAE_TIP_MMEDIRDAP { get; set; }
        [Description("MMEDIR_DAP")]
        public String MMEDIR_DAP { get; set; }
        [Description("AC")]
        public Decimal AC { get; set; }
        [Description("ZONA")]
        public String ZONA { get; set; }
        [Description("COORDENADA_ESTE")]
        public Int32 COORDENADA_ESTE { get; set; }
        [Description("COORDENADA_NORTE")]
        public Int32 COORDENADA_NORTE { get; set; }
        [Description("COD_EESTADO")]
        public String COD_EESTADO { get; set; }
        [Description("DESC_EESTADO")]
        public String DESC_EESTADO { get; set; }
        [Description("DESC_ACATEGORIA_CITE")]
        public String DESC_ACATEGORIA_CITE { get; set; }
        [Description("DESC_ACATEGORIA_DS")]
        public String DESC_ACATEGORIA_DS { get; set; }
        [Description("OBSERVACION")]
        public String OBSERVACION { get; set; }
        [Description("RegEstado")]
        public Int32 RegEstado { get; set; }


        public Ent_INFORME_EVAL_ARBOL()
        {
            COD_SECUENCIAL = -1;
            DAP = -1;
            DAP1 = -1;
            DAP2 = -1;
            AC = -1;
            COORDENADA_ESTE = -1;
            COORDENADA_NORTE = -1;
            RegEstado = -1;

        }
    }

    public class Ent_INFORME_HUAYRONA
    {
        [Description("NUMERO")]
        public String NUMERO { get; set; }
        [Description("ZONA")]
        public String ZONA { get; set; }
        [Description("COORDENADA_ESTE")]
        public Int32 COORDENADA_ESTE { get; set; }
        [Description("COORDENADA_NORTE")]
        public Int32 COORDENADA_NORTE { get; set; }
        [Description("VOLUMEN")]
        public Decimal VOLUMEN { get; set; }
        [Description("RegEstado")]
        public Int32 RegEstado { get; set; }
    }

    public class Ent_INFORME_ACT_SILVICULTURAL
    {
        [Description("COD_ASILVICULTURALES")]
        public String COD_ASILVICULTURALES { get; set; }
        [Description("DESC_SILVICULTURALES")]
        public String DESC_SILVICULTURALES { get; set; }
        [Description("COD_SECUENCIAL")]
        public Int32 COD_SECUENCIAL { get; set; }
        [Description("COD_ESPECIES")]
        public String COD_ESPECIES { get; set; }
        [Description("DESC_ESPECIES")]
        public String DESC_ESPECIES { get; set; }
        [Description("NUM_PLANTULAS")]
        public Int32 NUM_PLANTULAS { get; set; }
        [Description("UBICACION")]
        public String UBICACION { get; set; }
        [Description("TIEMPO")]
        public Int32 TIEMPO { get; set; }
        [Description("FAJA")]
        public String FAJA { get; set; }
        [Description("OBSERVACION")]
        public String OBSERVACION { get; set; }
        [Description("CUMPLIMIENTO_ACTIVIDADES")]
        public object CUMPLIMIENTO_ACTIVIDADES { get; set; }
        [Description("DESC_CUMPLIMIENTO")]
        public String DESC_CUMPLIMIENTO { get; set; }
        [Description("RegEstado")]
        public Int32 RegEstado { get; set; }
    }

    public class Ent_INFORME_CAMBIO_USO
    {
        [Description("MAE_TIP_CAMBIOUSO")]
        public String MAE_TIP_CAMBIOUSO { get; set; }
        [Description("NOM_TIP_CAMBIOUSO")]
        public String NOM_TIP_CAMBIOUSO { get; set; }
        [Description("COD_SECUENCIAL")]
        public Int32 COD_SECUENCIAL { get; set; }
        [Description("AREA")]
        public Decimal AREA { get; set; }
        [Description("ZONA")]
        public String ZONA { get; set; }
        [Description("AUTORIZADO")]
        public String AUTORIZADO { get; set; }
        [Description("COORDENADA_ESTE")]
        public Int32 COORDENADA_ESTE { get; set; }
        [Description("COORDENADA_NORTE")]
        public Int32 COORDENADA_NORTE { get; set; }
        [Description("OBSERVACION")]
        public String OBSERVACION { get; set; }
        [Description("RegEstado")]
        public Int32 RegEstado { get; set; }

        public Ent_INFORME_CAMBIO_USO()
        {
            COD_SECUENCIAL = -1;
            AREA = -1;
            RegEstado = -1;
        }
    }

    public class Ent_INFORME_VERTICE_AREA
    {
        [Description("COD_SECUENCIAL_POA")]
        public Int32 COD_SECUENCIAL_POA { get; set; }
        [Description("COD_SECUENCIAL")]
        public Int32 COD_SECUENCIAL { get; set; }        
        [Description("ZONA")]
        public String ZONA { get; set; }
        [Description("ZONA_CAMPO")]
        public String ZONA_CAMPO { get; set; }
        [Description("COD_SISTEMA")]
        public String COD_SISTEMA { get; set; }
        [Description("COORDENADA_ESTE")]
        public Int32 COORDENADA_ESTE { get; set; }
        [Description("COORDENADA_ESTE_CAMPO")]
        public Int32 COORDENADA_ESTE_CAMPO { get; set; }
        [Description("COORDENADA_NORTE")]
        public Int32 COORDENADA_NORTE { get; set; }       
        [Description("COORDENADA_NORTE_CAMPO")]
        public Int32 COORDENADA_NORTE_CAMPO { get; set; }
        [Description("OBSERVACION")]
        public String OBSERVACION { get; set; }
        [Description("VERTICE")]
        public String VERTICE { get; set; }
        [Description("VERTICE_CAMPO")]
        public String VERTICE_CAMPO { get; set; }
        [Description("RegEstado")]
        public Int32 RegEstado { get; set; }
        //parcela
        [Description("PCA")]
        public String PCA { get; set; }
        [Description("PCA_CAMPO")]
        public String PCA_CAMPO { get; set; }
        
        public Ent_INFORME_VERTICE_AREA()
        {
            COD_SECUENCIAL_POA = -1;
            COD_SECUENCIAL = -1;
            COORDENADA_ESTE = -1;
            COORDENADA_NORTE = -1;
            RegEstado = -1;
            COORDENADA_ESTE_CAMPO = -1;
            COORDENADA_NORTE_CAMPO = -1;
            COD_SECUENCIAL_POA = -1;
        }
    }

    public class Ent_INFORME_EVAL_OTRO
    {
        [Description("COD_SECUENCIAL")]
        public Int32 COD_SECUENCIAL { get; set; }
        [Description("EVALUACION")]
        public String EVALUACION { get; set; }
        [Description("ZONA")]
        public String ZONA { get; set; }
        [Description("COORDENADA_ESTE")]
        public Int32 COORDENADA_ESTE { get; set; }
        [Description("COORDENADA_NORTE")]
        public Int32 COORDENADA_NORTE { get; set; }
        [Description("DESCRIPCION")]
        public String DESCRIPCION { get; set; }
        [Description("RegEstado")]
        public Int32 RegEstado { get; set; }

        public Ent_INFORME_EVAL_OTRO()
        {
            COD_SECUENCIAL = -1;
            COORDENADA_ESTE = -1;
            COORDENADA_NORTE = -1;
            RegEstado = -1;
        }
    }

    public class Ent_INFORME_VOL_ANALIZADO
    {
        [Description("COD_SECUENCIAL")]
        public Int32 COD_SECUENCIAL { get; set; }
        [Description("COD_ESPECIES")]
        public String COD_ESPECIES { get; set; }
        [Description("ESPECIES")]
        public String ESPECIES { get; set; }
        [Description("NUM_ARBOLES")]
        public decimal NUM_ARBOLES { get; set; }
        [Description("BALANCE_EXTRACCION")]
        public decimal BALANCE_EXTRACCION { get; set; }
        [Description("ESTADO_CAMPO")]
        public string ESTADO_CAMPO { get; set; }
        [Description("VOLUMEN_APROBADO")]
        public decimal VOLUMEN_APROBADO { get; set; }         
        [Description("VOLUMEN_MOVILIZADO")]
        public decimal VOLUMEN_MOVILIZADO { get; set; }
        [Description("VOLUMEN_INJUSTIFICADO")]
        public decimal VOLUMEN_INJUSTIFICADO { get; set; }
        [Description("VOLUMEN_JUSTIFICADO")]
        public decimal VOLUMEN_JUSTIFICADO { get; set; }
        [Description("OBSERVACION")]
        public String OBSERVACION { get; set; }
        [Description("RegEstado")]
        public Int32 RegEstado { get; set; }

        [Description("PC")]
        public String PCA { get; set; }
        public Ent_INFORME_VOL_ANALIZADO()
        {
            COD_SECUENCIAL = -1;
            VOLUMEN_APROBADO = -1;
            VOLUMEN_MOVILIZADO = -1;
            VOLUMEN_INJUSTIFICADO = -1;
            VOLUMEN_JUSTIFICADO = -1;
            RegEstado = -1;
        }
    }

    public class Ent_INFORME_MADERABLE
    {
        [Description("COD_INFORME")]
        public String COD_INFORME { get; set; }
        [Description("COD_SECUENCIAL")]
        public Int32 COD_SECUENCIAL { get; set; }
        [Description("COD_THABILITANTE")]
        public String COD_THABILITANTE { get; set; }
        [Description("NUM_POA")]
        public Int32 NUM_POA { get; set; }
        [Description("POA")]
        public String POA { get; set; }
        [Description("BLOQUE")]
        public String BLOQUE { get; set; }
        [Description("BLOQUE_CAMPO")]
        public String BLOQUE_CAMPO { get; set; }
        [Description("FAJA")]
        public String FAJA { get; set; }
        [Description("FAJA_CAMPO")]
        public String FAJA_CAMPO { get; set; }
        [Description("CODIGO")]
        public String CODIGO { get; set; }
        [Description("CODIGO_CAMPO")]
        public String CODIGO_CAMPO { get; set; }
        [Description("COD_ESPECIES")]
        public String COD_ESPECIES { get; set; }
        [Description("DESC_ESPECIES")]
        public String DESC_ESPECIES { get; set; }
        [Description("COD_ESPECIES_CAMPO")]
        public String COD_ESPECIES_CAMPO { get; set; }
        [Description("DESC_ESPECIES_CAMPO")]
        public String DESC_ESPECIES_CAMPO { get; set; }
        [Description("COINCIDE_ESPECIES")]
        public String COINCIDE_ESPECIES { get; set; }
        [Description("DESC_COINCIDE_ESPECIES")]
        public String DESC_COINCIDE_ESPECIES { get; set; }
        [Description("ZONA")]
        public String ZONA { get; set; }
        [Description("ZONA_CAMPO")]
        public String ZONA_CAMPO { get; set; }
        [Description("COORDENADA_ESTE")]
        public Int32 COORDENADA_ESTE { get; set; }
        [Description("COORDENADA_ESTE_CAMPO")]
        public Int32 COORDENADA_ESTE_CAMPO { get; set; }
        [Description("COORDENADA_NORTE")]
        public Int32 COORDENADA_NORTE { get; set; }
        [Description("COORDENADA_NORTE_CAMPO")]
        public Int32 COORDENADA_NORTE_CAMPO { get; set; }
        [Description("DAP")]
        public Decimal DAP { get; set; }
        [Description("DAP_CAMPO")]
        public Decimal DAP_CAMPO { get; set; }
        [Description("DAP_CAMPO1")]
        public Decimal DAP_CAMPO1 { get; set; }
        [Description("DAP_CAMPO2")]
        public Decimal DAP_CAMPO2 { get; set; }
        [Description("MAE_TIP_MMEDIRDAP")]
        public String MAE_TIP_MMEDIRDAP { get; set; }
        [Description("MMEDIR_DAP")]
        public String MMEDIR_DAP { get; set; }
        [Description("VIGENCIA")]
        public String VIGENCIA { get; set; }
        [Description("AC")]
        public Decimal AC { get; set; }
        [Description("AC_CAMPO")]
        public Decimal AC_CAMPO { get; set; }
        [Description("DESC_EESTADO")]
        public String DESC_EESTADO { get; set; }
        [Description("COD_EESTADO")]
        public String COD_EESTADO { get; set; }
        [Description("DESC_EESTADO_CAMPO")]
        public String DESC_EESTADO_CAMPO { get; set; }
        [Description("COD_ECONDICION")]
        public String COD_ECONDICION { get; set; }
        [Description("DESC_ECONDICION")]
        public String DESC_ECONDICION { get; set; }
        [Description("COD_ECONDICION_CAMPO")]
        public String COD_ECONDICION_CAMPO { get; set; }
        [Description("DESC_ECONDICION_CAMPO")]
        public String DESC_ECONDICION_CAMPO { get; set; }
        [Description("CANT_SOBRE_ESTIMA_DIAMETRO")]
        public Int32 CANT_SOBRE_ESTIMA_DIAMETRO { get; set; }
        [Description("PORC_SOBRE_ESTIMA_DIAMETRO")]
        public Decimal PORC_SOBRE_ESTIMA_DIAMETRO { get; set; }
        [Description("CANT_SUB_ESTIMA_DIAMETRO")]
        public Int32 CANT_SUB_ESTIMA_DIAMETRO { get; set; }
        [Description("PORC_SUB_ESTIMA_DIAMETRO")]
        public Decimal PORC_SUB_ESTIMA_DIAMETRO { get; set; }
        [Description("VOLUMEN")]
        public Decimal VOLUMEN { get; set; }
        [Description("OBSERVACION")]
        public String OBSERVACION { get; set; }
        [Description("RegEstado")]
        public Int32 RegEstado { get; set; }

        [Description("PCA")]
        public String PCA { get; set; }

        [Description("PCA_POA")]
        public String PCA_POA { get; set; }

        public Ent_INFORME_MADERABLE()
        {
            COD_SECUENCIAL = -1;
            NUM_POA = -1;
            COORDENADA_ESTE = -1;
            COORDENADA_NORTE = -1;
            COORDENADA_ESTE_CAMPO = -1;
            COORDENADA_NORTE_CAMPO = -1;
            DAP = -1;
            DAP_CAMPO = -1;
            DAP_CAMPO1 = -1;
            DAP_CAMPO2 = -1;
            AC = -1;
            AC_CAMPO = -1;
            CANT_SOBRE_ESTIMA_DIAMETRO = -1;
            PORC_SOBRE_ESTIMA_DIAMETRO = -1;
            CANT_SUB_ESTIMA_DIAMETRO = -1;
            PORC_SUB_ESTIMA_DIAMETRO = -1;
            RegEstado = -1;
        }
    }

    public class Ent_INFORME_BOSQUE_SECO
    {
        [Description("COD_INFORME")]
        public String COD_INFORME { get; set; }
        [Description("COD_SECUENCIAL")]
        public Int32 COD_SECUENCIAL { get; set; }
        [Description("COD_THABILITANTE")]
        public String COD_THABILITANTE { get; set; }
        [Description("NUM_POA")]
        public Int32 NUM_POA { get; set; }
        [Description("POA")]
        public String POA { get; set; }
        [Description("COD_ESPECIES")]
        public String COD_ESPECIES { get; set; }
        [Description("DESC_ESPECIES")]
        public String DESC_ESPECIES { get; set; }
        [Description("COD_ESPECIES_CAMPO")]
        public String COD_ESPECIES_CAMPO { get; set; }
        [Description("DESC_ESPECIES_CAMPO")]
        public String DESC_ESPECIES_CAMPO { get; set; }
        [Description("BLOQUE")]
        public String BLOQUE { get; set; }
        [Description("BLOQUE_CAMPO")]
        public String BLOQUE_CAMPO { get; set; }
        [Description("FAJA")]
        public String FAJA { get; set; }
        [Description("FAJA_CAMPO")]
        public String FAJA_CAMPO { get; set; }
        [Description("CODIGO")]
        public String CODIGO { get; set; }
        [Description("CODIGO_CAMPO")]
        public String CODIGO_CAMPO { get; set; }
        [Description("DAP")]
        public Decimal DAP { get; set; }
        [Description("DAP_CAMPO")]
        public Decimal DAP_CAMPO { get; set; }
        [Description("AC")]
        public Decimal AC { get; set; }
        [Description("AC_CAMPO")]
        public Decimal AC_CAMPO { get; set; }
        [Description("ZONA")]
        public String ZONA { get; set; }
        [Description("ZONA_CAMPO")]
        public String ZONA_CAMPO { get; set; }
        [Description("COORDENADA_ESTE")]
        public Int32 COORDENADA_ESTE { get; set; }
        [Description("COORDENADA_ESTE_CAMPO")]
        public Int32 COORDENADA_ESTE_CAMPO { get; set; }
        [Description("COORDENADA_NORTE")]
        public Int32 COORDENADA_NORTE { get; set; }
        [Description("COORDENADA_NORTE_CAMPO")]
        public Int32 COORDENADA_NORTE_CAMPO { get; set; }
        [Description("DESC_EESTADO")]
        public String DESC_EESTADO { get; set; }
        [Description("COD_EESTADO")]
        public String COD_EESTADO { get; set; }
        [Description("DESC_EESTADO_CAMPO")]
        public String DESC_EESTADO_CAMPO { get; set; }
        [Description("DESC_ACATEGORIA_CITE")]
        public String DESC_ACATEGORIA_CITE { get; set; }
        [Description("DESC_ACATEGORIA_DS")]
        public String DESC_ACATEGORIA_DS { get; set; }
        [Description("BS_ALTURA_TOTAL")]
        public decimal BS_ALTURA_TOTAL { get; set; }
        [Description("BS_DIAMETRO_RAMA_1")]
        public decimal BS_DIAMETRO_RAMA_1 { get; set; }
        [Description("BS_DIAMETRO_RAMA_2")]
        public decimal BS_DIAMETRO_RAMA_2 { get; set; }
        [Description("BS_DIAMETRO_RAMA_3")]
        public decimal BS_DIAMETRO_RAMA_3 { get; set; }
        [Description("BS_DIAMETRO_RAMA_4")]
        public decimal BS_DIAMETRO_RAMA_4 { get; set; }
        [Description("BS_DIAMETRO_RAMA_5")]
        public decimal BS_DIAMETRO_RAMA_5 { get; set; }
        [Description("BS_DIAMETRO_RAMA_6")]
        public decimal BS_DIAMETRO_RAMA_6 { get; set; }
        [Description("BS_DIAMETRO_RAMA_7")]
        public decimal BS_DIAMETRO_RAMA_7 { get; set; }
        [Description("BS_LONGITUD_RAMA_1")]
        public decimal BS_LONGITUD_RAMA_1 { get; set; }
        [Description("BS_LONGITUD_RAMA_2")]
        public decimal BS_LONGITUD_RAMA_2 { get; set; }
        [Description("BS_LONGITUD_RAMA_3")]
        public decimal BS_LONGITUD_RAMA_3 { get; set; }
        [Description("BS_LONGITUD_RAMA_4")]
        public decimal BS_LONGITUD_RAMA_4 { get; set; }
        [Description("BS_LONGITUD_RAMA_5")]
        public decimal BS_LONGITUD_RAMA_5 { get; set; }
        [Description("BS_LONGITUD_RAMA_6")]
        public decimal BS_LONGITUD_RAMA_6 { get; set; }
        [Description("BS_LONGITUD_RAMA_7")]
        public decimal BS_LONGITUD_RAMA_7 { get; set; }
        [Description("OBSERVACION")]
        public String OBSERVACION { get; set; }
        [Description("RegEstado")]
        public Int32 RegEstado { get; set; }

        public Ent_INFORME_BOSQUE_SECO()
        {
            COD_SECUENCIAL = -1;
            NUM_POA = -1;
            COORDENADA_ESTE = -1;
            COORDENADA_NORTE = -1;
            COORDENADA_ESTE_CAMPO = -1;
            COORDENADA_NORTE_CAMPO = -1;
            DAP = -1;
            DAP_CAMPO = -1;
            AC = -1;
            AC_CAMPO = -1;
            BS_ALTURA_TOTAL = -1;
            BS_DIAMETRO_RAMA_1 = -1;
            BS_DIAMETRO_RAMA_2 = -1;
            BS_DIAMETRO_RAMA_3 = -1;
            BS_DIAMETRO_RAMA_4 = -1;
            BS_DIAMETRO_RAMA_5 = -1;
            BS_DIAMETRO_RAMA_6 = -1;
            BS_DIAMETRO_RAMA_7 = -1;
            BS_LONGITUD_RAMA_1 = -1;
            BS_LONGITUD_RAMA_2 = -1;
            BS_LONGITUD_RAMA_3 = -1;
            BS_LONGITUD_RAMA_4 = -1;
            BS_LONGITUD_RAMA_5 = -1;
            BS_LONGITUD_RAMA_6 = -1;
            BS_LONGITUD_RAMA_7 = -1;
            RegEstado = -1;
        }
    }

    public class Ent_INFORME_SEMILLERO
    {
        [Description("COD_INFORME")]
        public String COD_INFORME { get; set; }
        [Description("COD_SECUENCIAL")]
        public Int32 COD_SECUENCIAL { get; set; }
        [Description("COD_THABILITANTE")]
        public String COD_THABILITANTE { get; set; }
        [Description("NUM_POA")]
        public Int32 NUM_POA { get; set; }
        [Description("POA")]
        public String POA { get; set; }
        [Description("COD_ESPECIES")]
        public String COD_ESPECIES { get; set; }
        [Description("DESC_ESPECIES")]
        public String DESC_ESPECIES { get; set; }
        [Description("COD_ESPECIES_CAMPO")]
        public String COD_ESPECIES_CAMPO { get; set; }
        [Description("DESC_ESPECIES_CAMPO")]
        public String DESC_ESPECIES_CAMPO { get; set; }
        [Description("BLOQUE")]
        public String BLOQUE { get; set; }
        [Description("BLOQUE_CAMPO")]
        public String BLOQUE_CAMPO { get; set; }
        [Description("FAJA")]
        public String FAJA { get; set; }
        [Description("FAJA_CAMPO")]
        public String FAJA_CAMPO { get; set; }
        [Description("CODIGO")]
        public String CODIGO { get; set; }
        [Description("CODIGO_CAMPO")]
        public String CODIGO_CAMPO { get; set; }
        [Description("COINCIDE_ESPECIES")]
        public String COINCIDE_ESPECIES { get; set; }
        [Description("DESC_COINCIDE_ESPECIES")]
        public String DESC_COINCIDE_ESPECIES { get; set; }
        [Description("ZONA")]
        public String ZONA { get; set; }
        [Description("ZONA_CAMPO")]
        public String ZONA_CAMPO { get; set; }
        [Description("COORDENADA_ESTE")]
        public Int32 COORDENADA_ESTE { get; set; }
        [Description("COORDENADA_ESTE_CAMPO")]
        public Int32 COORDENADA_ESTE_CAMPO { get; set; }
        [Description("COORDENADA_NORTE")]
        public Int32 COORDENADA_NORTE { get; set; }
        [Description("COORDENADA_NORTE_CAMPO")]
        public Int32 COORDENADA_NORTE_CAMPO { get; set; }
        [Description("DAP")]
        public Decimal DAP { get; set; }
        [Description("DAP_CAMPO")]
        public Decimal DAP_CAMPO { get; set; }
        [Description("DAP_CAMPO1")]
        public Decimal DAP_CAMPO1 { get; set; }
        [Description("DAP_CAMPO2")]
        public Decimal DAP_CAMPO2 { get; set; }
        [Description("MAE_TIP_MMEDIRDAP")]
        public String MAE_TIP_MMEDIRDAP { get; set; }
        [Description("MMEDIR_DAP")]
        public String MMEDIR_DAP { get; set; }
        [Description("AC")]
        public Decimal AC { get; set; }
        [Description("AC_CAMPO")]
        public Decimal AC_CAMPO { get; set; }
        [Description("DESC_EESTADO")]
        public String DESC_EESTADO { get; set; }
        [Description("COD_EESTADO")]
        public String COD_EESTADO { get; set; }
        [Description("DESC_EESTADO_CAMPO")]
        public String DESC_EESTADO_CAMPO { get; set; }
        [Description("COD_EFENOLOGICO")]
        public String COD_EFENOLOGICO { get; set; }
        [Description("DESC_EFENOLOGICO")]
        public String DESC_EFENOLOGICO { get; set; }
        [Description("COD_CFUSTE")]
        public String COD_CFUSTE { get; set; }
        [Description("DESC_CFUSTE")]
        public String DESC_CFUSTE { get; set; }
        [Description("COD_FCOPA")]
        public String COD_FCOPA { get; set; }
        [Description("DESC_FCOPA")]
        public String DESC_FCOPA { get; set; }
        [Description("COD_PCOPA")]
        public String COD_PCOPA { get; set; }
        [Description("DESC_PCOPA")]
        public String DESC_PCOPA { get; set; }
        [Description("COD_ESANITARIO")]
        public String COD_ESANITARIO { get; set; }
        [Description("DESC_ESANITARIO")]
        public String DESC_ESANITARIO { get; set; }
        [Description("COD_ILIANAS")]
        public String COD_ILIANAS { get; set; }
        [Description("DESC_ILIANAS")]
        public String DESC_ILIANAS { get; set; }
        [Description("CANT_SOBRE_ESTIMA_DIAMETRO")]
        public Int32 CANT_SOBRE_ESTIMA_DIAMETRO { get; set; }
        [Description("PORC_SOBRE_ESTIMA_DIAMETRO")]
        public Decimal PORC_SOBRE_ESTIMA_DIAMETRO { get; set; }
        [Description("CANT_SUB_ESTIMA_DIAMETRO")]
        public Int32 CANT_SUB_ESTIMA_DIAMETRO { get; set; }
        [Description("PORC_SUB_ESTIMA_DIAMETRO")]
        public Decimal PORC_SUB_ESTIMA_DIAMETRO { get; set; }
        [Description("OBSERVACION")]
        public String OBSERVACION { get; set; }
        [Description("RegEstado")]
        public Int32 RegEstado { get; set; }

        [Description("PCA")]
        public String PCA { get; set; }

        [Description("PCA_POA")]
        public String PCA_POA { get; set; }

        public Ent_INFORME_SEMILLERO()
        {
            COD_SECUENCIAL = -1;
            NUM_POA = -1;
            COORDENADA_ESTE = -1;
            COORDENADA_NORTE = -1;
            COORDENADA_ESTE_CAMPO = -1;
            COORDENADA_NORTE_CAMPO = -1;
            DAP = -1;
            DAP_CAMPO = -1;
            DAP_CAMPO1 = -1;
            DAP_CAMPO2 = -1;
            AC = -1;
            AC_CAMPO = -1;
            CANT_SOBRE_ESTIMA_DIAMETRO = -1;
            PORC_SOBRE_ESTIMA_DIAMETRO = -1;
            CANT_SUB_ESTIMA_DIAMETRO = -1;
            PORC_SUB_ESTIMA_DIAMETRO = -1;
            RegEstado = -1;
        }
    }

    public class Ent_INFORME_NO_MADERABLE
    {
        [Description("COD_INFORME")]
        public String COD_INFORME { get; set; }
        [Description("COD_SECUENCIAL")]
        public Int32 COD_SECUENCIAL { get; set; }
        [Description("COD_THABILITANTE")]
        public String COD_THABILITANTE { get; set; }
        [Description("NUM_POA")]
        public Int32 NUM_POA { get; set; }
        [Description("POA")]
        public String POA { get; set; }
        [Description("COD_ESPECIES")]
        public String COD_ESPECIES { get; set; }
        [Description("DESC_ESPECIES")]
        public String DESC_ESPECIES { get; set; }
        [Description("COD_ESPECIES_CAMPO")]
        public String COD_ESPECIES_CAMPO { get; set; }
        [Description("DESC_ESPECIES_CAMPO")]
        public String DESC_ESPECIES_CAMPO { get; set; }
        [Description("NUM_ESTRADA")]
        public String NUM_ESTRADA { get; set; }
        [Description("NUM_ESTRADA_CAMPO")]
        public String NUM_ESTRADA_CAMPO { get; set; }
        [Description("CODIGO")]
        public String CODIGO { get; set; }
        [Description("CODIGO_CAMPO")]
        public String CODIGO_CAMPO { get; set; }
        [Description("DIAMETRO")]
        public Decimal DIAMETRO { get; set; }
        [Description("DIAMETRO_CAMPO")]
        public decimal DIAMETRO_CAMPO { get; set; }
        [Description("ALTURA")]
        public Decimal ALTURA { get; set; }
        [Description("ALTURA_CAMPO")]
        public decimal ALTURA_CAMPO { get; set; }
        [Description("PRODUCCION_LATAS")]
        public Decimal PRODUCCION_LATAS { get; set; }
        [Description("PRODUCCION_LATAS_CAMPO")]
        public decimal PRODUCCION_LATAS_CAMPO { get; set; }
        [Description("ZONA")]
        public String ZONA { get; set; }
        [Description("ZONA_CAMPO")]
        public String ZONA_CAMPO { get; set; }
        [Description("COORDENADA_ESTE")]
        public Int32 COORDENADA_ESTE { get; set; }
        [Description("COORDENADA_ESTE_CAMPO")]
        public Int32 COORDENADA_ESTE_CAMPO { get; set; }
        [Description("COORDENADA_NORTE")]
        public Int32 COORDENADA_NORTE { get; set; }
        [Description("COORDENADA_NORTE_CAMPO")]
        public Int32 COORDENADA_NORTE_CAMPO { get; set; }
        [Description("COD_EESTADO")]
        public String COD_EESTADO { get; set; }
        [Description("DESC_EESTADO_CAMPO")]
        public String DESC_EESTADO_CAMPO { get; set; }
        [Description("NUM_COCOS_ABIERTOS")]
        public Int32 NUM_COCOS_ABIERTOS { get; set; }
        [Description("NUM_COCOS_CERRADOS")]
        public Int32 NUM_COCOS_CERRADOS { get; set; }
        [Description("COD_CFUSTE")]
        public String COD_CFUSTE { get; set; }
        [Description("DESC_CFUSTE")]
        public String DESC_CFUSTE { get; set; }
        [Description("COD_PCOPA")]
        public String COD_PCOPA { get; set; }
        [Description("DESC_PCOPA")]
        public String DESC_PCOPA { get; set; }
        [Description("COD_FCOPA")]
        public String COD_FCOPA { get; set; }
        [Description("DESC_FCOPA")]
        public String DESC_FCOPA { get; set; }
        [Description("COD_EFENOLOGICO")]
        public String COD_EFENOLOGICO { get; set; }
        [Description("DESC_EFENOLOGICO")]
        public String DESC_EFENOLOGICO { get; set; }
        [Description("COD_ESANITARIO")]
        public String COD_ESANITARIO { get; set; }
        [Description("DESC_ESANITARIO")]
        public String DESC_ESANITARIO { get; set; }
        [Description("COD_ILIANAS")]
        public String COD_ILIANAS { get; set; }
        [Description("DESC_ILIANAS")]
        public String DESC_ILIANAS { get; set; }
        [Description("COD_ECONDICION")]
        public String COD_ECONDICION { get; set; }
        [Description("DESC_ECONDICION")]
        public String DESC_ECONDICION { get; set; }
        [Description("COD_ECONDICION_CAMPO")]
        public String COD_ECONDICION_CAMPO { get; set; }
        [Description("DESC_ECONDICION_CAMPO")]
        public String DESC_ECONDICION_CAMPO { get; set; }
        [Description("OBSERVACION")]
        public String OBSERVACION { get; set; }
        [Description("RegEstado")]
        public Int32 RegEstado { get; set; }

        public Ent_INFORME_NO_MADERABLE()
        {
            COD_SECUENCIAL = -1;
            NUM_POA = -1;
            COORDENADA_ESTE = -1;
            COORDENADA_NORTE = -1;
            COORDENADA_ESTE_CAMPO = -1;
            COORDENADA_NORTE_CAMPO = -1;
            DIAMETRO = -1;
            DIAMETRO_CAMPO = -1;
            ALTURA = -1;
            ALTURA_CAMPO = -1;
            PRODUCCION_LATAS = -1;
            PRODUCCION_LATAS_CAMPO = -1;
            NUM_COCOS_ABIERTOS = -1;
            NUM_COCOS_CERRADOS = -1;
            RegEstado = -1;
        }
    }

    public class Ent_INFORME_TROZA_CAMPO
    {
        [Description("COD_INFORME")]
        public String COD_INFORME { get; set; }
        [Description("COD_SECUENCIAL")]
        public Int32 COD_SECUENCIAL { get; set; }
        [Description("COD_THABILITANTE")]
        public String COD_THABILITANTE { get; set; }
        [Description("NUM_POA")]
        public Int32 NUM_POA { get; set; }
        [Description("CODIGO")]
        public String CODIGO { get; set; }
        [Description("COD_ESPECIES")]
        public String COD_ESPECIES { get; set; }
        [Description("ESPECIES")]
        public String ESPECIES { get; set; }
        [Description("ZONA")]
        public String ZONA { get; set; }
        [Description("COORDENADA_ESTE")]
        public Int32 COORDENADA_ESTE { get; set; }
        [Description("COORDENADA_NORTE")]
        public Int32 COORDENADA_NORTE { get; set; }
        [Description("DAP1")]
        public Decimal DAP1 { get; set; }
        [Description("DAP2")]
        public Decimal DAP2 { get; set; }
        [Description("LC")]
        public Decimal LC { get; set; }
        [Description("OBSERVACION")]
        public String OBSERVACION { get; set; }
        [Description("RegEstado")]
        public Int32 RegEstado { get; set; }

        public Ent_INFORME_TROZA_CAMPO()
        {
            COD_SECUENCIAL = -1;
            NUM_POA = -1;
            COORDENADA_ESTE = -1;
            COORDENADA_NORTE = -1;
            DAP1 = -1;
            DAP2 = -1;
            LC = -1;
            RegEstado = -1;
        }
    }

    public class Ent_INFORME_MADERA_ASERRADA
    {
        [Description("COD_INFORME")]
        public String COD_INFORME { get; set; }
        [Description("COD_SECUENCIAL")]
        public Int32 COD_SECUENCIAL { get; set; }
        [Description("COD_THABILITANTE")]
        public String COD_THABILITANTE { get; set; }
        [Description("NUM_POA")]
        public Int32 NUM_POA { get; set; }
        [Description("CODIGO")]
        public String CODIGO { get; set; }
        [Description("COD_ESPECIES")]
        public String COD_ESPECIES { get; set; }
        [Description("ESPECIES")]
        public String ESPECIES { get; set; }
        [Description("PIEZAS")]
        public Int32 PIEZAS { get; set; }
        [Description("ZONA")]
        public String ZONA { get; set; }
        [Description("COORDENADA_ESTE")]
        public Int32 COORDENADA_ESTE { get; set; }
        [Description("COORDENADA_NORTE")]
        public Int32 COORDENADA_NORTE { get; set; }
        [Description("ESPESOR")]
        public Decimal ESPESOR { get; set; }
        [Description("ANCHO")]
        public Decimal ANCHO { get; set; }
        [Description("LARGO")]
        public Decimal LARGO { get; set; }
        [Description("OBSERVACION")]
        public String OBSERVACION { get; set; }
        [Description("RegEstado")]
        public Int32 RegEstado { get; set; }

        public Ent_INFORME_MADERA_ASERRADA()
        {
            COD_SECUENCIAL = -1;
            NUM_POA = -1;
            PIEZAS = -1;
            COORDENADA_ESTE = -1;
            COORDENADA_NORTE = -1;
            ESPESOR = -1;
            ANCHO = -1;
            LARGO = -1;
            RegEstado = -1;
        }
    }

    public class Ent_INFORME_CARRIZO_CAMPO
    {
        [Description("COD_INFORME")]
        public String COD_INFORME { get; set; }
        [Description("COD_THABILITANTE")]
        public String COD_THABILITANTE { get; set; }
        [Description("NUM_POA")]
        public Int32 NUM_POA { get; set; }
        [Description("COD_MUESTRA_SUPERVISION")]
        public Int32 COD_MUESTRA_SUPERVISION { get; set; }
        [Description("COD_ESPECIES")]
        public String COD_ESPECIES { get; set; }
        [Description("ESPECIES")]
        public String ESPECIES { get; set; }
        [Description("TOTAL_UNIDAD_MUEST")]
        public Int32 TOTAL_UNIDAD_MUEST { get; set; }
        [Description("TOTAL_UNIDADES_APROV")]
        public Int32 TOTAL_UNIDADES_APROV { get; set; }
        [Description("ZONA")]
        public String ZONA { get; set; }
        [Description("COORDENADA_ESTE")]
        public Int32 COORDENADA_ESTE { get; set; }
        [Description("COORDENADA_NORTE")]
        public Int32 COORDENADA_NORTE { get; set; }
        [Description("ALTURA_PROMEDIO")]
        public Decimal ALTURA_PROMEDIO { get; set; }
        [Description("UNIDAD_MEDIDA")]
        public String UNIDAD_MEDIDA { get; set; }
        [Description("NUM_INDIVIDUOS")]
        public Int32 NUM_INDIVIDUOS { get; set; }
        [Description("PRODUCTO_EXTRAER")]
        public String PRODUCTO_EXTRAER { get; set; }
        [Description("OBSERVACION")]
        public String OBSERVACION { get; set; }
        [Description("RegEstado")]
        public Int32 RegEstado { get; set; }
        [Description("COD_UCUENTA")]
        public String COD_UCUENTA { get; set; }

        public Ent_INFORME_CARRIZO_CAMPO()
        {
            NUM_POA = -1;
            TOTAL_UNIDADES_APROV = -1;
            TOTAL_UNIDAD_MUEST = -1;
            COORDENADA_ESTE = -1;
            COORDENADA_NORTE = -1;
            ALTURA_PROMEDIO = -1;
            NUM_INDIVIDUOS = -1;
            RegEstado = -1;
            COD_MUESTRA_SUPERVISION = -1;
        }
    }

    public class Ent_INFORME_VERTICE_VERIFICADO
    {
        [Description("COD_INFORME")]
        public String COD_INFORME { get; set; }
        [Description("COD_THABILITANTE")]
        public String COD_THABILITANTE { get; set; }
        [Description("NUM_POA")]
        public Int32 NUM_POA { get; set; }
        [Description("COD_INFORME_VERTICE")]
        public String COD_INFORME_VERTICE { get; set; }
        [Description("VERTICE")]
        public String VERTICE { get; set; }
        [Description("VERTICE_CAMPO")]
        public String VERTICE_CAMPO { get; set; }
        [Description("ZONA")]
        public String ZONA { get; set; }
        [Description("ZONA_CAMPO")]
        public String ZONA_CAMPO { get; set; }
        [Description("COORDENADA_ESTE")]
        public Int32 COORDENADA_ESTE { get; set; }
        [Description("COORDENADA_ESTE_CAMPO")]
        public Int32 COORDENADA_ESTE_CAMPO { get; set; }
        [Description("COORDENADA_NORTE")]
        public Int32 COORDENADA_NORTE { get; set; }
        [Description("COORDENADA_NORTE_CAMPO")]
        public Int32 COORDENADA_NORTE_CAMPO { get; set; }
        [Description("OBSERVACION")]
        public String OBSERVACION { get; set; }
        [Description("RegEstado")]
        public Int32 RegEstado { get; set; }
        [Description("COD_UCUENTA")]
        public String COD_UCUENTA { get; set; }

        public Ent_INFORME_VERTICE_VERIFICADO()
        {
            NUM_POA = -1;
            COORDENADA_ESTE = -1;
            COORDENADA_ESTE_CAMPO = -1;
            COORDENADA_NORTE = -1;
            COORDENADA_NORTE_CAMPO = -1;
            RegEstado = -1;
        }
    }

    //Clases para el formulario de Conservación y Ecoturismo
    public class Ent_INFORME_VERTICE
    {
        public Int32 COD_SECUENCIAL { get; set; }
        public string VERTICE { get; set; }
        public string VERTICE_CAMPO { get; set; }
        public string ZONA { get; set; }
        public string ZONA_CAMPO { get; set; }
        public Int32 COORDENADA_ESTE { get; set; }
        public Int32 COORDENADA_ESTE_CAMPO { get; set; }
        public Int32 COORDENADA_NORTE { get; set; }
        public Int32 COORDENADA_NORTE_CAMPO { get; set; }
        public Int32 RegEstado { get; set; }
        public Int32 NUM_POA { get; set; }

        public Ent_INFORME_VERTICE()
        {
            COD_SECUENCIAL = -1; COORDENADA_ESTE = -1; COORDENADA_ESTE_CAMPO = -1;
            COORDENADA_NORTE = -1; COORDENADA_NORTE_CAMPO = -1; RegEstado = -1;
            NUM_POA = -1;
        }
    }
    public class Ent_INFORME_PROGRAMA
    {
        public Int32 COD_PROGRAMA { get; set; }
        public bool ESTADO_PROGRAMA { get; set; }
        public string TIPO_PROGRAMA { get; set; }
        public string OBSERVACION { get; set; }
        public string TIPO { get; set; }
        public string FRECUENCIA { get; set; }
        public string DESCRIPCION { get; set; }
        public Int32 RegEstado { get; set; }

        public Ent_INFORME_PROGRAMA()
        {
            COD_PROGRAMA = -1; RegEstado = -1;
        }
    }
    public class Ent_INFORME_REGFLORA
    {
        public Int32 COD_SECUENCIAL { get; set; }
        public string COD_ESPECIES { get; set; }
        public string ESPECIES { get; set; }
        public decimal DAP { get; set; }
        public decimal ALTURA_TOTAL { get; set; }
        public Int32 COORDENADA_NORTE { get; set; }
        public Int32 COORDENADA_ESTE { get; set; }
        public string ESTADO_ESPECIE { get; set; }
        public string OBSERVACION { get; set; }
        public string DESC_TIPO_REGISTRO { get; set; }
        public Int32 RegEstado { get; set; }
        public string ZONA { get; set; }

        public Ent_INFORME_REGFLORA()
        {
            COD_SECUENCIAL = -1; DAP = -1; ALTURA_TOTAL = -1;
            COORDENADA_ESTE = -1; COORDENADA_NORTE = -1; RegEstado = 1;
        }
    }
    public class Ent_INFORME_REGPAISAJE
    {
        public Int32 COD_SECUENCIAL { get; set; }
        public string TIPO { get; set; }
        public string ESTADO_PAISAJE { get; set; }
        public string NUM_VISITANTE { get; set; }
        public Int32 COORDENADA_NORTE { get; set; }
        public Int32 COORDENADA_ESTE { get; set; }
        public string OBSERVACION { get; set; }
        public Int32 RegEstado { get; set; }
        public string ZONA { get; set; }

        public Ent_INFORME_REGPAISAJE()
        {
            COD_SECUENCIAL = -1; COORDENADA_ESTE = -1; COORDENADA_NORTE = -1; RegEstado = -1;
        }
    }

    //Clases para el formulario de Tara
    public class Ent_INFORME_TCONCEPTO
    {
        public int COD_TCONCEPTO { get; set; }
        public string DESCRIPCION { get; set; }
        public bool ESTADO_MPLANTACION { get; set; }
        public string OBSERVACION { get; set; }
        public string TIPO { get; set; }
        public int RegEstado { get; set; }

        public Ent_INFORME_TCONCEPTO()
        {
            COD_TCONCEPTO = -1;
            RegEstado = -1;
        }
    }
    public class Ent_INFORME_TCENSO
    {
        public int COD_SECUENCIAL { get; set; }
        public decimal PREDIO_AREA { get; set; }
        public string CODIGO_ARBOL { get; set; }
        public int VAINAS_COD_PRESENCIA { get; set; }
        public string DESCRIPCION { get; set; }
        public bool PRES_FLORES { get; set; }
        public string PRES_FLORES_TEXT { get; set; }
        public string PRES_PLAGA_ENFERMEDA { get; set; }
        public string PRES_PLANTA_PARASITARIA { get; set; }
        public int COORDENADA_ESTE { get; set; }
        public int COORDENADA_NORTE { get; set; }
        public decimal ALTURA_TOTAL { get; set; }
        public string OBSERVACION { get; set; }
        public string ZONA { get; set; }
        public int RegEstado { get; set; }

        public Ent_INFORME_TCENSO()
        {
            COD_SECUENCIAL = -1; PREDIO_AREA = -1; VAINAS_COD_PRESENCIA = -1; COORDENADA_ESTE = -1; COORDENADA_NORTE = -1;
            ALTURA_TOTAL = -1; RegEstado = -1;
        }
    }

    public class Ent_INFORME_OBLIGTITULAR
    {
        [Description("COD_INFORME")]
        public String COD_INFORME { get; set; }
        [Description("COD_OBLIGTITULAR")]
        public String COD_OBLIGTITULAR { get; set; }
        [Description("OBLIGTITULAR")]
        public String OBLIGTITULAR { get; set; }
        [Description("EVAL_OBLIGTITULAR")]
        public String EVAL_OBLIGTITULAR { get; set; }
        [Description("OBSERVACION")]
        public String OBSERVACION { get; set; }
        [Description("COD_UCUENTA")]
        public String COD_UCUENTA { get; set; }
        public string COD_GRUPO { get; set; }

        public Ent_INFORME_OBLIGTITULAR()
        {

        }
    }

    public class Ent_MANDATOS
    {
        [Description("COD_INFORME")]
        public String COD_INFORME { get; set; }
        [Description("COD_SECUENCIAL")]
        public Int32 COD_SECUENCIAL { get; set; }       
        [Description("MANDATO")]
        public String MANDATO { get; set; }
        [Description("PLAZO_IMPL_DIA")]
        public Int32 PLAZO_IMPL_DIA { get; set; }
        [Description("PLAZO_POST_DIA")]
        public Int32 PLAZO_POST_DIA { get; set; }
        [Description("PLAZO_INF_DIA")]
        public Int32 PLAZO_INF_DIA { get; set; }
        [Description("COD_UCUENTA")]
        public String COD_UCUENTA { get; set; }
        [Description("RegEstado")]
        public Int32 RegEstado { get; set; }

        public Ent_MANDATOS()
        {
            COD_SECUENCIAL = -1;
            RegEstado = -1;
        }
    }

    public class Ent_INFORME_CONSULTA_LEGAL
    {
        public string COD_INFORME { get; set; }
        public string COD_RESODIREC { get; set; }
        public string COD_RESODIREC_INI_PAU { get; set; }
        public string NUM_INFORME { get; set; }
        public string DLINEA { get; set; }
        public string NUM_THABILITANTE { get; set; }
        public string TITULAR { get; set; }
        public int RegEstado { get; set; }
        public string COD_ILEGAL { get; set; }
        public string COD_INFORME_ALERTA { get; set; }
        public Int32 v_ROW_INDEX { get; set; }
        public List<Ent_INFORME_CONSULTA_LEGAL> listBusqueda { get; set; }
        public Ent_INFORME_CONSULTA_LEGAL()
        {
            RegEstado = -1;
            v_ROW_INDEX = -1;
        }
    }

    public class Ent_SBusqueda
    {
        public string Text { get; set; }
        public string Value { get; set; }
        //opcional
        public bool IsCheck { get; set; }
    }

    public class Ent_INFORME_CONSULTA
    {
        public string COD_INFORME { get; set; }
        public string NUM_INFORME { get; set; }
        public string DLINEA { get; set; }
        public string NUM_THABILITANTE { get; set; }
        public string TITULAR { get; set; }
        public int RegEstado { get; set; }
    }
    public class VW_REPORTE_INFORME_SUPERVISION
    {
        public List<VM_FControlCalidadSupervision_Det> listadoitems { get; set; }
        public List<VM_FControlCalidadSupervision_Det> listadoFechas { get; set; }
        public List<INFORME_CONTROL_CALIDAD> iNFORME_CONTROL_CALIDADs { get; set; }
        public List<INFORME_CONTROL_CALIDAD> respuestasLista { get; set; }
    }

    public class INFORME_CONTROL_CALIDAD
    {
        public Ent_INFORME Ent_Informe { get; set; }
        public VM_FControlCalidadSupervision vM_FControlCalidadSupervision { get; set; }
    }

    //Clases Reporte

    public class Ent_INFORME_ANALISIS
    {
        
        public string COD_ESPECIES { get; set; }
        public string NOMBRE_CIENTIFICO { get; set; } //Especie
        public int NUM_PIEZAS { get; set; } //N° de Arboles autorizados
        public decimal VOLUMEN_AUTORIZADO { get; set; } //volumen autorizado
        public decimal VOLUMEN { get; set; } //molumen movilizado campo
        public decimal PORC { get; set; } //total porcentaje movilizado
        public decimal SALDO { get; set; } //total saldo movilizado
        public int NUM_ARBOLES { get; set; }    //N° de Arboles movilizado campo    
        public decimal VOLUMEN_MOVILIZADO { get; set; } //total volumen movilizado
        public decimal DIFERENCIA { get; set; } //diferencia de volumen
        public string BEXTRACCION_FEMISION { get; set; }        

    }

    public class Ent_INFORME_CONSOLIDADO
    {
        public string COD_ESPECIES { get; set; }
        public string NOMBRE_CIENTIFICO { get; set; } //ESPECIES FORESTALES - NOMBRE CIENTIFICO
        public int NUM_PIEZAS { get; set; } //APROVECHABLES AUTORIZADOS - N° ÁRB.
        public decimal VOLUMEN_AUTORIZADO { get; set; } //APROVECHABLES AUTORIZADOS - VOL. (M3)
        public int NUM_ARBOLES { get; set; } //ÁRBOLES PROGRAMADOS A SUPERVISAR DEL PMF - APROVECHABLES - N° ÁRB
        public decimal VOLUMEN_CENSO { get; set; } //ÁRBOLES PROGRAMADOS A SUPERVISAR DEL PMF - APROVECHABLES - VOL. (M3)
        public int NUM_ARB_SEM { get; set; } //ÁRBOLES PROGRAMADOS A SUPERVISAR DEL PMF - SEMILLEROS - N° ÁRB.
        public int NUM_ARB_TOT { get; set; } //ÁRBOLES PROGRAMADOS A SUPERVISAR DEL PMF - TOTAL - N° ÁRB.
        public int NUM_ARB_AEP { get; set; } //ÁRBOLES SUPERVISADOS EN CAMPO - APROVECHABLES (A) - EN PIE (P) - N° ÁRB.
        public decimal VOLUMEN_AEP { get; set; }  //ÁRBOLES SUPERVISADOS EN CAMPO - APROVECHABLES (A) - EN PIE (P) - VOL. (M3)
        public int NUM_ARB_ATU { get; set; }  //ÁRBOLES SUPERVISADOS EN CAMPO - APROVECHABLES (A) - TUMBADO (T) - N° ÁRB.
        public decimal VOLUMEN_ATU { get; set; }  //ÁRBOLES SUPERVISADOS EN CAMPO - APROVECHABLES (A) - TUMBADO (T)- VOL. (M3)
        public int NUM_ARB_ATF { get; set; } //ÁRBOLES SUPERVISADOS EN CAMPO - APROVECHABLES (A) - TUMBADO (T) FUERA DE VIGENCIA - N° ÁRB.
        public decimal VOLUMEN_ATF { get; set; } //ÁRBOLES SUPERVISADOS EN CAMPO - APROVECHABLES (A) - TUMBADO (T) FUERA DE VIGENCIA - VOL. (M3)
        public int NUM_ARB_AMO { get; set; } //ÁRBOLES SUPERVISADOS EN CAMPO - APROVECHABLES (A) - MOVILIZADO (M) - N° ÁRB.
        public decimal VOLUMEN_AMO { get; set; } //ÁRBOLES SUPERVISADOS EN CAMPO - APROVECHABLES (A) - MOVILIZADO (M) - VOL. (M3)
        public int NUM_ARB_AMF { get; set; } //ÁRBOLES SUPERVISADOS EN CAMPO - APROVECHABLES (A) - MOVILIZADO (M) FUERA DE VIGENCIA - N° ÁRB.
        public decimal VOLUMEN_AMF { get; set; } //ÁRBOLES SUPERVISADOS EN CAMPO - APROVECHABLES (A) - MOVILIZADO (M) FUERA DE VIGENCIA - VOL. (M3)
        public int NUM_ARB_ACN { get; set; } //ÁRBOLES SUPERVISADOS EN CAMPO - APROVECHABLES (A) - CAIDO NATURAL (CN) - N° ÁRB.
        public decimal VOLUMEN_ACN { get; set; } //ÁRBOLES SUPERVISADOS EN CAMPO - APROVECHABLES (A) - CAIDO NATURAL (CN) - VOL. (M3)
        public int NUM_ARB_ANE { get; set; }   //ÁRBOLES SUPERVISADOS EN CAMPO - APROVECHABLES (A) - NO EXISTE - N° ÁRB.
        public int NUM_ARB_NEP { get; set; } //ÁRBOLES SUPERVISADOS EN CAMPO - ARBOLES NO APROVECHABLES - EN PIE (P) - N° ÁRB.
        public decimal VOLUMEN_NEP { get; set; } //ÁRBOLES SUPERVISADOS EN CAMPO - ARBOLES NO APROVECHABLES - EN PIE (P) - VOL. (M3)
        public int NUM_ARB_NTU { get; set; }  //ÁRBOLES SUPERVISADOS EN CAMPO - ARBOLES NO APROVECHABLES - TUMBADO (T) - N° ÁRB.
        public decimal VOLUMEN_NTU { get; set; }  //ÁRBOLES SUPERVISADOS EN CAMPO - ARBOLES NO APROVECHABLES - TUMBADO (T) - VOL. (M3)
        public int NUM_ARB_NMO { get; set; }
        public decimal VOLUMEN_NMO { get; set; }
        public int NUM_ARB_NCN { get; set; } //ÁRBOLES SUPERVISADOS EN CAMPO - ARBOLES NO APROVECHABLES - CAIDO NATURAL (CN) - N° ÁRB.
        public decimal VOLUMEN_NCN { get; set; }  //ÁRBOLES SUPERVISADOS EN CAMPO - ARBOLES NO APROVECHABLES - CAIDO NATURAL (CN) - VOL. (M3)
        public int NUM_ARB_SEP { get; set; }  //ÁRBOLES SUPERVISADOS EN CAMPO - SEMILLEROS (S) - EN PIE (P) - N° ÁRB.
        public int NUM_ARB_STU { get; set; }  //ÁRBOLES SUPERVISADOS EN CAMPO - SEMILLEROS (S) - TUMBADO (T) - N° ÁRB.
        public decimal VOLUMEN_STU { get; set; }  //ÁRBOLES SUPERVISADOS EN CAMPO - SEMILLEROS (S) - TUMBADO (T) - VOL. (M3)
        public int NUM_ARB_SMO { get; set; } //ÁRBOLES SUPERVISADOS EN CAMPO - SEMILLEROS (S) - MOVILIZADO (M) -  (M3)	N° ÁRB.
        public decimal VOLUMEN_SMO { get; set; } //ÁRBOLES SUPERVISADOS EN CAMPO - SEMILLEROS (S) - MOVILIZADO (M) - VOL. (M3)
        public int NUM_ARB_SCN { get; set; } //ÁRBOLES SUPERVISADOS EN CAMPO - SEMILLEROS (S)¿ - CAIDO NATURAL (CN) - N° ÁRB.
        public int NUM_ARB_SNE { get; set; }  //ÁRBOLES SUPERVISADOS EN CAMPO - SEMILLEROS (S)¿ -  NO EXISTE - N° ÁRB. 
        public int NUM_ARB_NEA { get; set; } //NO EVALUADOS - APROVECHABLES - N° ÁRB.
        public int NUM_ARB_NES { get; set; } // NO EVALUADOS - SEMILLEROS - N° ÁRB.
        public int TOTAL_SUP { get; set; } //TOTAL SUPERVISADO - N° ÁRB.

    }

    public class Ent_INFORME_MADERABLE_A
    {
        
        public string CODIGO { get; set; }//CODIGO - PMF
        public string CODIGO_CAMPO { get; set; } //CODIGO - SUP
        public string DESC_ESPECIES { get; set; } //ESPECIES FORESTALES - PMF - NOMBRE CIENTÍFICO / NOMBRE COMÚN
        public string DESC_ESPECIES_COMUN { get; set; }//ESPECIES FORESTALES - PMF - Nombre común
        public string DESC_ESPECIES_CAMPO { get; set; }//ESPECIES FORESTALES - SUP - NOMBRE CIENTÍFICO
        public string DESC_ESPECIES_COMUN_CAMPO { get; set; }//ESPECIES FORESTALES - SUP NOMBRE COMÚN
        public int COORDENADA_ESTE { get; set; } //COORDENADAS UTM PMF - ESTE
        public int COORDENADA_NORTE { get; set; } //COORDENADAS UTM PMF - NORTE 
        public int COORDENADA_ESTE_CAMPO { get; set; } //COORDENADAS UTM SUP - ESTE
        public int COORDENADA_NORTE_CAMPO { get; set; } //COORDENADAS UTM SUP - NORTE
        public decimal DAP { get; set; } //DIAMETRO(CM) - PMF
        public decimal DAP_CAMPO { get; set; } // DIAMETRO(CM) - SUP
        public decimal DAP_CAMPO1 { get; set; } //DIAMETRO(CM) - SUP (D1)
        public decimal DAP_CAMPO2 { get; set; }// DIAMETRO(CM) - SUP (D2)
        public string MMEDIR_DAP { get; set; } //METODOLOGIA - METODOLOGÍA PARA LA MEDICIÓN DEL DAP
        public decimal AC { get; set; } //AC - PMF
        public decimal AC_CAMPO { get; set; } //AC - SUP
        public string COINCIDE_ESPECIES { get; set; } //COINCIDENCIA - ESPECIE
        public decimal VOLUMEN { get; set; } //VOLUMEN - VOL PMF
        public decimal VOLUMEN_CAMPO { get; set; } //VOLUMEN - VOL SUP
        public string COINCIDE_CODIGO { get; set; } //COINCIDENCIA - CÓDIGO
        public decimal DAP_RP { get; set; } //RANGO PERMISIBLE - DAP
        public decimal AC_RP { get; set; } //RANGO PERMISIBLE -  AC
        public decimal COO_RP { get; set; } //RANGO PERMISIBLE - UTM
        public string DESC_EESTADO_CAMPO { get; set; } //ESTADO - SUP
        public string DESC_ECONDICION_CAMPO { get; set; } // CONDICIÓN - SUP
    }

}
