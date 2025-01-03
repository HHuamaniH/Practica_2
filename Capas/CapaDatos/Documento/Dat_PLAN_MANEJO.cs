using CapaEntidad.DOC;
using CapaEntidad.ViewModel;
using GeneralSQL;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using CEntidad = CapaEntidad.DOC.Ent_PLAN_MANEJO;
using SQL = GeneralSQL.Data.SQL;
using VM = CapaEntidad.ViewModel.VM_PlanManejoExituList;

namespace CapaDatos.DOC
{
    /// <summary>
    /// 
    /// </summary>
    public class Dat_PLAN_MANEJO
    {
        private SQL oGDataSQL = new SQL();

        private DBOracle dBOracle = new DBOracle();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public List<CEntidad> RegMostrarLista(OracleConnection cn, CEntidad oCEntidad)
        {
            CEntidad oCampos = new CEntidad();
            oCampos.ListManTHabilitante = new List<CEntidad>();

            List<CEntidad> lsCEntidad = new List<CEntidad>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spGeneral_Listar", oCEntidad))
                {
                    if (dr != null)
                    {
                        CEntidad oCamposDetItem;
                        CEntidad oCamposdet;
                        if (dr.HasRows)
                        {

                            int p1 = dr.GetOrdinal("COD_PMANEJO");
                            int p01 = dr.GetOrdinal("COD_THABILITANTE");
                            int p02 = dr.GetOrdinal("FECHA");
                            int p2 = dr.GetOrdinal("FECHA_PRESENTACION");
                            int p3 = dr.GetOrdinal("MODALIDAD");
                            int p4 = dr.GetOrdinal("NUM_THABILITANTE");
                            int p5 = dr.GetOrdinal("PERSONA_TITULAR");
                            int p6 = dr.GetOrdinal("ARESOLUCION_NUM");
                            int p7 = dr.GetOrdinal("COD_MTIPO");
                            int p07 = dr.GetOrdinal("ESTADO_ORIGEN_TIPO");
                            int p8 = dr.GetOrdinal("INDICADOR");
                            int p9 = dr.GetOrdinal("ESTADO_ORIGEN");
                            int p10 = dr.GetOrdinal("HIJO_COD_PMANEJO");
                            int p11 = dr.GetOrdinal("HIJO_NIVEL");
                            Int32 NumReg = 0;
                            while (dr.Read())
                            {
                                oCamposdet = new CEntidad();
                                oCamposdet.COD_PMANEJO = dr.GetString(p1);
                                oCamposdet.COD_THABILITANTE = dr.GetString(p01);
                                oCamposdet.FECHA = dr.GetString(p02);
                                oCamposdet.FECHA_PRESENTACION = dr.GetString(p2);
                                oCamposdet.MODALIDAD = dr.GetString(p3);
                                oCamposdet.NUM_THABILITANTE = dr.GetString(p4);
                                oCamposdet.PERSONA_TITULAR = dr.GetString(p5);
                                oCamposdet.ARESOLUCION_NUM = dr.GetString(p6);
                                oCamposdet.COD_MTIPO = dr.GetString(p7);
                                oCamposdet.ESTADO_ORIGEN_TIPO = dr.GetString(p07);
                                oCamposdet.INDICADOR = dr.GetString(p8);
                                oCamposdet.ESTADO_ORIGEN = dr.GetString(p9);
                                oCamposdet.HIJO_COD_PMANEJO = dr.GetString(p10);
                                oCamposdet.HIJO_NIVEL = dr.GetInt32(p11);
                                NumReg = (from p in oCampos.ListManTHabilitante where p.NUM_THABILITANTE == dr.GetString(p4) select p).Count();
                                if (NumReg == 0)
                                {
                                    oCamposDetItem = new CEntidad();
                                    oCamposDetItem.COD_THABILITANTE = oCamposdet.COD_THABILITANTE;
                                    oCamposDetItem.FECHA = oCamposdet.FECHA;
                                    oCamposDetItem.FECHA_PRESENTACION = oCamposdet.FECHA_PRESENTACION;
                                    oCamposDetItem.MODALIDAD = oCamposdet.MODALIDAD;
                                    oCamposDetItem.PERSONA_TITULAR = oCamposdet.PERSONA_TITULAR;
                                    oCamposDetItem.NUM_THABILITANTE = oCamposdet.NUM_THABILITANTE;
                                    oCampos.ListManTHabilitante.Add(oCamposDetItem); //Por Cambiar
                                }
                                lsCEntidad.Add(oCamposdet);
                            }
                            Int32 IndexTHabilitante = -1;
                            Int32 IndexPoa;
                            Int32 IndexPoaItem;
                            Int32 IndexPoaItemDet;
                            foreach (var lsRegTHabilitante in oCampos.ListManTHabilitante)
                            {
                                //PLAN MANEJO
                                IndexTHabilitante += 1;
                                lsRegTHabilitante.ListManPlanManejo = (from p in lsCEntidad where p.COD_THABILITANTE == lsRegTHabilitante.COD_THABILITANTE && p.HIJO_COD_PMANEJO == "" orderby p.COD_PMANEJO select p).ToList<CEntidad>();
                                //
                                IndexPoa = -1;
                                foreach (var lsRegPoa in lsRegTHabilitante.ListManPlanManejo)
                                {
                                    IndexPoa += 1;
                                    lsRegPoa.LISTA_INDEX = String.Format("{0}-{1}", IndexTHabilitante.ToString(), IndexPoa.ToString());
                                    //PLAN MANEJO Items Hijo
                                    lsRegPoa.ListManPlanManejoItem = (from p in lsCEntidad where p.COD_THABILITANTE == lsRegPoa.COD_THABILITANTE && p.HIJO_COD_PMANEJO == lsRegPoa.COD_PMANEJO && p.HIJO_NIVEL == 1 orderby p.FECHA select p).ToList<CEntidad>();
                                    IndexPoaItem = -1;

                                    foreach (var lsRegPoaItem in lsRegPoa.ListManPlanManejoItem)
                                    {
                                        IndexPoaItem += 1;
                                        lsRegPoaItem.LISTA_INDEX = String.Format("{0}-{1}", lsRegPoa.LISTA_INDEX, IndexPoaItem.ToString());
                                        //
                                        //PLAN MANEJO Items Hijo Items
                                        lsRegPoaItem.ListManPlanManejoDetItem = (from p in lsCEntidad where p.COD_THABILITANTE == lsRegPoaItem.COD_THABILITANTE && p.HIJO_COD_PMANEJO == lsRegPoaItem.COD_PMANEJO && p.HIJO_NIVEL == 2 orderby p.FECHA select p).ToList<CEntidad>();
                                        IndexPoaItemDet = -1;
                                        foreach (var lsRegPoaItemDet in lsRegPoaItem.ListManPlanManejoDetItem)
                                        {
                                            IndexPoaItemDet += 1;
                                            lsRegPoaItemDet.LISTA_INDEX = String.Format("{0}-{1}", lsRegPoaItem.LISTA_INDEX, IndexPoaItemDet.ToString());
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                return oCampos.ListManTHabilitante;
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
        //public CEntidad RegMostrarListaItems(OracleConnection cn, CEntidad oCEntidad)
        //{
        //    CEntidad oCampos = new CEntidad();
        //    try
        //    {
        //        using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spPLAN_MANEJOMostItems", oCEntidad))
        //        {
        //            if (dr != null)
        //            {
        //                oCampos.ListPMDTTIOCULAR = new List<CEntidad>();
        //                oCampos.ListPMDTTRAPROBACION = new List<CEntidad>();
        //                oCampos.ListPMDISITUCAREA = new List<CEntidad>();
        //                oCampos.ListPMDISITUFAUNA = new List<CEntidad>();
        //                oCampos.ListPMDISITUFLORA = new List<CEntidad>();
        //                //TARA
        //                oCampos.ListPMTDOOPCIONESEAPROVE = new List<CEntidad>();
        //                oCampos.ListPMTDOOPCIONESPSILVI = new List<CEntidad>();
        //                oCampos.ListPMTDPPAPROVECHAMIENTO = new List<CEntidad>();
        //                oCampos.ListPMTBEXTRACCION = new List<CEntidad>();
        //                oCampos.ListPMTINVENTARIO = new List<CEntidad>();
        //                oCampos.ListEliTABLA = new List<CEntidad>();
        //                oCampos.ListPMTCOORDENADAUTM = new List<CEntidad>();
        //                oCampos.ListPMTAAPROVECHAMIENTO = new List<CEntidad>();
        //                oCampos.ListPMTAUTORIZADAEXTRA = new List<CEntidad>();
        //                oCampos.ListPMINFORME_ANUAL = new List<CEntidad>();
        //                oCampos.ListPMECOTPROGIMPLEMENTAR = new List<CEntidad>();
        //                oCampos.ListDependencia = new List<CEntidad>();
        //                CEntidad oCamposDet;
        //                //
        //                if (dr.HasRows)
        //                {
        //                    dr.Read();
        //                    oCampos.COD_PMANEJO = dr.GetString(dr.GetOrdinal("COD_PMANEJO"));
        //                    oCampos.FECHA_PRESENTACION = dr.GetString(dr.GetOrdinal("FECHA_PRESENTACION"));
        //                    oCampos.IS_DURACION_FINICIO = dr.GetString(dr.GetOrdinal("IS_DURACION_FINICIO"));
        //                    oCampos.IS_DURACION_FFIN = dr.GetString(dr.GetOrdinal("IS_DURACION_FFIN"));
        //                    oCampos.TARA_AREA_PREDIO = Decimal.Parse(dr.GetString(dr.GetOrdinal("TARA_AREA_PREDIO")));
        //                    oCampos.TARA_AREA_MANEJO = Decimal.Parse(dr.GetString(dr.GetOrdinal("TARA_AREA_MANEJO")));
        //                    oCampos.CONSULTOR_CODIGO = dr.GetString(dr.GetOrdinal("CONSULTOR_CODIGO"));
        //                    oCampos.CONSULTOR_NUM_REGISTRO_FFS = dr.GetString(dr.GetOrdinal("CONSULTOR_NUM_REGISTRO_FFS"));
        //                    oCampos.CONSULTOR_NOMBRE = dr.GetString(dr.GetOrdinal("CONSULTOR_NOMBRE"));
        //                    oCampos.CONSULTOR_DNI = dr.GetString(dr.GetOrdinal("CONSULTOR_DNI"));
        //                    oCampos.CONSULTOR_NUM_REGISTRO_PROFESIONAL = dr.GetString(dr.GetOrdinal("CONSULTOR_NUM_REGISTRO_PROFESIONAL"));
        //                    oCampos.ITECNICO_IOCULAR_NUM = dr.GetString(dr.GetOrdinal("ITECNICO_IOCULAR_NUM"));
        //                    oCampos.ITECNICO_IOCULAR_FECHA = dr.GetString(dr.GetOrdinal("ITECNICO_IOCULAR_FECHA"));
        //                    oCampos.ITECNICO_RAPROBACION_NUM = dr.GetString(dr.GetOrdinal("ITECNICO_RAPROBACION_NUM"));
        //                    oCampos.ITECNICO_RAPROBACION_FECHA = dr.GetString(dr.GetOrdinal("ITECNICO_RAPROBACION_FECHA"));
        //                    oCampos.ARESOLUCION_NUM = dr.GetString(dr.GetOrdinal("ARESOLUCION_NUM"));
        //                    oCampos.ARESOLUCION_FECHA = dr.GetString(dr.GetOrdinal("ARESOLUCION_FECHA"));
        //                    oCampos.ARESOLUCION_COD_FUNCIONARIO = dr.GetString(dr.GetOrdinal("ARESOLUCION_COD_FUNCIONARIO"));
        //                    oCampos.ARESOLUCION_FUNCIONARIO_NOMBRE = dr.GetString(dr.GetOrdinal("ARESOLUCION_FUNCIONARIO_NOMBRE"));
        //                    oCampos.ARESOLUCION_FUNCIONARIO_ODATOS = dr.GetString(dr.GetOrdinal("ARESOLUCION_FUNCIONARIO_ODATOS"));
        //                    oCampos.ACORDE_TDR_VIGENTE = dr.GetBoolean(dr.GetOrdinal("ACORDE_TDR_VIGENTE"));
        //                    oCampos.OBSERVACION = dr.GetString(dr.GetOrdinal("OBSERVACION"));
        //                    oCampos.COD_THABILITANTE = dr.GetString(dr.GetOrdinal("COD_THABILITANTE"));
        //                    oCampos.COD_MTIPO = dr.GetString(dr.GetOrdinal("COD_MTIPO"));
        //                    oCampos.ESTADO_ORIGEN = dr.GetString(dr.GetOrdinal("ESTADO_ORIGEN"));
        //                    oCampos.INDICADOR = dr.GetString(dr.GetOrdinal("INDICADOR"));
        //                    oCampos.COD_DEPENDENCIA = dr.GetInt32(dr.GetOrdinal("COD_DEPENDENCIA")).ToString();
        //                    //
        //                    //Tara
        //                    //oCampos.NUM_ARBOLES_EDAD_APRO = dr.GetInt32(dr.GetOrdinal("NUM_ARBOLES_EDAD_APRO"));
        //                    //oCampos.NUM_ARBOLES_NOEDAD_APRO = dr.GetInt32(dr.GetOrdinal("NUM_ARBOLES_NOEDAD_APRO"));
        //                    //oCampos.PESO_ARBOLES_EDAD_APRO = Decimal.Parse(dr.GetString(dr.GetOrdinal("PESO_ARBOLES_EDAD_APRO")));
        //                    oCampos.ACTIVIDAD_CAPACITACION = dr.GetString(dr.GetOrdinal("ACTIVIDAD_CAPACITACION"));
        //                    oCampos.MODALIDAD_COMERCIALIZACION = dr.GetString(dr.GetOrdinal("MODALIDAD_COMERCIALIZACION"));
        //                    oCampos.ANO_EPLANTACION = dr.GetInt32(dr.GetOrdinal("ANO_EPLANTACION"));
        //                    oCampos.NUM_PCOMPLEMENTARIO = dr.GetString(dr.GetOrdinal("NUM_PCOMPLEMENTARIO"));
        //                    oCampos.APROB_ACTIVIDAD_ESTADO = dr.GetBoolean(dr.GetOrdinal("APROB_ACTIVIDAD_ESTADO"));
        //                    oCampos.APROB_ACTIVIDAD_FECHA = dr.GetString(dr.GetOrdinal("APROB_ACTIVIDAD_FECHA"));
        //                    oCampos.APROB_ACTIVIDAD_AUTORIDAD = dr.GetString(dr.GetOrdinal("APROB_ACTIVIDAD_AUTORIDAD"));
        //                    oCampos.APROB_ACTIVIDAD_RESOLUCION = dr.GetString(dr.GetOrdinal("APROB_ACTIVIDAD_RESOLUCION"));
        //                    oCampos.APROB_ACTIVIDAD_FUNCIONARIO = dr.GetString(dr.GetOrdinal("APROB_ACTIVIDAD_FUNCIONARIO"));
        //                    oCampos.FUNCIONARIO_APROB_ACTIVIDAD = dr.GetString(dr.GetOrdinal("FUNCIONARIO_APROB_ACTIVIDAD"));
        //                    oCampos.COD_OD_REGISTRO = dr.GetString(dr.GetOrdinal("COD_OD_REGISTRO"));
        //                    oCampos.USUARIO_REGISTRO = dr.GetString(dr.GetOrdinal("USUARIO_REGISTRO"));
        //                    oCampos.REGENTE_NUM_REGISTRO_FFS = dr.GetString(dr.GetOrdinal("REGENTE_NUM_REGISTRO_FFS"));

        //                }
        //                //Estado (Calidad)
        //                dr.NextResult();
        //                if (dr.HasRows)
        //                {
        //                    dr.Read();
        //                    oCampos.COD_ESTADO_DOC = dr.GetString(dr.GetOrdinal("COD_ESTADO_DOC"));
        //                    oCampos.OBSERVACIONES_CONTROL = dr.GetString(dr.GetOrdinal("OBSERVACIONES_CONTROL"));
        //                    oCampos.OBSERV_SUBSANAR = dr.GetBoolean(dr.GetOrdinal("OBSERV_SUBSANAR"));
        //                    oCampos.USUARIO_CONTROL = dr.GetString(dr.GetOrdinal("USUARIO_CONTROL"));
        //                }
        //                else
        //                {
        //                    oCampos.COD_ESTADO_DOC = "";
        //                    oCampos.OBSERVACIONES_CONTROL = "";
        //                    oCampos.OBSERV_SUBSANAR = false;
        //                    oCampos.USUARIO_CONTROL = "";
        //                }
        //                //PLAN_MANEJO_DET_TIOCULAR
        //                dr.NextResult();
        //                if (dr.HasRows)
        //                {
        //                    int pt1 = dr.GetOrdinal("COD_PERSONA");
        //                    int pt2 = dr.GetOrdinal("PERSONA");
        //                    int pt3 = dr.GetOrdinal("N_DOCUMENTO");
        //                    int pt4 = dr.GetOrdinal("CARGO");
        //                    while (dr.Read())
        //                    {
        //                        oCamposDet = new CEntidad();
        //                        oCamposDet.COD_PERSONA = dr.GetString(pt1);
        //                        oCamposDet.PERSONA = dr.GetString(pt2);
        //                        oCamposDet.N_DOCUMENTO = dr.GetString(pt3);
        //                        oCamposDet.CARGO = dr.GetString(pt4);
        //                        oCamposDet.RegEstado = 0;
        //                        oCampos.ListPMDTTIOCULAR.Add(oCamposDet);
        //                    }
        //                }
        //                //PLAN_MANEJO_DET_TRAPROBACION
        //                dr.NextResult();
        //                if (dr.HasRows)
        //                {
        //                    int pt1 = dr.GetOrdinal("COD_PERSONA");
        //                    int pt2 = dr.GetOrdinal("PERSONA");
        //                    int pt3 = dr.GetOrdinal("N_DOCUMENTO");
        //                    int pt4 = dr.GetOrdinal("CARGO");
        //                    while (dr.Read())
        //                    {
        //                        oCamposDet = new CEntidad();
        //                        oCamposDet.COD_PERSONA = dr.GetString(pt1);
        //                        oCamposDet.PERSONA = dr.GetString(pt2);
        //                        oCamposDet.N_DOCUMENTO = dr.GetString(pt3);
        //                        oCamposDet.CARGO = dr.GetString(pt4);
        //                        oCamposDet.RegEstado = 0;
        //                        oCampos.ListPMDTTRAPROBACION.Add(oCamposDet);
        //                    }
        //                }
        //                //PLAN_MANEJO_INSITU_DET_CAREA
        //                dr.NextResult();
        //                if (dr.HasRows)
        //                {
        //                    int pt1 = dr.GetOrdinal("COD_CAREA");
        //                    int pt2 = dr.GetOrdinal("DESCRIPCION");
        //                    while (dr.Read())
        //                    {
        //                        oCamposDet = new CEntidad();
        //                        oCamposDet.COD_CAREA = dr.GetString(pt1);
        //                        oCamposDet.DESCRIPCION = dr.GetString(pt2);
        //                        oCamposDet.RegEstado = 0;
        //                        oCampos.ListPMDISITUCAREA.Add(oCamposDet);
        //                    }
        //                }
        //                //PLAN_MANEJO_INSITU_DET_INV_FAUNA
        //                dr.NextResult();
        //                if (dr.HasRows)
        //                {
        //                    int pt1 = dr.GetOrdinal("COD_ESPECIES");
        //                    int pt2 = dr.GetOrdinal("COD_SECUENCIAL");
        //                    int pt3 = dr.GetOrdinal("ESPECIES");
        //                    int pt4 = dr.GetOrdinal("OBSERVACION");
        //                    while (dr.Read())
        //                    {
        //                        oCamposDet = new CEntidad();
        //                        oCamposDet.COD_ESPECIES = dr.GetString(pt1);
        //                        oCamposDet.COD_SECUENCIAL = dr.GetInt32(pt2);
        //                        oCamposDet.ESPECIES = dr.GetString(pt3);
        //                        oCamposDet.OBSERVACION = dr.GetString(pt4);
        //                        oCamposDet.RegEstado = 0;
        //                        oCampos.ListPMDISITUFAUNA.Add(oCamposDet);
        //                    }
        //                }
        //                //PLAN_MANEJO_INSITU_DET_INV_FLORA
        //                dr.NextResult();
        //                if (dr.HasRows)
        //                {
        //                    int pt1 = dr.GetOrdinal("COD_ESPECIES");
        //                    int pt2 = dr.GetOrdinal("COD_SECUENCIAL");
        //                    int pt3 = dr.GetOrdinal("ESPECIES");
        //                    int pt4 = dr.GetOrdinal("CARACTERISTICAS");
        //                    int pt5 = dr.GetOrdinal("RASOCIACIONES_FAUNA");
        //                    int pt6 = dr.GetOrdinal("OBSERVACION");
        //                    while (dr.Read())
        //                    {
        //                        oCamposDet = new CEntidad();
        //                        oCamposDet.COD_ESPECIES = dr.GetString(pt1);
        //                        oCamposDet.COD_SECUENCIAL = dr.GetInt32(pt2);
        //                        oCamposDet.ESPECIES = dr.GetString(pt3);
        //                        oCamposDet.CARACTERISTICAS = dr.GetString(pt4);
        //                        oCamposDet.RASOCIACIONES_FAUNA = dr.GetString(pt5);
        //                        oCamposDet.OBSERVACION = dr.GetString(pt6);
        //                        oCamposDet.RegEstado = 0;
        //                        oCampos.ListPMDISITUFLORA.Add(oCamposDet);
        //                    }
        //                }
        //                //PLAN_MANEJO_TARA_DET_PAPROVECHAMIENTO
        //                dr.NextResult();
        //                if (dr.HasRows)
        //                {
        //                    int pt1 = dr.GetOrdinal("COD_SECUENCIAL");
        //                    int pt2 = dr.GetOrdinal("ANO");
        //                    int pt3 = dr.GetOrdinal("NUM_ARBOLES");
        //                    int pt4 = dr.GetOrdinal("PESO_VAINAS");
        //                    int pt5 = dr.GetOrdinal("NUM_COSECHA");
        //                    int pt6 = dr.GetOrdinal("NUM_QUINTALES");
        //                    int pt7 = dr.GetOrdinal("OBSERVACION");
        //                    while (dr.Read())
        //                    {
        //                        oCamposDet = new CEntidad();
        //                        oCamposDet.COD_SECUENCIAL = dr.GetInt32(pt1);
        //                        oCamposDet.ANO = dr.GetInt32(pt2);
        //                        oCamposDet.NUM_ARBOLES = dr.GetInt32(pt3);
        //                        oCamposDet.PESO_VAINAS = Decimal.Parse(dr.GetString(pt4));
        //                        oCamposDet.NUM_COSECHA = dr.GetInt32(pt5);
        //                        oCamposDet.NUM_QUINTALES = dr.GetDecimal(pt6);
        //                        oCamposDet.OBSERVACION = dr.GetString(pt7);
        //                        oCamposDet.RegEstado = 0;
        //                        oCampos.ListPMTDPPAPROVECHAMIENTO.Add(oCamposDet);
        //                    }
        //                }
        //                //PLAN_MANEJO_TARA_DET_OPCIONES
        //                List<CEntidad> ListPMTDOOPCIONES = new List<CEntidad>();
        //                dr.NextResult();
        //                if (dr.HasRows)
        //                {
        //                    int pt1 = dr.GetOrdinal("COD_PMTOPCIONES");
        //                    int pt2 = dr.GetOrdinal("OBSERVACION");
        //                    int pt3 = dr.GetOrdinal("DESCRIPCION");
        //                    int pt4 = dr.GetOrdinal("TIPO");
        //                    int pt5 = dr.GetOrdinal("COD_SECUENCIAL");
        //                    while (dr.Read())
        //                    {
        //                        oCamposDet = new CEntidad();
        //                        oCamposDet.COD_PMTOPCIONES = dr.GetString(pt1);
        //                        oCamposDet.OBSERVACION = dr.GetString(pt2);
        //                        oCamposDet.DESCRIPCION = dr.GetString(pt3);
        //                        oCamposDet.TIPO = dr.GetString(pt4);
        //                        oCamposDet.COD_SECUENCIAL = dr.GetInt32(pt5);
        //                        oCamposDet.RegEstado = 0;
        //                        ListPMTDOOPCIONES.Add(oCamposDet);
        //                    }
        //                    oCampos.ListPMTDOOPCIONESEAPROVE = (from p in ListPMTDOOPCIONES where p.TIPO == "SA" select p).ToList<CEntidad>();
        //                    oCampos.ListPMTDOOPCIONESPSILVI = (from p in ListPMTDOOPCIONES where p.TIPO == "PS" select p).ToList<CEntidad>();
        //                    oCampos.ListPMECOTPROGIMPLEMENTAR = (from p in ListPMTDOOPCIONES where p.TIPO == "PI" || p.TIPO == "CS" select p).ToList<CEntidad>();
        //                }
        //                //PLAN_MANEJO_TARA_DET_COORDENADAUTM
        //                dr.NextResult();
        //                if (dr.HasRows)
        //                {
        //                    int pt1 = dr.GetOrdinal("COD_SECUENCIAL");
        //                    int pt2 = dr.GetOrdinal("NUM_PARCELA");
        //                    int pt3 = dr.GetOrdinal("NUM_PUNTOS");
        //                    int pt4 = dr.GetOrdinal("COORDENADA_ESTE");
        //                    int pt5 = dr.GetOrdinal("COORDENADA_NORTE");
        //                    int pt6 = dr.GetOrdinal("OBSERVACION");
        //                    while (dr.Read())
        //                    {
        //                        oCamposDet = new CEntidad();
        //                        oCamposDet.COD_SECUENCIAL = dr.GetInt32(pt1);
        //                        oCamposDet.NUM_PARCELA = dr.GetString(pt2);
        //                        oCamposDet.NUM_PUNTOS = dr.GetString(pt3);
        //                        oCamposDet.COORDENADA_ESTE = dr.GetInt32(pt4);
        //                        oCamposDet.COORDENADA_NORTE = dr.GetInt32(pt5);
        //                        oCamposDet.OBSERVACION = dr.GetString(pt6);
        //                        oCamposDet.RegEstado = 0;
        //                        oCampos.ListPMTCOORDENADAUTM.Add(oCamposDet);
        //                    }
        //                }
        //                //PLAN_MANEJO_TARA_DET_AAPROVECHAMIENTO
        //                dr.NextResult();
        //                if (dr.HasRows)
        //                {
        //                    int pt1 = dr.GetOrdinal("COD_SECUENCIAL");
        //                    int pt2 = dr.GetOrdinal("NUM_PARCELA");
        //                    int pt3 = dr.GetOrdinal("NUM_ARBOLES_APROVE");
        //                    int pt4 = dr.GetOrdinal("NUM_ARBOLES_NO_APROVE");
        //                    int pt5 = dr.GetOrdinal("PRODUCCION_ANUAL_PROMEDIO");
        //                    int pt6 = dr.GetOrdinal("PESO_ESTIMADO_VAINAS");
        //                    int pt7 = dr.GetOrdinal("OBSERVACION");
        //                    while (dr.Read())
        //                    {
        //                        oCamposDet = new CEntidad();
        //                        oCamposDet.COD_SECUENCIAL = dr.GetInt32(pt1);
        //                        oCamposDet.NUM_PARCELA = dr.GetString(pt2);
        //                        oCamposDet.NUM_ARBOLES_APROVE = dr.GetInt32(pt3);
        //                        oCamposDet.NUM_ARBOLES_NO_APROVE = dr.GetInt32(pt4);
        //                        oCamposDet.PRODUCCION_ANUAL_PROMEDIO = dr.GetDecimal(pt5);
        //                        oCamposDet.PESO_ESTIMADO_VAINAS = dr.GetDecimal(pt6);
        //                        oCamposDet.OBSERVACION = dr.GetString(pt7);
        //                        oCamposDet.RegEstado = 0;
        //                        oCampos.ListPMTAAPROVECHAMIENTO.Add(oCamposDet);
        //                    }
        //                }
        //                //PLAN_MANEJO_TARA_DET_CAUTO_EXTRAER
        //                dr.NextResult();
        //                if (dr.HasRows)
        //                {
        //                    int pt1 = dr.GetOrdinal("COD_SECUENCIAL");
        //                    int pt2 = dr.GetOrdinal("COD_ESPECIES");
        //                    int pt3 = dr.GetOrdinal("ESPCIES");
        //                    int pt4 = dr.GetOrdinal("SUPERFICIE_HA");
        //                    int pt5 = dr.GetOrdinal("TOTAL_PGMF");
        //                    int pt6 = dr.GetOrdinal("ANO_1");
        //                    int pt7 = dr.GetOrdinal("ANO_2");
        //                    int pt8 = dr.GetOrdinal("ANO_3");
        //                    int pt9 = dr.GetOrdinal("ANO_4");
        //                    int pt10 = dr.GetOrdinal("ANO_5");
        //                    int pt11 = dr.GetOrdinal("DERECHO_APROVE_QUINTAL");
        //                    int pt12 = dr.GetOrdinal("DERECHO_APROVE_QTOTAL");
        //                    int pt13 = dr.GetOrdinal("OBSERVACION");
        //                    while (dr.Read())
        //                    {
        //                        oCamposDet = new CEntidad();
        //                        oCamposDet.COD_SECUENCIAL = dr.GetInt32(pt1);
        //                        oCamposDet.COD_ESPECIES = dr.GetString(pt2);
        //                        oCamposDet.ESPECIES = dr.GetString(pt3);
        //                        oCamposDet.SUPERFICIE_HA = dr.GetDecimal(pt4);
        //                        oCamposDet.TOTAL_PGMF = dr.GetDecimal(pt5);
        //                        oCamposDet.ANO_1 = dr.GetDecimal(pt6);
        //                        oCamposDet.ANO_2 = dr.GetDecimal(pt7);
        //                        oCamposDet.ANO_3 = dr.GetDecimal(pt8);
        //                        oCamposDet.ANO_4 = dr.GetDecimal(pt9);
        //                        oCamposDet.ANO_5 = dr.GetDecimal(pt10);
        //                        oCamposDet.DERECHO_APROVE_QUINTAL = dr.GetDecimal(pt11);
        //                        oCamposDet.DERECHO_APROVE_QTOTAL = dr.GetDecimal(pt12);
        //                        oCamposDet.OBSERVACION = dr.GetString(pt13);
        //                        oCamposDet.RegEstado = 0;
        //                        oCampos.ListPMTAUTORIZADAEXTRA.Add(oCamposDet);
        //                    }
        //                }
        //                //PLAN_MANEJO_TARA_DET_INVENTARIO
        //                dr.NextResult();
        //                if (dr.HasRows)
        //                {
        //                    int pt1 = dr.GetOrdinal("COD_SECUENCIAL");
        //                    int pt2 = dr.GetOrdinal("N_ARBOL");
        //                    int pt3 = dr.GetOrdinal("CONDICION");
        //                    int pt4 = dr.GetOrdinal("ESTADO_FITOSAN");
        //                    int pt5 = dr.GetOrdinal("ALTURA_ESTIMADO");
        //                    int pt6 = dr.GetOrdinal("PESO_VAINAS_KILOGRAMOS");
        //                    int pt7 = dr.GetOrdinal("COORDENADA_ESTE");
        //                    int pt8 = dr.GetOrdinal("COORDENADA_NORTE");
        //                    int pt9 = dr.GetOrdinal("OBSERVACION");
        //                    while (dr.Read())
        //                    {
        //                        oCamposDet = new CEntidad();
        //                        oCamposDet.COD_SECUENCIAL = dr.GetInt32(pt1);
        //                        oCamposDet.N_ARBOL = dr.GetString(pt2);
        //                        oCamposDet.CONDICION = dr.GetString(pt3);
        //                        oCamposDet.ESTADO_FITOSAN = dr.GetString(pt4);
        //                        oCamposDet.ALTURA_ESTIMADO = Decimal.Parse(dr.GetString(pt5));
        //                        oCamposDet.PESO_VAINAS_KILOGRAMOS = Decimal.Parse(dr.GetString(pt6));
        //                        oCamposDet.COORDENADA_ESTE = dr.GetInt32(pt7);
        //                        oCamposDet.COORDENADA_NORTE = dr.GetInt32(pt8);
        //                        oCamposDet.OBSERVACION = dr.GetString(pt9);
        //                        oCamposDet.RegEstado = 0;
        //                        oCampos.ListPMTINVENTARIO.Add(oCamposDet);
        //                    }
        //                }
        //                ////PLAN_MANEJO_EXSITU_DET_IANUAL
        //                dr.NextResult();
        //                if (dr.HasRows)
        //                {
        //                    int pt1 = dr.GetOrdinal("COD_SECUENCIAL");
        //                    int pt3 = dr.GetOrdinal("ANO_EJECUTADO");
        //                    int pt4 = dr.GetOrdinal("FECHA_EMISION");
        //                    int pt6 = dr.GetOrdinal("PROFESIONAL_CODIGO");
        //                    int pt7 = dr.GetOrdinal("PROFESIONAL_NUM_REGISTRO_FFS");
        //                    int pt8 = dr.GetOrdinal("PROFESIONAL_NOMBRE");
        //                    int pt9 = dr.GetOrdinal("PROFESIONAL_DNI");
        //                    int pt10 = dr.GetOrdinal("PROFESIONAL_NUM_REGISTRO_PROFESIONAL");
        //                    int pt11 = dr.GetOrdinal("ACORDE_TDR_VIGENTE");
        //                    int pt111 = dr.GetOrdinal("PRINCIPAL_ACCION_DESARROLLA");
        //                    int pt12 = dr.GetOrdinal("OBSERVACION");
        //                    while (dr.Read())
        //                    {
        //                        oCamposDet = new CEntidad();
        //                        oCamposDet.COD_SECUENCIAL = dr.GetInt32(pt1);
        //                        oCamposDet.ANO_EJECUTADO = dr.GetInt32(pt3);
        //                        oCamposDet.FECHA_EMISION = dr.GetString(pt4);
        //                        oCamposDet.PROFESIONAL_CODIGO = dr.GetString(pt6);
        //                        oCamposDet.PROFESIONAL_NUM_REGISTRO_FFS = dr.GetString(pt7);
        //                        oCamposDet.PROFESIONAL_NOMBRE = dr.GetString(pt8);
        //                        oCamposDet.PROFESIONAL_DNI = dr.GetString(pt9);
        //                        oCamposDet.PROFESIONAL_NUM_REGISTRO_PROFESIONAL = dr.GetString(pt10);
        //                        oCamposDet.ACORDE_TDR_VIGENTE = dr.GetBoolean(pt11);
        //                        oCamposDet.PRINCIPAL_ACCION_DESARROLLA = dr.GetString(pt111);
        //                        oCamposDet.OBSERVACION = dr.GetString(pt12);
        //                        oCamposDet.RegEstado = 0;
        //                        oCampos.ListPMINFORME_ANUAL.Add(oCamposDet);
        //                    }
        //                }
        //                //Dependencias
        //                dr.NextResult();
        //                if (dr.HasRows)
        //                {
        //                    int pt1 = dr.GetOrdinal("CODIGO");
        //                    int pt2 = dr.GetOrdinal("DESCRIPCION");


        //                    while (dr.Read())
        //                    {
        //                        oCamposDet = new CEntidad();
        //                        oCamposDet.CODIGO = dr.GetInt32(pt1).ToString();
        //                        oCamposDet.DESCRIPCION = dr.GetString(pt2);

        //                        oCampos.ListDependencia.Add(oCamposDet);
        //                    }
        //                }
        //            }
        //        }
        //        return oCampos;
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
        //public CEntidad RegMostrarListaItemsESitu(OracleConnection cn, CEntidad oCEntidad)
        //{
        //    CEntidad oCampos = new CEntidad();
        //    try
        //    {
        //        using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spPLAN_MANEJOMostItemsESitu", oCEntidad))
        //        {
        //            if (dr != null)
        //            {
        //                oCampos.ListPMESITUIANUAL = new List<CEntidad>();
        //                oCampos.ListPGENETICO_FEXSITU_DET_ESPECIE = new List<CEntidad>();
        //                oCampos.ListPMESITUBINDIVIDUAL_E = new List<CEntidad>();
        //                oCampos.ListPMESITUBINDIVIDUAL_I = new List<CEntidad>();
        //                CEntidad oCamposDet;
        //                //
        //                //PLAN_MANEJO_EXSITU_DET_IANUAL
        //                if (dr.HasRows)
        //                {
        //                    int pt1 = dr.GetOrdinal("COD_SECUENCIAL");
        //                    int pt2 = dr.GetOrdinal("COD_UCUENTA");
        //                    int pt3 = dr.GetOrdinal("ANO_EJECUTADO");
        //                    int pt4 = dr.GetOrdinal("FECHA_EMISION");
        //                    int pt5 = dr.GetOrdinal("FECHA_RECEPCION");
        //                    int pt6 = dr.GetOrdinal("PROFESIONAL_CODIGO");
        //                    int pt7 = dr.GetOrdinal("PROFESIONAL_NUM_REGISTRO_FFS");
        //                    int pt8 = dr.GetOrdinal("PROFESIONAL_NOMBRE");
        //                    int pt9 = dr.GetOrdinal("PROFESIONAL_DNI");
        //                    int pt10 = dr.GetOrdinal("PROFESIONAL_NUM_REGISTRO_PROFESIONAL");
        //                    int pt11 = dr.GetOrdinal("ACORDE_TDR_VIGENTE");
        //                    int pt12 = dr.GetOrdinal("OBSERVACION");
        //                    while (dr.Read())
        //                    {
        //                        oCamposDet = new CEntidad();
        //                        oCamposDet.COD_SECUENCIAL = dr.GetInt32(pt1);
        //                        oCamposDet.COD_UCUENTA = dr.GetString(pt2);
        //                        oCamposDet.ANO_EJECUTADO = dr.GetInt32(pt3);
        //                        oCamposDet.FECHA_EMISION = dr.GetString(pt4);
        //                        oCamposDet.FECHA_RECEPCION = dr.GetString(pt5);
        //                        oCamposDet.PROFESIONAL_CODIGO = dr.GetString(pt6);
        //                        oCamposDet.PROFESIONAL_NUM_REGISTRO_FFS = dr.GetString(pt7);
        //                        oCamposDet.PROFESIONAL_NOMBRE = dr.GetString(pt8);
        //                        oCamposDet.PROFESIONAL_DNI = dr.GetString(pt9);
        //                        oCamposDet.PROFESIONAL_NUM_REGISTRO_PROFESIONAL = dr.GetString(pt10);
        //                        oCamposDet.ACORDE_TDR_VIGENTE = dr.GetBoolean(pt11);
        //                        oCamposDet.OBSERVACION = dr.GetString(pt12);
        //                        oCamposDet.RegEstado = 0;
        //                        oCampos.ListPMESITUIANUAL.Add(oCamposDet);
        //                    }
        //                }
        //                // EXSITU PLAN GENETICO
        //                dr.NextResult();
        //                if (dr.HasRows)
        //                {
        //                    int pt1 = dr.GetOrdinal("COD_PGSECUENCIAL");
        //                    int pt2 = dr.GetOrdinal("ARESOLUCION_NUM");
        //                    int pt3 = dr.GetOrdinal("ARESOLUCION_FECHA");
        //                    int pt4 = dr.GetOrdinal("ARESOLUCION_COD_FUNCIONARIO");
        //                    int pt5 = dr.GetOrdinal("ARESOLUCION_FUNCIONARIO_NOMBRE");
        //                    int pt6 = dr.GetOrdinal("CARGO");
        //                    int pt7 = dr.GetOrdinal("FUNCIONARIO_DNI");
        //                    int pt8 = dr.GetOrdinal("OBSERVACION");
        //                    while (dr.Read())
        //                    {
        //                        oCamposDet = new CEntidad();
        //                        oCamposDet.COD_PGSECUENCIAL = dr.GetInt32(pt1);
        //                        oCamposDet.ARESOLUCION_NUM = dr.GetString(pt2);
        //                        oCamposDet.ARESOLUCION_FECHA = dr.GetString(pt3);
        //                        oCamposDet.ARESOLUCION_COD_FUNCIONARIO = dr.GetString(pt4);
        //                        oCamposDet.ARESOLUCION_FUNCIONARIO_NOMBRE = dr.GetString(pt5);
        //                        oCamposDet.CARGO = dr.GetString(pt6);
        //                        oCamposDet.FUNCIONARIO_DNI = dr.GetString(pt7);
        //                        oCamposDet.OBSERVACION = dr.GetString(pt8);
        //                        oCamposDet.RegEstado = 0;
        //                        oCampos.ListPGENETICO_FEXSITU_DET_ESPECIE.Add(oCamposDet);
        //                    }
        //                }
        //                // BALANCE INDIVIDUOS
        //                dr.NextResult();
        //                if (dr.HasRows)
        //                {
        //                    int pt1 = dr.GetOrdinal("COD_ESPECIES");
        //                    int pt2 = dr.GetOrdinal("COD_SECUENCIAL");
        //                    int pt3 = dr.GetOrdinal("COD_MOTIVO");
        //                    int pt4 = dr.GetOrdinal("COD_SDOCUMENTO");
        //                    int pt5 = dr.GetOrdinal("NUM_SDOCUMENTO");
        //                    int pt6 = dr.GetOrdinal("NUM_DOCUMENTO");
        //                    int pt7 = dr.GetOrdinal("FECHA_EMISION");
        //                    int pt8 = dr.GetOrdinal("FECHA_RECEPCION");
        //                    int pt9 = dr.GetOrdinal("TIPO");
        //                    int pt10 = dr.GetOrdinal("OBSERVACION");
        //                    int pt11 = dr.GetOrdinal("ESPECIES");
        //                    int pt12 = dr.GetOrdinal("DOCUMENTO");
        //                    int pt13 = dr.GetOrdinal("MOTIVO");
        //                    while (dr.Read())
        //                    {
        //                        oCamposDet = new CEntidad();
        //                        oCamposDet.COD_ESPECIES = dr.GetString(pt1);
        //                        oCamposDet.COD_SECUENCIAL = dr.GetInt32(pt2);
        //                        oCamposDet.COD_MOTIVO = dr.GetString(pt3);
        //                        oCamposDet.COD_SDOCUMENTO = dr.GetString(pt4);
        //                        oCamposDet.NUM_SDOCUMENTO = dr.GetString(pt5);
        //                        oCamposDet.NUM_DOCUMENTO = dr.GetString(pt6);
        //                        oCamposDet.FECHA_EMISION = dr.GetString(pt7);
        //                        oCamposDet.FECHA_RECEPCION = dr.GetString(pt8);
        //                        oCamposDet.TIPO = dr.GetString(pt9);
        //                        oCamposDet.OBSERVACION = dr.GetString(pt10);
        //                        oCamposDet.ESPECIES = dr.GetString(pt11);
        //                        oCamposDet.DOCUMENTO = dr.GetString(pt12);
        //                        oCamposDet.MOTIVO = dr.GetString(pt13);
        //                        oCamposDet.RegEstado = 0;
        //                        oCampos.ListPMESITUBINDIVIDUAL_I.Add(oCamposDet);
        //                    }
        //                }
        //                dr.NextResult();
        //                if (dr.HasRows)
        //                {
        //                    int pt1 = dr.GetOrdinal("COD_ESPECIES");
        //                    int pt2 = dr.GetOrdinal("COD_SECUENCIAL");
        //                    int pt3 = dr.GetOrdinal("COD_MOTIVO");
        //                    int pt4 = dr.GetOrdinal("COD_SDOCUMENTO");
        //                    int pt5 = dr.GetOrdinal("NUM_SDOCUMENTO");
        //                    int pt6 = dr.GetOrdinal("NUM_DOCUMENTO");
        //                    int pt7 = dr.GetOrdinal("FECHA_EMISION");
        //                    int pt8 = dr.GetOrdinal("FECHA_RECEPCION");
        //                    int pt9 = dr.GetOrdinal("TIPO");
        //                    int pt10 = dr.GetOrdinal("OBSERVACION");
        //                    int pt11 = dr.GetOrdinal("ESPECIES");
        //                    int pt12 = dr.GetOrdinal("DOCUMENTO");
        //                    int pt13 = dr.GetOrdinal("MOTIVO");
        //                    while (dr.Read())
        //                    {
        //                        oCamposDet = new CEntidad();
        //                        oCamposDet.COD_ESPECIES = dr.GetString(pt1);
        //                        oCamposDet.COD_SECUENCIAL = dr.GetInt32(pt2);
        //                        oCamposDet.COD_MOTIVO = dr.GetString(pt3);
        //                        oCamposDet.COD_SDOCUMENTO = dr.GetString(pt4);
        //                        oCamposDet.NUM_SDOCUMENTO = dr.GetString(pt5);
        //                        oCamposDet.NUM_DOCUMENTO = dr.GetString(pt6);
        //                        oCamposDet.FECHA_EMISION = dr.GetString(pt7);
        //                        oCamposDet.FECHA_RECEPCION = dr.GetString(pt8);
        //                        oCamposDet.TIPO = dr.GetString(pt9);
        //                        oCamposDet.OBSERVACION = dr.GetString(pt10);
        //                        oCamposDet.ESPECIES = dr.GetString(pt11);
        //                        oCamposDet.DOCUMENTO = dr.GetString(pt12);
        //                        oCamposDet.MOTIVO = dr.GetString(pt13);
        //                        oCamposDet.RegEstado = 0;
        //                        oCampos.ListPMESITUBINDIVIDUAL_E.Add(oCamposDet);
        //                    }
        //                }
        //            }
        //        }
        //        return oCampos;
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
        public CEntidad PLAN_MANEJO_EXSITU_PGENETICO_MostItem(OracleConnection cn, CEntidad oCEntidad)
        {
            CEntidad oCampos = new CEntidad();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.PLAN_MANEJO_EXSITU_PGENETICO_MostItem", oCEntidad))
                {
                    if (dr != null)
                    {
                        oCampos.ListPGENETICO_FEXSITU_DET_ESPECIE = new List<CEntidad>();
                        oCampos.ListPGENETICO_FEXSITU_PGENTICO_INFORME = new List<CEntidad>();
                        CEntidad oCamposDet;
                        //
                        //PLAN_MANEJO_EXSITU_DET_IANUAL
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("COD_SECUENCIAL");
                            int pt2 = dr.GetOrdinal("COD_ESPECIES");
                            int pt3 = dr.GetOrdinal("ESPECIES");
                            int pt4 = dr.GetOrdinal("COD_GACATEGORIA");
                            int pt5 = dr.GetOrdinal("DESC_GACATEGORIA");
                            int pt6 = dr.GetOrdinal("CANTIDAD_OTORGADA");
                            int pt7 = dr.GetOrdinal("CANTIDAD_AUTORIZADA_CAPTURA");
                            int pt8 = dr.GetOrdinal("NUM_MACHO");
                            int pt9 = dr.GetOrdinal("NUM_HEMBRAS");
                            int pt10 = dr.GetOrdinal("OBSERVACION");
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.COD_SECUENCIAL = dr.GetInt32(pt1);
                                oCamposDet.COD_ESPECIES = dr.GetString(pt2);
                                oCamposDet.ESPECIES = dr.GetString(pt3);
                                oCamposDet.COD_GACATEGORIA = dr.GetString(pt4);
                                oCamposDet.DESC_GACATEGORIA = dr.GetString(pt5);
                                oCamposDet.CANTIDAD_OTORGADA = dr.GetInt32(pt6);
                                oCamposDet.CANTIDAD_AUTORIZADA_CAPTURA = dr.GetInt32(pt7);
                                oCamposDet.NUM_MACHO = dr.GetInt32(pt8);
                                oCamposDet.NUM_HEMBRAS = dr.GetInt32(pt9);
                                oCamposDet.OBSERVACION = dr.GetString(pt10);
                                oCamposDet.RegEstado = 0;
                                oCampos.ListPGENETICO_FEXSITU_DET_ESPECIE.Add(oCamposDet);
                            }
                        }
                        // EXSITU PLAN GENETICO
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("COD_SECUENCIAL");
                            int pt2 = dr.GetOrdinal("COD_ESPECIES");
                            int pt3 = dr.GetOrdinal("ESPECIES");
                            int pt4 = dr.GetOrdinal("NUM_INFORME");
                            int pt5 = dr.GetOrdinal("FECHA_EMISION");
                            int pt6 = dr.GetOrdinal("ZONA_CAPTURA");
                            int pt7 = dr.GetOrdinal("NUM_MACHO");
                            int pt8 = dr.GetOrdinal("NUM_HEMBRAS");
                            int pt9 = dr.GetOrdinal("OBSERVACION");
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.COD_SECUENCIAL = dr.GetInt32(pt1);
                                oCamposDet.COD_ESPECIES = dr.GetString(pt2);
                                oCamposDet.ESPECIES = dr.GetString(pt3);
                                oCamposDet.NUM_INFORME = dr.GetString(pt4);
                                oCamposDet.FECHA_EMISION = dr.GetString(pt5);
                                oCamposDet.ZONA_CAPTURA = dr.GetString(pt6);
                                oCamposDet.NUM_MACHO = dr.GetInt32(pt7);
                                oCamposDet.NUM_HEMBRAS = dr.GetInt32(pt8);
                                oCamposDet.OBSERVACION = dr.GetString(pt9);
                                oCamposDet.RegEstado = 0;
                                oCampos.ListPGENETICO_FEXSITU_PGENTICO_INFORME.Add(oCamposDet);
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
        //public String RegGrabar(OracleConnection cn, CEntidad oCEntidad)
        //{
        //    OracleTransaction tr = null;
        //    String OUTPUTPARAM01 = "";
        //    CEntidad oCamposDet;
        //    try
        //    {
        //        tr = cn.BeginTransaction();
        //        //Grabando Cabecera
        //        using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spPLAN_MANEJOGrabar", oCEntidad))
        //        {
        //            cmd.ExecuteNonQuery();
        //            OUTPUTPARAM01 = (String)cmd.Parameters["@OUTPUTPARAM01"].Value;
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
        //                throw new Exception("El Número de Resolución para este Plan de Manejo ya Existe");
        //            }
        //            else if (OUTPUTPARAM01 == "1")
        //            {
        //                tr.Rollback();
        //                tr = null;
        //                throw new Exception("El Número de Resolución ya Existe en Otro Plan de Manejo");
        //            }
        //            else if (OUTPUTPARAM01 == "2")
        //            {
        //                tr.Rollback();
        //                tr = null;
        //                throw new Exception("No Tiene Permisos para Modificar este Plan de Manejo");
        //            }
        //            else if (OUTPUTPARAM01 == "3")
        //            {
        //                tr.Rollback();
        //                tr = null;
        //                throw new Exception("Está con Control de Calidad, no puede modificar");
        //            }
        //            oCEntidad.COD_PMANEJO = OUTPUTPARAM01;
        //        }
        //        //
        //        //Eliminando Detalle
        //        if (oCEntidad.ListEliTABLA != null)
        //        {
        //            foreach (var loDatos in oCEntidad.ListEliTABLA)
        //            {
        //                oCamposDet = new CEntidad();
        //                oCamposDet.COD_PMANEJO = oCEntidad.COD_PMANEJO;
        //                oCamposDet.EliTABLA = loDatos.EliTABLA;
        //                oCamposDet.EliVALOR01 = loDatos.EliVALOR01;
        //                oCamposDet.EliVALOR02 = loDatos.EliVALOR02;
        //                dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spPLAN_MANEJOEliminarDetalle", oCamposDet);
        //            }
        //        }
        //        //
        //        //Grabando Detalle PLAN_MANEJO_DET_TIOCULAR
        //        if (oCEntidad.ListPMDTTIOCULAR != null)
        //        {
        //            foreach (var loDatos in oCEntidad.ListPMDTTIOCULAR)
        //            {
        //                if (loDatos.RegEstado == 1) //Nuevo o Modificado
        //                {
        //                    oCamposDet = new CEntidad();
        //                    oCamposDet.COD_PMANEJO = oCEntidad.COD_PMANEJO;
        //                    oCamposDet.COD_TIOCULAR = loDatos.COD_PERSONA;
        //                    dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spPLAN_MANEJO_DET_TIOCULARGrabar", oCamposDet);
        //                }
        //            }
        //        }
        //        //Grabando Detalle PLAN_MANEJO_DET_TRAPROBACION
        //        if (oCEntidad.ListPMDTTRAPROBACION != null)
        //        {
        //            foreach (var loDatos in oCEntidad.ListPMDTTRAPROBACION)
        //            {
        //                if (loDatos.RegEstado == 1) //Nuevo o Modificado
        //                {
        //                    oCamposDet = new CEntidad();
        //                    oCamposDet.COD_PMANEJO = oCEntidad.COD_PMANEJO;
        //                    oCamposDet.COD_TRAPROBACION = loDatos.COD_PERSONA;
        //                    dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spPLAN_MANEJO_DET_TRAPROBACIONGrabar", oCamposDet);
        //                }
        //            }
        //        }
        //        //Grabando Detalle PLAN_MANEJO_INSITU_DET_CAREA
        //        if (oCEntidad.ListPMDISITUCAREA != null)
        //        {
        //            foreach (var loDatos in oCEntidad.ListPMDISITUCAREA)
        //            {
        //                if (loDatos.RegEstado == 1) //Nuevo o Modificado
        //                {
        //                    oCamposDet = new CEntidad();
        //                    oCamposDet.COD_PMANEJO = oCEntidad.COD_PMANEJO;
        //                    oCamposDet.COD_CAREA = loDatos.COD_CAREA;
        //                    dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spPLAN_MANEJO_INSITU_DET_CAREAGrabar", oCamposDet);
        //                }
        //            }
        //        }
        //        //Grabando Detalle PLAN_MANEJO_INSITU_DET_INV_FAUNA
        //        if (oCEntidad.ListPMDISITUFAUNA != null)
        //        {
        //            foreach (var loDatos in oCEntidad.ListPMDISITUFAUNA)
        //            {
        //                if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
        //                {
        //                    oCamposDet = new CEntidad();
        //                    oCamposDet.COD_PMANEJO = oCEntidad.COD_PMANEJO;
        //                    oCamposDet.COD_ESPECIES = loDatos.COD_ESPECIES;
        //                    oCamposDet.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
        //                    oCamposDet.OBSERVACION = loDatos.OBSERVACION;
        //                    oCamposDet.RegEstado = loDatos.RegEstado;
        //                    dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spPLAN_MANEJO_INSITU_DET_INV_FAUNAGrabar", oCamposDet);
        //                }
        //            }
        //        }
        //        //Grabando Detalle PLAN_MANEJO_INSITU_DET_INV_FLORA
        //        if (oCEntidad.ListPMDISITUFLORA != null)
        //        {
        //            foreach (var loDatos in oCEntidad.ListPMDISITUFLORA)
        //            {
        //                if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
        //                {
        //                    oCamposDet = new CEntidad();
        //                    oCamposDet.COD_PMANEJO = oCEntidad.COD_PMANEJO;
        //                    oCamposDet.COD_ESPECIES = loDatos.COD_ESPECIES;
        //                    oCamposDet.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
        //                    oCamposDet.CARACTERISTICAS = loDatos.CARACTERISTICAS;
        //                    oCamposDet.RASOCIACIONES_FAUNA = loDatos.RASOCIACIONES_FAUNA;
        //                    oCamposDet.OBSERVACION = loDatos.OBSERVACION;
        //                    oCamposDet.RegEstado = loDatos.RegEstado;
        //                    dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spPLAN_MANEJO_INSITU_DET_INV_FLORAGrabar", oCamposDet);
        //                }
        //            }
        //        }
        //        //PLAN_MANEJO_TARA_DET_PAPROVECHAMIENTO
        //        if (oCEntidad.ListPMTDPPAPROVECHAMIENTO != null)
        //        {
        //            foreach (var loDatos in oCEntidad.ListPMTDPPAPROVECHAMIENTO)
        //            {
        //                if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
        //                {
        //                    oCamposDet = new CEntidad();
        //                    oCamposDet.COD_PMANEJO = oCEntidad.COD_PMANEJO;
        //                    oCamposDet.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
        //                    oCamposDet.ANO = loDatos.ANO;
        //                    oCamposDet.NUM_ARBOLES = loDatos.NUM_ARBOLES;
        //                    oCamposDet.PESO_VAINAS = loDatos.PESO_VAINAS;
        //                    oCamposDet.NUM_COSECHA = loDatos.NUM_COSECHA;
        //                    oCamposDet.NUM_QUINTALES = loDatos.NUM_QUINTALES;
        //                    oCamposDet.OBSERVACION = loDatos.OBSERVACION;
        //                    oCamposDet.RegEstado = loDatos.RegEstado;
        //                    dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spPLAN_MANEJO_TARA_DET_PAPROVECHAMIENTOGrabar", oCamposDet);
        //                }
        //            }
        //        }
        //        //PLAN_MANEJO_TARA_DET_OPCIONES Aprovechamiento
        //        if (oCEntidad.ListPMTDOOPCIONESEAPROVE != null)
        //        {
        //            foreach (var loDatos in oCEntidad.ListPMTDOOPCIONESEAPROVE)
        //            {
        //                if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
        //                {
        //                    oCamposDet = new CEntidad();
        //                    oCamposDet.COD_PMANEJO = oCEntidad.COD_PMANEJO;
        //                    oCamposDet.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
        //                    oCamposDet.COD_PMTOPCIONES = loDatos.COD_PMTOPCIONES;
        //                    oCamposDet.OBSERVACION = loDatos.OBSERVACION;
        //                    oCamposDet.RegEstado = loDatos.RegEstado;
        //                    dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spPLAN_MANEJO_TARA_DET_OPCIONESGrabar", oCamposDet);
        //                }
        //            }
        //        }
        //        //PLAN_MANEJO_TARA_DET_OPCIONES Silviculturales
        //        if (oCEntidad.ListPMTDOOPCIONESPSILVI != null)
        //        {
        //            foreach (var loDatos in oCEntidad.ListPMTDOOPCIONESPSILVI)
        //            {
        //                if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
        //                {
        //                    oCamposDet = new CEntidad();
        //                    oCamposDet.COD_PMANEJO = oCEntidad.COD_PMANEJO;
        //                    oCamposDet.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
        //                    oCamposDet.COD_PMTOPCIONES = loDatos.COD_PMTOPCIONES;
        //                    oCamposDet.OBSERVACION = loDatos.OBSERVACION;
        //                    oCamposDet.RegEstado = loDatos.RegEstado;
        //                    dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spPLAN_MANEJO_TARA_DET_OPCIONESGrabar", oCamposDet);
        //                }
        //            }
        //        }
        //        // PLAN_MANEJO_TARA_DET_COORDENADAUTM
        //        if (oCEntidad.ListPMTCOORDENADAUTM != null)
        //        {
        //            foreach (var loDatos in oCEntidad.ListPMTCOORDENADAUTM)
        //            {
        //                if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
        //                {
        //                    oCamposDet = new CEntidad();
        //                    oCamposDet.COD_PMANEJO = oCEntidad.COD_PMANEJO;
        //                    oCamposDet.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
        //                    oCamposDet.NUM_PARCELA = loDatos.NUM_PARCELA;
        //                    oCamposDet.NUM_PUNTOS = loDatos.NUM_PUNTOS;
        //                    oCamposDet.COORDENADA_ESTE = loDatos.COORDENADA_ESTE;
        //                    oCamposDet.COORDENADA_NORTE = loDatos.COORDENADA_NORTE;
        //                    oCamposDet.OBSERVACION = loDatos.OBSERVACION;
        //                    oCamposDet.RegEstado = loDatos.RegEstado;
        //                    dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spPLAN_MANEJO_TARA_DET_COORDENADAUTMGrabar", oCamposDet);
        //                }
        //            }
        //        }
        //        // PLAN_MANEJO_TARA_DET_AAPROVECHAMIENTO
        //        if (oCEntidad.ListPMTAAPROVECHAMIENTO != null)
        //        {
        //            foreach (var loDatos in oCEntidad.ListPMTAAPROVECHAMIENTO)
        //            {
        //                if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
        //                {
        //                    oCamposDet = new CEntidad();
        //                    oCamposDet.COD_PMANEJO = oCEntidad.COD_PMANEJO;
        //                    oCamposDet.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
        //                    oCamposDet.NUM_PARCELA = loDatos.NUM_PARCELA;
        //                    oCamposDet.NUM_ARBOLES_APROVE = loDatos.NUM_ARBOLES_APROVE;
        //                    oCamposDet.NUM_ARBOLES_NO_APROVE = loDatos.NUM_ARBOLES_NO_APROVE;
        //                    oCamposDet.PRODUCCION_ANUAL_PROMEDIO = loDatos.PRODUCCION_ANUAL_PROMEDIO;
        //                    oCamposDet.PESO_ESTIMADO_VAINAS = loDatos.PESO_ESTIMADO_VAINAS;
        //                    oCamposDet.OBSERVACION = loDatos.OBSERVACION;
        //                    oCamposDet.RegEstado = loDatos.RegEstado;
        //                    dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spPLAN_MANEJO_TARA_DET_AAPROVECHAMIENTOGrabar", oCamposDet);
        //                }
        //            }
        //        }
        //        // PLAN_MANEJO_TARA_DET_AAPROVECHAMIENTO
        //        if (oCEntidad.ListPMTAUTORIZADAEXTRA != null)
        //        {
        //            foreach (var loDatos in oCEntidad.ListPMTAUTORIZADAEXTRA)
        //            {
        //                if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
        //                {
        //                    oCamposDet = new CEntidad();
        //                    oCamposDet.COD_PMANEJO = oCEntidad.COD_PMANEJO;
        //                    oCamposDet.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
        //                    oCamposDet.COD_ESPECIES = loDatos.COD_ESPECIES;
        //                    oCamposDet.SUPERFICIE_HA = loDatos.SUPERFICIE_HA;
        //                    oCamposDet.TOTAL_PGMF = loDatos.TOTAL_PGMF;
        //                    oCamposDet.ANO_1 = loDatos.ANO_1;
        //                    oCamposDet.ANO_2 = loDatos.ANO_2;
        //                    oCamposDet.ANO_3 = loDatos.ANO_3;
        //                    oCamposDet.ANO_4 = loDatos.ANO_4;
        //                    oCamposDet.ANO_5 = loDatos.ANO_5;
        //                    oCamposDet.DERECHO_APROVE_QUINTAL = loDatos.DERECHO_APROVE_QUINTAL;
        //                    oCamposDet.DERECHO_APROVE_QTOTAL = loDatos.DERECHO_APROVE_QTOTAL;
        //                    oCamposDet.OBSERVACION = loDatos.OBSERVACION;
        //                    oCamposDet.RegEstado = loDatos.RegEstado;
        //                    dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spPLAN_MANEJO_TARA_DET_CAUTO_EXTRAERGrabar", oCamposDet);
        //                }
        //            }
        //        }
        //        //PLAN_MANEJO_TARA_DET_BEXTRACCION
        //        //if (oCEntidad.ListPMTBEXTRACCION != null)
        //        //{
        //        //    foreach (var loDatos in oCEntidad.ListPMTBEXTRACCION)
        //        //    {
        //        //        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
        //        //        {
        //        //            oCamposDet = new CEntidad();
        //        //            oCamposDet.COD_PMANEJO = oCEntidad.COD_PMANEJO;
        //        //            oCamposDet.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
        //        //            oCamposDet.NUM_GTRANSPORTE = loDatos.NUM_GTRANSPORTE;
        //        //            oCamposDet.AUTORIZADO_CANTIDAD = loDatos.AUTORIZADO_CANTIDAD;
        //        //            oCamposDet.APROVECHADO_KILOGRAMOS = loDatos.APROVECHADO_KILOGRAMOS;
        //        //            oCamposDet.APROVECHADO_CANTIDAD = loDatos.APROVECHADO_CANTIDAD;
        //        //            oCamposDet.SALDO = loDatos.SALDO;
        //        //            oCamposDet.OBSERVACION = loDatos.OBSERVACION;
        //        //            oCamposDet.RegEstado = loDatos.RegEstado;
        //        //            oGDataSQL.ManExecute(cn, tr, "DOC.spPLAN_MANEJO_TARA_DET_BEXTRACCIONGrabar", oCamposDet);
        //        //        }
        //        //    }
        //        //}
        //        //PLAN_MANEJO_TARA_DET_INVENTARIO
        //        if (oCEntidad.ListPMTINVENTARIO != null)
        //        {
        //            foreach (var loDatos in oCEntidad.ListPMTINVENTARIO)
        //            {
        //                if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
        //                {
        //                    oCamposDet = new CEntidad();
        //                    oCamposDet.COD_PMANEJO = oCEntidad.COD_PMANEJO;
        //                    oCamposDet.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
        //                    oCamposDet.N_ARBOL = loDatos.N_ARBOL;
        //                    oCamposDet.CONDICION = loDatos.CONDICION;
        //                    oCamposDet.ESTADO_FITOSAN = loDatos.ESTADO_FITOSAN;
        //                    oCamposDet.ALTURA_ESTIMADO = loDatos.ALTURA_ESTIMADO;
        //                    oCamposDet.PESO_VAINAS_KILOGRAMOS = loDatos.PESO_VAINAS_KILOGRAMOS;
        //                    oCamposDet.COORDENADA_ESTE = loDatos.COORDENADA_ESTE;
        //                    oCamposDet.COORDENADA_NORTE = loDatos.COORDENADA_NORTE;
        //                    oCamposDet.OBSERVACION = loDatos.OBSERVACION;
        //                    oCamposDet.RegEstado = loDatos.RegEstado;
        //                    dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spPLAN_MANEJO_TARA_DET_INVENTARIOGrabar", oCamposDet);
        //                }
        //            }
        //        }
        //        //PLAN_MANEJO_EXSITU_DET_IANUAL
        //        if (oCEntidad.ListPMINFORME_ANUAL != null)
        //        {
        //            foreach (var loDatos in oCEntidad.ListPMINFORME_ANUAL)
        //            {
        //                if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
        //                {
        //                    oCamposDet = new CEntidad();
        //                    oCamposDet.COD_PMANEJO = oCEntidad.COD_PMANEJO;
        //                    oCamposDet.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
        //                    oCamposDet.COD_UCUENTA = loDatos.COD_UCUENTA;
        //                    oCamposDet.ANO_EJECUTADO = loDatos.ANO_EJECUTADO;
        //                    oCamposDet.FECHA_EMISION = loDatos.FECHA_EMISION;
        //                    oCamposDet.PROFESIONAL_CODIGO = loDatos.PROFESIONAL_CODIGO;
        //                    oCamposDet.PROFESIONAL_NUM_REGISTRO_FFS = loDatos.PROFESIONAL_NUM_REGISTRO_FFS;
        //                    oCamposDet.ACORDE_TDR_VIGENTE = loDatos.ACORDE_TDR_VIGENTE;
        //                    oCamposDet.OBSERVACION = loDatos.OBSERVACION;
        //                    oCamposDet.PRINCIPAL_ACCION_DESARROLLA = loDatos.PRINCIPAL_ACCION_DESARROLLA;
        //                    oCamposDet.RegEstado = loDatos.RegEstado;
        //                    dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spPLAN_MANEJO_EXSITU_DET_IANUALGrabar", oCamposDet);
        //                }
        //            }
        //        }
        //        //PLAN_MANEJO_TARA_DET_OPCIONES Aprovechamiento
        //        if (oCEntidad.ListPMECOTPROGIMPLEMENTAR != null)
        //        {
        //            foreach (var loDatos in oCEntidad.ListPMECOTPROGIMPLEMENTAR)
        //            {
        //                if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
        //                {
        //                    oCamposDet = new CEntidad();
        //                    oCamposDet.COD_PMANEJO = oCEntidad.COD_PMANEJO;
        //                    oCamposDet.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
        //                    oCamposDet.COD_PMTOPCIONES = loDatos.COD_PMTOPCIONES;
        //                    oCamposDet.OBSERVACION = loDatos.OBSERVACION;
        //                    oCamposDet.RegEstado = loDatos.RegEstado;
        //                    dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spPLAN_MANEJO_TARA_DET_OPCIONESGrabar", oCamposDet);
        //                }
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public Int32 RegGrabarESituIAnual(OracleConnection cn, OracleTransaction tr, CEntidad oCEntidad)
        {
            try
            {
                Int32 OUTPUTPARAM01 = 0;
                oCEntidad.OUTPUTPARAM01 = "";

                using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spPLAN_MANEJO_EXSITU_DET_IANUALGrabar", oCEntidad))
                {
                    cmd.ExecuteNonQuery();
                    OUTPUTPARAM01 = Int32.Parse((String)cmd.Parameters["OUTPUTPARAM01"].Value);

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
        public void RegEliminar(OracleConnection cn, CEntidad oCEntidad)
        {
            try
            {
                dBOracle.ManExecute(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spPLAN_MANEJOEliminar", oCEntidad);
                /*
                Int32 RegNum = dBOracle.ManExecute(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spPLAN_MANEJOEliminar", oCEntidad);
                if (RegNum == -1)
                {
                    throw new Exception("No se logró realizar la operación");
                }*/
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
        public void RegEliminarESituIAnual(OracleConnection cn, OracleTransaction tr, CEntidad oCEntidad)
        {
            try
            {
                dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spPLAN_MANEJO_EXSITU_DET_IANUALEliminar", oCEntidad);
                tr.Commit();
            }
            catch (Exception ex)
            {
                if (tr != null)
                {
                    tr.Rollback();
                    tr.Dispose();
                }
                throw ex;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        public void RegEliminarESituPGenetico(OracleConnection cn, OracleTransaction tr, CEntidad oCEntidad)
        {
            try
            {
                dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spPLAN_MANEJO_EXSITU_PGENETICOEliminar", oCEntidad);
                tr.Commit();
            }
            catch (Exception ex)
            {
                if (tr != null)
                {
                    tr.Rollback();
                    tr.Dispose();
                }
                throw ex;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        public void RegEliminarESituBIndividuos(OracleConnection cn, OracleTransaction tr, CEntidad oCEntidad)
        {
            try
            {
                dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spPLAN_MANEJO_EXSITU_BINDIVIDUOSEliminar", oCEntidad);
                tr.Commit();
            }
            catch (Exception ex)
            {
                if (tr != null)
                {
                    tr.Rollback();
                    tr.Dispose();
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
        public List<CEntidad> RegNuevoBuscar(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spGeneral_Listar", oCEntidad))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            int p1 = dr.GetOrdinal("COD_THABILITANTE");
                            int p2 = dr.GetOrdinal("MODALIDAD");
                            int p3 = dr.GetOrdinal("NUM_THABILITANTE");
                            int p4 = dr.GetOrdinal("PERSONA");
                            int p5 = dr.GetOrdinal("INDICADOR");
                            int p6 = dr.GetOrdinal("COD_MTIPO");
                            CEntidad oCampos;
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                oCampos.COD_THABILITANTE = dr.GetString(p1);
                                oCampos.MODALIDAD = dr.GetString(p2);
                                oCampos.NUM_THABILITANTE = dr.GetString(p3);
                                oCampos.PERSONA = dr.GetString(p4);
                                oCampos.INDICADOR = dr.GetString(p5);
                                oCampos.COD_MTIPO = dr.GetString(p6);
                                lsCEntidad.Add(oCampos);
                            }
                        }
                    }
                }
                return lsCEntidad;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //Combo
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
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
                        //
                        oCampos.ListMComboModalidad = new List<CEntidad>();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                //PARTE_DIARIO_DETALLE
                                oCamposDet = new CEntidad();
                                oCamposDet.CODIGO = dr["CODIGO"].ToString();
                                oCamposDet.DESCRIPCION = dr["DESCRIPCION"].ToString();
                                oCampos.ListMComboModalidad.Add(oCamposDet);
                            }
                        }
                        //Documento de Identidad
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
                        oCampos.ListMComboDIdentidad = lsDetDetalle;
                        //
                        //Insitu Condicion Area
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
                        oCampos.ListMComboCArea = lsDetDetalle;

                        // grado de amenaza
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
                        oCampos.ListMComboGAmenaza = lsDetDetalle;

                        // ESPECIE DE AFAUNA EX SITU
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
                        oCampos.ListMComboEspecieFauna = lsDetDetalle;
                        //MANEJO MOTIVO EXSITU
                        dr.NextResult();
                        lsDetDetalle = new List<CEntidad>();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.CODIGO = dr["CODIGO"].ToString();
                                oCamposDet.DESCRIPCION = dr["DESCRIPCION"].ToString();
                                oCamposDet.TIPO = dr["TIPO"].ToString();
                                lsDetDetalle.Add(oCamposDet);
                            }
                        }
                        oCampos.ListMComboMotivo = lsDetDetalle;
                        //EXSITU DOCUMENTO
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
                        oCampos.ListMComboDocumento = lsDetDetalle;
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
                        //Especies Fauna
                        dr.NextResult();
                        lsDetDetalle = new List<CEntidad>();
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("CODIGO");
                            int pt2 = dr.GetOrdinal("DESCRIPCION");
                            int pt3 = dr.GetOrdinal("COD_ENCIENTIFICO");
                            int pt4 = dr.GetOrdinal("NOMBRE_CIENTIFICO");
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.CODIGO = dr.GetString(pt1);
                                oCamposDet.DESCRIPCION = dr.GetString(pt2);
                                oCamposDet.COD_ENCIENTIFICO = dr.GetString(pt3);
                                oCamposDet.NOMBRE_CIENTIFICO = dr.GetString(pt4);
                                lsDetDetalle.Add(oCamposDet);
                            }
                        }
                        oCampos.ListMComboEspecieFauna = lsDetDetalle;
                        //Especies Flora
                        dr.NextResult();
                        lsDetDetalle = new List<CEntidad>();
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("CODIGO");
                            int pt2 = dr.GetOrdinal("DESCRIPCION");
                            int pt3 = dr.GetOrdinal("COD_ENCIENTIFICO");
                            int pt4 = dr.GetOrdinal("NOMBRE_CIENTIFICO");
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.CODIGO = dr.GetString(pt1);
                                oCamposDet.DESCRIPCION = dr.GetString(pt2);
                                oCamposDet.COD_ENCIENTIFICO = dr.GetString(pt3);
                                oCamposDet.NOMBRE_CIENTIFICO = dr.GetString(pt4);
                                lsDetDetalle.Add(oCamposDet);
                            }
                        }
                        oCampos.ListMComboEspecieFlora = lsDetDetalle;
                        //
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
                        oCampos.ListMComboAutoextraer = lsDetDetalle;
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
        /// <returns></returns>
        public List<CEntidad> RegMostComboTOpciones(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spGeneral_Combo_Listar", oCEntidad))
                {
                    if (dr != null)
                    {
                        CEntidad oCampos;
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("CODIGO");
                            int pt2 = dr.GetOrdinal("DESCRIPCION");
                            int pt3 = dr.GetOrdinal("TIPO");
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                oCampos.CODIGO = dr.GetString(pt1);
                                oCampos.DESCRIPCION = dr.GetString(pt2);
                                oCampos.TIPO = dr.GetString(pt3);
                                lsCEntidad.Add(oCampos);
                            }
                        }
                    }
                }
                return lsCEntidad;
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
        public String RegMostComboEspeciesGrabar(OracleConnection cn, CEntidad oCEntidad)
        {
            String OUTPUTPARAM01 = "";
            try
            {
                //Grabando Cabecera
                using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spESPECIESVerficaCreaNuevo", oCEntidad))
                {
                    cmd.ExecuteNonQuery();
                    OUTPUTPARAM01 = (String)cmd.Parameters["@OUTPUTPARAM01"].Value;
                }
                return OUTPUTPARAM01;
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
        public String PLAN_MANEJO_EXSITU_BINDIVIDUOS_Grabar(OracleConnection cn, OracleTransaction tr, CEntidad oCEntidad)
        {
            String OUTPUTPARAM01 = "";
            CEntidad ocampo = new CEntidad();
            try
            {
                //Grabando Cabecera
                ocampo.COD_PMANEJO = oCEntidad.COD_PMANEJO;
                ocampo.COD_SECUENCIAL = oCEntidad.COD_SECUENCIAL;
                ocampo.COD_ESPECIES = oCEntidad.COD_ESPECIES;
                ocampo.NUM_DOCUMENTO = oCEntidad.NUM_DOCUMENTO;
                ocampo.COD_SDOCUMENTO = oCEntidad.COD_SDOCUMENTO;
                ocampo.NUM_SDOCUMENTO = oCEntidad.NUM_SDOCUMENTO;
                ocampo.COD_MOTIVO = oCEntidad.COD_MOTIVO;
                ocampo.FECHA_EMISION = oCEntidad.FECHA_EMISION;
                ocampo.FECHA_RECEPCION = oCEntidad.FECHA_RECEPCION;
                ocampo.TIPO = oCEntidad.TIPO;
                ocampo.OBSERVACION = oCEntidad.OBSERVACION;
                ocampo.RegEstado = oCEntidad.RegEstado;
                ocampo.OUTPUTPARAM01 = "";
                using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.PLAN_MANEJO_EXSITU_BINDIVIDUOS_Grabar", ocampo))

                {
                    cmd.ExecuteNonQuery();
                    OUTPUTPARAM01 = (String)cmd.Parameters["OUTPUTPARAM01"].Value;
                    if (OUTPUTPARAM01 == "0")
                    {
                        throw new Exception("El Registro ya Existe");
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
                    tr.Dispose();
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
        public String PLAN_MANEJO_EXSITU_PGENETICO_Grabar(OracleConnection cn, CEntidad oCEntidad)
        {
            OracleTransaction tr = null;
            String OUTPUTPARAM01 = "";
            CEntidad oCamposDet;
            try
            {
                tr = cn.BeginTransaction();
                //Grabando Cabecera
                using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.PLAN_MANEJO_EXSITU_PGENETICO_Grabar", oCEntidad))
                {
                    cmd.ExecuteNonQuery();
                    OUTPUTPARAM01 = (String)cmd.Parameters["OUTPUTPARAM01"].Value;
                    if (OUTPUTPARAM01 == "0")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("El Número de Resolución para este Plan de Manejo ya Existe");
                    }
                    oCEntidad.COD_PGSECUENCIAL = Int32.Parse(OUTPUTPARAM01);
                }
                //
                //Eliminando Detalle
                if (oCEntidad.ListEliTABLA != null)
                {
                    foreach (var loDatos in oCEntidad.ListEliTABLA)
                    {
                        oCamposDet = new CEntidad();
                        oCamposDet.COD_PMANEJO = oCEntidad.COD_PMANEJO;
                        oCamposDet.EliTABLA = loDatos.EliTABLA;
                        oCamposDet.EliVALOR01 = loDatos.EliVALOR01;
                        oCamposDet.EliVALOR02 = loDatos.EliVALOR02;
                        oCamposDet.COD_PGSECUENCIAL = oCEntidad.COD_PGSECUENCIAL;
                        dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spPLAN_MANEJOEliminarDetalle", oCamposDet);
                    }
                }
                //
                //Grabando Detalle PLAN_MANEJO_DET_TIOCULAR
                if (oCEntidad.ListPGENETICO_FEXSITU_DET_ESPECIE != null)
                {
                    foreach (var loDatos in oCEntidad.ListPGENETICO_FEXSITU_DET_ESPECIE)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            oCamposDet = new CEntidad();
                            oCamposDet.COD_PMANEJO = oCEntidad.COD_PMANEJO;
                            oCamposDet.COD_PGSECUENCIAL = oCEntidad.COD_PGSECUENCIAL;
                            oCamposDet.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            oCamposDet.COD_ESPECIES = loDatos.COD_ESPECIES;
                            oCamposDet.COD_GACATEGORIA = loDatos.COD_GACATEGORIA;
                            oCamposDet.CANTIDAD_OTORGADA = loDatos.CANTIDAD_OTORGADA;
                            oCamposDet.CANTIDAD_AUTORIZADA_CAPTURA = loDatos.CANTIDAD_AUTORIZADA_CAPTURA;
                            oCamposDet.NUM_MACHO = loDatos.NUM_MACHO;
                            oCamposDet.NUM_HEMBRAS = loDatos.NUM_HEMBRAS;
                            oCamposDet.OBSERVACION = loDatos.OBSERVACION;
                            oCamposDet.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.PLAN_MANEJO_EXSITU_PGENETICO_DET_ESPECIES_Grabar", oCamposDet);
                        }
                    }
                }
                //Grabando Detalle PLAN_MANEJO_DET_TRAPROBACION
                if (oCEntidad.ListPGENETICO_FEXSITU_PGENTICO_INFORME != null)
                {
                    foreach (var loDatos in oCEntidad.ListPGENETICO_FEXSITU_PGENTICO_INFORME)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            oCamposDet = new CEntidad();
                            oCamposDet.COD_PMANEJO = oCEntidad.COD_PMANEJO;
                            oCamposDet.COD_PGSECUENCIAL = oCEntidad.COD_PGSECUENCIAL;
                            oCamposDet.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            oCamposDet.COD_ESPECIES = loDatos.COD_ESPECIES;
                            oCamposDet.NUM_INFORME = loDatos.NUM_INFORME;
                            oCamposDet.FECHA_EMISION = loDatos.FECHA_EMISION;
                            oCamposDet.ZONA_CAPTURA = loDatos.ZONA_CAPTURA;
                            oCamposDet.NUM_MACHO = loDatos.NUM_MACHO;
                            oCamposDet.NUM_HEMBRAS = loDatos.NUM_HEMBRAS;
                            oCamposDet.OBSERVACION = loDatos.OBSERVACION;
                            oCamposDet.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.PLAN_MANEJO_EXSITU_PGENETICO_INFORME_Grabar", oCamposDet);
                        }
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

        public List<CEntidad> RegPersonaList(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "GENE.spBuscaPersonas", oCEntidad))
                {
                    if (dr != null)
                    {
                        CEntidad ocampoEnt;
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidad();
                                ocampoEnt.CODIGO = dr["COD_PERSONA"].ToString();
                                ocampoEnt.DESCRIPCION = dr["APELLIDOS_NOMBRES"].ToString();
                                //ocampoEnt.RegEstado = 1;
                                lsCEntidad.Add(ocampoEnt);
                            }
                        }
                    }
                }
                return lsCEntidad;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // METODOS PARA PLAN GENERAL DE MANEJO FORESTAL
        //public String RegGrabarPGMF(OracleConnection cn, CEntidad oCEntidad)
        //{
        //    OracleTransaction tr = null;
        //    String OUTPUTPARAM01 = "";

        //    try
        //    {
        //        tr = cn.BeginTransaction();
        //        //Grabando Cabecera
        //        using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spPLANGENERALMANEJOFORESTAL_Grabar", oCEntidad))
        //        {
        //            cmd.ExecuteNonQuery();
        //            OUTPUTPARAM01 = (String)cmd.Parameters["@OUTPUTPARAM01"].Value;
        //            if (OUTPUTPARAM01 == "99")
        //            {
        //                tr.Rollback();
        //                tr = null;
        //                throw new Exception("Ud. no tiene permiso para realizar esta acción");
        //            }
        //            if (OUTPUTPARAM01 == "0")
        //            {
        //                tr.Rollback();
        //                tr = null;
        //                throw new Exception("El Número PGMF ya existe");
        //            }
        //            else if (OUTPUTPARAM01 == "1")
        //            {
        //                tr.Rollback();
        //                tr = null;
        //                throw new Exception("El Número PGMF Existe en otro Registro");
        //            }
        //            else if (OUTPUTPARAM01 == "2")
        //            {
        //                tr.Rollback();
        //                tr = null;
        //                throw new Exception("No Tiene Permisos para Modificar");
        //            }
        //            else if (OUTPUTPARAM01 == "3")
        //            {
        //                tr.Rollback();
        //                tr = null;
        //                throw new Exception("Está con Control de Calidad, no puede modificar");
        //            }
        //        }
        //        //Reemplazando El Nuevo Codigo Creado
        //        //String[] cadena = OUTPUTPARAM02.Split('|');
        //        if (oCEntidad.RegEstado == 1) //Nuevo
        //        {
        //            oCEntidad.COD_PGMF = OUTPUTPARAM01;
        //        }
        //        if (oCEntidad.ListTHabilitante != null)
        //        {
        //            foreach (var loDatos in oCEntidad.ListTHabilitante)
        //            {
        //                CEntidad oCamposDet = new CEntidad();
        //                oCamposDet.COD_THABILITANTE = loDatos.COD_THABILITANTE;
        //                oCamposDet.COD_PGMF = oCEntidad.COD_PGMF;
        //                oCamposDet.BusFormulario = "THABILITANTE";
        //                if (loDatos.RegEstado == 1)
        //                {
        //                    dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spPLAN_GENERALMANEJOFORESTAL_ItemsGRABAR", oCamposDet);
        //                }
        //            }
        //        }
        //        //
        //        //Eliminando Detalle
        //        if (oCEntidad.ListEliTABLA != null)
        //        {
        //            foreach (var loDatos in oCEntidad.ListEliTABLA)
        //            {
        //                CEntidad oCamposDet = new CEntidad();
        //                oCamposDet.COD_PGMF = OUTPUTPARAM01;
        //                oCamposDet.COD_THABILITANTE = loDatos.COD_THABILITANTE;
        //                oCamposDet.EliTABLA = loDatos.EliTABLA;
        //                oCamposDet.COD_ESPECIES = loDatos.COD_ESPECIES;
        //                oCamposDet.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
        //                oCamposDet.VERTICE = loDatos.VERTICE;
        //                oCamposDet.COD_AMENAZA = loDatos.COD_AMENAZA;
        //                dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spPLAN_GENERALMANEJOFORESTAL_Eliminar", oCamposDet);
        //            }
        //        }
        //        if (oCEntidad.ListEspecies != null)
        //        {
        //            foreach (var loDatos in oCEntidad.ListEspecies)
        //            {
        //                CEntidad oCamposDEt = new CEntidad();
        //                oCamposDEt.COD_PGMF = OUTPUTPARAM01;
        //                oCamposDEt.COD_ESPECIES = loDatos.COD_ESPECIES;
        //                oCamposDEt.NUM_BLOQUES = loDatos.NUM_BLOQUES;
        //                oCamposDEt.NUM_ARBOLES = loDatos.NUM_ARBOLES;
        //                oCamposDEt.VOLUMEN = loDatos.VOLUMEN;
        //                oCamposDEt.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
        //                oCamposDEt.BusFormulario = "ESPECIES";
        //                if (loDatos.RegEstado == 1)
        //                {
        //                    dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spPLAN_GENERALMANEJOFORESTAL_ItemsGRABAR", oCamposDEt);
        //                }
        //            }
        //        }

        //        if (oCEntidad.ListCoordenadas != null)
        //        {
        //            foreach (var loDatos in oCEntidad.ListCoordenadas)
        //            {
        //                CEntidad oCamposDet = new CEntidad();
        //                oCamposDet.COD_PGMF = OUTPUTPARAM01;
        //                oCamposDet.VERTICE = loDatos.VERTICE;
        //                oCamposDet.COORDENADA_ESTE = loDatos.COORDENADA_ESTE;
        //                oCamposDet.COORDENADA_NORTE = loDatos.COORDENADA_NORTE;
        //                oCamposDet.OBSERVACIONES = loDatos.OBSERVACIONES;
        //                oCamposDet.BusFormulario = "COORDENADAS";
        //                oCamposDet.COD_UCUENTA = oCEntidad.COD_UCUENTA;
        //                oCamposDet.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
        //                if (loDatos.RegEstado == 1)
        //                {
        //                    dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spPLAN_GENERALMANEJOFORESTAL_ItemsGRABAR", oCamposDet);
        //                }
        //            }
        //        }
        //        if (oCEntidad.ListEspeciesFauna != null)
        //        {
        //            foreach (var loDatos in oCEntidad.ListEspeciesFauna)
        //            {
        //                CEntidad oCamposDet = new CEntidad();
        //                oCamposDet.COD_PGMF = OUTPUTPARAM01;
        //                oCamposDet.COD_ESPECIES = loDatos.COD_ESPECIES;
        //                oCamposDet.COD_AMENAZA = loDatos.COD_AMENAZA;
        //                oCamposDet.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
        //                oCamposDet.OBSERVACIONES = loDatos.OBSERVACIONES;
        //                oCamposDet.BusFormulario = "FAUNA";
        //                if (loDatos.RegEstado == 1)
        //                {
        //                    dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spPLAN_GENERALMANEJOFORESTAL_ItemsGRABAR", oCamposDet);
        //                }
        //            }
        //        }

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


        //public CEntidad RegMostrarListaItemsPGMF(OracleConnection cn, CEntidad oCEntidad)
        //{
        //    CEntidad oCampos = new CEntidad();
        //    try
        //    {
        //        using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spPLAN_GENERALMANEJOFORESTALMostItems", oCEntidad))
        //        {
        //            if (dr != null)
        //            {
        //                oCampos.ListTHabilitante = new List<CEntidad>();
        //                oCampos.ListEspecies = new List<CEntidad>();
        //                oCampos.ListCoordenadas = new List<CEntidad>();
        //                oCampos.ListEspeciesFauna = new List<CEntidad>();
        //                oCampos.ListDependencia = new List<CEntidad>();
        //                CEntidad oCamposDet;
        //                //
        //                if (dr.HasRows)
        //                {
        //                    dr.Read();
        //                    oCampos.COD_PGMF = dr.GetString(dr.GetOrdinal("COD_PGMF"));
        //                    oCampos.NUMERO_PGMF = dr.GetString(dr.GetOrdinal("NUMERO_PGMF"));
        //                    oCampos.FECHA_RESOLUCION = dr.GetString(dr.GetOrdinal("FECHA_PGMF"));
        //                    oCampos.COD_FUNCIONARIO = dr.GetString(dr.GetOrdinal("COD_FUNCIONARIO"));
        //                    oCampos.FUNCIONARIO_APROB_ACTIVIDAD = dr.GetString(dr.GetOrdinal("FUNCIONARIO"));
        //                    oCampos.PRIM_QUIENQUENIO = dr.GetInt32(dr.GetOrdinal("PRIMER_QUIN"));
        //                    oCampos.SEG_QUINQUENIO = dr.GetInt32(dr.GetOrdinal("SEGUN_QUIN"));
        //                    oCampos.TERC_QUINQUENIO = dr.GetInt32(dr.GetOrdinal("TERC_QUIN"));
        //                    oCampos.CUART_QUINQUENIO = dr.GetInt32(dr.GetOrdinal("CUART_QUIN"));
        //                    oCampos.NUM_BLOQUES = dr.GetInt32(dr.GetOrdinal("NUM_BLOQUE"));
        //                    oCampos.AREA_PGMF = dr.GetDecimal(dr.GetOrdinal("AREA_PGMF"));
        //                    oCampos.PERIODO = dr.GetInt32(dr.GetOrdinal("PERIODO"));
        //                    oCampos.FECHA_INICIO = dr.GetString(dr.GetOrdinal("FECHA_INICIO"));
        //                    oCampos.FECHA_FIN = dr.GetString(dr.GetOrdinal("FECHA_FIN"));
        //                    oCampos.NUM_INFORME = dr.GetString(dr.GetOrdinal("NUM_INFORME"));
        //                    oCampos.FECHA_INFORME = dr.GetString(dr.GetOrdinal("FECHA_INFORME"));
        //                    oCampos.COD_PROF_INFORME = dr.GetString(dr.GetOrdinal("COD_PROFESIONAL"));
        //                    oCampos.PROFESIONAL_NOMBRE = dr.GetString(dr.GetOrdinal("PROFESIONAL"));
        //                    oCampos.COD_CONSULTOR = dr.GetString(dr.GetOrdinal("COD_CONSULTOR"));
        //                    oCampos.CONSULTOR_NOMBRE = dr.GetString(dr.GetOrdinal("CONSULTOR"));
        //                    oCampos.NUM_REGISTRO_ATFFS = dr.GetString(dr.GetOrdinal("NUM_ATFFS"));
        //                    oCampos.NUM_CIP = dr.GetString(dr.GetOrdinal("NUM_CIP"));
        //                    oCampos.CONSOLIDADCION = dr.GetBoolean(dr.GetOrdinal("CONSOLIDADO"));
        //                    oCampos.NOMBRE_CONSOLIDAD = dr.GetString(dr.GetOrdinal("NOM_CONSOLIDADO"));
        //                    oCampos.OBSERVACIONES = dr.GetString(dr.GetOrdinal("OBSERVACIONES"));
        //                    oCampos.COD_OD_REGISTRO = dr.GetString(dr.GetOrdinal("COD_OD_REGISTRO"));
        //                    oCampos.USUARIO_REGISTRO = dr.GetString(dr.GetOrdinal("USUARIO_REGISTRO"));
        //                    oCampos.COD_DEPENDENCIA = dr.GetInt32(dr.GetOrdinal("COD_DEPENDENCIA")).ToString();
        //                }
        //                //Estado (Calidad)
        //                dr.NextResult();
        //                if (dr.HasRows)
        //                {
        //                    dr.Read();
        //                    oCampos.COD_ESTADO_DOC = dr.GetString(dr.GetOrdinal("COD_ESTADO_DOC"));
        //                    oCampos.OBSERVACIONES_CONTROL = dr.GetString(dr.GetOrdinal("OBSERVACIONES_CONTROL"));
        //                    oCampos.OBSERV_SUBSANAR = dr.GetBoolean(dr.GetOrdinal("OBSERV_SUBSANAR"));
        //                    oCampos.USUARIO_CONTROL = dr.GetString(dr.GetOrdinal("USUARIO_CONTROL"));
        //                }
        //                else
        //                {
        //                    oCampos.COD_ESTADO_DOC = "";
        //                    oCampos.OBSERVACIONES_CONTROL = "";
        //                    oCampos.OBSERV_SUBSANAR = false;
        //                    oCampos.USUARIO_CONTROL = "";
        //                }

        //                //lista de titulo habilitantes
        //                dr.NextResult();
        //                if (dr.HasRows)
        //                {

        //                    while (dr.Read())
        //                    {
        //                        oCamposDet = new CEntidad();
        //                        oCamposDet.COD_THABILITANTE = dr["COD_THABILITANTE"].ToString();
        //                        oCamposDet.DESCRIPCION = dr["NUMERO"].ToString();
        //                        oCamposDet.MODALIDAD = dr["MODALIDAD"].ToString();
        //                        oCamposDet.PERSONA_TITULAR = dr["PERSONA_TITULAR"].ToString();
        //                        oCamposDet.COD_OD_REGISTRO = dr["REGION"].ToString();
        //                        oCamposDet.D_LINEA = dr["D_LINEA"].ToString();
        //                        oCamposDet.RegEstado = 0;
        //                        oCampos.ListTHabilitante.Add(oCamposDet);
        //                    }
        //                }

        //                //lista de especies
        //                dr.NextResult();
        //                if (dr.HasRows)
        //                {
        //                    while (dr.Read())
        //                    {
        //                        oCamposDet = new CEntidad();
        //                        oCamposDet.COD_PGMF = dr["COD_PGMF"].ToString();
        //                        oCamposDet.COD_ESPECIES = dr["COD_ESPECIE"].ToString();
        //                        oCamposDet.DESCRIPCION = dr["DESCRIPCION"].ToString();
        //                        oCamposDet.NUM_BLOQUES = Int32.Parse(dr["NUM_BLOQUE"].ToString());
        //                        oCamposDet.NUM_ARBOLES = Int32.Parse(dr["NUM_ARBOLES"].ToString());
        //                        oCamposDet.VOLUMEN = Decimal.Parse(dr["VOLUMEN"].ToString());
        //                        oCamposDet.COD_SECUENCIAL = Int32.Parse(dr["COD_SECUENCIAL"].ToString());
        //                        oCamposDet.RegEstado = 0;
        //                        oCampos.ListEspecies.Add(oCamposDet);
        //                    }
        //                }
        //                //lista de coordenadas
        //                dr.NextResult();
        //                if (dr.HasRows)
        //                {
        //                    while (dr.Read())
        //                    {
        //                        oCamposDet = new CEntidad();
        //                        oCamposDet.COD_PGMF = dr["COD_PGMF"].ToString();
        //                        oCamposDet.VERTICE = dr["VERTICE"].ToString();
        //                        oCamposDet.COD_SECUENCIAL = Int32.Parse(dr["COD_SECUENCIAL"].ToString());
        //                        oCamposDet.COORDENADA_ESTE = Int32.Parse(dr["COORD_ESTE"].ToString());
        //                        oCamposDet.COORDENADA_NORTE = Int32.Parse(dr["COORD_NORTE"].ToString());
        //                        oCamposDet.OBSERVACIONES = dr["OBSERVACION"].ToString();
        //                        oCamposDet.RegEstado = 0;
        //                        oCampos.ListCoordenadas.Add(oCamposDet);
        //                    }
        //                }
        //                //LISTA DE ESPECIES FAUNA
        //                dr.NextResult();
        //                if (dr.HasRows)
        //                {
        //                    while (dr.Read())
        //                    {
        //                        oCamposDet = new CEntidad();
        //                        oCamposDet.COD_PGMF = dr["COD_PGMF"].ToString();
        //                        oCamposDet.COD_ESPECIES = dr["COD_ESPECIE"].ToString();
        //                        oCamposDet.DESCRIPCION = dr["DESCRIPCION"].ToString();
        //                        oCamposDet.COD_SECUENCIAL = Int32.Parse(dr["COD_SECUENCIAL"].ToString());
        //                        oCamposDet.COD_AMENAZA = dr["COD_AMENAZA"].ToString();
        //                        oCamposDet.DESC_AMENAZA = dr["DESCRIPCION_AMENAZA"].ToString();
        //                        oCamposDet.OBSERVACIONES = dr["OBSERVACIONES"].ToString();
        //                        oCamposDet.RegEstado = 0;
        //                        oCampos.ListEspeciesFauna.Add(oCamposDet);
        //                    }
        //                }
        //                //Dependencias
        //                dr.NextResult();
        //                if (dr.HasRows)
        //                {
        //                    int pt1 = dr.GetOrdinal("CODIGO");
        //                    int pt2 = dr.GetOrdinal("DESCRIPCION");


        //                    while (dr.Read())
        //                    {
        //                        oCamposDet = new CEntidad();
        //                        oCamposDet.CODIGO = dr.GetInt32(pt1).ToString();
        //                        oCamposDet.DESCRIPCION = dr.GetString(pt2);

        //                        oCampos.ListDependencia.Add(oCamposDet);
        //                    }
        //                }

        //            }
        //        }
        //        return oCampos;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        /// <summary>
        /// metodo para obtener la lista de titulo habilitante
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public List<CEntidad> datListTitulo(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spGeneral_Listar", oCEntidad))
                {
                    if (dr != null)
                    {
                        CEntidad ocampoEnt;
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidad();
                                ocampoEnt.COD_THABILITANTE = dr["COD_THABILITANTE"].ToString();
                                ocampoEnt.CODIGO = dr["COD_THABILITANTE"].ToString();
                                ocampoEnt.DESCRIPCION = dr["NUMERO"].ToString();
                                ocampoEnt.PERSONA_TITULAR = dr["PERSONA_TITULAR"].ToString();
                                ocampoEnt.MODALIDAD = dr["MODALIDAD"].ToString();
                                ocampoEnt.COD_OD_REGISTRO = dr["REGION"].ToString();
                                ocampoEnt.D_LINEA = dr["D_LINEA"].ToString();
                                ocampoEnt.RegEstado = 1;
                                lsCEntidad.Add(ocampoEnt);
                            }
                        }
                    }
                }
                return lsCEntidad;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// metodo para llenar el combo de especies
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public CEntidad datListComboLlenar(OracleConnection cn, CEntidad oCEntidad)
        {
            CEntidad oCampos = new CEntidad();
            oCampos.ListEspecies = new List<CEntidad>();
            oCampos.ListEspeciesFauna = new List<CEntidad>();
            oCampos.ListGradAmenaza = new List<CEntidad>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spGeneral_Combo_Listar", oCEntidad))
                {
                    if (dr != null)
                    {
                        CEntidad ocampoEnt;
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidad();
                                ocampoEnt.CODIGO = dr["CODIGO"].ToString();
                                ocampoEnt.DESCRIPCION = dr["DESCRIPCION"].ToString();
                                oCampos.ListEspecies.Add(ocampoEnt);
                            }
                        }
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidad();
                                ocampoEnt.CODIGO = dr["CODIGO"].ToString();
                                ocampoEnt.DESCRIPCION = dr["DESCRIPCION"].ToString();
                                oCampos.ListGradAmenaza.Add(ocampoEnt);
                            }
                        }
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidad();
                                ocampoEnt.CODIGO = dr["CODIGO"].ToString();
                                ocampoEnt.DESCRIPCION = dr["DESCRIPCION"].ToString();
                                oCampos.ListEspeciesFauna.Add(ocampoEnt);
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
        #region "Dat Sigo V3"
        public String ValidarResolucionPGMFV3(CEntidad oCEntidad)
        {
            String OUTPUTPARAM01 = "";
            OracleTransaction tr = null;
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    tr = cn.BeginTransaction();
                    using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.uspPLANGENERALMANEJOFORESTAL_EXISTE_RESOLUCION", oCEntidad))
                    {
                        cmd.ExecuteNonQuery();
                        OUTPUTPARAM01 = (String)cmd.Parameters["OUTPUTPARAM01"].Value;
                    }
                }
            }
            catch (Exception ex)
            {
                if (tr != null) tr.Dispose();
                throw ex;
            }
            return OUTPUTPARAM01;
        }
        public String RegGrabarPGMFV3(OracleConnection cn, CEntidad oCEntidad, OracleTransaction tr)
        {
            String OUTPUTPARAM01 = "";
            try
            {
                //Grabando Cabecera
                using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.uspPLANGENERALMANEJOFORESTAL_GrabarSigoV3", oCEntidad))
                {
                    cmd.ExecuteNonQuery();
                    OUTPUTPARAM01 = (String)cmd.Parameters["OUTPUTPARAM01"].Value;
                    if (OUTPUTPARAM01 == "99")
                    {
                        throw new Exception("Ud. no tiene permiso para realizar esta acción");
                    }
                    if (OUTPUTPARAM01 == "0")
                    {
                        throw new Exception("El Número PGMF ya existe");
                    }
                    else if (OUTPUTPARAM01 == "1")
                    {
                        throw new Exception("El Número PGMF Existe en otro Registro");
                    }
                    else if (OUTPUTPARAM01 == "2")
                    {
                        throw new Exception("No Tiene Permisos para Modificar");
                    }
                    else if (OUTPUTPARAM01 == "3")
                    {
                        throw new Exception("Está con Control de Calidad, no puede modificar");
                    }
                }
                //Reemplazando El Nuevo Codigo Creado
                //String[] cadena = OUTPUTPARAM02.Split('|');
                if (oCEntidad.RegEstado == 1) //Nuevo
                {
                    oCEntidad.COD_PGMF = OUTPUTPARAM01;
                }
                if (oCEntidad.ListTHabilitante != null)
                {
                    foreach (var loDatos in oCEntidad.ListTHabilitante)
                    {
                        CEntidad oCamposDet = new CEntidad();
                        oCamposDet.COD_THABILITANTE = loDatos.COD_THABILITANTE;
                        oCamposDet.COD_PGMF = oCEntidad.COD_PGMF;
                        oCamposDet.BusFormulario = "THABILITANTE";
                        if (loDatos.RegEstado == 1)
                        {
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.uspPLAN_GENERALMANEJOFORESTAL_ItemsGRABARV3", oCamposDet);
                        }
                    }
                }
                //
                //Eliminando Detalle
                if (oCEntidad.ListEliTABLA != null)
                {
                    foreach (var loDatos in oCEntidad.ListEliTABLA)
                    {
                        CEntidad oCamposDet = new CEntidad();
                        oCamposDet.COD_PGMF = OUTPUTPARAM01;
                        oCamposDet.COD_THABILITANTE = loDatos.COD_THABILITANTE;
                        oCamposDet.EliTABLA = loDatos.EliTABLA;
                        oCamposDet.COD_ESPECIES = loDatos.COD_ESPECIES;
                        oCamposDet.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                        oCamposDet.VERTICE = loDatos.VERTICE;
                        oCamposDet.COD_AMENAZA = loDatos.COD_AMENAZA;
                        dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spPLAN_GENERALMANEJOFORESTAL_Eliminar", oCamposDet);
                    }
                }
                if (oCEntidad.ListEspecies != null)
                {
                    foreach (var loDatos in oCEntidad.ListEspecies)
                    {
                        CEntidad oCamposDEt = new CEntidad();
                        oCamposDEt.COD_PGMF = OUTPUTPARAM01;                        
                        oCamposDEt.COD_ESPECIES = loDatos.COD_ESPECIES;
                        oCamposDEt.NUM_BLOQUES = loDatos.NUM_BLOQUES;
                        oCamposDEt.NUM_ARBOLES = loDatos.NUM_ARBOLES;
                        oCamposDEt.VOLUMEN = loDatos.VOLUMEN;
                        oCamposDEt.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                        oCamposDEt.BusFormulario = "ESPECIES";
                        oCamposDEt.TIPOMADERABLE = loDatos.TIPOMADERABLE;
                        oCamposDEt.UNIDAD_MEDIDA = loDatos.UNIDAD_MEDIDA;
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2)
                        {
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.uspPLAN_GENERALMANEJOFORESTAL_ItemsGRABARV3", oCamposDEt);                                                                                  
                        }
                    }
                }

                if (oCEntidad.ListCoordenadas != null)
                {
                    foreach (var loDatos in oCEntidad.ListCoordenadas)
                    {
                        CEntidad oCamposDet = new CEntidad();
                        oCamposDet.COD_PGMF = OUTPUTPARAM01;
                        oCamposDet.VERTICE = loDatos.VERTICE;
                        oCamposDet.COORDENADA_ESTE = loDatos.COORDENADA_ESTE;
                        oCamposDet.COORDENADA_NORTE = loDatos.COORDENADA_NORTE;
                        oCamposDet.OBSERVACIONES = loDatos.OBSERVACIONES;
                        oCamposDet.BusFormulario = "COORDENADAS";
                        oCamposDet.COD_UCUENTA = oCEntidad.COD_UCUENTA;
                        oCamposDet.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2)
                        {
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.uspPLAN_GENERALMANEJOFORESTAL_ItemsGRABARV3", oCamposDet);
                        }
                    }
                }
                if (oCEntidad.ListEspeciesFauna != null)
                {
                    foreach (var loDatos in oCEntidad.ListEspeciesFauna)
                    {
                        CEntidad oCamposDet = new CEntidad();
                        oCamposDet.COD_PGMF = OUTPUTPARAM01;
                        oCamposDet.COD_ESPECIES = loDatos.COD_ESPECIES;
                        oCamposDet.COD_AMENAZA = loDatos.COD_AMENAZA;
                        oCamposDet.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                        oCamposDet.OBSERVACIONES = loDatos.OBSERVACIONES;
                        oCamposDet.BusFormulario = "FAUNA";
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2)
                        {
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.uspPLAN_GENERALMANEJOFORESTAL_ItemsGRABARV3", oCamposDet);
                        }
                    }
                }

                return OUTPUTPARAM01;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public CEntidad RegMostrarListaItemsPGMFV3(OracleConnection cn, CEntidad oCEntidad)
        {
            CEntidad oCampos = new CEntidad();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.uspPLAN_GENERALMANEJOFORESTALMostItemsSigoV3", oCEntidad))
                {
                    if (dr != null)
                    {
                        oCampos.ListTHabilitante = new List<CEntidad>();
                        oCampos.ListEspecies = new List<CEntidad>();
                        oCampos.ListCoordenadas = new List<CEntidad>();
                        oCampos.ListEspeciesFauna = new List<CEntidad>();
                        oCampos.ListDependencia = new List<CEntidad>();
                        CEntidad oCamposDet;
                        //
                        if (dr.HasRows)
                        {
                            dr.Read();
                            oCampos.COD_PGMF = dr.GetString(dr.GetOrdinal("COD_PGMF"));
                            oCampos.NUMERO_PGMF = dr.GetString(dr.GetOrdinal("NUMERO_PGMF"));
                            oCampos.FECHA_RESOLUCION = dr.GetString(dr.GetOrdinal("FECHA_PGMF"));
                            oCampos.COD_FUNCIONARIO = dr.GetString(dr.GetOrdinal("COD_FUNCIONARIO"));
                            oCampos.FUNCIONARIO_APROB_ACTIVIDAD = dr.GetString(dr.GetOrdinal("FUNCIONARIO"));
                            oCampos.PRIM_QUIENQUENIO = dr.GetInt32(dr.GetOrdinal("PRIMER_QUIN"));
                            oCampos.SEG_QUINQUENIO = dr.GetInt32(dr.GetOrdinal("SEGUN_QUIN"));
                            oCampos.TERC_QUINQUENIO = dr.GetInt32(dr.GetOrdinal("TERC_QUIN"));
                            oCampos.CUART_QUINQUENIO = dr.GetInt32(dr.GetOrdinal("CUART_QUIN"));
                            oCampos.NUM_BLOQUES = dr.GetInt32(dr.GetOrdinal("NUM_BLOQUE"));
                            oCampos.AREA_PGMF = dr.GetDecimal(dr.GetOrdinal("AREA_PGMF"));
                            oCampos.PERIODO = dr.GetInt32(dr.GetOrdinal("PERIODO"));
                            oCampos.FECHA_INICIO = dr.GetString(dr.GetOrdinal("FECHA_INICIO"));
                            oCampos.FECHA_FIN = dr.GetString(dr.GetOrdinal("FECHA_FIN"));
                            oCampos.NUM_INFORME = dr.GetString(dr.GetOrdinal("NUM_INFORME"));
                            oCampos.FECHA_INFORME = dr.GetString(dr.GetOrdinal("FECHA_INFORME"));
                            oCampos.COD_PROF_INFORME = dr.GetString(dr.GetOrdinal("COD_PROFESIONAL"));
                            oCampos.PROFESIONAL_NOMBRE = dr.GetString(dr.GetOrdinal("PROFESIONAL"));
                            oCampos.COD_CONSULTOR = dr.GetString(dr.GetOrdinal("COD_CONSULTOR"));
                            oCampos.CONSULTOR_NOMBRE = dr.GetString(dr.GetOrdinal("CONSULTOR"));
                            oCampos.NUM_REGISTRO_ATFFS = dr.GetString(dr.GetOrdinal("NUM_ATFFS"));
                            oCampos.NUM_CIP = dr.GetString(dr.GetOrdinal("NUM_CIP"));
                            oCampos.CONSOLIDADCION = dr.GetBoolean(dr.GetOrdinal("CONSOLIDADO"));
                            oCampos.NOMBRE_CONSOLIDAD = dr.GetString(dr.GetOrdinal("NOM_CONSOLIDADO"));
                            oCampos.OBSERVACIONES = dr.GetString(dr.GetOrdinal("OBSERVACIONES"));
                            oCampos.COD_OD_REGISTRO = dr.GetString(dr.GetOrdinal("COD_OD_REGISTRO"));
                            oCampos.USUARIO_REGISTRO = dr.GetString(dr.GetOrdinal("USUARIO_REGISTRO"));
                            oCampos.TIPO_PLAN = dr.GetString(dr.GetOrdinal("TIPO_PLAN"));
                            oCampos.COD_DEPENDENCIA = dr.GetInt32(dr.GetOrdinal("COD_DEPENDENCIA")).ToString();
                        }
                        //Estado (Calidad)
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

                        //lista de titulo habilitantes
                        dr.NextResult();
                        if (dr.HasRows)
                        {

                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.COD_THABILITANTE = dr["COD_THABILITANTE"].ToString();
                                oCamposDet.DESCRIPCION = dr["NUMERO"].ToString();
                                oCamposDet.MODALIDAD = dr["MODALIDAD"].ToString();
                                oCamposDet.PERSONA_TITULAR = dr["PERSONA_TITULAR"].ToString();
                                oCamposDet.COD_OD_REGISTRO = dr["REGION"].ToString();
                                oCamposDet.D_LINEA = dr["D_LINEA"].ToString();
                                oCamposDet.RegEstado = 0;
                                oCampos.ListTHabilitante.Add(oCamposDet);
                            }
                        }

                        //lista de especies
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.COD_PGMF = dr["COD_PGMF"].ToString();
                                oCamposDet.COD_ESPECIES = dr["COD_ESPECIE"].ToString();
                                oCamposDet.DESCRIPCION = dr["DESCRIPCION"].ToString();
                                oCamposDet.NUM_BLOQUES = Int32.Parse(dr["NUM_BLOQUE"].ToString());
                                oCamposDet.NUM_ARBOLES = Int32.Parse(dr["NUM_ARBOLES"].ToString());
                                oCamposDet.VOLUMEN = Decimal.Parse(dr["VOLUMEN"].ToString());
                                oCamposDet.COD_SECUENCIAL = Int32.Parse(dr["COD_SECUENCIAL"].ToString());
                                oCamposDet.TIPOMADERABLE = dr["TIPOMADERABLE"].ToString();
                                oCamposDet.UNIDAD_MEDIDA = dr["UNIDAD_MEDIDA"].ToString();
                                oCamposDet.RegEstado = 0;
                                oCampos.ListEspecies.Add(oCamposDet);
                            }
                        }
                        //lista de coordenadas
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.COD_PGMF = dr["COD_PGMF"].ToString();
                                oCamposDet.VERTICE = dr["VERTICE"].ToString();
                                oCamposDet.COD_SECUENCIAL = Int32.Parse(dr["COD_SECUENCIAL"].ToString());
                                oCamposDet.COORDENADA_ESTE = Int32.Parse(dr["COORD_ESTE"].ToString());
                                oCamposDet.COORDENADA_NORTE = Int32.Parse(dr["COORD_NORTE"].ToString());
                                oCamposDet.OBSERVACIONES = dr["OBSERVACION"].ToString();
                                oCamposDet.RegEstado = 0;
                                oCampos.ListCoordenadas.Add(oCamposDet);
                            }
                        }
                        //LISTA DE ESPECIES FAUNA
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.COD_PGMF = dr["COD_PGMF"].ToString();
                                oCamposDet.COD_ESPECIES = dr["COD_ESPECIE"].ToString();
                                oCamposDet.DESCRIPCION = dr["DESCRIPCION"].ToString();
                                oCamposDet.COD_SECUENCIAL = Int32.Parse(dr["COD_SECUENCIAL"].ToString());
                                oCamposDet.COD_AMENAZA = dr["COD_AMENAZA"].ToString();
                                oCamposDet.DESC_AMENAZA = dr["DESCRIPCION_AMENAZA"].ToString();
                                oCamposDet.OBSERVACIONES = dr["OBSERVACIONES"].ToString();
                                oCamposDet.RegEstado = 0;
                                oCampos.ListEspeciesFauna.Add(oCamposDet);
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

                    }
                }
                return oCampos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public CapaEntidad.ViewModel.VM_ControlCalidad datObtenerControlCalidadV3(OracleConnection cn, CEntidad oCEntidad)
        {
            CapaEntidad.ViewModel.VM_ControlCalidad oCampos = new CapaEntidad.ViewModel.VM_ControlCalidad();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.usp_ObtenerControlCalidad_SigoV3", oCEntidad))
                {
                    if (dr != null)
                    {
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
                    }
                }
                return oCampos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public CEntidad datListComboLlenarV3(OracleConnection cn, CEntidad oCEntidad)
        {
            CEntidad oCampos = new CEntidad();
            oCampos.ListEspecies = new List<CEntidad>();
            oCampos.ListEspeciesFauna = new List<CEntidad>();
            oCampos.ListGradAmenaza = new List<CEntidad>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.uspGeneral_Combo_Listar_SigoV3", oCEntidad))
                {
                    if (dr != null)
                    {
                        CEntidad ocampoEnt;
                        if (dr.HasRows)
                        {
                            if (oCEntidad.BusCriterio == "COMBO_ESPECIES_PGMF_MADERABLES")
                            {
                                while (dr.Read())
                                {
                                    ocampoEnt = new CEntidad();
                                    ocampoEnt.CODIGO = dr["CODIGO"].ToString();
                                    ocampoEnt.DESCRIPCION = dr["DESCRIPCION"].ToString();
                                    oCampos.ListEspecies.Add(ocampoEnt);
                                }
                            }

                        }
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidad();
                                ocampoEnt.CODIGO = dr["CODIGO"].ToString();
                                ocampoEnt.DESCRIPCION = dr["DESCRIPCION"].ToString();
                                oCampos.ListGradAmenaza.Add(ocampoEnt);
                            }
                        }
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidad();
                                ocampoEnt.CODIGO = dr["CODIGO"].ToString();
                                ocampoEnt.DESCRIPCION = dr["DESCRIPCION"].ToString();
                                oCampos.ListEspeciesFauna.Add(ocampoEnt);
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
        public List<VM_Cbo> GetDatosComboV3(OracleConnection cn, CEntidad oCEntidad, bool addSeleccionar = false)
        {
            List<VM_Cbo> oCampos = new List<VM_Cbo>();
            if (addSeleccionar)
            {
                oCampos.Add(new VM_Cbo { Value = "-", Text = "(Seleccionar)" });
            }
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.uspGeneral_Combo_Listar_SigoV3", oCEntidad))
                {
                    if (dr != null)
                    {
                        VM_Cbo ocampoEnt;
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                ocampoEnt = new VM_Cbo();
                                ocampoEnt.Value = dr["CODIGO"].ToString();
                                ocampoEnt.Text = dr["DESCRIPCION"].ToString();
                                switch (oCEntidad.BusCriterio)
                                {
                                    case "Motivo_Exsitu": ocampoEnt.Tipo = dr["TIPO"].ToString(); break;
                                }
                                oCampos.Add(ocampoEnt);
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
        public List<Dictionary<string, string>> RegMostrarPlanManejoList(OracleConnection cn, CEntidad oCEntidad)
        {
            List<Dictionary<string, string>> lsCEntidad = new List<Dictionary<string, string>>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spGeneral_Listar", oCEntidad))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            string[] demoStr = new string[]{ "COD_PMANEJO", "COD_THABILITANTE", "FECHA", "FECHA_PRESENTACION",
                            "MODALIDAD","NUM_THABILITANTE","PERSONA_TITULAR","ARESOLUCION_NUM","COD_MTIPO","ESTADO_ORIGEN_TIPO",
                            "INDICADOR","ESTADO_ORIGEN","HIJO_COD_PMANEJO","HIJO_NIVEL"};
                            lsCEntidad = this.CreateList(dr, demoStr);
                        }
                    }
                }
                return lsCEntidad;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<VM> RegMostrarPlanManejoList1(OracleConnection cn, CEntidad oCEntidad)
        {
            List<VM> lsCEntidad = new List<VM>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spGeneral_Listar", oCEntidad))
                {
                    if (dr != null)
                    {
                        VM oCamposdet;
                        if (dr.HasRows)
                        {
                            int p1 = dr.GetOrdinal("COD_PMANEJO");
                            int p01 = dr.GetOrdinal("COD_THABILITANTE");
                            int p02 = dr.GetOrdinal("FECHA");
                            int p2 = dr.GetOrdinal("FECHA_PRESENTACION");
                            int p3 = dr.GetOrdinal("MODALIDAD");
                            int p4 = dr.GetOrdinal("NUM_THABILITANTE");
                            int p5 = dr.GetOrdinal("PERSONA_TITULAR");
                            int p6 = dr.GetOrdinal("ARESOLUCION_NUM");
                            int p7 = dr.GetOrdinal("COD_MTIPO");
                            int p07 = dr.GetOrdinal("ESTADO_ORIGEN_TIPO");
                            int p8 = dr.GetOrdinal("INDICADOR");
                            int p9 = dr.GetOrdinal("ESTADO_ORIGEN");
                            int p10 = dr.GetOrdinal("HIJO_COD_PMANEJO");
                            int p11 = dr.GetOrdinal("HIJO_NIVEL");
                            Int32 contador = 1;
                            while (dr.Read())
                            {
                                oCamposdet = new VM();
                                oCamposdet.COD_PMANEJO = dr.GetString(p1);
                                oCamposdet.COD_THABILITANTE = dr.GetString(p01);
                                oCamposdet.FECHA = dr.GetString(p02);
                                oCamposdet.FECHA_PRESENTACION = dr.GetString(p2);
                                oCamposdet.MODALIDAD = dr.GetString(p3);
                                oCamposdet.NUM_THABILITANTE = dr.GetString(p4);
                                oCamposdet.PERSONA_TITULAR = dr.GetString(p5);
                                oCamposdet.ARESOLUCION_NUM = dr.GetString(p6);
                                oCamposdet.COD_MTIPO = dr.GetString(p7);
                                oCamposdet.ESTADO_ORIGEN_TIPO = dr.GetString(p07);
                                oCamposdet.INDICADOR = dr.GetString(p8);
                                oCamposdet.ESTADO_ORIGEN = dr.GetString(p9);
                                oCamposdet.HIJO_COD_PMANEJO = dr.GetString(p10);
                                oCamposdet.HIJO_NIVEL = dr.GetInt32(p11);
                                oCamposdet.contador = contador;
                                lsCEntidad.Add(oCamposdet);
                                contador++;
                            }

                        }
                    }
                }
                return lsCEntidad;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Dictionary<string, string>> RegMostrarListaItemsESituV3(OracleConnection cn, CEntidad oCEntidad)
        {
            List<Dictionary<string, string>> listado = new List<Dictionary<string, string>>();
            int ind = 1;
            Dictionary<string, string> oCamposDet;
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.uspPLAN_MANEJOMostItemsESituV3", oCEntidad))
                {
                    if (dr != null)
                    {

                        //
                        //PLAN_MANEJO_EXSITU_DET_IANUAL
                        if (oCEntidad.BusCriterio == "1")
                        {
                            if (dr.HasRows)
                            {
                                int pt1 = dr.GetOrdinal("COD_SECUENCIAL");
                                int pt2 = dr.GetOrdinal("COD_UCUENTA");
                                int pt3 = dr.GetOrdinal("ANO_EJECUTADO");
                                int pt4 = dr.GetOrdinal("FECHA_EMISION");
                                int pt5 = dr.GetOrdinal("FECHA_RECEPCION");
                                int pt6 = dr.GetOrdinal("PROFESIONAL_CODIGO");
                                int pt7 = dr.GetOrdinal("PROFESIONAL_NUM_REGISTRO_FFS");
                                int pt8 = dr.GetOrdinal("PROFESIONAL_NOMBRE");
                                int pt9 = dr.GetOrdinal("PROFESIONAL_DNI");
                                int pt10 = dr.GetOrdinal("PROFESIONAL_NUM_REGISTRO_PROFESIONAL");
                                int pt11 = dr.GetOrdinal("ACORDE_TDR_VIGENTE");
                                int pt12 = dr.GetOrdinal("OBSERVACION");
                                while (dr.Read())
                                {  //sFila = new Dictionary<string, string>();
                                   // sFila.Add("ROW_INDEX", dr["ROW_INDEX"].ToString());
                                    oCamposDet = new Dictionary<string, string>();
                                    oCamposDet.Add("COD_SECUENCIAL", dr.GetInt32(pt1).ToString());
                                    oCamposDet.Add("COD_UCUENTA", dr.GetString(pt2));
                                    oCamposDet.Add("ANO_EJECUTADO", dr.GetInt32(pt3).ToString());
                                    oCamposDet.Add("FECHA_EMISION", dr.GetString(pt4));
                                    oCamposDet.Add("FECHA_RECEPCION", dr.GetString(pt5));
                                    oCamposDet.Add("PROFESIONAL_CODIGO", dr.GetString(pt6));
                                    oCamposDet.Add("PROFESIONAL_NUM_REGISTRO_FFS", dr.GetString(pt7));
                                    oCamposDet.Add("PROFESIONAL_NOMBRE", dr.GetString(pt8));
                                    oCamposDet.Add("PROFESIONAL_DNI", dr.GetString(pt9));
                                    oCamposDet.Add("PROFESIONAL_NUM_REGISTRO_PROFESIONAL", dr.GetString(pt10));
                                    oCamposDet.Add("ACORDE_TDR_VIGENTE", dr.GetBoolean(pt11).ToString());
                                    oCamposDet.Add("OBSERVACION", dr.GetString(pt12));
                                    oCamposDet.Add("RegEstado", "0");
                                    oCamposDet.Add("ind", ind.ToString());
                                    ind++;
                                    listado.Add(oCamposDet);
                                }
                            }
                        }

                        // EXSITU PLAN GENETICO
                        if (oCEntidad.BusCriterio == "2")
                        {
                            if (dr.HasRows)
                            {
                                int pt1 = dr.GetOrdinal("COD_PGSECUENCIAL");
                                int pt2 = dr.GetOrdinal("ARESOLUCION_NUM");
                                int pt3 = dr.GetOrdinal("ARESOLUCION_FECHA");
                                int pt4 = dr.GetOrdinal("ARESOLUCION_COD_FUNCIONARIO");
                                int pt5 = dr.GetOrdinal("ARESOLUCION_FUNCIONARIO_NOMBRE");
                                int pt6 = dr.GetOrdinal("CARGO");
                                int pt7 = dr.GetOrdinal("FUNCIONARIO_DNI");
                                int pt8 = dr.GetOrdinal("OBSERVACION");
                                while (dr.Read())
                                {
                                    oCamposDet = new Dictionary<string, string>();
                                    oCamposDet.Add("COD_SECUENCIAL", dr.GetInt32(pt1).ToString());
                                    oCamposDet.Add("ARESOLUCION_NUM", dr.GetString(pt2));
                                    oCamposDet.Add("ARESOLUCION_FECHA", dr.GetString(pt3));
                                    oCamposDet.Add("ARESOLUCION_COD_FUNCIONARIO", dr.GetString(pt4));
                                    oCamposDet.Add("ARESOLUCION_FUNCIONARIO_NOMBRE", dr.GetString(pt5));
                                    oCamposDet.Add("CARGO", dr.GetString(pt6));
                                    oCamposDet.Add("FUNCIONARIO_DNI", dr.GetString(pt7));
                                    oCamposDet.Add("OBSERVACION", dr.GetString(pt8));
                                    oCamposDet.Add("RegEstado", "0");
                                    oCamposDet.Add("ind", ind.ToString());
                                    ind++;
                                    listado.Add(oCamposDet);
                                }
                            }
                        }

                        // BALANCE INDIVIDUOS
                        if (oCEntidad.BusCriterio == "3")
                        {
                            if (dr.HasRows)
                            {
                                int pt1 = dr.GetOrdinal("COD_ESPECIES");
                                int pt2 = dr.GetOrdinal("COD_SECUENCIAL");
                                int pt3 = dr.GetOrdinal("COD_MOTIVO");
                                int pt4 = dr.GetOrdinal("COD_SDOCUMENTO");
                                int pt5 = dr.GetOrdinal("NUM_SDOCUMENTO");
                                int pt6 = dr.GetOrdinal("NUM_DOCUMENTO");
                                int pt7 = dr.GetOrdinal("FECHA_EMISION");
                                int pt8 = dr.GetOrdinal("FECHA_RECEPCION");
                                int pt9 = dr.GetOrdinal("TIPO");
                                int pt10 = dr.GetOrdinal("OBSERVACION");
                                int pt11 = dr.GetOrdinal("ESPECIES");
                                int pt12 = dr.GetOrdinal("DOCUMENTO");
                                int pt13 = dr.GetOrdinal("MOTIVO");
                                while (dr.Read())
                                {
                                    oCamposDet = new Dictionary<string, string>();
                                    oCamposDet.Add("COD_ESPECIES", dr.GetString(pt1));
                                    oCamposDet.Add("COD_SECUENCIAL", dr.GetInt32(pt2).ToString());
                                    oCamposDet.Add("COD_MOTIVO", dr.GetString(pt3));
                                    oCamposDet.Add("COD_SDOCUMENTO ", dr.GetString(pt4));
                                    oCamposDet.Add("NUM_SDOCUMENTO", dr.GetString(pt5));
                                    oCamposDet.Add("NUM_DOCUMENTO", dr.GetString(pt6));
                                    oCamposDet.Add("FECHA_EMISION", dr.GetString(pt7));
                                    oCamposDet.Add("FECHA_RECEPCION", dr.GetString(pt8));
                                    oCamposDet.Add("TIPO", dr.GetString(pt9));
                                    oCamposDet.Add("OBSERVACION", dr.GetString(pt10));
                                    oCamposDet.Add("ESPECIES", dr.GetString(pt11));
                                    oCamposDet.Add("DOCUMENTO", dr.GetString(pt12));
                                    oCamposDet.Add("MOTIVO", dr.GetString(pt13));
                                    oCamposDet.Add("RegEstado", "0");
                                    oCamposDet.Add("ind", ind.ToString());
                                    ind++;
                                    listado.Add(oCamposDet);
                                }
                            }
                        }

                        if (oCEntidad.BusCriterio == "4")
                        {
                            if (dr.HasRows)
                            {
                                int pt1 = dr.GetOrdinal("COD_ESPECIES");
                                int pt2 = dr.GetOrdinal("COD_SECUENCIAL");
                                int pt3 = dr.GetOrdinal("COD_MOTIVO");
                                int pt4 = dr.GetOrdinal("COD_SDOCUMENTO");
                                int pt5 = dr.GetOrdinal("NUM_SDOCUMENTO");
                                int pt6 = dr.GetOrdinal("NUM_DOCUMENTO");
                                int pt7 = dr.GetOrdinal("FECHA_EMISION");
                                int pt8 = dr.GetOrdinal("FECHA_RECEPCION");
                                int pt9 = dr.GetOrdinal("TIPO");
                                int pt10 = dr.GetOrdinal("OBSERVACION");
                                int pt11 = dr.GetOrdinal("ESPECIES");
                                int pt12 = dr.GetOrdinal("DOCUMENTO");
                                int pt13 = dr.GetOrdinal("MOTIVO");
                                while (dr.Read())
                                {
                                    oCamposDet = new Dictionary<string, string>();
                                    oCamposDet.Add("COD_ESPECIES", dr.GetString(pt1));
                                    oCamposDet.Add("COD_SECUENCIAL", dr.GetInt32(pt2).ToString());
                                    oCamposDet.Add("COD_MOTIVO", dr.GetString(pt3));
                                    oCamposDet.Add("COD_SDOCUMENTO", dr.GetString(pt4));
                                    oCamposDet.Add("NUM_SDOCUMENTO", dr.GetString(pt5));
                                    oCamposDet.Add("NUM_DOCUMENTO", dr.GetString(pt6));
                                    oCamposDet.Add("FECHA_EMISION", dr.GetString(pt7));
                                    oCamposDet.Add("FECHA_RECEPCION", dr.GetString(pt8));
                                    oCamposDet.Add("TIPO", dr.GetString(pt9));
                                    oCamposDet.Add("OBSERVACION", dr.GetString(pt10));
                                    oCamposDet.Add("ESPECIES", dr.GetString(pt11));
                                    oCamposDet.Add("DOCUMENTO", dr.GetString(pt12));
                                    oCamposDet.Add("MOTIVO", dr.GetString(pt13));
                                    oCamposDet.Add("RegEstado", "0");
                                    oCamposDet.Add("ind", ind.ToString());
                                    ind++;
                                    listado.Add(oCamposDet);
                                }
                            }
                        }

                    }
                }
                return listado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public VM_ExSituItem GetESituAnualIdV3(OracleConnection cn, CEntidad oCEntidad)
        {
            VM_ExSituItem itemExSitu = new VM_ExSituItem();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.uspPLAN_MANEJOESituGetIdV3", oCEntidad))
                {
                    if (dr != null)
                    {

                        //
                        //PLAN_MANEJO_EXSITU_DET_IANUAL
                        if (oCEntidad.BusCriterio == "1")
                        {
                            if (dr.HasRows)
                            {
                                int pt1 = dr.GetOrdinal("COD_SECUENCIAL");
                                int pt2 = dr.GetOrdinal("COD_UCUENTA");
                                int pt3 = dr.GetOrdinal("ANO_EJECUTADO");
                                int pt4 = dr.GetOrdinal("FECHA_EMISION");
                                int pt5 = dr.GetOrdinal("FECHA_RECEPCION");
                                int pt6 = dr.GetOrdinal("PROFESIONAL_CODIGO");
                                int pt7 = dr.GetOrdinal("PROFESIONAL_NUM_REGISTRO_FFS");
                                int pt8 = dr.GetOrdinal("PROFESIONAL_NOMBRE");
                                int pt9 = dr.GetOrdinal("PROFESIONAL_DNI");
                                int pt10 = dr.GetOrdinal("PROFESIONAL_NUM_REGISTRO_PROFESIONAL");
                                int pt11 = dr.GetOrdinal("ACORDE_TDR_VIGENTE");
                                int pt12 = dr.GetOrdinal("OBSERVACION");
                                while (dr.Read())
                                {
                                    // sFila.Add("ROW_INDEX", dr["ROW_INDEX"].ToString());

                                    itemExSitu.COD_SECUENCIAL = Convert.ToInt32(dr.GetInt32(pt1).ToString());
                                    itemExSitu.txtItemESituIAnual_Ano = dr.GetInt32(pt3).ToString();
                                    itemExSitu.txtItemESituIAnual_FEmision = dr.GetString(pt4);
                                    itemExSitu.txtItemESituIAnual_FRecepcion = dr.GetString(pt5);
                                    itemExSitu.hdtxtProfesional = dr.GetString(pt6);
                                    itemExSitu.txtItemESituIAnual_PNR = dr.GetString(pt7);
                                    itemExSitu.txtProfesional = dr.GetString(pt8);
                                    itemExSitu.txtDni = dr.GetString(pt9);
                                    itemExSitu.lblItemESituIAnual_PNC = dr.GetString(pt10);
                                    itemExSitu.chkItemAcorde_Tdr_Vigente = dr.GetBoolean(pt11);
                                    itemExSitu.txtItemESituIAnual_Observacion = dr.GetString(pt12);
                                    itemExSitu.hdEstado = "0";
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return itemExSitu;
        }
        public VM_PGeneticoItem GetESituPGeneticoIdV3(OracleConnection cn, CEntidad oCEntidad)
        {
            VM_PGeneticoItem oCamposDet = new VM_PGeneticoItem();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.uspPLAN_MANEJOESituGetIdV3", oCEntidad))
                {
                    if (dr != null)
                    {
                        // EXSITU PLAN GENETICO                       
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("COD_PGSECUENCIAL");
                            int pt2 = dr.GetOrdinal("ARESOLUCION_NUM");
                            int pt3 = dr.GetOrdinal("ARESOLUCION_FECHA");
                            int pt4 = dr.GetOrdinal("ARESOLUCION_COD_FUNCIONARIO");
                            int pt5 = dr.GetOrdinal("ARESOLUCION_FUNCIONARIO_NOMBRE");
                            int pt6 = dr.GetOrdinal("CARGO");
                            int pt7 = dr.GetOrdinal("FUNCIONARIO_DNI");
                            int pt8 = dr.GetOrdinal("OBSERVACION");
                            while (dr.Read())
                            {
                                oCamposDet.COD_SECUENCIAL = dr.GetInt32(pt1);
                                oCamposDet.txtnum_resolucion = dr.GetString(pt2);
                                oCamposDet.txtfecha_emision_resolucion = dr.GetString(pt3);
                                oCamposDet.hdfItemPGenetico_PCodigo = dr.GetString(pt4);
                                oCamposDet.lblItemPGenetico_PNombre = dr.GetString(pt5);
                                oCamposDet.lblItemPGenetico_PCargo = dr.GetString(pt6);
                                oCamposDet.lblItemPGenetico_PDNI = dr.GetString(pt7);
                                oCamposDet.lblItemPGenetico_Observacion = dr.GetString(pt8);
                                oCamposDet.hdEstado = "0";

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
        public VM_BalanceItem GetESituBalanceIdV3(OracleConnection cn, CEntidad oCEntidad)
        {
            VM_BalanceItem oCamposDet = new VM_BalanceItem();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.uspPLAN_MANEJOESituGetIdV3", oCEntidad))
                {
                    if (dr != null)
                    {
                        // BALANCE INDIVIDUOS
                        if (oCEntidad.BusCriterio == "3" || oCEntidad.BusCriterio == "4")
                        {
                            if (dr.HasRows)
                            {
                                int pt1 = dr.GetOrdinal("COD_ESPECIES");
                                int pt2 = dr.GetOrdinal("COD_SECUENCIAL");
                                int pt3 = dr.GetOrdinal("COD_MOTIVO");
                                int pt4 = dr.GetOrdinal("COD_SDOCUMENTO");
                                int pt5 = dr.GetOrdinal("NUM_SDOCUMENTO");
                                int pt6 = dr.GetOrdinal("NUM_DOCUMENTO");
                                int pt7 = dr.GetOrdinal("FECHA_EMISION");
                                int pt8 = dr.GetOrdinal("FECHA_RECEPCION");
                                int pt9 = dr.GetOrdinal("TIPO");
                                int pt10 = dr.GetOrdinal("OBSERVACION");
                                int pt11 = dr.GetOrdinal("ESPECIES");
                                int pt12 = dr.GetOrdinal("DOCUMENTO");
                                int pt13 = dr.GetOrdinal("MOTIVO");
                                while (dr.Read())
                                {
                                    oCamposDet.ddlbfs_especieId = dr.GetString(pt1);
                                    oCamposDet.COD_SECUENCIAL = dr.GetInt32(pt2);
                                    oCamposDet.ddlbfs_motivo_Id = dr.GetString(pt3);
                                    oCamposDet.ddlbfs_documentoId = dr.GetString(pt4);
                                    oCamposDet.txtbfs_num_documento = dr.GetString(pt5);
                                    oCamposDet.txtbfs_numero = dr.GetString(pt6);
                                    oCamposDet.txtbfs_femision = dr.GetString(pt7);
                                    oCamposDet.txtbfs_frecepcion = dr.GetString(pt8);
                                    oCamposDet.hdTipo = dr.GetString(pt9);
                                    oCamposDet.txtbfs_observacion = dr.GetString(pt10);
                                    oCamposDet.hdEstado = "0";

                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oCamposDet;
        }
        public CEntidad GetPlanManejoIdV3(OracleConnection cn, CEntidad oCEntidad)
        {
            CEntidad oCampos = new CEntidad();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.uspPLAN_MANEJO_GetIdV3", oCEntidad))
                {
                    if (dr != null)
                    {
                        oCampos.ListDependencia = new List<CEntidad>();
                        CEntidad oCamposDet;
                        if (dr.HasRows)
                        {
                            dr.Read();
                            oCampos.COD_PMANEJO = dr.GetString(dr.GetOrdinal("COD_PMANEJO"));
                            oCampos.FECHA_PRESENTACION = dr.GetString(dr.GetOrdinal("FECHA_PRESENTACION")).Trim();
                            oCampos.IS_DURACION_FINICIO = dr.GetString(dr.GetOrdinal("IS_DURACION_FINICIO")).Trim();
                            oCampos.IS_DURACION_FFIN = dr.GetString(dr.GetOrdinal("IS_DURACION_FFIN")).Trim();
                            //dr.GetDecimal(dr.GetOrdinal("AREA_OTORGADA"));
                            oCampos.TARA_AREA_PREDIO = dr.GetDecimal(dr.GetOrdinal("TARA_AREA_PREDIO"));
                            oCampos.TARA_AREA_MANEJO = dr.GetDecimal(dr.GetOrdinal("TARA_AREA_MANEJO"));
                            oCampos.CONSULTOR_CODIGO = dr.GetString(dr.GetOrdinal("CONSULTOR_CODIGO"));
                            oCampos.CONSULTOR_NUM_REGISTRO_FFS = dr.GetString(dr.GetOrdinal("CONSULTOR_NUM_REGISTRO_FFS"));
                            oCampos.CONSULTOR_NOMBRE = dr.GetString(dr.GetOrdinal("CONSULTOR_NOMBRE"));
                            oCampos.CONSULTOR_DNI = dr.GetString(dr.GetOrdinal("CONSULTOR_DNI"));
                            oCampos.CONSULTOR_NUM_REGISTRO_PROFESIONAL = dr.GetString(dr.GetOrdinal("CONSULTOR_NUM_REGISTRO_PROFESIONAL"));
                            oCampos.ITECNICO_IOCULAR_NUM = dr.GetString(dr.GetOrdinal("ITECNICO_IOCULAR_NUM"));
                            oCampos.ITECNICO_IOCULAR_FECHA = dr.GetString(dr.GetOrdinal("ITECNICO_IOCULAR_FECHA")).Trim();
                            oCampos.ITECNICO_RAPROBACION_NUM = dr.GetString(dr.GetOrdinal("ITECNICO_RAPROBACION_NUM"));
                            oCampos.ITECNICO_RAPROBACION_FECHA = dr.GetString(dr.GetOrdinal("ITECNICO_RAPROBACION_FECHA")).Trim();
                            oCampos.ARESOLUCION_NUM = dr.GetString(dr.GetOrdinal("ARESOLUCION_NUM"));
                            oCampos.ARESOLUCION_FECHA = dr.GetString(dr.GetOrdinal("ARESOLUCION_FECHA")).Trim();
                            oCampos.ARESOLUCION_COD_FUNCIONARIO = dr.GetString(dr.GetOrdinal("ARESOLUCION_COD_FUNCIONARIO"));
                            oCampos.ARESOLUCION_FUNCIONARIO_NOMBRE = dr.GetString(dr.GetOrdinal("ARESOLUCION_FUNCIONARIO_NOMBRE"));
                            oCampos.ARESOLUCION_FUNCIONARIO_ODATOS = dr.GetString(dr.GetOrdinal("ARESOLUCION_FUNCIONARIO_ODATOS"));
                            oCampos.ACORDE_TDR_VIGENTE = dr.GetBoolean(dr.GetOrdinal("ACORDE_TDR_VIGENTE"));
                            oCampos.OBSERVACION = dr.GetString(dr.GetOrdinal("OBSERVACION"));
                            oCampos.COD_THABILITANTE = dr.GetString(dr.GetOrdinal("COD_THABILITANTE"));
                            oCampos.COD_MTIPO = dr.GetString(dr.GetOrdinal("COD_MTIPO"));
                            oCampos.ESTADO_ORIGEN = dr.GetString(dr.GetOrdinal("ESTADO_ORIGEN"));
                            oCampos.INDICADOR = dr.GetString(dr.GetOrdinal("INDICADOR"));
                            oCampos.COD_DEPENDENCIA = dr.GetInt32(dr.GetOrdinal("COD_DEPENDENCIA")).ToString();
                            oCampos.DIRECCION_REGENTE = dr.GetString(dr.GetOrdinal("DIRECCION_REGENTE"));
                            oCampos.COD_UBIGEO_REGENTE = dr.GetString(dr.GetOrdinal("COD_UBIGEO_REGENTE"));
                            oCampos.UBIGEO_REGENTE = dr.GetString(dr.GetOrdinal("UBIGEO_REGENTE"));
                            //
                            //Tara
                            //oCampos.NUM_ARBOLES_EDAD_APRO = dr.GetInt32(dr.GetOrdinal("NUM_ARBOLES_EDAD_APRO"));
                            //oCampos.NUM_ARBOLES_NOEDAD_APRO = dr.GetInt32(dr.GetOrdinal("NUM_ARBOLES_NOEDAD_APRO"));
                            //oCampos.PESO_ARBOLES_EDAD_APRO = Decimal.Parse(dr.GetString(dr.GetOrdinal("PESO_ARBOLES_EDAD_APRO")));
                            oCampos.ACTIVIDAD_CAPACITACION = dr.GetString(dr.GetOrdinal("ACTIVIDAD_CAPACITACION"));
                            oCampos.MODALIDAD_COMERCIALIZACION = dr.GetString(dr.GetOrdinal("MODALIDAD_COMERCIALIZACION"));
                            oCampos.ANO_EPLANTACION = dr.GetInt32(dr.GetOrdinal("ANO_EPLANTACION"));
                            oCampos.NUM_PCOMPLEMENTARIO = dr.GetString(dr.GetOrdinal("NUM_PCOMPLEMENTARIO"));
                            oCampos.APROB_ACTIVIDAD_ESTADO = dr.GetBoolean(dr.GetOrdinal("APROB_ACTIVIDAD_ESTADO"));
                            oCampos.APROB_ACTIVIDAD_FECHA = dr.GetString(dr.GetOrdinal("APROB_ACTIVIDAD_FECHA")).Trim();
                            oCampos.APROB_ACTIVIDAD_AUTORIDAD = dr.GetString(dr.GetOrdinal("APROB_ACTIVIDAD_AUTORIDAD"));
                            oCampos.APROB_ACTIVIDAD_RESOLUCION = dr.GetString(dr.GetOrdinal("APROB_ACTIVIDAD_RESOLUCION"));
                            oCampos.APROB_ACTIVIDAD_FUNCIONARIO = dr.GetString(dr.GetOrdinal("APROB_ACTIVIDAD_FUNCIONARIO"));
                            oCampos.FUNCIONARIO_APROB_ACTIVIDAD = dr.GetString(dr.GetOrdinal("FUNCIONARIO_APROB_ACTIVIDAD"));
                            oCampos.COD_OD_REGISTRO = dr.GetString(dr.GetOrdinal("COD_OD_REGISTRO"));
                            oCampos.USUARIO_REGISTRO = dr.GetString(dr.GetOrdinal("USUARIO_REGISTRO"));
                            oCampos.MODALIDAD = dr.GetString(dr.GetOrdinal("MODALIDAD"));
                            oCampos.NUM_THABILITANTE = dr.GetString(dr.GetOrdinal("NUM_THABILITANTE"));
                            oCampos.PERSONA_TITULAR = dr.GetString(dr.GetOrdinal("PERSONA_TITULAR"));
                            oCampos.REGENTE_NUM_REGISTRO_FFS = dr.GetString(dr.GetOrdinal("REGENTE_NUM_REGISTRO_FFS"));
                        }
                        //Estado (Calidad)
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
                    }
                }
                return oCampos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public virtual List<Dictionary<string, string>> CreateList(OracleDataReader reader, string[] campos)
        {
            var results = new List<Dictionary<string, string>>();
            var properties = typeof(Dictionary<string, string>).GetProperties();

            while (reader.Read())
            {
                var item = new Dictionary<string, string>();
                foreach (string text in campos)
                {
                    Type ss = reader[text].GetType();
                    item.Add(text, reader[text].ToString());
                }
                item.Add("RegEstado", "0");
                results.Add(item);
            }
            return results;
        }
        public VM_PlanManejoList GetPlanManejoListIdV3(OracleConnection cn, CEntidad oCEntidad)
        {
            VM_PlanManejoList oCampos = new VM_PlanManejoList();
            try
            {
                CEntidad oCe = new CEntidad();
                oCe.COD_PMANEJO = oCEntidad.COD_PMANEJO;
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.uspPLAN_MANEJO_GetListIdV3", oCe))
                {
                    if (dr != null)
                    {
                        oCampos.ListPMDTTIOCULAR = new List<Dictionary<string, string>>();
                        oCampos.ListPMDTTRAPROBACION = new List<Dictionary<string, string>>();
                        oCampos.ListPMDISITUCAREA = new List<Dictionary<string, string>>();
                        oCampos.ListPMDISITUFAUNA = new List<Dictionary<string, string>>();
                        oCampos.ListPMDISITUFLORA = new List<Dictionary<string, string>>();
                        //TARA
                        oCampos.ListPMTDOOPCIONESEAPROVE = new List<Dictionary<string, string>>();
                        oCampos.ListPMTDOOPCIONESPSILVI = new List<Dictionary<string, string>>();
                        oCampos.ListPMTDPPAPROVECHAMIENTO = new List<Dictionary<string, string>>();
                        //   oCampos.ListPMTBEXTRACCION = new List<Dictionary<string, string>>();
                        oCampos.ListPMTINVENTARIO = new List<Dictionary<string, string>>();

                        oCampos.ListPMTCOORDENADAUTM = new List<Dictionary<string, string>>();
                        oCampos.ListPMTAAPROVECHAMIENTO = new List<Dictionary<string, string>>();
                        oCampos.ListPMTAUTORIZADAEXTRA = new List<Dictionary<string, string>>();
                        oCampos.ListPMINFORME_ANUAL = new List<Dictionary<string, string>>();
                        oCampos.ListPMECOTPROGIMPLEMENTAR = new List<Dictionary<string, string>>();

                        //Error Material
                        oCampos.ListPMErrorMaterialG = new List<Dictionary<string, string>>();
                        oCampos.ListPMErrorMaterialA = new List<Dictionary<string, string>>();

                        //Dictionary<string, string> oCamposDet;
                        string[] columns;
                        //PLAN_MANEJO_DET_TIOCULAR
                        if (dr.HasRows)
                        {
                            columns = new string[] { "COD_PERSONA", "PERSONA", "N_DOCUMENTO", "CARGO" };
                            oCampos.ListPMDTTIOCULAR = this.CreateList(dr, columns);
                        }
                        //PLAN_MANEJO_DET_TRAPROBACION
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            columns = new string[] { "COD_PERSONA", "PERSONA", "N_DOCUMENTO", "CARGO" };
                            oCampos.ListPMDTTRAPROBACION = this.CreateList(dr, columns);
                        }
                        //PLAN_MANEJO_INSITU_DET_CAREA
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            columns = new string[] { "COD_CAREA", "DESCRIPCION" };
                            oCampos.ListPMDISITUCAREA = this.CreateList(dr, columns);
                        }
                        //PLAN_MANEJO_INSITU_DET_INV_FAUNA
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            columns = new string[] { "COD_ESPECIES", "COD_SECUENCIAL", "ESPECIES", "OBSERVACION" };
                            oCampos.ListPMDISITUFAUNA = this.CreateList(dr, columns);
                        }
                        //PLAN_MANEJO_INSITU_DET_INV_FLORA
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            columns = new string[] { "COD_ESPECIES", "COD_SECUENCIAL", "ESPECIES", "CARACTERISTICAS",
                                                    "RASOCIACIONES_FAUNA","OBSERVACION"};
                            oCampos.ListPMDISITUFLORA = this.CreateList(dr, columns);
                        }
                        //PLAN_MANEJO_TARA_DET_PAPROVECHAMIENTO
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            columns = new string[] { "COD_SECUENCIAL", "ANO", "NUM_ARBOLES", "PESO_VAINAS",
                                                    "NUM_COSECHA","NUM_QUINTALES","OBSERVACION"};
                            oCampos.ListPMTDPPAPROVECHAMIENTO = this.CreateList(dr, columns);
                        }
                        //PLAN_MANEJO_TARA_DET_OPCIONES
                        List<CEntidad> ListPMTDOOPCIONES = new List<CEntidad>();
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("COD_PMTOPCIONES");
                            int pt2 = dr.GetOrdinal("OBSERVACION");
                            int pt3 = dr.GetOrdinal("DESCRIPCION");
                            int pt4 = dr.GetOrdinal("TIPO");
                            int pt5 = dr.GetOrdinal("COD_SECUENCIAL");
                            Dictionary<string, string> detalle;
                            string tipoOP = "";
                            while (dr.Read())
                            {
                                detalle = new Dictionary<string, string>();
                                detalle.Add("COD_PMTOPCIONES", dr.GetString(pt1));
                                detalle.Add("OBSERVACION", dr.GetString(pt2));
                                detalle.Add("DESCRIPCION", dr.GetString(pt3));
                                detalle.Add("TIPO", dr.GetString(pt4));
                                detalle.Add("COD_SECUENCIAL", dr.GetInt32(pt5).ToString());
                                detalle.Add("RegEstado", "0");
                                tipoOP = dr.GetString(pt4);
                                switch (tipoOP)
                                {
                                    case "SA": oCampos.ListPMTDOOPCIONESEAPROVE.Add(detalle); break;
                                    case "PS": oCampos.ListPMTDOOPCIONESPSILVI.Add(detalle); break;
                                    case "PI":
                                    case "CS": oCampos.ListPMECOTPROGIMPLEMENTAR.Add(detalle); break;
                                }

                            }
                        }
                        //PLAN_MANEJO_TARA_DET_COORDENADAUTM
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            columns = new string[] { "COD_SECUENCIAL", "NUM_PARCELA", "NUM_PUNTOS", "COORDENADA_ESTE",
                                                    "COORDENADA_NORTE","OBSERVACION"};
                            oCampos.ListPMTCOORDENADAUTM = this.CreateList(dr, columns);
                        }
                        //PLAN_MANEJO_TARA_DET_AAPROVECHAMIENTO
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            columns = new string[] { "COD_SECUENCIAL", "NUM_PARCELA", "NUM_ARBOLES_APROVE", "NUM_ARBOLES_NO_APROVE",
                                                    "PRODUCCION_ANUAL_PROMEDIO","PESO_ESTIMADO_VAINAS"};
                            oCampos.ListPMTAAPROVECHAMIENTO = this.CreateList(dr, columns);
                        }
                        //PLAN_MANEJO_TARA_DET_CAUTO_EXTRAER
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            columns = new string[] { "COD_SECUENCIAL", "COD_ESPECIES", "ESPCIES", "SUPERFICIE_HA",
                                                    "TOTAL_PGMF","ANO_1","ANO_2","ANO_3","ANO_4","ANO_5",
                                                     "DERECHO_APROVE_QUINTAL","DERECHO_APROVE_QTOTAL","OBSERVACION"};
                            oCampos.ListPMTAUTORIZADAEXTRA = this.CreateList(dr, columns);
                        }
                        //PLAN_MANEJO_TARA_DET_INVENTARIO
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            columns = new string[] { "COD_SECUENCIAL", "N_ARBOL", "CONDICION", "ESTADO_FITOSAN",
                                                    "ALTURA_ESTIMADO","PESO_VAINAS_KILOGRAMOS","COORDENADA_ESTE",
                                                     "COORDENADA_NORTE","OBSERVACION"};
                            oCampos.ListPMTINVENTARIO = this.CreateList(dr, columns);
                        }
                        //PLAN_MANEJO_EXSITU_DET_IANUAL
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            columns = new string[] { "COD_SECUENCIAL", "ANO_EJECUTADO", "FECHA_EMISION", "PROFESIONAL_CODIGO",
                                                    "PROFESIONAL_NUM_REGISTRO_FFS","PROFESIONAL_NOMBRE","PROFESIONAL_DNI",
                                                     "PROFESIONAL_NUM_REGISTRO_PROFESIONAL","ACORDE_TDR_VIGENTE",
                                                    "PRINCIPAL_ACCION_DESARROLLA","OBSERVACION"};
                            oCampos.ListPMINFORME_ANUAL = this.CreateList(dr, columns);
                        }
                        //Error Material
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            columns = new string[] { "COD_SECUENCIAL", "DA_FECRESOLUCION", "NV_RESOLUCION", "NV_NOMCAMPO", "NV_VALANTERIOR", "NV_VALACTUAL", "NV_OBSERVACION" };
                            oCampos.ListPMErrorMaterialG = this.CreateList(dr, columns);
                        }

                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            columns = new string[] { "COD_SECUENCIAL", "DA_FECRESOLUCION", "NV_RESOLUCION", "NV_NOMCAMPO", "NV_VALANTERIOR", "NV_VALACTUAL", "NV_OBSERVACION" };
                            oCampos.ListPMErrorMaterialA = this.CreateList(dr, columns);
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
        public Tuple<List<Dictionary<string, string>>, List<Dictionary<string, string>>> PLAN_MANEJO_EXSITU_PGENETICO_MostItemV3(OracleConnection cn, CEntidad oCEntidad)
        {

            try
            {
                string[] columns;
                List<Dictionary<string, string>> ListPGENETICO_FEXSITU_DET_ESPECIE = new List<Dictionary<string, string>>();
                List<Dictionary<string, string>> ListPGENETICO_FEXSITU_PGENTICO_INFORME = new List<Dictionary<string, string>>();
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.PLAN_MANEJO_EXSITU_PGENETICO_MostItem", oCEntidad))
                {
                    if (dr != null)
                    {

                        //
                        //PLAN_MANEJO_EXSITU_DET_IANUAL
                        if (dr.HasRows)
                        {

                            columns = new string[] { "COD_SECUENCIAL", "COD_ESPECIES", "ESPECIES", "COD_GACATEGORIA", "DESC_GACATEGORIA" ,
                                                    "CANTIDAD_OTORGADA","CANTIDAD_AUTORIZADA_CAPTURA","NUM_MACHO","NUM_HEMBRAS","OBSERVACION"};
                            ListPGENETICO_FEXSITU_DET_ESPECIE = this.CreateList(dr, columns);
                        }
                        // EXSITU PLAN GENETICO
                        dr.NextResult();
                        if (dr.HasRows)
                        {

                            columns = new string[] { "COD_SECUENCIAL", "COD_ESPECIES" , "ESPECIES", "NUM_INFORME" , "FECHA_EMISION", "ZONA_CAPTURA",
                                                    "NUM_MACHO","NUM_HEMBRAS","OBSERVACION"};
                            ListPGENETICO_FEXSITU_PGENTICO_INFORME = this.CreateList(dr, columns);
                        }
                    }
                }
                return Tuple.Create(ListPGENETICO_FEXSITU_DET_ESPECIE, ListPGENETICO_FEXSITU_PGENTICO_INFORME);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public String RegGrabarV3(OracleConnection cn, CEntidad oCEntidad, OracleTransaction tr)
        {
            String OUTPUTPARAM01 = "";
            CEntidad oCamposDet;
            try
            {
                //Grabando Cabecera
                using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.uspPLAN_MANEJOGrabarV3", oCEntidad))
                {
                    cmd.ExecuteNonQuery();
                    OUTPUTPARAM01 = (String)cmd.Parameters["OUTPUTPARAM01"].Value;
                    if (OUTPUTPARAM01 == "99")
                    {
                        throw new Exception("Ud. no tiene permiso para realizar esta acción");
                    }
                    if (OUTPUTPARAM01 == "0")
                    {
                        throw new Exception("El Número de Resolución para este Plan de Manejo ya Existe");
                    }
                    else if (OUTPUTPARAM01 == "1")
                    {
                        throw new Exception("El Número de Resolución ya Existe en Otro Plan de Manejo");
                    }
                    else if (OUTPUTPARAM01 == "2")
                    {
                        throw new Exception("No Tiene Permisos para Modificar este Plan de Manejo");
                    }
                    else if (OUTPUTPARAM01 == "3")
                    {
                        throw new Exception("Está con Control de Calidad, no puede modificar");
                    }
                    oCEntidad.COD_PMANEJO = OUTPUTPARAM01;
                }
                //
                //Eliminando Detalle
                if (oCEntidad.ListEliTABLA != null)
                {
                    foreach (var loDatos in oCEntidad.ListEliTABLA)
                    {
                        oCamposDet = new CEntidad();
                        oCamposDet.COD_PMANEJO = oCEntidad.COD_PMANEJO;
                        oCamposDet.EliTABLA = loDatos.EliTABLA;
                        oCamposDet.EliVALOR01 = loDatos.EliVALOR01;
                        oCamposDet.EliVALOR02 = loDatos.EliVALOR02;
                        dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spPLAN_MANEJOEliminarDetalle", oCamposDet);
                    }
                }
                //
                //Grabando Detalle PLAN_MANEJO_DET_TIOCULAR
                if (oCEntidad.ListPMDTTIOCULAR != null)
                {
                    foreach (var loDatos in oCEntidad.ListPMDTTIOCULAR)
                    {
                        if (loDatos.RegEstado == 1) //Nuevo o Modificado
                        {
                            oCamposDet = new CEntidad();
                            oCamposDet.COD_PMANEJO = oCEntidad.COD_PMANEJO;
                            oCamposDet.COD_TIOCULAR = loDatos.COD_PERSONA;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spPLAN_MANEJO_DET_TIOCULARGrabar", oCamposDet);
                        }
                    }
                }
                //Grabando Detalle PLAN_MANEJO_DET_TRAPROBACION
                if (oCEntidad.ListPMDTTRAPROBACION != null)
                {
                    foreach (var loDatos in oCEntidad.ListPMDTTRAPROBACION)
                    {
                        if (loDatos.RegEstado == 1) //Nuevo o Modificado
                        {
                            oCamposDet = new CEntidad();
                            oCamposDet.COD_PMANEJO = oCEntidad.COD_PMANEJO;
                            oCamposDet.COD_TRAPROBACION = loDatos.COD_PERSONA;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spPLAN_MANEJO_DET_TRAPROBACIONGrabar", oCamposDet);
                        }
                    }
                }
                //Grabando Detalle PLAN_MANEJO_INSITU_DET_CAREA
                if (oCEntidad.ListPMDISITUCAREA != null)
                {
                    foreach (var loDatos in oCEntidad.ListPMDISITUCAREA)
                    {
                        if (loDatos.RegEstado == 1) //Nuevo o Modificado
                        {
                            oCamposDet = new CEntidad();
                            oCamposDet.COD_PMANEJO = oCEntidad.COD_PMANEJO;
                            oCamposDet.COD_CAREA = loDatos.COD_CAREA;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spPLAN_MANEJO_INSITU_DET_CAREAGrabar", oCamposDet);
                        }
                    }
                }
                //Grabando Detalle PLAN_MANEJO_INSITU_DET_INV_FAUNA
                if (oCEntidad.ListPMDISITUFAUNA != null)
                {
                    foreach (var loDatos in oCEntidad.ListPMDISITUFAUNA)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            oCamposDet = new CEntidad();
                            oCamposDet.COD_PMANEJO = oCEntidad.COD_PMANEJO;
                            oCamposDet.COD_ESPECIES = loDatos.COD_ESPECIES;
                            oCamposDet.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            oCamposDet.OBSERVACION = loDatos.OBSERVACION == null ? "" : loDatos.OBSERVACION;
                            oCamposDet.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spPLAN_MANEJO_INSITU_DET_INV_FAUNAGrabar", oCamposDet);
                        }
                    }
                }
                //Grabando Detalle PLAN_MANEJO_INSITU_DET_INV_FLORA
                if (oCEntidad.ListPMDISITUFLORA != null)
                {
                    foreach (var loDatos in oCEntidad.ListPMDISITUFLORA)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            oCamposDet = new CEntidad();
                            oCamposDet.COD_PMANEJO = oCEntidad.COD_PMANEJO;
                            oCamposDet.COD_ESPECIES = loDatos.COD_ESPECIES;
                            oCamposDet.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            oCamposDet.CARACTERISTICAS = loDatos.CARACTERISTICAS == null ? "" : loDatos.CARACTERISTICAS;
                            oCamposDet.RASOCIACIONES_FAUNA = loDatos.RASOCIACIONES_FAUNA == null ? "" : loDatos.RASOCIACIONES_FAUNA;
                            oCamposDet.OBSERVACION = loDatos.OBSERVACION == null ? "" : loDatos.OBSERVACION;
                            oCamposDet.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spPLAN_MANEJO_INSITU_DET_INV_FLORAGrabar", oCamposDet);
                        }
                    }
                }
                //PLAN_MANEJO_TARA_DET_PAPROVECHAMIENTO
                if (oCEntidad.ListPMTDPPAPROVECHAMIENTO != null)
                {
                    foreach (var loDatos in oCEntidad.ListPMTDPPAPROVECHAMIENTO)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            oCamposDet = new CEntidad();
                            oCamposDet.COD_PMANEJO = oCEntidad.COD_PMANEJO;
                            oCamposDet.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            oCamposDet.ANO = loDatos.ANO;
                            oCamposDet.NUM_ARBOLES = loDatos.NUM_ARBOLES;
                            oCamposDet.PESO_VAINAS = loDatos.PESO_VAINAS;
                            oCamposDet.NUM_COSECHA = loDatos.NUM_COSECHA;
                            oCamposDet.NUM_QUINTALES = loDatos.NUM_QUINTALES;
                            oCamposDet.OBSERVACION = loDatos.OBSERVACION == null ? "" : loDatos.OBSERVACION;
                            oCamposDet.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spPLAN_MANEJO_TARA_DET_PAPROVECHAMIENTOGrabar", oCamposDet);
                        }
                    }
                }
                //PLAN_MANEJO_TARA_DET_OPCIONES Aprovechamiento
                if (oCEntidad.ListPMTDOOPCIONESEAPROVE != null)
                {
                    foreach (var loDatos in oCEntidad.ListPMTDOOPCIONESEAPROVE)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            oCamposDet = new CEntidad();
                            oCamposDet.COD_PMANEJO = oCEntidad.COD_PMANEJO;
                            oCamposDet.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            oCamposDet.COD_PMTOPCIONES = loDatos.COD_PMTOPCIONES;
                            oCamposDet.OBSERVACION = loDatos.OBSERVACION == null ? "" : loDatos.OBSERVACION;
                            oCamposDet.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spPLAN_MANEJO_TARA_DET_OPCIONESGrabar", oCamposDet);
                        }
                    }
                }
                //PLAN_MANEJO_TARA_DET_OPCIONES Silviculturales
                if (oCEntidad.ListPMTDOOPCIONESPSILVI != null)
                {
                    foreach (var loDatos in oCEntidad.ListPMTDOOPCIONESPSILVI)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            oCamposDet = new CEntidad();
                            oCamposDet.COD_PMANEJO = oCEntidad.COD_PMANEJO;
                            oCamposDet.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            oCamposDet.COD_PMTOPCIONES = loDatos.COD_PMTOPCIONES;
                            oCamposDet.OBSERVACION = loDatos.OBSERVACION == null ? "" : loDatos.OBSERVACION;
                            oCamposDet.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spPLAN_MANEJO_TARA_DET_OPCIONESGrabar", oCamposDet);
                        }
                    }
                }
                // PLAN_MANEJO_TARA_DET_COORDENADAUTM
                if (oCEntidad.ListPMTCOORDENADAUTM != null)
                {
                    foreach (var loDatos in oCEntidad.ListPMTCOORDENADAUTM)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            oCamposDet = new CEntidad();
                            oCamposDet.COD_PMANEJO = oCEntidad.COD_PMANEJO;
                            oCamposDet.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            oCamposDet.NUM_PARCELA = loDatos.NUM_PARCELA;
                            oCamposDet.NUM_PUNTOS = loDatos.NUM_PUNTOS;
                            oCamposDet.COORDENADA_ESTE = loDatos.COORDENADA_ESTE;
                            oCamposDet.COORDENADA_NORTE = loDatos.COORDENADA_NORTE;
                            oCamposDet.OBSERVACION = loDatos.OBSERVACION == null ? "" : loDatos.OBSERVACION;
                            oCamposDet.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spPLAN_MANEJO_TARA_DET_COORDENADAUTMGrabar", oCamposDet);
                        }
                    }
                }
                // PLAN_MANEJO_TARA_DET_AAPROVECHAMIENTO
                if (oCEntidad.ListPMTAAPROVECHAMIENTO != null)
                {
                    foreach (var loDatos in oCEntidad.ListPMTAAPROVECHAMIENTO)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            oCamposDet = new CEntidad();
                            oCamposDet.COD_PMANEJO = oCEntidad.COD_PMANEJO;
                            oCamposDet.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            oCamposDet.NUM_PARCELA = loDatos.NUM_PARCELA;
                            oCamposDet.NUM_ARBOLES_APROVE = loDatos.NUM_ARBOLES_APROVE;
                            oCamposDet.NUM_ARBOLES_NO_APROVE = loDatos.NUM_ARBOLES_NO_APROVE;
                            oCamposDet.PRODUCCION_ANUAL_PROMEDIO = loDatos.PRODUCCION_ANUAL_PROMEDIO;
                            oCamposDet.PESO_ESTIMADO_VAINAS = loDatos.PESO_ESTIMADO_VAINAS;
                            oCamposDet.OBSERVACION = loDatos.OBSERVACION == null ? "" : loDatos.OBSERVACION;
                            oCamposDet.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spPLAN_MANEJO_TARA_DET_AAPROVECHAMIENTOGrabar", oCamposDet);
                        }
                    }
                }
                // PLAN_MANEJO_TARA_DET_AAPROVECHAMIENTO
                if (oCEntidad.ListPMTAUTORIZADAEXTRA != null)
                {
                    foreach (var loDatos in oCEntidad.ListPMTAUTORIZADAEXTRA)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            oCamposDet = new CEntidad();
                            oCamposDet.COD_PMANEJO = oCEntidad.COD_PMANEJO;
                            oCamposDet.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            oCamposDet.COD_ESPECIES = loDatos.COD_ESPECIES;
                            oCamposDet.SUPERFICIE_HA = loDatos.SUPERFICIE_HA;
                            oCamposDet.TOTAL_PGMF = loDatos.TOTAL_PGMF;
                            oCamposDet.ANO_1 = loDatos.ANO_1;
                            oCamposDet.ANO_2 = loDatos.ANO_2;
                            oCamposDet.ANO_3 = loDatos.ANO_3;
                            oCamposDet.ANO_4 = loDatos.ANO_4;
                            oCamposDet.ANO_5 = loDatos.ANO_5;
                            oCamposDet.DERECHO_APROVE_QUINTAL = loDatos.DERECHO_APROVE_QUINTAL;
                            oCamposDet.DERECHO_APROVE_QTOTAL = loDatos.DERECHO_APROVE_QTOTAL;
                            oCamposDet.OBSERVACION = loDatos.OBSERVACION == null ? "" : loDatos.OBSERVACION;
                            oCamposDet.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spPLAN_MANEJO_TARA_DET_CAUTO_EXTRAERGrabar", oCamposDet);
                        }
                    }
                }
                //PLAN_MANEJO_TARA_DET_BEXTRACCION
                //if (oCEntidad.ListPMTBEXTRACCION != null)
                //{
                //    foreach (var loDatos in oCEntidad.ListPMTBEXTRACCION)
                //    {
                //        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                //        {
                //            oCamposDet = new CEntidad();
                //            oCamposDet.COD_PMANEJO = oCEntidad.COD_PMANEJO;
                //            oCamposDet.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                //            oCamposDet.NUM_GTRANSPORTE = loDatos.NUM_GTRANSPORTE;
                //            oCamposDet.AUTORIZADO_CANTIDAD = loDatos.AUTORIZADO_CANTIDAD;
                //            oCamposDet.APROVECHADO_KILOGRAMOS = loDatos.APROVECHADO_KILOGRAMOS;
                //            oCamposDet.APROVECHADO_CANTIDAD = loDatos.APROVECHADO_CANTIDAD;
                //            oCamposDet.SALDO = loDatos.SALDO;
                //            oCamposDet.OBSERVACION = loDatos.OBSERVACION;
                //            oCamposDet.RegEstado = loDatos.RegEstado;
                //            oGDataSQL.ManExecute(cn, tr, "DOC.spPLAN_MANEJO_TARA_DET_BEXTRACCIONGrabar", oCamposDet);
                //        }
                //    }
                //}
                //PLAN_MANEJO_TARA_DET_INVENTARIO
                if (oCEntidad.ListPMTINVENTARIO != null)
                {
                    foreach (var loDatos in oCEntidad.ListPMTINVENTARIO)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            oCamposDet = new CEntidad();
                            oCamposDet.COD_PMANEJO = oCEntidad.COD_PMANEJO;
                            oCamposDet.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            oCamposDet.N_ARBOL = loDatos.N_ARBOL;
                            oCamposDet.CONDICION = loDatos.CONDICION;
                            oCamposDet.ESTADO_FITOSAN = loDatos.ESTADO_FITOSAN;
                            oCamposDet.ALTURA_ESTIMADO = loDatos.ALTURA_ESTIMADO;
                            oCamposDet.PESO_VAINAS_KILOGRAMOS = loDatos.PESO_VAINAS_KILOGRAMOS;
                            oCamposDet.COORDENADA_ESTE = loDatos.COORDENADA_ESTE;
                            oCamposDet.COORDENADA_NORTE = loDatos.COORDENADA_NORTE;
                            oCamposDet.OBSERVACION = loDatos.OBSERVACION == null ? "" : loDatos.OBSERVACION;
                            oCamposDet.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spPLAN_MANEJO_TARA_DET_INVENTARIOGrabar", oCamposDet);
                        }
                    }
                }
                //PLAN_MANEJO_EXSITU_DET_IANUAL
                if (oCEntidad.ListPMINFORME_ANUAL != null)
                {
                    foreach (var loDatos in oCEntidad.ListPMINFORME_ANUAL)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            oCamposDet = new CEntidad();
                            oCamposDet.COD_PMANEJO = oCEntidad.COD_PMANEJO;
                            oCamposDet.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            oCamposDet.COD_UCUENTA = oCEntidad.COD_UCUENTA;
                            oCamposDet.ANO_EJECUTADO = loDatos.ANO_EJECUTADO;
                            oCamposDet.FECHA_EMISION = loDatos.FECHA_EMISION;
                            oCamposDet.PROFESIONAL_CODIGO = loDatos.PROFESIONAL_CODIGO;
                            oCamposDet.PROFESIONAL_NUM_REGISTRO_FFS = loDatos.PROFESIONAL_NUM_REGISTRO_FFS;
                            oCamposDet.ACORDE_TDR_VIGENTE = loDatos.ACORDE_TDR_VIGENTE;
                            oCamposDet.OBSERVACION = loDatos.OBSERVACION == null ? "" : loDatos.OBSERVACION;
                            oCamposDet.PRINCIPAL_ACCION_DESARROLLA = loDatos.PRINCIPAL_ACCION_DESARROLLA;
                            oCamposDet.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spPLAN_MANEJO_EXSITU_DET_IANUALGrabar", oCamposDet);
                        }
                    }
                }
                //PLAN_MANEJO_TARA_DET_OPCIONES Aprovechamiento
                if (oCEntidad.ListPMECOTPROGIMPLEMENTAR != null)
                {
                    foreach (var loDatos in oCEntidad.ListPMECOTPROGIMPLEMENTAR)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            oCamposDet = new CEntidad();
                            oCamposDet.COD_PMANEJO = oCEntidad.COD_PMANEJO;
                            oCamposDet.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            oCamposDet.COD_PMTOPCIONES = loDatos.COD_PMTOPCIONES;
                            oCamposDet.OBSERVACION = loDatos.OBSERVACION == null ? "" : loDatos.OBSERVACION;
                            oCamposDet.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spPLAN_MANEJO_TARA_DET_OPCIONESGrabar", oCamposDet);
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
                            oCampos.COD_PMANEJO = oCEntidad.COD_PMANEJO;
                            oCampos.NV_TIPO = loDatos.NV_TIPO;
                            oCampos.NV_RESOLUCION = loDatos.NV_RESOLUCION;
                            oCampos.DA_FECRESOLUCION = loDatos.DA_FECRESOLUCION;
                            oCampos.NV_NOMCAMPO = loDatos.NV_NOMCAMPO;
                            oCampos.NV_VALANTERIOR = loDatos.NV_VALANTERIOR;
                            oCampos.NV_VALACTUAL = loDatos.NV_VALACTUAL;
                            oCampos.NV_OBSERVACION = loDatos.NV_OBSERVACION;
                            oCampos.COD_UCUENTA = oCEntidad.COD_UCUENTA;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spPMANEJO_ERROR_MATERIAL_Grabar", oCampos);
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
                            oCampos.COD_PMANEJO = oCEntidad.COD_PMANEJO;
                            oCampos.NV_TIPO = loDatos.NV_TIPO;
                            oCampos.NV_RESOLUCION = loDatos.NV_RESOLUCION;
                            oCampos.DA_FECRESOLUCION = loDatos.DA_FECRESOLUCION;
                            oCampos.NV_NOMCAMPO = loDatos.NV_NOMCAMPO;
                            oCampos.NV_VALANTERIOR = loDatos.NV_VALANTERIOR;
                            oCampos.NV_VALACTUAL = loDatos.NV_VALACTUAL;
                            oCampos.NV_OBSERVACION = loDatos.NV_OBSERVACION;
                            oCampos.COD_UCUENTA = oCEntidad.COD_UCUENTA;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spPMANEJO_ERROR_MATERIAL_Grabar", oCampos);
                        }
                    }
                }

                //             
                return OUTPUTPARAM01;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string GetCodEspecie(OracleConnection cn, CEntidad oCEntidad)
        {
            string codEspecie="";
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC_OSINFOR_ERP_MIGRACION.uspEspecie_obtener", oCEntidad))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            dr.Read();
                            codEspecie = dr.GetString(dr.GetOrdinal("COD_ESPECIES"));
                        }
                    }
                }
                return codEspecie;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string GetCodAmenaza(OracleConnection cn, CEntidad oCEntidad)
        {
            string codAmenaza = "";
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC_OSINFOR_ERP_MIGRACION.uspGradoAmenaza_obtener", oCEntidad))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            dr.Read();
                            codAmenaza = dr.GetString(dr.GetOrdinal("COD_ACATEGORIA"));
                        }
                    }
                }
                return codAmenaza;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
