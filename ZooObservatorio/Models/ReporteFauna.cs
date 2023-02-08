using System.Collections.Generic;
using CEntidad = CapaEntidad.DOC.Ent_Reporte_Historial_TH;
using CEntidadINF = CapaEntidad.DOC.Ent_INFORME;
namespace ZooObservatorio.Models
{
    public class ReporteFauna
    {
        public string descZoologico { get; set; }
        public string descZoocriadero { get; set; }
        public IEnumerable<CEntidad> ListRegion { get; set; }
        public IEnumerable<CEntidad> ListModalidad { get; set; }
        public IEnumerable<CEntidad> ListReporteFauna { get; set; }
        public CEntidad oCEntidad { get; set; }
        public IEnumerable<CEntidad> ListEspecies { get; set; }
        public IEnumerable<CEntidadINF> ListEspeciesFotos { get; set; }
        public string urlGeneral { get; set; }
        public string mensajeError { get; set; }
        public int ranking { get; set; }
        public string fecha_observ { get; set; }
    }
}