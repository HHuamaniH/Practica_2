using CapaEntidad.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CEntidadP = CapaEntidad.DOC.Ent_Tablero_Parametros;
using CEntidadR = CapaEntidad.DOC.Ent_Tablero_Resultados;
using CLogica = CapaLogica.DOC.Log_Tablero;

namespace SIGOFCv3.Areas.General.Controllers
{
    public class ReporteFlujoFiscalizacionController : Controller
    {
        // GET: General/ReporteFlujoFiscalizacion
        public ActionResult Index(int _idTab)
        {
            ViewBag.TituloFormulario = "Reporte de Seguimiento";
            VM_FlujoFiscalizacion _dto = new VM_FlujoFiscalizacion();
            _dto.idTab = _idTab;
            _dto.ddlSubdireccion = _dto.ddlSubdirMAPRO = _dto.ddlSubdirPEI = new List <VM_Cbo>
            {
                new VM_Cbo { Value = "0000004|0000005", Text = "TODOS" },
                new VM_Cbo { Value = "0000004", Text = "SDFPAFFS" },
                new VM_Cbo { Value = "0000005", Text = "SDFCFFS" }
            };
            return View(_dto);
        }

        [HttpPost]
        public JsonResult ObtenerData(VM_FlujoFiscalizacion vm)
        {
            try
            {
                CEntidadP param = new CEntidadP();
                CLogica exe = new CLogica();
                VM_FlujoFiscalizacion _dto = new VM_FlujoFiscalizacion();

                if (vm.idTab == 0)
                {
                    param.VAFECINICIO = vm.txtfechainiDFFFS;
                    param.VAFECTERMINO = vm.txtfechafinDFFFS;
                    param.VAFILTRO = "1";
                    CEntidadR obj = exe.RegMostIndDFFFS(param);

                    _dto.cantDFFFS1 = obj.DERIVADOS_DFFFS;
                    _dto.cantDFFFS5 = obj.INF_EVALUADOS;
                    _dto.cantDFFFS5_1 = obj.INF_ARCHIVO;
                    _dto.cantDFFFS5_2 = obj.INF_DEVUELTOS;
                    _dto.cantDFFFS5_3 = obj.INF_RSD_INICIO;
                    _dto.cantDFFFS6 = obj.RSD_PENDIENTE;
                    _dto.cantDFFFS2 = obj.CON_RSD_INICIO_NOTIFICADO;
                    _dto.cantDFFFS7 = obj.CON_IFI_EMITIDOS;
                    _dto.cantDFFFS8 = obj.CON_IFI_PENDIENTES;
                    _dto.cantDFFFS3 = obj.CON_IFI_EMITIDOS;
                    _dto.cantDFFFS9 = obj.RD_EMITIDOS;
                    _dto.cantDFFFS10 = obj.RD_PENDIENTES;
                    _dto.cantDFFFS4 = obj.RD_EMITIDOS_NOTIFICADOS;
                    _dto.cantDFFFS11 = obj.RD_FIRMEZA;
                    _dto.cantDFFFS12 = obj.RD_PENDIENTE_FIRMEZA;
                    _dto.cantDFFFS13 = obj.DIAS_INFORME;
                    _dto.cantDFFFS14 = obj.DIAS_EVALUACION;
                    _dto.cantDFFFS15 = obj.DIAS_INSTRUCCION;
                    _dto.cantDFFFS16 = obj.DIAS_DECISION;
                    _dto.cantDFFFS17 = obj.MES_PAU;
                    _dto.cantDFFFS18 = obj.MES_INF_PAU;

                    _dto.cantDFFFS19 = _dto.cantDFFFS8;
                    _dto.cantDFFFS20 = _dto.cantDFFFS10;
                    _dto.cantDFFFS21 = _dto.cantDFFFS12;
                    _dto.cantDFFFS22 = obj.IFI_EN_PLAZO;
                    _dto.cantDFFFS23 = obj.IFI_PARA_EMITIR;
                    _dto.cantDFFFS24 = obj.RD_EN_PLAZO;
                    _dto.cantDFFFS25 = obj.RD_PARA_EMITIR;
                    _dto.cantDFFFS26 = obj.FIRMEZA_EN_PLAZO;
                    _dto.cantDFFFS27 = obj.FIRMEZA_PARA_EMITIR;
                }
                else if (vm.idTab == 1)
                {
                    param.VAFECINICIO = vm.txtfechainiSubdireccion;
                    param.VAFECTERMINO = vm.txtfechafinSubdireccion;
                    param.VACODDIRECCIONL = vm.ddlSubdireccionId;
                    param.VAFILTRO = "2";
                    CEntidadR obj = exe.RegMostIndDFFFS(param);

                    _dto.cantSubdireccion1 = obj.DERIVADOS_DFFFS;
                    _dto.cantSubdireccion3 = obj.INF_EVALUADOS;
                    _dto.cantSubdireccion3_1 = obj.INF_ARCHIVO;
                    _dto.cantSubdireccion3_2 = obj.INF_DEVUELTOS;
                    _dto.cantSubdireccion3_3 = obj.INF_RSD_INICIO;
                    _dto.cantSubdireccion4 = obj.RSD_PENDIENTE;
                    _dto.cantSubdireccion2 = obj.CON_RSD_INICIO_NOTIFICADO;
                    _dto.cantSubdireccion5 = obj.CON_IFI_EMITIDOS;
                    _dto.cantSubdireccion6 = obj.CON_IFI_PENDIENTES;
                    _dto.cantSubdireccion7 = obj.DIAS_INFORME;
                    _dto.cantSubdireccion8 = obj.DIAS_EVALUACION;
                    _dto.cantSubdireccion9 = obj.DIAS_INSTRUCCION;

                    _dto.cantSubdireccion10 = _dto.cantSubdireccion6;
                    _dto.cantSubdireccion11 = obj.IFI_EN_PLAZO;
                    _dto.cantSubdireccion12 = obj.IFI_PARA_EMITIR;
                }
                else if (vm.idTab == 2)
                {
                    param.VACODDIRECCIONL = vm.ddlSubdirMAPROId;

                    if (vm.opcConsulta == 1)
                    {
                        param.VAFECINICIO = vm.txtfechainiMAPRO1;
                        param.VAFECTERMINO = vm.txtfechafinMAPRO1;
                        param.VAFILTRO = "3-1";
                        CEntidadR obj = exe.RegMostIndDFFFS(param);

                        _dto.cantMAPRO1 = obj.DERIVADOS_DFFFS;
                    }
                    else if (vm.opcConsulta == 2)
                    {
                        param.VAFECINICIO = vm.txtfechainiMAPRO2;
                        param.VAFECTERMINO = vm.txtfechafinMAPRO2;
                        param.VAFILTRO = "3-2";
                        CEntidadR obj = exe.RegMostIndDFFFS(param);

                        _dto.cantMAPRO2 = obj.INF_EVALUADOS;

                        if (vm.cantMAPRO1==0 && obj.INF_EVALUADOS == 0) _dto.cantMAPRO3 = 0;
                        else _dto.cantMAPRO3 = Truncate((((double)obj.INF_EVALUADOS / (double)vm.cantMAPRO1) * 100), 2);
                    }
                    else if (vm.opcConsulta == 3)
                    {
                        param.VAFECINICIO = vm.txtfechainiMAPRO3;
                        param.VAFECTERMINO = vm.txtfechafinMAPRO3;
                        param.VAFILTRO = "3-3";
                        CEntidadR obj = exe.RegMostIndDFFFS(param);

                        _dto.cantMAPRO4 = obj.CON_IFI_PENDIENTES;
                    }
                    else if (vm.opcConsulta == 4)
                    {
                        param.VAFECINICIO = vm.txtfechainiMAPRO4;
                        param.VAFECTERMINO = vm.txtfechafinMAPRO4;
                        param.VAFILTRO = "3-4";
                        CEntidadR obj = exe.RegMostIndDFFFS(param);

                        _dto.cantMAPRO5 = obj.CON_IFI_EMITIDOS;

                        if (vm.cantMAPRO4 == 0 && obj.CON_IFI_EMITIDOS == 0) _dto.cantMAPRO6 = 0;
                        else _dto.cantMAPRO6 = Truncate((((double)obj.CON_IFI_EMITIDOS / (double)vm.cantMAPRO4) * 100), 2);
                    }
                    else if (vm.opcConsulta == 5)
                    {
                        if (vm.chkFechaini5) param.VAFECINICIO = vm.txtfechainiMAPRO5;
                        else param.VAFECINICIO = "01/01/1900";

                        param.VAFECTERMINO = vm.txtfechafinMAPRO5;
                        param.VAFILTRO = "3-5";
                        CEntidadR obj = exe.RegMostIndDFFFS(param);

                        _dto.cantMAPRO7 = obj.RD_APELADA_RESUELTA;

                        param.VAFILTRO = "3-6";
                        obj = exe.RegMostIndDFFFS(param);

                        _dto.cantMAPRO8 = obj.RD_CONFIRMADA;

                        if (_dto.cantMAPRO7 == 0) _dto.cantMAPRO9 = 0;
                        else _dto.cantMAPRO9 = Truncate((((double)obj.RD_CONFIRMADA / (double)_dto.cantMAPRO7) * 100), 2);
                    }
                    /*else if (vm.opcConsulta == 6)
                    {
                        if (vm.chkFechaini5) param.VAFECINICIO = vm.txtfechainiMAPRO5;
                        else param.VAFECINICIO = "01/01/1900";

                        param.VAFECTERMINO = vm.txtfechafinMAPRO5;

                        if (vm.chkFechaini6) param.VAFECINICIO_DOC = vm.txtfechainiMAPRO6;
                        else param.VAFECINICIO_DOC = "01/01/1900";

                        param.VAFECTERMINO_DOC = vm.txtfechafinMAPRO6;
                        param.VAFILTRO = "3-6";
                        CEntidadR obj = exe.RegMostIndDFFFS(param);

                        _dto.cantMAPRO8 = obj.RD_CONFIRMADA;

                        if (vm.cantMAPRO7 == 0 && obj.RD_CONFIRMADA == 0) _dto.cantMAPRO9 = 0;
                        else _dto.cantMAPRO9 = Truncate((((double)obj.RD_CONFIRMADA / (double)vm.cantMAPRO7) * 100), 2);
                    }*/
                    else if (vm.opcConsulta == 7)
                    {
                        if (vm.chkFechaini7) param.VAFECINICIO = vm.txtfechainiMAPRO7;
                        else param.VAFECINICIO = "01/01/1900";

                        param.VAFECTERMINO = vm.txtfechafinMAPRO7;
                        param.VAFILTRO = "3-7";
                        CEntidadR obj = exe.RegMostIndDFFFS(param);

                        _dto.cantMAPRO10 = obj.RD_RECONSIDERADA_RESUELTA;

                        param.VAFILTRO = "3-8";
                        obj = exe.RegMostIndDFFFS(param);

                        _dto.cantMAPRO11 = obj.RD_EMITIDA;

                        if (_dto.cantMAPRO10 == 0) _dto.cantMAPRO12 = 0;
                        else _dto.cantMAPRO12 = Truncate((((double)obj.RD_EMITIDA / (double)_dto.cantMAPRO10) * 100), 2);
                    }
                    /*else if (vm.opcConsulta == 8)
                    {
                        if (vm.chkFechaini7) param.VAFECINICIO = vm.txtfechainiMAPRO7;
                        else param.VAFECINICIO = "01/01/1900";

                        param.VAFECTERMINO = vm.txtfechafinMAPRO7;

                        if (vm.chkFechaini8) param.VAFECINICIO_DOC = vm.txtfechainiMAPRO8;
                        else param.VAFECINICIO_DOC = "01/01/1900";

                        param.VAFECTERMINO_DOC = vm.txtfechafinMAPRO8;
                        param.VAFILTRO = "3-8";
                        CEntidadR obj = exe.RegMostIndDFFFS(param);

                        _dto.cantMAPRO11 = obj.RD_EMITIDA;

                        if (vm.cantMAPRO10 == 0 && obj.RD_EMITIDA == 0) _dto.cantMAPRO12 = 0;
                        else _dto.cantMAPRO12 = Truncate((((double)obj.RD_EMITIDA / (double)vm.cantMAPRO10) * 100), 2);
                    }*/

                }
                else if (vm.idTab == 3)
                {
                    param.VACODDIRECCIONL = vm.ddlSubdirPEIId;
                    param.VAFECINICIO = vm.txtfechainiPEI1;
                    param.VAFECTERMINO = vm.txtfechafinPEI1;
                    param.VAFILTRO = "4-1";
                    CEntidadR obj = exe.RegMostIndDFFFS(param);

                    _dto.cantPEI1 = obj.DERIVADOS_DFFFS;
                    _dto.cantPEI2 = obj.INF_EVALUADOS;

                    if (_dto.cantPEI1 == 0 && obj.INF_EVALUADOS == 0) _dto.cantPEI3 = 0;
                    else _dto.cantPEI3 = Truncate((((double)obj.INF_EVALUADOS / (double)_dto.cantPEI1) * 100), 2);
                }

                return Json(new { success = true, result = _dto });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, result = ex.Message });
            }
        }

        public double Truncate(double value, int decimales)
        {
            double aux_value = Math.Pow(10, decimales);
            return (Math.Truncate(value * aux_value) / aux_value);
        }

        [HttpPost]
        public JsonResult Reporte(VM_FlujoFiscalizacion dto)
        {
            List<Dictionary<string, string>> olResult = new List<Dictionary<string, string>>();
            CapaEntidad.DOC.Ent_REPORTE_GENERAL paramRpt = new CapaEntidad.DOC.Ent_REPORTE_GENERAL();
            CapaLogica.DOC.Log_REPORTE_GENERAL exeRpt = new CapaLogica.DOC.Log_REPORTE_GENERAL();

            try
            {
                paramRpt.TIPO_REPORTE = "REPORTE_DIRECCION_FISCALIZACION_FILTRO";
                paramRpt.FILTRO = dto.cellReporte;

                if (dto.idTab == 0)
                {
                    paramRpt.FECHA_INICIO = dto.txtfechainiDFFFS;
                    paramRpt.FECHA_TERNINO = dto.txtfechafinDFFFS;
                }
                else if (dto.idTab == 1)
                {
                    paramRpt.COD_DLINEA = dto.ddlSubdireccionId;
                    paramRpt.FECHA_INICIO = dto.txtfechainiSubdireccion;
                    paramRpt.FECHA_TERNINO = dto.txtfechafinSubdireccion;
                }
                else if (dto.idTab == 2)
                {
                    paramRpt.COD_DLINEA = dto.ddlSubdirMAPROId;

                    if (dto.opcConsulta == 1)
                    {
                        paramRpt.FECHA_INICIO = dto.txtfechainiMAPRO1;
                        paramRpt.FECHA_TERNINO = dto.txtfechafinMAPRO1;
                    }
                    else if (dto.opcConsulta == 2)
                    {
                        paramRpt.FECHA_INICIO = dto.txtfechainiMAPRO2;
                        paramRpt.FECHA_TERNINO = dto.txtfechafinMAPRO2;
                    }
                    else if (dto.opcConsulta == 3)
                    {
                        paramRpt.FECHA_INICIO = dto.txtfechainiMAPRO3;
                        paramRpt.FECHA_TERNINO = dto.txtfechafinMAPRO3;
                    }
                    else if (dto.opcConsulta == 4)
                    {
                        paramRpt.FECHA_INICIO = dto.txtfechainiMAPRO4;
                        paramRpt.FECHA_TERNINO = dto.txtfechafinMAPRO4;
                    }
                    else if (dto.opcConsulta == 5)
                    {
                        if (dto.chkFechaini5) paramRpt.FECHA_INICIO = dto.txtfechainiMAPRO5;
                        else paramRpt.FECHA_INICIO = "01/01/1900";

                        paramRpt.FECHA_TERNINO = dto.txtfechafinMAPRO5;
                    }
                    else if (dto.opcConsulta == 6)
                    {
                        if (dto.chkFechaini5) paramRpt.FECHA_INICIO = dto.txtfechainiMAPRO5;
                        else paramRpt.FECHA_INICIO = "01/01/1900";

                        paramRpt.FECHA_TERNINO = dto.txtfechafinMAPRO5;

                        if (dto.chkFechaini6) paramRpt.FECHA_INICIO_DOC = dto.txtfechainiMAPRO6;
                        else paramRpt.FECHA_INICIO_DOC = "01/01/1900";

                        paramRpt.FECHA_TERNINO_DOC = dto.txtfechafinMAPRO6;
                    }
                    else if (dto.opcConsulta == 7)
                    {
                        if (dto.chkFechaini7) paramRpt.FECHA_INICIO = dto.txtfechainiMAPRO7;
                        else paramRpt.FECHA_INICIO = "01/01/1900";

                        paramRpt.FECHA_TERNINO = dto.txtfechafinMAPRO7;
                    }
                    else if (dto.opcConsulta == 8)
                    {
                        if (dto.chkFechaini7) paramRpt.FECHA_INICIO = dto.txtfechainiMAPRO7;
                        else paramRpt.FECHA_INICIO = "01/01/1900";

                        paramRpt.FECHA_TERNINO = dto.txtfechafinMAPRO7;

                        if (dto.chkFechaini8) paramRpt.FECHA_INICIO_DOC = dto.txtfechainiMAPRO8;
                        else paramRpt.FECHA_INICIO_DOC = "01/01/1900";

                        paramRpt.FECHA_TERNINO_DOC = dto.txtfechafinMAPRO8;
                    }
                }
                else if (dto.idTab == 3)
                {
                    paramRpt.COD_DLINEA = dto.ddlSubdirPEIId;
                    paramRpt.FECHA_INICIO = dto.txtfechainiPEI1;
                    paramRpt.FECHA_TERNINO = dto.txtfechafinPEI1;
                }

                olResult = exeRpt.ReporteGeneral(paramRpt);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msj = ex.Message });
            }

            var jsonResult = Json(new { success = true, msj = "", data = olResult.ToArray() }, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }
    }
}