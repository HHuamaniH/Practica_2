using System.Collections.Generic;
using System.ComponentModel;

namespace CapaEntidad.DOC
{
    public class Ent_Libro_Operaciones
    {
        [Description("LIBRO_OPERACIONES_ID")]
        public long LIBRO_OPERACIONES_ID { get; set; }
        [Description("LIBRO_OPERACIONES_TH_ID")]
        public long LIBRO_OPERACIONES_TH_ID { get; set; }
        [Description("LIBRO_OPERACIONES_ARCHIVO_ID")]
        public long LIBRO_OPERACIONES_ARCHIVO_ID { get; set; }
        [Description("CODIGO")]
        public string CODIGO { get; set; }
        [Description("NOMBRE_ESPECIE")]
        public string NOMBRE_ESPECIE { get; set; }
        [Description("PC")]
        public string PC { get; set; }
        [Description("FAJA")]
        public string FAJA { get; set; }
        [Description("DAP")]
        public decimal? DAP { get; set; }
        [Description("HC")]
        public decimal? HC { get; set; }
        [Description("VOL")]
        public decimal? VOL { get; set; }
        [Description("CF")]
        public string CF { get; set; }
        [Description("DTB")]
        public decimal? DTB { get; set; }
        [Description("DTE")]
        public decimal? DTE { get; set; }
        [Description("LADO")]
        public string LADO { get; set; }
        [Description("COORDENADA_X")]
        public string COORDENADA_X { get; set; }
        [Description("COORDENADA_Y")]
        public string COORDENADA_Y { get; set; }
        [Description("CONDICION")]
        public string CONDICION { get; set; }
        [Description("OBSERVACION")]
        public string OBSERVACION { get; set; }
        [Description("COD_UCUENTA")]
        public string COD_UCUENTA { get; set; }
        [Description("OUTPUTPARAM02")]
        public string OUTPUTPARAM02 { get; set; }
        public Ent_Libro_Operaciones()
        {
            this.LIBRO_OPERACIONES_ID = -1;
        }
        public List<Ent_Libro_Operaciones_Movimientos> detalleMovimientos { get; set; }
    }
}
