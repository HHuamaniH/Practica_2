using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CapaEntidad.DOC
{
    public class Ent_ISUPERVISION_EXSITU_INFRA_AREA
    {
        #region "Entidades y Propiedades"
        [Category("OUTPUT"), Description("OUTPUTPARAM01")]
        public Object OUTPUTPARAM01 { get; set; }
        //
        [Description("COD_INFORME")]
        public String COD_INFORME { get; set; }

        [Description("POBJETIVO_COD_TDESCRIPTIVA")]
        public String POBJETIVO_COD_TDESCRIPTIVA { get; set; }

        [Description("OBSERVACION")]
        public String OBSERVACION { get; set; }

        [Category("FECHA"), Description("FECHA_PUBLICACION")]
        public Object FECHA_PUBLICACION { get; set; }

        [Category("FECHA"), Description("FECHA_EVENTO")]
        public Object FECHA_EVENTO { get; set; }

        [Description("COD_AREA")]
        public String COD_AREA { get; set; }

        [Description("INVESTIGACION_REALIZADA")]
        public String INVESTIGACION_REALIZADA { get; set; }

        [Description("OBJETIVO")]
        public String OBJETIVO { get; set; }

        [Description("COD_SECUENCIAL")]
        public Int32 COD_SECUENCIAL { get; set; }

        [Description("NUMERO")]
        public String NUMERO { get; set; }
        [Description("LARGO")]
        public Decimal LARGO { get; set; }
        [Description("ANCHO")]
        public Decimal ANCHO { get; set; }
        [Description("ALTURA")]
        public Decimal ALTURA { get; set; }
        [Description("AREA")]
        public Decimal AREA { get; set; }

        [Category("LIST"), Description("ListISupervision_exsitu_recinto")]
        public List<Ent_ISUPERVISION_EXSITU_INFRA_AREA> ListISupervision_exsitu_recinto
        { get; set; }

        [Category("LIST"), Description("ListISupervision_exsitu_recinto_equipo")]
        public List<Ent_ISUPERVISION_EXSITU_INFRA_AREA> ListISupervision_exsitu_recinto_equipo
        { get; set; }

        [Description("RegEstado")]
        public Int32 RegEstado { get; set; }

        [Description("NUM_FILA")]
        public Int32 NUM_FILA { get; set; }

        [Description("COD_ESPECIES")]
        public String COD_ESPECIES { get; set; }

        [Description("COD_TDESCRIPTIVA")]
        public String COD_TDESCRIPTIVA { get; set; }

        [Description("COD_EORIGEN")]
        public String COD_EORIGEN { get; set; }

        [Description("DESC_EORIGEN")]
        public String DESC_EORIGEN { get; set; }

        [Description("PROCEDENCIA_COD_TDESCRIPTIVA")]
        public String PROCEDENCIA_COD_TDESCRIPTIVA { get; set; }

        [Description("DESC_PROCEDENCIA")]
        public String DESC_PROCEDENCIA { get; set; }

        [Description("TIDENTI_COD_TDESCRIPTIVA")]
        public String TIDENTI_COD_TDESCRIPTIVA { get; set; }

        [Description("DESC_TIDENTIFICACION")]
        public String DESC_TIDENTIFICACION { get; set; }

        [Description("CODIGO_NOMBRE")]
        public String CODIGO_NOMBRE { get; set; }

        [Description("COD_SEXO")]
        public String COD_SEXO { get; set; }

        [Description("SEXO")]
        public String SEXO { get; set; }

        [Description("PUBLICADO")]
        public Object PUBLICADO { get; set; }

        [Description("COD_ACATEGORIA")]
        public String COD_ACATEGORIA { get; set; }

        [Description("DESC_ACATEGORIA")]
        public String DESC_ACATEGORIA { get; set; }

        [Description("PROCEDENCIA_NUM_INDIVIDUOS")]
        public Int32 PROCEDENCIA_NUM_INDIVIDUOS { get; set; }


        [Description("TIPO_VERTEBRADO")]
        public String TIPO_VERTEBRADO { get; set; }

        [Description("DESCRIPCION")]
        public String DESCRIPCION { get; set; }

        [Description("FRECUENCIA_COD_TDESCRIPTIVA")]
        public String FRECUENCIA_COD_TDESCRIPTIVA { get; set; }

        [Description("FRECUENCIA_DESCRIPCION")]
        public String FRECUENCIA_DESCRIPCION { get; set; }

        [Description("TIPO")]
        public String TIPO { get; set; }

        [Description("METODO_QUIMICO")]
        public String METODO_QUIMICO { get; set; }

        [Description("METODO_FISICO")]
        public String METODO_FISICO { get; set; }

        [Description("TIPO_AREA")]
        public String TIPO_AREA { get; set; }

        [Description("TIPO_ALIMENTACION")]
        public String TIPO_ALIMENTACION { get; set; }

        [Description("FRECUENCIA_RACION")]
        public String FRECUENCIA_RACION { get; set; }

        [Description("FRECUENCIA")]
        public String FRECUENCIA { get; set; }

        [Description("ACTIVIDAD_IMPLEMENTADA")]
        public String ACTIVIDAD_IMPLEMENTADA { get; set; }

        [Description("MATERIAL_USADO")]
        public String MATERIAL_USADO { get; set; }

        [Category("FECHA"), Description("FECHA_ACTUALIZACION")]
        public Object FECHA_ACTUALIZACION { get; set; }

        [Description("NUM_CRIAS_ANO")]
        public Int32 NUM_CRIAS_ANO { get; set; }

        [Description("NUM_CRIAS_VIABLES")]
        public Int32 NUM_CRIAS_VIABLES { get; set; }

        [Description("NUM_CRIAS_MUERTAS")]
        public Int32 NUM_CRIAS_MUERTAS { get; set; }

        [Description("REPRODUCCION_FRECUENCIA")]
        public String REPRODUCCION_FRECUENCIA { get; set; }

        [Description("REPRODUCCION_EPOCA")]
        public String REPRODUCCION_EPOCA { get; set; }

        [Description("ESPECIE_CAPTURADA")]
        public String ESPECIE_CAPTURADA { get; set; }

        [Description("NOMBRE_COMUN")]
        public String NOMBRE_COMUN { get; set; }

        [Description("NUM_ICAPTURADOS")]
        public Int32 NUM_ICAPTURADOS { get; set; }

        [Description("ZONA_CAPTURA")]
        public String ZONA_CAPTURA { get; set; }

        [Description("DOCUMENTO")]
        public String DOCUMENTO { get; set; }

        [Description("COD_MOTIVO")]
        public String COD_MOTIVO { get; set; }

        [Description("MOTIVO")]
        public String MOTIVO { get; set; }

        [Description("NECROPSIA")]
        public String NECROPSIA { get; set; }

        [Description("DIAGNOSTICO")]
        public String DIAGNOSTICO { get; set; }

        [Description("EDAD")]
        public String EDAD { get; set; }
        #endregion
        //cambios  fauna
        [Description("GRUPOESPECIE")]
        public String GRUPOESPECIE { get; set; }

        [Description("ESTADO")]
        public Object ESTADO { get; set; }

        [Description("TEMA")]
        public String TEMA { get; set; }
        [Description("NUM_BENEFICIADOS")]
        public Int32 NUM_BENEFICIADOS { get; set; }
        [Description("CAPACITADOR")]
        public String CAPACITADOR { get; set; }
        [Description("COD_EXSITUCAPACITACION")]
        public String COD_EXSITUCAPACITACION { get; set; }

        [Description("COD_BALANCE")]
        public String COD_BALANCE { get; set; }
        [Description("CENSO_INICIAL")]
        public Int32 CENSO_INICIAL { get; set; }
        [Description("CANT_INGRESO")]
        public Int32 CANT_INGRESO { get; set; }
        [Description("FECHA_INGRESO")]
        public Object FECHA_INGRESO { get; set; }
        [Description("DOCUMENTO_INGRESO")]
        public String DOCUMENTO_INGRESO { get; set; }
        [Description("MOTIVO_INGRESO")]
        public String MOTIVO_INGRESO { get; set; }
        [Description("OBSERV_INGRESO")]
        public String OBSERV_INGRESO { get; set; }
        [Description("CANT_EGRESO")]
        public Int32 CANT_EGRESO { get; set; }
        [Description("FECHA_EGRESO")]
        public Object FECHA_EGRESO { get; set; }
        [Description("DOCUMENTO_EGRESO")]
        public String DOCUMENTO_EGRESO { get; set; }
        [Description("MOTIVO_EGRESO")]
        public String MOTIVO_EGRESO { get; set; }
        [Description("OBSERV_EGRESO")]
        public String OBSERV_EGRESO { get; set; }
        [Description("BALANCE_PREVIO")]
        public Int32 BALANCE_PREVIO { get; set; }
        [Description("CENSO_FINAL")]
        public Int32 CENSO_FINAL { get; set; }

        [Description("MAE_OBLIGTITULAR")]
        public String MAE_OBLIGTITULAR { get; set; }
        [Description("EVAL_OBLIGTITULAR")]
        public String EVAL_OBLIGTITULAR { get; set; }
        [Description("OBSERVACION_OBLIG")]
        public String OBSERVACION_OBLIG { get; set; }
        [Description("COD_UCUENTA")]
        public String COD_UCUENTA { get; set; }

        #region "Constructor"
        public Ent_ISUPERVISION_EXSITU_INFRA_AREA()
        {
            CANT_EGRESO = -1;
            CANT_INGRESO = -1;
            CENSO_INICIAL = -1;
            CENSO_FINAL = -1;
            BALANCE_PREVIO = -1;
            NUM_ICAPTURADOS = -1;
            LARGO = -1;
            ANCHO = -1;
            ALTURA = -1;
            AREA = -1;
            COD_SECUENCIAL = -1;
            NUM_FILA = -1;
            NUM_CRIAS_ANO = -1;
            NUM_CRIAS_VIABLES = -1;
            NUM_CRIAS_MUERTAS = -1;
            NUM_ICAPTURADOS = -1;
            RegEstado = -1;
            PROCEDENCIA_NUM_INDIVIDUOS = -1;
            ESTADO = -1;
            NUM_BENEFICIADOS = -1;
        }
        #endregion
    }

    public class Ent_ISUPERVISION_EXSITU_CAUTI_EVALZOO
    {
        [Description("COD_INFORME")]
        public String COD_INFORME { get; set; }
        [Description("COD_SECUENCIAL")]
        public Int32 COD_SECUENCIAL { get; set; }
        [Description("MAE_CRITERIO_EVALZOO")]
        public String MAE_CRITERIO_EVALZOO { get; set; }
        [Description("CRITERIO_EVALZOO")]
        public String CRITERIO_EVALZOO { get; set; }
        [Description("CALIFICACION")]
        public String CALIFICACION { get; set; }
        [Description("OBSERVACION")]
        public String OBSERVACION { get; set; }
        [Description("COD_UCUENTA")]
        public String COD_UCUENTA { get; set; }
        [Description("RegEstado")]
        public Int32 RegEstado { get; set; }

        public Ent_ISUPERVISION_EXSITU_CAUTI_EVALZOO()
        {
            COD_SECUENCIAL = -1;
            RegEstado = -1;
        }
    }
}