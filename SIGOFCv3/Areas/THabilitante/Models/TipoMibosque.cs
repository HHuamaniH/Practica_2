using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIGOFCv3.Areas.THabilitante.Models
{
    public class TipoMibosque
    {
        public int currentPage { set; get; }

        public int totalPages { set; get; }

        public int totalItems { set; get; }
        public List<Tipo> result { set; get; }
    }
    public class Tipo
    {
        public string vaNumGrupoTipo { set; get; }
        public string vaNumTipo { set; get; }
        public string vaTipoDescripcion { set; get; }
        public string vaNumObligacion { set; get; }
        public string faFechaRegistro { set; get; }
        public string faFechaActualizacion { set; get; }
        public string faFechaEliminacion { set; get; }
        public string vaUsuarioRegistro { set; get; }
        public string vaUsuarioActualizacion { set; get; }
    }
}