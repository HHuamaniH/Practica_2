using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad.ViewModel
{
   public class VM_TRAMITE
    {
        public VM_TRAMITE()
        {
            this.fechaRegistro = DateTime.Now;
        }

        public int cCodTipoDoc { get; set; }
        public string cDescTipoDoc { get; set; }
        public int iCodOficina { get; set; }
        public string cAsunto { get; set; }
        public string cObservaciones { get; set; }
        public string cnNumFolio { get; set; }
        //public int iCodTrabajadorLogin { get; set; }
        public string cod_THabilitante { get; set; }
        public string cod_Informe { get; set; }
        public int iCodTramite { get; set; }
        public string cCodificacion { get; set; }
        public string password { get; set; }
        public DateTime fechaRegistro { get; set; }

        public int trabajadorId { get; set; }
        public string trabajador { get; set; }
        public int perfilId { get; set; }
        public int indicacionId { get; set; }
        public string prioridad { get; set; }
        public int nFlgEstado { get; set; }
        public string cUsuario { get; set; }

        public List<VM_Cbo> lstTipoDocumento { get; set; }
        public List<VM_Cbo> lstOficina { get; set; }
        public List<VM_TRAMITE_REFERENCIA> lstReferencias { get; set; }
    }
    public class VM_TRAMITE_MOVIMIENTO
    {
        public int iCodTramite { get; set; }
        public int? iCodTrabajadorRegistro { get; set; }
        public string nFlgTipoDoc { get; set; }
        public int? iCodOficinaOrigen { get; set; }
        public int? iCodOficinaDerivar { get; set; }
        public int? iCodTrabajadorDerivar { get; set; }
        public int? iCodIndicacionDerivar { get; set; }
        public string cPrioridadDerivar { get; set; }
        public string cAsuntoDerivar { get; set; }
        public string cObservacionesDerivar { get; set; }
        public DateTime? fFecDerivar { get; set; }
        public DateTime? fFecMovimiento { get; set; }
        public int? nEstadoMovimiento { get; set; }
        public int? cFlgTipoMovimiento { get; set; }
        public int? cFlgOficina { get; set; }
        public int? nflgtra { get; set; }
        public int? nflgpri { get; set; }
        public int? cCodTipoDocDerivar { get; set; }
        public int? nFlgEnvio { get; set; }
        public int iCodTrabajadorPerfil { get; set; }
    }

    public class VM_TRAMITE_REFERENCIA
    {
        public int iCodTramite { get; set; }
        public int? iCodTramiteRef { get; set; }
        public string cReferencia { get; set; }
        public string cCodSession { get; set; }
        public string cDesEstado { get; set; }
        public int? iCodTipo { get; set; }
    }
}
