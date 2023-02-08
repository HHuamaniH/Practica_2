using System;
using System.Collections.Generic;


namespace SIGOFCv3.Areas.THabilitante.Models
{

    public class TipoSelect
    {

        public int currentPage { set; get; }

        public int totalPages { set; get; }

        public int totalItems { set; get; }
        public List<Result> result { set; get; }
        //public Obligacion() {
        //    currentPage = -1;
        //}
    }

    public class Result
    {
        public Int64 inIdTituloHabilitante { set; get; }
        public Int64 inIdPlanManejo { set; get; }
        public int inTipoObligacion { set; get; }
        public string inIdObligacion { set; get; }
        public string vaNombreObligacion { set; get; }
        public string faFechaPresentacion { set; get; }
        public string vaEstado { set; get; }
        public string faFechaActualizacion { set; get; }
        public string vaUsuarioActualizacion { set; get; }
    }
}