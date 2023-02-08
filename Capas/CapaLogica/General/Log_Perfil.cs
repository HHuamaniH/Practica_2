using CapaDatos;
using CapaDatos.General;
using CapaEntidad.General;
using CapaEntidad.ViewModel;
using CapaEntidad.ViewModel.General;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CapaLogica.General
{
    public class Log_Perfil
    {
        public List<Dictionary<string, string>> GetListClasificacionPerfil(int? id=null)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return new Dat_Perfil().GetListClasificacionPerfil(cn, id);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public VM_Menu_List _saveMenuRol(VM_Perfil_Menu_List ent)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return new Dat_Perfil()._saveMenuRol(cn, ent);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

            public List<Dictionary<string, string>> GetListPerfil(string busCriterio, string busValor, string clasificacion)
        {
            Dat_Perfil dat = new Dat_Perfil();
            Ent_BUSQUEDA_V3 ent = new Ent_BUSQUEDA_V3();
            ent.BusFormulario = "GET_ALL_PERFILES";
            ent.BusValor = busValor;
            ent.BusCriterio = busCriterio;
            ent.param01 = clasificacion;
            return dat.GetAllPerfil(ent);
        }

        public VM_Perfil AddEditPerfilInit(string codigo)
        {
            VM_Perfil vm;
            if (string.IsNullOrEmpty(codigo))
            {//nuevo
                vm = new VM_Perfil();
                vm.id = "";
                vm.act = true;
                vm.lblTitulo = "Nuevo Perfil";
                vm.estado = 1;
            }
            else
            {//edit
                Dat_Perfil dat = new Dat_Perfil();
                Ent_BUSQUEDA_V3 ent = new Ent_BUSQUEDA_V3();
                ent.BusFormulario = "GET_ID_PERFILES";
                ent.BusValor = codigo;
                vm = dat.GetIdPerfil(ent);
                vm.lblTitulo = "Modificar Perfil";
            }
            return vm;
        }
        public VM_Perfil_Menu PerfilMenuInit(string codPerfil)
        {
            VM_Perfil_Menu vm;
            Dat_Perfil dat = new Dat_Perfil();
            Ent_BUSQUEDA_V3 ent = new Ent_BUSQUEDA_V3();
            ent.BusFormulario = "GET_ID_PERFIL_MENU";
            ent.BusValor = codPerfil;
            vm = dat.GetIdPerfilMenu(ent);
            return vm;
        }
        public ListResult AddEditPerfil(VM_Perfil vm, string codUsuario)
        {
            ListResult result = new ListResult();
            try
            {
                Ent_Perfil ent = new Ent_Perfil();
                ent.RegEstado = vm.estado;
                ent.COD_SPERFIL = string.IsNullOrEmpty(vm.id) ? "" : vm.id.Trim();
                ent.DESCRIPCION = vm.descr;
                ent.COD_UCUENTA = codUsuario;
                ent.IDSUBCLASIFICACION = vm.idSubClasificacion.ToString();
                ent.ACTIVO = vm.act?1:0;
                ent.OUTPUTPARAM01 = "";
                ent.OUTPUTPARAM02 = "";
                Dat_Perfil dat = new Dat_Perfil();
                dat.SavePerfil(ent);
                result.success = true;
                string msj = "";
                switch (ent.RegEstado)
                {
                    case 1: msj = "Se registro correctamente el perfil"; break;
                    case 0: msj = "Se modifico correctamente la perfil"; break;
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
        public ListResult DeletePerfil(string id, string codUsuario)
        {
            ListResult result = new ListResult();
            try
            {
                Ent_Perfil ent = new Ent_Perfil();
                ent.RegEstado = 2;
                ent.COD_SPERFIL = id.Trim();
                ent.DESCRIPCION = "";
                ent.COD_UCUENTA = codUsuario;
                ent.OUTPUTPARAM01 = "";
                ent.OUTPUTPARAM02 = "";
                Dat_Perfil dat = new Dat_Perfil();
                dat.SavePerfil(ent);
                result.success = true;
                result.msj = "Se elimino correctamente el perfil";
            }
            catch (Exception ex)
            {
                result.success = false;
                result.msj = ex.Message;
            }
            return result;
        }
        public VM_Perfil_Menu_List GetAlltMenuAsignado(VM_Perfil_Menu_List vm)
        {
            Dat_Perfil dat = new Dat_Perfil();
            Ent_BUSQUEDA_V3 ent = new Ent_BUSQUEDA_V3();
            //obteniendo no asignados
            ent.BusFormulario = "GET_ALL_VARIOS";
            ent.BusCriterio = "GET_ALL_MENUS";
            ent.BusValor = vm.codPerfil;
            ent.param01 = vm.p1 == "0000000" ? null : vm.p1;
            ent.param02 = vm.p2 == "0000000" ? null : vm.p2;
            var resultNoAsignados = dat.GetAlltMenus(ent);
            //obteniendo asignados
            ent.BusFormulario = "GET_ALL_VARIOS";
            ent.BusCriterio = "GET_ALL_MENUS_ASIGNADO_PERFIL";
            ent.BusValor = vm.codPerfil;
            var result = dat.GetAlltMenus(ent);
            //if (vm.listMenusAsig != null)
            //{
            //    if (vm.listMenusAsig.Count() > 0)
            //    {   //Asignados
            //        foreach(var item in vm.listMenusAsig)
            //        {
            //            result.Add(item);
            //        }

            //        //No asignados
            //        //quitando datos a los asignados                   
            //        VM_Menu_List menuDelete;
            //        foreach (var itemNo in vm.listMenusAsig)
            //        {
            //            menuDelete = resultNoAsignados.Where(x => x.COD_SMODULOS == itemNo.COD_SMODULOS && x.COD_SMGRUPO==itemNo.COD_SMGRUPO
            //                                                   &&x.COD_SECUENCIAL_HIJO==itemNo.COD_SECUENCIAL_HIJO && x.COD_SECUENCIAL_PADRE==itemNo.COD_SECUENCIAL_PADRE).Single();                        
            //            resultNoAsignados.Remove(menuDelete);
            //            //resultNoAsignados.Remove(resultNoAsignados[0]);
            //        }

            //    }
            //}
            //if(vm.listMenusEli != null)
            //{
            //    if (vm.listMenusEli.Count() >)
            //    {
            //        //Quitando  
            //        VM_Menu_List menuDelete;
            //        foreach (var itemNo in vm.listMenusEli)
            //        {
            //            menuDelete = result.Where(x => x.COD_SMODULOS == itemNo.COD_SMODULOS && x.COD_SMGRUPO == itemNo.COD_SMGRUPO
            //                                                  && x.COD_SECUENCIAL_HIJO == itemNo.COD_SECUENCIAL_HIJO && x.COD_SECUENCIAL_PADRE == itemNo.COD_SECUENCIAL_PADRE).Single();

            //            result.Remove(itemNo);
            //        }
            //    }
            //}
            ////oredenando asignados
            //result = (from list in result
            //          orderby list.MODULO_N_ORDEN ascending, list.GRUPO_N_ORDEN ascending, list.MENU_PADRE descending
            //          select list).ToList();
            ////ordenando no asignados
            //resultNoAsignados = (from list in resultNoAsignados
            //                     orderby list.MODULO_N_ORDEN ascending, list.GRUPO_N_ORDEN ascending, list.MENU_PADRE descending
            //                     select list).ToList();
            VM_Perfil_Menu_List vmResult = new VM_Perfil_Menu_List();
            vmResult.listMenus = resultNoAsignados;
            vmResult.listMenusAsig = result;
            vmResult.codPerfil = vm.codPerfil;
            return vmResult;
        }
        public ListResult SavePerfilMenu(VM_Perfil_Menu_List vm, string codUsuario)
        {
            ListResult result = new ListResult();
            try
            {
                Ent_Perfil_Menu ent = new Ent_Perfil_Menu();
                ent.lstMenuNoAsignado = new List<Ent_Perfil_Menu>();
                int cantItem = 0;
                if (vm.listMenusAsig != null)
                {
                    cantItem = vm.listMenusAsig.Count();
                    if (cantItem > 0)
                    {
                        foreach (var item in vm.listMenusAsig)
                        {
                            ent.lstMenuNoAsignado.Add(new Ent_Perfil_Menu
                            {
                                COD_UCUENTA = codUsuario,
                                COD_SMODULOS = item.COD_SMODULOS,
                                COD_SECUENCIAL = item.COD_SECUENCIAL_HIJO == 0 ? item.COD_SECUENCIAL_PADRE : item.COD_SECUENCIAL_HIJO,
                                COD_SPERFIL = vm.codPerfil,
                                RegEstado = item.estado
                            });
                        }
                    }
                }
                if (cantItem == 0) throw new Exception("Seleccione items");
                Dat_Perfil dat = new Dat_Perfil();
                dat.SavePerfilMenu(ent);
                result.success = true;
                result.msj = vm.op == "A" ? "Se asigno correctamente al perfil" : "Se quito correctamente del perfil";
            }
            catch (Exception ex)
            {
                result.success = false;
                result.msj = ex.Message;
            }
            return result;
        }
    }
}
