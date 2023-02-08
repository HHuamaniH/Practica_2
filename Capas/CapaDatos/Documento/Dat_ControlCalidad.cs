using GeneralSQL;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using CEntidad = CapaEntidad.DOC.Ent_ControlCalidad;
using SQL = GeneralSQL.Data.SQL;

namespace CapaDatos.DOC
{
    public class Dat_ControlCalidad
    {
        private SQL oGDataSQL = new SQL();
        private DBOracle dBOracle = new DBOracle();

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
                        oCampos.ListMComboTipoDocumento = new List<CEntidad>();
                        oCampos.ListDireccionLinea = new List<CEntidad>();
                        oCampos.ListDepartamento = new List<CEntidad>();

                        CEntidad oCamposDet;
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.CODIGO = dr.GetString(dr.GetOrdinal("CODIGO"));
                                oCamposDet.DESCRIPCION = dr.GetString(dr.GetOrdinal("DESCRIPCION"));
                                oCampos.ListMComboTipoDocumento.Add(oCamposDet);
                            }
                        }
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.CODIGO = dr.GetString(dr.GetOrdinal("CODIGO"));
                                oCamposDet.DESCRIPCION = dr.GetString(dr.GetOrdinal("DESCRIPCION"));
                                oCampos.ListDireccionLinea.Add(oCamposDet);
                            }
                        }
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.CODIGO = dr.GetString(dr.GetOrdinal("CODIGO"));
                                oCamposDet.DESCRIPCION = dr.GetString(dr.GetOrdinal("DESCRIPCION"));
                                oCampos.ListDepartamento.Add(oCamposDet);
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

        //public CEntidad RegMostrarControlCalidadResumen(SqlConnection cn, CEntidad oCEntidad)
        //{
        //    CEntidad oCampos = null;
        //    try
        //    {
        //        using (SqlDataReader dr = oGDataSQL.SelDrdDefault(cn, null, "DOC.spReporte_ControlCalidadXanio", oCEntidad))
        //        {
        //            if (dr != null)
        //            {
        //                oCampos = new CEntidad();
        //                oCampos.ListCCResumenGeneral = new List<CEntidad>();
        //                oCampos.ListCCResumenOD = new List<CEntidad>();

        //                CEntidad oCamposDet;

        //                if (dr.HasRows)
        //                {
        //                    while (dr.Read())
        //                    {
        //                        oCamposDet = new CEntidad();
        //                        oCamposDet.TD = dr.GetInt32(dr.GetOrdinal("TD"));
        //                        oCamposDet.PR = dr.GetInt32(dr.GetOrdinal("PR"));
        //                        oCamposDet.RC = dr.GetInt32(dr.GetOrdinal("RC"));
        //                        oCamposDet.PCC = dr.GetInt32(dr.GetOrdinal("PCC"));
        //                        oCamposDet.CCO = dr.GetInt32(dr.GetOrdinal("CCO"));
        //                        oCamposDet.CCO_SUBSANADO = dr.GetInt32(dr.GetOrdinal("CCO_SUBSANADO"));
        //                        oCamposDet.CCO_PENDIENTE = dr.GetInt32(dr.GetOrdinal("CCO_PENDIENTE"));
        //                        oCamposDet.CCC = dr.GetInt32(dr.GetOrdinal("CCC"));
        //                        oCampos.ListCCResumenGeneral.Add(oCamposDet);
        //                    }
        //                }

        //                dr.NextResult();
        //                if (dr.HasRows)
        //                {
        //                    while (dr.Read())
        //                    {
        //                        oCamposDet = new CEntidad();
        //                        oCamposDet.COD_OD = dr.GetString(dr.GetOrdinal("COD_OD"));
        //                        oCamposDet.OD = dr.GetString(dr.GetOrdinal("OD"));
        //                        oCamposDet.TD = dr.GetInt32(dr.GetOrdinal("TD"));
        //                        oCamposDet.PR = dr.GetInt32(dr.GetOrdinal("PR"));
        //                        oCamposDet.RC = dr.GetInt32(dr.GetOrdinal("RC"));
        //                        oCamposDet.PCC = dr.GetInt32(dr.GetOrdinal("PCC"));
        //                        oCamposDet.CCO = dr.GetInt32(dr.GetOrdinal("CCO"));
        //                        oCamposDet.CCO_SUBSANADO = dr.GetInt32(dr.GetOrdinal("CCO_SUBSANADO"));
        //                        oCamposDet.CCO_PENDIENTE = dr.GetInt32(dr.GetOrdinal("CCO_PENDIENTE"));
        //                        oCamposDet.CCC = dr.GetInt32(dr.GetOrdinal("CCC"));
        //                        oCampos.ListCCResumenOD.Add(oCamposDet);
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

        //public List<CEntidad> RegMostrarControlCalidadDetalle(SqlConnection cn, CEntidad oCEntidad)
        //{
        //    List<CEntidad> olCampos = new List<CEntidad>();
        //    try
        //    {
        //        using (SqlDataReader dr = oGDataSQL.SelDrdDefault(cn, null, "DOC.spReporte_ControlCalidadXanio", oCEntidad))
        //        {
        //            if (dr != null)
        //            {
        //                CEntidad oCamposDet;

        //                if (dr.HasRows)
        //                {
        //                    while (dr.Read())
        //                    {
        //                        oCamposDet = new CEntidad();
        //                        oCamposDet.OD = dr.GetString(dr.GetOrdinal("OD"));
        //                        oCamposDet.DOCUMENTO = dr.GetString(dr.GetOrdinal("DOCUMENTO"));
        //                        oCamposDet.FECHA_REGISTRO = dr.GetString(dr.GetOrdinal("FECHA_REGISTRO"));
        //                        oCamposDet.RESPONSABLE_REGISTRO = dr.GetString(dr.GetOrdinal("RESPONSABLE_REGISTRO"));
        //                        oCamposDet.ESTADO_DOCUMENTO = dr.GetString(dr.GetOrdinal("ESTADO_DOCUMENTO"));
        //                        oCamposDet.ESTADO_OBSERVACION = dr.GetString(dr.GetOrdinal("ESTADO_OBSERVACION"));
        //                        oCamposDet.COD_ESTADO_DOC = dr.GetString(dr.GetOrdinal("COD_ESTADO_DOC"));

        //                        if (oCamposDet.COD_ESTADO_DOC != "0000001")
        //                        {
        //                            oCamposDet.FECHA_CONTROL = dr.GetString(dr.GetOrdinal("FECHA_CONTROL"));
        //                            oCamposDet.RESPONSABLE_CONTROL = dr.GetString(dr.GetOrdinal("RESPONSABLE_CONTROL"));
        //                        }
        //                        else
        //                        {
        //                            oCamposDet.FECHA_CONTROL = "";
        //                            oCamposDet.RESPONSABLE_CONTROL = "";
        //                        }

        //                        if (oCEntidad.NOM_FORMULARIO == "POA" || oCEntidad.NOM_FORMULARIO == "RESOLUCION_DIRECTORAL")
        //                        {
        //                            oCamposDet.TIPO_DOCUMENTO = dr.GetString(dr.GetOrdinal("TIPO_DOCUMENTO"));
        //                        }
        //                        else
        //                        {
        //                            oCamposDet.TIPO_DOCUMENTO = "";
        //                        }

        //                        olCampos.Add(oCamposDet);
        //                    }
        //                }
        //            }
        //        }
        //        return olCampos;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
    }
}
