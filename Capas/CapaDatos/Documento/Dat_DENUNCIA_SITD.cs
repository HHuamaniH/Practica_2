using CapaEntidad.ViewModel.DOC;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using CEntidad = CapaEntidad.DOC.Ent_DENUNCIA_SITD;
using SQL = GeneralSQL.Data.SQL;

namespace CapaDatos.DOC
{
    public class Dat_DENUNCIA_SITD
    {
        private SQL oGDataSQL = new SQL();

        public List<CEntidad> RegMostrarGeneral(SqlConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> olCampos = new List<CEntidad>();
            try
            {
                using (SqlDataReader dr = oGDataSQL.SelDrdDefault(cn, null, "DOC.spGeneral_Listar", oCEntidad))
                {
                    if (dr != null)
                    {
                        CEntidad oCampo;

                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCampo = new CEntidad();
                                oCampo.COD_TRAMITE_SITD = dr.GetInt32(dr.GetOrdinal("COD_TRAMITE_SITD"));
                                oCampo.NUM_DREFERENCIA = dr.GetString(dr.GetOrdinal("NUM_DREFERENCIA"));
                                oCampo.FECHA_SITD = dr.GetString(dr.GetOrdinal("FECHA_SITD"));
                                oCampo.ESTADO_DREFERENCIA = dr.GetString(dr.GetOrdinal("ESTADO_DREFERENCIA"));
                                oCampo.OBSERVACION_TRANSFERENCIA = dr.GetString(dr.GetOrdinal("OBSERVACION_TRANSFERENCIA"));
                                oCampo.ASUNTO = dr.GetString(dr.GetOrdinal("ASUNTO"));
                                oCampo.PDF_TRAMITE_SITD = dr.GetString(dr.GetOrdinal("PDF_TRAMITE_SITD"));

                                olCampos.Add(oCampo);
                            }
                        }
                    }
                }

                return olCampos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void RegEliminarDetalle(SqlConnection cn, CEntidad oCEntidad)
        {
            SqlTransaction tr = null;

            try
            {
                tr = cn.BeginTransaction();
                //Grabando Cabecera
                using (SqlCommand cmd = oGDataSQL.ManExecuteOutput(cn, tr, "DOC.spDENUNCIA_SITDEliminarDetalle", oCEntidad))
                {
                    cmd.ExecuteNonQuery();
                }

                tr.Commit();
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
        #region "Sigo v3"
        public void RegEliminar(SqlConnection cn, CEntidad oCEntidad)
        {
            SqlTransaction tr = null;

            try
            {
                tr = cn.BeginTransaction();
                //Grabando Cabecera
                using (SqlCommand cmd = oGDataSQL.ManExecuteOutput(cn, tr, "DOC.uspDENUNCIA_SITDEliminarDetalle_V3", oCEntidad))
                {
                    cmd.ExecuteNonQuery();
                }

                tr.Commit();
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
        public VM_DENUNCIA_SITD RegMostrarListaItems_V3(SqlConnection cn, int tramiteId)
        {
            VM_DENUNCIA_SITD oCampo = new VM_DENUNCIA_SITD();

            try
            {
                using (SqlDataReader dr = oGDataSQL.SelDrdDefault(cn, "DOC.uspDENUNCIA_SITDMostrarItems_V3", tramiteId))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            if (dr.Read())
                            {
                                oCampo.cod_Tramite_Id = dr.GetInt32(dr.GetOrdinal("COD_TRAMITE_SITD"));
                                oCampo.nro_Referencia = dr.GetString(dr.GetOrdinal("NUM_DREFERENCIA"));
                                oCampo.asunto = dr.GetString(dr.GetOrdinal("ASUNTO")).Trim();
                                oCampo.obs = dr.GetString(dr.GetOrdinal("OBSERVACION_TRANSFERENCIA")).Trim();

                                oCampo.cboSectorF = dr.GetString(dr.GetOrdinal("PERTENECE_SECTOR_FORESTAL"));
                                oCampo.transAreaOS = dr.GetString(dr.GetOrdinal("CORRESPONDE_AREA_OSINFOR"));
                                oCampo.cboCompetencia = dr.GetString(dr.GetOrdinal("COMPETENCIA_OSINFOR"));
                                oCampo.chkTransTrasladarOE = dr.GetBoolean(dr.GetOrdinal("TRASLADAR_OTRA_ENTIDAD"));
                                oCampo.descTransTrasladarOE = dr.GetString(dr.GetOrdinal("DESCRIPCION_OTRA_ENTIDAD"));
                                oCampo.chkDisponeET = dr.GetBoolean(dr.GetOrdinal("DISPONE_ITECNICO"));
                                oCampo.cod_Prof_Tecnico = dr.GetString(dr.GetOrdinal("COD_PROFESIONAL_ITECNICO"));
                                oCampo.prof_Tecnico = dr.GetString(dr.GetOrdinal("PROFESIONAL_ITECNICO"));
                                oCampo.chkDisponeER = dr.GetBoolean(dr.GetOrdinal("DISPONE_EMISION_CARTA"));
                                oCampo.chkDisponeSI = dr.GetBoolean(dr.GetOrdinal("DISPONE_SOLINF_AFFS"));
                                oCampo.chkOtros = dr.GetBoolean(dr.GetOrdinal("DISPONE_OTROS"));
                                oCampo.descOtros = dr.GetString(dr.GetOrdinal("DESCRIPCION_OTROS"));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return oCampo;
        }
        #endregion

        public CEntidad RegMostrarListaItems(SqlConnection cn, CEntidad oCEntidad)
        {
            CEntidad oCampo = new CEntidad();

            try
            {
                using (SqlDataReader dr = oGDataSQL.SelDrdDefault(cn, null, "DOC.spDENUNCIA_SITDMostrarItems", oCEntidad))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            if (dr.Read())
                            {
                                oCampo.COD_TRAMITE_SITD = dr.GetInt32(dr.GetOrdinal("COD_TRAMITE_SITD"));
                                oCampo.NUM_DREFERENCIA = dr.GetString(dr.GetOrdinal("NUM_DREFERENCIA"));
                                oCampo.ASUNTO = dr.GetString(dr.GetOrdinal("ASUNTO"));
                                oCampo.OBSERVACION_TRANSFERENCIA = dr.GetString(dr.GetOrdinal("OBSERVACION_TRANSFERENCIA"));

                                oCampo.PERTENECE_SECTOR_FORESTAL = dr.GetString(dr.GetOrdinal("PERTENECE_SECTOR_FORESTAL"));
                                oCampo.CORRESPONDE_AREA_OSINFOR = dr.GetString(dr.GetOrdinal("CORRESPONDE_AREA_OSINFOR"));
                                oCampo.COMPETENCIA_OSINFOR = dr.GetString(dr.GetOrdinal("COMPETENCIA_OSINFOR"));
                                oCampo.TRASLADAR_OTRA_ENTIDAD = dr.GetBoolean(dr.GetOrdinal("TRASLADAR_OTRA_ENTIDAD"));
                                oCampo.DESCRIPCION_OTRA_ENTIDAD = dr.GetString(dr.GetOrdinal("DESCRIPCION_OTRA_ENTIDAD"));
                                oCampo.DISPONE_ITECNICO = dr.GetBoolean(dr.GetOrdinal("DISPONE_ITECNICO"));
                                oCampo.COD_PROFESIONAL_ITECNICO = dr.GetString(dr.GetOrdinal("COD_PROFESIONAL_ITECNICO"));
                                oCampo.PROFESIONAL_ITECNICO = dr.GetString(dr.GetOrdinal("PROFESIONAL_ITECNICO"));
                                oCampo.DISPONE_EMISION_CARTA = dr.GetBoolean(dr.GetOrdinal("DISPONE_EMISION_CARTA"));
                                oCampo.DISPONE_SOLINF_AFFS = dr.GetBoolean(dr.GetOrdinal("DISPONE_SOLINF_AFFS"));
                                oCampo.DISPONE_OTROS = dr.GetBoolean(dr.GetOrdinal("DISPONE_OTROS"));
                                oCampo.DESCRIPCION_OTROS = dr.GetString(dr.GetOrdinal("DESCRIPCION_OTROS"));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return oCampo;
        }

        public String RegGrabar(SqlConnection cn, CEntidad oCEntidad)
        {
            SqlTransaction tr = null;
            String OUTPUTPARAM01 = "";
            try
            {
                tr = cn.BeginTransaction();
                //Grabando Cabecera
                using (SqlCommand cmd = oGDataSQL.ManExecuteOutput(cn, tr, "DOC.spDENUNCIA_SITDGrabar", oCEntidad))
                {
                    cmd.ExecuteNonQuery();
                    OUTPUTPARAM01 = (String)cmd.Parameters["@OUTPUTPARAM01"].Value;
                    if (OUTPUTPARAM01 == "99")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("Ud. no tiene permiso para realizar esta acción");
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

        public List<CEntidad> RegBuscarDenuncia(SqlConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> olCampos = new List<CEntidad>();
            try
            {
                using (SqlDataReader dr = oGDataSQL.SelDrdDefault(cn, null, "DOC.spGeneral_Listar", oCEntidad))
                {
                    if (dr != null)
                    {
                        CEntidad oCampo;

                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCampo = new CEntidad();
                                oCampo.COD_TRAMITE_SITD = dr.GetInt32(dr.GetOrdinal("COD_TRAMITE_SITD"));
                                oCampo.NUM_DREFERENCIA = dr.GetString(dr.GetOrdinal("NUM_DREFERENCIA"));
                                oCampo.PROFESIONAL_ITECNICO = dr.GetString(dr.GetOrdinal("PROFESIONAL_ITECNICO"));

                                olCampos.Add(oCampo);
                            }
                        }
                    }
                }

                return olCampos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CEntidad> ReporteGestionDenuncias_Resumen(SqlConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> olCampos = new List<CEntidad>();
            try
            {
                using (SqlDataReader dr = oGDataSQL.SelDrdDefault(cn, null, "DOC.spReporteGestionDenuncias", oCEntidad))
                {
                    if (dr != null)
                    {
                        CEntidad oCampo;

                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCampo = new CEntidad();
                                oCampo.COD_ANIO_MES = dr.GetString(dr.GetOrdinal("COD_ANIO_MES"));
                                oCampo.ANIO_MES = dr.GetString(dr.GetOrdinal("ANIO_MES"));
                                oCampo.N_DENUNCIA = dr.GetInt32(dr.GetOrdinal("N_DENUNCIA"));
                                oCampo.N_DENUNCIA_PENDIENTE = dr.GetInt32(dr.GetOrdinal("N_DENUNCIA_PENDIENTE"));
                                oCampo.N_DENUNCIA_REVISADO = dr.GetInt32(dr.GetOrdinal("N_DENUNCIA_REVISADO"));
                                oCampo.N_DENUNCIA_ANULADO = dr.GetInt32(dr.GetOrdinal("N_DENUNCIA_ANULADO"));
                                oCampo.N_SECTOR_FORESTAL = dr.GetInt32(dr.GetOrdinal("N_SECTOR_FORESTAL"));
                                oCampo.N_COMPETENCIA_OSINFOR = dr.GetInt32(dr.GetOrdinal("N_COMPETENCIA_OSINFOR"));
                                oCampo.N_DENUNCIA_ATENDIDA = dr.GetInt32(dr.GetOrdinal("N_DENUNCIA_ATENDIDA"));
                                olCampos.Add(oCampo);
                            }

                            oCampo = new CEntidad();
                            oCampo.COD_ANIO_MES = ""; oCampo.ANIO_MES = "TOTAL";
                            oCampo.N_DENUNCIA = 0; oCampo.N_DENUNCIA_PENDIENTE = 0; oCampo.N_DENUNCIA_REVISADO = 0;
                            oCampo.N_DENUNCIA_ANULADO = 0; oCampo.N_SECTOR_FORESTAL = 0; oCampo.N_COMPETENCIA_OSINFOR = 0;
                            oCampo.N_DENUNCIA_ATENDIDA = 0;

                            foreach (var item in olCampos)
                            {
                                oCampo.N_DENUNCIA += item.N_DENUNCIA;
                                oCampo.N_DENUNCIA_PENDIENTE += item.N_DENUNCIA_PENDIENTE;
                                oCampo.N_DENUNCIA_REVISADO += item.N_DENUNCIA_REVISADO;
                                oCampo.N_DENUNCIA_ANULADO += item.N_DENUNCIA_ANULADO;
                                oCampo.N_SECTOR_FORESTAL += item.N_SECTOR_FORESTAL;
                                oCampo.N_COMPETENCIA_OSINFOR += item.N_COMPETENCIA_OSINFOR;
                                oCampo.N_DENUNCIA_ATENDIDA += item.N_DENUNCIA_ATENDIDA;
                            }
                            olCampos.Add(oCampo);
                        }
                    }
                }

                return olCampos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CEntidad> ReporteGestionDenuncias_DetalleDenunciaSITD(SqlConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> olCampos = new List<CEntidad>();
            try
            {
                using (SqlDataReader dr = oGDataSQL.SelDrdDefault(cn, null, "DOC.spReporteGestionDenuncias", oCEntidad))
                {
                    if (dr != null)
                    {
                        CEntidad oCampo;

                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCampo = new CEntidad();
                                oCampo.COD_ANIO_MES = dr.GetString(dr.GetOrdinal("COD_ANIO_MES"));
                                oCampo.ANIO_MES = dr.GetString(dr.GetOrdinal("ANIO_MES"));
                                oCampo.COD_TRAMITE_SITD = dr.GetInt32(dr.GetOrdinal("COD_TRAMITE_SITD"));
                                oCampo.NUM_DREFERENCIA = dr.GetString(dr.GetOrdinal("NUM_DREFERENCIA"));
                                oCampo.FECHA_SITD = dr.GetString(dr.GetOrdinal("FECHA_SITD"));
                                oCampo.ENTIDAD = dr.GetString(dr.GetOrdinal("ENTIDAD"));
                                oCampo.PERTENECE_SECTOR_FORESTAL = dr.GetString(dr.GetOrdinal("PERTENECE_SECTOR_FORESTAL"));
                                oCampo.COMPETENCIA_OSINFOR = dr.GetString(dr.GetOrdinal("COMPETENCIA_OSINFOR"));
                                oCampo.ESTADO_DREFERENCIA = dr.GetString(dr.GetOrdinal("ESTADO_DREFERENCIA"));
                                oCampo.FECHA_ATENCION = dr.GetString(dr.GetOrdinal("FECHA_ATENCION"));
                                olCampos.Add(oCampo);
                            }
                        }
                    }
                }

                return olCampos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CEntidad> ReporteGestionDenuncias_DetalleDenunciaOSF(SqlConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> olCampos = new List<CEntidad>();
            try
            {
                using (SqlDataReader dr = oGDataSQL.SelDrdDefault(cn, null, "DOC.spReporteGestionDenuncias", oCEntidad))
                {
                    if (dr != null)
                    {
                        CEntidad oCampo;

                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCampo = new CEntidad();
                                oCampo.COD_ANIO_MES = dr.GetString(dr.GetOrdinal("COD_ANIO_MES"));
                                oCampo.ANIO_MES = dr.GetString(dr.GetOrdinal("ANIO_MES"));
                                oCampo.COD_TRAMITE_SITD = dr.GetInt32(dr.GetOrdinal("COD_TRAMITE_SITD"));
                                oCampo.NUM_DREFERENCIA = dr.GetString(dr.GetOrdinal("NUM_DREFERENCIA"));
                                oCampo.FECHA_SITD = dr.GetString(dr.GetOrdinal("FECHA_SITD"));
                                oCampo.NUM_DREFERENCIA_ASOCIADO = dr.GetString(dr.GetOrdinal("NUM_DREFERENCIA_ASOCIADO"));
                                oCampo.DISPONE = dr.GetString(dr.GetOrdinal("DISPONE"));
                                oCampo.DISPONE_DOCUMENTO = dr.GetString(dr.GetOrdinal("DISPONE_DOCUMENTO"));
                                oCampo.ASUNTO_DOCUMENTO = dr.GetString(dr.GetOrdinal("ASUNTO_DOCUMENTO"));
                                oCampo.DEPARTAMENTO = dr.GetString(dr.GetOrdinal("DEPARTAMENTO"));
                                oCampo.ASUNTO = dr.GetString(dr.GetOrdinal("ASUNTO"));
                                oCampo.NUM_THABILITANTE = dr.GetString(dr.GetOrdinal("NUM_THABILITANTE"));
                                oCampo.TITULAR_PAU_TRAMITE = dr.GetString(dr.GetOrdinal("TITULAR_PAU_TRAMITE"));
                                oCampo.REQUIERE_SUPERVISION = dr.GetString(dr.GetOrdinal("REQUIERE_SUPERVISION"));
                                oCampo.NUM_INFORME = dr.GetString(dr.GetOrdinal("NUM_INFORME"));
                                olCampos.Add(oCampo);
                            }
                        }
                    }
                }

                return olCampos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
