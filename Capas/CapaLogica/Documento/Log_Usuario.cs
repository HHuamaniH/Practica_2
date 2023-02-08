using CapaDatos;
using CapaDatos.DOC;
//using CapaDatos.GENE;
using CapaDatos.General;
using CapaEntidad.DOC;
using CapaEntidad.GENE;
using CapaEntidad.General;
using CapaEntidad.ViewModel;
using CapaEntidad.ViewModel.DOC;
using CapaEntidad.ViewModel.General;
using CapaLogica.GENE;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
//using System.Data.SqlClient;
using System.Linq;
using CDatos = CapaDatos.DOC.Dat_Usuario;
using CEntidad = CapaEntidad.DOC.Ent_Usuario;

namespace CapaLogica.DOC
{
    public class Log_Usuario
    {
        private CDatos oCDatos = new CDatos();

        public CEntidad RegMostCombo(CEntidad oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegMostCombo(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //public CEntidad RegMostrarListaItem(CEntidad oCEntidad)
        //{
        //    try
        //    {
        //        using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena()))
        //        {
        //            cn.Open();
        //            return oCDatos.RegMostrarListaItem(cn, oCEntidad);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        //public String RegGrabar(CEntidad oCampoEntrada)
        //{
        //    try
        //    {
        //        using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena()))
        //        {
        //            cn.Open();
        //            return oCDatos.RegGrabar(cn, oCampoEntrada);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //public void RegEliminar(CEntidad oCampoEntrada)
        //{
        //    try
        //    {
        //        using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena()))
        //        {
        //            cn.Open();
        //            oCDatos.RegEliminar(cn, oCampoEntrada);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //public List<CEntidad> RegMostrarMenuNoAsignado(CEntidad oCEntidad)
        //{
        //    try
        //    {
        //        using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena()))
        //        {
        //            cn.Open();
        //            return oCDatos.RegMostrarMenuNoAsignado(cn, oCEntidad);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        #region "Sigo V3"
        public VM_Usuario UsuarioInt(string codigo)
        {
            VM_Usuario vm = new VM_Usuario();
            Dat_Usuario oCDatos = new Dat_Usuario();
            CEntidad oCEntidad = new CEntidad();
            if (string.IsNullOrEmpty(codigo))
            {//nuevo

                vm.id = "";
                vm.activo = true;
                vm.titulo = "Nuevo Usuario";
                vm.estado = 1;
            }
            else
            {//edit


                Ent_BUSQUEDA_V3 ent = new Ent_BUSQUEDA_V3();
                ent.BusFormulario = "USUARIO";
                ent.BusCriterio = "GET_ID_USUARIO";
                ent.BusValor = codigo;
                vm = oCDatos.GetIdUsuario(ent);
                vm.titulo = "Modificar Usuario";
            }
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    oCEntidad.BusFormulario = "USUARIO";
                    oCEntidad.BusCriterio = "TIPOPERSONAL";
                    vm.ddlTipoPersonal =  oCDatos.GetCombo(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    oCEntidad.BusFormulario = "USUARIO";
                    oCEntidad.BusCriterio = "LUGARTRABAJO";
                    vm.ddlLugarTrabajo = oCDatos.GetCombo(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            
            return vm;
        }
        public VM_Acceso AccesoInt(string codigo, int idAcceso)
        {
            VM_Acceso vm;
            if (idAcceso==0)
            {//nuevo
                vm = new VM_Acceso();
                vm.id_acceso = idAcceso;
                vm.codUsuario = codigo;
                vm.titulo = "Nuevo Control de Acceso del Usuario";
                vm.estado = 1;
            }
            else
            {//edit
                vm = new VM_Acceso();
                Dat_Usuario dat = new Dat_Usuario();
                Ent_BUSQUEDA_V3 ent = new Ent_BUSQUEDA_V3();
                ent.BusFormulario = "USUARIO";
                ent.BusCriterio = "GET_ID_ACCESO";
                ent.BusValor = codigo;
                ent.param01 = idAcceso.ToString();
                vm = dat.GetIdAcceso(ent);
                vm.id_acceso = idAcceso;
                vm.codUsuario = codigo;
                vm.titulo = "Modificar Control de Acceso del Usuario";
                vm.estado = 0;
            }
            return vm;
        }
        public VM_Usuario_Menu UsuarioMenuInit(string codUsuario)
        {
            Dat_Usuario dat = new Dat_Usuario();
            Ent_BUSQUEDA_V3 ent = new Ent_BUSQUEDA_V3();
            ent.BusFormulario = "USUARIO";
            ent.BusCriterio = "GET_ID_USUARIO_MENU";
            ent.BusValor = codUsuario;
            return dat.GetIdUsuarioMenu(ent);
        }
        public ListResult SaveUsuarioAccesoControl(VM_Acceso vm, string codUsuario)
        {
            ListResult result = new ListResult();
            try
            {
                Ent_Usuario ent = new Ent_Usuario();
                ent.RegEstado = vm.estado;
                ent.COD_UCUENTA = string.IsNullOrEmpty(vm.codUsuario) ? "" : vm.codUsuario.Trim();
                ent.COD_UCUENTA_CREACION = codUsuario;
                ent.COD_SECUENCIAL = vm.id_acceso;
                ent.ACCESO_NOCADUCA = vm.accesoNoCaduca;
                ent.FECHA_SOLICITUD = vm.fecha_solicitud;
                ent.FECHA_DESDE = vm.fecha_desde;
                ent.FECHA_HASTA = vm.fecha_hasta;
                ent.OUTPUTPARAM01 = "";
                Dat_Usuario dat = new Dat_Usuario();
                dat.SaveUsuarioAccesoControl(ent);
                result.success = true;
                string msj = "";
                switch (ent.RegEstado)
                {
                    case 1: msj = "El Registro se Guardo Correctamente"; break;
                    case 0: msj = "El Registro se Modifico Correctamente"; break;
                }
                result.msj = msj;
            }
            catch (Exception ex)
            {
                result.success = false;
                result.msj = ex.Message;
            }
            return result;
        }
        public ListResult SaveUsuariocambiarPass(VM_Usuario vm, string codUsuario)
        {
            ListResult result = new ListResult();
            try
            {
                Ent_USUARIO_CUENTA ent = new Ent_USUARIO_CUENTA();
                if (vm.passwordN == vm.passwordR && vm.passwordN != "")
                {
                    ent.COD_UCUENTA = codUsuario;
                    ent.USUARIO_CONTRASENA = vm.password;
                    ent.CONTRASENA_CAMBIAR = vm.passwordN;
                    ent.OUTPUTPARAM01 = "";
                    Log_USUARIO_CUENTA log = new Log_USUARIO_CUENTA();
                    if (log.RegUpdatePasswordSITD(ent) == "1")
                    { result.success = true;
                      result.msj = "La contraseña se modifico correctamente";
                    } else
                    {
                       result.msj = "La contraseña actual a cambiar no es correcta.";
                    }
                    
                }
                else { throw new Exception("Las contraseñas ingresadas no coinciden"); }
            }
            catch (Exception ex)
            {
                result.success = false;
                result.msj = ex.Message;
            }
            return result;
        }
        public ListResult SaveUsuarioterminosUso(VM_Usuario vm, string codUsuario)
        {
            ListResult result = new ListResult();
            try
            {
                Ent_BUSQUEDA_V3 ent = new Ent_BUSQUEDA_V3();
                ent.BusFormulario = "USUARIO";
                ent.BusCriterio = "SET_TERMINOS_USO";
                ent.BusValor = codUsuario;
                Dat_Usuario dat = new Dat_Usuario();
                if (dat.RegUpdateterminosUso(ent))
                {
                    result.success = true;
                }
                result.msj = "Se registro la lectura de términos de uso";
            }
            catch (Exception ex)
            {
                result.success = false;
                result.msj = ex.Message;
            }
            return result;
        }

        public ListResult SaveUsuario(VM_Usuario vm, string codUsuario)
        {
            ListResult result = new ListResult();
            try
            {

                Ent_Usuario ent = new Ent_Usuario();
                ent.RegEstado = vm.estado;
                ent.COD_UCUENTA = string.IsNullOrEmpty(vm.id) ? "" : vm.id.Trim();
                ent.COD_UCUENTA_CREACION = codUsuario;
                ent.COD_PERSONA = vm.codPersona;
                ent.USUARIO_LOGIN = vm.usuario;
                ent.ESTADO_ACTIVO = vm.activo;        
                ent.NOTIFICADO = vm.remPassword;
                ent.esPublico = vm.esPublico;
                ent.TIPO_PERSONAL = vm.ddlTipoPersonalId;
                ent.CARGO = vm.cargo;
                ent.LUGAR_TRABAJO = vm.ddlLugarTrabajoId;
                ent.OFICINA = vm.oficina;
                ent.INSTITUCION = vm.institucion;
                ent.esPublico = vm.esPublico;
                if (ent.COD_PERSONA.Trim() == "" || ent.USUARIO_LOGIN.Trim() == "")
                {
                    throw new Exception("Ingrese los datos de la persona");
                }
                if (string.IsNullOrEmpty(ent.CARGO)) { throw new Exception("Ingrese el cargo de la persona"); }
                if (string.IsNullOrEmpty(ent.OFICINA)) { throw new Exception("Ingrese la oficina de la persona"); }
                if (string.IsNullOrEmpty(ent.INSTITUCION)) { throw new Exception("Ingrese la institución de la persona"); }

                if (ent.RegEstado == 1 || (ent.RegEstado != 1 && vm.modPassword)) //Nuevo
                {
                    if (vm.password.Trim() != vm.passwordR.Trim())
                        throw new Exception("Las contraseñas ingresadas no coinciden");

                    ent.USUARIO_CONTRASENA = vm.password.Trim();
                }
                ent.OUTPUTPARAM01 = "";
                ent.OUTPUTPARAM02 = "";
                Dat_Usuario dat = new Dat_Usuario();
                dat.SaveUsuario(ent);
                result.success = true;
                string msj = "";
                switch (ent.RegEstado)
                {
                    case 1: msj = "El Registro se Guardo Correctamente"; break;
                    case 0: msj = "El Registro se Modifico Correctamente"; break;
                }
                result.msj = msj;
            }
            catch (Exception ex)
            {
                result.success = false;
                result.msj = ex.Message;
            }
            return result;
        }
        public VM_Usuario_Menu_List GetAllUsuarioMenu(VM_Usuario_Menu_List vm)
        {
            Dat_Perfil dat = new Dat_Perfil();
            Ent_BUSQUEDA_V3 ent = new Ent_BUSQUEDA_V3();
            //obteniendo no asignados
            ent.BusFormulario = "USUARIO";
            ent.BusCriterio = "GET_ALL_MENUS";
            ent.BusValor = vm.codUsuario;
            ent.param01 = vm.p1 == "0000000" ? null : vm.p1;
            ent.param02 = vm.p2 == "0000000" ? null : vm.p2;
            var resultNoAsignados = dat.GetAlltMenus(ent);
            //obteniendo asignados
            ent.BusFormulario = "USUARIO";
            ent.BusCriterio = "GET_ALL_MENUS_USUARIO";
            var result = dat.GetAlltMenus(ent);
            VM_Usuario_Menu_List vmResult = new VM_Usuario_Menu_List();
            vmResult.listMenus = resultNoAsignados;
            vmResult.listMenusAsig = result;
            vmResult.codUsuario = vm.codUsuario;
            return vmResult;
        }
        public VM_Usuario_Perfil_List GetAllUsuarioPerfil(VM_Usuario_Perfil_List vm)
        {
            Dat_Usuario dat = new Dat_Usuario();
            Ent_BUSQUEDA_V3 ent = new Ent_BUSQUEDA_V3();
            //obteniendo no asignados
            ent.BusFormulario = "USUARIO";
            ent.BusCriterio = "GET_ALL_PERFIL";
            ent.BusValor = vm.codUsuario;
            ent.param01 = vm.p1;
            ent.param02 = vm.p2;
            var resultNoAsignados = dat.GetAllUsuarioPerfil(ent);
            //obteniendo asignados           
            ent.BusCriterio = "GET_ALL_PERFIL_USUARIO";
            var result = dat.GetAllUsuarioPerfil(ent);
            VM_Usuario_Perfil_List vmResult = new VM_Usuario_Perfil_List();
            vmResult.listPerfil = resultNoAsignados;
            vmResult.listPerfilAsig = result;
            vmResult.codUsuario = vm.codUsuario;
            return vmResult;
        }
        public VM_Usuario_Perfil_List GetUsuarioPerfil(VM_Usuario_Perfil_List vm)
        {
            Dat_Usuario dat = new Dat_Usuario();
            Ent_BUSQUEDA_V3 ent = new Ent_BUSQUEDA_V3();
            //obteniendo no asignados
            ent.BusFormulario = "USUARIO";
            //obteniendo asignados           
            ent.BusCriterio = "GET_ALL_PERFIL_USUARIO";
            ent.BusValor = vm.codUsuario;
            var result = dat.GetAllUsuarioPerfil(ent);
            VM_Usuario_Perfil_List vmResult = new VM_Usuario_Perfil_List();
            vmResult.listPerfilAsig = result;
            vmResult.codUsuario = vm.codUsuario;
            return vmResult;
        }

        public VM_Acceso GetAllUsuarioAcceso(VM_Acceso vm)
        {
            Dat_Usuario dat = new Dat_Usuario();
            Ent_BUSQUEDA_V3 ent = new Ent_BUSQUEDA_V3();
            //obteniendo asignados           
            ent.BusFormulario = "GET_ALL_ACCESO";
            ent.BusCriterio = "GET_ALL_ACCESO_USUARIO";
            ent.BusValor= vm.codUsuario;
            var result = dat.GetAllUsuarioAcceso(ent);
            VM_Acceso vmResult = new VM_Acceso();     
            vmResult.listAccesoAsig = result;
            vmResult.codUsuario = vm.codUsuario;
            return vmResult;
        }

        public ListResult SaveUsuarioMenu(VM_Usuario_Menu_List vm, string codUsuario)
        {
            ListResult result = new ListResult();
            try
            {
                List<Ent_Usuario_Menu> lstEnt = new List<Ent_Usuario_Menu>();
                int cantItem = 0;
                if (vm.listMenusAsig != null)
                {
                    cantItem = vm.listMenusAsig.Count();
                    if (cantItem > 0)
                    {
                        foreach (var item in vm.listMenusAsig)
                        {
                            lstEnt.Add(new Ent_Usuario_Menu()
                            {
                                COD_UCUENTA = vm.codUsuario,
                                COD_SMODULOS = item.COD_SMODULOS,
                                COD_SECUENCIAL = item.COD_SECUENCIAL_HIJO == 0 ? item.COD_SECUENCIAL_PADRE : item.COD_SECUENCIAL_HIJO,
                                COD_UCUENTA_CREACION = codUsuario,
                                RegEstado = item.estado
                            });
                        }
                    }
                }
                if (cantItem == 0) throw new Exception("Seleccione al menos una opción");
                Dat_Usuario dat = new Dat_Usuario();
                dat.SaveUsuarioMenu(lstEnt);
                result.success = true;
                result.msj = vm.op == "A" ? "Se asigno correctamente la opción" : "Se quito correctamente la opción";
            }
            catch (Exception ex)
            {
                result.success = false;
                result.msj = ex.Message;
            }
            return result;
        }



        public ListResult SaveUsuarioPerfil(VM_Usuario_Perfil_List vm, string codUsuario)
        {
            ListResult result = new ListResult();
            try
            {
                List<Ent_Usuario_Perfil> lstEnt = new List<Ent_Usuario_Perfil>();
                int cantItem = 0;
                if (vm.listPerfilAsig != null)
                {
                    cantItem = vm.listPerfilAsig.Count();
                    if (cantItem > 0)
                    {
                        foreach (var item in vm.listPerfilAsig)
                        {
                            lstEnt.Add(new Ent_Usuario_Perfil
                            {
                                COD_UCUENTA = vm.codUsuario,
                                COD_UCUENTA_CREACION = codUsuario,
                                COD_SPERFIL = item.id,
                                RegEstado = item.estado
                            });
                        }
                    }
                }
                if (cantItem == 0) throw new Exception("Seleccione al menos un perfil");
                Dat_Usuario dat = new Dat_Usuario();
                dat.SaveUsuarioPerfil(lstEnt);
                result.success = true;
                result.msj = vm.op == "A" ? "Se asigno correctamente el perfil" : "Se quito correctamente el perfil";
            }
            catch (Exception ex)
            {
                result.success = false;
                result.msj = ex.Message;
            }
            return result;
        }


        public ListResult DeleteUsuarioAcceso(VM_Acceso vm, string codUsuario)
        {
            ListResult result = new ListResult();
            try
            {
                List<Ent_Usuario> lstEnt = new List<Ent_Usuario>();
                int cantItem = 0;
                if (vm.listAccesoAsig != null)
                {
                    cantItem = vm.listAccesoAsig.Count();
                    if (cantItem > 0)
                    {
                        foreach (var item in vm.listAccesoAsig)
                        {
                            lstEnt.Add(new Ent_Usuario
                            {
                                COD_UCUENTA = vm.codUsuario,
                                COD_UCUENTA_CREACION = codUsuario,
                                COD_SECUENCIAL = item.id_acceso,
                                OUTPUTPARAM01="",
                                RegEstado = 2
                            });
                        }
                    }
                }
                if (cantItem == 0) throw new Exception("Seleccione al menos un control de acceso");
                Dat_Usuario dat = new Dat_Usuario();
                dat.DeleteUsuarioAcceso(lstEnt);
                result.success = true;
                result.msj = vm.op == "A" ? "Se asigno correctamente el perfil" : "Se quito correctamente el perfil";
            }
            catch (Exception ex)
            {
                result.success = false;
                result.msj = ex.Message;
            }
            return result;
        }


        public String veriflecturaterminosUso(string codUsuario)
        {
            try
            {
                Dat_Usuario dat = new Dat_Usuario();
                Ent_BUSQUEDA_V3 ent = new Ent_BUSQUEDA_V3();
                //obteniendo asignados           
                ent.BusFormulario = "USUARIO";
                ent.BusCriterio = "GET_TERMINOS_USO";
                ent.BusValor = codUsuario;
                VM_Usuario vmResult = new VM_Usuario();
                // if (dat.GetveriflecturaterminosUso(ent)) { return "1"; }
                // return "0";
                return "1";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CEntidad _saveMenuRol(CEntidad ent)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return new Dat_Usuario()._saveMenuRol(cn, ent);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }




        #endregion
    }
}
