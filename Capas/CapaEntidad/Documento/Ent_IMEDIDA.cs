using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CapaEntidad.DOC
{
    public class Ent_IMEDIDA
    {
        //Control de Calidad
        [Description("COD_ESTADO_DOC")]
        public String COD_ESTADO_DOC { get; set; }
        [Description("OBSERVACIONES_CONTROL")]
        public String OBSERVACIONES_CONTROL { get; set; }
        [Description("OBSERV_SUBSANAR")]
        public Object OBSERV_SUBSANAR { get; set; }

        //Campos Informe
        [Description("COD_INFORME")]
        public String COD_INFORME { get; set; }
        [Description("COD_ITIPO")]
        public String COD_ITIPO { get; set; }
        [Description("ITIPO")]
        public String ITIPO { get; set; }
        [Description("IMOTIVO")]
        public String IMOTIVO { get; set; }
        [Description("COD_DIRECTOR")]
        public String COD_DIRECTOR { get; set; }
        [Description("DIRECTOR")]
        public String DIRECTOR { get; set; }
        [Description("NUMERO")]
        public String NUMERO { get; set; }
        [Description("CONCLUSION")]
        public String CONCLUSION { get; set; }

        //Campos Informe Medida Correctiva
        [Description("CUMPLE_PLAZO")]
        public object CUMPLE_PLAZO { get; set; }
        [Category("FECHA"), Description("FECHA_RECEPCION")]
        public Object FECHA_RECEPCION { get; set; }
        [Description("INFORME_COMPLETO")]
        public object INFORME_COMPLETO { get; set; }
        [Description("FIRMA_REGENTE")]
        public object FIRMA_REGENTE { get; set; }
        [Description("REMITIR_DFFFS")]
        public object REMITIR_DFFFS { get; set; }
        [Description("RECOMENDACION")]
        public String RECOMENDACION { get; set; }
        [Category("FECHA"), Description("FECHA_VERIFICA_INICIO")]
        public Object FECHA_VERIFICA_INICIO { get; set; }
        [Category("FECHA"), Description("FECHA_VERIFICA_FIN")]
        public Object FECHA_VERIFICA_FIN { get; set; }
        [Category("FECHA"), Description("FECHA_IMPLEMENTACION")]
        public Object FECHA_IMPLEMENTACION { get; set; }
        [Description("REPOSICION_DENTRO")]
        public object REPOSICION_DENTRO { get; set; }
        [Description("REPOSICION_FUERA")]
        public object REPOSICION_FUERA { get; set; }
        [Description("CUMPLE_CANTIDAD")]
        public object CUMPLE_CANTIDAD { get; set; }
        [Description("CUMPLE_MEDIDA")]
        public object CUMPLE_MEDIDA { get; set; }

        [Description("COD_UCUENTA")]
        public String COD_UCUENTA { get; set; }
        [Description("OUTPUTPARAM01")]
        public String OUTPUTPARAM01 { get; set; }
        [Description("RegEstado")]
        public Int32 RegEstado { get; set; }
        [Description("BusFormulario")]
        public String BusFormulario { get; set; }
        [Description("BusCriterio")]
        public String BusCriterio { get; set; }
        [Description("BusValor")]
        public String BusValor { get; set; }
        [Description("currentpage")]
        public Int32 currentpage { get; set; }
        [Description("v_pagesize")]
        public Int32 v_pagesize { get; set; }
        [Description("v_row_index")]
        public Int32 v_row_index { get; set; }

        [Description("CODIGO")]
        public String CODIGO { get; set; }
        [Description("DESCRIPCION")]
        public String DESCRIPCION { get; set; }

        [Description("USUARIO_REGISTRO")]
        public String USUARIO_REGISTRO { get; set; }
        [Description("USUARIO_CONTROL")]
        public String USUARIO_CONTROL { get; set; }

        //Detalle informe
        //MEDIDAS
        [Category("LIST"), Description("ListMedida")]
        public List<Ent_IMEDIDA_EXP_MEDIDA> ListMedida { get; set; }
        [Category("LIST"), Description("ListMedidaAsociada")]
        public List<Ent_IMEDIDA_EXP_MEDIDA> ListMedidaAsociada { get; set; }
        [Category("LIST"), Description("ListEliTABLA")]
        public List<Ent_IMEDIDA_EliTABLA> ListEliTABLA { get; set; }
        [Category("LIST"), Description("ListProfResponsable")]
        public List<Ent_IMEDIDA_RESPONSABLE> ListProfResponsable { get; set; }
        [Category("LIST"), Description("ListEspecieReforestada")]
        public List<Ent_IMEDIDA_ESPECIE> ListEspecieReforestada { get; set; }
        [Category("LIST"), Description("ListVerticeReforestada")]
        public List<Ent_IMEDIDA_VERTICE> ListVerticeReforestada { get; set; }
        [Category("LIST"), Description("ListExpediente")]
        public List<Ent_IMEDIDA_EXPEDIENTE> ListExpediente { get; set; }
        [Category("LIST"), Description("ListBusqueda")]
        public List<Ent_IMEDIDA_EXPEDIENTE> ListBusqueda { get; set; }

        //Otros detalles
        [Category("LIST"), Description("ListMComboTInforme")]
        public List<Ent_IMEDIDA> ListMComboTInforme { get; set; }
        [Category("LIST"), Description("ListMComboEspecies")]
        public List<Ent_IMEDIDA> ListMComboEspecies { get; set; }
        [Category("LIST"), Description("ListIndicador")]
        public List<Ent_IMEDIDA> ListIndicador { get; set; }

        public Ent_IMEDIDA()
        {
            RegEstado = -1;
            currentpage = -1;
            v_pagesize = -1;
            v_row_index = -1;
        }
    }

    public class Ent_IMEDIDA_EliTABLA
    {
        [Description("EliTABLA")]
        public string EliTABLA { get; set; }
        [Description("COD_INFORME")]
        public string COD_INFORME { get; set; }
        [Description("COD_PERSONA")]
        public string COD_PERSONA { get; set; }
        [Description("COD_RESODIREC")]
        public string COD_RESODIREC { get; set; }
        [Description("COD_SECUENCIAL")]
        public int COD_SECUENCIAL { get; set; }

        public Ent_IMEDIDA_EliTABLA()
        {
            COD_SECUENCIAL = -1;
        }
    }

    public class Ent_IMEDIDA_RESPONSABLE
    {
        [Description("COD_INFORME")]
        public string COD_INFORME { get; set; }
        [Description("COD_RESPONSABLE")]
        public string COD_RESPONSABLE { get; set; }
        [Description("RESPONSABLE")]
        public string RESPONSABLE { get; set; }
        [Description("RegEstado")]
        public int RegEstado { get; set; }
        [Description("COD_UCUENTA")]
        public string COD_UCUENTA { get; set; }

        public Ent_IMEDIDA_RESPONSABLE()
        {
            RegEstado = -1;
        }
    }

    public class Ent_IMEDIDA_EXPEDIENTE
    {
        [Description("COD_INFORME")]
        public string COD_INFORME { get; set; }
        [Description("COD_RESODIREC")]
        public string COD_RESODIREC { get; set; }
        [Description("NUM_RESOLUCION")]
        public string NUM_RESOLUCION { get; set; }
        [Description("TIPO_RESOLUCION")]
        public string TIPO_RESOLUCION { get; set; }
        [Description("NUM_EXPEDIENTE")]
        public string NUM_EXPEDIENTE { get; set; }
        [Description("NUM_THABILITANTE")]
        public string NUM_THABILITANTE { get; set; }
        [Description("TITULAR")]
        public string TITULAR { get; set; }
        [Description("MODALIDAD")]
        public string MODALIDAD { get; set; }
        [Description("RegEstado")]
        public int RegEstado { get; set; }
        [Description("COD_UCUENTA")]
        public String COD_UCUENTA { get; set; }

        public Ent_IMEDIDA_EXPEDIENTE()
        {
            RegEstado = -1;
        }
    }

    public class Ent_IMEDIDA_EXP_MEDIDA
    {
        [Description("COD_INFORME")]
        public string COD_INFORME { get; set; }
        [Description("COD_RESODIREC")]
        public string COD_RESODIREC { get; set; }
        [Description("COD_RESODIREC_MEDIDA")]
        public string COD_RESODIREC_MEDIDA { get; set; }
        [Description("NUM_RESOLUCION_MEDIDA")]
        public string NUM_RESOLUCION_MEDIDA { get; set; }
        [Description("COD_MEDIDA")]
        public int COD_MEDIDA { get; set; }
        [Description("MEDIDA")]
        public string MEDIDA { get; set; }
        [Description("ASOCIADO")]
        public object ASOCIADO { get; set; }
        [Description("TXT_ASOCIADO")]
        public string TXT_ASOCIADO { get; set; }
        [Description("PLAZO_IMPL_DIA")]
        public int PLAZO_IMPL_DIA { get; set; }
        [Description("PLAZO_IMPL_MES")]
        public int PLAZO_IMPL_MES { get; set; }
        [Description("PLAZO_IMPL_ANIO")]
        public int PLAZO_IMPL_ANIO { get; set; }
        [Description("PLAZO_POST_DIA")]
        public int PLAZO_POST_DIA { get; set; }
        [Description("PLAZO_POST_MES")]
        public int PLAZO_POST_MES { get; set; }
        [Description("PLAZO_POST_ANIO")]
        public int PLAZO_POST_ANIO { get; set; }
        [Description("PLAZO_INF_DIA")]
        public int PLAZO_INF_DIA { get; set; }
        [Description("PLAZO_INF_MES")]
        public int PLAZO_INF_MES { get; set; }
        [Description("PLAZO_INF_ANIO")]
        public int PLAZO_INF_ANIO { get; set; }
        [Description("COD_UCUENTA")]
        public string COD_UCUENTA { get; set; }
        [Description("MAE_TIP_MEDIDA")]
        public string MAE_TIP_MEDIDA { get; set; }

        public Ent_IMEDIDA_EXP_MEDIDA()
        {
            COD_MEDIDA = -1;
            PLAZO_IMPL_ANIO = -1;
            PLAZO_IMPL_DIA = -1;
            PLAZO_IMPL_MES = -1;
            PLAZO_INF_ANIO = -1;
            PLAZO_INF_DIA = -1;
            PLAZO_INF_MES = -1;
            PLAZO_POST_ANIO = -1;
            PLAZO_POST_DIA = -1;
            PLAZO_POST_MES = -1;
        }
    }

    public class Ent_IMEDIDA_ESPECIE
    {
        [Description("COD_INFORME")]
        public String COD_INFORME { get; set; }
        [Description("COD_SECUENCIAL")]
        public Int32 COD_SECUENCIAL { get; set; }
        [Description("COD_ESPECIES")]
        public String COD_ESPECIES { get; set; }
        [Description("DESCRIPCION_ESPECIE")]
        public String DESCRIPCION_ESPECIE { get; set; }
        [Description("DIAMETRO")]
        public Decimal DIAMETRO { get; set; }
        [Description("ALTURA")]
        public Decimal ALTURA { get; set; }
        [Description("ZONA")]
        public String ZONA { get; set; }
        [Description("COORDENADA_ESTE")]
        public Int32 COORDENADA_ESTE { get; set; }
        [Description("COORDENADA_NORTE")]
        public Int32 COORDENADA_NORTE { get; set; }
        [Description("ESTADO_ESPECIE")]
        public String ESTADO_ESPECIE { get; set; }
        [Description("OBSERVACION")]
        public String OBSERVACION { get; set; }
        [Description("RegEstado")]
        public int RegEstado { get; set; }
        [Description("COD_UCUENTA")]
        public String COD_UCUENTA { get; set; }

        public Ent_IMEDIDA_ESPECIE()
        {
            COD_SECUENCIAL = -1;
            DIAMETRO = -1;
            ALTURA = -1;
            COORDENADA_ESTE = -1;
            COORDENADA_NORTE = -1;
            RegEstado = -1;
        }
    }

    public class Ent_IMEDIDA_VERTICE
    {
        [Description("COD_INFORME")]
        public String COD_INFORME { get; set; }
        [Description("COD_SECUENCIAL")]
        public Int32 COD_SECUENCIAL { get; set; }
        [Description("VERTICE")]
        public String VERTICE { get; set; }
        [Description("ZONA")]
        public String ZONA { get; set; }
        [Description("COORDENADA_ESTE")]
        public Int32 COORDENADA_ESTE { get; set; }
        [Description("COORDENADA_NORTE")]
        public Int32 COORDENADA_NORTE { get; set; }
        [Description("OBSERVACION")]
        public String OBSERVACION { get; set; }
        [Description("RegEstado")]
        public int RegEstado { get; set; }
        [Description("COD_UCUENTA")]
        public String COD_UCUENTA { get; set; }

        public Ent_IMEDIDA_VERTICE()
        {
            COD_SECUENCIAL = -1;
            COORDENADA_ESTE = -1;
            COORDENADA_NORTE = -1;
            RegEstado = -1;
        }
    }
}
