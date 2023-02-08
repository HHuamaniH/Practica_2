using System.ComponentModel;

namespace CapaEntidad.DOC
{
    public class Ent_PLAN
    {
        [Description("COD_PLAN")]
        public string COD_PLAN { get; set; }
        [Description("ANIO")]
        public int ANIO { get; set; }
        [Description("FECHA_CORTE")]
        public object FECHA_CORTE { get; set; }
        [Description("HORA_CORTE")]
        public string HORA_CORTE { get; set; }
        [Description("NUMERO_RESOLUCION")]
        public string NUMERO_RESOLUCION { get; set; }
        [Description("FECHA_EMISION")]
        public object FECHA_EMISION { get; set; }
        [Description("COD_FUNCIONARIO")]
        public string COD_FUNCIONARIO { get; set; }
        [Description("FUNCIONARIO")]
        public string FUNCIONARIO { get; set; }
        [Description("OBSERVACION")]
        public string OBSERVACION { get; set; }
        [Description("COD_ESTADO_DOC")]
        public string COD_ESTADO_DOC { get; set; }
        [Description("OBSERVACIONES_CONTROL")]
        public string OBSERVACIONES_CONTROL { get; set; }
        [Description("OBSERV_SUBSANAR")]
        public object OBSERV_SUBSANAR { get; set; }
        [Description("COD_UCUENTA")]
        public string COD_UCUENTA { get; set; }
        [Description("USUARIO_CONTROL")]
        public string USUARIO_CONTROL { get; set; }
        [Description("USUARIO_REGISTRO")]
        public string USUARIO_REGISTRO { get; set; }
        [Description("OUTPUTPARAM")]
        public string OUTPUTPARAM { get; set; }

        public Ent_PLAN()
        {
            ANIO = -1;
        }
    }

    public class Ent_PLAN_COLABORADOR
    {
        [Description("COD_PLAN")]
        public string COD_PLAN { get; set; }
        [Description("COD_COLABORADOR")]
        public string COD_COLABORADOR { get; set; }
        [Description("COLABORADOR")]
        public string COLABORADOR { get; set; }
        [Description("COD_UCUENTA")]
        public string COD_UCUENTA { get; set; }
        [Description("OUTPUTPARAM")]
        public string OUTPUTPARAM { get; set; }
    }

    public class Ent_PLAN_UNIVERSO
    {
        [Description("COD_PLAN")]
        public string COD_PLAN { get; set; }
        [Description("FECHA_CORTE")]
        public object FECHA_CORTE { get; set; }
        [Description("OUTPUTPARAM")]
        public string OUTPUTPARAM { get; set; }
    }

    public class Ent_PLAN_CRITERIO
    {
        [Description("COD_PCRITERIO")]
        public string COD_PCRITERIO { get; set; }
        [Description("COD_PLAN")]
        public string COD_PLAN { get; set; }
        [Description("COD_TCRITERIO")]
        public string COD_TCRITERIO { get; set; }
        [Description("TCRITERIO")]
        public string TCRITERIO { get; set; }
        [Description("CODIGO")]
        public string CODIGO { get; set; }
        [Description("PCRITERIO")]
        public string PCRITERIO { get; set; }
        [Description("COD_TAPLICACION")]
        public string COD_TAPLICACION { get; set; }
        [Description("TAPLICACION")]
        public string TAPLICACION { get; set; }
        [Description("COD_PCOLUMNA")]
        public string COD_PCOLUMNA { get; set; }
        [Description("PCOLUMNA")]
        public string PCOLUMNA { get; set; }
        [Description("DESCRIPCION")]
        public string DESCRIPCION { get; set; }
        [Description("ACTIVO")]
        public object ACTIVO { get; set; }
        [Description("COD_UCUENTA")]
        public string COD_UCUENTA { get; set; }
        [Description("OUTPUTPARAM")]
        public string OUTPUTPARAM { get; set; }
        [Description("COD_PLAN_BASE")]
        public string COD_PLAN_BASE { get; set; }
    }

    public class Ent_PLAN_CRITERIO_VALOR
    {
        [Description("COD_PCRITERIO")]
        public string COD_PCRITERIO { get; set; }
        [Description("COD_SECUENCIAL")]
        public int COD_SECUENCIAL { get; set; }
        [Description("OPCION_TEXTO_1")]
        public string OPCION_TEXTO_1 { get; set; }
        [Description("OPCION_NUMERO_1")]
        public decimal OPCION_NUMERO_1 { get; set; }
        [Description("OPCION_NUMERO_2")]
        public decimal OPCION_NUMERO_2 { get; set; }
        [Description("OPCION_FECHA_1")]
        public object OPCION_FECHA_1 { get; set; }
        [Description("OPCION_FECHA_2")]
        public object OPCION_FECHA_2 { get; set; }
        [Description("VALOR")]
        public decimal VALOR { get; set; }
        [Description("RIESGO")]
        public decimal RIESGO { get; set; }
        [Description("COD_UCUENTA")]
        public string COD_UCUENTA { get; set; }
        [Description("OUTPUTPARAM")]
        public string OUTPUTPARAM { get; set; }

        public Ent_PLAN_CRITERIO_VALOR()
        {
            COD_SECUENCIAL = -1;
            OPCION_NUMERO_1 = -1;
            OPCION_NUMERO_2 = -1;
            VALOR = -1;
            RIESGO = -1;
        }
    }

    public class Ent_PLAN_COLUMNA
    {
        [Description("COD_PCOLUMNA")]
        public string COD_PCOLUMNA { get; set; }
        [Description("TIPO_DATO")]
        public string TIPO_DATO { get; set; }
        [Description("COD_PCRITERIO")]
        public string COD_PCRITERIO { get; set; }
        [Description("OPCION")]
        public string OPCION { get; set; }
    }

    public class Ent_PLAN_CASUISTICA
    {
        [Description("COD_PCASUISTICA")]
        public string COD_PCASUISTICA { get; set; }
        [Description("COD_PLAN")]
        public string COD_PLAN { get; set; }
        [Description("PCASUISTICA")]
        public string PCASUISTICA { get; set; }
        [Description("COD_TCRITERIO")]
        public string COD_TCRITERIO { get; set; }
        [Description("TCRITERIO")]
        public string TCRITERIO { get; set; }
        [Description("DESCRIPCION")]
        public string DESCRIPCION { get; set; }
        [Description("DESCRIPCION_FILTRO")]
        public string DESCRIPCION_FILTRO { get; set; }
        [Description("N_CRITERIO")]
        public int N_CRITERIO { get; set; }
        [Description("N_REGISTRO")]
        public int N_REGISTRO { get; set; }
        [Description("COD_UCUENTA")]
        public string COD_UCUENTA { get; set; }
        [Description("OUTPUTPARAM")]
        public string OUTPUTPARAM { get; set; }

        public Ent_PLAN_CASUISTICA()
        {
            N_CRITERIO = -1;
            N_REGISTRO = -1;
        }
    }

    public class Ent_PLAN_CASUISTICA_CRITERIO
    {
        [Description("COD_PCASUISTICA")]
        public string COD_PCASUISTICA { get; set; }
        [Description("COD_PCRITERIO")]
        public string COD_PCRITERIO { get; set; }
        [Description("PCRITERIO")]
        public string PCRITERIO { get; set; }
        [Description("TAPLICACION")]
        public string TAPLICACION { get; set; }
        [Description("PCOLUMNA")]
        public string PCOLUMNA { get; set; }
        [Description("COD_TCRITERIO")]
        public string COD_TCRITERIO { get; set; }
        [Description("ASIGNAR")]
        public object ASIGNAR { get; set; }
        [Description("COD_UCUENTA")]
        public string COD_UCUENTA { get; set; }
        [Description("OUTPUTPARAM")]
        public string OUTPUTPARAM { get; set; }
    }

    public class Ent_PLAN_CASUISTICA_UNIVERSO
    {
        [Description("COD_PCASUISTICA")]
        public string COD_PCASUISTICA { get; set; }
        [Description("COD_PLAN")]
        public string COD_PLAN { get; set; }
        [Description("COD_SECUENCIAL")]
        public int COD_SECUENCIAL { get; set; }
        [Description("PRIORIZAR")]
        public object PRIORIZAR { get; set; }
        [Description("COD_UCUENTA")]
        public string COD_UCUENTA { get; set; }
        [Description("UCUENTA")]
        public string UCUENTA { get; set; }
        [Description("OUTPUTPARAM")]
        public string OUTPUTPARAM { get; set; }
        [Description("COD_OD")]
        public string COD_OD { get; set; }
        [Description("COD_ESTADO_PRIORIZAR")]
        public string COD_ESTADO_PRIORIZAR { get; set; }
        [Description("OBSERVAR")]
        public object OBSERVAR { get; set; }
        [Description("OBSERVACION")]
        public string OBSERVACION { get; set; }
        [Description("REVISAR")]
        public object REVISAR { get; set; }
        [Description("REVISION")]
        public string REVISION { get; set; }

        public Ent_PLAN_CASUISTICA_UNIVERSO()
        {
            COD_SECUENCIAL = -1;
        }
    }

    public class Ent_PLAN_REPORTE
    {
        [Description("TIPO_REPORTE")]
        public string TIPO_REPORTE { get; set; }
        [Description("COD_PLAN")]
        public string COD_PLAN { get; set; }
    }
}