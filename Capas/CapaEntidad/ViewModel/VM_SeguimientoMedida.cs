using System.Collections.Generic;

namespace CapaEntidad.ViewModel
{
    public class VM_SeguimientoMedida
    {
        public string lblTituloCabecera { get; set; }
        public string lblTituloEstado { get; set; }
        public string hdfCodResodirec { get; set; }
        public string txtTitular { get; set; }
        public string txtNumTHabilitante { get; set; }
        public string txtModalidad { get; set; }
        public string txtNumExpediente { get; set; }

        public List<CapaEntidad.DOC.Ent_RESODIREC_MEDIDA> tbMedidaCorrectiva { get; set; }
        public List<CapaEntidad.DOC.Ent_RESODIREC_MEDIDA> tbMandato { get; set; }

        //public int hdfidCodTramite { get; set; }
        //public int hdfidCodMandato { get; set; }
        //public int hdfidCodMC { get; set; }
        //public string TITULO { get; set; }
        //
        //public string DESCRIPCION_MED_CORRECTIVAS { get; set; }
        //public string FECHA { get; set; }
        //public string MANDATO { get; set; }
        //public string CANT_DIAS { get; set; }
        //public string ICODMANDATO { get; set; }
        //public string FECHA_INI { get; set; }
        //public string FECHA_FIN { get; set; }
        //public string FECHA_FIN2 { get; set; }
        //public int iCodMC { get; set; }
        //public Boolean REQUIEREPLAZO { get; set; }
        //public int PLAZO_DIA { get; set; }
        //public int ORIGEN { get; set; }
        //public int PLAZO_MES { get; set; }
        //public int COD_EXPEDIENTE { get; set; }
        //public IEnumerable<VM_Cbo> ddlEstado { get; set; }
        //public string ddlEstadoID { get; set; }

        public VM_SeguimientoMedida()
        {
            //ddlEstado = new List<VM_Cbo>()
            //{
            //        new VM_Cbo() { Value = "SN",Text = "Seleccionar" },
            //        new VM_Cbo() { Value = "SI",Text = "SI" },
            //        new VM_Cbo() { Value = "NO",Text = "NO" }
            //};
        }
    }
}
