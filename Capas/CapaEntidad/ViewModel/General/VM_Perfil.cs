namespace CapaEntidad.ViewModel.General
{
    public class VM_Perfil
    {
        public string id { get; set; }
        public string descr { get; set; }
        public int estado { get; set; }
        public string lblTitulo { get; set; }
        public bool act { get; set; }
        public int? idClasificacion { get; set; }
        public string descrClasificacion { get; set; }
        public int? idSubClasificacion { get; set; }
        public string descrSubClasificacion { get; set; }
    }
}
