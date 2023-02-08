using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CapaEntidad.GENE
{
    public class Ent_ESPECIECM
    {
        [Description("CodCalculoMulta")]
        public String CodCalculoMulta { get; set; }
        [Description("literal")]
        public String literal { get; set; }
        [Description("cod_especie")]
        public String cod_especie { get; set; }
        [Description("especie")]
        public String especie { get; set; }
        [Description("margen")]
        public Decimal margen { get; set; }
        [Description("volumen")]
        public Decimal volumen { get; set; }
        [Description("ipc")]
        public Decimal ipc { get; set; }
        [Description("fechaipc")]
        public Decimal fechaipc { get; set; }
        [Description("beneficio")]
        public Decimal beneficio { get; set; }
        [Description("ven")]
        public Decimal ven { get; set; }
        [Description("gravedad")]
        public Decimal gravedad { get; set; }
        [Description("afectacion")]
        public Decimal afectacion { get; set; }
        [Description("regeneracion")]
        public Decimal regeneracion { get; set; }
        [Description("vengar")]
        public Decimal vengar { get; set; }
        [Description("RegEstado")]
        public Int32 RegEstado { get; set; }
        [Description("COD_UCUENTA")]
        public String COD_UCUENTA { get; set; }
        public Ent_ESPECIECM()
        {
        }
    }
}
