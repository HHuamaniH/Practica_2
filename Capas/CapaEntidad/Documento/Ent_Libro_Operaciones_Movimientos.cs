using System;
using System.ComponentModel;

namespace CapaEntidad.DOC
{
    public class Ent_Libro_Operaciones_Movimientos
    {
        //[Description("LIBRO_OPERACIONES_MOV_ID")]
        //public long LIBRO_OPERACIONES_MOV_ID { get; set; }
        [Description("LIBRO_OPERACIONES_ID")]
        public long LIBRO_OPERACIONES_ID { get; set; }
        [Category("FECHA"), Description("TALA_F")]
        public DateTime? TALA_F { get; set; }
        [Description("TALA_D1")]
        public decimal? TALA_D1 { get; set; }
        [Description("TALA_D2")]
        public decimal? TALA_D2 { get; set; }
        [Description("TALA_L")]
        public decimal? TALA_L { get; set; }
        [Description("TALA_V")]
        public decimal? TALA_V { get; set; }
        [Description("TALA_OBS")]
        public string TALA_OBS { get; set; }
        [Description("ARRASTRE_CT")]
        public string ARRASTRE_CT { get; set; }
        [Category("FECHA"), Description("ARRASTRE_F")]
        public DateTime? ARRASTRE_F { get; set; }
        [Description("ARRASTRE_D1")]
        public decimal? ARRASTRE_D1 { get; set; }
        [Description("ARRASTRE_D2")]
        public decimal? ARRASTRE_D2 { get; set; }
        [Description("ARRASTRE_L")]
        public decimal? ARRASTRE_L { get; set; }
        [Description("ARRASTRE_V")]
        public decimal? ARRASTRE_V { get; set; }
        [Description("TROZADO_CT")]
        public string TROZADO_CT { get; set; }
        [Category("FECHA"), Description("TROZADO_F")]
        public DateTime? TROZADO_F { get; set; }
        [Description("TROZADO_D1")]
        public decimal? TROZADO_D1 { get; set; }
        [Description("TROZADO_D2")]
        public decimal? TROZADO_D2 { get; set; }
        [Description("TROZADO_L")]
        public decimal? TROZADO_L { get; set; }
        [Description("TROZADO_V")]
        public decimal? TROZADO_V { get; set; }
        [Description("TRANSPORTE_N_GTF")]
        public string TRANSPORTE_N_GTF { get; set; }
        [Category("FECHA"), Description("TRANSPORTE_F_EMISION")]
        public DateTime? TRANSPORTE_F_EMISION { get; set; }
        [Description("TRANSPORTE_DESTINO")]
        public string TRANSPORTE_DESTINO { get; set; }
        [Description("TRANSPORTE_CONDUCTOR")]
        public string TRANSPORTE_CONDUCTOR { get; set; }
        [Description("TRANSPORTE_PLACA")]
        public string TRANSPORTE_PLACA { get; set; }
        [Description("CONDICION")]
        public string CONDICION { get; set; }
        public Ent_Libro_Operaciones_Movimientos()
        {

        }
    }
}
