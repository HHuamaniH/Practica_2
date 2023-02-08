using CapaEntidad.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using CEntSDetDevol = CapaEntidad.DOC.Ent_DEVOLUCION_MADERA;
using CEntSDetMarable = CapaEntidad.DOC.Ent_ISUPERVISION_DET_EMADERABLE;
namespace CapaEntidad.DOC
{
    public class Ent_CNOTIFICACION
    {
        #region "Entidades y Propiedades"
        [Description("TIPO")]
        public Int32 TIPO { get; set; }
        [Description("ARCHIVO")]
        public String ARCHIVO { get; set; }
        [Description("COD_PMANEJO")]
        public String COD_PMANEJO { get; set; }
        [Description("NOMBRE_POA")]
        public String NOMBRE_POA { get; set; }
        [Description("COD_ESTADO_DOC")]
        public String COD_ESTADO_DOC { get; set; }
        [Description("OBSERVACIONES_CONTROL")]
        public Object OBSERVACIONES_CONTROL { get; set; }
        [Description("OBSERV_SUBSANAR")]
        public Object OBSERV_SUBSANAR { get; set; }

        [Description("COD_DLINEA")]
        public String COD_DLINEA { get; set; }

        [Description("COD_THABILITANTE")]
        public String COD_THABILITANTE { get; set; }

        [Description("NUM_THABILITANTE")]
        public String NUM_THABILITANTE { get; set; }

        [Description("PERSONA_NOTIFICADOR")]
        public String PERSONA_NOTIFICADOR { get; set; }
        //
        [Description("INDICADOR")]
        public String INDICADOR { get; set; }
        //
        [Description("NUM_POA")]
        public Int32 NUM_POA { get; set; }

        [Description("NUM_PCOMPLEMENTARIO")]
        public String NUM_PCOMPLEMENTARIO { get; set; }

        [Description("BUZON")]
        public Object BUZON { get; set; }

        [Description("COD_CNOTIFICACION")]
        public String COD_CNOTIFICACION { get; set; }
        [Description("COD_FISNOTI")]
        public String COD_FISNOTI { get; set; }

        [Category("FK"), Description("RNOTIFICACION_COD_PERSONA")]
        public String RNOTIFICACION_COD_PERSONA { get; set; }

        [Description("PERSONA_RNOTIFICACION")]
        public String PERSONA_RNOTIFICACION { get; set; }

        [Description("NUMERO")]
        public String NUMERO { get; set; }

        [Category("FECHA"), Description("FECHA_EMISION")]
        public Object FECHA_EMISION { get; set; }

        [Category("FECHA"), Description("FECHA_CREACION")]
        public Object FECHA_CREACION { get; set; }

        [Category("FECHA"), Description("FECHA_RECEPCION_OD")]
        public Object FECHA_RECEPCION_OD { get; set; }

        [Category("FECHA"), Description("FECHA_PSUPERVISION")]
        public Object FECHA_PSUPERVISION { get; set; }

        [Description("MES_SUPERVISION")]
        public String MES_SUPERVISION { get; set; }

        [Category("FECHA"), Description("FECHA_NOTIFICADOR")]
        public Object FECHA_NOTIFICADOR { get; set; }

        [Category("FECHA"), Description("RNOTIFICACION_FECHA")]
        public Object RNOTIFICACION_FECHA { get; set; }

        [Category("FK"), Description("COD_PARENTESCO_RTITULAR")]
        public String COD_PARENTESCO_RTITULAR { get; set; }

        [Category("FK"), Description("LNOTIFI_COD_UBIGEO")]
        public String LNOTIFI_COD_UBIGEO { get; set; }

        [Description("LNOTIF_UBIGEO")]
        public String LNOTIFI_UBIGEO { get; set; }

        [Description("LNOTIFI_DIRECCION")]
        public String LNOTIFI_DIRECCION { get; set; }

        [Description("DIR_COINCIDE_DTITULAR")]
        public Object DIR_COINCIDE_DTITULAR { get; set; }

        [ Description("LNOTIFI_COD_UBIGEO_ACTUAL")]
        public String LNOTIFI_COD_UBIGEO_ACTUAL { get; set; }

        [Description("LNOTIF_UBIGEO_ACTUAL")]
        public String LNOTIFI_UBIGEO_ACTUAL { get; set; }

        [Description("LNOTIFI_DIRECCION_ACTUAL")]
        public String LNOTIFI_DIRECCION_ACTUAL { get; set; }

        [Description("LNOTIFI_REFERENCIA_ACTUAL")]
        public String LNOTIFI_REFERENCIA_ACTUAL { get; set; }

        [Description("NOMBRE_COINCIDE_DTITULAR")]
        public String NOMBRE_COINCIDE_DTITULAR { get; set; }

        [Description("NINTERNET_TITULAR")]
        public int NINTERNET_TITULAR { get; set; }

        [Category("FK"), Description("COD_PERSONA_NOTIFICADOR")]
        public String COD_PERSONA_NOTIFICADOR { get; set; }

        [Description("NOMBRE_PERSONA_NOTIFICADOR")]
        public String NOMBRE_PERSONA_NOTIFICADOR { get; set; }

        [Description("ESTADO_ORIGEN")]
        public String ESTADO_ORIGEN { get; set; }

        [Description("OBSERVACION")]
        public Object OBSERVACION { get; set; }

        [Description("OBS_PSUPERVISION")]
        public Object OBS_PSUPERVISION { get; set; }

        [Description("COD_UCUENTA")]
        public String COD_UCUENTA { get; set; }

        [Category("OUTPUT"), Description("OUTPUTPARAM01")]
        public Object OUTPUTPARAM01 { get; set; }

        [Description("ELIM_TOTAL_MUESTRA_M")]
        public Object ELIM_TOTAL_MUESTRA_M { get; set; }
        [Description("ELIM_TOTAL_MUESTRA_NM")]
        public Object ELIM_TOTAL_MUESTRA_NM { get; set; }
        [Description("ELIM_TOTAL_MUESTRA_DMTR")]
        public Object ELIM_TOTAL_MUESTRA_DMTR { get; set; }
        [Description("ELIM_TOTAL_MUESTRA_DMTO")]
        public Object ELIM_TOTAL_MUESTRA_DMTO { get; set; }
        [Description("ELIM_TOTAL_MUESTRA_DMAR")]
        public Object ELIM_TOTAL_MUESTRA_DMAR { get; set; }

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

        [Description("CODIGO")]
        public String CODIGO { get; set; }

        [Description("DESCRIPCION")]
        public String DESCRIPCION { get; set; }
        //
        [Description("ANO")]
        public Int32 ANO { get; set; }
        [Category("FK"), Description("COD_DIDENTIDAD")]
        public String COD_DIDENTIDAD { get; set; }
        [Description("COD_PERSONA")]
        public String COD_PERSONA { get; set; }
        [Description("COD_SECUENCIAL")]
        public Int32 COD_SECUENCIAL { get; set; }
        [Description("APELLIDOS_NOMBRES")]
        public String APELLIDOS_NOMBRES { get; set; }

        [Category("FK"), Description("COD_UBIGEO")]
        public String COD_UBIGEO { get; set; }

        [Description("ESTAB_UBIGEO")]
        public String ESTAB_UBIGEO { get; set; }
        [Description("DIRECCION")]
        public String DIRECCION { get; set; }
        //
        [Description("UBIGEO")]
        public String UBIGEO { get; set; }
        [Description("COD_DEVOLUCION")]
        public String COD_DEVOLUCION { get; set; }
        [Category("FECHA"), Description("FECHA_RESOLUCION")]
        public String FECHA_RESOLUCION { get; set; }
        [Description("NUM_RESOLUCION")]
        public String NUM_RESOLUCION { get; set; }

        [Description("NUM_ZAFRA")]
        public String NUM_ZAFRA { get; set; }
        [Description("NUM_PARCELA")]
        public String NUM_PARCELA { get; set; }

        [Description("NUM_ARBOL_AUTORIZADO")]
        public Int32 NUM_ARBOL_AUTORIZADO { get; set; }
        [Description("CALCULAR_MUESTRA")]
        public Int32 CALCULAR_MUESTRA { get; set; }
        [Description("CANTIDAD_APROBADA")]
        public Decimal CANTIDAD_APROBADA { get; set; }

        [Category("LIST"), Description("ListMComboDIdentidad")]
        public List<Ent_CNOTIFICACION> ListMComboDIdentidad { get; set; }
        [Category("LIST"), Description("ListMComboParentesco")]
        public List<Ent_CNOTIFICACION> ListMComboParentesco { get; set; }
        [Category("LIST"), Description("ListMComboTipoComprobante")]
        public List<Ent_CNOTIFICACION> ListMComboTipoComprobante { get; set; }
        [Category("LIST"), Description("ListMComboPSuperGasto")]
        public List<Ent_CNOTIFICACION> ListMComboPSuperGasto { get; set; }
        [Category("LIST"), Description("ListMComboPSuperConcepto")]
        public List<Ent_CNOTIFICACION> ListMComboPSuperConcepto { get; set; }
        /*[Category("LIST"), Description("ListMComboDireccionLinea")]
		public List<Ent_CNOTIFICACION> ListMComboDireccionLinea { get; set; }*/
        [Category("LIST"), Description("ListRNOTIFICACION")]
        public List<Ent_CNOTIFICACION> ListRNOTIFICACION { get; set; }
        [Category("LIST"), Description("ListNUM_POA")]
        public List<Ent_CNOTIFICACION> ListNUM_POA { get; set; }
        [Category("LIST"), Description("ListNUM_DEVOL")]
        public List<Ent_CNOTIFICACION> ListNUM_DEVOL { get; set; }
        [Category("LIST"), Description("ListSDETDEVOLUCION")]
        public List<CEntSDetDevol> ListSDETDEVOLUCION { get; set; }
        [Category("LIST"), Description("ListSDETDEVOLUCION_Muestra")]
        public List<CEntSDetDevol> ListSDETDEVOLUCION_Muestra { get; set; }
        [Category("LIST"), Description("ListSDETDEVOLUCION_Buscar")]
        public List<CEntSDetDevol> ListSDETDEVOLUCION_Buscar { get; set; }
        //[Category("LIST"), Description("ListTHABILITANTEPOA")]
        //public List<Ent_CNOTIFICACION> ListTHABILITANTEPOA { get; set; }

        [Category("LIST"), Description("ListDetMuestra")]
        public List<Ent_CNOTIFICACION> ListDetMuestra { get; set; }
        [Category("LIST"), Description("ListSDETMADERABLE")]
        public List<CEntSDetMarable> ListSDETMADERABLE { get; set; }
        [Category("LIST"), Description("ListSDETMADERABLE_Muestra")]
        public List<CEntSDetMarable> ListSDETMADERABLE_Muestra { get; set; }
        [Category("LIST"), Description("ListSDETMADERABLE_Buscar")]
        public List<CEntSDetMarable> ListSDETMADERABLE_Buscar { get; set; }
        [Category("LIST"), Description("ListEliTABLA")]
        public List<Ent_CNOTIFICACION> ListEliTABLA { get; set; }
        [Category("LIST"), Description("ListEliTABLACenso")]
        public List<Ent_CNOTIFICACION> ListEliTABLACenso { get; set; }
        [Category("LIST"), Description("ListIndicador")]
        public List<Ent_CNOTIFICACION> ListIndicador { get; set; }
        [Category("LIST"), Description("ListODs")]
        public List<Ent_CNOTIFICACION> ListODs { get; set; }
        [Category("LIST"), Description("ListTipoCN")]
        public List<Ent_CNOTIFICACION> ListTipoCN { get; set; }
        //[Category("LIST"), Description("ListaMes")]
        //public List<Ent_CNOTIFICACION> ListaMes { get; set; }
        [Description("EliTABLA")]
        public String EliTABLA { get; set; }

        [Description("COD_ESPECIES")]
        public String COD_ESPECIES { get; set; }
        //ORIGEN PARA DEVOLUCION_MADERA Y/O PLAN_MANEJO
        [Description("COD_ORIGEN")]
        public Object COD_ORIGEN { get; set; }

        //Nuevo tipo de Carta de Notificación: 15/12/2016
        [Description("MAE_COD_CNTIPO")]
        public String MAE_COD_CNTIPO { get; set; }
        [Description("MAE_CNTIPO")]
        public String MAE_CNTIPO { get; set; }
        [Description("COD_CNOTIFICACION_REF")]
        public String COD_CNOTIFICACION_REF { get; set; }
        [Description("NUMERO_REF")]
        public String NUMERO_REF { get; set; }

        //Número de muestra: 20/02/2017
        [Description("ESTADO_MUESTRA2")]
        public Object ESTADO_MUESTRA2 { get; set; }
        [Description("ESTADO_MUESTRA3")]
        public Object ESTADO_MUESTRA3 { get; set; }
        [Description("NUM_MUESTRA")]
        public Int32 NUM_MUESTRA { get; set; }

        [Description("USUARIO_REGISTRO")]
        public String USUARIO_REGISTRO { get; set; }
        [Description("USUARIO_CONTROL")]
        public String USUARIO_CONTROL { get; set; }

        [Description("TIPO_REPORTE")]
        public String TIPO_REPORTE { get; set; }
        [Description("MTIPO")]
        public String MTIPO { get; set; }
        [Description("ESTADO_ORIGEN_TEXT")]
        public String ESTADO_ORIGEN_TEXT { get; set; }
        [Description("COD_MTIPO")]
        public String COD_MTIPO { get; set; }
        [Description("SECTOR")]
        public String SECTOR { get; set; }

        

        [Description("COD_INFORME")]
        public String COD_INFORME { get; set; }
        [Description("NUM_INFORME")]
        public String NUM_INFORME { get; set; }

        [Description("ID_TRAMITE_SITD")]
        public int ID_TRAMITE_SITD { get; set; }

        
        public VM_Persona ENT_NOTIFICADO { get; set; }

        #endregion
        #region "Constructor"
        public Ent_CNOTIFICACION()
        {
            ID_TRAMITE_SITD = -1;
            ANO = -1;
            COD_SECUENCIAL = -1;
            //
            RegEstado = -1;
            NUM_POA = -1;
            NUM_ARBOL_AUTORIZADO = -1;
            CALCULAR_MUESTRA = -1;
            CANTIDAD_APROBADA = -1;
            //COD_ZAFRA = -1;
            TIPO = -1;
            NUM_MUESTRA = -1;
            NINTERNET_TITULAR = -1;
        }
        #endregion
    }
}
