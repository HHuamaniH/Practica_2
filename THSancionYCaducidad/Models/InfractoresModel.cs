using System.Collections.Generic;

// importaciones de la capas de entidad
using CEntidad = CapaEntidad.DOC.Ent_Reporte_Historial_TH;

namespace THSAncionYCaducidad.Models
{
    public class InfractoresModel
    {
        public IEnumerable<CEntidad> ListRegion { get; set; }
        public IEnumerable<CEntidad> ListModalidad { get; set; }
        public IEnumerable<CEntidad> ListInfractores { get; set; }
        public CEntidad oCEntidad { get; set; }
        public string Descripcion { get; set; }
        public string tipo { get; set; }
        public IEnumerable<CEntidad> ListPOA { get; set; }
        public string mensajeError { get; set; }
        public string fecha { get; set; }
        public IEnumerable<CEntidad> ListEspecie { get; set; }
    }
}