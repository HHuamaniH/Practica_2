using CapaEntidad.DOC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad.ViewModel
{
    public class VM_TribunalNotificacion2da
    {
        public string lblTituloCabecera { get; set; }
        public string lblTituloDatosG { get; set; }
        public string lblTituloEstado { get; set; }
        public VM_ControlCalidad_2 vmControlCalidad { get; set; }
        public string hdfCodNotificacion { get; set; }
        public string hdfCodTipoNotificacion { get; set; }
        public string txtTipoNotificacion { get; set; }
        public string hdfCodNotificador { get; set; }
        public string txtNotificador { get; set; }
        public string txtNumCarta { get; set; }
        public string txtFechaEmision { get; set; }
        public string txtFechaRecepcion { get; set; }
        public string txtFechaEntrega { get; set; }
        public string txtFechaNotificacion { get; set; }
        public string txtFechaDevolucion { get; set; }

        public IEnumerable<VM_Cbo> ddlOd { get; set; }
        public string ddlOdId { get; set; }
        public IEnumerable<VM_Cbo> ddlEstadoCargo { get; set; }
        public string ddlEstadoCargoId { get; set; }
        public IEnumerable<VM_Cbo> ddlTitular { get; set; }
        public string ddlTitularId { get; set; }
        public IEnumerable<VM_Cbo> ddlZonaUtm { get; set; }
        public string ddlZonaUtmId { get; set; }
        public IEnumerable<VM_Cbo> ddlEntidad { get; set; }
        public string ddlEntidadId { get; set; }

        public bool chkPrimeraVisita { get; set; }
        public bool chkSegundaVisita { get; set; }
        public string txtFechaPVisita { get; set; }
        public string txtFechaSVisita { get; set; }
        public string radSituacion { get; set; }
        public string txtParentesco { get; set; }
        public string hdfCodNotificado { get; set; }
        public string txtNotificado { get; set; }
        public string txtUbigeo { get; set; }
        public string hdfUbigeo { get; set; }
        public string txtDireccion { get; set; }
        public bool chkActa { get; set; }
        public string radMedidor { get; set; }
        public string txtNumMedidor { get; set; }
        public string txtMatFachada { get; set; }
        public string txtMatPuerta { get; set; }
        public string txtNumPisos { get; set; }
        public string txtCoordEste { get; set; }
        public string txtCoordNorte { get; set; }
        public string txtTelefono { get; set; }
        public bool chkDeclaracionJurada { get; set; }
        public string txtCalleDJ { get; set; }
        public string txtLugarDJ { get; set; }
        public string txtUbigeoDJ { get; set; }
        public string hdfUbigeoDJ { get; set; }
        public string txtReferenciaDJ { get; set; }
        public string txtObservaciones { get; set; }
        public string txtDocAdjuntos { get; set; }
        public string txtTituloModal { get; set; }

        public int RegEstado { get; set; }
        public string hdfCodigoNotificacionAlerta { get; set; }
        public string hdfIdOrigenRegistro { get; set; }
        public string lbldocumento { get; set; }
        public string txtTituloDocumento { get; set; }
        public string lblTituloItemDoc { get; set; }
        public string lblTituloItemFechaNotif { get; set; }
        public string lblTituloItemRecibeNotif { get; set; }
        public string txtnomArchOriginal { get; set; }
        public string txtnomArchTemporal { get; set; }
        public string txtextArch { get; set; }
        public string txtestadoArch { get; set; }
        public string txtcCodificacionSiTD { get; set; }
        public bool chknotifTitular { get; set; }
        public int idTramiteSITD { get; set; }
        public bool chkactadispensa { get; set; }
        public bool chkdjcambiodomicilio { get; set; }

        public List<Ent_FISNOTI2da> tbInforme { get; set; }
        public List<Ent_SBusqueda> sBusqueda { get; set; }
        public List<Ent_FISNOTI2da> tbEliTABLA { get; set; }
    }
}
