using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SIGOFCv3.Areas.THabilitante.Models
{
    public class Obligacion
    {
        public string tipoFormulario { get; set; }
        public int tipoContenedor { get; set; }
        public string hdfTipoFormulario { get; set; }
        public string busFormulario { get; set; }
        public string busCriterio { get; set; }
        public string busModuloConsulta { get; set; }
        public string idTipoObligacion { get; set; }
        public string idObligacion { get; set; }
        public String idModulo { get; set; }
        public Int32 idMenu { get; set; }
        public String titleMenu { get; set; }
        public IEnumerable<SelectListItem> cboOpciones { get; set; }
        public TituloHabilitante tituloHabilitante { set; get; }
        public PlanManejo planManejo { set; get; }
        public dynamic dataObligacion { set; get; }
    }
    public class TituloHabilitante
    {
        public int currentPage { set; get; }

        public int totalPages { set; get; }

        public Int64 totalItems { set; get; }
        public List<TH> result { set; get; }
    }
    public class TH
    {
        public string id { set; get; }
        public Int64 inIdTituloHabilitante { set; get; }
        public Int64 inIdTitular { set; get; }
        public Int64 inIdRegente { set; get; }
        public Int64 inCodigo { set; get; }
        public string vaCodigo { set; get; }
        public string vaDepartamento { set; get; }
        public string vaProvincia { set; get; }
        public string vaDistrito { set; get; }
        public string faFechaRegistro { set; get; }
        public string faFechaActualizacion { set; get; }
        public string faFechaEliminacion { set; get; }
        public string vaUsuarioRegistro { set; get; }
        public string vaUsuarioActualizacion { set; get; }
    }
    public class PlanManejo {
        public Int64 currentPage { set; get; }

        public Int64 totalPages { set; get; }

        public Int64 totalItems { set; get; }
        public List<PM> result { set; get; }
    }
    public class PM {
    
        public Int64 inIdPlanManejo { set; get; }
        public Int64 inIdTituloHabilitante { set; get; }
        public string vaNumTituloHabilitante { set; get; }
        public string vaTitularActual { set; get; }
        public string varLegal { set; get; }
        public string vaModalidad { set; get; }
        public string vaodAmbito { set; get; }
        public Int64 inAreaTh { set; get; }
        public string vaCaducidad { set; get; }
        public string vaTipoPlan { set; get; }
        public string vaNombrePOA { set; get; }
        public string vaResolucionAprueba { set; get; }
        public string faFechaAprobacion { set; get; }
        public Int64 inAreaPOA { set; get; }
        public Int64 inConsultorCodigo { set; get; }
    }
}