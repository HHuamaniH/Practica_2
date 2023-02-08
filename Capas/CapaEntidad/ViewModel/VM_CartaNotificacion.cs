
using CapaEntidad.DOC;
using System.Collections.Generic;

namespace CapaEntidad.ViewModel
{
    public class VM_CartaNotificacion
    {
        public string lblTituloCabecera { get; set; }
        public string lblTituloEstado { get; set; }

        public VM_ControlCalidad_2 vmControlCalidad { get; set; }

        public int hdfRegEstado { get; set; }
        public int hdfiCodTramite { get; set; }
        public string hdfCodCNotificacion { get; set; }
        public string txtNumCNotificacion { get; set; }
        public IEnumerable<VM_Cbo> ddlOd { get; set; }
        public string ddlOdId { get; set; }
        public IEnumerable<VM_Cbo> ddlTipoCNotificacion { get; set; }
        public string ddlTipoCNotificacionId { get; set; }
        public string txtFecEmision { get; set; }
        public string txtFecSupervision { get; set; }
        public IEnumerable<VM_Cbo> ddlMesSupervision { get; set; }
        public string ddlMesSupervisionId { get; set; }
        public IEnumerable<VM_Chk> lstChkTipoSupervision { get; set; }
        public string lstChkTipoSupervisionId { get; set; }
        public string lblTHabilitante { get; set; }
        public string hdfCodTHabilitante { get; set; }
        public string lblInforme { get; set; }
        public string hdfCodInforme { get; set; }

        public string txtFecRecepcionOd { get; set; }
        public string txtFecEntregaNft { get; set; }
        public string txtFecNotificacion { get; set; }
        public string lblPersonaNotificada { get; set; }
        public string hdfCodPersonaNatificada { get; set; }
        public IEnumerable<VM_Cbo> ddlParentesco { get; set; }
        public string ddlParentescoId { get; set; }
        public bool chkNtfBajoPuerta { get; set; }
        public string lblUbigeo { get; set; }
        public string hdfCodUbigeo { get; set; }
        public string txtDireccion { get; set; }
        public string lblUbigeo_actual { get; set; }
        public string lblReferencia_actual { get; set; }
        public string hdfCodUbigeo_actual { get; set; }
        public string txtDireccion_actual { get; set; }
        public bool chkCoincideDirTh { get; set; }
        public string lblNotificador { get; set; }
        public string hdfCodNatificador { get; set; }
        public string txtObservacion { get; set; }
        public string lblCNotificacionRef { get; set; }
        public string hdfCodCNotificacionRef { get; set; }
        public VM_Persona Ent_Notificado { get; set; }
        public string txtUbigeoDJ { get; set; }
        public string txtDireccionDJ { get; set; }
        public string txtReferenciaDJ { get; set; }


        public List<Ent_CNOTIFICACION> tbPoaPo_Dema { get; set; }
        public List<Ent_CNOTIFICACION> tbDevolMadera { get; set; }
        public List<Ent_CNOTIFICACION> tbEliTABLA { get; set; }

        public VM_CartaNotificacion()
        {
            vmControlCalidad = new VM_ControlCalidad_2();
            hdfRegEstado = 1;//Nuevo Registro
            ddlOdId = "0000000";
            ddlTipoCNotificacionId = "0000000";

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
                new VM_Chk { Value = "PM", Text = "Plan de Manejo" },new VM_Chk { Value = "DM", Text = "Devolución de Madera" }//,
                //new VM_Chk { Value = "AQ", Text = "Auditoria Quinquenales" }
            };
            lstChkTipoSupervision = lstChk;
            lstChkTipoSupervisionId = "";
            ddlParentescoId = "0000000";
            chkNtfBajoPuerta = false;
            chkCoincideDirTh = false;

            tbPoaPo_Dema = new List<Ent_CNOTIFICACION>();
            tbDevolMadera = new List<Ent_CNOTIFICACION>();
            tbEliTABLA = new List<Ent_CNOTIFICACION>();
            Ent_Notificado = new VM_Persona();
        }
    }

    public class VM_CNotificacionMuestra
    {
        public string lblTituloEstado { get; set; }
        public string hdfCodCNotificacion { get; set; }
        public string hdfCodTHabilitante { get; set; }
        public string hdfTipoMuestra { get; set; }
        public bool hdfRemoveAllMuestraSelect { get; set; }

        public IEnumerable<VM_Cbo> ddlFiltroBusqueda { get; set; }
        public string ddlFiltroBusquedaId { get; set; }
        public IEnumerable<VM_Cbo> ddlCriterioBusqueda { get; set; }
        public string ddlCriterioBusquedaId { get; set; }
        public string txtValorBusqueda { get; set; }

        public List<Ent_ISUPERVISION_DET_EMADERABLE> tbMuestra { get; set; }
        public List<Ent_DEVOLUCION_MADERA> tbMuestraDevolucion { get; set; }
        public List<Ent_CNOTIFICACION> tbEliTABLA { get; set; }

        public VM_CNotificacionMuestra()
        {
            List<VM_Cbo> lstCbo = new List<VM_Cbo>() {
                new VM_Cbo() { Value="TODOS",Text="Todos"},
                new VM_Cbo() { Value = "MUESTRA", Text = "Muestra" },
                new VM_Cbo() { Value = "NO_MUESTRA", Text = "No Muestra" },
                new VM_Cbo() { Value = "COND_APROVECHABLE", Text = "Condición Aprovechable" },
                new VM_Cbo() { Value = "COND_SEMILLERO", Text = "Condición Semillero" }
            };
            ddlFiltroBusqueda = lstCbo;
            ddlFiltroBusquedaId = "TODOS";

            lstCbo = new List<VM_Cbo>() {
                new VM_Cbo() { Value="ESPECIE",Text="Especie"},
                new VM_Cbo() { Value = "CESTE", Text = "Coordenada Este" },
                new VM_Cbo() { Value = "CNORTE", Text = "Coordenada Norte" },
                new VM_Cbo() { Value = "BLOQUE", Text = "Bloque" },
                new VM_Cbo() { Value = "FAJA", Text = "Faja" },
                new VM_Cbo() { Value = "CODIGO", Text = "Código" },
                new VM_Cbo() { Value = "POA", Text = "POA" }
            };
            ddlCriterioBusqueda = lstCbo;
            ddlCriterioBusquedaId = "ESPECIE";

            hdfRemoveAllMuestraSelect = false;

            tbMuestra = new List<Ent_ISUPERVISION_DET_EMADERABLE>();
            tbEliTABLA = new List<Ent_CNOTIFICACION>();
            tbMuestraDevolucion = new List<Ent_DEVOLUCION_MADERA>();
        }
    }
}
