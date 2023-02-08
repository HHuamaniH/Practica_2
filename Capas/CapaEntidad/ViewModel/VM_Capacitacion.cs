using CapaEntidad.DOC;
using System.Collections.Generic;
namespace CapaEntidad.ViewModel
{
    public class VM_Capacitacion
    {
        public string lblTituloCabecera { get; set; }
        public string lblTituloEstado { get; set; }

        public VM_ControlCalidad_2 vmControlCalidad { get; set; }

        public string hdfCodCapacitacion { get; set; }
        public IEnumerable<VM_Cbo> ddlOd { get; set; }
        public string ddlOdId { get; set; }
        public int hdfRegEstado { get; set; }
        public IEnumerable<VM_Cbo> ddlCapacitacionEjecutar { get; set; }
        public string ddlCapacitacionEjecutarId { get; set; }
        public string txtNomCapacitacion { get; set; }
        public IEnumerable<VM_Cbo> ddlTipCapacitacion { get; set; }
        public string ddlTipCapacitacionId { get; set; }
        public IEnumerable<VM_Cbo> ddlSumMetPoi { get; set; }
        public string ddlSumMetPoiId { get; set; }
        public string txtObjetivo { get; set; }
        public IEnumerable<VM_Cbo> ddlMetodologia { get; set; }
        public string ddlMetodologiaId { get; set; }
        public string txtObsMetodologia { get; set; }
        public string hdfDLinea { get; set; }
        public string txtFecInicio { get; set; }
        public string txtFecTermino { get; set; }
        public int txtDuracion { get; set; }
        public IEnumerable<VM_Cbo> ddlOrganizador { get; set; }
        public string ddlOrganizadorId { get; set; }
        public string txtDetOrganizador { get; set; }
        public IEnumerable<VM_Cbo> ddlApoyoCoorganizador { get; set; }
        public string ddlApoyoCoorganizadorId { get; set; }
        public int txtTotalParticipante { get; set; }
        public bool chkMarConvenio { get; set; }
        public string lblUbigeo { get; set; }
        public string hdfUbigeo { get; set; }
        public string txtLugar { get; set; }
        public string txtSector { get; set; }
        public IEnumerable<VM_Cbo> ddlZonaUtm { get; set; }
        public string ddlZonaUtmId { get; set; }
        public int txtCEste { get; set; }
        public int txtCNorte { get; set; }
        public string txtConclusion { get; set; }
        public string txtObservacion { get; set; }
        public IEnumerable<VM_Cbo> ddlConvenio { get; set; }
        public string ddlConvenioId { get; set; }
        public IEnumerable<VM_Chk> lstChkTema { get; set; }
        public string lstChkTemaId { get; set; }
        public string txtDescTema { get; set; }
        public IEnumerable<VM_Cbo> ddlPublicoObjetivo { get; set; }
        public string ddlPublicoObjetivoId { get; set; }
        public string txtDescPObjRepresentante { get; set; }
        public string txtDescPObjOtroActor { get; set; }
        public IEnumerable<VM_Cbo> ddlTipoAdjunto { get; set; }
        public string ddlTipoAdjuntoId { get; set; }

        public string txtAntecedentes { get; set; }
        public string txtJustificacion { get; set; }
        public string txtResultadosEsperados { get; set; }
        public IEnumerable<VM_Cbo> ddlModalidad { get; set; }
        public string ddlModalidadId { get; set; }
        public string txtMaterialesEquipo { get; set; }
        public string txtPublicoObjetivo { get; set; }
        public string txtCronograma { get; set; }
        public string txtPrograma { get; set; }

        public string txtPresentacion { get; set; }
        public string txtDescripcionEjecutiva { get; set; }
        public string txtResumenIntervenciones { get; set; }
        public string txtDescripcionTrabajos { get; set; }

        public string txtRecomendaciones { get; set; }

        public List<Ent_CAPACITACION> tbParticipante_Asistentes { get; set; }
        public List<Ent_CAPACITACION> tbParticipante_EquipoApoyo { get; set; }
        public List<Ent_CAPACITACION> tbParticipante_Ponentes { get; set; }
        public List<Ent_CAPACITACION> tbEvaluacion_Aportes { get; set; }
        public List<Ent_CAPACITACION> tbEvaluacion_Encuestas { get; set; }
        public List<Ent_CAPACITACION> tbEvaluacion_EvalInicial { get; set; }
        public List<Ent_CAPACITACION> tbEvaluacion_EvalFinal { get; set; }
        public List<Ent_CAPACITACION> tbEvaluacion_Examenes { get; set; }
        public List<Ent_CAPACITACION> tbDocumentoAdjunto { get; set; }
        public List<Ent_CAPACITACION> tbEliTABLA { get; set; }
        public List<Ent_CAPACITACION> tbProgramacion { get; set; }
        public List<Ent_CAPACITACION> tbCronograma { get; set; }

        public string hdfTipo { get; set; }

        public VM_Capacitacion()
        {
            vmControlCalidad = new VM_ControlCalidad_2();
            List<VM_Cbo> lstSumMetPoi = new List<VM_Cbo>() {
                new VM_Cbo() { Selected = true, Value = "0000000", Text = "Seleccionar" },
                new VM_Cbo() { Selected = false, Value = "1", Text = "SI" },
                new VM_Cbo() { Selected = false, Value = "0", Text = "NO" }
            };
            ddlSumMetPoi = lstSumMetPoi;

            ddlOdId = "0000000";
            ddlCapacitacionEjecutarId = "0000000";
            ddlCapacitacionEjecutar = new List<VM_Cbo>() { new VM_Cbo() { Value = "0000000", Text = "Seleccionar" } };
            ddlTipCapacitacionId = "0000000";
            ddlMetodologiaId = "0000000";
            ddlSumMetPoiId = "0000000";
            chkMarConvenio = false;
            hdfRegEstado = 1;//Nuevo registro
            hdfDLinea = "0000008";//Por defecto se selecciona a la DEFFS
            ddlOrganizadorId = "0000000";
            ddlZonaUtmId = "0000000";
            ddlZonaUtm = new List<VM_Cbo>() {
                new VM_Cbo() { Value = "0000000", Text = "Seleccionar" },
                new VM_Cbo() { Value = "17S", Text = "17S" },
                new VM_Cbo() { Value = "18S", Text = "18S" },
                new VM_Cbo() { Value = "19S", Text = "19S" }
            };
            lstChkTemaId = "";
            ddlTipoAdjuntoId = "0000000";

            tbParticipante_Asistentes = new List<Ent_CAPACITACION>();
            tbParticipante_EquipoApoyo = new List<Ent_CAPACITACION>();
            tbParticipante_Ponentes = new List<Ent_CAPACITACION>();
            tbEvaluacion_Aportes = new List<Ent_CAPACITACION>();
            tbEvaluacion_Encuestas = new List<Ent_CAPACITACION>();
            tbEvaluacion_EvalFinal = new List<Ent_CAPACITACION>();
            tbEvaluacion_EvalInicial = new List<Ent_CAPACITACION>();
            tbEvaluacion_Examenes = new List<Ent_CAPACITACION>();
            tbDocumentoAdjunto = new List<Ent_CAPACITACION>();
            tbEliTABLA = new List<Ent_CAPACITACION>();
            tbProgramacion = new List<Ent_CAPACITACION>();
            tbCronograma = new List<Ent_CAPACITACION>();
        }
    }

    public class VM_Capacitacion_Reporte
    {
        public string lblTituloCabecera { get; set; }
        public string hdfTipoReporte { get; set; }
        public string hdfCodPersona { get; set; }
        public string hdfCodTHabilitante { get; set; }

        public IEnumerable<VM_Cbo> ddlTipoFiltro { get; set; }
        public string ddlTipoFiltroId { get; set; }
        public IEnumerable<VM_Cbo> ddlTHCapacitados { get; set; }
        public string ddlTHCapacitadosId { get; set; }
        public IEnumerable<VM_Cbo> ddlSumMetPoi { get; set; }
        public string ddlSumMetPoiId { get; set; }
        public IEnumerable<VM_Cbo> ddlOtrosEventos { get; set; }
        public string ddlOtrosEventosId { get; set; }
        public IEnumerable<VM_Cbo> ddlEntFinancia { get; set; }
        public string ddlEntFinanciaId { get; set; }
        public IEnumerable<VM_Cbo> ddlComunidadNativa { get; set; }
        public string ddlComunidadNativaId { get; set; }
        public IEnumerable<VM_Cbo> ddlEtnia { get; set; }
        public string ddlEtniaId { get; set; }
        public IEnumerable<VM_Chk> lstChkInstitucion { get; set; }
        public string lstChkInstitucionId { get; set; }

        public IEnumerable<VM_Chk> lstChkAnio { get; set; }
        public string lstChkAnioId { get; set; }
        public IEnumerable<VM_Chk> lstChkMes { get; set; }
        public string lstChkMesId { get; set; }
        public IEnumerable<VM_Chk> lstChkOd { get; set; }
        public string lstChkOdId { get; set; }
        public IEnumerable<VM_Chk> lstChkTipCapacitacion { get; set; }
        public string lstChkTipCapacitacionId { get; set; }
        public IEnumerable<VM_Chk> lstChkPublicoObjetivo { get; set; }
        public IEnumerable<VM_Chk> lstChkPObjetivoGroup { get; set; }
        public string lstChkPublicoObjetivoId { get; set; }
        public IEnumerable<VM_Chk> lstChkDepartamento { get; set; }
        public string lstChkDepartamentoId { get; set; }
        public string hdfCodMTipo { get; set; }

        public VM_Capacitacion_Reporte()
        {
            ddlTipoFiltro = new List<VM_Cbo>() { new VM_Cbo() { Value = "0000000", Text = "Seleccionar" } };
            ddlTipoFiltroId = "0000000";

            List<VM_Cbo> lstOtrosEventos = new List<VM_Cbo>() {
                new VM_Cbo() { Value="SI",Text="Si" },new VM_Cbo() { Value="NO",Text="No" }
            };
            ddlOtrosEventos = lstOtrosEventos;
            ddlOtrosEventosId = "No";

            List<VM_Cbo> lstTHCapacitados = new List<VM_Cbo>() {
                new VM_Cbo() { Value="SI",Text="Si" },new VM_Cbo() { Value="NO",Text="No" }
            };
            ddlTHCapacitados = lstTHCapacitados;
            ddlTHCapacitadosId = "Si";

            List<VM_Cbo> lstSumMetPoi = new List<VM_Cbo>() {
                new VM_Cbo() { Value="TODOS",Text="Todos"},new VM_Cbo() { Value="SI",Text="Si" },new VM_Cbo() { Value="NO",Text="No" }
            };
            ddlSumMetPoi = lstSumMetPoi;
            ddlSumMetPoiId = "TODOS";

            lstChkAnioId = "";
            lstChkMesId = "";
            lstChkOdId = "";
            lstChkTipCapacitacionId = "";
            ddlEntFinancia = new List<VM_Cbo>() { new VM_Cbo() { Value = "0000000", Text = "Seleccionar" } };
            ddlEntFinanciaId = "0000000";
            ddlComunidadNativa = new List<VM_Cbo>() { new VM_Cbo() { Value = "0000000", Text = "Seleccionar" } };
            ddlComunidadNativaId = "0000000";
            ddlEtnia = new List<VM_Cbo>() { new VM_Cbo() { Value = "0000000", Text = "Seleccionar" } };
            ddlEtniaId = "0000000";
            lstChkPublicoObjetivo = new List<VM_Chk>();
            lstChkDepartamentoId = "";
            lstChkInstitucionId = "";
        }
    }
}
