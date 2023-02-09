using System.Collections.Generic;
using System.ComponentModel;

namespace CapaEntidad.ViewModel
{
    public class VM_INFORME_LEGAL_DIGITAL
    {
        public VM_INFORME_LEGAL_DIGITAL()
        {
            this.RSD = new List<VM_INFORME_LEGAL_DIGITAL_VS_RSD>();
            this.DOCUMENTOS = new List<VM_INFORME_LEGAL_DIGITAL_DOCUMENTO>();
            this.PARTICIPANTES = new List<VM_INFORME_LEGAL_DIGITAL_PARTICIPANTE>();
            this.INFRACCIONES = new List<VM_INFORME_LEGAL_DIGITAL_INFRACCION>();
            this.ELIMINAR = new List<VM_INFORME_LEGAL_DIGITAL_ELIMINAR>();
        }

        public string COD_INFORME_DIGITAL { get; set; }
        public string COD_INFORME { get; set; }
        public string NUM_INFORME_SITD { get; set; }
        public int? TRAMITE_ID { get; set; }
        public string COD_PROCEDENCIA { get; set; }
        public string PROCEDENCIA { get; set; }
        public string COD_TIPO_INFORME { get; set; }
        public string COD_MATERIA { get; set; }
        public string MATERIA { get; set; }
        //public string NRO_REFERENCIA { get; set; }
        public string COD_MODALIDAD { get; set; }

        public string COD_THABILITANTE { get; set; }
        public string COD_TITULAR { get; set; }
        public string NUM_CONTRATO { get; set; }
        public string TITULAR { get; set; }
        public string TITULAR_DOCUMENTO { get; set; }
        public string TITULAR_RUC { get; set; }
        public string TITULAR_ESTADO_RUC { get; set; }
        public string TITULAR_CONDICION_RUC { get; set; }
        public string R_LEGAL { get; set; }
        public string R_LEGAL_DOCUMENTO { get; set; }
        public string R_LEGAL_RUC { get; set; }
        public string UBIGEO_COD_DPTO { get; set; }
        public string UBIGEO_DEPARTAMENTO { get; set; }
        public string UBIGEO_COD_PROV { get; set; }
        public string UBIGEO_PROVINCIA { get; set; }
        public string UBIGEO_COD_DIST { get; set; }
        public string UBIGEO_DISTRITO { get; set; }
        public string UBIGEO_SECTOR { get; set; }
        public bool FLG_CUESTION_PREVIA { get; set; }
        public bool FLG_REC_RESPONSABILIDAD { get; set; }
        public bool FLG_GRAVEDAD_RIESGO { get; set; }
        public bool FLG_SANCION { get; set; }
        public decimal? SANCION_UIT { get; set; }
        public string SANCION_COD_CALCULO { get; set; }
        public bool FLG_MEDIDA_CORRECTIVA { get; set; }
        public bool FLG_MEDIDA_COMPLEMENTARIA { get; set; }
        public bool FLG_RESPONSABLE_SOLIDARIO { get; set; }
        public bool FLG_COMUNICACION_GORE { get; set; }
        public string RUTA_ARCHIVO_REVISION { get; set; }
        public string COD_USUARIO_OPERACION { get; set; }
        public int ESTADO { get; set; }

        public List<VM_INFORME_LEGAL_DIGITAL_VS_RSD> RSD { get; set; }
        public List<VM_INFORME_LEGAL_DIGITAL_DOCUMENTO> DOCUMENTOS { get; set; }
        public List<VM_INFORME_LEGAL_DIGITAL_PARTICIPANTE> PARTICIPANTES { get; set; }
        public List<VM_INFORME_LEGAL_DIGITAL_INFRACCION> INFRACCIONES { get; set; }
        public List<VM_INFORME_LEGAL_DIGITAL_ELIMINAR> ELIMINAR { get; set; }
    }

    public class VM_INFORME_LEGAL_DIGITAL_VS_RSD
    {
        public string codInformeDigital { get; set; }
        public int item { get; set; }
        public string codResolucion { get; set; }
        public string numInforme { get; set; }
        public int estado { get; set; }
        public int accion { get; set; }
    }

    public class VM_INFORME_LEGAL_DIGITAL_DOCUMENTO
    {
        public string codInformeDigital { get; set; }
        public int item { get; set; }
        public string codResolucion { get; set; }
        public string tipo { get; set; }
        public string url { get; set; }
        public string nombre { get; set; }
        public int estado { get; set; }
        public int accion { get; set; }
    }

    public class VM_INFORME_LEGAL_DIGITAL_PARTICIPANTE
    {
        public string codInformeDigital { get; set; }
        public int item { get; set; }
        public string codPersona { get; set; }
        public string numeroDocumento { get; set; }
        public string apellidosNombres { get; set; }
        public string funcion { get; set; }
        public string observacion { get; set; }
        public int? estado { get; set; }
        public int accion { get; set; }
    }

    public class VM_INFORME_LEGAL_DIGITAL_INFRACCION
    {
        public string codInformeDigital { get; set; }
        public int item { get; set; }
        public string codResolucion { get; set; }
        public string codInciso { get; set; }
        public string inciso { get; set; }
        public string titulo { get; set; }
        public string detalle { get; set; }
        public bool flgDesvirtua { get; set; }
        public bool flgSubsana { get; set; }
        public string parrafos { get; set; }
        public int? estado { get; set; }
        public int accion { get; set; }
    }

    public class VM_INFORME_LEGAL_DIGITAL_ELIMINAR
    {
        public string codInformeDigital { get; set; }
        public int item { get; set; }
        public string origen { get; set; } //DOCUMENTO,PARTICIPANTE,INFRACCION,RSD
    }

    public class Informe_Notificacion
    {
        [Description("DESTINATARIOS")]
        public string DESTINATARIOS { get; set; }
        [Description("CC_DESTINATARIOS")]
        public string CC_DESTINATARIOS { get; set; }
        [Description("COD_INFORME")]
        public string COD_INFORME { get; set; }
        [Description("MENSAJE_ENVIO_ALERTA")]
        public string MENSAJE_ENVIO_ALERTA { get; set; }
        [Description("URL_LOCAL")]
        public string URL_LOCAL { get; set; }
    }
}
