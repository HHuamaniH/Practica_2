using CapaLogica.GENE;
using System.Web.Mvc;

namespace SIGOFCv3.Areas.Fiscalizacion.Controllers
{
    public class ControlesController : Controller
    {
        // GET: Fiscalizacion/Controles
        #region "Ubigeo"
        [HttpPost]
        public ActionResult _Ubigeo(string formOrigen, string controlOrigen)
        {
            ViewBag.ubFormularioOrigen = formOrigen;
            ViewBag.ubControlOrigen = controlOrigen;
            return PartialView();
        }
        public string GetListUbigeoTodo()
        {
            Log_UBIGEO objLogUbigeo = new Log_UBIGEO();
            string listaTotalUbigeo = objLogUbigeo.RegMostrarUbigeoV3();
            return listaTotalUbigeo;
        }
        #endregion
    }
}