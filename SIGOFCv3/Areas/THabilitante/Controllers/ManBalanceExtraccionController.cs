using CapaEntidad.DOC;
using CapaEntidad.ViewModel;
using CapaEntidad.ViewModel.General;
using CapaLogica.DOC;
using SIGOFCv3.Areas.THabilitante.Models.ManBalanceExtraccion;
using SIGOFCv3.Helper;
using SIGOFCv3.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace SIGOFCv3.Areas.THabilitante.Controllers
{
    public class ManBalanceExtraccionController : Controller
    {
        private Log_BEXTRACCION exeBExt;

        public ManBalanceExtraccionController()
        {
            exeBExt = new Log_BEXTRACCION();
        }

        #region "General"
        //Validar que el usuario que ingresa a la acción (vista) tenga asignado el menú respectivo (Tabla: SISTEMA_MODULOS_DET_MENU: Columna: COD_SECUENCIAL)
        public ActionResult Index(string _alertaIncial = "")
        {
            ViewBag.Formulario = "PMANEJO_BEXTRACCION";
            ViewBag.TituloFormulario = "Balances de extracción de los planes de manejo";
            ViewBag.AlertaInicial = _alertaIncial;
            //obtenemos el rol sobre el formulario
            VM_Menu_Rol mr = HelperSigo.GetRol("MODULO TITULO HABILITANTE", "Balance de Extracción");
            ViewBag.CodRol = mr.NCODROL;
            ViewBag.VAliasRol = mr.VALIAS;
            return View();
        }

        public ActionResult AddEdit(string asCodTHabilitante, int aiNumPoa)
        {
            try
            {
                VM_BalanceExtraccion vm = exeBExt.Init(asCodTHabilitante, aiNumPoa);
                //obtenemos el rol sobre el formulario
                VM_Menu_Rol mr = HelperSigo.GetRol("MODULO TITULO HABILITANTE", "Balance de Extracción");
                ViewBag.CodRol = mr.NCODROL;
                ViewBag.VAliasRol = mr.VALIAS;
                return View(vm);
            }
            catch (Exception)
            {
                return RedirectToAction("ErrorC", "Login", new { Area = "" });
            }
        }

        public ActionResult ListarBExtraccionPorPlan(string asCodTHabilitante, int aiNumPoa)
        {
            try
            {
                var result = exeBExt.ListarBExtraccionPorPlan(asCodTHabilitante, aiNumPoa);

                return Json(new { success = true, data = result }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Ocurrió un error, comuníquese con el administrador." }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult EliminarBExtraccion(Ent_BEXTRACCION_EliTABLA dto)
        {
            ListResult result = exeBExt.EliminarBExtraccion(dto);

            return Json(result);
        }

        [HttpPost]
        public JsonResult ImportarBExtraccion(string asTipo, string asCodTHabilitante, int aiNumPoa, int aiCodSecuencialBExt, string asCodMTipo,
            string asEstadoOrigen, string asIndicador)
        {
            IEnumerable<Object> result = new List<Object>(); ;

            try
            {
                if (Request != null)
                {
                    switch (asTipo)
                    {
                        case "BEXTRACCION_MADE": result = ImportarDatos.BExtraccionMaderable(Request, asCodTHabilitante, aiNumPoa, aiCodSecuencialBExt, asCodMTipo, asEstadoOrigen, asIndicador); break;
                        case "BEXTRACCION_NOMADE": result = ImportarDatos.BExtraccionNoMaderable(Request, asCodTHabilitante, aiNumPoa, aiCodSecuencialBExt, asCodMTipo); break;
                    }
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msj = ex.Message });
            }

            return Json(new { success = true, msj = "", data = result });
        }

        [HttpPost]
        public JsonResult DescargarBExtraccion(string asTipo, string asCodTHabilitante, int aiNumPoa, int aiCodSecuencialBExt, string asCodMTipo,
            string asEstadoOrigen, string asIndicador)
        {
            ListResult result = new ListResult();

            switch (asTipo)
            {
                case "BEXTRACCION_MADE":
                    var lstMaderable = exeBExt.ListarBExtraccionMaderable(asCodTHabilitante, aiNumPoa, aiCodSecuencialBExt);
                    result = ExportarDatos.BExtraccionMaderable(lstMaderable, asCodMTipo, asEstadoOrigen, asIndicador);
                    break;
                case "BEXTRACCION_NOMADE":
                    var lstNoMaderable = exeBExt.ListarBExtraccionNoMaderable(asCodTHabilitante, aiNumPoa, aiCodSecuencialBExt);
                    result = ExportarDatos.BExtraccionNoMaderable(lstNoMaderable, asCodMTipo);
                    break;
            }
            return Json(result);
        }

        [HttpGet]
        //[DeleteFileAttribute]
        public ActionResult Download(string file)
        {
            if (!file.Contains(":"))
            {
                string fullPath = Path.Combine(Server.MapPath("~/Archivos/Plantilla"), file);
                return File(fullPath, "application/vnd.ms-excel", file);
            }
            else
            {
                return Json(new { success = false, message = "Archivo de descarga no permitido." }, JsonRequestBehavior.AllowGet);
            }
            
        }
        #endregion
        #region "Fecha de Emisión"
        [HttpPost]
        public PartialViewResult _BExtraccionFecEmi(string asCodTHabilitante, int aiNumPoa)
        {
            ViewBag.hdfCodTHabilitante = asCodTHabilitante;
            ViewBag.hdfNumPoa = aiNumPoa;

            return PartialView();
        }

        [HttpPost]
        public JsonResult GrabarBExtraccionFecEmi(Ent_BEXTRACCION_FECEMI dto)
        {
            ListResult result = exeBExt.GrabarBExtraccionFecEmi(dto, (ModelSession.GetSession())[0].COD_UCUENTA);

            return Json(result);
        }
        #endregion
        #region "Maderable"
        public ActionResult ListarBExtraccionMaderable(string asCodTHabilitante, int aiNumPoa, int aiCodSecuencialBExt)
        {
            try
            {
                var result = exeBExt.ListarBExtraccionMaderable(asCodTHabilitante, aiNumPoa, aiCodSecuencialBExt);

                return Json(new { success = true, data = result }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Ocurrió un error, comuníquese con el administrador." }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public PartialViewResult _BExtraccionMaderable(string asCodTHabilitante, int aiNumPoa, int aiCodSecuencialBExt)
        {
            ViewBag.hdfCodTHabilitante = asCodTHabilitante;
            ViewBag.hdfNumPoa = aiNumPoa;
            ViewBag.hdfCodSecuencialBExt = aiCodSecuencialBExt;

            Ent_POA oCampos = new Ent_POA() { COD_UCUENTA = (ModelSession.GetSession())[0].COD_UCUENTA, BusFormulario = "POA", BusCriterio = "POA_GENERAL", COD_THABILITANTE = asCodTHabilitante, BusValor2 = aiNumPoa };
            Log_POA exePoa = new Log_POA();
            oCampos = exePoa.RegMostCombo(oCampos);

            var lstEspeciesSerfor = oCampos.ListMComboEspeciesSerfor.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION }).ToList();
            lstEspeciesSerfor.Insert(0, new VM_Cbo { Value = "-", Text = "Seleccionar" });
            ViewBag.lstEspeciesSerfor = lstEspeciesSerfor;

            var lstEspecies = oCampos.ListMComboEspecies.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION }).ToList();
            lstEspecies.Insert(0, new VM_Cbo { Value = "-", Text = "Seleccionar" });
            ViewBag.lstEspecies = lstEspecies;

            var lstParcelas = oCampos.ListParcela.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION }).ToList();
            lstEspecies.Insert(0, new VM_Cbo { Value = "-", Text = "Seleccionar" });
            ViewBag.lstParcelas = lstParcelas;

            return PartialView();
        }

        [HttpPost]
        public JsonResult GrabarBExtraccionMaderable(Ent_BEXTRACCION_MADE dto)
        {
            List<Ent_BEXTRACCION_MADE> olMaderable = new List<Ent_BEXTRACCION_MADE>();
            olMaderable.Add(dto);

            ListResult result = exeBExt.GrabarBExtraccionMaderable(olMaderable, (ModelSession.GetSession())[0].COD_UCUENTA);

            return Json(result);
        }

        [HttpPost]
        public JsonResult GrabarBExtraccionMaderableLista(List<Ent_BEXTRACCION_MADE> lstMaderable)
        {
            ListResult result = exeBExt.GrabarBExtraccionMaderable(lstMaderable, (ModelSession.GetSession())[0].COD_UCUENTA);

            return Json(result);
        }
        #endregion
        #region "No Maderable"
        public ActionResult ListarBExtraccionNoMaderable(string asCodTHabilitante, int aiNumPoa, int aiCodSecuencialBExt)
        {
            try
            {
                var result = exeBExt.ListarBExtraccionNoMaderable(asCodTHabilitante, aiNumPoa, aiCodSecuencialBExt);

                return Json(new { success = true, data = result }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public PartialViewResult _BExtraccionNoMaderable(string asCodTHabilitante, int aiNumPoa, int aiCodSecuencialBExt)
        {
            ViewBag.hdfCodTHabilitante = asCodTHabilitante;
            ViewBag.hdfNumPoa = aiNumPoa;
            ViewBag.hdfCodSecuencialBExt = aiCodSecuencialBExt;

            Ent_POA oCampos = new Ent_POA() { COD_UCUENTA = (ModelSession.GetSession())[0].COD_UCUENTA, BusFormulario = "POA", BusCriterio = "POA_GENERAL" };
            Log_POA exePoa = new Log_POA();
            oCampos = exePoa.RegMostCombo(oCampos);
            var lstEspeciesSerfor = oCampos.ListMComboEspeciesSerfor.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION }).ToList();
            lstEspeciesSerfor.Insert(0, new VM_Cbo { Value = "-", Text = "Seleccionar" });
            ViewBag.lstEspeciesSerfor = lstEspeciesSerfor;

            var lstEspecies = oCampos.ListMComboEspecies.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION }).ToList();
            lstEspecies.Insert(0, new VM_Cbo { Value = "-", Text = "Seleccionar" });
            ViewBag.lstEspecies = lstEspecies;

            return PartialView();
        }

        [HttpPost]
        public JsonResult GrabarBExtraccionNoMaderable(Ent_BEXTRACCION_NOMADE dto)
        {
            List<Ent_BEXTRACCION_NOMADE> olNoMaderable = new List<Ent_BEXTRACCION_NOMADE>();
            olNoMaderable.Add(dto);

            ListResult result = exeBExt.GrabarBExtraccionNoMaderable(olNoMaderable, (ModelSession.GetSession())[0].COD_UCUENTA);

            return Json(result);
        }

        [HttpPost]
        public JsonResult GrabarBExtraccionNoMaderableLista(List<Ent_BEXTRACCION_NOMADE> lstNoMaderable)
        {
            ListResult result = exeBExt.GrabarBExtraccionNoMaderable(lstNoMaderable, (ModelSession.GetSession())[0].COD_UCUENTA);

            return Json(result);
        }
        #endregion
        #region "Kardex"
        public ActionResult ListarBExtraccionKardex(string asCodTHabilitante, int aiNumPoa)
        {
            try
            {
                var result = exeBExt.ListarBExtraccionKardex(asCodTHabilitante, aiNumPoa);

                return Json(new { success = true, data = result }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Ocurrió un error, comuníquese con el administrador." }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public PartialViewResult _BExtraccionKardex(string asCodTHabilitante, int aiNumPoa)
        {
            ViewBag.hdfCodTHabilitante = asCodTHabilitante;
            ViewBag.hdfNumPoa = aiNumPoa;

            Ent_POA oCampos = new Ent_POA() { COD_UCUENTA = (ModelSession.GetSession())[0].COD_UCUENTA, BusFormulario = "POA", BusCriterio = "POA_GENERAL" };
            Log_POA exePoa = new Log_POA();
            oCampos = exePoa.RegMostCombo(oCampos);
            var ListKARDEXPRODUCTO = oCampos.ListKARDEXPRODUCTO.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION }).ToList();
            ViewBag.ddlItemkeardexProducto = ListKARDEXPRODUCTO;
            var ListKARDEXDESCRIPCION = oCampos.ListKARDEXDESCRIPCION.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION }).ToList();
            ViewBag.ddlItemkeardexDescripcion = ListKARDEXDESCRIPCION;

            return PartialView();
        }

        [HttpPost]
        public JsonResult GrabarBExtraccionKardex(Ent_BEXTRACCION_KARDEX dto)
        {
            List<Ent_BEXTRACCION_KARDEX> olKardex = new List<Ent_BEXTRACCION_KARDEX>();
            olKardex.Add(dto);

            ListResult result = exeBExt.GrabarBExtraccionKardex(olKardex, (ModelSession.GetSession())[0].COD_UCUENTA);

            return Json(result);
        }
        #endregion
    }
}