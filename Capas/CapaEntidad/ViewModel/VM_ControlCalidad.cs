using System.Collections.Generic;

namespace CapaEntidad.ViewModel
{
    public class VM_ControlCalidad
    {
        public string COD_ESTADO_DOC { get; set; }
        public string OBSERVACIONES_CONTROL { get; set; }
        public bool OBSERV_SUBSANAR { get; set; }
        public string USUARIO_CONTROL { get; set; }
    }

    public class VM_ControlCalidad_2
    {
        public string hdFrmControl { get; set; }
        public string hdIdControl { get; set; }
        public IEnumerable<VM_Cbo> ddlIndicador { get; set; }
      
        public string ddlIndicadorId { get; set; }
      
        public bool ddlIndicadorEnable { get; set; }
        public bool chkObsSubsanada { get; set; }
        public bool hdnDisableControl { get; set; }
        public string txtControlCalidadObservaciones { get; set; }
        public string txtUsuarioRegistro { get; set; }
        public string txtUsuarioControl { get; set; }
        public string COD_ESTADO_DOC { get; set; }
        public string VALIAS_ROL { get; set; }
        public VM_ControlCalidad_2()
        {
            ddlIndicadorId = "0000000";
            ddlIndicadorEnable = true;
        }
    }
}
