using CapaEntidad.DOC;
using System.Collections.Generic;

namespace CapaEntidad.ViewModel
{
    public class VM_InformeFundamentado
    {
        public string lblTituloCabecera { get; set; }
        public string lblTituloEstado { get; set; }
        public VM_ControlCalidad_2 vmControlCalidad { get; set; }
        public string hdfCodInfFundamentado { get; set; }
        public string hdfCodTipoInfFundamentado { get; set; }
        public string txtTipoInfFundamentado { get; set; }
        public string txtNumInfFundamentado { get; set; }
        public string dtpFechaFundamentado { get; set; }

        public IEnumerable<VM_Cbo> ddlOd { get; set; }
        public string ddlOdId { get; set; }
        public IEnumerable<VM_Cbo> ddlEntidad { get; set; }
        public string ddlEntidadId { get; set; }
        public IEnumerable<VM_Cbo> ddlSubEntidad { get; set; }
        public string ddlSubEntidadId { get; set; }

        public string txtConclusiones { get; set; }
        public string txtObservaciones { get; set; }
        public string txtTituloModal { get; set; }

        public int RegEstado { get; set; }
        public string hdfCodigoInfFundamentadoAlerta { get; set; }

        public List<Ent_INFFUN> tbInforme { get; set; }
        public List<Ent_SBusqueda> sBusqueda { get; set; }
        public List<Ent_INFFUN> listaProfesionales { get; set; }
        public List<Ent_INFFUN> listaEntidades { get; set; }

        public List<Ent_INFFUN> tbEliTABLA { get; set; }

        // NUEVOS CAMPOS // DATOS SOLICITUD FEMAS

        public string txtRegistro { get; set; }

        public string dtpFechaIngresoSolicitud { get; set; }
        public string txtNumeroOficioSolicitud { get; set; }
        public IEnumerable<VM_Cbo> ddlTipoSolicitud { get; set; }
        public string ddlTipoSolicitudId { get; set; }
        public IEnumerable<VM_Cbo> ddlVencimientoPlazoLegal { get; set; }
        public string ddlVencimientoPlazoLegalId { get; set; }
        public string txtDetalle { get; set; }

        public IEnumerable<VM_Cbo> ddlEstadoSolicitudFema { get; set; }
        public string ddlEstadoSolicitudFemaId { get; set; }
        public string txtTitularTipo { get; set; }
        public string hdtxtTitularTipo { get; set; }
        public string hdfItemEstUbigeoCodigo { get; set; }
        public string fItemEstUbigeoCodigo { get; set; }
        // INFORME FUNDAMENTADO
        public bool chkEmitirInforme { get; set; }
        public string dtpfechaFirmezaPAU { get; set; }
        public string txtNumeroInformeFundamentado { get; set; }
        public string dtpFechaEmision1 { get; set; }
        public string txtNumeroOficio1 { get; set; }
        public string dtpFechaEmision2 { get; set; }

        public bool chkEmitirOficio { get; set; }
        public string txtNumeroOficio2 { get; set; }
        public string dtpfechaOficio2 { get; set; }
        public string txtObservacionesOficio { get; set; }
        public string dtpfechaOficio1 { get; set; }
        // PAU
        public bool chkEmitirOficioPau { get; set; }
        public string txtNumeroOficioPau { get; set; }
        public string dtpFechaEmisionPau { get; set; }
        public string txtObservacionesPau { get; set; }

        // NOTIFICACION

        public bool chkNotificacion { get; set; }
        public string dtpFechaNotificacion { get; set; }
        public string txtAnotaciones { get; set; }

    }
}
