using CapaEntidad.DOC;
using System.Collections.Generic;

namespace CapaEntidad.ViewModel
{
    public class VM_Notificacion
    {
        public string lblTituloCabecera { get; set; }
        public string lblTituloEstado { get; set; }
        public VM_ControlCalidad_2 vmControlCalidad { get; set; }
        public string hdfCodNotificacion { get; set; }
        public string txtNumNotificacion { get; set; }
        public IEnumerable<VM_Cbo> ddlOd { get; set; }
        public string ddlOdId { get; set; }
        public string hdfCodTipoNotificacion { get; set; }
        public string lblTipoNotificacion { get; set; }
        public string txtFecEmision { get; set; }
        public string txtFecRecepcionOd { get; set; }
        public string txtFecEntregaNft { get; set; }
        public string txtFecNotificacion { get; set; }
        public string hdfCodNotificador { get; set; }
        public string lblNotificador { get; set; }
        public bool hdfNotifTitular { get; set; }
        public string txtFecDevolSec { get; set; }
        public IEnumerable<VM_Cbo> ddlEstadoCargo { get; set; }
        public int ddlEstadoCargoId { get; set; }
        public bool chkPrimeraVisita { get; set; }
        public string txtFecPrimeraVisita { get; set; }
        public bool chkSegundaVisita { get; set; }
        public string txtFecSegundaVisita { get; set; }
        /// <summary>
        /// [1]Conforme recepción y firma [2]Se nego a recibir la notificación [3]Se nego a firmar el cargo de notificación [4]Bajo la puerta
        /// </summary>
        public string radListRecepcionId { get; set; }
        public IEnumerable<VM_Cbo> ddlParentesco { get; set; }
        public string ddlParentescoId { get; set; }
        public string txtParentesco { get; set; }
        public string hdfCodPersonaRecibe { get; set; }
        public string lblPersonaRecibe { get; set; }
        public IEnumerable<VM_Cbo> ddlFEntidad { get; set; }
        public string ddlFEntidadId { get; set; }
        public string hdfCodUbigeo { get; set; }
        public string lblUbigeo { get; set; }
        public string txtDireccion { get; set; }
        public bool chkActaNotifAdm { get; set; }
        /// <summary>
        /// [1]Medidor de agua [2]Medidor de luz
        /// </summary>
        public string radListMedidorId { get; set; }
        public string txtNumMedidor { get; set; }
        public string txtDetalleFachada { get; set; }
        public string txtDetallePuerta { get; set; }
        public string txtNroPisos { get; set; }
        public IEnumerable<VM_Cbo> ddlZona { get; set; }
        public string ddlZonaId { get; set; }
        public int txtCoordEste { get; set; }
        public int txtCoordNorte { get; set; }
        public string txtTelefono { get; set; }
        public bool chkCambioDomicilio { get; set; }
        public string txtDireccionCambio { get; set; }
        public string txtUrbanicacionCambio { get; set; }
        public string hdfCodUbigeoCambio { get; set; }
        public string lblUbigeoCambio { get; set; }
        public string txtReferenciaCambio { get; set; }
        public string txtObservacion { get; set; }
        public string hdfCodificacionSITD { get; set; }
        public string txtDocumentoCargo { get; set; }
        public bool chkCoincideDireccion { get; set; }
        public string txtFecSupervision { get; set; }
        public IEnumerable<VM_Cbo> ddlMesSupervision { get; set; }
        public string ddlMesSupervisionId { get; set; }
        public IEnumerable<VM_Chk> lstChkTipoSupervision { get; set; }
        public string lstChkTipoSupervisionId { get; set; }
        public string lblTHabilitante { get; set; }
        public string hdfCodTHabilitante { get; set; }
        public string lblCNotificacionRef { get; set; }
        public string hdfCodCNotificacionRef { get; set; }

        public List<Ent_INFORME_CONSULTA> tbInforme { get; set; }
        public List<Ent_RESODIREC_CONSULTA> tbExpediente { get; set; }
        public List<Ent_RESODIREC_CONSULTA> tbResolucion { get; set; }
        public List<Ent_ILEGAL_CONSULTA> tbILegal { get; set; }
        public List<Ent_POA_CONSULTA> tbPoa { get; set; }
        public List<Ent_DEVOLUCION_MADERA_CONSULTA> tbDevolucionMadera { get; set; }
        public List<Ent_NOTIFICACION_ELI> tbEliTABLA { get; set; }

        public VM_Notificacion()
        {
            vmControlCalidad = new VM_ControlCalidad_2();
            ddlOdId = "0000000";
            ddlEstadoCargo = new List<VM_Cbo>() { new VM_Cbo() { Value = "0", Text = "Seleccionar" }, new VM_Cbo() { Value = "1", Text = "Notificado" }, new VM_Cbo() { Value = "2", Text = "Devuelto" }, new VM_Cbo() { Value = "3", Text = "Pendiente" } };
            ddlEstadoCargoId = 0;
            ddlParentescoId = "0000000";
            radListRecepcionId = "";
            ddlFEntidadId = "0000000";
            ddlZonaId = "0000000";
            List<VM_Cbo> lstCbo = new List<VM_Cbo>() {
                new VM_Cbo() { Value="0000000",Text="Ninguno"},
                new VM_Cbo() { Value = "Enero", Text = "Enero" }, new VM_Cbo() { Value = "Febrero", Text = "Febrero" }, new VM_Cbo() { Value = "Marzo", Text = "Marzo" },
                new VM_Cbo() { Value = "Abril", Text = "Abril" }, new VM_Cbo() { Value = "Mayo", Text = "Mayo" }, new VM_Cbo() { Value = "Junio", Text = "Junio" },
                new VM_Cbo() { Value = "Julio", Text = "Julio" }, new VM_Cbo() { Value = "Agosto", Text = "Agosto" }, new VM_Cbo() { Value = "Septiembre", Text = "Septiembre" },
                new VM_Cbo() { Value = "Octubre", Text = "Octubre" }, new VM_Cbo() { Value = "Noviembre", Text = "Noviembre" },new VM_Cbo() { Value = "Diciembre", Text = "Diciembre" }
            };
            ddlMesSupervision = lstCbo;
            ddlMesSupervisionId = "0000000";

            List<VM_Chk> lstChk = new List<VM_Chk>() {
                new VM_Chk { Value = "TH", Text = "Obligaciones Contractuales (Sin Muestra)" },new VM_Chk { Value = "P", Text = "POA/PO | DEMA" },
                new VM_Chk { Value = "PM", Text = "Plan de Manejo" },new VM_Chk { Value = "DM", Text = "Devolución de Madera" }
            };
            lstChkTipoSupervision = lstChk;
            lstChkTipoSupervisionId = "";

            tbInforme = new List<Ent_INFORME_CONSULTA>();
            tbExpediente = new List<Ent_RESODIREC_CONSULTA>();
            tbResolucion = new List<Ent_RESODIREC_CONSULTA>();
            tbILegal = new List<Ent_ILEGAL_CONSULTA>();
            tbPoa = new List<Ent_POA_CONSULTA>();
            tbDevolucionMadera = new List<Ent_DEVOLUCION_MADERA_CONSULTA>();
            tbEliTABLA = new List<Ent_NOTIFICACION_ELI>();
        }
    }
}
