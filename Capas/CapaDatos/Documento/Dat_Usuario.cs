using CapaEntidad.General;
using CapaEntidad.ViewModel;
using CapaEntidad.ViewModel.DOC;
using CapaEntidad.ViewModel.General;
using GeneralSQL;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
//using System.Data.SqlClient;
using CEntidad = CapaEntidad.DOC.Ent_Usuario;
using SQL = GeneralSQL.Data.SQL;

namespace CapaDatos.DOC
{
    public class Dat_Usuario
    {
        //private SQL oGDataSQL = new SQL();
        private DBOracle dBOracle = new DBOracle();

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
                        //Grupo
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
                        oCampos.ListCGrupo = lsDetDetalle;
                        dr.NextResult();
                    }
                }
                return oCampos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<VM_Cbo> GetCombo(OracleConnection cn, CEntidad oCEntidad)
        {
            List<VM_Cbo> listCbo = null;
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spGeneral_Combo_Listar", oCEntidad))
                {
                    if (dr != null)
                    {
                        VM_Cbo oCampos;
                        listCbo = new List<VM_Cbo>();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCampos = new VM_Cbo();
                                oCampos.Value = dr["CODIGO"].ToString();
                                oCampos.Text = dr["DESCRIPCION"].ToString();
                                listCbo.Add(oCampos);
                            }
                        }
                    }
                }
                return listCbo;
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
        //public CEntidad RegMostrarListaItem(OracleConnection cn, CEntidad oCEntidad)
        //{
        //    CEntidad oCampos = new CEntidad();
        //    CEntidad oCamposDet;
        //    try
        //    {
        //        using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "GENE.spUSUARIO_CUENTAMostrarItem", oCEntidad))
        //        {
        //            if (dr != null)
        //            {
        //                oCampos.ListMenuAsignado = new List<CEntidad>();
        //                oCampos.ListEliTABLA = new List<CEntidad>();

        //                if (dr.HasRows)
        //                {
        //                    //Datos Usuario
        //                    dr.Read();
        //                    oCampos.COD_UCUENTA = dr.GetString(dr.GetOrdinal("COD_UCUENTA"));
        //                    oCampos.COD_PERSONA = dr.GetString(dr.GetOrdinal("COD_PERSONA"));
        //                    oCampos.APELLIDOS_NOMBRES = dr.GetString(dr.GetOrdinal("APELLIDOS_NOMBRES"));
        //                    oCampos.USUARIO_LOGIN = dr.GetString(dr.GetOrdinal("USUARIO_LOGIN"));
        //                    oCampos.USUARIO_CONTRASENA = dr.GetString(dr.GetOrdinal("USUARIO_CONTRASENA"));
        //                    oCampos.COD_UGRUPO = dr.GetString(dr.GetOrdinal("COD_UGRUPO"));
        //                    oCampos.ESTADO_ACTIVO = dr.GetBoolean(dr.GetOrdinal("ESTADO_ACTIVO"));
        //                    oCampos.RegEstado = 0;
        //                    //Menu opciones asignadas
        //                    dr.NextResult();
        //                    if (dr.HasRows)
        //                    {
        //                        while (dr.Read())
        //                        {
        //                            oCamposDet = new CEntidad();
        //                            oCamposDet.COD_SMODULOS = dr.GetString(dr.GetOrdinal("COD_SMODULOS"));
        //                            oCamposDet.MODULO = dr.GetString(dr.GetOrdinal("MODULO"));
        //                            oCamposDet.COD_SMGRUPO = dr.GetString(dr.GetOrdinal("COD_SMGRUPO"));
        //                            oCamposDet.GRUPO = dr.GetString(dr.GetOrdinal("GRUPO"));
        //                            oCamposDet.COD_SECUENCIAL_PADRE = dr.GetInt32(dr.GetOrdinal("COD_SECUENCIAL_PADRE"));
        //                            oCamposDet.MENU_PADRE = dr.GetString(dr.GetOrdinal("MENU_PADRE"));
        //                            oCamposDet.COD_SECUENCIAL_HIJO = dr.GetInt32(dr.GetOrdinal("COD_SECUENCIAL_HIJO"));
        //                            oCamposDet.MENU_HIJO = dr.GetString(dr.GetOrdinal("MENU_HIJO"));
        //                            oCamposDet.MODULO_N_ORDEN = dr.GetInt32(dr.GetOrdinal("MODULO_N_ORDEN"));
        //                            oCamposDet.GRUPO_N_ORDEN = dr.GetInt32(dr.GetOrdinal("GRUPO_N_ORDEN"));
        //                            oCamposDet.ROL_NUEVO = dr.GetBoolean(dr.GetOrdinal("ROL_NUEVO"));
        //                            oCamposDet.ROL_MODIFICAR = dr.GetBoolean(dr.GetOrdinal("ROL_MODIFICAR"));
        //                            oCamposDet.ROL_ELIMINAR = dr.GetBoolean(dr.GetOrdinal("ROL_ELIMINAR"));
        //                            oCamposDet.RegEstado = 0;
        //                            oCampos.ListMenuAsignado.Add(oCamposDet);
        //                        }
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
        //public String RegGrabar(OracleConnection cn, CEntidad oCEntidad)
        //{
        //    OracleTransaction tr = null;
        //    String OUTPUTPARAM01 = "";
        //    CEntidad oCamposDet;
        //    try
        //    {
        //        tr = cn.BeginTransaction();
        //        //Grabando Cabecera
        //        using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, tr, "GENE.spUSUARIO_CUENTAGrabar", oCEntidad))
        //        {
        //            cmd.ExecuteNonQuery();
        //            OUTPUTPARAM01 = (String)cmd.Parameters["OUTPUTPARAM01"].Value;
        //            switch (OUTPUTPARAM01)
        //            {
        //                case "99":
        //                    tr.Rollback();
        //                    tr = null;
        //                    throw new Exception("Ud. no tiene permiso para realizar esta acción");
        //                case "0":
        //                    tr.Rollback();
        //                    tr = null;
        //                    throw new Exception("El usuario ya existe");
        //                case "1":
        //                    tr.Rollback();
        //                    tr = null;
        //                    throw new Exception("El usuario ya existe en otro registro");
        //                default:
        //                    break;
        //            }
        //        }
        //        //Reemplazando El Nuevo Codigo Creado
        //        if (oCEntidad.RegEstado == 1) //Nuevo
        //        {
        //            oCEntidad.COD_UCUENTA = OUTPUTPARAM01;
        //        }
        //        if (oCEntidad.ListEliTABLA != null)
        //        {
        //            foreach (var itemEli in oCEntidad.ListEliTABLA)
        //            {
        //                oCamposDet = new CEntidad();
        //                oCamposDet.COD_UCUENTA = oCEntidad.COD_UCUENTA;

        //                oCamposDet.EliTABLA = itemEli.EliTABLA;
        //                oCamposDet.EliVALOR01 = itemEli.EliVALOR01;
        //                oCamposDet.EliVALOR02 = itemEli.EliVALOR02;
        //                dBOracle.ManExecute(cn, tr, "GENE.spUSUARIO_CUENTAEliminarDetalle", oCamposDet);
        //            }
        //        }
        //        //Accesos (menú de opciones)
        //        if (oCEntidad.ListMenuAsignado != null)
        //        {
        //            foreach (var itemAsig in oCEntidad.ListMenuAsignado)
        //            {
        //                oCamposDet = new CEntidad();
        //                oCamposDet.COD_UCUENTA = oCEntidad.COD_UCUENTA;
        //                oCamposDet.COD_SMODULOS = itemAsig.COD_SMODULOS;
        //                oCamposDet.COD_SECUENCIAL = itemAsig.COD_SECUENCIAL_HIJO == 0 ? itemAsig.COD_SECUENCIAL_PADRE : itemAsig.COD_SECUENCIAL_HIJO;
        //                oCamposDet.ROL_NUEVO = itemAsig.ROL_NUEVO;
        //                oCamposDet.ROL_MODIFICAR = itemAsig.ROL_MODIFICAR;
        //                oCamposDet.ROL_ELIMINAR = itemAsig.ROL_ELIMINAR;
        //                oCamposDet.RegEstado = itemAsig.RegEstado;
        //                dBOracle.ManExecute(cn, tr, "GENE.spUSUARIO_CUENTA_DET_MMENUGrabar", oCamposDet);
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        //public Int32 RegEliminar(OracleConnection cn, CEntidad oCEntidad)
        //{
        //    try
        //    {
        //        Int32 RegNum = dBOracle.ManExecute(cn, null, "GENE.spUSUARIO_CUENTAEliminarDetalle", oCEntidad);

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
        //public List<CEntidad> RegMostrarMenuNoAsignado(OracleConnection cn, CEntidad oCEntidad)
        //{
        //    List<CEntidad> oListCampos = new List<CEntidad>();
        //    CEntidad oCamposDet;
        //    try
        //    {
        //        using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "GENE.spUSUARIO_CUENTA_MENUNoAsignado", oCEntidad))
        //        {
        //            if (dr != null)
        //            {
        //                if (dr.HasRows)
        //                {
        //                    while (dr.Read())
        //                    {
        //                        oCamposDet = new CEntidad();
        //                        oCamposDet.COD_SMODULOS = dr.GetString(dr.GetOrdinal("COD_SMODULOS"));
        //                        oCamposDet.MODULO = dr.GetString(dr.GetOrdinal("MODULO"));
        //                        oCamposDet.COD_SMGRUPO = dr.GetString(dr.GetOrdinal("COD_SMGRUPO"));
        //                        oCamposDet.GRUPO = dr.GetString(dr.GetOrdinal("GRUPO"));
        //                        oCamposDet.COD_SECUENCIAL_PADRE = dr.GetInt32(dr.GetOrdinal("COD_SECUENCIAL_PADRE"));
        //                        oCamposDet.MENU_PADRE = dr.GetString(dr.GetOrdinal("MENU_PADRE"));
        //                        oCamposDet.COD_SECUENCIAL_HIJO = dr.GetInt32(dr.GetOrdinal("COD_SECUENCIAL_HIJO"));
        //                        oCamposDet.MENU_HIJO = dr.GetString(dr.GetOrdinal("MENU_HIJO"));
        //                        oCamposDet.MODULO_N_ORDEN = dr.GetInt32(dr.GetOrdinal("MODULO_N_ORDEN"));
        //                        oCamposDet.GRUPO_N_ORDEN = dr.GetInt32(dr.GetOrdinal("GRUPO_N_ORDEN"));
        //                        oCamposDet.ROL_NUEVO = true;
        //                        oCamposDet.ROL_MODIFICAR = true;
        //                        oCamposDet.ROL_ELIMINAR = true;
        //                        oListCampos.Add(oCamposDet);
        //                    }
        //                }
        //            }
        //        }
        //        return oListCampos;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        #region "Sigo - V3"
        public bool SaveUsuario(CEntidad ent)
        {
            String OUTPUTPARAM02 = "";
            using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
            {
                OracleTransaction tr = null;
                try
                {
                    cn.Open();
                    tr = cn.BeginTransaction();
                    //Grabando Cabecera
                    using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, tr, "GENE_OSINFOR_ERP_MIGRACION.spUSUARIO_CUENTAGrabarV3", ent))
                    {
                        cmd.ExecuteNonQuery();
                        OUTPUTPARAM02 = (String)cmd.Parameters["OUTPUTPARAM02"].Value;
                        if (OUTPUTPARAM02 != "EXITO")
                        {
                            throw new Exception(OUTPUTPARAM02);
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
        public bool SaveUsuarioAccesoControl(CEntidad ent)
        {
            String OUTPUTPARAM01 = "";
            using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
            {
                OracleTransaction tr = null;
                try
                {
                    cn.Open();
                    tr = cn.BeginTransaction();
                    //Grabando Cabecera
                    using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, tr, "GENE_OSINFOR_ERP_MIGRACION.spUSUARIO_ACCESOCONTROLGrabarV3", ent))
                    {
                        cmd.ExecuteNonQuery();
                        OUTPUTPARAM01 = (String)cmd.Parameters["OUTPUTPARAM01"].Value;
                        if (OUTPUTPARAM01 != "EXITO")
                        {
                            throw new Exception(OUTPUTPARAM01);
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
        public bool SaveUsuarioMenu(List<Ent_Usuario_Menu> lstEnt)
        {

            using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
            {
                OracleTransaction tr = null;
                try
                {
                    cn.Open();
                    tr = cn.BeginTransaction();
                    //Grabando asignacion
                    foreach (var item in lstEnt)
                    {
                        dBOracle.ManExecute(cn, tr, "GENE_OSINFOR_ERP_MIGRACION.spUSUARIO_CUENTA_DET_MMENUGrabarV3", item);
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
        public bool SaveUsuarioPerfil(List<Ent_Usuario_Perfil> lstEnt)
        {

            using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
            {
                OracleTransaction tr = null;
                try
                {
                    cn.Open();
                    tr = cn.BeginTransaction();
                    //Grabando asignacion
                    foreach (var item in lstEnt)
                    {
                        dBOracle.ManExecute(cn, tr, "GENE_OSINFOR_ERP_MIGRACION.uspPerfil_Usuario_GrabarV3", item);
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
        public bool DeleteUsuarioAcceso(List<CEntidad> lstEnt)
        {

            using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
            {
                OracleTransaction tr = null;
                try
                {
                    cn.Open();
                    tr = cn.BeginTransaction();
                    //Grabando asignacion
                    foreach (var item in lstEnt)
                    {
                        dBOracle.ManExecute(cn, tr, "GENE_OSINFOR_ERP_MIGRACION.spUSUARIO_ACCESOCONTROLGrabarV3", item);
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

        public VM_Usuario GetIdUsuario(Ent_BUSQUEDA_V3 ent)
        {
            VM_Usuario vm = new VM_Usuario();
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "GENE_OSINFOR_ERP_MIGRACION.uspSistema_Seguridad_ListarV3", ent))
                    {
                        if (dr != null)
                        {
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    vm.id = dr["COD_UCUENTA"].ToString();
                                    vm.codPersona = dr["COD_PERSONA"].ToString();
                                    vm.desPersona = dr["APELLIDOS_NOMBRES"].ToString();
                                    vm.usuario = dr["USUARIO_LOGIN"].ToString();
                                    string COD_UGRUPO = dr["COD_UGRUPO"].ToString();
                                    vm.esPublico = COD_UGRUPO.Trim() == "0000013" ? true : false;
                                    vm.activo = Convert.ToBoolean(dr["ESTADO_ACTIVO"]);
                                    vm.ddlTipoPersonalId = dr["TIPO_PERSONAL"].ToString();
                                    vm.cargo = dr["CARGO"].ToString();
                                    vm.ddlLugarTrabajoId = dr["LUGAR_TRABAJO"].ToString();
                                    vm.oficina = dr["OFICINA"].ToString();
                                    vm.institucion = dr["INSTITUCION"].ToString();
                                    vm.estado = 0;
                                }
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
        public VM_Acceso GetIdAcceso(Ent_BUSQUEDA_V3 ent)
        {
            VM_Acceso vm = new VM_Acceso();
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "GENE_OSINFOR_ERP_MIGRACION.uspSistema_Seguridad_ListarV3", ent))
                    {
                        if (dr != null)
                        {
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    vm.id_acceso = dr.GetInt32(dr.GetOrdinal("ID_ACCESO"));
                                    vm.accesoNoCaduca = Convert.ToBoolean(dr["ACCESO_NOCADUCA"]);
                                    vm.fecha_registro = dr.GetString(dr.GetOrdinal("FECHA_CREACION"));
                                    vm.fecha_solicitud = dr.GetString(dr.GetOrdinal("FECHA_SOLICITUD"));
                                    vm.fecha_desde = dr.GetString(dr.GetOrdinal("FECHA_DESDE"));
                                    vm.fecha_hasta = dr.GetString(dr.GetOrdinal("FECHA_HASTA"));
                                    vm.estado = 1;
                                }
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
        public VM_Usuario_Menu GetIdUsuarioMenu(Ent_BUSQUEDA_V3 ent)
        {
            VM_Usuario_Menu vm = new VM_Usuario_Menu();
            vm.cboModulo = new List<VM_Cbo>();
            vm.cboGrupo = new List<VM_Cbo>();
            VM_Cbo cbo;
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "GENE_OSINFOR_ERP_MIGRACION.uspSistema_Seguridad_ListarV3", ent))
                    {
                        if (dr != null)
                        {
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    vm.codUsuario = dr["COD_UCUENTA"].ToString();
                                    vm.nUsuario = dr["APELLIDOS_NOMBRES"].ToString();
                                }
                            }
                            dr.NextResult();
                            if (dr.HasRows)
                            { //modulos
                                while (dr.Read())
                                {
                                    cbo = new VM_Cbo();
                                    cbo.Text = dr["DESCRIPCION"].ToString();
                                    cbo.Value = dr["CODIGO"].ToString();
                                    vm.cboModulo.Add(cbo);
                                }
                            }
                            dr.NextResult();
                            if (dr.HasRows)
                            { //grupos
                                while (dr.Read())
                                {
                                    cbo = new VM_Cbo();
                                    cbo.Text = dr["DESCRIPCION"].ToString();
                                    cbo.Value = dr["CODIGO"].ToString();
                                    vm.cboGrupo.Add(cbo);
                                }
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
        public List<VM_Perfil> GetAllUsuarioPerfil(Ent_BUSQUEDA_V3 ent)
        {
            List<VM_Perfil> listPerfil = new List<VM_Perfil>();
            VM_Perfil oCamposDet;
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "GENE_OSINFOR_ERP_MIGRACION.uspSistema_Seguridad_ListarV3", ent))
                    {
                        if (dr != null)
                        {

                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    oCamposDet = new VM_Perfil();
                                    oCamposDet.id = dr.GetString(dr.GetOrdinal("COD_SPERFIL"));
                                    oCamposDet.descr = dr.GetString(dr.GetOrdinal("DESCRIPCION"));
                                    oCamposDet.idSubClasificacion = dr.GetInt32(dr.GetOrdinal("NCODPERFILCLASIFICACION"));
                                    oCamposDet.descrSubClasificacion = dr.GetString(dr.GetOrdinal("SUBCLASIFICACION"));
                                    oCamposDet.idClasificacion = dr.GetInt32(dr.GetOrdinal("CODCLASIFICACION"));
                                    oCamposDet.descrClasificacion = dr.GetString(dr.GetOrdinal("CLASIFICACION"));

                                    if (ent.BusCriterio == "GET_ALL_PERFIL") oCamposDet.estado = 1;
                                    else oCamposDet.estado = 0;
                                    listPerfil.Add(oCamposDet);
                                }
                            }
                        }
                    }
                }
                return listPerfil;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool RegUpdateterminosUso(Ent_BUSQUEDA_V3 oCEntidad)
        {

            using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
            {
                OracleTransaction tr = null;
                try
                {
                    cn.Open();
                    tr = cn.BeginTransaction();
                    //Grabando asignacion
                    dBOracle.ManExecute(cn, tr, "GENE_OSINFOR_ERP_MIGRACION.uspSistema_Seguridad_ListarV3", oCEntidad);
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
        public List<VM_Acceso> GetAllUsuarioAcceso(Ent_BUSQUEDA_V3 ent)
        {
            List<VM_Acceso> listAcceso = new List<VM_Acceso>();
            VM_Acceso oCamposDet;
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "GENE_OSINFOR_ERP_MIGRACION.uspSistema_Seguridad_ListarV3", ent))
                    {
                        if (dr != null)
                        {

                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    oCamposDet = new VM_Acceso();
                                    oCamposDet.id_acceso = dr.GetInt32(dr.GetOrdinal("ID_ACCESO"));
                                    oCamposDet.accesoNoCaduca = Convert.ToBoolean(dr["ACCESO_NOCADUCA"]);
                                    oCamposDet.fecha_registro = dr.GetString(dr.GetOrdinal("FECHA_CREACION"));
                                    oCamposDet.fecha_solicitud = dr.GetString(dr.GetOrdinal("FECHA_SOLICITUD"));
                                    oCamposDet.fecha_desde = dr.GetString(dr.GetOrdinal("FECHA_DESDE"));
                                    oCamposDet.fecha_hasta = dr.GetString(dr.GetOrdinal("FECHA_HASTA"));
                                    if (ent.BusCriterio == "GET_ALL_ACCESO") oCamposDet.estado = 1;
                                    else oCamposDet.estado = 0;
                                    listAcceso.Add(oCamposDet);
                                }
                            }
                        }
                    }
                }
                return listAcceso;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public bool GetveriflecturaterminosUso(Ent_BUSQUEDA_V3 ent)
        //{
        //    VM_Acceso vm = new VM_Acceso();
        //    try
        //    {
        //        using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
        //        {
        //            cn.Open();
        //            using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "GENE.uspSistema_Seguridad_ListarV3", ent))
        //            {
        //                if (dr != null)
        //                {
        //                    if (dr.HasRows)
        //                    {
        //                        return false;
        //                    }                           
        //                }
        //            }
        //        }
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //Guardar Menu Rol Usuario
        public CEntidad _saveMenuRol(OracleConnection cn, CEntidad ent)
        {
            String OUTPUTPARAM01 = "";
            OracleTransaction tr = null;
            try
            {

                tr = cn.BeginTransaction();
                //Grabando Cabecera
                using (OracleCommand cm = new OracleCommand("GENE_OSINFOR_ERP_MIGRACION.SPUSUARIO_ROLMENU_GRABAR", cn))
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.Parameters.Add("NCODROL", ent.NCODROL);
                    cm.Parameters.Add("NCODMENU", ent.COD_SECUENCIAL);
                    cm.Parameters.Add("VCODUSUARIO", ent.COD_UCUENTA);
                    cm.Parameters.Add("VCODUSUARIO", ent.COD_UCUENTA_CREACION);

                    //cm.ExecuteNonQuery();
                    //OUTPUTPARAM01 = (String)cm.Parameters["OUTPUTPARAM01"].Value;
                    //if (OUTPUTPARAM01 != "EXITO")
                    //{
                    //    throw new Exception(OUTPUTPARAM01);
                    //}
                    using (OracleDataReader dr = cm.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    OUTPUTPARAM01 = dr["OUTPUTPARAM01"].ToString();
                                }
                            }
                        }
                    }
                    if (OUTPUTPARAM01 != "EXITO")
                    {
                        throw new Exception(OUTPUTPARAM01);
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
            return ent;
        }
        #endregion

    }
}
