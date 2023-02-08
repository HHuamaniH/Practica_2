using CapaEntidad.DOC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad.ViewModel
{
    public class VM_Veeduria
    {
        public string lblTituloCabecera { get; set; }
        public string lblTituloEstado { get; set; }
        public string hdfCodDetalle { get; set; }
        public string hdfCodEquipo { get; set; }
        public string hdfCodOrganizacion { get; set; }
        public string txtcomunidad { get; set; }
        public string txtorginterna { get; set; }
        public string txtorgregional { get; set; }
        public string txtubigeo { get; set; }
        public string txttipo { get; set; }
        public string txtlugar { get; set; }
        public string hdfCodInstalacion { get; set; }
        public int estado { get; set; }
        public string hdfCodIntegrante { get; set; }
        public string txttipodoc { get; set; }
        public string txtnumero { get; set; }
        public string txtintegrante { get; set; }
        public string txtfechaini { get; set; }
        public string txtfechafin { get; set; }
        public string hdfCodHallazgo { get; set; }
        public string txtveedor { get; set; }
        public string txtfecha { get; set; }
        public int txtcoordenadaEste { get; set; }
        public int txtcoordenadaNorte { get; set; }
        public string txtsector { get; set; }
        public decimal txtsuperficie { get; set; }
        public string txtnomempresa { get; set; }
        public string txtnomempresa_validado { get; set; }
        public string txtTHabilitante { get; set; }
        public string txtTHabilitante_validado { get; set; }
        public string hdfCodTHabilitante { get; set; }
        public string txtTitular { get; set; }
        public string txtTitular_validado { get; set; }
        public string hdfCodTitular { get; set; }
        public string txtobservacion { get; set; }
        public string txtobservacion_validado { get; set; }
        public string txtUsuarioRegistro { get; set; }
        public string hdfCodUCuenta { get; set; }
        public string hdfCodUsuarioControl { get; set; }
        public string txtUsuarioControl { get; set; }
        public string txtdescripcion { get; set; }
        public string txtdestino { get; set; }
        public string txtdestinoCC { get; set; }
        public string txtasunto { get; set; }
        public string txtmensaje_envio { get; set; }
        public int hdfRegEstado { get; set; }

        public IEnumerable<VM_Cbo> ddlTipoHallazgo { get; set; }
        public string ddlTipoHallazgoId { get; set; }
        public IEnumerable<VM_Cbo> ddlZona { get; set; }
        public string ddlZonaId { get; set; }
        public IEnumerable<VM_Cbo> ddlTipoVia { get; set; }
        public string ddlTipoViaId { get; set; }
        public IEnumerable<VM_Cbo> ddlTipoVehiculo { get; set; }
        public string ddlTipoVehiculoId { get; set; }
        public IEnumerable<VM_Cbo> ddlTipoFrecuencia { get; set; }
        public string ddlTipoFrecuenciaId { get; set; }
        public IEnumerable<VM_Cbo> ddlTipoActividad { get; set; }
        public string ddlTipoActividadId { get; set; }
        public IEnumerable<VM_Cbo> ddlTipoHecho { get; set; }
        public string ddlTipoHechoId { get; set; }
        public IEnumerable<VM_Cbo> ddlTipoResponsable { get; set; }
        public string ddlTipoResponsableId { get; set; }
        public IEnumerable<VM_Cbo> ddlEstado { get; set; }
        public string ddlEstadoId { get; set; }
        public string idEstado { get; set; }

        public List<Ent_Veeduria> listIntengrante { get; set; }
        public List<Ent_Veeduria> listDetHallazgo { get; set; }
        public List<Ent_Veeduria> listTHabilitanteVinculado { get; set; }
        public List<Ent_Veeduria> listElimTHabilitanteVinculado { get; set; }
        public List<Ent_Veeduria> listArchivo { get; set; }
        public List<Ent_Veeduria> listEnviado { get; set; }
    }
}