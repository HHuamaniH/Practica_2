using System.ComponentModel;

namespace CapaEntidad.Documento
{
    public class ENT_Focalizacion_Priorizacion
    {
        [Description("COD_PLAN")]
        public string COD_PLAN { get; set; }
        [Description("COD_SECUENCIAL")]
        public int COD_SECUENCIAL { get; set; }
        [Description("COD_UCUENTA_CREACION")]
        public string COD_UCUENTA_CREACION { get; set; }
        [Description("A1")]
        public int A1 { get; set; }
        [Description("A2")]
        public int A2 { get; set; }
        [Description("A3")]
        public int A3 { get; set; }
        [Description("A4")]
        public int A4 { get; set; }
        [Description("A5")]
        public int A5 { get; set; }
        [Description("A6")]
        public int A6 { get; set; }
        [Description("A7")]
        public int A7 { get; set; }
        [Description("A8")]
        public int A8 { get; set; }
        [Description("B1")]
        public int B1 { get; set; }
        [Description("B2")]
        public int B2 { get; set; }
        [Description("B3")]
        public int B3 { get; set; }
        [Description("B4")]
        public int B4 { get; set; }
        [Description("B5")]
        public int B5 { get; set; }
        [Description("B6")]
        public int B6 { get; set; }
        [Category("OUTPUT"), Description("OUTPUTPARAM02")]
        public string OUTPUTPARAM02 { get; set; }
        public ENT_Focalizacion_Priorizacion()
        {
            this.OUTPUTPARAM02 = "";
        }
    }

}
