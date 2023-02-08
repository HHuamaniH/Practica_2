namespace CapaEntidad.ViewModel.DOC
{
    public class VM_SOLINF_THABILITANTE
    {
        public int cod_Tramite_Id { get; set; }
        public string nro_Referencia { get; set; }
        public string entidad { get; set; }
        public string asunto { get; set; }
        public string obs { get; set; }
        public int nFlgTransferencia { get; set; }
    }
    public class VM_SOLINF_THABILITANTE_DETALLE
    {
        public int cod_Tramite_Id { get; set; }
        public int cod_secuencial { get; set; }
        public string cod_TH { get; set; }
        public string num_TH { get; set; }
        public int num_poa { get; set; }
        public string nombre_poa { get; set; }
        public string res_poa { get; set; }
        public string estado_supervision { get; set; }
        public string obs { get; set; }
        public string registro_sigo { get; set; }
        public int estado { get; set; }
    }
}
