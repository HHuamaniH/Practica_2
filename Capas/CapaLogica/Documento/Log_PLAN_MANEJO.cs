using CapaDatos;
using CapaEntidad.DOC;
using CapaEntidad.ViewModel;
using GeneralSQL;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using CDatos = CapaDatos.DOC.Dat_PLAN_MANEJO;
using CEntBusq = CapaEntidad.DOC.Ent_BUSQUEDA;
using CEntidad = CapaEntidad.DOC.Ent_PLAN_MANEJO;
using CEntidadDependencia = CapaEntidad.GENE.Ent_DEPENDENCIA_UBIGEO;
using CLogBusq = CapaLogica.DOC.Log_BUSQUEDA;
using CLogicaDependencia = CapaLogica.GENE.Log_DEPENDENCIA_UBIGEO;

namespace CapaLogica.DOC
{
    /// <summary>
    /// 
    /// </summary>
	public class Log_PLAN_MANEJO
    {
        private CDatos oCDatos = new CDatos();
        private DBOracle dBOracle = new DBOracle();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
		public List<CEntidad> RegMostrarLista(CEntidad oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegMostrarLista(cn, oCEntidad);
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
        //public CEntidad RegMostrarListaItems(CEntidad oCEntidad)
        //{
        //    try
        //    {
        //        using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
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
        //public CEntidad RegMostrarListaItemsESitu(CEntidad oCEntidad)
        //{
        //    try
        //    {
        //        using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
        //        {
        //            cn.Open();
        //            return oCDatos.RegMostrarListaItemsESitu(cn, oCEntidad);
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
        public CEntidad PLAN_MANEJO_EXSITU_PGENETICO_MostItem(CEntidad oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.PLAN_MANEJO_EXSITU_PGENETICO_MostItem(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Tuple<List<Dictionary<string, string>>, List<Dictionary<string, string>>> PLAN_MANEJO_EXSITU_PGENETICO_MostItemV3(CEntidad oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.PLAN_MANEJO_EXSITU_PGENETICO_MostItemV3(cn, oCEntidad);
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
        //public String RegGrabar(CEntidad oCampoEntrada)
        //{
        //    try
        //    {
        //        using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
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
        public Int32 RegGrabarESituIAnual(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    OracleTransaction tr = cn.BeginTransaction();
                    return oCDatos.RegGrabarESituIAnual(cn, tr, oCampoEntrada);
                    cn.Close();
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
		public void RegEliminar(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    oCDatos.RegEliminar(cn, oCampoEntrada);
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
        public void RegEliminarESituIAnual(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    OracleTransaction tr = cn.BeginTransaction();
                    oCDatos.RegEliminarESituIAnual(cn, tr, oCampoEntrada);
                    cn.Close();
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
        public void RegEliminarESituPGenetico(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    OracleTransaction tr = cn.BeginTransaction();
                    oCDatos.RegEliminarESituPGenetico(cn, tr, oCampoEntrada);
                    cn.Close();
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
        public void RegEliminarESituBIndividuos(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    OracleTransaction tr = cn.BeginTransaction();
                    oCDatos.RegEliminarESituBIndividuos(cn, tr, oCampoEntrada);
                    cn.Close();
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
        public List<CEntidad> RegNuevoBuscar(CEntidad oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegNuevoBuscar(cn, oCEntidad);
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
        //public List<CEntidad> RegMostComboEspecies(CEntidad oCEntidad)
        //{
        //    try
        //    {
        //        using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
        //        {
        //            cn.Open();
        //            return oCDatos.RegMostComboEspecies(cn, oCEntidad);
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
        public String RegMostComboEspeciesGrabar(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegMostComboEspeciesGrabar(cn, oCampoEntrada);
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
        /// <returns></returns>
        public List<CEntidad> RegMostComboTOpciones(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegMostComboTOpciones(cn, oCampoEntrada);
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
        /// <returns></returns>
        //public List<CEntidad> RegMostComboAutoExtraer(CEntidad oCampoEntrada)
        //{
        //    try
        //    {
        //        using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
        //        {
        //            cn.Open();
        //            return oCDatos.RegMostComboAutoExtraer(cn, oCampoEntrada);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="oCampoEntrada"></param>
        /// <returns></returns>
        public String PLAN_MANEJO_EXSITU_BINDIVIDUOS_Grabar(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    OracleTransaction tr = cn.BeginTransaction();
                    return oCDatos.PLAN_MANEJO_EXSITU_BINDIVIDUOS_Grabar(cn, tr, oCampoEntrada);

                    cn.Close();
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
        public String PLAN_MANEJO_EXSITU_PGENETICO_Grabar(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.PLAN_MANEJO_EXSITU_PGENETICO_Grabar(cn, oCampoEntrada);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #region PLAN GENERAL DE  MANEJO FORESTAL
        public List<CEntidad> LogPersonas(CEntidad oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegPersonaList(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// metodo para obtener la lista de THabilitante
        /// </summary>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public List<CEntidad> LogTitulo(CEntidad oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.datListTitulo(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// metodo para el listado y llenado del combo de especies
        /// </summary>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public CEntidad LogListEspecies(CEntidad oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.datListComboLlenar(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// METODO PARA GUARDAR DATOS DEL PLAN GENERAL DE MANEJO FORESTAL
        /// </summary>
        /// <param name="oCampoEntrada"></param>
        /// <returns></returns>
        //public String RegGrabarPGMF(CEntidad oCampoEntrada)
        //{
        //    try
        //    {
        //        using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
        //        {
        //            cn.Open();
        //            return oCDatos.RegGrabarPGMF(cn, oCampoEntrada);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public CEntidad LogMostrarItemPGMF(CEntidad oCampoEntrada)
        //{
        //    try
        //    {
        //        using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
        //        {
        //            cn.Open();
        //            return oCDatos.RegMostrarListaItemsPGMF(cn, oCampoEntrada);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        #endregion
        #region "Log SIGO V3"
        public String RegGrabarPGMFV3(CEntidad oCampoEntrada, OracleTransaction tr)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegGrabarPGMFV3(cn, oCampoEntrada, tr);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public CEntidad LogMostrarItemPGMFV3(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegMostrarListaItemsPGMFV3(cn, oCampoEntrada);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public VM_ControlCalidad LogObtenerControlCalidadV3(string busFormulario, string busValor)
        {
            try
            {
                CEntidad oCampoEntrada = new CEntidad();
                oCampoEntrada.BusFormulario = busFormulario;
                oCampoEntrada.BusCriterio = "";
                oCampoEntrada.BusValor = busValor;
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.datObtenerControlCalidadV3(cn, oCampoEntrada);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public CEntidad LogListEspeciesV3(CEntidad oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.datListComboLlenarV3(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public VM_PlanManejoGeneral IniDatosPlanManejoGeneral(string codigoPlanManejo, string cod_cuenta, int opt, string codTHabilitante = "", string txtNumResolucion = "", string rol="")
        {
            VM_PlanManejoGeneral PM_VM;
           
            try
            {
                PM_VM = new VM_PlanManejoGeneral();

                CEntBusq oCampos = new CEntBusq();
                CLogBusq oCLogicaBusqueda = new CLogBusq();
                oCampos.BusFormulario = "GENERAL";
                oCampos.COD_UCUENTA = cod_cuenta;
                oCampos.BusValor = rol;
                PM_VM.esPMFI = opt;
                PM_VM.rol = rol;
                if (opt == 0)
                {
                    PM_VM.lblTituloCabecera = "Plan General de Manejo Forestal - PGMF";
                    PM_VM.tituloInformeRecomendacion = "Informe de recomendación de la aprobación del PGMF";
                    PM_VM.tituloDatosGenerales = "Datos Generales - PGMF";
                }
                else
                {
                    PM_VM.lblTituloCabecera = "Plan de Manejo Forestal Intermedio - PMFI";
                    PM_VM.tituloInformeRecomendacion = "Informe de recomendación de la aprobación del PMFI";
                    PM_VM.tituloDatosGenerales = "Datos Generales - PMFI";
                }
                oCampos = oCLogicaBusqueda.RegMostCombo(oCampos);
                List<VM_Cbo> listIndicador = oCampos.ListIndicador.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION }).ToList();
                PM_VM.ddlODRegistro = oCampos.ListODs.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION });
                if (String.IsNullOrEmpty(codigoPlanManejo))
                { //iniciamos datos para un nuevo registro
                    PM_VM.lblTituloEstado = "Nuevo Registro";
                    PM_VM.ddlItemIndicador = listIndicador;
                    PM_VM.ddlItemIndicadorId = "0000000";
                    PM_VM.ddlODRegistroId = "0000000";
                    PM_VM.ddlItemIndicadorEnable = true;
                    PM_VM.hdfManRegEstado = "1";
                    PM_VM.codTipoPlan = opt == 0 ? "PGMF" : "PMFI";
                    PM_VM.ddlDependencia = new List<VM_Cbo>();

                    //cuando biene desde otro lugar - SITD, INTEROPERABILIDAD
                    if (!String.IsNullOrEmpty(codTHabilitante))
                    {
                        Ent_PLAN_MANEJO paramBusqueda = new Ent_PLAN_MANEJO();
                        paramBusqueda.BusFormulario = "TITULO_HABILITANTE";
                        paramBusqueda.BusCriterio = "TH_CODIGO";
                        paramBusqueda.BusValor = codTHabilitante;
                        PM_VM.ListTHabilitante = this.LogTitulo(paramBusqueda);
                    }
                    PM_VM.txtNumResolucion = txtNumResolucion;
                }
                else
                { //iniciamos datos para modificacion
                    CEntidad oCEntidadBusq = new CEntidad();
                    PM_VM.hdfManCOD_PGMF = codigoPlanManejo;
                    oCEntidadBusq.COD_PGMF = codigoPlanManejo;
                    oCEntidadBusq = LogMostrarItemPGMFV3(oCEntidadBusq);
                    PM_VM.lblTituloEstado = "Modificando Registro";
                    PM_VM.hdfManRegEstado = "0";

                    PM_VM.txtNumResolucion = oCEntidadBusq.NUMERO_PGMF;
                    PM_VM.txtFechaAprobacion = oCEntidadBusq.FECHA_RESOLUCION.ToString();
                    PM_VM.hdtxtFuncionarioFirma = oCEntidadBusq.COD_FUNCIONARIO;
                    PM_VM.txtFuncionarioFirma = oCEntidadBusq.FUNCIONARIO_APROB_ACTIVIDAD;
                    PM_VM.chckprimerQuinquenio = oCEntidadBusq.PRIM_QUIENQUENIO == 0 ? false : true;
                    PM_VM.chckSegundoQuinquenio = oCEntidadBusq.SEG_QUINQUENIO == 0 ? false : true;
                    PM_VM.chckTercerQuinquenio = oCEntidadBusq.TERC_QUINQUENIO == 0 ? false : true;
                    PM_VM.chckCuartoQuinquenio = oCEntidadBusq.CUART_QUINQUENIO == 0 ? false : true;
                    PM_VM.txtBloques = oCEntidadBusq.NUM_BLOQUES.ToString();
                    PM_VM.txtAreaPGMF = oCEntidadBusq.AREA_PGMF.ToString();
                    PM_VM.txtPeriodo = oCEntidadBusq.PERIODO.ToString();
                    PM_VM.txtFechaIncioPeriodo = oCEntidadBusq.FECHA_INICIO.ToString();
                    PM_VM.txtFechaTerminoPeriodo = oCEntidadBusq.FECHA_FIN.ToString();
                    PM_VM.txtNumInfAprob = oCEntidadBusq.NUM_INFORME;
                    PM_VM.txtFechaAprobacionInf = oCEntidadBusq.FECHA_INFORME.ToString();
                    PM_VM.hdtxtProfesionalRecomendo = oCEntidadBusq.COD_PROF_INFORME;
                    PM_VM.txtProfesionalRecomendo = oCEntidadBusq.PROFESIONAL_NOMBRE;
                    PM_VM.hdtxtConsultorElaboro = oCEntidadBusq.COD_CONSULTOR;
                    PM_VM.txtConsultorElaboro = oCEntidadBusq.CONSULTOR_NOMBRE;
                    PM_VM.txtNumAFFS = oCEntidadBusq.NUM_REGISTRO_ATFFS;
                    PM_VM.txtNumCIP = oCEntidadBusq.NUM_CIP;
                    PM_VM.chckConsolidad = (Boolean)oCEntidadBusq.CONSOLIDADCION;
                    PM_VM.txtNomConsolidad = oCEntidadBusq.NOMBRE_CONSOLIDAD;
                    PM_VM.txtObservacion = oCEntidadBusq.OBSERVACIONES;

                    PM_VM.ddlODRegistroId = oCEntidadBusq.COD_OD_REGISTRO;
                    PM_VM.ListTHabilitante = oCEntidadBusq.ListTHabilitante;
                    PM_VM.ListEspecies = oCEntidadBusq.ListEspecies;
                    PM_VM.ListCoordenadas = oCEntidadBusq.ListCoordenadas;
                    PM_VM.ListEspeciesFauna = oCEntidadBusq.ListEspeciesFauna;
                    //Observaciones de control de calidad
                    //PM_VM.txtControlCalidadObservaciones = oCEntidadBusq.OBSERVACIONES_CONTROL.ToString();
                    PM_VM.OBSERV_SUBSANAR = (Boolean)oCEntidadBusq.OBSERV_SUBSANAR;
                    bool enableIndicador = true;
                    string itemSelectIndicador = oCEntidadBusq.COD_ESTADO_DOC;
                    Log_Helper.controla_estado_calidad(oCEntidadBusq.COD_ESTADO_DOC, ref listIndicador, ref enableIndicador, ref itemSelectIndicador);
                    PM_VM.ddlItemIndicador = listIndicador;
                    PM_VM.ddlItemIndicadorId = itemSelectIndicador;
                    PM_VM.ddlItemIndicadorEnable = enableIndicador;
                    PM_VM.txtUsuarioRegistro = oCEntidadBusq.USUARIO_REGISTRO;
                    PM_VM.txtUsuarioControl = oCEntidadBusq.USUARIO_CONTROL;
                    PM_VM.codTipoPlan = oCEntidadBusq.TIPO_PLAN;


                    PM_VM.ddlDependencia = Log_Helper.ListComboLlenar(oCEntidadBusq.ListDependencia, "CODIGO", "DESCRIPCION", true);
                    if (oCEntidadBusq.COD_DEPENDENCIA != "0")
                        PM_VM.ddlDependenciaId = oCEntidadBusq.COD_DEPENDENCIA;



                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return PM_VM;
        }
        public string ValidarResolucionPGMFV3(string COD_PGMF, string NUMERO_PGMF, string estado)
        {
            CEntidad oCampos = new CEntidad();
            string OUTPUTPARAM = "";
            oCampos.COD_PGMF = COD_PGMF;
            oCampos.NUMERO_PGMF = NUMERO_PGMF.Trim();
            oCampos.RegEstado = int.Parse(estado);
            OUTPUTPARAM = oCDatos.ValidarResolucionPGMFV3(oCampos);
            return OUTPUTPARAM;
        }
        public ListResult GuardarPlanManejoForestal(VM_PlanManejoGeneral dto, string codCuenta)
        {
            ListResult result = new ListResult();
            string msjRespuesta = "El Registro se Guardo Correctamente";
            string appServer = "";
            string oResultTransferir = "";
            try
            {
                String OUTPUTPARAM = "";
                CEntidad oCampos = new CEntidad();
                dto.ListTHabilitante = dto.ListTHabilitante ?? new List<CEntidad>();
                if (dto.ListTHabilitante == null || dto.ListTHabilitante.Count() == 0) throw new Exception("Selecione el/los título(s) habilitante(s)");
                oCampos.COD_ESTADO_DOC = dto.ddlItemIndicadorId;
                oCampos.NUMERO_PGMF = dto.txtNumResolucion.Trim();
                oCampos.FECHA_RESOLUCION = dto.txtFechaAprobacion;
                oCampos.COD_FUNCIONARIO = dto.hdtxtFuncionarioFirma;
                oCampos.PRIM_QUIENQUENIO = dto.chckprimerQuinquenio == true ? 1 : 0;
                oCampos.SEG_QUINQUENIO = dto.chckSegundoQuinquenio == true ? 1 : 0;
                oCampos.TERC_QUINQUENIO = dto.chckTercerQuinquenio == true ? 1 : 0;
                oCampos.CUART_QUINQUENIO = dto.chckCuartoQuinquenio == true ? 1 : 0;
                if (dto.codTipoPlan.Trim() == "PGMF")
                {
                    oCampos.NUM_BLOQUES = Int32.Parse(dto.txtBloques);
                    oCampos.AREA_PGMF = Decimal.Parse(dto.txtAreaPGMF);
                    oCampos.PERIODO = Int32.Parse(dto.txtPeriodo);
                    oCampos.FECHA_INICIO = dto.txtFechaIncioPeriodo;
                    oCampos.FECHA_FIN = dto.txtFechaTerminoPeriodo;
                }
                oCampos.NUM_INFORME_RECOMEN = dto.txtNumInfAprob.Trim();
                oCampos.FECHA_INFORME = dto.txtFechaAprobacionInf;
                oCampos.COD_PROF_INFORME = dto.hdtxtProfesionalRecomendo;
                oCampos.COD_CONSULTOR = dto.hdtxtConsultorElaboro;
                oCampos.NUM_REGISTRO_ATFFS = dto.txtNumAFFS != null ? dto.txtNumAFFS.Trim() : null;
                oCampos.NUM_CIP = dto.txtNumCIP != null ? dto.txtNumCIP.Trim() : null;
                oCampos.CONSOLIDADCION = dto.chckConsolidad;
                oCampos.NOMBRE_CONSOLIDAD = dto.txtNomConsolidad != null ? dto.txtNomConsolidad.Trim() : null;
                oCampos.OBSERVACIONES = dto.txtObservacion != null ? dto.txtObservacion.Trim() : null;
                oCampos.RegEstado = int.Parse(dto.hdfManRegEstado);
                oCampos.COD_PGMF = "";
                if (oCampos.RegEstado == 0) //Modificar
                {
                    msjRespuesta = "El Registro se Modifico Correctamente";
                    oCampos.COD_PGMF = dto.hdfManCOD_PGMF;
                }
                oCampos.COD_UCUENTA = codCuenta;
                oCampos.COD_OD_REGISTRO = dto.ddlODRegistroId;
                oCampos.ListTHabilitante = dto.ListTHabilitante;
                oCampos.ListEliTABLA = dto.ListEliTABLA;
                oCampos.ListEspecies = dto.ListEspecies;
                oCampos.ListCoordenadas = dto.ListCoordenadas;
                oCampos.ListEspeciesFauna = dto.ListEspeciesFauna;

                //cotrol de calidad
                oCampos.OBSERVACIONES_CONTROL = dto.txtControlCalidadObservaciones;
                oCampos.OBSERV_SUBSANAR = dto.OBSERV_SUBSANAR;
                oCampos.TIPO_PLAN = dto.codTipoPlan;

                oCampos.COD_DEPENDENCIA = dto.ddlDependenciaId == "-" ? null : dto.ddlDependenciaId;

                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    OracleTransaction tr = cn.BeginTransaction();
                    try
                    {
                        OUTPUTPARAM = oCDatos.RegGrabarPGMFV3(cn, oCampos, tr);
                        if (dto.appClient == null)
                        {
                            dto.appClient = "";
                            dto.appData = "";
                        }
                        if (dto.appClient != "" && dto.appClient.Split('|')[1] == "TRANSFERIR")
                        {
                            //Grabar dato de la transferencia
                            CapaEntidad.DOC.Ent_ANTECEDENTE_EXPEDIENTE oParamsAExpedienteSitd = new CapaEntidad.DOC.Ent_ANTECEDENTE_EXPEDIENTE();
                            oParamsAExpedienteSitd.TIPO = "TRANSFERIR"; oParamsAExpedienteSitd.SUBTIPO = "PGMF";
                            oParamsAExpedienteSitd.COD_AEXPEDIENTE_SITD = Convert.ToInt32(dto.appData.Split('¬')[0]);
                            oParamsAExpedienteSitd.COD_TRAMITE_SITD = Convert.ToInt32(dto.appData.Split('¬')[1]);
                            oParamsAExpedienteSitd.OBSERVACION = dto.appData.Split('¬')[6];
                            oParamsAExpedienteSitd.COD_PGMF = OUTPUTPARAM;
                            oParamsAExpedienteSitd.ORIGEN_REGISTRO = 1;//ORIGEN SITD
                            oParamsAExpedienteSitd.RESOLUCION_POA = dto.txtNumResolucion;
                            oParamsAExpedienteSitd.ESTADO_AEXPEDIENTE = dto.appData.Split('¬')[2] == "0401" || dto.appData.Split('¬')[2] == "0404" ? "Transferido" : "Pendiente";//0401:PGMF 0404:PMFI (SITD)
                            oParamsAExpedienteSitd.COD_UCUENTA = codCuenta;
                            oParamsAExpedienteSitd.OUTPUTPARAM01 = "";
                            if (oParamsAExpedienteSitd.RESOLUCION_POA != dto.appData.Split('¬')[5]) oParamsAExpedienteSitd.RegEstado = 2;//Datos del SITD modificado

                            CapaLogica.DOC.Log_ANTECEDENTE_EXPEDIENTE oLogAExpedienteSitd = new CapaLogica.DOC.Log_ANTECEDENTE_EXPEDIENTE();
                            CapaDatos.DOC.Dat_ANTECEDENTE_EXPEDIENTE datAntecedentes = new CapaDatos.DOC.Dat_ANTECEDENTE_EXPEDIENTE();
                            oResultTransferir = datAntecedentes.RegGrabarV3(cn, oParamsAExpedienteSitd, tr);
                            appServer = "2";
                        }
                        else if (dto.appClient != "" && dto.appClient.Split('|')[1] == "VISUALIZAR")
                        {
                            appServer = "2";
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
                result.appServer = appServer;
                result.AddResultado(msjRespuesta, true);
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
                result.appServer = appServer;
                result.AddResultado(ex.Message, false);
            }
            return result;
        }
        #region "MODALES SIGO v3"
        public VM_ESPECIE_APROBADAS IniDatosEspecies(int numBloque, int esPMFI)
        {
            VM_ESPECIE_APROBADAS VM_E = new VM_ESPECIE_APROBADAS();
            CEntidad oCampos = new CEntidad();
            oCampos.BusCriterio = "COMBO_ESPECIES_PGMF_MADERABLES";
            oCampos.BusFormulario = "MANGRILLA";
            oCampos = LogListEspeciesV3(oCampos);
            VM_E.cbespeciesinipauforest = oCampos.ListEspecies.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION });
            VM_E.cbespeciesinipauforestId = "0002484";
            if (esPMFI == 0)
            {
                List<VM_Cbo> listBloque = new List<VM_Cbo>();
                for (int i = 1; i <= numBloque; i++)
                {

                    VM_Cbo oCentidaTemp = new VM_Cbo();
                    oCentidaTemp.Text = "Bloque N° " + i.ToString();
                    oCentidaTemp.Value = i.ToString();
                    listBloque.Add(oCentidaTemp);
                }
                VM_E.dlBloque = listBloque;
                VM_E.dlBloqueId = "1";
            }
            VM_E.esPMFI = esPMFI;
            return VM_E;
        }
        public VM_ESPECIE_FS IniDatosEspeciesFS()
        {
            VM_ESPECIE_FS VM_EFS = new VM_ESPECIE_FS();
            CEntidad oCampos = new CEntidad();
            oCampos.BusCriterio = "COMBO_ESPECIES_PGMF_AMENAZA";
            oCampos.BusFormulario = "MANGRILLA";
            oCampos = LogListEspeciesV3(oCampos);
            VM_EFS.dplEspecieFauna = oCampos.ListEspeciesFauna.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION });
            VM_EFS.dplGradoAmenazaEspecie = oCampos.ListGradAmenaza.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION });
            VM_EFS.dplEspecieFaunaId = "0003496";
            return VM_EFS;
        }
        #endregion
        public List<Dictionary<string, string>> RegMostrarPlanManejoList(CEntidad oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegMostrarPlanManejoList(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ListResult DescargaExceles(string nomPlantillaExcel, List<Ent_PLAN_MANEJO> listParam)
        {
            ListResult result = new ListResult();
            try
            {

                String RutaReporteSeguimiento = HttpContext.Current.Server.MapPath("~/Archivos/Plantilla/");
                string nombreFile = "";

                nombreFile = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() +
                    DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() +
                    DateTime.Now.Millisecond.ToString() + ".xlsx";

                string rutaExcel = RutaReporteSeguimiento + nombreFile;
                File.Copy(RutaReporteSeguimiento + nomPlantillaExcel, rutaExcel); //pues si es mover 
                                                                                  //Creamos la cadena de conexión con el fichero excel
                OleDbConnectionStringBuilder cb = new OleDbConnectionStringBuilder();
                cb.DataSource = rutaExcel;

                if (Path.GetExtension(rutaExcel).ToUpper() == ".XLS")
                {
                    cb.Provider = "Microsoft.Jet.OLEDB.4.0";
                    cb.Add("Extended Properties", "Excel 8.0;HDR=YES;IMEX=0;");
                }
                else if (Path.GetExtension(rutaExcel).ToUpper() == ".XLSX")
                {
                    cb.Provider = "Microsoft.ACE.OLEDB.12.0";
                    cb.Add("Extended Properties", "Excel 12.0 Xml;HDR=YES;IMEX=0;");
                }
                using (OleDbConnection conn = new OleDbConnection(cb.ConnectionString))
                {
                    //Abrimos la conexión
                    conn.Open();
                    //Creamos la ficha
                    using (OleDbCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        //Construyendo las Cabeceras
                        RetornaInsert(cmd, nomPlantillaExcel, listParam);
                        //Cerramos la conexión
                        conn.Close();
                    }
                }
                List<string> lstResult = new List<string> { nombreFile };
                result.AddResultado("Ok", true, lstResult);

            }
            catch (Exception ex)
            {
                result.AddResultado(ex.Message, false);

            }
            return result;
        }

        private static void RetornaInsert(OleDbCommand cmd, string nomPlantillaExcel, List<CEntidad> listParam)
        {
            String insertar = "";
            int i = 1;
            switch (nomPlantillaExcel)
            {

                #region EspeciesAprobadas.xlsx
                case "EspeciesAprobadas.xlsx":
                    foreach (var list in listParam)
                    {
                        insertar = "";
                        insertar = insertar + "'" + (string.IsNullOrEmpty(list.DESCRIPCION) ? "" : list.DESCRIPCION.Split('|')[0]) + "'";
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(list.DESCRIPCION) ? "" : list.DESCRIPCION.Split('|')[1]) + "'";
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(list.NUM_BLOQUES.ToString()) ? "" : list.NUM_BLOQUES.ToString()) + "'";
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(list.NUM_ARBOLES.ToString()) ? "" : list.NUM_ARBOLES.ToString()) + "'";
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(list.VOLUMEN.ToString()) ? "" : list.VOLUMEN.ToString()) + "'";
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(list.TIPOMADERABLE.ToString()) ? "" : list.TIPOMADERABLE.ToString()) + "'";
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(list.UNIDAD_MEDIDA.ToString()) ? "" : list.UNIDAD_MEDIDA.ToString()) + "'";

                        cmd.CommandText = "INSERT INTO [Datos$A" + i.ToString().Trim() + ":G" + (listParam.Count + 1).ToString() + "] VALUES (" + insertar + ")";
                        cmd.ExecuteNonQuery();
                    }
                    break;
                #endregion
                #region VerticesPMForestal.xlsx
                case "VerticesPMForestal.xlsx":
                    foreach (var list in listParam)
                    {
                        insertar = "";
                        insertar = insertar + "'" + (string.IsNullOrEmpty(list.VERTICE) ? "" : list.VERTICE.ToString()) + "'";
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(list.COORDENADA_ESTE.ToString()) ? "" : list.COORDENADA_ESTE.ToString()) + "'";
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(list.COORDENADA_NORTE.ToString()) ? "" : list.COORDENADA_NORTE.ToString()) + "'";
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(list.OBSERVACIONES.ToString()) ? "" : list.OBSERVACIONES.ToString()) + "'";

                        cmd.CommandText = "INSERT INTO [Datos$A" + i.ToString().Trim() + ":D" + (listParam.Count + 1).ToString() + "] VALUES (" + insertar + ")";
                        cmd.ExecuteNonQuery();
                    }
                    break;
                #endregion
                #region EspeciesFS.xlsx
                case "EspeciesFS.xlsx":
                    foreach (var list in listParam)
                    {
                        insertar = "";
                        insertar = insertar + "'" + (string.IsNullOrEmpty(list.DESCRIPCION) ? "" : list.DESCRIPCION.Split('|')[0]) + "'";
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(list.DESCRIPCION) ? "" : list.DESCRIPCION.Split('|')[1]) + "'";
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(list.DESC_AMENAZA.ToString()) ? "" : list.DESC_AMENAZA.Split('|')[0]) + "'";
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(list.DESC_AMENAZA.ToString()) ? "" : list.DESC_AMENAZA.Split('|')[1]) + "'";
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(list.OBSERVACIONES.ToString()) ? "" : list.OBSERVACIONES.ToString()) + "'";
                        cmd.CommandText = "INSERT INTO [Datos$A" + i.ToString().Trim() + ":E" + (listParam.Count + 1).ToString() + "] VALUES (" + insertar + ")";
                        cmd.ExecuteNonQuery();
                    }
                    break;
                    #endregion

            }
        }
        #endregion
        #region "Plan Manejo V3"
        public VM_PlanManejo IniDatosPlanManejo(string codPM, string codTH, string modTH, string numTH, string tituTH, string indi, string cod_mtipo, string codCuenta, string resolucion_Num,string VALIAS_ROL=null)
        {
            VM_PlanManejo PM = new VM_PlanManejo();
            try
            {
                CEntBusq objBusqueda = new CEntBusq() { BusFormulario = "GENERAL", BusValor = VALIAS_ROL, COD_UCUENTA = codCuenta };
                CLogBusq oCLogicaBusqueda = new CLogBusq();
                objBusqueda = oCLogicaBusqueda.RegMostCombo(objBusqueda);
                List<VM_Cbo> listIndicador = objBusqueda.ListIndicador.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION }).ToList();
                PM.ddlODRegistro = objBusqueda.ListODs.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION });

                if (String.IsNullOrEmpty(codPM))
                {//iniciar datos para nuevo registro                                        
                    PM.lblTituloEstado = "Nuevo Registro";
                    PM.hdfManRegEstado = "1";
                    PM.hdfItemCOD_PMANEJO = "";
                    PM.hdfItemCod_THabilitante = codTH;
                    PM.ddlItemIndicador = listIndicador;
                    PM.ddlItemIndicadorId = "0000000";
                    PM.ddlODRegistroId = "0000000";
                    PM.ddlItemIndicadorEnable = true;
                    PM.hdfItemIndicador = indi;
                    PM.hdfItemCod_MTipo = cod_mtipo;
                    PM.txtItemAresolucion_Num = resolucion_Num;
                    CEntidadDependencia oCamposCombo = new CEntidadDependencia();
                    oCamposCombo.BusFormulario = "DEPENDENCIA_UBIGEO";
                    oCamposCombo.BusCriterio = "THABILITANTE";
                    oCamposCombo.BusValor = codTH;
                    oCamposCombo = new CLogicaDependencia().RegMostCombo(oCamposCombo);
                    //Dependencia Ubigeo              
                    PM.ddlDependencia = Log_Helper.ListComboLlenar(oCamposCombo.ListDependencia, "CODIGO", "DESCRIPCION", true);
                    PM.lblItemTHModalidad = modTH;
                    PM.lblItemTHNumero = numTH;
                    PM.lblItemTHTitular = tituTH;
                }
                else
                {//iniciar datos a modificar                              
                    CEntidad oCampos = new CEntidad();
                    CEntidad CEntPLAN_MANEJOItems;
                    oCampos.COD_PMANEJO = codPM;
                    PM.lblTituloEstado = "Modificando Registro";
                    PM.hdfManRegEstado = "0";
                    CEntPLAN_MANEJOItems = GetPlanManejoIdV3(oCampos);
                    PM.hdfItemCOD_PMANEJO = CEntPLAN_MANEJOItems.COD_PMANEJO;
                    PM.hdfItemCod_THabilitante = CEntPLAN_MANEJOItems.COD_THABILITANTE;
                    PM.hdfItemIndicador = CEntPLAN_MANEJOItems.INDICADOR.ToString();
                    PM.hdfItemCod_MTipo = CEntPLAN_MANEJOItems.COD_MTIPO.ToString();

                    if (CEntPLAN_MANEJOItems.ESTADO_ORIGEN == "PC")
                    {
                        PM.txtItemNumPlanComplementario = CEntPLAN_MANEJOItems.NUM_PCOMPLEMENTARIO;
                        PM.visiblePlanComplementario = true;
                    }
                    else
                    {
                        PM.visiblePlanComplementario = false;
                    }
                    //Plan de Manejo
                    PM.txtItemFechaPresentacion = CEntPLAN_MANEJOItems.FECHA_PRESENTACION.ToString();
                    PM.txtItemISDuracionFInicio = CEntPLAN_MANEJOItems.IS_DURACION_FINICIO.ToString();
                    PM.txtItemISDuracionFFin = CEntPLAN_MANEJOItems.IS_DURACION_FFIN.ToString();
                    PM.hdlblItemConsultorNombre = CEntPLAN_MANEJOItems.CONSULTOR_CODIGO;
                    PM.txtItemConsultorNRConsultor = CEntPLAN_MANEJOItems.CONSULTOR_NUM_REGISTRO_FFS;
                    PM.lblItemConsultorNombre = CEntPLAN_MANEJOItems.CONSULTOR_NOMBRE;
                    PM.lblItemConsultorDNI = CEntPLAN_MANEJOItems.CONSULTOR_DNI;
                    PM.lblItemConsultorNRProfesional = CEntPLAN_MANEJOItems.CONSULTOR_NUM_REGISTRO_PROFESIONAL;
                    PM.txtItemConsultorNRRegente = CEntPLAN_MANEJOItems.REGENTE_NUM_REGISTRO_FFS;
                    PM.txtItemItecnico_Iocular_Num = CEntPLAN_MANEJOItems.ITECNICO_IOCULAR_NUM;
                    PM.txtItemItecnico_Iocular_Fecha = CEntPLAN_MANEJOItems.ITECNICO_IOCULAR_FECHA.ToString();
                    PM.txtItemItecnico_Raprobacion_Num = CEntPLAN_MANEJOItems.ITECNICO_RAPROBACION_NUM;

                    PM.txtItemItecnico_Raprobacion_Fecha = CEntPLAN_MANEJOItems.ITECNICO_RAPROBACION_FECHA.ToString();
                    PM.txtItemAresolucion_Num = CEntPLAN_MANEJOItems.ARESOLUCION_NUM;
                    PM.txtItemAresolucion_Fecha = CEntPLAN_MANEJOItems.ARESOLUCION_FECHA.ToString();
                    PM.hdlblItemARFuncionario = CEntPLAN_MANEJOItems.ARESOLUCION_COD_FUNCIONARIO;
                    string datosAdiARF = CEntPLAN_MANEJOItems.ARESOLUCION_FUNCIONARIO_ODATOS == null ? "" : CEntPLAN_MANEJOItems.ARESOLUCION_FUNCIONARIO_ODATOS;
                    PM.lblItemARFuncionario = CEntPLAN_MANEJOItems.ARESOLUCION_FUNCIONARIO_NOMBRE + " " + datosAdiARF;
                    //PM.lblItemARFuncionarioODatos = CEntPLAN_MANEJOItems.ARESOLUCION_FUNCIONARIO_ODATOS;
                    PM.chkItemAcorde_Tdr_Vigente = (Boolean)CEntPLAN_MANEJOItems.ACORDE_TDR_VIGENTE;
                    PM.txtItemObservacion = CEntPLAN_MANEJOItems.OBSERVACION.ToString();
                    PM.txtAPROB_ACTIVIDAD_FECHA = CEntPLAN_MANEJOItems.APROB_ACTIVIDAD_FECHA.ToString();
                    PM.txtAPROB_ACTIVIDAD_AUTORIZACION = CEntPLAN_MANEJOItems.APROB_ACTIVIDAD_AUTORIDAD;
                    PM.txtAPROB_ACTIVIDAD_RESOLUCION = CEntPLAN_MANEJOItems.APROB_ACTIVIDAD_RESOLUCION;
                    PM.chkItemActividadPrioritaria = (Boolean)CEntPLAN_MANEJOItems.APROB_ACTIVIDAD_ESTADO;
                    PM.hdlblAPROB_ACTIVIDAD_NOM_FUNCIONARIO = CEntPLAN_MANEJOItems.APROB_ACTIVIDAD_FUNCIONARIO;
                    PM.lblAPROB_ACTIVIDAD_NOM_FUNCIONARIO = CEntPLAN_MANEJOItems.FUNCIONARIO_APROB_ACTIVIDAD;
                    PM.ddlODRegistroId = CEntPLAN_MANEJOItems.COD_OD_REGISTRO;
                    //DIRECCION DEL REGENTE
                    PM.txtUbigeo = CEntPLAN_MANEJOItems.UBIGEO_REGENTE;
                    PM.txtDirecion = CEntPLAN_MANEJOItems.DIRECCION_REGENTE;
                    PM.txtCodUbigeo = CEntPLAN_MANEJOItems.COD_UBIGEO_REGENTE;
                   
                    //Tara
                    PM.txtItemTaraAPredio = CEntPLAN_MANEJOItems.TARA_AREA_PREDIO.ToString();
                    PM.txtItemTaraAManejo = CEntPLAN_MANEJOItems.TARA_AREA_MANEJO.ToString();
                    //txtItemTara_NAAprovecha.Text = CEntPLAN_MANEJOItems.NUM_ARBOLES_EDAD_APRO.ToString();
                    //txtItemTara_NANoAprovecha.Text = CEntPLAN_MANEJOItems.NUM_ARBOLES_NOEDAD_APRO.ToString();
                    //txtItemTara_PArboles.Text = CEntPLAN_MANEJOItems.PESO_ARBOLES_EDAD_APRO.ToString();
                    PM.txtItemTara_ACapacitacion = CEntPLAN_MANEJOItems.ACTIVIDAD_CAPACITACION.ToString();
                    PM.txtItemTara_MComercializacion = CEntPLAN_MANEJOItems.MODALIDAD_COMERCIALIZACION.ToString();
                    PM.txtItemTara_AnoEPlantacion = CEntPLAN_MANEJOItems.ANO_EPLANTACION.ToString();
                    //txtItemTara_BExtraFEmision.Text = CEntPLAN_MANEJOItems.BEXTRACCION_FEMISION.ToString();

                    //Integracion SIADO
                    // IntegracionSIADODatos.listarExpedientesSIADO(hdfItemCod_THabilitante.Value, "TITULO HABILITANTE");
                    // IntegracionSIADODatos.MostrarFicheros_SIADO("SUBTIP_TITDOCSIGO", "PLAN DE MANEJO", hdfItemCOD_PMANEJO.Value);
                    // PM.lbtItemTaraInventarioSelec = String.Format("Ir Inventario ( {0} )", CEntPLAN_MANEJOItems.ListPMTINVENTARIO.Count.ToString());
                    //
                    // ItemRegistroValidaOpciones(hdfItemIndicador.Value); ver
                    //
                    //Observaciones de control de calidad
                    PM.OBSERV_SUBSANAR = (Boolean)CEntPLAN_MANEJOItems.OBSERV_SUBSANAR;
                    bool enableIndicador = true;
                    string itemSelectIndicador = CEntPLAN_MANEJOItems.COD_ESTADO_DOC;
                    Log_Helper.controla_estado_calidad(CEntPLAN_MANEJOItems.COD_ESTADO_DOC, ref listIndicador, ref enableIndicador, ref itemSelectIndicador);
                    PM.ddlItemIndicador = listIndicador;
                    PM.ddlItemIndicadorId = itemSelectIndicador;
                    PM.ddlItemIndicadorEnable = enableIndicador;
                    PM.lblUsuarioRegistro = CEntPLAN_MANEJOItems.USUARIO_REGISTRO;
                    PM.lblUsuarioControl = CEntPLAN_MANEJOItems.USUARIO_CONTROL;

                    PM.ddlDependencia = Log_Helper.ListComboLlenar(CEntPLAN_MANEJOItems.ListDependencia, "CODIGO", "DESCRIPCION", true);

                    if (CEntPLAN_MANEJOItems.COD_DEPENDENCIA != "0")
                        PM.ddlDependenciaId = CEntPLAN_MANEJOItems.COD_DEPENDENCIA;

                    PM.lblItemTHModalidad = CEntPLAN_MANEJOItems.MODALIDAD;
                    PM.lblItemTHNumero = CEntPLAN_MANEJOItems.NUM_THABILITANTE;
                    PM.lblItemTHTitular = CEntPLAN_MANEJOItems.PERSONA_TITULAR;
                }
               
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return PM;
        }
        public ListResult GuardarPlanManejo(VM_PlanManejo dto, string codCuenta)
        {
            ListResult result = new ListResult();
            string msjRespuesta = "El Registro se Guardo Correctamente", appServer = "";
            try
            {
                String OUTPUTPARAM = "";
                CEntidad oCampos = new CEntidad();

                oCampos.COD_THABILITANTE = dto.hdfItemCod_THabilitante;
                oCampos.NUM_PCOMPLEMENTARIO = dto.txtItemNumPlanComplementario;
                oCampos.FECHA_PRESENTACION = dto.txtItemFechaPresentacion == null ? DateTime.Now.ToShortDateString() : dto.txtItemFechaPresentacion;
                oCampos.IS_DURACION_FINICIO = dto.txtItemISDuracionFInicio;
                oCampos.IS_DURACION_FFIN = dto.txtItemISDuracionFFin;
                oCampos.CONSULTOR_CODIGO = dto.hdlblItemConsultorNombre;
                oCampos.NUM_REGISTRO_PROFESIONAL = dto.lblItemConsultorNRProfesional;
                oCampos.CONSULTOR_NUM_REGISTRO_FFS = dto.txtItemConsultorNRConsultor;
                oCampos.REGENTE_NUM_REGISTRO_FFS = dto.txtItemConsultorNRRegente;
                oCampos.ITECNICO_IOCULAR_NUM = dto.txtItemItecnico_Iocular_Num;
                oCampos.ITECNICO_IOCULAR_FECHA = dto.txtItemItecnico_Iocular_Fecha;
                oCampos.ITECNICO_RAPROBACION_NUM = dto.txtItemItecnico_Raprobacion_Num;
                oCampos.ITECNICO_RAPROBACION_FECHA = dto.txtItemItecnico_Raprobacion_Fecha;
                oCampos.ARESOLUCION_NUM = dto.txtItemAresolucion_Num;
                oCampos.ARESOLUCION_FECHA = dto.txtItemAresolucion_Fecha;
                oCampos.ARESOLUCION_COD_FUNCIONARIO = dto.hdlblItemARFuncionario;
                oCampos.ACORDE_TDR_VIGENTE = dto.chkItemAcorde_Tdr_Vigente;
                oCampos.COD_UCUENTA = codCuenta;
                oCampos.OBSERVACION = dto.txtItemObservacion;
                // oCampos.COD_MTIPO = dto.hdfItemCod_MTipo;
                oCampos.ESTADO_ORIGEN = "";
                oCampos.COD_MTIPO_HIJO = "";
                oCampos.APROB_ACTIVIDAD_ESTADO = dto.chkItemActividadPrioritaria;
                oCampos.APROB_ACTIVIDAD_FECHA = dto.txtAPROB_ACTIVIDAD_FECHA;
                oCampos.APROB_ACTIVIDAD_AUTORIDAD = dto.txtAPROB_ACTIVIDAD_AUTORIZACION;
                oCampos.APROB_ACTIVIDAD_RESOLUCION = dto.txtAPROB_ACTIVIDAD_RESOLUCION;
                oCampos.APROB_ACTIVIDAD_FUNCIONARIO = dto.hdlblAPROB_ACTIVIDAD_NOM_FUNCIONARIO;
                oCampos.COD_OD_REGISTRO = dto.ddlODRegistroId;
                oCampos.UBIGEO_REGENTE = dto.txtUbigeo;
                oCampos.COD_UBIGEO_REGENTE = dto.txtCodUbigeo;
                oCampos.DIRECCION_REGENTE = dto.txtDirecion;
                //Tara
                oCampos.TARA_AREA_PREDIO = Decimal.Parse((dto.txtItemTaraAPredio == null ? "0" : dto.txtItemTaraAPredio));
                oCampos.TARA_AREA_MANEJO = Decimal.Parse((dto.txtItemTaraAManejo == null ? "0" : dto.txtItemTaraAManejo));
                oCampos.ACTIVIDAD_CAPACITACION = dto.txtItemTara_ACapacitacion;
                oCampos.MODALIDAD_COMERCIALIZACION = dto.txtItemTara_MComercializacion;
                oCampos.ANO_EPLANTACION = Int32.Parse((dto.txtItemTara_AnoEPlantacion) == null ? "0" : dto.txtItemTara_AnoEPlantacion);

                oCampos.COD_PMANEJO = dto.hdfItemCOD_PMANEJO == null ? "" : dto.hdfItemCOD_PMANEJO;


                oCampos.OUTPUTPARAM01 = "";
                //Tabla de Enlance HIjo
                oCampos.HIJO_NIVEL = 0;

                //Lista de Objetos
                oCampos.ListPMDTTIOCULAR = dto.ListPMDTTIOCULAR;
                oCampos.ListPMDTTRAPROBACION = dto.ListPMDTTRAPROBACION;
                oCampos.ListPMDISITUFLORA = dto.ListPMDISITUFLORA;
                oCampos.ListPMDISITUFAUNA = dto.ListPMDISITUFAUNA;
                oCampos.ListPMDISITUCAREA = dto.ListPMDISITUCAREA;
                oCampos.ListPMTDPPAPROVECHAMIENTO = dto.ListPMTDPPAPROVECHAMIENTO;
                oCampos.ListPMTDOOPCIONESEAPROVE = dto.ListPMTDOOPCIONESEAPROVE;
                oCampos.ListPMTDOOPCIONESPSILVI = dto.ListPMTDOOPCIONESPSILVI;

                //  oCampos.ESTADO_ORIGEN = dto.hdfItemEstadoOrigen; //ss
                oCampos.ListPMTINVENTARIO = dto.ListPMTINVENTARIO;
                oCampos.ListEliTABLA = dto.ListEliTABLA;
                //tara
                oCampos.ListPMTAAPROVECHAMIENTO = dto.ListPMTAAPROVECHAMIENTO;
                oCampos.ListPMTCOORDENADAUTM = dto.ListPMTCOORDENADAUTM;
                oCampos.ListPMTAUTORIZADAEXTRA = dto.ListPMTAUTORIZADAEXTRA;
                //
                oCampos.ListPMINFORME_ANUAL = dto.ListPMINFORME_ANUAL;
                oCampos.ListPMECOTPROGIMPLEMENTAR = dto.ListPMECOTPROGIMPLEMENTAR;
                //
                oCampos.RegEstado = Int32.Parse(dto.hdfManRegEstado);
                //

                //cotrol de calidad
                oCampos.COD_ESTADO_DOC = dto.ddlItemIndicadorId;
                oCampos.OBSERVACIONES_CONTROL = dto.txtControlCalidadObservaciones;
                oCampos.OBSERV_SUBSANAR = dto.OBSERV_SUBSANAR;

                oCampos.COD_DEPENDENCIA = dto.ddlDependenciaId == "-" ? null : dto.ddlDependenciaId;

                oCampos.ListErrorMaterialGeneral = dto.ListPMErrorMaterialG;
                oCampos.ListErrorMaterialAdicional = dto.ListPMErrorMaterialA;

                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    OracleTransaction tr = cn.BeginTransaction();
                    try
                    {
                        //Grabando Base Datos                        
                        OUTPUTPARAM = oCDatos.RegGrabarV3(cn, oCampos, tr);
                        if (dto.appClient == null)
                        {
                            dto.appClient = "";
                            dto.appData = "";
                        }
                        if (dto.appClient != "" && dto.appClient.Split('|')[1] == "TRANSFERIR")
                        {
                            //Grabar dato de la transferencia
                            CapaEntidad.DOC.Ent_ANTECEDENTE_EXPEDIENTE oParamsAExpedienteSitd = new CapaEntidad.DOC.Ent_ANTECEDENTE_EXPEDIENTE();
                            oParamsAExpedienteSitd.TIPO = "TRANSFERIR"; oParamsAExpedienteSitd.SUBTIPO = "PMANEJO";
                            oParamsAExpedienteSitd.COD_AEXPEDIENTE_SITD = Convert.ToInt32(dto.appData.Split('¬')[0]);
                            oParamsAExpedienteSitd.COD_TRAMITE_SITD = Convert.ToInt32(dto.appData.Split('¬')[1]);
                            oParamsAExpedienteSitd.OBSERVACION = dto.appData.Split('¬')[6];
                            oParamsAExpedienteSitd.COD_PMANEJO = OUTPUTPARAM;
                            oParamsAExpedienteSitd.RESOLUCION_POA = dto.txtItemAresolucion_Num;
                            oParamsAExpedienteSitd.ESTADO_AEXPEDIENTE = dto.appData.Split('¬')[2] == "0403" ? "Transferido" : "Pendiente";//0401:Plan Manejo (Fauna)
                            oParamsAExpedienteSitd.COD_UCUENTA = codCuenta;
                            oParamsAExpedienteSitd.ORIGEN_REGISTRO = 1;//ORIGEN SITD
                            oParamsAExpedienteSitd.OUTPUTPARAM01 = "";
                            if (oParamsAExpedienteSitd.RESOLUCION_POA != dto.appData.Split('¬')[5]) oParamsAExpedienteSitd.RegEstado = 2;//Datos del SITD modificado

                            CapaDatos.DOC.Dat_ANTECEDENTE_EXPEDIENTE datAntecedentesInter = new CapaDatos.DOC.Dat_ANTECEDENTE_EXPEDIENTE();
                            datAntecedentesInter.RegGrabarV3(cn, oParamsAExpedienteSitd, tr);
                            appServer = "2";
                        }
                        else if (dto.appClient != "" && dto.appClient.Split('|')[1] == "VISUALIZAR")
                        {
                            appServer = "2";
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
                result.appServer = appServer;
                result.AddResultado(msjRespuesta, true);
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
                result.appServer = appServer;
                result.AddResultado(ex.Message, false);
            }
            return result;
        }
        public ListResult EliminarPlanManejo(string codPM, string codCuenta)
        {
            ListResult result = new ListResult();
            try
            {
                CEntidad oCampos = new CEntidad();
                oCampos.COD_PMANEJO = codPM;
                this.RegEliminar(oCampos);
                result.AddResultado("Se elimino correctamente el Plan de Manejo :" + codPM, true);
            }
            catch (Exception ex)
            {
                result.AddResultado("Error", false, ex.Message);
            }
            return result;
        }
        public VM_ExSitu IniDatosExSitu(string codPM, string modTH, string numTH, string tituTH,
                                       string indi, string cod_mtipo)
        {
            VM_ExSitu VM_EX;
            try
            {
                VM_EX = new VM_ExSitu();
                VM_EX.thM = modTH;
                VM_EX.thN = numTH;
                VM_EX.thT = tituTH;
                VM_EX.codPm = codPM;
                VM_EX.thInd = indi;
                VM_EX.thMT = cod_mtipo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return VM_EX;
        }
        public List<Dictionary<string, string>> RegMostrarListaItemsESituV3(CEntidad oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegMostrarListaItemsESituV3(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public VM_PlanManejoList GetPlanManejoListIdV3(string codPM)
        {
            CEntidad oCEntidad = new CEntidad() { COD_PMANEJO = codPM };
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.GetPlanManejoListIdV3(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string GetCodEspecie(string nombre_cientifico, string nombre_comun)
        {
            CEntidad oCEntidad = new CEntidad() { NOMBRE_CIENTIFICO = nombre_cientifico, NOMBRE_COMUN = nombre_comun };
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.GetCodEspecie(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string GetCodAmenaza(string grado, string categoria)
        {
            CEntidad oCEntidad = new CEntidad() { GRADO = grado, CATEGORIA = categoria };
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.GetCodAmenaza(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region "ExSitu V3"
        public CEntidad GetPlanManejoIdV3(CEntidad oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.GetPlanManejoIdV3(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public VM_Cbo_General GetDatosComboV3(string[] opciones)
        {
            VM_Cbo_General resultado = new VM_Cbo_General();
            using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
            {
                cn.Open();
                CEntidad oCampos;
                for (var i = 0; i < opciones.Length; i++)
                {
                    oCampos = new CEntidad();
                    oCampos.BusFormulario = "PLAN_MANEJO";
                    oCampos.BusCriterio = opciones[i];
                    switch (oCampos.BusCriterio)
                    {
                        case "Especie_Fauna":
                            resultado.ListMComboEspecieFauna = oCDatos.GetDatosComboV3(cn, oCampos);
                            break;
                        case "Motivo_Exsitu":
                            resultado.ListMComboMotivo = oCDatos.GetDatosComboV3(cn, oCampos);
                            break;
                        case "Exsitu_Documento":
                            resultado.ListMComboDocumento = oCDatos.GetDatosComboV3(cn, oCampos);
                            break;
                    }
                }
                cn.Close();
            }
            return resultado;
        }
        public List<VM_Cbo> GetDatosComboV3(string busFormulario, string busCriterio, bool addSeleccionar = false)
        {
            CEntidad oCampos = new CEntidad();
            oCampos.BusFormulario = busFormulario;
            oCampos.BusCriterio = busCriterio;
            using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
            {
                cn.Open();
                return oCDatos.GetDatosComboV3(cn, oCampos, addSeleccionar);
            }
        }
        public VM_ExSituItem GetESituAnualIdV3(String codPM, string codSec)
        {
            VM_ExSituItem vm = new VM_ExSituItem();
            CEntidad oCampos = new CEntidad();
            oCampos.COD_PMANEJO = codPM;
            oCampos.COD_SECUENCIAL = Convert.ToInt32(codSec);
            oCampos.BusCriterio = "1";
            using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
            {
                cn.Open();
                vm = oCDatos.GetESituAnualIdV3(cn, oCampos);
            }
            return vm;
        }
        public VM_PGeneticoItem GetESituPGeneticoIdV3(String codPM, string codSec)
        {
            CEntidad oCampos = new CEntidad();
            oCampos.COD_PMANEJO = codPM;
            oCampos.COD_SECUENCIAL = Convert.ToInt32(codSec);
            oCampos.BusCriterio = "2";
            using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
            {
                cn.Open();
                return oCDatos.GetESituPGeneticoIdV3(cn, oCampos);
            }
        }
        public VM_BalanceItem GetESituBalanceIdV3(String codPM, string codSec, string busCriterio)
        {
            VM_BalanceItem vm = new VM_BalanceItem();
            CEntidad oCampos = new CEntidad();
            oCampos.COD_PMANEJO = codPM;
            oCampos.COD_SECUENCIAL = Convert.ToInt32(codSec);
            oCampos.BusCriterio = busCriterio;
            using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
            {
                cn.Open();
                vm = oCDatos.GetESituBalanceIdV3(cn, oCampos);
            }
            return vm;
        }
        public VM_BalanceItem InitEsituBalance(String codPM, string codSec, string estado, string tipo)
        {
            VM_BalanceItem vm;
            if (Convert.ToInt32(estado) == 1)
            { //init agregar 
                vm = new VM_BalanceItem();
                vm.hdEstado = estado;
                vm.COD_SECUENCIAL = 0;
                vm.lblTitulo = "Nuevo";
                vm.hdTipo = tipo.Trim();

            }
            else
            {//init modificar
                string busCriterio = tipo.Trim() == "I" ? "3" : "4";
                vm = this.GetESituBalanceIdV3(codPM, codSec, busCriterio);
                vm.lblTitulo = "Editar";
            }
            vm.COD_PMANEJO = codPM.Trim();
            //llenando combos
            VM_Cbo_General listCombos = new VM_Cbo_General();
            listCombos = this.GetDatosComboV3(new string[] { "Especie_Fauna", "Motivo_Exsitu", "Exsitu_Documento" });
            vm.ddlbfs_especie = listCombos.ListMComboEspecieFauna;
            vm.ddlbfs_documento = listCombos.ListMComboDocumento;
            vm.ddlbfs_motivo = listCombos.ListMComboMotivo.Where(m => m.Tipo == vm.hdTipo).ToList();
            vm.demo = new List<Dictionary<string, string>>();
            return vm;
        }
        public VM_ExSituItem InitEsituAnual(String codPM, string codSec, string estado)
        {
            VM_ExSituItem vm;
            if (Convert.ToInt32(estado) == 1)
            { //init agregar
                vm = new VM_ExSituItem();
                vm.hdEstado = estado;
                vm.COD_SECUENCIAL = 0;
                vm.lblTitulo = "Nuevo";
            }
            else
            {//init modificar
                vm = this.GetESituAnualIdV3(codPM, codSec);
                vm.lblTitulo = "Editar";
            }
            vm.COD_PMANEJO = codPM.Trim();
            return vm;
        }
        public VM_PGeneticoItem InitEsituPGenetivo(String codPM, string codSec, string estado)
        {
            VM_PGeneticoItem vm;
            if (Convert.ToInt32(estado) == 1)
            { //init agregar
                vm = new VM_PGeneticoItem();
                vm.hdEstado = estado;
                vm.COD_SECUENCIAL = 0;
                vm.lblTitulo = "Nuevo";
            }
            else
            {//init modificar
                vm = this.GetESituPGeneticoIdV3(codPM, codSec);
                vm.lblTitulo = "Editar";
            }
            vm.COD_PMANEJO = codPM.Trim();
            return vm;
        }
        public ListResult AddEditESituBalance(VM_BalanceItem vm, string codCuentaUsuario)
        {
            ListResult result = new ListResult();
            try
            {
                CEntidad ocampo = new CEntidad();
                ocampo.COD_PMANEJO = vm.COD_PMANEJO;
                ocampo.COD_SECUENCIAL = vm.COD_SECUENCIAL;
                ocampo.COD_ESPECIES = vm.ddlbfs_especieId;
                ocampo.COD_MOTIVO = vm.ddlbfs_motivo_Id;
                ocampo.NUM_DOCUMENTO = vm.txtbfs_numero == null ? "" : vm.txtbfs_numero.Trim();
                ocampo.COD_SDOCUMENTO = vm.ddlbfs_documentoId == null ? "0000001" : vm.ddlbfs_documentoId;
                ocampo.NUM_SDOCUMENTO = vm.txtbfs_num_documento == null ? "" : vm.txtbfs_num_documento.Trim();
                ocampo.FECHA_EMISION = vm.txtbfs_femision == null ? "" : vm.txtbfs_femision.Trim();
                ocampo.FECHA_RECEPCION = vm.txtbfs_frecepcion == null ? "" : vm.txtbfs_frecepcion;
                ocampo.OBSERVACION = vm.txtbfs_observacion == null ? "" : vm.txtbfs_observacion;
                ocampo.TIPO = vm.hdTipo;
                ocampo.RegEstado = Convert.ToInt32(vm.hdEstado.Trim());
                String cod_secuencial = this.PLAN_MANEJO_EXSITU_BINDIVIDUOS_Grabar(ocampo);
                result.success = true;
                if (ocampo.RegEstado == 0)
                {
                    result.msj = "Se actualizo correctamente la informacion";
                }
                else
                {
                    result.msj = "Se registro correctamente la informacion";
                    result.values = new List<string>();
                    result.values.Add(cod_secuencial);
                }
            }
            catch (Exception ex)
            {
                result.AddResultado("", false, ex.Message);
            }
            return result;
        }
        public ListResult AddEditESituIAnual(VM_ExSituItem vm, string codCuentaUsuario)
        {
            ListResult result = new ListResult();
            try
            {
                CEntidad oCampos = new CEntidad();
                oCampos.COD_PMANEJO = vm.COD_PMANEJO.Trim();
                oCampos.COD_SECUENCIAL = vm.COD_SECUENCIAL;
                oCampos.COD_UCUENTA = codCuentaUsuario;
                oCampos.ANO_EJECUTADO = Convert.ToInt32(vm.txtItemESituIAnual_Ano);
                oCampos.FECHA_EMISION = vm.txtItemESituIAnual_FEmision;
                oCampos.FECHA_RECEPCION = vm.txtItemESituIAnual_FRecepcion;
                oCampos.ACORDE_TDR_VIGENTE = vm.chkItemAcorde_Tdr_Vigente;
                oCampos.OBSERVACION = vm.txtItemESituIAnual_Observacion == null ? "" : vm.txtItemESituIAnual_Observacion.Trim();
                oCampos.PROFESIONAL_CODIGO = vm.hdtxtProfesional;
                oCampos.PROFESIONAL_NUM_REGISTRO_FFS = vm.txtItemESituIAnual_PNR.Trim();
                oCampos.RegEstado = Int32.Parse(vm.hdEstado);
                Int32 COD_SECUENCIAL = this.RegGrabarESituIAnual(oCampos);
                result.success = true;
                if (oCampos.RegEstado == 0)
                {
                    result.msj = "Se actualizo correctamente la informacion";
                }
                else
                {
                    result.msj = "Se registro correctamente la informacion";
                    result.values = new List<string>();
                    result.values.Add(COD_SECUENCIAL.ToString());
                }
            }
            catch (Exception ex)
            {
                result.AddResultado("", false, ex.Message);
            }
            return result;
        }
        public ListResult AddEditESituPGenetico(VM_PGeneticoItem vm, string codCuentaUsuario)
        {
            ListResult result = new ListResult();
            try
            {
                CEntidad oCampos = new CEntidad();
                oCampos.COD_PMANEJO = vm.COD_PMANEJO.Trim();
                oCampos.COD_PGSECUENCIAL = vm.COD_SECUENCIAL;
                // oCampos.COD_UCUENTA = codCuentaUsuario;
                oCampos.ARESOLUCION_NUM = vm.txtnum_resolucion == null ? "" : vm.txtnum_resolucion.Trim();
                oCampos.ARESOLUCION_FECHA = vm.txtfecha_emision_resolucion.Trim();
                oCampos.ARESOLUCION_COD_FUNCIONARIO = vm.hdfItemPGenetico_PCodigo.Trim();
                oCampos.OBSERVACION = vm.lblItemPGenetico_Observacion == null ? "" : vm.lblItemPGenetico_Observacion.Trim();
                oCampos.RegEstado = Int32.Parse(vm.hdEstado);
                oCampos.OUTPUTPARAM01 = "";
                string COD_SECUENCIAL = this.PLAN_MANEJO_EXSITU_PGENETICO_Grabar(oCampos);
                result.success = true;
                if (oCampos.RegEstado == 0)
                {
                    result.msj = "Se actualizo correctamente la informacion";
                }
                else
                {
                    result.msj = "Se registro correctamente la informacion";
                    result.values = new List<string>();
                    result.values.Add(COD_SECUENCIAL.ToString());
                }
            }
            catch (Exception ex)
            {
                result.AddResultado("", false, ex.Message);
            }
            return result;
        }
        public ListResult DeleteExsitu(string codPM, string codS, string tipo, string codE = "")
        {
            ListResult result = new ListResult();
            try
            {
                CEntidad oCampos = new CEntidad();
                oCampos.COD_PMANEJO = codPM.Trim();
                if (tipo == "G")
                    oCampos.COD_PGSECUENCIAL = Convert.ToInt32(codS);
                else oCampos.COD_SECUENCIAL = Convert.ToInt32(codS);
                if (tipo.Trim() == "I" || tipo.Trim() == "E")
                {
                    oCampos.COD_ESPECIES = codE.Trim();
                }
                switch (tipo.Trim())
                {
                    case "A": this.RegEliminarESituIAnual(oCampos); break;
                    case "G": this.RegEliminarESituPGenetico(oCampos); break;
                    case "I": this.RegEliminarESituBIndividuos(oCampos); break;
                    case "E": this.RegEliminarESituBIndividuos(oCampos); break;
                }
                result.msj = "Se Elimino Correctamente el Item";
                result.success = true;
            }
            catch (Exception ex)
            {
                result.msj = "Error al eliminar el item";
                result.msjError = ex.Message;
                result.success = false;
            }
            return result;
        }
        public List<Dictionary<string, string>> LogMostrarListaItemsESituV3(string codPM, string busCriterio)
        {
            CEntidad oCampos = new CEntidad();
            oCampos.COD_PMANEJO = codPM;
            oCampos.BusCriterio = busCriterio;
            return this.RegMostrarListaItemsESituV3(oCampos);
        }
        #endregion
    }
}
