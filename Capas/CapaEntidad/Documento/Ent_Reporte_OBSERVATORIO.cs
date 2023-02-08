using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CapaEntidad.DOC
{
    public class Ent_Reporte_OBSERVATORIO
    {

        [Description("ID_REGISTRO")]
        public Int32 ID_REGISTRO { get; set; }
        [Description("TITULAR")]
        public String TITULAR { get; set; }
        [Description("TITULAR_BUSQUEDA")]
        public String TITULAR_BUSQUEDA { get; set; }
        [Description("NUM_THABILITANTE")]
        public String NUM_THABILITANTE { get; set; }
        [Description("RUC")]
        public String RUC { get; set; }
        [Description("COD_MTIPO")]
        public String COD_MTIPO { get; set; }
        [Description("MODALIDAD")]
        public String MODALIDAD { get; set; }
        [Description("UBICACION")]
        public String UBICACION { get; set; }
        [Description("REGION")]
        public String REGION { get; set; }
        [Description("PROVINCIA")]
        public String PROVINCIA { get; set; }
        [Description("DISTRITO")]
        public String DISTRITO { get; set; }
        [Description("NUM_POA")]
        public String NUM_POA { get; set; }
        [Description("PLAN_MANEJO_TOP")]
        public String PLAN_MANEJO_TOP { get; set; }
        [Description("VOLUMEN")]
        public Decimal VOLUMEN { get; set; }
        [Description("RES_APROBACION_POA")]
        public String RES_APROBACION_POA { get; set; }
        [Description("RES_REFORMULA_POA")]
        public String RES_REFORMULA_POA { get; set; }
        [Description("VIGENCIA")]
        public String VIGENCIA { get; set; }
        [Description("FIN_VIGENCIA")]
        public String FIN_VIGENCIA { get; set; }
        [Description("ZAFRA")]
        public String ZAFRA { get; set; }
        [Description("COLOR")]
        public String COLOR { get; set; }
        [Description("TRAZA")]
        public String TRAZA { get; set; }

        [Description("INF_FALSA")]
        public String INF_FALSA { get; set; }
        [Description("ARBOLES_INEX")]
        public String ARBOLES_INEX { get; set; }

        [Description("CAMBIO_USO")]
        public String CAMBIO_USO { get; set; }
        [Description("AREA_CAMBIO_USO")]
        public Decimal AREA_CAMBIO_USO { get; set; }
        [Description("ESTADO")]
        public String ESTADO { get; set; }
        [Description("DESCRIPCION_ESTADO")]
        public String DESCRIPCION_ESTADO { get; set; }
        //
        [Description("COD_RESODIREC")]
        public String COD_RESODIREC { get; set; }
        [Description("NUM_RESOLUCION")]
        public String NUM_RESOLUCION { get; set; }
        [Description("TIPO_RESOLUCION")]
        public String TIPO_RESOLUCION { get; set; }
        [Description("MEDIDA_CAUTELAR")]
        public Object MEDIDA_CAUTELAR { get; set; }
        [Description("MEDIDA_PRECAUTORIA")]
        public Object MEDIDA_PRECAUTORIA { get; set; }
        [Description("CADUCIDAD")]
        public Object CADUCIDAD { get; set; }
        [Description("CADUCADO")]
        public String CADUCADO { get; set; }
        [Description("MONTO")]
        public Decimal MONTO { get; set; }
        [Description("MULTA")]
        public Decimal MULTA { get; set; }
        [Description("LITERAL")]
        public String LITERAL { get; set; }
        //---------------------------------------------
        [Description("SENTIDO_RES")]
        public String SENTIDO_RES { get; set; }
        [Description("RESOL_DET")]
        public String RESOL_DET { get; set; } 
        [Description("RESOL_DET2")]
        public String RESOL_DET2 { get; set; }
        [Description("CHKCONFIRMAR")]
        public Int32 CHKCONFIRMAR { get; set; }
        [Description("RADREVOCAR")]
        public String RADREVOCAR { get; set; }
        [Description("CHKREVOCARPARTE")]
        public Int32 CHKREVOCARPARTE { get; set; }
        [Description("CHKRETROTRAER")]
        public Int32 CHKRETROTRAER { get; set; }
        [Description("RADRETROTRAER")]
        public String RADRETROTRAER { get; set; }
        [Description("CHKREVOCAR")]
        public Int32 CHKREVOCAR { get; set; }     
        [Description("CHKPRESCRIBIR")]
        public Int32 CHKPRESCRIBIR { get; set; }
        [Description("CHKARCHIVAR")]
        public Int32 CHKARCHIVAR { get; set; }
        [Description("CHKNULIDAD")]
        public Int32 CHKNULIDAD { get; set; }
        [Description("RADNULIDAD")]
        public String RADNULIDAD { get; set; }
        [Description("CHKLEVANTAR")]
        public Int32 CHKLEVANTAR { get; set; }
        [Description("CHKCARECE")]
        public Int32 CHKCARECE { get; set; }
        [Description("CHKOTRO")]
        public Int32 CHKOTRO { get; set; }
        [Description("CHKCONFIRMAR2")]
        public Int32 CHKCONFIRMAR2 { get; set; }
        [Description("CHKREVOCAR2")]
        public Int32 CHKREVOCAR2 { get; set; }
        [Description("RADREVOCAR2")]
        public String RADREVOCAR2 { get; set; }
        [Description("CHKREVOCARPARTE2")]
        public Int32 CHKREVOCARPARTE2 { get; set; }
        [Description("CHKRETROTRAER2")]
        public Int32 CHKRETROTRAER2 { get; set; }
       
        [Description("RADRETROTRAER2")]
        public String RADRETROTRAER2 { get; set; }
        [Description("CHKPRESCRIBIR2")]
        public Int32 CHKPRESCRIBIR2 { get; set; }
        [Description("CHKARCHIVAR2")]
        public Int32 CHKARCHIVAR2 { get; set; }
        [Description("CHKNULIDAD2")]
        public Int32 CHKNULIDAD2 { get; set; }
        [Description("RADNULIDAD2")]
        public String RADNULIDAD2 { get; set; }
        [Description("CHKLEVANTAR2")]
        public Int32 CHKLEVANTAR2 { get; set; }
        [Description("CHKCARECE2")]
        public Int32 CHKCARECE2 { get; set; }
        [Description("CHKOTRO2")]
        public Int32 CHKOTRO2 { get; set; }
        [Description("RESOL_DET3")]
        public String RESOL_DET3 { get; set; }
        [Description("DETERMINA_RETROTRAER")]
        public String DETERMINA_RETROTRAER { get; set; }
        [Description("RETRO_VALOR1")]
        public String RETRO_VALOR1 { get; set; }
        [Description("DETERMINA_RETROTRAER2")]
        public String DETERMINA_RETROTRAER2 { get; set; }
        [Description("RETRO_VALOR2")]
        public String RETRO_VALOR2 { get; set; }
        [Description("RADREVOCARPARTE")]
        public String RADREVOCARPARTE { get; set; }
        [Description("RADREVOCARPARTE2")]
        public String RADREVOCARPARTE2 { get; set; }

        //---------------------------------------------
        //
        [Description("IMPROCEDENTE")]
        public Object IMPROCEDENTE { get; set; }
        [Description("FUNDADA")]
        public Object FUNDADA { get; set; }
        [Description("FUNDADA_PARTE")]
        public Object FUNDADA_PARTE { get; set; }
        [Description("INFUNDADA")]
        public Object INFUNDADA { get; set; }

        [Description("DESISTIMIENTO")]
        public Object DESISTIMIENTO { get; set; }
        [Description("INADMISIBLE")]
        public Object INADMISIBLE { get; set; }
        [Description("NULIDAD")]
        public Object NULIDAD { get; set; }
        [Description("REVOCAR")]
        public Object REVOCAR { get; set; }
        [Description("SUSPENSION")]
        public Object SUSPENSION { get; set; }

        [Description("LEVANTAR_CADUCIDAD")]
        public Object LEVANTAR_CADUCIDAD { get; set; }
        [Description("CAMBIO_MULTA")]
        public Object CAMBIO_MULTA { get; set; }
        [Description("DETERMINACION")]
        public String DETERMINACION { get; set; }


        [Description("INCISO")]
        public String INCISO { get; set; }
        [Description("DESC_ESPECIES")]
        public String DESC_ESPECIES { get; set; }        //
        [Description("TIPO_REPORTE")]
        public String TIPO_REPORTE { get; set; }        //
        [Description("PARAMETRO")]
        public String PARAMETRO { get; set; }
        [Description("FECHA")]
        public String FECHA { get; set; }

        [Description("FECHA_INICIO_TH")]
        public String FECHA_INICIO_TH { get; set; }
        [Description("FECHA_TERMINO_TH")]
        public String FECHA_TERMINO_TH { get; set; }

        [Description("NUM_INFORME")]
        public String NUM_INFORME { get; set; }
        [Description("FECHA_SUPERVISION_INICIO")]
        public String FECHA_SUPERVISION_INICIO { get; set; }
        [Description("FECHA_SUPERVISION_TERMINO")]
        public String FECHA_SUPERVISION_TERMINO { get; set; }
        [Description("ANIO_REFERENCIA")]
        public Int32 ANIO_REFERENCIA { get; set; }

        [Description("NUM_ARBOLES_INEX")]
        public Int32 NUM_ARBOLES_INEX { get; set; }

        [Description("COD_INFORME")]
        public String COD_INFORME { get; set; }
        [Description("COD_ENCIENTIFICO")]
        public String COD_ENCIENTIFICO { get; set; }
        [Description("NOM_CIENTIFICO")]
        public String NOM_CIENTIFICO { get; set; }
        [Description("NOMBRE_COMUN")]
        public String NOMBRE_COMUN { get; set; }
        [Description("OBSERVACION")]
        public String OBSERVACION { get; set; }

        //[Description("NIVEL_RIESGO")]
        //public String NIVEL_RIESGO { get; set; }
        //[Description("DES_NIVEL_RIESGO")]
        //public String DES_NIVEL_RIESGO { get; set; }
        //[Description("TIPO_RIESGO")]
        //public String TIPO_RIESGO { get; set; }
        //[Description("DES_TIPO_RIESGO")]
        //public String DES_TIPO_RIESGO { get; set; }
        //[Description("OBSERVACION_RIESGO")]
        //public String OBSERVACION_RIESGO { get; set; }
        [Description("FECHA_INGRESO")]
        public String FECHA_INGRESO { get; set; }

        [Description("PORCENT_BEXT")]
        public String PORCENT_BEXT { get; set; }
        [Description("PORCENT_AUT")]
        public String PORCENT_AUT { get; set; }
        [Description("PORCENT_INEX")]
        public String PORCENT_INEX { get; set; }
        [Description("PORCENT_INJUS_VOL")]
        public String PORCENT_INJUS_VOL { get; set; }
        [Description("VOL_INJUS")]
        public String VOL_INJUS { get; set; }

        [Description("COD_ITIPO")]
        public String COD_ITIPO { get; set; }
        [Description("COD_THABILITANTE")]
        public String COD_THABILITANTE { get; set; }
        [Description("NUM_POA_INT")]
        public Int32 NUM_POA_INT { get; set; }

        [Description("VOLUMEN_BEXT")]
        public Decimal VOLUMEN_BEXT { get; set; }
        [Description("VOLUMEN_AUT")]
        public Decimal VOLUMEN_AUT { get; set; }
        [Description("VOLUMEN_DECLARADO")]
        public Decimal VOLUMEN_DECLARADO { get; set; }
        [Description("VOLUMEN_VERIFICADO")]
        public Decimal VOLUMEN_VERIFICADO { get; set; }


        [Description("NUM_ARB_MUESTRA")]
        public Int32 NUM_ARB_MUESTRA { get; set; }
        [Description("NUM_ARB_INEX")]
        public Int32 NUM_ARB_INEX { get; set; }
        [Description("NUM_ARB_EXIST")]
        public Int32 NUM_ARB_EXIST { get; set; }

        [Description("FECHA_BEXT")]
        public String FECHA_BEXT { get; set; }

        [Description("INFRACCIONES")]
        public String INFRACCIONES { get; set; }
        [Description("TEXTO")]
        public String TEXTO { get; set; }

        [Description("RD_MOSTRAR_INCISOS")]
        public Object RD_MOSTRAR_INCISOS { get; set; }

        [Description("TEXTO_CADUCA")]
        public String TEXTO_CADUCA { get; set; }

        [Description("URL_RESOLUCION")]
        public String URL_RESOLUCION { get; set; }
        [Description("CONSULTOR")]
        public String CONSULTOR { get; set; }
        [Description("REGENTE_IMPLEMENTA")]
        public String REGENTE_IMPLEMENTA { get; set; }

        [Description("ES_ALERTA_OSINFOR")]
        public String ES_ALERTA_OSINFOR { get; set; }
        [Description("TIPO_SUPERVISION")]
        public String TIPO_SUPERVISION { get; set; }
        [Description("TIPO_MEDIDA")]
        public String TIPO_MEDIDA { get; set; }
        [Description("NUM_RESOLUCION_DERICTORAL")]
        public String NUM_RESOLUCION_DERICTORAL { get; set; }

        [Description("PERDIDA_COBERTURA")]
        public Decimal PERDIDA_COBERTURA { get; set; }
        [Description("APROV_NO_AUTORIZADO")]
        public Decimal APROV_NO_AUTORIZADO { get; set; }
        [Description("SIGNIFICANCIA")]
        public Int32 SIGNIFICANCIA { get; set; }
        [Description("IRREPARABILIDAD")]
        public Int32 IRREPARABILIDAD { get; set; }

        [Description("VALOR_IMPACTO")]
        public Int32 VALOR_IMPACTO { get; set; }
        [Description("VALOR_PROBABILIDAD_1")]
        public Int32 VALOR_PROBABILIDAD_1 { get; set; }
        [Description("VALOR_PROBABILIDAD_2")]
        public Int32 VALOR_PROBABILIDAD_2 { get; set; }
        [Description("VALOR_PROBABILIDAD_3")]
        public Int32 VALOR_PROBABILIDAD_3 { get; set; }
        [Description("RESULTADO")]
        public Int32 RESULTADO { get; set; }
        [Description("CANT_ESP_VOL_INJUS")]
        public Int32 CANT_ESP_VOL_INJUS { get; set; }
        [Description("CANT_ESP_SUPER")]
        public Int32 CANT_ESP_SUPER { get; set; }


        [Category("LIST"), Description("List_Resumen_ROJO")]
        public List<Ent_Reporte_OBSERVATORIO> List_Resumen_ROJO { get; set; }
        [Category("LIST"), Description("List_Resumen_AMBAR")]
        public List<Ent_Reporte_OBSERVATORIO> List_Resumen_AMBAR { get; set; }
        [Category("LIST"), Description("List_Resumen_VERDE")]
        public List<Ent_Reporte_OBSERVATORIO> List_Resumen_VERDE { get; set; }
        //[Category("LIST"), Description("List_Injus_Inf")]
        //public List<Ent_Reporte_OBSERVATORIO> List_Injus_Inf { get; set; }
        [Category("LIST"), Description("List_Resoluciones")]
        public List<Ent_Reporte_OBSERVATORIO> List_Resoluciones { get; set; }
        [Category("LIST"), Description("List_Detalle_Titular")]
        public List<Ent_Reporte_OBSERVATORIO> List_Detalle_Titular { get; set; }


        [Description("BusValor")]
        public String BusValor { get; set; }
        [Description("ESTADO_TH")]
        public String ESTADO_TH { get; set; }
        [Description("NUM_RDINICIO")]
        public String NUM_RDINICIO { get; set; }
        [Description("NUM_RDTERMINO")]
        public String NUM_RDTERMINO { get; set; }

        [Description("ARCH_EVI_IRREG")]
        public Object ARCH_EVI_IRREG { get; set; }
        [Description("NUMERO_RESOLUCION_ALERTA")]
        public Object NUMERO_RESOLUCION_ALERTA { get; set; }

        //ALERTAS
        [Description("ALERTA")]
        public String ALERTA { get; set; }
        [Description("FECHA_ENVIO_ALERTA")]
        public Object FECHA_ENVIO_ALERTA { get; set; }
        [Description("NUM_RESOLUCION_ANT_PAU")]
        public String NUM_RESOLUCION_ANT_PAU { get; set; }
        [Description("NUMERO_ALERTA")]
        public String NUMERO_ALERTA { get; set; }
        [Description("VOLUMEN_ALERTA")]
        public Decimal VOLUMEN_ALERTA { get; set; }

        [Description("PC")]
        public String PC { get; set; }
        public Ent_Reporte_OBSERVATORIO()
        {
            VOLUMEN = -1;
            ID_REGISTRO = -1;
            AREA_CAMBIO_USO = -1;
            NUM_ARBOLES_INEX = -1;
            NUM_ARB_EXIST = -1;

            NUM_POA_INT = -1;
            VOLUMEN_BEXT = -1;
            VOLUMEN_AUT = -1;
            VOLUMEN_ALERTA = -1;
            VOLUMEN_VERIFICADO = -1;
            VOLUMEN_DECLARADO = -1;
            NUM_ARB_MUESTRA = -1;
            NUM_ARB_INEX = -1;
            MONTO = -1;

            VALOR_IMPACTO = -1;
            VALOR_PROBABILIDAD_1 = -1;
            VALOR_PROBABILIDAD_2 = -1;
            VALOR_PROBABILIDAD_3 = -1;
            RESULTADO = -1;

            CANT_ESP_VOL_INJUS = -1;
            CANT_ESP_SUPER = -1;

            ANIO_REFERENCIA = -1;
            PERDIDA_COBERTURA = -1;
            APROV_NO_AUTORIZADO = -1;
            SIGNIFICANCIA = -1;
            IRREPARABILIDAD = -1;

            CHKCONFIRMAR = -1;
            CHKREVOCAR = -1;
            CHKREVOCARPARTE = -1;
            CHKRETROTRAER = -1;
            CHKPRESCRIBIR = -1;
            CHKARCHIVAR = -1;
            CHKNULIDAD = -1;
            CHKLEVANTAR = -1;
            CHKCARECE = -1;
            CHKOTRO = -1;
            CHKCONFIRMAR2 = -1;
            CHKREVOCAR2 = -1;
            CHKREVOCARPARTE2 = -1;
            CHKRETROTRAER2 = -1;
            CHKPRESCRIBIR2 = -1;
            CHKARCHIVAR2 = -1;
            CHKNULIDAD2 = -1;
            CHKLEVANTAR2 = -1;
            CHKCARECE2 = -1;
            CHKOTRO2 = -1;
            MULTA = -1;
        }
    }
}
