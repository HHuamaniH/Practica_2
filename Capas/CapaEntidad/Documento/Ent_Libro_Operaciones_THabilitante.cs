using System.ComponentModel;

namespace CapaEntidad.DOC
{
    public class Ent_Libro_Operaciones_THabilitante
    {
        [Description("LIBRO_OPERACIONES_TH_ID")]
        public long LIBRO_OPERACIONES_TH_ID { get; set; }
        [Description("COD_THABILITANTE")]
        public string COD_THABILITANTE { get; set; }
        [Description("NUM_POA")]
        public int NUM_POA { get; set; }
        [Description("COD_UCUENTA")]
        public string COD_UCUENTA { get; set; }
        [Description("OUTPUTPARAM02")]
        public string OUTPUTPARAM02 { get; set; }

    }
}
