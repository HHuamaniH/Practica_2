using CapaDatos.DOC;
using CapaEntidad.DOC;
using CapaEntidad.ViewModel;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
//using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using CDatos = CapaDatos.DOC.Dat_POA;
using CEntidad = CapaEntidad.DOC.Ent_POA;
using CEntidadDependencia = CapaEntidad.GENE.Ent_DEPENDENCIA_UBIGEO;
using CEntPersona = CapaEntidad.DOC.Ent_GENEPERSONA;
using CLogicaDependencia = CapaLogica.GENE.Log_DEPENDENCIA_UBIGEO;


/// <summary>
/// 2014-08-26  EPB Se añade el metodo RegMostItemsHijoMadNoMad
/// </summary>
namespace CapaLogica.DOC
{
    /// <summary>
    /// 
    /// </summary>
	public class Log_POA
    {
        private CDatos oCDatos = new CDatos();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public List<CEntidad> ListarVertice(string COD_THABILITANTE, int NumPoa)
        {
            CEntidad oCEntidad = new CEntidad();
            oCEntidad.COD_THABILITANTE = COD_THABILITANTE;
            oCEntidad.NUM_POA = NumPoa;

            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.listVertice(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CEntidad> ListarRAPoa(string COD_THABILITANTE, int NumPoa)
        {
            CEntidad oCEntidad = new CEntidad();
            oCEntidad.COD_THABILITANTE = COD_THABILITANTE;
            oCEntidad.NUM_POA = NumPoa;

            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.listRAPoa(cn, oCEntidad);
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public CEntidad RegMostrarListaHijoItems(CEntidad oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegMostrarListaHijoItems(cn, oCEntidad);
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
        public String RegGrabar(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegGrabar(cn, oCampoEntrada);
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
        public List<CEntidad> Temp_Validar_Especie(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.Temp_Validar_Especie(cn, oCampoEntrada);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Temp_Validad_CodSistema(string asCodSistema)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.Temp_Validad_CodSistema(cn, asCodSistema);
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
        /// Retorna la tabla de Censo Maderable y No Maderable
        /// </summary>
        /// <param name="oCEntidad">Se pasan los parametros COD_THABILITANTE y NUM_POA</param>
        /// <returns></returns>
        public CEntidad RegMostItemsHijoMadNoMad(CEntidad oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegMostItemsHijoMadNoMad(cn, oCEntidad);
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
        public List<CEntPersona> MostTOcularitem(CEntidad oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.MostTOcularitem(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region "Migracion - SIGO v3"
        public VM_POA IniDatosPOA(string codigoThabilitante, string descripcionTHabilitante, string cod_cuenta, int nuevo, string appClient, string appData, string lstManMenu, string rol="")
        {
            VM_POA POA_VM;
            try
            {
                POA_VM = new VM_POA();

                //iniciar nuevo item
                if (nuevo == 1)
                {
                    //cargando datos   
                    POA_VM.ItemTitulo = "Nuevo Registro";
                    if (appClient != null && appData != null)
                    {
                        string origen = appClient.Split('|')[2];
                        if (origen == "PLAN")
                        {
                            Log_BUSQUEDA oLogBusqueda = new Log_BUSQUEDA();
                            Ent_BUSQUEDA oTh = new Ent_BUSQUEDA()
                            {
                                BusFormulario = (lstManMenu == "1" ? "POA" : (lstManMenu == "2" ? "DEMA" : "PMFI")),
                                BusCriterio = "GRI_TH_NUMERO",
                                BusValor = appData.Split('¬')[4]
                            };
                            oTh = oLogBusqueda.RegMostrarLista(oTh).Where(th => th.CODIGO == appData.Split('¬')[3]).FirstOrDefault();
                            POA_VM.hdfItemCod_THabilitante = oTh.CODIGO;
                            POA_VM.lblItemTHModalidad = oTh.PARAMETRO01;
                            POA_VM.lblItemTHNumero = oTh.NUMERO;
                            POA_VM.lblItemTHTitular = oTh.PARAMETRO02;
                            POA_VM.hdfItemIndicador = oTh.PARAMETRO03;
                            POA_VM.hdfItemCod_MTipo = oTh.PARAMETRO04;
                            POA_VM.hdfItemEstadoOrigen = oTh.PARAMETRO06;
                            POA_VM.txtItemAresolucion_Num = appData.Split('¬')[5];
                            POA_VM.appClient = appClient;
                            POA_VM.appData = appData;
                        }
                    }
                    else
                    {
                        POA_VM.hdfItemCod_THabilitante = codigoThabilitante.Trim();
                        POA_VM.lblItemTHModalidad = descripcionTHabilitante.Split('|')[0].ToString();
                        POA_VM.lblItemTHNumero = descripcionTHabilitante.Split('|')[1].ToString();
                        POA_VM.lblItemTHTitular = descripcionTHabilitante.Split('|')[2].ToString();
                        POA_VM.hdfItemIndicador = descripcionTHabilitante.Split('|')[3].ToString();
                        POA_VM.hdfItemCod_MTipo = descripcionTHabilitante.Split('|')[4].ToString();
                        POA_VM.hdfItemEstadoOrigen = descripcionTHabilitante.Split('|')[6].ToString();
                    }

                    LlenarCombos(ref POA_VM, cod_cuenta);
                    POA_VM.ltrItemEtiNPoa = (POA_VM.hdfItemIndicador == "EC" ? "Número P. Complementario" : "Número POA");
                    POA_VM.hdfItemBExtPOA_RegEstado = "1";

                    POA_VM.hdfManRegEstado = "1";
                    switch (POA_VM.hdfItemEstadoOrigen)
                    {
                        case "PN":
                            POA_VM.lbltextapru = "Resolución que Aprueba el POA";
                            POA_VM.lbltextEspeciesApru = "Especies Aprobadas de la Resolución de Aprobación del POA";
                            POA_VM.lbltextrecoaprob = "Informe Técnico que Recomienda la Aprobación del POA";
                            //  POA_VM.lbltextrefo = "Resolución que Reformula POA";
                            break;
                        case "DEMA":
                            POA_VM.lbltextapru = "Resolución que Aprueba la Declaración de Manejo";
                            POA_VM.lbltextEspeciesApru = "Especies Aprobadas de la Resolución de Aprobación de la Declaración de Manejo";
                            POA_VM.lbltextrecoaprob = "Informe Técnico que Recomienda la Aprobación de la Declaración de Manejo";
                            // POA_VM.lbltextrefo = "Resolución que Reformula la Declaración de Manejo";
                            POA_VM.txtItemNumPOA = "50";
                            POA_VM.txtNombrePOA = "Declaración de Manejo";
                            break;
                        case "PMFI":
                            POA_VM.lbltextapru = "Resolución que Aprueba el PMFI (PO 1)";
                            POA_VM.lbltextEspeciesApru = "Especies Aprobadas de la Resolución de Aprobación del PMFI (PO 1)";
                            POA_VM.lbltextrecoaprob = "Informe Técnico que Recomienda la Aprobación del PMFI (PO 1)";
                            //POA_VM.lbltextrefo = "Resolución que Reformula el PMFI (PO 1)";
                            POA_VM.txtNombrePOA = "Plan de Manejo Forestal Intermedio (PMFI)";
                            break;
                    }
                    CEntidadDependencia oCamposCombo = new CEntidadDependencia();
                    oCamposCombo.BusFormulario = "DEPENDENCIA_UBIGEO";
                    oCamposCombo.BusCriterio = "THABILITANTE";
                    oCamposCombo.BusValor = POA_VM.hdfItemCod_THabilitante;
                    oCamposCombo = new CLogicaDependencia().RegMostCombo(oCamposCombo);
                    //Dependencia Ubigeo              
                    POA_VM.ddlDependencia = Log_Helper.ListComboLlenar(oCamposCombo.ListDependencia, "CODIGO", "DESCRIPCION", true);
                    POA_VM.ListParcela = new List<CEntidad>();
                }
                if (nuevo == 0) //editar
                {

                    POA_VM.rol = rol;
                    string estado_origen = "";
                    LlenarCombos(ref POA_VM, cod_cuenta);
                    CEntidad datModificar = new CEntidad();
                    CEntidad oCamposMod = new CEntidad();
                    if (appClient != null && appData != null)
                    {
                        Log_BUSQUEDA oLogBusqueda = new Log_BUSQUEDA();
                        Ent_BUSQUEDA oPoa = new Ent_BUSQUEDA()
                        {
                            BusFormulario = (lstManMenu == "1" ? "POA" : "DEMA"),
                            BusCriterio = "COD_THABILITANTE|POA",
                            BusValor = appData.Split('¬')[3] + "|" + appData.Split('¬')[4]
                        };
                        oPoa = oLogBusqueda.RegMostrarLista(oPoa).Where(th => th.CODIGO == appData.Split('¬')[3]).FirstOrDefault();
                        oCamposMod.COD_THABILITANTE = oPoa.CODIGO;
                        oCamposMod.NUM_POA = Int32.Parse(appData.Split('¬')[4]);
                        estado_origen = oPoa.PARAMETRO08;

                        //Titulo Habilitante
                        POA_VM.lblItemTHModalidad = oPoa.PARAMETRO05;
                        POA_VM.lblItemTHNumero = oPoa.PARAMETRO07;
                        POA_VM.lblItemTHTitular = oPoa.PARAMETRO06;
                        POA_VM.appClient = appClient;
                        POA_VM.appData = appData;
                    }
                    else if (descripcionTHabilitante != "")
                    {
                        //Cargando datos
                        oCamposMod.COD_THABILITANTE = descripcionTHabilitante.Split('|')[0];
                        oCamposMod.NUM_POA = Int32.Parse(descripcionTHabilitante.Split('|')[1]);
                        estado_origen = descripcionTHabilitante.Split('|')[2];

                        //Titulo Habilitante
                        POA_VM.lblItemTHModalidad = descripcionTHabilitante.Split('|')[3];
                        POA_VM.lblItemTHNumero = descripcionTHabilitante.Split('|')[4];
                        POA_VM.lblItemTHTitular = descripcionTHabilitante.Split('|')[5];
                    }

                    if (estado_origen == "R")//REINGRESO                    
                        datModificar = RegMostrarListaHijoItems(oCamposMod);
                    else
                        datModificar = RegMostrarListaItems(oCamposMod);


                    POA_VM.hdfItemIndicador = datModificar.INDICADOR.ToString();
                    POA_VM.hdfItemCod_MTipo = datModificar.COD_MTIPO.ToString();
                    POA_VM.hdfItemEstadoOrigen = datModificar.ESTADO_ORIGEN.ToString();
                    //POA
                    POA_VM.hdfItemCod_THabilitante = datModificar.COD_THABILITANTE;
                    POA_VM.txtItemNumPOA = datModificar.NUM_POA.ToString();
                    POA_VM.txtNombrePOA = datModificar.NOMBRE_POA.ToString();
                    POA_VM.chkNPNumPOA = (Boolean)datModificar.NP_NUM_POA;
                    POA_VM.chkPOAPO = (Boolean)datModificar.ESPO;
                    POA_VM.txtItemNumPComplementario = datModificar.NUM_PCOMPLEMENTARIO.ToString();
                    POA_VM.txtItemArea = datModificar.AREA.ToString();
                    POA_VM.txtItemPca = datModificar.PCA;
                    POA_VM.txtItemZafra_Pca = datModificar.ZAFRA_PCA;
                    POA_VM.txtItemInicio_Vigencia = datModificar.INICIO_VIGENCIA.ToString();
                    POA_VM.txtItemFin_Vigencia = datModificar.FIN_VIGENCIA.ToString();
                    POA_VM.txtItemacta_Iocular_Num = datModificar.ACTA_IOCULAR_NUM.ToString();
                    POA_VM.txtItemActa_Iocular_Fe = datModificar.ACTA_IOCULAR_FECHA.ToString();
                    POA_VM.hdfItemConsultorCodigo = datModificar.CONSULTOR_CODIGO;
                    POA_VM.txtItemNRConsultor = datModificar.CONSULTOR_NUM_REGISTRO_FFS;
                    POA_VM.txtItemNRRegente = datModificar.REGENTE_NUM_REGISTRO_FFS;
                    POA_VM.lblItemConsultorNombre = datModificar.CONSULTOR_NOMBRE;
                    POA_VM.lblItemConsultorDNI = datModificar.CONSULTOR_DNI;
                    //Actualización
                    POA_VM.lblItemConsultorLICENCIA = datModificar.NROLICENCIA;
                    POA_VM.lblItemConsultorRESOLUCION = datModificar.RESAPROBACION;
                    POA_VM.lblItemConsultorOTORGAMIENTO = datModificar.OTORGAMIENTO;
                    POA_VM.lblItemConsultorCIP = datModificar.CIP;
                    POA_VM.lblItemConsultorESTADO = datModificar.ESTADO_REGENTE;

                    POA_VM.lblItemConsultorNRProfesional = datModificar.CONSULTOR_NUM_REGISTRO_PROFESIONAL;
                    POA_VM.txtItemItecnico_Iocular_Num = datModificar.ITECNICO_IOCULAR_NUM;
                    POA_VM.txtItemItecnico_Iocular_Fecha = datModificar.ITECNICO_IOCULAR_FECHA.ToString();
                    POA_VM.txtItemItecnico_Raprobacion_Num = datModificar.ITECNICO_RAPROBACION_NUM;
                    POA_VM.txtItemItecnico_Raprobacion_Fecha = datModificar.ITECNICO_RAPROBACION_FECHA.ToString();
                    POA_VM.txtItemAresolucion_Num = datModificar.ARESOLUCION_NUM;
                    POA_VM.txtItemAresolucion_Fecha = datModificar.ARESOLUCION_FECHA.ToString();
                    POA_VM.hdfItemARFuncionarioCodigo = datModificar.ARESOLUCION_COD_FUNCIONARIO;
                    POA_VM.lblItemARFuncionario = datModificar.ARESOLUCION_FUNCIONARIO_NOMBRE;
                    POA_VM.lblItemARFuncionarioODatos = datModificar.ARESOLUCION_FUNCIONARIO_ODATOS;
                    POA_VM.hdfItemBExtPOA_RegEstado = "1";
                    POA_VM.chkItemCuentaFinZafra = (Boolean)datModificar.CUENTA_FIN_ZAFRA;
                    POA_VM.txtItemObservacion = datModificar.OBSERVACION.ToString();
                    POA_VM.ddlODRegistroId = datModificar.COD_OD_REGISTRO;
                    //05/05/2021 lista de PCA
                    POA_VM.ListParcela = datModificar.ListParcela;
                    //InSitu
                    POA_VM.txtItemTmetodo_Epoblacional = datModificar.TMETODO_EPOBLACIONAL;
                    POA_VM.txtItemManejo_Habitat = datModificar.MANEJO_HABITAT;
                    POA_VM.txtItemComercio = datModificar.COMERCIO;
                    POA_VM.txtItemControl_Impacto = datModificar.CONTROL_IMPACTO;
                    POA_VM.txtItemInvestigacion = datModificar.INVESTIGACION;
                    POA_VM.txtItemCapacitacion = datModificar.CAPACITACION;
                    POA_VM.chckSinInspOcu = (Boolean)datModificar.SIN_INS_OCULAR;



                    POA_VM.lblItemRepresentanteLegal = datModificar.RLEGAL_NOMBRES;

                    POA_VM.lbtMaderableItemCensoSelec = String.Format("Ir Censo Maderable ( {0} )", datModificar.ListMadeCENSO.Count.ToString());
                    POA_VM.lbtNoMaderableItemCensoSelec = String.Format("Ir Censo No Maderable ( {0} )", datModificar.ListNoMadeCENSO.Count.ToString());


                    POA_VM.hdfManRegEstado = "0";
                    POA_VM.ItemTitulo = "Modificando Registro";

                    POA_VM.txtControlCalidadObservaciones = datModificar.OBSERVACIONES_CONTROL.ToString();
                    POA_VM.chkItemObsSubsanada = (Boolean)datModificar.OBSERV_SUBSANAR;

                    #region indicador
                    List<VM_Cbo> listIndicador = POA_VM.ddlItemIndicador.ToList();
                    bool enableIndicador = true;
                    string itemSelectIndicador = datModificar.COD_ESTADO_DOC;
                    Log_Helper.controla_estado_calidad(datModificar.COD_ESTADO_DOC, ref listIndicador, ref enableIndicador, ref itemSelectIndicador);
                    POA_VM.ddlItemIndicador = listIndicador;
                    POA_VM.ddlItemIndicadorId = itemSelectIndicador;
                    POA_VM.ddlItemIndicadorEnable = enableIndicador;
                    #endregion

                    POA_VM.txtUsuarioRegistro = datModificar.USUARIO_REGISTRO;
                    POA_VM.txtUsuarioControl = datModificar.USUARIO_CONTROL;
                    //Grillas
                    POA_VM.ListVERTICE = datModificar.ListVERTICE;
                    POA_VM.ListAOCULAR = datModificar.ListAOCULAR;
                    POA_VM.ListTIOCULAR = datModificar.ListTIOCULAR;
                    POA_VM.ListTRAPROBACION = datModificar.ListTRAPROBACION;
                    POA_VM.ListSAPROBACION = datModificar.ListSAPROBACION;
                    POA_VM.ListMadeCENSO = datModificar.ListMadeCENSO;
                    POA_VM.ListNoMadeCENSO = datModificar.ListNoMadeCENSO;
                    //05/05/2023
                    POA_VM.ListDETREGENTE = datModificar.ListDETREGENTE;

                    POA_VM.ListRAprueba = datModificar.ListRAprueba;
                    POA_VM.ListBExtPOA = datModificar.ListBExtPOA;

                    POA_VM.ListRApruebaISitu = datModificar.ListRApruebaISitu;
                    POA_VM.ListKARDEX = datModificar.ListKARDEX;

                    POA_VM.ListPOARegenteImplementa = datModificar.ListPOARegenteImplementa;

                    POA_VM.ListPOAErrorMaterialG = datModificar.ListPOAErrorMaterialG;
                    POA_VM.ListPOAErrorMaterialA = datModificar.ListPOAErrorMaterialA;


                    POA_VM.txtItemNRNroLicencia = datModificar.REGENTE_NRO_LICENCIA;
                    POA_VM.txtItemNREmail = datModificar.REGENTE_EMAIL;
                    POA_VM.txtUbigeo = datModificar.UBIGEO_REGENTE;
                    POA_VM.txtCodUbigeo = datModificar.COD_UBIGEO_REGENTE;
                    POA_VM.txtDirecion = datModificar.DIRECCION_REGENTE;

                    if (datModificar.ListBExtPOA.Count > 0)
                        POA_VM.hdfSelectBExtPOA_Index = "0";
                    else
                        POA_VM.hdfSelectBExtPOA_Index = "";


                    switch (datModificar.ESTADO_ORIGEN)
                    {
                        case "PN":
                            POA_VM.lbltextapru = "Resolución que Aprueba el POA";
                            POA_VM.lbltextEspeciesApru = "Especies Aprobadas de la Resolución de Aprobación del POA";
                            POA_VM.lbltextrecoaprob = "Informe Técnico que Recomienda la Aprobación del POA";

                            break;
                        case "PC":
                            POA_VM.lbltextapru = "Resolución que Aprueba el Plan Complementario Maderable";
                            POA_VM.lbltextEspeciesApru = "Especies Aprobadas de la Resolución de Aprobación del Plan Complementario Maderable";
                            POA_VM.lbltextrecoaprob = "Informe Técnico que Recomienda la Aprobación del Plan Complementario Maderable";

                            break;
                        case "PCN":
                            POA_VM.lbltextapru = "Resolución que Aprueba el Plan Complementario No Maderable";
                            POA_VM.lbltextEspeciesApru = "Especies Aprobadas de la Resolución de Aprobación del Plan Complementario No Maderable";
                            POA_VM.lbltextrecoaprob = "Informe Técnico que Recomienda la Aprobación del Plan Complementario No Maderable";
                            break;
                        case "FI":
                            POA_VM.lbltextapru = "Resolución que Aprueba el Plan Complementario";
                            POA_VM.lbltextEspeciesApru = "Especies Aprobadas de la Resolución de Aprobación del Plan Complementario";
                            POA_VM.lbltextrecoaprob = "Informe Técnico que Recomienda la Aprobación del Plan Complementario";
                            break;
                        case "MS":
                            POA_VM.lbltextapru = "Resolución que Aprueba la Movilización de Saldo";
                            POA_VM.lbltextEspeciesApru = "Especies Aprobadas de la Resolución de Aprobación de la Movilización de Saldo";
                            POA_VM.lbltextrecoaprob = "Informe Técnico que Recomienda la Aprobación de la Movilización de Saldo";

                            break;
                        case "R":
                            POA_VM.lbtn_listadoPOACensoMaderable = String.Format("Listado Censo del POA ({0})", datModificar.ListHijoMadeCENSO.Count.ToString());
                            POA_VM.lbtn_listadoPOACensoNoMaderable = String.Format("Listado Censo del POA ({0})", datModificar.ListHijoNoMadeCENSO.Count.ToString());

                            POA_VM.lbltextapru = "Resolución que Aprueba el Reingreso";
                            POA_VM.lbltextEspeciesApru = "Especies Aprobadas de la Resolución de Aprobación del Reingreso";
                            POA_VM.lbltextrecoaprob = "Informe Técnico que Recomienda la Aprobación del Reingreso";


                            break;
                        case "REFOR":
                            POA_VM.lbltextapru = "Resolución que Reformula el Plan de Manejo";
                            POA_VM.lbltextEspeciesApru = "Especies Aprobadas de la Resolución que Reformula el Plan de Manejo";
                            POA_VM.lbltextrecoaprob = "Informe Técnico que Recomienda la Reformulación del Plan de Manejo";

                            break;
                        case "REAJU":
                            POA_VM.lbltextapru = "Resolución que Aprueba el Reajuste del Plan de Manejo";
                            POA_VM.lbltextEspeciesApru = "Especies Aprobadas de la Resolución que Aprueba el Reajuste del Plan de Manejo";
                            POA_VM.lbltextrecoaprob = "Informe Técnico que Recomienda el Reajuste del Plan de Manejo";
                            break;
                        case "DEMA":
                            POA_VM.lbltextapru = "Resolución que Aprueba la Declaración de Manejo";
                            POA_VM.lbltextEspeciesApru = "Especies Aprobadas de la Resolución que Aprueba la Declaración de Manejo";
                            POA_VM.lbltextrecoaprob = "Informe Técnico que Recomienda la Aprobación de la Declaración de Manejo";

                            break;
                        case "PMFI":
                            POA_VM.lbltextapru = "Resolución que Aprueba el Plan de Manejo Forestal Intermedio (PO 1)";
                            POA_VM.lbltextEspeciesApru = "Especies Aprobadas de la Resolución de Aprobación del PMFI (PO 1)";
                            POA_VM.lbltextrecoaprob = "Informe Técnico que Recomienda la Aprobación del PMFI (PO 1)";

                            break;
                        case "ADECU":
                            POA_VM.lbltextapru = "Resolución que Aprueba la Adecuación Plan de Manejo Forestal";
                            POA_VM.lbltextEspeciesApru = "Especies Aprobadas de la Resolución de Aprobación de la Adecuación";
                            POA_VM.lbltextrecoaprob = "Informe Técnico que Recomienda la Adeucación";

                            break;

                    }
                    POA_VM.ddlDependencia = Log_Helper.ListComboLlenar(datModificar.ListDependencia, "CODIGO", "DESCRIPCION", true);


                    if (datModificar.COD_DEPENDENCIA != 0)
                        POA_VM.ddlDependenciaId = datModificar.COD_DEPENDENCIA.ToString();


                    //Acervo documentario


                    POA_VM.lstChkDETitulo = getObjectToListCheck(POA_VM.lstChkDETitulo.ToList(), datModificar);
                    POA_VM.lstDEResoluciones = getObjectToListCheck(POA_VM.lstDEResoluciones.ToList(), datModificar);
                    POA_VM.lstDEDocumentoGestion = getObjectToListCheck(POA_VM.lstDEDocumentoGestion.ToList(), datModificar);
                    POA_VM.lstDEObligaciones = getObjectToListCheck(POA_VM.lstDEObligaciones.ToList(), datModificar);
                    POA_VM.lstDEEjecucion = getObjectToListCheck(POA_VM.lstDEEjecucion.ToList(), datModificar);
                    POA_VM.lstDEOtros = getObjectToListCheck(POA_VM.lstDEOtros.ToList(), datModificar);

                    POA_VM.txtActaNro = datModificar.AD_ACTA_NRO;
                    POA_VM.txtFechaAcervo = datModificar.AD_FECHA.ToString();

                    POA_VM.hdEspAcervo = datModificar.AD_VERIFICADOR_CODIGO;
                    POA_VM.lbEspecialistaAcervo = datModificar.VERIFICADOR_ACERVO_NOMBRES;
                    POA_VM.chkIncluyeCD = datModificar.AD_CAIncluyeCD == null || datModificar.AD_CAIncluyeCD == false ? false : true;
                    POA_VM.txtNroTomos = datModificar.AD_CANroTomos;

                    POA_VM.txtNroFolios = datModificar.AD_CANroFolios;
                    POA_VM.chkConcluido = datModificar.AD_RSConcluido == null || datModificar.AD_RSConcluido == false ? false : true;
                    POA_VM.chkProceso = datModificar.AD_RSProceso == null || datModificar.AD_RSProceso == false ? false : true;
                    POA_VM.chkPendiente = datModificar.AD_RSPendiente == null || datModificar.AD_RSPendiente == false ? false : true;
                    POA_VM.txtObservacionesAcervo = datModificar.AD_Observaciones;

                    POA_VM.txtNumeroSolAprob = datModificar.SAPROBACION_NUM;
                    POA_VM.txtFechaSolAprob = datModificar.SAPROBACION_FECHA;
                    POA_VM.hdfItemIOFuncionarioCodigo = datModificar.ACTA_IOCULAR_COD_FUNCIONARIO;
                    POA_VM.lblItemIOFuncionario = datModificar.ACTA_IOCULAR_FUNCIONARIO;
                    POA_VM.lblItemIOFuncionarioODatos = datModificar.ACTA_IOCULAR_CARGO;


                }
                if (nuevo == 2) //varias opciones
                {

                    LlenarCombos(ref POA_VM, cod_cuenta);

                    string EstadoOrigen = "";
                    string m_tipo = "";
                    string nom_poa_padre = "";
                    int num_poa_padre = 0;


                    CEntidad datModificar = new CEntidad();

                    CEntidad oCamposMod = new CEntidad();
                    if (appClient != null && appData != null)
                    {
                        string origen = appClient.Split('|')[2];
                        if (origen == "ACTO")
                        {
                            Log_BUSQUEDA oLogBusqueda = new Log_BUSQUEDA();
                            Ent_BUSQUEDA oPoa = new Ent_BUSQUEDA()
                            {
                                BusFormulario = (lstManMenu == "1" ? "POA" : "DEMA"),
                                BusCriterio = "COD_THABILITANTE|POA",
                                BusValor = appData.Split('¬')[3] + "|" + appData.Split('¬')[7]
                            };
                            oPoa = oLogBusqueda.RegMostrarLista(oPoa).FirstOrDefault();
                            switch (appData.Split('¬')[2])
                            {
                                case "0245": EstadoOrigen = "PC"; break;//PCM
                                case "0244": EstadoOrigen = "PCN"; break;//PCNM
                                case "0202": EstadoOrigen = "MS"; break;//MS
                                case "0203": EstadoOrigen = "R"; break;//REING
                                case "0246": EstadoOrigen = "REFOR"; break;//REFOR
                                case "0247": EstadoOrigen = "REAJU"; break;//REAJUS
                            }

                            m_tipo = oPoa.PARAMETRO04;
                            nom_poa_padre = oPoa.PARAMETRO01;
                            num_poa_padre = Convert.ToInt32(appData.Split('¬')[7]);

                            POA_VM.hdfItemCod_THabilitante = appData.Split('¬')[3];
                            codigoThabilitante = appData.Split('¬')[3];
                            POA_VM.hdfItemNum_POAPadre = appData.Split('¬')[7];
                            POA_VM.lblItemTHModalidad = oPoa.PARAMETRO05;
                            POA_VM.lblItemTHNumero = oPoa.PARAMETRO07;
                            POA_VM.lblItemTHTitular = oPoa.PARAMETRO06;

                            if (EstadoOrigen == "PC")
                            {
                                POA_VM.hdfItemIndicador = "M";
                                POA_VM.hdfItemCod_MTipo = "0000007";
                            }
                            if (EstadoOrigen == "PCN")
                            {
                                POA_VM.hdfItemIndicador = "NM";
                                POA_VM.hdfItemCod_MTipo = "0000008";
                            }
                            else
                            {
                                POA_VM.hdfItemIndicador = oPoa.PARAMETRO10;
                                POA_VM.hdfItemCod_MTipo = oPoa.PARAMETRO04;
                            }
                            POA_VM.txtItemAresolucion_Num = appData.Split('¬')[5];
                            POA_VM.appClient = appClient;
                            POA_VM.appData = appData;
                        }
                    }
                    if (descripcionTHabilitante != "")
                    {
                        EstadoOrigen = descripcionTHabilitante.Split('|')[1].ToString();
                        m_tipo = descripcionTHabilitante.Split('|')[2].ToString();
                        nom_poa_padre = descripcionTHabilitante.Split('|')[7].ToString();
                        num_poa_padre = Int32.Parse(descripcionTHabilitante.Split('|')[0].ToString());

                        POA_VM.hdfItemCod_THabilitante = codigoThabilitante.Trim();
                        POA_VM.hdfItemNum_POAPadre = descripcionTHabilitante.Split('|')[0].ToString();
                        POA_VM.lblItemTHModalidad = descripcionTHabilitante.Split('|')[3].ToString();
                        POA_VM.lblItemTHNumero = descripcionTHabilitante.Split('|')[4].ToString();
                        POA_VM.lblItemTHTitular = descripcionTHabilitante.Split('|')[5].ToString();


                        if (EstadoOrigen == "PC")
                        {
                            POA_VM.hdfItemIndicador = "M";
                            POA_VM.hdfItemCod_MTipo = "0000007";
                        }
                        if (EstadoOrigen == "PCN")
                        {
                            POA_VM.hdfItemIndicador = "NM";
                            POA_VM.hdfItemCod_MTipo = "0000008";
                        }
                        else
                        {
                            POA_VM.hdfItemIndicador = descripcionTHabilitante.Split('|')[6].ToString();
                            POA_VM.hdfItemCod_MTipo = descripcionTHabilitante.Split('|')[2].ToString();
                        }

                    }
                    CEntidadDependencia oCamposCombo = new CEntidadDependencia();
                    oCamposCombo.BusFormulario = "DEPENDENCIA_UBIGEO";
                    oCamposCombo.BusCriterio = "THABILITANTE";
                    oCamposCombo.BusValor = POA_VM.hdfItemCod_THabilitante;
                    oCamposCombo = new CLogicaDependencia().RegMostCombo(oCamposCombo);
                    //Dependencia Ubigeo              
                    POA_VM.ddlDependencia = Log_Helper.ListComboLlenar(oCamposCombo.ListDependencia, "CODIGO", "DESCRIPCION", true);


                    POA_VM.hdfItemEstadoOrigen = EstadoOrigen;
                    CEntidad oCampos = new CEntidad();
                    oCampos.ListTIOCULAR = new List<CEntidad>();
                    //05/05/2023
                    oCampos.ListDETREGENTE = new List<CEntidad>();
                    oCampos.ListAOCULAR = new List<CEntidad>();
                    oCampos.ListTRAPROBACION = new List<CEntidad>();
                    oCampos.ListSAPROBACION = new List<CEntidad>();
                    oCampos.ListRAprueba = new List<CEntidad>();
                    oCampos.ListRApruebaISitu = new List<CEntidad>();
                    oCampos.ListRReformulaISitu = new List<CEntidad>();
                    oCampos.ListASBSAmbientales = new List<CEntidad>();
                    oCampos.ListBioseguridad = new List<CEntidad>();
                    oCampos.ListMadeCENSO = new List<CEntidad>();
                    oCampos.ListNoMadeCENSO = new List<CEntidad>();
                    oCampos.ListVERTICE = new List<CEntidad>();
                    oCampos.ListEliTABLA = new List<CEntidad>();
                    oCampos.ListMComboEspecies = new List<CEntidad>();
                    oCampos.ListHijoMadeCENSO = new List<CEntidad>();
                    oCampos.ListHijoNoMadeCENSO = new List<CEntidad>();
                    switch (EstadoOrigen)
                    {
                        case "PC":
                            POA_VM.lbltextapru = "Resolución que Aprueba el Plan Complementario Maderable";
                            POA_VM.lbltextEspeciesApru = "Especies Aprobadas de la Resolución de Aprobación del Plan Complementario Maderable";
                            POA_VM.lbltextrecoaprob = "Informe Técnico que Recomienda la Aprobación del Plan Complementario Maderable";
                            POA_VM.txtNombrePOA = "Plan Complementario Maderable N° (" + nom_poa_padre + ")";
                            break;
                        case "PCN":
                            POA_VM.lbltextapru = "Resolución que Aprueba el Plan Complementario No Maderable";
                            POA_VM.lbltextEspeciesApru = "Especies Aprobadas de la Resolución de Aprobación del Plan Complementario No Maderable";
                            POA_VM.lbltextrecoaprob = "Informe Técnico que Recomienda la Aprobación del Plan Complementario No Maderable";
                            POA_VM.txtNombrePOA = "Plan Complementario No Maderable N° (" + nom_poa_padre + ")";
                            break;
                        case "FI":
                            POA_VM.lbltextapru = "Resolución que Aprueba el Plan Complementario";
                            POA_VM.lbltextEspeciesApru = "Especies Aprobadas de la Resolución de Aprobación del Plan Complementario";
                            POA_VM.lbltextrecoaprob = "Informe Técnico que Recomienda la Aprobación del Plan Complementario";

                            POA_VM.txtNombrePOA = "Fauna Insitu " + nom_poa_padre;
                            break;
                        case "MS":
                            POA_VM.lbltextapru = "Resolución que Aprueba la Movilización de Saldo";
                            POA_VM.lbltextEspeciesApru = "Especies Aprobadas de la Resolución de Aprobación de la Movilización de Saldo";
                            POA_VM.lbltextrecoaprob = "Informe Técnico que Recomienda la Aprobación de la Movilización de Saldo";
                            POA_VM.txtNombrePOA = "Movilización de Saldo " + nom_poa_padre;
                            break;
                        case "R":
                            POA_VM.lbltextapru = "Resolución que Aprueba el Reingreso";
                            POA_VM.lbltextEspeciesApru = "Especies Aprobadas de la Resolución de Aprobación del Reingreso";
                            POA_VM.lbltextrecoaprob = "Informe Técnico que Recomienda la Aprobación del Reingreso";
                            POA_VM.txtNombrePOA = "Reingreso " + nom_poa_padre;

                            CEntidad oCampos2 = new CEntidad();
                            oCampos2.COD_THABILITANTE = codigoThabilitante;
                            oCampos2.NUM_POA = num_poa_padre;
                            oCampos2 = RegMostItemsHijoMadNoMad(oCampos2);
                            oCampos.ListHijoMadeCENSO = oCampos2.ListHijoMadeCENSO;
                            oCampos.ListHijoNoMadeCENSO = oCampos2.ListHijoNoMadeCENSO;

                            POA_VM.lbtn_listadoPOACensoMaderable = String.Format("Listado Censo del Plan Maderable ({0})", oCampos2.ListHijoMadeCENSO.Count.ToString());
                            POA_VM.lbtn_listadoPOACensoNoMaderable = String.Format("Listado Censo del Plan No Maderable ({0})", oCampos2.ListHijoNoMadeCENSO.Count.ToString());
                            break;
                        case "REFOR":
                            POA_VM.lbltextapru = "Resolución que Reformula el Plan de Manejo";
                            POA_VM.lbltextEspeciesApru = "Especies Aprobadas de la Resolución que Reformula el Plan de Manejo";
                            POA_VM.lbltextrecoaprob = "Informe Técnico que Recomienda la Reformulación del Plan de Manejo";
                            POA_VM.txtNombrePOA = "Reformulación del " + nom_poa_padre;
                            break;
                        case "REAJU":
                            POA_VM.lbltextapru = "Resolución que Aprueba el Reajuste del Plan de Manejo";
                            POA_VM.lbltextEspeciesApru = "Especies Aprobadas de la Resolución que Aprueba el Reajuste el Plan de Manejo";
                            POA_VM.lbltextrecoaprob = "Informe Técnico que Recomienda el Reajuste del Plan de Manejo";
                            POA_VM.txtNombrePOA = nom_poa_padre + "Reajustado";
                            break;
                        case "PMFI":
                            POA_VM.lbltextapru = "Resolución que Aprueba el PMFI (PO 1)";
                            POA_VM.lbltextEspeciesApru = "Especies Aprobadas de la Resolución que Aprueba el PMFI (PO 1)";
                            POA_VM.lbltextrecoaprob = "Informe Técnico que Recomienda la Aprobación del PMFI (PO 1)";
                            POA_VM.txtNombrePOA = "Reformulación del " + nom_poa_padre;
                            break;
                        case "ADECU":
                            POA_VM.lbltextapru = "Resolución que Aprueba la Adecuación";
                            POA_VM.lbltextEspeciesApru = "Especies Aprobadas de la Resolución que Aprueba la Adecuación";
                            POA_VM.lbltextrecoaprob = "Informe Técnico que Recomienda la Adecuación";
                            POA_VM.txtNombrePOA = "Adecuación del Plan de Manejo Forestal";
                            break;
                    }



                    POA_VM.hdfManRegEstado = "1";
                    POA_VM.ItemTitulo = "Nuevo Registro";


                    //Grillas

                    //  POA_VM.ListAOCULAR = datModificar.ListAOCULAR;
                    POA_VM.ListTIOCULAR = oCampos.ListTIOCULAR;
                    POA_VM.ListTRAPROBACION = oCampos.ListTRAPROBACION;
                    POA_VM.ListSAPROBACION = oCampos.ListSAPROBACION;
                    POA_VM.ListRAprueba = oCampos.ListRAprueba;

                    POA_VM.ListBExtPOA = new List<CEntidad>();
                    POA_VM.ListRApruebaISitu = oCampos.ListRApruebaISitu;
                    POA_VM.ListVERTICE = datModificar.ListVERTICE;

                    POA_VM.ListPOARegenteImplementa = new List<Ent_ERRORMATERIAL>();

                    POA_VM.ListPOAErrorMaterialG = new List<Ent_ERRORMATERIAL>();
                    POA_VM.ListPOAErrorMaterialA = new List<Ent_ERRORMATERIAL>();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return POA_VM;
        }
        private List<VM_Chk> getObjectToListCheck(List<VM_Chk> listCheck, CEntidad obj)
        {

            for (int i = 0; i < listCheck.Count; i++)
            {
                object o = obj.GetType().GetProperty(listCheck[i].Value).GetValue(obj, null);
                listCheck[i].Checked = (bool)o;
            }
            return listCheck;
        }
        public void LlenarCombos(ref VM_POA POA_VM, string cod_cuenta)
        {
            POA_VM.ddlItemIndicadorEnable = true;
            CEntidad oCampos = new CEntidad();
            oCampos.COD_UCUENTA = cod_cuenta;
            oCampos.BusFormulario = "POA";
            oCampos.BusCriterio = "POA_GENERAL";
            //rol
            oCampos.BusValor = POA_VM.rol;
            oCampos = RegMostCombo(oCampos);


            POA_VM.ddlItemIndicador = oCampos.ListIndicador.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION });
            ////No Maderable
            POA_VM.ddlODRegistro = oCampos.ListODs.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION });
            ////Cargando los combos de especies
            var listMComboEspecies = oCampos.ListMComboEspecies.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION }).ToList();
            listMComboEspecies.Insert(0, new VM_Cbo { Value = "-", Text = "Seleccionar" });
            POA_VM.ddlItemRAPoaEspecies = listMComboEspecies;
            POA_VM.ddlItemRAPoaEspeciesId = "-";

            var listMComboEspeciesSerfor = oCampos.ListMComboEspeciesSerfor.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION }).ToList();
            listMComboEspeciesSerfor.Insert(0, new VM_Cbo { Value = "-", Text = "Seleccionar" });
            POA_VM.ddlItemRAPoaEspecies_Serfor = listMComboEspeciesSerfor;
            POA_VM.ddlItemRAPoaEspecies_SerforId = "-";



            POA_VM.lstChkDETitulo = new List<VM_Chk>() {
                        new VM_Chk() { Value = "AD_THContrato", Text = "Contrato de concesión" },
                        new VM_Chk() { Value = "AD_THAdenda", Text = "Adenda" },
                        new VM_Chk() { Value = "AD_THPermiso", Text = "Permiso" },
                        new VM_Chk() { Value = "AD_THAutorizacion", Text = "Autorización" },
                        new VM_Chk() { Value = "AD_THResolucion", Text = "Resol. SERFOR (bosque local)" }
                    };

            POA_VM.lstDEResoluciones = new List<VM_Chk>() {
                        new VM_Chk() { Value = "AD_REAprobacion", Text = "De aprobación del plan de manejo" },
                        new VM_Chk() { Value = "AD_RECargo", Text = "Cargo de notificación de resol." },
                        new VM_Chk() { Value = "AD_REReingreso", Text = "De reingreso" },
                        new VM_Chk() { Value = "AD_REMovilizacion", Text = "De movilización de saldos" },
                        new VM_Chk() { Value = "AD_REReajuste", Text = "Reajuste/ reformulación de plan" }
                    };
            POA_VM.lstDEDocumentoGestion = new List<VM_Chk>() {
                        new VM_Chk() { Value = "AD_DGPGMF", Text = "PGMF" },
                        new VM_Chk() { Value = "AD_DGPMFI", Text = "PMFI" },
                        new VM_Chk() { Value = "AD_DGPO", Text = "PO" },
                        new VM_Chk() { Value = "AD_DGDEMA", Text = "DEMA" },
                        new VM_Chk() { Value = "AD_DGPMCA", Text = "PMCA" }
                    };
            POA_VM.lstDEObligaciones = new List<VM_Chk>() {
                        new VM_Chk() { Value = "AD_ODBalance", Text = "Balance de pagos por DA" },
                        new VM_Chk() { Value = "AD_ODRefinanciamiento", Text = "Refinanciamiento (resol.)" },
                        new VM_Chk() { Value = "AD_ODSuspension", Text = "Suspensión de obligaciones (resol.)" },
                        new VM_Chk() { Value = "AD_ODGarantias", Text = "Garantías de fiel cumplimiento (vigente)" },
                        new VM_Chk() { Value = "AD_ODInfEjecucionAnual", Text = "Informe de ejecución anual" },
                        new VM_Chk() { Value = "AD_ODInfEjecucionFinal", Text = "Informe de ejecución final" }
                    };
            POA_VM.lstDEEjecucion = new List<VM_Chk>() {
                        new VM_Chk() { Value = "AD_EIGTF", Text = "GTF al estado natural" },
                        new VM_Chk() { Value = "AD_EILibro", Text = "Libro de operación de bosque" },
                        new VM_Chk() { Value = "AD_EIKardex", Text = "Kardex" },
                        new VM_Chk() { Value = "AD_EIForma20", Text = "Forma 20" },
                        new VM_Chk() { Value = "AD_EIBalance", Text = "Balance de extracción" },
                        new VM_Chk() { Value = "AD_EILista", Text = "Lista de trozas" }
                    };

            POA_VM.lstDEOtros = new List<VM_Chk>() {
                        new VM_Chk() { Value = "AD_OTActa", Text = "Acta de inspección ocular" },
                        new VM_Chk() { Value = "AD_OTInfInspeccion", Text = "Informe de inspección ocular" },
                        new VM_Chk() { Value = "AD_OTInfRecomienda", Text = "Informe que recomienda aprobación del plan" },
                        new VM_Chk() { Value = "AD_OTContratoRegente", Text = "Contrato con regente" },
                        new VM_Chk() { Value = "AD_OTContratoTercero", Text = "Contrato con tercero" },
                        new VM_Chk() { Value = "AD_OTDenuncias", Text = "Denuncias" }
                    };
            //HerUtil.ComboLlenar(ddlItemBioseguridadActividad, oCampos.ListMComboBSeguridad, "CODIGO", "DESCRIPCION", false);
            //HerUtil.ComboLlenar(ddlItemBNuevo_DIdentidad, oCampos.ListMComboDIdentidad, "CODIGO", "DESCRIPCION", false);

            ////Maderable
            var ListCombo = (from p in oCampos.ListMComboEspeciesCondicion
                             where (Boolean)p.MADERABLE == true
                             select new VM_Cbo { Value = p.CODIGO, Text = p.DESCRIPCION }
                             ).ToList();
            ListCombo.Insert(0, new VM_Cbo { Value = "-", Text = "Seleccionar" });
            POA_VM.ddlItemCMaderableCod_Econdicion = ListCombo;


            ListCombo = (from p in oCampos.ListMComboEspeciesEstado
                         where (Boolean)p.MADERABLE == true
                         select new VM_Cbo { Value = p.CODIGO, Text = p.DESCRIPCION }
                         ).ToList();
            ListCombo.Insert(0, new VM_Cbo { Value = "-", Text = "Seleccionar" });

            POA_VM.ddlItemCMaderableCod_Eestado = ListCombo;

            ListCombo = (from p in oCampos.ListMComboEspeciesEstado
                         where (Boolean)p.NO_MADERABLE == true
                         select new VM_Cbo { Value = p.CODIGO, Text = p.DESCRIPCION }
                        ).ToList();
            ListCombo.Insert(0, new VM_Cbo { Value = "-", Text = "Seleccionar" });

            POA_VM.ddlItemCNoMaderableCod_Econdicion = ListCombo;



            var ListKARDEXPRODUCTO = oCampos.ListKARDEXPRODUCTO.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION }).ToList();
            POA_VM.ddlItemkeardexProducto = ListKARDEXPRODUCTO;

            var ListKARDEXDESCRIPCION = oCampos.ListKARDEXDESCRIPCION.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION }).ToList();
            POA_VM.ddlItemkeardexDescripcion = ListKARDEXDESCRIPCION;



        }


        public ListResult GuardarDatosPOA(VM_POA dto, string codCuenta)
        {
            ListResult resultado = new ListResult();
            Log_BEXTRACCION logBEXTRACCION = new Log_BEXTRACCION(); 
            CEntidad oCampos = new CEntidad();
            String OUTPUTPARAM = "";
            string msjRespuesta = "El Registro se Guardo Correctamente", appServer = "";

            try
            {

                oCampos.COD_THABILITANTE = dto.hdfItemCod_THabilitante;

                if (string.IsNullOrEmpty(dto.txtItemNumPOA))
                    dto.txtItemNumPOA = dto.hdfNumPoa ?? "0";
                oCampos.NUM_POA = Int32.Parse(!string.IsNullOrEmpty(dto.txtItemNumPOA) ? dto.txtItemNumPOA.Trim() : "0");


                oCampos.NOMBRE_POA = dto.txtNombrePOA ?? string.Empty;
                oCampos.NOMBRE_POA = oCampos.NOMBRE_POA.Trim();
                oCampos.NP_NUM_POA = dto.chkNPNumPOA;
                oCampos.ESPO = dto.chkPOAPO;
                oCampos.COD_MTIPO = dto.hdfItemCod_MTipo;
                if (dto.txtItemNumPComplementario == null) dto.txtItemNumPComplementario = "0";
                oCampos.NUM_PCOMPLEMENTARIO = Int32.Parse(dto.hdfItemEstadoOrigen == "PC" || dto.hdfItemEstadoOrigen == "PCN" ? dto.txtItemNumPComplementario.Trim() : "0");
                oCampos.AREA = Decimal.Parse(string.IsNullOrEmpty(dto.txtItemArea) ? "0" : dto.txtItemArea.Trim());
                oCampos.PCA = string.IsNullOrEmpty(dto.txtItemPca) ? "" : dto.txtItemPca.Trim();
                oCampos.ZAFRA_PCA = string.IsNullOrEmpty(dto.txtItemZafra_Pca) ? "" : dto.txtItemZafra_Pca.Trim();
                oCampos.INICIO_VIGENCIA = string.IsNullOrEmpty(dto.txtItemInicio_Vigencia) ? "" : dto.txtItemInicio_Vigencia.Trim();
                oCampos.FIN_VIGENCIA = string.IsNullOrEmpty(dto.txtItemFin_Vigencia) ? "" : dto.txtItemFin_Vigencia.Trim();
                oCampos.CONSULTOR_CODIGO = string.IsNullOrEmpty(dto.hdfItemConsultorCodigo) ? "" : dto.hdfItemConsultorCodigo.Trim();
                oCampos.CONSULTOR_NUM_REGISTRO_FFS = string.IsNullOrEmpty(dto.txtItemNRConsultor) ? "" : dto.txtItemNRConsultor.Trim();
                oCampos.REGENTE_NUM_REGISTRO_FFS = string.IsNullOrEmpty(dto.txtItemNRRegente) ? "" : dto.txtItemNRRegente.Trim();
                oCampos.CONSULTOR_NUM_REGISTRO_PROFESIONAL = string.IsNullOrEmpty(dto.lblItemConsultorNRProfesional) ? "" : dto.lblItemConsultorNRProfesional.Trim();
                oCampos.ITECNICO_IOCULAR_NUM = string.IsNullOrEmpty(dto.txtItemItecnico_Iocular_Num) ? "" : dto.txtItemItecnico_Iocular_Num.Trim();
                oCampos.ITECNICO_IOCULAR_FECHA = string.IsNullOrEmpty(dto.txtItemItecnico_Iocular_Fecha) ? "" : dto.txtItemItecnico_Iocular_Fecha.Trim();
                oCampos.ITECNICO_RAPROBACION_NUM = string.IsNullOrEmpty(dto.txtItemItecnico_Raprobacion_Num) ? "" : dto.txtItemItecnico_Raprobacion_Num.Trim();
                oCampos.ITECNICO_RAPROBACION_FECHA = string.IsNullOrEmpty(dto.txtItemItecnico_Raprobacion_Fecha) ? "" : dto.txtItemItecnico_Raprobacion_Fecha.Trim();
                //DIRECCION UBIGEO REGENTE
                oCampos.COD_UBIGEO_REGENTE = string.IsNullOrEmpty(dto.txtCodUbigeo) ? "" : dto.txtCodUbigeo.Trim();
                oCampos.DIRECCION_REGENTE = string.IsNullOrEmpty(dto.txtDirecion) ? "" : dto.txtDirecion.Trim();

                oCampos.SIN_INS_OCULAR = dto.chckSinInspOcu;
                oCampos.ACTA_IOCULAR_NUM = string.IsNullOrEmpty(dto.txtItemacta_Iocular_Num) ? "" : dto.txtItemacta_Iocular_Num.Trim();
                oCampos.ACTA_IOCULAR_FECHA = string.IsNullOrEmpty(dto.txtItemActa_Iocular_Fe) ? "" : dto.txtItemActa_Iocular_Fe.Trim();
                oCampos.ARESOLUCION_NUM = string.IsNullOrEmpty(dto.txtItemAresolucion_Num) ? "" : dto.txtItemAresolucion_Num.Trim();
                oCampos.ARESOLUCION_FECHA = string.IsNullOrEmpty(dto.txtItemAresolucion_Fecha) ? "" : dto.txtItemAresolucion_Fecha.Trim();
                oCampos.ARESOLUCION_COD_FUNCIONARIO = string.IsNullOrEmpty(dto.hdfItemARFuncionarioCodigo) ? "" : dto.hdfItemARFuncionarioCodigo.Trim();
                oCampos.COD_UCUENTA = string.IsNullOrEmpty(codCuenta) ? "" : codCuenta;
                oCampos.ESTADO_ORIGEN = string.IsNullOrEmpty(dto.hdfItemEstadoOrigen) ? "" : dto.hdfItemEstadoOrigen.Trim();
                oCampos.BEXTRACCION_FEMISION = string.IsNullOrEmpty(dto.txtItemFEmisionBExtracion) ? "" : dto.txtItemFEmisionBExtracion.Trim();
                oCampos.CUENTA_FIN_ZAFRA = dto.chkItemCuentaFinZafra;
                oCampos.OBSERVACION = string.IsNullOrEmpty(dto.txtItemObservacion) ? "" : dto.txtItemObservacion.Trim();

                oCampos.OBSERVACIONES_CONTROL = string.IsNullOrEmpty(dto.txtControlCalidadObservaciones) ? "" : dto.txtControlCalidadObservaciones;
                //hdfItemReformulaPOA_RegEstado.Value = "1";
                oCampos.COD_OD_REGISTRO = dto.ddlODRegistroId;
                oCampos.OUTPUTPARAM01 = "";
                oCampos.OUTPUTPARAM02 = "";

                //
                //InSitu
                oCampos.TMETODO_EPOBLACIONAL = string.IsNullOrEmpty(dto.txtItemTmetodo_Epoblacional) ? "" : dto.txtItemTmetodo_Epoblacional.Trim();
                oCampos.MANEJO_HABITAT = string.IsNullOrEmpty(dto.txtItemManejo_Habitat) ? "" : dto.txtItemManejo_Habitat.Trim(); ;
                oCampos.COMERCIO = string.IsNullOrEmpty(dto.txtItemComercio) ? "" : dto.txtItemComercio.Trim();
                oCampos.CONTROL_IMPACTO = string.IsNullOrEmpty(dto.txtItemControl_Impacto) ? "" : dto.txtItemControl_Impacto.Trim();
                oCampos.INVESTIGACION = string.IsNullOrEmpty(dto.txtItemInvestigacion) ? "" : dto.txtItemInvestigacion.Trim();
                oCampos.CAPACITACION = string.IsNullOrEmpty(dto.txtItemCapacitacion) ? "" : dto.txtItemCapacitacion.Trim();

                //
                //Tabla de Enlance HIjoListTIOCULAR
                oCampos.HIJO_COD_THABILITANTE = "";
                oCampos.HIJO_NUM_POA = 0;
                oCampos.HIJO_NIVEL = 0;

                //Variables de control de calidad
                oCampos.COD_ESTADO_DOC = dto.ddlItemIndicadorId;
                oCampos.OBSERVACIONES_CONTROL = string.IsNullOrEmpty(dto.txtControlCalidadObservaciones) ? "" : dto.txtControlCalidadObservaciones.Trim();
                oCampos.OBSERV_SUBSANAR = dto.chkItemObsSubsanada;

                oCampos.COD_DEPENDENCIA = dto.ddlDependenciaId == "-" ? (int?)null : int.Parse(dto.ddlDependenciaId);


                //Lista de Objetos
                oCampos.ListTIOCULAR = dto.ListTIOCULAR;
                oCampos.ListTRAPROBACION = dto.ListTRAPROBACION;
                oCampos.ListSAPROBACION = dto.ListSAPROBACION;
                oCampos.ListRAprueba = dto.ListRAprueba;
                if(oCampos.ListRAprueba != null && oCampos.ListRAprueba.Count > 0)
                {
                    foreach (var item in oCampos.ListRAprueba)
                    {
                        List<Ent_BEXTRACCION_FECEMI> listaFechas = logBEXTRACCION.ListarBExtraccionPorPlan(oCampos.COD_THABILITANTE, oCampos.NUM_POA);
                        if (listaFechas != null && listaFechas.Count > 0)
                        {
                            foreach (var fecha in listaFechas)
                            {
                                List<Ent_POA> listaGuardar = new List<Ent_POA>();
                                listaGuardar.Add(item);
                                logBEXTRACCION.InsertarBalanceExtraccionMaderableNoMaderable(listaGuardar, oCampos.COD_UCUENTA, fecha.COD_SECUENCIAL, oCampos.COD_THABILITANTE, oCampos.NUM_POA);
                            }
                        }
                    }
                }
                oCampos.ListRApruebaISitu = dto.ListRApruebaISitu;
                oCampos.ListAOCULAR = dto.ListAOCULAR;
                oCampos.ListVERTICE = dto.ListVERTICE;
                oCampos.ListMadeCENSO = dto.ListMadeCENSO;
                oCampos.ListNoMadeCENSO = dto.ListNoMadeCENSO;
                oCampos.ListKARDEX = dto.ListKARDEX;
                //05/05/2023
                oCampos.ListDETREGENTE = dto.ListDETREGENTE;

                if (dto.ListEliTABLA == null)
                    oCampos.ListEliTABLA = new List<CEntidad>();
                else
                    oCampos.ListEliTABLA = dto.ListEliTABLA;
                oCampos.ListBExtPOA = dto.ListBExtPOA;
                oCampos.ListPOARegenteImplementa = dto.ListPOARegenteImplementa;
                oCampos.ListPOAErrorMaterialG = dto.ListPOAErrorMaterialG;
                oCampos.ListPOAErrorMaterialA = dto.ListPOAErrorMaterialA;
                oCampos.NUM_CENSO_MADE_ELIM = (from p in oCampos.ListEliTABLA where p.EliTABLA == "POA_DET_MADERABLE_CENSO" select p).ToList<CEntidad>().Count;
                oCampos.ELIM_TOTAL_CENSO = dto.hdELIM_TOTAL_CENSO;

                /*  oCampos.ListRReformulaISitu = CEntPOAItems.ListRReformulaISitu;                
                oCampos.ListASBSAmbientales = CEntPOAItems.ListASBSAmbientales;
                oCampos.ListBioseguridad = CEntPOAItems.ListBioseguridad;
                oCampos.ListRDReformulaPOA = CEntPOAItems.ListRDReformulaPOA;
                oCampos.ListHijoMadeCENSO = CEntPOAItems.ListHijoMadeCENSO;
                oCampos.ListHijoNoMadeCENSO = CEntPOAItems.ListHijoNoMadeCENSO;
                 */
                /*
                #region indicador
                List<VM_Cbo> listIndicador = POA_VM.ddlItemIndicador.ToList();
                bool enableIndicador = true;
                string itemSelectIndicador = datModificar.COD_ESTADO_DOC;
                Log_Helper.controla_estado_calidad(datModificar.COD_ESTADO_DOC, ref listIndicador, ref enableIndicador, ref itemSelectIndicador);
                POA_VM.ddlItemIndicador = listIndicador;
                POA_VM.ddlItemIndicadorId = itemSelectIndicador;
                POA_VM.ddlItemIndicadorEnable = enableIndicador;
                #endregion

                POA_VM.txtUsuarioRegistro = datModificar.USUARIO_REGISTRO;
                POA_VM.txtUsuarioControl = datModificar.USUARIO_CONTROL;
                */
                //obtenemos el estado del registro
                oCampos.RegEstado = Int32.Parse(dto.hdfManRegEstado);
                oCampos.ListParcela = dto.ListParcela;
                oCampos.ListEliTABLAParcela = dto.ListEliTABLAParcela;
                //
                //Extrayendo Codigo Hijos de Enlace en caso que sea parte de una POA
                if (dto.hdfManRegEstado == "1" && dto.hdfItemEstadoOrigen != "PN" && dto.hdfItemEstadoOrigen != "DEMA")
                {
                    oCampos.HIJO_COD_THABILITANTE = dto.hdfItemCod_THabilitante;
                    oCampos.HIJO_NUM_POA = Int32.Parse(dto.hdfItemNum_POAPadre ?? "0");
                }

                oCampos.AD_ACTA_NRO = String.IsNullOrEmpty(dto.txtActaNro) ? "" : dto.txtActaNro.Trim();
                oCampos.AD_FECHA = String.IsNullOrEmpty(dto.txtFechaAcervo) ? "" : dto.txtFechaAcervo.Trim();
                oCampos.AD_VERIFICADOR_CODIGO = String.IsNullOrEmpty(dto.hdEspAcervo) ? "" : dto.hdEspAcervo.Trim();
                oCampos.REGENTE_NRO_LICENCIA = String.IsNullOrEmpty(dto.txtItemNRNroLicencia) ? "" : dto.txtItemNRNroLicencia.Trim();
                oCampos.REGENTE_EMAIL = String.IsNullOrEmpty(dto.txtItemNREmail) ? "" : dto.txtItemNREmail.Trim();


                oCampos.AD_ACTA_NRO = String.IsNullOrEmpty(dto.txtActaNro) ? "" : dto.txtActaNro.Trim();
                oCampos.AD_FECHA = String.IsNullOrEmpty(dto.txtFechaAcervo) ? "" : dto.txtFechaAcervo.Trim();
                oCampos.AD_VERIFICADOR_CODIGO = String.IsNullOrEmpty(dto.hdEspAcervo) ? "" : dto.hdEspAcervo.Trim();

                oCampos.AD_CAIncluyeCD = dto.chkIncluyeCD;
                oCampos.AD_CANroTomos = String.IsNullOrEmpty(dto.txtNroTomos) ? null : dto.txtNroTomos.Trim();
                oCampos.AD_CANroFolios = String.IsNullOrEmpty(dto.txtNroFolios) ? null : dto.txtNroFolios.Trim();

                oCampos.AD_RSConcluido = dto.chkConcluido;
                oCampos.AD_RSProceso = dto.chkProceso;
                oCampos.AD_RSPendiente = dto.chkPendiente;

                oCampos.SAPROBACION_NUM = dto.txtNumeroSolAprob;
                oCampos.SAPROBACION_FECHA = dto.txtFechaSolAprob;
                oCampos.ACTA_IOCULAR_COD_FUNCIONARIO = dto.hdfItemIOFuncionarioCodigo;


                oCampos.AD_Observaciones = String.IsNullOrEmpty(dto.txtObservacionesAcervo) ? "" : dto.txtObservacionesAcervo.Trim();


                setListCheckToObject(dto.lstChkDETituloId, ref oCampos);
                setListCheckToObject(dto.lstDEResolucionesId, ref oCampos);
                setListCheckToObject(dto.lstDEDocumentoGestionId, ref oCampos);
                setListCheckToObject(dto.lstDEObligacionesId, ref oCampos);
                setListCheckToObject(dto.lstDEEjecucionId, ref oCampos);
                setListCheckToObject(dto.lstDEOtrosId, ref oCampos);

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
                            Ent_ANTECEDENTE_EXPEDIENTE oParamsAExpedienteSitd = new Ent_ANTECEDENTE_EXPEDIENTE();
                            oParamsAExpedienteSitd.TIPO = "TRANSFERIR"; oParamsAExpedienteSitd.SUBTIPO = "POA";
                            oParamsAExpedienteSitd.COD_AEXPEDIENTE_SITD = Convert.ToInt32(dto.appData.Split('¬')[0]);
                            oParamsAExpedienteSitd.COD_TRAMITE_SITD = Convert.ToInt32(dto.appData.Split('¬')[1]);
                            oParamsAExpedienteSitd.OBSERVACION = dto.appData.Split('¬')[6];
                            oParamsAExpedienteSitd.COD_THABILITANTE = dto.hdfItemCod_THabilitante;
                            oParamsAExpedienteSitd.ORIGEN_REGISTRO = 1;
                            if (dto.appClient.Split('|')[2] == "PLAN")
                            {
                                if (dto.appData.Split('¬')[2] == "0204" || dto.appData.Split('¬')[2] == "0402" || dto.appData.Split('¬')[2] == "0301")//POA/PO|DEMA|BExt
                                    oParamsAExpedienteSitd.RESOLUCION_POA = dto.txtItemAresolucion_Num;
                                else oParamsAExpedienteSitd.RESOLUCION_POA = dto.appData.Split('¬')[5];

                                oParamsAExpedienteSitd.ESTADO_AEXPEDIENTE = dto.appData.Split('¬')[2] == "0204" || dto.appData.Split('¬')[2] == "0402" ? "Transferido" : "Pendiente";//0204: POA/PO,0402: DEMA

                                //oParamsAExpedienteSitd.NUM_POA = Int32.Parse(dto.txtItemNumPOA.Trim() != "" ? dto.txtItemNumPOA.Trim() : "0");
                                oParamsAExpedienteSitd.NUM_POA = Int32.Parse(OUTPUTPARAM.Trim() != "" ? OUTPUTPARAM.Trim() : "0");

                            }
                            else
                            {
                                oParamsAExpedienteSitd.RESOLUCION_POA = dto.txtItemAresolucion_Num;
                                oParamsAExpedienteSitd.ESTADO_AEXPEDIENTE = "Transferido";

                                // se cambia por que se cambio el procedimiento para obtener el numero de poa
                                //oParamsAExpedienteSitd.NUM_POA = Convert.ToInt32(OUTPUTPARAM.Split('|')[2]);
                                oParamsAExpedienteSitd.NUM_POA = Convert.ToInt32(OUTPUTPARAM);
                            }

                            oParamsAExpedienteSitd.COD_UCUENTA = codCuenta;
                            oParamsAExpedienteSitd.OUTPUTPARAM01 = "";
                            if (oParamsAExpedienteSitd.RESOLUCION_POA != dto.appData.Split('¬')[5]) oParamsAExpedienteSitd.RegEstado = 2;//Datos del SITD modificado

                            Log_ANTECEDENTE_EXPEDIENTE oLogAExpedienteSitd = new Log_ANTECEDENTE_EXPEDIENTE();
                            Dat_ANTECEDENTE_EXPEDIENTE dat = new Dat_ANTECEDENTE_EXPEDIENTE();
                            dat.RegGrabarV3(cn, oParamsAExpedienteSitd, tr);
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
                resultado.AddResultado(ex.Message, false);
            }
            return resultado;
        }
        private void setListCheckToObject(string ListCheckIds, ref CEntidad obj)
        {
            if ((ListCheckIds ?? "") != "")
            {
                string[] lstTema = ListCheckIds.Split(',');
                for (int i = 0; i < lstTema.Length; i++)
                {
                    PropertyInfo pi = obj.GetType().GetProperty(lstTema[i]);
                    pi.SetValue(obj, true, null);
                }
            }
        }

        #endregion
        public void setArchivoDetRegente(Ent_Persona entP, string name)
        {
            
            using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
            {
                cn.Open();
                oCDatos.setArchivoDetRegenete(cn,entP,name);
            }
        }

    }
}
