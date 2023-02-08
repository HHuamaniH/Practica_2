using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CapaEntidad.Documento
{
    public class Ent_Seguimiento_Muestra
    {

        [Category("OUTPUT"), Description("OUTPUTPARAM01")]
        public String OUTPUTPARAM01 { get; set; }
        [Description("BusCriterio")]
        public String BusCriterio { get; set; }
        [Description("COD_SECUENCIAL")]
        public Int32? COD_SECUENCIAL { get; set; }


        [Description("COD_SEG_MUESTRA")]
        public String COD_SEG_MUESTRA { get; set; }
        [Description("COD_INFORME")]
        public String COD_INFORME { get; set; }
        [Description("COD_TRAMITE_ENVIO")]
        public Int32? COD_TRAMITE_ENVIO { get; set; }
        [Description("COD_TRAMITE_RESPUESTA")]
        public Int32? COD_TRAMITE_RESPUESTA { get; set; }

        [Description("COD_UCUENTA")]
        public String COD_UCUENTA { get; set; }
        [Description("OBSERVACION")]
        public String OBSERVACION { get; set; }
        [Description("RegEstado")]
        public Int32? RegEstado { get; set; }
        [Description("COD_OD_REGISTRO")]
        public String COD_OD_REGISTRO { get; set; }

        //PROPIEDADES DE CALIDAD
        [Description("COD_ESTADO_DOC")]
        public String COD_ESTADO_DOC { get; set; }
        [Description("OBSERVACIONES_CONTROL")]
        public Object OBSERVACIONES_CONTROL { get; set; }
        [Description("OBSERV_SUBSANAR")]
        public Object OBSERV_SUBSANAR { get; set; }

    }
    public class Ent_Seguimiento_Muestra_Detalle
    {
        [Description("RegEstado")]
        public Int32 RegEstado { get; set; }
        [Description("COD_SEG_MUESTRA")]
        public string COD_SEG_MUESTRA { get; set; }
        [Description("COD_SECUENCIAL")]
        public Int32 COD_SECUENCIAL { get; set; }
        [Description("COD_MUESTRA")]
        public string COD_MUESTRA { get; set; }
        [Description("ZONAUTM")]
        public string ZONAUTM { get; set; }
        [Description("COORDENADA_ESTE")]
        public Int32 COORDENADA_ESTE { get; set; }
        [Description("COORDENADA_NORTE")]
        public Int32 COORDENADA_NORTE { get; set; }
        [Description("SECTOR")]
        public string SECTOR { get; set; }
        [Description("FECHA_COLECCION")]
        public object FECHA_COLECCION { get; set; }
        [Description("OBSERVACION")]
        public string OBSERVACION { get; set; }
        [Description("NUM_POA")]
        public Int32? NUM_POA { get; set; }
        [Description("COD_CENSO")]
        public string COD_CENSO { get; set; }
        [Description("COD_UCUENTA")]
        public string COD_UCUENTA { get; set; }
        [Description("COD_ESPECIES")]
        public string COD_ESPECIES { get; set; }
        [Description("ESPECIE_IDENTIFICADO")]
        public bool ESPECIE_IDENTIFICADO { get; set; }
        [Category("OUTPUT"), Description("OUTPUTPARAMDET01")]
        public String OUTPUTPARAMDET01 { get; set; }
        public List<Ent_SEG_MUESTRA_DETALLE_ARCHIVO> fotos { get; set; }
        public List<Ent_SEG_MUESTRA_DETALLE_ARCHIVO> fotosEli { get; set; }

        //caracteristicas adicionales
        [Description("C_FFuste")]
        public string C_FFuste { get; set; }
        [Description("C_TRAMIFICACION")]
        public string C_TRAMIFICACION { get; set; }
        [Description("C_TRAICES")]
        public string C_TRAICES { get; set; }
        [Description("C_CECOLOR")]
        public string C_CECOLOR { get; set; }
        [Description("C_CELENTICELAS")]
        public string C_CELENTICELAS { get; set; }
        [Description("C_CERITIDOMA")]
        public string C_CERITIDOMA { get; set; }
        [Description("C_CEOTRAS_ESTRUCTURAS")]
        public string C_CEOTRAS_ESTRUCTURAS { get; set; }
        [Description("C_CICOLOR")]
        public string C_CICOLOR { get; set; }
        [Description("C_CIOLOR")]
        public string C_CIOLOR { get; set; }
        [Description("C_CI_EXU_TIPO")]
        public string C_CI_EXU_TIPO { get; set; }
        [Description("C_CI_EXU_COLOR")]
        public string C_CI_EXU_COLOR { get; set; }
        [Description("C_CI_EXU_OLOR")]
        public string C_CI_EXU_OLOR { get; set; }
        [Description("C_CI_EXU_SABOR")]
        public string C_CI_EXU_SABOR { get; set; }
        [Description("C_CI_EXU_ABUNDANCIA")]
        public string C_CI_EXU_ABUNDANCIA { get; set; }
        [Description("C_CI_EXU_OTRA_CARACT")]
        public string C_CI_EXU_OTRA_CARACT { get; set; }
        [Description("C_CI_TIPO")]
        public string C_CI_TIPO { get; set; }
        [Description("C_IFUSTE_ESPINAS")]
        public string C_IFUSTE_ESPINAS { get; set; }
        [Description("C_IFUSTE_AGUIJONES")]
        public string C_IFUSTE_AGUIJONES { get; set; }
        [Description("C_IFUSTE_OTRAS_ESTRUCTURAS")]
        public string C_IFUSTE_OTRAS_ESTRUCTURAS { get; set; }
        [Description("C_HABITO_ARBOL")]
        public string C_HABITO_ARBOL { get; set; }
        [Description("C_HOJA_SIMPLE")]
        public bool C_HOJA_SIMPLE { get; set; }
        [Description("C_HOJA_COMPUESTA")]
        public bool C_HOJA_COMPUESTA { get; set; }
        [Description("C_HOJA_FORMA")]
        public string C_HOJA_FORMA { get; set; }
        [Description("C_HOJA_BORDE")]
        public string C_HOJA_BORDE { get; set; }
        [Description("C_HOJA_DISPOSICION")]
        public string C_HOJA_DISPOSICION { get; set; }
        [Description("C_FLORES_COLOR")]
        public string C_FLORES_COLOR { get; set; }
        [Description("C_FLORES_TAMAÑO")]
        public string C_FLORES_TAMAÑO { get; set; }
        [Description("C_FLORES_SIMPLE")]
        public bool C_FLORES_SIMPLE { get; set; }
        [Description("C_FLORES_INFLORESCENCIA")]
        public bool C_FLORES_INFLORESCENCIA { get; set; }
        [Description("C_FLORES_OTRA_CARACT")]
        public string C_FLORES_OTRA_CARACT { get; set; }
        [Description("C_FRUTOS_TIPO")]
        public string C_FRUTOS_TIPO { get; set; }
        [Description("C_FRUTOS_COLOR")]
        public string C_FRUTOS_COLOR { get; set; }
        [Description("C_FRUTOS_TAMANIO")]
        public string C_FRUTOS_TAMANIO { get; set; }
        [Description("C_FRUTOS_OTRA_CARACT")]
        public string C_FRUTOS_OTRA_CARACT { get; set; }
        //censo
        [Description("ESMADERABLE")]
        public bool? ESMADERABLE { get; set; }
        [Description("COD_SECUENCIAL_CENSO")]
        public int? COD_SECUENCIAL_CENSO { get; set; }
        //datos colector y supervisor
        [Description("COD_COLECTOR")]
        public string COD_COLECTOR { get; set; }
        [Description("COD_SUPERVISOR")]
        public string COD_SUPERVISOR { get; set; }
    }
    public class Ent_SEG_MUESTRA_DETALLE_ARCHIVO
    {


        [Description("COD_SEG_MUESTRA")]
        public string COD_SEG_MUESTRA { get; set; }
        [Description("COD_SECUENCIAL")]
        public Int32 COD_SECUENCIAL { get; set; }
        [Description("COD_SECUENCIAL_ARCHIVO")]
        public Int32 COD_SECUENCIAL_ARCHIVO { get; set; }
        [Description("NOMBRE_ARCH")]
        public string NOMBRE_ARCH { get; set; }
        [Description("fname")]
        public string fname { get; set; }
        [Description("EXTENSION_ARCH")]
        public string EXTENSION_ARCH { get; set; }
        [Description("COD_UCUENTA")]
        public string COD_UCUENTA { get; set; }
        [Description("RegEstado")]
        public Int32 RegEstado { get; set; }
        [Category("OUTPUT"), Description("OUTPUTPARAMDET01")]
        public String OUTPUTPARAMDET01 { get; set; }

    }
}
