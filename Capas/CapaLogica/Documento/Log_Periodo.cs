using CapaDatos.Documento;
using CapaEntidad.Documento;
using CapaEntidad.General;
using CapaEntidad.ViewModel;
using System;
using System.Collections.Generic;

namespace CapaLogica.Documento
{
    public class Log_Periodo
    {
        public List<Dictionary<string, string>> GetListPeriodo(string busCriterio, string busValor)
        {
            Dat_Periodo dat = new Dat_Periodo();
            Ent_BUSQUEDA_V3 ent = new Ent_BUSQUEDA_V3();
            ent.BusValor = busValor;
            ent.BusCriterio = busCriterio;
            return dat.GetAllPeriodo(ent);
        }

        public VM_Periodo AddEditPeriodoInit(string codigo)
        {
            VM_Periodo vm = new VM_Periodo();
            if (string.IsNullOrEmpty(codigo))
            {//nuevo
                vm = new VM_Periodo();
                vm.id = "";
                vm.act = true;
                vm.lblTitulo = "Nuevo Periodo";
                vm.estado = 1;
            }
            else
            {//edit
                Dat_Periodo dat = new Dat_Periodo();
                Ent_BUSQUEDA_V3 ent = new Ent_BUSQUEDA_V3();
                ent.BusCriterio = "GET_ID";
                ent.BusValor = codigo;
                vm = dat.GetIdPeriodo(ent);
                vm.lblTitulo = "Modificar Periodo";
            }
            return vm;
        }
        public ListResult AddEditPeriodo(VM_Periodo model, string codUsuario)
        {
            ListResult result = new ListResult();
            try
            {
                Ent_Periodo ent = new Ent_Periodo();
                ent.RegEstado = model.estado;
                ent.IDPERIODO = string.IsNullOrEmpty(model.id) ? "" : model.id.Trim();
                ent.MOTIVO = model.motivo;
                ent.ACTIVO = model.act ? 1 : 0;
                ent.OUTPUTPARAM01 = "";
                ent.OUTPUTPARAM02 = "";
                ent.COD_UCUENTA = codUsuario;
                Dat_Periodo dat = new Dat_Periodo();
                dat.SavePeriodo(ent);
                result.success = true;
                string msj = "";
                switch (ent.RegEstado)
                {
                    case 1: msj = "Se registro correctamente el periodo"; break;
                    case 0: msj = "Se modifico correctamente la periodo"; break;
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
    }
}
