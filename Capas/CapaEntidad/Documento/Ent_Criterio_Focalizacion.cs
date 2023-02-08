using System;

namespace CapaEntidad.DOC
{
    public class Ent_Criterio_Focalizacion
    {
        public String CODIGO { get; set; }
        public String DESCRIPCION { get; set; }
        public Decimal? PUNTAJE { get; set; }

        public Ent_Criterio_Focalizacion()
        {
            PUNTAJE = -1;
        }
    }
}
