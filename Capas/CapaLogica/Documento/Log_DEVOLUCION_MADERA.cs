using CapaEntidad.ViewModel;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
//using System.Data.SqlClient;
using System.Linq;
using CDatos = CapaDatos.DOC.Dat_DEVOLUCION_MADERA;
using CEntidad = CapaEntidad.DOC.Ent_DEVOLUCION_MADERA;
//using CEntPersona = CapaEntidad.DOC.Ent_GENEPERSONA;
using VModel = CapaEntidad.ViewModel.VM_DevolucionMadera;

namespace CapaLogica.DOC
{
    /// <summary>
    /// 
    /// </summary>
    public class Log_DEVOLUCION_MADERA
    {
        private CDatos oCDatos = new CDatos();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        //public CEntidad RegMostrarListaItems(CEntidad oCEntidad)
        //{
        //    try
        //    {
        //        using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
        //        {
        //            cn.Open();
        //            return oCDatos.RegMostrarListaItems(cn, oCEntidad);
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
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        //public CEntidad RegMostrarListaItemsV3(CEntidad oCEntidad)
        //{
        //    try
        //    {
        //        using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
        //        {
        //            cn.Open();
        //            return oCDatos.RegMostrarListaItemsV3(cn, oCEntidad);
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
        /// <param name="oCampoEntrada"></param>
        /// <returns></returns>
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="oCampoEntrada"></param>
        /// <returns></returns>
        //public String RegGrabarV3(CEntidad oCampoEntrada)
        //{
        //    try
        //    {
        //        using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
        //        {
        //            cn.Open();
        //            return oCDatos.RegGrabarV3(cn, oCampoEntrada);
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
        /// <param name="oCampoEntrada"></param>
        //public void RegEliminar(CEntidad oCampoEntrada)
        //{
        //    try
        //    {
        //        using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
        //        {
        //            cn.Open();
        //            oCDatos.RegEliminar(cn, oCampoEntrada);
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
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        //public List<CEntidad> RegMostPoa_Thabilitante_Lista_x_Numero(CEntidad oCEntidad)
        //{
        //    try
        //    {
        //        using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
        //        {
        //            cn.Open();
        //            return oCDatos.RegMostPoa_Thabilitante_Lista_x_Numero(cn, oCEntidad);
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
        //public List<CEntPersona> MostPInformeitem(CEntidad oCEntidad)
        //{
        //    try
        //    {
        //        using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
        //        {
        //            cn.Open();
        //            return oCDatos.MostPInformeitem(cn, oCEntidad);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        #region "Migracion - SIGO v3"
        //public VModel IniDatos(string codigo, string codigoComplementario, string cod_cuenta, int nuevo,string rol)
        //{
        //    VModel viewModel;
        //    try
        //    {
        //        viewModel = new VModel();
        //        viewModel.Rol = rol;

        //        if (nuevo == 1) //iniciar nuevo item
        //        {   //cargando datos                 

        //            viewModel.hdfItemCod_THabilitante = codigo;
        //            viewModel.lblItemTHModalidad = codigoComplementario.Split('|')[0];
        //            viewModel.lblItemTHNumero = codigoComplementario.Split('|')[1];
        //            viewModel.lblItemTHTitular = codigoComplementario.Split('|')[2];
        //            LlenarCombos(ref viewModel, cod_cuenta);
        //            viewModel.ItemTitulo = "Nuevo Registro";
        //            viewModel.hdfManRegEstado = "1";

        //            viewModel.ListNUM_POA = new List<CEntidad>();
        //            viewModel.ListPINFTEC = new List<CEntidad>();
        //            viewModel.ListESPDEVUELTAS = new List<CEntidad>();
        //            viewModel.ListVERTICE = new List<CEntidad>();
        //            viewModel.ListESPHALLADAS = new List<CEntidad>();
        //            viewModel.ListBEXTRACCION = new List<CEntidad>();
        //            viewModel.ListDEVOLCENSOTROZA = new List<CEntidad>();
        //            viewModel.ListDEVOLCENSOTOCON = new List<CEntidad>();
        //            viewModel.ListDEVOLCENSOARBOL = new List<CEntidad>();

        //        }
        //        if (nuevo == 0) //editar
        //        {

                    //Cargando datos
                    //CEntidad CEntDEVOLItems = new CEntidad();
                    //CEntidad oCampos = new CEntidad();
                    //oCampos.COD_THABILITANTE = codigoComplementario;
                    //oCampos.COD_DEVOLUCION = codigo;
                    //CEntDEVOLItems = RegMostrarListaItemsV3(oCampos);

        //            LlenarCombos(ref viewModel, cod_cuenta);


        //            viewModel.lblItemTHModalidad = CEntDEVOLItems.MODALIDAD;
        //            viewModel.hdfItemCod_THabilitante = CEntDEVOLItems.COD_THABILITANTE;
        //            viewModel.hdfItemCod_Devolucion = CEntDEVOLItems.COD_DEVOLUCION;
        //            viewModel.lblItemTHNumero = CEntDEVOLItems.NUM_THABILITANTE;
        //            viewModel.lblItemTHTitular = CEntDEVOLItems.PERSONA_TITULAR;
        //            viewModel.txtItemNumResolucion = CEntDEVOLItems.NUM_RESOLUCION;
        //            viewModel.txtItemFechaResol = CEntDEVOLItems.FECHA_RESOLUCION.ToString();
        //            viewModel.lblItemFunFirma = CEntDEVOLItems.PERSONA_FIRMA;
        //            viewModel.hdfItemFunFirmaCodigo = CEntDEVOLItems.COD_PERSONA_FIRMA;
        //            viewModel.txtItemZafra_Ejec = CEntDEVOLItems.ZAFRA_EJECUTAR;
        //            viewModel.txtItemEjecucionInicio = CEntDEVOLItems.INICIO_PERIODO_EJECUCION.ToString();
        //            viewModel.txtItemEjecucionFin = CEntDEVOLItems.FIN_PERIODO_EJECUCION.ToString();
        //            viewModel.txtItemFEmisionBExtracion = CEntDEVOLItems.FECHA_EMISION_BEXTRACCION.ToString();
        //            viewModel.ddlODRegistroId = CEntDEVOLItems.COD_OD_REGISTRO;

        //            viewModel.txtItemItecnico_Raprobacion_Num = CEntDEVOLItems.NUM_INFORME;
        //            viewModel.txtItemItecnico_Raprobacion_Fecha = CEntDEVOLItems.FECHA_INFORME.ToString();

        //            viewModel.ListNUM_POA = CEntDEVOLItems.ListNUM_POA;
        //            viewModel.ListPINFTEC = CEntDEVOLItems.ListPINFTEC;

        //            viewModel.ListESPDEVUELTAS = CEntDEVOLItems.ListESPDEVUELTAS;
        //            viewModel.ListVERTICE = CEntDEVOLItems.ListVERTICE;
        //            viewModel.ListESPHALLADAS = CEntDEVOLItems.ListESPHALLADAS;
        //            viewModel.ListBEXTRACCION = CEntDEVOLItems.ListBEXTRACCION;
        //            viewModel.ListDEVOLCENSOTROZA = CEntDEVOLItems.ListDEVOLCENSOTROZA;
        //            viewModel.ListDEVOLCENSOTOCON = CEntDEVOLItems.ListDEVOLCENSOTOCON;
        //            viewModel.ListDEVOLCENSOARBOL = CEntDEVOLItems.ListDEVOLCENSOARBOL;


        //            viewModel.lbtMaderableItemCensoTrozaSelec = String.Format("Total de Trozas ({0})", CEntDEVOLItems.ListDEVOLCENSOTROZA.Count.ToString());
        //            viewModel.lbtMaderableItemCensoToconSelec = String.Format("Total de Tocones ({0})", CEntDEVOLItems.ListDEVOLCENSOTOCON.Count.ToString());
        //            viewModel.lbtMaderableItemCensoArbolSelec = String.Format("Total de Arboles ({0})", CEntDEVOLItems.ListDEVOLCENSOARBOL.Count.ToString());

        //            //Observaciones de control de calidad
        //            viewModel.txtControlCalidadObservaciones = CEntDEVOLItems.OBSERVACIONES_CONTROL.ToString();
        //            viewModel.chkItemObsSubsanada = (Boolean)CEntDEVOLItems.OBSERV_SUBSANAR;
        //            viewModel.ddlItemIndicadorId = CEntDEVOLItems.COD_ESTADO_DOC;
        //            viewModel.txtUsuarioRegistro = CEntDEVOLItems.USUARIO_REGISTRO;
        //            viewModel.txtUsuarioControl = CEntDEVOLItems.USUARIO_CONTROL;
        //            viewModel.hdfManRegEstado = "0";
        //            viewModel.ItemTitulo = "Modificando Registro";

        //        }


        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return viewModel;
        //}
        public void LlenarCombos(ref VModel VM, string cod_cuenta)
        {
            List<CEntidad> ListCombo = new List<CEntidad>();
            CEntidad oCampos = new CEntidad();

            oCampos.COD_UCUENTA = cod_cuenta;
            oCampos.BusFormulario = "DEVOLUCION_MADERA";
            oCampos = RegMostCombo(oCampos);
            //
            //HerUtil.ComboLlenar(ddlItemBNuevo_DIdentidad, oCampos.ListMComboDIdentidad, "CODIGO", "DESCRIPCION", false);
            //HerUtil.ComboLlenar(ddlItemPN_DITipo, oCampos.ListMComboDIdentidad, "CODIGO", "DESCRIPCION", false);

            var listCondicion = (from p in oCampos.ListMComboEspeciesCondicion
                                 where (Boolean)p.MADERABLE == true
                                 select new VM_Cbo
                                 {
                                     Value = p.CODIGO,
                                     Text = p.DESCRIPCION.ToString()
                                 }
                          ).ToList();
            listCondicion.Insert(0, new VM_Cbo { Value = "-", Text = "Seleccionar" });
            VM.ddlItemCArbolCod_Econdicion = listCondicion;


            var listEstado = (from p in oCampos.ListMComboEspeciesEstado
                              where (Boolean)p.MADERABLE == true
                              select new VM_Cbo
                              {
                                  Value = p.CODIGO,
                                  Text = p.DESCRIPCION.ToString()
                              }
                          ).ToList();
            listEstado.Insert(0, new VM_Cbo { Value = "-", Text = "Seleccionar" });
            VM.ddlItemCArbolCod_Eestado = listEstado;


            VM.ddlItemIndicador = oCampos.ListIndicador.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION.ToString() });
            VM.ddlODRegistro = oCampos.ListODs.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION.ToString() });

            var listMComboEspecies = oCampos.ListMComboEspecies.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION.ToString() }).ToList();
            listMComboEspecies.Insert(0, new VM_Cbo { Value = "-", Text = "Seleccionar" });
            VM.ListMComboEspecies = listMComboEspecies;




        }


        //public ListResult GuardarDatosDM(VModel dto, string codCuenta)
        //{
        //    ListResult resultado = new ListResult();
        //    CEntidad oCampos = new CEntidad();
        //    String OUTPUTPARAM = "";
        //    string msjRespuesta = "El Registro se Guardo Correctamente";

        //    try
        //    {


        //        //Devol
        //        oCampos.COD_THABILITANTE = dto.hdfItemCod_THabilitante;
        //        oCampos.COD_DEVOLUCION = dto.hdfItemCod_Devolucion;
        //        oCampos.NUM_RESOLUCION = dto.txtItemNumResolucion;
        //        oCampos.FECHA_RESOLUCION = dto.txtItemFechaResol;
        //        oCampos.COD_PERSONA_FIRMA = dto.hdfItemFunFirmaCodigo;
        //        oCampos.ZAFRA_EJECUTAR = dto.txtItemZafra_Ejec;
        //        oCampos.INICIO_PERIODO_EJECUCION = dto.txtItemEjecucionInicio;
        //        oCampos.NUM_INFORME = dto.txtItemItecnico_Raprobacion_Num;
        //        oCampos.FECHA_INFORME = dto.txtItemItecnico_Raprobacion_Fecha;
        //        oCampos.FIN_PERIODO_EJECUCION = dto.txtItemEjecucionFin;
        //        oCampos.FECHA_EMISION_BEXTRACCION = dto.txtItemFEmisionBExtracion;
        //        oCampos.COD_UCUENTA = codCuenta;
        //        oCampos.OUTPUTPARAM01 = "";
        //        oCampos.OUTPUTPARAM02 = "";

        //        //Variables de control de calidad
        //        oCampos.COD_ESTADO_DOC = dto.ddlItemIndicadorId;
        //        oCampos.OBSERVACIONES_CONTROL = dto.txtControlCalidadObservaciones;
        //        oCampos.OBSERV_SUBSANAR = dto.chkItemObsSubsanada;
        //        oCampos.COD_OD_REGISTRO = dto.ddlODRegistroId;
        //        //Lista de Objetos
        //        oCampos.ListNUM_POA = dto.ListNUM_POA;
        //        oCampos.ListESPDEVUELTAS = dto.ListESPDEVUELTAS;
        //        oCampos.ListPINFTEC = dto.ListPINFTEC;
        //        oCampos.ListVERTICE = dto.ListVERTICE;
        //        oCampos.ListESPHALLADAS = dto.ListESPHALLADAS;
        //        oCampos.ListBEXTRACCION = dto.ListBEXTRACCION;
        //        oCampos.ListDEVOLCENSOTROZA = dto.ListDEVOLCENSOTROZA;
        //        oCampos.ListDEVOLCENSOTOCON = dto.ListDEVOLCENSOTOCON;
        //        oCampos.ListDEVOLCENSOARBOL = dto.ListDEVOLCENSOARBOL;
        //        oCampos.ListEliTABLA = dto.ListEliTABLA;

        //        oCampos.TIENE_POA = dto.TIENE_POA;
        //        oCampos.COD_DEVOLUCION = "";
        //        oCampos.OUTPUTPARAM01 = "";
        //        oCampos.OUTPUTPARAM02 = "";
        //        oCampos.RegEstado = Int32.Parse(dto.hdfManRegEstado);

        //        if (dto.hdfManRegEstado == "0") //Modificar
        //        {

        //            oCampos.COD_THABILITANTE = dto.hdfItemCod_THabilitante;
        //            oCampos.COD_DEVOLUCION = dto.hdfItemCod_Devolucion;
        //        }
        //        //Grabando Base Datos
        //        OUTPUTPARAM = RegGrabarV3(oCampos);
        //        resultado.AddResultado(msjRespuesta, true);

        //    }
        //    catch (Exception ex)
        //    {
        //        resultado.AddResultado(ex.Message, false);
        //    }
        //    return resultado;
        //}

        #endregion
    }

}
