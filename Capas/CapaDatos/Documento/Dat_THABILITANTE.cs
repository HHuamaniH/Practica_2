using CapaEntidad.DOC;
using GeneralSQL;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using CEntidad = CapaEntidad.DOC.Ent_THABILITANTE;
using SQL = GeneralSQL.Data.SQL;

/// <summary>
/// 2014-08-14  EPB Se modifica el codigo para considerar las consultas, modificaciones y borrados de vertices con el campo COD_SECUENCIAL como VERT_COD_SECUENCIAL
/// 2014-08-18  EPB Se modifica el codigo para considerar consultas, modificaciones y borrados sobre la tabla DOC.THABILITANTE_DGENERAL_ADENDA_AREA
/// </summary>
namespace CapaDatos.DOC
{
    public class Dat_THABILITANTE
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
                CEntidad CentBus = new CEntidad();
                CentBus.COD_THABILITANTE = oCEntidad.COD_THABILITANTE;
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "doc_osinfor_erp_migracion.spTHABILITANTEMostItems", CentBus))
                {
                    if (dr != null)
                    {
                        oCampos.ListTDTTITULARES = new List<CEntidad>();
                        oCampos.ListTDDVVERTICE = new List<CEntidad>();
                        oCampos.ListTDDVADEAREA = new List<CEntidad>();
                        oCampos.ListAdendas = new List<CEntidad>();
                        oCampos.ListEliTABLA = new List<CEntidad>();
                        oCampos.ListModalidadesTH = new List<CEntidad>();
                        oCampos.ListTHEstadoEsta = new List<CEntidad>();
                        oCampos.ListDependencia = new List<CEntidad>();
                        oCampos.ListErrorMaterialGeneral = new List<Ent_ERRORMATERIAL>();
                        oCampos.ListErrorMaterialAdicional = new List<Ent_ERRORMATERIAL>();
                        oCampos.ListTHExtincion = new List<CEntidad>();
                        oCampos.ListDivisionInterna = new List<Ent_DIVISIONINTERNA>();

                        CEntidad oCamposDet;
                        //
                        if (dr.HasRows)
                        {
                            dr.Read();
                            oCampos.COD_THABILITANTE = dr.GetString(dr.GetOrdinal("CODIGO_TITULO"));
                            oCampos.COD_MTIPO = dr.GetString(dr.GetOrdinal("COD_MTIPO"));
                            oCampos.COD_TITULAR = dr.GetString(dr.GetOrdinal("COD_TITULAR"));
                            oCampos.COD_RLEGAL = dr.GetString(dr.GetOrdinal("COD_RLEGAL"));
                            oCampos.NUMERO = dr.GetString(dr.GetOrdinal("NUMERO"));
                            oCampos.TIPO = dr.GetString(dr.GetOrdinal("TIPO"));
                            oCampos.ESTAB_COD_UBIGEO = dr.GetString(dr.GetOrdinal("ESTAB_COD_UBIGEO"));
                            oCampos.ESTAB_SECTOR = dr.GetString(dr.GetOrdinal("ESTAB_SECTOR"));
                            oCampos.OBSERVACION = dr.GetString(dr.GetOrdinal("OBSERVACION"));
                            oCampos.MODALIDAD = dr.GetString(dr.GetOrdinal("MODALIDAD"));
                            oCampos.PERSONA_TITULAR = dr.GetString(dr.GetOrdinal("PERSONA_TITULAR"));
                            oCampos.PERSONA_RLEGAL = dr.GetString(dr.GetOrdinal("PERSONA_RLEGAL"));
                            oCampos.ESTAB_UBIGEO = dr.GetString(dr.GetOrdinal("ESTAB_UBIGEO"));
                            oCampos.TIPO_PERSONA = dr.GetString(dr.GetOrdinal("TIPO_PERSONA"));
                            oCampos.MODALIDAD_EJURIDICO = dr.GetString(dr.GetOrdinal("MODALIDAD_EJURIDICO"));
                            oCampos.CLASE_ZOOLOGICO = dr.GetString(dr.GetOrdinal("CLASE_ZOOLOGICO"));
                            oCampos.CODIGO_NUMERO = dr.GetString(dr.GetOrdinal("CODIGO_NUMERO"));
                            oCampos.COD_CAT = dr.GetString(dr.GetOrdinal("COD_CAT"));


                            oCampos.UBIGEO_DIRECCION = dr.GetString(dr.GetOrdinal("UBIGEO_DIRECCION"));
                            //
                            //oCampos.AREA_OTORGADA = Decimal.Parse(dr.GetString(dr.GetOrdinal("AREA_OTORGADA")));
                            oCampos.AREA_OTORGADA = dr.GetDecimal(dr.GetOrdinal("AREA_OTORGADA"));
                            oCampos.CONTRADO_CONDICIONAL = dr.GetBoolean(dr.GetOrdinal("CONTRADO_CONDICIONAL"));
                            oCampos.CONTRATO_FECHA_INICIO = dr.GetString(dr.GetOrdinal("CONTRATO_FECHA_INICIO"));
                            oCampos.CONTRATO_FECHA_FIN = dr.GetString(dr.GetOrdinal("CONTRATO_FECHA_FIN"));
                            oCampos.ADENDA_CONDICIONAL = dr.GetBoolean(dr.GetOrdinal("ADENDA_CONDICIONAL"));
                            oCampos.CARACTER_AMBIENTAL = dr.GetString(dr.GetOrdinal("CARACTER_AMBIENTAL"));
                            oCampos.CARACTER_SOCIAL = dr.GetString(dr.GetOrdinal("CARACTER_SOCIAL"));
                            oCampos.CARACTER_ERESPONSABLE = dr.GetString(dr.GetOrdinal("CARACTER_ERESPONSABLE"));
                            oCampos.OBLIGACIONES_CONCESIONARIOS = dr.GetString(dr.GetOrdinal("OBLIGACIONES_CONCESIONARIO"));
                            //
                            oCampos.APROYECTO_NUM_RESOL = dr.GetString(dr.GetOrdinal("APROYECTO_NUM_RESOL"));
                            oCampos.APROYECTO_FECHA = dr.GetString(dr.GetOrdinal("APROYECTO_FECHA"));
                            oCampos.APROYECTO_COD_FUNCIONARIO = dr.GetString(dr.GetOrdinal("APROYECTO_COD_FUNCIONARIO"));
                            oCampos.AFUNCIONAMIENTO_NUM_RESOL = dr.GetString(dr.GetOrdinal("AFUNCIONAMIENTO_NUM_RESOL"));
                            oCampos.AFUNCIONAMIENTO_FECHA = dr.GetString(dr.GetOrdinal("AFUNCIONAMIENTO_FECHA"));
                            oCampos.AFUNCIONAMIENTO_COD_FUNCIONARIO = dr.GetString(dr.GetOrdinal("AFUNCIONAMIENTO_COD_FUNCIONARIO"));
                            oCampos.PERSONA_APROYECTO = dr.GetString(dr.GetOrdinal("PERSONA_APROYECTO"));
                            oCampos.PERSONA_AFUNCIONAMIENTO = dr.GetString(dr.GetOrdinal("PERSONA_AFUNCIONAMIENTO"));
                            //
                            oCampos.COD_ESTADO_DOC = dr.GetString(dr.GetOrdinal("COD_ESTADO_DOC"));
                            oCampos.OBSERVACIONES_CONTROL = dr.GetString(dr.GetOrdinal("OBSERVACIONES_CONTROL"));
                            oCampos.OBSERV_SUBSANAR = dr.GetBoolean(dr.GetOrdinal("OBSERV_SUBSANAR"));
                            oCampos.CUENTA_PLAN_MANEJO = dr.GetBoolean(dr.GetOrdinal("CUENTA_PLAN_MANEJO"));
                            oCampos.COD_OD_REGISTRO = dr.GetString(dr.GetOrdinal("COD_OD_REGISTRO"));
                            oCampos.TIPO_NM = dr.GetString(dr.GetOrdinal("TIPO_NM"));
                            oCampos.NIVEL_APROV = dr.GetString(dr.GetOrdinal("NIVEL_APROVECHA"));

                            oCampos.USUARIO_REGISTRO = dr.GetString(dr.GetOrdinal("USUARIO_REGISTRO"));
                            oCampos.USUARIO_CONTROL = dr.GetString(dr.GetOrdinal("USUARIO_CONTROL"));
                            oCampos.COD_DEPENDENCIA = dr.GetInt32(dr.GetOrdinal("COD_DEPENDENCIA")).ToString();
                            //
                            oCampos.COD_SECUENCIAL_ADENDA = dr.GetInt32(dr.GetOrdinal("COD_SECUENCIAL_ADENDA"));
                            oCampos.CATEGORIA = dr.GetString(dr.GetOrdinal("CATEGORIA"));
                            oCampos.RES_TITULAR = dr.GetString(dr.GetOrdinal("RES_TITULAR"));
                            oCampos.ESTADO_TH = dr.GetString(dr.GetOrdinal("ESTADO_TH"));
                        }
                        //THABILITANTE_DET_TITULARES
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("COD_PERSONA");
                            int pt2 = dr.GetOrdinal("COD_SECUENCIAL");
                            int pt3 = dr.GetOrdinal("NUMERO");
                            int pt4 = dr.GetOrdinal("PERSONA");
                            int pt5 = dr.GetOrdinal("N_DOCUMENTO");
                            int pt6 = dr.GetOrdinal("CONTRATO_FECHA_INICIO");
                            int pt7 = dr.GetOrdinal("CONTRATO_FECHA_FIN");
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.COD_PERSONA = dr.GetString(pt1);
                                oCamposDet.COD_SECUENCIAL = dr.GetInt32(pt2);
                                oCamposDet.NUMERO = dr.GetString(pt3);
                                oCamposDet.PERSONA = dr.GetString(pt4);
                                oCamposDet.N_DOCUMENTO = dr.GetString(pt5);
                                oCamposDet.CONTRATO_FECHA_INICIO = dr.GetString(pt6);
                                oCamposDet.CONTRATO_FECHA_FIN = dr.GetString(pt7);
                                oCamposDet.RegEstado = 0;
                                oCampos.ListTDTTITULARES.Add(oCamposDet);
                            }
                        }
                        //THABILITANTE_ADENDAS
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("COD_MADENDA");
                            int pt2 = dr.GetOrdinal("MOTIVO");
                            int pt3 = dr.GetOrdinal("COD_SECUENCIAL");
                            int pt4 = dr.GetOrdinal("NUM_THABILITANTE_ADENDA");
                            int pt5 = dr.GetOrdinal("NUM_RESOLUCION_ADENDA");
                            int pt6 = dr.GetOrdinal("COD_FUNCIONARIO_ADENDA");
                            int pt7 = dr.GetOrdinal("FUNCIONARIO");
                            int pt8 = dr.GetOrdinal("COD_TITULAR_ADENDA");
                            int pt9 = dr.GetOrdinal("TITULAR_ADENDA");
                            int pt10 = dr.GetOrdinal("ADENDA_FECHA_INICIO");
                            int pt11 = dr.GetOrdinal("ADENDA_FECHA_TERMINO");
                            int pt12 = dr.GetOrdinal("OBSERVACION");
                            int pt13 = dr.GetOrdinal("CANT_VERTICES");
                            int pt14 = dr.GetOrdinal("TIPO_PERSONA");
                            int pt15 = dr.GetOrdinal("N_DOCUMENTO");
                            int pt16 = dr.GetOrdinal("N_RUC");
                            int pt17 = dr.GetOrdinal("AREA");
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.COD_MADENDA = dr.GetString(pt1);
                                oCamposDet.MOTIVO = dr.GetString(pt2);
                                oCamposDet.COD_SECUENCIAL = dr.GetInt32(pt3);
                                oCamposDet.NUM_THABILITANTE_ADENDA = dr.GetString(pt4);
                                oCamposDet.NUM_RESOLUCION_ADENDA = dr.GetString(pt5);
                                oCamposDet.COD_FUNCIONARIO_ADENDA = dr.GetString(pt6);
                                oCamposDet.FUNCIONARIO = dr.GetString(pt7);
                                oCamposDet.COD_TITULAR_ADENDA = dr.GetString(pt8);
                                oCamposDet.TITULAR_ADENDA = dr.GetString(pt9);
                                oCamposDet.ADENDA_FECHA_INICIO = dr.GetString(pt10);
                                oCamposDet.ADENDA_FECHA_TERMINO = dr.GetString(pt11);
                                oCamposDet.OBSERVACION = dr.GetString(pt12);
                                oCamposDet.CANT_VERTICES = dr.GetInt32(pt13);
                                oCamposDet.TIPO_PERSONA = dr.GetString(pt14);
                                oCamposDet.N_DOCUMENTO = dr.GetString(pt15);
                                oCamposDet.N_RUC = dr.GetString(pt16);
                                oCamposDet.AREA_OTORGADA = dr.GetDecimal(pt17);
                                oCamposDet.RegEstado = 0;
                                oCamposDet.ListTDDVADEAREA = new List<CEntidad>();
                                oCampos.ListAdendas.Add(oCamposDet);
                            }
                        }
                        //THABILITANTE_DGENERAL_DET_VERTICE
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.VERTICE = dr["VERTICE"].ToString();
                                oCamposDet.ZONA = dr["ZONA"].ToString();
                                oCamposDet.COORDENADA_ESTE = Int32.Parse(dr["COORDENADA_ESTE"].ToString());
                                oCamposDet.COORDENADA_NORTE = Int32.Parse(dr["COORDENADA_NORTE"].ToString());
                                oCamposDet.OBSERVACION = dr["OBSERVACION"].ToString();
                                oCamposDet.COD_SECUENCIAL = Int32.Parse(dr["COD_SECUENCIAL"].ToString());
                                oCamposDet.COD_SECUENCIAL_ADENDA = Int32.Parse(dr["COD_SECUENCIAL_ADENDA"].ToString());
                                oCamposDet.RegEstado = 0;
                                oCampos.ListTDDVVERTICE.Add(oCamposDet);
                            }
                        }

                        //DOC.THABILITANTE_DGENERAL_ADENDA_AREA
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.VERTICE = dr["VERTICE"].ToString();
                                oCamposDet.ZONA = dr["ZONA"].ToString();
                                oCamposDet.COORDENADA_ESTE = Int32.Parse(dr["COORDENADA_ESTE"].ToString());
                                oCamposDet.COORDENADA_NORTE = Int32.Parse(dr["COORDENADA_NORTE"].ToString());
                                oCamposDet.OBSERVACION = dr["OBSERVACION"].ToString();
                                oCamposDet.COD_SECUENCIAL = Int32.Parse(dr["COD_SECUENCIAL"].ToString());
                                oCamposDet.COD_SECUENCIAL_ADENDA = Int32.Parse(dr["COD_SECUENCIAL_ADENDA"].ToString());
                                //oCamposDet.COD_MADENDA = dr["COD_MADENDA"].ToString();
                                //oCamposDet.COD_AREA_SECUENCIAL = Int32.Parse(dr["COD_AREA_SECUENCIAL"].ToString());
                                oCamposDet.RegEstado = 0;

                                for (int i = 0; i < oCampos.ListAdendas.Count; i++)
                                {
                                    if (oCampos.ListAdendas[i].COD_SECUENCIAL == oCamposDet.COD_SECUENCIAL_ADENDA)
                                    {
                                        oCampos.ListAdendas[i].ListTDDVADEAREA.Add(oCamposDet);
                                    }
                                }

                                //oCampos.ListTDDVADEAREA.Add(oCamposDet);
                            }
                        }
                        // CAMBIO DE MODALIDAD
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("COD_MADENDA");
                            int pt2 = dr.GetOrdinal("MOTIVO");
                            int pt3 = dr.GetOrdinal("COD_SECUENCIAL");
                            int pt4 = dr.GetOrdinal("COD_TITULAR_ADENDA");
                            int pt5 = dr.GetOrdinal("TITULAR_ADENDA");
                            int pt6 = dr.GetOrdinal("ADENDA_FECHA_INICIO");
                            int pt7 = dr.GetOrdinal("OBSERVACION");
                            int pt8 = dr.GetOrdinal("COD_MTIPO");
                            int pt9 = dr.GetOrdinal("MODALIDAD");
                            int pt10 = dr.GetOrdinal("NUM_RESOLUCIONCAMBIO");
                            int pt11 = dr.GetOrdinal("AFUNCIONAMIENTO_NUM_RESOL");
                            int pt12 = dr.GetOrdinal("RESOLUCION_TITULAR");
                            int pt13 = dr.GetOrdinal("NUEVO_CONTRATO");
                            int pt14 = dr.GetOrdinal("COD_MTIPO_ANT");
                            int pt15 = dr.GetOrdinal("MODALIDAD_ANT");
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.COD_MADENDA = dr.GetString(pt1);
                                oCamposDet.MOTIVO = dr.GetString(pt2);
                                oCamposDet.COD_SECUENCIAL = dr.GetInt32(pt3);
                                oCamposDet.COD_TITULAR_ADENDA = dr.GetString(pt4);
                                oCamposDet.TITULAR_ADENDA = dr.GetString(pt5);
                                oCamposDet.ADENDA_FECHA_INICIO = dr.GetString(pt6);
                                oCamposDet.OBSERVACION = dr.GetString(pt7);
                                oCamposDet.COD_MTIPO = dr.GetString(pt8);
                                oCamposDet.MODALIDAD = dr.GetString(pt9);
                                oCamposDet.NUM_RESOLUCION_ADENDA = dr.GetString(pt10);
                                oCamposDet.AFUNCIONAMIENTO_NUM_RESOL = dr.GetString(pt11);
                                oCamposDet.RegEstado = 0;
                                //20.04.2021 se agrega campos
                                oCamposDet.RES_TITULAR = dr.GetString(pt12);
                                oCamposDet.NUMERO = dr.GetString(pt13);
                                oCamposDet.CODMTIPO_ANTERIOR = dr.GetString(pt14);
                                oCamposDet.MTIPO_ANTERIOR = dr.GetString(pt15);

                                oCampos.ListModalidadesTH.Add(oCamposDet);
                            }
                        }
                        //ESTADO ESTABLECIMIENTO
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("COD_THABILITANTE");
                            int pt2 = dr.GetOrdinal("COD_THABILITANTE_EVALUACION_FAUNA");
                            int pt3 = dr.GetOrdinal("COD_MOTIVO_EV");
                            int pt4 = dr.GetOrdinal("MOTIVO");
                            int pt5 = dr.GetOrdinal("NUMERO");
                            int pt6 = dr.GetOrdinal("FECHA_AFFS");
                            int pt7 = dr.GetOrdinal("NOMBRE_FIRMA_RES");
                            int pt8 = dr.GetOrdinal("NUM_DOCUMENTO");
                            int pt9 = dr.GetOrdinal("FECHA_DOC");
                            int pt10 = dr.GetOrdinal("NOMBRE_AFFS");
                            int pt11 = dr.GetOrdinal("OBSERVACION");

                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.COD_THABILITANTE = dr.GetString(pt1);
                                oCamposDet.COD_THABILITANTE_EVALUACION_FAUNA = dr.GetString(pt2);
                                oCamposDet.COD_MOTIVO_EV = dr.GetString(pt3);
                                oCamposDet.MOTIVO = dr.GetString(pt4);
                                oCamposDet.NUMERO = dr.GetString(pt5);
                                oCamposDet.FECHA_AFFS = dr.GetString(pt6);
                                oCamposDet.NOMBRE_FIRMA_RES = dr.GetString(pt7);
                                oCamposDet.N_DOCUMENTO = dr.GetString(pt8);
                                oCamposDet.FECHA_DOC = dr.GetString(pt9);
                                oCamposDet.NOMBRE_AFFS = dr.GetString(pt10);
                                oCamposDet.OBSERVACION = dr.GetString(pt11);
                                oCamposDet.RegEstado = 0;
                                oCampos.ListTHEstadoEsta.Add(oCamposDet);
                            }
                        }
                        //Dependencias
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("CODIGO");
                            int pt2 = dr.GetOrdinal("DESCRIPCION");


                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.CODIGO = dr.GetInt32(pt1).ToString();
                                oCamposDet.DESCRIPCION = dr.GetString(pt2);

                                oCampos.ListDependencia.Add(oCamposDet);
                            }
                        }

                        //Listados de Error Material
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            Ent_ERRORMATERIAL oCamposEM;

                            while (dr.Read())
                            {
                                oCamposEM = new Ent_ERRORMATERIAL();
                                oCamposEM.COD_SECUENCIAL = dr.GetInt32(dr.GetOrdinal("COD_SECUENCIAL"));
                                oCamposEM.DA_FECRESOLUCION = dr.GetString(dr.GetOrdinal("DA_FECRESOLUCION"));
                                oCamposEM.NV_RESOLUCION = dr.GetString(dr.GetOrdinal("NV_RESOLUCION"));
                                oCamposEM.NV_NOMCAMPO = dr.GetString(dr.GetOrdinal("NV_NOMCAMPO"));
                                oCamposEM.NV_VALANTERIOR = dr.GetString(dr.GetOrdinal("NV_VALANTERIOR"));
                                oCamposEM.NV_VALACTUAL = dr.GetString(dr.GetOrdinal("NV_VALACTUAL"));
                                oCamposEM.NV_OBSERVACION = dr.GetString(dr.GetOrdinal("NV_OBSERVACION")).Replace("\n", "<br/>");

                                oCampos.ListErrorMaterialGeneral.Add(oCamposEM);
                            }
                        }

                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            Ent_ERRORMATERIAL oCamposEM;

                            while (dr.Read())
                            {
                                oCamposEM = new Ent_ERRORMATERIAL();
                                oCamposEM.COD_SECUENCIAL = dr.GetInt32(dr.GetOrdinal("COD_SECUENCIAL"));
                                oCamposEM.DA_FECRESOLUCION = dr.GetString(dr.GetOrdinal("DA_FECRESOLUCION"));
                                oCamposEM.NV_RESOLUCION = dr.GetString(dr.GetOrdinal("NV_RESOLUCION"));
                                oCamposEM.NV_NOMCAMPO = dr.GetString(dr.GetOrdinal("NV_NOMCAMPO"));
                                oCamposEM.NV_VALANTERIOR = dr.GetString(dr.GetOrdinal("NV_VALANTERIOR"));
                                oCamposEM.NV_VALACTUAL = dr.GetString(dr.GetOrdinal("NV_VALACTUAL"));
                                oCamposEM.NV_OBSERVACION = dr.GetString(dr.GetOrdinal("NV_OBSERVACION")).Replace("\n", "<br/>");

                                oCampos.ListErrorMaterialAdicional.Add(oCamposEM);
                            }
                        }
                        //LISTADO PARA LA EXTINCION DEL TITULO HABILITANTE
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            Ent_THABILITANTE oCamposEM;

                            while (dr.Read())
                            {
                                oCamposEM = new Ent_THABILITANTE();
                                oCamposEM.COD_EXTINCION = dr.GetString(dr.GetOrdinal("COD_EXTINCION"));
                                oCamposEM.COD_THABILITANTE = dr.GetString(dr.GetOrdinal("COD_THABILITANTE"));
                                oCamposEM.MOTIVO = dr.GetString(dr.GetOrdinal("MOTIVO"));
                                oCamposEM.NUM_RESOLUCION = dr.GetString(dr.GetOrdinal("RESOLUCION"));
                                oCamposEM.FECHA = dr.GetString(dr.GetOrdinal("FECHA_REGISTRO"));
                                oCamposEM.OBSERVACION = dr.GetString(dr.GetOrdinal("OBSERVACIONE"));
                                oCamposEM.RegEstado = 0;
                                oCampos.ListTHExtincion.Add(oCamposEM);
                            }
                        }
                        //LISTADO DE DIVISION INTERNA DE PREDIO
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            Ent_DIVISIONINTERNA oCamposDI;

                            while (dr.Read())
                            {
                                oCamposDI = new Ent_DIVISIONINTERNA();
                                oCamposDI.COD_THABILITANTE = dr.GetString(dr.GetOrdinal("COD_THABILITANTE"));
                                oCamposDI.COD_SECUENCIAL = dr.GetInt32(dr.GetOrdinal("COD_SECUENCIAL"));
                                oCamposDI.TIPOAREA = dr.GetInt32(dr.GetOrdinal("TIPOAREA"));
                                oCamposDI.SUBTIPOAREA = dr.GetInt32(dr.GetOrdinal("SUBTIPOAREA"));
                                oCamposDI.SUBTIPOAREADESC = dr.GetString(dr.GetOrdinal("SUBTIPOAREADESC"));
                                oCamposDI.AREA = dr.GetDecimal(dr.GetOrdinal("AREA"));                                
                                oCamposDI.DESCRIPCIONAREA = dr.GetString(dr.GetOrdinal("DESCRIPCIONAREA"));                                
                                oCampos.ListDivisionInterna.Add(oCamposDI);
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
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        //public String RegGrabar(SqlConnection cn, CEntidad oCEntidad, bool sigoV3 = false)
        //{
        //    SqlTransaction tr = null;
        //    String OUTPUTPARAM01 = "";
        //    //String OUTPUTPARAM02 = "";
        //    Int32 OUTPUTSEC = 0;
        //    CEntidad oCamposDet;
        //    CEntidad oCamposDet2;
        //    CEntidad oCamposActTH;
        //    List<CEntidad> listaFiltro = new List<CEntidad>();
        //    try
        //    {
        //        tr = cn.BeginTransaction();
        //        string sp_Sigo = "DOC.spTHABILITANTEGrabar";
        //        if (sigoV3) sp_Sigo = "DOC.spTHABILITANTEGrabarSigoV3";
        //        //Grabando Cabecera
        //        using (SqlCommand cmd = oGDataSQL.ManExecuteOutput(cn, tr, sp_Sigo, oCEntidad))
        //        {
        //            cmd.ExecuteNonQuery();
        //            OUTPUTPARAM01 = (String)cmd.Parameters["@OUTPUTPARAM01"].Value;
        //            //OUTPUTPARAM02 = (String)cmd.Parameters["@OUTPUTPARAM02"].Value;
        //            if (OUTPUTPARAM01 == "100")
        //            {
        //                tr.Rollback();
        //                tr = null;
        //                throw new Exception("El registro se encuentra con Control de Calidad Conforme, No se puede modificar el registro");
        //            }
        //            else if (OUTPUTPARAM01 == "99")
        //            {
        //                tr.Rollback();
        //                tr = null;
        //                throw new Exception("Ud. no tiene permiso para realizar esta acción");
        //            }
        //            if (OUTPUTPARAM01 == "0")
        //            {
        //                tr.Rollback();
        //                tr = null;
        //                throw new Exception("El Número del Titulo Habilitante ya Existe");
        //            }
        //            else if (OUTPUTPARAM01 == "1")
        //            {
        //                tr.Rollback();
        //                tr = null;
        //                throw new Exception("El Número del Titulo Habilitante Existe en otro Registro");
        //            }
        //            else if (OUTPUTPARAM01 == "2")
        //            {
        //                tr.Rollback();
        //                tr = null;
        //                throw new Exception("No Tiene Permisos para Modificar este Título Habilitante");
        //            }
        //            else if (OUTPUTPARAM01 == "3")
        //            {
        //                tr.Rollback();
        //                tr = null;
        //                throw new Exception("Está con Control de Calidad, no puede modificar");
        //            }
        //        }
        //        //Reemplazando El Nuevo Codigo Creado
        //        if (oCEntidad.RegEstado == 1) //Nuevo
        //        {
        //            oCEntidad.COD_THABILITANTE = OUTPUTPARAM01;
        //        }
        //        //
        //        //Eliminando Detalle
        //        if (oCEntidad.ListEliTABLA != null)
        //        {
        //            foreach (var loDatos in oCEntidad.ListEliTABLA)
        //            {
        //                oCamposDet = new CEntidad();
        //                oCamposDet.COD_THABILITANTE = oCEntidad.COD_THABILITANTE;
        //                oCamposDet.EliTABLA = loDatos.EliTABLA;
        //                oCamposDet.EliVALOR01 = loDatos.EliVALOR01;
        //                oCamposDet.EliVALOR02 = loDatos.EliVALOR02;
        //                oCamposDet.EliVALOR03 = loDatos.EliVALOR03;
        //                oCamposDet.EliVALOR04 = loDatos.EliVALOR04;
        //                oCamposDet.COD_AREA_SECUENCIAL = loDatos.COD_AREA_SECUENCIAL;

        //                oGDataSQL.ManExecute(cn, tr, "DOC.spTHABILITANTEEliminarDetalle", oCamposDet);
        //            }
        //        }
        //        //
        //        //Grabando Detalle THABILITANTE_DET_TITULARES
        //        if (oCEntidad.ListTDTTITULARES != null)
        //        {
        //            foreach (var loDatos in oCEntidad.ListTDTTITULARES)
        //            {
        //                if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
        //                {
        //                    oCamposDet = new CEntidad();
        //                    oCamposDet.COD_THABILITANTE = oCEntidad.COD_THABILITANTE;
        //                    oCamposDet.COD_TITULAR = loDatos.COD_PERSONA;
        //                    oCamposDet.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
        //                    oCamposDet.NUMERO = loDatos.NUMERO;
        //                    oCamposDet.CONTRATO_FECHA_INICIO = loDatos.CONTRATO_FECHA_INICIO;
        //                    oCamposDet.CONTRATO_FECHA_FIN = loDatos.CONTRATO_FECHA_FIN;
        //                    oCamposDet.RegEstado = loDatos.RegEstado;
        //                    oGDataSQL.ManExecute(cn, tr, "DOC.spTHABILITANTE_DET_TITULARESGrabar", oCamposDet);
        //                }
        //            }
        //        }
        //        //Grabando 
        //        if (oCEntidad.ListTDDVVERTICE != null)
        //        {
        //            foreach (var loDatos in oCEntidad.ListTDDVVERTICE)
        //            {
        //                if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
        //                {
        //                    oCamposDet = new CEntidad();
        //                    oCamposDet.COD_THABILITANTE = oCEntidad.COD_THABILITANTE;
        //                    oCamposDet.VERTICE = loDatos.VERTICE;
        //                    oCamposDet.ZONA = loDatos.ZONA == "" ? null : loDatos.ZONA;
        //                    oCamposDet.COORDENADA_ESTE = loDatos.COORDENADA_ESTE;
        //                    oCamposDet.COORDENADA_NORTE = loDatos.COORDENADA_NORTE;
        //                    oCamposDet.OBSERVACION = loDatos.OBSERVACION;
        //                    oCamposDet.RegEstado = loDatos.RegEstado;
        //                    oCamposDet.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
        //                    oCamposDet.COD_SECUENCIAL_ADENDA = loDatos.COD_SECUENCIAL_ADENDA;
        //                    oGDataSQL.ManExecute(cn, tr, "DOC.spTHABILITANTE_DGENERAL_DET_VERTICEGrabar", oCamposDet);
        //                }
        //            }
        //        }
        //        //Listado Adendas
        //        if (oCEntidad.ListAdendas != null)
        //        {
        //            foreach (var loDatos in oCEntidad.ListAdendas)
        //            {
        //                if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
        //                {
        //                    oCamposDet = new CEntidad();
        //                    oCamposDet.COD_THABILITANTE = oCEntidad.COD_THABILITANTE;
        //                    oCamposDet.COD_MADENDA = loDatos.COD_MADENDA;
        //                    oCamposDet.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
        //                    oCamposDet.NUM_THABILITANTE_ADENDA = loDatos.NUM_THABILITANTE_ADENDA;
        //                    oCamposDet.NUM_RESOLUCION_ADENDA = loDatos.NUM_RESOLUCION_ADENDA;
        //                    oCamposDet.COD_FUNCIONARIO_ADENDA = loDatos.COD_FUNCIONARIO_ADENDA;
        //                    oCamposDet.COD_TITULAR_ADENDA = loDatos.COD_TITULAR_ADENDA;
        //                    oCamposDet.ADENDA_FECHA_INICIO = loDatos.ADENDA_FECHA_INICIO;
        //                    oCamposDet.ADENDA_FECHA_TERMINO = loDatos.ADENDA_FECHA_TERMINO;
        //                    oCamposDet.OBSERVACION = loDatos.OBSERVACION;
        //                    oCamposDet.AREA_OTORGADA = loDatos.AREA_OTORGADA;
        //                    oCamposDet.RegEstado = loDatos.RegEstado;
        //                    oCamposDet.COD_AEXPEDIENTE_SITD = loDatos.COD_AEXPEDIENTE_SITD;
        //                    oCamposDet.COD_TRAMITE_SITD = loDatos.COD_TRAMITE_SITD;
        //                    //oGDataSQL.ManExecute(cn, tr, "DOC.spTHABILITANTE_DGENERAL_DET_VERTICEGrabar", oCamposDet);

        //                    using (SqlCommand cmd = oGDataSQL.ManExecuteOutput(cn, tr, "DOC.spTHABILITANTE_DG_ADENDAGrabar", oCamposDet))
        //                    {
        //                        cmd.ExecuteNonQuery();
        //                        OUTPUTSEC = (Int32)cmd.Parameters["@OUTPUTPARAM01"].Value;
        //                        if (oCamposDet.COD_MADENDA == "0000001" || oCamposDet.COD_MADENDA == "0000003")
        //                        {
        //                            //listaFiltro = new List<CEntidad>();
        //                            //listaFiltro = (from p in oCEntidad.ListTDDVADEAREA where p.COD_MADENDA == oCamposDet.COD_MADENDA && p.ADENDA_FECHA_INICIO == oCamposDet.ADENDA_FECHA_INICIO select p).ToList<CEntidad>();

        //                            //if (oCEntidad.ListTDDVADEAREA != null)
        //                            if (loDatos.ListTDDVADEAREA != null)
        //                            {
        //                                //foreach (var loDatos2 in listaFiltro)
        //                                foreach (var loDatos2 in loDatos.ListTDDVADEAREA)
        //                                {
        //                                    if (loDatos2.RegEstado == 1 || loDatos2.RegEstado == 2) //Nuevo o Modificado
        //                                    {
        //                                        oCamposDet2 = new CEntidad();
        //                                        oCamposDet2.COD_THABILITANTE = oCEntidad.COD_THABILITANTE;
        //                                        oCamposDet2.VERTICE = loDatos2.VERTICE;
        //                                        oCamposDet2.ZONA = loDatos2.ZONA == "" ? null : loDatos2.ZONA;
        //                                        oCamposDet2.COORDENADA_ESTE = loDatos2.COORDENADA_ESTE;
        //                                        oCamposDet2.COORDENADA_NORTE = loDatos2.COORDENADA_NORTE;
        //                                        oCamposDet2.OBSERVACION = loDatos2.OBSERVACION;
        //                                        oCamposDet2.COD_SECUENCIAL_ADENDA = OUTPUTSEC;
        //                                        oCamposDet2.COD_SECUENCIAL = loDatos2.COD_SECUENCIAL;
        //                                        oCamposDet2.RegEstado = loDatos2.RegEstado;
        //                                        oGDataSQL.ManExecute(cn, tr, "DOC.spTHABILITANTE_DGENERAL_DET_VERTICEGrabar", oCamposDet2);
        //                                        //oGDataSQL.ManExecute(cn, tr, "DOC.spTHABILITANTE_DG_ADENDA_AREAGrabar", oCamposDet2);
        //                                    }
        //                                }
        //                            }
        //                        }
        //                    }
        //                }
        //            }
        //        }

        //        //adendas de cambio de modalidad
        //        if (oCEntidad.ListModalidadesTH != null)
        //        {
        //            foreach (var loDatos in oCEntidad.ListModalidadesTH)
        //            {
        //                if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
        //                {
        //                    oCamposDet = new CEntidad();
        //                    oCamposDet.COD_THABILITANTE = oCEntidad.COD_THABILITANTE;
        //                    oCamposDet.COD_MADENDA = loDatos.COD_MADENDA;
        //                    oCamposDet.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
        //                    oCamposDet.NUM_THABILITANTE_ADENDA = loDatos.NUM_THABILITANTE_ADENDA;
        //                    oCamposDet.NUM_RESOLUCION_ADENDA = loDatos.NUM_RESOLUCION_ADENDA;
        //                    oCamposDet.COD_FUNCIONARIO_ADENDA = loDatos.COD_FUNCIONARIO_ADENDA;
        //                    oCamposDet.COD_TITULAR_ADENDA = loDatos.COD_TITULAR_ADENDA;
        //                    oCamposDet.ADENDA_FECHA_INICIO = loDatos.ADENDA_FECHA_INICIO;
        //                    oCamposDet.ADENDA_FECHA_TERMINO = loDatos.ADENDA_FECHA_TERMINO;
        //                    oCamposDet.OBSERVACION = loDatos.OBSERVACION;
        //                    oCamposDet.AREA_OTORGADA = loDatos.AREA_OTORGADA;
        //                    oCamposDet.COD_MTIPO = loDatos.COD_MTIPO;
        //                    oCamposDet.RegEstado = loDatos.RegEstado;
        //                    oCamposDet.AFUNCIONAMIENTO_NUM_RESOL = loDatos.AFUNCIONAMIENTO_NUM_RESOL;
        //                    oGDataSQL.ManExecute(cn, tr, "DOC.spTHABILITANTE_DG_ADENDAGrabar", oCamposDet);
        //                    //oGDataSQL.ManExecute(cn, tr, "DOC.spTHABILITANTE_DGENERAL_DET_VERTICEGrabar", oCamposDet);
        //                    //using (SqlCommand cmd = oGDataSQL.ManExecuteOutput(cn, tr, "DOC.spTHABILITANTE_DG_ADENDAGrabar", oCamposDet))

        //                    if (loDatos.COD_MADENDA == "0000007")
        //                    {
        //                        oCEntidad.COD_MTIPO = loDatos.COD_MTIPO;
        //                        oCEntidad.AFUNCIONAMIENTO_NUM_RESOL = loDatos.NUM_RESOLUCION_ADENDA;
        //                        oGDataSQL.ManExecute(cn, tr, sp_Sigo, oCEntidad);

        //                        /*using (SqlCommand cmd = oGDataSQL.ManExecuteOutput(cn, tr, sp_Sigo, oCEntidad))
        //                            oCamposDet = new CEntidad();
        //                        oCamposDet.COD_THABILITANTE = oCEntidad.COD_THABILITANTE;
        //                        //oCamposDet.COD_MADENDA = loDatos.COD_MADENDA;
        //                        //oCamposDet.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
        //                        //oCamposDet.NUM_THABILITANTE_ADENDA = loDatos.NUM_THABILITANTE_ADENDA;
        //                        oCamposDet.AFUNCIONAMIENTO_NUM_RESOL = loDatos.NUM_RESOLUCION_ADENDA;
        //                        //oCamposDet.COD_FUNCIONARIO_ADENDA = loDatos.COD_FUNCIONARIO_ADENDA;
        //                        //oCamposDet.COD_TITULAR_ADENDA = loDatos.COD_TITULAR_ADENDA;
        //                        //oCamposDet.ADENDA_FECHA_INICIO = loDatos.ADENDA_FECHA_INICIO;
        //                        //oCamposDet.ADENDA_FECHA_TERMINO = loDatos.ADENDA_FECHA_TERMINO;
        //                        //oCamposDet.OBSERVACION = loDatos.OBSERVACION;
        //                       // oCamposDet.AREA_OTORGADA = loDatos.AREA_OTORGADA;
        //                        oCamposDet.COD_MTIPO = loDatos.COD_MTIPO;
        //                        //oCamposDet.RegEstado = loDatos.RegEstado;
        //                        oGDataSQL.ManExecute(cn, tr, "DOC.spTHABILITANTE_DG_ADENDAGrabar", oCamposDet);*/
        //                    }
        //                }
        //            }
        //        }

        //        if (oCEntidad.ListTHEstadoEsta != null)
        //        {
        //            foreach (var loDatos in oCEntidad.ListTHEstadoEsta)
        //            {
        //                if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
        //                {
        //                    oCamposDet = new CEntidad();
        //                    oCamposDet.COD_THABILITANTE = oCEntidad.COD_THABILITANTE;
        //                    oCamposDet.COD_THABILITANTE_EVALUACION_FAUNA = loDatos.COD_THABILITANTE_EVALUACION_FAUNA;
        //                    oCamposDet.COD_MOTIVO_EV = loDatos.COD_MOTIVO_EV;
        //                    oCamposDet.NUMERO = loDatos.NUMERO;
        //                    oCamposDet.FECHA_AFFS = loDatos.FECHA_AFFS;
        //                    oCamposDet.NOMBRE_FIRMA_RES = loDatos.NOMBRE_AFFS;
        //                    oCamposDet.N_DOCUMENTO = loDatos.N_DOCUMENTO;
        //                    oCamposDet.FECHA_DOC = loDatos.FECHA_DOC;
        //                    oCamposDet.NOMBRE_AFFS = loDatos.NOMBRE_AFFS;
        //                    oCamposDet.OBSERVACION = loDatos.OBSERVACION;
        //                    if (oCamposDet.FECHA_AFFS.ToString() == "")
        //                    {
        //                        oCamposDet.FECHA_AFFS = null;
        //                    }
        //                    if (oCamposDet.COD_THABILITANTE_EVALUACION_FAUNA != null)
        //                    {
        //                        oCamposDet.RegEstado = 2;
        //                    }
        //                    else
        //                    {
        //                        oCamposDet.RegEstado = 1;
        //                    }
        //                    oGDataSQL.ManExecute(cn, tr, "DOC.spTHABILITANTE_ESTDO_ESTGrabar", oCamposDet);
        //                }
        //            }
        //        }
        //        oCamposActTH = new CEntidad();
        //        oCamposActTH.COD_THABILITANTE = oCEntidad.COD_THABILITANTE;
        //        using (SqlCommand cmd = oGDataSQL.ManExecuteOutput(cn, tr, "DOC.spTHABILITANTE_VALIDACION", oCamposActTH))
        //        {
        //            cmd.ExecuteNonQuery();
        //            OUTPUTPARAM01 = (String)cmd.Parameters["@OUTPUTPARAM01"].Value;
        //            if (OUTPUTPARAM01 == "99")
        //            {
        //                tr.Rollback();
        //                tr = null;
        //                throw new Exception("Ud. no tiene permiso para realizar esta acción");
        //            }
        //        }

        //        ///<summary>
        //        ///Grabando Detalle THABILITANTE_DGENERAL_ADENDA_AREA
        //        ///</summary>

        //        //
        //        tr.Commit();
        //        return OUTPUTPARAM01;// + '|' + OUTPUTPARAM02;
        //    }
        //    catch (Exception ex)
        //    {
        //        if (tr != null)
        //        {
        //            tr.Rollback();
        //        }
        //        throw ex;
        //    }
        //}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        //public Int32 RegEliminar(SqlConnection cn, CEntidad oCEntidad)
        //{
        //    try
        //    {
        //        Int32 RegNum = oGDataSQL.ManExecute(cn, null, "DOC.spTHABILITANTEEliminar", oCEntidad);
        //        if (RegNum == -1)
        //        {
        //            throw new Exception("No se logró realizar la operación");
        //        }
        //        return RegNum;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
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
                //using (SqlDataReader dr = oGDataSQL.SelDrdDefault(cn, null, "DOC.spGeneral_Combo_Listar", oCEntidad))
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "doc_osinfor_erp_migracion.spGeneral_Combo_Listar", oCEntidad))
                {
                    if (dr != null)
                    {
                        oCampos = new CEntidad();
                        List<CEntidad> lsDetDetalle;
                        CEntidad oCamposDet;
                        //
                        //Modalidad
                        lsDetDetalle = new List<CEntidad>();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                //PARTE_DIARIO_DETALLE
                                oCamposDet = new CEntidad();
                                oCamposDet.CODIGO = dr["CODIGO"].ToString();
                                oCamposDet.DESCRIPCION = dr["DESCRIPCION"].ToString();
                                lsDetDetalle.Add(oCamposDet);
                            }
                        }
                        oCampos.ListMComboModalidad = lsDetDetalle;
                        //
                        //Motivo Adenda
                        dr.NextResult();
                        lsDetDetalle = new List<CEntidad>();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.CODIGO = dr["CODIGO"].ToString();
                                oCamposDet.DESCRIPCION = dr["DESCRIPCION"].ToString();
                                lsDetDetalle.Add(oCamposDet);
                            }
                        }
                        oCampos.ListMComboMAdenda = lsDetDetalle;
                        //
                        //Documento de Identidad
                        dr.NextResult();
                        lsDetDetalle = new List<CEntidad>();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                //PARTE_DIARIO_DETALLE
                                oCamposDet = new CEntidad();
                                oCamposDet.CODIGO = dr["CODIGO"].ToString();
                                oCamposDet.DESCRIPCION = dr["DESCRIPCION"].ToString();
                                lsDetDetalle.Add(oCamposDet);
                            }
                        }
                        oCampos.ListMComboDIdentidad = lsDetDetalle;
                        //Estado documento
                        dr.NextResult();
                        lsDetDetalle = new List<CEntidad>();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                //PARTE_DIARIO_DETALLE
                                oCamposDet = new CEntidad();
                                oCamposDet.CODIGO = dr["CODIGO"].ToString();
                                oCamposDet.DESCRIPCION = dr["DESCRIPCION"].ToString();
                                lsDetDetalle.Add(oCamposDet);
                            }
                        }
                        oCampos.ListIndicador = lsDetDetalle;
                        //Oficinas Desconcentradas
                        dr.NextResult();
                        lsDetDetalle = new List<CEntidad>();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.CODIGO = dr["CODIGO"].ToString();
                                oCamposDet.DESCRIPCION = dr["DESCRIPCION"].ToString();
                                lsDetDetalle.Add(oCamposDet);
                            }
                        }
                        oCampos.ListODs = lsDetDetalle;
                        // combo modalidades recategorizacion
                        dr.NextResult();
                        lsDetDetalle = new List<CEntidad>();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.CODIGO = dr["CODIGO"].ToString();
                                oCamposDet.DESCRIPCION = dr["DESCRIPCION"].ToString();
                                lsDetDetalle.Add(oCamposDet);
                            }
                        }
                        oCampos.ListComboRecategoriza = lsDetDetalle;
                        // combo modalidades del Titulo Habilitante
                        dr.NextResult();
                        lsDetDetalle = new List<CEntidad>();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.CODIGO = dr["CODIGO"].ToString();
                                oCamposDet.DESCRIPCION = dr["DESCRIPCION"].ToString();
                                lsDetDetalle.Add(oCamposDet);
                            }
                        }
                        oCampos.ListModalidadesTH = lsDetDetalle;
                        dr.NextResult();
                        lsDetDetalle = new List<CEntidad>();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.CODIGO = dr["CODIGO"].ToString();
                                oCamposDet.DESCRIPCION = dr["DESCRIPCION"].ToString();
                                lsDetDetalle.Add(oCamposDet);
                            }
                        }
                        oCampos.ListComboFR = lsDetDetalle;
                        //motivo estado del establecimiento
                        dr.NextResult();
                        lsDetDetalle = new List<CEntidad>();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.CODIGO = dr["CODIGO"].ToString();
                                oCamposDet.DESCRIPCION = dr["DESCRIPCION"].ToString();
                                lsDetDetalle.Add(oCamposDet);
                            }
                        }
                        oCampos.ListTHMotivoEstado = lsDetDetalle;
                        //clase de Zoologico
                        dr.NextResult();
                        lsDetDetalle = new List<CEntidad>();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.CODIGO = dr["CODIGO"].ToString();
                                oCamposDet.DESCRIPCION = dr["DESCRIPCION"].ToString();
                                lsDetDetalle.Add(oCamposDet);
                            }
                        }
                        oCampos.ListClaseZoologico = lsDetDetalle;

                        //motivo de extincion
                        dr.NextResult();
                        lsDetDetalle = new List<CEntidad>();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.CODIGO = dr["CODIGO"].ToString();
                                oCamposDet.DESCRIPCION = dr["DESCRIPCION"].ToString();
                                lsDetDetalle.Add(oCamposDet);
                            }
                        }
                        oCampos.ListTHMotivoExtincion = lsDetDetalle;
                    }
                }
                return oCampos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public CEntidad GetDatosGeneralesTituloHabilitante(OracleConnection cn, CEntidad oCEntidad)
        {
            CEntidad oCampos = new CEntidad();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, "DOC_OSINFOR_ERP_MIGRACION.spGET_DATOSGENERALES_THABILITANTE", oCEntidad.COD_CNOTIFICACION))
                {
                    if (dr != null)
                    {
                        oCampos.ListTHVertice = new List<CapaEntidad.DOC.Ent_INFORME>();

                        if (dr.HasRows)
                        {
                            dr.Read();
                            oCampos.COD_THABILITANTE = dr.GetString(dr.GetOrdinal("COD_THABILITANTE"));
                            oCampos.PERSONA_TITULAR = dr.GetString(dr.GetOrdinal("PERSONA_TITULAR"));
                            oCampos.PERSONA_RLEGAL = dr.GetString(dr.GetOrdinal("PERSONA_RLEGAL"));
                            oCampos.NUMERO = dr.GetString(dr.GetOrdinal("NUMERO"));
                            oCampos.N_RUC = dr.GetString(dr.GetOrdinal("N_RUC"));
                            oCampos.ESTADO_DOC = dr.GetString(dr.GetOrdinal("ESTADO_DOC"));
                            oCampos.DIRECCION = dr.GetString(dr.GetOrdinal("DIRECCION"));
                            oCampos.TELEFONO = dr.GetString(dr.GetOrdinal("TELEFONO"));
                            oCampos.AREA_OTORGADA = dr.GetDecimal(dr.GetOrdinal("AREA_OTORGADA"));
                            oCampos.REGENTE_PGMF = dr["REGENTE_PGMF"].ToString();
                            oCampos.NUMREG_REGENTE_PGMF = dr["NUMREG_REGENTE_PGMF"].ToString();
                            oCampos.TELEFONO_REGENTE_PGMF = dr["TELEFONO_REGENTE_PGMF"].ToString();
                            oCampos.NUMRES_APROB_PGMF = dr["NUMRES_APROB_PGMF"].ToString();
                            oCampos.POA = dr["POA"].ToString();
                            oCampos.POA_AREA = dr["POA_AREA"].ToString();
                            oCampos.POA_COMPLEMENTARIO = dr["POA_COMPLEMENTARIO"].ToString();
                            oCampos.ANIO_OPERATIVO = dr.GetInt32(dr.GetOrdinal("ANIO_OPERATIVO"));
                            oCampos.REGENTE_ELAB_POA = dr["REGENTE_ELAB_POA"].ToString();
                            oCampos.PROF_INSP_POA = dr["PROF_INSP_POA"].ToString();
                            oCampos.PROF_RECOM_APROB_POA = dr["PROF_RECOM_APROB_POA"].ToString();
                            oCampos.NUMRES_APROB_POA = dr["NUMRES_APROB_POA"].ToString();
                            oCampos.FUNCIONARIO_APROB_POA = dr["FUNCIONARIO_APROB_POA"].ToString();
                            oCampos.COD_MTIPO = dr["COD_MTIPO"].ToString();
                        }

                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            CapaEntidad.DOC.Ent_INFORME ocampoEnt;

                            while (dr.Read())
                            {
                                ocampoEnt = new CapaEntidad.DOC.Ent_INFORME();
                                ocampoEnt.COD_INFORME = dr["COD_INFORME"].ToString();
                                ocampoEnt.CODIGO = dr["CODIGO"].ToString();
                                ocampoEnt.DESCRIPCION = dr["DESCRIPCION"].ToString();
                                ocampoEnt.COD_SISTEMA = dr["COD_SISTEMA"].ToString();
                                ocampoEnt.VERTICE = dr["VERTICE"].ToString();
                                ocampoEnt.VERTICE_CAMPO = dr["VERTICE_CAMPO"].ToString();
                                ocampoEnt.ZONA = dr["ZONA"].ToString();
                                ocampoEnt.ZONA_CAMPO = dr["ZONA_CAMPO"].ToString();
                                ocampoEnt.COORDENADA_ESTE = Int32.Parse(dr["COORDENADA_ESTE"].ToString());
                                ocampoEnt.COORDENADA_ESTE_CAMPO = Int32.Parse(dr["COORDENADA_ESTE_CAMPO"].ToString());
                                ocampoEnt.COORDENADA_NORTE = Int32.Parse(dr["COORDENADA_NORTE"].ToString());
                                ocampoEnt.COORDENADA_NORTE_CAMPO = Int32.Parse(dr["COORDENADA_NORTE_CAMPO"].ToString());
                                ocampoEnt.OBSERVACION_CAMPO = dr["OBSERVACION_CAMPO"].ToString();
                                ocampoEnt.RegEstado = 0;
                                oCampos.ListTHVertice.Add(ocampoEnt);
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
        //public List<CEntidad> RegMostrarTHEstadoListar(SqlConnection cn, CEntidad oCEntidad)
        //{
        //    List<CEntidad> lsCEntidad = new List<CEntidad>();
        //    try
        //    {
        //        using (SqlDataReader dr = oGDataSQL.SelDrdResult(cn, null, "DOC.spTHabilitanteEstadoListar", oCEntidad))
        //        {
        //            if (dr != null)
        //            {
        //                CEntidad oCampos;
        //                if (dr.HasRows)
        //                {
        //                    while (dr.Read())
        //                    {
        //                        oCampos = new CEntidad();
        //                        oCampos.COD_THABILITANTE = dr["v_COD_THABILITANTE"].ToString();
        //                        oCampos.NUMERO = dr["NUMERO"].ToString();
        //                        oCampos.MODALIDAD = dr["MODALIDAD"].ToString();
        //                        oCampos.PERSONA_TITULAR = dr["TITULAR"].ToString();
        //                        oCampos.ESTADO_TH = dr["ESTADO_TH"].ToString();
        //                        oCampos.FECHA = dr["FECHA"].ToString();
        //                        lsCEntidad.Add(oCampos);
        //                    }

        //                }
        //            }
        //        }
        //        return lsCEntidad;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //public String RegActualizarEstado(SqlConnection cn, CEntidad oCEntidad)
        //{
        //    SqlTransaction tr = null;
        //    String OUTPUTPARAM01 = "";
        //    try
        //    {
        //        tr = cn.BeginTransaction();
        //        //Grabando Cabecera
        //        using (SqlCommand cmd = oGDataSQL.ManExecuteOutput(cn, tr, "DOC.spTHabilitanteEstadoActualizar", oCEntidad))
        //        {
        //            cmd.ExecuteNonQuery();
        //            OUTPUTPARAM01 = (String)cmd.Parameters["@OUTPUTPARAM01"].Value;
        //            if (OUTPUTPARAM01 == "0")
        //            {
        //                tr.Rollback();
        //                tr = null;
        //                throw new Exception("Error en la Actualización del Estado");
        //            }
        //        }
        //        //
        //        tr.Commit();
        //        return OUTPUTPARAM01;
        //    }
        //    catch (Exception ex)
        //    {
        //        if (tr != null)
        //        {
        //            tr.Rollback();
        //        }
        //        throw ex;
        //    }
        //}

        #region "Migracion - SIGO v3"
        public CEntidad RegMostComboV3(OracleConnection cn, CEntidad oCEntidad)
        {
            CEntidad oCampos = null;
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.uspGeneral_Combo_Listar_SigoV3", oCEntidad))
                {
                    if (dr != null)
                    {
                        oCampos = new CEntidad();
                        List<CEntidad> lsDetDetalle;
                        CEntidad oCamposDet;
                        lsDetDetalle = new List<CEntidad>();
                        switch (oCEntidad.BusCriterio)
                        {
                            case "TIPO_DOCUMENTO_IDENTIDAD":
                                if (dr.HasRows)
                                {
                                    while (dr.Read())
                                    {
                                        oCamposDet = new CEntidad();
                                        oCamposDet.CODIGO = dr["CODIGO"].ToString();
                                        oCamposDet.DESCRIPCION = dr["DESCRIPCION"].ToString();
                                        lsDetDetalle.Add(oCamposDet);
                                    }
                                }
                                break;
                        }
                        oCampos.ListMComboDIdentidad = lsDetDetalle;
                    }
                }
                return oCampos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<CEntidad> ListarVerticeTHabilitante(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> oCampos = new List<CEntidad>();
            try
            {
                //using (SqlDataReader dr = oGDataSQL.SelDrdDefault(cn, null, "DOC.uspReporte_ListarVerticeTHabilitante", oCEntidad))
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "doc_osinfor_erp_migracion.uspReporte_ListarVerticeTHabilitante", oCEntidad))
                {
                    CEntidad oCamposDet = new CEntidad();
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.VERTICE = dr["VERTICE"].ToString();
                                oCamposDet.ZONA = dr["ZONA"].ToString();
                                oCamposDet.COORDENADA_ESTE = Int32.Parse(dr["COORDENADA_ESTE"].ToString());
                                oCamposDet.COORDENADA_NORTE = Int32.Parse(dr["COORDENADA_NORTE"].ToString());
                                oCamposDet.OBSERVACION = dr["OBSERVACION"].ToString();
                                oCamposDet.COD_SECUENCIAL = Int32.Parse(dr["COD_SECUENCIAL"].ToString());
                                oCamposDet.RegEstado = 0;
                                oCampos.Add(oCamposDet);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oCampos;
        }

        #endregion

        public String RegGrabarV3(OracleConnection cn, CEntidad oCEntidad, OracleTransaction tr)
        {

            String OUTPUTPARAM01 = "";
            //String OUTPUTPARAM02 = "";
            Int32 OUTPUTSEC = 0;
            CEntidad oCamposDet;
            CEntidad oCamposDet2;
            CEntidad oCamposDet3;
            CEntidad oCamposDet4;
            CEntidad oCamposActTH;
            /*
             * 
            */
            if (oCEntidad.CONTRADO_CONDICIONAL == null)
            {
                oCEntidad.CONTRADO_CONDICIONAL = false;
            }
            if (oCEntidad.OBSERV_SUBSANAR == null)
            {
                oCEntidad.OBSERV_SUBSANAR = false;
            }
            if (oCEntidad.CUENTA_PLAN_MANEJO == null)
            {
                oCEntidad.CUENTA_PLAN_MANEJO = false;
            }



            if (oCEntidad.CONTRADO_CONDICIONAL.Equals(true))
            {
                oCEntidad.iv_CONTRADO_CONDICIONAL = 1;
            }
            else
            {
                oCEntidad.iv_CONTRADO_CONDICIONAL = 0;
            }

            if (oCEntidad.OBSERV_SUBSANAR.Equals(true))
            {
                oCEntidad.iv_OBSERV_SUBSANAR = 1;
            }
            else
            {
                oCEntidad.iv_OBSERV_SUBSANAR = 0;
            }

            if (oCEntidad.CUENTA_PLAN_MANEJO.Equals(true))
            {
                oCEntidad.iv_CUENTA_PLAN_MANEJO = 1;
            }
            else
            {
                oCEntidad.iv_CUENTA_PLAN_MANEJO = 0;
            }

            oCEntidad.CONTRADO_CONDICIONAL = null;
            oCEntidad.OBSERV_SUBSANAR = null;
            oCEntidad.CUENTA_PLAN_MANEJO = null;


            List<CEntidad> listaFiltro = new List<CEntidad>();
            try
            {
                // tr = cn.BeginTransaction();
                string sp_Sigo = "doc_osinfor_erp_migracion.spTHABILITANTEGrabarSigoV3";
                //Grabando Cabecera
                using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, tr, sp_Sigo, oCEntidad))
                {
                    cmd.ExecuteNonQuery();
                    OUTPUTPARAM01 = (String)cmd.Parameters["OUTPUTPARAM01"].Value;
                    //OUTPUTPARAM02 = (String)cmd.Parameters["@OUTPUTPARAM02"].Value;
                    if (OUTPUTPARAM01 == "99")
                    {
                        throw new Exception("Ud. no tiene permiso para realizar esta acción");
                    }
                    if (OUTPUTPARAM01 == "0")
                    {
                        throw new Exception("El Número del Titulo Habilitante ya Existe");
                    }
                    else if (OUTPUTPARAM01 == "1")
                    {
                        throw new Exception("El Número del Titulo Habilitante Existe en otro Registro");
                    }
                    else if (OUTPUTPARAM01 == "2")
                    {
                        throw new Exception("No Tiene Permisos para Modificar este Título Habilitante");
                    }
                    else if (OUTPUTPARAM01 == "3")
                    {
                        throw new Exception("Está con Control de Calidad, no puede modificar");
                    }
                }
                //Reemplazando El Nuevo Codigo Creado
                if (oCEntidad.RegEstado == 1) //Nuevo
                {
                    oCEntidad.COD_THABILITANTE = OUTPUTPARAM01;
                }
                //
                //Eliminando Detalle
                if (oCEntidad.ListEliTABLA != null)
                {
                    foreach (var loDatos in oCEntidad.ListEliTABLA)
                    {
                        oCamposDet = new CEntidad();
                        oCamposDet.COD_THABILITANTE = oCEntidad.COD_THABILITANTE;
                        oCamposDet.EliTABLA = loDatos.EliTABLA;
                        oCamposDet.EliVALOR01 = loDatos.EliVALOR01;
                        oCamposDet.EliVALOR02 = loDatos.EliVALOR02;
                        oCamposDet.EliVALOR03 = loDatos.EliVALOR03;
                        oCamposDet.EliVALOR04 = loDatos.EliVALOR04;
                        oCamposDet.COD_AREA_SECUENCIAL = loDatos.COD_AREA_SECUENCIAL;

                        dBOracle.ManExecute(cn, tr, "doc_osinfor_erp_migracion.spTHABILITANTEEliminarDetalle", oCamposDet);
                    }
                }
                //
                //Grabando Detalle THABILITANTE_DET_TITULARES
                if (oCEntidad.ListTDTTITULARES != null)
                {
                    foreach (var loDatos in oCEntidad.ListTDTTITULARES)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            oCamposDet = new CEntidad();
                            oCamposDet.COD_THABILITANTE = oCEntidad.COD_THABILITANTE;
                            oCamposDet.COD_TITULAR = loDatos.COD_PERSONA;
                            oCamposDet.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            oCamposDet.NUMERO = loDatos.NUMERO;
                            oCamposDet.CONTRATO_FECHA_INICIO = loDatos.CONTRATO_FECHA_INICIO;
                            oCamposDet.CONTRATO_FECHA_FIN = loDatos.CONTRATO_FECHA_FIN;
                            oCamposDet.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "doc_osinfor_erp_migracion.spTHABILITANTE_DET_TITULARESGrabar", oCamposDet);
                        }
                    }
                }
                //Grabando 
                if (oCEntidad.ListTDDVVERTICE != null)
                {
                    //tr.Commit();
                    foreach (var loDatos in oCEntidad.ListTDDVVERTICE)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {

                            oCamposDet2 = new CEntidad();
                            oCamposDet2.COD_THABILITANTE = oCEntidad.COD_THABILITANTE;
                            oCamposDet2.VERTICE = loDatos.VERTICE;
                            oCamposDet2.ZONA = loDatos.ZONA == "" ? null : loDatos.ZONA;
                            oCamposDet2.COORDENADA_ESTE = loDatos.COORDENADA_ESTE;
                            oCamposDet2.COORDENADA_NORTE = loDatos.COORDENADA_NORTE;
                            oCamposDet2.OBSERVACION = loDatos.OBSERVACION;
                            oCamposDet2.RegEstado = loDatos.RegEstado;
                            oCamposDet2.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            if (loDatos.COD_SECUENCIAL_ADENDA == 0)
                            {
                                loDatos.COD_SECUENCIAL_ADENDA = 1;
                            }
                            oCamposDet2.COD_SECUENCIAL_ADENDA = loDatos.COD_SECUENCIAL_ADENDA;

                            if (oCamposDet2.ZONA != "0000000")
                                dBOracle.ManExecute(cn, tr, "doc_osinfor_erp_migracion.spTHABILITANTE_DGENERAL_DET_VERTICEGrabar", oCamposDet2);
                        }
                    }
                }
                //Listado Adendas
                if (oCEntidad.ListAdendas != null)
                {
                    foreach (var loDatos in oCEntidad.ListAdendas)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            oCamposDet3 = new CEntidad();
                            oCamposDet3.COD_THABILITANTE = oCEntidad.COD_THABILITANTE;
                            oCamposDet3.COD_MADENDA = loDatos.COD_MADENDA;
                            oCamposDet3.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            oCamposDet3.NUM_THABILITANTE_ADENDA = loDatos.NUM_THABILITANTE_ADENDA;
                            oCamposDet3.NUM_RESOLUCION_ADENDA = loDatos.NUM_RESOLUCION_ADENDA;
                            oCamposDet3.COD_FUNCIONARIO_ADENDA = loDatos.COD_FUNCIONARIO_ADENDA;
                            oCamposDet3.COD_TITULAR_ADENDA = loDatos.COD_TITULAR_ADENDA;
                            oCamposDet3.ADENDA_FECHA_INICIO = loDatos.ADENDA_FECHA_INICIO.ToString();
                            if (loDatos.ADENDA_FECHA_TERMINO != null)
                            {
                                oCamposDet3.ADENDA_FECHA_TERMINO = loDatos.ADENDA_FECHA_TERMINO.ToString();
                            }


                            oCamposDet3.AREA_OTORGADA = loDatos.AREA_OTORGADA;
                            oCamposDet3.COD_MTIPO = loDatos.COD_MTIPO;
                            oCamposDet3.AFUNCIONAMIENTO_NUM_RESOL = loDatos.AFUNCIONAMIENTO_NUM_RESOL;
                            oCamposDet3.OBSERVACION = loDatos.OBSERVACION;
                            oCamposDet3.RegEstado = loDatos.RegEstado;
                            //oCamposDet3.COD_AEXPEDIENTE_SITD = loDatos.COD_AEXPEDIENTE_SITD;
                            //oCamposDet3.COD_TRAMITE_SITD = loDatos.COD_TRAMITE_SITD;
                            //oCamposDet3.OUTPUTPARAM01 = 0;
                            //oGDataSQL.ManExecute(cn, tr, "DOC.spTHABILITANTE_DGENERAL_DET_VERTICEGrabar", oCamposDet);

                            using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, tr, "doc_osinfor_erp_migracion.spTHABILITANTE_DG_ADENDAGrabar", oCamposDet3))
                            {
                                cmd.ExecuteNonQuery();
                                OUTPUTSEC = Int32.Parse(cmd.Parameters["OUTPUTPARAM01"].Value.ToString());
                                if (oCamposDet3.COD_MADENDA == "0000001" || oCamposDet3.COD_MADENDA == "0000003")
                                {
                                    //listaFiltro = new List<CEntidad>();
                                    //listaFiltro = (from p in oCEntidad.ListTDDVADEAREA where p.COD_MADENDA == oCamposDet.COD_MADENDA && p.ADENDA_FECHA_INICIO == oCamposDet.ADENDA_FECHA_INICIO select p).ToList<CEntidad>();

                                    //if (oCEntidad.ListTDDVADEAREA != null)
                                    if (loDatos.ListTDDVADEAREA != null)
                                    {
                                        //foreach (var loDatos2 in listaFiltro)
                                        foreach (var loDatos2 in loDatos.ListTDDVADEAREA)
                                        {
                                            if (loDatos2.RegEstado == 1 || loDatos2.RegEstado == 2) //Nuevo o Modificado
                                            {
                                                oCamposDet4 = new CEntidad();
                                                oCamposDet4.COD_THABILITANTE = oCEntidad.COD_THABILITANTE;
                                                oCamposDet4.VERTICE = loDatos2.VERTICE;
                                                oCamposDet4.ZONA = loDatos2.ZONA == "" ? null : loDatos2.ZONA;
                                                oCamposDet4.COORDENADA_ESTE = loDatos2.COORDENADA_ESTE;
                                                oCamposDet4.COORDENADA_NORTE = loDatos2.COORDENADA_NORTE;
                                                oCamposDet4.OBSERVACION = loDatos2.OBSERVACION;
                                                oCamposDet4.COD_SECUENCIAL_ADENDA = OUTPUTSEC;
                                                oCamposDet4.COD_SECUENCIAL = loDatos2.COD_SECUENCIAL;
                                                oCamposDet4.RegEstado = loDatos2.RegEstado;
                                                dBOracle.ManExecute(cn, tr, "doc_osinfor_erp_migracion.spTHABILITANTE_DGENERAL_DET_VERTICEGrabar", oCamposDet4);
                                                //oGDataSQL.ManExecute(cn, tr, "DOC.spTHABILITANTE_DG_ADENDA_AREAGrabar", oCamposDet3);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                //adendas de cambio de modalidad
                if (oCEntidad.ListModalidadesTH != null)
                {
                    foreach (var loDatos in oCEntidad.ListModalidadesTH)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            oCamposDet = new CEntidad();

                            oCamposDet.COD_THABILITANTE = oCEntidad.COD_THABILITANTE;
                            oCamposDet.COD_MADENDA = loDatos.COD_MADENDA;
                            oCamposDet.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            oCamposDet.NUM_THABILITANTE_ADENDA = loDatos.NUM_THABILITANTE_ADENDA;
                            oCamposDet.NUM_RESOLUCION_ADENDA = loDatos.NUM_RESOLUCION_ADENDA;
                            oCamposDet.COD_FUNCIONARIO_ADENDA = loDatos.COD_FUNCIONARIO_ADENDA;
                            oCamposDet.COD_TITULAR_ADENDA = loDatos.COD_TITULAR_ADENDA;
                            oCamposDet.ADENDA_FECHA_INICIO = loDatos.ADENDA_FECHA_INICIO;
                            oCamposDet.ADENDA_FECHA_TERMINO = loDatos.ADENDA_FECHA_TERMINO;
                            oCamposDet.OBSERVACION = loDatos.OBSERVACION;
                            oCamposDet.AREA_OTORGADA = loDatos.AREA_OTORGADA;
                            oCamposDet.COD_MTIPO = loDatos.COD_MTIPO;
                            oCamposDet.RegEstado = loDatos.RegEstado;
                            oCamposDet.CODMTIPO_ANTERIOR = loDatos.CODMTIPO_ANTERIOR;
                            //24.04.2021
                            oCamposDet.NUMERO = loDatos.NUMERO;
                            oCamposDet.RES_TITULAR = loDatos.RES_TITULAR;
                            oCamposDet.AFUNCIONAMIENTO_NUM_RESOL = loDatos.AFUNCIONAMIENTO_NUM_RESOL;
                            dBOracle.ManExecute(cn, tr, "doc_osinfor_erp_migracion.spTHABILITANTE_DG_ADENDAGrabar", oCamposDet);
                            //oGDataSQL.ManExecute(cn, tr, "DOC.spTHABILITANTE_DGENERAL_DET_VERTICEGrabar", oCamposDet);
                            //using (SqlCommand cmd = oGDataSQL.ManExecuteOutput(cn, tr, "DOC.spTHABILITANTE_DG_ADENDAGrabar", oCamposDet))
                            if (loDatos.COD_MADENDA == "0000007")
                            {
                                oCEntidad.COD_MTIPO = loDatos.COD_MTIPO;
                                oCEntidad.AFUNCIONAMIENTO_NUM_RESOL = loDatos.NUM_RESOLUCION_ADENDA;
                                if (loDatos.NUMERO != null && loDatos.NUMERO.Trim() != "")
                                {
                                    oCEntidad.NUMERO_OLD = oCEntidad.NUMERO;
                                    oCEntidad.NUMERO = loDatos.NUMERO;
                                }
                                if (loDatos.RES_TITULAR != null && loDatos.RES_TITULAR.Trim() != "")
                                {
                                    oCEntidad.RES_TITULAR = loDatos.RES_TITULAR;
                                }
                                //dBOracle.ManExecute(cn, tr, sp_Sigo, oCEntidad);
                                using (OracleCommand cmd1 = dBOracle.ManExecuteOutput(cn, tr, sp_Sigo, oCEntidad))
                                {
                                    cmd1.ExecuteNonQuery();
                                    String result = (String)cmd1.Parameters["OUTPUTPARAM01"].Value;
                                }
                            }
                        }
                    }
                }

                if (oCEntidad.ListTHEstadoEsta != null)
                {
                    foreach (var loDatos in oCEntidad.ListTHEstadoEsta)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            oCamposDet3 = new CEntidad();
                            //oCamposDet3.iv_CUENTA_PLAN_MANEJO = 0;
                            oCamposDet3.COD_THABILITANTE = oCEntidad.COD_THABILITANTE;
                            oCamposDet3.COD_THABILITANTE_EVALUACION_FAUNA = loDatos.COD_THABILITANTE_EVALUACION_FAUNA;
                            oCamposDet3.COD_MOTIVO_EV = loDatos.COD_MOTIVO_EV;
                            oCamposDet3.NUMERO = loDatos.NUMERO;
                            oCamposDet3.FECHA_AFFS = loDatos.FECHA_AFFS;
                            oCamposDet3.NOMBRE_FIRMA_RES = loDatos.NOMBRE_FIRMA_RES;
                            oCamposDet3.N_DOCUMENTO = loDatos.N_DOCUMENTO;
                            oCamposDet3.FECHA_DOC = loDatos.FECHA_DOC;
                            oCamposDet3.NOMBRE_AFFS = loDatos.NOMBRE_AFFS;
                            oCamposDet3.OBSERVACION = loDatos.OBSERVACION;
                            //if (oCamposDet3.FECHA_AFFS.ToString() == "")
                            /*
                            if (String.IsNullOrEmpty(oCamposDet3.FECHA_AFFS.ToString()))
                            {
                                oCamposDet3.FECHA_AFFS = null;
                            }
                            */
                            if (oCamposDet3.COD_THABILITANTE_EVALUACION_FAUNA != null)
                            {
                                oCamposDet3.RegEstado = 2;
                            }
                            else
                            {
                                oCamposDet3.RegEstado = 1;
                            }
                            dBOracle.ManExecute(cn, tr, "doc_osinfor_erp_migracion.spTHABILITANTE_ESTDO_ESTGrabar", oCamposDet3);

                        }
                    }
                }

                //Registrar Error Material
                if (oCEntidad.ListErrorMaterialGeneral != null)
                {
                    Ent_ERRORMATERIAL oCampos;

                    foreach (var loDatos in oCEntidad.ListErrorMaterialGeneral)
                    {
                        if (loDatos.COD_SECUENCIAL == -1)
                        {
                            oCampos = new Ent_ERRORMATERIAL();
                            oCampos.COD_THABILITANTE = oCEntidad.COD_THABILITANTE;
                            oCampos.NV_TIPO = loDatos.NV_TIPO;
                            oCampos.NV_RESOLUCION = loDatos.NV_RESOLUCION;
                            oCampos.DA_FECRESOLUCION = loDatos.DA_FECRESOLUCION;
                            oCampos.NV_NOMCAMPO = loDatos.NV_NOMCAMPO;
                            oCampos.NV_VALANTERIOR = loDatos.NV_VALANTERIOR;
                            oCampos.NV_VALACTUAL = loDatos.NV_VALACTUAL;
                            oCampos.NV_OBSERVACION = loDatos.NV_OBSERVACION;
                            oCampos.COD_UCUENTA = oCEntidad.COD_UCUENTA;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spTHABILITANTE_ERROR_MATERIAL_Grabar", oCampos);
                        }
                    }
                }

                if (oCEntidad.ListErrorMaterialAdicional != null)
                {
                    Ent_ERRORMATERIAL oCampos;

                    foreach (var loDatos in oCEntidad.ListErrorMaterialAdicional)
                    {
                        if (loDatos.COD_SECUENCIAL == -1)
                        {
                            oCampos = new Ent_ERRORMATERIAL();
                            oCampos.COD_THABILITANTE = oCEntidad.COD_THABILITANTE;
                            oCampos.NV_TIPO = loDatos.NV_TIPO;
                            oCampos.NV_RESOLUCION = loDatos.NV_RESOLUCION;
                            oCampos.DA_FECRESOLUCION = loDatos.DA_FECRESOLUCION;
                            oCampos.NV_NOMCAMPO = loDatos.NV_NOMCAMPO;
                            oCampos.NV_VALANTERIOR = loDatos.NV_VALANTERIOR;
                            oCampos.NV_VALACTUAL = loDatos.NV_VALACTUAL;
                            oCampos.NV_OBSERVACION = loDatos.NV_OBSERVACION;
                            oCampos.COD_UCUENTA = oCEntidad.COD_UCUENTA;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spTHABILITANTE_ERROR_MATERIAL_Grabar", oCampos);
                        }
                    }
                }

                //para guardar el listado de extencion
                if (oCEntidad.ListTHExtincion != null)
                {
                    Ent_THABILITANTE oCampos;

                    foreach (var loDatos in oCEntidad.ListTHExtincion)
                    {
                        if (loDatos.RegEstado == 1)
                        {
                            oCampos = new Ent_THABILITANTE();
                            oCampos.COD_THABILITANTE = oCEntidad.COD_THABILITANTE;
                            oCampos.MOTIVO = loDatos.COD_MOTIVO;
                            oCampos.NUM_RESOLUCION = loDatos.NUM_RESOLUCION;
                            oCampos.FECHA = loDatos.FECHA;
                            oCampos.OBSERVACION = loDatos.OBSERVACION;
                            oCampos.RegEstado = 1;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.THABILITANTE_EXTINCIONGrabar", oCampos);
                        }
                    }
                }
                //para guardar Division Interna
                if (oCEntidad.ListDivisionInterna != null)
                {
                    Ent_DIVISIONINTERNA oDivInterna;
                    int i = 1;
                    foreach (var loDatos in oCEntidad.ListDivisionInterna)
                    {
                        oDivInterna = new Ent_DIVISIONINTERNA();
                        oDivInterna.COD_THABILITANTE = oCEntidad.COD_THABILITANTE;
                        oDivInterna.COD_SECUENCIAL = i;
                        oDivInterna.TIPOAREA = loDatos.TIPOAREA;
                        oDivInterna.SUBTIPOAREA = loDatos.SUBTIPOAREA;
                        oDivInterna.SUBTIPOAREADESC = loDatos.SUBTIPOAREADESC;
                        oDivInterna.AREA = loDatos.AREA;
                        oDivInterna.DESCRIPCIONAREA = loDatos.DESCRIPCIONAREA;
                        oDivInterna.COD_UCUENTA = oCEntidad.COD_UCUENTA;
                        dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.THABILITANTE_DivIntGrabar", oDivInterna);
                        i++;
                    }
                }

                if (oCEntidad.ListEliTABLAExt != null)
                {
                    foreach (var loDatos in oCEntidad.ListEliTABLAExt)
                    {
                        oCamposDet = new CEntidad();
                        oCamposDet.COD_THABILITANTE = oCEntidad.COD_THABILITANTE;
                        oCamposDet.EliTABLA = loDatos.EliTABLA;
                        oCamposDet.EliVALOR01 = loDatos.EliVALOR01;
                        oCamposDet.EliVALOR02 = loDatos.EliVALOR02;
                        oCamposDet.EliVALOR03 = loDatos.EliVALOR03;
                        oCamposDet.EliVALOR04 = loDatos.EliVALOR04;
                        oCamposDet.COD_AREA_SECUENCIAL = loDatos.COD_AREA_SECUENCIAL;
                        dBOracle.ManExecute(cn, tr, "doc_osinfor_erp_migracion.spTHABILITANTEEliminarDetalle", oCamposDet);
                    }
                }

                oCamposActTH = new CEntidad();
                oCamposActTH.COD_THABILITANTE = oCEntidad.COD_THABILITANTE;
                using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, tr, "doc_osinfor_erp_migracion.spTHABILITANTE_VALIDACION", oCamposActTH))
                {
                    cmd.ExecuteNonQuery();
                    OUTPUTPARAM01 = (String)cmd.Parameters["OUTPUTPARAM01"].Value;
                    if (OUTPUTPARAM01 == "99")
                    {
                        throw new Exception("Ud. no tiene permiso para realizar esta acción");
                    }
                }

                return OUTPUTPARAM01;// + '|' + OUTPUTPARAM02;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
