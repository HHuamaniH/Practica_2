using CapaEntidad.DOC;
using CapaEntidad.ViewModel;
using CapaLogica.DOC;
using OfficeOpenXml;
using SIGOFCv3.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SIGOFCv3.Areas.THabilitante.Controllers
{
    public class LibroOperacionesController : Controller
    {
        // GET: THabilitante/LibroOperaciones
        Log_Libro_Operaciones log = null;
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult LibroOperaciones(int id = 0)
        {
            log = new Log_Libro_Operaciones();
            return View(log.init(id));
        }
        [HttpPost]
        public JsonResult createLibroOperacioneTH(VM_Libro_Operaciones_THabilitante vm)
        {
            ListResult result = new ListResult();
            try
            {
                log = new Log_Libro_Operaciones();
                long id = log.createLibroOperacioneTH(vm, (ModelSession.GetSession())[0].COD_UCUENTA);
                result.success = true;
                result.values = new List<string>();
                result.values.Add(id.ToString());
                result.msj = "Se registo correctamente la información";
            }
            catch (Exception ex)
            {
                result.success = false;
                result.msj = ex.Message;
            }
            return Json(result);
        }
        public Ent_LIBRO_OPERACIONES_ARCHIVO fnLibroOperacionesArchivo(HttpPostedFileBase file, string LIBRO_OPERACIONES_TH_ID)
        {
            string fileName = "", extArch = "", NOMBRE_GENERADO = "", NOMBRE_ARCH = "";
            fileName = file.FileName;
            NOMBRE_ARCH = fileName.Substring(0, fileName.LastIndexOf("."));
            NOMBRE_ARCH = (NOMBRE_ARCH.Length >= 400 ? NOMBRE_ARCH.Substring(0, 400) : NOMBRE_ARCH);
            extArch = fileName.Substring(fileName.LastIndexOf(".") + 1).ToLower();
            NOMBRE_GENERADO = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString();
            NOMBRE_ARCH = NOMBRE_ARCH + "." + extArch;
            NOMBRE_GENERADO = NOMBRE_GENERADO + "." + extArch;
            file.SaveAs(Path.Combine(Server.MapPath("~/Archivos/Modulo/Libro_Operaciones/Temp/"), NOMBRE_GENERADO));
            Ent_LIBRO_OPERACIONES_ARCHIVO entidadLibroOperacionesArchivo = new Ent_LIBRO_OPERACIONES_ARCHIVO
            {
                NOMBRE_ARCH = NOMBRE_ARCH,
                NOMBRE_GENERADO = NOMBRE_GENERADO,
                COD_UCUENTA = (ModelSession.GetSession())[0].COD_UCUENTA,
                OUTPUTPARAM02 = "",
                LIBRO_OPERACIONES_TH_ID = long.Parse(LIBRO_OPERACIONES_TH_ID)
            };
            return entidadLibroOperacionesArchivo;
        }
        [HttpPost]
        public JsonResult ImportarItemsExcel()
        {
            bool success = true;
            object retorna = new object();
            string msj = "Se registro correctamente";
            string codUcuenta = (ModelSession.GetSession())[0].COD_UCUENTA;
            Ent_LIBRO_OPERACIONES_ARCHIVO LIBRO_OPERACIONES_ARCHIVO = null;
            try
            {  //Ent_LIBRO_OPERACIONES_ARCHIVO
                if (Request != null)
                {
                    HttpPostedFileBase file = Request.Files[0];
                    string LIBRO_OPERACIONES_TH_ID = Request.Params["LIBRO_OPERACIONES_TH_ID"].ToString();
                    if ((file != null) && (file.ContentLength > 0) && !string.IsNullOrEmpty(file.FileName))
                    {

                        List<Ent_Libro_Operaciones> lstLibroOP = new List<Ent_Libro_Operaciones>();
                        using (var package = new ExcelPackage(file.InputStream))
                        {
                            var currentSheet = package.Workbook.Worksheets;
                            var workSheet = currentSheet.First();
                            var endRow = workSheet.Dimension.End.Row;
                            var iniRow = 10;
                            Ent_Libro_Operaciones LibroOP = new Ent_Libro_Operaciones();
                            String codCenso = "", codCensoAnterior = "";

                            for (int i = iniRow; i <= endRow; i++)
                            {
                                codCenso = workSheet.Cells[i, 3].Value.ToString().Trim();
                                Ent_Libro_Operaciones_Movimientos detalle = new Ent_Libro_Operaciones_Movimientos();
                                if (codCenso != codCensoAnterior)
                                {   //if(i!=iniRow)
                                    //lstLibroOP.Add(LibroOP);
                                    LibroOP = new Ent_Libro_Operaciones();
                                    codCensoAnterior = codCenso;
                                    LibroOP.COD_UCUENTA = codUcuenta;
                                    LibroOP.LIBRO_OPERACIONES_TH_ID = long.Parse(LIBRO_OPERACIONES_TH_ID);
                                    LibroOP.OUTPUTPARAM02 = "";
                                    LibroOP.CODIGO = codCenso;
                                    LibroOP.NOMBRE_ESPECIE = workSheet.Cells[i, 4].Value == null ? "" : workSheet.Cells[i, 4].Value.ToString().Trim();
                                    LibroOP.PC = workSheet.Cells[i, 1].Value == null ? "" : workSheet.Cells[i, 1].Value.ToString().Trim();
                                    LibroOP.FAJA = workSheet.Cells[i, 2].Value == null ? "" : workSheet.Cells[i, 2].Value.ToString().Trim();
                                    LibroOP.DAP = workSheet.Cells[i, 5].Value == null ? (decimal?)null : decimal.Parse(workSheet.Cells[i, 5].Value.ToString());
                                    LibroOP.HC = workSheet.Cells[i, 6].Value == null ? (decimal?)null : decimal.Parse(workSheet.Cells[i, 6].Value.ToString());
                                    LibroOP.VOL = workSheet.Cells[i, 7].Value == null ? (decimal?)null : decimal.Parse(workSheet.Cells[i, 7].Value.ToString());
                                    LibroOP.CF = workSheet.Cells[i, 8].Value == null ? "" : workSheet.Cells[i, 8].Value.ToString().Trim();
                                    LibroOP.DTB = workSheet.Cells[i, 9].Value == null ? (decimal?)null : decimal.Parse(workSheet.Cells[i, 9].Value.ToString());
                                    LibroOP.DTE = workSheet.Cells[i, 10].Value == null ? (decimal?)null : decimal.Parse(workSheet.Cells[i, 10].Value.ToString());
                                    LibroOP.LADO = workSheet.Cells[i, 11].Value == null ? "" : workSheet.Cells[i, 11].Value.ToString().Trim();
                                    LibroOP.COORDENADA_X = workSheet.Cells[i, 12].Value == null ? "" : workSheet.Cells[i, 12].Value.ToString().Trim();
                                    LibroOP.COORDENADA_Y = workSheet.Cells[i, 13].Value == null ? "" : workSheet.Cells[i, 13].Value.ToString().Trim();
                                    LibroOP.CONDICION = workSheet.Cells[i, 14].Value == null ? "" : workSheet.Cells[i, 14].Value.ToString().Trim();
                                    LibroOP.OBSERVACION = workSheet.Cells[i, 15].Value == null ? "" : workSheet.Cells[i, 15].Value.ToString().Trim();

                                    LibroOP.detalleMovimientos = new List<Ent_Libro_Operaciones_Movimientos>();
                                    //detalle
                                    //tala
                                    detalle.TALA_F = workSheet.Cells[i, 16].Value == null ? (DateTime?)null : Convert.ToDateTime(workSheet.Cells[i, 16].Value.ToString());
                                    detalle.TALA_D1 = workSheet.Cells[i, 17].Value == null ? (decimal?)null : decimal.Parse(workSheet.Cells[i, 17].Value.ToString());
                                    detalle.TALA_D2 = workSheet.Cells[i, 18].Value == null ? (decimal?)null : decimal.Parse(workSheet.Cells[i, 18].Value.ToString());
                                    detalle.TALA_L = workSheet.Cells[i, 19].Value == null ? (decimal?)null : decimal.Parse(workSheet.Cells[i, 19].Value.ToString());
                                    detalle.TALA_V = workSheet.Cells[i, 20].Value == null ? (decimal?)null : decimal.Parse(workSheet.Cells[i, 20].Value.ToString());
                                    detalle.TALA_OBS = workSheet.Cells[i, 21].Value == null ? "" : workSheet.Cells[i, 21].Value.ToString().Trim();
                                    //arrastre
                                    detalle.ARRASTRE_CT = workSheet.Cells[i, 22].Value == null ? "" : workSheet.Cells[i, 22].Value.ToString().Trim();
                                    detalle.ARRASTRE_F = workSheet.Cells[i, 23].Value == null ? (DateTime?)null : Convert.ToDateTime(workSheet.Cells[i, 23].Value.ToString());
                                    detalle.ARRASTRE_D1 = workSheet.Cells[i, 24].Value == null ? (decimal?)null : decimal.Parse(workSheet.Cells[i, 24].Value.ToString());
                                    detalle.ARRASTRE_D2 = workSheet.Cells[i, 25].Value == null ? (decimal?)null : decimal.Parse(workSheet.Cells[i, 25].Value.ToString());
                                    detalle.ARRASTRE_L = workSheet.Cells[i, 26].Value == null ? (decimal?)null : decimal.Parse(workSheet.Cells[i, 26].Value.ToString());
                                    detalle.ARRASTRE_V = workSheet.Cells[i, 27].Value == null ? (decimal?)null : decimal.Parse(workSheet.Cells[i, 27].Value.ToString());
                                    //trozado
                                    detalle.TROZADO_CT = workSheet.Cells[i, 28].Value == null ? "" : workSheet.Cells[i, 28].Value.ToString().Trim();
                                    detalle.TROZADO_F = workSheet.Cells[i, 29].Value == null ? (DateTime?)null : Convert.ToDateTime(workSheet.Cells[i, 29].Value.ToString());
                                    detalle.TROZADO_D1 = workSheet.Cells[i, 30].Value == null ? (decimal?)null : decimal.Parse(workSheet.Cells[i, 30].Value.ToString());
                                    detalle.TROZADO_D2 = workSheet.Cells[i, 31].Value == null ? (decimal?)null : decimal.Parse(workSheet.Cells[i, 31].Value.ToString());
                                    detalle.TROZADO_L = workSheet.Cells[i, 32].Value == null ? (decimal?)null : decimal.Parse(workSheet.Cells[i, 32].Value.ToString());
                                    detalle.TROZADO_V = workSheet.Cells[i, 33].Value == null ? (decimal?)null : decimal.Parse(workSheet.Cells[i, 33].Value.ToString());
                                    //despacho transporte
                                    detalle.TRANSPORTE_N_GTF = workSheet.Cells[i, 34].Value == null ? "" : workSheet.Cells[i, 34].Value.ToString().Trim();
                                    detalle.TRANSPORTE_F_EMISION = workSheet.Cells[i, 35].Value == null ? (DateTime?)null : Convert.ToDateTime(workSheet.Cells[i, 35].Value.ToString());
                                    detalle.TRANSPORTE_DESTINO = workSheet.Cells[i, 36].Value == null ? "" : workSheet.Cells[i, 36].Value.ToString().Trim();
                                    detalle.TRANSPORTE_CONDUCTOR = workSheet.Cells[i, 37].Value == null ? "" : workSheet.Cells[i, 37].Value.ToString().Trim();
                                    detalle.TRANSPORTE_PLACA = workSheet.Cells[i, 38].Value == null ? "" : workSheet.Cells[i, 38].Value.ToString().Trim();
                                    detalle.CONDICION = workSheet.Cells[i, 39].Value == null ? "" : workSheet.Cells[i, 39].Value.ToString().Trim();
                                    //agregando detalle
                                    LibroOP.detalleMovimientos.Add(detalle);
                                    lstLibroOP.Add(LibroOP);
                                }
                                else
                                {
                                    //detalle
                                    //tala
                                    detalle.TALA_F = workSheet.Cells[i, 16].Value == null ? (DateTime?)null : Convert.ToDateTime(workSheet.Cells[i, 16].Value.ToString());
                                    detalle.TALA_D1 = workSheet.Cells[i, 17].Value == null ? (decimal?)null : decimal.Parse(workSheet.Cells[i, 17].Value.ToString());
                                    detalle.TALA_D2 = workSheet.Cells[i, 18].Value == null ? (decimal?)null : decimal.Parse(workSheet.Cells[i, 18].Value.ToString());
                                    detalle.TALA_L = workSheet.Cells[i, 19].Value == null ? (decimal?)null : decimal.Parse(workSheet.Cells[i, 19].Value.ToString());
                                    detalle.TALA_V = workSheet.Cells[i, 20].Value == null ? (decimal?)null : decimal.Parse(workSheet.Cells[i, 20].Value.ToString());
                                    detalle.TALA_OBS = workSheet.Cells[i, 21].Value == null ? "" : workSheet.Cells[i, 21].Value.ToString().Trim();
                                    //arrastre
                                    detalle.ARRASTRE_CT = workSheet.Cells[i, 22].Value == null ? "" : workSheet.Cells[i, 22].Value.ToString().Trim();
                                    detalle.ARRASTRE_F = workSheet.Cells[i, 23].Value == null ? (DateTime?)null : Convert.ToDateTime(workSheet.Cells[i, 23].Value.ToString());
                                    detalle.ARRASTRE_D1 = workSheet.Cells[i, 24].Value == null ? (decimal?)null : decimal.Parse(workSheet.Cells[i, 24].Value.ToString());
                                    detalle.ARRASTRE_D2 = workSheet.Cells[i, 25].Value == null ? (decimal?)null : decimal.Parse(workSheet.Cells[i, 25].Value.ToString());
                                    detalle.ARRASTRE_L = workSheet.Cells[i, 26].Value == null ? (decimal?)null : decimal.Parse(workSheet.Cells[i, 26].Value.ToString());
                                    detalle.ARRASTRE_V = workSheet.Cells[i, 27].Value == null ? (decimal?)null : decimal.Parse(workSheet.Cells[i, 27].Value.ToString());
                                    //trozado
                                    detalle.TROZADO_CT = workSheet.Cells[i, 28].Value == null ? "" : workSheet.Cells[i, 28].Value.ToString().Trim();
                                    detalle.TROZADO_F = workSheet.Cells[i, 29].Value == null ? (DateTime?)null : Convert.ToDateTime(workSheet.Cells[i, 29].Value.ToString());
                                    detalle.TROZADO_D1 = workSheet.Cells[i, 30].Value == null ? (decimal?)null : decimal.Parse(workSheet.Cells[i, 30].Value.ToString());
                                    detalle.TROZADO_D2 = workSheet.Cells[i, 31].Value == null ? (decimal?)null : decimal.Parse(workSheet.Cells[i, 31].Value.ToString());
                                    detalle.TROZADO_L = workSheet.Cells[i, 32].Value == null ? (decimal?)null : decimal.Parse(workSheet.Cells[i, 32].Value.ToString());
                                    detalle.TROZADO_V = workSheet.Cells[i, 33].Value == null ? (decimal?)null : decimal.Parse(workSheet.Cells[i, 33].Value.ToString());
                                    //despacho transporte
                                    detalle.TRANSPORTE_N_GTF = workSheet.Cells[i, 34].Value == null ? "" : workSheet.Cells[i, 34].Value.ToString().Trim();
                                    detalle.TRANSPORTE_F_EMISION = workSheet.Cells[i, 35].Value == null ? (DateTime?)null : Convert.ToDateTime(workSheet.Cells[i, 35].Value.ToString());
                                    detalle.TRANSPORTE_DESTINO = workSheet.Cells[i, 36].Value == null ? "" : workSheet.Cells[i, 36].Value.ToString().Trim();
                                    detalle.TRANSPORTE_CONDUCTOR = workSheet.Cells[i, 37].Value == null ? "" : workSheet.Cells[i, 37].Value.ToString().Trim();
                                    detalle.TRANSPORTE_PLACA = workSheet.Cells[i, 38].Value == null ? "" : workSheet.Cells[i, 38].Value.ToString().Trim();
                                    detalle.CONDICION = workSheet.Cells[i, 39].Value == null ? "" : workSheet.Cells[i, 39].Value.ToString().Trim();
                                    //agregando detalle
                                    LibroOP.detalleMovimientos.Add(detalle);
                                }
                            }
                        }
                        //registrando
                        log = new Log_Libro_Operaciones();
                        LIBRO_OPERACIONES_ARCHIVO = fnLibroOperacionesArchivo(file, LIBRO_OPERACIONES_TH_ID);
                        if (log.createLibroOperacionesMovimientos(lstLibroOP, LIBRO_OPERACIONES_ARCHIVO))
                        {
                            string direcTemp = "~/Archivos/Modulo/Libro_Operaciones/Temp/";
                            string direcDestino = "~/Archivos/Modulo/Libro_Operaciones/";
                            if (System.IO.File.Exists(Path.Combine(Server.MapPath(direcTemp), LIBRO_OPERACIONES_ARCHIVO.NOMBRE_GENERADO)))
                            {
                                System.IO.File.Copy(Path.Combine(Server.MapPath(direcTemp), LIBRO_OPERACIONES_ARCHIVO.NOMBRE_GENERADO), Server.MapPath(direcDestino + LIBRO_OPERACIONES_ARCHIVO.NOMBRE_GENERADO));
                                System.IO.File.Delete(Path.Combine(Server.MapPath(direcTemp), LIBRO_OPERACIONES_ARCHIVO.NOMBRE_GENERADO));
                            }
                        }
                        success = true;
                    }
                }
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                if (LIBRO_OPERACIONES_ARCHIVO != null)
                {
                    string direcTemp = "~/Archivos/Modulo/Libro_Operaciones/Temp/";
                    if (System.IO.File.Exists(Path.Combine(Server.MapPath(direcTemp), LIBRO_OPERACIONES_ARCHIVO.NOMBRE_GENERADO)))
                    {
                        System.IO.File.Delete(Path.Combine(Server.MapPath(direcTemp), LIBRO_OPERACIONES_ARCHIVO.NOMBRE_GENERADO));
                    }
                }
                success = false;
                msj = "Sucedio un error. No se pudo registrar la información";
            }
            var jsonResult = Json(new { success = success, msj = msj }, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

    }
}