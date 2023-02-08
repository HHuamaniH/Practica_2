using System.Collections.Generic;
using System.ComponentModel;

namespace CapaEntidad.DOC
{
    public class Ent_NOTIFICACION
    {
        [Description("COD_FISNOTI")]
        public string COD_FISNOTI { get; set; }
        [Description("COD_UCUENTA")]
        public string COD_UCUENTA { get; set; }
        [Description("COD_FCTIPO")]
        public string COD_FCTIPO { get; set; }
        [Description("TIPO_NOTIFICACION")]
        public string TIPO_NOTIFICACION { get; set; }
        [Description("COD_NOTIFICADOR")]
        public string COD_NOTIFICADOR { get; set; }
        [Description("NOTIFICADOR")]
        public string NOTIFICADOR { get; set; }
        [Description("TIPO")]
        public string TIPO { get; set; }
        [Description("NUMERO_NOTIFICACION")]
        public string NUMERO_NOTIFICACION { get; set; }
        [Category("FECHA"), Description("FECHA_EMISION")]
        public object FECHA_EMISION { get; set; }
        [Category("FECHA"), Description("FECHA_RECEPCION_OD")]
        public object FECHA_RECEPCION_OD { get; set; }
        [Category("FECHA"), Description("FECHA_NOTIFICA_TITULAR")]
        public object FECHA_NOTIFICA_TITULAR { get; set; }
        [Description("COD_RECIBE_NOTIFICA")]
        public string COD_RECIBE_NOTIFICA { get; set; }
        [Description("RECIBE_NOTIFICA")]
        public string RECIBE_NOTIFICA { get; set; }
        [Description("COD_PARENTESCO")]
        public string COD_PARENTESCO { get; set; }
        [Description("PARENTESCO")]
        public string PARENTESCO { get; set; }
        [Description("COD_UBIGEO")]
        public string COD_UBIGEO { get; set; }
        [Description("UBIGEO")]
        public string UBIGEO { get; set; }
        [Description("DIRECCION")]
        public string DIRECCION { get; set; }
        [Description("OBSERVACION")]
        public string OBSERVACION { get; set; }
        [Description("COD_OD_REGISTRO")]
        public string COD_OD_REGISTRO { get; set; }
        [Description("COD_FENTIDAD")]
        public string COD_FENTIDAD { get; set; }
        [Description("NOTIF_TITULAR")]
        public object NOTIF_TITULAR { get; set; }
        [Description("DJ_CAMBIO_DOMICILIO")]
        public object DJ_CAMBIO_DOMICILIO { get; set; }
        [Category("FECHA"), Description("FECHA_NOTIFICADOR")]
        public object FECHA_NOTIFICADOR { get; set; }
        [Description("IdEstadoCargo")]
        public int IdEstadoCargo { get; set; }
        [Description("FlagPrimeraVisita")]
        public object FlagPrimeraVisita { get; set; }
        [Category("FECHA"), Description("FechaPrimeraVisita")]
        public object FechaPrimeraVisita { get; set; }
        [Description("FlagSegundaVisita")]
        public object FlagSegundaVisita { get; set; }
        [Category("FECHA"), Description("FechaSegundaVisita")]
        public object FechaSegundaVisita { get; set; }
        [Description("FlagConformeRecepcion")]
        public object FlagConformeRecepcion { get; set; }
        [Description("FlagSeNegoRecibir")]
        public object FlagSeNegoRecibir { get; set; }
        [Description("FlagSeNegoFirmar")]
        public object FlagSeNegoFirmar { get; set; }
        [Description("FlagBajoPuerta")]
        public object FlagBajoPuerta { get; set; }
        [Description("MedidorAgua")]
        public object MedidorAgua { get; set; }
        [Description("MedidorLuz")]
        public object MedidorLuz { get; set; }
        [Description("NroMedidor")]
        public string NroMedidor { get; set; }
        [Description("MaterialColorFachada")]
        public string MaterialColorFachada { get; set; }
        [Description("MaterialColorPuerta")]
        public string MaterialColorPuerta { get; set; }
        [Description("NroPisos")]
        public string NroPisos { get; set; }
        [Description("TelefonoOtros")]
        public string TelefonoOtros { get; set; }
        [Description("FlagCambioDomicilio")]
        public object FlagCambioDomicilio { get; set; }
        [Description("DireccionDeCambioDomicilio")]
        public string DireccionDeCambioDomicilio { get; set; }
        [Description("UrbanizacionDeCambioDomicilio")]
        public string UrbanizacionDeCambioDomicilio { get; set; }
        [Description("ReferenciaDeCambioDomicilio")]
        public string ReferenciaDeCambioDomicilio { get; set; }
        [Category("FECHA"), Description("fdevolucionSEC")]
        public object fdevolucionSEC { get; set; }
        [Description("CodUbigeoCambioDomicilio")]
        public string CodUbigeoCambioDomicilio { get; set; }
        [Description("UbigeoCambioDomicilio")]
        public string UbigeoCambioDomicilio { get; set; }
        [Description("FlagActaNotificacion")]
        public object FlagActaNotificacion { get; set; }
        [Description("COD_THABILITANTE")]
        public string COD_THABILITANTE { get; set; }
        [Description("NUM_THABILITANTE")]
        public string NUM_THABILITANTE { get; set; }
        [Description("DIR_COINCIDE_DTITULAR")]
        public object DIR_COINCIDE_DTITULAR { get; set; }
        [Description("ESTADO_ORIGEN")]
        public string ESTADO_ORIGEN { get; set; }
        [Category("FECHA"), Description("FECHA_PSUPERVISION")]
        public object FECHA_PSUPERVISION { get; set; }
        [Description("MES_SUPERVISION")]
        public string MES_SUPERVISION { get; set; }
        [Description("ZONA")]
        public string ZONA { get; set; }
        [Description("COORDENADA_ESTE")]
        public int COORDENADA_ESTE { get; set; }
        [Description("COORDENADA_NORTE")]
        public int COORDENADA_NORTE { get; set; }
        [Description("CODIFICACION_SITD")]
        public string CODIFICACION_SITD { get; set; }
        [Description("DOCUMENTO_CARGO")]
        public string DOCUMENTO_CARGO { get; set; }
        [Description("COD_NOTIFICACION_REF")]
        public string COD_NOTIFICACION_REF { get; set; }
        [Description("NUM_NOTIFICACION_REF")]
        public string NUM_NOTIFICACION_REF { get; set; }

        //Control de calidad
        [Description("COD_ESTADO_DOC")]
        public string COD_ESTADO_DOC { get; set; }
        [Description("OBSERVACIONES_CONTROL")]
        public object OBSERVACIONES_CONTROL { get; set; }
        [Description("OBSERV_SUBSANAR")]
        public object OBSERV_SUBSANAR { get; set; }
        [Description("USUARIO_REGISTRO")]
        public string USUARIO_REGISTRO { get; set; }
        [Description("USUARIO_CONTROL")]
        public string USUARIO_CONTROL { get; set; }
        [Description("ORIGEN_REGISTRO")]
        public int ORIGEN_REGISTRO { get; set; }
        [Description("OUTPUTPARAM01")]
        public string OUTPUTPARAM01 { get; set; }

        //Listados
        public List<Ent_INFORME_CONSULTA> ListInforme { get; set; }
        public List<Ent_RESODIREC_CONSULTA> ListExpediente { get; set; }
        public List<Ent_RESODIREC_CONSULTA> ListResolucion { get; set; }
        public List<Ent_ILEGAL_CONSULTA> ListILegal { get; set; }
        public List<Ent_POA_CONSULTA> ListPoa { get; set; }
        public List<Ent_DEVOLUCION_MADERA_CONSULTA> ListDevolucionMadera { get; set; }
        public List<Ent_NOTIFICACION_ELI> ListEliTABLA { get; set; }

        [Description("TIPO_REPORTE")]
        public string TIPO_REPORTE { get; set; }

        public Ent_NOTIFICACION()
        {
            IdEstadoCargo = -1;
            COORDENADA_ESTE = -1;
            COORDENADA_NORTE = -1;
            ORIGEN_REGISTRO = -1;
        }
    }
    public class Ent_NOTIFICACION_CONSULTA
    {
        public string COD_FISNOTI { get; set; }
        public string NUM_NOTIFICACION { get; set; }
        public string COD_FCTIPO { get; set; }
        public string FCTIPO { get; set; }
        public string COD_THABILITANTE { get; set; }
        public string NUM_THABILITANTE { get; set; }
        public string COD_MTIPO { get; set; }
        public string MTIPO { get; set; }
        public string ESTADO_ORIGEN { get; set; }
        public string NOMBRE_POA { get; set; }
        public string COD_UBIGEO { get; set; }
        public string UBIGEO { get; set; }
        public string SECTOR { get; set; }

        [Description("BusFormulario")]
        public string BusFormulario { get; set; }
        [Description("BusCriterio")]
        public string BusCriterio { get; set; }
        [Description("BusValor")]
        public string BusValor { get; set; }
        [Description("BusTipo")]
        public string BusTipo { get; set; }
    }
    public class Ent_NOTIFICACION_ELI
    {
        [Description("COD_FISNOTI")]
        public string COD_FISNOTI { get; set; }
        [Description("EliTABLA")]
        public string EliTABLA { get; set; }
        [Description("COD_INFORME")]
        public string COD_INFORME { get; set; }
        [Description("COD_RESODIREC")]
        public string COD_RESODIREC { get; set; }
        [Description("COD_RESODIREC_INI_PAU")]
        public string COD_RESODIREC_INI_PAU { get; set; }
        [Description("COD_RPSECUENCIAL")]
        public int COD_RPSECUENCIAL { get; set; }
        [Description("COD_ILEGAL")]
        public string COD_ILEGAL { get; set; }
        [Description("COD_THABILITANTE")]
        public string COD_THABILITANTE { get; set; }
        [Description("NUM_POA")]
        public int NUM_POA { get; set; }
        [Description("COD_DEVOLUCION")]
        public string COD_DEVOLUCION { get; set; }
    }
    public class Ent_NOTIFICACION_INF
    {
        [Description("COD_FISNOTI")]
        public string COD_FISNOTI { get; set; }
        [Description("COD_INFORME")]
        public string COD_INFORME { get; set; }
        [Description("RegEstado")]
        public int RegEstado { get; set; }
    }
    public class Ent_NOTIFICACION_EXP
    {
        [Description("COD_FISNOTI")]
        public string COD_FISNOTI { get; set; }
        [Description("COD_RESODIREC")]
        public string COD_RESODIREC { get; set; }
        [Description("COD_RESODIREC_INI_PAU")]
        public string COD_RESODIREC_INI_PAU { get; set; }
        [Description("COD_RPSECUENCIAL")]
        public int COD_RPSECUENCIAL { get; set; }
        [Description("RegEstado")]
        public int RegEstado { get; set; }
    }
    public class Ent_NOTIFICACION_RES
    {
        [Description("COD_FISNOTI")]
        public string COD_FISNOTI { get; set; }
        [Description("COD_RESODIREC")]
        public string COD_RESODIREC { get; set; }
        [Description("RegEstado")]
        public int RegEstado { get; set; }
    }
    public class Ent_NOTIFICACION_ILE
    {
        [Description("COD_FISNOTI")]
        public string COD_FISNOTI { get; set; }
        [Description("COD_ILEGAL")]
        public string COD_ILEGAL { get; set; }
        [Description("RegEstado")]
        public int RegEstado { get; set; }
    }
    public class Ent_NOTIFICACION_CARGO
    {
        [Description("COD_FISNOTI")]
        public string COD_FISNOTI { get; set; }
        [Description("DOCUMENTO_CARGO")]
        public string DOCUMENTO_CARGO { get; set; }
        [Description("DOCUMENTO_CARGO_ORIGINAL")]
        public string DOCUMENTO_CARGO_ORIGINAL { get; set; }
    }
    public class Ent_NOTIFICACION_POA
    {
        [Description("COD_FISNOTI")]
        public string COD_FISNOTI { get; set; }
        [Description("COD_THABILITANTE")]
        public string COD_THABILITANTE { get; set; }
        [Description("NUM_POA")]
        public int NUM_POA { get; set; }
    }
    public class Ent_NOTIFICACION_DEVMAD
    {
        [Description("COD_FISNOTI")]
        public string COD_FISNOTI { get; set; }
        [Description("COD_THABILITANTE")]
        public string COD_THABILITANTE { get; set; }
        [Description("COD_DEVOLUCION")]
        public string COD_DEVOLUCION { get; set; }
    }
}
