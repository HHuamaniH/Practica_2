using CapaEntidad.DOC;
using System;
using System.Collections.Generic;

namespace CapaEntidad.ViewModel
{
    public class VM_CertificadoPlanta
    {         
        public string hdCodigo_CertificadoPlanta { get; set; }
        public string hdCodigo_Thabilitante { get; set; }
        public string ItemTitulo { get; set; }
        public string hdfManRegEstado { get; set; }
        public string txtItemNumero { get; set; }
        public string txtItemModalidad { get; set; }
        public string txtItemTitular { get; set; }
        public string txtItemUbicacion { get; set; }


        public string txtItemNumeroInscripcion { get; set; }
        public string txtItemFechaInscripcion { get; set; }
        public string txtItemAreaTotal { get; set; }
        public string txtItemFechaEstablecimiento { get; set; }
        public string ddlZonaUTMId { get; set; }
        public string txtCoorEste { get; set; }
        public string txtCoorNorte { get; set; }
        public string txtItemObservacion { get; set; }
        public string appClient { get; set; }
        public string appData { get; set; }        
        public int opRegresar { get; set; }        

        public VM_ControlCalidad_2 vmControlCalidad { get; set; }
        public List<Ent_EspeciesEstablecidas> tbEspeciesEstablecidas { get; set; }
        public List<Ent_EliTabla> tbEliTABLA { get; set; }
        public VM_CertificadoPlanta()
        {
            vmControlCalidad = new VM_ControlCalidad_2();
            tbEspeciesEstablecidas = new List<Ent_EspeciesEstablecidas>();
            tbEliTABLA = new List<Ent_EliTabla>();
        }

    }
}
