using CapaEntidad.ViewModel;
using SIGOFCv3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CEntVM = CapaEntidad.ViewModel.VM_Veeduria;
using CEntidad = CapaEntidad.DOC.Ent_Veeduria;
using CLogica = CapaLogica.DOC.Log_Veeduria;

namespace SIGOFCv3.Areas.Supervision.Controllers
{
    public class AdmEquipoController : Controller
    {
        // GET: Supervision/AdmEquipo
        public ActionResult Index()
        {
            try
            {
                ViewBag.TituloFormulario = "Administrar Equipo";
                /*CLogica logExe = new CLogica();
                CEntidad param = new CEntidad() { NV_CATALOGO = "0000002" };
                CEntidad obj = logExe.ListarTipo(param);

                List<VM_Cbo> lstCboOrganizacion = new List<VM_Cbo>();
                lstCboOrganizacion.Add(new VM_Cbo() { Value = "0000000", Text = "Todos" });
                foreach (var item in obj.ListTipo)
                {
                    lstCboOrganizacion.Add(new VM_Cbo() { Value = item.NV_TIPO, Text = item.NV_DESCRIPCION, Group = item.NV_CATALOGO });
                }
                ViewBag.ddlOrganizacion = lstCboOrganizacion;*/

                ViewBag.ddlOpcion = new List<VM_Cbo>
                {
                    new VM_Cbo { Value = "100", Text = "Todos" },
                    new VM_Cbo { Value = "1", Text = "Comunidad" },
                    new VM_Cbo { Value = "2", Text = "Organización Regional" }
                };

                return View();
            }
            catch (Exception ex)
            {
                return RedirectToAction("ErrorC", "Login", new { Area = "" });
            }
        }

        [HttpGet]
        public JsonResult GetListaEquipo(int opcion, string txtvalor)
        {
            try
            {
                CLogica logExe = new CLogica();
                CEntidad param = new CEntidad();
                param.NU_CRITERIO = opcion;
                param.NV_VALOR = txtvalor;
                var lstEquipo = logExe.ListarEquipo(param);
                var jsonResult = Json(new { data = lstEquipo, success = true }, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }
            catch (Exception ex)
            {

                return Json(new { data = "", success = false, msjError = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult DetalleEquipo(string iddetalle)
        {
            try
            {
                CEntVM vm = new CEntVM();
                CLogica logExe = new CLogica();
                CEntidad param = new CEntidad() { NV_EQUIPO_INTEGRANTE_ORGANIZACION = iddetalle };
                CEntidad obj = logExe.MostrarEquipo(param);

                vm.lblTituloCabecera = "Administrar Equipo";
                vm.lblTituloEstado = "Detalle de registro";
                vm.hdfCodDetalle = obj.NV_EQUIPO_INTEGRANTE_ORGANIZACION;
                vm.txtcomunidad = obj.NV_COMUNIDAD;
                vm.txtubigeo = obj.UBIGEO;
                vm.txttipo = obj.TIPO;
                vm.txtorginterna = obj.NV_ORGINTERNA;
                vm.txtlugar = obj.NV_LUGAR;
                vm.txtorgregional = obj.NV_ORGREGIONAL;
                vm.txttipodoc = obj.TIPO_DOCUMENTO;
                vm.txtnumero = obj.NV_NUMERO;
                vm.txtintegrante = obj.INTEGRANTE;
                vm.txtfechaini = obj.FE_INICIO;
                vm.txtfechafin = obj.FE_TERMINO;

                return View(vm);
            }
            catch (Exception ex)
            {
                return RedirectToAction("ErrorC", "Login", new { Area = "" });
            }
        }

        [HttpPost]
        public JsonResult CambiarEstado(string idequipo, int estado)
        {
            ListResult result = new ListResult();
            try
            {
                CLogica logExe = new CLogica();
                CEntidad param = new CEntidad();
                param.NV_EQUIPO = idequipo;
                param.NU_ESTADO = estado;
                param.RegEstado = 1;
                param.COD_UCUENTA = (ModelSession.GetSession())[0].COD_UCUENTA;

                string valor = logExe.CambiarEstado(param);

                if (valor != "")
                {
                    result.AddResultado("Equipo " + ((estado == 1) ? "activado" : "inactivado") + " correctamente", true);
                }
                else
                {
                    result.AddResultado("Error en la operación", false);
                }
            }
            catch (Exception ex)
            {
                result.AddResultado(ex.Message, false);
            }
            return Json(result);
        }
    }
}