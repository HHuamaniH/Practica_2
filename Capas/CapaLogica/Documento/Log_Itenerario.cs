using CapaDatos.DOC;
using CapaDatos.Documento;
using CapaEntidad.DOC;
using CapaEntidad.Documento;
using CapaEntidad.ViewModel;
using CapaEntidad.ViewModel.Documento;
//using iTextSharp.text.pdf.qrcode;
using System;
using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace CapaLogica.Documento
{
  public  class Log_Itenerario
    {
        private Dat_Itenerario dat_Itenerario;
        public List<VM_Itenerario_List> GetAll(string criterio, string valorBusqueda, int currentPage, int pageSize, string sort, ref int rowCount)
        {
            dat_Itenerario = new Dat_Itenerario();
            return dat_Itenerario.GetAll(criterio, valorBusqueda, currentPage, pageSize, sort, ref rowCount);
        }
        public List<VM_Itenerario_List> Reporte(string criterio, string valorBusqueda, int currentPage, int pageSize, string sort, ref int rowCount)
        {
            dat_Itenerario = new Dat_Itenerario();
            return dat_Itenerario.Reporte(criterio, valorBusqueda, currentPage, pageSize, sort, ref rowCount);
        }
        public List<Ent_BITACORA_SUPER> GetAllCartaNotificacion(string BusFormulario, string BusCriterio, string BusValor, string BusCriterio1 = "")
        {
            dat_Itenerario = new Dat_Itenerario();
            return dat_Itenerario.GetAllCartaNotificacion(BusFormulario, BusCriterio, BusValor, BusCriterio1);
        }
        public List<Ent_BITACORA_SUPER> GetAllItenerarioSupervision(string COD_BITACORA)
        {
            dat_Itenerario = new Dat_Itenerario();
            return  dat_Itenerario.GetAllItenerarioSupervision(COD_BITACORA);
        }
        public Ent_BITACORA_SUPER GetAllItenerarioSupervisionGetById(string COD_BITACORA, string COD_CNOTIFICACION, string COD_THABILITANTE, int COD_SECUENCIAL)
        {
            dat_Itenerario = new Dat_Itenerario();
            return dat_Itenerario.GetAllItenerarioSupervisionGetById(COD_BITACORA, COD_CNOTIFICACION, COD_THABILITANTE, COD_SECUENCIAL);
        }
        public List<VM_Cbo> ComboListar(string BUSFORMULARIO, string BUSCRITERIO, string BUSVALOR)
        {
            Dat_BUSQUEDA _datBusqueda = new Dat_BUSQUEDA();
            return _datBusqueda.RegMostComboSupervision(BUSFORMULARIO, BUSCRITERIO, BUSVALOR);
        }
        public VM_Itenerario GetById(string id)
        {
            dat_Itenerario = new Dat_Itenerario();
            Dat_BUSQUEDA _datBusqueda = new Dat_BUSQUEDA();
            VM_Itenerario vm;
            if (id == "0")
            {
                vm = new VM_Itenerario();
                vm.id = "0";
                vm.tbSupervisor = new List<CapaEntidad.DOC.Ent_GENEPERSONA>();
            }
            else
            {
                vm = dat_Itenerario.GetById(id);                
            }
            vm.od = _datBusqueda.RegMostComboSupervision("BITACORA_SUPER", "OD", " ");
            vm.ddPAuxilios = new List<VM_Cbo>() { new VM_Cbo() { Text = "Seleccionar", Value = "SN" },
                                                                    new VM_Cbo() { Text = "SI", Value = "S" },
                                                                    new VM_Cbo() { Text = "NO", Value = "N" }, };
            vm.ddIncidentes = new List<VM_Cbo>() { new VM_Cbo() { Text = "Seleccionar", Value = "SN" },
                                                                    new VM_Cbo() { Text = "SI", Value = "S" },
                                                                    new VM_Cbo() { Text = "NO", Value = "N" }, };

            return vm;
        }
        public string Guardar( VM_Itenerario vm,string codUCuenta)
        {
            dat_Itenerario = new Dat_Itenerario();
            Ent_Itenerario model = new Ent_Itenerario();
            model.FECHA_OPERACION = DateTime.Now;
            model.COD_BITACORA = vm.id;
            model.COD_OD = vm.odId;
            model.COD_UCUENTA = codUCuenta;
            model.FECHA_HORA_SALIDA = Convert.ToDateTime(vm.fechaSalida);
            model.FECHA_RECEPCION_CHEQUE =  string.IsNullOrEmpty(vm.fechaRecepcionCheque) ?  (DateTime?)null : Convert.ToDateTime(vm.fechaRecepcionCheque);
            model.FECHA_COBRO_CHEQUE = string.IsNullOrEmpty(vm.fechaCobroCheque) ? (DateTime?)null : Convert.ToDateTime(vm.fechaCobroCheque);
            model.RegEstado = vm.id == "0" ? 1 : 0;
           
            if (model.RegEstado == 0)
            {
                model.FECHA_RETORNO_CAMPO = string.IsNullOrEmpty(vm.fechaRetornoCampo)? (DateTime?)null : Convert.ToDateTime(vm.fechaRetornoCampo);
                model.FECHA_HORA_LLEGADA = string.IsNullOrEmpty(vm.fechaInicioLabores)? (DateTime?)null : Convert.ToDateTime(vm.fechaInicioLabores);
            }
            else
            {
                model.FECHA_RETORNO_CAMPO = null;
                model.FECHA_HORA_LLEGADA = null;
            }
            model.OBSERVACIONES = vm.observacion;
            if (vm.ddPAuxiliosId != "SN")
            {
                model.CAPACITACION_PAUXILIOS = vm.ddPAuxiliosId == "S" ? 1 : 0;
            }
            else
            {
                model.CAPACITACION_PAUXILIOS = null;
            }
            if (vm.ddIncidentesId != "SN")
            {
                model.CAPACITACION_INCIDENTES = vm.ddIncidentesId == "S" ? 1 : 0;
            }
            else
            {
                model.CAPACITACION_INCIDENTES = null;
            }
            model.ListInformeDetSupervisor = vm.tbSupervisor;
            model.ListEliTABLA = vm.ListEliTABLA;
            return dat_Itenerario.Guardar(model);
        }
        public bool EliminarBitacoraDetalle(Ent_BITACORA_SUPER entidad)
        {
            dat_Itenerario = new Dat_Itenerario();
            return dat_Itenerario.EliminarBitacoraDetalle(entidad);
        }
        public bool RegistrarCartaNotificacionBitacora(Ent_BITACORA_SUPER cartaNotificacionBitacora)
        {
            dat_Itenerario = new Dat_Itenerario();
            return dat_Itenerario.RegistrarCartaNotificacionBitacora(cartaNotificacionBitacora);
        }
    }
}
