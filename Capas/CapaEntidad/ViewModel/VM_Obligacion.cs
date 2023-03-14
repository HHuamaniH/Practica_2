using CapaEntidad.DOC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad.ViewModel
{
    public class VM_Obligacion
    {
        public string lblTituloCabecera { get; set; }
        public string lblTituloEstado { get; set; }
        public string lblcomunidad_grupo { get; set; }
        public string hdfCodObligacion { get; set; }
        public string hdfCodUCuenta { get; set; }
        public string txtUsuarioRegistro { get; set; }
        public string hdfCodUsuarioControl { get; set; }
        public string txtUsuarioControl { get; set; }
        public string hdfTipoObligacionId { get; set; }
        public string txtobservacion { get; set; }
        public string txtthabilitante { get; set; }
        public string txtmodalidad { get; set; }
        public string txttitular { get; set; }
        public string txtregion { get; set; }
        public string txtpmanejo { get; set; }
        public string txttipoobligacion { get; set; }
        public string txtfechaenviado { get; set; }
        public string txtnumARFFS { get; set; }
        public string txtfechaARFFS { get; set; }
        public string txtnumOSINFOR { get; set; }
        public string txtfechaOSINFOR { get; set; }
        public string txtnumregLibro { get; set; }
        public string txtformareg { get; set; }
        public string txtotrosistema { get; set; }
        public string txtdescripcion { get; set; }
        public string txtfechaini { get; set; }
        public string txtfechafin { get; set; }
        public string txtruc { get; set; }
        public string txtentidad { get; set; }
        public string hdfCese { get; set; }
        public string txtfechacese { get; set; }
        public string txtmotivocese { get; set; }
        public bool chkactprogramada { get; set; }
        public bool chkzonavulnerable { get; set; }
        public bool chkalertatemprana { get; set; }
        public bool chkalertadeforest { get; set; }
        public bool chkmineriailegal { get; set; }
        public bool chkcambiouso { get; set; }
        public bool chktalailegal { get; set; }
        public bool chkninguno { get; set; }
        public string txtotromotivo { get; set; }
        public string txtotroresultado { get; set; }
        public string txtfechapatrullaje { get; set; }
        public string txtdetallepatrullaje { get; set; }
        public string txtcatregencia { get; set; }
        public string txtnomregente { get; set; }
        public string txtcomunidad_grupo { get; set; }
        public string txtobsregente { get; set; }
        public string txtgtfprimera { get; set; }
        public string txtfechagtfprimera { get; set; }
        public string txtprimernumtrozas_primera { get; set; }
        public string txtultimonumtrozas_primera { get; set; }
        public string txtgtfultima { get; set; }
        public string txtfechagtfultima { get; set; }
        public string txtprimernumtrozas_ultima { get; set; }
        public string txtultimonumtrozas_ultima { get; set; }
        public string hdfCodificacionTrozas { get; set; }
        public string txtcodificado { get; set; }
        public string hdfOtroTipoMaterial { get; set; }
        public string txtotrotipomaterial { get; set; }
        public string txtmotivo_nocodificado { get; set; }
        public string hdfTipoMedida { get; set; }
        public string txttipomedida { get; set; }
        public string txtnumresolucion { get; set; }
        public string txtfechaplazo { get; set; }
        public string txttiporegistro { get; set; }
        public string txtresaprobacion { get; set; }
        public string txtnumdocumento { get; set; }
        public string txtnumregistro { get; set; }
        public string txtfechaactadmin { get; set; }
        public string txtareaafectada { get; set; }
        public string txtzona { get; set; }
        public string txtcoordEste { get; set; }
        public string txtcoordNorte { get; set; }
        public bool isSuccess { get; set; }
        public string data { get; set; }
        public string tx_Mensaje { get; set; }
        public string hdfIdTH { get; set; }
        public string hdfIdPM { get; set; }

        public IEnumerable<VM_Cbo> ddlEstado { get; set; }
        public string ddlEstadoId { get; set; }
        public IEnumerable<VM_Cbo> ddlCatRegencia { get; set; }
        public string ddlCatRegenciaId { get; set; }
        public IEnumerable<VM_Cbo> ddlFormaRegistro { get; set; }
        public string ddlFormaRegistroId { get; set; }
        public IEnumerable<VM_Cbo> ddlTipoFoto { get; set; }
        public IEnumerable<VM_Cbo> ddlTipoRegistro { get; set; }
        public string ddlTipoRegistroId { get; set; }
        public IEnumerable<VM_Chk> listChkAlcance { get; set; }
        public IEnumerable<VM_Chk> listChkTipoCodificado { get; set; }

        public List<Ent_Obligacion> listSenial { get; set; }
        public List<Ent_Obligacion> listHallazgo { get; set; }
        public List<Ent_Obligacion> listArchivoDenuncia { get; set; }
        public List<Ent_Obligacion> listArchivoOtros { get; set; }
        public List<Ent_Obligacion> listArchivo { get; set; }
        public List<Ent_Obligacion> listEvento { get; set; }
    }
}
