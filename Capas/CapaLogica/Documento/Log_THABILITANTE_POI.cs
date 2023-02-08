using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CEntVM = CapaEntidad.ViewModel.VM_THabilitantePOI;
using CEntidad = CapaEntidad.DOC.Ent_THABILITANTE_POI;
using CDatos = CapaDatos.DOC.Dat_THABILITANTE_POI;
using CapaEntidad.ViewModel;

namespace CapaLogica.DOC
{
    public class Log_THABILITANTE_POI
    {
        public List<Dictionary<string, string>> GetListTHabilitantePOI(string busCriterio, string busValor, string tipo)
        {
            CDatos dat = new CDatos();
            CEntidad ent = new CEntidad();
            ent.NV_TIPO = tipo;
            if (busCriterio.Equals("Anio")) ent.NU_ANIO = Int32.Parse(busValor);
            return dat.GetAllTHPOI(ent);
        }

        public CEntVM AddEditTHPOIInit(string codigo, string tipo)
        {
            CEntVM vm = new CEntVM();
            List<VM_Cbo> lstCboItem = new List<VM_Cbo>();
            lstCboItem.Add(new VM_Cbo() { Value = "0000", Text = "Seleccionar" });
            for (int i = DateTime.Now.Year; i >= 2018; i--)
                lstCboItem.Add(new VM_Cbo() { Value = i.ToString(), Text = i.ToString() });

            vm.ddlAnio = lstCboItem;

            switch (tipo)
            {
                case "POI":
                    vm.ddlTrimestre = new List<VM_Cbo>()
                    {
                        new VM_Cbo() { Value = "0", Text = "Seleccionar" },
                        new VM_Cbo() { Value = "1", Text = "1 TRIMESTRE" },
                        new VM_Cbo() { Value = "2", Text = "2 TRIMESTRE" },
                        new VM_Cbo() { Value = "3", Text = "3 TRIMESTRE" },
                        new VM_Cbo() { Value = "4", Text = "4 TRIMESTRE" }
                    };
                    break;

                case "PEI":
                    vm.ddlTrimestre = new List<VM_Cbo>()
                    {
                        new VM_Cbo() { Value = "0", Text = "Seleccionar" },
                        new VM_Cbo() { Value = "1", Text = "1 SEMESTRE" },
                        new VM_Cbo() { Value = "2", Text = "2 SEMESTRE" }
                    };
                    break;
            }

            if (string.IsNullOrEmpty(codigo))
            {//nuevo       
                vm.lblTitulo = "Registro Nuevo";
                vm.RegEstado = 1;
            }
            else
            {//edit
                CDatos dat = new CDatos();
                CEntidad ent = new CEntidad();
                vm.lblTitulo = "Modificar Registro";
                ent.NV_CODIGO = codigo;
                CEntVM vmEnt = dat.GetTHPOI(ent);
                vm.hdfCodTHPOI = vmEnt.hdfCodTHPOI;
                vm.ddlAnioId = vmEnt.ddlAnioId;
                vm.ddlTrimestreId = vmEnt.ddlTrimestreId;
                vm.txtValorAuditoria = vmEnt.txtValorAuditoria;
                vm.txtValorSupervision = vmEnt.txtValorSupervision;
                if (tipo == "PEI") vm.txtValorMedida = vmEnt.txtValorMedida;
                vm.hdfEstado = vmEnt.hdfEstado;
                vm.RegEstado = vmEnt.RegEstado;
            }
            return vm;
        }

        public ListResult AddEditTHPOI(CEntVM vm, string codUsuario, string tipo)
        {
            ListResult result = new ListResult();
            try
            {
                CEntidad ent = new CEntidad();
                ent.NV_CODIGO = vm.hdfCodTHPOI;
                ent.NV_TIPO = tipo;
                ent.NU_ANIO = Int32.Parse(vm.ddlAnioId);
                ent.NU_TRIMESTRE = Int32.Parse(vm.ddlTrimestreId);
                ent.NU_VALOR_AUDITORIA = Int32.Parse(vm.txtValorAuditoria);
                ent.NU_VALOR_SUPERVISION = Int32.Parse(vm.txtValorSupervision);
                if(tipo == "PEI") ent.NU_VALOR_MEDIDA = Int32.Parse(vm.txtValorMedida);
                ent.COD_UCUENTA = codUsuario;
                ent.ESTADO = (ent.RegEstado == 1) ? 1 : vm.hdfEstado;
                ent.RegEstado = vm.RegEstado;

                CDatos dat = new CDatos();
                string valor=dat.SaveTHPOI(ent);

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
