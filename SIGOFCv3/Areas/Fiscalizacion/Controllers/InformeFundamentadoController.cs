using CapaEntidad.DOC;
using CapaEntidad.ViewModel;
using SIGOFCv3.Areas.Fiscalizacion.Models.InformeFundamentado;
using SIGOFCv3.Models;
using SIGOFCv3.Models.DataTables;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CEntVM = CapaEntidad.ViewModel.VM_InformeFundamentado;
using CEntidadIF = CapaEntidad.DOC.Ent_INFFUN;
using CLogica = CapaLogica.DOC.Log_INFFUN;
using System.Linq;
using CapaEntidad.ViewModel.General;
using SIGOFCv3.Helper;

namespace SIGOFCv3.Areas.Fiscalizacion.Controllers
{
    public class InformeFundamentadoController : Controller
    {
        public static CEntVM vmIF= new CEntVM();

        public ActionResult Index(string _alertaIncial = "")
        {
            ViewBag.Formulario = "INFORME_FUNDAMENTADO";
            ViewBag.TituloFormulario = "Informe Fundamentado";
            ViewBag.AlertaInicial = _alertaIncial;
            //obtenemos el rol sobre el formulario
            VM_Menu_Rol mr = HelperSigo.GetRol("MODULO FISCALIZACION", "Informe Fundamentado");
            ViewBag.CodRol = mr.NCODROL;
            ViewBag.VAliasRol = mr.VALIAS;
            return View();
        }

        public ActionResult AddEdit(string asCodInfFundamentado = "")
        {
            try
            {
                CEntidadIF entIF = new CEntidadIF();
                CLogica logIF = new CLogica();

                vmIF.lblTituloCabecera = "Informe Fundamentado";
                vmIF.vmControlCalidad = new VM_ControlCalidad_2();
                entIF.BusFormulario = "GENERAL";
                entIF.COD_UCUENTA = (ModelSession.GetSession())[0].COD_UCUENTA;
                entIF = logIF.RegMostCombo(entIF);
                vmIF.ddlOd = entIF.ListMComboOD.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION });
                entIF = logIF.RegMostrarComboEntidad(entIF);
                vmIF.ddlEntidad = entIF.ListarEntidades.Select(i => new VM_Cbo { Value = i.COD_SENTIDAD, Text = i.DESCRIPCION_ENTIDAD });
                vmIF.ddlEntidadId = entIF.ListarEntidades.ElementAt(0).COD_SENTIDAD;
                entIF.COD_INFFUN_ENTIDADES = vmIF.ddlEntidadId;
                entIF = logIF.RegMostrarComboSubEntidad(entIF);
                vmIF.ddlSubEntidad = entIF.ListarEntidades.Select(i => new VM_Cbo { Value = i.COD_SENTIDAD, Text = i.DESCRIPCION_SUBENTIDAD });
                vmIF.ddlSubEntidadId = entIF.ListarEntidades.ElementAt(0).COD_SENTIDAD;
                this.initBusquedaModal();

                if (String.IsNullOrEmpty(asCodInfFundamentado))
                {      
                    vmIF.lblTituloEstado = "Nuevo Registro";    
                    vmIF.vmControlCalidad.ddlIndicadorId = "0000000";
                    vmIF.hdfCodTipoInfFundamentado = "0000049";
                    vmIF.txtTipoInfFundamentado = "Informes fundamentados - Informes fundamentados";
                    vmIF.ddlOdId = null;
                    vmIF.txtFechaFundamentado = null;
                    vmIF.txtNumInfFundamentado = null;
                    vmIF.txtConclusiones = null;
                    vmIF.txtObservaciones = null;
                    vmIF.listaProfesionales = new List<CEntidadIF>();
                    vmIF.tbInforme = new List<CEntidadIF>();  
                    vmIF.listaEntidades = new List<CEntidadIF>();
                    vmIF.RegEstado = 1;
                }
                else
                {
                    entIF = logIF.RegMostrarINFFUNItem(new CEntidadIF() { COD_INFFUN = asCodInfFundamentado });
                    vmIF.lblTituloEstado = "Modificando Registro";
                    vmIF.hdfCodInfFundamentado = asCodInfFundamentado;
                    vmIF.vmControlCalidad.ddlIndicadorId = entIF.COD_ESTADO_DOC;
                    vmIF.vmControlCalidad.txtUsuarioRegistro = entIF.USUARIO_REGISTRO;
                    vmIF.vmControlCalidad.txtUsuarioControl = entIF.USUARIO_CONTROL;
                    vmIF.vmControlCalidad.chkObsSubsanada = (bool)entIF.OBSERV_SUBSANAR;
                    vmIF.vmControlCalidad.txtControlCalidadObservaciones = entIF.OBSERVACIONES_CONTROL.ToString();
                    vmIF.ddlOdId = entIF.COD_OD_REGISTRO;
                    vmIF.hdfCodTipoInfFundamentado = entIF.COD_FCTIPO;
                    vmIF.txtTipoInfFundamentado = entIF.TIPO_FISCALIZA;
                    vmIF.txtFechaFundamentado = entIF.FECHA_EMISION.ToString();
                    vmIF.txtNumInfFundamentado= entIF.NUMERO_INFORME;
                    vmIF.listaProfesionales = entIF.ListProfesionales;
                    vmIF.tbInforme = entIF.ListInformes;
                    vmIF.listaEntidades = entIF.ListarEntidades;
                    vmIF.txtConclusiones = entIF.CONCLUSIONES;
                    vmIF.txtObservaciones = entIF.DESCRIPCION;
                    vmIF.tbEliTABLA = new List<CEntidadIF>();
                    vmIF.RegEstado = 0;
                }
                //obtenemos el rol sobre el formulario
                VM_Menu_Rol mr = HelperSigo.GetRol("MODULO FISCALIZACION", "Informe Fundamentado");
                ViewBag.CodRol = mr.NCODROL;
                ViewBag.VAliasRol = mr.VALIAS;
                //Pasamos el Rol del usuario
                vmIF.vmControlCalidad.VALIAS_ROL = mr.VALIAS;
                return View(vmIF);
            }
            catch (Exception)
            {
                return RedirectToAction("ErrorC", "Index");
            }

        }

        [HttpPost]
        public JsonResult Grabar(CEntVM obj)
        {
            try
            {
                string codCuenta = (ModelSession.GetSession())[0].COD_UCUENTA;
                ListResult result = new ListResult();
                CEntidadIF entIF = new CEntidadIF();
                CLogica logIF = new CLogica();

                entIF.COD_FCTIPO = obj.hdfCodTipoInfFundamentado;
                entIF.COD_UCUENTA = codCuenta;
                entIF.COD_PERSONA = "";
                entIF.COD_INFFUN = obj.hdfCodInfFundamentado;
                entIF.NUMERO_INFORME = obj.txtNumInfFundamentado;
                entIF.FECHA_EMISION = obj.txtFechaFundamentado;
                //entIF.FECHA_CREACION = "";
                entIF.COD_OD_REGISTRO = obj.ddlOdId;
                entIF.COD_ESTADO_DOC = obj.vmControlCalidad.ddlIndicadorId;
                entIF.OBSERVACIONES_CONTROL = obj.vmControlCalidad.txtControlCalidadObservaciones;
                entIF.OBSERV_SUBSANAR = obj.vmControlCalidad.chkObsSubsanada;
                entIF.OUTPUTPARAM01 = "";
                entIF.RegEstado = obj.RegEstado;
                entIF.CONCLUSIONES = obj.txtConclusiones;
                entIF.DESCRIPCION = obj.txtObservaciones;
                entIF.ListInformes = obj.tbInforme;
                entIF.ListarEntidades = obj.listaEntidades;

                if (obj.tbEliTABLA != null) {

                    for (int j = 0; j < obj.tbEliTABLA.Count; j++)
                    {
                        var ob = obj.tbEliTABLA[j];
                        vmIF.tbEliTABLA.Add(ob);
                    }
                } 

                entIF.ListEliTABLA = vmIF.tbEliTABLA;
                entIF.ListProfesionales = obj.listaProfesionales;

                var estado_final = logIF.RegInformeFundamentado_Grabar(entIF);

                if (estado_final != "0" && estado_final != "1") result.AddResultado("El Registro se Guardo Correctamente", true);
                else result.AddResultado("Error en la información", false);

                return Json(result);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }

        }

        public void initBusquedaModal()
        {
            List<Ent_SBusqueda> listCombo = new List<Ent_SBusqueda>();
            vmIF.sBusqueda = new List<Ent_SBusqueda>();
            Ent_SBusqueda Combo;

            Combo = new Ent_SBusqueda();
            Combo.Value = "INF_NUMERO";
            Combo.Text = "Informe Supervisión";
            listCombo.Add(Combo);

            Combo = new Ent_SBusqueda();
            Combo.Value = "EXPADM_NUMERO";
            Combo.Text = "Nro. Expediente";
            listCombo.Add(Combo);

            vmIF.txtTituloModal = "Nuevo Registro";

            vmIF.sBusqueda = listCombo;
        }

        [HttpPost]
        public JsonResult ExportarRegistroUsuario()
        {
            ListResult result = new ListResult();

            result = ExportarDatos.RegistroUsuario((ModelSession.GetSession())[0].COD_UCUENTA);

            return Json(result);
        }

        [HttpPost]
        public JsonResult FiltrarSubEntidad(string asCodEntidad)
        {
            try
            {
                CEntidadIF entIF = new CEntidadIF();
                CLogica logIF = new CLogica();
                vmIF.ddlEntidadId = asCodEntidad;
                entIF.COD_INFFUN_ENTIDADES = vmIF.ddlEntidadId;
                entIF = logIF.RegMostrarComboSubEntidad(entIF);
                vmIF.ddlSubEntidad = entIF.ListarEntidades.Select(i => new VM_Cbo { Value = i.COD_SENTIDAD, Text = i.DESCRIPCION_SUBENTIDAD });
                vmIF.ddlSubEntidadId = entIF.ListarEntidades.ElementAt(0).COD_SENTIDAD;
                return Json(new { success = true, result = vmIF.ddlSubEntidad });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, result = ex.Message });
            }
        }

        [HttpPost]
        public JsonResult agregarEntidades(CEntidadIF _dto)
        {
            try
            {
                CEntidadIF oCentidad = new CEntidadIF();
                int band = 0;
                oCentidad.COD_SENTIDAD = _dto.COD_SENTIDAD;
                oCentidad.DESCRIPCION_ENTIDAD = _dto.DESCRIPCION_ENTIDAD;
                oCentidad.DESCRIPCION_SUBENTIDAD = _dto.DESCRIPCION_SUBENTIDAD;
                oCentidad.RegEstado = 1;

                if (vmIF.listaEntidades.Count > 0)
                {
                    for (int j = 0; j < vmIF.listaEntidades.Count; j++)
                    {
                        var obj = vmIF.listaEntidades[j];
                        if (obj.COD_SENTIDAD == oCentidad.COD_SENTIDAD)
                        {
                            band = 1;
                        }
                    }
                    if (band == 0)
                    {
                        vmIF.listaEntidades.Add(oCentidad);
                    }
                }
                else
                    vmIF.listaEntidades.Add(oCentidad);

                bool valor = (band == 0) ? true : false;

                return Json(new { success = true, result = vmIF.listaEntidades, value = valor });

            }
            catch (Exception ex)
            {
                return Json(new { success = false, result = ex.Message });
            }
        }

        [HttpPost]
        public JsonResult quitarEntidad(CEntidadIF _dto)
        {
            try
            {
                for (int j = 0; j < vmIF.listaEntidades.Count; j++)
                {
                    var obj = vmIF.listaEntidades[j];
                    if (obj.COD_SENTIDAD == _dto.COD_SENTIDAD)
                    {
                        vmIF.listaEntidades.RemoveAt(j);

                        if (vmIF.RegEstado == 0 && obj.RegEstado == 0)
                        {
                            CEntidadIF oCampos = new CEntidadIF();
                            oCampos.EliTABLA = "INFFUN_DET_ENTIDADES";
                            oCampos.EliVALOR01 = obj.COD_SENTIDAD;
                            vmIF.tbEliTABLA.Add(oCampos);
                        }
                    }
                }

                return Json(new { success = true, msj = "El elemento ha sido eliminado correctamente" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msj = ex.Message });
            }
        }

        [HttpPost]
        public JsonResult agregarProfesionales(CEntidadIF _dto)
        {
            try
            {
                CEntidadIF oCentidad = new CEntidadIF();
                int band = 0;
                oCentidad.COD_PERSONA = _dto.COD_PERSONA;
                oCentidad.NUMERO = _dto.NUMERO;
                oCentidad.APELLIDOS_NOMBRES = _dto.APELLIDOS_NOMBRES;
                oCentidad.TIPO = _dto.TIPO;
                oCentidad.RegEstado = 1;

                if (vmIF.listaProfesionales.Count > 0)
                {
                    for (int j = 0; j < vmIF.listaProfesionales.Count; j++)
                    {
                        var obj = vmIF.listaProfesionales[j];
                        if (obj.COD_PERSONA == oCentidad.COD_PERSONA)
                        {
                            band = 1;
                        }
                    }
                    if (band == 0)
                    {
                        vmIF.listaProfesionales.Add(oCentidad);
                    }
                }
                else
                    vmIF.listaProfesionales.Add(oCentidad);

                bool valor = (band == 0) ? true : false;

                return Json(new { success = true, result = vmIF.listaProfesionales, value = valor });

            }
            catch (Exception ex)
            {
                return Json(new { success = false, result = ex.Message });
            }
        }

        [HttpPost]
        public JsonResult quitarProfesional(CEntidadIF _dto)
        {
            try
            {
                for (int j = 0; j < vmIF.listaProfesionales.Count; j++)
                {
                    var obj = vmIF.listaProfesionales[j];
                    if (obj.COD_PERSONA == _dto.COD_PERSONA)
                    {
                        vmIF.listaProfesionales.RemoveAt(j);

                        if (vmIF.RegEstado == 0 && obj.RegEstado == 0)
                        {
                            CEntidadIF oCampos = new CEntidadIF();
                            oCampos.EliTABLA = "INFFUN_DET_PROFESIONAL";
                            oCampos.EliVALOR01 = obj.COD_PERSONA;
                            vmIF.tbEliTABLA.Add(oCampos);
                        }
                    }
                }

                return Json(new { success = true, msj = "El elemento ha sido eliminado correctamente" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msj = ex.Message });
            }
        }

        [HttpPost]
        public JsonResult quitarAll(string opc)
        {
            try
            {
                bool valor = false;
                string resultado = "No se eliminaron elementos";

                if (opc == "PROFESIONAL") {
                    if (vmIF.listaProfesionales.Count > 0)
                    {
                        for (int j = 0; j < vmIF.listaProfesionales.Count; j++)
                        {
                            var obj = vmIF.listaProfesionales[j];
                            if (vmIF.RegEstado == 0 && obj.RegEstado == 0)
                            {
                                CEntidadIF oCampos = new CEntidadIF();
                                oCampos.EliTABLA = "INFFUN_DET_PROFESIONAL";
                                oCampos.EliVALOR01 = obj.COD_PERSONA;
                                vmIF.tbEliTABLA.Add(oCampos);
                            }          
                        }
                    }

                    vmIF.listaProfesionales.Clear();
                    valor = true;
                    resultado = "Elementos eliminados satisfactoriamente";
                }

                return Json(new { success = valor, msj = resultado });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msj = ex.Message });
            }
        }

        #region "SHARED"
        [HttpGet]
        public JsonResult ConsultaModal(DataTableRequest request = null)
        {

            CLogica exeBus = new CLogica();
            CEntidadIF paramsBus = new CEntidadIF();
            CEntidadIF result;
            int page = request.Start == 0 ? 1 : (request.Start / request.Length) + 1;

            paramsBus.BusFormulario = request.CustomSearchForm;
            paramsBus.BusCriterio = request.CustomSearchType;
            paramsBus.BusValor = request.CustomSearchValue;
            paramsBus.v_pagesize = request.Length;
            paramsBus.v_currentpage = page;

            result = exeBus.RegMostrarINFFUN_BuscarDatos(paramsBus);

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
        #endregion
    }
}