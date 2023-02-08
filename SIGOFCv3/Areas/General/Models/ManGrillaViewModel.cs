using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace SIGOFCv3.Areas.General.Models
{
    public class ManGrillaViewModel
    {
        public string tipoFormulario { get; set; }
        //0-aquellos que no requieran buscar un dato inicialmente
        public int tipoContenedor { get; set; }
        /// 0 Sin ventana Menu, 1 Con ventana Modalidad/categoria, 2 Con ventana para buscar TH</param> 1-Thabiitante,2-documentos de fiscalizacion, 3-devolucion de madera 
        /// 4-informe de suspensión e informe de supervisión, 6-otros documentos (informe técnico medidas correctivas)
        public string hdfTipoFormulario { get; set; }
        public string busFormulario { get; set; }
        public string busCriterio { get; set; }
        public string busModuloConsulta { get; set; }
        public String idModulo { get; set; }
        public Int32 idMenu { get; set; }
        public String titleMenu { get; set; }
        public IEnumerable<SelectListItem> cboOpciones { get; set; }
        public IEnumerable<SelectListItem> cboOpciones1 { get; set; }
        //public IEnumerable<Ent_THABILITANTE> listMComboModalidad { get; set; }
        //  public string cboManModalidad { get; set; }
        //  public bool chkManConsolidado { get; set; }
        // public string codigoThabilitante { get; set; }
        // public string descripcionThabilitante { get; set; }
        // public int Nuevo { get; set; }
        //public string modalId { get; set; }

    }
}