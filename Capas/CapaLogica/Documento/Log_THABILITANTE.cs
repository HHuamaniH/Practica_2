using CapaDatos;
using CapaEntidad.DOC;
using CapaEntidad.ViewModel;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
//using System.Data.SqlClient;
using System.Linq;
using CDatos = CapaDatos.DOC.Dat_THABILITANTE;
using CEntidad = CapaEntidad.DOC.Ent_THABILITANTE;
//using GeneralSQL;
namespace CapaLogica.DOC
{
    /// <summary>
    /// 
    /// </summary>
	public class Log_THABILITANTE
    {
        private CDatos oCDatos = new CDatos();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public CEntidad RegMostrarListaItems(CEntidad oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegMostrarListaItems(cn, oCEntidad);
                    //cn.Close();
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
		//public String RegGrabar(CEntidad oCampoEntrada, bool sigov3 = false)
  //      {
  //          try
  //          {
  //              using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
  //              {
  //                  cn.Open();
  //                  return oCDatos.RegGrabar(cn, oCampoEntrada, sigov3);
  //              }
  //          }
  //          catch (Exception ex)
  //          {
  //              throw ex;
  //          }
  //      }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="oCampoEntrada"></param>
		//public void RegEliminar(CEntidad oCampoEntrada)
  //      {
  //          try
  //          {
  //              using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
  //              {
  //                  cn.Open();
  //                  oCDatos.RegEliminar(cn, oCampoEntrada);
  //              }
  //          }
  //          catch (Exception ex)
  //          {
  //              throw ex;
  //          }
  //      }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public CEntidad RegMostCombo(CEntidad oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegMostCombo(cn, oCEntidad);
                    //cn.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CEntidad GetDatosGeneralesTituloHabilitante(CEntidad oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.GetDatosGeneralesTituloHabilitante(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //public List<CEntidad> RegMostrarTHEstadoListar(CEntidad oCEntidad)
        //{
        //    try
        //    {
        //        using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
        //        {
        //            cn.Open();
        //            return oCDatos.RegMostrarTHEstadoListar(cn, oCEntidad);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //public String RegActualizarEstado(CEntidad oCampoEntrada)
        //{
        //    try
        //    {
        //        using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
        //        {
        //            cn.Open();
        //            return oCDatos.RegActualizarEstado(cn, oCampoEntrada);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        #region "Migracion - SIGO v3"
        public CEntidad RegMostComboV3(CEntidad oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegMostComboV3(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public VM_THabilitante IniDatosTHabilitante(string codigoThabilitante, string cod_cuenta, string codigoNuevo, string nombreTH = "")
        {
            VM_THabilitante TH_VM;
            bool esConsolidado = false;
            try
            {
                TH_VM = new VM_THabilitante();
                CEntidad oCampos = new CEntidad();
                oCampos.COD_UCUENTA = cod_cuenta;
                oCampos.BusFormulario = "TITULO_HABILITANTE";
                oCampos = RegMostCombo(oCampos);
                if (String.IsNullOrEmpty(codigoThabilitante)) //iniciar nuevo item
                {
                    String cod_mtipo; String titularJuridico; String cod_modalidad;
                    cod_mtipo = codigoNuevo.Split('|')[0];
                    titularJuridico = codigoNuevo.Split('|')[3];
                    cod_modalidad = codigoNuevo.Split('|')[4];
                    TH_VM.hdCodigo_Thabilitante = "";
                    TH_VM.ItemTitulo = "Nuevo Registro";
                    TH_VM.txtItemNumero = nombreTH;
                    TH_VM.hdfManRegEstado = "1";
                    TH_VM.cod_Modalidad = cod_modalidad;
                    TH_VM.txtItemModalidad = codigoNuevo.Split('|')[1].Split(':')[1].Trim();
                    TH_VM.hdfItemModalidadCodigo = cod_mtipo;
                    TH_VM.ddlODRegistro = oCampos.ListODs.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION });
                    TH_VM.ddlODRegistroId = "0000000";
                    TH_VM.ddClaseZoologico = oCampos.ListClaseZoologico.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION });
                    TH_VM.ddClaseZoologicoId = "0";
                    TH_VM.ddClaseZoologicoRECId = "0";
                    TH_VM.chkManConsolidado = esConsolidado;
                    TH_VM.mostrarDivRLegal = true;
                    TH_VM.lblItemNumeroTitulo = cod_modalidad == "0000002" ? "Nombre Establecimiento" : "Número Contrato";
                    TH_VM.lblCodigoNumero = "Código N°";
                    TH_VM.hdfItemTipo = esConsolidado == true ? "C" : "N";
                    TH_VM.ltrItemEtiContratoTitulo = esConsolidado ? "Contrato (Ingresar Fechas Consolidadas)" : "Contrato (Ingresar Fechas)";
                    TH_VM.ddplZonaZooId = "0000000";
                    TH_VM.lblTitularTipoTitulo = esConsolidado == true ? "Nombre Consolidado" : "Titular";
                    if (cod_modalidad == "0000004")
                    {
                        List<VM_Cbo> listaTipo = new List<VM_Cbo> { new VM_Cbo { Value = "00000", Text = "Seleccionar" }, new VM_Cbo { Value = "PERMISO", Text = "PERMISO" }, new VM_Cbo { Value = "AUTORIZACI�N", Text = "AUTORIZACI�N" } };
                        TH_VM.ddTipo = listaTipo;
                        TH_VM.ddTipoId = "00000";
                    }
                    if (cod_mtipo == "0000015")//Comunidad Nativa
                    {
                        List<VM_Cbo> listNivelAprov = new List<VM_Cbo> { new VM_Cbo { Value = "00000", Text = "Seleccionar" }, new VM_Cbo { Value = "ALTA ESCALA", Text = "ALTA ESCALA" }, new VM_Cbo { Value = "MEDIA ESCALA", Text = "MEDIA ESCALA" },
                                                  new VM_Cbo { Value = "BAJA ESCALA", Text = "BAJA ESCALA" }, new VM_Cbo { Value = "NO PRECISA", Text = "NO PRECISA" }};
                        TH_VM.ddNivelApro = listNivelAprov;
                        TH_VM.ddNivelAproId = "00000";
                    }
                    TH_VM.ddComoboMotivoRec = oCampos.ListComboRecategoriza.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION });
                    TH_VM.ddComoboMotivoRecId = "00000";
                    TH_VM.ddModalidadTH = oCampos.ListModalidadesTH.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION });
                    TH_VM.ddModalidadTHId = "00000";
                    // INI Establecimiento
                    TH_VM.ddEstablecimientoTH = oCampos.ListTHMotivoEstado.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION });
                    TH_VM.ddEstablecimientoTHId = "00000";
                    // FIN Establecimiento
                    TH_VM.ddlItemAdeMotivo = oCampos.ListMComboMAdenda.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION });
                    TH_VM.ddlItemAdeMotivoId = "00000";
                    TH_VM.chkItemPlanManejo = false;

                    TH_VM.ddModalidadFRTH = oCampos.ListComboFR.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION });
                    TH_VM.ddModalidadFRTHId = "00000";

                    // para extincion
                    TH_VM.ddTHExtincion = oCampos.ListTHMotivoExtincion.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION });
                    TH_VM.ddTHExtincionId = "00000";


                    TH_VM.ddlDependencia = new List<VM_Cbo>();
                    TH_VM.tbErrorMaterial_DGeneral = new List<Ent_ERRORMATERIAL>();
                    TH_VM.tbErrorMaterial_DAdicional = new List<Ent_ERRORMATERIAL>();

                    TH_VM.ListTHExtincion = new List<Ent_THABILITANTE>();
                    TH_VM.ListModalidadesTH = new List<Ent_THABILITANTE>();
                }
                else //iniciar modificar item
                {
                    CEntidad datModificar = new CEntidad();
                    TH_VM.ItemTitulo = "Modificando Registro";
                    datModificar.COD_THABILITANTE = codigoThabilitante;
                    datModificar = RegMostrarListaItems(datModificar);

                    TH_VM.hdCodigo_Thabilitante = codigoThabilitante;
                    TH_VM.ItemTitulo = "Modificar Registro";
                    TH_VM.hdfManRegEstado = "0";
                    TH_VM.cod_Modalidad = datModificar.MODALIDAD_EJURIDICO.Split('|')[0];
                    TH_VM.txtItemModalidad = datModificar.MODALIDAD;
                    TH_VM.hdfItemModalidadCodigo = datModificar.COD_MTIPO;
                    TH_VM.lblTitularTipoTitulo = datModificar.TIPO == "C" ? "Nombre Consolidado" : "Titular";
                    if (TH_VM.cod_Modalidad == "0000004")
                    {
                        List<VM_Cbo> listaTipo = new List<VM_Cbo> { new VM_Cbo { Value = "00000", Text = "Seleccionar" }, new VM_Cbo { Value = "PERMISO", Text = "PERMISO" }, new VM_Cbo { Value = "AUTORIZACI�N", Text = "AUTORIZACI�N" } };
                        TH_VM.ddTipo = listaTipo;
                        TH_VM.ddTipoId = datModificar.TIPO_NM != "" ? datModificar.TIPO_NM : "00000";
                    }
                    if (TH_VM.hdfItemModalidadCodigo == "0000015")//Comunidad Nativa
                    {
                        List<VM_Cbo> listNivelAprov = new List<VM_Cbo> { new VM_Cbo { Value = "00000", Text = "Seleccionar" }, new VM_Cbo { Value = "ALTA ESCALA", Text = "ALTA ESCALA" }, new VM_Cbo { Value = "MEDIA ESCALA", Text = "MEDIA ESCALA" },
                                                  new VM_Cbo { Value = "BAJA ESCALA", Text = "BAJA ESCALA" }, new VM_Cbo { Value = "NO PRECISA", Text = "NO PRECISA" }};
                        TH_VM.ddNivelApro = listNivelAprov;
                        TH_VM.ddNivelAproId = datModificar.NIVEL_APROV;
                    }
                    TH_VM.ddComoboMotivoRec = oCampos.ListComboRecategoriza.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION });
                    TH_VM.ddComoboMotivoRecId = "00000";
                    TH_VM.ddModalidadTH = oCampos.ListModalidadesTH.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION });
                    TH_VM.ddModalidadTHId = "00000";
                    TH_VM.ddModalidadFRTH = oCampos.ListComboFR.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION });
                    TH_VM.ddModalidadFRTHId = "00000";
                    // INI Establecimiento
                    TH_VM.ddEstablecimientoTH = oCampos.ListTHMotivoEstado.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION });
                    TH_VM.ddEstablecimientoTHId = "00000";
                    // FIN Establecimiento
                    TH_VM.ddlItemAdeMotivo = oCampos.ListMComboMAdenda.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION });
                    TH_VM.ddlItemAdeMotivoId = "00000";
                    TH_VM.ddClaseZoologico = oCampos.ListClaseZoologico.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION });
                    TH_VM.ddClaseZoologicoId = datModificar.CLASE_ZOOLOGICO;

                    TH_VM.ddTHExtincion = oCampos.ListTHMotivoExtincion.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION });
                    TH_VM.ddTHExtincionId = "00000";

                    TH_VM.ddClaseZoologicoRECId = "0";
                    TH_VM.txtTitularTipo = datModificar.PERSONA_TITULAR;
                    TH_VM.txtCodigoNumero = datModificar.CODIGO_NUMERO == " " ? "" : datModificar.CODIGO_NUMERO;
                    TH_VM.hdtxtTitularTipo = datModificar.COD_TITULAR;
                    TH_VM.fItemRLegalCodigo = datModificar.PERSONA_RLEGAL;
                    TH_VM.hdfItemRLegalCodigo = datModificar.COD_RLEGAL;
                    string valTitularTipo = TH_VM.txtTitularTipo.Substring(0, 10);
                    if (valTitularTipo == "(Juridico)") TH_VM.mostrarDivRLegal = true;
                    else TH_VM.mostrarDivRLegal = false;
                    TH_VM.lblItemNumeroTitulo = TH_VM.cod_Modalidad == "0000002" ? "Nombre Establecimiento" : "Número Contrato";
                    TH_VM.lblCodigoNumero = "Código N°";
                    TH_VM.txtItemNumero = datModificar.NUMERO;
                    TH_VM.hdfItemTipo = datModificar.TIPO;
                    TH_VM.fItemEstUbigeoCodigo = datModificar.ESTAB_UBIGEO;
                    TH_VM.hdfItemEstUbigeoCodigo = datModificar.ESTAB_COD_UBIGEO;
                    TH_VM.txtItemEstSector = datModificar.ESTAB_SECTOR;
                    TH_VM.txtItemObservacion = datModificar.OBSERVACION.ToString();
                    TH_VM.ddlODRegistro = oCampos.ListODs.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION });
                    TH_VM.ddlODRegistroId = datModificar.COD_OD_REGISTRO;
                    TH_VM.txtItemAOtorgada = datModificar.AREA_OTORGADA.ToString();
                    TH_VM.chkItemContCuenta = (Boolean)datModificar.CONTRADO_CONDICIONAL;
                    TH_VM.txtItemContFInicio = datModificar.CONTRATO_FECHA_INICIO.ToString();
                    TH_VM.txtItemContFFin = datModificar.CONTRATO_FECHA_FIN.ToString();
                    TH_VM.txtCodCat = datModificar.COD_CAT;
                    //concesiones forestales
                    TH_VM.txtcaracter_ambiental = datModificar.CARACTER_AMBIENTAL.ToString();
                    TH_VM.txtcaracter_social = datModificar.CARACTER_SOCIAL.ToString();
                    TH_VM.txtcaracter_eresponsable = datModificar.CARACTER_ERESPONSABLE.ToString();
                    TH_VM.txtConcesionario = datModificar.OBLIGACIONES_CONCESIONARIOS.ToString();
                    //cuando es Autorizaciones Fauna Silvestre Ex Situ
                    TH_VM.txtItemRAPNumero = datModificar.APROYECTO_NUM_RESOL;
                    TH_VM.txtItemRAPFecha = datModificar.APROYECTO_FECHA.ToString();
                    TH_VM.fItemRAPFuncionarioCodigo = datModificar.PERSONA_APROYECTO;
                    TH_VM.hdfItemRAPFuncionarioCodigo = datModificar.APROYECTO_COD_FUNCIONARIO;
                    TH_VM.txtItemRAFNumero = datModificar.AFUNCIONAMIENTO_NUM_RESOL;
                    TH_VM.txtItemRAFFecha = datModificar.AFUNCIONAMIENTO_FECHA.ToString();
                    TH_VM.fItemRAFFuncionarioCodigo = datModificar.PERSONA_AFUNCIONAMIENTO;
                    TH_VM.hdfItemRAFFuncionarioCodigo = datModificar.AFUNCIONAMIENTO_COD_FUNCIONARIO;
                    TH_VM.chkItemPlanManejo = (Boolean)datModificar.CUENTA_PLAN_MANEJO;
                    string[] direccion = datModificar.UBIGEO_DIRECCION.Split('|');
                    if (direccion.Length>1)
                    {
                        TH_VM.txtUbigeo = direccion[0];
                        TH_VM.txtDirecion = direccion[1];
                    }
                    
                    //cargando datos de tablas                    
                    TH_VM.ListTDTTITULARES = datModificar.ListTDTTITULARES;
                    TH_VM.ListTDDVVERTICE = datModificar.ListTDDVVERTICE;
                    //agregado ListTHEstadoEsta
                    TH_VM.ListTHEstadoEsta = datModificar.ListTHEstadoEsta;
                    //TH_VM.ListTDDVADEAREA = new List<VM_THA_Area>();
                    TH_VM.ListModalidadesTH = datModificar.ListModalidadesTH;
                    TH_VM.ListAdendas = datModificar.ListAdendas;
                    //Observaciones de control de calidad
                    if (TH_VM.hdfItemModalidadCodigo == "0000001" || TH_VM.hdfItemModalidadCodigo == "0000002" || TH_VM.hdfItemModalidadCodigo == "0000003" || TH_VM.hdfItemModalidadCodigo == "0000004" || TH_VM.hdfItemModalidadCodigo == "0000023")
                    {
                        if (TH_VM.ListTDDVVERTICE.Count > 0)
                        {
                            TH_VM.ddplZonaZooId = TH_VM.ListTDDVVERTICE[0].ZONA;
                            TH_VM.txtCEsteZoo = TH_VM.ListTDDVVERTICE[0].COORDENADA_ESTE.ToString();
                            TH_VM.txtCNorteZoo = TH_VM.ListTDDVVERTICE[0].COORDENADA_NORTE.ToString();
                        }
                    }

                    //variables de control de calidad
                    TH_VM.vmControlCalidad.ddlIndicadorId = datModificar.COD_ESTADO_DOC;
                    TH_VM.vmControlCalidad.txtUsuarioRegistro = datModificar.USUARIO_REGISTRO;
                    TH_VM.vmControlCalidad.txtUsuarioControl = datModificar.USUARIO_CONTROL;
                    TH_VM.vmControlCalidad.chkObsSubsanada = (bool)datModificar.OBSERV_SUBSANAR;
                    TH_VM.vmControlCalidad.txtControlCalidadObservaciones = datModificar.OBSERVACIONES_CONTROL.ToString();

                    //Dependencia Ubigeo              
                    TH_VM.ddlDependencia = Log_Helper.ListComboLlenar(datModificar.ListDependencia, "CODIGO", "DESCRIPCION", true);
                    TH_VM.ddlDependenciaId = datModificar.COD_DEPENDENCIA == "0" ? "-" : datModificar.COD_DEPENDENCIA.ToString();
                    //
                    TH_VM.hdfCodSecuencialAdenda = datModificar.COD_SECUENCIAL_ADENDA;

                    TH_VM.tbErrorMaterial_DGeneral = datModificar.ListErrorMaterialGeneral;
                    TH_VM.tbErrorMaterial_DAdicional = datModificar.ListErrorMaterialAdicional;
                    TH_VM.txtResolucionTitular = datModificar.RES_TITULAR;

                    TH_VM.txtEstado_TH = datModificar.ESTADO_TH;

                    TH_VM.ListTHExtincion = datModificar.ListTHExtincion;
                }

                //General
                TH_VM.lblObligacionContTitulo = "Obligaciones del concesionario";
                if (TH_VM.hdfItemModalidadCodigo == "0000011" || TH_VM.hdfItemModalidadCodigo == "0000012")
                {
                    TH_VM.lblObligacionContTitulo = "Obligaciones Contractuales";
                }
                TH_VM.lblAdendaTitulo = "Registro de adendas";
                if (TH_VM.hdfItemModalidadCodigo == "0000015" || TH_VM.hdfItemModalidadCodigo == "0000041" || TH_VM.hdfItemModalidadCodigo == "0000028")
                {
                    TH_VM.lblAdendaTitulo = "Registro de ampliación de vigencia del permiso";
                }
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return TH_VM;
        }
        public ListResult GuardarDatosThabilitante(VM_THabilitante dto, string codCuenta)
        {
            ListResult resultado = new ListResult();
            Ent_THABILITANTE oCampos = new CEntidad();
            String[] OUTPUTPARAM = null;
            string appServer = "";
            string msjRespuesta = "El Registro se Guardo Correctamente";
            //string oResultTransferir = "";//Cuando se transfiere un TH del Antecedente Expediente del SITD
            try
            {
                //THabilitante
                oCampos.COD_MTIPO = dto.hdfItemModalidadCodigo;
                oCampos.COD_TITULAR = dto.hdtxtTitularTipo;
                oCampos.COD_RLEGAL = dto.hdfItemRLegalCodigo;
                oCampos.NUMERO = dto.txtItemNumero == null ? "" : dto.txtItemNumero.Trim();
                oCampos.TIPO = dto.hdfItemTipo;
                oCampos.ESTAB_COD_UBIGEO = dto.hdfItemEstUbigeoCodigo;
                oCampos.ESTAB_SECTOR = dto.txtItemEstSector == null ? "" : dto.txtItemEstSector.Trim();
                oCampos.COD_UCUENTA = codCuenta;
                oCampos.OBSERVACION = dto.txtItemObservacion == null ? "" : dto.txtItemObservacion.Trim();
                oCampos.CLASE_ZOOLOGICO = dto.ddClaseZoologicoId == null ? "" : dto.ddClaseZoologicoId.Trim();
                oCampos.CODIGO_NUMERO = dto.txtCodigoNumero == null ? "" : dto.txtCodigoNumero.Trim();
                oCampos.COD_CAT= dto.txtCodCat;

                //Validando Estado
                oCampos.COD_THABILITANTE = "";
                oCampos.OUTPUTPARAM01 = "";
                oCampos.OUTPUTPARAM02 = "";
                oCampos.RegEstado = Int32.Parse(dto.hdfManRegEstado);
                oCampos.TIPO_NM = "";
                if (dto.hdfManRegEstado == "0") //Modificar
                {
                    oCampos.COD_THABILITANTE = dto.hdCodigo_Thabilitante;
                    msjRespuesta = "El Registro se Modifico Correctamente";
                }
                oCampos.AFUNCIONAMIENTO_COD_FUNCIONARIO = dto.hdfItemRAFFuncionarioCodigo;
                oCampos.APROYECTO_COD_FUNCIONARIO = dto.hdfItemRAPFuncionarioCodigo;
                if (dto.cod_Modalidad == "0000002")
                {//Fauna Exsitu
                    oCampos.APROYECTO_NUM_RESOL = dto.txtItemRAPNumero == null ? null : dto.txtItemRAPNumero.Trim();
                    oCampos.APROYECTO_FECHA = dto.txtItemRAPFecha == null ? null : dto.txtItemRAPFecha.Trim();
                    oCampos.AFUNCIONAMIENTO_NUM_RESOL = dto.txtItemRAFNumero == null ? null : dto.txtItemRAFNumero.Trim();
                    oCampos.AFUNCIONAMIENTO_FECHA = dto.txtItemRAFFecha == null ? null : dto.txtItemRAFFecha.Trim();
                    oCampos.CLASE_ZOOLOGICO = dto.ddClaseZoologicoId == null ? null : dto.ddClaseZoologicoId.Trim();
                }
                else
                {  //Datos Generales
                    oCampos.AREA_OTORGADA = Decimal.Parse((string.IsNullOrEmpty(dto.txtItemAOtorgada) ? "0" : dto.txtItemAOtorgada));
                    oCampos.CONTRADO_CONDICIONAL = dto.chkItemContCuenta;
                    oCampos.CONTRATO_FECHA_INICIO = dto.txtItemContFInicio == null ? null : dto.txtItemContFInicio.Trim();
                    oCampos.CONTRATO_FECHA_FIN = dto.txtItemContFFin == null ? null : dto.txtItemContFFin.Trim();
                }
                if (dto.cod_Modalidad == "0000005" || dto.cod_Modalidad == "0000009")
                { //Obligaciones Contractuales - Concesioens
                    if (dto.hdfItemModalidadCodigo == "0000011" || dto.hdfItemModalidadCodigo == "0000012")
                    {
                        oCampos.CARACTER_AMBIENTAL = dto.txtcaracter_ambiental == null ? null : dto.txtcaracter_ambiental.Trim();
                        oCampos.CARACTER_SOCIAL = dto.txtcaracter_social == null ? dto.txtcaracter_social : dto.txtcaracter_social.Trim();
                        oCampos.CARACTER_ERESPONSABLE = dto.txtcaracter_eresponsable == null ? null : dto.txtcaracter_eresponsable.Trim();
                    }
                    else
                    {
                        oCampos.OBLIGACIONES_CONCESIONARIOS = dto.txtConcesionario == null ? null : dto.txtConcesionario.Trim();
                    }
                }
                oCampos.COD_OD_REGISTRO = dto.ddlODRegistroId;
                //Lista de Objetos
                oCampos.ListTDTTITULARES = dto.ListTDTTITULARES;
                oCampos.ListTDDVVERTICE = dto.ListTDDVVERTICE;
                oCampos.ListTDDVADEAREA = dto.ListTDDVADEAREA;
                oCampos.ListAdendas = dto.ListAdendas;
                oCampos.ListEliTABLA = dto.ListEliTABLA; //cuando se elimina datos
                oCampos.ListModalidadesTH = dto.ListModalidadesTH;
                oCampos.ListTHEstadoEsta = dto.ListTHEstadoEsta;
                //Variables de control de calidad
                oCampos.COD_ESTADO_DOC = dto.vmControlCalidad.ddlIndicadorId;
                oCampos.OBSERVACIONES_CONTROL = dto.vmControlCalidad.txtControlCalidadObservaciones ?? "";
                oCampos.OBSERV_SUBSANAR = dto.vmControlCalidad.chkObsSubsanada;

                oCampos.CUENTA_PLAN_MANEJO = dto.chkItemPlanManejo;

                if (oCampos.COD_MTIPO == "0000020" || oCampos.COD_MTIPO == "0000021" || oCampos.COD_MTIPO == "0000005") //consultar
                {
                    oCampos.TIPO_NM = dto.ddTipoId;
                }
                // para el nivel de aprovechamiento
                oCampos.NIVEL_APROV = "";
                if (oCampos.COD_MTIPO == "0000015")
                {
                    oCampos.NIVEL_APROV = dto.ddNivelAproId;
                }

                if (oCampos.COD_MTIPO == "0000001" || oCampos.COD_MTIPO == "0000002" || oCampos.COD_MTIPO == "0000003" || oCampos.COD_MTIPO == "0000004" || oCampos.COD_MTIPO == "0000023")
                {
                    dto.txtCEsteZoo = string.IsNullOrEmpty(dto.txtCEsteZoo) ? "0" : dto.txtCEsteZoo.Trim();
                    dto.txtCNorteZoo = string.IsNullOrEmpty(dto.txtCNorteZoo) ? "0" : dto.txtCNorteZoo.Trim();
                    CEntidad oCamposDet = new CEntidad();
                    oCampos.ListTDDVVERTICE = oCampos.ListTDDVVERTICE ?? new List<CEntidad>();
                    if (oCampos.ListTDDVVERTICE.Count > 0)
                    {
                        oCampos.ListTDDVVERTICE[0].ZONA = dto.ddplZonaZooId;
                        oCampos.ListTDDVVERTICE[0].COORDENADA_ESTE = Int32.Parse(dto.txtCEsteZoo);
                        oCampos.ListTDDVVERTICE[0].COORDENADA_NORTE = Int32.Parse(dto.txtCNorteZoo);
                        oCampos.ListTDDVVERTICE[0].OBSERVACION = "VERTICES ZOOLOGICOS Y ZOOCRIADEROS";
                        oCampos.ListTDDVVERTICE[0].RegEstado = 2;
                    }
                    else
                    {
                        oCamposDet.ZONA = dto.ddplZonaZooId;
                        oCamposDet.COORDENADA_ESTE = Int32.Parse(dto.txtCEsteZoo);
                        oCamposDet.COORDENADA_NORTE = Int32.Parse(dto.txtCNorteZoo);
                        oCamposDet.OBSERVACION = "VERTICES ZOOLOGICOS Y ZOOCRIADEROS";
                        oCamposDet.VERTICE = "V1";
                        oCamposDet.COD_SECUENCIAL = 1;
                        oCamposDet.COD_SECUENCIAL_ADENDA = dto.hdfCodSecuencialAdenda;
                        oCamposDet.RegEstado = 1;
                        oCampos.ListTDDVVERTICE.Add(oCamposDet);
                    }

                }
                oCampos.COD_DEPENDENCIA = dto.ddlDependenciaId == "-" ? null : dto.ddlDependenciaId;
                oCampos.RES_TITULAR = dto.txtResolucionTitular;

                oCampos.ListErrorMaterialGeneral = dto.tbErrorMaterial_DGeneral;
                oCampos.ListErrorMaterialAdicional = dto.tbErrorMaterial_DAdicional;

                //agregamos las listas de extencion
                oCampos.ListTHExtincion = (List<Ent_THABILITANTE>)dto.ListTHExtincion;
                oCampos.ListEliTABLAExt = dto.ListEliTABLAExt;
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    OracleTransaction tr = cn.BeginTransaction();
                    try
                    {
                        //Grabando Base Datos.
                        OUTPUTPARAM = oCDatos.RegGrabarV3(cn, oCampos, tr).Split('|');

                        if (dto.appClient == null)
                        {
                            dto.appClient = "";
                            dto.appData = "";
                        }
                        if (dto.appClient != "" && dto.appClient.Split('|')[1] == "TRANSFERIR")
                        {
                            if (dto.appClient.Split('|')[0] == "SIGOsfc_VentanillaSITD")
                            {
                                CapaEntidad.DOC.Ent_ANTECEDENTE_EXPEDIENTE oParamsAExpedienteSitd = new CapaEntidad.DOC.Ent_ANTECEDENTE_EXPEDIENTE();
                                oParamsAExpedienteSitd.COD_AEXPEDIENTE_SITD = Convert.ToInt32(dto.appData.Split('¬')[0]);
                                oParamsAExpedienteSitd.COD_TRAMITE_SITD = Convert.ToInt32(dto.appData.Split('¬')[1]);

                                if (dto.appClient.Split('|')[2] == "ADENDA")
                                {
                                    oParamsAExpedienteSitd.TIPO = "TRANSFERIR"; oParamsAExpedienteSitd.SUBTIPO = "ADENDA";
                                    oParamsAExpedienteSitd.ESTADO_AEXPEDIENTE = "Transferido";
                                    oParamsAExpedienteSitd.OBSERVACION = dto.appData.Split('¬')[4];
                                }
                                else
                                {
                                    //Grabar dato de la transferencia
                                    oParamsAExpedienteSitd.TIPO = "TRANSFERIR"; oParamsAExpedienteSitd.SUBTIPO = "THABILITANTE";
                                    oParamsAExpedienteSitd.COD_THABILITANTE = OUTPUTPARAM[0];
                                    oParamsAExpedienteSitd.NUM_THABILITANTE = dto.txtItemNumero;
                                    oParamsAExpedienteSitd.ESTADO_AEXPEDIENTE = dto.appData.Split('¬')[2] == "0101" ? "Transferido" : "Pendiente";//0101: Código documento autoridad (TH) SITD
                                    oParamsAExpedienteSitd.OBSERVACION = dto.appData.Split('¬')[5];
                                    if (oParamsAExpedienteSitd.NUM_THABILITANTE != dto.appData.Split('¬')[3]) oParamsAExpedienteSitd.RegEstado = 2;//Datos del SITD modificado
                                }
                                oParamsAExpedienteSitd.COD_UCUENTA = codCuenta;
                                oParamsAExpedienteSitd.OUTPUTPARAM01 = "";
                                oParamsAExpedienteSitd.ORIGEN_REGISTRO = 1;//ORIGEN SITD
                                CapaDatos.DOC.Dat_ANTECEDENTE_EXPEDIENTE datAntecedentes = new CapaDatos.DOC.Dat_ANTECEDENTE_EXPEDIENTE();
                                //oResultTransferir = datAntecedentes.RegGrabarV3(cn, oParamsAExpedienteSitd, tr);
                                datAntecedentes.RegGrabarV3(cn, oParamsAExpedienteSitd, tr);
                                appServer = "2";
                            }
                            else
                            {
                                //CapaEntidad.DOC.Ent_AEXPEDIENTE_INTEROP oParams = new CapaEntidad.DOC.Ent_AEXPEDIENTE_INTEROP();
                                //CapaLogica.DOC.Log_AEXPEDIENTE_INTEROP oLogAEI = new CapaLogica.DOC.Log_AEXPEDIENTE_INTEROP();
                                //oParams.COD_AEXPEDIENTE_INTEROP = dto.appData.Split('¬')[0];
                                //oParams.COD_THABILITANTE = OUTPUTPARAM[0];
                                //oParams.ESTADO_AEXPEDIENTE = "Transferido";
                                //oParams.OBSERVACION_TRANSFERIR = dto.appData.Split('¬')[8];
                                //oParams.COD_UCUENTA = codCuenta;
                                //oParams.OUTPUTPARAM01 = "";
                                //CapaDatos.DOC.Dat_AEXPEDIENTE_INTEROP datAntecedentesInter = new CapaDatos.DOC.Dat_AEXPEDIENTE_INTEROP();
                                //datAntecedentesInter.RegGrabarV3(cn, oParams, tr);
                                appServer = "2";//"ManVentanillaAExpedienteInteroperabilidad.aspx                              
                            }
                        }
                        else if (dto.appClient != "" && dto.appClient.Split('|')[1] == "VISUALIZAR")
                        {
                            if (dto.appClient.Split('|')[0] == "SIGOsfc_VentanillaSITD")
                            {
                                appServer = "2";//ManVentanillaAntecedentesExpedientes                               
                            }
                            else
                            {
                                appServer = "2";//ManVentanillaAExpedienteInteroperabilidad.aspx                                 
                            }
                        }
                        tr.Commit();
                    }
                    catch (Exception ex)
                    {
                        if (tr != null)
                        {
                            tr.Rollback();
                            tr.Dispose();
                        }

                        throw ex;
                    }
                }

                resultado.appServer = appServer;
                resultado.AddResultado(msjRespuesta, true);
            }
            catch (Exception ex)
            {
                if (dto.appClient == null)
                {
                    dto.appClient = "";
                    dto.appData = "";
                }
                if (dto.appClient != "" && dto.appClient.Split('|')[1] == "TRANSFERIR")
                {
                    appServer = "1|" + ex.Message;
                }
                else if (dto.appClient != "" && dto.appClient.Split('|')[1] == "VISUALIZAR")
                {
                    appServer = "1|" + ex.Message;
                }
                resultado.appServer = appServer;
                resultado.AddResultado(ex.Message , false);
                //resultado.AddResultado("Ocurri� un error en el registro, por favor de verificar los datos e intente de nuevo", false);
            }
            return resultado;
        }
        public string ObtenerCodigoFormulario(string BusFormulario)
        {
            string codFormulario = "";
            switch (BusFormulario)
            {
                case "TITULO_HABILITANTE": codFormulario = "0000001"; break;
                case "POA": codFormulario = "0000002"; break;
                case "PLAN_MANEJO": codFormulario = "0000003"; break;
                case "BITACORA_SUPER": codFormulario = "0000025"; break;
                case "ALERTA_OSINFOR": codFormulario = "0000026"; break;
                case "CARTA_NOTIFICACION": codFormulario = "0000004"; break;
                case "INFORME_SUPERVISION": codFormulario = "0000005"; break;
                case "INFORME_AUT_FORESTAL": codFormulario = "0000021"; break;
                case "RENUNCIA_CONCESION": codFormulario = "0000027"; break;
                case "OTROS_INFORMES": codFormulario = "0000028"; break;
                case "DEVOLUCION_MADERA": codFormulario = "0000007"; break;
                case "INFORME_SUSPENSION": codFormulario = "0000006"; break;
                case "INFORME_CANCELACION": codFormulario = "0000029"; break;
                case "INFORMACION_TITULAR": codFormulario = "0000014"; break;
                case "DOC_REM_OTRA_INST": codFormulario = "0000015"; break;
                case "SOL_INTERNA": codFormulario = "0000016"; break;
                case "INFORME_LEGAL": codFormulario = "0000009"; break;
                case "RESOLUCION_DIRECTORAL": codFormulario = "0000010"; break;
                case "INFORME_TECNICO": codFormulario = "0000011"; break;
                case "INFORME_TECNICO_EV": codFormulario = "0000011"; break;
                case "INFORME_FUNDAMENTADO": codFormulario = "0000012"; break;
                case "FIS_NOTIFICACION": codFormulario = "0000013"; break;
                case "SOL_EXTERNA": codFormulario = "0000017"; break;
                case "PROVEIDO": codFormulario = "0000018"; break;
                case "PROVEIDO_ARCHIVO": codFormulario = "0000019"; break;
                case "CAPACITACION": codFormulario = "0000020"; break;
                case "OTROS_EVENTOS": codFormulario = "0000048"; break;
                case "GUIA_TRANSPORTE": codFormulario = "0000023"; break;
                case "ACTIVIDAD": codFormulario = "0000030"; break;
                case "ACTIVIDADOCI": codFormulario = "0000031"; break;
                case "ACTIVIDADOFI": codFormulario = "0000047"; break;
                case "PRECIO_ESPECIES": codFormulario = "0000032"; break;
                case "TFFS": codFormulario = "0000022"; break;
                case "REUNION": codFormulario = "0000033"; break;
                case "INFORME QUINQUENAL": codFormulario = "0000034"; break;
                case "PLAN_GENERAL_MANEJO_FORESTAL": codFormulario = "0000035"; break;
                case "CRONOGRAMA_SUPERVISION": codFormulario = "0000036"; break;
                case "PERSONA": codFormulario = "0000037"; break;
                case "USUARIO": codFormulario = "0000038"; break;
                case "DEMA": codFormulario = "0000039"; break;
                case "PROGRAMA_CAPACITACION": codFormulario = "0000040"; break;
                case "IMEDIDA": codFormulario = "0000041"; break;
            }
            return codFormulario;
        }
        public string ObtenerTipoVista(string idModulo, int idMenu)
        {
            string retornoVista = "";
            switch (idModulo)
            {
                case "0000001":
                    switch (idMenu)
                    {   //representa su codigo secuencial
                        case 1:
                            retornoVista = "TITULO_HABILITANTE";
                            break;
                        case 3:
                            retornoVista = "POA";
                            break;
                        case 2:
                            retornoVista = "PLAN_MANEJO";
                            break;
                        case 4:
                            retornoVista = "CARTA_NOTIFICACION";
                            break;
                        case 5:
                            retornoVista = "INFORME_SUPERVISION";
                            break;
                        case 6:
                            retornoVista = "INFORME_LEGAL";
                            break;
                        case 10:
                            retornoVista = "RESOLUCION_DIRECTORAL";
                            break;
                        case 12:
                            retornoVista = "INFORME_TECNICO";
                            break;
                        case 19:
                            retornoVista = "INFORME_FUNDAMENTADO";
                            break;
                        case 20:
                            retornoVista = "FIS_NOTIFICACION";
                            break;
                        case 21:
                            retornoVista = "INFORMACION_TITULAR";
                            break;
                        case 24:
                            retornoVista = "INFORME_SUSPENSION";
                            break;
                        case 28:
                            retornoVista = "SOL_INTERNA";
                            break;
                        case 30:
                            retornoVista = "SOL_EXTERNA";
                            break;
                        case 32:
                            retornoVista = "DOC_REM_OTRA_INST";
                            break;
                        case 33:
                            retornoVista = "PROVEIDO";
                            break;
                        case 34:
                            retornoVista = "PROVEIDO_ARCHIVO";
                            break;
                        case 35:
                            retornoVista = "DEVOLUCION_MADERA";
                            break;
                        case 37:
                            retornoVista = "CAPACITACION";
                            break;
                        case 111:
                            retornoVista = "INFORME_AUT_FORESTAL";
                            break;
                        case 113:
                            retornoVista = "";
                            break;
                        case 114:
                            retornoVista = "GUIA_TRANSPORTE";
                            break;
                        case 122:
                            retornoVista = "INFORME_CANCELACION";
                            break;
                        case 141:
                            retornoVista = "TFFS";
                            break;
                        case 157:
                            retornoVista = "BITACORA_SUPER";
                            break;
                        case 160:
                            retornoVista = "ALERTA_OSINFOR";
                            break;
                        case 165:
                            retornoVista = "PLAN_GENERAL_MANEJO_FORESTAL";
                            break;
                        case 166:
                            retornoVista = "GESTION_ESPECIES";
                            break;
                        case 167:
                            retornoVista = "CRONOGRAMA_SUPERVISION";
                            break;
                        case 168:
                            retornoVista = "PERSONA";
                            break;
                        case 169:
                            retornoVista = "USUARIO";
                            break;
                        case 171:
                            retornoVista = "DEMA";
                            break;
                        case 176:
                            retornoVista = "INFORME QUINQUENAL";
                            break;
                        case 182:
                            retornoVista = "";
                            break;

                    }
                    break;
                case "0000002":
                    switch (idMenu)
                    {
                        case 124:
                            retornoVista = "";
                            break;
                        case 125:
                            retornoVista = "";
                            break;
                        case 130:
                            retornoVista = "";
                            break;
                        case 135:
                            retornoVista = "";
                            break;
                        case 165:
                            break;
                    }
                    break;
            }
            return retornoVista;
        }
        public List<String[]> ListarTHabilitante(String formulario, String criterio, String valor, CapaEntidad.GENE.Ent_AUDITORIA auditoria)
        {
            Log_BUSQUEDA oCLogica = new Log_BUSQUEDA();
            List<String[]> Retorno = new List<String[]>();
            List<Ent_BUSQUEDA> lista = new List<Ent_BUSQUEDA>();
            Ent_BUSQUEDA oCampos = new Ent_BUSQUEDA();
            String codFormulario = "";
            oCampos.BusFormulario = formulario;
            oCampos.BusCriterio = criterio;
            oCampos.BusValor = valor;
            lista = oCLogica.RegMostrarLista(oCampos);
            switch (formulario)
            {
                case "TITULO_HABILITANTE":
                    codFormulario = "0000001";
                    foreach (var item in lista)
                    {
                        Retorno.Add(new String[] { item.CODIGO, item.PARAMETRO10, item.PARAMETRO01, item.NUMERO, item.PARAMETRO02, item.PARAMETRO03, item.PARAMETRO04 });
                    }
                    break;
                case "POA":
                    codFormulario = "0000002";
                    foreach (var item in lista)
                    {
                        Retorno.Add(new String[] {
                            "", "",   item.PARAMETRO09, item.PARAMETRO01,item.PARAMETRO02,
                            item.PARAMETRO03,item.PARAMETRO05, item.PARAMETRO06, item.PARAMETRO07,item.PARAMETRO04,
                            item.PARAMETRO08,item.CODIGO, item.NUMERO,item.PARAMETRO10
                            });
                    }
                    break;


                case "DEMA":
                    codFormulario = "0000039";
                    foreach (var item in lista)
                    {
                        Retorno.Add(new String[] {
                            "", "",   item.PARAMETRO09, item.PARAMETRO01,item.PARAMETRO02,
                            item.PARAMETRO03,item.PARAMETRO05, item.PARAMETRO06, item.PARAMETRO07,item.PARAMETRO04,
                            item.PARAMETRO08,item.CODIGO, item.NUMERO,item.PARAMETRO10
                            });
                    }
                    break;

                case "PLAN_MANEJO":
                    break;
                case "BITACORA_SUPER":
                    foreach (var item in lista)
                    {
                        Retorno.Add(new String[] { "", item.PARAMETRO06, item.PARAMETRO01, item.PARAMETRO03, item.NUMERO, item.PARAMETRO02, item.PARAMETRO04, item.PARAMETRO05 });
                    }
                    break;
                case "ALERTA_OSINFOR":
                    foreach (var item in lista)
                    {
                        Retorno.Add(new String[] { "", item.PARAMETRO06, item.PARAMETRO01, item.PARAMETRO03, item.NUMERO, item.PARAMETRO02, item.PARAMETRO04, item.PARAMETRO05, item.PARAMETRO07 });
                    }
                    break;
                case "CARTA_NOTIFICACION":
                    foreach (var item in lista)
                    {
                        Retorno.Add(new String[] { "", item.PARAMETRO01, item.NUMERO, item.PARAMETRO02, item.PARAMETRO03, item.PARAMETRO04, item.PARAMETRO05, item.PARAMETRO07, item.PARAMETRO08, item.PARAMETRO09, item.PARAMETRO10, item.PARAMETRO11, item.PARAMETRO12 });
                    }
                    break;
                case "INFORME_SUPERVISION":
                    foreach (var item in lista)
                    {
                        Retorno.Add(new String[] { "", item.PARAMETRO10, item.NUMERO, item.PARAMETRO01, item.PARAMETRO02, item.PARAMETRO03, item.PARAMETRO09, item.PARAMETRO04, item.PARAMETRO11, item.PARAMETRO12 });
                    }
                    break;
                case "INFORME_AUT_FORESTAL":
                    foreach (var item in lista)
                    {
                        Retorno.Add(new String[] { "", item.PARAMETRO10, item.NUMERO, item.PARAMETRO01, item.PARAMETRO02, item.PARAMETRO03, item.PARAMETRO04, item.PARAMETRO05 });
                    }
                    break;
                case "RENUNCIA_CONCESION":
                    foreach (var item in lista)
                    {
                        Retorno.Add(new String[] { "", item.PARAMETRO10, item.NUMERO, item.PARAMETRO01, item.PARAMETRO02, item.PARAMETRO03, item.PARAMETRO04 });
                    }
                    break;
                case "OTROS_INFORMES":
                    foreach (var item in lista)
                    {
                        Retorno.Add(new String[] { "", item.PARAMETRO10, item.NUMERO, item.PARAMETRO06, item.PARAMETRO02, item.PARAMETRO03, item.PARAMETRO04, item.PARAMETRO05 });
                    }
                    break;
                case "DEVOLUCION_MADERA":
                    foreach (var item in lista)
                    {
                        Retorno.Add(new String[] { "", item.PARAMETRO10, item.NUMERO, item.PARAMETRO07, item.PARAMETRO06 });
                    }
                    break;
                case "INFORME_SUSPENSION":
                    foreach (var item in lista)
                    {
                        Retorno.Add(new String[] { "", item.PARAMETRO10, item.NUMERO, item.PARAMETRO01, item.PARAMETRO02, item.PARAMETRO04, item.PARAMETRO07 });
                    }
                    break;
                case "INFORME_CANCELACION":
                    foreach (var item in lista)
                    {
                        Retorno.Add(new String[] { "", item.PARAMETRO10, item.NUMERO, item.PARAMETRO01, item.PARAMETRO02, item.PARAMETRO04 });
                    }
                    break;
                case "INFORMACION_TITULAR":
                    foreach (var item in lista)
                    {
                        Retorno.Add(new String[] { "", item.PARAMETRO10, item.NUMERO, item.PARAMETRO01, item.PARAMETRO02, item.PARAMETRO04, item.PARAMETRO05, item.PARAMETRO06, item.PARAMETRO07 });
                    }
                    break;
                case "DOC_REM_OTRA_INST":
                    foreach (var item in lista)
                    {
                        Retorno.Add(new String[] { "", item.PARAMETRO10, item.NUMERO, item.PARAMETRO01, item.PARAMETRO03 });
                    }
                    break;
                case "SOL_INTERNA":
                    foreach (var item in lista)
                    {
                        Retorno.Add(new String[] { "", item.PARAMETRO10, item.NUMERO, item.PARAMETRO01, item.PARAMETRO02, item.PARAMETRO03 });
                    }
                    break;
                case "INFORME_LEGAL":
                    foreach (var item in lista)
                    {
                        Retorno.Add(new String[] { "", item.PARAMETRO10, item.NUMERO, item.PARAMETRO02, item.PARAMETRO03, item.PARAMETRO04, item.PARAMETRO06 });
                    }
                    break;
                case "RESOLUCION_DIRECTORAL":
                    foreach (var item in lista)
                    {
                        Retorno.Add(new String[] { "", item.PARAMETRO10, item.NUMERO, item.PARAMETRO01, item.PARAMETRO03, item.PARAMETRO05 });
                    }
                    break;
                case "INFORME_TECNICO":
                    foreach (var item in lista)
                    {
                        Retorno.Add(new String[] { "", item.PARAMETRO10, item.NUMERO, item.PARAMETRO01, item.PARAMETRO04, item.PARAMETRO05 });
                    }
                    break;
                case "INFORME_FUNDAMENTADO":
                    foreach (var item in lista)
                    {
                        Retorno.Add(new String[] { "", item.PARAMETRO10, item.NUMERO, item.PARAMETRO01, item.PARAMETRO04, item.PARAMETRO05 });
                    }
                    break;
                case "FIS_NOTIFICACION":
                    foreach (var item in lista)
                    {
                        Retorno.Add(new String[] { "", item.PARAMETRO10, item.NUMERO, item.PARAMETRO01, item.PARAMETRO04, item.PARAMETRO05, item.PARAMETRO06, item.PARAMETRO07, item.PARAMETRO08 });
                    }
                    break;
                case "SOL_EXTERNA":
                    foreach (var item in lista)
                    {
                        Retorno.Add(new String[] { "", item.PARAMETRO10, item.NUMERO, item.PARAMETRO01, item.PARAMETRO02, item.PARAMETRO03, item.PARAMETRO06 });
                    }
                    break;
                case "PROVEIDO":
                    foreach (var item in lista)
                    {
                        Retorno.Add(new String[] { "", item.PARAMETRO06, item.PARAMETRO03, item.PARAMETRO04, item.PARAMETRO05, item.PARAMETRO07, item.PARAMETRO09, item.PARAMETRO08 });
                    }
                    break;
                case "PROVEIDO_ARCHIVO":
                    foreach (var item in lista)
                    {
                        Retorno.Add(new String[] { "", item.PARAMETRO02, item.PARAMETRO05, item.PARAMETRO06, item.PARAMETRO01 });
                    }
                    break;
                case "CAPACITACION":
                    foreach (var item in lista)
                    {
                        Retorno.Add(new String[] { "", item.PARAMETRO10, item.NUMERO, item.PARAMETRO04, item.PARAMETRO02, item.PARAMETRO05, item.PARAMETRO03, item.PARAMETRO06 });
                    }
                    break;
                case "PROGRAMA_CAPACITACION":
                    foreach (var item in lista)
                    {
                        Retorno.Add(new String[] { item.CODIGO, item.PARAMETRO01, item.PARAMETRO02, item.PARAMETRO04, item.PARAMETRO05, item.PARAMETRO10 });
                    }
                    break;
                case "GUIA_TRANSPORTE":
                    foreach (var item in lista)
                    {
                        Retorno.Add(new String[] { "", item.PARAMETRO10, item.NUMERO, item.PARAMETRO01, item.PARAMETRO03, item.PARAMETRO04, item.PARAMETRO02, item.PARAMETRO06, item.PARAMETRO07, item.PARAMETRO05 });
                    }
                    break;
                case "ACTIVIDAD":
                    foreach (var item in lista)
                    {
                        Retorno.Add(new String[] { "", item.NUMERO, item.PARAMETRO11, item.PARAMETRO02, item.PARAMETRO03, item.PARAMETRO04, item.PARAMETRO06, item.PARAMETRO09, item.PARAMETRO07, item.PARAMETRO05, item.PARAMETRO08 });
                    }
                    break;
                case "ACTIVIDADOCI":
                    foreach (var item in lista)
                    {
                        Retorno.Add(new String[] { "", item.NUMERO, item.PARAMETRO01, item.PARAMETRO11, item.PARAMETRO02, item.PARAMETRO03, item.PARAMETRO04, item.PARAMETRO06, item.PARAMETRO09, item.PARAMETRO07, item.PARAMETRO05, item.PARAMETRO08 });
                    }
                    break;
                case "PRECIO_ESPECIES":
                    foreach (var item in lista)
                    {
                        Retorno.Add(new String[] { "", item.CODIGO, item.NUMERO, item.PARAMETRO01, item.PARAMETRO02, item.PARAMETRO03, item.PARAMETRO04 });
                    }
                    break;
                case "TFFS":
                    foreach (var item in lista)
                    {
                        Retorno.Add(new String[] { "", item.PARAMETRO04, item.NUMERO, item.PARAMETRO01, item.PARAMETRO02, item.PARAMETRO03 });
                    }
                    break;
                case "REUNION":
                    foreach (var item in lista)
                    {
                        Retorno.Add(new String[] { "", item.NUMERO, item.PARAMETRO01, item.PARAMETRO06, item.PARAMETRO02, item.PARAMETRO03, item.PARAMETRO04, item.PARAMETRO05 });
                    }
                    break;
                case "PLAN_GENERAL_MANEJO_FORESTAL":
                    codFormulario = "0000035";
                    foreach (var item in lista)
                    {
                        Retorno.Add(new String[] { item.CODIGO, item.PARAMETRO01, item.NUMERO, item.PARAMETRO02, item.PARAMETRO03 });
                    }
                    break;
                case "PLAN_MANEJO_FORESTAL_INTERMEDIO":
                    codFormulario = "0000035";
                    foreach (var item in lista)
                    {
                        Retorno.Add(new String[] { item.CODIGO, item.PARAMETRO01, item.NUMERO, item.PARAMETRO02, item.PARAMETRO03 });
                    }
                    break;
                case "CRONOGRAMA_SUPERVISION":
                    foreach (var item in lista)
                    {
                        Retorno.Add(new String[] { "", item.PARAMETRO01, item.NUMERO, item.PARAMETRO02, item.PARAMETRO03, item.PARAMETRO04, item.PARAMETRO05, item.PARAMETRO06, item.PARAMETRO07, item.PARAMETRO08 });
                    }
                    break;
                case "PERSONA":
                    foreach (var item in lista)
                    {
                        Retorno.Add(new String[] { "", item.PARAMETRO01, item.PARAMETRO02, item.PARAMETRO03, item.PARAMETRO04 });
                    }
                    break;
                case "USUARIO":
                    foreach (var item in lista)
                    {
                        Retorno.Add(new String[] { "", item.PARAMETRO01, item.PARAMETRO02, item.PARAMETRO03, item.PARAMETRO04 });
                    }
                    break;
                case "INFORME QUINQUENAL":
                    foreach (var item in lista)
                    {
                        Retorno.Add(new String[] { "", item.PARAMETRO01, item.NUMERO, item.PARAMETRO02, item.PARAMETRO03 });
                    }
                    break;
                case "PMFI":
                    codFormulario = "0000050";
                    foreach (var item in lista)
                    {
                        Retorno.Add(
                            new String[] {
                                string.Empty,
                                string.Empty,
                                item.PARAMETRO09,
                                item.PARAMETRO01,
                                item.PARAMETRO02,
                                item.PARAMETRO05,
                                item.PARAMETRO06,
                                item.PARAMETRO07,
                                item.PARAMETRO04,
                                item.PARAMETRO08,
                                item.CODIGO,
                                item.NUMERO,
                                item.PARAMETRO10,
                            });

                        //Retorno.Add(new String[] {
                        //    "", "",   item.PARAMETRO09, item.PARAMETRO01,item.PARAMETRO02,
                        //    item.PARAMETRO03,item.PARAMETRO05, item.PARAMETRO06, item.PARAMETRO07,item.PARAMETRO04,
                        //    item.PARAMETRO08,item.CODIGO, item.NUMERO,item.PARAMETRO10
                        //    });
                        //FECHA,POA,ARESOLUCION_NUM,POA_PADRE,MODALIDAD,TITULAR,NUM_THABILITANTE,COD_MTIPO,ESTADO_ORIGEN,CODIGO,NUMERO,INDICADOR
                    }
                    //fecha,POA/PO,Res. de Aprobaci�n,Modalidad,Titular,T�tulo Habilitante
                    //PARAMETRO09,PARAMETRO01,PARAMETRO02,PARAMETRO05,PARAMETRO06,PARAMETRO07
                    //foreach (var item in lista)
                    //{
                    //    Retorno.Add(new String[] { item.CODIGO, item.NUMERO, item.PARAMETRO01, item.PARAMETRO02, item.PARAMETRO03, item.PARAMETRO04, item.PARAMETRO05, item.PARAMETRO06, item.PARAMETRO07, item.PARAMETRO08, item.PARAMETRO09, item.PARAMETRO10 });

                    //    //Retorno.Add(new String[] { item.CODIGO, item.NUMERO, item.PARAMETRO01, item.PARAMETRO02, item.PARAMETRO03, item.PARAMETRO04, item.PARAMETRO05, item.PARAMETRO06, item.PARAMETRO07, item.PARAMETRO08, item.PARAMETRO09, item.PARAMETRO10, item.PARAMETRO11, item.PARAMETRO12});
                    //}
                    break;
            }
            string camposAfectados = "CRITERIO=" + criterio.Trim() + ";SEARCH_STRING=" + valor.Trim();
            oCLogica.logRegistroAccion(codFormulario, auditoria.ipServer, auditoria.hostName, auditoria.ipCliente, camposAfectados, "SEARCH", auditoria.codCuentaUsuario);
            return Retorno;
        }
        //codigoPerona:codigo de la persona a registrar o registrada
        public VM_Persona iniciarRegistroPeronaNJ(string codigoPerona, string cod_ucuenta, string tipoPerona, string persona_Tipo)
        {
            VM_Persona objLogPersona;
            try
            {
                objLogPersona = new VM_Persona();
                if (tipoPerona.Equals("N") || persona_Tipo.Equals("0000006")) //0000006 - FUNCIONARIO
                {
                    CEntidad oCampos = new CEntidad();
                    oCampos.COD_UCUENTA = cod_ucuenta;
                    oCampos.BusFormulario = "TITULO_HABILITANTE";
                    oCampos.BusCriterio = "TIPO_DOCUMENTO_IDENTIDAD";
                    oCampos = RegMostComboV3(oCampos);
                    objLogPersona.ddlItemPN_DITipo = oCampos.ListMComboDIdentidad.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION });
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objLogPersona;
        }
        public List<CEntidad> ListarVerticeTHabilitante(string COD_THABILITANTE)
        {
            CEntidad oCEntidad = new CEntidad();
            oCEntidad.COD_THABILITANTE = COD_THABILITANTE;
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.ListarVerticeTHabilitante(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        //Persona Natural
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="oCampoEntrada"></param>
        ///// <returns></returns>
        //public String RegPNaturalGrabar(CEntidad oCampoEntrada)
        //{
        //    try
        //    {
        //        using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
        //        {
        //            cn.Open();
        //            return oCDatos.RegPNaturalGrabar(cn, oCampoEntrada);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="oCampoEntrada"></param>
        ///// <returns></returns>
        //public CEntidad RegPNaturalBuscar(CEntidad oCampoEntrada)
        //{
        //    try
        //    {
        //        using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
        //        {
        //            cn.Open();
        //            return oCDatos.RegPNaturalBuscar(cn, oCampoEntrada);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //
        //Persona Juridico
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="oCampoEntrada"></param>
        ///// <returns></returns>
        //public String RegPJuridicoGrabar(CEntidad oCampoEntrada)
        //{
        //    try
        //    {
        //        using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
        //        {
        //            cn.Open();
        //            return oCDatos.RegPJuridicoGrabar(cn, oCampoEntrada);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="oCampoEntrada"></param>
        ///// <returns></returns>
        //public CEntidad RegPJuridicoBuscar(CEntidad oCampoEntrada)
        //{
        //    try
        //    {
        //        using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
        //        {
        //            cn.Open();
        //            return oCDatos.RegPJuridicoBuscar(cn, oCampoEntrada);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //
        //PopupBuscador
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="oCEntidad"></param>
        ///// <returns></returns>
        //public List<CEntidad> RegPopupBuscar(CEntidad oCEntidad)
        //{
        //    try
        //    {
        //        using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
        //        {
        //            cn.Open();
        //            return oCDatos.RegPopupBuscar(cn, oCEntidad);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="oCampoEntrada"></param>
        ///// <returns></returns>
        //public String RegPopupGrabar(CEntidad oCampoEntrada)
        //{
        //    try
        //    {
        //        using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
        //        {
        //            cn.Open();
        //            return oCDatos.RegPopupGrabar(cn, oCampoEntrada);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

    }
}
