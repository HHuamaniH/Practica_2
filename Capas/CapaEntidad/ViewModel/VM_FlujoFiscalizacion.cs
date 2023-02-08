using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad.ViewModel
{
    public class VM_FlujoFiscalizacion
    {
        public int idTab { get; set; }
        public int idReporte { get; set; }
        public string cellReporte { get; set; }
        public string txtnomconsulta { get; set; }

        //Variables de menú Datos DFFFS
        public string txtfechainiDFFFS { get; set; }
        public string txtfechafinDFFFS { get; set; }
        public int cantDFFFS1 { get; set; }
        public int cantDFFFS2 { get; set; }
        public int cantDFFFS3 { get; set; }
        public int cantDFFFS4 { get; set; }
        public int cantDFFFS5 { get; set; }
        public int cantDFFFS5_1 { get; set; }
        public int cantDFFFS5_2 { get; set; }
        public int cantDFFFS5_3 { get; set; }
        public int cantDFFFS6 { get; set; }
        public int cantDFFFS7 { get; set; }
        public int cantDFFFS8 { get; set; }
        public int cantDFFFS9 { get; set; }
        public int cantDFFFS10 { get; set; }
        public int cantDFFFS11 { get; set; }
        public int cantDFFFS12 { get; set; }
        public int cantDFFFS13 { get; set; }
        public int cantDFFFS14 { get; set; }
        public int cantDFFFS15 { get; set; }
        public int cantDFFFS16 { get; set; }
        public int cantDFFFS17 { get; set; }
        public int cantDFFFS18 { get; set; }
        public int cantDFFFS19 { get; set; }
        public int cantDFFFS20 { get; set; }
        public int cantDFFFS21 { get; set; }
        public int cantDFFFS22 { get; set; }
        public int cantDFFFS23 { get; set; }
        public int cantDFFFS24 { get; set; }
        public int cantDFFFS25 { get; set; }
        public int cantDFFFS26 { get; set; }
        public int cantDFFFS27 { get; set; }

        //Variables de menú Datos Subdirección
        public IEnumerable<VM_Cbo> ddlSubdireccion { get; set; }
        public string ddlSubdireccionId { get; set; }
        public string txtfechainiSubdireccion { get; set; }
        public string txtfechafinSubdireccion { get; set; }
        public int cantSubdireccion1 { get; set; }
        public int cantSubdireccion2 { get; set; }
        public int cantSubdireccion3 { get; set; }
        public int cantSubdireccion3_1 { get; set; }
        public int cantSubdireccion3_2 { get; set; }
        public int cantSubdireccion3_3 { get; set; }
        public int cantSubdireccion4 { get; set; }
        public int cantSubdireccion5 { get; set; }
        public int cantSubdireccion6 { get; set; }
        public int cantSubdireccion7 { get; set; }
        public int cantSubdireccion8 { get; set; }
        public int cantSubdireccion9 { get; set; }
        public int cantSubdireccion10 { get; set; }
        public int cantSubdireccion11 { get; set; }
        public int cantSubdireccion12 { get; set; }

        //Variables de menú Indicador MAPRO
        public IEnumerable<VM_Cbo> ddlSubdirMAPRO { get; set; }
        public string ddlSubdirMAPROId { get; set; }
        public bool chkFechaini1 { get; set; }
        public string txtfechainiMAPRO1 { get; set; }
        public string txtfechafinMAPRO1 { get; set; }
        public bool chkFechaini2 { get; set; }
        public string txtfechainiMAPRO2 { get; set; }
        public string txtfechafinMAPRO2 { get; set; }
        public bool chkFechaini3 { get; set; }
        public string txtfechainiMAPRO3 { get; set; }
        public string txtfechafinMAPRO3 { get; set; }
        public bool chkFechaini4 { get; set; }
        public string txtfechainiMAPRO4 { get; set; }
        public string txtfechafinMAPRO4 { get; set; }
        public bool chkFechaini5 { get; set; }
        public string txtfechainiMAPRO5 { get; set; }
        public string txtfechafinMAPRO5 { get; set; }
        public bool chkFechaini6 { get; set; }
        public string txtfechainiMAPRO6 { get; set; }
        public string txtfechafinMAPRO6 { get; set; }
        public bool chkFechaini7 { get; set; }
        public string txtfechainiMAPRO7 { get; set; }
        public string txtfechafinMAPRO7 { get; set; }
        public bool chkFechaini8 { get; set; }
        public string txtfechainiMAPRO8 { get; set; }
        public string txtfechafinMAPRO8 { get; set; }
        public int opcConsulta { get; set; }
        public int cantMAPRO1 { get; set; }
        public int cantMAPRO2 { get; set; }
        public double cantMAPRO3 { get; set; }
        public int cantMAPRO4 { get; set; }
        public int cantMAPRO5 { get; set; }
        public double cantMAPRO6 { get; set; }
        public int cantMAPRO7 { get; set; }
        public int cantMAPRO8 { get; set; }
        public double cantMAPRO9 { get; set; }
        public int cantMAPRO10 { get; set; }
        public int cantMAPRO11 { get; set; }
        public double cantMAPRO12 { get; set; }


        //Variables de menú Indicador PEI
        public IEnumerable<VM_Cbo> ddlSubdirPEI { get; set; }
        public string ddlSubdirPEIId { get; set; }
        public bool chkFechainiPEI1 { get; set; }
        public string txtfechainiPEI1 { get; set; }
        public string txtfechafinPEI1 { get; set; }
        public bool chkFechainiPEI2 { get; set; }
        public string txtfechainiPEI2 { get; set; }
        public string txtfechafinPEI2 { get; set; }
        public int cantPEI1 { get; set; }
        public int cantPEI2 { get; set; }
        public double cantPEI3 { get; set; }
    }
}
