using CapaEntidad.ViewModel;
using SIGOFCv3.Areas.Supervision.Models.ManInformeMedidaCorrectiva;
using SIGOFCv3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CEntVM = CapaEntidad.ViewModel.VM_InformeMedidaCorrectiva;
using CEntidadIMC = CapaEntidad.DOC.Ent_IMEDIDA;
using CLogica = CapaLogica.DOC.Log_IMEDIDA;
using CapaEntidad.DOC;
using SIGOFCv3.Models.DataTables;
using CapaEntidad.ViewModel.General;
using SIGOFCv3.Helper;

namespace SIGOFCv3.Areas.Supervision.Controllers
{
    public class ManInformeMedidaCorrectivaController : Controller
    {
        public static CEntVM vmIMC = new CEntVM();

        public ActionResult Index(string _alertaIncial = "")
        {
            CapaLogica.DOC.Log_BUSQUEDA logB = new CapaLogica.DOC.Log_BUSQUEDA();

            ViewBag.Formulario = "IMEDIDA";
            ViewBag.TituloFormulario = "Informe Mandatos y Medidas Correctivas";
            ViewBag.AlertaInicial = _alertaIncial;
            ViewBag.ddlListOpciones = logB.RegMostComboIndividual_v3("IMEDIDA", "");

            //obtenemos el rol sobre el formulario
            VM_Menu_Rol mr = HelperSigo.GetRol("MODULO SUPERVISION", "Informe Medidas Correctivas y Mandatos");
            ViewBag.CodRol = mr.NCODROL;
            ViewBag.VAliasRol = mr.VALIAS;

            return View();
        }

        [HttpPost]
        public JsonResult ExportarRegistroUsuario()
        {
            ListResult result = new ListResult();

            result = ExportarDatos.RegistroUsuario((ModelSession.GetSession())[0].COD_UCUENTA);

            return Json(result);
        }

        public ActionResult AddEdit(string asCodInfMedidaCorrectiva = "", string asCodTipoIMC = "", string asTextTipoIMC = "")
        {
            try
            {
                CEntidadIMC entIMC = new CEntidadIMC();
                CLogica logIMC = new CLogica();

                vmIMC.lblTituloCabecera = "Informe Mandatos y Medidas Correctivas";
                vmIMC.vmControlCalidad = new VM_ControlCalidad_2();
                entIMC.BusFormulario = "IMEDIDA";
                entIMC.COD_UCUENTA = (ModelSession.GetSession())[0].COD_UCUENTA;

                initBusquedaModal();

                vmIMC.ddlItemPresentaFechaPlazo = new List<VM_Cbo>
                {
                    new VM_Cbo { Value = "No", Text = "No" },
                    new VM_Cbo { Value = "Si", Text = "Si" }
                };

                vmIMC.ddlItemInformeCompleto = new List<VM_Cbo>
                {
                    new VM_Cbo { Value = "No", Text = "No" },
                    new VM_Cbo { Value = "Si", Text = "Si" }
                };

                vmIMC.ddlItemCuentaFirmaRegente = new List<VM_Cbo>
                {
                    new VM_Cbo { Value = "No", Text = "No" },
                    new VM_Cbo { Value = "Si", Text = "Si" }
                };

                vmIMC.ddlItemReponeDentro = new List<VM_Cbo>
                {
                    new VM_Cbo { Value = "No", Text = "No" },
                    new VM_Cbo { Value = "Si", Text = "Si" }
                };

                vmIMC.ddlItemReponeFuera = new List<VM_Cbo>
                {
                    new VM_Cbo { Value = "No", Text = "No" },
                    new VM_Cbo { Value = "Si", Text = "Si" }
                };

                vmIMC.ddlItemCumpleCantidadRepone = new List<VM_Cbo>
                {
                    new VM_Cbo { Value = "No", Text = "No" },
                    new VM_Cbo { Value = "Si", Text = "Si" }
                };

                vmIMC.ddlItemCumpleMCorrectiva = new List<VM_Cbo>
                {
                    new VM_Cbo { Value = "No", Text = "No" },
                    new VM_Cbo { Value = "Si", Text = "Si" }
                };

                vmIMC.ddlItemRemitirDFFFS = new List<VM_Cbo>
                {
                    new VM_Cbo { Value = "No", Text = "No" },
                    new VM_Cbo { Value = "Si", Text = "Si" }
                };

                entIMC = logIMC.RegMostCombo(entIMC);
                ViewBag.ddlItemEspecieRef = entIMC.ListMComboEspecies.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION });

                ViewBag.ddlItemZonaEspecieRef = new List<VM_Cbo>
                {
                    new VM_Cbo { Value = "00S", Text = "Seleccionar" },
                    new VM_Cbo { Value = "17S", Text = "17S" },
                    new VM_Cbo { Value = "18S", Text = "18S" },
                    new VM_Cbo { Value = "19S", Text = "19S" },
                };

                ViewBag.ddlItemEstadoEspecieRef = new List<VM_Cbo>
                {
                    new VM_Cbo { Value = "0", Text = "Seleccionar" },
                    new VM_Cbo { Value = "BUENO", Text = "BUENO" },
                    new VM_Cbo { Value = "REGULAR", Text = "REGULAR" },
                    new VM_Cbo { Value = "MALO", Text = "MALO" },
                };

                ViewBag.ddlItemZonaVerticeRef = new List<VM_Cbo>
                {
                    new VM_Cbo { Value = "00S", Text = "Seleccionar" },
                    new VM_Cbo { Value = "17S", Text = "17S" },
                    new VM_Cbo { Value = "18S", Text = "18S" },
                    new VM_Cbo { Value = "19S", Text = "19S" },
                };

                //obtenemos el rol sobre el formulario
                VM_Menu_Rol mr = HelperSigo.GetRol("MODULO SUPERVISION", "Informe Medidas Correctivas y Mandatos");
                ViewBag.CodRol = mr.NCODROL;
                ViewBag.VAliasRol = mr.VALIAS;

                if (String.IsNullOrEmpty(asCodInfMedidaCorrectiva))
                {
                    vmIMC.lblTituloEstado = "Nuevo Registro";
                    vmIMC.vmControlCalidad.ddlIndicadorId = "0000000";
                    vmIMC.hdfItemTInformeCodigo = asCodTipoIMC;
                    vmIMC.txtItemTInforme = asTextTipoIMC;

                    RegistroLimpiar();

                    vmIMC.RegEstado = 1;
                }
                else
                {
                    RegistroLimpiar();

                    entIMC = logIMC.RegMostrarListaItems(new CEntidadIMC() { COD_INFORME = asCodInfMedidaCorrectiva });
                    
                    vmIMC.lblTituloEstado = "Modificando Registro";
                    vmIMC.hdfCodInfMedidaCorrectiva = asCodInfMedidaCorrectiva;
                    vmIMC.hdfItemTInformeCodigo = entIMC.COD_ITIPO;
                    vmIMC.txtItemTInforme = entIMC.ITIPO;

                    vmIMC.txtItemNumero = entIMC.NUMERO;
                    vmIMC.txtItemMotivo = entIMC.IMOTIVO;
                    vmIMC.hdfItemDirectorCodigo = entIMC.COD_DIRECTOR;
                    vmIMC.txtItemDirector = entIMC.DIRECTOR;

                    if (entIMC.COD_ITIPO == "0000011" || entIMC.COD_ITIPO == "0000016")
                    {
                        vmIMC.ddlItemPresentaFechaPlazoId = (Boolean)entIMC.CUMPLE_PLAZO == true ? "Si" : "No";
                        vmIMC.txtItemFechaPresentaTitular = entIMC.FECHA_RECEPCION.ToString();
                        vmIMC.ddlItemInformeCompletoId = (Boolean)entIMC.INFORME_COMPLETO == true ? "Si" : "No";
                        vmIMC.ddlItemCuentaFirmaRegenteId = (Boolean)entIMC.FIRMA_REGENTE == true ? "Si" : "No";
                        vmIMC.txtItemConclusion = entIMC.CONCLUSION;
                    }
                    else
                    {
                        vmIMC.txtItemFechaFin = entIMC.FECHA_VERIFICA_FIN.ToString();
                        vmIMC.txtItemFechaIni = entIMC.FECHA_VERIFICA_INICIO.ToString();                      
                        vmIMC.txtItemFechaInstalacion = entIMC.FECHA_IMPLEMENTACION.ToString();
                        vmIMC.ddlItemReponeDentroId = (Boolean)entIMC.REPOSICION_DENTRO == true ? "Si" : "No";
                        vmIMC.ddlItemReponeFueraId = (Boolean)entIMC.REPOSICION_FUERA == true ? "Si" : "No";
                        vmIMC.ddlItemCumpleCantidadReponeId = (Boolean)entIMC.CUMPLE_CANTIDAD == true ? "Si" : "No";
                        vmIMC.ddlItemCumpleMCorrectivaId = (Boolean)entIMC.CUMPLE_MEDIDA == true ? "Si" : "No";
                    }

                    vmIMC.ddlItemRemitirDFFFSId = (Boolean)entIMC.REMITIR_DFFFS == true ? "Si" : "No";
                    vmIMC.txtItemRecomendacion = entIMC.RECOMENDACION;

                    vmIMC.vmControlCalidad.ddlIndicadorId = entIMC.COD_ESTADO_DOC;
                    vmIMC.vmControlCalidad.txtUsuarioRegistro = entIMC.USUARIO_REGISTRO;
                    vmIMC.vmControlCalidad.txtUsuarioControl = entIMC.USUARIO_CONTROL;
                    vmIMC.vmControlCalidad.chkObsSubsanada = (Boolean)entIMC.OBSERV_SUBSANAR;
                    vmIMC.vmControlCalidad.txtControlCalidadObservaciones = entIMC.OBSERVACIONES_CONTROL.ToString();

                    vmIMC.tbResponsable = entIMC.ListProfResponsable;
                    vmIMC.tbExpediente = entIMC.ListExpediente;
                    vmIMC.tbEspecie = entIMC.ListEspecieReforestada;
                    vmIMC.tbVertice = entIMC.ListVerticeReforestada;
                    vmIMC.tbMedidaAsociada = entIMC.ListMedidaAsociada;

                    vmIMC.RegEstado = 0;
                    //Pasamos el Rol del usuario
                    vmIMC.vmControlCalidad.VALIAS_ROL = mr.VALIAS;
                }

                return View(vmIMC);
            }
            catch (Exception)
            {
                return RedirectToAction("ErrorC", "Index");
            }
        }

        public void RegistroLimpiar()
        {
            vmIMC.hdfCodInfMedidaCorrectiva = "";
            vmIMC.txtItemNumero = "";
            vmIMC.txtItemMotivo = "";
            vmIMC.hdfItemDirectorCodigo = "";
            vmIMC.txtItemDirector = "";
            vmIMC.txtItemFechaIni = "";
            vmIMC.txtItemFechaFin = "";
            vmIMC.ddlItemPresentaFechaPlazoId = "No";
            vmIMC.txtItemFechaPresentaTitular = "";
            vmIMC.ddlItemInformeCompletoId = "No";
            vmIMC.ddlItemCuentaFirmaRegenteId = "No";
            vmIMC.txtItemFechaInstalacion = "";
            vmIMC.ddlItemReponeDentroId = "No";
            vmIMC.ddlItemReponeFueraId = "No";
            vmIMC.ddlItemCumpleCantidadReponeId = "No";
            vmIMC.txtItemConclusion = "";
            vmIMC.ddlItemCumpleMCorrectivaId = "No";
            vmIMC.ddlItemRemitirDFFFSId = "No";
            vmIMC.txtItemRecomendacion = "";

            vmIMC.tbResponsable = new List<Ent_IMEDIDA_RESPONSABLE>();
            vmIMC.tbExpediente = new List<Ent_IMEDIDA_EXPEDIENTE>();
            vmIMC.tbMedida = new List<Ent_IMEDIDA_EXP_MEDIDA>();
            vmIMC.tbEspecie = new List<Ent_IMEDIDA_ESPECIE>();
            vmIMC.tbVertice = new List<Ent_IMEDIDA_VERTICE>();
            vmIMC.tbEliTABLA = new List<Ent_IMEDIDA_EliTABLA>();
            vmIMC.tbMedidaAsociada = new List<Ent_IMEDIDA_EXP_MEDIDA>();
        }

        public void initBusquedaModal()
        {
            List<Ent_SBusqueda> listCombo = new List<Ent_SBusqueda>();
            vmIMC.sBusqueda = new List<Ent_SBusqueda>();
            Ent_SBusqueda Combo;

            Combo = new Ent_SBusqueda();
            Combo.Value = "LISTA_NUM_RESOLUCION";
            Combo.Text = "N° Resolución";
            listCombo.Add(Combo);

            Combo = new Ent_SBusqueda();
            Combo.Value = "LISTA_NUM_EXPEDIENTE";
            Combo.Text = "N° Expediente";
            listCombo.Add(Combo);

            vmIMC.txtTituloModal = "Buscar Registro";

            vmIMC.sBusqueda = listCombo;
        }

        [HttpPost]
        public JsonResult Grabar(CEntVM obj)
        {
            try
            {
                CEntidadIMC entIMC = new CEntidadIMC();
                CLogica logIMC = new CLogica();

                string codCuenta = (ModelSession.GetSession())[0].COD_UCUENTA;
                ListResult result = new ListResult();
                string OUTPUTPARAM = null;

                if (obj.tbResponsable == null) result.AddResultado("Ingrese el profesional responsable de la evaluación/verificación", false);

                if (obj.tbExpediente == null)
                {
                    if (obj.hdfItemTInformeCodigo == "0000016" || obj.hdfItemTInformeCodigo == "0000017")
                        result.AddResultado("Es necesario ingresar el documento que dispuso los mandatos", false);
                    else result.AddResultado("Es necesario ingresar el documento que dispuso las medidas correctivas", false);
                }

                entIMC.COD_UCUENTA = codCuenta;
                entIMC.COD_ITIPO = obj.hdfItemTInformeCodigo;
                entIMC.IMOTIVO = obj.txtItemMotivo;
                entIMC.COD_DIRECTOR = obj.hdfItemDirectorCodigo;
                entIMC.NUMERO = obj.txtItemNumero;

                if (entIMC.COD_ITIPO == "0000011" || entIMC.COD_ITIPO == "0000016")
                {
                    entIMC.CUMPLE_PLAZO = (obj.ddlItemPresentaFechaPlazoId == "Si") ? true : false;
                    entIMC.FECHA_RECEPCION = obj.txtItemFechaPresentaTitular;
                    entIMC.INFORME_COMPLETO = (obj.ddlItemInformeCompletoId == "Si") ? true : false;
                    entIMC.FIRMA_REGENTE = (obj.ddlItemCuentaFirmaRegenteId == "Si") ? true : false;
                    entIMC.CONCLUSION = obj.txtItemConclusion;
                }
                else
                {
                    entIMC.FECHA_VERIFICA_INICIO = obj.txtItemFechaIni;
                    entIMC.FECHA_VERIFICA_FIN = obj.txtItemFechaFin;
                    entIMC.FECHA_IMPLEMENTACION = obj.txtItemFechaInstalacion;
                    entIMC.REPOSICION_DENTRO = (obj.ddlItemReponeDentroId == "Si") ? true : false;
                    entIMC.REPOSICION_FUERA = (obj.ddlItemReponeFueraId == "Si") ? true : false;
                    entIMC.CUMPLE_CANTIDAD = (obj.ddlItemCumpleCantidadReponeId == "Si") ? true : false;
                    entIMC.CUMPLE_MEDIDA = (obj.ddlItemCumpleMCorrectivaId == "Si") ? true : false;
                }

                entIMC.REMITIR_DFFFS = (obj.ddlItemRemitirDFFFSId == "Si") ? true : false;
                entIMC.RECOMENDACION = obj.txtItemRecomendacion;

                entIMC.ListProfResponsable = obj.tbResponsable;
                entIMC.ListExpediente = obj.tbExpediente;
                entIMC.ListEspecieReforestada = obj.tbEspecie;
                entIMC.ListVerticeReforestada = obj.tbVertice;   
                entIMC.ListMedidaAsociada = obj.tbMedidaAsociada;

                if (obj.tbElimResponsable != null)
                {
                    for (int j = 0; j < obj.tbElimResponsable.Count; j++)
                    {
                        var ob = obj.tbElimResponsable[j];
                        vmIMC.tbEliTABLA.Add(ob);
                    }
                }

                if (obj.tbElimExpediente != null)
                {
                    for (int j = 0; j < obj.tbElimExpediente.Count; j++)
                    {
                        var ob = obj.tbElimExpediente[j];
                        vmIMC.tbEliTABLA.Add(ob);
                    }
                }

                if (obj.tbElimEspecie != null)
                {
                    for (int j = 0; j < obj.tbElimEspecie.Count; j++)
                    {
                        var ob = obj.tbElimEspecie[j];
                        vmIMC.tbEliTABLA.Add(ob);
                    }
                }

                if (obj.tbElimVertice != null)
                {
                    for (int j = 0; j < obj.tbElimVertice.Count; j++)
                    {
                        var ob = obj.tbElimVertice[j];
                        vmIMC.tbEliTABLA.Add(ob);
                    }
                }

                entIMC.ListEliTABLA = vmIMC.tbEliTABLA;

                entIMC.COD_ESTADO_DOC = obj.vmControlCalidad.ddlIndicadorId;
                entIMC.OBSERVACIONES_CONTROL = obj.vmControlCalidad.txtControlCalidadObservaciones;
                entIMC.OBSERV_SUBSANAR = obj.vmControlCalidad.chkObsSubsanada;

                entIMC.COD_INFORME = "";
                entIMC.OUTPUTPARAM01 = "";
                entIMC.RegEstado = obj.RegEstado;

                if (obj.RegEstado == 0) //Modificar
                {
                    entIMC.COD_INFORME = obj.hdfCodInfMedidaCorrectiva;
                }

                OUTPUTPARAM = logIMC.RegGrabar(entIMC);
                RegistroLimpiar();
                result.AddResultado("El Registro se Guardo Correctamente", true);

                return Json(result);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }

        }

        #region "SHARED"
        [HttpGet]
        public JsonResult ConsultaModal(DataTableRequest request = null)
        {

            CLogica exeBus = new CLogica();
            CEntidadIMC paramsBus = new CEntidadIMC();
            CEntidadIMC result;
            int page = request.Start == 0 ? 1 : (request.Start / request.Length) + 1;

            paramsBus.BusFormulario = request.CustomSearchForm;
            paramsBus.BusCriterio = request.CustomSearchType;
            paramsBus.BusValor = request.CustomSearchValue;
            paramsBus.v_pagesize = request.Length;
            paramsBus.currentpage = page;

            result = exeBus.RegMostrarExpediente_BuscarDatos(paramsBus);

            var jsonResult = Json(new
            {
                data = result.ListBusqueda.ToArray(),
                draw = request.Draw,
                recordsTotal = result.v_row_index,
                recordsFiltered = result.v_row_index,
                error = ""
            }, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        [HttpPost]
        public JsonResult CargarMedidas(Ent_IMEDIDA_EXP_MEDIDA obj)
        {
            try
            {
                CLogica exeBus = new CLogica();
                CEntidadIMC paramsBus = new CEntidadIMC();

                paramsBus.ListMedida = exeBus.RegListMedida(obj);

                return Json(new { success = true, result = paramsBus.ListMedida });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, result = ex.Message });
            }
        }

        [HttpPost]
        public JsonResult ImportarDatosEspecie(string hdfTipo)
        {
            List<Ent_IMEDIDA_ESPECIE> olResult = new List<Ent_IMEDIDA_ESPECIE>();

            try
            {
                if (Request != null)
                {
                    olResult = ImportarDatos.Especies_Reforestadas(Request);
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msj = ex.Message });
            }

            return Json(new { success = true, msj = "", data = olResult.ToArray() });
        }

        [HttpPost]
        public JsonResult ImportarDatosVertice(string hdfTipo)
        {
            List<Ent_IMEDIDA_VERTICE> olResult = new List<Ent_IMEDIDA_VERTICE>();

            try
            {
                if (Request != null)
                {
                    olResult = ImportarDatos.Vertices_Reforestadas(Request);
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msj = ex.Message });
            }

            return Json(new { success = true, msj = "", data = olResult.ToArray() });
        }
        #endregion
    }
}