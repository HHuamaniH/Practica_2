using System;
using System.Web.Mvc;
using CEntidadObs = CapaEntidad.DOC.Ent_Reporte_OBSERVATORIO;
using CLogicaObs = CapaLogica.DOC.Log_Reporte_OBSERVATORIO;

namespace Estadisticas.Controllers
{
    public class HomeController : Controller
    {
        CLogicaObs oCLogicaObs = new CLogicaObs();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Reportes(Int32 id)
        {
            String vistaRetorno = "";
            try
            {
                switch (id)
                {
                    case 1: vistaRetorno = "viewReporte1"; ViewBag.Parametros = "3|0|1|0|0|0|0|0|0|0"; break;
                    case 2: vistaRetorno = "viewReporte2"; ViewBag.Parametros = "3|1|1|0|0|0|0|0|0|0"; break;
                    case 3: vistaRetorno = "viewReporte3"; ViewBag.Parametros = "0|0|0|0|0|0|0|0|0|0"; break;
                    case 4: vistaRetorno = "viewReporte4"; ViewBag.Parametros = "0|1|1|0|0|0|0|0|0|0"; break;
                    case 5: vistaRetorno = "viewReporte5"; ViewBag.Parametros = "3|1|1|0|0|0|0|0|0|0"; break;
                    case 6: vistaRetorno = "viewReporte6"; ViewBag.Parametros = "3|3|1|0|0|0|0|0|0|0"; break;
                    case 7: vistaRetorno = "viewReporte7"; ViewBag.Parametros = "5|0|1|0|0|0|0|0|0|0"; break;
                    case 8: vistaRetorno = "viewReporte8"; ViewBag.Parametros = "3|0|1|0|0|0|0|0|0|0"; break;
                    case 9: vistaRetorno = "viewReporte9"; ViewBag.Parametros = "3|3|1|0|0|0|0|0|0|0"; break;
                    case 10: vistaRetorno = "viewReporte10"; ViewBag.Parametros = "3|3|1|0|0|0|0|0|0|0"; break;
                    case 11: vistaRetorno = "viewReporte11"; ViewBag.Parametros = "0|0|0|0|0|0|0|0|0|0"; break;
                    case 12: vistaRetorno = "viewReporte12"; ViewBag.Parametros = "5|1|1|0|0|0|0|0|0|0"; break;
                }
                ViewBag.fechaProcess = (oCLogicaObs.RegMostrarFechaObserv(new CEntidadObs())).FECHA;
                return View(vistaRetorno);
            }
            catch (Exception ex)
            {
                return View();
            }
        }
    }
}