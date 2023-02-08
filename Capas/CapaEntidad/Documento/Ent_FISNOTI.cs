using CapaEntidad.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CapaEntidad.DOC
{
    public class Ent_FISNOTI
    {
        #region "Entidades y Propiedades"

        [Description("COD_FISNOTI")]
        public String COD_FISNOTI { get; set; }
        [Description("COD_FCTIPO")]
        public String COD_FCTIPO { get; set; }
        [Description("COD_UCUENTA")]
        public String COD_UCUENTA { get; set; }
        [Description("NUMERO_NOTIFICACION")]
        public String NUMERO_NOTIFICACION { get; set; }
        [Description("RegEstado")]
        public int RegEstado { get; set; }
        [Description("COD_OD_REGISTRO")]
        public String COD_OD_REGISTRO { get; set; }

        [Description("BUZON")]
        public Object BUZON { get; set; }
        [Description("ACTA_DISPENSA")]
        public Object ACTA_DISPENSA { get; set; }
        [Description("DJ_CAMBIO_DOMICILIO")]
        public Object DJ_CAMBIO_DOMICILIO { get; set; }

        [Description("BusFormulario")]
        public String BusFormulario { get; set; }
        [Description("BusCriterio")]
        public String BusCriterio { get; set; }
        [Description("BusValor")]
        public String BusValor { get; set; }
        [Description("v_currentpage")]
        public Int32 v_currentpage { get; set; }
        [Description("v_pagesize")]
        public Int32 v_pagesize { get; set; }
        [Description("v_row_index")]
        public Int32 v_row_index { get; set; }

        [Description("OBSERVACION")]
        public String OBSERVACION { get; set; }
        [Description("COD_RESODIREC")]
        public String COD_RESODIREC { get; set; }
        [Description("COD_RESODIREC_INI_PAU")]
        public String COD_RESODIREC_INI_PAU { get; set; }
        [Description("NUMERO_EXPEDIENTE")]
        public String NUMERO_EXPEDIENTE { get; set; }
        [Description("COD_RECIBE_NOTIFICA")]
        public String COD_RECIBE_NOTIFICA { get; set; }
        [Description("COD_PARENTESCO")]
        public String COD_PARENTESCO { get; set; }
        [Description("COD_UBIGEO")]
        public String COD_UBIGEO { get; set; }
        [Description("CodUbigeoCambioDomicilio")]
        public String CodUbigeoCambioDomicilio { get; set; }

        [Description("D_LINEA")]
        public String D_LINEA { get; set; }
        [Description("NUM_THABILITANTE")]
        public String NUM_THABILITANTE { get; set; }
        [Description("TITULAR")]
        public String TITULAR { get; set; }
        [Description("COD_TITULAR")]
        public String COD_TITULAR { get; set; }


        [Description("CODIGO")]
        public String CODIGO { get; set; }
        [Description("DESCRIPCION")]
        public String DESCRIPCION { get; set; }
        [Description("COD_ILEGAL")]
        public String COD_ILEGAL { get; set; }
        [Description("COD_INFORME")]
        public String COD_INFORME { get; set; }
        [Description("TIPO")]
        public string TIPO { get; set; }
        [Description("DOCUMENTOS_ADJUNTOS")]
        public string DOCUMENTOS_ADJUNTOS { get; set; }
        //
        [Description("COD_ESTADO_DOC")]
        public String COD_ESTADO_DOC { get; set; }
        [Description("OBSERVACIONES_CONTROL")]
        public Object OBSERVACIONES_CONTROL { get; set; }
        [Description("OBSERV_SUBSANAR")]
        public Object OBSERV_SUBSANAR { get; set; }
        [Description("PARENTESCO")]
        public Object PARENTESCO { get; set; }
        [Description("ID_ORIGEN_REGISTRO")]
        public int? ID_ORIGEN_REGISTRO { get; set; }

        //
        [Description("DESCRIPCION_ENTIDAD")]
        public string DESCRIPCION_ENTIDAD { get; set; }
        [Description("COD_FENTIDAD")]
        public string COD_FENTIDAD { get; set; }
        [Description("OUTPUTPARAM01")]
        public string OUTPUTPARAM01 { get; set; }
        [Description("TIPO_FISCALIZA")]
        public string TIPO_FISCALIZA { get; set; }
        [Description("NUMERO")]
        public string NUMERO { get; set; }
        [Description("NUMERO_RESOLUCION")]
        public string NUMERO_RESOLUCION { get; set; }
        [Description("APELLIDOS_NOMBRES")]
        public string APELLIDOS_NOMBRES { get; set; }
        [Description("DIRECCION")]
        public string DIRECCION { get; set; }
        [Description("UBIGEO")]
        public string UBIGEO { get; set; }
        [Description("UBIGEOCAMBIO")]
        public string UBIGEOCAMBIO { get; set; }
        [Description("EliTABLA")]
        public string EliTABLA { get; set; }
        [Description("EliVALOR02")]
        public Int32 EliVALOR02 { get; set; }
        [Description("COD_NOTIFICADOR")]
        public string COD_NOTIFICADOR { get; set; }
        [Description("NOTIFICADOR")]
        public string NOTIFICADOR { get; set; }
        [Description("ENT_NOTIFICADO")]
        public VM_Persona ENT_NOTIFICADO { get; set; }

        [Description("NOTIF_TITULAR")]
        public Object NOTIF_TITULAR { get; set; }
        [Description("ID_TRAMITE_SITD")]
        public int ID_TRAMITE_SITD { get; set; }

        [Description("USUARIO_REGISTRO")]
        public String USUARIO_REGISTRO { get; set; }
        [Description("USUARIO_CONTROL")]
        public String USUARIO_CONTROL { get; set; }

        //archivos
        [Description("NOMBRE_ARCHIVO")]
        public String NOMBRE_ARCHIVO { get; set; }
        [Description("EXTENSION_ARCHIVO")]
        public String EXTENSION_ARCHIVO { get; set; }
        [Description("NOMBRE_TEMPORAL_ARCHIVO")]
        public String NOMBRE_TEMPORAL_ARCHIVO { get; set; }
        [Description("ESTADO_ARCHIVO")]
        public String ESTADO_ARCHIVO { get; set; }
        [Description("cCodificacion_SiTD")]
        public String cCodificacion_SiTD { get; set; }


        [Category("FECHA"), Description("FECHA_EMISION")]
        public Object FECHA_EMISION { get; set; }
        [Category("FECHA"), Description("FECHA_RECEPCION_OD")]
        public Object FECHA_RECEPCION_OD { get; set; }
        [Category("FECHA"), Description("FECHA_NOTIFICA_TITULAR")]
        public Object FECHA_NOTIFICA_TITULAR { get; set; }
        [Category("FECHA"), Description("FECHA_NOTIFICADOR")]
        public Object FECHA_NOTIFICADOR { get; set; }
        [Category("FECHA"), Description("fdevolucionSEC")]
        public Object fdevolucionSEC { get; set; }

        [Category("LIST"), Description("ListInformes")]
        public List<Ent_FISNOTI> ListInformes { get; set; }
        [Category("LIST"), Description("ListParentesco")]
        public List<Ent_FISNOTI> ListParentesco { get; set; }
        [Category("LIST"), Description("ListEntidades")]
        public List<Ent_FISNOTI> ListEntidades { get; set; }
        [Category("LIST"), Description("ListEliTABLA")]
        public List<Ent_FISNOTI> ListEliTABLA { get; set; }
        [Category("LIST"), Description("ListMComboOD")]
        public List<Ent_FISNOTI> ListMComboOD { get; set; }
        [Category("LIST"), Description("ListIndicador")]
        public List<Ent_FISNOTI> ListIndicador { get; set; }
        [Category("LIST"), Description("ListTipoCNotificacion")]
        public List<Ent_FISNOTI> ListTipoCNotificacion { get; set; }
        [Category("LIST"), Description("ListBusqueda")]
        public List<Ent_FISNOTI> ListBusqueda { get; set; }
        [Description("ORIGEN_REGISTRO")]
        public Int32? ORIGEN_REGISTRO { get; set; }
        [Description("IdEstadoCargo")]
        public Int32? IdEstadoCargo { get; set; }
        [Description("FlagPrimeraVisita")]
        public Boolean? FlagPrimeraVisita { get; set; }
        [Description("FlagActaNotificacion")]
        public Boolean? FlagActaNotificacion { get; set; }
        [Category("FECHA"), Description("FechaPrimeraVisita")]
        public Object FechaPrimeraVisita { get; set; }
        [Description("FlagSegundaVisita")]
        public Boolean? FlagSegundaVisita { get; set; }
        [Category("FECHA"), Description("FechaSegundaVisita")]
        public Object FechaSegundaVisita { get; set; }
        [Description("FlagConformeRecepcion")]
        public Boolean? FlagConformeRecepcion { get; set; }
        [Description("FlagSeNegoRecibir")]
        public Boolean? FlagSeNegoRecibir { get; set; }
        [Description("FlagSeNegoFirmar")]
        public Boolean? FlagSeNegoFirmar { get; set; }
        [Description("FlagBajoPuerta")]
        public Boolean? FlagBajoPuerta { get; set; }
        [Description("MedidorAgua")]
        public Boolean? MedidorAgua { get; set; }
        [Description("MedidorLuz")]
        public Boolean? MedidorLuz { get; set; }
        [Description("NroMedidor")]
        public String NroMedidor { get; set; }
        [Description("MaterialColorFachada")]
        public String MaterialColorFachada { get; set; }
        [Description("MaterialColorPuerta")]
        public String MaterialColorPuerta { get; set; }
        [Description("NroPisos")]
        public String NroPisos { get; set; }
        [Description("CoordenadaUTM")]
        public String CoordenadaUTM { get; set; }
        [Description("TelefonoOtros")]
        public String TelefonoOtros { get; set; }
        [Description("FlagCambioDomicilio")]
        public Boolean? FlagCambioDomicilio { get; set; }
        [Description("DireccionDeCambioDomicilio")]
        public String DireccionDeCambioDomicilio { get; set; }
        [Description("UrbanizacionDeCambioDomicilio")]
        public String UrbanizacionDeCambioDomicilio { get; set; }
        [Description("ReferenciaDeCambioDomicilio")]
        public String ReferenciaDeCambioDomicilio { get; set; }
        [Description("NINTERNET_TITULAR")]
        public int NINTERNET_TITULAR { get; set; }
        public Ent_FISNOTI()
        {
            RegEstado = -1;
            EliVALOR02 = -1;
            ID_TRAMITE_SITD = -1;
            v_currentpage = -1;
            v_pagesize = -1;
            v_row_index = -1;
            NINTERNET_TITULAR = -1;
        }







        #endregion
    }
}
