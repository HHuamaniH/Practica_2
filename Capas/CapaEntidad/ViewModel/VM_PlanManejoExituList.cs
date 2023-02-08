using System.Collections.Generic;

namespace CapaEntidad.ViewModel
{
    public class VM_PlanManejoExituList
    {
        public string COD_PMANEJO { get; set; }
        public string COD_THABILITANTE { get; set; }
        public string FECHA { get; set; }
        public string FECHA_PRESENTACION { get; set; }
        public string MODALIDAD { get; set; }
        public string NUM_THABILITANTE { get; set; }

        public string PERSONA_TITULAR { get; set; }
        public string ARESOLUCION_NUM { get; set; }
        public string COD_MTIPO { get; set; }
        public string ESTADO_ORIGEN_TIPO { get; set; }
        public string INDICADOR { get; set; }
        public string ESTADO_ORIGEN { get; set; }
        public string HIJO_COD_PMANEJO { get; set; }
        public int HIJO_NIVEL { get; set; }
        public int contador { get; set; }
        public string LISTA_INDEX { get; set; }
        public List<VM_PlanManejoExituList> ListManTHabilitante { get; set; }
        public List<VM_PlanManejoExituList> ListManPlanManejo { get; set; }
        public List<VM_PlanManejoExituList> ListManPlanManejoItem { get; set; }
        public List<VM_PlanManejoExituList> ListManPlanManejoDetItem { get; set; }

    }
}
