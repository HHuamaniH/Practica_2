using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CapaEntidad.DOC
{
    public class Ent_GUIA_TRANSPORTE
    {
        #region entidades y propiedades
        [Description("COD_GUIA_TRANS")]
        public String COD_GUIA_TRANS { get; set; }
        [Description("NUMERO_GUIA_TRANS")]
        public String NUMERO_GUIA_TRANS { get; set; }
        [Description("NOMBRE_GUIA_TRANS")]
        public String NOMBRE_GUIA_TRANS { get; set; }
        [Description("COD_ZATRA")]
        public String COD_ZATRA { get; set; }
        [Description("SEDE")]
        public String SEDE { get; set; }
        [Description("TITULAR")]
        public String TITULAR { get; set; }
        [Description("TITULO")]
        public String TITULO { get; set; }
        [Description("APELLIDOS_NOMBRES_TH")]
        public String APELLIDOS_NOMBRES_TH { get; set; }
        [Description("DNI_TH")]
        public String DNI_TH { get; set; }
        [Description("RUC_TH")]
        public String RUC_TH { get; set; }
        [Description("DIRECCION_TH")]
        public String DIRECCION_TH { get; set; }
        [Description("UBIGEO_TH")]
        public String UBIGEO_TH { get; set; }
        [Description("DEPARTAMENTO_TH")]
        public String DEPARTAMENTO_TH { get; set; }
        [Description("PROVINCIA_TH")]
        public String PROVINCIA_TH { get; set; }
        [Description("DISTRITO_TH")]
        public String DISTRITO_TH { get; set; }
        [Description("TIPO_PERSONA")]
        public String TIPO_PERSONA { get; set; }
        /// <summary>
        //datos del propietario
        /// </summary>
        [Description("COD_PERSONAPRO")]
        public String COD_PERSONAPRO { get; set; }
        [Description("APELLIDOS_NOMBRES_PRO")]
        public String APELLIDOS_NOMBRES_PRO { get; set; }
        [Description("DNI_PRO")]
        public String DNI_PRO { get; set; }
        [Description("RUC_PRO")]
        public String RUC_PRO { get; set; }
        [Description("DIRECCION_PRO")]
        public String DIRECCION_PRO { get; set; }
        [Description("UBIGEO_PRO")]
        public String UBIGEO_PRO { get; set; }
        [Description("DEPARTAMENTO_PRO")]
        public String DEPARTAMENTO_PRO { get; set; }
        [Description("PROVINCIA_PRO")]
        public String PROVINCIA_PRO { get; set; }
        [Description("DISTRITO_PRO")]
        public String DISTRITO_PRO { get; set; }
        /// <summary>
        /// datos del destinatario
        /// </summary>
        [Description("COD_PERSONADEST")]
        public String COD_PERSONADEST { get; set; }
        [Description("APELLIDOS_NOMBRES_DES")]
        public String APELLIDOS_NOMBRES_DES { get; set; }
        [Description("DNI_DES")]
        public String DNI_DES { get; set; }
        [Description("RUC_DES")]
        public String RUC_DES { get; set; }
        [Description("DIRECCION_DES")]
        public String DIRECCION_DES { get; set; }
        [Description("UBIGEO_DES")]
        public String UBIGEO_DES { get; set; }
        [Description("DEPARTAMENTO_DES")]
        public String DEPARTAMENTO_DES { get; set; }
        [Description("PROVINCIA_DES")]
        public String PROVINCIA_DES { get; set; }
        [Description("DISTRITO_DES")]
        public String DISTRITO_DES { get; set; }
        [Description("NUM_POA")]
        public Int32 NUM_POA { get; set; }
        //PAGOS EFECTUADOS
        [Description("PROD_NATURAL")]
        public String PROD_NATURAL { get; set; }
        [Description("MONTONATURAL")]
        public Decimal MONTONATURAL { get; set; }
        [Description("CANON_REFOREST")]
        public String CANON_REFOREST { get; set; }
        [Description("MONTOCANON")]
        public Decimal MONTOCANON { get; set; }
        [Description("TIP_TRANS")]
        public String TIP_TRANS { get; set; }
        [Description("PLACA_VEHICULO_TRANS")]
        public String PLACA_VEHICULO_TRANS { get; set; }
        [Description("NUM_LICENCIA")]
        public String NUM_LICENCIA { get; set; }
        [Description("RegEstado")]
        public Int32 RegEstado { get; set; }

        //datos del conductor
        [Description("COD_PERSONACOND")]
        public String COD_PERSONACOND { get; set; }
        [Description("APELLIDOS_NOMBRES_COND")]
        public String APELLIDOS_NOMBRES_COND { get; set; }

        //DATOS DEL DESPACHADOR
        [Description("COD_PERSONADESP")]
        public String COD_PERSONADESP { get; set; }
        [Description("APELLIDOS_NOMBRES_DESPACHADOR")]
        public String APELLIDOS_NOMBRES_DESPACHADOR { get; set; }

        //DATOS DEL AUTORIZADOR
        [Description("COD_PERSONAAUT")]
        public String COD_PERSONAAUT { get; set; }

        [Description("APELLIDOS_NOMBRES_AUTORIZA")]
        public String APELLIDOS_NOMBRES_AUTORIZA { get; set; }

        [Description("COD_UCUENTA")]
        public String COD_UCUENTA { get; set; }

        [Description("NOMBRE_PRODUCTO")]
        public String NOMBRE_PRODUCTO { get; set; }

        [Description("NUMERO_PRODUCTO")]
        public String NUMERO_PRODUCTO { get; set; }

        [Description("CODIGO_PRODUCTO")]
        public String CODIGO_PRODUCTO { get; set; }

        [Description("CODIGO_ESPECIE")]
        public String CODIGO_ESPECIE { get; set; }

        [Description("ID_PRODUCTO")]
        public String ID_PRODUCTO { get; set; }

        [Description("TIPO_PRODUCTO")]
        public String TIPO_PRODUCTO { get; set; }

        [Description("DESCRIPCION_PRODUCTO")]
        public String DESCRIPCION_PRODUCTO { get; set; }

        [Description("CANTIDAD_PRODUCTO")]
        public Decimal CANTIDAD_PRODUCTO { get; set; }

        [Description("UNIDAD_MEDIDA_PROD")]
        public String UNIDAD_MEDIDA_PROD { get; set; }

        [Description("TOTAL_PRODUCTO")]
        public Decimal TOTAL_PRODUCTO { get; set; }

        [Description("OBSERVACIONES_PROD")]
        public String OBSERVACIONES_PROD { get; set; }

        [Description("OBSERVACIONES_PROD_DETALLE")]
        public String OBSERVACIONES_PROD_DETALLE { get; set; }

        [Description("OBSERVACIONES_GUIA")]
        public String OBSERVACIONES_GUIA { get; set; }

        [Description("PESO_CARGA")]
        public Decimal PESO_CARGA { get; set; }

        [Description("FECHA_EXPEDICION")]
        public Object FECHA_EXPEDICION { get; set; }

        [Description("FECHA_VENCIMIENTO")]
        public Object FECHA_VENCIMIENTO { get; set; }

        [Description("BusFormulario")]
        public String BusFormulario { get; set; }
        [Description("BusCriterio")]
        public String BusCriterio { get; set; }
        [Description("BusValor")]
        public String BusValor { get; set; }

        [Description("COD_THABILITANTE")]
        public String COD_THABILITANTE { get; set; }
        [Description("NUMERO TELEFONICO")]
        public String TELEFONO { get; set; }
        [Description("NOMBRE_UBIGEO")]
        public String UBIGEO_NAME { get; set; }
        [Description("NOMBRE_UBIGEOTH")]
        public String UBIGEO_NAMETH { get; set; }
        [Description("NOMBRE_UBIGEODEST")]
        public String UBIGEO_NAMEDEST { get; set; }
        [Description("COD_TITULAR")]
        public String COD_TITULAR { get; set; }
        [Description("COD_PERSONA")]
        public String COD_PERSONA { get; set; }
        [Description("DIRECCION")]
        public String DIRECCION { get; set; }

        //para el listado de las especies
        [Description("COD_ESPECIES")]
        public String COD_ESPECIES { get; set; }

        [Description("NOMBRE_CIENTIFICO")]
        public String NOMBRE_CIENTIFICO { get; set; }

        [Description("ESPECIE")]
        public String ESPECIE { get; set; }


        [Description("PLAN_AMAZONAS")]
        public Object PLAN_AMAZONAS { get; set; }
        [Description("ANIO_PLAN_AMAZONAS")]
        public String ANIO_PLAN_AMAZONAS { get; set; }

        [Description("CODIGO")]
        public String CODIGO { get; set; }
        [Description("DESCRIPCION")]
        public String DESCRIPCION { get; set; }

        [Description("GTF_ARCHIVO")]
        public String GTF_ARCHIVO { get; set; }
        [Description("GTF_ARCHIVO_TEXT")]
        public String GTF_ARCHIVO_TEXT { get; set; }

        //para el registro de persona
        #region registro de persona

        //para el registro de persona juridica       
        [Description("PERSONA")]
        public String PERSONA { get; set; }
        [Description("COD_UBIGEO")]
        public String COD_UBIGEO { get; set; }

        //calidad
        [Description("COD_ESTADO_DOC")]
        public String COD_ESTADO_DOC { get; set; }
        [Description("OBSERVACIONES_CONTROL")]
        public String OBSERVACIONES_CONTROL { get; set; }
        [Description("OBSERV_SUBSANAR")]
        public object OBSERV_SUBSANAR { get; set; }

        //Nuevas agregaciones por nuevo formato de GTF 27/04/2016
        [Description("ORIGEN_CONC")]
        public Object ORIGEN_CONC { get; set; }
        [Description("ORIGEN_PERM")]
        public Object ORIGEN_PERM { get; set; }
        [Description("ORIGEN_AUT")]
        public Object ORIGEN_AUT { get; set; }
        [Description("ORIGEN_BL")]
        public Object ORIGEN_BL { get; set; }
        [Description("ORIGEN_DESBLOQUE")]
        public Object ORIGEN_DESBLOQUE { get; set; }
        [Description("ORIGEN_CAMBUSO")]
        public Object ORIGEN_CAMBUSO { get; set; }
        [Description("ORIGEN_PLANTACION")]
        public Object ORIGEN_PLANTACION { get; set; }
        [Description("ORIGEN_PMC")]
        public Object ORIGEN_PMC { get; set; }
        [Description("ORIGEN_OTROS")]
        public Object ORIGEN_OTROS { get; set; }
        [Description("DET_ORIGEN_OTROS")]
        public String DET_ORIGEN_OTROS { get; set; }
        [Description("COD_PERSONARLEGAL")]
        public String COD_PERSONARLEGAL { get; set; }
        [Description("REPRESENTANTE_LEGAL")]
        public String REPRESENTANTE_LEGAL { get; set; }
        [Description("NUM_ARESOLUCION")]
        public String NUM_ARESOLUCION { get; set; }
        [Description("PLAN_MANEJO_TIPO")]
        public String PLAN_MANEJO_TIPO { get; set; }
        [Description("TIPO_COMPROBANTE")]
        public String TIPO_COMPROBANTE { get; set; }
        [Description("NUM_COMPROBANTE")]
        public String NUM_COMPROBANTE { get; set; }

        [Category("OUTPUT"), Description("OUTPUTPARAM01")]
        public Object OUTPUTPARAM01 { get; set; }
        #endregion

        [Category("LIST"), Description("LISTpRODUCTO")]
        public List<Ent_GUIA_TRANSPORTE> listProducto { get; set; }
        [Category("LIST"), Description("listProductoEli")]
        public List<Ent_GUIA_TRANSPORTE> listProductoEli { get; set; }
        [Category("LIST"), Description("ListIndicador")]
        public List<Ent_GUIA_TRANSPORTE> ListIndicador { get; set; }
        [Category("LIST"), Description("ListUnidadMedida")]
        public List<Ent_GUIA_TRANSPORTE> ListUnidadMedida { get; set; }
        [Category("LIST"), Description("ListEspecies")]
        public List<Ent_GUIA_TRANSPORTE> ListEspecies { get; set; }
        [Category("LIST"), Description("ListMComboDIdentidad")]
        public List<Ent_GUIA_TRANSPORTE> ListMComboDIdentidad { get; set; }


        #endregion

        #region "Constructor"
        public Ent_GUIA_TRANSPORTE()
        {
            NUM_POA = -1;
            PESO_CARGA = -1;
            CANTIDAD_PRODUCTO = -1;
            TOTAL_PRODUCTO = -1;
            MONTOCANON = -1;
            MONTONATURAL = -1;
            RegEstado = -1;
        }
        #endregion
    }
}
