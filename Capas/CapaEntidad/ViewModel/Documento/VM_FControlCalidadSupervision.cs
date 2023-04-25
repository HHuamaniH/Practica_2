using System.Collections.Generic;

namespace CapaEntidad.ViewModel.DOC
{
    public class VM_FControlCalidadSupervision
    {
        public string conInforme { get; set; }
        public string fechaRecepcionIS { get; set; }
        public string eJefeODC { get; set; }
        public string eJefeODCID { get; set; }
        public string codPerfil { get; set; }
        public List<VM_FControlCalidadSupervision_Det> lstISupervision { get; set; }
        public List<VM_FControlCalidadSupervision_Det> lstDatosReg { get; set; }
    }
    public class VM_FControlCalidadSupervision_Det
    {
        public int id { get; set; }
        public string padre { get; set; }
        public string hijo { get; set; }
        public int ORDEN_HIJO { get; set; }
        public string codigo { get; set; }
        public int SUB_GRUPO { get; set; }
        public string PRESENTA_OBS { get; set; }
        public string LEVANTO_OBS { get; set; }
        public string OBS_ADICIONALES { get; set; }
        public string DETALLE { get; set; }
        public string FECHA_VARIOS { get; set; }
        public int cantHijos { get; set; }
        public int est { get; set; }
        public int ORDEN_PADRE { get; set; }
        public int CANTIDAD { get; set; }
    }
}
