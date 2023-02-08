using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CEntidad = CapaEntidad.DOC.Ent_MasterFiltro;
using CLogica = CapaLogica.DOC.Log_MasterFiltro;

namespace Estadisticas.Controllers
{
    public class ControlesController : Controller
    {
        CLogica oCLogica = new CLogica();
        // GET: Controles
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult llenarFiltros(String Parametros)
        {
            CEntidad oCampos = new CEntidad();
            List<String[]> retorno = new List<String[]>();
            oCampos.BusValor = Parametros;
            oCampos = oCLogica.RegMostFiltro(oCampos);

            String[] Arreglo = new String[oCampos.ListAnios.Count];
            for (int i = 0; i < oCampos.ListAnios.Count; i++) { Arreglo[i] = oCampos.ListAnios[i].CODIGO + "|" + oCampos.ListAnios[i].DESCRIPCION; }
            retorno.Add(Arreglo);

            Arreglo = new String[oCampos.ListModalidad.Count];
            for (int i = 0; i < oCampos.ListModalidad.Count; i++) { Arreglo[i] = oCampos.ListModalidad[i].CODIGO + "|" + oCampos.ListModalidad[i].DESCRIPCION; }
            retorno.Add(Arreglo);

            Arreglo = new String[oCampos.ListRegion.Count];
            string sDpto = "";
            for (int i = 0; i < oCampos.ListRegion.Count; i++)
            {
                sDpto = oCampos.ListRegion[i].DESCRIPCION.ToLowerInvariant();
                sDpto = sDpto.Substring(0, 1).ToUpper() + sDpto.Substring(1, sDpto.Length - 1);
                Arreglo[i] = oCampos.ListRegion[i].CODIGO + "|" + sDpto;
            }
            retorno.Add(Arreglo);

            Arreglo = new String[oCampos.ListArticulos.Count];
            for (int i = 0; i < oCampos.ListArticulos.Count; i++) { Arreglo[i] = oCampos.ListArticulos[i].CODIGO + "|" + oCampos.ListArticulos[i].DESCRIPCION; }
            retorno.Add(Arreglo);

            Arreglo = new String[oCampos.ListDLinea.Count];
            for (int i = 0; i < oCampos.ListDLinea.Count; i++) { Arreglo[i] = oCampos.ListDLinea[i].CODIGO + "|" + oCampos.ListDLinea[i].DESCRIPCION; }
            retorno.Add(Arreglo);

            Arreglo = new String[oCampos.ListProfesional.Count];
            for (int i = 0; i < oCampos.ListProfesional.Count; i++) { Arreglo[i] = oCampos.ListProfesional[i].CODIGO + "|" + oCampos.ListProfesional[i].DESCRIPCION; }
            retorno.Add(Arreglo);

            Arreglo = new String[oCampos.ListEspecies.Count];
            for (int i = 0; i < oCampos.ListEspecies.Count; i++) { Arreglo[i] = oCampos.ListEspecies[i].CODIGO + "|" + oCampos.ListEspecies[i].DESCRIPCION; }
            retorno.Add(Arreglo);

            Arreglo = new String[oCampos.ListOD.Count];
            for (int i = 0; i < oCampos.ListOD.Count; i++) { Arreglo[i] = oCampos.ListOD[i].CODIGO + "|" + oCampos.ListOD[i].DESCRIPCION; }
            retorno.Add(Arreglo);


            return Json(retorno);
        }
    }
}