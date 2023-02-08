using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using CEntidad = CapaEntidad.DOC.Ent_Reporte_ESTADISTICOS;
using CLogica = CapaLogica.DOC.Log_Reporte_ESTADISTICOS;

namespace Estadisticas.Controllers
{

    public class EstadisticosController : Controller
    {
        CEntidad CEntReportEstadisticos = new CEntidad();
        List<CEntidad> ListReportEstadisticos = new List<CEntidad>();
        CLogica oCLogica = new CLogica();
        // GET: Estadisticos
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult generaReporte1(String busAnio, String busRegion)
        {
            try
            {
                List<Object[]> retorno = new List<Object[]>();
                CEntidad oCampos = new CEntidad();
                oCampos.BusRegion = busRegion;
                oCampos.BusAnio = busAnio;
                oCampos.BusCriterio = "1";
                ListReportEstadisticos = oCLogica.Reg_Prin_Esp_Aprob(oCampos);//
                Session["ListReportEstadisticos"] = ListReportEstadisticos;
                foreach (var item in ListReportEstadisticos)
                {
                    retorno.Add(new Object[] { item.NOMBRE_CIENTIFICO, item.VOL_AUTORIZADO });
                }
                return Json(retorno);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }
        public JsonResult generarReporte2(String busAnio, String busModalidad, String busRegion, String busLinea)
        {
            try
            {
                List<List<Object[]>> retorno = new List<List<Object[]>>();
                List<Object[]> subretorno = new List<Object[]>();
                CEntidad oCampos = new CEntidad();
                oCampos.BusRegion = busRegion;
                oCampos.BusModalidad = busModalidad;
                oCampos.BusAnio = busAnio;
                oCampos.BusDireccion = busLinea;
                oCampos.BusCriterio = "2";
                CEntReportEstadisticos = oCLogica.Reg_Super_OSINFOR(oCampos);//
                Session["ListReportEstadisticos"] = ListReportEstadisticos;

                foreach (var item in CEntReportEstadisticos.ListISupervision_Region_Modalidad.OrderByDescending(m => m.TOTAL))
                {
                    subretorno.Add(new Object[] { item.DEPARTAMENTO,
                item.CANT_PFAUNA,
                item.CANT_TARA,
                item.CANT_BS,
                item.CANT_CMADE,
                item.CANT_NM,
                item.CANT_FYR,
                item.CANT_ECO,
                item.CANT_CONS,
                item.CANT_CFAUNA,
                item.CANT_PP,
                item.CANT_CCCC_CCNN,
                item.CANT_BL,
                //item.CANT_SISAG,
                item.CANT_PNM,
                item.TOTAL});
                }
                retorno.Add(subretorno);

                subretorno = new List<Object[]>();

                foreach (var item in CEntReportEstadisticos.ListISupervision_Modalidad_Anio.OrderByDescending(m => m.TOTAL))
                {
                    subretorno.Add(new Object[] { item.MODALIDAD,
                //item.DOSMILCINCO,
                item.DOSMILNUEVE,
                item.DOSMILDIEZ,
                item.DOSMILONCE,
                item.DOSMILDOCE,
                item.DOSMILTRECE,
                item.DOSMILCATORCE,
                item.DOSMILQUINCE,
                item.DOSMILDIECISEIS,
                item.DOSMILDIECISIETE,
                item.DOSMILDIECIOCHO,
                item.DOSMILDIECINUEVE,
                item.DOSMILVEINTE,
                item.DOSMILVEINTIUNO,
                item.DOSMILVEINTIDOS,
                item.DOSMILVEINTITRES,
                item.TOTAL});
                }
                retorno.Add(subretorno);

                subretorno = new List<Object[]>();
                foreach (var item in CEntReportEstadisticos.ListISupervision_Region_Anio.OrderByDescending(m => m.TOTAL))
                {
                    subretorno.Add(new Object[] { item.DEPARTAMENTO,
                //item.DOSMILCINCO,
                item.DOSMILNUEVE,
                item.DOSMILDIEZ,
                item.DOSMILONCE,
                item.DOSMILDOCE,
                item.DOSMILTRECE,
                item.DOSMILCATORCE,
                item.DOSMILQUINCE,
                item.DOSMILDIECISEIS,
                item.DOSMILDIECISIETE,
                item.DOSMILDIECIOCHO,
                item.DOSMILDIECINUEVE,
                item.DOSMILVEINTE,
                item.DOSMILVEINTIUNO,
                item.DOSMILVEINTIDOS,
                item.DOSMILVEINTITRES,
                item.TOTAL });
                }
                retorno.Add(subretorno);
                return Json(retorno);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }
        public JsonResult generarReporte3()
        {
            try
            {
                List<List<Object[]>> retorno = new List<List<Object[]>>();
                List<Object[]> subretorno = new List<Object[]>();
                CEntidad oCampos = new CEntidad();
                oCampos.BusCriterio = "3";
                CEntReportEstadisticos = oCLogica.Reg_Capacitaciones_OSINFOR(oCampos);//
                Session["CEntReportEstadisticos"] = CEntReportEstadisticos;

                foreach (var item in CEntReportEstadisticos.ListCapacitacionRegion.OrderByDescending(m => m.TOTAL))
                {
                    subretorno.Add(new Object[] { item.DEPARTAMENTO,
                    item.DOSMILDOCE,
                    item.DOSMILTRECE,
                    item.DOSMILCATORCE,
                    item.DOSMILQUINCE,
                    item.DOSMILDIECISEIS,
                    item.DOSMILDIECISIETE,
                    item.DOSMILDIECIOCHO,
                    item.DOSMILDIECINUEVE,
                    item.DOSMILVEINTE,
                    item.DOSMILVEINTIUNO,
                    item.DOSMILVEINTIDOS,
                    item.DOSMILVEINTITRES,
                    item.TOTAL });
                }
                retorno.Add(subretorno);

                subretorno = new List<Object[]>();
                foreach (var item in CEntReportEstadisticos.ListCapacitacionParticipante)
                {
                    subretorno.Add(new Object[] {
                    item.ANIO,
                    item.NUM_CAPACITACIONES,
                    item.NUM_PARTICIPANTES,
                    item.NUM_HOMBRES,
                    item.NUM_MUJERES
                });
                }
                retorno.Add(subretorno);
                return Json(retorno);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }
        public JsonResult generarReporte4(String busModalidad, String busRegion, String busLinea)
        {
            try
            {
                List<Object[]> retorno = new List<Object[]>();
                CEntidad oCampos = new CEntidad();
                oCampos.BusModalidad = busModalidad;
                oCampos.BusRegion = busRegion;
                oCampos.BusDireccion = busLinea;
                oCampos.BusDireccion2 = "'0000001','0000002','0000004','0000005','0000007'";
                oCampos.BusCriterio = "9";
                ListReportEstadisticos = oCLogica.Lista_PAU_Concluidos(oCampos);//No incluir el año 2020
                Session["ListReportEstadisticos"] = ListReportEstadisticos;

                foreach (var item in ListReportEstadisticos)
                {
                    retorno.Add(new Object[] {
                    item.ANIO,
                    item.SUPERVISION,
                    item.ARCHIVO_PRELIMINAR,
                    item.INI_PAU,
                    item.CANTIDAD,
                    item.AVANCE,
                    item.TERMINO_PAU,
                    item.AVANCE1,
                    item.CASOS,
                    item.AVANCE_CASOS,
                    });
                }
                return Json(retorno);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }
        public JsonResult generarReporte5(String busRegion, String busModalidad, String busAnio)
        {
            try
            {
                List<List<Object[]>> retorno = new List<List<Object[]>>();
                List<Object[]> subretorno = new List<Object[]>();
                CEntidad oCampos = new CEntidad();
                oCampos.BusRegion = busRegion;
                oCampos.BusModalidad = busModalidad;
                oCampos.BusAnio = busAnio;
                oCampos.BusCriterio = "4";
                CEntReportEstadisticos = oCLogica.Reg_Arboles_OSINFOR_v2(oCampos);//
                //Session["ListReportEstadisticos"] = ListReportEstadisticos;

                foreach (var item in CEntReportEstadisticos.ListISupervision_Region_Anio)
                {
                    subretorno.Add(new Object[] { item.ANIO, item.EXISTENTES, item.INEXISTENTES, item.TOTAL_ARBOLES });
                }
                retorno.Add(subretorno);

                subretorno = new List<Object[]>();
                foreach (var item in CEntReportEstadisticos.ListISupervision_Modalidad_Anio.OrderByDescending(m => m.TOTAL_ARBOLES))
                {
                    subretorno.Add(new Object[] { item.MODALIDAD, item.EXISTENTES, item.INEXISTENTES, item.TOTAL_ARBOLES });
                }
                retorno.Add(subretorno);

                subretorno = new List<Object[]>();
                foreach (var item in CEntReportEstadisticos.ListISupervision_Region_Modalidad.OrderByDescending(m => m.TOTAL_ARBOLES))
                {
                    subretorno.Add(new Object[] { item.DEPARTAMENTO, item.EXISTENTES, item.INEXISTENTES, item.TOTAL_ARBOLES });
                }
                retorno.Add(subretorno);

                return Json(retorno);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }
        public JsonResult generarReporte6(String busAnio, String busModalidad, String busRegion)
        {
            try
            {
                List<Object[]> retorno = new List<Object[]>();
                CEntidad oCampos = new CEntidad();
                oCampos.BusAnio = busAnio;
                oCampos.BusModalidad = busModalidad;
                oCampos.BusRegion = busRegion;
                oCampos.BusCriterio = "5";
                ListReportEstadisticos = oCLogica.Reg_PManejo_OSINFOR(oCampos);//
                Session["ListReportEstadisticos"] = ListReportEstadisticos;

                foreach (var item in ListReportEstadisticos)
                {
                    retorno.Add(new Object[] { item.ANIO, item.EXISTENTES, item.INEXISTENTES, item.TOTAL_PLANES
                        ,item.REGENTES,item.FUNCIONARIOS,item.REGENTES_EXISTENTE,item.FUNCIONARIOS_EXISTENTE });
                }
                return Json(retorno);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }
        public JsonResult generarReporte7(String busAnio, String busRegion)
        {
            try
            {
                List<Object[]> retorno = new List<Object[]>();
                CEntidad oCampos = new CEntidad();
                oCampos.BusAnio = busAnio;
                oCampos.BusRegion = busRegion;
                oCampos.BusCriterio = "6";
                ListReportEstadisticos = oCLogica.Reg_Esp_Vol_Injus_Superv(oCampos);//
                int cantidadEspecies = ListReportEstadisticos.Count;
                Session["ListReportEstadisticos"] = ListReportEstadisticos;

                int i = 0;
                foreach (var item in ListReportEstadisticos)
                {
                    retorno.Add(new Object[] { item.NOMBRE_CIENTIFICO, item.VOL_MOVILIZADO.ToString("f3") });
                    if (i++ > 8)
                    {
                        break;
                    }
                }
                return Json(new { data = retorno, num_especies = cantidadEspecies });
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }
        public JsonResult generarReporte8(String busAnio, String busRegion)
        {
            try
            {
                List<Object[]> retorno = new List<Object[]>();
                CEntidad oCampos = new CEntidad();
                oCampos.BusAnio = busAnio;
                oCampos.BusRegion = busRegion;
                oCampos.BusCriterio = "7";
                ListReportEstadisticos = oCLogica.Reg_Esp_Movil_Ext_Ilegal_Fiscal(oCampos);//
                Session["ListReportEstadisticos"] = ListReportEstadisticos;

                foreach (var item in ListReportEstadisticos)
                {
                    retorno.Add(new Object[] { item.NOMBRE_CIENTIFICO, item.VOL_MOVILIZADO.ToString("f3") });
                }
                return Json(retorno);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }
        public JsonResult generarReporte9(String busAnio, String busModalidad, String busRegion)
        {
            try
            {
                List<Object[]> retorno = new List<Object[]>();
                CEntidad oCampos = new CEntidad();
                oCampos.BusAnio = busAnio;
                oCampos.BusModalidad = busModalidad;
                oCampos.BusRegion = busRegion;
                oCampos.BusCriterio = "8";
                ListReportEstadisticos = oCLogica.Reg_Vol_Mov_Ext_Ilegal(oCampos);//
                Session["ListReportEstadisticos"] = ListReportEstadisticos;

                foreach (var item in ListReportEstadisticos.Where(m => m.TOTAL > 0).OrderByDescending(m => m.TOTAL))
                {
                    retorno.Add(new Object[] {item.DEPARTAMENTO,
                    item.CANT_BS.ToString("f3"),
                    item.CANT_FYR.ToString("f3"),
                    item.CANT_CMADE.ToString("f3"),
                    item.CANT_CCNN.ToString("f3"),
                    item.CANT_PP.ToString("f3"),
                    item.CANT_CCCC.ToString("f3"),
                    item.CANT_BL.ToString("f3"),
                    item.CANT_NM.ToString("f3"),
                    item.TOTAL.ToString("f3") });
                }
                return Json(retorno);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }
        public JsonResult generarReporte10(String busAnio, String busModalidad, String busRegion)
        {
            try
            {
                List<Object[]> retorno = new List<Object[]>();
                CEntidad oCampos = new CEntidad();
                oCampos.BusAnio = busAnio;
                oCampos.BusModalidad = busModalidad;
                oCampos.BusRegion = busRegion;
                oCampos.BusCriterio = "10";
                ListReportEstadisticos = oCLogica.Reg_PManejo_Sancion_OSINFOR(oCampos);//
                Session["ListReportEstadisticos"] = ListReportEstadisticos;

                foreach (var item in ListReportEstadisticos)
                {
                    retorno.Add(new Object[] { item.ANIO, item.TOTAL_PLANES, item.SANCIONADO_PAU, item.AVANCE
                        ,item.ARCHIVO_PRELIMINAR_SIN,item.ARCHIVO_PRELIMINAR,item.ARCHIVO_PAU});
                }
                return Json(retorno);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }
        public JsonResult generarReporte12(String busAnio, String busModalidad, String busRegion)
        {
            try
            {
                List<Object[]> retorno = new List<Object[]>();
                CEntidad oCampos = new CEntidad();
                oCampos.BusAnio = busAnio;
                oCampos.BusModalidad = busModalidad;
                oCampos.BusRegion = busRegion;
                oCampos.BusCriterio = "12";
                ListReportEstadisticos = oCLogica.Reg_Vol_Mov_Ext_Ilegal_Superv(oCampos);//
                Session["ListReportEstadisticos"] = ListReportEstadisticos;

                foreach (var item in ListReportEstadisticos.Where(m => m.TOTAL > 0).OrderByDescending(m => m.TOTAL))
                {
                    retorno.Add(new Object[] {item.DEPARTAMENTO,
                    item.CANT_BS.ToString("f3"),
                    item.CANT_FYR.ToString("f3"),
                    item.CANT_CMADE.ToString("f3"),
                    item.CANT_CCNN.ToString("f3"),
                    item.CANT_PP.ToString("f3"),
                    item.CANT_CCCC.ToString("f3"),
                    item.CANT_BL.ToString("f3"),
                    item.CANT_NM.ToString("f3"),
                    item.TOTAL.ToString("f3") });
                }
                return Json(retorno);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }
    }
}