using System;
using System.ComponentModel;

namespace CapaEntidad.DOC
{
    public class Ent_WS_OSINFOR
    {
        [Description("BusValor")]
        public String BusValor { get; set; }
        [Description("BusCriterio")]
        public String BusCriterio { get; set; }
        [Description("USUARIO_LOGIN")]
        public String USUARIO_LOGIN { get; set; }

        [Description("OD")]
        public String OD { get; set; }
        [Description("COD_THABILITANTE")]
        public String COD_THABILITANTE { get; set; }
        [Description("MODALIDAD")]
        public String MODALIDAD { get; set; }
        [Description("TITULAR")]
        public String TITULAR { get; set; }
        [Description("NUM_THABILITANTE")]
        public String NUM_THABILITANTE { get; set; }
        [Description("CADUCADO_TH")]
        public Object CADUCADO_TH { get; set; }
        [Description("DOCUMENTO")]
        public String DOCUMENTO { get; set; }

        [Description("NUM_POA")]
        public int NUM_POA { get; set; }
        [Description("NOMBRE_POA")]
        public String NOMBRE_POA { get; set; }
        [Description("ARESOLUCION_NUM")]
        public String ARESOLUCION_NUM { get; set; }
        [Description("REFORMULA_NUM")]
        public String REFORMULA_NUM { get; set; }

        [Description("COD_INFORME")]
        public String COD_INFORME { get; set; }
        [Description("NUM_INFORME")]
        public String NUM_INFORME { get; set; }
        [Category("FECHA"), Description("FECHA_SUPERVISION_INI")]
        public Object FECHA_SUPERVISION_INI { get; set; }
        [Category("FECHA"), Description("FECHA_SUPERVISION_FIN")]
        public Object FECHA_SUPERVISION_FIN { get; set; }

        [Description("NUM_RESOLUCION_INI_1")]
        public String NUM_RESOLUCION_INI_1 { get; set; }
        [Category("FECHA"), Description("FECHA_EMISION_INI_1")]
        public Object FECHA_EMISION_INI_1 { get; set; }
        [Description("MED_CAU_INI_1")]
        public Object MED_CAU_INI_1 { get; set; }
        [Description("INFRACCIONES_INI_1")]
        public String INFRACCIONES_INI_1 { get; set; }

        [Description("NUM_RESOLUCION_INI_2")]
        public String NUM_RESOLUCION_INI_2 { get; set; }
        [Category("FECHA"), Description("FECHA_EMISION_INI_2")]
        public Object FECHA_EMISION_INI_2 { get; set; }
        [Description("MED_CAU_INI_2")]
        public Object MED_CAU_INI_2 { get; set; }
        [Description("INFRACCIONES_INI_2")]
        public String INFRACCIONES_INI_2 { get; set; }

        [Description("NUM_RESOLUCION_AMP")]
        public String NUM_RESOLUCION_AMP { get; set; }
        [Category("FECHA"), Description("FECHA_EMISION_AMP")]
        public Object FECHA_EMISION_AMP { get; set; }
        [Description("INFRACCIONES_AMP")]
        public String INFRACCIONES_AMP { get; set; }
        [Description("NUM_RESOLUCION_VAIMP")]
        public String NUM_RESOLUCION_VAIMP { get; set; }
        [Category("FECHA"), Description("FECHA_EMISION_VAIMP")]
        public Object FECHA_EMISION_VAIMP { get; set; }
        [Description("INFRACCIONES_VAIMP")]
        public String INFRACCIONES_VAIMP { get; set; }

        [Description("NUM_RESOLUCION_TER_1")]
        public String NUM_RESOLUCION_TER_1 { get; set; }
        [Category("FECHA"), Description("FECHA_EMISION_TER_1")]
        public Object FECHA_EMISION_TER_1 { get; set; }
        [Description("DETER_TER_1")]
        public String DETER_TER_1 { get; set; }
        [Description("MONTO_MULTA_TER_1")]
        public Decimal MONTO_MULTA_TER_1 { get; set; }
        [Description("AMONESTACION_TER_1")]
        public Object AMONESTACION_TER_1 { get; set; }
        [Description("CADUCIDAD_TER_1")]
        public Object CADUCIDAD_TER_1 { get; set; }
        [Description("MED_PRECAU_TER_1")]
        public Object MED_PRECAU_TER_1 { get; set; }
        [Description("MED_CORREC_TER_1")]
        public Object MED_CORREC_TER_1 { get; set; }
        [Description("INFRACCIONES_TER_1")]
        public String INFRACCIONES_TER_1 { get; set; }

        [Description("NUM_RESOLUCION_TER_2")]
        public String NUM_RESOLUCION_TER_2 { get; set; }
        [Category("FECHA"), Description("FECHA_EMISION_TER_2")]
        public Object FECHA_EMISION_TER_2 { get; set; }
        [Description("DETER_TER_2")]
        public String DETER_TER_2 { get; set; }
        [Description("MONTO_MULTA_TER_2")]
        public Decimal MONTO_MULTA_TER_2 { get; set; }
        [Description("AMONESTACION_TER_2")]
        public Object AMONESTACION_TER_2 { get; set; }
        [Description("CADUCIDAD_TER_2")]
        public Object CADUCIDAD_TER_2 { get; set; }
        [Description("MED_PRECAU_TER_2")]
        public Object MED_PRECAU_TER_2 { get; set; }
        [Description("MED_CORREC_TER_2")]
        public Object MED_CORREC_TER_2 { get; set; }
        [Description("INFRACCIONES_TER_2")]
        public String INFRACCIONES_TER_2 { get; set; }

        [Description("NUM_RESOLUCION_RECONS")]
        public String NUM_RESOLUCION_RECONS { get; set; }
        [Category("FECHA"), Description("FECHA_EMISION_RECONS")]
        public Object FECHA_EMISION_RECONS { get; set; }
        [Description("DETER_RECONS")]
        public String DETER_RECONS { get; set; }
        [Description("LEV_CADUCIDAD_RECONS")]
        public Object LEV_CADUCIDAD_RECONS { get; set; }
        [Description("CAMBIO_MULTA_RECONS")]
        public Object CAMBIO_MULTA_RECONS { get; set; }
        [Description("MONTO_MULTA_RECONS")]
        public Decimal MONTO_MULTA_RECONS { get; set; }
        [Description("NUM_RESOLUCION_RECTI")]
        public String NUM_RESOLUCION_RECTI { get; set; }
        [Category("FECHA"), Description("FECHA_EMISION_RECTI")]
        public Object FECHA_EMISION_RECTI { get; set; }
        [Description("MOTIVO_RECTI")]
        public String MOTIVO_RECTI { get; set; }
        [Description("MONTO_MULTA_RECTI")]
        public Decimal MONTO_MULTA_RECTI { get; set; }

        [Description("NUM_RESOLUCION_TFFS_1")]
        public String NUM_RESOLUCION_TFFS_1 { get; set; }
        [Category("FECHA"), Description("FECHA_EMISION_TFFS_1")]
        public Object FECHA_EMISION_TFFS_1 { get; set; }
        [Description("RECURSO_TFFS_1")]
        public String RECURSO_TFFS_1 { get; set; }
        [Description("DETERMINA_TFFS_1")]
        public String DETERMINA_TFFS_1 { get; set; }
        [Description("MOTIVO_TFFS_1")]
        public String MOTIVO_TFFS_1 { get; set; }

        [Description("NUM_RESOLUCION_TFFS_2")]
        public String NUM_RESOLUCION_TFFS_2 { get; set; }
        [Category("FECHA"), Description("FECHA_EMISION_TFFS_2")]
        public Object FECHA_EMISION_TFFS_2 { get; set; }
        [Description("RECURSO_TFFS_2")]
        public String RECURSO_TFFS_2 { get; set; }
        [Description("DETERMINA_TFFS_2")]
        public String DETERMINA_TFFS_2 { get; set; }
        [Description("MOTIVO_TFFS_2")]
        public String MOTIVO_TFFS_2 { get; set; }

        [Description("ESTADO_PAU")]
        public String ESTADO_PAU { get; set; }
        [Category("FECHA"), Description("FECHA_ACTUALIZACION")]
        public Object FECHA_ACTUALIZACION { get; set; }


        /***Para datos generales del Título Habilitante***/
        [Description("NUM_PCOMPLEMENTARIO")]
        public String NUM_PCOMPLEMENTARIO { get; set; }
        [Description("AREA_POA")]
        public String AREA_POA { get; set; }
        [Description("PCA")]
        public String PCA { get; set; }
        [Description("ZAFRA_PCA")]
        public String ZAFRA_PCA { get; set; }
        [Description("INICIO_VIGENCIA")]
        public String INICIO_VIGENCIA { get; set; }
        [Description("FIN_VIGENCIA")]
        public String FIN_VIGENCIA { get; set; }
        [Description("DEPARTAMENTO")]
        public String DEPARTAMENTO { get; set; }
        [Description("PROVINCIA")]
        public String PROVINCIA { get; set; }
        [Description("DISTRITO")]
        public String DISTRITO { get; set; }
        /******/




        [Description("POA")]
        public String POA { get; set; }
        [Description("COD_ESPECIES")]
        public String COD_ESPECIES { get; set; }
        [Description("DESC_ESPECIES")]
        public String DESC_ESPECIES { get; set; }
        [Description("COD_SECUENCIAL")]
        public String COD_SECUENCIAL { get; set; }
        [Description("BLOQUE")]
        public String BLOQUE { get; set; }
        [Description("FAJA")]
        public String FAJA { get; set; }
        [Description("CODIGO")]
        public String CODIGO { get; set; }
        [Description("DAP")]
        public String DAP { get; set; }
        [Description("AC")]
        public String AC { get; set; }
        [Description("COD_ECONDICION")]
        public String COD_ECONDICION { get; set; }
        [Description("DESC_ECONDICION")]
        public String DESC_ECONDICION { get; set; }
        [Description("DESC_EESTADO")]
        public String DESC_EESTADO { get; set; }
        [Description("ZONA_UTM")]
        public String ZONA_UTM { get; set; }
        [Description("COORDENADA_ESTE")]
        public String COORDENADA_ESTE { get; set; }
        [Description("COORDENADA_NORTE")]
        public String COORDENADA_NORTE { get; set; }
        [Description("COD_ESPECIES_CAMPO")]
        public String COD_ESPECIES_CAMPO { get; set; }
        [Description("DESC_ESPECIES_CAMPO")]
        public String DESC_ESPECIES_CAMPO { get; set; }
        [Description("BLOQUE_CAMPO")]
        public String BLOQUE_CAMPO { get; set; }
        [Description("FAJA_CAMPO")]
        public String FAJA_CAMPO { get; set; }
        [Description("CODIGO_CAMPO")]
        public String CODIGO_CAMPO { get; set; }
        [Description("DAP_CAMPO")]
        public String DAP_CAMPO { get; set; }
        [Description("DAP_CAMPO1")]
        public String DAP_CAMPO1 { get; set; }
        [Description("DAP_CAMPO2")]
        public String DAP_CAMPO2 { get; set; }
        [Description("AC_CAMPO")]
        public String AC_CAMPO { get; set; }
        [Description("ZONA_UTM_CAMPO")]
        public String ZONA_UTM_CAMPO { get; set; }
        [Description("COORDENADA_ESTE_CAMPO")]
        public String COORDENADA_ESTE_CAMPO { get; set; }
        [Description("COORDENADA_NORTE_CAMPO")]
        public String COORDENADA_NORTE_CAMPO { get; set; }
        [Description("DESC_ACATEGORIA_CITE")]
        public String DESC_ACATEGORIA_CITE { get; set; }
        [Description("DESC_ACATEGORIA_DS")]
        public String DESC_ACATEGORIA_DS { get; set; }
        [Description("BS_ALTURA_TOTAL")]
        public String BS_ALTURA_TOTAL { get; set; }
        [Description("BS_DIAMETRO_RAMA_1")]
        public String BS_DIAMETRO_RAMA_1 { get; set; }
        [Description("BS_DIAMETRO_RAMA_2")]
        public String BS_DIAMETRO_RAMA_2 { get; set; }
        [Description("BS_DIAMETRO_RAMA_3")]
        public String BS_DIAMETRO_RAMA_3 { get; set; }
        [Description("BS_DIAMETRO_RAMA_4")]
        public String BS_DIAMETRO_RAMA_4 { get; set; }
        [Description("BS_DIAMETRO_RAMA_5")]
        public String BS_DIAMETRO_RAMA_5 { get; set; }
        [Description("BS_DIAMETRO_RAMA_6")]
        public String BS_DIAMETRO_RAMA_6 { get; set; }
        [Description("BS_DIAMETRO_RAMA_7")]
        public String BS_DIAMETRO_RAMA_7 { get; set; }
        [Description("BS_LONGITUD_RAMA_1")]
        public String BS_LONGITUD_RAMA_1 { get; set; }
        [Description("BS_LONGITUD_RAMA_2")]
        public String BS_LONGITUD_RAMA_2 { get; set; }
        [Description("BS_LONGITUD_RAMA_3")]
        public String BS_LONGITUD_RAMA_3 { get; set; }
        [Description("BS_LONGITUD_RAMA_4")]
        public String BS_LONGITUD_RAMA_4 { get; set; }
        [Description("BS_LONGITUD_RAMA_5")]
        public String BS_LONGITUD_RAMA_5 { get; set; }
        [Description("BS_LONGITUD_RAMA_6")]
        public String BS_LONGITUD_RAMA_6 { get; set; }
        [Description("BS_LONGITUD_RAMA_7")]
        public String BS_LONGITUD_RAMA_7 { get; set; }
        [Description("COD_EESTADO_CAMPO")]
        public String COD_EESTADO_CAMPO { get; set; }
        [Description("DESC_EESTADO_CAMPO")]
        public String DESC_EESTADO_CAMPO { get; set; }
        [Description("COD_ECONDICION_CAMPO")]
        public String COD_ECONDICION_CAMPO { get; set; }
        [Description("DESC_ECONDICION_CAMPO")]
        public String DESC_ECONDICION_CAMPO { get; set; }


        [Description("COD_RESODIREC")]
        public String COD_RESODIREC { get; set; }
        [Description("COD_INCISO")]
        public String COD_INCISO { get; set; }
        [Description("DESC_ART")]
        public String DESC_ART { get; set; }
        [Description("DESC_INCISO")]
        public String DESC_INCISO { get; set; }
        [Description("VOLUMEN")]
        public String VOLUMEN { get; set; }
        [Description("AREA")]
        public String AREA { get; set; }
        [Description("NUMERO_INDIVIDUOS")]
        public String NUMERO_INDIVIDUOS { get; set; }


        public Ent_WS_OSINFOR()
        {
            NUM_POA = -1;
            MONTO_MULTA_RECTI = -1;
            MONTO_MULTA_TER_1 = -1;
            MONTO_MULTA_TER_2 = -1;
            MONTO_MULTA_RECONS = -1;
        }
    }
}
