using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CEntVM = CapaEntidad.ViewModel.VM_Meta;
using CEntidad = CapaEntidad.DOC.Ent_Meta;
using CDatos = CapaDatos.DOC.Dat_Meta;
using CapaEntidad.ViewModel;
using CapaEntidad.DOC;

namespace CapaLogica.DOC
{
    public class Log_Meta
    {
        public List<Dictionary<string, string>> GetListMeta(string busCriterio, string busValor)
        {
            CDatos dat = new CDatos();
            CEntidad ent = new CEntidad();
            ent.NU_TIPO = 1;
            if (busCriterio.Equals("Anio")) ent.NU_ANIO = Int32.Parse(busValor);
            return dat.GetAllMeta(ent);
        }

        public CEntVM AddEditMetaInit(string codigo, string coducuenta)
        {
            CEntVM vm = new CEntVM();

            vm.ddlTipoIndicador = new List<VM_Cbo>()
            {
                new VM_Cbo() { Value = "-", Text = "Seleccionar" },
                new VM_Cbo() { Value = "MAPRO", Text = "MAPRO" },
                new VM_Cbo() { Value = "PEI", Text = "PEI" }
            };

            List<VM_Cbo> lstCboItem = new List<VM_Cbo>();
            lstCboItem.Add(new VM_Cbo() { Value = "-", Text = "Seleccionar" });
            for (int i = DateTime.Now.Year; i >= 2018; i--)
                lstCboItem.Add(new VM_Cbo() { Value = i.ToString(), Text = i.ToString() });

            vm.ddlAnio = lstCboItem;

            vm.ddlPeriodo = new List<VM_Cbo>()
            {
                new VM_Cbo() { Value = "-", Text = "Seleccionar" },
                new VM_Cbo() { Value = "ANUAL", Text = "ANUAL" },
            };

            if (string.IsNullOrEmpty(codigo))
            {//nuevo       
                vm.lblTitulo = "Registro Nuevo";
                vm.ddlIndicador = new List<VM_Cbo> { new VM_Cbo { Value = "-", Text = "Seleccionar" } };
                vm.ddlAnio = new List<VM_Cbo> { new VM_Cbo { Value = "-", Text = "Seleccionar" } };
                vm.RegEstado = 1;
            }
            else
            {//edit
                vm.lblTitulo = "Modificar Registro";

                CDatos dat = new CDatos();
                CEntidad ent = new CEntidad();
                ent.NV_CODIGO = codigo;
                ent.NU_TIPO = 2;
                CEntVM vmEnt = dat.GetMeta(ent);

                vm.hdfCodMeta = vmEnt.hdfCodMeta;
                vm.ddlTipoIndicadorId = vmEnt.ddlTipoIndicadorId;
                vm.ddlIndicadorId = vmEnt.ddlIndicadorId;
                vm.ddlAnioId = vmEnt.ddlAnioId;
                vm.ddlPeriodoId = vmEnt.ddlPeriodoId;
                vm.txtValorMeta = vmEnt.txtValorMeta;
                vm.hdfEstado = vmEnt.hdfEstado;
                vm.RegEstado = vmEnt.RegEstado;

                Ent_IndicadorFiltro obj = new Ent_IndicadorFiltro();
                Log_IndicadorFiltro exe = new Log_IndicadorFiltro();
                obj = exe.RegMostCombo(new Ent_IndicadorFiltro() { TIPO = vm.ddlTipoIndicadorId });

                List<VM_Cbo> lstCboIndicadorItem = new List<VM_Cbo>();
                lstCboIndicadorItem.Add(new VM_Cbo() { Value = "-", Text = "Seleccionar" });
                foreach (var item in obj.ListIndicador)
                {
                    if (vm.ddlTipoIndicadorId == "MAPRO")
                    {
                        lstCboIndicadorItem.Add(new VM_Cbo() { Value = item.COD_INDICADOR, Text = item.CODIGO + " | " + item.DESCRIPCION, Tipo = item.META });
                    }
                    else
                    {
                        if (item.COD_INDICADOR== "0000017" || item.COD_INDICADOR == "0000019")
                        {
                            lstCboIndicadorItem.Add(new VM_Cbo() { Value = item.COD_INDICADOR, Text = item.DESCRIPCION });
                        }
                    }
                }
                vm.ddlIndicador = lstCboIndicadorItem;

                Ent_IndicadorFiltro param = new Ent_IndicadorFiltro();
                param.NV_CODIGO = vm.ddlIndicadorId;
                param.TIPO = "YEAR";
                param.COD_UCUENTA = coducuenta;

                obj = exe.RegMostComboAnio(param);

                List<VM_Cbo> lstCboAnioItem = new List<VM_Cbo>();
                lstCboAnioItem.Add(new VM_Cbo() { Value = "-", Text = "Seleccionar" });
                foreach (var item in obj.ListAnio)
                {
                    lstCboAnioItem.Add(new VM_Cbo() { Value = item.CODIGO, Text = item.DESCRIPCION });
                }
                vm.ddlAnio = lstCboAnioItem;
            }
            return vm;
        }

        public ListResult AddEditMeta(CEntVM vm, string codUsuario)
        {
            ListResult result = new ListResult();
            try
            {
                CEntidad ent = new CEntidad();
                ent.NV_CODIGO = vm.hdfCodMeta;
                ent.NV_INDICADOR = vm.ddlIndicadorId;
                ent.NU_ANIO = Int32.Parse(vm.ddlAnioId);
                ent.NV_PERIODO = vm.ddlPeriodoId;
                ent.NU_META = Decimal.Parse(vm.txtValorMeta);
                ent.NU_NUMERO = 1;
                ent.COD_UCUENTA = codUsuario;
                ent.RegEstado = vm.RegEstado;

                CDatos dat = new CDatos();
                string valor = dat.SaveMeta(ent);

                if (valor != "")
                {
                    result.success = true;
                    result.msj = valor.Split('|')[1];
                }
                else
                {
                    result.success = false;
                    result.msj = "Error en la operación";
                }
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
