using System.ComponentModel;

namespace CapaEntidad.DOC
{
    public class Ent_REPORTE_GENERAL
    {
        [Description("TIPO_REPORTE")]
        public string TIPO_REPORTE { get; set; }
        [Description("ANIO")]
        public string ANIO { get; set; }
        [Description("MES")]
        public string MES { get; set; }
        [Description("FECHA_CORTE")]
        public string FECHA_CORTE { get; set; }
        [Description("COD_ITIPO")]
        public string COD_ITIPO { get; set; }
        [Description("COD_OD")]
        public string COD_OD { get; set; }
        [Description("COD_MTIPO")]
        public string COD_MTIPO { get; set; }
        [Description("COD_DPTO")]
        public string COD_DPTO { get; set; }
        [Description("COD_DLINEA")]
        public string COD_DLINEA { get; set; }
        [Description("TIPO_DOCUMENTO_SIGO")]
        public string TIPO_DOCUMENTO_SIGO { get; set; }
        [Description("ESTADO_DOCUMENTO")]
        public string ESTADO_DOCUMENTO { get; set; }
        [Description("TIPO_RESOLUCION_FISCALIZACION")]
        public string TIPO_RESOLUCION_FISCALIZACION { get; set; }
        //Variables creadas 07/05/21 Tablero Datos
        [Description("FECHA_INICIO")]
        public string FECHA_INICIO { get; set; }
        [Description("FECHA_TERNINO")]
        public string FECHA_TERNINO { get; set; }
        [Description("FECHA_INICIO_DOC")]
        public string FECHA_INICIO_DOC { get; set; }
        [Description("FECHA_TERNINO_DOC")]
        public string FECHA_TERNINO_DOC { get; set; }
        [Description("FILTRO")]
        public string FILTRO { get; set; }
        public Ent_REPORTE_GENERAL()
        {

        }
    }

    public class Ent_REPORTE_TITULAR_RESUMEN
    {
        [Description("UBICACION")]
        public string UBICACION { get; set; }
        [Description("DEPARTAMENTO")]
        public string DEPARTAMENTO { get; set; }
        [Description("DLINEA")]
        public string DLINEA { get; set; }
        [Description("MTIPO")]
        public string MTIPO { get; set; }
        [Description("ANIO_SUPERVISION")]
        public string ANIO_SUPERVISION { get; set; }
        [Description("ANIO_RDTERMINO")]
        public string ANIO_RDTERMINO { get; set; }
        [Description("MES_RDTERMINO")]
        public string MES_RDTERMINO { get; set; }
        [Description("ANIO_PROVEIDO")]
        public string ANIO_PROVEIDO { get; set; }
        [Description("ANIO_FIRMEZA")]
        public string ANIO_FIRMEZA { get; set; }
        [Description("TIPO_FILTRO")]
        public string TIPO_FILTRO { get; set; }
        [Description("VALOR_FILTRO")]
        public string VALOR_FILTRO { get; set; }
        [Description("MULTA")]
        public object MULTA { get; set; }
    }

    public class Ent_TH_Comportamiento
    {
        [Description("NU_OPCION")]
        public int NU_OPCION { get; set; }        
        [Description("NU_ENTIDAD")]
        public int NU_ENTIDAD { get; set; }
        [Description("NU_OPCION_BUSQUEDA")]
        public int NU_OPCION_BUSQUEDA { get; set; }
        [Description("NU_CODIGO_BUSQUEDA")]
        public int NU_CODIGO_BUSQUEDA { get; set; }
        [Description("NV_CODIGO_BUSQUEDA")]
        public string NV_CODIGO_BUSQUEDA { get; set; }
        [Description("TX_DATO_BUSQUEDA")]
        public string TX_DATO_BUSQUEDA { get; set; }
        [Description("DA_FECHA_REGISTRO")]
        public string DA_FECHA_REGISTRO { get; set; }
        [Description("NV_COD_TITULO_HABILITANTE")]
        public string NV_COD_TITULO_HABILITANTE { get; set; }
        [Description("NV_TITULO_HABILITANTE")]
        public string NV_TITULO_HABILITANTE { get; set; }
        [Description("NV_TITULAR")]
        public string NV_TITULAR { get; set; }
        [Description("NV_REPLEGAL")]
        public string NV_REPLEGAL { get; set; }
        [Description("NV_DOCUMENTO")]
        public string NV_DOCUMENTO { get; set; }
        [Description("NV_MODALIDAD_TIPO")]
        public string NV_MODALIDAD_TIPO { get; set; }
        [Description("NV_REGION")]
        public string NV_REGION { get; set; }
        [Description("NV_PROVINCIA")]
        public string NV_PROVINCIA { get; set; }
        [Description("NV_DISTRITO")]
        public string NV_DISTRITO { get; set; }
        [Description("NV_AREA")]
        public string NV_AREA { get; set; }
        [Description("DA_FECHA_VIGENCIA")]
        public string DA_FECHA_VIGENCIA { get; set; }
        [Description("NU_CALIFICACION")]
        public string NU_CALIFICACION { get; set; }  
        [Description("TXT_ANIO")]
        public string TXT_ANIO { get; set; } 
        [Description("TXT_PUNTAJE")]
        public string TXT_PUNTAJE { get; set; }
        [Description("NU_CADUCO")]
        public string NU_CADUCO { get; set; }
        public Ent_TH_Comportamiento()
        {
            NU_OPCION = -1;
            NU_ENTIDAD = -1;
            NU_OPCION_BUSQUEDA = -1;
            NU_CODIGO_BUSQUEDA = -1;            
        }

    }

    public class Ent_TH_Calificacion
    {
        [Description("NU_ANIO")]
        public int NU_ANIO { get; set; }
        [Description("NU_PUNTAJE")]
        public int NU_PUNTAJE { get; set; }        
        public Ent_TH_Calificacion()
        {
            NU_ANIO = -1;
            NU_PUNTAJE = -1;
        }
    }

    public class Ent_THabilitanteC
    {
        [Description("COD_TITULAR_ADENDA")]
        public string COD_TITULAR_ADENDA { get; set; }
        [Description("NV_ENTIDAD")]
        public string NV_ENTIDAD { get; set; }
        [Description("NV_NUMERO")]
        public string NV_NUMERO { get; set; }
        [Description("ADENDA_FECHA_INICIO")]
        public string ADENDA_FECHA_INICIO { get; set; }
        [Description("ADENDA_FECHA_TERMINO")]
        public string ADENDA_FECHA_TERMINO { get; set; }
        public Ent_THabilitanteC()
        {
            
        }
    }

    public class Ent_TH_CalificacionAnual
    {
        [Description("NV_ANIO")]
        public string NV_ANIO { get; set; }
        [Description("NCRITERIO1")]
        public string NCRITERIO1 { get; set; }
        [Description("NCRITERIO2")]
        public string NCRITERIO2 { get; set; }
        [Description("NCRITERIO3")]
        public string NCRITERIO3 { get; set; }
        [Description("NCRITERIO4")]
        public string NCRITERIO4 { get; set; }
        [Description("NCRITERIO5")]
        public string NCRITERIO5 { get; set; }
        [Description("NCRITERIO6")]
        public string NCRITERIO6 { get; set; }
        [Description("NCRITERIO7")]
        public string NCRITERIO7 { get; set; }
        [Description("NCRITERIO8")]
        public string NCRITERIO8 { get; set; }
        [Description("NCRITERIO9")]
        public string NCRITERIO9 { get; set; }
        [Description("NCRITERIO10")]
        public string NCRITERIO10 { get; set; }
        public Ent_TH_CalificacionAnual()
        {

        }
    }
}
