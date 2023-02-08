using CapaEntidad.ViewModel;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
//using System.Data;
//using System.Data.SqlClient;
//using System.IO;
//using System.Linq;
using CDatos = CapaDatos.DOC.Dat_GuiaTransporte;
using CEntidad = CapaEntidad.DOC.Ent_GUIA_TRANSPORTE;
using CentidadView = CapaEntidad.DOC.Ent_PreVisualizar;
using VModel = CapaEntidad.ViewModel.VM_GuiaTransporte;
using VModelProducto = CapaEntidad.ViewModel.VM_GuiaTransporte_Producto;

namespace CapaLogica.DOC
{
    public class Log_GuiaTransporte
    {
        private CDatos oCDatos = new CDatos();
        //String RutaGTFs = "~/Archivos/Archivo_GTF/";

        //grabar el registro de guia de transporte
        //public String RegGrabar(CEntidad oCampoEntrada)
        //{
        //    try
        //    {
        //        using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
        //        {
        //            cn.Open();
        //            return oCDatos.RegGrabar(cn, oCampoEntrada);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        public String RegGrabarV3(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegGrabarv3(cn, oCampoEntrada);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<CentidadView> RegBuscarInexistencias(CentidadView oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegBuscarInexistencias(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //lista para la busqueda del thabilitante

        //public List<CEntidad> RegMostrarTHLista(CEntidad oCEntidad)
        //{
        //    try
        //    {
        //        using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
        //        {
        //            cn.Open();
        //            return oCDatos.RegMostrarTHLista(cn, oCEntidad);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        //public CEntidad RegMostCombo(CEntidad oCampoEntrada)
        //{
        //    try
        //    {
        //        using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
        //        {
        //            cn.Open();
        //            return oCDatos.RegMostCombo(cn, oCampoEntrada);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        public CEntidad RegMostComboProducto(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegMostComboProducto(cn, oCampoEntrada);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public CEntidad RegMostrarListaItems(CEntidad oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegMostrarListaItems(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //public List<CentidadView> RegMostrarTHPreViewLista(CentidadView oCEntidad)
        //{
        //    try
        //    {
        //        using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
        //        {
        //            cn.Open();
        //            return oCDatos.RegMostrarTHPreViewLista(cn, oCEntidad);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        public List<CentidadView> RegMostrarTHPOA(CentidadView oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegMostrarTHPOA(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //notificaciones

        public List<CentidadView> RegMostrarNotificaciones(CentidadView oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegMostrarNotificaciones(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //sanciones items
        public List<CentidadView> RegMostrarItemsSansion(CentidadView oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegMostrarItemsSansion(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<CentidadView> RegMostrarBExtraccion(CentidadView oCEntidad)
        {
            try
            {
                using ( OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegMostrarBExtraccion(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region "Migracion - SIGO v3"
        public VModel IniDatos(string codigo, string codigoComplementario, string cod_cuenta, string cod_ugrupo, int nuevo, string tipoFrmulario)
        {
            VModel viewModel;
            try
            {
                viewModel = new VModel();
                viewModel.TipoFormulario = tipoFrmulario;
                viewModel.codUGrupo = cod_ugrupo;

                if (nuevo == 1) //iniciar nuevo item
                {


                    LlenarCombos(ref viewModel, cod_cuenta, tipoFrmulario);
                    CEntidad oCampos = new CEntidad();
                    viewModel.ListProducto = new List<CEntidad>();
                    viewModel.hdfManRegEstado = "1";



                }
                if (nuevo == 0) //editar
                {
                    //Cargando datos
                    LlenarCombos(ref viewModel, cod_cuenta, tipoFrmulario);
                    CEntidad oCampos = new CEntidad();
                    oCampos.COD_GUIA_TRANS = codigo;
                    CEntidad CEntidadGuiaTemp = new CEntidad();
                    CEntidadGuiaTemp = RegMostrarListaItems(oCampos);
                    CEntidadGuiaTemp.listProductoEli = new List<CEntidad>();

                    viewModel.COD_GUIA_TRANS = CEntidadGuiaTemp.COD_GUIA_TRANS;
                    viewModel.txtNumPOA = CEntidadGuiaTemp.NUM_POA == 0 ? "" : CEntidadGuiaTemp.NUM_POA.ToString();
                    viewModel.txtSede = CEntidadGuiaTemp.SEDE;
                    viewModel.txtNumGuia = CEntidadGuiaTemp.NUMERO_GUIA_TRANS;
                    viewModel.txtNomGuia = CEntidadGuiaTemp.NOMBRE_GUIA_TRANS;
                    viewModel.txtItemFechaExp = CEntidadGuiaTemp.FECHA_EXPEDICION.ToString();
                    viewModel.txtItemFechaVen = CEntidadGuiaTemp.FECHA_VENCIMIENTO.ToString();
                    viewModel.hdfItemCodTHabilitante = CEntidadGuiaTemp.COD_THABILITANTE;
                    viewModel.txtItemTituloHabilitante = CEntidadGuiaTemp.TITULO;
                    viewModel.hdfCodTitularHab = CEntidadGuiaTemp.COD_TITULAR;
                    viewModel.hdfItemEstUbigeoCodigo = CEntidadGuiaTemp.UBIGEO_TH;
                    viewModel.lblItemEstUbigeo = CEntidadGuiaTemp.UBIGEO_NAMETH;
                    viewModel.txtItemNombreTitularh = CEntidadGuiaTemp.APELLIDOS_NOMBRES_TH;
                    viewModel.txtDireccionHabilitante = CEntidadGuiaTemp.DIRECCION_TH;
                    viewModel.txtDNIHab = CEntidadGuiaTemp.DNI_TH;
                    viewModel.txtRucHab = CEntidadGuiaTemp.RUC_TH;
                    viewModel.hdfCodPropietario = CEntidadGuiaTemp.COD_PERSONAPRO;
                    viewModel.txtNomProp = CEntidadGuiaTemp.APELLIDOS_NOMBRES_PRO;
                    viewModel.txtDireccProp = CEntidadGuiaTemp.DIRECCION_PRO;
                    viewModel.txtDNIProp = CEntidadGuiaTemp.DNI_PRO;
                    viewModel.txtRucProp = CEntidadGuiaTemp.RUC_PRO;
                    viewModel.hdfCodDestinatario = CEntidadGuiaTemp.COD_PERSONADEST;
                    viewModel.txtNomDest = CEntidadGuiaTemp.APELLIDOS_NOMBRES_DES;
                    viewModel.txtDirecDest = CEntidadGuiaTemp.DIRECCION_DES;
                    viewModel.txtRucDest = CEntidadGuiaTemp.RUC_DES;
                    viewModel.txtDNIDest = CEntidadGuiaTemp.DNI_DES;
                    viewModel.hdfItemEstUbigeoCodigo1 = CEntidadGuiaTemp.UBIGEO_DES;
                    viewModel.lblItemEstUbigeo1 = CEntidadGuiaTemp.UBIGEO_NAMEDEST;
                    viewModel.txtReciboProd = CEntidadGuiaTemp.PROD_NATURAL;
                    viewModel.txtReciboCanon = CEntidadGuiaTemp.CANON_REFOREST;
                    viewModel.chkPlanAmazonas = (Boolean)CEntidadGuiaTemp.PLAN_AMAZONAS;
                    viewModel.ddlPlanAmazonasId = CEntidadGuiaTemp.ANIO_PLAN_AMAZONAS;
                    viewModel.chkOrigenConc = (Boolean)CEntidadGuiaTemp.ORIGEN_CONC;
                    viewModel.chkOrigenPerm = (Boolean)CEntidadGuiaTemp.ORIGEN_PERM;
                    viewModel.chkOrigenAut = (Boolean)CEntidadGuiaTemp.ORIGEN_AUT;
                    viewModel.chkOrigenBL = (Boolean)CEntidadGuiaTemp.ORIGEN_BL;
                    viewModel.chkOrigenDesbloque = (Boolean)CEntidadGuiaTemp.ORIGEN_DESBLOQUE;
                    viewModel.chkOrigenCambUso = (Boolean)CEntidadGuiaTemp.ORIGEN_CAMBUSO;
                    viewModel.chkOrigenPlant = (Boolean)CEntidadGuiaTemp.ORIGEN_PLANTACION;
                    viewModel.chkOrigenPMConsolidado = (Boolean)CEntidadGuiaTemp.ORIGEN_PMC;
                    viewModel.chkOrigenOtros = (Boolean)CEntidadGuiaTemp.ORIGEN_OTROS;
                    viewModel.txtOrigenOtros = CEntidadGuiaTemp.DET_ORIGEN_OTROS.ToString();
                    viewModel.hdfCodRLegalHab = CEntidadGuiaTemp.COD_PERSONARLEGAL.ToString();
                    viewModel.txtItemNombreRLegalh = CEntidadGuiaTemp.REPRESENTANTE_LEGAL.ToString();
                    viewModel.txtNumResPOA = CEntidadGuiaTemp.NUM_ARESOLUCION.ToString();
                    viewModel.txtTipoPM = CEntidadGuiaTemp.PLAN_MANEJO_TIPO.ToString();
                    viewModel.txtTipoComprobante = CEntidadGuiaTemp.TIPO_COMPROBANTE.ToString();
                    viewModel.txtNumComprobante = CEntidadGuiaTemp.NUM_COMPROBANTE.ToString();
                    viewModel.lblArchivoSeleccionado = CEntidadGuiaTemp.GTF_ARCHIVO_TEXT;
                    viewModel.txtMontoProduct = CEntidadGuiaTemp.MONTONATURAL == 0 ? "" : CEntidadGuiaTemp.MONTONATURAL.ToString();
                    viewModel.txtMontoCanon = CEntidadGuiaTemp.MONTOCANON == 0 ? "" : CEntidadGuiaTemp.MONTOCANON.ToString();
                    viewModel.hdfCodConductor = CEntidadGuiaTemp.COD_PERSONACOND;
                    viewModel.hdfCodDespachante = CEntidadGuiaTemp.COD_PERSONADESP;
                    viewModel.hdfCodAutorizante = CEntidadGuiaTemp.COD_PERSONAAUT;
                    viewModel.txtTipoTransp = CEntidadGuiaTemp.TIP_TRANS;
                    viewModel.txtPlacaTransp = CEntidadGuiaTemp.PLACA_VEHICULO_TRANS;
                    viewModel.txtLicTransp = CEntidadGuiaTemp.NUM_LICENCIA;
                    viewModel.txtPeso = CEntidadGuiaTemp.PESO_CARGA == 0 ? "" : CEntidadGuiaTemp.PESO_CARGA.ToString();
                    viewModel.txtObservacion = CEntidadGuiaTemp.OBSERVACIONES_PROD;
                    viewModel.txtObserGuia = CEntidadGuiaTemp.OBSERVACIONES_GUIA;
                    viewModel.txtNomCondTransp = CEntidadGuiaTemp.APELLIDOS_NOMBRES_COND;
                    viewModel.txtDespachado = CEntidadGuiaTemp.APELLIDOS_NOMBRES_DESPACHADOR;
                    viewModel.txtAutorizado = CEntidadGuiaTemp.APELLIDOS_NOMBRES_AUTORIZA;
                    viewModel.txtZafra = CEntidadGuiaTemp.COD_ZATRA;
                    viewModel.ListProducto = CEntidadGuiaTemp.listProducto;
                    viewModel.GTF_ARCHIVO = CEntidadGuiaTemp.GTF_ARCHIVO;
                    viewModel.GTF_ARCHIVO_TEXT = CEntidadGuiaTemp.GTF_ARCHIVO_TEXT;

                    //     verificaUsuSUNAT();
                    viewModel.hdfManRegEstado = "0";
                    viewModel.SubTitulo = "Modificando Registro";




                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
            return viewModel;
        }

        public void LlenarCombos(ref VModel VM, string cod_cuenta, string tipoFrmulario)
        {
            VM.Titulo = "Guia de Transporte Forestal";


        }


        public VModelProducto IniDatosProducto(string cod_cuenta)
        {
            VModelProducto viewModel;
            try
            {
                viewModel = new VModelProducto();
                LlenarCombosProducto(ref viewModel, cod_cuenta);



            }
            catch (Exception ex)
            {
                throw ex;
            }
            return viewModel;
        }
        public void LlenarCombosProducto(ref VModelProducto VM, string cod_cuenta)
        {
            CEntidad oCampos = new CEntidad();

            ////llenar combos
            oCampos.COD_UCUENTA = cod_cuenta;
            oCampos.BusFormulario = "GUIA_TRANSPORTE_FORESTAL_PRODUCTO";
            oCampos = RegMostComboProducto(oCampos);

            VM.ddlEspecies = oCampos.ListEspecies.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION });
            VM.ddlUnidadMedida = oCampos.ListUnidadMedida.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION });


        }


        public ListResult GuardarDatos(VModel dto, string codCuenta)
        {
            ListResult resultado = new ListResult();
            CEntidad oCampos = new CEntidad();
            string msjRespuesta = "El Registro se Guardo Correctamente";

            try
            {

                oCampos.NUM_POA = string.IsNullOrEmpty(dto.txtNumPOA) ? 0 : Int32.Parse(dto.txtNumPOA.Trim());
                oCampos.SEDE = string.IsNullOrEmpty(dto.txtSede) ? "" : dto.txtSede.Trim();
                oCampos.COD_UCUENTA = codCuenta;
                oCampos.NUMERO_GUIA_TRANS = string.IsNullOrEmpty(dto.txtNumGuia) ? "" : dto.txtNumGuia.Trim();
                oCampos.NOMBRE_GUIA_TRANS = string.IsNullOrEmpty(dto.txtNomGuia) ? "" : dto.txtNomGuia.Trim();
                oCampos.FECHA_EXPEDICION = string.IsNullOrEmpty(dto.txtItemFechaExp) ? null : dto.txtItemFechaExp.Trim();
                oCampos.FECHA_VENCIMIENTO = string.IsNullOrEmpty(dto.txtItemFechaVen) ? null : dto.txtItemFechaVen.Trim();
                oCampos.COD_THABILITANTE = dto.hdfItemCodTHabilitante;
                oCampos.COD_TITULAR = dto.hdfCodTitularHab;
                oCampos.TITULO = string.IsNullOrEmpty(dto.txtItemTituloHabilitante) ? "" : dto.txtItemTituloHabilitante.Trim();
                oCampos.COD_UBIGEO = string.IsNullOrEmpty(dto.hdfItemEstUbigeoCodigo) ? "" : dto.hdfItemEstUbigeoCodigo.Trim();
                oCampos.COD_PERSONAPRO = string.IsNullOrEmpty(dto.hdfCodPropietario) ? "" : dto.hdfCodPropietario.Trim();
                oCampos.COD_PERSONADEST = string.IsNullOrEmpty(dto.hdfCodDestinatario) ? "" : dto.hdfCodDestinatario.Trim();
                oCampos.COD_PERSONACOND = string.IsNullOrEmpty(dto.hdfCodConductor) ? "" : dto.hdfCodConductor.Trim();
                oCampos.COD_PERSONADESP = string.IsNullOrEmpty(dto.hdfCodDespachante) ? "" : dto.hdfCodDespachante.Trim();
                oCampos.COD_PERSONAAUT = string.IsNullOrEmpty(dto.hdfCodAutorizante) ? "" : dto.hdfCodAutorizante.Trim();
                oCampos.PROD_NATURAL = string.IsNullOrEmpty(dto.txtReciboProd) ? "" : dto.txtReciboProd.Trim();
                oCampos.CANON_REFOREST = string.IsNullOrEmpty(dto.txtReciboCanon) ? "" : dto.txtReciboCanon.Trim();
                oCampos.COD_ZATRA = string.IsNullOrEmpty(dto.txtZafra) ? "" : dto.txtZafra.Trim();
                oCampos.ANIO_PLAN_AMAZONAS = dto.ddlPlanAmazonasId;
                oCampos.PLAN_AMAZONAS = dto.chkPlanAmazonas;
                oCampos.ORIGEN_CONC = dto.chkOrigenConc;
                oCampos.ORIGEN_PERM = dto.chkOrigenPerm;
                oCampos.ORIGEN_AUT = dto.chkOrigenAut;
                oCampos.ORIGEN_BL = dto.chkOrigenBL;
                oCampos.ORIGEN_DESBLOQUE = dto.chkOrigenDesbloque;
                oCampos.ORIGEN_CAMBUSO = dto.chkOrigenCambUso;
                oCampos.ORIGEN_PLANTACION = dto.chkOrigenPlant;
                oCampos.ORIGEN_PMC = dto.chkOrigenPMConsolidado;
                oCampos.ORIGEN_OTROS = dto.chkOrigenOtros;
                oCampos.DET_ORIGEN_OTROS = string.IsNullOrEmpty(dto.txtOrigenOtros) ? "" : dto.txtOrigenOtros.Trim();
                oCampos.COD_PERSONARLEGAL = dto.hdfCodRLegalHab;
                oCampos.NUM_ARESOLUCION = string.IsNullOrEmpty(dto.txtNumResPOA) ? "" : dto.txtNumResPOA.Trim();
                oCampos.PLAN_MANEJO_TIPO = string.IsNullOrEmpty(dto.txtTipoPM) ? "" : dto.txtTipoPM.Trim();
                oCampos.TIPO_COMPROBANTE = string.IsNullOrEmpty(dto.txtTipoComprobante) ? "" : dto.txtTipoComprobante.Trim();
                oCampos.NUM_COMPROBANTE = string.IsNullOrEmpty(dto.txtNumComprobante) ? "" : dto.txtNumComprobante.Trim();
                oCampos.MONTONATURAL = string.IsNullOrEmpty(dto.txtMontoProduct) ? 0 : Decimal.Parse(dto.txtMontoProduct.Trim());
                oCampos.MONTOCANON = string.IsNullOrEmpty(dto.txtMontoCanon) ? 0 : Decimal.Parse(dto.txtMontoCanon.Trim());
                oCampos.TIP_TRANS = string.IsNullOrEmpty(dto.txtTipoTransp) ? "" : dto.txtTipoTransp.Trim();
                oCampos.PLACA_VEHICULO_TRANS = string.IsNullOrEmpty(dto.txtPlacaTransp) ? "" : dto.txtPlacaTransp.Trim();
                oCampos.NUM_LICENCIA = string.IsNullOrEmpty(dto.txtLicTransp) ? "" : dto.txtLicTransp.Trim();
                oCampos.PESO_CARGA = string.IsNullOrEmpty(dto.txtPeso) ? 0 : Decimal.Parse(dto.txtPeso.Trim());
                oCampos.OBSERVACIONES_PROD = string.IsNullOrEmpty(dto.txtObservacion) ? "" : dto.txtObservacion.Trim();
                oCampos.OBSERVACIONES_GUIA = string.IsNullOrEmpty(dto.txtObserGuia) ? "" : dto.txtObserGuia.Trim();
                oCampos.UBIGEO_DES = string.IsNullOrEmpty(dto.hdfItemEstUbigeoCodigo1) ? "" : dto.hdfItemEstUbigeoCodigo1.Trim();
                oCampos.listProducto = dto.ListProducto;
                oCampos.listProductoEli = dto.ListEliTABLA;


                oCampos.RegEstado = Int32.Parse(dto.hdfManRegEstado);
                oCampos.COD_GUIA_TRANS = "";
                oCampos.OUTPUTPARAM01 = "";

                if (dto.hdfManRegEstado == "0")
                    oCampos.COD_GUIA_TRANS = dto.COD_GUIA_TRANS;


                if (dto.archivoSubido == "1")
                {
                    string rutaBase = System.AppDomain.CurrentDomain.BaseDirectory;

                    oCampos.GTF_ARCHIVO = dto.GTF_ARCHIVO;
                    oCampos.GTF_ARCHIVO_TEXT = dto.GTF_ARCHIVO_TEXT;
                    try
                    {
                        File.Delete(Path.Combine(rutaBase, "Archivos/Archivo_GTF/" + dto.GTF_ARCHIVO));
                    }
                    catch (Exception) { }
                    File.Move(Path.Combine(rutaBase, "Archivos/Archivo_GTF/Temp/" + dto.GTF_ARCHIVO), Path.Combine(rutaBase, "Archivos/Archivo_GTF/" + dto.GTF_ARCHIVO));

                }
                else
                {
                    oCampos.GTF_ARCHIVO = string.IsNullOrEmpty(dto.GTF_ARCHIVO) ? "" : dto.GTF_ARCHIVO.Trim();
                    oCampos.GTF_ARCHIVO_TEXT = string.IsNullOrEmpty(dto.GTF_ARCHIVO_TEXT) ? "" : dto.GTF_ARCHIVO_TEXT.Trim();
                }

                RegGrabarV3(oCampos);
                resultado.AddResultado(msjRespuesta, true);


            }
            catch (Exception ex)
            {
                resultado.AddResultado(ex.Message, false);
            }
            return resultado;
        }
        //public String ReglInsertarInformeV3(CEntidad oCampoEntrada)
        //{
        //    try
        //    {
        //        using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
        //        {
        //            cn.Open();
        //            return oCDatos.RegInsertarV3(cn, oCampoEntrada);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        #endregion



    }
}
