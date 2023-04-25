using System;
using System.Collections.Generic;
using System.ComponentModel;
/// <summary>
/// 2014-08-22  EPB Se añaden las listas ListHijoMadeCENSO y ListHijoNoMadeCENSO
/// 2014-08-25  EPB Se añade las entidades NUM_POA_REING y COD_SECUENCIAL_REING para control de Reingresos.
/// 2014-08-14  EPB Se añade VERT_COD_SECUENCIAL 
/// </summary>
namespace CapaEntidad.DOC
{
    public class Ent_POA
    {
        #region "Entidades y Propiedades"
        //Control de Calidad
        [Description("COD_ESTADO_DOC")]
        public String COD_ESTADO_DOC { get; set; }
        [Description("OBSERVACIONES_CONTROL")]
        public Object OBSERVACIONES_CONTROL { get; set; }
        [Description("OBSERV_SUBSANAR")]
        public Object OBSERV_SUBSANAR { get; set; }

        [Category("FK"), Description("ARESOLUCION_COD_FUNCIONARIO")]
        public String ARESOLUCION_COD_FUNCIONARIO { get; set; }
        [Category("FK"), Description("CONSULTOR_CODIGO")]
        public String CONSULTOR_CODIGO { get; set; }
        [Description("COD_ESPECIES")]
        public String COD_ESPECIES { get; set; }
        [Description("COD_ECONDICION")]
        public String COD_ECONDICION { get; set; }
        [Description("COD_EESTADO")]
        public String COD_EESTADO { get; set; }
        [Description("COD_SECUENCIAL")]
        public Int32 COD_SECUENCIAL { get; set; }
        [Description("COD_SECUENCIAL_RDREF")]
        public Int32 COD_SECUENCIAL_RDREF { get; set; }
        [Description("COD_SECUENCIAL_BEXT")]
        public Int32 COD_SECUENCIAL_BEXT { get; set; }
        [Description("COD_THABILITANTE")]
        public String COD_THABILITANTE { get; set; }
        [Description("COD_TIOCULAR")]
        public String COD_TIOCULAR { get; set; }
        [Description("COD_TRAPROBACION")]
        public String COD_TRAPROBACION { get; set; }
        [Description("COD_UCUENTA")]
        public String COD_UCUENTA { get; set; }
        [Description("NUM_POA")]
        public Int32 NUM_POA { get; set; }
        [Description("NOMBRE_POA")]
        public String NOMBRE_POA { get; set; }
        [Description("NUM_PCOMPLEMENTARIO")]
        public Int32 NUM_PCOMPLEMENTARIO { get; set; }
        [Description("VERTICE")]
        public String VERTICE { get; set; }
        [Description("ZONA")]
        public String ZONA { get; set; }
        [Description("AC")]
        public Decimal AC { get; set; }
        /*[Description("ACORDE_TDR_VIGENTE")]
        public Object ACORDE_TDR_VIGENTE { get; set; }*/
        [Description("ALTURA")]
        public Decimal ALTURA { get; set; }
        [Description("AREA")]
        public Decimal AREA { get; set; }
        [Category("FECHA"), Description("ARESOLUCION_FECHA")]
        public Object ARESOLUCION_FECHA { get; set; }
        [Description("ARESOLUCION_NUM")]
        public String ARESOLUCION_NUM { get; set; }
        [Description("BLOQUE")]
        public String BLOQUE { get; set; }
        [Description("COORDENADA_ESTE")]
        public Int32 COORDENADA_ESTE { get; set; }
        [Description("COORDENADA_NORTE")]
        public Int32 COORDENADA_NORTE { get; set; }
        [Description("CUENTA_PCOMPLEMENTARIO")]
        public Object CUENTA_PCOMPLEMENTARIO { get; set; }
        [Description("CUENTA_REINGRESO")]
        public Object CUENTA_REINGRESO { get; set; }
        [Description("DAP")]
        public Decimal DAP { get; set; }
        [Description("DIAMETRO")]
        public Decimal DIAMETRO { get; set; }
        [Description("DMC")]
        public Int32 DMC { get; set; }
        [Description("ESTADO_MUESTRA")]
        public Object ESTADO_MUESTRA { get; set; }
        [Description("ESTADO_ORIGEN")]
        public String ESTADO_ORIGEN { get; set; }
        [Description("FAJA")]
        public String FAJA { get; set; }
        [Category("FECHA"), Description("FECHA_EMISION")]
        public Object FECHA_EMISION { get; set; }
        [Category("FECHA"), Description("INICIO_VIGENCIA")]
        public Object INICIO_VIGENCIA { get; set; }
        [Category("FECHA"), Description("FIN_VIGENCIA")]
        public Object FIN_VIGENCIA { get; set; }
        [Category("FECHA"), Description("ITECNICO_IOCULAR_FECHA")]
        public Object ITECNICO_IOCULAR_FECHA { get; set; }
        [Description("ITECNICO_IOCULAR_NUM")]
        public String ITECNICO_IOCULAR_NUM { get; set; }
        [Category("FECHA"), Description("ITECNICO_RAPROBACION_FECHA")]
        public Object ITECNICO_RAPROBACION_FECHA { get; set; }
        [Category("FECHA"), Description("ACTA_IOCULAR_FECHA")]
        public Object ACTA_IOCULAR_FECHA { get; set; }
        [Category("FECHA"), Description("ITECNICO_REFORMULA_POA_FECHA")]
        public Object ITECNICO_REFORMULA_POA_FECHA { get; set; }

        //DIRECCION UBIGEO REGENTE

        [Description("DIRECCION_REGENTE")]
        public String DIRECCION_REGENTE { get; set; }
        [Description("UBIGEO_REGENTE")]
        public String UBIGEO_REGENTE { get; set; }
        [Description("COD_UBIGEO_REGENTE")]
        public String COD_UBIGEO_REGENTE { get; set; }

        [Description("COD_PARCELA")]
        public String COD_PARCELA { get; set; }

        [Description("ITECNICO_RAPROBACION_NUM")]
        public String ITECNICO_RAPROBACION_NUM { get; set; }
        [Description("KILOGRAMO_AUTORIZADO")]
        public Decimal KILOGRAMO_AUTORIZADO { get; set; }
        [Description("KILOGRAMO_MOVILIZADO")]
        public Decimal KILOGRAMO_MOVILIZADO { get; set; }
        [Description("KILOGRAMOS")]
        public Decimal KILOGRAMOS { get; set; }
        [Description("NUM_ARBOLES")]
        public Int32 NUM_ARBOLES { get; set; }
        [Description("NUM_ESTRADA")]
        public String NUM_ESTRADA { get; set; }
        [Description("OBSERVACION")]
        public Object OBSERVACION { get; set; }
        [Description("PCA")]
        public String PCA { get; set; }
        [Description("PRODUCCION_LATAS")]
        public Decimal PRODUCCION_LATAS { get; set; }
        [Description("SALDO")]
        public Decimal SALDO { get; set; }
        [Description("TOTAL_ARBOLES")]
        public Int32 TOTAL_ARBOLES { get; set; }
        [Description("VOLUMEN")]
        public Decimal VOLUMEN { get; set; }
        [Description("VOLUMEN_KILOGRAMOS")]
        public Decimal VOLUMEN_KILOGRAMOS { get; set; }
        [Description("VOLUMEN_AUTORIZADO")]
        public Decimal VOLUMEN_AUTORIZADO { get; set; }
        [Description("VOLUMEN_MOVILIZADO")]
        public Decimal VOLUMEN_MOVILIZADO { get; set; }
        [Description("ZAFRA_PCA")]
        public String ZAFRA_PCA { get; set; }
        [Description("ECONDICION")]
        public String ECONDICION { get; set; }
        [Description("EESTADO")]
        public String EESTADO { get; set; }
        [Description("PERSONA")]
        public String PERSONA { get; set; }
        [Description("UCUENTA")]
        public String UCUENTA { get; set; }
        [Description("CODIGO")]
        public String CODIGO { get; set; }
        [Description("DESCRIPCION")]
        public String DESCRIPCION { get; set; }
        [Description("PERSONA_TITULAR")]
        public String PERSONA_TITULAR { get; set; }
        [Description("INDICADOR")]
        public String INDICADOR { get; set; }
        [Description("NUM_THABILITANTE")]
        public String NUM_THABILITANTE { get; set; }
        [Description("FECHA")]
        public String FECHA { get; set; }
        [Description("MODALIDAD")]
        public String MODALIDAD { get; set; }
        [Description("N_DOCUMENTO")]
        public String N_DOCUMENTO { get; set; }
        [Description("ESPECIES")]
        public String ESPECIES { get; set; }
        [Description("NOMBRE_CIENTIFICO")]
        public String NOMBRE_CIENTIFICO { get; set; }
        [Description("CARGO")]
        public String CARGO { get; set; }
        [Description("COD_PERSONA")]
        public String COD_PERSONA { get; set; }
        [Description("COD_MTIPO")]
        public String COD_MTIPO { get; set; }
        [Description("COD_UBIDEPARTAMENTO")]
        public String COD_UBIDEPARTAMENTO { get; set; }
        [Description("CUENTA_FIN_ZAFRA")]
        public Object CUENTA_FIN_ZAFRA { get; set; }
        [Description("ACTA_IOCULAR_NUM")]
        public String ACTA_IOCULAR_NUM { get; set; }
        [Description("NUMERO_FILA")]
        public Int32 NUMERO_FILA { get; set; }
        [Description("NUM_POA_REING")]
        public Int32 NUM_POA_REING { get; set; }
        [Description("COD_SECUENCIAL_REING")]
        public Int32 COD_SECUENCIAL_REING { get; set; }
        [Description("COD_DEPENDENCIA")]
        public Int32? COD_DEPENDENCIA { get; set; }
        //
        [Description("CONSULTOR_NOMBRE")]
        public String CONSULTOR_NOMBRE { get; set; }
        [Description("CONSULTOR_NUM_REGISTRO_FFS")]
        public String CONSULTOR_NUM_REGISTRO_FFS { get; set; }
        [Description("REGENTE_NUM_REGISTRO_FFS")]
        public String REGENTE_NUM_REGISTRO_FFS { get; set; }
        [Description("CONSULTOR_DNI")]
        public String CONSULTOR_DNI { get; set; }
        [Description("CONSULTOR_NUM_REGISTRO_PROFESIONAL")]
        public String CONSULTOR_NUM_REGISTRO_PROFESIONAL { get; set; }
        //
        [Description("ARESOLUCION_FUNCIONARIO_NOMBRE")]
        public String ARESOLUCION_FUNCIONARIO_NOMBRE { get; set; }
        [Description("ARESOLUCION_FUNCIONARIO_ODATOS")]
        public String ARESOLUCION_FUNCIONARIO_ODATOS { get; set; }
        //
        [Description("NUM_RESOLUCION")]
        public String NUM_RESOLUCION { get; set; }
        [Category("FK"), Description("COD_FUNCIONARIO")]
        public String COD_FUNCIONARIO { get; set; }
        [Description("FUNCIONARIO_NOMBRE")]
        public String FUNCIONARIO_NOMBRE { get; set; }
        [Description("FUNCIONARIO_ODATOS")]
        public String FUNCIONARIO_ODATOS { get; set; }
        //
        [Category("FECHA"), Description("BEXTRACCION_FEMISION")]
        public Object BEXTRACCION_FEMISION { get; set; }
        //
        [Description("PERIODO")]
        public String PERIODO { get; set; }
        [Description("CUOTA_SACA")]
        public Int32 CUOTA_SACA { get; set; }
        [Description("METODO_CAZA")]
        public String METODO_CAZA { get; set; }
        [Description("SISTEMA_MARCAJE")]
        public String SISTEMA_MARCAJE { get; set; }
        [Description("DENSIDAD")]
        public Int32 DENSIDAD { get; set; }
        //
        [Description("ACTIVIDAD")]
        public String ACTIVIDAD { get; set; }
        [Description("OBJETIVOS")]
        public String OBJETIVOS { get; set; }
        [Description("METODO")]
        public String METODO { get; set; }
        [Description("PRESUPUESTO")]
        public Decimal PRESUPUESTO { get; set; }
        //
        [Description("MADERABLE")]
        public Object MADERABLE { get; set; }
        [Description("NO_MADERABLE")]
        public Object NO_MADERABLE { get; set; }
        //
        [Description("COD_BIOSEGURIDAD")]
        public String COD_BIOSEGURIDAD { get; set; }
        [Description("BIOSEGURIDAD")]
        public String BIOSEGURIDAD { get; set; }
        //
        [Description("CANTIDAD_AUTORIZADO")]
        public Decimal CANTIDAD_AUTORIZADO { get; set; }
        [Description("CANTIDAD_MOVILIZADO")]
        public Decimal CANTIDAD_MOVILIZADO { get; set; }
        //
        [Description("TMETODO_EPOBLACIONAL")]
        public String TMETODO_EPOBLACIONAL { get; set; }
        [Description("MANEJO_HABITAT")]
        public String MANEJO_HABITAT { get; set; }
        [Description("COMERCIO")]
        public String COMERCIO { get; set; }
        [Description("CONTROL_IMPACTO")]
        public String CONTROL_IMPACTO { get; set; }
        [Description("INVESTIGACION")]
        public String INVESTIGACION { get; set; }
        [Description("CAPACITACION")]
        public String CAPACITACION { get; set; }
        [Description("CONDICION")]
        public String CONDICION { get; set; }
        [Description("ESTADO")]
        public String ESTADO { get; set; }
        //
        [Description("ESTADO_ORIGEN_TIPO")]
        public String ESTADO_ORIGEN_TIPO { get; set; }
        [Description("REINGRESO")]
        public String REINGRESO { get; set; }
        [Description("MSALDO")]
        public String MSALDO { get; set; }
        [Description("HIJO_COD_THABILITANTE")]
        public String HIJO_COD_THABILITANTE { get; set; }
        [Description("HIJO_NUM_POA")]
        public Int32 HIJO_NUM_POA { get; set; }
        [Description("HIJO_NIVEL")]
        public Int32 HIJO_NIVEL { get; set; }
        //
        [Description("ITECNICO_REFORMULA_POA_NUM")]
        public String ITECNICO_REFORMULA_POA_NUM { get; set; }

        [Category("FK"), Description("ITECNICO_REFORMULA_COD_FUNCIONARIO")]
        public String ITECNICO_REFORMULA_COD_FUNCIONARIO { get; set; }
        [Description("COD_PREFORMULA")]
        public String COD_PREFORMULA { get; set; }
        [Description("COD_POCULAR")]
        public String COD_POCULAR { get; set; }
        [Description("TIPO")]
        public String TIPO { get; set; }

        //
        [Category("FECHA"), Description("FECHA_EMISIONKARDEX")]
        public Object FECHA_EMISIONKARDEX { get; set; }
        [Description("GUIA_TRANSPORTE")]
        public String GUIA_TRANSPORTE { get; set; }
        [Category("FK"), Description("COD_KARDEX_PRODUCTO")]
        public String COD_KARDEX_PRODUCTO { get; set; }
        [Category("FK"), Description("COD_KARDEX_DESCRIPCION")]
        public String COD_KARDEX_DESCRIPCION { get; set; }
        [Description("CANTIDAD")]
        public int CANTIDAD { get; set; }
        [Description("KILOGRAMOS_KARDEX")]
        public Decimal KILOGRAMOS_KARDEX { get; set; }
        [Description("M3")]
        public Decimal M3 { get; set; }
        [Description("ACUMULADO")]
        public Decimal ACUMULADO { get; set; }
        [Description("SALDO_KARDEX")]
        public Decimal SALDO_KARDEX { get; set; }
        [Description("OBSERVACION_KARDEX")]
        public String OBSERVACION_KARDEX { get; set; }
        [Description("DESCRIPCION_KARDEX")]
        public String DESCRIPCION_KARDEX { get; set; }
        [Description("PRODUCTO")]
        public String PRODUCTO { get; set; }
        [Description("SIN_INS_OCULAR")]
        public Object SIN_INS_OCULAR { get; set; }
        //
        [Description("LISTA_INDEX")]
        public String LISTA_INDEX { get; set; }
        //
        [Category("OUTPUT"), Description("OUTPUTPARAM01")]
        public Object OUTPUTPARAM01 { get; set; }
        [Category("OUTPUT"), Description("OUTPUTPARAM02")]
        public Object OUTPUTPARAM02 { get; set; }
        [Category("OUTPUT"), Description("OUTPUTPARAMDET01")]
        public Object OUTPUTPARAMDET01 { get; set; }
        [Description("BusFormulario")]
        public String BusFormulario { get; set; }
        [Description("BusCriterio")]
        public String BusCriterio { get; set; }
        [Description("BusValor")]
        public String BusValor { get; set; }
        [Description("BusValor2")]
        public int BusValor2 { get; set; }
        [Description("RegEstado")]
        public Int32 RegEstado { get; set; }
        [Description("COD_OD_REGISTRO")]
        public String COD_OD_REGISTRO { get; set; }

        [Description("NP_NUM_POA")]
        public Object NP_NUM_POA { get; set; }
        [Description("ESPO")]
        public Object ESPO { get; set; }

        [Description("NUM_CENSO_MADE_ELIM")]
        public Int32 NUM_CENSO_MADE_ELIM { get; set; }
        [Description("ELIM_TOTAL_CENSO")]
        public Object ELIM_TOTAL_CENSO { get; set; }

        [Description("USUARIO_REGISTRO")]
        public String USUARIO_REGISTRO { get; set; }
        [Description("USUARIO_CONTROL")]
        public String USUARIO_CONTROL { get; set; }

        //Lista Objetos
        [Category("LIST"), Description("ListTIOCULAR")]
        public List<Ent_POA> ListTIOCULAR { get; set; }
        [Category("LIST"), Description("ListTRAPROBACION")]
        public List<Ent_POA> ListTRAPROBACION { get; set; }
        [Category("LIST"), Description("ListRAprueba")]
        public List<Ent_POA> ListRAprueba { get; set; }
        [Category("LIST"), Description("ListRApruebaISitu")]
        public List<Ent_POA> ListRApruebaISitu { get; set; }
        [Category("LIST"), Description("ListRReformula")]
        public List<Ent_POA> ListRReformula { get; set; }
        [Category("LIST"), Description("ListRReformulaISitu")]
        public List<Ent_POA> ListRReformulaISitu { get; set; }
        [Category("LIST"), Description("ListASBSAmbientales")]
        public List<Ent_POA> ListASBSAmbientales { get; set; }
        [Category("LIST"), Description("ListBioseguridad")]
        public List<Ent_POA> ListBioseguridad { get; set; }
        [Category("LIST"), Description("ListMadeCENSO")]
        public List<Ent_POA> ListMadeCENSO { get; set; }
        [Category("LIST"), Description("ListMadeBusquedaCENSO")]
        public List<Ent_POA> ListMadeBusquedaCENSO { get; set; }
        [Category("LIST"), Description("ListNoMadeCENSO")]
        public List<Ent_POA> ListNoMadeCENSO { get; set; }
        [Category("LIST"), Description("ListMadeBEXTRACCION")]
        public List<Ent_POA> ListMadeBEXTRACCION { get; set; }
        [Category("LIST"), Description("ListNoMadeBEXTRACCION")]
        public List<Ent_POA> ListNoMadeBEXTRACCION { get; set; }
        [Category("LIST"), Description("ListISituBEXTRACCION")]
        public List<Ent_POA> ListISituBEXTRACCION { get; set; }
        [Category("LIST"), Description("ListKARDEX")]
        public List<Ent_POA> ListKARDEX { get; set; }
        [Category("LIST"), Description("ListVERTICE")]
        public List<Ent_POA> ListVERTICE { get; set; }
        [Category("LIST"), Description("ListMComboBSeguridad")]
        public List<Ent_POA> ListMComboBSeguridad { get; set; }
        [Category("LIST"), Description("ListMComboDIdentidad")]
        public List<Ent_POA> ListMComboDIdentidad { get; set; }
        [Category("LIST"), Description("ListMComboEspecies")]
        public List<Ent_POA> ListMComboEspecies { get; set; }
        [Category("LIST"), Description("ListMComboEspeciesCondicion")]
        public List<Ent_POA> ListMComboEspeciesCondicion { get; set; }
        [Category("LIST"), Description("ListMComboEspeciesEstado")]
        public List<Ent_POA> ListMComboEspeciesEstado { get; set; }
        [Category("LIST"), Description("ListManTHabilitante")]
        public List<Ent_POA> ListManTHabilitante { get; set; }
        [Category("LIST"), Description("ListManPOA")]
        public List<Ent_POA> ListManPOA { get; set; }
        [Category("LIST"), Description("ListManPOAItem")]
        public List<Ent_POA> ListManPOAItem { get; set; }
        [Category("LIST"), Description("ListManPOAItemDet")]
        public List<Ent_POA> ListManPOAItemDet { get; set; }
        [Category("LIST"), Description("ListIndicador")]
        public List<Ent_POA> ListIndicador { get; set; }
        [Category("LIST"), Description("ListREFORMULAPOA")]
        public List<Ent_POA> ListREFORMULAPOA { get; set; }
        [Category("LIST"), Description("ListAOCULAR")]
        public List<Ent_POA> ListAOCULAR { get; set; }
        [Category("LIST"), Description("ListKARDEXPRODUCTO")]
        public List<Ent_POA> ListKARDEXPRODUCTO { get; set; }
        [Category("LIST"), Description("ListKARDEXDESCRIPCION")]
        public List<Ent_POA> ListKARDEXDESCRIPCION { get; set; }
        [Category("LIST"), Description("ListHijoMadeCENSO")]
        public List<Ent_POA> ListHijoMadeCENSO { get; set; }
        [Category("LIST"), Description("ListHijoNoMadeCENSO")]
        public List<Ent_POA> ListHijoNoMadeCENSO { get; set; }
        [Category("LIST"), Description("ListODs")]
        public List<Ent_POA> ListODs { get; set; }

        //Nuevas variables para: detalle RD reformula, detalle balance de extracción
        [Category("LIST"), Description("ListRDReformulaPOA")]
        public List<Ent_POA> ListRDReformulaPOA { get; set; }
        [Category("LIST"), Description("ListBExtPOA")]
        public List<Ent_POA> ListBExtPOA { get; set; }

        //TemEliiminar
        [Description("EliTABLA")]
        public String EliTABLA { get; set; }
        [Description("EliVALOR01")]
        public String EliVALOR01 { get; set; }
        [Description("EliVALOR02")]
        public Int32 EliVALOR02 { get; set; }
        [Category("LIST"), Description("ListEliTABLA")]
        public List<Ent_POA> ListEliTABLA { get; set; }
        [Category("LIST"), Description("ListEliTABLAParcela")]
        public List<Ent_POA> ListEliTABLAParcela { get; set; }

        [Description("SuperficieHa")]
        public Decimal SuperficieHa { get; set; }
        [Category("FECHA1"), Description("FECHA1")]
        public Object FECHA1 { get; set; }
        [Category("FECHA2"), Description("FECHA2")]
        public Object FECHA2 { get; set; }
        [Category("RECIBO"), Description("RECIBO")]
        public String RECIBO { get; set; }
        [Description("TIPOMADERABLE")]
        public String TIPOMADERABLE { get; set; }
        // PLantas Medicinales
        [Category("ABUNDANCIA"), Description("ABUNDANCIA")]
        public Decimal ABUNDANCIA { get; set; }
        [Category("NUMINDIVIDUOS"), Description("NUMINDIVIDUOS")]
        public Decimal NUMINDIVIDUOS { get; set; }
        [Category("PESO"), Description("PESO")]
        public Decimal PESO { get; set; }
        [Category("RENDIMIENTO"), Description("RENDIMIENTO")]
        public Decimal RENDIMIENTO { get; set; }
        [Category("UNIDAD_MEDIDA"), Description("UNIDAD_MEDIDA")]
        public String UNIDAD_MEDIDA { get; set; }
        [Category("AUTORIZADO"), Description("AUTORIZADO")]
        public Decimal AUTORIZADO { get; set; }
        [Category("EXTRAIDO"), Description("EXTRAIDO")]
        public Decimal EXTRAIDO { get; set; }

        [Description("COD_ESPECIES_ARESOLUCION")]
        public String COD_ESPECIES_ARESOLUCION { get; set; }
        [Description("ESPECIES_ARESOLUCION")]
        public String ESPECIES_ARESOLUCION { get; set; }
        [Description("COD_ESPECIES_SERFOR")]
        public String COD_ESPECIES_SERFOR { get; set; }
        [Description("ESPECIES_SERFOR")]
        public String ESPECIES_SERFOR { get; set; }

        //TGS 26-12-2022: Agrega atributos del tipo de cargo
        [Description("COD_PTIPO")]
        public String COD_PTIPO { get; set; }
        [Description("TIPO_CARGO")]
        public String TIPO_CARGO { get; set; }

        [Category("LIST"), Description("ListMComboEspeciesSerfor")]
        public List<Ent_POA> ListMComboEspeciesSerfor { get; set; }

        [Category("LIST"), Description("ListDependencia")]
        public List<Ent_POA> ListDependencia { get; set; }

        #region Acervo Documentario
        /*
        oCampos.RLEGAL_NOMBRES = dr.GetString(dr.GetOrdinal("RLEGAL_NOMBRES"));
                            oCampos.AD_ACTA_NRO = dr.GetString(dr.GetOrdinal("AD_ACTA_NRO"));
                            oCampos.AD_FECHA = dr.GetString(dr.GetOrdinal("AD_FECHA"));
                            oCampos.AD_VERIFICADOR_CODIGO = dr.GetString(dr.GetOrdinal("AD_VERIFICADOR_CODIGO"));
                            oCampos.VERIFICADOR_ACERVO_NOMBRES = dr.GetString(dr.GetOrdinal("VERIFICADOR_ACERVO_NOMBRES"));
                            oCampos.REGENTE_NRO_LICENCIA = dr.GetString(dr.GetOrdinal("REGENTE_NRO_LICENCIA"));
                            oCampos.REGENTE_EMAIL = dr.GetString(dr.GetO*/
        [Description("RLEGAL_NOMBRES")]
        public String RLEGAL_NOMBRES { get; set; }
        [Description("AD_ACTA_NRO")]
        public String AD_ACTA_NRO { get; set; }
        [Category("FECHA"), Description("AD_FECHA")]
        public Object AD_FECHA { get; set; }
        [Description("AD_VERIFICADOR_CODIGO")]
        public String AD_VERIFICADOR_CODIGO { get; set; }
        [Description("VERIFICADOR_ACERVO_NOMBRES")]
        public String VERIFICADOR_ACERVO_NOMBRES { get; set; }
        [Description("REGENTE_NRO_LICENCIA")]
        public String REGENTE_NRO_LICENCIA { get; set; }
        [Description("REGENTE_EMAIL")]
        public String REGENTE_EMAIL { get; set; }


        //Titulo Habilitante
        [Description("AD_THContrato")]
        public Boolean? AD_THContrato { get; set; }
        [Description("AD_THAdenda")]
        public Boolean? AD_THAdenda { get; set; }
        [Description("AD_THPermiso")]
        public Boolean? AD_THPermiso { get; set; }
        [Description("AD_THAutorizacion")]
        public Boolean? AD_THAutorizacion { get; set; }
        [Description("AD_THResolucion")]
        public Boolean? AD_THResolucion { get; set; }
        //Resolucion
        [Description("AD_REAprobacion")]
        public Boolean? AD_REAprobacion { get; set; }
        [Description("AD_RECargo")]
        public Boolean? AD_RECargo { get; set; }
        [Description("AD_REReingreso")]
        public Boolean? AD_REReingreso { get; set; }
        [Description("AD_REMovilizacion")]
        public Boolean? AD_REMovilizacion { get; set; }
        [Description("AD_REReajuste")]
        public Boolean? AD_REReajuste { get; set; }

        //Documento de Gestion
        [Description("AD_DGPGMF")]
        public Boolean? AD_DGPGMF { get; set; }
        [Description("AD_DGPMFI")]
        public Boolean? AD_DGPMFI { get; set; }
        [Description("AD_DGPO")]
        public Boolean? AD_DGPO { get; set; }
        [Description("AD_DGDEMA")]
        public Boolean? AD_DGDEMA { get; set; }
        [Description("AD_DGPMCA")]
        public Boolean? AD_DGPMCA { get; set; }

        //Obligacion Documentales
        [Description("AD_ODBalance")]
        public Boolean? AD_ODBalance { get; set; }
        [Description("AD_ODRefinanciamiento")]
        public Boolean? AD_ODRefinanciamiento { get; set; }
        [Description("AD_ODSuspension")]
        public Boolean? AD_ODSuspension { get; set; }
        [Description("AD_ODGarantias")]
        public Boolean? AD_ODGarantias { get; set; }
        [Description("AD_ODInfEjecucionAnual")]
        public Boolean? AD_ODInfEjecucionAnual { get; set; }
        [Description("AD_ODInfEjecucionFinal")]
        public Boolean? AD_ODInfEjecucionFinal { get; set; }

        //Ejecucion Implementacion
        [Description("AD_EIGTF")]
        public Boolean? AD_EIGTF { get; set; }
        [Description("AD_EILibro")]
        public Boolean? AD_EILibro { get; set; }
        [Description("AD_EIKardex")]
        public Boolean? AD_EIKardex { get; set; }
        [Description("AD_EIForma20")]
        public Boolean? AD_EIForma20 { get; set; }
        [Description("AD_EIBalance")]
        public Boolean? AD_EIBalance { get; set; }
        [Description("AD_EILista")]
        public Boolean? AD_EILista { get; set; }

        //OTROS
        [Description("AD_OTActa")]
        public Boolean? AD_OTActa { get; set; }
        [Description("AD_OTInfInspeccion")]
        public Boolean? AD_OTInfInspeccion { get; set; }
        [Description("AD_OTInfRecomienda")]
        public Boolean? AD_OTInfRecomienda { get; set; }
        [Description("AD_OTContratoRegente")]
        public Boolean? AD_OTContratoRegente { get; set; }
        [Description("AD_OTContratoTercero")]
        public Boolean? AD_OTContratoTercero { get; set; }
        [Description("AD_OTDenuncias")]
        public Boolean? AD_OTDenuncias { get; set; }


        //Computo
        [Description("AD_CAIncluyeCD")]
        public Boolean? AD_CAIncluyeCD { get; set; }
        [Description("AD_CANroTomos")]
        public string AD_CANroTomos { get; set; }
        [Description("AD_CANroFolios")]
        public string AD_CANroFolios { get; set; }


        //Registro
        [Description("AD_RSConcluido")]
        public Boolean? AD_RSConcluido { get; set; }
        [Description("AD_RSProceso")]
        public Boolean? AD_RSProceso { get; set; }
        [Description("AD_RSPendiente")]
        public Boolean? AD_RSPendiente { get; set; }
        [Description("AD_Observaciones")]
        public String AD_Observaciones { get; set; }
        #endregion

        //05/05/2021
        [Category("LIST"), Description("ListParcela")]
        public List<Ent_POA> ListParcela { get; set; }

        //Error Material
        [Category("LIST"), Description("ListPOAErrorMaterialG")]
        public List<Ent_ERRORMATERIAL> ListPOAErrorMaterialG { get; set; }
        [Category("LIST"), Description("ListPOAErrorMaterialA")]
        public List<Ent_ERRORMATERIAL> ListPOAErrorMaterialA { get; set; }

        #endregion


        #region "Constructor"
        public Ent_POA()
        {
            AUTORIZADO = -1;
            EXTRAIDO = -1;
            ABUNDANCIA = -1;
            NUMINDIVIDUOS = -1;
            PESO = -1;
            RENDIMIENTO = -1;
            SuperficieHa = -1;

            NUMERO_FILA = -1;
            COD_SECUENCIAL = -1;
            COD_SECUENCIAL_RDREF = -1;
            NUM_POA = -1;
            NUM_PCOMPLEMENTARIO = -1;
            AC = -1;
            ALTURA = -1;
            AREA = -1;
            COORDENADA_ESTE = -1;
            COORDENADA_NORTE = -1;
            CUOTA_SACA = -1;
            DENSIDAD = -1;
            DAP = -1;
            DIAMETRO = -1;
            DMC = -1;
            KILOGRAMO_AUTORIZADO = -1;
            KILOGRAMO_MOVILIZADO = -1;
            KILOGRAMOS = -1;
            NUM_ARBOLES = -1;
            PRODUCCION_LATAS = -1;
            SALDO = -1;
            TOTAL_ARBOLES = -1;
            VOLUMEN = -1;
            VOLUMEN_KILOGRAMOS = -1;
            VOLUMEN_AUTORIZADO = -1;
            VOLUMEN_MOVILIZADO = -1;
            PRESUPUESTO = -1;
            //
            CANTIDAD_AUTORIZADO = -1;
            CANTIDAD_MOVILIZADO = -1;
            //
            HIJO_NUM_POA = -1;
            HIJO_NIVEL = -1;
            //
            RegEstado = -1;
            EliVALOR02 = -1;
            CANTIDAD = -1;
            KILOGRAMOS_KARDEX = -1;
            M3 = -1;
            ACUMULADO = -1;
            SALDO_KARDEX = -1;
            NUM_POA_REING = -1;
            COD_SECUENCIAL_REING = -1;

            NUM_CENSO_MADE_ELIM = -1;
            COD_SECUENCIAL_BEXT = -1;
            BusValor2 = -1;
        }
        #endregion
    }

    public class Ent_POA_CONSULTA
    {
        public string COD_THABILITANTE { get; set; }
        public int NUM_POA { get; set; }
        public string NOMBRE_POA { get; set; }
        public string ARESOLUCION_NUM { get; set; }
        public int NUM_MUESTRA { get; set; }
        public int RegEstado { get; set; }
    }
}

