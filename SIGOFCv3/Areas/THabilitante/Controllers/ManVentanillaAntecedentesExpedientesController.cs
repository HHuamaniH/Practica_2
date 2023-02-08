using CapaEntidad.DOC;
using CapaEntidad.ViewModel;
using CapaLogica.DOC;
using SIGOFCv3.Models;
using SIGOFCv3.Models.DataTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using CEntVM = CapaEntidad.ViewModel.DOC.VM_Transferir;
using CEntidad = CapaEntidad.DOC.Ent_ANTECEDENTE_EXPEDIENTE;
using CLogica = CapaLogica.DOC.Log_ANTECEDENTE_EXPEDIENTE;
using SIGOFCv3.Areas.THabilitante.Models.ManVentanillaAntecedentesExpedientes;
using SIGOFCv3.Helper;
using System.IO;

namespace SIGOFCv3.Areas.THabilitante.Controllers
{
    public class ManVentanillaAntecedentesExpedientesController : Controller
    {
        //Validar que el usuario que ingresa a la acción (vista) tenga asignado el menú respectivo (Tabla: SISTEMA_MODULOS_DET_MENU: Columna: COD_SECUENCIAL)
        public ActionResult Index(string _alertaIncial = "")
        {
            ViewBag.Formulario = "AEXPEDIENTE_SITD";
            ViewBag.TituloFormulario = "Gestión de Antecedentes de Expedientes Remitidos por la AFFS";
            ViewBag.AlertaInicial = _alertaIncial;
            ViewBag.ddlOptBustarEstadoVentanilla = new List<SelectListItem>()
            {
                new SelectListItem() { Value = "TODOS", Text = "Todos" },
                new SelectListItem() { Value = "Pendiente", Text = "Pendientes" },
                new SelectListItem() { Value = "Transferido", Text = "Transferidos" },
                new SelectListItem() { Value = "Anulado", Text = "Anulados" },
            };

            ViewBag.ddlOpcionBuscarVentanilla = new List<SelectListItem>()
            {
                new SelectListItem { Value = "TODOS", Text = "Todos" },
                new SelectListItem { Value = "OD", Text = "Oficina Desconcentrada" },
                new SelectListItem { Value = "DOC_REFERENCIA", Text = "Tipo Documento Referencia" },
                new SelectListItem { Value = "NUM_DOCUMENTO", Text = "Documento Trámite" },
                new SelectListItem { Value = "NUM_TRAMITE", Text = "N° Trámite" },
                new SelectListItem { Value = "NUM_THABILITANTE", Text = "Título Habilitante" },
                new SelectListItem { Value = "RESOLUCION_POA", Text = "Resolución de Aprobación" },
            };

            CEntidad ent = new CEntidad();
            CLogica log = new CLogica();
            ent = log.RegMostCombo(ent);

            List<VM_Cbo> DOC_ATFFS_Temp = new List<VM_Cbo>() { new VM_Cbo { Text = "(Seleccionar)", Value = "-" } };
            if (ent.ListMComboDocReferencia != null)
            {
                foreach (var item in ent.ListMComboDocReferencia)
                {
                    DOC_ATFFS_Temp.Add(new VM_Cbo { Text = item.DESCRIPCION, Value = item.CODIGO });
                }
            }
            ViewBag.DOC_ATFFS = DOC_ATFFS_Temp;
            //ViewBag.DOC_ATFFS = ent.ListMComboDocReferencia.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION });

            string appClient = Request.QueryString["appClient"];
            string appData = Request.QueryString["appData"];
            string appServer = Request.QueryString["appServer"];//En los formularios en los que se transfiera los datos devolveran en
            ViewBag.msjTransfer = "";     //la primera columna  ([0]Volver, [1]se encontró un error al registrar, [2]Correcto)
            ViewBag.origen = "";
            if (appClient != null && appData != null && appServer != null)
            {
                if (appServer.Split('|')[0] == "0")
                {
                    if (appClient.Split('|')[1] == "TRANSFERIR") ViewBag.msjTransfer = "";
                }
                else if (appServer.Split('|')[0] == "1")
                {
                    ViewBag.origen = appClient.Split('|')[1];
                    ViewBag.msjTransfer = appServer.Split('|')[1] + "¬0";
                }
                else if (appServer.Split('|')[0] == "2")
                {
                    if (appClient.Split('|')[1] == "TRANSFERIR")
                    {
                        ViewBag.msjTransfer = "Transferencia realizada correctamente¬1";
                    }

                    else
                    {
                        ViewBag.msjTransfer = "Registro actualizado correctamente¬1";
                        ViewBag.origen = "VISUALIZAR";
                    }
                }
                if (appClient.Split('|')[2] == "ADENDA")
                    ViewBag.origen = "ADENDA";
                else ViewBag.origen = appClient.Split('|')[1];

            }

            return View();
        }

        [HttpPost]
        public JsonResult ExportarRegistroUsuario()
        {
            ListResult result = new ListResult();

            result = ExportarDatos.RegistroUsuario((ModelSession.GetSession())[0].COD_UCUENTA);

            return Json(result);
        }

        [HttpPost]
        public JsonResult UpdateDatosSITD(CEntidad model)
        {
            try
            {
                model.OUTPUTPARAM01 = "";
                model.COD_UCUENTA = (ModelSession.GetSession())[0].COD_UCUENTA;
                CLogica log = new CLogica();
                ListResult result = new ListResult();

                log.RegGrabarSITD(model);

                result.AddResultado("El Registro se Guardo Correctamente", true);

                return Json(result);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }

            //return Json(log.UpdateDatosSITD(model));
        }

        [HttpGet]
        public ActionResult _Transferir(string tipo, string COD_DREFERENCIA, string DOC_REFERENCIA, string COD_AEXPEDIENTE_SITD, string COD_TRAMITE_SITD, string SUBTIPO,string obs)
        {
            CLogica log = new CLogica();
            ViewBag.Obs = obs;
            return PartialView(log.InitTransferir(tipo, COD_DREFERENCIA, DOC_REFERENCIA, COD_AEXPEDIENTE_SITD, COD_TRAMITE_SITD, SUBTIPO));
        }

        //09.08.2021 CARR
        [HttpPost]
        public JsonResult asociarPM(CEntidad dto)
        {
            string codCuenta = (ModelSession.GetSession())[0].COD_UCUENTA;
            CLogica log = new CLogica();
            /*CLogica exeBus = new CLogica();
            dto.ListPOA = vmRD.ListPOA;*/
            ListResult result = log.sincronizar(dto, codCuenta);
            return Json(result);
        }

        //29/11/2022 ENLACE AL FORMULARIO POA
        [HttpPost]
        public JsonResult asociarPOA(CEntidad dto)
        {
            string codCuenta = (ModelSession.GetSession())[0].COD_UCUENTA;
            Ent_BUSQUEDA oCampos = new Ent_BUSQUEDA();
            String codFormulario = "";
            oCampos.BusFormulario = "POA";
            oCampos.BusCriterio = "CODTH_RESOLUCION";
            oCampos.BusValor = dto.BusValor; 
            List<Ent_BUSQUEDA> lista = new List<Ent_BUSQUEDA>();
            Log_BUSQUEDA oCLogica = new Log_BUSQUEDA();
            lista = oCLogica.RegMostrarLista(oCampos);
           /* CLogica log = new CLogica();
            CLogica exeBus = new CLogica();
            dto.ListPOA = vmRD.ListPOA;
            ListResult result = log.sincronizar(dto, codCuenta);*/
            return Json(lista);
        }

        [HttpGet]
        public JsonResult ValidarExisteTH(string numTHabilitante)
        {//permite validar si existe titulo habilitante
            try
            {
                bool banderaExiste = false;
                Log_BUSQUEDA oCLogica = new Log_BUSQUEDA();
                List<Ent_BUSQUEDA> lista = new List<Ent_BUSQUEDA>();
                Ent_BUSQUEDA oCampos = new Ent_BUSQUEDA();
                oCampos.BusFormulario = "TITULO_HABILITANTE";
                oCampos.BusCriterio = "TH_NUMERO_IGUAL";
                oCampos.BusValor = numTHabilitante.Trim();
                lista = oCLogica.RegMostrarLista(oCampos);//
                if (lista.Count() > 1) throw new Exception("Existe dos registros iguales con el mismo número de título habilitante, reportar al administrador del sistema");
                if (lista.Count() == 1) banderaExiste = true;
                var thResult = (from l in lista
                                select new { NUMERO = l.NUMERO, CODIGO = l.CODIGO }).FirstOrDefault();
                return Json(new { success = true, existe = banderaExiste, item = thResult }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msj = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult SincronizarSITD_TH(string COD_AEXPEDIENTE_SITD, string COD_TRAMITE_SITD, string codTH, string numTH, string codRef)
        {
            CLogica log = new CLogica();
            string COD_UCUENTA = (ModelSession.GetSession())[0].COD_UCUENTA;
            return Json(log.SincronizarSITD_TH(Convert.ToInt32(COD_AEXPEDIENTE_SITD), Convert.ToInt32(COD_TRAMITE_SITD), codTH, numTH, COD_UCUENTA, codRef), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult SincronizarSITD_PLAN_MANEJO(string COD_AEXPEDIENTE_SITD, string COD_TRAMITE_SITD, string COD_DREFERENCIA, string CODIGO, string numPoa)
        {
            CLogica log = new CLogica();
            string COD_UCUENTA = (ModelSession.GetSession())[0].COD_UCUENTA;
            int num_Poa = (numPoa == "" || numPoa == null) ? 0 : Convert.ToInt32(numPoa);
            return Json(log.SincronizarSITD_PLAN_MANEJO(Convert.ToInt32(COD_AEXPEDIENTE_SITD), Convert.ToInt32(COD_TRAMITE_SITD), COD_DREFERENCIA, CODIGO, COD_UCUENTA, num_Poa), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult BExtraccionTransferir(string COD_TH, string COD_DREF, string COD_AEXP, string COD_TRAM, string cboPadre, string fecha, string obs)
        {
            CLogica log = new CLogica();
            string COD_UCUENTA = (ModelSession.GetSession())[0].COD_UCUENTA;
            var result = log.BExtraccionTransferir(COD_TH, COD_DREF, COD_AEXP, COD_TRAM, cboPadre, fecha, obs, COD_UCUENTA);
            return Json(result);
        }

        [HttpGet]
        public JsonResult AnularDocumentoTramite(string COD_AEXPEDIENTE_SITD, string COD_TRAMITE_SITD, string obs, string codRef = "")
        {
            CLogica log = new CLogica();
            string COD_UCUENTA = (ModelSession.GetSession())[0].COD_UCUENTA;
            var result = log.AnularDocumentoTramite(COD_AEXPEDIENTE_SITD, COD_TRAMITE_SITD, obs, COD_UCUENTA, codRef);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        //Obtiene codigo de titulo habilitante
        [HttpGet]
        public JsonResult ValidarIrPM(string COD_AEXPEDIENTE_SITD, string COD_TRAMITE_SITD)
        {
            try
            {
                CEntidad oParamsDatSigo = new CEntidad() { COD_AEXPEDIENTE_SITD = Convert.ToInt32(COD_AEXPEDIENTE_SITD), COD_TRAMITE_SITD = Convert.ToInt32(COD_TRAMITE_SITD) };
                CLogica log = new CLogica();
                oParamsDatSigo = log.RegMostrarListaItems(oParamsDatSigo);
                return Json(new { success = true, msj = "", COD_TH = oParamsDatSigo.COD_THABILITANTE, numPoa = oParamsDatSigo.NUM_POA }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return Json(new { success = false, msj = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public ActionResult DownloadCenso(string coddoc,string file = "PoaMaderable_Censo_v2.xlsx")
        {
            //dto.ListMadeCENSO = objVM2.ListMadeCENSO;
            string codCuenta = (ModelSession.GetSession())[0].COD_UCUENTA;
            Ent_BUSQUEDA oCampos = new Ent_BUSQUEDA();
            String codFormulario = "";
            oCampos.BusFormulario = "POA";
            oCampos.BusCriterio = "CODDOC_POA_CENSO";
            oCampos.BusValor = coddoc;
            List<Ent_BUSQUEDA> lista = new List<Ent_BUSQUEDA>();
            Log_BUSQUEDA oCLogica = new Log_BUSQUEDA();
            lista = oCLogica.RegMostrarLista(oCampos);
            object result = new object();
            result = Reportes.THabilitante.ReportePOA.DescargaExcelCENSO(lista);

            return Json(result);
        }
        [HttpGet]
        [DeleteFileAttribute]
        public ActionResult Download(string file = "PoaMaderable_Censo_v2.xlsx")
        {
            string fullPath = Path.Combine(Server.MapPath("~/Archivos/Plantilla"), file);
            return File(fullPath, "application/vnd.ms-excel", file);
        }
    }
}