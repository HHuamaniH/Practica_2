using System;
using System.ComponentModel;

namespace CapaEntidad.DOC
{
    public class Ent_FControlCalidadSupervision
    {
        [Description("COD_INFORME")]
        public String COD_INFORME { get; set; }
        [Description("MAESTRO_FORMATO_ID")]
        public int MAESTRO_FORMATO_ID { get; set; }
        [Description("PRESENTA_OBS")]
        public String PRESENTA_OBS { get; set; }
        [Description("LEVANTO_OBS")]
        public String LEVANTO_OBS { get; set; }
        [Description("OBS_ADICIONALES")]
        public String OBS_ADICIONALES { get; set; }
        [Description("DETALLE")]
        public String DETALLE { get; set; }
        [Category("FECHA"), Description("FECHA_VARIOS")]
        public Object FECHA_VARIOS { get; set; }
        [Description("ESTADOREG")]
        public int ESTADOREG { get; set; }
        [Description("COD_UCUENTA")]
        public String COD_UCUENTA { get; set; }
    }
}
