using System.Collections.Generic;
//utilizamos la capa entidad
using CEntidad = CapaEntidad.DOC.Ent_Reporte_Historial_TH;

namespace HistorialTH.Models
{
    public class HistorialModel
    {
        public CEntidad oCEntidad { get; set; }
        public IEnumerable<CEntidad> listPOA { get; set; }
        public string mensajeError { get; set; }
        public string COD_THABILITANTE { get; set; }
        public string Descripcion { get; set; }
        public string Tipo { get; set; }
        public IEnumerable<CEntidad> listEspecies { get; set; }
    }
}