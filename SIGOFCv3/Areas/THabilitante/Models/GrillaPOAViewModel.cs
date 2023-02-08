namespace SIGOFCv3.Areas.THabilitante.Models
{
    public class GrillaPOAViewModel
    {
        //1 es nuevo 0 si es para modificar
        public int RegEstado { get; set; }
        public string ModalId { get; set; }
        //Indice de la grilla para poder modificar
        public int ListIndex { get; set; }
        public string Titulo { get; set; }

    }
}