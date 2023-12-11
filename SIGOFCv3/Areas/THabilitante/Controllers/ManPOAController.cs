using CapaEntidad.DOC;
using CapaEntidad.ViewModel;
using CapaEntidad.ViewModel.General;
using CapaLogica.DOC;
using Newtonsoft.Json;
using OfficeOpenXml;
using SIGOFCv3.Helper;
using SIGOFCv3.Models;
using SIGOFCv3.Reportes.THabilitante;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CEntidad = CapaEntidad.DOC.Ent_POA;
using CEntidadUC = CapaEntidad.GENE.Ent_USUARIO_CUENTA;

namespace SIGOFCv3.Areas.THabilitante.Controllers
{
    public class ManPOAController : Controller
    {
        public static VM_POA objVM2 = new VM_POA();
        public string NOMARCHTEMP = "";

        //Validar que el usuario que ingresa a la acción (vista) tenga asignado el menú respectivo (Tabla: SISTEMA_MODULOS_DET_MENU: Columna: COD_SECUENCIAL)
        [HttpGet]
        public ActionResult Index(int lstManMenu, string _alertaIncial = "")
        {
            try
            {
                if (lstManMenu == 1)
                {
                    ViewBag.thTipoFrmulario = "POA";
                    ViewBag.thBusFormulario = "POA";
                    ViewBag.thTitleMenu = "POA/PO";
                    ViewBag.thBusCriterio = "TODOS";
                    //obtenemos el rol sobre el formulario
                    VM_Menu_Rol mr = HelperSigo.GetRol("MODULO TITULO HABILITANTE", "POA/PO");
                    ViewBag.CodRol = mr.NCODROL;
                    ViewBag.VAliasRol = mr.VALIAS;
                }
                if (lstManMenu == 2)
                {
                    ViewBag.thTipoFrmulario = "DEMA";
                    ViewBag.thBusFormulario = "DEMA";
                    ViewBag.thTitleMenu = "Declaracion de Manejo";
                    ViewBag.thBusCriterio = "TODOS";
                    //obtenemos el rol sobre el formulario
                    VM_Menu_Rol mr = HelperSigo.GetRol("MODULO TITULO HABILITANTE", "Declaración de Manejo");
                    ViewBag.CodRol = mr.NCODROL;
                    ViewBag.VAliasRol = mr.VALIAS;
                }
                if (lstManMenu == 3)
                {
                    ViewBag.thTipoFrmulario = "PMFI";
                    ViewBag.thBusFormulario = "PMFI";
                    ViewBag.thTitleMenu = "PMFI";
                    ViewBag.thBusCriterio = "TODOS";
                    //obtenemos el rol sobre el formulario
                    VM_Menu_Rol mr = HelperSigo.GetRol("MODULO TITULO HABILITANTE", "PMFI");
                    ViewBag.CodRol = mr.NCODROL;
                    ViewBag.VAliasRol = mr.VALIAS;
                }

                ViewBag.hdfTipoFormulario = "3";
                ViewBag.AlertaInicial = _alertaIncial;

                return View();
            }
            catch (Exception)
            {
                return RedirectToAction("ErrorC", "Login", new { Area = "" });
            }
        }

        [HttpGet]
        public ActionResult AddEdit()
        {
            try
            {
                VM_POA objVM;

                Log_POA objLog = new Log_POA();
                int nuevo = 1; Int16 opRegresar = 0;
                string codigo = "", descripcion = "", tipoFrmulario = "", lstMenu = "";
                string appClient = Request.QueryString["appClient"]; string appData = Request.QueryString["appData"];
                if (appClient != null && appData != null)
                {
                    string origen = appClient.Split('|')[2];
                    if (Request.QueryString["lstManMenu"] != null) { lstMenu = Request.QueryString["lstManMenu"].ToString(); }
                    tipoFrmulario = lstMenu;
                    if (appClient.Split('|')[1] == "TRANSFERIR")
                    {
                        if (origen == "PLAN")
                        {
                            nuevo = 1;
                            #region ADD DEL MENU DE ARRFF
                            if (lstMenu == "1")
                            {
                                ViewBag.thTipoFrmulario = "POA";
                                ViewBag.thBusFormulario = "POA";
                                ViewBag.thTitleMenu = "POA/PO";
                                ViewBag.thBusCriterio = "TODOS";

                            }
                            if (lstMenu == "2")
                            {
                                ViewBag.thTipoFrmulario = "DEMA";
                                ViewBag.thBusFormulario = "DEMA";
                                ViewBag.thTitleMenu = "Declaracion de Manejo";
                                ViewBag.thBusCriterio = "TODOS";

                            }
                            if (lstMenu == "3")
                            {
                                ViewBag.thTipoFrmulario = "PMFI";
                                ViewBag.thBusFormulario = "PMFI";
                                ViewBag.thTitleMenu = "PMFI";
                                ViewBag.thBusCriterio = "TODOS";

                            }

                            ViewBag.hdfTipoFormulario = "3";
                            /*descripcion = Request.QueryString["descripcion"];*/
                            codigo = appData.Split('¬')[3];
                            tipoFrmulario = (lstMenu == "1") ? "POA" : (lstMenu == "2") ? "DEMA" : "PMFI";
                            #endregion
                        }
                        else if (origen == "ACTO")
                        {
                            tipoFrmulario = (lstMenu == "1") ? "POA" : (lstMenu == "2") ? "DEMA" : "PMFI";
                            nuevo = 2;
                        }
                    }
                    else if (appClient.Split('|')[1] == "VISUALIZAR")
                    {
                        nuevo = 0;
                    }

                    opRegresar = 1;
                }
                else
                {
                    nuevo = Convert.ToInt32(Request.QueryString["nuevo"]);
                    codigo = Request.QueryString["codigo"];//000120180000311
                    descripcion = Request.QueryString["descripcion"];//Concesiones - Maderables|25-UCA-PUC/CON-MAD-2018-07|CONSORCIO TAMRIO|M|0000007|25|PN|TAMBO ALVARADO FRANCISCO
                    tipoFrmulario = Request.QueryString["tipoFrmulario"];//POA

                }

                VM_Menu_Rol mr = new VM_Menu_Rol();
                if (tipoFrmulario == "POA")
                {
                    //obtenemos el rol sobre el formulario
                    mr = HelperSigo.GetRol("MODULO TITULO HABILITANTE", "POA/PO");
                    ViewBag.CodRol = mr.NCODROL;
                    ViewBag.VAliasRol = mr.VALIAS;
                }
                if (tipoFrmulario == "DEMA")
                {
                    //obtenemos el rol sobre el formulario
                    mr = HelperSigo.GetRol("MODULO TITULO HABILITANTE", "Declaración de Manejo");
                    ViewBag.CodRol = mr.NCODROL;
                    ViewBag.VAliasRol = mr.VALIAS;
                }
                if (tipoFrmulario == "PMFI")
                {
                    //obtenemos el rol sobre el formulario
                    mr = HelperSigo.GetRol("MODULO TITULO HABILITANTE", "PMFI");
                    ViewBag.CodRol = mr.NCODROL;
                    ViewBag.VAliasRol = mr.VALIAS;
                }
                objVM = objLog.IniDatosPOA(
                    codigo,
                    descripcion,
                    (ModelSession.GetSession())[0].COD_UCUENTA,
                    nuevo, appClient, appData, lstMenu, mr.VALIAS
                    );
                objVM2.ListMadeCENSO = objVM.ListMadeCENSO;
                TempData["listVERTICE"] = objVM.ListVERTICE;
                TempData["listDETREGENTE"] = objVM.ListDETREGENTE;
                TempData["listAOCULAR"] = objVM.ListAOCULAR;
                TempData["listTIOCULAR"] = objVM.ListTIOCULAR;
                TempData["listTRAPROBACION"] = objVM.ListTRAPROBACION;
                TempData["listSAPROBACION"] = objVM.ListSAPROBACION;
                TempData["listRAprueba"] = objVM.ListRAprueba;
                TempData["ListRApruebaISitu"] = objVM.ListRApruebaISitu;
                TempData["listBExtPOA"] = objVM.ListBExtPOA;
                TempData["listMadeCENSO"] = objVM.ListMadeCENSO;
                TempData["listNoMadeCENSO"] = objVM.ListNoMadeCENSO;
                TempData["ListKARDEX"] = objVM.ListKARDEX;
                TempData["listPOAErrorMaterialG"] = objVM.ListPOAErrorMaterialG;
                TempData["listPOAErrorMaterialA"] = objVM.ListPOAErrorMaterialA;
                TempData["listPOARegenteImplementa"] = objVM.ListPOARegenteImplementa;
                objVM.opRegresar = opRegresar;
                objVM.TipoFormulario = tipoFrmulario;
                objVM.ListDETREGENTE = null;
                objVM.ListVERTICE = null;
                objVM.ListAOCULAR = null;
                objVM.ListTIOCULAR = null;
                objVM.ListTRAPROBACION = null;
                objVM.ListRApruebaISitu = null;
                objVM.ListMadeCENSO = null;
                objVM.ListNoMadeCENSO = null;
                objVM.ListKARDEX = null;

                return View(objVM);


            }
            catch (Exception ex)
            {
                return RedirectToAction("ErrorC: " + ex.ToString(), "Login", new { Area = "" });
            }
        }
        [HttpGet]
        public JsonResult GetAllCensoMaderable()
        {
            int i = 1;
            List<Ent_POA> list = (List<Ent_POA>)TempData["listMadeCENSO"];
            list = list ?? new List<Ent_POA>();
            var resul = from item in list
                        select new
                        {
                            NRO = i++,
                            ESPECIES = item.ESPECIES,
                            ESPECIES_ARESOLUCION = item.ESPECIES_ARESOLUCION,
                            BLOQUE = item.BLOQUE,
                            FAJA = item.FAJA,
                            CODIGO = item.CODIGO,
                            VOLUMEN = item.VOLUMEN,
                            DAP = item.DAP,
                            AC = item.AC,
                            DMC = item.DMC,
                            ZONA = item.ZONA,
                            COORDENADA_ESTE = item.COORDENADA_ESTE,
                            COORDENADA_NORTE = item.COORDENADA_NORTE,
                            CONDICION = item.CONDICION,
                            ESTADO = item.ESTADO,
                            PCA = item.PCA,
                            OBSERVACION = item.OBSERVACION,
                            COD_ESPECIES = item.COD_ESPECIES,
                            COD_ESPECIES_ARESOLUCION = item.COD_ESPECIES_ARESOLUCION,
                            COD_ECONDICION = item.COD_ECONDICION,
                            COD_EESTADO = item.COD_EESTADO,
                            RegEstado = item.RegEstado,
                            COD_SECUENCIAL = item.COD_SECUENCIAL
                        };
            var jsonResult = Json(new { data = resul }, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;

        }
        [HttpGet]
        public JsonResult GetAllCensoNoMaderable()
        {

            int i = 1;
            List<Ent_POA> list = (List<Ent_POA>)TempData["listNoMadeCENSO"];
            list = list ?? new List<Ent_POA>();
            var resul = from item in list
                        select new
                        {
                            NRO = i++,
                            ESPECIES = item.ESPECIES,
                            ESPECIES_ARESOLUCION = item.ESPECIES_ARESOLUCION,
                            NUM_ESTRADA = item.NUM_ESTRADA,
                            CODIGO = item.CODIGO,
                            DIAMETRO = item.DIAMETRO,
                            ALTURA = item.ALTURA,
                            PRODUCCION_LATAS = item.PRODUCCION_LATAS,
                            ZONA = item.ZONA,
                            COORDENADA_ESTE = item.COORDENADA_ESTE,
                            COORDENADA_NORTE = item.COORDENADA_NORTE,
                            CONDICION = item.CONDICION,
                            OBSERVACION = item.OBSERVACION,
                            COD_ESPECIES = item.COD_ESPECIES,
                            COD_ESPECIES_ARESOLUCION = item.COD_ESPECIES_ARESOLUCION,
                            COD_ECONDICION = item.COD_ECONDICION,
                            RegEstado = item.RegEstado,
                            COD_SECUENCIAL = item.COD_SECUENCIAL

                        };
            var jsonResult = Json(new { data = resul }, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;

        }

        [HttpPost]
        public JsonResult ImportarDataExcel()
        {
            bool success = true;
            object retorna = new object();
            string hdfItemEstadoOrigen = "";
            string hdfItemIndicador = "";
            string hdfItemCod_MTipo = "";

            string msj = "";
            try
            {
                if (Request != null)
                {
                    HttpPostedFileBase file = Request.Files[0];
                    if (file.ContentType == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
                    {
                        if ((file != null) && (file.ContentLength > 0) && !string.IsNullOrEmpty(file.FileName))
                        {

                            //string fileName = file.FileName;
                            //string fileContentType = file.ContentType;
                            //  byte[] fileBytes = new byte[file.ContentLength];
                            // var data = file.InputStream.Read(fileBytes, 0, Convert.ToInt32(file.ContentLength));
                            using (var package = new ExcelPackage(file.InputStream))
                            {
                                var currentSheet = package.Workbook.Worksheets;
                                var workSheet = currentSheet.First();
                                var noOfCol = workSheet.Dimension.End.Column;
                                var noOfRow = workSheet.Dimension.End.Row;

                                //Aqui es la logica

                                //Recorriendo Datos
                                CEntidad oCampos;
                                //ListBusqueda<CEntidad> oListBus;     
                                string hdfItemExcelImportar = Request["TVentana"];
                                List<CEntidad> ListPOAItemsDetalle = new List<CEntidad>();

                                switch (hdfItemExcelImportar)
                                {
                                    #region CMADE
                                    case "CMADE":
                                        for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                                        {
                                            oCampos = new CEntidad();
                                            oCampos.COD_SECUENCIAL = 0;
                                            oCampos.COD_ESPECIES = "";
                                            oCampos.BLOQUE = workSheet.Cells[rowIterator, 5].Value == null ? "" : workSheet.Cells[rowIterator, 5].Value.ToString().Trim();
                                            oCampos.FAJA = workSheet.Cells[rowIterator, 6].Value == null ? "" : workSheet.Cells[rowIterator, 6].Value.ToString().Trim();
                                            oCampos.CODIGO = workSheet.Cells[rowIterator, 7].Value == null ? "" : workSheet.Cells[rowIterator, 7].Value.ToString().Trim();
                                            oCampos.VOLUMEN = workSheet.Cells[rowIterator, 8].Value == null ? 0 : Decimal.Parse(workSheet.Cells[rowIterator, 8].Value.ToString().Trim());
                                            oCampos.DAP = workSheet.Cells[rowIterator, 9].Value == null ? 0 : Decimal.Parse(workSheet.Cells[rowIterator, 9].Value.ToString().Trim());
                                            oCampos.AC = workSheet.Cells[rowIterator, 10].Value == null ? 0 : Decimal.Parse(workSheet.Cells[rowIterator, 10].Value.ToString().Trim());
                                            oCampos.DMC = workSheet.Cells[rowIterator, 11].Value == null ? 0 : Int32.Parse(workSheet.Cells[rowIterator, 11].Value.ToString().Trim());
                                            oCampos.COD_ECONDICION = "";
                                            oCampos.COD_EESTADO = "";
                                            oCampos.ZONA = workSheet.Cells[rowIterator, 14].Value == null ? "" : workSheet.Cells[rowIterator, 14].Value.ToString().Trim();
                                            if (oCampos.ZONA == "17" || oCampos.ZONA == "18" || oCampos.ZONA == "19")
                                                oCampos.ZONA = oCampos.ZONA + "S";
                                            oCampos.COORDENADA_ESTE = workSheet.Cells[rowIterator, 15].Value == null ? 0 : Int32.Parse(workSheet.Cells[rowIterator, 15].Value.ToString().Trim());
                                            oCampos.COORDENADA_NORTE = workSheet.Cells[rowIterator, 16].Value == null ? 0 : Int32.Parse(workSheet.Cells[rowIterator, 16].Value.ToString().Trim());
                                            oCampos.OBSERVACION = workSheet.Cells[rowIterator, 18].Value == null ? "" : workSheet.Cells[rowIterator, 18].Value.ToString().Trim();
                                            oCampos.CONDICION = workSheet.Cells[rowIterator, 12].Value == null ? "" : workSheet.Cells[rowIterator, 12].Value.ToString().Trim();
                                            oCampos.ESTADO = workSheet.Cells[rowIterator, 13].Value == null ? "" : workSheet.Cells[rowIterator, 13].Value.ToString().Trim();
                                            oCampos.ESPECIES = String.Format("{0} | {1}", workSheet.Cells[rowIterator, 1].Value == null ? "" : workSheet.Cells[rowIterator, 1].Value.ToString().Trim(), workSheet.Cells[rowIterator, 2].Value == null ? "" : workSheet.Cells[rowIterator, 2].Value.ToString().Trim());
                                            oCampos.COD_ESPECIES_ARESOLUCION = "";
                                            oCampos.ESPECIES_ARESOLUCION = String.Format("{0} | {1}", workSheet.Cells[rowIterator, 3].Value == null ? "" : workSheet.Cells[rowIterator, 3].Value.ToString().Trim(), workSheet.Cells[rowIterator, 4].Value == null ? "" : workSheet.Cells[rowIterator, 4].Value.ToString().Trim());
                                            oCampos.RegEstado = 1;
                                            oCampos.PCA = workSheet.Cells[rowIterator, 17].Value == null ? "" : workSheet.Cells[rowIterator, 17].Value.ToString().Trim();
                                            ListPOAItemsDetalle.Add(oCampos);
                                        }

                                        break;
                                    #endregion
                                    #region CNOMADE
                                    case "CNOMADE":
                                        for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                                        {
                                            oCampos = new CEntidad();
                                            oCampos.COD_SECUENCIAL = 0;
                                            oCampos.COD_ESPECIES = "";
                                            oCampos.NUM_ESTRADA = workSheet.Cells[rowIterator, 5].Value == null ? "" : workSheet.Cells[rowIterator, 5].Value.ToString().Trim();
                                            oCampos.CODIGO = workSheet.Cells[rowIterator, 6].Value == null ? "" : workSheet.Cells[rowIterator, 6].Value.ToString().Trim();
                                            oCampos.DIAMETRO = workSheet.Cells[rowIterator, 7].Value == null ? 0 : Decimal.Parse(workSheet.Cells[rowIterator, 7].Value.ToString().Trim());
                                            oCampos.ALTURA = workSheet.Cells[rowIterator, 8].Value == null ? 0 : Decimal.Parse(workSheet.Cells[rowIterator, 8].Value.ToString().Trim());
                                            oCampos.PRODUCCION_LATAS = workSheet.Cells[rowIterator, 9].Value == null ? 0 : Decimal.Parse(workSheet.Cells[rowIterator, 9].Value.ToString().Trim());
                                            oCampos.COD_ECONDICION = "";
                                            oCampos.ZONA = workSheet.Cells[rowIterator, 11].Value == null ? "" : workSheet.Cells[rowIterator, 11].Value.ToString().Trim();
                                            if (oCampos.ZONA == "17" || oCampos.ZONA == "18" || oCampos.ZONA == "19")
                                                oCampos.ZONA = oCampos.ZONA + "S";

                                            oCampos.COORDENADA_ESTE = workSheet.Cells[rowIterator, 12].Value == null ? 0 : Int32.Parse(workSheet.Cells[rowIterator, 12].Value.ToString().Trim());
                                            oCampos.COORDENADA_NORTE = workSheet.Cells[rowIterator, 13].Value == null ? 0 : Int32.Parse(workSheet.Cells[rowIterator, 13].Value.ToString().Trim());
                                            oCampos.OBSERVACION = workSheet.Cells[rowIterator, 14].Value == null ? "" : workSheet.Cells[rowIterator, 14].Value.ToString().Trim();
                                            oCampos.CONDICION = workSheet.Cells[rowIterator, 10].Value == null ? "" : workSheet.Cells[rowIterator, 10].Value.ToString().Trim();
                                            oCampos.ESPECIES = String.Format("{0} | {1}", (workSheet.Cells[rowIterator, 1].Value == null ? "" : workSheet.Cells[rowIterator, 1].Value.ToString().Trim()), (workSheet.Cells[rowIterator, 2].Value == null ? "" : workSheet.Cells[rowIterator, 2].Value.ToString().Trim()));
                                            oCampos.COD_ESPECIES_ARESOLUCION = "";
                                            oCampos.ESPECIES_ARESOLUCION = String.Format("{0} | {1}", workSheet.Cells[rowIterator, 3].Value == null ? "" : workSheet.Cells[rowIterator, 3].Value.ToString().Trim(), workSheet.Cells[rowIterator, 4].Value == null ? "" : workSheet.Cells[rowIterator, 4].Value.ToString().Trim());
                                            oCampos.RegEstado = 1;
                                            ListPOAItemsDetalle.Add(oCampos);
                                        }

                                        break;
                                    #endregion
                                    #region BEMADE
                                    case "BEMADE":
                                        for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                                        {
                                            oCampos = new CEntidad();
                                            oCampos.COD_SECUENCIAL = 0;
                                            oCampos.COD_ESPECIES = "";
                                            oCampos.DMC = workSheet.Cells[rowIterator, 5].Value == null ? 0 : Int32.Parse(workSheet.Cells[rowIterator, 5].Value.ToString().Trim());
                                            oCampos.TOTAL_ARBOLES = workSheet.Cells[rowIterator, 6].Value == null ? 0 : Int32.Parse(workSheet.Cells[rowIterator, 6].Value.ToString().Trim());
                                            oCampos.VOLUMEN_AUTORIZADO = workSheet.Cells[rowIterator, 7].Value == null ? 0 : Decimal.Parse(workSheet.Cells[rowIterator, 7].Value.ToString().Trim());
                                            oCampos.VOLUMEN_MOVILIZADO = workSheet.Cells[rowIterator, 8].Value == null ? 0 : Decimal.Parse(workSheet.Cells[rowIterator, 8].Value.ToString().Trim());
                                            oCampos.SALDO = workSheet.Cells[rowIterator, 9].Value == null ? 0 : Decimal.Parse(workSheet.Cells[rowIterator, 9].Value.ToString().Trim());
                                            oCampos.TIPOMADERABLE = workSheet.Cells[rowIterator, 10].Value == null ? "" : workSheet.Cells[rowIterator, 10].Value.ToString().Trim();
                                            oCampos.OBSERVACION = workSheet.Cells[rowIterator, 12].Value == null ? "" : workSheet.Cells[rowIterator, 12].Value.ToString().Trim();
                                            oCampos.ESPECIES = String.Format("{0} | {1}", (workSheet.Cells[rowIterator, 1].Value == null ? "" : workSheet.Cells[rowIterator, 1].Value.ToString().Trim()), (workSheet.Cells[rowIterator, 2].Value == null ? "" : workSheet.Cells[rowIterator, 2].Value.ToString().Trim()));
                                            oCampos.COD_ESPECIES_SERFOR = "";
                                            oCampos.ESPECIES_SERFOR = String.Format("{0} | {1}", workSheet.Cells[rowIterator, 3].Value == null ? "" : workSheet.Cells[rowIterator, 3].Value.ToString().Trim(), workSheet.Cells[rowIterator, 4].Value == null ? "" : workSheet.Cells[rowIterator, 4].Value.ToString().Trim());
                                            oCampos.RegEstado = 1;
                                            oCampos.PCA = workSheet.Cells[rowIterator, 11].Value == null ? "" : workSheet.Cells[rowIterator, 11].Value.ToString().Trim();

                                            ListPOAItemsDetalle.Add(oCampos);
                                        }

                                        break;
                                    #endregion

                                    #region BENOMADE
                                    case "BENOMADE":
                                        hdfItemCod_MTipo = Request["hdfItemCod_MTipo"];

                                        if (hdfItemCod_MTipo == "0000021")
                                        {
                                            for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                                            {
                                                oCampos = new CEntidad();
                                                oCampos.COD_SECUENCIAL = 0;
                                                oCampos.COD_ESPECIES = "";
                                                oCampos.AUTORIZADO = workSheet.Cells[rowIterator, 5].Value == null ? 0 : Decimal.Parse(workSheet.Cells[rowIterator, 5].Value.ToString().Trim());
                                                oCampos.EXTRAIDO = workSheet.Cells[rowIterator, 6].Value == null ? 0 : Decimal.Parse(workSheet.Cells[rowIterator, 6].Value.ToString().Trim());
                                                oCampos.SALDO = workSheet.Cells[rowIterator, 7].Value == null ? 0 : Decimal.Parse(workSheet.Cells[rowIterator, 7].Value.ToString().Trim());
                                                oCampos.UNIDAD_MEDIDA = workSheet.Cells[rowIterator, 8].Value == null ? "" : workSheet.Cells[rowIterator, 8].Value.ToString().Trim();
                                                oCampos.OBSERVACION = workSheet.Cells[rowIterator, 9].Value == null ? "" : workSheet.Cells[rowIterator, 9].Value.ToString().Trim();
                                                oCampos.ESPECIES = String.Format("{0} | {1}", workSheet.Cells[rowIterator, 1].Value == null ? "" : workSheet.Cells[rowIterator, 1].Value.ToString().Trim(), workSheet.Cells[rowIterator, 2].Value == null ? "" : workSheet.Cells[rowIterator, 2].Value.ToString().Trim());
                                                oCampos.COD_ESPECIES_SERFOR = "";
                                                oCampos.ESPECIES_SERFOR = String.Format("{0} | {1}", workSheet.Cells[rowIterator, 3].Value == null ? "" : workSheet.Cells[rowIterator, 3].Value.ToString().Trim(), workSheet.Cells[rowIterator, 4].Value == null ? "" : workSheet.Cells[rowIterator, 4].Value.ToString().Trim());
                                                oCampos.RegEstado = 1;
                                                ListPOAItemsDetalle.Add(oCampos);
                                            }



                                        }
                                        else if (hdfItemCod_MTipo == "0000020")
                                        {
                                            for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                                            {
                                                oCampos = new CEntidad();
                                                oCampos.COD_SECUENCIAL = 0;
                                                oCampos.COD_ESPECIES = "";
                                                oCampos.FECHA1 = workSheet.Cells[rowIterator, 5].Value == null ? "" : workSheet.Cells[rowIterator, 5].Value.ToString().Trim();
                                                oCampos.GUIA_TRANSPORTE = workSheet.Cells[rowIterator, 6].Value == null ? "" : workSheet.Cells[rowIterator, 6].Value.ToString().Trim();
                                                oCampos.FECHA2 = workSheet.Cells[rowIterator, 7].Value == null ? "" : workSheet.Cells[rowIterator, 7].Value.ToString().Trim();
                                                oCampos.RECIBO = workSheet.Cells[rowIterator, 8].Value == null ? "" : workSheet.Cells[rowIterator, 8].Value.ToString().Trim();
                                                oCampos.SALDO = workSheet.Cells[rowIterator, 9].Value == null ? 0 : Decimal.Parse(workSheet.Cells[rowIterator, 9].Value.ToString().Trim());
                                                oCampos.CANTIDAD = workSheet.Cells[rowIterator, 10].Value == null ? 0 : Int32.Parse(workSheet.Cells[rowIterator, 10].Value.ToString().Trim());
                                                oCampos.OBSERVACION = workSheet.Cells[rowIterator, 11].Value == null ? "" : workSheet.Cells[rowIterator, 11].Value.ToString().Trim();
                                                oCampos.ESPECIES = String.Format("{0} | {1}", workSheet.Cells[rowIterator, 1].Value == null ? "" : workSheet.Cells[rowIterator, 1].Value.ToString().Trim(), workSheet.Cells[rowIterator, 2].Value == null ? "" : workSheet.Cells[rowIterator, 2].Value.ToString().Trim());
                                                oCampos.COD_ESPECIES_SERFOR = "";
                                                oCampos.ESPECIES_SERFOR = String.Format("{0} | {1}", workSheet.Cells[rowIterator, 3].Value == null ? "" : workSheet.Cells[rowIterator, 3].Value.ToString().Trim(), workSheet.Cells[rowIterator, 4].Value == null ? "" : workSheet.Cells[rowIterator, 4].Value.ToString().Trim());
                                                oCampos.RegEstado = 1;
                                                ListPOAItemsDetalle.Add(oCampos);
                                            }
                                        }
                                        else
                                        {
                                            for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                                            {
                                                oCampos = new CEntidad();
                                                oCampos.COD_SECUENCIAL = 0;
                                                oCampos.COD_ESPECIES = "";
                                                oCampos.KILOGRAMO_AUTORIZADO = workSheet.Cells[rowIterator, 5].Value == null ? 0 : Decimal.Parse(workSheet.Cells[rowIterator, 5].Value.ToString().Trim());
                                                oCampos.KILOGRAMO_MOVILIZADO = workSheet.Cells[rowIterator, 6].Value == null ? 0 : Decimal.Parse(workSheet.Cells[rowIterator, 6].Value.ToString().Trim());
                                                oCampos.SALDO = workSheet.Cells[rowIterator, 7].Value == null ? 0 : Decimal.Parse(workSheet.Cells[rowIterator, 7].Value.ToString().Trim());
                                                oCampos.OBSERVACION = workSheet.Cells[rowIterator, 8].Value == null ? "" : workSheet.Cells[rowIterator, 8].Value.ToString().Trim();
                                                oCampos.ESPECIES = String.Format("{0} | {1}", workSheet.Cells[rowIterator, 1].Value == null ? "" : workSheet.Cells[rowIterator, 1].Value.ToString().Trim(), workSheet.Cells[rowIterator, 2].Value == null ? "" : workSheet.Cells[rowIterator, 2].Value.ToString().Trim());
                                                oCampos.COD_ESPECIES_SERFOR = "";
                                                oCampos.ESPECIES_SERFOR = String.Format("{0} | {1}", workSheet.Cells[rowIterator, 3].Value == null ? "" : workSheet.Cells[rowIterator, 3].Value.ToString().Trim(), workSheet.Cells[rowIterator, 4].Value == null ? "" : workSheet.Cells[rowIterator, 4].Value.ToString().Trim());
                                                oCampos.RegEstado = 1;
                                                ListPOAItemsDetalle.Add(oCampos);
                                            }
                                        }

                                        break;

                                    #endregion
                                    #region BEINSITU
                                    case "BEINSITU":
                                        for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                                        {
                                            oCampos = new CEntidad();
                                            oCampos.COD_SECUENCIAL = 0;
                                            oCampos.COD_ESPECIES = "";
                                            oCampos.CANTIDAD_AUTORIZADO = workSheet.Cells[rowIterator, 5].Value == null ? 0 : Decimal.Parse(workSheet.Cells[rowIterator, 5].Value.ToString().Trim());
                                            oCampos.CANTIDAD_MOVILIZADO = workSheet.Cells[rowIterator, 6].Value == null ? 0 : Decimal.Parse(workSheet.Cells[rowIterator, 6].Value.ToString().Trim());
                                            oCampos.SALDO = workSheet.Cells[rowIterator, 7].Value == null ? 0 : Decimal.Parse(workSheet.Cells[rowIterator, 7].Value.ToString().Trim());
                                            oCampos.OBSERVACION = workSheet.Cells[rowIterator, 8].Value == null ? "" : workSheet.Cells[rowIterator, 8].Value.ToString().Trim();
                                            oCampos.ESPECIES = String.Format("{0} | {1}", workSheet.Cells[rowIterator, 1].Value == null ? "" : workSheet.Cells[rowIterator, 1].Value.ToString().Trim(), workSheet.Cells[rowIterator, 2].Value == null ? "" : workSheet.Cells[rowIterator, 2].Value.ToString().Trim());
                                            oCampos.COD_ESPECIES_SERFOR = "";
                                            oCampos.ESPECIES_SERFOR = String.Format("{0} | {1}", workSheet.Cells[rowIterator, 3].Value == null ? "" : workSheet.Cells[rowIterator, 3].Value.ToString().Trim(), workSheet.Cells[rowIterator, 4].Value == null ? "" : workSheet.Cells[rowIterator, 4].Value.ToString().Trim());
                                            oCampos.RegEstado = 1;
                                            ListPOAItemsDetalle.Add(oCampos);
                                        }

                                        break;
                                    #endregion
                                    #region VERTICE
                                    case "VERTICE":
                                        for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                                        {
                                            //Verificando Existencia
                                            oCampos = new CEntidad();
                                            oCampos.VERTICE = workSheet.Cells[rowIterator, 1].Value == null ? "" : workSheet.Cells[rowIterator, 1].Value.ToString().Trim();
                                            string temp = workSheet.Cells[rowIterator, 2].Value == null ? "" : workSheet.Cells[rowIterator, 2].Value.ToString().Trim();

                                            if (temp != "17" && temp != "18" && temp != "19"
                                            && temp != "17S" && temp != "18S" && temp != "19S")
                                            {
                                                oCampos.ZONA = "";
                                            }
                                            else
                                            {
                                                if (temp == "17" || temp == "17S") { oCampos.ZONA = "17S"; }
                                                else if (temp == "18" || temp == "18S") { oCampos.ZONA = "18S"; }
                                                else if (temp == "19" || temp == "19S") { oCampos.ZONA = "19S"; }
                                                else { oCampos.ZONA = temp; }
                                            }
                                            oCampos.COORDENADA_ESTE = workSheet.Cells[rowIterator, 3].Value == null ? 0 : Int32.Parse(workSheet.Cells[rowIterator, 3].Value.ToString().Trim());
                                            oCampos.COORDENADA_NORTE = workSheet.Cells[rowIterator, 4].Value == null ? 0 : Int32.Parse(workSheet.Cells[rowIterator, 4].Value.ToString().Trim());
                                            oCampos.OBSERVACION = workSheet.Cells[rowIterator, 6].Value == null ? "" : workSheet.Cells[rowIterator, 6].Value.ToString().Trim();
                                            oCampos.PCA = workSheet.Cells[rowIterator, 5].Value == null ? "" : workSheet.Cells[rowIterator, 5].Value.ToString().Trim();
                                            oCampos.COD_SECUENCIAL = 0;
                                            oCampos.RegEstado = 1;
                                            ListPOAItemsDetalle.Add(oCampos);
                                        }


                                        break;
                                    #endregion
                                    #region RAPROBMADE
                                    case "RAPROBMADE":
                                        Log_PLAN_MANEJO objLog_RAPoa;
                                        bool isAdd_RAPoa;
                                        string codEspecie_RAPoa;
                                        string codEspecieSerfor_RAPoa;

                                        hdfItemCod_MTipo = Request["hdfItemCod_MTipo"];

                                        if (hdfItemCod_MTipo == "0000021")
                                        {
                                            for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                                            {
                                                oCampos = new CEntidad();
                                                objLog_RAPoa = new Log_PLAN_MANEJO();
                                                isAdd_RAPoa = true;

                                                codEspecie_RAPoa = objLog_RAPoa.GetCodEspecie(
                                                    workSheet.Cells[rowIterator, 1].Value == null ? "" : workSheet.Cells[rowIterator, 1].Value.ToString().Trim(),
                                                    workSheet.Cells[rowIterator, 2].Value == null ? "" : workSheet.Cells[rowIterator, 2].Value.ToString().Trim()
                                                );

                                                if (codEspecie_RAPoa != null && codEspecie_RAPoa.Trim() != "")
                                                {
                                                    oCampos.COD_SECUENCIAL = 0;
                                                    oCampos.COD_ESPECIES = codEspecie_RAPoa;
                                                    oCampos.ESPECIES = String.Format("{0} | {1}", workSheet.Cells[rowIterator, 1].Value == null ? "" : workSheet.Cells[rowIterator, 1].Value.ToString().Trim(), workSheet.Cells[rowIterator, 2].Value == null ? "" : workSheet.Cells[rowIterator, 2].Value.ToString().Trim());
                                                    oCampos.ABUNDANCIA = workSheet.Cells[rowIterator, 5].Value == null ? 0 : Decimal.Parse(workSheet.Cells[rowIterator, 5].Value.ToString().Trim());
                                                    oCampos.NUMINDIVIDUOS = workSheet.Cells[rowIterator, 6].Value == null ? 0 : Decimal.Parse(workSheet.Cells[rowIterator, 6].Value.ToString().Trim());
                                                    oCampos.PESO = workSheet.Cells[rowIterator, 7].Value == null ? 0 : Decimal.Parse(workSheet.Cells[rowIterator, 7].Value.ToString().Trim());
                                                    oCampos.RENDIMIENTO = workSheet.Cells[rowIterator, 8].Value == null ? 0 : Decimal.Parse(workSheet.Cells[rowIterator, 8].Value.ToString().Trim());
                                                    oCampos.UNIDAD_MEDIDA = workSheet.Cells[rowIterator, 9].Value == null ? "" : workSheet.Cells[rowIterator, 9].Value.ToString().Trim();
                                                    oCampos.TIPOMADERABLE = workSheet.Cells[rowIterator, 10].Value == null ? "" : workSheet.Cells[rowIterator, 10].Value.ToString().Trim();
                                                    oCampos.PCA = workSheet.Cells[rowIterator, 11].Value == null ? "" : workSheet.Cells[rowIterator, 11].Value.ToString().Trim();
                                                    oCampos.OBSERVACION = workSheet.Cells[rowIterator, 12].Value == null ? "" : workSheet.Cells[rowIterator, 12].Value.ToString().Trim();
                                                    oCampos.RegEstado = 1;

                                                    if (!(workSheet.Cells[rowIterator, 3].Value == null ? "" : workSheet.Cells[rowIterator, 3].Value.ToString().Trim()).Equals(""))
                                                    {
                                                        codEspecieSerfor_RAPoa = objLog_RAPoa.GetCodEspecie(
                                                            workSheet.Cells[rowIterator, 3].Value == null ? "" : workSheet.Cells[rowIterator, 3].Value.ToString().Trim(),
                                                            workSheet.Cells[rowIterator, 4].Value == null ? "" : workSheet.Cells[rowIterator, 4].Value.ToString().Trim()
                                                        );

                                                        if (codEspecieSerfor_RAPoa != null && codEspecieSerfor_RAPoa != "")
                                                        {
                                                            oCampos.COD_ESPECIES_SERFOR = codEspecieSerfor_RAPoa;
                                                            oCampos.ESPECIES_SERFOR = String.Format("{0} | {1}", workSheet.Cells[rowIterator, 3].Value == null ? "" : workSheet.Cells[rowIterator, 3].Value.ToString().Trim(), workSheet.Cells[rowIterator, 4].Value == null ? "" : workSheet.Cells[rowIterator, 4].Value.ToString().Trim());
                                                        }
                                                        else isAdd_RAPoa = false;
                                                    }

                                                    if (isAdd_RAPoa) ListPOAItemsDetalle.Add(oCampos);
                                                }
                                            }
                                        }
                                        else if (hdfItemCod_MTipo == "0000020")
                                        {
                                            for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                                            {
                                                oCampos = new CEntidad();
                                                objLog_RAPoa = new Log_PLAN_MANEJO();
                                                isAdd_RAPoa = true;

                                                codEspecie_RAPoa = objLog_RAPoa.GetCodEspecie(
                                                    workSheet.Cells[rowIterator, 1].Value == null ? "" : workSheet.Cells[rowIterator, 1].Value.ToString().Trim(),
                                                    workSheet.Cells[rowIterator, 2].Value == null ? "" : workSheet.Cells[rowIterator, 2].Value.ToString().Trim()
                                                );

                                                if (codEspecie_RAPoa != null && codEspecie_RAPoa.Trim() != "")
                                                {
                                                    oCampos.COD_SECUENCIAL = 0;
                                                    oCampos.COD_ESPECIES = codEspecie_RAPoa;
                                                    oCampos.ESPECIES = String.Format("{0} | {1}", workSheet.Cells[rowIterator, 1].Value == null ? "" : workSheet.Cells[rowIterator, 1].Value.ToString().Trim(), workSheet.Cells[rowIterator, 2].Value == null ? "" : workSheet.Cells[rowIterator, 2].Value.ToString().Trim());
                                                    oCampos.SuperficieHa = workSheet.Cells[rowIterator, 5].Value == null ? 0 : Decimal.Parse(workSheet.Cells[rowIterator, 5].Value.ToString().Trim());
                                                    oCampos.CANTIDAD = workSheet.Cells[rowIterator, 6].Value == null ? 0 : Int32.Parse(workSheet.Cells[rowIterator, 6].Value.ToString().Trim());
                                                    oCampos.TIPOMADERABLE = workSheet.Cells[rowIterator, 7].Value == null ? "" : workSheet.Cells[rowIterator, 7].Value.ToString().Trim();
                                                    oCampos.PCA = workSheet.Cells[rowIterator, 8].Value == null ? "" : workSheet.Cells[rowIterator, 8].Value.ToString().Trim();
                                                    oCampos.OBSERVACION = workSheet.Cells[rowIterator, 9].Value == null ? "" : workSheet.Cells[rowIterator, 9].Value.ToString().Trim();
                                                    oCampos.RegEstado = 1;

                                                    if (!(workSheet.Cells[rowIterator, 3].Value == null ? "" : workSheet.Cells[rowIterator, 3].Value.ToString().Trim()).Equals(""))
                                                    {
                                                        codEspecieSerfor_RAPoa = objLog_RAPoa.GetCodEspecie(
                                                            workSheet.Cells[rowIterator, 3].Value == null ? "" : workSheet.Cells[rowIterator, 3].Value.ToString().Trim(),
                                                            workSheet.Cells[rowIterator, 4].Value == null ? "" : workSheet.Cells[rowIterator, 4].Value.ToString().Trim()
                                                        );

                                                        if (codEspecieSerfor_RAPoa != null && codEspecieSerfor_RAPoa != "")
                                                        {
                                                            oCampos.COD_ESPECIES_SERFOR = codEspecieSerfor_RAPoa;
                                                            oCampos.ESPECIES_SERFOR = String.Format("{0} | {1}", workSheet.Cells[rowIterator, 3].Value == null ? "" : workSheet.Cells[rowIterator, 3].Value.ToString().Trim(), workSheet.Cells[rowIterator, 4].Value == null ? "" : workSheet.Cells[rowIterator, 4].Value.ToString().Trim());
                                                        }
                                                        else isAdd_RAPoa = false;
                                                    }

                                                    if (isAdd_RAPoa) ListPOAItemsDetalle.Add(oCampos);
                                                }
                                            }
                                        }
                                        else
                                        {
                                            for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                                            {
                                                oCampos = new CEntidad();
                                                objLog_RAPoa = new Log_PLAN_MANEJO();
                                                isAdd_RAPoa = true;

                                                codEspecie_RAPoa = objLog_RAPoa.GetCodEspecie(
                                                    workSheet.Cells[rowIterator, 1].Value == null ? "" : workSheet.Cells[rowIterator, 1].Value.ToString().Trim(),
                                                    workSheet.Cells[rowIterator, 2].Value == null ? "" : workSheet.Cells[rowIterator, 2].Value.ToString().Trim()
                                                );

                                                if (codEspecie_RAPoa != null && codEspecie_RAPoa.Trim() != "")
                                                {
                                                    oCampos.COD_SECUENCIAL = 0;
                                                    oCampos.COD_ESPECIES = codEspecie_RAPoa;
                                                    oCampos.ESPECIES = String.Format("{0} | {1}", workSheet.Cells[rowIterator, 1].Value == null ? "" : workSheet.Cells[rowIterator, 1].Value.ToString().Trim(), workSheet.Cells[rowIterator, 2].Value == null ? "" : workSheet.Cells[rowIterator, 2].Value.ToString().Trim());
                                                    oCampos.NUM_ARBOLES = workSheet.Cells[rowIterator, 5].Value == null ? 0 : Int32.Parse(workSheet.Cells[rowIterator, 5].Value.ToString().Trim());
                                                    oCampos.VOLUMEN_KILOGRAMOS = workSheet.Cells[rowIterator, 6].Value == null ? 0 : Decimal.Parse(workSheet.Cells[rowIterator, 6].Value.ToString().Trim());
                                                    oCampos.TIPOMADERABLE = workSheet.Cells[rowIterator, 7].Value == null ? "" : workSheet.Cells[rowIterator, 7].Value.ToString().Trim();
                                                    oCampos.PCA = workSheet.Cells[rowIterator, 8].Value == null ? "" : workSheet.Cells[rowIterator, 8].Value.ToString().Trim();
                                                    oCampos.OBSERVACION = workSheet.Cells[rowIterator, 9].Value == null ? "" : workSheet.Cells[rowIterator, 9].Value.ToString().Trim();
                                                    oCampos.RegEstado = 1;

                                                    if (oCampos.TIPOMADERABLE.Equals("CARBON") || oCampos.TIPOMADERABLE.Equals("NO MADERABLES")) oCampos.UNIDAD_MEDIDA = "KG";
                                                    else if (oCampos.TIPOMADERABLE.Equals("MADERABLES")) oCampos.UNIDAD_MEDIDA = "M3";

                                                    if (!(workSheet.Cells[rowIterator, 3].Value == null ? "" : workSheet.Cells[rowIterator, 3].Value.ToString().Trim()).Equals(""))
                                                    {
                                                        codEspecieSerfor_RAPoa = objLog_RAPoa.GetCodEspecie(
                                                            workSheet.Cells[rowIterator, 3].Value == null ? "" : workSheet.Cells[rowIterator, 3].Value.ToString().Trim(),
                                                            workSheet.Cells[rowIterator, 4].Value == null ? "" : workSheet.Cells[rowIterator, 4].Value.ToString().Trim()
                                                        );

                                                        if (codEspecieSerfor_RAPoa != null && codEspecieSerfor_RAPoa != "")
                                                        {
                                                            oCampos.COD_ESPECIES_SERFOR = codEspecieSerfor_RAPoa;
                                                            oCampos.ESPECIES_SERFOR = String.Format("{0} | {1}", workSheet.Cells[rowIterator, 3].Value == null ? "" : workSheet.Cells[rowIterator, 3].Value.ToString().Trim(), workSheet.Cells[rowIterator, 4].Value == null ? "" : workSheet.Cells[rowIterator, 4].Value.ToString().Trim());
                                                        }
                                                        else isAdd_RAPoa = false;
                                                    }

                                                    if (isAdd_RAPoa) ListPOAItemsDetalle.Add(oCampos);
                                                }
                                            }
                                        }

                                        break;
                                    #endregion
                                    //#region RREFORMADE
                                    //case "RREFORMADE":
                                    //    foreach (DataRow Fila in exiItemDatos.Datos.Rows)
                                    //    {
                                    //        oCampos = new CEntidad();
                                    //        oCampos.COD_SECUENCIAL = 0;
                                    //        oCampos.COD_ESPECIES = "";
                                    //        oCampos.NUM_ARBOLES = Int32.Parse(Fila[4].ToString().Trim());
                                    //        oCampos.VOLUMEN_KILOGRAMOS = Decimal.Parse(Fila[5].ToString().Trim());
                                    //        oCampos.TIPOMADERABLE = Fila[6].ToString().Trim();
                                    //        oCampos.OBSERVACION = Fila[7].ToString().Trim();
                                    //        oCampos.ESPECIES = String.Format("{0} | {1}", Fila[0].ToString().Trim(), Fila[1].ToString().Trim());
                                    //        oCampos.COD_ESPECIES_SERFOR = "";
                                    //        oCampos.ESPECIES_SERFOR = String.Format("{0} | {1}", Fila[2].ToString().Trim(), Fila[3].ToString().Trim());
                                    //        oCampos.RegEstado = 1;
                                    //        ListPOAItemsDetalle.Add(oCampos);
                                    //    }
                                    //    HerUtil.GrillaLlenar(grvItemRRPoa, ListPOAItemsDetalle, 0);
                                    //    break;
                                    //#endregion
                                    #region RAPROBINSITU
                                    case "RAPROBINSITU":
                                        for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                                        {
                                            oCampos = new CEntidad();
                                            oCampos.COD_SECUENCIAL = 0;
                                            oCampos.COD_ESPECIES = "";
                                            oCampos.PERIODO = workSheet.Cells[rowIterator, 5].Value == null ? "" : workSheet.Cells[rowIterator, 5].Value.ToString().Trim();
                                            oCampos.CUOTA_SACA = workSheet.Cells[rowIterator, 6].Value == null ? 0 : Int32.Parse(workSheet.Cells[rowIterator, 6].Value.ToString().Trim());
                                            oCampos.METODO_CAZA = workSheet.Cells[rowIterator, 7].Value == null ? "" : workSheet.Cells[rowIterator, 7].Value.ToString().Trim();
                                            oCampos.SISTEMA_MARCAJE = workSheet.Cells[rowIterator, 8].Value == null ? "" : workSheet.Cells[rowIterator, 8].Value.ToString().Trim();
                                            oCampos.DENSIDAD = workSheet.Cells[rowIterator, 9].Value == null ? 0 : Int32.Parse(workSheet.Cells[rowIterator, 9].Value.ToString().Trim());
                                            oCampos.OBSERVACION = workSheet.Cells[rowIterator, 10].Value == null ? "" : workSheet.Cells[rowIterator, 10].Value.ToString().Trim();
                                            oCampos.ESPECIES = String.Format("{0} | {1}", workSheet.Cells[rowIterator, 1].Value == null ? "" : workSheet.Cells[rowIterator, 1].Value.ToString().Trim(), workSheet.Cells[rowIterator, 2].Value == null ? "" : workSheet.Cells[rowIterator, 2].Value.ToString().Trim());
                                            oCampos.COD_ESPECIES_SERFOR = "";
                                            oCampos.ESPECIES_SERFOR = String.Format("{0} | {1}", workSheet.Cells[rowIterator, 3].Value == null ? "" : workSheet.Cells[rowIterator, 3].Value.ToString().Trim(), workSheet.Cells[rowIterator, 4].Value == null ? "" : workSheet.Cells[rowIterator, 4].Value.ToString().Trim());
                                            oCampos.RegEstado = 1;
                                            ListPOAItemsDetalle.Add(oCampos);
                                        }

                                        break;
                                    #endregion

                                    #region BExt_MadeNoMade
                                    case "BExt_MadeNoMade":
                                        hdfItemEstadoOrigen = Request["hdfItemEstadoOrigen"];
                                        hdfItemIndicador = Request["hdfItemIndicador"];
                                        Log_PLAN_MANEJO objLog;
                                        bool isAdd;
                                        string codEspecie;
                                        string codEspecieSerfor;

                                        if (
                                            (hdfItemEstadoOrigen.Equals("PN") && hdfItemIndicador.Equals("M")) ||
                                            (hdfItemEstadoOrigen.Equals("R")) ||
                                            (hdfItemEstadoOrigen.Equals("MS")) ||
                                            (hdfItemEstadoOrigen.Equals("PC"))
                                        )
                                        {
                                            for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                                            {
                                                oCampos = new CEntidad();
                                                objLog = new Log_PLAN_MANEJO();
                                                isAdd = true;

                                                codEspecie = objLog.GetCodEspecie(
                                                    workSheet.Cells[rowIterator, 1].Value == null ? "" : workSheet.Cells[rowIterator, 1].Value.ToString().Trim(),
                                                    workSheet.Cells[rowIterator, 2].Value == null ? "" : workSheet.Cells[rowIterator, 2].Value.ToString().Trim()
                                                );

                                                if (codEspecie != null && codEspecie.Trim() != "")
                                                {
                                                    oCampos.COD_SECUENCIAL = 0;
                                                    oCampos.COD_ESPECIES = codEspecie;
                                                    oCampos.ESPECIES = String.Format("{0} | {1}", (workSheet.Cells[rowIterator, 1].Value == null ? "" : workSheet.Cells[rowIterator, 1].Value.ToString().Trim()), (workSheet.Cells[rowIterator, 2].Value == null ? "" : workSheet.Cells[rowIterator, 2].Value.ToString().Trim()));
                                                    oCampos.DMC = workSheet.Cells[rowIterator, 5].Value == null ? 0 : Int32.Parse(workSheet.Cells[rowIterator, 5].Value.ToString().Trim());
                                                    oCampos.TOTAL_ARBOLES = workSheet.Cells[rowIterator, 6].Value == null ? 0 : Int32.Parse(workSheet.Cells[rowIterator, 6].Value.ToString().Trim());
                                                    oCampos.VOLUMEN_AUTORIZADO = workSheet.Cells[rowIterator, 7].Value == null ? 0 : Decimal.Parse(workSheet.Cells[rowIterator, 7].Value.ToString().Trim());
                                                    oCampos.VOLUMEN_MOVILIZADO = workSheet.Cells[rowIterator, 8].Value == null ? 0 : Decimal.Parse(workSheet.Cells[rowIterator, 8].Value.ToString().Trim());
                                                    oCampos.SALDO = workSheet.Cells[rowIterator, 9].Value == null ? 0 : Decimal.Parse(workSheet.Cells[rowIterator, 9].Value.ToString().Trim());
                                                    oCampos.TIPOMADERABLE = workSheet.Cells[rowIterator, 10].Value == null ? "" : workSheet.Cells[rowIterator, 10].Value.ToString().Trim();
                                                    oCampos.OBSERVACION = workSheet.Cells[rowIterator, 11].Value == null ? "" : workSheet.Cells[rowIterator, 11].Value.ToString().Trim();
                                                    oCampos.RegEstado = 1;

                                                    if (oCampos.TIPOMADERABLE.Equals("MADERABLES")) oCampos.UNIDAD_MEDIDA = "M3";
                                                    else if (oCampos.TIPOMADERABLE.Equals("CARBON")) oCampos.UNIDAD_MEDIDA = "KG";

                                                    if (!(workSheet.Cells[rowIterator, 3].Value == null ? "" : workSheet.Cells[rowIterator, 3].Value.ToString().Trim()).Equals(""))
                                                    {
                                                        codEspecieSerfor = objLog.GetCodEspecie(
                                                            workSheet.Cells[rowIterator, 3].Value == null ? "" : workSheet.Cells[rowIterator, 3].Value.ToString().Trim(),
                                                            workSheet.Cells[rowIterator, 4].Value == null ? "" : workSheet.Cells[rowIterator, 4].Value.ToString().Trim()
                                                        );

                                                        if (codEspecieSerfor != null && codEspecieSerfor != "")
                                                        {
                                                            oCampos.COD_ESPECIES_SERFOR = codEspecieSerfor;
                                                            oCampos.ESPECIES_SERFOR = String.Format("{0} | {1}", workSheet.Cells[rowIterator, 3].Value == null ? "" : workSheet.Cells[rowIterator, 3].Value.ToString().Trim(), workSheet.Cells[rowIterator, 4].Value == null ? "" : workSheet.Cells[rowIterator, 4].Value.ToString().Trim());
                                                        }
                                                        else isAdd = false;
                                                    }

                                                    if (isAdd) ListPOAItemsDetalle.Add(oCampos);
                                                }
                                            }
                                        }
                                        else if (
                                            (hdfItemEstadoOrigen.Equals("PN") && hdfItemIndicador.Equals("NM")) ||
                                            (hdfItemEstadoOrigen.Equals("PCN"))
                                        )
                                        {
                                            hdfItemCod_MTipo = Request["hdfItemCod_MTipo"];

                                            if (hdfItemCod_MTipo == "0000021")
                                            {
                                                for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                                                {
                                                    oCampos = new CEntidad();
                                                    objLog = new Log_PLAN_MANEJO();
                                                    isAdd = true;

                                                    codEspecie = objLog.GetCodEspecie(
                                                        workSheet.Cells[rowIterator, 1].Value == null ? "" : workSheet.Cells[rowIterator, 1].Value.ToString().Trim(),
                                                        workSheet.Cells[rowIterator, 2].Value == null ? "" : workSheet.Cells[rowIterator, 2].Value.ToString().Trim()
                                                    );

                                                    if (codEspecie != null && codEspecie.Trim() != "")
                                                    {
                                                        oCampos.COD_SECUENCIAL = 0;
                                                        oCampos.COD_ESPECIES = codEspecie;
                                                        oCampos.ESPECIES = String.Format("{0} | {1}", workSheet.Cells[rowIterator, 1].Value == null ? "" : workSheet.Cells[rowIterator, 1].Value.ToString().Trim(), workSheet.Cells[rowIterator, 2].Value == null ? "" : workSheet.Cells[rowIterator, 2].Value.ToString().Trim());
                                                        oCampos.AUTORIZADO = workSheet.Cells[rowIterator, 5].Value == null ? 0 : Decimal.Parse(workSheet.Cells[rowIterator, 5].Value.ToString().Trim());
                                                        oCampos.EXTRAIDO = workSheet.Cells[rowIterator, 6].Value == null ? 0 : Decimal.Parse(workSheet.Cells[rowIterator, 6].Value.ToString().Trim());
                                                        oCampos.SALDO = workSheet.Cells[rowIterator, 7].Value == null ? 0 : Decimal.Parse(workSheet.Cells[rowIterator, 7].Value.ToString().Trim());
                                                        oCampos.TIPOMADERABLE = "NO MADERABLES";
                                                        oCampos.UNIDAD_MEDIDA = "KG";
                                                        oCampos.OBSERVACION = workSheet.Cells[rowIterator, 8].Value == null ? "" : workSheet.Cells[rowIterator, 8].Value.ToString().Trim();
                                                        oCampos.RegEstado = 1;

                                                        if (!(workSheet.Cells[rowIterator, 3].Value == null ? "" : workSheet.Cells[rowIterator, 3].Value.ToString().Trim()).Equals(""))
                                                        {
                                                            codEspecieSerfor = objLog.GetCodEspecie(
                                                                workSheet.Cells[rowIterator, 3].Value == null ? "" : workSheet.Cells[rowIterator, 3].Value.ToString().Trim(),
                                                                workSheet.Cells[rowIterator, 4].Value == null ? "" : workSheet.Cells[rowIterator, 4].Value.ToString().Trim()
                                                            );

                                                            if (codEspecieSerfor != null && codEspecieSerfor != "")
                                                            {
                                                                oCampos.COD_ESPECIES_SERFOR = codEspecieSerfor;
                                                                oCampos.ESPECIES_SERFOR = String.Format("{0} | {1}", workSheet.Cells[rowIterator, 3].Value == null ? "" : workSheet.Cells[rowIterator, 3].Value.ToString().Trim(), workSheet.Cells[rowIterator, 4].Value == null ? "" : workSheet.Cells[rowIterator, 4].Value.ToString().Trim());
                                                            }
                                                            else isAdd = false;
                                                        }

                                                        if (isAdd) ListPOAItemsDetalle.Add(oCampos);
                                                    }
                                                }
                                            }
                                            else if (hdfItemCod_MTipo == "0000020")
                                            {
                                                for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                                                {
                                                    oCampos = new CEntidad();
                                                    objLog = new Log_PLAN_MANEJO();
                                                    isAdd = true;

                                                    codEspecie = objLog.GetCodEspecie(
                                                        workSheet.Cells[rowIterator, 1].Value == null ? "" : workSheet.Cells[rowIterator, 1].Value.ToString().Trim(),
                                                        workSheet.Cells[rowIterator, 2].Value == null ? "" : workSheet.Cells[rowIterator, 2].Value.ToString().Trim()
                                                    );

                                                    if (codEspecie != null && codEspecie.Trim() != "")
                                                    {
                                                        oCampos.COD_SECUENCIAL = 0;
                                                        oCampos.COD_ESPECIES = codEspecie;
                                                        oCampos.ESPECIES = String.Format("{0} | {1}", workSheet.Cells[rowIterator, 1].Value == null ? "" : workSheet.Cells[rowIterator, 1].Value.ToString().Trim(), workSheet.Cells[rowIterator, 2].Value == null ? "" : workSheet.Cells[rowIterator, 2].Value.ToString().Trim());
                                                        oCampos.FECHA1 = workSheet.Cells[rowIterator, 5].Value == null ? "" : workSheet.Cells[rowIterator, 5].Value.ToString().Trim();
                                                        oCampos.GUIA_TRANSPORTE = workSheet.Cells[rowIterator, 6].Value == null ? "" : workSheet.Cells[rowIterator, 6].Value.ToString().Trim();
                                                        oCampos.FECHA2 = workSheet.Cells[rowIterator, 7].Value == null ? "" : workSheet.Cells[rowIterator, 7].Value.ToString().Trim();
                                                        oCampos.RECIBO = workSheet.Cells[rowIterator, 8].Value == null ? "" : workSheet.Cells[rowIterator, 8].Value.ToString().Trim();
                                                        oCampos.SALDO = workSheet.Cells[rowIterator, 9].Value == null ? 0 : Decimal.Parse(workSheet.Cells[rowIterator, 9].Value.ToString().Trim());
                                                        oCampos.TIPOMADERABLE = "NO MADERABLES";
                                                        oCampos.CANTIDAD = workSheet.Cells[rowIterator, 10].Value == null ? 0 : Int32.Parse(workSheet.Cells[rowIterator, 10].Value.ToString().Trim());
                                                        oCampos.OBSERVACION = workSheet.Cells[rowIterator, 11].Value == null ? "" : workSheet.Cells[rowIterator, 11].Value.ToString().Trim();
                                                        oCampos.RegEstado = 1;

                                                        if (!(workSheet.Cells[rowIterator, 3].Value == null ? "" : workSheet.Cells[rowIterator, 3].Value.ToString().Trim()).Equals(""))
                                                        {
                                                            codEspecieSerfor = objLog.GetCodEspecie(
                                                                workSheet.Cells[rowIterator, 3].Value == null ? "" : workSheet.Cells[rowIterator, 3].Value.ToString().Trim(),
                                                                workSheet.Cells[rowIterator, 4].Value == null ? "" : workSheet.Cells[rowIterator, 4].Value.ToString().Trim()
                                                            );

                                                            if (codEspecieSerfor != null && codEspecieSerfor != "")
                                                            {
                                                                oCampos.COD_ESPECIES_SERFOR = codEspecieSerfor;
                                                                oCampos.ESPECIES_SERFOR = String.Format("{0} | {1}", workSheet.Cells[rowIterator, 3].Value == null ? "" : workSheet.Cells[rowIterator, 3].Value.ToString().Trim(), workSheet.Cells[rowIterator, 4].Value == null ? "" : workSheet.Cells[rowIterator, 4].Value.ToString().Trim());
                                                            }
                                                            else isAdd = false;
                                                        }

                                                        if (isAdd) ListPOAItemsDetalle.Add(oCampos);
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                                                {
                                                    oCampos = new CEntidad();
                                                    objLog = new Log_PLAN_MANEJO();
                                                    isAdd = true;

                                                    codEspecie = objLog.GetCodEspecie(
                                                        workSheet.Cells[rowIterator, 1].Value == null ? "" : workSheet.Cells[rowIterator, 1].Value.ToString().Trim(),
                                                        workSheet.Cells[rowIterator, 2].Value == null ? "" : workSheet.Cells[rowIterator, 2].Value.ToString().Trim()
                                                    );

                                                    if (codEspecie != null && codEspecie.Trim() != "")
                                                    {
                                                        oCampos.COD_SECUENCIAL = 0;
                                                        oCampos.COD_ESPECIES = codEspecie;
                                                        oCampos.ESPECIES = String.Format("{0} | {1}", workSheet.Cells[rowIterator, 1].Value == null ? "" : workSheet.Cells[rowIterator, 1].Value.ToString().Trim(), workSheet.Cells[rowIterator, 2].Value == null ? "" : workSheet.Cells[rowIterator, 2].Value.ToString().Trim());
                                                        oCampos.VOLUMEN_AUTORIZADO = workSheet.Cells[rowIterator, 5].Value == null ? 0 : Decimal.Parse(workSheet.Cells[rowIterator, 5].Value.ToString().Trim());
                                                        oCampos.VOLUMEN_MOVILIZADO = workSheet.Cells[rowIterator, 6].Value == null ? 0 : Decimal.Parse(workSheet.Cells[rowIterator, 6].Value.ToString().Trim());
                                                        oCampos.SALDO = workSheet.Cells[rowIterator, 7].Value == null ? 0 : Decimal.Parse(workSheet.Cells[rowIterator, 7].Value.ToString().Trim());
                                                        oCampos.TIPOMADERABLE = "NO MADERABLES";
                                                        oCampos.UNIDAD_MEDIDA = "KG";
                                                        oCampos.OBSERVACION = workSheet.Cells[rowIterator, 8].Value == null ? "" : workSheet.Cells[rowIterator, 8].Value.ToString().Trim();
                                                        oCampos.RegEstado = 1;

                                                        if (!(workSheet.Cells[rowIterator, 3].Value == null ? "" : workSheet.Cells[rowIterator, 3].Value.ToString().Trim()).Equals(""))
                                                        {
                                                            codEspecieSerfor = objLog.GetCodEspecie(
                                                                workSheet.Cells[rowIterator, 3].Value == null ? "" : workSheet.Cells[rowIterator, 3].Value.ToString().Trim(),
                                                                workSheet.Cells[rowIterator, 4].Value == null ? "" : workSheet.Cells[rowIterator, 4].Value.ToString().Trim()
                                                            );

                                                            if (codEspecieSerfor != null && codEspecieSerfor != "")
                                                            {
                                                                oCampos.COD_ESPECIES_SERFOR = codEspecieSerfor;
                                                                oCampos.ESPECIES_SERFOR = String.Format("{0} | {1}", workSheet.Cells[rowIterator, 3].Value == null ? "" : workSheet.Cells[rowIterator, 3].Value.ToString().Trim(), workSheet.Cells[rowIterator, 4].Value == null ? "" : workSheet.Cells[rowIterator, 4].Value.ToString().Trim());
                                                            }
                                                            else isAdd = false;
                                                        }

                                                        if (isAdd) ListPOAItemsDetalle.Add(oCampos);
                                                    }
                                                }
                                            }
                                        }
                                        else
                                        {
                                            hdfItemCod_MTipo = Request["hdfItemCod_MTipo"];

                                            if (hdfItemCod_MTipo == "0000021")
                                            {
                                                for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                                                {
                                                    oCampos = new CEntidad();
                                                    objLog = new Log_PLAN_MANEJO();
                                                    isAdd = true;

                                                    codEspecie = objLog.GetCodEspecie(
                                                        workSheet.Cells[rowIterator, 1].Value == null ? "" : workSheet.Cells[rowIterator, 1].Value.ToString().Trim(),
                                                        workSheet.Cells[rowIterator, 2].Value == null ? "" : workSheet.Cells[rowIterator, 2].Value.ToString().Trim()
                                                    );

                                                    if (codEspecie != null && codEspecie.Trim() != "")
                                                    {
                                                        oCampos.COD_SECUENCIAL = 0;
                                                        oCampos.COD_ESPECIES = codEspecie;
                                                        oCampos.ESPECIES = String.Format("{0} | {1}", workSheet.Cells[rowIterator, 1].Value == null ? "" : workSheet.Cells[rowIterator, 1].Value.ToString().Trim(), workSheet.Cells[rowIterator, 2].Value == null ? "" : workSheet.Cells[rowIterator, 2].Value.ToString().Trim());
                                                        oCampos.TIPOMADERABLE = workSheet.Cells[rowIterator, 5].Value == null ? "" : workSheet.Cells[rowIterator, 5].Value.ToString().Trim();
                                                        oCampos.SALDO = workSheet.Cells[rowIterator, 12].Value == null ? 0 : Decimal.Parse(workSheet.Cells[rowIterator, 12].Value.ToString().Trim());
                                                        oCampos.OBSERVACION = workSheet.Cells[rowIterator, 13].Value == null ? "" : workSheet.Cells[rowIterator, 13].Value.ToString().Trim();
                                                        oCampos.RegEstado = 1;

                                                        if (oCampos.TIPOMADERABLE.Equals("MADERABLES") || oCampos.TIPOMADERABLE.Equals("CARBON"))
                                                        {
                                                            oCampos.DMC = workSheet.Cells[rowIterator, 6].Value == null ? 0 : Int32.Parse(workSheet.Cells[rowIterator, 6].Value.ToString().Trim());
                                                            oCampos.TOTAL_ARBOLES = workSheet.Cells[rowIterator, 7].Value == null ? 0 : Int32.Parse(workSheet.Cells[rowIterator, 7].Value.ToString().Trim());
                                                            oCampos.VOLUMEN_AUTORIZADO = workSheet.Cells[rowIterator, 8].Value == null ? 0 : Decimal.Parse(workSheet.Cells[rowIterator, 8].Value.ToString().Trim());
                                                            oCampos.VOLUMEN_MOVILIZADO = workSheet.Cells[rowIterator, 9].Value == null ? 0 : Decimal.Parse(workSheet.Cells[rowIterator, 9].Value.ToString().Trim());

                                                            if (oCampos.TIPOMADERABLE.Equals("MADERABLES")) oCampos.UNIDAD_MEDIDA = "M3";
                                                            else oCampos.UNIDAD_MEDIDA = "KG";

                                                            //Para que valores numéricos no vayan con -1
                                                            oCampos.AUTORIZADO = 0;
                                                            oCampos.EXTRAIDO = 0;
                                                        }
                                                        else if (oCampos.TIPOMADERABLE.Equals("NO MADERABLES"))
                                                        {
                                                            oCampos.AUTORIZADO = workSheet.Cells[rowIterator, 10].Value == null ? 0 : Decimal.Parse(workSheet.Cells[rowIterator, 10].Value.ToString().Trim());
                                                            oCampos.EXTRAIDO = workSheet.Cells[rowIterator, 11].Value == null ? 0 : Decimal.Parse(workSheet.Cells[rowIterator, 11].Value.ToString().Trim());
                                                            oCampos.UNIDAD_MEDIDA = "KG";
                                                            //Para que valores numéricos no vayan con -1
                                                            oCampos.DMC = 0;
                                                            oCampos.TOTAL_ARBOLES = 0;
                                                            oCampos.VOLUMEN_AUTORIZADO = 0;
                                                            oCampos.VOLUMEN_MOVILIZADO = 0;
                                                        }

                                                        if (!(workSheet.Cells[rowIterator, 3].Value == null ? "" : workSheet.Cells[rowIterator, 3].Value.ToString().Trim()).Equals(""))
                                                        {
                                                            codEspecieSerfor = objLog.GetCodEspecie(
                                                                workSheet.Cells[rowIterator, 3].Value == null ? "" : workSheet.Cells[rowIterator, 3].Value.ToString().Trim(),
                                                                workSheet.Cells[rowIterator, 4].Value == null ? "" : workSheet.Cells[rowIterator, 4].Value.ToString().Trim()
                                                            );

                                                            if (codEspecieSerfor != null && codEspecieSerfor != "")
                                                            {
                                                                oCampos.COD_ESPECIES_SERFOR = codEspecieSerfor;
                                                                oCampos.ESPECIES_SERFOR = String.Format("{0} | {1}", workSheet.Cells[rowIterator, 3].Value == null ? "" : workSheet.Cells[rowIterator, 3].Value.ToString().Trim(), workSheet.Cells[rowIterator, 4].Value == null ? "" : workSheet.Cells[rowIterator, 4].Value.ToString().Trim());
                                                            }
                                                            else isAdd = false;
                                                        }

                                                        if (isAdd) ListPOAItemsDetalle.Add(oCampos);
                                                    }
                                                }
                                            }
                                            else if (hdfItemCod_MTipo == "0000020")
                                            {
                                                for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                                                {
                                                    oCampos = new CEntidad();
                                                    objLog = new Log_PLAN_MANEJO();
                                                    isAdd = true;

                                                    codEspecie = objLog.GetCodEspecie(
                                                        workSheet.Cells[rowIterator, 1].Value == null ? "" : workSheet.Cells[rowIterator, 1].Value.ToString().Trim(),
                                                        workSheet.Cells[rowIterator, 2].Value == null ? "" : workSheet.Cells[rowIterator, 2].Value.ToString().Trim()
                                                    );

                                                    if (codEspecie != null && codEspecie.Trim() != "")
                                                    {
                                                        oCampos.COD_SECUENCIAL = 0;
                                                        oCampos.COD_ESPECIES = codEspecie;
                                                        oCampos.ESPECIES = String.Format("{0} | {1}", workSheet.Cells[rowIterator, 1].Value == null ? "" : workSheet.Cells[rowIterator, 1].Value.ToString().Trim(), workSheet.Cells[rowIterator, 2].Value == null ? "" : workSheet.Cells[rowIterator, 2].Value.ToString().Trim());
                                                        oCampos.TIPOMADERABLE = workSheet.Cells[rowIterator, 5].Value == null ? "" : workSheet.Cells[rowIterator, 5].Value.ToString().Trim();
                                                        oCampos.SALDO = workSheet.Cells[rowIterator, 14].Value == null ? 0 : Decimal.Parse(workSheet.Cells[rowIterator, 14].Value.ToString().Trim());
                                                        oCampos.OBSERVACION = workSheet.Cells[rowIterator, 16].Value == null ? "" : workSheet.Cells[rowIterator, 16].Value.ToString().Trim();
                                                        oCampos.RegEstado = 1;

                                                        if (oCampos.TIPOMADERABLE.Equals("MADERABLES") || oCampos.TIPOMADERABLE.Equals("CARBON"))
                                                        {
                                                            oCampos.DMC = workSheet.Cells[rowIterator, 6].Value == null ? 0 : Int32.Parse(workSheet.Cells[rowIterator, 6].Value.ToString().Trim());
                                                            oCampos.TOTAL_ARBOLES = workSheet.Cells[rowIterator, 7].Value == null ? 0 : Int32.Parse(workSheet.Cells[rowIterator, 7].Value.ToString().Trim());
                                                            oCampos.VOLUMEN_AUTORIZADO = workSheet.Cells[rowIterator, 8].Value == null ? 0 : Decimal.Parse(workSheet.Cells[rowIterator, 8].Value.ToString().Trim());
                                                            oCampos.VOLUMEN_MOVILIZADO = workSheet.Cells[rowIterator, 9].Value == null ? 0 : Decimal.Parse(workSheet.Cells[rowIterator, 9].Value.ToString().Trim());

                                                            if (oCampos.TIPOMADERABLE.Equals("MADERABLES")) oCampos.UNIDAD_MEDIDA = "M3";
                                                            else oCampos.UNIDAD_MEDIDA = "KG";

                                                            //Para que valores numéricos no vayan con -1
                                                            oCampos.CANTIDAD = 0;

                                                        }
                                                        else if (oCampos.TIPOMADERABLE.Equals("NO MADERABLES"))
                                                        {
                                                            oCampos.FECHA1 = workSheet.Cells[rowIterator, 10].Value == null ? "" : workSheet.Cells[rowIterator, 10].Value.ToString().Trim();
                                                            oCampos.GUIA_TRANSPORTE = workSheet.Cells[rowIterator, 11].Value == null ? "" : workSheet.Cells[rowIterator, 11].Value.ToString().Trim();
                                                            oCampos.FECHA2 = workSheet.Cells[rowIterator, 12].Value == null ? "" : workSheet.Cells[rowIterator, 12].Value.ToString().Trim();
                                                            oCampos.RECIBO = workSheet.Cells[rowIterator, 13].Value == null ? "" : workSheet.Cells[rowIterator, 13].Value.ToString().Trim();
                                                            oCampos.CANTIDAD = workSheet.Cells[rowIterator, 15].Value == null ? 0 : Int32.Parse(workSheet.Cells[rowIterator, 15].Value.ToString().Trim());

                                                            //Para que valores numéricos no vayan con -1
                                                            oCampos.DMC = 0;
                                                            oCampos.TOTAL_ARBOLES = 0;
                                                            oCampos.VOLUMEN_AUTORIZADO = 0;
                                                            oCampos.VOLUMEN_MOVILIZADO = 0;
                                                        }

                                                        if (!(workSheet.Cells[rowIterator, 3].Value == null ? "" : workSheet.Cells[rowIterator, 3].Value.ToString().Trim()).Equals(""))
                                                        {
                                                            codEspecieSerfor = objLog.GetCodEspecie(
                                                                workSheet.Cells[rowIterator, 3].Value == null ? "" : workSheet.Cells[rowIterator, 3].Value.ToString().Trim(),
                                                                workSheet.Cells[rowIterator, 4].Value == null ? "" : workSheet.Cells[rowIterator, 4].Value.ToString().Trim()
                                                            );

                                                            if (codEspecieSerfor != null && codEspecieSerfor != "")
                                                            {
                                                                oCampos.COD_ESPECIES_SERFOR = codEspecieSerfor;
                                                                oCampos.ESPECIES_SERFOR = String.Format("{0} | {1}", workSheet.Cells[rowIterator, 3].Value == null ? "" : workSheet.Cells[rowIterator, 3].Value.ToString().Trim(), workSheet.Cells[rowIterator, 4].Value == null ? "" : workSheet.Cells[rowIterator, 4].Value.ToString().Trim());
                                                            }
                                                            else isAdd = false;
                                                        }

                                                        if (isAdd) ListPOAItemsDetalle.Add(oCampos);
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                                                {
                                                    oCampos = new CEntidad();
                                                    objLog = new Log_PLAN_MANEJO();
                                                    isAdd = true;

                                                    codEspecie = objLog.GetCodEspecie(
                                                        workSheet.Cells[rowIterator, 1].Value == null ? "" : workSheet.Cells[rowIterator, 1].Value.ToString().Trim(),
                                                        workSheet.Cells[rowIterator, 2].Value == null ? "" : workSheet.Cells[rowIterator, 2].Value.ToString().Trim()
                                                    );

                                                    if (codEspecie != null && codEspecie.Trim() != "")
                                                    {
                                                        oCampos.COD_SECUENCIAL = 0;
                                                        oCampos.COD_ESPECIES = codEspecie;
                                                        oCampos.ESPECIES = String.Format("{0} | {1}", workSheet.Cells[rowIterator, 1].Value == null ? "" : workSheet.Cells[rowIterator, 1].Value.ToString().Trim(), workSheet.Cells[rowIterator, 2].Value == null ? "" : workSheet.Cells[rowIterator, 2].Value.ToString().Trim());
                                                        oCampos.TIPOMADERABLE = workSheet.Cells[rowIterator, 5].Value == null ? "" : workSheet.Cells[rowIterator, 5].Value.ToString().Trim();
                                                        oCampos.VOLUMEN_AUTORIZADO = workSheet.Cells[rowIterator, 8].Value == null ? 0 : Decimal.Parse(workSheet.Cells[rowIterator, 8].Value.ToString().Trim());
                                                        oCampos.VOLUMEN_MOVILIZADO = workSheet.Cells[rowIterator, 9].Value == null ? 0 : Decimal.Parse(workSheet.Cells[rowIterator, 9].Value.ToString().Trim());
                                                        oCampos.SALDO = workSheet.Cells[rowIterator, 10].Value == null ? 0 : Decimal.Parse(workSheet.Cells[rowIterator, 10].Value.ToString().Trim());
                                                        oCampos.OBSERVACION = workSheet.Cells[rowIterator, 11].Value == null ? "" : workSheet.Cells[rowIterator, 11].Value.ToString().Trim();
                                                        oCampos.RegEstado = 1;

                                                        if (oCampos.TIPOMADERABLE.Equals("MADERABLES") || oCampos.TIPOMADERABLE.Equals("CARBON"))
                                                        {
                                                            oCampos.DMC = workSheet.Cells[rowIterator, 6].Value == null ? 0 : Int32.Parse(workSheet.Cells[rowIterator, 6].Value.ToString().Trim());
                                                            oCampos.TOTAL_ARBOLES = workSheet.Cells[rowIterator, 7].Value == null ? 0 : Int32.Parse(workSheet.Cells[rowIterator, 7].Value.ToString().Trim());

                                                            if (oCampos.TIPOMADERABLE.Equals("MADERABLES")) oCampos.UNIDAD_MEDIDA = "M3";
                                                            else oCampos.UNIDAD_MEDIDA = "KG";
                                                        }
                                                        else if (oCampos.TIPOMADERABLE.Equals("NO MADERABLES"))
                                                        {
                                                            oCampos.UNIDAD_MEDIDA = "KG";

                                                            //Para que valores numéricos no vayan con -1
                                                            oCampos.DMC = 0;
                                                            oCampos.TOTAL_ARBOLES = 0;
                                                        }

                                                        if (!(workSheet.Cells[rowIterator, 3].Value == null ? "" : workSheet.Cells[rowIterator, 3].Value.ToString().Trim()).Equals(""))
                                                        {
                                                            codEspecieSerfor = objLog.GetCodEspecie(
                                                                workSheet.Cells[rowIterator, 3].Value == null ? "" : workSheet.Cells[rowIterator, 3].Value.ToString().Trim(),
                                                                workSheet.Cells[rowIterator, 4].Value == null ? "" : workSheet.Cells[rowIterator, 4].Value.ToString().Trim()
                                                            );

                                                            if (codEspecieSerfor != null && codEspecieSerfor != "")
                                                            {
                                                                oCampos.COD_ESPECIES_SERFOR = codEspecieSerfor;
                                                                oCampos.ESPECIES_SERFOR = String.Format("{0} | {1}", workSheet.Cells[rowIterator, 3].Value == null ? "" : workSheet.Cells[rowIterator, 3].Value.ToString().Trim(), workSheet.Cells[rowIterator, 4].Value == null ? "" : workSheet.Cells[rowIterator, 4].Value.ToString().Trim());
                                                            }
                                                            else isAdd = false;
                                                        }

                                                        if (isAdd) ListPOAItemsDetalle.Add(oCampos);
                                                    }
                                                }
                                            }
                                        }

                                        break;
                                        #endregion
                                }



                                //objVM2.ListMadeCENSO.AddRange(ListPOAItemsDetalle);

                                retorna = ListPOAItemsDetalle;




                            }
                        }
                    }
                    else
                    {
                        success = false;
                        msj = "Archivo cargado no válido, utilizar la plantilla desde la opción de descarga.";
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

        public void validarFilaVertice(ExcelWorksheet workSheet, int rowIterator)
        {
            string[] zonaUTM = new string[] { "17S", "18S", "19S" };
            if (workSheet.Cells[rowIterator, 1].Value == null || workSheet.Cells[rowIterator, 2].Value == null || workSheet.Cells[rowIterator, 3].Value == null || workSheet.Cells[rowIterator, 4].Value == null)
            {
                throw new Exception("0|Error en la fila " + rowIterator.ToString() + ", Son campos obligatorios las columnas VERTICE, ZONA_UTM, COORDENADA_ESTE, COORDENADAS_NORTE");
            }
            if (workSheet.Cells[rowIterator, 1].Value.ToString().Trim() == "" || workSheet.Cells[rowIterator, 2].Value.ToString().Trim() == "" || workSheet.Cells[rowIterator, 3].Value.ToString().Trim() == "" || workSheet.Cells[rowIterator, 4].Value.ToString().Trim() == "")
            {
                throw new Exception("0|Error en la fila " + rowIterator.ToString() + ", Son campos obligatorios las columnas VERTICE, ZONA_UTM, COORDENADA_ESTE, COORDENADAS_NORTE");
            }
            if (!zonaUTM.Contains(workSheet.Cells[rowIterator, 2].Value.ToString()))
            {
                throw new Exception("0|Error en la fila " + rowIterator.ToString() + ", Los valores correctos solo pueden ser 17S, 18S y 19S en mayuscula");
            }
            //validando si son numeros
            bool isNum;
            Int32 retNum;
            isNum = Int32.TryParse(Convert.ToString(workSheet.Cells[rowIterator, 3].Value.ToString()), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
            if (!isNum)
            {
                throw new Exception("0|Error en la fila " + rowIterator.ToString() + ", Los valores de COORDENADA_ESTE debe ser numero entero");
            }
            isNum = Int32.TryParse(Convert.ToString(workSheet.Cells[rowIterator, 4].Value.ToString()), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
            if (!isNum)
            {
                throw new Exception("0|Error en la fila " + rowIterator.ToString() + ", Los valores de COORDENADAS_NORTE debe ser numero entero");
            }
            if (workSheet.Cells[rowIterator, 3].Value.ToString().Length > 6)
            {
                throw new Exception("0|Error en la fila " + rowIterator.ToString() + ", Los valores de COORDENADAS_ESTE debe ser numero entero maximo de 6 digitos");
            }
            if (workSheet.Cells[rowIterator, 4].Value.ToString().Length > 7)
            {
                throw new Exception("0|Error en la fila " + rowIterator.ToString() + ", Los valores de COORDENADAS_ESTE debe ser numero entero maximo de 7 digitos");
            }
            if (Convert.ToInt32(workSheet.Cells[rowIterator, 3].Value.ToString()) < 0 || Convert.ToInt32(workSheet.Cells[rowIterator, 4].Value.ToString()) < 0)
            {
                throw new Exception("0|Error en la fila " + rowIterator.ToString() + ", Los valores de COORDENADAS_ESTE y COORDENADAS_NORTE deben ser mayor o igual a 0");
            }

        }
        [HttpGet]
        [DeleteFileAttribute]
        public ActionResult Download(string file = "PoaVertice.xlsx")
        {
            string fullPath = Path.Combine(Server.MapPath("~/Archivos/Plantilla"), file);
            return File(fullPath, "application/vnd.ms-excel", file);
        }
        [HttpPost]
        public JsonResult ExportarExcelVertices(string COD_THABILITANTE, int NumPoa)
        {
            var result = ReportePOA.GenerarReporteVerticeTH(COD_THABILITANTE, NumPoa);
            return Json(result);
        }
        [HttpPost]
        public JsonResult ExportarExcel(string TVentana, string COD_THABILITANTE, int NumPoa, string hdfItemCod_MTipo,
            string estado_origen, string indicador = "")
        {


            object result = new object();

            string nomPlantilla = "";
            switch (TVentana)
            {
                case "BEMADE":
                    List<Ent_POA> listParam = new List<Ent_POA>();
                    Ent_POA oCamposMod = new Ent_POA();
                    oCamposMod.COD_THABILITANTE = COD_THABILITANTE;
                    oCamposMod.NUM_POA = NumPoa;
                    Ent_POA datModificar = new Ent_POA();
                    Log_POA log = new Log_POA();
                    if (estado_origen == "R")//REINGRESO                    
                        datModificar = log.RegMostrarListaHijoItems(oCamposMod);
                    else
                        datModificar = log.RegMostrarListaItems(oCamposMod);


                    if (datModificar.ListBExtPOA.Count > 0)
                    {
                        listParam = datModificar.ListBExtPOA[0].ListMadeBEXTRACCION;
                        result = ReportePOA.DescargaExceles("PoaMaderableBExtraccion_v2.xlsx", listParam);
                    }
                    else
                    {

                        var resultado = new { sds = "" };
                        return Json(new { success = false, msj = "no tiene data" });
                    }
                    break;
                case "RAPROBMADE":

                    if (hdfItemCod_MTipo == "0000021")
                    {
                        nomPlantilla = "PoaMaderableRAprobPMed_v3.xlsx";
                    }
                    else if (hdfItemCod_MTipo == "0000020")
                    {
                        nomPlantilla = "PoaMaderableRAprobPCarr_v3.xlsx";
                    }
                    else
                    {
                        nomPlantilla = "PoaMaderableRAprob_v3.xlsx";
                    }

                    oCamposMod = new Ent_POA();
                    oCamposMod.COD_THABILITANTE = COD_THABILITANTE;
                    oCamposMod.NUM_POA = NumPoa;

                    datModificar = new Ent_POA();
                    log = new Log_POA();

                    if (estado_origen == "R")//REINGRESO                    
                        datModificar = log.RegMostrarListaHijoItems(oCamposMod);
                    else
                        datModificar = log.RegMostrarListaItems(oCamposMod);

                    if (datModificar.ListRAprueba.Count > 0)
                    {
                        listParam = datModificar.ListRAprueba;
                        result = ReportePOA.DescargaExceles(nomPlantilla, listParam);
                    }
                    else
                    {
                        return Json(new { success = false, msj = "no tiene data" });
                    }

                    break;
                case "VERTICE":
                    listParam = new List<Ent_POA>();
                    oCamposMod = new Ent_POA();
                    oCamposMod.COD_THABILITANTE = COD_THABILITANTE;
                    oCamposMod.NUM_POA = NumPoa;
                    datModificar = new Ent_POA();
                    log = new Log_POA();
                    if (estado_origen == "R")//REINGRESO                    
                        datModificar = log.RegMostrarListaHijoItems(oCamposMod);
                    else
                        datModificar = log.RegMostrarListaItems(oCamposMod);

                    listParam = datModificar.ListVERTICE;

                    result = ReportePOA.DescargaExceles("PoaVertice.xlsx", listParam);

                    break;

                case "BENOMADE":
                    listParam = new List<Ent_POA>();
                    oCamposMod = new Ent_POA();
                    oCamposMod.COD_THABILITANTE = COD_THABILITANTE;
                    oCamposMod.NUM_POA = NumPoa;
                    datModificar = new Ent_POA();
                    log = new Log_POA();
                    if (estado_origen == "R")//REINGRESO                    
                        datModificar = log.RegMostrarListaHijoItems(oCamposMod);
                    else
                        datModificar = log.RegMostrarListaItems(oCamposMod);


                    if (datModificar.ListBExtPOA.Count > 0)
                    {
                        listParam = datModificar.ListBExtPOA[0].ListNoMadeBEXTRACCION;
                        result = ReportePOA.DescargaExceles("PoaMaderableBExtraccion_v2.xlsx", listParam);
                    }
                    else
                    {

                        var resultado = new { sds = "" };
                        return Json(new { success = false, msj = "no tiene data" });
                    }

                    break;
                case "BEINSITU":
                    listParam = new List<Ent_POA>();
                    oCamposMod = new Ent_POA();
                    oCamposMod.COD_THABILITANTE = COD_THABILITANTE;
                    oCamposMod.NUM_POA = NumPoa;
                    datModificar = new Ent_POA();
                    log = new Log_POA();
                    if (estado_origen == "R")//REINGRESO                    
                        datModificar = log.RegMostrarListaHijoItems(oCamposMod);
                    else
                        datModificar = log.RegMostrarListaItems(oCamposMod);

                    if (datModificar.ListBExtPOA.Count > 0)
                    {
                        listParam = datModificar.ListBExtPOA[0].ListISituBEXTRACCION;
                        result = ReportePOA.DescargaExceles("PoaMaderableBExtraccion_v2.xlsx", listParam);
                    }
                    else
                    {
                        return Json(new { success = false, msj = "no tiene data" });
                    }
                    break;

                case "RAPROBINSITU":
                    listParam = new List<Ent_POA>();
                    oCamposMod = new Ent_POA();
                    oCamposMod.COD_THABILITANTE = COD_THABILITANTE;
                    oCamposMod.NUM_POA = NumPoa;
                    datModificar = new Ent_POA();
                    log = new Log_POA();
                    if (estado_origen == "R")//REINGRESO                    
                        datModificar = log.RegMostrarListaHijoItems(oCamposMod);
                    else
                        datModificar = log.RegMostrarListaItems(oCamposMod);

                    if (datModificar.ListRApruebaISitu.Count > 0)
                    {
                        listParam = datModificar.ListRApruebaISitu;
                        result = ReportePOA.DescargaExceles("PoaMaderableBExtraccion_v2.xlsx", listParam);
                    }
                    else
                    {
                        return Json(new { success = false, msj = "no tiene data" });
                    }
                    break;

                case "BExt_MadeNoMade":
                    listParam = new List<Ent_POA>();
                    oCamposMod = new Ent_POA();
                    oCamposMod.COD_THABILITANTE = COD_THABILITANTE;
                    oCamposMod.NUM_POA = NumPoa;
                    datModificar = new Ent_POA();
                    log = new Log_POA();

                    if (estado_origen == "R")//REINGRESO                    
                        datModificar = log.RegMostrarListaHijoItems(oCamposMod);
                    else
                        datModificar = log.RegMostrarListaItems(oCamposMod);

                    if (datModificar.ListBExtPOA.Count > 0)
                    {
                        listParam = datModificar.ListBExtPOA[0].ListMadeBEXTRACCION;

                        if (
                            (estado_origen.Equals("PN") && indicador.Equals("M")) ||
                            (estado_origen.Equals("R")) ||
                            (estado_origen.Equals("MS")) ||
                            (estado_origen.Equals("PC"))
                        )
                        {
                            result = ReportePOA.DescargaExceles("PoaMaderableBExtraccion_v3.xlsx", listParam);
                        }
                        else if (
                            (estado_origen.Equals("PN") && indicador.Equals("NM")) ||
                            (estado_origen.Equals("PCN"))
                        )
                        {
                            if (hdfItemCod_MTipo == "0000021")
                            {
                                result = ReportePOA.DescargaExceles("PoaNoMaderablePMedBExtraccion_v3.xlsx", listParam);
                            }
                            else if (hdfItemCod_MTipo == "0000020")
                            {
                                result = ReportePOA.DescargaExceles("PoaNoMaderableCarrBExtraccion_v3.xlsx", listParam);
                            }
                            else
                            {
                                result = ReportePOA.DescargaExceles("PoaNoMaderableBExtraccion_v3.xlsx", listParam);
                            }
                        }
                        else
                        {
                            if (hdfItemCod_MTipo == "0000021")
                            {
                                result = ReportePOA.DescargaExceles("PoaMadNoMadPMedBExtraccion_v3.xlsx", listParam);
                            }
                            else if (hdfItemCod_MTipo == "0000020")
                            {
                                result = ReportePOA.DescargaExceles("PoaMadNoMadCarrBExtraccion_v3.xlsx", listParam);
                            }
                            else
                            {
                                result = ReportePOA.DescargaExceles("PoaMadNoMadBExtraccion_v3.xlsx", listParam);
                            }
                        }
                    }
                    else
                    {
                        var resultado = new { sds = "" };
                        return Json(new { success = false, msj = "no tiene data" });
                    }
                    break;

            }




            return Json(result);
        }

        [HttpPost]
        public JsonResult ExportExcel(VM_POA dto)
        {

            dto.ListMadeCENSO = objVM2.ListMadeCENSO;
            object result = new object();
            result = ReportePOA.DescargaExcel(dto);

            return Json(result);
        }

        [HttpGet]
        [DeleteFileAttribute]
        public ActionResult DownloadVertices(string file)
        {
            string fullPath = Path.Combine(Server.MapPath("~/Archivos/Plantilla"), file);
            return File(fullPath, "application/vnd.ms-excel", file);
        }
        [HttpGet]
        public JsonResult GetAllVertices()
        {
            List<Ent_POA> data = (List<Ent_POA>)TempData["listVERTICE"];
            data = data ?? new List<Ent_POA>();
            //devolviendo solo data requerida
            var lstMin = from cust in data
                         select new
                         {
                             VERTICE = cust.VERTICE,
                             ZONA = cust.ZONA,
                             COORDENADA_ESTE = cust.COORDENADA_ESTE,
                             COORDENADA_NORTE = cust.COORDENADA_NORTE,
                             PCA = cust.PCA,
                             OBSERVACION = cust.OBSERVACION,
                             COD_SECUENCIAL = cust.COD_SECUENCIAL,
                             RegEstado = cust.RegEstado

                         };
            var jsonResult = Json(new { data = lstMin }, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
        [HttpGet]
        public JsonResult GetAllListDetRegente()
        {
            List<Ent_POA> data = (List<Ent_POA>)TempData["listDETREGENTE"];
            data = data ?? new List<Ent_POA>();
            int i = 1;
            var lstMin = from cust in data
                         select new
                         {
                             NRO = i++,
                             PERSONA = cust.PERSONA,
                             N_DOCUMENTO = cust.N_DOCUMENTO,
                             COD_PTIPO = cust.COD_PTIPO,
                             TIPO_CARGO = cust.TIPO_CARGO,
                             COD_PERSONA = cust.COD_PERSONA,
                             OTORGAMIENTO = cust.OTORGAMIENTO,
                             RESAPROBACION = cust.RESAPROBACION,
                             CATEGORIA = cust.CATEGORIA,
                             CIP = cust.CIP,
                             ESTADO_REGENTE = cust.ESTADO_REGENTE,
                             ANIO = cust.ANIO,
                             NROLICENCIA = cust.NROLICENCIA,
                             COD_SECUENCIAL = cust.COD_SECUENCIAL,
                             NOMBRE_ARCH = cust.NOMBRE_ARCH,
                             FECHA_INI = cust.FECHA,
                             FECHA_FIN = cust.FECHA1,
                         };
            var jsonResult = Json(new { data = lstMin }, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
        [HttpGet]
        public JsonResult GetAllListAOCULAR()
        {
            List<Ent_POA> data = (List<Ent_POA>)TempData["listAOCULAR"];
            data = data ?? new List<Ent_POA>();
            int i = 1;
            var lstMin = from cust in data
                         select new
                         {
                             NRO = i++,
                             PERSONA = cust.PERSONA,
                             N_DOCUMENTO = cust.N_DOCUMENTO,
                             //CARGO = cust.CARGO,
                             COD_PTIPO = cust.COD_PTIPO,
                             TIPO_CARGO = cust.TIPO_CARGO,
                             COD_PERSONA = cust.COD_PERSONA,
                             RegEstado = cust.RegEstado
                         };
            var jsonResult = Json(new { data = lstMin }, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
        [HttpGet]
        public JsonResult GetAllListTIOCULAR()
        {
            List<Ent_POA> data = (List<Ent_POA>)TempData["listTIOCULAR"];
            data = data ?? new List<Ent_POA>();
            int i = 1;
            var lstMin = from cust in data
                         select new
                         {
                             NRO = i++,
                             PERSONA = cust.PERSONA,
                             N_DOCUMENTO = cust.N_DOCUMENTO,
                             //CARGO = cust.CARGO,
                             COD_PTIPO = cust.COD_PTIPO,
                             TIPO_CARGO = cust.TIPO_CARGO,
                             COD_PERSONA = cust.COD_PERSONA,
                             RegEstado = cust.RegEstado
                         };
            var jsonResult = Json(new { data = lstMin }, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
        [HttpGet]
        public JsonResult GetAllListTRAPROBACION()
        {
            List<Ent_POA> data = (List<Ent_POA>)TempData["listTRAPROBACION"];
            data = data ?? new List<Ent_POA>();
            int i = 1;
            var lstMin = from cust in data
                         select new
                         {
                             NRO = i++,
                             PERSONA = cust.PERSONA,
                             N_DOCUMENTO = cust.N_DOCUMENTO,
                             //CARGO = cust.CARGO,
                             COD_PTIPO = cust.COD_PTIPO,
                             TIPO_CARGO = cust.TIPO_CARGO,
                             COD_PERSONA = cust.COD_PERSONA,
                             RegEstado = cust.RegEstado
                         };

            var jsonResult = Json(new { data = lstMin }, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
        [HttpGet]
        public JsonResult GetAllListSAPROBACION()
        {
            List<Ent_POA> data = (List<Ent_POA>)TempData["ListSAPROBACION"];
            data = data ?? new List<Ent_POA>();
            int i = 1;
            var lstMin = from cust in data
                         select new
                         {
                             NRO = i++,
                             PERSONA = cust.PERSONA,
                             N_DOCUMENTO = cust.N_DOCUMENTO,
                             //CARGO = cust.CARGO,
                             COD_PTIPO = cust.COD_PTIPO,
                             TIPO_CARGO = cust.TIPO_CARGO,
                             COD_PERSONA = cust.COD_PERSONA,
                             RegEstado = cust.RegEstado
                         };

            var jsonResult = Json(new { data = lstMin }, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
        [HttpGet]
        public JsonResult GetAllListRAprueba()
        {
            List<Ent_POA> data = (List<Ent_POA>)TempData["listRAprueba"];
            data = data ?? new List<Ent_POA>();
            int i = 1;
            var lstMin = from cust in data
                         select new
                         {
                             NRO = i++,
                             ESPECIES = cust.ESPECIES,
                             ESPECIES_SERFOR = cust.ESPECIES_SERFOR,
                             NUM_ARBOLES = cust.NUM_ARBOLES,
                             VOLUMEN_KILOGRAMOS = cust.VOLUMEN_KILOGRAMOS,
                             SuperficieHa = cust.SuperficieHa,
                             CANTIDAD = cust.CANTIDAD,
                             ABUNDANCIA = cust.ABUNDANCIA,
                             NUMINDIVIDUOS = cust.NUMINDIVIDUOS,
                             PESO = cust.PESO,
                             RENDIMIENTO = cust.RENDIMIENTO,
                             UNIDAD_MEDIDA = cust.UNIDAD_MEDIDA,
                             TIPOMADERABLE = cust.TIPOMADERABLE,
                             PCA = cust.PCA,
                             OBSERVACION = cust.OBSERVACION,
                             COD_ESPECIES = cust.COD_ESPECIES,
                             COD_ESPECIES_SERFOR = cust.COD_ESPECIES_SERFOR,
                             COD_SECUENCIAL = cust.COD_SECUENCIAL,
                             RegEstado = 0

                         };


            var jsonResult = Json(new { data = lstMin }, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }


        [HttpGet]
        public JsonResult GetAllRAPoaInSitu()
        {
            List<Ent_POA> data = (List<Ent_POA>)TempData["ListRApruebaISitu"];
            data = data ?? new List<Ent_POA>();
            int i = 1;
            var lstMin = from cust in data
                         select new
                         {
                             NRO = i++,
                             ESPECIES = cust.ESPECIES,
                             ESPECIES_SERFOR = cust.ESPECIES_SERFOR,
                             PERIODO = cust.PERIODO,
                             CUOTA_SACA = cust.CUOTA_SACA,
                             METODO_CAZA = cust.METODO_CAZA,
                             SISTEMA_MARCAJE = cust.SISTEMA_MARCAJE,
                             DENSIDAD = cust.DENSIDAD,
                             OBSERVACION = cust.OBSERVACION,
                             COD_ESPECIES = cust.COD_ESPECIES,
                             COD_ESPECIES_SERFOR = cust.COD_ESPECIES_SERFOR,
                             RegEstado = 0,
                             COD_SECUENCIAL = cust.COD_SECUENCIAL
                         };


            var jsonResult = Json(new { data = lstMin }, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
        [HttpGet]
        public JsonResult GetAllkardex()
        {
            List<Ent_POA> data = (List<Ent_POA>)TempData["ListKARDEX"];
            data = data ?? new List<Ent_POA>();
            int i = 1;
            var lstMin = from cust in data
                         select new
                         {
                             NRO = i++,
                             ESPECIES = cust.ESPECIES,
                             FECHA_EMISIONKARDEX = cust.FECHA_EMISIONKARDEX,
                             GUIA_TRANSPORTE = cust.GUIA_TRANSPORTE,
                             PRODUCTO = cust.PRODUCTO,
                             DESCRIPCION_KARDEX = cust.DESCRIPCION_KARDEX,
                             CANTIDAD = cust.CANTIDAD,
                             KILOGRAMOS_KARDEX = cust.KILOGRAMOS_KARDEX,
                             M3 = cust.M3,
                             ACUMULADO = cust.ACUMULADO,
                             SALDO_KARDEX = cust.SALDO_KARDEX,
                             OBSERVACION_KARDEX = cust.OBSERVACION_KARDEX,
                             COD_ESPECIES = cust.COD_ESPECIES,
                             COD_KARDEX_PRODUCTO = cust.COD_KARDEX_PRODUCTO,
                             COD_KARDEX_DESCRIPCION = cust.COD_KARDEX_DESCRIPCION,
                             COD_SECUENCIAL = cust.COD_SECUENCIAL,
                             RegEstado = 0

                         };


            var jsonResult = Json(new { data = lstMin }, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        [HttpPost]
        public JsonResult RegistrarPOA(VM_POA dto)
        {

            Log_POA objLog = new Log_POA();

            //dto.ListMadeCENSO.AddRange(objVM2.ListMadeCENSO);
            ListResult resultado;
            resultado = objLog.GuardarDatosPOA(dto, (ModelSession.GetSession())[0].COD_UCUENTA);
            return Json(resultado);
        }

        [HttpPost]
        public PartialViewResult _ErrorMaterial()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult _FechaRegencia()
        {
            return PartialView();
        }

        [HttpPost]
        public JsonResult GrabarDocumentoAdjunto()
        {
            Log_POA objLog = new Log_POA();
            // Checking no of files injected in Request object  
            if (Request.Files.Count > 0)
            {
                try
                {
                    string pathSIGOsfc = ConfigurationManager.AppSettings["pathSIGOsfc"] + "/Contrato/ContratoDetRegente/";
                    Ent_Persona entP = JsonConvert.DeserializeObject<Ent_Persona>(Request.Form["data"]);
                    HttpPostedFileBase file = Request.Files[0];//  Get all files from Request object 

                    if (!Directory.Exists(Server.MapPath(pathSIGOsfc)))
                    {
                        Directory.CreateDirectory(Server.MapPath(pathSIGOsfc));
                    }
                    Guid myuuid = Guid.NewGuid();
                    string myuuidAsString = myuuid.ToString();
                    //Guardar el doc ajunto
                    string name = $"ContratoRegente-{myuuidAsString}.pdf";
                    NOMARCHTEMP = name;
                    string carpetaDestino = Server.MapPath(pathSIGOsfc);
                    string rutaDestino = Path.Combine(carpetaDestino, name);

                    if (entP.COD_SECUENCIAL > 0)
                    {
                        objLog.setArchivoDetRegente(entP, name);
                    }
                    //Get the complete folder path and store the file inside it.
                    file.SaveAs(rutaDestino);
                    

                    return Json(new { success = true, msj = "Se subio correctamente el archivo", data = name });
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            else
            {
                return Json(new { success = false, msj = "No se encontró el documento a subir" });
            }
        }

    }
}