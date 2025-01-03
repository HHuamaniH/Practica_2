using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CapaEntidad.DOC
{
    public class Ent_PLAN_MANEJO
    {
        #region "Entidades y Propiedades"
        //
        [Description("COD_ESTADO_DOC")]
        public String COD_ESTADO_DOC { get; set; }
        [Description("OBSERVACIONES_CONTROL")]
        public Object OBSERVACIONES_CONTROL { get; set; }
        [Description("OBSERV_SUBSANAR")]
        public Object OBSERV_SUBSANAR { get; set; }
        //

        [Description("LISTA_INDEX")]
        public String LISTA_INDEX { get; set; }
        [Description("NUM_PCOMPLEMENTARIO")]
        public String NUM_PCOMPLEMENTARIO { get; set; }
        [Description("FUNCIONARIO_APROB_ACTIVIDAD")]
        public string FUNCIONARIO_APROB_ACTIVIDAD { get; set; }
        [Description("ARESOLUCION_COD_FUNCIONARIO")]
        public String ARESOLUCION_COD_FUNCIONARIO { get; set; }
        [Description("FUNCIONARIO_DNI")]
        public String FUNCIONARIO_DNI { get; set; }
        [Description("ZONA_CAPTURA")]
        public String ZONA_CAPTURA { get; set; }
        [Description("NUM_INFORME")]
        public String NUM_INFORME { get; set; }
        [Description("COD_PMANEJO")]
        public String COD_PMANEJO { get; set; }
        [Description("COD_THABILITANTE")]
        public String COD_THABILITANTE { get; set; }
        [Description("COD_TIOCULAR")]
        public String COD_TIOCULAR { get; set; }
        [Description("ESTADO_ORIGEN")]
        public String ESTADO_ORIGEN { get; set; }
        [Description("COD_TRAPROBACION")]
        public String COD_TRAPROBACION { get; set; }
        [Description("COD_UCUENTA")]
        public String COD_UCUENTA { get; set; }
        [Description("CONSULTOR_CODIGO")]
        public String CONSULTOR_CODIGO { get; set; }
        //dirección regente
        [Description("COD_UBIGEO_REGENTE")]
        public String COD_UBIGEO_REGENTE { get; set; }
        [Description("DIRECCION_REGENTE")]
        public String DIRECCION_REGENTE { get; set; }
        [Description("UBIGEO_REGENTE")]
        public String UBIGEO_REGENTE { get; set; }

        [Description("ACORDE_TDR_VIGENTE")]
        public Object ACORDE_TDR_VIGENTE { get; set; }
        [Description("HIJO_NIVEL")]
        public Int32 HIJO_NIVEL { get; set; }
        [Description("COD_MTIPO_HIJO")]
        public String COD_MTIPO_HIJO { get; set; }
        [Category("FECHA"), Description("ARESOLUCION_FECHA")]
        public Object ARESOLUCION_FECHA { get; set; }
        [Description("ARESOLUCION_NUM")]
        public String ARESOLUCION_NUM { get; set; }
        [Description("COD_MTIPO")]
        public String COD_MTIPO { get; set; }
        [Description("COD_PERSONA")]
        public String COD_PERSONA { get; set; }
        [Description("N_DOCUMENTO")]
        public String N_DOCUMENTO { get; set; }
        [Description("NUM_SDOCUMENTO")]
        public String NUM_SDOCUMENTO { get; set; }
        [Description("COD_ESPECIES")]
        public String COD_ESPECIES { get; set; }
        [Description("COD_PGSECUENCIAL")]
        public Int32 COD_PGSECUENCIAL { get; set; }
        [Description("NUM_FILA")]
        public Int32 NUM_FILA { get; set; }
        [Description("COD_SECUENCIAL")]
        public Int32 COD_SECUENCIAL { get; set; }
        [Description("DESCRIPCION")]
        public String DESCRIPCION { get; set; }
        [Description("COD_CAREA")]
        public String COD_CAREA { get; set; }
        [Description("ESPECIES")]
        public String ESPECIES { get; set; }
        [Description("CARACTERISTICAS")]
        public String CARACTERISTICAS { get; set; }
        [Description("RASOCIACIONES_FAUNA")]
        public String RASOCIACIONES_FAUNA { get; set; }

        [Description("NUM_REGISTRO_PROFESIONAL")]
        public String NUM_REGISTRO_PROFESIONAL { get; set; }
        [Description("CARGO")]
        public String CARGO { get; set; }
        [Description("CODIGO")]
        public String CODIGO { get; set; }
        [Description("TIPO")]
        public String TIPO { get; set; }
        [Description("COD_ENCIENTIFICO")]
        public String COD_ENCIENTIFICO { get; set; }
        [Description("NOMBRE_CIENTIFICO")]
        public String NOMBRE_CIENTIFICO { get; set; }
        
        [Description("NOMBRE_COMUN")]
        public String NOMBRE_COMUN { get; set; }

        //30-06-2021
        [Description("GRADO")]
        public String GRADO { get; set; }
        [Description("CATEGORIA")]
        public String CATEGORIA { get; set; }
        //
        [Description("CONSULTOR_NOMBRE")]
        public String CONSULTOR_NOMBRE { get; set; }
        [Description("CONSULTOR_NUM_REGISTRO_FFS")]
        public String CONSULTOR_NUM_REGISTRO_FFS { get; set; }
        [Description("CONSULTOR_DNI")]
        public String CONSULTOR_DNI { get; set; }
        [Description("CONSULTOR_NUM_REGISTRO_PROFESIONAL")]
        public String CONSULTOR_NUM_REGISTRO_PROFESIONAL { get; set; }
        //
        [Description("COD_GACATEGORIA")]
        public String COD_GACATEGORIA { get; set; }
        [Description("DESC_GACATEGORIA")]
        public String DESC_GACATEGORIA { get; set; }
        [Description("CANTIDAD_OTORGADA")]
        public Int32 CANTIDAD_OTORGADA { get; set; }
        [Description("CANTIDAD_AUTORIZADA_CAPTURA")]
        public Int32 CANTIDAD_AUTORIZADA_CAPTURA { get; set; }
        [Description("NUM_MACHO")]
        public Int32 NUM_MACHO { get; set; }
        [Description("NUM_HEMBRAS")]
        public Int32 NUM_HEMBRAS { get; set; }
        //
        [Description("ARESOLUCION_FUNCIONARIO_NOMBRE")]
        public String ARESOLUCION_FUNCIONARIO_NOMBRE { get; set; }

        [Description("ARESOLUCION_FUNCIONARIO_ODATOS")]
        public String ARESOLUCION_FUNCIONARIO_ODATOS { get; set; }
        [Description("APROB_ACTIVIDAD_AUTORIDAD")]
        public String APROB_ACTIVIDAD_AUTORIDAD { get; set; }
        [Description("APROB_ACTIVIDAD_RESOLUCION")]
        public String APROB_ACTIVIDAD_RESOLUCION { get; set; }
        [Category("FK"), Description("APROB_ACTIVIDAD_FUNCIONARIO")]
        public String APROB_ACTIVIDAD_FUNCIONARIO { get; set; }
        //
        [Category("FECHA"), Description("APROB_ACTIVIDAD_FECHA")]
        public Object APROB_ACTIVIDAD_FECHA { get; set; }
        [Description("APROB_ACTIVIDAD_ESTADO")]
        public Object APROB_ACTIVIDAD_ESTADO { get; set; }
        [Category("FECHA"), Description("FECHA")]
        public Object FECHA { get; set; }
        [Category("FECHA"), Description("FECHA_PRESENTACION")]
        public Object FECHA_PRESENTACION { get; set; }
        [Category("FECHA"), Description("IS_DURACION_FFIN")]
        public Object IS_DURACION_FFIN { get; set; }
        [Category("FECHA"), Description("IS_DURACION_FINICIO")]
        public Object IS_DURACION_FINICIO { get; set; }
        [Category("FECHA"), Description("ITECNICO_IOCULAR_FECHA")]
        public Object ITECNICO_IOCULAR_FECHA { get; set; }
        [Description("ITECNICO_IOCULAR_NUM")]
        public String ITECNICO_IOCULAR_NUM { get; set; }
        [Category("FECHA"), Description("ITECNICO_RAPROBACION_FECHA")]
        public Object ITECNICO_RAPROBACION_FECHA { get; set; }
        [Description("ITECNICO_RAPROBACION_NUM")]
        public String ITECNICO_RAPROBACION_NUM { get; set; }
        [Description("OBSERVACION")]
        public Object OBSERVACION { get; set; }
        [Description("PERSONA")]
        public String PERSONA { get; set; }
        [Description("ESTADO_ORIGEN_TIPO")]
        public String ESTADO_ORIGEN_TIPO { get; set; }
        [Description("HIJO_COD_PMANEJO")]
        public String HIJO_COD_PMANEJO { get; set; }
        [Description("THABILITANTE")]
        public String THABILITANTE { get; set; }
        [Description("UCUENTA")]
        public String UCUENTA { get; set; }
        [Description("MODALIDAD")]
        public String MODALIDAD { get; set; }
        [Description("PERSONA_TITULAR")]
        public String PERSONA_TITULAR { get; set; }
        [Description("INDICADOR")]
        public String INDICADOR { get; set; }
        [Description("NUM_THABILITANTE")]
        public String NUM_THABILITANTE { get; set; }
        //Plan Menjo Tara
        [Description("ANO")]
        public Int32 ANO { get; set; }
        [Description("COD_PMTOPCIONES")]
        public String COD_PMTOPCIONES { get; set; }
        [Description("ACTIVIDAD_CAPACITACION")]
        public Object ACTIVIDAD_CAPACITACION { get; set; }
        [Description("ANO_EPLANTACION")]
        public Int32 ANO_EPLANTACION { get; set; }
        [Description("MODALIDAD_COMERCIALIZACION")]
        public Object MODALIDAD_COMERCIALIZACION { get; set; }
        [Description("NUM_ARBOLES")]
        public Int32 NUM_ARBOLES { get; set; }
        [Description("NUM_ARBOLES_EDAD_APRO")]
        public Int32 NUM_ARBOLES_EDAD_APRO { get; set; }
        [Description("NUM_ARBOLES_NOEDAD_APRO")]
        public Int32 NUM_ARBOLES_NOEDAD_APRO { get; set; }
        [Description("NUM_COSECHA")]
        public Int32 NUM_COSECHA { get; set; }
        [Description("PESO_ARBOLES_EDAD_APRO")]
        public Decimal PESO_ARBOLES_EDAD_APRO { get; set; }
        [Description("PESO_VAINAS")]
        public Decimal PESO_VAINAS { get; set; }
        [Description("TARA_AREA_PREDIO")]
        public Decimal TARA_AREA_PREDIO { get; set; }
        [Description("TARA_AREA_MANEJO")]
        public Decimal TARA_AREA_MANEJO { get; set; }
        [Category("FECHA"), Description("BEXTRACCION_FEMISION")]
        public Object BEXTRACCION_FEMISION { get; set; }
        //autorizado a extraer
        [Description("SUPERFICIE_HA")]
        public Decimal SUPERFICIE_HA { get; set; }
        [Description("TOTAL_PGMF")]
        public Decimal TOTAL_PGMF { get; set; }
        [Description("ANO_1")]
        public Decimal ANO_1 { get; set; }
        [Description("ANO_2")]
        public Decimal ANO_2 { get; set; }
        [Description("ANO_3")]
        public Decimal ANO_3 { get; set; }
        [Description("ANO_4")]
        public Decimal ANO_4 { get; set; }
        [Description("ANO_5")]
        public Decimal ANO_5 { get; set; }
        [Description("DERECHO_APROVE_QUINTAL")]
        public Decimal DERECHO_APROVE_QUINTAL { get; set; }
        [Description("DERECHO_APROVE_QTOTAL")]
        public Decimal DERECHO_APROVE_QTOTAL { get; set; }
        //
        [Description("NUM_GTRANSPORTE")]
        public String NUM_GTRANSPORTE { get; set; }
        [Description("AUTORIZADO_CANTIDAD")]
        public Int32 AUTORIZADO_CANTIDAD { get; set; }
        [Description("APROVECHADO_KILOGRAMOS")]
        public Decimal APROVECHADO_KILOGRAMOS { get; set; }
        [Description("APROVECHADO_CANTIDAD")]
        public Int32 APROVECHADO_CANTIDAD { get; set; }
        [Description("SALDO")]
        public Decimal SALDO { get; set; }
        //AREA APROVECHADA
        [Description("NUM_PARCELA")]
        public String NUM_PARCELA { get; set; }
        [Description("NUM_PUNTOS")]
        public String NUM_PUNTOS { get; set; }
        [Description("NUM_ARBOLES_APROVE")]
        public Int32 NUM_ARBOLES_APROVE { get; set; }
        [Description("NUM_ARBOLES_NO_APROVE")]
        public Int32 NUM_ARBOLES_NO_APROVE { get; set; }
        [Description("PRODUCCION_ANUAL_PROMEDIO")]
        public Decimal PRODUCCION_ANUAL_PROMEDIO { get; set; }
        [Description("PESO_ESTIMADO_VAINAS")]
        public Decimal PESO_ESTIMADO_VAINAS { get; set; }
        //
        [Description("NUM_QUINTALES")]
        public Decimal NUM_QUINTALES { get; set; }
        //
        [Description("AREA_MANEJO")]
        public String AREA_MANEJO { get; set; }
        [Description("FAJA")]
        public String FAJA { get; set; }
        [Description("CONDICION")]
        public String CONDICION { get; set; }
        [Description("ESTADO_FITOSAN")]
        public String ESTADO_FITOSAN { get; set; }
        [Description("ALTURA_ESTIMADO")]
        public Decimal ALTURA_ESTIMADO { get; set; }
        [Description("PESO_VAINAS_KILOGRAMOS")]
        public Decimal PESO_VAINAS_KILOGRAMOS { get; set; }
        [Description("COORDENADA_ESTE")]
        public Int32 COORDENADA_ESTE { get; set; }
        [Description("COORDENADA_NORTE")]
        public Int32 COORDENADA_NORTE { get; set; }
        //
        //ExSitu Presentación de informes anuales
        [Description("ANO_EJECUTADO")]
        public Int32 ANO_EJECUTADO { get; set; }
        [Category("FECHA"), Description("FECHA_EMISION")]
        public Object FECHA_EMISION { get; set; }
        [Category("FECHA"), Description("FECHA_RECEPCION")]
        public Object FECHA_RECEPCION { get; set; }
        [Description("PROFESIONAL_CODIGO")]
        public String PROFESIONAL_CODIGO { get; set; }
        [Description("PROFESIONAL_NOMBRE")]
        public String PROFESIONAL_NOMBRE { get; set; }
        [Description("PRINCIPAL_ACCION_DESARROLLA")]
        public String PRINCIPAL_ACCION_DESARROLLA { get; set; }
        [Description("PROFESIONAL_DNI")]
        public String PROFESIONAL_DNI { get; set; }
        [Description("PROFESIONAL_NUM_REGISTRO_FFS")]
        public String PROFESIONAL_NUM_REGISTRO_FFS { get; set; }
        [Description("PROFESIONAL_NUM_REGISTRO_PROFESIONAL")]
        public String PROFESIONAL_NUM_REGISTRO_PROFESIONAL { get; set; }
        //
        //ExSitu Balance de Individuos
        [Description("COD_MOTIVO")]
        public String COD_MOTIVO { get; set; }
        [Description("COD_SDOCUMENTO")]
        public String COD_SDOCUMENTO { get; set; }
        [Description("NUM_DOCUMENTO")]
        public String NUM_DOCUMENTO { get; set; }
        [Description("DOCUMENTO")]
        public String DOCUMENTO { get; set; }
        [Description("MOTIVO")]
        public String MOTIVO { get; set; }
        //
        //INVENTARIO
        [Description("N_ARBOL")]
        public String N_ARBOL { get; set; }
        //
        [Category("OUTPUT"), Description("OUTPUTPARAM01")]
        public Object OUTPUTPARAM01 { get; set; }
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
        [Description("TIPO_PLAN")]
        public string TIPO_PLAN { get; set; }
        [Description("COD_DEPENDENCIA")]
        public string COD_DEPENDENCIA { get; set; }
        [Description("DIRECCION")]
        public string DIRECCION { get; set; }
        [Description("TIPOMADERABLE")]
        public string TIPOMADERABLE { get; set; }
        [Description("UNIDAD_MEDIDA")]
        public string UNIDAD_MEDIDA { get; set; }
        //Lista Objetos
        [Category("LIST"), Description("ListManPlanManejo")]
        public List<Ent_PLAN_MANEJO> ListManPlanManejo { get; set; }
        [Category("LIST"), Description("ListManPlanManejoItem")]
        public List<Ent_PLAN_MANEJO> ListManPlanManejoItem { get; set; }
        [Category("LIST"), Description("ListManPlanManejoDetItem")]
        public List<Ent_PLAN_MANEJO> ListManPlanManejoDetItem { get; set; }
        [Category("LIST"), Description("ListManTHabilitante")]
        public List<Ent_PLAN_MANEJO> ListManTHabilitante { get; set; }
        [Category("LIST"), Description("ListPMDTTIOCULAR")]
        public List<Ent_PLAN_MANEJO> ListPMDTTIOCULAR { get; set; }
        [Category("LIST"), Description("ListPMDTTRAPROBACION")]
        public List<Ent_PLAN_MANEJO> ListPMDTTRAPROBACION { get; set; }
        [Category("LIST"), Description("ListPMDISITUFLORA")]
        public List<Ent_PLAN_MANEJO> ListPMDISITUFLORA { get; set; }
        [Category("LIST"), Description("ListPMDISITUFAUNA")]
        public List<Ent_PLAN_MANEJO> ListPMDISITUFAUNA { get; set; }
        [Category("LIST"), Description("ListPMDISITUCAREA")]
        public List<Ent_PLAN_MANEJO> ListPMDISITUCAREA { get; set; }
        [Category("LIST"), Description("ListPMTDPPAPROVECHAMIENTO")]
        public List<Ent_PLAN_MANEJO> ListPMTDPPAPROVECHAMIENTO { get; set; }
        [Category("LIST"), Description("ListPMTDOOPCIONESEAPROVE")]
        public List<Ent_PLAN_MANEJO> ListPMTDOOPCIONESEAPROVE { get; set; }
        [Category("LIST"), Description("ListPMTDOOPCIONESPSILVI")]
        public List<Ent_PLAN_MANEJO> ListPMTDOOPCIONESPSILVI { get; set; }
        [Category("LIST"), Description("ListPMTBEXTRACCION")]
        public List<Ent_PLAN_MANEJO> ListPMTBEXTRACCION { get; set; }
        [Category("LIST"), Description("ListPMTINVENTARIO")]
        public List<Ent_PLAN_MANEJO> ListPMTINVENTARIO { get; set; }
        [Category("LIST"), Description("ListPMESITUIANUAL")]
        public List<Ent_PLAN_MANEJO> ListPMESITUIANUAL { get; set; }
        [Category("LIST"), Description("ListPMTAUTORIZADAEXTRA")]
        public List<Ent_PLAN_MANEJO> ListPMTAUTORIZADAEXTRA { get; set; }
        [Category("LIST"), Description("ListPMTAAPROVECHAMIENTO")]
        public List<Ent_PLAN_MANEJO> ListPMTAAPROVECHAMIENTO { get; set; }
        [Category("LIST"), Description("ListPMTCOORDENADAUTM")]
        public List<Ent_PLAN_MANEJO> ListPMTCOORDENADAUTM { get; set; }
        [Category("LIST"), Description("ListIndicador")]
        public List<Ent_PLAN_MANEJO> ListIndicador { get; set; }

        [Category("LIST"), Description("ListPGENETICO_FEXSITU")]
        public List<Ent_PLAN_MANEJO> ListPGENETICO_FEXSITU { get; set; }
        [Category("LIST"), Description("ListPGENETICO_FEXSITU_DET_ESPECIE")]
        public List<Ent_PLAN_MANEJO> ListPGENETICO_FEXSITU_DET_ESPECIE { get; set; }
        [Category("LIST"), Description("ListPGENETICO_FEXSITU_PGENTICO_INFORME")]
        public List<Ent_PLAN_MANEJO> ListPGENETICO_FEXSITU_PGENTICO_INFORME { get; set; }
        [Category("LIST"), Description("ListPGENETICO_FEXSITU_DET_INDIVIDUO")]
        public List<Ent_PLAN_MANEJO> ListPGENETICO_FEXSITU_DET_INDIVIDUO { get; set; }

        [Category("LIST"), Description("ListPMESITUBINDIVIDUAL_I")]
        public List<Ent_PLAN_MANEJO> ListPMESITUBINDIVIDUAL_I { get; set; }
        [Category("LIST"), Description("ListPMESITUBINDIVIDUAL_E")]
        public List<Ent_PLAN_MANEJO> ListPMESITUBINDIVIDUAL_E { get; set; }
        //
        [Category("LIST"), Description("ListMComboModalidad")]
        public List<Ent_PLAN_MANEJO> ListMComboModalidad { get; set; }
        [Category("LIST"), Description("ListMComboDIdentidad")]
        public List<Ent_PLAN_MANEJO> ListMComboDIdentidad { get; set; }
        [Category("LIST"), Description("ListMComboCArea")]
        public List<Ent_PLAN_MANEJO> ListMComboCArea { get; set; }
        [Category("LIST"), Description("ListMComboEspecieFauna")]
        public List<Ent_PLAN_MANEJO> ListMComboEspecieFauna { get; set; }
        [Category("LIST"), Description("ListMComboEspecieFlora")]
        public List<Ent_PLAN_MANEJO> ListMComboEspecieFlora { get; set; }
        [Category("LIST"), Description("ListMComboTaraOpciones")]
        public List<Ent_PLAN_MANEJO> ListMComboTaraOpciones { get; set; }
        [Category("LIST"), Description("ListPMECOTPROGIMPLEMENTAR")]
        public List<Ent_PLAN_MANEJO> ListPMECOTPROGIMPLEMENTAR { get; set; }
        [Category("LIST"), Description("ListMComboGAmenaza")]
        public List<Ent_PLAN_MANEJO> ListMComboGAmenaza { get; set; }
        [Category("LIST"), Description("ListMComboMotivo")]
        public List<Ent_PLAN_MANEJO> ListMComboMotivo { get; set; }
        [Category("LIST"), Description("ListMComboDocumento")]
        public List<Ent_PLAN_MANEJO> ListMComboDocumento { get; set; }
        [Category("LIST"), Description("ListPMINFORME_ANUAL")]
        public List<Ent_PLAN_MANEJO> ListPMINFORME_ANUAL { get; set; }
        [Category("LIST"), Description("ListODs")]
        public List<Ent_PLAN_MANEJO> ListODs { get; set; }
        [Category("LIST"), Description("ListMComboAutoextraer")]
        public List<Ent_PLAN_MANEJO> ListMComboAutoextraer { get; set; }
        [Category("LIST"), Description("ListDependencia")]
        public List<Ent_PLAN_MANEJO> ListDependencia { get; set; }

        //TemEliiminar
        [Description("EliTABLA")]
        public String EliTABLA { get; set; }
        [Description("EliVALOR01")]
        public String EliVALOR01 { get; set; }
        [Description("EliVALOR02")]
        public Int32 EliVALOR02 { get; set; }
        [Category("LIST"), Description("ListEliTABLA")]
        public List<Ent_PLAN_MANEJO> ListEliTABLA { get; set; }

        [Description("REGENTE_NUM_REGISTRO_FFS")]
        public String REGENTE_NUM_REGISTRO_FFS { get; set; }

        //Error Material
        [Category("LIST"), Description("ListErrorMaterialGeneral")]
        public List<Ent_ERRORMATERIAL> ListErrorMaterialGeneral { get; set; }
        [Category("LIST"), Description("ListErrorMaterialAdicional")]
        public List<Ent_ERRORMATERIAL> ListErrorMaterialAdicional { get; set; }
        #endregion


        #region PLAN GENERAL DE MANEJO FORESTAL
        [Description("COD_PGMF")]
        public String COD_PGMF { get; set; }
        [Description("NUMERO_PGMF")]
        public String NUMERO_PGMF { get; set; }
        [Description("FECHA_RESOLUCION")]
        public Object FECHA_RESOLUCION { get; set; }
        [Description("COD_FUNCIONARIO")]
        public String COD_FUNCIONARIO { get; set; }
        [Description("PRIM_QUIENQUENIO")]
        public Int32 PRIM_QUIENQUENIO { get; set; }
        [Description("SEG_QUINQUENIO")]
        public Int32 SEG_QUINQUENIO { get; set; }
        [Description("TERC_QUINQUENIO")]
        public Int32 TERC_QUINQUENIO { get; set; }
        [Description("CUART_QUINQUENIO")]
        public Int32 CUART_QUINQUENIO { get; set; }
        [Description("NUM_BLOQUES")]
        public Int32 NUM_BLOQUES { get; set; }
        [Description("DESC_BLOQUE")]
        public String DESC_BLOQUE { get; set; }
        [Description("AREA_PGMF")]
        public Decimal AREA_PGMF { get; set; }
        [Description("PERIODO")]
        public Int32 PERIODO { get; set; }
        [Description("FECHA_INICIO")]
        public Object FECHA_INICIO { get; set; }
        [Description("FECHA_FIN")]
        public Object FECHA_FIN { get; set; }
        [Description("NUM_INFORME_RECOMEN")]
        public String NUM_INFORME_RECOMEN { get; set; }
        [Description("FECHA_INFORME")]
        public Object FECHA_INFORME { get; set; }
        [Description("COD_PROF_INFORME")]
        public String COD_PROF_INFORME { get; set; }
        [Description("COD_CONSULTOR")]
        public String COD_CONSULTOR { get; set; }
        [Description("NUM_REGISTRO_ATFFS")]
        public String NUM_REGISTRO_ATFFS { get; set; }
        [Description("NUM_CIP")]
        public String NUM_CIP { get; set; }
        [Description("CONSOLIDADCION")]
        public Object CONSOLIDADCION { get; set; }
        [Description("NOMBRE_CONSOLIDAD")]
        public String NOMBRE_CONSOLIDAD { get; set; }
        [Description("OBSERVACIONES")]
        public String OBSERVACIONES { get; set; }
        [Description("D_LINEA")]
        public String D_LINEA { get; set; }

        [Description("VOLUMEN")]
        public Decimal VOLUMEN { get; set; }
        [Description("VERTICE")]
        public String VERTICE { get; set; }

        [Description("COD_AMENAZA")]
        public String COD_AMENAZA { get; set; }
        [Description("DESC_AMENAZA")]
        public String DESC_AMENAZA { get; set; }

        [Description("USUARIO_REGISTRO")]
        public String USUARIO_REGISTRO { get; set; }
        [Description("USUARIO_CONTROL")]
        public String USUARIO_CONTROL { get; set; }

        [Category("LIST"), Description("ListTHabilitante")]
        public List<Ent_PLAN_MANEJO> ListTHabilitante { get; set; }
        [Category("LIST"), Description("ListEspecies")]
        public List<Ent_PLAN_MANEJO> ListEspecies { get; set; }
        [Category("LIST"), Description("ListEspeciesFauna")]
        public List<Ent_PLAN_MANEJO> ListEspeciesFauna { get; set; }
        [Category("LIST"), Description("ListCoordenadas")]
        public List<Ent_PLAN_MANEJO> ListCoordenadas { get; set; }
        [Category("LIST"), Description("ListGradAmenaza")]
        public List<Ent_PLAN_MANEJO> ListGradAmenaza { get; set; }

        #endregion
        #region "Constructor";
        public Ent_PLAN_MANEJO()
        {
            HIJO_NIVEL = -1;
            DERECHO_APROVE_QUINTAL = -1;
            DERECHO_APROVE_QTOTAL = -1;
            ALTURA_ESTIMADO = -1;
            NUM_FILA = -1;
            COD_PGSECUENCIAL = -1;
            RegEstado = -1;
            COD_SECUENCIAL = -1;
            ANO = -1;
            ANO_EPLANTACION = -1;
            NUM_QUINTALES = -1;
            NUM_ARBOLES = -1;
            NUM_ARBOLES_EDAD_APRO = -1;
            NUM_ARBOLES_NOEDAD_APRO = -1;
            NUM_ARBOLES_APROVE = -1;
            NUM_ARBOLES_NO_APROVE = -1;
            PRODUCCION_ANUAL_PROMEDIO = -1;
            PESO_ESTIMADO_VAINAS = -1;
            NUM_COSECHA = -1;
            PESO_ARBOLES_EDAD_APRO = -1;
            TARA_AREA_PREDIO = -1;
            TARA_AREA_MANEJO = -1;
            PESO_VAINAS = -1;
            //
            AUTORIZADO_CANTIDAD = -1;
            APROVECHADO_KILOGRAMOS = -1;
            APROVECHADO_CANTIDAD = -1;
            SALDO = -1;
            //
            PESO_VAINAS_KILOGRAMOS = -1;
            COORDENADA_ESTE = -1;
            COORDENADA_NORTE = -1;
            //
            ANO_EJECUTADO = -1;
            //
            EliVALOR02 = -1;
            CANTIDAD_OTORGADA = -1;
            CANTIDAD_AUTORIZADA_CAPTURA = -1;
            NUM_MACHO = -1;
            NUM_HEMBRAS = -1;
            //
            SUPERFICIE_HA = -1;
            TOTAL_PGMF = -1;
            ANO_1 = -1;
            ANO_2 = -1;
            ANO_3 = -1;
            ANO_4 = -1;
            ANO_5 = -1;

            NUM_BLOQUES = -1;
            AREA_PGMF = -1;
            PERIODO = -1;
            VOLUMEN = -1;

            PRIM_QUIENQUENIO = -1;
            SEG_QUINQUENIO = -1;
            TERC_QUINQUENIO = -1;
            CUART_QUINQUENIO = -1;
        }
        #endregion
    }

}

