using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CapaEntidad.DOC
{
    public class Ent_RESODIREC
    {
        #region "Entidades y Propiedades"

        [Description("COD_RESODIREC")]
        public String COD_RESODIREC { get; set; }
        [Description("COD_UCUENTA")]
        public String COD_UCUENTA { get; set; }
        [Description("COD_PERSONA")]
        public String COD_PERSONA { get; set; }
        [Description("COD_FCTIPO")]
        public String COD_FCTIPO { get; set; }
        [Description("NUMERO_RESOLUCION")]
        public String NUMERO_RESOLUCION { get; set; }
        [Description("DESCRIPCION")]
        public String DESCRIPCION { get; set; }
        [Description("APELLIDOS_NOMBRES")]
        public String APELLIDOS_NOMBRES { get; set; }
        [Description("RESOLUCION_COD_RESODIREC")]
        public String RESOLUCION_COD_RESODIREC { get; set; }

        [Description("D_LINEA")]
        public String D_LINEA { get; set; }
        [Description("NUM_THABILITANTE")]
        public String NUM_THABILITANTE { get; set; }
        [Description("COD_TITULAR")]
        public String COD_TITULAR { get; set; }
        [Description("TITULAR")]
        public String TITULAR { get; set; }
        [Description("COD_MTIPO")]
        public String COD_MTIPO { get; set; }
        [Description("NUMERO_SUP")]
        public String NUMERO_SUP { get; set; }

        //
        [Description("COD_ESTADO_DOC")]
        public String COD_ESTADO_DOC { get; set; }
        [Description("OBSERVACIONES_CONTROL")]
        public Object OBSERVACIONES_CONTROL { get; set; }
        [Description("OBSERV_SUBSANAR")]
        public Object OBSERV_SUBSANAR { get; set; }
        [Description("PUBLICAR")]
        public Object PUBLICAR { get; set; }
        //       
        [Category("FECHA"), Description("FECHA_EMISION")]
        public Object FECHA_EMISION { get; set; }
        [Category("FECHA"), Description("FECHA_ACUMULACION")]
        public Object FECHA_ACUMULACION { get; set; }
        [Category("FECHA"), Description("FECHA_OTROS")]
        public Object FECHA_OTROS { get; set; }


        //Archivo Archivo_Inf_sup
        [Description("EVIDENCIA_IRREGULARIDAD")]
        public object EVIDENCIA_IRREGULARIDAD { get; set; }
        [Description("BUEN_MANEJO")]
        public object BUEN_MANEJO { get; set; }
        [Description("SIN_INFRACCION")]
        public object SIN_INFRACCION { get; set; }
        [Description("DEFICIENTE_NOTIFICACION")]
        public object DEFICIENTE_NOTIFICACION { get; set; }
        [Description("DEFICIENCIA_TECNICA")]
        public object DEFICIENCIA_TECNICA { get; set; }
        [Description("OTROS_arch")]
        public string OTROS_arch { get; set; }
        [Description("RegEstado")]
        public int RegEstado { get; set; }
        [Description("COD_OD_REGISTRO")]
        public String COD_OD_REGISTRO { get; set; }

        [Description("OUTPUTPARAM01")]
        public String OUTPUTPARAM01 { get; set; }
        [Description("OUTPUTPARAM02")]
        public String OUTPUTPARAM02 { get; set; }
        [Description("TIPO_FISCALIZA")]
        public String TIPO_FISCALIZA { get; set; }

        //Inicio PAU
        [Category("FK"), Description("COD_RESODIREC_INI_PAU")]
        public String COD_RESODIREC_INI_PAU { get; set; }

        [Description("NUMERO_EXPEDIENTE")]
        public String NUMERO_EXPEDIENTE { get; set; }
        [Description("MEDIDAS_CAUTELARES")]
        public object MEDIDAS_CAUTELARES { get; set; }
        [Description("DESCRIPCION_MEDIDAS_PAU")]
        public String DESCRIPCION_MEDIDAS_PAU { get; set; }
        [Description("CAUSALES_CADUCIDAD")]
        public object CAUSALES_CADUCIDAD { get; set; }
        [Description("SOLICITUD_ANTECEDENTES")]
        public object SOLICITUD_ANTECEDENTES { get; set; }
        [Description("SOLICITUD_BALANCE")]
        public object SOLICITUD_BALANCE { get; set; }
        [Description("ATFFS")]
        public object ATFFS { get; set; }
        [Description("DETALLE_ATFFS")]
        public String DETALLE_ATFFS { get; set; }
        [Description("OCI")]
        public object OCI { get; set; }
        [Description("DETALLE_OCI")]
        public String DETALLE_OCI { get; set; }
        [Description("DGFFS")]
        public object DGFFS { get; set; }
        [Description("DETALLE_DGFFS")]
        public String DETALLE_DGFFS { get; set; }
        [Description("PROGRAMA_REGIONAL")]
        public object PROGRAMA_REGIONAL { get; set; }
        [Description("DETALLE_PROREG")]
        public String DETALLE_PROREG { get; set; }
        [Description("MINISTERIO_PUBLICO")]
        public object MINISTERIO_PUBLICO { get; set; }
        [Description("DETALLE_MINPUB")]
        public String DETALLE_MINPUB { get; set; }
        [Description("COLEGIO_INGENIEROS")]
        public object COLEGIO_INGENIEROS { get; set; }
        [Description("DETALLE_COLING")]
        public String DETALLE_COLING { get; set; }
        [Description("OTROS")]
        public object OTROS { get; set; }
        [Description("DETALLE_OTROS")]
        public String DETALLE_OTROS { get; set; }
        [Description("OEFA")]
        public object OEFA { get; set; }
        [Description("DETALLE_OEFA")]
        public String DETALLE_OEFA { get; set; }
        [Description("SUNAT")]
        public object SUNAT { get; set; }
        [Description("DETALLE_SUNAT")]
        public String DETALLE_SUNAT { get; set; }
        [Description("SERFOR")]
        public object SERFOR { get; set; }
        [Description("DETALLE_SERFOR")]
        public String DETALLE_SERFOR { get; set; }
        [Description("COD_ILEGAL_ENCISOS")]
        public string COD_ILEGAL_ENCISOS { get; set; }
        [Description("DESCRIPCION_ARTICULOS")]
        public string DESCRIPCION_ARTICULOS { get; set; }
        [Description("DESCRIPCION_ENCISOS")]
        public string DESCRIPCION_ENCISOS { get; set; }
        [Category("FK"), Description("COD_ESPECIES")]
        public string COD_ESPECIES { get; set; }
        [Description("DESCRIPCION_ESPECIE")]
        public string DESCRIPCION_ESPECIE { get; set; }
        [Description("VOLUMEN")]
        public decimal VOLUMEN { get; set; }
        [Description("AREA")]
        public decimal AREA { get; set; }
        [Description("NUMERO_INDIVIDUOS")]
        public int NUMERO_INDIVIDUOS { get; set; }
        [Description("DESCRIPCION_INFRACCIONES")]
        public string DESCRIPCION_INFRACCIONES { get; set; }
        [Description("GRAVEDAD")]
        public string GRAVEDAD { get; set; }
        [Description("COD_SECUENCIAL")]
        public int COD_SECUENCIAL { get; set; }

        [Description("TIPOMADERABLE")]
        public String TIPOMADERABLE { get; set; }


        [Description("TIPO")]
        public String TIPO { get; set; }
        [Description("EliTABLA")]
        public string EliTABLA { get; set; }
        [Description("EliVALOR01")]
        public string EliVALOR01 { get; set; }
        [Description("EliVALOR02")]
        public int EliVALOR02 { get; set; }
        [Description("INFORMACION_FALSA_INEX")]
        public object INFORMACION_FALSA_INEX { get; set; }
        [Description("INFORMACION_FALSA_DIF")]
        public object INFORMACION_FALSA_DIF { get; set; }
        [Description("INFORMACION_FALSA_DAS")]
        public object INFORMACION_FALSA_DAS { get; set; }
        [Description("DESCRIPCION_INFORMACION_FALSA")]
        public string DESCRIPCION_INFORMACION_FALSA { get; set; }

        [Description("MOTAMP_AMPIMP")]
        public object MOTAMP_AMPIMP { get; set; }
        [Description("MOTAMP_AMPOTRINF")]
        public object MOTAMP_AMPOTRINF { get; set; }
        [Description("MOTAMP_AMPPORPLA")]
        public object MOTAMP_AMPPORPLA { get; set; }
        [Description("MOTAMP_OTROS")]
        public String MOTAMP_OTROS { get; set; }

        [Description("BusFormulario")]
        public String BusFormulario { get; set; }
        [Description("BusCriterio")]
        public String BusCriterio { get; set; }
        [Description("BusValor")]
        public String BusValor { get; set; }

        //Rectificacion
        //[Description("COD_RESODIREC_RECTIFICACION")]
        //public String COD_RESODIREC_RECTIFICACION { get; set; }
        [Description("ERROR_MATERIAL")]
        public object ERROR_MATERIAL { get; set; }
        [Description("OTROS_RECTIFICACION")]
        public object OTROS_RECTIFICACION { get; set; }
        [Description("OTROS_DESCRIPCION")]
        public String OTROS_DESCRIPCION { get; set; }

        //Reconsideracion
        //[Description("COD_RESODIREC_RECONSIDERA")]
        //public String COD_RESODIREC_RECONSIDERA { get; set; }
        [Description("IMPROCEDENTE")]
        public object IMPROCEDENTE { get; set; }
        [Description("FUNDADA")]
        public object FUNDADA { get; set; }
        [Description("FUNDADA_PARTE")]
        public object FUNDADA_PARTE { get; set; }
        [Description("INFUNDADA")]
        public object INFUNDADA { get; set; }
        [Description("INADMISIBLE")]
        public object INADMISIBLE { get; set; }
        // Medida Cautelar
        [Description("IMPROCEDENTE_MED")]
        public object IMPROCEDENTE_MED { get; set; }
        [Description("FUNDADA_MED")]
        public object FUNDADA_MED { get; set; }
        [Description("FUNDADA_PARTE_MED")]
        public object FUNDADA_PARTE_MED { get; set; }
        [Description("INFUNDADA_MED")]
        public object INFUNDADA_MED { get; set; }
        [Description("LEVANTAR_CADUCIDAD")]
        public object LEVANTAR_CADUCIDAD { get; set; }
        [Description("RECTIF_CAMBIO_MULTA")]
        public object RECTIF_CAMBIO_MULTA { get; set; }
        [Description("RECONS_CAMBIO_MULTA")]
        public object RECONS_CAMBIO_MULTA { get; set; }
        [Description("RECTIF_MONTO")]
        public decimal RECTIF_MONTO { get; set; }
        [Description("RECONS_MONTO")]
        public decimal RECONS_MONTO { get; set; }
        //[Description("COD_RESODIREC_MED_CAUTELARES")]
        //public String COD_RESODIREC_MED_CAUTELARES { get; set; }
        [Description("LEV_MED_CAUTELAR")]
        public object LEV_MED_CAUTELAR { get; set; }
        [Description("MOD_MED_CAUTELAR")]
        public object MOD_MED_CAUTELAR { get; set; }
        [Description("DESCRIPCION_MED_CAUTELAR")]
        public String DESCRIPCION_MED_CAUTELAR { get; set; }
        [Description("EXPEDIENTE_ADMINISTRATIVO_ASIGNADO")]
        public String EXPEDIENTE_ADMINISTRATIVO_ASIGNADO { get; set; }

        // Acumulacion
        //[Description("COD_ACUMULACION")]
        //public String COD_ACUMULACION { get; set; }
        [Description("DESCRIPCION_ACUMULACION")]
        public String DESCRIPCION_ACUMULACION { get; set; }

        //Otros
        //[Description("COD_RESODIREC_OTROS")]
        //public String COD_RESODIREC_OTROS { get; set; }
        [Description("DESCRIPCION_OTROS")]
        public String DESCRIPCION_OTROS { get; set; }

        [Category("FK"), Description("COD_INFORME")]
        public String COD_INFORME { get; set; }

        [Description("CODIGO")]
        public String CODIGO { get; set; }
        [Description("COD_DETALLE")]
        public String COD_DETALLE { get; set; }
        [Description("NUMERO")]
        public String NUMERO { get; set; }

        //Ampliacion PAU
        //[Description("COD_RESODIREC_AMPLI_PAU")]
        //public String COD_RESODIREC_AMPLI_PAU { get; set; }

        [Description("MOTIVO")]
        public String MOTIVO { get; set; }
        [Description("DETALLE_MOTIVO")]
        public String DETALLE_MOTIVO { get; set; }

        //Termino PAU
        [Category("FK"), Description("COD_RESUDIREC_PAU_FIN_TIPO")]
        public String COD_RESUDIREC_PAU_FIN_TIPO { get; set; }
        [Description("MULTA")]
        public object MULTA { get; set; }
        [Description("MONTO")]
        public decimal MONTO { get; set; }
        [Description("CADUCIDAD")]
        public object CADUCIDAD { get; set; }


        //  MEDIDA CORRECTIVA
        [Description("DESCRIPCION_MED_CORRECTIVAS")]
        public String DESCRIPCION_MED_CORRECTIVAS { get; set; }
        /*
        [Description("iCodMC")]
        public int iCodMC { get; set; }
        [Description("iCodMCE")]
        public int iCodMCE { get; set; }
        [Description("DIA_IMPLEMENT_MCORRECTIVA")]
        public int DIA_IMPLEMENT_MCORRECTIVA { get; set; }
        [Description("MES_IMPLEMENT_MCORRECTIVA")]
        public int MES_IMPLEMENT_MCORRECTIVA { get; set; }
        [Description("ANIO_IMPLEMENT_MCORRECTIVA")]
        public int ANIO_IMPLEMENT_MCORRECTIVA { get; set; }
        [Description("DIA_POST_IMPLEMENT_MCORRECTIVA")]
        public int DIA_POST_IMPLEMENT_MCORRECTIVA { get; set; }
        [Description("MES_POST_IMPLEMENT_MCORRECTIVA")]
        public int MES_POST_IMPLEMENT_MCORRECTIVA { get; set; }
        [Description("ANIO_POST_IMPLEMENT_MCORRECTIVA")]
        public int ANIO_POST_IMPLEMENT_MCORRECTIVA { get; set; }
        [Description("DIA_INFORME_MCORRECTIVA")]
        public int DIA_INFORME_MCORRECTIVA { get; set; }
        [Description("MES_INFORME_MCORRECTIVA")]
        public int MES_INFORME_MCORRECTIVA { get; set; }
        [Description("ANIO_INFORME_MCORRECTIVA")]
        public int ANIO_INFORME_MCORRECTIVA { get; set; }
        */

        [Description("COD_RESODIREC_ARCHIVO_PAU_SUB")]
        public String COD_RESODIREC_ARCHIVO_PAU_SUB { get; set; }
        [Description("DESCRIPCIONMOTIVO")]
        public String DESCRIPCIONMOTIVO { get; set; }
        [Description("TEXTO_RECTIFICACION")]
        public String TEXTO_RECTIFICACION { get; set; }
        [Description("DESCRIPCION_MEDIDAS_CAUTELARES")]
        public String DESCRIPCION_MEDIDAS_CAUTELARES { get; set; }

        [Description("SANCION_EXTITULAR")]
        public object SANCION_EXTITULAR { get; set; }
        [Description("SIN_INDICIOS_APROV")]
        public object SIN_INDICIOS_APROV { get; set; }

        //Para lista de POAS
        [Description("NUM_POA")]
        public String NUM_POA { get; set; }
        [Description("POA")]
        public String POA { get; set; }

        [Description("TIPO_DOCUMENTO_REPORT")]
        public String TIPO_DOCUMENTO_REPORT { get; set; }
        [Description("COD_DOCUMENTO_REPORT")]
        public String COD_DOCUMENTO_REPORT { get; set; }
        [Description("NUM_POA_REPORT")]
        public Int32 NUM_POA_REPORT { get; set; }

        //cambios RD
        [Description("DETERMINACION")]
        public String DETERMINACION { get; set; }
        [Description("BTN_LITERALES")]
        public object BTN_LITERALES { get; set; }
        [Description("BTN_LITERALES2")]
        public object BTN_LITERALES2 { get; set; }
        [Description("LEV_PARTE_MED_CAUTELAR")]
        public object LEV_PARTE_MED_CAUTELAR { get; set; }
        [Description("NO_LEV_MED_CAUTELAR")]
        public object NO_LEV_MED_CAUTELAR { get; set; }
        [Description("COD_ILEGAL_ARTICULOS")]
        public string COD_ILEGAL_ARTICULOS { get; set; }
        //ministerio de energia y minas agregado el 14/07/2016
        [Description("MIN_ENERGIA_MINAS")]
        public object MIN_ENERGIA_MINAS { get; set; }
        [Description("DETALLE_MINENMIN")]
        public String DETALLE_MINENMIN { get; set; }
        // modificacion de la resolucion directoral 01/08/2016
        [Description("MED_CAUT_GTF")]
        public Object MED_CAUT_GTF { get; set; }
        [Description("MED_CAUT_LIST_TROZA")]
        public Object MED_CAUT_LIST_TROZA { get; set; }
        [Description("MED_CAUT_PM")]
        public Object MED_CAUT_PM { get; set; }
        [Description("MED_CAUT_POA")]
        public Object MED_CAUT_POA { get; set; }
        [Description("DESCUENTO")]
        public Object DESCUENTO { get; set; }
        [Description("COD_RESODIREC_GRAVEDAD")]
        public String COD_RESODIREC_GRAVEDAD { get; set; }
        //variables para las nuevas opciones de rectificacion
        [Description("NOM_TITULAR")]
        public object NOM_TITULAR { get; set; }
        [Description("DESC_NOM_TIT")]
        public String DESC_NOM_TIT { get; set; }
        [Description("NUM_TITULO")]
        public object NUM_TITULO { get; set; }
        [Description("DESC_NUM_TIT")]
        public String DESC_NUM_TIT { get; set; }
        [Description("NUM_EXP")]
        public object NUM_EXP { get; set; }
        [Description("DESC_NUM_EXPE")]
        public String DESC_NUM_EXPE { get; set; }
        [Description("FECHA_EMISION1")]
        public object FECHA_EMISION1 { get; set; }
        [Description("DESC_FECHA")]
        public object DESC_FECHA { get; set; }
        [Description("ESPECIES")]
        public object ESPECIES { get; set; }

        //entidad persona para su modificacion
        [Description("AP_PATERNO")]
        public String AP_PATERNO { get; set; }
        [Description("AP_MATERNO")]
        public String AP_MATERNO { get; set; }
        [Description("NOMBRES")]
        public String NOMBRES { get; set; }
        [Description("RAZON_SOCIAL")]
        public String RAZON_SOCIAL { get; set; }
        [Description("TIPO_PERSONA")]
        public String TIPO_PERSONA { get; set; }

        [Description("AMONESTACION")]
        public Object AMONESTACION { get; set; }

        [Category("LIST"), Description("ListInformes")]
        public List<Ent_RESODIREC> ListarIniPAU { get; set; }
        [Category("LIST"), Description("ListarIniPAU")]
        public List<Ent_RESODIREC> MotivoArchivo { get; set; }
        [Category("LIST"), Description("MotivoArchivo")]
        public List<Ent_RESODIREC> ListInformes { get; set; }
        //[Category("LIST"), Description("ListResolucioPrin")]
        //public List<Ent_RESODIREC> ListResolucioPrin { get; set; }
        [Category("LIST"), Description("ListEliTABLA")]
        public List<Ent_RESODIREC> ListEliTABLA { get; set; }
        [Category("LIST"), Description("ListEspeciesForestal")]
        public List<Ent_RESODIREC> ListEspeciesForestal { get; set; }
        [Category("LIST"), Description("ListEspeciesFauna")]
        public List<Ent_RESODIREC> ListEspeciesFauna { get; set; }
        [Category("LIST"), Description("ListArticulosPAU")]
        public List<Ent_RESODIREC> ListArticulosPAU { get; set; }
        [Category("LIST"), Description("ListPOAs")]
        public List<Ent_RESODIREC> ListPOAs { get; set; }
        [Category("LIST"), Description("ListTitulares")]
        public List<Ent_RESODIREC> ListTitulares { get; set; }
        [Category("LIST"), Description("ListTipoDeter")]
        public List<Ent_RESODIREC> ListTipoDeter { get; set; }

        [Category("LIST"), Description("ListComboGravedad")]
        public List<Ent_RESODIREC> ListComboGravedad { get; set; }
        [Category("LIST"), Description("ListLiterales")]
        public List<Ent_RESODIREC> ListLiterales { get; set; }
        [Category("LIST"), Description("ListLiterales")]
        public List<Ent_RESODIREC> ListRD_Rectificar { get; set; }
        //rectificacion de especias
        [Category("LIST"), Description("ListEspeciesError")]
        public List<Ent_RESODIREC> ListEspeciesError { get; set; }
        [Category("LIST"), Description("ListTitularRectificar")]
        public List<Ent_RESODIREC> ListTitularRectificar { get; set; }

        [Category("LIST"), Description("ListTipoArchivo")]
        public List<Ent_RESODIREC> ListTipoArchivo { get; set; }

        [Description("COD_THABILITANTE")]
        public String COD_THABILITANTE { get; set; }
        [Description("TITULO")]
        public String TITULO { get; set; }
        [Description("FECHA_CAMPO")]
        public Object FECHA_CAMPO { get; set; }

        [Description("DAP")]
        public Decimal DAP { get; set; }
        [Description("AC")]
        public Decimal AC { get; set; }
        [Description("DMC")]
        public Int32 DMC { get; set; }
        [Description("CONDICION_ESPECIE")]
        public String CONDICION_ESPECIE { get; set; }
        [Description("MUESTRA_QUIN")]
        public Object MUESTRA_QUIN { get; set; }
        [Description("COORDENADA_ESTE")]
        public String COORDENADA_ESTE { get; set; }
        [Description("COORDENADA_NORTE")]
        public String COORDENADA_NORTE { get; set; }

        [Description("PRIM_QUINQUENIO")]
        public Object PRIM_QUINQUENIO { get; set; }
        [Description("SEG_QUINQUENIO")]
        public Object SEG_QUINQUENIO { get; set; }
        [Description("TERC_QUINQUENIO")]
        public Object TERC_QUINQUENIO { get; set; }
        [Description("CUART_QUINQUENIO")]
        public Object CUART_QUINQUENIO { get; set; }
        [Description("BLOQ_QUINQUENIO")]
        public Int32 BLOQ_QUINQUENIO { get; set; }

        [Description("RESDIR")]
        public object RESDIR { get; set; }
        [Description("RESSUBDIR")]
        public object RESSUBDIR { get; set; }

        [Description("COD_RESOLUCION_TFFS")]
        public string COD_RESOLUCION_TFFS { get; set; }
        [Category("FECHA"), Description("BEXTRACCION_FEMISION")]
        public Object BEXTRACCION_FEMISION { get; set; }

        [Description("USUARIO_REGISTRO")]
        public String USUARIO_REGISTRO { get; set; }
        [Description("USUARIO_CONTROL")]
        public String USUARIO_CONTROL { get; set; }

        [Category("LIST"), Description("ListTHabilitanteQuinquenal")]
        public List<Ent_RESODIREC> ListTHabilitanteQuinquenal { get; set; }
        [Category("LIST"), Description("ListQuinquenalSupervisor")]
        public List<Ent_RESODIREC> ListQuinquenalSupervisor { get; set; }
        [Category("LIST"), Description("ListQuinquenalMuestra")]
        public List<Ent_RESODIREC> ListQuinquenalMuestra { get; set; }

        //26/06/2017
        [Description("OBSERVACION")]
        public string OBSERVACION { get; set; }
        //[Category("LIST"), Description("ListEspeciesMCorrectiva")]
        //public List<Ent_RESODIREC> ListEspeciesMCorrectiva { get; set; }

        [Description("RECTIFICACION")]
        public Object RECTIFICACION { get; set; }
        [Description("DESC_RECTIFICACION")]
        public String DESC_RECTIFICACION { get; set; }

        //29/09/2017
        [Description("MED_CAUT_XESPECIE")]
        public Object MED_CAUT_XESPECIE { get; set; }

        [Category("LIST"), Description("ListEspeciesMedidas")]
        public List<Ent_RESODIREC> ListEspeciesMedidas { get; set; }
        //04/10/2017
        [Description("MAE_ESTDETERMINA_ART363I")]
        public String MAE_ESTDETERMINA_ART363I { get; set; }
        [Description("ESTDETERMINA_ART363I")]
        public String ESTDETERMINA_ART363I { get; set; }

        [Category("FECHA"), Description("FECHA_ANULACION")]
        public Object FECHA_ANULACION { get; set; }

        /// <summary>
        /// PARA EL BALANCE 22/05/2019
        /// </summary>
        [Description("COD_BITACORA")]
        public String COD_BITACORA { get; set; }
        [Category("LIST"), Description("ListBEXT")]
        public List<Ent_RESODIREC> ListBEXT { get; set; }
        [Description("NUMERO_POA")]
        public Int32 NUMERO_POA { get; set; }
        [Description("NOMBRE_POA")]
        public String NOMBRE_POA { get; set; }
        [Description("TOTAL_ARBOLES")]
        public Int32 TOTAL_ARBOLES { get; set; }
        [Description("VOLUMEN_AUTORIZADO")]
        public Decimal VOLUMEN_AUTORIZADO { get; set; }
        [Description("VOLUMEN_MOVILIZADO")]
        public Decimal VOLUMEN_MOVILIZADO { get; set; }
        [Description("SALDO")]
        public Decimal SALDO { get; set; }
        [Description("FECHA_BALANCE")]
        public Object FECHA_BALANCE { get; set; }

        //MANDATOS
        [Category("LIST"), Description("ListMandatos")]
        public List<Ent_RESODIREC_MEDIDA> ListMandatos { get; set; }
        [Description("MANDATOS")]
        public Object MANDATOS { get; set; }
        //MEDIDAS CORRECTIVAS
        [Category("LIST"), Description("ListMedidasCorrectivas")]
        public List<Ent_RESODIREC_MEDIDA> ListMedidasCorrectivas { get; set; }
        [Description("MEDIDAS_CORRECTIVAS")]
        public object MEDIDAS_CORRECTIVAS { get; set; }

        //[Description("ICODMANDATO")]
        //public int ICODMANDATO { get; set; }
        //[Description("ESMANDATO")]
        //public int ESMANDATO { get; set; }
        //[Description("MANDATO")]
        //public String MANDATO { get; set; }
        //[Description("CANTMESES")]
        //public int CANTMESES { get; set; }
        //[Description("CANTDIAS")]
        //public int CANTDIAS { get; set; }
        //[Description("CANTMESES_INF")]
        //public int CANTMESES_INF { get; set; }
        //[Description("CANTDIAS_INF")]
        //public int CANTDIAS_INF { get; set; }


        [Description("ITIPO")]
        public int ITIPO { get; set; }
        [Description("FECHA_INI")]
        public String FECHA_INI { get; set; }
        [Description("FECHA_FIN")]
        public String FECHA_FIN { get; set; }
        [Description("FECHA_FIN2")]
        public String FECHA_FIN2 { get; set; }
        [Description("vEnlace")]
        public String vEnlace { get; set; }
        [Description("ORIGEN")]
        public int ORIGEN { get; set; }
        [Description("FECHAINF_FIN")]
        public String FECHAINF_FIN { get; set; }
        [Description("FECHAINF_FIN2")]
        public String FECHAINF_FIN2 { get; set; }
        public string MODALIDAD { get; set; }
        public string FECHA { get; set; }
        public string MED_CORRECTIVA { get; set; }
        #endregion

        [Description("v_ROW_INDEX")]
        public Int32 v_ROW_INDEX { get; set; }

        [Description("v_currentpage")]
        public Int32 v_currentpage { get; set; }

        [Description("v_pagesize")]
        public Int32 v_pagesize { get; set; }

        [Description("PCA")]
        public String PCA { get; set; }

        [Description("BusValor2")]
        public Int32 BusValor2 { get; set; }

        //23.08.2021 CARR
        [Description("CHK_ACCION")]
        public object CHK_ACCION { get; set; }

        [Description("CHK_ALLANAMIENTO")]
        public object CHK_ALLANAMIENTO { get; set; }

        [Description("CHK_SUBSANACION")]
        public object CHK_SUBSANACION { get; set; }

        //[Description("CHK_MEDCOMPLE")]
        //public object CHK_MEDCOMPLE { get; set; }

        [Description("CHK_DECOMISO")]
        public object CHK_DECOMISO { get; set; }

        [Description("CHK_PLANCIERRE")]
        public object CHK_PLANCIERRE { get; set; }

        [Description("CHK_DIPOSICIONFAUNA")]
        public object CHK_DIPOSICIONFAUNA { get; set; }
        [Description("CHK_PARALIZACION")]
        public object CHK_PARALIZACION { get; set; }
        [Description("CHK_CLAUSURATEMPORAL")]
        public object CHK_CLAUSURATEMPORAL { get; set; }
        [Description("CHK_CLAUSURADEFINITIVA")]
        public object CHK_CLAUSURADEFINITIVA { get; set; }
        [Description("CHK_INHABILITACIONTEMPORAL")]
        public object CHK_INHABILITACIONTEMPORAL { get; set; }
        [Description("CHK_INHABILITACIONDEFINITIVA")]
        public object CHK_INHABILITACIONDEFINITIVA { get; set; }
        [Description("CHK_INMOVILIZACION")]
        public object CHK_INMOVILIZACION { get; set; }


        [Description("TIPO_DOCUMENTO")]
        public String TIPO_DOCUMENTO { get; set; }

        [Description("PDF_DOCUMENTO")]
        public String PDF_DOCUMENTO { get; set; }

        [Description("COD_RDACCION")]
        public String COD_RDACCION { get; set; }

        [Description("SUBTIPO")]
        public String SUBTIPO { get; set; }

        public List<Ent_RESODIREC> listSTD01 { get; set; }
        public List<Ent_RESODIREC> listSTD02 { get; set; }
        public List<Ent_RESODIREC> listEliTSTD01 { get; set; }
        public List<Ent_RESODIREC> listEliTSTD02 { get; set; }

        //21.09.2022 TGS tercero solidario
        [Description("COD_TERCERO_SOLIDARIO")]
        public String COD_TERCERO_SOLIDARIO { get; set; }
        [Description("TERCERO_SOLIDARIO")]
        public String TERCERO_SOLIDARIO { get; set; }

        [Description("SUBSANACION_VOLUNTARIA")]
        public Object SUBSANACION_VOLUNTARIA { get; set; }
        [Description("COD_RESODIREC_DET_INFRACCION")]
        public string COD_RESODIREC_DET_INFRACCION { get; set; }
        [Description("COD_ENCISOS")]
        public string COD_ENCISOS { get; set; }
        [Description("ARTICULO")]
        public string ARTICULO { get; set; }
        [Description("INCISO")]
        public string INCISO { get; set; }
        [Description("ESTADO")]
        public int ESTADO { get; set; }
        [Category("LIST"), Description("ListIncisos")]
        public List<Ent_RESODIREC> ListIncisos { get; set; }
        [Category("LIST"), Description("ListEliTABLAIncisos")]
        public List<Ent_RESODIREC> ListEliTABLAIncisos { get; set; }
        

        #region "Constructor"
        public Ent_RESODIREC()
        {
            //DIA_POST_IMPLEMENT_MCORRECTIVA = -1;
            //MES_POST_IMPLEMENT_MCORRECTIVA = -1;
            //ANIO_POST_IMPLEMENT_MCORRECTIVA = -1;
            //iCodMC = -1;
            //iCodMCE = -1;
            ORIGEN = -1;
            ITIPO = -1;
            //ICODMANDATO = -1;
            RECTIFICACION = -1;
            RegEstado = -1;
            VOLUMEN = -1;
            AREA = -1;
            NUMERO_INDIVIDUOS = -1;
            COD_SECUENCIAL = -1;
            MONTO = -1;
            RECTIF_MONTO = -1;
            RECONS_MONTO = -1;
            EliVALOR02 = -1;
            NUM_POA_REPORT = -1;
            DAP = -1;
            AC = -1;
            DMC = -1;
            BLOQ_QUINQUENIO = -1;
            //DIA_IMPLEMENT_MCORRECTIVA = -1;
            //DIA_INFORME_MCORRECTIVA = -1;
            //MES_IMPLEMENT_MCORRECTIVA = -1;
            //MES_INFORME_MCORRECTIVA = -1;
            //ANIO_IMPLEMENT_MCORRECTIVA = -1;
            //ANIO_INFORME_MCORRECTIVA = -1;
            NUMERO_POA = -1;
            TOTAL_ARBOLES = -1;
            VOLUMEN_AUTORIZADO = -1;
            VOLUMEN_MOVILIZADO = -1;
            SALDO = -1;
            //ESMANDATO = -1;
            //CANTMESES = -1;
            //CANTDIAS = -1;
            //CANTMESES_INF = -1;
            //CANTDIAS_INF = -1;
            v_ROW_INDEX = -1;
            v_currentpage = -1;
            v_pagesize = -1;
            BusValor2 = -1;
            ESTADO = -1;
        }
        #endregion
    }

    public class Ent_RESODIREC_CONSULTA
    {
        public string COD_RESODIREC { get; set; }
        public string COD_RESODIREC_INI_PAU { get; set; }
        public int COD_RPSECUENCIAL { get; set; }
        public string NUM_RESOLUCION { get; set; }
        public string NUM_EXPEDIENTE { get; set; }
        public string DLINEA { get; set; }
        public string NUM_THABILITANTE { get; set; }
        public string TITULAR { get; set; }
        public int RegEstado { get; set; }
    }

    public class Ent_RESODIREC_MEDIDA
    {
        [Description("COD_RESODIREC")]
        public string COD_RESODIREC { get; set; }
        [Description("COD_MEDIDA")]
        public int COD_MEDIDA { get; set; }
        [Description("MEDIDA")]
        public string MEDIDA { get; set; }
        [Description("MAE_TIP_MEDIDA")]
        public string MAE_TIP_MEDIDA { get; set; }
        [Description("PLAZO_IMPL_DIA")]
        public int PLAZO_IMPL_DIA { get; set; }
        [Description("PLAZO_IMPL_MES")]
        public int PLAZO_IMPL_MES { get; set; }
        [Description("PLAZO_IMPL_ANIO")]
        public int PLAZO_IMPL_ANIO { get; set; }
        [Description("PLAZO_POST_DIA")]
        public int PLAZO_POST_DIA { get; set; }
        [Description("PLAZO_POST_MES")]
        public int PLAZO_POST_MES { get; set; }
        [Description("PLAZO_POST_ANIO")]
        public int PLAZO_POST_ANIO { get; set; }
        [Description("PLAZO_INF_DIA")]
        public int PLAZO_INF_DIA { get; set; }
        [Description("PLAZO_INF_MES")]
        public int PLAZO_INF_MES { get; set; }
        [Description("PLAZO_INF_ANIO")]
        public int PLAZO_INF_ANIO { get; set; }
        [Description("COD_UCUENTA")]
        public string COD_UCUENTA { get; set; }

        [Category("LIST"), Description("ListEspeciesMCorrectiva")]
        public List<Ent_RESODIREC_MEDIDA_ESPECIE> ListEspeciesMCorrectiva { get; set; }

        //Columnas para el saeguimiento de medidas
        [Description("COD_RESODIREC_MEDIDA")]
        public string COD_RESODIREC_MEDIDA { get; set; }
        [Description("NUM_RESOLUCION_MEDIDA")]
        public string NUM_RESOLUCION_MEDIDA { get; set; }
        [Description("FECHA_NOTIFICACION")]
        public object FECHA_NOTIFICACION { get; set; }
        [Description("PLAZO_IMPLEMENTACION")]
        public object PLAZO_IMPLEMENTACION { get; set; }
        public int RegEstado { get; set; }
        public Ent_RESODIREC_MEDIDA()
        {
            COD_MEDIDA = -1;
            PLAZO_IMPL_ANIO = -1;
            PLAZO_IMPL_DIA = -1;
            PLAZO_IMPL_MES = -1;
            PLAZO_INF_ANIO = -1;
            PLAZO_INF_DIA = -1;
            PLAZO_INF_MES = -1;
            PLAZO_POST_ANIO = -1;
            PLAZO_POST_DIA = -1;
            PLAZO_POST_MES = -1;
            RegEstado = -1;
        }
    }

    public class Ent_RESODIREC_MEDIDA_ESPECIE
    {
        [Description("COD_RESODIREC")]
        public string COD_RESODIREC { get; set; }
        [Description("COD_MEDIDA")]
        public int COD_MEDIDA { get; set; }
        [Description("COD_SECUENCIAL")]
        public int COD_SECUENCIAL { get; set; }
        [Description("COD_ESPECIES")]
        public string COD_ESPECIES { get; set; }
        [Description("ESPECIES")]
        public string ESPECIES { get; set; }
        [Description("VOLUMEN_MOVILIZADO")]
        public decimal VOLUMEN_MOVILIZADO { get; set; }
        [Description("NUMERO_INDIVIDUOS")]
        public int NUMERO_INDIVIDUOS { get; set; }
        [Description("OBSERVACION")]
        public string OBSERVACION { get; set; }
        [Description("COD_UCUENTA")]
        public string COD_UCUENTA { get; set; }
        [Description("RegEstado")]
        public int RegEstado { get; set; }

        public Ent_RESODIREC_MEDIDA_ESPECIE()
        {
            COD_MEDIDA = -1;
            COD_SECUENCIAL = -1;
            VOLUMEN_MOVILIZADO = -1;
            NUMERO_INDIVIDUOS = -1;
            RegEstado = -1;
        }
    }

    public class Ent_RESODIREC_MEDIDA_SEGUIMIENTO
    {
        [Description("COD_RESODIREC")]
        public string COD_RESODIREC { get; set; }
        [Description("NUM_EXPEDIENTE")]
        public string NUM_EXPEDIENTE { get; set; }
        [Description("NUM_THABILITANTE")]
        public string NUM_THABILITANTE { get; set; }
        [Description("TITULAR")]
        public string TITULAR { get; set; }
        [Description("MODALIDAD")]
        public string MODALIDAD { get; set; }
        [Category("LIST"), Description("ListMedidaCorrectiva")]
        public List<Ent_RESODIREC_MEDIDA> ListMedidaCorrectiva { get; set; }
        [Category("LIST"), Description("ListMandato")]
        public List<Ent_RESODIREC_MEDIDA> ListMandato { get; set; }
    }

    public class Ent_RESODIREC_REPORTEMEDIDAD
    {
        public string FECHA_EMSION { get; set; }
        public string TITULAR { get; set; }
        public string TITULO { get; set; }
        public string RESOLUCION { get; set; }
        public string NUMERO_EXPEDIENTE { get; set; }
        public string SANCION { get; set; }
        public string AMONESTACION { get; set; }
        public string ARCHIVO { get; set; }
        public string ALLANAMIENTO { get; set; }
        public string SUBSANACION { get; set; }
        public string IMPL_MEDIDAS { get; set; }
        public string DECOMISO { get; set; }
        public string PLAN_CIERRE { get; set; }
        public string DISP_FAUNA { get; set; }
        public string MED_CORRECTIVA { get; set; }
        public string OBSERVACIONES { get; set; }
        public string GUIA_TF { get; set; }
        public string LISTA_TROZAS { get; set; }
        public string PLAN_MANEJO { get; set; }
        public string POA { get; set; }
        public string MED_CAUTELAR { get; set; }
        public string NUM_INFORME { get; set; }

    }
}
