using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CapaEntidad.DOC
{
    public class Ent_Reporte_Historial_TH
    {
        #region entidades y propiedades

        [Description("MODALIDAD")]
        public String MODALIDAD { get; set; }

        [Description("TITULO")]
        public String TITULO { get; set; }

        [Description("TITULAR")]
        public String TITULAR { get; set; }
        [Description("NUMERO_DOCUMENTO")]
        public String NUMERO_DOCUMENTO { get; set; }

        [Description("UBICACION")]
        public String UBICACION { get; set; }
        [Description("ESTAB_SECTOR")]
        public String ESTAB_SECTOR { get; set; }

        [Description("DIRECCION")]
        public String DIRECCION { get; set; }

        [Description("AREA_O")]
        public Decimal AREA_O { get; set; }

        [Description("FECHA_INICIO")]
        public Object FECHA_INICIO { get; set; }

        [Description("FECHA_FIN")]
        public Object FECHA_FIN { get; set; }

        [Description("COD_MTIPO")]
        public String COD_MTIPO { get; set; }

        [Description("COD_THABILITANTE")]
        public String COD_THABILITANTE { get; set; }

        [Description("REPRESENTANTE_LEG")]
        public String REPRESENTANTE_LEG { get; set; }

        [Description("N_POA")]
        public Int32 N_POA { get; set; }

        //para la busqueda de reportes
        [Description("BusCriterio")]
        public String BusCriterio { get; set; }

        [Description("BusValor")]
        public String BusValor { get; set; }

        //[Description("BusDepartamento")]
        //public String BusDepartamento { get; set; }

        //[Description("BusLinea")]
        //public String BusLinea { get; set; }

        [Description("V_MESES")]
        public Int32 V_MESES { get; set; }

        [Description("NUM_POA")]
        public Int32 NUM_POA { get; set; }

        [Description("consultor")]
        public String consultor { get; set; }

        [Description("ARESOLUCION_NUM")]
        public String ARESOLUCION_NUM { get; set; }
        [Description("INICIO_VIGENCIA")]
        public String INICIO_VIGENCIA { get; set; }
        [Description("FIN_VIGENCIA")]
        public String FIN_VIGENCIA { get; set; }
        [Description("BEXTRACCION_FEMISION")]
        public String BEXTRACCION_FEMISION { get; set; }

        [Description("ITECNICO_REFORMULA_POA_NUM")]
        public String ITECNICO_REFORMULA_POA_NUM { get; set; }

        [Description("ESTADO_ORIGEN_TIPO")]
        public String ESTADO_ORIGEN_TIPO { get; set; }

        [Description("fecha_aprobacion")]
        public Object fecha_aprobacion { get; set; }

        [Description("COD_RESODIREC")]
        public String COD_RESODIREC { get; set; }

        [Description("NUMERO_RESOLUCION")]
        public String NUMERO_RESOLUCION { get; set; }
        [Description("NUMERO_NOTIFICACION")]
        public String NUMERO_NOTIFICACION { get; set; }
        [Description("FECHA_NOTIFICA_TITULAR")]
        public String FECHA_NOTIFICA_TITULAR { get; set; }
        [Description("TIPO_FISCALIZA")]
        public String TIPO_FISCALIZA { get; set; }

        [Description("COD_ITIPO")]
        public String COD_ITIPO { get; set; }

        [Description("Fecha_Sup")]
        public Object Fecha_Sup { get; set; }

        [Description("MEDIDAS_CAUTELARES")]
        public Object MEDIDAS_CAUTELARES { get; set; }

        //[Description("MEDIDAS_CAUTELARES_RT")]
        //public Object MEDIDAS_CAUTELARES_RT { get; set; }

        [Description("CAUSALES_CADUCIDAD")]
        public Object CAUSALES_CADUCIDAD { get; set; }
        //para lista de arboles aprobados
        [Description("Arboles_aprob")]
        public Int32 Arboles_aprob { get; set; }

        [Description("Volumen_apro")]
        public Decimal Volumen_apro { get; set; }

        [Description("Nombre_Cienti")]
        public String Nombre_Cienti { get; set; }

        [Description("Nombre_Comun")]
        public String Nombre_Comun { get; set; }

        //balance
        [Description("DMC")]
        public Int32 DMC { get; set; }

        [Description("TOTAL_ARBOLES")]
        public Int32 TOTAL_ARBOLES { get; set; }

        [Description("VOLUMEN_AUTORIZADO")]
        public Decimal VOLUMEN_AUTORIZADO { get; set; }

        [Description("VOLUMEN_MOVILIZADO")]
        public Decimal VOLUMEN_MOVILIZADO { get; set; }

        [Description("VOLUMEN_INEXISTENTE")]
        public Decimal VOLUMEN_INEXISTENTE { get; set; }

        [Description("SALDO")]
        public Decimal SALDO { get; set; }

        [Description("Articulos")]
        public String Articulos { get; set; }

        [Description("Encisos")]
        public String Encisos { get; set; }

        //estado del proceso
        [Description("ileg_Descrip")]
        public String ileg_Descrip { get; set; }

        [Description("RD_tipo")]
        public String RD_tipo { get; set; }

        [Description("COD_RESODIREC_Inicio")]
        public String COD_RESODIREC_Inicio { get; set; }

        [Description("Tipo_Inicio")]
        public String Tipo_Inicio { get; set; }

        [Description("RD_termino")]
        public String RD_termino { get; set; }

        [Description("COD_RESODIREC_Termino")]
        public String COD_RESODIREC_Termino { get; set; }

        [Description("COD_INFORME")]
        public String COD_INFORME { get; set; }

        [Description("Tipo_Termino")]
        public String Tipo_Termino { get; set; }

        [Description("descripFin")]
        public String descripFin { get; set; }

        //para el estado del titulo habilitante

        [Description("ESTADO_ORIGEN")]
        public String ESTADO_ORIGEN { get; set; }

        [Description("HIJO_COD_THABILITANTE")]
        public String HIJO_COD_THABILITANTE { get; set; }

        [Description("HIJO_NUM_POA")]
        public Int32 HIJO_NUM_POA { get; set; }

        [Description("HIJO_NIVEL")]
        public Int32 HIJO_NIVEL { get; set; }
        // nuevos items Carlos

        [Description("DIRECCION_TH")]
        public String DIRECCION_TH { get; set; }

        [Description("DIRECCION_LEGAL")]
        public String DIRECCION_LEGAL { get; set; }

        [Description("POA_COMPLEMENT")]
        public Int32 POA_COMPLEMENT { get; set; }

        [Description("PCA")]
        public String PCA { get; set; }

        [Description("ZAFRA")]
        public String ZAFRA { get; set; }

        [Description("NUM_INFORME")]
        public String NUM_INFORME { get; set; }

        [Description("NUM_CNOTIFICACION")]
        public String NUM_CNOTIFICACION { get; set; }

        [Description("ANIO_SUPERV")]
        public Int32 ANIO_SUPERV { get; set; }

        [Description("Supervisor")]
        public String Supervisor { get; set; }

        [Description("RD_INICIO")]
        public String RD_INICIO { get; set; }

        [Description("FECHA_RDINICIO")]
        public String FECHA_RDINICIO { get; set; }

        //[Description("TIPO_RDINICIO")]
        //public String TIPO_RDINICIO { get; set; }

        [Description("CAUSAL_CADUCIDAD")]
        public String CAUSAL_CADUCIDAD { get; set; }

        [Description("INF_FALSA_DAS")]
        public String INF_FALSA_DAS { get; set; }

        [Description("INF_FALSA_DIF")]
        public String INF_FALSA_DIF { get; set; }

        [Description("INF_FALSA_INEX")]
        public String INF_FALSA_INEX { get; set; }

        [Description("RD_TERMINO")]
        public String RD_TERMINO { get; set; }

        [Description("FECHA_RDTERMINO")]
        public String FECHA_RDTERMINO { get; set; }

        //[Description("TIPO_RDTERMINO")]
        //public String TIPO_RDTERMINO { get; set; }

        [Description("DETERMINACION_RDTERMINO")]
        public String DETERMINACION_RDTERMINO { get; set; }
        [Description("AMONESTACION_RT")]
        public String AMONESTACION_RT { get; set; }

        [Description("CADUCIDAD_RDTERMINO")]
        public String CADUCIDAD_RDTERMINO { get; set; }
        [Description("GRAVEDAD_DANIO_RDTERMINO")]
        public String GRAVEDAD_DANIO_RDTERMINO { get; set; }
        [Description("MEDIDAS_CORRECTIVAS_RDTERMINO")]
        public String MEDIDAS_CORRECTIVAS_RDTERMINO { get; set; }
        [Description("MEDIDAS_CAUTELARES_RDTERMINO")]
        public String MEDIDAS_CAUTELARES_RDTERMINO { get; set; }

        [Description("MULTA_RDTERMINO")]
        public String MULTA_RDTERMINO { get; set; }

        [Description("MULTA_MONTO")]
        public String MULTA_MONTO { get; set; }

        [Description("SANCION_EXTITULAR_RDTERMINO")]
        public String SANCION_EXTITULAR_RDTERMINO { get; set; }

        [Description("SANCION")]
        public String SANCION { get; set; }

        //[Description("RD_RECONSIDERACION")]
        //public String RD_RECONSIDERACION { get; set; }

        //[Description("TIPO_RDRECONSIDERACION")]
        //public String TIPO_RDRECONSIDERACION { get; set; }

        //[Description("FUNDADA_RDRECON")]
        //public String FUNDADA_RDRECON { get; set; }

        //[Description("FUNDADA_PARTE_RDRECON")]
        //public String FUNDADA_PARTE_RDRECON { get; set; }

        //[Description("IMPROCEDENTE_RDRECON")]
        //public String IMPROCEDENTE_RDRECON { get; set; }

        //[Description("INFUNDADA_RDRECON")]
        //public String INFUNDADA_RDRECON { get; set; }

        //[Description("CAMBIO_MULTA_RDRECON")]
        //public String CAMBIO_MULTA_RDRECON { get; set; }

        //[Description("MONTO_RDRECON")]
        //public String MONTO_RDRECON { get; set; }

        //[Description("RD_AMPLIACION")]
        //public String RD_AMPLIACION { get; set; }

        //[Description("TIPO_RDAMPLIACION")]
        //public String TIPO_RDAMPLIACION { get; set; }

        //[Description("FECHA_RDAMPLIACION")]
        //public String FECHA_RDAMPLIACION { get; set; }

        //[Description("AMPLIAR_IMPUTACION_RDAMPLIACION")]
        //public String AMPLIAR_IMPUTACION_RDAMPLIACION { get; set; }

        //[Description("AMPLIAR_INFRACCIONES_RDAMPLIACION")]
        //public String AMPLIAR_INFRACCIONES_RDAMPLIACION { get; set; }

        //[Description("AMPLIACION_PLAZOS_RDAMPLIACION")]
        //public String AMPLIACION_PLAZOS_RDAMPLIACION { get; set; }

        //[Description("OTROS_RDAMPLIACION")]
        //public String OTROS_RDAMPLIACION { get; set; }

        [Description("NUMERO")]
        public String NUMERO { get; set; }

        [Description("NUMERO_ARBOLES")]
        public Int32 NUMERO_ARBOLES { get; set; }

        [Description("VOLUMEN_ARBOLES")]
        public Decimal VOLUMEN_ARBOLES { get; set; }
        [Description("UNIDAD_MEDIDA")]
        public String UNIDAD_MEDIDA { get; set; }
        [Description("TIPO_APROVECHAMIENTO")]
        public String TIPO_APROVECHAMIENTO { get; set; }

        [Description("ID_REGISTRO")]
        public Int32 ID_REGISTRO { get; set; }

        [Description("NUM_POA_STRING")]
        public String NUM_POA_STRING { get; set; }

        [Description("DOC_SIADO")]
        public String DOC_SIADO { get; set; }

        [Description("NUM_RESODIREC_RECONSIDERACION")]
        public String NUM_RESODIREC_RECONSIDERACION { get; set; }

        [Description("DOC_SIADO_RECONSIDERACION")]
        public String DOC_SIADO_RECONSIDERACION { get; set; }


        [Description("ANIO_SUP")]
        public String ANIO_SUP { get; set; }

        //TEMPORAL HASTA OBTENER LOS VERTICES DE GEOMATICA
        //[Description("LONGITUD")]
        //public String LONGITUD { get; set; }
        //[Description("LATITUD")]
        //public String LATITUD { get; set; }

        [Description("INEX")]
        public Int32 INEX { get; set; }
        [Description("COINC")]
        public Int32 COINC { get; set; }
        /**
         * para los arboles supervisados
         */
        [Description("COD_ESPECIES")]
        public String COD_ESPECIES { get; set; }
        [Description("NOMBRE_COMUN")]
        public String NOMBRE_COMUN { get; set; }
        [Description("NOMBRE_CIENTIFICO")]
        public String NOMBRE_CIENTIFICO { get; set; }
        [Description("PARCELA")]
        public String PARCELA { get; set; }
        [Description("ESPECIES")]
        public Int32 ESPECIES { get; set; }
        [Description("INXISTENCIA")]
        public Int32 INXISTENCIA { get; set; }
        [Description("PORCENTAJE_INEX")]
        public Decimal PORCENTAJE_INEX { get; set; }
        [Description("EN_PIE")]
        public Int32 EN_PIE { get; set; }
        [Description("TUMBADO")]
        public Int32 TUMBADO { get; set; }
        [Description("TOCON")]
        public Int32 TOCON { get; set; }
        [Description("NO_EVALUADO")]
        public Int32 NO_EVALUADO { get; set; }
        [Description("SIN_DATOS")]
        public Int32 SIN_DATOS { get; set; }

        [Description("OBSERVACIONES")]
        public String OBSERVACIONES { get; set; }
        [Description("FECHA_SUPERVISION_INICIO")]
        public String FECHA_SUPERVISION_INICIO { get; set; }
        [Description("FECHA_SUPERVISION_FIN")]
        public String FECHA_SUPERVISION_FIN { get; set; }
        [Description("REGENTE_IMPLEMENTA")]
        public String REGENTE_IMPLEMENTA { get; set; }
        [Description("ARCHIVA_INFORME")]
        public String ARCHIVA_INFORME { get; set; }
        [Description("SUPERVISOR")]
        public String SUPERVISOR { get; set; }
        [Description("VOLUMEN_INJUSTIFICADO")]
        public Decimal VOLUMEN_INJUSTIFICADO { get; set; }
        [Description("INDICIO_APROV")]
        public String INDICIO_APROV { get; set; }

        //[Description("COD_PROVARCH")]
        //public String COD_PROVARCH { get; set; }

        //[Description("ILEGAL_NUMERO")]
        //public String ILEGAL_NUMERO { get; set; }

        [Description("FECHA_PROVEIDO")]
        public Object FECHA_PROVEIDO { get; set; }

        [Description("INFRACCIONES")]
        public Object INFRACCIONES { get; set; }

        [Description("INFRACCIONES_TER")]
        public Object INFRACCIONES_TER { get; set; }

        [Description("DEPARTAMENTO")]
        public String DEPARTAMENTO { get; set; }

        [Description("PROVINCIA")]
        public String PROVINCIA { get; set; }

        [Description("DISTRITO")]
        public String DISTRITO { get; set; }

        // PARA LAS NOTIFICACIONES
        [Description("FECHA_NOT")]
        public Object FECHA_NOT { get; set; }

        [Description("PERSONA_NOT")]
        public String PERSONA_NOT { get; set; }

        [Description("PARENTESCO")]
        public String PARENTESCO { get; set; }

        [Description("NUM_EXP")]
        public String NUM_EXP { get; set; }

        [Description("PORCENT_INJUST_MOVIL")]
        public Decimal PORCENT_INJUST_MOVIL { get; set; }

        [Description("PORCENT_INJUST_APROV")]
        public Decimal PORCENT_INJUST_APROV { get; set; }

        // btn style class
        [Description("BTN_STYLE_CLASS")]
        public String BTN_STYLE_CLASS { get; set; }

        // btn name
        [Description("BTN_NAME")]
        public String BTN_NAME { get; set; }

        // btn visible
        [Description("BTN_VISIBLE")]
        public Object BTN_VISIBLE { get; set; }

        //[Description("BTN_VISIBLE2")]
        //public Object BTN_VISIBLE2 { get; set; }

        //[Description("BTN_VISIBLE3")]
        //public Object BTN_VISIBLE3 { get; set; }

        [Description("ESTADO_CONTA")]
        public String ESTADO_CONTA { get; set; }

        [Description("NUMEROTITULOHABILITANTE")]
        public String NUM_THABILITANTE { get; set; }

        [Description("ESTADO")]
        public String ESTADO_PROCESOJUDICIALIZADO { get; set; }

        [Description("FECHANOTIFICACION")]
        public String FECHA_NOTIFICACION_RDTERMINO { get; set; }

        [Description("NUM_RESOLUCION_SIGO")]
        public String NUM_RESOLUCION_SIGO { get; set; }
        [Description("ESTADO")]
        public String ESTADO_RESOLUCION { get; set; }

        [Description("TIPO_EXPEDIENTE")]
        public String TIPO_EXPEDIENTE_RD { get; set; }

        [Description("id")]
        public int ID_D { get; set; }

        [Description("uiT")]
        public decimal UIT_D { get; set; }

        [Description("factor_uit")]
        public decimal FACTOR_UIT_D { get; set; }

        [Description("multa_impuesta")]
        public decimal MULTA_IMPUESTA_D { get; set; }

        [Description("pago_multa")]
        public decimal PAGO_MULTA_D { get; set; }

        [Description("ajuste")]
        public decimal AJUSTE_D { get; set; }

        [Description("descuento")]
        public decimal DESCUENTO_D { get; set; }

        [Description("compensacion")]
        public decimal COMPENSACION_D { get; set; }

        [Description("saldo")]
        public decimal SALDO_D { get; set; }


        [Description("interes")]
        public decimal INTERES_D { get; set; }

        [Description("total")]
        public decimal TOTAL_D { get; set; }

        [Description("cta_contable")]
        public string CTA_CONTABLE_D { get; set; }

        [Description("otros_ingresos")]
        public decimal OTROS_INGRESOS_D { get; set; }

        [Category("LIST"), Description("ListDEUDAS")]
        public List<Ent_Reporte_Historial_TH> ListDEUDAS { get; set; }

        [Description("fecha")]
        public string FECHA_P { get; set; }

        [Description("multa")]
        public double MULTA_P { get; set; }

        [Description("interes")]
        public double INTERES_P { get; set; }

        [Description("cuota")]
        public double CUOTA_P { get; set; }

        [Description("voucher")]
        public string VOUCHER_P { get; set; }

        [Description("recibo")]
        public string RECIBO_P { get; set; }
        [Description("band")]
        public string BAND_P { get; set; }
        [Description("fecha_orden")]
        public string FECHA_ORDEN_P { get; set; }

        [Description("otrosIngresos")]
        public double OTROSINGRESOS_P { get; set; }

        [Category("LIST"), Description("ListPAGOS")]
        public List<Ent_Reporte_Historial_TH> ListPAGOS { get; set; }

        [Description("periodo")]
        public int PERIODO_C { get; set; }

        [Description("fecha")]
        public string FECHA_C { get; set; }

        [Description("saldo")]
        public decimal SALDO_C { get; set; }

        [Description("multa")]
        public decimal MULTA_C { get; set; }

        [Description("interes")]
        public decimal INTERES_C { get; set; }

        [Description("cuota")]
        public decimal CUOTA_C { get; set; }

        [Description("nroRecibo")]
        public string NRORECIBO_C { get; set; }

        [Description("periodo_p")]
        public int PERIODO_P_C { get; set; }

        [Description("fecha_p")]
        public string FECHA_P_C { get; set; }


        [Description("saldo_p")]
        public decimal SALDO_P_C { get; set; }

        [Description("multa_p")]
        public decimal MULTA_P_C { get; set; }

        [Description("interes_p")]
        public decimal INTERES_P_C { get; set; }

        [Description("cuota_p")]
        public decimal CUOTA_P_C { get; set; }

        [Description("nroRecibo_p")]
        public string NRORECIBO_P_C { get; set; }

        [Category("LIST"), Description("ListCRONOGRAMA")]
        public List<Ent_Reporte_Historial_TH> ListCRONOGRAMA { get; set; }

        [Description("SigCorrelativo")]
        public int SIGCORRELATIVO_CM { get; set; }

        [Description("SigNomTitular")]
        public string SIGNOMTITULAR_CM { get; set; }

        [Description("ResIdentity")]
        public int RESIDENTITY_CM { get; set; }

        [Description("ResJefAprobComp_Nro")]
        public string RESJEFAPROBCOMP_NRO_CM { get; set; }
        [Description("ResJefAprobComp_Fecha")]
        public string RESJEFAPROBCOMP_FECHA_CM { get; set; }
        [Description("ResJefAprobComp_NroActa")]
        public string RESJEFAPROBCOMP_NROACTA_CM { get; set; }
        [Description("ResJefAprobComp_FechaNot")]
        public string RESJEFAPROBCOMP_FECHANOT_CM { get; set; }


        [Description("ResJefAprobCompFracc_Nro")]
        public string RESJEFAPROBCOMPFRACC_NRO_CM { get; set; }
        [Description("ResJefAprobCompFracc_Fecha")]
        public string RESJEFAPROBCOMPFRACC_FECHA_CM { get; set; }
        [Description("ResJefAprobCompFracc_NroActa")]
        public string RESJEFAPROBCOMPFRACC_NROACTA_CM { get; set; }
        [Description("ResJefAprobCompFracc_FechaNot")]
        public string RESJEFAPROBCOMPFRACC_FECHANOT_CM { get; set; }


        [Description("ResJefPerdComp_Nro")]
        public string RESJEFPERDCOMP_NRO_CM { get; set; }
        [Description("ResJefPerdComp_Fecha")]
        public string RESJEFPERDCOMP_FECHA_CM { get; set; }
        [Description("ResJefPerdComp_NroActa")]
        public string RESJEFPERDCOMP_NROACTA_CM { get; set; }
        [Description("ResJefPerdComp_FechaNot")]
        public string RESJEFPERDCOMP_FECHANOT_CM { get; set; }


        [Description("ResJefPerdCompFracc_Nro")]
        public string RESJEFPERDCOMPFRACC_NRO_CM { get; set; }
        [Description("ResJefPerdCompFracc_Fecha")]
        public string RESJEFPERDCOMPFRACC_FECHA_CM { get; set; }
        [Description("ResJefPerdCompFracc_NroActa")]
        public string RESJEFPERDCOMPFRACC_NROACTA_CM { get; set; }
        [Description("ResJefPerdCompFracc_FechaNot")]
        public string RESJEFPERDCOMPFRACC_FECHANOT_CM { get; set; }


        [Category("LIST"), Description("ListCOMPENSACION")]
        public List<Ent_Reporte_Historial_TH> ListCOMPENSACION { get; set; }

        [Description("ResIdentity")]
        public int RESIDENTITY { get; set; }

        [Description("anio")]
        public int ANIO_CC { get; set; }
        [Description("fecha")]
        public string FECHA_CC { get; set; }
        [Description("montoCompensable")]
        public decimal MONTOCOMPENSABLE_CC { get; set; }
        [Description("fecha_p")]
        public string FECHA_P_CC { get; set; }
        [Description("montoCompensable_p")]
        public decimal MONTOCOMPENSABLE_P_CC { get; set; }
        [Description("nroInforme")]
        public string NROINFORME_CC { get; set; }
        [Description("fechaInforme")]
        public string FECHAINFORME_CC { get; set; }
        [Description("nroRJ")]
        public string NRORJ_CC { get; set; }
        [Description("fechaRJ")]
        public string FECHARJ_CC { get; set; }
        [Description("cuentaContable")]
        public string CUENTACONTABLE_CC { get; set; }
        [Description("CompEstado")]
        public int COMPESTADO_CC { get; set; }
        [Category("LIST"), Description("ListCRONOCOMPENSACION")]
        public List<Ent_Reporte_Historial_TH> ListCRONOCOMPENSACION { get; set; }


        //[Description("OCULTAR_COLUMNA")]
        //public Object OCULTAR_COLUMNA { get; set; }
        [Category("LIST"), Description("ListDomicilio")]
        public List<Ent_Reporte_Historial_TH> ListDomicilio { get; set; }
        [Category("LIST"), Description("ListAdendas")]
        public List<Ent_Reporte_Historial_TH> ListAdendas { get; set; }
        [Category("LIST"), Description("ListPOATH")]
        public List<Ent_Reporte_Historial_TH> ListPOATH { get; set; }
        [Category("LIST"), Description("ListINFORMETH")]
        public List<Ent_Reporte_Historial_TH> ListINFORMETH { get; set; }
        [Category("LIST"), Description("ListINFTIT")]
        public List<Ent_Reporte_Historial_TH> ListINFTIT { get; set; }
        [Category("LIST"), Description("ListPOARBAPRO")]
        public List<Ent_Reporte_Historial_TH> ListPOARBAPRO { get; set; } //para los arboles y volumenes aprobados
        [Category("LIST"), Description("ListPOABalance")]
        public List<Ent_Reporte_Historial_TH> ListPOABalance { get; set; } //para los arboles y volumenes balance
        [Category("LIST"), Description("ListPOAReformula")]
        public List<Ent_Reporte_Historial_TH> ListPOAReformula { get; set; } //para los arboles y volumenes reformula
        [Category("LIST"), Description("ListSupervision")]
        public List<Ent_Reporte_Historial_TH> ListSupervision { get; set; } //para los arboles y volumenes reformula
        [Category("LIST"), Description("ListInfracciones")]
        public List<Ent_Reporte_Historial_TH> ListInfracciones { get; set; } //Infracciones
        [Category("LIST"), Description("ListPOACompl")]
        public List<Ent_Reporte_Historial_TH> ListPOACompl { get; set; } //POA complementarios
        [Category("LIST"), Description("ListPOAReing")]
        public List<Ent_Reporte_Historial_TH> ListPOAReing { get; set; } //POA  reingreso
        [Category("LIST"), Description("ListPOAMSaldo")]
        public List<Ent_Reporte_Historial_TH> ListPOAMSaldo { get; set; } //POA  Movilizacion de saldo
        [Category("LIST"), Description("ListInexistencia")]
        public List<Ent_Reporte_Historial_TH> ListInexistencia { get; set; } //inexistencias
        [Category("LIST"), Description("ListVolumenInexistencia")]
        public List<Ent_Reporte_Historial_TH> ListVolumenInexistencia { get; set; } //volumen de inexistencia

        [Category("LIST"), Description("ListVolumenAnalizado")]
        public List<Ent_Reporte_Historial_TH> ListVolumenAnalizado { get; set; } //Notificación de resolución Sub Directoral de Inicio de PAU
        [Category("LIST"), Description("ListNotRDINICIO")]
        public List<Ent_Reporte_Historial_TH> ListNotRDINICIO { get; set; } //Notificación de resolución Sub Directoral de Inicio de PAU
        [Category("LIST"), Description("ListNotRDTERMINO")]
        public List<Ent_Reporte_Historial_TH> ListNotRDTERMINO { get; set; } //Notificación de resolución Sub Directoral de Término de PAU

        //cambios en el historial titulo habilitante interno

        [Description("RECONS_COD_RESODIREC")]
        public String RECONS_COD_RESODIREC { get; set; }
        [Description("RECONS_NUM_RESOLUCION")]
        public String RECONS_NUM_RESOLUCION { get; set; }
        [Description("RECONS_CODFCTIPO")]
        public String RECONS_CODFCTIPO { get; set; }
        [Description("RECONS_RD_FECHA")]
        public Object RECONS_RD_FECHA { get; set; }
        [Description("FECHA_RDRECONS")]
        public String FECHA_RDRECONS { get; set; }
        [Description("RECONS_IMPROCEDENTE")]
        public String RECONS_IMPROCEDENTE { get; set; }
        [Description("RECONS_FUNDADA")]
        public String RECONS_FUNDADA { get; set; }
        [Description("RECONS_FUNDADA_PARTE")]
        public String RECONS_FUNDADA_PARTE { get; set; }
        [Description("RECONS_INFUNDADA")]
        public String RECONS_INFUNDADA { get; set; }
        [Description("RECONS_INADMISIBLE")]
        public String RECONS_INADMISIBLE { get; set; }
        [Description("RECONS_LEVANTAR_CADUCIDAD")]
        public String RECONS_LEVANTAR_CADUCIDAD { get; set; }
        [Description("RECONS_CAMBIO_MULTA")]
        public String RECONS_CAMBIO_MULTA { get; set; }
        [Description("RECONS_MONTO")]
        public String RECONS_MONTO { get; set; }
        [Description("RECT_COD_RESODIREC")]
        public String RECT_COD_RESODIREC { get; set; }
        [Description("RECT_NUM_RESOLUCION")]
        public String RECT_NUM_RESOLUCION { get; set; }
        [Description("RECT_CODFCTIPO")]
        public String RECT_CODFCTIPO { get; set; }
        [Description("RECT_RD_FECHA")]
        public String RECT_RD_FECHA { get; set; }
        [Description("RECT_ERRORMATERIAL")]
        public String RECT_ERRORMATERIAL { get; set; }
        [Description("RECT_CAMBIO_MULTA")]
        public String RECT_CAMBIO_MULTA { get; set; }
        [Description("RECT_MONTO")]
        public String RECT_MONTO { get; set; }
        [Description("RECT_OTROS")]
        public String RECT_OTROS { get; set; }
        [Description("RECT_DESC_OTROS")]
        public String RECT_DESC_OTROS { get; set; }
        [Description("ACUM_COD_RESODIREC")]
        public String ACUM_COD_RESODIREC { get; set; }
        [Description("ACUM_NUM_RESOLUCION")]
        public String ACUM_NUM_RESOLUCION { get; set; }
        [Description("ACUM_COD_FCTIPO")]
        public String ACUM_COD_FCTIPO { get; set; }
        [Description("ACUM_FECHA_EMISION")]
        public String ACUM_FECHA_EMISION { get; set; }
        [Description("ACUM_DESCRIPCION")]
        public String ACUM_DESCRIPCION { get; set; }
        [Description("AMP_COD_RESODIREC")]
        public String AMP_COD_RESODIREC { get; set; }
        [Description("AMP_NUM_RESOLUCION")]
        public String AMP_NUM_RESOLUCION { get; set; }
        [Description("AMP_COD_FCTIPO")]
        public String AMP_COD_FCTIPO { get; set; }
        [Description("RD_FECHA_EMISION_AMP")]
        public String RD_FECHA_EMISION_AMP { get; set; }
        [Description("AMP_IMPUTACION")]
        public String AMP_IMPUTACION { get; set; }
        [Description("AMP_OTRAS_INFRACCIONES")]
        public String AMP_OTRAS_INFRACCIONES { get; set; }
        [Description("AMP_POR_PLAZOS")]
        public String AMP_POR_PLAZOS { get; set; }
        [Description("AMP_OTROS")]
        public String AMP_OTROS { get; set; }
        [Description("CAD_COD_RESODIREC")]
        public String CAD_COD_RESODIREC { get; set; }
        [Description("CAD_NUM_RESOLUCION")]
        public String CAD_NUM_RESOLUCION { get; set; }
        [Description("CAD_COD_FCTIPO")]
        public String CAD_COD_FCTIPO { get; set; }
        [Description("CAD_RD_FECHA")]
        public String CAD_RD_FECHA { get; set; }
        [Description("CAD_NUM_EXP")]
        public String CAD_NUM_EXP { get; set; }
        [Description("CAD_CADUCIDAD")]
        public String CAD_CADUCIDAD { get; set; }
        [Description("OTROS_COD_RESODIREC")]
        public String OTROS_COD_RESODIREC { get; set; }
        [Description("OTROS_NUM_RESOLUCION")]
        public String OTROS_NUM_RESOLUCION { get; set; }
        [Description("OTROS_COD_FCTIPO")]
        public String OTROS_COD_FCTIPO { get; set; }
        [Description("OTROS_RD_FECHA")]
        public String OTROS_RD_FECHA { get; set; }
        [Description("OTROS_DETERMINACION")]
        public String OTROS_DETERMINACION { get; set; }
        [Description("VARI_COD_RESODIREC")]
        public String VARI_COD_RESODIREC { get; set; }
        [Description("VARI_NUM_RESOLUCION")]
        public String VARI_NUM_RESOLUCION { get; set; }
        [Description("VARI_COD_FCTIPO")]
        public String VARI_COD_FCTIPO { get; set; }
        [Description("VARI_RD_FECHA")]
        public String VARI_RD_FECHA { get; set; }
        [Description("VARI_LEVANTAR")]
        public String VARI_LEVANTAR { get; set; }
        [Description("VARI_LEVANTAR_PARTE")]
        public String VARI_LEVANTAR_PARTE { get; set; }
        [Description("VARI_NO_LEVANTAR")]
        public String VARI_NO_LEVANTAR { get; set; }
        [Description("VARI_MODIFICAR")]
        public String VARI_MODIFICAR { get; set; }
        [Description("VARI_DETERMINACION")]
        public String VARI_DETERMINACION { get; set; }

        [Description("ARCH_COD_RESODIREC")]
        public String ARCH_COD_RESODIREC { get; set; }
        [Description("ARCH_NUM_RESOLUCION")]
        public String ARCH_NUM_RESOLUCION { get; set; }
        [Description("ARCH_FECHA_RD")]
        public String ARCH_FECHA_RD { get; set; }
        [Description("ARCH_COD_FCTIPO")]
        public String ARCH_COD_FCTIPO { get; set; }
        [Description("ARCH_EVIDENCIA_IRRE")]
        public String ARCH_EVIDENCIA_IRRE { get; set; }
        [Description("ARCH_SIN_INFRACCION")]
        public String ARCH_SIN_INFRACCION { get; set; }
        [Description("ARCH_BUEN_MANEJO")]
        public String ARCH_BUEN_MANEJO { get; set; }
        [Description("ARCH_DEFICIENTE_NOT")]
        public String ARCH_DEFICIENTE_NOT { get; set; }
        [Description("ARCH_DEFICIENCIA_TEC")]
        public String ARCH_DEFICIENCIA_TEC { get; set; }
        [Description("OTROS")]
        public String OTROS { get; set; }

        //tribunal
        //[Description("COD_TRIBUNAL")]
        //public String COD_TRIBUNAL { get; set; }
        //[Description("NUM_RDTFFS")]
        //public String NUM_RDTFFS { get; set; }
        [Description("FECHA_TFFS")]
        public String FECHA_TFFS { get; set; }
        //[Description("DECLARA")]
        //public String DECLARA { get; set; }
        //[Description("RESUELVE")]
        //public String RESUELVE { get; set; }
        //[Description("REFERENCIA")]
        //public String REFERENCIA { get; set; }

        [Description("INEX_AGUAJAL")]
        public String INEX_AGUAJAL { get; set; }
        [Description("PORC_AGUAJAL")]
        public String PORC_AGUAJAL { get; set; }
        [Description("NUM_ARBNOU_AGUAJAL")]
        public String NUM_ARBNOU_AGUAJAL { get; set; }
        [Description("AGUAJAL_OBSERV")]
        public String AGUAJAL_OBSERV { get; set; }
        [Description("INEX_PASTIZAL")]
        public String INEX_PASTIZAL { get; set; }
        [Description("PORC_PASTIZAL")]
        public String PORC_PASTIZAL { get; set; }
        [Description("NUM_ARBNOU_PASTIZAL")]
        public String NUM_ARBNOU_PASTIZAL { get; set; }
        [Description("PASTIZAL_OBSERV")]
        public String PASTIZAL_OBSERV { get; set; }
        [Description("INEX_INACCESIBLE")]
        public String INEX_INACCESIBLE { get; set; }
        [Description("PORC_INACCESIBLE")]
        public String PORC_INACCESIBLE { get; set; }
        [Description("NUM_ARBNOU_INACCESIBLE")]
        public String NUM_ARBNOU_INACCESIBLE { get; set; }
        [Description("INACCESIBLE_OBSERV")]
        public String INACCESIBLE_OBSERV { get; set; }
        [Description("INEX_OTROS")]
        public String INEX_OTROS { get; set; }
        [Description("PORC_OTROS")]
        public String PORC_OTROS { get; set; }
        [Description("NUM_ARBNOU_OTROS")]
        public String NUM_ARBNOU_OTROS { get; set; }
        [Description("OTROS_OBSERV")]
        public String OTROS_OBSERV { get; set; }

        // para obtener lista de regiones y modalidades para el zoobservatorio
        [Description("CODIGO")]
        public String CODIGO { get; set; }
        [Description("DESCRIPCION")]
        public String DESCRIPCION { get; set; }
        [Description("BusFormulario")]
        public String BusFormulario { get; set; }
        [Category("LIST"), Description("ListModalidad")]
        public List<Ent_Reporte_Historial_TH> ListModalidad { get; set; } //POA  Movilizacion de saldo
        [Category("LIST"), Description("ListRegion")]
        public List<Ent_Reporte_Historial_TH> ListRegion { get; set; } //POA  Movilizacion de saldo

        //COD_DOC SIADO
        [Description("COD_DOCINFORME")]
        public String COD_DOCINFORME { get; set; }
        [Description("COD_DOCRDINICIO")]
        public String COD_DOCRDINICIO { get; set; }
        [Description("COD_DOCRDTERMINO")]
        public String COD_DOCRDTERMINO { get; set; }
        [Description("DOC_RECONS")]
        public String DOC_RECONS { get; set; }
        [Description("DOC_RECTIFICACION")]
        public String DOC_RECTIFICACION { get; set; }

        //tribunal inicio
        [Description("COD_TRIBUNAL_INI")]
        public String COD_TRIBUNAL_INI { get; set; }
        [Description("NUM_TFFSINI")]
        public String NUM_TFFSINI { get; set; }
        [Description("DETERMINA")]
        public String DETERMINA { get; set; }
        [Description("MOTIVO")]
        public String MOTIVO { get; set; }
        [Description("DOC_RETRO")]
        public String DOC_RETRO { get; set; }
        [Description("ESTADO_TFFS")]
        public String ESTADO_TFFS { get; set; }
        [Description("FECHA_EMISION_RITFFS")]
        public String FECHA_EMISION_RITFFS { get; set; }
        [Description("APELACION_RITFFS")]
        public String APELACION_RITFFS { get; set; }
        [Description("SENTIDO_RESOLUCION_RITFFS")]
        public String SENTIDO_RESOLUCION_RITFFS { get; set; }
        [Description("CONFIRM_RESOLUCION_RITFFS")]
        public String CONFIRM_RESOLUCION_RITFFS { get; set; }
        [Description("LEVANTAMIENTO_RESOLUCION_RITFFS")]
        public String LEVANTAMIENTO_RESOLUCION_RITFFS { get; set; }
        [Description("CAMBIO_MULTA_RITFFS")]
        public String CAMBIO_MULTA_RITFFS { get; set; }
        [Description("MULTA_RITFFS")]
        public Decimal MULTA_RITFFS { get; set; }
        [Description("ESTADO_PAU_RITFFS")]
        public String ESTADO_PAU_RITFFS { get; set; }
        [Description("DOC_SIADO_RITFFS")]
        public String DOC_SIADO_RITFFS { get; set; }
        // tribunal termino
        [Description("COD_TRIBUNAL_TER")]
        public String COD_TRIBUNAL_TER { get; set; }
        [Description("NUM_TFFSTER")]
        public String NUM_TFFSTER { get; set; }
        [Description("DETERMINA_TFFSTER")]
        public String DETERMINA_TFFSTER { get; set; }
        [Description("MOTIVO_TFFSTER")]
        public String MOTIVO_TFFSTER { get; set; }
        [Description("DOC_RETRO_TFFSTER")]
        public String DOC_RETRO_TFFSTER { get; set; }
        [Description("ESTADO_TFFSTER")]
        public String ESTADO_TFFSTER { get; set; }
        [Description("FECHA_EMISION_RTTFFS")]
        public String FECHA_EMISION_RTTFFS { get; set; }
        [Description("APELACION_RTTFFS")]
        public String APELACION_RTTFFS { get; set; }
        [Description("SENTIDO_RESOLUCION_RTTFFS")]
        public String SENTIDO_RESOLUCION_RTTFFS { get; set; }
        [Description("CONFIRM_RESOLUCION_RTTFFS")]
        public String CONFIRM_RESOLUCION_RTTFFS { get; set; }
        [Description("LEVANTAMIENTO_RESOLUCION_RTTFFS")]
        public String LEVANTAMIENTO_RESOLUCION_RTTFFS { get; set; }
        [Description("CAMBIO_MULTA_RTTFFS")]
        public String CAMBIO_MULTA_RTTFFS { get; set; }
        [Description("MULTA_RTTFFS")]
        public Decimal MULTA_RTTFFS { get; set; }
        [Description("ESTADO_PAU_RTTFFS")]
        public String ESTADO_PAU_RTTFFS { get; set; }
        [Description("DOC_SIADO_RTTFFS")]
        public String DOC_SIADO_RTTFFS { get; set; }
        //tribunal reconsideracion
        [Description("COD_TRIBUNAL_REC")]
        public String COD_TRIBUNAL_REC { get; set; }
        [Description("NUM_TFFSREC")]
        public String NUM_TFFSREC { get; set; }
        [Description("DETERMINA_TFFSREC")]
        public String DETERMINA_TFFSREC { get; set; }
        [Description("MOTIVO_TFFSREC")]
        public String MOTIVO_TFFSREC { get; set; }
        [Description("DOC_RETRO_TFFSREC")]
        public String DOC_RETRO_TFFSREC { get; set; }
        [Description("ESTADO_TFFSREC")]
        public String ESTADO_TFFSREC { get; set; }
        [Description("FECHA_EMISION_RRTFFS")]
        public String FECHA_EMISION_RRTFFS { get; set; }
        [Description("APELACION_RITFFS")]
        public String APELACION_RRTFFS { get; set; }
        [Description("SENTIDO_RESOLUCION_RRTFFS")]
        public String SENTIDO_RESOLUCION_RRTFFS { get; set; }
        [Description("CONFIRM_RESOLUCION_RRTFFS")]
        public String CONFIRM_RESOLUCION_RRTFFS { get; set; }
        [Description("LEVANTAMIENTO_RESOLUCION_RRTFFS")]
        public String LEVANTAMIENTO_RESOLUCION_RRTFFS { get; set; }
        [Description("CAMBIO_MULTA_RRTFFS")]
        public String CAMBIO_MULTA_RRTFFS { get; set; }
        [Description("MULTA_RRTFFS")]
        public Decimal MULTA_RRTFFS { get; set; }
        [Description("ESTADO_PAU_RRTFFS")]
        public String ESTADO_PAU_RRTFFS { get; set; }
        [Description("DOC_SIADO_RRTFFS")]
        public String DOC_SIADO_RRTFFS { get; set; }

        // datos para capturar la informacion en los reportes
        [Description("COD_ACCION")]
        public String COD_ACCION { get; set; }
        [Description("IP")]
        public String IP { get; set; }
        [Description("HOSTNAME")]
        public String HOSTNAME { get; set; }
        [Description("COD_FORMULARIO")]
        public String COD_FORMULARIO { get; set; }
        [Description("ACCION")]
        public String ACCION { get; set; }
        [Category("OUTPUT"), Description("OUTPUTPARAM01")]
        public Object OUTPUTPARAM01 { get; set; }
        #endregion

        [Description("OBJ_ACTUAL")]
        public String OBJ_ACTUAL { get; set; }
        [Description("OBJ_PRINCIP")]
        public String OBJ_PRINCIP { get; set; }
        [Description("ESTADO_ESTABLECIMIENTO")]
        public String ESTADO_ESTABLECIMIENTO { get; set; }
        [Description("VISITA")]
        public Object VISITA { get; set; }
        [Description("REPRODUCE")]
        public Object REPRODUCE { get; set; }


        /// <summary>
        /// 20/03/2018 C.R.
        /// </summary>
        /// 
        [Description("FUENTE")]
        public String FUENTE { get; set; }

        /// <summary>
        /// 23/08/2018 C.A.R
        /// DNI y RUC directorio
        /// </summary>
        [Description("T_DNI")]
        public String T_DNI { get; set; }
        [Description("T_RUC")]
        public String T_RUC { get; set; }
        [Description("T_NUMERO_DOCUMENTO")]
        public String T_NUMERO_DOCUMENTO { get; set; }
        [Description("R_DNI")]
        public String R_DNI { get; set; }
        [Description("R_RUC")]
        public String R_RUC { get; set; }
        [Description("R_NUMERO_DOCUMENTO")]
        public String R_NUMERO_DOCUMENTO { get; set; }
        [Description("PROVEIDO")]
        public String PROVEIDO { get; set; }
        [Description("ESTADO_TH")]
        public String ESTADO_TH { get; set; }
        [Description("COD_DOCUMENTO_DIG")]
        public String COD_DOCUMENTO_DIG { get; set; }
        [Description("DOC_RDINICIO")]
        public String DOC_RDINICIO { get; set; }
        [Description("DOC_RDTERMINO")]
        public String DOC_RDTERMINO { get; set; }
        [Description("DOC_RDRECONSIDERACION")]
        public String DOC_RDRECONSIDERACION { get; set; }
        [Description("DOC_RDRECTIFICACION")]
        public String DOC_RDRECTIFICACION { get; set; }
        [Description("DOC_RDACUMULACION")]
        public String DOC_RDACUMULACION { get; set; }
        [Description("DOC_RDAMPLIACION")]
        public String DOC_RDAMPLIACION { get; set; }
        [Description("DOC_RDCADUCIDAD")]
        public String DOC_RDCADUCIDAD { get; set; }
        [Description("DOC_RDOTROS")]
        public String DOC_RDOTROS { get; set; }
        [Description("DOC_RDVARI")]
        public String DOC_RDVARI { get; set; }
        [Description("DOC_RDARCH")]
        public String DOC_RDARCH { get; set; }
        [Description("ESPECIE")]
        public String ESPECIE { get; set; }
        [Description("VOLUMEN_APROBADO")]
        public Decimal VOLUMEN_APROBADO { get; set; }
        [Description("VOLUMEN_JUSTIFICADO")]
        public Decimal VOLUMEN_JUSTIFICADO { get; set; }
        #region constructor
        public Ent_Reporte_Historial_TH()
        {
            VISITA = -1;
            REPRODUCE = -1;
            INEX = -1;
            COINC = -1;
            AREA_O = -1;
            N_POA = -1;
            NUM_POA = -1;
            Arboles_aprob = -1;
            Volumen_apro = -1;
            DMC = -1;
            TOTAL_ARBOLES = -1;
            VOLUMEN_AUTORIZADO = -1;
            VOLUMEN_MOVILIZADO = -1;
            VOLUMEN_INEXISTENTE = -1;
            SALDO = -1;
            HIJO_NIVEL = -1;
            HIJO_NUM_POA = -1;
            POA_COMPLEMENT = -1;
            ANIO_SUPERV = -1;
            NUMERO_ARBOLES = -1;
            VOLUMEN_ARBOLES = -1;
            ESPECIES = -1;
            INXISTENCIA = -1;
            PORCENTAJE_INEX = -1;
            EN_PIE = -1;
            TOCON = -1;
            NO_EVALUADO = -1;
            SIN_DATOS = -1;
            TUMBADO = -1;
            PORCENT_INJUST_MOVIL = -1;
            PORCENT_INJUST_APROV = -1;
            ID_REGISTRO = -1;
            ID_D = -1;
            UIT_D = -1;
            FACTOR_UIT_D = -1;
            MULTA_IMPUESTA_D = -1;
            PAGO_MULTA_D = -1;
            AJUSTE_D = -1;
            DESCUENTO_D = -1;
            COMPENSACION_D = -1;

            SALDO_D = -1;
            INTERES_D = -1;
            TOTAL_D = -1;
            OTROS_INGRESOS_D = -1;
            MULTA_P = -1;
            INTERES_P = -1;
            CUOTA_P = -1;
            OTROSINGRESOS_P = -1;
            PERIODO_C = -1;
            SALDO_C = -1;
            MULTA_C = -1;
            INTERES_C = -1;
            CUOTA_C = -1;
            PERIODO_P_C = -1;
            SALDO_P_C = -1;
            MULTA_P_C = -1;
            INTERES_P_C = -1;
            CUOTA_P_C = -1;
            SIGCORRELATIVO_CM = -1;
            RESIDENTITY_CM = -1;
            RESIDENTITY = -1;
            ANIO_CC = -1;
            MONTOCOMPENSABLE_CC = -1;
            ANIO_CC = -1;
            MONTOCOMPENSABLE_CC = -1;
            MONTOCOMPENSABLE_P_CC = -1;
            COMPESTADO_CC = -1;
            V_MESES = -1;
            VOLUMEN_INJUSTIFICADO = -1;
            MULTA_RITFFS = -1;
            MULTA_RTTFFS = -1;
            MULTA_RRTFFS = -1;
            VOLUMEN_APROBADO = -1;
            VOLUMEN_JUSTIFICADO = -1;
        }
        #endregion
    }
    public class Ent_Temporal
    {
        public string COD_RESODIREC { get; set; }
        public string TIPO_RD { get; set; }
    }
}
