using System;
using System.ComponentModel;

namespace CapaEntidad.DOC
{
    public class Ent_PreVisualizar
    {
        #region entidades y propiedades

        [Description("COD_THABILITANTE")]
        public String COD_THABILITANTE { get; set; }

        [Description("COD_INFORME")]
        public String COD_INFORME { get; set; }

        [Description("COD_RDINICIO")]
        public String COD_RDINICIO { get; set; }

        [Description("COD_RDTERMINO")]
        public String COD_RDTERMINO { get; set; }

        [Description("MODALIDAD")]
        public String MODALIDAD { get; set; }

        [Description("TITULAR")]
        public String TITULAR { get; set; }

        [Description("PERMISO_AUTORIZACION")]
        public String PERMISO_AUTORIZACION { get; set; }

        [Description("REGION")]
        public String REGION { get; set; }
        [Description("DEPARTAMENTO")]
        public String DEPARTAMENTO { get; set; }
        [Description("PROVINCIA")]
        public String PROVINCIA { get; set; }
        [Description("DISTRITO")]
        public String DISTRITO { get; set; }

        [Description("Parentesco")]
        public String Parentesco { get; set; }

        [Description("SECTOR")]
        public String SECTOR { get; set; }

        [Description("POA")]
        public String POA { get; set; }
        [Description("NUM_POA")]
        public Int32 NUM_POA { get; set; }
        [Description("ARESOLUCION_NUM")]
        public String ARESOLUCION_NUM { get; set; }
        [Description("REFORMULA_NUM")]
        public String REFORMULA_NUM { get; set; }
        [Category("FECHA"), Description("INICIO_VIGENCIA")]
        public Object INICIO_VIGENCIA { get; set; }
        [Category("FECHA"), Description("BEXTRACCION_FEMISION")]
        public Object BEXTRACCION_FEMISION { get; set; }
        //14/11/2019 CAR MEJORAS CONSULTA TH
        [Category("FECHA_INFORME"), Description("FECHA_INFORME")]
        public Object FECHA_INFORME { get; set; }

        [Description("INF_NUMERO")]
        public String INF_NUMERO { get; set; }
        [Description("ANIO_SUPER")]
        public String ANIO_SUPER { get; set; }
        [Category("FECHA"), Description("FECHA_INI")]
        public Object FECHA_INI { get; set; }
        [Category("FECHA"), Description("FECHA_TERMINO")]
        public Object FECHA_TERMINO { get; set; }

        [Description("INF_LEGAL")]
        public String INF_LEGAL { get; set; }
        [Description("DETER_INF_LEGAL")]
        public String DETER_INF_LEGAL { get; set; }
        [Description("MOTIVO_ARCHIVO")]
        public String MOTIVO_ARCHIVO { get; set; }

        [Description("RD_INICIO_PAU")]
        public String RD_INICIO_PAU { get; set; }
        [Description("RD_TERMINO_PAU")]
        public String RD_TERMINO_PAU { get; set; }
        [Description("MEDIDAS_CAUTELARES")]
        public Object MEDIDAS_CAUTELARES { get; set; }
        [Description("RD_INICIO_INF_FALSA")]
        public Object RD_INICIO_INF_FALSA { get; set; }

        [Description("RD_RECONSIDERACION")]
        public String RD_RECONSIDERACION { get; set; }
        [Description("DETER_RECONSIDERACION")]
        public String DETER_RECONSIDERACION { get; set; }

        [Description("LEV_CADUC_RD_REC")]
        public Object LEV_CADUC_RD_REC { get; set; }

        [Description("RES_TFFS")]
        public String RES_TFFS { get; set; }
        [Description("NOM_RECAPE_TFFS")]
        public String NOM_RECAPE_TFFS { get; set; }
        [Description("NOM_TIPDET_TFFS")]
        public String NOM_TIPDET_TFFS { get; set; }
        [Description("NOM_MOTDET_TFFS")]
        public String NOM_MOTDET_TFFS { get; set; }

        [Description("PROVEIDO")]
        public String PROVEIDO { get; set; }
        [Description("APELA")]
        public String APELA { get; set; }

        [Description("COD_UCUENTA")]
        public String COD_UCUENTA { get; set; }

        //[Description("FIN_FOR_f")]
        //public String FIN_FOR_f { get; set; }
        //[Description("FIN_FOR_i")]
        //public String FIN_FOR_i { get; set; }
        //[Description("FIN_FOR_k")]
        //public String FIN_FOR_k { get; set; }
        //[Description("FIN_FOR_l")]
        //public String FIN_FOR_l { get; set; }
        //[Description("FIN_FOR_m")]
        //public String FIN_FOR_m { get; set; }
        //[Description("FIN_FOR_n")]
        //public String FIN_FOR_n { get; set; }
        //[Description("FIN_FOR_w")]
        //public String FIN_FOR_w { get; set; }

        [Description("PAU_FIN_TIPO")]
        public String PAU_FIN_TIPO { get; set; }

        [Description("CADUCIDAD")]
        public Object CADUCIDAD { get; set; }

        [Description("ARCH")]
        public String ARCH { get; set; }

        [Category("OUTPUT"), Description("OUTPUTPARAM01")]
        public Object OUTPUTPARAM01 { get; set; }

        //para las inexistencias 
        [Description("NOMBRE_CIENTIFICO")]
        public String NOMBRE_CIENTIFICO { get; set; }
        [Description("NOMBRE_COMUN")]
        public String NOMBRE_COMUN { get; set; }
        [Description("VOLUMEN_APROBADO_RESOLUCION")]
        public Decimal VOLUMEN_APROBADO_RESOLUCION { get; set; }
        [Description("VOLUMEN_EXTRAIDO")]
        public Decimal VOLUMEN_EXTRAIDO { get; set; }
        [Description("MUESTRA")]
        public Int32 MUESTRA { get; set; }
        [Description("INEX")]
        public Int32 INEX { get; set; }
        [Description("VOL_RD")]
        public Decimal VOL_RD { get; set; }

        //para la busqueda de reportes
        [Description("BusCriterio")]
        public String BusCriterio { get; set; }

        [Description("BusValor")]
        public String BusValor { get; set; }

        [Description("ZAFRA")]
        public String ZAFRA { get; set; }

        [Description("Porcentaje")]
        public Decimal Porcentaje { get; set; }

        //notificacion
        [Description("NUMERO_RESOLUCION")]
        public String NUMERO_RESOLUCION { get; set; }
        [Description("PERSONA_NOTIFICADA")]
        public String PERSONA_NOTIFICADA { get; set; }
        [Description("Autoridad")]
        public String Autoridad { get; set; }
        [Description("NUMERO_EXPEDIENTE")]
        public String NUMERO_EXPEDIENTE { get; set; }


        [Description("NUMERO_NOTIFICACION")]
        public String NUMERO_NOTIFICACION { get; set; }
        [Description("FECHA_NOTIFICACION")]
        public Object FECHA_NOTIFICACION { get; set; }
        [Description("TIPO_NOTIFICACION")]
        public String TIPO_NOTIFICACION { get; set; }

        [Description("COD_RESODIREC")]
        public String COD_RESODIREC { get; set; }



        [Description("ARTICULO")]
        public String ARTICULO { get; set; }
        [Description("ENCISO")]
        public String ENCISO { get; set; }

        [Description("VOLUMEN")]
        public Decimal VOLUMEN { get; set; }
        //[Description("VOLUMEN_INI")]
        //public Decimal VOLUMEN_INI { get; set; }
        //[Description("VOLUMEN_TER")]
        //public Decimal VOLUMEN_TER { get; set; }
        [Description("SALDO")]
        public Decimal SALDO { get; set; }

        [Description("ESPECIES")]
        public String ESPECIES { get; set; }

        [Description("AREA")]
        public Decimal AREA { get; set; }

        [Description("NUMERO_INDIVIDUOS")]
        public Int32 NUMERO_INDIVIDUOS { get; set; }

        [Description("INFRACCIONES")]
        public String INFRACCIONES { get; set; }

        [Description("OBSERVACION")]
        public String OBSERVACION { get; set; }

        //literales de sancion
        [Description("sanciones")]
        public String sanciones { get; set; }

        [Description("DOC_SIADO_ARESOL")]
        public String DOC_SIADO_ARESOL { get; set; }
        [Description("DOC_SIADO_REFOR")]
        public String DOC_SIADO_REFOR { get; set; }
        [Description("DOC_SIADO_INFORME")]
        public String DOC_SIADO_INFORME { get; set; }
        [Description("DOC_SIADO_ILEGAL")]
        public String DOC_SIADO_ILEGAL { get; set; }
        [Description("DOC_SIADO_INI")]
        public String DOC_SIADO_INI { get; set; }
        [Description("DOC_SIADO_TER")]
        public String DOC_SIADO_TER { get; set; }
        [Description("DOC_SIADO_REC")]
        public String DOC_SIADO_REC { get; set; }


        [Description("TIPO_DOCUMENTO")]
        public String TIPO_DOCUMENTO { get; set; }
        [Description("FECHA_HORA_CONSULTA")]
        public String FECHA_HORA_CONSULTA { get; set; }

        //14/11/2019 RD DE ADCUACION Y MULTA
        [Description("RD_ADECUACION")]
        public String RD_ADECUACION { get; set; }
        [Description("FECHA_ADECUACION")]
        public Object FECHA_ADECUACION { get; set; }
        [Description("TIPO_ADECUACION")]
        public String TIPO_ADECUACION { get; set; }
        [Description("MULTA_PAU")]
        public Decimal MULTA_PAU { get; set; }
        #endregion
        #region constructor
        public Ent_PreVisualizar()
        {
            //NUM_POA = -1;
            VOL_RD = -1;
            VOLUMEN_APROBADO_RESOLUCION = -1;
            INEX = -1;
            VOLUMEN_EXTRAIDO = -1;
            MUESTRA = -1;
            Porcentaje = -1;
            VOLUMEN = -1;
            AREA = -1;
            NUMERO_INDIVIDUOS = -1;
            NUM_POA = -1;
            //VOLUMEN_INI = -1;
            //VOLUMEN_TER = -1;
            SALDO = -1;
            MULTA_PAU = -1;
        }
        #endregion

    }

    /*
    public class Ent_PreVisualizar
    {
        #region entidades y propiedades

        [Description("COD_THABILITANTE")]
        public String COD_THABILITANTE { get; set; }

        [Description("COD_INFORME")]
        public String COD_INFORME { get; set; }

        [Description("COD_RDINICIO")]
        public String COD_RDINICIO { get; set; }

        [Description("COD_RDTERMINO")]
        public String COD_RDTERMINO { get; set; }

        [Description("MODALIDAD")]
        public String MODALIDAD { get; set; }

        [Description("TITULAR")]
        public String TITULAR { get; set; }

        [Description("PERMISO_AUTORIZACION")]
        public String PERMISO_AUTORIZACION { get; set; }

        [Description("REGION")]
        public String REGION { get; set; }
        [Description("DEPARTAMENTO")]
        public String DEPARTAMENTO { get; set; }
        [Description("PROVINCIA")]
        public String PROVINCIA { get; set; }
        [Description("DISTRITO")]
        public String DISTRITO { get; set; }

        [Description("Parentesco")]
        public String Parentesco { get; set; }

        [Description("SECTOR")]
        public String SECTOR { get; set; }

        [Description("POA")]
        public String POA { get; set; }
        [Description("NUM_POA")]
        public Int32 NUM_POA { get; set; }
        [Description("ARESOLUCION_NUM")]
        public String ARESOLUCION_NUM { get; set; }
        [Description("REFORMULA_NUM")]
        public String REFORMULA_NUM { get; set; }
        [Category("FECHA"), Description("INICIO_VIGENCIA")]
        public Object INICIO_VIGENCIA { get; set; }
        [Category("FECHA"), Description("BEXTRACCION_FEMISION")]
        public Object BEXTRACCION_FEMISION { get; set; }
        //14/11/2019 CAR MEJORAS CONSULTA TH
        [Category("FECHA_INFORME"), Description("FECHA_INFORME")]
        public Object FECHA_INFORME { get; set; }

        [Description("INF_NUMERO")]
        public String INF_NUMERO { get; set; }
        [Description("ANIO_SUPER")]
        public String ANIO_SUPER { get; set; }
        [Category("FECHA"), Description("FECHA_INI")]
        public Object FECHA_INI { get; set; }
        [Category("FECHA"), Description("FECHA_TERMINO")]
        public Object FECHA_TERMINO { get; set; }

        [Description("INF_LEGAL")]
        public String INF_LEGAL { get; set; }
        [Description("DETER_INF_LEGAL")]
        public String DETER_INF_LEGAL { get; set; }
        [Description("MOTIVO_ARCHIVO")]
        public String MOTIVO_ARCHIVO { get; set; }

        [Description("RD_INICIO_PAU")]
        public String RD_INICIO_PAU { get; set; }
        [Description("RD_TERMINO_PAU")]
        public String RD_TERMINO_PAU { get; set; }
        [Description("MEDIDAS_CAUTELARES")]
        public Object MEDIDAS_CAUTELARES { get; set; }
        [Description("RD_INICIO_INF_FALSA")]
        public Object RD_INICIO_INF_FALSA { get; set; }

        [Description("RD_RECONSIDERACION")]
        public String RD_RECONSIDERACION { get; set; }
        [Description("DETER_RECONSIDERACION")]
        public String DETER_RECONSIDERACION { get; set; }

        [Description("LEV_CADUC_RD_REC")]
        public Object LEV_CADUC_RD_REC { get; set; }

        [Description("RES_TFFS")]
        public String RES_TFFS { get; set; }
        [Description("NOM_RECAPE_TFFS")]
        public String NOM_RECAPE_TFFS { get; set; }
        [Description("NOM_TIPDET_TFFS")]
        public String NOM_TIPDET_TFFS { get; set; }
        [Description("NOM_MOTDET_TFFS")]
        public String NOM_MOTDET_TFFS { get; set; }

        [Description("PROVEIDO")]
        public String PROVEIDO { get; set; }
        [Description("APELA")]
        public String APELA { get; set; }

        [Description("COD_UCUENTA")]
        public String COD_UCUENTA { get; set; }

        //[Description("FIN_FOR_f")]
        //public String FIN_FOR_f { get; set; }
        //[Description("FIN_FOR_i")]
        //public String FIN_FOR_i { get; set; }
        //[Description("FIN_FOR_k")]
        //public String FIN_FOR_k { get; set; }
        //[Description("FIN_FOR_l")]
        //public String FIN_FOR_l { get; set; }
        //[Description("FIN_FOR_m")]
        //public String FIN_FOR_m { get; set; }
        //[Description("FIN_FOR_n")]
        //public String FIN_FOR_n { get; set; }
        //[Description("FIN_FOR_w")]
        //public String FIN_FOR_w { get; set; }

        [Description("PAU_FIN_TIPO")]
        public String PAU_FIN_TIPO { get; set; }

        [Description("CADUCIDAD")]
        public Object CADUCIDAD { get; set; }

        [Description("ARCH")]
        public String ARCH { get; set; }

        [Category("OUTPUT"), Description("OUTPUTPARAM01")]
        public Object OUTPUTPARAM01 { get; set; }

        //para las inexistencias 
        [Description("NOMBRE_CIENTIFICO")]
        public String NOMBRE_CIENTIFICO { get; set; }
        [Description("NOMBRE_COMUN")]
        public String NOMBRE_COMUN { get; set; }
        [Description("VOLUMEN_APROBADO_RESOLUCION")]
        public Decimal VOLUMEN_APROBADO_RESOLUCION { get; set; }
        [Description("VOLUMEN_EXTRAIDO")]
        public Decimal VOLUMEN_EXTRAIDO { get; set; }
        [Description("MUESTRA")]
        public Int32 MUESTRA { get; set; }
        [Description("INEX")]
        public Int32 INEX { get; set; }
        [Description("VOL_RD")]
        public Decimal VOL_RD { get; set; }

        //para la busqueda de reportes
        [Description("BusCriterio")]
        public String BusCriterio { get; set; }

        [Description("BusValor")]
        public String BusValor { get; set; }

        [Description("ZAFRA")]
        public String ZAFRA { get; set; }

        [Description("Porcentaje")]
        public Decimal Porcentaje { get; set; }

        //notificacion
        [Description("NUMERO_RESOLUCION")]
        public String NUMERO_RESOLUCION { get; set; }
        [Description("PERSONA_NOTIFICADA")]
        public String PERSONA_NOTIFICADA { get; set; }
        [Description("Autoridad")]
        public String Autoridad { get; set; }
        [Description("NUMERO_EXPEDIENTE")]
        public String NUMERO_EXPEDIENTE { get; set; }


        [Description("NUMERO_NOTIFICACION")]
        public String NUMERO_NOTIFICACION { get; set; }
        [Description("FECHA_NOTIFICACION")]
        public Object FECHA_NOTIFICACION { get; set; }
        [Description("TIPO_NOTIFICACION")]
        public String TIPO_NOTIFICACION { get; set; }

        [Description("COD_RESODIREC")]
        public String COD_RESODIREC { get; set; }



        [Description("ARTICULO")]
        public String ARTICULO { get; set; }
        [Description("ENCISO")]
        public String ENCISO { get; set; }

        [Description("VOLUMEN")]
        public Decimal VOLUMEN { get; set; }
        //[Description("VOLUMEN_INI")]
        //public Decimal VOLUMEN_INI { get; set; }
        //[Description("VOLUMEN_TER")]
        //public Decimal VOLUMEN_TER { get; set; }
        [Description("SALDO")]
        public Decimal SALDO { get; set; }

        [Description("ESPECIES")]
        public String ESPECIES { get; set; }

        [Description("AREA")]
        public Decimal AREA { get; set; }

        [Description("NUMERO_INDIVIDUOS")]
        public Int32 NUMERO_INDIVIDUOS { get; set; }

        [Description("INFRACCIONES")]
        public String INFRACCIONES { get; set; }

        [Description("OBSERVACION")]
        public String OBSERVACION { get; set; }

        //literales de sancion
        [Description("sanciones")]
        public String sanciones { get; set; }

        [Description("DOC_SIADO_ARESOL")]
        public String DOC_SIADO_ARESOL { get; set; }
        [Description("DOC_SIADO_REFOR")]
        public String DOC_SIADO_REFOR { get; set; }
        [Description("DOC_SIADO_INFORME")]
        public String DOC_SIADO_INFORME { get; set; }
        [Description("DOC_SIADO_ILEGAL")]
        public String DOC_SIADO_ILEGAL { get; set; }
        [Description("DOC_SIADO_INI")]
        public String DOC_SIADO_INI { get; set; }
        [Description("DOC_SIADO_TER")]
        public String DOC_SIADO_TER { get; set; }
        [Description("DOC_SIADO_REC")]
        public String DOC_SIADO_REC { get; set; }


        [Description("TIPO_DOCUMENTO")]
        public String TIPO_DOCUMENTO { get; set; }
        [Description("FECHA_HORA_CONSULTA")]
        public String FECHA_HORA_CONSULTA { get; set; }

        //14/11/2019 RD DE ADCUACION Y MULTA
        [Description("RD_ADECUACION")]
        public String RD_ADECUACION { get; set; }
        [Description("FECHA_ADECUACION")]
        public Object FECHA_ADECUACION { get; set; }
        [Description("TIPO_ADECUACION")]
        public String TIPO_ADECUACION { get; set; }
        [Description("MULTA_PAU")]
        public Decimal MULTA_PAU { get; set; }
        #endregion
        #region constructor
        public Ent_PreVisualizar()
        {
            //NUM_POA = -1;
            VOL_RD = -1;
            VOLUMEN_APROBADO_RESOLUCION = -1;
            INEX = -1;
            VOLUMEN_EXTRAIDO = -1;
            MUESTRA = -1;
            Porcentaje = -1;
            VOLUMEN = -1;
            AREA = -1;
            NUMERO_INDIVIDUOS = -1;
            NUM_POA = -1;
            //VOLUMEN_INI = -1;
            //VOLUMEN_TER = -1;
            SALDO = -1;
            MULTA_PAU = -1;
        }
        #endregion

    }*/

    public class Ent_PreVisualizarv1
    {
        #region entidades y propiedades


        public String COD_THABILITANTE { get; set; }


        public String COD_INFORME { get; set; }


        public String COD_RDINICIO { get; set; }


        public String COD_RDTERMINO { get; set; }


        public String MODALIDAD { get; set; }


        public String TITULAR { get; set; }


        public String PERMISO_AUTORIZACION { get; set; }


        public String REGION { get; set; }

        public String DEPARTAMENTO { get; set; }

        public String PROVINCIA { get; set; }

        public String DISTRITO { get; set; }


        public String Parentesco { get; set; }


        public String SECTOR { get; set; }


        public String POA { get; set; }

        public Int32 NUM_POA { get; set; }

        public String ARESOLUCION_NUM { get; set; }

        public String REFORMULA_NUM { get; set; }

        public string INICIO_VIGENCIA { get; set; }

        public string BEXTRACCION_FEMISION { get; set; }

        public string FECHA_INFORME { get; set; }


        public String INF_NUMERO { get; set; }
        public String COD_ITIPO { get; set; }

        public String ANIO_SUPER { get; set; }

        public string FECHA_INI { get; set; }

        public string FECHA_TERMINO { get; set; }

        public String INF_LEGAL { get; set; }

        public String DETER_INF_LEGAL { get; set; }

        public String MOTIVO_ARCHIVO { get; set; }


        public String RD_INICIO_PAU { get; set; }

        public String RD_TERMINO_PAU { get; set; }

        public string MEDIDAS_CAUTELARES { get; set; }

        public string RD_INICIO_INF_FALSA { get; set; }


        public String RD_RECONSIDERACION { get; set; }

        public String DETER_RECONSIDERACION { get; set; }


        public string LEV_CADUC_RD_REC { get; set; }


        public String RES_TFFS { get; set; }

        public String NOM_RECAPE_TFFS { get; set; }

        public String NOM_TIPDET_TFFS { get; set; }

        public String NOM_MOTDET_TFFS { get; set; }


        public String PROVEIDO { get; set; }

        public String APELA { get; set; }


        public String COD_UCUENTA { get; set; }

        //[Description("FIN_FOR_f")]
        //public String FIN_FOR_f { get; set; }
        //[Description("FIN_FOR_i")]
        //public String FIN_FOR_i { get; set; }
        //[Description("FIN_FOR_k")]
        //public String FIN_FOR_k { get; set; }
        //[Description("FIN_FOR_l")]
        //public String FIN_FOR_l { get; set; }
        //[Description("FIN_FOR_m")]
        //public String FIN_FOR_m { get; set; }
        //[Description("FIN_FOR_n")]
        //public String FIN_FOR_n { get; set; }
        //[Description("FIN_FOR_w")]
        //public String FIN_FOR_w { get; set; }


        public String PAU_FIN_TIPO { get; set; }


        public string CADUCIDAD { get; set; }


        public String ARCH { get; set; }



        //para las inexistencias 

        public String NOMBRE_CIENTIFICO { get; set; }

        public String NOMBRE_COMUN { get; set; }

        public Decimal VOLUMEN_APROBADO_RESOLUCION { get; set; }

        public Decimal VOLUMEN_EXTRAIDO { get; set; }

        public Int32 MUESTRA { get; set; }

        public Int32 INEX { get; set; }

        public Decimal VOL_RD { get; set; }

        //para la busqueda de reportes

        public String BusCriterio { get; set; }


        public String BusValor { get; set; }


        public String ZAFRA { get; set; }


        public Decimal Porcentaje { get; set; }

        //notificacion

        public String NUMERO_RESOLUCION { get; set; }

        public String PERSONA_NOTIFICADA { get; set; }

        public String Autoridad { get; set; }

        public String NUMERO_EXPEDIENTE { get; set; }



        public String NUMERO_NOTIFICACION { get; set; }

        public Object FECHA_NOTIFICACION { get; set; }

        public String TIPO_NOTIFICACION { get; set; }


        public String COD_RESODIREC { get; set; }




        public String ARTICULO { get; set; }

        public String ENCISO { get; set; }


        public Decimal VOLUMEN { get; set; }
        //[Description("VOLUMEN_INI")]
        //public Decimal VOLUMEN_INI { get; set; }
        //[Description("VOLUMEN_TER")]
        //public Decimal VOLUMEN_TER { get; set; }

        public Decimal SALDO { get; set; }


        public String ESPECIES { get; set; }


        public Decimal AREA { get; set; }


        public Int32 NUMERO_INDIVIDUOS { get; set; }


        public String INFRACCIONES { get; set; }


        public String OBSERVACION { get; set; }

        //literales de sancion

        public String sanciones { get; set; }


        public String DOC_SIADO_ARESOL { get; set; }
        public String DOC_ORIGEN_ARESOL { get; set; }

        public String DOC_SIADO_REFOR { get; set; }
        public String DOC_ORIGEN_REFOR { get; set; }

        public String DOC_SIADO_INFORME { get; set; }

        public String DOC_SIADO_ILEGAL { get; set; }

        public String DOC_SIADO_INI { get; set; }

        public String DOC_SIADO_TER { get; set; }

        public String DOC_SIADO_REC { get; set; }



        public String TIPO_DOCUMENTO { get; set; }

        public String FECHA_HORA_CONSULTA { get; set; }

        //14/11/2019 RD DE ADCUACION Y MULTA

        public String RD_ADECUACION { get; set; }

        public string FECHA_ADECUACION { get; set; }

        public String TIPO_ADECUACION { get; set; }

        public Decimal MULTA_PAU { get; set; }
        #endregion
        #region constructor
        public Ent_PreVisualizarv1()
        {
            //NUM_POA = -1;
            VOL_RD = -1;
            VOLUMEN_APROBADO_RESOLUCION = -1;
            INEX = -1;
            VOLUMEN_EXTRAIDO = -1;
            MUESTRA = -1;
            Porcentaje = -1;
            VOLUMEN = -1;
            AREA = -1;
            NUMERO_INDIVIDUOS = -1;
            NUM_POA = -1;
            //VOLUMEN_INI = -1;
            //VOLUMEN_TER = -1;
            SALDO = -1;
            MULTA_PAU = -1;
        }
        #endregion

    }
}
