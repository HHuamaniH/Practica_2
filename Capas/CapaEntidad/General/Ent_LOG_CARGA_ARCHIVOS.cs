using System.ComponentModel;

namespace CapaEntidad.GENE
{
    public class Ent_LOG_CARGA_ARCHIVOS
    {
        [Description("ORIGEN")]
        public string ORIGEN { get; set; }
        [Description("COD_UCUENTA")]
        public string COD_UCUENTA { get; set; }
        [Description("FECHA_CREACION")]
        public object FECHA_CREACION { get; set; }
        [Description("COD_REFERENCIA")]
        public string COD_REFERENCIA { get; set; }
        [Description("COD_REFERENCIA_AUX")]
        public string COD_REFERENCIA_AUX { get; set; }
        [Description("NOMBRE_ARCH")]
        public string NOMBRE_ARCH { get; set; }
        [Description("ERROR")]
        public string ERROR { get; set; }
    }
}

