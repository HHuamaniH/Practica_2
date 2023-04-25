using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CEntVM = CapaEntidad.ViewModel.VM_Persona;
using CEntidadP = CapaEntidad.DOC.Ent_Persona;
using CLogica = CapaLogica.DOC.Log_Persona;
using SIGOFCv3.Models;
using CapaEntidad.ViewModel;
using CapaEntidad.ViewModel.General;
using SIGOFCv3.Helper;

namespace SIGOFCv3.Areas.General.Controllers
{
    public class ManPersonasController : Controller
    {
        public static CEntVM vmP = new CEntVM();
        //dIRECTORIO UNICO
        public ActionResult Index(int lstManMenu = 0, string _alertaIncial = "")
        {
            try
            {
                /*if (lstManMenu == 1)
                {
                    ViewBag.Formulario = "ADMINISTRADOS";
                    ViewBag.TituloFormulario = "Administrados";
                    ViewBag.AlertaInicial = _alertaIncial;
                }
                else
                {
                    ViewBag.Formulario = "PERSONA";
                    ViewBag.TituloFormulario = "Personas";
                    ViewBag.AlertaInicial = _alertaIncial;
                }*/

                ViewBag.Formulario = "DIRECTORIO_UNICO";
                ViewBag.TituloFormulario = "Directorio Único";
                ViewBag.AlertaInicial = _alertaIncial;

                //obtenemos el rol sobre el formulario
                //VM_Menu_Rol mr = HelperSigo.GetRol("HERRAMIENTAS", "Mantenimiento Personas");
                VM_Menu_Rol mr = HelperSigo.GetRol("HERRAMIENTAS", "Mantenimiento de Directorio Único");
                ViewBag.CodRol = mr.NCODROL;
                ViewBag.VAliasRol = mr.VALIAS;
                return View();
            }
            catch (Exception)
            {
                return RedirectToAction("ErrorC", "Login", new { Area = "" });
            }

        }

        /*[HttpPost]
        public JsonResult ExportarRegistroUsuario()
        {
            ListResult result = new ListResult();

            result = ExportarDatos.RegistroUsuario((ModelSession.GetSession())[0].COD_UCUENTA);

            return Json(result);
        }*/

        //public ActionResult AddEdit(string asCodPersona = "",string tipo="P")
        public ActionResult AddEdit(string asCodPersona = "")
        {
            try
            {
                CEntidadP entP = new CEntidadP();
                CLogica logP = new CLogica();

                /*vmP.lblTituloCabecera = tipo=="P"?"Personas":"Administrados";
                entP.BusFormulario = tipo == "P" ? "PERSONA" : "ADMINISTRADOS";
                entP.BusValor = tipo;*/
                vmP.lblTituloCabecera = "Directorio Único";
                entP.BusFormulario = "DIRECTORIO_UNICO";
                //entP.BusValor = tipo;
                entP.BusCriterio = "TODOS";
                entP.COD_UCUENTA = (ModelSession.GetSession())[0].COD_UCUENTA;
                entP = logP.RegMostCombo(entP);
                vmP.ddlTipo = entP.ListCTipoPersona.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION });
                vmP.ddlItemPN_DITipo = entP.ListCTipoDocIdentidad.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION });
                vmP.ddlISexo = entP.ListCSexo.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION });
                vmP.ddlITipoCargo = entP.ListCTipoCargo.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION });
                vmP.ddlINivelAcademico = entP.ListCNivelAcademico.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION });
                vmP.ddlIEspecialidad = entP.ListCEspecialidad.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION });

                ViewBag.ddlMItemTelefono_TTelefono = entP.ListCTipoTelefono.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION });
                ViewBag.ddlMItemCorreo_TCorreo = entP.ListCTipoCorreo.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION });

                var lstCategoria = entP.ListCCategoria.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION }).ToList();
                lstCategoria.Insert(0, new VM_Cbo { Value = "0000000", Text = "Seleccionar" });
                vmP.ddlCategoria = lstCategoria;
                vmP.ddlMencionRegencia = new List<VM_Cbo>();
                var lstEstado = entP.ListCEstado.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION }).ToList();
                lstEstado.Insert(0, new VM_Cbo { Value = "-", Text = "Seleccionar" });
                vmP.ddlEstado = lstEstado;

                var lstAnio = new List<VM_Chk>();
                for (int i = DateTime.Now.Year; i >= 2016; i--)
                {
                    lstAnio.Add(new VM_Chk() { Value = i.ToString(), Text = i.ToString() });
                }
                vmP.ddlAnio = lstAnio.Select(i => new VM_Cbo { Value = i.Value, Text = i.Text });
                vmP.ddlAnioId = vmP.ddlAnio.First().Value;

                //ViewBag.tipo = tipo;
                if (String.IsNullOrEmpty(asCodPersona))
                {
                    vmP.lblTituloEstado = "Nuevo Registro";

                    RegistroLimpiar();

                    vmP.RegEstadoPersona = 1;
                }
                else
                {
                    RegistroLimpiar();

                    entP = logP.RegMostrarListaItem(new CEntidadP() { COD_PERSONA = asCodPersona });
                    vmP.lblTituloEstado = "Modificando Registro";
                    vmP.codigoPersona = asCodPersona;

                    vmP.tipoPersona = entP.COD_TPERSONA;
                    vmP.ddlItemPN_DITipoId = entP.COD_DIDENTIDAD;
                    vmP.ddlISexoId = entP.COD_SEXO;
                    vmP.txtItemPN_APaterno = entP.APE_PATERNO;
                    vmP.txtItemPN_AMaterno = entP.APE_MATERNO;
                    vmP.txtItemPN_Nombres = entP.NOMBRES;
                    vmP.txtItemPN_DINumero = entP.N_DOCUMENTO;
                    vmP.txtIRazonSocial = entP.RAZON_SOCIAL;
                    vmP.rb_internet = entP.NINTERNET;

                    vmP.txtICargo = entP.CARGO;
                    vmP.txtINumColegiatura = entP.COLEGIATURA_NUM;
                    vmP.txtINumRegFfs = entP.NUM_REGISTRO_FFS;
                    vmP.txtINumRegProf = entP.NUM_REGISTRO_PROFESIONAL;
                    vmP.ddlIEspecialidadId = entP.COD_DPESPECIALIDAD == "" ? "0000000" : entP.COD_DPESPECIALIDAD;
                    vmP.ddlINivelAcademicoId = entP.COD_NACADEMICO == "" ? "0000000" : entP.COD_NACADEMICO;
                    vmP.ddlAnioId = entP.ANIO;
                    vmP.txtNroLicencia = entP.NROLICENCIA;
                    vmP.txtFecLicencia = entP.OTORGAMIENTO;
                    vmP.txtResolucion = entP.RESAPROBACION;
                    vmP.ddlCategoriaId = entP.COD_CATEGORIA == "" ? "0000000" : entP.COD_CATEGORIA;
                    vmP.txtCIP = entP.CIP;
                    vmP.ddlEstadoId = entP.ESTADO_REGENTE == "" ? "-" : entP.ESTADO_REGENTE;
                    vmP.txtOtro = entP.OTRO;

                    vmP.tbDomicilio = entP.ListDomicilio;
                    vmP.tbTelefono = entP.ListTelefono;
                    vmP.tbCorreo = entP.ListCorreo;

                    foreach (var itemCargo in entP.ListTipoCargo)
                    {
                        vmP.hdfITipoCargo += "," + itemCargo.COD_PTIPO;
                    }

                    foreach (var itemMencion in entP.ListMencion)
                    {
                        vmP.hdfMencionRegencia += "," + itemMencion.COD_MENSION;
                    }

                    vmP.RegEstadoPersona = 0;
                }

                //obtenemos el rol sobre el formulario
                // VM_Menu_Rol mr = HelperSigo.GetRol("HERRAMIENTAS", "Mantenimiento Personas");
                VM_Menu_Rol mr = HelperSigo.GetRol("HERRAMIENTAS", "Mantenimiento de Directorio Único");
                ViewBag.CodRol = mr.NCODROL;
                ViewBag.VAliasRol = mr.VALIAS;

                return View(vmP);
            }
            catch (Exception)
            {
                return RedirectToAction("ErrorC", "Index");
            }
        }

        public void RegistroLimpiar()
        {
            vmP.codigoPersona = "";
            vmP.tipoPersona = "N";
            vmP.ddlItemPN_DITipoId = "0000000";
            vmP.txtItemPN_DINumero = "";
            vmP.txtItemPN_APaterno = "";
            vmP.txtItemPN_AMaterno = "";
            vmP.txtItemPN_Nombres = "";
            vmP.ddlISexoId = "00";
            vmP.hdfITipoCargo = "";
            vmP.txtIRazonSocial = "";
            vmP.txtINumRegFfs = "";
            vmP.txtINumRegProf = "";
            vmP.txtICargo = "";
            vmP.txtINumColegiatura = "";
            vmP.ddlINivelAcademicoId = "0000000";
            vmP.ddlIEspecialidadId = "0000000";
            vmP.txtNroLicencia = "";
            vmP.txtFecLicencia = "";
            vmP.txtResolucion = "";
            vmP.ddlCategoriaId = "0000000";
            vmP.hdfMencionRegencia = "";
            vmP.txtCIP = "";
            vmP.ddlEstadoId = "-";

            vmP.tbTipoCargo = new List<CEntidadP>();
            vmP.tbDomicilio = new List<CEntidadP>();
            vmP.tbTelefono = new List<CEntidadP>();
            vmP.tbCorreo = new List<CEntidadP>();
            vmP.tbEliTABLA = new List<CEntidadP>();
        }

        [HttpPost]
        public JsonResult Grabar(CEntVM obj)
        {
            try
            {
                CEntidadP entP = new CEntidadP();
                CLogica logP = new CLogica();

                string codCuenta = (ModelSession.GetSession())[0].COD_UCUENTA;
                ListResult result = new ListResult();

                entP.COD_PERSONA = obj.codigoPersona;
                entP.COD_TPERSONA = obj.tipoPersona;
                entP.COD_DIDENTIDAD = obj.ddlItemPN_DITipoId;
                entP.N_DOCUMENTO = obj.txtItemPN_DINumero.Trim();

                if (obj.tipoPersona == "N")
                {
                    entP.COD_SEXO = obj.ddlISexoId;
                    entP.APE_PATERNO = obj.txtItemPN_APaterno.Trim();
                    entP.APE_MATERNO = obj.txtItemPN_AMaterno.Trim();
                    entP.NOMBRES = obj.txtItemPN_Nombres.Trim();
                    entP.APELLIDOS_NOMBRES = entP.APE_PATERNO + " " + entP.APE_MATERNO + " " + entP.NOMBRES;
                }
                else if (obj.tipoPersona == "J")
                {
                    entP.APELLIDOS_NOMBRES = obj.txtIRazonSocial.Trim();
                }

                entP.CARGO = (obj.txtICargo == null) ? "" : obj.txtICargo.Trim();
                entP.COD_DPESPECIALIDAD = obj.ddlIEspecialidadId;
                entP.COD_NACADEMICO = obj.ddlINivelAcademicoId;
                entP.COLEGIATURA_NUM = (obj.txtINumColegiatura == null) ? "" : obj.txtINumColegiatura.Trim();
                entP.NUM_REGISTRO_FFS = (obj.txtINumRegFfs == null) ? "" : obj.txtINumRegFfs.Trim();
                entP.NUM_REGISTRO_PROFESIONAL = (obj.txtINumRegProf == null) ? "" : obj.txtINumRegProf.Trim();
                entP.NINTERNET = obj.rb_internet;
                entP.ANIO = obj.ddlAnioId;
                entP.NROLICENCIA = (obj.txtNroLicencia != null) ? obj.txtNroLicencia.Trim() : null;
                entP.OTORGAMIENTO = (obj.txtFecLicencia != null) ? obj.txtFecLicencia.Trim() : null;
                entP.RESAPROBACION = (obj.txtResolucion != null) ? obj.txtResolucion.Trim() : null;
                entP.COD_CATEGORIA = (obj.ddlCategoriaId == "0000000") ? null : obj.ddlCategoriaId;
                entP.CIP = (obj.txtCIP != null) ? obj.txtCIP.Trim() : null;
                entP.ESTADO_REGENTE = (obj.ddlEstadoId == "-") ? null : obj.ddlEstadoId;
                entP.OTRO = (obj.txtOtro != null) ? obj.txtOtro.Trim() : null;
                entP.ListDomicilio = obj.tbDomicilio;
                entP.ListEliTABLA = obj.tbEliTABLA;
                entP.ListTelefono = obj.tbTelefono;
                entP.ListCorreo = obj.tbCorreo;

                entP.ListTipoCargo = new List<CEntidadP>();

                if (obj.hdfITipoCargo != null && obj.hdfITipoCargo != "")
                {
                    CEntidadP oParamsCargo;
                    string[] codTipCargos = obj.hdfITipoCargo.Split(',');

                    for (int i = 1; i < codTipCargos.Length; i++)
                    {
                        oParamsCargo = new CEntidadP();
                        oParamsCargo.COD_PTIPO = codTipCargos[i];
                        oParamsCargo.RegEstado = 1;

                        entP.ListTipoCargo.Add(oParamsCargo);
                    }
                }

                entP.ListMencion = new List<CEntidadP>();

                if (obj.hdfMencionRegencia != null && obj.hdfMencionRegencia != "")
                {
                    CEntidadP oParamsMencion;
                    string[] codMencion = obj.hdfMencionRegencia.Split(',');

                    for (int i = 1; i < codMencion.Length; i++)
                    {
                        oParamsMencion = new CEntidadP();
                        oParamsMencion.COD_MENSION = codMencion[i];
                        oParamsMencion.COD_SECUENCIAL = 0;
                        oParamsMencion.RegEstado = 1;

                        entP.ListMencion.Add(oParamsMencion);
                    }
                }

                entP.OUTPUTPARAM01 = "";
                entP.COD_UCUENTA = codCuenta;
                entP.RegEstado = obj.RegEstadoPersona;

                entP.COD_PERSONA = logP.RegGrabar(entP);
                RegistroLimpiar();
                result.AddResultado("El Registro se Guardo Correctamente", true);

                return Json(result);
            }
            catch (Exception)
            {
                //return Json(ex.Message);
                return Json("Ocurrio un error en el registro, verifique los datos e intente de nuevo");
            }

        }

        [HttpPost]
        public PartialViewResult _AddTipoCargo()
        {
            return PartialView();
        }

        [HttpPost]
        public JsonResult GrabarTipoCargo(CEntidadP entP)
        {
            ListResult result = new ListResult();

            try
            {
                CLogica logP = new CLogica();

                string OUTPUTPARAM = logP.GrabarTipoCargo(entP);

                if (OUTPUTPARAM.Split('|')[0] == "0")
                {
                    result.AddResultado(OUTPUTPARAM.Split('|')[1], false);
                }
                else
                {
                    result.AddResultado(OUTPUTPARAM.Split('|')[1], true);
                }
            }
            catch (Exception ex)
            {
                result.AddResultado(ex.Message, false);
            }
            return Json(result);
        }

        [HttpPost]
        public JsonResult ListarTipoCargo()
        {
            try
            {
                CapaLogica.DOC.Log_BUSQUEDA exeBus = new CapaLogica.DOC.Log_BUSQUEDA();
                CapaEntidad.DOC.Ent_BUSQUEDA paramsBus = new CapaEntidad.DOC.Ent_BUSQUEDA();
                paramsBus.BusFormulario = "DIRECTORIO_UNICO";
                paramsBus.BusCriterio = "PERSONA_TIPO";

                List<CapaEntidad.DOC.Ent_BUSQUEDA> list = exeBus.RegOpcionesCombo(paramsBus);
                var ddlITipoCargo = list.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION });
                return Json(new { success = true, result = ddlITipoCargo });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, result = ex.Message });
            }
        }

        [HttpPost]
        public JsonResult ListarMencionRegencia(string idcategoria)
        {
            try
            {
                CapaLogica.DOC.Log_BUSQUEDA exeBus = new CapaLogica.DOC.Log_BUSQUEDA();
                CapaEntidad.DOC.Ent_BUSQUEDA paramsBus = new CapaEntidad.DOC.Ent_BUSQUEDA();
                paramsBus.BusFormulario = "DIRECTORIO_UNICO";
                paramsBus.BusCriterio = "REGENTE_MENCION";
                paramsBus.BusValor = idcategoria;

                List<CapaEntidad.DOC.Ent_BUSQUEDA> list = exeBus.RegOpcionesCombo(paramsBus);
                var ddlMencionRegencia = list.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION });
                return Json(new { success = true, result = ddlMencionRegencia });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, result = ex.Message });
            }
        }
    }
}