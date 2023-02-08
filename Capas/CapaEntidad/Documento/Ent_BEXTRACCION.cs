using System.ComponentModel;

namespace CapaEntidad.DOC
{
    public class Ent_BEXTRACCION
    {
        [Description("COD_THABILITANTE")]
        public string COD_THABILITANTE { get; set; }
        [Description("NUM_POA")]
        public int NUM_POA { get; set; }
        public string NOMBRE_POA { get; set; }
        public string ARESOLUCION_NUM { get; set; }
        public string NUM_THABILITANTE { get; set; }
        public string TITULAR { get; set; }
        public string MODALIDAD { get; set; }
        public string ESTADO_ORIGEN { get; set; }
        public string COD_MTIPO { get; set; }
        public string INDICADOR { get; set; }

        public Ent_BEXTRACCION()
        {
            NUM_POA = -1;
        }
    }

    public class Ent_BEXTRACCION_FECEMI
    {
        [Description("COD_THABILITANTE")]
        public string COD_THABILITANTE { get; set; }
        [Description("NUM_POA")]
        public int NUM_POA { get; set; }
        [Description("COD_SECUENCIAL")]
        public int COD_SECUENCIAL { get; set; }
        [Description("BEXTRACCION_FEMISION")]
        public string BEXTRACCION_FEMISION { get; set; }
        [Description("COD_UCUENTA")]
        public string COD_UCUENTA { get; set; }
        [Description("RegEstado")]
        public int RegEstado { get; set; }
        [Description("OUTPUTPARAMDET01")]
        public int OUTPUTPARAMDET01 { get; set; }
        public int SELECTED { get; set; }

        public Ent_BEXTRACCION_FECEMI()
        {
            NUM_POA = -1;
            COD_SECUENCIAL = -1;
            RegEstado = -1;
            OUTPUTPARAMDET01 = -1;
            SELECTED = -1;
        }
    }

    public class Ent_BEXTRACCION_EliTABLA
    {
        [Description("EliTABLA")]
        public string EliTABLA { get; set; }
        [Description("COD_THABILITANTE")]
        public string COD_THABILITANTE { get; set; }
        [Description("NUM_POA")]
        public int NUM_POA { get; set; }
        [Description("COD_SECUENCIAL")]
        public int COD_SECUENCIAL { get; set; }
        [Description("COD_ESPECIES_BEXT")]
        public string COD_ESPECIES_BEXT { get; set; }
        [Description("COD_SECUENCIAL_BEXT")]
        public int COD_SECUENCIAL_BEXT { get; set; }

        public Ent_BEXTRACCION_EliTABLA()
        {
            NUM_POA = -1;
            COD_SECUENCIAL = -1;
            COD_SECUENCIAL_BEXT = -1;
        }
    }

    public class Ent_BEXTRACCION_MADE
    {
        [Description("COD_THABILITANTE")]
        public string COD_THABILITANTE { get; set; }
        [Description("NUM_POA")]
        public int NUM_POA { get; set; }
        [Description("COD_SECUENCIAL_BEXT")]
        public int COD_SECUENCIAL_BEXT { get; set; }
        [Description("COD_ESPECIES")]
        public string COD_ESPECIES { get; set; }
        [Description("COD_SECUENCIAL")]
        public int COD_SECUENCIAL { get; set; }
        [Description("ESPECIES")]
        public string ESPECIES { get; set; }
        [Description("DMC")]
        public int DMC { get; set; }
        [Description("TOTAL_ARBOLES")]
        public int TOTAL_ARBOLES { get; set; }
        [Description("VOLUMEN_AUTORIZADO")]
        public decimal VOLUMEN_AUTORIZADO { get; set; }
        [Description("VOLUMEN_MOVILIZADO")]
        public decimal VOLUMEN_MOVILIZADO { get; set; }
        [Description("SALDO")]
        public decimal SALDO { get; set; }
        [Description("COD_ESPECIES_SERFOR")]
        public string COD_ESPECIES_SERFOR { get; set; }
        [Description("ESPECIES_SERFOR")]
        public string ESPECIES_SERFOR { get; set; }
        [Description("TIPOMADERABLE")]
        public string TIPOMADERABLE { get; set; }
        [Description("OBSERVACION")]
        public string OBSERVACION { get; set; }
        [Description("COD_UCUENTA")]
        public string COD_UCUENTA { get; set; }
        [Description("RegEstado")]
        public int RegEstado { get; set; }

        //23-07-2021 Unión de Maderable - No Maderable
        [Description("UNIDAD_MEDIDA")]
        public string UNIDAD_MEDIDA { get; set; }
        //Atributos No Maderables
        [Description("AUTORIZADO")]
        public decimal AUTORIZADO { get; set; }
        [Description("EXTRAIDO")]
        public decimal EXTRAIDO { get; set; }      
        [Description("FECHA1")]
        public string FECHA1 { get; set; }
        [Description("FECHA2")]
        public string FECHA2 { get; set; }
        [Description("GUIA_TRANSPORTE")]
        public string GUIA_TRANSPORTE { get; set; }
        [Description("CANTIDAD")]
        public int CANTIDAD { get; set; }
        [Description("RECIBO")]
        public string RECIBO { get; set; }
        [Description("PC")]
        public string PC { get; set; }

        [Description("COD_PARCELA")]
        public string COD_PARCELA { get; set; }

        public Ent_BEXTRACCION_MADE()
        {
            NUM_POA = -1;
            COD_SECUENCIAL_BEXT = -1;
            COD_SECUENCIAL = -1;
            DMC = -1;
            TOTAL_ARBOLES = -1;
            VOLUMEN_AUTORIZADO = -1;
            VOLUMEN_MOVILIZADO = -1;
            SALDO = -1;
            RegEstado = -1;
            AUTORIZADO = -1;
            EXTRAIDO = -1;
            CANTIDAD = -1;
        }
    }

    public class Ent_BEXTRACCION_NOMADE
    {
        [Description("COD_THABILITANTE")]
        public string COD_THABILITANTE { get; set; }
        [Description("NUM_POA")]
        public int NUM_POA { get; set; }
        [Description("COD_SECUENCIAL_BEXT")]
        public int COD_SECUENCIAL_BEXT { get; set; }
        [Description("COD_ESPECIES")]
        public string COD_ESPECIES { get; set; }
        [Description("COD_SECUENCIAL")]
        public int COD_SECUENCIAL { get; set; }
        [Description("ESPECIES")]
        public string ESPECIES { get; set; }
        [Description("KILOGRAMO_AUTORIZADO")]
        public decimal KILOGRAMO_AUTORIZADO { get; set; }
        [Description("KILOGRAMO_MOVILIZADO")]
        public decimal KILOGRAMO_MOVILIZADO { get; set; }
        [Description("SALDO")]
        public decimal SALDO { get; set; }
        [Description("FECHA1")]
        public string FECHA1 { get; set; }
        [Description("FECHA2")]
        public string FECHA2 { get; set; }
        [Description("GUIA_TRANSPORTE")]
        public string GUIA_TRANSPORTE { get; set; }
        [Description("CANTIDAD")]
        public int CANTIDAD { get; set; }
        [Description("RECIBO")]
        public string RECIBO { get; set; }
        [Description("UNIDAD_MEDIDA")]
        public string UNIDAD_MEDIDA { get; set; }
        [Description("AUTORIZADO")]
        public decimal AUTORIZADO { get; set; }
        [Description("EXTRAIDO")]
        public decimal EXTRAIDO { get; set; }
        [Description("OBSERVACION")]
        public string OBSERVACION { get; set; }
        [Description("COD_ESPECIES_SERFOR")]
        public string COD_ESPECIES_SERFOR { get; set; }
        [Description("ESPECIES_SERFOR")]
        public string ESPECIES_SERFOR { get; set; }
        [Description("COD_UCUENTA")]
        public string COD_UCUENTA { get; set; }
        [Description("RegEstado")]
        public int RegEstado { get; set; }

        public Ent_BEXTRACCION_NOMADE()
        {
            NUM_POA = -1;
            COD_SECUENCIAL_BEXT = -1;
            COD_SECUENCIAL = -1;
            KILOGRAMO_AUTORIZADO = -1;
            KILOGRAMO_MOVILIZADO = -1;
            SALDO = -1;
            CANTIDAD = -1;
            AUTORIZADO = -1;
            EXTRAIDO = -1;
            RegEstado = -1;
        }
    }

    public class Ent_BEXTRACCION_KARDEX
    {
        [Description("COD_THABILITANTE")]
        public string COD_THABILITANTE { get; set; }
        [Description("NUM_POA")]
        public int NUM_POA { get; set; }
        [Description("COD_SECUENCIAL")]
        public int COD_SECUENCIAL { get; set; }
        [Description("COD_ESPECIES")]
        public string COD_ESPECIES { get; set; }
        [Description("ESPECIES")]
        public string ESPECIES { get; set; }
        [Description("FECHA_EMISIONKARDEX")]
        public string FECHA_EMISIONKARDEX { get; set; }
        [Description("GUIA_TRANSPORTE")]
        public string GUIA_TRANSPORTE { get; set; }
        [Description("COD_KARDEX_PRODUCTO")]
        public string COD_KARDEX_PRODUCTO { get; set; }
        [Description("COD_KARDEX_DESCRIPCION")]
        public string COD_KARDEX_DESCRIPCION { get; set; }
        [Description("CANTIDAD")]
        public int CANTIDAD { get; set; }
        [Description("KILOGRAMOS_KARDEX")]
        public decimal KILOGRAMOS_KARDEX { get; set; }
        [Description("M3")]
        public decimal M3 { get; set; }
        [Description("ACUMULADO")]
        public decimal ACUMULADO { get; set; }
        [Description("SALDO_KARDEX")]
        public decimal SALDO_KARDEX { get; set; }
        [Description("OBSERVACION_KARDEX")]
        public string OBSERVACION_KARDEX { get; set; }
        [Description("COD_UCUENTA")]
        public string COD_UCUENTA { get; set; }
        [Description("RegEstado")]
        public int RegEstado { get; set; }

        public string KARDEX_PRODUCTO { get; set; }
        public string KARDEX_DESCRIPCION { get; set; }

        public Ent_BEXTRACCION_KARDEX()
        {
            NUM_POA = -1;
            COD_SECUENCIAL = -1;
            CANTIDAD = -1;
            KILOGRAMOS_KARDEX = -1;
            M3 = -1;
            ACUMULADO = -1;
            SALDO_KARDEX = -1;
            RegEstado = -1;
        }
    }
}
