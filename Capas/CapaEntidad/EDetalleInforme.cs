using System.ComponentModel;

namespace CapaEntidad
{
    public class EDetalleInforme
    {
        [Description("id_informe_supervision")]
        public string id_informe_supervision { get; set; }
        [Description("iddetinforme")]
        public int iddetinforme { get; set; }
        [Description("descripcion")]
        public string descripcion { get; set; }
        [Description("idcategoria")]
        public int idcategoria { get; set; }
        [Description("idsubcategoria")]
        public int idsubcategoria { get; set; }
        [Description("iddetsubcategoria")]
        public int iddetsubcategoria { get; set; }
        [Description("iddetsectorsubcategoria")]
        public int iddetsectorsubcategoria { get; set; }



    }
}
