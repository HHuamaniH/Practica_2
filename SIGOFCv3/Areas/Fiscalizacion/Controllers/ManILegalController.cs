using CapaEntidad.DOC;
using CapaLogica.DOC;
using SIGOFCv3.Models.DataTables;
using System.Collections.Generic;
using System.Web.Mvc;

namespace SIGOFCv3.Areas.Fiscalizacion.Controllers
{
    public class ManILegalController : Controller
    {
        // GET: Fiscalizacion/ManILegal
        public ActionResult Index()
        {
            return View();
        }

        #region "SHARED"
        [HttpGet]
        public JsonResult ConsultaILegalPaging(DataTableRequest request = null)
        {
            Log_BUSQUEDA exeBus = new Log_BUSQUEDA();
            Ent_BUSQUEDA paramsBus = new Ent_BUSQUEDA();
            List<Dictionary<string, string>> lstResult;
            int rowcount = 0;
            int page = request.Start == 0 ? 1 : (request.Start / request.Length) + 1;

            paramsBus.BusFormulario = request.CustomSearchForm;//ILEGAL_CONSULTA
            paramsBus.BusCriterio = request.CustomSearchType;//NUM_ILEGAL
            paramsBus.BusValor = request.CustomSearchValue;
            paramsBus.pagesize = request.Length;
            paramsBus.currentpage = page;

            if (request.Order.Length != 0)
            {
                paramsBus.sort = request.Order[0].Column_Name + " " + request.Order[0].Dir;
            }

            lstResult = exeBus.RegMostrarListaPaging(paramsBus, ref rowcount);

            var jsonResult = Json(new
            {
                data = lstResult.ToArray(),
                draw = request.Draw,
                recordsTotal = rowcount,
                recordsFiltered = rowcount,
                error = ""
            }, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
        #endregion
    }
}