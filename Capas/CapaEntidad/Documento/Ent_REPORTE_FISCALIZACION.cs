using System;
using System.Collections.Generic;
using System.ComponentModel;


namespace CapaEntidad.DOC
{
    public class Ent_REPORTE_FISCALIZACION
    {
        [Description("ESTADO_PAU")]
        public String ESTADO_PAU { get; set; }
        [Description("FECHA_PROVEIDO")]
        public String FECHA_PROVEIDO { get; set; }
        [Description("FIC_SIADO")]
        public String FIC_SIADO { get; set; }
        [Description("CODIGO")]
        public String CODIGO { get; set; }
        [Description("DESCRIPCION")]
        public String DESCRIPCION { get; set; }
        [Description("APELLIDOS_NOMBRES")]
        public String APELLIDOS_NOMBRES { get; set; }
        [Description("RESOLUCION INICIO PAU")]
        public String INICIO_PAU { get; set; }
        [Description("INICIO PAU")]
        public Int32 INI_PAU { get; set; }
        [Description("TERMINO PAU")]
        public Int32 TERMINO_PAU { get; set; }
        [Description("SANCIONADO_PAU")]
        public Int32 SANCIONADO_PAU { get; set; }
        //[Description("SANCIONADO_RD")]
        //public Int32 SANCIONADO_RD { get; set; }
        [Description("MED_CORREC_PAU")]
        public Int32 MED_CORREC_PAU { get; set; }
        //[Description("MED_CORREC_RD")]
        //public Int32 MED_CORREC_RD { get; set; }
        [Description("AMONEST_PAU")]
        public Int32 AMONEST_PAU { get; set; }
        //[Description("AMONEST_RD")]
        //public Int32 AMONEST_RD { get; set; }
        [Description("CADUCADO_PAU")]
        public Int32 CADUCADO_PAU { get; set; }
        //[Description("CADUCADO_RD")]
        //public Int32 CADUCADO_RD { get; set; }
        [Description("CADUCADO_PAU_TH")]
        public Int32 CADUCADO_PAU_TH { get; set; }
        [Description("CADUCADO_PAU_TH_PRV")]
        public Int32 CADUCADO_PAU_TH_PRV { get; set; }
        [Description("SUPER_TERMINADO_PAU")]
        public Int32 SUPER_TERMINADO_PAU { get; set; }
        [Description("ARCHIVO_PRELIMINAR")]
        public Int32 ARCHIVO_PRELIMINAR { get; set; }
        [Description("ARCHIVO_PRELIMINAR_SIN")]
        public Int32 ARCHIVO_PRELIMINAR_SIN { get; set; }
        [Description("ARCHIVO_PAU")]
        public Int32 ARCHIVO_PAU { get; set; }
        //[Description("ARCHIVO_RD")]
        //public Int32 ARCHIVO_RD { get; set; }



        [Description("MEDCAU_PAU")]
        public Int32 MEDCAU_PAU { get; set; }
        [Description("MEDPRECAU_PAU")]
        public Int32 MEDPRECAU_PAU { get; set; }
        //[Description("SUPER_CASOS_INEX")]
        //public Int32 SUPER_CASOS_INEX { get; set; }
        //[Description("SUPER_ARBOLES_INEX")]
        //public Int32 SUPER_ARBOLES_INEX { get; set; }
        //[Description("VOL_INI_i_PAU")]
        //public Decimal VOL_INI_i_PAU { get; set; }
        //[Description("VOL_INI_w_PAU")]
        //public Decimal VOL_INI_w_PAU { get; set; }
        //[Description("VOL_TER_i_PAU")]
        //public Decimal VOL_TER_i_PAU { get; set; }
        //[Description("VOL_TER_w_PAU")]
        //public Decimal VOL_TER_w_PAU { get; set; }
        //[Description("UIT_TER_PAU")]
        //public Decimal UIT_TER_PAU { get; set; }

        [Description("CASOS_SOLO_i_TER_PAU")]
        public Int32 CASOS_SOLO_i_TER_PAU { get; set; }
        [Description("CASOS_SOLO_w_TER_PAU")]
        public Int32 CASOS_SOLO_w_TER_PAU { get; set; }
        [Description("CASOS_SOLO_i_w_TER_PAU")]
        public Int32 CASOS_SOLO_i_w_TER_PAU { get; set; }
        //[Description("CASOS_i_w_TER_PAU")]
        //public Int32 CASOS_i_w_TER_PAU { get; set; }

        [Description("CASOS")]
        public Int32 CASOS { get; set; }
        [Description("AVANCE_CASOS")]
        public Decimal AVANCE_CASOS { get; set; }

        [Description("RECURSOS DE RECONSIDERACION")]
        public Int32 RECONSIDERACION { get; set; }
        [Description("RECTIFICACION")]
        public Int32 RECTIFICACION { get; set; }
        [Description("MED_CAU")]
        public Int32 MED_CAU { get; set; }
        [Description("AVANCE")]
        public Decimal AVANCE { get; set; }
        [Description("AVANCE1")]
        public Decimal AVANCE1 { get; set; }
        [Description("SUPERVISIONES")]
        public Int32 SUPERVISIONES { get; set; }
        [Description("OTROS")]
        public Int32 OTROS { get; set; }
        [Description("FECHA_EMISION")]
        public String FECHA_EMISION { get; set; }
        [Description("MODALIDAD")]
        public String MODALIDAD { get; set; }
        [Description("REGION")]
        public String REGION { get; set; }
        [Description("ANIO")]
        public String ANIO { get; set; }
        [Description("TOTAL")]
        public Int32 TOTAL { get; set; }
        [Description("ITEM")]
        public Int32 ITEM { get; set; }
        [Description("FECHA_CREACION")]
        public String FECHA_CREACION { get; set; }
        
        [Description("N_DOC")]
        public String N_DOC { get; set; }
        [Description("DESTINATARIO")]
        public String DESTINATARIO { get; set; }
        
        [Description("FECHA_ADMINISTRADO")]
        public String FECHA_ADMINISTRADO { get; set; }
        [Description("FECHA_PRIMERA_VISITA")]
        public String FECHA_PRIMERA_VISITA { get; set; }
        [Description("FECHA_SEGUNDA_VISITA")]
        public String FECHA_SEGUNDA_VISITA { get; set; }
        [Description("PERSONA_NOT")]
        public String PERSONA_NOT { get; set; }
        [Description("VINCULO")]
        public String VINCULO { get; set; }
        [Description("DIRECCION_NOT")]
        public String DIRECCION_NOT { get; set; }
        [Description("VARIACION_DOMICILIO")]
        public String VARIACION_DOMICILIO { get; set; }
        [Description("OD_RESPONSABLE")]
        public String OD_RESPONSABLE { get; set; }
        [Description("ESTADO")]
        public String ESTADO { get; set; }
        [Description("OBSERVACIONES")]
        public String OBSERVACIONES { get; set; }
        
        [Description("TOTAL_PRIMERO")]
        public Int32 TOTAL_PRIMERO { get; set; }
        [Description("FUNDADA")]
        public Int16 FUNDADA { get; set; }
        [Description("TOTAL_SEGUNDO")]
        public Int32 TOTAL_SEGUNDO { get; set; }
        [Description("IL_EVA_INF_SUP")]
        public Int32 IL_EVA_INF_SUP { get; set; }
        [Description("IL_ETAPA_INSTRU")]
        public Int32 IL_ETAPA_INSTRU { get; set; }
        [Description("IL_CONFORMIDAD")]
        public Int32 IL_CONFORMIDAD { get; set; }
        [Description("IL_EVA_REC_RECONS")]
        public Int32 IL_EVA_REC_RECONS { get; set; }
        [Description("IL_OTROS")]
        public Int32 IL_OTROS { get; set; }
        [Description("IL_FINAL")]
        public Int32 IL_FINAL { get; set; }
        //Regiones

        [Description("UCAYALI")]
        public Int32 UCAYALI { get; set; }
        [Description("MADRE DE DIOS")]
        public Int32 MADREDEDIOS { get; set; }
        [Description("SAN MARTIN")]
        public Int32 SANMARTIN { get; set; }
        [Description("LORETO")]
        public Int32 LORETO { get; set; }
        [Description("LAMBAYEQUE")]
        public Int32 LAMBAYEQUE { get; set; }
        [Description("AMAZONAS")]
        public Int32 AMAZONAS { get; set; }
        [Description("HUANUCO")]
        public Int32 HUANUCO { get; set; }
        [Description("PASCO")]
        public Int32 PASCO { get; set; }
        [Description("JUNIN")]
        public Int32 JUNIN { get; set; }

        // VARIABLES EVALUACION

        [Description("DOSMILNUEVE")]
        public Double DOSMILNUEVE { get; set; }
        [Description("DOSMILDIEZ")]
        public Double DOSMILDIEZ { get; set; }
        [Description("DOSMILONCE")]
        public Double DOSMILONCE { get; set; }
        [Description("DOSMILDOCE")]
        public Double DOSMILDOCE { get; set; }
        [Description("DOSMILTRECE")]
        public Double DOSMILTRECE { get; set; }
        [Description("DOSMILCATORCE")]
        public Double DOSMILCATORCE { get; set; }
        [Description("ENERO")]
        public Double ENERO { get; set; }
        [Description("FEBRERO")]
        public Double FEBRERO { get; set; }
        [Description("MARZO")]
        public Double MARZO { get; set; }
        [Description("ABRIL")]
        public Double ABRIL { get; set; }
        [Description("MAYO")]
        public Double MAYO { get; set; }
        [Description("JUNIO")]
        public Double JUNIO { get; set; }
        [Description("JULIO")]
        public Double JULIO { get; set; }
        [Description("AGOSTO")]
        public Double AGOSTO { get; set; }
        [Description("SETIEMBRE")]
        public Double SETIEMBRE { get; set; }
        [Description("OCTUBRE")]
        public Double OCTUBRE { get; set; }
        [Description("NOVIEMBRE")]
        public Double NOVIEMBRE { get; set; }
        [Description("DICIEMBRE")]
        public Double DICIEMBRE { get; set; }

        //MODALIDADES DE APROVECHAMIENTO

        [Description("CANT_CMADE")]
        public Decimal CANT_CMADE { get; set; }
        [Description("CANT_NM")]
        public Decimal CANT_NM { get; set; }
        [Description("CANT_FYR")]
        public Decimal CANT_FYR { get; set; }
        [Description("CANT_ECO")]
        public Decimal CANT_ECO { get; set; }
        [Description("CANT_CONS")]
        public Decimal CANT_CONS { get; set; }
        //[Description("Fauna_Silvestre")]
        //public Int32 Fauna_Silvestre { get; set; }
        [Description("CANT_PFAUNA")]
        public Decimal CANT_PFAUNA { get; set; }
        [Description("CANT_CFAUNA")]
        public Decimal CANT_CFAUNA { get; set; }
        [Description("CANT_TARA")]
        public Decimal CANT_TARA { get; set; }
        [Description("CANT_BS")]
        public Decimal CANT_BS { get; set; }
        [Description("CANT_BL")]
        public Decimal CANT_BL { get; set; }
        [Description("CANT_PP")]
        public Decimal CANT_PP { get; set; }
        [Description("CANT_CCCC_CCNN")]
        public Decimal CANT_CCCC_CCNN { get; set; }
        [Description("CANT_PNM")]
        public Decimal CANT_PNM { get; set; }

        //PROPIEDADES DE MENU
        [Description("MENU")]
        public String MENU { get; set; }
        [Description("CATEGORIA")]
        public Int32 CATEGORIA { get; set; }

        //Opciones de Busqueda
        [Description("BusDireccion")]
        public String BusDireccion { get; set; }
        [Description("BusDireccion2")]
        public String BusDireccion2 { get; set; }
        [Description("BusModalidad")]
        public String BusModalidad { get; set; }
        [Description("BusCriterio")]
        public String BusCriterio { get; set; }
        [Description("BusRegion")]
        public String BusRegion { get; set; }
        [Description("BusAnio")]
        public String BusAnio { get; set; }
        [Description("BusFechaFin")]
        public String BusFechaFin { get; set; }
        [Description("BusInciso")]
        public String BusInciso { get; set; }
        [Description("BusMeses")]
        public String BusMeses { get; set; }

        //Reporte Estado_Informe
        [Description("JUDICIALIZADO")]
        public String JUDICIALIZADO { get; set; }
        [Description("INFORME SUPERVISION")]
        public string INFORME_SUPERVISION { get; set; }
        [Description("TITULAR")]
        public string TITULAR { get; set; }
        [Description("INFORME LEGAL DE EVALUACIÓN INF. SUPERVISIÓN")]
        public string INFOR_LEGAL_EVALUCION_IS { get; set; }
        [Description("DETERMINACIÓN INF. LEGAL")]
        public string DETERMINACION_IL { get; set; }
        [Description("RD INICIO PAU")]
        public string RD_INICIO { get; set; }
        [Description("RD AMPLIACIÓN PAU")]
        public string RD_AMPLIACION { get; set; }
        [Description("FECHA DE NOTIFICACIÓN DE LA RD INICIO")]
        public string EXPED_ADMN { get; set; }
        [Description("FECHA DE PRESENTACIÓN DESCARGO")]
        public string FEC_NOTIF_RD_INICIO { get; set; }
        [Description("FEC_DESCARGO")]
        public string FEC_DESCARGO { get; set; }
        [Description("INFORME TÉCNICO")]
        public string INFORME_TECNICO { get; set; }
        [Description("INFORME LEGAL DE TÉRMINO DE PAU")]
        public string ILEGAL_TERMINO { get; set; }
        [Description("INFORME LEGAL DETERMINACION DE MULTA")]
        public string ILEGAL_DETER { get; set; }
        [Description("RD TERMINO")]
        public string RD_TERMINO { get; set; }
        [Description("DETERMINACIÓN RD FINAL")]
        public string RD_TERMINO_DETER { get; set; }
        [Description("FECHA DE NOTIFICACIÓN")]
        public string FEC_NOTIF_RD_TERMINO { get; set; }
        [Description("FECHA DE PRESENTACIÓN RECURSO DE RECONSIDERACIÓN")]
        public string FEC_RECONSIRECACION { get; set; }
        [Description("FECHA PRESENTACIÓN RECURSO APELACIÓN")]
        public string FEC_APELACION { get; set; }
        [Description("INFORME LEGAL EV. RECURSO RECONSIDERACIÓN")]
        public string ILEGAL_RECONSIDERA { get; set; }
        [Description("RD RECURSO RECONSIDERACIÓN")]
        public string RD_RECONSIDERA { get; set; }

        //Reporte Informe Detalle
        [Description("Numero de informe del reporte")]
        public string Numero_Inform { get; set; }
        [Description("COD_PROFESIONAL")]
        public string COD_PROFESIONAL { get; set; }

        [Description("Tipo de Informe")]
        public string Tipo_Informe { get; set; }
        [Description("Recomendaciones")]
        public string Recomendaciones { get; set; }

        //REPORTE RESOLUCION DIRECTORAL ELABORADO
        //  [Description("Titulo Habilitante")]
        //    public string TITULO_HABILITANTE { get; set; }
        [Description("tipo RD")]
        public string TIPO_RD { get; set; }
        [Description("numero RD")]
        public string NUMERO_RD { get; set; }
        [Description("Person notificada")]
        public string PERSONA_NOTIFICADA { get; set; }
        [Description("NOTIFICACION_OCI")]
        public string NOTIFICACION_OCI { get; set; }
        [Description("numero de informe de supervision")]
        public string NUMERO_INFORME_SUPERV { get; set; }
        [Description("numero de expediente")]
        public string NUMERO_EXPEDIENTE { get; set; }
        [Description("fecha de notificacion")]
        public string FECHA_NOTIFICACION { get; set; }

        /// <summary>
        /// para los usuarios 
        /// </summary>
        [Description("COD_UCUENTA")]
        public String COD_UCUENTA { get; set; }

        [Description("COD_UGRUPO")]
        public String COD_UGRUPO { get; set; }

        [Description("N_DOCUMENTO")]
        public String N_DOCUMENTO { get; set; }

        //reporte relacion de documentos presentados por el thabilitante
        [Description("BusLinea")]
        public String BusLinea { get; set; }

        [Description("BusOD")]
        public String BusOD { get; set; }

        [Description("TH_NUMERO")]
        public String TH_NUMERO { get; set; }

        [Description("TIPO_DOCUMENTO")]
        public String TIPO_DOCUMENTO { get; set; }

        [Description("OD")]
        public String OD { get; set; }

        [Description("FECHA_PRESENTACION")]
        public Object FECHA_PRESENTACION { get; set; }

        [Description("DIRECCION")]
        public String DIRECCION { get; set; }

        [Description("COD_TITULAR")]
        public String COD_TITULAR { get; set; }

        [Description("NUMERO_INFTIT")]
        public String NUMERO_INFTIT { get; set; }

        [Description("INFORME")]
        public String INFORME { get; set; }
        [Description("ILEGAL")]
        public String ILEGAL { get; set; }



        [Description("Frecuencia")]
        public Int32 Frecuencia { get; set; }
        [Description("Porcentaje")]
        public double Porcentaje { get; set; }
        [Description("Ariticulo")]
        public string Ariticulo { get; set; }
        [Description("Inciso")]
        public string Inciso { get; set; }

        //Literales

        //ART 18
        //////[Description("ART18a")]
        //////public Int32 ART18a { get; set; }
        //////[Description("ART18b")]
        //////public Int32 ART18b { get; set; }
        //////[Description("ART18c")]
        //////public Int32 ART18c { get; set; }
        //////[Description("ART18d")]
        //////public Int32 ART18d { get; set; }
        //////[Description("ART18e")]
        //////public Int32 ART18e { get; set; }

        //ART 295
        //////[Description("ART295a")]
        //////public Int32 ART295a { get; set; }
        //////[Description("ART295b")]
        //////public Int32 ART295b { get; set; }
        //////[Description("ART295c")]
        //////public Int32 ART295c { get; set; }

        //ART 363
        //////[Description("ART363e")]
        //////public Int32 ART363e { get; set; }
        //////[Description("ART363f")]
        //////public Int32 ART363f { get; set; }
        //////[Description("ART363i")]
        //////public Int32 ART363i { get; set; }
        //////[Description("ART363k")]
        //////public Int32 ART363k { get; set; }
        //////[Description("ART363l")]
        //////public Int32 ART363l { get; set; }
        //////[Description("ART363m")]
        //////public Int32 ART363m { get; set; }
        //////[Description("ART363n")]
        //////public Int32 ART363n { get; set; }
        //////[Description("ART363r")]
        //////public Int32 ART363r { get; set; }
        //////[Description("ART363t")]
        //////public Int32 ART363t { get; set; }
        //////[Description("ART363u")]
        //////public Int32 ART363u { get; set; }
        //////[Description("ART363V1")]
        //////public Int32 ART363V1 { get; set; }
        //////[Description("ART363w")]
        //////public Int32 ART363w { get; set; }

        //ART 364
        //////[Description("ART364f")]
        //////public Int32 ART364f { get; set; }
        //////[Description("ART364g")]
        //////public Int32 ART364g { get; set; }
        //////[Description("ART364h")]
        //////public Int32 ART364h { get; set; }
        //////[Description("ART364l")]
        //////public Int32 ART364l { get; set; }
        //////[Description("ART364o")]
        //////public Int32 ART364o { get; set; }
        //////[Description("ART364q")]
        //////public Int32 ART364q { get; set; }
        //////[Description("ART364s")]
        //////public Int32 ART364s { get; set; }
        //////[Description("ART364t")]
        //////public Int32 ART364t { get; set; }

        //AR T91
        //////[Description("ART91Aa")]
        //////public Int32 ART91Aa { get; set; }
        //////[Description("ART91Ab")]
        //////public Int32 ART91Ab { get; set; }
        //////[Description("ART91Ad")]
        //////public Int32 ART91Ad { get; set; }
        //////[Description("ART91Ae")]
        //////public Int32 ART91Ae { get; set; }
        //////[Description("ART91Af")]
        //////public Int32 ART91Af { get; set; }
        //////[Description("ART91Ag")]
        //////public Int32 ART91Ag { get; set; }
        //////[Description("ART91Ah")]
        //////public Int32 ART91Ah { get; set; }

        //
        [Category("LIST"), Description("ListarInfraccionesGeneral")]
        public List<Ent_REPORTE_FISCALIZACION> ListarInfraccionesGeneral { get; set; }
        [Category("LIST"), Description("ListLiterales")]
        public List<Ent_REPORTE_FISCALIZACION> ListLiterales { get; set; }
        [Category("LIST"), Description("ListarArticulo")]
        public List<Ent_REPORTE_FISCALIZACION> ListarArticulo { get; set; }
        [Category("LIST"), Description("ListarArticuloInciso")]
        public List<Ent_REPORTE_FISCALIZACION> ListarArticuloInciso { get; set; }

        //Reporte Estado_Informe

        //Caducidad
        [Description("DEPARTAMENTO")]
        public String DEPARTAMENTO { get; set; }
        [Description("ZAFRA_PCA")]
        public String ZAFRA_PCA { get; set; }
        [Description("CANTIDAD")]
        public Int32 CANTIDAD { get; set; }
        [Description("AREA_OTORGADA")]
        public Decimal AREA_OTORGADA { get; set; }

        [Category("LIST"), Description("ListGeneral")]
        public List<Ent_REPORTE_FISCALIZACION> ListGeneral { get; set; }
        [Category("LIST"), Description("ListDetalle")]
        public List<Ent_REPORTE_FISCALIZACION> ListDetalle { get; set; }
        [Category("LIST"), Description("ListDepartamento")]
        public List<Ent_REPORTE_FISCALIZACION> ListDepartamento { get; set; }
        [Category("LIST"), Description("ListZafra")]
        public List<Ent_REPORTE_FISCALIZACION> ListZafra { get; set; }

        //Nuevos cambios: 07/08/2017
        [Description("TIPO_REPORTE")]
        public string TIPO_REPORTE { get; set; }
        [Description("TITULAR_SANCIONADO")]
        public string TITULAR_SANCIONADO { get; set; }
        [Description("RDCADUCA")]
        public string RDCADUCA { get; set; }
        [Description("RDCADUCA_PUBLICAR")]
        public string RDCADUCA_PUBLICAR { get; set; }
        [Description("RDRECONSIDERA")]
        public string RDRECONSIDERA { get; set; }
        [Description("RDRECONSIDERA_PUBLICAR")]
        public string RDRECONSIDERA_PUBLICAR { get; set; }
        [Description("RTFFS")]
        public string RTFFS { get; set; }
        [Description("RTFFS_PUBLICAR")]
        public string RTFFS_PUBLICAR { get; set; }
        [Description("REC_APELACION")]
        public string REC_APELACION { get; set; }
        [Description("PROVEIDO")]
        public string PROVEIDO { get; set; }
        [Description("PROVEIDO_FECHA")]
        public string PROVEIDO_FECHA { get; set; }
        [Description("CADUCADOS")]
        public Int32 CADUCADOS { get; set; }

        [Description("RDMEDIDAS")]
        public string RDMEDIDAS { get; set; }
        [Description("RDMEDIDAS_PUBLICAR")]
        public string RDMEDIDAS_PUBLICAR { get; set; }
        [Description("CADUCIDAD")]
        public string CADUCIDAD { get; set; }

        //Caducidad


        //Archivo       
        [Description("EVIDENCIA_IRREGULARIDAD")]
        public Int32 EVIDENCIA_IRREGULARIDAD { get; set; }
        [Description("SIN_INDICIOS_INFRACCION")]
        public Int32 SIN_INDICIOS_INFRACCION { get; set; }
        [Description("DEFICIENCIA_NOTIF")]
        public Int32 DEFICIENCIA_NOTIF { get; set; }
        [Description("DEFICIENCIA_TECNICA")]
        public Int32 DEFICIENCIA_TECNICA { get; set; }
        [Category("LIST"), Description("ListarDetalle")]
        public List<Ent_REPORTE_FISCALIZACION> ListarDetalle { get; set; }
        //Archivo


        //Expedientes Evaluados

        [Description("SUPERVISION")]
        public Int32 SUPERVISION { get; set; }
        [Description("EXPEDIENTE")]
        public Int32 EXPEDIENTE { get; set; }
        [Description("EMITIRLEGAL")]
        public Int32 EMITIRLEGAL { get; set; }
        [Description("EMITIRIMPOSICION")]
        public Int32 EMITIRIMPOSICION { get; set; }
        [Description("PAU_CONCLUIDOS")]
        public Int32 PAU_CONCLUIDOS { get; set; }
        [Category("LIST"), Description("ListExpedientesEvaluados")]
        public List<Ent_REPORTE_FISCALIZACION> ListExpedientesEvaluados { get; set; }
        [Category("LIST"), Description("ListExpedientesEvaluadosHistorial")]
        public List<Ent_REPORTE_FISCALIZACION> ListExpedientesEvaluadosHistorial { get; set; }
        [Category("LIST"), Description("ListExpedientesEvaluadosAñoActual")]
        public List<Ent_REPORTE_FISCALIZACION> ListExpedientesEvaluadosAñoActual { get; set; }
        //Expedientes Evaluados

        //PAU Concluidos
        //[Category("LIST"), Description("ListPAUinfSupervision")]
        //public List<Ent_REPORTE_FISCALIZACION> ListPAUinfSupervision { get; set; }
        //[Category("LIST"), Description("ListPAUinfSuspeCancel")]
        //public List<Ent_REPORTE_FISCALIZACION> ListPAUinfSuspeCancel { get; set; }
        //[Category("LIST"), Description("ListPAUinfTecnico")]
        //public List<Ent_REPORTE_FISCALIZACION> ListPAUinfTecnico { get; set; }
        //[Category("LIST"), Description("ListPAUinfAutForestal")]
        //public List<Ent_REPORTE_FISCALIZACION> ListPAUinfAutForestal { get; set; }
        //[Category("LIST"), Description("ListPAU20052008")]
        //public List<Ent_REPORTE_FISCALIZACION> ListPAU20052008 { get; set; }
        //Manejo de Listas

        [Category("LIST"), Description("ListTiempoModalidad")]
        public List<Ent_REPORTE_FISCALIZACION> ListTiempoModalidad { get; set; }
        [Category("LIST"), Description("ListISupervision_General")]
        public List<Ent_REPORTE_FISCALIZACION> ListISupervision_General { get; set; }
        [Category("LIST"), Description("ListISupervision_Modalidades")]
        public List<Ent_REPORTE_FISCALIZACION> ListISupervision_Modalidades { get; set; }
        [Category("LIST"), Description("ListRegiones")]
        public List<Ent_REPORTE_FISCALIZACION> ListRegiones { get; set; }
        [Category("LIST"), Description("ListArticulo")]
        public List<Ent_REPORTE_FISCALIZACION> ListISupervision_Articulo { get; set; }

        [Description("BusValor")]
        public String BusValor { get; set; }
        //Resoluciones Emitidas

        [Description("PROMEDIO")]
        public Int32 PROMEDIO { get; set; }

        //Resoluciones Emitidas

        //PAU vs Descargos

        [Description("COD_INFTIT")]
        public string COD_INFTIT { get; set; }
        [Description("COD_ITIPO")]
        public string COD_ITIPO { get; set; }
        [Description("THABILITANTE")]
        public string THABILITANTE { get; set; }
        [Description("DESCARGO")]
        public Int32 DESCARGO { get; set; }
        [Description("RDINICIO")]
        public string RDINICIO { get; set; }
        [Description("FECHA")]
        public string FECHA { get; set; }
        [Description("LUGAR")]
        public string LUGAR { get; set; }

        [Description("COD_FCTIPO")]
        public string COD_FCTIPO { get; set; }
        [Description("PARAMETRO")]
        public string PARAMETRO { get; set; }

        [Description("TITULO")]
        public string TITULO { get; set; }
        [Description("MES")]
        public string MES { get; set; }
        [Description("OBSERV_INEX")]
        public string OBSERV_INEX { get; set; }
        [Description("DIAS_TRANSC")]
        public Int32 DIAS_TRANSC { get; set; }
        [Description("FUNCIONARIO_CARGO")]
        public string FUNCIONARIO_CARGO { get; set; }
        [Description("FECHA_DERV")]
        public string FECHA_DERV { get; set; }
        [Description("PORC_INEX")]
        public string PORC_INEX { get; set; }
        [Description("TOTAL_INJUS")]
        public string TOTAL_INJUS { get; set; }

        //Notificaciones segun resoluciones
        [Description("INFORMACION_FALSA_INEX")]
        public string INFORMACION_FALSA_INEX { get; set; }
        [Description("INFORMACION_FALSA_DIF")]
        public string INFORMACION_FALSA_DIF { get; set; }
        [Description("INFORMACION_FALSA_DAS")]
        public string INFORMACION_FALSA_DAS { get; set; }
        [Description("INFORMACION_FALSA_T")]
        public string INFORMACION_FALSA_T { get; set; }
        [Description("DESCRIPCION_INFORMACION_FALSA")]
        public string DESCRIPCION_INFORMACION_FALSA { get; set; }
        [Description("ATFFS")]
        public string ATFFS { get; set; }
        [Description("DETALLE_ATFFS")]
        public string DETALLE_ATFFS { get; set; }
        [Description("OCI")]
        public string OCI { get; set; }
        [Description("DETALLE_OCI")]
        public string DETALLE_OCI { get; set; }
        [Description("DGFFS")]
        public string DGFFS { get; set; }
        [Description("DETALLE_DGFFS")]
        public string DETALLE_DGFFS { get; set; }
        [Description("PROGRAMA_REGIONAL")]
        public string PROGRAMA_REGIONAL { get; set; }
        [Description("DETALLE_PROREG")]
        public string DETALLE_PROREG { get; set; }
        [Description("MINISTERIO_PUBLICO")]
        public string MINISTERIO_PUBLICO { get; set; }
        [Description("DETALLE_MINPUB")]
        public string DETALLE_MINPUB { get; set; }
        [Description("COLEGIO_INGENIEROS")]
        public string COLEGIO_INGENIEROS { get; set; }
        [Description("DETALLE_COLING")]
        public string DETALLE_COLING { get; set; }
        [Description("OEFA")]
        public string OEFA { get; set; }
        [Description("DETALLE_OEFA")]
        public string DETALLE_OEFA { get; set; }
        [Description("SUNAT")]
        public string SUNAT { get; set; }
        [Description("DETALLE_SUNAT")]
        public string DETALLE_SUNAT { get; set; }
        [Description("SERFOR")]
        public string SERFOR { get; set; }
        [Description("DETALLE_SERFOR")]
        public string DETALLE_SERFOR { get; set; }
        [Description("NOTROS")]
        public string NOTROS { get; set; }
        [Description("DETALLE_OTROS")]
        public string DETALLE_OTROS { get; set; }

        [Description("GRAVEDAD")]
        public string GRAVEDAD { get; set; }

        //PAU vs Descargos

        //Atributos para el reporte de Archivados
        [Description("NARCHIVO_INFORME")]
        public Int32 NARCHIVO_INFORME { get; set; }
        [Description("NARCHIVO_PRIMERA")]
        public Int32 NARCHIVO_PRIMERA { get; set; }
        [Description("NARCHIVO_SEGUNDA")]
        public Int32 NARCHIVO_SEGUNDA { get; set; }
        [Description("TIPO_ARCHIVADO")]
        public string TIPO_ARCHIVADO { get; set; }
        [Description("PROVINCIA")]
        public string PROVINCIA { get; set; }
        [Description("DISTRITO")]
        public string DISTRITO { get; set; }
        [Description("MOTIVO")]
        public string MOTIVO { get; set; }

        [Description("DESC_RD_INI")]
        public Int32 DESC_RD_INI { get; set; }
        [Description("ALLANAMIENTO")]
        public Int32 ALLANAMIENTO { get; set; }
        [Description("DESC_INF_FINAL")]
        public Int32 DESC_INF_FINAL { get; set; }
        [Description("APELACIONES")]
        public Int32 APELACIONES { get; set; }
        [Description("IMPLEMENTACIONES")]
        public Int32 IMPLEMENTACIONES { get; set; }

        [Description("BusTipo")]
        public String BusTipo { get; set; }

        //recursos impugnatorios
        [Description("Impugnatorios")]
        public Int32 Impugnatorios { get; set; }
        [Description("Resueltos")]
        public Int32 Resueltos { get; set; }
        [Description("Pendientes")]
        public Int32 Pendientes { get; set; }

        [Description("MES_")]
        public Int32 MES_ { get; set; }
        [Description("MES_NOMBRE")]
        public String MES_NOMBRE { get; set; }
        [Description("PROGRAMADO")]
        public Int32 PROGRAMADO { get; set; }
        [Description("SUPERVISADO")]
        public Int32 SUPERVISADO { get; set; }
        [Description("SUPERVISADO_CA")]
        public Int32 SUPERVISADO_CA { get; set; }
        [Description("SUPERVISADO_DOC")]
        public Int32 SUPERVISADO_DOC { get; set; }
        [Description("REMITIDOS")]
        public Int32 REMITIDOS { get; set; }

        [Description("COD_THABILITANTE")]
        public String COD_THABILITANTE { get; set; }


        [Description("SUPERVISOR")]
        public String SUPERVISOR { get; set; }

        [Description("FECHA_INICIO")]
        public String FECHA_INICIO { get; set; }

        [Description("FECHA_FIN")]
        public String FECHA_FIN { get; set; }

        [Description("FECHA_ENTREGA")]
        public String FECHA_ENTREGA { get; set; }

        [Description("CONTROL_CALIDAD")]
        public String CONTROL_CALIDAD { get; set; }

        [Description("FECHA_CCA")]
        public String FECHA_CCA { get; set; }

        [Description("DIGITALIZADO")]
        public String DIGITALIZADO { get; set; }

        [Description("FECHA_DERIVACION")]
        public String FECHA_DERIVACION { get; set; }

        [Description("NUM_POA")]
        public String NUM_POA { get; set; }

        [Description("COD_RESODIREC")]
        public String COD_RESODIREC { get; set; }


        [Description("RD_AUDIT_QUINQUENAL")]
        public String RD_AUDIT_QUINQUENAL { get; set; }
        [Description("FECHA_EMISION_RD_QUINQUENAL")]
        public String FECHA_EMISION_RD_QUINQUENAL { get; set; }
        [Description("NOTIFICACION")]
        public String NOTIFICACION { get; set; }
        [Description("EQUIPO")]
        public String EQUIPO { get; set; }
        [Description("NUM_INF_EVALUACION_DOC")]
        public String NUM_INF_EVALUACION_DOC { get; set; }

        [Description("FECHA_EMISION_ED")]
        public String FECHA_EMISION_ED { get; set; }
        [Description("NUM_INF_EVALUACION_CAMPO")]
        public String NUM_INF_EVALUACION_CAMPO { get; set; }
        [Description("FECHA_EMISION_EC")]
        public String FECHA_EMISION_EC { get; set; }
        [Description("NUM_INF_QUINQUENAL")]
        public String NUM_INF_QUINQUENAL { get; set; }
        [Description("FECHA_ENTREGA_INF_QUINQ")]
        public String FECHA_ENTREGA_INF_QUINQ { get; set; }
        [Description("INF_QUINQUENAL_CONCLUCION")]
        public String INF_QUINQUENAL_CONCLUCION { get; set; }
        [Description("AMPLIAR_CONTRATO")]
        public String AMPLIAR_CONTRATO { get; set; }

        [Description("MONTO_MULTA_TEXT")]
        public String MONTO_MULTA_TEXT { get; set; }
        [Description("MONTO_MULTA_FINAL_TEXT")]
        public String MONTO_MULTA_FINAL_TEXT { get; set; }
        [Description("COD_DOC_SIADO")]
        public String COD_DOC_SIADO { get; set; }

        public string ANIO_INFORME_TEXT { get; set; }

        public Ent_REPORTE_FISCALIZACION()
        {
            MES_ = -1;
            PROGRAMADO = -1;
            SUPERVISADO = -1;
            SUPERVISADO_CA = -1;
            SUPERVISADO_DOC = -1;
            REMITIDOS = -1;

            Impugnatorios = -1;
            Resueltos = -1;
            Pendientes = -1;
            DESC_RD_INI = -1;
            ALLANAMIENTO = -1;
            DESC_INF_FINAL = -1;
            APELACIONES = -1;
            IMPLEMENTACIONES = -1;
            // 29/08/2017
            //PORC_INEX = -1;
            DIAS_TRANSC = -1;
            FUNDADA = -1;
            IL_EVA_INF_SUP = -1;
            IL_ETAPA_INSTRU = -1;
            IL_CONFORMIDAD = -1;
            IL_EVA_REC_RECONS = -1;
            IL_OTROS = -1;
            IL_FINAL = -1;
            OTROS = -1;
            RECONSIDERACION = -1;
            INI_PAU = -1;
            TERMINO_PAU = -1;
            UCAYALI = -1;
            MADREDEDIOS = -1;
            SANMARTIN = -1;
            LORETO = -1;
            LAMBAYEQUE = -1;
            AMAZONAS = -1;
            HUANUCO = -1;
            PASCO = -1;
            JUNIO = -1;
            CATEGORIA = -1;
            TOTAL = -1;
            ITEM = -1;
            TOTAL_PRIMERO = -1;
            TOTAL_SEGUNDO = -1;
            ENERO = -1;
            FEBRERO = -1;
            MARZO = -1;
            ABRIL = -1;
            MAYO = -1;
            JUNIN = -1;
            JULIO = -1;
            AGOSTO = -1;
            SETIEMBRE = -1;
            OCTUBRE = -1;
            NOVIEMBRE = -1;
            DICIEMBRE = -1;
            SUPERVISIONES = -1;
            DOSMILNUEVE = -1;
            DOSMILDIEZ = -1;
            DOSMILONCE = -1;
            DOSMILDOCE = -1;
            DOSMILTRECE = -1;
            DOSMILCATORCE = -1;
            AVANCE = -1;
            AVANCE1 = -1;
            CANTIDAD = -1;
            AREA_OTORGADA = -1;
            DEFICIENCIA_TECNICA = -1;
            DEFICIENCIA_NOTIF = -1;
            EVIDENCIA_IRREGULARIDAD = -1;
            SIN_INDICIOS_INFRACCION = -1;
            EXPEDIENTE = -1;
            EMITIRIMPOSICION = -1;
            EMITIRLEGAL = -1;
            PAU_CONCLUIDOS = -1;
            SUPERVISION = -1;
            PROMEDIO = -1;
            DESCARGO = -1;
            SANCIONADO_PAU = -1;
            //SANCIONADO_RD = -1;
            MED_CORREC_PAU = -1;
            //MED_CORREC_RD = -1;
            AMONEST_PAU = -1;
            //AMONEST_RD = -1;
            CADUCADO_PAU = -1;
            //CADUCADO_RD = -1;
            CADUCADO_PAU_TH = -1;
            CADUCADO_PAU_TH_PRV = -1;
            ARCHIVO_PAU = -1;
            //ARCHIVO_RD = -1;
            ARCHIVO_PRELIMINAR = -1;
            ARCHIVO_PRELIMINAR_SIN = -1;
            SUPER_TERMINADO_PAU = -1;


            MEDCAU_PAU = -1;
            MEDPRECAU_PAU = -1;
            //SUPER_CASOS_INEX = -1;
            //SUPER_ARBOLES_INEX = -1;
            //VOL_INI_i_PAU = -1;
            //VOL_INI_w_PAU = -1;
            //VOL_TER_i_PAU = -1;
            //VOL_TER_w_PAU = -1;

            CASOS_SOLO_i_TER_PAU = -1;
            CASOS_SOLO_w_TER_PAU = -1;
            CASOS_SOLO_i_w_TER_PAU = -1;
            //CASOS_i_w_TER_PAU = -1;
            //UIT_TER_PAU = -1;

            CANT_CMADE = -1;
            CANT_NM = -1;
            CANT_FYR = -1;
            CANT_ECO = -1;
            CANT_CONS = -1;
            CANT_PFAUNA = -1;
            CANT_CFAUNA = -1;
            CANT_TARA = -1;
            CANT_BS = -1;
            CANT_BL = -1;
            CANT_PP = -1;
            CANT_CCCC_CCNN = -1;
            CANT_PNM = -1;

            Frecuencia = -1;
            Porcentaje = -1;
            //ART18a = -1;
            //ART18b = -1;
            //ART18c = -1;
            //ART18d = -1;
            //ART18e = -1;
            //ART295a = -1;
            //ART295b = -1;
            //ART295c = -1;
            //ART363e = -1;
            //ART363f = -1;
            //ART363i = -1;
            //ART363k = -1;
            //ART363l = -1;
            //ART363m = -1;
            //ART363n = -1;
            //ART363r = -1;
            //ART363t = -1;
            //ART363u = -1;
            //ART363V1 = -1;
            //ART363w = -1;
            //ART364f = -1;
            //ART364g = -1;
            //ART364h = -1;
            //ART364l = -1;
            //ART364o = -1;
            //ART364q = -1;
            //ART364s = -1;
            //ART364t = -1;
            //ART91Aa = -1;
            //ART91Ab = -1;
            //ART91Ad = -1;
            //ART91Ae = -1;
            //ART91Af = -1;
            //ART91Ag = -1;
            //ART91Ah = -1;

            RECTIFICACION = -1;
            MED_CAU = -1;

            CASOS = -1;
            AVANCE_CASOS = -1;

            CADUCADOS = -1;

            NARCHIVO_INFORME = -1;
            NARCHIVO_PRIMERA = -1;
            NARCHIVO_SEGUNDA = -1;

        }

    }
}
