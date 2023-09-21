using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CapaEntidad.ViewModel
{
    public class VM_RSD_DIGITAL
    {
        public VM_RSD_DIGITAL()
        {
            this.RECURSOS = new List<VM_RSD_DIGITAL_RECURSO>();
            this.FIRMAS = new List<VM_RSD_DIGITAL_FIRMA>();
            this.ELIMINAR = new List<VM_RSD_DIGITAL_ELIMINAR>();
        }

        public string COD_INFORME_DIGITAL { get; set; }
        public string COD_RES_SUB { get; set; }
        public string NUM_INFORME_SITD { get; set; }
        public int? TRAMITE_ID { get; set; }
        public string COD_PROCEDENCIA { get; set; }
        public string PROCEDENCIA { get; set; }
        public string COD_MATERIA { get; set; }
        public string MATERIA { get; set; }
        public string COD_MODALIDAD { get; set; }
        public string MODALIDAD { get; set; }
        public string NRO_REFERENCIA { get; set; }
        public string COD_TITULAR { get; set; }
        public string DOCUMENTO_TITULAR { get; set; }
        public string TITULAR_ESTADO_RUC { get; set; }
        public string TITULAR_CONDICION_RUC { get; set; }
        public int? RES_DIRECTORAL_ANIO { get; set; }
        public string RES_DIRECTORAL_UND_ORGANICA { get; set; }
        public DateTime? RES_DIRECTORAL_FECHA { get; set; }

        //public string VISTOS { get; set; }
        //public string ANTECEDENTES { get; set; }
        //public string COMPETENCIA { get; set; }
        //public string ANALISIS { get; set; }
        //public string IMPUTACION { get; set; }
        //public string COMUNICACION_EXTERNA { get; set; }
        //public string PARRAFOS_CLICHE { get; set; }
        //public string PIE_PAGINA { get; set; }
        //public string RESOLUCION { get; set; }

        public bool FLG_CADUCIDAD_EXTRACCION { get; set; }
        public bool FLG_IMPUTACION_CARGOS { get; set; }
        public bool FLG_MEDIDAS_CAUTELARES { get; set; }
        public bool FLG_COMUNICACION { get; set; }
        public bool FLG_HERRAMIENTAS_SUBSANAR { get; set; }

        public string RUTA_ARCHIVO_REVISION { get; set; }

        public string COD_USUARIO_OPERACION { get; set; }
        public DateTime FECHA_REGISTRO { get; set; }
        public int ESTADO { get; set; }

        public List<VM_RSD_DIGITAL_RECURSO> RECURSOS { get; set; }
        public List<VM_RSD_DIGITAL_FIRMA> FIRMAS { get; set; }
        public List<VM_RSD_DIGITAL_INFRACCIONES_INFORME> INFRACCIONES { get; set; }
        public List<VM_RSD_DIGITAL_CAUSALES_CADUCIDAD_INFORME> CAUSALES_CADUCIDAD { get; set; }
        public List<VM_RSD_DIGITAL_ELIMINAR> ELIMINAR { get; set; }
    }

    public class VM_RSD_CABECERA
    {
        public string COD_INFORME { get; set; }
        public string TITULAR_SUPERVISADO { get; set; }
        public string DOCUMENTO_TITULAR { get; set; }
        public string REPRESENTANTE_LEGAL { get; set; }
        public string RUC_TITULAR { get; set; }
        public string ASUNTO { get; set; }
        public string COD_THABILITANTE { get; set; }
        public string NUM_THABILITANTE { get; set; }
        public string THABILITANTE_SECTOR { get; set; }
        public string UBIGEO_THABILITANTE { get; set; }
    }

    public class VM_RSD_DIGITAL_RECURSO
    {
        public string codInformeDigital { get; set; }
        public int item { get; set; }
        public string tipo { get; set; }
        public string url { get; set; }
        public string nombre { get; set; }
        public int estado { get; set; }
        public int accion { get; set; }
    }

    public class VM_RSD_DIGITAL_FIRMA
    {
        public string codInformeDigital { get; set; }
        public int item { get; set; }
        public String codPersona { get; set; }
        public string numeroDocumento { get; set; }
        public string apellidosNombres { get; set; }
        public String funcion { get; set; }
        public int? estado { get; set; }
        public int accion { get; set; }
    }

    public class VM_RSD_DIGITAL_INFRACCIONES
    {
        public int codInfraccion { get; set; }
        public string codModalidad { get; set; }
        public string titulo { get; set; }
        public string conducta { get; set; }
        public string tipoInfractor { get; set; }
        public string numeral { get; set; }
        public string sancion { get; set; }
        public string subsanar { get; set; }
        public string codPlantilla { get; set; }
    }

    public class VM_RSD_DIGITAL_INFRACCIONES_INFORME
    {
        public string codInformeDigital { get; set; }
        public int codInfraccion { get; set; }
        public int accion { get; set; }
    }

    public class VM_RSD_DIGITAL_CAUSALES_CADUCIDAD
    {
        public int codCausalCaducidad { get; set; }
        public string titulo { get; set; }
    }

    public class VM_RSD_DIGITAL_CAUSALES_CADUCIDAD_INFORME
    {
        public string codInformeDigital { get; set; }
        public int codCausalCaducidad { get; set; }
        public int accion { get; set; }
    }

    public class VM_RSD_DIGITAL_ELIMINAR
    {
        public string codInformeDigital { get; set; }
        public int item { get; set; }
        public string origen { get; set; } //RECURSO,FIRMA
    }

    public class RSD_Notificacion
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
