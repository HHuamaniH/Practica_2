using CapaEntidad.DOC;
using CapaEntidad.Documento;
using CapaEntidad.ViewModel;
//using GeneralSQL.Data;
using GeneralSQL;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
//using System.Data.SqlClient;
using System.Linq;

namespace CapaDatos.Documento
{
    public class Dat_Focalizacion
    {
        //private SQL oGDataSQL = new SQL();
        private DBOracle dBOracle = new DBOracle();
        #region "Focalización - Priorización"
        public List<VM_Focalizacion_Priorizacion> PaspeqPriorizacionListar(string periodo, string codOdAmbito, string numTH)
        {
            List<VM_Focalizacion_Priorizacion> result = new List<VM_Focalizacion_Priorizacion>();
            VM_Focalizacion_Priorizacion vm;
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, "FC_OSINFOR_ERP_MIGRACION.uspPASPEQ_Priorizacion_GetAll", periodo, codOdAmbito, numTH))
                    {
                        if (dr != null)
                        {

                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    vm = new VM_Focalizacion_Priorizacion();
                                    vm.codPlan = dr["COD_PLAN"].ToString();
                                    vm.codSecuencial = Convert.ToInt32(dr["COD_SECUENCIAL"]);
                                    vm.numTH = dr["NUM_THABILITANTE"].ToString();
                                    vm.numPoa = Convert.ToInt32(dr["NUM_POA"]);
                                    vm.planManejo = dr["PLAN_MANEJO"].ToString();
                                    vm.a1 = Convert.ToDecimal(dr["A1"]);
                                    vm.a2 = Convert.ToDecimal(dr["A2"]);
                                    vm.a3 = Convert.ToDecimal(dr["A3"]);
                                    vm.a4 = Convert.ToDecimal(dr["A4"]);
                                    vm.a5 = Convert.ToDecimal(dr["A5"]);
                                    vm.a6 = Convert.ToDecimal(dr["A6"]);
                                    vm.a7 = Convert.ToDecimal(dr["A7"]);
                                    vm.a8 = Convert.ToDecimal(dr["A8"]);
                                    vm.b1 = Convert.ToDecimal(dr["B1"]);
                                    vm.b2 = Convert.ToDecimal(dr["B2"]);
                                    vm.b3 = Convert.ToDecimal(dr["B3"]);
                                    vm.b4 = Convert.ToDecimal(dr["B4"]);
                                    vm.b5 = Convert.ToDecimal(dr["B5"]);
                                    vm.b6 = Convert.ToDecimal(dr["B6"]);
                                    vm.subTotalIneludible = vm.a1 + vm.a2 + vm.a3 + vm.a4 + vm.a5 + vm.a6 + vm.a7 + vm.a8;
                                    vm.subTotalCircunstancial = vm.b1 + vm.b2 + vm.b3 + vm.b4 + vm.b5 + vm.b6;
                                    vm.total = vm.a1 + vm.a2 + vm.a3 + vm.a4 + vm.a5 + vm.a6 + vm.a7 + vm.a8 + vm.b1 + vm.b2 + vm.b3 + vm.b4 + vm.b5 + vm.b6;
                                    result.Add(vm);
                                }
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
        public VM_Focalizacion_Priorizacion PaspeqPriorizacionGetById(string codPlan, int codSecuencial)
        {
            VM_Focalizacion_Priorizacion vm = new VM_Focalizacion_Priorizacion();
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, "FC_OSINFOR_ERP_MIGRACION.uspPASPEQ_Priorizacion_GetById", codPlan, codSecuencial))
                    {
                        if (dr != null)
                        {

                            if (dr.HasRows)
                            {
                                dr.Read();
                                vm = new VM_Focalizacion_Priorizacion();
                                vm.codPlan = dr["COD_PLAN"].ToString();
                                vm.codSecuencial = Convert.ToInt32(dr["COD_SECUENCIAL"]);
                                vm.numTH = dr["NUM_THABILITANTE"].ToString();
                                vm.numPoa = Convert.ToInt32(dr["NUM_POA"]);
                                vm.planManejo = dr["PLAN_MANEJO"].ToString();
                                vm.a1 = Convert.ToDecimal(dr["A1"]);
                                vm.a2 = Convert.ToDecimal(dr["A2"]);
                                vm.a3 = Convert.ToDecimal(dr["A3"]);
                                vm.a4 = Convert.ToDecimal(dr["A4"]);
                                vm.a5 = Convert.ToDecimal(dr["A5"]);
                                vm.a6 = Convert.ToDecimal(dr["A6"]);
                                vm.a7 = Convert.ToDecimal(dr["A7"]);
                                vm.a8 = Convert.ToDecimal(dr["A8"]);
                                vm.b1 = Convert.ToDecimal(dr["B1"]);
                                vm.b2 = Convert.ToDecimal(dr["B2"]);
                                vm.b3 = Convert.ToDecimal(dr["B3"]);
                                vm.b4 = Convert.ToDecimal(dr["B4"]);
                                vm.b5 = Convert.ToDecimal(dr["B5"]);
                                vm.b6 = Convert.ToDecimal(dr["B6"]);
                                vm.subTotalIneludible = vm.a1 + vm.a2 + vm.a3 + vm.a4 + vm.a5 + vm.a6 + vm.a7 + vm.a8;
                                vm.subTotalCircunstancial = vm.b1 + vm.b2 + vm.b3 + vm.b4 + vm.b5 + vm.b6;
                                vm.total = vm.a1 + vm.a2 + vm.a3 + vm.a4 + vm.a5 + vm.a6 + vm.a7 + vm.a8 + vm.b1 + vm.b2 + vm.b3 + vm.b4 + vm.b5 + vm.b6;
                            }
                        }
                    }
                }
                return vm;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool PaspeqPriorizacionInsertarEliminar(List<ENT_Focalizacion_Priorizacion> items, string usuarioCreacion)
        {

            using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
            {
                OracleTransaction tr = null;
                string OUTPUTPARAM02 = "";
                try
                {
                    cn.Open();
                    tr = cn.BeginTransaction();
                    //Grabando asignacion
                    foreach (var item in items)
                    {
                        OUTPUTPARAM02 = "";
                        using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, tr, "FC_OSINFOR_ERP_MIGRACION.uspPASPEQ_Priorizacion_Update", item))
                        {
                            cmd.ExecuteNonQuery();
                            OUTPUTPARAM02 = (String)cmd.Parameters["OUTPUTPARAM02"].Value;
                            if (OUTPUTPARAM02 != "EXITO")
                            {
                                throw new Exception("0|" + OUTPUTPARAM02);
                            }
                        }
                    }
                    tr.Commit();
                }
                catch (Exception ex)
                {
                    tr.Rollback();
                    tr.Dispose();
                    tr = null;
                    throw ex;
                }
            }
            return true;
        }
        #endregion
        #region "Focalización - Plan de trabajo"
        public List<VM_Focalizacion_PlanTrabajo_List> PlanTrabajoListar(string od, string periodo, int mes, string id, int currentpage, int pagesize, string sort, ref int rowcount)
        {
            List<VM_Focalizacion_PlanTrabajo_List> result = new List<VM_Focalizacion_PlanTrabajo_List>();
            VM_Focalizacion_PlanTrabajo_List vm;
            rowcount = 0;
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, "FC_OSINFOR_ERP_MIGRACION.uspPASPEQ_PlanTrabajo_GetAll", od, periodo, mes, id, currentpage, pagesize, sort))
                    {
                        if (dr != null)
                        {

                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    vm = new VM_Focalizacion_PlanTrabajo_List();
                                    vm.idPlanTrajo = dr["COD_PLAN_TRABAJO_SUPERVISION"].ToString();
                                    vm.fRegistro = Convert.ToDateTime(dr["FECHA_CREACION"]);
                                    vm.fRegistroText = dr["FECHA_CREACION_TEXT"].ToString();
                                    vm.od = dr["OD"].ToString();
                                    vm.periodo = dr["PERIODO"].ToString();
                                    vm.mes = dr["MES_FOCALIZACION"].ToString();
                                    vm.supervisor = dr["USUARIO_REGISTRO"].ToString();
                                    vm.funcionario = dr["FUNCIONARIO_APROBACION"].ToString();
                                    vm.estadoDoc = dr["ESTADO_DOC"].ToString();
                                    vm.estado = Convert.ToBoolean(dr["ESTADO"]);
                                    result.Add(vm);
                                }
                                dr.NextResult();
                                if (dr.HasRows)
                                {
                                    if (dr.Read())
                                    {
                                        rowcount = Convert.ToInt32(dr["rowcount"].ToString());
                                    }
                                }
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
        public VM_Focalizacion_PlanTrabajo PlanTrabajoGetById(string id)
        {
            VM_Focalizacion_PlanTrabajo vm = new VM_Focalizacion_PlanTrabajo();
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, "FC_OSINFOR_ERP_MIGRACION.uspPASPEQ_PlanTrabajo_GetById", id))
                    {
                        if (dr != null)
                        {

                            if (dr.HasRows)
                            {
                                dr.Read();
                                vm.idPlanTrajo = dr["COD_PLAN_TRABAJO_SUPERVISION"].ToString();
                                vm.ddlIODId = dr["COD_OD"].ToString();
                                vm.ddlPeriodoId = dr["PERIODO"].ToString();
                                vm.ddlMesId = Convert.ToInt16(dr["MES_FOCALIZACION"]);
                                vm.funcionarioResponsableId = dr["COD_JEFE"].ToString();
                                vm.funcionarioResponsable = dr["FUNCIONARIO_APROBACION"].ToString();
                                vm.usuarioCreacion = dr["USUARIO_REGISTRO"].ToString();
                                vm.usuarioModificacion = dr["USUARIO_MODIFICACION"].ToString();
                                vm.funcionarioResponsableNA = dr["FUNCIONARIO_APROBACION_NA"].ToString();
                                vm.usuarioCreacionNA = dr["USUARIO_REGISTRO_NA"].ToString();
                                vm.usuarioCreacion= dr["USUARIO_REGISTRO"].ToString(); 
                                vm.usuarioModificacion= dr["USUARIO_MODIFICACION"].ToString();                               
                                vm.fCreacion = Convert.ToDateTime(dr["FECHA_CREACION"]);
                                vm.od = dr["OD"].ToString();
                                vm.mesFocalizacion = dr["MES_FOCALIZACION_TEXT"].ToString();

                                dr.NextResult();
                                dr.Read();
                                vm.observacionSubsanar = false;//Convert.ToBoolean(dr["OBSERV_SUBSANAR"]);
                                vm.ddlItemIndicadorId = dr["COD_ESTADO_DOC"].ToString();
                            }
                        }
                    }
                }
                return vm;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string PlanTrabajoCreate(Ent_Focalizacion_PlanTrabajo planCabecera)
        {
            String OUTPUTPARAM01 = "";
            String OUTPUTPARAM02 = "";
            using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
            {
                OracleTransaction tr = null;
                try
                {
                    cn.Open();
                    tr = cn.BeginTransaction();
                    using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, tr, "FC_OSINFOR_ERP_MIGRACION.uspPASPEQ_PlanTrabajo_Create", planCabecera))
                    {
                        cmd.ExecuteNonQuery();
                        OUTPUTPARAM01 = (String)cmd.Parameters["OUTPUTPARAM01"].Value;
                        OUTPUTPARAM02 = (String)cmd.Parameters["OUTPUTPARAM02"].Value;
                        if (OUTPUTPARAM02 != "EXITO")
                        {
                            throw new Exception("0|" + OUTPUTPARAM02);
                        }
                    }
                    tr.Commit();
                }
                catch (Exception ex)
                {
                    tr.Rollback();
                    tr.Dispose();
                    tr = null;
                    throw ex;
                }
            }
            return OUTPUTPARAM01;
        }

        public bool PlanTrabajoDetCreate(List<Ent_Focalizacion_PlanTrabajo_Detalle> ent)
        {
            String OUTPUTPARAM02 = "";
            using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
            {
                OracleTransaction tr = null;
                try
                {
                    cn.Open();
                    tr = cn.BeginTransaction();
                    foreach (var item in ent)
                    {
                        OUTPUTPARAM02 = "";
                        using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, tr, "FC_OSINFOR_ERP_MIGRACION.uspPASPEQ_PlanTrabajoDetalle_Create", item))
                        {
                            cmd.ExecuteNonQuery();
                            OUTPUTPARAM02 = (String)cmd.Parameters["OUTPUTPARAM02"].Value;
                            if (OUTPUTPARAM02 != "EXITO")
                            {
                                throw new Exception("0|" + OUTPUTPARAM02);
                            }
                        }
                    }
                    tr.Commit();
                }
                catch (Exception ex)
                {
                    tr.Rollback();
                    tr.Dispose();
                    tr = null;
                    throw ex;
                }
            }
            return true;
        }
        public bool PlanTrabajoDelete(Ent_Focalizacion_PlanTrabajo ent)
        {
            String OUTPUTPARAM02 = "";
            using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
            {
                OracleTransaction tr = null;
                try
                {
                    cn.Open();
                    tr = cn.BeginTransaction();
                    using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, tr, "FC_OSINFOR_ERP_MIGRACION.uspPASPEQ_PlanTrabajo_Delete", ent))
                    {
                        cmd.ExecuteNonQuery();
                        OUTPUTPARAM02 = (String)cmd.Parameters["OUTPUTPARAM02"].Value;
                        if (OUTPUTPARAM02 != "EXITO")
                        {
                            throw new Exception("0|" + OUTPUTPARAM02);
                        }
                    }
                    tr.Commit();
                }
                catch (Exception ex)
                {
                    tr.Rollback();
                    tr.Dispose();
                    tr = null;
                    throw ex;
                }
            }
            return true;
        }
        public bool PlanTrabajoDetDelete(Ent_Focalizacion_PlanTrabajo_Detalle ent)
        {
            String OUTPUTPARAM02 = "";
            using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
            {
                OracleTransaction tr = null;
                try
                {
                    cn.Open();
                    tr = cn.BeginTransaction();
                    using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, tr, "FC_OSINFOR_ERP_MIGRACION.uspPASPEQ_PlanTrabajoDetalle_Delete", ent))
                    {
                        cmd.ExecuteNonQuery();
                        OUTPUTPARAM02 = (String)cmd.Parameters["OUTPUTPARAM02"].Value;
                        if (OUTPUTPARAM02 != "EXITO")
                        {
                            throw new Exception("0|" + OUTPUTPARAM02);
                        }
                    }
                    tr.Commit();
                }
                catch (Exception ex)
                {
                    tr.Rollback();
                    tr.Dispose();
                    tr = null;
                    throw ex;
                }
            }
            return true;
        }
        public List<VM_PlanManejoCalificacion> PlanManejoCalificadoGetAll(string codPlanTrabajo, int tipoSupervision = 4)
        {
            List<VM_PlanManejoCalificacion> result = new List<VM_PlanManejoCalificacion>();
            VM_PlanManejoCalificacion vm;
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, "FC_OSINFOR_ERP_MIGRACION.uspPASPEQ_PlanManejo_Calificacion_GetAll", codPlanTrabajo, tipoSupervision))
                    {
                        if (dr != null)
                        {

                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    vm = new VM_PlanManejoCalificacion();
                                    vm.tipoPManejo = dr["TIPO_PMANEJO"].ToString();
                                    vm.codTH = dr["COD_THABILITANTE"].ToString();
                                    vm.codPlan = dr["COD_PLAN"].ToString();
                                    vm.codSecuencial = Convert.ToInt32(dr["COD_SECUENCIAL"]);
                                    vm.titular = dr["TITULAR_ACTUAL"].ToString();
                                    vm.th = dr["NUM_THABILITANTE"].ToString();
                                    vm.planManejo = dr["PLAN_MANEJO"].ToString();
                                    vm.numPoa = Convert.ToInt32(dr["NUM_POA"]);
                                    vm.puntaje = Convert.ToDecimal(dr["PUNTAJE"]);
                                    vm.tipoSupervision = Convert.ToInt32(dr["TIPO_SUPERVISION"]);
                                    result.Add(vm);
                                }
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
        public List<VM_PlanManejoCalificacion> PlanManejoUniversoAdicionalGetAll(string codPlanTrabajo)
        {
            List<VM_PlanManejoCalificacion> result = new List<VM_PlanManejoCalificacion>();
            VM_PlanManejoCalificacion vm;
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, "FC_OSINFOR_ERP_MIGRACION.uspPASPEQ_PlanManejo_Calificacion_Adicional_GetAll", codPlanTrabajo))
                    {
                        if (dr != null)
                        {

                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    vm = new VM_PlanManejoCalificacion();
                                    vm.tipoPManejo = dr["TIPO_PMANEJO"].ToString();
                                    vm.codTH = dr["COD_THABILITANTE"].ToString();
                                    vm.codPlan = dr["COD_PLAN"].ToString();
                                    vm.codSecuencial = Convert.ToInt32(dr["COD_SECUENCIAL"]);
                                    vm.titular = dr["TITULAR_ACTUAL"].ToString();
                                    vm.th = dr["NUM_THABILITANTE"].ToString();
                                    vm.planManejo = dr["PLAN_MANEJO"].ToString();
                                    vm.numPoa = Convert.ToInt32(dr["NUM_POA"]);
                                    vm.puntaje = Convert.ToDecimal(dr["PUNTAJE"]);
                                    result.Add(vm);
                                }
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">@COD_PLAN_TRABAJO_SUPERVISION</param>
        /// <returns></returns>
        public List<VM_Focalizacion_PlanTrabajoDet_List> PlanTrabajoDetGetByPadreId(string id)
        {
            List<VM_Focalizacion_PlanTrabajoDet_List> result = new List<VM_Focalizacion_PlanTrabajoDet_List>();
            VM_Focalizacion_PlanTrabajoDet_List vm;
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, "FC_OSINFOR_ERP_MIGRACION.uspPASPEQ_PlanTrabajoDetalle_GetByPadreId", id))
                    {
                        if (dr != null)
                        {

                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    vm = new VM_Focalizacion_PlanTrabajoDet_List();
                                    vm.idPlanTrajoDet = Convert.ToInt64(dr["COD_PLAN_TRABAJO_SUPERVISION_DETALLE"]);
                                    vm.tipoSupervision = dr["TIPO_SUPERVISION"].ToString();
                                    vm.oportunidadSupervision = dr["OPORTUNIDAD_SUPERVISION"].ToString();
                                    vm.codTH = dr["COD_THABILITANTE"].ToString();
                                    vm.numPoa = Convert.ToInt32(dr["NUM_POA"]);
                                    vm.tipoPManejo = dr["TIPO_PMANEJO"].ToString();
                                    vm.nombrePManejo = dr["NOMBRE_PMANEJO"].ToString();
                                    vm.titular = dr["TITULAR_ACTUAL"].ToString();
                                    vm.numTH = dr["NUM_THABILITANTE"].ToString();
                                    vm.codMTipo = dr["COD_MTIPO"].ToString();
                                    vm.modalidad = dr["MODALIDAD"].ToString();
                                    vm.departamento = dr["DEPARTAMENTO"].ToString();
                                    vm.provincia = dr["PROVINCIA"].ToString();
                                    vm.distrito = dr["DISTRITO"].ToString();
                                    vm.criterios = dr["CRITERIOS"].ToString();
                                    result.Add(vm);
                                }
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
        public VM_Focalizacion_PlanTrabajoDet_List PlanTrabajoDetGetById(long id)
        {
            VM_Focalizacion_PlanTrabajoDet_List vm = null;
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, "FC_OSINFOR_ERP_MIGRACION.uspPASPEQ_PlanTrabajoDetalle_GetById", id))
                    {
                        if (dr != null)
                        {

                            if (dr.HasRows)
                            {
                                dr.Read();
                                vm = new VM_Focalizacion_PlanTrabajoDet_List();
                                vm.idPlan = dr["COD_PLAN_TRABAJO_SUPERVISION"].ToString();
                                vm.idPlanTrajoDet = Convert.ToInt64(dr["COD_PLAN_TRABAJO_SUPERVISION_DETALLE"]);
                                vm.tipoSupervision = dr["TIPO_SUPERVISION"].ToString();
                                vm.oportunidadSupervision = dr["OPORTUNIDAD_SUPERVISION"].ToString();
                                vm.codTH = dr["COD_THABILITANTE"].ToString();
                                vm.numPoa = Convert.ToInt32(dr["NUM_POA"]);
                                vm.tipoPManejo = dr["TIPO_PMANEJO"].ToString();
                                vm.nombrePManejo = dr["NOMBRE_PMANEJO"].ToString();
                                vm.titular = dr["TITULAR_ACTUAL"].ToString();
                                vm.numTH = dr["NUM_THABILITANTE"].ToString();
                                vm.codMTipo = dr["COD_MTIPO"].ToString();
                                vm.modalidad = dr["MODALIDAD"].ToString();
                                vm.departamento = dr["DEPARTAMENTO"].ToString();
                                vm.provincia = dr["PROVINCIA"].ToString();
                                vm.distrito = dr["DISTRITO"].ToString();
                                vm.criterios = dr["CRITERIOS"].ToString();
                                vm.OdAmbito = dr["OD_AMBITO"].ToString();
                            }
                        }
                    }
                }
                return vm;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region "Muestra"
        public List<VM_PlanTrabajoDetalleEspecie> PlanTrabajoDetGetEspecie(string codTH, int numPoa)
        {
            List<VM_PlanTrabajoDetalleEspecie> result = new List<VM_PlanTrabajoDetalleEspecie>();
            VM_PlanTrabajoDetalleEspecie vm;
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, "FC_OSINFOR_ERP_MIGRACION.uspPASPEQ_PlanTrabajoDetalle_GetEspecie", codTH, numPoa))
                    {
                        if (dr != null)
                        {

                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    vm = new VM_PlanTrabajoDetalleEspecie();
                                    vm.codEspecie = dr["CodEspecie"].ToString();
                                    vm.descripcionEspecie = dr["DescripcionEspecie"].ToString();
                                    vm.AGRADO_CITE = dr["AGRADO_CITE"].ToString();
                                    vm.TIENE_AGRADO_CITE = Convert.ToBoolean(dr["TIENE_AGRADO_CITE"]);
                                    vm.numAprov = Convert.ToInt32(dr["NumAprov"]);
                                    vm.numSemilleros = Convert.ToInt32(dr["NumSemilleros"]);
                                    vm.volAutorizado = Math.Round(Convert.ToDecimal(dr["VolAutorizado"]), 3);
                                    vm.volMovilizado = Math.Round(Convert.ToDecimal(dr["VolMovilizado"]), 3);
                                    vm.totalIndividuos = vm.numAprov + vm.numSemilleros;
                                    vm.IdPuntajeEspeciesAmenazadas = dr["IdPuntajeCatEspecieAmenazada"].ToString();
                                    vm.IdPuntajeCategoriaMad= dr["IdPuntajeCatEspecieMaderable"].ToString();
                                    vm.puntajeEspeciesAmenazadas = Convert.ToInt32(dr["PuntajeCatEspecieAmenazada"]);
                                    vm.puntajeCategoriaMad = Convert.ToInt32(dr["PuntajeCatEspecieMaderable"]);
                                    //vm.PCA = dr["PCA"].ToString();
                                    result.Add(vm);
                                }
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
        public bool GenerarCalificacionMuestra(List<Ent_Plan_T_Detalle_Especie> items)
        {
            string OUTPUTPARAM02 = "";
            using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
            {
                OracleTransaction tr = null;
                try
                {
                    cn.Open();
                    tr = cn.BeginTransaction();
                    //verificando si el plan de trabajo tiene control de calidad conforme
                    using (OracleCommand cmd = dBOracle.ManExecuteOutputV1(cn, tr, "FC_OSINFOR_ERP_MIGRACION.uspPASPEQ_PlanTrabajoDetalle_Verificar"))
                    {
                        OracleCommandBuilder.DeriveParameters(cmd);
                        cmd.Parameters["COD_PLAN_TRABAJO_SUPERVISION_DETALLE"].Value = items.First().COD_PLAN_TRABAJO_SUPERVISION_DETALLE;
                        cmd.Parameters["TIPO"].Value = "GENERAR_CALIFICACION_ESPECIE";
                        cmd.Parameters["OUTPUTPARAM02"].Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        OUTPUTPARAM02 = (String)cmd.Parameters["OUTPUTPARAM02"].Value;
                        if (OUTPUTPARAM02 != "EXITO")
                        {
                            throw new Exception("0|" + OUTPUTPARAM02);
                        }
                    }
                    foreach (var item in items)
                    {
                        dBOracle.ManExecute(cn, tr, "FC_OSINFOR_ERP_MIGRACION.uspPASPEQ_PlanTrabajoDetalleEspecie_Create", item);
                    }
                    tr.Commit();
                    return true;
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
        }
        public List<VM_PlanTrabajoDetalleEspecie> PlanTrabajoDetGetEspecieCalificacionNoCites(long codPlanTrabajoSupervisionDetalle)
        {
            List<VM_PlanTrabajoDetalleEspecie> result = new List<VM_PlanTrabajoDetalleEspecie>();
            VM_PlanTrabajoDetalleEspecie vm;
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, "FC_OSINFOR_ERP_MIGRACION.uspPASPEQ_PlanTrabajoDetalleEspecie_GetByPTSD", codPlanTrabajoSupervisionDetalle))
                    {
                        if (dr != null)
                        {

                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    vm = new VM_PlanTrabajoDetalleEspecie();
                                    vm.id = Convert.ToInt64(dr["COD_PLAN_T_DETALLE_ESPECIE"]);
                                    vm.idCabecera = Convert.ToInt64(dr["COD_PLAN_TRABAJO_SUPERVISION_DETALLE"]);
                                    vm.codEspecie = dr["CodEspecie"].ToString();
                                    vm.descripcionEspecie = dr["DescripcionEspecie"].ToString();
                                    vm.totalIndividuos = Convert.ToInt32(dr["TotalIndividuos"]);
                                    vm.numAprov = Convert.ToInt32(dr["NumAprov"]);
                                    vm.numSemilleros = Convert.ToInt32(dr["NumSemilleros"]);
                                    vm.volAutorizado = Math.Round(Convert.ToDecimal(dr["VolAutorizado"]), 3);
                                    vm.volMovilizado = Math.Round(Convert.ToDecimal(dr["VolMovilizado"]), 3);

                                    vm.abundanciaCalificacion = Convert.ToDecimal(dr["CalAbundancia"]);
                                    vm.abundanciaPuntaje = Convert.ToInt32(dr["PuntajeAbundancia"]);
                                    vm.volAprobadoCalificacion = Convert.ToDecimal(dr["CalVAprobado"]);
                                    vm.volAprobadoPuntaje = Convert.ToInt32(dr["PuntajeVAprobado"]);
                                    vm.volMovilizadoCalificacion = Convert.ToDecimal(dr["CalVMovilizado"]);
                                    vm.volMovilizadoPuntaje = Convert.ToInt32(dr["PuntajeVMovilizado"]);

                                    vm.puntajeEspeciesAmenazadas = Convert.ToInt32(dr["PuntajeCatEspecieAmenazada"]);
                                    vm.IdPuntajeEspeciesAmenazadas = dr["IdPuntajeCatEspecieAmenazada"].ToString();
                                    vm.puntajeCategoriaMad = Convert.ToInt32(dr["PuntajeCatEspecieMaderable"]);
                                    vm.IdPuntajeCategoriaMad = dr["IdPuntajeCatEspecieMaderable"].ToString();
                                    vm.calEspeciesAmenazadas = dr["CodPuntajeCatEspecieAmenazada"].ToString();
                                    vm.calCategoriaMad = dr["CodPuntajeCatEspecieMaderable"].ToString();
                                    vm.puntajeTotalCalificacion = Convert.ToInt32(dr["PuntajeFinal"]);
                                    vm.puntajeTotalPorcentaje = Convert.ToDecimal(dr["PuntajeFinalPorcentaje"]);
                                    vm.perteneceMuestraMinima = Convert.ToInt32(dr["PERTENECE_MUESTRA_MINIMA"]);
                                    //vm.PCA = dr["PCA"].ToString();

                                    result.Add(vm);
                                }
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
        public List<VM_PlanTrabajoDetalleEspecie> PlanTrabajoDetGetEspecieCalificacionCites(long codPlanTrabajoSupervisionDetalle)
        {
            List<VM_PlanTrabajoDetalleEspecie> result = new List<VM_PlanTrabajoDetalleEspecie>();
            VM_PlanTrabajoDetalleEspecie vm;
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, "FC_OSINFOR_ERP_MIGRACION.uspPASPEQ_PlanTrabajoDetalleEspecieCite_GetByPTSD", codPlanTrabajoSupervisionDetalle))
                    {
                        if (dr != null)
                        {

                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    vm = new VM_PlanTrabajoDetalleEspecie();
                                    vm.id = Convert.ToInt64(dr["COD_PLAN_T_DETALLE_ESPECIE"]);
                                    vm.idCabecera = Convert.ToInt64(dr["COD_PLAN_TRABAJO_SUPERVISION_DETALLE"]);
                                    vm.codEspecie = dr["CodEspecie"].ToString();
                                    vm.descripcionEspecie = dr["DescripcionEspecie"].ToString();
                                    vm.totalIndividuos = Convert.ToInt32(dr["TotalIndividuos"]);
                                    vm.numAprov = Convert.ToInt32(dr["NumAprov"]);
                                    vm.numSemilleros = Convert.ToInt32(dr["NumSemilleros"]);
                                    vm.volAutorizado = Math.Round(Convert.ToDecimal(dr["VolAutorizado"]), 3);
                                    vm.volMovilizado = Math.Round(Convert.ToDecimal(dr["VolMovilizado"]), 3);

                                    vm.abundanciaCalificacion = Convert.ToDecimal(dr["CalAbundancia"]);
                                    vm.abundanciaPuntaje = Convert.ToInt32(dr["PuntajeAbundancia"]);
                                    vm.volAprobadoCalificacion = Convert.ToDecimal(dr["CalVAprobado"]);
                                    vm.volAprobadoPuntaje = Convert.ToInt32(dr["PuntajeVAprobado"]);
                                    vm.volMovilizadoCalificacion = Convert.ToDecimal(dr["CalVMovilizado"]);
                                    vm.volMovilizadoPuntaje = Convert.ToInt32(dr["PuntajeVMovilizado"]);

                                    vm.puntajeEspeciesAmenazadas = Convert.ToInt32(dr["PuntajeCatEspecieAmenazada"]);
                                    vm.IdPuntajeEspeciesAmenazadas = dr["IdPuntajeCatEspecieAmenazada"].ToString();
                                    vm.puntajeCategoriaMad = Convert.ToInt32(dr["PuntajeCatEspecieMaderable"]);
                                    vm.IdPuntajeCategoriaMad = dr["IdPuntajeCatEspecieMaderable"].ToString();
                                    vm.calEspeciesAmenazadas = dr["CodPuntajeCatEspecieAmenazada"].ToString();
                                    vm.calCategoriaMad = dr["CodPuntajeCatEspecieMaderable"].ToString();
                                    vm.puntajeTotalCalificacion = Convert.ToInt32(dr["PuntajeFinal"]);
                                    vm.puntajeTotalPorcentaje = Convert.ToDecimal(dr["PuntajeFinalPorcentaje"]);
                                    vm.Observacion = dr["OBSERVACION"].ToString();
                                    vm.TIENE_AGRADO_CITE = Convert.ToBoolean(dr["TIENE_AGRADO_CITE"]);
                                    result.Add(vm);
                                }
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
        public bool PlanTrabajoDetEspecieDelete(long codPlanTrabajoSupervisionDetalle, string codUsuario)
        {
            String OUTPUTPARAM02 = "";
            using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
            {
                OracleTransaction tr = null;
                try
                {
                    cn.Open();
                    tr = cn.BeginTransaction();
                    using (OracleCommand cmd = dBOracle.ManExecuteOutputV1(cn, tr, "FC_OSINFOR_ERP_MIGRACION.uspPASPEQ_PlanTrabajoDetalleEspecie_DeletetByPTSD"))
                    {
                        OracleCommandBuilder.DeriveParameters(cmd);
                        cmd.Parameters["COD_PLAN_TRABAJO_SUPERVISION_DETALLE"].Value = codPlanTrabajoSupervisionDetalle;
                        cmd.Parameters["COD_UCUENTA"].Value = codUsuario;
                        cmd.Parameters["OUTPUTPARAM02"].Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        OUTPUTPARAM02 = (String)cmd.Parameters["OUTPUTPARAM02"].Value;
                        if (OUTPUTPARAM02 != "EXITO")
                        {
                            throw new Exception("0|" + OUTPUTPARAM02);
                        }
                    }
                    tr.Commit();
                }
                catch (Exception ex)
                {
                    tr.Rollback();
                    tr.Dispose();
                    tr = null;
                    throw ex;
                }
            }
            return true;
        }
        public bool PlanTrabajoDetalleEspecie_Update(List<VM_PlanTrabajoDetalleEspecie> items, string codUsuario)
        {
            string OUTPUTPARAM02 = "";
            using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
            {
                OracleTransaction tr = null;
                try
                {
                    cn.Open();
                    tr = cn.BeginTransaction();
                    //aqui verificar si esta aprobado por el funcionario el plan de trabajo
                    using (OracleCommand cmd = dBOracle.ManExecuteOutputV1(cn, tr, "FC_OSINFOR_ERP_MIGRACION.uspPASPEQ_PlanTrabajoDetalle_Verificar"))
                    {
                        OracleCommandBuilder.DeriveParameters(cmd);
                        cmd.Parameters["COD_PLAN_TRABAJO_SUPERVISION_DETALLE"].Value = items.First().idCabecera;
                        cmd.Parameters["TIPO"].Value = "ACTUALIZAR_CALIFICACION_ESPECIE";
                        cmd.Parameters["OUTPUTPARAM02"].Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        OUTPUTPARAM02 = (String)cmd.Parameters["OUTPUTPARAM02"].Value;
                        if (OUTPUTPARAM02 != "EXITO")
                        {
                            throw new Exception("0|" + OUTPUTPARAM02);
                        }
                    }
                    //verificando si tiene muestra mínima
                    OUTPUTPARAM02 = "";
                    using (OracleCommand cmd = dBOracle.ManExecuteOutputV1(cn, tr, "FC_OSINFOR_ERP_MIGRACION.uspPASPEQ_PlanTrabajoDetalle_Verificar"))
                    {
                        OracleCommandBuilder.DeriveParameters(cmd);
                        cmd.Parameters["COD_PLAN_TRABAJO_SUPERVISION_DETALLE"].Value = items.First().idCabecera;
                        cmd.Parameters["TIPO"].Value = "ACTUALIZAR_CALIFICACION_ESPECIE_EXIST_MUESTRA";
                        cmd.Parameters["OUTPUTPARAM02"].Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        OUTPUTPARAM02 = (String)cmd.Parameters["OUTPUTPARAM02"].Value;
                        if (OUTPUTPARAM02 != "EXITO")
                        {
                            throw new Exception("0|" + OUTPUTPARAM02);
                        }
                    }
                    foreach (var item in items)
                    {
                        dBOracle.ManExecute(cn, tr, "FC_OSINFOR_ERP_MIGRACION.uspPASPEQ_PlanTrabajoDetalleEspecie_Update",
                            item.id, item.puntajeTotalCalificacion, item.puntajeTotalPorcentaje, item.IdPuntajeEspeciesAmenazadas,
                            item.puntajeEspeciesAmenazadas, item.IdPuntajeCategoriaMad, item.puntajeCategoriaMad, codUsuario);
                    }
                    tr.Commit();
                }
                catch (Exception ex)
                {
                    tr.Rollback();
                    tr.Dispose();
                    tr = null;
                    throw ex;
                }
            }
            return true;
        }
        public bool PlanTrabajoDetalleMuestraMinima_Create(List<VM_PlanTrabajoDetalleEspecie> itemNoCites, decimal tamañoMinimoMustra, long codPlanTrabajoSupervisionDetalle, string codUsuario)
        {
            string OUTPUTPARAM02 = "";
            using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
            {
                OracleTransaction tr = null;
                try
                {
                    cn.Open();
                    tr = cn.BeginTransaction();
                    //aqui verificar si esta aprobado por el funcionario el plan de trabajo
                    using (OracleCommand cmd = dBOracle.ManExecuteOutputV1(cn, tr, "FC_OSINFOR_ERP_MIGRACION.uspPASPEQ_PlanTrabajoDetalle_Verificar"))
                    {
                        OracleCommandBuilder.DeriveParameters(cmd);
                        cmd.Parameters["COD_PLAN_TRABAJO_SUPERVISION_DETALLE"].Value = codPlanTrabajoSupervisionDetalle;
                        cmd.Parameters["TIPO"].Value = "GENERAR_MUESTRA_MINIMA";
                        cmd.Parameters["OUTPUTPARAM02"].Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        OUTPUTPARAM02 = (String)cmd.Parameters["OUTPUTPARAM02"].Value;
                        if (OUTPUTPARAM02 != "EXITO")
                        {
                            throw new Exception("0|" + OUTPUTPARAM02);
                        }
                    }
                    //actualizando tamaño de la muestra en la tabla PLAN_TRABAJO_SUPERVISION_DETALLE
                    dBOracle.ManExecute(cn, tr, "FC_OSINFOR_ERP_MIGRACION.uspPASPEQ_PlanTrabajoDetalleMuestra_Update", codPlanTrabajoSupervisionDetalle, tamañoMinimoMustra, codUsuario);
                    foreach (var item in itemNoCites)
                    {
                        dBOracle.ManExecute(cn, tr, "FC_OSINFOR_ERP_MIGRACION.uspPASPEQ_PlanTrabajoDetalleMuestraMinima_Create",
                            item.id, item.factorAprov, item.factorSem, item.muestraAprov, item.muestraSem, codUsuario/*, item.PCA*/);
                    }
                    ////agregando las especies cites al 100 %. 
                    //if (itemCites.Count > 0)
                    //{
                    //    foreach (var item in itemCites)
                    //    {    //3. Significa que se agrega especies de tipo cites
                    //        dBOracle.ManExecute(cn, tr, "[FC].[uspPASPEQ_PlanTrabajoDetalleEspecieAdicional_Create]",
                    //            item.id, item.muestraAprov, item.muestraSem, 3, codUsuario);
                    //    }
                    //}

                    tr.Commit();
                }
                catch (Exception ex)
                {
                    tr.Rollback();
                    tr.Dispose();
                    tr = null;
                    throw ex;
                }
            }
            return true;
        }
        public bool PlanTrabajoDetalleMuestraMinima_Delete(long codPlanTrabajoSupervisionDetalle, string codUsuario)
        {
            string OUTPUTPARAM02 = "";
            using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
            {
                OracleTransaction tr = null;
                try
                {
                    cn.Open();
                    tr = cn.BeginTransaction();
                    //actualizando tamaño de la muestra en la tabla PLAN_TRABAJO_SUPERVISION_DETALLE                   
                    using (OracleCommand cmd = dBOracle.ManExecuteOutputV1(cn, tr, "FC_OSINFOR_ERP_MIGRACION.uspPASPEQ_PlanTrabajoDetalleMuestraMinima_Delete"))
                    {
                        OracleCommandBuilder.DeriveParameters(cmd);
                        cmd.Parameters["COD_PLAN_TRABAJO_SUPERVISION_DETALLE"].Value = codPlanTrabajoSupervisionDetalle;
                        cmd.Parameters["COD_UCUENTA_MODIFICAR"].Value = codUsuario;
                        cmd.Parameters["OUTPUTPARAM02"].Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        OUTPUTPARAM02 = (String)cmd.Parameters["OUTPUTPARAM02"].Value;
                        if (OUTPUTPARAM02 != "EXITO")
                        {
                            throw new Exception("0|" + OUTPUTPARAM02);
                        }
                    }
                    tr.Commit();
                }
                catch (Exception ex)
                {
                    tr.Rollback();
                    tr.Dispose();
                    tr = null;
                    throw ex;
                }
            }
            return true;
        }
        public List<VM_PlanTrabajoDetalleEspecie> PlanTrabajoDetGetMuestraMinima_GetByPTSD(long codPlanTrabajoSupervisionDetalle)
        {
            List<VM_PlanTrabajoDetalleEspecie> result = new List<VM_PlanTrabajoDetalleEspecie>();
            VM_PlanTrabajoDetalleEspecie vm;
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, "FC_OSINFOR_ERP_MIGRACION.uspPASPEQ_PlanTrabajoDetalleMuestraMinima_GetByPTSD", codPlanTrabajoSupervisionDetalle))
                    {
                        if (dr != null)
                        {

                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    vm = new VM_PlanTrabajoDetalleEspecie();
                                    vm.id = Convert.ToInt64(dr["COD_PLAN_T_DETALLE_ESPECIE"]);
                                    vm.idCabecera = Convert.ToInt64(dr["COD_PLAN_TRABAJO_SUPERVISION_DETALLE"]);
                                    vm.codEspecie = dr["CodEspecie"].ToString();
                                    vm.descripcionEspecie = dr["DescripcionEspecie"].ToString();
                                    vm.totalIndividuos = Convert.ToInt32(dr["TotalIndividuos"]);
                                    vm.numAprov = Convert.ToInt32(dr["NumAprov"]);
                                    vm.numSemilleros = Convert.ToInt32(dr["NumSemilleros"]);
                                    vm.factorAprov = Convert.ToDecimal(dr["FactorAprov"]);
                                    vm.factorSem = Convert.ToDecimal(dr["FactorSem"]);
                                    vm.muestraAprov = Convert.ToInt32(dr["MuestraAprov"]);
                                    vm.muestraSem = Convert.ToInt32(dr["MuestraSem"]);
                                    vm.muestraMinima = Convert.ToDecimal(dr["MuestraMinima"]);
                                    result.Add(vm);
                                }
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
        public decimal PlanTrabajoDetGetCantidadEspeciesCites_GetByPTSD(long codPlanTrabajoSupervisionDetalle)
        {
            decimal cantEspeciesCites = 0;
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, "FC_OSINFOR_ERP_MIGRACION.uspPASPEQ_PlanTrabajoDetGetCantidadEspeciesCites_GetByPTSD", codPlanTrabajoSupervisionDetalle))
                    {
                        if (dr != null)
                        {

                            if (dr.HasRows)
                            {
                                dr.Read();
                                cantEspeciesCites = Convert.ToDecimal(dr["CANTIDAD_ESPECIES_CITES"]);
                            }
                        }
                    }
                }
                return cantEspeciesCites;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool PlanTrabajoDetalleAdicionalOrigen_Create(VM_PlanTrabajoDetalleEspecie especieAdicional, string codUsuario)
        {
            string OUTPUTPARAM02 = "";
            using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
            {
                OracleTransaction tr = null;
                try
                {
                    cn.Open();
                    tr = cn.BeginTransaction();
                    //aqui verificar si esta aprobado por el funcionario el plan de trabajo
                    using (OracleCommand cmd = dBOracle.ManExecuteOutputV1(cn, tr, "FC_OSINFOR_ERP_MIGRACION.uspPASPEQ_PlanTrabajoDetalle_Verificar"))
                    {
                        OracleCommandBuilder.DeriveParameters(cmd);
                        cmd.Parameters["COD_PLAN_TRABAJO_SUPERVISION_DETALLE"].Value = especieAdicional.idCabecera;
                        cmd.Parameters["TIPO"].Value = "GENERAR_MUESTRA_ADICIONAL";
                        cmd.Parameters["OUTPUTPARAM02"].Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        OUTPUTPARAM02 = (String)cmd.Parameters["OUTPUTPARAM02"].Value;
                        if (OUTPUTPARAM02 != "EXITO")
                        {
                            throw new Exception("0|" + OUTPUTPARAM02);
                        }
                    }
                    OUTPUTPARAM02 = "";
                    using (OracleCommand cmd = dBOracle.ManExecuteOutputV1(cn, tr, "FC_OSINFOR_ERP_MIGRACION.uspPASPEQ_PlanTrabajoDetalleEspecieAdicionalOrigen_Create"))
                    {
                        OracleCommandBuilder.DeriveParameters(cmd);
                        cmd.Parameters["COD_PLAN_TRABAJO_SUPERVISION_DETALLE"].Value = especieAdicional.idCabecera;
                        cmd.Parameters["COD_PLAN_T_DETALLE_ESPECIE"].Value = especieAdicional.id;
                        cmd.Parameters["MUESTRA_APROVECHABLE"].Value = especieAdicional.muestraAprov;
                        cmd.Parameters["MUESTRA_SEMILLERO"].Value = especieAdicional.muestraSem;
                        cmd.Parameters["TIPO"].Value = especieAdicional.tipo;
                        cmd.Parameters["OBSERVACION"].Value = especieAdicional.obs;
                        cmd.Parameters["COD_UCUENTA_CREACION"].Value = codUsuario;
                        cmd.Parameters["OUTPUTPARAM02"].Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        OUTPUTPARAM02 = (String)cmd.Parameters["OUTPUTPARAM02"].Value;
                        if (OUTPUTPARAM02 != "EXITO")
                        {
                            throw new Exception("0|" + OUTPUTPARAM02);
                        }
                    }
                    tr.Commit();
                }
                catch (Exception ex)
                {
                    tr.Rollback();
                    tr.Dispose();
                    tr = null;
                    throw ex;
                }
            }
            return true;
        }
        public bool ModificarCantidadConsolidado(VM_PlanTrabajoDetalleEspecie especieConsolidado, string codUsuario)
        {
            string OUTPUTPARAM02 = "";
            using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
            {
                OracleTransaction tr = null;
                try
                {
                    cn.Open();
                    tr = cn.BeginTransaction();
                    //aqui verificar si esta aprobado por el funcionario el plan de trabajo
                    using (OracleCommand cmd = dBOracle.ManExecuteOutputV1(cn, tr, "FC_OSINFOR_ERP_MIGRACION.uspPASPEQ_PlanTrabajoDetalle_Verificar"))
                    {
                        OracleCommandBuilder.DeriveParameters(cmd);
                        cmd.Parameters["COD_PLAN_TRABAJO_SUPERVISION_DETALLE"].Value = especieConsolidado.idCabecera;
                        cmd.Parameters["TIPO"].Value = "MODIFICAR_MUESTRA_FINAL";
                        cmd.Parameters["OUTPUTPARAM02"].Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        OUTPUTPARAM02 = (String)cmd.Parameters["OUTPUTPARAM02"].Value;
                        if (OUTPUTPARAM02 != "EXITO")
                        {
                            throw new Exception("0|" + OUTPUTPARAM02);
                        }
                    }
                    OUTPUTPARAM02 = "";
                    using (OracleCommand cmd = dBOracle.ManExecuteOutputV1(cn, tr, "FC_OSINFOR_ERP_MIGRACION.uspPASPEQ_ModificarCantidadConsolidado"))
                    {
                        OracleCommandBuilder.DeriveParameters(cmd);
                        cmd.Parameters["COD_PLAN_TRABAJO_SUPERVISION_DETALLE"].Value = especieConsolidado.idCabecera;
                        cmd.Parameters["ID_MODIFICAR"].Value = especieConsolidado.idModificarFinal;
                        cmd.Parameters["MUESTRA_APROVECHABLE_FINAL"].Value = especieConsolidado.muestraAprovFinal;
                        cmd.Parameters["MUESTRA_SEMILLERO_FINAL"].Value = especieConsolidado.muestraSemFinal;
                        cmd.Parameters["FUENTE_ORIGEN"].Value = especieConsolidado.fuenteOrigen;
                        cmd.Parameters["OBSERVACION_FINAL"].Value = especieConsolidado.obsFinal;
                        cmd.Parameters["COD_UCUENTA_CREACION"].Value = codUsuario;
                        cmd.Parameters["OUTPUTPARAM02"].Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        OUTPUTPARAM02 = (String)cmd.Parameters["OUTPUTPARAM02"].Value;
                        if (OUTPUTPARAM02 != "EXITO")
                        {
                            throw new Exception("0|" + OUTPUTPARAM02);
                        }
                    }
                    tr.Commit();
                }
                catch (Exception ex)
                {
                    tr.Rollback();
                    tr.Dispose();
                    tr = null;
                    throw ex;
                }
            }
            return true;
        }
        public bool PlanTrabajoDetalleAdicionalOrigen_Delete(long id, long codPlanTrabajoSupervisionDetalle, string codUsuario)
        {
            string OUTPUTPARAM02 = "";
            using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
            {
                OracleTransaction tr = null;
                try
                {
                    cn.Open();
                    tr = cn.BeginTransaction();
                    //aqui verificar si esta aprobado por el funcionario el plan de trabajo
                    using (OracleCommand cmd = dBOracle.ManExecuteOutputV1(cn, tr, "FC_OSINFOR_ERP_MIGRACION.uspPASPEQ_PlanTrabajoDetalle_Verificar"))
                    {
                        OracleCommandBuilder.DeriveParameters(cmd);
                        cmd.Parameters["COD_PLAN_TRABAJO_SUPERVISION_DETALLE"].Value = codPlanTrabajoSupervisionDetalle;
                        cmd.Parameters["TIPO"].Value = "ELIMINAR_MUESTRA_ADICIONAL";
                        cmd.Parameters["OUTPUTPARAM02"].Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        OUTPUTPARAM02 = (String)cmd.Parameters["OUTPUTPARAM02"].Value;
                        if (OUTPUTPARAM02 != "EXITO")
                        {
                            throw new Exception("0|" + OUTPUTPARAM02);
                        }
                    }
                    dBOracle.ManExecute(cn, tr, "FC_OSINFOR_ERP_MIGRACION.uspPASPEQ_PlanTrabajoDetalleEspecieAdicionalOrigen_Delete", id, codUsuario);
                    tr.Commit();
                }
                catch (Exception ex)
                {
                    tr.Rollback();
                    tr.Dispose();
                    tr = null;
                    throw ex;
                }
            }
            return true;
        }
        public List<VM_PlanTrabajoDetalleEspecie> PlanTrabajoDetGetConsolidado_GetByPTSD(long codPlanTrabajoSupervisionDetalle)
        {
            List<VM_PlanTrabajoDetalleEspecie> result = new List<VM_PlanTrabajoDetalleEspecie>();
            VM_PlanTrabajoDetalleEspecie vm;
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, "FC_OSINFOR_ERP_MIGRACION.uspPASPEQ_PlanTrabajoDetalleConsolidado_GetByPTSD", codPlanTrabajoSupervisionDetalle))
                    {
                        if (dr != null)
                        {

                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    vm = new VM_PlanTrabajoDetalleEspecie();
                                    vm.id = Convert.ToInt64(dr["COD_PLAN_T_DETALLE_ESPECIE"]);
                                    vm.idCabecera = Convert.ToInt64(dr["COD_PLAN_TRABAJO_SUPERVISION_DETALLE"]);
                                    vm.idCodAdicional = Convert.ToInt64(dr["COD_ESPECIE_ADICIONAL_SUPERVISAR"]);
                                    vm.codEspecie = dr["CodEspecie"].ToString();
                                    vm.descripcionEspecie = dr["DescripcionEspecie"].ToString();
                                    vm.muestraAprov = Convert.ToInt32(dr["MuestraAprov"]);
                                    vm.muestraSem = Convert.ToInt32(dr["MuestraSem"]);
                                    vm.muestraAprovFinal = Convert.ToInt32(dr["MuestraAprovFinal"]);
                                    vm.muestraSemFinal = Convert.ToInt32(dr["MuestraSemFinal"]);
                                    vm.obsFinal = dr["OBSERVACION_FINAL"].ToString();
                                    vm.obs = dr["OBSERVACION"].ToString();
                                    vm.tipo = Convert.ToInt32(dr["TIPO"]);
                                    vm.puntajeTotalPorcentaje = Convert.ToDecimal(dr["PUNTAJE_FINAL_PORCENTAJE"]);
                                    vm.fuenteOrigen = Convert.ToInt32(dr["fuenteOrigen"]); //0 - MuestraAdicional, 1 - MuestraCalculada
                                    vm.idModificarFinal = Convert.ToInt64(dr["idModificar"]);
                                    //vm.PCA = dr["PCA"].ToString();
                                    result.Add(vm);
                                }
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
        #endregion
        #region "Planes de Manejo Extra-Ordinario"
        //codPlan, codTH, codPManejo, numPoa, idPlanTrajo, oportunidadSupId
        public bool GenerarUniversoExtraOrdinario(string COD_PLAN, string COD_THABILITANTE, string COD_PMANEJO, int NUM_POA, string COD_PLAN_TRABAJO_SUPERVISION, int OPORTUNIDAD_SUPERVISION, string codUsuario)
        {

            int OUTPUTPARAM = 0;
            using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
            {
                OracleTransaction tr = null;
                try
                {
                    cn.Open();
                    tr = cn.BeginTransaction();
                    //verificando si el plan de trabajo tiene control de calidad conforme
                    using (OracleCommand cmd = dBOracle.ManExecuteOutputV1(cn, tr, "FC_OSINFOR_ERP_MIGRACION.uspPLAN_UNIVERSO_Generar_Id"))
                    {
                        OracleCommandBuilder.DeriveParameters(cmd);
                        cmd.Parameters["COD_PLAN"].Value = COD_PLAN;
                        cmd.Parameters["COD_THABILITANTE"].Value = COD_THABILITANTE;
                        cmd.Parameters["COD_PMANEJO"].Value = COD_PMANEJO;
                        cmd.Parameters["NUM_POA"].Value = NUM_POA;
                        cmd.Parameters["OUTPUTPARAM"].Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        OUTPUTPARAM = Int32.Parse(cmd.Parameters["OUTPUTPARAM"].Value.ToString());
                        //if (OUTPUTPARAM02 != "EXITO")
                        //{
                        //    throw new Exception("0|" + OUTPUTPARAM02);
                        //}
                        //registrando plan de trabajo detalle

                    }
                    Ent_Focalizacion_PlanTrabajo_Detalle det = new Ent_Focalizacion_PlanTrabajo_Detalle()
                    {
                        COD_PLAN_TRABAJO_SUPERVISION = COD_PLAN_TRABAJO_SUPERVISION,
                        COD_PLAN = COD_PLAN,
                        COD_SECUENCIAL = OUTPUTPARAM,
                        TIPO_SUPERVISION = 5, //tipo ExtraOrdinario
                        OPORTUNIDAD_SUPERVISION = OPORTUNIDAD_SUPERVISION,
                        COD_UCUENTA_CREACION = codUsuario
                    };
                    string OUTPUTPARAM02 = "";
                    using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, tr, "FC_OSINFOR_ERP_MIGRACION.uspPASPEQ_PlanTrabajoDetalle_Create", det))
                    {
                        cmd.ExecuteNonQuery();
                        OUTPUTPARAM02 = (String)cmd.Parameters["OUTPUTPARAM02"].Value;
                        if (OUTPUTPARAM02 != "EXITO")
                        {
                            throw new Exception("0|" + OUTPUTPARAM02);
                        }
                    }
                    tr.Commit();
                    return true;
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
        }
        #endregion
    }
}
