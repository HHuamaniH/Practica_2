namespace CapaEntidad.ViewModel
{
    public class VM_PlanManejoEspecies
    {
        public int cod_paspeq_plan_trabajo_especies { get; set; }
        public string cod_especies { get; set; }
        public int cod_paspeq_detalle_mensual { get; set; }
        public string num_thabilitante { get; set; }
        public string nombre_poa { get; set; }
        public string especie { get; set; }
        public int aprovechables_minimo { get; set; }
        public int semilleros_minimo { get; set; }
        public int aprovechables_supervisar { get; set; }
        public int semilleros_supervisar { get; set; }
        public int total { get; set; }
        public int cantidad_aprobada { get; set; }
        public double volumen_aprobado { get; set; }
    }
}
