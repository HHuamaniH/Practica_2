using CapaDatos;
using CapaEntidad.DOC;
using CapaEntidad.ViewModel;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
//using System.Data.SqlClient;
using System.IO;
using System.Web;
using CDatos = CapaDatos.DOC.Dat_RESODIREC;
using CEntidad = CapaEntidad.DOC.Ent_RESODIREC;
//using Tra_M_Tramite = CapaEntidad.DOC.Tra_M_Tramite;

namespace CapaLogica.DOC
{
    /// <summary>
    /// 
    /// </summary>
    public class Log_RESODIREC
    {
        private CDatos oCDatos = new CDatos();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="oCampoEntrada"></param>
        /// <returns></returns>
        public String RegGrabarResodirec(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegGrabarResodirec(cn, oCampoEntrada);
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
        public CEntidad RegMostrariNFORME_Buscar(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegMostrariNFORME_Buscar(cn, oCampoEntrada);
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
        public CEntidad RegMostrarListaResoDirecItem(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegMostrarListaResoDirecItem(cn, oCampoEntrada);
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
        public CEntidad RegMostListPOAs(CEntidad oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegMostListPOAs(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CEntidad RegNumExpediente(CEntidad oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegNumExpediente(cn, oCEntidad);
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
        /// <param name="oCampoEntrada"></param>
        /// <returns></returns>
        public List<CEntidad> RegImportarIncisos(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegImportarIncisos(cn, oCampoEntrada);
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
        public Int32 RegPreProcesarObservatorio(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegPreProcesarObservatorio(cn, oCampoEntrada);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Int32 RegPublicarObservatorio(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegPublicarObservatorio(cn, oCampoEntrada);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        ////////////////////////////////// 666
        /*
        public Int32 INSERTAUPDATE_MANDATOS(CEntidad oCampoEntrada)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
                {
                    cn.Open();
                    return oCDatos.INSERTAUPDATE_MANDATOS(cn, oCampoEntrada);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        */
        /// <summary>
        /// 
        /// </summary>
        /// <param name="oCampoEntrada"></param>
        /// <returns></returns>
        public List<CEntidad> RegTitularBuscar(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegTitularBuscar(cn, oCampoEntrada);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// metodo para obtener el balance de extraccion 
        /// 16/05/2019
        /// </summary>
        /// <param name="oCampoEntrada"></param>
        /// <returns></returns>
        //public List<CEntidad> RegImportarBalanceExt(CEntidad oCampoEntrada)
        //{
        //    try
        //    {
        //        using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
        //        {
        //            cn.Open();
        //            return oCDatos.RegEspecieBExt(cn, oCampoEntrada);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        /// <summary>
        /// metodo para obtener la lista de encisos 05/09/2016
        /// </summary>
        /// <param name="oCampoEntrada"></param>
        /// <returns></returns>
        //public List<CEntidad> RegListEncisosLog(CEntidad oCampoEntrada)
        //{
        //    try
        //    {
        //        using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
        //        {
        //            cn.Open();
        //            return oCDatos.RegEncisosList(cn, oCampoEntrada);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        /// <summary>
        /// metodo para listar la gravedad de daño de la RD de termino
        /// 15/09/2016
        /// </summary>
        /// <param name="oCampoEntrada"></param>
        /// <returns></returns>
        public List<CEntidad> RegListarComboGravedad(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.dat_ComboListarGravedad(cn, oCampoEntrada);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// metodo para listar las Resoluciones asociadas a un expediente para su rectificación
        /// </summary>
        /// <param name="oCampoEntrada"></param>
        /// <returns></returns>
        //public List<CEntidad> RegListarRD_Rectificacion(CEntidad oCampoEntrada)
        //{
        //    try
        //    {
        //        using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
        //        {
        //            cn.Open();
        //            return oCDatos.dat_ListRD_Rectificacion(cn, oCampoEntrada);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        /// <summary>
        /// metodo para obtener la lista de especies para rectificar en la rd de rectificacion
        /// </summary>
        /// <param name="oCampoEntrada"></param>
        /// <returns></returns>
        //public List<CEntidad> log_ListEspecieError(CEntidad oCampoEntrada)
        //{
        //    try
        //    {
        //        using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
        //        {
        //            cn.Open();
        //            return oCDatos.dat_ListEspecies_Recitificar(cn, oCampoEntrada);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public List<CEntidad> log_ListTitular(CEntidad oCampoEntrada)
        //{
        //    try
        //    {
        //        using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
        //        {
        //            cn.Open();
        //            return oCDatos.dat_ListTitulares_Recitificar(cn, oCampoEntrada);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public List<CEntidad> RegMostrarTHabilitante_Buscar(CEntidad oCampoEntrada)
        //{
        //    try
        //    {
        //        using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
        //        {
        //            cn.Open();
        //            return oCDatos.RegMostrarTHabilitante_Buscar(cn, oCampoEntrada);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //public List<CEntidad> RegMostrarTHabilitanteSup_Buscar(CEntidad oCampoEntrada)
        //{
        //    try
        //    {
        //        using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
        //        {
        //            cn.Open();
        //            return oCDatos.RegMostrarItemTHSupQuinquenal(cn, oCampoEntrada);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //public List<CEntidad> RegMostrarTHabilitanteMuestraBuscar(CEntidad oCampoEntrada)
        //{
        //    try
        //    {
        //        using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
        //        {
        //            cn.Open();
        //            return oCDatos.RegMostrarItemTHMuestraQuinquenal(cn, oCampoEntrada);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public void RegMuestraQuinquenalGrabar(List<CEntidad> oCampoEntrada)
        //{
        //    try
        //    {
        //        using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
        //        {
        //            cn.Open();
        //            oCDatos.grabarMuestraQuinquenal(cn, oCampoEntrada);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        /// <summary>
        /// metodo para obtener el balance de extraccion 
        /// 22/05/2019
        /// </summary>
        /// <param name="oCampoEntrada"></param>
        /// <returns></returns>
        //public List<CEntidad> RegImportarBalanceExt_ALERTA(CEntidad oCampoEntrada)
        //{
        //    try
        //    {
        //        using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
        //        {
        //            cn.Open();
        //            return oCDatos.RegEspecieBExt_ALERTA(cn, oCampoEntrada);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public List<Tra_M_Tramite> selectExpedienteMC(Tra_M_Tramite tramite)
        //{
        //    try
        //    {
        //        using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
        //        {
        //            cn.Open();
        //            return oCDatos.selectExpedienteMC(cn, tramite);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        #region "Seguimiento Medidas - SIGOsfc Beta"
        //public VM_SeguimientoMedida InitSeguimientoMedida(string asCodResodirec)
        //{
        //    VM_SeguimientoMedida vm = new VM_SeguimientoMedida();
        //    Ent_RESODIREC_MEDIDA_SEGUIMIENTO entSeguimiento;

        //    try
        //    {
        //        if (string.IsNullOrEmpty(asCodResodirec)) throw new Exception("El expediente a consultar no existe");

        //        entSeguimiento = oCDatos.RegMostrarItemSeguimientoMedida(new Ent_RESODIREC_MEDIDA_SEGUIMIENTO() { COD_RESODIREC = asCodResodirec });
        //        if (string.IsNullOrEmpty(entSeguimiento.COD_RESODIREC)) throw new Exception("El expediente a consultar no existe");

        //        vm.lblTituloCabecera = "Seguimiento de Medidas Correctivas/Mandatos";
        //        vm.lblTituloEstado = "Detalle";
        //        vm.hdfCodResodirec = entSeguimiento.COD_RESODIREC;
        //        vm.txtModalidad = entSeguimiento.MODALIDAD;
        //        vm.txtNumExpediente = entSeguimiento.NUM_EXPEDIENTE;
        //        vm.txtNumTHabilitante = entSeguimiento.NUM_THABILITANTE;
        //        vm.txtTitular = entSeguimiento.TITULAR;

        //        vm.tbMedidaCorrectiva = entSeguimiento.ListMedidaCorrectiva;
        //        vm.tbMandato = entSeguimiento.ListMandato;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //    return vm;
        //}
        /// <summary>
        /// metodo para exportar los registros
        /// </summary>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public List<Dictionary<string, string>> registroUsuarioRD(CEntidad oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegistroUsuarios(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //metodo de llamado con el controlador para exportar los registros 
        public ListResult RegistroUsuario(string asCodUsuario)
        {
            ListResult result = new ListResult();

            try
            {
                CEntidad paramCap = new CEntidad();
                //CLogica exeCap = new CLogica();
                paramCap.BusFormulario = "REGISTRO_USUARIO";
                paramCap.BusCriterio = "RESOLUCION_DIRECTORAL";
                paramCap.COD_UCUENTA = asCodUsuario;

                List<Dictionary<string, string>> olResult = registroUsuarioRD(paramCap);

                if (olResult.Count > 0)
                {
                    string rutaBase = HttpContext.Current.Server.MapPath("~/Archivos/Plantilla/Reg_Usu/");
                    string nombreFile = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + ".xlsx";
                    string rutaExcel = rutaBase + nombreFile;
                    string rutaExcelBase = rutaBase + "RESODIREC_REG.xlsx";

                    try
                    {
                        File.Delete(@rutaExcel);
                        File.Copy(@rutaExcelBase, @rutaExcel);
                    }
                    catch (IOException ix)
                    {
                        throw new Exception(ix.Message);
                    }

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
                        string insertar = "";
                        int i = 1, ind = 1;
                        //Abrimos la conexión
                        conn.Open();
                        //Creamos la ficha
                        using (OleDbCommand cmd = conn.CreateCommand())
                        {
                            cmd.CommandType = CommandType.Text;
                            //Construyendo las Cabeceras
                            foreach (var itemPart in olResult)
                            {
                                insertar = "'" + (ind++).ToString() + "'";
                                insertar = insertar + ",'" + (itemPart["FECHA_CREACION"] ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart["NUMERO_RESOLUCION"] ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart["TIPO_FISCALIZA"] ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart["NUMERO_EXPEDIENTE"] ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart["NUMERO_INFORME"] ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart["OD_AMBITO"] ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart["USUARIO"] ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart["ESTADO_CALIDAD"] ?? "") + "'";
                                cmd.CommandText = "INSERT INTO [Datos$A" + i.ToString().Trim() + ":AZ" + (olResult.Count + 1).ToString() + "] VALUES (" + insertar + ")";
                                cmd.ExecuteNonQuery();
                            }

                            //Cerramos la conexión
                            conn.Close();
                        }
                    }

                    result.success = true;
                    result.msj = nombreFile;
                }
                else { throw new Exception("No se encontraron registros"); }
            }
            catch (Exception ex)
            {
                result.success = false;
                result.msj = ex.Message;
            }
            return result;
        }

        public ListResult InfraccionesRD(VM_Resodirec _dto)
        {
            ListResult result = new ListResult();
            try
            {
                if (_dto.ListarIniPAU.Count > 0)
                {
                    string rutaBase = HttpContext.Current.Server.MapPath("~/Archivos/Plantilla/Reg_Usu/");
                    string nombreFile = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + ".xlsx";
                    string rutaExcel = rutaBase + nombreFile;
                    string rutaExcelBase = rutaBase + "RESODIREC_INFRACCIONES.xlsx";

                    try
                    {
                        File.Delete(@rutaExcel);
                        File.Copy(@rutaExcelBase, @rutaExcel);
                    }
                    catch (IOException ix)
                    {
                        throw new Exception(ix.Message);
                    }
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
                        string insertar = "";
                        int i = 1, ind = 1;
                        //Abrimos la conexión
                        conn.Open();
                        //Creamos la ficha
                        using (OleDbCommand cmd = conn.CreateCommand())
                        {
                            cmd.CommandType = CommandType.Text;
                            //Construyendo las Cabeceras
                            foreach (var itemPart in _dto.ListarIniPAU)
                            {
                                insertar = "'" + (ind++).ToString() + "'";
                                insertar = insertar + ",'" + (itemPart.DESCRIPCION_ARTICULOS ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart.DESCRIPCION_ENCISOS ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart.VOLUMEN.ToString() ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart.PCA.ToString() ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart.DESCRIPCION_ESPECIE ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart.AREA.ToString() ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart.NUMERO_INDIVIDUOS.ToString() ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart.DESCRIPCION_INFRACCIONES ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart.POA ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart.TIPOMADERABLE ?? "") + "'";

                                cmd.CommandText = "INSERT INTO [Datos$A" + i.ToString().Trim() + ":AZ" + (_dto.ListarIniPAU.Count + 1).ToString() + "] VALUES (" + insertar + ")";
                                cmd.ExecuteNonQuery();
                            }

                            //Cerramos la conexión
                            conn.Close();
                        }
                    }

                    result.success = true;
                    result.msj = nombreFile;
                }
                else { throw new Exception("No se encontraron registros"); }
            }
            catch (Exception ex)
            {
                result.success = false;
                result.msj = ex.Message;
            }
            return result;
        }
        #endregion

        public VM_RSD_Resumen RSD_Resumen(string COD_RESDIR, string asCodTipoIL)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RSD_Resumen(cn, COD_RESDIR, asCodTipoIL);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //CARR migracion
        public VM_Resodirec initRD(string asCodResodirec, string asCodTipo)
        {
            VM_Resodirec vm = new VM_Resodirec();
            try
            {
                //vm.lblTituloCabecera = "Resolucion Directoral";
                if (String.IsNullOrEmpty(asCodResodirec))
                {
                    //nuevo;
                    vm.lblTituloCabecera = "Nuevo Registro";
                    vm.vmControlCalidad = new VM_ControlCalidad_2();
                    vm.vmControlCalidad.ddlIndicadorId = "0000000";
                    vm.hdfCodFCTipo = asCodTipo;
                    initBusquedaModal(asCodTipo, vm);
                    initCombosRD(vm);
                    // initPoas(vm);
                    vm.listInformes = new List<CEntidad>();
                    vm.ListMandato = new List<Ent_RESODIREC_MEDIDA>();
                    vm.ListMedCorrectiva = new List<Ent_RESODIREC_MEDIDA>();
                    vm.ListEspecieMedCorrectiva = new List<Ent_RESODIREC_MEDIDA_ESPECIE>();
                    vm.ListPOA = new List<CEntidad>();
                    vm.ListarIniPAU = new List<CEntidad>();
                    vm.ListEspeciesMC = new List<CEntidad>();
                    vm.ListMotivoArchivo = new List<CEntidad>();
                    vm.RegEstado = 1;
                    vm.ListSTD01 = new List<CEntidad>();
                    vm.ListSTD02 = new List<CEntidad>();
                    vm.listaArticulos = initCombos("ARTICULOS_SUBSANADOS", "");
                    vm.listaInfracciones = new List<CEntidad>();

                    switch (asCodTipo)
                    {
                        case "0000008"://Archivo del Informe de Supervision
                            vm.txtTipoFiscaliza = "Archivo del Informe de Supervisión";
                            break;

                        case "0000009":////Inicio PAU  
                            vm.txtTipoFiscaliza = "Inicio PAU";
                            break;

                        case "0000010"://Ampliación PAU
                            vm.txtTipoFiscaliza = "Ampliación PAU";
                            break;

                        case "0000011"://Término PAU
                            vm.txtTipoFiscaliza = "Término PAU";
                            break;

                        case "0000088"://Conservación Acto Administrativo
                            vm.txtTipoFiscaliza = "Conservación Acto Administrativo";
                            break;

                        case "0000012"://Rectificación  
                            vm.txtTipoFiscaliza = "Rectificación";
                            break;

                        case "0000013"://Acumulación de Expedientes con PAU  
                            vm.txtTipoFiscaliza = "Acumulación de Expedientes con PAU";
                            break;

                        case "0000014"://Recurso de Reconsideracón
                            vm.txtTipoFiscaliza = "Recurso de Reconsideración";
                            break;

                        case "0000015"://Medidas Cautelares  
                            vm.txtTipoFiscaliza = "Variación de Medidas Cautelares";
                            break;

                        case "0000016"://Otros 
                            vm.txtTipoFiscaliza = "Otros";
                            break;

                        case "0000075"://Renuncia Concesión
                            vm.txtTipoFiscaliza = "Caducidad por Renuncia del Titular";
                            break;

                        case "0000100"://Auditoria quinquenal  
                            vm.txtTipoFiscaliza = "Auditoria Quinquenal";
                            break;
                        case "0000105"://Variación de Imputación de Cargos
                            vm.txtTipoFiscaliza = "Variación de Imputación de Cargos";
                            break;

                        case "0000111"://Aplicación de Medidas Cautelares (Antes del PAU)
                            vm.txtTipoFiscaliza = "Aplicación de Medidas Cautelares (Antes del PAU)";
                            break;

                        case "0000130"://Adecuación de Multa
                            vm.txtTipoFiscaliza = "Adecuación de Multa";
                            break;

                    }
                }
                else
                {
                    //editando
                    CEntidad oCEntidadRD = RegMostrarListaResoDirecItem(new CEntidad() { COD_RESODIREC = asCodResodirec });
                    vm.lblTituloCabecera = "Modificando Registro";
                    vm.hdfCodResodirec = asCodResodirec;
                    vm.txtTipoFiscaliza = oCEntidadRD.TIPO_FISCALIZA;
                    vm.hdfCodPersona = oCEntidadRD.COD_PERSONA;
                    vm.txtApellidosNombres = oCEntidadRD.APELLIDOS_NOMBRES;
                    vm.txtNumeroResolucion = oCEntidadRD.NUMERO_RESOLUCION;
                    vm.txtFechaEmision = oCEntidadRD.FECHA_EMISION.ToString();
                    vm.txtFechaAnulacion = oCEntidadRD.FECHA_ANULACION.ToString();
                    vm.chkResDir = (bool)oCEntidadRD.RESDIR;
                    vm.chkResSubDir = (bool)oCEntidadRD.RESSUBDIR;
                    vm.RegEstado = 0;
                    vm.hdfCodFCTipo = oCEntidadRD.COD_FCTIPO;
                    vm.chkPublicar = (bool)oCEntidadRD.PUBLICAR;
                    //para el control de calidad
                    //control de calidad
                    vm.vmControlCalidad = new VM_ControlCalidad_2();
                    vm.vmControlCalidad.ddlIndicadorId = oCEntidadRD.COD_ESTADO_DOC;
                    vm.vmControlCalidad.txtUsuarioRegistro = oCEntidadRD.USUARIO_REGISTRO;
                    vm.vmControlCalidad.txtUsuarioControl = oCEntidadRD.USUARIO_CONTROL;
                    vm.vmControlCalidad.chkObsSubsanada = (bool)oCEntidadRD.OBSERV_SUBSANAR;
                    vm.vmControlCalidad.txtControlCalidadObservaciones = oCEntidadRD.OBSERVACIONES_CONTROL.ToString();

                    vm.ListSTD01 = oCEntidadRD.listSTD01;
                    vm.ListSTD02 = oCEntidadRD.listSTD02;

                    //lista de expedientes
                    vm.listInformes = oCEntidadRD.ListInformes;

                    //iniciando modal de busqueda
                    initBusquedaModal(vm.hdfCodFCTipo, vm);

                    vm.txtNumeroExpediente = oCEntidadRD.NUMERO_EXPEDIENTE;

                    vm.chkSolAntecedente = (bool)oCEntidadRD.SOLICITUD_ANTECEDENTES;
                    vm.chkSancionExTitular = (bool)oCEntidadRD.SANCION_EXTITULAR;
                    vm.txtTitular = oCEntidadRD.TITULAR;
                    vm.hdfCodTitular = oCEntidadRD.COD_TITULAR;
                    vm.txtObservacones = oCEntidadRD.DESCRIPCION;

                    //notificacion a intituciones
                    vm.chkDGFFS = (bool)oCEntidadRD.DGFFS;
                    vm.txtDescDGFFS = oCEntidadRD.DETALLE_DGFFS;
                    vm.chkProgramaRegional = (bool)oCEntidadRD.PROGRAMA_REGIONAL;
                    vm.txtDescProgramaRegional = oCEntidadRD.DETALLE_PROREG;
                    vm.chkMinPublico = (bool)oCEntidadRD.MINISTERIO_PUBLICO;
                    vm.txtDescMinPublico = oCEntidadRD.DETALLE_MINPUB;
                    vm.chkColegioIng = (bool)oCEntidadRD.COLEGIO_INGENIEROS;
                    vm.txtDescColegioIng = oCEntidadRD.DETALLE_COLING;
                    vm.chkATFFS = (bool)oCEntidadRD.ATFFS;
                    vm.txtDescATFFS = oCEntidadRD.DETALLE_ATFFS;
                    vm.chkOCI = (bool)oCEntidadRD.OCI;
                    vm.txtDescOCI = oCEntidadRD.DETALLE_OCI;
                    vm.chkOEFA = (bool)oCEntidadRD.OEFA;
                    vm.txtDescOEFA = oCEntidadRD.DETALLE_OEFA;
                    vm.chkSUNAT = (bool)oCEntidadRD.SUNAT;
                    vm.txtDescSUNAT = oCEntidadRD.DETALLE_SUNAT;
                    vm.chkSERFOR = (bool)oCEntidadRD.SERFOR;
                    vm.txtDescSERFOR = oCEntidadRD.DETALLE_SERFOR;
                    vm.chkOTROS1 = (bool)oCEntidadRD.OTROS;
                    vm.txtDescOTROS1 = oCEntidadRD.DETALLE_OTROS;
                    vm.chkMINEMMIN = (bool)oCEntidadRD.MIN_ENERGIA_MINAS;
                    vm.txtDescMINEMMIN = oCEntidadRD.DETALLE_MINENMIN;

                    ///RD inicio PAU
                    ///variables para medidas cautelares / medidas precuatorias
                    vm.chkMedCautelar = (bool)oCEntidadRD.MEDIDAS_CAUTELARES;
                    vm.chkMedGTF = (bool)oCEntidadRD.MED_CAUT_GTF;
                    vm.chkMedLisTrozas = (bool)oCEntidadRD.MED_CAUT_LIST_TROZA;
                    vm.chkMedPM = (bool)oCEntidadRD.MED_CAUT_PM;
                    vm.chkMedPOA = (bool)oCEntidadRD.MED_CAUT_POA;
                    vm.chkMedEspecie = (bool)oCEntidadRD.MED_CAUT_XESPECIE;
                    vm.txtDescMedidaCautelar = oCEntidadRD.DESCRIPCION_MEDIDAS_PAU;


                    vm.chkSolBalance = (bool)oCEntidadRD.SOLICITUD_BALANCE;
                    vm.chkCausalesCaducidad = (bool)oCEntidadRD.CAUSALES_CADUCIDAD;
                    vm.chkInfFalsaInex = (bool)oCEntidadRD.INFORMACION_FALSA_INEX;
                    vm.chkInfFalsaDif = (bool)oCEntidadRD.INFORMACION_FALSA_DIF;
                    vm.chkInfFalsaDas = (bool)oCEntidadRD.INFORMACION_FALSA_DAS;
                    vm.txtDescInfFalsa = oCEntidadRD.DESCRIPCION_INFORMACION_FALSA;
                    vm.chkNoExisteAprovechamiento = (bool)oCEntidadRD.SIN_INDICIOS_APROV;
                    ///variables para mandatos
                    vm.chkMandatos = (bool)oCEntidadRD.MANDATOS;
                    vm.oMandato = new Ent_RESODIREC_MEDIDA();
                    vm.ListMandato = oCEntidadRD.ListMandatos;
                    ///variables para medidas correctivas
                    vm.oMedCorrectiva = new Ent_RESODIREC_MEDIDA();
                    vm.ListMedCorrectiva = oCEntidadRD.ListMedidasCorrectivas;
                    vm.ListEspecieMedCorrectiva = new List<Ent_RESODIREC_MEDIDA_ESPECIE>(); //oCEntidadRD.ListEspeciesMedidas;
                    ///para las infracciones
                    vm.txtBExtraccionFEmision = (string)oCEntidadRD.BEXTRACCION_FEMISION;
                    vm.txtDescInfraacion = oCEntidadRD.DESCRIPCION_INFRACCIONES;
                    
                    ///inicializamos algunos combos
                    //vm.listaEspeciesFloraCombo = initCombos("ESPECIES", "");
                    initCombosRD(vm);
                    vm.ListPOA = new List<CEntidad>();
                    //para obtener los poas
                    if (oCEntidadRD.ListPOAs.Count == 0)
                    {
                        initPoas(vm);
                    }
                    else {
                        vm.ListPOAOBSERVATORIO = oCEntidadRD.ListPOAs;
                        vm.ListPOA = oCEntidadRD.ListPOAs;
                    }
                    //lista de infracciones
                    vm.ListarIniPAU = oCEntidadRD.ListarIniPAU;
                    //especies con medidad cuatelares
                    vm.ListEspeciesMC = oCEntidadRD.ListEspeciesMedidas;
                    vm.ListMotivoArchivo = new List<CEntidad>();
                    // rd termino
                    vm.hdfCodExTitulat = oCEntidadRD.COD_TITULAR;
                    vm.txtExtitular = oCEntidadRD.TITULAR;
                    vm.txtIdDetermina = oCEntidadRD.COD_RESUDIREC_PAU_FIN_TIPO;
                    vm.chkCaducidadTH = (bool)oCEntidadRD.CADUCIDAD;
                    vm.chkSancionExTitular2 = (bool)oCEntidadRD.SANCION_EXTITULAR;
                    vm.chkAmonestacion = (bool)oCEntidadRD.AMONESTACION;
                    vm.chkMulta = (bool)oCEntidadRD.MULTA;
                    vm.txtMonMulta = oCEntidadRD.MONTO.ToString();
                    vm.chkDesc30 = (bool)oCEntidadRD.DESCUENTO;
                    vm.txtIdGravedad = oCEntidadRD.COD_RESODIREC_GRAVEDAD;
                    vm.chkNoev_Aprov = (bool)oCEntidadRD.SIN_INDICIOS_APROV;

                    vm.chkGTFMP = (bool)oCEntidadRD.MED_CAUT_GTF;
                    vm.chkMedLisTrozasMP = (bool)oCEntidadRD.MED_CAUT_LIST_TROZA;
                    vm.chkMedEspecieMP = (bool)oCEntidadRD.MED_CAUT_XESPECIE;
                    vm.chkRectificacion = (bool)oCEntidadRD.RECTIFICACION;
                    vm.txtDesRectificacion = oCEntidadRD.DESC_RECTIFICACION;
                    vm.chkMCorrectivas = (bool)oCEntidadRD.MEDIDAS_CORRECTIVAS;
                    // rd reconsideracion
                    vm.chkInadmisible = (bool)oCEntidadRD.INADMISIBLE;
                    vm.chkImprocedente = (bool)oCEntidadRD.IMPROCEDENTE;
                    vm.chkFundada = (bool)oCEntidadRD.FUNDADA;
                    vm.chkFundadaParte = (bool)oCEntidadRD.FUNDADA_PARTE;
                    vm.chkInFundada = (bool)oCEntidadRD.INFUNDADA;
                    vm.chkLevantarCaducidad = (bool)oCEntidadRD.LEVANTAR_CADUCIDAD;
                    vm.chkCambioMulta = (bool)oCEntidadRD.RECONS_CAMBIO_MULTA;
                    vm.txtMonMultaRecon = oCEntidadRD.RECONS_MONTO.ToString();
                    vm.ListMotivoArchivo = oCEntidadRD.MotivoArchivo;

                    //rd otros
                    vm.txtDescOtrosRD = oCEntidadRD.DESCRIPCION_OTROS;
                    //rd archivo
                    vm.txtNumExpeAsignado = oCEntidadRD.EXPEDIENTE_ADMINISTRATIVO_ASIGNADO;
                    vm.chkeviirre = (bool)oCEntidadRD.EVIDENCIA_IRREGULARIDAD;
                    vm.chkbueman = (bool)oCEntidadRD.BUEN_MANEJO;
                    vm.chkdefnot = (bool)oCEntidadRD.DEFICIENTE_NOTIFICACION;
                    vm.chkdeftec = (bool)oCEntidadRD.DEFICIENCIA_TECNICA;
                    vm.chksininf = (bool)oCEntidadRD.SIN_INFRACCION;
                    vm.txtOtrosArchivo = oCEntidadRD.OTROS_arch;
                    //rd ampliacion
                    vm.chkmotamp_ampimp = (bool)oCEntidadRD.MOTAMP_AMPIMP;
                    vm.chkmotamp_ampotrinf = (bool)oCEntidadRD.MOTAMP_AMPOTRINF;
                    vm.chkmotamp_ampporpla = (bool)oCEntidadRD.MOTAMP_AMPPORPLA;
                    vm.txtmotamp_otros = oCEntidadRD.MOTAMP_OTROS;
                    // rd acumulacion
                    vm.txtDescAcumulacion = oCEntidadRD.DESCRIPCION_ACUMULACION;
                    // rd variacion de medidas cautelares
                    vm.txtMedidaCaut = oCEntidadRD.DESCRIPCION_MEDIDAS_PAU;
                    vm.chklevmed = (bool)oCEntidadRD.LEV_MED_CAUTELAR;
                    vm.chklevParmed = (bool)oCEntidadRD.LEV_PARTE_MED_CAUTELAR;
                    vm.chkNoLevmed = (bool)oCEntidadRD.NO_LEV_MED_CAUTELAR;
                    vm.chkmodmed = (bool)oCEntidadRD.MOD_MED_CAUTELAR;
                    vm.txtdesmed = oCEntidadRD.DESCRIPCION_MED_CAUTELAR;
                    //conservacion acto administrativo
                    vm.txtMotConservActoAdm = oCEntidadRD.MOTAMP_OTROS;
                    //adecuacion de multa
                    vm.txtAdecuMonto = oCEntidadRD.MONTO.ToString();
                    //rectificacion
                    vm.chkErrorMaterial = (bool)oCEntidadRD.ERROR_MATERIAL;
                    vm.chkNomTitError = (bool)oCEntidadRD.NOM_TITULAR;
                    vm.chkNumTitError = (bool)oCEntidadRD.NUM_TITULO;
                    vm.txtNumtitError = oCEntidadRD.DESC_NUM_TIT;
                    vm.chkNumExpdError = (bool)oCEntidadRD.NUM_EXP;
                    vm.txtNumExpdError = oCEntidadRD.DESC_NUM_EXPE;
                    vm.chkFechaError = (bool)oCEntidadRD.FECHA_EMISION1;
                    vm.txtFechaError = oCEntidadRD.DESC_FECHA.ToString();
                    vm.chkEspeciesError = (bool)oCEntidadRD.ESPECIES;
                    vm.chkRectifmonto = (bool)oCEntidadRD.RECTIF_CAMBIO_MULTA;
                    vm.txtRectifmonto = oCEntidadRD.RECTIF_MONTO.ToString();
                    vm.chkotrosrec = (bool)oCEntidadRD.OTROS_RECTIFICACION;
                    vm.txtotrosrec = oCEntidadRD.TEXTO_RECTIFICACION;
                    vm.listInfracionReconsideracion = oCEntidadRD.ListLiterales;

                    //23.08.2021 CARR
                    vm.chkAccion = (bool)oCEntidadRD.CHK_ACCION;
                    vm.chkAllanamiento = (bool)oCEntidadRD.CHK_ALLANAMIENTO;
                    vm.chkSubsanacion = (bool)oCEntidadRD.CHK_SUBSANACION;
                    vm.chkMedidaCompl = (bool)oCEntidadRD.CHK_MEDCOMPLE;
                    vm.chkDecomiso = (bool)oCEntidadRD.CHK_DECOMISO;
                    vm.chkPlanCierre = (bool)oCEntidadRD.CHK_PLANCIERRE;
                    vm.chkDisposicionFauna = (bool)oCEntidadRD.CHK_DIPOSICIONFAUNA;


                    if (oCEntidadRD.ListMedidasCorrectivas.Count > 0)
                    {
                        vm.ListEspecieMedCorrectiva = oCEntidadRD.ListMedidasCorrectivas[0].ListEspeciesMCorrectiva;
                    }

                    //21.09.2022 TGS
                    vm.chkTerceroSolidario= (oCEntidadRD.COD_TERCERO_SOLIDARIO.Trim()=="")?false:true;
                    vm.hdfCodTerceroSolidario = oCEntidadRD.COD_TERCERO_SOLIDARIO;
                    vm.txtTerceroSolidario = oCEntidadRD.TERCERO_SOLIDARIO;
                    vm.chkSubsVoluntaria = (Boolean)oCEntidadRD.SUBSANACION_VOLUNTARIA;
                    vm.listaArticulos = initCombos("ARTICULOS_SUBSANADOS", "");
                    vm.listaInfracciones = oCEntidadRD.ListIncisos;
                }
            }
            catch (Exception)
            {

            }
            return vm;
        }

        public List<Ent_SBusqueda> initCombos(string criterio, string valor)
        {
            try
            {
                CEntidad oCampoEntrada = new CEntidad();
                oCampoEntrada.BusFormulario = "COMBO_INDIVIDUAL";
                oCampoEntrada.BusCriterio = criterio; //"ARTICULOS";
                oCampoEntrada.BusValor = valor;
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegMostCombo_V3(cn, oCampoEntrada);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// metodo para el modal de busqueda de expedientes
        /// </summary>
        /// <param name="codTipoLegal"></param>
        /// <param name="vm"></param>
        public void initBusquedaModal(string codTipoLegal, VM_Resodirec vm)
        {
            List<Ent_SBusqueda> listCombo = new List<Ent_SBusqueda>();
            Ent_SBusqueda Combo = new Ent_SBusqueda();
            vm.sBusqueda = new List<Ent_SBusqueda>();
            vm.txtTituloInfraccion = "Infracciones presuntamente incurridas";
            switch (codTipoLegal)
            {
                case "0000008"://Archivo del Informe de Supervision
                    listCombo = new List<Ent_SBusqueda>();
                    Combo = new Ent_SBusqueda();
                    Combo.Value = "INF_QUINQ";
                    Combo.Text = "Inf. Audi. Quinquenal";
                    listCombo.Add(Combo);

                    Combo = new Ent_SBusqueda();
                    Combo.Value = "IAF_NUMERO";
                    Combo.Text = "Informe Autoridad Forestal";
                    listCombo.Add(Combo);

                    Combo = new Ent_SBusqueda();
                    Combo.Value = "INF_NUMERO";
                    Combo.Text = "Informes OSINFOR";
                    listCombo.Add(Combo);

                    vm.txtTituloModal = "Lista de Informes de Supervisión, Suspensión, Cancelación y/o Técnicos";

                    vm.hdfTipoDocumento = "ARCHIVO DE INFORME DE SUPERVISION";
                    break;

                case "0000009":////Inicio PAU  
                    listCombo = new List<Ent_SBusqueda>();
                    Combo = new Ent_SBusqueda();
                    Combo.Value = "EXPADM_NUMERO";
                    Combo.Text = "Nro. Expediente";
                    listCombo.Add(Combo);

                    Combo = new Ent_SBusqueda();
                    Combo.Value = "REN_NUMERO";
                    Combo.Text = "Solicitud de Renuncia a la Concesión";
                    listCombo.Add(Combo);

                    Combo = new Ent_SBusqueda();
                    Combo.Value = "IAF_NUMERO";
                    Combo.Text = "Informe Autoridad Forestal";
                    listCombo.Add(Combo);

                    Combo = new Ent_SBusqueda();
                    Combo.Value = "INF_QUINQ";
                    Combo.Text = "Inf. Audi. Quinquenal";
                    listCombo.Add(Combo);

                    Combo = new Ent_SBusqueda();
                    Combo.Value = "INF_NUMERO";
                    Combo.Text = "Informes OSINFOR";
                    listCombo.Add(Combo);

                    vm.txtTituloModal = "Lista de Informes de Supervisión, Suspensión, Cancelación, Técnicos y/o Exp. Administrativo";
                    vm.hdfTipoDocumento = "INICIO PAU";
                    break;

                case "0000010"://Ampliación PAU
                    listCombo = new List<Ent_SBusqueda>();
                    Combo = new Ent_SBusqueda();
                    Combo.Value = "EXPADM_NUMERO";
                    Combo.Text = "Nro. Expediente";
                    listCombo.Add(Combo);
                    vm.txtTituloModal = "Lista de Expedientes Administrativos";
                    vm.hdfTipoDocumento = "AMPLIACION DE PAU";
                    break;

                case "0000011"://Término PAU
                    listCombo = new List<Ent_SBusqueda>();
                    Combo = new Ent_SBusqueda();
                    Combo.Value = "EXPADM_NUMERO";
                    Combo.Text = "Nro. Expediente";
                    listCombo.Add(Combo);
                    vm.txtTituloModal = "Lista de Expedientes Administrativos";
                    vm.txtTituloInfraccion = "Infracciones acreditadas";
                    vm.hdfTipoDocumento = "TERMINO DE PAU";
                    break;

                case "0000088"://Conservación Acto Administrativo
                    listCombo = new List<Ent_SBusqueda>();
                    Combo = new Ent_SBusqueda();
                    Combo.Value = "EXPADM_NUMERO";
                    Combo.Text = "Nro. Expediente";
                    listCombo.Add(Combo);
                    vm.txtTituloModal = "Lista de Expedientes Administrativos";
                    vm.hdfTipoDocumento = "CONSERVACION ACTO ADMINISTRATIVO";
                    break;

                case "0000012"://Rectificación  
                    listCombo = new List<Ent_SBusqueda>();
                    Combo = new Ent_SBusqueda();
                    Combo.Value = "EXPADM_NUMERO";
                    Combo.Text = "Nro. Expediente";
                    listCombo.Add(Combo);
                    vm.txtTituloModal = "Lista de Expedientes Administrativos";
                    vm.hdfTipoDocumento = "RECTIFICACION";
                    break;

                case "0000013"://Acumulación de Expedientes con PAU  
                    listCombo = new List<Ent_SBusqueda>();
                    Combo = new Ent_SBusqueda();
                    Combo.Value = "EXPADM_NUMERO";
                    Combo.Text = "Nro. Expediente";
                    listCombo.Add(Combo);
                    vm.txtTituloModal = "Lista de Expedientes Administrativos";
                    vm.hdfTipoDocumento = "ACUMULACION DE EXPEDIENTES CON PAU";
                    break;

                case "0000014"://Recurso de Reconsideracón
                    listCombo = new List<Ent_SBusqueda>();
                    Combo = new Ent_SBusqueda();
                    Combo.Value = "EXPADM_NUMERO";
                    Combo.Text = "Nro. Expediente";
                    listCombo.Add(Combo);
                    vm.txtTituloModal = "Lista de Expedientes Administrativos";
                    vm.hdfTipoDocumento = "EVALUACION DE RECONSIDERACION";
                    break;

                case "0000015"://Medidas Cautelares  
                    listCombo = new List<Ent_SBusqueda>();
                    Combo = new Ent_SBusqueda();
                    Combo.Value = "EXPADM_NUMERO";
                    Combo.Text = "Nro. Expediente";
                    listCombo.Add(Combo);
                    vm.txtTituloModal = "Lista de Expedientes Administrativos";
                    vm.hdfTipoDocumento = "LEVANTAMIENTO DE MEDIDAS CAUTELARES";
                    break;

                case "0000016"://Otros 
                    listCombo = new List<Ent_SBusqueda>();
                    Combo = new Ent_SBusqueda();
                    Combo.Value = "EXPADM_NUMERO";
                    Combo.Text = "Nro. Expediente";
                    listCombo.Add(Combo);
                    vm.txtTituloModal = "Lista de Expedientes Administrativos";
                    vm.hdfTipoDocumento = "RD_OTROS";
                    break;

                case "0000075"://Renuncia Concesión
                    listCombo = new List<Ent_SBusqueda>();
                    Combo = new Ent_SBusqueda();
                    Combo.Value = "REN_NUMERO";
                    Combo.Text = "Solicitud de Renuncia a la Concesión";
                    listCombo.Add(Combo);
                    vm.txtTituloModal = "Lista de Solicitudes de Renuncia a la Concesión";
                    vm.hdfTipoDocumento = "RD_RENUNCIA_CONCESION";
                    break;

                case "0000100"://Auditoria quinquenal  
                    vm.hdfTipoDocumento = "RD_AUDITORIA_QUINQUENAL";
                    break;

                case "0000105"://Variación de Imputación de Cargos
                    listCombo = new List<Ent_SBusqueda>();
                    Combo = new Ent_SBusqueda();
                    Combo.Value = "EXPADM_NUMERO";
                    Combo.Text = "Nro. Expediente";
                    listCombo.Add(Combo);
                    vm.txtTituloModal = "Lista de Expedientes Administrativos";
                    vm.hdfTipoDocumento = "RD VARIACION CARGOS";
                    break;

                case "0000111"://Aplicación de Medidas Cautelares (Antes del PAU)
                    listCombo = new List<Ent_SBusqueda>();
                    Combo = new Ent_SBusqueda();
                    Combo.Value = "REN_NUMERO";
                    Combo.Text = "Solicitud de Renuncia a la Concesión";
                    listCombo.Add(Combo);
                    Combo = new Ent_SBusqueda();
                    Combo.Value = "IAF_NUMERO";
                    Combo.Text = "Informe Autoridad Forestal";
                    listCombo.Add(Combo);
                    Combo = new Ent_SBusqueda();
                    Combo.Value = "INF_NUMERO";
                    Combo.Text = "Informes OSINFOR";
                    listCombo.Add(Combo);
                    vm.txtTituloModal = "Lista de Informes de Supervisión, Suspensión, Cancelación, Técnicos y/o Alertas";
                    vm.hdfTipoDocumento = "RD_MED_CAU_ANTES_PAU";

                    break;

                case "0000130"://Adecuación de Multa
                    listCombo = new List<Ent_SBusqueda>();
                    Combo = new Ent_SBusqueda();
                    Combo.Value = "EXPADM_NUMERO";
                    Combo.Text = "Nro. Expediente";
                    listCombo.Add(Combo);
                    vm.txtTituloModal = "Lista de Expedientes Administrativos";
                    vm.hdfTipoDocumento = "ADECUACION DE MULTA";

                    break;

            }
            vm.sBusqueda = listCombo;
        }

        public void initCombosRD(VM_Resodirec vmRD)
        {
            CEntidad oCEntidad = new CEntidad();
            //oCEntidad.COD_UCUENTA = "20150000025";
            oCEntidad.BusFormulario = "RESOLUCION_DIRECTORAL";
            oCEntidad = this.RegMostCombo(oCEntidad);
            vmRD.ListRecomendacion = oCEntidad.ListTipoDeter;
            vmRD.ListArticulo = oCEntidad.ListArticulosPAU;
            vmRD.listaEspeciesFloraCombo = oCEntidad.ListEspeciesForestal;
            vmRD.listaEspeciesFaunaCombo = oCEntidad.ListEspeciesFauna;
            vmRD.listComboTipoArchivo = oCEntidad.ListTipoArchivo;
            vmRD.ListSubTipoArchivo = new List<Ent_SBusqueda>();
            CEntidad oCamposB = new CEntidad();
            oCamposB.ListComboGravedad = this.RegListarComboGravedad(oCamposB);
            vmRD.listComboGravedad = oCamposB.ListComboGravedad;
            Ent_SBusqueda sTipo = new Ent_SBusqueda();
            vmRD.ListTipo = new List<Ent_SBusqueda>();
            sTipo = new Ent_SBusqueda();
            sTipo.Value = "MADERABLES";
            sTipo.Text = "MADERABLES";
            vmRD.ListTipo.Add(sTipo);
            sTipo = new Ent_SBusqueda();
            sTipo.Value = "NO MADERABLES";
            sTipo.Text = "NO MADERABLES";
            vmRD.ListTipo.Add(sTipo);
            sTipo = new Ent_SBusqueda();
            sTipo.Value = "CARBON";
            sTipo.Text = "CARBÓN";
            vmRD.ListTipo.Add(sTipo);

        }

        public List<Ent_SBusqueda> initArticulos(string criterio, string valor)
        {
            try
            {
                CEntidad oCampoEntrada = new CEntidad();
                oCampoEntrada.BusFormulario = "COMBO_INDIVIDUAL";
                oCampoEntrada.BusCriterio = criterio; //"ARTICULOS";
                oCampoEntrada.BusValor = valor;
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegMostCombo_V3(cn, oCampoEntrada);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void initPoas(VM_Resodirec vmRD)
        {
            if (vmRD.listInformes.Count > 0)
            {
                List<Ent_RESODIREC> listPoa = new List<Ent_RESODIREC>();
                //CLogica exeBus = new CLogica();
                Ent_RESODIREC oCEntidad = new Ent_RESODIREC();
                oCEntidad.BusFormulario = "RESOLUCION_DIRECTORAL";
                oCEntidad.BusCriterio = "LISTA_POAS";
                oCEntidad.BusValor = "";
                foreach (var fila in vmRD.listInformes)
                {

                    if ((fila.COD_RESODIREC != " ") && (fila.COD_RESODIREC_INI_PAU != " ") && (fila.COD_RESODIREC != null) && (fila.COD_RESODIREC_INI_PAU != null))
                    {
                        oCEntidad.TIPO = "EX";
                        if (oCEntidad.BusValor == "") { oCEntidad.BusValor = fila.COD_RESODIREC; }
                        else { oCEntidad.BusValor = oCEntidad.BusValor + "," + fila.COD_RESODIREC; }

                    }
                    else if (fila.COD_RESODIREC != " " && fila.COD_RESODIREC != null)
                    {
                        oCEntidad.TIPO = "RD";
                        if (oCEntidad.BusValor == "") { oCEntidad.BusValor = fila.COD_RESODIREC; }
                        else { oCEntidad.BusValor = oCEntidad.BusValor + "," + fila.COD_RESODIREC; }
                    }
                    else if (fila.COD_INFORME != " " && fila.COD_INFORME != null)
                    {
                        oCEntidad.TIPO = "IN";
                        if (oCEntidad.BusValor == "") { oCEntidad.BusValor = fila.COD_INFORME; }
                        else { oCEntidad.BusValor = oCEntidad.BusValor + "," + fila.COD_INFORME; }
                    }
                }
                oCEntidad = this.RegMostListPOAs(oCEntidad);
                vmRD.ListPOA = oCEntidad.ListPOAs;
                vmRD.ListPOAOBSERVATORIO = oCEntidad.ListPOAs;
            }
        }

        private void ValidarDatos(VM_Resodirec _dto)
        {
            var errores = new List<string>();
            if (_dto.vmControlCalidad.ddlIndicadorId == "0000000") errores.Add("Seleccione el estado actual del registro");
            //if (string.IsNullOrEmpty(_dto.txtNumeroResolucion)) errores.Add("Ingrese el número de Resolución Directoral");
            if (string.IsNullOrEmpty(_dto.txtFechaEmision)) errores.Add("Seleccione la fecha de emisión");
            if (_dto.listInformes == null) errores.Add("Seleccione un informe, expediente");
            //if (_dto.hdfCodTipoIlegal == "0000001" && _dto.txtIdRecomendacion == "0000000") errores.Add("Seleccione una recomendación");

            if (errores.Count > 0)
            {
                throw new Exception(string.Join("<br>", errores.ToArray()));
            }
            if (_dto.vmControlCalidad.ddlIndicadorId == "0000000") throw new Exception("Seleccione el estado actual del registro");
            //if (string.IsNullOrEmpty(_dto.txtNumeroResolucion)) throw new Exception("Ingrese el número de Resolución Directoral");
            if (string.IsNullOrEmpty(_dto.txtFechaEmision)) throw new Exception("Seleccione la fecha de emisión");
            if (_dto.listInformes == null) throw new Exception("Seleccione un informe, expediente");
            if (_dto.chkMedidaCompl == true)
            {
                if (_dto.chkDecomiso == false && _dto.chkPlanCierre == false && _dto.chkDisposicionFauna == false)
                {
                    throw new Exception("Seleccione una medida complementaria");
                }
            }
            if (_dto.chkAccion == true)
            {
                if (_dto.chkAllanamiento == false && _dto.chkSubsanacion == false)
                {
                    throw new Exception("Seleccione una acción");
                }
            }
            if (_dto.hdfCodPersona == " ") throw new Exception("Seleccione funcionario responsable del resgitro");
            //if (_dto.hdfCodTipoIlegal == "0000001" && _dto.txtIdRecomendacion == "0000000") throw new Exception("Seleccione una recomendación");
        }

        //metodo para guardar los registros
        public ListResult GuardarDatosRD(VM_Resodirec _dto, string asCodUCuenta)
        {
            ListResult result = new ListResult();
            try
            {
                this.ValidarDatos(_dto);
                CEntidad oCEntResodirec = new CEntidad();

                oCEntResodirec.COD_FCTIPO = _dto.hdfCodFCTipo;
                oCEntResodirec.COD_UCUENTA = asCodUCuenta;
                if (!string.IsNullOrEmpty(_dto.hdfCodPersona?.Trim()))
                {
                    oCEntResodirec.COD_PERSONA = _dto.hdfCodPersona.Trim();
                }
                
                oCEntResodirec.COD_RESODIREC = _dto.hdfCodResodirec;
                oCEntResodirec.DESCRIPCION = _dto.txtObservacones;
                oCEntResodirec.NUMERO_RESOLUCION = _dto.txtNumeroResolucion;
                oCEntResodirec.FECHA_EMISION = Convert.ToDateTime(_dto.txtFechaEmision);

                oCEntResodirec.RESDIR = _dto.chkResDir;
                oCEntResodirec.RESSUBDIR = _dto.chkResSubDir;

                //Variables de control de calidad
                oCEntResodirec.COD_ESTADO_DOC = _dto.vmControlCalidad.ddlIndicadorId;
                oCEntResodirec.OBSERVACIONES_CONTROL = _dto.vmControlCalidad.txtControlCalidadObservaciones;
                oCEntResodirec.OBSERV_SUBSANAR = _dto.vmControlCalidad.chkObsSubsanada;

                oCEntResodirec.PUBLICAR = _dto.chkPublicar;

                // oCEntResodirec.FECHA_ANULACION = _dto.txtFechaAnulacion;

                oCEntResodirec.COD_OD_REGISTRO = "0000001";//ddlODRegistro.SelectedValue;
                oCEntResodirec.COD_TITULAR = _dto.hdfCodTitular == " " ? null : _dto.hdfCodTitular;
                oCEntResodirec.TITULAR = _dto.txtTitular == " " ? null : _dto.txtTitular;


                oCEntResodirec.DGFFS = _dto.chkDGFFS;
                oCEntResodirec.ATFFS = _dto.chkATFFS;
                oCEntResodirec.OCI = _dto.chkOCI;
                oCEntResodirec.OEFA = _dto.chkOEFA;
                oCEntResodirec.SUNAT = _dto.chkSUNAT;
                oCEntResodirec.SERFOR = _dto.chkSERFOR;
                oCEntResodirec.PROGRAMA_REGIONAL = _dto.chkProgramaRegional;
                oCEntResodirec.MINISTERIO_PUBLICO = _dto.chkMinPublico;
                oCEntResodirec.COLEGIO_INGENIEROS = _dto.chkColegioIng;
                oCEntResodirec.OTROS = _dto.chkOTROS1;

                //cambios de acuerdo a la capcitacion 31/08/2016
                oCEntResodirec.MIN_ENERGIA_MINAS = _dto.chkMINEMMIN;

                oCEntResodirec.DETALLE_MINENMIN = _dto.txtDescMINEMMIN;

                oCEntResodirec.DETALLE_DGFFS = _dto.txtDescDGFFS;
                oCEntResodirec.DETALLE_PROREG = _dto.txtDescProgramaRegional;
                oCEntResodirec.DETALLE_MINPUB = _dto.txtDescMinPublico;
                oCEntResodirec.DETALLE_COLING = _dto.txtDescColegioIng;
                oCEntResodirec.DETALLE_ATFFS = _dto.txtDescATFFS;
                oCEntResodirec.DETALLE_OCI = _dto.txtDescOCI;
                oCEntResodirec.DETALLE_OEFA = _dto.txtDescOEFA;
                oCEntResodirec.DETALLE_SUNAT = _dto.txtDescSUNAT;
                oCEntResodirec.DETALLE_SERFOR = _dto.txtDescSERFOR;
                oCEntResodirec.DETALLE_OTROS = _dto.txtDescOTROS1;

                //oCEntResodirec.FECHA_CREACION = "";
                oCEntResodirec.RegEstado = _dto.RegEstado;

                /*
                // para la muestra de los quinquenales
                if (txtFechaCampoTHQ.Text != "")
                {
                    oCEntResodirec.FECHA_CAMPO = txtFechaCampoTHQ.Text;
                }
                List<CEntidadR> ListMuestraQuinquenal = new List<CEntidadR>();
                ListMuestraQuinquenal = (List<CEntidadR>)Session["listMuestraEspecies"];
                if (ListMuestraQuinquenal != null)
                {
                    if (ListMuestraQuinquenal.Count > 0)
                    {
                        oCEntResodirec.ListQuinquenalMuestra = ListMuestraQuinquenal;
                    }
                }
                */
                //RECTIFICACION DE LA R.D. 13/09/2017
                oCEntResodirec.RECTIFICACION = _dto.chkRectificacion;
                oCEntResodirec.DESC_RECTIFICACION = _dto.txtDesRectificacion;

                oCEntResodirec.OUTPUTPARAM01 = "";
                oCEntResodirec.OUTPUTPARAM02 = "";

                switch (_dto.hdfCodFCTipo)
                {
                    case "0000008":
                        //GrabarArch_Informe();

                        oCEntResodirec.EXPEDIENTE_ADMINISTRATIVO_ASIGNADO = _dto.txtNumExpeAsignado;
                        oCEntResodirec.EVIDENCIA_IRREGULARIDAD = _dto.chkeviirre;
                        oCEntResodirec.BUEN_MANEJO = _dto.chkbueman;
                        oCEntResodirec.DEFICIENTE_NOTIFICACION = _dto.chkdefnot;
                        oCEntResodirec.DEFICIENCIA_TECNICA = _dto.chkdeftec;
                        oCEntResodirec.SIN_INFRACCION = _dto.chksininf;
                        oCEntResodirec.OTROS_arch = _dto.txtOtrosArchivo;
                        oCEntResodirec.COD_TITULAR = null;
                        oCEntResodirec.TITULAR = null;
                        oCEntResodirec.SUBSANACION_VOLUNTARIA = _dto.chkSubsVoluntaria;
                        oCEntResodirec.ListIncisos = _dto.listaInfracciones;
                        oCEntResodirec.ListEliTABLAIncisos = _dto.tbEliTABLAEnciso;

                        //oCEntResodirec.l
                        break;
                    case "0000009":
                        oCEntResodirec.COD_RESODIREC_INI_PAU = "";
                        oCEntResodirec.NUMERO_EXPEDIENTE = _dto.txtNumeroExpediente;
                        oCEntResodirec.MEDIDAS_CAUTELARES = _dto.chkMedCautelar;
                        oCEntResodirec.DESCRIPCION_MEDIDAS_PAU = _dto.txtDescMedidaCautelar;
                        oCEntResodirec.CAUSALES_CADUCIDAD = _dto.chkCausalesCaducidad;
                        oCEntResodirec.SOLICITUD_ANTECEDENTES = _dto.chkSolAntecedente;
                        oCEntResodirec.SOLICITUD_BALANCE = _dto.chkSolBalance;
                        oCEntResodirec.TIPO = "IP";
                        oCEntResodirec.SANCION_EXTITULAR = _dto.chkSancionExTitular;
                        oCEntResodirec.INFORMACION_FALSA_INEX = _dto.chkInfFalsaInex;
                        oCEntResodirec.INFORMACION_FALSA_DIF = _dto.chkInfFalsaDif;
                        oCEntResodirec.INFORMACION_FALSA_DAS = _dto.chkInfFalsaDas;
                        oCEntResodirec.DESCRIPCION_INFORMACION_FALSA = _dto.txtDescInfFalsa;
                        oCEntResodirec.SIN_INDICIOS_APROV = _dto.chkNoExisteAprovechamiento;
                        //modificaciones 01/08/2016
                        oCEntResodirec.MED_CAUT_GTF = _dto.chkMedGTF;
                        oCEntResodirec.MED_CAUT_LIST_TROZA = _dto.chkMedLisTrozas;
                        oCEntResodirec.MED_CAUT_PM = _dto.chkMedPM;
                        oCEntResodirec.MED_CAUT_POA = _dto.chkMedPOA;
                        oCEntResodirec.MED_CAUT_XESPECIE = _dto.chkMedEspecie;
                        if (_dto.txtBExtraccionFEmision != null)
                        {
                            if (_dto.txtBExtraccionFEmision.Trim() != "")
                            {
                                oCEntResodirec.BEXTRACCION_FEMISION = Convert.ToDateTime(_dto.txtBExtraccionFEmision);
                            }
                        }
                        oCEntResodirec.MANDATOS = _dto.chkMandatos;
                        oCEntResodirec.ListEspeciesMedidas = _dto.ListEspeciesMC;

                        //lista de expedientes de tramite documentario 20/09/2022 TGS
                        oCEntResodirec.listSTD01 = _dto.ListSTD01;
                        oCEntResodirec.listSTD02 = _dto.ListSTD02;
                        oCEntResodirec.listEliTSTD01 = _dto.ListEliTSTD01;
                        oCEntResodirec.COD_TERCERO_SOLIDARIO = _dto.hdfCodTerceroSolidario == " " ? null : _dto.hdfCodTerceroSolidario;
                        oCEntResodirec.ListIncisos = _dto.listaInfracciones;
                        oCEntResodirec.ListEliTABLAIncisos = _dto.tbEliTABLAEnciso;
                        break;
                    case "0000010":
                        oCEntResodirec.COD_RESODIREC_INI_PAU = "";
                        oCEntResodirec.MOTAMP_AMPIMP = _dto.chkmotamp_ampimp;
                        oCEntResodirec.MOTAMP_AMPOTRINF = _dto.chkmotamp_ampotrinf;
                        oCEntResodirec.MOTAMP_AMPPORPLA = _dto.chkmotamp_ampporpla;
                        oCEntResodirec.MOTAMP_OTROS = _dto.txtmotamp_otros;
                        oCEntResodirec.COD_TITULAR = null;
                        oCEntResodirec.TITULAR = null;

                        oCEntResodirec.MEDIDAS_CAUTELARES = _dto.chkMedCautelar;
                        oCEntResodirec.DESCRIPCION_MEDIDAS_PAU = _dto.txtDescMedidaCautelar;
                        oCEntResodirec.CAUSALES_CADUCIDAD = _dto.chkCausalesCaducidad;
                        oCEntResodirec.TIPO = "AP";
                        oCEntResodirec.DESCRIPCION_INFORMACION_FALSA = _dto.txtDescInfFalsa;
                        if (_dto.txtBExtraccionFEmision != null)
                        {
                            if (_dto.txtBExtraccionFEmision.Trim() != "")
                            {
                                oCEntResodirec.BEXTRACCION_FEMISION = Convert.ToDateTime(_dto.txtBExtraccionFEmision);
                            }
                        }
                        oCEntResodirec.MED_CAUT_GTF = _dto.chkMedGTF;
                        oCEntResodirec.MED_CAUT_LIST_TROZA = _dto.chkMedLisTrozas;
                        oCEntResodirec.MED_CAUT_PM = _dto.chkMedPM;
                        oCEntResodirec.MED_CAUT_POA = _dto.chkMedPOA;
                        oCEntResodirec.MED_CAUT_XESPECIE = _dto.chkMedEspecie;
                        oCEntResodirec.ListEspeciesMedidas = _dto.ListEspeciesMC;

                        //22.09.2022 TGS
                        oCEntResodirec.COD_TERCERO_SOLIDARIO = _dto.hdfCodTerceroSolidario == " " ? null : _dto.hdfCodTerceroSolidario;

                        break;
                    case "0000011":
                        oCEntResodirec.COD_RESODIREC_INI_PAU = "";
                        oCEntResodirec.COD_RESUDIREC_PAU_FIN_TIPO = _dto.txtIdDetermina;

                        if (oCEntResodirec.COD_RESUDIREC_PAU_FIN_TIPO == "0000001")//Sanción
                        {
                            oCEntResodirec.MULTA = _dto.chkMulta;
                            oCEntResodirec.MONTO = string.IsNullOrEmpty(_dto.txtMonMulta) ? 0 : Decimal.Parse(_dto.txtMonMulta);
                            oCEntResodirec.MEDIDAS_CAUTELARES = _dto.chkMedCautelar;
                            oCEntResodirec.DESCRIPCION_MEDIDAS_PAU = _dto.txtDescMedidaCautelar;
                            oCEntResodirec.CADUCIDAD = _dto.chkCaducidadTH;
                            oCEntResodirec.MEDIDAS_CORRECTIVAS = _dto.chkMCorrectivas;
                            oCEntResodirec.SANCION_EXTITULAR = _dto.chkSancionExTitular2;
                            oCEntResodirec.TITULAR = _dto.txtExtitular;
                            oCEntResodirec.COD_TITULAR = _dto.hdfCodExTitulat;
                            oCEntResodirec.MED_CAUT_GTF = _dto.chkGTFMP;
                            oCEntResodirec.MED_CAUT_LIST_TROZA = _dto.chkMedLisTrozasMP;
                            oCEntResodirec.MED_CAUT_XESPECIE = _dto.chkMedEspecieMP;
                            oCEntResodirec.AMONESTACION = _dto.chkAmonestacion;
                            if (_dto.txtBExtraccionFEmision != null)
                            {
                                if (_dto.txtBExtraccionFEmision.Trim() != "")
                                {
                                    oCEntResodirec.BEXTRACCION_FEMISION = Convert.ToDateTime(_dto.txtBExtraccionFEmision);
                                }
                            }




                        }
                        else if (oCEntResodirec.COD_RESUDIREC_PAU_FIN_TIPO == "0000002")//archivo
                        {
                            oCEntResodirec.MULTA = false;
                            oCEntResodirec.MONTO = 0;
                            oCEntResodirec.MEDIDAS_CAUTELARES = false;
                            oCEntResodirec.DESCRIPCION_MEDIDAS_PAU = null;
                            oCEntResodirec.CADUCIDAD = false;
                            oCEntResodirec.MEDIDAS_CORRECTIVAS = false;
                            oCEntResodirec.SANCION_EXTITULAR = false;
                            oCEntResodirec.MED_CAUT_GTF = false;
                            oCEntResodirec.MED_CAUT_LIST_TROZA = false;
                            oCEntResodirec.MED_CAUT_XESPECIE = false;
                            oCEntResodirec.AMONESTACION = false;
                            oCEntResodirec.BEXTRACCION_FEMISION = null;
                            oCEntResodirec.COD_TITULAR = null;
                            oCEntResodirec.TITULAR = null;
                        }

                        oCEntResodirec.TIPO = "TP";
                        oCEntResodirec.SIN_INDICIOS_APROV = _dto.chkNoev_Aprov;
                        oCEntResodirec.DESCUENTO = _dto.chkDesc30;
                        oCEntResodirec.MED_CAUT_PM = _dto.chkMedPM;

                        if (_dto.txtIdGravedad != "0000000")
                        {
                            oCEntResodirec.COD_RESODIREC_GRAVEDAD = _dto.txtIdGravedad;
                        }
                        oCEntResodirec.ListEspeciesMedidas = _dto.ListEspeciesMC;
                        oCEntResodirec.MotivoArchivo = _dto.ListMotivoArchivo;

                        oCEntResodirec.CHK_ACCION = _dto.chkAccion;
                        oCEntResodirec.CHK_ALLANAMIENTO = _dto.chkAllanamiento;
                        oCEntResodirec.CHK_SUBSANACION = _dto.chkSubsanacion;
                        oCEntResodirec.CHK_MEDCOMPLE = _dto.chkMedidaCompl;
                        oCEntResodirec.CHK_DECOMISO = _dto.chkDecomiso;
                        oCEntResodirec.CHK_PLANCIERRE = _dto.chkPlanCierre;
                        oCEntResodirec.CHK_DIPOSICIONFAUNA = _dto.chkDisposicionFauna;

                        //oCEntResodirec.listEliTSTD01 = _dto.listEliTSTD01;
                        //oCEntResodirec.listEliTSTD02 = _dto.listEliTSTD02;
                        oCEntResodirec.listSTD01 = _dto.ListSTD01;
                        oCEntResodirec.listSTD02 = _dto.ListSTD02;
                        oCEntResodirec.listEliTSTD01 = _dto.ListEliTSTD01;

                        //22.09.2022 TGS
                        oCEntResodirec.COD_TERCERO_SOLIDARIO = _dto.hdfCodTerceroSolidario == " " ? null : _dto.hdfCodTerceroSolidario;
                        oCEntResodirec.ListIncisos = _dto.listaInfracciones;
                        oCEntResodirec.ListEliTABLAIncisos = _dto.tbEliTABLAEnciso;
                        break;
                    case "0000012":
                        //GrabarRECTIFICACION();
                        oCEntResodirec.ERROR_MATERIAL = _dto.chkErrorMaterial;
                        oCEntResodirec.NOM_TITULAR = _dto.chkNomTitError;
                        oCEntResodirec.NUM_TITULO = _dto.chkNumTitError;
                        oCEntResodirec.DESC_NUM_TIT = _dto.txtNumtitError;
                        oCEntResodirec.NUM_EXP = _dto.chkNumExpdError;
                        oCEntResodirec.DESC_NUM_EXPE = _dto.txtNumExpdError;
                        oCEntResodirec.FECHA_EMISION1 = _dto.chkFechaError;
                        oCEntResodirec.DESC_FECHA = _dto.txtFechaError;
                        oCEntResodirec.ESPECIES = _dto.chkEspeciesError;
                        oCEntResodirec.RECTIF_CAMBIO_MULTA = _dto.chkRectifmonto;
                        if (_dto.chkRectifmonto) { oCEntResodirec.RECTIF_MONTO = _dto.txtRectifmonto.Trim() == "" || _dto.txtRectifmonto is null ? 0 : Decimal.Parse(_dto.txtRectifmonto.Trim()); }
                        else { oCEntResodirec.RECTIF_MONTO = 0; }
                        oCEntResodirec.OTROS_RECTIFICACION = _dto.chkotrosrec;
                        oCEntResodirec.TEXTO_RECTIFICACION = _dto.txtotrosrec;
                        oCEntResodirec.COD_TITULAR = null;
                        oCEntResodirec.TITULAR = null;

                        break;
                    case "0000013":
                        //GrabarACUMULACION();
                        oCEntResodirec.DESCRIPCION_ACUMULACION = _dto.txtDescAcumulacion;
                        oCEntResodirec.FECHA_ACUMULACION = "";
                        oCEntResodirec.COD_TITULAR = null;
                        oCEntResodirec.TITULAR = null;
                        break;
                    case "0000014":
                        //GrabarRECONSIDERACION();
                        oCEntResodirec.INADMISIBLE = _dto.chkInadmisible;
                        oCEntResodirec.IMPROCEDENTE = _dto.chkImprocedente;
                        oCEntResodirec.FUNDADA = _dto.chkFundada;
                        oCEntResodirec.FUNDADA_PARTE = _dto.chkFundadaParte;
                        oCEntResodirec.INFUNDADA = _dto.chkInFundada;
                        oCEntResodirec.LEVANTAR_CADUCIDAD = _dto.chkLevantarCaducidad;
                        oCEntResodirec.RECONS_CAMBIO_MULTA = _dto.chkCambioMulta;
                        oCEntResodirec.RECONS_MONTO = string.IsNullOrEmpty(_dto.txtMonMultaRecon) ? 0 : Decimal.Parse(_dto.txtMonMultaRecon);
                        oCEntResodirec.COD_TITULAR = null;
                        oCEntResodirec.TITULAR = null;
                        oCEntResodirec.ListLiterales = _dto.listInfracionReconsideracion;

                        //lista de expedientes de tramite documentario 20/09/2022 TGS
                        oCEntResodirec.listSTD02 = _dto.ListSTD02;
                        oCEntResodirec.listEliTSTD01 = _dto.ListEliTSTD01;
                        oCEntResodirec.ListIncisos = _dto.listaInfracciones;
                        oCEntResodirec.ListEliTABLAIncisos = _dto.tbEliTABLAEnciso;
                        break;
                    case "0000015":
                        //GrabarMEDIDACAUTELAR();
                        oCEntResodirec.NUMERO_EXPEDIENTE = "ALERTA";
                        oCEntResodirec.LEV_MED_CAUTELAR = _dto.chklevmed;
                        oCEntResodirec.MOD_MED_CAUTELAR = _dto.chkmodmed;
                        oCEntResodirec.DESCRIPCION_MED_CAUTELAR = _dto.txtdesmed;
                        oCEntResodirec.LEV_PARTE_MED_CAUTELAR = _dto.chklevParmed;
                        oCEntResodirec.NO_LEV_MED_CAUTELAR = _dto.chkNoLevmed;
                        oCEntResodirec.COD_TITULAR = null;
                        oCEntResodirec.TITULAR = null;
                        break;
                    case "0000016":
                        //GrabarOTROS();
                        oCEntResodirec.DESCRIPCION_OTROS = _dto.txtDescOtrosRD;
                        oCEntResodirec.COD_TITULAR = null;
                        oCEntResodirec.TITULAR = null;
                        break;
                    case "0000075":
                        //GrabarRenunciaConc();
                        oCEntResodirec.NUMERO_EXPEDIENTE = _dto.txtNumeroExpediente;
                        oCEntResodirec.CADUCIDAD = _dto.chkCaducidadTH;
                        oCEntResodirec.COD_TITULAR = null;
                        oCEntResodirec.TITULAR = null;
                        break;
                    case "0000088":
                        //GrabarConservActoAdm();
                        oCEntResodirec.COD_RESODIREC_INI_PAU = "";
                        oCEntResodirec.MOTAMP_OTROS = _dto.txtMotConservActoAdm;
                        oCEntResodirec.COD_TITULAR = null;
                        oCEntResodirec.TITULAR = null;
                        break;
                    case "0000100":
                        //GrabarRDQUINQUENAL();
                        break;
                    case "0000111":
                        //GrabarAplicacionMedCau();
                        oCEntResodirec.TIPO = "AM";
                        oCEntResodirec.COD_RESODIREC_INI_PAU = "";
                        oCEntResodirec.MEDIDAS_CAUTELARES = _dto.chkMedCautelar;
                        oCEntResodirec.DESCRIPCION_MEDIDAS_PAU = _dto.txtDescMedidaCautelar;
                        oCEntResodirec.MED_CAUT_GTF = _dto.chkMedGTF;
                        oCEntResodirec.MED_CAUT_LIST_TROZA = _dto.chkMedLisTrozas;
                        oCEntResodirec.MED_CAUT_PM = _dto.chkMedPM;
                        oCEntResodirec.MED_CAUT_POA = _dto.chkMedPOA;
                        oCEntResodirec.MED_CAUT_XESPECIE = _dto.chkMedEspecie;
                        oCEntResodirec.COD_TITULAR = null;
                        oCEntResodirec.TITULAR = null;
                        oCEntResodirec.ListEspeciesMedidas = _dto.ListEspeciesMC;
                        break;
                    case "0000130":
                        //GrabarAdecuacionMulta();
                        oCEntResodirec.TIPO = "AU";
                        oCEntResodirec.MONTO = _dto.txtAdecuMonto == "" ? 0 : Decimal.Parse(_dto.txtAdecuMonto);
                        oCEntResodirec.COD_TITULAR = null;
                        oCEntResodirec.TITULAR = null;

                        break;
                    case "0000105":
                        oCEntResodirec.COD_RESODIREC_INI_PAU = "";
                        oCEntResodirec.COD_TITULAR = null;
                        oCEntResodirec.TITULAR = null;
                        break;
                }
                //listas
                oCEntResodirec.ListInformes = _dto.listInformes;

                oCEntResodirec.ListarIniPAU = _dto.ListarIniPAU;
                oCEntResodirec.ListMandatos = _dto.ListMandato;

                oCEntResodirec.ListEliTABLA = _dto.listEliTabla;
                if (oCEntResodirec.ListEliTABLA == null)
                {
                    oCEntResodirec.ListEliTABLA = new List<CEntidad>();
                }
                if (_dto.listEliTablaEMC != null)
                {

                    //se agrega elementos a eliminar de especies con medidas correctivas
                    foreach (Ent_RESODIREC eli in _dto.listEliTablaEMC)
                    {
                        oCEntResodirec.ListEliTABLA.Add(eli);
                    }
                }
                if (_dto.listEliTablaInfracciones != null)
                {
                    foreach (Ent_RESODIREC eli in _dto.listEliTablaInfracciones)
                    {
                        oCEntResodirec.ListEliTABLA.Add(eli);
                    }
                }
                if (_dto.listEliTablaMandatos != null)
                {
                    foreach (Ent_RESODIREC eli in _dto.listEliTablaMandatos)
                    {
                        oCEntResodirec.ListEliTABLA.Add(eli);
                    }
                }
                if (_dto.ListMedCorrectiva != null)
                {
                    oCEntResodirec.ListMedidasCorrectivas = _dto.ListMedCorrectiva;
                    if (_dto.ListEspecieMedCorrectiva != null)
                    {
                        oCEntResodirec.ListMedidasCorrectivas[0].ListEspeciesMCorrectiva = _dto.ListEspecieMedCorrectiva;
                    }
                }
                if (_dto.listEliTablaMedidasCorrectivas != null)
                {
                    foreach (Ent_RESODIREC eli in _dto.listEliTablaMedidasCorrectivas)
                    {
                        oCEntResodirec.ListEliTABLA.Add(eli);
                    }
                }
                if (_dto.listEliTablEspeciesMC != null)
                {
                    foreach (Ent_RESODIREC eli in _dto.listEliTablEspeciesMC)
                    {
                        oCEntResodirec.ListEliTABLA.Add(eli);
                    }
                }

                if (_dto.listEliTablaMotivo != null)
                {
                    foreach (Ent_RESODIREC eli in _dto.listEliTablaMotivo)
                    {
                        oCEntResodirec.ListEliTABLA.Add(eli);
                    }
                }
                oCEntResodirec.ListPOAs = new List<CEntidad>();
                if (_dto.ListPOA != null)
                {
                    foreach (Ent_RESODIREC poa in _dto.ListPOA)
                    {
                        Ent_RESODIREC item = new Ent_RESODIREC();
                        item.NUM_POA = poa.NUM_POA;
                        item.COD_UCUENTA = asCodUCuenta;
                        if (_dto.ListPOAChecked != null)
                        {
                            foreach (string poacheck in _dto.ListPOAChecked)
                            {
                                Ent_RESODIREC item2 = new Ent_RESODIREC();
                                item2.NUM_POA = poacheck;
                                if (item.NUM_POA == item2.NUM_POA)
                                {
                                    item.PUBLICAR = true;
                                }
                            }
                        }
                        //item.PUBLICAR = _dto.chkPublicar;
                        oCEntResodirec.ListPOAs.Add(item);
                    }
                }                

                //ListPOAChecked
                var estado_final = this.RegGrabarResodirec(oCEntResodirec);
                result.AddResultado("Guardo Correctamente", true, new List<string>() { estado_final });
            }
            catch (Exception ex)
            {
                result.AddResultado(ex.Message, false);
            }
            return result;
        }

        private void GrabarIniPAU()
        {

            //modificaciones 17/09/2019 - mandatos
            //if (txtMandato.Text.ToString().Trim().Length > 0)
            //{
            //    oCEntResodirec.ESMANDATO = 1;
            //}
            //else
            //{
            //    oCEntResodirec.ESMANDATO = 0;
            //}
            //oCEntResodirec.MANDATO = txtMandato.Text.ToString().Trim().ToUpper();
            //oCEntResodirec.CANTMESES = Int32.Parse(txtMeses.Text);
            //oCEntResodirec.CANTDIAS = Int32.Parse(txtdias.Text);
        }

        //26.08.2021

        public List<Ent_SBusqueda> busCombo(CEntidad ent)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegMostCombo_V3(cn, ent);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Ent_RESODIREC_REPORTEMEDIDAD> reporteDetalle(CEntidad oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegReporteDetalle(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Ent_RESODIREC_REPORTEMEDIDAD> reporteDetalle2(CEntidad oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegReporteDetalle2(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ListResult exportReporteDetalle(List<Ent_RESODIREC_REPORTEMEDIDAD> list)
        {
            ListResult result = new ListResult();
            try
            {
                if (list.Count > 0)
                {
                    string rutaBase = HttpContext.Current.Server.MapPath("~/Archivos/Plantilla/Reg_Usu/");
                    string nombreFile = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + ".xlsx";
                    string rutaExcel = rutaBase + nombreFile;
                    string rutaExcelBase = rutaBase + "REPORTE_DETALLE01.xlsx";

                    try
                    {
                        File.Delete(@rutaExcel);
                        File.Copy(@rutaExcelBase, @rutaExcel);
                    }
                    catch (IOException ix)
                    {
                        throw new Exception(ix.Message);
                    }
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
                        string insertar = "";
                        int i = 2, ind = 1;
                        //Abrimos la conexión
                        conn.Open();
                        //Creamos la ficha
                        using (OleDbCommand cmd = conn.CreateCommand())
                        {
                            cmd.CommandType = CommandType.Text;
                            //Construyendo las Cabeceras
                            foreach (var itemPart in list)
                            {
                                insertar = "'" + (ind++).ToString() + "'";
                                insertar = insertar + ",'" + (itemPart.FECHA_EMSION ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart.TITULAR ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart.TITULO.ToString() ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart.RESOLUCION ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart.NUMERO_EXPEDIENTE ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart.SANCION ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart.AMONESTACION ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart.ARCHIVO ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart.ALLANAMIENTO ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart.SUBSANACION ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart.IMPL_MEDIDAS ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart.DECOMISO ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart.PLAN_CIERRE ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart.DISP_FAUNA ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart.MED_CORRECTIVA ?? "") + "'";
                                //insertar = insertar + ",'" + (itemPart.OBSERVACIONES ?? "") + "'";


                                cmd.CommandText = "INSERT INTO [Datos$A" + i.ToString().Trim() + ":AZ" + (list.Count + 1).ToString() + "] VALUES (" + insertar + ")";
                                cmd.ExecuteNonQuery();
                            }

                            //Cerramos la conexión
                            conn.Close();
                        }
                    }

                    result.success = true;
                    result.msj = nombreFile;
                }
                else { throw new Exception("No se encontraron registros"); }
            }
            catch (Exception ex)
            {
                result.success = false;
                result.msj = ex.Message;
            }
            return result;
        }

        public ListResult exportReporteDetalle2(List<Ent_RESODIREC_REPORTEMEDIDAD> list)
        {
            ListResult result = new ListResult();
            try
            {
                if (list.Count > 0)
                {
                    string rutaBase = HttpContext.Current.Server.MapPath("~/Archivos/Plantilla/Reg_Usu/");
                    string nombreFile = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + ".xlsx";
                    string rutaExcel = rutaBase + nombreFile;
                    string rutaExcelBase = rutaBase + "REPORTE_DETALLE02.xlsx";

                    try
                    {
                        File.Delete(@rutaExcel);
                        File.Copy(@rutaExcelBase, @rutaExcel);
                    }
                    catch (IOException ix)
                    {
                        throw new Exception(ix.Message);
                    }
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
                        string insertar = "";
                        int i = 2, ind = 1;
                        //Abrimos la conexión
                        conn.Open();
                        //Creamos la ficha
                        using (OleDbCommand cmd = conn.CreateCommand())
                        {
                            cmd.CommandType = CommandType.Text;
                            //Construyendo las Cabeceras
                            foreach (var itemPart in list)
                            {
                                insertar = "'" + (ind++).ToString() + "'";
                                insertar = insertar + ",'" + (itemPart.FECHA_EMSION ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart.TITULAR ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart.TITULO.ToString() ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart.RESOLUCION ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart.NUMERO_EXPEDIENTE ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart.MED_CAUTELAR ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart.GUIA_TF ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart.LISTA_TROZAS ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart.PLAN_MANEJO ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart.POA ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart.OBSERVACIONES ?? "") + "'";
                                cmd.CommandText = "INSERT INTO [Datos$A" + i.ToString().Trim() + ":AZ" + (list.Count + 1).ToString() + "] VALUES (" + insertar + ")";
                                cmd.ExecuteNonQuery();
                            }

                            //Cerramos la conexión
                            conn.Close();
                        }
                    }

                    result.success = true;
                    result.msj = nombreFile;
                }
                else { throw new Exception("No se encontraron registros"); }
            }
            catch (Exception ex)
            {
                result.success = false;
                result.msj = ex.Message;
            }
            return result;
        }
    }
}
