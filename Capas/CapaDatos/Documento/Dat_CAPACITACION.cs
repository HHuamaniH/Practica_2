using CapaEntidad.DOC;
using CapaEntidad.ViewModel;
using GeneralSQL;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;   //using System.Data.SqlClient;
using CEntidad = CapaEntidad.DOC.Ent_CAPACITACION;
using CEntidadPDC = CapaEntidad.DOC.Ent_ReportePDC;
using SQL = GeneralSQL.Data.SQL;

namespace CapaDatos.DOC
{
    public class Dat_CAPACITACION
    {
        private SQL oGDataSQL = new SQL();

        private DBOracle dBOracle = new DBOracle();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public CEntidad RegMostrarListaItems(OracleConnection cn, CEntidad oCEntidad)
        {
            CEntidad oCampos = new CEntidad();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spCAPACITACIONMostItems", oCEntidad))
                {
                    if (dr != null)
                    {
                        oCampos.ListMComboDIdentidad = new List<CEntidad>();
                        oCampos.ListMComboOD = new List<CEntidad>();
                        //oCampos.ListMComboRespuestas = new List<CEntidad>();
                        oCampos.ListMComboTipoCapacitacion = new List<CEntidad>();
                        oCampos.ListTDCapacitacion = new List<CEntidad>();
                        oCampos.ListParticipantes = new List<CEntidad>();
                        oCampos.ListParticipantesOsi = new List<CEntidad>();
                        oCampos.ListParticipantesPonente = new List<CEntidad>();
                        oCampos.ListEliTABLA = new List<CEntidad>();
                        //oCampos.ListEncuestasPart = new List<List<CEntidad>>();
                        oCampos.ListCapacitacionConvenios = new List<CEntidad>();
                        oCampos.ListPublicoObjetivo = new List<CEntidad>();
                        oCampos.ListEncuestas = new List<CEntidad>();
                        oCampos.ListEvaluaciones = new List<CEntidad>();
                        oCampos.ListAportes = new List<CEntidad>();
                        oCampos.ListTematica = new List<CEntidad>();
                        oCampos.ListEvaInicial = new List<CEntidad>();
                        oCampos.ListEvaFinal = new List<CEntidad>();
                        oCampos.ListMComboModalidad = new List<CEntidad>();
                        oCampos.ListProgramacion = new List<CEntidad>();
                        oCampos.ListCronograma = new List<CEntidad>();

                        CEntidad oCamposDet;
                        //
                        if (dr.HasRows)
                        {
                            dr.Read();
                            oCampos.COD_CAPACITACION = dr.GetString(dr.GetOrdinal("COD_CAPACITACION"));
                            oCampos.NOMBRE = dr.GetString(dr.GetOrdinal("NOMBRE"));
                            oCampos.COD_CAPATIPO = dr.GetString(dr.GetOrdinal("COD_CAPATIPO"));
                            oCampos.COD_OD = dr.GetString(dr.GetOrdinal("COD_OD"));
                            oCampos.COD_DLINEA = dr.GetString(dr.GetOrdinal("COD_DLINEA"));
                            oCampos.COD_UBIGEO = dr.GetString(dr.GetOrdinal("COD_UBIGEO"));
                            oCampos.UBIGEO_DESCRIPCION = dr.GetString(dr.GetOrdinal("UBIGEO_DESCRIPCION"));
                            oCampos.SECTOR = dr.GetString(dr.GetOrdinal("SECTOR"));
                            oCampos.LUGAR = dr.GetString(dr.GetOrdinal("LUGAR"));
                            oCampos.FECHA_INICIO = dr.GetString(dr.GetOrdinal("FECHA_INICIO"));
                            oCampos.FECHA_TERMINO = dr.GetString(dr.GetOrdinal("FECHA_TERMINO"));
                            oCampos.N_PARTICIPANTES = dr.GetInt32(dr.GetOrdinal("N_PARTICIPANTES"));
                            oCampos.MARCO_CONVENIO = dr.GetBoolean(dr.GetOrdinal("MARCO_CONVENIO"));
                            oCampos.OBSERVACION = dr.GetString(dr.GetOrdinal("OBSERVACION"));
                            oCampos.DURACION = dr.GetInt32(dr.GetOrdinal("DURACION"));
                            oCampos.MAE_COD_ORGANIZADOR = dr.GetString(dr.GetOrdinal("MAE_COD_ORGANIZADOR"));
                            oCampos.ORGANIZADOR = dr.GetString(dr.GetOrdinal("ORGANIZADOR"));
                            oCampos.APOYO_COORGANIZ_DIFUSION = dr.GetBoolean(dr.GetOrdinal("APOYO_COORGANIZ_DIFUSION"));
                            oCampos.APOYO_COORGANIZ_FIRMA = dr.GetBoolean(dr.GetOrdinal("APOYO_COORGANIZ_FIRMA"));
                            oCampos.APOYO_COORGANIZ_LOGISTICO = dr.GetBoolean(dr.GetOrdinal("APOYO_COORGANIZ_LOGISTICO"));

                            oCampos.OBJETIVO = dr.GetString(dr.GetOrdinal("OBJETIVO"));
                            oCampos.DESCRIPCION_TEMAS = dr.GetString(dr.GetOrdinal("DESCRIPCION_TEMAS"));
                            oCampos.MAE_COD_METODO = dr.GetString(dr.GetOrdinal("MAE_COD_METODO"));
                            oCampos.OBSERVACION_METODO = dr.GetString(dr.GetOrdinal("OBSERVACION_METODO"));
                            oCampos.CONCLUSION = dr.GetString(dr.GetOrdinal("CONCLUSION"));
                            oCampos.SUMA_POI = dr.GetBoolean(dr.GetOrdinal("SUMA_POI"));
                            oCampos.ZONA_UTM = dr.GetString(dr.GetOrdinal("ZONA_UTM"));
                            oCampos.COORD_ESTE = dr.GetInt32(dr.GetOrdinal("COORD_ESTE"));
                            oCampos.COORD_NORTE = dr.GetInt32(dr.GetOrdinal("COORD_NORTE"));
                            oCampos.USUARIO_REGISTRO = dr.GetString(dr.GetOrdinal("USUARIO_REGISTRO"));

                            oCampos.ANTECEDENTES = dr.GetString(dr.GetOrdinal("ANTECEDENTES"));
                            oCampos.JUSTIFICACION = dr.GetString(dr.GetOrdinal("JUSTIFICACION"));
                            oCampos.RESULTADOS_ESPERADOS = dr.GetString(dr.GetOrdinal("RESULTADOS_ESPERADOS"));
                            oCampos.COD_MODALIDAD = dr.GetString(dr.GetOrdinal("COD_MODALIDAD"));
                            oCampos.MATERIALES_EQUIPO = dr.GetString(dr.GetOrdinal("MATERIALES_EQUIPO"));
                            oCampos.PUBLICO_OBJETIVO = dr.GetString(dr.GetOrdinal("PUBLICO_OBJETIVO"));
                            oCampos.CRONOGRAMA = dr.GetString(dr.GetOrdinal("CRONOGRAMA"));
                            oCampos.PROGRAMA = dr.GetString(dr.GetOrdinal("PROGRAMA"));

                            oCampos.PRESENTACION = dr.GetString(dr.GetOrdinal("PRESENTACION"));
                            oCampos.DESCRIPCION_EJECUTIVA = dr.GetString(dr.GetOrdinal("DESCRIPCION_EJECUTIVA"));
                            oCampos.RESUMEN_INTERVENCIONES = dr.GetString(dr.GetOrdinal("RESUMEN_INTERVENCIONES"));
                            oCampos.DESCRIPCION_TRABAJO = dr.GetString(dr.GetOrdinal("DESCRIPCION_TRABAJO"));
                            oCampos.RECOMENDACIONES = dr.GetString(dr.GetOrdinal("RECOMENDACIONES"));
                            oCampos.FECHA_CREACION = dr.GetString(dr.GetOrdinal("FECHA_CREACION"));
                        }
                        //2 Estado (Calidad)
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            dr.Read();
                            oCampos.COD_ESTADO_DOC = dr.GetString(dr.GetOrdinal("COD_ESTADO_DOC"));
                            oCampos.OBSERVACIONES_CONTROL = dr.GetString(dr.GetOrdinal("OBSERVACIONES_CONTROL"));
                            oCampos.OBSERV_SUBSANAR = dr.GetBoolean(dr.GetOrdinal("OBSERV_SUBSANAR"));
                            oCampos.USUARIO_CONTROL = dr.GetString(dr.GetOrdinal("USUARIO_CONTROL"));

                        }
                        else
                        {
                            oCampos.COD_ESTADO_DOC = "";
                            oCampos.OBSERVACIONES_CONTROL = "";
                            oCampos.OBSERV_SUBSANAR = false;
                            oCampos.USUARIO_CONTROL = "";
                        }
                        //3 CAPACITACION_DETALLE
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.COD_CAPACITACION = dr.GetString(dr.GetOrdinal("COD_CAPACITACION"));
                                oCamposDet.COD_SECUENCIAL = dr.GetInt32(dr.GetOrdinal("COD_SECUENCIAL"));
                                oCamposDet.NOMBRE_ARCHIVO = dr.GetString(dr.GetOrdinal("NOMBRE_ARCHIVO"));
                                oCamposDet.EXTENSION = dr.GetString(dr.GetOrdinal("EXTENSION"));
                                oCamposDet.MAE_COD_TIPOADJUNTO = dr.GetString(dr.GetOrdinal("MAE_COD_TIPOADJUNTO"));
                                oCamposDet.TIPO_ADJUNTO = dr.GetString(dr.GetOrdinal("TIPO_ADJUNTO"));
                                oCamposDet.OBSERVACION = dr.GetString(dr.GetOrdinal("OBSERVACION"));
                                oCamposDet.RegEstado = 0;
                                oCampos.ListTDCapacitacion.Add(oCamposDet);
                            }
                        }
                        //4 CAPACITACION_PARTICIPANTES
                        #region
                        dr.NextResult();

                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.COD_PERSONA = dr["COD_PERSONA"].ToString();
                                oCamposDet.N_DOCUMENTO = dr["N_DOCUMENTO"].ToString();
                                oCamposDet.APE_PATERNO = dr["APE_PATERNO"].ToString();
                                oCamposDet.APE_MATERNO = dr["APE_MATERNO"].ToString();
                                oCamposDet.NOMBRES = dr["NOMBRES"].ToString();
                                oCamposDet.APELLIDOS_NOMBRES = dr["APELLIDOS_NOMBRES"].ToString();
                                oCamposDet.COD_INSTITUCION = dr["COD_INSTITUCION"].ToString();
                                oCamposDet.NOM_INSTITUCION = dr["NOM_INSTITUCION"].ToString();
                                oCamposDet.CARGO = dr["CARGO"].ToString();
                                oCamposDet.GENERO = dr["GENERO"].ToString();
                                oCamposDet.EDAD = int.Parse(dr["EDAD"].ToString());
                                oCamposDet.TELEFONO = dr["TELEFONO"].ToString();
                                oCamposDet.CORREO = dr["CORREO"].ToString();
                                oCamposDet.OBSERVACION = dr["OBSERVACION"].ToString();
                                oCamposDet.COD_CONSTANCIA = dr["COD_CONSTANCIA"].ToString();
                                oCamposDet.FUNCION = dr["FUNCION"].ToString();
                                oCamposDet.COD_CCNN = dr.GetString(dr.GetOrdinal("COD_CCNN"));
                                oCamposDet.CCNN = dr.GetString(dr.GetOrdinal("CCNN"));
                                oCamposDet.ETNIA = dr.GetString(dr.GetOrdinal("ETNIA"));
                                oCamposDet.MAE_COD_TIPOPARTICIPANTE = dr.GetString(dr.GetOrdinal("MAE_COD_TIPOPARTICIPANTE"));
                                oCamposDet.COD_THABILITANTE = dr.GetString(dr.GetOrdinal("COD_THABILITANTE"));
                                oCamposDet.NUM_THABILITANTE = dr.GetString(dr.GetOrdinal("NUM_THABILITANTE"));
                                oCamposDet.MAE_COD_GRUPOPUBLICOPARTICIPANTE = dr.GetString(dr.GetOrdinal("MAE_COD_GRUPOPUBLICOPARTICIPANTE"));
                                oCamposDet.GRUPOPUBLICOPARTICIPANTE = dr.GetString(dr.GetOrdinal("GRUPOPUBLICOPARTICIPANTE"));
                                oCamposDet.MAE_COD_PUBLICOPARTICIPANTE = dr.GetString(dr.GetOrdinal("MAE_COD_PUBLICOPARTICIPANTE"));
                                oCamposDet.PUBLICOPARTICIPANTE = dr.GetString(dr.GetOrdinal("PUBLICOPARTICIPANTE"));
                                oCamposDet.FECHA_CREACION = dr.GetString(dr.GetOrdinal("FECHA_CREACION"));
                                oCamposDet.MOCHILAFORESTAL = dr.GetString(dr.GetOrdinal("MOCHILAFORESTAL"));
                                oCamposDet.RegEstado = 0;

                                switch (oCamposDet.MAE_COD_TIPOPARTICIPANTE)
                                {
                                    case "0000016"://Participante normal
                                        oCampos.ListParticipantes.Add(oCamposDet);
                                        break;
                                    case "0000017"://Participante OSINFOR
                                        oCampos.ListParticipantesOsi.Add(oCamposDet);
                                        break;
                                    case "0000018"://Participante Ponente
                                        oCampos.ListParticipantesPonente.Add(oCamposDet);
                                        break;
                                }
                            }
                        }
                        #endregion
                        #region [LENIEAS COMENTADAS]
                        //CAPACITACION_ENCUESTAS
                        /*
						dr.NextResult();
						if (dr.HasRows)
						{
							List<CEntidad> oCamposList = new List<CEntidad>();
							int pt1 = dr.GetOrdinal("COD_PERSONA");
							int pt2 = dr.GetOrdinal("COD_INSTITUCION");
							int pt3 = dr.GetOrdinal("COD_PREGUNTA");
							int pt4 = dr.GetOrdinal("COD_RESPUESTA");
							int pt5 = dr.GetOrdinal("RESPUESTA_DETALLE");
							int i = 0;
							oCampos.ListEncuestasPart = new List<List<CEntidad>>(oCampos.ListParticipantes.Count());
							while (dr.Read())
							{
								oCamposDet = new CEntidad();
								oCampos.ListEncuestasPart.Add(oCamposList);
								oCamposDet.COD_PERSONA = dr.GetString(pt1);
								oCamposDet.COD_INSTITUCION = dr.GetString(pt2);   
								if ((oCampos.ListParticipantes[i].COD_PERSONA == oCamposDet.COD_PERSONA) && (oCampos.ListParticipantes[i].COD_INSTITUCION == oCamposDet.COD_INSTITUCION))
									{
										oCamposDet.COD_PREGUNTA = dr.GetString(pt3);
										oCamposDet.COD_RESPUESTA = dr.GetString(pt4);
										oCamposDet.DES_RESPUESTA = dr.GetString(pt5);
										oCamposDet.RegEstado = 0;                                        
										oCampos.ListEncuestasPart[i].Add(oCamposDet);
									}
									else
									{
										i++;
										oCampos.ListEncuestasPart.Add(oCamposList);
										oCampos.ListEncuestasPart[i] = new List<CEntidad>();
										oCamposDet.COD_PERSONA = dr.GetString(pt1);
										oCamposDet.COD_INSTITUCION = dr.GetString(pt2);
										oCamposDet.COD_PREGUNTA = dr.GetString(pt3);
										oCamposDet.COD_RESPUESTA = dr.GetString(pt4);
										oCamposDet.DES_RESPUESTA = dr.GetString(pt5);
										oCamposDet.RegEstado = 0;
										oCampos.ListEncuestasPart[i].Add(oCamposDet);                                        
									}                               
							}
						}
						*/

                        ////CAPACITACION_ENCUESTAS_ANONIMAS
                        //dr.NextResult();
                        //if (dr.HasRows)
                        //{
                        //    List<CEntidad> oCamposList = new List<CEntidad>();
                        //    int pt1 = dr.GetOrdinal("NRO_ENCUESTA_ANONIMA");
                        //    int pt2 = dr.GetOrdinal("COD_PREGUNTA");
                        //    int pt3 = dr.GetOrdinal("COD_RESPUESTA");
                        //    int pt4 = dr.GetOrdinal("RESPUESTA_DETALLE");
                        //    int pt5 = dr.GetOrdinal("NRO_PREGUNTAS");
                        //    int pt6 = dr.GetOrdinal("NRO_PREGUNTAS_SIN");
                        //    int i = 0;
                        //    int j = 0;
                        //    oCampos.ListEncuestasPart = new List<List<CEntidad>>(oCampos.N_PARTICIPANTES);
                        //    oCampos.ListEncuestasPart.Add(oCamposList);
                        //    while (dr.Read())
                        //    {
                        //        oCamposDet = new CEntidad();

                        //        oCamposDet.NRO_ENCUESTA_ANONIMA = dr.GetInt32(pt1);
                        //        oCamposDet.NRO_PREGUNTAS = dr.GetInt32(pt5);
                        //        oCamposDet.NRO_PREGUNTAS_SIN = dr.GetInt32(pt6);
                        //        if (j<8)
                        //        {
                        //            oCamposDet.COD_PREGUNTA = dr.GetString(pt2);
                        //            oCamposDet.COD_RESPUESTA = dr.GetString(pt3);
                        //            oCamposDet.DES_RESPUESTA = dr.GetString(pt4);
                        //            oCamposDet.RegEstado = 0;
                        //            oCampos.ListEncuestasPart[i].Add(oCamposDet);
                        //            j++;
                        //        }
                        //        else
                        //        {
                        //            i++;
                        //            oCampos.ListEncuestasPart.Add(oCamposList);
                        //            oCampos.ListEncuestasPart[i] = new List<CEntidad>();
                        //            oCamposDet.NRO_ENCUESTA_ANONIMA = dr.GetInt32(pt1);
                        //            oCamposDet.COD_PREGUNTA = dr.GetString(pt2);
                        //            oCamposDet.COD_RESPUESTA = dr.GetString(pt3);
                        //            oCamposDet.DES_RESPUESTA = dr.GetString(pt4);
                        //            oCamposDet.NRO_PREGUNTAS = dr.GetInt32(pt5);
                        //            oCamposDet.NRO_PREGUNTAS_SIN = dr.GetInt32(pt6);
                        //            oCamposDet.RegEstado = 0;
                        //            oCampos.ListEncuestasPart[i].Add(oCamposDet);
                        //            j = 1;
                        //        }
                        //    }
                        //}
                        #endregion
                        //5 CAPACITACION_CONVENIOS
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.COD_MARCO_CONVENIO = dr["COD_MARCO_CONVENIO"].ToString();
                                oCamposDet.MAE_GRUPO_CONVENIO = dr["MAE_GRUPO_CONVENIO"].ToString();
                                oCampos.ListCapacitacionConvenios.Add(oCamposDet);
                            }

                        }
                        //6 CAPACITACION_PUBLICO_OBJETIVO
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.COD_PUBLICO_OBJETIVO = dr["COD_PUBLICO_OBJETIVO"].ToString();
                                oCamposDet.DESCRIPCION_PUBLICO = dr["DESCRIPCION_PUBLICO"].ToString();
                                oCampos.ListPublicoObjetivo.Add(oCamposDet);
                            }

                        }
                        //CAPACITACION_ENCUESTA
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.COD_PREGUNTA = dr["COD_PREGUNTA"].ToString();
                                oCamposDet.DES_PREGUNTA = dr["PREGUNTA"].ToString();
                                oCamposDet.N_CHECK_BUENO = int.Parse(dr["N_CHECK_BUENO"].ToString());
                                oCamposDet.P_CHECK_BUENO = decimal.Parse(dr["P_CHECK_BUENO"].ToString());
                                oCamposDet.N_CHECK_REGULAR = int.Parse(dr["N_CHECK_REGULAR"].ToString());
                                oCamposDet.P_CHECK_REGULAR = decimal.Parse(dr["P_CHECK_REGULAR"].ToString());
                                oCamposDet.N_CHECK_MALO = int.Parse(dr["N_CHECK_MALO"].ToString());
                                oCamposDet.P_CHECK_MALO = decimal.Parse(dr["P_CHECK_MALO"].ToString());
                                oCamposDet.N_PARTICIPANTES = int.Parse(dr["N_RESPUESTA"].ToString());
                                oCamposDet.N_NO_CHECK = dr.GetInt32(dr.GetOrdinal("N_NO_CHECK"));
                                oCamposDet.P_NO_CHECK = dr.GetDecimal(dr.GetOrdinal("P_NO_CHECK"));
                                oCamposDet.MAE_COD_TIPOENCUESTA = dr.GetString(dr.GetOrdinal("MAE_COD_TIPOENCUESTA"));
                                oCamposDet.RegEstado = 0;

                                switch (oCamposDet.MAE_COD_TIPOENCUESTA)
                                {
                                    case "0000039"://Encuesta
                                        oCampos.ListEncuestas.Add(oCamposDet);
                                        break;
                                    case "0000040"://Evaluación Inicial
                                        oCampos.ListEvaInicial.Add(oCamposDet);
                                        break;
                                    case "0000041"://Evaluación Final
                                        oCampos.ListEvaFinal.Add(oCamposDet);
                                        break;
                                }
                            }
                        }
                        //CAPACITACION_EVALUACION (Examen)
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.COD_PERSONA = dr["COD_PERSONA"].ToString();
                                oCamposDet.N_DOCUMENTO = dr["N_DOCUMENTO"].ToString();
                                oCamposDet.APE_PATERNO = dr["APE_PATERNO"].ToString();
                                oCamposDet.APE_MATERNO = dr["APE_MATERNO"].ToString();
                                oCamposDet.NOMBRES = dr["NOMBRES"].ToString();
                                oCamposDet.APELLIDOS_NOMBRES = dr["APELLIDOS_NOMBRES"].ToString();
                                oCamposDet.NOM_INSTITUCION = dr["NOM_INSTITUCION"].ToString();
                                oCamposDet.NOTA_EXA_INICIO = decimal.Parse(dr["NOTA_EXA_INICIO"].ToString());
                                oCamposDet.NOTA_EXA_FIN = decimal.Parse(dr["NOTA_EXA_FIN"].ToString());
                                oCamposDet.RegEstado = 0;
                                oCampos.ListEvaluaciones.Add(oCamposDet);
                            }
                        }
                        //CAPACITACION_APORTE
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.COD_PERSONA = dr["COD_PERSONA"].ToString();
                                oCamposDet.N_DOCUMENTO = dr["N_DOCUMENTO"].ToString();
                                oCamposDet.APE_PATERNO = dr["APE_PATERNO"].ToString();
                                oCamposDet.APE_MATERNO = dr["APE_MATERNO"].ToString();
                                oCamposDet.NOMBRES = dr["NOMBRES"].ToString();
                                oCamposDet.APELLIDOS_NOMBRES = dr["APELLIDOS_NOMBRES"].ToString();
                                oCamposDet.NOM_INSTITUCION = dr["NOM_INSTITUCION"].ToString();
                                oCamposDet.APORTE = dr["APORTE"].ToString();
                                oCamposDet.COD_SECUENCIAL = dr.GetInt32(dr.GetOrdinal("COD_SECUENCIAL"));
                                oCamposDet.RegEstado = 0;
                                oCampos.ListAportes.Add(oCamposDet);
                            }
                        }
                        //CAPACITACION_TEMATICA
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.COD_CAPACITACION = dr.GetString(dr.GetOrdinal("COD_CAPACITACION"));
                                oCamposDet.MAE_COD_TEMA = dr.GetString(dr.GetOrdinal("MAE_COD_TEMA"));
                                oCamposDet.DESCRIPCION = dr.GetString(dr.GetOrdinal("DESCRIPCION"));

                                oCampos.ListTematica.Add(oCamposDet);
                            }
                        }

                        //CAPACITACION_PROGRAMACION
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.COD_CAPACITACION = dr.GetString(dr.GetOrdinal("COD_CAPACITACION"));
                                oCamposDet.COD_SECUENCIAL = dr.GetInt32(dr.GetOrdinal("COD_SECUENCIAL"));
                                oCamposDet.FECHA_PROGRAMA = dr.GetString(dr.GetOrdinal("FECHA_PROGRAMA"));
                                oCamposDet.HORA = dr.GetString(dr.GetOrdinal("HORA"));
                                oCamposDet.TEMA = dr.GetString(dr.GetOrdinal("TEMA"));
                                oCamposDet.RESPONSABLE = dr.GetString(dr.GetOrdinal("RESPONSABLE"));
                                oCamposDet.RegEstado = 0;
                                oCampos.ListProgramacion.Add(oCamposDet);
                            }
                        }

                        //CAPACITACION_CRONOGRAMA
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.COD_CAPACITACION = dr.GetString(dr.GetOrdinal("COD_CAPACITACION"));
                                oCamposDet.COD_SECUENCIAL = dr.GetInt32(dr.GetOrdinal("COD_SECUENCIAL"));
                                oCamposDet.ACTIVIDAD = dr.GetString(dr.GetOrdinal("ACTIVIDAD"));
                                oCamposDet.FECHA_INICIO_CRONOGRAMA = dr.GetString(dr.GetOrdinal("FECHA_INICIO_CRONOGRAMA"));
                                oCamposDet.FECHA_FIN_CRONOGRAMA = dr.GetString(dr.GetOrdinal("FECHA_FIN_CRONOGRAMA"));
                                oCamposDet.RegEstado = 0;
                                oCampos.ListCronograma.Add(oCamposDet);
                            }
                        }
                    }
                }
                return oCampos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 
        /// </summary>, "DOC_OSINFOR_ERP_MIGRACION.sp
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public String RegGrabar(OracleConnection cn, CEntidad oCEntidad)
        {
            OracleTransaction tr = null;
            String OUTPUTPARAM01 = "";
            CEntidad oCamposDet;
            try
            {
                tr = cn.BeginTransaction();
                //Grabando Cabecera
                using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spCAPACITACIONGrabar", oCEntidad))
                {
                    cmd.ExecuteNonQuery();
                    OUTPUTPARAM01 = (String)cmd.Parameters["OUTPUTPARAM01"].Value;
                    if (OUTPUTPARAM01 == "100")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("El registro se encuentra con Control de Calidad Conforme, No se puede modificar el registro");
                    }
                    else if (OUTPUTPARAM01 == "99")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("Ud. no tiene permiso para realizar esta acción");
                    }
                    if (OUTPUTPARAM01 == "0")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("El Nombre de la Capacitación ya Existe");
                    }
                    else if (OUTPUTPARAM01 == "3")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("Este Control de Calidad no puede modificarse");
                    }
                    else if (OUTPUTPARAM01 == "2")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("No Tiene Permisos para Modificar este Registro");
                    }
                    else if (OUTPUTPARAM01 == "1")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("El Nombre de la Capacitación ya Existe");
                    }
                }
                //Reemplazando El Nuevo Codigo Creado
                if (oCEntidad.RegEstado == 1) //Nuevo
                {
                    oCEntidad.COD_CAPACITACION = OUTPUTPARAM01;
                }
                //
                //Eliminando Detalle
                if (oCEntidad.ListEliTABLA != null)
                {
                    foreach (var loDatos in oCEntidad.ListEliTABLA)
                    {
                        oCamposDet = new CEntidad();
                        oCamposDet.COD_CAPACITACION = oCEntidad.COD_CAPACITACION;
                        oCamposDet.EliTABLA = loDatos.EliTABLA;
                        oCamposDet.EliVALOR01 = loDatos.EliVALOR01;
                        oCamposDet.EliVALOR02 = loDatos.EliVALOR02;
                        oCamposDet.EliVALOR03 = loDatos.EliVALOR03;
                        dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spCAPACITACIONEliminarDetalle", oCamposDet);
                    }
                }
                //
                /*
				//Grabando Detalle CAPACITACION_DETALLE
				if (oCEntidad.ListTDCapacitacion != null)
				{
					foreach (var loDatos in oCEntidad.ListTDCapacitacion)
					{
						if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
						{
							oCamposDet = new CEntidad();
							oCamposDet.COD_CAPACITACION = oCEntidad.COD_CAPACITACION;
							oCamposDet.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
							oCamposDet.NOMBRE_ARCHIVO = loDatos.NOMBRE_ARCHIVO;
							oCamposDet.EXTENSION = loDatos.EXTENSION;
							oCamposDet.RegEstado = loDatos.RegEstado;
							dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spCAPACITACION_DETALLE_Grabar", oCamposDet);
						}
					}
				}*/

                List<CEntidad> olParticipantesGeneral = new List<CEntidad>();
                if (oCEntidad.ListParticipantes != null)
                {
                    foreach (var loDatos in oCEntidad.ListParticipantes)
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            loDatos.MAE_COD_TIPOPARTICIPANTE = "0000016";
                            olParticipantesGeneral.Add(loDatos);
                        }
                }
                if (oCEntidad.ListParticipantesOsi != null)
                {
                    foreach (var loDatos in oCEntidad.ListParticipantesOsi)
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            loDatos.MAE_COD_TIPOPARTICIPANTE = "0000017";
                            olParticipantesGeneral.Add(loDatos);
                        }
                }
                if (oCEntidad.ListParticipantesPonente != null)
                {
                    foreach (var loDatos in oCEntidad.ListParticipantesPonente)
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            loDatos.MAE_COD_TIPOPARTICIPANTE = "0000018";
                            olParticipantesGeneral.Add(loDatos);
                        }

                }

                if (olParticipantesGeneral.Count > 0)
                {
                    foreach (var loDatos in olParticipantesGeneral)
                    {
                        oCamposDet = new CEntidad();
                        oCamposDet.COD_CAPACITACION = oCEntidad.COD_CAPACITACION;
                        oCamposDet.COD_PERSONA = loDatos.COD_PERSONA;
                        oCamposDet.APE_PATERNO = loDatos.APE_PATERNO;
                        oCamposDet.APE_MATERNO = loDatos.APE_MATERNO;
                        oCamposDet.NOMBRES = loDatos.NOMBRES;
                        oCamposDet.APELLIDOS_NOMBRES = loDatos.APELLIDOS_NOMBRES;
                        oCamposDet.NOMBRES_APELLIDOS = loDatos.NOMBRES_APELLIDOS;
                        oCamposDet.N_DOCUMENTO = loDatos.N_DOCUMENTO;
                        oCamposDet.NOM_INSTITUCION = loDatos.NOM_INSTITUCION;
                        oCamposDet.COD_INSTITUCION = loDatos.COD_INSTITUCION ?? "";
                        oCamposDet.CARGO = loDatos.CARGO ?? "";
                        oCamposDet.GENERO = loDatos.GENERO;
                        oCamposDet.EDAD = loDatos.EDAD;
                        oCamposDet.TELEFONO = loDatos.TELEFONO;
                        oCamposDet.CORREO = loDatos.CORREO;
                        oCamposDet.OBSERVACION = loDatos.OBSERVACION ?? "";
                        oCamposDet.COD_CONSTANCIA = loDatos.COD_CONSTANCIA;
                        oCamposDet.FUNCION = loDatos.FUNCION;
                        oCamposDet.COD_CCNN = loDatos.COD_CCNN ?? "";
                        oCamposDet.CCNN = loDatos.CCNN;
                        oCamposDet.ETNIA = loDatos.ETNIA;
                        oCamposDet.MAE_COD_TIPOPARTICIPANTE = loDatos.MAE_COD_TIPOPARTICIPANTE;
                        oCamposDet.COD_THABILITANTE = loDatos.COD_THABILITANTE;
                        oCamposDet.NUM_THABILITANTE = loDatos.NUM_THABILITANTE;
                        oCamposDet.RegEstado = loDatos.RegEstado;
                        dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spCAPACITACION_PARTICIPANTES_Grabar", oCamposDet);
                    }
                }
                if (oCEntidad.ListCapacitacionConvenios != null)
                {
                    foreach (var loDatos in oCEntidad.ListCapacitacionConvenios)
                    {
                        oCamposDet = new CEntidad();
                        oCamposDet.COD_CAPACITACION = oCEntidad.COD_CAPACITACION;
                        oCamposDet.COD_MARCO_CONVENIO = loDatos.COD_MARCO_CONVENIO;
                        //oCamposDet.MAE_GRUPO_CONVENIO = loDatos.MAE_GRUPO_CONVENIO;
                        dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spCAPACITACION_CONVENIOS_Grabar", oCamposDet);
                    }
                }
                if (oCEntidad.ListPublicoObjetivo != null)
                {
                    foreach (var loDatos in oCEntidad.ListPublicoObjetivo)
                    {
                        oCamposDet = new CEntidad();
                        oCamposDet.COD_CAPACITACION = oCEntidad.COD_CAPACITACION;
                        oCamposDet.COD_PUBLICO_OBJETIVO = loDatos.COD_PUBLICO_OBJETIVO;
                        oCamposDet.DESCRIPCION_PUBLICO = loDatos.DESCRIPCION_PUBLICO;
                        dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spCAPACITACION_PUBLICO_OBJ_Grabar", oCamposDet);
                    }
                }

                List<CEntidad> olEncuestasGeneral = new List<CEntidad>();
                if (oCEntidad.ListEncuestas != null)
                {
                    foreach (var loDatos in oCEntidad.ListEncuestas)
                    {
                        loDatos.MAE_COD_TIPOENCUESTA = "0000039";
                        olEncuestasGeneral.Add(loDatos);
                    }
                }
                if (oCEntidad.ListEvaInicial != null)
                {
                    foreach (var loDatos in oCEntidad.ListEvaInicial)
                    {
                        loDatos.MAE_COD_TIPOENCUESTA = "0000040";
                        olEncuestasGeneral.Add(loDatos);
                    }
                }
                if (oCEntidad.ListEvaFinal != null)
                {
                    foreach (var loDatos in oCEntidad.ListEvaFinal)
                    {
                        loDatos.MAE_COD_TIPOENCUESTA = "0000041";
                        olEncuestasGeneral.Add(loDatos);
                    }
                }

                if (olEncuestasGeneral.Count > 0)
                {
                    foreach (var loEncuesta in olEncuestasGeneral)
                    {
                        oCamposDet = new CEntidad();
                        oCamposDet.COD_CAPACITACION = oCEntidad.COD_CAPACITACION;
                        oCamposDet.COD_PREGUNTA = loEncuesta.COD_PREGUNTA ?? "";
                        oCamposDet.DES_PREGUNTA = loEncuesta.DES_PREGUNTA;
                        oCamposDet.N_PARTICIPANTES = loEncuesta.N_PARTICIPANTES;
                        oCamposDet.N_CHECK_BUENO = loEncuesta.N_CHECK_BUENO;
                        oCamposDet.P_CHECK_BUENO = loEncuesta.P_CHECK_BUENO;
                        oCamposDet.N_CHECK_REGULAR = loEncuesta.N_CHECK_REGULAR;
                        oCamposDet.P_CHECK_REGULAR = loEncuesta.P_CHECK_REGULAR;
                        oCamposDet.N_CHECK_MALO = loEncuesta.N_CHECK_MALO;
                        oCamposDet.P_CHECK_MALO = loEncuesta.P_CHECK_MALO;
                        oCamposDet.N_NO_CHECK = loEncuesta.N_NO_CHECK;
                        oCamposDet.P_NO_CHECK = loEncuesta.P_NO_CHECK;
                        oCamposDet.MAE_COD_TIPOENCUESTA = loEncuesta.MAE_COD_TIPOENCUESTA;
                        oCamposDet.COD_UCUENTA = oCEntidad.COD_UCUENTA;
                        dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spCAPACITACION_ENCUESTA_Grabar", oCamposDet);
                    }
                }
                if (oCEntidad.ListEvaluaciones != null)
                {
                    foreach (var loEvaluacion in oCEntidad.ListEvaluaciones)
                    {
                        oCamposDet = new CEntidad();
                        oCamposDet.COD_CAPACITACION = oCEntidad.COD_CAPACITACION;
                        oCamposDet.COD_PERSONA = loEvaluacion.COD_PERSONA ?? "";
                        oCamposDet.APE_PATERNO = loEvaluacion.APE_PATERNO;
                        oCamposDet.APE_MATERNO = loEvaluacion.APE_MATERNO;
                        oCamposDet.NOMBRES = loEvaluacion.NOMBRES;
                        oCamposDet.APELLIDOS_NOMBRES = loEvaluacion.APELLIDOS_NOMBRES;
                        oCamposDet.NOMBRES_APELLIDOS = loEvaluacion.NOMBRES_APELLIDOS;
                        oCamposDet.N_DOCUMENTO = loEvaluacion.N_DOCUMENTO;
                        oCamposDet.NOTA_EXA_INICIO = loEvaluacion.NOTA_EXA_INICIO;
                        oCamposDet.NOTA_EXA_FIN = loEvaluacion.NOTA_EXA_FIN;
                        oCamposDet.COD_UCUENTA = oCEntidad.COD_UCUENTA;
                        dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spCAPACITACION_EVALUACION_Grabar", oCamposDet);
                    }
                }
                if (oCEntidad.ListAportes != null)
                {
                    foreach (var loAporte in oCEntidad.ListAportes)
                    {
                        oCamposDet = new CEntidad();
                        oCamposDet.COD_CAPACITACION = oCEntidad.COD_CAPACITACION;
                        oCamposDet.COD_PERSONA = loAporte.COD_PERSONA;
                        oCamposDet.APE_PATERNO = loAporte.APE_PATERNO;
                        oCamposDet.APE_MATERNO = loAporte.APE_MATERNO;
                        oCamposDet.NOMBRES = loAporte.NOMBRES;
                        oCamposDet.APELLIDOS_NOMBRES = loAporte.APELLIDOS_NOMBRES;
                        oCamposDet.NOMBRES_APELLIDOS = loAporte.NOMBRES_APELLIDOS;
                        oCamposDet.N_DOCUMENTO = loAporte.N_DOCUMENTO;
                        oCamposDet.APORTE = loAporte.APORTE;
                        oCamposDet.COD_SECUENCIAL = loAporte.COD_SECUENCIAL;
                        oCamposDet.COD_UCUENTA = oCEntidad.COD_UCUENTA;
                        dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spCAPACITACION_APORTE_Grabar", oCamposDet);
                    }
                }
                if (oCEntidad.ListTematica != null)
                {
                    foreach (var loTema in oCEntidad.ListTematica)
                    {
                        oCamposDet = new CEntidad();
                        oCamposDet.COD_CAPACITACION = oCEntidad.COD_CAPACITACION;
                        oCamposDet.MAE_COD_TEMA = loTema.MAE_COD_TEMA;
                        oCamposDet.DESCRIPCION = loTema.DESCRIPCION;
                        oCamposDet.COD_UCUENTA = oCEntidad.COD_UCUENTA;
                        dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spCAPACITACION_TEMATICA_Grabar", oCamposDet);
                    }
                }
                if (oCEntidad.ListProgramacion != null)
                {
                    foreach (var loProgramacion in oCEntidad.ListProgramacion)
                    {
                        oCamposDet = new CEntidad();
                        oCamposDet.COD_CAPACITACION = oCEntidad.COD_CAPACITACION;
                        oCamposDet.FECHA_PROGRAMA = loProgramacion.FECHA_PROGRAMA;
                        oCamposDet.HORA = loProgramacion.HORA;
                        oCamposDet.TEMA = loProgramacion.TEMA;
                        oCamposDet.RESPONSABLE = loProgramacion.RESPONSABLE;
                        //oCamposDet.MAE_GRUPO_CONVENIO = loDatos.MAE_GRUPO_CONVENIO;
                        dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.SPCAPACITACION_PROGRAMA_Grabar", oCamposDet);
                    }
                }
                if (oCEntidad.ListCronograma != null)
                {
                    foreach (var loCronograma in oCEntidad.ListCronograma)
                    {
                        oCamposDet = new CEntidad();
                        oCamposDet.COD_CAPACITACION = oCEntidad.COD_CAPACITACION;
                        oCamposDet.ACTIVIDAD = loCronograma.ACTIVIDAD;
                        oCamposDet.FECHA_INICIO_CRONOGRAMA = loCronograma.FECHA_INICIO_CRONOGRAMA;
                        oCamposDet.FECHA_FIN_CRONOGRAMA = loCronograma.FECHA_FIN_CRONOGRAMA;


                        //oCamposDet.MAE_GRUPO_CONVENIO = loDatos.MAE_GRUPO_CONVENIO;
                        dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.SPCAPACITACION_CRONOGRAMA_Grabar", oCamposDet);
                    }
                }
                tr.Commit();
                return OUTPUTPARAM01;
            }
            catch (Exception ex)
            {
                if (tr != null)
                {
                    tr.Rollback();
                }
                throw ex;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public Int32 RegEliminar(OracleConnection cn, CEntidad oCEntidad)
        {
            try
            {
                Int32 RegNum = dBOracle.ManExecute(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spCAPACITACIONEliminarDetalle", oCEntidad);
                if (RegNum == -1)
                {
                    //ASí se ejecute bien el SP igual devuelve el valor de -1
                    //throw new Exception("No se logró realizar la operación");
                }
                return RegNum;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public CEntidad RegMostCombo(OracleConnection cn, CEntidad oCEntidad)
        {
            CEntidad oCampos = null;
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spGeneral_Combo_Listar", oCEntidad))
                {
                    if (dr != null)
                    {
                        oCampos = new CEntidad();
                        List<CEntidad> lsDetDetalle;
                        CEntidad oCamposDet;
                        //01 Oficina Desconcentrada
                        lsDetDetalle = new List<CEntidad>();
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("CODIGO");
                            int pt2 = dr.GetOrdinal("DESCRIPCION");
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.CODIGO = dr.GetString(pt1);
                                oCamposDet.DESCRIPCION = dr.GetString(pt2);
                                lsDetDetalle.Add(oCamposDet);
                            }
                        }
                        oCampos.ListMComboOD = lsDetDetalle;
                        //02 DIRECCION LINEA
                        dr.NextResult();
                        lsDetDetalle = new List<CEntidad>();
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("CODIGO");
                            int pt2 = dr.GetOrdinal("DESCRIPCION");
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.CODIGO = dr.GetString(pt1);
                                oCamposDet.DESCRIPCION = dr.GetString(pt2);
                                lsDetDetalle.Add(oCamposDet);
                            }
                        }
                        oCampos.ListMComboDireccionLinea = lsDetDetalle;
                        ////Respuestas a Encuesta
                        //dr.NextResult();
                        //lsDetDetalle = new List<CEntidad>();
                        //if (dr.HasRows)
                        //{
                        //    int pt1 = dr.GetOrdinal("CODIGO");
                        //    int pt2 = dr.GetOrdinal("DESCRIPCION");
                        //    while (dr.Read())
                        //    {
                        //        oCamposDet = new CEntidad();
                        //        oCamposDet.CODIGO = dr.GetString(pt1);
                        //        oCamposDet.DESCRIPCION = dr.GetString(pt2);
                        //        lsDetDetalle.Add(oCamposDet);
                        //    }
                        //}
                        //oCampos.ListMComboRespuestas = lsDetDetalle;
                        //
                        // 03 Tipos de Capacitaciones
                        dr.NextResult();
                        lsDetDetalle = new List<CEntidad>();
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("CODIGO");
                            int pt2 = dr.GetOrdinal("DESCRIPCION");
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.CODIGO = dr.GetString(pt1);
                                oCamposDet.DESCRIPCION = dr.GetString(pt2);
                                lsDetDetalle.Add(oCamposDet);
                            }
                        }
                        oCampos.ListMComboTipoCapacitacion = lsDetDetalle;
                        //04 Documento de Identidad
                        dr.NextResult();
                        lsDetDetalle = new List<CEntidad>();
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("CODIGO");
                            int pt2 = dr.GetOrdinal("DESCRIPCION");
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.CODIGO = dr.GetString(pt1);
                                oCamposDet.DESCRIPCION = dr.GetString(pt2);
                                lsDetDetalle.Add(oCamposDet);
                            }
                        }
                        oCampos.ListMComboDIdentidad = lsDetDetalle;
                        //05 Estado Documento
                        dr.NextResult();
                        lsDetDetalle = new List<CEntidad>();
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("CODIGO");
                            int pt2 = dr.GetOrdinal("DESCRIPCION");
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.CODIGO = dr.GetString(pt1);
                                oCamposDet.DESCRIPCION = dr.GetString(pt2);
                                lsDetDetalle.Add(oCamposDet);
                            }
                        }
                        oCampos.ListIndicador = lsDetDetalle;
                        //06 Instituciones
                        dr.NextResult();
                        lsDetDetalle = new List<CEntidad>();
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("CODIGO");
                            int pt2 = dr.GetOrdinal("DESCRIPCION");
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.CODIGO = dr.GetString(pt1);
                                oCamposDet.DESCRIPCION = dr.GetString(pt2);
                                lsDetDetalle.Add(oCamposDet);
                            }
                        }
                        oCampos.ListInstituciones = lsDetDetalle;
                        ////Convenios
                        //dr.NextResult();
                        //lsDetDetalle = new List<CEntidad>();
                        //if (dr.HasRows)
                        //{
                        //    int pt1 = dr.GetOrdinal("CODIGO");
                        //    int pt2 = dr.GetOrdinal("DESCRIPCION");
                        //    while (dr.Read())
                        //    {
                        //        oCamposDet = new CEntidad();
                        //        oCamposDet.CODIGO = dr.GetString(pt1);
                        //        oCamposDet.DESCRIPCION = dr.GetString(pt2);
                        //        lsDetDetalle.Add(oCamposDet);
                        //    }
                        //}
                        //oCampos.ListConvenios = lsDetDetalle;
                        //07 Publico Objetivo
                        dr.NextResult();
                        lsDetDetalle = new List<CEntidad>();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.GRUPO = dr.GetString(dr.GetOrdinal("GRUPO"));
                                oCamposDet.CODIGO = dr.GetString(dr.GetOrdinal("CODIGO"));
                                oCamposDet.DESCRIPCION = dr.GetString(dr.GetOrdinal("DESCRIPCION"));
                                lsDetDetalle.Add(oCamposDet);
                            }
                        }
                        oCampos.ListPublicoObjetivo = lsDetDetalle;
                        //08 Organizador evento
                        dr.NextResult();
                        lsDetDetalle = new List<CEntidad>();
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("CODIGO");
                            int pt2 = dr.GetOrdinal("DESCRIPCION");
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.CODIGO = dr.GetString(pt1);
                                oCamposDet.DESCRIPCION = dr.GetString(pt2);
                                lsDetDetalle.Add(oCamposDet);
                            }
                        }
                        oCampos.ListMComboOrganizador = lsDetDetalle;
                        //09 Marco Convenio - a.	Autoridades forestales de fiscalización
                        dr.NextResult();
                        lsDetDetalle = new List<CEntidad>();
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("CODIGO");
                            int pt2 = dr.GetOrdinal("DESCRIPCION");
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.CODIGO = dr.GetString(pt1);
                                oCamposDet.DESCRIPCION = dr.GetString(pt2);
                                lsDetDetalle.Add(oCamposDet);
                            }
                        }
                        oCampos.ListConveniosAFF = lsDetDetalle;
                        //10 --Marco Convenio - b.	Organizaciones indígenas
                        dr.NextResult();
                        lsDetDetalle = new List<CEntidad>();
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("CODIGO");
                            int pt2 = dr.GetOrdinal("DESCRIPCION");
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.CODIGO = dr.GetString(pt1);
                                oCamposDet.DESCRIPCION = dr.GetString(pt2);
                                lsDetDetalle.Add(oCamposDet);
                            }
                        }
                        oCampos.ListConveniosOI = lsDetDetalle;
                        //11 --Marco Convenio - c.	Organizaciones de investigación o afines
                        dr.NextResult();
                        lsDetDetalle = new List<CEntidad>();
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("CODIGO");
                            int pt2 = dr.GetOrdinal("DESCRIPCION");
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.CODIGO = dr.GetString(pt1);
                                oCamposDet.DESCRIPCION = dr.GetString(pt2);
                                lsDetDetalle.Add(oCamposDet);
                            }
                        }
                        oCampos.ListConveniosOIA = lsDetDetalle;

                        //12 --Marco Convenio SIGOsfc v3
                        oCampos.ListMComboConvenios = new List<CEntidad>();
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.CODIGO = dr.GetString(dr.GetOrdinal("CODIGO"));
                                oCamposDet.DESCRIPCION = dr.GetString(dr.GetOrdinal("DESCRIPCION"));
                                oCamposDet.GRUPO = dr.GetString(dr.GetOrdinal("GRUPO"));
                                oCampos.ListMComboConvenios.Add(oCamposDet);
                            }
                        }

                        //13 --Apoyo del coorganizador
                        dr.NextResult();
                        lsDetDetalle = new List<CEntidad>();
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("CODIGO");
                            int pt2 = dr.GetOrdinal("DESCRIPCION");
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.CODIGO = dr.GetString(pt1);
                                oCamposDet.DESCRIPCION = dr.GetString(pt2);
                                lsDetDetalle.Add(oCamposDet);
                            }
                        }
                        oCampos.ListApoyoCoorg = lsDetDetalle;
                        //14 --Titulares de títulos habilitantes 
                        dr.NextResult();
                        lsDetDetalle = new List<CEntidad>();
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("CODIGO");
                            int pt2 = dr.GetOrdinal("DESCRIPCION");
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.CODIGO = dr.GetString(pt1);
                                oCamposDet.DESCRIPCION = dr.GetString(pt2);
                                lsDetDetalle.Add(oCamposDet);
                            }
                        }
                        oCampos.ListTitularesTitHab = lsDetDetalle;
                        //15 --Representantes de Organizaciones/Asociaciones 
                        dr.NextResult();
                        lsDetDetalle = new List<CEntidad>();
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("CODIGO");
                            int pt2 = dr.GetOrdinal("DESCRIPCION");
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.CODIGO = dr.GetString(pt1);
                                oCamposDet.DESCRIPCION = dr.GetString(pt2);
                                lsDetDetalle.Add(oCamposDet);
                            }
                        }
                        oCampos.ListRepresentantesOrgAso = lsDetDetalle;
                        //16 --Consultores/regentes/materos
                        dr.NextResult();
                        lsDetDetalle = new List<CEntidad>();
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("CODIGO");
                            int pt2 = dr.GetOrdinal("DESCRIPCION");
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.CODIGO = dr.GetString(pt1);
                                oCamposDet.DESCRIPCION = dr.GetString(pt2);
                                lsDetDetalle.Add(oCamposDet);
                            }
                        }
                        oCampos.ListConsultoresRegMat = lsDetDetalle;

                        //17 Metodología capacitación
                        dr.NextResult();
                        lsDetDetalle = new List<CEntidad>();
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("CODIGO");
                            int pt2 = dr.GetOrdinal("DESCRIPCION");
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.CODIGO = dr.GetString(pt1);
                                oCamposDet.DESCRIPCION = dr.GetString(pt2);
                                lsDetDetalle.Add(oCamposDet);
                            }
                        }
                        oCampos.ListMComboMetodologia = lsDetDetalle;


                        //18 Temáticas de una capacitación
                        dr.NextResult();
                        lsDetDetalle = new List<CEntidad>();
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("CODIGO");
                            int pt2 = dr.GetOrdinal("DESCRIPCION");
                            int pt3 = dr.GetOrdinal("NUEVO_2021");
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.CODIGO = dr.GetString(pt1);
                                oCamposDet.DESCRIPCION = dr.GetString(pt2);
                                oCamposDet.NUEVO_2021 = dr.GetString(pt3);
                                lsDetDetalle.Add(oCamposDet);
                            }
                        }
                        oCampos.ListMChkListTematica = lsDetDetalle;
                        //19 comunidades nativas
                        dr.NextResult();
                        lsDetDetalle = new List<CEntidad>();
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("CODIGO");
                            int pt2 = dr.GetOrdinal("DESCRIPCION");
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.CODIGO = dr.GetString(pt1);
                                oCamposDet.DESCRIPCION = dr.GetString(pt2);
                                lsDetDetalle.Add(oCamposDet);
                            }
                        }
                        oCampos.ListMComboCCNN = lsDetDetalle;
                        //20 Etnias
                        dr.NextResult();
                        lsDetDetalle = new List<CEntidad>();
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("CODIGO");
                            int pt2 = dr.GetOrdinal("DESCRIPCION");
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.CODIGO = dr.GetString(pt1);
                                oCamposDet.DESCRIPCION = dr.GetString(pt2);
                                lsDetDetalle.Add(oCamposDet);
                            }
                        }
                        oCampos.ListMComboEtnia = lsDetDetalle;
                        //21 Listado de capacitaciones programadas (pendientes de ejecución)
                        dr.NextResult();
                        lsDetDetalle = new List<CEntidad>();
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("CODIGO");
                            int pt2 = dr.GetOrdinal("DESCRIPCION");
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.CODIGO = dr.GetString(pt1);
                                oCamposDet.DESCRIPCION = dr.GetString(pt2);
                                oCamposDet.COD_OD = dr.GetString(dr.GetOrdinal("COD_OD"));
                                oCamposDet.COD_CAPATIPO = dr.GetString(dr.GetOrdinal("COD_CAPATIPO"));
                                oCamposDet.FECHA_INICIO = dr.GetString(dr.GetOrdinal("FECHA_INICIO"));
                                oCamposDet.COD_UBIGEO = dr.GetString(dr.GetOrdinal("COD_UBIGEO"));
                                oCamposDet.UBIGEO_DESCRIPCION = dr.GetString(dr.GetOrdinal("UBIGEO_DESCRIPCION"));
                                oCamposDet.LUGAR = dr.GetString(dr.GetOrdinal("LUGAR"));
                                oCamposDet.NOMBRE = dr.GetString(dr.GetOrdinal("NOMBRE"));
                                oCamposDet.SUMA_POI = dr.GetBoolean(dr.GetOrdinal("SUMA_POI"));
                                oCamposDet.MARCO_CONVENIO = dr.GetBoolean(dr.GetOrdinal("MARCO_CONVENIO"));
                                oCamposDet.ListCapacitacionConvenios = new List<CEntidad>();
                                lsDetDetalle.Add(oCamposDet);
                            }
                        }
                        oCampos.ListMComboCapacitacionPendiente = lsDetDetalle;
                        //22 Listado marco convenio de las capacitaciones programadas
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            string codPcapacitacion = "";

                            while (dr.Read())
                            {
                                codPcapacitacion = dr.GetString(dr.GetOrdinal("COD_PCAPACITACION"));
                                for (int i = 0; i < oCampos.ListMComboCapacitacionPendiente.Count; i++)
                                {
                                    if (oCampos.ListMComboCapacitacionPendiente[i].CODIGO == codPcapacitacion)
                                    {
                                        oCamposDet = new CEntidad();
                                        oCamposDet.COD_MARCO_CONVENIO = dr.GetString(dr.GetOrdinal("COD_MARCO_CONVENIO"));
                                        oCamposDet.MAE_GRUPO_CONVENIO = dr.GetString(dr.GetOrdinal("MAE_GRUPO_CONVENIO"));
                                        oCampos.ListMComboCapacitacionPendiente[i].ListCapacitacionConvenios.Add(oCamposDet);
                                    }
                                }
                            }
                        }
                        //23 Listado Tipo Archivo Adjunto
                        dr.NextResult();
                        lsDetDetalle = new List<CEntidad>();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.CODIGO = dr.GetString(dr.GetOrdinal("CODIGO"));
                                oCamposDet.DESCRIPCION = dr.GetString(dr.GetOrdinal("DESCRIPCION"));
                                lsDetDetalle.Add(oCamposDet);
                            }
                        }
                        oCampos.ListMComboTipoAdjunto = lsDetDetalle;

                        //24 Publico Participante
                        dr.NextResult();
                        oCampos.ListPublicoParticipante = new List<CEntidad>();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.GRUPO = dr.GetString(dr.GetOrdinal("GRUPO"));
                                oCamposDet.CODIGO = dr.GetString(dr.GetOrdinal("CODIGO"));
                                oCamposDet.DESCRIPCION = dr.GetString(dr.GetOrdinal("DESCRIPCION"));
                                oCampos.ListPublicoParticipante.Add(oCamposDet);
                            }
                        }
                        //25 Modalidad capacitación
                        dr.NextResult();
                        lsDetDetalle = new List<CEntidad>();
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("CODIGO");
                            int pt2 = dr.GetOrdinal("DESCRIPCION");
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.CODIGO = dr.GetString(pt1);
                                oCamposDet.DESCRIPCION = dr.GetString(pt2);
                                lsDetDetalle.Add(oCamposDet);
                            }
                        }
                        oCampos.ListMComboModalidad = lsDetDetalle;
                    }
                }
                return oCampos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public String RegGrabarDetalle(OracleConnection cn, CEntidad oCEntidad)
        {
            OracleTransaction tr = null;
            String OUTPUTPARAM01 = "";
            try
            {
                tr = cn.BeginTransaction();
                //Grabando Cabecera
                using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spCAPACITACION_DETALLE_Grabar", oCEntidad))
                {
                    cmd.ExecuteNonQuery();
                    OUTPUTPARAM01 = (String)cmd.Parameters["OUTPUTPARAM01"].Value;
                }
                tr.Commit();
                return OUTPUTPARAM01;
            }
            catch (Exception ex)
            {
                if (tr != null)
                {
                    tr.Rollback();
                }
                throw ex;
            }
        }

        #region SIGOsfc v3
        public String RegGrabar_v3(OracleConnection cn, CEntidad oCEntidad)
        {
            OracleTransaction tr = null;
            String OUTPUTPARAM01 = "";
            CEntidad oCamposDet;
            try
            {
                tr = cn.BeginTransaction();
                //Grabando Cabecera
                using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spCAPACITACIONGrabar_v3", oCEntidad))
                {
                    cmd.ExecuteNonQuery();
                    OUTPUTPARAM01 = (String)cmd.Parameters["OUTPUTPARAM01"].Value;
                    if (OUTPUTPARAM01 == "99")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("Ud. no tiene permiso para realizar esta acción");
                    }
                    if (OUTPUTPARAM01 == "0")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("El Nombre de la Capacitación ya Existe");
                    }
                    else if (OUTPUTPARAM01 == "3")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("Este Control de Calidad no puede modificarse");
                    }
                    else if (OUTPUTPARAM01 == "2")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("No Tiene Permisos para Modificar este Registro");
                    }
                    else if (OUTPUTPARAM01 == "1")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("El Nombre de la Capacitación ya Existe");
                    }
                    else if (OUTPUTPARAM01 == "100")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("La capacitación ya se encuentra con Control de Calidad Conforme");
                    }
                }
                //Reemplazando El Nuevo Codigo Creado
                if (oCEntidad.RegEstado == 1) //Nuevo
                {
                    oCEntidad.COD_CAPACITACION = OUTPUTPARAM01;
                }
                //
                //Eliminando Detalle
                if (oCEntidad.ListEliTABLA != null)
                {
                    foreach (var loDatos in oCEntidad.ListEliTABLA)
                    {
                        oCamposDet = new CEntidad();
                        oCamposDet.COD_CAPACITACION = oCEntidad.COD_CAPACITACION;
                        oCamposDet.EliTABLA = loDatos.EliTABLA;
                        oCamposDet.EliVALOR01 = loDatos.EliVALOR01;
                        oCamposDet.EliVALOR02 = loDatos.EliVALOR02;
                        oCamposDet.EliVALOR03 = loDatos.EliVALOR03;
                        dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spCAPACITACIONEliminarDetalle", oCamposDet);
                    }
                }
                //
                /*
				//Grabando Detalle CAPACITACION_DETALLE
				if (oCEntidad.ListTDCapacitacion != null)
				{
					foreach (var loDatos in oCEntidad.ListTDCapacitacion)
					{
						if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
						{
							oCamposDet = new CEntidad();
							oCamposDet.COD_CAPACITACION = oCEntidad.COD_CAPACITACION;
							oCamposDet.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
							oCamposDet.NOMBRE_ARCHIVO = loDatos.NOMBRE_ARCHIVO;
							oCamposDet.EXTENSION = loDatos.EXTENSION;
							oCamposDet.RegEstado = loDatos.RegEstado;
							dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spCAPACITACION_DETALLE_Grabar", oCamposDet);
						}
					}
				}*/

                List<CEntidad> olParticipantesGeneral = new List<CEntidad>();
                if (oCEntidad.ListParticipantes != null)
                {
                    foreach (var loDatos in oCEntidad.ListParticipantes)
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            loDatos.MAE_COD_TIPOPARTICIPANTE = "0000016";
                            olParticipantesGeneral.Add(loDatos);
                        }
                }
                if (oCEntidad.ListParticipantesOsi != null)
                {
                    foreach (var loDatos in oCEntidad.ListParticipantesOsi)
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            loDatos.MAE_COD_TIPOPARTICIPANTE = "0000017";
                            olParticipantesGeneral.Add(loDatos);
                        }
                }
                if (oCEntidad.ListParticipantesPonente != null)
                {
                    foreach (var loDatos in oCEntidad.ListParticipantesPonente)
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            loDatos.MAE_COD_TIPOPARTICIPANTE = "0000018";
                            olParticipantesGeneral.Add(loDatos);
                        }

                }

                if (olParticipantesGeneral.Count > 0)
                {
                    foreach (var loDatos in olParticipantesGeneral)
                    {
                        oCamposDet = new CEntidad();
                        oCamposDet.COD_CAPACITACION = oCEntidad.COD_CAPACITACION;
                        oCamposDet.COD_PERSONA = loDatos.COD_PERSONA;
                        oCamposDet.APE_PATERNO = loDatos.APE_PATERNO;
                        oCamposDet.APE_MATERNO = loDatos.APE_MATERNO;
                        oCamposDet.NOMBRES = loDatos.NOMBRES;
                        //oCamposDet.APELLIDOS_NOMBRES = loDatos.APELLIDOS_NOMBRES;
                        //oCamposDet.NOMBRES_APELLIDOS = loDatos.NOMBRES_APELLIDOS;
                        oCamposDet.N_DOCUMENTO = loDatos.N_DOCUMENTO;
                        oCamposDet.NOM_INSTITUCION = loDatos.NOM_INSTITUCION;
                        oCamposDet.COD_INSTITUCION = loDatos.COD_INSTITUCION ?? "";
                        oCamposDet.CARGO = loDatos.CARGO ?? "";
                        oCamposDet.GENERO = loDatos.GENERO;
                        oCamposDet.EDAD = loDatos.EDAD;
                        oCamposDet.TELEFONO = loDatos.TELEFONO;
                        oCamposDet.CORREO = loDatos.CORREO;
                        oCamposDet.OBSERVACION = loDatos.OBSERVACION ?? "";
                        oCamposDet.COD_CONSTANCIA = loDatos.COD_CONSTANCIA;
                        oCamposDet.FUNCION = loDatos.FUNCION;
                        oCamposDet.COD_CCNN = loDatos.COD_CCNN ?? "";
                        oCamposDet.CCNN = loDatos.CCNN;
                        oCamposDet.ETNIA = loDatos.ETNIA;
                        oCamposDet.MAE_COD_TIPOPARTICIPANTE = loDatos.MAE_COD_TIPOPARTICIPANTE;
                        oCamposDet.COD_THABILITANTE = loDatos.COD_THABILITANTE;
                        oCamposDet.NUM_THABILITANTE = loDatos.NUM_THABILITANTE;
                        oCamposDet.MAE_COD_PUBLICOPARTICIPANTE = loDatos.MAE_COD_PUBLICOPARTICIPANTE;
                        oCamposDet.PUBLICOPARTICIPANTE = (loDatos.GRUPOPUBLICOPARTICIPANTE ?? "") + " | " + (loDatos.PUBLICOPARTICIPANTE ?? "");
                        oCamposDet.COD_UCUENTA = oCEntidad.COD_UCUENTA;
                        oCamposDet.MOCHILAFORESTAL = (loDatos.MOCHILAFORESTAL == null || loDatos.MOCHILAFORESTAL.Equals("0000000") || loDatos.MOCHILAFORESTAL.Trim().Equals("")) ? null : loDatos.MOCHILAFORESTAL;
                        oCamposDet.RegEstado = loDatos.RegEstado;
                       // oCamposDet.COD_CONSTANCIA_CAP = loDatos.COD_CONSTANCIA_CAP;
                        dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spCAPACITACION_PARTICIPANTES_Grabar", oCamposDet);
                    }
                }
                if (oCEntidad.ListCapacitacionConvenios != null)
                {
                    foreach (var loDatos in oCEntidad.ListCapacitacionConvenios)
                    {
                        oCamposDet = new CEntidad();
                        oCamposDet.COD_CAPACITACION = oCEntidad.COD_CAPACITACION;
                        oCamposDet.COD_MARCO_CONVENIO = loDatos.COD_MARCO_CONVENIO;
                        //oCamposDet.MAE_GRUPO_CONVENIO = loDatos.MAE_GRUPO_CONVENIO;
                        dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spCAPACITACION_CONVENIOS_Grabar", oCamposDet);
                    }
                }
                if (oCEntidad.ListPublicoObjetivo != null)
                {
                    foreach (var loDatos in oCEntidad.ListPublicoObjetivo)
                    {
                        oCamposDet = new CEntidad();
                        oCamposDet.COD_CAPACITACION = oCEntidad.COD_CAPACITACION;
                        oCamposDet.COD_PUBLICO_OBJETIVO = loDatos.COD_PUBLICO_OBJETIVO;
                        oCamposDet.DESCRIPCION_PUBLICO = loDatos.DESCRIPCION_PUBLICO;
                        dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spCAPACITACION_PUBLICO_OBJ_Grabar", oCamposDet);
                    }
                }

                List<CEntidad> olEncuestasGeneral = new List<CEntidad>();
                if (oCEntidad.ListEncuestas != null)
                {
                    foreach (var loDatos in oCEntidad.ListEncuestas)
                    {
                        loDatos.MAE_COD_TIPOENCUESTA = "0000039";
                        olEncuestasGeneral.Add(loDatos);
                    }
                }
                if (oCEntidad.ListEvaInicial != null)
                {
                    foreach (var loDatos in oCEntidad.ListEvaInicial)
                    {
                        loDatos.MAE_COD_TIPOENCUESTA = "0000040";
                        olEncuestasGeneral.Add(loDatos);
                    }
                }
                if (oCEntidad.ListEvaFinal != null)
                {
                    foreach (var loDatos in oCEntidad.ListEvaFinal)
                    {
                        loDatos.MAE_COD_TIPOENCUESTA = "0000041";
                        olEncuestasGeneral.Add(loDatos);
                    }
                }

                if (olEncuestasGeneral.Count > 0)
                {
                    foreach (var loEncuesta in olEncuestasGeneral)
                    {
                        oCamposDet = new CEntidad();
                        oCamposDet.COD_CAPACITACION = oCEntidad.COD_CAPACITACION;
                        oCamposDet.COD_PREGUNTA = loEncuesta.COD_PREGUNTA ?? "";
                        oCamposDet.DES_PREGUNTA = loEncuesta.DES_PREGUNTA;
                        oCamposDet.N_PARTICIPANTES = loEncuesta.N_PARTICIPANTES;
                        oCamposDet.N_CHECK_BUENO = loEncuesta.N_CHECK_BUENO;
                        oCamposDet.P_CHECK_BUENO = loEncuesta.P_CHECK_BUENO;
                        oCamposDet.N_CHECK_REGULAR = loEncuesta.N_CHECK_REGULAR;
                        oCamposDet.P_CHECK_REGULAR = loEncuesta.P_CHECK_REGULAR;
                        oCamposDet.N_CHECK_MALO = loEncuesta.N_CHECK_MALO;
                        oCamposDet.P_CHECK_MALO = loEncuesta.P_CHECK_MALO;
                        oCamposDet.N_NO_CHECK = loEncuesta.N_NO_CHECK;
                        oCamposDet.P_NO_CHECK = loEncuesta.P_NO_CHECK;
                        oCamposDet.MAE_COD_TIPOENCUESTA = loEncuesta.MAE_COD_TIPOENCUESTA;
                        oCamposDet.COD_UCUENTA = oCEntidad.COD_UCUENTA;
                        dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spCAPACITACION_ENCUESTA_Grabar", oCamposDet);
                    }
                }
                if (oCEntidad.ListEvaluaciones != null)
                {
                    foreach (var loEvaluacion in oCEntidad.ListEvaluaciones)
                    {
                        oCamposDet = new CEntidad();
                        oCamposDet.COD_CAPACITACION = oCEntidad.COD_CAPACITACION;
                        oCamposDet.COD_PERSONA = loEvaluacion.COD_PERSONA ?? "";
                        oCamposDet.APE_PATERNO = loEvaluacion.APE_PATERNO;
                        oCamposDet.APE_MATERNO = loEvaluacion.APE_MATERNO;
                        oCamposDet.NOMBRES = loEvaluacion.NOMBRES;
                        oCamposDet.APELLIDOS_NOMBRES = loEvaluacion.APELLIDOS_NOMBRES;
                        oCamposDet.NOMBRES_APELLIDOS = loEvaluacion.NOMBRES_APELLIDOS;
                        oCamposDet.N_DOCUMENTO = loEvaluacion.N_DOCUMENTO;
                        oCamposDet.NOTA_EXA_INICIO = loEvaluacion.NOTA_EXA_INICIO;
                        oCamposDet.NOTA_EXA_FIN = loEvaluacion.NOTA_EXA_FIN;
                        oCamposDet.COD_UCUENTA = oCEntidad.COD_UCUENTA;
                        dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spCAPACITACION_EVALUACION_Grabar", oCamposDet);
                    }
                }
                if (oCEntidad.ListAportes != null)
                {
                    foreach (var loAporte in oCEntidad.ListAportes)
                    {
                        oCamposDet = new CEntidad();
                        oCamposDet.COD_CAPACITACION = oCEntidad.COD_CAPACITACION;
                        oCamposDet.COD_PERSONA = loAporte.COD_PERSONA;
                        oCamposDet.APE_PATERNO = loAporte.APE_PATERNO;
                        oCamposDet.APE_MATERNO = loAporte.APE_MATERNO;
                        oCamposDet.NOMBRES = loAporte.NOMBRES;
                        oCamposDet.APELLIDOS_NOMBRES = loAporte.APELLIDOS_NOMBRES;
                        oCamposDet.NOMBRES_APELLIDOS = loAporte.NOMBRES_APELLIDOS;
                        oCamposDet.N_DOCUMENTO = loAporte.N_DOCUMENTO;
                        oCamposDet.APORTE = loAporte.APORTE;
                        oCamposDet.COD_SECUENCIAL = loAporte.COD_SECUENCIAL;
                        oCamposDet.COD_UCUENTA = oCEntidad.COD_UCUENTA;
                        dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spCAPACITACION_APORTE_Grabar", oCamposDet);
                    }
                }
                if (oCEntidad.ListTematica != null)
                {
                    foreach (var loTema in oCEntidad.ListTematica)
                    {
                        oCamposDet = new CEntidad();
                        oCamposDet.COD_CAPACITACION = oCEntidad.COD_CAPACITACION;
                        oCamposDet.MAE_COD_TEMA = loTema.MAE_COD_TEMA;
                        oCamposDet.DESCRIPCION = loTema.DESCRIPCION;
                        oCamposDet.COD_UCUENTA = oCEntidad.COD_UCUENTA;
                        dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spCAPACITACION_TEMATICA_Grabar", oCamposDet);
                    }
                }

                List<CEntidad> olProgramaGeneral = new List<CEntidad>();
                //if (oCEntidad.ListProgramacion != null)
                //{
                //    foreach (var loDatosPrograma in oCEntidad.ListProgramacion)
                //        if (loDatosPrograma.RegEstado == 1 || loDatosPrograma.RegEstado == 2) //Nuevo o Modificado                        {

                //            olProgramaGeneral.Add(loDatosPrograma);
                //        }
                //}
                if (oCEntidad.ListProgramacion != null)
                {
                    foreach (var loProgramacion in oCEntidad.ListProgramacion)
                    {
                        oCamposDet = new CEntidad();
                        oCamposDet.COD_CAPACITACION = oCEntidad.COD_CAPACITACION;
                        oCamposDet.COD_SECUENCIAL = loProgramacion.COD_SECUENCIAL;
                        oCamposDet.FECHA_PROGRAMA = loProgramacion.FECHA_PROGRAMA.ToString();
                        oCamposDet.HORA = loProgramacion.HORA;
                        oCamposDet.TEMA = loProgramacion.TEMA;
                        oCamposDet.RESPONSABLE = loProgramacion.RESPONSABLE;
                        //oCamposDet.MAE_GRUPO_CONVENIO = loDatos.MAE_GRUPO_CONVENIO;
                        dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.SPCAPACITACION_PROGRAMA_Grabar", oCamposDet);
                    }
                }
                if (oCEntidad.ListCronograma != null)
                {
                    foreach (var loCronograma in oCEntidad.ListCronograma)
                    {
                        oCamposDet = new CEntidad();
                        oCamposDet.COD_CAPACITACION = oCEntidad.COD_CAPACITACION;
                        oCamposDet.COD_SECUENCIAL = loCronograma.COD_SECUENCIAL;
                        oCamposDet.ACTIVIDAD = loCronograma.ACTIVIDAD;
                        oCamposDet.FECHA_INICIO_CRONOGRAMA = loCronograma.FECHA_INICIO_CRONOGRAMA.ToString();
                        oCamposDet.FECHA_FIN_CRONOGRAMA = loCronograma.FECHA_FIN_CRONOGRAMA.ToString();
                        dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.SPCAPACITACION_CRONOGRAMA_Grabar", oCamposDet);
                    }
                }
                tr.Commit();
                return OUTPUTPARAM01;
            }
            catch (Exception ex)
            {
                if (tr != null)
                {
                    tr.Rollback();
                }
                throw ex;
            }
        }

        public List<Dictionary<string, string>> ReportesCapacitacion(OracleConnection cn, CEntidad oCEntidad)
        {
            List<Dictionary<string, string>> lstResult = new List<Dictionary<string, string>>();

            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spReporteCapacitacion", oCEntidad))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            Dictionary<string, string> sFila;
                            string sColumn = "";

                            while (dr.Read())
                            {
                                sFila = new Dictionary<string, string>();
                                for (int i = 0; i < dr.FieldCount; i++)
                                {
                                    sColumn = dr.GetName(i);
                                    sFila.Add(sColumn, dr[sColumn].ToString());
                                }
                                lstResult.Add(sFila);
                            }
                        }
                    }
                }

                return lstResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        public List<CEntidad> ReporteGraficoGenero(OracleConnection cn, String codCapacitacion)
        {
            List<CEntidad> lsCEntidadRGP = new List<CEntidad>();
            CEntidad oCamposDet = new CEntidad();
            //List<Dictionary<string, string>> lstResult = new List<Dictionary<string, string>>();

            try
            {
                //using (SqlDataReader dr = oGDataSQL.SelDrdDefault(cn, null, "DOC.spCAPACITACIONRepNC", oCEntidad))
                //using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spReporteCapacitacionGenero", codCapacitacion))
                using (OracleDataReader dr = dBOracle.SelDrdDefaultPart(cn, null, "DOC_OSINFOR_ERP_MIGRACION.SPREPORTECAPACITACIONGENERO", codCapacitacion))
                {

                    //dr.NextResult();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            oCamposDet = new CEntidad();
                            oCamposDet.COD_CAPACITACION = dr["COD_CAPACITACION"].ToString();
                            oCamposDet.GENERO = dr["GENERO"].ToString();
                            oCamposDet.P_CHECK_BUENO = decimal.Parse(dr["P_CHECK_BUENO"].ToString());
                            lsCEntidadRGP.Add(oCamposDet);
                        }
                    }
                }
                return lsCEntidadRGP;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<CEntidad> ReporteGraficoGeneroMemoria(OracleConnection cn, String codCapacitacion)
        {
            List<CEntidad> lsCEntidadRGP = new List<CEntidad>();
            CEntidad oCamposDet = new CEntidad();
            //List<Dictionary<string, string>> lstResult = new List<Dictionary<string, string>>();

            try
            {
                //using (SqlDataReader dr = oGDataSQL.SelDrdDefault(cn, null, "DOC.spCAPACITACIONRepNC", oCEntidad))
                //using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spReporteCapacitacionGenero", codCapacitacion))
                using (OracleDataReader dr = dBOracle.SelDrdDefaultPart(cn, null, "DOC_OSINFOR_ERP_MIGRACION.SPREPORTECAPACITACIONGENERO", codCapacitacion))
                {

                    //dr.NextResult();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            oCamposDet = new CEntidad();
                            oCamposDet.COD_CAPACITACION = dr["COD_CAPACITACION"].ToString();
                            oCamposDet.GENERO = dr["GENERO"].ToString();
                            oCamposDet.P_CHECK_BUENO = decimal.Parse(dr["P_CHECK_BUENO"].ToString());
                            lsCEntidadRGP.Add(oCamposDet);
                        }
                    }
                }
                return lsCEntidadRGP;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<CEntidad> ReporteGraficoCCNN(OracleConnection cn, String codCapacitacion)
        {
            List<CEntidad> lsCEntidadRGP = new List<CEntidad>();
            CEntidad oCamposDet = new CEntidad();
            //List<Dictionary<string, string>> lstResult = new List<Dictionary<string, string>>();

            try
            {
                //using (SqlDataReader dr = oGDataSQL.SelDrdDefault(cn, null, "DOC.spCAPACITACIONRepNC", oCEntidad))
                //using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spReporteCapacitacionGenero", codCapacitacion))
                using (OracleDataReader dr = dBOracle.SelDrdDefaultPart(cn, null, "DOC_OSINFOR_ERP_MIGRACION.SPREPORTECAPACITACIONCCNN", codCapacitacion))
                {

                    //dr.NextResult();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            oCamposDet = new CEntidad();
                            oCamposDet.COD_CAPACITACION = dr["COD_CAPACITACION"].ToString();
                            oCamposDet.COD_CCNN = dr["COD_CCNN"].ToString();
                            oCamposDet.P_CHECK_BUENO = decimal.Parse(dr["P_CHECK_BUENO"].ToString());
                            lsCEntidadRGP.Add(oCamposDet);
                        }
                    }
                }
                return lsCEntidadRGP;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<CEntidad> ReporteGraficoCCNNMemoria(OracleConnection cn, String codCapacitacion)
        {
            List<CEntidad> lsCEntidadRGP = new List<CEntidad>();
            CEntidad oCamposDet = new CEntidad();
            //List<Dictionary<string, string>> lstResult = new List<Dictionary<string, string>>();

            try
            {
                //using (SqlDataReader dr = oGDataSQL.SelDrdDefault(cn, null, "DOC.spCAPACITACIONRepNC", oCEntidad))
                //using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spReporteCapacitacionGenero", codCapacitacion))
                using (OracleDataReader dr = dBOracle.SelDrdDefaultPart(cn, null, "DOC_OSINFOR_ERP_MIGRACION.SPREPORTECAPACITACIONCCNN", codCapacitacion))
                {

                    //dr.NextResult();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            oCamposDet = new CEntidad();
                            oCamposDet.COD_CAPACITACION = dr["COD_CAPACITACION"].ToString();
                            oCamposDet.COD_CCNN = dr["COD_CCNN"].ToString();
                            oCamposDet.P_CHECK_BUENO = decimal.Parse(dr["P_CHECK_BUENO"].ToString());
                            lsCEntidadRGP.Add(oCamposDet);
                        }
                    }
                }
                return lsCEntidadRGP;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<CEntidad> ReporteGraficoETNIA(OracleConnection cn, String codCapacitacion)
        {
            List<CEntidad> lsCEntidadRGP = new List<CEntidad>();
            CEntidad oCamposDet = new CEntidad();
            //List<Dictionary<string, string>> lstResult = new List<Dictionary<string, string>>();

            try
            {
                //using (SqlDataReader dr = oGDataSQL.SelDrdDefault(cn, null, "DOC.spCAPACITACIONRepNC", oCEntidad))
                //using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spReporteCapacitacionGenero", codCapacitacion))
                using (OracleDataReader dr = dBOracle.SelDrdDefaultPart(cn, null, "DOC_OSINFOR_ERP_MIGRACION.SPREPORTECAPACITACIONETNIA", codCapacitacion))
                {

                    //dr.NextResult();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            oCamposDet = new CEntidad();
                            oCamposDet.COD_CAPACITACION = dr["COD_CAPACITACION"].ToString();
                            oCamposDet.ETNIA = dr["ETNIA"].ToString();
                            oCamposDet.P_CHECK_BUENO = decimal.Parse(dr["P_CHECK_BUENO"].ToString());
                            lsCEntidadRGP.Add(oCamposDet);
                        }
                    }
                }
                return lsCEntidadRGP;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<CEntidad> ReporteGraficoETNIAMemoria(OracleConnection cn, String codCapacitacion)
        {
            List<CEntidad> lsCEntidadRGP = new List<CEntidad>();
            CEntidad oCamposDet = new CEntidad();
            //List<Dictionary<string, string>> lstResult = new List<Dictionary<string, string>>();

            try
            {
                //using (SqlDataReader dr = oGDataSQL.SelDrdDefault(cn, null, "DOC.spCAPACITACIONRepNC", oCEntidad))
                //using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spReporteCapacitacionGenero", codCapacitacion))
                using (OracleDataReader dr = dBOracle.SelDrdDefaultPart(cn, null, "DOC_OSINFOR_ERP_MIGRACION.SPREPORTECAPACITACIONETNIA", codCapacitacion))
                {

                    //dr.NextResult();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            oCamposDet = new CEntidad();
                            oCamposDet.COD_CAPACITACION = dr["COD_CAPACITACION"].ToString();
                            oCamposDet.ETNIA = dr["ETNIA"].ToString();
                            oCamposDet.P_CHECK_BUENO = decimal.Parse(dr["P_CHECK_BUENO"].ToString());
                            lsCEntidadRGP.Add(oCamposDet);
                        }
                    }
                }
                return lsCEntidadRGP;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<CEntidad> ReporteGraficoTHAB(OracleConnection cn, String codCapacitacion)
        {
            List<CEntidad> lsCEntidadRGP = new List<CEntidad>();
            CEntidad oCamposDet = new CEntidad();
            //List<Dictionary<string, string>> lstResult = new List<Dictionary<string, string>>();

            try
            {
                //using (SqlDataReader dr = oGDataSQL.SelDrdDefault(cn, null, "DOC.spCAPACITACIONRepNC", oCEntidad))
                //using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spReporteCapacitacionGenero", codCapacitacion))
                using (OracleDataReader dr = dBOracle.SelDrdDefaultPart(cn, null, "DOC_OSINFOR_ERP_MIGRACION.SPREPORTECAPACITACIONTHAB", codCapacitacion))
                {

                    //dr.NextResult();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            oCamposDet = new CEntidad();
                            oCamposDet.COD_CAPACITACION = dr["COD_CAPACITACION"].ToString();
                            oCamposDet.COD_THABILITANTE = dr["COD_THABILITANTE"].ToString();
                            oCamposDet.P_CHECK_BUENO = decimal.Parse(dr["P_CHECK_BUENO"].ToString());
                            lsCEntidadRGP.Add(oCamposDet);
                        }
                    }
                }
                return lsCEntidadRGP;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<CEntidad> ReporteGraficoTHABMemoria(OracleConnection cn, String codCapacitacion)
        {
            List<CEntidad> lsCEntidadRGP = new List<CEntidad>();
            CEntidad oCamposDet = new CEntidad();
            //List<Dictionary<string, string>> lstResult = new List<Dictionary<string, string>>();

            try
            {
                //using (SqlDataReader dr = oGDataSQL.SelDrdDefault(cn, null, "DOC.spCAPACITACIONRepNC", oCEntidad))
                //using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spReporteCapacitacionGenero", codCapacitacion))
                using (OracleDataReader dr = dBOracle.SelDrdDefaultPart(cn, null, "DOC_OSINFOR_ERP_MIGRACION.SPREPORTECAPACITACIONTHAB", codCapacitacion))
                {

                    //dr.NextResult();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            oCamposDet = new CEntidad();
                            oCamposDet.COD_CAPACITACION = dr["COD_CAPACITACION"].ToString();
                            oCamposDet.COD_THABILITANTE = dr["COD_THABILITANTE"].ToString();
                            oCamposDet.P_CHECK_BUENO = decimal.Parse(dr["P_CHECK_BUENO"].ToString());
                            lsCEntidadRGP.Add(oCamposDet);
                        }
                    }
                }
                return lsCEntidadRGP;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<CEntidad> ReporteGraficoCORREO(OracleConnection cn, String codCapacitacion)
        {
            List<CEntidad> lsCEntidadRGP = new List<CEntidad>();
            CEntidad oCamposDet = new CEntidad();
            //List<Dictionary<string, string>> lstResult = new List<Dictionary<string, string>>();

            try
            {
                //using (SqlDataReader dr = oGDataSQL.SelDrdDefault(cn, null, "DOC.spCAPACITACIONRepNC", oCEntidad))
                //using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spReporteCapacitacionGenero", codCapacitacion))
                using (OracleDataReader dr = dBOracle.SelDrdDefaultPart(cn, null, "DOC_OSINFOR_ERP_MIGRACION.SPREPORTECAPACITACIONCORREO", codCapacitacion))
                {

                    //dr.NextResult();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            oCamposDet = new CEntidad();
                            oCamposDet.COD_CAPACITACION = dr["COD_CAPACITACION"].ToString();
                            oCamposDet.CORREO = dr["CORREO"].ToString();
                            oCamposDet.P_CHECK_BUENO = decimal.Parse(dr["P_CHECK_BUENO"].ToString());
                            lsCEntidadRGP.Add(oCamposDet);
                        }
                    }
                }
                return lsCEntidadRGP;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<CEntidad> ReporteGraficoCORREOMemoria(OracleConnection cn, String codCapacitacion)
        {
            List<CEntidad> lsCEntidadRGP = new List<CEntidad>();
            CEntidad oCamposDet = new CEntidad();
            //List<Dictionary<string, string>> lstResult = new List<Dictionary<string, string>>();

            try
            {
                //using (SqlDataReader dr = oGDataSQL.SelDrdDefault(cn, null, "DOC.spCAPACITACIONRepNC", oCEntidad))
                //using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spReporteCapacitacionGenero", codCapacitacion))
                using (OracleDataReader dr = dBOracle.SelDrdDefaultPart(cn, null, "DOC_OSINFOR_ERP_MIGRACION.SPREPORTECAPACITACIONCORREO", codCapacitacion))
                {

                    //dr.NextResult();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            oCamposDet = new CEntidad();
                            oCamposDet.COD_CAPACITACION = dr["COD_CAPACITACION"].ToString();
                            oCamposDet.CORREO = dr["CORREO"].ToString();
                            oCamposDet.P_CHECK_BUENO = decimal.Parse(dr["P_CHECK_BUENO"].ToString());
                            lsCEntidadRGP.Add(oCamposDet);
                        }
                    }
                }
                return lsCEntidadRGP;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<CEntidad> ReporteGraficoNOTA(OracleConnection cn, String codCapacitacion)
        {
            List<CEntidad> lsCEntidadRGP = new List<CEntidad>();
            CEntidad oCamposDet = new CEntidad();

            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefaultPart(cn, null, "DOC_OSINFOR_ERP_MIGRACION.SPREPORTECAPACITACIONNOTA", codCapacitacion))
                {

                    //dr.NextResult();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            oCamposDet = new CEntidad();
                            oCamposDet.COD_CAPACITACION = dr["COD_CAPACITACION"].ToString();
                            oCamposDet.CORREO = dr["CORREO"].ToString();
                            oCamposDet.P_CHECK_BUENO = decimal.Parse(dr["P_CHECK_BUENO"].ToString());
                            lsCEntidadRGP.Add(oCamposDet);
                        }
                    }
                }
                return lsCEntidadRGP;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<CEntidad> ReporteGraficoNOTAMemoria(OracleConnection cn, String codCapacitacion)
        {
            List<CEntidad> lsCEntidadRGP = new List<CEntidad>();
            CEntidad oCamposDet = new CEntidad();

            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefaultPart(cn, null, "DOC_OSINFOR_ERP_MIGRACION.SPREPORTECAPACITACIONNOTA", codCapacitacion))
                {

                    //dr.NextResult();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            oCamposDet = new CEntidad();
                            oCamposDet.COD_CAPACITACION = dr["COD_CAPACITACION"].ToString();
                            oCamposDet.CORREO = dr["CORREO"].ToString();
                            oCamposDet.P_CHECK_BUENO = decimal.Parse(dr["P_CHECK_BUENO"].ToString());
                            lsCEntidadRGP.Add(oCamposDet);
                        }
                    }
                }
                return lsCEntidadRGP;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<CEntidad> ReporteGraficoENCUESTA(OracleConnection cn, String codCapacitacion)
        {
            List<CEntidad> lsCEntidadRGP = new List<CEntidad>();
            CEntidad oCamposDet = new CEntidad();

            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefaultPart(cn, null, "DOC_OSINFOR_ERP_MIGRACION.SPREPORTECAPACITACIONENCUESTA", codCapacitacion))
                {

                    //dr.NextResult();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            oCamposDet = new CEntidad();
                            oCamposDet.COD_CAPACITACION = dr["COD_CAPACITACION"].ToString();
                            oCamposDet.CORREO = dr["CORREO"].ToString();
                            oCamposDet.P_CHECK_BUENO = decimal.Parse(dr["P_CHECK_BUENO"].ToString());
                            oCamposDet.P_CHECK_REGULAR = decimal.Parse(dr["P_CHECK_REGULAR"].ToString());
                            oCamposDet.P_CHECK_MALO = decimal.Parse(dr["P_CHECK_MALAS"].ToString());
                            lsCEntidadRGP.Add(oCamposDet);
                        }
                    }
                }
                return lsCEntidadRGP;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<CEntidad> ReporteGraficoENCUESTA_EI(OracleConnection cn, String codCapacitacion)
        {
            List<CEntidad> lsCEntidadRGP = new List<CEntidad>();
            CEntidad oCamposDet = new CEntidad();

            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefaultPart(cn, null, "DOC_OSINFOR_ERP_MIGRACION.SPREPORTECAPACITACIONENCUESTA_EI", codCapacitacion))
                {

                    //dr.NextResult();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            oCamposDet = new CEntidad();
                            oCamposDet.COD_CAPACITACION = dr["COD_CAPACITACION"].ToString();
                            oCamposDet.CORREO = dr["CORREO"].ToString();
                            oCamposDet.P_CHECK_BUENO = decimal.Parse(dr["P_CHECK_BUENO"].ToString());
                            oCamposDet.P_CHECK_REGULAR = decimal.Parse(dr["P_CHECK_REGULAR"].ToString());
                            oCamposDet.P_CHECK_MALO = decimal.Parse(dr["P_CHECK_MALAS"].ToString());
                            oCamposDet.RegNum_Orden = int.Parse(dr["ORDEN"].ToString());
                            oCamposDet.DES_PREGUNTA = dr["DES_PREGUNTA"].ToString();
                            lsCEntidadRGP.Add(oCamposDet);
                        }
                    }
                }
                return lsCEntidadRGP;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<CEntidad> ReporteGraficoENCUESTA_EF(OracleConnection cn, String codCapacitacion)
        {
            List<CEntidad> lsCEntidadRGP = new List<CEntidad>();
            CEntidad oCamposDet = new CEntidad();

            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefaultPart(cn, null, "DOC_OSINFOR_ERP_MIGRACION.SPREPORTECAPACITACIONENCUESTA_EF", codCapacitacion))
                {

                    //dr.NextResult();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            oCamposDet = new CEntidad();
                            oCamposDet.COD_CAPACITACION = dr["COD_CAPACITACION"].ToString();
                            oCamposDet.CORREO = dr["CORREO"].ToString();
                            oCamposDet.P_CHECK_BUENO = decimal.Parse(dr["P_CHECK_BUENO"].ToString());
                            oCamposDet.P_CHECK_REGULAR = decimal.Parse(dr["P_CHECK_REGULAR"].ToString());
                            oCamposDet.P_CHECK_MALO = decimal.Parse(dr["P_CHECK_MALAS"].ToString());
                            oCamposDet.RegNum_Orden = int.Parse(dr["ORDEN"].ToString());
                            oCamposDet.DES_PREGUNTA = dr["DES_PREGUNTA"].ToString();
                            lsCEntidadRGP.Add(oCamposDet);
                        }
                    }
                }
                return lsCEntidadRGP;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<CEntidad> ReporteNOTACONCEPTUAL(OracleConnection cn, String codCapacitacion)
        {
            List<CEntidad> lsCEntidadRGP = new List<CEntidad>();
            CEntidad oCamposDet = new CEntidad();

            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefaultPart(cn, null, "DOC_OSINFOR_ERP_MIGRACION.SPREPORTECAPACITACIONNOTACONCEPTUAL", codCapacitacion))
                {

                    //dr.NextResult();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            oCamposDet = new CEntidad();
                            oCamposDet.COD_CAPACITACION = dr["COD_CAPACITACION"].ToString();
                            oCamposDet.ANTECEDENTES = dr["ANTECEDENTES"].ToString();
                            oCamposDet.JUSTIFICACION = dr["JUSTIFICACION"].ToString();
                            oCamposDet.RESULTADOS_ESPERADOS = dr["RESULTADOS_ESPERADOS"].ToString();
                            oCamposDet.MATERIALES_EQUIPO = dr["MATERIALES_EQUIPO"].ToString();
                            oCamposDet.PUBLICO_OBJETIVO = dr["PUBLICO_OBJETIVO"].ToString();
                            oCamposDet.ORGANIZADOR = dr["ORGANIZADOR"].ToString();
                            oCamposDet.PROGRAMA = dr["PROGRAMA"].ToString();
                            oCamposDet.CRONOGRAMA = dr["CRONOGRAMA"].ToString();
                            oCamposDet.FECHA_INICIO = dr["FECHA_INICIO"].ToString();
                            oCamposDet.FECHA_TERMINO = dr["FECHA_TERMINO"].ToString();
                            oCamposDet.RESUMEN_INTERVENCIONES = dr["MODALIDAD"].ToString();
                            oCamposDet.RECOMENDACIONES = dr["TIPO_TALLER"].ToString();
                            oCamposDet.NOMBRE = dr["NOMBRE"].ToString();
                            oCamposDet.CONCLUSION = dr["DIRIGIDO"].ToString();
                            oCamposDet.DESCRIPCION = dr["LUGAR"].ToString();
                            oCamposDet.OBJETIVO = dr["OBJETIVO"].ToString();
                            oCamposDet.DESCRIPCION_EJECUTIVA = dr["EVENTO"].ToString();
                            lsCEntidadRGP.Add(oCamposDet);
                        }
                    }
                }
                return lsCEntidadRGP;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<CEntidad> ReporteMEMORIA(OracleConnection cn, String codCapacitacion)
        {
            List<CEntidad> lsCEntidadRGP = new List<CEntidad>();
            CEntidad oCamposDet = new CEntidad();

            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefaultPart(cn, null, "DOC_OSINFOR_ERP_MIGRACION.SPREPORTECAPACITACIONMEMORIA", codCapacitacion))
                {

                    //dr.NextResult();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            oCamposDet = new CEntidad();
                            oCamposDet.COD_CAPACITACION = dr["COD_CAPACITACION"].ToString();
                            oCamposDet.DESCRIPCION = dr["TITULO"].ToString();
                            oCamposDet.NOMBRE = dr["NOMBRE"].ToString();
                            oCamposDet.CORREO = dr["DIRIGIDO"].ToString();
                            oCamposDet.OBJETIVO = dr["OBJETIVO"].ToString();
                            oCamposDet.OBSERVACION = dr["ORGANIZADOR"].ToString();
                            oCamposDet.APELLIDOS_NOMBRES = dr["LUGAR"].ToString();
                            oCamposDet.PRESENTACION = dr["PRESENTACION"].ToString();
                            oCamposDet.ANTECEDENTES = dr["ANTECEDENTES"].ToString();
                            oCamposDet.CRONOGRAMA = dr["TIPO_TALLER"].ToString();
                            oCamposDet.NOMBRES_APELLIDOS = dr["MODALIDAD"].ToString();
                            oCamposDet.MATERIALES_EQUIPO = dr["MATERIALES_EQUIPO"].ToString();
                            oCamposDet.OBSERVACION_METODO = dr["OBSERVACION_METODO"].ToString();
                            oCamposDet.PUBLICO_OBJETIVO = dr["PUBLICO_OBJETIVO"].ToString();
                            oCamposDet.DESCRIPCION_PUBLICO = dr["EVENTO"].ToString();
                            oCamposDet.JUSTIFICACION = dr["MARCO"].ToString();
                            oCamposDet.PROGRAMA = dr["PROGRAMA"].ToString();
                            oCamposDet.RESULTADOS_ESPERADOS = dr["ORGANIZADOR_DETALLE"].ToString();
                            oCamposDet.CONCLUSION = dr["CONCLUSION"].ToString();
                            oCamposDet.RECOMENDACIONES = dr["RECOMENDACIONES"].ToString();
                            oCamposDet.DESCRIPCION_TEMAS = dr["ARCHIVO"].ToString();
                            oCamposDet.DESCRIPCION_EJECUTIVA = dr["DESCRIPCION_EJECUTIVA"].ToString();
                            oCamposDet.RESUMEN_INTERVENCIONES = dr["RESUMEN_INTERVENCIONES"].ToString();
                            oCamposDet.DESCRIPCION_TRABAJO = dr["DESCRIPCION_TRABAJO"].ToString();
                            lsCEntidadRGP.Add(oCamposDet);
                        }
                    }
                }
                return lsCEntidadRGP;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<CEntidad> ReporteMEMORIAPN(OracleConnection cn, String codCapacitacion)
        {
            List<CEntidad> lsCEntidadRGP = new List<CEntidad>();
            CEntidad oCamposDet = new CEntidad();

            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefaultPart(cn, null, "DOC_OSINFOR_ERP_MIGRACION.SPREPORTECAPACITACIONMEMORIAPN", codCapacitacion))
                {

                    //dr.NextResult();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            oCamposDet = new CEntidad();
                            oCamposDet.N_PARTICIPANTES = int.Parse(dr["ORDEN"].ToString());
                            oCamposDet.NOMBRE = dr["NOMBRE_APELLIDO"].ToString();
                            oCamposDet.GENERO = dr["GENERO"].ToString();
                            oCamposDet.DESCRIPCION = dr["AREA"].ToString();
                            lsCEntidadRGP.Add(oCamposDet);
                        }
                    }
                }
                return lsCEntidadRGP;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<CEntidad> ReporteMEMORIAPA(OracleConnection cn, String codCapacitacion)
        {
            List<CEntidad> lsCEntidadRGP = new List<CEntidad>();
            CEntidad oCamposDet = new CEntidad();

            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefaultPart(cn, null, "DOC_OSINFOR_ERP_MIGRACION.SPREPORTECAPACITACIONMEMORIAPA", codCapacitacion))
                {

                    //dr.NextResult();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            oCamposDet = new CEntidad();
                            oCamposDet.N_PARTICIPANTES = int.Parse(dr["ORDEN"].ToString());
                            oCamposDet.NOMBRE = dr["NOMBRE_APELLIDO"].ToString();
                            oCamposDet.GENERO = dr["GENERO"].ToString();
                            oCamposDet.DESCRIPCION = dr["FUNCION"].ToString();
                            lsCEntidadRGP.Add(oCamposDet);
                        }
                    }
                }
                return lsCEntidadRGP;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<CEntidad> ReporteMEMORIAPP(OracleConnection cn, String codCapacitacion)
        {
            List<CEntidad> lsCEntidadRGP = new List<CEntidad>();
            CEntidad oCamposDet = new CEntidad();

            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefaultPart(cn, null, "DOC_OSINFOR_ERP_MIGRACION.SPREPORTECAPACITACIONMEMORIAPP", codCapacitacion))
                {

                    //dr.NextResult();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            oCamposDet = new CEntidad();
                            oCamposDet.N_PARTICIPANTES = int.Parse(dr["ORDEN"].ToString());
                            oCamposDet.NOMBRE = dr["NOMBRE_APELLIDO"].ToString();
                            oCamposDet.GENERO = dr["GENERO"].ToString();
                            oCamposDet.DESCRIPCION = dr["INSTITUCION"].ToString();
                            lsCEntidadRGP.Add(oCamposDet);
                        }
                    }
                }
                return lsCEntidadRGP;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<CEntidad> ReporteMEMORIAProgramacion(OracleConnection cn, String codCapacitacion)
        {
            List<CEntidad> lsCEntidadRGP = new List<CEntidad>();
            CEntidad oCamposDet = new CEntidad();

            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefaultPart(cn, null, "DOC_OSINFOR_ERP_MIGRACION.SPREPORTECAPACITACIONMEMORIAPROG", codCapacitacion))
                {

                    //dr.NextResult();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            oCamposDet = new CEntidad();
                            oCamposDet.FECHA_PROGRAMA = dr["FECHA_PROGRAMA"].ToString();
                            oCamposDet.HORA = dr["HORA"].ToString();
                            oCamposDet.TEMA = dr["TEMA"].ToString();
                            oCamposDet.RESPONSABLE = dr["RESPONSABLE"].ToString();
                            lsCEntidadRGP.Add(oCamposDet);
                        }
                    }
                }
                return lsCEntidadRGP;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<CEntidad> ReporteMEMORIACronograma(OracleConnection cn, String codCapacitacion)
        {
            List<CEntidad> lsCEntidadRGP = new List<CEntidad>();
            CEntidad oCamposDet = new CEntidad();

            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefaultPart(cn, null, "DOC_OSINFOR_ERP_MIGRACION.SPREPORTECAPACITACIONMEMORIACRON", codCapacitacion))
                {

                    //dr.NextResult();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            oCamposDet = new CEntidad();
                            oCamposDet.ACTIVIDAD = dr["ACTIVIDAD"].ToString();
                            oCamposDet.FECHA_INICIO_CRONOGRAMA = dr["FECHA_INICIO_CRONOGRAMA"].ToString();
                            oCamposDet.FECHA_FIN_CRONOGRAMA = dr["FECHA_FIN_CRONOGRAMA"].ToString();
                            lsCEntidadRGP.Add(oCamposDet);
                        }
                    }
                }
                return lsCEntidadRGP;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CEntidadPDC> RepUniversoPDC(OracleConnection cn, CEntidad cEntidad)
        {
            List<CEntidadPDC> lsCEntidadRGP = new List<CEntidadPDC>();
            CEntidadPDC oCamposDet = new CEntidadPDC();

            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC_OSINFOR_ERP_MIGRACION.SPREPORTECAPACITACION_UNIVERSOPDC", cEntidad))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidadPDC();
                                oCamposDet.ID_REGISTRO = dr["ID_REGISTRO"].ToString();
                                oCamposDet.COD_THABILITANTE = dr["COD_THABILITANTE"].ToString();
                                oCamposDet.OFICINA_DESCONCENTRADA = dr["OFICINA_DESCONCENTRADA"].ToString();
                                oCamposDet.TITULO = dr["TITULO"].ToString();
                                oCamposDet.MODALIDAD = dr["MODALIDAD"].ToString();
                                oCamposDet.TITULAR = dr["TITULAR"].ToString();
                                oCamposDet.REP_LEGAL = dr["REP_LEGAL"].ToString();
                                oCamposDet.DEPARTAMENTO = dr["DEPARTAMENTO"].ToString();
                                oCamposDet.PROVINCIA = dr["PROVINCIA"].ToString();
                                oCamposDet.DISTRITO = dr["DISTRITO"].ToString();
                                oCamposDet.FECHA_VIGENCIA = dr["FECHA_VIGENCIA"].ToString();
                                oCamposDet.FECHA_CORTE = dr["FECHA_CORTE"].ToString();
                                oCamposDet.AREA = Decimal.Parse(dr["AREA"].ToString());
                                oCamposDet.ULTIMO_PLAN = dr["ULTIMO_PLAN"].ToString();
                                oCamposDet.ROJO = dr["ROJO"].ToString();
                                oCamposDet.VERDE = dr["VERDE"].ToString();
                                oCamposDet.ALERTA = dr["ALERTA"].ToString();
                                oCamposDet.PASPEQ = dr["PASPEQ"].ToString();
                                oCamposDet.PASPEQ_ENFOQUE = dr["PASPEQ_ENFOQUE"].ToString();
                                oCamposDet.FECHA_SUPERVISION = dr["FECHA_SUPERVISION"].ToString();
                                oCamposDet.S_VOL_APROB = Decimal.Parse(dr["S_VOL_APROB"].ToString());
                                oCamposDet.S_VOL_MOV = Decimal.Parse(dr["S_VOL_MOV"].ToString());
                                oCamposDet.S_VOL_INJUST = Decimal.Parse(dr["S_VOL_INJUST"].ToString());
                                oCamposDet.INFRACCIONES = dr["INFRACCIONES"].ToString();
                                oCamposDet.MULTAS = dr["MULTAS"].ToString();
                                oCamposDet.ESTADO_PAU = dr["ESTADO_PAU"].ToString();
                                oCamposDet.ESTADO_PAGO = dr["ESTADO_PAGO"].ToString();
                                oCamposDet.MODALIDAD_PAGO = dr["MODALIDAD_PAGO"].ToString();
                                oCamposDet.MEC_COMP = dr["MEC_COMP"].ToString();
                                oCamposDet.N_CAPACITACION = Decimal.Parse(dr["N_CAPACITACION"].ToString());
                                oCamposDet.FECHA_ULT_CAP = dr["FECHA_ULT_CAP"].ToString();
                                oCamposDet.TEMA_ULT_CAP = dr["TEMA_ULT_CAP"].ToString();
                                oCamposDet.TEMA_MOCHILA_CAP = dr["TEMA_MOCHILA_CAP"].ToString();
                                oCamposDet.TEMA_MOCHILA_ENT = dr["TEMA_MOCHILA_ENT"].ToString();
                                oCamposDet.PRIORIDAD = Decimal.Parse(dr["PRIORIDAD"].ToString());

                                lsCEntidadRGP.Add(oCamposDet);
                            }
                        }
                    }
                }
                return lsCEntidadRGP;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public VM_ReporteGeneral RepUniversoPDC_pag(OracleConnection cn, CEntidad cEntidad)
        {
            VM_ReporteGeneral result = new VM_ReporteGeneral();
            result.list_universoPDC = new List<CEntidadPDC>();
            CEntidadPDC oCamposDet = new CEntidadPDC();

            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.SPREPORTECAPACITACION_UNIVERSOPDC", cEntidad))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidadPDC();
                                oCamposDet.ID_REGISTRO = dr["ID_REGISTRO"].ToString();
                                oCamposDet.COD_THABILITANTE = dr["COD_THABILITANTE"].ToString();
                                oCamposDet.OFICINA_DESCONCENTRADA = dr["OFICINA_DESCONCENTRADA"].ToString();
                                oCamposDet.TITULO = dr["TITULO"].ToString();
                                oCamposDet.MODALIDAD = dr["MODALIDAD"].ToString();
                                oCamposDet.TITULAR = dr["TITULAR"].ToString();
                                oCamposDet.REP_LEGAL = dr["REP_LEGAL"].ToString();
                                oCamposDet.DEPARTAMENTO = dr["DEPARTAMENTO"].ToString();
                                oCamposDet.PROVINCIA = dr["PROVINCIA"].ToString();
                                oCamposDet.DISTRITO = dr["DISTRITO"].ToString();
                                oCamposDet.FECHA_VIGENCIA = dr["FECHA_VIGENCIA"].ToString();
                                oCamposDet.FECHA_CORTE = dr["FECHA_CORTE"].ToString();
                                oCamposDet.AREA = Decimal.Parse(dr["AREA"].ToString());
                                oCamposDet.ULTIMO_PLAN = dr["ULTIMO_PLAN"].ToString();
                                oCamposDet.ROJO = dr["ROJO"].ToString();
                                oCamposDet.VERDE = dr["VERDE"].ToString();
                                oCamposDet.ALERTA = dr["ALERTA"].ToString();
                                oCamposDet.PASPEQ = dr["PASPEQ"].ToString();
                                oCamposDet.PASPEQ_ENFOQUE = dr["PASPEQ_ENFOQUE"].ToString();
                                oCamposDet.FECHA_SUPERVISION = dr["FECHA_SUPERVISION"].ToString();
                                oCamposDet.S_VOL_APROB = Decimal.Parse(dr["S_VOL_APROB"].ToString());
                                oCamposDet.S_VOL_MOV = Decimal.Parse(dr["S_VOL_MOV"].ToString());
                                oCamposDet.S_VOL_INJUST = Decimal.Parse(dr["S_VOL_INJUST"].ToString());
                                oCamposDet.INFRACCIONES = dr["INFRACCIONES"].ToString();
                                oCamposDet.MULTAS = dr["MULTAS"].ToString();
                                oCamposDet.ESTADO_PAU = dr["ESTADO_PAU"].ToString();
                                oCamposDet.ESTADO_PAGO = dr["ESTADO_PAGO"].ToString();
                                oCamposDet.MODALIDAD_PAGO = dr["MODALIDAD_PAGO"].ToString();
                                oCamposDet.MEC_COMP = dr["MEC_COMP"].ToString();
                                oCamposDet.N_CAPACITACION = Decimal.Parse(dr["N_CAPACITACION"].ToString());
                                oCamposDet.FECHA_ULT_CAP = dr["FECHA_ULT_CAP"].ToString();
                                oCamposDet.TEMA_ULT_CAP = dr["TEMA_ULT_CAP"].ToString();
                                oCamposDet.TEMA_MOCHILA_CAP = dr["TEMA_MOCHILA_CAP"].ToString();
                                oCamposDet.TEMA_MOCHILA_ENT = dr["TEMA_MOCHILA_ENT"].ToString();
                                oCamposDet.PRIORIDAD = Decimal.Parse(dr["PRIORIDAD"].ToString());

                                result.list_universoPDC.Add(oCamposDet);
                            }
                        }
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                //oCampos = new Ent_INFORME_CONSULTA_LEGAL();
                                result.v_ROW_INDEX = Int32.Parse(dr["TOTALROW"].ToString());
                                //lsCEntidad.Add(oCampos);
                            }
                        }

                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Ent_ReportConsolidadoPDC> RepconsolidadoPDC(OracleConnection cn, CEntidad cEntidad)
        {
            List<Ent_ReportConsolidadoPDC> lsCEntidadRGP = new List<Ent_ReportConsolidadoPDC>();
            Ent_ReportConsolidadoPDC oCamposDet = new Ent_ReportConsolidadoPDC();

            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC_OSINFOR_ERP_MIGRACION.SPREPORTECAPACITACION_UNIVERSOPDC", cEntidad))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCamposDet = new Ent_ReportConsolidadoPDC();
                                oCamposDet.COD_MODALIDAD = dr["COD_MODALIDAD"].ToString();
                                oCamposDet.MODALIDAD = dr["MODALIDAD"].ToString();
                                oCamposDet.ATALAYA = Decimal.Parse(dr["'ATALAYA'"].ToString());
                                oCamposDet.CHICLAYO = Decimal.Parse(dr["'CHICLAYO'"].ToString());
                                oCamposDet.IQUITOS = Decimal.Parse(dr["'IQUITOS'"].ToString());
                                oCamposDet.LA_MERCED = Decimal.Parse(dr["'LA MERCED'"].ToString());
                                oCamposDet.PUCALLPA = Decimal.Parse(dr["'PUCALLPA'"].ToString());
                                oCamposDet.PUERTO_MALDONADO = Decimal.Parse(dr["'PUERTO MALDONADO'"].ToString());
                                oCamposDet.TARAPOTO = Decimal.Parse(dr["'TARAPOTO'"].ToString());
                                oCamposDet.SEDE_CENTRAL = Decimal.Parse(dr["'SEDE CENTRAL'"].ToString());
                                oCamposDet.TOTAL = oCamposDet.ATALAYA + oCamposDet.CHICLAYO + oCamposDet.IQUITOS + oCamposDet.LA_MERCED + oCamposDet.PUCALLPA + oCamposDet.PUERTO_MALDONADO + oCamposDet.TARAPOTO + oCamposDet.SEDE_CENTRAL;

                                lsCEntidadRGP.Add(oCamposDet);
                            }
                        }
                    }
                }
                return lsCEntidadRGP;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Ent_PDCImportPASPEQ> ImportPDC_PASPEQ(OracleConnection cn, CEntidad cEntidad)
        {
            List<Ent_PDCImportPASPEQ> lsCEntidadRGP = new List<Ent_PDCImportPASPEQ>();
            Ent_PDCImportPASPEQ oCamposDet = new Ent_PDCImportPASPEQ();

            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC_OSINFOR_ERP_MIGRACION.SPREPORTECAPACITACION_UNIVERSOPDC", cEntidad))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCamposDet = new Ent_PDCImportPASPEQ();
                                oCamposDet.ID_REGISTRO = Int32.Parse(dr["ID_REGISTRO"].ToString());
                                oCamposDet.COD_THABILITANTE = dr["COD_THABILITANTE"].ToString();
                                oCamposDet.TITULO = dr["TITULO"].ToString();
                                oCamposDet.ENFOQUE = dr["ENFOQUE"].ToString();
                                oCamposDet.MES = Int32.Parse(dr["MES"].ToString());
                                oCamposDet.MES_FOCALIZACION = dr["MES_FOCALIZACION"].ToString();
                                oCamposDet.ANIO = Int32.Parse(dr["ANIO"].ToString());
                                oCamposDet.ESTADO = Int32.Parse(dr["ESTADO"].ToString());

                                lsCEntidadRGP.Add(oCamposDet);
                            }

                        }
                    }
                }
                return lsCEntidadRGP;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Ent_PDCImportPASPEQ ImportPDC_PASPEQ_COUNT(OracleConnection cn, CEntidad cEntidad)
        {
            Ent_PDCImportPASPEQ oCamposDet = new Ent_PDCImportPASPEQ();

            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC_OSINFOR_ERP_MIGRACION.SPREPORTECAPACITACION_UNIVERSOPDC", cEntidad))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCamposDet = new Ent_PDCImportPASPEQ();
                                oCamposDet.v_ROW_INDEX = Int32.Parse(dr["totalRow"].ToString());
                            }

                        }
                    }
                }
                return oCamposDet;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Ent_PDCImportPASPEQ ImportPDC_PASPEQ_CAMBIAR_ESTADO(OracleConnection cn, CEntidad cEntidad)
        {
            Ent_PDCImportPASPEQ oCamposDet = new Ent_PDCImportPASPEQ();

            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC_OSINFOR_ERP_MIGRACION.SPREPORTPDC_IMPORT_ESTADO", cEntidad))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCamposDet = new Ent_PDCImportPASPEQ();
                                oCamposDet.TITULO = dr["REGISTRO"].ToString();
                            }

                        }
                    }
                }
                return oCamposDet;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        //09/07/2023 CAMBIAR ESTADO
        public Ent_PDCImportPASPEQ REPORTPDC_CAMBIAR_ESTADO_TALLER(OracleConnection cn, CEntidad cEntidad)
        {
            Ent_PDCImportPASPEQ oCamposDet = new Ent_PDCImportPASPEQ();

            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC_OSINFOR_ERP_MIGRACION.SPREPORTPDC_ESTADO_TALLER", cEntidad))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCamposDet = new Ent_PDCImportPASPEQ();
                                oCamposDet.TITULO = dr["REGISTRO"].ToString();
                            }

                        }
                    }
                }
                return oCamposDet;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// METODO QUE DEVUELVE EL LISTADO DEL TALLER CALCULADO
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="cEntidad"></param>
        /// <returns></returns>
        public List<CEntidadPDC> PDC_TALLERES(OracleConnection cn, CEntidad cEntidad)
        {
            List<CEntidadPDC> lsCEntidadRGP = new List<CEntidadPDC>();
            CEntidadPDC oCamposDet = new CEntidadPDC();

            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC_OSINFOR_ERP_MIGRACION.SPREPORTECAPACITACION_UNIVERSOPDC", cEntidad))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidadPDC();
                                oCamposDet.OFICINA_DESCONCENTRADA = dr["oficina_desconcentrada"].ToString();
                                oCamposDet.COD_MODALIDAD = dr["cod_modalidad"].ToString();
                                oCamposDet.MODALIDAD = dr["MODALIDAD"].ToString();
                                oCamposDet.TALLER = Decimal.Parse(dr["taller"].ToString());
                                oCamposDet.CAPACITABLE = dr["capacitable"].ToString();
                                oCamposDet.SUM_AREA = Decimal.Parse(dr["suma_area"].ToString());
                                oCamposDet.IDREGISTRO = Decimal.Parse(dr["count_th"].ToString());
                                oCamposDet.VOL_APROB = Decimal.Parse(dr["vol_aprob"].ToString());
                                oCamposDet.PASPEQ_COUNT = Decimal.Parse(dr["paspeq"].ToString());
                                oCamposDet.INFRACCIONES_COUNT = Decimal.Parse(dr["infracciones"].ToString());

                                lsCEntidadRGP.Add(oCamposDet);
                            }
                        }
                    }
                }
                return lsCEntidadRGP;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public String asignar_taller(OracleConnection cn, CEntidadPDC oCEntidad)
        {
            OracleTransaction tr = null;
            String OUTPUTPARAM01 = "";
            try
            {
                tr = cn.BeginTransaction();
                //Grabando Cabecera
                using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.SPREPORTPDC_ASIGNAR_TALLER", oCEntidad))
                {
                    cmd.ExecuteNonQuery();
                    OUTPUTPARAM01 = (String)cmd.Parameters["OUTPUTPARAM01"].Value;

                    if (OUTPUTPARAM01 == "0")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("Error al insertar los datos");
                    }
                    else
                    {
                        oCEntidad.ID_REGISTRO = OUTPUTPARAM01;
                    }
                }

                tr.Commit();
                return OUTPUTPARAM01;
            }
            catch (Exception ex)
            {
                if (tr != null)
                {
                    tr.Rollback();
                }
                throw ex;
            }
        }

        public String GuardarDatosPasPEQ(OracleConnection cn, Ent_PDCImportPASPEQ oCEntidad)
        {
            OracleTransaction tr = null;
            String OUTPUTPARAM01 = "";
            try
            {
                tr = cn.BeginTransaction();
                //Grabando Cabecera
                using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.SPREPORTPDC_IMPORT_GRABAR", oCEntidad))
                {
                    cmd.ExecuteNonQuery();
                    OUTPUTPARAM01 = (String)cmd.Parameters["OUTPUTPARAM01"].Value;
              
                    if (OUTPUTPARAM01 == "0")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("Error al insertar los datos");
                    }
  
                    /*else if (OUTPUTPARAM01 == "1")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("El Nombre de la Capacitación ya Existe");
                    }*/
              
                }
                //Reemplazando El Nuevo Codigo Creado
                if (oCEntidad.ESTADO == 1) //Nuevo
                {
                    oCEntidad.ID_REGISTRO = Int32.Parse(OUTPUTPARAM01);
                }

                tr.Commit();
                return OUTPUTPARAM01;
            }
            catch (Exception ex)
            {
                if (tr != null)
                {
                    tr.Rollback();
                }
                throw ex;
            }
        }

        #region "Gestión de constancias"


        public CEntidad ObtenerPorId(OracleConnection cn, CEntidad oCEntidad)
        {
            CEntidad oCampos = null;
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.SPCAPACITACION_CAPACITACION_OBTENER", oCEntidad))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            dr.Read();
                            oCampos = new CEntidad();
                            oCampos.COD_CAPACITACION = dr.GetString(dr.GetOrdinal("COD_CAPACITACION"));
                            oCampos.NOMBRE = dr.GetString(dr.GetOrdinal("NOMBRE"));
                            oCampos.COD_CAPATIPO = dr.GetString(dr.GetOrdinal("COD_CAPATIPO"));
                            oCampos.DIRIGIDO = dr.GetString(dr.GetOrdinal("DIRIGIDO"));
                            oCampos.CAPATIPO = dr.GetString(dr.GetOrdinal("TIPO"));
                            oCampos.COD_OD = dr.GetString(dr.GetOrdinal("COD_OD"));
                            oCampos.COD_DLINEA = dr.GetString(dr.GetOrdinal("COD_DLINEA"));
                            oCampos.COD_UBIGEO = dr.GetString(dr.GetOrdinal("COD_UBIGEO"));
                            oCampos.UBIGEO_DESCRIPCION = dr.GetString(dr.GetOrdinal("UBIGEO_DESCRIPCION"));
                            oCampos.SECTOR = dr.GetString(dr.GetOrdinal("SECTOR"));
                            oCampos.LUGAR = dr.GetString(dr.GetOrdinal("LUGAR"));
                            oCampos.FECHA_INICIO = dr.GetString(dr.GetOrdinal("FECHA_INICIO"));
                            oCampos.FECHA_TERMINO = dr.GetString(dr.GetOrdinal("FECHA_TERMINO"));
                            oCampos.N_PARTICIPANTES = dr.GetInt32(dr.GetOrdinal("N_PARTICIPANTES"));
                            oCampos.MARCO_CONVENIO = dr.GetBoolean(dr.GetOrdinal("MARCO_CONVENIO"));
                            oCampos.OBSERVACION = dr.GetString(dr.GetOrdinal("OBSERVACION"));
                            oCampos.DURACION = dr.GetInt32(dr.GetOrdinal("DURACION"));
                            oCampos.MAE_COD_ORGANIZADOR = dr.GetString(dr.GetOrdinal("MAE_COD_ORGANIZADOR"));
                            oCampos.ORGANIZADOR = dr.GetString(dr.GetOrdinal("ORGANIZADOR"));
                            oCampos.APOYO_COORGANIZ_DIFUSION = dr.GetBoolean(dr.GetOrdinal("APOYO_COORGANIZ_DIFUSION"));
                            oCampos.APOYO_COORGANIZ_FIRMA = dr.GetBoolean(dr.GetOrdinal("APOYO_COORGANIZ_FIRMA"));
                            oCampos.APOYO_COORGANIZ_LOGISTICO = dr.GetBoolean(dr.GetOrdinal("APOYO_COORGANIZ_LOGISTICO"));

                            oCampos.OBJETIVO = dr.GetString(dr.GetOrdinal("OBJETIVO"));
                            oCampos.DESCRIPCION_TEMAS = dr.GetString(dr.GetOrdinal("DESCRIPCION_TEMAS"));
                            oCampos.MAE_COD_METODO = dr.GetString(dr.GetOrdinal("MAE_COD_METODO"));
                            oCampos.OBSERVACION_METODO = dr.GetString(dr.GetOrdinal("OBSERVACION_METODO"));
                            oCampos.CONCLUSION = dr.GetString(dr.GetOrdinal("CONCLUSION"));
                            oCampos.SUMA_POI = dr.GetBoolean(dr.GetOrdinal("SUMA_POI"));
                            oCampos.ZONA_UTM = dr.GetString(dr.GetOrdinal("ZONA_UTM"));
                            oCampos.COORD_ESTE = dr.GetInt32(dr.GetOrdinal("COORD_ESTE"));
                            oCampos.COORD_NORTE = dr.GetInt32(dr.GetOrdinal("COORD_NORTE"));
                            oCampos.USUARIO_REGISTRO = dr.GetString(dr.GetOrdinal("USUARIO_REGISTRO"));

                            oCampos.ANTECEDENTES = dr.GetString(dr.GetOrdinal("ANTECEDENTES"));
                            oCampos.JUSTIFICACION = dr.GetString(dr.GetOrdinal("JUSTIFICACION"));
                            oCampos.RESULTADOS_ESPERADOS = dr.GetString(dr.GetOrdinal("RESULTADOS_ESPERADOS"));
                            oCampos.COD_MODALIDAD = dr.GetString(dr.GetOrdinal("COD_MODALIDAD"));
                            oCampos.MATERIALES_EQUIPO = dr.GetString(dr.GetOrdinal("MATERIALES_EQUIPO"));
                            oCampos.PUBLICO_OBJETIVO = dr.GetString(dr.GetOrdinal("PUBLICO_OBJETIVO"));
                            oCampos.CRONOGRAMA = dr.GetString(dr.GetOrdinal("CRONOGRAMA"));
                            oCampos.PROGRAMA = dr.GetString(dr.GetOrdinal("PROGRAMA"));

                            oCampos.PRESENTACION = dr.GetString(dr.GetOrdinal("PRESENTACION"));
                            oCampos.DESCRIPCION_EJECUTIVA = dr.GetString(dr.GetOrdinal("DESCRIPCION_EJECUTIVA"));
                            oCampos.RESUMEN_INTERVENCIONES = dr.GetString(dr.GetOrdinal("RESUMEN_INTERVENCIONES"));
                            oCampos.DESCRIPCION_TRABAJO = dr.GetString(dr.GetOrdinal("DESCRIPCION_TRABAJO"));
                            oCampos.RECOMENDACIONES = dr.GetString(dr.GetOrdinal("RECOMENDACIONES"));
                            oCampos.FECHA_CREACION = dr.GetString(dr.GetOrdinal("FECHA_CREACION"));
                        }
                    }
                }
                return oCampos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int ObtenerUltimoCorrelativoPorAnio(OracleConnection cn, string cod_capacitacion)
        {
            int correlativo = 0;

            try
            {
                object[] param = { cod_capacitacion };
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, "DOC_OSINFOR_ERP_MIGRACION.SPCAPACITACION_CONSTANCIA_OBTENER_CORRELATIVO", param))
                {
                    if (dr.HasRows)
                    {
                        dr.Read();
                        correlativo = int.Parse(dr["CORRELATIVO"].ToString());
                    }
                }
                return correlativo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string ObtenerAbreviatura(OracleConnection cn, string codTipoCapacitacion)
        {
            string abreviatura = string.Empty;

            try
            {
                object[] param = { codTipoCapacitacion };
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, "DOC_OSINFOR_ERP_MIGRACION.SPCAPACITACION_CONSTANCIA_OBTENER_ABREVIATURA", param))
                {
                    if (dr.HasRows)
                    {
                        dr.Read();
                        abreviatura = dr["ABREVIATURA"].ToString();
                    }
                }
                return abreviatura;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Ent_CAPACITACION_CONSTANCIA> ConstanciaListar(OracleConnection cn, string codCapacitacion, int flagActivo = 0)
        {
            List<Ent_CAPACITACION_CONSTANCIA> constancias = new List<Ent_CAPACITACION_CONSTANCIA>();
            Ent_CAPACITACION_CONSTANCIA constancia = null;

            try
            {
                object[] param = { codCapacitacion, flagActivo };
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, "DOC_OSINFOR_ERP_MIGRACION.SPCAPACITACION_CONSTANCIA_LISTAR", param))
                {
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            constancia = new Ent_CAPACITACION_CONSTANCIA();
                            constancia.COD_CONSTANCIA = dr["COD_CONSTANCIA"].ToString();
                            constancia.COD_CAPACITACION = dr["COD_CAPACITACION"].ToString();
                            constancia.MODALIDAD = dr["MODALIDAD"].ToString();
                            constancia.CORRELATIVO = Convert.ToInt32(dr["CORRELATIVO"]);
                            constancia.CORRELATIVO_ANIO = Convert.ToInt32(dr["CORRELATIVO_ANIO"]);
                            constancia.NRO_CONSTANCIA = dr["NRO_CONSTANCIA"].ToString();
                            constancia.ARCHIVO = dr["ARCHIVO"].ToString();
                            constancia.ARCHIVO_COD = dr["ARCHIVO_COD"].ToString();
                            constancia.FLAG_ASIGNADO = Convert.ToInt32(dr["FLAG_ASIGNADO"]);
                            constancia.ESTADO = Convert.ToInt32(dr["ESTADO"]);
                            constancia.ESTADO_TEXT = dr["ESTADO_TEXT"].ToString();
                            constancia.PARTICIPANTE = dr["PARTICIPANTE"].ToString();
                            constancias.Add(constancia);
                        }
                    }
                }
                return constancias;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Ent_CAPACITACION_CONSTANCIA ConstanciaObtener(OracleConnection cn, string codConstancia)
        {

            Ent_CAPACITACION_CONSTANCIA constancia = null;

            try
            {
                object[] param = { codConstancia };
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, "DOC_OSINFOR_ERP_MIGRACION.SPCAPACITACION_CONSTANCIA_OBTENER", param))
                {
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            constancia = new Ent_CAPACITACION_CONSTANCIA();
                            constancia.COD_CONSTANCIA = dr["COD_CONSTANCIA"].ToString();
                            constancia.COD_CAPACITACION = dr["COD_CAPACITACION"].ToString();
                            constancia.CORRELATIVO = Convert.ToInt32(dr["CORRELATIVO"]);
                            constancia.CORRELATIVO_ANIO = Convert.ToInt32(dr["CORRELATIVO_ANIO"]);
                            constancia.NRO_CONSTANCIA = dr["NRO_CONSTANCIA"].ToString();
                            constancia.MODALIDAD = dr["MODALIDAD"].ToString();
                            constancia.ARCHIVO = dr["ARCHIVO"].ToString();
                            constancia.ARCHIVO_COD = dr["ARCHIVO_COD"].ToString();
                            constancia.FLAG_ASIGNADO = Convert.ToInt32(dr["FLAG_ASIGNADO"]);
                            constancia.ESTADO = Convert.ToInt32(dr["ESTADO"]);
                            constancia.ESTADO_TEXT = dr["ESTADO_TEXT"].ToString();
                        }
                    }
                }
                return constancia;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Ent_CAPACITACION_CONSTANCIA ConstanciaObtenerPorNroConstancia(OracleConnection cn, string nroConstancia)
        {

            Ent_CAPACITACION_CONSTANCIA constancia = null;

            try
            {
                object[] param = { nroConstancia };
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, "DOC_OSINFOR_ERP_MIGRACION.SPCAPACITACION_CONSTANCIA_OBTENER_NRO", param))
                {
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            constancia = new Ent_CAPACITACION_CONSTANCIA();
                            constancia.COD_CONSTANCIA = dr["COD_CONSTANCIA"].ToString();
                            constancia.COD_CAPACITACION = dr["COD_CAPACITACION"].ToString();
                            constancia.CORRELATIVO = Convert.ToInt32(dr["CORRELATIVO"]);
                            constancia.CORRELATIVO_ANIO = Convert.ToInt32(dr["CORRELATIVO_ANIO"]);
                            constancia.NRO_CONSTANCIA = dr["NRO_CONSTANCIA"].ToString();
                            constancia.MODALIDAD = dr["MODALIDAD"].ToString();
                            constancia.ARCHIVO = dr["ARCHIVO"].ToString();
                            constancia.ARCHIVO_COD = dr["ARCHIVO_COD"].ToString();
                            constancia.FLAG_ASIGNADO = Convert.ToInt32(dr["FLAG_ASIGNADO"]);
                            constancia.ESTADO = Convert.ToInt32(dr["ESTADO"]);
                            constancia.ESTADO_TEXT = dr["ESTADO_TEXT"].ToString();
                        }
                    }
                }
                return constancia;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool ConstanciaInsertarMasivo(List<Ent_CAPACITACION_CONSTANCIA> constancias)
        {


            OracleTransaction tr = null;
            using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
            {
                cn.Open();
                tr = cn.BeginTransaction();
                try
                {

                    foreach (var item in constancias)
                    {
                        object[] param = { item.COD_CAPACITACION, item.CORRELATIVO, item.CORRELATIVO_ANIO, item.NRO_CONSTANCIA, item.MODALIDAD, item.ARCHIVO, item.ARCHIVO_COD, item.COD_UCUENTA, item.FECHA_CREACION, item.ESTADO };
                        dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.SPCAPACITACION_CONSTANCIA_INSERTAR", param);
                    }
                    tr.Commit();
                }
                catch (Exception ex)
                {
                    if (tr != null)
                    {
                        tr.Rollback();
                        tr.Dispose();
                        tr = null;
                    }
                    throw ex;
                }

            }
            return true;
        }
        public bool ConstanciaEliminar(string codConstancia, string codUsuario)
        {
            OracleTransaction tr = null;
            using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
            {
                cn.Open();
                tr = cn.BeginTransaction();
                try
                {
                    object[] param = { codConstancia, codUsuario };
                    dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.SPCAPACITACION_CONSTANCIA_ELIMINAR", param);
                    tr.Commit();
                }
                catch (Exception ex)
                {
                    if (tr != null)
                    {
                        tr.Rollback();
                        tr.Dispose();
                        tr = null;
                    }
                    throw ex;
                }

            }
            return true;
        }
        public List<CEntidad> ParticipanteListar(OracleConnection cn, string codCapacitacion, string codTipoParticipante, string persona)
        {
            List<CEntidad> result = new List<CEntidad>();
            CEntidad oCamposDet = null;

            try
            {
                object[] param = { codCapacitacion, codTipoParticipante, persona };
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, "DOC_OSINFOR_ERP_MIGRACION.SPCAPACITACION_PARTICIPANTES_LISTAR", param))
                {
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            oCamposDet = new CEntidad();
                            oCamposDet.COD_CAPACITACION = dr["COD_CAPACITACION"].ToString();
                            oCamposDet.COD_PERSONA = dr["COD_PERSONA"].ToString();
                            oCamposDet.MAE_COD_TIPOPARTICIPANTE = dr["MAE_COD_TIPOPARTICIPANTE"].ToString();
                            oCamposDet.N_DOCUMENTO = dr["N_DOCUMENTO"].ToString();
                            oCamposDet.APE_PATERNO = dr["APE_PATERNO"].ToString();
                            oCamposDet.APE_MATERNO = dr["APE_MATERNO"].ToString();
                            oCamposDet.NOMBRES = dr["NOMBRES"].ToString();
                            oCamposDet.APELLIDOS_NOMBRES = dr["APELLIDOS_NOMBRES"].ToString();
                            oCamposDet.COD_INSTITUCION = dr["COD_INSTITUCION"].ToString();
                            oCamposDet.NOM_INSTITUCION = dr["NOM_INSTITUCION"].ToString();
                            oCamposDet.CARGO = dr["CARGO"].ToString();
                            oCamposDet.GENERO = dr["GENERO"].ToString();
                            oCamposDet.EDAD = int.Parse(dr["EDAD"].ToString());
                            oCamposDet.TELEFONO = dr["TELEFONO"].ToString();
                            oCamposDet.CORREO = dr["CORREO"].ToString();
                            oCamposDet.OBSERVACION = dr["OBSERVACION"].ToString();
                            oCamposDet.COD_CONSTANCIA = dr["COD_CONSTANCIA"].ToString();
                            oCamposDet.FUNCION = dr["FUNCION"].ToString();
                            oCamposDet.COD_CCNN = dr.GetString(dr.GetOrdinal("COD_CCNN"));
                            oCamposDet.CCNN = dr.GetString(dr.GetOrdinal("CCNN"));
                            oCamposDet.ETNIA = dr.GetString(dr.GetOrdinal("ETNIA"));
                            oCamposDet.COD_THABILITANTE = dr.GetString(dr.GetOrdinal("COD_THABILITANTE"));
                            oCamposDet.NUM_THABILITANTE = dr.GetString(dr.GetOrdinal("NUM_THABILITANTE"));
                            oCamposDet.MAE_COD_GRUPOPUBLICOPARTICIPANTE = dr.GetString(dr.GetOrdinal("MAE_COD_GRUPOPUBLICOPARTICIPANTE"));
                            oCamposDet.GRUPOPUBLICOPARTICIPANTE = dr.GetString(dr.GetOrdinal("GRUPOPUBLICOPARTICIPANTE"));
                            oCamposDet.MAE_COD_PUBLICOPARTICIPANTE = dr.GetString(dr.GetOrdinal("MAE_COD_PUBLICOPARTICIPANTE"));
                            oCamposDet.PUBLICOPARTICIPANTE = dr.GetString(dr.GetOrdinal("PUBLICOPARTICIPANTE"));
                            oCamposDet.FECHA_CREACION = dr.GetString(dr.GetOrdinal("FECHA_CREACION"));
                            oCamposDet.MOCHILAFORESTAL = dr.GetString(dr.GetOrdinal("MOCHILAFORESTAL"));
                            oCamposDet.COD_CONSTANCIA_CAP = dr["COD_CONSTANCIA_CAP"].ToString();
                            oCamposDet.NRO_CONSTANCIA = dr["NRO_CONSTANCIA"].ToString();
                            result.Add(oCamposDet);
                        }
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public CEntidad ParticipanteObtener(OracleConnection cn, string codCapacitacion, string codTipoParticipante, string codPersona)
        {

            CEntidad oCamposDet = null;

            try
            {
                object[] param = { codCapacitacion, codTipoParticipante, codPersona };
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, "DOC_OSINFOR_ERP_MIGRACION.SPCAPACITACION_PARTICIPANTES_OBTENER", param))
                {
                    if (dr.HasRows)
                    {
                        dr.Read();
                        oCamposDet = new CEntidad();
                        oCamposDet.COD_CAPACITACION = dr["COD_CAPACITACION"].ToString();
                        oCamposDet.COD_PERSONA = dr["COD_PERSONA"].ToString();
                        oCamposDet.MAE_COD_TIPOPARTICIPANTE = dr["MAE_COD_TIPOPARTICIPANTE"].ToString();
                        oCamposDet.N_DOCUMENTO = dr["N_DOCUMENTO"].ToString();
                        oCamposDet.APE_PATERNO = dr["APE_PATERNO"].ToString();
                        oCamposDet.APE_MATERNO = dr["APE_MATERNO"].ToString();
                        oCamposDet.NOMBRES = dr["NOMBRES"].ToString();
                        oCamposDet.APELLIDOS_NOMBRES = dr["APELLIDOS_NOMBRES"].ToString();
                        oCamposDet.COD_INSTITUCION = dr["COD_INSTITUCION"].ToString();
                        oCamposDet.NOM_INSTITUCION = dr["NOM_INSTITUCION"].ToString();
                        oCamposDet.CARGO = dr["CARGO"].ToString();
                        oCamposDet.GENERO = dr["GENERO"].ToString();
                        oCamposDet.EDAD = int.Parse(dr["EDAD"].ToString());
                        oCamposDet.TELEFONO = dr["TELEFONO"].ToString();
                        oCamposDet.CORREO = dr["CORREO"].ToString();
                        oCamposDet.OBSERVACION = dr["OBSERVACION"].ToString();
                        oCamposDet.COD_CONSTANCIA = dr["COD_CONSTANCIA"].ToString();
                        oCamposDet.FUNCION = dr["FUNCION"].ToString();
                        oCamposDet.COD_CCNN = dr.GetString(dr.GetOrdinal("COD_CCNN"));
                        oCamposDet.CCNN = dr.GetString(dr.GetOrdinal("CCNN"));
                        oCamposDet.ETNIA = dr.GetString(dr.GetOrdinal("ETNIA"));
                        oCamposDet.COD_THABILITANTE = dr.GetString(dr.GetOrdinal("COD_THABILITANTE"));
                        oCamposDet.NUM_THABILITANTE = dr.GetString(dr.GetOrdinal("NUM_THABILITANTE"));
                        oCamposDet.MAE_COD_GRUPOPUBLICOPARTICIPANTE = dr.GetString(dr.GetOrdinal("MAE_COD_GRUPOPUBLICOPARTICIPANTE"));
                        oCamposDet.GRUPOPUBLICOPARTICIPANTE = dr.GetString(dr.GetOrdinal("GRUPOPUBLICOPARTICIPANTE"));
                        oCamposDet.MAE_COD_PUBLICOPARTICIPANTE = dr.GetString(dr.GetOrdinal("MAE_COD_PUBLICOPARTICIPANTE"));
                        oCamposDet.PUBLICOPARTICIPANTE = dr.GetString(dr.GetOrdinal("PUBLICOPARTICIPANTE"));
                        oCamposDet.FECHA_CREACION = dr.GetString(dr.GetOrdinal("FECHA_CREACION"));
                        oCamposDet.MOCHILAFORESTAL = dr.GetString(dr.GetOrdinal("MOCHILAFORESTAL"));
                        oCamposDet.COD_CONSTANCIA_CAP = dr["COD_CONSTANCIA_CAP"].ToString();
                    }
                }
                return oCamposDet;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public CEntidad ParticipanteObtenerPorConstancia(OracleConnection cn,string codCapacitacion, string codConstancia)
        {

            CEntidad oCamposDet = null;

            try
            {
                object[] param = { codCapacitacion,codConstancia };
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, "DOC_OSINFOR_ERP_MIGRACION.SPCAPACITACION_PARTICIPANTES_OBTENER_POR_CONSTANCIA", param))
                {
                    if (dr.HasRows)
                    {
                        dr.Read();
                        oCamposDet = new CEntidad();
                        oCamposDet.COD_CAPACITACION = dr["COD_CAPACITACION"].ToString();
                        oCamposDet.COD_PERSONA = dr["COD_PERSONA"].ToString();
                        oCamposDet.MAE_COD_TIPOPARTICIPANTE = dr["MAE_COD_TIPOPARTICIPANTE"].ToString();
                        oCamposDet.N_DOCUMENTO = dr["N_DOCUMENTO"].ToString();
                        oCamposDet.APE_PATERNO = dr["APE_PATERNO"].ToString();
                        oCamposDet.APE_MATERNO = dr["APE_MATERNO"].ToString();
                        oCamposDet.NOMBRES = dr["NOMBRES"].ToString();
                        oCamposDet.APELLIDOS_NOMBRES = dr["APELLIDOS_NOMBRES"].ToString();
                        oCamposDet.COD_INSTITUCION = dr["COD_INSTITUCION"].ToString();
                        oCamposDet.NOM_INSTITUCION = dr["NOM_INSTITUCION"].ToString();
                        oCamposDet.CARGO = dr["CARGO"].ToString();
                        oCamposDet.GENERO = dr["GENERO"].ToString();
                        oCamposDet.EDAD = int.Parse(dr["EDAD"].ToString());
                        oCamposDet.TELEFONO = dr["TELEFONO"].ToString();
                        oCamposDet.CORREO = dr["CORREO"].ToString();
                        oCamposDet.OBSERVACION = dr["OBSERVACION"].ToString();
                        oCamposDet.COD_CONSTANCIA = dr["COD_CONSTANCIA"].ToString();
                        oCamposDet.FUNCION = dr["FUNCION"].ToString();
                        oCamposDet.COD_CCNN = dr.GetString(dr.GetOrdinal("COD_CCNN"));
                        oCamposDet.CCNN = dr.GetString(dr.GetOrdinal("CCNN"));
                        oCamposDet.ETNIA = dr.GetString(dr.GetOrdinal("ETNIA"));
                        oCamposDet.COD_THABILITANTE = dr.GetString(dr.GetOrdinal("COD_THABILITANTE"));
                        oCamposDet.NUM_THABILITANTE = dr.GetString(dr.GetOrdinal("NUM_THABILITANTE"));
                        oCamposDet.MAE_COD_GRUPOPUBLICOPARTICIPANTE = dr.GetString(dr.GetOrdinal("MAE_COD_GRUPOPUBLICOPARTICIPANTE"));
                        oCamposDet.GRUPOPUBLICOPARTICIPANTE = dr.GetString(dr.GetOrdinal("GRUPOPUBLICOPARTICIPANTE"));
                        oCamposDet.MAE_COD_PUBLICOPARTICIPANTE = dr.GetString(dr.GetOrdinal("MAE_COD_PUBLICOPARTICIPANTE"));
                        oCamposDet.PUBLICOPARTICIPANTE = dr.GetString(dr.GetOrdinal("PUBLICOPARTICIPANTE"));
                        oCamposDet.FECHA_CREACION = dr.GetString(dr.GetOrdinal("FECHA_CREACION"));
                        oCamposDet.MOCHILAFORESTAL = dr.GetString(dr.GetOrdinal("MOCHILAFORESTAL"));
                        oCamposDet.COD_CONSTANCIA_CAP = dr["COD_CONSTANCIA_CAP"].ToString();
                    }
                }
                return oCamposDet;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool ParticipanteAsignarConstancia(string codCapacitacion, string codTipoParticipante, string codPersona, string codConstancia, string archivoCod, string usuarioMoficiacion, DateTime fechaModificar)
        {
            OracleTransaction tr = null;
            using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
            {
                cn.Open();
                tr = cn.BeginTransaction();
                try
                {
                    object[] param = { codCapacitacion, codTipoParticipante, codPersona, codConstancia, archivoCod, usuarioMoficiacion, fechaModificar };
                    dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.SPCAPACITACION_PARTICIPANTE_ASIGNAR", param);
                    tr.Commit();
                }
                catch (Exception ex)
                {
                    if (tr != null)
                    {
                        tr.Rollback();
                        tr.Dispose();
                        tr = null;
                    }
                    throw ex;
                }

            }
            return true;
        }
        #endregion

    }
}
