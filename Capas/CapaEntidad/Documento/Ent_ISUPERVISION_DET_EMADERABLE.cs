using System;
using System.ComponentModel;
//using CSUPERVISION_NMRAMA = CapaEntidad.DOC.Ent_ISUPERVION_DET_EMADERABLE_BS_RAMA;
namespace CapaEntidad.DOC
{
    public class Ent_ISUPERVISION_DET_EMADERABLE
    {
        #region "Entidades y Propiedades"
        [Category("OUTPUT"), Description("OUTPUTPARAM01")]
        public Object OUTPUTPARAM01 { get; set; }

        [Description("COD_THABILITANTE")]
        public String COD_THABILITANTE { get; set; }

        [Description("COD_CNOTIFICACION")]
        public String COD_CNOTIFICACION { get; set; }
        [Description("COD_FISNOTI")]
        public String COD_FISNOTI { get; set; }

        [Description("POA")]
        public String POA { get; set; }

        [Description("NUM_POA")]
        public Int32 NUM_POA { get; set; }

        [Description("COD_ESPECIES")]
        public String COD_ESPECIES { get; set; }

        [Description("COD_ENCIENTIFICO")]
        public String COD_ENCIENTIFICO { get; set; }

        [Description("NOMBRE_CIENTIFICO")]
        public String NOMBRE_CIENTIFICO { get; set; }

        [Description("NOMBRE_COMUN")]
        public String NOMBRE_COMUN { get; set; }

        [Description("COD_INFORME")]
        public String COD_INFORME { get; set; }

        [Description("COD_ESPECIES_CAMPO")]
        public String COD_ESPECIES_CAMPO { get; set; }

        [Description("DESC_ESPECIES")]
        public String DESC_ESPECIES { get; set; }

        [Description("DESC_ESPECIES_2")]
        public String DESC_ESPECIES_2 { get; set; }

        [Description("COD_SECUENCIAL")]
        public Int32 COD_SECUENCIAL { get; set; }

        [Description("NUM_ESTRADA")]
        public String NUM_ESTRADA { get; set; }

        [Description("NUM_ESTRADA_2")]
        public String NUM_ESTRADA_2 { get; set; }

        [Description("BLOQUE")]
        public String BLOQUE { get; set; }

        [Description("BLOQUE_2")]
        public String BLOQUE_2 { get; set; }

        [Description("DMC")]
        public Int32 DMC { get; set; }

        [Description("VOLUMEN")]
        public Decimal VOLUMEN { get; set; }

        [Description("FAJA")]
        public String FAJA { get; set; }

        [Description("FAJA_2")]
        public String FAJA_2 { get; set; }

        [Description("CODIGO")]
        public String CODIGO { get; set; }

        [Description("CODIGO_2")]
        public String CODIGO_2 { get; set; }

        [Description("NUMERO")]
        public String NUMERO { get; set; }

        [Category("FK"), Description("COD_EFITOSANITARIO")]
        public String COD_EFITOSANITARIO { get; set; }

        [Category("FK"), Description("DESC_EFITOSANITARIO")]
        public String DESC_EFITOSANITARIO { get; set; }

        [Description("ESTADO_SUPERVISION")]
        public Object ESTADO_SUPERVISION { get; set; }

        [Description("DAP")]
        public Decimal DAP { get; set; }

        [Description("DAP_2")]
        public Decimal DAP_2 { get; set; }

        [Description("DIAMETRO")]
        public Decimal DIAMETRO { get; set; }

        [Description("DIAMETRO_2")]
        public Decimal DIAMETRO_2 { get; set; }

        [Description("ALTURA")]
        public Decimal ALTURA { get; set; }

        [Description("ALTURA_2")]
        public Decimal ALTURA_2 { get; set; }

        [Description("AC")]
        public Decimal AC { get; set; }

        [Description("AC_2")]
        public Decimal AC_2 { get; set; }

        [Description("ZONA")]
        public String ZONA { get; set; }

        [Description("COORDENADA_ESTE")]
        public Int32 COORDENADA_ESTE { get; set; }

        [Description("COORDENADA_NORTE")]
        public Int32 COORDENADA_NORTE { get; set; }

        [Description("COORDENADA_ESTE_2")]
        public Int32 COORDENADA_ESTE_2 { get; set; }

        [Description("COORDENADA_NORTE_2")]
        public Int32 COORDENADA_NORTE_2 { get; set; }

        [Description("PRODUCCION_LATAS")]
        public Decimal PRODUCCION_LATAS { get; set; }

        [Description("PRODUCCION_LATAS_2")]
        public Decimal PRODUCCION_LATAS_2 { get; set; }

        [Description("NUM_COCOS_ABIERTOS")]
        public Int32 NUM_COCOS_ABIERTOS { get; set; }

        [Description("NUM_COCOS_CERRADOS")]
        public Int32 NUM_COCOS_CERRADOS { get; set; }

        [Description("ESTADO_MUESTRA")]
        public Object ESTADO_MUESTRA { get; set; }
        [Description("ESTADO_MUESTRA2")]
        public Object ESTADO_MUESTRA2 { get; set; }
        [Description("ESTADO_MUESTRA3")]
        public Object ESTADO_MUESTRA3 { get; set; }
        [Description("NUM_MUESTRA")]
        public Int32 NUM_MUESTRA { get; set; }

        [Category("FK"), Description("COD_ECONDICION")]
        public String COD_ECONDICION { get; set; }

        [Description("OBSERVACION")]
        public String OBSERVACION { get; set; }

        [Description("CODIGO_GPS")]
        public String CODIGO_GPS { get; set; }

        [Description("COD_SISTEMA")]
        public String COD_SISTEMA { get; set; }

        [Description("DESC_ECONDICION")]
        public String DESC_ECONDICION { get; set; }

        [Category("FK"), Description("COD_EESTADO")]
        public String COD_EESTADO { get; set; }

        [Category("FK"), Description("DESC_EESTADO")]
        public String DESC_EESTADO { get; set; }

        [Category("FK"), Description("DESC_EESTADO_2")]
        public String DESC_EESTADO_2 { get; set; }

        [Category("FK"), Description("COD_ACATEGORIA")]
        public String COD_ACATEGORIA { get; set; }

        [Description("DESC_ACATEGORIA")]
        public String DESC_ACATEGORIA { get; set; }

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

        [Description("BS_ALTURA_TOTAL")]
        public Decimal BS_ALTURA_TOTAL { get; set; }

        [Description("BS_DIAMETRO_RAMA_1")]
        public Decimal BS_DIAMETRO_RAMA_1 { get; set; }

        [Description("BS_DIAMETRO_RAMA_2")]
        public Decimal BS_DIAMETRO_RAMA_2 { get; set; }

        [Description("BS_DIAMETRO_RAMA_3")]
        public Decimal BS_DIAMETRO_RAMA_3 { get; set; }

        [Description("BS_DIAMETRO_RAMA_4")]
        public Decimal BS_DIAMETRO_RAMA_4 { get; set; }

        [Description("BS_DIAMETRO_RAMA_5")]
        public Decimal BS_DIAMETRO_RAMA_5 { get; set; }

        [Description("BS_DIAMETRO_RAMA_6")]
        public Decimal BS_DIAMETRO_RAMA_6 { get; set; }

        [Description("BS_DIAMETRO_RAMA_7")]
        public Decimal BS_DIAMETRO_RAMA_7 { get; set; }

        [Description("BS_LONGITUD_RAMA_1")]
        public Decimal BS_LONGITUD_RAMA_1 { get; set; }

        [Description("BS_LONGITUD_RAMA_2")]
        public Decimal BS_LONGITUD_RAMA_2 { get; set; }

        [Description("BS_LONGITUD_RAMA_3")]
        public Decimal BS_LONGITUD_RAMA_3 { get; set; }

        [Description("BS_LONGITUD_RAMA_4")]
        public Decimal BS_LONGITUD_RAMA_4 { get; set; }

        [Description("BS_LONGITUD_RAMA_5")]
        public Decimal BS_LONGITUD_RAMA_5 { get; set; }

        [Description("BS_LONGITUD_RAMA_6")]
        public Decimal BS_LONGITUD_RAMA_6 { get; set; }

        [Description("BS_LONGITUD_RAMA_7")]
        public Decimal BS_LONGITUD_RAMA_7 { get; set; }

        [Description("RegEstado")]
        public Int32 RegEstado { get; set; }

        [Description("ESTADO_FILA")]
        public Int32 ESTADO_FILA { get; set; }

        [Description("NUMERO_FILA")]
        public Int32 NUMERO_FILA { get; set; }

        //[Category("LIST"), Description("oListSupervision_Rama")]
        //public List<CSUPERVISION_NMRAMA> oListSupervision_Rama { get; set; }

        [Description("ESPECIES_ARESOLUCION")]
        public String ESPECIES_ARESOLUCION { get; set; }
        //17/05/2021 se agrega para mostrar las parcelas
        [Description("PCA")]
        public String PCA { get; set; }
        #endregion

        #region "Constructor"
        public Ent_ISUPERVISION_DET_EMADERABLE()
        {
            NUMERO_FILA = -1;
            ESTADO_FILA = -1;
            COORDENADA_ESTE = -1;
            COORDENADA_NORTE = -1;
            COORDENADA_ESTE_2 = -1;
            COORDENADA_NORTE_2 = -1;
            RegEstado = -1;
            COD_SECUENCIAL = -1;
            DAP = -1;
            DAP_2 = -1;
            AC = -1;
            AC_2 = -1;
            DIAMETRO = -1;
            DIAMETRO_2 = -1;
            ALTURA = -1;
            ALTURA_2 = -1;
            NUM_POA = -1;
            VOLUMEN = -1;
            DMC = -1;
            PRODUCCION_LATAS = -1;
            PRODUCCION_LATAS_2 = -1;
            NUM_COCOS_ABIERTOS = -1;
            NUM_COCOS_CERRADOS = -1;
            BS_LONGITUD_RAMA_1 = -1;
            BS_LONGITUD_RAMA_2 = -1;
            BS_LONGITUD_RAMA_3 = -1;
            BS_LONGITUD_RAMA_4 = -1;
            BS_LONGITUD_RAMA_5 = -1;
            BS_LONGITUD_RAMA_6 = -1;
            BS_LONGITUD_RAMA_7 = -1;
            BS_ALTURA_TOTAL = -1;
            BS_DIAMETRO_RAMA_1 = -1;
            BS_DIAMETRO_RAMA_2 = -1;
            BS_DIAMETRO_RAMA_3 = -1;
            BS_DIAMETRO_RAMA_4 = -1;
            BS_DIAMETRO_RAMA_5 = -1;
            BS_DIAMETRO_RAMA_6 = -1;
            BS_DIAMETRO_RAMA_7 = -1;
            NUM_MUESTRA = -1;
        }
        #endregion
    }
}
