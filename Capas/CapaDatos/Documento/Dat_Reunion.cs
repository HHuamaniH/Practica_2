using GeneralSQL;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using CEntidad = CapaEntidad.DOC.Ent_Reunion;
using SQL = GeneralSQL.Data.SQL;

namespace CapaDatos.DOC
{
    public class Dat_Reunion
    {
        private SQL oGDataSQL = new SQL();
        private DBOracle dBOracle = new DBOracle();

        public CEntidad RegMostrarReunion(SqlConnection cn, CEntidad oCEntidad)
        {
            CEntidad oCampos = new CEntidad();
            CEntidad oCamposDet;
            try
            {
                using (SqlDataReader dr = oGDataSQL.SelDrdDefault(cn, null, "ACT.spREUNION_GetData", oCEntidad))
                {
                    if (dr != null)
                    {
                        oCampos.ListAgendaReunion = new List<CEntidad>();
                        oCampos.ListEliTABLA = new List<CEntidad>();
                        oCampos.ListParticipantes = new List<CEntidad>();
                        oCampos.ListParticipantesOtros = new List<CEntidad>();

                        if (dr.HasRows)
                        {
                            //Cabecera Reunión
                            dr.Read();
                            oCampos.COD_REUNION = dr.GetString(dr.GetOrdinal("COD_REUNION"));
                            oCampos.COD_UCUENTA = dr.GetString(dr.GetOrdinal("COD_UCUENTA"));
                            oCampos.DURACION_MIN = dr.GetInt32(dr.GetOrdinal("DURACION_MIN"));
                            oCampos.DURACION_DIA = dr.GetInt32(dr.GetOrdinal("DURACION_DIA"));
                            oCampos.EXTENSION_ARCH_PART = dr.GetString(dr.GetOrdinal("EXTENSION_ARCH_PART"));
                            oCampos.FECHA_INICIO = dr.GetDateTime(dr.GetOrdinal("FECHA_INICIO"));
                            oCampos.FECHA_FIN = dr.GetDateTime(dr.GetOrdinal("FECHA_FIN"));
                            oCampos.HORA_FIN = dr.GetString(dr.GetOrdinal("HORA_FIN"));
                            oCampos.HORA_INICIO = dr.GetString(dr.GetOrdinal("HORA_INICIO"));
                            oCampos.LUGAR = dr.GetString(dr.GetOrdinal("LUGAR"));
                            oCampos.NOMBRE_ARCH_PART = dr.GetString(dr.GetOrdinal("NOMBRE_ARCH_PART"));
                            oCampos.REF_CONVOCATORIA = dr.GetString(dr.GetOrdinal("REF_CONVOCATORIA"));
                            oCampos.ACUERDO = dr.GetString(dr.GetOrdinal("ACUERDO"));
                            oCampos.DESA_AGENDA = dr.GetString(dr.GetOrdinal("DESA_AGENDA"));

                            //Detalle Agenda Reunión
                            dr.NextResult();
                            if (dr.HasRows)
                            {
                                int pt1 = dr.GetOrdinal("COD_REUNION");
                                int pt2 = dr.GetOrdinal("COD_SECUENCIAL");
                                int pt3 = dr.GetOrdinal("ORDEN_AGENDA");
                                int pt4 = dr.GetOrdinal("DESCRIPCION");
                                //int pt5 = dr.GetOrdinal("COMENTARIO");
                                while (dr.Read())
                                {
                                    oCamposDet = new CEntidad();
                                    oCamposDet.COD_REUNION = dr.GetString(pt1);
                                    oCamposDet.COD_SECUENCIAL = dr.GetInt32(pt2);
                                    oCamposDet.ORDEN_AGENDA = dr.GetInt32(pt3);
                                    oCamposDet.DESCRIP_AGENDA = dr.GetString(pt4);
                                    //oCamposDet.COMENTARIO= dr.GetString(pt5);
                                    oCamposDet.RegEstado = 0;
                                    oCampos.ListAgendaReunion.Add(oCamposDet);
                                }
                            }
                            //Participantes de la Reunión
                            dr.NextResult();
                            if (dr.HasRows)
                            {
                                int pt1 = dr.GetOrdinal("COD_REUNION");
                                int pt2 = dr.GetOrdinal("COD_PERSONA");
                                int pt3 = dr.GetOrdinal("COD_INSTITUCION");
                                int pt4 = dr.GetOrdinal("CARGO");
                                int pt5 = dr.GetOrdinal("APELLIDOS_NOMBRES");
                                int pt6 = dr.GetOrdinal("N_DOCUMENTO");
                                int pt7 = dr.GetOrdinal("NOM_INSTITUCION");
                                int pt8 = dr.GetOrdinal("COD_SECUENCIAL");
                                while (dr.Read())
                                {
                                    oCamposDet = new CEntidad();
                                    oCamposDet.COD_REUNION = dr.GetString(pt1);
                                    oCamposDet.COD_PERSONA = dr.GetString(pt2);
                                    oCamposDet.COD_INSTITUCION = dr.GetString(pt3);
                                    oCamposDet.CARGO = dr.GetString(pt4);
                                    oCamposDet.APELLIDOS_NOMBRES = dr.GetString(pt5);
                                    oCamposDet.N_DOCUMENTO = dr.GetString(pt6);
                                    oCamposDet.NOM_INSTITUCION = dr.GetString(pt7);
                                    oCamposDet.COD_SECUENCIAL = dr.GetInt32(pt8);
                                    oCamposDet.RegEstado = 0;
                                    if (oCamposDet.COD_INSTITUCION == "00000013")
                                        oCampos.ListParticipantes.Add(oCamposDet);
                                    else oCampos.ListParticipantesOtros.Add(oCamposDet);
                                }
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

        //public CEntidad RegMostrarCombos(OracleConnection cn, CEntidad oCEntidad)
        //{
        //    CEntidad oCampos = null;
        //    try
        //    {
        //        using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spGeneral_Combo_Listar", oCEntidad))
        //        {
        //            if (dr != null)
        //            {
        //                oCampos = new CEntidad();
        //                List<CEntidad> lsDetDetalle;
        //                CEntidad oCamposDet;
        //                //Filtros de búsqueda
        //                lsDetDetalle = new List<CEntidad>();
        //                if (dr.HasRows)
        //                {
        //                    int pt1 = dr.GetOrdinal("CODIGO");
        //                    int pt2 = dr.GetOrdinal("DESCRIPCION");
        //                    while (dr.Read())
        //                    {
        //                        oCamposDet = new CEntidad();
        //                        oCamposDet.CODIGO = dr.GetString(pt1);
        //                        oCamposDet.DESCRIPCION = dr.GetString(pt2);
        //                        lsDetDetalle.Add(oCamposDet);
        //                    }
        //                }
        //                oCampos.ListFiltroBusqueda = lsDetDetalle;
        //                //Instituciones
        //                dr.NextResult();
        //                lsDetDetalle = new List<CEntidad>();
        //                if (dr.HasRows)
        //                {
        //                    int pt1 = dr.GetOrdinal("CODIGO");
        //                    int pt2 = dr.GetOrdinal("DESCRIPCION");
        //                    while (dr.Read())
        //                    {
        //                        oCamposDet = new CEntidad();
        //                        oCamposDet.CODIGO = dr.GetString(pt1);
        //                        oCamposDet.DESCRIPCION = dr.GetString(pt2);
        //                        lsDetDetalle.Add(oCamposDet);
        //                    }
        //                }
        //                oCampos.ListInstituciones = lsDetDetalle;

        //            }
        //        }
        //        return oCampos;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public String RegGrabar(SqlConnection cn, CEntidad oCEntidad)
        {
            SqlTransaction tr = null;
            String OUTPUTPARAM01 = "";
            CEntidad oCamposDet;
            try
            {
                tr = cn.BeginTransaction();
                //Grabando Cabecera
                using (SqlCommand cmd = oGDataSQL.ManExecuteOutput(cn, tr, "ACT.spREUNIONGrabar", oCEntidad))
                {
                    cmd.ExecuteNonQuery();
                    OUTPUTPARAM01 = (String)cmd.Parameters["@OUTPUTPARAM01"].Value;
                    switch (OUTPUTPARAM01)
                    {
                        case "99":
                            tr.Rollback();
                            tr = null;
                            throw new Exception("Ud. no tiene permiso para realizar esta acción");
                        case "0":
                            tr.Rollback();
                            tr = null;
                            throw new Exception("La Referencia de la convocatoria ya existe");
                        case "1":
                            tr.Rollback();
                            tr = null;
                            throw new Exception("La Referencia de la convocatoria ya existe");
                        default:
                            break;
                    }
                }
                //Reemplazando El Nuevo Codigo Creado
                if (oCEntidad.RegEstado == 1) //Nuevo
                {
                    oCEntidad.COD_REUNION = OUTPUTPARAM01;
                }
                if (oCEntidad.ListEliTABLA != null)
                {
                    foreach (var ptoAgenda in oCEntidad.ListEliTABLA)
                    {
                        oCamposDet = new CEntidad();
                        oCamposDet.COD_REUNION = oCEntidad.COD_REUNION;
                        oCamposDet.EliTABLA = ptoAgenda.EliTABLA;
                        oCamposDet.EliVALOR01 = ptoAgenda.EliVALOR01;
                        oCamposDet.EliVALOR02 = ptoAgenda.EliVALOR02;
                        oGDataSQL.ManExecute(cn, tr, "ACT.spREUNIONEliminarDetalle", oCamposDet);
                    }
                }
                //Grabando Agenda de la reunión
                if (oCEntidad.ListAgendaReunion != null)
                {
                    foreach (var ptoAgenda in oCEntidad.ListAgendaReunion)
                    {
                        oCamposDet = new CEntidad();
                        oCamposDet.COD_REUNION = oCEntidad.COD_REUNION;
                        oCamposDet.COD_SECUENCIAL = ptoAgenda.COD_SECUENCIAL;
                        oCamposDet.ORDEN_AGENDA = ptoAgenda.ORDEN_AGENDA;
                        oCamposDet.DESCRIP_AGENDA = ptoAgenda.DESCRIP_AGENDA;
                        //oCamposDet.COMENTARIO = ptoAgenda.COMENTARIO;
                        oCamposDet.COD_UCUENTA = oCEntidad.COD_UCUENTA;
                        oCamposDet.RegEstado = ptoAgenda.RegEstado;
                        oGDataSQL.ManExecute(cn, tr, "ACT.spREUNION_AGENDA_Grabar", oCamposDet);
                    }
                }
                //Grabando Participantes de la reunión
                if (oCEntidad.ListParticipantes != null)
                {
                    foreach (var partiReunion in oCEntidad.ListParticipantes)
                    {
                        oCamposDet = new CEntidad();
                        oCamposDet.COD_REUNION = oCEntidad.COD_REUNION;
                        oCamposDet.COD_PERSONA = partiReunion.COD_PERSONA;
                        oCamposDet.COD_INSTITUCION = partiReunion.COD_INSTITUCION;
                        oCamposDet.CARGO = partiReunion.CARGO;
                        oCamposDet.COD_SECUENCIAL = partiReunion.COD_SECUENCIAL;
                        oCamposDet.APELLIDOS_NOMBRES = partiReunion.APELLIDOS_NOMBRES;
                        oCamposDet.COD_UCUENTA = oCEntidad.COD_UCUENTA;
                        oCamposDet.RegEstado = partiReunion.RegEstado;
                        oGDataSQL.ManExecute(cn, tr, "ACT.spREUNION_PARTICIPANTES_Grabar", oCamposDet);
                    }
                }
                //Grabando Participantes de otras entidades
                if (oCEntidad.ListParticipantesOtros != null)
                {
                    foreach (var partiReunion in oCEntidad.ListParticipantesOtros)
                    {
                        oCamposDet = new CEntidad();
                        oCamposDet.COD_REUNION = oCEntidad.COD_REUNION;
                        oCamposDet.COD_PERSONA = partiReunion.COD_PERSONA;
                        oCamposDet.COD_INSTITUCION = partiReunion.COD_INSTITUCION;
                        oCamposDet.CARGO = partiReunion.CARGO;
                        oCamposDet.COD_SECUENCIAL = partiReunion.COD_SECUENCIAL;
                        oCamposDet.APELLIDOS_NOMBRES = partiReunion.APELLIDOS_NOMBRES;
                        oCamposDet.COD_UCUENTA = oCEntidad.COD_UCUENTA;
                        oCamposDet.RegEstado = partiReunion.RegEstado;
                        oGDataSQL.ManExecute(cn, tr, "ACT.spREUNION_PARTICIPANTES_Grabar", oCamposDet);
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
    }
}
