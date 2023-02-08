using CapaEntidad.ViewModel;
using CapaEntidad.ViewModel.General;
using OfficeOpenXml;
using SIGOFCv3.Helper;
using SIGOFCv3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CEntidad = CapaEntidad.DOC.Ent_DEVOLUCION_MADERA;
using CLogica = CapaLogica.DOC.Log_DEVOLUCION_MADERA;
using VModel = CapaEntidad.ViewModel.VM_DevolucionMadera;

namespace SIGOFCv3.Areas.THabilitante.Controllers
{
    public class ManDevolucionMaderaController : Controller
    {
        //Validar que el usuario que ingresa a la acción (vista) tenga asignado el menú respectivo (Tabla: SISTEMA_MODULOS_DET_MENU: Columna: COD_SECUENCIAL)
        // GET: THabilitante/ManDevolucionMadera
        public ActionResult Index()
        {
            ViewBag.Formulario = "DEVOLUCION_MADERA";
            ViewBag.TituloFormulario = "DEVOLUCIÓN DE MADERA";
            //obtenemos el rol sobre el formulario
            VM_Menu_Rol mr = HelperSigo.GetRol("MODULO TITULO HABILITANTE", "Devolución de Madera");
            ViewBag.CodRol = mr.NCODROL;
            ViewBag.VAliasRol = mr.VALIAS;
            return View();
        }

        //[HttpGet]
        //public ActionResult AddEdit(string codigoDato, string codigoComplementario, int nuevo, string tipoFrmulario)
        //{
        //    try
        //    {
        //        VModel objVM;
        //        CLogica objLog = new CLogica();
        //        //obtenemos el rol sobre el formulario
        //        VM_Menu_Rol mr = HelperSigo.GetRol("MODULO TITULO HABILITANTE", "Devolución de Madera");
        //        ViewBag.CodRol = mr.NCODROL;
        //        ViewBag.VAliasRol = mr.VALIAS;
        //        objVM = objLog.IniDatos(
        //            codigoDato,
        //            codigoComplementario,
        //            (ModelSession.GetSession())[0].COD_UCUENTA,
        //            nuevo, mr.VALIAS
        //         );

        //        objVM.TipoFormulario = tipoFrmulario;
        //        TempData["ListDEVOLCENSOTROZA"] = objVM.ListDEVOLCENSOTROZA;
        //        objVM.ListDEVOLCENSOTROZA = null;
        //        TempData["ListDEVOLCENSOTOCON"] = objVM.ListDEVOLCENSOTOCON;
        //        objVM.ListDEVOLCENSOTOCON = null;
        //        TempData["ListDEVOLCENSOARBOL"] = objVM.ListDEVOLCENSOARBOL;
        //        objVM.ListDEVOLCENSOARBOL = null;


        //        return View(objVM);


        //    }
        //    catch (Exception ex)
        //    {
        //        return RedirectToAction("ErrorC: " + ex.ToString(), "Login", new { Area = "" });
        //    }
        //}

        [HttpPost]
        public JsonResult ImportarDataExcel()
        {


            bool success = true;
            object retorna = new object();

            string msj = "";
            try
            {
                if (Request != null)
                {
                    HttpPostedFileBase file = Request.Files[0];
                    if ((file != null) && (file.ContentLength > 0) && !string.IsNullOrEmpty(file.FileName))
                    {

                        using (var package = new ExcelPackage(file.InputStream))
                        {
                            var currentSheet = package.Workbook.Worksheets;
                            var workSheet = currentSheet.First();
                            var noOfCol = workSheet.Dimension.End.Column;
                            var noOfRow = workSheet.Dimension.End.Row;


                            //Recorriendo Datos
                            CEntidad oCampos;
                            //ListBusqueda<CEntidad> oListBus;     
                            string hdfItemExcelImportar = Request["TVentana"];

                            List<CEntidad> ListItemsDetalle = new List<CEntidad>();

                            switch (hdfItemExcelImportar)
                            {
                                #region ESPDEV
                                case "ESPDEV":
                                    for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                                    {
                                        oCampos = new CEntidad();
                                        oCampos.COD_SECUENCIAL = 0;
                                        oCampos.COD_ESPECIES = "";
                                        oCampos.NUM_TROZAS = Int32.Parse(workSheet.Cells[rowIterator, 3].Value.ToString().Trim());
                                        oCampos.VOLUMEN = Decimal.Parse(workSheet.Cells[rowIterator, 4].Value.ToString().Trim());

                                        oCampos.COORDENADA_ESTE = Int32.Parse(workSheet.Cells[rowIterator, 5].Value.ToString().Trim());
                                        oCampos.COORDENADA_NORTE = Int32.Parse(workSheet.Cells[rowIterator, 6].Value.ToString().Trim());
                                        oCampos.OBSERVACION = workSheet.Cells[rowIterator, 7].Value.ToString().Trim();
                                        oCampos.ESPECIES = String.Format("{0} | {1}", workSheet.Cells[rowIterator, 1].Value.ToString().Trim(), workSheet.Cells[rowIterator, 2].Value.ToString());
                                        oCampos.RegEstado = 1;
                                        ListItemsDetalle.Add(oCampos);
                                    }
                                    retorna = (from row in ListItemsDetalle
                                               select new
                                               {
                                                   row.COD_SECUENCIAL,
                                                   row.COD_ESPECIES,
                                                   row.NUM_TROZAS,
                                                   row.VOLUMEN,
                                                   row.COORDENADA_ESTE,
                                                   row.COORDENADA_NORTE,
                                                   row.OBSERVACION,
                                                   row.ESPECIES,
                                                   row.RegEstado
                                               }
                                               );
                                    break;
                                #endregion
                                #region ESPHAL
                                case "ESPHAL":
                                    for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                                    {
                                        oCampos = new CEntidad();
                                        oCampos.COD_SECUENCIAL = 0;
                                        oCampos.COD_ESPECIES = "";
                                        oCampos.NUM_TROZAS = Int32.Parse(workSheet.Cells[rowIterator, 3].Value.ToString().Trim());
                                        oCampos.VOLUMEN = Decimal.Parse(workSheet.Cells[rowIterator, 4].Value.ToString().Trim());
                                        oCampos.COORDENADA_ESTE = Int32.Parse(workSheet.Cells[rowIterator, 5].Value.ToString().Trim());
                                        oCampos.COORDENADA_NORTE = Int32.Parse(workSheet.Cells[rowIterator, 6].Value.ToString().Trim());
                                        oCampos.OBSERVACION = workSheet.Cells[rowIterator, 7].Value.ToString().Trim();
                                        oCampos.ESPECIES = String.Format("{0} | {1}", workSheet.Cells[rowIterator, 1].Value.ToString().Trim(), workSheet.Cells[rowIterator, 2].Value.ToString());
                                        oCampos.RegEstado = 1;
                                        ListItemsDetalle.Add(oCampos);
                                    }
                                    retorna = (from row in ListItemsDetalle
                                               select new
                                               {
                                                   row.COD_SECUENCIAL,
                                                   row.COD_ESPECIES,
                                                   row.NUM_TROZAS,
                                                   row.VOLUMEN,
                                                   row.COORDENADA_ESTE,
                                                   row.COORDENADA_NORTE,
                                                   row.OBSERVACION,
                                                   row.ESPECIES,
                                                   row.RegEstado
                                               }
                                               );
                                    break;
                                #endregion
                                #region BEMADE
                                case "BEMADE":
                                    for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                                    {
                                        oCampos = new CEntidad();
                                        oCampos.COD_SECUENCIAL = 0;
                                        oCampos.COD_ESPECIES = "";
                                        oCampos.VOLUMEN_AUTORIZADO = Decimal.Parse(workSheet.Cells[rowIterator, 3].Value.ToString().Trim());
                                        oCampos.VOLUMEN_MOVILIZADO = Decimal.Parse(workSheet.Cells[rowIterator, 4].Value.ToString().Trim());
                                        oCampos.SALDO = Decimal.Parse(workSheet.Cells[rowIterator, 5].Value.ToString().Trim());
                                        oCampos.OBSERVACION = workSheet.Cells[rowIterator, 6].Value.ToString().Trim();
                                        oCampos.ESPECIES = String.Format("{0} | {1}", workSheet.Cells[rowIterator, 1].Value.ToString().Trim(), workSheet.Cells[rowIterator, 2].Value.ToString());
                                        oCampos.RegEstado = 1;
                                        ListItemsDetalle.Add(oCampos);
                                    }
                                    retorna = (from row in ListItemsDetalle
                                               select new
                                               {
                                                   row.COD_SECUENCIAL,
                                                   row.COD_ESPECIES,
                                                   row.VOLUMEN_AUTORIZADO,
                                                   row.VOLUMEN_MOVILIZADO,
                                                   row.SALDO,
                                                   row.OBSERVACION,
                                                   row.ESPECIES,
                                                   row.RegEstado
                                               }
                                               );
                                    break;
                                #endregion

                                #region VERTICE
                                case "VERTICE":
                                    for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                                    {
                                        oCampos = new CEntidad();
                                        oCampos.VERTICE = workSheet.Cells[rowIterator, 1].Value.ToString().Trim();
                                        oCampos.COORDENADA_ESTE = Int32.Parse(workSheet.Cells[rowIterator, 2].Value.ToString().Trim());
                                        oCampos.COORDENADA_NORTE = Int32.Parse(workSheet.Cells[rowIterator, 3].Value.ToString().Trim());
                                        oCampos.OBSERVACION = workSheet.Cells[rowIterator, 4].Value.ToString().Trim();
                                        oCampos.COD_SECUENCIAL = 0;
                                        oCampos.RegEstado = 1;
                                        ListItemsDetalle.Add(oCampos);
                                    }
                                    retorna = (from row in ListItemsDetalle
                                               select new
                                               {
                                                   row.VERTICE,
                                                   row.COORDENADA_ESTE,
                                                   row.COORDENADA_NORTE,
                                                   row.OBSERVACION,
                                                   row.COD_SECUENCIAL,
                                                   row.RegEstado
                                               }
                                               );
                                    break;
                                #endregion

                                #region CTROZA
                                case "CTROZA":
                                    for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                                    {
                                        oCampos = new CEntidad();
                                        oCampos.COD_SECUENCIAL = 0;
                                        oCampos.COD_ESPECIES = "";
                                        oCampos.CODIGO = workSheet.Cells[rowIterator, 3].Value.ToString().Trim();
                                        oCampos.DAP = Decimal.Parse(workSheet.Cells[rowIterator, 4].Value.ToString().Trim());
                                        oCampos.ALTURA = Decimal.Parse(workSheet.Cells[rowIterator, 5].Value.ToString().Trim());
                                        oCampos.VOLUMEN = Decimal.Parse(workSheet.Cells[rowIterator, 6].Value.ToString().Trim());
                                        oCampos.COORDENADA_ESTE = Int32.Parse(workSheet.Cells[rowIterator, 7].Value.ToString().Trim());
                                        oCampos.COORDENADA_NORTE = Int32.Parse(workSheet.Cells[rowIterator, 8].Value.ToString().Trim());
                                        oCampos.NUM_TROZAS = Int32.Parse(workSheet.Cells[rowIterator, 9].Value.ToString().Trim());
                                        oCampos.DESCRIPCION = workSheet.Cells[rowIterator, 10].Value.ToString().Trim();
                                        oCampos.OBSERVACION = workSheet.Cells[rowIterator, 11].Value.ToString().Trim();
                                        oCampos.ESPECIES = String.Format("{0} | {1}", workSheet.Cells[rowIterator, 1].Value.ToString().Trim(), workSheet.Cells[rowIterator, 2].Value.ToString());
                                        oCampos.RegEstado = 1;
                                        ListItemsDetalle.Add(oCampos);
                                    }
                                    retorna = (from row in ListItemsDetalle
                                               select new
                                               {
                                                   row.COD_SECUENCIAL,
                                                   row.COD_ESPECIES,
                                                   row.CODIGO,
                                                   row.DAP,
                                                   row.ALTURA,
                                                   row.VOLUMEN,
                                                   row.COORDENADA_ESTE,
                                                   row.COORDENADA_NORTE,
                                                   row.NUM_TROZAS,
                                                   row.DESCRIPCION,
                                                   row.OBSERVACION,
                                                   row.ESPECIES,
                                                   row.RegEstado
                                               }
                                               );
                                    break;
                                #endregion

                                #region CTOCON
                                case "CTOCON":
                                    for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                                    {
                                        oCampos = new CEntidad();
                                        oCampos.COD_SECUENCIAL = 0;
                                        oCampos.COD_ESPECIES = "";
                                        oCampos.CODIGO = workSheet.Cells[rowIterator, 3].Value.ToString().Trim();
                                        oCampos.DIAMETRO = Decimal.Parse(workSheet.Cells[rowIterator, 4].Value.ToString().Trim());
                                        oCampos.LARGO = Decimal.Parse(workSheet.Cells[rowIterator, 5].Value.ToString().Trim());
                                        oCampos.VOLUMEN = Decimal.Parse(workSheet.Cells[rowIterator, 6].Value.ToString().Trim());
                                        oCampos.COORDENADA_ESTE = Int32.Parse(workSheet.Cells[rowIterator, 7].Value.ToString().Trim());
                                        oCampos.COORDENADA_NORTE = Int32.Parse(workSheet.Cells[rowIterator, 8].Value.ToString().Trim());
                                        oCampos.CANTIDAD = Int32.Parse(workSheet.Cells[rowIterator, 9].Value.ToString().Trim());
                                        oCampos.DESCRIPCION = workSheet.Cells[rowIterator, 10].Value.ToString().Trim();
                                        oCampos.OBSERVACION = workSheet.Cells[rowIterator, 11].Value.ToString().Trim();
                                        oCampos.ESPECIES = String.Format("{0} | {1}", workSheet.Cells[rowIterator, 1].Value.ToString().Trim(), workSheet.Cells[rowIterator, 2].Value.ToString());
                                        oCampos.RegEstado = 1;
                                        ListItemsDetalle.Add(oCampos);
                                    }
                                    retorna = (from row in ListItemsDetalle
                                               select new
                                               {
                                                   row.COD_SECUENCIAL,
                                                   row.COD_ESPECIES,
                                                   row.CODIGO,
                                                   row.DIAMETRO,
                                                   row.LARGO,
                                                   row.VOLUMEN,
                                                   row.COORDENADA_ESTE,
                                                   row.COORDENADA_NORTE,
                                                   row.CANTIDAD,
                                                   row.DESCRIPCION,
                                                   row.OBSERVACION,
                                                   row.ESPECIES,
                                                   row.RegEstado
                                               }
                                               );
                                    break;
                                #endregion
                                #region CARBOL
                                case "CARBOL":
                                    for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                                    {
                                        oCampos = new CEntidad();
                                        oCampos.COD_SECUENCIAL = 0;
                                        oCampos.COD_ESPECIES = "";
                                        oCampos.NUM_PCA = workSheet.Cells[rowIterator, 3].Value.ToString().Trim();
                                        oCampos.CODIGO = workSheet.Cells[rowIterator, 4].Value.ToString().Trim();
                                        oCampos.DAP = Decimal.Parse(workSheet.Cells[rowIterator, 5].Value.ToString().Trim());
                                        oCampos.ALTURA = Decimal.Parse(workSheet.Cells[rowIterator, 6].Value.ToString().Trim());
                                        oCampos.VOLUMEN = Decimal.Parse(workSheet.Cells[rowIterator, 7].Value.ToString().Trim());
                                        oCampos.COORDENADA_ESTE = Int32.Parse(workSheet.Cells[rowIterator, 8].Value.ToString().Trim());
                                        oCampos.COORDENADA_NORTE = Int32.Parse(workSheet.Cells[rowIterator, 9].Value.ToString().Trim());
                                        oCampos.COD_ECONDICION = "";
                                        oCampos.COD_EESTADO = "";
                                        oCampos.CONDICION = workSheet.Cells[rowIterator, 10].Value.ToString().Trim();
                                        oCampos.ESTADO = workSheet.Cells[rowIterator, 11].Value.ToString().Trim();
                                        oCampos.OBSERVACION = workSheet.Cells[rowIterator, 12].Value.ToString().Trim();
                                        oCampos.ESPECIES = String.Format("{0} | {1}", workSheet.Cells[rowIterator, 1].Value.ToString().Trim(), workSheet.Cells[rowIterator, 2].Value.ToString());
                                        oCampos.RegEstado = 1;
                                        ListItemsDetalle.Add(oCampos);
                                    }
                                    retorna = (from row in ListItemsDetalle
                                               select new
                                               {
                                                   row.COD_SECUENCIAL,
                                                   row.COD_ESPECIES,
                                                   row.NUM_PCA,
                                                   row.CODIGO,
                                                   row.DAP,
                                                   row.ALTURA,
                                                   row.VOLUMEN,
                                                   row.COORDENADA_ESTE,
                                                   row.COORDENADA_NORTE,
                                                   row.COD_ECONDICION,
                                                   row.COD_EESTADO,
                                                   row.CONDICION,
                                                   row.ESTADO,
                                                   row.OBSERVACION,
                                                   row.ESPECIES,
                                                   row.RegEstado
                                               }
                                               );
                                    break;
                                    #endregion

                            }










                        }
                    }
                }

            }
            catch (Exception ex)
            {
                success = false;
                string[] mensaje = ex.Message.Split('|');
                if (mensaje[0] == "0")
                    msj = mensaje[1];
                else msj = ex.Message;
            }
            var jsonResult = Json(new { success = success, msj = msj, data = retorna });
            jsonResult.MaxJsonLength = int.MaxValue;


            return jsonResult;
        }

        [HttpGet]
        public JsonResult GetAllCTroza()
        {
            List<CEntidad> data = (List<CEntidad>)TempData["ListDEVOLCENSOTROZA"];
            data = data ?? new List<CEntidad>();

            var lstMin = from cust in data
                         select new
                         {

                             ESPECIES = cust.ESPECIES,
                             CODIGO = cust.CODIGO,
                             DAP = cust.DAP,
                             ALTURA = cust.ALTURA,
                             VOLUMEN = cust.VOLUMEN,
                             COORDENADA_ESTE = cust.COORDENADA_ESTE,
                             COORDENADA_NORTE = cust.COORDENADA_NORTE,
                             NUM_TROZAS = cust.NUM_TROZAS,
                             DESCRIPCION = cust.DESCRIPCION,
                             OBSERVACION = cust.OBSERVACION,
                             COD_SECUENCIAL = cust.COD_SECUENCIAL,
                             COD_ESPECIES = cust.COD_ESPECIES,
                             RegEstado = cust.RegEstado

                         };
            var jsonResult = Json(new { data = lstMin }, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
        [HttpGet]
        public JsonResult GetAllCTocon()
        {
            List<CEntidad> data = (List<CEntidad>)TempData["ListDEVOLCENSOTOCON"];
            data = data ?? new List<CEntidad>();

            var lstMin = from cust in data
                         select new
                         {

                             ESPECIES = cust.ESPECIES,
                             CODIGO = cust.CODIGO,
                             DIAMETRO = cust.DIAMETRO,
                             LARGO = cust.LARGO,
                             VOLUMEN = cust.VOLUMEN,
                             COORDENADA_ESTE = cust.COORDENADA_ESTE,
                             COORDENADA_NORTE = cust.COORDENADA_NORTE,
                             CANTIDAD = cust.CANTIDAD,
                             DESCRIPCION = cust.DESCRIPCION,
                             OBSERVACION = cust.OBSERVACION,
                             COD_SECUENCIAL = cust.COD_SECUENCIAL,
                             COD_ESPECIES = cust.COD_ESPECIES,
                             RegEstado = cust.RegEstado

                         };
            var jsonResult = Json(new { data = lstMin }, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
        [HttpGet]
        public JsonResult GetAllCArbol()
        {
            List<CEntidad> data = (List<CEntidad>)TempData["ListDEVOLCENSOARBOL"];
            data = data ?? new List<CEntidad>();

            var lstMin = from cust in data
                         select new
                         {

                             ESPECIES = cust.ESPECIES,
                             NUM_PCA = cust.NUM_PCA,
                             CODIGO = cust.CODIGO,
                             DAP = cust.DAP,
                             ALTURA = cust.ALTURA,
                             VOLUMEN = cust.VOLUMEN,
                             COORDENADA_ESTE = cust.COORDENADA_ESTE,
                             COORDENADA_NORTE = cust.COORDENADA_NORTE,
                             CONDICION = cust.CONDICION,
                             ESTADO = cust.ESTADO,
                             OBSERVACION = cust.OBSERVACION,
                             COD_SECUENCIAL = cust.COD_SECUENCIAL,
                             COD_ESPECIES = cust.COD_ESPECIES,
                             COD_ECONDICION = cust.COD_ECONDICION,
                             COD_EESTADO = cust.COD_EESTADO,
                             RegEstado = cust.RegEstado

                         };
            var jsonResult = Json(new { data = lstMin }, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        //[HttpPost]

        //public JsonResult RegistrarDM(VModel dto)
        //{

        //    CLogica objLog = new CLogica();
        //    ListResult resultado;
        //    resultado = objLog.GuardarDatosDM(dto, (ModelSession.GetSession())[0].COD_UCUENTA);
        //    return Json(resultado);
        //}


    }
}