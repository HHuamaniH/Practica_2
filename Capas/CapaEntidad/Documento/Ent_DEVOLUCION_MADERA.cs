using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CapaEntidad.DOC
{
    public class Ent_DEVOLUCION_MADERA
    {
        #region "Entidades y Propiedades"
        //Control de Calidad
        [Description("COD_UCUENTA")]
        public String COD_UCUENTA { get; set; }
        [Description("COD_THABILITANTE")]
        public String COD_THABILITANTE { get; set; }
        [Description("NUM_THABILITANTE")]
        public String NUM_THABILITANTE { get; set; }
        [Description("NUM_POA")]
        public Int32 NUM_POA { get; set; }
        [Description("COD_DEVOLUCION")]
        public String COD_DEVOLUCION { get; set; }
        [Description("COD_PERSONA_FIRMA")]
        public String COD_PERSONA_FIRMA { get; set; }
        [Description("PERSONA_FIRMA")]
        public String PERSONA_FIRMA { get; set; }
        [Description("NUM_RESOLUCION")]
        public String NUM_RESOLUCION { get; set; }
        [Category("FECHA"), Description("FECHA_RESOLUCION")]
        public Object FECHA_RESOLUCION { get; set; }
        [Description("ZAFRA_EJECUTAR")]
        public String ZAFRA_EJECUTAR { get; set; }
        [Category("FECHA"), Description("INICIO_PERIODO_EJECUCION")]
        public Object INICIO_PERIODO_EJECUCION { get; set; }
        [Category("FECHA"), Description("FIN_PERIODO_EJECUCION")]
        public Object FIN_PERIODO_EJECUCION { get; set; }

        [Description("INDICADOR")]
        public String INDICADOR { get; set; }
        [Description("COD_MTIPO")]
        public String COD_MTIPO { get; set; }
        [Description("MODALIDAD")]
        public String MODALIDAD { get; set; }
        [Description("COD_UBIDEPARTAMENTO")]
        public String COD_UBIDEPARTAMENTO { get; set; }
        [Description("ESTADO_ORIGEN")]
        public String ESTADO_ORIGEN { get; set; }

        [Description("PERSONA_TITULAR")]
        public String PERSONA_TITULAR { get; set; }

        [Description("CARGO")]
        public String CARGO { get; set; }
        [Category("FECHA"), Description("FECHA_EMISION_BEXTRACCION")]
        public Object FECHA_EMISION_BEXTRACCION { get; set; }
        [Description("TIENE_POA")]
        public Object TIENE_POA { get; set; }
        //
        [Description("COD_SECUENCIAL")]
        public Int32 COD_SECUENCIAL { get; set; }
        [Description("COD_ESPECIES")]
        public String COD_ESPECIES { get; set; }
        [Description("ESPECIES")]
        public String ESPECIES { get; set; }
        [Description("VOLUMEN")]
        public Decimal VOLUMEN { get; set; }
        [Description("NUM_TROZAS")]
        public Int32 NUM_TROZAS { get; set; }
        [Description("OBSERVACION")]
        public Object OBSERVACION { get; set; }
        [Category("FECHA"), Description("FECHA_CREACION")]
        public Object FECHA_CREACION { get; set; }
        //
        [Description("NUM_INFORME")]
        public String NUM_INFORME { get; set; }
        [Category("FECHA"), Description("FECHA_INFORME")]
        public Object FECHA_INFORME { get; set; }
        [Description("COD_PERSONA")]
        public String COD_PERSONA { get; set; }
        [Description("PERSONA")]
        public String PERSONA { get; set; }
        [Description("N_DOCUMENTO")]
        public String N_DOCUMENTO { get; set; }
        //
        [Description("VERTICE")]
        public String VERTICE { get; set; }
        [Description("COORDENADA_ESTE")]
        public Int32 COORDENADA_ESTE { get; set; }
        [Description("COORDENADA_NORTE")]
        public Int32 COORDENADA_NORTE { get; set; }

        //
        [Description("VOLUMEN_AUTORIZADO")]
        public Decimal VOLUMEN_AUTORIZADO { get; set; }
        [Description("VOLUMEN_MOVILIZADO")]
        public Decimal VOLUMEN_MOVILIZADO { get; set; }
        [Description("SALDO")]
        public Decimal SALDO { get; set; }
        //     
        [Description("DAP")]
        public Decimal DAP { get; set; }
        [Description("CODIGO")]
        public String CODIGO { get; set; }
        [Description("ALTURA")]
        public Decimal ALTURA { get; set; }
        [Description("DESCRIPCION")]
        public Object DESCRIPCION { get; set; }
        [Description("NUMERO_FILA")]
        public Int32 NUMERO_FILA { get; set; }
        [Description("DIAMETRO")]
        public Decimal DIAMETRO { get; set; }
        [Description("LARGO")]
        public Decimal LARGO { get; set; }
        [Description("CANTIDAD")]
        public Int32 CANTIDAD { get; set; }
        [Description("NUM_PCA")]
        public String NUM_PCA { get; set; }
        //
        [Description("COD_ECONDICION")]
        public String COD_ECONDICION { get; set; }
        [Description("COD_EESTADO")]
        public String COD_EESTADO { get; set; }
        [Description("CONDICION")]
        public String CONDICION { get; set; }
        [Description("ESTADO")]
        public String ESTADO { get; set; }
        [Description("ESTADO_MUESTRA")]
        public Object ESTADO_MUESTRA { get; set; }
        [Description("COD_CNOTIFICACION")]
        public String COD_CNOTIFICACION { get; set; }
        [Description("COD_FISNOTI")]
        public String COD_FISNOTI { get; set; }
        [Description("DESC_ESPECIES")]
        public String DESC_ESPECIES { get; set; }
        //
        [Description("NUM_PCOMPLEMENTARIO")]
        public Int32 NUM_PCOMPLEMENTARIO { get; set; }
        [Description("COD_THABILITANTE_POA")]
        public String COD_THABILITANTE_POA { get; set; }
        [Description("COD_THABILITANTE_DEV")]
        public String COD_THABILITANTE_DEV { get; set; }
        //Auxiliares
        [Description("LISTA_INDEX")]
        public String LISTA_INDEX { get; set; }
        [Description("MADERABLE")]
        public Object MADERABLE { get; set; }
        [Description("NO_MADERABLE")]
        public Object NO_MADERABLE { get; set; }
        [Description("COD_ESTADO_DOC")]
        public String COD_ESTADO_DOC { get; set; }
        [Description("OBSERVACIONES_CONTROL")]
        public String OBSERVACIONES_CONTROL { get; set; }
        [Description("OBSERV_SUBSANAR")]
        public Object OBSERV_SUBSANAR { get; set; }

        //
        [Description("COD_ESPECIES_CAMPO")]
        public String COD_ESPECIES_CAMPO { get; set; }
        [Description("DAP_2")]
        public Decimal DAP_2 { get; set; }
        [Description("CODIGO_2")]
        public String CODIGO_2 { get; set; }
        [Description("ALTURA_2")]
        public Decimal ALTURA_2 { get; set; }
        [Description("VOLUMEN_2")]
        public Decimal VOLUMEN_2 { get; set; }
        [Description("DIAMETRO_2")]
        public Decimal DIAMETRO_2 { get; set; }
        [Description("LARGO_2")]
        public Decimal LARGO_2 { get; set; }
        [Description("CANTIDAD_2")]
        public Int32 CANTIDAD_2 { get; set; }
        [Description("NUM_PCA_2")]
        public String NUM_PCA_2 { get; set; }
        [Description("NUM_TROZAS_2")]
        public Int32 NUM_TROZAS_2 { get; set; }
        [Description("COORDENADA_ESTE_2")]
        public Int32 COORDENADA_ESTE_2 { get; set; }
        [Description("COORDENADA_NORTE_2")]
        public Int32 COORDENADA_NORTE_2 { get; set; }
        [Description("COD_ECONDICION_2")]
        public String COD_ECONDICION_2 { get; set; }
        [Description("COD_EESTADO_2")]
        public String COD_EESTADO_2 { get; set; }
        [Description("COD_ACATEGORIA_2")]
        public String COD_ACATEGORIA_2 { get; set; }
        [Description("ESTADO_SUPERVISION")]
        public Object ESTADO_SUPERVISION { get; set; }
        [Description("ESTADO_FILA")]
        public Int32 ESTADO_FILA { get; set; }
        [Category("FK"), Description("COD_ACATEGORIA")]
        public String COD_ACATEGORIA { get; set; }
        [Description("COD_INFORME")]
        public String COD_INFORME { get; set; }
        //
        [Description("TIPO")]
        public String TIPO { get; set; }
        //
        [Category("OUTPUT"), Description("OUTPUTPARAM01")]
        public Object OUTPUTPARAM01 { get; set; }
        [Category("OUTPUT"), Description("OUTPUTPARAM02")]
        public Object OUTPUTPARAM02 { get; set; }

        [Description("BusFormulario")]
        public String BusFormulario { get; set; }
        [Description("BusCriterio")]
        public String BusCriterio { get; set; }
        [Description("BusValor")]
        public String BusValor { get; set; }
        [Description("RegEstado")]
        public Int32 RegEstado { get; set; }
        [Description("COD_OD_REGISTRO")]
        public String COD_OD_REGISTRO { get; set; }

        [Description("USUARIO_REGISTRO")]
        public String USUARIO_REGISTRO { get; set; }
        [Description("USUARIO_CONTROL")]
        public String USUARIO_CONTROL { get; set; }

        //Lista Objetos
        [Category("LIST"), Description("ListPINFTEC")]
        public List<Ent_DEVOLUCION_MADERA> ListPINFTEC { get; set; }
        [Category("LIST"), Description("ListESPDEVUELTAS")]
        public List<Ent_DEVOLUCION_MADERA> ListESPDEVUELTAS { get; set; }
        [Category("LIST"), Description("ListVERTICE")]
        public List<Ent_DEVOLUCION_MADERA> ListVERTICE { get; set; }
        [Category("LIST"), Description("ListESPHALLADAS")]
        public List<Ent_DEVOLUCION_MADERA> ListESPHALLADAS { get; set; }
        [Category("LIST"), Description("ListBEXTRACCION")]
        public List<Ent_DEVOLUCION_MADERA> ListBEXTRACCION { get; set; }
        [Category("LIST"), Description("ListDEVOLCENSOTROZA")]
        public List<Ent_DEVOLUCION_MADERA> ListDEVOLCENSOTROZA { get; set; }
        [Category("LIST"), Description("ListDEVOLCENSOTOCON")]
        public List<Ent_DEVOLUCION_MADERA> ListDEVOLCENSOTOCON { get; set; }
        [Category("LIST"), Description("ListDEVOLCENSOARBOL")]
        public List<Ent_DEVOLUCION_MADERA> ListDEVOLCENSOARBOL { get; set; }
        [Category("LIST"), Description("ListMComboEspecies")]
        public List<Ent_DEVOLUCION_MADERA> ListMComboEspecies { get; set; }
        [Category("LIST"), Description("ListMComboEspeciesCondicion")]
        public List<Ent_DEVOLUCION_MADERA> ListMComboEspeciesCondicion { get; set; }
        [Category("LIST"), Description("ListMComboEspeciesEstado")]
        public List<Ent_DEVOLUCION_MADERA> ListMComboEspeciesEstado { get; set; }
        [Category("LIST"), Description("ListIndicador")]
        public List<Ent_DEVOLUCION_MADERA> ListIndicador { get; set; }
        [Category("LIST"), Description("ListMComboDIdentidad")]
        public List<Ent_DEVOLUCION_MADERA> ListMComboDIdentidad { get; set; }
        [Category("LIST"), Description("ListNUM_POA")]
        public List<Ent_DEVOLUCION_MADERA> ListNUM_POA { get; set; }
        [Category("LIST"), Description("ListODs")]
        public List<Ent_DEVOLUCION_MADERA> ListODs { get; set; }

        //TemEliiminar
        [Description("EliTABLA")]
        public String EliTABLA { get; set; }
        [Description("EliVALOR01")]
        public String EliVALOR01 { get; set; }
        [Description("EliVALOR02")]
        public Int32 EliVALOR02 { get; set; }
        [Category("LIST"), Description("ListEliTABLA")]
        public List<Ent_DEVOLUCION_MADERA> ListEliTABLA { get; set; }
        #endregion

        #region "Constructor"
        public Ent_DEVOLUCION_MADERA()
        {

            COD_SECUENCIAL = -1;
            EliVALOR02 = -1;
            NUM_POA = -1;
            COD_SECUENCIAL = -1;
            VOLUMEN = -1;
            VOLUMEN_2 = -1;
            DAP = -1;
            DAP_2 = -1;
            ALTURA = -1;
            ALTURA_2 = -1;
            NUM_TROZAS = -1;
            NUM_TROZAS_2 = -1;
            COORDENADA_NORTE = -1;
            COORDENADA_NORTE_2 = -1;
            COORDENADA_ESTE = -1;
            COORDENADA_ESTE_2 = -1;
            VOLUMEN_AUTORIZADO = -1;
            VOLUMEN_MOVILIZADO = -1;
            SALDO = -1;
            DIAMETRO = -1;
            DIAMETRO_2 = -1;
            LARGO = -1;
            LARGO_2 = -1;
            CANTIDAD = -1;
            CANTIDAD_2 = -1;
            NUMERO_FILA = -1;
            RegEstado = -1;
            EliVALOR02 = -1;
            NUM_PCOMPLEMENTARIO = -1;
            ESTADO_FILA = -1;
        }
        #endregion
    }

    public class Ent_DEVOLUCION_MADERA_CONSULTA
    {
        public string COD_THABILITANTE { get; set; }
        public string COD_DEVOLUCION { get; set; }
        public object FECHA_RESOLUCION { get; set; }
        public object NUM_RESOLUCION { get; set; }
        public int RegEstado { get; set; }
    }
}
