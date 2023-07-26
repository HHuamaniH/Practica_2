using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad.DOC
{
  public  class Ent_CAPACITACION_CONSTANCIA
    {
        public string COD_CONSTANCIA { get; set; }
        public string COD_CAPACITACION { get; set; }
        public int CORRELATIVO { get; set; }
        public int CORRELATIVO_ANIO { get; set; }
        public string NRO_CONSTANCIA { get; set; }
        public string MODALIDAD { get; set; }
        public string ARCHIVO { get; set; }
        public string ARCHIVO_COD { get; set; }
        public int FLAG_ASIGNADO { get; set; }
        public string COD_UCUENTA { get; set; }
        public DateTime FECHA_CREACION { get; set; }
        public int ESTADO { get; set; }
        public string ESTADO_TEXT { get; set; }
        public string PARTICIPANTE { get; set; }
    }
}
