using CapaEntidad.ViewModel;
using SIGOFCv3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CEntidad = CapaEntidad.DOC.Ent_IndicadorFiltro;
using CLogica = CapaLogica.DOC.Log_IndicadorFiltro;

namespace SIGOFCv3.Areas.Supervision.Controllers
{
    public class IndicadoresController : Controller
    {
        // GET: Supervision/Indicadores
        public ActionResult Index()
        {
            ViewBag.TituloFormulario = "Indicadores";
            VM_IndicadorFiltro _dto = new VM_IndicadorFiltro();
            CLogica exe = new CLogica();

            //Variables para idTab = 0
            CEntidad obj = exe.RegMostCombo(new CEntidad() { TIPO = "MAPRO" });

            List<VM_Cbo> lstCboIndicadorItem = new List<VM_Cbo>();
            lstCboIndicadorItem.Add(new VM_Cbo() { Value = "0000000", Text = "Seleccionar" });
            foreach (var item in obj.ListIndicador)
            {
                lstCboIndicadorItem.Add(new VM_Cbo() { Value = item.COD_INDICADOR, Text = item.CODIGO + " | " + item.DESCRIPCION, Tipo= item.META});
            }
            _dto.ddlIndicadorMAPRO = lstCboIndicadorItem;

            _dto.ddlAnioMAPRO = new List<VM_Cbo>{ new VM_Cbo { Value = "0000", Text = "Seleccionar" } };
            //_dto.ddlIndicadorMAPRO = obj.ListIndicador.Select(i => new VM_Cbo { Value = i.COD_INDICADOR, Text = i.CODIGO+" | "+i.DESCRIPCION });

            //Variables para idTab = 1
            obj = exe.RegMostCombo(new CEntidad() { TIPO = "POI" });

            lstCboIndicadorItem = new List<VM_Cbo>();
            lstCboIndicadorItem.Add(new VM_Cbo() { Value = "0000000", Text = "Seleccionar" });
            foreach (var item in obj.ListIndicador)
            {
                lstCboIndicadorItem.Add(new VM_Cbo() { Value = item.COD_INDICADOR, Text = item.DESCRIPCION});
            }
            _dto.ddlIndicadorPOI = lstCboIndicadorItem;

            _dto.ddlAnioPOI = new List<VM_Cbo> { new VM_Cbo { Value = "0000", Text = "Seleccionar" } };

            _dto.ddlMesPOI = new List<VM_Cbo>
            {
                new VM_Cbo { Value = "0", Text = "Seleccionar" },
                new VM_Cbo { Value = "1", Text = "ENERO" },
                new VM_Cbo { Value = "2", Text = "FEBRERO" },
                new VM_Cbo { Value = "3", Text = "MARZO" },
                new VM_Cbo { Value = "4", Text = "ABRIL" },
                new VM_Cbo { Value = "5", Text = "MAYO" },
                new VM_Cbo { Value = "6", Text = "JUNIO" },
                new VM_Cbo { Value = "7", Text = "JULIO" },
                new VM_Cbo { Value = "8", Text = "AGOSTO" },
                new VM_Cbo { Value = "9", Text = "SEPTIEMBRE" },
                new VM_Cbo { Value = "10", Text = "OCTUBRE" },
                new VM_Cbo { Value = "11", Text = "NOVIEMBRE" },
                new VM_Cbo { Value = "12", Text = "DICIEMBRE" }
            };

            //Variables para idTab = 2
            obj = exe.RegMostCombo(new CEntidad() { TIPO = "PEI" });

            lstCboIndicadorItem = new List<VM_Cbo>();
            lstCboIndicadorItem.Add(new VM_Cbo() { Value = "0000000", Text = "Seleccionar" });
            foreach (var item in obj.ListIndicador)
            {
                lstCboIndicadorItem.Add(new VM_Cbo() { Value = item.COD_INDICADOR, Text = item.DESCRIPCION });
            }
            _dto.ddlIndicadorPEI = lstCboIndicadorItem;

            _dto.ddlAnioPEI = new List<VM_Cbo> { new VM_Cbo { Value = "0000", Text = "Seleccionar" } };

            return View(_dto);
        }

        [HttpPost]
        public JsonResult FiltrarAnio(VM_IndicadorFiltro dto)
        {
            CEntidad obj = new CEntidad();
            CLogica exe = new CLogica();

            try
            {
                CEntidad param = new CEntidad();
                param.NV_CODIGO = dto.ddlIndicadorMAPROId;
                param.TIPO = dto.tipo;
                param.COD_UCUENTA= (ModelSession.GetSession())[0].COD_UCUENTA;

                obj = exe.RegMostComboAnio(param);

                List<VM_Cbo> lstCboAnioItem = new List<VM_Cbo>();
                lstCboAnioItem.Add(new VM_Cbo() { Value = "0000", Text = "Seleccionar" });
                foreach (var item in obj.ListAnio)
                {
                    lstCboAnioItem.Add(new VM_Cbo() { Value = item.CODIGO, Text = item.DESCRIPCION });
                }
                dto.ddlAnioMAPRO = lstCboAnioItem;

                return Json(new { success = true, result = dto.ddlAnioMAPRO });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msj = ex.Message });
            }
        }

        [HttpPost]
        public JsonResult Reporte(VM_IndicadorFiltro dto)
        {
            List<Dictionary<string, string>> olResult = new List<Dictionary<string, string>>();
            CEntidad param = new CEntidad();
            CLogica exe = new CLogica();
            CEntidad objMeta = null;

            try
            {
                //Para lista
                if (dto.idTab == 0)
                {
                    param.NV_CODIGO = dto.ddlIndicadorMAPROId;
                    param.ANIO = Int32.Parse(dto.ddlAnioMAPROId);
                }
                else if(dto.idTab == 1)
                {
                    param.NV_CODIGO = dto.ddlIndicadorPOIId;
                    param.ANIO = Int32.Parse(dto.ddlAnioPOIId);

                    if (param.NV_CODIGO == "0000012" || param.NV_CODIGO == "0000013")
                    {
                        param.NUMERO = Int32.Parse(dto.ddlMesPOIId);
                    }
                }
                else if (dto.idTab == 2)
                {
                    param.NV_CODIGO = dto.ddlIndicadorPEIId;
                    param.ANIO = Int32.Parse(dto.ddlAnioPEIId);
                }

                param.TIPO = dto.tipo;
                param.COD_UCUENTA = (ModelSession.GetSession())[0].COD_UCUENTA;

                if (param.TIPO.Equals("LISTA")) param.NUMERO = dto.numero;

                olResult = exe.Reporte(param);

                //Para Meta
                param = new CEntidad();

                if (dto.tipo== "CUADRO")
                {
                    param.NV_PERIODO = "ANUAL";

                    if (dto.idTab == 0)
                    {
                        param.NV_INDICADOR = dto.ddlIndicadorMAPROId;
                        param.NU_ANIO = Int32.Parse(dto.ddlAnioMAPROId);
                        objMeta = exe.RegMostMeta(param);
                    }
                    else if (dto.idTab == 2)
                    {
                        if (dto.ddlIndicadorPEIId== "0000017" || dto.ddlIndicadorPEIId == "0000019")
                        {
                            param.NV_INDICADOR = dto.ddlIndicadorPEIId;
                            param.NU_ANIO = Int32.Parse(dto.ddlAnioPEIId);
                            objMeta = exe.RegMostMeta(param);
                        } 
                    }
                }

                var jsonResult = Json(new { success = true, msj = "", data = olResult.ToArray(), obj= objMeta }, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msj = ex.Message });
            }
        }
    }
}