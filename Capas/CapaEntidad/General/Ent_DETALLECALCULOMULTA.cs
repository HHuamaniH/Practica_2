using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CapaEntidad.GENE
{
    public class Ent_DETALLECALCULOMULTA
    {
        [Description("CodCalculoMulta")]
        public String CodCalculoMulta { get; set; }
        [Description("literal")]
        public String literal { get; set; }        
        [Description("SumatoriaK")]
        public Decimal SumatoriaK { get; set; }
        [Description("SumatoriaB")]
        public Decimal SumatoriaB { get; set; }
        [Description("SumatoriaCE")]
        public Decimal SumatoriaCE { get; set; }
        [Description("SumatoriaPD")]
        public Decimal SumatoriaPD { get; set; }
        [Description("SumatoriaVEN")]
        public Decimal SumatoriaVEN { get; set; }
        [Description("SumatoriaF")]
        public Decimal SumatoriaF { get; set; }
        [Description("SubTotal")]
        public Decimal SubTotal { get; set; }
        [Description("Total")]
        public Decimal Total { get; set; }
        [Description("RegEstado")]
        public Int32 RegEstado { get; set; }
        [Description("COD_UCUENTA")]
        public String COD_UCUENTA { get; set; }
        public List<Ent_ESPECIECM> especies { get; set; }
        public Ent_DETALLECALCULOMULTA()
        {            
        }
    }
}
