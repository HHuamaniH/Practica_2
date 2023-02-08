using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CapaEntidad.DOC
{
    public class Ent_ILEGAL
    {
        #region "Entidades y Propiedades"

        [Description("COD_ILEGAL")]
        public String COD_ILEGAL { get; set; }
        [Description("COD_FCTIPO")]
        public String COD_FCTIPO { get; set; }
        [Category("FK"), Description("COD_INFORME")]
        public String COD_INFORME { get; set; }

        [Description("COD_ILEGAL_INF_SUP_TIPO")]
        public String COD_ILEGAL_INF_SUP_TIPO { get; set; }
        [Description("ILEGAL_NUMERO")]
        public String ILEGAL_NUMERO { get; set; }
        [Category("FECHA"), Description("ILEGAL_FECHA_EMISION")]
        public Object ILEGAL_FECHA_EMISION { get; set; }
        [Description("PRESENTO_PROYECTO_RD")]
        public Object PRESENTO_PROYECTO_RD { get; set; }
        [Description("COD_PROFESIONAL")]
        public String COD_PROFESIONAL { get; set; }
        [Description("COD_UCUENTA")]
        public String COD_UCUENTA { get; set; }
        [Description("OBSERVACION")]
        public String OBSERVACION { get; set; }
        [Description("TIPO")]
        public string TIPO { get; set; }
        [Description("COD_SECUENCIAL")]
        public int COD_SECUENCIAL { get; set; }

        [Description("D_LINEA")]
        public String D_LINEA { get; set; }
        [Description("TITULAR")]
        public String TITULAR { get; set; }
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

        [Description("DESCRIPCION_CATEGORIA")]
        public String DESCRIPCION_CATEGORIA { get; set; }
        [Description("DESCRIPCION_CAT_TIPO")]
        public String DESCRIPCION_CAT_TIPO { get; set; }
        [Description("EVIDENCIA_IRREGULARIDAD")]
        public Object EVIDENCIA_IRREGULARIDAD { get; set; }
        [Description("BUEN_MANEJO")]
        public Object BUEN_MANEJO { get; set; }
        [Description("DEFICIENCIA_NOTIFICACION")]
        public Object DEFICIENCIA_NOTIFICACION { get; set; }
        [Description("DEFICIENCIA_TECNICA")]
        public Object DEFICIENCIA_TECNICA { get; set; }
        [Description("ARCHIVOS_OTROS")]
        public String ARCHIVOS_OTROS { get; set; }
        [Description("CODIGO")]
        public String CODIGO { get; set; }
        [Description("DESCRIPCION")]
        public String DESCRIPCION { get; set; }

        [Description("COD_ILEGAL_ARTICULOS")]
        public String COD_ILEGAL_ARTICULOS { get; set; }
        [Description("DESCRIPCION_ARTICULOS")]
        public String DESCRIPCION_ARTICULOS { get; set; }
        [Description("COD_ILEGAL_ENCISOS")]
        public String COD_ILEGAL_ENCISOS { get; set; }
        [Description("DESCRIPCION_ENCISOS")]
        public String DESCRIPCION_ENCISOS { get; set; }
        [Description("RegEstado")]
        public int RegEstado { get; set; }
        [Description("COD_OD_REGISTRO")]
        public String COD_OD_REGISTRO { get; set; }

        [Description("OUTPUTPARAM01")]
        public String OUTPUTPARAM01 { get; set; }
        //[Description("OUTPUTPARAM02")]
        //public String OUTPUTPARAM02 { get; set; }

        //ILEGAL_EVA_INSTRUCTIVA
        [Description("INSPECCION_OCULAR")]
        public object INSPECCION_OCULAR { get; set; }
        [Description("EMITIR_RD_FINAL")]
        public object EMITIR_RD_FINAL { get; set; }
        [Description("CADUCIDAD")]
        public object CADUCIDAD { get; set; }
        [Description("AMPLIACION_PAU")]
        public object AMPLIACION_PAU { get; set; }
        [Description("ACUMULACION_PAU")]
        public object ACUMULACION_PAU { get; set; }
        [Description("MEDIDAS_CORRECTIVAS")]
        public object MEDIDAS_CORRECTIVAS { get; set; }
        [Description("NUEVA_SUPERVISION")]
        public object NUEVA_SUPERVISION { get; set; }
        [Description("OTROS_EVA_INSTRUCTIVA")]
        public string OTROS_EVA_INSTRUCTIVA { get; set; }
        //CONFORMIDAD
        [Description("CONFORME")]
        public object CONFORME { get; set; }
        [Description("OBESERVACIONES")]
        public String OBESERVACIONES { get; set; }
        //Evaluación recurso de reconsideración
        [Description("MEDIDA_CAUTELAR")]
        public object MEDIDA_CAUTELAR { get; set; }
        [Description("FIN_PAU")]
        public object FIN_PAU { get; set; }
        [Description("IMPROCEDENTE")]
        public object IMPROCEDENTE { get; set; }
        [Description("FUNDADA")]
        public object FUNDADA { get; set; }
        [Description("FUNDADA_PARTE")]
        public object FUNDADA_PARTE { get; set; }
        [Description("INFUNDADA")]
        public object INFUNDADA { get; set; }
        [Description("PRUEBAS_PRESENTADAS")]
        public string PRUEBAS_PRESENTADAS { get; set; }
        //otros
        [Description("MOTIVO")]
        public String MOTIVO { get; set; }
        [Description("RECOMENDACION")]
        public String RECOMENDACION { get; set; }

        [Description("BusFormulario")]
        public String BusFormulario { get; set; }
        [Description("BusCriterio")]
        public String BusCriterio { get; set; }
        [Description("BusValor")]
        public String BusValor { get; set; }

        [Description("NUMERO")]
        public String NUMERO { get; set; }

        [Description("NUM_THABILITANTE")]
        public String NUM_THABILITANTE { get; set; }

        [Description("COD_RESODIREC_INI_PAU")]
        public String COD_RESODIREC_INI_PAU { get; set; }
        [Description("COD_RESODIREC")]
        public String COD_RESODIREC { get; set; }

        [Description("TIPO_FISCALIZA")]
        public String TIPO_FISCALIZA { get; set; }
        [Description("APELLIDOS_NOMBRES")]
        public String APELLIDOS_NOMBRES { get; set; }

        [Description("NUMERO_EXPEDIENTE")]
        public String NUMERO_EXPEDIENTE { get; set; }

        [Description("DESCRIPCION_EVA_INF")]
        public String DESCRIPCION_EVA_INF { get; set; }

        [Description("EliTABLA")]
        public String EliTABLA { get; set; }
        [Description("EliVALOR01")]
        public String EliVALOR01 { get; set; }
        [Description("EliVALOR02")]
        public String EliVALOR02 { get; set; }

        [Description("NUEVA_NOTIFICACION")]
        public object NUEVA_NOTIFICACION { get; set; }
        [Description("VARIAR_MED_CAUT")]
        public String VARIAR_MED_CAUT { get; set; }
        [Description("RECTIFICACION_EMATERIAL")]
        public object RECTIFICACION_EMATERIAL { get; set; }

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

        //muerte titular
        [Description("MUERTE_TITULAR")]
        public Object MUERTE_TITULAR { get; set; }

        //Recomendaciones
        [Description("NSUPERV_RECOM")]
        public Object NSUPERV_RECOM { get; set; }

        //Evaluación informe de supervisión nuevos campos
        [Description("MCORRECTIVA")]
        public Object MCORRECTIVA { get; set; }

        [Description("DESCRIPCION_MCORRECTIVA")]
        public String DESCRIPCION_MCORRECTIVA { get; set; }
        [Description("DIA_IMPLEMENT_MCORRECTIVA")]
        public Int32 DIA_IMPLEMENT_MCORRECTIVA { get; set; }
        [Description("MES_IMPLEMENT_MCORRECTIVA")]
        public Int32 MES_IMPLEMENT_MCORRECTIVA { get; set; }
        [Description("ANIO_IMPLEMENT_MCORRECTIVA")]
        public Int32 ANIO_IMPLEMENT_MCORRECTIVA { get; set; }
        [Description("DIA_INFORME_MCORRECTIVA")]
        public Int32 DIA_INFORME_MCORRECTIVA { get; set; }
        [Description("MES_INFORME_MCORRECTIVA")]
        public Int32 MES_INFORME_MCORRECTIVA { get; set; }
        [Description("ANIO_INFORME_MCORRECTIVA")]
        public Int32 ANIO_INFORME_MCORRECTIVA { get; set; }
        [Description("MANDATO")]
        public object MANDATO { get; set; }
        [Description("DESCRIPCION_MANDATO")]
        public String DESCRIPCION_MANDATO { get; set; }
        [Description("DESCRIPCION_ESPECIE")]
        public string DESCRIPCION_ESPECIE { get; set; }
        [Description("VOLUMEN")]
        public decimal VOLUMEN { get; set; }
        [Description("NUMERO_INDIVIDUOS")]
        public int NUMERO_INDIVIDUOS { get; set; }

        [Category("LIST"), Description("ListEspeciesMCorrectiva")]
        public List<Ent_ILEGAL> ListEspeciesMCorrectiva { get; set; }

        //modificaciones formulario de informe legal
        [Description("SANCION")]
        public object SANCION { get; set; }
        [Description("AMONESTACIONES")]
        public object AMONESTACIONES { get; set; }
        [Description("ARCHIVO")]
        public object ARCHIVO { get; set; }
        [Description("MEDIDA_PREVISORIA_OBS")]
        public String MEDIDA_PREVISORIA_OBS { get; set; }
        [Description("MEDIDA_PREVISORIA")]
        public object MEDIDA_PREVISORIA { get; set; }
        [Description("PROCEDENTE")]
        public object PROCEDENTE { get; set; }
        [Description("INFUNDADO_OBS")]
        public object INFUNDADO_OBS { get; set; }
        [Description("FUERA_PLAZO")]
        public object FUERA_PLAZO { get; set; }
        [Description("FALTA_PRUEBAS")]
        public object FALTA_PRUEBAS { get; set; }

        [Description("COD_ESPECIES")]
        public String COD_ESPECIES { get; set; }

        [Description("INFDIR")]
        public object INFDIR { get; set; }
        [Description("INFSUBDIR")]
        public object INFSUBDIR { get; set; }

        [Description("USUARIO_REGISTRO")]
        public String USUARIO_REGISTRO { get; set; }
        [Description("USUARIO_CONTROL")]
        public String USUARIO_CONTROL { get; set; }

        //medida cautelar antes del inicio PAU CAR 08/08/2018
        [Description("COD_ILEGAL_IALERTA_DETALLE")]
        public String COD_ILEGAL_IALERTA_DETALLE { get; set; }
        [Description("GTF")]
        public object GTF { get; set; }
        [Description("LIST_TROZAS")]
        public object LIST_TROZAS { get; set; }
        [Description("PLAN_MANEJO")]
        public object PLAN_MANEJO { get; set; }

        [Description("POA2")]
        public object POA2 { get; set; }

        [Description("ESPECIES")]
        public object ESPECIES { get; set; }
        [Description("COD_INFORME_ALERTA")]
        public String COD_INFORME_ALERTA { get; set; }

        [Description("RECOMENDACION_IA")]
        public String RECOMENDACION_IA { get; set; }

        [Category("LIST"), Description("ListMComboCategoria")]
        public List<Ent_ILEGAL> ListMComboCategoria { get; set; }
        [Category("LIST"), Description("ListMComboDIdentidad")]
        public List<Ent_ILEGAL> ListMComboDIdentidad { get; set; }

        [Category("LIST"), Description("ListMComboEspecieForestal")]
        public List<Ent_ILEGAL> ListMComboEspecieForestal { get; set; }

        [Category("LIST"), Description("ListEliTABLA")]
        public List<Ent_ILEGAL> ListEliTABLA { get; set; }

        [Category("LIST"), Description("ListInformesTemp")]
        public List<Ent_INFORME_CONSULTA_LEGAL> ListInformesTemp { get; set; }

        [Category("LIST"), Description("ListIncisos")]
        public List<Ent_ILEGAL> ListIncisos { get; set; }
        [Category("LIST"), Description("ListPOAs")]
        public List<Ent_ILEGAL> ListPOAs { get; set; }
        [Category("LIST"), Description("ListTiposRecom")]
        public List<Ent_ILEGAL> ListTiposRecom { get; set; }

        [Category("LIST"), Description("ListTiposRecom")]
        public List<Ent_ILEGAL> ListEspecies { get; set; }
        [Category("LIST"), Description("ListTiposRecom")]
        public List<Ent_ILEGAL> ListMedCautAPAU { get; set; }

        [Description("v_COD_ILEGAL")]
        public String v_COD_ILEGAL { get; set; }

        //para la paginacion
        [Description("v_Orden_Categoria")]
        public Int32 v_Orden_Categoria { get; set; }

        [Description("v_currentpage")]
        public Int32 v_currentpage { get; set; }

        [Description("v_pagesize")]
        public Int32 v_pagesize { get; set; }

        [Description("v_ROW_INDEX")]
        public Int32 v_ROW_INDEX { get; set; }

        //nuevas variables CARR 27/08/2020
        //Información Falsa - Inexistencia de Especies
        [Description("IF_INEXESP")]
        public Object IF_INEXESP { get; set; }
        //Información Falsa - Diferencia de Especies
        [Description("IF_DIFESP")]
        public Object IF_DIFESP { get; set; }
        //Información Falsa - Sobreestimación de Volumen
        [Description("IF_SOBREVOL")]
        public Object IF_SOBREVOL { get; set; }

        //Incorporación para acciones de final de instrucción 20/09/2022 TGS
        [Description("TIPO_DOCUMENTO")]
        public String TIPO_DOCUMENTO { get; set; }
        [Description("PDF_DOCUMENTO")]
        public String PDF_DOCUMENTO { get; set; }
        [Description("COD_ILACCION")]
        public String COD_ILACCION { get; set; }
        [Description("SUBTIPO")]
        public String SUBTIPO { get; set; }
        [Description("COD_TERCERO_SOLIDARIO")]
        public String COD_TERCERO_SOLIDARIO { get; set; }
        [Description("TERCERO_SOLIDARIO")]
        public String TERCERO_SOLIDARIO { get; set; }
        [Description("COD_ILEGAL_SUBSANADA")]
        public string COD_ILEGAL_SUBSANADA { get; set; }
        [Description("COD_ENCISOS")]
        public string COD_ENCISOS { get; set; }
        [Description("ARTICULO")]
        public string ARTICULO { get; set; }
        [Description("INCISO")]
        public string INCISO { get; set; }
        [Description("ESTADO")]
        public int ESTADO { get; set; }
        [Category("LIST"), Description("ListIncisosSubsanados")]
        public List<Ent_ILEGAL> ListIncisosSubsanados { get; set; }
        [Category("LIST"), Description("ListEliTABLAIncisosSubsanados")]
        public List<Ent_ILEGAL> ListEliTABLAIncisosSubsanados { get; set; }

        public List<Ent_ILEGAL> listSTD01 { get; set; }
        public List<Ent_ILEGAL> listSTD02 { get; set; }
        public List<Ent_ILEGAL> listEliTSTD01 { get; set; }
       

        #endregion
        #region "Constructor"
        public Ent_ILEGAL()
        {
            RegEstado = -1;
            COD_SECUENCIAL = -1;
            NUM_POA_REPORT = -1;

            DIA_IMPLEMENT_MCORRECTIVA = -1;
            DIA_INFORME_MCORRECTIVA = -1;
            MES_IMPLEMENT_MCORRECTIVA = -1;
            MES_INFORME_MCORRECTIVA = -1;
            ANIO_IMPLEMENT_MCORRECTIVA = -1;
            ANIO_INFORME_MCORRECTIVA = -1;
            VOLUMEN = -1;
            NUMERO_INDIVIDUOS = -1;

            //para la paginacion
            v_Orden_Categoria = -1;
            v_currentpage = -1;
            v_pagesize = -1;
            v_ROW_INDEX = -1;
            ESTADO = -1;
        }
        #endregion
    }

    public class Ent_ILEGAL_CONSULTA
    {
        public string COD_ILEGAL { get; set; }
        public string NUM_ILEGAL { get; set; }
        public string DLINEA { get; set; }
        public string NUM_THABILITANTE { get; set; }
        public string TITULAR { get; set; }
        public int RegEstado { get; set; }

        public Int32 Orden_Categoria { get; set; }
        public Int32 currentpage { get; set; }
        public Int32 pagesize { get; set; }
        public Int32 ROW_INDEX { get; set; }

        public Ent_ILEGAL_CONSULTA()
        {
            Orden_Categoria = -1;
            currentpage = -1;
            pagesize = -1;
            ROW_INDEX = -1;
        }
    }
}
