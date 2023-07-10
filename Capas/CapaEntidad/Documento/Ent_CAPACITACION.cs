using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CapaEntidad.DOC
{
    public class Ent_CAPACITACION
    {
        #region "Entidades y Propiedades"		
        //Control de Calidad
        [Description("COD_ESTADO_DOC")]
        public String COD_ESTADO_DOC { get; set; }
        [Description("OBSERVACIONES_CONTROL")]
        public String OBSERVACIONES_CONTROL { get; set; }
        [Description("OBSERV_SUBSANAR")]
        public Object OBSERV_SUBSANAR { get; set; }
        //Capacitacion
        [Description("COD_CAPACITACION")]
        public String COD_CAPACITACION { get; set; }
        [Description("NOMBRE")]
        public String NOMBRE { get; set; }
        [Description("COD_CAPATIPO")]
        public String COD_CAPATIPO { get; set; }
        public String CAPATIPO { get; set; }
        public String DIRIGIDO { get; set; }
        [Description("COD_OD")]
        public String COD_OD { get; set; }
        [Description("COD_DLINEA")]
        public String COD_DLINEA { get; set; }
        [Description("COD_UBIGEO")]
        public String COD_UBIGEO { get; set; }
        [Description("UBIGEO_DESCRIPCION")]
        public String UBIGEO_DESCRIPCION { get; set; }
        [Description("SECTOR")]
        public String SECTOR { get; set; }
        [Description("LUGAR")]
        public String LUGAR { get; set; }
        [Category("FECHA"), Description("FECHA_INICIO")]
        public Object FECHA_INICIO { get; set; }
        [Category("FECHA"), Description("FECHA_TERMINO")]
        public Object FECHA_TERMINO { get; set; }
        [Description("N_PARTICIPANTES")]
        public Int32 N_PARTICIPANTES { get; set; }
        [Description("OBSERVACION")]
        public Object OBSERVACION { get; set; }
        [Description("COD_UCUENTA")]
        public Object COD_UCUENTA { get; set; }
        [Description("DURACION")]
        public Int32 DURACION { get; set; }
        [Description("MAE_COD_ORGANIZADOR")]
        public String MAE_COD_ORGANIZADOR { get; set; }
        [Description("ORGANIZADOR")]
        public String ORGANIZADOR { get; set; }

        //Nota Conceptual   
        [Description("ANTECEDENTES")]
        public String ANTECEDENTES { get; set; }
        [Description("JUSTIFICACION")]
        public String JUSTIFICACION { get; set; }
        [Description("RESULTADOS_ESPERADOS")]
        public String RESULTADOS_ESPERADOS { get; set; }
        [Description("COD_MODALIDAD")]
        public String COD_MODALIDAD { get; set; }
        [Description("MATERIALES_EQUIPO")]
        public String MATERIALES_EQUIPO { get; set; }
        [Description("PUBLICO_OBJETIVO")]
        public String PUBLICO_OBJETIVO { get; set; }
        [Description("CRONOGRAMA")]
        public String CRONOGRAMA { get; set; }
        [Description("PROGRAMA")]
        public String PROGRAMA { get; set; }
        //Memoria Taller
        [Description("PRESENTACION")]
        public String PRESENTACION { get; set; }
        [Description("DESCRIPCION_EJECUTIVA")]
        public String DESCRIPCION_EJECUTIVA { get; set; }
        [Description("RESUMEN_INTERVENCIONES")]
        public String RESUMEN_INTERVENCIONES { get; set; }
        [Description("DESCRIPCION_TRABAJO")]
        public String DESCRIPCION_TRABAJO { get; set; }
        //Conclusiones y Recomendaciones
        [Description("RECOMENDACIONES")]
        public String RECOMENDACIONES { get; set; }
        //Programa
        [Description("FECHA_PROGRAMA")]
        public String FECHA_PROGRAMA { get; set; }
        [Description("HORA")]
        public String HORA { get; set; }
        [Description("TEMA")]
        public String TEMA { get; set; }
        [Description("RESPONSABLE")]
        public String RESPONSABLE { get; set; }
        //Cronograma
        [Description("ACTIVIDAD")]
        public String ACTIVIDAD { get; set; }
        [Description("FECHA_INICIO_CRONOGRAMA")]
        public String FECHA_INICIO_CRONOGRAMA { get; set; }
        [Description("FECHA_FIN_CRONOGRAMA")]
        public String FECHA_FIN_CRONOGRAMA { get; set; }
        //Para Grafico Evaluación Inicial y Final

        //[Description("BUENO")]
        //public Int32 BUENO { get; set; }       
        //[Description("REGULAR")]
        //public Int32 REGULAR { get; set; }        
        //[Description("MALO")]
        //public Int32 MALO { get; set; }


        [Description("APOYO_COORGANIZ_DIFUSION")]
        public object APOYO_COORGANIZ_DIFUSION { get; set; }
        [Description("APOYO_COORGANIZ_FIRMA")]
        public object APOYO_COORGANIZ_FIRMA { get; set; }
        [Description("APOYO_COORGANIZ_LOGISTICO")]
        public object APOYO_COORGANIZ_LOGISTICO { get; set; }
        //18/05/2017
        [Description("OBJETIVO")]
        public String OBJETIVO { get; set; }
        [Description("DESCRIPCION_TEMAS")]
        public String DESCRIPCION_TEMAS { get; set; }
        [Description("MAE_COD_METODO")]
        public String MAE_COD_METODO { get; set; }
        [Description("OBSERVACION_METODO")]
        public String OBSERVACION_METODO { get; set; }
        [Description("CONCLUSION")]
        public String CONCLUSION { get; set; }
        [Description("MAE_COD_TEMA")]
        public String MAE_COD_TEMA { get; set; }
        [Description("SUMA_POI")]
        public object SUMA_POI { get; set; }
        [Description("COD_CCNN")]
        public String COD_CCNN { get; set; }
        [Description("CCNN")]
        public String CCNN { get; set; }
        [Description("ETNIA")]
        public String ETNIA { get; set; }
        [Description("MAE_COD_TIPOPARTICIPANTE")]
        public String MAE_COD_TIPOPARTICIPANTE { get; set; }
        [Description("ZONA_UTM")]
        public String ZONA_UTM { get; set; }
        [Description("COORD_ESTE")]
        public Int32 COORD_ESTE { get; set; }
        [Description("COORD_NORTE")]
        public Int32 COORD_NORTE { get; set; }
        //DETALLE
        [Description("COD_PTIPO")]
        public String COD_PTIPO { get; set; }
        [Description("ANO")]
        public Int32 ANO { get; set; }
        [Description("COD_SECUENCIAL")]
        public Int32 COD_SECUENCIAL { get; set; }
        [Description("NOMBRE_ARCHIVO")]
        public String NOMBRE_ARCHIVO { get; set; }
        [Description("EXTENSION")]
        public String EXTENSION { get; set; }
        //
        [Description("COD_PERSONA")]
        public String COD_PERSONA { get; set; }
        [Description("N_DOCUMENTO")]
        public String N_DOCUMENTO { get; set; }
        [Description("APELLIDOS_NOMBRES")]
        public String APELLIDOS_NOMBRES { get; set; }
        [Description("NOMBRES_APELLIDOS")]
        public String NOMBRES_APELLIDOS { get; set; }
        [Description("COD_INSTITUCION")]
        public String COD_INSTITUCION { get; set; }
        [Description("NOM_INSTITUCION")]
        public String NOM_INSTITUCION { get; set; }
        [Description("CARGO")]
        public String CARGO { get; set; }
        [Description("GENERO")]
        public String GENERO { get; set; }
        [Description("TELEFONO")]
        public String TELEFONO { get; set; }
        [Description("CORREO")]
        public String CORREO { get; set; }
        [Description("COD_CONSTANCIA")]
        public String COD_CONSTANCIA { get; set; }
        [Description("FUNCION")]
        public String FUNCION { get; set; }
        //
        [Description("CODIGO")]
        public String CODIGO { get; set; }
        [Description("DESCRIPCION")]
        public String DESCRIPCION { get; set; }
        [Description("GRUPO")]
        public String GRUPO { get; set; }
        //
        [Description("MAE_COD_TIPOENCUESTA")]
        public String MAE_COD_TIPOENCUESTA { get; set; }
        [Description("COD_PREGUNTA")]
        public String COD_PREGUNTA { get; set; }
        [Description("DES_PREGUNTA")]
        public String DES_PREGUNTA { get; set; }
        //[Description("COD_RESPUESTA")]
        //public String COD_RESPUESTA { get; set; }
        //[Description("DES_RESPUESTA")]
        //public String DES_RESPUESTA { get; set; }
        //Capacitación Encuesta
        [Description("N_CHECK_BUENO")]
        public Int32 N_CHECK_BUENO { get; set; }
        [Description("P_CHECK_BUENO")]
        public decimal P_CHECK_BUENO { get; set; }
        [Description("N_CHECK_REGULAR")]
        public Int32 N_CHECK_REGULAR { get; set; }
        [Description("P_CHECK_REGULAR")]
        public decimal P_CHECK_REGULAR { get; set; }
        [Description("N_CHECK_MALO")]
        public Int32 N_CHECK_MALO { get; set; }
        [Description("P_CHECK_MALO")]
        public decimal P_CHECK_MALO { get; set; }
        [Description("N_NO_CHECK")]
        public Int32 N_NO_CHECK { get; set; }
        [Description("P_NO_CHECK")]
        public decimal P_NO_CHECK { get; set; }
        //Capacitacion Evaluación
        [Description("NOTA_EXA_INICIO")]
        public decimal NOTA_EXA_INICIO { get; set; }
        [Description("NOTA_EXA_FIN")]
        public decimal NOTA_EXA_FIN { get; set; }
        //Capacitación Aporte
        [Description("APORTE")]
        public string APORTE { get; set; }
        //
        //[Description("NRO_ENCUESTA_ANONIMA")]
        //public int NRO_ENCUESTA_ANONIMA { get; set; }
        //[Description("NRO_PREGUNTAS")]
        //public int NRO_PREGUNTAS { get; set; }
        //[Description("NRO_PREGUNTAS_SIN")]
        //public int NRO_PREGUNTAS_SIN { get; set; }
        //
        [Description("COD_MARCO_CONVENIO")]
        public String COD_MARCO_CONVENIO { get; set; }
        [Description("MAE_GRUPO_CONVENIO")]
        public String MAE_GRUPO_CONVENIO { get; set; }
        [Description("MARCO_CONVENIO")]
        public object MARCO_CONVENIO { get; set; }
        [Description("EDAD")]
        public Int32 EDAD { get; set; }
        [Description("COD_PUBLICO_OBJETIVO")]
        public String COD_PUBLICO_OBJETIVO { get; set; }
        [Description("DESCRIPCION_PUBLICO")]
        public String DESCRIPCION_PUBLICO { get; set; }
        //
        [Description("APE_MATERNO")]
        public String APE_MATERNO { get; set; }
        [Description("APE_PATERNO")]
        public String APE_PATERNO { get; set; }
        [Description("NOMBRES")]
        public String NOMBRES { get; set; }

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
        [Description("RegNum_Orden")]
        public Int32 RegNum_Orden { get; set; }

        [Description("v_currentpage")]
        public Int32 v_currentpage { get; set; }

        [Description("v_pagesize")]
        public Int32 v_pagesize { get; set; }

        //CREITERIOS PARA BUSCAR 
        [Description("BusModalidad")]
        public String BusModalidad { get; set; }
        [Description("BusOD")]
        public String BusOD { get; set; }
        [Description("BusDepartamento")]
        public String BusDepartamento { get; set; }

        [Description("BusTitulo")]
        public String BusTitulo { get; set; }
        [Description("BusTitular")]
        public String BusTitular { get; set; }

        [Description("USUARIO_REGISTRO")]
        public String USUARIO_REGISTRO { get; set; }
        [Description("USUARIO_CONTROL")]
        public String USUARIO_CONTROL { get; set; }

        //03/04/2018 - THabilitante Participante
        [Description("COD_THABILITANTE")]
        public String COD_THABILITANTE { get; set; }
        [Description("NUM_THABILITANTE")]
        public String NUM_THABILITANTE { get; set; }

        [Description("COD_CONSTANCIA_CAP")]
        public String COD_CONSTANCIA_CAP { get; set; }

        public String NRO_CONSTANCIA { get; set; }

        //Lista Objetos
        [Category("LIST"), Description("ListMComboOD")]
        public List<Ent_CAPACITACION> ListMComboOD { get; set; }
        //[Category("LIST"), Description("ListMComboRespuestas")]
        //public List<Ent_CAPACITACION> ListMComboRespuestas { get; set; }
        [Category("LIST"), Description("ListMComboDIdentidad")]
        public List<Ent_CAPACITACION> ListMComboDIdentidad { get; set; }
        [Category("LIST"), Description("ListMComboTipoCapacitacion")]
        public List<Ent_CAPACITACION> ListMComboTipoCapacitacion { get; set; }
        [Category("LIST"), Description("ListTDCapacitacion")]
        public List<Ent_CAPACITACION> ListTDCapacitacion { get; set; }
        [Category("LIST"), Description("ListParticipantes")]
        public List<Ent_CAPACITACION> ListParticipantes { get; set; }
        [Category("LIST"), Description("ListParticipantesOsi")]
        public List<Ent_CAPACITACION> ListParticipantesOsi { get; set; }
        [Category("LIST"), Description("ListParticipantesPonente")]
        public List<Ent_CAPACITACION> ListParticipantesPonente { get; set; }
        [Category("LIST"), Description("ListIndicador")]
        public List<Ent_CAPACITACION> ListIndicador { get; set; }
        [Category("LIST"), Description("ListInstituciones")]
        public List<Ent_CAPACITACION> ListInstituciones { get; set; }
        //[Category("LIST"), Description("ListConvenios")]
        //public List<Ent_CAPACITACION> ListConvenios { get; set; }
        [Category("LIST"), Description("ListCapacitacionConvenios")]
        public List<Ent_CAPACITACION> ListCapacitacionConvenios { get; set; }
        //[Category("LIST"), Description("ListEncuestasPart")]
        //public List<List<Ent_CAPACITACION>> ListEncuestasPart { get; set; }
        [Category("LIST"), Description("ListPublicoObjetivo")]
        public List<Ent_CAPACITACION> ListPublicoObjetivo { get; set; }
        [Category("LIST"), Description("ListMComboDireccionLinea")]
        public List<Ent_CAPACITACION> ListMComboDireccionLinea { get; set; }
        [Category("LIST"), Description("ListMComboOrganizador")]
        public List<Ent_CAPACITACION> ListMComboOrganizador { get; set; }
        [Category("LIST"), Description("ListConveniosAFF")]
        public List<Ent_CAPACITACION> ListConveniosAFF { get; set; }
        [Category("LIST"), Description("ListConveniosOI")]
        public List<Ent_CAPACITACION> ListConveniosOI { get; set; }
        [Category("LIST"), Description("ListConveniosOIA")]
        public List<Ent_CAPACITACION> ListConveniosOIA { get; set; }
        [Category("LIST"), Description("ListMComboConvenios")]
        public List<Ent_CAPACITACION> ListMComboConvenios { get; set; }
        [Category("LIST"), Description("ListApoyoCoorg")]
        public List<Ent_CAPACITACION> ListApoyoCoorg { get; set; }
        [Category("LIST"), Description("ListTitularesTitHab")]
        public List<Ent_CAPACITACION> ListTitularesTitHab { get; set; }
        [Category("LIST"), Description("ListRepresentantesOrgAso")]
        public List<Ent_CAPACITACION> ListRepresentantesOrgAso { get; set; }
        [Category("LIST"), Description("ListConsultoresRegMat")]
        public List<Ent_CAPACITACION> ListConsultoresRegMat { get; set; }

        [Category("LIST"), Description("ListEncuestas")]
        public List<Ent_CAPACITACION> ListEncuestas { get; set; }
        [Category("LIST"), Description("ListEvaluaciones")]
        public List<Ent_CAPACITACION> ListEvaluaciones { get; set; }
        [Category("LIST"), Description("ListAportes")]
        public List<Ent_CAPACITACION> ListAportes { get; set; }
        [Category("LIST"), Description("ListEvaInicial")]
        public List<Ent_CAPACITACION> ListEvaInicial { get; set; }
        [Category("LIST"), Description("ListEvaFinal")]
        public List<Ent_CAPACITACION> ListEvaFinal { get; set; }

        [Category("LIST"), Description("ListTematica")]
        public List<Ent_CAPACITACION> ListTematica { get; set; }
        [Category("LIST"), Description("ListMComboMetodologia")]
        public List<Ent_CAPACITACION> ListMComboMetodologia { get; set; }
        [Category("LIST"), Description("ListMChkListTematica")]
        public List<Ent_CAPACITACION> ListMChkListTematica { get; set; }
        [Category("LIST"), Description("ListMComboCCNN")]
        public List<Ent_CAPACITACION> ListMComboCCNN { get; set; }
        [Category("LIST"), Description("ListMComboEtnia")]
        public List<Ent_CAPACITACION> ListMComboEtnia { get; set; }

        [Category("LIST"), Description("ListMComboCapacitacionPendiente")]
        public List<Ent_CAPACITACION> ListMComboCapacitacionPendiente { get; set; }
        [Category("LIST"), Description("ListMComboTipoAdjunto")]
        public List<Ent_CAPACITACION> ListMComboTipoAdjunto { get; set; }

        [Category("LIST"), Description("ListMComboModalidad")]
        public List<Ent_CAPACITACION> ListMComboModalidad { get; set; }

        [Category("LIST"), Description("ListProgramacion")]
        public List<Ent_CAPACITACION> ListProgramacion { get; set; }

        [Category("LIST"), Description("ListCronograma")]
        public List<Ent_CAPACITACION> ListCronograma { get; set; }

        //TemEliminar
        [Description("EliTABLA")]
        public String EliTABLA { get; set; }
        [Description("EliVALOR01")]
        public String EliVALOR01 { get; set; }
        [Description("EliVALOR02")]
        public Int32 EliVALOR02 { get; set; }
        [Description("EliVALOR03")]
        public String EliVALOR03 { get; set; }
        [Category("LIST"), Description("ListEliTABLA")]
        public List<Ent_CAPACITACION> ListEliTABLA { get; set; }

        [Description("ROW_INDEX")]
        public Int32 ROW_INDEX { get; set; }
        [Description("URL")]
        public String URL { get; set; }
        [Description("TIPO_REPORTE")]
        public String TIPO_REPORTE { get; set; }
        [Description("ANIO")]
        public String ANIO { get; set; }
        [Description("MES")]
        public String MES { get; set; }
        [Description("POI")]
        public String POI { get; set; }
        [Description("MAE_ENT_FINANCIA")]
        public String MAE_ENT_FINANCIA { get; set; }
        [Description("MAE_COD_TIPOADJUNTO")]
        public String MAE_COD_TIPOADJUNTO { get; set; }
        [Description("TIPO_ADJUNTO")]
        public String TIPO_ADJUNTO { get; set; }
        [Description("MAE_GRUPO_PUBLICO")]
        public String MAE_GRUPO_PUBLICO { get; set; }

        [Description("COD_MTIPO")]
        public String COD_MTIPO { get; set; }
        [Description("MAE_COD_GRUPOPUBLICOPARTICIPANTE")]
        public String MAE_COD_GRUPOPUBLICOPARTICIPANTE { get; set; }
        [Description("GRUPOPUBLICOPARTICIPANTE")]
        public String GRUPOPUBLICOPARTICIPANTE { get; set; }
        [Description("MAE_COD_PUBLICOPARTICIPANTE")]
        public String MAE_COD_PUBLICOPARTICIPANTE { get; set; }
        [Description("PUBLICOPARTICIPANTE")]
        public String PUBLICOPARTICIPANTE { get; set; }
        //TGS: 16-12-2022
        [Description("MOCHILAFORESTAL")]
        public String MOCHILAFORESTAL { get; set; }

        [Category("LIST"), Description("ListPublicoParticipante")]
        public List<Ent_CAPACITACION> ListPublicoParticipante { get; set; }

        [Category("LIST"), Description("ListCapacitacionPrograma")]
        public List<Ent_CAPACITACION> ListCapacitacionPrograma { get; set; }
        [Category("LIST"), Description("ListCapacitacionCronograma")]
        public List<Ent_CAPACITACION> ListCapacitacionCronograma { get; set; }

        [Description("NUEVO_2021")]
        public String NUEVO_2021 { get; set; }
        [Category("FECHA"), Description("FECHA_CREACION")]
        public Object FECHA_CREACION { get; set; }
        #endregion



        #region "Constructor"
        public Ent_CAPACITACION()
        {
            //
            ANO = -1;
            COD_SECUENCIAL = -1;
            EliVALOR02 = -1;
            N_PARTICIPANTES = -1;
            //NRO_ENCUESTA_ANONIMA = -1;
            //NRO_PREGUNTAS = -1;
            //NRO_PREGUNTAS_SIN = -1;
            EDAD = -1;
            DURACION = -1;
            N_CHECK_BUENO = -1;
            N_CHECK_MALO = -1;
            N_CHECK_REGULAR = -1;
            P_CHECK_BUENO = -1;
            P_CHECK_MALO = -1;
            P_CHECK_REGULAR = -1;
            NOTA_EXA_FIN = -1;
            NOTA_EXA_INICIO = -1;
            //
            RegEstado = -1;
            RegNum_Orden = -1;
            COORD_ESTE = -1;
            COORD_NORTE = -1;
            N_NO_CHECK = -1;
            P_NO_CHECK = -1;

            ROW_INDEX = -1;
            v_currentpage = -1;
            v_pagesize = -1;
        }
        #endregion

    }
}
