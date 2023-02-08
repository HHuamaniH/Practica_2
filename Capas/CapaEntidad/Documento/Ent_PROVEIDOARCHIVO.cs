using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CapaEntidad.DOC
{
    public class Ent_PROVEIDOARCHIVO
    {
        #region "Entidades y Propiedades"
        [Description("COD_PROVEIDOARCH")]
        public String COD_PROVEIDOARCH { get; set; }
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
        [Description("DESCRIPCION")]
        public String DESCRIPCION { get; set; }
        [Description("COD_RESODIREC")]
        public String COD_RESODIREC { get; set; }
        [Description("COD_RESODIREC_INI_PAU")]
        public String COD_RESODIREC_INI_PAU { get; set; }
        [Description("COD_SECUENCIAL")]
        public int COD_SECUENCIAL { get; set; }

        [Description("D_LINEA")]
        public String D_LINEA { get; set; }
        [Description("NUM_THABILITANTE")]
        public String NUM_THABILITANTE { get; set; }
        [Description("TITULAR")]
        public String TITULAR { get; set; }
        //
        [Description("COD_ESTADO_DOC")]
        public String COD_ESTADO_DOC { get; set; }
        [Description("OBSERVACIONES_CONTROL")]
        public Object OBSERVACIONES_CONTROL { get; set; }
        [Description("OBSERV_SUBSANAR")]
        public Object OBSERV_SUBSANAR { get; set; }
        //

        [Description("NUMERO")]
        public String NUMERO { get; set; }
        [Description("TIPO_FISCALIZA")]
        public String TIPO_FISCALIZA { get; set; }

        [Description("COD_PTIPO")]
        public String COD_PTIPO { get; set; }

        [Description("COD_FUNCIONARIO")]
        public String COD_FUNCIONARIO { get; set; }

        [Description("NOMBRE_FUNCIONARIO")]
        public String NOMBRE_FUNCIONARIO { get; set; }
        [Description("CARGO")]
        public String CARGO { get; set; }

        [Description("COD_INFORME")]
        public String COD_INFORME { get; set; }
        [Description("COD_FCTIPO")]
        public String COD_FCTIPO { get; set; }
        [Description("COD_UCUENTA")]
        public String COD_UCUENTA { get; set; }
        [Description("REFERENCIA")]
        public String REFERENCIA { get; set; }
        [Description("RECOMENDACION")]
        public String RECOMENDACION { get; set; }
        [Description("OBSERVACION")]
        public String OBSERVACION { get; set; }
        [Description("RESUELVE")]
        public String RESUELVE { get; set; }
        [Description("OUTPUTPARAM01")]
        public String OUTPUTPARAM01 { get; set; }

        //CAMBIOS PROVEIDO
        [Description("DISPONE")]
        public String DISPONE { get; set; }
        [Description("NSUPERV_RECOM")]
        public Object NSUPERV_RECOM { get; set; }
        [Description("SIN_INDICIOS")]
        public Object SIN_INDICIOS { get; set; }
        [Description("EVIDENCIA_IRREG")]
        public Object EVIDENCIA_IRREG { get; set; }
        [Description("DEFICIENCIA_NOTIFICACION")]
        public Object DEFICIENCIA_NOTIFICACION { get; set; }
        [Description("DEFICIENCIA_TECNICA")]
        public Object DEFICIENCIA_TECNICA { get; set; }
        [Description("MUERTE_TITULAR")]
        public Object MUERTE_TITULAR { get; set; }
        [Description("ARCHIVO_TEMPORAL")]
        public Object ARCHIVO_TEMPORAL { get; set; }
        [Description("OTROS_TIPOS")]
        public String OTROS_TIPOS { get; set; }

        [Description("TITULAR_NOT")]
        public Object TITULAR_NOT { get; set; }
        [Description("DETALLE_TITULAR_NOT")]
        public String DETALLE_TITULAR_NOT { get; set; }
        [Description("DGFFS")]
        public Object DGFFS { get; set; }
        [Description("DETALLE_DGFFS")]
        public String DETALLE_DGFFS { get; set; }
        [Description("PROGRAMA_REGIONAL")]
        public Object PROGRAMA_REGIONAL { get; set; }
        [Description("DETALLE_PROREG")]
        public String DETALLE_PROREG { get; set; }
        [Description("MINISTERIO_PUBLICO")]
        public Object MINISTERIO_PUBLICO { get; set; }
        [Description("DETALLE_MINPUB")]
        public String DETALLE_MINPUB { get; set; }
        [Description("MIN_ENERGIA_MINAS")]
        public Object MIN_ENERGIA_MINAS { get; set; }
        [Description("DETALLE_MINENMIN")]
        public String DETALLE_MINENMIN { get; set; }
        [Description("COLEGIO_INGENIEROS")]
        public Object COLEGIO_INGENIEROS { get; set; }
        [Description("DETALLE_COLING")]
        public String DETALLE_COLING { get; set; }
        [Description("ATFFS")]
        public Object ATFFS { get; set; }
        [Description("DETALLE_ATFFS")]
        public String DETALLE_ATFFS { get; set; }
        [Description("OCI")]
        public Object OCI { get; set; }
        [Description("DETALLE_OCI")]
        public String DETALLE_OCI { get; set; }
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
        [Description("CONTABILIDAD")]
        public Object CONTABILIDAD { get; set; }
        [Description("DETALLE_CONTA")]
        public String DETALLE_CONTA { get; set; }
        [Description("TESORERIA")]
        public Object TESORERIA { get; set; }
        [Description("DETALLE_TESO")]
        public String DETALLE_TESO { get; set; }
        [Description("OTROS")]
        public Object OTROS { get; set; }
        [Description("DETALLE_OTROS")]
        public String DETALLE_OTROS { get; set; }


        [Category("FECHA"), Description("FECHA")]
        public Object FECHA { get; set; }

        [Description("RESOLDIRECTORAL")]
        public String RESOLDIRECTORAL { get; set; }
        [Description("RESOLTRIBUNAL")]
        public String RESOLTRIBUNAL { get; set; }
        [Description("RESUEL_FUNDADO")]
        public Object RESUEL_FUNDADO { get; set; }
        [Description("RESUEL_INFUNDADO")]
        public Object RESUEL_INFUNDADO { get; set; }
        [Description("RESUEL_IMPROCEDENTE")]
        public Object RESUEL_IMPROCEDENTE { get; set; }

        //Datos adicionales: 06/12/2016
        [Description("COD_RESUELVE")]
        public String COD_RESUELVE { get; set; }
        [Description("TRIBUNAL_FFS")]
        public Object TRIBUNAL_FFS { get; set; }
        [Description("DETALLE_TRIBUNAL_FFS")]
        public String DETALLE_TRIBUNAL_FFS { get; set; }

        [Description("EliTABLA")]
        public string EliTABLA { get; set; }
        [Description("EliVALOR01")]
        public string EliVALOR01 { get; set; }

        [Description("USUARIO_REGISTRO")]
        public String USUARIO_REGISTRO { get; set; }
        [Description("USUARIO_CONTROL")]
        public String USUARIO_CONTROL { get; set; }

        [Category("LIST"), Description("ListEliTABLA")]
        public List<Ent_PROVEIDOARCHIVO> ListEliTABLA { get; set; }
        [Category("LIST"), Description("ListInformes")]
        public List<Ent_PROVEIDOARCHIVO> ListInformes { get; set; }
        [Category("LIST"), Description("ListadoFuncionario")]
        public List<Ent_PROVEIDOARCHIVO> ListadoFuncionario { get; set; }
        [Category("LIST"), Description("ListMandatos")]
        public List<Ent_PROVEIDOARCHIVO> ListMandatos { get; set; }
        //21/09/2017
        [Category("LIST"), Description("ListMComboTipoFirmeza")]
        public List<Ent_PROVEIDOARCHIVO> ListMComboTipoFirmeza { get; set; }
        [Category("LIST"), Description("ListMComboTipoAgotadaVia")]
        public List<Ent_PROVEIDOARCHIVO> ListMComboTipoAgotadaVia { get; set; }
        [Description("CODIGO")]
        public String CODIGO { get; set; }
        [Description("MAE_TIP_PROVFIRMEZA")]
        public String MAE_TIP_PROVFIRMEZA { get; set; }
        [Description("MAE_TIP_AGOTAVIAADM")]
        public String MAE_TIP_AGOTAVIAADM { get; set; }
        [Description("CONFIRM_RESOL")]
        public String CONFIRM_RESOL { get; set; }
        [Description("CADUCIDAD_FIRME")]
        public Object CADUCIDAD_FIRME { get; set; }
        [Description("ART363I_FIRME")]
        public Object ART363I_FIRME { get; set; }
        [Description("MULTA_FIRME")]
        public Object MULTA_FIRME { get; set; }
        [Description("MCORRECTIVA_FIRME")]
        public Object MCORRECTIVA_FIRME { get; set; }
        //03/10/2017
        [Description("MAE_TIP_PROVARCHIVO")]
        public String MAE_TIP_PROVARCHIVO { get; set; }
        [Description("DESCRIPCION_PROVARCHIVO")]
        public String DESCRIPCION_PROVARCHIVO { get; set; }
        [Description("MAE_TIP_MEDIDAS")]
        public String MAE_TIP_MEDIDAS { get; set; }
        [Description("DESCRIPCION_MEDIDAS")]
        public String DESCRIPCION_MEDIDAS { get; set; }
        [Category("LIST"), Description("ListMComboTipoArchivo")]
        public List<Ent_PROVEIDOARCHIVO> ListMComboTipoArchivo { get; set; }
        [Category("LIST"), Description("ListMComboTipoMedidas")]
        public List<Ent_PROVEIDOARCHIVO> ListMComboTipoMedidas { get; set; }
        [Category("LIST"), Description("ListMComboEmiteConst")]
        public List<Ent_PROVEIDOARCHIVO> ListMComboEmiteConst { get; set; }

        [Category("LIST"), Description("ListODs")]
        public List<Ent_PROVEIDOARCHIVO> ListODs { get; set; }

        [Description("MAE_TIP_CONSTANCIA")]
        public String MAE_TIP_CONSTANCIA { get; set; }


        //30/10/2017 - Nuevo proveído: Declarar cumplimiento de medidas correctivas
        [Description("CUMPLE_MCORRECTIVA")]
        public Object CUMPLE_MCORRECTIVA { get; set; }
        [Description("FECHA_CUMPLE_MCORRECTIVA")]
        public Object FECHA_CUMPLE_MCORRECTIVA { get; set; }
        [Description("DISPONE_CUMPLE_MCORRECTIVA")]
        public String DISPONE_CUMPLE_MCORRECTIVA { get; set; }
        //07/12/2017
        [Category("FECHA"), Description("FECHA_FIRMEZA")]
        public Object FECHA_FIRMEZA { get; set; }
        //11/12/2017
        [Description("COD_DLINEA")]
        public String COD_DLINEA { get; set; }
        [Description("RECOMIENDA_NUEVA_SUPERV")]
        public Object RECOMIENDA_NUEVA_SUPERV { get; set; }
        [Description("INCUMPLE_DIRECTIVA_SUPERV")]
        public Object INCUMPLE_DIRECTIVA_SUPERV { get; set; }

        [Description("MED_CAUTELAR")]
        public Object MED_CAUTELAR { get; set; }
        [Description("CADUCIDAD")]
        public Object CADUCIDAD { get; set; }
        [Description("INFRACCIONES")]
        public Object INFRACCIONES { get; set; }

        [Description("PJ_PM")]
        public Object PJ_PM { get; set; }
        [Description("PJ_GTF")]
        public Object PJ_GTF { get; set; }
        [Description("PJ_TROZAS")]
        public Object PJ_TROZAS { get; set; }

        /// <summary>
        /// 04/06/2018 PROVEIDO JUDICIALIZADOS AGREGANDO COLUMNAS DETALLE
        /// CR
        /// </summary>
        ///
        [Description("NUM_EXPPJ")]
        public String NUM_EXPPJ { get; set; }
        [Description("NUM_JUZGADO")]
        public String NUM_JUZGADO { get; set; }
        [Description("FECHA_PJ")]
        public Object FECHA_PJ { get; set; }
        [Description("PLAZO_PJ")]
        public String PLAZO_PJ { get; set; }
        [Description("RESUM_PJ")]
        public String RESUM_PJ { get; set; }

        [Description("CADUCIDADPARCIAL")]
        public Object CADUCIDADPARCIAL { get; set; }
        [Description("NOTIFICA_AUTOR")]
        public String NOTIFICA_AUTOR { get; set; }
        [Description("OBSERVACIONES_TSC")]
        public String OBSERVACIONES_TSC { get; set; }
        //SITD
        [Description("DESTRAMENVIO")]
        public String DESTRAMENVIO { get; set; }
        [Description("CODTRAMITEENVIO")]
        public String CODTRAMITEENVIO { get; set; }
        [Description("CNRODOCUMENTOE")]
        public String CNRODOCUMENTOE { get; set; }
        [Description("FFECDOCUMENTOE")]
        public String FFECDOCUMENTOE { get; set; }
        [Description("CASUNTOE")]
        public String CASUNTOE { get; set; }
        [Description("PDF_ID_TRAM_ENVIO")]
        public String PDF_ID_TRAM_ENVIO { get; set; }
        [Description("COD_TRAMITE_ENVIO")]
        public int COD_TRAMITE_ENVIO { get; set; }
        //MANDATO
        [Description("ICODMANDATO")]
        public int ICODMANDATO { get; set; }

        [Description("ESMANDATO")]
        public int ESMANDATO { get; set; }

        [Description("MANDATO")]
        public String MANDATO { get; set; }

        [Description("vEnlace")]
        public String vEnlace { get; set; }

        [Description("CANTMESES")]
        public int CANTMESES { get; set; }

        [Description("CANTDIAS")]
        public int CANTDIAS { get; set; }

        [Description("DESDE")]
        public String DESDE { get; set; }

        [Description("HASTA")]
        public String HASTA { get; set; }

        [Description("ITIPO")]
        public int ITIPO { get; set; }
        
        //TGS 07.10.2022: subsanación voluntaria
        [Description("SUBSANACION_VOLUNTARIA")]
        public Object SUBSANACION_VOLUNTARIA { get; set; }
        [Description("DESCRIPCION_SUBSANACION_VOLUNTARIA")]
        public String DESCRIPCION_SUBSANACION_VOLUNTARIA { get; set; }


        #region "Constructor"
        public Ent_PROVEIDOARCHIVO()
        {
            COD_TRAMITE_ENVIO = -1;
            ICODMANDATO = -1;
            RegEstado = -1;
            COD_SECUENCIAL = -1;
            ESMANDATO = -1;
            CANTMESES = -1;
            CANTDIAS = -1;
            ITIPO = -1;
        }
        #endregion

        #endregion
    }
}
