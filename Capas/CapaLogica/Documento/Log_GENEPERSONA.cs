using CapaEntidad.ViewModel;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
//using System.Data.SqlClient;
using CDatos = CapaDatos.DOC.Dat_GENEPERSONA;
using CEntidad = CapaEntidad.DOC.Ent_GENEPERSONA;
namespace CapaLogica.DOC
{
    public class Log_GENEPERSONA
    {
        private CDatos oCDatos = new CDatos();
        //PopupBuscador
        /// <summary>
        /// 
        /// </summary>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public List<CEntidad> RegPersonaBuscar(CEntidad oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegPersonaBuscar(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="oCampoEntrada"></param>
        /// <returns></returns>
        public String RegPersonaGrabar(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegPersonaGrabar(cn, oCampoEntrada);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public CEntidad RegMostCombo(CEntidad oCEntidad)
        {
            try
            {
                oCEntidad.BusFormulario = "PERSONA_GENERAL";
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegMostCombo(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //permite buscar persona natural o juridica
        public ListResult buscarPersonaNJ(string busCriterio, string busValor)
        {
            ListResult result = new ListResult();
            try
            {
                CEntidad oCampos = new CEntidad();
                oCampos.BusCriterio = busCriterio;
                oCampos.BusValor = busValor;
                oCampos = RegPersonaBuscar(oCampos)[0];
                List<string> persona;
                if (busCriterio.Equals("DNI"))
                {
                    persona = new List<string> { oCampos.COD_PERSONA, oCampos.COD_DIDENTIDAD, oCampos.APE_PATERNO, oCampos.APE_MATERNO, oCampos.NOMBRES, oCampos.N_DOCUMENTO, oCampos.N_RUC, oCampos.COD_UBIGEO, oCampos.UBIGEO, oCampos.DIRECCION };
                }
                else
                {
                    persona = new List<string> { oCampos.PERSONA, oCampos.N_RUC, oCampos.COD_UBIGEO, oCampos.UBIGEO, oCampos.DIRECCION };
                }
                result.AddResultado("Registro encontrado", true, persona);
            }
            catch (Exception ex)
            {
                result.AddResultado(ex.Message, false);

            }
            return result;
        }
        public ListResult registrarPersona(VM_Persona _persona)
        {
            ListResult result = new ListResult();
            try
            {



                CEntidad oCampos = new CEntidad();
                string datosPersona = "";
                oCampos.OUTPUTPARAM01 = "";
                if (_persona.COD_PTIPO == "0000006")
                {
                    oCampos.COD_DIDENTIDAD = _persona.ddlItemPN_DITipoId;
                    oCampos.APE_PATERNO = _persona.txtItemPN_APaterno.Trim().ToUpper();
                    oCampos.APE_MATERNO = _persona.txtItemPN_AMaterno.Trim().ToUpper();
                    oCampos.NOMBRES = _persona.txtItemPN_Nombres.Trim().ToUpper();
                    oCampos.N_DOCUMENTO = _persona.txtItemPN_DINumero.Trim();
                    oCampos.COD_PTIPO = _persona.COD_PTIPO;
                    oCampos.CARGO = (string.IsNullOrEmpty(_persona.txtItemBNuevo_Cargo) ? "" : _persona.txtItemBNuevo_Cargo.Trim());
                    datosPersona = oCampos.APE_PATERNO + " " + oCampos.APE_MATERNO + " " + oCampos.NOMBRES;
                }
                else
                {
                    oCampos.DIRECCION = string.IsNullOrEmpty(_persona.txtItemPN_DLDireccion) ? "" : _persona.txtItemPN_DLDireccion.Trim();
                    oCampos.TIPO_PERSONA = _persona.tipo;
                    oCampos.COD_PERSONA = _persona.codigoPersona;
                    oCampos.RegEstado = Int32.Parse(_persona.regEstado);
                    oCampos.COD_UBIGEO = _persona.hdCOD_UBIGEO;
                    oCampos.UBIGEO = _persona.hdfUbigeo;



                    if (_persona.tipo.Equals("N"))
                    {  //natular 
                        oCampos.COD_DIDENTIDAD = _persona.ddlItemPN_DITipoId;
                        oCampos.APE_PATERNO = _persona.txtItemPN_APaterno.Trim().ToUpper();
                        oCampos.APE_MATERNO = _persona.txtItemPN_AMaterno.Trim().ToUpper();
                        oCampos.NOMBRES = _persona.txtItemPN_Nombres.Trim().ToUpper();
                        oCampos.N_DOCUMENTO = _persona.txtItemPN_DINumero.Trim();
                        oCampos.CARGO = (string.IsNullOrEmpty(_persona.txtItemBNuevo_Cargo) ? "" : _persona.txtItemBNuevo_Cargo.Trim());

                        oCampos.N_RUC = _persona.txtItemPN_DIRUC == null ? _persona.txtItemPN_DIRUC : _persona.txtItemPN_DIRUC.Trim();
                        if (_persona.formOrigen == "frmBuscarPersonaPOA")
                            oCampos.COD_PTIPO = _persona.COD_PTIPO;
                        else
                            oCampos.COD_PTIPO = (_persona.tVentana == "TI" || _persona.tVentana == "TC" ? "0000001" : "0000002");

                        datosPersona = "(Natural) " + oCampos.APE_PATERNO + " " + oCampos.APE_MATERNO + " " + oCampos.NOMBRES + " (" + oCampos.N_DOCUMENTO + "-" + oCampos.N_RUC + ")";
                    }
                    else
                    {//juridico                   
                        oCampos.PERSONA = _persona.txtItemPJ_RSocial.Trim().ToUpper();
                        oCampos.N_RUC = _persona.txtItemPJ_RUC.Trim();
                        datosPersona = "(Juridico) " + oCampos.PERSONA + " (" + oCampos.N_RUC + ")";
                    }
                }


                string codPersona = RegPersonaGrabar(oCampos);
                List<string> datosAdicionales = new List<string> { codPersona, datosPersona };
                result.AddResultado("", true, datosAdicionales);

            }
            catch (Exception ex)
            {
                result.AddResultado(ex.Message, false);

            }
            return result;
        }
        //public List<CEntidad> RegPersonaBuscarV3(CEntidad oCEntidad)
        //{
        //    try
        //    {
        //        using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
        //        {
        //            cn.Open();
        //            return oCDatos.RegPersonaBuscarV3(cn, oCEntidad);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //public List<CEntidad> buscarFuncionriov3(string cod_pTipo, string busCriterio, string busValor)
        //{
        //    List<CEntidad> resultado = new List<CEntidad>();
        //    CEntidad oCampos;
        //    try
        //    {
        //        oCampos = new CEntidad();
        //        oCampos.COD_PTIPO = cod_pTipo;
        //        oCampos.BusCriterio = busCriterio;
        //        oCampos.BusValor = busValor;
        //        resultado = RegPersonaBuscarV3(oCampos);
        //        return resultado;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        #region "SIGOsfc v3"
        public List<CEntidad> BuscarPersonaSimple_v3(CEntidad oCEntidad)
        {
            try
            {
                return oCDatos.RegPersonaBuscarSimple_v3(oCEntidad);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ListResult GrabarPersonaSimple_v3(String coducuenta, VM_Persona vm)
        {
            ListResult resultado = new ListResult();
            try
            {
                string msjRespuesta = "Se guardo con exito";
                CEntidad oCampos = new CEntidad();
                oCampos.COD_UCUENTA = coducuenta;
                oCampos.COD_PERSONA = vm.codigoPersona;
                oCampos.TIPO_PERSONA = vm.tipoPersona;
                oCampos.TELEFONO = vm.txtTelefono != null ? vm.txtTelefono.Trim() : null;
                oCampos.CORREO = vm.txtCorreo != null ? vm.txtCorreo.Trim() : null;
                oCampos.COD_PTIPO = vm.hdfITipoCargo;
                oCampos.NUM_REGISTRO_FFS = (vm.txtINumRegFfs != null) ? vm.txtINumRegFfs.Trim() : null;
                oCampos.NUM_REGISTRO_PROFESIONAL = (vm.txtINumRegProf != null) ? vm.txtINumRegProf.Trim() : null;
                oCampos.CARGO = (vm.txtICargo != null) ? vm.txtICargo.Trim() : null;
                oCampos.COLEGIATURA_NUM = (vm.txtINumColegiatura != null) ? vm.txtINumColegiatura.Trim() : null;
                oCampos.COD_NACADEMICO = vm.ddlINivelAcademicoId;
                oCampos.COD_DPESPECIALIDAD = vm.ddlIEspecialidadId;
                oCampos.ANIO = vm.ddlAnioId;
                oCampos.NROLICENCIA = (vm.txtNroLicencia != null) ? vm.txtNroLicencia.Trim() : null;
                oCampos.OTORGAMIENTO = (vm.txtFecLicencia != null) ? vm.txtFecLicencia.Trim() : null;
                oCampos.RESAPROBACION = (vm.txtResolucion != null) ? vm.txtResolucion.Trim() : null;
                oCampos.COD_CATEGORIA = (vm.ddlCategoriaId == "0000000") ? null : vm.ddlCategoriaId;
                oCampos.CIP = (vm.txtCIP != null) ? vm.txtCIP.Trim() : null;
                oCampos.ESTADO_REGENTE = (vm.ddlEstadoId == "-") ? null : vm.ddlEstadoId;
                oCampos.OTRO = (vm.txtOtro != null) ? vm.txtOtro.Trim() : null;
                oCampos.RegEstado = vm.RegEstadoPersona;
                oCampos.OUTPUTPARAM01 = "";

                if (vm.tipoPersona == "N")
                {
                    if (string.IsNullOrEmpty(vm.txtItemPN_DINumero))
                        throw new Exception("El número de documento de identidad es obligatorio");
                    oCampos.COD_DIDENTIDAD = vm.ddlItemPN_DITipoId;
                    oCampos.APE_PATERNO = vm.txtItemPN_APaterno;
                    oCampos.APE_MATERNO = vm.txtItemPN_AMaterno;
                    oCampos.NOMBRES = vm.txtItemPN_Nombres;
                    oCampos.N_DOCUMENTO = vm.txtItemPN_DINumero;
                    oCampos.N_RUC = (vm.txtItemPN_DIRUC ?? "").Trim();
                    oCampos.DIRECCION = vm.txtItemPN_DLDireccion == null ? "" : vm.txtItemPN_DLDireccion;
                    oCampos.COD_UBIGEO = vm.hdfItemPN_DLUbigeo;
                    oCampos.UBIGEO = vm.hdlblItemPN_DLUbigeo;
                }
                else //Jurídica
                {
                    if (string.IsNullOrEmpty(vm.txtItemPJ_RUC))
                        throw new Exception("El número de RUC es obligatorio");
                    oCampos.PERSONA = vm.txtItemPJ_RSocial.Trim().ToUpper();
                    oCampos.N_RUC = vm.txtItemPJ_RUC.Trim();
                    oCampos.DIRECCION = vm.txtItemPJ_DLDireccion == null ? "" : vm.txtItemPJ_DLDireccion;
                    oCampos.COD_UBIGEO = vm.hdfItemPJ_DLUbigeo;
                    oCampos.UBIGEO = vm.hdlblItemPJ_DLUbigeo;
                    oCampos.FICHA_REGISTRAL = vm.txtItemPJ_FichaRegistral;
                }

                oCampos.ListTipoCargo = new List<CEntidad>();
                if (vm.hdfITipoCargo != null && vm.hdfITipoCargo != "")
                {
                    CEntidad oParamsCargo;
                    string[] codTipCargos = vm.hdfITipoCargo.Split(',');

                    for (int i = 1; i < codTipCargos.Length; i++)
                    {
                        oParamsCargo = new CEntidad();
                        oParamsCargo.COD_PTIPO = codTipCargos[i];
                        oParamsCargo.RegEstado = 1;

                        oCampos.ListTipoCargo.Add(oParamsCargo);
                    }
                }

                oCampos.ListMencion = new List<CEntidad>();
                if (vm.hdfMencionRegencia != null && vm.hdfMencionRegencia != "")
                {
                    CEntidad oParamsMencion;
                    string[] codMencion = vm.hdfMencionRegencia.Split(',');

                    for (int i = 1; i < codMencion.Length; i++)
                    {
                        oParamsMencion = new CEntidad();
                        oParamsMencion.COD_MENSION = codMencion[i];
                        oParamsMencion.COD_SECUENCIAL = 0;
                        oParamsMencion.RegEstado = 1;

                        oCampos.ListMencion.Add(oParamsMencion);
                    }
                }

                oCDatos.RegPersonaGrabarSimple_v3(oCampos);
                resultado.AddResultado(msjRespuesta, true);
            }
            catch (Exception ex)
            {
                resultado.AddResultado("", false, ex.Message);
            }
            return resultado;

        }

        public ListResult GrabarTipoCargo(String coducuenta, VM_Persona vm)
        {

            ListResult resultado = new ListResult();
            try
            {
                CEntidad oCampos = new CEntidad();
                oCampos.BusFormulario = "ADICIONA_CARGO";
                oCampos.COD_UCUENTA = coducuenta;
                oCampos.COD_PERSONA = vm.codigoPersona;
                oCampos.COD_PTIPO = vm.ddlITipoCargoId;
                oCampos.NUM_REGISTRO_FFS = (vm.txtINumRegFfs != null) ? vm.txtINumRegFfs.Trim() : null;
                oCampos.NUM_REGISTRO_PROFESIONAL = (vm.txtINumRegProf != null) ? vm.txtINumRegProf.Trim() : null;
                oCampos.CARGO = (vm.txtICargo != null) ? vm.txtICargo.Trim() : null;
                oCampos.COLEGIATURA_NUM = (vm.txtINumColegiatura != null) ? vm.txtINumColegiatura.Trim() : null;
                oCampos.COD_NACADEMICO = vm.ddlINivelAcademicoId;
                oCampos.COD_DPESPECIALIDAD = vm.ddlIEspecialidadId;
                oCampos.ANIO = vm.ddlAnioId;
                oCampos.NROLICENCIA = (vm.txtNroLicencia != null) ? vm.txtNroLicencia.Trim() : null;
                oCampos.OTORGAMIENTO = (vm.txtFecLicencia != null) ? vm.txtFecLicencia.Trim() : null;
                oCampos.RESAPROBACION = (vm.txtResolucion != null) ? vm.txtResolucion.Trim() : null;
                oCampos.COD_CATEGORIA = (vm.ddlCategoriaId == "0000000") ? null : vm.ddlCategoriaId;
                oCampos.CIP = (vm.txtCIP != null) ? vm.txtCIP.Trim() : null;
                oCampos.ESTADO_REGENTE = (vm.ddlEstadoId == "-") ? null : vm.ddlEstadoId;
                oCampos.OTRO = (vm.txtOtro != null) ? vm.txtOtro.Trim() : null;
                oCampos.RegEstado = 1;
                oCampos.OUTPUTPARAM01 = "";

                oCampos.ListMencion = new List<CEntidad>();
                if (vm.hdfMencionRegencia != null && vm.hdfMencionRegencia != "")
                {
                    CEntidad oParamsMencion;
                    string[] codMencion = vm.hdfMencionRegencia.Split(',');

                    for (int i = 1; i < codMencion.Length; i++)
                    {
                        oParamsMencion = new CEntidad();
                        oParamsMencion.COD_MENSION = codMencion[i];
                        oParamsMencion.COD_SECUENCIAL = 0;
                        oParamsMencion.RegEstado = 1;

                        oCampos.ListMencion.Add(oParamsMencion);
                    }
                }

                string msjRespuesta = oCDatos.RegTipoCargoGrabar(oCampos);
                resultado.AddResultado(msjRespuesta, true);
            }
            catch (Exception ex)
            {
                resultado.AddResultado("", false, ex.Message);
            }
            return resultado;
        }
        #endregion
    }
}
