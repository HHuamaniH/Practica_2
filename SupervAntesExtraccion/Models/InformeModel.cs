using System.Collections.Generic;

// importaciones de la capas de entidad
using CEntidad = CapaEntidad.DOC.Ent_Reporte_Historial_TH;

namespace SupervAntesExtraccion.Models
{
    public class InformeModel
    {
        public CEntidad oCEntidad { get; set; }
        public string Descripcion { get; set; }
        public string tipo { get; set; }
        public string mensajeError { get; set; }
        public string fecha { get; set; }
        public IEnumerable<CEntidad> ListEspecie { get; set; }
        public IEnumerable<CEntidad> ListInformSup { get; set; }
    }
}