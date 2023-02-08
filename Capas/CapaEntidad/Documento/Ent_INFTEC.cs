using System;
using System.Collections.Generic;
using System.ComponentModel;


namespace CapaEntidad.DOC
{
    public class Ent_INFTEC
    {
        #region "Entidades y Propiedades"

        [Category("FECHA"), Description("FECHA_EMISION")]
        public Object FECHA_EMISION { get; set; }

        [Category("FECHA"), Description("FECHA_INICIO_INSPECCION")]
        public Object FECHA_INICIO_INSPECCION { get; set; }
        [Category("FECHA"), Description("FECHA_FIN_INSPECCION")]
        public Object FECHA_FIN_INSPECCION { get; set; }
        //[Category("FECHA"), Description("FECHA_OTROS")]
        //public Object FECHA_OTROS { get; set; }
        //
        [Description("COD_ESTADO_DOC")]
        public String COD_ESTADO_DOC { get; set; }
        [Description("OBSERVACIONES_CONTROL")]
        public Object OBSERVACIONES_CONTROL { get; set; }
        [Description("OBSERV_SUBSANAR")]
        public Object OBSERV_SUBSANAR { get; set; }

        [Description("D_LINEA")]
        public String D_LINEA { get; set; }
        [Description("NUM_THABILITANTE")]
        public String NUM_THABILITANTE { get; set; }
        [Description("TITULAR")]
        public String TITULAR { get; set; }
        //        

        [Description("COD_INFTEC")]
        public String COD_INFTEC { get; set; }
        //[Description("COD_INFTEC_MULTA")]
        //public String COD_INFTEC_MULTA { get; set; }
        [Description("COD_PERSONA")]
        public String COD_PERSONA { get; set; }
        [Description("COD_UCUENTA")]
        public String COD_UCUENTA { get; set; }
        [Description("NUMERO_INFORME")]
        public String NUMERO_INFORME { get; set; }
        [Description("COD_FCTIPO")]
        public String COD_FCTIPO { get; set; }
        [Description("COD_INFORME")]
        public String COD_INFORME { get; set; }
        [Description("MULTA_RECOMENDADA_UIT")]
        public decimal MULTA_RECOMENDADA_UIT { get; set; }
        [Description("MULTA_RECOMENDADA_SOLES")]
        public decimal MULTA_RECOMENDADA_SOLES { get; set; }
        [Description("MOTIVO_MULTA")]
        public string MOTIVO_MULTA { get; set; }
        [Description("TIPO_FISCALIZA")]
        public string TIPO_FISCALIZA { get; set; }
        //[Description("TIPO")]
        //public string TIPO { get; set; }
        [Description("DESCRIPCION_MULTA_ANTIGUO")]
        public string DESCRIPCION_MULTA_ANTIGUO { get; set; }
        [Description("APELLIDOS_NOMBRES")]
        public string APELLIDOS_NOMBRES { get; set; }
        [Description("DESCRIPCION_INFORME")]
        public string DESCRIPCION_INFORME { get; set; }

        [Description("NUMERO")]
        public string NUMERO { get; set; }
        [Description("RegEstado")]
        public int RegEstado { get; set; }
        [Description("COD_OD_REGISTRO")]
        public String COD_OD_REGISTRO { get; set; }

        [Description("BusFormulario")]
        public String BusFormulario { get; set; }
        [Description("BusCriterio")]
        public String BusCriterio { get; set; }
        [Description("BusValor")]
        public String BusValor { get; set; }
        [Description("CODIGO")]
        public String CODIGO { get; set; }
        [Description("DESCRIPCION")]
        public String DESCRIPCION { get; set; }
        [Description("COD_RESODIREC")]
        public String COD_RESODIREC { get; set; }
        [Description("COD_RESODIREC_INI_PAU")]
        public String COD_RESODIREC_INI_PAU { get; set; }

        [Description("COD_SECUENCIAL")]
        public int COD_SECUENCIAL { get; set; }

        [Category("FK"), Description("COD_ILEGAL_ENCISOS")]
        public String COD_ILEGAL_ENCISOS { get; set; }
        [Category("FK"), Description("COD_ILEGAL_ENCISOSLFFS")]
        public String COD_ILEGAL_ENCISOSLFFS { get; set; }
        [Category("FK"), Description("COD_ESPECIESMULTA")]
        public String COD_ESPECIESMULTA { get; set; }
        [Category("FK"), Description("COD_ESPECIES")]
        public String COD_ESPECIES { get; set; }
        [Category("FK"), Description("COD_INCISOMULTA")]
        public String COD_INCISOMULTA { get; set; }
        [Category("FK"), Description("COD_INCISO_OPCIONAL")]
        public String COD_INCISO_OPCIONAL { get; set; }
        [Description("AREA")]
        public decimal AREA { get; set; }
        [Description("VOLUMEN")]
        public decimal VOLUMEN { get; set; }
        [Description("NUMERO_INDIVIDUOS")]
        public int NUMERO_INDIVIDUOS { get; set; }
        [Description("DESCRIPCION_DET_DESCARGO")]
        public string DESCRIPCION_DET_DESCARGO { get; set; }
        [Description("DESCRIPCION_ARTICULOS")]
        public string DESCRIPCION_ARTICULOS { get; set; }
        [Description("DESCRIPCION_ARTICULOSLFFS")]
        public string DESCRIPCION_ARTICULOSLFFS { get; set; }
        [Description("DESCRIPCION_ENCISOS")]
        public string DESCRIPCION_ENCISOS { get; set; }
        [Description("DESCRIPCION_ENCISOSLFFS")]
        public string DESCRIPCION_ENCISOSLFFS { get; set; }
        [Description("DESCRIPCION_ESPECIE")]
        public string DESCRIPCION_ESPECIE { get; set; }
        [Description("DESCRIPCION_MULTA")]
        public string DESCRIPCION_MULTA { get; set; }

        [Description("RESOLUCION")]
        public string RESOLUCION { get; set; }
        [Description("SANCION")]
        public string SANCION { get; set; }

        [Description("PRINCIPALES_RESULTADOS")]
        public string PRINCIPALES_RESULTADOS { get; set; }

        [Description("INFORMACION_COMPLEMENTO")]
        public string INFORMACION_COMPLEMENTO { get; set; }
        [Description("REFERENCIA")]
        public string REFERENCIA { get; set; }
        [Description("CONCLUSION")]
        public string CONCLUSION { get; set; }

        [Description("COMENTARIOS")]
        public String COMENTARIOS { get; set; }

        [Description("OUTPUTPARAM01")]
        public String OUTPUTPARAM01 { get; set; }
        //[Description("OUTPUTPARAM02")]
        //public String OUTPUTPARAM02 { get; set; }
        [Description("INFORMACION_ACLARO")]
        public String INFORMACION_ACLARO { get; set; }
        [Description("DOCUMENTOS_ADJUNTOS")]
        public String DOCUMENTOS_ADJUNTOS { get; set; }

        [Description("VOLUMENMULTA")]
        public decimal VOLUMENMULTA { get; set; }
        [Description("BENEFICIOILICITO")]
        public decimal BENEFICIOILICITO { get; set; }
        [Description("PE")]
        public int PE { get; set; }
        [Description("K")]
        public decimal K { get; set; }
        [Description("ALFA")]
        public decimal ALFA { get; set; }
        [Description("R")]
        public decimal R { get; set; }
        [Description("VSUBFORMULA")]
        public decimal VSUBFORMULA { get; set; }
        [Description("F")]
        public decimal F { get; set; }
        [Description("MULTASUBTOTALSOL")]
        public decimal MULTASUBTOTALSOL { get; set; }
        [Description("MULTASUBTOTALUIT")]
        public decimal MULTASUBTOTALUIT { get; set; }
        [Description("MULTATOTALUIT")]
        public decimal MULTATOTALUIT { get; set; }
        [Description("DESCRIPCION_INCISOSMULTA")]
        public string DESCRIPCION_INCISOSMULTA { get; set; }
        [Description("DESCRIPCION_ESPECIEMULTA")]
        public string DESCRIPCION_ESPECIEMULTA { get; set; }
        [Description("DESCRIPCION_INCISOSMULTA2")]
        public string DESCRIPCION_INCISOSMULTA2 { get; set; }
        [Description("EliTABLA")]
        public string EliTABLA { get; set; }
        [Description("EliVALOR01")]
        public string EliVALOR01 { get; set; }
        [Description("EliVALOR02")]
        public int EliVALOR02 { get; set; }

        [Description("UIT_100")]
        public decimal UIT_100 { get; set; }
        [Description("UIT_500")]
        public decimal UIT_500 { get; set; }
        [Description("UIT_501")]
        public decimal UIT_501 { get; set; }
        [Description("MULTA_SUBTOT1")]
        public decimal MULTA_SUBTOT1 { get; set; }
        [Description("UIT")]
        public decimal UIT { get; set; }
        [Description("MULTA_SUBTOT2")]
        public decimal MULTA_SUBTOT2 { get; set; }
        [Description("VOLUMEN_M3")]
        public decimal VOLUMEN_M3 { get; set; }
        [Description("VOLUMEN_PT")]
        public decimal VOLUMEN_PT { get; set; }
        [Description("VCF")]
        public decimal VCF { get; set; }
        [Description("DMC")]
        public decimal DMC { get; set; }
        [Description("MULTA_CITE")]
        public decimal MULTA_CITE { get; set; }
        [Description("MULTA_SUBTOTAL3")]
        public decimal MULTA_SUBTOTAL3 { get; set; }
        [Description("MULTA_SUBTOTAL")]
        public decimal MULTA_SUBTOTAL { get; set; }
        [Description("MULTA_TOTAL_UIT")]
        public decimal MULTA_TOTAL_UIT { get; set; }

        [Description("USUARIO_REGISTRO")]
        public String USUARIO_REGISTRO { get; set; }
        [Description("USUARIO_CONTROL")]
        public String USUARIO_CONTROL { get; set; }

        [Category("LIST"), Description("ListDETERMINACIONMULTA")]
        public List<Ent_INFTEC> ListDETERMINACIONMULTA { get; set; }
        [Category("LIST"), Description("ListInformes")]
        public List<Ent_INFTEC> ListInformes { get; set; }
        [Category("LIST"), Description("Listardetdescargo")]
        public List<Ent_INFTEC> Listardetdescargo { get; set; }
        [Category("LIST"), Description("Listarlffs")]
        public List<Ent_INFTEC> Listarlffs { get; set; }
        [Category("LIST"), Description("Listarmulta")]
        public List<Ent_INFTEC> Listarmulta { get; set; }
        [Category("LIST"), Description("Listarmultaantiguo")]
        public List<Ent_INFTEC> Listarmultaantiguo { get; set; }
        [Category("LIST"), Description("ListComboEspecies")]
        public List<Ent_INFTEC> ListComboEspecies { get; set; }
        [Category("LIST"), Description("ListComboInciso")]
        public List<Ent_INFTEC> ListComboInciso { get; set; }
        [Category("LIST"), Description("ListEliTABLA")]
        public List<Ent_INFTEC> ListEliTABLA { get; set; }
        //lista nueva
        [Category("LIST"), Description("listacombo")]
        public List<Ent_INFTEC> listacombo { get; set; }
        public List<Ent_INFTEC> ListODs { get; set; }
        //variables para informes tecnicos de evalucion
        [Description("NUM_INF_ACTIV")]
        public String NUM_INF_ACTIV { get; set; }
        [Description("CONCLUCION")]
        public String CONCLUCION { get; set; }
        [Description("RECOMENDACION")]
        public String RECOMENDACION { get; set; }

        //25/09/2017
        [Description("COD_THABILITANTE")]
        public String COD_THABILITANTE { get; set; }
        [Description("NUM_POA")]
        public int NUM_POA { get; set; }
        [Description("ESPECIES")]
        public String ESPECIES { get; set; }
        [Description("COD_EESTADO")]
        public String COD_EESTADO { get; set; }
        [Description("OBSERVACION")]
        public String OBSERVACION { get; set; }
        [Description("VOLUMEN_APROBADO")]
        public decimal VOLUMEN_APROBADO { get; set; }
        [Description("VOLUMEN_MOVILIZADO")]
        public decimal VOLUMEN_MOVILIZADO { get; set; }
        [Description("VOLUMEN_INJUSTIFICADO")]
        public decimal VOLUMEN_INJUSTIFICADO { get; set; }
        [Description("VOLUMEN_JUSTIFICADO")]
        public decimal VOLUMEN_JUSTIFICADO { get; set; }
        [Description("CAMBIA_VOL_ISUPERVISION")]
        public Object CAMBIA_VOL_ISUPERVISION { get; set; }
        [Description("CAMBIA_ESTADO_ESPECIES")]
        public Object CAMBIA_ESTADO_ESPECIES { get; set; }
        [Category("LIST"), Description("ListVolumen")]
        public List<Ent_INFTEC> ListVolumen { get; set; }
        [Category("LIST"), Description("ListEMaderable")]
        public List<CapaEntidad.DOC.Ent_INFORME> ListEMaderable { get; set; }
        [Category("LIST"), Description("ListEMaderableSemillero")]
        public List<CapaEntidad.DOC.Ent_INFORME> ListEMaderableSemillero { get; set; }

        //IT Eval. Denuncias
        [Description("COD_PERSONA_DIRIGIDO")]
        public String COD_PERSONA_DIRIGIDO { get; set; }
        [Description("PERSONA_DIRIGIDO")]
        public String PERSONA_DIRIGIDO { get; set; }
        [Description("COD_TRAMITE_SITD")]
        public Int32 COD_TRAMITE_SITD { get; set; }
        [Description("NUM_DREFERECIA")]
        public String NUM_DREFERECIA { get; set; }
        [Description("MOTIVO_INVASION")]
        public Object MOTIVO_INVASION { get; set; }
        [Description("MOTIVO_CAMBIO_USO")]
        public Object MOTIVO_CAMBIO_USO { get; set; }
        [Description("MOTIVO_MINERIA_ILEGAL")]
        public Object MOTIVO_MINERIA_ILEGAL { get; set; }
        [Description("MOTIVO_TALA_ILEGAL")]
        public Object MOTIVO_TALA_ILEGAL { get; set; }
        [Description("MOTIVO_OTROS")]
        public Object MOTIVO_OTROS { get; set; }
        [Description("DESCRIPCION_MOTROS")]
        public String DESCRIPCION_MOTROS { get; set; }
        [Description("TITULAR_PAU_TRAMITE")]
        public String TITULAR_PAU_TRAMITE { get; set; }
        [Description("REQUIERE_SUPERVISION")]
        public String REQUIERE_SUPERVISION { get; set; }
        [Description("TRANSLADAR_ENTIDAD")]
        public Object TRANSLADAR_ENTIDAD { get; set; }
        [Description("DGFFS")]
        public Object DGFFS { get; set; }
        [Description("DETALLE_DGFFS")]
        public String DETALLE_DGFFS { get; set; }
        [Description("ATFFS")]
        public Object ATFFS { get; set; }
        [Description("DETALLE_ATFFS")]
        public String DETALLE_ATFFS { get; set; }
        [Description("OCI")]
        public Object OCI { get; set; }
        [Description("DETALLE_OCI")]
        public String DETALLE_OCI { get; set; }
        [Description("PROGRAMA_REGIONAL")]
        public Object PROGRAMA_REGIONAL { get; set; }
        [Description("DETALLE_PROREG")]
        public String DETALLE_PROREG { get; set; }
        [Description("MINISTERIO_PUBLICO")]
        public Object MINISTERIO_PUBLICO { get; set; }
        [Description("DETALLE_MINPUB")]
        public String DETALLE_MINPUB { get; set; }
        [Description("COLEGIO_INGENIEROS")]
        public Object COLEGIO_INGENIEROS { get; set; }
        [Description("DETALLE_COLING")]
        public String DETALLE_COLING { get; set; }
        [Description("OEFA")]
        public Object OEFA { get; set; }
        [Description("DETALLE_OEFA")]
        public String DETALLE_OEFA { get; set; }
        [Description("SUNAT")]
        public Object SUNAT { get; set; }
        [Description("DETALLE_SUNAT")]
        public String DETALLE_SUNAT { get; set; }
        [Description("SERFOR")]
        public Object SERFOR { get; set; }
        [Description("DETALLE_SERFOR")]
        public String DETALLE_SERFOR { get; set; }
        [Description("MIN_ENERGIA_MINAS")]
        public Object MIN_ENERGIA_MINAS { get; set; }
        [Description("DETALLE_MINENMIN")]
        public String DETALLE_MINENMIN { get; set; }
        [Description("OTROS")]
        public Object OTROS { get; set; }
        [Description("DETALLE_OTROS")]
        public String DETALLE_OTROS { get; set; }
        [Description("NOMBRE_POA")]
        public String NOMBRE_POA { get; set; }
        [Category("LIST"), Description("ListPManejo")]
        public List<Ent_INFTEC> ListPManejo { get; set; }

        public Ent_INFTEC()
        {
            RegEstado = -1;
            MULTA_RECOMENDADA_UIT = -1;
            MULTA_RECOMENDADA_SOLES = -1;
            AREA = -1;
            VOLUMEN = -1;
            NUMERO_INDIVIDUOS = -1;
            COD_SECUENCIAL = -1;
            VOLUMENMULTA = -1;
            BENEFICIOILICITO = -1;
            PE = -1;
            K = -1;
            ALFA = -1;
            R = -1;
            VSUBFORMULA = -1;
            F = -1;
            MULTASUBTOTALSOL = -1;
            MULTASUBTOTALUIT = -1;
            MULTATOTALUIT = -1;

            UIT_100 = -1;
            UIT_500 = -1;
            UIT_501 = -1;
            MULTA_SUBTOT1 = -1;
            UIT = -1;
            MULTA_SUBTOT2 = -1;
            VOLUMEN_M3 = -1;
            VOLUMEN_PT = -1;
            VCF = -1;
            DMC = -1;
            MULTA_CITE = -1;
            MULTA_SUBTOTAL3 = -1;
            MULTA_SUBTOTAL = -1;
            MULTA_TOTAL_UIT = -1;
            EliVALOR02 = -1;

            VOLUMEN_APROBADO = -1;
            VOLUMEN_MOVILIZADO = -1;
            VOLUMEN_INJUSTIFICADO = -1;
            VOLUMEN_JUSTIFICADO = -1;
            NUM_POA = -1;

            COD_TRAMITE_SITD = -1;
        }






        #endregion

    }
}
