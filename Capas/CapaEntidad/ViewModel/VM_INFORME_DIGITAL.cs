using CapaEntidad.DOC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad.ViewModel
{
    public class VM_INFORME_DIGITAL
    {
        public string COD_INFORME_DIGITAL { get; set; }
        public string INFORME_DIGITAL { get; set; }
        public string COD_INFORME { get; set; }
        public string COD_DESTINATARIO { get; set; }
        public string NUM_INFORME_SITD { get; set; }
        public int TRAMITE_ID { get; set; }
        public string ANTECEDENTES { get; set; }
        public string TIPO_BOSQUE { get; set; }
        public string CRONOGRAMA { get; set; }
        public string METODOLOGIA { get; set; }
        public string ANALISIS { get; set; }
        public string RESULTADOS { get; set; }
        public string CONCLUSIONES { get; set; }
        public string RECOMENDACIONES { get; set; }
        public string COD_USUARIO_OPERACION { get; set; }
        public int ESTADO { get; set; }
        public string ARCHIVO { get; set; }
        public DateTime? FECHA_REGISTRO_SITD { get; set; }
        public DateTime FECHA_REGISTRO { get; set; }

        public string COD_THABILITANTE { get; set; }

        public string COD_MTIPO { get; set; }
        public string MODALIDAD_TIPO { get; set; }
        public DateTime? CONTRATO_TH_FECHA_INICIO { get; set; }
        public DateTime? CONTRATO_TH_FECHA_FIN { get; set; }
        public string TITULAR_SUPERVISADO { get; set; }
        public string TITULAR_TIPO_DOC { get; set; } //0000001 - DNI , 0000002 - pasaporte,  0000006 RUC
        public string DOCUMENTO_TITULAR { get; set; }
        public string REPRESENTANTE_LEGAL { get; set; }
        public string RLEGAL_TIPO_DOC { get; set; }  //0000001 - DNI , 0000002 - pasaporte,  0000006 RUC
        public string DOCUMENTO_RLEGAL { get; set; }
        public string NUM_THABILITANTE { get; set; }
        public string UBIGEO_THABILITANTE { get; set; }
        public string RUC_TITULAR { get; set; }
        public string RUC_TITULAR_ESTADO { get; set; }
        public string RUC_TITULAR_CONDICION { get; set; }
        public string RUC_TITULAR_DIRECCION { get; set; }
        public string DIRECCION_LEGAL { get; set; }
        public string SECTOR { get; set; }
        public string TELEFONO_TITULAR { get; set; }
        public decimal AREA_THABILITANTE { get; set; }


        public string OPORTUNIDAD_POA { get; set; }
        public string TIPO_POA { get; set; }
        public string COD_TIPO_POA { get; set; }
        public string NOMBRE_POA { get; set; }
        public string NOMBRE_POA_PRINCIPAL { get; set; }
        public int NUM_POA_PRINCIPAL { get; set; }
        public DateTime? FECHA_PRESENTACION_POA { get; set; }
        public DateTime? FECHA_INICIO_VIGENCIA_POA { get; set; }
        public DateTime? FECHA_FIN_VIGENCIA_POA { get; set; }
        public DateTime? RESOLUCION_POA_FECHA { get; set; }

        public DateTime? FECHA_SUPERVISION_INICIO { get; set; }
        public DateTime? FECHA_SUPERVISION_FIN { get; set; }


        public decimal AREA_POA { get; set; }
        public int NUM_POA { get; set; }
        public string PCA_POA { get; set; }
        public int DURACION_PMF { get; set; }  //NOTA: Un plan de manejo puede ser de tipo: PMFS, PGMF, DEMA, POA/PO, PMFI, PMCA
        public string RESOLUCION_POA { get; set; }
        public string REGENTE_POA { get; set; }
        public string REGENTE_REGISTRO_PROFESIONAL { get; set; }
        public string REGENTE_REGISTRO { get; set; }
        public string LICENCIA_REGENCIA_POA { get; set; }
        public string TELEFONO_REGENTE_POA { get; set; }
        public string CORREO_REGENTE_POA { get; set; }

        //referente al proyecto - para lso casos de fauna
        public DateTime? R_PROYECTO_AUTORIZA_FECHA { get; set; }
        public string R_PROYECTO_AUTORIZA { get; set; }
        public string R_PROYECTO_AUTORIZA_PERSONA { get; set; }
        public DateTime? R_PROYECTO_APRUEBA_FECHA { get; set; }
        public string R_PROYECTO_APRUEBA { get; set; }
        public string R_PROYECTO_APRUEBA_PERSONA { get; set; }
        //nforme Técnico de Inspección Ocular
        public string PROFESIONAL_IOCULAR_POA { get; set; }
        public string ITECNICO_IOCULAR_NUM { get; set; }
        public DateTime? ITECNICO_IOCULAR_FECHA { get; set; }
        //INFORME QUE RECOMIENDA LA APROBACION DEL PLAN DE MANEJO
        public string ITECNICO_RAPROBACION_PROFESIONAL { get; set; }
        public string ITECNICO_RAPROBACION_NUM { get; set; }
        public DateTime? ITECNICO_RAPROBACION_FECHA { get; set; }

        //INFORME QUE RECOMIENDA LA APROBACION DEL PGMF
        public string NUMERO_RECOMIENDA_PGMF { get; set; }
        public DateTime? FECHA_RECOMIENDA_PGMF { get; set; }
        public string COD_CONSULTOR_PGMF { get; set; }
        public string CONSULTOR_PGMF { get; set; }

        public string NUMERO_PGMF { get; set; }
        public DateTime? FECHA_RESOLUCION_PGMF { get; set; }
        public DateTime? FECHA_INICIO_PGMF { get; set; }
        public DateTime? FECHA_FIN_PGMF { get; set; }
        public decimal AREA_PGMF { get; set; }

        public string FUNCIONARIO_APROBACION_POA { get; set; }

        //Acta Ocular
        public string ACTA_IOCULAR_NUM { get; set; }
        public int ACTA_SIN_INS_OCULAR { get; set; }
        public DateTime? ACTA_IOCULAR_FECHA { get; set; }
        public string ACTA_PROFESIONAL_IOCULAR_POA { get; set; }

        public string DEPENDENCIA { get; set; }

        public List<VM_INFORME_DIGITAL_OBJETIVO> OBJETIVOS { get; set; }
        public List<VM_INFORME_DIGITAL_RECURSO> RECURSOS { get; set; }
        public List<VM_INFORME_DIGITAL_PARTICIPANTE> PARTICIPANTES { get; set; }
        public List<VM_INFORME_DIGITAL_ANEXO> ANEXOS { get; set; }
        public List<VM_INFORME_DIGITAL_ACCESO_AREA_TH> ACCESO_AREAS_TH { get; set; }
        public List<VM_INFORME_DIGITAL_ELIMINAR> ELIMINAR { get; set; } //incluir en esta lista todos los items que tengan el campo item con valor mayor a 0

    }
    public class VM_INFORME_DIGITAL_ANTECEDENTE_INICIAL
    {
        public string P1_THABILITANTE { get; set; } //TITULO HABILITANTE
        public string P3_ACTA_RECEPCION { get; set; } //ACTA DE RECEPCION
        public string P6_RESPUESTA_ARFFS { get; set; } //RESPUESTA A LA SOLICITUD DE INFORMACION A LA ARFFS
        public string P13_INFORME_INSPECCION_OCULAR { get; set; }//INFORME DE INSPECCIÓN OCULAR
        public string P14_INFORME_RECOMIENDA_APROB_PLAN { get; set; }//INFORME QUE RECOMIENDA LA APROBACION DEL PLAN DE MANEJO
        public string P15_RESOLUCION_APROB_PLAN { get; set; }//RESOLUCION DE APROBACION DEL PLAN DE MANEJO
        public string P16_INFORME_RECOMIENDA_APROB_PGMF { get; set; }//INFORME QUE RECOMIENDA LA APROBACION DEL PGMF
        public string P17_RESOLUCION_APROB_PGMF { get; set; }//RESOLUCION DE APROBACION DEL PGMF
    }
    public class VM_INFORME_DIGITAL_VERTICE
    {
        public string GRUPO { get; set; }
        public String VERTICE { get; set; }
        public String ZONA { get; set; }
        public Int32 COORDENADA_ESTE { get; set; }
        public Int32 COORDENADA_NORTE { get; set; }
        public decimal area { get; set; }
    }
    public class VM_EVALUACION_VERTICE
    {
        public String VERTICE_TH { get; set; }
        public String VERTICE_SUP { get; set; }
        public String ZONA_TH { get; set; }
        public Int32 COORDENADA_ESTE_TH { get; set; }
        public Int32 COORDENADA_NORTE_TH { get; set; }
        public String ZONA_SUP { get; set; }
        public Int32 COORDENADA_ESTE_SUP { get; set; }
        public Int32 COORDENADA_NORTE_SUP { get; set; }
        public Int32 DIFERENCIA_ESTE { get; set; }
        public Int32 DIFERENCIA_NORTE { get; set; }
        public String OBSERVACION { get; set; }

    }
    public class VM_INFORME_DIGITAL_ANTECEDENTE
    {
        public int orden { get; set; }
        public string descripcion { get; set; }
        public DateTime? fecha { get; set; }
        public string tipo { get; set; }
        public string codTHabilitante { get; set; }
        public int numPoa { get; set; }
        public string NOMBRE_POA { get; set; }
    }
    public class VM_INFORME_DIGITAL_OBJETIVO
    {
        public string codInformeDigital { get; set; }
        public int item { get; set; }
        public int orden { get; set; }
        public String detalle { get; set; }
        public int estado { get; set; }
        public VM_INFORME_DIGITAL_OBJETIVO()
        {
            this.estado = 1;
        }
    }
    public class VM_INFORME_DIGITAL_RECURSO
    {
        public string codInformeDigital { get; set; }
        public int item { get; set; }
        public String tipo { get; set; }
        public String detalle { get; set; }
        public int estado { get; set; }
        public VM_INFORME_DIGITAL_RECURSO()
        {
            this.estado = 1;
        }
    }
    public class VM_INFORME_DIGITAL_PARTICIPANTE
    {
        public string codInformeDigital { get; set; }
        public int item { get; set; }
        public String codParticipante { get; set; }
        public String funcion { get; set; }
        public String observacion { get; set; }
        public string apellidosNombres { get; set; }
        public string numeroDocumento { get; set; }
        public int estado { get; set; }
        public VM_INFORME_DIGITAL_PARTICIPANTE()
        {
            this.estado = 1;
        }
    }
    public class VM_INFORME_DIGITAL_ANEXO
    {
        public string codInformeDigital { get; set; }
        public int item { get; set; }
        public int orden { get; set; }
        public String titulo { get; set; }
        public String detalle { get; set; }
        public int estado { get; set; }
        public VM_INFORME_DIGITAL_ANEXO()
        {
            this.estado = 1;
        }
    }
    public class VM_INFORME_DIGITAL_ACCESO_AREA_TH
    {
        public string codInformeDigital { get; set; }
        public int item { get; set; }
        public String tramo { get; set; }
        public decimal distancia { get; set; }
        public decimal tiempo { get; set; }
        public String transporte { get; set; }
        public String tipoVehiculo { get; set; }
        public String observaciones { get; set; }
        public int estado { get; set; }
        public VM_INFORME_DIGITAL_ACCESO_AREA_TH()
        {
            this.estado = 1;
        }
    }
    public class VM_INFORME_DIGITAL_ELIMINAR
    {
        public string codInformeDigital { get; set; }
        public int item { get; set; }
        public string origen { get; set; } //OBJETIVO,RECURSO,PARTICIPANTE,ANEXO,ACCESO_AREA_TH
    }

    public class VM_CARTA_NOTIFICACION_ANTECEDENTE
    {
        public string tabDetalle { get; set; }
        public string tipoCarta { get; set; }
        public string nroCartaNotificacion { get; set; }
        public DateTime? fechaEmision { get; set; }
        public string nombreRegente { get; set; }
        public string nombreTitular { get; set; }
        public string nombrePlanManejo { get; set; }
        public string resolucionPlanManejo { get; set; }
        public DateTime? fechaNotificacion { get; set; }
        public string personaNotificacion { get; set; }
        public string parentescoPerNotificacion { get; set; }
    }
    public class VM_DOCUMENTO_ANTECEDENTE
    {
        public string tipoDocumento { get; set; }
        public string nroDocumento { get; set; }
        public DateTime? fechaRecepcion { get; set; }
        public string remitente { get; set; }
        public string tipoDocumentoRemitido { get; set; }
        public string nroResolucionAprobacion { get; set; }
    }
    public class VM_INFORME_DIGITAL_PM
    {
        public string COD_INFORME { get; set; }
        public string COD_THABILITANTE { get; set; }
        public int NUM_POA { get; set; }
        public string POA { get; set; }
        public bool PUBLICAR { get; set; }
        public bool SUPERVISADO { get; set; }
        public int B_POA { get; set; }
        public string CODIGO_SEC_NOPOA { get; set; }
        public VM_INFORME_DIGITAL_PM_DATOS DATOS { get; set; }

    }
    public class VM_VOLUMEN_MADERA_ASERRADA
    {
        
        public String COD_THABILITANTE { get; set; }
        public Int32 NUM_POA { get; set; }
        public String COD_ESPECIES { get; set; }
        public String ESPECIES { get; set; }
        public Int32 PIEZAS { get; set; }  
        public String OBSERVACION { get; set; }
        public decimal VL_PT { get; set; }
        public decimal VL_ASERRADA{ get; set; }
        public decimal VL_ROLLIZO { get; set; }

    }
    public class VM_VOLUMEN_MADERA_TROZAS
    {

        public String COD_THABILITANTE { get; set; }
        public Int32 NUM_POA { get; set; }
        public String COD_ESPECIES { get; set; }
        public String ESPECIES { get; set; }
        public Int32 TROZAS { get; set; }
        public String OBSERVACION { get; set; }
        public decimal VL { get; set; }       

    }
    public class VM_INFORME_DIGITAL_PM_DATOS
    {
        public List<Ent_INFORME_ANALISIS> ListAnalisis { get; set; }
        public List<Ent_INFORME_MADERABLE_A> ListMaderable { get; set; }
        public List<Ent_INFORME_CONSOLIDADO> ListConsolidado { get; set; }
        public Ent_INFORME_CONSOLIDADO ConsolidadoTotal { get; set; }
        //public List<Ent_INFORME_TROZA_CAMPO> ListMaderaTrozas { get; set; }
        public List<VM_VOLUMEN_MADERA_TROZAS> ListMaderaTrozas { get; set; }
        //public List<Ent_INFORME_MADERA_ASERRADA> ListMaderaAserrada { get; set; }
        public List<VM_VOLUMEN_MADERA_ASERRADA> ListMaderaAserrada { get; set; }
        public List<VM_INFORME_DIGITAL_VERTICE> ListVerticePM { get; set; }
        public List<VM_ESPECIES> ListEspecieApro { get; set; }
        public List<VM_ESPECIES> ListEspecieAproFaunaConcesion { get; set; }
        public List<OtroPuntoEvaluacion> ListOtroPuntoEvaluacion { get; set; }
        public List<VM_EVALUACION_VERTICE> ListVerticePoaSupervisado { get; set; }
        public VM_INFORME_DIGITAL_PM_DATOS()
        {
            this.ListAnalisis = new List<Ent_INFORME_ANALISIS>();
            this.ListMaderable = new List<Ent_INFORME_MADERABLE_A>();
            this.ListConsolidado = new List<Ent_INFORME_CONSOLIDADO>();
            this.ConsolidadoTotal = new Ent_INFORME_CONSOLIDADO();
            this.ListMaderaTrozas = new List<VM_VOLUMEN_MADERA_TROZAS>();
            this.ListMaderaAserrada = new List<VM_VOLUMEN_MADERA_ASERRADA>();
            this.ListVerticePM = new List<VM_INFORME_DIGITAL_VERTICE>();
            this.ListOtroPuntoEvaluacion = new List<OtroPuntoEvaluacion>();
            this.ListVerticePoaSupervisado = new List<VM_EVALUACION_VERTICE>();
            this.ListEspecieApro = new List<VM_ESPECIES>();
            this.ListEspecieAproFaunaConcesion = new List<VM_ESPECIES>();
        }
    }
    public class VM_SUPERVISOR
    {
        public string COD_PERSONA { get; set; }
        public string APELLIDOS_NOMBRES { get; set; }
        public int FLAG_FIRMA { get; set; }
    }
    public class VM_ESPECIES
    {
        public string COD_ESPECIES { get; set; }
        public string ESPECIE { get; set; }
        public int NUM_ARBOLES { get; set; }
        public decimal VOLUMEN { get; set; }
    }
    public class VM_INFORME_SUSPENSION
    {
        public string nroInforme { get; set; }
        public DateTime? fechaCreacionInforme { get; set; }
        public string nroCartaNotificacion { get; set; }
        public DateTime? fechaCartaNotificacion { get; set; }
        public string motivoSuspension { get; set; }
    }

    /****** ENTIDADES RESUMEN TITULO HABILITANTE *********/
    public class Busqueda
    {
        [Description("BUSVALOR")]
        public string BUSVALOR { get; set; }

        [Description("BUSCRITERIO")]
        public string BUSCRITERIO { get; set; }

        [Description("v_currentpage")]
        public int v_currentpage { get; set; }

        [Description("v_pagesize")]
        public int v_pagesize { get; set; }

        [Description("v_COD_THABILITANTE")]
        public string v_COD_THABILITANTE { get; set; }

        [Description("v_NUM_POA")]
        public int v_NUM_POA { get; set; }

        [Description("v_COD_INFORME")]
        public string v_COD_INFORME { get; set; }

        [Description("v_estado")]
        public int v_estado { get; set; }
    }

    public class THabilitantePOA
    {
        public string cod_thabilitante { get; set; }
        public int num_poa { get; set; }
        public string cod_informe { get; set; }
        public string documento { get; set; }
        public string resolucion_poa { get; set; }
        public string poa_digital { get; set; }
        public int cant_especie { get; set; }
        public decimal volumen { get; set; }
        public int kilogramos { get; set; }
        public string consultor { get; set; }
        public string supervision { get; set; }
        public string numero_informe { get; set; }
        public string informe_digital { get; set; }
        public string anio_informe { get; set; }
        public string estado_pau { get; set; }
        public string estado_conta { get; set; }
        public int id_registro { get; set; }
        public string color { get; set; }
        public string modalidad_conta { get; set; }
        public int estado { get; set; }
        public List<DetRDPOA> rdList { get; set; }
    }

    public class DetRDPOA
    {
        public string numero_rd { get; set; }
        public string digital_rd { get; set; }
    }    
    public class OtroPuntoEvaluacion
    {
        public string evaluacion { get; set; }
        public string zona { get; set; }
        public int coordenadaEste { get; set; }
        public int coordenadaNorte { get; set; }
        public string descripcion { get; set; }
    }
    /****** FIN ENTIDADES RESUMEN TITULO HABILITANTE *********/
}
