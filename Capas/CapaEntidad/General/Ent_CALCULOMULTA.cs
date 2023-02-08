using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CapaEntidad.GENE
{
    public class Ent_CALCULOMULTA
    {
        [Description("CodCalculoMulta")]
        public String CodCalculoMulta { get; set; }
        [Description("Expediente")]
        public String Expediente { get; set; }
        [Description("Administrado")]
        public String Administrado { get; set; }
        [Description("NroDocumento")]
        public String NroDocumento { get; set; }
        [Description("TituloHabilitante")]
        public String TituloHabilitante { get; set; }
        [Description("RegEstado")]
        public Int32 RegEstado { get; set; }
        [Description("COD_UCUENTA")]
        public String COD_UCUENTA { get; set; }
        [Description("especies")]
        public List<Ent_DETALLECALCULOMULTA> DetalleCalculoMulta { get; set; }

        public Ent_CALCULOMULTA()
        {
            RegEstado = -1;
        }
    }
}
