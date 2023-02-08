using CapaEntidad.DOC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad.ViewModel.Documento
{
   public class VM_Itenerario_List
    {
        public string COD_BITACORA { get; set; }
        public string NUM_THABILITANTE { get; set; }
        public string OD { get; set; }
        public string SUPERVISOR { get; set; }
        public string CARTA_NOTIFICACION { get; set; }
        public string SUPERVISADO { get; set; }
        public string TIPO_INFORME { get; set; }
        public DateTime FECHA { get; set; }
        public string FECHA_TEXT { get; set; }
        public int ANIO_REGISTRO { get; set; }
        public string MES_REGISTRO { get; set; }
        public string USUARIO { get; set; }
        public DateTime? FECHA_HORA_SALIDA { get; set; }
        public DateTime? FECHA_RECEPCION_CHEQUE { get; set; }
        public DateTime? FECHA_COBRO_CHEQUE { get; set; }
    }
    public class VM_Itenerario
    {
        public string id { get; set; }
        public IEnumerable<VM_Cbo> od { get; set; }
        public string odId { get; set; }
        public string fechaSalida { get; set; }
        public string fechaRecepcionCheque { get; set; }
        public string fechaCobroCheque { get; set; }

        public string fechaRetornoCampo { get; set; }
        public string fechaInicioLabores { get; set; }
        public string ddPAuxiliosId { get; set; }
        public IEnumerable<VM_Cbo> ddPAuxilios { get; set; }
        public string ddIncidentesId { get; set; }
        public IEnumerable<VM_Cbo> ddIncidentes { get; set; }
        public string observacion { get; set; }
        public List<Ent_GENEPERSONA> tbSupervisor { get; set; }      
        public List<Ent_BITACORA_SUPER> ListEliTABLA { get; set; }
        public List<Ent_BITACORA_SUPER> lstSupervisiones { get; set; }
        public VM_Itenerario()
        {
            id = "0";
        }
    }
}
